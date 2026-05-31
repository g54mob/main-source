using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline.Utility
{
	public static class RTHandleUtility
	{
		private static MethodInfo setTextureInfo;

		private static object[] parameter;

		public static void SetTexture(this RTHandle handle, Texture texture)
		{
		}

		public static void SetRenderTargetIdentifier(this RTHandle handle, RenderTargetIdentifier identifier)
		{
		}
	}
}
