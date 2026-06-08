using System.Collections.Concurrent;

namespace NSubstitute.Core
{
	public class CallResults : ICallResults
	{
		private readonly struct ResultForCallSpec
		{
			private readonly ICallSpecification _callSpecification;

			private readonly IReturn _resultToReturn;

			public ResultForCallSpec(ICallSpecification callSpecification, IReturn resultToReturn)
			{
				_callSpecification = callSpecification;
				_resultToReturn = resultToReturn;
			}

			public bool IsResultFor(ICall call)
			{
				return _callSpecification.IsSatisfiedBy(call);
			}

			public object? GetResult(ICall call, ICallInfoFactory callInfoFactory)
			{
				if (_resultToReturn is ICallIndependentReturn callIndependentReturn)
				{
					return callIndependentReturn.GetReturnValue();
				}
				CallInfo info = callInfoFactory.Create(call);
				return _resultToReturn.ReturnFor(info);
			}
		}

		private readonly ICallInfoFactory _callInfoFactory;

		private readonly ConcurrentStack<ResultForCallSpec> _results;

		public CallResults(ICallInfoFactory callInfoFactory)
		{
			_results = new ConcurrentStack<ResultForCallSpec>();
			_callInfoFactory = callInfoFactory;
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
			result = configuredResult.GetResult(call, _callInfoFactory);
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
