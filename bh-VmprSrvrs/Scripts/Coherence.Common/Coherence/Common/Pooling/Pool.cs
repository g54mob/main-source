using System;
using System.Collections.Generic;
using System.Diagnostics;
using Coherence.Common.Pooling.Modules;
using Coherence.Common.Pooling.Storage;

namespace Coherence.Common.Pooling
{
	public class Pool<T> : IPool<T>
	{
		public class PoolBuilder
		{
			private readonly List<IPoolModule<T>> modules;

			private IPoolStorage<T> storage;

			private readonly Func<IPool<T>, T> objectGenerator;

			private bool useGuard;

			private bool isConcurrent;

			private bool built;

			private int prefillSize;

			private ActionsModule<T> actionsModule;

			public PoolBuilder(Func<IPool<T>, T> objectGenerator)
			{
			}

			public PoolBuilder Prefill(int prefillSize)
			{
				return null;
			}

			public PoolBuilder WithReturnAction(Action<T> action)
			{
				return null;
			}

			public PoolBuilder WithRentAction(Action<T> action)
			{
				return null;
			}

			public PoolBuilder WithModule(IPoolModule<T> module)
			{
				return null;
			}

			public PoolBuilder Concurrent()
			{
				return null;
			}

			public PoolBuilder WithNoGuard()
			{
				return null;
			}

			public Pool<T> Build()
			{
				return null;
			}

			private void AddActionsModule()
			{
			}

			[Conditional("DEBUG")]
			private void AddGuardModule()
			{
			}
		}

		internal const int DefaultPrefillSize = 32;

		private readonly List<IPoolModule<T>> modules;

		private readonly IPoolStorage<T> storage;

		private readonly Func<IPool<T>, T> objectGenerator;

		public static PoolBuilder Builder(Func<IPool<T>, T> objectGenerator)
		{
			return null;
		}

		protected Pool(Func<IPool<T>, T> objectGenerator, IPoolStorage<T> storage = null, IEnumerable<IPoolModule<T>> modules = null, int prefillSize = 32)
		{
		}

		private void Prefill(int prefillSize)
		{
		}

		public T Rent()
		{
			return default(T);
		}

		public void Return(T item)
		{
		}

		protected void AddModule(IPoolModule<T> module)
		{
		}

		private T GenerateObject()
		{
			return default(T);
		}

		private void ExecuteModulesOnRent(in T item)
		{
		}

		private void ExecuteModulesOnReturn(in T item)
		{
		}
	}
}
