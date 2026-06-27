using Restory.Data.NewGame;
using Restory.Data.SaveLoad;
using Restory.Gameplay.Common;
using Restory.Gameplay.Equipment;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class TimeSystemBlockerFromWindowShutters : MonoBehaviour, IPostRestoreComponent, IActiveStateSwitchRequester
	{
		private TimeSystem timeSystem;

		private WindowShuttersStoreInteractiveItem windowShutters;

		[SerializeField]
		private NewGameSettings newGameSettings;

		[Inject]
		public void Construct(TimeSystem timeSystem, WindowShuttersStoreInteractiveItem windowShutters)
		{
			this.windowShutters = windowShutters;
			this.timeSystem = timeSystem;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)windowShutters && timeSystem != null)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (windowShutters.MonoShellExists())
			{
				windowShutters.OnIsOpenStatusChanged -= ResolveWindowShuttersOpenStatusChanged;
			}
		}

		private void Init()
		{
			if (newGameSettings.BlockTimeBeforeFirstWindowOpening)
			{
				timeSystem.BlockTimeSystem(this);
			}
		}

		private void ResolveWindowShuttersOpenStatusChanged()
		{
			windowShutters.OnIsOpenStatusChanged -= ResolveWindowShuttersOpenStatusChanged;
			timeSystem.StopBlockingTimeSystem(this);
		}

		public void PostRestore()
		{
			if (newGameSettings.BlockTimeBeforeFirstWindowOpening)
			{
				if (!windowShutters.WasWindowOpenAtLeastOnce && !windowShutters.IsWindowOpen)
				{
					windowShutters.OnIsOpenStatusChanged += ResolveWindowShuttersOpenStatusChanged;
				}
				else
				{
					timeSystem.StopBlockingTimeSystem(this);
				}
			}
		}
	}
}
