using UnityEngine;
using UnityEngine.Rendering;

namespace Jundroo.Common.Extensions
{
	public static class MaterialExtensions
	{
		public static bool SetLocalKeyword(this Material material, string keywordName, bool value, bool logErrors = true)
		{
			Shader shader = material.shader;
			LocalKeyword keyword = shader.keywordSpace.FindKeyword(keywordName);
			if (keyword.isValid)
			{
				material.SetKeyword(in keyword, value);
				return true;
			}
			if (logErrors)
			{
				Debug.LogError("Unable to set keyword '" + keywordName + "' on material '" + material.name + "' because the keyword can not be found for shader '" + shader.name + "'");
			}
			return false;
		}
	}
}
