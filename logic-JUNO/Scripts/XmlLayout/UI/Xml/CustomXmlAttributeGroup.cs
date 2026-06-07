using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UI.Xml
{
	public abstract class CustomXmlAttributeGroup
	{
		public virtual string GroupName
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(GetType().Name);
				stringBuilder.Replace("AttributeGroup", string.Empty);
				stringBuilder[0] = char.ToLower(stringBuilder[0]);
				return stringBuilder.ToString();
			}
		}

		public abstract List<Type> CustomXmlAttributes { get; }

		public bool Validate()
		{
			if (CustomXmlAttributes == null || !CustomXmlAttributes.Any())
			{
				Debug.LogWarning("[XmlLayout][CustomXmlAttributeGroup] Warning: a Custom Xml Attribute Group has no attributes defined.");
				return false;
			}
			Type type = typeof(CustomXmlAttribute);
			if (CustomXmlAttributes.Any((Type t) => !t.IsSubclassOf(type)))
			{
				Debug.LogWarning("[XmlLAyout][CustomXmlAttributeGroup] Warning: All Custom Xml Attributes must extend the CustomXmlAttribute class.");
				return false;
			}
			return true;
		}
	}
}
