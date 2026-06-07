using UnityEngine;
using ZLinq.Traversables;

namespace ZLinq
{
	public static class TransformTraverserExtensions
	{
		public static TransformTraverser AsTraverser(this Transform origin)
		{
			return new TransformTraverser(origin);
		}

		public static ValueEnumerable<Children<TransformTraverser, Transform>, Transform> Children(this TransformTraverser traverser)
		{
			return traverser.Children<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<Children<TransformTraverser, Transform>, Transform> ChildrenAndSelf(this TransformTraverser traverser)
		{
			return traverser.ChildrenAndSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<Descendants<TransformTraverser, Transform>, Transform> Descendants(this TransformTraverser traverser)
		{
			return traverser.Descendants<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<Descendants<TransformTraverser, Transform>, Transform> DescendantsAndSelf(this TransformTraverser traverser)
		{
			return traverser.DescendantsAndSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<Ancestors<TransformTraverser, Transform>, Transform> Ancestors(this TransformTraverser traverser)
		{
			return traverser.Ancestors<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<Ancestors<TransformTraverser, Transform>, Transform> AncestorsAndSelf(this TransformTraverser traverser)
		{
			return traverser.AncestorsAndSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<BeforeSelf<TransformTraverser, Transform>, Transform> BeforeSelf(this TransformTraverser traverser)
		{
			return traverser.BeforeSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<BeforeSelf<TransformTraverser, Transform>, Transform> BeforeSelfAndSelf(this TransformTraverser traverser)
		{
			return traverser.BeforeSelfAndSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<AfterSelf<TransformTraverser, Transform>, Transform> AfterSelf(this TransformTraverser traverser)
		{
			return traverser.AfterSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<AfterSelf<TransformTraverser, Transform>, Transform> AfterSelfAndSelf(this TransformTraverser traverser)
		{
			return traverser.AfterSelfAndSelf<TransformTraverser, Transform>();
		}

		public static ValueEnumerable<Children<TransformTraverser, Transform>, Transform> Children(this Transform origin)
		{
			return origin.AsTraverser().Children();
		}

		public static ValueEnumerable<Children<TransformTraverser, Transform>, Transform> ChildrenAndSelf(this Transform origin)
		{
			return origin.AsTraverser().ChildrenAndSelf();
		}

		public static ValueEnumerable<Descendants<TransformTraverser, Transform>, Transform> Descendants(this Transform origin)
		{
			return origin.AsTraverser().Descendants();
		}

		public static ValueEnumerable<Descendants<TransformTraverser, Transform>, Transform> DescendantsAndSelf(this Transform origin)
		{
			return origin.AsTraverser().DescendantsAndSelf();
		}

		public static ValueEnumerable<Ancestors<TransformTraverser, Transform>, Transform> Ancestors(this Transform origin)
		{
			return origin.AsTraverser().Ancestors();
		}

		public static ValueEnumerable<Ancestors<TransformTraverser, Transform>, Transform> AncestorsAndSelf(this Transform origin)
		{
			return origin.AsTraverser().AncestorsAndSelf();
		}

		public static ValueEnumerable<BeforeSelf<TransformTraverser, Transform>, Transform> BeforeSelf(this Transform origin)
		{
			return origin.AsTraverser().BeforeSelf();
		}

		public static ValueEnumerable<BeforeSelf<TransformTraverser, Transform>, Transform> BeforeSelfAndSelf(this Transform origin)
		{
			return origin.AsTraverser().BeforeSelfAndSelf();
		}

		public static ValueEnumerable<AfterSelf<TransformTraverser, Transform>, Transform> AfterSelf(this Transform origin)
		{
			return origin.AsTraverser().AfterSelf();
		}

		public static ValueEnumerable<AfterSelf<TransformTraverser, Transform>, Transform> AfterSelfAndSelf(this Transform origin)
		{
			return origin.AsTraverser().AfterSelfAndSelf();
		}

		public static ValueEnumerable<OfComponentT<Children<TransformTraverser, Transform>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<Children<TransformTraverser, Transform>, Transform> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentT<Children<TransformTraverser, Transform>, TComponent>, TComponent>(new OfComponentT<Children<TransformTraverser, Transform>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentT<Descendants<TransformTraverser, Transform>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<Descendants<TransformTraverser, Transform>, Transform> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentT<Descendants<TransformTraverser, Transform>, TComponent>, TComponent>(new OfComponentT<Descendants<TransformTraverser, Transform>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentT<Ancestors<TransformTraverser, Transform>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<Ancestors<TransformTraverser, Transform>, Transform> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentT<Ancestors<TransformTraverser, Transform>, TComponent>, TComponent>(new OfComponentT<Ancestors<TransformTraverser, Transform>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentT<BeforeSelf<TransformTraverser, Transform>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<BeforeSelf<TransformTraverser, Transform>, Transform> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentT<BeforeSelf<TransformTraverser, Transform>, TComponent>, TComponent>(new OfComponentT<BeforeSelf<TransformTraverser, Transform>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentT<AfterSelf<TransformTraverser, Transform>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<AfterSelf<TransformTraverser, Transform>, Transform> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentT<AfterSelf<TransformTraverser, Transform>, TComponent>, TComponent>(new OfComponentT<AfterSelf<TransformTraverser, Transform>, TComponent>(source.Enumerator));
		}
	}
}
