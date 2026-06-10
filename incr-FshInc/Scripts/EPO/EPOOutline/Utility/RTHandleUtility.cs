using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline.Utility
{
	public static class RTHandleUtility
	{
		private static MethodInfo setTextureInfo;

		private static object[] parameter = new object[1];

		public static void SetTexture(this RTHandle handle, Texture texture)
		{
			if (setTextureInfo == null)
			{
				setTextureInfo = typeof(RTHandle).GetMethod("SetTexture", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[1] { typeof(Texture) }, null);
			}
			parameter[0] = texture;
			setTextureInfo.Invoke(handle, parameter);
		}

		public static void SetRenderTargetIdentifier(this RTHandle handle, RenderTargetIdentifier identifier)
		{
			RTHandleStaticHelpers.SetRTHandleUserManagedWrapper(ref handle, identifier);
		}
	}
}
