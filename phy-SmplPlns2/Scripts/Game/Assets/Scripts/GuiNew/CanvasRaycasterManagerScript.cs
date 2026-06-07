using Assets.Scripts.XR.UI.InputModules;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class CanvasRaycasterManagerScript : MonoBehaviour
	{
		protected virtual void OnTransformChildrenChanged()
		{
			UpdateCustomTrackedDeviceRaycaster();
		}

		protected virtual void Start()
		{
			UpdateCustomTrackedDeviceRaycaster();
		}

		private void UpdateCustomTrackedDeviceRaycaster()
		{
			Canvas componentInParent = GetComponentInParent<Canvas>();
			bool flag = componentInParent.renderMode == RenderMode.WorldSpace;
			bool flag2 = false;
			Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].raycastTarget)
				{
					flag2 = true;
					break;
				}
			}
			UpdateRaycaster<CustomTrackedDeviceRaycaster>(componentInParent, flag2 && flag && Game.Instance.XRDeviceManager.HmdActive);
			UpdateRaycaster<GraphicRaycaster>(componentInParent, flag2 && !flag);
		}

		private void UpdateRaycaster<T>(Canvas canvas, bool needsCaster) where T : BaseRaycaster
		{
			bool flag = false;
			T component = canvas.GetComponent<T>();
			if (needsCaster)
			{
				if (component == null)
				{
					canvas.gameObject.AddComponent<T>();
				}
				else if (flag)
				{
					Object.Destroy(component);
				}
				else
				{
					component.enabled = true;
				}
			}
			else if (component != null)
			{
				if (flag)
				{
					Object.Destroy(component);
				}
				else
				{
					component.enabled = false;
				}
			}
		}
	}
}
