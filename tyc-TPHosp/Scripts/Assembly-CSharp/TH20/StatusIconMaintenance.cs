using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconMaintenance : StatusIcon
	{
		[SerializeField]
		private GameObject _statusIcon;

		[SerializeField]
		private GameObject _highPriorityIcon;

		[SerializeField]
		private Image _statusImage;

		private RoomItem _item;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_item = emitter as RoomItem;
			bool isActive = _item != null && _item.Definition.ShowStatusIcon && base.IconType != Type.MaintenanceWarning;
			_statusImage.overrideSprite = null;
			if (_item != null && (bool)_item.Definition.MaintenanceIconOverride)
			{
				_statusImage.overrideSprite = _item.Definition.MaintenanceIconOverride;
			}
			GameObjectUtils.SetActive(_statusIcon, isActive);
			Update();
		}

		private void Update()
		{
			bool isActive = (((_item != null) ? _item.GetComponent<RoomItemMaintenanceComponent>() : null)?.Job)?.HighPriority ?? false;
			GameObjectUtils.SetActive(_highPriorityIcon, isActive);
		}
	}
}
