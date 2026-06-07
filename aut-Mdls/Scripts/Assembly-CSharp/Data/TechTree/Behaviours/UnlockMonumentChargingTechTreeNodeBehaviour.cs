using Data.Notifications;
using Data.Variables;
using Events.UI.Notifications;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Unlock Monument Charging", fileName = "UnlockMonumentCharging")]
	public class UnlockMonumentChargingTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private ZenModeVariableSO _isCreativeModeSO;

		[SerializeField]
		private BoolVariableSO _monumentCanBeChargedBoolSO;

		[SerializeField]
		private NotificationEvent _notificationEvent;

		[SerializeField]
		private Sprite _chargeNotificationSprite;

		[SerializeField]
		[LocaKey]
		private string _chargeAvailableLocaKey;

		public override void Unlock()
		{
			if (!_isCreativeModeSO.Value && _notificationEvent != null && !_monumentCanBeChargedBoolSO.Value)
			{
				_notificationEvent.Fire(new GenericNotificationData(_chargeNotificationSprite, _chargeAvailableLocaKey));
			}
			_monumentCanBeChargedBoolSO.SetValue(value: true);
		}

		public override void RefunableReUnlock()
		{
			_monumentCanBeChargedBoolSO.SetValue(value: true);
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _monumentCanBeChargedBoolSO;
			return false;
		}
	}
}
