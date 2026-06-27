using System;
using UnityEngine;

namespace Restory.UserInterface
{
	public class GUI_SteamDeckActivitySwitcher : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] gameObjects = Array.Empty<GameObject>();

		[SerializeField]
		private string[] forbiddenOperationSystemNames = Array.Empty<string>();

		[SerializeField]
		private string[] forbiddenDeviceNames = new string[2] { "Jupiter (Valve)", "Valve" };

		[SerializeField]
		private string[] forbiddenDeviceModels = new string[2] { "Jupiter (Valve)", "Valve" };

		private void OnEnable()
		{
			UpdateActivity();
		}

		private void UpdateActivity()
		{
			bool active = !IsInForbiddenPlatform() && !IsOnForbiddenDevice();
			GameObject[] array = gameObjects;
			foreach (GameObject gameObject in array)
			{
				if ((bool)gameObject)
				{
					gameObject.SetActive(active);
				}
			}
		}

		private bool IsOnForbiddenDevice()
		{
			string deviceName = SystemInfo.deviceName;
			string deviceModel = SystemInfo.deviceModel;
			if (!DoesNameContainSubstringOfAnyArrayElement(deviceName, forbiddenDeviceNames) && !DoesNameContainSubstringOfAnyArrayElement(deviceModel, forbiddenDeviceNames) && !DoesNameContainSubstringOfAnyArrayElement(deviceName, forbiddenDeviceModels))
			{
				return DoesNameContainSubstringOfAnyArrayElement(deviceModel, forbiddenDeviceModels);
			}
			return true;
		}

		private bool IsInForbiddenPlatform()
		{
			return DoesNameContainSubstringOfAnyArrayElement(SystemInfo.operatingSystem, forbiddenOperationSystemNames);
		}

		private bool DoesNameContainSubstringOfAnyArrayElement(string targetName, string[] namesArray)
		{
			string text = targetName.ToLower();
			for (int i = 0; i < namesArray.Length; i++)
			{
				string value = namesArray[i].ToLower();
				if (text.Contains(value))
				{
					return true;
				}
			}
			return false;
		}
	}
}
