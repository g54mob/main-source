using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class ActivationPanelController : FlightPanelController
	{
		private class ActivationButton
		{
			public int ActivationGroup { get; set; }

			public XmlElement Button { get; set; }

			public TextMeshProUGUI NameText { get; set; }

			public TextMeshProUGUI NumberText { get; set; }

			public bool State { get; set; }
		}

		private VerticalLayoutGroup _activationPanel;

		private List<ActivationButton> _buttons = new List<ActivationButton>();

		private XmlElement _noActivationGroupsText;

		private GameObject _template;

		public override void CraftNodeChanged(CraftNode craftNode)
		{
			if (craftNode != null)
			{
				Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
				foreach (PartData part in craftNode.CraftScript.Data.Assembly.Parts)
				{
					dictionary[part.ActivationGroup] = true;
					List<PartModifierData> modifiers = part.Modifiers;
					int count = modifiers.Count;
					for (int i = 0; i < count; i++)
					{
						foreach (int associatedActivationGroup in modifiers[i].GetAssociatedActivationGroups())
						{
							dictionary[associatedActivationGroup] = true;
						}
					}
				}
				if (craftNode.CraftScript.ActiveCommandPod != null)
				{
					if (craftNode.CraftScript.ActiveCommandPod.Part.GetModifier<FlightProgramData>() != null)
					{
						for (int j = 0; j < craftNode.CraftScript.ActiveCommandPod.ActivationGroupNames.Count; j++)
						{
							if (!string.IsNullOrWhiteSpace(craftNode.CraftScript.ActiveCommandPod.ActivationGroupNames[j]))
							{
								dictionary[j + 1] = true;
							}
						}
					}
					foreach (ActivationButton button in _buttons)
					{
						button.NameText.text = craftNode.Controls.GetActivationGroupName(button.ActivationGroup);
						if (dictionary.ContainsKey(button.ActivationGroup))
						{
							button.Button.gameObject.SetActive(value: true);
						}
						else
						{
							button.Button.gameObject.SetActive(value: false);
						}
					}
				}
				else
				{
					Debug.Log("Can't update ags b/c command pod is null");
				}
				if (dictionary.Count <= 1)
				{
					_noActivationGroupsText.SetActive(active: true);
				}
				else
				{
					_noActivationGroupsText.SetActive(active: false);
				}
				return;
			}
			foreach (ActivationButton button2 in _buttons)
			{
				button2.Button.gameObject.SetActive(value: false);
			}
			_noActivationGroupsText.SetActive(active: true);
		}

		public void CreateButtons()
		{
			for (int i = 0; i < 20; i++)
			{
				ActivationButton activationButton = new ActivationButton();
				GameObject obj = Object.Instantiate(_template);
				obj.name = $"ActivationPanel.AG{i + 1}";
				obj.transform.SetParent(_activationPanel.transform, worldPositionStays: false);
				obj.SetActive(value: true);
				XmlElement component = obj.GetComponent<XmlElement>();
				activationButton.Button = component;
				activationButton.NameText = component.GetElementByInternalId<TextMeshProUGUI>("name");
				TextMeshProUGUI elementByInternalId = component.GetElementByInternalId<TextMeshProUGUI>("number");
				activationButton.ActivationGroup = i + 1;
				elementByInternalId.text = activationButton.ActivationGroup.ToString();
				component.AddOnClickEvent(delegate
				{
					OnActivationButtonClicked(activationButton);
				});
				_buttons.Add(activationButton);
			}
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_template = base.xmlLayout.GetElementById("activation-button-template").gameObject;
			_activationPanel = base.xmlLayout.GetElementById<VerticalLayoutGroup>("activation-panel");
			_noActivationGroupsText = base.xmlLayout.GetElementById("no-ag-panel");
			CreateButtons();
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
			foreach (ActivationButton button in _buttons)
			{
				bool activationGroup = craftNode.Controls.GetActivationGroup(button.ActivationGroup);
				if (button.State != activationGroup)
				{
					button.State = activationGroup;
					if (button.State && !button.Button.HasClass("selected"))
					{
						button.Button.AddClass("selected");
					}
					else if (!button.State && button.Button.HasClass("selected"))
					{
						button.Button.RemoveClass("selected");
					}
				}
			}
		}

		private void OnActivationButtonClicked(ActivationButton activationButton)
		{
			if (base.CraftNode != null)
			{
				base.CraftNode.Controls.ToggleActivationGroup(activationButton.ActivationGroup);
			}
		}
	}
}
