using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace VRTK
{
	public abstract class VRTK_BasePointerRenderer : MonoBehaviour
	{
		public enum VisibilityStates
		{
			OnWhenActive = 0,
			AlwaysOn = 1,
			AlwaysOff = 2
		}

		[Serializable]
		public sealed class PointerOriginSmoothingSettings
		{
			[Tooltip("Whether or not to smooth the position of the pointer origin when positioning the pointer tip.")]
			public bool smoothsPosition;

			[Tooltip("The maximum allowed distance between the unsmoothed pointer origin and the smoothed pointer origin per frame to use for smoothing.")]
			public float maxAllowedPerFrameDistanceDifference = 0.003f;

			[Tooltip("Whether or not to smooth the rotation of the pointer origin when positioning the pointer tip.")]
			public bool smoothsRotation;

			[Tooltip("The maximum allowed angle between the unsmoothed pointer origin and the smoothed pointer origin per frame to use for smoothing.")]
			public float maxAllowedPerFrameAngleDifference = 1.5f;
		}

		[Header("Renderer Supplement Settings")]
		[Tooltip("An optional Play Area Cursor generator to add to the destination position of the pointer tip.")]
		public VRTK_PlayAreaCursor playareaCursor;

		[Tooltip("A custom VRTK_PointerDirectionIndicator to use to determine the rotation given to the destination set event.")]
		public VRTK_PointerDirectionIndicator directionIndicator;

		[Header("General Renderer Settings")]
		[Tooltip("A custom raycaster to use for the pointer's raycasts to ignore.")]
		public VRTK_CustomRaycast customRaycast;

		[Tooltip("Specifies the smoothing to be applied to the pointer origin when positioning the pointer tip.")]
		public PointerOriginSmoothingSettings pointerOriginSmoothingSettings = new PointerOriginSmoothingSettings();

		[Header("General Appearance Settings")]
		[Tooltip("The colour to change the pointer materials when the pointer collides with a valid object. Set to `Color.clear` to bypass changing material colour on valid collision.")]
		public Color validCollisionColor = Color.green;

		[Tooltip("The colour to change the pointer materials when the pointer is not colliding with anything or with an invalid object. Set to `Color.clear` to bypass changing material colour on invalid collision.")]
		public Color invalidCollisionColor = Color.red;

		[Tooltip("Determines when the main tracer of the pointer renderer will be visible.")]
		public VisibilityStates tracerVisibility;

		[Tooltip("Determines when the cursor/tip of the pointer renderer will be visible.")]
		public VisibilityStates cursorVisibility;

		protected const float BEAM_ADJUST_OFFSET = 0.0001f;

		protected VRTK_Pointer controllingPointer;

		protected RaycastHit destinationHit;

		protected Material defaultMaterial;

		protected Color previousColor;

		protected Color currentColor;

		protected VRTK_PolicyList invalidListPolicy;

		protected VRTK_NavMeshData navMeshData;

		protected bool headsetPositionCompensation;

		protected GameObject objectInteractor;

		protected GameObject objectInteractorAttachPoint;

		protected GameObject pointerOriginTransformFollowGameObject;

		protected VRTK_TransformFollow pointerOriginTransformFollow;

		protected VRTK_InteractGrab controllerGrabScript;

		protected Rigidbody savedAttachPoint;

		protected bool attachedToInteractorAttachPoint;

		protected float savedBeamLength;

		protected HashSet<GameObject> makeRendererVisible = new HashSet<GameObject>();

		protected bool tracerVisible;

		protected bool cursorVisible;

		protected LayerMask defaultIgnoreLayer = 4;

		protected SDK_BaseController.ControllerHand cachedAttachedHand;

		protected Transform cachedPointerAttachPoint;

		public abstract GameObject[] GetPointerObjects();

		[Obsolete("`VRTK_BasePointerRenderer.InitalizePointer(givenPointer, givenInvalidListPolicy, givenNavMeshCheckDistance, givenHeadsetPositionCompensation)` has been replaced with the method `VRTK_BasePointerRenderer.InitalizePointer(givenPointer, givenInvalidListPolicy, givenNavMeshData, givenHeadsetPositionCompensation)`. This method will be removed in a future version of VRTK.")]
		public virtual void InitalizePointer(VRTK_Pointer givenPointer, VRTK_PolicyList givenInvalidListPolicy, float givenNavMeshCheckDistance, bool givenHeadsetPositionCompensation)
		{
			VRTK_NavMeshData vRTK_NavMeshData = base.gameObject.AddComponent<VRTK_NavMeshData>();
			vRTK_NavMeshData.distanceLimit = givenNavMeshCheckDistance;
			InitalizePointer(givenPointer, givenInvalidListPolicy, vRTK_NavMeshData, givenHeadsetPositionCompensation);
		}

		public virtual void InitalizePointer(VRTK_Pointer givenPointer, VRTK_PolicyList givenInvalidListPolicy, VRTK_NavMeshData givenNavMeshData, bool givenHeadsetPositionCompensation)
		{
			controllingPointer = givenPointer;
			invalidListPolicy = givenInvalidListPolicy;
			navMeshData = givenNavMeshData;
			headsetPositionCompensation = givenHeadsetPositionCompensation;
			if (controllingPointer != null && controllingPointer.interactWithObjects && controllingPointer.controllerEvents != null && objectInteractor == null)
			{
				controllerGrabScript = controllingPointer.controllerEvents.GetComponentInChildren<VRTK_InteractGrab>();
				CreateObjectInteractor();
			}
			SetupDirectionIndicator();
		}

		public virtual void ResetPointerObjects()
		{
			DestroyPointerOriginTransformFollow();
			DestroyPointerObjects();
			CreatePointerOriginTransformFollow();
			CreatePointerObjects();
		}

		public virtual void Toggle(bool pointerState, bool actualState)
		{
			if (pointerState)
			{
				destinationHit = default(RaycastHit);
			}
			else if (controllingPointer != null)
			{
				controllingPointer.ResetActivationTimer();
				PointerExit(destinationHit);
			}
			ToggleInteraction(pointerState);
			ToggleRenderer(pointerState, actualState);
		}

		public virtual void ToggleInteraction(bool state)
		{
			ToggleObjectInteraction(state);
		}

		public virtual void UpdateRenderer()
		{
			if (playareaCursor != null)
			{
				playareaCursor.SetHeadsetPositionCompensation(headsetPositionCompensation);
				playareaCursor.ToggleState(IsCursorVisible());
			}
			if (directionIndicator != null)
			{
				UpdateDirectionIndicator();
			}
		}

		public virtual RaycastHit GetDestinationHit()
		{
			return destinationHit;
		}

		public virtual bool ValidPlayArea()
		{
			if (!(playareaCursor == null) && playareaCursor.IsActive())
			{
				return !playareaCursor.HasCollided();
			}
			return true;
		}

		public virtual bool IsVisible()
		{
			if (!IsTracerVisible())
			{
				return IsCursorVisible();
			}
			return true;
		}

		public virtual bool IsTracerVisible()
		{
			if (tracerVisibility != VisibilityStates.AlwaysOn)
			{
				return tracerVisible;
			}
			return true;
		}

		public virtual bool IsCursorVisible()
		{
			if (cursorVisibility != VisibilityStates.AlwaysOn)
			{
				return cursorVisible;
			}
			return true;
		}

		public virtual bool IsValidCollision()
		{
			return currentColor != invalidCollisionColor;
		}

		public virtual GameObject GetObjectInteractor()
		{
			return objectInteractor;
		}

		protected abstract void CreatePointerObjects();

		protected abstract void DestroyPointerObjects();

		protected abstract void ToggleRenderer(bool pointerState, bool actualState);

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			cachedPointerAttachPoint = null;
			cachedAttachedHand = SDK_BaseController.ControllerHand.None;
			defaultMaterial = Resources.Load("WorldPointer") as Material;
			makeRendererVisible.Clear();
			CreatePointerOriginTransformFollow();
			CreatePointerObjects();
		}

		protected virtual void OnDisable()
		{
			DestroyPointerObjects();
			if (objectInteractor != null)
			{
				UnityEngine.Object.Destroy(objectInteractor);
			}
			controllerGrabScript = null;
			DestroyPointerOriginTransformFollow();
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnValidate()
		{
			pointerOriginSmoothingSettings.maxAllowedPerFrameDistanceDifference = Mathf.Max(0.0001f, pointerOriginSmoothingSettings.maxAllowedPerFrameDistanceDifference);
			pointerOriginSmoothingSettings.maxAllowedPerFrameAngleDifference = Mathf.Max(0.0001f, pointerOriginSmoothingSettings.maxAllowedPerFrameAngleDifference);
		}

		protected virtual void FixedUpdate()
		{
			if (controllingPointer != null && controllingPointer.interactWithObjects && objectInteractor != null && objectInteractor.activeInHierarchy)
			{
				UpdateObjectInteractor();
			}
			if (pointerOriginTransformFollow != null)
			{
				UpdatePointerOriginTransformFollow();
			}
		}

		protected virtual void ToggleObjectInteraction(bool state)
		{
			if (!(controllingPointer != null) || !controllingPointer.interactWithObjects)
			{
				return;
			}
			if (state && controllingPointer.grabToPointerTip && controllerGrabScript != null && objectInteractorAttachPoint != null)
			{
				savedAttachPoint = controllerGrabScript.controllerAttachPoint;
				controllerGrabScript.controllerAttachPoint = objectInteractorAttachPoint.GetComponent<Rigidbody>();
				attachedToInteractorAttachPoint = true;
			}
			if (!state && controllingPointer.grabToPointerTip && controllerGrabScript != null)
			{
				if (attachedToInteractorAttachPoint)
				{
					controllerGrabScript.ForceRelease(applyGrabbingObjectVelocity: true);
				}
				if (savedAttachPoint != null)
				{
					controllerGrabScript.controllerAttachPoint = savedAttachPoint;
					savedAttachPoint = null;
				}
				attachedToInteractorAttachPoint = false;
				savedBeamLength = 0f;
			}
			if (objectInteractor != null)
			{
				objectInteractor.SetActive(state);
			}
		}

		protected virtual void UpdateObjectInteractor()
		{
			objectInteractor.transform.position = destinationHit.point;
		}

		protected virtual VRTK_ControllerReference GetControllerReference(GameObject reference = null)
		{
			reference = ((reference == null && controllingPointer != null && controllingPointer.controllerEvents != null) ? controllingPointer.controllerEvents.gameObject : reference);
			return VRTK_ControllerReference.GetControllerReference(reference);
		}

		protected virtual Transform GetPointerOriginTransform()
		{
			VRTK_ControllerReference controllerReference = GetControllerReference((controllingPointer != null) ? controllingPointer.attachedTo : null);
			if (VRTK_ControllerReference.IsValid(controllerReference) && (cachedAttachedHand != controllerReference.hand || cachedPointerAttachPoint == null))
			{
				cachedPointerAttachPoint = controllerReference.model.transform.Find(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.AttachPoint, controllerReference.hand));
				cachedAttachedHand = controllerReference.hand;
				pointerOriginTransformFollow.gameObject.SetActive(value: false);
			}
			if (!(cachedPointerAttachPoint != null))
			{
				return base.transform;
			}
			return cachedPointerAttachPoint;
		}

		protected virtual void UpdatePointerOriginTransformFollow()
		{
			pointerOriginTransformFollow.gameObject.SetActive(controllingPointer != null);
			if (controllingPointer != null)
			{
				pointerOriginTransformFollow.gameObjectToFollow = ((controllingPointer.customOrigin == null) ? GetPointerOriginTransform() : controllingPointer.customOrigin).gameObject;
				pointerOriginTransformFollow.enabled = controllingPointer != null;
				pointerOriginTransformFollowGameObject.SetActive(controllingPointer != null);
				pointerOriginTransformFollow.smoothsPosition = pointerOriginSmoothingSettings.smoothsPosition;
				pointerOriginTransformFollow.maxAllowedPerFrameDistanceDifference = pointerOriginSmoothingSettings.maxAllowedPerFrameDistanceDifference;
				pointerOriginTransformFollow.smoothsRotation = pointerOriginSmoothingSettings.smoothsRotation;
				pointerOriginTransformFollow.maxAllowedPerFrameAngleDifference = pointerOriginSmoothingSettings.maxAllowedPerFrameAngleDifference;
			}
		}

		protected Transform GetOrigin(bool smoothed = true)
		{
			if (!smoothed)
			{
				if (!(controllingPointer.customOrigin == null))
				{
					return controllingPointer.customOrigin;
				}
				return GetPointerOriginTransform();
			}
			return pointerOriginTransformFollow.gameObjectToChange.transform;
		}

		protected virtual void PointerEnter(RaycastHit givenHit)
		{
			controllingPointer.PointerEnter(givenHit);
		}

		protected virtual void PointerExit(RaycastHit givenHit)
		{
			controllingPointer.PointerExit(givenHit);
		}

		protected virtual bool ValidDestination()
		{
			bool flag = false;
			if (navMeshData != null)
			{
				if (destinationHit.transform != null)
				{
					flag = NavMesh.SamplePosition(destinationHit.point, out var _, navMeshData.distanceLimit, navMeshData.validAreas);
				}
			}
			else
			{
				flag = true;
			}
			if (flag && destinationHit.collider != null)
			{
				return !VRTK_PolicyList.Check(destinationHit.collider.gameObject, invalidListPolicy);
			}
			return false;
		}

		protected virtual void ToggleElement(GameObject givenObject, bool pointerState, bool actualState, VisibilityStates givenVisibility, ref bool currentVisible)
		{
			if (givenObject != null)
			{
				currentVisible = givenVisibility == VisibilityStates.AlwaysOn || pointerState;
				givenObject.SetActive(currentVisible);
				if (givenVisibility == VisibilityStates.AlwaysOff)
				{
					currentVisible = false;
					ToggleRendererVisibility(givenObject, state: false);
				}
				else if (actualState && givenVisibility != VisibilityStates.AlwaysOn)
				{
					ToggleRendererVisibility(givenObject, state: false);
					AddVisibleRenderer(givenObject);
				}
				else
				{
					ToggleRendererVisibility(givenObject, state: true);
				}
			}
		}

		protected virtual void AddVisibleRenderer(GameObject givenObject)
		{
			makeRendererVisible.Add(givenObject);
		}

		protected virtual void MakeRenderersVisible()
		{
			foreach (GameObject item in new HashSet<GameObject>(makeRendererVisible))
			{
				ToggleRendererVisibility(item, state: true);
			}
			makeRendererVisible.Clear();
		}

		protected virtual void ToggleRendererVisibility(GameObject givenObject, bool state)
		{
			if (givenObject != null)
			{
				Renderer[] componentsInChildren = givenObject.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = state;
				}
			}
		}

		protected virtual void SetupMaterialRenderer(GameObject givenObject)
		{
			if (givenObject != null)
			{
				MeshRenderer component = givenObject.GetComponent<MeshRenderer>();
				component.shadowCastingMode = ShadowCastingMode.Off;
				component.receiveShadows = false;
				component.material = defaultMaterial;
			}
		}

		protected virtual void ChangeColor(Color givenColor)
		{
			previousColor = currentColor;
			if ((playareaCursor != null && playareaCursor.IsActive() && playareaCursor.HasCollided()) || !ValidDestination() || (controllingPointer != null && !controllingPointer.CanSelect()))
			{
				givenColor = invalidCollisionColor;
			}
			if (givenColor != Color.clear)
			{
				currentColor = givenColor;
				ChangeMaterial(givenColor);
			}
			if (previousColor != currentColor)
			{
				EmitStateEvent();
			}
		}

		protected virtual void EmitStateEvent()
		{
			if (controllingPointer != null)
			{
				if (IsValidCollision())
				{
					controllingPointer.OnPointerStateValid();
				}
				else
				{
					controllingPointer.OnPointerStateInvalid();
				}
			}
		}

		protected virtual void ChangeMaterial(Color givenColor)
		{
			if (playareaCursor != null)
			{
				playareaCursor.SetMaterialColor(givenColor, IsValidCollision());
			}
			if (directionIndicator != null)
			{
				directionIndicator.SetMaterialColor(givenColor, IsValidCollision());
			}
		}

		protected virtual void ChangeMaterialColor(GameObject givenObject, Color givenColor)
		{
			if (!(givenObject != null))
			{
				return;
			}
			Renderer[] componentsInChildren = givenObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (renderer.material != null)
				{
					renderer.material.EnableKeyword("_EMISSION");
					if (renderer.material.HasProperty("_Color"))
					{
						renderer.material.color = givenColor;
					}
					if (renderer.material.HasProperty("_EmissionColor"))
					{
						renderer.material.SetColor("_EmissionColor", VRTK_SharedMethods.ColorDarken(givenColor, 50f));
					}
				}
			}
		}

		protected virtual void CreateObjectInteractor()
		{
			objectInteractor = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "BasePointerRenderer_ObjectInteractor_Container"));
			objectInteractor.transform.SetParent(controllingPointer.controllerEvents.transform);
			objectInteractor.transform.localPosition = Vector3.zero;
			objectInteractor.layer = LayerMask.NameToLayer("Ignore Raycast");
			VRTK_PlayerObject.SetPlayerObject(objectInteractor, VRTK_PlayerObject.ObjectTypes.Pointer);
			GameObject obj = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "BasePointerRenderer_ObjectInteractor_Collider"));
			obj.transform.SetParent(objectInteractor.transform);
			obj.transform.localPosition = Vector3.zero;
			obj.layer = LayerMask.NameToLayer("Ignore Raycast");
			obj.AddComponent<SphereCollider>().isTrigger = true;
			VRTK_PlayerObject.SetPlayerObject(obj, VRTK_PlayerObject.ObjectTypes.Pointer);
			if (controllingPointer.grabToPointerTip)
			{
				objectInteractorAttachPoint = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "BasePointerRenderer_ObjectInteractor_AttachPoint"));
				objectInteractorAttachPoint.transform.SetParent(objectInteractor.transform);
				objectInteractorAttachPoint.transform.localPosition = Vector3.zero;
				objectInteractorAttachPoint.layer = LayerMask.NameToLayer("Ignore Raycast");
				Rigidbody rigidbody = objectInteractorAttachPoint.AddComponent<Rigidbody>();
				rigidbody.isKinematic = true;
				rigidbody.freezeRotation = true;
				rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
				VRTK_PlayerObject.SetPlayerObject(objectInteractorAttachPoint, VRTK_PlayerObject.ObjectTypes.Pointer);
			}
			ScaleObjectInteractor(Vector3.one);
			objectInteractor.SetActive(value: false);
		}

		protected virtual void ScaleObjectInteractor(Vector3 scaleAmount)
		{
			if (objectInteractor != null)
			{
				objectInteractor.transform.SetGlobalScale(scaleAmount);
			}
		}

		protected virtual void CreatePointerOriginTransformFollow()
		{
			pointerOriginTransformFollowGameObject = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "BasePointerRenderer_Origin_Smoothed"));
			pointerOriginTransformFollow = pointerOriginTransformFollowGameObject.AddComponent<VRTK_TransformFollow>();
			pointerOriginTransformFollow.enabled = false;
			pointerOriginTransformFollow.moment = VRTK_TransformFollow.FollowMoment.OnFixedUpdate;
			pointerOriginTransformFollow.followsScale = false;
		}

		protected virtual void DestroyPointerOriginTransformFollow()
		{
			if (pointerOriginTransformFollowGameObject != null)
			{
				UnityEngine.Object.Destroy(pointerOriginTransformFollowGameObject);
				pointerOriginTransformFollowGameObject = null;
				pointerOriginTransformFollow = null;
			}
		}

		protected virtual float OverrideBeamLength(float currentLength)
		{
			if (controllerGrabScript == null || !controllerGrabScript.GetGrabbedObject())
			{
				savedBeamLength = 0f;
			}
			if (controllingPointer != null && controllingPointer.interactWithObjects && controllingPointer.grabToPointerTip && attachedToInteractorAttachPoint && controllerGrabScript != null && (bool)controllerGrabScript.GetGrabbedObject())
			{
				savedBeamLength = ((savedBeamLength == 0f) ? currentLength : savedBeamLength);
				return savedBeamLength;
			}
			return currentLength;
		}

		protected virtual void UpdateDependencies(Vector3 location)
		{
			if (playareaCursor != null)
			{
				playareaCursor.SetPlayAreaCursorTransform(location);
			}
		}

		protected virtual void SetupDirectionIndicator()
		{
			if (directionIndicator != null && controllingPointer != null && controllingPointer.controllerEvents != null)
			{
				directionIndicator.Initialize(controllingPointer.controllerEvents);
			}
		}

		protected virtual void UpdateDirectionIndicator()
		{
			RaycastHit raycastHit = GetDestinationHit();
			directionIndicator.SetPosition(ShowDirectionIndicator() && raycastHit.collider != null, raycastHit.point);
		}

		protected virtual bool ShowDirectionIndicator()
		{
			switch (directionIndicator.indicatorVisibility)
			{
			case VRTK_PointerDirectionIndicator.VisibilityState.OnWhenPointerActive:
				return controllingPointer.IsPointerActive();
			case VRTK_PointerDirectionIndicator.VisibilityState.AlwaysOnWithPointerCursor:
				if (!IsCursorVisible())
				{
					return controllingPointer.IsPointerActive();
				}
				return true;
			default:
				return false;
			}
		}
	}
}
