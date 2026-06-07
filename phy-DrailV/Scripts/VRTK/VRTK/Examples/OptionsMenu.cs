using UnityEngine;

namespace VRTK.Examples
{
	public class OptionsMenu : MonoBehaviour
	{
		public VRTK_ControllerEvents leftController;

		public VRTK_ControllerEvents rightController;

		public GameObject controlObject;

		protected bool state;

		protected virtual void OnEnable()
		{
			state = false;
			RegisterEvents(leftController);
			RegisterEvents(rightController);
			SetObjectVisibility();
		}

		protected virtual void RegisterEvents(VRTK_ControllerEvents events)
		{
			if (events != null)
			{
				events.ButtonTwoPressed += ButtonTwoPressed;
			}
		}

		protected virtual void ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
		{
			state = !state;
			Move();
			SetObjectVisibility();
		}

		protected virtual void Move()
		{
			Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
			Transform transform2 = VRTK_DeviceFinder.HeadsetTransform();
			if (transform != null && transform2 != null)
			{
				base.transform.position = new Vector3(transform2.position.x, transform.position.y, transform2.position.z);
				controlObject.transform.localPosition = transform2.forward * 0.5f;
				controlObject.transform.localPosition = new Vector3(controlObject.transform.localPosition.x, 0f, controlObject.transform.localPosition.z);
				Vector3 position = transform2.position;
				position.y = transform.transform.position.y;
				controlObject.transform.LookAt(position);
				controlObject.transform.localEulerAngles = new Vector3(0f, controlObject.transform.localEulerAngles.y, 0f);
			}
		}

		protected virtual void SetObjectVisibility()
		{
			controlObject.SetActive(state);
		}
	}
}
