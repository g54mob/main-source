using System.Collections.Generic;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public class DevicePowerUpVisualizer : MonoBehaviour
	{
		[SerializeField]
		private List<ElementSocket> notActiveOnPowerUpSockets;

		[SerializeField]
		private List<GameObject> activeOnPowerUpObjects;

		public void OnPowerUp()
		{
			SwitchDeviceCheckObjectsState(isPowerUp: true);
		}

		public void OnPowerOff()
		{
			SwitchDeviceCheckObjectsState(isPowerUp: false);
		}

		private void SwitchDeviceCheckObjectsState(bool isPowerUp)
		{
			foreach (ElementSocket notActiveOnPowerUpSocket in notActiveOnPowerUpSockets)
			{
				if ((bool)notActiveOnPowerUpSocket)
				{
					notActiveOnPowerUpSocket.gameObject.SetActive(!isPowerUp);
				}
			}
			foreach (GameObject activeOnPowerUpObject in activeOnPowerUpObjects)
			{
				if ((bool)activeOnPowerUpObject)
				{
					activeOnPowerUpObject.SetActive(isPowerUp);
				}
			}
		}
	}
}
