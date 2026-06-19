using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerItemExploded : AdvisorTrigger
	{
		[SerializeField]
		private bool _messageSet;

		[SerializeField]
		private string _text;

		private Vector3 _interestPoint;

		public AdvisorTriggerItemExploded(AdvisorTriggerItemExplodedDefinition definition)
			: base(definition)
		{
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
		}

		public override void OnUnregister()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
		}

		private void OnRoomItemExploded(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			if (!_messageSet)
			{
				_messageSet = true;
				_interestPoint = roomItem.WorldPosition;
				_text = (flammableComponent.AdvisorExplodedMessage.IsNull() ? ScriptLocalization.Items.OnExploded_CS : flammableComponent.AdvisorExplodedMessage.Translation);
				_text = _text.Replace("{[ITEM]}", roomItem.LocalisedName);
			}
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (_messageSet)
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _text;
			result.CameraFocus = _interestPoint;
			_messageSet = false;
			return result;
		}
	}
}
