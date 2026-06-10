using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;
using Utils;

namespace NSEipix.Base
{
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		[NonSerialized]
		private static T instance;

		[NonSerialized]
		private static bool instanceInitialized;

		private static bool applicationIsQuitting = false;

		private static readonly object Padlock = new object();

		private bool delete;

		public static T Instance
		{
			get
			{
				lock (Padlock)
				{
					if (!instanceInitialized)
					{
						instance = UnityEngine.Object.FindObjectOfType<T>();
						instanceInitialized = true;
						if (instance != null)
						{
							return instance;
						}
						if (applicationIsQuitting)
						{
							return null;
						}
						throw new Exception("Singleton not instantiated. Please add " + typeof(T).Name + " as a script to a GameObject.");
					}
					return instance;
				}
			}
		}

		public static void OnDomainReload()
		{
			if (instance != null)
			{
				UnityEngine.Object.DestroyImmediate(instance);
				instance = null;
			}
			instanceInitialized = false;
			applicationIsQuitting = false;
		}

		public MonoSingleton()
		{
			lock (Padlock)
			{
				if (instanceInitialized)
				{
					delete = true;
					return;
				}
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Base\\MonoSingleton.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating Singleton ");
				messageBuilder.AppendFormatted(GetType().Name);
			}
			Log.Trace(messageBuilder);
			DomainReloadHelper.OnDomainReloadEvent = (Action)Delegate.Combine(DomainReloadHelper.OnDomainReloadEvent, new Action(OnDomainReload));
		}

		public static void DevForceInstantiate()
		{
			if (IsInstantiated())
			{
				return;
			}
			lock (Padlock)
			{
				GameObject obj = new GameObject();
				instance = obj.AddComponent<T>();
				instanceInitialized = true;
				obj.name = $"(Singleton) {typeof(T).ToString()}";
				Log.Trace(obj.name + ", was created at: \n" + Environment.StackTrace, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Base\\MonoSingleton.cs");
			}
		}

		public static bool IsApplicationIsQuitting()
		{
			return applicationIsQuitting;
		}

		public static bool IsInstantiated()
		{
			lock (Padlock)
			{
				return instance != null && !applicationIsQuitting;
			}
		}

		protected virtual void Awake()
		{
			if (delete)
			{
				UnityEngine.Object.DestroyImmediate(this);
				return;
			}
			lock (Padlock)
			{
				if (!instanceInitialized)
				{
					instance = GetComponent<T>();
					instanceInitialized = true;
				}
			}
		}

		protected virtual void OnApplicationQuit()
		{
			applicationIsQuitting = true;
		}

		protected virtual void OnDestroy()
		{
			lock (Padlock)
			{
				if (instance == this)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Base\\MonoSingleton.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Destroying Singleton ");
						messageBuilder.AppendFormatted(GetType().Name);
					}
					Log.Trace(messageBuilder);
					instance = null;
					instanceInitialized = false;
				}
			}
		}
	}
}
