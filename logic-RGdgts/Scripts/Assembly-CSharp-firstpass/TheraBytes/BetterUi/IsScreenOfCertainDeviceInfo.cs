using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class IsScreenOfCertainDeviceInfo : IScreenTypeCheck, IIsActive
	{
		public enum DeviceInfo
		{
			Other = 0,
			Handheld = 1,
			Console = 2,
			Desktop = 3,
			TouchScreen = 4,
			VirtualReality = 5
		}

		[SerializeField]
		private DeviceInfo expectedDeviceInfo;

		[SerializeField]
		private bool isActive;

		public DeviceInfo ExpectedDeviceInfo
		{
			get
			{
				return default(DeviceInfo);
			}
			set
			{
			}
		}

		public bool IsActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsScreenType()
		{
			return false;
		}
	}
}
