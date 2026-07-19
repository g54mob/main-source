using System;
using UnityEngine;

namespace UniGLTF
{
	public static class gltfImporter
	{
		[Obsolete("Use ImporterContext.Load(path)")]
		public static ImporterContext Load(string path)
		{
			ImporterContext importerContext = new ImporterContext();
			importerContext.Load(path);
			importerContext.ShowMeshes();
			importerContext.EnableUpdateWhenOffscreen();
			return importerContext;
		}

		[Obsolete("Use ImporterContext.Parse(path, bytes)")]
		public static ImporterContext Parse(string path, byte[] bytes)
		{
			ImporterContext importerContext = new ImporterContext();
			importerContext.Load(path);
			importerContext.ShowMeshes();
			importerContext.EnableUpdateWhenOffscreen();
			return importerContext;
		}

		[Obsolete("use ImporterContext.Load()")]
		public static void Load(ImporterContext context)
		{
			context.Load();
			context.ShowMeshes();
			context.EnableUpdateWhenOffscreen();
		}

		public static void LoadVrmAsync(string path, byte[] bytes, Action<GameObject> onLoaded, Action<Exception> onError = null, bool show = true)
		{
			ImporterContext context = new ImporterContext();
			context.Parse(path, bytes);
			context.LoadAsync((Action)delegate
			{
				if (show)
				{
					context.ShowMeshes();
				}
				onLoaded(context.Root);
			}, onError);
		}
	}
}
