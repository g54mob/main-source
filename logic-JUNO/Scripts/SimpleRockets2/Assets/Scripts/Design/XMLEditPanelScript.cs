using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class XMLEditPanelScript : DesignerFlyoutPanelScript
	{
		private XElement _xml;

		private XElement _backupxml;

		private IPartScript _part;

		private Dictionary<string, XElement> _elements = new Dictionary<string, XElement>();

		private XmlElement _content;

		private SpinnerScript _spinner;

		private List<char> _invalidCharacters = new List<char>();

		private XmlElement _template;

		private bool _ignoreCraftStructureChanged;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			base.Flyout.Opening += OnFlyoutOpening;
			Game.Instance.Designer.SelectedPartChanged += OnSelectedPartChanged;
			Game.Instance.Designer.CraftStructureChanged += OnCraftStructureChanged;
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
			_spinner = base.xmlLayout.GetElementById<SpinnerScript>("spinner-modifier");
		}

		private void OnCraftStructureChanged()
		{
			if (base.Flyout.IsOpen && !_ignoreCraftStructureChanged)
			{
				OnSelectedPartChanged(null, Game.Instance.Designer.SelectedPart);
			}
		}

		private void OnApplyClicked()
		{
			PartData data = _part.Data;
			data.LoadXML(_xml, 15);
			ISymmetrySlice symmetrySlice = _part.SymmetrySlice;
			if (_part.Data.IsRootPart)
			{
				Game.Instance.Designer.CraftScript.CenterOfMass.SetParent(null);
				Object.DestroyImmediate(_part.GameObject);
				CraftBuilder.CreatePartGameObjects(new PartData[1] { data }, Game.Instance.Designer.CraftScript);
				try
				{
					_ignoreCraftStructureChanged = true;
					Game.Instance.Designer.CraftScript.SetPrimaryCommandPod(data.PartScript.GetModifier<CommandPodScript>(), saveUndoStep: false);
				}
				finally
				{
					_ignoreCraftStructureChanged = false;
				}
			}
			else
			{
				Object.DestroyImmediate(_part.GameObject);
				CraftBuilder.CreatePartGameObjects(new PartData[1] { data }, Game.Instance.Designer.CraftScript);
			}
			Game.Instance.Designer.SelectPart(data.PartScript, null, justAdded: true);
			data.PartScript.SymmetrySlice = symmetrySlice;
			Symmetry.SynchronizeParts(data.PartScript, synchronizeModifiers: true);
			Game.Instance.Designer.CraftScript.SetStructureChanged();
			Game.Instance.Designer.CreateUndoStep();
		}

		private void OnDiscardClicked()
		{
			_xml = _backupxml;
			OnSelectedPartChanged(Game.Instance.Designer.SelectedPart, Game.Instance.Designer.SelectedPart);
		}

		private void OnRemoveModifierClicked()
		{
			string[] names = _spinner.Value.Split();
			switch (names[0])
			{
			case "Config":
				return;
			case "Drag":
				return;
			}
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.Designer.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "By removing a necessary modifier you can brick your craft. Are you sure you want to remove it?";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				_xml.Elements(names[0]).ElementAt((names.Length != 1) ? (names[1].ToInt() - 1) : 0).Remove();
				_spinner.Value = _xml.Name.LocalName;
				OnApplyClicked();
				d.Close();
			};
		}

		private void OnNewModifierClicked()
		{
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.Designer.UserInterface.CreateInputDialog();
			inputDialogScript.InputPlaceholderText = "MODIFIER NAME";
			inputDialogScript.MessageText = "NAME THE MODIFIER\n\nAll your unsaved changes will be lost";
			inputDialogScript.OkayButtonText = "ADD";
			inputDialogScript.CancelButtonText = "CANCEL";
			inputDialogScript.InputText = "InputController";
			inputDialogScript.InvalidCharacters.AddRange(_invalidCharacters);
			inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				string text = d.InputText;
				switch (text)
				{
				default:
					OnDiscardClicked();
					if (_spinner.Values.Contains(text))
					{
						int num = 2;
						while (_spinner.Values.Contains(text + " " + num))
						{
							num++;
						}
						text = text + " " + num;
					}
					_xml.Add(new XElement(d.InputText, (d.InputText == "InputController") ? new XAttribute("inputId", "Activator") : null));
					OnApplyClicked();
					if (_spinner.Values.Contains(text))
					{
						OnModifierChanged(text);
					}
					d.Close();
					break;
				case "Config":
					break;
				case "Drag":
					break;
				}
			};
		}

		private void CreateListItem(string paramName, string type, string value, string backupValue, XmlElement parent)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_template, parent);
			xmlElement.transform.SetSiblingIndex(parent.transform.childCount - 2);
			XmlElement paramNameText = xmlElement.GetElementByInternalId("param-name");
			xmlElement.GetElementByInternalId("param-value").SetText(type);
			if (backupValue == string.Empty || backupValue == value)
			{
				paramNameText.SetText(paramName);
			}
			else
			{
				paramNameText.SetText("<color=#33cc33>" + paramName + "</color>");
			}
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("value-input");
			elementByInternalId.SetText(value);
			elementByInternalId.GetComponent<TMP_InputField>().onValueChanged.AddListener(delegate(string s)
			{
				paramNameText.SetText("<color=#33cc33>" + paramName + "</color>");
				OnValueChanged(paramName, s);
			});
		}

		private void OnModifierChanged(string name)
		{
			_spinner.Value = name;
			XElement xElement = _elements[name];
			foreach (XmlElement item in _content.GetChildElementsWithClass("ag-item"))
			{
				if (item != _template)
				{
					_content.RemoveChildElement(item, destroyChild: true);
				}
			}
			XElement xElement2;
			if (name == _xml.Name.LocalName)
			{
				xElement2 = _backupxml;
			}
			else
			{
				string[] array = name.Split();
				xElement2 = _backupxml.Elements(array[0]).ElementAt((array.Length != 1) ? (array[1].ToInt() - 1) : 0);
			}
			foreach (XAttribute item2 in xElement.Attributes().ToList())
			{
				string backupValue = string.Empty;
				if (xElement2 != null)
				{
					backupValue = xElement2.Attribute(item2.Name.LocalName)?.Value;
				}
				CreateListItem(item2.Name.LocalName, item2.Value.GetType().Name, item2.Value, backupValue, _content);
			}
		}

		private void OnValueChanged(string param, string value)
		{
			if (param != "partType")
			{
				_elements[_spinner.Value].Attribute(param).SetValue(value);
			}
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			OnSelectedPartChanged(null, Game.Instance.Designer.SelectedPart);
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (!base.Flyout.IsOpen)
			{
				return;
			}
			if (newPart == null)
			{
				base.Flyout.Close();
				return;
			}
			if (oldPart != newPart)
			{
				_part = newPart;
				_xml = _part.Data.GenerateXml(_part.CraftScript.Transform, optimizeXml: false);
				_xml.SetAttributeValue("activated", _part.Data.Activated);
				_backupxml = new XElement(_xml);
				_part.OnCraftStructureChanged();
			}
			string value = _spinner.Value;
			_spinner.Values.Clear();
			_elements.Clear();
			_elements.Add(_xml.Name.LocalName, _xml);
			_spinner.Values.Add(_xml.Name.LocalName);
			foreach (XElement item in _xml.Elements())
			{
				string text = item.Name.LocalName;
				if (_spinner.Values.Contains(text))
				{
					int num = 2;
					while (_spinner.Values.Contains(text + " " + num))
					{
						num++;
					}
					text = text + " " + num;
				}
				_elements.Add(text, item);
				_spinner.Values.Add(text);
			}
			OnModifierChanged(_spinner.Values.Contains(value) ? value : _xml.Name.LocalName);
		}
	}
}
