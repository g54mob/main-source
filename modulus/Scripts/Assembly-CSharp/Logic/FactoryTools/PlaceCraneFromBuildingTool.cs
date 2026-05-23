using System;
using System.Collections.Generic;
using Commands;
using Data.Buildings;
using Data.FactoryFloor.Buildings;
using Data.FeatureFlags.Validators;
using Data.Quests.QuestData;
using Data.Quests.QuestViews;
using Data.Variables;
using Data.Variables.Cranes;
using Events;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/PlaceCraneFromBuildingTool", fileName = "PlaceCraneFromBuildingTool", order = 0)]
	public class PlaceCraneFromBuildingTool : FactoryTool
	{
		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private CraneMaxReach _craneMaxReach;

		[SerializeField]
		private BaseEvent _onPlacedCrane;

		[SerializeField]
		private HologramsQuestData _hologramsQuestData;

		[SerializeField]
		private BaseEvent _selectOpenOperatorToolEvent;

		[SerializeField]
		private float _maxMouseDistanceFromCranePlacingPos = 10f;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private BuildingCranesBehaviour _defaultBuildingCranesBehaviour;

		[SerializeField]
		private Texture2D _defaultCursorTexture;

		[SerializeField]
		private BoolVariableSO _placementLockedToHolograms;

		private string _defaultCursorTextKey;

		[SerializeField]
		private string _limitReachedCursorTextKey;

		[Header("Feature Flag Validators")]
		[SerializeField]
		private EnableCraneLimitValidator _enableCraneLimitValidator;

		private BuildingCranesBehaviour _currentBuildingCranesBehaviour;

		private BuildingCranesView _currentBuildingCranesView;

		private Vector3Int _craneEntrancePos;

		private Vector3Int _craneEntranceDir;

		private bool _validCranePlacement;

		private Vector3Int _cranePos;

		private BuildingBehaviour _buildingBehaviour;

		public override bool CanAutoSwapAwayFrom => false;

		public event Action OnStartPlacingCrane = delegate
		{
		};

		public event Action OnStopPlacingCrane = delegate
		{
		};

		private void Awake()
		{
			_defaultCursorTextKey = _cursorTextKey;
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			this.OnStartPlacingCrane();
		}

		public void SetBuilding(BuildingBehaviour buildingBehaviour)
		{
			_buildingBehaviour = buildingBehaviour;
			_currentBuildingCranesBehaviour = _buildingBehaviour.FactoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>();
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(buildingBehaviour.FactoryObject.CreatedId, out var view))
			{
				_currentBuildingCranesView = view.GetComponent<BuildingCranesView>();
				_currentBuildingCranesView.ShowPossibleCraneEntrancePositions();
			}
			UpdateCursorText();
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			Place(gridPos);
		}

		private void Place(Vector3Int position)
		{
			Vector3 vector = position;
			Vector3 hitPos;
			FactoryObjectView selectedFactoryObjectView = _mouseToGridInput.GetSelectedFactoryObjectView(out hitPos);
			if (selectedFactoryObjectView != null && selectedFactoryObjectView.FactoryObject != null && selectedFactoryObjectView.FactoryObject == _buildingBehaviour.FactoryObject)
			{
				vector = hitPos - Vector3.one * 0.5f;
			}
			if (_currentBuildingCranesBehaviour.GetClosestAvailableCranePos(vector, out var cranePos, out var craneDir))
			{
				_currentBuildingCranesView.ShowCraneEntrancePreview(cranePos, craneDir);
				_craneEntrancePos = cranePos;
				_craneEntranceDir = craneDir;
				_cranePos = _craneEntrancePos + _craneEntranceDir;
				float num = float.MaxValue;
				for (int i = 0; i < _craneMaxReach.Value; i++)
				{
					Vector3Int vector3Int = _craneEntrancePos + _craneEntranceDir * (i + 1);
					float num2 = Vector3.Distance(vector3Int, vector);
					if (num2 < num)
					{
						num = num2;
						_cranePos = vector3Int;
					}
				}
				_validCranePlacement = IsCranePlacementValid(_cranePos, _craneEntrancePos) && (!_placementLockedToHolograms.Value || CheckCraneHologramExistsAt(_cranePos));
				_currentBuildingCranesView.ShowCranePreview(_cranePos);
				if (_enableCraneLimitValidator.IsEnabledFeatureFlag() && _currentBuildingCranesBehaviour.HasReachedCraneLimit)
				{
					_validCranePlacement = false;
				}
				_currentBuildingCranesView.SetCranePreviewValid(_validCranePlacement);
			}
			else
			{
				_currentBuildingCranesView.HideCraneEntrancePreview();
			}
			HideBasedOnDistance(vector);
		}

		private void HideBasedOnDistance(Vector3 mousePos)
		{
			if (Vector3.Distance(mousePos, _cranePos) > _maxMouseDistanceFromCranePlacingPos)
			{
				_validCranePlacement = false;
				_currentBuildingCranesView.HideCraneEntrancePreview();
				ResetCursor();
			}
			else
			{
				UpdateCursorText();
			}
		}

		private bool CheckCraneHologramExistsAt(Vector3Int position)
		{
			bool result = false;
			foreach (KeyValuePair<HologramPlacementData, OnboardingHologramView> spawnedHologram in _hologramsQuestData.SpawnedHolograms)
			{
				if (spawnedHologram.Key.Position == position)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		public bool IsCranePlacementValid(Vector3Int pickupPos, Vector3Int entrancePos)
		{
			return _defaultBuildingCranesBehaviour.IsValidCranePosition(pickupPos, entrancePos);
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (!_validCranePlacement)
			{
				return;
			}
			PlaceCraneFromBuildingCommand command = new PlaceCraneFromBuildingCommand(delete: false, _onPlacedCrane, _currentBuildingCranesBehaviour, _audioManagerLocator, _cranePos, _craneEntrancePos);
			if (_commandManager.DoCommand(command))
			{
				_currentBuildingCranesView.HidePossibleCraneEntrancePositions();
				_currentBuildingCranesView.ShowPossibleCraneEntrancePositions();
				if (_currentBuildingCranesBehaviour.PossibleCranePositions.Count == 0)
				{
					DeSelectTool();
					_selectOpenOperatorToolEvent.Fire();
				}
			}
		}

		public override void CancelAction()
		{
			_currentBuildingCranesView.HidePossibleCraneEntrancePositions();
			this.OnStopPlacingCrane();
		}

		public override void DeSelectTool()
		{
			base.DeSelectTool();
			_currentBuildingCranesView.HidePossibleCraneEntrancePositions();
			_currentBuildingCranesView.HideCraneEntrancePreview();
			this.OnStopPlacingCrane();
		}

		private void UpdateCursorText()
		{
			if (_enableCraneLimitValidator.IsEnabledFeatureFlag())
			{
				_cursorTextKey = (_currentBuildingCranesBehaviour.HasReachedCraneLimit ? _limitReachedCursorTextKey : _defaultCursorTextKey);
				SetCursor();
			}
		}

		private void ResetCursor()
		{
			_cursorTextKey = string.Empty;
			SetCursor(_defaultCursorTexture);
		}
	}
}
