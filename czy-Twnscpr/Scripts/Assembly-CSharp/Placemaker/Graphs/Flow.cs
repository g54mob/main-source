using System;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Graphs
{
	[Serializable]
	public class Flow : MonoBehaviour
	{
		private struct FlowCalcData
		{
			public FlowData flowData;

			public Corner corner;

			public int count;

			public int index;

			public bool availale;

			public bool open;

			public Vector3 pos;
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Transform test;

		private const float amountAdd = 1000000f;

		private void Update()
		{
		}

		private void FlowTwoFlows(ref FlowCalcData flow0, ref FlowCalcData flow1, float spaceDist)
		{
		}

		private void SetupFlowData(ref FlowCalcData flow0)
		{
		}

		public void AddFlowTarget(float3 worldPos)
		{
		}

		public (Vector3, Vector3, float, float) SampleFlow(Vector3 worldPos)
		{
			return default((Vector3, Vector3, float, float));
		}

		private void OnDrawGizmos()
		{
		}
	}
}
