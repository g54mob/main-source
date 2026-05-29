using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	public static class CGResourceHandler
	{
		private static readonly Dictionary<string, ICGResourceLoader> resourceLoadersCache;

		public static void RegisterResourceLoader(string resourceName, ICGResourceLoader loader)
		{
		}

		[NotNull]
		public static Component CreateResource(CGModule module, [NotNull] string resName, [NotNull] string context)
		{
			return null;
		}

		public static void DestroyResource(CGModule module, [NotNull] string resName, Component obj, [NotNull] string context, bool kill)
		{
		}
	}
}
