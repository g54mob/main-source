using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RenderCameraToTextures : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCaptureFrames_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RenderCameraToTextures _003C_003E4__this;

		private int _003Cwidth_003E5__2;

		private int _003Cheight_003E5__3;

		private RenderTexture _003Crt_003E5__4;

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
		public _003CCaptureFrames_003Ed__10(int _003C_003E1__state)
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

	[Header("Capture Settings")]
	public Camera captureCamera;

	public int frameCount;

	public string outputFolder;

	public string baseFileName;

	private int currentFrame;

	private bool capturing;

	private Vector2 ScreenRes;

	private void Start()
	{
	}

	private static Vector2 GetMainGameViewSize()
	{
		return default(Vector2);
	}

	public void StartCapture()
	{
	}

	[IteratorStateMachine(typeof(_003CCaptureFrames_003Ed__10))]
	private IEnumerator CaptureFrames()
	{
		return null;
	}

	public void ValidateAndCreateOutputFolder()
	{
	}

	public void OpenOutputFolderInExplorer()
	{
	}
}
