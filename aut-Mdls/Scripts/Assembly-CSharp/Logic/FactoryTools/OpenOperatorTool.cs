#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews;
using Presentation.Locators;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/OpenOperatorTool", fileName = "OpenOperatorTool", order = 0)]
	public class OpenOperatorTool : FactoryTool
	{
		[Header("Open Operator refs")]
		[SerializeField]
		private CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private IntListEvent _newFactoryObjectsSelectedEvent;

		[SerializeField]
		private IntListEvent _factoryObjectsDeSelectedEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private InputActionReference _mousePosition;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private OpenOperatorToolUsedOnPositionEvent _openOperatorToolUsedOnPositionEvent;

		[SerializeField]
		private BoolEvent _cameraModeChangedEvent;

		[SerializeField]
		private GameObject _clickOnEmptyGroundParticle;

		[SerializeField]
		private GameObject _clickOnGrassParticle;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private Texture2D _configurableCursorTexture;

		[Header("Copy / Paste configs")]
		[SerializeField]
		private InputActionReference _copyConfigInputAction;

		[SerializeField]
		private InputActionReference _pasteConfigInputAction;

		[SerializeField]
		private SetCursorTextEvent _setFadingCursorTextEvent;

		[SerializeField]
		[LocaKey]
		private string _copiedConfigLocaKey;

		[SerializeField]
		[LocaKey]
		private string _pastedConfigLocaKey;

		[SerializeField]
		[LocaKey]
		private string _cantPasteConfigLocaKey;

		[SerializeField]
		private float _animationTime = 0.15f;

		[SerializeField]
		private float _animationDistanceFromCursor = 10f;

		private FactoryObject _currentHoveredFactoryObject;

		private FactoryObjectView _currentHoveredView;

		private bool _isFreeCamera;

		private bool _isTryingToPasteConfig;

		private string _copiedOperatorNameLocaKey;

		private int _copiedFactoryObjectID = -1;

		private bool _copiedFactoryObjectIsBuilding;

		private BehaviourConfigurationDto[] _copiedConfigurations = Array.Empty<BehaviourConfigurationDto>();

		public override bool CanAutoSwapAwayFrom => true;

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			_currentHoveredView = _mouseToGridInput.GetSelectedFactoryObjectView();
			FactoryObject hoveredFactoryObject = GetHoveredFactoryObject(gridPos);
			if (hoveredFactoryObject != null)
			{
				if (_currentHoveredFactoryObject != hoveredFactoryObject)
				{
					UpdateCursor(hoveredFactoryObject);
				}
			}
			else if (_currentHoveredFactoryObject != null)
			{
				_factoryObjectsDeSelectedEvent.Fire(new List<int> { _currentHoveredFactoryObject.CreatedId });
				UpdateCurrentHoveredFactoryObject(null);
				SetCursor();
			}
		}

		private void UpdateCursor(FactoryObject newFactoryObject)
		{
			if (_currentHoveredFactoryObject != null)
			{
				_factoryObjectsDeSelectedEvent.Fire(new List<int> { _currentHoveredFactoryObject.CreatedId });
			}
			if (!_isFreeCamera)
			{
				UpdateCurrentHoveredFactoryObject(newFactoryObject);
				_newFactoryObjectsSelectedEvent.Fire(new List<int> { _currentHoveredFactoryObject.CreatedId });
				if (newFactoryObject.FactoryObjectData.UIData != null && newFactoryObject.FactoryObjectData.UIData.IsConfigurable)
				{
					_setCursorEvent.Fire((_configurableCursorTexture, string.Empty, _cursorOffset));
				}
				else
				{
					SetCursor();
				}
			}
		}

		private FactoryObject GetHoveredFactoryObject(Vector3Int gridPos)
		{
			FactoryObject factoryObject;
			if (_currentHoveredView != null)
			{
				factoryObject = _currentHoveredView.FactoryObject;
			}
			else
			{
				factoryObject = _factoryLayer.Value.GetObjectAt(gridPos);
				if (factoryObject != null && (bool)FactoryObjectViewManager.Instance)
				{
					FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out _currentHoveredView);
				}
			}
			return factoryObject;
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_currentHoveredView == null)
			{
				TryPlayTileMaterialSound(gridPos);
				return;
			}
			if (_currentHoveredView.FactoryObject != null)
			{
				_audioManagerLocator.AudioManager.PlayObjectSelected(gridPos, _currentHoveredView.FactoryObject.FactoryObjectData.ObjectSize);
			}
			if (_currentHoveredView.TryGetComponent<OpenUIOnClick>(out var component))
			{
				component.FireOpenUIEvent();
			}
			_openOperatorToolUsedOnPositionEvent.Fire(gridPos);
		}

		private void TryPlayTileMaterialSound(Vector3Int gridPos)
		{
			if (_islandLayer.TryGetIslandAtWorldPosition(gridPos, out var islandObject) && islandObject.IslandView != null && islandObject.IslandView.IslandData != null)
			{
				if (islandObject.IslandView.IslandData.IsGrass(gridPos))
				{
					UnityEngine.Object.Instantiate(_clickOnGrassParticle, _mouseToGridInput.GetSelectedMapPosition(), Quaternion.identity);
					_audioManagerLocator.AudioManager.PlayClickGrass(gridPos);
				}
				else if (islandObject.IslandView.IslandData.IsTile(gridPos))
				{
					UnityEngine.Object.Instantiate(_clickOnEmptyGroundParticle, _mouseToGridInput.GetSelectedMapPosition(), Quaternion.identity);
					_audioManagerLocator.AudioManager.PlayClickFloorStone(gridPos);
				}
			}
		}

		public override void DoAction(FactoryObject factoryObject)
		{
			_audioManagerLocator.AudioManager.PlayObjectSelected(factoryObject.Position, factoryObject.FactoryObjectData.ObjectSize);
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view) && view.TryGetComponent<OpenUIOnClick>(out var component))
			{
				component.FireOpenUIEvent();
			}
			_openOperatorToolUsedOnPositionEvent.Fire(factoryObject.Position);
		}

		public override void CancelAction()
		{
		}

		private void OnCameraModeChange(bool isFreeCamera)
		{
			_isFreeCamera = isFreeCamera;
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_isFreeCamera = _cameraModeChangedEvent.Value;
			Subscribe();
		}

		public override void DeSelectTool()
		{
			if (_currentHoveredFactoryObject != null)
			{
				_factoryObjectsDeSelectedEvent.Fire(new List<int> { _currentHoveredFactoryObject.CreatedId });
				_currentHoveredFactoryObject = null;
			}
			Unsubscribe();
		}

		private void Subscribe()
		{
			_cameraModeChangedEvent.Register(OnCameraModeChange);
			_copyConfigInputAction.action.performed += CopyConfig;
			_pasteConfigInputAction.action.performed += PasteConfig;
			_pasteConfigInputAction.action.started += StartPastingConfig;
			_pasteConfigInputAction.action.canceled += StopPastingConfig;
		}

		private void Unsubscribe()
		{
			_cameraModeChangedEvent.UnRegister(OnCameraModeChange);
			_copyConfigInputAction.action.performed -= CopyConfig;
			_pasteConfigInputAction.action.performed -= PasteConfig;
			_pasteConfigInputAction.action.started -= StartPastingConfig;
			_pasteConfigInputAction.action.canceled -= StopPastingConfig;
		}

		private void UpdateCurrentHoveredFactoryObject(FactoryObject factoryObject)
		{
			_currentHoveredFactoryObject = factoryObject;
			if (_isTryingToPasteConfig)
			{
				PasteConfig(showCantPasteText: false);
			}
		}

		private void StartPastingConfig(InputAction.CallbackContext callbackContext)
		{
			_isTryingToPasteConfig = true;
		}

		private void StopPastingConfig(InputAction.CallbackContext callbackContext)
		{
			_isTryingToPasteConfig = false;
		}

		private void CopyConfig(InputAction.CallbackContext callbackContext)
		{
			if (_currentHoveredFactoryObject != null && _currentHoveredFactoryObject.FactoryObjectData.ConfigCanBeCopied)
			{
				_copiedFactoryObjectID = _currentHoveredFactoryObject.ObjectId;
				_copiedFactoryObjectIsBuilding = _currentHoveredFactoryObject.HasFactoryObjectBehaviour(typeof(BuildingBehaviour));
				_copiedConfigurations = _currentHoveredFactoryObject.GetConfigurations().ToArray();
				_copiedOperatorNameLocaKey = _currentHoveredFactoryObject.FactoryObjectData.NameLocKey;
				string localizedText = LocalizationUtility.GetLocalizedText(_copiedOperatorNameLocaKey);
				this.Log("Copied " + localizedText + " config successfully", "CopyConfig", 269);
				string data = string.Format(LocalizationUtility.GetLocalizedText(_copiedConfigLocaKey), localizedText);
				_setFadingCursorTextEvent.Fire(data);
				AnimateOperatorToCursor(_currentHoveredFactoryObject);
			}
		}

		private void PasteConfig(InputAction.CallbackContext callbackContext)
		{
			PasteConfig();
		}

		private void PasteConfig(bool showCantPasteText = true)
		{
			if (_currentHoveredFactoryObject == null)
			{
				return;
			}
			if ((!_copiedFactoryObjectIsBuilding || !_currentHoveredFactoryObject.HasFactoryObjectBehaviour(typeof(BuildingBehaviour))) && _currentHoveredFactoryObject.ObjectId != _copiedFactoryObjectID)
			{
				if (showCantPasteText && !string.IsNullOrEmpty(_copiedOperatorNameLocaKey))
				{
					string localizedText = LocalizationUtility.GetLocalizedText(_copiedOperatorNameLocaKey);
					string localizedText2 = LocalizationUtility.GetLocalizedText(_currentHoveredFactoryObject.FactoryObjectData.NameLocKey);
					this.Log("Can't paste " + localizedText + " config on " + localizedText2, "PasteConfig", 293);
					string data = string.Format(LocalizationUtility.GetLocalizedText(_cantPasteConfigLocaKey), localizedText, localizedText2);
					_setFadingCursorTextEvent.Fire(data);
				}
				return;
			}
			if (_copiedFactoryObjectIsBuilding)
			{
				BehaviourConfigurationDto behaviourConfigurationDto = _currentHoveredFactoryObject.GetConfigurations().FirstOrDefault((BehaviourConfigurationDto c) => c.GetType() == typeof(BuildingCranesBehaviourConfigurationDto));
				for (int num = 0; num < _copiedConfigurations.Length; num++)
				{
					if (_copiedConfigurations[num].GetType() == typeof(BuildingCranesBehaviourConfigurationDto))
					{
						_copiedConfigurations[num] = behaviourConfigurationDto;
					}
				}
			}
			BehaviourSaveStateDto[] saveStates = _currentHoveredFactoryObject.GetSaveStates().ToArray();
			_currentHoveredFactoryObject.UnInitialize();
			_currentHoveredFactoryObject.SetSaveStates(saveStates);
			_currentHoveredFactoryObject.SetConfigurations(_copiedConfigurations);
			_currentHoveredFactoryObject.Initialize();
			string localizedText3 = LocalizationUtility.GetLocalizedText(_currentHoveredFactoryObject.FactoryObjectData.NameLocKey);
			this.Log("Pasted " + localizedText3 + " config successfully", "PasteConfig", 319);
			string data2 = string.Format(LocalizationUtility.GetLocalizedText(_pastedConfigLocaKey), localizedText3);
			_setFadingCursorTextEvent.Fire(data2);
			AnimateOperatorToPlacedOperator(_currentHoveredFactoryObject);
		}

		private void AnimateOperatorToCursor(FactoryObject factoryObject)
		{
			FactoryObjectView hologramObject = CreateHologramObject(factoryObject);
			float z = Vector3.Distance(factoryObject.Position, _cameraLocator.Camera.transform.position) - _animationDistanceFromCursor;
			Vector2 vector = _mousePosition.action.ReadValue<Vector2>();
			Vector3 endValue = _cameraLocator.Camera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, z));
			hologramObject.transform.position = factoryObject.Position + Vector3.one * 0.5f;
			hologramObject.transform.DOMove(endValue, _animationTime);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = hologramObject.transform.DOScale(Vector3.zero, _animationTime);
			tweenerCore.onKill = (TweenCallback)Delegate.Combine(tweenerCore.onKill, (TweenCallback)delegate
			{
				hologramObject.transform.localScale = Vector3.one;
				FactoryObjectViewPoolManager.Instance.ReturnFactoryObject(factoryObject.ObjectId, hologramObject, wasPreview: true);
			});
		}

		private void AnimateOperatorToPlacedOperator(FactoryObject factoryObject)
		{
			FactoryObjectView hologramObject = CreateHologramObject(factoryObject);
			float z = Vector3.Distance(factoryObject.Position, _cameraLocator.Camera.transform.position) - _animationDistanceFromCursor;
			Vector2 vector = _mousePosition.action.ReadValue<Vector2>();
			Vector3 position = _cameraLocator.Camera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, z));
			hologramObject.transform.localScale = Vector3.zero;
			hologramObject.transform.position = position;
			hologramObject.transform.DOMove(factoryObject.Position + Vector3.one * 0.5f, _animationTime);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = hologramObject.transform.DOScale(Vector3.one, _animationTime);
			tweenerCore.onKill = (TweenCallback)Delegate.Combine(tweenerCore.onKill, (TweenCallback)delegate
			{
				hologramObject.transform.localScale = Vector3.one;
				FactoryObjectViewPoolManager.Instance.ReturnFactoryObject(factoryObject.ObjectId, hologramObject, wasPreview: true);
			});
		}

		private FactoryObjectView CreateHologramObject(FactoryObject factoryObject)
		{
			FactoryObjectView factoryObjectView = FactoryObjectViewPoolManager.Instance.GetObject(factoryObject.ObjectId);
			factoryObjectView.gameObject.SetActive(value: true);
			List<Vector3> list = new List<Vector3>();
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				list.Add(occupiedPosition);
			}
			factoryObjectView.transform.position = factoryObject.Position;
			factoryObjectView.transform.localRotation = Quaternion.Euler(0f, factoryObject.Rotation, 0f);
			factoryObjectView.transform.localScale = new Vector3((!factoryObject.Mirrored) ? 1 : (-1), 1f, 1f);
			factoryObjectView.SetAllPreviewPositions(list);
			BlueprintViewEventDto blueprintViewEventDto = new BlueprintViewEventDto(new BlueprintViewDto(), canBePlaced: false);
			BlueprintViewDto.BlueprintViewElementDto element = new BlueprintViewDto.BlueprintViewElementDto(factoryObject.ObjectId, factoryObject.Position, list, factoryObject.Rotation, factoryObject.Mirrored, _copiedConfigurations.ToList(), new List<BehaviourSaveStateDto>());
			factoryObjectView.InitPreview(factoryObject.ObjectId, blueprintViewEventDto, element);
			if (factoryObjectView.TryGetComponent<HologramVFXController>(out var component))
			{
				component.ShowHologramVersion();
			}
			return factoryObjectView;
		}
	}
}
