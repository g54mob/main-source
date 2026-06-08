using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class BindingResolver : IBindingResolver
	{
		private readonly IMultiBindingService _multiBindingService;

		private readonly IBinder _ownBinder;

		private readonly IBinder _parentBinder;

		public BindingResolver(IMultiBindingService multiBindingService, IBinder ownBinder, IBinder parentBinder = null)
		{
			_multiBindingService = multiBindingService;
			_ownBinder = ownBinder;
			_parentBinder = parentBinder;
		}

		public bool ResolveBindings(Type type, out IEnumerable<Binding> ownBindings)
		{
			if (_multiBindingService.IsMultiBound(type, out var multiBoundType))
			{
				ownBindings = _ownBinder.GetMultiBindings(multiBoundType);
				return true;
			}
			if (TryGetBinding(type, out ownBindings))
			{
				return true;
			}
			ownBindings = Enumerable.Empty<Binding>();
			return false;
		}

		private bool TryGetBinding(Type type, out IEnumerable<Binding> ownBindings)
		{
			if (_ownBinder.TryGetBinding(type, out var binding))
			{
				ownBindings = Enumerable.Repeat(binding, 1);
				return true;
			}
			if (_parentBinder != null && _parentBinder.TryGetExportedBinding(type, out var _))
			{
				ownBindings = Enumerable.Empty<Binding>();
				return true;
			}
			ownBindings = Enumerable.Empty<Binding>();
			return false;
		}
	}
}
