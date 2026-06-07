using System;
using System.Collections;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureFromTexture : CaptureBase
	{
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
