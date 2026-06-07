using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;

namespace Assets.Nimbatus.Scripts.Receivables
{
	public static class ReceivableHelper
	{
		public static bool IsAllowed(BaseReceivable receivable)
		{
			if (TypeAllowed(receivable))
			{
				if (receivable.Type() == EReceivableType.Health && receivable.IsPositive())
				{
					return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth < SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
				}
				if (receivable.Type() == EReceivableType.DronePart && !(receivable is MultiPartReceivable))
				{
					return DronePartAllowed(receivable.GetReward<DronePart>());
				}
				if (receivable.Type() == EReceivableType.Upgrade)
				{
					EMothershipUpgradeType upgradeType = ((UpgradeReceivable)receivable).UpgradeType;
					if (UpgradeAllowed(upgradeType))
					{
						return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(upgradeType) < SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(upgradeType).MaxLevel;
					}
					return false;
				}
				if (receivable.Type() == EReceivableType.Effect)
				{
					DroneEffect effect = ((EffectReceivable)receivable).Effect;
					if (effect == null)
					{
						return false;
					}
					return effect.IsAllowed();
				}
				return true;
			}
			return false;
		}

		private static bool TypeAllowed(BaseReceivable receivable)
		{
			List<EReceivableType> list = new List<EReceivableType> { EReceivableType.Ore };
			if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
			{
				list.Add(EReceivableType.Health);
				list.Add(EReceivableType.Threat);
			}
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				list.Add(EReceivableType.Upgrade);
				list.Add(EReceivableType.Effect);
			}
			else if (!RuntimeGlobals.GameModeSettings.FreeUpgrades)
			{
				list.Add(EReceivableType.Upgrade);
			}
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				list.Add(EReceivableType.DronePart);
			}
			if (RuntimeGlobals.HasWeaponWorkshop)
			{
				list.Add(EReceivableType.Technology);
			}
			return list.Contains(receivable.Type());
		}

		private static bool DronePartAllowed(DronePart part)
		{
			List<EDronePartType> list = new List<EDronePartType>();
			for (int i = 0; i < EnumHelper.GetValues<EDronePartType>().Count() + 1; i++)
			{
				list.Add((EDronePartType)i);
			}
			List<DroneEffect> activeEffects = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects;
			if (activeEffects != null && activeEffects.Any((DroneEffect e) => e is SuperchargedBatteries))
			{
				list.Remove(EDronePartType.FuelTank);
			}
			return list.Contains(part.DronePartType);
		}

		public static bool UpgradeAllowed(EMothershipUpgradeType upgrade)
		{
			bool flag = false;
			switch (upgrade)
			{
			case EMothershipUpgradeType.DroneHangar:
				if (!RuntimeGlobals.GameModeSettings.DeployCost)
				{
					flag = true;
				}
				break;
			case EMothershipUpgradeType.DroneFabrication:
				if (!RuntimeGlobals.GameModeSettings.DeployCost)
				{
					flag = true;
				}
				break;
			case EMothershipUpgradeType.Drive:
				if (!RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
				{
					flag = true;
				}
				break;
			case EMothershipUpgradeType.WarpDrive:
				if (RuntimeGlobals.GameMode == EGameMode.Creative)
				{
					flag = true;
				}
				break;
			case EMothershipUpgradeType.Sensors:
				if (RuntimeGlobals.GameMode == EGameMode.Campaign && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects != null && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.OfType<NoInputAllowed>().Any())
				{
					flag = true;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("upgrade", upgrade, null);
			case EMothershipUpgradeType.Bridge:
				break;
			}
			return !flag;
		}
	}
}
