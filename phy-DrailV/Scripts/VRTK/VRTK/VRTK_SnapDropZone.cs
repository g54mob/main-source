using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using VRTK.Highlighters;

namespace VRTK
{
	[ExecuteInEditMode]
	public class VRTK_SnapDropZone : MonoBehaviour
	{
		public enum SnapTypes
		{
			UseKinematic = 0,
			UseJoint = 1,
			UseParenting = 2
		}

		[Tooltip("A game object that is used to draw the highlighted destination for within the drop zone. This object will also be created in the Editor for easy placement.")]
		public GameObject highlightObjectPrefab;

		[Tooltip("The Snap Type to apply when a valid interactable object is dropped within the snap zone.")]
		public SnapTypes snapType;

		[Tooltip("The amount of time it takes for the object being snapped to move into the new snapped position, rotation and scale.")]
		public float snapDuration;

		[Tooltip("If this is checked then the scaled size of the snap drop zone will be applied to the object that is snapped to it.")]
		public bool applyScalingOnSnap;

		[Tooltip("If this is checked then when the snapped object is unsnapped from the drop zone, a clone of the unsnapped object will be snapped back into the drop zone.")]
		public bool cloneNewOnUnsnap;

		[Tooltip("The colour to use when showing the snap zone is active. This is used as the highlight colour when no object is hovering but `Highlight Always Active` is true.")]
		public Color highlightColor = Color.clear;

		[Tooltip("The colour to use when showing the snap zone is active and a valid object is hovering. If this is `Color.clear` then the `Highlight Color` will be used.")]
		public Color validHighlightColor = Color.clear;

		[Tooltip("The highlight object will always be displayed when the snap drop zone is available even if a valid item isn't being hovered over.")]
		public bool highlightAlwaysActive;

		[Tooltip("A specified VRTK_PolicyList to use to determine which interactable objects will be snapped to the snap drop zone on release.")]
		public VRTK_PolicyList validObjectListPolicy;

		[Tooltip("If this is checked then the drop zone highlight section will be displayed in the scene editor window.")]
		public bool displayDropZoneInEditor = true;

		[Tooltip("The Interactable Object to snap into the dropzone when the drop zone is enabled. The Interactable Object must be valid in any given policy list to snap.")]
		public VRTK_InteractableObject defaultSnappedInteractableObject;

		[Header("Obsolete Settings")]
		[Obsolete("`VRTK_SnapDropZone.defaultSnappedObject` has been replaced with the `VRTK_SnapDropZone.defaultSnappedInteractableObject`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public GameObject defaultSnappedObject;

		protected bool forceSnapped;

		protected bool attemptingDelayedSnap;

		protected GameObject previousPrefab;

		protected GameObject highlightContainer;

		protected GameObject highlightObject;

		protected GameObject highlightEditorObject;

		protected List<VRTK_InteractableObject> currentValidSnapInteractableObjects = new List<VRTK_InteractableObject>();

		protected VRTK_InteractableObject currentSnappedObject;

		protected GameObject objectToClone;

		protected bool[] clonedObjectColliderStates = new bool[0];

		protected bool willSnap;

		protected bool isSnapped;

		protected bool wasSnapped;

		protected bool isHighlighted;

		protected VRTK_BaseHighlighter objectHighlighter;

		protected Coroutine transitionInPlaceRoutine;

		protected Coroutine attemptTransitionAtEndOfFrameRoutine;

		protected Coroutine checkCanSnapRoutine;

		protected bool originalJointCollisionState;

		protected Coroutine overridePreviousStateAtEndOfFrameRoutine;

		protected const string HIGHLIGHT_CONTAINER_NAME = "HighlightContainer";

		protected const string HIGHLIGHT_OBJECT_NAME = "HighlightObject";

		protected const string HIGHLIGHT_EDITOR_OBJECT_NAME = "EditorHighlightObject";

		public event SnapDropZoneEventHandler ObjectEnteredSnapDropZone;

		public event SnapDropZoneEventHandler ObjectExitedSnapDropZone;

		public event SnapDropZoneEventHandler ObjectSnappedToDropZone;

		public event SnapDropZoneEventHandler ObjectUnsnappedFromDropZone;

		public virtual void OnObjectEnteredSnapDropZone(SnapDropZoneEventArgs e)
		{
			if (this.ObjectEnteredSnapDropZone != null)
			{
				this.ObjectEnteredSnapDropZone(this, e);
			}
		}

		public virtual void OnObjectExitedSnapDropZone(SnapDropZoneEventArgs e)
		{
			if (this.ObjectExitedSnapDropZone != null)
			{
				this.ObjectExitedSnapDropZone(this, e);
			}
		}

		public virtual void OnObjectSnappedToDropZone(SnapDropZoneEventArgs e)
		{
			if (this.ObjectSnappedToDropZone != null)
			{
				this.ObjectSnappedToDropZone(this, e);
			}
		}

		public virtual void OnObjectUnsnappedFromDropZone(SnapDropZoneEventArgs e)
		{
			UnsnapObject();
			if (this.ObjectUnsnappedFromDropZone != null)
			{
				this.ObjectUnsnappedFromDropZone(this, e);
			}
		}

		public virtual SnapDropZoneEventArgs SetSnapDropZoneEvent(GameObject interactableObject)
		{
			SnapDropZoneEventArgs result = default(SnapDropZoneEventArgs);
			result.snappedObject = interactableObject;
			return result;
		}

		public virtual void InitaliseHighlightObject(bool removeOldObject = false)
		{
			if (removeOldObject)
			{
				DeleteHighlightObject();
			}
			ChooseDestroyType(base.transform.Find(ObjectPath("EditorHighlightObject")));
			highlightEditorObject = null;
			GenerateObjects();
		}

		public virtual void ForceSnap(GameObject objectToSnap)
		{
			forceSnapped = true;
			ForceSnap(objectToSnap.GetComponentInParent<VRTK_InteractableObject>());
		}

		protected virtual void ForceSnap(VRTK_InteractableObject interactableObjectToSnap)
		{
			if (!(interactableObjectToSnap != null))
			{
				return;
			}
			if (attemptTransitionAtEndOfFrameRoutine != null)
			{
				StopCoroutine(attemptTransitionAtEndOfFrameRoutine);
				attemptingDelayedSnap = false;
			}
			if (checkCanSnapRoutine != null)
			{
				StopCoroutine(checkCanSnapRoutine);
			}
			if (interactableObjectToSnap.IsGrabbed())
			{
				interactableObjectToSnap.ForceStopInteracting();
			}
			if (base.gameObject.activeInHierarchy)
			{
				if (interactableObjectToSnap.IsGrabbed())
				{
					interactableObjectToSnap.ForceStopInteracting();
				}
				attemptTransitionAtEndOfFrameRoutine = StartCoroutine(AttemptForceSnapAtEndOfFrame(interactableObjectToSnap));
			}
		}

		public virtual void ForceUnsnap()
		{
			if (isSnapped && ValidSnapObject(currentSnappedObject, grabState: false))
			{
				currentSnappedObject.ToggleSnapDropZone(this, state: false);
			}
		}

		public virtual bool ValidSnappableObjectIsHovering()
		{
			for (int i = 0; i < currentValidSnapInteractableObjects.Count; i++)
			{
				if (currentValidSnapInteractableObjects[i].IsGrabbed())
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool IsObjectHovering(GameObject checkObject)
		{
			VRTK_InteractableObject componentInParent = checkObject.GetComponentInParent<VRTK_InteractableObject>();
			if (!(componentInParent != null))
			{
				return false;
			}
			return currentValidSnapInteractableObjects.Contains(componentInParent);
		}

		public virtual bool IsInteractableObjectHovering(VRTK_InteractableObject checkObject)
		{
			if (!(checkObject != null))
			{
				return false;
			}
			return currentValidSnapInteractableObjects.Contains(checkObject);
		}

		public virtual List<GameObject> GetHoveringObjects()
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < currentValidSnapInteractableObjects.Count; i++)
			{
				VRTK_SharedMethods.AddListValue(list, currentValidSnapInteractableObjects[i].gameObject);
			}
			return list;
		}

		public virtual List<VRTK_InteractableObject> GetHoveringInteractableObjects()
		{
			return currentValidSnapInteractableObjects;
		}

		public virtual GameObject GetCurrentSnappedObject()
		{
			if (!(currentSnappedObject != null))
			{
				return null;
			}
			return currentSnappedObject.gameObject;
		}

		public virtual VRTK_InteractableObject GetCurrentSnappedInteractableObject()
		{
			return currentSnappedObject;
		}

		public virtual GameObject Clone(Vector3 position)
		{
			VRTK_SnapDropZone component = UnityEngine.Object.Instantiate(base.gameObject, position, base.transform.rotation).GetComponent<VRTK_SnapDropZone>();
			for (int i = 0; i < component.transform.childCount; i++)
			{
				Transform child = component.transform.GetChild(i);
				if (child.GetComponent<VRTK_InteractableObject>() != null)
				{
					UnityEngine.Object.Destroy(child.gameObject);
				}
			}
			if (isSnapped)
			{
				VRTK_InteractableObject vRTK_InteractableObject = currentSnappedObject;
				vRTK_InteractableObject.GetPreviousState(out var previousParent, out var previousKinematic, out var previousGrabbable);
				GameObject gameObject = null;
				if (cloneNewOnUnsnap)
				{
					gameObject = UnityEngine.Object.Instantiate(objectToClone);
					gameObject.SetActive(value: true);
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate(vRTK_InteractableObject.gameObject);
				}
				gameObject.transform.position = component.transform.position;
				component.ForceSnap(gameObject);
				overridePreviousStateAtEndOfFrameRoutine = StartCoroutine(OverridePreviousStateAtEndOfFrame(gameObject.GetComponent<VRTK_InteractableObject>(), previousParent, previousKinematic, previousGrabbable));
			}
			return component.gameObject;
		}

		public virtual GameObject Clone()
		{
			return Clone(Vector3.zero);
		}

		protected virtual void Awake()
		{
			if (Application.isPlaying)
			{
				InitaliseHighlightObject();
			}
		}

		protected virtual void OnApplicationQuit()
		{
			if (objectHighlighter != null)
			{
				objectHighlighter.Unhighlight();
			}
		}

		protected virtual void OnEnable()
		{
			currentValidSnapInteractableObjects.Clear();
			currentSnappedObject = null;
			objectToClone = null;
			clonedObjectColliderStates = new bool[0];
			willSnap = false;
			isSnapped = false;
			wasSnapped = false;
			isHighlighted = false;
			if (defaultSnappedObject != null && defaultSnappedInteractableObject == null)
			{
				defaultSnappedInteractableObject = defaultSnappedObject.GetComponentInParent<VRTK_InteractableObject>();
			}
			DisableHighlightShadows();
			if (!VRTK_SharedMethods.IsEditTime() && Application.isPlaying && defaultSnappedInteractableObject != null)
			{
				ForceSnap(defaultSnappedInteractableObject);
			}
		}

		protected virtual void OnDisable()
		{
			if (transitionInPlaceRoutine != null)
			{
				StopCoroutine(transitionInPlaceRoutine);
			}
			if (attemptTransitionAtEndOfFrameRoutine != null)
			{
				StopCoroutine(attemptTransitionAtEndOfFrameRoutine);
				attemptingDelayedSnap = false;
			}
			if (checkCanSnapRoutine != null)
			{
				StopCoroutine(checkCanSnapRoutine);
			}
			if (overridePreviousStateAtEndOfFrameRoutine != null)
			{
				StopCoroutine(overridePreviousStateAtEndOfFrameRoutine);
			}
			ForceUnsnap();
			SetHighlightObjectActive(state: false);
			UnregisterAllUngrabEvents();
		}

		protected virtual void Update()
		{
			CheckSnappedItemExists();
			CheckPrefabUpdate();
			CreateHighlightersInEditor();
			CheckCurrentValidSnapObjectStillValid();
			previousPrefab = highlightObjectPrefab;
			SetObjectHighlight();
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			CheckCanSnap(collider.GetComponentInParent<VRTK_InteractableObject>());
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			CheckCanUnsnap(collider.GetComponentInParent<VRTK_InteractableObject>());
		}

		protected virtual void CheckCanSnap(VRTK_InteractableObject interactableObjectCheck)
		{
			if (!(interactableObjectCheck != null) || !ValidSnapObject(interactableObjectCheck, grabState: true))
			{
				return;
			}
			AddCurrentValidSnapObject(interactableObjectCheck);
			if (!isSnapped)
			{
				ToggleHighlight(interactableObjectCheck, state: true);
				interactableObjectCheck.SetSnapDropZoneHover(this, state: true);
				if (!willSnap)
				{
					OnObjectEnteredSnapDropZone(SetSnapDropZoneEvent(interactableObjectCheck.gameObject));
				}
				willSnap = true;
				ToggleHighlightColor();
			}
		}

		protected virtual void CheckCanUnsnap(VRTK_InteractableObject interactableObjectCheck)
		{
			if (interactableObjectCheck != null && currentValidSnapInteractableObjects.Contains(interactableObjectCheck) && ValidUnsnap(interactableObjectCheck))
			{
				if (isSnapped && currentSnappedObject == interactableObjectCheck)
				{
					ForceUnsnap();
				}
				RemoveCurrentValidSnapObject(interactableObjectCheck);
				if (!ValidSnappableObjectIsHovering())
				{
					ToggleHighlight(interactableObjectCheck, state: false);
					willSnap = false;
				}
				interactableObjectCheck.SetSnapDropZoneHover(this, state: false);
				if (ValidSnapObject(interactableObjectCheck, grabState: true))
				{
					ToggleHighlightColor();
					OnObjectExitedSnapDropZone(SetSnapDropZoneEvent(interactableObjectCheck.gameObject));
				}
			}
		}

		protected virtual bool ValidUnsnap(VRTK_InteractableObject interactableObjectCheck)
		{
			if (!interactableObjectCheck.IsGrabbed())
			{
				if (snapType != SnapTypes.UseJoint || !float.IsInfinity(GetComponent<Joint>().breakForce))
				{
					return interactableObjectCheck.validDrop == VRTK_InteractableObject.ValidDropTypes.DropAnywhere;
				}
				return false;
			}
			return true;
		}

		protected virtual void SnapObjectToZone(VRTK_InteractableObject objectToSnap, bool checkGrabState = false)
		{
			if (!isSnapped && ValidSnapObject(objectToSnap, grabState: false, checkGrabState))
			{
				SnapObject(objectToSnap, checkGrabState);
			}
		}

		protected virtual void UnregisterAllUngrabEvents()
		{
			for (int i = 0; i < currentValidSnapInteractableObjects.Count; i++)
			{
				currentValidSnapInteractableObjects[i].InteractableObjectGrabbed -= InteractableObjectGrabbed;
				currentValidSnapInteractableObjects[i].InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
			}
		}

		protected virtual bool ValidSnapObject(VRTK_InteractableObject interactableObjectCheck, bool grabState, bool checkGrabState = true)
		{
			if (interactableObjectCheck != null && (!checkGrabState || interactableObjectCheck.IsGrabbed() == grabState))
			{
				return !VRTK_PolicyList.Check(interactableObjectCheck.gameObject, validObjectListPolicy);
			}
			return false;
		}

		protected virtual string ObjectPath(string name)
		{
			return "HighlightContainer/" + name;
		}

		protected virtual void CheckSnappedItemExists()
		{
			if (isSnapped && (currentSnappedObject == null || !currentSnappedObject.gameObject.activeInHierarchy))
			{
				ForceUnsnap();
				OnObjectUnsnappedFromDropZone(SetSnapDropZoneEvent((currentSnappedObject != null) ? currentSnappedObject.gameObject : null));
			}
		}

		protected virtual void CheckPrefabUpdate()
		{
			if (previousPrefab != null && previousPrefab != highlightObjectPrefab)
			{
				DeleteHighlightObject();
			}
		}

		protected virtual void SetObjectHighlight()
		{
			if (highlightAlwaysActive && !isSnapped && !isHighlighted)
			{
				SetHighlightObjectActive(state: true);
				ToggleHighlightColor();
			}
			if (!highlightAlwaysActive && isHighlighted && !ValidSnappableObjectIsHovering())
			{
				SetHighlightObjectActive(state: false);
			}
		}

		protected virtual void ToggleHighlightColor()
		{
			if (Application.isPlaying && highlightAlwaysActive && !isSnapped && objectHighlighter != null)
			{
				objectHighlighter.Highlight((willSnap && validHighlightColor != Color.clear) ? validHighlightColor : highlightColor);
			}
		}

		protected virtual void CreateHighlightersInEditor()
		{
			if (VRTK_SharedMethods.IsEditTime())
			{
				GenerateHighlightObject();
				if (snapType == SnapTypes.UseJoint && GetComponent<Joint>() == null)
				{
					VRTK_Logger.Warn(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "SnapDropZone:" + base.name, "Joint", "the same", " because the `Snap Type` is set to `Use Joint`"));
				}
				GenerateEditorHighlightObject();
				ForceSetObjects();
				if (highlightEditorObject != null)
				{
					highlightEditorObject.SetActive(displayDropZoneInEditor);
				}
			}
		}

		protected virtual void CheckCurrentValidSnapObjectStillValid()
		{
			for (int i = 0; i < currentValidSnapInteractableObjects.Count; i++)
			{
				VRTK_InteractableObject vRTK_InteractableObject = currentValidSnapInteractableObjects[i];
				if (vRTK_InteractableObject != null && vRTK_InteractableObject.GetStoredSnapDropZone() != null && vRTK_InteractableObject.GetStoredSnapDropZone() != this)
				{
					RemoveCurrentValidSnapObject(vRTK_InteractableObject);
					if (isHighlighted && highlightObject != null && !highlightAlwaysActive)
					{
						SetHighlightObjectActive(state: false);
					}
				}
			}
		}

		protected virtual void ForceSetObjects()
		{
			if (highlightEditorObject == null)
			{
				Transform transform = base.transform.Find(ObjectPath("EditorHighlightObject"));
				highlightEditorObject = (transform ? transform.gameObject : null);
			}
			if (highlightObject == null)
			{
				Transform transform2 = base.transform.Find(ObjectPath("HighlightObject"));
				highlightObject = (transform2 ? transform2.gameObject : null);
			}
			if (highlightContainer == null)
			{
				Transform transform3 = base.transform.Find("HighlightContainer");
				highlightContainer = (transform3 ? transform3.gameObject : null);
			}
		}

		protected virtual void GenerateContainer()
		{
			if (highlightContainer == null || base.transform.Find("HighlightContainer") == null)
			{
				highlightContainer = new GameObject("HighlightContainer");
				highlightContainer.transform.SetParent(base.transform);
				highlightContainer.transform.localPosition = Vector3.zero;
				highlightContainer.transform.localRotation = Quaternion.identity;
				highlightContainer.transform.localScale = Vector3.one;
			}
		}

		protected virtual void DisableHighlightShadows()
		{
			if (highlightObject != null)
			{
				Renderer[] componentsInChildren = highlightObject.GetComponentsInChildren<Renderer>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].receiveShadows = false;
					componentsInChildren[i].shadowCastingMode = ShadowCastingMode.Off;
				}
			}
		}

		protected virtual void SetContainer()
		{
			Transform transform = base.transform.Find("HighlightContainer");
			if (transform != null)
			{
				highlightContainer = transform.gameObject;
			}
		}

		protected virtual void GenerateObjects()
		{
			GenerateHighlightObject();
			if (highlightObject != null && objectHighlighter == null)
			{
				InitialiseHighlighter();
			}
		}

		protected virtual void SnapObject(VRTK_InteractableObject interactableObjectCheck, bool checkGrabState = true)
		{
			if (willSnap && !isSnapped && ValidSnapObject(interactableObjectCheck, grabState: false, checkGrabState) && !interactableObjectCheck.IsInSnapDropZone())
			{
				if (highlightObject != null)
				{
					SetHighlightObjectActive(state: false);
				}
				Vector3 newLocalScale = GetNewLocalScale(interactableObjectCheck);
				if (transitionInPlaceRoutine != null)
				{
					StopCoroutine(transitionInPlaceRoutine);
				}
				isSnapped = true;
				currentSnappedObject = interactableObjectCheck;
				if (cloneNewOnUnsnap)
				{
					CreatePermanentClone();
				}
				if (base.gameObject.activeInHierarchy)
				{
					if (checkGrabState)
					{
						_ = snapDuration;
					}
					transitionInPlaceRoutine = StartCoroutine(UpdateTransformDimensions(interactableObjectCheck, highlightContainer, newLocalScale, snapDuration));
				}
				interactableObjectCheck.ToggleSnapDropZone(this, state: true);
				forceSnapped = false;
			}
			isSnapped = (!isSnapped || !(interactableObjectCheck != null) || !interactableObjectCheck.IsGrabbed()) && isSnapped;
			willSnap = !isSnapped;
			wasSnapped = false;
		}

		protected virtual void CreatePermanentClone()
		{
			VRTK_BaseHighlighter component = currentSnappedObject.GetComponent<VRTK_BaseHighlighter>();
			if (component != null)
			{
				component.Unhighlight();
			}
			objectToClone = UnityEngine.Object.Instantiate(currentSnappedObject.gameObject);
			objectToClone.transform.position = highlightContainer.transform.position;
			objectToClone.transform.rotation = highlightContainer.transform.rotation;
			Collider[] componentsInChildren = currentSnappedObject.GetComponentsInChildren<Collider>();
			clonedObjectColliderStates = new bool[componentsInChildren.Length];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Collider collider = componentsInChildren[i];
				clonedObjectColliderStates[i] = collider.isTrigger;
				collider.isTrigger = true;
			}
			objectToClone.SetActive(value: false);
		}

		protected virtual void ResetPermanentCloneColliders(GameObject objectToReset)
		{
			if (!(objectToReset != null) || clonedObjectColliderStates.Length == 0)
			{
				return;
			}
			Collider[] componentsInChildren = objectToReset.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Collider collider = componentsInChildren[i];
				if (clonedObjectColliderStates.Length > i)
				{
					collider.isTrigger = clonedObjectColliderStates[i];
				}
			}
		}

		protected virtual void ResnapPermanentClone()
		{
			if (objectToClone != null)
			{
				float num = snapDuration;
				snapDuration = 0f;
				objectToClone.SetActive(value: true);
				ResetPermanentCloneColliders(objectToClone);
				ForceSnap(objectToClone);
				snapDuration = num;
			}
		}

		protected virtual void UnsnapObject()
		{
			if (currentSnappedObject != null)
			{
				ResetPermanentCloneColliders(currentSnappedObject.gameObject);
				RemoveCurrentValidSnapObject(currentSnappedObject);
			}
			isSnapped = false;
			wasSnapped = true;
			VRTK_InteractableObject interactableObjectCheck = currentSnappedObject;
			currentSnappedObject = null;
			ResetSnapDropZoneJoint();
			if (transitionInPlaceRoutine != null)
			{
				StopCoroutine(transitionInPlaceRoutine);
			}
			if (cloneNewOnUnsnap)
			{
				ResnapPermanentClone();
			}
			if (checkCanSnapRoutine != null)
			{
				StopCoroutine(checkCanSnapRoutine);
			}
			if (base.gameObject.activeInHierarchy)
			{
				checkCanSnapRoutine = StartCoroutine(CheckCanSnapObjectAtEndOfFrame(interactableObjectCheck));
			}
			interactableObjectCheck = null;
		}

		protected virtual Vector3 GetNewLocalScale(VRTK_InteractableObject checkObject)
		{
			Vector3 result = checkObject.transform.localScale;
			if (applyScalingOnSnap)
			{
				checkObject.StoreLocalScale();
				result = Vector3.Scale(checkObject.transform.localScale, base.transform.localScale);
			}
			return result;
		}

		protected virtual IEnumerator CheckCanSnapObjectAtEndOfFrame(VRTK_InteractableObject interactableObjectCheck)
		{
			yield return new WaitForEndOfFrame();
			CheckCanSnap(interactableObjectCheck);
		}

		protected virtual IEnumerator UpdateTransformDimensions(VRTK_InteractableObject ioCheck, GameObject endSettings, Vector3 endScale, float duration)
		{
			float elapsedTime = 0f;
			Transform ioTransform = ioCheck.transform;
			Vector3 startPosition = ioTransform.position;
			Quaternion startRotation = ioTransform.rotation;
			Vector3 startScale = ioTransform.localScale;
			bool storedKinematicState = ioCheck.isKinematic;
			ioCheck.isKinematic = true;
			while (elapsedTime <= duration)
			{
				elapsedTime += Time.deltaTime;
				if (ioTransform != null && endSettings != null)
				{
					ioTransform.position = Vector3.Lerp(startPosition, endSettings.transform.position, elapsedTime / duration);
					ioTransform.rotation = Quaternion.Lerp(startRotation, endSettings.transform.rotation, elapsedTime / duration);
					ioTransform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
				}
				yield return null;
			}
			if (ioTransform != null && endSettings != null)
			{
				ioTransform.position = endSettings.transform.position;
				ioTransform.rotation = endSettings.transform.rotation;
				ioTransform.localScale = endScale;
			}
			ioCheck.isKinematic = storedKinematicState;
			SetDropSnapType(ioCheck);
		}

		protected virtual void SetDropSnapType(VRTK_InteractableObject ioCheck)
		{
			switch (snapType)
			{
			case SnapTypes.UseKinematic:
				ioCheck.SaveCurrentState();
				ioCheck.isKinematic = true;
				break;
			case SnapTypes.UseParenting:
				ioCheck.SaveCurrentState();
				ioCheck.isKinematic = true;
				ioCheck.transform.SetParent(base.transform);
				break;
			case SnapTypes.UseJoint:
				SetSnapDropZoneJoint(ioCheck.GetComponent<Rigidbody>());
				break;
			}
			OnObjectSnappedToDropZone(SetSnapDropZoneEvent(ioCheck.gameObject));
		}

		protected virtual void SetSnapDropZoneJoint(Rigidbody snapTo)
		{
			Joint component = GetComponent<Joint>();
			if (component == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "SnapDropZone:" + base.name, "Joint", "the same", " because the `Snap Type` is set to `Use Joint`"));
			}
			else if (snapTo == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_SnapDropZone", "Rigidbody", "the `VRTK_InteractableObject`"));
			}
			else
			{
				component.connectedBody = snapTo;
				originalJointCollisionState = component.enableCollision;
				component.enableCollision = true;
			}
		}

		protected virtual void ResetSnapDropZoneJoint()
		{
			Joint component = GetComponent<Joint>();
			if (component != null)
			{
				component.enableCollision = originalJointCollisionState;
			}
		}

		protected virtual void AddCurrentValidSnapObject(VRTK_InteractableObject givenObject)
		{
			if (givenObject != null && VRTK_SharedMethods.AddListValue(currentValidSnapInteractableObjects, givenObject, preventDuplicates: true))
			{
				givenObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
				givenObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
			}
		}

		protected virtual void RemoveCurrentValidSnapObject(VRTK_InteractableObject givenObject)
		{
			if (givenObject != null && currentValidSnapInteractableObjects.Remove(givenObject))
			{
				givenObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
				givenObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
			}
		}

		protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			VRTK_InteractableObject vRTK_InteractableObject = sender as VRTK_InteractableObject;
			if (!vRTK_InteractableObject.IsInSnapDropZone())
			{
				CheckCanSnap(vRTK_InteractableObject);
			}
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			VRTK_InteractableObject objectToSnap = sender as VRTK_InteractableObject;
			if (attemptTransitionAtEndOfFrameRoutine != null)
			{
				StopCoroutine(attemptTransitionAtEndOfFrameRoutine);
				attemptingDelayedSnap = false;
			}
			attemptTransitionAtEndOfFrameRoutine = StartCoroutine(AttemptForceSnapAtEndOfFrame(objectToSnap));
		}

		protected virtual void AttemptForceSnap(VRTK_InteractableObject objectToSnap)
		{
			willSnap = true;
			SnapObjectToZone(objectToSnap);
		}

		protected virtual IEnumerator AttemptForceSnapAtEndOfFrame(VRTK_InteractableObject objectToSnap)
		{
			attemptingDelayedSnap = true;
			yield return new WaitForEndOfFrame();
			objectToSnap.SaveCurrentState();
			AttemptForceSnap(objectToSnap);
			attemptingDelayedSnap = false;
			attemptTransitionAtEndOfFrameRoutine = null;
		}

		protected virtual void ToggleHighlight(VRTK_InteractableObject checkObject, bool state)
		{
			if (highlightObject != null && ValidSnapObject(checkObject, grabState: true, state))
			{
				SetHighlightObjectActive(state);
			}
		}

		protected virtual void CopyObject(GameObject objectBlueprint, ref GameObject clonedObject, string givenName)
		{
			GenerateContainer();
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = Vector3.one;
			clonedObject = UnityEngine.Object.Instantiate(objectBlueprint, highlightContainer.transform);
			clonedObject.name = givenName;
			clonedObject.transform.localPosition = Vector3.zero;
			clonedObject.transform.localRotation = Quaternion.identity;
			base.transform.localScale = localScale;
			CleanHighlightObject(clonedObject);
		}

		protected virtual void GenerateHighlightObject()
		{
			if (highlightObjectPrefab != null && highlightObject == null && base.transform.Find(ObjectPath("HighlightObject")) == null)
			{
				CopyObject(highlightObjectPrefab, ref highlightObject, "HighlightObject");
			}
			Transform transform = base.transform.Find(ObjectPath("HighlightObject"));
			if (transform != null && highlightObject == null)
			{
				highlightObject = transform.gameObject;
			}
			if (highlightObjectPrefab == null && highlightObject != null)
			{
				DeleteHighlightObject();
			}
			DisableHighlightShadows();
			SetHighlightObjectActive(state: false);
			SetContainer();
		}

		protected virtual void SetHighlightObjectActive(bool state)
		{
			if (highlightObject != null)
			{
				highlightObject.SetActive(state);
				isHighlighted = state;
			}
		}

		protected virtual void DeleteHighlightObject()
		{
			ChooseDestroyType(base.transform.Find("HighlightContainer"));
			highlightContainer = null;
			highlightObject = null;
			objectHighlighter = null;
		}

		protected virtual void GenerateEditorHighlightObject()
		{
			if (highlightObject != null && highlightEditorObject == null && base.transform.Find(ObjectPath("EditorHighlightObject")) == null)
			{
				CopyObject(highlightObject, ref highlightEditorObject, "EditorHighlightObject");
				Renderer[] componentsInChildren = highlightEditorObject.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].material = Resources.Load("SnapDropZoneEditorObject") as Material;
				}
				highlightEditorObject.SetActive(value: true);
			}
		}

		protected virtual void CleanHighlightObject(GameObject objectToClean)
		{
			VRTK_SnapDropZone[] componentsInChildren = objectToClean.GetComponentsInChildren<VRTK_SnapDropZone>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ChooseDestroyType(componentsInChildren[i].gameObject);
			}
			string[] array = new string[5] { "Transform", "MeshFilter", "MeshRenderer", "SkinnedMeshRenderer", "VRTK_GameObjectLinker" };
			Joint[] componentsInChildren2 = objectToClean.GetComponentsInChildren<Joint>(includeInactive: true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				ChooseDestroyType(componentsInChildren2[j]);
			}
			Component[] componentsInChildren3 = objectToClean.GetComponentsInChildren<Component>(includeInactive: true);
			foreach (Component component in componentsInChildren3)
			{
				bool flag = false;
				for (int l = 0; l < array.Length; l++)
				{
					if (component.GetType().ToString().Contains("." + array[l]))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					ChooseDestroyType(component);
				}
			}
		}

		protected virtual void InitialiseHighlighter()
		{
			VRTK_BaseHighlighter activeHighlighter = VRTK_BaseHighlighter.GetActiveHighlighter(base.gameObject);
			if (activeHighlighter == null)
			{
				highlightObject.AddComponent<VRTK_MaterialColorSwapHighlighter>();
			}
			else
			{
				VRTK_SharedMethods.CloneComponent(activeHighlighter, highlightObject);
			}
			objectHighlighter = highlightObject.GetComponent<VRTK_BaseHighlighter>();
			objectHighlighter.unhighlightOnDisable = false;
			objectHighlighter.Initialise(highlightColor);
			objectHighlighter.Highlight(highlightColor);
			if (!objectHighlighter.UsesClonedObject())
			{
				return;
			}
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!VRTK_PlayerObject.IsPlayerObject(componentsInChildren[i].gameObject, VRTK_PlayerObject.ObjectTypes.Highlighter))
				{
					componentsInChildren[i].enabled = false;
				}
			}
		}

		protected virtual void ChooseDestroyType(Transform deleteTransform)
		{
			if (deleteTransform != null)
			{
				ChooseDestroyType(deleteTransform.gameObject);
			}
		}

		protected virtual void ChooseDestroyType(GameObject deleteObject)
		{
			if (VRTK_SharedMethods.IsEditTime())
			{
				if (deleteObject != null)
				{
					UnityEngine.Object.DestroyImmediate(deleteObject);
				}
			}
			else if (deleteObject != null)
			{
				UnityEngine.Object.Destroy(deleteObject);
			}
		}

		protected virtual void ChooseDestroyType(Component deleteComponent)
		{
			if (VRTK_SharedMethods.IsEditTime())
			{
				if (deleteComponent != null)
				{
					UnityEngine.Object.DestroyImmediate(deleteComponent);
				}
			}
			else if (deleteComponent != null)
			{
				UnityEngine.Object.Destroy(deleteComponent);
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
			if (highlightObject != null && !displayDropZoneInEditor)
			{
				Vector3 size = VRTK_SharedMethods.GetBounds(highlightObject.transform).size * 1.05f;
				Gizmos.color = Color.red;
				Gizmos.DrawWireCube(highlightObject.transform.position, size);
			}
		}

		protected virtual IEnumerator OverridePreviousStateAtEndOfFrame(VRTK_InteractableObject io, Transform parent, bool kinematic, bool grabbable)
		{
			yield return new WaitForEndOfFrame();
			io.OverridePreviousState(parent, kinematic, grabbable);
		}
	}
}
