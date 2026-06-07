using System;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	internal sealed class LocationNotificationTrigger : INotificationTrigger
	{
		[SerializeField]
		private CircularRegion m_region;

		[SerializeField]
		private bool m_notifyOnEntry;

		[SerializeField]
		private bool m_notifyOnExit;

		[SerializeField]
		private bool m_repeats;

		public CircularRegion Region => default(CircularRegion);

		public bool NotifyOnEntry => false;

		public bool NotifyOnExit => false;

		public bool Repeats => false;

		public LocationNotificationTrigger(CircularRegion region, bool notifyOnEntry, bool notifyOnExit, bool repeats)
		{
		}
	}
}
