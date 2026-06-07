using UnityEngine;

[DefaultExecutionOrder(-90)]
public class OVRHand : MonoBehaviour, OVRSkeleton.IOVRSkeletonDataProvider, OVRSkeletonRenderer.IOVRSkeletonRendererDataProvider, OVRMesh.IOVRMeshDataProvider, OVRMeshRenderer.IOVRMeshRendererDataProvider
{
	public enum Hand
	{
		None = -1,
		HandLeft = 0,
		HandRight = 1
	}

	public enum HandFinger
	{
		Thumb = 0,
		Index = 1,
		Middle = 2,
		Ring = 3,
		Pinky = 4,
		Max = 5
	}

	public enum TrackingConfidence
	{
		Low = 0,
		High = 1065353216
	}

	[SerializeField]
	private Hand HandType = Hand.None;

	[SerializeField]
	private Transform _pointerPoseRoot;

	private GameObject _pointerPoseGO;

	private OVRPlugin.HandState _handState;

	public bool IsDataValid { get; private set; }

	public bool IsDataHighConfidence { get; private set; }

	public bool IsTracked { get; private set; }

	public bool IsSystemGestureInProgress { get; private set; }

	public bool IsPointerPoseValid { get; private set; }

	public Transform PointerPose { get; private set; }

	public float HandScale { get; private set; }

	public TrackingConfidence HandConfidence { get; private set; }

	public bool IsDominantHand { get; private set; }

	private void Awake()
	{
		_pointerPoseGO = new GameObject();
		PointerPose = _pointerPoseGO.transform;
		if (_pointerPoseRoot != null)
		{
			PointerPose.SetParent(_pointerPoseRoot, worldPositionStays: false);
		}
		GetHandState(OVRPlugin.Step.Render);
	}

	private void Update()
	{
		GetHandState(OVRPlugin.Step.Render);
	}

	private void FixedUpdate()
	{
		if (OVRPlugin.nativeXrApi != OVRPlugin.XrApi.OpenXR)
		{
			GetHandState(OVRPlugin.Step.Physics);
		}
	}

	private void GetHandState(OVRPlugin.Step step)
	{
		if (OVRPlugin.GetHandState(step, (OVRPlugin.Hand)HandType, ref _handState))
		{
			IsTracked = (_handState.Status & OVRPlugin.HandStatus.HandTracked) != 0;
			IsSystemGestureInProgress = (_handState.Status & OVRPlugin.HandStatus.SystemGestureInProgress) != 0;
			IsPointerPoseValid = (_handState.Status & OVRPlugin.HandStatus.InputStateValid) != 0;
			IsDominantHand = (_handState.Status & OVRPlugin.HandStatus.DominantHand) != 0;
			PointerPose.localPosition = _handState.PointerPose.Position.FromFlippedZVector3f();
			PointerPose.localRotation = _handState.PointerPose.Orientation.FromFlippedZQuatf();
			HandScale = _handState.HandScale;
			HandConfidence = (TrackingConfidence)_handState.HandConfidence;
			IsDataValid = true;
			IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
		}
		else
		{
			IsTracked = false;
			IsSystemGestureInProgress = false;
			IsPointerPoseValid = false;
			PointerPose.localPosition = Vector3.zero;
			PointerPose.localRotation = Quaternion.identity;
			HandScale = 1f;
			HandConfidence = TrackingConfidence.Low;
			IsDataValid = false;
			IsDataHighConfidence = false;
		}
	}

	public bool GetFingerIsPinching(HandFinger finger)
	{
		if (IsDataValid)
		{
			return ((uint)_handState.Pinches & (uint)(1 << (int)finger)) != 0;
		}
		return false;
	}

	public float GetFingerPinchStrength(HandFinger finger)
	{
		if (IsDataValid && _handState.PinchStrength != null && _handState.PinchStrength.Length == 5)
		{
			return _handState.PinchStrength[(int)finger];
		}
		return 0f;
	}

	public TrackingConfidence GetFingerConfidence(HandFinger finger)
	{
		if (IsDataValid && _handState.FingerConfidences != null && _handState.FingerConfidences.Length == 5)
		{
			return (TrackingConfidence)_handState.FingerConfidences[(int)finger];
		}
		return TrackingConfidence.Low;
	}

	OVRSkeleton.SkeletonType OVRSkeleton.IOVRSkeletonDataProvider.GetSkeletonType()
	{
		switch (HandType)
		{
		case Hand.HandLeft:
			return OVRSkeleton.SkeletonType.HandLeft;
		case Hand.HandRight:
			return OVRSkeleton.SkeletonType.HandRight;
		default:
			return OVRSkeleton.SkeletonType.None;
		}
	}

	OVRSkeleton.SkeletonPoseData OVRSkeleton.IOVRSkeletonDataProvider.GetSkeletonPoseData()
	{
		OVRSkeleton.SkeletonPoseData result = new OVRSkeleton.SkeletonPoseData
		{
			IsDataValid = IsDataValid
		};
		if (IsDataValid)
		{
			result.RootPose = _handState.RootPose;
			result.RootScale = _handState.HandScale;
			result.BoneRotations = _handState.BoneRotations;
			result.IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
		}
		return result;
	}

	OVRSkeletonRenderer.SkeletonRendererData OVRSkeletonRenderer.IOVRSkeletonRendererDataProvider.GetSkeletonRendererData()
	{
		OVRSkeletonRenderer.SkeletonRendererData result = new OVRSkeletonRenderer.SkeletonRendererData
		{
			IsDataValid = IsDataValid
		};
		if (IsDataValid)
		{
			result.RootScale = _handState.HandScale;
			result.IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
			result.ShouldUseSystemGestureMaterial = IsSystemGestureInProgress;
		}
		return result;
	}

	OVRMesh.MeshType OVRMesh.IOVRMeshDataProvider.GetMeshType()
	{
		switch (HandType)
		{
		case Hand.None:
			return OVRMesh.MeshType.None;
		case Hand.HandLeft:
			return OVRMesh.MeshType.HandLeft;
		case Hand.HandRight:
			return OVRMesh.MeshType.HandRight;
		default:
			return OVRMesh.MeshType.None;
		}
	}

	OVRMeshRenderer.MeshRendererData OVRMeshRenderer.IOVRMeshRendererDataProvider.GetMeshRendererData()
	{
		OVRMeshRenderer.MeshRendererData result = new OVRMeshRenderer.MeshRendererData
		{
			IsDataValid = IsDataValid
		};
		if (IsDataValid)
		{
			result.IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
			result.ShouldUseSystemGestureMaterial = IsSystemGestureInProgress;
		}
		return result;
	}
}
