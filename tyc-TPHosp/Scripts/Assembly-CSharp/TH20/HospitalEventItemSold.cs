using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventItemSold : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			}

			private void OnRoomItemSold(RoomItem roomItem)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventItemSold
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_itemDefinition = roomItem.Definition,
					_upgradeLevel = roomItem.UpgradeLevel,
					_cost = roomItem.SellValue()
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
			return ScriptLocalization.HospitalEvent.ItemSold_CS.Replace("{[ITEM]}", _itemDefinition.GetLocalisedName(_upgradeLevel));
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
