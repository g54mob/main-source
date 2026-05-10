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
		private sealed class _003CAttachFilesAsync_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FeedbackForm _003C_003E4__this;

			public string cardID;

			private List<AeLa.EasyFeedback.Utility.FileAttachment>.Enumerator _003C_003E7__wrap1;

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
			public _003CAttachFilesAsync_003Ed__30(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CScreenshotAndOpenForm_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CScreenshotAndOpenForm_003Ed__35(int _003C_003E1__state)
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
		private sealed class _003CSubmitAsync_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CSubmitAsync_003Ed__29(int _003C_003E1__state)
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

		public const int MAX_SUBMISSIONS_PER_SESSION = 5;

		[Tooltip("Easy Feedback configuration file")]
		public EFConfig Config;

		[Tooltip("Include screenshot with reports?")]
		public bool IncludeScreenshot;

		[Tooltip("Include save file with reports?")]
		public bool IncludeSaveFile;

		[Tooltip("Method used to capture the screenshot.")]
		public ScreenshotMode ScreenshotCaptureMode;

		[Tooltip("Resizes screenshots larger than 1080p to help with Trello's filesize limit.\nNOTE: Not supported in Legacy screenshot mode.")]
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

		private string screenshotPath;

		private Coroutine ssCoroutine;

		private Trello trello;

		private int submissionCount;

		public bool IsOpen => false;

		public virtual void Awake()
		{
		}

		private void ReportError(string message)
		{
		}

		public void InitTrelloAPI()
		{
		}

		private void InitCurrentReport()
		{
		}

		public void Toggle()
		{
		}

		public void Show()
		{
		}

		public virtual void Submit()
		{
		}

		protected virtual string GetTextToAppendToTitle()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSubmitAsync_003Ed__29))]
		protected IEnumerator SubmitAsync()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAttachFilesAsync_003Ed__30))]
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

		[IteratorStateMachine(typeof(_003CScreenshotAndOpenForm_003Ed__35))]
		private IEnumerator ScreenshotAndOpenForm()
		{
			return null;
		}
	}
}
