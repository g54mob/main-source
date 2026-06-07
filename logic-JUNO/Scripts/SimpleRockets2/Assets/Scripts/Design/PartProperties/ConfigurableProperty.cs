using System.Reflection;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using ModApi.Design.PartProperties;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class ConfigurableProperty : IConfigurableProperty
	{
		public DesignerPropertyAttribute Attribute { get; private set; }

		public object CurrentFieldTarget { get; private set; }

		public IDesignerPartModifierData CurrentPartModifier { get; private set; }

		public IDesignerPartProperties CurrentPartProperties { get; private set; }

		public FieldInfo Field { get; private set; }

		public string FieldName
		{
			get
			{
				if (!string.IsNullOrEmpty(Attribute.Label))
				{
					return Attribute.Label;
				}
				string text = Field.Name.TrimStart('_');
				return text[0].ToString().ToUpper() + text.Substring(1);
			}
		}

		public PropertyRowScript Row { get; private set; }

		public ConfigurableProperty(FieldInfo field, DesignerPropertyAttribute attribute)
		{
			Field = field;
			Attribute = attribute;
		}

		public void CreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			GameObject gameObject = OnCreateUI(parent, flyout);
			Row = gameObject.AddComponent<PropertyRowScript>();
		}

		public void OnPartSelectionChanged(PartModifierData partModifier, IDesignerPartProperties partProperties)
		{
			bool num = CurrentPartModifier != null && partModifier == null;
			bool flag = CurrentPartModifier != partModifier && partModifier != null;
			CurrentPartModifier = partModifier;
			CurrentFieldTarget = partModifier;
			CurrentPartProperties = partProperties;
			if (num)
			{
				OnPartDeselected();
			}
			else if (flag)
			{
				OnPartSelected();
			}
		}

		public virtual void RefreshUI()
		{
		}

		public void SetPreferredHeight(float height)
		{
			LayoutElement component = Row.GetComponent<LayoutElement>();
			if (component != null)
			{
				component.preferredHeight = height;
			}
		}

		public void SetReadOnly()
		{
			Row.GetComponent<XmlElement>()?.AddClass("read-only");
		}

		protected object GetValue()
		{
			return Field.GetValue(CurrentFieldTarget);
		}

		protected virtual GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			Debug.LogWarningFormat("Designer property attribute of type '{0}' is not supported.", Attribute.GetType().FullName);
			RectTransform rectTransform = new GameObject("UnsupportedProperty").AddComponent<RectTransform>();
			rectTransform.sizeDelta = Vector2.zero;
			rectTransform.localPosition = Vector3.zero;
			rectTransform.SetParent(parent.transform, worldPositionStays: false);
			rectTransform.gameObject.SetActive(value: false);
			return rectTransform.gameObject;
		}

		protected virtual void OnPartDeselected()
		{
		}

		protected virtual void OnPartSelected()
		{
		}

		protected void SetValue(object value)
		{
			object value2 = Field.GetValue(CurrentFieldTarget);
			Field.SetValue(CurrentFieldTarget, value);
			CurrentPartModifier.DesignerPartProperties.OnPropertyChanged(Field, value, value2);
			if (CurrentPartProperties != null)
			{
				CurrentPartProperties.OnPropertyChanged(Field);
			}
		}
	}
}
