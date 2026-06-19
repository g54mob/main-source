using System;
using UnityEngine;

namespace TH20
{
	public class ArrivalMethodTimePortal : ArrivalMethod, IAnimationEndEvent
	{
		private readonly ArrivalMethodTimePortalDefinition _definition;

		private readonly Character _character;

		private readonly RuntimeAnimatorController _characterAnimGraph;

		private bool _arrived;

		public ArrivalMethodTimePortal(ArrivalMethodTimePortalDefinition definition, Level level, IArrivedCallback arrivedCallback)
			: base(level, arrivedCallback)
		{
			_definition = definition;
			ArrivalTimePortalComponent.Type type = ArrivalTimePortalComponent.Type.Natural;
			Vector3 spawnPosition = Vector3.zero;
			Vector3 landingPosition = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
			if (!ArrivalTimePortalComponent.PopSpawnTransform(ref type, ref spawnPosition, ref landingPosition, ref rotation))
			{
				ArrivalTimePortalComponent.RandomTransform(out type, out spawnPosition, out landingPosition, out rotation);
			}
			_character = _arrivedCallback.OnArrived(spawnPosition);
			_characterAnimGraph = ((type == ArrivalTimePortalComponent.Type.Natural) ? _definition.CharacterNaturalAnimGraph : _definition.CharacterArtificialAnimGraph);
			_character.Position = spawnPosition;
			_character.Rotation = rotation;
			_character.NavPath.PutBackInNavWorld();
			_character.NavPath.Warp(spawnPosition);
			_character.NavPath.BecomeKinematic();
			_character.Interrupt();
			_character.PushAnimationGraph(_characterAnimGraph, 0f, this);
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
