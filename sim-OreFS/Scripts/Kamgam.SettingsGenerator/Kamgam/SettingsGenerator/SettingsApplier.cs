using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class SettingsApplier : MonoBehaviour
	{
		public SettingsProvider Provider;

		[Header("Start")]
		public bool ApplyOnStart = true;

		[Tooltip("On start delay in seconds.")]
		public float ApplyOnStartDelay;

		[Header("Update")]
		[Tooltip("Only use this as a last resort if another system keeps overriding your settings.\nYou really should find out what system that is and route the settings through that instead of using this.")]
		public bool ApplyOnLateUpdate;

		[Header("Limit applied settings")]
		[Tooltip("Leave empty to apply all settings")]
		public List<string> SettingIds = new List<string>();

		public IEnumerator Start()
		{
			yield return new WaitForSecondsRealtime(ApplyOnStartDelay);
			if (Provider == null)
			{
				Debug.LogError("You have not set the Provider on you SettingsApplier. Please set a provider!", this);
				throw new Exception("Missing Provider on Settings Initializer.");
			}
			if (ApplyOnStart)
			{
				Apply();
			}
		}

		public void LateUpdate()
		{
			if (ApplyOnLateUpdate)
			{
				Apply();
			}
		}

		public void Apply()
		{
			if (SettingIds == null || SettingIds.Count == 0)
			{
				Provider.Settings.Apply(changedOnly: false);
				return;
			}
			foreach (string settingId in SettingIds)
			{
				Provider.Settings.GetSetting(settingId)?.Apply();
			}
		}
	}
}
