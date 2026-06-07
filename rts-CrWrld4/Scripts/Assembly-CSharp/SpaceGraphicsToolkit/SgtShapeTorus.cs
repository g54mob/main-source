using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public class SgtShapeTorus : SgtShape
	{
		public float Radius;

		public float Thickness;

		public SgtEase.Type Ease;

		public float Sharpness;

		public override float GetDensity(Vector3 worldPoint)
		{
			return 0f;
		}

		public static SgtShapeTorus Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtShapeTorus Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}
	}
}
