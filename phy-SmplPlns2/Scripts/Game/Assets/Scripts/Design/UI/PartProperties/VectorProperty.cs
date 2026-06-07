using System;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public abstract class VectorProperty : ConfigurableProperty
	{
		public DesignerPropertyVectorAttribute VectorAttribute => (DesignerPropertyVectorAttribute)base.Attribute;

		public VectorProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public static VectorProperty Create(MemberInfo member, DesignerPropertyAttribute attribute)
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
			return (VectorProperty)typeof(VectorProperty<>).MakeGenericType(type).GetConstructor(new Type[2]
			{
				typeof(MemberInfo),
				typeof(DesignerPropertyAttribute)
			}).Invoke(new object[2] { member, attribute });
		}
	}
	public class VectorProperty<TVector> : VectorProperty
	{
		private VectorControl<TVector> _vectorControl;

		public VectorProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			DesignerPropertyVectorAttribute vectorAttribute = base.VectorAttribute;
			string templateID = (vectorAttribute.UseInlineLabel ? "control-vector-input-inline-label" : "control-vector-input-label");
			base.RootWidget = CreateWidgetFromTemplate(templateID, parent);
			base.RootWidget.name = GetDefaultLabel();
			_vectorControl = new VectorControl<TVector>(base.RootWidget);
			VectorControl<TVector> vectorControl = _vectorControl;
			vectorControl.OnValueChanging = (Action<TVector>)Delegate.Combine(vectorControl.OnValueChanging, new Action<TVector>(OnValueChanging));
			VectorControl<TVector> vectorControl2 = _vectorControl;
			vectorControl2.OnValueChanged = (Action<TVector>)Delegate.Combine(vectorControl2.OnValueChanged, new Action<TVector>(OnValueChanged));
			_vectorControl.StepValue = vectorAttribute.StepValue;
			_vectorControl.MinValue = vectorAttribute.MinValue;
			_vectorControl.MaxValue = vectorAttribute.MaxValue;
			_vectorControl.AllowManualEntry = vectorAttribute.AllowManualEntry;
			_vectorControl.ManualEntryIgnoresRange = vectorAttribute.ManualEntryIgnoresRange;
			_vectorControl.ValueFormatter = (object x) => base.CurrentPartModifier?.GetGenericDesignerPropertyVectorValueLabel(base.Member.Name, x);
			if (vectorAttribute.ButtonRepeatDelay != 0f)
			{
				_vectorControl.ButtonDownRepeatDelay = vectorAttribute.ButtonRepeatDelay;
			}
			if (vectorAttribute.ButtonRepeatTime != 0f)
			{
				_vectorControl.ButtonDownRepeatTime = vectorAttribute.ButtonRepeatTime;
			}
		}

		public override void RefreshUI()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				_vectorControl.Label = currentPartModifier.GetGenericDesignerPropertyNameLabel(this);
				_vectorControl.Value = (TVector)GetValue();
			}
		}

		private void OnValueChanged(TVector vector)
		{
			if (base.CurrentPartModifier == null)
			{
				return;
			}
			SetValue(vector, convertType: false);
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, _vectorControl.GetValueAsNumericString(vector));
			}
			RaiseValueCommitted();
		}

		private void OnValueChanging(TVector vector)
		{
			if (base.CurrentPartModifier == null)
			{
				return;
			}
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, _vectorControl.GetValueAsNumericString(vector));
			}
		}
	}
}
