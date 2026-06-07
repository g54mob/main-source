using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ChildXmlLayoutTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent => base.currentInstanceTransform.GetComponentInChildren<XmlLayout>();

		public override string prefabPath => null;

		public override bool isCustomElement => true;

		public override string elementChildType => null;

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "viewPath", "xs:string" },
			{ "controller", "xs:string" }
		};

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			MatchParentDimensions();
			XmlElement xmlElement = base.currentXmlElement;
			xmlElement.name = "ChildXmlLayout";
			base.ApplyAttributes(attributesToApply);
			attributesToApply.Remove("id");
			attributesToApply.Remove("internalId");
			if (xmlElement.GetAttribute("initialized") != null)
			{
				return;
			}
			string value = attributesToApply.GetValue<string>("viewPath");
			if (string.IsNullOrEmpty(value))
			{
				Debug.LogWarning("[XmlLayout][Warning][ChildXmlLayout]:: The 'viewPath' attribute is required.");
				return;
			}
			Type type = null;
			string value2 = attributesToApply.GetValue<string>("controller");
			if (!string.IsNullOrEmpty(value2))
			{
				type = GetTypeFromStringName(value2);
				if (type == null)
				{
					Debug.LogWarning("[XmlLayout][Warning][ChildXmlLayout]:: Controller Type '" + value2 + "' not found. Please ensure that the full class name (including the namespace, if the class is located within one). For example: MyNamespace.MyLayoutControllerType");
				}
			}
			bool flag = false;
			if (type == null)
			{
				type = typeof(XmlLayoutController);
				flag = true;
			}
			XmlLayout xmlLayout = XmlLayoutFactory.Instantiate(base.currentInstanceTransform, value, type);
			xmlLayout.ParentLayout = xmlElement.xmlLayoutInstance;
			xmlLayout.ForceRebuildOnAwake = false;
			if (flag)
			{
				xmlLayout.XmlLayoutController.EventTarget = base.currentXmlLayoutInstance.XmlLayoutController;
			}
			Canvas canvas = xmlElement.gameObject.GetComponent<Canvas>();
			if (canvas == null)
			{
				canvas = xmlElement.gameObject.AddComponent<Canvas>();
			}
			canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.Normal | AdditionalCanvasShaderChannels.Tangent;
			if (xmlElement.gameObject.GetComponent<GraphicRaycaster>() == null)
			{
				xmlElement.gameObject.AddComponent<GraphicRaycaster>();
			}
			xmlLayout.XmlElement.tagType = "XmlLayout";
			xmlElement.AddChildElement(xmlLayout.XmlElement, adjustRectTransform: false);
			xmlElement.SetAttribute("initialized", "true");
			xmlLayout.XmlElement.ApplyAttributes(attributesToApply);
		}

		private Type GetTypeFromStringName(string typeName)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				if (!assembly.IsDynamic)
				{
					Type type = assembly.GetType(typeName, throwOnError: false, ignoreCase: true);
					if (type != null)
					{
						return type;
					}
				}
			}
			Debug.LogError("Could not find type from string for type:" + typeName);
			return null;
		}
	}
}
