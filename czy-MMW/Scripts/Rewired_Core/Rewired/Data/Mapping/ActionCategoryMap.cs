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
			private sealed class nsfNnoxyEAhOQrqRipRFAOQMTxwe : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int gbIgJGbqqOHjldgbCarYxRHSPTuRb;

				private int yGFEkMpSvbwNoXYTnGbFxlHLRiff;

				private int LudgFBfuQDgcXYvakjhwPkQyTllx;

				public Entry SamFlWLmkQgeEHGkeGHgqidJfTEab;

				private int jxLSNaUJECLPDfFWAtwRhXVJqAJp;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return yGFEkMpSvbwNoXYTnGbFxlHLRiff;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yGFEkMpSvbwNoXYTnGbFxlHLRiff;
					}
				}

				[DebuggerHidden]
				public nsfNnoxyEAhOQrqRipRFAOQMTxwe(int P_0)
				{
					gbIgJGbqqOHjldgbCarYxRHSPTuRb = P_0;
					LudgFBfuQDgcXYvakjhwPkQyTllx = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = gbIgJGbqqOHjldgbCarYxRHSPTuRb;
					Entry samFlWLmkQgeEHGkeGHgqidJfTEab = SamFlWLmkQgeEHGkeGHgqidJfTEab;
					switch (num)
					{
					default:
						return false;
					case 0:
						gbIgJGbqqOHjldgbCarYxRHSPTuRb = -1;
						if (samFlWLmkQgeEHGkeGHgqidJfTEab.actionIds == null)
						{
							return false;
						}
						jxLSNaUJECLPDfFWAtwRhXVJqAJp = 0;
						break;
					case 1:
						gbIgJGbqqOHjldgbCarYxRHSPTuRb = -1;
						jxLSNaUJECLPDfFWAtwRhXVJqAJp++;
						break;
					}
					if (jxLSNaUJECLPDfFWAtwRhXVJqAJp < samFlWLmkQgeEHGkeGHgqidJfTEab.actionIds.Count)
					{
						yGFEkMpSvbwNoXYTnGbFxlHLRiff = samFlWLmkQgeEHGkeGHgqidJfTEab.actionIds[jxLSNaUJECLPDfFWAtwRhXVJqAJp];
						gbIgJGbqqOHjldgbCarYxRHSPTuRb = 1;
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
					nsfNnoxyEAhOQrqRipRFAOQMTxwe nsfNnoxyEAhOQrqRipRFAOQMTxwe2;
					if (gbIgJGbqqOHjldgbCarYxRHSPTuRb == -2 && LudgFBfuQDgcXYvakjhwPkQyTllx == Environment.CurrentManagedThreadId)
					{
						gbIgJGbqqOHjldgbCarYxRHSPTuRb = 0;
						nsfNnoxyEAhOQrqRipRFAOQMTxwe2 = this;
					}
					else
					{
						nsfNnoxyEAhOQrqRipRFAOQMTxwe2 = new nsfNnoxyEAhOQrqRipRFAOQMTxwe(0);
						nsfNnoxyEAhOQrqRipRFAOQMTxwe2.SamFlWLmkQgeEHGkeGHgqidJfTEab = SamFlWLmkQgeEHGkeGHgqidJfTEab;
					}
					return nsfNnoxyEAhOQrqRipRFAOQMTxwe2;
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
				[IteratorStateMachine(typeof(nsfNnoxyEAhOQrqRipRFAOQMTxwe))]
				get
				{
					return new nsfNnoxyEAhOQrqRipRFAOQMTxwe(-2)
					{
						SamFlWLmkQgeEHGkeGHgqidJfTEab = this
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

		private sealed class lBcDfOhHRGjDZpKRXXYCDoSnYdof : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int MfhFHpbfOKksgcDCjLJnnPRcRBdrd;

			private int GGxazZUUNntnMdMOrBbThogqvUfuA;

			private int gZcsokJDCFylbEobcmYnQSPaeSci;

			public ActionCategoryMap XWULMiaKRvYXroMQivvBdEbjgsGJ;

			private int FsZocHEBODOzoEvHsKgiTmCknfBb;

			public int wdHlOVSmvbCMhCqEubEbSltZLqeWA;

			private IEnumerator<int> PSYFnlHFSJOfkuBssXxMdiKjPWsQ;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return GGxazZUUNntnMdMOrBbThogqvUfuA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return GGxazZUUNntnMdMOrBbThogqvUfuA;
				}
			}

			[DebuggerHidden]
			public lBcDfOhHRGjDZpKRXXYCDoSnYdof(int P_0)
			{
				MfhFHpbfOKksgcDCjLJnnPRcRBdrd = P_0;
				gZcsokJDCFylbEobcmYnQSPaeSci = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int mfhFHpbfOKksgcDCjLJnnPRcRBdrd = MfhFHpbfOKksgcDCjLJnnPRcRBdrd;
				if (mfhFHpbfOKksgcDCjLJnnPRcRBdrd == -3 || mfhFHpbfOKksgcDCjLJnnPRcRBdrd == 1)
				{
					try
					{
					}
					finally
					{
						sNeXNokEaubipfPMxmquUkgCupWT();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int mfhFHpbfOKksgcDCjLJnnPRcRBdrd = MfhFHpbfOKksgcDCjLJnnPRcRBdrd;
					ActionCategoryMap xWULMiaKRvYXroMQivvBdEbjgsGJ = XWULMiaKRvYXroMQivvBdEbjgsGJ;
					switch (mfhFHpbfOKksgcDCjLJnnPRcRBdrd)
					{
					default:
						return false;
					case 0:
					{
						MfhFHpbfOKksgcDCjLJnnPRcRBdrd = -1;
						if (xWULMiaKRvYXroMQivvBdEbjgsGJ.list == null)
						{
							return false;
						}
						int num = xWULMiaKRvYXroMQivvBdEbjgsGJ.IndexOfCategory(FsZocHEBODOzoEvHsKgiTmCknfBb);
						if (num < 0)
						{
							return false;
						}
						PSYFnlHFSJOfkuBssXxMdiKjPWsQ = xWULMiaKRvYXroMQivvBdEbjgsGJ.list[num].ActionIds.GetEnumerator();
						MfhFHpbfOKksgcDCjLJnnPRcRBdrd = -3;
						break;
					}
					case 1:
						MfhFHpbfOKksgcDCjLJnnPRcRBdrd = -3;
						break;
					}
					if (PSYFnlHFSJOfkuBssXxMdiKjPWsQ.MoveNext())
					{
						int current = PSYFnlHFSJOfkuBssXxMdiKjPWsQ.Current;
						GGxazZUUNntnMdMOrBbThogqvUfuA = current;
						MfhFHpbfOKksgcDCjLJnnPRcRBdrd = 1;
						return true;
					}
					sNeXNokEaubipfPMxmquUkgCupWT();
					PSYFnlHFSJOfkuBssXxMdiKjPWsQ = null;
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

			private void sNeXNokEaubipfPMxmquUkgCupWT()
			{
				MfhFHpbfOKksgcDCjLJnnPRcRBdrd = -1;
				if (PSYFnlHFSJOfkuBssXxMdiKjPWsQ != null)
				{
					PSYFnlHFSJOfkuBssXxMdiKjPWsQ.Dispose();
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
				lBcDfOhHRGjDZpKRXXYCDoSnYdof lBcDfOhHRGjDZpKRXXYCDoSnYdof2;
				if (MfhFHpbfOKksgcDCjLJnnPRcRBdrd == -2 && gZcsokJDCFylbEobcmYnQSPaeSci == Environment.CurrentManagedThreadId)
				{
					MfhFHpbfOKksgcDCjLJnnPRcRBdrd = 0;
					lBcDfOhHRGjDZpKRXXYCDoSnYdof2 = this;
				}
				else
				{
					lBcDfOhHRGjDZpKRXXYCDoSnYdof2 = new lBcDfOhHRGjDZpKRXXYCDoSnYdof(0);
					lBcDfOhHRGjDZpKRXXYCDoSnYdof2.XWULMiaKRvYXroMQivvBdEbjgsGJ = XWULMiaKRvYXroMQivvBdEbjgsGJ;
				}
				lBcDfOhHRGjDZpKRXXYCDoSnYdof2.FsZocHEBODOzoEvHsKgiTmCknfBb = wdHlOVSmvbCMhCqEubEbSltZLqeWA;
				return lBcDfOhHRGjDZpKRXXYCDoSnYdof2;
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

		[IteratorStateMachine(typeof(lBcDfOhHRGjDZpKRXXYCDoSnYdof))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new lBcDfOhHRGjDZpKRXXYCDoSnYdof(-2)
			{
				XWULMiaKRvYXroMQivvBdEbjgsGJ = this,
				wdHlOVSmvbCMhCqEubEbSltZLqeWA = categoryId
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
