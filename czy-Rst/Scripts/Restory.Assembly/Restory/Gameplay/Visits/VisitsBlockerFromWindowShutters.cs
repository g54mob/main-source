using System;
using System.Collections;
using Restory.Data.NPCs;
using Restory.Gameplay.Common;
using Restory.Gameplay.Equipment;
using Restory.Infrastructure.ProjectServices;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Visits
{
	public class VisitsBlockerFromWindowShutters : IInitializable, IDisposable, IActiveStateSwitchRequester
	{
		private readonly CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private readonly WindowShuttersStoreInteractiveItem windowShutters;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly CurrentDayVisitsSettings settings;

		private Coroutine doCallbackAfterDelayCoroutine;

		public VisitsBlockerFromWindowShutters(CurrentDayVisitsQueueService currentDayVisitsQueueService, WindowShuttersStoreInteractiveItem windowShutters, ICoroutineRunner coroutineRunner, CurrentDayVisitsSettings settings)
		{
			this.coroutineRunner = coroutineRunner;
			this.windowShutters = windowShutters;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
			this.settings = settings;
		}

		public void Initialize()
		{
			ResolveWindowOpenStatusChanged();
			windowShutters.OnIsOpenStatusChanged += ResolveWindowOpenStatusChanged;
		}

		public void Dispose()
		{
			if (windowShutters != null)
			{
				windowShutters.OnIsOpenStatusChanged += ResolveWindowOpenStatusChanged;
			}
			if (doCallbackAfterDelayCoroutine != null)
			{
				coroutineRunner?.Stop(doCallbackAfterDelayCoroutine);
				doCallbackAfterDelayCoroutine = null;
			}
		}

		private void ResolveWindowOpenStatusChanged()
		{
			if (doCallbackAfterDelayCoroutine != null)
			{
				coroutineRunner.Stop(doCallbackAfterDelayCoroutine);
			}
			if (windowShutters.IsWindowOpen)
			{
				doCallbackAfterDelayCoroutine = coroutineRunner.Run(DoCallbackAfterDelayCoroutine(delegate
				{
					if (windowShutters.IsWindowOpen)
					{
						currentDayVisitsQueueService.UnblockVisits(this);
					}
				}));
			}
			else
			{
				currentDayVisitsQueueService.BlockVisits(this);
			}
		}

		private IEnumerator DoCallbackAfterDelayCoroutine(Action callback)
		{
			yield return new WaitForSeconds(settings.DelayAfterWindowOpensBeforeUnblockingVisits);
			doCallbackAfterDelayCoroutine = null;
			callback?.Invoke();
		}
	}
}
