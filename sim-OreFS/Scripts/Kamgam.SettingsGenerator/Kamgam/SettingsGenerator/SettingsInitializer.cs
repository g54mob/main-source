using System;
using System.Collections;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[DefaultExecutionOrder(-10)]
	public class SettingsInitializer : MonoBehaviour
	{
		private static SettingsInitializer _instance;

		[Tooltip("Don't forget to hook this up with the right provider.")]
		public SettingsProvider Provider;

		[Tooltip("Enable if you are unloading the scene that contains the initializer.\nIf you can then disable this and use additive scene loading instead.")]
		public bool DoNotDestroy = true;

		[Tooltip("Used only if DoNotDestry is enabled.\nIf enabled then it will re-apply the settings in Start() after reloading this scene.")]
		public bool ApplyOnReload = true;

		private static WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

		public static SettingsInitializer Instance => _instance;

		public static Settings Settings => Instance?.Provider?.Settings;

		public static bool HasSettings()
		{
			if (_instance != null && _instance.Provider != null)
			{
				return _instance.Provider.HasSettings();
			}
			return false;
		}

		public void Awake()
		{
			if (DoNotDestroy)
			{
				if (_instance != null)
				{
					UnityEngine.Object.Destroy(base.gameObject);
					if (ApplyOnReload)
					{
						_instance.StartCoroutine(onInstanceReloaded());
					}
					return;
				}
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			_instance = this;
		}

		public void Start()
		{
			if (Provider == null)
			{
				Debug.LogError("You have not set the Provider on you SettingsInitializer. Please set a provider!", this);
				throw new Exception("Missing Provider on Settings Initializer.");
			}
			_ = Provider.Settings;
		}

		private IEnumerator onInstanceReloaded()
		{
			yield return _waitForEndOfFrame;
			Provider.Apply(changedOnly: false);
		}
	}
}
