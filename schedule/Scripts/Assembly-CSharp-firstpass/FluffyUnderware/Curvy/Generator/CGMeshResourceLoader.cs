using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	public class CGMeshResourceLoader : ICGResourceLoader
	{
		[EnvironmentAgnosticInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		protected static void InitializeOnLoad()
		{
		}

		public Component Create(CGModule cgModule, string context)
		{
			return null;
		}

		public void Destroy(CGModule cgModule, Component obj, string context, bool kill)
		{
		}
	}
}
