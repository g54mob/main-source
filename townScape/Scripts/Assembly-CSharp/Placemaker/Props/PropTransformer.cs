using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropTransformer : MonoBehaviour, IPropModifier
	{
		public bool fitInSquare;

		public float scaleVariance;

		public float rotationVariance;

		public float3 posVariance;

		void IPropModifier.Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct)
		{
		}

		void IPropModifier.Reset(WorldMaster master, Transform srcT)
		{
		}
	}
}
