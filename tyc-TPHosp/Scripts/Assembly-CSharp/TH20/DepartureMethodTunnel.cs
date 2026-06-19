using System;
using UnityEngine;

namespace TH20
{
	public class DepartureMethodTunnel : DepartureMethod, IAnimationEndEvent
	{
		private readonly DepartureMethodTunnelDefinition _definition;

		private readonly Vector3 _departurePosition;

		private readonly float _departureRotation;

		private bool _departed;

		public DepartureMethodTunnel(DepartureMethodTunnelDefinition definition, Character character, IDepartedCallback callback)
			: base(character, callback)
		{
			_definition = definition;
			Transform transform = DepartureTunnelComponent.RandomTunnel().GetTransform();
			_departurePosition = transform.position;
			_departureRotation = transform.rotation.eulerAngles.y;
		}

		public override void ReadyToDepart()
		{
			_character.NavPath.Warp(_departurePosition);
			_character.NavPath.BecomeKinematic();
			_character.Position = _departurePosition;
			_character.RotationY = _departureRotation;
			_character.Interrupt();
			_character.PushAnimationGraph(_definition.CharacterAnimGraph, 0.25f, this);
		}

		public override bool Update()
		{
			return _departed;
		}

		public override Vector3 Position()
		{
			return _departurePosition;
		}

		public override float Rotation()
		{
			return _departureRotation;
		}

		public void OnAnimationEndEvent()
		{
			_departed = true;
			if (_departedCallback != null)
			{
				_departedCallback.OnDeparted();
			}
			else
			{
				_character.Level.CharacterEvents.OnDestroyCharacter.InvokeSafe(_character);
			}
		}

		public override void RestoreFromSave()
		{
			Character character = _character;
			character.PostRestoreFromSaveCallback = (Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (Action)delegate
			{
				if (_character.AnimationGraph == _definition.CharacterAnimGraph)
				{
					_character.FixupAnimationEndEvent(this, _definition.CharacterAnimGraph);
				}
			});
		}
	}
}
