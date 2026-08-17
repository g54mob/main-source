using System;
using Cpp2ILInjected;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Localization;

public abstract class LocalizedStringProviderBase : MonoBehaviour, ILocalizedStringProvider
{
	private bool _prefetch;

	public virtual bool prefetch
	{
		get
		{
			return _prefetch;
		}
		set
		{
			_prefetch = value;
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy && base.enabled && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.LocalizationHelper localization = ReInput.localization;
				ILocalizedStringProvider localizedStringProvider = localization.localizedStringProvider;
				if (localizedStringProvider == this)
				{
					ReInput.LocalizationHelper localization2 = ReInput.localization;
					localization2.prefetch = value;
				}
			}
		}
	}

	protected abstract bool initialized { get; }

	protected virtual void OnEnable()
	{
		if (!initialized)
		{
			bool flag = Initialize();
		}
		TrySetLocalizedStringProvider();
	}

	protected virtual void OnDisable()
	{
		//IL_0083: Expected I, but got O
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.LocalizationHelper localization = ReInput.localization;
			ILocalizedStringProvider localizedStringProvider = localization.localizedStringProvider;
			if (localizedStringProvider == this)
			{
				ReInput.LocalizationHelper localization2 = ReInput.localization;
				localization2.localizedStringProvider = null;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v3 (Il2CppClass<Rewired.Localization.LocalizedStringProviderBase>)+1F0]");
		Action value = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		ReInput.InitializedEvent -= value;
	}

	protected virtual void Update()
	{
	}

	protected virtual void TrySetLocalizedStringProvider()
	{
		//IL_000a: Expected I, but got O
		//IL_004e: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<Rewired.Localization.LocalizedStringProviderBase>)+1F0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<Rewired.Localization.LocalizedStringProviderBase>)+1F0]");
		action._002Ector(this, (IntPtr)0);
		ReInput.InitializedEvent -= action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v4 (Il2CppClass<Rewired.Localization.LocalizedStringProviderBase>)+1F0]");
		Action value = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		ReInput.InitializedEvent += value;
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.LocalizationHelper localization = ReInput.localization;
			ILocalizedStringProvider localizedStringProvider = localization.localizedStringProvider;
			if (UnityTools.IsNullOrDestroyed(localizedStringProvider))
			{
				ReInput.LocalizationHelper localization2 = ReInput.localization;
				localization2.localizedStringProvider = this;
				ReInput.LocalizationHelper localization3 = ReInput.localization;
				localization3.prefetch = _prefetch;
			}
			else
			{
				Debug.LogWarning("A localized string provider is already set. Only one localized string provider can exist at a time.");
			}
		}
	}

	protected abstract bool Initialize();

	public virtual void Reload()
	{
		bool flag = Initialize();
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy && base.enabled && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.LocalizationHelper localization = ReInput.localization;
			ILocalizedStringProvider localizedStringProvider = localization.localizedStringProvider;
			if (localizedStringProvider == this)
			{
				ReInput.LocalizationHelper localization2 = ReInput.localization;
				localization2.Reload();
			}
		}
	}

	protected abstract bool TryGetLocalizedString(string key, out string result);

	bool ILocalizedStringProvider.TryGetLocalizedString(string key, out string result)
	{
		return TryGetLocalizedString(key, out result);
	}
}
