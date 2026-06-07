using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using UnityEngine;
using Utils;

public class HexaCrystalResourceView : FactoryBehaviorView<ColorResourceBehaviour>
{
	[SerializeField]
	private Transform _modelParent;

	[SerializeField]
	private GameObject _defaultModel;

	[SerializeField]
	private ColorLibrarySO _colorLibrary;

	[SerializeField]
	private SerializedDictionary<Color, GameObject> _prefabPerColor;

	private GameObject _view;

	private bool _hasView;

	public override void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading)
	{
		base.SetFactoryObject(factoryObject, isGameLoading);
		SpawnView();
		_behaviour.ColorChanged.RegisterMainThread(SpawnView);
	}

	protected override void ResetFactoryObject()
	{
		base.ResetFactoryObject();
		if ((bool)_behaviour)
		{
			_behaviour.ColorChanged.UnRegisterMainThread(SpawnView);
		}
		DestroyView();
	}

	private void SpawnView()
	{
		if (_hasView)
		{
			DestroyView();
		}
		bool flag = _behaviour != null && _prefabPerColor.ContainsKey(_behaviour.Color);
		if (flag)
		{
			_view = Object.Instantiate(_prefabPerColor[_behaviour.Color], _modelParent);
		}
		_defaultModel.gameObject.SetActive(!flag);
		_hasView = true;
	}

	private void DestroyView()
	{
		Object.Destroy(_view);
		_view = null;
		_hasView = false;
	}

	[Button(null, EButtonEnableMode.Always)]
	private void PopulateColorLibrary()
	{
		if (!_colorLibrary)
		{
			return;
		}
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < _prefabPerColor.Count; i++)
		{
			list.Add(_prefabPerColor.ElementAt(i).Value);
		}
		_prefabPerColor.Clear();
		for (int j = 0; j < _colorLibrary.HexCodeColorDictionary.Count; j++)
		{
			if (ColorUtility.TryParseHtmlString("#" + _colorLibrary.HexCodeColorDictionary.ElementAt(j).Key, out var color))
			{
				_prefabPerColor.Add(color, (list.Count > j) ? list[j] : null);
			}
		}
	}
}
