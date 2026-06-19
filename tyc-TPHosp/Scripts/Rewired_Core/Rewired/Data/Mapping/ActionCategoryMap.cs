using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
			private sealed class tRDJmOUUrKJUHCAsIETnTXzrnVF : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
			{
				private int ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Entry kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int xtAOPmDcqacZxCSjIyFHhsqWbTqW;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					tRDJmOUUrKJUHCAsIETnTXzrnVF tRDJmOUUrKJUHCAsIETnTXzrnVF2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						tRDJmOUUrKJUHCAsIETnTXzrnVF2 = this;
					}
					else
					{
						tRDJmOUUrKJUHCAsIETnTXzrnVF2 = new tRDJmOUUrKJUHCAsIETnTXzrnVF(0);
						tRDJmOUUrKJUHCAsIETnTXzrnVF2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return tRDJmOUUrKJUHCAsIETnTXzrnVF2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<int>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionIds == null)
						{
							break;
						}
						xtAOPmDcqacZxCSjIyFHhsqWbTqW = 0;
						goto IL_006e;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							xtAOPmDcqacZxCSjIyFHhsqWbTqW++;
							goto IL_006e;
						}
						IL_006e:
						if (xtAOPmDcqacZxCSjIyFHhsqWbTqW < kdBZqupjvsCsVkwJiOeEQzkEDVO.actionIds.Count)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionIds[xtAOPmDcqacZxCSjIyFHhsqWbTqW];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							return true;
						}
						break;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public tRDJmOUUrKJUHCAsIETnTXzrnVF(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				get
				{
					tRDJmOUUrKJUHCAsIETnTXzrnVF tRDJmOUUrKJUHCAsIETnTXzrnVF2 = new tRDJmOUUrKJUHCAsIETnTXzrnVF(-2);
					tRDJmOUUrKJUHCAsIETnTXzrnVF2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return tRDJmOUUrKJUHCAsIETnTXzrnVF2;
				}
			}

			public Entry()
			{
				actionIds = new List<int>();
			}

			public Entry(int categoryId)
				: this()
			{
				this.categoryId = categoryId;
			}

			public Entry(Entry source)
			{
				actionIds = ListTools.ShallowCopy(source.actionIds);
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

		private sealed class ZxAXGZOqCffTxdwcCQCRQoUuNhSL : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ActionCategoryMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int xPeeFDuTocYwnhaJrBCbItlrDKAe;

			public int GRdOpxNKCFYWbmqOeDFezHUKcsBb;

			public int OJxJClAQfaCIUMSuMsVOTxOtfNd;

			public int jNOApLgNVmWIUvVttNwzHItGCkGA;

			public IEnumerator<int> SHtGtYgrEUImnpzFIFydLCmusev;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				ZxAXGZOqCffTxdwcCQCRQoUuNhSL zxAXGZOqCffTxdwcCQCRQoUuNhSL;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					zxAXGZOqCffTxdwcCQCRQoUuNhSL = this;
				}
				else
				{
					zxAXGZOqCffTxdwcCQCRQoUuNhSL = new ZxAXGZOqCffTxdwcCQCRQoUuNhSL(0);
					zxAXGZOqCffTxdwcCQCRQoUuNhSL.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				zxAXGZOqCffTxdwcCQCRQoUuNhSL.xPeeFDuTocYwnhaJrBCbItlrDKAe = GRdOpxNKCFYWbmqOeDFezHUKcsBb;
				return zxAXGZOqCffTxdwcCQCRQoUuNhSL;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.list == null)
						{
							break;
						}
						OJxJClAQfaCIUMSuMsVOTxOtfNd = kdBZqupjvsCsVkwJiOeEQzkEDVO.IndexOfCategory(xPeeFDuTocYwnhaJrBCbItlrDKAe);
						if (OJxJClAQfaCIUMSuMsVOTxOtfNd < 0)
						{
							break;
						}
						SHtGtYgrEUImnpzFIFydLCmusev = kdBZqupjvsCsVkwJiOeEQzkEDVO.list[OJxJClAQfaCIUMSuMsVOTxOtfNd].ActionIds.GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00b3;
					case 2:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_00b3;
						}
						IL_00b3:
						if (SHtGtYgrEUImnpzFIFydLCmusev.MoveNext())
						{
							jNOApLgNVmWIUvVttNwzHItGCkGA = SHtGtYgrEUImnpzFIFydLCmusev.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = jNOApLgNVmWIUvVttNwzHItGCkGA;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						IrxYGAlkSktKdxAsgKtZaHyJYuc();
						break;
					}
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						IrxYGAlkSktKdxAsgKtZaHyJYuc();
					}
				}
			}

			[DebuggerHidden]
			public ZxAXGZOqCffTxdwcCQCRQoUuNhSL(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void IrxYGAlkSktKdxAsgKtZaHyJYuc()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (SHtGtYgrEUImnpzFIFydLCmusev != null)
				{
					SHtGtYgrEUImnpzFIFydLCmusev.Dispose();
				}
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> list;

		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			ZxAXGZOqCffTxdwcCQCRQoUuNhSL zxAXGZOqCffTxdwcCQCRQoUuNhSL = new ZxAXGZOqCffTxdwcCQCRQoUuNhSL(-2);
			zxAXGZOqCffTxdwcCQCRQoUuNhSL.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			zxAXGZOqCffTxdwcCQCRQoUuNhSL.GRdOpxNKCFYWbmqOeDFezHUKcsBb = categoryId;
			return zxAXGZOqCffTxdwcCQCRQoUuNhSL;
		}

		public ActionCategoryMap()
		{
			list = new List<Entry>();
		}

		public ActionCategoryMap(ActionCategoryMap source)
		{
			if (source.list != null)
			{
				list = new List<Entry>(source.list.Count);
				for (int i = 0; i < source.list.Count; i++)
				{
					list[i] = source.list[i].Clone();
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
