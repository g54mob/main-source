using System.Collections.Concurrent;

namespace NSubstitute.Core
{
	public class CallResults : ICallResults
	{
		private readonly struct ResultForCallSpec
		{
			public ResultForCallSpec(ICallSpecification callSpecification, IReturn resultToReturn)
			{
				_003CcallSpecification_003EP = callSpecification;
				_003CresultToReturn_003EP = resultToReturn;
			}

			public bool IsResultFor(ICall call)
			{
				return _003CcallSpecification_003EP.IsSatisfiedBy(call);
			}

			public object? GetResult(ICall call, ICallInfoFactory callInfoFactory)
			{
				if (_003CresultToReturn_003EP is ICallIndependentReturn callIndependentReturn)
				{
					return callIndependentReturn.GetReturnValue();
				}
				CallInfo info = callInfoFactory.Create(call);
				return _003CresultToReturn_003EP.ReturnFor(info);
			}
		}

		private readonly ConcurrentStack<ResultForCallSpec> _results;

		public CallResults(ICallInfoFactory callInfoFactory)
		{
			_003CcallInfoFactory_003EP = callInfoFactory;
			_results = new ConcurrentStack<ResultForCallSpec>();
			base._002Ector();
		}

		public void SetResult(ICallSpecification callSpecification, IReturn result)
		{
			_results.Push(new ResultForCallSpec(callSpecification, result));
		}

		public bool TryGetResult(ICall call, out object? result)
		{
			result = null;
			if (ReturnsVoidFrom(call))
			{
				return false;
			}
			if (!TryFindResultForCall(call, out var configuredResult))
			{
				return false;
			}
			result = configuredResult.GetResult(call, _003CcallInfoFactory_003EP);
			return true;
		}

		private bool TryFindResultForCall(ICall call, out ResultForCallSpec configuredResult)
		{
			if (_results.IsEmpty)
			{
				configuredResult = default(ResultForCallSpec);
				return false;
			}
			foreach (ResultForCallSpec result in _results)
			{
				if (result.IsResultFor(call))
				{
					configuredResult = result;
					return true;
				}
			}
			configuredResult = default(ResultForCallSpec);
			return false;
		}

		public void Clear()
		{
			_results.Clear();
		}

		private static bool ReturnsVoidFrom(ICall call)
		{
			return call.GetReturnType() == typeof(void);
		}
	}
}
