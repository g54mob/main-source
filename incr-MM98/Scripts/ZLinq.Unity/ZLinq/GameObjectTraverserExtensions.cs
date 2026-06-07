using UnityEngine;
using ZLinq.Traversables;

namespace ZLinq
{
	public static class GameObjectTraverserExtensions
	{
		public static GameObjectTraverser AsTraverser(this GameObject origin)
		{
			return new GameObjectTraverser(origin);
		}

		public static ValueEnumerable<Children<GameObjectTraverser, GameObject>, GameObject> Children(this GameObjectTraverser traverser)
		{
			return traverser.Children<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<Children<GameObjectTraverser, GameObject>, GameObject> ChildrenAndSelf(this GameObjectTraverser traverser)
		{
			return traverser.ChildrenAndSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<Descendants<GameObjectTraverser, GameObject>, GameObject> Descendants(this GameObjectTraverser traverser)
		{
			return traverser.Descendants<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<Descendants<GameObjectTraverser, GameObject>, GameObject> DescendantsAndSelf(this GameObjectTraverser traverser)
		{
			return traverser.DescendantsAndSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<Ancestors<GameObjectTraverser, GameObject>, GameObject> Ancestors(this GameObjectTraverser traverser)
		{
			return traverser.Ancestors<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<Ancestors<GameObjectTraverser, GameObject>, GameObject> AncestorsAndSelf(this GameObjectTraverser traverser)
		{
			return traverser.AncestorsAndSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<BeforeSelf<GameObjectTraverser, GameObject>, GameObject> BeforeSelf(this GameObjectTraverser traverser)
		{
			return traverser.BeforeSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<BeforeSelf<GameObjectTraverser, GameObject>, GameObject> BeforeSelfAndSelf(this GameObjectTraverser traverser)
		{
			return traverser.BeforeSelfAndSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<AfterSelf<GameObjectTraverser, GameObject>, GameObject> AfterSelf(this GameObjectTraverser traverser)
		{
			return traverser.AfterSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<AfterSelf<GameObjectTraverser, GameObject>, GameObject> AfterSelfAndSelf(this GameObjectTraverser traverser)
		{
			return traverser.AfterSelfAndSelf<GameObjectTraverser, GameObject>();
		}

		public static ValueEnumerable<Children<GameObjectTraverser, GameObject>, GameObject> Children(this GameObject origin)
		{
			return origin.AsTraverser().Children();
		}

		public static ValueEnumerable<Children<GameObjectTraverser, GameObject>, GameObject> ChildrenAndSelf(this GameObject origin)
		{
			return origin.AsTraverser().ChildrenAndSelf();
		}

		public static ValueEnumerable<Descendants<GameObjectTraverser, GameObject>, GameObject> Descendants(this GameObject origin)
		{
			return origin.AsTraverser().Descendants();
		}

		public static ValueEnumerable<Descendants<GameObjectTraverser, GameObject>, GameObject> DescendantsAndSelf(this GameObject origin)
		{
			return origin.AsTraverser().DescendantsAndSelf();
		}

		public static ValueEnumerable<Ancestors<GameObjectTraverser, GameObject>, GameObject> Ancestors(this GameObject origin)
		{
			return origin.AsTraverser().Ancestors();
		}

		public static ValueEnumerable<Ancestors<GameObjectTraverser, GameObject>, GameObject> AncestorsAndSelf(this GameObject origin)
		{
			return origin.AsTraverser().AncestorsAndSelf();
		}

		public static ValueEnumerable<BeforeSelf<GameObjectTraverser, GameObject>, GameObject> BeforeSelf(this GameObject origin)
		{
			return origin.AsTraverser().BeforeSelf();
		}

		public static ValueEnumerable<BeforeSelf<GameObjectTraverser, GameObject>, GameObject> BeforeSelfAndSelf(this GameObject origin)
		{
			return origin.AsTraverser().BeforeSelfAndSelf();
		}

		public static ValueEnumerable<AfterSelf<GameObjectTraverser, GameObject>, GameObject> AfterSelf(this GameObject origin)
		{
			return origin.AsTraverser().AfterSelf();
		}

		public static ValueEnumerable<AfterSelf<GameObjectTraverser, GameObject>, GameObject> AfterSelfAndSelf(this GameObject origin)
		{
			return origin.AsTraverser().AfterSelfAndSelf();
		}

		public static ValueEnumerable<OfComponentG<Children<GameObjectTraverser, GameObject>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<Children<GameObjectTraverser, GameObject>, GameObject> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentG<Children<GameObjectTraverser, GameObject>, TComponent>, TComponent>(new OfComponentG<Children<GameObjectTraverser, GameObject>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentG<Descendants<GameObjectTraverser, GameObject>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<Descendants<GameObjectTraverser, GameObject>, GameObject> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentG<Descendants<GameObjectTraverser, GameObject>, TComponent>, TComponent>(new OfComponentG<Descendants<GameObjectTraverser, GameObject>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentG<Ancestors<GameObjectTraverser, GameObject>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<Ancestors<GameObjectTraverser, GameObject>, GameObject> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentG<Ancestors<GameObjectTraverser, GameObject>, TComponent>, TComponent>(new OfComponentG<Ancestors<GameObjectTraverser, GameObject>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentG<BeforeSelf<GameObjectTraverser, GameObject>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<BeforeSelf<GameObjectTraverser, GameObject>, GameObject> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentG<BeforeSelf<GameObjectTraverser, GameObject>, TComponent>, TComponent>(new OfComponentG<BeforeSelf<GameObjectTraverser, GameObject>, TComponent>(source.Enumerator));
		}

		public static ValueEnumerable<OfComponentG<AfterSelf<GameObjectTraverser, GameObject>, TComponent>, TComponent> OfComponent<TComponent>(this ValueEnumerable<AfterSelf<GameObjectTraverser, GameObject>, GameObject> source) where TComponent : Component
		{
			return new ValueEnumerable<OfComponentG<AfterSelf<GameObjectTraverser, GameObject>, TComponent>, TComponent>(new OfComponentG<AfterSelf<GameObjectTraverser, GameObject>, TComponent>(source.Enumerator));
		}
	}
}
