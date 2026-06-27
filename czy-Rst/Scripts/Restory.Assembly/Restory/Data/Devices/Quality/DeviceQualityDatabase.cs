using UnityEngine;

namespace Restory.Data.Devices.Quality
{
	[CreateAssetMenu(menuName = "Restory/Devices/Quality/DeviceQualityDatabase", fileName = "DeviceQualityDatabase")]
	public class DeviceQualityDatabase : ScriptableObject
	{
		[SerializeField]
		private UnknownDeviceQuality unknownQuality;

		[SerializeField]
		private IdealDeviceQuality idealQuality;

		[SerializeField]
		private WorkingDeviceQuality workingQuality;

		[SerializeField]
		private BrokenDeviceQuality brokenQuality;

		public UnknownDeviceQuality UnknownQuality => unknownQuality;

		public IdealDeviceQuality IdealQuality => idealQuality;

		public WorkingDeviceQuality WorkingQuality => workingQuality;

		public BrokenDeviceQuality BrokenQuality => brokenQuality;
	}
}
