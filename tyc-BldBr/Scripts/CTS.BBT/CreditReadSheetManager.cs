using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

public class CreditReadSheetManager : MonoBehaviour
{
	public enum E_ImportType
	{
		None = 0,
		EditorOnly = 1,
		BuildOnly = 2,
		EditorNBuild = 3
	}

	private string _documentID;

	private ImportQueue _importQueue;

	private Dictionary<string, bool> _pagesToggles;

	[SerializeField]
	private E_ImportType _importType;

	[Foldout("Devs")]
	[SerializeField]
	private UI_CreditsExcelText _creditsExcelText;

	[Foldout("Devs")]
	[SerializeField]
	private CreditSheetImporter _sheetImporter;

	[Foldout("Devs")]
	[SerializeField]
	private CreditsDataSheetLink _creditDataSheetLink;

	[Foldout("Devs")]
	[SerializeField]
	private CreditsDatabase _creditsDataBase;

	private bool _replaceExistingAssets;

	[Header("Use The ShareLink and Not The URL")]
	[SerializeField]
	private string _googlePath = "";

	[SerializeField]
	[HideInInspector]
	private string _currentResourcesPath;

	[field: SerializeField]
	public string ResourcesPath { get; private set; } = "Assets\\Resources\\ScriptableObjects\\LevelData\\";

	private void StartImport()
	{
		if (_sheetImporter == null)
		{
			return;
		}
		if (_creditDataSheetLink == null)
		{
			Debug.LogError("Load LevelsDataSheetLink Failed");
			return;
		}
		_documentID = _creditDataSheetLink.GetCleanedPath();
		if (string.IsNullOrEmpty(_documentID))
		{
			Debug.LogError("Document ID is not specified!");
			return;
		}
		Debug.Log("StartImport");
		_sheetImporter.documentID = _documentID;
		FieldInfo[] array = (from i in _sheetImporter.GetType().GetFields()
			where Attribute.IsDefined(i, typeof(PageNameAttribute))
			orderby i.Name
			select i).ToArray();
		if (_pagesToggles == null)
		{
			_pagesToggles = new Dictionary<string, bool>();
			for (int num = 0; num < array.Length; num++)
			{
				_pagesToggles.Add(array[num].Name, value: true);
			}
		}
		_importQueue = new ImportQueue(_sheetImporter, array.Where((FieldInfo i) => _pagesToggles[i.Name]).ToArray());
		ImportQueue importQueue = _importQueue;
		importQueue.onComplete = (Action<DataContainerBase>)Delegate.Combine(importQueue.onComplete, new Action<DataContainerBase>(OnImportQueueComplete));
		_importQueue.Run();
	}

	private void OnImportQueueComplete(DataContainerBase container)
	{
		ImportQueue importQueue = _importQueue;
		importQueue.onComplete = (Action<DataContainerBase>)Delegate.Remove(importQueue.onComplete, new Action<DataContainerBase>(OnImportQueueComplete));
		_importQueue = null;
		SaveData();
	}

	private void SaveData()
	{
		int num = 0;
		Debug.Log("Save Datas : " + _sheetImporter.HierarchyJob.Count);
		if (_pagesToggles.ContainsKey("HierarchyJob") && _pagesToggles["HierarchyJob"])
		{
			for (int i = 0; i < _sheetImporter.HierarchyJob.Count; i++)
			{
				_creditsDataBase._listHierarchy.Add(null);
				num += _sheetImporter.HierarchyJob[i].SavingHierarchyUpdate(_replaceExistingAssets, ResourcesPath, _creditsDataBase, i);
				Debug.Log(_sheetImporter.HierarchyJob[i]);
			}
			_creditsDataBase.RemoveListNull();
		}
		if (_pagesToggles.ContainsKey("Worker") && _pagesToggles["Worker"])
		{
			for (int j = 0; j < _sheetImporter.Worker.Count; j++)
			{
				num += _sheetImporter.Worker[j].SaveBalancingDataUpdated(_replaceExistingAssets, ResourcesPath, _creditsDataBase);
				Debug.Log(_sheetImporter.Worker[j]);
			}
			Debug.Log("Import : " + num + " / " + _sheetImporter.Worker.Count + " Level Assets");
		}
		else
		{
			Debug.Log("Rien trouvé");
		}
		Debug.Log("Import Finished");
		_creditsDataBase.ArrangeList();
		_creditsExcelText.UpdateText();
	}

	[Button("ImportSheetDatas", EButtonEnableMode.Editor)]
	private void ImportSheetDatas()
	{
		if (_currentResourcesPath == null)
		{
			_currentResourcesPath = ResourcesPath;
		}
		Create();
		StartImport();
	}

	private void Create()
	{
		CreateANewDataSheetLink();
		CreateANewSheetImport();
		CreateANewInstance();
		_currentResourcesPath = ResourcesPath;
	}

	private void CreateANewDataSheetLink()
	{
	}

	private void CreateANewSheetImport()
	{
	}

	private void CreateANewInstance()
	{
	}

	public string GiveRef()
	{
		return ResourcesPath + "CreditDataBase.asset";
	}

	[Button(null, EButtonEnableMode.Always)]
	private void OpenSheetDatas()
	{
		Application.OpenURL(_creditDataSheetLink.GetFullPath());
	}
}
