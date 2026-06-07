using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	public class ThreatReceivable : BaseReceivable
	{
		public float Amount;

		public override EReceivableType Type()
		{
			return EReceivableType.Threat;
		}

		public override T GetReward<T>()
		{
			return (T)(object)null;
		}

		public override Texture2D GetIcon()
		{
			return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ThreatIcon;
		}

		public override string GetTitle()
		{
			return LocalizationManager.GetTranslation("CampaignMode/Threat");
		}

		public override string GetAmount()
		{
			return ((Amount > 0f) ? (LabelHelper.DarkOrange + "+") : LabelHelper.Green) + Amount.ToString("F2", CultureInfo.InvariantCulture);
		}

		public override void HandleReward()
		{
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.IncreaseThreatByAmount(Amount);
		}

		public override bool IsPositive()
		{
			return Amount < 0f;
		}
	}
}
