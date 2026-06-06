using UnityEngine;

public static class Constants
{
	public static class MaterialProperties
	{
		public static readonly int CurrentTexture = Shader.PropertyToID("_Current");

		public static readonly int TargetTexture = Shader.PropertyToID("_Target");

		public static readonly int Blend = Shader.PropertyToID("_Blend");

		public static readonly int State = Shader.PropertyToID("_State");
	}
}
