using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Finger Pose Motor")]
	[IKDescription("Allows for the posing of the fingers of each hand.")]
	public class FingerPoseMotor : BoneControllerMotor
	{
		[Serializable]
		public class FingerPoseMotorBone : IKBoneModifier
		{
			public bool IsEnabled;

			public Quaternion Rotation;

			public Quaternion ActualSwing;

			public Quaternion ActualTwist;

			public float RotationLerp;
		}

		public float _LeftWeight;

		public float _RightWeight;

		public float _LeftCurl;

		public float _RightCurl;

		public float[] _FingerCurls;

		public List<FingerPoseMotorBone> _BoneInfo;

		public float LeftWeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightWeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LeftCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LeftThumbCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LeftIndexCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LeftMiddleCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LeftRingCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LeftLittleCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightThumbCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightIndexCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightMiddleCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightRingCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightLittleCurl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public FingerPoseMotor()
		{
		}

		public FingerPoseMotor(BoneController rSkeleton)
		{
		}

		public override void LoadBones()
		{
		}

		public void SetBoneRotation(HumanBodyBones rBoneID, float rAngle, Vector3 rAxis)
		{
		}

		public void SetBoneRotation(int rIndex, float rAngle, Vector3 rAxis)
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}

		private int AddBone(HumanBodyBones rBoneID)
		{
			return 0;
		}

		public override bool OnInspectorGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		private bool OnInspectorFingerGUI(int rFingerIndex, string rName)
		{
			return false;
		}
	}
}
