using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StageScript_SanctumOfEnigma : AEndlessModeStageScript
{
	[Serializable]
	public class MechanicPrefabDictionary : SerializableDictionary<eMechanicBlockType, GameObject>
	{
	}

	public class MazeMechanicSet
	{
		public List<eMechanicBlockType> list_MechanicTypes;

		public eMechanicBlockType GetMechanic(eMazeBlockState state)
		{
			return default(eMechanicBlockType);
		}
	}

	public enum eMechanicBlockType
	{
		RUNETRAP_FROST = 0,
		RUNETRAP_FIRE = 1,
		RUNETRAP_HEAL = 2,
		RUNETRAP_SHIELD = 3,
		RUNETRAP_BREAK = 4,
		RUNETRAP_HASTE = 5
	}

	[CompilerGenerated]
	private sealed class _003CCR_ChangeMazeLayout_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

		public int roundIndex;

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
		public _003CCR_ChangeMazeLayout_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CCR_ChooseNewRelic_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

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
		public _003CCR_ChooseNewRelic_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003CCR_ChooseNewRune_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_ChooseNewRune_003Ed__47(int _003C_003E1__state)
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
	private sealed class _003CCR_ChooseNewTowerCard_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_ChooseNewTowerCard_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CCR_ChoosePerks_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_ChoosePerks_003Ed__48(int _003C_003E1__state)
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
	private sealed class _003CCR_ClearField_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

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
		public _003CCR_ClearField_003Ed__38(int _003C_003E1__state)
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
	private sealed class _003CCR_GameEnd_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

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
		public _003CCR_GameEnd_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CCR_Intro_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

		private UI_EnigmaSanctumIntro_Popup _003CwindowIntro_003E5__2;

		private UI_InGameSelectCharacterPopup _003Cwindow_003E5__3;

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
		public _003CCR_Intro_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003CCR_Outro_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_Outro_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CCR_RoundEnd_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

		public int roundIndex;

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
		public _003CCR_RoundEnd_003Ed__37(int _003C_003E1__state)
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
	private sealed class _003CCR_RoundStart_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

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
		public _003CCR_RoundStart_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003CGiveNewSetOfCard_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

		private UnityEngine.Random.State _003CoriginalRandomState_003E5__2;

		private List<eItemType> _003Clist_chosenTowers_003E5__3;

		private int _003Ci_003E5__4;

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
		public _003CGiveNewSetOfCard_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003CTerminateBattle_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageScript_SanctumOfEnigma _003C_003E4__this;

		private List<AMonsterBase> _003Cmonsters_003E5__2;

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
		public _003CTerminateBattle_003Ed__24(int _003C_003E1__state)
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
	private PhotoCameraController photoCameraController;

	[SerializeField]
	private Material mat_SoulMonster;

	[SerializeField]
	private List<Obj_EnigmaSanctumFloorBlock> list_FloorBlocks;

	[SerializeField]
	private List<MazeMechanicSet> list_MechanicSets;

	[SerializeField]
	private MechanicPrefabDictionary dict_MechanicPrefabs;

	private SanctumOfEnigmaMonsterWaveData monsterWaveData;

	private SanctumOfEnigmaMazeData mazeData;

	private int score;

	private int roundScore;

	private int boundSize;

	private int monsterKilled_Small;

	private int monsterKilled_Medium;

	private int monsterKilled_Large;

	private int monsterKilled_Boss;

	private List<int> list_MazeLayoutSelections;

	private List<int> list_WaveDataSelections;

	private float timeInBattle;

	private Color scoreTextColor;

	private List<eItemType> list_GivenTowersInSession;

	private EndlessModeRoundRewardData roundRewardData;

	private bool isChangingMazeLayout;

	private int relicChooseCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Start()
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	[IteratorStateMachine(typeof(_003CTerminateBattle_003Ed__24))]
	private IEnumerator TerminateBattle()
	{
		return null;
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	private void AddScore(int addValue)
	{
	}

	private void OnRoundStart(int currentRound, int totalRound)
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Intro_003Ed__31))]
	public override IEnumerator CR_Intro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_003Ed__32))]
	public override IEnumerator CR_Outro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameEnd_003Ed__33))]
	public override IEnumerator CR_GameEnd(bool isWin)
	{
		return null;
	}

	protected override void UploadScore()
	{
	}

	[IteratorStateMachine(typeof(_003CGiveNewSetOfCard_003Ed__36))]
	private IEnumerator GiveNewSetOfCard()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_RoundEnd_003Ed__37))]
	public override IEnumerator CR_RoundEnd(int roundIndex)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ClearField_003Ed__38))]
	private IEnumerator CR_ClearField()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_RoundStart_003Ed__40))]
	public override IEnumerator CR_RoundStart(int roundIndex)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeMazeLayout_003Ed__42))]
	private IEnumerator CR_ChangeMazeLayout(int roundIndex)
	{
		return null;
	}

	private GameObject GetMechanicPrefab(eMechanicBlockType type)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChooseNewTowerCard_003Ed__44))]
	private IEnumerator CR_ChooseNewTowerCard(int roundIndex)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChooseNewRelic_003Ed__46))]
	private IEnumerator CR_ChooseNewRelic()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChooseNewRune_003Ed__47))]
	private IEnumerator CR_ChooseNewRune()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChoosePerks_003Ed__48))]
	private IEnumerator CR_ChoosePerks()
	{
		return null;
	}

	private void SetupBlocks()
	{
	}
}
