using System;
using DG.Tweening;
using Data.FactoryFloor;
using Data.Operator;
using Data.Quests.QuestData;
using Events;
using Events.FactoryFloor;
using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

public class FactoryObjectPlacementHighlight : MonoBehaviour
{
	private const float HiddenHighlightScale = 0.01f;

	[SerializeField]
	private FactoryObjectData _predicateFactoryObject;

	[Header("Occupied Check")]
	[SerializeField]
	private FactoryObjectView _factoryObjectView;

	[SerializeField]
	private FactoryLayer _editableFactoryLayer;

	[Header("Effect")]
	[SerializeField]
	private GameObject _highlightContainer;

	[Header("Events")]
	[SerializeField]
	private BluePrintEvent _startPreviewEvent;

	[SerializeField]
	protected BaseEvent _stopPreviewEvent;

	[SerializeField]
	private HologramsQuestData _hologramsQuestData;

	[SerializeField]
	private FactoryObjectViewCullingController _factoryObjectViewCullingController;

	[SerializeField]
	private PreviewSystemLocator _previewSystemLocator;

	private Vector3 _highlightInitialScale;

	private bool _isShown;

	public void Start()
	{
		_startPreviewEvent.Register(TryShow);
		_stopPreviewEvent.Register(Hide);
		FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
		factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullingChanged));
		_highlightInitialScale = _highlightContainer.transform.localScale;
		_highlightContainer.SetActive(value: false);
		_highlightContainer.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
	}

	public void OnDestroy()
	{
		_startPreviewEvent.UnRegister(TryShow);
		_stopPreviewEvent.UnRegister(Hide);
		FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
		factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullingChanged));
	}

	private void OnCullingChanged(CullableObjectState _, CullableObjectState __)
	{
		TryShow();
	}

	private void TryShow(BlueprintViewEventDto _ = null)
	{
		if (!DisableHighlightDuringTutorial() && _factoryObjectView.FactoryObject != null && !_factoryObjectViewCullingController.IsCulledOrShadowsOnly && _editableFactoryLayer.CanPlaceObjectAt(_factoryObjectView.FactoryObject.Position) && _previewSystemLocator.PreviewSystem.IsPreviewing(_predicateFactoryObject))
		{
			Show();
		}
		else
		{
			Hide();
		}
	}

	private bool DisableHighlightDuringTutorial()
	{
		if (_hologramsQuestData == null)
		{
			return false;
		}
		return _hologramsQuestData.SpawnedHolograms.Count > 0;
	}

	private void Show()
	{
		if (!_isShown)
		{
			_isShown = true;
			_highlightContainer.SetActive(value: true);
			_highlightContainer.transform.DOKill();
			_highlightContainer.transform.DOScale(_highlightInitialScale, 0.25f).SetEase(Ease.OutBack);
		}
	}

	private void Hide()
	{
		if (_isShown)
		{
			_isShown = false;
			_highlightContainer.transform.DOKill();
			_highlightContainer.transform.DOScale(0.01f, 0.5f).SetEase(Ease.OutBack).OnComplete(OnHideAnimationComplete);
		}
	}

	private void OnHideAnimationComplete()
	{
		_highlightContainer.SetActive(value: false);
	}
}
