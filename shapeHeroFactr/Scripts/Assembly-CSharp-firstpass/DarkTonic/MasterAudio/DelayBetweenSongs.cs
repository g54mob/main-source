using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public class DelayBetweenSongs : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPlaySongWithDelay_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DelayBetweenSongs _003C_003E4__this;

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
			public _003CPlaySongWithDelay_003Ed__7(int _003C_003E1__state)
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

		public float minTimeToWait;

		public float maxTimeToWait;

		public string playlistControllerName;

		private PlaylistController _controller;

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void SongEnded(string songName)
		{
		}

		[IteratorStateMachine(typeof(_003CPlaySongWithDelay_003Ed__7))]
		private IEnumerator PlaySongWithDelay()
		{
			return null;
		}
	}
}
