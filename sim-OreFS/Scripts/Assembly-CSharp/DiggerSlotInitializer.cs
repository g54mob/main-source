using System.Reflection;
using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.SaveSystem;
using UnityEngine;

[DefaultExecutionOrder(-15)]
public class DiggerSlotInitializer : MonoBehaviour
{
	private DiggerMasterRuntime _runtime;

	public static bool NeedsCleanPersistOnSave { get; set; }

	private void Awake()
	{
		NeedsCleanPersistOnSave = false;
		DiggerSystem.SkipPersistedDataOnRead = false;
		int num = ((!(SaveLoadGameManager.Instance != null)) ? 1 : SaveLoadGameManager.Instance.GetCurrentSaveSlot());
		string nanoSaveFolderPrefix = GetNanoSaveFolderPrefix();
		string text = $"../Saves/{nanoSaveFolderPrefix}_{num:D4}/DiggerData";
		DiggerSystem[] array = Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].PersistenceSubPath = text;
		}
		_runtime = GetComponent<DiggerMasterRuntime>();
		if (_runtime == null)
		{
			_runtime = Object.FindFirstObjectByType<DiggerMasterRuntime>();
		}
		if (_runtime != null)
		{
			_runtime.enablePersistence = true;
			Debug.Log($"[DiggerSlotInitializer] Prefix '{text}' uygulandı (Slot {num}), persistence aktif.");
		}
		else
		{
			Debug.LogError("[DiggerSlotInitializer] DiggerMasterRuntime bulunamadı!");
		}
	}

	private void Start()
	{
		if (!SaveLoadGameManager.isLoadMode && _runtime != null)
		{
			_runtime.ClearBuffer();
			_runtime.ClearScene();
			NeedsCleanPersistOnSave = true;
			DiggerSystem.SkipPersistedDataOnRead = true;
			Debug.Log("[DiggerSlotInitializer] New game/property change: sahne temizlendi (disk dosyaları korundu).");
		}
	}

	private static string GetNanoSaveFolderPrefix()
	{
		if (Singleton<SaveLoadManager>.Instance == null)
		{
			return "OFS";
		}
		IDataStorage dataStorage = Singleton<SaveLoadManager>.Instance.DataStorage;
		if (dataStorage == null)
		{
			return "OFS";
		}
		FieldInfo field = dataStorage.GetType().GetField("folderPrefix", BindingFlags.Instance | BindingFlags.NonPublic);
		if (field == null)
		{
			return "OFS";
		}
		return ((string)field.GetValue(dataStorage)) ?? "OFS";
	}
}
