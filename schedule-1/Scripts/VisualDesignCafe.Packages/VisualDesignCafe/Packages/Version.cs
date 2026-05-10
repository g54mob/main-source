using System;
using UnityEngine;

namespace VisualDesignCafe.Packages
{
	[Serializable]
	public struct Version
	{
		[SerializeField]
		private string _bundleIdentifier;

		[SerializeField]
		private string _versionNumber;

		[SerializeField]
		private int _buildNumber;

		public bool IsValid => false;

		public string BundleIdentifier => null;

		public string VersionNumber => null;

		[Obsolete]
		public int BuildNumber => 0;

		public Version(string identifier, string versionNumber, int buildNumber)
		{
			_bundleIdentifier = null;
			_versionNumber = null;
			_buildNumber = 0;
		}

		public override string ToString()
		{
			return null;
		}

		public int CompareTo(in Version other)
		{
			return 0;
		}
	}
}
