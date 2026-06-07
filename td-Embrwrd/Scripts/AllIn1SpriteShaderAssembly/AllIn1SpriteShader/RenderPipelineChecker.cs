using System;
using System.Collections.Generic;
using System.Reflection;

namespace AllIn1SpriteShader
{
	public static class RenderPipelineChecker
	{
		private const string HDRP_PACKAGE = "HDRenderPipelineAsset";

		private const string URP_PACKAGE = "UniversalRenderPipelineAsset";

		public static bool IsHDRP { get; private set; }

		public static bool IsURP { get; private set; }

		public static bool IsStandardRP { get; private set; }

		public static void RefreshData()
		{
		}

		public static bool DoesTypeExist(string className)
		{
			return false;
		}

		public static IEnumerable<Type> GetTypesSafe(Assembly assembly)
		{
			return null;
		}
	}
}
