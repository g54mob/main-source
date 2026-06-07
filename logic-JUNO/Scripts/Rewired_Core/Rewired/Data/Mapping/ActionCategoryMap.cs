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
			private sealed class nOqGPgqypyOsVdpnEAMWcBmJvKKl : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int oULoQCzMjeBIgcpuKcOFlnbKVfER;

				private int udUTTKwwPDXxhZGXXrzUROZYvnJi;

				private int PAcZWXsCTjtBCYFnKYMjnsulnJLp;

				public Entry AuzqiMCkvyRcZKXfGiPdGhDCzlwF;

				private int vQIFMyHhHaXuEjyNwmXIPstAcwns;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return udUTTKwwPDXxhZGXXrzUROZYvnJi;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return udUTTKwwPDXxhZGXXrzUROZYvnJi;
					}
				}

				[DebuggerHidden]
				public nOqGPgqypyOsVdpnEAMWcBmJvKKl(int P_0)
				{
					oULoQCzMjeBIgcpuKcOFlnbKVfER = P_0;
					PAcZWXsCTjtBCYFnKYMjnsulnJLp = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = oULoQCzMjeBIgcpuKcOFlnbKVfER;
					Entry auzqiMCkvyRcZKXfGiPdGhDCzlwF = AuzqiMCkvyRcZKXfGiPdGhDCzlwF;
					switch (num)
					{
					default:
						return false;
					case 0:
						oULoQCzMjeBIgcpuKcOFlnbKVfER = -1;
						if (auzqiMCkvyRcZKXfGiPdGhDCzlwF.actionIds == null)
						{
							return false;
						}
						vQIFMyHhHaXuEjyNwmXIPstAcwns = 0;
						break;
					case 1:
						oULoQCzMjeBIgcpuKcOFlnbKVfER = -1;
						vQIFMyHhHaXuEjyNwmXIPstAcwns++;
						break;
					}
					if (vQIFMyHhHaXuEjyNwmXIPstAcwns < auzqiMCkvyRcZKXfGiPdGhDCzlwF.actionIds.Count)
					{
						udUTTKwwPDXxhZGXXrzUROZYvnJi = auzqiMCkvyRcZKXfGiPdGhDCzlwF.actionIds[vQIFMyHhHaXuEjyNwmXIPstAcwns];
						oULoQCzMjeBIgcpuKcOFlnbKVfER = 1;
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
					nOqGPgqypyOsVdpnEAMWcBmJvKKl nOqGPgqypyOsVdpnEAMWcBmJvKKl2;
					if (oULoQCzMjeBIgcpuKcOFlnbKVfER == -2 && PAcZWXsCTjtBCYFnKYMjnsulnJLp == Environment.CurrentManagedThreadId)
					{
						oULoQCzMjeBIgcpuKcOFlnbKVfER = 0;
						nOqGPgqypyOsVdpnEAMWcBmJvKKl2 = this;
					}
					else
					{
						nOqGPgqypyOsVdpnEAMWcBmJvKKl2 = new nOqGPgqypyOsVdpnEAMWcBmJvKKl(0);
						nOqGPgqypyOsVdpnEAMWcBmJvKKl2.AuzqiMCkvyRcZKXfGiPdGhDCzlwF = AuzqiMCkvyRcZKXfGiPdGhDCzlwF;
					}
					return nOqGPgqypyOsVdpnEAMWcBmJvKKl2;
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
				[IteratorStateMachine(typeof(nOqGPgqypyOsVdpnEAMWcBmJvKKl))]
				get
				{
					return new nOqGPgqypyOsVdpnEAMWcBmJvKKl(-2)
					{
						AuzqiMCkvyRcZKXfGiPdGhDCzlwF = this
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

		private sealed class lyrWhUebSidYYfFJpFkRvYKgAsOn : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int AIsrOlmMHeeRvXFRlfsobndYFvHNA;

			private int UJcybJXaUPCVBrNTRCGWEmYxetPJ;

			private int gwtCzkCrDvPToYZiMOFugAbbRYOr;

			public ActionCategoryMap NTTcOshpSRgpeuPVWESAAHFkbAmgb;

			private int BmfxZiZkOipYqArsxhpxjBQXHiJI;

			public int sZUzXJDuaZtvsuUDOrlqXbLQRSKr;

			private IEnumerator<int> FPVsabOBXzpYrgKrWhWBLDayTsIv;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return UJcybJXaUPCVBrNTRCGWEmYxetPJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UJcybJXaUPCVBrNTRCGWEmYxetPJ;
				}
			}

			[DebuggerHidden]
			public lyrWhUebSidYYfFJpFkRvYKgAsOn(int P_0)
			{
				AIsrOlmMHeeRvXFRlfsobndYFvHNA = P_0;
				gwtCzkCrDvPToYZiMOFugAbbRYOr = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int aIsrOlmMHeeRvXFRlfsobndYFvHNA = AIsrOlmMHeeRvXFRlfsobndYFvHNA;
				if (aIsrOlmMHeeRvXFRlfsobndYFvHNA == -3 || aIsrOlmMHeeRvXFRlfsobndYFvHNA == 1)
				{
					try
					{
					}
					finally
					{
						grrGOklfNEBswvDoHJcpeYhLThoF();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int aIsrOlmMHeeRvXFRlfsobndYFvHNA = AIsrOlmMHeeRvXFRlfsobndYFvHNA;
					ActionCategoryMap nTTcOshpSRgpeuPVWESAAHFkbAmgb = NTTcOshpSRgpeuPVWESAAHFkbAmgb;
					switch (aIsrOlmMHeeRvXFRlfsobndYFvHNA)
					{
					default:
						return false;
					case 0:
					{
						AIsrOlmMHeeRvXFRlfsobndYFvHNA = -1;
						if (nTTcOshpSRgpeuPVWESAAHFkbAmgb.list == null)
						{
							return false;
						}
						int num = nTTcOshpSRgpeuPVWESAAHFkbAmgb.IndexOfCategory(BmfxZiZkOipYqArsxhpxjBQXHiJI);
						if (num < 0)
						{
							return false;
						}
						FPVsabOBXzpYrgKrWhWBLDayTsIv = nTTcOshpSRgpeuPVWESAAHFkbAmgb.list[num].ActionIds.GetEnumerator();
						AIsrOlmMHeeRvXFRlfsobndYFvHNA = -3;
						break;
					}
					case 1:
						AIsrOlmMHeeRvXFRlfsobndYFvHNA = -3;
						break;
					}
					if (FPVsabOBXzpYrgKrWhWBLDayTsIv.MoveNext())
					{
						int current = FPVsabOBXzpYrgKrWhWBLDayTsIv.Current;
						UJcybJXaUPCVBrNTRCGWEmYxetPJ = current;
						AIsrOlmMHeeRvXFRlfsobndYFvHNA = 1;
						return true;
					}
					grrGOklfNEBswvDoHJcpeYhLThoF();
					FPVsabOBXzpYrgKrWhWBLDayTsIv = null;
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

			private void grrGOklfNEBswvDoHJcpeYhLThoF()
			{
				AIsrOlmMHeeRvXFRlfsobndYFvHNA = -1;
				if (FPVsabOBXzpYrgKrWhWBLDayTsIv != null)
				{
					FPVsabOBXzpYrgKrWhWBLDayTsIv.Dispose();
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
				lyrWhUebSidYYfFJpFkRvYKgAsOn lyrWhUebSidYYfFJpFkRvYKgAsOn2;
				if (AIsrOlmMHeeRvXFRlfsobndYFvHNA == -2 && gwtCzkCrDvPToYZiMOFugAbbRYOr == Environment.CurrentManagedThreadId)
				{
					AIsrOlmMHeeRvXFRlfsobndYFvHNA = 0;
					lyrWhUebSidYYfFJpFkRvYKgAsOn2 = this;
				}
				else
				{
					lyrWhUebSidYYfFJpFkRvYKgAsOn2 = new lyrWhUebSidYYfFJpFkRvYKgAsOn(0);
					lyrWhUebSidYYfFJpFkRvYKgAsOn2.NTTcOshpSRgpeuPVWESAAHFkbAmgb = NTTcOshpSRgpeuPVWESAAHFkbAmgb;
				}
				lyrWhUebSidYYfFJpFkRvYKgAsOn2.BmfxZiZkOipYqArsxhpxjBQXHiJI = sZUzXJDuaZtvsuUDOrlqXbLQRSKr;
				return lyrWhUebSidYYfFJpFkRvYKgAsOn2;
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

		[IteratorStateMachine(typeof(lyrWhUebSidYYfFJpFkRvYKgAsOn))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new lyrWhUebSidYYfFJpFkRvYKgAsOn(-2)
			{
				NTTcOshpSRgpeuPVWESAAHFkbAmgb = this,
				sZUzXJDuaZtvsuUDOrlqXbLQRSKr = categoryId
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
