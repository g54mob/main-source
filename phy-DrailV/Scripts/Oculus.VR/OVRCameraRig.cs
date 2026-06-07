using System;
using UnityEngine;
using UnityEngine.XR;

[ExecuteInEditMode]
public class OVRCameraRig : MonoBehaviour
{
	public bool usePerEyeCameras;

	public bool useFixedUpdateForTracking;

	public bool disableEyeAnchorCameras;

	protected bool _skipUpdate;

	protected readonly string trackingSpaceName = "TrackingSpace";

	protected readonly string trackerAnchorName = "TrackerAnchor";

	protected readonly string leftEyeAnchorName = "LeftEyeAnchor";

	protected readonly string centerEyeAnchorName = "CenterEyeAnchor";

	protected readonly string rightEyeAnchorName = "RightEyeAnchor";

	protected readonly string leftHandAnchorName = "LeftHandAnchor";

	protected readonly string rightHandAnchorName = "RightHandAnchor";

	protected readonly string leftControllerAnchorName = "LeftControllerAnchor";

	protected readonly string rightControllerAnchorName = "RightControllerAnchor";

	protected Camera _centerEyeCamera;

	protected Camera _leftEyeCamera;

	protected Camera _rightEyeCamera;

	public Camera leftEyeCamera
	{
		get
		{
			if (!usePerEyeCameras)
			{
				return _centerEyeCamera;
			}
			return _leftEyeCamera;
		}
	}

	public Camera rightEyeCamera
	{
		get
		{
			if (!usePerEyeCameras)
			{
				return _centerEyeCamera;
			}
			return _rightEyeCamera;
		}
	}

	public Transform trackingSpace { get; private set; }

	public Transform leftEyeAnchor { get; private set; }

	public Transform centerEyeAnchor { get; private set; }

	public Transform rightEyeAnchor { get; private set; }

	public Transform leftHandAnchor { get; private set; }

	public Transform rightHandAnchor { get; private set; }

	public Transform leftControllerAnchor { get; private set; }

	public Transform rightControllerAnchor { get; private set; }

	public Transform trackerAnchor { get; private set; }

	public event Action<OVRCameraRig> UpdatedAnchors;

	protected virtual void Awake()
	{
		_skipUpdate = true;
		EnsureGameObjectIntegrity();
	}

	protected virtual void Start()
	{
		UpdateAnchors(updateEyeAnchors: true, updateHandAnchors: true);
		Application.onBeforeRender += OnBeforeRenderCallback;
	}

	protected virtual void FixedUpdate()
	{
		if (useFixedUpdateForTracking)
		{
			UpdateAnchors(updateEyeAnchors: true, updateHandAnchors: true);
		}
	}

	protected virtual void Update()
	{
		_skipUpdate = false;
		if (!useFixedUpdateForTracking)
		{
			UpdateAnchors(updateEyeAnchors: true, updateHandAnchors: true);
		}
	}

	protected virtual void OnDestroy()
	{
		Application.onBeforeRender -= OnBeforeRenderCallback;
	}

	protected virtual void UpdateAnchors(bool updateEyeAnchors, bool updateHandAnchors)
	{
		if (!OVRManager.OVRManagerinitialized)
		{
			return;
		}
		EnsureGameObjectIntegrity();
		if (!Application.isPlaying)
		{
			return;
		}
		if (_skipUpdate)
		{
			centerEyeAnchor.FromOVRPose(OVRPose.identity, isLocal: true);
			leftEyeAnchor.FromOVRPose(OVRPose.identity, isLocal: true);
			rightEyeAnchor.FromOVRPose(OVRPose.identity, isLocal: true);
			return;
		}
		bool monoscopic = OVRManager.instance.monoscopic;
		bool flag = OVRNodeStateProperties.IsHmdPresent();
		OVRPose pose = OVRManager.tracker.GetPose();
		trackerAnchor.localRotation = pose.orientation;
		Quaternion localRotation = Quaternion.Euler(0f - OVRManager.instance.headPoseRelativeOffsetRotation.x, 0f - OVRManager.instance.headPoseRelativeOffsetRotation.y, OVRManager.instance.headPoseRelativeOffsetRotation.z);
		if (updateEyeAnchors)
		{
			if (flag)
			{
				Vector3 retVec = Vector3.zero;
				Quaternion retQuat = Quaternion.identity;
				if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.CenterEye, NodeStatePropertyType.Position, OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render, out retVec))
				{
					centerEyeAnchor.localPosition = retVec;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.CenterEye, NodeStatePropertyType.Orientation, OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render, out retQuat))
				{
					centerEyeAnchor.localRotation = retQuat;
				}
			}
			else
			{
				centerEyeAnchor.localRotation = localRotation;
				centerEyeAnchor.localPosition = OVRManager.instance.headPoseRelativeOffsetTranslation;
			}
			if (!flag || monoscopic)
			{
				leftEyeAnchor.localPosition = centerEyeAnchor.localPosition;
				rightEyeAnchor.localPosition = centerEyeAnchor.localPosition;
				leftEyeAnchor.localRotation = centerEyeAnchor.localRotation;
				rightEyeAnchor.localRotation = centerEyeAnchor.localRotation;
			}
			else
			{
				Vector3 retVec2 = Vector3.zero;
				Vector3 retVec3 = Vector3.zero;
				Quaternion retQuat2 = Quaternion.identity;
				Quaternion retQuat3 = Quaternion.identity;
				if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.LeftEye, NodeStatePropertyType.Position, OVRPlugin.Node.EyeLeft, OVRPlugin.Step.Render, out retVec2))
				{
					leftEyeAnchor.localPosition = retVec2;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.RightEye, NodeStatePropertyType.Position, OVRPlugin.Node.EyeRight, OVRPlugin.Step.Render, out retVec3))
				{
					rightEyeAnchor.localPosition = retVec3;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.LeftEye, NodeStatePropertyType.Orientation, OVRPlugin.Node.EyeLeft, OVRPlugin.Step.Render, out retQuat2))
				{
					leftEyeAnchor.localRotation = retQuat2;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.RightEye, NodeStatePropertyType.Orientation, OVRPlugin.Node.EyeRight, OVRPlugin.Step.Render, out retQuat3))
				{
					rightEyeAnchor.localRotation = retQuat3;
				}
			}
		}
		if (updateHandAnchors)
		{
			if (OVRManager.loadedXRDevice == OVRManager.XRDevice.OpenVR)
			{
				Vector3 retVec4 = Vector3.zero;
				Vector3 retVec5 = Vector3.zero;
				Quaternion retQuat4 = Quaternion.identity;
				Quaternion retQuat5 = Quaternion.identity;
				if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.LeftHand, NodeStatePropertyType.Position, OVRPlugin.Node.HandLeft, OVRPlugin.Step.Render, out retVec4))
				{
					leftHandAnchor.localPosition = retVec4;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.RightHand, NodeStatePropertyType.Position, OVRPlugin.Node.HandRight, OVRPlugin.Step.Render, out retVec5))
				{
					rightHandAnchor.localPosition = retVec5;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.LeftHand, NodeStatePropertyType.Orientation, OVRPlugin.Node.HandLeft, OVRPlugin.Step.Render, out retQuat4))
				{
					leftHandAnchor.localRotation = retQuat4;
				}
				if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.RightHand, NodeStatePropertyType.Orientation, OVRPlugin.Node.HandRight, OVRPlugin.Step.Render, out retQuat5))
				{
					rightHandAnchor.localRotation = retQuat5;
				}
			}
			else
			{
				leftHandAnchor.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
				rightHandAnchor.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
				leftHandAnchor.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
				rightHandAnchor.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
			}
			trackerAnchor.localPosition = pose.position;
			OVRPose oVRPose = OVRPose.identity;
			OVRPose oVRPose2 = OVRPose.identity;
			if (OVRManager.loadedXRDevice == OVRManager.XRDevice.OpenVR)
			{
				oVRPose = OVRManager.GetOpenVRControllerOffset(XRNode.LeftHand);
				oVRPose2 = OVRManager.GetOpenVRControllerOffset(XRNode.RightHand);
				OVRManager.SetOpenVRLocalPose(trackingSpace.InverseTransformPoint(leftControllerAnchor.position), trackingSpace.InverseTransformPoint(rightControllerAnchor.position), Quaternion.Inverse(trackingSpace.rotation) * leftControllerAnchor.rotation, Quaternion.Inverse(trackingSpace.rotation) * rightControllerAnchor.rotation);
			}
			rightControllerAnchor.localPosition = oVRPose2.position;
			rightControllerAnchor.localRotation = oVRPose2.orientation;
			leftControllerAnchor.localPosition = oVRPose.position;
			leftControllerAnchor.localRotation = oVRPose.orientation;
		}
		RaiseUpdatedAnchorsEvent();
	}

	protected virtual void OnBeforeRenderCallback()
	{
		if (OVRManager.loadedXRDevice == OVRManager.XRDevice.Oculus && OVRManager.instance.LateControllerUpdate)
		{
			UpdateAnchors(updateEyeAnchors: false, updateHandAnchors: true);
		}
	}

	protected virtual void RaiseUpdatedAnchorsEvent()
	{
		if (this.UpdatedAnchors != null)
		{
			this.UpdatedAnchors(this);
		}
	}

	public virtual void EnsureGameObjectIntegrity()
	{
		bool flag = OVRManager.instance != null && OVRManager.instance.monoscopic;
		if (trackingSpace == null)
		{
			trackingSpace = ConfigureAnchor(null, trackingSpaceName);
		}
		if (leftEyeAnchor == null)
		{
			leftEyeAnchor = ConfigureAnchor(trackingSpace, leftEyeAnchorName);
		}
		if (centerEyeAnchor == null)
		{
			centerEyeAnchor = ConfigureAnchor(trackingSpace, centerEyeAnchorName);
		}
		if (rightEyeAnchor == null)
		{
			rightEyeAnchor = ConfigureAnchor(trackingSpace, rightEyeAnchorName);
		}
		if (leftHandAnchor == null)
		{
			leftHandAnchor = ConfigureAnchor(trackingSpace, leftHandAnchorName);
		}
		if (rightHandAnchor == null)
		{
			rightHandAnchor = ConfigureAnchor(trackingSpace, rightHandAnchorName);
		}
		if (trackerAnchor == null)
		{
			trackerAnchor = ConfigureAnchor(trackingSpace, trackerAnchorName);
		}
		if (leftControllerAnchor == null)
		{
			leftControllerAnchor = ConfigureAnchor(leftHandAnchor, leftControllerAnchorName);
		}
		if (rightControllerAnchor == null)
		{
			rightControllerAnchor = ConfigureAnchor(rightHandAnchor, rightControllerAnchorName);
		}
		if (_centerEyeCamera == null || _leftEyeCamera == null || _rightEyeCamera == null)
		{
			_centerEyeCamera = centerEyeAnchor.GetComponent<Camera>();
			_leftEyeCamera = leftEyeAnchor.GetComponent<Camera>();
			_rightEyeCamera = rightEyeAnchor.GetComponent<Camera>();
			if (_centerEyeCamera == null)
			{
				_centerEyeCamera = centerEyeAnchor.gameObject.AddComponent<Camera>();
				_centerEyeCamera.tag = "MainCamera";
			}
			if (_leftEyeCamera == null)
			{
				_leftEyeCamera = leftEyeAnchor.gameObject.AddComponent<Camera>();
				_leftEyeCamera.tag = "MainCamera";
			}
			if (_rightEyeCamera == null)
			{
				_rightEyeCamera = rightEyeAnchor.gameObject.AddComponent<Camera>();
				_rightEyeCamera.tag = "MainCamera";
			}
			_centerEyeCamera.stereoTargetEye = StereoTargetEyeMask.Both;
			_leftEyeCamera.stereoTargetEye = StereoTargetEyeMask.Left;
			_rightEyeCamera.stereoTargetEye = StereoTargetEyeMask.Right;
		}
		if (flag && !OVRPlugin.EyeTextureArrayEnabled)
		{
			if (_centerEyeCamera.stereoTargetEye != StereoTargetEyeMask.Left)
			{
				_centerEyeCamera.stereoTargetEye = StereoTargetEyeMask.Left;
			}
		}
		else if (_centerEyeCamera.stereoTargetEye != StereoTargetEyeMask.Both)
		{
			_centerEyeCamera.stereoTargetEye = StereoTargetEyeMask.Both;
		}
		if (disableEyeAnchorCameras)
		{
			_centerEyeCamera.enabled = false;
			_leftEyeCamera.enabled = false;
			_rightEyeCamera.enabled = false;
			return;
		}
		if (_centerEyeCamera.enabled == usePerEyeCameras || _leftEyeCamera.enabled == !usePerEyeCameras || _rightEyeCamera.enabled == (!usePerEyeCameras || (flag && !OVRPlugin.EyeTextureArrayEnabled)))
		{
			_skipUpdate = true;
		}
		_centerEyeCamera.enabled = !usePerEyeCameras;
		_leftEyeCamera.enabled = usePerEyeCameras;
		_rightEyeCamera.enabled = usePerEyeCameras && (!flag || OVRPlugin.EyeTextureArrayEnabled);
	}

	protected virtual Transform ConfigureAnchor(Transform root, string name)
	{
		Transform transform = ((root != null) ? root.Find(name) : null);
		if (transform == null)
		{
			transform = base.transform.Find(name);
		}
		if (transform == null)
		{
			transform = new GameObject(name).transform;
		}
		transform.name = name;
		transform.parent = ((root != null) ? root : base.transform);
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		return transform;
	}

	public virtual Matrix4x4 ComputeTrackReferenceMatrix()
	{
		if (centerEyeAnchor == null)
		{
			Debug.LogError("centerEyeAnchor is required");
			return Matrix4x4.identity;
		}
		OVRPose identity = OVRPose.identity;
		if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.Head, NodeStatePropertyType.Position, OVRPlugin.Node.Head, OVRPlugin.Step.Render, out var retVec))
		{
			identity.position = retVec;
		}
		if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.Head, NodeStatePropertyType.Orientation, OVRPlugin.Node.Head, OVRPlugin.Step.Render, out var retQuat))
		{
			identity.orientation = retQuat;
		}
		OVRPose oVRPose = identity.Inverse();
		Matrix4x4 matrix4x = Matrix4x4.TRS(oVRPose.position, oVRPose.orientation, Vector3.one);
		return centerEyeAnchor.localToWorldMatrix * matrix4x;
	}
}
