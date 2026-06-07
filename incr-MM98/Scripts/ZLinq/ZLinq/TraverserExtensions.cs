using ZLinq.Traversables;

namespace ZLinq
{
	public static class TraverserExtensions
	{
		public static ValueEnumerable<Children<TTraverser, T>, T> Children<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<Children<TTraverser, T>, T>(new Children<TTraverser, T>(traverser, withSelf: false));
		}

		public static ValueEnumerable<Children<TTraverser, T>, T> ChildrenAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<Children<TTraverser, T>, T>(new Children<TTraverser, T>(traverser, withSelf: true));
		}

		public static ValueEnumerable<Descendants<TTraverser, T>, T> Descendants<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<Descendants<TTraverser, T>, T>(new Descendants<TTraverser, T>(traverser, withSelf: false));
		}

		public static ValueEnumerable<Descendants<TTraverser, T>, T> DescendantsAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<Descendants<TTraverser, T>, T>(new Descendants<TTraverser, T>(traverser, withSelf: true));
		}

		public static ValueEnumerable<Ancestors<TTraverser, T>, T> Ancestors<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<Ancestors<TTraverser, T>, T>(new Ancestors<TTraverser, T>(traverser, withSelf: false));
		}

		public static ValueEnumerable<Ancestors<TTraverser, T>, T> AncestorsAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<Ancestors<TTraverser, T>, T>(new Ancestors<TTraverser, T>(traverser, withSelf: true));
		}

		public static ValueEnumerable<BeforeSelf<TTraverser, T>, T> BeforeSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<BeforeSelf<TTraverser, T>, T>(new BeforeSelf<TTraverser, T>(traverser, withSelf: false));
		}

		public static ValueEnumerable<BeforeSelf<TTraverser, T>, T> BeforeSelfAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<BeforeSelf<TTraverser, T>, T>(new BeforeSelf<TTraverser, T>(traverser, withSelf: true));
		}

		public static ValueEnumerable<AfterSelf<TTraverser, T>, T> AfterSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<AfterSelf<TTraverser, T>, T>(new AfterSelf<TTraverser, T>(traverser, withSelf: false));
		}

		public static ValueEnumerable<AfterSelf<TTraverser, T>, T> AfterSelfAndSelf<TTraverser, T>(this TTraverser traverser) where TTraverser : struct, ITraverser<TTraverser, T>
		{
			return new ValueEnumerable<AfterSelf<TTraverser, T>, T>(new AfterSelf<TTraverser, T>(traverser, withSelf: true));
		}
	}
}
