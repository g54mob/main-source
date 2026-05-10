using System;
using CTS.Core;
using DG.Tweening;
using UnityEngine;

namespace CTS.UI
{
	public class ButtonHoverTweens : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private SoftReference<ISelectable> _selectable;

		[SerializeField]
		[Inject(false)]
		private Transform _transformToApply;

		[SerializeField]
		private Vector3 _normalScale = Vector3.one;

		[SerializeField]
		private Vector3 _hoverScale = new Vector3(1.2f, 1.2f, 1.2f);

		[SerializeField]
		private Ease _hoverEase = Ease.Linear;

		[SerializeField]
		private float _hoverDuration = 1f;

		[SerializeField]
		private Vector3 _pressedScale = new Vector3(0.8f, 0.8f, 0.8f);

		[SerializeField]
		private Ease _pressedEase = Ease.Linear;

		[SerializeField]
		private float _pressedDuration = 1f;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_selectable.Value.SelectionStateChanged += OnStateChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_selectable.Value.SelectionStateChanged -= OnStateChanged;
			_transformToApply.localScale = _normalScale;
		}

		private void OnStateChanged(ESelectionState obj)
		{
			if (base.gameObject.scene.isLoaded)
			{
				_transformToApply.DOKill();
				switch (obj)
				{
				case ESelectionState.Normal:
				case ESelectionState.Selected:
				case ESelectionState.Disabled:
					_transformToApply.DOScale(_normalScale, 0.25f).SetUpdate(isIndependentUpdate: true);
					break;
				case ESelectionState.Highlighted:
					_transformToApply.DOScale(_hoverScale, _hoverDuration).SetEase(_hoverEase).SetUpdate(isIndependentUpdate: true);
					break;
				case ESelectionState.Pressed:
					_transformToApply.DOScale(_pressedScale, _pressedDuration).SetEase(_pressedEase).SetUpdate(isIndependentUpdate: true);
					break;
				default:
					throw new ArgumentOutOfRangeException("obj", obj, null);
				}
			}
		}
	}
}
