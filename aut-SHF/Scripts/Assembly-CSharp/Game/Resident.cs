using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Libs;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Game
{
	public class Resident : SingletonMonoBehaviour<Resident>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStart_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Resident _003C_003E4__this;

			private TaskAwaiter<LocalizationSettings> _003C_003Eu__1;

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
		private string scriptableObjectReaderPath;

		[SerializeField]
		private ScriptableObjectReader scriptableObjectReader;

		private bool _initialized;

		public ScriptableObjectReader ScriptableObjectReader => null;

		public static void ForceSteamInitialize(bool enable)
		{
		}

		private void Awake()
		{
		}

		[AsyncStateMachine(typeof(_003CStart_003Ed__7))]
		private void Start()
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
