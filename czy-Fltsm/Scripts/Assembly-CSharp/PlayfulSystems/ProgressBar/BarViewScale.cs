using System.Collections;
using UnityEngine;

namespace PlayfulSystems.ProgressBar
{
	[RequireComponent(typeof(RectTransform))]
	public class BarViewScale : ProgressBarProView
	{
		[SerializeField]
		protected RectTransform graphic;

		[Header("Color Options")]
		[Tooltip("If true, then the scale animates for each change. Otherwise it scales constantly based on value")]
		[SerializeField]
		private bool animateOnChange = true;

		[SerializeField]
		private Vector3 minSize = Vector3.one;

		[SerializeField]
		private Vector3 maxSize = new Vector3(2f, 2f, 2f);

		[Tooltip("A value of 0 is minSize, a value of 1 is maxSize. Time goes from 0 to 1.")]
		[SerializeField]
		private AnimationCurve scale;

		[SerializeField]
		private float animDuration = 0.2f;

		private Coroutine scaleAnim;

		private void OnEnable()
		{
			UpdateScale();
		}

		public override void NewChangeStarted(float currentValue, float targetValue)
		{
			if (base.gameObject.activeInHierarchy && animateOnChange)
			{
				if (scaleAnim != null)
				{
					StopCoroutine(scaleAnim);
				}
				scaleAnim = StartCoroutine(DoBarScaleAnim(animDuration));
			}
		}

		private IEnumerator DoBarScaleAnim(float duration)
		{
			float time = 0f;
			while (time < duration)
			{
				UpdateScale(time / duration);
				time += Time.deltaTime;
				yield return null;
			}
			UpdateScale();
			scaleAnim = null;
		}

		public override void UpdateView(float currentValue, float targetValue)
		{
			if (!animateOnChange && scaleAnim == null)
			{
				UpdateScale(currentValue);
			}
		}

		private void UpdateScale(float value = 0f)
		{
			graphic.localScale = GetCurrentScale(value);
		}

		private Vector3 GetCurrentScale(float percentage)
		{
			return Vector3.Lerp(minSize, maxSize, scale.Evaluate(percentage));
		}
	}
}
