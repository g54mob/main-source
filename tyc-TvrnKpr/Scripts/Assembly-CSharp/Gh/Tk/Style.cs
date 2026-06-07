using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class Style
	{
		public string id;

		public string displayName;

		[Range(1f, 10f)]
		public float costMultiplier;

		public List<string> swatchIds;

		public const int SWATCH_COLOUR_GROUPS = 16;

		public bool IsLocalStyle { get; set; }

		public List<StyleSwatch> GetSwatches()
		{
			return null;
		}

		public void ApplyToRenderer(Renderer renderer, string swatchMaterialOverride = null)
		{
		}

		private void ApplyColourToMesh(Mesh mesh, int colourGroupID, Color color, float gloss, float metallic)
		{
		}
	}
}
