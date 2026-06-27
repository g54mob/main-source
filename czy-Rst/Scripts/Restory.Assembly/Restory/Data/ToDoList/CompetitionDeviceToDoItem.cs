using Restory.Data.Devices;
using UnityEngine;

namespace Restory.Data.ToDoList
{
	public class CompetitionDeviceToDoItem : ToDoItem
	{
		[SerializeField]
		private DeviceInfo deviceInfo;

		[SerializeField]
		private bool any;

		public DeviceInfo DeviceInfo => deviceInfo;

		public bool Any => any;
	}
}
