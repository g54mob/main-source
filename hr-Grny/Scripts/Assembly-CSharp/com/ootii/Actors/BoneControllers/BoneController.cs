using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[ExecuteInEditMode]
	[AddComponentMenu("ootii/Bone Controller")]
	public class BoneController : BaseBoneController, ISerializationCallbackReceiver
	{
		[NonSerialized]
		public static bool EditorForceRepaint;

		public static int MaxIterations;

		public Transform _RootTransform;

		protected BoneControllerBone mRoot;

		public List<BoneControllerBone> Bones;

		[NonSerialized]
		public List<BoneControllerMotor> Motors;

		[SerializeField]
		public List<string> MotorDefinitions;

		public string EditorBoneFilters;

		public bool EditorShowBones;

		protected string[] mBoneFilters;

		public bool EditorShowBoneLimits;

		public bool EditorShowBoneColliders;

		public bool EditorAutoScaleHandles;

		public bool EditorShowSelectedBones;

		public bool EditorForceTrueColliders;

		public bool EditorForceTrueBoxColliders;

		public float EditorLastTime;

		public float EditorDeltaTime;

		private bool mRaiseOnAfterDeserialize;

		private static GUIStyle sRowStyle;

		private static GUIStyle sTitleRowStyle;

		private static GUIStyle sSelectedRowStyle;

		private static Texture sItemSelector;

		public Transform RootTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BoneControllerBone Root => null;

		public static GUIStyle RowStyle => null;

		public static GUIStyle TitleRowStyle => null;

		public static GUIStyle SelectedRowStyle => null;

		public static Texture ItemSelector => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void InitializeRoot(Transform rRoot)
		{
		}

		public void InitializeBone(BoneControllerBone rBone)
		{
		}

		public override IKBone GetBone(string rBoneName)
		{
			return null;
		}

		public override IKBone GetBone(Transform rBone)
		{
			return null;
		}

		public override IKBone GetBone(HumanBodyBones rBone)
		{
			return null;
		}

		private BoneControllerBone GetChildBone(BoneControllerBone rParent, string rBoneName)
		{
			return null;
		}

		private BoneControllerBone GetChildBone(BoneControllerBone rParent, Transform rBoneTransform)
		{
			return null;
		}

		public BoneControllerBone AddBone(BoneControllerBone rParent)
		{
			return null;
		}

		public void RemoveBone(BoneControllerBone rBone)
		{
		}

		private void RemoveBoneChildren(BoneControllerBone rParent)
		{
		}

		public override IKBone TestPointCollision(Vector3 rPoint)
		{
			return null;
		}

		public override bool TestRayCollision(Vector3 rStart, Vector3 rDirection, float rRange, out IKBone rHitBone, out Vector3 rHitPoint)
		{
			rHitBone = null;
			rHitPoint = default(Vector3);
			return false;
		}

		public bool TestBoneNameFilter(string rName)
		{
			return false;
		}

		public override void ResetBindPose()
		{
		}

		public override IKMotor GetMotor(string rName)
		{
			return null;
		}

		public override IKMotor GetMotor(Type rType)
		{
			return null;
		}

		public virtual List<IKMotor> GetMotors(Type rType)
		{
			return null;
		}

		public override T GetMotor<T>()
		{
			return null;
		}

		public virtual List<T> GetMotors<T>() where T : BoneControllerMotor
		{
			return null;
		}

		public override T GetMotor<T>(string rName)
		{
			return null;
		}

		public virtual List<T> GetMotors<T>(string rName) where T : BoneControllerMotor
		{
			return null;
		}

		public override void EnableMotors<T>(bool rEnable)
		{
		}

		public void EnableMotors(Type rType, bool rEnable)
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		public virtual void SetBoneColliders(string rType, int rDetailLevel)
		{
		}

		public virtual void SetBoneColliders(int rDetailLevel)
		{
		}

		public virtual void SetHumanoidBoneColliders(int rDetailLevel)
		{
		}

		protected void SetBoneBoxCollider(HumanBodyBones rBoneID, bool rTestForExisting)
		{
		}

		protected void SetBoneBoxCollider(BoneControllerBone rBone, bool rTestForExisting)
		{
		}

		protected void SetBoneCapsuleCollider(HumanBodyBones rBoneID, bool rTestForExisting)
		{
		}

		protected void SetBoneCapsuleCollider(HumanBodyBones rBoneID, float rWidthMultiplier, bool rTestForExisting)
		{
		}

		protected void SetBoneCapsuleCollider(BoneControllerBone rBone, float rWidthMultiplier, bool rTestForExisting)
		{
		}

		protected void SetBoneSphereCollider(HumanBodyBones rBoneID, bool rTestForExisting)
		{
		}

		protected void SetBoneSphereCollider(HumanBodyBones rBoneID, float rRadiusMultiplier, bool rCenter, bool rTestForExisting)
		{
		}

		protected void SetBoneSphereCollider(BoneControllerBone rBone, float rRadiusMultiplier, bool rCenter, bool rTestForExisting)
		{
		}

		public virtual void RemoveBoneColliders(int rDetailLevel)
		{
		}

		public virtual void SetBoneJoints(string rType, int rDetailLevel)
		{
		}

		public virtual void SetBoneJoints(int rDetailLevel)
		{
		}

		public virtual void SetHumanoidBoneJoints(int rDetailLevel)
		{
		}

		public virtual void RemoveBoneJoints(int rDetailLevel)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private void OnAfterDeserializeCore()
		{
		}

		public bool OnSceneGUI()
		{
			return false;
		}

		public Transform GetPrefabTransform(string rBoneName)
		{
			return null;
		}

		public bool RenderBoneList(List<BoneControllerBone> rBones, ref int rSelectedBoneIndex, ref BoneControllerBone rSceneSelectedBone)
		{
			return false;
		}

		public static Transform FindTransform(Transform rParent, string rBoneName)
		{
			return null;
		}

		private static Transform FindChildTransform(Transform rParent, string rBoneName)
		{
			return null;
		}
	}
}
