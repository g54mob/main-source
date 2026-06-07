using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ActionCategoryMap
	{
		[Serializable]
		public class Entry
		{
			private sealed class igLTcwKCZEkMqhHIjidSFAHaqpmFA : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int tzqcUQDTKKWHrqHTplXdXKMfbiXB;

				private int bThdvKBIzdSNECTckJIGUbebFtrvA;

				private int CfRcqZWSdHsNtEeOfutjTxJMNZxp;

				public Entry BNUjQWqJHUeRmQYCvwDnywyfdlIw;

				private int mbdatijrnYkCbjEuBwCKzbYpynTJ;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return 0;
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
				public igLTcwKCZEkMqhHIjidSFAHaqpmFA(int P_0)
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
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				[IteratorStateMachine(typeof(igLTcwKCZEkMqhHIjidSFAHaqpmFA))]
				get
				{
					return null;
				}
			}

			public Entry()
			{
			}

			public Entry(int P_0)
			{
			}

			public Entry(Entry P_0)
			{
			}

			public void AddAction(int actionId)
			{
			}

			public bool InsertAction(int actionId, int index)
			{
				return false;
			}

			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				return false;
			}

			public void RemoveAction(int actionId)
			{
			}

			public int IndexOfAction(int id)
			{
				return 0;
			}

			public bool ContainsAction(int id)
			{
				return false;
			}

			public Entry Clone()
			{
				return null;
			}
		}

		private sealed class qlOvgOCOuIFMpKtoCMBPnDzNmamY : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int XTNwbLKbjOFDYLqmKXyRRAbzlGdD;

			private int VgDGMXbOgtEKolMemqlSkpjAimjq;

			private int xMIzByiYvLHZHUqNjHygYIEESxuK;

			public ActionCategoryMap GPeZmuHieprzDkHyhjRMjboFJQEt;

			private int GkCaDyfuwOWxFOsRQhAhZtjeKFxy;

			public int xkzcdBtzKfAbPuaqfREshKkbIIiS;

			private IEnumerator<int> SGqMKrmzdLGlEaYSdprTjFSRuBmh;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0;
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
			public qlOvgOCOuIFMpKtoCMBPnDzNmamY(int P_0)
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

			private void dKKDqoTJJyfHFrKygawtWZvuHkUf()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> list;

		[IteratorStateMachine(typeof(qlOvgOCOuIFMpKtoCMBPnDzNmamY))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return null;
		}

		public ActionCategoryMap()
		{
		}

		public ActionCategoryMap(ActionCategoryMap P_0)
		{
		}

		public void AddCategory(int id)
		{
		}

		public void RemoveCategory(int id)
		{
		}

		public bool ReorderCategory(int id, bool offsetDown)
		{
			return false;
		}

		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			return false;
		}

		public int IndexOfCategory(int id)
		{
			return 0;
		}

		public bool AddAction(int categoryId, int actionId)
		{
			return false;
		}

		public bool InsertAction(int categoryId, int actionId, int index)
		{
			return false;
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void RemoveAction(int categoryId, int actionId)
		{
		}

		public int IndexOfAction(int categoryId, int actionId)
		{
			return 0;
		}

		public ActionCategoryMap Clone()
		{
			return null;
		}
	}
}
