using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class QueueRunner : SelfInstancingMonoSingleton<QueueRunner>
	{
		[CompilerGenerated]
		private sealed class _003CRun_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QueueRunner _003C_003E4__this;

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
			public _003CRun_003Ed__3(int _003C_003E1__state)
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

		private List<Action> sequences;

		private Coroutine coroutine;

		public void Add(Action sequence)
		{
		}

		[IteratorStateMachine(typeof(_003CRun_003Ed__3))]
		private IEnumerator Run()
		{
			return null;
		}

		public void AddSpriteCreation(Texture2D texture, Action<Sprite> onConversion)
		{
		}

		private static Sprite TextureToSprite(Texture2D texture)
		{
			return null;
		}
	}
}
