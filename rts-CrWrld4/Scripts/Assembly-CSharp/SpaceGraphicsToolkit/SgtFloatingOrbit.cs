using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingOrbit : MonoBehaviour
	{
		public double Radius;

		public float Oblateness;

		public Vector3 Tilt;

		public double Angle;

		public double DegreesPerSecond;

		public SgtFloatingOrbitVisual Visual;

		[SerializeField]
		private SgtFloatingPoint parentPoint;

		[NonSerialized]
		private SgtFloatingPoint cachedPoint;

		[NonSerialized]
		private bool cachedPointSet;

		public SgtFloatingPoint ParentPoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void RegisterParentPoint()
		{
		}

		public void UnregisterParentPoint()
		{
		}

		public static SgtPosition CalculatePosition(SgtFloatingPoint parentPoint, double radius, double angle, Vector3 tilt, float oblateness)
		{
			return default(SgtPosition);
		}

		public void UpdateOrbit()
		{
		}

		public static void Rotate(Quaternion q, ref double x, ref double y, ref double z)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		private void ParentPositionChanged()
		{
		}

		private void FloatingCameraSnap(SgtFloatingCamera floatingCamera, Vector3 delta)
		{
		}
	}
}
