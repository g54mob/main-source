using System;
using System.Collections;

namespace Noesis
{
	public static class LogicalTreeHelper
	{
		private struct ChildrenEnumerable : IEnumerable
		{
			private struct Enumerator : IEnumerator
			{
				private DependencyObject _parent;

				private int _index;

				private int _count;

				object IEnumerator.Current => null;

				public object Current => null;

				public bool MoveNext()
				{
					return false;
				}

				public void Reset()
				{
				}

				public void Dispose()
				{
				}

				public Enumerator(DependencyObject parent)
				{
					_parent = null;
					_index = 0;
					_count = 0;
				}
			}

			private DependencyObject _parent;

			public ChildrenEnumerable(DependencyObject parent)
			{
				_parent = null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static DependencyObject GetParent(DependencyObject current)
		{
			return null;
		}

		public static IEnumerable GetChildren(DependencyObject current)
		{
			return null;
		}

		public static DependencyObject FindLogicalNode(DependencyObject current, string name)
		{
			return null;
		}

		private static DependencyObject GetParentHelper(DependencyObject current)
		{
			return null;
		}

		private static int GetChildrenCountHelper(DependencyObject current)
		{
			return 0;
		}

		private static IntPtr GetChildHelper(DependencyObject current, int index)
		{
			return (IntPtr)0;
		}

		private static IntPtr FindLogicalNodeHelper(DependencyObject current, string name)
		{
			return (IntPtr)0;
		}
	}
}
