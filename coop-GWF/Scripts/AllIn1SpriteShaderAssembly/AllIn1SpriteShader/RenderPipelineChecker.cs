using System;
using System.Collections.Generic;
using System.Linq;
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
			IsHDRP = DoesTypeExist("HDRenderPipelineAsset");
			IsURP = DoesTypeExist("UniversalRenderPipelineAsset");
			if (!IsHDRP && !IsURP)
			{
				IsStandardRP = true;
			}
		}

		public static bool DoesTypeExist(string className)
		{
			return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
				from type in GetTypesSafe(assembly)
				where type.Name == className
				select type).FirstOrDefault() != null;
		}

		public static IEnumerable<Type> GetTypesSafe(Assembly assembly)
		{
			Type[] types;
			try
			{
				types = assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException ex)
			{
				types = ex.Types;
			}
			return types.Where((Type x) => x != null);
		}
	}
}
