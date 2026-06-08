using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[ExecuteAlways]
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
	public class EndSimBarrier : GroupedEntityCommandBufferSystem
	{
		public override ECB ECB => ECB.End;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
