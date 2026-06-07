using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS.BBT
{
	internal sealed class UIContextActionsButton : MonoBehaviour
	{
		[SerializeField]
		private Color _normalColor = Color.white;

		[SerializeField]
		private Color _normalTextColor = Color.black;

		[SerializeField]
		private Color _powerColor = Color.red;

		[SerializeField]
		private Color _powerTextColor = Color.white;

		private Image _image;

		private TextMeshProUGUI _choreText;

		private Button _button;

		private Worker _workerRef;

		private WorkerChore _choreRef;

		private ContextualAction _contextualAction;

		private UIContextActionsPanel _panel;

		private HorizontalLayoutGroup _layoutGroup;

		private RectTransform _transform;

		private Tween _currentTween;

		public bool Interactable
		{
			get
			{
				return _button.interactable;
			}
			set
			{
				_button.interactable = value;
			}
		}

		public static event Action<ContextualAction, Worker> ExecutingContextualAction;

		private void Awake()
		{
			_image = GetComponent<Image>();
			_layoutGroup = GetComponent<HorizontalLayoutGroup>();
			_choreText = GetComponentInChildren<TextMeshProUGUI>();
			_button = GetComponent<Button>();
			_panel = GetComponentInParent<UIContextActionsPanel>();
			_transform = base.transform as RectTransform;
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnClick);
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		}

		private void OnDisable()
		{
			if (_currentTween != null && _currentTween.IsActive())
			{
				_currentTween.Kill();
			}
			_button.onClick.RemoveListener(OnClick);
			_choreRef = null;
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		}

		public void Init(Worker p_worker, ContextualAction p_action, int p_index)
		{
			BaseInit(p_worker, p_index);
			_contextualAction = p_action;
			_choreRef = null;
			UpdateText(_contextualAction.GetDisplayName());
			if (p_action is ContextualActionWipeMemory || p_action is ContextualActionHypnosis)
			{
				_image.color = _powerColor;
				_choreText.color = _powerTextColor;
			}
			else
			{
				_image.color = _normalColor;
				_choreText.color = _normalTextColor;
			}
		}

		public void Init(Worker p_worker, WorkerChore p_chore, int p_index)
		{
			BaseInit(p_worker, p_index);
			_contextualAction = null;
			_choreRef = p_chore;
			UpdateText(_choreRef.GetDisplayName());
			_image.color = _normalColor;
			_choreText.color = _normalTextColor;
		}

		private void BaseInit(Worker p_worker, int p_index)
		{
			base.gameObject.SetActive(value: true);
			_workerRef = p_worker;
			base.transform.localScale = Vector3.zero;
			_currentTween = base.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack).SetDelay((float)p_index * 0.075f)
				.SetUpdate(isIndependentUpdate: true);
		}

		private void OnLocaleChanged(Locale obj)
		{
			if (_choreRef != null)
			{
				UpdateText(_choreRef.GetDisplayName());
			}
		}

		private void UpdateText(string p_name)
		{
			_choreText.text = p_name;
			GetComponent<ContentSizeFitter>().SetLayoutHorizontal();
			_layoutGroup.CalculateLayoutInputHorizontal();
			_layoutGroup.SetLayoutHorizontal();
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
		}

		public void UpdatePosition(Vector3 p_center, float p_angle, float p_distance)
		{
			Vector2 vector = Vector2.up.RotateDirection(p_angle) * p_distance;
			base.transform.localPosition = p_center + (Vector3)vector;
			if (p_angle > 190f && p_angle < 350f)
			{
				base.transform.localPosition += Vector3.right * _transform.sizeDelta.x * 0.25f;
			}
			else if (p_angle > 10f && p_angle < 170f)
			{
				base.transform.localPosition -= Vector3.right * _transform.sizeDelta.x * 0.25f;
			}
		}

		private void OnClick()
		{
			TryExecuteAction();
			_panel.SetActive(p_state: false);
			if (!_workerRef)
			{
				WorldSelector.DeselectAll();
			}
		}

		private void TryExecuteAction()
		{
			if (_choreRef != null)
			{
				if ((bool)_workerRef)
				{
					_workerRef.ActionPlayer.ForceAction(_choreRef, EActionPriority.Player);
				}
			}
			else
			{
				UIContextActionsButton.ExecutingContextualAction?.Invoke(_contextualAction, _workerRef);
				_contextualAction.Execute(_workerRef);
			}
		}
	}
}
