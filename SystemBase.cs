namespace ECSFramework
{
    public abstract class SystemBase
    {
        internal void Create() { OnCreate(); }
        protected virtual void OnCreate() { }

        public virtual void Tick() { }
    }
}