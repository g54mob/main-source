using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	public class MultiPartReceivable : BaseReceivable
	{
		public EMultiPartType MultiPartType;

		public List<string> DroneParts;

		public int Amount;

		public TranslationTerm Title;

		public override EReceivableType Type()
		{
			return EReceivableType.DronePart;
		}

		public override T GetReward<T>()
		{
			return (T)(object)DroneParts.Select(GetActualPart).ToList();
		}

		public override Texture2D GetIcon()
		{
			if (SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.MultiPartIcons.ContainsKey(MultiPartType))
			{
				return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.MultiPartIcons[MultiPartType];
			}
			return GetActualPart(DroneParts.RandomItem()).GetIcon();
		}

		public override string GetTitle()
		{
			return Title.GetTranslation();
		}

		public override string GetAmount()
		{
			return Amount.ToString();
		}

		public override void HandleReward()
		{
			foreach (string dronePart in DroneParts)
			{
				DronePart actualPart = GetActualPart(dronePart);
				actualPart.Unlocked = true;
				actualPart.ChangeStackSize(Amount);
			}
		}

		private DronePart GetActualPart(string id)
		{
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<DronePart>(id);
		}

		public override bool IsPositive()
		{
			return true;
		}
	}
}
