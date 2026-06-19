using Coffee.UIEffects;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD.Assistant
{
	public class AssistantMissionView : UIView
	{
		[SerializeField]
		private TextMeshProUGUI _counteText;

		[SerializeField]
		private TextMeshProUGUI _descriptionText;

		[SerializeField]
		private TextMeshProUGUI _objectiveText;

		[SerializeField]
		private Image _tickImage;

		[SerializeField]
		private UIEffect _shineEffect;

		[Header("Appear Animation")]
		[SerializeField]
		private Color _goldColor = new Color(1f, 0.84f, 0.1f, 1f);

		[SerializeField]
		private float _animDuration = 0.5f;

		[Header("Completion Animation")]
		[SerializeField]
		private float _stampDuration = 0.25f;

		[SerializeField]
		private float _stampStartScale = 2.8f;

		[SerializeField]
		private float _squishScaleX = 1.25f;

		[SerializeField]
		private float _squishScaleY = 0.75f;

		[SerializeField]
		private float _bounceAmount = 8f;

		[SerializeField]
		private float _bounceDuration = 0.15f;

		private bool _wasCompleted;

		public bool Completed
		{
			get
			{
				return _wasCompleted;
			}
			set
			{
				if (value && !_wasCompleted)
				{
					PlayCompletionAnimation();
				}
				_wasCompleted = value;
			}
		}

		public void CreateBinding()
		{
			BindingSet<AssistantMissionView, AssistantMissionViewModel> bindingSet = this.CreateBindingSet<AssistantMissionView, AssistantMissionViewModel>();
			bindingSet.Bind(_counteText).For((TextMeshProUGUI v) => v.text).To((AssistantMissionViewModel vm) => vm.MissionCount)
				.OneWay();
			bindingSet.Bind(_descriptionText).For((TextMeshProUGUI v) => v.text).To((AssistantMissionViewModel vm) => vm.Description)
				.OneWay();
			bindingSet.Bind(_objectiveText).For((TextMeshProUGUI v) => v.text).To((AssistantMissionViewModel vm) => vm.ObjectiveCount)
				.OneWay();
			bindingSet.Bind(_objectiveText.gameObject).For((GameObject v) => v.activeSelf).To((AssistantMissionViewModel vm) => vm.ObjectiveCountable)
				.OneWay();
			bindingSet.Bind(_tickImage.gameObject).For((GameObject v) => v.activeSelf).To((AssistantMissionViewModel vm) => vm.Completed)
				.OneWay();
			bindingSet.Bind(_shineEffect).For((UIEffect v) => v.enabled).To((AssistantMissionViewModel vm) => vm.Completed)
				.WithConversion("InverseBool")
				.OneWay();
			bindingSet.Bind(this).For((AssistantMissionView v) => v.Completed).To((AssistantMissionViewModel vm) => vm.Completed)
				.OneWay();
			bindingSet.Build();
		}

		protected override void Start()
		{
			PlayAppearAnimation();
		}

		private void PlayAppearAnimation()
		{
			TextMeshProUGUI[] array = new TextMeshProUGUI[3] { _counteText, _descriptionText, _objectiveText };
			for (int i = 0; i < array.Length; i++)
			{
				TextMeshProUGUI textMeshProUGUI = array[i];
				if (!(textMeshProUGUI == null))
				{
					Color color = textMeshProUGUI.color;
					textMeshProUGUI.color = _goldColor;
					textMeshProUGUI.transform.localScale = Vector3.one * 1.15f;
					float delay = (float)i * 0.07f;
					textMeshProUGUI.transform.DOScale(Vector3.one, _animDuration).SetDelay(delay).SetEase(Ease.OutBack);
					textMeshProUGUI.DOColor(color, _animDuration).SetDelay(delay).SetEase(Ease.InQuad);
				}
			}
		}

		private void PlayCompletionAnimation()
		{
			if (_tickImage == null)
			{
				return;
			}
			_tickImage.gameObject.SetActive(value: true);
			Transform tick = _tickImage.transform;
			tick.localScale = Vector3.one * _stampStartScale;
			tick.DOScale(Vector3.one, _stampDuration).SetEase(Ease.InExpo).OnComplete(delegate
			{
				tick.DOScale(new Vector3(_squishScaleX, _squishScaleY, 1f), 0.07f).SetEase(Ease.OutQuad).OnComplete(delegate
				{
					tick.DOScale(Vector3.one, 0.12f).SetEase(Ease.OutBack).OnComplete(PlayTextBounce);
				});
			});
		}

		private void PlayTextBounce()
		{
			TextMeshProUGUI[] array = new TextMeshProUGUI[3] { _counteText, _descriptionText, _objectiveText };
			foreach (TextMeshProUGUI textMeshProUGUI in array)
			{
				if (!(textMeshProUGUI == null))
				{
					RectTransform rt = textMeshProUGUI.GetComponent<RectTransform>();
					float originalY = rt.anchoredPosition.y;
					rt.DOAnchorPosY(originalY + _bounceAmount, _bounceDuration).SetEase(Ease.OutQuad).OnComplete(delegate
					{
						rt.DOAnchorPosY(originalY, _bounceDuration).SetEase(Ease.InQuad);
					});
				}
			}
		}
	}
}
