using ZLinq.Traversables;

namespace ZLinq
{
	public static class TraverserExtensions
	{
		public static ValueEnumerable<Children<TTraverser, T>, T> Children<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<Children<TTraverser, T>, T>);
		}

		public static ValueEnumerable<Children<TTraverser, T>, T> ChildrenAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<Children<TTraverser, T>, T>);
		}

		public static ValueEnumerable<Descendants<TTraverser, T>, T> Descendants<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<Descendants<TTraverser, T>, T>);
		}

		public static ValueEnumerable<Descendants<TTraverser, T>, T> DescendantsAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<Descendants<TTraverser, T>, T>);
		}

		public static ValueEnumerable<Ancestors<TTraverser, T>, T> Ancestors<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<Ancestors<TTraverser, T>, T>);
		}

		public static ValueEnumerable<Ancestors<TTraverser, T>, T> AncestorsAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<Ancestors<TTraverser, T>, T>);
		}

		public static ValueEnumerable<BeforeSelf<TTraverser, T>, T> BeforeSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<BeforeSelf<TTraverser, T>, T>);
		}

		public static ValueEnumerable<BeforeSelf<TTraverser, T>, T> BeforeSelfAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<BeforeSelf<TTraverser, T>, T>);
		}

		public static ValueEnumerable<AfterSelf<TTraverser, T>, T> AfterSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<AfterSelf<TTraverser, T>, T>);
		}

		public static ValueEnumerable<AfterSelf<TTraverser, T>, T> AfterSelfAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return default(ValueEnumerable<AfterSelf<TTraverser, T>, T>);
		}
	}
}
