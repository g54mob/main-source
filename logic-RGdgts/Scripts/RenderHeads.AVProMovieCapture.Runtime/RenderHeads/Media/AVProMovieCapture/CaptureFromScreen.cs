using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureFromScreen : CaptureBase
	{
		[SerializeField]
		private bool _captureMouseCursor;

		[SerializeField]
		private MouseCursor _mouseCursor;

		private IntPtr _targetNativePointer;

		private RenderTexture _resolveTexture;

		private CommandBuffer _commandBuffer;

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

		private IEnumerator FinalRenderCapture()
		{
			return null;
		}

		public override void UpdateFrame()
		{
		}
	}
}
