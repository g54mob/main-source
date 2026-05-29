using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropNgonScaler : MonoBehaviour, IPropModifier
	{
		void IPropModifier.Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct)
		{
		}

		void IPropModifier.Reset(WorldMaster master, Transform srcT)
		{
		}
	}
}
