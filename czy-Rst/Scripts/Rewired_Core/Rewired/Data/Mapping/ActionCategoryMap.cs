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
			private sealed class sXHCPVnOoDvhOlvrunadUcidgtqn : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int xwgEOnwVyNRnxqTimTjgDmhocnqkA;

				private int xkhHHhxCMoicgNLFdYWdzDReidxv;

				private int OsNBScKrIIlcFYVlmijKKXsNnVxHA;

				public Entry BCwebYReHwwCFIlsCBCzsDwzjWcA;

				private int ezpPEDMkMDxXNndPYVsrrExclmJN;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return xkhHHhxCMoicgNLFdYWdzDReidxv;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xkhHHhxCMoicgNLFdYWdzDReidxv;
					}
				}

				[DebuggerHidden]
				public sXHCPVnOoDvhOlvrunadUcidgtqn(int P_0)
				{
					xwgEOnwVyNRnxqTimTjgDmhocnqkA = P_0;
					OsNBScKrIIlcFYVlmijKKXsNnVxHA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = xwgEOnwVyNRnxqTimTjgDmhocnqkA;
					Entry bCwebYReHwwCFIlsCBCzsDwzjWcA = BCwebYReHwwCFIlsCBCzsDwzjWcA;
					switch (num)
					{
					default:
						return false;
					case 0:
						xwgEOnwVyNRnxqTimTjgDmhocnqkA = -1;
						if (bCwebYReHwwCFIlsCBCzsDwzjWcA.actionIds == null)
						{
							return false;
						}
						ezpPEDMkMDxXNndPYVsrrExclmJN = 0;
						break;
					case 1:
						xwgEOnwVyNRnxqTimTjgDmhocnqkA = -1;
						ezpPEDMkMDxXNndPYVsrrExclmJN++;
						break;
					}
					if (ezpPEDMkMDxXNndPYVsrrExclmJN < bCwebYReHwwCFIlsCBCzsDwzjWcA.actionIds.Count)
					{
						xkhHHhxCMoicgNLFdYWdzDReidxv = bCwebYReHwwCFIlsCBCzsDwzjWcA.actionIds[ezpPEDMkMDxXNndPYVsrrExclmJN];
						xwgEOnwVyNRnxqTimTjgDmhocnqkA = 1;
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
					sXHCPVnOoDvhOlvrunadUcidgtqn sXHCPVnOoDvhOlvrunadUcidgtqn2;
					if (xwgEOnwVyNRnxqTimTjgDmhocnqkA == -2 && OsNBScKrIIlcFYVlmijKKXsNnVxHA == Environment.CurrentManagedThreadId)
					{
						xwgEOnwVyNRnxqTimTjgDmhocnqkA = 0;
						sXHCPVnOoDvhOlvrunadUcidgtqn2 = this;
					}
					else
					{
						sXHCPVnOoDvhOlvrunadUcidgtqn2 = new sXHCPVnOoDvhOlvrunadUcidgtqn(0);
						sXHCPVnOoDvhOlvrunadUcidgtqn2.BCwebYReHwwCFIlsCBCzsDwzjWcA = BCwebYReHwwCFIlsCBCzsDwzjWcA;
					}
					return sXHCPVnOoDvhOlvrunadUcidgtqn2;
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
				[IteratorStateMachine(typeof(sXHCPVnOoDvhOlvrunadUcidgtqn))]
				get
				{
					return new sXHCPVnOoDvhOlvrunadUcidgtqn(-2)
					{
						BCwebYReHwwCFIlsCBCzsDwzjWcA = this
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

		private sealed class eyGCzhzLPHrJHfPTTLTeNDGEuEgI : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int JhRfMEjwQPRqeJbDDnFRNijehnfY;

			private int RjZubaSZisxuYtHaffHtuUuZcclf;

			private int tDMhnJNtSEatvMMqoclRYpvJIreh;

			public ActionCategoryMap GBoSOXeuPqQRpeBDidRxphVKMcEK;

			private int UWKbwTECNBCApEimZvSAJOYjhHjs;

			public int bHdeXyGJzcYWruEZyQODzRXcHCuw;

			private IEnumerator<int> OZeCyUFVAYntwrovwfxqwlgMvcocA;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return RjZubaSZisxuYtHaffHtuUuZcclf;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RjZubaSZisxuYtHaffHtuUuZcclf;
				}
			}

			[DebuggerHidden]
			public eyGCzhzLPHrJHfPTTLTeNDGEuEgI(int P_0)
			{
				JhRfMEjwQPRqeJbDDnFRNijehnfY = P_0;
				tDMhnJNtSEatvMMqoclRYpvJIreh = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int jhRfMEjwQPRqeJbDDnFRNijehnfY = JhRfMEjwQPRqeJbDDnFRNijehnfY;
				if (jhRfMEjwQPRqeJbDDnFRNijehnfY == -3 || jhRfMEjwQPRqeJbDDnFRNijehnfY == 1)
				{
					try
					{
					}
					finally
					{
						znGALyukdrylJlTUfyKuWGIxLUOB();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int jhRfMEjwQPRqeJbDDnFRNijehnfY = JhRfMEjwQPRqeJbDDnFRNijehnfY;
					ActionCategoryMap gBoSOXeuPqQRpeBDidRxphVKMcEK = GBoSOXeuPqQRpeBDidRxphVKMcEK;
					switch (jhRfMEjwQPRqeJbDDnFRNijehnfY)
					{
					default:
						return false;
					case 0:
					{
						JhRfMEjwQPRqeJbDDnFRNijehnfY = -1;
						if (gBoSOXeuPqQRpeBDidRxphVKMcEK.list == null)
						{
							return false;
						}
						int num = gBoSOXeuPqQRpeBDidRxphVKMcEK.IndexOfCategory(UWKbwTECNBCApEimZvSAJOYjhHjs);
						if (num < 0)
						{
							return false;
						}
						OZeCyUFVAYntwrovwfxqwlgMvcocA = gBoSOXeuPqQRpeBDidRxphVKMcEK.list[num].ActionIds.GetEnumerator();
						JhRfMEjwQPRqeJbDDnFRNijehnfY = -3;
						break;
					}
					case 1:
						JhRfMEjwQPRqeJbDDnFRNijehnfY = -3;
						break;
					}
					if (OZeCyUFVAYntwrovwfxqwlgMvcocA.MoveNext())
					{
						int current = OZeCyUFVAYntwrovwfxqwlgMvcocA.Current;
						RjZubaSZisxuYtHaffHtuUuZcclf = current;
						JhRfMEjwQPRqeJbDDnFRNijehnfY = 1;
						return true;
					}
					znGALyukdrylJlTUfyKuWGIxLUOB();
					OZeCyUFVAYntwrovwfxqwlgMvcocA = null;
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

			private void znGALyukdrylJlTUfyKuWGIxLUOB()
			{
				JhRfMEjwQPRqeJbDDnFRNijehnfY = -1;
				if (OZeCyUFVAYntwrovwfxqwlgMvcocA != null)
				{
					OZeCyUFVAYntwrovwfxqwlgMvcocA.Dispose();
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
				eyGCzhzLPHrJHfPTTLTeNDGEuEgI eyGCzhzLPHrJHfPTTLTeNDGEuEgI2;
				if (JhRfMEjwQPRqeJbDDnFRNijehnfY == -2 && tDMhnJNtSEatvMMqoclRYpvJIreh == Environment.CurrentManagedThreadId)
				{
					JhRfMEjwQPRqeJbDDnFRNijehnfY = 0;
					eyGCzhzLPHrJHfPTTLTeNDGEuEgI2 = this;
				}
				else
				{
					eyGCzhzLPHrJHfPTTLTeNDGEuEgI2 = new eyGCzhzLPHrJHfPTTLTeNDGEuEgI(0);
					eyGCzhzLPHrJHfPTTLTeNDGEuEgI2.GBoSOXeuPqQRpeBDidRxphVKMcEK = GBoSOXeuPqQRpeBDidRxphVKMcEK;
				}
				eyGCzhzLPHrJHfPTTLTeNDGEuEgI2.UWKbwTECNBCApEimZvSAJOYjhHjs = bHdeXyGJzcYWruEZyQODzRXcHCuw;
				return eyGCzhzLPHrJHfPTTLTeNDGEuEgI2;
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

		[IteratorStateMachine(typeof(eyGCzhzLPHrJHfPTTLTeNDGEuEgI))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new eyGCzhzLPHrJHfPTTLTeNDGEuEgI(-2)
			{
				GBoSOXeuPqQRpeBDidRxphVKMcEK = this,
				bHdeXyGJzcYWruEZyQODzRXcHCuw = categoryId
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
