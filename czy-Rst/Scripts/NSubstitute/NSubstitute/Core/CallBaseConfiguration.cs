using System.Collections.Concurrent;

namespace NSubstitute.Core
{
	public class CallBaseConfiguration : ICallBaseConfiguration
	{
		private readonly struct CallBaseRule
		{
			public bool CallBase { get; }

			public CallBaseRule(ICallSpecification callSpecification, bool callBase)
			{
				_003CcallSpecification_003EP = callSpecification;
				CallBase = callBase;
			}

			public bool IsSatisfiedBy(ICall call)
			{
				return _003CcallSpecification_003EP.IsSatisfiedBy(call);
			}
		}

		private ConcurrentStack<CallBaseRule> Rules { get; } = new ConcurrentStack<CallBaseRule>();

		public bool CallBaseByDefault { get; set; }

		public void Exclude(ICallSpecification callSpecification)
		{
			Rules.Push(new CallBaseRule(callSpecification, callBase: false));
		}

		public void Include(ICallSpecification callSpecification)
		{
			Rules.Push(new CallBaseRule(callSpecification, callBase: true));
		}

		public bool ShouldCallBase(ICall call)
		{
			if (!TryGetExplicitConfiguration(call, out var callBase))
			{
				return CallBaseByDefault;
			}
			return callBase;
		}

		private bool TryGetExplicitConfiguration(ICall call, out bool callBase)
		{
			callBase = false;
			if (Rules.IsEmpty)
			{
				return false;
			}
			foreach (CallBaseRule rule in Rules)
			{
				if (rule.IsSatisfiedBy(call))
				{
					callBase = rule.CallBase;
					return true;
				}
			}
			return false;
		}
	}
}
