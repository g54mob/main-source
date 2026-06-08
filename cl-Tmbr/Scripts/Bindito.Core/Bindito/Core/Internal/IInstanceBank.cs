using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IInstanceBank
	{
		bool TryGetInstance(Type type, out object instance);

		bool TryGetExportedInstance(Type type, out object instance);

		IEnumerable<object> GetInstances(Type type);

		IEnumerable<object> GetExportedInstances(Type type);
	}
}
