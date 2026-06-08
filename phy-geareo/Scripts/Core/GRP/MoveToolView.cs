using UnityEngine;

namespace GRP
{
	public class MoveToolView : ToolView<MoveToolViewable>
	{
		public Axis axisX;

		public Axis axisY;

		public Axis axisZ;

		public Axis axisNX;

		public Axis axisNY;

		public Axis axisNZ;

		public Axis axisXY;

		public Axis axisXZ;

		public Axis axisYZ;

		public GameObject indicator;

		public Renderer indicatorRenderer;

		public AnimationCurve indicatorCurve;

		public Transform anchor;

		public float planeAxisSize;

		private PartGroupTransform group;

		private float startTime;

		protected override void Start()
		{
		}

		private void Begin()
		{
		}

		private void Drag(Vector3 dir, float value)
		{
		}

		private void End()
		{
		}

		protected override void Update()
		{
		}

		private void SetIndicatorAlpha(float alpha)
		{
		}

		protected override void LateUpdate()
		{
		}

		private void SetupPlaneAxises()
		{
		}

		private void UpdateTransform()
		{
		}
	}
}
