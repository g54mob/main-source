using UnityEngine;

namespace Linework.SurfaceFill
{
	internal static class ShaderPropertyId
	{
		public static readonly int PrimaryColor = Shader.PropertyToID("_Primary_Color");

		public static readonly int SecondaryColor = Shader.PropertyToID("_Secondary_Color");

		public static readonly int FrequencyX = Shader.PropertyToID("_FrequencyX");

		public static readonly int FrequencyY = Shader.PropertyToID("_FrequencyY");

		public static readonly int Density = Shader.PropertyToID("_Density");

		public static readonly int Rotation = Shader.PropertyToID("_Rotation");

		public static readonly int Direction = Shader.PropertyToID("_Direction");

		public static readonly int Offset = Shader.PropertyToID("_Offset");

		public static readonly int Speed = Shader.PropertyToID("_Speed");

		public static readonly int Scale = Shader.PropertyToID("_Scale");

		public static readonly int Texture = Shader.PropertyToID("_Texture");

		public static readonly int Softness = Shader.PropertyToID("_Softness");

		public static readonly int Width = Shader.PropertyToID("_Width");

		public static readonly int Power = Shader.PropertyToID("_Power");
	}
}
