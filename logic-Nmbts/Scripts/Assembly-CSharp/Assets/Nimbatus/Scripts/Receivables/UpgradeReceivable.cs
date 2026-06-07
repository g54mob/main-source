using System;
using System.Globalization;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	public class UpgradeReceivable : BaseReceivable
	{
		public EMothershipUpgradeType UpgradeType;

		public int Level;

		public override EReceivableType Type()
		{
			return EReceivableType.Upgrade;
		}

		public override T GetReward<T>()
		{
			return (T)(object)null;
		}

		public override Texture2D GetIcon()
		{
			MothershipUpgrade upgradePrefab = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(UpgradeType);
			if (!(upgradePrefab != null))
			{
				return null;
			}
			return upgradePrefab.Icon;
		}

		public override string GetTitle()
		{
			MothershipUpgrade upgradePrefab = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(UpgradeType);
			if (!(upgradePrefab != null))
			{
				return "";
			}
			return upgradePrefab.Name.GetTranslation();
		}

		public override string GetAmount()
		{
			if (UpgradeType == EMothershipUpgradeType.WarpDrive)
			{
				return "";
			}
			return LocalizationManager.GetTranslation("MothershipUpgrades/Level") + " " + (Level + 1).ToString(CultureInfo.InvariantCulture);
		}

		public override void HandleReward()
		{
			int lvl = Mathf.Max(Level, SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(UpgradeType));
			SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeUpgradeLevel(UpgradeType, lvl);
		}

		public override bool IsPositive()
		{
			return true;
		}

		public string GetDescription()
		{
			MothershipUpgrade upgradePrefab = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(UpgradeType);
			if (!(upgradePrefab != null))
			{
				return "";
			}
			return upgradePrefab.Description.GetTranslation();
		}

		public string GetValue()
		{
			return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(UpgradeType).GetValue(Level);
		}

		public override string GetToolTip()
		{
			return GetDescription();
		}

		public override bool IsDuplicate(BaseReceivable receivable)
		{
			UpgradeReceivable upgradeReceivable;
			if ((upgradeReceivable = receivable as UpgradeReceivable) != null && Type() == upgradeReceivable.Type())
			{
				return UpgradeType == upgradeReceivable.UpgradeType;
			}
			return false;
		}
	}
}
