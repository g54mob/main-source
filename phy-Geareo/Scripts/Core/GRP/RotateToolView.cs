using UnityEngine;

namespace GRP
{
	public class RotateToolView : ToolView<RotateToolViewable>
	{
		public Axis[] axisX;

		public Axis[] axisY;

		public Axis[] axisZ;

		public Transform transformX;

		public Transform transformY;

		public Transform transformZ;

		public LineRenderer pointerLine;

		public LineRenderer sliceLine;

		public MeshFilter meshFilter;

		public float vertexPerTurn;

		public Transform anchor;

		private Plane plane;

		private Vector3 startPosition;

		private PartGroupTransform group;

		protected override void Start()
		{
		}

		protected override void LateUpdate()
		{
		}

		private void UpdateTransform()
		{
		}
	}
}
