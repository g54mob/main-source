using System;
using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	public class LoadingManager
	{
		public Dictionary<DlcType, string> MountedPaths { get; }

		public Dictionary<DlcType, BundleManifestData> LoadedDlc { get; }

		public void LoadDlcs(Action callback)
		{
		}

		public void MountDlc(DlcType dlcType, Action callback)
		{
		}

		private void LogAllMountedPaths()
		{
		}

		public void UnmountAllDlc(Action callback)
		{
		}

		public void UnmountDlc(DlcType dlcType, Action callback)
		{
		}

		private void LoadDlc(int index, List<DlcType> dlcsToLoad, Action callback)
		{
		}

		private void LoadIncludedDlc(int index, List<DlcType> dlcsToLoad, Action callback)
		{
		}

		private void LoadManifestDirect(DlcType dlcType, string path, Action<bool> callback)
		{
		}

		public void ValidateDlcVersions(Action callback)
		{
		}

		private void ValidateVersion(int index, DlcType[] dlcs, Action callback)
		{
		}
	}
}
