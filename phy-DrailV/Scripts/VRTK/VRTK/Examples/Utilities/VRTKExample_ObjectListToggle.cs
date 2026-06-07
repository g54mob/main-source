using UnityEngine;

namespace VRTK.Examples.Utilities
{
	public class VRTKExample_ObjectListToggle : MonoBehaviour
	{
		public GameObject[] objects = new GameObject[0];

		public GameObject[] retoggle = new GameObject[0];

		public VRTK_ControllerEvents controllerEvents;

		public VRTK_ControllerEvents.ButtonAlias toggleButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;

		protected int currentIndex;

		protected virtual void OnEnable()
		{
			currentIndex = 0;
			if (controllerEvents != null)
			{
				controllerEvents.SubscribeToButtonAliasEvent(toggleButton, startEvent: false, ButtonPressed);
			}
			ToggleObjects();
		}

		protected virtual void OnDisable()
		{
			if (controllerEvents != null)
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(toggleButton, startEvent: false, ButtonPressed);
			}
		}

		protected virtual void ButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			currentIndex++;
			if (currentIndex >= objects.Length)
			{
				currentIndex = 0;
			}
			ToggleObjects();
		}

		protected virtual void ToggleObjects()
		{
			for (int i = 0; i < objects.Length; i++)
			{
				if (objects[i] != null && i != currentIndex)
				{
					objects[i].SetActive(value: false);
				}
			}
			for (int j = 0; j < retoggle.Length; j++)
			{
				if (retoggle[j] != null && retoggle[j].activeInHierarchy)
				{
					retoggle[j].SetActive(value: false);
				}
			}
			Invoke("ToggleOn", 0f);
			Invoke("RetoggleOn", 0f);
		}

		protected virtual void ToggleOn()
		{
			objects[currentIndex].SetActive(value: true);
		}

		protected virtual void RetoggleOn()
		{
			for (int i = 0; i < retoggle.Length; i++)
			{
				if (retoggle[i] != null && !retoggle[i].activeInHierarchy)
				{
					retoggle[i].SetActive(value: true);
				}
			}
		}
	}
}
