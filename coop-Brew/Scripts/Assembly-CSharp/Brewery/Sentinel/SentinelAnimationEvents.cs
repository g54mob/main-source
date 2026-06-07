using UnityEngine;

namespace Brewery.Sentinel
{
	public class SentinelAnimationEvents : MonoBehaviour
	{
		[SerializeField]
		private SentinelArmedCombat combat;

		private void Awake()
		{
		}

		public void OnAttackStart()
		{
		}

		public void OnSwingSound()
		{
		}

		public void OnHit()
		{
		}

		public void OnAttackEnd()
		{
		}
	}
}
