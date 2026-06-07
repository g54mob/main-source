using System;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	public class TechnologyReceivable : BaseReceivable
	{
		public string UniqueId;

		public override EReceivableType Type()
		{
			return EReceivableType.Technology;
		}

		public override T GetReward<T>()
		{
			return (T)(object)GetActualUpgrade();
		}

		public override Texture2D GetIcon()
		{
			return GetActualUpgrade().GetIcon();
		}

		public override string GetToolTip()
		{
			return GetActualUpgrade().GetTooltip();
		}

		public override string GetTitle()
		{
			return GetActualUpgrade().Name.GetTranslation();
		}

		public override string GetAmount()
		{
			return "";
		}

		public override void HandleReward()
		{
			GetActualUpgrade().Unlocked = true;
		}

		private WeaponAttributeUpgrade GetActualUpgrade()
		{
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<WeaponAttributeUpgrade>(UniqueId);
		}

		public override bool IsPositive()
		{
			return true;
		}
	}
}
