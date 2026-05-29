using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class HighlightObject : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Image _image;

		[SerializeField]
		private float _padding = 80f;

		private DOGetter<float> _alphaGetter;

		private DOSetter<float> _alphaSetter;

		private bool _stopping;

		protected override void OnAwake()
		{
			base.OnAwake();
			_alphaGetter = () => _image.color.a;
			_alphaSetter = SetColorAlpha;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.transform.Cast<RectTransform>().sizeDelta = Vector2.one * _padding;
			SetColorAlpha(1f);
			DOTween.Kill(this);
			DOTween.To(_alphaGetter, _alphaSetter, 0.5f, 0.5f).SetUpdate(isIndependentUpdate: true).SetTarget(this);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (_stopping)
			{
				FinishStop();
			}
		}

		public void Stop()
		{
			if (base.gameObject.activeSelf)
			{
				if (base.gameObject.activeInHierarchy)
				{
					_stopping = true;
					StartCoroutine(StopRoutine());
				}
				else
				{
					FinishStop();
				}
			}
		}

		private IEnumerator StopRoutine()
		{
			DOTween.Kill(this);
			yield return DOTween.To(_alphaGetter, _alphaSetter, 0f, 0.5f).SetUpdate(isIndependentUpdate: true).SetTarget(this)
				.WaitForCompletion();
			FinishStop();
		}

		private void FinishStop()
		{
			_stopping = false;
			SetColorAlpha(0f);
			base.gameObject.SetActive(value: false);
			CTSSingleton<Highlighter>.Instance.ReturnToPool(this);
		}

		private void SetColorAlpha(float value)
		{
			Color color = _image.color;
			color.a = value;
			_image.color = color;
		}
	}
}
