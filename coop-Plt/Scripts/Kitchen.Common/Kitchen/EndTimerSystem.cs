using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
	public class EndTimerSystem : GenericSystemBase
	{
		protected override void OnUpdate()
		{
			TimerSystems.FrameTime = (UnityEngine.Time.realtimeSinceStartup - TimerSystems.FrameStartTime) * 0.75f + TimerSystems.FrameTime * 0.25f;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
