using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Capture From Screen", 0)]
	public class CaptureFromScreen : CaptureBase
	{
		[CompilerGenerated]
		private sealed class _003CFinalRenderCapture_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CaptureFromScreen _003C_003E4__this;

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
			public _003CFinalRenderCapture_003Ed__17(int _003C_003E1__state)
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

		[SerializeField]
		private bool _captureMouseCursor;

		[SerializeField]
		private MouseCursor _mouseCursor;

		private IntPtr _targetNativePointer;

		private RenderTexture _resolveTexture;

		private CommandBuffer _commandBuffer;

		private IEnumerator _finalRenderCapture;

		private bool _doFinalRenderCapture;

		public bool CaptureMouseCursor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MouseCursor MouseCursor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool PrepareCapture()
		{
			return false;
		}

		private void CopyRenderTargetToTexture()
		{
		}

		private void FreeRenderResources()
		{
		}

		public override void UnprepareCapture()
		{
		}

		[IteratorStateMachine(typeof(_003CFinalRenderCapture_003Ed__17))]
		private IEnumerator FinalRenderCapture()
		{
			return null;
		}

		public override void UpdateFrame()
		{
		}
	}
}
