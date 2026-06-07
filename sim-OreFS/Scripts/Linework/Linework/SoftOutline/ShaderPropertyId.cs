using UnityEngine;

namespace Linework.SoftOutline
{
	internal static class ShaderPropertyId
	{
		public static readonly int Samples = Shader.PropertyToID("_Samples");

		public static readonly int KernelSize = Shader.PropertyToID("_KernelSize");

		public static readonly int KernelSpread = Shader.PropertyToID("_KernelSpread");

		public static readonly int Offset = Shader.PropertyToID("_offset");

		public static readonly int OutlineHardness = Shader.PropertyToID("_OutlineHardness");

		public static readonly int OutlineIntensity = Shader.PropertyToID("_OutlineIntensity");

		public static readonly int SilhouetteBuffer = Shader.PropertyToID("_SilhouetteBuffer");
	}
}
