using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class StatsUi : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedRebuild_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StatsUi _003C_003E4__this;

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
		public _003CDelayedRebuild_003Ed__10(int _003C_003E1__state)
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

	public Transform rootTransformToRefresh;

	public GameObject entryPrefab;

	public GameObject spacerPrefab;

	private List<StatEntry> entries;

	private int[] spacers;

	private List<EStat> statsToShow;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnStatUpdate(EStat stat)
	{
	}

	private void TryInit()
	{
	}

	private void Refresh()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedRebuild_003Ed__10))]
	private IEnumerator DelayedRebuild()
	{
		return null;
	}

	public static string FormatStat(EStat stat, float value)
	{
		return null;
	}
}
