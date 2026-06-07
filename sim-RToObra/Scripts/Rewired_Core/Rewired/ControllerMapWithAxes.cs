using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerMapWithAxes : ControllerMap
	{
		private sealed class zdPevVkizUulSZlkMudazHPaSIn : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMapWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

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
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_007b;
				IL_0012:
				int num = -35331919;
				goto IL_0017;
				IL_0017:
				zdPevVkizUulSZlkMudazHPaSIn zdPevVkizUulSZlkMudazHPaSIn2 = default(zdPevVkizUulSZlkMudazHPaSIn);
				while (true)
				{
					switch (num ^ -35331918)
					{
					case 0:
						break;
					case 1:
						zdPevVkizUulSZlkMudazHPaSIn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -35331914;
						continue;
					case 5:
						num = -35331914;
						continue;
					case 2:
						zdPevVkizUulSZlkMudazHPaSIn2 = this;
						num = -35331913;
						continue;
					case 3:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = -35331920;
							continue;
						}
						goto IL_007b;
					case 6:
						goto IL_007b;
					default:
						zdPevVkizUulSZlkMudazHPaSIn2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = EWQVMNaYUmlNevCoyIethJojVez;
						zdPevVkizUulSZlkMudazHPaSIn2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						return zdPevVkizUulSZlkMudazHPaSIn2;
					}
					break;
				}
				goto IL_0012;
				IL_007b:
				zdPevVkizUulSZlkMudazHPaSIn2 = new zdPevVkizUulSZlkMudazHPaSIn(0);
				num = -35331917;
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
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 866064642;
						goto IL_0023;
					case 2:
						goto IL_010a;
						IL_0023:
						while (true)
						{
							switch (num ^ 0x339F1901)
							{
							case 9:
								num = 866064647;
								continue;
							case 5:
								if (!AsRlFjnbjSBLrcANLpabHIHimJLO.MoveNext())
								{
									USsmtEKltWHMUcUQRNXjCUFqiAR();
									num = 866064641;
									continue;
								}
								goto case 7;
							case 3:
								if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
								{
									ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
									num = 866064641;
									continue;
								}
								goto case 8;
							case 6:
								break;
							case 8:
								if (CcfTFbvLTcqsiXVrUOCJWGLeCzX >= 0)
								{
									AsRlFjnbjSBLrcANLpabHIHimJLO = iKQXbXnVtIaMZEJNeigQJWAHqUx.AxisMaps.GetEnumerator();
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									num = 866064644;
									continue;
								}
								goto end_IL_0008;
							case 1:
								aimBzjfQfPyaeQqysAQJISCBhELB = qHFvxOmqgACMfmejWgrwrmZiAqoC;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								return true;
							case 2:
								goto IL_010a;
							case 7:
								qHFvxOmqgACMfmejWgrwrmZiAqoC = AsRlFjnbjSBLrcANLpabHIHimJLO.Current;
								if (qHFvxOmqgACMfmejWgrwrmZiAqoC._actionId != CcfTFbvLTcqsiXVrUOCJWGLeCzX)
								{
									goto case 5;
								}
								goto IL_0142;
							case 4:
								goto IL_015e;
							default:
								goto end_IL_0008;
							}
							break;
							IL_015e:
							int num2;
							if (!qHFvxOmqgACMfmejWgrwrmZiAqoC.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = 866064644;
								num2 = num;
							}
							else
							{
								num = 866064640;
								num2 = num;
							}
							continue;
							IL_0142:
							int num3;
							if (!kUWZXXVHFictxLEMjETmHtCiqtXG)
							{
								num = 866064640;
								num3 = num;
							}
							else
							{
								num = 866064645;
								num3 = num;
							}
						}
						goto case 0;
						IL_010a:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 866064644;
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
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -1818551303;
					while (true)
					{
						switch (num2 ^ -1818551304)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							switch (num)
							{
							case 1:
							case 2:
								try
								{
									return;
								}
								finally
								{
									USsmtEKltWHMUcUQRNXjCUFqiAR();
								}
							}
							goto IL_0035;
						case 0:
							return;
						}
						break;
						IL_0035:
						num2 = -1818551304;
					}
				}
			}

			[DebuggerHidden]
			public zdPevVkizUulSZlkMudazHPaSIn(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void USsmtEKltWHMUcUQRNXjCUFqiAR()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				while (true)
				{
					int num = 619314429;
					while (true)
					{
						switch (num ^ 0x24E9FCFC)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (AsRlFjnbjSBLrcANLpabHIHimJLO != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						AsRlFjnbjSBLrcANLpabHIHimJLO.Dispose();
						num = 619314428;
					}
				}
			}
		}

		private sealed class sQWbzXEkGdibIXVncfeXWXTafzo : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMapWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ControllerMap NsnpsJhWvVdnFvGpHHimGkwdsno;

			public ControllerMap AkCCOPqWBDIoelQfBDGjGqsxrCK;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public ElementAssignmentConflictInfo CayAjQadxFcfRtECDWHbcXWQpVPB;

			public ControllerMapWithAxes QjhUWncqxrbBVzSzxRjsoCsjSFA;

			public IList<ActionElementMap> uctckdeLCVfYjwjNlmuDGSpgUSKm;

			public int kPEjCXObudccKVUsUTshFbQDpkz;

			public int iZGaMmSvAnTSFuttDEfDgeeGddm;

			public ActionElementMap OJrqBQUxkcziRqeKWByrsbAhgrpf;

			public int XLRZEnLwcYDUqjSChLvNECTSDeIa;

			public ActionElementMap TlSbENdNNPCMmTiwMrgJEejTatfq;

			public IEnumerator<ElementAssignmentConflictInfo> qClriEVdICdBUhLqhuncLuAmdeAC;

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
				goto IL_0040;
				IL_0012:
				int num = 801048946;
				goto IL_0017;
				IL_0017:
				sQWbzXEkGdibIXVncfeXWXTafzo sQWbzXEkGdibIXVncfeXWXTafzo2 = default(sQWbzXEkGdibIXVncfeXWXTafzo);
				while (true)
				{
					switch (num ^ 0x2FBF0973)
					{
					case 0:
						break;
					case 5:
						goto IL_0040;
					case 6:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						sQWbzXEkGdibIXVncfeXWXTafzo2 = this;
						num = 801048944;
						continue;
					case 1:
						goto IL_006a;
					case 2:
						sQWbzXEkGdibIXVncfeXWXTafzo2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						num = 801048951;
						continue;
					case 3:
						sQWbzXEkGdibIXVncfeXWXTafzo2.NsnpsJhWvVdnFvGpHHimGkwdsno = AkCCOPqWBDIoelQfBDGjGqsxrCK;
						num = 801048945;
						continue;
					default:
						return sQWbzXEkGdibIXVncfeXWXTafzo2;
					}
					break;
					IL_006a:
					int num2;
					if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						num = 801048949;
						num2 = num;
					}
					else
					{
						num = 801048950;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0040:
				sQWbzXEkGdibIXVncfeXWXTafzo2 = new sQWbzXEkGdibIXVncfeXWXTafzo(0);
				sQWbzXEkGdibIXVncfeXWXTafzo2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 801048944;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
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
						int num2 = -1008160356;
						while (true)
						{
							switch (num2 ^ -1008160379)
							{
							case 6:
								break;
							default:
								goto end_IL_000c;
							case 19:
								if (!qClriEVdICdBUhLqhuncLuAmdeAC.MoveNext())
								{
									DULNNgxbNndCpCzLipVfjovJySP();
									QjhUWncqxrbBVzSzxRjsoCsjSFA = NsnpsJhWvVdnFvGpHHimGkwdsno as ControllerMapWithAxes;
									num2 = -1008160369;
									continue;
								}
								goto case 15;
							case 23:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -1008160362;
								continue;
							case 14:
								goto IL_00c6;
							case 22:
								if (OJrqBQUxkcziRqeKWByrsbAhgrpf.CheckForAssignmentConflict(TlSbENdNNPCMmTiwMrgJEejTatfq))
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(iKQXbXnVtIaMZEJNeigQJWAHqUx._categoryId).userAssignable, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerType, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerId, iKQXbXnVtIaMZEJNeigQJWAHqUx._id, OJrqBQUxkcziRqeKWByrsbAhgrpf.rOuBUzbbciWwktcpmiPWpQIKoaAa, OJrqBQUxkcziRqeKWByrsbAhgrpf._actionId, OJrqBQUxkcziRqeKWByrsbAhgrpf._elementType, OJrqBQUxkcziRqeKWByrsbAhgrpf._elementIdentifierId, OJrqBQUxkcziRqeKWByrsbAhgrpf.keyCode, OJrqBQUxkcziRqeKWByrsbAhgrpf.modifierKeyFlags);
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
									num2 = -1008160370;
									continue;
								}
								goto case 2;
							case 24:
							{
								int num7;
								if (XLRZEnLwcYDUqjSChLvNECTSDeIa < kPEjCXObudccKVUsUTshFbQDpkz)
								{
									num2 = -1008160368;
									num7 = num2;
								}
								else
								{
									num2 = -1008160375;
									num7 = num2;
								}
								continue;
							}
							case 3:
								kPEjCXObudccKVUsUTshFbQDpkz = uctckdeLCVfYjwjNlmuDGSpgUSKm.Count;
								iZGaMmSvAnTSFuttDEfDgeeGddm = 0;
								num2 = -1008160384;
								continue;
							case 16:
								goto IL_01f2;
							case 2:
								XLRZEnLwcYDUqjSChLvNECTSDeIa++;
								num2 = -1008160355;
								continue;
							case 13:
							{
								uctckdeLCVfYjwjNlmuDGSpgUSKm = QjhUWncqxrbBVzSzxRjsoCsjSFA.AxisMaps;
								int num5;
								if (uctckdeLCVfYjwjNlmuDGSpgUSKm == null)
								{
									num2 = -1008160363;
									num5 = num2;
								}
								else
								{
									num2 = -1008160378;
									num5 = num2;
								}
								continue;
							}
							case 1:
								result = true;
								goto end_IL_000c;
							case 18:
								OJrqBQUxkcziRqeKWByrsbAhgrpf = iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI[iZGaMmSvAnTSFuttDEfDgeeGddm];
								if (kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									int num9;
									if (OJrqBQUxkcziRqeKWByrsbAhgrpf.PAfqntGWZaNgzmZFIOyQPuJGOCq)
									{
										num2 = -1008160364;
										num9 = num2;
									}
									else
									{
										num2 = -1008160375;
										num9 = num2;
									}
									continue;
								}
								goto case 17;
							case 25:
								switch (num)
								{
								case 2:
									break;
								case 0:
									goto IL_00c6;
								case 1:
									goto IL_01f2;
								default:
									goto IL_02b2;
								case 3:
									goto IL_0425;
								}
								goto case 23;
							case 21:
								TlSbENdNNPCMmTiwMrgJEejTatfq = uctckdeLCVfYjwjNlmuDGSpgUSKm[XLRZEnLwcYDUqjSChLvNECTSDeIa];
								if (kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									int num8;
									if (TlSbENdNNPCMmTiwMrgJEejTatfq.PAfqntGWZaNgzmZFIOyQPuJGOCq)
									{
										num2 = -1008160365;
										num8 = num2;
									}
									else
									{
										num2 = -1008160377;
										num8 = num2;
									}
									continue;
								}
								goto case 22;
							case 7:
								if (NsnpsJhWvVdnFvGpHHimGkwdsno != null)
								{
									qClriEVdICdBUhLqhuncLuAmdeAC = iKQXbXnVtIaMZEJNeigQJWAHqUx.kWWSEXIbsAXQwoIrDotZJbIXYCf(NsnpsJhWvVdnFvGpHHimGkwdsno, kUWZXXVHFictxLEMjETmHtCiqtXG).GetEnumerator();
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									num2 = -1008160372;
									continue;
								}
								goto IL_01f2;
							case 4:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx._enabled)
								{
									int num6;
									if (!QjhUWncqxrbBVzSzxRjsoCsjSFA._enabled)
									{
										num2 = -1008160363;
										num6 = num2;
									}
									else
									{
										num2 = -1008160376;
										num6 = num2;
									}
									continue;
								}
								goto IL_01f2;
							case 15:
								CayAjQadxFcfRtECDWHbcXWQpVPB = qClriEVdICdBUhLqhuncLuAmdeAC.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = CayAjQadxFcfRtECDWHbcXWQpVPB;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								num2 = -1008160380;
								continue;
							case 11:
								result = true;
								goto end_IL_000c;
							case 0:
								num2 = -1008160363;
								continue;
							case 17:
								XLRZEnLwcYDUqjSChLvNECTSDeIa = 0;
								num2 = -1008160355;
								continue;
							case 9:
								num2 = -1008160362;
								continue;
							case 10:
								if (QjhUWncqxrbBVzSzxRjsoCsjSFA != null)
								{
									int num4;
									if (!kUWZXXVHFictxLEMjETmHtCiqtXG)
									{
										num2 = -1008160376;
										num4 = num2;
									}
									else
									{
										num2 = -1008160383;
										num4 = num2;
									}
									continue;
								}
								goto IL_01f2;
							case 5:
							{
								int num3;
								if (iZGaMmSvAnTSFuttDEfDgeeGddm < iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI.Count)
								{
									num2 = -1008160361;
									num3 = num2;
								}
								else
								{
									num2 = -1008160363;
									num3 = num2;
								}
								continue;
							}
							case 8:
								goto IL_0425;
							case 12:
								iZGaMmSvAnTSFuttDEfDgeeGddm++;
								num2 = -1008160384;
								continue;
							case 20:
								goto end_IL_000c;
								IL_00c6:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
								{
									ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
									num2 = -1008160379;
									continue;
								}
								goto case 7;
								IL_01f2:
								result = false;
								num2 = -1008160367;
								continue;
								IL_0425:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -1008160377;
								continue;
								IL_02b2:
								num2 = -1008160363;
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
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -1263711754;
					while (true)
					{
						switch (num2 ^ -1263711753)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							switch (num)
							{
							case 1:
							case 2:
								try
								{
									return;
								}
								finally
								{
									DULNNgxbNndCpCzLipVfjovJySP();
								}
							}
							goto IL_0035;
						case 2:
							return;
						}
						break;
						IL_0035:
						num2 = -1263711755;
					}
				}
			}

			[DebuggerHidden]
			public sQWbzXEkGdibIXVncfeXWXTafzo(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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

		private sealed class koxDDKYInYIhczXgwjNsuJStJvR : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMapWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ActionElementMap zZOKcJvuOQCLBInkTSUcrEfEQnB;

			public ActionElementMap WfePqZKTzLLSOkMcfaksZhTkOHF;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public ElementAssignmentConflictInfo njaVVVTDYpKbaranjCjSDymlYkg;

			public int qfpyoxZOyLWSBpLHPIXOwUtGTAU;

			public ActionElementMap vqKXZjRetngdnFzPZkkMgzITYBu;

			public IEnumerator<ElementAssignmentConflictInfo> JorHuBFWtfAfKahsuTWapenhFMf;

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
				koxDDKYInYIhczXgwjNsuJStJvR koxDDKYInYIhczXgwjNsuJStJvR2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					koxDDKYInYIhczXgwjNsuJStJvR2 = this;
					goto IL_0025;
				}
				goto IL_0052;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x793A9447)
					{
					case 0:
						break;
					case 3:
						num = 2033882179;
						continue;
					case 2:
						goto IL_0052;
					case 1:
						koxDDKYInYIhczXgwjNsuJStJvR2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 2033882179;
						continue;
					default:
						koxDDKYInYIhczXgwjNsuJStJvR2.zZOKcJvuOQCLBInkTSUcrEfEQnB = WfePqZKTzLLSOkMcfaksZhTkOHF;
						koxDDKYInYIhczXgwjNsuJStJvR2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						return koxDDKYInYIhczXgwjNsuJStJvR2;
					}
					break;
				}
				goto IL_0025;
				IL_0052:
				koxDDKYInYIhczXgwjNsuJStJvR2 = new koxDDKYInYIhczXgwjNsuJStJvR(0);
				num = 2033882182;
				goto IL_002a;
				IL_0025:
				num = 2033882180;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 3:
						goto IL_00df;
					case 0:
						goto IL_0205;
					case 2:
						goto IL_0295;
						IL_00df:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -1218411852;
						goto IL_0027;
						IL_0027:
						while (true)
						{
							switch (num ^ -1218411850)
							{
							case 0:
								num = -1218411851;
								continue;
							case 10:
								njaVVVTDYpKbaranjCjSDymlYkg = JorHuBFWtfAfKahsuTWapenhFMf.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = njaVVVTDYpKbaranjCjSDymlYkg;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								return true;
							case 7:
								break;
							case 12:
								goto IL_00df;
							case 1:
								vqKXZjRetngdnFzPZkkMgzITYBu = iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI[qfpyoxZOyLWSBpLHPIXOwUtGTAU];
								if (kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									goto IL_0114;
								}
								goto case 9;
							case 9:
								if (vqKXZjRetngdnFzPZkkMgzITYBu.CheckForAssignmentConflict(zZOKcJvuOQCLBInkTSUcrEfEQnB))
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(iKQXbXnVtIaMZEJNeigQJWAHqUx._categoryId).userAssignable, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerType, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerId, iKQXbXnVtIaMZEJNeigQJWAHqUx._id, vqKXZjRetngdnFzPZkkMgzITYBu.rOuBUzbbciWwktcpmiPWpQIKoaAa, vqKXZjRetngdnFzPZkkMgzITYBu._actionId, vqKXZjRetngdnFzPZkkMgzITYBu._elementType, vqKXZjRetngdnFzPZkkMgzITYBu._elementIdentifierId, vqKXZjRetngdnFzPZkkMgzITYBu.keyCode, vqKXZjRetngdnFzPZkkMgzITYBu.modifierKeyFlags);
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
									return true;
								}
								goto case 2;
							case 2:
								qfpyoxZOyLWSBpLHPIXOwUtGTAU++;
								num = -1218411856;
								continue;
							case 3:
								goto IL_0205;
							case 4:
								if (JorHuBFWtfAfKahsuTWapenhFMf.MoveNext())
								{
									goto case 10;
								}
								cZkvjQiFgQMHCWReMOuxnMpPpOL();
								if (kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									goto IL_025a;
								}
								goto case 11;
							case 13:
								num = -1218411854;
								continue;
							case 5:
								goto IL_0295;
							case 11:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI != null)
								{
									qfpyoxZOyLWSBpLHPIXOwUtGTAU = 0;
									num = -1218411856;
									continue;
								}
								goto end_IL_0008;
							case 6:
								goto IL_02c4;
							default:
								goto end_IL_0008;
							}
							break;
							IL_02c4:
							int num2;
							if (qfpyoxZOyLWSBpLHPIXOwUtGTAU >= iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI.Count)
							{
								num = -1218411842;
								num2 = num;
							}
							else
							{
								num = -1218411849;
								num2 = num;
							}
							continue;
							IL_025a:
							if (!iKQXbXnVtIaMZEJNeigQJWAHqUx._enabled)
							{
								goto end_IL_0008;
							}
							int num3;
							if (!zZOKcJvuOQCLBInkTSUcrEfEQnB.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = -1218411842;
								num3 = num;
							}
							else
							{
								num = -1218411843;
								num3 = num;
							}
							continue;
							IL_0114:
							int num4;
							if (vqKXZjRetngdnFzPZkkMgzITYBu.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = -1218411841;
								num4 = num;
							}
							else
							{
								num = -1218411852;
								num4 = num;
							}
						}
						goto IL_00a1;
						IL_0295:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = -1218411854;
						goto IL_0027;
						IL_0205:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
						{
							ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1218411842;
							goto IL_0027;
						}
						goto IL_00a1;
						IL_00a1:
						if (zZOKcJvuOQCLBInkTSUcrEfEQnB == null)
						{
							break;
						}
						JorHuBFWtfAfKahsuTWapenhFMf = iKQXbXnVtIaMZEJNeigQJWAHqUx.HzMRlhjcLPWkeqEOMcYNBjNvhmFi(zZOKcJvuOQCLBInkTSUcrEfEQnB, kUWZXXVHFictxLEMjETmHtCiqtXG).GetEnumerator();
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = -1218411845;
						goto IL_0027;
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
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 406196078;
					while (true)
					{
						switch (num2 ^ 0x18360F6C)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							switch (num)
							{
							case 1:
							case 2:
								try
								{
									return;
								}
								finally
								{
									cZkvjQiFgQMHCWReMOuxnMpPpOL();
								}
							}
							goto IL_0035;
						case 1:
							return;
						}
						break;
						IL_0035:
						num2 = 406196077;
					}
				}
			}

			[DebuggerHidden]
			public koxDDKYInYIhczXgwjNsuJStJvR(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void cZkvjQiFgQMHCWReMOuxnMpPpOL()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (JorHuBFWtfAfKahsuTWapenhFMf != null)
				{
					JorHuBFWtfAfKahsuTWapenhFMf.Dispose();
				}
			}
		}

		private sealed class TYSGWCaCnadqFmPowvJgauBUrte : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMapWithAxes iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public ElementAssignmentConflictCheck mtCaFmEWqIwhWsqkQteeLYfucQfp;

			public ElementAssignmentConflictCheck zmNiuGMQtlBlHidAStqiwbddGtbg;

			public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

			public bool pBwzwenOfAhpelzwewTaMxzWsmu;

			public ElementAssignmentConflictInfo XNkJfCyGrcyCsHnbcHuXERMMosI;

			public ElementAssignment pjNMYEXwGOLqZIhKwzFrKCrTxEM;

			public int GQMMAmjuYGMyPQWYQBhuWzXeydb;

			public ActionElementMap qYlkAMeESZLOVCioJMCbpagypyq;

			public IEnumerator<ElementAssignmentConflictInfo> xcYMpMAxhHEfSucEKzunffBHLkF;

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
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					goto IL_0023;
				}
				goto IL_0059;
				IL_0028:
				int num;
				TYSGWCaCnadqFmPowvJgauBUrte tYSGWCaCnadqFmPowvJgauBUrte = default(TYSGWCaCnadqFmPowvJgauBUrte);
				while (true)
				{
					switch (num ^ -1879222916)
					{
					case 4:
						break;
					case 3:
						tYSGWCaCnadqFmPowvJgauBUrte = this;
						num = -1879222916;
						continue;
					case 0:
						num = -1879222914;
						continue;
					case 1:
						goto IL_0059;
					default:
						tYSGWCaCnadqFmPowvJgauBUrte.mtCaFmEWqIwhWsqkQteeLYfucQfp = zmNiuGMQtlBlHidAStqiwbddGtbg;
						tYSGWCaCnadqFmPowvJgauBUrte.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						return tYSGWCaCnadqFmPowvJgauBUrte;
					}
					break;
				}
				goto IL_0023;
				IL_0059:
				tYSGWCaCnadqFmPowvJgauBUrte = new TYSGWCaCnadqFmPowvJgauBUrte(0);
				tYSGWCaCnadqFmPowvJgauBUrte.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -1879222914;
				goto IL_0028;
				IL_0023:
				num = -1879222913;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					int num6;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 2:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = -2032852808;
						goto IL_0027;
					case 0:
						goto IL_0157;
					case 3:
						goto IL_0328;
						IL_0027:
						while (true)
						{
							switch (num ^ -2032852805)
							{
							case 16:
								num = -2032852816;
								continue;
							case 1:
								num = -2032852812;
								continue;
							case 14:
								XNkJfCyGrcyCsHnbcHuXERMMosI = xcYMpMAxhHEfSucEKzunffBHLkF.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = XNkJfCyGrcyCsHnbcHuXERMMosI;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								result = true;
								num = -2032852814;
								continue;
							case 12:
								break;
							case 3:
								if (xcYMpMAxhHEfSucEKzunffBHLkF.MoveNext())
								{
									goto case 14;
								}
								goto IL_00d0;
							case 2:
								xcYMpMAxhHEfSucEKzunffBHLkF = iKQXbXnVtIaMZEJNeigQJWAHqUx.DAnVRsqqDqWmOcgGbTEBnLkHiGp(mtCaFmEWqIwhWsqkQteeLYfucQfp, kUWZXXVHFictxLEMjETmHtCiqtXG).GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -2032852808;
								continue;
							case 7:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI != null)
								{
									pjNMYEXwGOLqZIhKwzFrKCrTxEM = mtCaFmEWqIwhWsqkQteeLYfucQfp.ToElementAssignment();
									GQMMAmjuYGMyPQWYQBhuWzXeydb = 0;
									num = -2032852805;
									continue;
								}
								goto end_IL_0008;
							case 11:
								goto IL_0157;
							case 6:
								goto IL_0184;
							case 8:
								qYlkAMeESZLOVCioJMCbpagypyq = iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI[GQMMAmjuYGMyPQWYQBhuWzXeydb];
								if (kUWZXXVHFictxLEMjETmHtCiqtXG)
								{
									goto IL_01c9;
								}
								goto case 4;
							case 0:
								goto IL_01ea;
							case 9:
								goto end_IL_0000;
							case 4:
								if (qYlkAMeESZLOVCioJMCbpagypyq.rOuBUzbbciWwktcpmiPWpQIKoaAa == mtCaFmEWqIwhWsqkQteeLYfucQfp.elementMapId || !qYlkAMeESZLOVCioJMCbpagypyq.CheckForAssignmentConflict(pjNMYEXwGOLqZIhKwzFrKCrTxEM))
								{
									goto case 5;
								}
								aimBzjfQfPyaeQqysAQJISCBhELB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(iKQXbXnVtIaMZEJNeigQJWAHqUx._categoryId).userAssignable, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerType, iKQXbXnVtIaMZEJNeigQJWAHqUx._controllerId, iKQXbXnVtIaMZEJNeigQJWAHqUx._id, qYlkAMeESZLOVCioJMCbpagypyq.rOuBUzbbciWwktcpmiPWpQIKoaAa, qYlkAMeESZLOVCioJMCbpagypyq._actionId, qYlkAMeESZLOVCioJMCbpagypyq._elementType, qYlkAMeESZLOVCioJMCbpagypyq._elementIdentifierId, qYlkAMeESZLOVCioJMCbpagypyq.keyCode, qYlkAMeESZLOVCioJMCbpagypyq.modifierKeyFlags);
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								result = true;
								goto end_IL_0000;
							case 5:
								GQMMAmjuYGMyPQWYQBhuWzXeydb++;
								num = -2032852805;
								continue;
							case 13:
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = -2032852806;
								continue;
							case 10:
								goto IL_0328;
							default:
								goto end_IL_0008;
							}
							break;
							IL_01ea:
							int num2;
							if (GQMMAmjuYGMyPQWYQBhuWzXeydb < iKQXbXnVtIaMZEJNeigQJWAHqUx.yqfwPzXnQCcQWmMZOGXrgztArbHI.Count)
							{
								num = -2032852813;
								num2 = num;
							}
							else
							{
								num = -2032852812;
								num2 = num;
							}
							continue;
							IL_0184:
							int num3;
							if (!iKQXbXnVtIaMZEJNeigQJWAHqUx._enabled)
							{
								num = -2032852812;
								num3 = num;
							}
							else
							{
								num = -2032852804;
								num3 = num;
							}
							continue;
							IL_00d0:
							NkzuZBmcZzvzKyTnBefQXdiWpGg();
							int num4;
							if (!kUWZXXVHFictxLEMjETmHtCiqtXG)
							{
								num = -2032852804;
								num4 = num;
							}
							else
							{
								num = -2032852803;
								num4 = num;
							}
							continue;
							IL_01c9:
							int num5;
							if (!qYlkAMeESZLOVCioJMCbpagypyq.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num = -2032852802;
								num5 = num;
							}
							else
							{
								num = -2032852801;
								num5 = num;
							}
						}
						goto case 2;
						IL_0328:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -2032852802;
						goto IL_0027;
						IL_0157:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (ReInput._id == iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
						{
							num = -2032852807;
							num6 = num;
						}
						else
						{
							num = -2032852810;
							num6 = num;
						}
						goto IL_0027;
						end_IL_0008:
						break;
					}
					result = false;
					end_IL_0000:;
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
						NkzuZBmcZzvzKyTnBefQXdiWpGg();
					}
				}
			}

			[DebuggerHidden]
			public TYSGWCaCnadqFmPowvJgauBUrte(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void NkzuZBmcZzvzKyTnBefQXdiWpGg()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				while (true)
				{
					int num = -491304357;
					while (true)
					{
						switch (num ^ -491304360)
						{
						case 0:
							break;
						default:
							return;
						case 3:
						{
							int num2;
							if (xcYMpMAxhHEfSucEKzunffBHLkF != null)
							{
								num = -491304358;
								num2 = num;
							}
							else
							{
								num = -491304359;
								num2 = num;
							}
							continue;
						}
						case 2:
							xcYMpMAxhHEfSucEKzunffBHLkF.Dispose();
							num = -491304359;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private readonly IList<ActionElementMap> yqfwPzXnQCcQWmMZOGXrgztArbHI;

		private readonly ReadOnlyCollection<ActionElementMap> HzeXlolQbBeUhGGukIPIfDHuLuc;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
				{
					return 0;
				}
				return yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return HzeXlolQbBeUhGGukIPIfDHuLuc;
			}
		}

		internal AList<ActionElementMap> AxisMaps_orig
		{
			get
			{
				return (AList<ActionElementMap>)yqfwPzXnQCcQWmMZOGXrgztArbHI;
			}
		}

		public ControllerMapWithAxes()
		{
			yqfwPzXnQCcQWmMZOGXrgztArbHI = new AList<ActionElementMap>();
			HzeXlolQbBeUhGGukIPIfDHuLuc = new ReadOnlyCollection<ActionElementMap>(yqfwPzXnQCcQWmMZOGXrgztArbHI);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes controllerMap)
			: base(controllerMap)
		{
			yqfwPzXnQCcQWmMZOGXrgztArbHI = new AList<ActionElementMap>();
			HzeXlolQbBeUhGGukIPIfDHuLuc = new ReadOnlyCollection<ActionElementMap>(yqfwPzXnQCcQWmMZOGXrgztArbHI);
			if (controllerMap.yqfwPzXnQCcQWmMZOGXrgztArbHI != null)
			{
				int count = controllerMap.yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
				for (int i = 0; i < count; i++)
				{
					wEjrXWgpPemJWXOxgnwHNSDxUZx(new ActionElementMap(controllerMap.yqfwPzXnQCcQWmMZOGXrgztArbHI[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				goto IL_0024;
			}
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				return false;
			}
			int count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			int num = 0;
			int num2 = 979828492;
			goto IL_0029;
			IL_0029:
			while (true)
			{
				switch (num2 ^ 0x3A66FF0D)
				{
				case 2:
					break;
				case 3:
					return true;
				case 0:
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num]._actionId != actionId)
					{
						goto IL_007d;
					}
					return true;
				default:
					if (num >= count)
					{
						return false;
					}
					goto case 0;
				}
				break;
				IL_007d:
				num++;
				num2 = 979828492;
			}
			goto IL_0024;
			IL_0024:
			num2 = 979828494;
			goto IL_0029;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				result = null;
				goto IL_001d;
			}
			int num;
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				num = 1080429229;
			}
			else if (NazMgzUnvggfOsDycmqIQvTPcxX(elementType))
			{
				ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
				BakeElementMap(actionElementMap);
				wEjrXWgpPemJWXOxgnwHNSDxUZx(actionElementMap);
				result = actionElementMap;
				num = 1080429231;
			}
			else
			{
				num = 1080429227;
			}
			goto IL_0022;
			IL_001d:
			num = 1080429230;
			goto IL_0022;
			IL_0022:
			switch (num ^ 0x40660AAF)
			{
			case 3:
				break;
			case 1:
				return false;
			case 4:
				return false;
			case 2:
				return true;
			default:
				return true;
			}
			goto IL_001d;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			int num;
			int num2;
			if (NazMgzUnvggfOsDycmqIQvTPcxX(elementMap._elementType))
			{
				num = -1478051510;
				num2 = num;
			}
			else
			{
				num = -1478051511;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = -1478051505;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1478051510)
				{
				case 4:
					break;
				case 2:
					return false;
				case 0:
				{
					int num3 = gOcKLNtqDSCVlHyLurllgnkHbLHN(elementMapId);
					if (num3 >= 0)
					{
						ControllerMap.luomRJHoFJehByGwbbSySSuKiyS(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
						BakeElementMap(elementMap);
						num = -1478051509;
					}
					else
					{
						num = -1478051512;
					}
					continue;
				}
				case 3:
					DeleteElementMap(elementMapId);
					elementMap._elementType = ControllerElementType.Axis;
					wEjrXWgpPemJWXOxgnwHNSDxUZx(elementMap);
					num = -1478051510;
					continue;
				case 5:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					result = null;
					return false;
				default:
					result = elementMap;
					return true;
				}
				break;
			}
			goto IL_0010;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = gOcKLNtqDSCVlHyLurllgnkHbLHN(elementMapId);
			while (true)
			{
				int num2 = -2111060677;
				while (true)
				{
					switch (num2 ^ -2111060678)
					{
					case 2:
						break;
					case 1:
						if (num >= 0)
						{
							goto IL_0052;
						}
						return false;
					default:
						return true;
					}
					break;
					IL_0052:
					WuChnzPslaUlmRLIBtQjOWdaOdB(elementMapId, num);
					num2 = -2111060678;
				}
			}
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			bool flag = base.DeleteElementMapsWithAction(actionId);
			return flag | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			int count = default(int);
			int num;
			if (elementMap == null)
			{
				if (yqfwPzXnQCcQWmMZOGXrgztArbHI != null)
				{
					count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
					num = -1256506281;
				}
				else
				{
					num = -1256506287;
				}
			}
			else
			{
				num = -1256506282;
			}
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1256506286)
				{
				case 0:
					break;
				case 3:
					return null;
				case 4:
					return elementMap;
				case 2:
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2].rOuBUzbbciWwktcpmiPWpQIKoaAa == elementMapId)
					{
						return yqfwPzXnQCcQWmMZOGXrgztArbHI[num2];
					}
					num2++;
					num = -1256506285;
					continue;
				case 5:
					num2 = 0;
					num = -1256506285;
					continue;
				case 6:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				default:
					if (num2 >= count)
					{
						return null;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -1256506284;
			goto IL_0015;
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, false);
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			int count = default(int);
			int num = default(int);
			int num2;
			if (actionId >= 0)
			{
				ActionElementMap firstElementMapWithAction = base.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
				if (firstElementMapWithAction != null)
				{
					return firstElementMapWithAction;
				}
				count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
				num = 0;
				num2 = 1995445652;
			}
			else
			{
				num2 = 1995445655;
			}
			goto IL_0021;
			IL_001c:
			num2 = 1995445650;
			goto IL_0021;
			IL_0021:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ 0x76F01593)
				{
				case 3:
					break;
				case 2:
					if (actionElementMap._actionId == actionId)
					{
						int num3;
						if (skipDisabledMaps)
						{
							num2 = 1995445653;
							num3 = num2;
						}
						else
						{
							num2 = 1995445654;
							num3 = num2;
						}
						continue;
					}
					goto IL_00d9;
				case 0:
					actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num];
					num2 = 1995445649;
					continue;
				case 6:
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num2 = 1995445654;
						continue;
					}
					goto IL_00d9;
				case 4:
					return null;
				case 7:
					num2 = 1995445659;
					continue;
				case 1:
					return null;
				case 5:
					return actionElementMap;
				default:
					{
						if (num >= count)
						{
							return null;
						}
						goto case 0;
					}
					IL_00d9:
					num++;
					num2 = 1995445659;
					continue;
				}
				break;
			}
			goto IL_001c;
		}

		internal override ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap firstElementMapMatch = base.GetFirstElementMapMatch(P_0, P_1);
			while (true)
			{
				int num = 2030501962;
				while (true)
				{
					switch (num ^ 0x7907004B)
					{
					case 2:
						break;
					case 1:
						if (firstElementMapMatch != null)
						{
							goto IL_002a;
						}
						return VFcDPEChNYCdnDMfCvUAcRHLhZLz(P_0, P_1);
					default:
						return firstElementMapMatch;
					}
					break;
					IL_002a:
					num = 2030501963;
				}
			}
		}

		internal override int GetElementMapMatches(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int elementMapMatches = base.GetElementMapMatches(P_0, P_1, P_2, P_3);
			return elementMapMatches + DawakiFhGlOlQpqerZMuFhTdFcwV(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					switch (-1925819460 ^ -1925819458)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return;
					}
					break;
				}
			}
			base.ClearElementMaps();
			yqfwPzXnQCcQWmMZOGXrgztArbHI.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI != null && index >= 0)
			{
				if (index >= yqfwPzXnQCcQWmMZOGXrgztArbHI.Count)
				{
					num = -1494711463;
					goto IL_0012;
				}
				return yqfwPzXnQCcQWmMZOGXrgztArbHI[index];
			}
			goto IL_005a;
			IL_005a:
			return null;
			IL_0012:
			switch (num ^ -1494711463)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			default:
				goto IL_005a;
			}
			goto IL_000d;
			IL_000d:
			num = -1494711464;
			goto IL_0012;
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = 154069418;
					while (true)
					{
						switch (num ^ 0x92EE9A8)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return EmptyObjects<ActionElementMap>.array;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = 154069417;
					}
				}
			}
			return GetAxisMaps(false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(yqfwPzXnQCcQWmMZOGXrgztArbHI);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					ActionElementMap actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num2];
					int num3;
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						list.Add(actionElementMap);
						num3 = 797687442;
						goto IL_0045;
					}
					goto IL_0085;
					IL_0045:
					while (true)
					{
						switch (num3 ^ 0x2F8BBE92)
						{
						case 3:
							num3 = 797687443;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0085;
						default:
							goto end_IL_0062;
						}
						break;
					}
					continue;
					IL_0085:
					num2++;
					num3 = 797687440;
					goto IL_0045;
					continue;
					end_IL_0062:
					break;
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return boiOCpmNxxXmpsfIFPlkViGmnpy(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
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
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = axisMapCount;
			int num2 = 1402019118;
			goto IL_0021;
			IL_001c:
			num2 = 1402019114;
			goto IL_0021;
			IL_0021:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num6 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			ActionElementMap[] array = default(ActionElementMap[]);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0x53911D2B)
				{
				case 10:
					break;
				case 11:
					if (actionElementMap._actionId != actionId)
					{
						goto case 12;
					}
					if (skipDisabledMaps)
					{
						int num7;
						if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = 1402019111;
							num7 = num2;
						}
						else
						{
							num2 = 1402019113;
							num7 = num2;
						}
						continue;
					}
					goto case 2;
				case 5:
					if (num == 0)
					{
						num2 = 1402019107;
						continue;
					}
					num6 = 0;
					num5 = 0;
					num2 = 1402019112;
					continue;
				case 4:
				{
					ActionElementMap actionElementMap2 = yqfwPzXnQCcQWmMZOGXrgztArbHI[num5];
					if (actionElementMap2._actionId == actionId)
					{
						if (skipDisabledMaps)
						{
							int num8;
							if (!actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num2 = 1402019115;
								num8 = num2;
							}
							else
							{
								num2 = 1402019106;
								num8 = num2;
							}
							continue;
						}
						goto case 9;
					}
					goto case 0;
				}
				case 1:
					return EmptyObjects<ActionElementMap>.array;
				case 9:
					num6++;
					num2 = 1402019115;
					continue;
				case 12:
					num3++;
					num2 = 1402019117;
					continue;
				case 3:
					if (num5 >= num)
					{
						if (num6 == 0)
						{
							return EmptyObjects<ActionElementMap>.array;
						}
						array = new ActionElementMap[num6];
						num4 = 0;
						num3 = 0;
						num2 = 1402019117;
						continue;
					}
					goto case 4;
				case 2:
					array[num4] = actionElementMap;
					num2 = 1402019116;
					continue;
				case 13:
					actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					num2 = 1402019104;
					continue;
				case 7:
					num4++;
					num2 = 1402019111;
					continue;
				case 0:
					num5++;
					num2 = 1402019112;
					continue;
				case 8:
					return EmptyObjects<ActionElementMap>.array;
				default:
					if (num3 >= num)
					{
						return array;
					}
					goto case 13;
				}
				break;
			}
			goto IL_001c;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
				ListTools.TryClear(results);
				num = -382034460;
				goto IL_001e;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
			IL_0019:
			num = -382034457;
			goto IL_001e;
			IL_001e:
			switch (num ^ -382034458)
			{
			case 0:
				break;
			case 1:
				return 0;
			default:
				return 0;
			}
			goto IL_0019;
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return qtmFyJGTaljVfBsctInZuPBEPzzP(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			zdPevVkizUulSZlkMudazHPaSIn zdPevVkizUulSZlkMudazHPaSIn2 = new zdPevVkizUulSZlkMudazHPaSIn(-2);
			zdPevVkizUulSZlkMudazHPaSIn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			zdPevVkizUulSZlkMudazHPaSIn2.EWQVMNaYUmlNevCoyIethJojVez = actionId;
			while (true)
			{
				int num = 2022140178;
				while (true)
				{
					switch (num ^ 0x78876910)
					{
					case 0:
						break;
					case 2:
						goto IL_0034;
					default:
						return zdPevVkizUulSZlkMudazHPaSIn2;
					}
					break;
					IL_0034:
					zdPevVkizUulSZlkMudazHPaSIn2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
					num = 2022140177;
				}
			}
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			int count = default(int);
			int num2 = default(int);
			if (actionId < 0)
			{
				num = 574504870;
			}
			else
			{
				axisMaps = AxisMaps;
				count = axisMaps.Count;
				num2 = 0;
				num = 574504879;
			}
			goto IL_0012;
			IL_000d:
			num = 574504872;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x223E3FAF)
				{
				case 3:
					break;
				case 4:
				{
					int num4;
					if (!skipDisabledMaps)
					{
						num = 574504878;
						num4 = num;
					}
					else
					{
						num = 574504874;
						num4 = num;
					}
					continue;
				}
				case 8:
					if (actionElementMap._actionId == actionId)
					{
						num = 574504875;
						continue;
					}
					goto IL_009b;
				case 7:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				case 5:
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = 574504878;
						continue;
					}
					goto IL_009b;
				case 1:
					return actionElementMap;
				case 9:
					return null;
				case 2:
					actionElementMap = axisMaps[num2];
					num = 574504871;
					continue;
				case 0:
				{
					int num3;
					if (num2 >= count)
					{
						num = 574504873;
						num3 = num;
					}
					else
					{
						num = 574504877;
						num3 = num;
					}
					continue;
				}
				default:
					{
						return null;
					}
					IL_009b:
					num2++;
					num = 574504879;
					continue;
				}
				break;
			}
			goto IL_000d;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int actionId = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return VFcDPEChNYCdnDMfCvUAcRHLhZLz(predicate, false);
		}

		internal ActionElementMap VFcDPEChNYCdnDMfCvUAcRHLhZLz(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0037;
			IL_0003:
			int num = 1989966714;
			goto IL_0008;
			IL_0008:
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			switch (num ^ 0x769C7B7B)
			{
			case 3:
				break;
			case 1:
				throw new ArgumentNullException("predicate");
			case 0:
				goto IL_0037;
			default:
			{
				int num2 = axisMapCount;
				try
				{
					int num3 = 0;
					while (num3 < num2)
					{
						while (true)
						{
							ActionElementMap actionElementMap = axisMaps[num3];
							int num4;
							if (P_1)
							{
								int num5;
								if (actionElementMap.enabled)
								{
									num4 = 1989966712;
									num5 = num4;
								}
								else
								{
									num4 = 1989966719;
									num5 = num4;
								}
								goto IL_0055;
							}
							goto IL_009a;
							IL_009a:
							if (P_0(actionElementMap))
							{
								return actionElementMap;
							}
							goto IL_00af;
							IL_0055:
							while (true)
							{
								switch (num4 ^ 0x769C7B7B)
								{
								case 0:
									num4 = 1989966713;
									continue;
								case 2:
									break;
								case 3:
									goto IL_009a;
								case 4:
									goto IL_00af;
								default:
									goto end_IL_0076;
								}
								break;
							}
							continue;
							IL_00af:
							num3++;
							num4 = 1989966714;
							goto IL_0055;
							continue;
							end_IL_0076:
							break;
						}
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMap.GetFirstAxisMapMatch", exception);
				}
				return null;
			}
			}
			goto IL_0003;
			IL_0037:
			axisMaps = AxisMaps;
			num = 1989966713;
			goto IL_0008;
		}

		public int GetAxisMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			return DawakiFhGlOlQpqerZMuFhTdFcwV(predicate, false, results, false);
		}

		internal int DawakiFhGlOlQpqerZMuFhTdFcwV(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			while (P_2 != null)
			{
				while (true)
				{
					IL_0068:
					int num = 0;
					int num2;
					int num3;
					if (!P_3)
					{
						num2 = -1354163745;
						num3 = num2;
					}
					else
					{
						num2 = -1354163751;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1354163748)
						{
						case 0:
							num2 = -1354163747;
							continue;
						case 1:
							break;
						case 3:
							P_2.Clear();
							num2 = -1354163752;
							continue;
						case 5:
							num = P_2.Count;
							num2 = -1354163752;
							continue;
						case 2:
							goto IL_0068;
						default:
						{
							IList<ActionElementMap> axisMaps = AxisMaps;
							int num4 = axisMapCount;
							try
							{
								int num5 = 0;
								while (num5 < num4)
								{
									while (true)
									{
										ActionElementMap actionElementMap = axisMaps[num5];
										int num6;
										int num7;
										if (P_1)
										{
											num6 = -1354163751;
											num7 = num6;
										}
										else
										{
											num6 = -1354163745;
											num7 = num6;
										}
										while (true)
										{
											switch (num6 ^ -1354163748)
											{
											case 0:
												num6 = -1354163752;
												continue;
											case 1:
												num5++;
												num6 = -1354163750;
												continue;
											case 3:
												break;
											case 2:
												P_2.Add(actionElementMap);
												num6 = -1354163747;
												continue;
											case 5:
												goto IL_00f7;
											case 4:
												goto end_IL_0099;
											default:
												goto end_IL_0111;
											}
											int num8;
											if (P_0(actionElementMap))
											{
												num6 = -1354163746;
												num8 = num6;
											}
											else
											{
												num6 = -1354163747;
												num8 = num6;
											}
											continue;
											IL_00f7:
											int num9;
											if (actionElementMap.enabled)
											{
												num6 = -1354163745;
												num9 = num6;
											}
											else
											{
												num6 = -1354163747;
												num9 = num6;
											}
											continue;
											end_IL_0099:
											break;
										}
										continue;
										end_IL_0111:
										break;
									}
								}
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.GetAxisMapMatches", exception);
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

		public void ForEachAxisMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			try
			{
				int num = 0;
				while (num < count)
				{
					while (true)
					{
						ActionElementMap obj = yqfwPzXnQCcQWmMZOGXrgztArbHI[num];
						int num2;
						if (predicate(obj))
						{
							actionToPerform(obj);
							num2 = -1258441404;
							goto IL_007b;
						}
						goto IL_00bc;
						IL_007b:
						while (true)
						{
							switch (num2 ^ -1258441403)
							{
							case 0:
								num2 = -1258441402;
								continue;
							case 3:
								break;
							case 1:
								goto IL_00bc;
							default:
								goto end_IL_0098;
							}
							break;
						}
						continue;
						IL_00bc:
						num++;
						num2 = -1258441401;
						goto IL_007b;
						continue;
						end_IL_0098:
						break;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachAxisMapMatch", exception);
			}
		}

		public bool DeleteAxisMapsWithAction(string actionName)
		{
			return DeleteAxisMapsWithAction(ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			int num2 = num - 1;
			int num3 = -29595774;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num3 ^ -29595773)
				{
				case 4:
					break;
				case 2:
					num2--;
					num3 = -29595770;
					continue;
				case 1:
					num3 = -29595770;
					continue;
				case 7:
				{
					int num4;
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2] != null)
					{
						num3 = -29595773;
						num4 = num3;
					}
					else
					{
						num3 = -29595775;
						num4 = num3;
					}
					continue;
				}
				case 3:
					result = true;
					num3 = -29595775;
					continue;
				case 0:
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2]._actionId == actionId)
					{
						WuChnzPslaUlmRLIBtQjOWdaOdB(yqfwPzXnQCcQWmMZOGXrgztArbHI[num2].rOuBUzbbciWwktcpmiPWpQIKoaAa, num2);
						num3 = -29595776;
						continue;
					}
					goto case 2;
				case 6:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				default:
					if (num2 < 0)
					{
						return result;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num3 = -29595771;
			goto IL_0015;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num = 0;
			int count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			int num2 = 0;
			int num3 = -1519688974;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num3 ^ -1519688969)
				{
				case 6:
					break;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num3 = -1519688970;
					continue;
				case 1:
					return 0;
				case 3:
					num2++;
					num3 = -1519688974;
					continue;
				case 5:
				{
					int num4;
					if (num2 < count)
					{
						num3 = -1519688973;
						num4 = num3;
					}
					else
					{
						num3 = -1519688969;
						num4 = num3;
					}
					continue;
				}
				case 4:
				{
					ActionElementMap actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num2];
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq != state)
					{
						actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq = state;
						num++;
						num3 = -1519688972;
						continue;
					}
					goto case 3;
				}
				default:
					return num;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num3 = -1519688971;
			goto IL_0012;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(controllerMap, skipDisabledMaps))
			{
				return true;
			}
			ControllerMapWithAxes controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				goto IL_0039;
			}
			int num;
			if (skipDisabledMaps)
			{
				if (!_enabled)
				{
					goto IL_0141;
				}
				if (!controllerMapWithAxes._enabled)
				{
					num = -1561907249;
					goto IL_003e;
				}
			}
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			int count2 = axisMaps.Count;
			int num2 = 0;
			num = -1561907258;
			goto IL_003e;
			IL_003e:
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -1561907249)
				{
				case 4:
					break;
				case 1:
					num2++;
					num = -1561907258;
					continue;
				case 5:
					goto IL_008b;
				case 7:
					goto IL_00a1;
				case 3:
					goto IL_00b1;
				case 11:
					num3 = 0;
					num = -1561907254;
					continue;
				case 10:
					return false;
				case 6:
					goto IL_0103;
				case 2:
					goto IL_0120;
				case 0:
					goto IL_0141;
				case 8:
					goto IL_0179;
				default:
					if (num2 >= count)
					{
						return false;
					}
					goto IL_00b1;
				}
				break;
				IL_0179:
				int num4;
				if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -1561907260;
					num4 = num;
				}
				else
				{
					num = -1561907250;
					num4 = num;
				}
				continue;
				IL_00a1:
				if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = -1561907255;
					continue;
				}
				goto IL_0110;
				IL_00b1:
				actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num2];
				int num5;
				if (!skipDisabledMaps)
				{
					num = -1561907260;
					num5 = num;
				}
				else
				{
					num = -1561907257;
					num5 = num;
				}
				continue;
				IL_0120:
				actionElementMap2 = axisMaps[num3];
				int num6;
				if (skipDisabledMaps)
				{
					num = -1561907256;
					num6 = num;
				}
				else
				{
					num = -1561907255;
					num6 = num;
				}
				continue;
				IL_008b:
				int num7;
				if (num3 >= count2)
				{
					num = -1561907250;
					num7 = num;
				}
				else
				{
					num = -1561907251;
					num7 = num;
				}
				continue;
				IL_0110:
				num3++;
				num = -1561907254;
				continue;
				IL_0103:
				if (actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
				goto IL_0110;
			}
			goto IL_0039;
			IL_0141:
			return false;
			IL_0039:
			num = -1561907259;
			goto IL_003e;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (actionElementMap == null)
			{
				goto IL_0021;
			}
			if (base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
			{
				return true;
			}
			int num;
			if (skipDisabledMaps)
			{
				int num2;
				if (!_enabled)
				{
					num = 1301662132;
					num2 = num;
				}
				else
				{
					num = 1301662133;
					num2 = num;
				}
				goto IL_0026;
			}
			goto IL_00e2;
			IL_0026:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x4D95C9BD)
				{
				case 5:
					break;
				case 0:
					num = 1301662138;
					continue;
				case 2:
					goto IL_0065;
				case 6:
					actionElementMap2 = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					num = 1301662143;
					continue;
				case 4:
					goto IL_008b;
				case 1:
					return false;
				case 8:
					goto IL_00ce;
				case 9:
					return false;
				case 7:
					goto IL_00f8;
				default:
					return false;
				}
				break;
				IL_00f8:
				int num4;
				if (num3 < yqfwPzXnQCcQWmMZOGXrgztArbHI.Count)
				{
					num = 1301662139;
					num4 = num;
				}
				else
				{
					num = 1301662142;
					num4 = num;
				}
				continue;
				IL_0065:
				if (!skipDisabledMaps)
				{
					goto IL_008b;
				}
				if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = 1301662137;
					continue;
				}
				goto IL_0096;
				IL_008b:
				if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
				goto IL_0096;
				IL_00ce:
				if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = 1301662132;
					continue;
				}
				goto IL_00e2;
				IL_0096:
				num3++;
				num = 1301662138;
			}
			goto IL_0021;
			IL_00e2:
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				return false;
			}
			num3 = 0;
			num = 1301662141;
			goto IL_0026;
			IL_0021:
			num = 1301662140;
			goto IL_0026;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (base.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return false;
			}
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num2 = 1840698256;
				while (true)
				{
					switch (num2 ^ 0x6DB6D393)
					{
					case 6:
						break;
					case 1:
						if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
						{
							num2 = 1840698262;
							continue;
						}
						goto IL_00be;
					case 4:
						if (!skipDisabledMaps)
						{
							goto case 1;
						}
						if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = 1840698258;
							continue;
						}
						goto IL_00be;
					case 5:
						return true;
					case 3:
						num2 = 1840698257;
						continue;
					case 0:
						actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num];
						num2 = 1840698263;
						continue;
					default:
						{
							if (num >= yqfwPzXnQCcQWmMZOGXrgztArbHI.Count)
							{
								return false;
							}
							goto case 0;
						}
						IL_00be:
						num++;
						num2 = 1840698257;
						continue;
					}
					break;
				}
			}
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			sQWbzXEkGdibIXVncfeXWXTafzo sQWbzXEkGdibIXVncfeXWXTafzo2 = new sQWbzXEkGdibIXVncfeXWXTafzo(-2);
			sQWbzXEkGdibIXVncfeXWXTafzo2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			sQWbzXEkGdibIXVncfeXWXTafzo2.AkCCOPqWBDIoelQfBDGjGqsxrCK = controllerMap;
			sQWbzXEkGdibIXVncfeXWXTafzo2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return sQWbzXEkGdibIXVncfeXWXTafzo2;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			koxDDKYInYIhczXgwjNsuJStJvR koxDDKYInYIhczXgwjNsuJStJvR2 = new koxDDKYInYIhczXgwjNsuJStJvR(-2);
			koxDDKYInYIhczXgwjNsuJStJvR2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			koxDDKYInYIhczXgwjNsuJStJvR2.WfePqZKTzLLSOkMcfaksZhTkOHF = actionElementMap;
			koxDDKYInYIhczXgwjNsuJStJvR2.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return koxDDKYInYIhczXgwjNsuJStJvR2;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			TYSGWCaCnadqFmPowvJgauBUrte tYSGWCaCnadqFmPowvJgauBUrte = new TYSGWCaCnadqFmPowvJgauBUrte(-2);
			tYSGWCaCnadqFmPowvJgauBUrte.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			tYSGWCaCnadqFmPowvJgauBUrte.zmNiuGMQtlBlHidAStqiwbddGtbg = conflictCheck;
			tYSGWCaCnadqFmPowvJgauBUrte.pBwzwenOfAhpelzwewTaMxzWsmu = skipDisabledMaps;
			return tYSGWCaCnadqFmPowvJgauBUrte;
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			int num2 = -493454778;
			goto IL_001e;
			IL_0019:
			num2 = -493454775;
			goto IL_001e;
			IL_001e:
			ActionElementMap actionElementMap = default(ActionElementMap);
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			int num4 = default(int);
			int count = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num3 = default(int);
			ControllerMapWithAxes controllerMapWithAxes = default(ControllerMapWithAxes);
			while (true)
			{
				switch (num2 ^ -493454769)
				{
				case 8:
					break;
				case 6:
					return 0;
				case 3:
					return num;
				case 1:
					actionElementMap = axisMaps[num4];
					if (skipDisabledMaps)
					{
						int num5;
						if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = -493454774;
							num5 = num2;
						}
						else
						{
							num2 = -493454782;
							num5 = num2;
						}
						continue;
					}
					goto case 13;
				case 4:
				{
					if (axisMaps == null)
					{
						return num;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
					if (mapCategory != null && !mapCategory.userAssignable)
					{
						return num;
					}
					int count2 = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
					count = axisMaps.Count;
					num2 = -493454779;
					continue;
				}
				case 0:
					if (skipDisabledMaps)
					{
						int num6;
						if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = -493454784;
							num6 = num2;
						}
						else
						{
							num2 = -493454771;
							num6 = num2;
						}
						continue;
					}
					goto case 15;
				case 5:
					num4++;
					num2 = -493454781;
					continue;
				case 7:
					actionElementMap2 = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					num2 = -493454769;
					continue;
				case 13:
					if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
					{
						WuChnzPslaUlmRLIBtQjOWdaOdB(actionElementMap2.rOuBUzbbciWwktcpmiPWpQIKoaAa, num3);
						num++;
						num2 = -493454771;
						continue;
					}
					goto case 5;
				case 12:
				{
					int num7;
					if (num4 >= count)
					{
						num2 = -493454771;
						num7 = num2;
					}
					else
					{
						num2 = -493454770;
						num7 = num2;
					}
					continue;
				}
				case 10:
					num3 = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count - 1;
					num2 = -493454780;
					continue;
				case 2:
					num3--;
					num2 = -493454780;
					continue;
				case 9:
					controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
					num2 = -493454783;
					continue;
				case 15:
					num4 = 0;
					num2 = -493454781;
					continue;
				case 14:
					if (controllerMapWithAxes == null)
					{
						return num;
					}
					if (skipDisabledMaps)
					{
						if (!_enabled)
						{
							goto case 3;
						}
						if (!controllerMapWithAxes._enabled)
						{
							num2 = -493454772;
							continue;
						}
					}
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
					{
						return num;
					}
					axisMaps = controllerMapWithAxes.AxisMaps;
					num2 = -493454773;
					continue;
				default:
					if (num3 < 0)
					{
						return num;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0019;
		}

		public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
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
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			int num3 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				int num2 = -919530801;
				while (true)
				{
					InputMapCategory mapCategory;
					switch (num2 ^ -919530807)
					{
					case 0:
						break;
					case 2:
						return num;
					case 3:
						return num;
					case 8:
						num3--;
						num2 = -919530802;
						continue;
					case 5:
						if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = -919530805;
							continue;
						}
						goto IL_0068;
					case 1:
						return num;
					case 9:
						actionElementMap2 = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
						if (skipDisabledMaps)
						{
							int num5;
							if (!actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num2 = -919530815;
								num5 = num2;
							}
							else
							{
								num2 = -919530803;
								num5 = num2;
							}
							continue;
						}
						goto case 4;
					case 6:
						if (skipDisabledMaps)
						{
							int num4;
							if (!_enabled)
							{
								num2 = -919530805;
								num4 = num2;
							}
							else
							{
								num2 = -919530804;
								num4 = num2;
							}
							continue;
						}
						goto IL_0068;
					case 4:
						if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
						{
							WuChnzPslaUlmRLIBtQjOWdaOdB(actionElementMap2.rOuBUzbbciWwktcpmiPWpQIKoaAa, num3);
							num++;
							num2 = -919530815;
							continue;
						}
						goto case 8;
					default:
						{
							if (num3 < 0)
							{
								return num;
							}
							goto case 9;
						}
						IL_0068:
						mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
						if (mapCategory == null)
						{
							num2 = -919530808;
							continue;
						}
						if (!mapCategory.userAssignable)
						{
							return num;
						}
						if (yqfwPzXnQCcQWmMZOGXrgztArbHI != null)
						{
							num3 = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count - 1;
							num2 = -919530802;
						}
						else
						{
							num2 = -919530806;
						}
						continue;
					}
					break;
				}
			}
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				goto IL_0035;
			}
			int num2;
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num3 = default(int);
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				num2 = 1186406059;
			}
			else
			{
				if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
				{
					return num;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory == null)
				{
					num2 = 1186406054;
				}
				else
				{
					if (!mapCategory.userAssignable)
					{
						return num;
					}
					elementAssignment = conflictCheck.ToElementAssignment();
					num3 = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count - 1;
					num2 = 1186406050;
				}
			}
			goto IL_003a;
			IL_0035:
			num2 = 1186406057;
			goto IL_003a;
			IL_003a:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ 0x46B71EA1)
				{
				case 0:
					break;
				case 1:
					actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					if (skipDisabledMaps)
					{
						int num4;
						if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = 1186406056;
							num4 = num2;
						}
						else
						{
							num2 = 1186406051;
							num4 = num2;
						}
						continue;
					}
					goto case 9;
				case 2:
					num3--;
					num2 = 1186406053;
					continue;
				case 3:
					num2 = 1186406053;
					continue;
				case 6:
					if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						WuChnzPslaUlmRLIBtQjOWdaOdB(actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa, num3);
						num2 = 1186406052;
						continue;
					}
					goto case 2;
				case 8:
					return num;
				case 5:
					num++;
					num2 = 1186406051;
					continue;
				case 9:
				{
					int num5;
					if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa == conflictCheck.elementMapId)
					{
						num2 = 1186406051;
						num5 = num2;
					}
					else
					{
						num2 = 1186406055;
						num5 = num2;
					}
					continue;
				}
				case 10:
					return num;
				case 7:
					return num;
				default:
					if (num3 < 0)
					{
						return num;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0035;
		}

		internal override int DisableElementAssignmentConflicts(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.DisableElementAssignmentConflicts(P_0, P_1, P_2, P_3);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num3 = default(int);
			ControllerMapWithAxes controllerMapWithAxes = default(ControllerMapWithAxes);
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			int count = default(int);
			int count2 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = -1590510704;
				while (true)
				{
					switch (num2 ^ -1590510703)
					{
					case 7:
						break;
					case 10:
						if (actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							actionElementMap.enabled = false;
							if (P_2 != null)
							{
								P_2.Add(actionElementMap);
								num2 = -1590510691;
								continue;
							}
							goto case 12;
						}
						goto case 15;
					case 13:
						num3++;
						num2 = -1590510695;
						continue;
					case 2:
						if (!controllerMapWithAxes._enabled)
						{
							num2 = -1590510718;
							continue;
						}
						goto IL_016a;
					case 11:
						return num;
					case 6:
						return num;
					case 14:
						return num;
					case 0:
					{
						int num8;
						if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = -1590510692;
							num8 = num2;
						}
						else
						{
							num2 = -1590510717;
							num8 = num2;
						}
						continue;
					}
					case 9:
						if (controllerMapWithAxes != null)
						{
							if (P_1)
							{
								int num4;
								if (_enabled)
								{
									num2 = -1590510701;
									num4 = num2;
								}
								else
								{
									num2 = -1590510718;
									num4 = num2;
								}
								continue;
							}
							goto IL_016a;
						}
						num2 = -1590510697;
						continue;
					case 5:
						if (axisMaps != null)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
							if (mapCategory == null || mapCategory.userAssignable)
							{
								count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
								count2 = axisMaps.Count;
								num3 = 0;
								num2 = -1590510699;
							}
							else
							{
								num2 = -1590510694;
							}
						}
						else
						{
							num2 = -1590510689;
						}
						continue;
					case 19:
						return num;
					case 12:
						num++;
						num2 = -1590510692;
						continue;
					case 15:
						num5++;
						num2 = -1590510720;
						continue;
					case 16:
						actionElementMap2 = axisMaps[num5];
						if (P_1)
						{
							int num7;
							if (actionElementMap2.PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num2 = -1590510693;
								num7 = num2;
							}
							else
							{
								num2 = -1590510690;
								num7 = num2;
							}
							continue;
						}
						goto case 10;
					case 4:
						num2 = -1590510695;
						continue;
					case 1:
						controllerMapWithAxes = P_0 as ControllerMapWithAxes;
						num2 = -1590510696;
						continue;
					case 17:
					{
						int num6;
						if (num5 < count2)
						{
							num2 = -1590510719;
							num6 = num2;
						}
						else
						{
							num2 = -1590510692;
							num6 = num2;
						}
						continue;
					}
					case 3:
						actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
						num2 = -1590510703;
						continue;
					case 18:
						num5 = 0;
						num2 = -1590510720;
						continue;
					default:
						{
							if (num3 >= count)
							{
								return num;
							}
							goto case 3;
						}
						IL_016a:
						if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
						{
							return num;
						}
						axisMaps = controllerMapWithAxes.AxisMaps;
						num2 = -1590510700;
						continue;
					}
					break;
				}
			}
		}

		internal override int DisableElementAssignmentConflicts(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.DisableElementAssignmentConflicts(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1)
			{
				if (_enabled)
				{
					goto IL_001c;
				}
				goto IL_007d;
			}
			goto IL_007f;
			IL_007f:
			if (P_0.elementIdentifierId < 0)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = axisMapCount;
			int num3 = 0;
			int num4 = 914897280;
			goto IL_0021;
			IL_007d:
			return num;
			IL_001c:
			num4 = 914897292;
			goto IL_0021;
			IL_0021:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num4 ^ 0x36883985)
				{
				case 3:
					break;
				case 9:
					goto IL_0059;
				case 7:
					if (P_2 != null)
					{
						P_2.Add(actionElementMap);
						num4 = 914897283;
						continue;
					}
					goto case 6;
				case 4:
					goto IL_007d;
				case 8:
					num3++;
					num4 = 914897285;
					continue;
				case 5:
					num4 = 914897285;
					continue;
				case 1:
					actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq && P_0.CheckForAssignmentConflict(actionElementMap))
					{
						actionElementMap.enabled = false;
						num4 = 914897282;
						continue;
					}
					goto case 8;
				case 6:
					num++;
					num4 = 914897293;
					continue;
				case 0:
					goto IL_0116;
				default:
					return num;
				}
				break;
				IL_0116:
				int num5;
				if (num3 >= num2)
				{
					num4 = 914897287;
					num5 = num4;
				}
				else
				{
					num4 = 914897284;
					num5 = num4;
				}
				continue;
				IL_0059:
				if (!P_0.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num4 = 914897281;
					continue;
				}
				goto IL_007f;
			}
			goto IL_001c;
		}

		internal override int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.DisableElementAssignmentConflicts(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				goto IL_0021;
			}
			int num2;
			if (P_0.elementAssignmentType != ElementAssignmentType.FullAxis)
			{
				num2 = 358342693;
				goto IL_0026;
			}
			goto IL_00c3;
			IL_0026:
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ElementAssignment elementAssignment = default(ElementAssignment);
			int count = default(int);
			while (true)
			{
				switch (num2 ^ 0x155BE027)
				{
				case 3:
					break;
				case 1:
					return num;
				case 7:
					num++;
					num2 = 358342690;
					continue;
				case 5:
					num3++;
					num2 = 358342689;
					continue;
				case 0:
					if (actionElementMap.rOuBUzbbciWwktcpmiPWpQIKoaAa != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						actionElementMap.enabled = false;
						if (P_2 != null)
						{
							P_2.Add(actionElementMap);
							num2 = 358342688;
							continue;
						}
						goto case 7;
					}
					goto case 5;
				case 2:
					goto IL_00b7;
				case 4:
					goto IL_0104;
				default:
					if (num3 >= count)
					{
						return num;
					}
					goto IL_0104;
				}
				break;
				IL_0104:
				actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
				int num4;
				if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num2 = 358342690;
					num4 = num2;
				}
				else
				{
					num2 = 358342695;
					num4 = num2;
				}
			}
			goto IL_0021;
			IL_0021:
			num2 = 358342694;
			goto IL_0026;
			IL_00c3:
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			elementAssignment = P_0.ToElementAssignment();
			count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			num3 = 0;
			num2 = 358342689;
			goto IL_0026;
			IL_00b7:
			if (P_0.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			goto IL_00c3;
		}

		public string[] GetAxisNames()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num = axisMapCount;
			int num2;
			string[] array = default(string[]);
			int num3 = default(int);
			if (num == 0)
			{
				num2 = -774618387;
			}
			else
			{
				array = new string[num];
				num3 = 0;
				num2 = -774618391;
			}
			goto IL_001e;
			IL_0019:
			num2 = -774618392;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ -774618391)
				{
				case 2:
					break;
				case 1:
					return EmptyObjects<string>.array;
				case 4:
					return null;
				case 0:
				{
					int num4;
					if (num3 >= num)
					{
						num2 = -774618388;
						num4 = num2;
					}
					else
					{
						num2 = -774618390;
						num4 = num2;
					}
					continue;
				}
				case 3:
					array[num3] = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3].ccLqwqerDNLPbYOQRmZkNRvlnZD;
					num3++;
					num2 = -774618391;
					continue;
				default:
					return array;
				}
				break;
			}
			goto IL_0019;
		}

		internal override bool AddActionMapping_BeforeBake(ActionElementMap P_0)
		{
			if (base.AddActionMapping_BeforeBake(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			while (true)
			{
				int num = -1775800945;
				while (true)
				{
					switch (num ^ -1775800946)
					{
					case 0:
						break;
					case 1:
						if (!NazMgzUnvggfOsDycmqIQvTPcxX(elementType))
						{
							goto IL_0039;
						}
						wEjrXWgpPemJWXOxgnwHNSDxUZx(P_0);
						return true;
					default:
						return false;
					}
					break;
					IL_0039:
					num = -1775800948;
				}
			}
		}

		internal override int GetElementMaps_Append(List<ActionElementMap> P_0, bool P_1)
		{
			base.GetElementMaps_Append(P_0, P_1);
			int count = P_0.Count;
			int count2 = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			int num = 0;
			while (num < count2)
			{
				while (true)
				{
					IL_006a:
					int num2;
					if (P_1)
					{
						int num3;
						if (!yqfwPzXnQCcQWmMZOGXrgztArbHI[num].PAfqntGWZaNgzmZFIOyQPuJGOCq)
						{
							num2 = 610125232;
							num3 = num2;
						}
						else
						{
							num2 = 610125239;
							num3 = num2;
						}
						goto IL_0025;
					}
					goto IL_0051;
					IL_0025:
					while (true)
					{
						switch (num2 ^ 0x245DC5B3)
						{
						case 0:
							num2 = 610125234;
							continue;
						case 3:
							num++;
							num2 = 610125233;
							continue;
						case 4:
							break;
						case 1:
							goto IL_006a;
						default:
							goto end_IL_006a;
						}
						break;
					}
					goto IL_0051;
					IL_0051:
					P_0.Add(yqfwPzXnQCcQWmMZOGXrgztArbHI[num]);
					num2 = 610125232;
					goto IL_0025;
					continue;
					end_IL_006a:
					break;
				}
			}
			return P_0.Count - count;
		}

		internal override ActionElementMap GetFirstElementMapWithMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap firstElementMapWithMapping = base.GetFirstElementMapWithMapping(P_0, P_1, P_2);
			if (firstElementMapWithMapping != null)
			{
				return firstElementMapWithMapping;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_2))
			{
				return null;
			}
			int num = FirstIndexOfElementMapping(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return yqfwPzXnQCcQWmMZOGXrgztArbHI[num];
			}
			throw new NotImplementedException();
		}

		internal override int GetElementMapsWithElementIdentifier(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num;
			while (true)
			{
				num = (P_2 ? P_1.Count : 0);
				base.GetElementMapsWithElementIdentifier(P_0, P_1, P_2);
				if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
				{
					break;
				}
				int count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
				int num2 = 0;
				int num3 = 1457473823;
				while (true)
				{
					switch (num3 ^ 0x56DF491F)
					{
					case 2:
						num3 = 1457473822;
						continue;
					case 4:
						num2++;
						num3 = 1457473823;
						continue;
					case 3:
						if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2]._elementIdentifierId == P_0)
						{
							P_1.Add(yqfwPzXnQCcQWmMZOGXrgztArbHI[num2]);
							num3 = 1457473819;
							continue;
						}
						goto case 4;
					case 1:
						break;
					default:
						if (num2 >= count)
						{
							return P_1.Count - num;
						}
						goto case 3;
					}
					break;
				}
			}
			return P_1.Count - num;
		}

		internal override bool ContainsElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.ContainsElementMapping(P_0, P_1, P_2))
			{
				return true;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_2))
			{
				goto IL_0016;
			}
			int count = default(int);
			int num;
			if (P_2 == ControllerElementType.Axis)
			{
				count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
				num = -290746772;
				goto IL_001b;
			}
			goto IL_0044;
			IL_001b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -290746769)
				{
				case 0:
					break;
				case 5:
					goto IL_0044;
				case 1:
					goto IL_0051;
				case 3:
					num2 = 0;
					num = -290746771;
					continue;
				case 4:
					return false;
				case 2:
					if (num2 >= count)
					{
						num = -290746775;
						continue;
					}
					goto IL_0051;
				default:
					return false;
				}
				break;
				IL_0051:
				if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2]._elementIdentifierId == P_0 && yqfwPzXnQCcQWmMZOGXrgztArbHI[num2]._actionId == P_1)
				{
					return true;
				}
				num2++;
				num = -290746771;
			}
			goto IL_0016;
			IL_0016:
			num = -290746773;
			goto IL_001b;
			IL_0044:
			throw new NotImplementedException();
		}

		internal override int FirstIndexOfElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.FirstIndexOfElementMapping(P_0, P_1, P_2);
			if (num >= 0)
			{
				goto IL_0011;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_2))
			{
				return -1;
			}
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				return -1;
			}
			int count = default(int);
			int num2;
			if (P_2 == ControllerElementType.Axis)
			{
				count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
				num2 = 74861605;
				goto IL_0016;
			}
			goto IL_00e9;
			IL_00e9:
			throw new NotImplementedException();
			IL_0011:
			num2 = 74861602;
			goto IL_0016;
			IL_0016:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x4764C21)
				{
				case 6:
					break;
				case 8:
					return num3;
				case 0:
					goto IL_005b;
				case 4:
					num3 = 0;
					num2 = 74861600;
					continue;
				case 1:
					num2 = 74861601;
					continue;
				case 7:
					num2 = 74861603;
					continue;
				case 5:
					goto IL_0087;
				case 3:
					return num;
				case 9:
					goto IL_00e9;
				default:
					return -1;
				}
				break;
				IL_0087:
				if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3]._elementIdentifierId != P_0 || yqfwPzXnQCcQWmMZOGXrgztArbHI[num3]._actionId != P_1)
				{
					num3++;
					num2 = 74861601;
				}
				else
				{
					num2 = 74861609;
				}
				continue;
				IL_005b:
				int num4;
				if (num3 < count)
				{
					num2 = 74861604;
					num4 = num2;
				}
				else
				{
					num2 = 74861606;
					num4 = num2;
				}
			}
			goto IL_0011;
		}

		internal int gOcKLNtqDSCVlHyLurllgnkHbLHN(int P_0)
		{
			if (yqfwPzXnQCcQWmMZOGXrgztArbHI == null)
			{
				goto IL_0008;
			}
			int count = yqfwPzXnQCcQWmMZOGXrgztArbHI.Count;
			int num = -1909854349;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1909854352)
				{
				case 4:
					break;
				case 5:
					return -1;
				case 2:
					num = -1909854351;
					continue;
				case 3:
					num2 = 0;
					num = -1909854350;
					continue;
				case 0:
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2].rOuBUzbbciWwktcpmiPWpQIKoaAa == P_0)
					{
						return num2;
					}
					num2++;
					num = -1909854351;
					continue;
				default:
					if (num2 >= count)
					{
						return -1;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = -1909854347;
			goto IL_000d;
		}

		internal int boiOCpmNxxXmpsfIFPlkViGmnpy(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num4 = default(int);
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			while (true)
			{
				IL_00ea:
				int num;
				if (!P_2)
				{
					P_1.Clear();
					num = -670039378;
					goto IL_0016;
				}
				goto IL_005f;
				IL_0016:
				while (true)
				{
					switch (num ^ -670039383)
					{
					case 0:
						num = -670039377;
						continue;
					case 5:
						num4 = 0;
						num = -670039379;
						continue;
					case 7:
						break;
					case 3:
						num4++;
						num = -670039391;
						continue;
					case 10:
						goto IL_0078;
					case 8:
						num2++;
						num = -670039390;
						continue;
					case 2:
						actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num2];
						num = -670039389;
						continue;
					case 1:
						goto IL_00b1;
					case 4:
						num2 = 0;
						num = -670039390;
						continue;
					case 9:
						P_1.Add(actionElementMap);
						num = -670039382;
						continue;
					case 6:
						goto IL_00ea;
					default:
						if (num2 >= num3)
						{
							return num4;
						}
						goto case 2;
					}
					break;
					IL_00b1:
					int num5;
					if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = -670039391;
						num5 = num;
					}
					else
					{
						num = -670039392;
						num5 = num;
					}
					continue;
					IL_0078:
					int num6;
					if (P_0)
					{
						num = -670039384;
						num6 = num;
					}
					else
					{
						num = -670039392;
						num6 = num;
					}
				}
				goto IL_005f;
				IL_005f:
				num3 = axisMapCount;
				num = -670039380;
				goto IL_0016;
			}
		}

		internal int qtmFyJGTaljVfBsctInZuPBEPzzP(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				goto IL_0003;
			}
			goto IL_007e;
			IL_0003:
			int num = 165148161;
			goto IL_0008;
			IL_0008:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x9D7F600)
				{
				case 3:
					break;
				case 4:
					P_2.Add(actionElementMap);
					num = 165148165;
					continue;
				case 7:
					goto IL_004e;
				case 8:
					P_2.Clear();
					num = 165148167;
					continue;
				case 5:
					num4++;
					num = 165148160;
					continue;
				case 9:
					goto IL_007e;
				case 1:
					throw new ArgumentNullException("results");
				case 0:
					num2++;
					num = 165148166;
					continue;
				case 2:
					actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num2];
					if (actionElementMap._actionId != P_0)
					{
						goto case 0;
					}
					if (!P_1)
					{
						goto case 4;
					}
					goto IL_00d5;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto case 2;
				}
				break;
				IL_00d5:
				int num5;
				if (actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = 165148164;
					num5 = num;
				}
				else
				{
					num = 165148160;
					num5 = num;
				}
				continue;
				IL_004e:
				if (P_0 < 0)
				{
					return 0;
				}
				num3 = axisMapCount;
				num4 = 0;
				num2 = 0;
				num = 165148166;
			}
			goto IL_0003;
			IL_007e:
			int num6;
			if (!P_3)
			{
				num = 165148168;
				num6 = num;
			}
			else
			{
				num = 165148167;
				num6 = num;
			}
			goto IL_0008;
		}

		internal override int GetElementMapsWithAction(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.GetElementMapsWithAction(P_0, P_1, P_2, P_3);
			if (!P_3)
			{
				P_2.Clear();
				goto IL_0016;
			}
			goto IL_0082;
			IL_0082:
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			int num3 = 0;
			int num4 = 1118109039;
			goto IL_001b;
			IL_0016:
			num4 = 1118109034;
			goto IL_001b;
			IL_001b:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num4 ^ 0x42A4FD6C)
				{
				case 7:
					break;
				case 4:
					if (actionElementMap._actionId == P_0)
					{
						if (P_1)
						{
							goto IL_0057;
						}
						goto case 5;
					}
					goto case 1;
				case 5:
					P_2.Add(actionElementMap);
					num++;
					num4 = 1118109037;
					continue;
				case 6:
					goto IL_0082;
				case 3:
					goto IL_0098;
				case 1:
					num3++;
					num4 = 1118109039;
					continue;
				case 2:
					actionElementMap = yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					num4 = 1118109032;
					continue;
				default:
					return num;
				}
				break;
				IL_0098:
				int num5;
				if (num3 >= num2)
				{
					num4 = 1118109036;
					num5 = num4;
				}
				else
				{
					num4 = 1118109038;
					num5 = num4;
				}
				continue;
				IL_0057:
				int num6;
				if (!actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num4 = 1118109037;
					num6 = num4;
				}
				else
				{
					num4 = 1118109033;
					num6 = num4;
				}
			}
			goto IL_0016;
		}

		internal override ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap firstElementMapWithElementTarget = base.GetFirstElementMapWithElementTarget(P_0, P_1, P_2, P_3, out P_4);
			if (firstElementMapWithElementTarget != null)
			{
				return firstElementMapWithElementTarget;
			}
			if (P_4)
			{
				goto IL_0018;
			}
			int num;
			int num2 = default(int);
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0.elementType))
			{
				num = -1190507540;
			}
			else
			{
				num2 = axisMapCount;
				num = -1190507541;
			}
			goto IL_001d;
			IL_001d:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1190507543)
				{
				case 0:
					break;
				case 1:
					return null;
				case 4:
					if (!P_3)
					{
						goto case 8;
					}
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3].PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						num = -1190507551;
						continue;
					}
					goto IL_00db;
				case 2:
				{
					int elementIdentifierId = P_0.elementIdentifierId;
					num3 = 0;
					num = -1190507537;
					continue;
				}
				case 7:
					if (!P_1)
					{
						goto case 4;
					}
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3]._actionId == P_2)
					{
						num = -1190507539;
						continue;
					}
					goto IL_00db;
				case 8:
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3].IsTarget(P_0))
					{
						return yqfwPzXnQCcQWmMZOGXrgztArbHI[num3];
					}
					goto IL_00db;
				case 5:
					return null;
				case 6:
					num = -1190507542;
					continue;
				default:
					{
						if (num3 >= num2)
						{
							return null;
						}
						goto case 7;
					}
					IL_00db:
					num3++;
					num = -1190507542;
					continue;
				}
				break;
			}
			goto IL_0018;
			IL_0018:
			num = -1190507544;
			goto IL_001d;
		}

		internal override int GetElementMapsWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.GetElementMapsWithElementTarget(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			int elementIdentifierId = P_0.elementIdentifierId;
			int num3 = 0;
			while (num3 < num2)
			{
				while (true)
				{
					int num4;
					int num5;
					if (P_1)
					{
						num4 = -390342697;
						num5 = num4;
					}
					else
					{
						num4 = -390342702;
						num5 = num4;
					}
					while (true)
					{
						switch (num4 ^ -390342700)
						{
						case 7:
							num4 = -390342704;
							continue;
						case 1:
							num3++;
							num4 = -390342703;
							continue;
						case 3:
							break;
						case 0:
							P_4.Add(yqfwPzXnQCcQWmMZOGXrgztArbHI[num3]);
							num++;
							num4 = -390342699;
							continue;
						case 4:
							goto end_IL_0043;
						case 6:
							goto IL_00d8;
						case 2:
							goto IL_0103;
						default:
							goto end_IL_00c1;
						}
						int num6;
						if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3]._actionId == P_2)
						{
							num4 = -390342702;
							num6 = num4;
						}
						else
						{
							num4 = -390342699;
							num6 = num4;
						}
						continue;
						IL_00d8:
						if (P_3)
						{
							int num7;
							if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3].PAfqntGWZaNgzmZFIOyQPuJGOCq)
							{
								num4 = -390342698;
								num7 = num4;
							}
							else
							{
								num4 = -390342699;
								num7 = num4;
							}
							continue;
						}
						goto IL_0103;
						IL_0103:
						int num8;
						if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num3].IsTarget(P_0))
						{
							num4 = -390342700;
							num8 = num4;
						}
						else
						{
							num4 = -390342699;
							num8 = num4;
						}
						continue;
						end_IL_0043:
						break;
					}
					continue;
					end_IL_00c1:
					break;
				}
			}
			return num;
		}

		internal override bool AddElementMap(ActionElementMap P_0)
		{
			if (base.AddElementMap(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!NazMgzUnvggfOsDycmqIQvTPcxX(P_0._elementType))
			{
				goto IL_001e;
			}
			yqfwPzXnQCcQWmMZOGXrgztArbHI.Add(P_0);
			int num = 539513166;
			goto IL_0023;
			IL_001e:
			num = 539513165;
			goto IL_0023;
			IL_0023:
			switch (num ^ 0x2028514F)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				ZXTTERTmYRGjWpTQPsXGmIFjEPp(P_0);
				return true;
			}
			goto IL_001e;
		}

		private bool NazMgzUnvggfOsDycmqIQvTPcxX(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void WuChnzPslaUlmRLIBtQjOWdaOdB(int P_0, int P_1)
		{
			BDKELfBOvrxXEfPJDRLKPineuSg(P_0);
			if (P_1 < 0)
			{
				return;
			}
			if (P_1 >= axisMapCount)
			{
				while (true)
				{
					switch (-855123862 ^ -855123864)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			yqfwPzXnQCcQWmMZOGXrgztArbHI.RemoveAt(P_1);
		}

		private void wEjrXWgpPemJWXOxgnwHNSDxUZx(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				yqfwPzXnQCcQWmMZOGXrgztArbHI.Add(P_0);
				int num = -923969137;
				while (true)
				{
					switch (num ^ -923969139)
					{
					case 3:
						num = -923969140;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						ZXTTERTmYRGjWpTQPsXGmIFjEPp(P_0);
						num = -923969139;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void xJtYdZcTbSEuApASrEoAbIMLioT(ActionElementMap P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (P_1 >= 0)
			{
				int num;
				int num2;
				if (P_1 < axisMapCount)
				{
					num = -1927181160;
					num2 = num;
				}
				else
				{
					num = -1927181158;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1927181157)
					{
					case 0:
						goto IL_0004;
					case 2:
						break;
					case 1:
						return;
					default:
						OQtybPohmoGLTDDnhoDUJwrkECF(yqfwPzXnQCcQWmMZOGXrgztArbHI[P_1].rOuBUzbbciWwktcpmiPWpQIKoaAa, P_0);
						yqfwPzXnQCcQWmMZOGXrgztArbHI[P_1] = P_0;
						return;
					}
					break;
					IL_0004:
					num = -1927181159;
				}
			}
		}

		internal override void ExportDataToSerializedObject(SerializedObject P_0)
		{
			base.ExportDataToSerializedObject(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					int num3;
					if (yqfwPzXnQCcQWmMZOGXrgztArbHI[num2] != null)
					{
						list.Add(yqfwPzXnQCcQWmMZOGXrgztArbHI[num2].wGWQXZtIQyRkZMrIKWqTSlWZlQY());
						num3 = -715178928;
						goto IL_002a;
					}
					goto IL_0073;
					IL_002a:
					while (true)
					{
						switch (num3 ^ -715178927)
						{
						case 3:
							num3 = -715178925;
							continue;
						case 2:
							break;
						case 1:
							goto IL_0073;
						default:
							goto end_IL_0047;
						}
						break;
					}
					continue;
					IL_0073:
					num2++;
					num3 = -715178927;
					goto IL_002a;
					continue;
					end_IL_0047:
					break;
				}
			}
		}

		internal override bool Import(SerializedObject P_0)
		{
			bool flag = base.Import(P_0);
			if (!flag)
			{
				goto IL_000e;
			}
			goto IL_00f7;
			IL_000e:
			int num = 489973743;
			goto IL_0013;
			IL_0013:
			ActionElementMap actionElementMap = default(ActionElementMap);
			SerializedObject value = default(SerializedObject);
			int num2 = default(int);
			SerializedObject value2 = default(SerializedObject);
			while (true)
			{
				switch (num ^ 0x1D3467E8)
				{
				case 5:
					break;
				case 3:
					actionElementMap = new ActionElementMap();
					actionElementMap.DzhGtommJNlpRFKUAFaKGOCHKTz(value);
					num = 489973738;
					continue;
				case 6:
					num2++;
					num = 489973736;
					continue;
				case 0:
					goto IL_0070;
				case 2:
					if (ActionElementMap.lrnrCzJkUCjDHPoqSOHzRASvAkAd(actionElementMap))
					{
						wEjrXWgpPemJWXOxgnwHNSDxUZx(actionElementMap);
						num = 489973742;
						continue;
					}
					goto case 6;
				case 7:
					ClearElementMaps();
					flag = true;
					num = 489973740;
					continue;
				case 9:
					goto IL_00b7;
				case 10:
					goto IL_00ce;
				case 8:
					num = 489973736;
					continue;
				case 4:
					goto IL_00f7;
				default:
					goto IL_0117;
				}
				break;
				IL_00ce:
				int num3;
				if (!value2.TryGetDeserializedValue<SerializedObject>(num2, out value))
				{
					num = 489973729;
					num3 = num;
				}
				else
				{
					num = 489973739;
					num3 = num;
				}
				continue;
				IL_00b7:
				int num4;
				if (value == null)
				{
					num = 489973739;
					num4 = num;
				}
				else
				{
					num = 489973742;
					num4 = num;
				}
				continue;
				IL_0070:
				int num5;
				if (num2 >= value2.count)
				{
					num = 489973737;
					num5 = num;
				}
				else
				{
					num = 489973730;
					num5 = num;
				}
			}
			goto IL_000e;
			IL_00f7:
			value2 = null;
			if (P_0.TryGetDeserializedValueByRef("axisMaps", ref value2) && value2 != null)
			{
				num2 = 0;
				num = 489973728;
				goto IL_0013;
			}
			goto IL_0117;
			IL_0117:
			return flag;
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> kWWSEXIbsAXQwoIrDotZJbIXYCf(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> HzMRlhjcLPWkeqEOMcYNBjNvhmFi(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> DAnVRsqqDqWmOcgGbTEBnLkHiGp(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
