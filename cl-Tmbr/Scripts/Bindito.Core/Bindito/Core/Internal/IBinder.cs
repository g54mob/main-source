using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IBinder
	{
		IReadOnlyDictionary<Type, Binding> Bindings { get; }

		IReadOnlyDictionary<Type, IReadOnlyList<Binding>> MultiBindings { get; }

		void Bind(Type type, Binding binding);

		void MultiBind(Type type, Binding binding);

		bool TryGetBinding(Type type, out Binding binding);

		bool TryGetExportedBinding(Type type, out Binding binding);

		IEnumerable<Binding> GetMultiBindings(Type type);
	}
}
