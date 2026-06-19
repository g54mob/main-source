using System;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomNavigationFailure : AdvisorTrigger
	{
		private AdvisorTriggerRoomNavigationFailureDefinition _definition;

		private bool _failureDetected;

		private string _characterName;

		private string _destinationName;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerRoomNavigationFailure(AdvisorTriggerRoomNavigationFailureDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterNavFailure = (Action<Character, Vector3>)Delegate.Combine(characterEvents.OnCharacterNavFailure, new Action<Character, Vector3>(OnCharacterNavFailure));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnInteractionNavFailure = (Action<Character, RoomItem>)Delegate.Combine(characterEvents2.OnInteractionNavFailure, new Action<Character, RoomItem>(OnInteractionNavFailure));
		}

		public override void OnUnregister()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterNavFailure = (Action<Character, Vector3>)Delegate.Remove(characterEvents.OnCharacterNavFailure, new Action<Character, Vector3>(OnCharacterNavFailure));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnInteractionNavFailure = (Action<Character, RoomItem>)Delegate.Remove(characterEvents2.OnInteractionNavFailure, new Action<Character, RoomItem>(OnInteractionNavFailure));
		}

		private void OnCharacterNavFailure(Character character, Vector3 destination)
		{
			EntityNavFailedComponent component = character.GetComponent<EntityNavFailedComponent>();
			if (component != null && component.Failed)
			{
				_failureDetected = true;
				SetCharacterName(character);
				_destinationName = string.Empty;
			}
		}

		private void OnInteractionNavFailure(Character character, RoomItem roomItem)
		{
			EntityNavFailedComponent component = character.GetComponent<EntityNavFailedComponent>();
			if (component != null && component.Failed)
			{
				_failureDetected = true;
				SetCharacterName(character);
				_destinationName = roomItem.LocalisedName;
			}
		}

		private void SetCharacterName(Character character)
		{
			Staff staff = character as Staff;
			_characterName = ((staff != null) ? GameStringUtils.StaffTitle(staff) : character.Name);
			_interestPoint = character.GetCameraTrackObject();
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
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
			if (_destinationName.IsNullOrEmpty())
			{
				result.Message = _definition.MessageLocalised.Translation.Replace("{[NAME]}", _characterName);
			}
			else
			{
				result.Message = LocalisedString.Replace(_definition.DestinationInvalidText.Translation, new SubPair[2]
				{
					new SubPair("{[NAME]}", _characterName),
					new SubPair("{[DEST]}", _destinationName)
				});
			}
			_failureDetected = false;
			return result;
		}
	}
}
