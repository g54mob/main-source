using UnityEngine;

namespace Battle
{
	public class TrackingEffect : BaseBattleEffect
	{
		public bool finishKill;

		private Transform _trackTarget;

		private bool _isTracking;

		public bool IsTracking
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TrackingEffect PlayEffect(Transform trackTarget, bool newCreate = true)
		{
			return null;
		}

		public TrackingEffect CreateEffect()
		{
			return null;
		}

		protected override void Update()
		{
		}
	}
}
