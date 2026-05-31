using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T1Warehouse : WorldFrame
	{
		private int _addedStorageTier;

		private int _addedInventorySpace;

		public override int AutoWorkerCount => 0;

		public override TechNode RequiredTech => "t1f_warehouse";

		public int StorageTier { get; private set; }

		public T1Warehouse()
		{
			base.IconName = "Items_31";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			_baseCost = new List<ItemType> { "widget", "spinning_widget" };
			_extraCostMultiplier = 1.6f;
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			throw new NotImplementedException();
		}

		public override void OnAddFrame()
		{
			_refreshStorage();
		}

		public override void OnConstructionCompleted()
		{
			_refreshStorage();
		}

		public override void OnUpgradeConstructionCompleted(FrameUpgrade key)
		{
			base.OnUpgradeConstructionCompleted(key);
			_refreshStorage();
		}

		public override void OnDeconstructionCompleted()
		{
			_removeAddedStorage();
		}

		public override void CopyFrom(WorldFrame frame)
		{
			if (frame is T1Warehouse t1Warehouse)
			{
				StorageTier = t1Warehouse.StorageTier;
				_refreshStorage();
			}
		}

		public override void AddCustomTooltipLines(UITooltip tooltip)
		{
			tooltip.AddTextLine("+" + GetStorageAmount() + " storage for " + ((StorageTier == 0) ? "ALL" : ("Tier " + StorageTier)) + " items.");
		}

		public void SetStorageTier(int tier)
		{
			StorageTier = tier;
			_refreshStorage();
		}

		public int GetStorageAmount()
		{
			return Mathf.RoundToInt((float)((StorageTier == 0) ? 10 : 100) * GetUpgradeMultiplier(FrameUpgradeType.Custom, 1));
		}

		private void _refreshStorage()
		{
			if (_addedInventorySpace > 0)
			{
				_removeAddedStorage();
			}
			if (base.Construction == null)
			{
				_addedStorageTier = StorageTier;
				_addedInventorySpace = GetStorageAmount();
				GamePlayer.Current.AddInventorySpace(_addedStorageTier, _addedInventorySpace);
			}
		}

		private void _removeAddedStorage()
		{
			GamePlayer.Current.AddInventorySpace(_addedStorageTier, -_addedInventorySpace);
			_addedStorageTier = 0;
			_addedInventorySpace = 0;
		}

		protected override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			StorageTier = val["StorageTier"];
		}

		public override JsonValue ToJson()
		{
			JsonValue result = base.ToJson();
			result["StorageTier"] = StorageTier;
			return result;
		}
	}
}
