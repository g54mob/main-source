using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class BindingValidator : IBindingValidator
	{
		private readonly IBindingAnalyser _bindingAnalyser;

		public BindingValidator(IBindingAnalyser bindingAnalyser)
		{
			_bindingAnalyser = bindingAnalyser;
		}

		public void Validate(Type type, ProvisionBinding provisionBinding)
		{
			BindingAnalysis bindingAnalysis = _bindingAnalyser.Analyse(type, provisionBinding);
			IReadOnlyList<Type> dependencyChain = bindingAnalysis.DependencyChain;
			if (bindingAnalysis.HasCyclicDependency)
			{
				throw new BinditoException("Cyclic dependency: " + TypeFormatting.FormatChain(dependencyChain) + ".");
			}
			if (bindingAnalysis.HasMissingDependency)
			{
				Type type2 = dependencyChain.Last();
				throw new BinditoException(TypeFormatting.Format(type) + " isn't instantiable due to missing dependency: " + TypeFormatting.Format(type2) + ". Dependency chain: " + TypeFormatting.FormatChain(dependencyChain) + ".");
			}
		}
	}
}
