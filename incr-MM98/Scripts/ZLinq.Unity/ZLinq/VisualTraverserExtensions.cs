using UnityEngine.UIElements;
using ZLinq.Traversables;

namespace ZLinq
{
	public static class VisualTraverserExtensions
	{
		public static VisualElementTraverser AsTraverser(this VisualElement origin)
		{
			return new VisualElementTraverser(origin);
		}

		public static ValueEnumerable<Children<VisualElementTraverser, VisualElement>, VisualElement> Children(this VisualElementTraverser traverser)
		{
			return traverser.Children<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<Children<VisualElementTraverser, VisualElement>, VisualElement> ChildrenAndSelf(this VisualElementTraverser traverser)
		{
			return traverser.ChildrenAndSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<Descendants<VisualElementTraverser, VisualElement>, VisualElement> Descendants(this VisualElementTraverser traverser)
		{
			return traverser.Descendants<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<Descendants<VisualElementTraverser, VisualElement>, VisualElement> DescendantsAndSelf(this VisualElementTraverser traverser)
		{
			return traverser.DescendantsAndSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<Ancestors<VisualElementTraverser, VisualElement>, VisualElement> Ancestors(this VisualElementTraverser traverser)
		{
			return traverser.Ancestors<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<Ancestors<VisualElementTraverser, VisualElement>, VisualElement> AncestorsAndSelf(this VisualElementTraverser traverser)
		{
			return traverser.AncestorsAndSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<BeforeSelf<VisualElementTraverser, VisualElement>, VisualElement> BeforeSelf(this VisualElementTraverser traverser)
		{
			return traverser.BeforeSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<BeforeSelf<VisualElementTraverser, VisualElement>, VisualElement> BeforeSelfAndSelf(this VisualElementTraverser traverser)
		{
			return traverser.BeforeSelfAndSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<AfterSelf<VisualElementTraverser, VisualElement>, VisualElement> AfterSelf(this VisualElementTraverser traverser)
		{
			return traverser.AfterSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<AfterSelf<VisualElementTraverser, VisualElement>, VisualElement> AfterSelfAndSelf(this VisualElementTraverser traverser)
		{
			return traverser.AfterSelfAndSelf<VisualElementTraverser, VisualElement>();
		}

		public static ValueEnumerable<Children<VisualElementTraverser, VisualElement>, VisualElement> Children(this VisualElement origin)
		{
			return origin.AsTraverser().Children();
		}

		public static ValueEnumerable<Children<VisualElementTraverser, VisualElement>, VisualElement> ChildrenAndSelf(this VisualElement origin)
		{
			return origin.AsTraverser().ChildrenAndSelf();
		}

		public static ValueEnumerable<Descendants<VisualElementTraverser, VisualElement>, VisualElement> Descendants(this VisualElement origin)
		{
			return origin.AsTraverser().Descendants();
		}

		public static ValueEnumerable<Descendants<VisualElementTraverser, VisualElement>, VisualElement> DescendantsAndSelf(this VisualElement origin)
		{
			return origin.AsTraverser().DescendantsAndSelf();
		}

		public static ValueEnumerable<Ancestors<VisualElementTraverser, VisualElement>, VisualElement> Ancestors(this VisualElement origin)
		{
			return origin.AsTraverser().Ancestors();
		}

		public static ValueEnumerable<Ancestors<VisualElementTraverser, VisualElement>, VisualElement> AncestorsAndSelf(this VisualElement origin)
		{
			return origin.AsTraverser().AncestorsAndSelf();
		}

		public static ValueEnumerable<BeforeSelf<VisualElementTraverser, VisualElement>, VisualElement> BeforeSelf(this VisualElement origin)
		{
			return origin.AsTraverser().BeforeSelf();
		}

		public static ValueEnumerable<BeforeSelf<VisualElementTraverser, VisualElement>, VisualElement> BeforeSelfAndSelf(this VisualElement origin)
		{
			return origin.AsTraverser().BeforeSelfAndSelf();
		}

		public static ValueEnumerable<AfterSelf<VisualElementTraverser, VisualElement>, VisualElement> AfterSelf(this VisualElement origin)
		{
			return origin.AsTraverser().AfterSelf();
		}

		public static ValueEnumerable<AfterSelf<VisualElementTraverser, VisualElement>, VisualElement> AfterSelfAndSelf(this VisualElement origin)
		{
			return origin.AsTraverser().AfterSelfAndSelf();
		}
	}
}
