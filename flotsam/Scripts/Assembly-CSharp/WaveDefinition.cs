using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class WaveDefinition
{
	public const string _GLOBAL_WAVELENGTH = "_GLOBAL_GERSTNER_Wavelength";

	public const string _GLOBAL_SPEED = "_GLOBAL_GERSTNER_Speed";

	public const string _GLOBAL_PHASE = "_GLOBAL_GERSTNER_Phase";

	public const string _GLOBAL_AMPLITUDE = "_GLOBAL_GERSTNER_Amplitude";

	public const string _GLOBAL_STEEPNESS = "_GLOBAL_GERSTNER_Steepness";

	private const string _GLOBAL_DIRECTION_PREFIX = "_GLOBAL_GERSTNER_Direction";

	[FormerlySerializedAs("WaveLength")]
	[Tooltip("Length to set for wave.")]
	[SerializeField]
	private float _waveLength = 100f;

	[FormerlySerializedAs("Steepness")]
	[Tooltip("Steepness to set for wave.")]
	[Range(0f, 1f)]
	[SerializeField]
	private float _steepness = 1f;

	[FormerlySerializedAs("Amplitude")]
	[Tooltip("Amplitude to set for wave.")]
	[SerializeField]
	private float _amplitude = 1f;

	[FormerlySerializedAs("Speed")]
	[Tooltip("Speed to set for wave.")]
	[SerializeField]
	private float _speed = 0.5f;

	[FormerlySerializedAs("Direction")]
	[Tooltip("Direction to set for wave.")]
	[SerializeField]
	private Vector2 _direction = new Vector2(1f, 0f);

	private float _frequency;

	private float _phase;

	private float _steepnessAmplitudeDirectionX;

	private float _steepnessAmplitudeDirectionY;

	private string _normalizedDirectionGlobal;

	public float Wavelength { get; private set; }

	public float Speed { get; private set; }

	public float Phase => _phase;

	public float Amplitude { get; private set; }

	public float Steepness { get; private set; }

	public Vector2 NormalizedDirection { get; private set; }

	public void ApplyMultipliers(float wavelengthMultiplier, float speedMultiplier, float steepnessMultiplier, float amplitudeMultiplier)
	{
		Wavelength = _waveLength * wavelengthMultiplier;
		Speed = _speed * speedMultiplier;
		Amplitude = _amplitude * amplitudeMultiplier;
		Steepness = Mathf.Clamp(_steepness * steepnessMultiplier, 0f, 1f);
		_frequency = MathF.PI * 2f / Wavelength;
		_phase = Speed / _frequency;
		NormalizedDirection = _direction.normalized;
		float num = Steepness / (_frequency * Amplitude * 4f);
		_steepnessAmplitudeDirectionX = num * Amplitude * NormalizedDirection.x;
		_steepnessAmplitudeDirectionY = num * Amplitude * NormalizedDirection.y;
	}

	public Vector3 ReturnWaveOffsetGerstner(Vector3 position, float time)
	{
		Vector2 normalized = _direction.normalized;
		float num = Vector2.Dot(_direction.normalized, new Vector2(position.x, position.z));
		float num2 = MathF.PI * 2f / Wavelength;
		float f = num2 * num + Speed * time + Phase;
		float num3 = Mathf.Cos(f);
		float num4 = Mathf.Sin(f);
		float num5 = Steepness / (num2 * Amplitude * 4f);
		Vector3 zero = Vector3.zero;
		zero.x = num5 * Amplitude * normalized.x * num3;
		zero.z = num5 * Amplitude * normalized.y * num3;
		zero.y = Amplitude * num4;
		return zero;
	}

	public float ReturnWaveOffsetGerstnerY(float x, float z, float time)
	{
		float num = Vector2.Dot(_direction.normalized, new Vector2(x, z));
		float num2 = Mathf.Sin(MathF.PI * 2f / Wavelength * num + Speed * time + Phase);
		return Amplitude * num2;
	}

	public string ReturnNormalizedDirectionGlobal(int index)
	{
		if (string.IsNullOrEmpty(_normalizedDirectionGlobal) || Application.isEditor)
		{
			_normalizedDirectionGlobal = "_GLOBAL_GERSTNER_Direction" + index;
		}
		return _normalizedDirectionGlobal;
	}
}
