using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class TwitchVoteUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_RunPollComplete_003Ed__19 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TwitchVoteUI _003C_003E4__this;

		public List<PollResult> results;

		public int totalVotes;

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
		public _003C_RunPollComplete_003Ed__19(int _003C_003E1__state)
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

	public static TwitchVoteUI I;

	public TwitchVoteCharItem[] CharOptions;

	public CoolButton BtnClose;

	public TwitchVoteBtn BtnVote;

	private List<CharInfo> _curOptions;

	private bool _isPollAnimating;

	private bool _pollComplete;

	private bool _isAwaitingPoll;

	private bool _votedToday;

	private CharInfo _voteWinner;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	public override void Deactivate()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	private void OnCancelClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnVoteClicked()
	{
	}

	private void OnCloseClicked()
	{
	}

	private void OnPollClosed(List<PollResult> results, int totalVotes)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunPollComplete_003Ed__19))]
	private IEnumerator<float> _RunPollComplete(List<PollResult> results, int totalVotes)
	{
		return null;
	}

	public override bool IsAnimating()
	{
		return false;
	}

	private int GetOptionIdxFromSlug(string slug)
	{
		return 0;
	}
}
