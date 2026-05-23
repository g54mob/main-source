using Data.FactoryFloor;
using Data.FactoryFloor.Tools;
using Data.Variables;
using Events.FactoryFloor;
using Events.Generic;
using Presentation.FactoryFloor.FactoryObjectViews;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class FactoryObjectSelectedVisuals : MonoBehaviour
	{
		[SerializeField]
		private FactoryObjectView _factoryObjectView;

		[SerializeField]
		private FloatVariableSO _cameraZoomLevelPerc;

		[SerializeField]
		private HighlightOutline _highlightOutline;

		[SerializeField]
		private ToolColorLibrary _toolColorLibrary;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		private HologramVFXController _hologramVFXController;

		private bool _validPlacement = true;

		private void Awake()
		{
			_factoryObjectView.ValidPositionChanged += ValidPositionChanged;
			_factoryObjectView.ObjectSelected += ObjectSelected;
			_factoryObjectView.ObjectDeSelected += ObjectDeSelected;
			if (_hologramVFXController != null)
			{
				_factoryObjectView.OnInitPreview += ShowHologram;
				_factoryObjectView.FactoryObjectSet += ShowNormalVersion;
			}
		}

		private void OnDestroy()
		{
			_factoryObjectView.ValidPositionChanged -= ValidPositionChanged;
			_factoryObjectView.ObjectSelected -= ObjectSelected;
			_factoryObjectView.ObjectDeSelected -= ObjectDeSelected;
			if (_hologramVFXController != null)
			{
				_factoryObjectView.OnInitPreview -= ShowHologram;
				_factoryObjectView.FactoryObjectSet -= ShowNormalVersion;
			}
		}

		private void ShowNormalVersion(FactoryObject _, bool isGameLoading)
		{
			if (isGameLoading)
			{
				_hologramVFXController.ShowNormalVersion();
			}
			else
			{
				_hologramVFXController.AnimateToNormalVersion();
			}
		}

		private void ShowHologram(int _, BlueprintViewEventDto __, BlueprintViewDto.BlueprintViewElementDto ___)
		{
			_hologramVFXController.ShowHologramVersion();
		}

		public void ValidPositionChanged(bool isValid)
		{
			_validPlacement = isValid;
			UpdateValidVisuals();
		}

		private void UpdateValidVisuals()
		{
			_highlightOutline.SetColor(_validPlacement ? _toolColorLibrary.ValidPlacementColor : _toolColorLibrary.InvalidPlacementColor);
			if ((bool)_hologramVFXController)
			{
				if (_validPlacement)
				{
					_hologramVFXController.SetValidColors();
				}
				else
				{
					_hologramVFXController.SetInvalidColors();
				}
			}
		}

		private void ObjectSelected()
		{
			_highlightOutline.SetColor(_updateSelectionBoxColor ? _updateSelectionBoxColor.Value : _toolColorLibrary.SelectToolColor);
			_highlightOutline.Show();
		}

		private void ObjectDeSelected()
		{
			_highlightOutline.Hide();
		}
	}
}
