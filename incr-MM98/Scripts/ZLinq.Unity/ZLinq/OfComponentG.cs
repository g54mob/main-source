using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ZLinq
{
	[StructLayout(LayoutKind.Auto)]
	public struct OfComponentG<TEnumerable, TComponent> : IValueEnumerator<TComponent>, IDisposable where TEnumerable : struct, IValueEnumerator<GameObject> where TComponent : Component
	{
		private TEnumerable source;

		internal OfComponentG(TEnumerable source)
		{
			this.source = source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TComponent> span)
		{
			span = default(ReadOnlySpan<TComponent>);
			return false;
		}

		public bool TryGetNext(out TComponent current)
		{
			GameObject current2;
			while (source.TryGetNext(out current2))
			{
				TComponent component = current2.GetComponent<TComponent>();
				if (component != null)
				{
					current = component;
					return true;
				}
			}
			current = null;
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}

		public bool TryCopyTo(Span<TComponent> destination, Index offset)
		{
			return false;
		}
	}
}
