using System;
using UnityEngine;
using UnityEngine.Events;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class AchievementProgressReporter : MonoBehaviour
	{
		[Serializable]
		private class ReportProgressFinishEvent : UnityEvent<bool, Error>
		{
		}

		[SerializeField]
		[AchievementId]
		private string m_achievementId;

		[SerializeField]
		private ReportProgressFinishEvent m_onReportProgressFinish;

		public void ReportProgress(double percentageCompleted)
		{
		}
	}
}
