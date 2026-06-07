using System;
using DV.CabControls.Spec;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	[DisallowMultipleComponent]
	public abstract class ControlImplBase : MonoBehaviour
	{
		public enum SetValueSource
		{
			Default = 0,
			Analog = 1
		}

		private ControlSpec spec;

		private bool _interactionAllowed = true;

		public float Value { get; private set; }

		public SetValueSource LastSetValueSource { get; protected set; }

		protected abstract InteractionHandPoses GenericHandPoses { get; }

		public GameObject[] InteractionColliderObjects
		{
			get
			{
				if (spec == null)
				{
					spec = GetComponent<ControlSpec>();
				}
				return spec.colliderGameObjects;
			}
		}

		public bool InteractionAllowed
		{
			get
			{
				return _interactionAllowed;
			}
			set
			{
				OnInteractionAllowedChanged(value);
			}
		}

		public event Action Used;

		public event Action UnUsed;

		public event Action<ControlImplBase> Grabbed;

		public event Action<ControlImplBase> Ungrabbed;

		public event Action<ValueChangedEventArgs> ValueChanged;

		public event Action<bool> InteractionAllowedChanged;

		protected virtual void Start()
		{
		}

		public virtual (string value, string unit) GetCurrentPositionName()
		{
			return (value: "", unit: "");
		}

		public virtual void Use()
		{
			if (InteractionAllowed)
			{
				LastSetValueSource = SetValueSource.Default;
				this.Used?.Invoke();
			}
		}

		public virtual void UnUse()
		{
			if (InteractionAllowed)
			{
				this.UnUsed?.Invoke();
			}
		}

		public virtual void ResetParent(bool forced = false)
		{
		}

		public void SetValue(float newValue, SetValueSource setValueSource = SetValueSource.Default)
		{
			float value = Value;
			newValue = Mathf.Clamp01(newValue);
			LastSetValueSource = setValueSource;
			if (newValue != value)
			{
				Value = newValue;
				this.ValueChanged?.Invoke(new ValueChangedEventArgs(value, newValue));
			}
			AcceptSetValue(Value);
		}

		protected abstract void AcceptSetValue(float newValue);

		protected void RequestValueUpdate(float newValue)
		{
			float value = Value;
			if (newValue != value)
			{
				Value = newValue;
				this.ValueChanged?.Invoke(new ValueChangedEventArgs(value, newValue));
			}
		}

		protected virtual void OnInteractionAllowedChanged(bool value)
		{
			if (value != _interactionAllowed)
			{
				_interactionAllowed = value;
				this.InteractionAllowedChanged?.Invoke(value);
			}
		}

		public abstract bool IsGrabbed();

		public abstract void ForceEndInteraction();

		protected virtual void FireGrabbed()
		{
			LastSetValueSource = SetValueSource.Default;
			this.Grabbed?.Invoke(this);
		}

		protected virtual void FireUngrabbed()
		{
			this.Ungrabbed?.Invoke(this);
		}

		public void SetLayerToInteractionColliders(int layer)
		{
			GameObject[] interactionColliderObjects = InteractionColliderObjects;
			foreach (GameObject gameObject in interactionColliderObjects)
			{
				if (gameObject != null)
				{
					gameObject.layer = layer;
				}
			}
		}

		public virtual void BlockControl(bool setBlock)
		{
		}

		public bool BaseInteractionPassThrough(Vector3 point)
		{
			return !InteractionAllowed;
		}

		protected InteractionHandPoses GenerateHandPoses()
		{
			ControlSpec component = GetComponent<ControlSpec>();
			HandPose handPose = HandPose.Generic;
			HandPose handPose2 = HandPose.Generic;
			HandPose handPose3 = HandPose.Generic;
			if (component != null)
			{
				handPose = component.handPosesOverride.nearTouchPose;
				handPose2 = component.handPosesOverride.touchPose;
				handPose3 = component.handPosesOverride.grabPose;
			}
			HandPose nearTouchPose = ((handPose != HandPose.Generic) ? handPose : GenericHandPoses.nearTouchPose);
			HandPose touchPose = ((handPose2 != HandPose.Generic) ? handPose2 : GenericHandPoses.touchPose);
			HandPose grabPose = ((handPose3 != HandPose.Generic) ? handPose3 : GenericHandPoses.grabPose);
			return new InteractionHandPoses(nearTouchPose, touchPose, grabPose);
		}
	}
}
