using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Capture From Camera", 1)]
	public class CaptureFromCamera : CaptureBase
	{
		[CompilerGenerated]
		private sealed class _003CCapture_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CaptureFromCamera _003C_003E4__this;

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
			public _003CCapture_003Ed__22(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CFinalRenderCapture_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CaptureFromCamera _003C_003E4__this;

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
			public _003CFinalRenderCapture_003Ed__21(int _003C_003E1__state)
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
		private CameraSelector _cameraSelector;

		[SerializeField]
		private Camera _lastCamera;

		[SerializeField]
		private Camera[] _contribCameras;

		[SerializeField]
		private bool _useContributingCameras;

		private RenderTexture _target;

		private RenderTexture _resolveTexture;

		private IntPtr _targetNativePointer;

		private Texture _targetNativeTexture;

		private Texture _previewTexture;

		public CameraSelector CameraSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseContributingCameras
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void SetCamera(Camera topCamera, bool useContributingCameras = true)
		{
		}

		public void SetCamera(Camera topCamera, Camera[] contributingCameras)
		{
		}

		private bool RequiresResolve(Texture texture)
		{
			return false;
		}

		private bool HasCamera()
		{
			return false;
		}

		private bool HasContributingCameras()
		{
			return false;
		}

		public override void UpdateFrame()
		{
		}

		[IteratorStateMachine(typeof(_003CFinalRenderCapture_003Ed__21))]
		private IEnumerator FinalRenderCapture()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCapture_003Ed__22))]
		public IEnumerator Capture()
		{
			return null;
		}

		private bool RequiresHDR()
		{
			return false;
		}

		private void UpdateTexture()
		{
		}

		public override void UnprepareCapture()
		{
		}

		private void CreateResolveTexture(int width, int height)
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

		public override void OnDestroy()
		{
		}
	}
}
