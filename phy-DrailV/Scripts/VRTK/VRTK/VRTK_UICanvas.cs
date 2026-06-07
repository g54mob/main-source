using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/UI/VRTK_UICanvas")]
	public class VRTK_UICanvas : MonoBehaviour
	{
		[Tooltip("Determines if a UI Click action should happen when a UI Pointer game object collides with this canvas.")]
		public bool clickOnPointerCollision;

		[Tooltip("Determines if a UI Pointer will be auto activated if a UI Pointer game object comes within the given distance of this canvas. If a value of `0` is given then no auto activation will occur.")]
		public float autoActivateWithinDistance;

		protected BoxCollider canvasBoxCollider;

		protected Rigidbody canvasRigidBody;

		protected Coroutine draggablePanelCreation;

		protected const string CANVAS_DRAGGABLE_PANEL = "VRTK_UICANVAS_DRAGGABLE_PANEL";

		protected const string ACTIVATOR_FRONT_TRIGGER_GAMEOBJECT = "VRTK_UICANVAS_ACTIVATOR_FRONT_TRIGGER";

		protected virtual void OnEnable()
		{
			SetupCanvas();
		}

		protected virtual void OnDisable()
		{
			RemoveCanvas();
		}

		protected virtual void OnDestroy()
		{
			RemoveCanvas();
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			VRTK_PlayerObject componentInParent = collider.GetComponentInParent<VRTK_PlayerObject>();
			VRTK_UIPointer componentInParent2 = collider.GetComponentInParent<VRTK_UIPointer>();
			if (componentInParent2 != null && componentInParent != null && componentInParent.objectType == VRTK_PlayerObject.ObjectTypes.Collider)
			{
				componentInParent2.collisionClick = clickOnPointerCollision;
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			VRTK_UIPointer componentInParent = collider.GetComponentInParent<VRTK_UIPointer>();
			if (componentInParent != null)
			{
				componentInParent.collisionClick = false;
			}
		}

		protected virtual void SetupCanvas()
		{
			Canvas component = GetComponent<Canvas>();
			if (component == null || component.renderMode != RenderMode.WorldSpace)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_UICanvas", "Canvas", "the same", " that is set to `Render Mode = World Space`"));
				return;
			}
			RectTransform component2 = component.GetComponent<RectTransform>();
			Vector2 sizeDelta = component2.sizeDelta;
			GraphicRaycaster component3 = component.gameObject.GetComponent<GraphicRaycaster>();
			VRTK_UIGraphicRaycaster vRTK_UIGraphicRaycaster = component.gameObject.GetComponent<VRTK_UIGraphicRaycaster>();
			if (vRTK_UIGraphicRaycaster == null)
			{
				vRTK_UIGraphicRaycaster = component.gameObject.AddComponent<VRTK_UIGraphicRaycaster>();
			}
			if (component3 != null && component3.enabled)
			{
				vRTK_UIGraphicRaycaster.ignoreReversedGraphics = component3.ignoreReversedGraphics;
				vRTK_UIGraphicRaycaster.blockingObjects = component3.blockingObjects;
				vRTK_UIGraphicRaycaster.GetType().GetField("m_BlockingMask", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(vRTK_UIGraphicRaycaster, component3.GetType().GetField("m_BlockingMask", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(component3));
				component3.enabled = false;
			}
			if (component.gameObject.GetComponent<BoxCollider>() == null)
			{
				Vector2 pivot = component2.pivot;
				float num = 0.1f / component2.localScale.z;
				canvasBoxCollider = component.gameObject.AddComponent<BoxCollider>();
				canvasBoxCollider.size = new Vector3(sizeDelta.x, sizeDelta.y, num);
				canvasBoxCollider.center = new Vector3(sizeDelta.x / 2f - sizeDelta.x * pivot.x, sizeDelta.y / 2f - sizeDelta.y * pivot.y, num / 2f);
				canvasBoxCollider.isTrigger = true;
			}
			if (component.gameObject.GetComponent<Rigidbody>() == null)
			{
				canvasRigidBody = component.gameObject.AddComponent<Rigidbody>();
				canvasRigidBody.isKinematic = true;
			}
			draggablePanelCreation = StartCoroutine(CreateDraggablePanel(component, sizeDelta));
			CreateActivator(component, sizeDelta);
		}

		protected virtual IEnumerator CreateDraggablePanel(Canvas canvas, Vector2 canvasSize)
		{
			if (canvas != null && !canvas.transform.Find("VRTK_UICANVAS_DRAGGABLE_PANEL"))
			{
				yield return null;
				GameObject obj = new GameObject("VRTK_UICANVAS_DRAGGABLE_PANEL", typeof(RectTransform));
				obj.AddComponent<LayoutElement>().ignoreLayout = true;
				obj.AddComponent<Image>().color = Color.clear;
				obj.AddComponent<EventTrigger>();
				obj.transform.SetParent(canvas.transform);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				obj.transform.localScale = Vector3.one;
				obj.transform.SetAsFirstSibling();
				obj.GetComponent<RectTransform>().sizeDelta = canvasSize;
			}
		}

		protected virtual void CreateActivator(Canvas canvas, Vector2 canvasSize)
		{
			if (autoActivateWithinDistance > 0f && canvas != null && !canvas.transform.Find("VRTK_UICANVAS_ACTIVATOR_FRONT_TRIGGER"))
			{
				RectTransform component = canvas.GetComponent<RectTransform>();
				Vector2 pivot = component.pivot;
				GameObject obj = new GameObject("VRTK_UICANVAS_ACTIVATOR_FRONT_TRIGGER");
				obj.transform.SetParent(canvas.transform);
				obj.transform.SetAsFirstSibling();
				obj.transform.localPosition = new Vector3(canvasSize.x / 2f - canvasSize.x * pivot.x, canvasSize.y / 2f - canvasSize.y * pivot.y);
				obj.transform.localRotation = Quaternion.identity;
				obj.transform.localScale = Vector3.one;
				float num = autoActivateWithinDistance / component.localScale.z;
				BoxCollider boxCollider = obj.AddComponent<BoxCollider>();
				boxCollider.isTrigger = true;
				boxCollider.size = new Vector3(canvasSize.x, canvasSize.y, num);
				boxCollider.center = new Vector3(0f, 0f, 0f - num / 2f);
				obj.AddComponent<Rigidbody>().isKinematic = true;
				obj.AddComponent<VRTK_UIPointerAutoActivator>();
				obj.layer = LayerMask.NameToLayer("Ignore Raycast");
			}
		}

		protected virtual void RemoveCanvas()
		{
			Canvas component = GetComponent<Canvas>();
			if (!(component == null))
			{
				GraphicRaycaster component2 = component.gameObject.GetComponent<GraphicRaycaster>();
				VRTK_UIGraphicRaycaster component3 = component.gameObject.GetComponent<VRTK_UIGraphicRaycaster>();
				if (component3 != null)
				{
					Object.Destroy(component3);
				}
				if (component2 != null && !component2.enabled)
				{
					component2.enabled = true;
				}
				if (canvasBoxCollider != null)
				{
					Object.Destroy(canvasBoxCollider);
				}
				if (canvasRigidBody != null)
				{
					Object.Destroy(canvasRigidBody);
				}
				if (draggablePanelCreation != null)
				{
					StopCoroutine(draggablePanelCreation);
				}
				Transform transform = component.transform.Find("VRTK_UICANVAS_DRAGGABLE_PANEL");
				if (transform != null)
				{
					Object.Destroy(transform.gameObject);
				}
				Transform transform2 = component.transform.Find("VRTK_UICANVAS_ACTIVATOR_FRONT_TRIGGER");
				if (transform2 != null)
				{
					Object.Destroy(transform2.gameObject);
				}
			}
		}
	}
}
