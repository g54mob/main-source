using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRTK
{
	public class VRTK_IgnoreInteractTouchColliders : VRTK_SDKControllerReady
	{
		[Tooltip("The Interact Touch scripts to ignore collisions with.")]
		public List<VRTK_InteractTouch> interactTouchToIgnore = new List<VRTK_InteractTouch>();

		[Tooltip("A collection of GameObjects to not include when ignoring collisions with the provided Interact Touch colliders.")]
		public List<GameObject> skipIgnore = new List<GameObject>();

		protected Collider[] localColliders = new Collider[0];

		protected Coroutine disableAllCollidersRoutine;

		protected Coroutine disableControllerCollidersRoutine;

		protected override void OnEnable()
		{
			base.OnEnable();
			localColliders = GetComponentsInChildren<Collider>(includeInactive: true);
			disableAllCollidersRoutine = StartCoroutine(DisableAllCollidersAtEndOfFrame());
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (disableAllCollidersRoutine != null)
			{
				StopCoroutine(disableAllCollidersRoutine);
			}
			if (disableControllerCollidersRoutine != null)
			{
				StopCoroutine(disableControllerCollidersRoutine);
			}
			ManageAllCollisions(ignore: false);
			localColliders = new Collider[0];
		}

		protected virtual IEnumerator DisableAllCollidersAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			ManageAllCollisions(ignore: true);
		}

		protected virtual IEnumerator DisableControllerColliderAtEndOfFrame(VRTK_InteractTouch touchToIgnore)
		{
			yield return new WaitForEndOfFrame();
			ManageTouchCollision(touchToIgnore, ignore: true);
		}

		protected override void ControllerReady(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				VRTK_InteractTouch componentInChildren = controllerReference.scriptAlias.GetComponentInChildren<VRTK_InteractTouch>();
				if (interactTouchToIgnore.Contains(componentInChildren))
				{
					disableControllerCollidersRoutine = StartCoroutine(DisableControllerColliderAtEndOfFrame(componentInChildren));
				}
			}
		}

		protected virtual void ManageAllCollisions(bool ignore)
		{
			for (int i = 0; i < interactTouchToIgnore.Count; i++)
			{
				ManageTouchCollision(interactTouchToIgnore[i], ignore);
			}
		}

		protected virtual bool ShouldExclude(Transform checkObject)
		{
			if (skipIgnore.Contains(checkObject.gameObject))
			{
				return true;
			}
			if (checkObject.parent != null)
			{
				return ShouldExclude(checkObject.parent);
			}
			return false;
		}

		protected virtual void ManageTouchCollision(VRTK_InteractTouch touchToIgnore, bool ignore)
		{
			if (!(touchToIgnore != null))
			{
				return;
			}
			Collider[] array = touchToIgnore.ControllerColliders();
			VRTK_ControllerTrackedCollider dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(VRTK_ObjectCache.registeredTrackedColliderToInteractTouches, touchToIgnore);
			if (dictionaryValue != null)
			{
				Collider[] second = dictionaryValue.TrackedColliders();
				array = array.Concat(second).ToArray();
			}
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < localColliders.Length; j++)
				{
					if (localColliders[j] != null && array[i] != null && !ShouldExclude(localColliders[j].transform))
					{
						Physics.IgnoreCollision(localColliders[j], array[i], ignore);
					}
				}
			}
		}
	}
}
