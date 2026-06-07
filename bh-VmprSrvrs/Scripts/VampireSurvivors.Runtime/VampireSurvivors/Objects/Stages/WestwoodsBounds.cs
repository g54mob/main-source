using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Objects.Stages
{
	public class WestwoodsBounds : MonoBehaviour
	{
		public enum WestwoodsZone
		{
			One = 0,
			Two = 1,
			Three = 2
		}

		[Tooltip("X coordinate for the right hand side of the stage that will always be the same")]
		[SerializeField]
		private float _staticBoundsLimit;

		[SerializeField]
		private float[] _boundsXLimits;

		[Space]
		[SerializeField]
		private float _inverseStaticBoundsLimit;

		[SerializeField]
		private float[] _inverseBoundsXLimits;

		private bool _isStageInverse;

		public float StaticBoundsLimit => 0f;

		public float[] BoundsXLimits => null;

		public void Initialise(bool isStageInverse)
		{
		}

		public void EnableBoundsForZone(WestwoodsZone zone)
		{
		}

		public bool IsPositionInsidePlayableSpace(float2 position, WestwoodsZone currentUnlockedZone)
		{
			return false;
		}
	}
}
