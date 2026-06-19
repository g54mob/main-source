using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class ControlSettingsController : MonoBehaviour
{
	public List<SettingsControlBindingReference> ControlsRebindable;

	public List<ControlNameOverride> ControlNameOverrides;

	private static Dictionary<string, LocalizedString> FriendlyNames;

	private readonly List<(LocalizedString localized, SettingsControlBindingReference binding)> _activeSubscriptions;

	private readonly List<(LocalizedString, string localized)> _activeSubscriptionsStrings;

	public void Initiate()
	{
	}

	public void RegisterBinding(SettingsControlBindingReference bindingReference)
	{
	}

	private void ApplyToStory(SettingsControlBindingReference bindingReference, string displayString)
	{
	}

	private void ApplyToStory(string storyID, string displayString)
	{
	}

	private void OnLocaleChanged(Locale _)
	{
	}

	private void Cleanup()
	{
	}

	private void OnDestroy()
	{
	}
}
