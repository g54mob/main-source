using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;

namespace Assets.Scripts.Design.Tutorials.Steps.PartChanges
{
	public class PartPropertyChange : ITutorialStepPartChange
	{
		private FieldInfo _fieldInfo;

		private PropertyInfo _propertyInfo;

		public Type ModifierType { get; }

		public object NewValue { get; }

		public string NewValueDisplayLabel { get; }

		public int PartId { get; }

		public object PreviousValue { get; }

		public DesignerPropertyAttribute PropertyAttribute { get; }

		public string PropertyName { get; }

		public PartPropertyChange(int partId, Type modifierType, string propertyName, object previousValue, object newValue, string newValueDisplayLabel)
		{
			PartId = partId;
			ModifierType = modifierType;
			PropertyName = propertyName;
			PreviousValue = previousValue;
			NewValue = newValue;
			NewValueDisplayLabel = newValueDisplayLabel;
			Type type = ModifierType;
			while (type != null)
			{
				_fieldInfo = type.GetField(PropertyName, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (_fieldInfo != null)
				{
					break;
				}
				_propertyInfo = type.GetProperty(PropertyName, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (_propertyInfo != null)
				{
					break;
				}
				type = type.BaseType;
			}
			if (_fieldInfo == null && _propertyInfo == null)
			{
				throw new ArgumentException("Property or field '" + PropertyName + "' not found in type '" + ModifierType.FullName + "' or any of its base classes.");
			}
			PropertyAttribute = ((MemberInfo)(((object)_fieldInfo) ?? ((object)_propertyInfo)))?.GetCustomAttribute<DesignerPropertyAttribute>(inherit: true);
			if (PropertyAttribute == null)
			{
				throw new ArgumentException("DesignerPropertyAttribute not found on property or field '" + PropertyName + "' in type '" + ModifierType.FullName + "'.");
			}
		}

		public static PartPropertyChange Create<TModifier, TProperty>(TutorialStepBuilderContext context, string partName, string propertyName, TProperty previousValue, TProperty newValue, string newValueDisplayLabel)
		{
			return new PartPropertyChange(context.GetPartIdByName(partName), typeof(TModifier), propertyName, previousValue, newValue, newValueDisplayLabel);
		}

		public static PartPropertyChange Create<TModifier, TProperty>(TutorialStepBuilderContext context, int partId, string propertyName, TProperty previousValue, TProperty newValue, string newValueDisplayLabel)
		{
			return new PartPropertyChange(partId, typeof(TModifier), propertyName, previousValue, newValue, newValueDisplayLabel);
		}

		public void Apply(AircraftData craft)
		{
			SetValue(craft, NewValue);
		}

		public bool IsComplete(AircraftData craft)
		{
			PartModifierData modifier = craft.Assembly.GetPartById(PartId)?.GetModifier(ModifierType);
			return IsComplete(modifier);
		}

		public bool IsComplete(PartModifierData modifier)
		{
			if (modifier == null)
			{
				return false;
			}
			object obj = null;
			if (_fieldInfo != null)
			{
				obj = _fieldInfo.GetValue(modifier);
			}
			else if (_propertyInfo != null)
			{
				obj = _propertyInfo.GetValue(modifier);
			}
			if (obj == null && NewValue == null)
			{
				return true;
			}
			if (obj != null && obj.Equals(NewValue))
			{
				return true;
			}
			return false;
		}

		public void Revert(AircraftData craft)
		{
			SetValue(craft, PreviousValue);
		}

		private void SetValue(AircraftData craft, object value)
		{
			PartModifierData partModifierData = craft.Assembly.GetPartById(PartId)?.GetModifier(ModifierType);
			if (partModifierData == null)
			{
				return;
			}
			List<PartModifierData> value2;
			using (CollectionPool<List<PartModifierData>, PartModifierData>.Get(out value2))
			{
				SymmetryUtility.GetSymmetricModifiers(partModifierData, includeCurrentModifier: false, value2);
				List<(PartModifierData, object)> value3;
				using (CollectionPool<List<(PartModifierData, object)>, (PartModifierData, object)>.Get(out value3))
				{
					value3.Add((partModifierData, value));
					foreach (PartModifierData item in value2)
					{
						value3.Add((item, item.GetSymmetricValue(PropertyName, value2.Count + 1, partModifierData, value)));
					}
					foreach (var item2 in value3)
					{
						item2.Item1.OnGenericDesignerPropertyChanging(PropertyName, item2.Item2.ToString());
					}
					foreach (var item3 in value3)
					{
						if (_fieldInfo != null)
						{
							_fieldInfo.SetValue(item3.Item1, item3.Item2);
						}
						else if (_propertyInfo != null)
						{
							_propertyInfo.SetValue(item3.Item1, item3.Item2);
						}
					}
					foreach (var item4 in value3)
					{
						item4.Item1.OnGenericDesignerPropertyChanged(PropertyName, item4.Item2.ToString());
					}
				}
			}
		}
	}
}
