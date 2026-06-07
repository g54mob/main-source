using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-80)]
public class OVRSkeleton : MonoBehaviour
{
	public interface IOVRSkeletonDataProvider
	{
		SkeletonType GetSkeletonType();

		SkeletonPoseData GetSkeletonPoseData();
	}

	public struct SkeletonPoseData
	{
		public OVRPlugin.Posef RootPose { get; set; }

		public float RootScale { get; set; }

		public OVRPlugin.Quatf[] BoneRotations { get; set; }

		public bool IsDataValid { get; set; }

		public bool IsDataHighConfidence { get; set; }

		public int SkeletonChangedCount { get; set; }
	}

	public enum SkeletonType
	{
		None = -1,
		HandLeft = 0,
		HandRight = 1
	}

	public enum BoneId
	{
		Invalid = -1,
		Hand_Start = 0,
		Hand_WristRoot = 0,
		Hand_ForearmStub = 1,
		Hand_Thumb0 = 2,
		Hand_Thumb1 = 3,
		Hand_Thumb2 = 4,
		Hand_Thumb3 = 5,
		Hand_Index1 = 6,
		Hand_Index2 = 7,
		Hand_Index3 = 8,
		Hand_Middle1 = 9,
		Hand_Middle2 = 10,
		Hand_Middle3 = 11,
		Hand_Ring1 = 12,
		Hand_Ring2 = 13,
		Hand_Ring3 = 14,
		Hand_Pinky0 = 15,
		Hand_Pinky1 = 16,
		Hand_Pinky2 = 17,
		Hand_Pinky3 = 18,
		Hand_MaxSkinnable = 19,
		Hand_ThumbTip = 19,
		Hand_IndexTip = 20,
		Hand_MiddleTip = 21,
		Hand_RingTip = 22,
		Hand_PinkyTip = 23,
		Hand_End = 24,
		Max = 50
	}

	[SerializeField]
	protected SkeletonType _skeletonType = SkeletonType.None;

	[SerializeField]
	private IOVRSkeletonDataProvider _dataProvider;

	[SerializeField]
	private bool _updateRootPose;

	[SerializeField]
	private bool _updateRootScale;

	[SerializeField]
	private bool _enablePhysicsCapsules;

	private GameObject _bonesGO;

	private GameObject _bindPosesGO;

	private GameObject _capsulesGO;

	protected List<OVRBone> _bones;

	private List<OVRBone> _bindPoses;

	private List<OVRBoneCapsule> _capsules;

	protected OVRPlugin.Skeleton2 _skeleton;

	private readonly Quaternion wristFixupRotation = new Quaternion(0f, 1f, 0f, 0f);

	public bool IsInitialized { get; private set; }

	public bool IsDataValid { get; private set; }

	public bool IsDataHighConfidence { get; private set; }

	public IList<OVRBone> Bones { get; protected set; }

	public IList<OVRBone> BindPoses { get; private set; }

	public IList<OVRBoneCapsule> Capsules { get; private set; }

	public int SkeletonChangedCount { get; private set; }

	public SkeletonType GetSkeletonType()
	{
		return _skeletonType;
	}

	private void Awake()
	{
		if (_dataProvider == null)
		{
			_dataProvider = GetComponent<IOVRSkeletonDataProvider>();
		}
		_bones = new List<OVRBone>();
		Bones = _bones.AsReadOnly();
		_bindPoses = new List<OVRBone>();
		BindPoses = _bindPoses.AsReadOnly();
		_capsules = new List<OVRBoneCapsule>();
		Capsules = _capsules.AsReadOnly();
	}

	private void Start()
	{
		if (ShouldInitialize())
		{
			Initialize();
		}
	}

	private bool ShouldInitialize()
	{
		if (IsInitialized)
		{
			return false;
		}
		if (_skeletonType == SkeletonType.None)
		{
			return false;
		}
		if (_skeletonType != SkeletonType.HandLeft)
		{
			_ = _skeletonType;
			_ = 1;
		}
		return true;
	}

	private void Initialize()
	{
		if (OVRPlugin.GetSkeleton2((OVRPlugin.SkeletonType)_skeletonType, ref _skeleton))
		{
			InitializeBones();
			InitializeBindPose();
			InitializeCapsules();
			IsInitialized = true;
		}
	}

	protected virtual void InitializeBones()
	{
		bool flag = _skeletonType == SkeletonType.HandLeft || _skeletonType == SkeletonType.HandRight;
		if (!_bonesGO)
		{
			_bonesGO = new GameObject("Bones");
			_bonesGO.transform.SetParent(base.transform, worldPositionStays: false);
			_bonesGO.transform.localPosition = Vector3.zero;
			_bonesGO.transform.localRotation = Quaternion.identity;
		}
		if (_bones == null || _bones.Count != _skeleton.NumBones)
		{
			_bones = new List<OVRBone>(new OVRBone[_skeleton.NumBones]);
			Bones = _bones.AsReadOnly();
		}
		for (int i = 0; i < _bones.Count; i++)
		{
			OVRBone oVRBone = _bones[i] ?? (_bones[i] = new OVRBone());
			oVRBone.Id = (BoneId)_skeleton.Bones[i].Id;
			oVRBone.ParentBoneIndex = _skeleton.Bones[i].ParentBoneIndex;
			Transform obj = oVRBone.Transform ?? (oVRBone.Transform = new GameObject(BoneLabelFromBoneId(_skeletonType, oVRBone.Id)).transform);
			obj.localPosition = (flag ? _skeleton.Bones[i].Pose.Position.FromFlippedXVector3f() : _skeleton.Bones[i].Pose.Position.FromFlippedZVector3f());
			obj.localRotation = (flag ? _skeleton.Bones[i].Pose.Orientation.FromFlippedXQuatf() : _skeleton.Bones[i].Pose.Orientation.FromFlippedZQuatf());
		}
		for (int j = 0; j < _bones.Count; j++)
		{
			if (_bones[j].ParentBoneIndex == -1)
			{
				_bones[j].Transform.SetParent(_bonesGO.transform, worldPositionStays: false);
			}
			else
			{
				_bones[j].Transform.SetParent(_bones[_bones[j].ParentBoneIndex].Transform, worldPositionStays: false);
			}
		}
	}

	private void InitializeBindPose()
	{
		if (!_bindPosesGO)
		{
			_bindPosesGO = new GameObject("BindPoses");
			_bindPosesGO.transform.SetParent(base.transform, worldPositionStays: false);
			_bindPosesGO.transform.localPosition = Vector3.zero;
			_bindPosesGO.transform.localRotation = Quaternion.identity;
		}
		if (_bindPoses == null || _bindPoses.Count != _bones.Count)
		{
			_bindPoses = new List<OVRBone>(new OVRBone[_bones.Count]);
			BindPoses = _bindPoses.AsReadOnly();
		}
		for (int i = 0; i < _bindPoses.Count; i++)
		{
			OVRBone oVRBone = _bones[i];
			OVRBone oVRBone2 = _bindPoses[i] ?? (_bindPoses[i] = new OVRBone());
			oVRBone2.Id = oVRBone.Id;
			oVRBone2.ParentBoneIndex = oVRBone.ParentBoneIndex;
			Transform obj = oVRBone2.Transform ?? (oVRBone2.Transform = new GameObject(BoneLabelFromBoneId(_skeletonType, oVRBone2.Id)).transform);
			obj.localPosition = oVRBone.Transform.localPosition;
			obj.localRotation = oVRBone.Transform.localRotation;
		}
		for (int j = 0; j < _bindPoses.Count; j++)
		{
			if (_bindPoses[j].ParentBoneIndex == -1)
			{
				_bindPoses[j].Transform.SetParent(_bindPosesGO.transform, worldPositionStays: false);
			}
			else
			{
				_bindPoses[j].Transform.SetParent(_bindPoses[_bindPoses[j].ParentBoneIndex].Transform, worldPositionStays: false);
			}
		}
	}

	private void InitializeCapsules()
	{
		bool flag = _skeletonType == SkeletonType.HandLeft || _skeletonType == SkeletonType.HandRight;
		if (!_enablePhysicsCapsules)
		{
			return;
		}
		if (!_capsulesGO)
		{
			_capsulesGO = new GameObject("Capsules");
			_capsulesGO.transform.SetParent(base.transform, worldPositionStays: false);
			_capsulesGO.transform.localPosition = Vector3.zero;
			_capsulesGO.transform.localRotation = Quaternion.identity;
		}
		if (_capsules == null || _capsules.Count != _skeleton.NumBoneCapsules)
		{
			_capsules = new List<OVRBoneCapsule>(new OVRBoneCapsule[_skeleton.NumBoneCapsules]);
			Capsules = _capsules.AsReadOnly();
		}
		for (int i = 0; i < _capsules.Count; i++)
		{
			OVRBone oVRBone = _bones[_skeleton.BoneCapsules[i].BoneIndex];
			OVRBoneCapsule oVRBoneCapsule = _capsules[i] ?? (_capsules[i] = new OVRBoneCapsule());
			oVRBoneCapsule.BoneIndex = _skeleton.BoneCapsules[i].BoneIndex;
			if (oVRBoneCapsule.CapsuleRigidbody == null)
			{
				oVRBoneCapsule.CapsuleRigidbody = new GameObject(BoneLabelFromBoneId(_skeletonType, oVRBone.Id) + "_CapsuleRigidbody").AddComponent<Rigidbody>();
				oVRBoneCapsule.CapsuleRigidbody.mass = 1f;
				oVRBoneCapsule.CapsuleRigidbody.isKinematic = true;
				oVRBoneCapsule.CapsuleRigidbody.useGravity = false;
				oVRBoneCapsule.CapsuleRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			GameObject gameObject = oVRBoneCapsule.CapsuleRigidbody.gameObject;
			gameObject.transform.SetParent(_capsulesGO.transform, worldPositionStays: false);
			gameObject.transform.position = oVRBone.Transform.position;
			gameObject.transform.rotation = oVRBone.Transform.rotation;
			if (oVRBoneCapsule.CapsuleCollider == null)
			{
				oVRBoneCapsule.CapsuleCollider = new GameObject(BoneLabelFromBoneId(_skeletonType, oVRBone.Id) + "_CapsuleCollider").AddComponent<CapsuleCollider>();
				oVRBoneCapsule.CapsuleCollider.isTrigger = false;
			}
			Vector3 vector = (flag ? _skeleton.BoneCapsules[i].StartPoint.FromFlippedXVector3f() : _skeleton.BoneCapsules[i].StartPoint.FromFlippedZVector3f());
			Vector3 toDirection = (flag ? _skeleton.BoneCapsules[i].EndPoint.FromFlippedXVector3f() : _skeleton.BoneCapsules[i].EndPoint.FromFlippedZVector3f()) - vector;
			float magnitude = toDirection.magnitude;
			Quaternion localRotation = Quaternion.FromToRotation(Vector3.right, toDirection);
			oVRBoneCapsule.CapsuleCollider.radius = _skeleton.BoneCapsules[i].Radius;
			oVRBoneCapsule.CapsuleCollider.height = magnitude + _skeleton.BoneCapsules[i].Radius * 2f;
			oVRBoneCapsule.CapsuleCollider.direction = 0;
			oVRBoneCapsule.CapsuleCollider.center = Vector3.right * magnitude * 0.5f;
			GameObject obj = oVRBoneCapsule.CapsuleCollider.gameObject;
			obj.transform.SetParent(gameObject.transform, worldPositionStays: false);
			obj.transform.localPosition = vector;
			obj.transform.localRotation = localRotation;
		}
	}

	private void Update()
	{
		if (!IsInitialized || _dataProvider == null)
		{
			IsDataValid = false;
			IsDataHighConfidence = false;
			return;
		}
		SkeletonPoseData skeletonPoseData = _dataProvider.GetSkeletonPoseData();
		IsDataValid = skeletonPoseData.IsDataValid;
		if (!skeletonPoseData.IsDataValid)
		{
			return;
		}
		if (SkeletonChangedCount != skeletonPoseData.SkeletonChangedCount)
		{
			SkeletonChangedCount = skeletonPoseData.SkeletonChangedCount;
			IsInitialized = false;
			Initialize();
		}
		IsDataHighConfidence = skeletonPoseData.IsDataHighConfidence;
		if (_updateRootPose)
		{
			base.transform.localPosition = skeletonPoseData.RootPose.Position.FromFlippedZVector3f();
			base.transform.localRotation = skeletonPoseData.RootPose.Orientation.FromFlippedZQuatf();
		}
		if (_updateRootScale)
		{
			base.transform.localScale = new Vector3(skeletonPoseData.RootScale, skeletonPoseData.RootScale, skeletonPoseData.RootScale);
		}
		for (int i = 0; i < _bones.Count; i++)
		{
			if (!(_bones[i].Transform != null))
			{
				continue;
			}
			if (_skeletonType == SkeletonType.HandLeft || _skeletonType == SkeletonType.HandRight)
			{
				_bones[i].Transform.localRotation = skeletonPoseData.BoneRotations[i].FromFlippedXQuatf();
				if (_bones[i].Id == BoneId.Hand_Start)
				{
					_bones[i].Transform.localRotation *= wristFixupRotation;
				}
			}
			else
			{
				_bones[i].Transform.localRotation = skeletonPoseData.BoneRotations[i].FromFlippedZQuatf();
			}
		}
	}

	private void FixedUpdate()
	{
		if (!IsInitialized || _dataProvider == null)
		{
			IsDataValid = false;
			IsDataHighConfidence = false;
			return;
		}
		Update();
		if (!_enablePhysicsCapsules)
		{
			return;
		}
		SkeletonPoseData skeletonPoseData = _dataProvider.GetSkeletonPoseData();
		IsDataValid = skeletonPoseData.IsDataValid;
		IsDataHighConfidence = skeletonPoseData.IsDataHighConfidence;
		for (int i = 0; i < _capsules.Count; i++)
		{
			OVRBoneCapsule oVRBoneCapsule = _capsules[i];
			GameObject gameObject = oVRBoneCapsule.CapsuleRigidbody.gameObject;
			if (skeletonPoseData.IsDataValid && skeletonPoseData.IsDataHighConfidence)
			{
				Transform transform = _bones[oVRBoneCapsule.BoneIndex].Transform;
				if (gameObject.activeSelf)
				{
					oVRBoneCapsule.CapsuleRigidbody.MovePosition(transform.position);
					oVRBoneCapsule.CapsuleRigidbody.MoveRotation(transform.rotation);
				}
				else
				{
					gameObject.SetActive(value: true);
					oVRBoneCapsule.CapsuleRigidbody.position = transform.position;
					oVRBoneCapsule.CapsuleRigidbody.rotation = transform.rotation;
				}
			}
			else if (gameObject.activeSelf)
			{
				gameObject.SetActive(value: false);
			}
		}
	}

	public BoneId GetCurrentStartBoneId()
	{
		SkeletonType skeletonType = _skeletonType;
		if (skeletonType != SkeletonType.None && (uint)skeletonType <= 1u)
		{
			return BoneId.Hand_Start;
		}
		return BoneId.Invalid;
	}

	public BoneId GetCurrentEndBoneId()
	{
		SkeletonType skeletonType = _skeletonType;
		if (skeletonType != SkeletonType.None && (uint)skeletonType <= 1u)
		{
			return BoneId.Hand_End;
		}
		return BoneId.Invalid;
	}

	private BoneId GetCurrentMaxSkinnableBoneId()
	{
		SkeletonType skeletonType = _skeletonType;
		if (skeletonType != SkeletonType.None && (uint)skeletonType <= 1u)
		{
			return BoneId.Hand_MaxSkinnable;
		}
		return BoneId.Invalid;
	}

	public int GetCurrentNumBones()
	{
		SkeletonType skeletonType = _skeletonType;
		if (skeletonType != SkeletonType.None && (uint)skeletonType <= 1u)
		{
			return GetCurrentEndBoneId() - GetCurrentStartBoneId();
		}
		return 0;
	}

	public int GetCurrentNumSkinnableBones()
	{
		SkeletonType skeletonType = _skeletonType;
		if (skeletonType != SkeletonType.None && (uint)skeletonType <= 1u)
		{
			return GetCurrentMaxSkinnableBoneId() - GetCurrentStartBoneId();
		}
		return 0;
	}

	public static string BoneLabelFromBoneId(SkeletonType skeletonType, BoneId boneId)
	{
		if (skeletonType == SkeletonType.HandLeft || skeletonType == SkeletonType.HandRight)
		{
			switch (boneId)
			{
			case BoneId.Hand_Start:
				return "Hand_WristRoot";
			case BoneId.Hand_ForearmStub:
				return "Hand_ForearmStub";
			case BoneId.Hand_Thumb0:
				return "Hand_Thumb0";
			case BoneId.Hand_Thumb1:
				return "Hand_Thumb1";
			case BoneId.Hand_Thumb2:
				return "Hand_Thumb2";
			case BoneId.Hand_Thumb3:
				return "Hand_Thumb3";
			case BoneId.Hand_Index1:
				return "Hand_Index1";
			case BoneId.Hand_Index2:
				return "Hand_Index2";
			case BoneId.Hand_Index3:
				return "Hand_Index3";
			case BoneId.Hand_Middle1:
				return "Hand_Middle1";
			case BoneId.Hand_Middle2:
				return "Hand_Middle2";
			case BoneId.Hand_Middle3:
				return "Hand_Middle3";
			case BoneId.Hand_Ring1:
				return "Hand_Ring1";
			case BoneId.Hand_Ring2:
				return "Hand_Ring2";
			case BoneId.Hand_Ring3:
				return "Hand_Ring3";
			case BoneId.Hand_Pinky0:
				return "Hand_Pinky0";
			case BoneId.Hand_Pinky1:
				return "Hand_Pinky1";
			case BoneId.Hand_Pinky2:
				return "Hand_Pinky2";
			case BoneId.Hand_Pinky3:
				return "Hand_Pinky3";
			case BoneId.Hand_MaxSkinnable:
				return "Hand_ThumbTip";
			case BoneId.Hand_IndexTip:
				return "Hand_IndexTip";
			case BoneId.Hand_MiddleTip:
				return "Hand_MiddleTip";
			case BoneId.Hand_RingTip:
				return "Hand_RingTip";
			case BoneId.Hand_PinkyTip:
				return "Hand_PinkyTip";
			default:
				return "Hand_Unknown";
			}
		}
		return "Skeleton_Unknown";
	}
}
