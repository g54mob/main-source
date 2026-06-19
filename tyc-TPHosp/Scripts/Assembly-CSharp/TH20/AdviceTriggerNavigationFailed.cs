using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerNavigationFailed : AdviceTrigger
	{
		private bool _failureDetected;

		private string _characterName;

		[DontSave]
		private GameObject _interestPoint;

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnInteractionNavFailure = (Action<Character, RoomItem>)Delegate.Combine(characterEvents.OnInteractionNavFailure, new Action<Character, RoomItem>(OnInteractionNavFailure));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnInteractionNavFailure = (Action<Character, RoomItem>)Delegate.Remove(characterEvents.OnInteractionNavFailure, new Action<Character, RoomItem>(OnInteractionNavFailure));
		}

		private void OnInteractionNavFailure(Character character, RoomItem roomItem)
		{
			if (!_failureDetected && character.RoomUsing != null)
			{
				_failureDetected = true;
				Staff staff = character as Staff;
				_characterName = ((staff != null) ? GameStringUtils.StaffTitle(staff) : character.Name);
				_interestPoint = character.GetCameraTrackObject();
			}
		}

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_failureDetected)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			return Advisor.PriorityLevel.VeryHigh;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.CameraTrackObject = _interestPoint;
			result.Message = MessageLocalised.Translation.Replace("{[NAME]}", _characterName);
			_failureDetected = false;
			return result;
		}
	}
}
