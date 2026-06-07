using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Coffee.UISoftMaskInternal
{
	internal static class RenderTextureRepository
	{
		private static readonly ObjectRepository<RenderTexture> s_Repository = new ObjectRepository<RenderTexture>();

		private static readonly GraphicsFormat s_GraphicsFormat = GraphicsFormatUtility.GetGraphicsFormat(RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);

		private static readonly GraphicsFormat s_StencilFormat = GraphicsFormatUtility.GetDepthStencilFormat(0, 8);

		public static int count => s_Repository.count;

		public static bool Valid(Hash128 hash, RenderTexture rt)
		{
			return s_Repository.Valid(hash, rt);
		}

		public static void Get<T>(Hash128 hash, ref RenderTexture rt, Func<T, RenderTexture> onCreate, T source)
		{
			s_Repository.Get(hash, ref rt, onCreate, source);
		}

		public static RenderTextureDescriptor GetDescriptor(Vector2Int size, bool useStencil)
		{
			RenderTextureDescriptor result = new RenderTextureDescriptor(size.x, size.y, s_GraphicsFormat, useStencil ? 24 : 0);
			result.sRGB = QualitySettings.activeColorSpace == ColorSpace.Linear;
			result.mipCount = -1;
			result.depthStencilFormat = (useStencil ? s_StencilFormat : GraphicsFormat.None);
			return result;
		}

		public static void Release(ref RenderTexture rt)
		{
			s_Repository.Release(ref rt);
		}

		public static Vector2Int GetPreferSize(Vector2Int size, int downSamplingRate)
		{
			float num = (float)size.x / (float)size.y;
			Vector2Int screenSize = GetScreenSize();
			size.x = Mathf.Clamp(size.x, 8, screenSize.x);
			size.y = Mathf.Clamp(size.y, 8, screenSize.y);
			if (downSamplingRate <= 0)
			{
				if (size.x < size.y)
				{
					size.x = Mathf.CeilToInt((float)size.y * num);
				}
				else
				{
					size.y = Mathf.CeilToInt((float)size.x / num);
				}
				return size;
			}
			if (size.x < size.y)
			{
				size.y = Mathf.NextPowerOfTwo(size.y / 2) / downSamplingRate;
				size.x = Mathf.CeilToInt((float)size.y * num);
			}
			else
			{
				size.x = Mathf.NextPowerOfTwo(size.x / 2) / downSamplingRate;
				size.y = Mathf.CeilToInt((float)size.x / num);
			}
			return size;
		}

		public static Vector2Int GetScreenSize(int downSamplingRate)
		{
			return GetPreferSize(GetScreenSize(), downSamplingRate);
		}

		public static Vector2Int GetScreenSize()
		{
			return new Vector2Int(Screen.width, Screen.height);
		}
	}
}
