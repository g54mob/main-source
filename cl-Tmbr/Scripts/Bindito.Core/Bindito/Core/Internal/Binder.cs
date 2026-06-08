using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class Binder : IBinder
	{
		private readonly IBinder _parentBinder;

		private readonly Dictionary<Type, Binding> _bindings = new Dictionary<Type, Binding>();

		private readonly Dictionary<Type, List<Binding>> _multiBindings = new Dictionary<Type, List<Binding>>();

		public IReadOnlyDictionary<Type, Binding> Bindings => new ReadOnlyDictionary<Type, Binding>(_bindings);

		public IReadOnlyDictionary<Type, IReadOnlyList<Binding>> MultiBindings
		{
			get
			{
				Dictionary<Type, IReadOnlyList<Binding>> dictionary = new Dictionary<Type, IReadOnlyList<Binding>>();
				foreach (KeyValuePair<Type, List<Binding>> multiBinding in _multiBindings)
				{
					dictionary[multiBinding.Key] = multiBinding.Value.AsReadOnly();
				}
				return dictionary;
			}
		}

		public Binder(IBinder parentBinder)
		{
			_parentBinder = parentBinder;
		}

		public void Bind(Type type, Binding binding)
		{
			if (TryGetBinding(type, out var binding2))
			{
				throw new BinditoException($"Can't bind type {TypeFormatting.Format(type)} to {binding}," + $" it's already bound to {binding2}.");
			}
			if (_parentBinder != null && _parentBinder.TryGetExportedBinding(type, out var binding3))
			{
				throw new BinditoException($"Can't bind type {TypeFormatting.Format(type)} to {binding}," + $" it's already bound to {binding3} in parent container.");
			}
			_bindings[type] = binding;
		}

		public void MultiBind(Type type, Binding binding)
		{
			if (!_multiBindings.TryGetValue(type, out var value))
			{
				value = new List<Binding>();
				_multiBindings[type] = value;
			}
			value.Add(binding);
		}

		public bool TryGetBinding(Type type, out Binding binding)
		{
			return _bindings.TryGetValue(type, out binding);
		}

		public bool TryGetExportedBinding(Type type, out Binding binding)
		{
			if (TryGetBinding(type, out binding) && binding.Exported)
			{
				return true;
			}
			binding = null;
			return false;
		}

		public IEnumerable<Binding> GetMultiBindings(Type type)
		{
			if (!_multiBindings.TryGetValue(type, out var value))
			{
				return Enumerable.Empty<Binding>();
			}
			return value.AsReadOnlyEnumerable();
		}
	}
}
