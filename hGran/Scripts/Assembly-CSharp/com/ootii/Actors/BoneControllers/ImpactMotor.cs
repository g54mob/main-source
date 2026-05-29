using System;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Impact Motor")]
	[IKDescription("Allows the skeleton to react as if it were hit by bullets, swords, explosions, etc.")]
	public class ImpactMotor : BoneControllerMotor
	{
		[Serializable]
		public class ImpactMotorBone
		{
			public bool IsTemporary;

			public int State;

			public float Time;

			public Vector3 Change;

			public Vector3 EndPosition;

			public float Weight;

			private static ObjectPool<ImpactMotorBone> sPool;

			public static ImpactMotorBone Allocate()
			{
				return null;
			}

			public static void Release(ImpactMotorBone rInstance)
			{
			}
		}

		public bool _UseAllBones;

		public float _MinBoneLength;

		public float _Power;

		public float _ImpactTime;

		public float _RecoveryTime;

		public AnimationCurve _RecoveryCurve;

		public int _ParentSpread;

		public float _ParentDamping;

		public int _ChildSpread;

		public float _ChildDamping;

		public List<ImpactMotorBone> _BoneInfo;

		private Dictionary<BoneControllerBone, ImpactMotorBone> mActiveBoneInfo;

		private List<BoneControllerBone> mInactiveBoneInfo;

		public bool UseAllBones
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MinBoneLength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Power
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ImpactTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RecoveryTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve RecoveryCurve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int ParentSpread
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float ParentDamping
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int ChildSpread
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float ChildDamping
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ImpactMotor()
		{
		}

		public ImpactMotor(BoneController rSkeleton)
		{
		}

		public override void ClearBones()
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}

		public BoneControllerBone Raycast(Vector3 rOrigin, Vector3 rVelocity, float rRange, bool rStopIfBlocked, ref Vector3 lHitPoint)
		{
			return null;
		}

		public BoneControllerBone RaycastImpact(Vector3 rOrigin, Vector3 rVelocity, float rRange, float rMass, bool rStopIfBlocked, ref Vector3 rHitPoint)
		{
			return null;
		}

		private void ApplyImpactToParent(BoneControllerBone rChild, Vector3 rChange, int rDepthRemaining, float rDamping)
		{
		}

		private void ApplyImpactToChildren(BoneControllerBone rParent, Vector3 rChange, int rDepthRemaining, float rDamping)
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

		protected virtual bool AddTemporaryBone(BoneControllerBone rBone)
		{
			return false;
		}

		protected override void RemoveBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}
	}
}
