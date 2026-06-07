using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class ConstantCircleWorldScaler : MonoBehaviour
	{
		public AnimationCurve ScaleTween;

		public AnimationCurve RadiusTween;

		public AnimationCurve AlphaTween;

		public float MinSize;

		public float MaxSize;

		public float MinRadius;

		public float MaxRadius;

		public float MinAlpha;

		public float MaxAlpha = 1f;

		public Renderer Renderer;

		public float Duration;

		public float Offset;

		public float ActivationDelay;

		public string AudioEffect;

		private float _time;

		private Renderer _renderer;

		public void Start()
		{
			_time = Offset;
			_renderer = GetComponent<Renderer>();
		}

		public void Update()
		{
			_renderer.enabled = _time > 0f;
			_time += Time.deltaTime;
			if (_time >= Duration)
			{
				_time %= Duration;
				if (!AudioEffect.IsNullOrWhitespace())
				{
					AudioController.Play(AudioEffect);
				}
			}
			float t = ScaleTween.Evaluate(_time / Duration);
			float num = Mathf.Lerp(MinSize, MaxSize, t);
			base.transform.localScale = new Vector3(num, num, 1f);
			float t2 = RadiusTween.Evaluate(_time / Duration);
			float value = Mathf.Lerp(MinRadius, MaxRadius, t2);
			float t3 = AlphaTween.Evaluate(_time / Duration);
			float value2 = Mathf.Lerp(MinAlpha, MaxAlpha, t3);
			Renderer.material.SetFloat("_Radius", value);
			Renderer.material.SetFloat("_Alpha", value2);
		}

		public void OnDisable()
		{
			_time = ActivationDelay;
			_renderer.enabled = false;
		}
	}
}
