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
			private sealed class fJegGEigxNmVpRqzBtMfjplGePHs : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int oLBMeubCtDHZMAkwVQAgcygRSNHr;

				private int qzOsNeqLXqhUXdIBEazzKzMXWBCN;

				private int TQcQldcCJMGDeionVUKAiytcpeQJ;

				public Entry ODhZscCyjNcMhogpBgmMBFMNMLnkA;

				private int vJGCTGFFVTEfwXeDdwLnULaHUUgL;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return qzOsNeqLXqhUXdIBEazzKzMXWBCN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qzOsNeqLXqhUXdIBEazzKzMXWBCN;
					}
				}

				[DebuggerHidden]
				public fJegGEigxNmVpRqzBtMfjplGePHs(int P_0)
				{
					oLBMeubCtDHZMAkwVQAgcygRSNHr = P_0;
					TQcQldcCJMGDeionVUKAiytcpeQJ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					oLBMeubCtDHZMAkwVQAgcygRSNHr = -2;
				}

				private bool MoveNext()
				{
					int num = oLBMeubCtDHZMAkwVQAgcygRSNHr;
					Entry oDhZscCyjNcMhogpBgmMBFMNMLnkA = ODhZscCyjNcMhogpBgmMBFMNMLnkA;
					switch (num)
					{
					default:
						return false;
					case 0:
						oLBMeubCtDHZMAkwVQAgcygRSNHr = -1;
						if (oDhZscCyjNcMhogpBgmMBFMNMLnkA.actionIds == null)
						{
							return false;
						}
						vJGCTGFFVTEfwXeDdwLnULaHUUgL = 0;
						break;
					case 1:
						oLBMeubCtDHZMAkwVQAgcygRSNHr = -1;
						vJGCTGFFVTEfwXeDdwLnULaHUUgL++;
						break;
					}
					if (vJGCTGFFVTEfwXeDdwLnULaHUUgL < oDhZscCyjNcMhogpBgmMBFMNMLnkA.actionIds.Count)
					{
						qzOsNeqLXqhUXdIBEazzKzMXWBCN = oDhZscCyjNcMhogpBgmMBFMNMLnkA.actionIds[vJGCTGFFVTEfwXeDdwLnULaHUUgL];
						oLBMeubCtDHZMAkwVQAgcygRSNHr = 1;
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
					fJegGEigxNmVpRqzBtMfjplGePHs fJegGEigxNmVpRqzBtMfjplGePHs2;
					if (oLBMeubCtDHZMAkwVQAgcygRSNHr == -2 && TQcQldcCJMGDeionVUKAiytcpeQJ == Environment.CurrentManagedThreadId)
					{
						oLBMeubCtDHZMAkwVQAgcygRSNHr = 0;
						fJegGEigxNmVpRqzBtMfjplGePHs2 = this;
					}
					else
					{
						fJegGEigxNmVpRqzBtMfjplGePHs2 = new fJegGEigxNmVpRqzBtMfjplGePHs(0);
						fJegGEigxNmVpRqzBtMfjplGePHs2.ODhZscCyjNcMhogpBgmMBFMNMLnkA = ODhZscCyjNcMhogpBgmMBFMNMLnkA;
					}
					return fJegGEigxNmVpRqzBtMfjplGePHs2;
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
				[IteratorStateMachine(typeof(fJegGEigxNmVpRqzBtMfjplGePHs))]
				get
				{
					return new fJegGEigxNmVpRqzBtMfjplGePHs(-2)
					{
						ODhZscCyjNcMhogpBgmMBFMNMLnkA = this
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

		private sealed class lflfWygMEBVPiFmDkPwawbBhrEDo : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int WaoILDmERHkIRvNZqIiJegiDQLKQ;

			private int EUsTwhHiGapTfHSJSZCpDPJctOIp;

			private int yCnjfEYXTSJKAkXsZEZNfciqnmNV;

			public ActionCategoryMap XaBJUUrGEwbeIEIXXTYdQIMrjmlEA;

			private int DIlpfOFhWNniIgxkikbAmNFUvdYW;

			public int sCUNHfDaueauQYkPDtaFOaEXJgJR;

			private IEnumerator<int> DfBojZYbLUFIJADxBWmkUapviGTW;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return EUsTwhHiGapTfHSJSZCpDPJctOIp;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EUsTwhHiGapTfHSJSZCpDPJctOIp;
				}
			}

			[DebuggerHidden]
			public lflfWygMEBVPiFmDkPwawbBhrEDo(int P_0)
			{
				WaoILDmERHkIRvNZqIiJegiDQLKQ = P_0;
				yCnjfEYXTSJKAkXsZEZNfciqnmNV = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int waoILDmERHkIRvNZqIiJegiDQLKQ = WaoILDmERHkIRvNZqIiJegiDQLKQ;
				if (waoILDmERHkIRvNZqIiJegiDQLKQ == -3 || waoILDmERHkIRvNZqIiJegiDQLKQ == 1)
				{
					try
					{
					}
					finally
					{
						eOfwSQvafdUYGHcDKLRCjWNIabfq();
					}
				}
				DfBojZYbLUFIJADxBWmkUapviGTW = null;
				WaoILDmERHkIRvNZqIiJegiDQLKQ = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int waoILDmERHkIRvNZqIiJegiDQLKQ = WaoILDmERHkIRvNZqIiJegiDQLKQ;
					ActionCategoryMap xaBJUUrGEwbeIEIXXTYdQIMrjmlEA = XaBJUUrGEwbeIEIXXTYdQIMrjmlEA;
					switch (waoILDmERHkIRvNZqIiJegiDQLKQ)
					{
					default:
						return false;
					case 0:
					{
						WaoILDmERHkIRvNZqIiJegiDQLKQ = -1;
						if (xaBJUUrGEwbeIEIXXTYdQIMrjmlEA.list == null)
						{
							return false;
						}
						int num = xaBJUUrGEwbeIEIXXTYdQIMrjmlEA.IndexOfCategory(DIlpfOFhWNniIgxkikbAmNFUvdYW);
						if (num < 0)
						{
							return false;
						}
						DfBojZYbLUFIJADxBWmkUapviGTW = xaBJUUrGEwbeIEIXXTYdQIMrjmlEA.list[num].ActionIds.GetEnumerator();
						WaoILDmERHkIRvNZqIiJegiDQLKQ = -3;
						break;
					}
					case 1:
						WaoILDmERHkIRvNZqIiJegiDQLKQ = -3;
						break;
					}
					if (DfBojZYbLUFIJADxBWmkUapviGTW.MoveNext())
					{
						int current = DfBojZYbLUFIJADxBWmkUapviGTW.Current;
						EUsTwhHiGapTfHSJSZCpDPJctOIp = current;
						WaoILDmERHkIRvNZqIiJegiDQLKQ = 1;
						return true;
					}
					eOfwSQvafdUYGHcDKLRCjWNIabfq();
					DfBojZYbLUFIJADxBWmkUapviGTW = null;
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

			private void eOfwSQvafdUYGHcDKLRCjWNIabfq()
			{
				WaoILDmERHkIRvNZqIiJegiDQLKQ = -1;
				if (DfBojZYbLUFIJADxBWmkUapviGTW != null)
				{
					DfBojZYbLUFIJADxBWmkUapviGTW.Dispose();
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
				lflfWygMEBVPiFmDkPwawbBhrEDo lflfWygMEBVPiFmDkPwawbBhrEDo2;
				if (WaoILDmERHkIRvNZqIiJegiDQLKQ == -2 && yCnjfEYXTSJKAkXsZEZNfciqnmNV == Environment.CurrentManagedThreadId)
				{
					WaoILDmERHkIRvNZqIiJegiDQLKQ = 0;
					lflfWygMEBVPiFmDkPwawbBhrEDo2 = this;
				}
				else
				{
					lflfWygMEBVPiFmDkPwawbBhrEDo2 = new lflfWygMEBVPiFmDkPwawbBhrEDo(0);
					lflfWygMEBVPiFmDkPwawbBhrEDo2.XaBJUUrGEwbeIEIXXTYdQIMrjmlEA = XaBJUUrGEwbeIEIXXTYdQIMrjmlEA;
				}
				lflfWygMEBVPiFmDkPwawbBhrEDo2.DIlpfOFhWNniIgxkikbAmNFUvdYW = sCUNHfDaueauQYkPDtaFOaEXJgJR;
				return lflfWygMEBVPiFmDkPwawbBhrEDo2;
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

		[IteratorStateMachine(typeof(lflfWygMEBVPiFmDkPwawbBhrEDo))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new lflfWygMEBVPiFmDkPwawbBhrEDo(-2)
			{
				XaBJUUrGEwbeIEIXXTYdQIMrjmlEA = this,
				sCUNHfDaueauQYkPDtaFOaEXJgJR = categoryId
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
