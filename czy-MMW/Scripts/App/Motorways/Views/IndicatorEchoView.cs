using Client;
using Factory;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class IndicatorEchoView : MonoBehaviour, IView, IReusable
	{
		[Dependency]
		private ViewClient _viewClient;

		[Header("Shared Settings")]
		[SerializeField]
		private AnimationCurve _normalizedScaleCurve;

		[SerializeField]
		private AnimationCurve _normalizedAlphaCurve;

		[SerializeField]
		[Header("Internal References")]
		private Renderer _renderer;

		private AnimationCurve _ringWidthCurve;

		private float _scaleMin;

		private float _scaleMax;

		private float _duration;

		private float _timeLeft;

		private static int ShaderAlphaId = Shader.PropertyToID("_Alpha");

		private static int ShaderRingSizeId = Shader.PropertyToID("_RingSize");

		private void Initialize(Vector3 position, Color color, AnimationCurve ringWidthCurve, float scaleMin, float scaleMax, float duration)
		{
			base.transform.position = position;
			_renderer.material.color = color;
			_ringWidthCurve = ringWidthCurve;
			_scaleMin = scaleMin;
			_scaleMax = scaleMax;
			_duration = duration;
			_timeLeft = duration;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			_timeLeft -= timeInterval.Delta;
			if (_timeLeft <= 0f)
			{
				return TickResult.Destroy;
			}
			TickAnimation(timeInterval.Delta);
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void TickAnimation(float tickTime)
		{
			float time = 1f - _timeLeft / _duration;
			float num = Mathf.Lerp(_scaleMin, _scaleMax, _normalizedScaleCurve.Evaluate(time));
			float value = _normalizedAlphaCurve.Evaluate(time);
			base.transform.localScale = new Vector3(num, num, 1f);
			_renderer.material.SetFloat(ShaderAlphaId, value);
			float value2 = _ringWidthCurve.Evaluate(time) / num;
			_renderer.material.SetFloat(ShaderRingSizeId, value2);
		}

		public static IndicatorEchoView Create(ViewClient client, Vector3 position, Color color, AnimationCurve ringWidthCurve, float scaleMin, float scaleMax, float duration)
		{
			IndicatorEchoView indicatorEchoView = client.Scope.Get<IndicatorEchoView>();
			indicatorEchoView.Initialize(position, color, ringWidthCurve, scaleMin, scaleMax, duration);
			client.AddView(indicatorEchoView);
			return indicatorEchoView;
		}

		public void Reset()
		{
			_scaleMin = 0f;
			_scaleMax = 0f;
			_duration = 0f;
			_timeLeft = 0f;
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
		}
	}
}
