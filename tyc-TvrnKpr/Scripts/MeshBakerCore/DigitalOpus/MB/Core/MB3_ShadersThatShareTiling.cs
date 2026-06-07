using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB3_ShadersThatShareTiling
	{
		public struct ShaderThatSharesTiling
		{
			public string shadername;

			public bool allPropsShareTiling;

			public string tilingTexturePropName;
		}

		private static MB3_ShadersThatShareTiling _singleton;

		private Dictionary<string, ShaderThatSharesTiling> shadersThatShareTiling;

		public static MB3_ShadersThatShareTiling GetShadersThatShareTiling()
		{
			return null;
		}

		public static void GetScaleAndOffsetForTextureProp(Material m, string texturePropName, out Vector2 offset, out Vector2 scale)
		{
			offset = default(Vector2);
			scale = default(Vector2);
		}

		private static void Init()
		{
		}
	}
}
