using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.UI
{
	[RequireComponent(typeof(CanvasGroupController))]
	public abstract class CanvasGroupTweenEffect : MonoBehaviour
	{
		[SerializeField]
		[Header("Show")]
		private bool _showEffect;

		[SerializeField]
		[ShowIf("_showEffect")]
		protected float _showDuration = 0.25f;

		[SerializeField]
		[ShowIf("_showEffect")]
		protected Ease _showEase = Ease.Linear;

		[SerializeField]
		[Header("Hide")]
		private bool _hideEffect;

		[SerializeField]
		[ShowIf("_hideEffect")]
		protected float _hideDuration = 0.25f;

		[SerializeField]
		[ShowIf("_hideEffect")]
		protected Ease _hideEase = Ease.Linear;

		protected CanvasGroupController _groupController;

		protected CanvasGroup CanvasGroup => _groupController.CanvasGroup;

		protected RectTransform RectTransform => _groupController.RectTransform;

		private void Awake()
		{
			_groupController = GetComponent<CanvasGroupController>();
		}

		private void OnEnable()
		{
			if ((bool)_groupController && !_groupController.Effects.Contains(this))
			{
				_groupController.Effects.Add(this);
			}
		}

		private void OnDestroy()
		{
			if ((bool)_groupController)
			{
				_groupController.Effects.Remove(this);
			}
		}

		public Tween PlayEffect(bool show)
		{
			if (show && _showEffect)
			{
				return ShowEffect();
			}
			if (!show && _hideEffect)
			{
				return HideEffect();
			}
			return DOTween.Sequence().AppendCallback(delegate
			{
				SetToResult(show);
			});
		}

		public void SetToResult(bool show)
		{
			if (show)
			{
				SetShowResult();
			}
			else
			{
				SetHideResult();
			}
		}

		protected abstract Tween ShowEffect();

		protected abstract Tween HideEffect();

		protected abstract void SetShowResult();

		protected abstract void SetHideResult();
	}
}
