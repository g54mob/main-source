using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Bindito.Core
{
	public interface IContainer
	{
		T GetInstance<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] T>();

		IEnumerable<T> GetInstances<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] T>();

		object GetInstance(Type type);

		IEnumerable<object> GetInstances(Type type);

		IEnumerable<object> GetBoundInstances();

		void Inject(object instance);

		IContainer CreateChildContainer(IEnumerable<IConfigurator> configurators);

		IContainer CreateChildContainer(params IConfigurator[] configurators);
	}
}
