using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Xml.Examples
{
	[ExecuteInEditMode]
	internal class XmlLayout_Example_ExampleMenu : XmlLayoutController
	{
		public List<XmlLayout> Examples = new List<XmlLayout>();

		protected XmlLayout CurrentExample;

		private XmlElement menuButtonGroup;

		public void SelectExample(string name = null)
		{
			if (name == null)
			{
				CurrentExample = null;
				HideAllExamples();
				return;
			}
			XmlLayout newExample = Examples.FirstOrDefault((XmlLayout e) => e.name == name);
			if (newExample != null)
			{
				if (CurrentExample != null && newExample != CurrentExample)
				{
					CurrentExample.Hide(delegate
					{
						ShowExample(newExample);
					});
				}
				else
				{
					ShowExample(newExample);
				}
				return;
			}
			switch (name)
			{
			case "Drag & Drop":
				SceneManager.LoadScene("Drag & Drop Example");
				break;
			case "Localization":
				SceneManager.LoadScene("Localization Example");
				break;
			case "World Space":
				SceneManager.LoadScene("World Space Example");
				break;
			}
		}

		private void ShowExample(XmlLayout newExample)
		{
			foreach (XmlLayout example in Examples)
			{
				if (example != newExample)
				{
					example.Hide();
				}
			}
			newExample.Show();
			CurrentExample = newExample;
		}

		public void HideAllExamples()
		{
			foreach (XmlLayout example in Examples)
			{
				if (example.gameObject.activeInHierarchy)
				{
					example.Hide();
				}
			}
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (parseResult != ParseXmlResult.Changed)
			{
				return;
			}
			menuButtonGroup = base.xmlLayout.GetElementById("menuButtons");
			XmlElement elementById = base.xmlLayout.GetElementById("menuButtonTemplate");
			foreach (XmlLayout example in Examples)
			{
				string text = example.name;
				AddMenuButton(text, menuButtonGroup, elementById);
			}
			AddMenuButton("Drag & Drop", menuButtonGroup, elementById);
			AddMenuButton("Localization", menuButtonGroup, elementById);
			AddMenuButton("World Space", menuButtonGroup, elementById);
		}

		private void AddMenuButton(string name, XmlElement menuButtonGroup, XmlElement menuButtonTemplate)
		{
			XmlElement xmlElement = Object.Instantiate(menuButtonTemplate);
			xmlElement.name = name;
			XmlElement component = xmlElement.GetComponent<XmlElement>();
			component.Initialise(base.xmlLayout, (RectTransform)xmlElement.transform, menuButtonTemplate.tagHandler);
			menuButtonGroup.AddChildElement(xmlElement);
			component.SetAttribute("text", name);
			component.SetAttribute("active", "true");
			component.SetAttribute("onClick", "SelectExample(" + name + ");");
			component.SetAttribute("tooltip", "Show the <color=\"#00FF00\">" + name + "</color> example.");
			component.SetAttribute("tooltipPosition", "Right");
			component.SetAttribute("tooltipOffset", "15");
			component.ApplyAttributes();
		}
	}
}
