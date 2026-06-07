using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Capture From Texture", 3)]
	public class CaptureFromTexture : CaptureBase
	{
		[CompilerGenerated]
		private sealed class _003CFinalRenderCapture_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CaptureFromTexture _003C_003E4__this;

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
			public _003CFinalRenderCapture_003Ed__14(int _003C_003E1__state)
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

		[Tooltip("If enabled the method the encoder will only process frames each time UpdateSourceTexture() is called. This is useful if the texture is updating at a different rate compared to Unity, eg for webcam capture.")]
		[SerializeField]
		private bool _manualUpdate;

		private Texture _sourceTexture;

		private RenderTexture _resolveTexture;

		protected IntPtr _targetNativePointer;

		private bool _isSourceTextureChanged;

		public bool IsManualUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void SetSourceTexture(Texture texture)
		{
		}

		private bool RequiresResolve(Texture texture)
		{
			return false;
		}

		public void UpdateSourceTexture()
		{
		}

		private bool ShouldCaptureFrame()
		{
			return false;
		}

		private bool HasSourceTextureChanged()
		{
			return false;
		}

		public override void UpdateFrame()
		{
		}

		[IteratorStateMachine(typeof(_003CFinalRenderCapture_003Ed__14))]
		private IEnumerator FinalRenderCapture()
		{
			return null;
		}

		private void Capture()
		{
		}

		private void CreateResolveTexture(int width, int height)
		{
		}

		private void AccumulateMotionBlur()
		{
		}

		public override Texture GetPreviewTexture()
		{
			return null;
		}

		public override bool PrepareCapture()
		{
			return false;
		}

		public override void UnprepareCapture()
		{
		}
	}
}
