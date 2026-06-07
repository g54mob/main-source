using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace R3
{
	public class BindableReactiveProperty<T> : ReactiveProperty<T>, IBindableReactiveProperty<T>, IBindableReactiveProperty, IReadOnlyBindableReactiveProperty, INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable, IReadOnlyBindableReactiveProperty<T>
	{
		private class Observer : Observer<T>
		{
			public Observer(BindableReactiveProperty<T> parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cparent_003EP.Value = value;
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cparent_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cparent_003EP.OnCompleted(result);
			}
		}

		private IDisposable? subscription;

		private PropertyValidationContext? validationContext;

		private Func<T, Exception?>? validator;

		private List<ValidationResult>? errors;

		public new T Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				base.Value = value;
			}
		}

		public bool IsValidationEnabled { get; private set; }

		public bool HasErrors
		{
			get
			{
				if (errors == null)
				{
					return false;
				}
				return errors.Count != 0;
			}
		}

		object? IBindableReactiveProperty.Value
		{
			get
			{
				return Value;
			}
			set
			{
				Value = (T)value;
			}
		}

		object? IReadOnlyBindableReactiveProperty.Value => Value;

		public event PropertyChangedEventHandler? PropertyChanged;

		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		public BindableReactiveProperty()
		{
		}

		public BindableReactiveProperty(T value)
			: base(value)
		{
		}

		public BindableReactiveProperty(T value, IEqualityComparer<T>? equalityComparer)
			: base(value, equalityComparer)
		{
		}

		internal BindableReactiveProperty(Observable<T> source, T initialValue, IEqualityComparer<T>? equalityComparer)
			: base(initialValue, equalityComparer)
		{
			subscription = source.Subscribe(new Observer(this));
		}

		protected override void DisposeCore()
		{
			subscription?.Dispose();
		}

		protected override void OnValueChanged(T value)
		{
			Validate(value);
			this.PropertyChanged?.Invoke(this, ValueChangedEventArgs.PropertyChanged);
		}

		private void Validate(T value)
		{
			if (!IsValidationEnabled)
			{
				return;
			}
			bool flag = errors != null && errors.Count != 0;
			errors?.Clear();
			if (validationContext != null)
			{
				if (errors == null)
				{
					errors = new List<ValidationResult>(validationContext.ValidatorCount);
				}
				if (!validationContext.TryValidateValue(value, errors))
				{
					this.ErrorsChanged?.Invoke(this, ValueChangedEventArgs.DataErrorsChanged);
				}
				else if (flag)
				{
					this.ErrorsChanged?.Invoke(this, ValueChangedEventArgs.DataErrorsChanged);
				}
			}
			else if (validator != null)
			{
				Exception ex = validator(value);
				if (ex != null)
				{
					OnReceiveError(ex);
				}
				else if (flag)
				{
					this.ErrorsChanged?.Invoke(this, ValueChangedEventArgs.DataErrorsChanged);
				}
			}
			else if (flag)
			{
				this.ErrorsChanged?.Invoke(this, ValueChangedEventArgs.DataErrorsChanged);
			}
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			if (errors == null)
			{
				return Enumerable.Empty<Exception>();
			}
			return errors;
		}

		protected override void OnReceiveError(Exception exception)
		{
			if (!IsValidationEnabled)
			{
				return;
			}
			AggregateException ex = exception as AggregateException;
			if (errors == null)
			{
				if (ex != null)
				{
					errors = new List<ValidationResult>(ex.InnerExceptions.Count);
				}
				else
				{
					errors = new List<ValidationResult>(1);
				}
			}
			errors.Clear();
			if (ex != null)
			{
				foreach (Exception innerException in ex.InnerExceptions)
				{
					errors.Add(new ValidationResult(innerException.Message));
				}
			}
			else
			{
				errors.Add(new ValidationResult(exception.Message));
			}
			this.ErrorsChanged?.Invoke(this, ValueChangedEventArgs.DataErrorsChanged);
		}

		public BindableReactiveProperty<T> EnableValidation()
		{
			IsValidationEnabled = true;
			return this;
		}

		public BindableReactiveProperty<T> EnableValidation(Func<T, Exception?> validator)
		{
			this.validator = validator;
			IsValidationEnabled = true;
			return this;
		}

		public BindableReactiveProperty<T> EnableValidation<TClass>([CallerMemberName] string? propertyName = null)
		{
			PropertyInfo property = typeof(TClass).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			SetValidationContext(property);
			IsValidationEnabled = true;
			return this;
		}

		public BindableReactiveProperty<T> EnableValidation(Expression<Func<BindableReactiveProperty<T>?>> selfSelector)
		{
			PropertyInfo propertyInfo = (PropertyInfo)((MemberExpression)selfSelector.Body).Member;
			SetValidationContext(propertyInfo);
			IsValidationEnabled = true;
			return this;
		}

		private void SetValidationContext(PropertyInfo propertyInfo)
		{
			DisplayAttribute customAttribute = propertyInfo.GetCustomAttribute<DisplayAttribute>();
			ValidationAttribute[] array = AsArray(propertyInfo.GetCustomAttributes<ValidationAttribute>());
			if (array.Length != 0)
			{
				ValidationContext context = new ValidationContext(this)
				{
					DisplayName = (customAttribute?.GetName() ?? propertyInfo.Name),
					MemberName = "Value"
				};
				validationContext = new PropertyValidationContext(context, array);
			}
		}

		private ValidationAttribute[] AsArray(IEnumerable<ValidationAttribute> validationAttributes)
		{
			if (validationAttributes is ValidationAttribute[] result)
			{
				return result;
			}
			return validationAttributes.ToArray();
		}

		void IBindableReactiveProperty.OnNext(object? value)
		{
			OnNext((T)value);
		}

		IBindableReactiveProperty<T> IBindableReactiveProperty<T>.EnableValidation()
		{
			return EnableValidation();
		}

		IBindableReactiveProperty<T> IBindableReactiveProperty<T>.EnableValidation(Func<T, Exception?> validator)
		{
			return EnableValidation(validator);
		}

		IBindableReactiveProperty<T> IBindableReactiveProperty<T>.EnableValidation<TClass>(string? propertyName)
		{
			return EnableValidation<TClass>(propertyName);
		}

		IBindableReactiveProperty<T> IBindableReactiveProperty<T>.EnableValidation(Expression<Func<IBindableReactiveProperty<T>?>> selfSelector)
		{
			PropertyInfo propertyInfo = (PropertyInfo)((MemberExpression)selfSelector.Body).Member;
			SetValidationContext(propertyInfo);
			IsValidationEnabled = true;
			return this;
		}

		IReadOnlyBindableReactiveProperty<T> IReadOnlyBindableReactiveProperty<T>.EnableValidation()
		{
			return EnableValidation();
		}

		IReadOnlyBindableReactiveProperty<T> IReadOnlyBindableReactiveProperty<T>.EnableValidation(Func<T, Exception?> validator)
		{
			return EnableValidation(validator);
		}

		IReadOnlyBindableReactiveProperty<T> IReadOnlyBindableReactiveProperty<T>.EnableValidation<TClass>(string? propertyName)
		{
			return EnableValidation<TClass>(propertyName);
		}

		IReadOnlyBindableReactiveProperty<T> IReadOnlyBindableReactiveProperty<T>.EnableValidation(Expression<Func<IReadOnlyBindableReactiveProperty<T>?>> selfSelector)
		{
			PropertyInfo propertyInfo = (PropertyInfo)((MemberExpression)selfSelector.Body).Member;
			SetValidationContext(propertyInfo);
			IsValidationEnabled = true;
			return this;
		}

		public Observable<T> AsObservable()
		{
			return this;
		}

		public IBindableReactiveProperty<T> ForceValidate()
		{
			Validate(Value);
			return this;
		}

		IReadOnlyBindableReactiveProperty<T> IReadOnlyBindableReactiveProperty<T>.ForceValidate()
		{
			return ForceValidate();
		}
	}
}
