using Assets.Scripts.Input.Events;
using Assets.Scripts.XR;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	public class CockpitButtonInteractableCollider : InteractableCollider
	{
		private const float ButtonPressTriggerValue = 0.8f;

		private bool _buttonIsPressed;

		private bool _circular;

		[SerializeField]
		private AnimationCurve _switchCurve;

		public bool ButtonIsPressed
		{
			get
			{
				return _buttonIsPressed;
			}
			private set
			{
				if (value != _buttonIsPressed)
				{
					_buttonIsPressed = value;
					base.InteractablePart.HandleInput(new InputEventXR
					{
						InputButton = InputButton.Primary,
						InputState = ((!value) ? InputState.End : InputState.Begin)
					}, isPartStillTarget: true);
				}
			}
		}

		public float ButtonPressAmount { get; private set; }

		public override void InteractionEnd()
		{
			base.InteractionEnd();
			ButtonPressAmount = 0f;
			ButtonIsPressed = false;
		}

		public override void InteractionUpdate(ref Pose fingertipPose, float fingertipRadius, float triggerPull, out float? forcePoint, FlightHand hand)
		{
			forcePoint = 1f;
			Vector3 vector = _collider.ClosestPoint(fingertipPose.position);
			if (_circular)
			{
				Vector3 vector2 = Vector3.ProjectOnPlane(base.transform.InverseTransformPoint(vector), _surfaceNormal);
				if (vector2.sqrMagnitude > 0.25f)
				{
					vector += base.transform.TransformVector(vector2 * (0.5f - vector2.magnitude));
				}
			}
			vector += base.transform.TransformDirection(_surfaceNormal) * fingertipRadius;
			bool flag = false;
			if (triggerPull < 0.8f)
			{
				fingertipPose.position = Vector3.Lerp(fingertipPose.position, vector, triggerPull / 0.8f);
				ButtonPressAmount = 0f;
			}
			else
			{
				fingertipPose.position = vector;
				float num = (triggerPull - 0.8f) / 0.19999999f;
				if (_switchCurve != null && _switchCurve.length >= 2)
				{
					num = _switchCurve.Evaluate(num);
				}
				ButtonPressAmount = num;
				flag = num > 0.5f;
			}
			if (ButtonIsPressed != flag)
			{
				ButtonIsPressed = flag;
				if (flag)
				{
					hand.SendHaptic(0.6f, 0.04f);
				}
				else
				{
					hand.SendHaptic(0.3f, 0.03f);
				}
			}
		}

		protected override void Start()
		{
			base.Start();
			CockpitButtonScript componentInParent = GetComponentInParent<CockpitButtonScript>();
			_circular = (object)componentInParent != null && componentInParent.Modifier.Style == CockpitButtonData.CockpitButtonStyle.Circular;
		}
	}
}
