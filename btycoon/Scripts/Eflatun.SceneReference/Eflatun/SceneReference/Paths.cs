using System.IO;
using Eflatun.SceneReference.Utility;
using UnityEngine;

namespace Eflatun.SceneReference
{
	internal static class Paths
	{
		public static class RelativeToResources
		{
			private static readonly string MapPrefix = "Eflatun_SceneReference_";

			private static readonly string MapExt = ".generated.json";

			public static readonly string SceneGuidToPathMapFile = MapPrefix + "SceneGuidToPathMap" + MapExt;

			public static readonly string SceneGuidToPathMapMetaFile = MapPrefix + "SceneGuidToPathMap" + MapExt + ".meta";

			public static readonly string SceneGuidToAddressMapFile = MapPrefix + "SceneGuidToAddressMap" + MapExt;

			public static readonly string SceneGuidToAddressMapMetaFile = MapPrefix + "SceneGuidToAddressMap" + MapExt + ".meta";
		}

		public static class Absolute
		{
			public static readonly ConvertedPath SceneGuidToPathMapFile = new ConvertedPath(Path.Combine(ResourcesFolder.GivenPath, RelativeToResources.SceneGuidToPathMapFile));

			public static readonly ConvertedPath SceneGuidToPathMapMetaFile = new ConvertedPath(Path.Combine(ResourcesFolder.GivenPath, RelativeToResources.SceneGuidToPathMapMetaFile));

			public static readonly ConvertedPath SceneGuidToAddressMapFile = new ConvertedPath(Path.Combine(ResourcesFolder.GivenPath, RelativeToResources.SceneGuidToAddressMapFile));

			public static readonly ConvertedPath SceneGuidToAddressMapMetaFile = new ConvertedPath(Path.Combine(ResourcesFolder.GivenPath, RelativeToResources.SceneGuidToAddressMapMetaFile));
		}

		private static readonly ConvertedPath AssetsFolder = new ConvertedPath(Application.dataPath);

		public static readonly ConvertedPath ResourcesFolder = new ConvertedPath(Path.Combine(AssetsFolder.GivenPath, "Resources"));

		public static readonly ConvertedPath ResourcesMetaFile = new ConvertedPath(Path.Combine(AssetsFolder.GivenPath, "Resources.meta"));
	}
}
