using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageSettingsController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public LanguageListingItem lang;

		internal bool _003CApplyLanguage_003Eb__0(Locale l)
		{
			return false;
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CApplyLanguage_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LanguageListingItem lang;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

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

	public List<LanguageListingItem> LanguagesSupported;

	public const string LanguageSettingsKey = "Settings_Language";

	public void Initiate()
	{
	}

	public void UpdateLanguageSetting(LanguageListingItem listing)
	{
	}

	[AsyncStateMachine(typeof(_003CApplyLanguage_003Ed__4))]
	private void ApplyLanguage(LanguageListingItem lang)
	{
	}

	public LanguageListingItem GetLanguageListing()
	{
		return null;
	}

	public LanguageListingItem GetLanguageListing(Locale locale)
	{
		return null;
	}
}
