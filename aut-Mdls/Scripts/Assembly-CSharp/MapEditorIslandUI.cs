using DG.Tweening;
using Data.FactoryFloor.Maps;
using Events.FactoryFloor.Islands;
using Events.Generic;
using Presentation.FactoryFloor.Islands;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapEditorIslandUI : MonoBehaviour
{
	[SerializeField]
	private IslandObjectEvent _mapEditorSelectIslandObjectEvent;

	[SerializeField]
	private IntEvent _deleteIslandEvent;

	[Header("UI")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private TMP_Text _header;

	[SerializeField]
	private Slider _bottomPrefabIndexSlider;

	[SerializeField]
	private Slider _bottomPrefabRotationSlider;

	[SerializeField]
	private Toggle _isGNNGateIsland;

	private IslandObject _islandObject;

	private void Start()
	{
		_mapEditorSelectIslandObjectEvent.Register(OnIslandSelected);
		_deleteIslandEvent.Register(OnIslandDeleted);
		_bottomPrefabIndexSlider.onValueChanged.AddListener(ChangeBottomPrefabIndex);
		_bottomPrefabRotationSlider.onValueChanged.AddListener(ChangeBottomPrefabRotation);
		_isGNNGateIsland.onValueChanged.AddListener(ChangeIsGNNGateIsland);
		_canvasGroup.alpha = 0f;
		_canvasGroup.interactable = false;
	}

	private void OnDestroy()
	{
		_mapEditorSelectIslandObjectEvent.UnRegister(OnIslandSelected);
		_deleteIslandEvent.UnRegister(OnIslandDeleted);
		_bottomPrefabIndexSlider.onValueChanged.RemoveListener(ChangeBottomPrefabIndex);
		_bottomPrefabRotationSlider.onValueChanged.RemoveListener(ChangeBottomPrefabRotation);
		_isGNNGateIsland.onValueChanged.RemoveListener(ChangeIsGNNGateIsland);
	}

	private void OnIslandSelected(IslandObject islandObject)
	{
		if (islandObject != _islandObject)
		{
			_islandObject = islandObject;
			_header.SetText(islandObject.IslandConfig.IslandData.Name + islandObject.Position.ToString());
			_bottomPrefabIndexSlider.value = _islandObject.IslandConfig.IslandBottom.SelectedIndex;
			_bottomPrefabIndexSlider.maxValue = _islandObject.IslandView.GetBottomMaxIndex(_islandObject.IslandConfig.SizeUnits);
			_bottomPrefabRotationSlider.value = _islandObject.IslandConfig.IslandBottom.Rotation;
			_isGNNGateIsland.isOn = _islandObject.IslandConfig.IsGNNGateIsland;
			_canvasGroup.DOComplete();
			_canvasGroup.alpha = 0f;
			_canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutSine);
			_canvasGroup.interactable = true;
		}
	}

	private void OnIslandDeleted(int islandCreatedId)
	{
		if (_islandObject != null && _islandObject.CreatedId == islandCreatedId)
		{
			_islandObject = null;
			_canvasGroup.DOComplete();
			_canvasGroup.DOFade(0f, 0.5f).SetEase(Ease.OutSine);
			_canvasGroup.interactable = false;
		}
	}

	private void ChangeBottomPrefabIndex(float value)
	{
		int selectedIndex = Mathf.FloorToInt(value);
		IslandConfig.IslandBottomPrefabConfig islandBottom = _islandObject.IslandConfig.IslandBottom;
		islandBottom.SelectedIndex = selectedIndex;
		_islandObject.IslandConfig.IslandBottom = islandBottom;
		_islandObject.IslandView.SetBottomPrefab(_islandObject.IslandConfig);
	}

	private void ChangeBottomPrefabRotation(float value)
	{
		int rotation = Mathf.FloorToInt(value);
		IslandConfig.IslandBottomPrefabConfig islandBottom = _islandObject.IslandConfig.IslandBottom;
		islandBottom.Rotation = rotation;
		_islandObject.IslandConfig.IslandBottom = islandBottom;
		_islandObject.IslandView.SetBottomPrefab(_islandObject.IslandConfig);
	}

	private void ChangeIsGNNGateIsland(bool isGNNGateIsland)
	{
		_islandObject.IslandConfig.IsGNNGateIsland = isGNNGateIsland;
	}
}
