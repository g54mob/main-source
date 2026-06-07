using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Capture From Camera 360 Stereo ODS (VR)", 101)]
	public class CaptureFromCamera360ODS : CaptureBase
	{
		[Serializable]
		public class Settings
		{
			[SerializeField]
			public Camera camera;

			[SerializeField]
			public CameraSelector cameraSelector;

			[SerializeField]
			[Tooltip("Render 180 degree equirectangular instead of 360 degrees.  Also faster rendering")]
			public bool render180Degrees;

			[SerializeField]
			[Tooltip("Makes assumption that 1 Unity unit is 1m")]
			public float ipd;

			[SerializeField]
			[Tooltip("Higher value meant less slices to render, but can affect quality.")]
			public int pixelSliceSize;

			[SerializeField]
			[Range(1f, 31f)]
			[Tooltip("May need to be increased to work with some post image effects. Value is in pixels.")]
			public int paddingSize;

			[SerializeField]
			public CameraClearFlags cameraClearMode;

			[SerializeField]
			public Color cameraClearColor;

			[SerializeField]
			public Behaviour[] cameraImageEffects;
		}

		[CompilerGenerated]
		private sealed class _003CFinalRenderCapture_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CaptureFromCamera360ODS _003C_003E4__this;

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
			public _003CFinalRenderCapture_003Ed__20(int _003C_003E1__state)
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
		private Settings _settings;

		private int _eyeWidth;

		private int _eyeHeight;

		private Transform _cameraGroup;

		private Camera _leftCameraTop;

		private Camera _leftCameraBot;

		private Camera _rightCameraTop;

		private Camera _rightCameraBot;

		private RenderTexture _final;

		private IntPtr _targetNativePointer;

		private Material _finalMaterial;

		private int _propSliceCenter;

		public Settings Setup => null;

		public void SetCamera(Camera camera)
		{
		}

		public override void Start()
		{
		}

		private Camera CreateEye(Camera camera, string gameObjectName, float yRot, float xOffset, int cameraTargetHeight, int cullingMask, float fov, float aspect, int aalevel)
		{
			return null;
		}

		public override void UpdateFrame()
		{
		}

		[IteratorStateMachine(typeof(_003CFinalRenderCapture_003Ed__20))]
		private IEnumerator FinalRenderCapture()
		{
			return null;
		}

		private void Capture()
		{
		}

		private void AccumulateMotionBlur()
		{
		}

		private void RenderFrame()
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

		private static void DestroyEye(Camera camera)
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
