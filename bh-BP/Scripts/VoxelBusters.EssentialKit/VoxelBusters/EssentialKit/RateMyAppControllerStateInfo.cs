using System;
using UnityEngine;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	internal class RateMyAppControllerStateInfo
	{
		[SerializeField]
		private string m_versionLastRated;

		[SerializeField]
		private int m_appLaunchCount;

		[SerializeField]
		private string m_promptLastShown;

		[SerializeField]
		private int m_promptCount;

		[SerializeField]
		private bool m_isActive;

		public string VersionLastRated
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int AppLaunchCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public DateTime? PromptLastShown
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int PromptCount
		{
			get
			{
				return 0;
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

		private static string SerializeDateTime(DateTime dateTime)
		{
			return null;
		}

		private static DateTime? DeserializeDateTime(string dateTimeStr)
		{
			return null;
		}
	}
}
