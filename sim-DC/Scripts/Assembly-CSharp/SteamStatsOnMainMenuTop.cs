using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Steamworks;
using TMPro;
using UnityEngine;

public class SteamStatsOnMainMenuTop : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitAndDisplay_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SteamStatsOnMainMenuTop _003C_003E4__this;

		private float _003Ctimeout_003E5__2;

		private float _003Celapsed_003E5__3;

		private float _003CyourCableLength_003E5__4;

		private bool _003CstatReady_003E5__5;

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
		public _003CWaitAndDisplay_003Ed__5(int _003C_003E1__state)
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

	private TextMeshProUGUI m_TextMeshProUGUI;

	private CallResult<GlobalStatsReceived_t> m_globalStatsResult;

	private bool m_globalStatsReady;

	private double m_globalCableLength;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitAndDisplay_003Ed__5))]
	private IEnumerator WaitAndDisplay()
	{
		return null;
	}

	private void OnGlobalStatsReceived(GlobalStatsReceived_t result, bool ioFailure)
	{
	}

	private string FormatDistance(double meters)
	{
		return null;
	}
}
