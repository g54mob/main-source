using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropWireFlagMesh : MonoBehaviour, IPropModifier
	{
		[SerializeField]
		private Vector4 uv;

		public void Setup(WorldMaster master, PropWire wire, float length)
		{
		}

		void IPropModifier.Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct)
		{
		}

		void IPropModifier.Reset(WorldMaster master, Transform srcT)
		{
		}
	}
}
