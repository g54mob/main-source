using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class BindingAnalysis
	{
		public bool HasCyclicDependency { get; }

		public bool HasMissingDependency { get; }

		public IReadOnlyList<Type> DependencyChain { get; }

		public bool IsOk
		{
			get
			{
				if (!HasCyclicDependency)
				{
					return !HasMissingDependency;
				}
				return false;
			}
		}

		private BindingAnalysis(bool hasCyclicDependency, bool hasMissingDependency, IEnumerable<Type> dependencyChain)
		{
			HasCyclicDependency = hasCyclicDependency;
			HasMissingDependency = hasMissingDependency;
			DependencyChain = dependencyChain.ToList().AsReadOnly();
		}

		public static BindingAnalysis Ok()
		{
			return new BindingAnalysis(hasCyclicDependency: false, hasMissingDependency: false, Enumerable.Empty<Type>());
		}

		public static BindingAnalysis CyclicDependency(IEnumerable<Type> dependencyChain)
		{
			return new BindingAnalysis(hasCyclicDependency: true, hasMissingDependency: false, dependencyChain);
		}

		public static BindingAnalysis MissingDependency(IEnumerable<Type> dependencyChain)
		{
			return new BindingAnalysis(hasCyclicDependency: false, hasMissingDependency: true, dependencyChain);
		}
	}
}
