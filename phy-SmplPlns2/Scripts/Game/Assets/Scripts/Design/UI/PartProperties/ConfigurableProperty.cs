using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties.Events;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class ConfigurableProperty : IConfigurableProperty
	{
		public const int MaxChildProperties = 5;

		private List<ConfigurableProperty> _childProperties;

		public DesignerPropertyAttribute Attribute { get; private set; }

		public int ChildIndex { get; private set; }

		public IReadOnlyList<ConfigurableProperty> ChildProperties => _childProperties;

		public object CurrentFieldTarget { get; private set; }

		public PartModifierData CurrentPartModifier { get; private set; }

		public Type FieldType { get; private set; }

		public bool IsList { get; private set; }

		public bool IsListItem { get; private set; }

		public Func<bool> IsVisible { get; private set; }

		public MemberInfo Member { get; private set; }

		public ConfigurableProperty ParentProperty { get; private set; }

		IConfigurableProperty IConfigurableProperty.ParentProperty => ParentProperty;

		public Widget RootWidget { get; protected set; }

		public PartPropertyValueConverter ValueConverter { get; private set; }

		public event EventHandler<ConfigurablePropertyChangedEventArgs> ValueChanged;

		public event EventHandler<ConfigurablePropertyChangedEventArgs> ValueCommitted;

		public ConfigurableProperty(MemberInfo member, DesignerPropertyAttribute attribute)
		{
			Member = member;
			Attribute = attribute;
			if (member is FieldInfo fieldInfo)
			{
				FieldType = fieldInfo.FieldType;
			}
			else
			{
				if (!(member is PropertyInfo propertyInfo))
				{
					throw new ArgumentException("Member must be a FieldInfo or PropertyInfo", "member");
				}
				FieldType = propertyInfo.PropertyType;
			}
			IsList = FieldType.IsArray || (FieldType.IsGenericType && FieldType.GetGenericTypeDefinition() == typeof(List<>));
			IsListItem = false;
			_childProperties = new List<ConfigurableProperty>();
			IsVisible = () => true;
		}

		public void AddChildProperty(ConfigurableProperty property)
		{
			property.ParentProperty = this;
			property.ChildIndex = _childProperties.Count;
			_childProperties.Add(property);
			if (IsList)
			{
				property.IsList = false;
				property.IsListItem = true;
				property.FieldType = (FieldType.IsArray ? FieldType.GetElementType() : FieldType.GenericTypeArguments[0]);
			}
		}

		public ConfigurableProperty Clone()
		{
			ConfigurableProperty configurableProperty = (ConfigurableProperty)Activator.CreateInstance(GetType(), Member, Attribute);
			Clone(configurableProperty);
			return configurableProperty;
		}

		public virtual void CreateUI(Widget parent)
		{
			if (_childProperties.Count == 0)
			{
				Debug.LogWarningFormat("Designer property attribute of type '{0}' is not supported.", Attribute.GetType().FullName);
			}
			else if (!IsList && !string.IsNullOrEmpty(Attribute.Label))
			{
				Widget rootWidget = parent.Context.CreateWidgetFromTemplate("control-header", parent, new XAttribute[1]
				{
					new XAttribute("title", Attribute.Label)
				});
				RootWidget = rootWidget;
			}
		}

		public string GetDefaultLabel()
		{
			string text = ((!string.IsNullOrEmpty(Attribute.Label)) ? Attribute.Label : Member.Name);
			if (IsListItem)
			{
				text += $" {ChildIndex + 1}";
			}
			return text;
		}

		public IEnumerable<(PartModifierData PartModifier, object FieldTarget)> GetSymmetricModifiers(bool includeCurrentModifier)
		{
			if (includeCurrentModifier)
			{
				yield return (PartModifier: CurrentPartModifier, FieldTarget: CurrentFieldTarget);
			}
			PartData part = CurrentPartModifier.Part;
			if (CurrentPartModifier.SymmetryDisabled || part.SymmetryId == 0)
			{
				yield break;
			}
			int modifierTypeIndex = 0;
			Type type = CurrentPartModifier.GetType();
			foreach (PartModifierData modifier in part.Modifiers)
			{
				if (modifier != CurrentPartModifier)
				{
					if (modifier.GetType() == type)
					{
						modifierTypeIndex++;
					}
					continue;
				}
				break;
			}
			if (modifierTypeIndex >= part.Modifiers.Count)
			{
				Debug.LogError("Unable to find the part modifier associated with the configurable property.");
				yield break;
			}
			Assets.Scripts.Craft.Parts.Assembly assembly = part.PartScript.Aircraft.Aircraft.Assembly;
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				assembly.GetOtherSymmetricParts(CurrentPartModifier.Part, value);
				List<PartModifierData> value2;
				using (CollectionPool<List<PartModifierData>, PartModifierData>.Get(out value2))
				{
					foreach (PartData item in value)
					{
						PartModifierData partModifierData = null;
						int num = 0;
						foreach (PartModifierData modifier2 in item.Modifiers)
						{
							if (modifier2.GetType() == type)
							{
								if (num == modifierTypeIndex)
								{
									partModifierData = modifier2;
									break;
								}
								num++;
							}
						}
						if (partModifierData == null)
						{
							Debug.LogError($"Unable to find the symmetric part modifier on part {item.Id} for source part {part.Id} and modifier " + "'" + CurrentPartModifier.GetType().FullName + "'" + ((modifierTypeIndex == 0) ? string.Empty : $" at index {modifierTypeIndex}"));
						}
						else
						{
							value2.Add(partModifierData);
						}
					}
					if (CurrentFieldTarget is PartModifierData)
					{
						foreach (PartModifierData item2 in value2)
						{
							yield return (PartModifier: item2, FieldTarget: item2);
						}
					}
					else if (ParentProperty?.CurrentFieldTarget is PartModifierData)
					{
						foreach (PartModifierData item3 in value2)
						{
							MemberInfo member = ParentProperty.Member;
							object value3;
							if (!(member is FieldInfo fieldInfo))
							{
								if (!(member is PropertyInfo propertyInfo))
								{
									throw new InvalidOperationException("Member must be a FieldInfo or PropertyInfo");
								}
								value3 = propertyInfo.GetValue(item3);
							}
							else
							{
								value3 = fieldInfo.GetValue(item3);
							}
							object obj = value3;
							if (ParentProperty.IsListItem)
							{
								IList list = (IList)obj;
								if (list.Count <= ParentProperty.ChildIndex)
								{
									Debug.LogError($"Unable to find the symmetric part modifier target on part {item3.Part.Id} for source part {part.Id} and modifier " + "'" + CurrentPartModifier.GetType().FullName + "'" + ((modifierTypeIndex == 0) ? string.Empty : $" at index {modifierTypeIndex}") + ". " + $"The list index '{ParentProperty.ChildIndex}' is out of bounds '{list.Count}'");
									continue;
								}
								obj = list[ParentProperty.ChildIndex];
							}
							if (obj == null)
							{
								Debug.LogError($"Unable to find the symmetric part modifier target on part {item3.Part.Id} for source part {part.Id} and modifier " + "'" + CurrentPartModifier.GetType().FullName + "'" + ((modifierTypeIndex == 0) ? string.Empty : $" at index {modifierTypeIndex}"));
							}
							else
							{
								yield return (PartModifier: item3, FieldTarget: obj);
							}
						}
					}
					else
					{
						Debug.Log("Not Yet Supported: Automatic syncing of symmetric property '" + Member.Name + "' on modifier '" + CurrentPartModifier.GetType().Name + "'");
					}
				}
			}
		}

		public object GetValue()
		{
			if (CurrentFieldTarget == null)
			{
				return null;
			}
			object value;
			if (Member is FieldInfo fieldInfo)
			{
				value = fieldInfo.GetValue(CurrentFieldTarget);
			}
			else
			{
				if (!(Member is PropertyInfo propertyInfo))
				{
					throw new InvalidOperationException("Member must be a FieldInfo or PropertyInfo");
				}
				value = propertyInfo.GetValue(CurrentFieldTarget);
			}
			value = ValueConverter.ConvertFrom(value);
			if (IsListItem)
			{
				IList list = (IList)value;
				value = ((list.Count > ChildIndex) ? list[ChildIndex] : null);
			}
			return value;
		}

		public virtual void OnPropertiesClosed()
		{
		}

		public void RaiseValueCommitted()
		{
			GetDefaultLabel();
			this.ValueCommitted?.Invoke(this, new ConfigurablePropertyChangedEventArgs(GetDefaultLabel()));
		}

		public virtual void RefreshUI()
		{
			if (IsList)
			{
				SetCurrentPartModifier(CurrentPartModifier, CurrentFieldTarget);
				int num = ((IList)((CurrentFieldTarget == null) ? null : GetValue()))?.Count ?? 0;
				{
					foreach (ConfigurableProperty childProperty in ChildProperties)
					{
						bool flag = childProperty.ChildIndex < num;
						childProperty.RootWidget?.SetVisible(flag);
						foreach (ConfigurableProperty childProperty2 in childProperty.ChildProperties)
						{
							childProperty2.RootWidget?.SetVisible(flag);
						}
						if (flag)
						{
							childProperty.RefreshUI();
						}
					}
					return;
				}
			}
			foreach (ConfigurableProperty childProperty3 in ChildProperties)
			{
				childProperty3.RefreshUI();
			}
		}

		public virtual void SetCurrentPartModifier(PartModifierData partModifier, object fieldTarget)
		{
			CurrentPartModifier = partModifier;
			CurrentFieldTarget = fieldTarget;
			if (CurrentPartModifier != null)
			{
				bool flag = !IsList && ChildProperties.Count == 0;
				ValueConverter = (flag ? CurrentPartModifier.GetGenericDesignerPropertyValueConverter(this) : null) ?? PartPropertyValueConverter.Default;
				Func<bool> genericDesignerPropertyVisibilityCallback = CurrentPartModifier.GetGenericDesignerPropertyVisibilityCallback(this);
				if (genericDesignerPropertyVisibilityCallback != null)
				{
					IsVisible = genericDesignerPropertyVisibilityCallback;
				}
			}
			else
			{
				ValueConverter = null;
				IsVisible = () => true;
			}
			if (ChildProperties.Count <= 0)
			{
				return;
			}
			if (!IsList && fieldTarget != null)
			{
				fieldTarget = GetValue();
			}
			foreach (ConfigurableProperty childProperty in ChildProperties)
			{
				childProperty.SetCurrentPartModifier(partModifier, fieldTarget);
			}
		}

		public void SetValue(object value, bool convertType, bool updateSymmetricProperties = true, bool raiseValueChangedEvent = true)
		{
			if (CurrentFieldTarget == null)
			{
				Debug.LogError("Unable to set ConfigurableProperty field. The field target is null.");
				return;
			}
			value = ValueConverter.ConvertTo(value);
			if (convertType)
			{
				value = Convert.ChangeType(value, FieldType);
			}
			PartData part = CurrentPartModifier.Part;
			int symmetricPartCount = ((!updateSymmetricProperties || part.SymmetryId == 0) ? 1 : part.PartScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(part).Count);
			if (IsListItem)
			{
				MemberInfo member = Member;
				IList list;
				if (!(member is FieldInfo fieldInfo))
				{
					if (!(member is PropertyInfo propertyInfo))
					{
						throw new InvalidOperationException("Member must be a FieldInfo or PropertyInfo");
					}
					list = (IList)propertyInfo.GetValue(CurrentFieldTarget);
				}
				else
				{
					list = (IList)fieldInfo.GetValue(CurrentFieldTarget);
				}
				IList list2 = list;
				if (list2.Count <= ChildIndex)
				{
					Debug.LogError($"Unable to set ConfigurableProperty field. The index of the list is out of range. Size: {list2.Count}, Index: {ChildIndex}");
					return;
				}
				list2[ChildIndex] = value;
				if (updateSymmetricProperties)
				{
					foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: false))
					{
						member = Member;
						if (!(member is FieldInfo fieldInfo2))
						{
							if (!(member is PropertyInfo propertyInfo2))
							{
								throw new InvalidOperationException("Member must be a FieldInfo or PropertyInfo");
							}
							list = (IList)propertyInfo2.GetValue(symmetricModifier.FieldTarget);
						}
						else
						{
							list = (IList)fieldInfo2.GetValue(symmetricModifier.FieldTarget);
						}
						IList list3 = list;
						object symmetricValue = symmetricModifier.PartModifier.GetSymmetricValue(Member.Name, symmetricPartCount, CurrentPartModifier, value);
						list3[ChildIndex] = symmetricValue;
					}
				}
			}
			else if (Member is FieldInfo fieldInfo3)
			{
				fieldInfo3.SetValue(CurrentFieldTarget, value);
				if (updateSymmetricProperties)
				{
					foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: false))
					{
						object symmetricValue2 = symmetricModifier2.PartModifier.GetSymmetricValue(fieldInfo3.Name, symmetricPartCount, CurrentPartModifier, value);
						fieldInfo3.SetValue(symmetricModifier2.FieldTarget, symmetricValue2);
					}
				}
			}
			else
			{
				if (!(Member is PropertyInfo propertyInfo3))
				{
					throw new InvalidOperationException("Member must be a FieldInfo or PropertyInfo");
				}
				propertyInfo3.SetValue(CurrentFieldTarget, value);
				if (updateSymmetricProperties)
				{
					foreach (var symmetricModifier3 in GetSymmetricModifiers(includeCurrentModifier: false))
					{
						object symmetricValue3 = symmetricModifier3.PartModifier.GetSymmetricValue(propertyInfo3.Name, symmetricPartCount, CurrentPartModifier, value);
						propertyInfo3.SetValue(symmetricModifier3.FieldTarget, symmetricValue3);
					}
				}
			}
			if (raiseValueChangedEvent)
			{
				RaiseValueChanged();
			}
		}

		protected Widget CreateWidgetFromTemplate(string templateID, Widget parent)
		{
			string value = Attribute?.Tooltip;
			XAttribute[] instanceAttributes = (string.IsNullOrEmpty(value) ? null : new XAttribute[1]
			{
				new XAttribute("tooltip", value)
			});
			Widget widget = parent.Context.CreateWidgetFromTemplate(templateID, parent, instanceAttributes);
			if (Device.IsDemoBuild)
			{
				PartModifierDesignerHeaderAttribute partModifierDesignerHeaderAttribute = (PartModifierDesignerHeaderAttribute)(Member?.DeclaringType?.GetCustomAttributes(typeof(PartModifierDesignerHeaderAttribute), inherit: false).FirstOrDefault());
				if (partModifierDesignerHeaderAttribute != null && !partModifierDesignerHeaderAttribute.AllowInDemo)
				{
					widget.AddClass("demo");
				}
			}
			return widget;
		}

		protected void RaiseValueChanged()
		{
			GetDefaultLabel();
			this.ValueChanged?.Invoke(this, new ConfigurablePropertyChangedEventArgs(GetDefaultLabel()));
		}

		private void Clone(ConfigurableProperty clone)
		{
			foreach (ConfigurableProperty childProperty in ChildProperties)
			{
				ConfigurableProperty configurableProperty = (ConfigurableProperty)Activator.CreateInstance(childProperty.GetType(), childProperty.Member, childProperty.Attribute);
				clone.AddChildProperty(configurableProperty);
				childProperty.Clone(configurableProperty);
			}
		}
	}
}
