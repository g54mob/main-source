using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class HealthRewardItem : MonoBehaviour
	{
		public UILabel HealthLabel;

		public UISprite TopHealthBar;

		public UISprite BottomHealthBar;

		public Color PositiveColor;

		public Color NegativeColor;

		public Color NormalColor;

		public void Init(HealthReceivable receivable)
		{
			if (receivable.Amount <= 0)
			{
				TopHealthBar.color = NormalColor;
				TopHealthBar.fillAmount = (float)(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth + receivable.Amount) / (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
				BottomHealthBar.color = NegativeColor;
				BottomHealthBar.fillAmount = (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth / (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			}
			else
			{
				TopHealthBar.color = NormalColor;
				TopHealthBar.fillAmount = (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth / (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
				BottomHealthBar.color = PositiveColor;
				BottomHealthBar.fillAmount = (float)(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth + receivable.Amount) / (float)SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			}
			HealthLabel.text = GetFormattedPercentValue(receivable.Amount) + LabelHelper.White + LocalizationManager.GetTermTranslation("CampaignMode/Hull");
		}

		protected string GetFormattedPercentValue(int value)
		{
			if (value == 0)
			{
				return LabelHelper.White ?? "";
			}
			if (value > 0)
			{
				return LabelHelper.Green + "+ " + value + "%";
			}
			return LabelHelper.Red + "- " + Math.Abs(value) + "%";
		}
	}
}
