using System;
using Loxodon.Framework.Observables;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	public class ObservableNodeProxy : NotifiableSourceProxyBase, IObtainable, IModifiable, INotifiable
	{
		protected IObservableProperty property;

		private bool disposedValue;

		public override Type Type => property.Type;

		public ObservableNodeProxy(IObservableProperty property)
			: this(null, property)
		{
		}

		public ObservableNodeProxy(object source, IObservableProperty property)
			: base(source)
		{
			this.property = property;
			this.property.ValueChanged += OnValueChanged;
		}

		protected virtual void OnValueChanged(object sender, EventArgs e)
		{
			RaiseValueChanged();
		}

		public virtual object GetValue()
		{
			return property.Value;
		}

		public virtual TValue GetValue<TValue>()
		{
			if (property is IObservableProperty<TValue> observableProperty)
			{
				return observableProperty.Value;
			}
			return (TValue)property.Value;
		}

		public virtual void SetValue(object value)
		{
			property.Value = value;
		}

		public virtual void SetValue<TValue>(TValue value)
		{
			if (property is IObservableProperty<TValue> observableProperty)
			{
				observableProperty.Value = value;
			}
			else
			{
				property.Value = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (property != null)
				{
					property.ValueChanged -= OnValueChanged;
				}
				disposedValue = true;
				base.Dispose(disposing);
			}
		}
	}
}
