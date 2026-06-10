using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AeLa.EasyFeedback.APIs;
using UnityEngine;
using UnityEngine.Events;

namespace AeLa.EasyFeedback
{
	public class FeedbackForm : MonoBehaviour
	{
		[Serializable]
		public class SubmissionMessageEvent : UnityEvent<string>
		{
		}

		[CompilerGenerated]
		private sealed class _003CSubmitAsync_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FeedbackForm _003C_003E4__this;

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
			public _003CSubmitAsync_003Ed__30(int _003C_003E1__state)
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
		private sealed class _003CAttachFilesAsync_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FeedbackForm _003C_003E4__this;

			public string cardID;

			private int _003Ci_003E5__2;

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
			public _003CAttachFilesAsync_003Ed__31(int _003C_003E1__state)
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
		private sealed class _003CScreenshotAndOpenForm_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FeedbackForm _003C_003E4__this;

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
			public _003CScreenshotAndOpenForm_003Ed__38(int _003C_003E1__state)
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

		public Camera cam;

		private const int BIG_TEX = 4082;

		private const float TEX_DIMENSION_MAX = 1920f;

		[Tooltip("Easy Feedback configuration file")]
		public EFConfig Config;

		[Tooltip("Key to toggle feedback window")]
		public KeyCode FeedbackKey;

		[Tooltip("Include screenshot with reports?")]
		public bool IncludeScreenshot;

		[Tooltip("Resizes screenshots larger than 1080p to help with Trello's filesize limit.")]
		public bool ResizeLargeScreenshots;

		public Transform Form;

		[Tooltip("Functions to be called when the form is first opened")]
		public UnityEvent OnFormOpened;

		[Tooltip("Functions to be called when the form is submitted")]
		public UnityEvent OnFormSubmitted;

		[Tooltip("Functions to be called when the form is closed")]
		public UnityEvent OnFormClosed;

		[Tooltip("Called to notify of any errors during submission")]
		public SubmissionMessageEvent OnSubmissionError;

		[Tooltip("Called when the submission has successfully completed")]
		public UnityEvent OnSubmissionSucceeded;

		[Tooltip("Called if the submission fails")]
		public UnityEvent OnSubmissionFailed;

		public Report CurrentReport;

		private CursorLockMode initCursorLockMode;

		private bool initCursorVisible;

		private string screenshotPath;

		private Coroutine ssCoroutine;

		private bool submitting;

		private Trello trello;

		public bool IsOpen => false;

		public void Awake()
		{
		}

		private void Update()
		{
		}

		public void InitTrelloAPI()
		{
		}

		private void InitCurrentReport()
		{
		}

		public void Show()
		{
		}

		public void Submit()
		{
		}

		[IteratorStateMachine(typeof(_003CSubmitAsync_003Ed__30))]
		private IEnumerator SubmitAsync()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAttachFilesAsync_003Ed__31))]
		private IEnumerator AttachFilesAsync(string cardID)
		{
			return null;
		}

		private string WriteLocal(Report report)
		{
			return null;
		}

		public void DisableForm()
		{
		}

		public void EnableForm()
		{
		}

		public void Hide()
		{
		}

		private void ReleaseMouse()
		{
		}

		private void HideMouse()
		{
		}

		[IteratorStateMachine(typeof(_003CScreenshotAndOpenForm_003Ed__38))]
		private IEnumerator ScreenshotAndOpenForm()
		{
			return null;
		}
	}
}
