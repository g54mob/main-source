#define ENABLE_DEBUG_LOGS
using System.IO;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using UnityEngine;
using Utils;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Events/AutoSave/Auto Save Service", fileName = "AutoSaveService", order = 0)]
	public class AutoSaveService : ScriptableObject
	{
		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		public void AutoSave()
		{
			if (Directory.Exists(SaveSystem.AutoSavePath))
			{
				Directory.Delete(SaveSystem.AutoSavePath, recursive: true);
			}
			_factorySaver.SaveFactory(SaveSystem.AutoSavePath, _currentSavePath.Value);
			this.Log("Autosave to " + SaveSystem.AutoSavePath, "AutoSave", 25);
		}
	}
}
