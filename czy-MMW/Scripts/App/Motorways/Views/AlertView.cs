using Client;
using Easing;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class AlertView : MonoBehaviour, IView, IReusable
	{
		[SerializeField]
		private Color _defaultAlertColor = Color.white;

		[SerializeField]
		private float _defaultAlertScale = 7f;

		[SerializeField]
		private float _defaultAlertDuration = 2.7f;

		[SerializeField]
		private float _defaultAlertAlpha = 0.6f;

		private float _timeLeft;

		private float _duration;

		private float _baseScale;

		private float _alpha;

		[SerializeField]
		private SpriteRenderer _renderer;

		public float Alpha
		{
			get
			{
				return _renderer.color.a;
			}
			set
			{
				if (!Mathf.Approximately(Alpha, value))
				{
					Color color = _renderer.color;
					color.a = value;
					_renderer.color = color;
				}
			}
		}

		public void Initialize(Vector3 position, float duration, float scale, Color color, float alpha)
		{
			base.transform.position = position;
			_timeLeft = duration;
			_duration = duration;
			_baseScale = scale;
			_alpha = alpha;
			_renderer.color = color;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			_timeLeft -= timeInterval.Delta;
			if (_timeLeft <= 0f)
			{
				return TickResult.Destroy;
			}
			float p = 1f - _timeLeft / _duration;
			float num = 1f + Easings.Interpolate(p, Easings.Functions.ExponentialEaseOut) * _baseScale;
			float alpha = _alpha - Easings.Interpolate(p, Easings.Functions.CubicEaseOut) * _alpha;
			base.transform.localScale = new Vector3(num, num, 1f);
			Alpha = alpha;
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			_timeLeft = 0f;
			_duration = 0f;
			_baseScale = 0f;
			_alpha = 0f;
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
		}

		public static AlertView Create(ViewClient client, Vector3 position, Color? color = null, float? scale = null, float? duration = null, float? alpha = null)
		{
			AlertView alertView = client.Scope.Get<AlertView>();
			float scale2 = scale ?? alertView._defaultAlertScale;
			float duration2 = duration ?? alertView._defaultAlertDuration;
			Color color2 = color ?? alertView._defaultAlertColor;
			float alpha2 = alpha ?? alertView._defaultAlertAlpha;
			alertView.Initialize(position, duration2, scale2, color2, alpha2);
			client.AddView(alertView);
			return alertView;
		}
	}
}
