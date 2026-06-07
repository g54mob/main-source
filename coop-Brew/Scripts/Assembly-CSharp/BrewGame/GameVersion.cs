using UnityEngine;

namespace BrewGame
{
	[CreateAssetMenu(menuName = "Brewgether/Game Version", fileName = "GameVersion")]
	public sealed class GameVersion : ScriptableObject
	{
		private const string ResourcePath = "GameVersion";

		[Header("Semantic Version")]
		[SerializeField]
		private int _major;

		[SerializeField]
		private int _minor;

		[SerializeField]
		private int _patch;

		[Header("Pre-Release")]
		[SerializeField]
		private PreReleaseTag _preReleaseTag;

		[SerializeField]
		private int _preReleaseNumber;

		[Header("Build Info")]
		[SerializeField]
		private int _buildNumber;

		[SerializeField]
		private string _buildTimestamp;

		[SerializeField]
		private string _gitCommitHash;

		private static GameVersion _instance;

		public int Major => 0;

		public int Minor => 0;

		public int Patch => 0;

		public int BuildNumber => 0;

		public PreReleaseTag PreRelease => default(PreReleaseTag);

		public int PreReleaseNumber => 0;

		public string BuildTimestamp => null;

		public string GitCommitHash => null;

		public string VersionString => null;

		public string VersionStringWithPrefix => null;

		public string PreReleaseString => null;

		public string FullVersionString => null;

		public string FullVersionStringWithPrefix => null;

		public string DisplayVersion => null;

		public string ShortDisplayVersion => null;

		public static GameVersion Instance => null;

		public static string GetVersionString()
		{
			return null;
		}

		public static string GetVersionStringWithPrefix()
		{
			return null;
		}

		public static string GetFullVersionString()
		{
			return null;
		}

		public static string GetFullVersionStringWithPrefix()
		{
			return null;
		}

		public static string GetDisplayVersion()
		{
			return null;
		}

		public static string GetShortDisplayVersion()
		{
			return null;
		}

		public static int GetBuildNumber()
		{
			return 0;
		}
	}
}
