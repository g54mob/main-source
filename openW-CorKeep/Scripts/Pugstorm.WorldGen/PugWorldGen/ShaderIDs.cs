using UnityEngine;

namespace PugWorldGen
{
	public class ShaderIDs
	{
		public static int Area = Shader.PropertyToID("_Area");

		public static int Pass0 = Shader.PropertyToID("_Pass0");

		public static int Pass1 = Shader.PropertyToID("_Pass1");

		public static int Pass2 = Shader.PropertyToID("_Pass2");

		public static int RoundPosition = Shader.PropertyToID("_RoundPosition");

		public static int TileSize = Shader.PropertyToID("_TileSize");
	}
}
