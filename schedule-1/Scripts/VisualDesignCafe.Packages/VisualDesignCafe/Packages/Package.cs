using UnityEngine;

namespace VisualDesignCafe.Packages
{
	public class Package : ScriptableObject
	{
		[HideInInspector]
		[SerializeField]
		private string _displayName;

		[SerializeField]
		private string _description;

		[SerializeField]
		[HideInInspector]
		private Version _version;

		[SerializeField]
		private bool _downloadInBackground;

		[HideInInspector]
		[SerializeField]
		private int _priority;

		[SerializeField]
		private string _documentationUrl;

		[SerializeField]
		private string _demoScene;

		[SerializeField]
		private bool _pingAsset;

		public string DisplayName => null;

		public Version Version => default(Version);

		public bool DownloadInBackground => false;

		public int Priority => 0;

		public string DocumentationUrl => null;

		public string DemoScene => null;

		public bool Ping => false;

		public string Description => null;
	}
}
