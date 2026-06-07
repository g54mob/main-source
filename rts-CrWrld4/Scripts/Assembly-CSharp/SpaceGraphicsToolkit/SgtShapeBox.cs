using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public class SgtShapeBox : SgtShape
	{
		public Vector3 Extents;

		public SgtEase.Type Ease;

		public float Sharpness;

		public override float GetDensity(Vector3 worldPoint)
		{
			return 0f;
		}

		public static SgtShapeBox Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtShapeBox Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}
	}
}
