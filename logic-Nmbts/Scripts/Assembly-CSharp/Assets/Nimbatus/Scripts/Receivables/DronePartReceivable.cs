using System;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	public class DronePartReceivable : BaseReceivable
	{
		public string Reward;

		public int Amount;

		public override EReceivableType Type()
		{
			return EReceivableType.DronePart;
		}

		public override T GetReward<T>()
		{
			return (T)(object)GetActualPart();
		}

		public override Texture2D GetIcon()
		{
			return GetActualPart().GetIcon();
		}

		public override bool IsPositive()
		{
			return true;
		}

		public override string GetToolTip()
		{
			return GetActualPart().GetTooltip();
		}

		public override string GetTitle()
		{
			return GetActualPart().Name.GetTranslation();
		}

		public override string GetAmount()
		{
			return Amount.ToString();
		}

		public override void HandleReward()
		{
			DronePart actualPart = GetActualPart();
			actualPart.Unlocked = true;
			if (actualPart.IsStackable)
			{
				actualPart.ChangeStackSize(Amount);
			}
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Save();
		}

		private DronePart GetActualPart()
		{
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<DronePart>(Reward);
		}
	}
}
