using Timberborn.BaseComponentSystem;

namespace Timberborn.TickSystem
{
	public abstract class TickableComponent : BaseComponent, IStartableComponent
	{
		private bool _started;

		public virtual void StartTickable()
		{
		}

		public abstract void Tick();

		public void Start()
		{
			if (!_started)
			{
				StartTickable();
				_started = true;
			}
		}

		internal void StartAndTick()
		{
			Start();
			Tick();
		}
	}
}
