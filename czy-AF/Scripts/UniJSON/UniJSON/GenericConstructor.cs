using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace UniJSON
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct GenericConstructor<T, U> where T : IListTreeItem, IValue<T>
	{
		private delegate U Creator(ListTreeNode<T> src);

		private static Creator s_creator;

		private static V[] ArrayCreator<V>(ListTreeNode<T> src)
		{
			if (!src.IsArray())
			{
				throw new ArgumentException("value is not array");
			}
			return new V[src.GetArrayCount()];
		}

		private static Func<ListTreeNode<T>, U> GetCreator()
		{
			Type typeFromHandle = typeof(U);
			if (typeFromHandle.IsArray)
			{
				return GenericInvokeCallFactory.StaticFunc<ListTreeNode<T>, U>(typeof(GenericConstructor<T, U>).GetMethod("ArrayCreator", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeFromHandle.GetElementType()));
			}
			return (ListTreeNode<T> _s) => Activator.CreateInstance<U>();
		}

		public U Create(ListTreeNode<T> src)
		{
			if (s_creator == null)
			{
				s_creator = GetCreator().Invoke;
			}
			return s_creator(src);
		}
	}
}
