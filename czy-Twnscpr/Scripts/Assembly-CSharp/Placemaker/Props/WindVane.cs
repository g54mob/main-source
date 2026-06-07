using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public class WindVane : MonoBehaviour, IPropModifier
	{
		[SerializeField]
		private Transform compass;

		[SerializeField]
		private Transform rotator;

		void IPropModifier.Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct)
		{
		}

		void IPropModifier.Reset(WorldMaster master, Transform srcT)
		{
		}
	}
}
