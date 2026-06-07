using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using I2.Loc;
using NGenerics.Extensions;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class UnlockTech : SerializedMonoBehaviour
	{
		private WeaponAttributeUpgrade _selectedUpgrade;

		private EUnlockMode _unlockMode;

		private bool _hasResources;

		private bool _parentUnlocked;

		private UILabel _label;

		private UIButton[] _buttons;

		public void Init(UpgradeNode upgrade, EUnlockMode mode)
		{
			_selectedUpgrade = upgrade.Upgrade;
			_unlockMode = mode;
			_hasResources = _selectedUpgrade.HasResourcesToBuy();
			_parentUnlocked = upgrade.ParentNodes.Any((UpgradeNode p) => p.Upgrade.Unlocked);
			switch (_unlockMode)
			{
			case EUnlockMode.Normal:
				_label.text = LocalizationManager.GetTranslation("DroneWorkshop/ResearchSomething");
				break;
			case EUnlockMode.FreeUnlock:
				_label.text = LocalizationManager.GetTranslation("DroneWorkshop/UnlockSomething");
				break;
			case EUnlockMode.FreeLock:
				_label.text = LocalizationManager.GetTranslation("DroneWorkshop/LockSomething");
				break;
			}
		}

		public void Start()
		{
			_label = GetComponentInChildren<UILabel>();
			_buttons = GetComponents<UIButton>();
		}

		public void OnClick()
		{
			switch (_unlockMode)
			{
			case EUnlockMode.Normal:
				if (_parentUnlocked && _hasResources)
				{
					_selectedUpgrade.Buy();
				}
				break;
			case EUnlockMode.FreeUnlock:
				_selectedUpgrade.ChangeLockStatus(true);
				break;
			case EUnlockMode.FreeLock:
				_selectedUpgrade.ChangeLockStatus(false);
				break;
			}
		}

		public void Update()
		{
			if ((_parentUnlocked && _hasResources) || _unlockMode != EUnlockMode.Normal)
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Normal, true);
				});
			}
			else
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnTooltip(bool show)
		{
			if (show && _unlockMode == EUnlockMode.Normal)
			{
				if (!_parentUnlocked)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTranslation("DroneWorkshop/ParentTechNotResearched"));
				}
				else if (!_hasResources)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTranslation("DroneWorkshop/NotEnoughResources"));
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
