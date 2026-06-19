using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public static class LanguageManager
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string languageCode;

		internal bool _003CSetLanguageAsync_003Eb__0(Locale loc)
		{
			return false;
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CSetLanguageAsync_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string languageCode;

		private _003C_003Ec__DisplayClass1_0 _003C_003E8__1;

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

	public static void SetLanguage(string languageCode)
	{
	}

	[AsyncStateMachine(typeof(_003CSetLanguageAsync_003Ed__1))]
	public static Task SetLanguageAsync(string languageCode)
	{
		return null;
	}

	public static List<Locale> GetLocales()
	{
		return null;
	}
}
