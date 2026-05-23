using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Models;
using UnityEngine;

namespace Libs
{
	public struct Vector2IntBundle : IEquatable<Vector2IntBundle>
	{
		[CompilerGenerated]
		private sealed class _003CToStructureAddrs_003Ed__29 : IEnumerable<StructureAddr>, IEnumerable, IEnumerator<StructureAddr>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private StructureAddr _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Vector2IntBundle _003C_003E4__this;

			public Vector2IntBundle _003C_003E3___003C_003E4__this;

			private Vector2Int[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			StructureAddr IEnumerator<StructureAddr>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(StructureAddr);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CToStructureAddrs_003Ed__29(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<StructureAddr> IEnumerable<StructureAddr>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public Vector2Int[] array;

		public Vector2Int position => default(Vector2Int);

		public Vector2Int tail => default(Vector2Int);

		public int x => 0;

		public int y => 0;

		public int length => 0;

		public bool IsEmpty => false;

		public Vector2Int this[int index]
		{
			get
			{
				return default(Vector2Int);
			}
			set
			{
			}
		}

		public Vector2IntBundle(RectInt rect)
		{
			array = null;
		}

		public Vector2IntBundle(Vector2Int[] arr)
		{
			array = null;
		}

		public Vector2IntBundle(List<Vector2Int> arr)
		{
			array = null;
		}

		public Vector2IntBundle(Vector2Int v2i)
		{
			array = null;
		}

		public Vector2IntBundle(int startX, int startY, int length = 1, Dir.Rot rot = Dir.Rot.R)
		{
			array = null;
		}

		public Vector2IntBundle(Vector2Int start, Vector2Int end)
		{
			array = null;
		}

		public Vector2IntBundle(Vector2IntBundle other, Func<Vector2Int, Vector2Int> func)
		{
			array = null;
		}

		public Vector2IntBundle(Vector2IntBundle old, int newLength)
		{
			array = null;
		}

		public override string ToString()
		{
			return null;
		}

		public static explicit operator Vector2IntBundle(RectInt self)
		{
			return default(Vector2IntBundle);
		}

		public static Vector2IntBundle operator +(Vector2IntBundle self, Vector2Int offset)
		{
			return default(Vector2IntBundle);
		}

		public static Vector2IntBundle operator +(Vector2IntBundle self, Vector2IntBundle add)
		{
			return default(Vector2IntBundle);
		}

		public bool Equals(Vector2IntBundle other)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CToStructureAddrs_003Ed__29))]
		public IEnumerable<StructureAddr> ToStructureAddrs()
		{
			return null;
		}

		public bool Contains(Vector2Int pos)
		{
			return false;
		}

		public bool Contains(IEnumerable<Vector2Int> positions)
		{
			return false;
		}

		public void Resize(int newLength)
		{
		}

		public static Vector2IntBundle Create(Vector2Int from, Vector2Int to)
		{
			return default(Vector2IntBundle);
		}
	}
}
