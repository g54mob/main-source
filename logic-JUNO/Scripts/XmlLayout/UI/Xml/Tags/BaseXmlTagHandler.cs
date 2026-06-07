using System;
using UnityEngine;

namespace UI.Xml.Tags
{
	public abstract class BaseXmlTagHandler : ElementTagHandler
	{
		public override bool isCustomElement => true;

		public override string prefabPath => null;

		public virtual string Xml
		{
			get
			{
				if (XmlPath != null)
				{
					return XmlLayoutResourceDatabase.instance.LoadXml(XmlPath).text;
				}
				return "<XmlLayout></XmlLayout>";
			}
		}

		public virtual string XmlPath => null;

		public virtual Type ControllerType => null;

		public virtual Type PrimaryComponentType => null;

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (PrimaryComponentType == null)
				{
					return base.currentXmlElement;
				}
				return (MonoBehaviour)base.currentXmlElement.GetComponent(PrimaryComponentType);
			}
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			MatchParentDimensions();
			XmlElement xmlElement = base.currentXmlElement;
			xmlElement.name = base.tagType;
			base.ApplyAttributes(attributesToApply);
			XmlLayout xmlLayout = xmlElement.GetComponent<XmlLayout>();
			if (xmlLayout == null)
			{
				xmlLayout = xmlElement.gameObject.AddComponent<XmlLayout>();
			}
			xmlLayout.Xml = Xml;
			if (!xmlLayout.Xml.Contains("<XmlLayout"))
			{
				xmlLayout.Xml = "<XmlLayout>" + xmlLayout.Xml + " </XmlLayout>";
			}
			if (PrimaryComponentType != null && xmlElement.GetComponent(PrimaryComponentType) == null)
			{
				xmlElement.gameObject.AddComponent(PrimaryComponentType);
			}
			if (ControllerType != null)
			{
				if (ControllerType.IsSubclassOf(typeof(XmlLayoutController)))
				{
					if (xmlElement.GetComponent<XmlLayoutController>() == null)
					{
						xmlElement.gameObject.AddComponent(ControllerType);
					}
				}
				else
				{
					Debug.LogWarning("[XmlLayout][" + GetType().Name + "][Warning]:: Type '" + ControllerType.Name + "' is not inherited XmlLayoutController.");
				}
			}
			xmlLayout.RebuildLayout();
			if (!string.IsNullOrEmpty(XmlPath))
			{
				base.currentXmlLayoutInstance.ChildElementXmlFiles.Add(XmlPath);
			}
		}
	}
}
