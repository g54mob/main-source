using System.Collections;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;

namespace NGenerics.DataStructures.Trees
{
	public interface ISearchTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		T Maximum { get; }

		T Minimum { get; }

		void DepthFirstTraversal(OrderedVisitor<T> visitor);

		IEnumerator<T> GetOrderedEnumerator();
	}
}
