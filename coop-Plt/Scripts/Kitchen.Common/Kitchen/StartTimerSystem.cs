using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
	public class StartTimerSystem : GenericSystemBase
	{
		protected override void OnUpdate()
		{
			TimerSystems.FrameStartTime = UnityEngine.Time.realtimeSinceStartup;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
