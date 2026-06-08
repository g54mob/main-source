using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Dorfromantik;
using Dorfromantik.CreativeMode;
using UnityEngine;

public class AutoSaver : MonoBehaviour
{
	private sealed class _003CAutoSaveInSetIntervals_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoSaver _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CAutoSaveInSetIntervals_003Ed__19(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			AutoSaver autoSaver = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				Debug.Log("Autosave initiated after 10min");
				autoSaver.AutoSave();
			}
			else
			{
				_003C_003E1__state = -1;
			}
			_003C_003E2__current = new WaitForSeconds(600f);
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private bool autoLoad = true;

	[SerializeField]
	private bool autoSave = true;

	[SerializeField]
	private float unloadResourcesMinInterval = 600f;

	[SerializeField]
	private SaveLoadSystem saveLoadSystem;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private SaveFileManager saveFileManager;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private CreativeModeConfiguration creativeModeConfiguration;

	[SerializeField]
	private TileStack tileStack;

	private bool validSaveGame;

	private float lastUnloadTime;

	private void Awake()
	{
		tileStack.OnInitialized += AutoLoad;
		inputRouter.OnToggleMenu += AutoSaveFromToggleMenu;
		rewardSystem.OnGameOver += AutoSaveFromGameOver;
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += ValidateSaveGameFromTilePlaced;
		inputRouter.OnUndo += ValidateSaveGame;
		if ((bool)creativeModeConfiguration)
		{
			creativeModeConfiguration.OnGroupTypeProbabilitiesUpdated += ValidateSaveGameFromConfigurationChange;
			creativeModeConfiguration.OnExcludedBiomesUpdated += ValidateSaveGameFromConfigurationChange;
			inputRouter.OnDiscardCurrentTile += ValidateSaveGameFromDiscarded;
			inputRouter.OnDeleteTile += ValidateSaveGameFromDestroyedTile;
		}
		StartCoroutine(AutoSaveInSetIntervals());
		lastUnloadTime = Time.time;
	}

	private void AutoSaveFromToggleMenu()
	{
		AutoSave();
	}

	private void AutoSaveFromSwitchExitRequest()
	{
		Debug.Log("Autosave from Switch Exit Request");
		AutoSave(calledOnQuit: true);
	}

	private void ValidateSaveGameFromConfigurationChange(bool initial)
	{
		if (!initial)
		{
			ValidateSaveGame();
		}
	}

	private void AutoSaveFromGameOver(bool animate, bool setHighscore)
	{
		if (animate)
		{
			AutoSave();
		}
	}

	private IEnumerator AutoSaveInSetIntervals()
	{
		return new _003CAutoSaveInSetIntervals_003Ed__19(0)
		{
			_003C_003E4__this = this
		};
	}

	private void ValidateSaveGameFromDestroyedTile(Tile destroyedTile)
	{
		ValidateSaveGame();
	}

	private void ValidateSaveGameFromDiscarded(bool refillStack, bool initial)
	{
		if (!initial)
		{
			ValidateSaveGame();
		}
	}

	private void ValidateSaveGameFromTilePlaced(Tile placedTile, bool isPlacedByPlayer)
	{
		if (!placedTile.IsInitialTile && isPlacedByPlayer)
		{
			ValidateSaveGame();
		}
	}

	private void ValidateSaveGame()
	{
		validSaveGame = true;
	}

	private void OnApplicationQuit()
	{
		AutoSave();
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			AutoSave();
		}
	}

	private void AutoLoad()
	{
		if (autoLoad)
		{
			saveLoadSystem.LoadSaveGame(saveFileManager.ActiveSaveGame);
			if (saveFileManager.ActiveSaveGame.HasSaveFile && !saveFileManager.ActiveSaveGame.HasScreenshot)
			{
				ValidateSaveGame();
			}
		}
		else
		{
			saveLoadSystem.SetupNewGame();
		}
	}

	private void AutoSave(bool calledOnQuit = false)
	{
		if (autoSave && validSaveGame)
		{
			validSaveGame = false;
			if (!calledOnQuit)
			{
				Singleton<MainMenuUi>.Instance.ShowSavingLabel();
			}
			Debug.Log($"Resource Unload? {Time.time > lastUnloadTime + unloadResourcesMinInterval} - Time.time: {Time.time} > lastUnloadTime: {lastUnloadTime} + interval: {unloadResourcesMinInterval}");
			if (!calledOnQuit && Time.time > lastUnloadTime + unloadResourcesMinInterval)
			{
				Resources.UnloadUnusedAssets();
				lastUnloadTime = Time.time;
			}
			saveLoadSystem.SaveActiveGame();
		}
	}

	private void OnDestroy()
	{
		inputRouter.OnToggleMenu -= AutoSaveFromToggleMenu;
		tileStack.OnInitialized -= AutoLoad;
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ValidateSaveGameFromTilePlaced;
		inputRouter.OnUndo -= ValidateSaveGame;
		rewardSystem.OnGameOver -= AutoSaveFromGameOver;
		if ((bool)creativeModeConfiguration)
		{
			creativeModeConfiguration.OnGroupTypeProbabilitiesUpdated -= ValidateSaveGameFromConfigurationChange;
			creativeModeConfiguration.OnExcludedBiomesUpdated -= ValidateSaveGameFromConfigurationChange;
			inputRouter.OnDiscardCurrentTile -= ValidateSaveGameFromDiscarded;
			inputRouter.OnDeleteTile -= ValidateSaveGameFromDestroyedTile;
		}
	}
}
