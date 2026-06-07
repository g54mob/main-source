using UnityEngine;

namespace VRTK
{
	public class VRTK_ControllerRigidbodyActivator : MonoBehaviour
	{
		[Tooltip("If this is checked then the Collider will have it's Rigidbody toggled on and off during a collision.")]
		public bool isEnabled = true;

		[Tooltip("If this is checked then the Rigidbody Activator will activate the rigidbody and colliders on the Interact Touch script.")]
		public bool activateInteractTouch = true;

		[Tooltip("If this is checked then the Rigidbody Activator will activate the rigidbody and colliders on the Controller Tracked Collider script.")]
		public bool activateTrackedCollider;

		public event ControllerRigidbodyActivatorEventHandler ControllerRigidbodyOn;

		public event ControllerRigidbodyActivatorEventHandler ControllerRigidbodyOff;

		public virtual void OnControllerRigidbodyOn(ControllerRigidbodyActivatorEventArgs e)
		{
			if (this.ControllerRigidbodyOn != null)
			{
				this.ControllerRigidbodyOn(this, e);
			}
		}

		public virtual void OnControllerRigidbodyOff(ControllerRigidbodyActivatorEventArgs e)
		{
			if (this.ControllerRigidbodyOff != null)
			{
				this.ControllerRigidbodyOff(this, e);
			}
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			ToggleRigidbody(collider, state: true);
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			ToggleRigidbody(collider, state: false);
		}

		protected virtual void ToggleRigidbody(Collider collider, bool state)
		{
			if (!isEnabled && state)
			{
				return;
			}
			if (activateTrackedCollider)
			{
				VRTK_ControllerTrackedCollider componentInParent = collider.GetComponentInParent<VRTK_ControllerTrackedCollider>();
				if (componentInParent != null)
				{
					componentInParent.ToggleColliders(state);
					EmitEvent(state, componentInParent.interactTouch);
				}
			}
			if (activateInteractTouch)
			{
				VRTK_InteractTouch componentInParent2 = collider.GetComponentInParent<VRTK_InteractTouch>();
				if (componentInParent2 != null)
				{
					componentInParent2.ToggleControllerRigidBody(state, state);
					EmitEvent(state, componentInParent2);
				}
			}
		}

		protected virtual void EmitEvent(bool state, VRTK_InteractTouch touch)
		{
			ControllerRigidbodyActivatorEventArgs e = default(ControllerRigidbodyActivatorEventArgs);
			e.touchingObject = touch;
			if (state)
			{
				OnControllerRigidbodyOn(e);
			}
			else
			{
				OnControllerRigidbodyOff(e);
			}
		}
	}
}
