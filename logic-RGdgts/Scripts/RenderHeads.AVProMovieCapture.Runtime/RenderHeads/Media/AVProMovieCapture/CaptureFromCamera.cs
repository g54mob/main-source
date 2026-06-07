using System;
using System.Collections;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureFromCamera : CaptureBase
	{
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

		private IEnumerator FinalRenderCapture()
		{
			return null;
		}

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
