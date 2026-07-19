using System;
using System.IO;
using System.Threading.Tasks;
using DepthFirstScheduler;
using UnityEngine;

namespace VRM
{
	public static class VRMImporter
	{
		[Obsolete("use VRMImporterContext.Load(path)")]
		public static GameObject LoadFromPath(string path)
		{
			VRMImporterContext vRMImporterContext = new VRMImporterContext();
			vRMImporterContext.Parse(path, File.ReadAllBytes(path));
			vRMImporterContext.Load();
			vRMImporterContext.ShowMeshes();
			vRMImporterContext.EnableUpdateWhenOffscreen();
			return vRMImporterContext.Root;
		}

		[Obsolete("use VRMImporterContext.Load(bytes)")]
		public static GameObject LoadFromBytes(byte[] bytes)
		{
			VRMImporterContext vRMImporterContext = new VRMImporterContext();
			vRMImporterContext.ParseGlb(bytes);
			vRMImporterContext.Load();
			vRMImporterContext.ShowMeshes();
			vRMImporterContext.EnableUpdateWhenOffscreen();
			return vRMImporterContext.Root;
		}

		[Obsolete("use VRMImporterContext.Load()")]
		public static void LoadFromBytes(VRMImporterContext context)
		{
			context.Load();
			context.ShowMeshes();
			context.EnableUpdateWhenOffscreen();
		}

		[Obsolete("use VRMImporterContext.LoadAsync")]
		public static void LoadVrmAsync(string path, Action<GameObject> onLoaded, Action<Exception> onError = null, bool show = true)
		{
			LoadVrmAsync(File.ReadAllBytes(path), onLoaded, onError, show);
		}

		[Obsolete("use VRMImporterContext.LoadAsync")]
		public static void LoadVrmAsync(byte[] bytes, Action<GameObject> onLoaded, Action<Exception> onError = null, bool show = true)
		{
			VRMImporterContext context = new VRMImporterContext();
			using (context.MeasureTime("ParseGlb"))
			{
				context.ParseGlb(bytes);
			}
			context.LoadAsync((Action<Unit>)delegate
			{
				if (show)
				{
					context.ShowMeshes();
				}
				onLoaded(context.Root);
			}, onError);
		}

		[Obsolete("use VRMImporterContext.LoadAsync")]
		public static void LoadVrmAsync(VRMImporterContext context, Action<GameObject> onLoaded, Action<Exception> onError = null, bool show = true)
		{
			context.LoadAsync((Action<Unit>)delegate
			{
				if (show)
				{
					context.ShowMeshes();
				}
				onLoaded(context.Root);
			}, onError);
		}

		[Obsolete("use VRMImporterContext.LoadAsync()")]
		public static Task<GameObject> LoadVrmAsync(string path, bool show = true)
		{
			VRMImporterContext vRMImporterContext = new VRMImporterContext();
			vRMImporterContext.ParseGlb(File.ReadAllBytes(path));
			return LoadVrmAsync(vRMImporterContext, show);
		}

		[Obsolete("use VRMImporterContext.LoadAsync()")]
		public static Task<GameObject> LoadVrmAsync(byte[] bytes, bool show = true)
		{
			VRMImporterContext vRMImporterContext = new VRMImporterContext();
			vRMImporterContext.ParseGlb(bytes);
			return LoadVrmAsync(vRMImporterContext, show);
		}

		[Obsolete("use VRMImporterContext.LoadAsync()")]
		public static async Task<GameObject> LoadVrmAsync(VRMImporterContext ctx, bool show = true)
		{
			await ctx.LoadAsyncTask();
			if (show)
			{
				ctx.ShowMeshes();
			}
			return ctx.Root;
		}
	}
}
