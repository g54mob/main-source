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
			private sealed class tPagAZdUVJIJBjcPIOZCygblrOXFA : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int chLYyfNTWNBsctSiAJZJhkVeMLNd;

				private int gcMVXzKVfckMxUdbHnqCTmMiuYKk;

				private int VOyYmeIOhUSqYXRLEXSljfxDCyGP;

				public Entry SftLqbwLHTeSTJSTEUdnOpMgcKxw;

				private int tLEKGJtdYZxqEifVqGjURomcBzmC;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return gcMVXzKVfckMxUdbHnqCTmMiuYKk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return gcMVXzKVfckMxUdbHnqCTmMiuYKk;
					}
				}

				[DebuggerHidden]
				public tPagAZdUVJIJBjcPIOZCygblrOXFA(int P_0)
				{
					chLYyfNTWNBsctSiAJZJhkVeMLNd = P_0;
					VOyYmeIOhUSqYXRLEXSljfxDCyGP = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					chLYyfNTWNBsctSiAJZJhkVeMLNd = -2;
				}

				private bool MoveNext()
				{
					int num = chLYyfNTWNBsctSiAJZJhkVeMLNd;
					Entry sftLqbwLHTeSTJSTEUdnOpMgcKxw = SftLqbwLHTeSTJSTEUdnOpMgcKxw;
					switch (num)
					{
					default:
						return false;
					case 0:
						chLYyfNTWNBsctSiAJZJhkVeMLNd = -1;
						if (sftLqbwLHTeSTJSTEUdnOpMgcKxw.actionIds == null)
						{
							return false;
						}
						tLEKGJtdYZxqEifVqGjURomcBzmC = 0;
						break;
					case 1:
						chLYyfNTWNBsctSiAJZJhkVeMLNd = -1;
						tLEKGJtdYZxqEifVqGjURomcBzmC++;
						break;
					}
					if (tLEKGJtdYZxqEifVqGjURomcBzmC < sftLqbwLHTeSTJSTEUdnOpMgcKxw.actionIds.Count)
					{
						gcMVXzKVfckMxUdbHnqCTmMiuYKk = sftLqbwLHTeSTJSTEUdnOpMgcKxw.actionIds[tLEKGJtdYZxqEifVqGjURomcBzmC];
						chLYyfNTWNBsctSiAJZJhkVeMLNd = 1;
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
					tPagAZdUVJIJBjcPIOZCygblrOXFA tPagAZdUVJIJBjcPIOZCygblrOXFA2;
					if (chLYyfNTWNBsctSiAJZJhkVeMLNd == -2 && VOyYmeIOhUSqYXRLEXSljfxDCyGP == Environment.CurrentManagedThreadId)
					{
						chLYyfNTWNBsctSiAJZJhkVeMLNd = 0;
						tPagAZdUVJIJBjcPIOZCygblrOXFA2 = this;
					}
					else
					{
						tPagAZdUVJIJBjcPIOZCygblrOXFA2 = new tPagAZdUVJIJBjcPIOZCygblrOXFA(0);
						tPagAZdUVJIJBjcPIOZCygblrOXFA2.SftLqbwLHTeSTJSTEUdnOpMgcKxw = SftLqbwLHTeSTJSTEUdnOpMgcKxw;
					}
					return tPagAZdUVJIJBjcPIOZCygblrOXFA2;
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
				[IteratorStateMachine(typeof(tPagAZdUVJIJBjcPIOZCygblrOXFA))]
				get
				{
					return new tPagAZdUVJIJBjcPIOZCygblrOXFA(-2)
					{
						SftLqbwLHTeSTJSTEUdnOpMgcKxw = this
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

		private sealed class xDhfEpJWmPCLWienxuvBynXGlBPY : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int SCgSiKIgvXWWfAPfjlmqlmxsUaYF;

			private int CWwNmmdVgqENVcGjXoVSWHPFENGq;

			private int yihBzBwUrWgUyAJIAdUgLyeDWlVtA;

			public ActionCategoryMap NgDcKLeLawPygdNdUXRIDhSMurtt;

			private int HmfXfXxiaNAykDrIxkwhpmXxGeYy;

			public int iFITbgnmMiaRgztUIgHwBEAwvMJl;

			private IEnumerator<int> TITwySuNdEFlrnZBGDTNLDrMTqHm;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return CWwNmmdVgqENVcGjXoVSWHPFENGq;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return CWwNmmdVgqENVcGjXoVSWHPFENGq;
				}
			}

			[DebuggerHidden]
			public xDhfEpJWmPCLWienxuvBynXGlBPY(int P_0)
			{
				SCgSiKIgvXWWfAPfjlmqlmxsUaYF = P_0;
				yihBzBwUrWgUyAJIAdUgLyeDWlVtA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int sCgSiKIgvXWWfAPfjlmqlmxsUaYF = SCgSiKIgvXWWfAPfjlmqlmxsUaYF;
				if (sCgSiKIgvXWWfAPfjlmqlmxsUaYF == -3 || sCgSiKIgvXWWfAPfjlmqlmxsUaYF == 1)
				{
					try
					{
					}
					finally
					{
						oRbqQPVNJxfImcmhDGtrmEHtgwpk();
					}
				}
				TITwySuNdEFlrnZBGDTNLDrMTqHm = null;
				SCgSiKIgvXWWfAPfjlmqlmxsUaYF = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int sCgSiKIgvXWWfAPfjlmqlmxsUaYF = SCgSiKIgvXWWfAPfjlmqlmxsUaYF;
					ActionCategoryMap ngDcKLeLawPygdNdUXRIDhSMurtt = NgDcKLeLawPygdNdUXRIDhSMurtt;
					switch (sCgSiKIgvXWWfAPfjlmqlmxsUaYF)
					{
					default:
						return false;
					case 0:
					{
						SCgSiKIgvXWWfAPfjlmqlmxsUaYF = -1;
						if (ngDcKLeLawPygdNdUXRIDhSMurtt.list == null)
						{
							return false;
						}
						int num = ngDcKLeLawPygdNdUXRIDhSMurtt.IndexOfCategory(HmfXfXxiaNAykDrIxkwhpmXxGeYy);
						if (num < 0)
						{
							return false;
						}
						TITwySuNdEFlrnZBGDTNLDrMTqHm = ngDcKLeLawPygdNdUXRIDhSMurtt.list[num].ActionIds.GetEnumerator();
						SCgSiKIgvXWWfAPfjlmqlmxsUaYF = -3;
						break;
					}
					case 1:
						SCgSiKIgvXWWfAPfjlmqlmxsUaYF = -3;
						break;
					}
					if (TITwySuNdEFlrnZBGDTNLDrMTqHm.MoveNext())
					{
						int current = TITwySuNdEFlrnZBGDTNLDrMTqHm.Current;
						CWwNmmdVgqENVcGjXoVSWHPFENGq = current;
						SCgSiKIgvXWWfAPfjlmqlmxsUaYF = 1;
						return true;
					}
					oRbqQPVNJxfImcmhDGtrmEHtgwpk();
					TITwySuNdEFlrnZBGDTNLDrMTqHm = null;
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

			private void oRbqQPVNJxfImcmhDGtrmEHtgwpk()
			{
				SCgSiKIgvXWWfAPfjlmqlmxsUaYF = -1;
				if (TITwySuNdEFlrnZBGDTNLDrMTqHm != null)
				{
					TITwySuNdEFlrnZBGDTNLDrMTqHm.Dispose();
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
				xDhfEpJWmPCLWienxuvBynXGlBPY xDhfEpJWmPCLWienxuvBynXGlBPY2;
				if (SCgSiKIgvXWWfAPfjlmqlmxsUaYF == -2 && yihBzBwUrWgUyAJIAdUgLyeDWlVtA == Environment.CurrentManagedThreadId)
				{
					SCgSiKIgvXWWfAPfjlmqlmxsUaYF = 0;
					xDhfEpJWmPCLWienxuvBynXGlBPY2 = this;
				}
				else
				{
					xDhfEpJWmPCLWienxuvBynXGlBPY2 = new xDhfEpJWmPCLWienxuvBynXGlBPY(0);
					xDhfEpJWmPCLWienxuvBynXGlBPY2.NgDcKLeLawPygdNdUXRIDhSMurtt = NgDcKLeLawPygdNdUXRIDhSMurtt;
				}
				xDhfEpJWmPCLWienxuvBynXGlBPY2.HmfXfXxiaNAykDrIxkwhpmXxGeYy = iFITbgnmMiaRgztUIgHwBEAwvMJl;
				return xDhfEpJWmPCLWienxuvBynXGlBPY2;
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

		[IteratorStateMachine(typeof(xDhfEpJWmPCLWienxuvBynXGlBPY))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new xDhfEpJWmPCLWienxuvBynXGlBPY(-2)
			{
				NgDcKLeLawPygdNdUXRIDhSMurtt = this,
				iFITbgnmMiaRgztUIgHwBEAwvMJl = categoryId
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
