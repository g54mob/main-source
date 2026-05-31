using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserReport : MonoBehaviour
{
	[Serializable]
	private class SystemInfoData
	{
		public string operatingSystem;

		public string deviceModel;

		public string deviceName;

		public string processorType;

		public int systemMemorySize;

		public string graphicsDeviceName;

		public int graphicsMemorySize;

		public string unityVersion;

		public string productName;

		public string version;

		public string buildGUID;

		public int targetFrameRate;

		public string platform;
	}

	private enum UserReportingState
	{
		Idle = 0,
		CreatingUserReport = 1,
		ShowingForm = 2,
		SubmittingForm = 3
	}

	[CompilerGenerated]
	private sealed class _003CShowError_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UserReport _003C_003E4__this;

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
		public _003CShowError_003Ed__25(int _003C_003E1__state)
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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CStart_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public UserReport _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[Header("UI Elements")]
	[Tooltip("The button used to show the User Report submission form.")]
	[SerializeField]
	private ButtonExtended m_userReportButton;

	[Tooltip("The UI for the User Report submission form.")]
	[SerializeField]
	private GameObject m_userReportForm;

	[Tooltip("The thumbnail viewer for the User Report submission form.")]
	[SerializeField]
	private Image m_thumbnailViewer;

	[Tooltip("The category dropdown for the User Report submission form.")]
	[SerializeField]
	private Dropdown m_categoryDropdown;

	[Tooltip("The input for the summary of the User Report.")]
	[SerializeField]
	private InputField m_summaryInput;

	[Tooltip("The input for the description of the User Report.")]
	[SerializeField]
	private InputField m_descriptionInput;

	[Tooltip("The UI shown while the User Report is submitted.")]
	[SerializeField]
	private GameObject m_submittingPopup;

	[Tooltip("The text for the User Report submission progress display.")]
	[SerializeField]
	private Text m_progressText;

	[Tooltip("The UI shown when there's an error during User Report submission.")]
	[SerializeField]
	private GameObject m_errorPopup;

	[Tooltip("The event raised when a User Report is submitting.")]
	[SerializeField]
	private UnityEvent m_userReportSubmitting;

	[Header("User Reporting Configuration")]
	[Tooltip("Indicates whether each User Report shall include metrics about User Reporting itself.")]
	[SerializeField]
	private bool m_SendInternalMetrics;

	[SerializeField]
	private bool isMainMenu;

	private bool m_IsCreatingUserReport;

	private bool m_IsShowingError;

	private bool m_IsSubmitting;

	private UserReportingState State => default(UserReportingState);

	[AsyncStateMachine(typeof(_003CStart_003Ed__15))]
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void CreateUserReport()
	{
	}

	public void SubmitUserReport()
	{
	}

	public void ClearReport()
	{
	}

	private void SetThumbnail(Texture2D thumbnail)
	{
	}

	[IteratorStateMachine(typeof(_003CShowError_003Ed__25))]
	private IEnumerator ShowError()
	{
		return null;
	}

	private void ClearForm()
	{
	}
}
