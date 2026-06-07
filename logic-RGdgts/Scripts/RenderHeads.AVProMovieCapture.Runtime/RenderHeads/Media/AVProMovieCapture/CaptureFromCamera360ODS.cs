using System;
using System.Collections;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
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
			public bool render180Degrees;

			[SerializeField]
			public float ipd;

			[SerializeField]
			public int pixelSliceSize;

			[SerializeField]
			public int paddingSize;

			[SerializeField]
			public CameraClearFlags cameraClearMode;

			[SerializeField]
			public Color cameraClearColor;

			[SerializeField]
			public Behaviour[] cameraImageEffects;
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
