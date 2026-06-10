using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace Controller
{
	public class GameplayPauseManager : MonoSingleton<GameplayPauseManager>
	{
		private readonly HashSet<IPauseGame> pauseGameObjects = new HashSet<IPauseGame>();

		private bool DoAction => pauseGameObjects.Count == 0;

		public event Action PauseEvent;

		public event Action UnpauseEvent;

		public void ForcePause()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Force Pause. Registered object count: ");
				messageBuilder.AppendFormatted(pauseGameObjects.Count);
			}
			Log.Debug(messageBuilder);
			this.PauseEvent?.Invoke();
		}

		public void ForceUnpause()
		{
			this.UnpauseEvent?.Invoke();
			pauseGameObjects.Clear();
		}

		public void ReleaseSilently(IPauseGame pauseGameObject)
		{
			if (pauseGameObjects.Contains(pauseGameObject))
			{
				pauseGameObjects.Remove(pauseGameObject);
			}
		}

		public void Register(IPauseGame pauseGameObject)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(46, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Registering pause game object: ");
				messageBuilder.AppendFormatted(pauseGameObject.GetType());
				messageBuilder.AppendLiteral(" Object count: ");
				messageBuilder.AppendFormatted(pauseGameObjects.Count);
			}
			Log.Debug(messageBuilder);
			if (DoAction)
			{
				Log.Trace("PauseEvent", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
				this.PauseEvent?.Invoke();
			}
			if (!pauseGameObjects.Add(pauseGameObject))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(94, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Something went wrong while adding ");
					messageBuilder2.AppendFormatted(pauseGameObject);
					messageBuilder2.AppendLiteral(" to the pause game objects list. It probably already exists.");
				}
				Log.Error(messageBuilder2);
			}
		}

		public void Unregister(IPauseGame pauseGameObject)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Unregistering pause game object: ");
				messageBuilder.AppendFormatted(pauseGameObject.GetType());
				messageBuilder.AppendLiteral(" Object count: ");
				messageBuilder.AppendFormatted(pauseGameObjects.Count);
			}
			Log.Debug(messageBuilder);
			if (!pauseGameObjects.Remove(pauseGameObject))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(97, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Something went wrong while removing ");
					messageBuilder2.AppendFormatted(pauseGameObject);
					messageBuilder2.AppendLiteral(" from the pause game objects list. It probably doesn't exist.");
				}
				Log.Error(messageBuilder2);
			}
			if (DoAction)
			{
				Log.Trace("UnPauseEvent", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\GameplayPauseManager.cs");
				this.UnpauseEvent?.Invoke();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.PauseEvent = null;
			this.UnpauseEvent = null;
			pauseGameObjects?.Clear();
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnMainSceneLoaded;
			}
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
		}

		private void OnMainSceneLoaded()
		{
			pauseGameObjects.Clear();
		}
	}
}
