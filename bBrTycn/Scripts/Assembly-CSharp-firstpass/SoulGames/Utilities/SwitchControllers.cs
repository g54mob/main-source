using UnityEngine;

namespace SoulGames.Utilities
{
	public class SwitchControllers : MonoBehaviour
	{
		[Space]
		[Tooltip("Starting enabled game object list")]
		[SerializeField]
		private GameObject[] startingActiveObjects;

		[Tooltip("Starting enabled camera parent")]
		[SerializeField]
		private Transform mainCamStartingActiveParent;

		[Space]
		[Tooltip("Switching enabled game object list. Disabled at the start")]
		[SerializeField]
		private GameObject[] switchingObjects;

		[Tooltip("Switching enabled camera parent. Disabled at the start")]
		[SerializeField]
		private Transform mainCamSwitchingParent;

		[Space]
		[Tooltip("Input key to switch between objects")]
		[SerializeField]
		private KeyCode switchToggleKey = KeyCode.Backspace;

		private Transform mainCam;

		private bool toggled;

		private SimpleFirstPersonCameraController cameraController;

		private void Start()
		{
			mainCam = Camera.main.transform;
		}

		private void Update()
		{
			if (!Input.GetKeyDown(switchToggleKey))
			{
				return;
			}
			if (toggled)
			{
				toggled = false;
				if ((bool)mainCamStartingActiveParent && (bool)mainCamSwitchingParent)
				{
					mainCam.parent = base.transform;
				}
				GameObject[] array = startingActiveObjects;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: true);
				}
				array = switchingObjects;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
				if ((bool)mainCamStartingActiveParent && (bool)mainCamSwitchingParent)
				{
					Invoke("ExecuteAfterTimeNotToggled", 1f);
				}
			}
			else
			{
				toggled = true;
				if ((bool)mainCamStartingActiveParent && (bool)mainCamSwitchingParent)
				{
					mainCam.parent = base.transform;
				}
				GameObject[] array = switchingObjects;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: true);
				}
				array = startingActiveObjects;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
				if ((bool)mainCamStartingActiveParent && (bool)mainCamSwitchingParent)
				{
					Invoke("ExecuteAfterTimeToggled", 1f);
				}
			}
		}

		private void ExecuteAfterTimeNotToggled()
		{
			mainCam.parent = mainCamStartingActiveParent;
		}

		private void ExecuteAfterTimeToggled()
		{
			mainCam.parent = mainCamSwitchingParent;
		}
	}
}
