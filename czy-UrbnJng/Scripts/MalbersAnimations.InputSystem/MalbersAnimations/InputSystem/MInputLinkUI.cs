using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace MalbersAnimations.InputSystem
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/annex/integrations/unity-input-system-new#input-link-ui")]
	[AddComponentMenu("Malbers/Input/MInput UI")]
	public class MInputLinkUI : MonoBehaviour
	{
		[Serializable]
		public struct HideUIByControlScheme
		{
			public StringReference controlScheme;

			public GameObject[] gameObjects;
		}

		public InputActionReference input;

		public HideUIByControlScheme[] GameObjectByControlScheme;

		public StringEvent UpdateInput = new StringEvent();

		private void OnEnable()
		{
			InputUser.onChange += OnUserChange;
		}

		private void OnDisable()
		{
			InputUser.onChange -= OnUserChange;
		}

		private void OnUserChange(InputUser user, InputUserChange change, InputDevice device)
		{
			if (change == InputUserChange.ControlsChanged)
			{
				UpdateUIInput(user.controlScheme.Value.name);
			}
		}

		public void UpdateUIInput(string newControlScheme)
		{
			UpdateInput.Invoke(input.action.GetBindingDisplayString());
			HideUIByControlScheme[] gameObjectByControlScheme = GameObjectByControlScheme;
			for (int i = 0; i < gameObjectByControlScheme.Length; i++)
			{
				HideUIByControlScheme hideUIByControlScheme = gameObjectByControlScheme[i];
				GameObject[] gameObjects = hideUIByControlScheme.gameObjects;
				foreach (GameObject gameObject in gameObjects)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(hideUIByControlScheme.controlScheme.Value.Contains(newControlScheme));
					}
				}
			}
		}

		private void Reset()
		{
			GameObjectByControlScheme = new HideUIByControlScheme[2];
			GameObjectByControlScheme[0].controlScheme = new StringReference("Keyboard and Mouse");
			GameObjectByControlScheme[1].controlScheme = new StringReference("GamePad");
		}
	}
}
