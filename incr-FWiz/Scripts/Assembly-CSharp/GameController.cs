using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Localization;

public class GameController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAutoSaveWithNotification_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAutoSaveWithNotification_003Ed__54(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDoLoad_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameController _003C_003E4__this;

		private bool _003CnewCampaign_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDoLoad_003Ed__48(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private PlaytimeTracker _playtimeTracker;

	[SerializeField]
	private FloorItemsHandler _floorItemsHandler;

	[SerializeField]
	private BuildingsManager _buildingsManager;

	[SerializeField]
	private PipesManager _pipesManager;

	[SerializeField]
	private MovementInputHandler _movementInputHandler;

	[SerializeField]
	private CheckpointHandler _checkpointHandler;

	[SerializeField]
	private UpgradesHandler _upgradesHandler;

	[SerializeField]
	private RecipesHandler _recipesHandler;

	[SerializeField]
	private ItemsDiscoveredHandler _itemDiscoveredHandler;

	[SerializeField]
	private DialogueHandler _dialogueHandler;

	[SerializeField]
	private StoryEventHandlers _storyEventHandlers;

	[SerializeField]
	private PlayerController _playerController;

	[SerializeField]
	private GameCanvasController _gameCanvasController;

	[SerializeField]
	private SceneCanvasController _sceneCanvasController;

	[SerializeField]
	private ES3AutoSaveMgr _autoSaveManager;

	public float AutosaveInterval;

	public float AutosaveTimer;

	public bool DoesSavingAndLoading;

	private static Dictionary<int, Action> _callWhenLoaded;

	public const string WorldMetaDataKey = "WorldMetaData";

	public float FadeToQuitDuration;

	public float LoadEndingBuffer;

	public float FadeInDuration;

	public static Action<bool> AnnounceGameStarted;

	public static Action AnnounceGameExit;

	[SerializeField]
	private LocalizedString _savingText;

	private bool _isSaving;

	private string _activeSavingText;

	public static GameController Instance { get; private set; }

	[field: SerializeField]
	public WorldMetaData WorldMetaData { get; private set; }

	public static bool GameLoaded { get; private set; }

	public static bool GameExiting { get; private set; }

	public static event Action CallOnExiting
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static void OnLoaded(Action action, int order = 0)
	{
	}

	public static void CancelOnLoaded(Action action, int order = 0)
	{
	}

	public static void PrepareForLoad()
	{
	}

	public void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CDoLoad_003Ed__48))]
	public IEnumerator DoLoad()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	public void TryDoAutoSave()
	{
	}

	[IteratorStateMachine(typeof(_003CAutoSaveWithNotification_003Ed__54))]
	private IEnumerator AutoSaveWithNotification()
	{
		return null;
	}

	public void SaveGame()
	{
	}

	public void SaveAndQuit()
	{
	}

	public void Quit()
	{
	}

	public void Quit(string scene)
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void OnApplicationPause(bool paused)
	{
	}

	private void Update()
	{
	}
}
