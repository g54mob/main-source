using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Collections
{
	public ref struct ExtendedEnumerator<T>
	{
		private readonly IEnumerator _enumerator;

		private T _next;

		private int _index;

		private bool _hasNext;

		public readonly bool Any;

		public EnumeratorValue<T> Current { get; private set; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExtendedEnumerator<T> Create(IEnumerator enumerator)
		{
			return new ExtendedEnumerator<T>(enumerator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExtendedEnumerator<T, TEnumerator> Create<TEnumerator>(TEnumerator enumerator) where TEnumerator : IEnumerator<T>
		{
			return new ExtendedEnumerator<T, TEnumerator>(enumerator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ExtendedEnumerator(IEnumerator enumerator)
		{
			this = default(ExtendedEnumerator<T>);
			_enumerator = enumerator;
			PerformIteration();
			Any = _hasNext;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			if (!_hasNext)
			{
				return false;
			}
			PerformIteration();
			return true;
		}

		private void PerformIteration()
		{
			if (!_enumerator.MoveNext())
			{
				Current = (_hasNext ? new EnumeratorValue<T>(_next, _index++, isLast: true) : default(EnumeratorValue<T>));
				_hasNext = false;
				_next = default(T);
			}
			else if (!_hasNext)
			{
				_hasNext = true;
				_next = (T)_enumerator.Current;
			}
			else
			{
				Current = new EnumeratorValue<T>(_next, _index++, isLast: false);
				_next = (T)_enumerator.Current;
			}
		}
	}
	public ref struct ExtendedEnumerator<T, TEnumerator> where TEnumerator : IEnumerator<T>
	{
		private TEnumerator _enumerator;

		private T _next;

		private int _index;

		private bool _hasNext;

		public readonly bool Any;

		public EnumeratorValue<T> Current { get; private set; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ExtendedEnumerator(TEnumerator enumerator)
		{
			this = default(ExtendedEnumerator<T, TEnumerator>);
			_enumerator = enumerator;
			PerformIteration();
			Any = _hasNext;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			if (!_hasNext)
			{
				return false;
			}
			PerformIteration();
			return true;
		}

		private void PerformIteration()
		{
			if (!_enumerator.MoveNext())
			{
				Current = (_hasNext ? new EnumeratorValue<T>(_next, _index++, isLast: true) : default(EnumeratorValue<T>));
				_hasNext = false;
				_next = default(T);
			}
			else if (!_hasNext)
			{
				_hasNext = true;
				_next = _enumerator.Current;
			}
			else
			{
				Current = new EnumeratorValue<T>(_next, _index++, isLast: false);
				_next = _enumerator.Current;
			}
		}
	}
}
