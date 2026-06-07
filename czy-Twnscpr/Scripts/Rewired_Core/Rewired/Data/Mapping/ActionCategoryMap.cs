using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ActionCategoryMap
	{
		[Serializable]
		public class Entry
		{
			private sealed class WLihUuMEJdtuKwXufQERDoGtPYe : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
			{
				private int BkCCsqltFMRNvCZoZtUjDVFIQQJ;

				private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

				private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

				public Entry TiaUIShtPVkFOKyDFxywSfPUjyv;

				public int WshmrQVFMBwymgivrENdoSZMzyD;

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
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public WLihUuMEJdtuKwXufQERDoGtPYe(int _003C_003E1__state)
				{
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds => null;

			public Entry()
			{
			}

			public Entry(int categoryId)
			{
			}

			public Entry(Entry source)
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

		private sealed class gCzUyhEWkCLeoCScvIrfmIfsBMv : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

			public ActionCategoryMap TiaUIShtPVkFOKyDFxywSfPUjyv;

			public int SVZgnxAoEHFXqrJXIrUJrhKlIbxz;

			public int zqAmRDXyiostwIxAJcZOxNfUnJq;

			public int bkWEaBSaXBUhVuQgtPuqJbhjMQM;

			public int SipFNvkNpTdfRdlnAKeBaOMcMZCh;

			public IEnumerator<int> hHKuRisHZzrLyFGnhNmNTcxoDAE;

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
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public gCzUyhEWkCLeoCScvIrfmIfsBMv(int _003C_003E1__state)
			{
			}

			private void flUkuadwRLAAcXqNRhRdiTKNFdD()
			{
			}
		}

		[SerializeField]
		[CustomObfuscation]
		private List<Entry> list;

		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return null;
		}

		public ActionCategoryMap()
		{
		}

		public ActionCategoryMap(ActionCategoryMap source)
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
