using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKBoneJointName("Limited Swing and Twist")]
	public class LimitedSwingAndTwistJoint : BoneControllerJoint
	{
		[Serializable]
		public class ReachCone
		{
			public float Volume;

			public Vector3 SlicePlane;

			public Vector3 BoundaryPlane;

			public Vector3 Origin;

			public Vector3 VisiblePoint;

			public Vector3 BoundaryPoint1;

			public Vector3 BoundaryPoint2;

			public bool IsVisiblePointValid => false;

			public ReachCone(Vector3 rOrigin, Vector3 rVisiblePoint, Vector3 rBoundaryPoint1, Vector3 rBoundaryPoint2)
			{
			}

			public void PreProcess()
			{
			}
		}

		public bool _LimitSwing;

		public List<Vector3> BoundaryPoints;

		private Vector3[] mReachPoints;

		private ReachCone[] mReachCones;

		public bool _PreventSwingTwisting;

		public bool _AllowTwist;

		public bool _LimitTwist;

		public float _MinTwistAngle;

		public float _MaxTwistAngle;

		public int _SmoothingIterations;

		private bool mIsEditing;

		private int mSelectedPoint;

		public bool LimitSwing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool PreventSwingTwisting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AllowTwist
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LimitTwist
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override float MinTwistAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override float MaxTwistAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int SmoothingIterations
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override float GetTwistStress(Quaternion rLocalTwist)
		{
			return 0f;
		}

		public LimitedSwingAndTwistJoint()
		{
		}

		public LimitedSwingAndTwistJoint(BoneControllerBone rBone)
		{
		}

		public override void Initialize(BoneControllerBone rBone)
		{
		}

		public override bool ApplyLimits(ref Quaternion rSwing, ref Quaternion rTwist)
		{
			return false;
		}

		public void ClearBoundaryPoints()
		{
		}

		public void BuildReachCones()
		{
		}

		private Vector3[] SmoothReachPoints()
		{
			return null;
		}

		private float GetSmoothingConstant(int rBoundaryPointCount)
		{
			return 0f;
		}

		private Vector3 SpherePointToTangentPlane(Vector3 rReachPoint, Vector3 rVisiblePoint, float rRadius)
		{
			return default(Vector3);
		}

		private Vector3 TangentPointToSpherePoint(Vector3 rTangentPoint, Vector3 rVisiblePoint, float rRadius)
		{
			return default(Vector3);
		}

		private int GetReachConeIndex(Vector3 rBoneAxis)
		{
			return 0;
		}

		private bool IsInReachCone(Vector3 rBoneAxis)
		{
			return false;
		}

		private Vector3 GetReachConeExit(Vector3 rStart, Vector3 rEnd)
		{
			return default(Vector3);
		}

		private Vector3 GetReachConeExit(Vector3 rStart, Vector3 rEnd, int rStartReachSliceIndex)
		{
			return default(Vector3);
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public override bool OnInspectorConstraintGUI(bool rIsSelected)
		{
			return false;
		}

		public override bool OnSceneConstraintGUI(bool rIsSelected)
		{
			return false;
		}

		public override bool OnInspectorManipulatorGUI(IKBoneModifier rModifier)
		{
			return false;
		}

		public override bool OnSceneManipulatorGUI(IKBoneModifier rModifier)
		{
			return false;
		}

		private int AddBoundaryPoint(int rSelectedPoint)
		{
			return 0;
		}

		private int RemoveBoundaryPoint(int rSelectedPoint)
		{
			return 0;
		}
	}
}
