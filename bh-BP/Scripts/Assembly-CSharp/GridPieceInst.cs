using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class GridPieceInst
{
	[CompilerGenerated]
	private sealed class _003CGetAbovePieces_003Ed__50 : IEnumerable<GridPieceInst>, IEnumerable, IEnumerator<GridPieceInst>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GridPieceInst _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public GridPieceInst _003C_003E4__this;

		private GridPieceInst _003Cp_003E5__2;

		GridPieceInst IEnumerator<GridPieceInst>.Current
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
		public _003CGetAbovePieces_003Ed__50(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<GridPieceInst> IEnumerable<GridPieceInst>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetBelowPieces_003Ed__51 : IEnumerable<GridPieceInst>, IEnumerable, IEnumerator<GridPieceInst>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GridPieceInst _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public GridPieceInst _003C_003E4__this;

		private GridPieceInst _003Cp_003E5__2;

		GridPieceInst IEnumerator<GridPieceInst>.Current
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
		public _003CGetBelowPieces_003Ed__51(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<GridPieceInst> IEnumerable<GridPieceInst>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public GridPieceType Type;

	public int ChildIdx;

	public int SpawnTurn;

	public float X;

	public float Y;

	public float CurSpeed;

	public float MaxSpeed;

	public int CurHealth;

	public int MaxHealth;

	public int RemainingXP;

	public int XPVal;

	public PieceState CurState;

	public int ExtraNum;

	public bool IsFlippedX;

	public bool IsFlippedY;

	public List<StatusEffect> StatusEffects;

	public int StatusEffectHash;

	public int StackSize;

	public int StackPos;

	[NonSerialized]
	public GridPieceInst AbovePiece;

	[NonSerialized]
	public GridPieceInst BelowPiece;

	[NonSerialized]
	public GridPieceObj Obj;

	public Vector2 GridPos
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	public GridPieceInst(GridPieceType type, float x, float y, int numTurns, float moveSpeed)
	{
	}

	public void InitChild(int idx)
	{
	}

	public void SetMaxHealth(int h)
	{
	}

	public void SetState(PieceState st)
	{
	}

	public bool CanBeDamaged()
	{
		return false;
	}

	public void InstantKill(bool force = false)
	{
	}

	public bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	private void OnKilled()
	{
	}

	public void Heal(int amt)
	{
	}

	public int GetTouchDamage()
	{
		return 0;
	}

	public int GetMeleeDamage()
	{
		return 0;
	}

	public int GetArrowDamage()
	{
		return 0;
	}

	public int CalculateXPValue()
	{
		return 0;
	}

	public int GetGoldValue(System.Random rnd)
	{
		return 0;
	}

	public void ApplyStatusEffect(StatusEffect ef, HeroInst src)
	{
	}

	public void RemoveStatusEffect(int idx)
	{
	}

	public bool IsFrozen()
	{
		return false;
	}

	public bool HasStatusEffect(StatusEffectType t)
	{
		return false;
	}

	public StatusEffect GetStatusEffect(StatusEffectType t)
	{
		return null;
	}

	public int GetStatusEffectIdx(StatusEffectType t)
	{
		return 0;
	}

	public override string ToString()
	{
		return null;
	}

	public GridPieceInfo GetInfo()
	{
		return null;
	}

	public int GetStackTopHeight()
	{
		return 0;
	}

	public GridPieceInst GetStackTop()
	{
		return null;
	}

	public GridPieceInst GetStackBot()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetAbovePieces_003Ed__50))]
	public IEnumerable<GridPieceInst> GetAbovePieces()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetBelowPieces_003Ed__51))]
	public IEnumerable<GridPieceInst> GetBelowPieces()
	{
		return null;
	}

	public bool IsChild()
	{
		return false;
	}

	public void SetHealthMult(float mult)
	{
	}

	public void RefreshStatusEffectHash()
	{
	}

	public int GetStatusEffectHash()
	{
		return 0;
	}
}
