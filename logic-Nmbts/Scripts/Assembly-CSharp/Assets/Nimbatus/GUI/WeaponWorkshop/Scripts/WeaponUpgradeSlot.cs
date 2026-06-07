using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class WeaponUpgradeSlot : SerializedMonoBehaviour
	{
		public UITexture Icon;

		public UITexture Background;

		public GameObject InCompatible;

		public GameObject Locked;

		public ResetUpgradeSlot ClearButton;

		public Color NormalColor;

		public Color SelectedColor;

		public Color HoverColor;

		public Color EmptyColor;

		private bool _hover;

		[HideInInspector]
		internal WeaponAttributeUpgrade CurrentUpgrade;

		[HideInInspector]
		internal static WeaponUpgradeSlot SelectedSlot;

		private bool _compatible;

		private WeaponPreset _selectedItem;

		private int _upgradeIndex;

		private WeaponPresetDetails _parent;

		public void Init(WeaponPresetDetails parent, WeaponPreset selectedItem, int i)
		{
			CurrentUpgrade = null;
			_selectedItem = selectedItem;
			_upgradeIndex = i;
			_parent = parent;
			ClearButton.Init(this);
			if (selectedItem.Upgrades.Count > i)
			{
				CurrentUpgrade = selectedItem.Upgrades[i];
			}
			_compatible = selectedItem.IsCompatible(CurrentUpgrade);
		}

		public bool IsCompatible(WeaponAttributeUpgrade upgrade)
		{
			return _selectedItem.IsCompatible(CurrentUpgrade);
		}

		public void SetUpgrade(WeaponAttributeUpgrade upgrade)
		{
			CurrentUpgrade = upgrade;
			_compatible = _selectedItem.IsCompatible(CurrentUpgrade);
			_selectedItem.SetUpgrade(_upgradeIndex, upgrade);
			_parent.UpdateWeaponPreview();
		}

		public void OnTooltip(bool show)
		{
			if (CurrentUpgrade != null)
			{
				string text = CurrentUpgrade.GetTooltip();
				if (!CurrentUpgrade.Unlocked)
				{
					text = text + LabelHelper.Orange + "\n" + LocalizationManager.GetTermTranslation("DroneWorkshop/ResearchToUnlock");
				}
				NimbatusToolTip.Show(text);
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		public void OnClick()
		{
			SelectedSlot = this;
		}

		public void Update()
		{
			if (SelectedSlot == this)
			{
				Background.color = SelectedColor;
			}
			else if (CurrentUpgrade == null)
			{
				Background.color = EmptyColor;
			}
			else
			{
				Background.color = NormalColor;
			}
			if (_hover)
			{
				Background.color = HoverColor;
			}
			if (CurrentUpgrade != null)
			{
				Icon.mainTexture = CurrentUpgrade.Icon;
				Icon.enabled = true;
			}
			else
			{
				Icon.enabled = false;
			}
			if (RuntimeGlobals.HasWeaponWorkshop && _compatible && CurrentUpgrade != null && !CurrentUpgrade.Unlocked)
			{
				Locked.SetActive(true);
			}
			else
			{
				Locked.SetActive(false);
			}
			if (CurrentUpgrade != null)
			{
				ClearButton.gameObject.SetActive(true);
			}
			else
			{
				ClearButton.gameObject.SetActive(false);
			}
			InCompatible.SetActive(!_compatible);
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
