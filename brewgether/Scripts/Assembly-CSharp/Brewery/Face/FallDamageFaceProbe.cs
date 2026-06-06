using Brewery.Player;
using UnityEngine;

namespace Brewery.Face
{
	public class FallDamageFaceProbe : FaceStateProbe
	{
		[SerializeField]
		private float winceDuration;

		[Tooltip("Minimum damage (HP) required to trigger a wince — filters tiny chip damage.")]
		[SerializeField]
		private float minDamageForWince;

		private PlayerHealthController _health;

		private float _winceUntil;

		public override string ProbeId => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void HandleDamaged(float oldHealth, float newHealth, float damage)
		{
		}

		public override float Evaluate01()
		{
			return 0f;
		}
	}
}
