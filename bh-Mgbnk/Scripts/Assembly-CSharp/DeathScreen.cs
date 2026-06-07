using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoTransition_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DeathScreen _003C_003E4__this;

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
		public _003CDoTransition_003Ed__29(int _003C_003E1__state)
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

	public DeathScreenBlocksUI blocksUi;

	public GameObject deadUiWindow;

	public GameObject statsWindow;

	public GameObject background;

	public GameObject leaderboardsWindow;

	public GameObject victoryScreen;

	public UiAnimation t_dead;

	public UiAnimation b_continue;

	public AudioSource audio;

	public RawImage playerOnlyRender;

	public CanvasGroup canvasGroup;

	private float fadeInTime;

	private float fadeTimer;

	private bool hasNewRecord;

	private bool tierVictory;

	public GameObject restartBtn;

	public int newRecordRank { get; private set; }

	public string newRecordLbName { get; private set; }

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLeaderboardScoreUploaded(string lbName, int rank)
	{
	}

	private void OnBossDefeated(bool canSpawnPortal)
	{
	}

	public void PlayAudio()
	{
	}

	public void StartDeathScreen()
	{
	}

	[IteratorStateMachine(typeof(_003CDoTransition_003Ed__29))]
	private IEnumerator DoTransition()
	{
		return null;
	}

	private void Update()
	{
	}

	public void ShowLeaderboard()
	{
	}

	public void HideVictoryScreen()
	{
	}

	public void ShowStats()
	{
	}

	public void GoToMenu()
	{
	}

	public void Restart()
	{
	}
}
