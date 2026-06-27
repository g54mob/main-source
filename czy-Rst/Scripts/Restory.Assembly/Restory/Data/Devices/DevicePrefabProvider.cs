using Restory.Data.GameView;
using Restory.Gameplay.Devices;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/DevicePrefabProvider", fileName = "DevicePrefabProvider")]
	public class DevicePrefabProvider : ScriptableObject
	{
		[SerializeField]
		private GameViewPreset smallDevicePreset;

		[SerializeField]
		private GameViewPreset mediumDevicePreset;

		[SerializeField]
		private DismantledDevicePack defaultDismantledDevicePackPrefab;

		[SerializeField]
		private DismantledDevicePack bigDismantledDevicePackPrefab;

		public DismantledDevicePack GetPrefabForPackedDismantledDevice(GameViewPreset devicePreset)
		{
			if (devicePreset == smallDevicePreset)
			{
				return defaultDismantledDevicePackPrefab;
			}
			return bigDismantledDevicePackPrefab;
		}

		public bool IsSmallDevice(GameViewPreset devicePreset)
		{
			return devicePreset == smallDevicePreset;
		}
	}
}
