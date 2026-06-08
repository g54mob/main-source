using System;
using System.Collections.Generic;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.IO
{
	public class FormatterProvider : IFormatterProvider
	{
		private static readonly Func<Type, ObservableList<IFormatterProvider>, DeferredValue<KeyValuePair<Type, ObservableList<IFormatterProvider>>, IFormatter>> ValueFactory = (Type t, ObservableList<IFormatterProvider> providers) => new DeferredValue<KeyValuePair<Type, ObservableList<IFormatterProvider>>, IFormatter>(new KeyValuePair<Type, ObservableList<IFormatterProvider>>(t, providers), DeferredValueFactory);

		private static readonly Func<KeyValuePair<Type, ObservableList<IFormatterProvider>>, IFormatter> DeferredValueFactory = delegate(KeyValuePair<Type, ObservableList<IFormatterProvider>> deps)
		{
			ObservableList<IFormatterProvider> value = deps.Value;
			for (int num = value.Count - 1; num >= 0; num--)
			{
				if (value[num].TryCreateFormatter(deps.Key, out var formatter))
				{
					return formatter;
				}
			}
			return (IFormatter)null;
		};

		private readonly LookupSlim<Type, DeferredValue<KeyValuePair<Type, ObservableList<IFormatterProvider>>, IFormatter>, ReferenceEqualityComparer<Type>> _formatters = new LookupSlim<Type, DeferredValue<KeyValuePair<Type, ObservableList<IFormatterProvider>>, IFormatter>, ReferenceEqualityComparer<Type>>(default(ReferenceEqualityComparer<Type>));

		private readonly ObservableList<IFormatterProvider> _formatterProviders;

		private readonly List<object> _observers = new List<object>();

		public static FormatterProvider Current => AmbientContext.Current?.FormatterProvider;

		public FormatterProvider(ObservableList<IFormatterProvider> providers = null)
		{
			_formatterProviders = new ObservableList<IFormatterProvider>();
			if (providers != null)
			{
				Append(providers);
			}
			IObserver<ObservableEvent<IFormatterProvider>> observer = ObserverBuilder<ObservableEvent<IFormatterProvider>>.Create(_formatters).OnEvent(delegate(AddedObservableEvent<IFormatterProvider> @event, LookupSlim<Type, DeferredValue<KeyValuePair<Type, ObservableList<IFormatterProvider>>, IFormatter>, ReferenceEqualityComparer<Type>> state)
			{
				state.Clear();
			}).Build();
			_observers.Add(observer);
			_formatterProviders.Subscribe(observer);
		}

		public FormatterProvider Append(ObservableList<IFormatterProvider> providers)
		{
			_formatterProviders.AddMany(providers);
			providers.Subscribe(_formatterProviders);
			return this;
		}

		public FormatterProvider Append(FormatterProvider provider)
		{
			_formatterProviders.AddMany(provider._formatterProviders);
			provider._formatterProviders.Subscribe(_formatterProviders);
			return this;
		}

		public bool TryCreateFormatter(Type type, out IFormatter formatter)
		{
			formatter = _formatters.GetOrAdd(type, ValueFactory, _formatterProviders).Value;
			return formatter != null;
		}
	}
}
