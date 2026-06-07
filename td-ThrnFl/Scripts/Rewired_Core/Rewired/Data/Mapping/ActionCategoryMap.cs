using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ActionCategoryMap
	{
		[Serializable]
		public class Entry
		{
			private sealed class WJKjvekrgRvKwwIiffoGtBAkMRGN : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int TkjfgOhRkZMhLnjtxylTwaBpCVYw;

				private int HvkMwGcVUajBMWBGoAVUEAtlkZZCb;

				private int seOvoDoIhEXrtForvePliCoAxCTC;

				public Entry pnFWRIQjuPRZiXkqlEMdBMjvkFqP;

				private int EiichyHLCNaudGmWNMhCaUNhjSdtB;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return HvkMwGcVUajBMWBGoAVUEAtlkZZCb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return HvkMwGcVUajBMWBGoAVUEAtlkZZCb;
					}
				}

				[DebuggerHidden]
				public WJKjvekrgRvKwwIiffoGtBAkMRGN(int P_0)
				{
					TkjfgOhRkZMhLnjtxylTwaBpCVYw = P_0;
					seOvoDoIhEXrtForvePliCoAxCTC = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int tkjfgOhRkZMhLnjtxylTwaBpCVYw = TkjfgOhRkZMhLnjtxylTwaBpCVYw;
					Entry entry = pnFWRIQjuPRZiXkqlEMdBMjvkFqP;
					switch (tkjfgOhRkZMhLnjtxylTwaBpCVYw)
					{
					default:
						return false;
					case 0:
						TkjfgOhRkZMhLnjtxylTwaBpCVYw = -1;
						if (entry.actionIds == null)
						{
							return false;
						}
						EiichyHLCNaudGmWNMhCaUNhjSdtB = 0;
						break;
					case 1:
						TkjfgOhRkZMhLnjtxylTwaBpCVYw = -1;
						EiichyHLCNaudGmWNMhCaUNhjSdtB++;
						break;
					}
					if (EiichyHLCNaudGmWNMhCaUNhjSdtB < entry.actionIds.Count)
					{
						HvkMwGcVUajBMWBGoAVUEAtlkZZCb = entry.actionIds[EiichyHLCNaudGmWNMhCaUNhjSdtB];
						TkjfgOhRkZMhLnjtxylTwaBpCVYw = 1;
						return true;
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
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					WJKjvekrgRvKwwIiffoGtBAkMRGN wJKjvekrgRvKwwIiffoGtBAkMRGN;
					if (TkjfgOhRkZMhLnjtxylTwaBpCVYw == -2 && seOvoDoIhEXrtForvePliCoAxCTC == Environment.CurrentManagedThreadId)
					{
						TkjfgOhRkZMhLnjtxylTwaBpCVYw = 0;
						wJKjvekrgRvKwwIiffoGtBAkMRGN = this;
					}
					else
					{
						wJKjvekrgRvKwwIiffoGtBAkMRGN = new WJKjvekrgRvKwwIiffoGtBAkMRGN(0);
						wJKjvekrgRvKwwIiffoGtBAkMRGN.pnFWRIQjuPRZiXkqlEMdBMjvkFqP = pnFWRIQjuPRZiXkqlEMdBMjvkFqP;
					}
					return wJKjvekrgRvKwwIiffoGtBAkMRGN;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<int>)this).GetEnumerator();
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				[IteratorStateMachine(typeof(WJKjvekrgRvKwwIiffoGtBAkMRGN))]
				get
				{
					return new WJKjvekrgRvKwwIiffoGtBAkMRGN(-2)
					{
						pnFWRIQjuPRZiXkqlEMdBMjvkFqP = this
					};
				}
			}

			public Entry()
			{
				actionIds = new List<int>();
			}

			public Entry(int P_0)
				: this()
			{
				categoryId = P_0;
			}

			public Entry(Entry P_0)
			{
				actionIds = ListTools.ShallowCopy(P_0.actionIds);
			}

			public void AddAction(int actionId)
			{
				if (!actionIds.Contains(actionId))
				{
					actionIds.Add(actionId);
				}
			}

			public bool InsertAction(int actionId, int index)
			{
				if (index < 0)
				{
					return false;
				}
				if (actionIds.Contains(actionId))
				{
					return true;
				}
				if (index >= actionIds.Count)
				{
					actionIds.Add(actionId);
				}
				else
				{
					actionIds.Insert(index, actionId);
				}
				return true;
			}

			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				int num = IndexOfAction(actionId);
				if (num < 0)
				{
					return false;
				}
				if (!offsetDown && num == 0)
				{
					return false;
				}
				if (offsetDown && num >= actionIds.Count - 1)
				{
					return false;
				}
				if (!offsetNow)
				{
					return true;
				}
				int value = actionIds[num];
				if (offsetDown)
				{
					actionIds[num] = actionIds[num + 1];
					actionIds[num + 1] = value;
				}
				else
				{
					actionIds[num] = actionIds[num - 1];
					actionIds[num - 1] = value;
				}
				return true;
			}

			public void RemoveAction(int actionId)
			{
				int num = IndexOfAction(actionId);
				if (num >= 0)
				{
					actionIds.RemoveAt(num);
				}
			}

			public int IndexOfAction(int id)
			{
				if (actionIds == null)
				{
					return -1;
				}
				for (int i = 0; i < actionIds.Count; i++)
				{
					if (actionIds[i] == id)
					{
						return i;
					}
				}
				return -1;
			}

			public bool ContainsAction(int id)
			{
				return IndexOfAction(id) >= 0;
			}

			public Entry Clone()
			{
				return new Entry(this);
			}
		}

		private sealed class EpLKjYaBVTnAfarKSCrJsdsZiAGU : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int bqMpwjwESFTLGWfMMMdkwUFpFtLf;

			private int fxWzLFPCTucCuDeUoVyMABmOXQVKA;

			private int XPLgSuQgQMlRDHCrrFnaajHEAcMxA;

			public ActionCategoryMap cNvgvaxPXeDrRpNClBiUbMnPkkuYA;

			private int eHNsCkFUHVvtBBEfYfPzmWueBdPEA;

			public int DmegbNLdtmjBNnOvrHaeGbzduXQh;

			private IEnumerator<int> qevZOrQCAKIgIjNqnsyLIcIZCzWg;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return fxWzLFPCTucCuDeUoVyMABmOXQVKA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return fxWzLFPCTucCuDeUoVyMABmOXQVKA;
				}
			}

			[DebuggerHidden]
			public EpLKjYaBVTnAfarKSCrJsdsZiAGU(int P_0)
			{
				bqMpwjwESFTLGWfMMMdkwUFpFtLf = P_0;
				XPLgSuQgQMlRDHCrrFnaajHEAcMxA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = bqMpwjwESFTLGWfMMMdkwUFpFtLf;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						ZcLzrgplqnoJZchCybfrjRyaCtweA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = bqMpwjwESFTLGWfMMMdkwUFpFtLf;
					ActionCategoryMap actionCategoryMap = cNvgvaxPXeDrRpNClBiUbMnPkkuYA;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						bqMpwjwESFTLGWfMMMdkwUFpFtLf = -1;
						if (actionCategoryMap.list == null)
						{
							return false;
						}
						int num2 = actionCategoryMap.IndexOfCategory(eHNsCkFUHVvtBBEfYfPzmWueBdPEA);
						if (num2 < 0)
						{
							return false;
						}
						qevZOrQCAKIgIjNqnsyLIcIZCzWg = actionCategoryMap.list[num2].ActionIds.GetEnumerator();
						bqMpwjwESFTLGWfMMMdkwUFpFtLf = -3;
						break;
					}
					case 1:
						bqMpwjwESFTLGWfMMMdkwUFpFtLf = -3;
						break;
					}
					if (qevZOrQCAKIgIjNqnsyLIcIZCzWg.MoveNext())
					{
						int current = qevZOrQCAKIgIjNqnsyLIcIZCzWg.Current;
						fxWzLFPCTucCuDeUoVyMABmOXQVKA = current;
						bqMpwjwESFTLGWfMMMdkwUFpFtLf = 1;
						return true;
					}
					ZcLzrgplqnoJZchCybfrjRyaCtweA();
					qevZOrQCAKIgIjNqnsyLIcIZCzWg = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void ZcLzrgplqnoJZchCybfrjRyaCtweA()
			{
				bqMpwjwESFTLGWfMMMdkwUFpFtLf = -1;
				if (qevZOrQCAKIgIjNqnsyLIcIZCzWg != null)
				{
					qevZOrQCAKIgIjNqnsyLIcIZCzWg.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				EpLKjYaBVTnAfarKSCrJsdsZiAGU epLKjYaBVTnAfarKSCrJsdsZiAGU;
				if (bqMpwjwESFTLGWfMMMdkwUFpFtLf == -2 && XPLgSuQgQMlRDHCrrFnaajHEAcMxA == Environment.CurrentManagedThreadId)
				{
					bqMpwjwESFTLGWfMMMdkwUFpFtLf = 0;
					epLKjYaBVTnAfarKSCrJsdsZiAGU = this;
				}
				else
				{
					epLKjYaBVTnAfarKSCrJsdsZiAGU = new EpLKjYaBVTnAfarKSCrJsdsZiAGU(0);
					epLKjYaBVTnAfarKSCrJsdsZiAGU.cNvgvaxPXeDrRpNClBiUbMnPkkuYA = cNvgvaxPXeDrRpNClBiUbMnPkkuYA;
				}
				epLKjYaBVTnAfarKSCrJsdsZiAGU.eHNsCkFUHVvtBBEfYfPzmWueBdPEA = DmegbNLdtmjBNnOvrHaeGbzduXQh;
				return epLKjYaBVTnAfarKSCrJsdsZiAGU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> list;

		[IteratorStateMachine(typeof(EpLKjYaBVTnAfarKSCrJsdsZiAGU))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new EpLKjYaBVTnAfarKSCrJsdsZiAGU(-2)
			{
				cNvgvaxPXeDrRpNClBiUbMnPkkuYA = this,
				DmegbNLdtmjBNnOvrHaeGbzduXQh = categoryId
			};
		}

		public ActionCategoryMap()
		{
			list = new List<Entry>();
		}

		public ActionCategoryMap(ActionCategoryMap P_0)
		{
			if (P_0.list != null)
			{
				list = new List<Entry>(P_0.list.Count);
				for (int i = 0; i < P_0.list.Count; i++)
				{
					list[i] = P_0.list[i].Clone();
				}
			}
		}

		public void AddCategory(int id)
		{
			list.Add(new Entry(id));
		}

		public void RemoveCategory(int id)
		{
			int num = IndexOfCategory(id);
			if (num >= 0)
			{
				list.RemoveAt(num);
			}
		}

		public bool ReorderCategory(int id, bool offsetDown)
		{
			int num = IndexOfCategory(id);
			if (num < 0)
			{
				return false;
			}
			if (!offsetDown && num == 0)
			{
				return false;
			}
			if (offsetDown && num >= list.Count - 1)
			{
				return false;
			}
			Entry value = list[num];
			if (offsetDown)
			{
				list[num] = list[num + 1];
				list[num + 1] = value;
			}
			else
			{
				list[num] = list[num - 1];
				list[num - 1] = value;
			}
			return true;
		}

		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			if (list == null)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].ContainsAction(actionId))
				{
					list[i].RemoveAction(actionId);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].categoryId == newCategoryId)
				{
					list[j].AddAction(actionId);
					result = true;
				}
			}
			return result;
		}

		public int IndexOfCategory(int id)
		{
			if (list == null)
			{
				return -1;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].categoryId == id)
				{
					return i;
				}
			}
			return -1;
		}

		public bool AddAction(int categoryId, int actionId)
		{
			if (list == null)
			{
				return false;
			}
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			list[num].AddAction(actionId);
			return true;
		}

		public bool InsertAction(int categoryId, int actionId, int index)
		{
			if (index < 0)
			{
				return false;
			}
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			return list[num].InsertAction(actionId, index);
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			return list[num].ReorderAction(actionId, offsetDown, offsetNow);
		}

		public void RemoveAction(int categoryId, int actionId)
		{
			int num = IndexOfCategory(categoryId);
			if (num >= 0)
			{
				list[num].RemoveAction(actionId);
			}
		}

		public int IndexOfAction(int categoryId, int actionId)
		{
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return -1;
			}
			return list[num].IndexOfAction(actionId);
		}

		public ActionCategoryMap Clone()
		{
			return new ActionCategoryMap(this);
		}
	}
}
