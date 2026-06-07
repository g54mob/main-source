using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Craft.Parts.Styles;

namespace ModApi.Design.PartProperties
{
	public interface IDesignerPartPropertiesModifierInterface
	{
		IDesignerPartProperties Manager { get; }

		ICenterButtonProperty GetCenterButtonProperty<TField>(Expression<Func<TField>> fieldSelector);

		FieldInfo GetField<TValue>(Expression<Func<TValue>> fieldSelector);

		ILabelProperty GetLabelProperty<TField>(Expression<Func<TField>> fieldSelector);

		IConfigurableProperty GetProperty<TField>(Expression<Func<TField>> fieldSelector);

		IConfigurableProperty GetProperty<TObject>(TObject objectInstance, string fieldName);

		ISliderProperty GetSliderProperty<TField>(Expression<Func<TField>> fieldSelector);

		ISpinnerProperty GetSpinnerProperty<TField>(Expression<Func<TField>> fieldSelector);

		IToggleButtonProperty GetToggleButtonProperty<TField>(Expression<Func<TField>> fieldSelector);

		void OnActivated(Action action);

		void OnAnyPropertyChanged(Action action);

		void OnCenterButtonActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ICenterButtonProperty> action);

		void OnDeactivated(Action action);

		void OnHeaderLabelRequested(Func<string> headerLabel);

		void OnLabelActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ILabelProperty> action);

		void OnPartMaterialsChanged(Action action);

		void OnPartStyleChanged(StyleChangedDelegate<IPartStyle> action);

		void OnPartTextureStyleChanged(StyleChangedDelegate<IPartTextureStyle> action);

		void OnPropertyActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<IConfigurableProperty> action);

		void OnPropertyChanged<TValue>(Expression<Func<TValue>> fieldSelector, Action<TValue, TValue> action);

		void OnRefreshUI(Action action);

		void OnSliderActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ISliderProperty> action);

		void OnSpinnerActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ISpinnerProperty> action);

		void OnSpinnerValuesRequested<TValue>(Expression<Func<TValue>> fieldSelector, Action<List<string>> updateAction);

		void OnToggleButtonActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<IToggleButtonProperty> action);

		void OnValueLabelRequested<TValue>(Expression<Func<TValue>> fieldSelector, Func<TValue, string> label);

		void OnVisibilityRequested<TValue>(Expression<Func<TValue>> fieldSelector, Func<bool, bool> visibilityTest);
	}
}
