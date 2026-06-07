using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class wkNQqZYSMrRhdpHoRwWdnqCqeIB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ControllerPollingInfo qaRGhfeIRXdJFhFMNHJMcEqbMvHD;

			public ControllerPollingInfo asnDRTbYsuXIneZCgzJJBLYKXbI;

			public IEnumerator<ControllerPollingInfo> EokOdlcXjiPKvDpdGtTvGmupFRQ;

			public IEnumerator<ControllerPollingInfo> vJFQNywpcaSoJiPOFmsWhSpssfx;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0054;
				IL_0012:
				int num = 35326958;
				goto IL_0017;
				IL_0017:
				wkNQqZYSMrRhdpHoRwWdnqCqeIB wkNQqZYSMrRhdpHoRwWdnqCqeIB2 = default(wkNQqZYSMrRhdpHoRwWdnqCqeIB);
				while (true)
				{
					switch (num ^ 0x21B0BEF)
					{
					case 5:
						break;
					case 1:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = 35326957;
							continue;
						}
						goto IL_0054;
					case 0:
						goto IL_0054;
					case 4:
						wkNQqZYSMrRhdpHoRwWdnqCqeIB2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 35326956;
						continue;
					case 2:
						wkNQqZYSMrRhdpHoRwWdnqCqeIB2 = this;
						num = 35326956;
						continue;
					default:
						return wkNQqZYSMrRhdpHoRwWdnqCqeIB2;
					}
					break;
				}
				goto IL_0012;
				IL_0054:
				wkNQqZYSMrRhdpHoRwWdnqCqeIB2 = new wkNQqZYSMrRhdpHoRwWdnqCqeIB(0);
				num = 35326955;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						IL_0007:
						int num2 = -1996200248;
						while (true)
						{
							switch (num2 ^ -1996200231)
							{
							case 11:
								break;
							default:
								goto end_IL_000c;
							case 9:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num2 = -1996200225;
								continue;
							case 12:
								goto IL_0076;
							case 15:
								num2 = -1996200239;
								continue;
							case 13:
								goto IL_008b;
							case 8:
								if (!EokOdlcXjiPKvDpdGtTvGmupFRQ.MoveNext())
								{
									IysrbvxrCSafpHSqkwpJjuQUWDV();
									num2 = -1996200227;
									continue;
								}
								goto case 3;
							case 17:
								switch (num)
								{
								case 4:
									break;
								case 2:
									goto IL_0076;
								case 1:
								case 3:
									goto IL_008b;
								default:
									goto IL_00d1;
								case 0:
									goto IL_012d;
								}
								goto case 9;
							case 18:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								num2 = -1996200229;
								continue;
							case 1:
							{
								int num3;
								if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
								{
									num2 = -1996200226;
									num3 = num2;
								}
								else
								{
									num2 = -1996200231;
									num3 = num2;
								}
								continue;
							}
							case 7:
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num2 = -1996200236;
								continue;
							case 16:
								goto IL_012d;
							case 4:
								vJFQNywpcaSoJiPOFmsWhSpssfx = iKQXbXnVtIaMZEJNeigQJWAHqUx.PollForAllAxes().GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num2 = -1996200225;
								continue;
							case 5:
								aimBzjfQfPyaeQqysAQJISCBhELB = qaRGhfeIRXdJFhFMNHJMcEqbMvHD;
								num2 = -1996200245;
								continue;
							case 10:
								asnDRTbYsuXIneZCgzJJBLYKXbI = vJFQNywpcaSoJiPOFmsWhSpssfx.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = asnDRTbYsuXIneZCgzJJBLYKXbI;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
								result = true;
								goto end_IL_000c;
							case 2:
								result = true;
								goto end_IL_000c;
							case 3:
								qaRGhfeIRXdJFhFMNHJMcEqbMvHD = EokOdlcXjiPKvDpdGtTvGmupFRQ.Current;
								num2 = -1996200228;
								continue;
							case 6:
								if (!vJFQNywpcaSoJiPOFmsWhSpssfx.MoveNext())
								{
									CKCQKuaVeJfqOeGSHfIOiTsuXEn();
									num2 = -1996200236;
									continue;
								}
								goto case 10;
							case 0:
								EokOdlcXjiPKvDpdGtTvGmupFRQ = iKQXbXnVtIaMZEJNeigQJWAHqUx.fkmgvxWpMZmQzugQJFuoIPVrFZlC().GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -1996200234;
								continue;
							case 14:
								goto end_IL_000c;
								IL_008b:
								result = false;
								num2 = -1996200233;
								continue;
								IL_0076:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -1996200239;
								continue;
								IL_012d:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -1996200232;
								continue;
								IL_00d1:
								num2 = -1996200236;
								continue;
							}
							goto IL_0007;
							continue;
							end_IL_000c:
							break;
						}
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
					}
					finally
					{
						IysrbvxrCSafpHSqkwpJjuQUWDV();
					}
					break;
				}
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						CKCQKuaVeJfqOeGSHfIOiTsuXEn();
					}
				}
			}

			[DebuggerHidden]
			public wkNQqZYSMrRhdpHoRwWdnqCqeIB(int _003C_003E1__state)
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

			private void CKCQKuaVeJfqOeGSHfIOiTsuXEn()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (vJFQNywpcaSoJiPOFmsWhSpssfx != null)
				{
					vJFQNywpcaSoJiPOFmsWhSpssfx.Dispose();
				}
			}
		}

		private sealed class VlWCODcocVijagRFcfmPVNkWcXEP : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ControllerPollingInfo WSNAiJzoZlPHrRSVNvZVwyVBhyx;

			public ControllerPollingInfo fxJFeenOYxDOAeSYBOHieVfSBeyE;

			public IEnumerator<ControllerPollingInfo> tzuIgZAjVGsYgMVWIjnvtHeeEYT;

			public IEnumerator<ControllerPollingInfo> qClriEVdICdBUhLqhuncLuAmdeAC;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				VlWCODcocVijagRFcfmPVNkWcXEP vlWCODcocVijagRFcfmPVNkWcXEP;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					vlWCODcocVijagRFcfmPVNkWcXEP = this;
				}
				else
				{
					while (true)
					{
						vlWCODcocVijagRFcfmPVNkWcXEP = new VlWCODcocVijagRFcfmPVNkWcXEP(0);
						int num = 1870884956;
						while (true)
						{
							switch (num ^ 0x6F83705C)
							{
							case 3:
								num = 1870884957;
								continue;
							case 1:
								break;
							case 0:
								vlWCODcocVijagRFcfmPVNkWcXEP.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = 1870884958;
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
				return vlWCODcocVijagRFcfmPVNkWcXEP;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = 1491513720;
						while (true)
						{
							switch (num2 ^ 0x58E6B179)
							{
							case 9:
								break;
							case 10:
								qClriEVdICdBUhLqhuncLuAmdeAC = iKQXbXnVtIaMZEJNeigQJWAHqUx.PollForAllAxes().GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num2 = 1491513725;
								continue;
							case 12:
							{
								int num3;
								if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
								{
									num2 = 1491513719;
									num3 = num2;
								}
								else
								{
									num2 = 1491513723;
									num3 = num2;
								}
								continue;
							}
							case 2:
								tzuIgZAjVGsYgMVWIjnvtHeeEYT = iKQXbXnVtIaMZEJNeigQJWAHqUx.kWWSEXIbsAXQwoIrDotZJbIXYCf().GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = 1491513714;
								continue;
							case 1:
								switch (num)
								{
								case 4:
									goto IL_00f1;
								case 0:
									goto IL_01d5;
								case 2:
									goto IL_01e6;
								case 1:
								case 3:
									goto IL_01f7;
								}
								num2 = 1491513721;
								continue;
							case 8:
								goto IL_00f1;
							case 14:
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num2 = 1491513721;
								continue;
							case 3:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
								return true;
							case 11:
								num2 = 1491513724;
								continue;
							case 6:
								fxJFeenOYxDOAeSYBOHieVfSBeyE = qClriEVdICdBUhLqhuncLuAmdeAC.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = fxJFeenOYxDOAeSYBOHieVfSBeyE;
								num2 = 1491513722;
								continue;
							case 13:
								WSNAiJzoZlPHrRSVNvZVwyVBhyx = tzuIgZAjVGsYgMVWIjnvtHeeEYT.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = WSNAiJzoZlPHrRSVNvZVwyVBhyx;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								return true;
							case 5:
								if (!tzuIgZAjVGsYgMVWIjnvtHeeEYT.MoveNext())
								{
									hsXpLnSqAjwUyjJdahIphiJxlDdM();
									num2 = 1491513715;
									continue;
								}
								goto case 13;
							case 4:
								if (!qClriEVdICdBUhLqhuncLuAmdeAC.MoveNext())
								{
									DULNNgxbNndCpCzLipVfjovJySP();
									num2 = 1491513721;
									continue;
								}
								goto case 6;
							case 7:
								goto IL_01d5;
							case 15:
								goto IL_01e6;
							default:
								goto IL_01f7;
								IL_01f7:
								return false;
								IL_01e6:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = 1491513724;
								continue;
								IL_01d5:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 1491513717;
								continue;
								IL_00f1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num2 = 1491513725;
								continue;
							}
							break;
						}
					}
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
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 1769316187;
					while (true)
					{
						switch (num2 ^ 0x69759F59)
						{
						case 0:
							break;
						case 2:
							switch (num)
							{
							default:
								goto IL_0035;
							case 1:
							case 2:
								break;
							}
							try
							{
							}
							finally
							{
								hsXpLnSqAjwUyjJdahIphiJxlDdM();
							}
							goto default;
						default:
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 3:
							case 4:
								try
								{
									break;
								}
								finally
								{
									DULNNgxbNndCpCzLipVfjovJySP();
								}
							}
							return;
						}
						break;
						IL_0035:
						num2 = 1769316184;
					}
				}
			}

			[DebuggerHidden]
			public VlWCODcocVijagRFcfmPVNkWcXEP(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void hsXpLnSqAjwUyjJdahIphiJxlDdM()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (tzuIgZAjVGsYgMVWIjnvtHeeEYT == null)
				{
					return;
				}
				while (true)
				{
					int num = 679565212;
					while (true)
					{
						switch (num ^ 0x2881579D)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 2:
							return;
						}
						break;
						IL_002d:
						tzuIgZAjVGsYgMVWIjnvtHeeEYT.Dispose();
						num = 679565215;
					}
				}
			}

			private void DULNNgxbNndCpCzLipVfjovJySP()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (qClriEVdICdBUhLqhuncLuAmdeAC != null)
				{
					qClriEVdICdBUhLqhuncLuAmdeAC.Dispose();
				}
			}
		}

		private sealed class QwaahRWWJcRyNVmRVJsiJKYPwIz : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int IfxEPNsgwKLAgBzYwMXEcTIcoZK;

			public Pole LwLXSSILenFDDwWVXciMiCtIfkiQ;

			public int FNTgegdaJZBoshkblFvzeEhCrddi;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				QwaahRWWJcRyNVmRVJsiJKYPwIz qwaahRWWJcRyNVmRVJsiJKYPwIz = new QwaahRWWJcRyNVmRVJsiJKYPwIz(0);
				qwaahRWWJcRyNVmRVJsiJKYPwIz.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = -1241512176;
				goto IL_0021;
				IL_001c:
				num = -1241512174;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -1241512176)
					{
					case 3:
						break;
					case 2:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						qwaahRWWJcRyNVmRVJsiJKYPwIz = this;
						num = -1241512176;
						continue;
					case 1:
						goto IL_004e;
					default:
						return qwaahRWWJcRyNVmRVJsiJKYPwIz;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 1132125236;
					while (true)
					{
						switch (num2 ^ 0x437ADC33)
						{
						case 3:
							break;
						case 8:
						{
							int num3;
							if (IfxEPNsgwKLAgBzYwMXEcTIcoZK < iKQXbXnVtIaMZEJNeigQJWAHqUx._axisCount)
							{
								num2 = 1132125247;
								num3 = num2;
							}
							else
							{
								num2 = 1132125241;
								num3 = num2;
							}
							continue;
						}
						case 4:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 1:
							iKQXbXnVtIaMZEJNeigQJWAHqUx.UpdatePollingFrameTracking();
							num2 = 1132125237;
							continue;
						case 11:
							IfxEPNsgwKLAgBzYwMXEcTIcoZK = 0;
							num2 = 1132125243;
							continue;
						case 6:
							iKQXbXnVtIaMZEJNeigQJWAHqUx.PwFtNoHlaNYkltznFPguDSluRym();
							num2 = 1132125240;
							continue;
						case 0:
							if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
							{
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num2 = 1132125238;
								continue;
							}
							goto case 1;
						case 2:
							IfxEPNsgwKLAgBzYwMXEcTIcoZK++;
							num2 = 1132125243;
							continue;
						case 5:
							num2 = 1132125241;
							continue;
						case 9:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num2 = 1132125235;
							continue;
						case 7:
							switch (num)
							{
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 1132125233;
								continue;
							case 0:
								break;
							default:
								num2 = 1132125241;
								continue;
							}
							goto case 9;
						case 12:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.IsPolledAxisActive(IfxEPNsgwKLAgBzYwMXEcTIcoZK, out LwLXSSILenFDDwWVXciMiCtIfkiQ, out FNTgegdaJZBoshkblFvzeEhCrddi))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = new ControllerPollingInfo(true, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx.id, iKQXbXnVtIaMZEJNeigQJWAHqUx._name, iKQXbXnVtIaMZEJNeigQJWAHqUx._type, ControllerElementType.Axis, IfxEPNsgwKLAgBzYwMXEcTIcoZK, LwLXSSILenFDDwWVXciMiCtIfkiQ, iKQXbXnVtIaMZEJNeigQJWAHqUx.RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierName(FNTgegdaJZBoshkblFvzeEhCrddi), FNTgegdaJZBoshkblFvzeEhCrddi, KeyCode.None);
								num2 = 1132125239;
								continue;
							}
							goto case 2;
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
			public QwaahRWWJcRyNVmRVJsiJKYPwIz(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected CalibrationMap _calibrationMap;

		private float[] eqPhHTJPTbZzZjqXRoRXqdDrfNYA;

		private uint PHllaUeIdHWbiKlhKBkFgQCtbSWA = uint.MaxValue;

		private Func<int, int> SbsjUtjrUKRfhEeDUdLdKfSGtVhl;

		public int axisCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return RCNejcvnZtMAmgendVbiwgNYmdD.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, type, hardwareTypeGuid, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			_axisCount = axisCount;
			axes = new Axis[axisCount];
			for (int i = 0; i < axisCount; i++)
			{
				axes[i] = new Axis(this, hardwareMap.axisElementIdentifierIds[i], "Axis " + i, hardwareMap.hwAxisRanges[i], hardwareMap.hwAxisInfo[i]);
				uiIyqEcLjeCLLGNLkqHYomAmAGZF(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			_calibrationMap = new CalibrationMap(hardwareMap.hwAxisCalibrationData);
			_axis2DCount = hardwareMap.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int j = 0; j < _axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = hardwareMap.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
					}
					else
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[j] = new Axis2D(this, -1, "Axis 2D " + j, null, null, 0, 0, null);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			vFRIPkHGpMqQFbGcGqqRyxZqUXXX();
			SbsjUtjrUKRfhEeDUdLdKfSGtVhl = hardwareMap.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			if (RCNejcvnZtMAmgendVbiwgNYmdD == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			while (true)
			{
				int num = -628400890;
				while (true)
				{
					switch (num ^ -628400889)
					{
					case 0:
						break;
					case 1:
					{
						if (elementById != null)
						{
							return elementById;
						}
						int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
						if (axisIndex < 0)
						{
							goto IL_0061;
						}
						return axes[axisIndex];
					}
					default:
						return null;
					}
					break;
					IL_0061:
					num = -628400891;
				}
			}
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return -1;
			}
			return RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 1874303316;
				num2 = num;
			}
			else
			{
				num = 1874303317;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1874303318;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x6FB79954)
				{
				case 3:
					break;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0f;
				case 1:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].value;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 1874303316;
			}
			goto IL_000d;
		}

		public float GetAxisPrev(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 445505061;
				num2 = num;
			}
			else
			{
				num = 445505062;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 445505060;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x1A8DDE25)
				{
				case 2:
					break;
				case 1:
					return 0f;
				case 3:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].valuePrev;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 445505061;
			}
			goto IL_0019;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = 1947319766;
					goto IL_0012;
				}
				return axes[index].valueRaw;
			}
			goto IL_0051;
			IL_0012:
			switch (num ^ 0x7411BDD4)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_000d;
			IL_000d:
			num = 1947319765;
			goto IL_0012;
			IL_0051:
			return 0f;
		}

		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 994909262;
				num2 = num;
			}
			else
			{
				num = 994909261;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 994909260;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3B4D1C4D)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0f;
				case 3:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].valueRawPrev;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 994909261;
			}
			goto IL_000d;
		}

		public float GetAxisTimeActive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = -352784062;
					goto IL_0012;
				}
				return axes[index].timeActive;
			}
			goto IL_005c;
			IL_0012:
			while (true)
			{
				switch (num ^ -352784064)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -352784064;
					continue;
				case 0:
					return 0f;
				default:
					goto IL_005c;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -352784063;
			goto IL_0012;
			IL_005c:
			return 0f;
		}

		public float GetAxisTimeInactive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].timeInactive;
		}

		public float GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 2053508524;
				num2 = num;
			}
			else
			{
				num = 2053508527;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 2053508525;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x7A660DAC)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0f;
				case 3:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].lastTimeActive;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 2053508524;
			}
			goto IL_000d;
		}

		public float GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = -1610422189;
				num2 = num;
			}
			else
			{
				num = -1610422187;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -1610422188;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1610422185)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -1610422186;
					continue;
				case 1:
					return 0f;
				case 2:
					if (index >= _axisCount)
					{
						num = -1610422189;
						continue;
					}
					return axes[index].lastTimeInactive;
				default:
					return 0f;
				}
				break;
			}
			goto IL_000d;
		}

		public float GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = 490247115;
					goto IL_0012;
				}
				return axes[index].timeActiveRaw;
			}
			goto IL_0051;
			IL_0012:
			switch (num ^ 0x1D3893C9)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_000d;
			IL_000d:
			num = 490247112;
			goto IL_0012;
			IL_0051:
			return 0f;
		}

		public float GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 373846017;
				num2 = num;
			}
			else
			{
				num = 373846019;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 373846018;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x16487003)
				{
				case 3:
					break;
				case 1:
					return 0f;
				case 2:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].timeInactiveRaw;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 373846019;
			}
			goto IL_0019;
		}

		public float GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].lastTimeActiveRaw;
		}

		public float GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].lastTimeInactiveRaw;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			if (axisIndex >= 0)
			{
				while (true)
				{
					int num = -735684634;
					while (true)
					{
						switch (num ^ -735684633)
						{
						case 0:
							break;
						case 1:
							goto IL_004e;
						default:
							goto end_IL_0030;
						}
						break;
						IL_004e:
						if (axisIndex >= _axisCount)
						{
							num = -735684635;
							continue;
						}
						return axes[axisIndex].value;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return 0f;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			int num = 805155813;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2FFDB3E7)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0f;
				case 2:
					if (axisIndex >= 0)
					{
						if (axisIndex >= _axisCount)
						{
							goto IL_0062;
						}
						return axes[axisIndex].valuePrev;
					}
					goto default;
				default:
					return 0f;
				}
				break;
				IL_0062:
				num = 805155812;
			}
			goto IL_000d;
			IL_000d:
			num = 805155814;
			goto IL_0012;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			if (axisIndex >= 0)
			{
				while (true)
				{
					int num = -1274586987;
					while (true)
					{
						switch (num ^ -1274586985)
						{
						case 0:
							break;
						case 2:
							goto IL_004e;
						default:
							goto end_IL_0030;
						}
						break;
						IL_004e:
						if (axisIndex >= _axisCount)
						{
							num = -1274586986;
							continue;
						}
						return axes[axisIndex].valueRaw;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return 0f;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			while (true)
			{
				int num = -476393083;
				while (true)
				{
					switch (num ^ -476393084)
					{
					case 2:
						break;
					case 1:
						if (axisIndex >= 0)
						{
							if (axisIndex >= _axisCount)
							{
								goto IL_0057;
							}
							return axes[axisIndex].valueRawPrev;
						}
						goto default;
					default:
						return 0f;
					}
					break;
					IL_0057:
					num = -476393084;
				}
			}
		}

		public float GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			int num = 1199759990;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x4782E272)
				{
				case 0:
					break;
				case 1:
					return 0f;
				case 4:
				{
					int num2;
					if (axisIndex < 0)
					{
						num = 1199759984;
						num2 = num;
					}
					else
					{
						num = 1199759985;
						num2 = num;
					}
					continue;
				}
				case 3:
					if (axisIndex >= _axisCount)
					{
						num = 1199759984;
						continue;
					}
					return axes[axisIndex].timeActive;
				default:
					return 0f;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = 1199759987;
			goto IL_001e;
		}

		public float GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].timeInactive;
		}

		public float GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 1562440428;
					goto IL_001e;
				}
				return axes[axisIndex].lastTimeActive;
			}
			goto IL_005e;
			IL_001e:
			switch (num ^ 0x5D20F2EC)
			{
			case 2:
				break;
			case 1:
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_0019;
			IL_0019:
			num = 1562440429;
			goto IL_001e;
			IL_005e:
			return 0f;
		}

		public float GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 2118348406;
					goto IL_001e;
				}
				return axes[axisIndex].lastTimeInactive;
			}
			goto IL_005e;
			IL_001e:
			switch (num ^ 0x7E436E74)
			{
			case 0:
				break;
			case 1:
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_0019;
			IL_0019:
			num = 2118348405;
			goto IL_001e;
			IL_005e:
			return 0f;
		}

		public float GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 1601909162;
					goto IL_0012;
				}
				return axes[axisIndex].timeActiveRaw;
			}
			goto IL_005e;
			IL_0012:
			switch (num ^ 0x5F7B31A8)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_000d;
			IL_000d:
			num = 1601909161;
			goto IL_0012;
			IL_005e:
			return 0f;
		}

		public float GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 1416777000;
					goto IL_001e;
				}
				return axes[axisIndex].timeInactiveRaw;
			}
			goto IL_005e;
			IL_001e:
			switch (num ^ 0x54724D29)
			{
			case 0:
				break;
			case 2:
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_0019;
			IL_0019:
			num = 1416777003;
			goto IL_001e;
			IL_005e:
			return 0f;
		}

		public float GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public float GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementIdentifierId);
			while (true)
			{
				int num = -2012422951;
				while (true)
				{
					switch (num ^ -2012422952)
					{
					case 0:
						break;
					case 1:
						if (axisIndex >= 0)
						{
							if (axisIndex >= _axisCount)
							{
								goto IL_0057;
							}
							return axes[axisIndex].lastTimeInactiveRaw;
						}
						goto default;
					default:
						return 0f;
					}
					break;
					IL_0057:
					num = -2012422950;
				}
			}
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axis2DCount)
				{
					num = 1023964651;
					goto IL_0012;
				}
				return axes2D[index].value;
			}
			goto IL_0051;
			IL_0012:
			switch (num ^ 0x3D0875EA)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return Vector2.zero;
			default:
				goto IL_0051;
			}
			goto IL_000d;
			IL_000d:
			num = 1023964648;
			goto IL_0012;
			IL_0051:
			return default(Vector2);
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axis2DCount)
				{
					num = 1889809601;
					goto IL_001e;
				}
				return axes2D[index].valuePrev;
			}
			goto IL_0051;
			IL_001e:
			switch (num ^ 0x70A434C3)
			{
			case 0:
				break;
			case 1:
				return Vector2.zero;
			default:
				goto IL_0051;
			}
			goto IL_0019;
			IL_0019:
			num = 1889809602;
			goto IL_001e;
			IL_0051:
			return default(Vector2);
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return Vector2.zero;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -172998355;
					while (true)
					{
						switch (num ^ -172998356)
						{
						case 2:
							break;
						case 1:
							goto IL_0041;
						default:
							goto end_IL_0023;
						}
						break;
						IL_0041:
						if (index >= _axis2DCount)
						{
							num = -172998356;
							continue;
						}
						return axes2D[index].valueRaw;
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return default(Vector2);
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRawPrev;
		}

		public override float GetLastTimeActive()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return GetLastTimeActive(false);
		}

		public override float GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
		}

		public override float GetLastTimeAnyElementChanged()
		{
			return GetLastTimeAnyElementChanged(false);
		}

		public override float GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
		}

		public float GetLastTimeAnyAxisActive()
		{
			return GetLastTimeAnyAxisActive(false);
		}

		public float GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (axes == null)
			{
				goto IL_0027;
			}
			float num = 0f;
			int num2 = 0;
			int num3 = -1809399753;
			goto IL_002c;
			IL_002c:
			while (true)
			{
				switch (num3 ^ -1809399758)
				{
				case 3:
					break;
				case 1:
					return 0f;
				case 2:
				{
					float num5 = (useRawValues ? axes[num2].lastTimeActiveRaw : axes[num2].lastTimeActive);
					if (num5 > num)
					{
						num = num5;
						num3 = -1809399754;
						continue;
					}
					goto case 4;
				}
				case 4:
					num2++;
					num3 = -1809399753;
					continue;
				case 5:
				{
					int num4;
					if (num2 < axes.Length)
					{
						num3 = -1809399760;
						num4 = num3;
					}
					else
					{
						num3 = -1809399758;
						num4 = num3;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
			goto IL_0027;
			IL_0027:
			num3 = -1809399757;
			goto IL_002c;
		}

		public float GetLastTimeAnyAxisChanged()
		{
			return GetLastTimeAnyAxisChanged(false);
		}

		public float GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (axes == null)
			{
				return 0f;
			}
			float num = 0f;
			int num3 = default(int);
			while (true)
			{
				int num2 = -317328941;
				while (true)
				{
					switch (num2 ^ -317328942)
					{
					case 3:
						break;
					case 1:
						num3 = 0;
						num2 = -317328944;
						continue;
					case 4:
					{
						float num4 = (useRawValues ? axes[num3].lastTimeValueChangedRaw : axes[num3].lastTimeValueChanged);
						if (num4 > num)
						{
							num = num4;
							num2 = -317328942;
							continue;
						}
						goto case 0;
					}
					case 0:
						num3++;
						num2 = -317328944;
						continue;
					default:
						if (num3 >= axes.Length)
						{
							return num;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			int num;
			if (result.success)
			{
				num = 2016132797;
				goto IL_0012;
			}
			return PollForFirstAxis();
			IL_000d:
			num = 2016132798;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x782BBEBF)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
			default:
				return result;
			}
			goto IL_000d;
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			ControllerPollingInfo result = base.PollForFirstElementDown();
			int num;
			if (result.success)
			{
				num = -1224474444;
				goto IL_001e;
			}
			return PollForFirstAxis();
			IL_0019:
			num = -1224474441;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1224474443)
			{
			case 0:
				break;
			case 2:
				return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
			default:
				return result;
			}
			goto IL_0019;
		}

		public ControllerPollingInfo PollForFirstAxis()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			UpdatePollingFrameTracking();
			PwFtNoHlaNYkltznFPguDSluRym();
			int num = -1479182223;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			Pole pole = default(Pole);
			int elementIdentifierId = default(int);
			while (true)
			{
				switch (num ^ -1479182223)
				{
				case 3:
					break;
				case 6:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -1479182224;
					continue;
				case 0:
					num2 = 0;
					num = -1479182220;
					continue;
				case 4:
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, num2, pole, RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				case 1:
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				case 5:
				{
					int num3;
					if (num2 >= _axisCount)
					{
						num = -1479182218;
						num3 = num;
					}
					else
					{
						num = -1479182221;
						num3 = num;
					}
					continue;
				}
				case 2:
					if (!IsPolledAxisActive(num2, out pole, out elementIdentifierId))
					{
						num2++;
						num = -1479182220;
					}
					else
					{
						num = -1479182219;
					}
					continue;
				default:
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -1479182217;
			goto IL_0015;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			wkNQqZYSMrRhdpHoRwWdnqCqeIB wkNQqZYSMrRhdpHoRwWdnqCqeIB2 = new wkNQqZYSMrRhdpHoRwWdnqCqeIB(-2);
			wkNQqZYSMrRhdpHoRwWdnqCqeIB2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			return wkNQqZYSMrRhdpHoRwWdnqCqeIB2;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			VlWCODcocVijagRFcfmPVNkWcXEP vlWCODcocVijagRFcfmPVNkWcXEP = new VlWCODcocVijagRFcfmPVNkWcXEP(-2);
			vlWCODcocVijagRFcfmPVNkWcXEP.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			return vlWCODcocVijagRFcfmPVNkWcXEP;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			QwaahRWWJcRyNVmRVJsiJKYPwIz qwaahRWWJcRyNVmRVJsiJKYPwIz = new QwaahRWWJcRyNVmRVJsiJKYPwIz(-2);
			qwaahRWWJcRyNVmRVJsiJKYPwIz.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			return qwaahRWWJcRyNVmRVJsiJKYPwIz;
		}

		private void PwFtNoHlaNYkltznFPguDSluRym()
		{
			if (eqPhHTJPTbZzZjqXRoRXqdDrfNYA == null)
			{
				eqPhHTJPTbZzZjqXRoRXqdDrfNYA = new float[_axisCount];
				goto IL_0019;
			}
			goto IL_007e;
			IL_007e:
			int num;
			if (ZiBWJqHGYvQSltkdFfMKoNywXJD != PHllaUeIdHWbiKlhKBkFgQCtbSWA)
			{
				PHllaUeIdHWbiKlhKBkFgQCtbSWA = ZiBWJqHGYvQSltkdFfMKoNywXJD;
				num = -1693522897;
				goto IL_001e;
			}
			return;
			IL_0019:
			num = -1693522901;
			goto IL_001e;
			IL_001e:
			int num2 = default(int);
			UpdateLoopType currentUpdateLoop = default(UpdateLoopType);
			while (true)
			{
				switch (num ^ -1693522902)
				{
				case 3:
					break;
				default:
					return;
				case 0:
					num2++;
					num = -1693522904;
					continue;
				case 2:
					goto IL_0055;
				case 5:
					currentUpdateLoop = ReInput.currentUpdateLoop;
					num2 = 0;
					num = -1693522904;
					continue;
				case 1:
					goto IL_007e;
				case 4:
					eqPhHTJPTbZzZjqXRoRXqdDrfNYA[num2] = axes[num2].EiHIbOkFnjiOtBqrPpxWNhaRfUYA(currentUpdateLoop, _calibrationMap.GetAxis(num2));
					num = -1693522902;
					continue;
				case 6:
					return;
				}
				break;
				IL_0055:
				int num3;
				if (num2 >= _axisCount)
				{
					num = -1693522900;
					num3 = num;
				}
				else
				{
					num = -1693522898;
					num3 = num;
				}
			}
			goto IL_0019;
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			while (true)
			{
				int num = -1111165249;
				while (true)
				{
					float num2;
					float value;
					switch (num ^ -1111165252)
					{
					case 0:
						break;
					case 3:
						elementIdentifierId = -1;
						if (axes[index].flIXmRKXOUURLlZiHjZlJLbgGru != null)
						{
							num = -1111165250;
							continue;
						}
						goto IL_0057;
					case 2:
						if (axes[index].flIXmRKXOUURLlZiHjZlJLbgGru._excludeFromPolling)
						{
							return false;
						}
						goto IL_0057;
					default:
						{
							return false;
						}
						IL_0057:
						num2 = axes[index].EiHIbOkFnjiOtBqrPpxWNhaRfUYA(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index));
						value = num2 - eqPhHTJPTbZzZjqXRoRXqdDrfNYA[index];
						if (MathTools.Abs(value) <= 0.7f)
						{
							return false;
						}
						pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
						elementIdentifierId = RCNejcvnZtMAmgendVbiwgNYmdD.axisElementIdentifierIds[index];
						if (elementIdentifierId < 0)
						{
							num = -1111165251;
							continue;
						}
						return true;
					}
					break;
				}
			}
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			base.UpdateData(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			if (_type != ControllerType.Joystick)
			{
				goto IL_001f;
			}
			int num = 1;
			goto IL_012e;
			IL_012e:
			bool flag2 = (byte)num != 0;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			int num2 = -1810269724;
			goto IL_0024;
			IL_001f:
			num2 = -1810269726;
			goto IL_0024;
			IL_0024:
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			bool flag4 = default(bool);
			while (true)
			{
				switch (num2 ^ -1810269722)
				{
				case 8:
					break;
				case 15:
					num4++;
					num2 = -1810269713;
					continue;
				case 16:
					axes2D[num5].dvtavmcwhNkMVmvvKqcPhKMHyKbP();
					num2 = -1810269721;
					continue;
				case 12:
					axes[num4].valueRaw = _calibrationMap.GetAxis(num4).calibratedZero;
					axes[num4].xqneffBvtliTsIbgjcfZhJdKvLbg();
					num2 = -1810269719;
					continue;
				case 13:
					if (num5 >= _axis2DCount)
					{
						num3 = 0;
						num2 = -1810269715;
						continue;
					}
					goto case 16;
				case 9:
					if (num4 >= _axisCount)
					{
						num5 = 0;
						num2 = -1810269717;
						continue;
					}
					goto case 5;
				case 3:
					axes[num3].fcTFDEZsXDBrgfytqUGSCWrjjSq();
					num3++;
					num2 = -1810269716;
					continue;
				case 4:
					goto IL_0121;
				case 0:
					axes[num4].KZaWnSfEanREcjXdiSEBKrZinBA();
					num2 = -1810269719;
					continue;
				case 7:
					axes[num4].valueRaw = ybiZyKuVmvsrOHqZzdmfwidXkdm.axisValues[num4];
					if (flag2)
					{
						axes[num4].KZaWnSfEanREcjXdiSEBKrZinBA(_calibrationMap.GetAxis(num4));
						num2 = -1810269719;
						continue;
					}
					goto case 0;
				case 2:
					flag4 = _type == ControllerType.Joystick && !ybiZyKuVmvsrOHqZzdmfwidXkdm.hasReceivedInput;
					num2 = -1810269720;
					continue;
				case 11:
					num2 = -1810269716;
					continue;
				case 6:
					if (!flag3)
					{
						goto case 7;
					}
					goto IL_01d9;
				case 1:
					num5++;
					num2 = -1810269717;
					continue;
				case 14:
					num4 = 0;
					num2 = -1810269713;
					continue;
				case 5:
					axes[num4].hFZfconneSNSSDboIpZxIrDbEKL(P_0);
					if (!flag)
					{
						goto case 12;
					}
					goto IL_022f;
				default:
					if (num3 >= _axisCount)
					{
						return;
					}
					goto case 3;
				}
				break;
				IL_01d9:
				int num6;
				if (!ybiZyKuVmvsrOHqZzdmfwidXkdm.axisHasBeenPressedOSXLinux[num4])
				{
					num2 = -1810269718;
					num6 = num2;
				}
				else
				{
					num2 = -1810269727;
					num6 = num2;
				}
				continue;
				IL_022f:
				int num7;
				if (flag4)
				{
					num2 = -1810269718;
					num7 = num2;
				}
				else
				{
					num2 = -1810269728;
					num7 = num2;
				}
			}
			goto IL_001f;
			IL_0121:
			num = ((_type == ControllerType.Custom) ? 1 : 0);
			goto IL_012e;
		}

		internal bool RoxnbHmfcMcuGcFEwZyeaMuOhQh(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int mMyVYAPDqUrVlKvCuSgnRJfZwdm = P_0.mMyVYAPDqUrVlKvCuSgnRJfZwdm;
			if (mMyVYAPDqUrVlKvCuSgnRJfZwdm >= 0)
			{
				float num2 = default(float);
				bool flag = default(bool);
				while (true)
				{
					int num = -756900188;
					while (true)
					{
						int num3;
						switch (num ^ -756900177)
						{
						case 10:
							break;
						case 12:
							num = -756900191;
							continue;
						case 5:
							goto end_IL_0025;
						case 3:
							num2 = 0f;
							num = -756900189;
							continue;
						case 9:
							num3 = 0;
							goto IL_00b4;
						case 4:
							num2 = (P_2 ? axes[mMyVYAPDqUrVlKvCuSgnRJfZwdm].valueRawPrev : axes[mMyVYAPDqUrVlKvCuSgnRJfZwdm].valuePrev);
							num = -756900184;
							continue;
						case 1:
							num2 = (P_2 ? axes[mMyVYAPDqUrVlKvCuSgnRJfZwdm].valueRaw : axes[mMyVYAPDqUrVlKvCuSgnRJfZwdm].value);
							num = -756900184;
							continue;
						case 2:
							if (!flag && P_0._axisRange == AxisRange.Negative)
							{
								num2 = ((num2 <= 0f) ? num2 : 0f);
								num = -756900185;
								continue;
							}
							goto case 3;
						case 6:
							if (MathTools.Sign(num2) > 0f)
							{
								num3 = 1;
								goto IL_00b4;
							}
							num = -756900186;
							continue;
						case 17:
							return true;
						case 7:
							goto IL_01ad;
						case 15:
							if (P_0._axisContribution == Pole.Negative)
							{
								num2 *= -1f;
								num = -756900191;
								continue;
							}
							goto default;
						case 11:
							goto IL_01e2;
						case 16:
							goto IL_01f8;
						case 0:
							num2 *= -1f;
							num = -756900191;
							continue;
						case 13:
							if (P_0._axisRange != AxisRange.Full)
							{
								goto case 6;
							}
							goto IL_022f;
						case 8:
							if (P_0._axisContribution == Pole.Positive)
							{
								num2 *= -1f;
								num = -756900191;
								continue;
							}
							goto default;
						default:
							{
								P_4 = num2;
								return true;
							}
							IL_00b4:
							flag = (byte)num3 != 0;
							if (!flag || P_0._axisRange != AxisRange.Positive)
							{
								goto case 2;
							}
							num2 = ((num2 >= 0f) ? num2 : 0f);
							if (P_0._axisContribution == Pole.Negative)
							{
								num2 *= -1f;
								num = -756900191;
								continue;
							}
							goto default;
						}
						break;
						IL_022f:
						int num4;
						if (P_0._invert)
						{
							num = -756900177;
							num4 = num;
						}
						else
						{
							num = -756900191;
							num4 = num;
						}
						continue;
						IL_01e2:
						if (mMyVYAPDqUrVlKvCuSgnRJfZwdm < _axisCount)
						{
							int num5;
							if (!P_3)
							{
								num = -756900178;
								num5 = num;
							}
							else
							{
								num = -756900181;
								num5 = num;
							}
						}
						else
						{
							num = -756900182;
						}
						continue;
						IL_01ad:
						if (!MathTools.Approximately(num2, 0f))
						{
							int num6;
							if (elementType != ControllerElementType.Axis)
							{
								num = -756900161;
								num6 = num;
							}
							else
							{
								num = -756900190;
								num6 = num;
							}
						}
						else
						{
							num = -756900162;
						}
						continue;
						IL_01f8:
						int num7;
						if (elementType == ControllerElementType.Button)
						{
							num = -756900192;
							num7 = num;
						}
						else
						{
							num = -756900191;
							num7 = num;
						}
					}
					continue;
					end_IL_0025:
					break;
				}
			}
			return false;
		}

		internal override void BakeMap(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				ControllerMapWithAxes controllerMapWithAxes = P_0 as ControllerMapWithAxes;
				if (controllerMapWithAxes != null)
				{
					while (true)
					{
						base.BakeMap(P_0);
						IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
						int num = 0;
						int num2 = 109185612;
						while (true)
						{
							switch (num2 ^ 0x6820A4D)
							{
							case 0:
								num2 = 109185615;
								continue;
							case 3:
								BakeActionElementMap(P_0, axisMaps[num]);
								num++;
								num2 = 109185612;
								continue;
							case 4:
								break;
							case 2:
								goto end_IL_0043;
							default:
								if (num >= axisMaps.Count)
								{
									return;
								}
								goto case 3;
							}
							break;
						}
						continue;
						end_IL_0043:
						break;
					}
					continue;
				}
				Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
				break;
			}
		}

		internal override void BakeActionElementMap(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				base.BakeActionElementMap(P_0, P_1);
				int num;
				int num2;
				if (P_1._elementType != ControllerElementType.Axis)
				{
					num = -1734583557;
					num2 = num;
				}
				else
				{
					num = -1734583559;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1734583557)
					{
					case 3:
						goto IL_0004;
					case 1:
						break;
					case 0:
						return;
					default:
						P_1.IKsKsQjqHpGcmPftZSVTCEpXtFB(P_0);
						return;
					}
					break;
					IL_0004:
					num = -1734583558;
				}
			}
		}

		internal void vFRIPkHGpMqQFbGcGqqRyxZqUXXX()
		{
			int num = 0;
			while (num < axisCount)
			{
				while (true)
				{
					IL_00b2:
					int num2;
					switch (axes[num].flIXmRKXOUURLlZiHjZlJLbgGru._specialAxisType)
					{
					case SpecialAxisType.None:
						_calibrationMap.Axes[num].calibrationMode = AlternateAxisCalibrationType.Default;
						num2 = -1082530781;
						goto IL_000c;
					case SpecialAxisType.Throttle:
						goto IL_006b;
					default:
						{
							num2 = -1082530784;
							goto IL_000c;
						}
						IL_000c:
						while (true)
						{
							switch (num2 ^ -1082530780)
							{
							case 8:
								num2 = -1082530782;
								continue;
							case 5:
								throw new NotImplementedException();
							case 2:
								break;
							case 1:
								goto IL_006b;
							case 7:
								num2 = -1082530780;
								continue;
							case 0:
								num++;
								num2 = -1082530777;
								continue;
							case 6:
								goto IL_00b2;
							case 4:
								num2 = -1082530783;
								continue;
							default:
								goto end_IL_00c6;
							}
							break;
						}
						goto case SpecialAxisType.None;
						IL_006b:
						_calibrationMap.Axes[num].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
						num2 = -1082530780;
						goto IL_000c;
						end_IL_00c6:
						break;
					}
					break;
				}
			}
		}

		internal override void Clear()
		{
			base.Clear();
			int num2 = default(int);
			while (true)
			{
				int num = 1318541766;
				while (true)
				{
					switch (num ^ 0x4E9759C3)
					{
					case 4:
						break;
					default:
						return;
					case 6:
						axes[num2].Reset();
						num = 1318541761;
						continue;
					case 2:
						num2++;
						num = 1318541763;
						continue;
					case 0:
					{
						int num4;
						if (num2 < _axisCount)
						{
							num = 1318541760;
							num4 = num;
						}
						else
						{
							num = 1318541764;
							num4 = num;
						}
						continue;
					}
					case 5:
						num2 = 0;
						num = 1318541762;
						continue;
					case 3:
					{
						int num3;
						if (axes[num2] != null)
						{
							num = 1318541765;
							num3 = num;
						}
						else
						{
							num = 1318541761;
							num3 = num;
						}
						continue;
					}
					case 1:
						num = 1318541763;
						continue;
					case 7:
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> fkmgvxWpMZmQzugQJFuoIPVrFZlC()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> kWWSEXIbsAXQwoIrDotZJbIXYCf()
		{
			return base.PollForAllElementsDown();
		}
	}
}
