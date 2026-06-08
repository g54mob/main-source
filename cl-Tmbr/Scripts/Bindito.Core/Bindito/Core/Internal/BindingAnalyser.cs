using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class BindingAnalyser : IBindingAnalyser
	{
		private enum CheckResult
		{
			Ok = 0,
			CyclicDependency = 1,
			MissingDependency = 2
		}

		private readonly IDependencyRetriever _dependencyRetriever;

		private readonly IBindingResolver _bindingResolver;

		private readonly Stack<Type> _dependencyStack = new Stack<Type>();

		private readonly Dictionary<Type, CheckResult> _cachedResults = new Dictionary<Type, CheckResult>();

		public BindingAnalyser(IDependencyRetriever dependencyRetriever, IBindingResolver bindingResolver)
		{
			_dependencyRetriever = dependencyRetriever;
			_bindingResolver = bindingResolver;
		}

		public BindingAnalysis Analyse(Type suspectType, ProvisionBinding suspectProvisionBinding)
		{
			_dependencyStack.Clear();
			_dependencyStack.Push(suspectType);
			return CheckForProblemsCached(suspectProvisionBinding) switch
			{
				CheckResult.Ok => BindingAnalysis.Ok(), 
				CheckResult.CyclicDependency => BindingAnalysis.CyclicDependency(CreateDependencyChain()), 
				CheckResult.MissingDependency => BindingAnalysis.MissingDependency(CreateDependencyChain()), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		private CheckResult CheckForProblemsCached(ProvisionBinding suspect)
		{
			if (suspect.TryGetBindingType(out var bindingType))
			{
				if (!_cachedResults.ContainsKey(bindingType))
				{
					_cachedResults[bindingType] = CheckForProblems(suspect);
				}
				return _cachedResults[bindingType];
			}
			return CheckResult.Ok;
		}

		private CheckResult CheckForProblems(ProvisionBinding suspect)
		{
			foreach (Type dependency in _dependencyRetriever.GetDependencies(suspect))
			{
				_dependencyStack.Push(dependency);
				if (_dependencyStack.Count((Type dependencyInChain) => dependencyInChain == dependency) > 1)
				{
					return CheckResult.CyclicDependency;
				}
				if (!_bindingResolver.ResolveBindings(dependency, out var ownBindings))
				{
					return CheckResult.MissingDependency;
				}
				foreach (Binding item in ownBindings)
				{
					CheckResult checkResult = CheckForProblemsCached(item.ProvisionBinding);
					if (checkResult != CheckResult.Ok)
					{
						return checkResult;
					}
				}
				_dependencyStack.Pop();
			}
			return CheckResult.Ok;
		}

		private IEnumerable<Type> CreateDependencyChain()
		{
			return _dependencyStack.Reverse().ToList();
		}
	}
}
