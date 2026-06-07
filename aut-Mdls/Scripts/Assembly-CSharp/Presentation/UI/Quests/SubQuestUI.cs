using System.Collections;
using DG.Tweening;
using Data.Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Quests
{
	public class SubQuestUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _descriptionText;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private GameObject _completedObject;

		[SerializeField]
		private Image _completedIcon;

		[SerializeField]
		private Image _activeObject;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private GameObject _progressPanel;

		[SerializeField]
		private TextMeshProUGUI _progressText;

		[SerializeField]
		private Image _progressBar;

		[SerializeField]
		private Color _completedBgColor;

		[SerializeField]
		private Color _completedTextColor;

		protected SubQuestSO _subQuest;

		public SubQuestSO SubQuest => _subQuest;

		public bool IsMarkedCompleted { get; private set; }

		public bool IsShownCompleted { get; private set; }

		protected virtual void Awake()
		{
			_activeObject.gameObject.SetActive(value: false);
			_completedObject.SetActive(value: false);
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_rectTransform.anchoredPosition = new Vector2(-1000f, _rectTransform.anchoredPosition.y);
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		public virtual void Show(SubQuestSO subQuest)
		{
			_subQuest = subQuest;
			_descriptionText.SetText(subQuest.SubQuestDescription);
			_rectTransform.DOAnchorPosX(0f, 0.5f).SetEase(Ease.OutQuad);
			if (!_subQuest.Validator.HasProgress)
			{
				_progressPanel.SetActive(value: false);
				return;
			}
			_progressPanel.SetActive(value: true);
			StartCoroutine(UpdateProgress());
		}

		private void OnLanguageUpdate()
		{
			if (_subQuest != null)
			{
				_descriptionText.SetText(_subQuest.SubQuestDescription);
			}
		}

		private IEnumerator UpdateProgress()
		{
			float currentProgress = _subQuest.Validator.GetProgress();
			float targetProgress = _subQuest.Validator.GetProgressTarget();
			while (currentProgress < targetProgress)
			{
				currentProgress = _subQuest.Validator.GetProgress();
				SetProgress(currentProgress, targetProgress);
				yield return new WaitForSeconds(0.1f);
			}
		}

		protected virtual void SetProgress(float current, float target = 1f)
		{
			_progressText.SetText($"{(int)current}/{(int)target}");
			_progressBar.rectTransform.DOScaleX(current / target, 0.3f).SetEase(Ease.OutCubic);
		}

		public virtual void MarkAsStarted()
		{
			_activeObject.gameObject.SetActive(value: true);
		}

		public void MarkAsCompleted()
		{
			IsMarkedCompleted = true;
		}

		public virtual void ShowAsCompleted()
		{
			IsShownCompleted = true;
			_activeObject.gameObject.SetActive(value: false);
			_completedObject.SetActive(value: true);
			Sequence sequence = DOTween.Sequence();
			sequence.Append(_completedIcon.rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.one * 8f));
			sequence.Join(_completedIcon.rectTransform.DORotate(Vector3.zero, 0.4f).From(Vector3.forward * 60f));
			sequence.Join(_completedIcon.DOFade(1f, 0.1f).From(0f));
			sequence.PrependInterval(0.25f);
			sequence.Play();
			_progressPanel.SetActive(value: false);
			_descriptionText.DOColor(_completedTextColor, 0.4f);
			_backgroundImage.DOColor(_completedBgColor, 1f).From(_completedTextColor);
		}

		public void Hide(int index)
		{
			_rectTransform.DOAnchorPos(new Vector2(-1000f, _rectTransform.anchoredPosition.y), 0.5f).OnComplete(delegate
			{
				Object.Destroy(base.gameObject);
			}).SetEase(Ease.InBack)
				.SetDelay((float)index / 20f);
		}
	}
}
