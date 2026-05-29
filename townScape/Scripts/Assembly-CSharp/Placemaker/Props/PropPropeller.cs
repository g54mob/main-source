using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropPropeller : MonoBehaviour, IPropModifier
	{
		[SerializeField]
		private bool forward;

		[SerializeField]
		private GameObject waterSplashEffect;

		void IPropModifier.Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct)
		{
		}

		void IPropModifier.Reset(WorldMaster master, Transform srcT)
		{
		}

		private void Update()
		{
		}

		private void OnValidate()
		{
		}
	}
}
