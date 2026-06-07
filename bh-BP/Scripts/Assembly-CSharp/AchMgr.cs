using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AchMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_CheckEncyclopediaAch_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AchMgr _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003Cj_003E5__3;

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
		public _003C_CheckEncyclopediaAch_003Ed__10(int _003C_003E1__state)
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

	public static AchMgr I;

	public static readonly string[] AchIds;

	public bool[] EarnedAch;

	private void Awake()
	{
	}

	public bool IsEarned(AchType ach)
	{
		return false;
	}

	public bool ShouldCheckAch(AchType ach)
	{
		return false;
	}

	public void Earn(AchType ach)
	{
	}

	public void ClearAchievement(AchType a)
	{
	}

	public void ClearAllAchievements()
	{
	}

	public void CheckEncyclopediaAch()
	{
	}

	[IteratorStateMachine(typeof(_003C_CheckEncyclopediaAch_003Ed__10))]
	private IEnumerator _CheckEncyclopediaAch()
	{
		return null;
	}

	public void Check50BlueprintsAch()
	{
	}
}
