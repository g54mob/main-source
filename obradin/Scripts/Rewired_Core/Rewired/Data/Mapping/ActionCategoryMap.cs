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
			private sealed class pFWJazGtziNTLqeCIMBlADugUpa : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
			{
				private int aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Entry iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int bTPokZXhsGLjhsrtEFQDzjIRqOH;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return aimBzjfQfPyaeQqysAQJISCBhELB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aimBzjfQfPyaeQqysAQJISCBhELB;
					}
				}

				[DebuggerHidden]
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						goto IL_0023;
					}
					goto IL_0052;
					IL_0028:
					int num;
					pFWJazGtziNTLqeCIMBlADugUpa pFWJazGtziNTLqeCIMBlADugUpa2 = default(pFWJazGtziNTLqeCIMBlADugUpa);
					while (true)
					{
						switch (num ^ -832298895)
						{
						case 3:
							break;
						case 1:
							pFWJazGtziNTLqeCIMBlADugUpa2 = this;
							num = -832298895;
							continue;
						case 4:
							goto IL_0052;
						case 2:
							pFWJazGtziNTLqeCIMBlADugUpa2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = -832298895;
							continue;
						default:
							return pFWJazGtziNTLqeCIMBlADugUpa2;
						}
						break;
					}
					goto IL_0023;
					IL_0052:
					pFWJazGtziNTLqeCIMBlADugUpa2 = new pFWJazGtziNTLqeCIMBlADugUpa(0);
					num = -832298893;
					goto IL_0028;
					IL_0023:
					num = -832298896;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<int>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1989651102;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionIds != null)
							{
								num = 1989651097;
								num3 = num;
							}
							else
							{
								num = 1989651103;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x7697AA9C)
							{
							case 7:
								num = 1989651101;
								continue;
							case 6:
								break;
							case 4:
								return true;
							case 0:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionIds[bTPokZXhsGLjhsrtEFQDzjIRqOH];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1989651096;
								continue;
							case 5:
								bTPokZXhsGLjhsrtEFQDzjIRqOH = 0;
								num = 1989651098;
								continue;
							case 1:
								goto end_IL_001f;
							case 2:
								bTPokZXhsGLjhsrtEFQDzjIRqOH++;
								num = 1989651098;
								continue;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (bTPokZXhsGLjhsrtEFQDzjIRqOH < iKQXbXnVtIaMZEJNeigQJWAHqUx.actionIds.Count)
							{
								num = 1989651100;
								num2 = num;
							}
							else
							{
								num = 1989651103;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
						}
						goto case 0;
						end_IL_0008:
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
				public pFWJazGtziNTLqeCIMBlADugUpa(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				get
				{
					pFWJazGtziNTLqeCIMBlADugUpa pFWJazGtziNTLqeCIMBlADugUpa2 = new pFWJazGtziNTLqeCIMBlADugUpa(-2);
					pFWJazGtziNTLqeCIMBlADugUpa2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return pFWJazGtziNTLqeCIMBlADugUpa2;
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
					while (true)
					{
						actionIds.Insert(index, actionId);
						int num = 1049839864;
						while (true)
						{
							switch (num ^ 0x3E9348FA)
							{
							case 0:
								num = 1049839867;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0050;
							}
							break;
						}
						continue;
						end_IL_0050:
						break;
					}
				}
				return true;
			}

			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				int num = IndexOfAction(actionId);
				int value = default(int);
				while (true)
				{
					int num2 = -1042126224;
					while (true)
					{
						switch (num2 ^ -1042126216)
						{
						case 10:
							break;
						case 8:
							if (num < 0)
							{
								num2 = -1042126216;
								continue;
							}
							if (!offsetDown && num == 0)
							{
								num2 = -1042126209;
								continue;
							}
							if (offsetDown && num >= actionIds.Count - 1)
							{
								return false;
							}
							if (offsetNow)
							{
								value = actionIds[num];
								num2 = -1042126211;
							}
							else
							{
								num2 = -1042126214;
							}
							continue;
						case 1:
							actionIds[num + 1] = value;
							num2 = -1042126213;
							continue;
						case 0:
							return false;
						case 4:
							actionIds[num] = actionIds[num - 1];
							actionIds[num - 1] = value;
							num2 = -1042126210;
							continue;
						case 5:
						{
							int num3;
							if (!offsetDown)
							{
								num2 = -1042126212;
								num3 = num2;
							}
							else
							{
								num2 = -1042126223;
								num3 = num2;
							}
							continue;
						}
						case 3:
							num2 = -1042126210;
							continue;
						case 2:
							return true;
						case 9:
							actionIds[num] = actionIds[num + 1];
							num2 = -1042126215;
							continue;
						case 7:
							return false;
						default:
							return true;
						}
						break;
					}
				}
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
				int num = 0;
				while (num < actionIds.Count)
				{
					while (true)
					{
						if (actionIds[num] == id)
						{
							return num;
						}
						num++;
						int num2 = 820452512;
						while (true)
						{
							switch (num2 ^ 0x30E71CA0)
							{
							case 2:
								num2 = 820452513;
								continue;
							case 1:
								break;
							default:
								goto end_IL_002c;
							}
							break;
						}
						continue;
						end_IL_002c:
						break;
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

		private sealed class RqFpKkIVGBHGhItoYEsTjSgfGkz : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ActionCategoryMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int zibsNoozcWmIbXiNlCGtuaVyAdbg;

			public int OSuCJKRDGzMhxUyQqPmisRmDFmy;

			public int KPctKSCrmGENWwelUmjMOqNoWWA;

			public int pnHCTcPXPKMWUnKbzgOtJNTBDxz;

			public IEnumerator<int> EokOdlcXjiPKvDpdGtTvGmupFRQ;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0059;
				IL_0059:
				RqFpKkIVGBHGhItoYEsTjSgfGkz rqFpKkIVGBHGhItoYEsTjSgfGkz = new RqFpKkIVGBHGhItoYEsTjSgfGkz(0);
				rqFpKkIVGBHGhItoYEsTjSgfGkz.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = 1115159342;
				goto IL_0021;
				IL_001c:
				num = 1115159340;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x4277FB2E)
					{
					case 4:
						break;
					case 2:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						rqFpKkIVGBHGhItoYEsTjSgfGkz = this;
						num = 1115159341;
						continue;
					case 3:
						num = 1115159342;
						continue;
					case 1:
						goto IL_0059;
					default:
						rqFpKkIVGBHGhItoYEsTjSgfGkz.zibsNoozcWmIbXiNlCGtuaVyAdbg = OSuCJKRDGzMhxUyQqPmisRmDFmy;
						return rqFpKkIVGBHGhItoYEsTjSgfGkz;
					}
					break;
				}
				goto IL_001c;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.list == null)
						{
							break;
						}
						KPctKSCrmGENWwelUmjMOqNoWWA = iKQXbXnVtIaMZEJNeigQJWAHqUx.IndexOfCategory(zibsNoozcWmIbXiNlCGtuaVyAdbg);
						if (KPctKSCrmGENWwelUmjMOqNoWWA < 0)
						{
							break;
						}
						EokOdlcXjiPKvDpdGtTvGmupFRQ = iKQXbXnVtIaMZEJNeigQJWAHqUx.list[KPctKSCrmGENWwelUmjMOqNoWWA].ActionIds.GetEnumerator();
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 607502936;
						goto IL_0023;
					case 2:
						goto IL_010b;
						IL_0023:
						while (true)
						{
							switch (num ^ 0x2435C25B)
							{
							case 0:
								num = 607502937;
								continue;
							case 2:
								break;
							case 3:
								if (!EokOdlcXjiPKvDpdGtTvGmupFRQ.MoveNext())
								{
									IysrbvxrCSafpHSqkwpJjuQUWDV();
									num = 607502938;
									continue;
								}
								goto case 4;
							case 4:
								pnHCTcPXPKMWUnKbzgOtJNTBDxz = EokOdlcXjiPKvDpdGtTvGmupFRQ.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = pnHCTcPXPKMWUnKbzgOtJNTBDxz;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								return true;
							case 5:
								goto IL_010b;
							default:
								goto end_IL_0008;
							}
							break;
						}
						goto case 0;
						IL_010b:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 607502936;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						IysrbvxrCSafpHSqkwpJjuQUWDV();
					}
				}
			}

			[DebuggerHidden]
			public RqFpKkIVGBHGhItoYEsTjSgfGkz(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void IysrbvxrCSafpHSqkwpJjuQUWDV()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (EokOdlcXjiPKvDpdGtTvGmupFRQ != null)
				{
					EokOdlcXjiPKvDpdGtTvGmupFRQ.Dispose();
				}
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> list;

		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			RqFpKkIVGBHGhItoYEsTjSgfGkz rqFpKkIVGBHGhItoYEsTjSgfGkz = new RqFpKkIVGBHGhItoYEsTjSgfGkz(-2);
			rqFpKkIVGBHGhItoYEsTjSgfGkz.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			rqFpKkIVGBHGhItoYEsTjSgfGkz.OSuCJKRDGzMhxUyQqPmisRmDFmy = categoryId;
			return rqFpKkIVGBHGhItoYEsTjSgfGkz;
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
			while (true)
			{
				int num2 = -199643452;
				while (true)
				{
					switch (num2 ^ -199643450)
					{
					case 0:
						break;
					case 2:
					{
						int num3;
						if (num < 0)
						{
							num2 = -199643449;
							num3 = num2;
						}
						else
						{
							num2 = -199643451;
							num3 = num2;
						}
						continue;
					}
					case 1:
						return;
					default:
						list.RemoveAt(num);
						return;
					}
					break;
				}
			}
		}

		public bool ReorderCategory(int id, bool offsetDown)
		{
			int num = IndexOfCategory(id);
			Entry value = default(Entry);
			while (true)
			{
				int num2 = 164102170;
				while (true)
				{
					switch (num2 ^ 0x9C80018)
					{
					case 4:
						break;
					case 3:
						list[num] = list[num - 1];
						list[num - 1] = value;
						num2 = 164102168;
						continue;
					case 1:
						return false;
					case 2:
						if (num < 0)
						{
							return false;
						}
						if (offsetDown || num != 0)
						{
							if (offsetDown && num >= list.Count - 1)
							{
								return false;
							}
							value = list[num];
							if (offsetDown)
							{
								list[num] = list[num + 1];
								list[num + 1] = value;
								num2 = 164102168;
								continue;
							}
							goto case 3;
						}
						num2 = 164102169;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			if (list == null)
			{
				return false;
			}
			bool result = false;
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -785528615;
				while (true)
				{
					switch (num2 ^ -785528609)
					{
					case 10:
						break;
					case 9:
						if (num >= list.Count)
						{
							num3 = 0;
							num2 = -785528609;
							continue;
						}
						goto case 1;
					case 2:
						result = true;
						num2 = -785528612;
						continue;
					case 5:
						list[num3].AddAction(actionId);
						num2 = -785528611;
						continue;
					case 6:
						num2 = -785528618;
						continue;
					case 3:
						num3++;
						num2 = -785528609;
						continue;
					case 1:
					{
						int num5;
						if (list[num].ContainsAction(actionId))
						{
							num2 = -785528617;
							num5 = num2;
						}
						else
						{
							num2 = -785528616;
							num5 = num2;
						}
						continue;
					}
					case 8:
						list[num].RemoveAction(actionId);
						num2 = -785528616;
						continue;
					case 4:
					{
						int num4;
						if (list[num3].categoryId == newCategoryId)
						{
							num2 = -785528614;
							num4 = num2;
						}
						else
						{
							num2 = -785528612;
							num4 = num2;
						}
						continue;
					}
					case 7:
						num++;
						num2 = -785528618;
						continue;
					default:
						if (num3 >= list.Count)
						{
							return result;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public int IndexOfCategory(int id)
		{
			if (list == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 720536622;
				while (true)
				{
					switch (num2 ^ 0x2AF2842D)
					{
					case 2:
						break;
					case 3:
						num2 = 720536620;
						continue;
					case 0:
						if (list[num].categoryId == id)
						{
							return num;
						}
						num++;
						num2 = 720536620;
						continue;
					default:
						if (num >= list.Count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public bool AddAction(int categoryId, int actionId)
		{
			if (list == null)
			{
				goto IL_0008;
			}
			int num = IndexOfCategory(categoryId);
			int num2;
			if (num < 0)
			{
				num2 = 1332442385;
			}
			else
			{
				list[num].AddAction(actionId);
				num2 = 1332442384;
			}
			goto IL_000d;
			IL_0008:
			num2 = 1332442386;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ 0x4F6B7510)
			{
			case 3:
				break;
			case 2:
				return false;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0008;
		}

		public bool InsertAction(int categoryId, int actionId, int index)
		{
			if (index < 0)
			{
				goto IL_0004;
			}
			int num = IndexOfCategory(categoryId);
			int num2 = 1672379032;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num2 ^ 0x63AE7A9B)
				{
				case 0:
					break;
				case 2:
					return false;
				case 3:
					if (num < 0)
					{
						goto IL_003b;
					}
					return list[num].InsertAction(actionId, index);
				default:
					return false;
				}
				break;
				IL_003b:
				num2 = 1672379034;
			}
			goto IL_0004;
			IL_0004:
			num2 = 1672379033;
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
