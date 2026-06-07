using System;
using ModApi;
using ModApi.Common;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public class ParticleInterpolatorScript : MonoBehaviour
	{
		public enum ParticleField
		{
			StartSize = 0,
			StartSpeed = 1,
			Opacity = 2,
			Lifetime = 3,
			ArcSpread = 4,
			VelocityRadial = 5
		}

		[Serializable]
		public class ParticleFieldInterpolator
		{
			public AnimationCurve AnimationCurve;

			public ParticleField Field;

			public MinMaxValue MinMaxValue;

			public float Randomness = 0.5f;

			public float SineWave;

			public bool UseAnimationCurve;

			public float Value { get; set; }

			public Action<float> ValueSetter { get; set; }

			public void SetValue(float v)
			{
				Value = v;
				ValueSetter(v);
			}
		}

		private float _intensity;

		[SerializeField]
		private ParticleFieldInterpolator[] _interpolators;

		private ParticleSystem _ps;

		private ParticleSystem.EmissionModule _psEmission;

		private ParticleSystem.MainModule _psMain;

		private ParticleSystem.ShapeModule _psShape;

		private ParticleSystem.VelocityOverLifetimeModule _psVelocityOverLifetime;

		[SerializeField]
		private float _rateDecrease = 1f;

		[SerializeField]
		private float _rateIncrease = 10f;

		public void Interpolate(float intensity, float simulationSpeed)
		{
			_psMain.simulationSpeed = simulationSpeed;
			if (_intensity < intensity)
			{
				_intensity = Utilities.StepTowards(_intensity, _rateIncrease * Time.deltaTime, intensity);
			}
			else
			{
				_intensity = Utilities.StepTowards(_intensity, _rateDecrease * Time.deltaTime, intensity);
			}
			if (_intensity > 0f)
			{
				ParticleFieldInterpolator[] interpolators = _interpolators;
				foreach (ParticleFieldInterpolator particleFieldInterpolator in interpolators)
				{
					float num = _intensity;
					if (particleFieldInterpolator.SineWave > 0f)
					{
						num = Mathf.Sin(particleFieldInterpolator.SineWave * Time.time) * 0.5f + 0.5f;
					}
					else if (particleFieldInterpolator.UseAnimationCurve)
					{
						num = particleFieldInterpolator.AnimationCurve.Evaluate(num);
					}
					particleFieldInterpolator.SetValue(Mathf.Lerp(particleFieldInterpolator.MinMaxValue.MinValue, particleFieldInterpolator.MinMaxValue.MaxValue, num));
				}
			}
			_psEmission.enabled = _intensity > 0f;
		}

		protected virtual void Awake()
		{
			_ps = GetComponent<ParticleSystem>();
			_psMain = _ps.main;
			_psEmission = _ps.emission;
			_psShape = _ps.shape;
			_psVelocityOverLifetime = _ps.velocityOverLifetime;
			ParticleFieldInterpolator[] interpolators = _interpolators;
			foreach (ParticleFieldInterpolator particleFieldInterpolator in interpolators)
			{
				ParticleFieldInterpolator i2 = particleFieldInterpolator;
				switch (i2.Field)
				{
				case ParticleField.StartSize:
					i2.ValueSetter = delegate
					{
						_psMain.startSize = GetMinMaxCurve(i2);
					};
					break;
				case ParticleField.StartSpeed:
					i2.ValueSetter = delegate
					{
						_psMain.startSpeed = GetMinMaxCurve(i2);
					};
					break;
				case ParticleField.Opacity:
					i2.ValueSetter = delegate(float x)
					{
						Color colorMin = _psMain.startColor.colorMin;
						Color colorMin2 = _psMain.startColor.colorMin;
						colorMin.a = x;
						colorMin2.a = x;
						_psMain.startColor = new ParticleSystem.MinMaxGradient(colorMin, colorMin2);
					};
					break;
				case ParticleField.ArcSpread:
					i2.ValueSetter = delegate(float x)
					{
						_psShape.arcSpread = x;
					};
					break;
				case ParticleField.Lifetime:
					i2.ValueSetter = delegate
					{
						_psMain.startLifetime = GetMinMaxCurve(i2);
					};
					break;
				case ParticleField.VelocityRadial:
					i2.ValueSetter = delegate
					{
						_psVelocityOverLifetime.radial = GetMinMaxCurve(i2);
					};
					break;
				default:
					throw new NotImplementedException($"ParticleFieldInterpolator field type is not implemented: {i2.Field}");
				}
			}
		}

		private static ParticleSystem.MinMaxCurve GetMinMaxCurve(ParticleFieldInterpolator i)
		{
			if (i.Randomness > 0f)
			{
				return new ParticleSystem.MinMaxCurve(i.Value * (1f - i.Randomness), i.Value * (1f + i.Randomness));
			}
			return i.Value;
		}
	}
}
