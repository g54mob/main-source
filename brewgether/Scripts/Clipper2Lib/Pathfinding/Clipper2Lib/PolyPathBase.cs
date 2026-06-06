using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public abstract class PolyPathBase : IEnumerable
	{
		private class NodeEnumerator : IEnumerator
		{
			private int position;

			private readonly List<PolyPathBase> _nodes;

			public object Current => null;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public NodeEnumerator(List<PolyPathBase> nodes)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Reset()
			{
			}
		}

		internal PolyPathBase? _parent;

		internal List<PolyPathBase> _childs;

		public bool IsHole => false;

		public int Level => 0;

		public int Count => 0;

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public PolyPathBase(PolyPathBase? parent = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetLevel()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool GetIsHole()
		{
			return false;
		}

		public abstract PolyPathBase AddChild(List<Point64> p);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
		}

		internal string ToStringInternal(int idx, int level)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
