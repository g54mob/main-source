using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_UICanvasDV : VRTK_UICanvas
	{
		protected override void SetupCanvas()
		{
			Canvas component = GetComponent<Canvas>();
			if (component == null || component.renderMode != RenderMode.WorldSpace)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_UICanvas", "Canvas", "the same", " that is set to `Render Mode = World Space`"));
				return;
			}
			Vector2 sizeDelta = component.GetComponent<RectTransform>().sizeDelta;
			GraphicRaycaster component2 = component.gameObject.GetComponent<GraphicRaycaster>();
			VRTK_UIGraphicRaycaster vRTK_UIGraphicRaycaster = component.gameObject.GetComponent<VRTK_UIGraphicRaycaster>();
			if (vRTK_UIGraphicRaycaster == null)
			{
				vRTK_UIGraphicRaycaster = component.gameObject.AddComponent<VRTK_UIGraphicRaycaster>();
			}
			if (component2 != null && component2.enabled)
			{
				vRTK_UIGraphicRaycaster.ignoreReversedGraphics = component2.ignoreReversedGraphics;
				vRTK_UIGraphicRaycaster.blockingObjects = component2.blockingObjects;
				vRTK_UIGraphicRaycaster.GetType().GetField("m_BlockingMask", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(vRTK_UIGraphicRaycaster, component2.GetType().GetField("m_BlockingMask", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(component2));
				component2.enabled = false;
			}
			CreateActivator(component, sizeDelta);
		}
	}
}
