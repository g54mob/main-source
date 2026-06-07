using DG.Tweening;
using UnityEngine;

namespace VampireSurvivors
{
	public class CarouselItemUI : MonoBehaviour
	{
		protected CanvasGroup _cg;

		protected float _maxDistance;

		protected float _minAlpha;

		protected float _minScale;

		protected RectTransform _mTrans;

		protected RectTransform _tTrans;

		protected float _progress;

		protected RectTransform _target;

		private Tween _moveTween;

		private Tween _scaleTween;

		public virtual void Initialize(float maxDistance)
		{
		}

		private void OnDestroy()
		{
		}

		private void KillAllTweens()
		{
		}

		public Tween SetTarget(Transform t, bool completeImmediately = false)
		{
			return null;
		}

		private void Update()
		{
		}

		protected virtual void ApplyProgress()
		{
		}

		public virtual void Deselect(bool completeImmediately = false)
		{
		}

		public virtual void Select(bool completeImmediately = false)
		{
		}
	}
}
