using System;
using JetBrains.Annotations;

namespace Bindito.Core
{
	public interface IBindingBuilder<TBound> where TBound : class
	{
		IScopeAssignee To<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] TImplementation>() where TImplementation : class, TBound;

		IScopeAssignee ToProvider<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] TProvider>() where TProvider : IProvider<TBound>;

		IScopeAssignee ToProvider(IProvider<TBound> provider);

		IScopeAssignee ToProvider(Func<TBound> provider);

		IExportAssignee ToInstance(TBound instance);

		IExportAssignee ToExisting<TExisting>() where TExisting : TBound;
	}
}
