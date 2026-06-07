using UnityEngine;

namespace AmplifyImpostors
{
	public static class MaterialEx
	{
		public static void EnsureTextureKeywordState(this Material material, string property, string keyword)
		{
			Texture texture = (material.HasProperty(property) ? material.GetTexture(property) : null);
			material.EnsureKeywordState(keyword, texture != null);
		}

		public static void EnsureKeywordState(this Material material, string keyword, bool state)
		{
			if (state && !material.IsKeywordEnabled(keyword))
			{
				material.EnableKeyword(keyword);
			}
			else if (!state && material.IsKeywordEnabled(keyword))
			{
				material.DisableKeyword(keyword);
			}
		}
	}
}
