using UnityEngine;

namespace TH20.UI
{
	public class OverviewMenuSpotlightBeam : MonoBehaviour
	{
		public enum BeamModes
		{
			BmNone = 0,
			BmRandom = 1,
			BmFocus = 2
		}

		private const float BEAM_SIZE_BASE = 1.5f;

		private const float BEAM_DAMPENING = 0.9f;

		private const float X_AMPLITUDE_BASE = 0.5f;

		private const float X_FREQUENCY_BASE = 3f;

		private const float Y_AMPLITUDE_BASE = 0.5f;

		private const float Y_FREQUENCY_BASE = 1f;

		private bool _startCounting;

		private float _beamSizeDest = 1.5f;

		private float _timeStamp;

		private float _xAmplitude;

		private float _xFrequency;

		private float _yAmplitude;

		private float _yFrequency;

		private Vector2 _beamDest = Vector2.zero;

		private Vector2 _beamStart = Vector2.zero;

		private UIBeamRenderer _theBeamRenderer;

		private BeamModes _beamMode;

		public BeamModes BeamMode
		{
			get
			{
				return _beamMode;
			}
			set
			{
				if (value == BeamModes.BmNone)
				{
					base.gameObject.SetActive(value: false);
				}
				else
				{
					base.gameObject.SetActive(value: true);
				}
				_beamMode = value;
			}
		}

		public void Setup()
		{
			_theBeamRenderer = GetComponent<UIBeamRenderer>();
			BeamMode = BeamModes.BmNone;
		}

		public void Process()
		{
			if ((bool)_theBeamRenderer)
			{
				if (_startCounting)
				{
					_startCounting = false;
					_timeStamp = Time.unscaledTime;
				}
				float num = Mathf.Clamp01(Time.unscaledTime - _timeStamp);
				Vector2 vector = _theBeamRenderer.SpotTarget;
				switch (BeamMode)
				{
				default:
					return;
				case BeamModes.BmRandom:
					vector.Set(Mathf.Sin(Time.unscaledTime * _xFrequency) * _xAmplitude, Mathf.Sin(Time.unscaledTime * _yFrequency) * _yAmplitude);
					break;
				case BeamModes.BmFocus:
					vector = _beamStart + EasingsUtils.ElasticEaseOut(num * 0.5f) * (_beamDest - _beamStart);
					break;
				}
				_theBeamRenderer.BeamScale = 1.5f + EasingsUtils.BounceEaseOut(num) * _beamSizeDest;
				_theBeamRenderer.SpotTarget += (vector - _theBeamRenderer.SpotTarget) * 0.1f;
			}
		}

		public void SetRandomMovement()
		{
			if (BeamMode != BeamModes.BmRandom)
			{
				_startCounting = true;
				_beamSizeDest = Random.value;
				_xAmplitude = 0.5f + Random.Range(-0.1f, 0.1f);
				_xFrequency = 3f + Random.Range(-1f, 1f);
				_yAmplitude = 0.5f + Random.Range(-0.1f, 0.1f);
				_yFrequency = 1f + Random.Range(-1f, 1f);
				BeamMode = BeamModes.BmRandom;
			}
		}

		public void SetIntensity(float inIntensity)
		{
			Color color = _theBeamRenderer.color;
			color.a = Mathf.Clamp01(inIntensity);
			_theBeamRenderer.color = color;
		}

		public void SetFocus(Vector2 focus, float size)
		{
			_startCounting = true;
			_beamSizeDest = ((size > 0f) ? size : Random.value);
			_beamStart = ((_theBeamRenderer != null) ? _theBeamRenderer.SpotTarget : focus);
			_beamDest = focus;
			BeamMode = BeamModes.BmFocus;
		}

		public void SetOff()
		{
			BeamMode = BeamModes.BmNone;
		}
	}
}
