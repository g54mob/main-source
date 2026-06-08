using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Jobberwocky.TriangleNet.Topology;

namespace Jobberwocky.TriangleNet
{
	public class TrianglePool : ICollection<Triangle>, IEnumerable<Triangle>, IEnumerable
	{
		private class Enumerator : IEnumerator<Triangle>, IDisposable, IEnumerator
		{
			private int count;

			private Triangle[][] pool;

			private Triangle current;

			private int index;

			private int offset;

			public Triangle Current => current;

			object IEnumerator.Current => current;

			public Enumerator(TrianglePool pool)
			{
				count = pool.Count;
				this.pool = pool.pool;
				index = 0;
				offset = 0;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				while (index < count)
				{
					current = pool[offset / 1024][offset % 1024];
					offset++;
					if (current.hash >= 0)
					{
						index++;
						return true;
					}
				}
				return false;
			}

			public void Reset()
			{
				index = (offset = 0);
			}
		}

		private sealed class _003CSample_003Ed__9 : IEnumerable<Triangle>, IEnumerable, IEnumerator<Triangle>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private Triangle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private int k;

			public int _003C_003E3__k;

			private Random random;

			public Random _003C_003E3__random;

			public TrianglePool _003C_003E4__this;

			private int _003Ci_003E5__1;

			private int _003Ccount_003E5__2;

			private Triangle _003Ct_003E5__3;

			Triangle IEnumerator<Triangle>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CSample_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Ccount_003E5__2 = _003C_003E4__this.Count;
					if (k > _003Ccount_003E5__2)
					{
						k = _003Ccount_003E5__2;
					}
					break;
				case 1:
					_003C_003E1__state = -1;
					break;
				}
				while (k > 0)
				{
					_003Ci_003E5__1 = random.Next(0, _003Ccount_003E5__2);
					_003Ct_003E5__3 = _003C_003E4__this.pool[_003Ci_003E5__1 / 1024][_003Ci_003E5__1 % 1024];
					if (_003Ct_003E5__3.hash >= 0)
					{
						k--;
						_003C_003E2__current = _003Ct_003E5__3;
						_003C_003E1__state = 1;
						return true;
					}
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<Triangle> IEnumerable<Triangle>.GetEnumerator()
			{
				_003CSample_003Ed__9 _003CSample_003Ed__10;
				if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Thread.CurrentThread.ManagedThreadId)
				{
					_003C_003E1__state = 0;
					_003CSample_003Ed__10 = this;
				}
				else
				{
					_003CSample_003Ed__10 = new _003CSample_003Ed__9(0);
					_003CSample_003Ed__10._003C_003E4__this = _003C_003E4__this;
				}
				_003CSample_003Ed__10.k = _003C_003E3__k;
				_003CSample_003Ed__10.random = _003C_003E3__random;
				return _003CSample_003Ed__10;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Triangle>)this).GetEnumerator();
			}
		}

		private int size;

		private int count;

		private Triangle[][] pool;

		private Stack<Triangle> stack;

		public int Count => count - stack.Count;

		public bool IsReadOnly => true;

		public TrianglePool()
		{
			size = 0;
			int num = Math.Max(1, 64);
			pool = new Triangle[num][];
			pool[0] = new Triangle[1024];
			stack = new Stack<Triangle>(1024);
		}

		public Triangle Get()
		{
			Triangle triangle;
			if (stack.Count > 0)
			{
				triangle = stack.Pop();
				triangle.hash = -triangle.hash - 1;
				Cleanup(triangle);
			}
			else if (count < size)
			{
				triangle = pool[count / 1024][count % 1024];
				triangle.id = triangle.hash;
				Cleanup(triangle);
				count++;
			}
			else
			{
				triangle = new Triangle();
				triangle.hash = size;
				triangle.id = triangle.hash;
				int num = size / 1024;
				if (pool[num] == null)
				{
					pool[num] = new Triangle[1024];
					if (num + 1 == pool.Length)
					{
						Array.Resize(ref pool, 2 * pool.Length);
					}
				}
				pool[num][size % 1024] = triangle;
				count = ++size;
			}
			return triangle;
		}

		public void Release(Triangle triangle)
		{
			stack.Push(triangle);
			triangle.hash = -triangle.hash - 1;
		}

		internal IEnumerable<Triangle> Sample(int k, Random random)
		{
			return new _003CSample_003Ed__9(-2)
			{
				_003C_003E4__this = this,
				_003C_003E3__k = k,
				_003C_003E3__random = random
			};
		}

		private void Cleanup(Triangle triangle)
		{
			triangle.label = 0;
			triangle.area = 0.0;
			triangle.infected = false;
			for (int i = 0; i < 3; i++)
			{
				triangle.vertices[i] = null;
				triangle.subsegs[i] = default(Osub);
				triangle.neighbors[i] = default(Otri);
			}
		}

		public void Add(Triangle item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			stack.Clear();
			int num = size / 1024 + 1;
			for (int i = 0; i < num; i++)
			{
				Triangle[] array = pool[i];
				int num2 = (size - i * 1024) % 1024;
				for (int j = 0; j < num2; j++)
				{
					array[j] = null;
				}
			}
			size = (count = 0);
		}

		public bool Contains(Triangle item)
		{
			int hash = item.hash;
			if (hash < 0 || hash > size)
			{
				return false;
			}
			return pool[hash / 1024][hash % 1024].hash >= 0;
		}

		public void CopyTo(Triangle[] array, int index)
		{
			IEnumerator<Triangle> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				array[index] = enumerator.Current;
				index++;
			}
		}

		public bool Remove(Triangle item)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<Triangle> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
