using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.ShaderStripping
{
	[Serializable]
	public struct VariantsForShader
	{
		public Shader shader;

		public List<VariantInfo> variants;

		public VariantsForShader(Shader shader, List<VariantInfo> variants)
		{
			this.shader = shader;
			this.variants = variants;
		}
	}
}
