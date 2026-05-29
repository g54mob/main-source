using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AppBrowserDownloadAdapter
{
	[CompilerGenerated]
	private sealed class _003CAnimProgress_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppBrowserDownloadAdapter _003C_003E4__this;

		public AppBrowserDownloader appBrowserDownloader;

		private float _003CdownloadSpeed_003E5__2;

		private float _003Cdownloaded_003E5__3;

		private float _003CelapsedTime_003E5__4;

		private float _003CelapsedTime2_003E5__5;

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
		public _003CAnimProgress_003Ed__13(int _003C_003E1__state)
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

	public RectTransform adapterObject;

	public FileSystemObject file;

	public float progress;

	public long sizeFile;

	public AppBrowserDownloadStatus downloadStatus;

	private Image barProgress;

	private GameObject progressObject;

	private TMP_Text speed;

	private TMP_Text fileName;

	private TMP_Text downloadProgerssText_1;

	private TMP_Text downloadProgerssText_2;

	public Coroutine task;

	public void SetUI()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimProgress_003Ed__13))]
	public IEnumerator AnimProgress(AppBrowserDownloader appBrowserDownloader)
	{
		return null;
	}
}
