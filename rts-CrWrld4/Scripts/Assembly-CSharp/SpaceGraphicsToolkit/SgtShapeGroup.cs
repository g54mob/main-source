using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public class SgtShapeGroup : MonoBehaviour
	{
		public List<SgtShape> Shapes;

		public static SgtShapeGroup Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtShapeGroup Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		public float GetDensity(Vector3 worldPosition)
		{
			return 0f;
		}
	}
}
