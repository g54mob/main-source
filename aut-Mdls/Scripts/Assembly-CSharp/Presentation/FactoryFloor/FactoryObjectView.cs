#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using CustomAttributes.PrefabPlaceBrushTool;
using Data.FactoryFloor;
using Events.FactoryFloor;
using NaughtyAttributes;
using Presentation.FactoryFloor.FactoryObjectViews;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class FactoryObjectView : MonoBehaviour, IPoolableComponent
	{
		[OnValueChanged("SetNonChangable")]
		[SerializeField]
		private bool _isNonChangable;

		[SerializeField]
		private Vector3Int _gridCellSize = new Vector3Int(1, 1, 1);

		[SerializeField]
		private List<Vector3Int> _relativePositions = new List<Vector3Int> { Vector3Int.zero };

		[SerializeField]
		private EraseGrassEventSO _eraseGrassEvent;

		[SerializeField]
		private UneraseGrassEventSO _uneraseGrassEvent;

		[SerializeField]
		private bool _drawGizmos;

		[SerializeField]
		private bool _grassTiles;

		[SerializeField]
		private FactoryObjectViewAudioData _audioDataView;

		private FactoryObject _factoryObject;

		private bool _isPreparedToShow;

		public bool IsSelected { get; private set; }

		public bool GrassTiles => _grassTiles;

		public FactoryObject FactoryObject => _factoryObject;

		public bool IsNonChangable => _isNonChangable;

		public int CreatedId => _factoryObject.CreatedId;

		public List<Vector3Int> RelativePositions => _relativePositions;

		public event Action<int, BlueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto> OnInitPreview = delegate
		{
		};

		public event Action<BlueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto> OnUpdatePreview = delegate
		{
		};

		public event Action<FactoryObject, bool> FactoryObjectSet;

		public event Action<List<Vector3>> PreviewingPositions;

		public event Action<FactoryObjectView> FactoryObjectReset;

		public event Action<bool> ValidPositionChanged;

		public event Action ObjectSelected;

		public event Action ObjectDeSelected;

		public event Action ObjectHovered;

		public event Action ObjectHoverStopped;

		public event Action<bool> OnShowView = delegate
		{
		};

		public event Action<bool> OnHideView = delegate
		{
		};

		public void InitPreview(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			this.OnInitPreview(objectId, blueprintViewEventDto, element);
			if (_audioDataView != null)
			{
				_audioDataView.SetAudioEmitState(canEmit: false);
			}
		}

		public void UpdatePreview(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			this.OnUpdatePreview(blueprintViewEventDto, element);
		}

		public void Show(bool isLoading)
		{
			if (!_isPreparedToShow)
			{
				_isPreparedToShow = false;
				return;
			}
			base.gameObject.SetActive(value: true);
			_isPreparedToShow = false;
		}

		public void PrepareShow(bool isLoading)
		{
			_isPreparedToShow = true;
			this.OnShowView(isLoading);
			if (_factoryObject == null)
			{
				this.LogError($"Factory object is null in FOView {base.gameObject.name} {base.transform.position}", "PrepareShow", 84);
			}
			else
			{
				_isNonChangable = _factoryObject.NonChangable;
			}
		}

		public void Hide(bool wasPreview = false)
		{
			if (_isPreparedToShow)
			{
				Show(isLoading: false);
			}
			base.gameObject.SetActive(value: false);
			this.OnHideView(wasPreview);
		}

		private void OnValidate()
		{
			RelativeGridPositionsCalculator.GridCellSize = _gridCellSize;
		}

		public virtual void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading)
		{
			if (factoryObject == null)
			{
				this.DevException($"Got a null factoryobject {base.gameObject.name} {base.transform.position}", "SetFactoryObject", 113);
				return;
			}
			_factoryObject = factoryObject;
			EraseGrass();
			this.FactoryObjectSet?.Invoke(factoryObject, isGameLoading);
		}

		private void EraseGrass()
		{
			if (_eraseGrassEvent != null && _factoryObject != null && _factoryObject.OccupiedPositions != null)
			{
				_eraseGrassEvent.Fire(_factoryObject.OccupiedPositions);
			}
		}

		private void UneraseGrass()
		{
			if (_uneraseGrassEvent != null && _factoryObject != null && _factoryObject.OccupiedPositions != null)
			{
				_uneraseGrassEvent.Fire(_factoryObject.OccupiedPositions);
			}
		}

		public void SetAllPreviewPositions(List<Vector3> allPositions)
		{
			this.PreviewingPositions?.Invoke(allPositions);
		}

		public void ValidPosition(bool validPosition)
		{
			this.ValidPositionChanged?.Invoke(validPosition);
		}

		public void Reset(bool wasPreview = false)
		{
			UneraseGrass();
			this.FactoryObjectReset?.Invoke(this);
			_factoryObject = null;
			Hide(wasPreview);
		}

		public void SetRelativePositions(List<Vector3Int> relativePositions)
		{
			_relativePositions = relativePositions;
		}

		public void Hover()
		{
			this.ObjectHovered?.Invoke();
		}

		public void HoverStopped()
		{
			this.ObjectHoverStopped?.Invoke();
		}

		public void Select()
		{
			IsSelected = true;
			this.ObjectSelected?.Invoke();
		}

		public void DeSelect()
		{
			IsSelected = false;
			this.ObjectDeSelected?.Invoke();
		}

		public void OnReturnToPool()
		{
			base.gameObject.SetActive(value: false);
		}

		public void OnRetrieveFromPool()
		{
			base.gameObject.SetActive(value: true);
		}

		public void OnDestroy()
		{
			_factoryObject = null;
		}
	}
}
