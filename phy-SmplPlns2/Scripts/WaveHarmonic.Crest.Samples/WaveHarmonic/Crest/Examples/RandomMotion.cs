using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class RandomMotion : CustomBehaviour
	{
		[SerializeField]
		private bool _WorldSpace;

		[Header("Translation")]
		[SerializeField]
		private Vector3 _Axis = Vector3.up;

		[SerializeField]
		private float _Amplitude = 1f;

		[SerializeField]
		private float _Frequency = 1f;

		[SerializeField]
		private float _OrthogonalMotion;

		[Header("Rotation")]
		[SerializeField]
		private float _RotationFrequency = 1f;

		[SerializeField]
		private float _RotationVelocity;

		private Vector3 _Origin;

		private Vector3 _OrthogonalAxis;

		private protected override void OnStart()
		{
			base.OnStart();
			_Origin = (_WorldSpace ? base.transform.position : base.transform.localPosition);
			_OrthogonalAxis = Quaternion.AngleAxis(90f, Vector3.up) * _Axis;
		}

		private void Update()
		{
			float num = 2f * (Mathf.PerlinNoise(0.5f + 0.5f * Mathf.Cos(_Frequency * Time.time), 0.5f + 0.5f * Mathf.Sin(_Frequency * Time.time)) - 0.5f);
			float num2 = Mathf.Min(_Amplitude, _Amplitude * Time.timeSinceLevelLoad);
			float num3 = MathF.PI / 2f;
			float num4 = 2f * (Mathf.PerlinNoise(0.5f + 0.5f * Mathf.Cos(_Frequency * Time.time + num3), 0.5f + 0.5f * Mathf.Sin(_Frequency * Time.time + num3)) - 0.5f);
			Vector3 vector = _Origin + (_Axis * num + _OrthogonalMotion * num4 * _OrthogonalAxis) * num2;
			if (_WorldSpace)
			{
				base.transform.position = vector;
			}
			else
			{
				base.transform.localPosition = vector;
			}
			float num5 = Mathf.Sin(Time.time * _RotationFrequency * 1f);
			float num6 = Mathf.Sin(Time.time * _RotationFrequency * 0.83f);
			float num7 = Mathf.Sin(Time.time * _RotationFrequency * 1.14f);
			base.transform.rotation *= Quaternion.Euler(num5 * _RotationVelocity * Time.deltaTime, num6 * _RotationVelocity * Time.deltaTime, num7 * _RotationVelocity * Time.deltaTime);
		}
	}
}
