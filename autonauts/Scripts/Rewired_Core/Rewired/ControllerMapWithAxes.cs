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
		private sealed class YEJowMMJlEvMlpwhaVziQJPgIJm : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMapWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int hDvAMaTqLegLZzPsyeYTryTcCaC;

			public int lMvQGEdGoYKDXnJUDIpWwVzOVi;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public ActionElementMap ZuLBcXCEqWtvGQDcuwvoWKBgAfjG;

			public IEnumerator<ActionElementMap> rNBGCwPCdUcwWCwIlQihKhDwFEGs;

			ActionElementMap IEnumerator<ActionElementMap>.Current
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				YEJowMMJlEvMlpwhaVziQJPgIJm yEJowMMJlEvMlpwhaVziQJPgIJm = default(YEJowMMJlEvMlpwhaVziQJPgIJm);
				while (true)
				{
					switch (num ^ -1528768459)
					{
					case 3:
						break;
					case 1:
						yEJowMMJlEvMlpwhaVziQJPgIJm = this;
						num = -1528768457;
						continue;
					case 0:
						goto IL_004e;
					default:
						yEJowMMJlEvMlpwhaVziQJPgIJm.hDvAMaTqLegLZzPsyeYTryTcCaC = lMvQGEdGoYKDXnJUDIpWwVzOVi;
						yEJowMMJlEvMlpwhaVziQJPgIJm.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return yEJowMMJlEvMlpwhaVziQJPgIJm;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				yEJowMMJlEvMlpwhaVziQJPgIJm = new YEJowMMJlEvMlpwhaVziQJPgIJm(0);
				yEJowMMJlEvMlpwhaVziQJPgIJm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -1528768457;
				goto IL_0028;
				IL_0023:
				num = -1528768460;
				goto IL_0028;
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
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						goto IL_00f0;
					case 2:
						goto IL_0189;
						IL_00f0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
						{
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = -1805846163;
							goto IL_0023;
						}
						goto IL_0067;
						IL_0023:
						while (true)
						{
							switch (num ^ -1805846171)
							{
							case 6:
								num = -1805846172;
								continue;
							case 11:
								break;
							case 8:
								num = -1805846170;
								continue;
							case 7:
								ZuLBcXCEqWtvGQDcuwvoWKBgAfjG = rNBGCwPCdUcwWCwIlQihKhDwFEGs.Current;
								num = -1805846167;
								continue;
							case 9:
								goto IL_00b9;
							case 0:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZuLBcXCEqWtvGQDcuwvoWKBgAfjG;
								num = -1805846176;
								continue;
							case 1:
								goto IL_00f0;
							case 12:
								if (ZuLBcXCEqWtvGQDcuwvoWKBgAfjG._actionId != hDvAMaTqLegLZzPsyeYTryTcCaC)
								{
									goto IL_00b9;
								}
								if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
								{
									goto case 0;
								}
								goto IL_0145;
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								result = true;
								num = -1805846175;
								continue;
							case 10:
								dJqhqTgmfWIlrYHVdMBrjxXuFVA();
								num = -1805846170;
								continue;
							case 2:
								goto IL_0189;
							case 4:
								goto end_IL_0000;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0145:
							int num2;
							if (ZuLBcXCEqWtvGQDcuwvoWKBgAfjG.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = -1805846171;
								num2 = num;
							}
							else
							{
								num = -1805846164;
								num2 = num;
							}
							continue;
							IL_00b9:
							int num3;
							if (rNBGCwPCdUcwWCwIlQihKhDwFEGs.MoveNext())
							{
								num = -1805846174;
								num3 = num;
							}
							else
							{
								num = -1805846161;
								num3 = num;
							}
						}
						goto IL_0067;
						IL_0067:
						if (hDvAMaTqLegLZzPsyeYTryTcCaC < 0)
						{
							break;
						}
						rNBGCwPCdUcwWCwIlQihKhDwFEGs = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.AxisMaps.GetEnumerator();
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -1805846164;
						goto IL_0023;
						IL_0189:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -1805846164;
						goto IL_0023;
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
						dJqhqTgmfWIlrYHVdMBrjxXuFVA();
					}
				}
			}

			[DebuggerHidden]
			public YEJowMMJlEvMlpwhaVziQJPgIJm(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void dJqhqTgmfWIlrYHVdMBrjxXuFVA()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (rNBGCwPCdUcwWCwIlQihKhDwFEGs != null)
				{
					rNBGCwPCdUcwWCwIlQihKhDwFEGs.Dispose();
				}
			}
		}

		private sealed class PpOkISumWjIivjPeUafJdCBaHwf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMapWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ControllerMap eRtoQSFdzNGKcVeofCcwFdixCwlq;

			public ControllerMap dpEHnIOdFJcjTJXgjRwdzBylCqB;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public ElementAssignmentConflictInfo xJeggZaZbJoKmqcVxwBdpqIOaOYD;

			public ControllerMapWithAxes vFxeBodAxlLuseLcVSbuoPmlTOHb;

			public IList<ActionElementMap> JKvsputiAFwzQXQMJkeLtEpGXZV;

			public int HuKAqOwtifCZtdMtiqovsXKLCla;

			public int LBIevzwyKpsueGhoxQQZTbaSRsn;

			public ActionElementMap vXtapPyikgGMgFATkjaxjDOncqao;

			public int ccXULuhxqGdpVRiBJBpNgpTGbbVH;

			public ActionElementMap ubYwJIfdFLStLYqjmDcRfJnXYuiP;

			public IEnumerator<ElementAssignmentConflictInfo> TCrmpXvzWWrynjrjRptyksGkclH;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				PpOkISumWjIivjPeUafJdCBaHwf ppOkISumWjIivjPeUafJdCBaHwf;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					ppOkISumWjIivjPeUafJdCBaHwf = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x6B73E197)
					{
					case 3:
						break;
					case 1:
						num = 1802756501;
						continue;
					case 0:
						goto IL_004e;
					default:
						ppOkISumWjIivjPeUafJdCBaHwf.eRtoQSFdzNGKcVeofCcwFdixCwlq = dpEHnIOdFJcjTJXgjRwdzBylCqB;
						ppOkISumWjIivjPeUafJdCBaHwf.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return ppOkISumWjIivjPeUafJdCBaHwf;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				ppOkISumWjIivjPeUafJdCBaHwf = new PpOkISumWjIivjPeUafJdCBaHwf(0);
				ppOkISumWjIivjPeUafJdCBaHwf.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 1802756501;
				goto IL_002a;
				IL_0025:
				num = 1802756502;
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
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = -181655314;
						goto IL_0022;
					case 2:
						goto IL_01dc;
					case 0:
						goto IL_02bd;
					case 3:
						goto IL_0409;
					case 1:
						break;
						IL_0022:
						while (true)
						{
							switch (num ^ -181655304)
							{
							case 19:
								break;
							case 23:
								xJeggZaZbJoKmqcVxwBdpqIOaOYD = TCrmpXvzWWrynjrjRptyksGkclH.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = xJeggZaZbJoKmqcVxwBdpqIOaOYD;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								num = -181655324;
								continue;
							case 8:
								goto IL_00d8;
							case 21:
								goto IL_00f9;
							case 26:
								mFDGRlHlJzlhSylYWFXzUlFVbIU();
								num = -181655327;
								continue;
							case 10:
								goto IL_012b;
							case 2:
								goto IL_0157;
							case 27:
								ubYwJIfdFLStLYqjmDcRfJnXYuiP = JKvsputiAFwzQXQMJkeLtEpGXZV[ccXULuhxqGdpVRiBJBpNgpTGbbVH];
								num = -181655297;
								continue;
							case 16:
								num = -181655312;
								continue;
							case 0:
								LBIevzwyKpsueGhoxQQZTbaSRsn++;
								num = -181655310;
								continue;
							case 24:
								goto IL_01bb;
							case 15:
								goto IL_01dc;
							case 12:
								goto IL_01ed;
							case 1:
								goto IL_0209;
							case 29:
								goto IL_023a;
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								return true;
							case 7:
								goto IL_0290;
							case 28:
								return true;
							case 9:
								goto IL_02bd;
							case 14:
								goto IL_02f4;
							case 11:
								RDkWcsTpvDaNZojjIZONnoEBXPC = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ZzSaCQHlhEgTijsOQGwUlyKTOzqG._categoryId).userAssignable, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerType, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerId, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._id, vXtapPyikgGMgFATkjaxjDOncqao.KAixZgRycuVSHIYaEVNGzKGIdgV, vXtapPyikgGMgFATkjaxjDOncqao._actionId, vXtapPyikgGMgFATkjaxjDOncqao._elementType, vXtapPyikgGMgFATkjaxjDOncqao._elementIdentifierId, vXtapPyikgGMgFATkjaxjDOncqao.keyCode, vXtapPyikgGMgFATkjaxjDOncqao.modifierKeyFlags);
								num = -181655299;
								continue;
							case 6:
								goto IL_03af;
							case 4:
								ccXULuhxqGdpVRiBJBpNgpTGbbVH++;
								num = -181655315;
								continue;
							case 22:
								num = -181655318;
								continue;
							case 17:
								goto IL_0409;
							case 3:
								LBIevzwyKpsueGhoxQQZTbaSRsn = 0;
								num = -181655310;
								continue;
							case 13:
								JKvsputiAFwzQXQMJkeLtEpGXZV = vFxeBodAxlLuseLcVSbuoPmlTOHb.AxisMaps;
								if (JKvsputiAFwzQXQMJkeLtEpGXZV != null)
								{
									HuKAqOwtifCZtdMtiqovsXKLCla = JKvsputiAFwzQXQMJkeLtEpGXZV.Count;
									num = -181655301;
									continue;
								}
								goto end_IL_0008;
							case 25:
								goto IL_045f;
							case 20:
								ccXULuhxqGdpVRiBJBpNgpTGbbVH = 0;
								num = -181655315;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_045f:
							vFxeBodAxlLuseLcVSbuoPmlTOHb = eRtoQSFdzNGKcVeofCcwFdixCwlq as ControllerMapWithAxes;
							int num2;
							if (vFxeBodAxlLuseLcVSbuoPmlTOHb != null)
							{
								num = -181655308;
								num2 = num;
							}
							else
							{
								num = -181655318;
								num2 = num;
							}
							continue;
							IL_00f9:
							int num3;
							if (ccXULuhxqGdpVRiBJBpNgpTGbbVH < HuKAqOwtifCZtdMtiqovsXKLCla)
							{
								num = -181655325;
								num3 = num;
							}
							else
							{
								num = -181655304;
								num3 = num;
							}
							continue;
							IL_0209:
							if (!ZzSaCQHlhEgTijsOQGwUlyKTOzqG._enabled)
							{
								goto end_IL_0008;
							}
							int num4;
							if (!vFxeBodAxlLuseLcVSbuoPmlTOHb._enabled)
							{
								num = -181655318;
								num4 = num;
							}
							else
							{
								num = -181655307;
								num4 = num;
							}
							continue;
							IL_03af:
							vXtapPyikgGMgFATkjaxjDOncqao = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz[LBIevzwyKpsueGhoxQQZTbaSRsn];
							int num5;
							if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								num = -181655302;
								num5 = num;
							}
							else
							{
								num = -181655316;
								num5 = num;
							}
							continue;
							IL_01bb:
							int num6;
							if (ubYwJIfdFLStLYqjmDcRfJnXYuiP.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = -181655306;
								num6 = num;
							}
							else
							{
								num = -181655300;
								num6 = num;
							}
							continue;
							IL_00d8:
							int num7;
							if (!TCrmpXvzWWrynjrjRptyksGkclH.MoveNext())
							{
								num = -181655326;
								num7 = num;
							}
							else
							{
								num = -181655313;
								num7 = num;
							}
							continue;
							IL_02f4:
							int num8;
							if (vXtapPyikgGMgFATkjaxjDOncqao.CheckForAssignmentConflict(ubYwJIfdFLStLYqjmDcRfJnXYuiP))
							{
								num = -181655309;
								num8 = num;
							}
							else
							{
								num = -181655300;
								num8 = num;
							}
							continue;
							IL_012b:
							int num9;
							if (LBIevzwyKpsueGhoxQQZTbaSRsn >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count)
							{
								num = -181655318;
								num9 = num;
							}
							else
							{
								num = -181655298;
								num9 = num;
							}
							continue;
							IL_01ed:
							int num10;
							if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								num = -181655303;
								num10 = num;
							}
							else
							{
								num = -181655307;
								num10 = num;
							}
							continue;
							IL_0290:
							int num11;
							if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								num = -181655306;
								num11 = num;
							}
							else
							{
								num = -181655328;
								num11 = num;
							}
							continue;
							IL_0157:
							int num12;
							if (!vXtapPyikgGMgFATkjaxjDOncqao.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = -181655304;
								num12 = num;
							}
							else
							{
								num = -181655316;
								num12 = num;
							}
						}
						goto default;
						IL_0409:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -181655300;
						goto IL_0022;
						IL_02bd:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
						{
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = -181655318;
							goto IL_0022;
						}
						goto IL_023a;
						IL_01dc:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -181655312;
						goto IL_0022;
						IL_023a:
						if (eRtoQSFdzNGKcVeofCcwFdixCwlq == null)
						{
							break;
						}
						TCrmpXvzWWrynjrjRptyksGkclH = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.VHQLgKwmqCkCHIqetsnVehdVNDg(eRtoQSFdzNGKcVeofCcwFdixCwlq, RKQUCYjAXkOQEvYPFrRsAzEcuaK).GetEnumerator();
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -181655320;
						goto IL_0022;
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
						mFDGRlHlJzlhSylYWFXzUlFVbIU();
					}
				}
			}

			[DebuggerHidden]
			public PpOkISumWjIivjPeUafJdCBaHwf(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void mFDGRlHlJzlhSylYWFXzUlFVbIU()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (TCrmpXvzWWrynjrjRptyksGkclH != null)
				{
					TCrmpXvzWWrynjrjRptyksGkclH.Dispose();
				}
			}
		}

		private sealed class TOlAHZizOCzsPVxbKtwwPCndQKv : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMapWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ActionElementMap MzATACNcsUpFsuEcdOAkGvOQVeI;

			public ActionElementMap dAuEWWkVFHeztWZBXuicejvoVSv;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public ElementAssignmentConflictInfo AXyaYMChYveQFeLwfJbIBJqhxtfz;

			public int JHffQfjQnwnjhTYnpUeBNWKfWqH;

			public ActionElementMap IIQGxivjlvIPKpxYzPaWDqGDsVz;

			public IEnumerator<ElementAssignmentConflictInfo> ktpGSAvElzidzUKdSPLyANjxuNu;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_005b;
				IL_005b:
				TOlAHZizOCzsPVxbKtwwPCndQKv tOlAHZizOCzsPVxbKtwwPCndQKv = new TOlAHZizOCzsPVxbKtwwPCndQKv(0);
				tOlAHZizOCzsPVxbKtwwPCndQKv.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				int num = 657431918;
				goto IL_0021;
				IL_001c:
				num = 657431912;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x272F9D6C)
					{
					case 0:
						break;
					case 4:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						num = 657431917;
						continue;
					case 3:
						num = 657431918;
						continue;
					case 5:
						goto IL_005b;
					case 1:
						tOlAHZizOCzsPVxbKtwwPCndQKv = this;
						num = 657431919;
						continue;
					default:
						tOlAHZizOCzsPVxbKtwwPCndQKv.MzATACNcsUpFsuEcdOAkGvOQVeI = dAuEWWkVFHeztWZBXuicejvoVSv;
						tOlAHZizOCzsPVxbKtwwPCndQKv.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return tOlAHZizOCzsPVxbKtwwPCndQKv;
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
				bool result = default(bool);
				try
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 2:
						goto IL_00e1;
					case 3:
						goto IL_023d;
					case 0:
						goto IL_02d0;
						IL_00e1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 1378800305;
						goto IL_0027;
						IL_0027:
						while (true)
						{
							switch (num ^ 0x522ED2B6)
							{
							case 4:
								num = 1378800318;
								continue;
							case 11:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								result = true;
								num = 1378800308;
								continue;
							case 1:
								break;
							case 10:
								goto IL_00a3;
							case 16:
								goto IL_00e1;
							case 12:
								goto IL_00f2;
							case 0:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz != null)
								{
									JHffQfjQnwnjhTYnpUeBNWKfWqH = 0;
									num = 1378800312;
									continue;
								}
								goto end_IL_0008;
							case 3:
								JHffQfjQnwnjhTYnpUeBNWKfWqH++;
								num = 1378800312;
								continue;
							case 6:
								num = 1378800292;
								continue;
							case 7:
								goto IL_0166;
							case 9:
								if (IIQGxivjlvIPKpxYzPaWDqGDsVz.CheckForAssignmentConflict(MzATACNcsUpFsuEcdOAkGvOQVeI))
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ZzSaCQHlhEgTijsOQGwUlyKTOzqG._categoryId).userAssignable, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerType, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerId, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._id, IIQGxivjlvIPKpxYzPaWDqGDsVz.KAixZgRycuVSHIYaEVNGzKGIdgV, IIQGxivjlvIPKpxYzPaWDqGDsVz._actionId, IIQGxivjlvIPKpxYzPaWDqGDsVz._elementType, IIQGxivjlvIPKpxYzPaWDqGDsVz._elementIdentifierId, IIQGxivjlvIPKpxYzPaWDqGDsVz.keyCode, IIQGxivjlvIPKpxYzPaWDqGDsVz.modifierKeyFlags);
									num = 1378800317;
									continue;
								}
								goto case 3;
							case 2:
								break;
							case 15:
								goto IL_023d;
							case 13:
								IIQGxivjlvIPKpxYzPaWDqGDsVz = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz[JHffQfjQnwnjhTYnpUeBNWKfWqH];
								num = 1378800293;
								continue;
							case 19:
								if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
								{
									goto case 9;
								}
								goto IL_027f;
							case 17:
								AXyaYMChYveQFeLwfJbIBJqhxtfz = ktpGSAvElzidzUKdSPLyANjxuNu.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = AXyaYMChYveQFeLwfJbIBJqhxtfz;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								result = true;
								num = 1378800311;
								continue;
							case 8:
								goto IL_02d0;
							case 5:
								goto IL_0307;
							case 14:
								goto IL_0329;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0329:
							int num2;
							if (JHffQfjQnwnjhTYnpUeBNWKfWqH < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count)
							{
								num = 1378800315;
								num2 = num;
							}
							else
							{
								num = 1378800292;
								num2 = num;
							}
							continue;
							IL_00f2:
							if (!ZzSaCQHlhEgTijsOQGwUlyKTOzqG._enabled)
							{
								goto end_IL_0008;
							}
							int num3;
							if (MzATACNcsUpFsuEcdOAkGvOQVeI.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = 1378800310;
								num3 = num;
							}
							else
							{
								num = 1378800292;
								num3 = num;
							}
							continue;
							IL_027f:
							int num4;
							if (!IIQGxivjlvIPKpxYzPaWDqGDsVz.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = 1378800309;
								num4 = num;
							}
							else
							{
								num = 1378800319;
								num4 = num;
							}
							continue;
							IL_0307:
							JZiuKHSakItjzkbVeSepKjrPcDS();
							int num5;
							if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								num = 1378800314;
								num5 = num;
							}
							else
							{
								num = 1378800310;
								num5 = num;
							}
							continue;
							IL_0166:
							int num6;
							if (ktpGSAvElzidzUKdSPLyANjxuNu.MoveNext())
							{
								num = 1378800295;
								num6 = num;
							}
							else
							{
								num = 1378800307;
								num6 = num;
							}
						}
						goto end_IL_0000;
						IL_02d0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
						{
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 1378800304;
							goto IL_0027;
						}
						goto IL_00a3;
						IL_00a3:
						if (MzATACNcsUpFsuEcdOAkGvOQVeI == null)
						{
							break;
						}
						ktpGSAvElzidzUKdSPLyANjxuNu = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.yhCKekJgZLSRBCRNiTWFYABfLdQ(MzATACNcsUpFsuEcdOAkGvOQVeI, RKQUCYjAXkOQEvYPFrRsAzEcuaK).GetEnumerator();
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 1378800305;
						goto IL_0027;
						IL_023d:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 1378800309;
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
						JZiuKHSakItjzkbVeSepKjrPcDS();
					}
				}
			}

			[DebuggerHidden]
			public TOlAHZizOCzsPVxbKtwwPCndQKv(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void JZiuKHSakItjzkbVeSepKjrPcDS()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (ktpGSAvElzidzUKdSPLyANjxuNu != null)
				{
					ktpGSAvElzidzUKdSPLyANjxuNu.Dispose();
				}
			}
		}

		private sealed class ckKFAZCwjkVJgIshCZCsDXHSsCz : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMapWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ElementAssignmentConflictCheck XoQvEtmGuEoQzAIlaNmgxPliHTu;

			public ElementAssignmentConflictCheck UQPnpLguhtCEkQPRaxuaPxhrRag;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public ElementAssignmentConflictInfo mXuOyDIYheMxNxKmQIyHbIUOodR;

			public ElementAssignment KDkRFDlqUagsyqcKUnbxzUXKsRB;

			public int xiOTXdDFQQAnykUHoaPtxqhkefa;

			public ActionElementMap LfAhaZEgMGoDnaZdMYnSILwwmzj;

			public IEnumerator<ElementAssignmentConflictInfo> KBORqVwXnVcSpKpHeoypSTBRBlU;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				ckKFAZCwjkVJgIshCZCsDXHSsCz ckKFAZCwjkVJgIshCZCsDXHSsCz2 = default(ckKFAZCwjkVJgIshCZCsDXHSsCz);
				while (true)
				{
					switch (num ^ 0x2B4818F7)
					{
					case 0:
						break;
					case 2:
						ckKFAZCwjkVJgIshCZCsDXHSsCz2 = this;
						num = 726145270;
						continue;
					case 3:
						goto IL_004e;
					default:
						ckKFAZCwjkVJgIshCZCsDXHSsCz2.XoQvEtmGuEoQzAIlaNmgxPliHTu = UQPnpLguhtCEkQPRaxuaPxhrRag;
						ckKFAZCwjkVJgIshCZCsDXHSsCz2.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return ckKFAZCwjkVJgIshCZCsDXHSsCz2;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				ckKFAZCwjkVJgIshCZCsDXHSsCz2 = new ckKFAZCwjkVJgIshCZCsDXHSsCz(0);
				ckKFAZCwjkVJgIshCZCsDXHSsCz2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 726145270;
				goto IL_0028;
				IL_0023:
				num = 726145269;
				goto IL_0028;
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
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = -1096030028;
						while (true)
						{
							switch (num ^ -1096030027)
							{
							case 17:
								break;
							case 18:
								if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
								{
									ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
									num = -1096030024;
									continue;
								}
								goto case 2;
							case 5:
								LfAhaZEgMGoDnaZdMYnSILwwmzj = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz[xiOTXdDFQQAnykUHoaPtxqhkefa];
								if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
								{
									int num4;
									if (!LfAhaZEgMGoDnaZdMYnSILwwmzj.gmbIkkevNmPVGSTIwKcAwoPYANrc)
									{
										num = -1096030019;
										num4 = num;
									}
									else
									{
										num = -1096030017;
										num4 = num;
									}
									continue;
								}
								goto case 10;
							case 8:
								xiOTXdDFQQAnykUHoaPtxqhkefa++;
								num = -1096030020;
								continue;
							case 10:
							{
								int num6;
								if (LfAhaZEgMGoDnaZdMYnSILwwmzj.KAixZgRycuVSHIYaEVNGzKGIdgV == XoQvEtmGuEoQzAIlaNmgxPliHTu.elementMapId)
								{
									num = -1096030019;
									num6 = num;
								}
								else
								{
									num = -1096030018;
									num6 = num;
								}
								continue;
							}
							case 11:
								if (LfAhaZEgMGoDnaZdMYnSILwwmzj.CheckForAssignmentConflict(KDkRFDlqUagsyqcKUnbxzUXKsRB))
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ZzSaCQHlhEgTijsOQGwUlyKTOzqG._categoryId).userAssignable, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerType, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerId, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._id, LfAhaZEgMGoDnaZdMYnSILwwmzj.KAixZgRycuVSHIYaEVNGzKGIdgV, LfAhaZEgMGoDnaZdMYnSILwwmzj._actionId, LfAhaZEgMGoDnaZdMYnSILwwmzj._elementType, LfAhaZEgMGoDnaZdMYnSILwwmzj._elementIdentifierId, LfAhaZEgMGoDnaZdMYnSILwwmzj.keyCode, LfAhaZEgMGoDnaZdMYnSILwwmzj.modifierKeyFlags);
									num = -1096030027;
									continue;
								}
								goto case 8;
							case 14:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -1096030041;
								continue;
							case 16:
								RDkWcsTpvDaNZojjIZONnoEBXPC = mXuOyDIYheMxNxKmQIyHbIUOodR;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								return true;
							case 7:
								goto IL_01fd;
							case 4:
								if (!KBORqVwXnVcSpKpHeoypSTBRBlU.MoveNext())
								{
									eXftKEOBRvaCbMKWzGcMiuzQIutc();
									if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
									{
										int num3;
										if (!ZzSaCQHlhEgTijsOQGwUlyKTOzqG._enabled)
										{
											num = -1096030024;
											num3 = num;
										}
										else
										{
											num = -1096030023;
											num3 = num;
										}
										continue;
									}
									goto case 12;
								}
								goto case 3;
							case 0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								return true;
							case 6:
								KDkRFDlqUagsyqcKUnbxzUXKsRB = XoQvEtmGuEoQzAIlaNmgxPliHTu.ToElementAssignment();
								xiOTXdDFQQAnykUHoaPtxqhkefa = 0;
								num = -1096030020;
								continue;
							case 9:
							{
								int num2;
								if (xiOTXdDFQQAnykUHoaPtxqhkefa >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count)
								{
									num = -1096030024;
									num2 = num;
								}
								else
								{
									num = -1096030032;
									num2 = num;
								}
								continue;
							}
							case 12:
							{
								int num5;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ZPhbSkhrYKbvviOCcoZfUSvYBmWz != null)
								{
									num = -1096030029;
									num5 = num;
								}
								else
								{
									num = -1096030024;
									num5 = num;
								}
								continue;
							}
							case 15:
								goto IL_02d7;
							case 2:
								KBORqVwXnVcSpKpHeoypSTBRBlU = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.qEhCQfYiNaajdGQFFHULKggTFvk(XoQvEtmGuEoQzAIlaNmgxPliHTu, RKQUCYjAXkOQEvYPFrRsAzEcuaK).GetEnumerator();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1096030031;
								continue;
							case 1:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 0:
									break;
								case 3:
									goto IL_01fd;
								case 2:
									goto IL_02d7;
								default:
									goto IL_0331;
								case 1:
									goto IL_0356;
								}
								goto case 14;
							case 3:
								mXuOyDIYheMxNxKmQIyHbIUOodR = KBORqVwXnVcSpKpHeoypSTBRBlU.Current;
								num = -1096030043;
								continue;
							default:
								goto IL_0356;
								IL_0356:
								return false;
								IL_0331:
								num = -1096030024;
								continue;
								IL_02d7:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1096030031;
								continue;
								IL_01fd:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -1096030019;
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
						eXftKEOBRvaCbMKWzGcMiuzQIutc();
					}
				}
			}

			[DebuggerHidden]
			public ckKFAZCwjkVJgIshCZCsDXHSsCz(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void eXftKEOBRvaCbMKWzGcMiuzQIutc()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (KBORqVwXnVcSpKpHeoypSTBRBlU != null)
				{
					KBORqVwXnVcSpKpHeoypSTBRBlU.Dispose();
				}
			}
		}

		private readonly IList<ActionElementMap> ZPhbSkhrYKbvviOCcoZfUSvYBmWz;

		private readonly ReadOnlyCollection<ActionElementMap> kAkeQxHFrLlHEohdCqEYAKVaqIb;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
				{
					return 0;
				}
				return ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return kAkeQxHFrLlHEohdCqEYAKVaqIb;
			}
		}

		internal AList<ActionElementMap> AxisMaps_orig
		{
			get
			{
				return (AList<ActionElementMap>)ZPhbSkhrYKbvviOCcoZfUSvYBmWz;
			}
		}

		public ControllerMapWithAxes()
		{
			ZPhbSkhrYKbvviOCcoZfUSvYBmWz = new AList<ActionElementMap>();
			kAkeQxHFrLlHEohdCqEYAKVaqIb = new ReadOnlyCollection<ActionElementMap>(ZPhbSkhrYKbvviOCcoZfUSvYBmWz);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes controllerMap)
			: base(controllerMap)
		{
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				int num = -1619057662;
				while (true)
				{
					switch (num ^ -1619057664)
					{
					case 4:
						break;
					default:
						return;
					case 2:
						ZPhbSkhrYKbvviOCcoZfUSvYBmWz = new AList<ActionElementMap>();
						kAkeQxHFrLlHEohdCqEYAKVaqIb = new ReadOnlyCollection<ActionElementMap>(ZPhbSkhrYKbvviOCcoZfUSvYBmWz);
						num = -1619057663;
						continue;
					case 5:
						NAtmUFIQVkJgfdgwQosNyJVbSOe(new ActionElementMap(controllerMap.ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2]));
						num2++;
						num = -1619057661;
						continue;
					case 1:
						if (controllerMap.ZPhbSkhrYKbvviOCcoZfUSvYBmWz != null)
						{
							count = controllerMap.ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
							num = -1619057658;
							continue;
						}
						return;
					case 6:
						num2 = 0;
						num = -1619057661;
						continue;
					case 3:
					{
						int num3;
						if (num2 < count)
						{
							num = -1619057659;
							num3 = num;
						}
						else
						{
							num = -1619057664;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			int count = default(int);
			int num = default(int);
			int num2;
			if (!base.ContainsAction(actionId))
			{
				if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
				{
					return false;
				}
				count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
				num = 0;
				num2 = -252531122;
			}
			else
			{
				num2 = -252531121;
			}
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -252531126)
				{
				case 2:
					break;
				case 3:
					if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num]._actionId == actionId)
					{
						return true;
					}
					num++;
					num2 = -252531126;
					continue;
				case 5:
					return true;
				case 4:
					num2 = -252531126;
					continue;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				default:
					if (num >= count)
					{
						return false;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num2 = -252531125;
			goto IL_0015;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				goto IL_0032;
			}
			int num;
			ActionElementMap actionElementMap = default(ActionElementMap);
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementType))
			{
				num = -1689630543;
			}
			else
			{
				actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
				num = -1689630541;
			}
			goto IL_0037;
			IL_0037:
			while (true)
			{
				switch (num ^ -1689630541)
				{
				case 4:
					break;
				case 1:
					return true;
				case 2:
					return false;
				case 0:
					goto IL_0083;
				default:
					result = actionElementMap;
					return true;
				}
				break;
				IL_0083:
				BakeElementMap(actionElementMap);
				NAtmUFIQVkJgfdgwQosNyJVbSOe(actionElementMap);
				num = -1689630544;
			}
			goto IL_0032;
			IL_0032:
			num = -1689630542;
			goto IL_0037;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				goto IL_001d;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			int num;
			ActionElementMap elementMap = default(ActionElementMap);
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementType))
			{
				num = -2057166866;
			}
			else
			{
				elementMap = GetElementMap(elementMapId);
				num = -2057166871;
			}
			goto IL_0022;
			IL_001d:
			num = -2057166869;
			goto IL_0022;
			IL_0022:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -2057166872)
				{
				case 5:
					break;
				case 3:
					return false;
				case 4:
					num2 = FYopIOTmJUboOKYEGbdlGYgfPUMQ(elementMapId);
					num = -2057166865;
					continue;
				case 2:
					return false;
				case 6:
					return false;
				case 1:
					if (elementMap != null)
					{
						if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementMap._elementType))
						{
							DeleteElementMap(elementMapId);
							elementMap._elementType = ControllerElementType.Axis;
							num = -2057166872;
							continue;
						}
						goto case 4;
					}
					num = -2057166870;
					continue;
				case 0:
					NAtmUFIQVkJgfdgwQosNyJVbSOe(elementMap);
					num = -2057166868;
					continue;
				default:
					if (num2 < 0)
					{
						return false;
					}
					ControllerMap.CMutJYldqVFwACUDBjHKpaGMJfl(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
					BakeElementMap(elementMap);
					result = elementMap;
					return true;
				}
				break;
			}
			goto IL_001d;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = FYopIOTmJUboOKYEGbdlGYgfPUMQ(elementMapId);
			while (true)
			{
				int num2 = 331332997;
				while (true)
				{
					switch (num2 ^ 0x13BFBD84)
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
					dRWQkmnYrgqMFxVJnWUhrezoAuOi(elementMapId, num);
					num2 = 331332996;
				}
			}
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = -1759904731;
					while (true)
					{
						switch (num ^ -1759904732)
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
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = -1759904732;
					}
				}
			}
			return DeleteElementMapsWithAction(ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			bool flag = base.DeleteElementMapsWithAction(actionId);
			int num = -2029245482;
			goto IL_0012;
			IL_0012:
			switch (num ^ -2029245481)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			default:
				return flag | DeleteAxisMapsWithAction(actionId);
			}
			goto IL_000d;
			IL_000d:
			num = -2029245483;
			goto IL_0012;
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			int num;
			int count = default(int);
			int num2 = default(int);
			if (elementMap != null)
			{
				num = 723526716;
			}
			else
			{
				if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
				{
					return null;
				}
				count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
				num2 = 0;
				num = 723526719;
			}
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2B20243E)
				{
				case 4:
					break;
				case 5:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				case 1:
				{
					int num3;
					if (num2 >= count)
					{
						num = 723526712;
						num3 = num;
					}
					else
					{
						num = 723526717;
						num3 = num;
					}
					continue;
				}
				case 2:
					return elementMap;
				case 0:
					return ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
				case 3:
					if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2].KAixZgRycuVSHIYaEVNGzKGIdgV != elementMapId)
					{
						num2++;
						num = 723526719;
					}
					else
					{
						num = 723526718;
					}
					continue;
				default:
					return null;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 723526715;
			goto IL_0012;
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, false);
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			ActionElementMap firstElementMapWithAction = base.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
			if (firstElementMapWithAction != null)
			{
				return firstElementMapWithAction;
			}
			int count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					ActionElementMap actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num];
					int num2 = -1253625085;
					while (true)
					{
						switch (num2 ^ -1253625085)
						{
						case 2:
							num2 = -1253625081;
							continue;
						case 4:
							break;
						case 3:
							goto IL_0079;
						case 0:
							goto IL_0086;
						default:
							goto end_IL_0065;
						}
						break;
						IL_0086:
						if (actionElementMap._actionId == actionId)
						{
							if (!skipDisabledMaps)
							{
								goto IL_0079;
							}
							if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = -1253625088;
								continue;
							}
						}
						num++;
						num2 = -1253625086;
						continue;
						IL_0079:
						return actionElementMap;
					}
					continue;
					end_IL_0065:
					break;
				}
			}
			return null;
		}

		internal override ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap firstElementMapMatch = base.GetFirstElementMapMatch(P_0, P_1);
			if (firstElementMapMatch != null)
			{
				return firstElementMapMatch;
			}
			return qjiTODRFRGwGYwEqBUAWeWDzqQS(P_0, P_1);
		}

		internal override int GetElementMapMatches(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int elementMapMatches = base.GetElementMapMatches(P_0, P_1, P_2, P_3);
			return elementMapMatches + wJufnlfDWzmUbbMbgLCapINirrjF(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			while (true)
			{
				base.ClearElementMaps();
				int num = 977674866;
				while (true)
				{
					switch (num ^ 0x3A462273)
					{
					case 0:
						goto IL_001a;
					case 2:
						break;
					default:
						ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Clear();
						return;
					}
					break;
					IL_001a:
					num = 977674865;
				}
			}
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz != null && index >= 0)
			{
				if (index >= ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count)
				{
					num = -146120046;
					goto IL_0012;
				}
				return ZPhbSkhrYKbvviOCcoZfUSvYBmWz[index];
			}
			goto IL_005a;
			IL_005a:
			return null;
			IL_0012:
			switch (num ^ -146120048)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			default:
				goto IL_005a;
			}
			goto IL_000d;
			IL_000d:
			num = -146120047;
			goto IL_0012;
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(ZPhbSkhrYKbvviOCcoZfUSvYBmWz);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					ActionElementMap actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
					int num3;
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						list.Add(actionElementMap);
						num3 = -1677566496;
						goto IL_0045;
					}
					goto IL_0085;
					IL_0045:
					while (true)
					{
						switch (num3 ^ -1677566493)
						{
						case 0:
							num3 = -1677566495;
							continue;
						case 2:
							break;
						case 3:
							goto IL_0085;
						default:
							goto end_IL_0062;
						}
						break;
					}
					continue;
					IL_0085:
					num2++;
					num3 = -1677566494;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return UQafBmOpdxYZIQbXvjpimuOonkb(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			int num = 1217128751;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x488BE92D)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			default:
				if (inputAction == null)
				{
					return EmptyObjects<ActionElementMap>.array;
				}
				return GetAxisMapsWithAction(inputAction.id);
			}
			goto IL_000d;
			IL_000d:
			num = 1217128748;
			goto IL_0012;
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			int num = -1448008603;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1448008601)
			{
			case 0:
				break;
			case 1:
				return EmptyObjects<ActionElementMap>.array;
			default:
				if (inputAction == null)
				{
					return EmptyObjects<ActionElementMap>.array;
				}
				return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
			}
			goto IL_0019;
			IL_0019:
			num = -1448008602;
			goto IL_001e;
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = axisMapCount;
			int num2 = -48322275;
			goto IL_001e;
			IL_0019:
			num2 = -48322280;
			goto IL_001e;
			IL_001e:
			int num6 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			ActionElementMap[] array = default(ActionElementMap[]);
			int num9 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ -48322285)
				{
				case 12:
					break;
				case 11:
					return EmptyObjects<ActionElementMap>.array;
				case 2:
					num6 = 0;
					num2 = -48322279;
					continue;
				case 13:
					num6++;
					num2 = -48322278;
					continue;
				case 4:
					num3++;
					num2 = -48322301;
					continue;
				case 10:
					num2 = -48322278;
					continue;
				case 1:
				{
					int num5;
					if (num4 >= num)
					{
						num2 = -48322284;
						num5 = num2;
					}
					else
					{
						num2 = -48322283;
						num5 = num2;
					}
					continue;
				}
				case 7:
					if (num3 == 0)
					{
						return EmptyObjects<ActionElementMap>.array;
					}
					array = new ActionElementMap[num3];
					num9 = 0;
					num2 = -48322287;
					continue;
				case 16:
					num4++;
					num2 = -48322286;
					continue;
				case 5:
					actionElementMap2 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num6];
					if (actionElementMap2._actionId != actionId)
					{
						goto case 13;
					}
					if (skipDisabledMaps)
					{
						int num11;
						if (!actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num2 = -48322274;
							num11 = num2;
						}
						else
						{
							num2 = -48322288;
							num11 = num2;
						}
						continue;
					}
					goto case 3;
				case 6:
					actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num4];
					if (actionElementMap._actionId == actionId)
					{
						int num10;
						if (skipDisabledMaps)
						{
							num2 = -48322285;
							num10 = num2;
						}
						else
						{
							num2 = -48322281;
							num10 = num2;
						}
						continue;
					}
					goto case 16;
				case 3:
					array[num9] = actionElementMap2;
					num9++;
					num2 = -48322274;
					continue;
				case 9:
				{
					int num8;
					if (num6 >= num)
					{
						num2 = -48322277;
						num8 = num2;
					}
					else
					{
						num2 = -48322282;
						num8 = num2;
					}
					continue;
				}
				case 0:
				{
					int num7;
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num2 = -48322301;
						num7 = num2;
					}
					else
					{
						num2 = -48322281;
						num7 = num2;
					}
					continue;
				}
				case 15:
					num4 = 0;
					num2 = -48322286;
					continue;
				case 14:
					if (num == 0)
					{
						return EmptyObjects<ActionElementMap>.array;
					}
					num3 = 0;
					num2 = -48322276;
					continue;
				default:
					return array;
				}
				break;
			}
			goto IL_0019;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			int num = 89046770;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x54EBEF2)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			default:
				if (inputAction == null)
				{
					ListTools.TryClear(results);
					return 0;
				}
				return GetAxisMapsWithAction(inputAction.id, results);
			}
			goto IL_000d;
			IL_000d:
			num = 89046771;
			goto IL_0012;
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return JWoVzAynstgsUWzdBFvHgVLSPoi(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = 2033582734;
					while (true)
					{
						switch (num ^ 0x7936028C)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 2033582733;
					}
				}
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			YEJowMMJlEvMlpwhaVziQJPgIJm yEJowMMJlEvMlpwhaVziQJPgIJm = new YEJowMMJlEvMlpwhaVziQJPgIJm(-2);
			yEJowMMJlEvMlpwhaVziQJPgIJm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			yEJowMMJlEvMlpwhaVziQJPgIJm.lMvQGEdGoYKDXnJUDIpWwVzOVi = actionId;
			yEJowMMJlEvMlpwhaVziQJPgIJm.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
			return yEJowMMJlEvMlpwhaVziQJPgIJm;
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			int num = 813920541;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x3083711D)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				return GetFirstAxisMapWithAction(actionId);
			}
			goto IL_0019;
			IL_0019:
			num = 813920540;
			goto IL_001e;
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			if (actionId < 0)
			{
				goto IL_001f;
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num = -1464639401;
			goto IL_0024;
			IL_0024:
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int count = default(int);
			while (true)
			{
				switch (num ^ -1464639402)
				{
				case 6:
					break;
				case 2:
					return null;
				case 4:
					num2 = 0;
					num = -1464639403;
					continue;
				case 0:
					actionElementMap = axisMaps[num2];
					if (actionElementMap._actionId == actionId)
					{
						if (!skipDisabledMaps)
						{
							goto case 5;
						}
						if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -1464639405;
							continue;
						}
					}
					num2++;
					num = -1464639403;
					continue;
				case 5:
					return actionElementMap;
				case 1:
					count = axisMaps.Count;
					num = -1464639406;
					continue;
				default:
					if (num2 >= count)
					{
						return null;
					}
					goto case 0;
				}
				break;
			}
			goto IL_001f;
			IL_001f:
			num = -1464639404;
			goto IL_0024;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return qjiTODRFRGwGYwEqBUAWeWDzqQS(predicate, false);
		}

		internal ActionElementMap qjiTODRFRGwGYwEqBUAWeWDzqQS(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num = axisMapCount;
			try
			{
				int num2 = 0;
				while (num2 < num)
				{
					while (true)
					{
						ActionElementMap actionElementMap = axisMaps[num2];
						int num3;
						if (P_1)
						{
							int num4;
							if (actionElementMap.enabled)
							{
								num3 = -729804666;
								num4 = num3;
							}
							else
							{
								num3 = -729804671;
								num4 = num3;
							}
							goto IL_0025;
						}
						goto IL_0085;
						IL_0025:
						while (true)
						{
							switch (num3 ^ -729804670)
							{
							case 0:
								num3 = -729804669;
								continue;
							case 1:
								break;
							case 5:
								return actionElementMap;
							case 3:
								num2++;
								num3 = -729804672;
								continue;
							case 4:
								goto IL_0085;
							default:
								goto end_IL_004a;
							}
							break;
						}
						continue;
						IL_0085:
						int num5;
						if (P_0(actionElementMap))
						{
							num3 = -729804665;
							num5 = num3;
						}
						else
						{
							num3 = -729804671;
							num5 = num3;
						}
						goto IL_0025;
						continue;
						end_IL_004a:
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

		public int GetAxisMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return wJufnlfDWzmUbbMbgLCapINirrjF(predicate, false, results, false);
		}

		internal int wJufnlfDWzmUbbMbgLCapINirrjF(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			while (P_2 != null)
			{
				while (true)
				{
					IL_006d:
					int num = 0;
					int num2;
					int num3;
					if (!P_3)
					{
						num2 = -1566348589;
						num3 = num2;
					}
					else
					{
						num2 = -1566348590;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1566348585)
						{
						case 6:
							num2 = -1566348586;
							continue;
						case 3:
							axisMaps = AxisMaps;
							num2 = -1566348585;
							continue;
						case 5:
							num = P_2.Count;
							num2 = -1566348588;
							continue;
						case 1:
							break;
						case 2:
							goto IL_006d;
						case 4:
							P_2.Clear();
							num2 = -1566348588;
							continue;
						default:
						{
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
										if (P_1)
										{
											int num7;
											if (actionElementMap.enabled)
											{
												num6 = -1566348588;
												num7 = num6;
											}
											else
											{
												num6 = -1566348587;
												num7 = num6;
											}
											goto IL_00a1;
										}
										goto IL_00f3;
										IL_00f3:
										if (P_0(actionElementMap))
										{
											P_2.Add(actionElementMap);
											num6 = -1566348587;
											goto IL_00a1;
										}
										goto IL_00e8;
										IL_00a1:
										while (true)
										{
											switch (num6 ^ -1566348585)
											{
											case 4:
												num6 = -1566348586;
												continue;
											case 1:
												break;
											case 2:
												goto IL_00e8;
											case 3:
												goto IL_00f3;
											default:
												goto end_IL_00c2;
											}
											break;
										}
										continue;
										IL_00e8:
										num5++;
										num6 = -1566348585;
										goto IL_00a1;
										continue;
										end_IL_00c2:
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				while (true)
				{
					switch (-1530604040 ^ -1530604039)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto end_IL_0019;
					case 4:
						goto IL_005c;
					default:
						goto IL_0071;
					}
					continue;
					end_IL_0019:
					break;
				}
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			goto IL_005c;
			IL_0071:
			int count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
			try
			{
				int num = 0;
				ActionElementMap obj = default(ActionElementMap);
				while (true)
				{
					int num2;
					int num3;
					if (num >= count)
					{
						num2 = -1530604037;
						num3 = num2;
					}
					else
					{
						num2 = -1530604038;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1530604039)
						{
						case 4:
							num2 = -1530604038;
							continue;
						default:
							return;
						case 3:
						{
							obj = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num];
							int num4;
							if (!predicate(obj))
							{
								num2 = -1530604036;
								num4 = num2;
							}
							else
							{
								num2 = -1530604040;
								num4 = num2;
							}
							continue;
						}
						case 1:
							actionToPerform(obj);
							num2 = -1530604036;
							continue;
						case 5:
							num++;
							num2 = -1530604039;
							continue;
						case 0:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}
			catch (Exception exception)
			{
				while (true)
				{
					int num5 = -1530604040;
					while (true)
					{
						switch (num5 ^ -1530604039)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0121;
						case 2:
							return;
						}
						break;
						IL_0121:
						ReInput.HandleCallbackException("ControllerMap.ForEachAxisMapMatch", exception);
						num5 = -1530604037;
					}
				}
			}
			IL_005c:
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_0071;
		}

		public bool DeleteAxisMapsWithAction(string actionName)
		{
			return DeleteAxisMapsWithAction(ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			bool result = default(bool);
			int num2 = default(int);
			int num3;
			if (actionId >= 0)
			{
				int num = axisMapCount;
				if (num == 0)
				{
					return false;
				}
				result = false;
				num2 = num - 1;
				num3 = 1576705935;
			}
			else
			{
				num3 = 1576705932;
			}
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num3 ^ 0x5DFA9F89)
				{
				case 2:
					break;
				case 7:
				{
					int num4;
					if (num2 >= 0)
					{
						num3 = 1576705930;
						num4 = num3;
					}
					else
					{
						num3 = 1576705929;
						num4 = num3;
					}
					continue;
				}
				case 5:
					return false;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				case 3:
					if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2] != null && ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2]._actionId == actionId)
					{
						dRWQkmnYrgqMFxVJnWUhrezoAuOi(ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2].KAixZgRycuVSHIYaEVNGzKGIdgV, num2);
						result = true;
						num3 = 1576705933;
						continue;
					}
					goto case 4;
				case 6:
					num3 = 1576705934;
					continue;
				case 4:
					num2--;
					num3 = 1576705934;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num3 = 1576705928;
			goto IL_0012;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			int num = 0;
			int count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
			int num2 = 1798537244;
			goto IL_0015;
			IL_0015:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x6B33801A)
				{
				case 4:
					break;
				case 3:
					actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
					num2 = 1798537247;
					continue;
				case 5:
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc != state)
					{
						actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc = state;
						num++;
						num2 = 1798537240;
						continue;
					}
					goto case 2;
				case 7:
					num2 = 1798537242;
					continue;
				case 2:
					num3++;
					num2 = 1798537242;
					continue;
				case 6:
					num3 = 0;
					num2 = 1798537245;
					continue;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				default:
					if (num3 >= count)
					{
						return num;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num2 = 1798537243;
			goto IL_0015;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_001c;
			}
			if (controllerMap == null)
			{
				return false;
			}
			int num;
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			int count = default(int);
			int count2 = default(int);
			int num2 = default(int);
			if (!base.DoesElementAssignmentConflict(controllerMap, skipDisabledMaps))
			{
				ControllerMapWithAxes controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
				if (controllerMapWithAxes == null)
				{
					return false;
				}
				if (skipDisabledMaps)
				{
					if (!_enabled)
					{
						goto IL_0173;
					}
					if (!controllerMapWithAxes._enabled)
					{
						num = -931085887;
						goto IL_0021;
					}
				}
				if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz != null)
				{
					axisMaps = controllerMapWithAxes.AxisMaps;
					if (axisMaps == null)
					{
						return false;
					}
					count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
					count2 = axisMaps.Count;
					num2 = 0;
					num = -931085874;
				}
				else
				{
					num = -931085884;
				}
			}
			else
			{
				num = -931085881;
			}
			goto IL_0021;
			IL_0021:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -931085882)
				{
				case 9:
					break;
				case 0:
					actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
					if (skipDisabledMaps)
					{
						goto IL_0076;
					}
					goto case 3;
				case 5:
					num2++;
					num = -931085874;
					continue;
				case 1:
					return true;
				case 2:
					return false;
				case 6:
					goto IL_00ff;
				case 11:
					goto IL_011c;
				case 10:
					goto IL_0135;
				case 4:
					return false;
				case 7:
					goto IL_0173;
				case 3:
					num3 = 0;
					num = -931085875;
					continue;
				default:
					if (num2 >= count)
					{
						return false;
					}
					goto case 0;
				}
				break;
				IL_0135:
				actionElementMap2 = axisMaps[num3];
				if (!skipDisabledMaps)
				{
					goto IL_00ff;
				}
				if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = -931085888;
					continue;
				}
				goto IL_010c;
				IL_00ff:
				if (actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
				goto IL_010c;
				IL_010c:
				num3++;
				num = -931085875;
				continue;
				IL_011c:
				int num4;
				if (num3 >= count2)
				{
					num = -931085885;
					num4 = num;
				}
				else
				{
					num = -931085876;
					num4 = num;
				}
				continue;
				IL_0076:
				int num5;
				if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = -931085883;
					num5 = num;
				}
				else
				{
					num = -931085885;
					num5 = num;
				}
			}
			goto IL_001c;
			IL_001c:
			num = -931085886;
			goto IL_0021;
			IL_0173:
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			if (actionElementMap == null)
			{
				return false;
			}
			int num;
			if (!base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
			{
				if (!skipDisabledMaps)
				{
					goto IL_00f1;
				}
				int num2;
				if (_enabled)
				{
					num = 1398417692;
					num2 = num;
				}
				else
				{
					num = 1398417689;
					num2 = num;
				}
			}
			else
			{
				num = 1398417690;
			}
			goto IL_0012;
			IL_000d:
			num = 1398417693;
			goto IL_0012;
			IL_0012:
			int num3 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x535A291A)
				{
				case 2:
					break;
				case 6:
					goto IL_0046;
				case 0:
					return true;
				case 7:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				case 5:
					goto IL_00a0;
				case 8:
					goto IL_00b2;
				case 4:
					goto IL_00cb;
				case 3:
					return false;
				default:
					if (num3 >= ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count)
					{
						return false;
					}
					goto IL_00cb;
				}
				break;
				IL_00cb:
				actionElementMap2 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
				int num4;
				if (!skipDisabledMaps)
				{
					num = 1398417682;
					num4 = num;
				}
				else
				{
					num = 1398417695;
					num4 = num;
				}
				continue;
				IL_00a0:
				if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 1398417682;
					continue;
				}
				goto IL_00bd;
				IL_0046:
				if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 1398417689;
					continue;
				}
				goto IL_00f1;
				IL_00b2:
				if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
				goto IL_00bd;
				IL_00bd:
				num3++;
				num = 1398417691;
			}
			goto IL_000d;
			IL_00f1:
			if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
			{
				return false;
			}
			num3 = 0;
			num = 1398417691;
			goto IL_0012;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (base.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps)
			{
				goto IL_002a;
			}
			goto IL_0065;
			IL_0065:
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return false;
			}
			int num;
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num2 = default(int);
			if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
			{
				num = 2140904839;
			}
			else
			{
				elementAssignment = conflictCheck.ToElementAssignment();
				num2 = 0;
				num = 2140904833;
			}
			goto IL_002f;
			IL_005b:
			if (!_enabled)
			{
				return false;
			}
			goto IL_0065;
			IL_002a:
			num = 2140904837;
			goto IL_002f;
			IL_002f:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x7F9B9D84)
				{
				case 0:
					break;
				case 1:
					goto IL_005b;
				case 6:
					goto IL_0089;
				case 3:
					return false;
				case 4:
					goto IL_00b5;
				case 2:
					goto IL_00ce;
				default:
					if (num2 >= ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count)
					{
						return false;
					}
					goto IL_00ce;
				}
				break;
				IL_00ce:
				actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
				if (skipDisabledMaps)
				{
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 2140904832;
						continue;
					}
					goto IL_0094;
				}
				goto IL_00b5;
				IL_0094:
				num2++;
				num = 2140904833;
				continue;
				IL_0089:
				if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
				goto IL_0094;
				IL_00b5:
				if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV != conflictCheck.elementMapId)
				{
					num = 2140904834;
					continue;
				}
				goto IL_0094;
			}
			goto IL_002a;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			PpOkISumWjIivjPeUafJdCBaHwf ppOkISumWjIivjPeUafJdCBaHwf = new PpOkISumWjIivjPeUafJdCBaHwf(-2);
			ppOkISumWjIivjPeUafJdCBaHwf.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			ppOkISumWjIivjPeUafJdCBaHwf.dpEHnIOdFJcjTJXgjRwdzBylCqB = controllerMap;
			ppOkISumWjIivjPeUafJdCBaHwf.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
			return ppOkISumWjIivjPeUafJdCBaHwf;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			TOlAHZizOCzsPVxbKtwwPCndQKv tOlAHZizOCzsPVxbKtwwPCndQKv = new TOlAHZizOCzsPVxbKtwwPCndQKv(-2);
			tOlAHZizOCzsPVxbKtwwPCndQKv.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			tOlAHZizOCzsPVxbKtwwPCndQKv.dAuEWWkVFHeztWZBXuicejvoVSv = actionElementMap;
			tOlAHZizOCzsPVxbKtwwPCndQKv.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
			return tOlAHZizOCzsPVxbKtwwPCndQKv;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			ckKFAZCwjkVJgIshCZCsDXHSsCz ckKFAZCwjkVJgIshCZCsDXHSsCz2 = new ckKFAZCwjkVJgIshCZCsDXHSsCz(-2);
			while (true)
			{
				int num = 314997277;
				while (true)
				{
					switch (num ^ 0x12C67A1C)
					{
					case 0:
						break;
					case 1:
						goto IL_0026;
					default:
						return ckKFAZCwjkVJgIshCZCsDXHSsCz2;
					}
					break;
					IL_0026:
					ckKFAZCwjkVJgIshCZCsDXHSsCz2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					ckKFAZCwjkVJgIshCZCsDXHSsCz2.UQPnpLguhtCEkQPRaxuaPxhrRag = conflictCheck;
					ckKFAZCwjkVJgIshCZCsDXHSsCz2.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
					num = 314997278;
				}
			}
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_001c;
			}
			int num;
			int num2 = default(int);
			if (controllerMap == null)
			{
				num = -1066184026;
			}
			else
			{
				num2 = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
				num = -1066184032;
			}
			goto IL_0021;
			IL_001c:
			num = -1066184024;
			goto IL_0021;
			IL_0021:
			int num4 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			ControllerMapWithAxes controllerMapWithAxes = default(ControllerMapWithAxes);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				InputMapCategory mapCategory;
				int count2;
				switch (num ^ -1066184018)
				{
				case 15:
					break;
				case 11:
					num4 = 0;
					num = -1066184022;
					continue;
				case 13:
					actionElementMap = axisMaps[num4];
					if (skipDisabledMaps)
					{
						int num5;
						if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -1066184025;
							num5 = num;
						}
						else
						{
							num = -1066184021;
							num5 = num;
						}
						continue;
					}
					goto case 9;
				case 0:
					if (controllerMapWithAxes == null)
					{
						return num2;
					}
					if (skipDisabledMaps)
					{
						int num6;
						if (!_enabled)
						{
							num = -1066184019;
							num6 = num;
						}
						else
						{
							num = -1066184023;
							num6 = num;
						}
						continue;
					}
					goto IL_013e;
				case 12:
					actionElementMap2 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
					if (skipDisabledMaps)
					{
						int num8;
						if (!actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -1066184017;
							num8 = num;
						}
						else
						{
							num = -1066184027;
							num8 = num;
						}
						continue;
					}
					goto case 11;
				case 4:
				{
					int num7;
					if (num4 < count)
					{
						num = -1066184029;
						num7 = num;
					}
					else
					{
						num = -1066184017;
						num7 = num;
					}
					continue;
				}
				case 6:
					return 0;
				case 8:
					return 0;
				case 3:
					return num2;
				case 10:
					num = -1066184017;
					continue;
				case 1:
					num3--;
					num = -1066184020;
					continue;
				case 9:
					if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
					{
						dRWQkmnYrgqMFxVJnWUhrezoAuOi(actionElementMap2.KAixZgRycuVSHIYaEVNGzKGIdgV, num3);
						num2++;
						num = -1066184028;
						continue;
					}
					goto case 5;
				case 7:
					if (!controllerMapWithAxes._enabled)
					{
						num = -1066184019;
						continue;
					}
					goto IL_013e;
				case 5:
					num4++;
					num = -1066184022;
					continue;
				case 14:
					controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
					num = -1066184018;
					continue;
				default:
					{
						if (num3 < 0)
						{
							return num2;
						}
						goto case 12;
					}
					IL_013e:
					if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
					{
						return num2;
					}
					axisMaps = controllerMapWithAxes.AxisMaps;
					if (axisMaps == null)
					{
						return num2;
					}
					mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
					if (mapCategory != null && !mapCategory.userAssignable)
					{
						return num2;
					}
					count2 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
					count = axisMaps.Count;
					num3 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count - 1;
					num = -1066184020;
					continue;
				}
				break;
			}
			goto IL_001c;
		}

		public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				int num2 = -805808393;
				while (true)
				{
					InputMapCategory mapCategory;
					switch (num2 ^ -805808397)
					{
					case 9:
						break;
					case 2:
						num3--;
						num2 = -805808394;
						continue;
					case 5:
					{
						int num6;
						if (num3 < 0)
						{
							num2 = -805808395;
							num6 = num2;
						}
						else
						{
							num2 = -805808391;
							num6 = num2;
						}
						continue;
					}
					case 4:
						if (skipDisabledMaps)
						{
							int num5;
							if (_enabled)
							{
								num2 = -805808396;
								num5 = num2;
							}
							else
							{
								num2 = -805808397;
								num5 = num2;
							}
							continue;
						}
						goto IL_0117;
					case 1:
						num++;
						num2 = -805808399;
						continue;
					case 3:
						if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
						{
							dRWQkmnYrgqMFxVJnWUhrezoAuOi(actionElementMap2.KAixZgRycuVSHIYaEVNGzKGIdgV, num3);
							num2 = -805808398;
							continue;
						}
						goto case 2;
					case 7:
						if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num2 = -805808397;
							continue;
						}
						goto IL_0117;
					case 10:
						actionElementMap2 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
						if (skipDisabledMaps)
						{
							int num4;
							if (!actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = -805808399;
								num4 = num2;
							}
							else
							{
								num2 = -805808400;
								num4 = num2;
							}
							continue;
						}
						goto case 3;
					case 0:
						return num;
					case 8:
						num2 = -805808394;
						continue;
					default:
						{
							return num;
						}
						IL_0117:
						mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
						if (mapCategory == null)
						{
							return num;
						}
						if (!mapCategory.userAssignable)
						{
							return num;
						}
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
						{
							return num;
						}
						num3 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count - 1;
						num2 = -805808389;
						continue;
					}
					break;
				}
			}
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
			{
				return num;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			int num2;
			ElementAssignment elementAssignment = default(ElementAssignment);
			if (mapCategory == null)
			{
				num2 = -1666328974;
			}
			else if (!mapCategory.userAssignable)
			{
				num2 = -1666328970;
			}
			else
			{
				elementAssignment = conflictCheck.ToElementAssignment();
				num2 = -1666328964;
			}
			goto IL_0015;
			IL_0015:
			int num4 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ -1666328972)
				{
				case 5:
					break;
				case 0:
				{
					int num6;
					if (num4 >= 0)
					{
						num2 = -1666328963;
						num6 = num2;
					}
					else
					{
						num2 = -1666328969;
						num6 = num2;
					}
					continue;
				}
				case 9:
				{
					actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num4];
					int num5;
					if (skipDisabledMaps)
					{
						num2 = -1666328971;
						num5 = num2;
					}
					else
					{
						num2 = -1666328976;
						num5 = num2;
					}
					continue;
				}
				case 8:
					num4 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count - 1;
					num2 = -1666328972;
					continue;
				case 7:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				case 6:
					return num;
				case 2:
					return num;
				case 4:
					if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						dRWQkmnYrgqMFxVJnWUhrezoAuOi(actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV, num4);
						num++;
						num2 = -1666328962;
						continue;
					}
					goto case 10;
				case 1:
				{
					int num3;
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num2 = -1666328962;
						num3 = num2;
					}
					else
					{
						num2 = -1666328976;
						num3 = num2;
					}
					continue;
				}
				case 10:
					num4--;
					num2 = -1666328972;
					continue;
				default:
					return num;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num2 = -1666328973;
			goto IL_0015;
		}

		internal override int DisableElementAssignmentConflicts(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.DisableElementAssignmentConflicts(P_0, P_1, P_2, P_3);
			InputMapCategory mapCategory = default(InputMapCategory);
			int count = default(int);
			int count2 = default(int);
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			int num4 = default(int);
			ControllerMapWithAxes controllerMapWithAxes = default(ControllerMapWithAxes);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				int num2 = 1753225155;
				while (true)
				{
					switch (num2 ^ 0x688017CC)
					{
					case 20:
						break;
					case 14:
						if (mapCategory != null && !mapCategory.userAssignable)
						{
							return num;
						}
						count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
						count2 = axisMaps.Count;
						num2 = 1753225161;
						continue;
					case 12:
						return num;
					case 7:
						if (P_2 != null)
						{
							P_2.Add(actionElementMap);
							num2 = 1753225157;
							continue;
						}
						goto case 9;
					case 4:
						num3++;
						num2 = 1753225180;
						continue;
					case 13:
					{
						int num8;
						if (num4 >= count2)
						{
							num2 = 1753225160;
							num8 = num2;
						}
						else
						{
							num2 = 1753225166;
							num8 = num2;
						}
						continue;
					}
					case 15:
						controllerMapWithAxes = P_0 as ControllerMapWithAxes;
						num2 = 1753225159;
						continue;
					case 19:
					{
						int num6;
						if (actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							num2 = 1753225167;
							num6 = num2;
						}
						else
						{
							num2 = 1753225162;
							num6 = num2;
						}
						continue;
					}
					case 17:
						return num;
					case 5:
						num3 = 0;
						num2 = 1753225180;
						continue;
					case 0:
					{
						actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
						int num5;
						if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num2 = 1753225156;
							num5 = num2;
						}
						else
						{
							num2 = 1753225160;
							num5 = num2;
						}
						continue;
					}
					case 9:
						num++;
						num2 = 1753225160;
						continue;
					case 10:
						return num;
					case 3:
						actionElementMap.enabled = false;
						num2 = 1753225163;
						continue;
					case 8:
						num4 = 0;
						num2 = 1753225165;
						continue;
					case 2:
						actionElementMap2 = axisMaps[num4];
						if (P_1)
						{
							int num7;
							if (!actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = 1753225162;
								num7 = num2;
							}
							else
							{
								num2 = 1753225183;
								num7 = num2;
							}
							continue;
						}
						goto case 19;
					case 1:
						num2 = 1753225153;
						continue;
					case 6:
						num4++;
						num2 = 1753225153;
						continue;
					case 18:
						if (axisMaps != null)
						{
							mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
							num2 = 1753225154;
						}
						else
						{
							num2 = 1753225158;
						}
						continue;
					case 11:
						if (controllerMapWithAxes != null)
						{
							if (P_1)
							{
								if (!_enabled)
								{
									goto case 12;
								}
								if (!controllerMapWithAxes._enabled)
								{
									num2 = 1753225152;
									continue;
								}
							}
							if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
							{
								return num;
							}
							axisMaps = controllerMapWithAxes.AxisMaps;
							num2 = 1753225182;
						}
						else
						{
							num2 = 1753225181;
						}
						continue;
					default:
						if (num3 >= count)
						{
							return num;
						}
						goto case 0;
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
				if (!_enabled)
				{
					goto IL_00d2;
				}
				if (!P_0.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					goto IL_002d;
				}
			}
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
			int num4 = 1980166958;
			goto IL_0032;
			IL_002d:
			num4 = 1980166952;
			goto IL_0032;
			IL_0032:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num4 ^ 0x7606F32E)
				{
				case 4:
					break;
				case 8:
					num++;
					num4 = 1980166956;
					continue;
				case 0:
					goto IL_0071;
				case 3:
					P_2.Add(actionElementMap);
					num4 = 1980166950;
					continue;
				case 2:
					num3++;
					num4 = 1980166958;
					continue;
				case 5:
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc || !P_0.CheckForAssignmentConflict(actionElementMap))
					{
						goto case 2;
					}
					goto IL_00b3;
				case 6:
					goto IL_00d2;
				case 1:
					actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
					num4 = 1980166955;
					continue;
				default:
					return num;
				}
				break;
				IL_00b3:
				actionElementMap.enabled = false;
				int num5;
				if (P_2 != null)
				{
					num4 = 1980166957;
					num5 = num4;
				}
				else
				{
					num4 = 1980166950;
					num5 = num4;
				}
				continue;
				IL_0071:
				int num6;
				if (num3 >= num2)
				{
					num4 = 1980166953;
					num6 = num4;
				}
				else
				{
					num4 = 1980166959;
					num6 = num4;
				}
			}
			goto IL_002d;
			IL_00d2:
			return num;
		}

		internal override int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.DisableElementAssignmentConflicts(P_0, P_1, P_2, P_3);
			InputMapCategory mapCategory = default(InputMapCategory);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				int num2 = 256261126;
				while (true)
				{
					switch (num2 ^ 0xF463C05)
					{
					case 5:
						break;
					case 3:
						if (P_1 && !_enabled)
						{
							num2 = 256261132;
							continue;
						}
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
						{
							return num;
						}
						if (P_0.elementAssignmentType != ElementAssignmentType.FullAxis && P_0.elementAssignmentType != ElementAssignmentType.SplitAxis)
						{
							return num;
						}
						mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
						num2 = 256261122;
						continue;
					case 8:
					{
						int num5;
						if (!actionElementMap.CheckForAssignmentConflict(elementAssignment))
						{
							num2 = 256261125;
							num5 = num2;
						}
						else
						{
							num2 = 256261123;
							num5 = num2;
						}
						continue;
					}
					case 0:
						num3++;
						num2 = 256261134;
						continue;
					case 4:
						actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
						if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							int num6;
							if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV == P_0.elementMapId)
							{
								num2 = 256261125;
								num6 = num2;
							}
							else
							{
								num2 = 256261133;
								num6 = num2;
							}
							continue;
						}
						goto case 0;
					case 1:
					{
						int num4;
						if (P_2 == null)
						{
							num2 = 256261127;
							num4 = num2;
						}
						else
						{
							num2 = 256261135;
							num4 = num2;
						}
						continue;
					}
					case 10:
						P_2.Add(actionElementMap);
						num2 = 256261127;
						continue;
					case 7:
						if (mapCategory == null)
						{
							return num;
						}
						if (!mapCategory.userAssignable)
						{
							return num;
						}
						elementAssignment = P_0.ToElementAssignment();
						count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
						num3 = 0;
						num2 = 256261134;
						continue;
					case 6:
						actionElementMap.enabled = false;
						num2 = 256261124;
						continue;
					case 9:
						return num;
					case 2:
						num++;
						num2 = 256261125;
						continue;
					default:
						if (num3 >= count)
						{
							return num;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public string[] GetAxisNames()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<string>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2].FcZlvtEnXFMiEicBtcTcDitrjYGb;
					int num3 = -493978632;
					while (true)
					{
						switch (num3 ^ -493978631)
						{
						case 0:
							num3 = -493978630;
							continue;
						case 3:
							break;
						case 1:
							num2++;
							num3 = -493978629;
							continue;
						default:
							goto end_IL_0058;
						}
						break;
					}
					continue;
					end_IL_0058:
					break;
				}
			}
			return array;
		}

		internal override bool AddActionMapping_BeforeBake(ActionElementMap P_0)
		{
			if (base.AddActionMapping_BeforeBake(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementType))
			{
				return false;
			}
			NAtmUFIQVkJgfdgwQosNyJVbSOe(P_0);
			return true;
		}

		internal override int GetElementMaps_Append(List<ActionElementMap> P_0, bool P_1)
		{
			base.GetElementMaps_Append(P_0, P_1);
			int count = P_0.Count;
			int count2 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -882804693;
				while (true)
				{
					switch (num ^ -882804689)
					{
					case 2:
						break;
					case 4:
						count2 = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
						num2 = 0;
						num = -882804694;
						continue;
					case 3:
						if (P_1)
						{
							int num3;
							if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2].gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = -882804689;
								num3 = num;
							}
							else
							{
								num = -882804690;
								num3 = num;
							}
							continue;
						}
						goto case 0;
					case 1:
						num2++;
						num = -882804694;
						continue;
					case 0:
						P_0.Add(ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2]);
						num = -882804690;
						continue;
					default:
						if (num2 >= count2)
						{
							return P_0.Count - count;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		internal override ActionElementMap GetFirstElementMapWithMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap firstElementMapWithMapping = base.GetFirstElementMapWithMapping(P_0, P_1, P_2);
			int num2 = default(int);
			while (true)
			{
				int num = 1542861284;
				while (true)
				{
					switch (num ^ 0x5BF631E5)
					{
					case 2:
						break;
					case 1:
						if (firstElementMapWithMapping != null)
						{
							return firstElementMapWithMapping;
						}
						if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_2))
						{
							return null;
						}
						num2 = FirstIndexOfElementMapping(P_0, P_1, P_2);
						if (num2 < 0)
						{
							return null;
						}
						if (P_2 == ControllerElementType.Axis)
						{
							goto IL_004b;
						}
						throw new NotImplementedException();
					default:
						return ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
					}
					break;
					IL_004b:
					num = 1542861285;
				}
			}
		}

		internal override int GetElementMapsWithElementIdentifier(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			int count = default(int);
			int num4 = default(int);
			while (true)
			{
				IL_00b6:
				int num;
				if (P_2)
				{
					num = P_1.Count;
					goto IL_0074;
				}
				int num2 = -238997797;
				goto IL_0016;
				IL_0074:
				num3 = num;
				base.GetElementMapsWithElementIdentifier(P_0, P_1, P_2);
				if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
				{
					break;
				}
				count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
				num4 = 0;
				num2 = -238997794;
				goto IL_0016;
				IL_0016:
				while (true)
				{
					switch (num2 ^ -238997798)
					{
					case 0:
						num2 = -238997799;
						continue;
					case 2:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num4]._elementIdentifierId == P_0)
						{
							P_1.Add(ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num4]);
							num2 = -238997793;
							continue;
						}
						goto case 5;
					case 1:
						break;
					case 5:
						num4++;
						num2 = -238997794;
						continue;
					case 3:
						goto IL_00b6;
					default:
						if (num4 >= count)
						{
							return P_1.Count - num3;
						}
						goto case 2;
					}
					break;
				}
				num = 0;
				goto IL_0074;
			}
			return P_1.Count - num3;
		}

		internal override bool ContainsElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.ContainsElementMapping(P_0, P_1, P_2))
			{
				return true;
			}
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
				int num2 = default(int);
				while (true)
				{
					int num = 987304572;
					while (true)
					{
						switch (num ^ 0x3AD9127E)
						{
						case 6:
							break;
						case 2:
							num2 = 0;
							num = 987304570;
							continue;
						case 1:
							goto end_IL_0027;
						case 8:
							num = 987304574;
							continue;
						case 7:
							return true;
						case 4:
							goto IL_0087;
						case 3:
							goto IL_009c;
						case 5:
							goto IL_00ba;
						default:
							return false;
						}
						break;
						IL_00ba:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2]._elementIdentifierId == P_0)
						{
							num = 987304573;
							continue;
						}
						goto IL_007c;
						IL_007c:
						num2++;
						num = 987304570;
						continue;
						IL_009c:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2]._actionId == P_1)
						{
							num = 987304569;
							continue;
						}
						goto IL_007c;
						IL_0087:
						int num3;
						if (num2 < count)
						{
							num = 987304571;
							num3 = num;
						}
						else
						{
							num = 987304566;
							num3 = num;
						}
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			throw new NotImplementedException();
		}

		internal override int FirstIndexOfElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.FirstIndexOfElementMapping(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_2))
			{
				return -1;
			}
			if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int num3 = default(int);
				int count = default(int);
				while (true)
				{
					int num2 = 1496566968;
					while (true)
					{
						switch (num2 ^ 0x5933CCB9)
						{
						case 5:
							break;
						case 6:
							return num3;
						case 7:
							goto end_IL_0028;
						case 4:
							goto IL_0074;
						case 1:
							count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
							num2 = 1496566971;
							continue;
						case 0:
							if (num3 >= count)
							{
								num2 = 1496566970;
								continue;
							}
							goto IL_0074;
						case 2:
							num3 = 0;
							num2 = 1496566969;
							continue;
						default:
							return -1;
						}
						break;
						IL_0074:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3]._elementIdentifierId != P_0 || ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3]._actionId != P_1)
						{
							num3++;
							num2 = 1496566969;
						}
						else
						{
							num2 = 1496566975;
						}
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			throw new NotImplementedException();
		}

		internal int FYopIOTmJUboOKYEGbdlGYgfPUMQ(int P_0)
		{
			if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz == null)
			{
				return -1;
			}
			int count = ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Count;
			int num = 0;
			while (true)
			{
				int num2 = 437873631;
				while (true)
				{
					switch (num2 ^ 0x1A196BDE)
					{
					case 3:
						break;
					case 1:
						num2 = 437873630;
						continue;
					case 2:
						return num;
					case 4:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num].KAixZgRycuVSHIYaEVNGzKGIdgV != P_0)
						{
							num++;
							num2 = 437873630;
						}
						else
						{
							num2 = 437873628;
						}
						continue;
					default:
						if (num >= count)
						{
							return -1;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		internal int UQafBmOpdxYZIQbXvjpimuOonkb(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			goto IL_006b;
			IL_0003:
			int num = -975667583;
			goto IL_0008;
			IL_0008:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -975667578)
				{
				case 3:
					break;
				case 7:
					throw new ArgumentNullException("results");
				case 9:
					goto IL_0052;
				case 4:
					goto IL_006b;
				case 0:
					goto IL_007b;
				case 8:
					P_1.Add(actionElementMap);
					num4++;
					num = -975667577;
					continue;
				case 5:
					goto IL_00b4;
				case 6:
					num = -975667580;
					continue;
				case 1:
					num2++;
					num = -975667580;
					continue;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto IL_007b;
				}
				break;
				IL_007b:
				actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
				int num5;
				if (P_0)
				{
					num = -975667569;
					num5 = num;
				}
				else
				{
					num = -975667570;
					num5 = num;
				}
				continue;
				IL_0052:
				int num6;
				if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = -975667570;
					num6 = num;
				}
				else
				{
					num = -975667577;
					num6 = num;
				}
			}
			goto IL_0003;
			IL_00b4:
			num3 = axisMapCount;
			num4 = 0;
			num2 = 0;
			num = -975667584;
			goto IL_0008;
			IL_006b:
			if (!P_2)
			{
				P_1.Clear();
				num = -975667581;
				goto IL_0008;
			}
			goto IL_00b4;
		}

		internal int JWoVzAynstgsUWzdBFvHgVLSPoi(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				if (!P_3)
				{
					P_2.Clear();
					num = 57483717;
					goto IL_0013;
				}
				goto IL_0060;
				IL_0013:
				while (true)
				{
					switch (num ^ 0x36D21CD)
					{
					case 4:
						num = 57483724;
						continue;
					case 1:
						break;
					case 8:
						goto IL_0060;
					case 5:
						P_2.Add(actionElementMap);
						num4++;
						num = 57483725;
						continue;
					case 3:
						goto IL_0086;
					case 0:
						num2++;
						num = 57483722;
						continue;
					case 10:
						actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
						num = 57483726;
						continue;
					case 2:
						num = 57483722;
						continue;
					case 9:
						if (!P_1)
						{
							goto case 5;
						}
						goto IL_00d5;
					case 6:
						num4 = 0;
						num2 = 0;
						num = 57483727;
						continue;
					default:
						if (num2 >= num3)
						{
							return num4;
						}
						goto case 10;
					}
					break;
					IL_00d5:
					int num5;
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 57483720;
						num5 = num;
					}
					else
					{
						num = 57483725;
						num5 = num;
					}
					continue;
					IL_0086:
					int num6;
					if (actionElementMap._actionId != P_0)
					{
						num = 57483725;
						num6 = num;
					}
					else
					{
						num = 57483716;
						num6 = num;
					}
				}
				continue;
				IL_0060:
				if (P_0 < 0)
				{
					break;
				}
				num3 = axisMapCount;
				num = 57483723;
				goto IL_0013;
			}
			return 0;
		}

		internal override int GetElementMapsWithAction(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.GetElementMapsWithAction(P_0, P_1, P_2, P_3);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1095156921;
				while (true)
				{
					switch (num2 ^ 0x4146C4BB)
					{
					case 4:
						break;
					case 8:
						if (actionElementMap._actionId != P_0)
						{
							goto case 0;
						}
						if (P_1)
						{
							int num5;
							if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = 1095156923;
								num5 = num2;
							}
							else
							{
								num2 = 1095156920;
								num5 = num2;
							}
							continue;
						}
						goto case 3;
					case 6:
						if (P_0 < 0)
						{
							return num;
						}
						num4 = axisMapCount;
						num2 = 1095156922;
						continue;
					case 0:
						num3++;
						num2 = 1095156924;
						continue;
					case 5:
						actionElementMap = ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3];
						num2 = 1095156915;
						continue;
					case 2:
						if (!P_3)
						{
							P_2.Clear();
							num2 = 1095156925;
							continue;
						}
						goto case 6;
					case 3:
						P_2.Add(actionElementMap);
						num++;
						num2 = 1095156923;
						continue;
					case 1:
						num3 = 0;
						num2 = 1095156924;
						continue;
					default:
						if (num3 >= num4)
						{
							return num;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		internal override ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap firstElementMapWithElementTarget = base.GetFirstElementMapWithElementTarget(P_0, P_1, P_2, P_3, out P_4);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = -1023676021;
				while (true)
				{
					switch (num ^ -1023676017)
					{
					case 0:
						break;
					case 6:
						if (!P_3)
						{
							goto case 5;
						}
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2].gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -1023676022;
							continue;
						}
						goto IL_00b2;
					case 3:
						return null;
					case 7:
						num = -1023676019;
						continue;
					case 5:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2].IsTarget(P_0))
						{
							return ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2];
						}
						goto IL_00b2;
					case 4:
						if (firstElementMapWithElementTarget != null)
						{
							return firstElementMapWithElementTarget;
						}
						if (!P_4)
						{
							if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0.elementType))
							{
								return null;
							}
							num3 = axisMapCount;
							int elementIdentifierId = P_0.elementIdentifierId;
							num2 = 0;
							num = -1023676024;
						}
						else
						{
							num = -1023676020;
						}
						continue;
					case 1:
						if (!P_1)
						{
							goto case 6;
						}
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num2]._actionId == P_2)
						{
							num = -1023676023;
							continue;
						}
						goto IL_00b2;
					default:
						{
							if (num2 >= num3)
							{
								return null;
							}
							goto case 1;
						}
						IL_00b2:
						num2++;
						num = -1023676019;
						continue;
					}
					break;
				}
			}
		}

		internal override int GetElementMapsWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.GetElementMapsWithElementTarget(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = 984840940;
				while (true)
				{
					switch (num2 ^ 0x3AB37AED)
					{
					case 5:
						break;
					case 3:
						num3++;
						num2 = 984840937;
						continue;
					case 9:
						num2 = 984840937;
						continue;
					case 0:
						if (P_3)
						{
							int num6;
							if (!ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3].gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = 984840942;
								num6 = num2;
							}
							else
							{
								num2 = 984840934;
								num6 = num2;
							}
							continue;
						}
						goto case 11;
					case 1:
						if (P_6)
						{
							num2 = 984840933;
							continue;
						}
						if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0.elementType))
						{
							num2 = 984840938;
							continue;
						}
						num5 = axisMapCount;
						num2 = 984840939;
						continue;
					case 8:
						return num;
					case 6:
					{
						int elementIdentifierId = P_0.elementIdentifierId;
						num3 = 0;
						num2 = 984840932;
						continue;
					}
					case 7:
						return num;
					case 4:
					{
						int num7;
						if (num3 < num5)
						{
							num2 = 984840943;
							num7 = num2;
						}
						else
						{
							num2 = 984840935;
							num7 = num2;
						}
						continue;
					}
					case 2:
						if (P_1)
						{
							int num4;
							if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3]._actionId != P_2)
							{
								num2 = 984840942;
								num4 = num2;
							}
							else
							{
								num2 = 984840941;
								num4 = num2;
							}
							continue;
						}
						goto case 0;
					case 11:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3].IsTarget(P_0))
						{
							P_4.Add(ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3]);
							num++;
							num2 = 984840942;
							continue;
						}
						goto case 3;
					default:
						return num;
					}
					break;
				}
			}
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
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0._elementType))
			{
				return false;
			}
			ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Add(P_0);
			kHDMPMlaIVHtlZBBhMcCDjBjBPwI(P_0);
			return true;
		}

		private bool gfpRnucHhqKGhIOvKPuSfkLNcyE(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void dRWQkmnYrgqMFxVJnWUhrezoAuOi(int P_0, int P_1)
		{
			udQNkupzhbYmxPUEpZCAgqlazFz(P_0);
			while (true)
			{
				int num = 1787385649;
				while (true)
				{
					switch (num ^ 0x6A895730)
					{
					case 2:
						break;
					case 1:
						if (P_1 >= 0)
						{
							int num2;
							if (P_1 < axisMapCount)
							{
								num = 1787385648;
								num2 = num;
							}
							else
							{
								num = 1787385651;
								num2 = num;
							}
							continue;
						}
						return;
					case 3:
						return;
					default:
						ZPhbSkhrYKbvviOCcoZfUSvYBmWz.RemoveAt(P_1);
						return;
					}
					break;
				}
			}
		}

		private void NAtmUFIQVkJgfdgwQosNyJVbSOe(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = -76473981;
			goto IL_0008;
			IL_0008:
			switch (num ^ -76473982)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_002d;
			case 2:
				return;
			}
			goto IL_0003;
			IL_002d:
			ZPhbSkhrYKbvviOCcoZfUSvYBmWz.Add(P_0);
			kHDMPMlaIVHtlZBBhMcCDjBjBPwI(P_0);
			num = -76473984;
			goto IL_0008;
		}

		private void OxtguEMxjYYnrRUPBgsUQOOLFzOi(ActionElementMap P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (P_1 >= 0)
			{
				int num;
				int num2;
				if (P_1 >= axisMapCount)
				{
					num = 521483484;
					num2 = num;
				}
				else
				{
					num = 521483486;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x1F1534DC)
					{
					case 3:
						goto IL_0004;
					case 1:
						break;
					case 0:
						return;
					default:
						rVjdaWIUamskmtniHHVYvihwePYi(ZPhbSkhrYKbvviOCcoZfUSvYBmWz[P_1].KAixZgRycuVSHIYaEVNGzKGIdgV, P_0);
						ZPhbSkhrYKbvviOCcoZfUSvYBmWz[P_1] = P_0;
						return;
					}
					break;
					IL_0004:
					num = 521483485;
				}
			}
		}

		internal override void ExportDataToSerializedObject(SerializedObject P_0)
		{
			base.ExportDataToSerializedObject(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			int num3 = default(int);
			while (true)
			{
				int num2 = -1366496058;
				while (true)
				{
					switch (num2 ^ -1366496060)
					{
					case 3:
						break;
					case 2:
						num3 = 0;
						num2 = -1366496059;
						continue;
					case 4:
						if (ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3] != null)
						{
							list.Add(ZPhbSkhrYKbvviOCcoZfUSvYBmWz[num3].LxAJUQVkKiSNqkaHsfsZAlQLTqTK());
							num2 = -1366496060;
							continue;
						}
						goto case 0;
					case 0:
						num3++;
						num2 = -1366496059;
						continue;
					default:
						if (num3 >= num)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		internal override bool Import(SerializedObject P_0)
		{
			bool flag = base.Import(P_0);
			if (!flag)
			{
				ClearElementMaps();
				goto IL_0011;
			}
			goto IL_0078;
			IL_0078:
			SerializedObject value = null;
			int num = 1790232967;
			goto IL_0016;
			IL_0011:
			num = 1790232961;
			goto IL_0016;
			IL_0016:
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			SerializedObject value2 = default(SerializedObject);
			while (true)
			{
				switch (num ^ 0x6AB4C980)
				{
				case 9:
					break;
				case 1:
					flag = true;
					num = 1790232960;
					continue;
				case 7:
					if (P_0.TryGetDeserializedValueByRef("axisMaps", ref value) && value != null)
					{
						num2 = 0;
						num = 1790232964;
						continue;
					}
					goto default;
				case 0:
					goto IL_0078;
				case 6:
					num2++;
					num = 1790232964;
					continue;
				case 4:
					goto IL_008c;
				case 3:
					if (ActionElementMap.YuthJqnjOQMiolEvklDruXMdObP(actionElementMap))
					{
						NAtmUFIQVkJgfdgwQosNyJVbSOe(actionElementMap);
						num = 1790232966;
						continue;
					}
					goto case 6;
				case 2:
					actionElementMap = new ActionElementMap();
					actionElementMap.kLnQybMiVBnKwrnVkGeKjoKJKGa(value2);
					num = 1790232963;
					continue;
				case 5:
					if (value.TryGetDeserializedValue<SerializedObject>(num2, out value2))
					{
						goto case 2;
					}
					goto IL_00e8;
				default:
					return flag;
				}
				break;
				IL_00e8:
				int num3;
				if (value2 != null)
				{
					num = 1790232966;
					num3 = num;
				}
				else
				{
					num = 1790232962;
					num3 = num;
				}
				continue;
				IL_008c:
				int num4;
				if (num2 < value.count)
				{
					num = 1790232965;
					num4 = num;
				}
				else
				{
					num = 1790232968;
					num4 = num;
				}
			}
			goto IL_0011;
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> VHQLgKwmqCkCHIqetsnVehdVNDg(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> yhCKekJgZLSRBCRNiTWFYABfLdQ(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> qEhCQfYiNaajdGQFFHULKggTFvk(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
