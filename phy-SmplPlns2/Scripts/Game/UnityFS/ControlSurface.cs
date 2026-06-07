using Assets.Scripts.Craft;
using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Dynamics/Control Surface")]
	[RequireComponent(typeof(Wing))]
	public class ControlSurface : AircraftAttachment
	{
		public bool[] AffectedSections;

		public AircraftControls AircraftControls;

		public float CurrentDeflection;

		public float MaxDeflectionDegrees = 30f;

		public GameObject Model;

		public Vector3 ModelRotationAxis = Vector3.left;

		public float RootHingeDistanceFromTrailingEdge = 0.25f;

		public float TipHingeDistanceFromTrailingEdge = 0.25f;

		private Vector3 WingRootAileronHingePos = Vector3.zero;

		private Vector3 WingTipAileronHingePos = Vector3.zero;

		public string AxisName { get; set; }

		public void ModifyWingGeometry(int SectionIndex, ref Vector3 PointA, ref Vector3 PointB, ref Vector3 PointC, ref Vector3 PointD)
		{
			if (SectionIndex < AffectedSections.Length && AffectedSections[SectionIndex])
			{
				WingRootAileronHingePos = PointD + (PointA - PointD) * RootHingeDistanceFromTrailingEdge;
				WingTipAileronHingePos = PointC + (PointB - PointC) * TipHingeDistanceFromTrailingEdge;
				Vector3 vector = WingTipAileronHingePos - WingRootAileronHingePos;
				Vector3 vector2 = PointD - WingRootAileronHingePos;
				Vector3 vector3 = PointC - WingTipAileronHingePos;
				Quaternion quaternion = Quaternion.AngleAxis(CurrentDeflection, vector.normalized);
				vector2 = quaternion * vector2;
				vector3 = quaternion * vector3;
				PointD = WingRootAileronHingePos + vector2;
				PointC = WingTipAileronHingePos + vector3;
			}
		}

		protected virtual void OnDrawGizmos()
		{
			ClampEditorValues();
		}

		protected virtual void Start()
		{
			ModelRotationAxis.Normalize();
		}

		private void ClampEditorValues()
		{
			MaxDeflectionDegrees = Mathf.Clamp(MaxDeflectionDegrees, 0f, 90f);
			RootHingeDistanceFromTrailingEdge = Mathf.Clamp(RootHingeDistanceFromTrailingEdge, 0f, 1f);
			TipHingeDistanceFromTrailingEdge = Mathf.Clamp(TipHingeDistanceFromTrailingEdge, 0f, 1f);
			if (base.gameObject.TryGetComponent<Wing>(out var component) && (AffectedSections == null || component.SectionCount != AffectedSections.Length))
			{
				AffectedSections = new bool[component.SectionCount];
			}
		}
	}
}
