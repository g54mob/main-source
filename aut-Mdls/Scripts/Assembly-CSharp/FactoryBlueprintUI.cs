using System.Collections.Generic;
using System.IO;
using Data.Variables;
using Events;
using Logic.Factory.Blueprint;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FactoryBlueprintUI : MonoBehaviour
{
	[SerializeField]
	private InputActionAsset _input;

	[SerializeField]
	private StringVariableSO _currentFactoryBlueprintWorkingPath;

	[SerializeField]
	private Button _createNewBlueprintBtn;

	[SerializeField]
	private Button _refreshBlueprintsBtn;

	[SerializeField]
	private Transform _blueprintsParent;

	[SerializeField]
	private PlaceFactoryBlueprintButtonUI _placeBlueprintBtnPrefab;

	[SerializeField]
	private BaseEvent _selectNewBlueprintToolEvent;

	[SerializeField]
	private BaseEvent _newBlueprintWasAddedEvent;

	[SerializeField]
	private IntVariableSO _blueprintMaxAmount;

	private List<PlaceFactoryBlueprintButtonUI> _blueprintUIs = new List<PlaceFactoryBlueprintButtonUI>();

	private int _currentBlueprintCount;

	private void Awake()
	{
		_refreshBlueprintsBtn.onClick.AddListener(RefreshBlueprints);
		_createNewBlueprintBtn.onClick.AddListener(CreateNewBlueprintTool);
	}

	private void OnDestroy()
	{
		_refreshBlueprintsBtn.onClick.RemoveListener(RefreshBlueprints);
		_createNewBlueprintBtn.onClick.RemoveListener(CreateNewBlueprintTool);
	}

	private void CreateNewBlueprintTool()
	{
		if (_currentBlueprintCount < _blueprintMaxAmount.Value)
		{
			_selectNewBlueprintToolEvent?.Fire();
		}
	}

	private void RefreshBlueprints()
	{
		DirectoryInfo directoryInfo;
		if (!Directory.Exists(_currentFactoryBlueprintWorkingPath.Value))
		{
			directoryInfo = Directory.CreateDirectory(_currentFactoryBlueprintWorkingPath.Value);
		}
		directoryInfo = new DirectoryInfo(_currentFactoryBlueprintWorkingPath.Value);
		List<(BlueprintDto, string)> blueprints = RetrieveBlueprintsFromPath(directoryInfo);
		FillBlueprintUIButtons(blueprints);
	}

	private void FillBlueprintUIButtons(List<(BlueprintDto, string)> blueprints)
	{
		int num = 0;
		foreach (Transform item in _blueprintsParent)
		{
			if (!(item == null) && item.TryGetComponent<PlaceFactoryBlueprintButtonUI>(out var component))
			{
				num++;
				if (num > blueprints.Count)
				{
					component.gameObject.SetActive(value: false);
					continue;
				}
				component.Setup(blueprints[num - 1].Item1, blueprints[num - 1].Item2);
				_blueprintUIs.Add(component);
			}
		}
		if (num < blueprints.Count)
		{
			for (int i = num; i < blueprints.Count; i++)
			{
				PlaceFactoryBlueprintButtonUI placeFactoryBlueprintButtonUI = Object.Instantiate(_placeBlueprintBtnPrefab, _blueprintsParent);
				placeFactoryBlueprintButtonUI.Setup(blueprints[i].Item1, blueprints[i].Item2);
				_blueprintUIs.Add(placeFactoryBlueprintButtonUI);
			}
		}
	}

	private List<(BlueprintDto, string)> RetrieveBlueprintsFromPath(DirectoryInfo info)
	{
		List<(BlueprintDto, string)> list = new List<(BlueprintDto, string)>();
		FileInfo[] files = info.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			if (fileInfo.Extension.Equals(".json") && SaveSystem.TryLoadData<BlueprintDto>(fileInfo.FullName, out var data))
			{
				if (list.Count >= _blueprintMaxAmount.Value)
				{
					break;
				}
				list.Add((data, fileInfo.FullName));
			}
		}
		_currentBlueprintCount = list.Count;
		return list;
	}
}
