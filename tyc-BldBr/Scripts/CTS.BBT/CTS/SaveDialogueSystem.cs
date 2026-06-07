using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class SaveDialogueSystem : SaveContainer
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private SaveManager _saveManager;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private ProfileManager _profileManager;

		protected override void OnAwake()
		{
			base.OnAwake();
			GameMode.ProfileLoaded += OnProfileLoaded;
			ProfileManager.Saving += OnSceneSaving;
		}

		private void OnDestroy()
		{
			GameMode.ProfileLoaded -= OnProfileLoaded;
			ProfileManager.Saving -= OnSceneSaving;
		}

		private void OnProfileLoaded()
		{
			if ((bool)DialogueManager.Instance)
			{
				string text = _profileManager.CurrentProfile.GetName();
				_saveManager.Load(text + "/dialogueData");
			}
		}

		private void OnSceneSaving()
		{
			if ((bool)DialogueManager.Instance)
			{
				string text = _profileManager.CurrentProfile.GetName();
				_saveManager.Save(text + "/dialogueData");
			}
		}

		public override void Save(ES3Settings settings)
		{
			ES3.Save("DialogueSystem", PersistentDataManager.GetSaveData(), settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			if (SceneManager.GetActiveScene().buildIndex != 0)
			{
				PersistentDataManager.ApplySaveData(ES3.Load<string>("DialogueSystem", (string)null, settings));
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
