using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIO.Implementation
{
	public class ExampleSettingsPanel : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSaveSettings_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ExampleSettingsPanel _003C_003E4__this;

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

		[SerializeField]
		private TMP_InputField gameIdInputField;

		[SerializeField]
		private TMP_InputField apiKeyInputField;

		[SerializeField]
		private TMP_InputField initUserInputField;

		[SerializeField]
		private TextMeshProUGUI currentServerUrlText;

		[SerializeField]
		private TextMeshProUGUI currentGameIdText;

		[SerializeField]
		private Button[] buttons;

		private string urlToUse;

		public void ActivatePanel(bool isActive)
		{
		}

		public void SetProductionUrl()
		{
		}

		public void SetTestUrl()
		{
		}

		public void SetServerUrl(string url)
		{
		}

		[AsyncStateMachine(typeof(_003CSaveSettings_003Ed__11))]
		public void SaveSettings()
		{
		}

		public void Close()
		{
		}
	}
}
