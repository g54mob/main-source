using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinPage : MonoBehaviour
{
	[Serializable]
	public class BackgroundSettings
	{
		public eBackGroundType backgroundType;

		public GameObject sceneObject;

		public Material sceneFogMaterial;
	}

	public enum eBackGroundType
	{
		DEFAULT = 0,
		WORLD_1 = 1,
		WORLD_1_V2 = 2,
		WORLD_2 = 3,
		WORLD_2_V2 = 4,
		WORLD_3 = 5,
		WORLD_3_V2 = 6,
		WORLD_4 = 7,
		WORLD_4_V2 = 8,
		HALLOWEEN = 9,
		XMAS = 10
	}

	[Serializable]
	private class TimeResult
	{
		public long timestamp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public CoinPage _003C_003E4__this;

		public bool isNewGame;

		public UI_DifficultySelection_Popup.eSelectedResult result;

		public eGameDifficultyType difficultyType;

		public UI_DifficultySelection_Popup difficultySelectionWindow;

		internal void _003CCR_StartGame_003Eb__0(UI_DifficultySelection_Popup.eSelectedResult selectedResult)
		{
		}

		internal bool _003CCR_StartGame_003Eb__1()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_3
	{
		public bool isWorldSelected;

		public UI_SelectWorld_Popup selectWorldWindow;

		public _003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals1;

		internal void _003CCR_StartGame_003Eb__4(eWorldType selectedWorldType, HardModeSetting hardModeSetting, bool isCustomGame)
		{
		}

		internal bool _003CCR_StartGame_003Eb__5()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_StartEndlessMode_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string sceneName;

		public int seed;

		public List<PerkSettingData> anomalyList;

		public eEndlessModeType endlessModeType;

		public string leaderboardName;

		public eCharacterType characterType;

		public eEmberType emberType;

		public List<eItemType> towers;

		public List<eItemType> tetris;

		public List<eItemType> relics;

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
		public _003CCR_StartEndlessMode_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003CCR_StartGame_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CoinPage _003C_003E4__this;

		public bool isNewGame;

		private _003C_003Ec__DisplayClass43_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass43_3 _003C_003E8__2;

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
		public _003CCR_StartGame_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003CCR_StartQuickPlay_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string sceneName;

		public eCharacterType characterType;

		public eEmberType emberType;

		public List<eItemType> towers;

		public List<eItemType> tetris;

		public List<eItemType> relics;

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
		public _003CCR_StartQuickPlay_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003CCR_UnlockProcess_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_UnlockProcess_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CStart_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CoinPage _003C_003E4__this;

		private UI_WelcomeToDemo_Popup _003Cwindow_003E5__2;

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
		public _003CStart_003Ed__30(int _003C_003E1__state)
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
	private Image image_Logo_DemoTag;

	[SerializeField]
	private Image image_Logo_BetaTag;

	[SerializeField]
	private Button button_StartGame;

	[SerializeField]
	private Button button_Continue;

	[SerializeField]
	private TMP_Text text_ContinueProgress;

	[SerializeField]
	private Button button_Talents;

	[SerializeField]
	private Button button_Options;

	[SerializeField]
	private Button button_Wishlist;

	[SerializeField]
	private Button button_Exit;

	[SerializeField]
	private TMP_Text text_Talents;

	[SerializeField]
	private Button button_CopySaveFile;

	[SerializeField]
	private GameObject obj_Scene_Normal;

	[SerializeField]
	private GameObject obj_Scene_Halloween;

	[SerializeField]
	private GameObject obj_Scene_World4;

	[SerializeField]
	private Material mat_SceneFog_Common;

	[SerializeField]
	private GraphicRaycaster graphicRaycaster_Canvas;

	[SerializeField]
	private List<BackgroundSettings> backgroundSettingsList;

	private bool isButtonClicked;

	private bool isInitialized;

	private bool canContinue;

	private GameObject lastSelectedGameObject;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void OnRequestActivateEndlessMode(EndlessMapActivateData data)
	{
	}

	private void Awake()
	{
	}

	private void OnTimeReady(DateTime time)
	{
	}

	public void SwitchBackground(eBackGroundType type)
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__30))]
	private IEnumerator Start()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void UpdateContinueInfo()
	{
	}

	private void Update()
	{
	}

	private void OnClick_StartGame()
	{
	}

	private void OnClick_Talents()
	{
	}

	private void OnClick_Continue()
	{
	}

	private void OnClick_Stats()
	{
	}

	private void OnClick_Wishlist()
	{
	}

	private void OnClick_Options()
	{
	}

	private void OnClick_Exit()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_StartGame_003Ed__43))]
	private IEnumerator CR_StartGame(bool isNewGame)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_UnlockProcess_003Ed__44))]
	private IEnumerator CR_UnlockProcess(bool checkCharacter, bool checkEmber)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_StartQuickPlay_003Ed__45))]
	private IEnumerator CR_StartQuickPlay(string sceneName, eCharacterType characterType, eEmberType emberType, List<eItemType> towers, List<eItemType> tetris, List<eItemType> relics)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_StartEndlessMode_003Ed__46))]
	private IEnumerator CR_StartEndlessMode(int seed, string sceneName, string leaderboardName, eEndlessModeType endlessModeType, eCharacterType characterType, eEmberType emberType, List<eItemType> towers, List<eItemType> tetris, List<eItemType> relics, List<PerkSettingData> anomalyList)
	{
		return null;
	}
}
