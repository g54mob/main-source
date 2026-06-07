using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public class SgtShapeSphere : SgtShape
	{
		public float Radius;

		public SgtEase.Type Ease;

		public float Sharpness;

		public override float GetDensity(Vector3 worldPoint)
		{
			return 0f;
		}

		public static SgtShapeSphere Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtShapeSphere Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}
	}
}
