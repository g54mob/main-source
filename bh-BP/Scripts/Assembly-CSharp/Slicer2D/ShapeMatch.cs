using UnityEngine;

namespace Slicer2D
{
	public class ShapeMatch : MonoBehaviour
	{
		public ShapeMatchType type;

		public ShapeObject shapeA;

		public ShapeObject shapeB;

		public bool visualisation;

		public bool guiInfo;

		public static ShapeMatchResult GetMatch(ShapeObject shapeA, ShapeObject shapeB, ShapeMatchType type = ShapeMatchType.World)
		{
			return null;
		}

		public void Update()
		{
		}

		public void OnGUI()
		{
		}
	}
}
