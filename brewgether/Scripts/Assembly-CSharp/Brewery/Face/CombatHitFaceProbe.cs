using Brewery.Player;
using UnityEngine;

namespace Brewery.Face
{
	public class CombatHitFaceProbe : FaceStateProbe
	{
		[SerializeField]
		private float flinchDuration;

		[SerializeField]
		private float minDamageToFlinch;

		private PlayerHealthController _health;

		private float _flinchUntil;

		private float _lastHp;

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
