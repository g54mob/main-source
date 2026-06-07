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
			private sealed class ASKKlasfrwqFgUAfyfKbfYHijPp : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
			{
				private int RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Entry ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int AgTnIUtazYaOYCcryVPEUUDXpKR;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return RDkWcsTpvDaNZojjIZONnoEBXPC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return RDkWcsTpvDaNZojjIZONnoEBXPC;
					}
				}

				[DebuggerHidden]
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					ASKKlasfrwqFgUAfyfKbfYHijPp aSKKlasfrwqFgUAfyfKbfYHijPp;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						aSKKlasfrwqFgUAfyfKbfYHijPp = this;
						goto IL_0025;
					}
					goto IL_004e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ -148580287)
						{
						case 0:
							break;
						case 2:
							num = -148580288;
							continue;
						case 3:
							goto IL_004e;
						default:
							return aSKKlasfrwqFgUAfyfKbfYHijPp;
						}
						break;
					}
					goto IL_0025;
					IL_004e:
					aSKKlasfrwqFgUAfyfKbfYHijPp = new ASKKlasfrwqFgUAfyfKbfYHijPp(0);
					aSKKlasfrwqFgUAfyfKbfYHijPp.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = -148580288;
					goto IL_002a;
					IL_0025:
					num = -148580285;
					goto IL_002a;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<int>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = 1916045351;
						while (true)
						{
							switch (num ^ 0x72348821)
							{
							case 0:
								break;
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 1916045348;
								continue;
							case 1:
								num = 1916045349;
								continue;
							case 7:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionIds[AgTnIUtazYaOYCcryVPEUUDXpKR];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 3:
							{
								int num2;
								if (AgTnIUtazYaOYCcryVPEUUDXpKR >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionIds.Count)
								{
									num = 1916045349;
									num2 = num;
								}
								else
								{
									num = 1916045350;
									num2 = num;
								}
								continue;
							}
							case 6:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 0:
									break;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									AgTnIUtazYaOYCcryVPEUUDXpKR++;
									num = 1916045346;
									continue;
								default:
									num = 1916045344;
									continue;
								}
								goto case 2;
							case 5:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionIds != null)
								{
									AgTnIUtazYaOYCcryVPEUUDXpKR = 0;
									num = 1916045346;
									continue;
								}
								goto default;
							default:
								return false;
							}
							break;
						}
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
				}

				[DebuggerHidden]
				public ASKKlasfrwqFgUAfyfKbfYHijPp(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				get
				{
					ASKKlasfrwqFgUAfyfKbfYHijPp aSKKlasfrwqFgUAfyfKbfYHijPp = new ASKKlasfrwqFgUAfyfKbfYHijPp(-2);
					aSKKlasfrwqFgUAfyfKbfYHijPp.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return aSKKlasfrwqFgUAfyfKbfYHijPp;
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
					goto IL_0014;
				}
				int num;
				int num2;
				if (index < actionIds.Count)
				{
					num = -1700040612;
					num2 = num;
				}
				else
				{
					num = -1700040614;
					num2 = num;
				}
				goto IL_0019;
				IL_0019:
				while (true)
				{
					switch (num ^ -1700040616)
					{
					case 0:
						break;
					case 3:
						return true;
					case 2:
						actionIds.Add(actionId);
						num = -1700040615;
						continue;
					case 4:
						actionIds.Insert(index, actionId);
						num = -1700040615;
						continue;
					default:
						return true;
					}
					break;
				}
				goto IL_0014;
				IL_0014:
				num = -1700040613;
				goto IL_0019;
			}

			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				int num = IndexOfAction(actionId);
				if (num < 0)
				{
					return false;
				}
				if (!offsetDown)
				{
					goto IL_0011;
				}
				goto IL_004b;
				IL_0046:
				if (num == 0)
				{
					return false;
				}
				goto IL_004b;
				IL_0011:
				int num2 = -1406594813;
				goto IL_0016;
				IL_0016:
				int value = default(int);
				while (true)
				{
					switch (num2 ^ -1406594812)
					{
					case 3:
						break;
					case 7:
						goto IL_0046;
					case 0:
						return true;
					case 4:
						num2 = -1406594811;
						continue;
					case 6:
						goto IL_008f;
					case 5:
						goto IL_00ae;
					case 2:
						actionIds[num + 1] = value;
						num2 = -1406594816;
						continue;
					default:
						return true;
					}
					break;
				}
				goto IL_0011;
				IL_004b:
				if (offsetDown)
				{
					num2 = -1406594814;
					goto IL_0016;
				}
				goto IL_00a1;
				IL_00ae:
				actionIds[num] = actionIds[num - 1];
				actionIds[num - 1] = value;
				num2 = -1406594811;
				goto IL_0016;
				IL_00a1:
				if (offsetNow)
				{
					value = actionIds[num];
					if (!offsetDown)
					{
						goto IL_00ae;
					}
					actionIds[num] = actionIds[num + 1];
					num2 = -1406594810;
				}
				else
				{
					num2 = -1406594812;
				}
				goto IL_0016;
				IL_008f:
				if (num >= actionIds.Count - 1)
				{
					return false;
				}
				goto IL_00a1;
			}

			public void RemoveAction(int actionId)
			{
				int num = IndexOfAction(actionId);
				if (num < 0)
				{
					return;
				}
				while (true)
				{
					actionIds.RemoveAt(num);
					int num2 = 1174025992;
					while (true)
					{
						switch (num2 ^ 0x45FA3709)
						{
						case 0:
							goto IL_000d;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000d:
						num2 = 1174025995;
					}
				}
			}

			public int IndexOfAction(int id)
			{
				if (actionIds == null)
				{
					return -1;
				}
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= actionIds.Count)
					{
						num2 = -493121387;
						num3 = num2;
					}
					else
					{
						num2 = -493121388;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -493121386)
						{
						case 0:
							num2 = -493121388;
							continue;
						case 2:
							if (actionIds[num] == id)
							{
								return num;
							}
							num++;
							num2 = -493121385;
							continue;
						case 1:
							break;
						default:
							return -1;
						}
						break;
					}
				}
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

		private sealed class eSNBmduQYNbqGaHhmwYTQWodBLm : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ActionCategoryMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int SzjddpAOoODoUjdWFSipJbRqcqg;

			public int bFmNZSjCGffgImJpMTwiFowHYdx;

			public int rPkyGFqKxYbNzOTxcgBEjoiiJsL;

			public int OLJXwvdCVKfRbZnaNyxdoiBBAJk;

			public IEnumerator<int> rQyEewIudcqnYncmejNxavozNQHZ;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				eSNBmduQYNbqGaHhmwYTQWodBLm eSNBmduQYNbqGaHhmwYTQWodBLm2;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					eSNBmduQYNbqGaHhmwYTQWodBLm2 = this;
				}
				else
				{
					while (true)
					{
						eSNBmduQYNbqGaHhmwYTQWodBLm2 = new eSNBmduQYNbqGaHhmwYTQWodBLm(0);
						eSNBmduQYNbqGaHhmwYTQWodBLm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = 442447668;
						while (true)
						{
							switch (num ^ 0x1A5F3734)
							{
							case 2:
								num = 442447669;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				eSNBmduQYNbqGaHhmwYTQWodBLm2.SzjddpAOoODoUjdWFSipJbRqcqg = bFmNZSjCGffgImJpMTwiFowHYdx;
				return eSNBmduQYNbqGaHhmwYTQWodBLm2;
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
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -685345978;
						goto IL_0023;
					case 2:
						goto IL_0097;
						IL_0023:
						while (true)
						{
							switch (num ^ -685345978)
							{
							case 6:
								num = -685345979;
								continue;
							case 3:
								break;
							case 4:
								if (!rQyEewIudcqnYncmejNxavozNQHZ.MoveNext())
								{
									zFkJcwVPOSYuCpbdIglLQiSUuSE();
									num = -685345970;
									continue;
								}
								goto case 7;
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								return true;
							case 2:
								goto IL_0097;
							case 0:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.list != null)
								{
									rPkyGFqKxYbNzOTxcgBEjoiiJsL = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.IndexOfCategory(SzjddpAOoODoUjdWFSipJbRqcqg);
									if (rPkyGFqKxYbNzOTxcgBEjoiiJsL >= 0)
									{
										rQyEewIudcqnYncmejNxavozNQHZ = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.list[rPkyGFqKxYbNzOTxcgBEjoiiJsL].ActionIds.GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -685345977;
										continue;
									}
								}
								goto end_IL_0008;
							case 7:
								OLJXwvdCVKfRbZnaNyxdoiBBAJk = rQyEewIudcqnYncmejNxavozNQHZ.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = OLJXwvdCVKfRbZnaNyxdoiBBAJk;
								num = -685345981;
								continue;
							case 1:
								num = -685345982;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						goto case 0;
						IL_0097:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -685345982;
						goto IL_0023;
						end_IL_0008:
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						zFkJcwVPOSYuCpbdIglLQiSUuSE();
					}
				}
			}

			[DebuggerHidden]
			public eSNBmduQYNbqGaHhmwYTQWodBLm(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void zFkJcwVPOSYuCpbdIglLQiSUuSE()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (rQyEewIudcqnYncmejNxavozNQHZ != null)
				{
					rQyEewIudcqnYncmejNxavozNQHZ.Dispose();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Entry> list;

		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			eSNBmduQYNbqGaHhmwYTQWodBLm eSNBmduQYNbqGaHhmwYTQWodBLm2 = new eSNBmduQYNbqGaHhmwYTQWodBLm(-2);
			eSNBmduQYNbqGaHhmwYTQWodBLm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			while (true)
			{
				int num = -1494682415;
				while (true)
				{
					switch (num ^ -1494682416)
					{
					case 2:
						break;
					case 1:
						goto IL_002d;
					default:
						return eSNBmduQYNbqGaHhmwYTQWodBLm2;
					}
					break;
					IL_002d:
					eSNBmduQYNbqGaHhmwYTQWodBLm2.bFmNZSjCGffgImJpMTwiFowHYdx = categoryId;
					num = -1494682416;
				}
			}
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
				goto IL_000f;
			}
			int num2;
			if (!offsetDown)
			{
				num2 = 1355696474;
				goto IL_0014;
			}
			goto IL_00d4;
			IL_00d4:
			if (offsetDown)
			{
				num2 = 1355696477;
				goto IL_0014;
			}
			goto IL_00f2;
			IL_00cf:
			if (num == 0)
			{
				return false;
			}
			goto IL_00d4;
			IL_000f:
			num2 = 1355696469;
			goto IL_0014;
			IL_0014:
			Entry value = default(Entry);
			while (true)
			{
				switch (num2 ^ 0x50CE495D)
				{
				case 2:
					break;
				case 3:
					list[num + 1] = value;
					num2 = 1355696476;
					continue;
				case 0:
					goto IL_005e;
				case 5:
					list[num] = list[num + 1];
					num2 = 1355696478;
					continue;
				case 6:
					list[num] = list[num - 1];
					list[num - 1] = value;
					num2 = 1355696476;
					continue;
				case 7:
					goto IL_00cf;
				case 8:
					return false;
				case 4:
					return false;
				default:
					return true;
				}
				break;
				IL_005e:
				if (num >= list.Count - 1)
				{
					num2 = 1355696473;
					continue;
				}
				goto IL_00f2;
			}
			goto IL_000f;
			IL_00f2:
			value = list[num];
			int num3;
			if (offsetDown)
			{
				num2 = 1355696472;
				num3 = num2;
			}
			else
			{
				num2 = 1355696475;
				num3 = num2;
			}
			goto IL_0014;
		}

		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			if (list == null)
			{
				return false;
			}
			bool result = false;
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -985033132;
				while (true)
				{
					switch (num ^ -985033129)
					{
					case 4:
						break;
					case 5:
						if (num3 >= list.Count)
						{
							num2 = 0;
							num = -985033135;
							continue;
						}
						goto case 2;
					case 2:
						if (list[num3].ContainsAction(actionId))
						{
							list[num3].RemoveAction(actionId);
							num = -985033136;
							continue;
						}
						goto case 7;
					case 3:
						num3 = 0;
						num = -985033134;
						continue;
					case 1:
						num2++;
						num = -985033135;
						continue;
					case 0:
						if (list[num2].categoryId == newCategoryId)
						{
							list[num2].AddAction(actionId);
							result = true;
							num = -985033130;
							continue;
						}
						goto case 1;
					case 7:
						num3++;
						num = -985033134;
						continue;
					default:
						if (num2 >= list.Count)
						{
							return result;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public int IndexOfCategory(int id)
		{
			if (list == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 311982251;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x129878AA)
				{
				case 0:
					break;
				case 2:
					return -1;
				case 1:
				{
					int num3;
					if (num < list.Count)
					{
						num2 = 311982254;
						num3 = num2;
					}
					else
					{
						num2 = 311982249;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (list[num].categoryId == id)
					{
						return num;
					}
					num++;
					num2 = 311982251;
					continue;
				default:
					return -1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 311982248;
			goto IL_000d;
		}

		public bool AddAction(int categoryId, int actionId)
		{
			if (list == null)
			{
				goto IL_0008;
			}
			int num = IndexOfCategory(categoryId);
			int num2 = -2021294418;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -2021294417)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				if (num < 0)
				{
					return false;
				}
				list[num].AddAction(actionId);
				return true;
			}
			goto IL_0008;
			IL_0008:
			num2 = -2021294419;
			goto IL_000d;
		}

		public bool InsertAction(int categoryId, int actionId, int index)
		{
			if (index < 0)
			{
				goto IL_0004;
			}
			int num = IndexOfCategory(categoryId);
			int num2 = 545841834;
			goto IL_0009;
			IL_0009:
			switch (num2 ^ 0x2088E2AA)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				if (num < 0)
				{
					return false;
				}
				return list[num].InsertAction(actionId, index);
			}
			goto IL_0004;
			IL_0004:
			num2 = 545841835;
			goto IL_0009;
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
			if (num < 0)
			{
				return;
			}
			while (true)
			{
				list[num].RemoveAction(actionId);
				int num2 = 795177789;
				while (true)
				{
					switch (num2 ^ 0x2F65733D)
					{
					case 2:
						goto IL_000d;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000d:
					num2 = 795177788;
				}
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
