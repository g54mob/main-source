using DG.Tweening;
using Data.FactoryFloor.GameMode;
using Data.Operator;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory;
using UnityEngine;

namespace Presentation.FactoryFloor.SpaceRestrictor
{
	public class SpaceRestrictorView : MonoBehaviour
	{
		[SerializeField]
		private BoolEvent _buildModeEvent;

		[SerializeField]
		private CurrentGameMode _currentGameMode;

		[SerializeField]
		private GameModeSO _levelEditorGameMode;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private FactoryObjectData _restrictedAreaData;

		[SerializeField]
		private Material _material;

		[SerializeField]
		private float _defaultAlpha;

		[SerializeField]
		private float _secondsToFade = 0.25f;

		[SerializeField]
		private Ease _easeFade = Ease.InOutSine;

		private bool _isInEditor;

		private bool _isBuilding;

		private bool _isPreviewing;

		private void Awake()
		{
			_currentGameMode.CurrentGameModeChanged += HandleGameModeChanged;
			_startPreviewEvent.Register(OnStartPreview);
			_stopPreviewEvent.Register(OnStopPreview);
			_buildModeEvent.Register(HandleBuildModeChanged);
			_isBuilding = false;
			HandleGameModeChanged(_currentGameMode.Mode);
			Color color = _material.color;
			color.a = 0f;
			_material.color = color;
		}

		private void OnDestroy()
		{
			_buildModeEvent.UnRegister(HandleBuildModeChanged);
			_currentGameMode.CurrentGameModeChanged -= HandleGameModeChanged;
			_startPreviewEvent.UnRegister(OnStartPreview);
			_stopPreviewEvent.UnRegister(OnStopPreview);
			Color color = _material.color;
			color.a = _defaultAlpha;
			_material.color = color;
		}

		private void HandleGameModeChanged(GameModeSO current)
		{
			_isInEditor = _levelEditorGameMode == current;
			UpdateVisuals();
		}

		private void HandleBuildModeChanged(bool isInBuildMode)
		{
			_isBuilding = isInBuildMode;
			UpdateVisuals();
		}

		private void OnStartPreview(BlueprintViewEventDto dto)
		{
			if (!_isInEditor)
			{
				return;
			}
			foreach (BlueprintViewDto.BlueprintViewElementDto blueprintViewElementDto in dto.Blueprint.BlueprintViewElementDtos)
			{
				if (blueprintViewElementDto.ObjectId == _restrictedAreaData.ID)
				{
					_isPreviewing = true;
					UpdateVisuals();
					break;
				}
			}
		}

		private void OnStopPreview()
		{
			_isPreviewing = false;
			UpdateVisuals();
		}

		private void UpdateVisuals()
		{
			float endValue = ((_isBuilding || _isPreviewing) ? _defaultAlpha : 0f);
			_material.DOFade(endValue, _secondsToFade).SetEase(Ease.InOutSine);
		}
	}
}
