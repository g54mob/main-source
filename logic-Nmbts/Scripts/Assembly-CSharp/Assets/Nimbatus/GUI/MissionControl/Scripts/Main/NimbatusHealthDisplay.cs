using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class NimbatusHealthDisplay : MonoBehaviour
	{
		public UILabel HealthLabel;

		public SegmentedUiBar SegmentedBar;

		private int _maxHealth;

		public void Start()
		{
			_maxHealth = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			SegmentedBar.Init(_maxHealth, SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth);
			HealthLabel.text = LocalizationManager.GetTermTranslation("CampaignMode/Hull") + ": " + LabelHelper.Orange + SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth;
		}

		public void Update()
		{
			if (SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth != _maxHealth)
			{
				_maxHealth = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
				SegmentedBar.Init(_maxHealth, SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth);
			}
			SegmentedBar.UpdateSegments(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth);
			HealthLabel.text = LocalizationManager.GetTermTranslation("CampaignMode/Hull") + ": " + LabelHelper.Orange + SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth;
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("CampaignMode/HullTooltip"));
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
