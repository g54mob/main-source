using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifHunter : CTSBehaviour
	{
		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		[SerializeField]
		private NotificationData _workerKilledData;

		[SerializeField]
		private NotificationData _workerSurvivedData;

		[SerializeField]
		private NotificationData _customerKilledData;

		[SerializeField]
		private NotificationData _customerSurvivedData;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			AgentActionShootAgent.TargetSurvived += OnTargetSurvived;
			AgentActionShootAgent.TargetGotKilled += OnTargetKilled;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			AgentActionShootAgent.TargetSurvived -= OnTargetSurvived;
			AgentActionShootAgent.TargetGotKilled -= OnTargetKilled;
		}

		private void OnTargetSurvived(Agent obj)
		{
			NotificationData data = ((obj is Worker) ? _workerSurvivedData : _customerSurvivedData);
			if (!_notificationManager.HasNotification(data))
			{
				_notificationManager.ShowNotification(data);
			}
		}

		private void OnTargetKilled(Agent obj)
		{
			NotificationData data = ((obj is Worker) ? _workerKilledData : _customerKilledData);
			if (!_notificationManager.HasNotification(data))
			{
				_notificationManager.ShowNotification(data);
			}
		}
	}
}
