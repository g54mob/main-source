using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class SwatchMaterialTemplate
	{
		public const string BASE_MATERIAL_KEY = "base";

		public const string TRANSPARENT_MATERIAL_KEY = "transparent";

		public const string IF_MATERIAL_KEY = "if";

		public string id;

		public Material material;
	}
}
