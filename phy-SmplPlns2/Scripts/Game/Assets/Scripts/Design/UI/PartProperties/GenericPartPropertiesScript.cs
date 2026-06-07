using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties.Events;
using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class GenericPartPropertiesScript : PartPropertiesScript, IGenericPartProperties
	{
		private static Dictionary<Type, List<ConfigurableProperty>> _typePropertiesMap = new Dictionary<Type, List<ConfigurableProperty>>();

		private bool _created;

		private PartPropertiesHeaderScript _header;

		private uint _lastSymmetryId;

		private List<ConfigurableProperty> _properties;

		private bool _queueRefresh;

		public PartModifierData CurrentPartModifier { get; private set; }

		public PartPropertiesHeaderScript Header => _header;

		public Type ModifierType { get; private set; }

		public Widget Widget { get; private set; }

		public GenericPartPropertiesScript(Type modifierType)
		{
			ModifierType = modifierType;
		}

		public static GenericPartPropertiesScript AddComponent(GameObject obj, Type modifierType)
		{
			bool activeSelf = obj.activeSelf;
			if (activeSelf)
			{
				obj.SetActive(value: false);
			}
			GenericPartPropertiesScript genericPartPropertiesScript = obj.AddComponent<GenericPartPropertiesScript>();
			genericPartPropertiesScript.ModifierType = modifierType;
			if (activeSelf)
			{
				obj.SetActive(value: true);
			}
			return genericPartPropertiesScript;
		}

		public static bool AlreadyHasPartPropertiesScripts(Type modifierType)
		{
			return _typePropertiesMap.ContainsKey(modifierType);
		}

		public static bool NeedsPartPropertiesScript(Type modifierType)
		{
			if (_typePropertiesMap.ContainsKey(modifierType))
			{
				return true;
			}
			List<ConfigurableProperty> configurablePropertiesList = GetConfigurablePropertiesList(modifierType);
			if (configurablePropertiesList.Count > 0)
			{
				_typePropertiesMap.Add(modifierType, configurablePropertiesList);
				return true;
			}
			return false;
		}

		public IConfigurableProperty GetProperty(string propertyName)
		{
			foreach (ConfigurableProperty property in _properties)
			{
				if (property.Member.Name == propertyName)
				{
					return property;
				}
			}
			return null;
		}

		public T GetProperty<T>(string propertyName) where T : class, IConfigurableProperty
		{
			return GetProperty(propertyName) as T;
		}

		public virtual void Initialize(Widget widget)
		{
			Widget = widget;
			InitializeConfigurablePropertiesList();
			InitializeHeaderText();
		}

		public void MarkAsFirst(bool first)
		{
		}

		public override void OnPartDeselected(PartScript part)
		{
			foreach (ConfigurableProperty property in _properties)
			{
				property.SetCurrentPartModifier(null, null);
			}
			CurrentPartModifier?.OnGenericDesignerPropertiesPartDeselected();
			CurrentPartModifier = null;
			_header.SetPartModifier(null);
		}

		public override bool OnPartSelected(PartScript part, PartModifierScript modifierScript)
		{
			PartModifierData partModifier = modifierScript.PartModifier;
			if (partModifier.GetType() != ModifierType)
			{
				return false;
			}
			if (!_created)
			{
				CreateUI();
			}
			object fieldTarget = partModifier;
			partModifier.OnGenericDesignerPropertiesVisible(this);
			CurrentPartModifier = partModifier;
			_header.SetPartModifier(null);
			_lastSymmetryId = 0u;
			foreach (ConfigurableProperty property in _properties)
			{
				property.SetCurrentPartModifier(partModifier, fieldTarget);
			}
			_queueRefresh = true;
			return true;
		}

		public override void OnPropertiesClosed()
		{
			base.OnPropertiesClosed();
			foreach (ConfigurableProperty property in _properties)
			{
				property.OnPropertiesClosed();
			}
			CurrentPartModifier?.OnGenericDesignerPropertiesClosed();
		}

		public override void OnPropertiesOpened()
		{
			base.OnPropertiesOpened();
			_queueRefresh = true;
			CurrentPartModifier?.OnGenericDesignerPropertiesVisible(this);
		}

		public void RefreshUI()
		{
			_queueRefresh = false;
			foreach (ConfigurableProperty property in _properties)
			{
				Widget rootWidget = property.RootWidget;
				if ((object)rootWidget != null)
				{
					rootWidget.Visible = property.IsVisible();
				}
				property.RefreshUI();
			}
		}

		public void SetModifierHeaderText(string text)
		{
			_header.LabelText = text;
		}

		public void SetPropertyStatus(string propertyName, IGenericPartProperties.PropertyStatus status)
		{
			foreach (ConfigurableProperty property in _properties)
			{
				if (property.Member.Name == propertyName)
				{
					switch (status)
					{
					case IGenericPartProperties.PropertyStatus.Hidden:
						property.RootWidget.Visible = false;
						break;
					case IGenericPartProperties.PropertyStatus.Visible:
						property.RootWidget.Visible = true;
						break;
					}
				}
			}
		}

		protected virtual void Update()
		{
			if (CurrentPartModifier != null)
			{
				CurrentPartModifier.OnGenericDesignerPropertiesUpdate(this);
				if (_lastSymmetryId != CurrentPartModifier.Part.SymmetryId)
				{
					_lastSymmetryId = CurrentPartModifier.Part.SymmetryId;
					_header.SetPartModifier((_lastSymmetryId != 0) ? CurrentPartModifier : null);
				}
				if (_queueRefresh)
				{
					RefreshUI();
				}
			}
		}

		private static ConfigurableProperty AddPropertyToList(List<ConfigurableProperty> list, MemberInfo member, DesignerPropertyAttribute attribute, Func<MemberInfo, DesignerPropertyAttribute, ConfigurableProperty> createProperty)
		{
			Type type;
			if (member is FieldInfo fieldInfo)
			{
				type = fieldInfo.FieldType;
			}
			else
			{
				if (!(member is PropertyInfo propertyInfo))
				{
					throw new ArgumentException("Member must be a FieldInfo or PropertyInfo", "member");
				}
				type = propertyInfo.PropertyType;
			}
			if (attribute.SupportsLists && (type.IsArray || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))))
			{
				ConfigurableProperty configurableProperty = new ConfigurableProperty(member, attribute);
				for (int i = 0; i < 5; i++)
				{
					configurableProperty.AddChildProperty(createProperty(member, attribute));
				}
				list.Add(configurableProperty);
				return configurableProperty;
			}
			ConfigurableProperty configurableProperty2 = createProperty(member, attribute);
			list.Add(configurableProperty2);
			return configurableProperty2;
		}

		private static List<ConfigurableProperty> ClonePropertyList(IReadOnlyList<ConfigurableProperty> source)
		{
			List<ConfigurableProperty> list = new List<ConfigurableProperty>(source.Count);
			foreach (ConfigurableProperty item in source)
			{
				list.Add(item.Clone());
			}
			return list;
		}

		private static List<ConfigurableProperty> GetConfigurablePropertiesList(Type modifierType)
		{
			List<ConfigurableProperty> list = new List<ConfigurableProperty>();
			Type type = modifierType;
			while (type != null)
			{
				MemberInfo[] members = type.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MemberInfo memberInfo in members)
				{
					if (memberInfo.MemberType != MemberTypes.Field && memberInfo.MemberType != MemberTypes.Property)
					{
						continue;
					}
					DesignerPropertyAttribute designerPropertyAttribute = (DesignerPropertyAttribute)memberInfo.GetCustomAttributes(typeof(DesignerPropertyAttribute), inherit: true).FirstOrDefault();
					if (designerPropertyAttribute == null)
					{
						continue;
					}
					Type type2 = designerPropertyAttribute.GetType();
					if (type2 == typeof(DesignerPropertySliderAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new SliderProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyToggleButtonAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new ToggleButtonProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertySpinnerAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new SpinnerProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyTextSpinnerAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new TextSpinnerProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyLabelAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new LabelProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyTextInputAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new TextProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyButtonAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new ButtonProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyVectorAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => VectorProperty.Create(m, a));
					}
					else if (type2 == typeof(DesignerPropertyPartIdAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new SelectPartProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyColorAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new ColorProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyTextureAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new TextureProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyCustomWidgetAttribute))
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new CustomWidgetProperty(m, a));
					}
					else if (type2 == typeof(DesignerPropertyClassAttribute))
					{
						ConfigurableProperty configurableProperty = AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new ConfigurableProperty(m, a));
						Type type3 = (memberInfo as FieldInfo)?.FieldType ?? (memberInfo as PropertyInfo)?.PropertyType;
						List<ConfigurableProperty> configurablePropertiesList = GetConfigurablePropertiesList((!configurableProperty.IsList) ? type3 : (type3.IsArray ? type3.GetElementType() : type3.GenericTypeArguments[0]));
						if (configurableProperty.ChildProperties.Count > 0)
						{
							foreach (ConfigurableProperty childProperty in configurableProperty.ChildProperties)
							{
								foreach (ConfigurableProperty item in ClonePropertyList(configurablePropertiesList))
								{
									childProperty.AddChildProperty(item);
								}
							}
							continue;
						}
						foreach (ConfigurableProperty item2 in configurablePropertiesList)
						{
							configurableProperty.AddChildProperty(item2);
						}
					}
					else
					{
						AddPropertyToList(list, memberInfo, designerPropertyAttribute, (MemberInfo m, DesignerPropertyAttribute a) => new ConfigurableProperty(m, a));
					}
				}
				type = type.BaseType;
			}
			return list.OrderBy((ConfigurableProperty x) => x.Attribute.Order).ToList();
		}

		private void CreateHeaderElement(GameObject parent, string headerText, bool collapsed)
		{
			Widget widget = Widget.Context.CreateWidgetFromTemplate("control-header", Widget);
			widget.FindWidget<TextWidget>("label-text").Text = headerText;
			if (collapsed)
			{
				widget.GetComponentInChildren<HeaderScript>().StartCollapsed = collapsed;
			}
		}

		private void CreateUI()
		{
			_created = true;
			foreach (ConfigurableProperty property in _properties)
			{
				CreateUI(property);
			}
		}

		private void CreateUI(ConfigurableProperty property)
		{
			if (!string.IsNullOrEmpty(property.Attribute.Header))
			{
				CreateHeaderElement(base.gameObject, property.Attribute.Header, property.Attribute.HeaderCollapsed);
			}
			property.CreateUI(Widget);
			property.ValueCommitted += delegate(object s, ConfigurablePropertyChangedEventArgs e)
			{
				RefreshPropertyVisibilities();
				base.Designer.Designer.CreateUndoStepForSelectedPart(e.PropertyName);
			};
			foreach (ConfigurableProperty childProperty in property.ChildProperties)
			{
				CreateUI(childProperty);
			}
		}

		private void InitializeConfigurablePropertiesList()
		{
			if (!_typePropertiesMap.TryGetValue(ModifierType, out var value))
			{
				value = GetConfigurablePropertiesList(ModifierType);
				if (value.Count > 0)
				{
					_typePropertiesMap.Add(ModifierType, value);
				}
			}
			else
			{
				value = ClonePropertyList(value);
			}
			_properties = value;
		}

		private void InitializeHeaderText()
		{
			PartModifierDesignerHeaderAttribute partModifierDesignerHeaderAttribute = (PartModifierDesignerHeaderAttribute)ModifierType.GetCustomAttributes(typeof(PartModifierDesignerHeaderAttribute), inherit: false).FirstOrDefault();
			_header = Widget.FindWidget("header").GetComponentInChildren<PartPropertiesHeaderScript>();
			SetModifierHeaderText((partModifierDesignerHeaderAttribute != null && !string.IsNullOrEmpty(partModifierDesignerHeaderAttribute.HeaderText)) ? partModifierDesignerHeaderAttribute.HeaderText : ModifierType.Name);
		}

		private void RefreshPropertyVisibilities()
		{
			foreach (ConfigurableProperty property in _properties)
			{
				Widget rootWidget = property.RootWidget;
				if ((object)rootWidget != null)
				{
					rootWidget.Visible = property.IsVisible();
				}
			}
		}
	}
}
