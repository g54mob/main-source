using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	internal static class PSXShaderPassNames
	{
		public static readonly string s_PSXLitStr = "PSXLit";

		public static readonly string s_SRPDefaultUnlitStr = "SRPDefaultUnlit";

		public static readonly ShaderTagId s_PSXLit = new ShaderTagId(s_PSXLitStr);

		public static readonly ShaderTagId s_SRPDefaultUnlit = new ShaderTagId(s_SRPDefaultUnlitStr);
	}
}
