using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using ModApi.Design.PartProperties;
using ModApi.Services.Purchasing;
using ModApi.Settings;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class GenericPartPropertiesScript : PartPropertiesScript, IDesignerPartProperties
	{
		private static Dictionary<Type, Dictionary<int, List<ConfigurableProperty>>> _typePropertiesMap = new Dictionary<Type, Dictionary<int, List<ConfigurableProperty>>>();

		private DesignerSettings _designerSettings;

		private TextMeshProUGUI _headerLabel;

		private List<ConfigurableProperty> _properties;

		private List<PartModifierData> _tempPartModifiers;

		private RectTransform _transform;

		public IDesignerPartModifierData CurrentPartModifier { get; private set; }

		public Button HeaderDeleteButton { get; private set; }

		IPartPropertiesFlyout IDesignerPartProperties.Flyout => base.Flyout;

		public static void CleanupCache()
		{
			_typePropertiesMap.Clear();
		}

		public static bool NeedsPartPropertiesScript(Type modifierType)
		{
			List<ConfigurableProperty> configurablePropertiesList = GetConfigurablePropertiesList(modifierType);
			if (configurablePropertiesList.Count > 0)
			{
				if (!_typePropertiesMap.ContainsKey(modifierType))
				{
					Dictionary<int, List<ConfigurableProperty>> dictionary = new Dictionary<int, List<ConfigurableProperty>>();
					dictionary.Add(0, configurablePropertiesList);
					_typePropertiesMap.Add(modifierType, dictionary);
				}
				return true;
			}
			return false;
		}

		public T GetProperty<T>(FieldInfo field) where T : class, IConfigurableProperty
		{
			foreach (ConfigurableProperty property in _properties)
			{
				if (property.Field == field)
				{
					return property as T;
				}
			}
			return null;
		}

		public override void OnPartDeselected(IPartScript part)
		{
			if (CurrentPartModifier != null)
			{
				CurrentPartModifier.DesignerPartProperties.OnDeactivated(this);
			}
			foreach (ConfigurableProperty property in _properties)
			{
				property.OnPartSelectionChanged(null, null);
			}
			CurrentPartModifier = null;
		}

		public override bool OnPartSelected(IPartScript part)
		{
			part.Data.GetModifiers(base.ModifierType, inherit: false, _tempPartModifiers);
			if (_tempPartModifiers.Count == 0 || _tempPartModifiers.Count <= base.ModifierIndex)
			{
				_tempPartModifiers.Clear();
				return false;
			}
			PartModifierData partModifierData = _tempPartModifiers[base.ModifierIndex];
			_tempPartModifiers.Clear();
			if (!partModifierData.PartPropertiesEnabled)
			{
				return false;
			}
			CurrentPartModifier = partModifierData;
			if (CurrentPartModifier != null)
			{
				CurrentPartModifier.DesignerPartProperties.OnActivated(this);
			}
			foreach (ConfigurableProperty property in _properties)
			{
				property.OnPartSelectionChanged(partModifierData, this);
			}
			foreach (ConfigurableProperty property2 in _properties)
			{
				CurrentPartModifier.DesignerPartProperties.OnPropertyActivated(property2);
			}
			return true;
		}

		public override void OnPropertiesOpened()
		{
			base.OnPropertiesOpened();
			RefreshUI();
		}

		public void OnPropertyChanged(FieldInfo field)
		{
			PartPropertiesFlyoutScript.ChangesSinceLastUndoStep = true;
		}

		public void RefreshUI()
		{
			foreach (ConfigurableProperty property in _properties)
			{
				property.RefreshUI();
			}
			if (CurrentPartModifier == null)
			{
				return;
			}
			CurrentPartModifier.DesignerPartProperties.OnRefreshUI();
			string headerLabel = CurrentPartModifier.DesignerPartProperties.GetHeaderLabel();
			if (headerLabel != null)
			{
				_headerLabel.text = headerLabel;
			}
			if (!(_headerLabel != null))
			{
				return;
			}
			bool flag = false;
			if (headerLabel != string.Empty)
			{
				int childCount = _transform.childCount;
				for (int i = 1; i < childCount; i++)
				{
					PropertyRowScript component = _transform.GetChild(i).GetComponent<PropertyRowScript>();
					if (component != null)
					{
						flag |= component.Visible;
					}
				}
			}
			_transform.GetChild(0).gameObject.SetActive(flag);
		}

		public void SetVisibility(FieldInfo field, bool visible)
		{
			foreach (ConfigurableProperty property in _properties)
			{
				if (property.Field == field)
				{
					property.Row.Visible = visible;
					if (property.CurrentPartModifier != null)
					{
						property.CurrentPartModifier.DesignerPartProperties.SetVisible(field, visible);
					}
					break;
				}
			}
		}

		public override void SetVisible(bool visible)
		{
			base.SetVisible(visible);
			if (visible)
			{
				RefreshUI();
			}
		}

		public void UpdateVisibility(FieldInfo field)
		{
			bool value = _designerSettings.ShowHiddenPartProperties.Value;
			foreach (ConfigurableProperty property in _properties)
			{
				if (field == null || property.Field == field)
				{
					if (property.CurrentPartModifier != null)
					{
						bool flag = !property.Attribute.IsHidden || value;
						flag &= property.CurrentPartModifier.DesignerPartProperties.IsVisible(property.Field, value);
						property.Row.Visible = flag;
					}
					if (field != null)
					{
						break;
					}
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_tempPartModifiers = new List<PartModifierData>();
			_transform = GetComponent<RectTransform>();
			_designerSettings = Game.Instance.Settings.Game.Designer;
			InitializeConfigurablePropertiesList();
			InitializeHeaderText();
			base.Designer.CraftStructureChanged += OnCraftStructureChanged;
			CreateUI();
		}

		protected virtual void Update()
		{
			if (CurrentPartModifier != null)
			{
				CurrentPartModifier.DesignerPartProperties.OnUpdate();
			}
		}

		private static List<ConfigurableProperty> GetConfigurablePropertiesList(Type modifierType)
		{
			List<ConfigurableProperty> list = new List<ConfigurableProperty>();
			Type type = modifierType;
			while (type != null)
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					DesignerPropertyAttribute designerPropertyAttribute = (DesignerPropertyAttribute)fieldInfo.GetCustomAttributes(typeof(DesignerPropertyAttribute), inherit: true).FirstOrDefault();
					if (designerPropertyAttribute != null)
					{
						Type type2 = designerPropertyAttribute.GetType();
						if (type2 == typeof(DesignerPropertySliderAttribute))
						{
							list.Add(new SliderProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertyToggleButtonAttribute))
						{
							list.Add(new ToggleButtonProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertySpinnerAttribute))
						{
							list.Add(new SpinnerProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertyLabelAttribute))
						{
							list.Add(new LabelProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertyCenterButtonAttribute))
						{
							list.Add(new CenterButtonProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertyTextInputAttribute))
						{
							list.Add(new TextInputProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertyColorSlidersAttribute))
						{
							list.Add(new ColorSlidersProperty(fieldInfo, designerPropertyAttribute));
						}
						else if (type2 == typeof(DesignerPropertyUpgradeAttribute))
						{
							list.Add(new UpgradeProperty(fieldInfo, designerPropertyAttribute));
						}
						else
						{
							list.Add(new ConfigurableProperty(fieldInfo, designerPropertyAttribute));
						}
					}
				}
				type = type.BaseType;
			}
			return list.OrderBy((ConfigurableProperty x) => x.Attribute.Order).ToList();
		}

		private HeaderScript CreateHeaderElement(string headerText, bool startCollapsed)
		{
			XmlElement xmlElement = (base.Flyout as PartPropertiesFlyoutScript).CloneTemplateElement("template-header", base.transform);
			TextMeshProUGUI elementByInternalId = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			elementByInternalId.text = headerText;
			if (_headerLabel == null)
			{
				_headerLabel = elementByInternalId;
				HeaderDeleteButton = xmlElement.GetElementByInternalId<Button>("delete-button");
			}
			HeaderScript headerScript = xmlElement.gameObject.AddComponent<HeaderScript>();
			headerScript.Initialize(xmlElement);
			headerScript.StartCollapsed = startCollapsed;
			return headerScript;
		}

		private void CreateUI()
		{
			PartPropertiesFlyoutScript flyout = base.Flyout as PartPropertiesFlyoutScript;
			IInAppPurchaseFeature inAppFeature = Game.Instance.InAppPurchases.Features.PartProperties(base.ModifierType);
			if (!inAppFeature.Unlocked)
			{
				CreateUpgradeElement("Upgrade to the " + inAppFeature.ProductName + " to unlock these settings.", delegate
				{
					Game.Instance.InAppPurchases.CreatePurchaseDialog(inAppFeature.ProductId);
				});
			}
			foreach (ConfigurableProperty property in _properties)
			{
				if (!string.IsNullOrEmpty(property.Attribute.Header))
				{
					CreateHeaderElement(property.Attribute.Header, property.Attribute.HeaderCollapsed);
				}
				property.CreateUI(base.gameObject, flyout);
				property.Row?.SetTooltip(property.Attribute.Tooltip);
				if (!inAppFeature.Unlocked)
				{
					property.SetReadOnly();
				}
			}
		}

		private void CreateUpgradeElement(string text, Action onClick)
		{
			XmlElement xmlElement = (base.Flyout as PartPropertiesFlyoutScript).CloneTemplateElement("template-upgrade", base.transform);
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("label").text = text;
			xmlElement.GetElementByInternalId("button").AddOnClickEvent(onClick);
		}

		private void InitializeConfigurablePropertiesList()
		{
			if (!_typePropertiesMap.TryGetValue(base.ModifierType, out var value))
			{
				value = new Dictionary<int, List<ConfigurableProperty>>();
				_typePropertiesMap.Add(base.ModifierType, value);
			}
			if (!value.TryGetValue(base.ModifierIndex, out var value2))
			{
				value2 = GetConfigurablePropertiesList(base.ModifierType);
				value.Add(base.ModifierIndex, value2);
			}
			_properties = value2;
		}

		private void InitializeHeaderText()
		{
			if (base.DesignerAttribute != null && !string.IsNullOrEmpty(base.DesignerAttribute.HeaderText))
			{
				CreateHeaderElement(base.DesignerAttribute.HeaderText, base.DesignerAttribute.HeaderCollapsed);
			}
		}

		private void OnCraftStructureChanged()
		{
			if (base.IsVisible)
			{
				RefreshUI();
			}
		}
	}
}
