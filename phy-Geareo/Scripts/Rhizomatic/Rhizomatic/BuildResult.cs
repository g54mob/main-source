using UnityEngine;

namespace Rhizomatic
{
	[CreateAssetMenu(fileName = "build_result", menuName = "BuildSystem/BuildResult")]
	public class BuildResult : ScriptableObject
	{
		public string type;

		public uint major;

		public uint minor;

		public uint patch;

		public uint buildNumber;

		public string version;

		public string versionCore;

		public string GetDisplayVersion()
		{
			return null;
		}
	}
}
