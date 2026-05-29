using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Foot to Ground 2 Bone Motor")]
	[IKDescription("This motor will adjust foot placement and rotation in order to meet the ground under the character")]
	public class FootGround2BoneMotor : BoneControllerMotor
	{
		[Serializable]
		public class FootPlacementMotorBone
		{
			public Vector3 BendAxis;

			public float Twist;

			public Quaternion Rotation;

			public Quaternion RotationTarget;

			public float RotationLerp;

			public float Weight;
		}

		public const float MIN_TARGET_DISTANCE = 0.0001f;

		private static RaycastHit sCollisionInfo1;

		private static RaycastHit sCollisionInfo2;

		public int _GroundingLayers;

		public bool _UseBindRotation;

		public bool _UsePlaneNormal;

		public bool _AllowLegExtension;

		public float _MaxDeltaDistance;

		public bool _RotateFootToGround;

		public bool _RotateFootRequiresBoth;

		public bool _RotateFootOnMovement;

		public float _RotateFootToGroundMinAngle;

		public float _FootToeDistance;

		public float _ToeSoleDistance;

		public float _RaycastStartDistance;

		public float _RaycastExtensionDistance;

		public List<FootPlacementMotorBone> _BoneInfo;

		public Quaternion _FootForwardToBind;

		protected Vector3 mLastPosition;

		public int GroundingLayers
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool UseBindRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UsePlaneNormal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AllowLegExtension
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MaxDeltaDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool RotateFootToGround
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RotateFootRequiresBoth
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RotateFootOnMovement
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float RotateFootToGroundMinAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FootToeDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ToeSoleDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RaycastStartDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RaycastExtensionDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public FootGround2BoneMotor()
		{
		}

		public FootGround2BoneMotor(BoneController rSkeleton)
		{
		}

		public override void ClearBones()
		{
		}

		public virtual void AutoLoadBones(string rStyle)
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}

		private void RotateFoot(Transform rOwnerTransform, BoneControllerBone rLowerLeg, BoneControllerBone rFoot, BoneControllerBone rToes, Vector3 rFootTarget, Vector3 rGroundNormal, bool rHeelCollision, bool rToeCollision)
		{
		}

		public override bool OnInspectorGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		public override bool OnSceneGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		protected override bool RenderBone(int rIndex, BoneControllerBone rBone)
		{
			return false;
		}

		public override void AddBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}

		protected override void RemoveBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}
	}
}
