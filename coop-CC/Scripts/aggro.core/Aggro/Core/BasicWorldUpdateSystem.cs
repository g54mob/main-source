using UnityEngine;

namespace Aggro.Core
{
	[NoAutoCreation]
	public class BasicWorldUpdateSystem : EntitySystemBase
	{
		private InitializationUpdateSystemGroup _initGroup;

		private SimulationUpdateSystemGroup _simGroup;

		private PresentationUpdateSystemGroup _presGroup;

		public int Frame { get; private set; } = -1;

		public double ElapsedTimeInFrame { get; private set; }

		protected override void OnStartRunning()
		{
			_initGroup = base.world.GetOrCreateSystem<InitializationUpdateSystemGroup>();
			_simGroup = base.world.GetOrCreateSystem<SimulationUpdateSystemGroup>();
			_presGroup = base.world.GetOrCreateSystem<PresentationUpdateSystemGroup>();
		}

		protected override void OnUpdateSystem()
		{
			if (_initGroup.enabled)
			{
				_initGroup.Update();
			}
			if (_simGroup.enabled)
			{
				ElapsedTimeInFrame += Time.deltaTime;
				if (Frame == -1)
				{
					Frame++;
					_simGroup.Update();
				}
				while (ElapsedTimeInFrame >= (double)Time.fixedDeltaTime)
				{
					ElapsedTimeInFrame -= Time.fixedDeltaTime;
					Frame++;
					_simGroup.Update();
				}
			}
			if (_presGroup.enabled)
			{
				_presGroup.Update();
			}
		}
	}
}
