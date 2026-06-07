using System;
using UnityEngine;
using UnityEngine.Events;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class LeaderboardScoreReporter : MonoBehaviour
	{
		[Serializable]
		private class ReportScoreFinishEvent : UnityEvent<bool, Error>
		{
		}

		[SerializeField]
		[LeaderboardId]
		private string m_leaderboardId;

		[SerializeField]
		private ReportScoreFinishEvent m_onReportScoreFinish;

		public void ReportScore(long score)
		{
		}
	}
}
