using System.Collections.Generic;

namespace UI.Xml
{
	public abstract class CustomXmlAttribute
	{
		public enum eAttributeGroup
		{
			AllElements = 0,
			RectTransform = 1,
			RectPosition = 2,
			LayoutElement = 3,
			LayoutBase = 4,
			Image = 5,
			Text = 6,
			Animation = 7,
			Events = 8,
			Button = 9,
			Dragging = 10,
			Custom = 11,
			Tooltip = 12
		}

		public virtual bool UsesConvertMethod => false;

		public virtual bool UsesApplyMethod => false;

		public virtual bool RestrictToPermittedElementsOnly => false;

		public virtual List<string> PermittedElements => new List<string>();

		public virtual bool KeepOriginalTag => false;

		public virtual string ValueDataType => "xs:string";

		public virtual eAttributeGroup AttributeGroup => eAttributeGroup.AllElements;

		public virtual string DefaultValue => string.Empty;

		public virtual AttributeDictionary Convert(string value, AttributeDictionary attributes, XmlElement xmlElement)
		{
			return null;
		}

		public virtual void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
		}
	}
}
