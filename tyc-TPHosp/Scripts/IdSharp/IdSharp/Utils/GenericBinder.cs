using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace IdSharp.Utils
{
	public class GenericBinder<T> where T : INotifyPropertyChanged
	{
		private PropertyDescriptorCollection m_PropertyDescriptorCollection;

		private Dictionary<string, MethodInvoker> m_PropertyRetrievers;

		private Dictionary<string, Control> m_PropertyControls;

		private T m_Component;

		private IErrorProvider m_ErrorProvider;

		public GenericBinder(T component)
		{
			m_Component = component;
			m_PropertyDescriptorCollection = TypeDescriptor.GetProperties(m_Component);
			m_Component.PropertyChanged += Component_PropertyChanged;
			m_PropertyRetrievers = new Dictionary<string, MethodInvoker>();
			m_PropertyControls = new Dictionary<string, Control>();
			if (component is INotifyInvalidData notifyInvalidData)
			{
				notifyInvalidData.InvalidData += NotifyInvalidData_InvalidData;
			}
		}

		public GenericBinder(T component, IErrorProvider errorProvider)
			: this(component)
		{
			m_ErrorProvider = errorProvider;
		}

		private void NotifyInvalidData_InvalidData(object sender, InvalidDataEventArgs e)
		{
			if (m_PropertyControls.TryGetValue(e.Property, out var value))
			{
				m_ErrorProvider.SetError(value, e.Message, ErrorType.Warning);
			}
		}

		private void Component_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (m_PropertyRetrievers.TryGetValue(e.PropertyName, out var value))
			{
				value();
			}
		}

		public void Bind(IBindableControl bindableControl, string propertyName)
		{
			Guard.ArgumentNotNull(bindableControl, "bindableControl");
			Guard.ArgumentNotNullOrEmptyString(propertyName, "property");
			int num = propertyName.IndexOf('.');
			if (num >= 0)
			{
				propertyName.Substring(num + 1, propertyName.Length - num - 1);
				propertyName = propertyName.Substring(0, num);
			}
			PropertyDescriptor tmpPropertyDescriptor = m_PropertyDescriptorCollection.Find(propertyName, ignoreCase: false);
			if (tmpPropertyDescriptor == null)
			{
				throw new ArgumentException($"'{propertyName}' is not a valid property of '{typeof(T).FullName}'", "property");
			}
			m_PropertyControls.Add(propertyName, bindableControl.Control);
			if ((object)tmpPropertyDescriptor.PropertyType == typeof(string))
			{
				m_PropertyRetrievers.Add(propertyName, delegate
				{
					bindableControl.Value = (string)tmpPropertyDescriptor.GetValue(m_Component);
				});
				bindableControl.Validated += delegate
				{
					tmpPropertyDescriptor.SetValue(m_Component, bindableControl.Value);
				};
			}
			else if ((object)tmpPropertyDescriptor.PropertyType == typeof(bool))
			{
				m_PropertyRetrievers.Add(propertyName, delegate
				{
					bindableControl.Value = (bool)tmpPropertyDescriptor.GetValue(m_Component);
				});
				bindableControl.Validated += delegate
				{
					tmpPropertyDescriptor.SetValue(m_Component, bindableControl.Value);
				};
			}
			else if (tmpPropertyDescriptor.PropertyType.FindInterfaces(TypeFilter, "System.Collections.IEnumerable").Length == 0)
			{
				throw new ArgumentException($"Control '{bindableControl.Name}' cannot be bound to property '{propertyName}' because it is not of a convertable type");
			}
		}

		private bool TypeFilter(Type type, object filterCriteria)
		{
			return type.FullName.StartsWith((string)filterCriteria);
		}
	}
}
