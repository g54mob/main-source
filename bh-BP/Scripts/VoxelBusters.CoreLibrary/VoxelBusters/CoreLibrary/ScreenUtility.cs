using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class ScreenUtility : PrivateSingletonBehaviour<ScreenUtility>
	{
		[CompilerGenerated]
		private sealed class _003CCaptureFrameRoutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ScreenUtility _003C_003E4__this;

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
			public _003CCaptureFrameRoutine_003Ed__4(int _003C_003E1__state)
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

		private bool m_captureFrame;

		private Callback<Texture2D> m_callback;

		public static void CaptureFrame(Callback<Texture2D> callback)
		{
		}

		private void LateUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003CCaptureFrameRoutine_003Ed__4))]
		private IEnumerator CaptureFrameRoutine()
		{
			return null;
		}
	}
}
