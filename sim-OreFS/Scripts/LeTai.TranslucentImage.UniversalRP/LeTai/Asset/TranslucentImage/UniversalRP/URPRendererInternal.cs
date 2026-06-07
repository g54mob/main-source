using System;
using System.Linq;
using System.Reflection;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	internal class URPRendererInternal
	{
		private ScriptableRenderer renderer;

		private Func<RTHandle> getBackBufferDelegate;

		private Func<RTHandle> getAfterPostColorDelegate;

		public void CacheRenderer(ScriptableRenderer renderer)
		{
			if (this.renderer != renderer)
			{
				this.renderer = renderer;
				CacheBackBufferGetter(renderer);
			}
			void CacheBackBufferGetter(object rd)
			{
				object value = rd.GetType().GetField("m_ColorBufferSystem", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rd);
				MethodInfo methodInfo = value.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).First((MethodInfo m) => m.Name == "PeekBackBuffer" && m.GetParameters().Length == 0);
				getBackBufferDelegate = (Func<RTHandle>)methodInfo.CreateDelegate(typeof(Func<RTHandle>), value);
			}
		}

		public RenderTargetIdentifier GetBackBuffer()
		{
			return getBackBufferDelegate().nameID;
		}

		public RenderTargetIdentifier GetAfterPostColor()
		{
			return getAfterPostColorDelegate().nameID;
		}
	}
}
