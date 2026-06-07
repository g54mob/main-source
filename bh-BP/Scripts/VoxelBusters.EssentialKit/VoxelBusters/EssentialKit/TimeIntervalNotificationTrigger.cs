using System;
using UnityEngine;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public sealed class TimeIntervalNotificationTrigger : INotificationTrigger
	{
		[SerializeField]
		private double m_timeInterval;

		[SerializeField]
		private bool m_repeats;

		private DateTime? m_nextTriggerDate;

		public double TimeInterval => 0.0;

		public DateTime? NextTriggerDate => null;

		public bool Repeats => false;

		public TimeIntervalNotificationTrigger(double timeInterval, bool repeats, DateTime? nextTriggerDate = null)
		{
		}
	}
}
