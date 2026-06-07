using UnityEngine;

namespace Slicer2D
{
	public class SmartMaterial
	{
		public Material material;

		public SmartMaterial(string path)
		{
		}

		public SmartMaterial(SmartMaterial met)
		{
		}

		public static Shader LoadShader(string path)
		{
			return null;
		}

		public void SetTexture(Texture texture)
		{
		}

		public void SetColor(Color color)
		{
		}
	}
}
