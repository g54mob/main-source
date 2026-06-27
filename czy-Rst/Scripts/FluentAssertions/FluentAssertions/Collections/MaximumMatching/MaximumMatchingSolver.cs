using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.Collections.MaximumMatching
{
	internal class MaximumMatchingSolver<TValue>
	{
		private struct Match
		{
			public Predicate<TValue> Predicate;

			public Element<TValue> Element;
		}

		private sealed class MatchCollection : IEnumerable<Match>, IEnumerable
		{
			private readonly Dictionary<Element<TValue>, Match> matchesByElement = new Dictionary<Element<TValue>, Match>();

			public void UpdateFrom(IEnumerable<Match> matches)
			{
				foreach (Match match in matches)
				{
					matchesByElement[match.Element] = match;
				}
			}

			public Predicate<TValue> GetMatchedPredicate(Element<TValue> element)
			{
				return matchesByElement[element].Predicate;
			}

			public bool Contains(Element<TValue> element)
			{
				return matchesByElement.ContainsKey(element);
			}

			public IEnumerator<Match> GetEnumerator()
			{
				return matchesByElement.Values.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return matchesByElement.Values.GetEnumerator();
			}
		}

		private sealed class BreadthFirstSearchTracker
		{
			private readonly Queue<Predicate<TValue>> unmatchedPredicatesQueue = new Queue<Predicate<TValue>>();

			private readonly Dictionary<Predicate<TValue>, Match> previousMatchByPredicate = new Dictionary<Predicate<TValue>, Match>();

			private readonly MatchCollection originalMatches;

			public BreadthFirstSearchTracker(Predicate<TValue> unmatchedPredicate, MatchCollection originalMatches)
			{
				unmatchedPredicatesQueue.Enqueue(unmatchedPredicate);
				this.originalMatches = originalMatches;
			}

			public bool TryDequeueUnMatchedPredicate(out Predicate<TValue> unmatchedPredicate)
			{
				if (unmatchedPredicatesQueue.Count == 0)
				{
					unmatchedPredicate = null;
					return false;
				}
				unmatchedPredicate = unmatchedPredicatesQueue.Dequeue();
				return true;
			}

			public void ReassignElement(Element<TValue> element, Predicate<TValue> newMatchedPredicate)
			{
				Predicate<TValue> matchedPredicate = originalMatches.GetMatchedPredicate(element);
				previousMatchByPredicate.Add(matchedPredicate, new Match
				{
					Predicate = newMatchedPredicate,
					Element = element
				});
				unmatchedPredicatesQueue.Enqueue(matchedPredicate);
			}

			public IEnumerable<Match> GetMatchChain(Match lastMatch)
			{
				Match match = lastMatch;
				do
				{
					yield return match;
				}
				while (previousMatchByPredicate.TryGetValue(match.Predicate, out match));
			}
		}

		private readonly MaximumMatchingProblem<TValue> problem;

		private readonly Dictionary<Predicate<TValue>, List<Element<TValue>>> matchingElementsByPredicate = new Dictionary<Predicate<TValue>, List<Element<TValue>>>();

		public MaximumMatchingSolver(MaximumMatchingProblem<TValue> problem)
		{
			this.problem = problem;
		}

		public MaximumMatchingSolution<TValue> Solve()
		{
			MatchCollection matchCollection = new MatchCollection();
			foreach (Predicate<TValue> predicate in problem.Predicates)
			{
				IEnumerable<Match> matches = FindMatchForPredicate(predicate, matchCollection);
				matchCollection.UpdateFrom(matches);
			}
			Dictionary<Predicate<TValue>, Element<TValue>> elementsByMatchedPredicate = matchCollection.ToDictionary((Match match) => match.Predicate, (Match match) => match.Element);
			return new MaximumMatchingSolution<TValue>(problem, elementsByMatchedPredicate);
		}

		private IEnumerable<Match> FindMatchForPredicate(Predicate<TValue> predicate, MatchCollection currentMatches)
		{
			HashSet<Element<TValue>> visitedElements = new HashSet<Element<TValue>>();
			BreadthFirstSearchTracker breadthFirstSearchTracker = new BreadthFirstSearchTracker(predicate, currentMatches);
			Predicate<TValue> unmatchedPredicate;
			while (breadthFirstSearchTracker.TryDequeueUnMatchedPredicate(out unmatchedPredicate))
			{
				foreach (Element<TValue> item in from element in GetMatchingElements(unmatchedPredicate)
					where !visitedElements.Contains(element)
					select element)
				{
					visitedElements.Add(item);
					if (currentMatches.Contains(item))
					{
						breadthFirstSearchTracker.ReassignElement(item, unmatchedPredicate);
						continue;
					}
					Match lastMatch = new Match
					{
						Predicate = unmatchedPredicate,
						Element = item
					};
					return breadthFirstSearchTracker.GetMatchChain(lastMatch);
				}
			}
			return Array.Empty<Match>();
		}

		private List<Element<TValue>> GetMatchingElements(Predicate<TValue> predicate)
		{
			if (!matchingElementsByPredicate.TryGetValue(predicate, out var value))
			{
				value = problem.Elements.Where((Element<TValue> element) => predicate.Matches(element.Value)).ToList();
				matchingElementsByPredicate.Add(predicate, value);
			}
			return value;
		}
	}
}
