using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Pools;

namespace HandlebarsDotNet
{
	public readonly struct Arguments : IEquatable<Arguments>, IEnumerable<object>, IEnumerable
	{
		private sealed class Enumerable : IEnumerable<object>, IEnumerable
		{
			private readonly Arguments _arguments;

			public Enumerable(in Arguments arguments)
			{
				_arguments = arguments;
			}

			public IEnumerator<object> GetEnumerator()
			{
				return Enumerator.Create(in _arguments);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private sealed class Enumerator : IEnumerator<object>, IEnumerator, IDisposable
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			private struct Policy : IInternalObjectPoolPolicy<Enumerator>
			{
				public Enumerator Create()
				{
					return new Enumerator();
				}

				public bool Return(Enumerator item)
				{
					item.Reset();
					return true;
				}
			}

			private static readonly InternalObjectPool<Enumerator, Policy> Pool = new InternalObjectPool<Enumerator, Policy>(default(Policy));

			private Arguments _arguments;

			private int _index;

			public object Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					if (_index == -1)
					{
						return null;
					}
					if (_arguments._useArray)
					{
						return _arguments._array[_index];
					}
					return _index switch
					{
						0 => _arguments._element0, 
						1 => _arguments._element1, 
						2 => _arguments._element2, 
						3 => _arguments._element3, 
						4 => _arguments._element4, 
						5 => _arguments._element5, 
						_ => Throw.IndexOutOfRangeException(), 
					};
				}
			}

			public static Enumerator Create(in Arguments arguments)
			{
				Enumerator enumerator = Pool.Get();
				enumerator._index = -1;
				enumerator._arguments = arguments;
				return enumerator;
			}

			private Enumerator()
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++_index < _arguments.Length;
			}

			public void Reset()
			{
				_index = -1;
			}

			public void Dispose()
			{
				_arguments = default(Arguments);
				Pool.Return(this);
			}
		}

		private static class Throw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static object IndexOutOfRangeException(string message = null)
			{
				throw new IndexOutOfRangeException(message);
			}
		}

		private readonly object[] _array;

		private readonly bool _useArray;

		private readonly object _element0;

		private readonly object _element1;

		private readonly object _element2;

		private readonly object _element3;

		private readonly object _element4;

		private readonly object _element5;

		public readonly int Length;

		public IReadOnlyDictionary<string, object> Hash
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Length == 0)
				{
					return HashParameterDictionary.Empty;
				}
				IReadOnlyDictionary<string, object> readOnlyDictionary = this[Length - 1] as HashParameterDictionary;
				return readOnlyDictionary ?? HashParameterDictionary.Empty;
			}
		}

		public object this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index < 0 || index >= Length)
				{
					Throw.IndexOutOfRangeException();
				}
				if (_useArray)
				{
					return _array[index];
				}
				return index switch
				{
					0 => _element0, 
					1 => _element1, 
					2 => _element2, 
					3 => _element3, 
					4 => _element4, 
					5 => _element5, 
					_ => Throw.IndexOutOfRangeException(), 
				};
			}
		}

		public object this[string name]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Hash?[name];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Arguments(int dummy = 0)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = null;
			_element1 = null;
			_element2 = null;
			_element3 = null;
			_element4 = null;
			_element5 = null;
			Length = dummy;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object arg1)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = arg1;
			_element1 = null;
			_element2 = null;
			_element3 = null;
			_element4 = null;
			_element5 = null;
			Length = 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object arg1, object arg2)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = arg1;
			_element1 = arg2;
			_element2 = null;
			_element3 = null;
			_element4 = null;
			_element5 = null;
			Length = 2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object arg1, object arg2, object arg3)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = arg1;
			_element1 = arg2;
			_element2 = arg3;
			_element3 = null;
			_element4 = null;
			_element5 = null;
			Length = 3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object arg1, object arg2, object arg3, object arg4)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = arg1;
			_element1 = arg2;
			_element2 = arg3;
			_element3 = arg4;
			_element4 = null;
			_element5 = null;
			Length = 4;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object arg1, object arg2, object arg3, object arg4, object arg5)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = arg1;
			_element1 = arg2;
			_element2 = arg3;
			_element3 = arg4;
			_element4 = arg5;
			_element5 = null;
			Length = 5;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)
		{
			this = default(Arguments);
			_useArray = false;
			_array = null;
			_element0 = arg1;
			_element1 = arg2;
			_element2 = arg3;
			_element3 = arg4;
			_element4 = arg5;
			_element5 = arg6;
			Length = 6;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Arguments(object[] args)
		{
			this = default(Arguments);
			_useArray = true;
			_array = args;
			Length = args.Length;
			_element0 = null;
			_element1 = null;
			_element2 = null;
			_element3 = null;
			_element4 = null;
			_element5 = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IEnumerator<object> GetEnumerator()
		{
			return Enumerator.Create(in this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IEnumerable<object> AsEnumerable()
		{
			return new Enumerable(in this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T At<T>(in int index)
		{
			object obj = this[index];
			if (obj == null)
			{
				return default(T);
			}
			if (obj is T)
			{
				return (T)obj;
			}
			return (T)TypeDescriptor.GetConverter(obj.GetType()).ConvertTo(obj, typeof(T));
		}

		public static implicit operator Arguments(object[] array)
		{
			if (array.Length != 0)
			{
				return new Arguments(array);
			}
			return new Arguments(0);
		}

		public bool Equals(Arguments other)
		{
			if (_useArray && _useArray == other._useArray)
			{
				if (Length != other.Length || _array.Length != other._array.Length)
				{
					return false;
				}
				for (int i = 0; i < _array.Length; i++)
				{
					if (!_array[i].Equals(other._array[i]))
					{
						return false;
					}
				}
				return true;
			}
			if (Length == other.Length && object.Equals(_element0, other._element0) && object.Equals(_element1, other._element1) && object.Equals(_element2, other._element2) && object.Equals(_element3, other._element3) && object.Equals(_element4, other._element4))
			{
				return object.Equals(_element5, other._element5);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Arguments other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = Length;
			using IEnumerator<object> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				num = (num * 397) ^ (enumerator.Current?.GetHashCode() ?? 0);
			}
			return num;
		}
	}
}
