using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ZLinq
{
	[StructLayout(LayoutKind.Auto)]
	public struct OfComponentT<TEnumerable, TComponent> : IValueEnumerator<TComponent>, IDisposable where TEnumerable : struct, IValueEnumerator<Transform> where TComponent : Component
	{
		private TEnumerable source;

		internal OfComponentT(TEnumerable source)
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
			Transform current2;
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
