using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventItemBought : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
			}

			private void OnRoomItemPurchased(RoomItem roomItem)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventItemBought
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_itemDefinition = roomItem.Definition,
					_upgradeLevel = roomItem.UpgradeLevel,
					_cost = -roomItem.Cost
				});
			}
		}

		private IRoomItemDefinition _itemDefinition;

		private int _upgradeLevel;

		private int _cost;

		public override Sprite GetEventIcon()
		{
			return _itemDefinition.GetIcon(_upgradeLevel);
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.ItemBought_CS.Replace("{[ITEM]}", _itemDefinition.GetLocalisedName(_upgradeLevel));
		}

		public int GetFinanceValue()
		{
			return _cost;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}
	}
}
