using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerItemOnFire : AdvisorTrigger
	{
		[SerializeField]
		private string _text;

		[DontSave]
		private RoomItem _roomItem;

		public AdvisorTriggerItemOnFire(AdvisorTriggerItemOnFireDefinition definition)
			: base(definition)
		{
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomItemExtinguished = (Action<RoomItem>)Delegate.Combine(buildEvents2.OnRoomItemExtinguished, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents3 = Level.BuildEvents;
			buildEvents3.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents3.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
		}

		public override void OnUnregister()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomItemExtinguished = (Action<RoomItem>)Delegate.Remove(buildEvents2.OnRoomItemExtinguished, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents3 = Level.BuildEvents;
			buildEvents3.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents3.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
		}

		private void OnRoomItemOnFire(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			if (_roomItem == null)
			{
				_roomItem = roomItem;
				_text = (flammableComponent.AdvisorOnFireMessage.IsNull() ? ScriptLocalization.Items.OnFire_CS : flammableComponent.AdvisorOnFireMessage.Translation);
				_text = _text.Replace("{[ITEM]}", roomItem.LocalisedName);
			}
		}

		private void OnRoomItemDestroyed(RoomItem roomItem)
		{
			if (roomItem == _roomItem)
			{
				_roomItem = null;
			}
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (_roomItem != null)
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _text;
			result.CameraFocus = _roomItem.WorldPosition;
			_roomItem = null;
			return result;
		}
	}
}
