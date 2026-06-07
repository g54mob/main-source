using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class StyleSwatch
	{
		public string id;

		public string displayName;

		public Color color;

		[Range(0f, 1f)]
		public float gloss;

		[Range(0f, 1f)]
		public float metallic;

		public Color emissive;
	}
}
