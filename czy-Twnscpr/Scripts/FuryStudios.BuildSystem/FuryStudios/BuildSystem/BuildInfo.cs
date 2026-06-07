using System;
using UnityEngine;

namespace FuryStudios.BuildSystem
{
	[Serializable]
	public class BuildInfo : ScriptableObject
	{
		[Serializable]
		private struct DateTimeData
		{
			[SerializeField]
			private long ticks;

			[SerializeField]
			private DateTimeKind kind;

			public static implicit operator DateTime(DateTimeData data)
			{
				return default(DateTime);
			}

			public static implicit operator DateTimeData(DateTime date)
			{
				return default(DateTimeData);
			}
		}

		[SerializeField]
		private string repoName;

		[SerializeField]
		private string buildRevision;

		[SerializeField]
		private string buildBranch;

		[SerializeField]
		private DateTimeData revisionCommitTime;

		[SerializeField]
		private DateTimeData buildTime;

		[SerializeField]
		private string softwareVersion;

		[SerializeField]
		private int bundleVersionCode;

		[SerializeField]
		private string buildJobName;

		[SerializeField]
		private string buildJobVersion;

		public string RepoName => null;

		public string BuildRevision => null;

		public string BuildBranch => null;

		public DateTime RevisionCommitTime => default(DateTime);

		public DateTime BuildTime => default(DateTime);

		public string SoftwareVersion => null;

		public int BundleVersionCode => 0;

		public string BuildJobName => null;

		public string BuildJobVersion => null;

		public override string ToString()
		{
			return null;
		}
	}
}
