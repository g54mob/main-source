using UnityEngine;

namespace Mystery.Graphing
{
	public static class BuiltInGraphShader
	{
		public const string ShaderName = "Squiggle/Color Blended";

		private static Material lineMaterial;

		public static Material GetLineMaterial()
		{
			CreateLineMaterial();
			return lineMaterial;
		}

		private static void CreateLineMaterial()
		{
			if (!lineMaterial)
			{
				Shader shader = Shader.Find("Squiggle/Color Blended");
				if (!(shader == null))
				{
					lineMaterial = new Material(shader);
					lineMaterial.hideFlags = HideFlags.HideAndDontSave;
				}
			}
		}
	}
}
