using System;
using System.Collections.Generic;
using M4.Session;
using PajamaLlama.Persistence;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
	[SerializeField]
	private PersistentPropertiesReferences _persistentPropertiesReferences;

	[SerializeReference]
	[InstantiateSerializeReference]
	private IPersistenceFix[] _fixes;

	[HideInInspector]
	public bool IsRestoredGame;

	[HideInInspector]
	public int AutosaveIteration;

	[NonSerialized]
	private PersistentPropertiesData _persistentProperties;

	[NonSerialized]
	private StorageActionResult _loadSaveResult;

	private static SaveInfo _saveToLoad;

	private static byte[] _snapShot;

	private static bool _restoreSnapShot;

	public bool IsLoadingSave { get; private set; }

	public static SaveMetaInfo SaveMetaInfo { get; private set; }

	public bool IsSaving { get; private set; }

	public bool Initialize()
	{
		_persistentPropertiesReferences.Initialize();
		if ((_restoreSnapShot && _snapShot != null) || Session.TryLoadSave(out _saveToLoad, OnTryLoadSaveResult))
		{
			IsLoadingSave = true;
			IsRestoredGame = true;
			LoadingScreen.AddTask(delegate
			{
				Restore();
			}, "Restore");
			return true;
		}
		_persistentProperties = new PersistentPropertiesData(_persistentPropertiesReferences);
		IsLoadingSave = false;
		return false;
	}

	private bool Restore()
	{
		WorldPersistentData obj = null;
		if (_saveToLoad != null)
		{
			if (!SaveMetaInfo.TryDeserialize(_loadSaveResult, out var saveMetaInfo) || !saveMetaInfo.TryDeserializeData<WorldPersistentData>(out obj))
			{
				return false;
			}
			SaveMetaInfo = saveMetaInfo;
		}
		else if (!_restoreSnapShot || _snapShot == null || !SaveMetaInfo.TryDeserializeData<WorldPersistentData>(_snapShot, out obj))
		{
			return false;
		}
		GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		PersistenceLifeCycle.OnPrePersistenceAction(PersistenceState.Loading);
		_persistentProperties = obj.PersistentProperties;
		_persistentProperties.Restore(_persistentPropertiesReferences);
		obj.Restore();
		return true;
	}

	private void OnGameStart(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		if (!_fixes.IsNullOrEmpty())
		{
			IPersistenceFix[] fixes = _fixes;
			for (int i = 0; i < fixes.Length; i++)
			{
				fixes[i].Apply();
			}
		}
		ClearSnapShot();
		IsLoadingSave = false;
	}

	public void PopulateReferences<T>(PersistentProperties.Types type, List<T> references) where T : PersistentProperties
	{
		_persistentPropertiesReferences.PopulateReferences(type, references);
	}

	private void OnTryLoadSaveResult(StorageActionResult result)
	{
		_loadSaveResult = result;
	}

	public static bool DoesSaveInfoVersionComeBefore(int major, int minor, int patch)
	{
		if (_saveToLoad != null)
		{
			return _saveToLoad.GameVersion.ReturnComesBefore(major, minor, patch);
		}
		return false;
	}

	public static bool HasSaveInfoVersion(int major, int minor, int patch, string additionalModifiers)
	{
		if (_saveToLoad != null)
		{
			return _saveToLoad.GameVersion.Is(major, minor, patch, additionalModifiers);
		}
		return false;
	}

	public static bool TryTakeSnapShot()
	{
		if (_snapShot == null)
		{
			return TryGetSaveData(out _snapShot);
		}
		return false;
	}

	public static bool SetRestoreSnapShot()
	{
		_restoreSnapShot = _snapShot != null;
		if (_restoreSnapShot)
		{
			_saveToLoad = null;
		}
		return _restoreSnapShot;
	}

	public static void ClearSnapShot()
	{
		_snapShot = null;
		_restoreSnapShot = false;
	}

	private bool ReturnCanSave()
	{
		if (IsLoadingSave || LoadingScreen.IsLoading)
		{
			return false;
		}
		return true;
	}

	public bool TryGetWorldPersistentData(out WorldPersistentData worldPersistentData)
	{
		worldPersistentData = null;
		if (ReturnCanSave())
		{
			if (WorldPersistentData.TryCreateInstance(out worldPersistentData, _persistentProperties))
			{
				return true;
			}
			PopUpDialog.Instance.TryOpenPopUpDialog(GameManager.Settings.UISettings.SaveFailedDialogProperties);
		}
		return false;
	}

	public int ReturnPropertiesIndex(PersistentProperties properties)
	{
		if (_persistentProperties == null)
		{
			throw new NotSupportedException();
		}
		return _persistentProperties.PersistReference(properties);
	}

	public int[] ReturnPropertiesIndexArray<T>(IEnumerable<T> propertiesList) where T : PersistentProperties
	{
		if (_persistentProperties == null)
		{
			throw new NotSupportedException();
		}
		using ListPool<int>.List list = ListPool<int>.Get();
		foreach (T properties in propertiesList)
		{
			int num = _persistentProperties.PersistReference(properties);
			if (num < 0)
			{
				Debug.LogException(new Exception($"Unable to persist reference to '{properties}'"));
			}
			else
			{
				list.Add(num);
			}
		}
		return (0 < list.Count) ? list.ToArray() : null;
	}

	public List<int> ReturnPropertiesIndexList<T>(IEnumerable<T> propertiesList) where T : PersistentProperties
	{
		if (_persistentProperties == null)
		{
			throw new NotSupportedException();
		}
		using ListPool<int>.List list = ListPool<int>.Get();
		foreach (T properties in propertiesList)
		{
			int num = _persistentProperties.PersistReference(properties);
			if (num < 0)
			{
				Debug.LogException(new Exception($"Unable to persist reference to '{properties}'"));
			}
			else
			{
				list.Add(num);
			}
		}
		return (0 < list.Count) ? new List<int>(list) : null;
	}

	public bool TryReturnPropertiesReference<T>(int index, out T reference) where T : PersistentProperties
	{
		if (_persistentProperties == null)
		{
			throw new NotSupportedException();
		}
		return _persistentProperties.TryReturnReference<T>(index, out reference);
	}

	public static bool TryGetSaveData(out byte[] saveData)
	{
		saveData = null;
		if ((bool)GameManager.PersistenceManager && GameManager.PersistenceManager.TryGetWorldPersistentData(out var worldPersistentData))
		{
			return worldPersistentData.TrySerialize(out saveData);
		}
		return false;
	}

	public static bool ReturnIsRestoredGame()
	{
		if (!GameManager.PersistenceManager)
		{
			return false;
		}
		return GameManager.PersistenceManager.IsRestoredGame;
	}
}
