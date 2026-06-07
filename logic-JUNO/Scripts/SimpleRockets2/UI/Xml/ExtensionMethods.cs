namespace UI.Xml
{
	public static class ExtensionMethods
	{
		public static void ApplyAttributesRecursive(this XmlElement e)
		{
			e.ApplyAttributes();
			foreach (XmlElement childElement in e.childElements)
			{
				childElement.ApplyAttributesRecursive();
			}
		}

		public static XmlElement GetParentElementWithClass(this XmlElement xmlElement, string className)
		{
			if (xmlElement.HasClass(className))
			{
				return xmlElement;
			}
			if (xmlElement.transform.parent != null)
			{
				XmlElement component = xmlElement.transform.parent.GetComponent<XmlElement>();
				if (component != null)
				{
					return component.GetParentElementWithClass(className);
				}
			}
			return null;
		}

		public static string GetText(this XmlElement xmlElement)
		{
			return xmlElement.GetAttribute("text");
		}

		public static void SetActive(this XmlElement xmlElement, bool active)
		{
			if (active)
			{
				xmlElement.SetAndApplyAttribute("active", "true");
			}
			else
			{
				xmlElement.SetAndApplyAttribute("active", "false");
			}
		}

		public static void SetText(this XmlElement xmlElement, string text)
		{
			xmlElement.SetAndApplyAttribute("text", text);
		}

		public static void ToggleClass(this XmlElement e, string className)
		{
			if (e.HasClass(className))
			{
				e.RemoveClass(className);
			}
			else
			{
				e.AddClass(className);
			}
		}

		public static void ToggleVisibility(this XmlElement e)
		{
			if (e.Visible)
			{
				e.Hide();
			}
			else
			{
				e.Show();
			}
		}
	}
}
