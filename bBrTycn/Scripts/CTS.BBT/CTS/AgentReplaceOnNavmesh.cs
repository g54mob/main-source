using System;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentReplaceOnNavmesh : CTSBehaviour, IFurnitureDisplacer
	{
		[Inject(false)]
		private Agent _agent;

		private readonly int[] _alloc = new int[32];

		public void Displace()
		{
			if (!(_agent.ContextualFSM.CurrentState is ContextualStateStuck) && TrySample(out var outHit, 0))
			{
				base.transform.position = outHit.position;
				_agent.ForceStop();
			}
			bool TrySample(out NavMeshHit reference, int distance)
			{
				reference = default(NavMeshHit);
				if ((float)distance > (float)_alloc.Length * 0.5f)
				{
					return false;
				}
				int num = Math.Max(1, distance * 2);
				Vector3 position = base.transform.position;
				float num2 = UnityEngine.Random.value * 360f;
				float num3 = 360f / (float)num;
				for (int i = 0; i < num; i++)
				{
					Vector3 vector = position + Quaternion.Euler(0f, num2 + num3 * (float)i, 0f) * Vector3.forward * distance;
					Debug.DrawRay(vector, Vector3.up, Color.red, 5f);
					if (NavMesh.SamplePosition(vector, out reference, 2f, -1))
					{
						return true;
					}
				}
				return TrySample(out reference, distance + 2);
			}
		}
	}
}
