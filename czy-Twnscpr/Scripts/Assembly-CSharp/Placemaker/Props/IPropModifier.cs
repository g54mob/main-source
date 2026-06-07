using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public interface IPropModifier
	{
		void Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct);

		void Reset(WorldMaster master, Transform srcT);
	}
}
