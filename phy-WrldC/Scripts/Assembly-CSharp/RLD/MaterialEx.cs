using UnityEngine;

namespace RLD
{
	public static class MaterialEx
	{
		public static void SetZWriteEnabled(this Material material, bool enabled)
		{
			material.SetInt("_ZWrite", enabled ? 1 : 0);
		}

		public static void SetZTestEnabled(this Material material, bool enabled)
		{
			material.SetInt("_ZTest", enabled ? 4 : 8);
		}

		public static void SetZTestAlways(this Material material)
		{
			material.SetInt("_ZTest", 8);
		}

		public static void SetZTestLess(this Material material)
		{
			material.SetInt("_ZTest", 2);
		}

		public static void SetCullModeBack(this Material material)
		{
			material.SetInt("_CullMode", 2);
		}

		public static void SetCullModeFront(this Material material)
		{
			material.SetInt("_CullMode", 1);
		}

		public static void SetCullModeOff(this Material material)
		{
			material.SetInt("_CullMode", 0);
		}

		public static void SetColor(this Material material, Color color)
		{
			material.SetColor("_Color", color);
		}

		public static void SetStencilCmpAlways(this Material material)
		{
			material.SetInt("_StencilComp", 8);
		}

		public static void SetStencilCmpNotEqual(this Material material)
		{
			material.SetInt("_StencilComp", 6);
		}
	}
}
