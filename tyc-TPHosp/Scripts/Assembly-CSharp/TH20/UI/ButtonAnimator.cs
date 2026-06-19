using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace TH20.UI
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform), typeof(DynamicButton))]
	public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Serializable]
		public class ChangeStateEvent : UnityEvent<State>
		{
		}

		public class RefreshSpriteEvent : UnityEvent<State>
		{
		}

		public enum State
		{
			Selectable = 0,
			Selected = 1,
			Unselectable = 2
		}

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private ButtonAnimatorPreset _preset;

		[SerializeField]
		private ChangeStateEvent _onChangeState;

		[SerializeField]
		private RefreshSpriteEvent _onRefreshSprite;

		[SerializeField]
		private RectTransform[] _additiontalAnimationTargets;

		[SerializeField]
		private State _currentState;

		private bool _isOver;

		private Vector2 _initialButtonImageSizeDelta;

		private Vector2[] _additonalInitialButtonImageSizeDelta;

		private Vector2 _restingButtonImageSizeDelta;

		private Vector2[] _additonalRestingButtonImageSizeDelta;

		private float _mouseOverIntroTime;

		private float _mouseOverOutroTime;

		private RectTransform ButtonImageRectTransform
		{
			get
			{
				if (_button.image == null)
				{
					return null;
				}
				return _button.image.GetComponent<RectTransform>();
			}
		}

		public DynamicButton Button => _button;

		public ChangeStateEvent OnChangeState => _onChangeState;

		public RefreshSpriteEvent OnRefreshSprite => _onRefreshSprite;

		public bool PresetHasSprites
		{
			get
			{
				if (_preset != null)
				{
					if (!(_preset.SelectedBackgroundSprite != null))
					{
						return _preset.UnselectableBackgroundSprite != null;
					}
					return true;
				}
				return false;
			}
		}

		public State CurrentState
		{
			get
			{
				return _currentState;
			}
			set
			{
				if (!(_button == null) && !(_button.image == null) && !(_preset == null) && _currentState != value)
				{
					_currentState = value;
					RefreshButtonSprite();
					_onChangeState.Invoke(_currentState);
				}
			}
		}

		protected void Start()
		{
			RectTransform buttonImageRectTransform = ButtonImageRectTransform;
			if (_additiontalAnimationTargets == null)
			{
				_additiontalAnimationTargets = new RectTransform[0];
			}
			_additonalInitialButtonImageSizeDelta = new Vector2[_additiontalAnimationTargets.Length];
			_additonalRestingButtonImageSizeDelta = new Vector2[_additiontalAnimationTargets.Length];
			if (buttonImageRectTransform != null)
			{
				_restingButtonImageSizeDelta = buttonImageRectTransform.sizeDelta;
				_initialButtonImageSizeDelta = buttonImageRectTransform.sizeDelta;
			}
			for (int i = 0; i < _additiontalAnimationTargets.Length; i++)
			{
				_additonalRestingButtonImageSizeDelta[i] = _additiontalAnimationTargets[i].sizeDelta;
				_additonalInitialButtonImageSizeDelta[i] = _additiontalAnimationTargets[i].sizeDelta;
			}
			RefreshButtonSprite();
		}

		protected void Reset()
		{
			_currentState = State.Selectable;
			if (_button != null && _button.image != null)
			{
				_button.image.overrideSprite = null;
			}
			_button = GetComponent<DynamicButton>();
			RefreshButtonSprite();
		}

		protected void OnEnable()
		{
			RefreshButtonSprite();
		}

		protected void OnDisable()
		{
			if (_button != null && _button.image != null && PresetHasSprites)
			{
				_button.image.overrideSprite = null;
			}
		}

		protected void Update()
		{
			if (_preset == null)
			{
				return;
			}
			bool isOver = _isOver;
			if (_isOver && (_preset.AnimateIfUnselectable || CurrentState != State.Unselectable))
			{
				_mouseOverIntroTime += Time.unscaledDeltaTime;
			}
			else
			{
				_mouseOverOutroTime += Time.unscaledDeltaTime;
				isOver = false;
			}
			if (!_preset.PointerOverAnimation)
			{
				return;
			}
			RectTransform buttonImageRectTransform = ButtonImageRectTransform;
			if (buttonImageRectTransform != null)
			{
				UpdateAnimationTarget(_preset, isOver, buttonImageRectTransform, _mouseOverIntroTime, _mouseOverOutroTime, _initialButtonImageSizeDelta, _restingButtonImageSizeDelta);
				for (int i = 0; i < _additiontalAnimationTargets.Length; i++)
				{
					UpdateAnimationTarget(_preset, isOver, _additiontalAnimationTargets[i], _mouseOverIntroTime, _mouseOverOutroTime, _additonalInitialButtonImageSizeDelta[i], _additonalRestingButtonImageSizeDelta[i]);
				}
			}
		}

		private static void UpdateAnimationTarget(ButtonAnimatorPreset preset, bool isOver, RectTransform animationTarget, float introTime, float outroTime, Vector2 initialSizeDelta, Vector2 restingSizeDelta)
		{
			Vector2 sizeDelta;
			if (isOver)
			{
				float t = EasingsUtils.Interpolate(Mathf.Clamp01(introTime / preset.MousOverIntoDuration), preset.MouseOverIntoEaseFunction);
				sizeDelta = Vector2.LerpUnclamped(initialSizeDelta, restingSizeDelta + preset.PointerOverSizeDelta, t);
			}
			else
			{
				float t2 = EasingsUtils.Interpolate(Mathf.Clamp01(outroTime / preset.MousOverOutroDuration), preset.MouseOverOutroEaseFunction);
				sizeDelta = Vector2.LerpUnclamped(initialSizeDelta, restingSizeDelta, t2);
			}
			Vector2 sizeDelta2 = animationTarget.sizeDelta;
			if (!Mathf.Approximately(sizeDelta.x, sizeDelta2.x) || !Mathf.Approximately(sizeDelta.y, sizeDelta2.y))
			{
				animationTarget.sizeDelta = sizeDelta;
			}
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			_isOver = false;
			_mouseOverOutroTime = 0f;
			RectTransform buttonImageRectTransform = ButtonImageRectTransform;
			if (buttonImageRectTransform != null)
			{
				_initialButtonImageSizeDelta = buttonImageRectTransform.sizeDelta;
			}
			for (int i = 0; i < _additiontalAnimationTargets.Length; i++)
			{
				_additonalInitialButtonImageSizeDelta[i] = _additiontalAnimationTargets[i].sizeDelta;
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			_isOver = true;
			_mouseOverIntroTime = 0f;
			RectTransform buttonImageRectTransform = ButtonImageRectTransform;
			if (buttonImageRectTransform != null)
			{
				_initialButtonImageSizeDelta = buttonImageRectTransform.sizeDelta;
			}
			for (int i = 0; i < _additiontalAnimationTargets.Length; i++)
			{
				_additonalInitialButtonImageSizeDelta[i] = _additiontalAnimationTargets[i].sizeDelta;
			}
		}

		public void AddRefreshSpriteListener(UnityAction<State> call)
		{
			if (_onRefreshSprite == null)
			{
				_onRefreshSprite = new RefreshSpriteEvent();
			}
			_onRefreshSprite.AddListener(call);
		}

		public void RemoveRefreshSpriteListeners()
		{
			if (_onRefreshSprite != null)
			{
				OnRefreshSprite.RemoveAllListeners();
			}
		}

		public void RefreshButtonSprite()
		{
			switch (_currentState)
			{
			case State.Selectable:
				if (PresetHasSprites)
				{
					_button.image.overrideSprite = null;
				}
				_button.interactable = true;
				break;
			case State.Selected:
				if (PresetHasSprites)
				{
					_button.image.overrideSprite = _preset.SelectedBackgroundSprite;
				}
				_button.interactable = true;
				break;
			case State.Unselectable:
				if (PresetHasSprites)
				{
					_button.image.overrideSprite = _preset.UnselectableBackgroundSprite;
				}
				_button.interactable = false;
				break;
			}
			if (_onRefreshSprite != null)
			{
				_onRefreshSprite.Invoke(_currentState);
			}
		}
	}
}
