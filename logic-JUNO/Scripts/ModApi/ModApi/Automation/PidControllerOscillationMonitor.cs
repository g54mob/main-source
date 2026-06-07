using ModApi.Math;
using UnityEngine;

namespace ModApi.Automation
{
	public class PidControllerOscillationMonitor
	{
		private float _elapsedTime;

		private float _lastNonzeroError;

		private float _maxNegativeError;

		private float _maxNegativeErrorTime;

		private float _maxPositiveError;

		private float _maxPositiveErrorTime;

		private float _oscillationFactorAdjustment;

		private float _oscillationFactorInstant;

		private float _oscillationFactorLongTerm;

		private float _oscillationFactorShortTerm;

		public float OscillationFrequency { get; private set; }

		public float OscillationMagnitude { get; private set; }

		public float RecommendedPidAdjustment => Mathf.Max(1f - _oscillationFactorAdjustment, 0.1f);

		public void Reset()
		{
			float num = (OscillationFrequency = float.NaN);
			float maxPositiveErrorTime = (OscillationMagnitude = num);
			_maxNegativeError = (_maxNegativeErrorTime = (_maxPositiveError = (_maxPositiveErrorTime = maxPositiveErrorTime)));
		}

		public void Update(float error, float deltaTime)
		{
			_elapsedTime += deltaTime;
			if (Mathf.Sign(error) != Mathf.Sign(_lastNonzeroError) && error != 0f && _lastNonzeroError != 0f)
			{
				if (error > 0f)
				{
					_maxPositiveError = error;
					_maxPositiveErrorTime = _elapsedTime;
					OscillationFrequency = _maxPositiveErrorTime - _maxNegativeErrorTime;
				}
				else
				{
					_maxNegativeError = error;
					_maxNegativeErrorTime = _elapsedTime;
					OscillationFrequency = _maxNegativeErrorTime - _maxPositiveErrorTime;
				}
				OscillationMagnitude = _maxPositiveError - _maxNegativeError;
			}
			if (error > 0f)
			{
				if (error > _maxPositiveError)
				{
					_maxPositiveError = error;
					_maxPositiveErrorTime = _elapsedTime;
				}
			}
			else if (error < _maxNegativeError)
			{
				_maxNegativeError = error;
				_maxNegativeErrorTime = _elapsedTime;
			}
			float num = 1f / OscillationFrequency * OscillationMagnitude;
			if (!float.IsNaN(num))
			{
				num = MathUtils.PercentBetween(num, 0.002f, 0.05f);
				_oscillationFactorInstant = num;
			}
			else
			{
				_oscillationFactorInstant = 0f;
			}
			_oscillationFactorShortTerm = Mathf.Lerp(_oscillationFactorShortTerm, _oscillationFactorInstant, deltaTime);
			_oscillationFactorLongTerm = Mathf.Lerp(_oscillationFactorLongTerm, _oscillationFactorShortTerm, deltaTime / 10f);
			_oscillationFactorAdjustment = Mathf.Max(_oscillationFactorShortTerm, _oscillationFactorLongTerm);
			if (error != 0f)
			{
				_lastNonzeroError = error;
			}
		}
	}
}
