using System;
using System.Collections;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureFromCamera360 : CaptureBase
	{
		private enum CubemapRenderMethod
		{
			Manual = 0,
			Unity = 1,
			Unity2018 = 2
		}

		[SerializeField]
		private CameraSelector _cameraSelector;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private CubemapResolution _cubemapResolution;

		[SerializeField]
		private CubemapDepth _cubemapDepth;

		[SerializeField]
		private bool _supportGUI;

		[SerializeField]
		private bool _supportCameraRotation;

		[SerializeField]
		private bool _onlyLeftRightRotation;

		[SerializeField]
		private bool _render180Degrees;

		[SerializeField]
		private StereoPacking _stereoRendering;

		[SerializeField]
		private float _ipd;

		[SerializeField]
		private float _blendOverlapPercent;

		private RenderTexture _faceTarget;

		private RenderTexture[] _faceTargets;

		private Material _blitMaterial;

		private Material _cubemapToEquirectangularMaterial;

		private RenderTexture _cubeTarget;

		private RenderTexture _finalTarget;

		private IntPtr _targetNativePointer;

		private int _propFlipX;

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

		public CubemapResolution CubemapFaceResolution
		{
			get
			{
				return default(CubemapResolution);
			}
			set
			{
			}
		}

		public CubemapDepth CubemapDepthResolution
		{
			get
			{
				return default(CubemapDepth);
			}
			set
			{
			}
		}

		public bool SupportGUI
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SupportCameraRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool OnlyLeftRightRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Render180Degrees
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public StereoPacking StereoRendering
		{
			get
			{
				return default(StereoPacking);
			}
			set
			{
			}
		}

		public float IPD
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private CubemapRenderMethod GetCubemapRenderingMethod()
		{
			return default(CubemapRenderMethod);
		}

		public void SetCamera(Camera camera)
		{
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

		private static void ClearCubemap(RenderTexture texture, Color color)
		{
		}

		private void RenderCubemapToEquiRect(RenderTexture cubemap, RenderTexture target, bool supportRotation, Quaternion rotation, bool isEyeLeft)
		{
		}

		private void UpdateTexture()
		{
		}

		private void RenderCameraToCubemap(Camera camera, RenderTexture cubemapTarget)
		{
		}

		private void AccumulateMotionBlur()
		{
		}

		public override bool PrepareCapture()
		{
			return false;
		}

		public override Texture GetPreviewTexture()
		{
			return null;
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
