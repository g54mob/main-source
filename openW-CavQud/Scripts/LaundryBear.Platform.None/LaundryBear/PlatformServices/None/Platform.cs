using System;
using System.Collections;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace LaundryBear.PlatformServices.None
{
	public class Platform : MonoBehaviour, IPlatform, IService, IStorageService
	{
		public const string UseAsyncIOCallsInEditorKey = "UseAsyncIOCallsInEditor";

		public string Name => "None Platform";

		public ServiceLocator.ServiceInitializationStatus InitializationStatus { get; private set; }

		public bool SupportsAchievements => false;

		public bool SupportsRichPresence => false;

		public bool SupportsUsers => false;

		public bool AllowsUserWindowModification => true;

		public bool SupportsQuit => true;

		public bool SupportsPlayerPrefs => true;

		public bool RequiresAssociatedUser => false;

		public event PlatformSuspendEventHandler SuspendEvent;

		public event PlatformResumeEventHandler ResumeEvent;

		public event PlatformShutdownEventHandler ShutdownEvent;

		public void SetupRequiredData(object data)
		{
		}

		public void Quit()
		{
			this.ShutdownEvent?.Invoke();
			Application.Quit();
		}

		public string GetSystemLanguage()
		{
			return CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
		}

		public IEnumerator Initialize(bool sync = false)
		{
			yield return null;
			InitializationStatus = ServiceLocator.ServiceInitializationStatus.Ready;
		}

		private void OnApplicationQuit()
		{
			this.ShutdownEvent?.Invoke();
		}

		private void OnApplicationFocus(bool focus)
		{
			this.ResumeEvent?.Invoke();
		}

		private void OnApplicationPause(bool pause)
		{
			this.SuspendEvent?.Invoke();
		}

		public string Combine(params string[] paths)
		{
			return Path.Combine(paths);
		}

		public void InitializePlayerPrefs()
		{
		}

		public IEnumerator InitializePlayerPrefsAsync()
		{
			return InitializePlayerPrefsCoroutine();
		}

		public void OpenOrCreate(string root, OnCreateStorage callback)
		{
			if (false)
			{
				Debug.LogWarning("Using Async IO calls in editor not implemented anymore");
			}
			IStorage storage = new Storage(root);
			callback(StorageResult.Success, storage);
		}

		public void OpenOrCreate(IUser user, string name, OnCreateStorage callback)
		{
			throw new NotImplementedException();
		}

		private IEnumerator InitializePlayerPrefsCoroutine()
		{
			yield return null;
		}
	}
}
