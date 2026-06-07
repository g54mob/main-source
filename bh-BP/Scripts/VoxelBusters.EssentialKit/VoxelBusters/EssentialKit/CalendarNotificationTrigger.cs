using System;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public sealed class CalendarNotificationTrigger : INotificationTrigger
	{
		[SerializeField]
		private DateComponents m_dateComponents;

		[SerializeField]
		private bool m_repeats;

		private DateTime? m_nextTriggerDate;

		public DateComponents DateComponents => null;

		public DateTime? NextTriggerDate => null;

		public bool Repeats => false;

		public CalendarNotificationTrigger(DateComponents dateComponents, bool repeats, DateTime? nextTriggerDate = null)
		{
		}
	}
}
