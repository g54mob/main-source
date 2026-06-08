using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HandlebarsDotNet.Pools;

namespace HandlebarsDotNet.Collections
{
	internal readonly struct ImmutableStack<T>
	{
		private sealed class Node : IDisposable
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			private struct Policy : IInternalObjectPoolPolicy<Node>
			{
				public Node Create()
				{
					return new Node();
				}

				public bool Return(Node item)
				{
					item.Parent = null;
					item.Value = default(T);
					return true;
				}
			}

			private static readonly InternalObjectPool<Node, Policy> Pool = new InternalObjectPool<Node, Policy>(default(Policy));

			public Node Parent;

			public T Value;

			public static Node Create(T value = default(T), Node parent = null)
			{
				Node node = Pool.Get();
				node.Value = value;
				node.Parent = parent;
				return node;
			}

			private Node()
			{
			}

			public void Dispose()
			{
				Pool.Return(this);
			}
		}

		private readonly Node _container;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ImmutableStack(T value, Node parent)
			: this(Node.Create(value, parent))
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ImmutableStack(Node container)
		{
			_container = container;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ImmutableStack<T> Push(T value)
		{
			return new ImmutableStack<T>(value, _container);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Peek()
		{
			if (_container != null)
			{
				return _container.Value;
			}
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ImmutableStack<T> Pop(out T value)
		{
			if (_container == null)
			{
				value = default(T);
				return this;
			}
			value = _container.Value;
			Node parent = _container.Parent;
			_container.Dispose();
			return new ImmutableStack<T>(parent);
		}
	}
}
