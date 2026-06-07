using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_ControllerTrackedCollider")]
	public class VRTK_ControllerTrackedCollider : VRTK_SDKControllerReady
	{
		[Header("Tracked Controller Settings")]
		[Tooltip("The Interact Touch script to relate the tracked collider to.")]
		public VRTK_InteractTouch interactTouch;

		[Tooltip("The maximum distance the collider object can be from the controller before it automatically snaps back to the same position.")]
		public float maxResnapDistance = 0.5f;

		[Tooltip("The button to press to activate the colliders on the tracked collider set. If `Undefined` then it will always be active.")]
		public VRTK_ControllerEvents.ButtonAlias activationButton;

		[Header("Custom Settings")]
		[Tooltip("An optional Controller Events to use for listening to the button events. If this is left blank then it will attempt to be retrieved from the same controller as the `Interact Touch` parameter.")]
		public VRTK_ControllerEvents controllerEvents;

		protected VRTK_TrackedController trackedController;

		protected VRTK_ControllerReference controllerReference;

		protected Rigidbody trackedRigidbody;

		protected bool createRigidbody;

		protected Collider[] trackedColliders = new Collider[0];

		protected GameObject customColliderContainer;

		protected bool createColliders;

		protected VRTK_RigidbodyFollow rigidbodyFollow;

		protected bool createRigidbodyFollow;

		protected VRTK_ControllerEvents.ButtonAlias subscribedActivationButton;

		public virtual void ToggleColliders(bool state)
		{
			if (state || activationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				for (int i = 0; i < trackedColliders.Length; i++)
				{
					trackedColliders[i].isTrigger = !state;
				}
			}
		}

		public virtual Collider[] TrackedColliders()
		{
			return trackedColliders;
		}

		protected override void OnEnable()
		{
			if (interactTouch == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_PARAMETER, "VRTK_ControllerTrackedCollider", "VRTK_InteractTouch", "Interact Touch"));
			}
			else
			{
				VRTK_SharedMethods.AddDictionaryValue(VRTK_ObjectCache.registeredTrackedColliderToInteractTouches, interactTouch, this);
			}
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			ManageActivationListeners(state: false);
			Cleanup(immediate: false);
			VRTK_ObjectCache.registeredTrackedColliderToInteractTouches.Remove(interactTouch);
		}

		protected override void ControllerReady(VRTK_ControllerReference passedControllerReference)
		{
			if (VRTK_SDKManager.GetLoadedSDKSetup() != null && base.gameObject.activeInHierarchy && VRTK_ControllerReference.IsValid(passedControllerReference))
			{
				Cleanup(immediate: true);
				controllerReference = passedControllerReference;
				controllerEvents = ((controllerEvents == null) ? controllerReference.scriptAlias.GetComponentInChildren<VRTK_ControllerEvents>() : controllerEvents);
				ManageActivationListeners(state: true);
				SetupRigidbody();
				SetupColliders();
				SetupFollower();
				ToggleColliders(activationButton == VRTK_ControllerEvents.ButtonAlias.Undefined);
			}
		}

		protected virtual void Cleanup(bool immediate)
		{
			if (createRigidbody)
			{
				DestroyObject(trackedRigidbody, immediate);
			}
			trackedColliders = new Collider[0];
			if (createColliders)
			{
				DestroyObject(customColliderContainer, immediate);
			}
			if (createRigidbodyFollow)
			{
				DestroyObject(rigidbodyFollow, immediate);
			}
		}

		protected virtual void DestroyObject(Object toDestroy, bool immediate)
		{
			if (immediate)
			{
				Object.DestroyImmediate(toDestroy);
			}
			else
			{
				Object.Destroy(toDestroy);
			}
		}

		protected virtual void ManageActivationListeners(bool state)
		{
			if (controllerEvents != null)
			{
				if (subscribedActivationButton != VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || activationButton != subscribedActivationButton))
				{
					controllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: true, DoActivationPress);
					controllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: false, DoActivationRelease);
					subscribedActivationButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
				}
				if (state && activationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: true, DoActivationPress);
					controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: false, DoActivationRelease);
					subscribedActivationButton = activationButton;
				}
			}
		}

		protected virtual void DoActivationPress(object sender, ControllerInteractionEventArgs e)
		{
			ToggleColliders(state: true);
		}

		protected virtual void DoActivationRelease(object sender, ControllerInteractionEventArgs e)
		{
			ToggleColliders(state: false);
		}

		protected virtual void SetupRigidbody()
		{
			createRigidbody = false;
			trackedRigidbody = GetComponent<Rigidbody>();
			if (trackedRigidbody == null)
			{
				createRigidbody = true;
				trackedRigidbody = base.gameObject.AddComponent<Rigidbody>();
				trackedRigidbody.useGravity = false;
				trackedRigidbody.drag = 0f;
				trackedRigidbody.angularDrag = 0f;
			}
		}

		protected virtual void SetupColliders()
		{
			createColliders = false;
			Collider[] collidersInGameObjects = VRTK_SharedMethods.GetCollidersInGameObjects(new GameObject[1] { base.gameObject }, searchChildren: true, includeInactive: true);
			if (collidersInGameObjects.Length == 0)
			{
				Object obj = Resources.Load(VRTK_SDK_Bridge.GetControllerDefaultColliderPath(controllerReference.hand));
				if (obj == null)
				{
					VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.SDK_OBJECT_NOT_FOUND, "default collider prefab", "Controller SDK"));
					return;
				}
				createColliders = true;
				customColliderContainer = Object.Instantiate(obj) as GameObject;
				customColliderContainer.transform.SetParent(base.transform);
				customColliderContainer.transform.localPosition = Vector3.zero;
				customColliderContainer.transform.localRotation = Quaternion.identity;
				customColliderContainer.transform.localScale = Vector3.one;
				customColliderContainer.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "Controller", "TrackedCollidersContainer");
				collidersInGameObjects = VRTK_SharedMethods.GetCollidersInGameObjects(new GameObject[1] { base.gameObject }, searchChildren: true, includeInactive: true);
			}
			trackedColliders = collidersInGameObjects;
			Collider[] array = interactTouch.ControllerColliders();
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < trackedColliders.Length; j++)
				{
					Physics.IgnoreCollision(array[i], trackedColliders[j], ignore: true);
				}
			}
		}

		protected virtual void SetupFollower()
		{
			createRigidbodyFollow = false;
			rigidbodyFollow = GetComponent<VRTK_RigidbodyFollow>();
			if (rigidbodyFollow == null)
			{
				createRigidbodyFollow = true;
				rigidbodyFollow = base.gameObject.AddComponent<VRTK_RigidbodyFollow>();
			}
			rigidbodyFollow.gameObjectToFollow = interactTouch.gameObject;
			rigidbodyFollow.trackMaxDistance = maxResnapDistance;
			rigidbodyFollow.movementOption = VRTK_RigidbodyFollow.MovementOption.Track;
		}
	}
}
