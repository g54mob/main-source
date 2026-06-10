using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class PathSettings : MonoBehaviour
	{
		[Tooltip("Default root path for models")]
		public RootPathEnum defaultRootPath;

		[Tooltip("Root path for models on mobile devices")]
		public RootPathEnum mobileRootPath;

		public string RootPath => null;

		public static PathSettings FindPathComponent(GameObject obj)
		{
			return null;
		}

		public string FullPath(string path)
		{
			return null;
		}
	}
}
