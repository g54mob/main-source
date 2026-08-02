using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace Rhizomatic.ServiceSystem.Sample
{
	public class SampleAdManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CIShow_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SampleAdManager _003C_003E4__this;

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
			public _003CIShow_003Ed__8(int _003C_003E1__state)
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

		public VideoPlayer videoPlayer;

		public GameObject panel;

		public GameObject loading;

		public GameObject display;

		public UnityAction reward;

		public UnityAction error;

		private void Awake()
		{
		}

		public void Show()
		{
		}

		[IteratorStateMachine(typeof(_003CIShow_003Ed__8))]
		private IEnumerator IShow()
		{
			return null;
		}

		public void Reward()
		{
		}

		public void Skip()
		{
		}
	}
}
