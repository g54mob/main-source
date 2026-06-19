using System;
using System.Reflection;

namespace MonoMod.Utils
{
	public static class GCListener
	{
		private sealed class CollectionDummy
		{
			~CollectionDummy()
			{
				Unloading |= AppDomain.CurrentDomain.IsFinalizingForUnload() || Environment.HasShutdownStarted;
				if (!Unloading)
				{
					GC.ReRegisterForFinalize(this);
				}
				GCListener.OnCollect?.Invoke();
			}
		}

		private static bool Unloading;

		public static event Action OnCollect;

		static GCListener()
		{
			new CollectionDummy();
			Type type = typeof(Assembly).GetTypeInfo().Assembly.GetType("System.Runtime.Loader.AssemblyLoadContext");
			if (type != null)
			{
				object target = type.GetMethod("GetLoadContext").Invoke(null, new object[1] { typeof(GCListener).Assembly });
				EventInfo eventInfo = type.GetEvent("Unloading");
				eventInfo.AddEventHandler(target, Delegate.CreateDelegate(eventInfo.EventHandlerType, typeof(GCListener).GetMethod("UnloadingALC", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(type)));
			}
		}

		private static void UnloadingALC<T>(T alc)
		{
			Unloading = true;
		}
	}
}
