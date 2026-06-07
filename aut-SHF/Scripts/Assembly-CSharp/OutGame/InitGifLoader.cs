using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Libs;
using UnityEngine;

namespace OutGame
{
	public class InitGifLoader : SingletonMonoBehaviour<InitGifLoader>
	{
		[CompilerGenerated]
		private sealed class _003CAsyncInitLoad_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InitGifLoader _003C_003E4__this;

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
			public _003CAsyncInitLoad_003Ed__7(int _003C_003E1__state)
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

		private Coroutine _coroutine;

		public bool isFinishedGifLoad { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CAsyncInitLoad_003Ed__7))]
		public IEnumerator AsyncInitLoad()
		{
			return null;
		}

		public static void CreateInitGifLoader()
		{
		}

		private new void OnDestroy()
		{
		}
	}
}
