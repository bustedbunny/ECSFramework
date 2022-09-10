using System;
using System.Collections.Generic;
using Mono.Unix.Native;
using Unity.Collections;
using Verse;

namespace ECSFramework
{
    public class BookKeeper : GameComponent
    {
        public static BookKeeper current;

        public BookKeeper(Game game)
        {
            current = this;
            _systems = new List<SystemBase>(50);
            _baseSystems = new Dictionary<Type, CompSystem>(50);

            RegisterCompSystems();
        }


        private void RegisterCompSystems()
        {
            foreach (var type in typeof(ThingComp).AllSubclassesNonAbstract())
            {
                var system = new CompSystem();
                system.Create();

                if (system.Init(type))
                {
                    _systems.Add(system);
                    _baseSystems.Add(type, system);
                }
            }
        }

        public override void GameComponentTick()
        {
            foreach (var systemBase in _systems)
            {
                systemBase.Tick();
            }
        }

        private readonly List<SystemBase> _systems;

        private readonly Dictionary<Type, CompSystem> _baseSystems;

        public void RegisterComp(ThingComp comp) => _baseSystems.TryGetValue(comp.GetType())?.Register(comp);

        public void UnregisterComp(ThingComp comp) => _baseSystems.TryGetValue(comp.GetType())?.Unregister(comp);
    }
}