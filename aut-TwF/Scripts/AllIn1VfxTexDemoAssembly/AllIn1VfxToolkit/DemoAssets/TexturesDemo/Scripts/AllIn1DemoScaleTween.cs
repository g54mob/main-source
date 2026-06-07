using UnityEngine;

namespace AllIn1VfxToolkit.DemoAssets.TexturesDemo.Scripts
{
	public class AllIn1DemoScaleTween : MonoBehaviour
	{
		[SerializeField]
		private float maxTweenScale = 2f;

		[SerializeField]
		private float minTweenScale = 0.8f;

		[SerializeField]
		private float tweenSpeed = 15f;

		private bool isTweening;

		private float currentScale = 1f;

		private float iniScale;

		private Vector3 scaleToApply = Vector3.one;

		private void Start()
		{
			iniScale = base.transform.localScale.x;
		}

		private void Update()
		{
			if (isTweening)
			{
				currentScale = Mathf.Lerp(currentScale, iniScale, Time.unscaledDeltaTime * tweenSpeed);
				UpdateScaleToApply();
				ApplyScale();
				if (Mathf.Abs(currentScale - 1f) < 0.02f)
				{
					isTweening = false;
				}
			}
		}

		private void UpdateScaleToApply()
		{
			scaleToApply.x = currentScale;
			scaleToApply.y = currentScale;
		}

		private void ApplyScale()
		{
			base.transform.localScale = scaleToApply;
		}

		public void ScaleUpTween()
		{
			isTweening = true;
			currentScale = iniScale * maxTweenScale;
			UpdateScaleToApply();
		}

		public void ScaleDownTween()
		{
			isTweening = true;
			currentScale = iniScale * minTweenScale;
			UpdateScaleToApply();
		}
	}
}
