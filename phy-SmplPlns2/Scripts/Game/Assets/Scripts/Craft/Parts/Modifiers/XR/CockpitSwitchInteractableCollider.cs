using Assets.Scripts.Input.Events;
using Assets.Scripts.XR;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	public class CockpitSwitchInteractableCollider : InteractableCollider
	{
		private const float SwitchPressTriggerValue = 0.8f;

		private CockpitSwitchScript _cockpitSwitch;

		private bool _lastPressWasFromTop;

		private float _minTriggerAfterPress;

		private bool _switchIsPressed;

		[SerializeField]
		private Transform _transformBottomEdge;

		[SerializeField]
		private Transform _transformTopEdge;

		public bool SwitchIsPressed
		{
			get
			{
				return _switchIsPressed;
			}
			private set
			{
				if (value != _switchIsPressed)
				{
					_switchIsPressed = value;
					((IInteractablePartModifier)_cockpitSwitch).HandleInput((IInputEvent)new InputEventXR
					{
						InputButton = InputButton.Primary,
						InputState = ((!value) ? InputState.End : InputState.Begin)
					}, true);
				}
			}
		}

		public Transform TransformBottomEdge
		{
			get
			{
				return _transformBottomEdge;
			}
			set
			{
				_transformBottomEdge = value;
			}
		}

		public Transform TransformTopEdge
		{
			get
			{
				return _transformTopEdge;
			}
			set
			{
				_transformTopEdge = value;
			}
		}

		public override void InteractionEnd()
		{
			base.InteractionEnd();
			SwitchIsPressed = false;
			_minTriggerAfterPress = 0f;
		}

		public override void InteractionUpdate(ref Pose fingertipPose, float fingertipRadius, float triggerPull, out float? forcePoint, FlightHand hand)
		{
			_minTriggerAfterPress = Mathf.Min(triggerPull, _minTriggerAfterPress);
			bool isSwitchActivated = _cockpitSwitch.IsSwitchActivated;
			Vector3 vector = _transformTopEdge.TransformPoint(Vector3.forward * fingertipRadius);
			Vector3 vector2 = _transformBottomEdge.TransformPoint(Vector3.forward * fingertipRadius);
			Vector3 b = (isSwitchActivated ? vector : vector2);
			Vector3 position;
			if (_minTriggerAfterPress < 0.01f)
			{
				position = Vector3.Lerp(fingertipPose.position, b, triggerPull / 0.8f);
			}
			else
			{
				Vector3 b2 = (_lastPressWasFromTop ? vector : vector2);
				position = Vector3.Lerp(Vector3.Lerp(fingertipPose.position, b2, _minTriggerAfterPress / 0.8f), b, Mathf.InverseLerp(_minTriggerAfterPress, 0.8f, triggerPull) / 0.8f);
			}
			fingertipPose.position = position;
			forcePoint = 1f;
			bool flag = triggerPull > 0.8f;
			if (flag != SwitchIsPressed)
			{
				SwitchIsPressed = flag;
				if (flag)
				{
					hand.SendHaptic(0.6f, 0.04f);
					_minTriggerAfterPress = triggerPull;
					_lastPressWasFromTop = isSwitchActivated;
				}
			}
		}

		protected override void Start()
		{
			base.Start();
			_cockpitSwitch = GetComponentInParent<CockpitSwitchScript>();
		}
	}
}
