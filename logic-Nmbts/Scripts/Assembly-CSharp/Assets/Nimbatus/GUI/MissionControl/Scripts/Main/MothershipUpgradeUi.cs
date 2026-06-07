using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class MothershipUpgradeUi : MonoBehaviour
	{
		public EMothershipUpgradeType Type;

		public UITexture Icon;

		public UILabel NameLabel;

		public UILabel LevelLabel;

		public bool ShowDescriptionAsTooltip;

		[HideIf("ShowDescriptionAsTooltip", true)]
		public UILabel DescLabel;

		[HideIf("ShowDescriptionAsTooltip", true)]
		public UILabel ValueLabel;

		public SegmentedUiBar SegmentedBar;

		public UIButton UpButton;

		public UIButton DownButton;

		private MothershipUpgrade _prefab;

		private bool _deactivated;

		private bool _upActive;

		private bool _downActive;

		private Color _nameLabelColor;

		private Color _levelLabelColor;

		private Color _valueLabelColor;

		public void Start()
		{
			_prefab = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(Type);
			Icon.mainTexture = _prefab.Icon;
			NameLabel.text = _prefab.Name.GetTranslation();
			_nameLabelColor = NameLabel.color;
			int num = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type) + ((Type != EMothershipUpgradeType.WarpDrive) ? 1 : 0);
			LevelLabel.text = LocalizationManager.GetTranslation("MothershipUpgrades/Level") + " " + num;
			_levelLabelColor = LevelLabel.color;
			if (!ShowDescriptionAsTooltip)
			{
				DescLabel.text = _prefab.Description.GetTranslation();
				ValueLabel.text = _prefab.GetValue(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type));
				_valueLabelColor = ValueLabel.color;
			}
			SegmentedBar.Init(_prefab.MaxLevel + ((Type != EMothershipUpgradeType.WarpDrive) ? 1 : 0), num);
		}

		public void Update()
		{
			if (!CheckDeactivate())
			{
				NameLabel.text = _prefab.Name.GetTranslation();
				int upgradeLevel = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type);
				int num = upgradeLevel + ((Type != EMothershipUpgradeType.WarpDrive) ? 1 : 0);
				LevelLabel.text = LocalizationManager.GetTranslation("MothershipUpgrades/Level") + " " + num;
				SegmentedBar.UpdateSegments(num);
				if (!ShowDescriptionAsTooltip)
				{
					DescLabel.text = _prefab.Description.GetTranslation();
					ValueLabel.text = _prefab.GetValue(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type));
					DescLabel.Update();
					ValueLabel.Update();
				}
				UpButton.gameObject.SetActive(RuntimeGlobals.GameModeSettings.FreeUpgrades);
				DownButton.gameObject.SetActive(RuntimeGlobals.GameModeSettings.FreeUpgrades);
				if (upgradeLevel >= _prefab.MaxLevel)
				{
					UpButton.SetState(UIButtonColor.State.Disabled, false);
					_upActive = false;
				}
				else if (!_upActive)
				{
					UpButton.SetState(UIButtonColor.State.Normal, false);
					_upActive = true;
				}
				if (upgradeLevel <= _prefab.MinLevel)
				{
					DownButton.SetState(UIButtonColor.State.Disabled, false);
					_downActive = false;
				}
				else if (!_downActive)
				{
					DownButton.SetState(UIButtonColor.State.Normal, false);
					_downActive = true;
				}
			}
		}

		private bool CheckDeactivate()
		{
			bool flag = !ReceivableHelper.UpgradeAllowed(Type);
			if (flag != _deactivated)
			{
				if (flag)
				{
					Color color = new Color(0.4470588f, 0.4666667f, 0.4666667f);
					NameLabel.color = color;
					if (!ShowDescriptionAsTooltip)
					{
						ValueLabel.color = color;
					}
					LevelLabel.color = color;
					SegmentedBar.UpdateSegments(0);
				}
				else
				{
					NameLabel.color = _nameLabelColor;
					LevelLabel.color = _levelLabelColor;
					if (!ShowDescriptionAsTooltip)
					{
						ValueLabel.color = _valueLabelColor;
					}
				}
				UpButton.gameObject.SetActive(!flag);
				DownButton.gameObject.SetActive(!flag);
				_deactivated = flag;
			}
			return flag;
		}

		public void OnTooltip(bool show)
		{
			if (ShowDescriptionAsTooltip)
			{
				string translation = _prefab.Description.GetTranslation();
				string value = _prefab.GetValue(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type), true);
				NimbatusToolTip.Show(show ? (translation + ((!string.IsNullOrEmpty(value)) ? (LabelHelper.NewLine + value) : "")) : null);
			}
		}

		public void LvlUp()
		{
			int upgradeLevel = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type);
			if (upgradeLevel < _prefab.MaxLevel)
			{
				upgradeLevel++;
				SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeUpgradeLevel(Type, upgradeLevel);
			}
		}

		public void LvlDown()
		{
			int upgradeLevel = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type);
			if (upgradeLevel > _prefab.MinLevel)
			{
				upgradeLevel--;
				SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeUpgradeLevel(Type, upgradeLevel);
			}
		}
	}
}
