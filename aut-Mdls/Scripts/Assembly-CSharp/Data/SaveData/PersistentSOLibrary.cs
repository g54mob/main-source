#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events;
using UnityEngine;
using Utils;

namespace Data.SaveData
{
	[CreateAssetMenu(menuName = "General/PersistentSOLibrary", fileName = "PersistentSOLibrary", order = 0)]
	public class PersistentSOLibrary : ScriptableObject
	{
		[SerializeField]
		private BaseEvent _preResetPersistentSOsEvent;

		[SerializeField]
		private string PersistentSOPath = "Assets/ScriptableObjects/Systems/Persistent/";

		public List<AbstractPersistentSO> PersistentSOList = new List<AbstractPersistentSO>();

		public void Add(AbstractPersistentSO abstractPersistentSO)
		{
			if (!PersistentSOList.Contains(abstractPersistentSO))
			{
				PersistentSOList.Add(abstractPersistentSO);
			}
		}

		public void Remove(AbstractPersistentSO abstractPersistentSO)
		{
			if (PersistentSOList.Contains(abstractPersistentSO))
			{
				PersistentSOList.Remove(abstractPersistentSO);
			}
		}

		public void ResetPersistentSOs()
		{
			_preResetPersistentSOsEvent.Fire();
			foreach (AbstractPersistentSO persistentSO in PersistentSOList)
			{
				persistentSO.ResetToDefaults();
			}
		}

		private void OnValidate()
		{
			Refresh();
		}

		private void Refresh()
		{
			for (int num = PersistentSOList.Count - 1; num >= 0; num--)
			{
				if (PersistentSOList[num] == null)
				{
					PersistentSOList.RemoveAt(num);
				}
			}
		}

		public Task SaveAllPersistentSOsAsync(string directoryPath)
		{
			string[] persistentSONames = new string[PersistentSOList.Count];
			AbstractSaveData[] saveDatas = new AbstractSaveData[PersistentSOList.Count];
			for (int i = 0; i < PersistentSOList.Count; i++)
			{
				try
				{
					persistentSONames[i] = PersistentSOList[i].name;
					saveDatas[i] = PersistentSOList[i].GetSaveData();
				}
				catch (Exception arg)
				{
					this.LogAssertion($"Failed to GetSaveData() from \"{PersistentSOList[i].name}\" with exception: \"{arg}\"", "SaveAllPersistentSOsAsync", 94);
				}
			}
			return Task.Run((Func<Task>)ExecuteSaveAllPersistentSOsAsync);
			Task ExecuteSaveAllPersistentSOsAsync()
			{
				return SaveAllPersistentSOsAsyncContinued(directoryPath, persistentSONames, saveDatas);
			}
		}

		public async Task SaveAllPersistentSOsAsyncContinued(string directoryPath, string[] persistentSONames, AbstractSaveData[] saveDatas)
		{
			for (int i = 0; i < saveDatas.Length; i++)
			{
				if (saveDatas[i] != null)
				{
					string fullSavePath = SaveSystem.CreateFullPath(directoryPath, persistentSONames[i] + ".json");
					SaveSystem.TrySaveData(saveDatas[i], fullSavePath);
				}
			}
		}

		public bool SavePersistentSO(string directoryPath, AbstractPersistentSO persistentSO)
		{
			AbstractSaveData saveData = persistentSO.GetSaveData();
			string fullSavePath = SaveSystem.CreateFullPath(directoryPath, persistentSO.name + ".json");
			return SaveSystem.TrySaveData(saveData, fullSavePath);
		}

		public bool LoadAllPersistentSOs(string directoryPath, string backupPath = null)
		{
			bool flag = true;
			foreach (AbstractPersistentSO persistentSO in PersistentSOList)
			{
				if (persistentSO.TryLoadSaveData(SaveSystem.CreatePersistentSOSavePath(directoryPath, persistentSO.name)))
				{
					continue;
				}
				if (!string.IsNullOrEmpty(backupPath))
				{
					this.LogWarning("Failed loading persistent SO: " + persistentSO.name + " at " + directoryPath + ", trying to load backup next", "LoadAllPersistentSOs", 137);
					if (!persistentSO.TryLoadSaveData(SaveSystem.CreatePersistentSOSavePath(backupPath, persistentSO.name)))
					{
						this.LogWarning("Failed loading persistent SO: " + persistentSO.name + " at " + backupPath, "LoadAllPersistentSOs", 144);
						flag = false;
					}
				}
				else
				{
					this.LogWarning("Failed loading persistent SO: " + persistentSO.name + " at " + directoryPath, "LoadAllPersistentSOs", 149);
					flag = false;
				}
			}
			this.Log($"Load all persistent SOs! Success: {flag}", "LoadAllPersistentSOs", 154);
			return flag;
		}

		public bool LoadCopyOfPersistentSO(string directoryPath, AbstractPersistentSO persistentSO, out AbstractPersistentSO outCopy)
		{
			outCopy = UnityEngine.Object.Instantiate(persistentSO);
			outCopy.name = persistentSO.name;
			return outCopy.TryLoadSaveData(SaveSystem.CreatePersistentSOSavePath(directoryPath, outCopy.name));
		}
	}
}
