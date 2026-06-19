using System;
using UnityEngine;

namespace TH20
{
	public class ArrivalMethodAmbulanceEmergency : ArrivalMethod, IAnimationEndEvent
	{
		private readonly ArrivalMethodAmbulanceEmergencyDefinition _definition;

		private readonly Character _character;

		private readonly RuntimeAnimatorController _characterAnimGraph;

		private bool _arrived;

		public ArrivalMethodAmbulanceEmergency(ArrivalMethodAmbulanceEmergencyDefinition definition, Level level, IArrivedCallback arrivedCallback)
			: base(level, arrivedCallback)
		{
			_definition = definition;
		}

		public override bool Update()
		{
			return _arrived;
		}

		public void OnAnimationEndEvent()
		{
			_character.PopAnimationGraph(_characterAnimGraph, 0.25f);
			_character.NavPath.StopBeingKinematic();
			_character.Resume();
			_arrived = true;
		}

		public override void RestoreFromSave()
		{
			Character character = _character;
			character.PostRestoreFromSaveCallback = (Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (Action)delegate
			{
				_character.FixupAnimationEndEvent(this, _characterAnimGraph);
			});
		}

		public override bool IsValid()
		{
			return true;
		}

		public override bool IsArriving(Character character)
		{
			return _character == character;
		}
	}
}
