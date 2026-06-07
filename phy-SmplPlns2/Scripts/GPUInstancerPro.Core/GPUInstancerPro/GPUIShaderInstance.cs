using System;
using UnityEngine;

namespace GPUInstancerPro
{
	[Serializable]
	public class GPUIShaderInstance
	{
		public string shaderName;

		public string replacementShaderName;

		public string extensionCode;

		public bool isUseOriginal;

		public string modifiedDate;

		public Shader originalShader
		{
			get
			{
				if (string.IsNullOrEmpty(shaderName))
				{
					return null;
				}
				return GPUIUtility.FindShader(shaderName);
			}
		}

		public Shader replacementShader
		{
			get
			{
				if (string.IsNullOrEmpty(replacementShaderName))
				{
					return null;
				}
				return GPUIUtility.FindShader(replacementShaderName);
			}
		}
	}
}
