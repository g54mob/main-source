using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	public class VRTK_IndependentRadialMenuController : VRTK_RadialMenuController
	{
		[Tooltip("If the RadialMenu is the child of an object with VRTK_InteractableObject attached, this will be automatically obtained. It can also be manually set.")]
		public VRTK_InteractableObject eventsManager;

		[Tooltip("Whether or not the script should dynamically add a SphereCollider to surround the menu.")]
		public bool addMenuCollider = true;

		[Tooltip("This times the size of the RadialMenu is the size of the collider.")]
		[Range(0f, 10f)]
		public float colliderRadiusMultiplier = 1.2f;

		[Tooltip("If true, after a button is clicked, the RadialMenu will hide.")]
		public bool hideAfterExecution = true;

		[Tooltip("How far away from the object the menu should be placed, relative to the size of the RadialMenu.")]
		[Range(-10f, 10f)]
		public float offsetMultiplier = 1.1f;

		[Tooltip("The object the RadialMenu should face towards. If left empty, it will automatically try to find the Headset Camera.")]
		public GameObject rotateTowards;

		protected List<GameObject> interactingObjects = new List<GameObject>();

		protected HashSet<GameObject> collidingObjects = new HashSet<GameObject>();

		protected SphereCollider menuCollider;

		protected Coroutine delayedSetColliderEnabledRoutine;

		protected Vector3 desiredColliderCenter;

		protected Quaternion initialRotation;

		protected bool isClicked;

		protected bool waitingToDisableCollider;

		protected int counter = 2;

		public virtual void UpdateEventsManager()
		{
			VRTK_InteractableObject componentInParent = base.transform.GetComponentInParent<VRTK_InteractableObject>();
			if (componentInParent == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_IndependentRadialMenuController", "VRTK_InteractableObject", "eventsManager", "the parent"));
			}
			else if (componentInParent != eventsManager)
			{
				if (eventsManager != null)
				{
					OnDisable();
				}
				eventsManager = componentInParent;
				OnEnable();
				Object.Destroy(menuCollider);
				Initialize();
			}
		}

		protected override void Initialize()
		{
			if (eventsManager == null)
			{
				initialRotation = base.transform.localRotation;
				UpdateEventsManager();
				return;
			}
			interactingObjects.Clear();
			collidingObjects.Clear();
			if (delayedSetColliderEnabledRoutine != null)
			{
				StopCoroutine(delayedSetColliderEnabledRoutine);
			}
			isClicked = false;
			waitingToDisableCollider = false;
			counter = 2;
			if (base.transform.childCount != 0)
			{
				float z = base.transform.GetChild(0).GetComponent<RectTransform>().rect.width / 2f * offsetMultiplier;
				base.transform.localPosition = new Vector3(0f, 0f, z);
				if (addMenuCollider)
				{
					base.gameObject.SetActive(value: false);
					base.transform.localScale = Vector3.one;
					Quaternion rotation = base.transform.rotation;
					base.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
					SphereCollider sphereCollider = eventsManager.gameObject.AddComponent<SphereCollider>();
					sphereCollider.radius = base.transform.GetChild(0).GetComponent<RectTransform>().rect.width / 2f * colliderRadiusMultiplier * eventsManager.transform.InverseTransformVector(base.transform.GetChild(0).TransformVector(Vector3.one)).x;
					sphereCollider.center = eventsManager.transform.InverseTransformVector(base.transform.position - eventsManager.transform.position);
					sphereCollider.isTrigger = true;
					sphereCollider.enabled = false;
					menuCollider = sphereCollider;
					desiredColliderCenter = sphereCollider.center;
					base.transform.rotation = rotation;
				}
				if (!menu.isShown)
				{
					base.transform.localScale = Vector3.zero;
				}
				base.gameObject.SetActive(value: true);
			}
		}

		protected override void Awake()
		{
			menu = GetComponent<VRTK_RadialMenu>();
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Start()
		{
			Initialize();
		}

		protected override void OnEnable()
		{
			if (eventsManager != null)
			{
				eventsManager.InteractableObjectUsed += ObjectClicked;
				eventsManager.InteractableObjectUnused += ObjectUnClicked;
				eventsManager.InteractableObjectTouched += ObjectTouched;
				eventsManager.InteractableObjectUntouched += ObjectUntouched;
				menu.FireHapticPulse += AttemptHapticPulse;
			}
			else
			{
				Initialize();
			}
		}

		protected override void OnDisable()
		{
			if (eventsManager != null)
			{
				eventsManager.InteractableObjectUsed -= ObjectClicked;
				eventsManager.InteractableObjectUnused -= ObjectUnClicked;
				eventsManager.InteractableObjectTouched -= ObjectTouched;
				eventsManager.InteractableObjectUntouched -= ObjectUntouched;
				menu.FireHapticPulse -= AttemptHapticPulse;
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			if (rotateTowards == null)
			{
				Transform transform = VRTK_DeviceFinder.HeadsetTransform();
				if ((bool)transform)
				{
					rotateTowards = transform.gameObject;
				}
				else
				{
					VRTK_Logger.Warn(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.COULD_NOT_FIND_OBJECT_FOR_ACTION, "IndependentRadialMenu", "an object", "rotate towards"));
				}
			}
			if (menu.isShown)
			{
				if (interactingObjects.Count > 0)
				{
					DoChangeAngle(CalculateAngle(interactingObjects[0]), this);
				}
				if (rotateTowards != null)
				{
					base.transform.rotation = Quaternion.LookRotation((rotateTowards.transform.position - base.transform.position) * -1f, Vector3.up) * initialRotation;
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (waitingToDisableCollider)
			{
				if (counter == 0)
				{
					menuCollider.enabled = false;
					waitingToDisableCollider = false;
					counter = 2;
				}
				else
				{
					counter--;
				}
			}
		}

		protected override void AttemptHapticPulse(float strength)
		{
			if (interactingObjects.Count > 0)
			{
				VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(interactingObjects[0]), strength);
			}
		}

		protected virtual void ObjectClicked(object sender, InteractableObjectEventArgs e)
		{
			DoClickButton(sender);
			isClicked = true;
			if (hideAfterExecution && !menu.executeOnUnclick)
			{
				ImmediatelyHideMenu(e);
			}
		}

		protected virtual void ObjectUnClicked(object sender, InteractableObjectEventArgs e)
		{
			DoUnClickButton(sender);
			isClicked = false;
			if ((hideAfterExecution || (collidingObjects.Count == 0 && menu.hideOnRelease)) && menu.executeOnUnclick)
			{
				ImmediatelyHideMenu(e);
			}
		}

		protected virtual void ObjectTouched(object sender, InteractableObjectEventArgs e)
		{
			DoShowMenu(CalculateAngle(e.interactingObject), sender);
			collidingObjects.Add(e.interactingObject);
			VRTK_SharedMethods.AddListValue(interactingObjects, e.interactingObject, preventDuplicates: true);
			if (addMenuCollider && menuCollider != null)
			{
				SetColliderState(state: true, e);
				if (delayedSetColliderEnabledRoutine != null)
				{
					StopCoroutine(delayedSetColliderEnabledRoutine);
				}
			}
		}

		protected virtual void ObjectUntouched(object sender, InteractableObjectEventArgs e)
		{
			collidingObjects.Remove(e.interactingObject);
			if (((!menu.executeOnUnclick || !isClicked) && menu.hideOnRelease) || (Object)sender == this)
			{
				DoHideMenu(hideAfterExecution, sender);
				interactingObjects.Remove(e.interactingObject);
				if (addMenuCollider && menuCollider != null)
				{
					delayedSetColliderEnabledRoutine = StartCoroutine(DelayedSetColliderEnabled(enabled: false, 0.25f, e));
				}
			}
		}

		protected virtual TouchAngleDeflection CalculateAngle(GameObject interactingObject)
		{
			Vector3 vector = interactingObject.transform.position - base.transform.position;
			Vector3 vector2 = base.transform.position + Vector3.ProjectOnPlane(vector, base.transform.forward);
			float num = 0f;
			num = AngleSigned(base.transform.right * -1f, vector2 - base.transform.position, base.transform.forward);
			if (num < 0f)
			{
				num += 360f;
			}
			return new TouchAngleDeflection(num, 1f);
		}

		protected virtual float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
		{
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
		}

		protected virtual void ImmediatelyHideMenu(InteractableObjectEventArgs e)
		{
			ObjectUntouched(this, e);
			if (delayedSetColliderEnabledRoutine != null)
			{
				StopCoroutine(delayedSetColliderEnabledRoutine);
			}
			SetColliderState(state: false, e);
		}

		protected virtual void SetColliderState(bool state, InteractableObjectEventArgs e)
		{
			if (!addMenuCollider || !(menuCollider != null))
			{
				return;
			}
			if (state)
			{
				menuCollider.enabled = true;
				menuCollider.center = desiredColliderCenter;
				return;
			}
			bool flag = true;
			Collider[] components = eventsManager.GetComponents<Collider>();
			Collider[] array = e.interactingObject.GetComponent<VRTK_InteractTouch>().ControllerColliders();
			foreach (Collider collider in components)
			{
				if (!(collider != menuCollider))
				{
					continue;
				}
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].bounds.Intersects(collider.bounds))
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				menuCollider.center = new Vector3(100000000f, 100000000f, 100000000f);
				waitingToDisableCollider = true;
			}
			else
			{
				menuCollider.enabled = false;
			}
		}

		protected virtual IEnumerator DelayedSetColliderEnabled(bool enabled, float delay, InteractableObjectEventArgs e)
		{
			yield return new WaitForSeconds(delay);
			SetColliderState(enabled, e);
		}
	}
}
