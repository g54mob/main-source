using System;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnDeath : NimbatusEvent
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		protected override void Subscribe()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
			if (HealthPool != null)
			{
				HealthPool.HasDied += _healthPool_HasDied;
			}
		}

		protected override void Unsubscribe()
		{
			if (HealthPool != null)
			{
				HealthPool.HasDied -= _healthPool_HasDied;
			}
		}

		private void _healthPool_HasDied(object sender, EventArgs e)
		{
			RaiseEvent();
		}
	}
}
