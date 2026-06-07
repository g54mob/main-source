using Brewery.Player;
using UnityEngine;

namespace Brewery.Face
{
	public class HealthFaceProbe : FaceStateProbe
	{
		[Tooltip("HP percentage at or below which the hurt face is at full intensity.")]
		[SerializeField]
		private float fullIntensityAt;

		[Tooltip("HP percentage above which the hurt face is fully off.")]
		[SerializeField]
		private float zeroIntensityAt;

		private PlayerHealthController _health;

		public override string ProbeId => null;

		private void Awake()
		{
		}

		public override float Evaluate01()
		{
			return 0f;
		}
	}
}
