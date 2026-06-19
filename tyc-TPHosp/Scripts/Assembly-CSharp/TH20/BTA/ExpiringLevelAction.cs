using UnityEngine;

namespace TH20.BTA
{
	[DontSave]
	public abstract class ExpiringLevelAction : LevelAction
	{
		[SerializeField]
		private bool _expiresOnComplete = true;

		protected bool HasTaskExpired()
		{
			return base.Owner.HasTaskExpired(this);
		}

		public override void OnEnd()
		{
			if (_expiresOnComplete)
			{
				base.Owner.LogExpiredTask(this);
			}
			base.OnEnd();
		}
	}
}
