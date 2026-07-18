using System;
using UnityEngine;

namespace ProPixelizer
{
	public class ProPixelizerExampleFloating : MonoBehaviour
	{
		public float Period = 2.2f;

		public float Amplitude = 1f;

		public float Steps = 100f;

		private float RotationRate;

		private float PhaseOffset;

		private Vector3 Position;

		private float Angle;

		private Quaternion original;

		public bool Rotates;

		private void Start()
		{
			PhaseOffset = UnityEngine.Random.value;
			Position = base.transform.position;
			Angle = UnityEngine.Random.value * 360f;
			original = base.transform.rotation;
			RotationRate = (Rotates ? ((float)UnityEngine.Random.Range(0, 3) * 15f) : 0f);
		}

		private void Update()
		{
			float num = PhaseOffset + Time.time / Period;
			num = MathF.PI * 2f * (float)(int)(num * Steps) / Steps;
			float num2 = Amplitude * Mathf.Cos(num);
			base.transform.position = num2 * Vector3.up + Position;
			Angle += RotationRate * Time.deltaTime;
			if (RotationRate != 0f)
			{
				base.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.up) * original;
			}
		}
	}
}
