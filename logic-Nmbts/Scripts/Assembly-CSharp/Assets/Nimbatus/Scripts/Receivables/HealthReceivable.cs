using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	public class HealthReceivable : BaseReceivable
	{
		public int Amount;

		public override EReceivableType Type()
		{
			return EReceivableType.Health;
		}

		public override T GetReward<T>()
		{
			return (T)(object)null;
		}

		public override Texture2D GetIcon()
		{
			return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.HealthIcon;
		}

		public override string GetTitle()
		{
			return LocalizationManager.GetTranslation("CampaignMode/Hull");
		}

		public override string GetAmount()
		{
			return Amount.ToString();
		}

		public override void HandleReward()
		{
			SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeHealth(Amount);
		}

		public override bool IsPositive()
		{
			return Amount > 0;
		}

		public override string GetToolTip()
		{
			string translation = LocalizationManager.GetTermTranslation("CampaignMode/HullRewardDescription");
			LocalizationManager.ApplyLocalizationParams(ref translation, "x", GetAmount());
			return translation;
		}
	}
}
