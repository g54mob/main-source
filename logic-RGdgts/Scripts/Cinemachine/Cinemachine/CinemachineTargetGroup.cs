using System;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachineTargetGroup : MonoBehaviour, ICinemachineTargetGroup
	{
		[Serializable]
		public struct Target
		{
			public Transform target;

			public float weight;

			public float radius;
		}

		public enum PositionMode
		{
			GroupCenter = 0,
			GroupAverage = 1
		}

		public enum RotationMode
		{
			Manual = 0,
			GroupAverage = 1
		}

		public enum UpdateMethod
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		public PositionMode m_PositionMode;

		public RotationMode m_RotationMode;

		public UpdateMethod m_UpdateMethod;

		[NoSaveDuringPlay]
		public Target[] m_Targets;

		private float m_MaxWeight;

		private Vector3 m_AveragePos;

		private BoundingSphere m_BoundingSphere;

		public Transform Transform => null;

		public Bounds BoundingBox { get; private set; }

		public BoundingSphere Sphere => default(BoundingSphere);

		public bool IsEmpty => false;

		public void AddMember(Transform t, float weight, float radius)
		{
		}

		public void RemoveMember(Transform t)
		{
		}

		public int FindMember(Transform t)
		{
			return 0;
		}

		public BoundingSphere GetWeightedBoundsForMember(int index)
		{
			return default(BoundingSphere);
		}

		public Bounds GetViewSpaceBoundingBox(Matrix4x4 observer)
		{
			return default(Bounds);
		}

		private static BoundingSphere WeightedMemberBounds(Target t, Vector3 avgPos, float maxWeight)
		{
			return default(BoundingSphere);
		}

		public void DoUpdate()
		{
		}

		private BoundingSphere CalculateBoundingSphere(float maxWeight)
		{
			return default(BoundingSphere);
		}

		private Vector3 CalculateAveragePosition(out float maxWeight)
		{
			maxWeight = default(float);
			return default(Vector3);
		}

		private Quaternion CalculateAverageOrientation()
		{
			return default(Quaternion);
		}

		private Bounds CalculateBoundingBox(Vector3 avgPos, float maxWeight)
		{
			return default(Bounds);
		}

		private void OnValidate()
		{
		}

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void GetViewSpaceAngularBounds(Matrix4x4 observer, out Vector2 minAngles, out Vector2 maxAngles, out Vector2 zRange)
		{
			minAngles = default(Vector2);
			maxAngles = default(Vector2);
			zRange = default(Vector2);
		}
	}
}
