using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class BindingBuilderRegistry : IBindingBuilderRegistry
	{
		private readonly IBinder _binder;

		private readonly Dictionary<Type, IBindingBuilder> _boundBindingBuilders = new Dictionary<Type, IBindingBuilder>();

		private readonly Dictionary<Type, List<IBindingBuilder>> _boundMultiBindingBuilders = new Dictionary<Type, List<IBindingBuilder>>();

		public BindingBuilderRegistry(IBinder binder)
		{
			_binder = binder;
		}

		public void RegisterBindingBuilder<T>(BindingBuilder<T> bindingBuilder) where T : class
		{
			Type typeFromHandle = typeof(T);
			if (_boundBindingBuilders.ContainsKey(typeFromHandle))
			{
				throw new BinditoException("Can't bind type " + TypeFormatting.Format(typeFromHandle) + ", it's already bound.");
			}
			_boundBindingBuilders[typeFromHandle] = bindingBuilder;
		}

		public void RegisterMultiBindingBuilder<T>(BindingBuilder<T> bindingBuilder) where T : class
		{
			Type typeFromHandle = typeof(T);
			if (!_boundMultiBindingBuilders.TryGetValue(typeFromHandle, out var value))
			{
				value = new List<IBindingBuilder>();
				_boundMultiBindingBuilders[typeFromHandle] = value;
			}
			value.Add(bindingBuilder);
		}

		public void BuildAllBindings()
		{
			BuildBindings();
			BuildMultiBindings();
		}

		private void BuildBindings()
		{
			foreach (KeyValuePair<Type, IBindingBuilder> boundBindingBuilder in _boundBindingBuilders)
			{
				Type key = boundBindingBuilder.Key;
				IBindingBuilder value = boundBindingBuilder.Value;
				_binder.Bind(key, value.Build());
			}
		}

		private void BuildMultiBindings()
		{
			foreach (KeyValuePair<Type, List<IBindingBuilder>> boundMultiBindingBuilder in _boundMultiBindingBuilders)
			{
				Type key = boundMultiBindingBuilder.Key;
				foreach (IBindingBuilder item in boundMultiBindingBuilder.Value)
				{
					_binder.MultiBind(key, item.Build());
				}
			}
		}
	}
}
