using System;
using ModApi.Ui;
using UnityEngine;

namespace UI.Xml
{
	public static class XmlLayoutFactory
	{
		public static XmlLayout Instantiate(RectTransform parent, string xmlFilePath, Type controllerType = null, bool hidden = false)
		{
			XmlLayout component = InstantiatePrefab("XmlLayout Prefabs/XmlLayout").GetComponent<XmlLayout>();
			component.transform.SetParent(parent);
			FixInstanceTransform(component.transform as RectTransform);
			Action<IXmlLayoutController> action = null;
			if (!string.IsNullOrEmpty(xmlFilePath))
			{
				(component.XmlFile, action) = XmlLayoutResourceDatabase.instance.LoadXmlWithLayoutRebuiltCallback(xmlFilePath);
			}
			if (controllerType != null)
			{
				XmlLayoutController xmlLayoutController = component.gameObject.AddComponent(controllerType) as XmlLayoutController;
				if (xmlLayoutController != null && action != null)
				{
					xmlLayoutController.OnLayoutRebuilt = (Action<XmlLayoutController>)Delegate.Combine(xmlLayoutController.OnLayoutRebuilt, action);
				}
			}
			component.name = "XmlLayout";
			component.ReloadXmlFile();
			if (hidden)
			{
				component.XmlElement.Visible = true;
				CanvasGroup canvasGroup = component.GetComponent<CanvasGroup>();
				if (canvasGroup == null)
				{
					canvasGroup = component.gameObject.AddComponent<CanvasGroup>();
				}
				canvasGroup.alpha = 0f;
				canvasGroup.blocksRaycasts = false;
				component.Hide(delegate
				{
					canvasGroup.alpha = 1f;
					canvasGroup.blocksRaycasts = true;
				});
			}
			return component;
		}

		private static GameObject InstantiatePrefab(string name)
		{
			return UnityEngine.Object.Instantiate(XmlLayoutUtilities.LoadResource<GameObject>(name));
		}

		private static void FixInstanceTransform(RectTransform instanceTransform)
		{
			instanceTransform.localPosition = Vector3.zero;
			instanceTransform.rotation = default(Quaternion);
			instanceTransform.localScale = Vector3.one;
			instanceTransform.anchoredPosition = Vector2.zero;
			instanceTransform.anchoredPosition3D = Vector3.zero;
			instanceTransform.sizeDelta = Vector3.one;
		}
	}
}
