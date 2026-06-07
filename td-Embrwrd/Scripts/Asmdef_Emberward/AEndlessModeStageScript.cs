using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public abstract class AEndlessModeStageScript : AStageScript
{
	[CompilerGenerated]
	private sealed class _003CCR_GameEnd_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AEndlessModeStageScript _003C_003E4__this;

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
		public _003CCR_GameEnd_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CCR_Intro_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AEndlessModeStageScript _003C_003E4__this;

		private UI_InGameSelectCharacterPopup _003Cwindow_003E5__2;

		private UI_TetrisDraft_Popup _003CtetrisSelectwindow_003E5__3;

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
		public _003CCR_Intro_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CCR_Outro_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_Outro_003Ed__24(int _003C_003E1__state)
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

	protected bool isTowerAcquisitionStopped;

	protected bool doUploadScoreEvery5Rounds;

	protected int monsterOneShotCount;

	protected int monsterKilledCount;

	protected int dmgFromMonster;

	protected int zeroDmgCount;

	protected int coinGain;

	protected int coinSpent;

	protected int maxCoinGain;

	protected int roundSpent;

	private void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	private void OnRoundStart(int currentRound, int totalRound)
	{
	}

	private void OnMonsterHit(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	private void OnRequestStopTowerAcquisitionInEndlessMode()
	{
	}

	private void OnRequestAddCoin(int delta)
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Intro_003Ed__22))]
	public override IEnumerator CR_Intro()
	{
		return null;
	}

	private void OnTetrisCardDraftComplete(List<TetrisCardData> list_SelectedCards)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_003Ed__24))]
	public override IEnumerator CR_Outro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameEnd_003Ed__25))]
	public override IEnumerator CR_GameEnd(bool isWin)
	{
		return null;
	}

	protected abstract void UploadScore();
}
