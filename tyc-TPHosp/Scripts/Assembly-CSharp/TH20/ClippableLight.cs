using UnityEngine;

namespace TH20
{
	public class ClippableLight : MonoBehaviour
	{
		public enum LightType
		{
			Point = 0,
			Spot = 1
		}

		public LightType Type;

		public Color Color = Color.white;

		public float Range = 2f;

		public float Intensity = 1f;

		public Texture2D Cookie;

		[Range(1f, 180f)]
		public float SpotAngle = 45f;
	}
}
