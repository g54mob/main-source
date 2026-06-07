using UnityEngine;

namespace VRTK.Examples
{
	public class ControlsMenu : MonoBehaviour
	{
		public float spawnDistance = 0.8f;

		public GameObject menuSlate;

		public VRTK_ControllerEvents controllerEvents;

		public VRTK_ControllerEvents.ButtonAlias toggleButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;

		protected bool isVisible;

		protected virtual void Awake()
		{
			isVisible = false;
			ToggleVisibility();
		}

		protected virtual void OnEnable()
		{
			if (controllerEvents != null)
			{
				controllerEvents.SubscribeToButtonAliasEvent(toggleButton, startEvent: true, ToggleButtonPressed);
			}
		}

		protected virtual void OnDisable()
		{
			if (controllerEvents != null)
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(toggleButton, startEvent: true, ToggleButtonPressed);
			}
		}

		protected virtual void ToggleButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			isVisible = !isVisible;
			if (isVisible && menuSlate != null)
			{
				Transform transform = VRTK_DeviceFinder.HeadsetTransform();
				menuSlate.transform.position = new Vector3(transform.position.x, 0f, transform.position.z) + transform.forward * spawnDistance;
				menuSlate.transform.position = new Vector3(menuSlate.transform.position.x, 0f, menuSlate.transform.position.z);
				Vector3 position = transform.position;
				position.y = menuSlate.transform.position.y;
				menuSlate.transform.LookAt(position);
			}
			ToggleVisibility();
		}

		protected virtual void ToggleVisibility()
		{
			if (menuSlate != null)
			{
				menuSlate.SetActive(isVisible);
			}
		}
	}
}
