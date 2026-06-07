using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls.VRTK;
using DV.Interaction;
using DV.Utils;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_HandPoseController_DV : MonoBehaviour
	{
		public class HandPreRenderHook : MonoBehaviour
		{
			[NonSerialized]
			public List<VRTK_HandPoseController_DV> handPoses = new List<VRTK_HandPoseController_DV>();

			private void OnPreRender()
			{
				for (int num = handPoses.Count - 1; num >= 0; num--)
				{
					if ((bool)handPoses[num])
					{
						if (handPoses[num].overrideState.HasValue)
						{
							handPoses[num].visualRoot.localPosition = handPoses[num].lastVisualPos;
							handPoses[num].visualRoot.localRotation = handPoses[num].lastVisualRot;
						}
						else
						{
							handPoses[num].UpdateHandCorrection();
						}
					}
					else
					{
						handPoses.RemoveAt(num);
					}
				}
			}
		}

		private enum PoseSource
		{
			Idle = 0,
			NearTouched = 1,
			Touched = 2,
			Grabbing = 3
		}

		public const string ANCHORS_PARENT_NAME = "HandRoot/PipaAnchors";

		private const float SNAPPING_IN_SPEED = 8f;

		private const float SNAPPING_OUT_SPEED = 5f;

		private const int GRAB_POSE_RESET_FRAMES = 5;

		[Header("Pose offset")]
		public Transform scaleTransform;

		public Transform visualRoot;

		public Transform orientationReference;

		[Header("Pose blend ranges")]
		public float blendRangeMin = 0.02f;

		public float blendRangeMax = 0.1f;

		private VRTK_InteractGrab_DV grab;

		private VRTK_InteractTouch_DV touch;

		private VRTK_InteractNearTouch_DV nearTouch;

		private Transform pipaTransform;

		private HandPose handPoseState;

		private Animator handAnimator;

		public Dictionary<HandPose, Transform> poseToAnchor = new Dictionary<HandPose, Transform>();

		private static readonly HandPose[] PoseStates = (HandPose[])Enum.GetValues(typeof(HandPose));

		private static int[] PoseStateHashes = null;

		private float[] blendValues;

		private float[] blendValueTargets;

		private float[] blendValueVelocities;

		private VRTK_InteractableObject_DV[] priorityStack = new VRTK_InteractableObject_DV[Enum.GetValues(typeof(PoseSource)).Length];

		private PoseSource poseSource;

		private bool rightHand;

		private VRTK_SDKTransformModify_DV sdkAdjuster;

		private Vector3 initialVisualPosition = Vector3.zero;

		private Quaternion initialVisualRotation = Quaternion.identity;

		private Quaternion visualRotationLerped = Quaternion.identity;

		private Quaternion adjustedRotation = Quaternion.identity;

		private Vector3 adjustDelta = Vector3.zero;

		private Vector3 localToGrabbedAdjustedPosition = Vector3.zero;

		private Quaternion localToGrabbedAdjustedRotation = Quaternion.identity;

		private Vector3 localToPlayerAdjustedPosition = Vector3.zero;

		private float snapAmountPosition;

		private float snapAmountRotation;

		private bool isSnappingPosition;

		private bool isSnappingRotation;

		private VRTK_InteractGrab interactGrab;

		private ControllerPipa pipa;

		private Coroutine initCoro;

		private bool wasForceGrabbed;

		private int grabbedTimer;

		private GameObject lastGrabbedObject;

		private PipaUtils.AnchorData knownGoodData;

		private PipaUtils.AnchorData currentData;

		private GameObject snapperOwner;

		private AHandPoseSnapper pickedSnapper;

		private GameObject poseSnappersCacheOwner;

		private List<AHandPoseSnapper> poseSnappersCache = new List<AHandPoseSnapper>();

		private static readonly List<AHandPoseSnapper> EmptySnapperList = new List<AHandPoseSnapper>();

		public HandPose? overrideState;

		private Vector3 lastVisualPos;

		private Quaternion lastVisualRot;

		private VRTK_InteractableObject_DV CurrentInteractable => priorityStack[(int)poseSource];

		private void Awake()
		{
			initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
			blendValueTargets = new float[PoseStates.Length];
			blendValues = new float[PoseStates.Length];
			blendValueVelocities = new float[PoseStates.Length];
			blendValues[0] = (blendValueTargets[0] = 1f);
			interactGrab = GetComponentInParent<VRTK_InteractGrab>();
			interactGrab.ControllerStartGrabInteractableObject += OnGrabInteractableObject;
			if (PoseStateHashes == null)
			{
				PoseStateHashes = new int[PoseStates.Length];
				for (int i = 0; i < PoseStates.Length; i++)
				{
					PoseStateHashes[i] = Animator.StringToHash("Pose_" + PoseStates[i]);
				}
			}
			knownGoodData = PipaUtils.GetAnchorData("SteamVR", "QuestTouch");
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
			if (rightHand && SetupDeviceSpecificControls.AreControlsSetRight)
			{
				OnControlsSet(SDK_BaseController.ControllerHand.Right);
			}
			if (!rightHand && SetupDeviceSpecificControls.AreControlsSetLeft)
			{
				OnControlsSet(SDK_BaseController.ControllerHand.Left);
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand hand)
		{
			if (rightHand == (hand == SDK_BaseController.ControllerHand.Right))
			{
				VRTK_ControllerReference ctrlRef = (rightHand ? VRTK_DeviceFinder.GetControllerReferenceRightHand() : VRTK_DeviceFinder.GetControllerReferenceLeftHand());
				currentData = PipaUtils.GetAnchorData(ctrlRef);
			}
		}

		private List<AHandPoseSnapper> GetSnappersFor(GameObject target)
		{
			if (target != poseSnappersCacheOwner)
			{
				poseSnappersCacheOwner = target;
				target.GetComponents(poseSnappersCache);
			}
			return poseSnappersCache;
		}

		private AHandPoseSnapper GetClosestSnapper(GameObject target)
		{
			if (target == null)
			{
				return null;
			}
			AHandPoseSnapper result = null;
			float num = float.MaxValue;
			List<AHandPoseSnapper> snappersFor = GetSnappersFor(target);
			Vector3 position = pipaTransform.position;
			foreach (AHandPoseSnapper item in snappersFor)
			{
				float num2 = Vector3.SqrMagnitude(item.AdjustPosition(rightHand, visualRoot.parent.position, position, orientationReference.forward, orientationReference.up, orientationReference.rotation) - position);
				if (num2 < num)
				{
					num = num2;
					result = item;
				}
			}
			return result;
		}

		private void OnGrabInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			AHandPoseSnapper closestSnapper = GetClosestSnapper(e.target);
			if ((bool)closestSnapper)
			{
				pickedSnapper = closestSnapper;
				snapperOwner = e.target;
				closestSnapper.EnterInteraction(this);
			}
		}

		private void OnCameraChanged()
		{
			if (!(PlayerManager.ActiveCamera == null))
			{
				HandPreRenderHook handPreRenderHook = PlayerManager.ActiveCamera.GetComponent<HandPreRenderHook>();
				if (handPreRenderHook == null)
				{
					handPreRenderHook = PlayerManager.ActiveCamera.gameObject.AddComponent<HandPreRenderHook>();
				}
				if (!handPreRenderHook.handPoses.Contains(this))
				{
					handPreRenderHook.handPoses.Add(this);
				}
			}
		}

		private void Update()
		{
			if (initCoro != null || !TimeUtil.IsFlowing)
			{
				return;
			}
			CheckStack();
			if (overrideState.HasValue)
			{
				UpdateHandPoseState(overrideState.Value, 0f);
			}
			else if (CurrentInteractable != null)
			{
				switch (poseSource)
				{
				case PoseSource.Grabbing:
					handPoseState = GetGrabPoseFromInteractable(CurrentInteractable);
					break;
				case PoseSource.Touched:
					handPoseState = GetTouchPoseFromInteractable(CurrentInteractable);
					break;
				case PoseSource.NearTouched:
					handPoseState = GetNearTouchPoseFromInteractable(CurrentInteractable);
					break;
				}
				float distance = ((poseSource == PoseSource.NearTouched) ? nearTouch.ClosestDistance : 0f);
				UpdateHandPoseState(handPoseState, distance);
			}
			else
			{
				handPoseState = HandPose.Idle;
				UpdateHandPoseState(handPoseState, float.MaxValue);
			}
			if (isSnappingPosition)
			{
				snapAmountPosition = Mathf.Clamp01(snapAmountPosition + Time.unscaledDeltaTime * 8f);
			}
			else
			{
				snapAmountPosition = Mathf.Clamp01(snapAmountPosition - Time.unscaledDeltaTime * 5f);
			}
			if (isSnappingRotation)
			{
				snapAmountRotation = Mathf.Clamp01(snapAmountRotation + Time.unscaledDeltaTime * 8f);
			}
			else
			{
				snapAmountRotation = Mathf.Clamp01(snapAmountRotation - Time.unscaledDeltaTime * 5f);
			}
			for (int i = 0; i < PoseStates.Length; i++)
			{
				blendValues[i] = Mathf.SmoothDamp(blendValues[i], blendValueTargets[i], ref blendValueVelocities[i], 0.15f);
				if (handAnimator != null)
				{
					handAnimator.SetFloat(PoseStateHashes[i], blendValues[i]);
				}
			}
		}

		private void UpdateHandCorrection()
		{
			if (initCoro != null)
			{
				return;
			}
			bool flag = isSnappingPosition;
			bool flag2 = isSnappingRotation;
			if (grab.GetGrabbedObject() == lastGrabbedObject)
			{
				grabbedTimer++;
			}
			else
			{
				grabbedTimer = 0;
			}
			lastGrabbedObject = grab.GetGrabbedObject();
			if (grab.GetGrabbedObject() != null)
			{
				GameObject grabbedObject = grab.GetGrabbedObject();
				AHandPoseSnapper aHandPoseSnapper;
				if (grabbedObject == snapperOwner)
				{
					aHandPoseSnapper = pickedSnapper;
				}
				else
				{
					aHandPoseSnapper = (pickedSnapper = GetClosestSnapper(grabbedObject));
					snapperOwner = grabbedObject;
				}
				if (aHandPoseSnapper != null)
				{
					Vector3 position = pipaTransform.position;
					Quaternion rotation = orientationReference.rotation;
					adjustDelta = poseToAnchor[priorityStack[3].interactionHandPoses.GrabPose].localPosition;
					Vector3 position2;
					if (grabbedTimer < 5 || !flag || !aHandPoseSnapper.HoldPosition)
					{
						position2 = aHandPoseSnapper.AdjustPosition(rightHand, visualRoot.parent.position, position, orientationReference.forward, orientationReference.up, rotation);
						localToGrabbedAdjustedPosition = aHandPoseSnapper.HoldTransform.InverseTransformPoint(position2);
					}
					else
					{
						position2 = aHandPoseSnapper.HoldTransform.TransformPoint(localToGrabbedAdjustedPosition);
					}
					localToPlayerAdjustedPosition = PlayerManager.PlayerTransform.InverseTransformPoint(position2);
					if (grabbedTimer < 5 || !flag2 || !aHandPoseSnapper.HoldRotation)
					{
						adjustedRotation = aHandPoseSnapper.AdjustRotation(rightHand, visualRoot.parent.position, position, orientationReference.forward, orientationReference.up, rotation);
						if (!rightHand)
						{
							adjustedRotation *= Quaternion.AngleAxis(180f, Vector3.up);
						}
						localToGrabbedAdjustedRotation = Quaternion.Inverse(aHandPoseSnapper.HoldTransform.rotation) * adjustedRotation;
						adjustedRotation *= Quaternion.Inverse(orientationReference.localRotation);
					}
					else
					{
						adjustedRotation = aHandPoseSnapper.HoldTransform.rotation * localToGrabbedAdjustedRotation;
						adjustedRotation *= Quaternion.Inverse(orientationReference.localRotation);
					}
					isSnappingPosition = true;
					isSnappingRotation = true;
				}
				else
				{
					Vector3 vector = default(Vector3);
					ItemVRTK component = grab.GetGrabbedObject().GetComponent<ItemVRTK>();
					vector = ((!component || !wasForceGrabbed) ? pipaTransform.position : (rightHand ? component.GrabAnchorRight.position : component.GrabAnchorLeft.position));
					adjustDelta = poseToAnchor[priorityStack[3].interactionHandPoses.GrabPose].localPosition;
					Vector3 position3;
					if (grabbedTimer < 5 || !flag)
					{
						position3 = vector;
						localToGrabbedAdjustedPosition = grabbedObject.transform.InverseTransformPoint(position3);
					}
					else
					{
						position3 = grabbedObject.transform.TransformPoint(localToGrabbedAdjustedPosition);
					}
					localToPlayerAdjustedPosition = PlayerManager.PlayerTransform.InverseTransformPoint(position3);
					isSnappingPosition = true;
					isSnappingRotation = false;
				}
			}
			else
			{
				isSnappingPosition = false;
				isSnappingRotation = false;
			}
			Vector3 zero = Vector3.zero;
			if (pipaTransform != null && visualRoot != null)
			{
				float num = 0f;
				for (int i = 0; i < PoseStates.Length; i++)
				{
					if (poseToAnchor.TryGetValue(PoseStates[i], out var value))
					{
						zero += blendValues[i] * (GetLocalScaleAdjustedPos(value.position) - GetLocalScaleAdjustedPos(poseToAnchor[HandPose.Idle].position));
						num += blendValues[i];
					}
				}
				if (num > 0f)
				{
					zero /= num;
				}
			}
			float num2 = Mathf.SmoothStep(0f, 1f, snapAmountPosition);
			float t = Mathf.SmoothStep(0f, 1f, snapAmountRotation);
			HandPose key = ((grab.GetGrabbedObject() != null) ? priorityStack[3].interactionHandPoses.GrabPose : HandPose.Idle);
			if (overrideState.HasValue)
			{
				key = overrideState.Value;
			}
			visualRotationLerped = Quaternion.Slerp(b: (isSnappingRotation || !poseToAnchor.TryGetValue(key, out var value2)) ? initialVisualRotation : value2.localRotation, a: visualRotationLerped, t: Time.deltaTime * 50f);
			visualRoot.localRotation = visualRotationLerped;
			visualRoot.rotation = Quaternion.Slerp(visualRoot.rotation, adjustedRotation, t);
			Vector3 a = visualRoot.parent.TransformPoint(initialVisualPosition);
			Vector3 b = PlayerManager.PlayerTransform.TransformPoint(localToPlayerAdjustedPosition) - visualRoot.TransformVector(adjustDelta);
			visualRoot.position = Vector3.Lerp(a, b, num2);
			visualRoot.localPosition -= zero * (1f - num2);
			lastVisualPos = visualRoot.localPosition;
			lastVisualRot = visualRoot.localRotation;
		}

		private void OnDestroy()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			if (initCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(initCoro);
			}
			PlayerManager.CameraChanged -= OnCameraChanged;
		}

		private Vector3 GetLocalScaleAdjustedPos(Vector3 pos)
		{
			return scaleTransform.InverseTransformPoint(pos);
		}

		private IEnumerator Initialize()
		{
			rightHand = false;
			if (base.transform.parent.gameObject.name.ToLower().Contains("right"))
			{
				rightHand = true;
			}
			else if (!base.transform.parent.gameObject.name.ToLower().Contains("left"))
			{
				Debug.LogError("Please make sure this component (VRTK_HandPoseController_DV) is on a child of a controller object that has either 'left' or 'right' in its name. Thank you.", this);
			}
			if (rightHand)
			{
				while (!SetupDeviceSpecificControls.AreControlsSetRight)
				{
					yield return null;
				}
			}
			else
			{
				while (!SetupDeviceSpecificControls.AreControlsSetLeft)
				{
					yield return null;
				}
			}
			GameObject gameObject = (rightHand ? VRTK_DeviceFinder.GetControllerRightHand(getActual: true) : VRTK_DeviceFinder.GetControllerLeftHand(getActual: true));
			grab = gameObject.GetComponentInChildren<VRTK_InteractGrab_DV>();
			touch = gameObject.GetComponentInChildren<VRTK_InteractTouch_DV>();
			nearTouch = gameObject.GetComponentInChildren<VRTK_InteractNearTouch_DV>();
			handAnimator = gameObject.GetComponentInChildren<Animator>();
			pipaTransform = PipaUtils.PipaTransform(gameObject);
			InitializePoseToAnchor();
			handPoseState = HandPose.Idle;
			UpdatePipaPosition();
			SetupListeners(on: true);
			sdkAdjuster = GetComponent<VRTK_SDKTransformModify_DV>();
			if ((bool)sdkAdjuster)
			{
				while (!sdkAdjuster.Applied)
				{
					yield return null;
				}
			}
			Debug.Log("SDK adjuster done for " + (rightHand ? "RIGHT" : "LEFT") + " hand controller, proceeding...");
			initialVisualPosition = visualRoot.localPosition;
			initialVisualRotation = visualRoot.localRotation;
			while (pipa == null)
			{
				pipa = base.transform.parent.gameObject.GetComponentInChildren<ControllerPipa>();
				yield return null;
			}
			while (PlayerManager.ActiveCamera == null)
			{
				yield return null;
			}
			OnCameraChanged();
			PlayerManager.CameraChanged += OnCameraChanged;
			UpdatePipaPosition();
			initCoro = null;
		}

		private void InitializePoseToAnchor()
		{
			Transform transform = base.transform.Find("HandRoot/PipaAnchors");
			if (transform == null)
			{
				Debug.LogError("Missing anchor parent. Pipa will not be updated with pose change.", this);
				return;
			}
			foreach (HandPose item in Enum.GetValues(typeof(HandPose)).Cast<HandPose>())
			{
				if (item != HandPose.Generic)
				{
					string text = item.ToString();
					Transform transform2 = transform.Find(text);
					if (transform2 != null)
					{
						poseToAnchor.Add(item, transform2);
					}
					else
					{
						Debug.LogError("Could not find " + text + " child");
					}
				}
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				nearTouch.ControllerNearTouchInteractableObject += OnEnterInteractionNearTouch;
				nearTouch.ControllerNearUntouchInteractableObject += OnExitInteractionNearTouch;
				touch.ControllerTouchInteractableObject += OnEnterInteractionTouch;
				touch.ControllerUntouchInteractableObject += OnExitInteractionTouch;
				grab.ControllerGrabInteractableObject += OnEnterInteractionGrab;
				grab.ControllerUngrabInteractableObject += OnExitInteractionGrab;
				grab.AboutToForceGrab += OnAboutToForceGrab;
			}
			else
			{
				nearTouch.ControllerNearTouchInteractableObject -= OnEnterInteractionNearTouch;
				nearTouch.ControllerNearUntouchInteractableObject -= OnExitInteractionNearTouch;
				touch.ControllerTouchInteractableObject -= OnEnterInteractionTouch;
				touch.ControllerUntouchInteractableObject -= OnExitInteractionTouch;
				grab.ControllerGrabInteractableObject -= OnEnterInteractionGrab;
				grab.ControllerUngrabInteractableObject -= OnExitInteractionGrab;
				grab.AboutToForceGrab -= OnAboutToForceGrab;
			}
		}

		private void OnAboutToForceGrab(bool isitem, bool usinggrabbutton)
		{
			if (!usinggrabbutton)
			{
				wasForceGrabbed = true;
			}
		}

		private void UpdateHandPoseState(HandPose desiredPose, float distance)
		{
			float num = 1f - Mathf.Clamp01(Mathf.InverseLerp(blendRangeMin, blendRangeMax, distance));
			for (int i = 0; i < PoseStates.Length; i++)
			{
				if (PoseStates[i] != HandPose.Idle)
				{
					blendValueTargets[i] = ((desiredPose == PoseStates[i]) ? num : 0f);
				}
				else
				{
					blendValueTargets[i] = ((desiredPose == PoseStates[i]) ? 1f : (1f - num));
				}
			}
			handPoseState = desiredPose;
			UpdatePipaPosition();
		}

		private void OnEnterInteractionGrab(object sender, ObjectInteractEventArgs e)
		{
			OnEnterInteraction(sender, e, PoseSource.Grabbing);
			VRTK_InteractableObject_DV component = e.target.GetComponent<VRTK_InteractableObject_DV>();
			if (!(component == null))
			{
				ItemVRTK component2 = e.target.GetComponent<ItemVRTK>();
				component.interactionHandPoses.SetForceGrabbed(wasForceGrabbed || !component2 || !component2.SpecItem.precisionGrab);
			}
		}

		private void OnEnterInteractionTouch(object sender, ObjectInteractEventArgs e)
		{
			OnEnterInteraction(sender, e, PoseSource.Touched);
		}

		private void OnEnterInteractionNearTouch(object sender, ObjectInteractEventArgs e)
		{
			OnEnterInteraction(sender, e, PoseSource.NearTouched);
		}

		private void OnExitInteractionGrab(object sender, ObjectInteractEventArgs e)
		{
			OnExitInteraction(sender, e, PoseSource.Grabbing);
			wasForceGrabbed = false;
		}

		private void OnExitInteractionTouch(object sender, ObjectInteractEventArgs e)
		{
			OnExitInteraction(sender, e, PoseSource.Touched);
		}

		private void OnExitInteractionNearTouch(object sender, ObjectInteractEventArgs e)
		{
			OnExitInteraction(sender, e, PoseSource.NearTouched);
		}

		private void OnEnterInteraction(object sender, ObjectInteractEventArgs e, PoseSource source)
		{
			VRTK_InteractableObject_DV component = e.target.GetComponent<VRTK_InteractableObject_DV>();
			if (!(component == null))
			{
				priorityStack[(int)source] = component;
				if (source > poseSource)
				{
					poseSource = source;
				}
				CheckStack();
			}
		}

		private void OnExitInteraction(object sender, ObjectInteractEventArgs e, PoseSource source)
		{
			VRTK_InteractableObject_DV component = e.target.GetComponent<VRTK_InteractableObject_DV>();
			if (priorityStack[(int)source] == component)
			{
				priorityStack[(int)source] = null;
				if (source == PoseSource.Grabbing)
				{
					isSnappingPosition = false;
				}
				CheckStack();
			}
		}

		private void CheckStack()
		{
			if (priorityStack[3] == null || priorityStack[3].GetGrabbingObject() == null)
			{
				priorityStack[3] = null;
				if (poseSource == PoseSource.Grabbing)
				{
					poseSource--;
				}
			}
			if (priorityStack[2] == null && poseSource == PoseSource.Touched)
			{
				poseSource--;
			}
			if (poseSource < PoseSource.NearTouched && nearTouch.NearCount > 0)
			{
				poseSource = PoseSource.NearTouched;
			}
			if (poseSource == PoseSource.NearTouched)
			{
				priorityStack[1] = nearTouch.CurrentObject;
			}
			if (priorityStack[1] == null || nearTouch.NearCount == 0)
			{
				priorityStack[1] = null;
				if (poseSource == PoseSource.NearTouched)
				{
					poseSource--;
				}
			}
		}

		private HandPose GetGrabPoseFromInteractable(VRTK_InteractableObject_DV io)
		{
			if (io.interactionHandPoses != null)
			{
				HandPose grabPose = io.interactionHandPoses.GrabPose;
				if (grabPose != HandPose.Generic)
				{
					return grabPose;
				}
			}
			return HandPose.Grab;
		}

		private HandPose GetNearTouchPoseFromInteractable(VRTK_InteractableObject_DV io)
		{
			if (io.interactionHandPoses != null)
			{
				HandPose nearTouchPose = io.interactionHandPoses.nearTouchPose;
				if (nearTouchPose != HandPose.Generic)
				{
					return nearTouchPose;
				}
			}
			if (!io.isGrabbable)
			{
				return HandPose.Point;
			}
			return HandPose.PreGrab;
		}

		private HandPose GetTouchPoseFromInteractable(VRTK_InteractableObject_DV io)
		{
			if (io.interactionHandPoses != null)
			{
				HandPose touchPose = io.interactionHandPoses.touchPose;
				if (touchPose != HandPose.Generic)
				{
					return touchPose;
				}
			}
			if (!io.isGrabbable)
			{
				return HandPose.Point;
			}
			return HandPose.PreGrab;
		}

		private void UpdatePipaPosition()
		{
			Transform value;
			if (pipaTransform == null)
			{
				Debug.LogError("Pipa transform reference missing!", this);
			}
			else if (poseToAnchor.TryGetValue(HandPose.Idle, out value))
			{
				pipaTransform.position = value.position;
				Quaternion handRotation = knownGoodData.handRotation;
				Quaternion handRotation2 = currentData.handRotation;
				pipaTransform.localRotation = handRotation2 * Quaternion.Inverse(handRotation);
				if (!rightHand)
				{
					Vector3 right = Vector3.right;
					Vector3 inDirection = pipaTransform.localRotation * Vector3.forward;
					Vector3 inDirection2 = pipaTransform.localRotation * Vector3.up;
					inDirection = Vector3.Reflect(inDirection, right);
					inDirection2 = Vector3.Reflect(inDirection2, right);
					pipaTransform.localRotation = Quaternion.LookRotation(inDirection, inDirection2);
				}
			}
		}
	}
}
