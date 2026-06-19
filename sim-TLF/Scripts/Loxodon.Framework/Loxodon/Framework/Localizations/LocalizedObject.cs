using System;
using System.Collections.Generic;
using System.Globalization;
using Loxodon.Framework.Observables;

namespace Loxodon.Framework.Localizations
{
	public class LocalizedObject<T> : Dictionary<string, T>, IObservableProperty<T>, IObservableProperty, IDisposable
	{
		private readonly object _lock = new object();

		private EventHandler valueChanged;

		private Localization localization;

		private bool disposed;

		public virtual Type Type => typeof(T);

		public virtual T Value
		{
			get
			{
				return GetValue((localization != null) ? localization.CultureInfo : CultureInfo.CurrentUICulture);
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		object IObservableProperty.Value
		{
			get
			{
				return GetValue((localization != null) ? localization.CultureInfo : CultureInfo.CurrentUICulture);
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public event EventHandler ValueChanged
		{
			add
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Combine(valueChanged, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Remove(valueChanged, value);
				}
			}
		}

		public LocalizedObject()
			: this((IDictionary<string, T>)null, Localization.Current)
		{
		}

		public LocalizedObject(IDictionary<string, T> source)
			: this(source, Localization.Current)
		{
		}

		public LocalizedObject(IDictionary<string, T> source, Localization localization)
		{
			if (source != null)
			{
				foreach (KeyValuePair<string, T> item in source)
				{
					Add(item.Key, item.Value);
				}
			}
			this.localization = localization;
			if (localization != null)
			{
				localization.CultureInfoChanged += OnCultureInfoChanged;
			}
		}

		protected void RaiseValueChanged()
		{
			valueChanged?.Invoke(this, EventArgs.Empty);
		}

		private void OnCultureInfoChanged(object sender, EventArgs e)
		{
			try
			{
				RaiseValueChanged();
			}
			catch (Exception)
			{
			}
		}

		protected virtual T GetValue(CultureInfo cultureInfo)
		{
			T value = default(T);
			if (TryGetValue(cultureInfo.Name, out value))
			{
				return value;
			}
			if (TryGetValue(cultureInfo.TwoLetterISOLanguageName, out value))
			{
				return value;
			}
			ValueCollection.Enumerator enumerator = base.Values.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
			return value;
		}

		public static implicit operator T(LocalizedObject<T> localized)
		{
			return localized.Value;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is LocalizedObject<T>))
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			LocalizedObject<T> obj2 = (LocalizedObject<T>)obj;
			if (Equals(obj2))
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (Value == null)
			{
				return 0;
			}
			return Value.GetHashCode();
		}

		public override string ToString()
		{
			T value = Value;
			if (value == null)
			{
				return string.Empty;
			}
			return value.ToString();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (localization != null)
				{
					localization.CultureInfoChanged -= OnCultureInfoChanged;
				}
				disposed = true;
			}
		}

		~LocalizedObject()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
