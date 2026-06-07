using Easing;
using UnityEngine;

namespace Motorways
{
	public abstract class Tween<T>
	{
		private float _time;

		private float _duration;

		private T _startValue;

		private T _endValue;

		private Easings.Functions _function;

		public bool IsActive => _duration > 0f;

		public T Value
		{
			get
			{
				if (_duration <= 0f)
				{
					return _endValue;
				}
				return LerpValue(_startValue, _endValue, Easings.Interpolate(Mathf.Max(0f, _time) / _duration, _function));
			}
		}

		public T End => _endValue;

		public float Duration => _duration;

		public void Reset()
		{
			_time = 0f;
			_duration = 0f;
			_startValue = default(T);
			_endValue = default(T);
			_function = Easings.Functions.Linear;
		}

		public void Start(T start, T end, float duration, Easings.Functions easingFunction, float delay = 0f)
		{
			_time = 0f - delay;
			_startValue = start;
			_endValue = end;
			_duration = duration;
			_function = easingFunction;
		}

		public void Stop()
		{
			_duration = 0f;
		}

		public void Set(T val, float duration = 0f)
		{
			_endValue = val;
			_duration = duration;
		}

		public T Tick(float deltaTime)
		{
			if (!Diagnostics.Verify(_duration > 0f, "Please don't tick an inactive tween."))
			{
				return _endValue;
			}
			_time += deltaTime;
			if (_time >= _duration)
			{
				_duration = 0f;
			}
			return Value;
		}

		public override string ToString()
		{
			return $"[Tween(Start={_startValue}, End={_endValue}, Value={Value}, Time={_time}, Duration={_duration})]";
		}

		protected abstract T LerpValue(T startValue, T endValue, float alpha);
	}
}
