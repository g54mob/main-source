using System;
using System.Collections.Generic;
using System.Linq;

namespace Moq
{
	internal sealed class MatcherObserver : IDisposable
	{
		private readonly struct Observation
		{
			public readonly int Timestamp;

			public readonly Match Match;

			public Observation(int timestamp, Match match)
			{
				Timestamp = timestamp;
				Match = match;
			}
		}

		[ThreadStatic]
		private static Stack<MatcherObserver> activations;

		private int timestamp;

		private List<Observation> observations;

		public static MatcherObserver Activate()
		{
			MatcherObserver matcherObserver = new MatcherObserver();
			Stack<MatcherObserver> stack = activations;
			if (stack == null)
			{
				stack = (activations = new Stack<MatcherObserver>());
			}
			stack.Push(matcherObserver);
			return matcherObserver;
		}

		public static bool IsActive(out MatcherObserver observer)
		{
			Stack<MatcherObserver> stack = activations;
			if (stack != null && stack.Count > 0)
			{
				observer = stack.Peek();
				return true;
			}
			observer = null;
			return false;
		}

		private MatcherObserver()
		{
		}

		public void Dispose()
		{
			Stack<MatcherObserver> stack = activations;
			stack.Pop();
		}

		public int GetNextTimestamp()
		{
			return ++timestamp;
		}

		public void OnMatch(Match match)
		{
			if (observations == null)
			{
				observations = new List<Observation>();
			}
			observations.Add(new Observation(GetNextTimestamp(), match));
		}

		public bool TryGetLastMatch(out Match match)
		{
			if (observations != null && observations.Count > 0)
			{
				match = observations.Last().Match;
				return true;
			}
			match = null;
			return false;
		}

		public IEnumerable<Match> GetMatchesBetween(int fromTimestampInclusive, int toTimestampExclusive)
		{
			if (observations != null)
			{
				return from o in observations
					where fromTimestampInclusive <= o.Timestamp && o.Timestamp < toTimestampExclusive
					select o.Match;
			}
			return Enumerable.Empty<Match>();
		}
	}
}
