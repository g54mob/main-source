using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class ActivationGroupsPanelScript : DesignerSubPanelScript
	{
		private XmlElement _content;

		private List<IPartScript> _highlightedParts = new List<IPartScript>();

		private List<char> _invalidCharacters = new List<char>();

		private XmlElement _template;

		public CommandPodScript CommandPod { get; set; }

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_invalidCharacters.Add(',');
			_invalidCharacters.Add('"');
			_invalidCharacters.Add('\'');
			_invalidCharacters.Add('<');
			_invalidCharacters.Add('>');
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_content = base.xmlLayout.GetElementById("content");
			_template = base.xmlLayout.GetElementById("template");
		}

		public override void OnClosed()
		{
			base.OnClosed();
			StopHighlightingParts();
			CommandPod = null;
		}

		public override void OnOpened()
		{
			base.OnOpened();
			CommandPod = base.DesignerUi.Designer.SelectedPart?.GetModifier<CommandPodScript>() ?? base.DesignerUi.Designer.CraftScript.RootPart.GetModifier<CommandPodScript>();
			RefreshList();
		}

		private void CreateListItem(int activationGroup, string name, XmlElement parent)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_template, parent);
			xmlElement.transform.SetSiblingIndex(parent.transform.childCount - 2);
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("name-input");
			elementByInternalId.SetText(name);
			TMP_InputField component = elementByInternalId.GetComponent<TMP_InputField>();
			component.onEndEdit.AddListener(delegate(string s)
			{
				OnNameChanged(s, activationGroup);
			});
			component.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(component.onValidateInput, new TMP_InputField.OnValidateInput(OnValidateInput));
			component.characterLimit = 20;
			component.onSelect.AddListener(delegate
			{
				HighlightActivationGroup(activationGroup);
			});
			component.onDeselect.AddListener(delegate
			{
				StopHighlightingParts();
			});
			xmlElement.GetElementByInternalId("name-placeholder").SetText("Activation Group " + activationGroup);
			xmlElement.GetElementByInternalId("number-text").SetText(activationGroup.ToString());
			Toggle elementByInternalId2 = xmlElement.GetElementByInternalId<Toggle>("active-on-start-toggle");
			elementByInternalId2.isOn = CommandPod.GetActivationGroupState(activationGroup);
			elementByInternalId2.onValueChanged.AddListener(delegate(bool v)
			{
				OnActivateOnStartChanged(v, activationGroup);
			});
		}

		private void HighlightActivationGroup(int activationGroup)
		{
			StopHighlightingParts();
			foreach (PartData part in base.DesignerUi.Designer.CraftScript.Data.Assembly.Parts)
			{
				if (!(part.CommandPod == CommandPod.Part))
				{
					continue;
				}
				bool flag = part.ActivationGroup == activationGroup;
				if (!flag)
				{
					List<PartModifierData> modifiers = part.Modifiers;
					int count = modifiers.Count;
					for (int i = 0; i < count; i++)
					{
						foreach (int associatedActivationGroup in modifiers[i].GetAssociatedActivationGroups())
						{
							if (associatedActivationGroup == activationGroup)
							{
								flag = true;
								i = count;
								break;
							}
						}
					}
				}
				if (flag)
				{
					_highlightedParts.Add(part.PartScript);
					part.PartScript.PartMaterialScript.IsHighlighted = true;
				}
			}
		}

		private void OnActivateOnStartChanged(bool state, int activationGroup)
		{
			CommandPod.SetActivationGroupState(activationGroup, state);
		}

		private void OnNameChanged(string name, int activationGroup)
		{
			if (activationGroup - 1 < CommandPod.ActivationGroupNames.Count)
			{
				CommandPod.ActivationGroupNames[activationGroup - 1] = name;
			}
		}

		private char OnValidateInput(string text, int charIndex, char addedChar)
		{
			if (_invalidCharacters.Contains(addedChar))
			{
				return '\0';
			}
			return addedChar;
		}

		private void RefreshList()
		{
			foreach (XmlElement item in _content.GetChildElementsWithClass("ag-item"))
			{
				if (item != _template)
				{
					_content.RemoveChildElement(item, destroyChild: true);
				}
			}
			int num = Mathf.Max(CommandPod.ActivationGroupNames.Count, 10);
			for (int i = 0; i < num; i++)
			{
				string text = string.Empty;
				if (i < CommandPod.ActivationGroupNames.Count && !string.IsNullOrWhiteSpace(CommandPod.ActivationGroupNames[i]))
				{
					text = CommandPod.ActivationGroupNames[i];
				}
				CreateListItem(i + 1, text, _content);
			}
		}

		private void StopHighlightingParts()
		{
			foreach (IPartScript highlightedPart in _highlightedParts)
			{
				highlightedPart.PartMaterialScript.IsHighlighted = false;
			}
			_highlightedParts.Clear();
		}
	}
}
