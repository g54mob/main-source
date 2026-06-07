using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using UnityEngine;

namespace ModApi.Design.PartProperties
{
	public class PartModifierDataDesignerPartProperties : IDesignerPartPropertiesModifierInterface, IDesignerPartPropertiesDesignerInterface, IDisposable
	{
		private static List<FieldInfo> _invalidFields;

		private static List<FieldInfo> _validFields;

		private Action _activatedActions;

		private Action _anyPropertyChangedActions;

		private Action _deactivatedActions;

		private Func<string> _headerLabelFunction;

		private Action _onPartMaterialsChangedActions;

		private StyleChangedDelegate<IPartStyle> _onPartStyleChangedActions;

		private StyleChangedDelegate<IPartTextureStyle> _onPartTextureStyleChangedActions;

		private Dictionary<FieldInfo, Delegate> _propertyActivatedActions;

		private Dictionary<FieldInfo, Delegate> _propertyChangedActions;

		private Action _refreshUIActions;

		private Dictionary<FieldInfo, Delegate> _textSpinnerValuesActions;

		private Action _updateActions;

		private Dictionary<FieldInfo, Delegate> _valueLabelActions;

		private Dictionary<FieldInfo, Func<bool, bool>> _visibleActions;

		public IDesignerPartProperties Manager { get; private set; }

		public PartModifierData PartModifierData { get; private set; }

		public PartModifierDataDesignerPartProperties(PartModifierData modifier)
		{
			PartModifierData = modifier;
		}

		public void Dispose()
		{
			if (_onPartMaterialsChangedActions != null)
			{
				ITheme theme = PartModifierData.Part?.ThemeData?.Theme;
				if (theme != null)
				{
					theme.PartMaterialsChanged -= OnPartMaterialsChanged;
				}
			}
		}

		public ICenterButtonProperty GetCenterButtonProperty<TField>(Expression<Func<TField>> fieldSelector)
		{
			return GetProperty<ICenterButtonProperty, TField>(fieldSelector);
		}

		public FieldInfo GetField<TValue>(Expression<Func<TValue>> fieldSelector)
		{
			FieldInfo field = Utilities.GetField(fieldSelector);
			if (!ValidatePropertyField(field))
			{
				Debug.LogError("The field selector specified a field that was not associated with a designer property attribute.");
				return null;
			}
			return field;
		}

		string IDesignerPartPropertiesDesignerInterface.GetHeaderLabel()
		{
			return _headerLabelFunction?.Invoke();
		}

		public ILabelProperty GetLabelProperty<TField>(Expression<Func<TField>> fieldSelector)
		{
			return GetProperty<ILabelProperty, TField>(fieldSelector);
		}

		public IConfigurableProperty GetProperty<TField>(Expression<Func<TField>> fieldSelector)
		{
			return GetProperty<IConfigurableProperty, TField>(fieldSelector);
		}

		public IConfigurableProperty GetProperty<TObject>(TObject objectInstance, string fieldName)
		{
			if (Manager == null)
			{
				return null;
			}
			FieldInfo field = typeof(TObject).GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				return null;
			}
			return Manager.GetProperty<IConfigurableProperty>(field);
		}

		public ISliderProperty GetSliderProperty<TField>(Expression<Func<TField>> fieldSelector)
		{
			return GetProperty<ISliderProperty, TField>(fieldSelector);
		}

		public ISpinnerProperty GetSpinnerProperty<TField>(Expression<Func<TField>> fieldSelector)
		{
			return GetProperty<ISpinnerProperty, TField>(fieldSelector);
		}

		public IToggleButtonProperty GetToggleButtonProperty<TField>(Expression<Func<TField>> fieldSelector)
		{
			return GetProperty<IToggleButtonProperty, TField>(fieldSelector);
		}

		string IDesignerPartPropertiesDesignerInterface.GetValueLabel(FieldInfo field, object value)
		{
			if (_valueLabelActions != null && _valueLabelActions.TryGetValue(field, out var value2))
			{
				return (string)value2.DynamicInvoke(value);
			}
			return value?.ToString();
		}

		bool IDesignerPartPropertiesDesignerInterface.IsVisible(FieldInfo field, bool showHiddenFields)
		{
			Func<bool, bool> value = null;
			if (_visibleActions != null && _visibleActions.TryGetValue(field, out value))
			{
				return value(showHiddenFields);
			}
			return true;
		}

		public void OnActivated(Action action)
		{
			if (_activatedActions == null)
			{
				_activatedActions = action;
			}
			else
			{
				_activatedActions = (Action)Delegate.Combine(_activatedActions, action);
			}
		}

		void IDesignerPartPropertiesDesignerInterface.OnActivated(IDesignerPartProperties partPropertiesScript)
		{
			Manager = partPropertiesScript;
			_activatedActions?.Invoke();
		}

		public void OnAnyPropertyChanged(Action action)
		{
			_anyPropertyChangedActions = (Action)Delegate.Combine(_anyPropertyChangedActions, action);
		}

		public void OnCenterButtonActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ICenterButtonProperty> action)
		{
			OnPropertyActivated(fieldSelector, action);
		}

		public void OnDeactivated(Action action)
		{
			if (_deactivatedActions == null)
			{
				_deactivatedActions = action;
			}
			else
			{
				_deactivatedActions = (Action)Delegate.Combine(_deactivatedActions, action);
			}
		}

		void IDesignerPartPropertiesDesignerInterface.OnDeactivated(IDesignerPartProperties partPropertiesScript)
		{
			_deactivatedActions?.Invoke();
			Manager = null;
		}

		public void OnHeaderLabelRequested(Func<string> headerLabel)
		{
			_headerLabelFunction = headerLabel;
		}

		public void OnLabelActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ILabelProperty> action)
		{
			OnPropertyActivated(fieldSelector, action);
		}

		public void OnPartMaterialsChanged(Action action)
		{
			if (_onPartMaterialsChangedActions == null)
			{
				_onPartMaterialsChangedActions = action;
			}
			else
			{
				_onPartMaterialsChangedActions = (Action)Delegate.Combine(_onPartMaterialsChangedActions, action);
			}
			PartModifierData.Part.ThemeData.Theme.PartMaterialsChanged += OnPartMaterialsChanged;
		}

		void IDesignerPartPropertiesDesignerInterface.OnPartMaterialsChanged()
		{
			_onPartMaterialsChangedActions?.Invoke();
		}

		void IDesignerPartPropertiesDesignerInterface.OnPartStyleChanged(IPartStyle previousStyle, IPartStyle newStyle)
		{
			_onPartStyleChangedActions?.Invoke(previousStyle, newStyle);
		}

		public void OnPartStyleChanged(StyleChangedDelegate<IPartStyle> action)
		{
			if (_onPartStyleChangedActions == null)
			{
				_onPartStyleChangedActions = action;
			}
			else
			{
				_onPartStyleChangedActions = (StyleChangedDelegate<IPartStyle>)Delegate.Combine(_onPartStyleChangedActions, action);
			}
		}

		void IDesignerPartPropertiesDesignerInterface.OnPartTextureStyleChanged(IPartTextureStyle previousStyle, IPartTextureStyle newStyle)
		{
			_onPartTextureStyleChangedActions?.Invoke(previousStyle, newStyle);
		}

		public void OnPartTextureStyleChanged(StyleChangedDelegate<IPartTextureStyle> action)
		{
			if (_onPartTextureStyleChangedActions == null)
			{
				_onPartTextureStyleChangedActions = action;
			}
			else
			{
				_onPartTextureStyleChangedActions = (StyleChangedDelegate<IPartTextureStyle>)Delegate.Combine(_onPartTextureStyleChangedActions, action);
			}
		}

		void IDesignerPartPropertiesDesignerInterface.OnPropertyActivated(IConfigurableProperty property)
		{
			if (_propertyActivatedActions != null)
			{
				Delegate value = null;
				if (_propertyActivatedActions.TryGetValue(property.Field, out value))
				{
					value.DynamicInvoke(property);
				}
			}
		}

		public void OnPropertyActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<IConfigurableProperty> action)
		{
			OnPropertyActivated(fieldSelector, (Delegate)action);
		}

		public void OnPropertyChanged<TValue>(Expression<Func<TValue>> fieldSelector, Action<TValue, TValue> action)
		{
			FieldInfo field = GetField(fieldSelector);
			if (!(field == null))
			{
				if (_propertyChangedActions == null)
				{
					_propertyChangedActions = new Dictionary<FieldInfo, Delegate>();
				}
				Delegate value = null;
				if (!_propertyChangedActions.TryGetValue(field, out value))
				{
					_propertyChangedActions.Add(field, action);
				}
				else
				{
					_ = (Action<TValue, TValue>)Delegate.Combine((Action<TValue, TValue>)value, action);
				}
			}
		}

		void IDesignerPartPropertiesDesignerInterface.OnPropertyChanged(FieldInfo field, object newVal, object oldVal)
		{
			if (_propertyChangedActions != null)
			{
				Delegate value = null;
				if (_propertyChangedActions.TryGetValue(field, out value))
				{
					value.DynamicInvoke(newVal, oldVal);
				}
			}
			_anyPropertyChangedActions?.Invoke();
			Manager.UpdateVisibility(null);
		}

		public void OnRefreshUI(Action action)
		{
			if (_refreshUIActions == null)
			{
				_refreshUIActions = action;
			}
			else
			{
				_refreshUIActions = (Action)Delegate.Combine(_refreshUIActions, action);
			}
		}

		void IDesignerPartPropertiesDesignerInterface.OnRefreshUI()
		{
			_refreshUIActions?.Invoke();
			Manager.UpdateVisibility(null);
		}

		public void OnSliderActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ISliderProperty> action)
		{
			OnPropertyActivated(fieldSelector, action);
		}

		public void OnSpinnerActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<ISpinnerProperty> action)
		{
			OnPropertyActivated(fieldSelector, action);
		}

		public void OnSpinnerValuesRequested<TValue>(Expression<Func<TValue>> fieldSelector, Action<List<string>> updateAction)
		{
			FieldInfo field = GetField(fieldSelector);
			if (!(field == null))
			{
				if (_textSpinnerValuesActions == null)
				{
					_textSpinnerValuesActions = new Dictionary<FieldInfo, Delegate>();
				}
				if (!_textSpinnerValuesActions.ContainsKey(field))
				{
					_textSpinnerValuesActions.Add(field, updateAction);
					return;
				}
				Debug.LogErrorFormat("A designer property spinner value provider function was already specified for field '{0}'", field.Name);
			}
		}

		public void OnToggleButtonActivated<TValue>(Expression<Func<TValue>> fieldSelector, Action<IToggleButtonProperty> action)
		{
			OnPropertyActivated(fieldSelector, action);
		}

		void IDesignerPartPropertiesDesignerInterface.OnUpdate()
		{
			_updateActions?.Invoke();
		}

		public void OnUpdate(Action action)
		{
			if (_updateActions == null)
			{
				_updateActions = action;
			}
			else
			{
				_updateActions = (Action)Delegate.Combine(_updateActions, action);
			}
		}

		public void OnValueLabelRequested<TValue>(Expression<Func<TValue>> fieldSelector, Func<TValue, string> label)
		{
			FieldInfo field = GetField(fieldSelector);
			if (!(field == null))
			{
				if (_valueLabelActions == null)
				{
					_valueLabelActions = new Dictionary<FieldInfo, Delegate>();
				}
				if (!_valueLabelActions.ContainsKey(field))
				{
					_valueLabelActions.Add(field, label);
					return;
				}
				Debug.LogErrorFormat("A designer property value label provider function was already specified for field '{0}'", field.Name);
			}
		}

		public void OnVisibilityRequested<TValue>(Expression<Func<TValue>> fieldSelector, Func<bool, bool> visibilityTest)
		{
			OnVisibilityRequested(GetField(fieldSelector), visibilityTest);
		}

		void IDesignerPartPropertiesDesignerInterface.SetVisible(FieldInfo field, bool visible)
		{
			OnVisibilityRequested(field, (bool showHidden) => visible);
		}

		void IDesignerPartPropertiesDesignerInterface.UpdateSpinnerValues(FieldInfo field, List<string> currentValues)
		{
			if (_textSpinnerValuesActions != null)
			{
				Delegate value = null;
				if (_textSpinnerValuesActions.TryGetValue(field, out value))
				{
					value.DynamicInvoke(currentValues);
				}
			}
		}

		private static bool ValidatePropertyField(FieldInfo field)
		{
			if (_validFields == null)
			{
				_validFields = new List<FieldInfo>();
			}
			if (_validFields.Contains(field))
			{
				return true;
			}
			if (_invalidFields == null)
			{
				_invalidFields = new List<FieldInfo>();
			}
			if (_invalidFields.Contains(field))
			{
				return false;
			}
			bool num = field.GetCustomAttributes(typeof(DesignerPropertyAttribute), inherit: true).Length == 1;
			if (num)
			{
				_validFields.Add(field);
				return num;
			}
			_invalidFields.Add(field);
			return num;
		}

		private TProperty GetProperty<TProperty, TField>(Expression<Func<TField>> fieldSelector) where TProperty : class, IConfigurableProperty
		{
			if (Manager == null)
			{
				return null;
			}
			FieldInfo field = GetField(fieldSelector);
			if (field == null)
			{
				return null;
			}
			return Manager.GetProperty<TProperty>(field);
		}

		private void OnPartMaterialsChanged(object sender, EventArgs e)
		{
			_onPartMaterialsChangedActions?.Invoke();
		}

		private void OnPropertyActivated<TValue>(Expression<Func<TValue>> fieldSelector, Delegate action)
		{
			FieldInfo field = GetField(fieldSelector);
			if (!(field == null))
			{
				if (_propertyActivatedActions == null)
				{
					_propertyActivatedActions = new Dictionary<FieldInfo, Delegate>();
				}
				if (!_propertyActivatedActions.ContainsKey(field))
				{
					_propertyActivatedActions.Add(field, action);
					return;
				}
				Debug.LogErrorFormat("A designer property activated action was already specified for field '{0}'", field.Name);
			}
		}

		private void OnVisibilityRequested(FieldInfo field, Func<bool, bool> visibilityTest)
		{
			if (!(field == null))
			{
				if (_visibleActions == null)
				{
					_visibleActions = new Dictionary<FieldInfo, Func<bool, bool>>();
				}
				_visibleActions[field] = visibilityTest;
			}
		}
	}
}
