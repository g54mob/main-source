using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class LayoutElementAnimator : MonoBehaviour
	{
		[SerializeField]
		private float _originalHeight;

		public void HideVertical()
		{
			LayoutElement le = GetComponent<LayoutElement>();
			RectTransform rt = GetComponent<RectTransform>();
			if (_originalHeight == 0f)
			{
				_originalHeight = le.preferredHeight;
			}
			DOTween.To(() => rt.localScale.y, delegate(float x)
			{
				le.minHeight = x * _originalHeight;
				le.preferredHeight = le.minHeight;
				rt.localScale = new Vector3(1f, x, 1f);
			}, 0f, 0.5f).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true)
				.OnComplete(delegate
				{
					base.gameObject.SetActive(value: false);
				});
		}

		public void ShowVertical()
		{
			LayoutElement le = GetComponent<LayoutElement>();
			RectTransform rt = GetComponent<RectTransform>();
			base.gameObject.SetActive(value: true);
			if (_originalHeight == 0f)
			{
				_originalHeight = le.preferredHeight;
			}
			DOTween.To(() => rt.localScale.y, delegate(float x)
			{
				le.minHeight = x * _originalHeight;
				le.preferredHeight = le.minHeight;
				rt.localScale = new Vector3(1f, x, 1f);
			}, 1f, 0.5f).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
		}

		protected virtual void Awake()
		{
			RectTransform component = GetComponent<RectTransform>();
			_originalHeight = component.sizeDelta.y;
		}
	}
}
