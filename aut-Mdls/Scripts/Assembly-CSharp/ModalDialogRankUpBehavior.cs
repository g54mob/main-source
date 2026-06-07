using Data.Notifications;
using Events.UI.Notifications;
using UnityEngine;

[CreateAssetMenu(fileName = "ModalDialogRankUpBehavior", menuName = "Rank System/Behaviors/ModalDialogRankUpBehavior")]
public class ModalDialogRankUpBehavior : AbstractRankUpBehavior
{
	[SerializeField]
	private NotificationEvent _notificationEvent;

	[SerializeField]
	private RankConfigSO _rankConfigSO;

	public override void Execute()
	{
		_notificationEvent.Fire(new RankNotificationData(_rankConfigSO.GetCurrentRankConfig()));
	}
}
