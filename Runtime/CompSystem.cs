using System;
using System.Collections.Generic;
using Verse;

namespace ECSFramework
{
    public class CompSystem : SystemBase
    {
        protected override void OnCreate() { _comps = new List<ThingComp>(); }


        public bool Init(Type type)
        {
            if (type.GetMethod(nameof(ThingComp.CompTick))?.DeclaringType == type)
            {
                _tickerType = TickerType.Normal;
            }
            else if (type.GetMethod(nameof(ThingComp.CompTickRare))?.DeclaringType == type)
            {
                _tickerType = TickerType.Rare;
            }
            else if (type.GetMethod(nameof(ThingComp.CompTickLong))?.DeclaringType == type)
            {
                _tickerType = TickerType.Long;
            }

            Log.Message($"{type.Name} got {_tickerType}");

            return _tickerType != TickerType.Never;
        }

        private TickerType _tickerType;

        private List<ThingComp> _comps;
        public void Register(ThingComp comp) { _comps.Add(comp); }
        public void Unregister(ThingComp comp) { _comps.Remove(comp); }


        public override void Tick()
        {
            if (_tickerType == TickerType.Normal)
            {
                NormalTick();
            }
            else if (_tickerType == TickerType.Rare)
            {
                RareTick();
            }
            else if (_tickerType == TickerType.Long)
            {
                LongTick();
            }
        }

        private void NormalTick()
        {
            for (int i = _comps.Count - 1; i >= 0; i--)
            {
                _comps[i].CompTick();
            }
        }

        private void RareTick()
        {
            for (int i = _comps.Count - 1; i >= 0; i--)
            {
                var comp = _comps[i];
                if (comp.parent.IsHashIntervalTick(250))
                {
                    _comps[i].CompTickRare();
                }
            }
        }

        private void LongTick()
        {
            for (int i = _comps.Count - 1; i >= 0; i--)
            {
                var comp = _comps[i];
                if (comp.parent.IsHashIntervalTick(2000))
                {
                    _comps[i].CompTickRare();
                }
            }
        }
    }
}