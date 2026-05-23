using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class BYWhcxyfFJAbsgDmIQLeLndiLqre : IComparer<ActionElementMap>
		{
			public static BYWhcxyfFJAbsgDmIQLeLndiLqre LDwDTzcqSaJaAJzktFPjtpIxftC;

			public static BYWhcxyfFJAbsgDmIQLeLndiLqre Default
			{
				get
				{
					return LDwDTzcqSaJaAJzktFPjtpIxftC ?? (LDwDTzcqSaJaAJzktFPjtpIxftC = new BYWhcxyfFJAbsgDmIQLeLndiLqre());
				}
			}

			public int Compare(ActionElementMap x, ActionElementMap y)
			{
				if (x == null)
				{
					goto IL_0003;
				}
				if (y == null)
				{
					return 1;
				}
				if (x._elementType == y._elementType)
				{
					return x.id.CompareTo(y.id);
				}
				switch (x._elementType)
				{
				case ControllerElementType.Axis:
					goto IL_00d2;
				case ControllerElementType.CompoundElement:
					goto IL_00de;
				case ControllerElementType.Button:
					goto IL_00ea;
				}
				int num = 1254066921;
				goto IL_0008;
				IL_0008:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x4ABF8AEB)
					{
					case 5:
						break;
					case 9:
						goto IL_0048;
					case 0:
						throw new NotImplementedException();
					case 8:
						switch (y._elementType)
						{
						case ControllerElementType.Axis:
							goto IL_0106;
						case ControllerElementType.CompoundElement:
							goto IL_0112;
						case ControllerElementType.Button:
							goto IL_011e;
						}
						num = 1254066923;
						continue;
					case 3:
						goto IL_00d2;
					case 11:
						goto IL_00de;
					case 10:
						goto IL_00ea;
					case 2:
						throw new NotImplementedException();
					case 7:
						goto IL_0106;
					case 4:
						goto IL_0112;
					case 6:
						goto IL_011e;
					default:
						goto IL_012a;
						IL_011e:
						num2 = 0;
						num = 1254066922;
						continue;
						IL_0112:
						num2 = 2;
						num = 1254066922;
						continue;
						IL_0106:
						num2 = 1;
						num = 1254066922;
						continue;
					}
					break;
				}
				goto IL_0003;
				IL_012a:
				int num3 = default(int);
				if (num3 <= num2)
				{
					return -1;
				}
				return 1;
				IL_00de:
				num3 = 2;
				num = 1254066915;
				goto IL_0008;
				IL_00ea:
				num3 = 0;
				num = 1254066915;
				goto IL_0008;
				IL_00d2:
				num3 = 1;
				num = 1254066915;
				goto IL_0008;
				IL_0048:
				if (y == null)
				{
					return 0;
				}
				return -1;
				IL_0003:
				num = 1254066914;
				goto IL_0008;
			}
		}

		private sealed class hBQAHblxtOixmdPJpamkZvQEafe : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

			public int EWQVMNaYUmlNevCoyIethJojVez;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public ActionElementMap qHFvxOmqgACMfmejWgrwrmZiAqoC;

			public IEnumerator<ActionElementMap> AsRlFjnbjSBLrcANLpabHIHimJLO;

			ActionElementMap IEnumerator<ActionElementMap>.Current
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				hBQAHblxtOixmdPJpamkZvQEafe hBQAHblxtOixmdPJpamkZvQEafe2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					hBQAHblxtOixmdPJpamkZvQEafe2 = this;
				}
				else
				{
					while (true)
					{
						hBQAHblxtOixmdPJpamkZvQEafe2 = new hBQAHblxtOixmdPJpamkZvQEafe(0);
						int num = 61044905;
						while (true)
						{
							switch (num ^ 0x3A378AA)
							{
							case 0:
								num = 61044904;
								continue;
							case 2:
								break;
							case 3:
								hBQAHblxtOixmdPJpamkZvQEafe2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = 61044907;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				hBQAHblxtOixmdPJpamkZvQEafe2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = EWQVMNaYUmlNevCoyIethJojVez;
				hBQAHblxtOixmdPJpamkZvQEafe2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
				return hBQAHblxtOixmdPJpamkZvQEafe2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = -1199199298;
						goto IL_001e;
					case 2:
						goto IL_0086;
					case 1:
						goto IL_0104;
					case 0:
						goto IL_0158;
						IL_001e:
						while (true)
						{
							switch (num ^ -1199199297)
							{
							case 13:
								break;
							default:
								goto end_IL_0008;
							case 1:
								num = -1199199303;
								continue;
							case 8:
								result = true;
								goto end_IL_0008;
							case 7:
								num = -1199199307;
								continue;
							case 4:
								goto IL_0086;
							case 14:
								goto IL_0094;
							case 3:
								qHFvxOmqgACMfmejWgrwrmZiAqoC = AsRlFjnbjSBLrcANLpabHIHimJLO.Current;
								if (qHFvxOmqgACMfmejWgrwrmZiAqoC._actionId == CcfTFbvLTcqsiXVrUOCJWGLeCzX)
								{
									if (kUWZXXVHFictxLEMjETmHtCiqtXG)
									{
										goto IL_00e3;
									}
									goto case 5;
								}
								goto IL_018f;
							case 6:
								goto IL_0104;
							case 11:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								num = -1199199305;
								continue;
							case 12:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -1199199304;
								continue;
							case 0:
								USsmtEKltWHMUcUQRNXjCUFqiAR();
								num = -1199199303;
								continue;
							case 5:
								aimBzjfQfPyaeQqysAQJISCBhELB = qHFvxOmqgACMfmejWgrwrmZiAqoC;
								num = -1199199308;
								continue;
							case 2:
								goto IL_0158;
							case 10:
								goto IL_018f;
							case 9:
								goto end_IL_0008;
							}
							break;
							IL_00e3:
							int num2;
							if (!qHFvxOmqgACMfmejWgrwrmZiAqoC.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = -1199199307;
								num2 = num;
							}
							else
							{
								num = -1199199302;
								num2 = num;
							}
							continue;
							IL_018f:
							int num3;
							if (AsRlFjnbjSBLrcANLpabHIHimJLO.MoveNext())
							{
								num = -1199199300;
								num3 = num;
							}
							else
							{
								num = -1199199297;
								num3 = num;
							}
						}
						goto default;
						IL_0158:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
						{
							ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1199199303;
							goto IL_001e;
						}
						goto IL_0094;
						IL_0086:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = -1199199307;
						goto IL_001e;
						IL_0104:
						result = false;
						num = -1199199306;
						goto IL_001e;
						IL_0094:
						AsRlFjnbjSBLrcANLpabHIHimJLO = iKQXbXnVtIaMZEJNeigQJWAHqUx.AllMaps.GetEnumerator();
						num = -1199199309;
						goto IL_001e;
						end_IL_0008:
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
						USsmtEKltWHMUcUQRNXjCUFqiAR();
					}
				}
			}

			[DebuggerHidden]
			public hBQAHblxtOixmdPJpamkZvQEafe(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void USsmtEKltWHMUcUQRNXjCUFqiAR()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (AsRlFjnbjSBLrcANLpabHIHimJLO != null)
				{
					AsRlFjnbjSBLrcANLpabHIHimJLO.Dispose();
				}
			}
		}

		private sealed class tZylLiLLKKHunCYpEibyMlNAvxD : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public IControllerElementTarget LFzrUiqiisTUXrIBpGnYBVqRDYV;

			public IControllerElementTarget tUZNcgHLkjgLHurvnNVMybtwcTo;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public TempListPool.TList<ActionElementMap> kNzxJJuAHGmikifjObiZegUkMCH;

			public List<ActionElementMap> LAatUHXlkqukyjdaeKJoNJhhSzH;

			public bool MuHXCDTqUSvXMtocdvfPKvyhnyY;

			public ActionElementMap CZroCKWQDUpbFteFKwywATIxlEZ;

			public List<ActionElementMap>.Enumerator mhGCLvEJcBQcOLyPRvZRjAgaeurF;

			ActionElementMap IEnumerator<ActionElementMap>.Current
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId != HbSVCfYbFQknCSDIuBJpKcqKonb || oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
				{
					goto IL_0049;
				}
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
				tZylLiLLKKHunCYpEibyMlNAvxD tZylLiLLKKHunCYpEibyMlNAvxD2 = this;
				goto IL_0063;
				IL_002c:
				int num;
				while (true)
				{
					switch (num ^ -1293059284)
					{
					case 3:
						num = -1293059283;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0063;
					default:
						return tZylLiLLKKHunCYpEibyMlNAvxD2;
					}
					break;
				}
				goto IL_0049;
				IL_0049:
				tZylLiLLKKHunCYpEibyMlNAvxD2 = new tZylLiLLKKHunCYpEibyMlNAvxD(0);
				tZylLiLLKKHunCYpEibyMlNAvxD2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -1293059284;
				goto IL_002c;
				IL_0063:
				tZylLiLLKKHunCYpEibyMlNAvxD2.LFzrUiqiisTUXrIBpGnYBVqRDYV = tUZNcgHLkjgLHurvnNVMybtwcTo;
				tZylLiLLKKHunCYpEibyMlNAvxD2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
				num = -1293059282;
				goto IL_002c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					if (num == 0)
					{
						goto IL_00ed;
					}
					if (num == 3)
					{
						goto IL_00fe;
					}
					goto IL_0189;
					IL_00ed:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					int num2 = 1598995291;
					goto IL_001f;
					IL_00fe:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
					num2 = 1598995283;
					goto IL_001f;
					IL_001f:
					while (true)
					{
						switch (num2 ^ 0x5F4EBB53)
						{
						case 9:
							num2 = 1598995285;
							continue;
						case 10:
							kNzxJJuAHGmikifjObiZegUkMCH = TempListPool.GetTList<ActionElementMap>();
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							LAatUHXlkqukyjdaeKJoNJhhSzH = kNzxJJuAHGmikifjObiZegUkMCH.list;
							iKQXbXnVtIaMZEJNeigQJWAHqUx.GetElementMapsWithElementTarget(LFzrUiqiisTUXrIBpGnYBVqRDYV, false, -1, kUWZXXVHFictxLEMjETmHtCiqtXG, LAatUHXlkqukyjdaeKJoNJhhSzH, false, out MuHXCDTqUSvXMtocdvfPKvyhnyY);
							mhGCLvEJcBQcOLyPRvZRjAgaeurF = LAatUHXlkqukyjdaeKJoNJhhSzH.GetEnumerator();
							num2 = 1598995282;
							continue;
						case 8:
							if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
							{
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num2 = 1598995280;
								continue;
							}
							goto case 10;
						case 6:
							break;
						case 5:
							goto IL_00fe;
						case 4:
							CZroCKWQDUpbFteFKwywATIxlEZ = mhGCLvEJcBQcOLyPRvZRjAgaeurF.Current;
							aimBzjfQfPyaeQqysAQJISCBhELB = CZroCKWQDUpbFteFKwywATIxlEZ;
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
							return true;
						case 3:
							num2 = 1598995284;
							continue;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
							num2 = 1598995281;
							continue;
						case 2:
							num2 = 1598995283;
							continue;
						case 0:
							if (!mhGCLvEJcBQcOLyPRvZRjAgaeurF.MoveNext())
							{
								mvaUdbiVfchTKfiNJNXayeZgiVG();
								VEYwKZLUxYlPaNNFujjgzEpijjAC();
								num2 = 1598995284;
								continue;
							}
							goto case 4;
						default:
							goto IL_0189;
						}
						break;
					}
					goto IL_00ed;
					IL_0189:
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
				case 3:
					try
					{
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								mvaUdbiVfchTKfiNJNXayeZgiVG();
							}
						}
						break;
					}
					finally
					{
						VEYwKZLUxYlPaNNFujjgzEpijjAC();
					}
				}
			}

			[DebuggerHidden]
			public tZylLiLLKKHunCYpEibyMlNAvxD(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void VEYwKZLUxYlPaNNFujjgzEpijjAC()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (kNzxJJuAHGmikifjObiZegUkMCH == null)
				{
					return;
				}
				while (true)
				{
					int num = -135972455;
					while (true)
					{
						switch (num ^ -135972456)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 0:
							return;
						}
						break;
						IL_002d:
						((IDisposable)kNzxJJuAHGmikifjObiZegUkMCH).Dispose();
						num = -135972456;
					}
				}
			}

			private void mvaUdbiVfchTKfiNJNXayeZgiVG()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
				((IDisposable)mhGCLvEJcBQcOLyPRvZRjAgaeurF/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class lTNDbsiKTSWcZvCaauIosDKaaiXE : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public IControllerElementTarget LFzrUiqiisTUXrIBpGnYBVqRDYV;

			public IControllerElementTarget tUZNcgHLkjgLHurvnNVMybtwcTo;

			public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

			public int EWQVMNaYUmlNevCoyIethJojVez;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public TempListPool.TList<ActionElementMap> hqBxUFjeVFJyIxYEaNWVFFQLsdQ;

			public List<ActionElementMap> GszKSsFmKgbCJGQdAJdDgkOARrfD;

			public bool MvopUjIYgqMjGKABOUBeGZLBHNq;

			public ActionElementMap wJWXfKQqQCgBcuzUtzCFXMbGugS;

			public List<ActionElementMap>.Enumerator hUcgKzNIAxyUNDkGOMnYdunnWKc;

			ActionElementMap IEnumerator<ActionElementMap>.Current
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_004e;
				IL_0012:
				int num = 339879371;
				goto IL_0017;
				IL_0017:
				lTNDbsiKTSWcZvCaauIosDKaaiXE lTNDbsiKTSWcZvCaauIosDKaaiXE2 = default(lTNDbsiKTSWcZvCaauIosDKaaiXE);
				while (true)
				{
					switch (num ^ 0x144225C9)
					{
					case 0:
						break;
					case 2:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							lTNDbsiKTSWcZvCaauIosDKaaiXE2 = this;
							num = 339879368;
							continue;
						}
						goto IL_004e;
					case 3:
						goto IL_004e;
					default:
						lTNDbsiKTSWcZvCaauIosDKaaiXE2.LFzrUiqiisTUXrIBpGnYBVqRDYV = tUZNcgHLkjgLHurvnNVMybtwcTo;
						lTNDbsiKTSWcZvCaauIosDKaaiXE2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = EWQVMNaYUmlNevCoyIethJojVez;
						lTNDbsiKTSWcZvCaauIosDKaaiXE2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						return lTNDbsiKTSWcZvCaauIosDKaaiXE2;
					}
					break;
				}
				goto IL_0012;
				IL_004e:
				lTNDbsiKTSWcZvCaauIosDKaaiXE2 = new lTNDbsiKTSWcZvCaauIosDKaaiXE(0);
				lTNDbsiKTSWcZvCaauIosDKaaiXE2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 339879368;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					if (num != 0)
					{
						goto IL_000e;
					}
					goto IL_00aa;
					IL_000e:
					int num2 = 1932391196;
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num2 ^ 0x732DF315)
						{
						case 3:
							break;
						case 8:
							return true;
						case 6:
							num2 = 1932391186;
							continue;
						case 1:
							goto IL_006c;
						case 11:
							QVBfDkNyoxSqFzfZlasqgzAuhBQ();
							num2 = 1932391186;
							continue;
						case 5:
							bQDOjdPYvJNcHibansUphgXtRYS();
							num2 = 1932391198;
							continue;
						case 2:
							goto IL_00aa;
						case 10:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
							num2 = 1932391197;
							continue;
						case 9:
							goto IL_00ef;
						case 4:
							goto IL_0107;
						case 0:
							wJWXfKQqQCgBcuzUtzCFXMbGugS = hUcgKzNIAxyUNDkGOMnYdunnWKc.Current;
							aimBzjfQfPyaeQqysAQJISCBhELB = wJWXfKQqQCgBcuzUtzCFXMbGugS;
							num2 = 1932391199;
							continue;
						case 12:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
							num2 = 1932391188;
							continue;
						default:
							return false;
						}
						break;
						IL_00ef:
						int num3;
						if (num != 3)
						{
							num2 = 1932391187;
							num3 = num2;
						}
						else
						{
							num2 = 1932391193;
							num3 = num2;
						}
						continue;
						IL_006c:
						int num4;
						if (!hUcgKzNIAxyUNDkGOMnYdunnWKc.MoveNext())
						{
							num2 = 1932391184;
							num4 = num2;
						}
						else
						{
							num2 = 1932391189;
							num4 = num2;
						}
					}
					goto IL_000e;
					IL_0107:
					hqBxUFjeVFJyIxYEaNWVFFQLsdQ = TempListPool.GetTList<ActionElementMap>();
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
					GszKSsFmKgbCJGQdAJdDgkOARrfD = hqBxUFjeVFJyIxYEaNWVFFQLsdQ.list;
					iKQXbXnVtIaMZEJNeigQJWAHqUx.GetElementMapsWithElementTarget(LFzrUiqiisTUXrIBpGnYBVqRDYV, true, CcfTFbvLTcqsiXVrUOCJWGLeCzX, kUWZXXVHFictxLEMjETmHtCiqtXG, GszKSsFmKgbCJGQdAJdDgkOARrfD, false, out MvopUjIYgqMjGKABOUBeGZLBHNq);
					hUcgKzNIAxyUNDkGOMnYdunnWKc = GszKSsFmKgbCJGQdAJdDgkOARrfD.GetEnumerator();
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
					num2 = 1932391188;
					goto IL_0013;
					IL_00aa:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num2 = 1932391186;
						goto IL_0013;
					}
					goto IL_0107;
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
				case 3:
					try
					{
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								bQDOjdPYvJNcHibansUphgXtRYS();
							}
						}
						break;
					}
					finally
					{
						QVBfDkNyoxSqFzfZlasqgzAuhBQ();
					}
				}
			}

			[DebuggerHidden]
			public lTNDbsiKTSWcZvCaauIosDKaaiXE(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void QVBfDkNyoxSqFzfZlasqgzAuhBQ()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (hqBxUFjeVFJyIxYEaNWVFFQLsdQ == null)
				{
					return;
				}
				while (true)
				{
					int num = 1556095544;
					while (true)
					{
						switch (num ^ 0x5CC02239)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 0:
							return;
						}
						break;
						IL_002d:
						((IDisposable)hqBxUFjeVFJyIxYEaNWVFFQLsdQ).Dispose();
						num = 1556095545;
					}
				}
			}

			private void bQDOjdPYvJNcHibansUphgXtRYS()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
				((IDisposable)hUcgKzNIAxyUNDkGOMnYdunnWKc/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class bFPiLhdwcicGGvTpgIaULZEOYLCf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

			public int EWQVMNaYUmlNevCoyIethJojVez;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public IList<ActionElementMap> wssLictxkAKWaDQJhoHiAOtmskS;

			public int kkbbjuZKCnRKEoluxMVtIubKvTV;

			public int UNIizaTiexgWYkgpjhWZXiceAEd;

			public ActionElementMap IRQCtJkXFnQIcnJqaLJMxawJfcvj;

			ActionElementMap IEnumerator<ActionElementMap>.Current
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0054;
				IL_0054:
				bFPiLhdwcicGGvTpgIaULZEOYLCf bFPiLhdwcicGGvTpgIaULZEOYLCf2 = new bFPiLhdwcicGGvTpgIaULZEOYLCf(0);
				bFPiLhdwcicGGvTpgIaULZEOYLCf2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = -1206854976;
				goto IL_0021;
				IL_001c:
				num = -1206854973;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -1206854976)
					{
					case 4:
						break;
					case 3:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						num = -1206854974;
						continue;
					case 5:
						goto IL_0054;
					case 0:
						bFPiLhdwcicGGvTpgIaULZEOYLCf2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = EWQVMNaYUmlNevCoyIethJojVez;
						num = -1206854975;
						continue;
					case 2:
						bFPiLhdwcicGGvTpgIaULZEOYLCf2 = this;
						num = -1206854976;
						continue;
					default:
						bFPiLhdwcicGGvTpgIaULZEOYLCf2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						return bFPiLhdwcicGGvTpgIaULZEOYLCf2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -494456928;
					while (true)
					{
						switch (num2 ^ -494456923)
						{
						case 8:
							break;
						case 9:
							UNIizaTiexgWYkgpjhWZXiceAEd++;
							num2 = -494456925;
							continue;
						case 6:
						{
							int num4;
							if (UNIizaTiexgWYkgpjhWZXiceAEd >= kkbbjuZKCnRKEoluxMVtIubKvTV)
							{
								num2 = -494456921;
								num4 = num2;
							}
							else
							{
								num2 = -494456913;
								num4 = num2;
							}
							continue;
						}
						case 12:
							num2 = -494456921;
							continue;
						case 5:
							switch (num)
							{
							default:
								num2 = -494456926;
								continue;
							case 0:
								break;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -494456916;
								continue;
							}
							goto case 0;
						case 3:
						{
							int num5;
							if (!IRQCtJkXFnQIcnJqaLJMxawJfcvj.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num2 = -494456916;
								num5 = num2;
							}
							else
							{
								num2 = -494456914;
								num5 = num2;
							}
							continue;
						}
						case 10:
							IRQCtJkXFnQIcnJqaLJMxawJfcvj = wssLictxkAKWaDQJhoHiAOtmskS[UNIizaTiexgWYkgpjhWZXiceAEd];
							if (IRQCtJkXFnQIcnJqaLJMxawJfcvj._actionId == CcfTFbvLTcqsiXVrUOCJWGLeCzX)
							{
								int num3;
								if (kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									num2 = -494456922;
									num3 = num2;
								}
								else
								{
									num2 = -494456914;
									num3 = num2;
								}
								continue;
							}
							goto case 9;
						case 7:
							num2 = -494456921;
							continue;
						case 1:
							kkbbjuZKCnRKEoluxMVtIubKvTV = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttonMapCount;
							UNIizaTiexgWYkgpjhWZXiceAEd = 0;
							num2 = -494456925;
							continue;
						case 4:
							if (CcfTFbvLTcqsiXVrUOCJWGLeCzX >= 0)
							{
								wssLictxkAKWaDQJhoHiAOtmskS = iKQXbXnVtIaMZEJNeigQJWAHqUx.ButtonMaps;
								num2 = -494456924;
								continue;
							}
							goto default;
						case 0:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
							{
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num2 = -494456919;
								continue;
							}
							goto case 4;
						case 11:
							aimBzjfQfPyaeQqysAQJISCBhELB = IRQCtJkXFnQIcnJqaLJMxawJfcvj;
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
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
			public bFPiLhdwcicGGvTpgIaULZEOYLCf(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class TYCFQrmiDKXwjwnjCQAfipkSnCi : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ControllerMap NsnpsJhWvVdnFvGpHHimGkwdsno;

			public ControllerMap AkCCOPqWBDIoelQfBDGjGqsxrCK;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public IList<ActionElementMap> YODehZgjvlgxsyIAwnDHQKJXDTl;

			public int jvkseXunhRjGCdgCtaJkqtYcZKX;

			public int JmZjyktiBNVFsYKiWeBvNsBARcV;

			public ActionElementMap ugaiDoAhEOgPwcnMlBjzhMKDTnJ;

			public int aAiHiVrRPilovociEpINvpAdFrE;

			public ActionElementMap mKQMOhMclJznoqubMyKkLcOVdnB;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0056;
				IL_0012:
				int num = 1138315121;
				goto IL_0017;
				IL_0017:
				TYCFQrmiDKXwjwnjCQAfipkSnCi tYCFQrmiDKXwjwnjCQAfipkSnCi = default(TYCFQrmiDKXwjwnjCQAfipkSnCi);
				while (true)
				{
					switch (num ^ 0x43D94F75)
					{
					case 5:
						break;
					case 4:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							tYCFQrmiDKXwjwnjCQAfipkSnCi = this;
							num = 1138315126;
							continue;
						}
						goto IL_0056;
					case 1:
						goto IL_0056;
					case 2:
						tYCFQrmiDKXwjwnjCQAfipkSnCi.NsnpsJhWvVdnFvGpHHimGkwdsno = AkCCOPqWBDIoelQfBDGjGqsxrCK;
						tYCFQrmiDKXwjwnjCQAfipkSnCi.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						num = 1138315125;
						continue;
					case 3:
						num = 1138315127;
						continue;
					default:
						return tYCFQrmiDKXwjwnjCQAfipkSnCi;
					}
					break;
				}
				goto IL_0012;
				IL_0056:
				tYCFQrmiDKXwjwnjCQAfipkSnCi = new TYCFQrmiDKXwjwnjCQAfipkSnCi(0);
				tYCFQrmiDKXwjwnjCQAfipkSnCi.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 1138315127;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 860120071;
					while (true)
					{
						switch (num2 ^ 0x3344640F)
						{
						case 5:
							break;
						case 6:
							ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num2 = 860120079;
							continue;
						case 10:
							num2 = 860120079;
							continue;
						case 4:
						{
							ugaiDoAhEOgPwcnMlBjzhMKDTnJ = iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc[JmZjyktiBNVFsYKiWeBvNsBARcV];
							int num7;
							if (kUWZXXVHFictxLEMjETmHtCiqtXG)
							{
								num2 = 860120094;
								num7 = num2;
							}
							else
							{
								num2 = 860120091;
								num7 = num2;
							}
							continue;
						}
						case 16:
							YODehZgjvlgxsyIAwnDHQKJXDTl = NsnpsJhWvVdnFvGpHHimGkwdsno.ButtonMaps;
							if (YODehZgjvlgxsyIAwnDHQKJXDTl != null)
							{
								jvkseXunhRjGCdgCtaJkqtYcZKX = YODehZgjvlgxsyIAwnDHQKJXDTl.Count;
								num2 = 860120070;
								continue;
							}
							goto default;
						case 19:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							num2 = 860120077;
							continue;
						case 15:
							JmZjyktiBNVFsYKiWeBvNsBARcV++;
							num2 = 860120065;
							continue;
						case 20:
							aAiHiVrRPilovociEpINvpAdFrE = 0;
							num2 = 860120072;
							continue;
						case 7:
							num2 = 860120068;
							continue;
						case 17:
						{
							int num6;
							if (!ugaiDoAhEOgPwcnMlBjzhMKDTnJ.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num2 = 860120064;
								num6 = num2;
							}
							else
							{
								num2 = 860120091;
								num6 = num2;
							}
							continue;
						}
						case 12:
							if (NsnpsJhWvVdnFvGpHHimGkwdsno != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc != null)
							{
								if (!kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									goto case 16;
								}
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx._enabled)
								{
									int num9;
									if (!NsnpsJhWvVdnFvGpHHimGkwdsno._enabled)
									{
										num2 = 860120079;
										num9 = num2;
									}
									else
									{
										num2 = 860120095;
										num9 = num2;
									}
									continue;
								}
							}
							goto default;
						case 1:
							aAiHiVrRPilovociEpINvpAdFrE++;
							num2 = 860120068;
							continue;
						case 11:
						{
							int num8;
							if (aAiHiVrRPilovociEpINvpAdFrE < jvkseXunhRjGCdgCtaJkqtYcZKX)
							{
								num2 = 860120093;
								num8 = num2;
							}
							else
							{
								num2 = 860120064;
								num8 = num2;
							}
							continue;
						}
						case 13:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							int num5;
							if (ReInput._id == iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
							{
								num2 = 860120067;
								num5 = num2;
							}
							else
							{
								num2 = 860120073;
								num5 = num2;
							}
							continue;
						}
						case 3:
							if (ugaiDoAhEOgPwcnMlBjzhMKDTnJ.CheckForAssignmentConflict(mKQMOhMclJznoqubMyKkLcOVdnB))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(iKQXbXnVtIaMZEJNeigQJWAHqUx._categoryId).userAssignable, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerType, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerId, iKQXbXnVtIaMZEJNeigQJWAHqUx._id, ugaiDoAhEOgPwcnMlBjzhMKDTnJ.rOuBUzbbciWwktcpmiPWpQIKoaAa, ugaiDoAhEOgPwcnMlBjzhMKDTnJ._actionId, ugaiDoAhEOgPwcnMlBjzhMKDTnJ._elementType, ugaiDoAhEOgPwcnMlBjzhMKDTnJ._elementIdentifierId, ugaiDoAhEOgPwcnMlBjzhMKDTnJ.keyCode, ugaiDoAhEOgPwcnMlBjzhMKDTnJ.modifierKeyFlags);
								num2 = 860120092;
								continue;
							}
							goto case 1;
						case 14:
						{
							int num4;
							if (JmZjyktiBNVFsYKiWeBvNsBARcV >= iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc.Count)
							{
								num2 = 860120079;
								num4 = num2;
							}
							else
							{
								num2 = 860120075;
								num4 = num2;
							}
							continue;
						}
						case 8:
							switch (num)
							{
							case 0:
								break;
							default:
								num2 = 860120069;
								continue;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 860120078;
								continue;
							}
							goto case 13;
						case 9:
							JmZjyktiBNVFsYKiWeBvNsBARcV = 0;
							num2 = 860120065;
							continue;
						case 2:
							return true;
						case 18:
							mKQMOhMclJznoqubMyKkLcOVdnB = YODehZgjvlgxsyIAwnDHQKJXDTl[aAiHiVrRPilovociEpINvpAdFrE];
							if (kUWZXXVHFictxLEMjETmHtCiqtXG)
							{
								int num3;
								if (mKQMOhMclJznoqubMyKkLcOVdnB.PAfqntGWZaNgzmZFIOyQPuJGOCq)
								{
									num2 = 860120076;
									num3 = num2;
								}
								else
								{
									num2 = 860120078;
									num3 = num2;
								}
								continue;
							}
							goto case 3;
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
			public TYCFQrmiDKXwjwnjCQAfipkSnCi(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ukQbTZriQgkmSpjbotJIZKCXGQP : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ActionElementMap zZOKcJvuOQCLBInkTSUcrEfEQnB;

			public ActionElementMap WfePqZKTzLLSOkMcfaksZhTkOHF;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public int lnTrFYNctSGsJnBlDyQGhaFDIiE;

			public ActionElementMap WSNZGEGNGaiyLAqMpJnUKoSggJhI;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				ukQbTZriQgkmSpjbotJIZKCXGQP ukQbTZriQgkmSpjbotJIZKCXGQP2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					ukQbTZriQgkmSpjbotJIZKCXGQP2 = this;
					goto IL_0025;
				}
				goto IL_006a;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -121916486)
					{
					case 3:
						break;
					case 4:
						ukQbTZriQgkmSpjbotJIZKCXGQP2.zZOKcJvuOQCLBInkTSUcrEfEQnB = WfePqZKTzLLSOkMcfaksZhTkOHF;
						ukQbTZriQgkmSpjbotJIZKCXGQP2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						num = -121916486;
						continue;
					case 1:
						goto IL_006a;
					case 2:
						num = -121916482;
						continue;
					default:
						return ukQbTZriQgkmSpjbotJIZKCXGQP2;
					}
					break;
				}
				goto IL_0025;
				IL_006a:
				ukQbTZriQgkmSpjbotJIZKCXGQP2 = new ukQbTZriQgkmSpjbotJIZKCXGQP(0);
				ukQbTZriQgkmSpjbotJIZKCXGQP2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -121916482;
				goto IL_002a;
				IL_0025:
				num = -121916488;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				int num7;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				default:
					num = -1947513745;
					goto IL_001a;
				case 0:
					goto IL_008b;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -1947513755;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ -1947513748)
						{
						case 0:
							break;
						case 8:
							goto IL_0066;
						case 13:
							num = -1947513750;
							continue;
						case 12:
							goto IL_008b;
						case 10:
							goto IL_00bf;
						case 1:
							goto IL_00db;
						case 3:
							num = -1947513758;
							continue;
						case 9:
							lnTrFYNctSGsJnBlDyQGhaFDIiE++;
							num = -1947513750;
							continue;
						case 5:
							goto IL_011e;
						case 7:
							if (WSNZGEGNGaiyLAqMpJnUKoSggJhI.CheckForAssignmentConflict(zZOKcJvuOQCLBInkTSUcrEfEQnB))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(iKQXbXnVtIaMZEJNeigQJWAHqUx._categoryId).userAssignable, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerType, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerId, iKQXbXnVtIaMZEJNeigQJWAHqUx._id, WSNZGEGNGaiyLAqMpJnUKoSggJhI.rOuBUzbbciWwktcpmiPWpQIKoaAa, WSNZGEGNGaiyLAqMpJnUKoSggJhI._actionId, WSNZGEGNGaiyLAqMpJnUKoSggJhI._elementType, WSNZGEGNGaiyLAqMpJnUKoSggJhI._elementIdentifierId, WSNZGEGNGaiyLAqMpJnUKoSggJhI.keyCode, WSNZGEGNGaiyLAqMpJnUKoSggJhI.modifierKeyFlags);
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 9;
						case 2:
							if (kUWZXXVHFictxLEMjETmHtCiqtXG)
							{
								goto IL_0209;
							}
							goto case 11;
						case 11:
							lnTrFYNctSGsJnBlDyQGhaFDIiE = 0;
							num = -1947513759;
							continue;
						case 4:
							WSNZGEGNGaiyLAqMpJnUKoSggJhI = iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc[lnTrFYNctSGsJnBlDyQGhaFDIiE];
							num = -1947513754;
							continue;
						case 6:
							goto IL_0261;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0261:
						int num2;
						if (lnTrFYNctSGsJnBlDyQGhaFDIiE >= iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc.Count)
						{
							num = -1947513758;
							num2 = num;
						}
						else
						{
							num = -1947513752;
							num2 = num;
						}
						continue;
						IL_00bf:
						int num3;
						if (!kUWZXXVHFictxLEMjETmHtCiqtXG)
						{
							num = -1947513749;
							num3 = num;
						}
						else
						{
							num = -1947513747;
							num3 = num;
						}
						continue;
						IL_0066:
						int num4;
						if (!zZOKcJvuOQCLBInkTSUcrEfEQnB.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num = -1947513758;
							num4 = num;
						}
						else
						{
							num = -1947513753;
							num4 = num;
						}
						continue;
						IL_0209:
						int num5;
						if (!iKQXbXnVtIaMZEJNeigQJWAHqUx._enabled)
						{
							num = -1947513758;
							num5 = num;
						}
						else
						{
							num = -1947513756;
							num5 = num;
						}
						continue;
						IL_00db:
						int num6;
						if (!WSNZGEGNGaiyLAqMpJnUKoSggJhI.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num = -1947513755;
							num6 = num;
						}
						else
						{
							num = -1947513749;
							num6 = num;
						}
					}
					goto default;
					IL_008b:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -1947513758;
						goto IL_001a;
					}
					goto IL_011e;
					IL_011e:
					if (zZOKcJvuOQCLBInkTSUcrEfEQnB == null)
					{
						break;
					}
					if (iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
					{
						num = -1947513758;
						num7 = num;
					}
					else
					{
						num = -1947513746;
						num7 = num;
					}
					goto IL_001a;
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
			public ukQbTZriQgkmSpjbotJIZKCXGQP(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class tUOAYCAPIVNJvkbceFGmVGSweGyg : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ElementAssignmentConflictCheck mtCaFmEWqIwhWsqkQteeLYfucQfp;

			public ElementAssignmentConflictCheck zmNiuGMQtlBlHidAStqiwbddGtbg;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public ElementAssignment lSBenRqudljkOlMqDJmFKyRXuVt;

			public int WyQnXkMaJasMVYAUzsjYaMHXxBU;

			public ActionElementMap UCUJmbTvJhfxfqQGzAZoYBADJRP;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0052;
				IL_0052:
				tUOAYCAPIVNJvkbceFGmVGSweGyg tUOAYCAPIVNJvkbceFGmVGSweGyg2 = new tUOAYCAPIVNJvkbceFGmVGSweGyg(0);
				tUOAYCAPIVNJvkbceFGmVGSweGyg2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = -1703881840;
				goto IL_0021;
				IL_001c:
				num = -1703881839;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -1703881838)
					{
					case 0:
						break;
					case 3:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						tUOAYCAPIVNJvkbceFGmVGSweGyg2 = this;
						num = -1703881840;
						continue;
					case 1:
						goto IL_0052;
					case 2:
						tUOAYCAPIVNJvkbceFGmVGSweGyg2.mtCaFmEWqIwhWsqkQteeLYfucQfp = zmNiuGMQtlBlHidAStqiwbddGtbg;
						num = -1703881834;
						continue;
					default:
						tUOAYCAPIVNJvkbceFGmVGSweGyg2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						return tUOAYCAPIVNJvkbceFGmVGSweGyg2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				int num2;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -226625117;
						goto IL_001f;
					}
					goto IL_00c0;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -226625113;
						goto IL_001f;
					}
					IL_01ea:
					if (iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc != null)
					{
						num = -226625105;
						num2 = num;
					}
					else
					{
						num = -226625117;
						num2 = num;
					}
					goto IL_001f;
					IL_00c0:
					if (kUWZXXVHFictxLEMjETmHtCiqtXG)
					{
						int num3;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx._enabled)
						{
							num = -226625108;
							num3 = num;
						}
						else
						{
							num = -226625117;
							num3 = num;
						}
						goto IL_001f;
					}
					goto IL_01ea;
					IL_001f:
					while (true)
					{
						switch (num ^ -226625105)
						{
						case 4:
							num = -226625106;
							continue;
						case 1:
							break;
						case 5:
							goto IL_0094;
						case 11:
							goto IL_00c0;
						case 6:
							if (UCUJmbTvJhfxfqQGzAZoYBADJRP.CheckForAssignmentConflict(lSBenRqudljkOlMqDJmFKyRXuVt))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(iKQXbXnVtIaMZEJNeigQJWAHqUx._categoryId).userAssignable, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerType, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerId, iKQXbXnVtIaMZEJNeigQJWAHqUx._id, UCUJmbTvJhfxfqQGzAZoYBADJRP.rOuBUzbbciWwktcpmiPWpQIKoaAa, UCUJmbTvJhfxfqQGzAZoYBADJRP._actionId, UCUJmbTvJhfxfqQGzAZoYBADJRP._elementType, UCUJmbTvJhfxfqQGzAZoYBADJRP._elementIdentifierId, UCUJmbTvJhfxfqQGzAZoYBADJRP.keyCode, UCUJmbTvJhfxfqQGzAZoYBADJRP.modifierKeyFlags);
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 8;
						case 2:
							goto IL_01a6;
						case 8:
							WyQnXkMaJasMVYAUzsjYaMHXxBU++;
							num = -226625110;
							continue;
						case 3:
							goto IL_01ea;
						case 10:
							WyQnXkMaJasMVYAUzsjYaMHXxBU = 0;
							num = -226625110;
							continue;
						case 0:
							lSBenRqudljkOlMqDJmFKyRXuVt = mtCaFmEWqIwhWsqkQteeLYfucQfp.ToElementAssignment();
							num = -226625115;
							continue;
						case 7:
							UCUJmbTvJhfxfqQGzAZoYBADJRP = iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc[WyQnXkMaJasMVYAUzsjYaMHXxBU];
							num = -226625114;
							continue;
						case 9:
							goto IL_025d;
						default:
							goto end_IL_0008;
						}
						break;
						IL_025d:
						if (kUWZXXVHFictxLEMjETmHtCiqtXG)
						{
							int num4;
							if (UCUJmbTvJhfxfqQGzAZoYBADJRP.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = -226625107;
								num4 = num;
							}
							else
							{
								num = -226625113;
								num4 = num;
							}
							continue;
						}
						goto IL_01a6;
						IL_0094:
						int num5;
						if (WyQnXkMaJasMVYAUzsjYaMHXxBU >= iKQXbXnVtIaMZEJNeigQJWAHqUx.yaioNhAHmyifoDnqDTMwJZLzxdsc.Count)
						{
							num = -226625117;
							num5 = num;
						}
						else
						{
							num = -226625112;
							num5 = num;
						}
						continue;
						IL_01a6:
						int num6;
						if (UCUJmbTvJhfxfqQGzAZoYBADJRP.rOuBUzbbciWwktcpmiPWpQIKoaAa == mtCaFmEWqIwhWsqkQteeLYfucQfp.elementMapId)
						{
							num = -226625113;
							num6 = num;
						}
						else
						{
							num = -226625111;
							num6 = num;
						}
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
			public tUOAYCAPIVNJvkbceFGmVGSweGyg(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		private readonly AList<ActionElementMap> yaioNhAHmyifoDnqDTMwJZLzxdsc;

		private readonly ReadOnlyCollection<ActionElementMap> sVZWYsJWzeSJLdFSRckFcuHWGKT;

		private readonly AList<ActionElementMap> DamcbcIjPKsafMMaNHJXgqqYQUk;

		private readonly ReadOnlyCollection<ActionElementMap> PDmRtYnsUPmgAQFXiwnKKgQeTnS;

		protected int _playerId;

		protected int _controllerId;

		protected ControllerType _controllerType;

		private static int yyRdqIEdvRRWoOnhAbeUyuGapvs;

		private static int nextUid
		{
			get
			{
				int result = yyRdqIEdvRRWoOnhAbeUyuGapvs;
				if (yyRdqIEdvRRWoOnhAbeUyuGapvs == int.MaxValue)
				{
					yyRdqIEdvRRWoOnhAbeUyuGapvs = 0;
				}
				else
				{
					while (true)
					{
						yyRdqIEdvRRWoOnhAbeUyuGapvs++;
						int num = -260178374;
						while (true)
						{
							switch (num ^ -260178376)
							{
							case 0:
								num = -260178375;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0038;
							}
							break;
						}
						continue;
						end_IL_0038:
						break;
					}
				}
				return result;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = value;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = value;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = value;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -510808781;
						while (true)
						{
							switch (num ^ -510808782)
							{
							case 0:
								break;
							case 1:
								goto IL_002b;
							default:
								return -1;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -510808784;
						}
					}
				}
				return _playerId;
			}
			internal set
			{
				_playerId = value;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = value;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -1607195314;
						while (true)
						{
							switch (num ^ -1607195313)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1607195313;
						}
					}
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
			internal set
			{
				_controllerType = value;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return DamcbcIjPKsafMMaNHJXgqqYQUk.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return yaioNhAHmyifoDnqDTMwJZLzxdsc.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return PDmRtYnsUPmgAQFXiwnKKgQeTnS;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return sVZWYsJWzeSJLdFSRckFcuHWGKT;
			}
		}

		internal AList<ActionElementMap> ButtonMaps_orig
		{
			get
			{
				return yaioNhAHmyifoDnqDTMwJZLzxdsc;
			}
		}

		public ControllerMap()
		{
			while (true)
			{
				int num = 394005958;
				while (true)
				{
					switch (num ^ 0x177C0DC4)
					{
					case 3:
						break;
					case 2:
						_id = nextUid;
						num = 394005957;
						continue;
					case 1:
						_sourceMapId = -1;
						yaioNhAHmyifoDnqDTMwJZLzxdsc = new AList<ActionElementMap>();
						sVZWYsJWzeSJLdFSRckFcuHWGKT = new ReadOnlyCollection<ActionElementMap>(yaioNhAHmyifoDnqDTMwJZLzxdsc);
						DamcbcIjPKsafMMaNHJXgqqYQUk = new AList<ActionElementMap>();
						num = 394005956;
						continue;
					default:
						PDmRtYnsUPmgAQFXiwnKKgQeTnS = new ReadOnlyCollection<ActionElementMap>(DamcbcIjPKsafMMaNHJXgqqYQUk);
						znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
						return;
					}
					break;
				}
			}
		}

		public ControllerMap(ControllerMap source)
			: this()
		{
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				int num = 722695191;
				while (true)
				{
					switch (num ^ 0x2B137413)
					{
					case 6:
						break;
					default:
						return;
					case 4:
						_id = nextUid;
						_sourceMapId = source._sourceMapId;
						_categoryId = source._categoryId;
						_layoutId = source._layoutId;
						num = 722695186;
						continue;
					case 5:
					{
						int num3;
						if (num2 < count)
						{
							num = 722695188;
							num3 = num;
						}
						else
						{
							num = 722695195;
							num3 = num;
						}
						continue;
					}
					case 7:
						zMHDgeCdkJmjfDLdekpvLhdOLmH(new ActionElementMap(source.yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]));
						num2++;
						num = 722695190;
						continue;
					case 1:
						_name = source._name;
						_hardwareGuid = source._hardwareGuid;
						_enabled = source._enabled;
						_playerId = source._playerId;
						_controllerId = source._controllerId;
						num = 722695184;
						continue;
					case 9:
						if (source.yaioNhAHmyifoDnqDTMwJZLzxdsc != null)
						{
							count = source.yaioNhAHmyifoDnqDTMwJZLzxdsc.Count;
							num = 722695185;
							continue;
						}
						return;
					case 3:
						_controllerType = source._controllerType;
						num = 722695194;
						continue;
					case 0:
						num = 722695190;
						continue;
					case 2:
						num2 = 0;
						num = 722695187;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			InputAction inputAction = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.RrHFFOsApvcmnDwtShMjBoRBEqDs(actionName, true);
			while (true)
			{
				int num = 380527231;
				while (true)
				{
					switch (num ^ 0x16AE627E)
					{
					case 0:
						break;
					case 1:
						if (inputAction == null)
						{
							goto IL_0049;
						}
						return ContainsAction(inputAction.id);
					default:
						return false;
					}
					break;
					IL_0049:
					num = 380527228;
				}
			}
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			int num2 = default(int);
			if (actionId < 0)
			{
				num = 354644750;
			}
			else
			{
				num2 = buttonMapCount;
				num = 354644745;
			}
			goto IL_0012;
			IL_000d:
			num = 354644747;
			goto IL_0012;
			IL_0012:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x15237308)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				case 5:
				{
					int num4;
					if (num3 >= num2)
					{
						num = 354644751;
						num4 = num;
					}
					else
					{
						num = 354644748;
						num4 = num;
					}
					continue;
				}
				case 2:
					num = 354644749;
					continue;
				case 4:
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3]._actionId == actionId)
					{
						return true;
					}
					num3++;
					num = 354644749;
					continue;
				case 6:
					return false;
				case 1:
					num3 = 0;
					num = 354644746;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			AList<ActionElementMap> damcbcIjPKsafMMaNHJXgqqYQUk = DamcbcIjPKsafMMaNHJXgqqYQUk;
			int num = 0;
			int num2 = 818147541;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x30C3F0D7)
				{
				case 0:
					break;
				case 1:
					return false;
				case 3:
					if (DamcbcIjPKsafMMaNHJXgqqYQUk[num].elementIdentifierId != elementIdentifierId)
					{
						goto IL_0063;
					}
					return true;
				default:
					if (num >= damcbcIjPKsafMMaNHJXgqqYQUk.Count)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_0063:
				num++;
				num2 = 818147541;
			}
			goto IL_0019;
			IL_0019:
			num2 = 818147542;
			goto IL_001e;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			AList<ActionElementMap> damcbcIjPKsafMMaNHJXgqqYQUk = DamcbcIjPKsafMMaNHJXgqqYQUk;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= damcbcIjPKsafMMaNHJXgqqYQUk.Count)
				{
					num2 = -966821492;
					num3 = num2;
				}
				else
				{
					num2 = -966821490;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -966821491)
					{
					case 2:
						num2 = -966821490;
						continue;
					case 3:
						if (DamcbcIjPKsafMMaNHJXgqqYQUk[num].keyCode == keyCode && DamcbcIjPKsafMMaNHJXgqqYQUk[num].modifierKeyFlags == modifierKeys)
						{
							return true;
						}
						num++;
						num2 = -966821491;
						continue;
					case 0:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			AList<ActionElementMap> damcbcIjPKsafMMaNHJXgqqYQUk = default(AList<ActionElementMap>);
			int num = default(int);
			int num2;
			if (elementMap != null)
			{
				damcbcIjPKsafMMaNHJXgqqYQUk = DamcbcIjPKsafMMaNHJXgqqYQUk;
				num = 0;
				num2 = 266069706;
			}
			else
			{
				num2 = 266069707;
			}
			goto IL_0015;
			IL_0010:
			num2 = 266069710;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0xFDBE6CF)
				{
				case 0:
					break;
				case 2:
					if (DamcbcIjPKsafMMaNHJXgqqYQUk[num].rOuBUzbbciWwktcpmiPWpQIKoaAa == elementMap.id)
					{
						return true;
					}
					num++;
					num2 = 266069706;
					continue;
				case 4:
					return false;
				case 5:
				{
					int num3;
					if (num >= damcbcIjPKsafMMaNHJXgqqYQUk.Count)
					{
						num2 = 266069708;
						num3 = num2;
					}
					else
					{
						num2 = 266069709;
						num3 = num2;
					}
					continue;
				}
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_0010;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			AList<ActionElementMap> damcbcIjPKsafMMaNHJXgqqYQUk = DamcbcIjPKsafMMaNHJXgqqYQUk;
			int num = 0;
			int num2 = -1028155759;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ -1028155760)
				{
				case 5:
					break;
				case 3:
				{
					int num3;
					if (num < damcbcIjPKsafMMaNHJXgqqYQUk.Count)
					{
						num2 = -1028155760;
						num3 = num2;
					}
					else
					{
						num2 = -1028155756;
						num3 = num2;
					}
					continue;
				}
				case 1:
					num2 = -1028155757;
					continue;
				case 0:
					if (DamcbcIjPKsafMMaNHJXgqqYQUk[num].rOuBUzbbciWwktcpmiPWpQIKoaAa == elementMapId)
					{
						return true;
					}
					num++;
					num2 = -1028155757;
					continue;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = -1028155758;
			goto IL_0012;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = 1880436613;
					while (true)
					{
						switch (num ^ 0x70152F84)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = 1880436612;
					}
				}
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				result = null;
				goto IL_001c;
			}
			ActionElementMap elementMap = GetElementMap(elementAssignment.elementMapId);
			int num;
			if (elementMap == null)
			{
				num = -537278202;
				goto IL_0021;
			}
			return ReplaceElementMap(elementAssignment, out result);
			IL_001c:
			num = -537278203;
			goto IL_0021;
			IL_0021:
			switch (num ^ -537278204)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return CreateElementMap(elementAssignment, out result);
			}
			goto IL_001c;
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			int num;
			if (_controllerType != ControllerType.Joystick && _controllerType != ControllerType.Mouse)
			{
				if (_controllerType == ControllerType.Custom)
				{
					num = -93743573;
					goto IL_001e;
				}
				throw new NotImplementedException();
			}
			goto IL_008b;
			IL_008b:
			return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, jHLGlrXjGMMIuxAEONcGlnwHltw.CSNCkOQjILujRXYRCEZThnKdpKC(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			IL_001e:
			switch (num ^ -93743573)
			{
			case 2:
				break;
			case 1:
				result = null;
				return false;
			default:
				goto IL_008b;
			}
			goto IL_0019;
			IL_0019:
			num = -93743574;
			goto IL_001e;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.BakeActionElementMap(this, actionElementMap);
			zMHDgeCdkJmjfDLdekpvLhdOLmH(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			DPdDgksNILmWTzDYcQDlYsVlndC dPdDgksNILmWTzDYcQDlYsVlndC = DPdDgksNILmWTzDYcQDlYsVlndC.dEcGUDazSBDgjhOEGPZoaCPIgrii(modifierKeyFlags);
			int num = 1128223599;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x433F536C)
				{
				case 0:
					break;
				case 2:
					goto IL_002f;
				case 1:
					result = null;
					return false;
				default:
					return CreateElementMap(actionId, axisContribution, keyCode, dPdDgksNILmWTzDYcQDlYsVlndC.HkyvOsaidNYmdQZrPxleuzBGLMn, dPdDgksNILmWTzDYcQDlYsVlndC.ieSOzjvYulYvizEtgeNbBYPVuII, dPdDgksNILmWTzDYcQDlYsVlndC.KuyoSjIDOVSRhxVsoVPCAPYbbyt, out result);
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				num = 1128223597;
			}
			goto IL_000d;
			IL_000d:
			num = 1128223598;
			goto IL_0012;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			ActionElementMap actionElementMap = default(ActionElementMap);
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(elementType))
			{
				result = null;
				num = 620853909;
			}
			else
			{
				actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
				BakeElementMap(actionElementMap);
				num = 620853910;
			}
			goto IL_0012;
			IL_000d:
			num = 620853904;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x25017A95)
				{
				case 2:
					break;
				case 5:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					result = null;
					return false;
				case 4:
					result = actionElementMap;
					num = 620853908;
					continue;
				case 3:
					zMHDgeCdkJmjfDLdekpvLhdOLmH(actionElementMap);
					num = 620853905;
					continue;
				case 0:
					return false;
				default:
					return true;
				}
				break;
			}
			goto IL_000d;
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				result = null;
				goto IL_001c;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			int num;
			int num2;
			if (_controllerType != ControllerType.Joystick)
			{
				num = -1623240021;
				num2 = num;
			}
			else
			{
				num = -1623240022;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -1623240023;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ -1623240024)
				{
				case 0:
					break;
				case 1:
					return false;
				case 3:
					if (_controllerType != ControllerType.Mouse)
					{
						if (_controllerType == ControllerType.Custom)
						{
							goto IL_00a0;
						}
						throw new NotImplementedException();
					}
					goto default;
				default:
					return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, jHLGlrXjGMMIuxAEONcGlnwHltw.CSNCkOQjILujRXYRCEZThnKdpKC(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
				}
				break;
				IL_00a0:
				num = -1623240022;
			}
			goto IL_001c;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			int num = IziPXwDvTqTtXGnCEcUeHXXLzMYe(elementMapId);
			int num2;
			int num3;
			if (num >= 0)
			{
				num2 = 367107830;
				num3 = num2;
			}
			else
			{
				num2 = 367107829;
				num3 = num2;
			}
			goto IL_001e;
			IL_0019:
			num2 = 367107828;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x15E19EF3)
				{
				case 2:
					break;
				case 0:
					if (num < 0)
					{
						result = null;
						return false;
					}
					elementMap.nympziBLtYDUiPlWNRoEGqbSPfa();
					num2 = 367107826;
					continue;
				case 5:
					num = IziPXwDvTqTtXGnCEcUeHXXLzMYe(elementMapId);
					num2 = 367107827;
					continue;
				case 4:
					return false;
				case 1:
					elementMap._actionId = actionId;
					num2 = 367107835;
					continue;
				case 6:
					DeleteElementMap(elementMapId);
					elementMap._elementType = ControllerElementType.Button;
					num2 = 367107824;
					continue;
				case 7:
					result = null;
					num2 = 367107831;
					continue;
				case 3:
					zMHDgeCdkJmjfDLdekpvLhdOLmH(elementMap);
					num2 = 367107830;
					continue;
				default:
					elementMap._elementType = ControllerElementType.Button;
					elementMap._axisContribution = axisContribution;
					elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
					elementMap._modifierKey1 = modifierKey1;
					elementMap._modifierKey2 = modifierKey2;
					elementMap._modifierKey3 = modifierKey3;
					ReInput.controllers.Keyboard.BakeActionElementMap(this, elementMap);
					result = elementMap;
					return true;
				}
				break;
			}
			goto IL_0019;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			DPdDgksNILmWTzDYcQDlYsVlndC dPdDgksNILmWTzDYcQDlYsVlndC = DPdDgksNILmWTzDYcQDlYsVlndC.dEcGUDazSBDgjhOEGPZoaCPIgrii(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, dPdDgksNILmWTzDYcQDlYsVlndC.HkyvOsaidNYmdQZrPxleuzBGLMn, dPdDgksNILmWTzDYcQDlYsVlndC.ieSOzjvYulYvizEtgeNbBYPVuII, dPdDgksNILmWTzDYcQDlYsVlndC.KuyoSjIDOVSRhxVsoVPCAPYbbyt, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			ActionElementMap elementMap = default(ActionElementMap);
			int num;
			if (NazMgzUnvggfOsDycmqIQvTPcxX(elementType))
			{
				elementMap = GetElementMap(elementMapId);
				num = -1997843425;
			}
			else
			{
				num = -1997843430;
			}
			goto IL_0021;
			IL_001c:
			num = -1997843427;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ -1997843429)
				{
				case 0:
					break;
				case 4:
					if (elementMap == null)
					{
						result = null;
						num = -1997843426;
						continue;
					}
					if (!NazMgzUnvggfOsDycmqIQvTPcxX(elementMap._elementType))
					{
						DeleteElementMap(elementMapId);
						elementMap._elementType = ControllerElementType.Button;
						zMHDgeCdkJmjfDLdekpvLhdOLmH(elementMap);
						num = -1997843431;
						continue;
					}
					goto case 2;
				case 5:
					return false;
				case 2:
				{
					int num2 = IziPXwDvTqTtXGnCEcUeHXXLzMYe(elementMapId);
					if (num2 < 0)
					{
						result = null;
						return false;
					}
					luomRJHoFJehByGwbbSySSuKiyS(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
					num = -1997843432;
					continue;
				}
				case 1:
					result = null;
					return false;
				case 6:
					result = null;
					return false;
				case 3:
					BakeElementMap(elementMap);
					result = elementMap;
					num = -1997843428;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_001c;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int num = IziPXwDvTqTtXGnCEcUeHXXLzMYe(elementMapId);
			if (num < 0)
			{
				return false;
			}
			IQnrTBWpoLyVgqkOrYmtBIHQBJf(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 878748720;
					num4 = num3;
				}
				else
				{
					num3 = 878748722;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x3460A433)
					{
					case 2:
						num3 = 878748720;
						continue;
					case 3:
						if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num2].rOuBUzbbciWwktcpmiPWpQIKoaAa == elementMapId)
						{
							return yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
						}
						num2++;
						num3 = 878748723;
						continue;
					case 0:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num = elementMapCount;
			int num2 = -1773630843;
			goto IL_0012;
			IL_0012:
			switch (num2 ^ -1773630841)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			default:
			{
				if (num == 0)
				{
					return EmptyObjects<ActionElementMap>.array;
				}
				List<ActionElementMap> list = new List<ActionElementMap>(num);
				using (IEnumerator<ActionElementMap> enumerator = AllMaps.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							ActionElementMap current = enumerator.Current;
							int num3;
							int num4;
							if (!skipDisabledMaps)
							{
								num3 = -1773630845;
								num4 = num3;
							}
							else
							{
								num3 = -1773630843;
								num4 = num3;
							}
							while (true)
							{
								switch (num3 ^ -1773630841)
								{
								case 3:
									num3 = -1773630842;
									continue;
								case 4:
									list.Add(current);
									num3 = -1773630841;
									continue;
								case 2:
									break;
								case 1:
									goto end_IL_006e;
								default:
									goto end_IL_00b6;
								}
								int num5;
								if (!current.PAfqntGWZaNgzmZFIOyQPuJGOCq)
								{
									num3 = -1773630841;
									num5 = num3;
								}
								else
								{
									num3 = -1773630845;
									num5 = num3;
								}
								continue;
								end_IL_006e:
								break;
							}
							continue;
							end_IL_00b6:
							break;
						}
					}
				}
				return list.ToArray();
			}
			}
			goto IL_000d;
			IL_000d:
			num2 = -1773630842;
			goto IL_0012;
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (results == null)
			{
				while (true)
				{
					switch (0x79733267 ^ 0x79733266)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("results");
					}
					break;
				}
			}
			results.Clear();
			return GetElementMaps_Append(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = 586257223;
					while (true)
					{
						switch (num ^ 0x22F19346)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return EmptyObjects<ActionElementMap>.array;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = 586257220;
					}
				}
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			using (IEnumerator<ActionElementMap> enumerator = AllMaps.GetEnumerator())
			{
				while (true)
				{
					IL_0070:
					int num2;
					int num3;
					if (!enumerator.MoveNext())
					{
						num2 = -711404595;
						num3 = num2;
					}
					else
					{
						num2 = -711404600;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -711404596)
						{
						case 0:
							num2 = -711404600;
							continue;
						default:
							goto end_IL_004f;
						case 3:
							break;
						case 2:
							num++;
							num2 = -711404593;
							continue;
						case 4:
						{
							ActionElementMap current = enumerator.Current;
							if (current._actionId != actionId)
							{
								break;
							}
							if (skipDisabledMaps)
							{
								int num4;
								if (current.PAfqntGWZaNgzmZFIOyQPuJGOCq)
								{
									num2 = -711404594;
									num4 = num2;
								}
								else
								{
									num2 = -711404593;
									num4 = num2;
								}
								continue;
							}
							goto case 2;
						}
						case 1:
							goto end_IL_004f;
						}
						goto IL_0070;
						continue;
						end_IL_004f:
						break;
					}
					break;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num5 = 0;
			using (IEnumerator<ActionElementMap> enumerator2 = AllMaps.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					while (true)
					{
						ActionElementMap current2 = enumerator2.Current;
						if (current2._actionId != actionId)
						{
							break;
						}
						int num6;
						if (skipDisabledMaps)
						{
							int num7;
							if (!current2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num6 = -711404596;
								num7 = num6;
							}
							else
							{
								num6 = -711404594;
								num7 = num6;
							}
							goto IL_00f7;
						}
						goto IL_0144;
						IL_0144:
						array[num5] = current2;
						num5++;
						num6 = -711404596;
						goto IL_00f7;
						IL_00f7:
						while (true)
						{
							switch (num6 ^ -711404596)
							{
							case 3:
								num6 = -711404595;
								continue;
							case 1:
								break;
							case 2:
								goto IL_0144;
							default:
								goto end_IL_0114;
							}
							break;
						}
						continue;
						end_IL_0114:
						break;
					}
				}
				return array;
			}
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			int num = -987546791;
			goto IL_0012;
			IL_0012:
			switch (num ^ -987546791)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			default:
				return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
			}
			goto IL_000d;
			IL_000d:
			num = -987546792;
			goto IL_0012;
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			int num = -1180478471;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1180478472)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			default:
				return ElementMapsWithAction(actionId);
			}
			goto IL_000d;
			IL_000d:
			num = -1180478470;
			goto IL_0012;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			int num = -1671136340;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1671136339)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			default:
				return ElementMapsWithAction(actionId, skipDisabledMaps);
			}
			goto IL_000d;
			IL_000d:
			num = -1671136337;
			goto IL_0012;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			hBQAHblxtOixmdPJpamkZvQEafe hBQAHblxtOixmdPJpamkZvQEafe2 = new hBQAHblxtOixmdPJpamkZvQEafe(-2);
			hBQAHblxtOixmdPJpamkZvQEafe2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			hBQAHblxtOixmdPJpamkZvQEafe2.EWQVMNaYUmlNevCoyIethJojVez = actionId;
			hBQAHblxtOixmdPJpamkZvQEafe2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return hBQAHblxtOixmdPJpamkZvQEafe2;
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			int num2 = 917661638;
			goto IL_0021;
			IL_001c:
			num2 = 917661635;
			goto IL_0021;
			IL_0021:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x36B267C4)
				{
				case 0:
					break;
				case 3:
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3].PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num2 = 917661634;
						continue;
					}
					goto IL_00b3;
				case 2:
					num3 = 0;
					num2 = 917661632;
					continue;
				case 4:
					num2 = 917661633;
					continue;
				case 1:
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3]._actionId == actionId)
					{
						int num4;
						if (!skipDisabledMaps)
						{
							num2 = 917661634;
							num4 = num2;
						}
						else
						{
							num2 = 917661639;
							num4 = num2;
						}
						continue;
					}
					goto IL_00b3;
				case 6:
					return yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
				case 7:
					return null;
				default:
					{
						if (num3 >= num)
						{
							return null;
						}
						goto case 1;
					}
					IL_00b3:
					num3++;
					num2 = 917661633;
					continue;
				}
				break;
			}
			goto IL_001c;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			int num = 1418037078;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x54858754)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			default:
			{
				IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(rPsfaUSCQTmtficMhKUbbYyMecr, skipDisabledMaps);
				RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
				return result;
			}
			}
			goto IL_000d;
			IL_000d:
			num = 1418037077;
			goto IL_0012;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			tZylLiLLKKHunCYpEibyMlNAvxD tZylLiLLKKHunCYpEibyMlNAvxD2 = new tZylLiLLKKHunCYpEibyMlNAvxD(-2);
			tZylLiLLKKHunCYpEibyMlNAvxD2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			tZylLiLLKKHunCYpEibyMlNAvxD2.tUZNcgHLkjgLHurvnNVMybtwcTo = elementTarget;
			tZylLiLLKKHunCYpEibyMlNAvxD2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return tZylLiLLKKHunCYpEibyMlNAvxD2;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = -1225410912;
					while (true)
					{
						switch (num ^ -1225410911)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -1225410909;
					}
				}
			}
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(rPsfaUSCQTmtficMhKUbbYyMecr, actionId, skipDisabledMaps);
			RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			lTNDbsiKTSWcZvCaauIosDKaaiXE lTNDbsiKTSWcZvCaauIosDKaaiXE2 = new lTNDbsiKTSWcZvCaauIosDKaaiXE(-2);
			lTNDbsiKTSWcZvCaauIosDKaaiXE2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			lTNDbsiKTSWcZvCaauIosDKaaiXE2.tUZNcgHLkjgLHurvnNVMybtwcTo = elementTarget;
			lTNDbsiKTSWcZvCaauIosDKaaiXE2.EWQVMNaYUmlNevCoyIethJojVez = actionId;
			lTNDbsiKTSWcZvCaauIosDKaaiXE2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return lTNDbsiKTSWcZvCaauIosDKaaiXE2;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			int num = 1948537190;
			goto IL_0012;
			IL_0012:
			ActionElementMap firstElementMapWithElementTarget = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x74245165)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				case 3:
					goto IL_004b;
				default:
					return firstElementMapWithElementTarget;
				}
				break;
				IL_004b:
				firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(rPsfaUSCQTmtficMhKUbbYyMecr, skipDisabledMaps);
				RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
				num = 1948537188;
			}
			goto IL_000d;
			IL_000d:
			num = 1948537191;
			goto IL_0012;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			bool flag;
			return GetFirstElementMapWithElementTarget(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(rPsfaUSCQTmtficMhKUbbYyMecr, actionId, skipDisabledMaps);
			while (true)
			{
				int num = -695464706;
				while (true)
				{
					switch (num ^ -695464708)
					{
					case 0:
						break;
					case 2:
						goto IL_004a;
					default:
						return firstElementMapWithElementTarget;
					}
					break;
					IL_004a:
					RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
					num = -695464707;
				}
			}
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = 940759990;
					while (true)
					{
						switch (num ^ 0x3812DBB7)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return null;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = 940759989;
					}
				}
			}
			bool flag;
			return GetFirstElementMapWithElementTarget(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(rPsfaUSCQTmtficMhKUbbYyMecr, skipDisabledMaps, results);
			RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			bool flag;
			return GetElementMapsWithElementTarget(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			int num = 2055235433;
			goto IL_001e;
			IL_001e:
			int elementMapsWithElementTarget = default(int);
			while (true)
			{
				switch (num ^ 0x7A806768)
				{
				case 0:
					break;
				case 2:
					return 0;
				case 1:
					goto IL_004b;
				default:
					RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
					return elementMapsWithElementTarget;
				}
				break;
				IL_004b:
				elementMapsWithElementTarget = GetElementMapsWithElementTarget(rPsfaUSCQTmtficMhKUbbYyMecr, actionId, skipDisabledMaps, results);
				num = 2055235435;
			}
			goto IL_0019;
			IL_0019:
			num = 2055235434;
			goto IL_001e;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = -1784432813;
					while (true)
					{
						switch (num ^ -1784432814)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return 0;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -1784432814;
					}
				}
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			bool flag;
			return GetElementMapsWithElementTarget(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return GetFirstElementMapMatch(predicate, false);
		}

		internal virtual ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return kSaGiwvkbDJzwwKDuuACMdgTyMJ(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return GetElementMapMatches(predicate, false, results, false);
		}

		internal virtual int GetElementMapMatches(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return IRKIokYtoNIGBLUYALRMTGaVbxTg(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					switch (0x40C6615B ^ 0x40C6615A)
					{
					case 4:
						break;
					case 1:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return;
					case 3:
						goto end_IL_000d;
					case 2:
						goto IL_005c;
					default:
						goto IL_0071;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			goto IL_005c;
			IL_005c:
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_0071;
			IL_0071:
			int count = DamcbcIjPKsafMMaNHJXgqqYQUk.Count;
			try
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < count)
					{
						num2 = 1086742872;
						num3 = num2;
					}
					else
					{
						num2 = 1086742875;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x40C6615A)
						{
						case 0:
							num2 = 1086742872;
							continue;
						default:
							return;
						case 4:
							break;
						case 3:
							num++;
							num2 = 1086742878;
							continue;
						case 2:
						{
							ActionElementMap obj = DamcbcIjPKsafMMaNHJXgqqYQUk[num];
							if (predicate(obj))
							{
								actionToPerform(obj);
								num2 = 1086742873;
								continue;
							}
							goto case 3;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
			}
		}

		public virtual void ClearElementMaps()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			yaioNhAHmyifoDnqDTMwJZLzxdsc.Clear();
			DamcbcIjPKsafMMaNHJXgqqYQUk.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			int num = 0;
			int count = DamcbcIjPKsafMMaNHJXgqqYQUk.Count;
			int num3 = default(int);
			while (true)
			{
				int num2 = 1945256590;
				while (true)
				{
					switch (num2 ^ 0x73F2428C)
					{
					case 0:
						break;
					case 4:
						num3++;
						num2 = 1945256591;
						continue;
					case 1:
					{
						ActionElementMap actionElementMap = DamcbcIjPKsafMMaNHJXgqqYQUk[num3];
						if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq != state)
						{
							actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq = state;
							num2 = 1945256585;
							continue;
						}
						goto case 4;
					}
					case 2:
						num3 = 0;
						num2 = 1945256591;
						continue;
					case 5:
						num++;
						num2 = 1945256584;
						continue;
					default:
						if (num3 >= count)
						{
							return num;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc != null && index >= 0)
			{
				if (index >= yaioNhAHmyifoDnqDTMwJZLzxdsc.Count)
				{
					num = -1837030458;
					goto IL_001e;
				}
				return yaioNhAHmyifoDnqDTMwJZLzxdsc[index];
			}
			goto IL_005a;
			IL_001e:
			switch (num ^ -1837030458)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				goto IL_005a;
			}
			goto IL_0019;
			IL_005a:
			return null;
			IL_0019:
			num = -1837030457;
			goto IL_001e;
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(yaioNhAHmyifoDnqDTMwJZLzxdsc);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int count = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			int num = 0;
			int num2 = 594996459;
			goto IL_001e;
			IL_001e:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ 0x2376ECEF)
				{
				case 5:
					break;
				case 3:
					return EmptyObjects<ActionElementMap>.array;
				case 2:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num];
					if (skipDisabledMaps)
					{
						int num3;
						if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = 594996463;
							num3 = num2;
						}
						else
						{
							num2 = 594996462;
							num3 = num2;
						}
						continue;
					}
					goto case 1;
				case 0:
					num++;
					num2 = 594996459;
					continue;
				case 1:
					list.Add(actionElementMap);
					num2 = 594996463;
					continue;
				default:
					if (num >= count)
					{
						return list.ToArray();
					}
					goto case 2;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = 594996460;
			goto IL_001e;
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return ujcgeCbaSuGtjUccERanUdmgmkce(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.RrHFFOsApvcmnDwtShMjBoRBEqDs(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			InputAction inputAction = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.RrHFFOsApvcmnDwtShMjBoRBEqDs(actionName, true);
			int num;
			if (inputAction == null)
			{
				num = -821845438;
				goto IL_001e;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
			IL_0019:
			num = -821845437;
			goto IL_001e;
			IL_001e:
			switch (num ^ -821845438)
			{
			case 2:
				break;
			case 1:
				return EmptyObjects<ActionElementMap>.array;
			default:
				return EmptyObjects<ActionElementMap>.array;
			}
			goto IL_0019;
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			int num3 = 0;
			ActionElementMap[] array = default(ActionElementMap[]);
			int num4 = default(int);
			int num5 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				int num6;
				if (num3 >= num)
				{
					if (num2 == 0)
					{
						break;
					}
					array = new ActionElementMap[num2];
					num4 = 0;
					num5 = 0;
					num6 = -60283307;
					goto IL_003a;
				}
				goto IL_00c0;
				IL_00c0:
				actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
				num6 = -60283303;
				goto IL_003a;
				IL_003a:
				while (true)
				{
					switch (num6 ^ -60283311)
					{
					case 9:
						num6 = -60283309;
						continue;
					case 0:
						num2++;
						num6 = -60283306;
						continue;
					case 10:
						break;
					case 8:
						goto IL_00a3;
					case 2:
						goto IL_00c0;
					case 3:
						array[num4] = actionElementMap2;
						num4++;
						num6 = -60283308;
						continue;
					case 5:
						num5++;
						num6 = -60283307;
						continue;
					case 1:
						if (!skipDisabledMaps)
						{
							goto case 0;
						}
						goto IL_0104;
					case 7:
						num3++;
						num6 = -60283301;
						continue;
					case 6:
						actionElementMap2 = yaioNhAHmyifoDnqDTMwJZLzxdsc[num5];
						if (actionElementMap2._actionId != actionId)
						{
							goto case 5;
						}
						if (!skipDisabledMaps)
						{
							goto case 3;
						}
						goto IL_014a;
					default:
						if (num5 >= num)
						{
							return array;
						}
						goto case 6;
					}
					break;
					IL_014a:
					int num7;
					if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num6 = -60283310;
						num7 = num6;
					}
					else
					{
						num6 = -60283308;
						num7 = num6;
					}
					continue;
					IL_0104:
					int num8;
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num6 = -60283311;
						num8 = num6;
					}
					else
					{
						num6 = -60283306;
						num8 = num6;
					}
					continue;
					IL_00a3:
					int num9;
					if (actionElementMap._actionId == actionId)
					{
						num6 = -60283312;
						num9 = num6;
					}
					else
					{
						num6 = -60283306;
						num9 = num6;
					}
				}
			}
			return EmptyObjects<ActionElementMap>.array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			InputAction inputAction = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.RrHFFOsApvcmnDwtShMjBoRBEqDs(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			InputAction inputAction = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.RrHFFOsApvcmnDwtShMjBoRBEqDs(actionName, true);
			while (true)
			{
				int num = 915581008;
				while (true)
				{
					switch (num ^ 0x3692A851)
					{
					case 0:
						break;
					case 1:
						if (inputAction == null)
						{
							num = 915581010;
							continue;
						}
						return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
					case 3:
						ListTools.TryClear(results);
						num = 915581011;
						continue;
					default:
						return 0;
					}
					break;
				}
			}
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return uqAKdTrFhcLZkkoMTEzyvpwnvVp(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return ButtonMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			bFPiLhdwcicGGvTpgIaULZEOYLCf bFPiLhdwcicGGvTpgIaULZEOYLCf2 = new bFPiLhdwcicGGvTpgIaULZEOYLCf(-2);
			bFPiLhdwcicGGvTpgIaULZEOYLCf2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			bFPiLhdwcicGGvTpgIaULZEOYLCf2.EWQVMNaYUmlNevCoyIethJojVez = actionId;
			while (true)
			{
				int num = -2077702307;
				while (true)
				{
					switch (num ^ -2077702308)
					{
					case 0:
						break;
					case 1:
						goto IL_0034;
					default:
						return bFPiLhdwcicGGvTpgIaULZEOYLCf2;
					}
					break;
					IL_0034:
					bFPiLhdwcicGGvTpgIaULZEOYLCf2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
					num = -2077702306;
				}
			}
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = -1274854594;
			goto IL_0012;
			IL_000d:
			num = -1274854598;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1274854594)
				{
				case 3:
					break;
				case 5:
					num = -1274854600;
					continue;
				case 8:
					return actionElementMap;
				case 2:
					actionElementMap = buttonMaps[num2];
					num = -1274854599;
					continue;
				case 7:
					if (actionElementMap._actionId == actionId)
					{
						if (!skipDisabledMaps)
						{
							goto case 8;
						}
						if (actionElementMap.enabled)
						{
							num = -1274854602;
							continue;
						}
					}
					num2++;
					num = -1274854600;
					continue;
				case 1:
					return null;
				case 4:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -1274854593;
					continue;
				case 0:
					num3 = buttonMapCount;
					num2 = 0;
					num = -1274854597;
					continue;
				default:
					if (num2 >= num3)
					{
						return null;
					}
					goto case 2;
				}
				break;
			}
			goto IL_000d;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return kSaGiwvkbDJzwwKDuuACMdgTyMJ(predicate, false);
		}

		internal ActionElementMap kSaGiwvkbDJzwwKDuuACMdgTyMJ(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			try
			{
				int num2 = 0;
				ActionElementMap result = default(ActionElementMap);
				while (num2 < num)
				{
					while (true)
					{
						ActionElementMap actionElementMap = buttonMaps[num2];
						int num3;
						if (P_1)
						{
							int num4;
							if (!actionElementMap.enabled)
							{
								num3 = 865033625;
								num4 = num3;
							}
							else
							{
								num3 = 865033630;
								num4 = num3;
							}
							goto IL_0040;
						}
						goto IL_0092;
						IL_0092:
						if (P_0(actionElementMap))
						{
							result = actionElementMap;
							num3 = 865033631;
							goto IL_0040;
						}
						goto IL_00a5;
						IL_0040:
						while (true)
						{
							switch (num3 ^ 0x338F5D9C)
							{
							case 4:
								num3 = 865033629;
								continue;
							case 1:
								break;
							case 2:
								goto IL_0092;
							case 5:
								goto IL_00a5;
							default:
								goto end_IL_0065;
							case 3:
								return result;
							}
							break;
						}
						continue;
						IL_00a5:
						num2++;
						num3 = 865033628;
						goto IL_0040;
						continue;
						end_IL_0065:
						break;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstButtonMapMatch", exception);
			}
			return null;
		}

		public int GetButtonMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return IRKIokYtoNIGBLUYALRMTGaVbxTg(predicate, false, results, false);
		}

		internal int IRKIokYtoNIGBLUYALRMTGaVbxTg(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			while (P_2 != null)
			{
				while (true)
				{
					IL_004d:
					int num = 0;
					int num2 = -1640189528;
					while (true)
					{
						switch (num2 ^ -1640189526)
						{
						case 5:
							num2 = -1640189525;
							continue;
						case 1:
							break;
						case 0:
							goto IL_004d;
						case 4:
							num = P_2.Count;
							num2 = -1640189527;
							continue;
						case 2:
							if (!P_3)
							{
								P_2.Clear();
								num2 = -1640189527;
								continue;
							}
							goto case 4;
						default:
						{
							IList<ActionElementMap> buttonMaps = ButtonMaps;
							int num3 = buttonMapCount;
							try
							{
								int num4 = 0;
								while (num4 < num3)
								{
									while (true)
									{
										ActionElementMap actionElementMap = buttonMaps[num4];
										int num5;
										if (P_1)
										{
											int num6;
											if (actionElementMap.enabled)
											{
												num5 = -1640189522;
												num6 = num5;
											}
											else
											{
												num5 = -1640189526;
												num6 = num5;
											}
											goto IL_008c;
										}
										goto IL_00de;
										IL_00de:
										if (P_0(actionElementMap))
										{
											P_2.Add(actionElementMap);
											num5 = -1640189526;
											goto IL_008c;
										}
										goto IL_00d3;
										IL_008c:
										while (true)
										{
											switch (num5 ^ -1640189526)
											{
											case 2:
												num5 = -1640189525;
												continue;
											case 1:
												break;
											case 0:
												goto IL_00d3;
											case 4:
												goto IL_00de;
											default:
												goto end_IL_00ad;
											}
											break;
										}
										continue;
										IL_00d3:
										num4++;
										num5 = -1640189527;
										goto IL_008c;
										continue;
										end_IL_00ad:
										break;
									}
								}
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
							}
							return P_2.Count - num;
						}
						}
						break;
					}
					break;
				}
			}
			throw new ArgumentNullException("results");
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (predicate != null)
				{
					num = -1237153100;
					num2 = num;
				}
				else
				{
					num = -1237153098;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1237153098)
					{
					case 3:
						goto IL_001a;
					case 1:
						break;
					case 2:
						if (actionToPerform == null)
						{
							throw new ArgumentNullException("actionToPerform");
						}
						goto default;
					case 0:
						throw new ArgumentNullException("predicate");
					default:
					{
						int count = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count;
						try
						{
							int num3 = 0;
							while (num3 < count)
							{
								while (true)
								{
									ActionElementMap obj = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
									int num4 = -1237153102;
									while (true)
									{
										switch (num4 ^ -1237153098)
										{
										case 0:
											num4 = -1237153097;
											continue;
										case 1:
											break;
										case 4:
											if (predicate(obj))
											{
												actionToPerform(obj);
												num4 = -1237153099;
												continue;
											}
											goto case 3;
										case 3:
											num3++;
											num4 = -1237153100;
											continue;
										default:
											goto end_IL_00b1;
										}
										break;
									}
									continue;
									end_IL_00b1:
									break;
								}
							}
							return;
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
							return;
						}
					}
					}
					break;
					IL_001a:
					num = -1237153097;
				}
			}
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			bool result = default(bool);
			int num3 = default(int);
			if (actionId < 0)
			{
				num = 303705768;
			}
			else
			{
				int num2 = buttonMapCount;
				if (num2 == 0)
				{
					return false;
				}
				result = false;
				num3 = num2 - 1;
				num = 303705771;
			}
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x121A2EA9)
				{
				case 0:
					break;
				case 8:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				case 6:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
					num = 303705774;
					continue;
				case 5:
				{
					int num4;
					if (num3 >= 0)
					{
						num = 303705775;
						num4 = num;
					}
					else
					{
						num = 303705773;
						num4 = num;
					}
					continue;
				}
				case 2:
					num = 303705772;
					continue;
				case 7:
					if (actionElementMap != null && actionElementMap._actionId == actionId)
					{
						IQnrTBWpoLyVgqkOrYmtBIHQBJf(actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa, num3);
						result = true;
						num = 303705770;
						continue;
					}
					goto case 3;
				case 1:
					return false;
				case 3:
					num3--;
					num = 303705772;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 303705761;
			goto IL_0012;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			int num = 0;
			int count = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count;
			int num2 = 0;
			while (true)
			{
				int num3 = -1054900564;
				while (true)
				{
					switch (num3 ^ -1054900567)
					{
					case 0:
						break;
					case 5:
						num3 = -1054900565;
						continue;
					case 4:
						num2++;
						num3 = -1054900565;
						continue;
					case 3:
						num++;
						num3 = -1054900563;
						continue;
					case 1:
					{
						ActionElementMap actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
						if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq != state)
						{
							actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq = state;
							num3 = -1054900566;
							continue;
						}
						goto case 4;
					}
					default:
						if (num2 >= count)
						{
							return num;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
		{
			return DoesElementAssignmentConflict(controllerMap, false);
		}

		public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
		{
			return DoesElementAssignmentConflict(actionElementMap, false);
		}

		public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
		{
			return DoesElementAssignmentConflict(conflictCheck, false);
		}

		public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			if (controllerMap == null)
			{
				return false;
			}
			int num;
			if (skipDisabledMaps)
			{
				if (!_enabled)
				{
					goto IL_0135;
				}
				if (!controllerMap._enabled)
				{
					num = -362829637;
					goto IL_0012;
				}
			}
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int num2 = buttonMapCount;
			int count = buttonMaps.Count;
			int num3 = 0;
			num = -362829648;
			goto IL_0012;
			IL_0135:
			return false;
			IL_000d:
			num = -362829642;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -362829641)
				{
				case 11:
					break;
				case 7:
					num = -362829634;
					continue;
				case 3:
					return false;
				case 13:
					num = -362829635;
					continue;
				case 4:
					num3++;
					num = -362829634;
					continue;
				case 9:
					goto IL_00a0;
				case 10:
					goto IL_00b8;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -362829644;
					continue;
				case 8:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
					if (skipDisabledMaps)
					{
						goto IL_00f8;
					}
					goto case 5;
				case 0:
					goto IL_0115;
				case 12:
					goto IL_0135;
				case 5:
					num4 = 0;
					num = -362829638;
					continue;
				case 2:
					goto IL_0174;
				default:
					return false;
				}
				break;
				IL_0115:
				actionElementMap2 = buttonMaps[num4];
				if (!skipDisabledMaps)
				{
					goto IL_0174;
				}
				if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -362829643;
					continue;
				}
				goto IL_0187;
				IL_0187:
				num4++;
				num = -362829635;
				continue;
				IL_00f8:
				int num5;
				if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -362829645;
					num5 = num;
				}
				else
				{
					num = -362829646;
					num5 = num;
				}
				continue;
				IL_0174:
				if (actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
				goto IL_0187;
				IL_00b8:
				int num6;
				if (num4 < count)
				{
					num = -362829641;
					num6 = num;
				}
				else
				{
					num = -362829645;
					num6 = num;
				}
				continue;
				IL_00a0:
				int num7;
				if (num3 < num2)
				{
					num = -362829633;
					num7 = num;
				}
				else
				{
					num = -362829647;
					num7 = num;
				}
			}
			goto IL_000d;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			int num;
			int num2 = default(int);
			if (actionElementMap != null)
			{
				if (yaioNhAHmyifoDnqDTMwJZLzxdsc != null)
				{
					if (skipDisabledMaps)
					{
						if (!_enabled)
						{
							goto IL_00d9;
						}
						if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num = -839413156;
							goto IL_0015;
						}
					}
					num2 = 0;
					num = -839413167;
				}
				else
				{
					num = -839413153;
				}
				goto IL_0015;
			}
			goto IL_004d;
			IL_004d:
			return false;
			IL_0010:
			num = -839413168;
			goto IL_0015;
			IL_00d9:
			return false;
			IL_0015:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -839413160)
				{
				case 6:
					break;
				case 7:
					goto IL_004d;
				case 5:
					goto IL_006c;
				case 0:
					goto IL_0082;
				case 8:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -839413158;
					continue;
				case 3:
					goto IL_00a7;
				case 1:
					goto IL_00cb;
				case 4:
					goto IL_00d9;
				case 2:
					return false;
				default:
					if (num2 >= yaioNhAHmyifoDnqDTMwJZLzxdsc.Count)
					{
						return false;
					}
					goto IL_00a7;
				}
				break;
				IL_00cb:
				if (actionElementMap2 != actionElementMap)
				{
					num = -839413155;
					continue;
				}
				goto IL_0077;
				IL_0082:
				if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -839413159;
					continue;
				}
				goto IL_0077;
				IL_00a7:
				actionElementMap2 = yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
				int num3;
				if (!skipDisabledMaps)
				{
					num = -839413159;
					num3 = num;
				}
				else
				{
					num = -839413160;
					num3 = num;
				}
				continue;
				IL_0077:
				num2++;
				num = -839413167;
				continue;
				IL_006c:
				if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
				goto IL_0077;
			}
			goto IL_0010;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				return false;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				goto IL_0046;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = -1406465626;
			goto IL_004b;
			IL_0046:
			num = -1406465629;
			goto IL_004b;
			IL_004b:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1406465632)
				{
				case 2:
					break;
				case 3:
					return false;
				case 4:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
					if (!skipDisabledMaps)
					{
						goto case 1;
					}
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = -1406465631;
						continue;
					}
					goto IL_00c7;
				case 6:
					num2 = 0;
					num = -1406465627;
					continue;
				case 1:
					if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						return true;
					}
					goto IL_00c7;
				case 5:
					num = -1406465632;
					continue;
				default:
					{
						if (num2 >= yaioNhAHmyifoDnqDTMwJZLzxdsc.Count)
						{
							return false;
						}
						goto case 4;
					}
					IL_00c7:
					num2++;
					num = -1406465632;
					continue;
				}
				break;
			}
			goto IL_0046;
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return ElementAssignmentConflicts(controllerMap, false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return ElementAssignmentConflicts(actionElementMap, false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return ElementAssignmentConflicts(conflictCheck, false);
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			TYCFQrmiDKXwjwnjCQAfipkSnCi tYCFQrmiDKXwjwnjCQAfipkSnCi = new TYCFQrmiDKXwjwnjCQAfipkSnCi(-2);
			tYCFQrmiDKXwjwnjCQAfipkSnCi.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			tYCFQrmiDKXwjwnjCQAfipkSnCi.AkCCOPqWBDIoelQfBDGjGqsxrCK = controllerMap;
			tYCFQrmiDKXwjwnjCQAfipkSnCi.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return tYCFQrmiDKXwjwnjCQAfipkSnCi;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			ukQbTZriQgkmSpjbotJIZKCXGQP ukQbTZriQgkmSpjbotJIZKCXGQP2 = new ukQbTZriQgkmSpjbotJIZKCXGQP(-2);
			ukQbTZriQgkmSpjbotJIZKCXGQP2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			ukQbTZriQgkmSpjbotJIZKCXGQP2.WfePqZKTzLLSOkMcfaksZhTkOHF = actionElementMap;
			ukQbTZriQgkmSpjbotJIZKCXGQP2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return ukQbTZriQgkmSpjbotJIZKCXGQP2;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			tUOAYCAPIVNJvkbceFGmVGSweGyg tUOAYCAPIVNJvkbceFGmVGSweGyg2 = new tUOAYCAPIVNJvkbceFGmVGSweGyg(-2);
			tUOAYCAPIVNJvkbceFGmVGSweGyg2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			tUOAYCAPIVNJvkbceFGmVGSweGyg2.zmNiuGMQtlBlHidAStqiwbddGtbg = conflictCheck;
			tUOAYCAPIVNJvkbceFGmVGSweGyg2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return tUOAYCAPIVNJvkbceFGmVGSweGyg2;
		}

		public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return RemoveElementAssignmentConflicts(controllerMap, false);
		}

		public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return RemoveElementAssignmentConflicts(actionElementMap, false);
		}

		public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return RemoveElementAssignmentConflicts(conflictCheck, false);
		}

		public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps)
			{
				if (_enabled)
				{
					goto IL_0031;
				}
				goto IL_013e;
			}
			goto IL_0140;
			IL_0036:
			int num;
			ActionElementMap actionElementMap = default(ActionElementMap);
			IList<ActionElementMap> list = default(IList<ActionElementMap>);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x66D893F)
				{
				case 2:
					break;
				case 16:
					if (actionElementMap.CheckForAssignmentConflict(list[num4]))
					{
						IQnrTBWpoLyVgqkOrYmtBIHQBJf(actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa, num2);
						num = 107841838;
						continue;
					}
					goto case 11;
				case 5:
					goto IL_00bb;
				case 9:
					if (!skipDisabledMaps)
					{
						goto case 16;
					}
					goto IL_00d7;
				case 6:
					num = 107841850;
					continue;
				case 8:
					return num3;
				case 15:
					goto IL_013e;
				case 10:
					num = 107841851;
					continue;
				case 14:
					num2 = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count - 1;
					num = 107841842;
					continue;
				case 1:
					num4 = 0;
					num = 107841849;
					continue;
				case 7:
					goto IL_0184;
				case 4:
					num2--;
					num = 107841842;
					continue;
				case 17:
					num3++;
					num = 107841845;
					continue;
				case 11:
					num4++;
					num = 107841850;
					continue;
				case 3:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
					num = 107841843;
					continue;
				case 12:
					if (!skipDisabledMaps)
					{
						goto case 1;
					}
					goto IL_01e0;
				case 0:
					return num3;
				default:
					if (num2 < 0)
					{
						return num3;
					}
					goto case 3;
				}
				break;
				IL_01e0:
				int num5;
				if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = 107841851;
					num5 = num;
				}
				else
				{
					num = 107841854;
					num5 = num;
				}
				continue;
				IL_00bb:
				int num6;
				if (num4 < count)
				{
					num = 107841846;
					num6 = num;
				}
				else
				{
					num = 107841851;
					num6 = num;
				}
				continue;
				IL_00d7:
				int num7;
				if (!list[num4].PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = 107841844;
					num7 = num;
				}
				else
				{
					num = 107841839;
					num7 = num;
				}
				continue;
				IL_0184:
				if (!controllerMap._enabled)
				{
					num = 107841840;
					continue;
				}
				goto IL_0140;
			}
			goto IL_0031;
			IL_013e:
			return 0;
			IL_0140:
			num3 = 0;
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc != null)
			{
				list = controllerMap.yaioNhAHmyifoDnqDTMwJZLzxdsc;
				if (list == null)
				{
					return num3;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null && !mapCategory.userAssignable)
				{
					num = 107841855;
				}
				else
				{
					int buttonMapCount2 = buttonMapCount;
					count = list.Count;
					num = 107841841;
				}
			}
			else
			{
				num = 107841847;
			}
			goto IL_0036;
			IL_0031:
			num = 107841848;
			goto IL_0036;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps)
			{
				if (!_enabled)
				{
					goto IL_0070;
				}
				if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					goto IL_0033;
				}
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int num2;
			int num3 = default(int);
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				num2 = 1845346345;
			}
			else
			{
				num3 = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count - 1;
				num2 = 1845346348;
			}
			goto IL_0038;
			IL_0038:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ 0x6DFDC02E)
				{
				case 3:
					break;
				case 1:
					goto IL_0070;
				case 2:
					num2 = 1845346346;
					continue;
				case 4:
					goto IL_00aa;
				case 6:
					goto IL_00c2;
				case 5:
					IQnrTBWpoLyVgqkOrYmtBIHQBJf(actionElementMap2.rOuBUzbbciWwktcpmiPWpQIKoaAa, num3);
					num++;
					num2 = 1845346343;
					continue;
				case 9:
					num3--;
					num2 = 1845346346;
					continue;
				case 7:
					return num;
				case 0:
					goto IL_0131;
				default:
					return num;
				}
				break;
				IL_00c2:
				actionElementMap2 = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
				if (skipDisabledMaps)
				{
					int num4;
					if (!actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num2 = 1845346343;
						num4 = num2;
					}
					else
					{
						num2 = 1845346350;
						num4 = num2;
					}
					continue;
				}
				goto IL_0131;
				IL_00aa:
				int num5;
				if (num3 >= 0)
				{
					num2 = 1845346344;
					num5 = num2;
				}
				else
				{
					num2 = 1845346342;
					num5 = num2;
				}
				continue;
				IL_0131:
				int num6;
				if (!actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					num2 = 1845346343;
					num6 = num2;
				}
				else
				{
					num2 = 1845346347;
					num6 = num2;
				}
			}
			goto IL_0033;
			IL_0070:
			return 0;
			IL_0033:
			num2 = 1845346351;
			goto IL_0038;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				goto IL_0033;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			int num2 = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count - 1;
			int num3 = 827246237;
			goto IL_0038;
			IL_0033:
			num3 = 827246234;
			goto IL_0038;
			IL_0038:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num3 ^ 0x314EC698)
				{
				case 3:
					break;
				case 0:
					num++;
					num3 = 827246224;
					continue;
				case 4:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
					if (skipDisabledMaps)
					{
						int num4;
						if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num3 = 827246239;
							num4 = num3;
						}
						else
						{
							num3 = 827246224;
							num4 = num3;
						}
						continue;
					}
					goto case 7;
				case 7:
					if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa != conflictCheck.elementMapId)
					{
						int num5;
						if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
						{
							num3 = 827246233;
							num5 = num3;
						}
						else
						{
							num3 = 827246224;
							num5 = num3;
						}
						continue;
					}
					goto case 8;
				case 1:
					IQnrTBWpoLyVgqkOrYmtBIHQBJf(actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa, num2);
					num3 = 827246232;
					continue;
				case 5:
					num3 = 827246238;
					continue;
				case 8:
					num2--;
					num3 = 827246238;
					continue;
				case 2:
					return 0;
				default:
					if (num2 < 0)
					{
						return num;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0033;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return DisableElementAssignmentConflicts(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return DisableElementAssignmentConflicts(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return DisableElementAssignmentConflicts(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return DisableElementAssignmentConflicts(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return DisableElementAssignmentConflicts(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = 1639587782;
					while (true)
					{
						switch (num ^ 0x61BA1FC7)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return 0;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = 1639587783;
					}
				}
			}
			return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int DisableElementAssignmentConflicts(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null)
			{
				goto IL_0003;
			}
			goto IL_0081;
			IL_0003:
			int num = -1199291423;
			goto IL_0008;
			IL_0008:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num5 = default(int);
			int num2 = default(int);
			int num4 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num3 = default(int);
			IList<ActionElementMap> list = default(IList<ActionElementMap>);
			int count = default(int);
			while (true)
			{
				switch (num ^ -1199291412)
				{
				case 9:
					break;
				case 1:
					goto IL_0054;
				case 14:
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num5 = 0;
						num = -1199291411;
						continue;
					}
					goto case 6;
				case 7:
					goto IL_0081;
				case 2:
					goto IL_00ac;
				case 13:
					if (!P_3)
					{
						P_2.Clear();
						num = -1199291413;
						continue;
					}
					goto IL_0081;
				case 12:
					goto IL_00e1;
				case 10:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num2];
					num = -1199291422;
					continue;
				case 11:
					num4++;
					num = -1199291414;
					continue;
				case 8:
					goto IL_0125;
				case 4:
					if (actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						actionElementMap.enabled = false;
						if (P_2 != null)
						{
							P_2.Add(actionElementMap);
							num = -1199291417;
							continue;
						}
						goto case 11;
					}
					goto case 0;
				case 6:
					num2++;
					num = -1199291409;
					continue;
				case 0:
					num5++;
					num = -1199291411;
					continue;
				case 5:
					return num4;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto case 10;
				}
				break;
				IL_00e1:
				int num6;
				if (!actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -1199291412;
					num6 = num;
				}
				else
				{
					num = -1199291416;
					num6 = num;
				}
				continue;
				IL_00ac:
				actionElementMap2 = list[num5];
				int num7;
				if (!P_1)
				{
					num = -1199291416;
					num7 = num;
				}
				else
				{
					num = -1199291424;
					num7 = num;
				}
				continue;
				IL_0054:
				int num8;
				if (num5 >= count)
				{
					num = -1199291414;
					num8 = num;
				}
				else
				{
					num = -1199291410;
					num8 = num;
				}
			}
			goto IL_0003;
			IL_0081:
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1)
			{
				if (!_enabled)
				{
					goto IL_0125;
				}
				if (!P_0._enabled)
				{
					num = -1199291420;
					goto IL_0008;
				}
			}
			num4 = 0;
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				num = -1199291415;
			}
			else
			{
				list = P_0.yaioNhAHmyifoDnqDTMwJZLzxdsc;
				if (list == null)
				{
					return num4;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null && !mapCategory.userAssignable)
				{
					return num4;
				}
				num3 = buttonMapCount;
				count = list.Count;
				num2 = 0;
				num = -1199291409;
			}
			goto IL_0008;
			IL_0125:
			return 0;
		}

		internal virtual int DisableElementAssignmentConflicts(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				goto IL_000d;
			}
			goto IL_0114;
			IL_00df:
			int num = 0;
			if (P_0.elementIdentifierId < 0)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			int num2 = default(int);
			int num3 = default(int);
			int num4;
			if (mapCategory.userAssignable)
			{
				num2 = buttonMapCount;
				num3 = 0;
				num4 = 1391303986;
			}
			else
			{
				num4 = 1391303990;
			}
			goto IL_0012;
			IL_000d:
			num4 = 1391303989;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num4 ^ 0x52ED9D30)
				{
				case 0:
					break;
				case 4:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						goto IL_0068;
					}
					goto case 3;
				case 8:
					actionElementMap.enabled = false;
					if (P_2 != null)
					{
						P_2.Add(actionElementMap);
						num4 = 1391303993;
						continue;
					}
					goto case 9;
				case 9:
					num++;
					num4 = 1391303987;
					continue;
				case 10:
					if (_enabled)
					{
						goto IL_00b6;
					}
					goto case 7;
				case 6:
					return num;
				case 7:
					return 0;
				case 1:
					goto IL_0114;
				case 5:
					P_2.Clear();
					num4 = 1391303985;
					continue;
				case 3:
					num3++;
					num4 = 1391303986;
					continue;
				default:
					if (num3 >= num2)
					{
						return num;
					}
					goto case 4;
				}
				break;
				IL_00b6:
				if (!P_0.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num4 = 1391303991;
					continue;
				}
				goto IL_00df;
				IL_0068:
				int num5;
				if (!P_0.CheckForAssignmentConflict(actionElementMap))
				{
					num4 = 1391303987;
					num5 = num4;
				}
				else
				{
					num4 = 1391303992;
					num5 = num4;
				}
			}
			goto IL_000d;
			IL_0114:
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1)
			{
				num4 = 1391303994;
				goto IL_0012;
			}
			goto IL_00df;
		}

		internal virtual int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
				goto IL_0013;
			}
			goto IL_0164;
			IL_0164:
			int num;
			if (P_1)
			{
				num = 395128152;
				goto IL_0018;
			}
			goto IL_0138;
			IL_00cc:
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int num2 = 0;
			num = 395128151;
			goto IL_0018;
			IL_0013:
			num = 395128144;
			goto IL_0018;
			IL_0018:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ 0x178D2D55)
				{
				case 10:
					break;
				case 1:
					goto IL_0060;
				case 12:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						goto IL_0094;
					}
					goto case 7;
				case 8:
					P_2.Add(actionElementMap);
					num = 395128149;
					continue;
				case 4:
					return 0;
				case 7:
					num3++;
					num = 395128150;
					continue;
				case 13:
					goto IL_0110;
				case 9:
					goto IL_0122;
				case 11:
					return 0;
				case 0:
					num2++;
					num = 395128146;
					continue;
				case 5:
					goto IL_0164;
				case 6:
					goto IL_0171;
				case 2:
					num4 = buttonMapCount;
					num3 = 0;
					num = 395128150;
					continue;
				default:
					if (num3 >= num4)
					{
						return num2;
					}
					goto case 12;
				}
				break;
				IL_0171:
				int num5;
				if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					num = 395128148;
					num5 = num;
				}
				else
				{
					num = 395128146;
					num5 = num;
				}
				continue;
				IL_0094:
				int num6;
				if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa != P_0.elementMapId)
				{
					num = 395128147;
					num6 = num;
				}
				else
				{
					num = 395128146;
					num6 = num;
				}
				continue;
				IL_0110:
				if (!_enabled)
				{
					num = 395128158;
					continue;
				}
				goto IL_0138;
				IL_0122:
				if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					num = 395128145;
					continue;
				}
				goto IL_00cc;
				IL_0060:
				actionElementMap.enabled = false;
				int num7;
				if (P_2 != null)
				{
					num = 395128157;
					num7 = num;
				}
				else
				{
					num = 395128149;
					num7 = num;
				}
			}
			goto IL_0013;
			IL_0138:
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				return 0;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.Button)
			{
				num = 395128156;
				goto IL_0018;
			}
			goto IL_00cc;
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(controllerMap, actionToPerform, false);
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(actionElementMap, actionToPerform, false);
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(conflictCheck, actionToPerform, false);
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int num3 = default(int);
			int num4 = default(int);
			InputMapCategory mapCategory = default(InputMapCategory);
			int count = default(int);
			IList<ActionElementMap> damcbcIjPKsafMMaNHJXgqqYQUk = default(IList<ActionElementMap>);
			int num5 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (controllerMap != null)
			{
				int num;
				if (skipDisabledMaps)
				{
					int num2;
					if (_enabled)
					{
						num = 2073539818;
						num2 = num;
					}
					else
					{
						num = 2073539819;
						num2 = num;
					}
					goto IL_0031;
				}
				goto IL_00ad;
				IL_00ad:
				num3 = 0;
				num = 2073539823;
				goto IL_0031;
				IL_0031:
				while (true)
				{
					int num7;
					switch (num ^ 0x7B97B4EF)
					{
					case 6:
						num = 2073539822;
						continue;
					case 3:
						num4 = 0;
						goto IL_01f8;
					case 2:
						if (mapCategory != null && !mapCategory.userAssignable)
						{
							return num3;
						}
						count = damcbcIjPKsafMMaNHJXgqqYQUk.Count;
						num5 = DamcbcIjPKsafMMaNHJXgqqYQUk.Count - 1;
						goto IL_01dc;
					case 4:
						return 0;
					case 8:
						if (!skipDisabledMaps)
						{
							goto default;
						}
						if (damcbcIjPKsafMMaNHJXgqqYQUk[num4].PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num = 2073539814;
							continue;
						}
						goto IL_0207;
					case 5:
						break;
					case 0:
						goto IL_00ed;
					case 7:
					{
						actionElementMap = DamcbcIjPKsafMMaNHJXgqqYQUk[num5];
						int num6;
						if (!skipDisabledMaps)
						{
							num = 2073539820;
							num6 = num;
						}
						else
						{
							num = 2073539813;
							num6 = num;
						}
						continue;
					}
					case 1:
						goto end_IL_0031;
					case 10:
						if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num = 2073539820;
							continue;
						}
						goto IL_01eb;
					default:
						{
							if (actionElementMap.CheckForAssignmentConflict(damcbcIjPKsafMMaNHJXgqqYQUk[num4]))
							{
								try
								{
									actionToPerform(actionElementMap);
								}
								catch (Exception exception)
								{
									ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
									return num3;
								}
								num3++;
								goto IL_01eb;
							}
							goto IL_0207;
						}
						IL_0207:
						num4++;
						num7 = 2073539819;
						goto IL_01b7;
						IL_01f8:
						if (num4 < count)
						{
							goto case 8;
						}
						num7 = 2073539818;
						goto IL_01b7;
						IL_01b7:
						while (true)
						{
							switch (num7 ^ 0x7B97B4EF)
							{
							case 0:
								num7 = 2073539820;
								continue;
							case 1:
								break;
							case 5:
								goto IL_01eb;
							case 4:
								goto IL_01f8;
							case 3:
								goto IL_0207;
							default:
								return num3;
							}
							break;
						}
						goto IL_01dc;
						IL_01eb:
						num5--;
						num7 = 2073539822;
						goto IL_01b7;
						IL_01dc:
						if (num5 >= 0)
						{
							goto case 7;
						}
						num7 = 2073539821;
						goto IL_01b7;
					}
					if (!controllerMap._enabled)
					{
						num = 2073539819;
						continue;
					}
					goto IL_00ad;
					IL_00ed:
					if (DamcbcIjPKsafMMaNHJXgqqYQUk == null)
					{
						return num3;
					}
					damcbcIjPKsafMMaNHJXgqqYQUk = controllerMap.DamcbcIjPKsafMMaNHJXgqqYQUk;
					if (damcbcIjPKsafMMaNHJXgqqYQUk == null)
					{
						return num3;
					}
					mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
					num = 2073539821;
					continue;
					end_IL_0031:
					break;
				}
			}
			return 0;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				if (actionElementMap != null)
				{
					if (!skipDisabledMaps)
					{
						goto IL_00a5;
					}
					num = -1843075996;
				}
				else
				{
					num = -1843075994;
				}
				goto IL_002e;
				IL_0117:
				if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					try
					{
						actionToPerform(actionElementMap2);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num2;
					}
					num2++;
					goto IL_0140;
				}
				goto IL_0162;
				IL_016d:
				if (num3 >= 0)
				{
					goto IL_00d9;
				}
				int num4 = -1843075996;
				goto IL_0145;
				IL_0145:
				switch (num4 ^ -1843075995)
				{
				case 0:
					break;
				case 3:
					goto IL_0162;
				case 2:
					goto IL_016d;
				default:
					return num2;
				}
				goto IL_0140;
				IL_00a5:
				num2 = 0;
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory == null)
				{
					return num2;
				}
				if (!mapCategory.userAssignable)
				{
					break;
				}
				if (DamcbcIjPKsafMMaNHJXgqqYQUk != null)
				{
					num3 = DamcbcIjPKsafMMaNHJXgqqYQUk.Count - 1;
					goto IL_016d;
				}
				num = -1843075995;
				goto IL_002e;
				IL_00d9:
				actionElementMap2 = DamcbcIjPKsafMMaNHJXgqqYQUk[num3];
				if (!skipDisabledMaps)
				{
					goto IL_0117;
				}
				if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -1843076000;
					goto IL_002e;
				}
				goto IL_0162;
				IL_0140:
				num4 = -1843075994;
				goto IL_0145;
				IL_0162:
				num3--;
				num4 = -1843075993;
				goto IL_0145;
				IL_002e:
				while (true)
				{
					switch (num ^ -1843075995)
					{
					case 4:
						num = -1843075987;
						continue;
					case 0:
						return num2;
					case 3:
						return 0;
					case 6:
						break;
					case 8:
						goto end_IL_002e;
					case 7:
						return 0;
					case 2:
						goto IL_00d9;
					case 1:
						goto IL_00fb;
					default:
						goto IL_0117;
					}
					if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = -1843075998;
						continue;
					}
					goto IL_00a5;
					IL_00fb:
					int num5;
					if (_enabled)
					{
						num = -1843075997;
						num5 = num;
					}
					else
					{
						num = -1843075998;
						num5 = num;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return num2;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (actionToPerform == null)
			{
				num = 1771377899;
				num2 = num;
			}
			else
			{
				num = 1771377898;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1771377903;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num3 = default(int);
			while (true)
			{
				int num5;
				switch (num ^ 0x699514EE)
				{
				case 6:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = 1771377897;
					continue;
				case 5:
					throw new ArgumentNullException("actionToPerform");
				case 7:
					return 0;
				case 0:
					if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa != conflictCheck.elementMapId)
					{
						num = 1771377900;
						continue;
					}
					goto IL_017b;
				case 3:
					actionElementMap = DamcbcIjPKsafMMaNHJXgqqYQUk[num4];
					if (!skipDisabledMaps)
					{
						goto case 0;
					}
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = 1771377902;
						continue;
					}
					goto IL_017b;
				case 4:
				{
					if (skipDisabledMaps && !_enabled)
					{
						return 0;
					}
					if (DamcbcIjPKsafMMaNHJXgqqYQUk == null)
					{
						return 0;
					}
					if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					if (!mapCategory.userAssignable)
					{
						return 0;
					}
					elementAssignment = conflictCheck.ToElementAssignment();
					num3 = 0;
					num4 = DamcbcIjPKsafMMaNHJXgqqYQUk.Count - 1;
					goto IL_0186;
				}
				default:
					{
						if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num3;
							}
							num3++;
							goto IL_015d;
						}
						goto IL_017b;
					}
					IL_017b:
					num4--;
					num5 = 1771377900;
					goto IL_0162;
					IL_015d:
					num5 = 1771377903;
					goto IL_0162;
					IL_0162:
					switch (num5 ^ 0x699514EE)
					{
					case 0:
						break;
					case 1:
						goto IL_017b;
					default:
						goto IL_0186;
					}
					goto IL_015d;
					IL_0186:
					if (num4 < 0)
					{
						return num3;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000d;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			int num = buttonMapCount;
			int num2 = -1113090338;
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			string[] array = default(string[]);
			while (true)
			{
				switch (num2 ^ -1113090337)
				{
				case 3:
					break;
				case 2:
				{
					int num4;
					if (num3 >= num)
					{
						num2 = -1113090341;
						num4 = num2;
					}
					else
					{
						num2 = -1113090343;
						num4 = num2;
					}
					continue;
				}
				case 0:
					num3++;
					num2 = -1113090339;
					continue;
				case 6:
					array[num3] = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3].ccLqwqerDNLPbYOQRmZkNRvlnZD;
					num2 = -1113090337;
					continue;
				case 1:
					if (num == 0)
					{
						return new string[0];
					}
					array = new string[num];
					num3 = 0;
					num2 = -1113090339;
					continue;
				case 5:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<string>.array;
				default:
					return array;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num2 = -1113090342;
			goto IL_0015;
		}

		public string ToXmlString()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return string.Empty;
			}
			try
			{
				return wGWQXZtIQyRkZMrIKWqTSlWZlQY().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return string.Empty;
			}
			try
			{
				return wGWQXZtIQyRkZMrIKWqTSlWZlQY().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			if (controller == null)
			{
				goto IL_0023;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			HardwareJoystickTemplateMap hardwareJoystickTemplateMap = default(HardwareJoystickTemplateMap);
			int num;
			if (controllerTemplate == null)
			{
				hardwareJoystickTemplateMap = ReInput.GQIAEUrSKudAJFshKLEiDynhHAON(templateTypeGuid);
				num = -1116422247;
				goto IL_0028;
			}
			return ControllerTemplateMap.FromControllerMap(controllerTemplate, this);
			IL_0028:
			while (true)
			{
				switch (num ^ -1116422245)
				{
				case 0:
					break;
				case 1:
					goto IL_0045;
				case 3:
					return null;
				default:
				{
					string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
					Logger.LogError("The Controller does not implement " + text + ".", true);
					return null;
				}
				}
				break;
				IL_0045:
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
				num = -1116422248;
			}
			goto IL_0023;
			IL_0023:
			num = -1116422246;
			goto IL_0028;
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			if (templateInterfaceType == null)
			{
				throw new ArgumentNullException("templateInterfaceType");
			}
			goto IL_0081;
			IL_0081:
			IControllerTemplate controllerTemplate = default(IControllerTemplate);
			int num;
			if (controller != null)
			{
				controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
				num = -1127464470;
			}
			else
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
				num = -1127464467;
			}
			goto IL_0012;
			IL_009e:
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", true);
				return null;
			}
			return ControllerTemplateMap.FromControllerMap(controllerTemplate, this);
			IL_000d:
			num = -1127464472;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1127464471)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			case 4:
				return null;
			case 0:
				goto IL_0081;
			default:
				goto IL_009e;
			}
			goto IL_000d;
		}

		private ControllerTemplateMap GaAHbtiqBLdJLjtKRuPwZbTDYbv(IControllerTemplate P_0)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			int num2;
			if (P_0 == null)
			{
				num = 1411596999;
				num2 = num;
			}
			else
			{
				num = 1411596996;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 1411596997;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x542342C4)
			{
			case 2:
				break;
			case 1:
				return null;
			case 3:
				throw new ArgumentNullException("controllerTemplate");
			default:
				return ControllerTemplateMap.FromControllerMap(P_0, this);
			}
			goto IL_0019;
		}

		internal virtual bool AddActionMapping_BeforeBake(ActionElementMap P_0)
		{
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0._elementType))
			{
				goto IL_000e;
			}
			zMHDgeCdkJmjfDLdekpvLhdOLmH(P_0);
			int num = 880024993;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x34741DA0)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return true;
			}
			goto IL_000e;
			IL_000e:
			num = 880024994;
			goto IL_0013;
		}

		internal virtual int GetElementMaps_Append(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			int count2 = default(int);
			while (true)
			{
				int count = P_0.Count;
				int num = -578711215;
				while (true)
				{
					switch (num ^ -578711209)
					{
					case 5:
						num = -578711211;
						continue;
					case 3:
					{
						int num4;
						if (num2 >= count2)
						{
							num = -578711216;
							num4 = num;
						}
						else
						{
							num = -578711210;
							num4 = num;
						}
						continue;
					}
					case 0:
						P_0.Add(yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]);
						num = -578711213;
						continue;
					case 6:
						count2 = yaioNhAHmyifoDnqDTMwJZLzxdsc.Count;
						num2 = 0;
						num = -578711212;
						continue;
					case 1:
						if (P_1)
						{
							int num3;
							if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num2].PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = -578711209;
								num3 = num;
							}
							else
							{
								num = -578711213;
								num3 = num;
							}
							continue;
						}
						goto case 0;
					case 2:
						break;
					case 4:
						num2++;
						num = -578711212;
						continue;
					default:
						return P_0.Count - count;
					}
					break;
				}
			}
		}

		internal virtual ActionElementMap GetFirstElementMapWithMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_2))
			{
				return null;
			}
			int num = FirstIndexOfElementMapping(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return yaioNhAHmyifoDnqDTMwJZLzxdsc[num];
		}

		internal virtual int GetElementMapsWithElementIdentifier(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			goto IL_0058;
			IL_0003:
			int num = 634207465;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x25CD3CEA)
				{
				case 7:
					break;
				case 9:
					goto IL_0040;
				case 2:
					goto IL_0058;
				case 4:
					num2++;
					num = 634207471;
					continue;
				case 1:
					num2 = 0;
					num = 634207471;
					continue;
				case 3:
					throw new ArgumentNullException("results");
				case 6:
					if (!P_2)
					{
						P_1.Clear();
						num = 634207459;
						continue;
					}
					goto case 8;
				case 8:
					num4 = P_1.Count;
					num = 634207459;
					continue;
				case 0:
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]._elementIdentifierId == P_0)
					{
						P_1.Add(yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]);
						num = 634207470;
						continue;
					}
					goto case 4;
				default:
					if (num2 >= num3)
					{
						return P_1.Count - num4;
					}
					goto case 0;
				}
				break;
				IL_0040:
				if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
				{
					return 0;
				}
				num3 = buttonMapCount;
				num = 634207467;
			}
			goto IL_0003;
			IL_0058:
			num4 = 0;
			num = 634207468;
			goto IL_0008;
		}

		internal virtual bool ContainsElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					int num3;
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]._elementIdentifierId == P_0 && yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]._actionId == P_1)
					{
						num3 = 1406531778;
					}
					else
					{
						num2++;
						num3 = 1406531779;
					}
					while (true)
					{
						switch (num3 ^ 0x53D5F8C3)
						{
						case 3:
							num3 = 1406531777;
							continue;
						case 2:
							break;
						case 1:
							return true;
						default:
							goto end_IL_0038;
						}
						break;
					}
					continue;
					end_IL_0038:
					break;
				}
			}
			return false;
		}

		internal virtual int FirstIndexOfElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_2))
			{
				return -1;
			}
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			int num3 = default(int);
			while (true)
			{
				int num2 = 1364466829;
				while (true)
				{
					switch (num2 ^ 0x51541C8E)
					{
					case 4:
						break;
					case 3:
						num3 = 0;
						num2 = 1364466828;
						continue;
					case 2:
						num2 = 1364466830;
						continue;
					case 1:
						if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3]._elementIdentifierId == P_0 && yaioNhAHmyifoDnqDTMwJZLzxdsc[num3]._actionId == P_1)
						{
							return num3;
						}
						num3++;
						num2 = 1364466830;
						continue;
					default:
						if (num3 >= num)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		internal int IziPXwDvTqTtXGnCEcUeHXXLzMYe(int P_0)
		{
			if (yaioNhAHmyifoDnqDTMwJZLzxdsc == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			int num3 = default(int);
			while (true)
			{
				int num2 = -33751271;
				while (true)
				{
					switch (num2 ^ -33751269)
					{
					case 0:
						break;
					case 2:
						num3 = 0;
						num2 = -33751270;
						continue;
					case 1:
						num2 = -33751265;
						continue;
					case 3:
						if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3].rOuBUzbbciWwktcpmiPWpQIKoaAa == P_0)
						{
							return num3;
						}
						num3++;
						num2 = -33751265;
						continue;
					default:
						if (num3 >= num)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		internal int ujcgeCbaSuGtjUccERanUdmgmkce(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num4 = default(int);
			while (true)
			{
				IL_00bf:
				int num;
				if (!P_2)
				{
					P_1.Clear();
					num = 1723538197;
					goto IL_0016;
				}
				goto IL_0061;
				IL_0016:
				while (true)
				{
					switch (num ^ 0x66BB1B11)
					{
					case 9:
						num = 1723538203;
						continue;
					case 2:
						num3++;
						num = 1723538192;
						continue;
					case 4:
						break;
					case 8:
						goto IL_0071;
					case 7:
						P_1.Add(actionElementMap);
						num = 1723538194;
						continue;
					case 6:
						goto IL_009b;
					case 10:
						goto IL_00bf;
					case 3:
						num2++;
						num = 1723538195;
						continue;
					case 5:
						num3 = 0;
						num = 1723538202;
						continue;
					case 1:
						goto IL_00ec;
					case 11:
						num = 1723538192;
						continue;
					default:
						return num2;
					}
					break;
					IL_00ec:
					int num5;
					if (num3 < num4)
					{
						num = 1723538199;
						num5 = num;
					}
					else
					{
						num = 1723538193;
						num5 = num;
					}
					continue;
					IL_009b:
					actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
					int num6;
					if (P_0)
					{
						num = 1723538201;
						num6 = num;
					}
					else
					{
						num = 1723538198;
						num6 = num;
					}
					continue;
					IL_0071:
					int num7;
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = 1723538198;
						num7 = num;
					}
					else
					{
						num = 1723538195;
						num7 = num;
					}
				}
				goto IL_0061;
				IL_0061:
				num4 = buttonMapCount;
				num2 = 0;
				num = 1723538196;
				goto IL_0016;
			}
		}

		internal int uqAKdTrFhcLZkkoMTEzyvpwnvVp(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num5 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num;
				int num2;
				if (!P_3)
				{
					num = 884226154;
					num2 = num;
				}
				else
				{
					num = 884226144;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x34B43868)
					{
					case 4:
						num = 884226145;
						continue;
					case 5:
						num5++;
						num = 884226153;
						continue;
					case 8:
						num4 = buttonMapCount;
						num = 884226159;
						continue;
					case 7:
						if (num4 == 0)
						{
							return 0;
						}
						num5 = 0;
						num3 = 0;
						num = 884226152;
						continue;
					case 0:
						num = 884226155;
						continue;
					case 1:
						num3++;
						num = 884226155;
						continue;
					case 9:
						break;
					case 2:
						P_2.Clear();
						num = 884226144;
						continue;
					case 6:
						actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
						if (actionElementMap._actionId != P_0)
						{
							goto case 1;
						}
						if (P_1)
						{
							int num6;
							if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = 884226146;
								num6 = num;
							}
							else
							{
								num = 884226153;
								num6 = num;
							}
							continue;
						}
						goto case 10;
					case 10:
						P_2.Add(actionElementMap);
						num = 884226157;
						continue;
					default:
						if (num3 >= num4)
						{
							return num5;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		internal virtual int GetElementMapsWithAction(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				IL_0089:
				int num;
				if (!P_3)
				{
					P_2.Clear();
					num = 2042130917;
					goto IL_0016;
				}
				goto IL_0071;
				IL_0016:
				while (true)
				{
					switch (num ^ 0x79B871ED)
					{
					case 6:
						num = 2042130921;
						continue;
					case 5:
						P_2.Add(actionElementMap);
						num2++;
						num = 2042130927;
						continue;
					case 7:
						break;
					case 8:
						goto end_IL_0016;
					case 4:
						goto IL_0089;
					case 1:
						if (actionElementMap._actionId == P_0)
						{
							if (!P_1)
							{
								goto case 5;
							}
							goto IL_00a9;
						}
						goto case 2;
					case 0:
						actionElementMap = yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
						num = 2042130924;
						continue;
					case 2:
						num3++;
						num = 2042130922;
						continue;
					default:
						return num2;
					}
					int num5;
					if (num3 < num4)
					{
						num = 2042130925;
						num5 = num;
					}
					else
					{
						num = 2042130926;
						num5 = num;
					}
					continue;
					IL_00a9:
					int num6;
					if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = 2042130927;
						num6 = num;
					}
					else
					{
						num = 2042130920;
						num6 = num;
					}
					continue;
					end_IL_0016:
					break;
				}
				goto IL_0071;
				IL_0071:
				if (P_0 < 0)
				{
					break;
				}
				num2 = 0;
				num4 = buttonMapCount;
				num3 = 0;
				num = 2042130922;
				goto IL_0016;
			}
			return 0;
		}

		internal virtual ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!BTcXIhKWEqfxufBlemcfpGLBatp(P_0))
			{
				P_4 = true;
				goto IL_0021;
			}
			int num;
			int num2 = default(int);
			int num3 = default(int);
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0.elementType))
			{
				num = 1054216536;
			}
			else
			{
				num2 = buttonMapCount;
				int elementIdentifierId = P_0.elementIdentifierId;
				num3 = 0;
				num = 1054216538;
			}
			goto IL_0026;
			IL_0026:
			while (true)
			{
				switch (num ^ 0x3ED6115C)
				{
				case 3:
					break;
				case 6:
					num = 1054216540;
					continue;
				case 5:
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3].IsTarget(P_0))
					{
						return yaioNhAHmyifoDnqDTMwJZLzxdsc[num3];
					}
					goto IL_007e;
				case 1:
					if (P_1)
					{
						if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3]._actionId == P_2)
						{
							num = 1054216539;
							continue;
						}
						goto IL_007e;
					}
					goto case 7;
				case 7:
					if (!P_3)
					{
						goto case 5;
					}
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num3].PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = 1054216537;
						continue;
					}
					goto IL_007e;
				case 2:
					return null;
				case 4:
					return null;
				default:
					{
						if (num3 >= num2)
						{
							return null;
						}
						goto case 1;
					}
					IL_007e:
					num3++;
					num = 1054216540;
					continue;
				}
				break;
			}
			goto IL_0021;
			IL_0021:
			num = 1054216542;
			goto IL_0026;
		}

		internal virtual int GetElementMapsWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				goto IL_0007;
			}
			goto IL_0128;
			IL_0007:
			int num = -1522496124;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1522496117)
				{
				case 4:
					break;
				case 11:
					goto IL_0060;
				case 7:
					P_4.Add(yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]);
					num4++;
					num = -1522496118;
					continue;
				case 1:
					num2++;
					num = -1522496122;
					continue;
				case 16:
					goto IL_00b4;
				case 6:
					goto IL_00cc;
				case 9:
					num2 = 0;
					num = -1522496120;
					continue;
				case 10:
					goto IL_0100;
				case 8:
					goto IL_0117;
				case 14:
					goto IL_0128;
				case 0:
					goto IL_0134;
				case 3:
					num = -1522496122;
					continue;
				case 2:
					P_4.Clear();
					num = -1522496125;
					continue;
				case 12:
					goto IL_0176;
				case 5:
					goto IL_018e;
				case 15:
					throw new ArgumentNullException("results");
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto IL_0100;
				}
				break;
				IL_018e:
				if (P_2 < 0)
				{
					P_6 = true;
					return num4;
				}
				goto IL_0198;
				IL_00cc:
				int num5;
				if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num2]._actionId == P_2)
				{
					num = -1522496121;
					num5 = num;
				}
				else
				{
					num = -1522496118;
					num5 = num;
				}
				continue;
				IL_0176:
				int num6;
				if (!P_3)
				{
					num = -1522496128;
					num6 = num;
				}
				else
				{
					num = -1522496117;
					num6 = num;
				}
				continue;
				IL_0198:
				if (!BTcXIhKWEqfxufBlemcfpGLBatp(P_0))
				{
					P_6 = true;
					return num4;
				}
				if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0.elementType))
				{
					return num4;
				}
				num3 = buttonMapCount;
				int elementIdentifierId = P_0.elementIdentifierId;
				num = -1522496126;
				continue;
				IL_0100:
				int num7;
				if (!P_1)
				{
					num = -1522496121;
					num7 = num;
				}
				else
				{
					num = -1522496115;
					num7 = num;
				}
				continue;
				IL_0134:
				int num8;
				if (!yaioNhAHmyifoDnqDTMwJZLzxdsc[num2].PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -1522496118;
					num8 = num;
				}
				else
				{
					num = -1522496128;
					num8 = num;
				}
				continue;
				IL_00b4:
				int num9;
				if (!P_5)
				{
					num = -1522496119;
					num9 = num;
				}
				else
				{
					num = -1522496125;
					num9 = num;
				}
				continue;
				IL_0060:
				int num10;
				if (!yaioNhAHmyifoDnqDTMwJZLzxdsc[num2].IsTarget(P_0))
				{
					num = -1522496118;
					num10 = num;
				}
				else
				{
					num = -1522496116;
					num10 = num;
				}
				continue;
				IL_0117:
				P_6 = false;
				if (P_1)
				{
					num = -1522496114;
					continue;
				}
				goto IL_0198;
			}
			goto IL_0007;
			IL_0128:
			num4 = 0;
			num = -1522496101;
			goto IL_000c;
		}

		internal void gjbIScrKvQatHDCNOLNXFZCFGhv(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap == null)
			{
				goto IL_000b;
			}
			goto IL_0052;
			IL_000b:
			int num = -1892461580;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -1892461579)
				{
				case 5:
					break;
				case 3:
					elementMap._elementType = P_1;
					if (P_1 == ControllerElementType.Button)
					{
						elementMap._axisRange = AxisRange.Full;
						num = -1892461583;
						continue;
					}
					goto default;
				case 0:
					goto IL_0052;
				case 1:
					return;
				case 4:
					elementMap._invert = false;
					num = -1892461577;
					continue;
				case 6:
					return;
				default:
					DeleteElementMap(P_0);
					AddElementMap(elementMap);
					return;
				}
				break;
			}
			goto IL_000b;
			IL_0052:
			int num2;
			if (elementMap._elementType != P_1)
			{
				num = -1892461578;
				num2 = num;
			}
			else
			{
				num = -1892461581;
				num2 = num;
			}
			goto IL_0010;
		}

		internal virtual bool AddElementMap(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0._elementType))
			{
				return false;
			}
			yaioNhAHmyifoDnqDTMwJZLzxdsc.Add(P_0);
			ZXTTERTmYRGjWpTQPsXGmIFjEPp(P_0);
			return true;
		}

		internal bool BTcXIhKWEqfxufBlemcfpGLBatp(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			Controller controller = P_0.controller;
			int num;
			int num2;
			if (controller != null)
			{
				num = 263484952;
				num2 = num;
			}
			else
			{
				num = 263484954;
				num2 = num;
			}
			goto IL_0008;
			IL_0003:
			num = 263484953;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0xFB4761A)
				{
				case 4:
					break;
				case 1:
					if (controller.id != _controllerId)
					{
						num = 263484954;
						continue;
					}
					return true;
				case 2:
				{
					int num3;
					if (controller.type != _controllerType)
					{
						num = 263484954;
						num3 = num;
					}
					else
					{
						num = 263484955;
						num3 = num;
					}
					continue;
				}
				case 3:
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_0003;
		}

		internal bool qvdkeukHWHtqCAvrLHBkNbdqXIz(string P_0)
		{
			bool result = default(bool);
			try
			{
				Import(SerializedObject.FromXml(GetType(), P_0));
				while (true)
				{
					IL_0013:
					int num = -171015811;
					while (true)
					{
						switch (num ^ -171015809)
						{
						case 0:
							break;
						default:
							goto end_IL_0018;
						case 2:
							goto IL_0031;
						case 1:
							goto end_IL_0018;
						}
						goto IL_0013;
						IL_0031:
						result = true;
						num = -171015810;
						continue;
						end_IL_0018:
						break;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				while (true)
				{
					IL_0062:
					int num2 = -171015810;
					while (true)
					{
						switch (num2 ^ -171015809)
						{
						case 2:
							break;
						default:
							goto end_IL_0067;
						case 1:
							goto IL_0080;
						case 0:
							goto end_IL_0067;
						}
						goto IL_0062;
						IL_0080:
						result = false;
						num2 = -171015809;
						continue;
						end_IL_0067:
						break;
					}
					break;
				}
			}
			return result;
		}

		internal bool lCFjRsSUajrhWaOtlHCMiHMVFA(string P_0)
		{
			bool result = default(bool);
			try
			{
				Import(SerializedObject.FromJson(GetType(), P_0));
				result = true;
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_0018:
					int num = 441488569;
					while (true)
					{
						switch (num ^ 0x1A5094BB)
						{
						case 0:
							break;
						default:
							goto end_IL_001d;
						case 2:
							goto IL_0036;
						case 1:
							goto end_IL_001d;
						}
						goto IL_0018;
						IL_0036:
						Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
						result = false;
						num = 441488570;
						continue;
						end_IL_001d:
						break;
					}
					break;
				}
			}
			return result;
		}

		internal void ZXTTERTmYRGjWpTQPsXGmIFjEPp(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 786607026;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x2EE2ABB3)
			{
			case 2:
				break;
			case 1:
				return;
			case 3:
				goto IL_002d;
			default:
				DamcbcIjPKsafMMaNHJXgqqYQUk.Sort(BYWhcxyfFJAbsgDmIQLeLndiLqre.Default);
				return;
			}
			goto IL_0003;
			IL_002d:
			DamcbcIjPKsafMMaNHJXgqqYQUk.Add(P_0);
			num = 786607027;
			goto IL_0008;
		}

		internal void BDKELfBOvrxXEfPJDRLKPineuSg(int P_0)
		{
			int num = XZdWmnOQkFFIYvxePtoqlDhYOpX(P_0);
			while (true)
			{
				int num2 = 1160024030;
				while (true)
				{
					switch (num2 ^ 0x45248FDD)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						if (num >= 0)
						{
							goto IL_0036;
						}
						return;
					case 1:
						goto IL_0036;
					case 2:
						return;
					}
					break;
					IL_0036:
					DamcbcIjPKsafMMaNHJXgqqYQUk.RemoveAt(num);
					num2 = 1160024031;
				}
			}
		}

		internal void OQtybPohmoGLTDDnhoDUJwrkECF(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = XZdWmnOQkFFIYvxePtoqlDhYOpX(P_0);
				if (num >= 0)
				{
					DamcbcIjPKsafMMaNHJXgqqYQUk[num] = P_1;
					DamcbcIjPKsafMMaNHJXgqqYQUk.Sort(BYWhcxyfFJAbsgDmIQLeLndiLqre.Default);
				}
			}
		}

		internal static void luomRJHoFJehByGwbbSySSuKiyS(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.nympziBLtYDUiPlWNRoEGqbSPfa();
			while (true)
			{
				int num = -1635817043;
				while (true)
				{
					switch (num ^ -1635817041)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						P_0._actionId = P_1;
						P_0._elementType = P_4;
						P_0._elementIdentifierId = P_3;
						num = -1635817044;
						continue;
					case 3:
						P_0._axisContribution = P_2;
						P_0._axisRange = P_5;
						if (P_4 == ControllerElementType.Axis)
						{
							P_0._invert = P_6;
							num = -1635817042;
							continue;
						}
						return;
					case 1:
						return;
					}
					break;
				}
			}
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId).BakeActionElementMap(this, map);
			}
		}

		internal virtual bool Import(SerializedObject P_0)
		{
			bool flag = false;
			SerializedObject value2 = default(SerializedObject);
			int num3 = default(int);
			SerializedObject value = default(SerializedObject);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num = -112460877;
				while (true)
				{
					switch (num ^ -112460870)
					{
					case 5:
						break;
					case 2:
						if (!value2.TryGetDeserializedValue<SerializedObject>(num3, out value))
						{
							int num5;
							if (value != null)
							{
								num = -112460870;
								num5 = num;
							}
							else
							{
								num = -112460880;
								num5 = num;
							}
							continue;
						}
						goto case 10;
					case 10:
						actionElementMap = new ActionElementMap();
						num = -112460867;
						continue;
					case 1:
						zMHDgeCdkJmjfDLdekpvLhdOLmH(actionElementMap);
						num = -112460870;
						continue;
					case 11:
						P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
						num = -112460874;
						continue;
					case 9:
						_sourceMapId = -1;
						_categoryId = -1;
						_layoutId = -1;
						_name = string.Empty;
						num = -112460866;
						continue;
					case 6:
						value2 = null;
						if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value2) && value2 != null)
						{
							num3 = 0;
							num = -112460878;
							continue;
						}
						goto default;
					case 4:
						_hardwareGuid = Guid.Empty;
						_enabled = true;
						P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
						num = -112460879;
						continue;
					case 12:
						P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
						P_0.TryGetDeserializedValueByRef("name", ref _name);
						P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
						P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
						if (!flag)
						{
							ClearElementMaps();
							flag = true;
							num = -112460868;
							continue;
						}
						goto case 6;
					case 8:
					{
						int num4;
						if (num3 >= value2.count)
						{
							num = -112460871;
							num4 = num;
						}
						else
						{
							num = -112460872;
							num4 = num;
						}
						continue;
					}
					case 0:
						num3++;
						num = -112460878;
						continue;
					case 7:
					{
						actionElementMap.DzhGtommJNlpRFKUAFaKGOCHKTz(value);
						int num2;
						if (ActionElementMap.lrnrCzJkUCjDHPoqSOHzRASvAkAd(actionElementMap))
						{
							num = -112460869;
							num2 = num;
						}
						else
						{
							num = -112460870;
							num2 = num;
						}
						continue;
					}
					default:
						return flag;
					}
					break;
				}
			}
		}

		internal virtual void ExportDataToSerializedObject(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0016;
			}
			goto IL_02f6;
			IL_02f6:
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			int num = -1904558636;
			goto IL_001b;
			IL_0016:
			num = -1904558629;
			goto IL_001b;
			IL_001b:
			Guid guid = default(Guid);
			string value = default(string);
			List<object> list = default(List<object>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1904558637)
				{
				case 11:
					break;
				case 3:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
					});
					P_0.Add("sourceMapId", _sourceMapId);
					P_0.Add("categoryId", _categoryId);
					num = -1904558638;
					continue;
				case 7:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "dataVersion",
						value = 2.ToString()
					});
					if (object.ReferenceEquals(GetType(), typeof(JoystickMap)))
					{
						Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
						guid = ((joystick != null) ? joystick.hardwareTypeGuid : Guid.Empty);
						value = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
						num = -1904558630;
						continue;
					}
					goto case 3;
				case 0:
					list.Add(yaioNhAHmyifoDnqDTMwJZLzxdsc[num2].wGWQXZtIQyRkZMrIKWqTSlWZlQY());
					num = -1904558639;
					continue;
				case 9:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "hardwareGuid",
						value = guid.ToString()
					});
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "hardwareName",
						value = value
					});
					num = -1904558640;
					continue;
				case 12:
				{
					int num4;
					if (yaioNhAHmyifoDnqDTMwJZLzxdsc[num2] == null)
					{
						num = -1904558639;
						num4 = num;
					}
					else
					{
						num = -1904558637;
						num4 = num;
					}
					continue;
				}
				case 4:
					num3 = buttonMapCount;
					num = -1904558634;
					continue;
				case 2:
					num2++;
					num = -1904558631;
					continue;
				case 1:
					P_0.Add("layoutId", _layoutId);
					P_0.Add("name", _name);
					num = -1904558635;
					continue;
				case 8:
					goto IL_02f6;
				case 6:
					P_0.Add("hardwareGuid", _hardwareGuid);
					P_0.Add("enabled", _enabled);
					num = -1904558633;
					continue;
				case 5:
					list = new List<object>();
					P_0.Add("buttonMaps", list);
					num2 = 0;
					num = -1904558631;
					continue;
				default:
					if (num2 >= num3)
					{
						return;
					}
					goto case 12;
				}
				break;
			}
			goto IL_0016;
		}

		private bool NazMgzUnvggfOsDycmqIQvTPcxX(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void IQnrTBWpoLyVgqkOrYmtBIHQBJf(int P_0, int P_1)
		{
			BDKELfBOvrxXEfPJDRLKPineuSg(P_0);
			if (P_1 < 0)
			{
				return;
			}
			if (P_1 >= buttonMapCount)
			{
				while (true)
				{
					switch (0x4469AC7C ^ 0x4469AC7D)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			yaioNhAHmyifoDnqDTMwJZLzxdsc.RemoveAt(P_1);
		}

		private void zMHDgeCdkJmjfDLdekpvLhdOLmH(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				yaioNhAHmyifoDnqDTMwJZLzxdsc.Add(P_0);
				ZXTTERTmYRGjWpTQPsXGmIFjEPp(P_0);
			}
		}

		private void ndnhZEoJCkRSewMjUgsTvSgYjXx(ActionElementMap P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (P_1 >= 0)
			{
				int num;
				int num2;
				if (P_1 >= buttonMapCount)
				{
					num = -1479725015;
					num2 = num;
				}
				else
				{
					num = -1479725014;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1479725013)
					{
					case 0:
						goto IL_0004;
					case 3:
						break;
					case 2:
						return;
					default:
						OQtybPohmoGLTDDnhoDUJwrkECF(yaioNhAHmyifoDnqDTMwJZLzxdsc[P_1].rOuBUzbbciWwktcpmiPWpQIKoaAa, P_0);
						yaioNhAHmyifoDnqDTMwJZLzxdsc[P_1] = P_0;
						return;
					}
					break;
					IL_0004:
					num = -1479725016;
				}
			}
		}

		private int XZdWmnOQkFFIYvxePtoqlDhYOpX(int P_0)
		{
			if (DamcbcIjPKsafMMaNHJXgqqYQUk == null)
			{
				return -1;
			}
			int count = DamcbcIjPKsafMMaNHJXgqqYQUk.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -1069135178;
				while (true)
				{
					switch (num ^ -1069135177)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -1069135177;
						continue;
					case 2:
						if (DamcbcIjPKsafMMaNHJXgqqYQUk[num2].rOuBUzbbciWwktcpmiPWpQIKoaAa == P_0)
						{
							return num2;
						}
						num2++;
						num = -1069135177;
						continue;
					default:
						if (num2 >= count)
						{
							return -1;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private SerializedObject wGWQXZtIQyRkZMrIKWqTSlWZlQY()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ExportDataToSerializedObject(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap MdLShCgeucAqBomYFlMaHVWokJC(ControllerType P_0)
		{
			switch (P_0)
			{
			case ControllerType.Keyboard:
				return new KeyboardMap();
			case ControllerType.Mouse:
				return new MouseMap();
			case ControllerType.Joystick:
				return new JoystickMap();
			case ControllerType.Custom:
				return new CustomControllerMap();
			default:
				throw new NotImplementedException();
			}
		}

		internal static ControllerMap yjuGEpeYQnmaUDahBbyqXLhSilq(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (0x46447104 ^ 0x46447106)
					{
					case 0:
						continue;
					case 2:
						return null;
					}
					break;
				}
			}
			else
			{
				switch (P_0.type)
				{
				case ControllerType.Keyboard:
					break;
				case ControllerType.Mouse:
					return MouseMap.Blank(P_1, P_2);
				case ControllerType.Joystick:
					return JoystickMap.Blank(((Joystick)P_0).hardwareTypeGuid, P_1, P_2);
				case ControllerType.Custom:
					return CustomControllerMap.Blank(((CustomController)P_0).sourceControllerId, P_1, P_2);
				default:
					throw new NotImplementedException();
				}
			}
			return KeyboardMap.Blank(P_1, P_2);
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = MdLShCgeucAqBomYFlMaHVWokJC(controllerType);
			ControllerMap result = default(ControllerMap);
			try
			{
				controllerMap.qvdkeukHWHtqCAvrLHBkNbdqXIz(xmlString);
				result = controllerMap;
			}
			catch
			{
				while (true)
				{
					IL_001e:
					int num = -837109649;
					while (true)
					{
						switch (num ^ -837109650)
						{
						case 2:
							break;
						default:
							goto end_IL_0023;
						case 1:
							goto IL_003c;
						case 0:
							goto end_IL_0023;
						}
						goto IL_001e;
						IL_003c:
						result = null;
						num = -837109650;
						continue;
						end_IL_0023:
						break;
					}
					break;
				}
			}
			return result;
		}
	}
}
