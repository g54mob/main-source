using System;
using DG.Tweening;
using Restory.Utils;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters
{
	public class GUI_ToggleSlider : MonoBehaviour
	{
		[Serializable]
		private struct TargetImage
		{
			public Image Target;

			public Sprite OnSprite;

			public Sprite OffSprite;
		}

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private RectTransform target;

		[SerializeField]
		private TargetImage[] targetImages = Array.Empty<TargetImage>();

		[SerializeField]
		private Vector3 onPosition = Vector3.zero;

		[SerializeField]
		private Vector3 offPosition = Vector3.right;

		[SerializeField]
		private Ease ease = Ease.OutCubic;

		[SerializeField]
		[Min(0f)]
		private float duration = 0.25f;

		private Sequence sequence;

		private TweenSequencesService tweenSequencesService;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void Reset()
		{
			toggle = GetComponent<Toggle>();
			target = GetComponentInChildren<RectTransform>();
		}

		private void OnEnable()
		{
			UpdateView();
			toggle.onValueChanged.AddListener(ResolveOnToggleValueChanged);
		}

		private void OnDisable()
		{
			toggle.onValueChanged.RemoveListener(ResolveOnToggleValueChanged);
		}

		private void UpdateView()
		{
			if (tweenSequencesService == null)
			{
				targetImages.ForEach(delegate(TargetImage image)
				{
					image.Target.sprite = (toggle.isOn ? image.OnSprite : image.OffSprite);
				});
				target.anchoredPosition = (toggle.isOn ? onPosition : offPosition);
				return;
			}
			tweenSequencesService.Kill(sequence);
			sequence = tweenSequencesService.Create();
			sequence.AppendCallback(delegate
			{
				targetImages.ForEach(delegate(TargetImage image)
				{
					image.Target.sprite = (toggle.isOn ? image.OnSprite : image.OffSprite);
				});
			});
			sequence.Append(target.DOAnchorPos(toggle.isOn ? onPosition : offPosition, duration).SetEase(ease)).SetUpdate(isIndependentUpdate: true);
		}

		private void ResolveOnToggleValueChanged(bool value)
		{
			UpdateView();
		}
	}
}
