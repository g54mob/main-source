using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGMaterialSettings
	{
		public bool SwapUV;

		[Tooltip("Options to keep texel size proportional")]
		public CGKeepAspectMode KeepAspect;

		public float UVRotation;

		public Vector2 UVOffset;

		public Vector2 UVScale;
	}
}
