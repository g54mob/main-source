using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameCheatMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_BallCrash_003Ed__58 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		private int _003CcurNum_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_BallCrash_003Ed__58(int _003C_003E1__state)
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
	private sealed class _003C_SpamBalls_003Ed__57 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		private int _003CcurNum_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_SpamBalls_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003C_TestAllCombos_003Ed__56 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		private int _003Ci_003E5__2;

		private HeroInst _003Ch1Inst_003E5__3;

		private int _003Cj_003E5__4;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_TestAllCombos_003Ed__56(int _003C_003E1__state)
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

	public static GameCheatMgr I;

	public LevelType EditorLevelType;

	public bool AllowEditorChar;

	public CharType EditorChar;

	public bool AllowEditorCharCombo;

	public List<CharType> EditorCharCombos;

	public bool IsGodMode;

	public bool IsBallCrashing;

	public bool UnkillableEnemies;

	public bool OneHitKills;

	public bool DebugShowTut;

	public int EditorDifficulty;

	public bool LoadSaveOnStart;

	public bool SaveOnExitPlayMode;

	[Header("Starters")]
	public bool AllowEditorStarter;

	public HeroType EditorStarterHero;

	public bool AllowEditorStarterCombo;

	public HeroType EditorStarterBallCombo;

	public bool AllowEditorStarterPassive;

	public List<PassiveType> EditorStarterPassive;

	public bool AllowEditorStarterPets;

	public List<PetType> EditorStarterPets;

	[Header("Level Gen")]
	public bool AllowEditorGridPiece;

	public List<GridPieceType> EditorGridPieces;

	public bool LimitEditorGridPiece;

	public bool AbundantPickups;

	public PickupType AbundantPickupType;

	public int EditorStackSize;

	public bool AllowEditorSeed;

	public int EditorSeed;

	public bool StopEnemySpawning;

	public bool DisableAllPickups;

	[Header("Ball Boosts")]
	public bool AlwaysFreeze;

	public bool AlwaysBirth;

	public bool AlwaysLifesteal;

	public bool AlwaysCharm;

	public bool AlwaysDodge;

	[Header("Misc Stuff")]
	public bool DisableLevelUp;

	public bool DebugGameCompletion;

	public int GameCompletionProgress;

	[Header("Automated Testing")]
	public static bool Autoplay;

	public static int sAutoTestSeed;

	public static int sCurTestNumAtSeed;

	public int TestsPerSeed;

	public bool EnableAutoTesting;

	public GameSpeed TestSpeed;

	public static List<AutoTestResult> TestResults;

	public bool ForceLeaderboardSubmission;

	private TextMeshProUGUI _debugTxt;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void MyUpdate()
	{
	}

	private void UseUpExtraXP()
	{
	}

	private void MaxOutItems()
	{
	}

	public void LogAutoTest()
	{
	}

	private void OnDestroy()
	{
	}

	public void ApplyCheat(GameCheatType t)
	{
	}

	[IteratorStateMachine(typeof(_003C_TestAllCombos_003Ed__56))]
	private IEnumerator<float> _TestAllCombos()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_SpamBalls_003Ed__57))]
	private IEnumerator<float> _SpamBalls()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_BallCrash_003Ed__58))]
	private IEnumerator<float> _BallCrash()
	{
		return null;
	}

	public void CreateDebugText(string str)
	{
	}

	public void ClearDebugText()
	{
	}

	public void TestCharCombos(CharType ct)
	{
	}
}
