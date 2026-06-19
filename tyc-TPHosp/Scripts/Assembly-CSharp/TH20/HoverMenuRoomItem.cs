using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuRoomItem : HoverMenuRoomItemBase
	{
		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private GameObject _mainSection;

		[SerializeField]
		private ProgressBarMaskable _maintenanceBar;

		[SerializeField]
		private GameObject _maintenanceSection;

		[SerializeField]
		private ProgressBarMaskable _upgradeBar;

		[SerializeField]
		private GameObject _upgradeSection;

		[SerializeField]
		private TMP_Text _stateText;

		[SerializeField]
		private Image _maintenanceIcon;

		[SerializeField]
		private GameObject _maintenanceRegenAnim;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			if (_maintenanceIcon != null && roomItem != null && roomItem.Definition.MaintenanceIconOverride != null)
			{
				_maintenanceIcon.overrideSprite = roomItem.Definition.MaintenanceIconOverride;
				if (roomItem.Definition.IgnoredByJanitors)
				{
					GameObjectUtils.SetActive(_maintenanceRegenAnim, isActive: true);
				}
			}
		}

		protected override void Update()
		{
			base.Update();
			if (!_roomItem.Definition.HasTooltip)
			{
				GameObjectUtils.SetActive(_mainSection, isActive: false);
			}
			else
			{
				_name.text = _roomItem.LocalisedName;
				if (_maintenanceSection != null)
				{
					if (_roomItem.MaintenanceLevel == null)
					{
						GameObjectUtils.SetActive(_maintenanceSection, isActive: false);
					}
					else
					{
						GameObjectUtils.SetActive(_maintenanceSection, isActive: true);
						_maintenanceBar.Progress = 1f - _roomItem.MaintenanceLevel.Value() / 100f;
					}
				}
				string text = string.Empty;
				QualificationDefinition upgradeQualification = _roomItem.UpgradeQualification;
				if (!_roomItem.IsFunctional() && !_roomItem.Definition.IgnoredByJanitors)
				{
					text = ((_roomItem.GetComponent<RoomItemUpgradeComponent>() == null || upgradeQualification == null) ? GameStringUtils.GetRoomItemJanitorText(_roomItem, null, out var staff) : GameStringUtils.GetRoomItemJanitorText(_roomItem, upgradeQualification, out staff));
				}
				if (_upgradeSection != null)
				{
					RoomItemUpgradeComponent component = _roomItem.GetComponent<RoomItemUpgradeComponent>();
					if (component != null)
					{
						_upgradeBar.Progress = component.Progress;
						if (upgradeQualification != null && !GameAlgorithms.AnyStaffCompletedQualification(base.Level, upgradeQualification))
						{
							text = ScriptLocalization.Menu.Hover_RoomItem_JanitorQualificationRequired_CS.Replace("{[QUALIFICATION]}", upgradeQualification.NameLocalised.Translation);
						}
						GameObjectUtils.SetActive(_upgradeSection, isActive: true);
					}
					else
					{
						GameObjectUtils.SetActive(_upgradeSection, isActive: false);
					}
				}
				if (_stateText != null)
				{
					_stateText.text = text;
					GameObjectUtils.SetActive(_stateText.gameObject, !string.IsNullOrEmpty(text));
				}
			}
			if (_roomItem.Definition.ShowQueuePositions)
			{
				foreach (ObjectInteraction interaction in _roomItem.Interactions)
				{
					if (interaction.Interactor != null && !(interaction.Interactor is Staff { CurrentMode: Staff.Mode.Work }))
					{
						base.Level.StatusIconManager.ShowStatusIcon(interaction.Interactor, StatusIcon.Type.InteractionQueuePosition);
					}
					foreach (Character item in interaction.Queue)
					{
						if (!(item is Staff { CurrentMode: Staff.Mode.Work }))
						{
							base.Level.StatusIconManager.ShowStatusIcon(item, StatusIcon.Type.InteractionQueuePosition);
						}
					}
				}
				return;
			}
			if (_roomItem.OwningRoom != null)
			{
				_roomItem.OwningRoom.ShowQueuePositions();
			}
		}
	}
}
