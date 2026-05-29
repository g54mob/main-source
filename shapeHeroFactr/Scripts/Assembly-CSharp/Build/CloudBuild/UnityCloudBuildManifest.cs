using System;

namespace Build.CloudBuild
{
	[Serializable]
	public class UnityCloudBuildManifest
	{
		public string scmCommitId;

		public string scmBranch;

		public string buildNumber;

		public string buildStartTime;

		public string projectId;

		public string bundleId;

		public string unityVersion;

		public string xcodeVersion;

		public string cloudBuildTargetName;
	}
}
