using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[HelpURL("https://ferdowsur.gitbook.io/layout-system/layout-group/circular-layout-group")]
	[AddComponentMenu("Tiny Giant Studio/Layout/Circular Layout Group (M3D)", 30003)]
	public class CircularLayoutGroup : LayoutGroup
	{
		public enum Direction
		{
			left = 0,
			right = 1
		}

		public enum Style
		{
			style1 = 0,
			style2 = 1,
			style3 = 2,
			style4 = 3,
			style5 = 4
		}

		public Direction direction;

		public bool useAngle;

		public Vector3 angle;

		public Style style;

		public float spread;

		public float radius;

		public float radiusDecreaseRate;

		private int totalActiveChildCount;

		private float xPos;

		private float yPos;

		public override void UpdateLayout(int startRepositioningFrom = 0)
		{
		}

		private void SetLocalPositionRotation(Vector3 position, Quaternion rotation, Transform target)
		{
		}

		public override List<MeshLayout> GetPositions(List<MeshLayout> meshLayouts)
		{
			return null;
		}

		private float Size(Bounds myBound, float totalBound)
		{
			return 0f;
		}

		private float TotalYSize(Bounds[] bounds)
		{
			return 0f;
		}

		private Quaternion GetRotation(float angle, int i)
		{
			return default(Quaternion);
		}

		private Quaternion GetRotationFromFlatRotation(float rotation)
		{
			return default(Quaternion);
		}

		private Quaternion GetRotationFromStyle(float angle, int i)
		{
			return default(Quaternion);
		}

		public void SetDirectionLeft()
		{
		}

		public void SetDirectionRight()
		{
		}
	}
}
