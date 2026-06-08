using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class BoundInstanceService : IBoundInstanceService
	{
		private readonly IBinder _ownBinder;

		public BoundInstanceService(IBinder ownBinder)
		{
			_ownBinder = ownBinder;
		}

		public IEnumerable<object> GetBoundInstances()
		{
			return (from instance in BoundInstances().Concat(MultiBoundsInstances())
				where instance != null
				select instance).Distinct();
		}

		private IEnumerable<object> BoundInstances()
		{
			return _ownBinder.Bindings.Values.Select((Binding binding) => binding.ProvisionBinding.Instance);
		}

		private IEnumerable<object> MultiBoundsInstances()
		{
			return from binding in _ownBinder.MultiBindings.Values.SelectMany((IReadOnlyList<Binding> bindings) => bindings)
				select binding.ProvisionBinding.Instance;
		}
	}
}
