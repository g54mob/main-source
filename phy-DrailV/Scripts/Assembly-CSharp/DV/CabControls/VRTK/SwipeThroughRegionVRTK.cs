using UnityEngine;
using VRTK;

namespace DV.CabControls.VRTK
{
	[DisallowMultipleComponent]
	public class SwipeThroughRegionVRTK : MonoBehaviour
	{
		private enum State
		{
			Idle = 1,
			Entered_With_Button_Pressed = 2,
			Entered_Without_Button_Pressed = 3,
			Waiting_For_Release = 4
		}

		public SwipeEvent Triggered = new SwipeEvent();

		public Collider trigger;

		private State state;

		private VRTK_ControllerEvents enteredController;

		private Vector3 entryPosition;

		private void Start()
		{
			if (trigger == null)
			{
				trigger = GetComponentInChildren<Collider>();
			}
			ResetToIdle();
		}

		private void OnTriggerEnter(Collider c)
		{
			if (state != State.Idle)
			{
				return;
			}
			GameObject scriptAlias = VRTK_ControllerReference.GetControllerReference(c.attachedRigidbody.gameObject).scriptAlias;
			enteredController = (scriptAlias ? scriptAlias.GetComponent<VRTK_ControllerEvents>() : null);
			entryPosition = c.attachedRigidbody.transform.position;
			if (enteredController != null)
			{
				if (enteredController.triggerPressed)
				{
					state = State.Entered_With_Button_Pressed;
				}
				else
				{
					state = State.Entered_Without_Button_Pressed;
				}
			}
		}

		private void OnTriggerExit(Collider c)
		{
			if (State.Idle != state)
			{
				GameObject obj = c.attachedRigidbody.gameObject;
				Vector3 arg = c.attachedRigidbody.transform.position - entryPosition;
				if (obj == enteredController.gameObject)
				{
					ResetToIdle();
					Triggered.Invoke(arg, arg1: true);
				}
			}
		}

		private void Update()
		{
			if (enteredController == null && state != State.Idle)
			{
				Debug.LogWarning("Seems like the object disappeared, reverting to idle state", this);
				ResetToIdle();
			}
			else if (State.Entered_Without_Button_Pressed == state)
			{
				if (enteredController.triggerPressed)
				{
					Triggered.Invoke(Vector3.zero, arg1: false);
					state = State.Waiting_For_Release;
				}
			}
			else if (State.Waiting_For_Release == state)
			{
				if (!enteredController.triggerPressed)
				{
					state = State.Entered_Without_Button_Pressed;
				}
			}
			else if (State.Entered_With_Button_Pressed == state && !enteredController.triggerPressed)
			{
				state = State.Entered_Without_Button_Pressed;
			}
		}

		private void ResetToIdle()
		{
			state = State.Idle;
			enteredController = null;
			entryPosition = Vector3.zero;
		}
	}
}
