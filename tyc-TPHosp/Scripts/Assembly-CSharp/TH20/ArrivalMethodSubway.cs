using System;
using UnityEngine;

namespace TH20
{
	public class ArrivalMethodSubway : ArrivalMethod, IAnimationEndEvent
	{
		private readonly ArrivalMethodSubwayDefinition _definition;

		private readonly Character _character;

		private bool _arrived;

		public ArrivalMethodSubway(ArrivalMethodSubwayDefinition definition, Level level, IArrivedCallback arrivedCallback)
			: base(level, arrivedCallback)
		{
			_definition = definition;
			Transform transform = ArrivalSubwayComponent.RandomPoint().GetTransform();
			_character = _arrivedCallback.OnArrived(transform.position);
			_character.Position = transform.position;
			_character.Rotation = transform.rotation;
			_character.NavPath.PutBackInNavWorld();
			_character.NavPath.Warp(transform.position);
			_character.NavPath.BecomeKinematic();
			_character.Interrupt();
			_character.PushAnimationGraph(_definition.CharacterAnimGraph, 0f, this);
		}

		public override bool Update()
		{
			return _arrived;
		}

		public void OnAnimationEndEvent()
		{
			_character.PopAnimationGraph(_definition.CharacterAnimGraph, 0.25f);
			_character.NavPath.StopBeingKinematic();
			_character.Resume();
			_arrived = true;
		}

		public override void RestoreFromSave()
		{
			Character character = _character;
			character.PostRestoreFromSaveCallback = (Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (Action)delegate
			{
				_character.FixupAnimationEndEvent(this, _definition.CharacterAnimGraph);
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
