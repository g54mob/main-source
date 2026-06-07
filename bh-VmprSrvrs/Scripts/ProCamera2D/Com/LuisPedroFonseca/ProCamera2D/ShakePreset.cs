using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[Serializable]
	[CreateAssetMenu(menuName = "ProCamera2D/Shake Preset")]
	public class ShakePreset : ScriptableObject
	{
		public Vector3 Strength;

		[Range(0.02f, 3f)]
		public float Duration;

		[Range(1f, 100f)]
		public int Vibrato;

		[Range(0f, 1f)]
		public float Randomness;

		[Range(0f, 0.5f)]
		public float Smoothness;

		public bool UseRandomInitialAngle;

		[Range(0f, 360f)]
		public float InitialAngle;

		public Vector3 Rotation;

		public bool IgnoreTimeScale;
	}
}
