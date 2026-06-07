using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class PartPropertiesFlyoutScript : DesignerFlyoutPanelScript, IPartPropertiesFlyout
	{
		public delegate void OnPartSelectionCompleteDelegate(IReadOnlyList<PartPropertiesScript> visiblePartProperties);

		private RectTransform _contentRoot;

		private XmlElement _emptyPanel;

		private List<PartPropertiesScript> _partProperties;

		private Dictionary<Type, Dictionary<Type, List<PartPropertiesScript>>> _partPropertyTypeLookup;

		private List<StylePartProperties> _stylePartProperties;

		private List<PartPropertiesScript> _visibleList;

		public static bool ChangesSinceLastUndoStep { get; set; }

		public static bool OpenedViaUndoStep { get; set; }

		public IReadOnlyList<PartPropertiesScript> PartProperties => _partProperties;

		public IReadOnlyList<StylePartProperties> StylePartProperties => _stylePartProperties;

		protected DesignerScript Designer { get; private set; }

		public event OnPartSelectionCompleteDelegate PartSelectionComplete;

		public XmlElement CloneTemplateElement(string templateId, Transform parent, string name = null)
		{
			GameObject obj = UnityEngine.Object.Instantiate(base.xmlLayout.GetElementById(templateId).gameObject);
			obj.transform.SetParent(parent, worldPositionStays: false);
			XmlElement component = obj.GetComponent<XmlElement>();
			component.SetAttribute("id", null);
			component.SetAttribute("active", "true");
			if (!string.IsNullOrEmpty(name))
			{
				component.SetAttribute("name", name);
			}
			component.ApplyAttributesRecursive();
			component.gameObject.SetActive(value: true);
			return component;
		}

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			Designer = designerUi.Designer;
			_partProperties = new List<PartPropertiesScript>();
			_stylePartProperties = new List<StylePartProperties>();
			_visibleList = new List<PartPropertiesScript>();
			_partPropertyTypeLookup = new Dictionary<Type, Dictionary<Type, List<PartPropertiesScript>>>();
			Designer.SelectedPartChanged += OnSelectedPartChanged;
			base.Flyout.Opening += OnFlyoutOpening;
			base.Flyout.Closed += OnFlyoutClosed;
			_contentRoot = base.xmlLayout.GetElementById("content-root").GetComponent<RectTransform>();
			CreatePanels();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			GenericPartPropertiesScript.CleanupCache();
		}

		public void RefreshTextureStyles()
		{
			_stylePartProperties.ForEach(delegate(StylePartProperties x)
			{
				x.RefreshTextureStyles();
			});
		}

		public void RefreshUI()
		{
			IPartScript selectedPart = Designer.SelectedPart;
			UpdateSelectedPart(selectedPart, selectedPart);
		}

		public void UpdateSymmetry()
		{
			if (Designer.SelectedPart != null)
			{
				Symmetry.SynchronizePartModifiers(Designer.SelectedPart);
			}
		}

		protected virtual void OnDestroy()
		{
			GenericPartPropertiesScript.CleanupCache();
		}

		protected void UpdateEmptyPanelLabel(string text)
		{
			_emptyPanel.GetComponentInChildren<TextMeshProUGUI>();
			_emptyPanel.GetElementByInternalId("label").SetAndApplyAttribute("text", text);
			_emptyPanel.gameObject.SetActive(!string.IsNullOrEmpty(text));
		}

		private static void UpdateSeenNotifications(IPartScript part)
		{
			bool flag = false;
			foreach (PartModifierData modifier in part.Data.Modifiers)
			{
				flag = flag || Game.Instance.Settings.AddNotification($"PartProperties-{modifier.Name}");
			}
			if (flag)
			{
				Game.Instance.Settings.Save();
			}
		}

		private void AddPartPropertyScript(Type modifierType, Type scriptType, DesignerPartModifierAttribute attribute)
		{
			int num = 0;
			PartPropertiesScript partPropertiesScript = null;
			List<PartPropertiesScript> value = null;
			if (_partPropertyTypeLookup.TryGetValue(modifierType, out var value2))
			{
				if (value2.TryGetValue(scriptType, out value))
				{
					num = value.Count;
					partPropertiesScript = value[num - 1];
				}
				else
				{
					value = new List<PartPropertiesScript>();
					value2.Add(scriptType, value);
				}
			}
			else
			{
				value = new List<PartPropertiesScript>();
				value2 = new Dictionary<Type, List<PartPropertiesScript>>();
				value2.Add(scriptType, value);
				_partPropertyTypeLookup.Add(modifierType, value2);
			}
			GameObject obj = UnityEngine.Object.Instantiate(base.xmlLayout.GetElementById("template-panel").gameObject);
			obj.SetActive(value: true);
			obj.name = "PartProperties_" + modifierType.Name + "_" + num;
			Transform transform = obj.transform;
			transform.SetParent(_contentRoot, worldPositionStays: false);
			if (partPropertiesScript == null)
			{
				transform.SetAsFirstSibling();
			}
			else
			{
				transform.SetSiblingIndex(partPropertiesScript.transform.GetSiblingIndex() + 1);
			}
			PartPropertiesScript partPropertiesScript2 = (PartPropertiesScript)obj.AddComponent(scriptType);
			partPropertiesScript2.Initialize(Designer, this, modifierType, num, attribute);
			value.Add(partPropertiesScript2);
			obj.SetActive(value: false);
			_partProperties.Add(partPropertiesScript2);
		}

		private void CreatePanels()
		{
			foreach (Type registeredPartModifierType in PartModifierData.GetRegisteredPartModifierTypes())
			{
				List<DesignerPartModifierAttribute> list = registeredPartModifierType.GetCustomAttributes(typeof(DesignerPartModifierAttribute), inherit: true).Cast<DesignerPartModifierAttribute>().ToList();
				if (list.Count == 0)
				{
					if (GenericPartPropertiesScript.NeedsPartPropertiesScript(registeredPartModifierType))
					{
						AddPartPropertyScript(registeredPartModifierType, typeof(GenericPartPropertiesScript), null);
					}
					continue;
				}
				foreach (DesignerPartModifierAttribute item in list)
				{
					Type scriptType = item.DesignerPartPropertiesType ?? typeof(GenericPartPropertiesScript);
					AddPartPropertyScript(registeredPartModifierType, scriptType, item);
				}
			}
			_partProperties = (from x in _partProperties
				orderby x.PanelOrder, x.transform.GetSiblingIndex()
				select x).ToList();
			for (int num = 0; num < _partProperties.Count; num++)
			{
				_partProperties[num].transform.SetSiblingIndex(num);
			}
			_emptyPanel = base.xmlLayout.GetElementById("empty-panel");
			_emptyPanel.gameObject.SetActive(value: false);
			GameObject obj = base.xmlLayout.GetElementById("part-part-properties").gameObject;
			obj.name = "PartPartProperties";
			Transform obj2 = obj.transform;
			obj2.SetParent(_contentRoot, worldPositionStays: false);
			obj2.SetAsFirstSibling();
			PartPartProperties partPartProperties = obj.AddComponent<PartPartProperties>();
			partPartProperties.Initialize(Designer, this, null, 0, null);
			obj.SetActive(value: false);
			_partProperties.Add(partPartProperties);
			for (int num2 = 0; num2 < SubpartType.MaxCountPerPart; num2++)
			{
				CreateStylePartProperties(num2);
			}
		}

		private void CreateStylePartProperties(int subpartIndex)
		{
			GameObject obj = CloneTemplateElement("template-style-part-properties", _contentRoot).gameObject;
			obj.name = "StylePartProperties_" + subpartIndex;
			StylePartProperties stylePartProperties = obj.AddComponent<StylePartProperties>();
			stylePartProperties.Initialize(Designer, this, null, subpartIndex, null);
			obj.SetActive(value: false);
			stylePartProperties.transform.SetAsLastSibling();
			_partProperties.Add(stylePartProperties);
			_stylePartProperties.Add(stylePartProperties);
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			foreach (PartPropertiesScript partProperty in _partProperties)
			{
				partProperty.OnPropertiesClosed();
			}
			UpdateSelectedPart(Designer.SelectedPart, null);
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			OpenedViaUndoStep = false;
			foreach (PartPropertiesScript partProperty in _partProperties)
			{
				partProperty.OnPropertiesOpened();
			}
			UpdateSelectedPart(null, Designer.SelectedPart);
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.Flyout.IsOpen)
			{
				UpdateSelectedPart(oldPart, newPart);
			}
		}

		private void UpdateSelectedPart(IPartScript oldPart, IPartScript newPart)
		{
			if (oldPart != null)
			{
				foreach (PartPropertiesScript partProperty in _partProperties)
				{
					partProperty.OnPartDeselected(oldPart);
				}
				if (ChangesSinceLastUndoStep)
				{
					Symmetry.SynchronizeParts(oldPart, synchronizeModifiers: true);
				}
			}
			_visibleList.Clear();
			if (newPart != null)
			{
				foreach (KeyValuePair<Type, Dictionary<Type, List<PartPropertiesScript>>> item in _partPropertyTypeLookup)
				{
					foreach (KeyValuePair<Type, List<PartPropertiesScript>> item2 in item.Value)
					{
						PartPropertiesScript partPropertiesScript = item2.Value[0];
						if (!partPropertiesScript.HandlesMultipleModifiers)
						{
							int modifierCount = newPart.Data.GetModifierCount(item.Key, inherit: false);
							for (int i = item2.Value.Count; i < modifierCount; i++)
							{
								AddPartPropertyScript(partPropertiesScript.ModifierType, partPropertiesScript.GetType(), partPropertiesScript.DesignerAttribute);
							}
						}
					}
				}
				foreach (PartPropertiesScript partProperty2 in _partProperties)
				{
					bool flag = partProperty2.OnPartSelected(newPart);
					partProperty2.SetVisible(flag);
					if (flag)
					{
						_visibleList.Add(partProperty2);
					}
				}
				UpdateSeenNotifications(newPart);
				UpdateEmptyPanelLabel((_visibleList.Count != 0) ? null : "The selected part has no customizable properties.");
			}
			else
			{
				foreach (PartPropertiesScript partProperty3 in _partProperties)
				{
					partProperty3.SetVisible(visible: false);
				}
				UpdateEmptyPanelLabel("Select a part to view its customizable properties.");
			}
			base.Flyout.Title = "Part Properties";
			if (oldPart != newPart && oldPart != null && ChangesSinceLastUndoStep)
			{
				ChangesSinceLastUndoStep = false;
				XElement xml = Designer.GenerateCraftXml(undoStep: true, optimizeXml: true);
				Designer.UndoHistory.PushUndo(new PartPropertiesUndoStep(xml, oldPart.Data.Id));
			}
			_contentRoot.ForceUpdateRectTransforms();
			if (newPart != null)
			{
				this.PartSelectionComplete?.Invoke(_visibleList);
			}
			_visibleList.Clear();
		}
	}
}
