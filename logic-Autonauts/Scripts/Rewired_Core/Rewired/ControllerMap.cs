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
		private class wLIrbkQlRLbWBEvbupPmmMdsIpob : IComparer<ActionElementMap>
		{
			public static wLIrbkQlRLbWBEvbupPmmMdsIpob gePIlGMmtUuQJnaTMLFTWnhtmcu;

			public static wLIrbkQlRLbWBEvbupPmmMdsIpob Default
			{
				get
				{
					return gePIlGMmtUuQJnaTMLFTWnhtmcu ?? (gePIlGMmtUuQJnaTMLFTWnhtmcu = new wLIrbkQlRLbWBEvbupPmmMdsIpob());
				}
			}

			public int Compare(ActionElementMap x, ActionElementMap y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				if (x._elementType == y._elementType)
				{
					goto IL_0020;
				}
				switch (x._elementType)
				{
				case ControllerElementType.CompoundElement:
					break;
				case ControllerElementType.Axis:
					goto IL_009b;
				default:
					goto IL_00d3;
				case ControllerElementType.Button:
					goto IL_00dd;
				}
				goto IL_0085;
				IL_00dd:
				int num = 0;
				int num2 = -2090747465;
				goto IL_0025;
				IL_009b:
				num = 1;
				num2 = -2090747465;
				goto IL_0025;
				IL_0085:
				num = 2;
				num2 = -2090747465;
				goto IL_0025;
				IL_00d3:
				num2 = -2090747471;
				goto IL_0025;
				IL_0020:
				num2 = -2090747458;
				goto IL_0025;
				IL_0025:
				ControllerElementType elementType = default(ControllerElementType);
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -2090747469)
					{
					case 14:
						break;
					case 15:
						if (elementType != ControllerElementType.CompoundElement)
						{
							num2 = -2090747470;
							continue;
						}
						goto case 9;
					case 7:
						goto IL_0085;
					case 1:
						throw new NotImplementedException();
					case 8:
						goto IL_009b;
					case 13:
						return x.id.CompareTo(y.id);
					case 6:
						goto IL_00dd;
					case 2:
						throw new NotImplementedException();
					case 12:
						num3 = 0;
						num2 = -2090747469;
						continue;
					case 10:
						goto IL_0105;
					case 9:
						num3 = 2;
						num2 = -2090747472;
						continue;
					case 0:
						goto IL_011d;
					case 4:
						elementType = y._elementType;
						switch (elementType)
						{
						case ControllerElementType.Button:
							break;
						case ControllerElementType.Axis:
							goto IL_0105;
						default:
							goto IL_0142;
						}
						goto case 12;
					case 11:
						num2 = -2090747469;
						continue;
					case 3:
						num2 = -2090747469;
						continue;
					default:
						{
							return -1;
						}
						IL_0142:
						num2 = -2090747460;
						continue;
						IL_0105:
						num3 = 1;
						num2 = -2090747464;
						continue;
					}
					break;
					IL_011d:
					if (num <= num3)
					{
						num2 = -2090747466;
						continue;
					}
					return 1;
				}
				goto IL_0020;
			}
		}

		private sealed class YEIUguRNhSUeVDgIZbiqwJIGauv : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

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
				if (Thread.CurrentThread.ManagedThreadId != iDzUuTsbdXLkIyEGCPmJzsmGhcs || LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
				{
					goto IL_0049;
				}
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
				YEIUguRNhSUeVDgIZbiqwJIGauv yEIUguRNhSUeVDgIZbiqwJIGauv = this;
				goto IL_0063;
				IL_002c:
				int num;
				while (true)
				{
					switch (num ^ -738958342)
					{
					case 0:
						num = -738958343;
						continue;
					case 3:
						break;
					case 1:
						goto IL_0063;
					default:
						return yEIUguRNhSUeVDgIZbiqwJIGauv;
					}
					break;
				}
				goto IL_0049;
				IL_0049:
				yEIUguRNhSUeVDgIZbiqwJIGauv = new YEIUguRNhSUeVDgIZbiqwJIGauv(0);
				yEIUguRNhSUeVDgIZbiqwJIGauv.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -738958341;
				goto IL_002c;
				IL_0063:
				yEIUguRNhSUeVDgIZbiqwJIGauv.hDvAMaTqLegLZzPsyeYTryTcCaC = lMvQGEdGoYKDXnJUDIpWwVzOVi;
				yEIUguRNhSUeVDgIZbiqwJIGauv.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
				num = -738958344;
				goto IL_002c;
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
						goto IL_006b;
					case 2:
						goto IL_00d3;
					default:
						goto IL_0138;
						IL_006b:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
						{
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 1912407246;
							goto IL_0023;
						}
						goto IL_009c;
						IL_00d3:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 1912407232;
						goto IL_0023;
						IL_009c:
						rNBGCwPCdUcwWCwIlQihKhDwFEGs = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.AllMaps.GetEnumerator();
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 1912407232;
						goto IL_0023;
						IL_0023:
						while (true)
						{
							switch (num ^ 0x71FD04C7)
							{
							case 8:
								num = 1912407233;
								continue;
							case 6:
								goto IL_006b;
							case 1:
								goto IL_009c;
							case 2:
								dJqhqTgmfWIlrYHVdMBrjxXuFVA();
								num = 1912407234;
								continue;
							case 12:
								goto IL_00d3;
							case 4:
								result = true;
								num = 1912407239;
								continue;
							case 11:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZuLBcXCEqWtvGQDcuwvoWKBgAfjG;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								num = 1912407235;
								continue;
							case 7:
								goto IL_010d;
							case 9:
								num = 1912407234;
								continue;
							case 5:
								goto IL_0138;
							case 0:
								break;
							case 10:
								if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
								{
									goto case 11;
								}
								goto IL_0158;
							case 13:
								goto IL_0179;
							case 3:
								break;
							}
							break;
							IL_0179:
							ZuLBcXCEqWtvGQDcuwvoWKBgAfjG = rNBGCwPCdUcwWCwIlQihKhDwFEGs.Current;
							int num2;
							if (ZuLBcXCEqWtvGQDcuwvoWKBgAfjG._actionId == hDvAMaTqLegLZzPsyeYTryTcCaC)
							{
								num = 1912407245;
								num2 = num;
							}
							else
							{
								num = 1912407232;
								num2 = num;
							}
							continue;
							IL_0158:
							int num3;
							if (ZuLBcXCEqWtvGQDcuwvoWKBgAfjG.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = 1912407244;
								num3 = num;
							}
							else
							{
								num = 1912407232;
								num3 = num;
							}
							continue;
							IL_010d:
							int num4;
							if (!rNBGCwPCdUcwWCwIlQihKhDwFEGs.MoveNext())
							{
								num = 1912407237;
								num4 = num;
							}
							else
							{
								num = 1912407242;
								num4 = num;
							}
						}
						break;
						IL_0138:
						result = false;
						num = 1912407236;
						goto IL_0023;
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
			public YEIUguRNhSUeVDgIZbiqwJIGauv(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void dJqhqTgmfWIlrYHVdMBrjxXuFVA()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (rNBGCwPCdUcwWCwIlQihKhDwFEGs == null)
				{
					return;
				}
				while (true)
				{
					int num = -305659267;
					while (true)
					{
						switch (num ^ -305659268)
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
						rNBGCwPCdUcwWCwIlQihKhDwFEGs.Dispose();
						num = -305659268;
					}
				}
			}
		}

		private sealed class EMuDIhhMQMeRGoyswefgfpFYcTI : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public IControllerElementTarget yTpclTGilwkctRfZRSWbqEDLYSX;

			public IControllerElementTarget KiFYlhhjZbNikEnaNHGLRlhmzJU;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public TempListPool.TList<ActionElementMap> FQrgSWIBdUNHAYsEqiEBNKoiXfS;

			public List<ActionElementMap> qCgeqQxnomhFBDhnKQFeqSjlqoU;

			public bool fHBaMMnFAQiQrbLnLlhPvfqhpaFC;

			public ActionElementMap vKjJJDaqXONYoZiGigcklpOlXRS;

			public List<ActionElementMap>.Enumerator RFMSOihuqTrTdCkWldZPxCqiKrg;

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
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0056;
				IL_0012:
				int num = 297876043;
				goto IL_0017;
				IL_0017:
				EMuDIhhMQMeRGoyswefgfpFYcTI eMuDIhhMQMeRGoyswefgfpFYcTI = default(EMuDIhhMQMeRGoyswefgfpFYcTI);
				while (true)
				{
					switch (num ^ 0x11C13A4A)
					{
					case 5:
						break;
					case 1:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							eMuDIhhMQMeRGoyswefgfpFYcTI = this;
							num = 297876040;
							continue;
						}
						goto IL_0056;
					case 0:
						goto IL_0056;
					case 3:
						eMuDIhhMQMeRGoyswefgfpFYcTI.yTpclTGilwkctRfZRSWbqEDLYSX = KiFYlhhjZbNikEnaNHGLRlhmzJU;
						eMuDIhhMQMeRGoyswefgfpFYcTI.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						num = 297876046;
						continue;
					case 2:
						num = 297876041;
						continue;
					default:
						return eMuDIhhMQMeRGoyswefgfpFYcTI;
					}
					break;
				}
				goto IL_0012;
				IL_0056:
				eMuDIhhMQMeRGoyswefgfpFYcTI = new EMuDIhhMQMeRGoyswefgfpFYcTI(0);
				eMuDIhhMQMeRGoyswefgfpFYcTI.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 297876041;
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
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = -1722163524;
						while (true)
						{
							switch (num ^ -1722163532)
							{
							case 5:
								break;
							case 3:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								num = -1722163530;
								continue;
							case 7:
								FQrgSWIBdUNHAYsEqiEBNKoiXfS = TempListPool.GetTList<ActionElementMap>();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1722163532;
								continue;
							case 9:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
								{
									ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
									num = -1722163522;
									continue;
								}
								goto case 7;
							case 0:
								qCgeqQxnomhFBDhnKQFeqSjlqoU = FQrgSWIBdUNHAYsEqiEBNKoiXfS.list;
								ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetElementMapsWithElementTarget(yTpclTGilwkctRfZRSWbqEDLYSX, false, -1, RKQUCYjAXkOQEvYPFrRsAzEcuaK, qCgeqQxnomhFBDhnKQFeqSjlqoU, false, out fHBaMMnFAQiQrbLnLlhPvfqhpaFC);
								RFMSOihuqTrTdCkWldZPxCqiKrg = qCgeqQxnomhFBDhnKQFeqSjlqoU.GetEnumerator();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								num = -1722163536;
								continue;
							case 1:
								vKjJJDaqXONYoZiGigcklpOlXRS = RFMSOihuqTrTdCkWldZPxCqiKrg.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = vKjJJDaqXONYoZiGigcklpOlXRS;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								return true;
							case 8:
								if (lzqgRXjFXvJPbHjfzyAmNfcqezXL != 0)
								{
									if (lzqgRXjFXvJPbHjfzyAmNfcqezXL != 3)
									{
										num = -1722163522;
										continue;
									}
									goto case 3;
								}
								goto case 9;
							case 4:
								num = -1722163530;
								continue;
							case 2:
								if (!RFMSOihuqTrTdCkWldZPxCqiKrg.MoveNext())
								{
									JNcEyeWmvozYfZFCpFNuLLDijCBI();
									num = -1722163534;
									continue;
								}
								goto case 1;
							case 6:
								ejSbLQgntSTgBlnAWfjoSKjyDiDF();
								num = -1722163522;
								continue;
							default:
								return false;
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
				case 3:
					try
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								JNcEyeWmvozYfZFCpFNuLLDijCBI();
							}
						}
						break;
					}
					finally
					{
						ejSbLQgntSTgBlnAWfjoSKjyDiDF();
					}
				}
			}

			[DebuggerHidden]
			public EMuDIhhMQMeRGoyswefgfpFYcTI(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void ejSbLQgntSTgBlnAWfjoSKjyDiDF()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				while (true)
				{
					int num = -1534117605;
					while (true)
					{
						switch (num ^ -1534117606)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (FQrgSWIBdUNHAYsEqiEBNKoiXfS != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						((IDisposable)FQrgSWIBdUNHAYsEqiEBNKoiXfS).Dispose();
						num = -1534117606;
					}
				}
			}

			private void JNcEyeWmvozYfZFCpFNuLLDijCBI()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
				((IDisposable)RFMSOihuqTrTdCkWldZPxCqiKrg/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class GmZncpQENCXBgXTtYIMuRsUmNdK : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public IControllerElementTarget yTpclTGilwkctRfZRSWbqEDLYSX;

			public IControllerElementTarget KiFYlhhjZbNikEnaNHGLRlhmzJU;

			public int hDvAMaTqLegLZzPsyeYTryTcCaC;

			public int lMvQGEdGoYKDXnJUDIpWwVzOVi;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public TempListPool.TList<ActionElementMap> UpDcZCdRFRVHhvZFSKYNbaUPQiRE;

			public List<ActionElementMap> lNngRbzpWmAreDgucIlTGNYIfsgA;

			public bool dixoKLwWFavlKaFeyAFkjHPTKWd;

			public ActionElementMap ROIAQqmuIOLPmWsDFnqKaIcGvuX;

			public List<ActionElementMap>.Enumerator CnoBfyrNEtAZwlNRolKAKkdfJFf;

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
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0087;
				IL_0012:
				int num = 1923594342;
				goto IL_0017;
				IL_0017:
				GmZncpQENCXBgXTtYIMuRsUmNdK gmZncpQENCXBgXTtYIMuRsUmNdK = default(GmZncpQENCXBgXTtYIMuRsUmNdK);
				while (true)
				{
					switch (num ^ 0x72A7B864)
					{
					case 0:
						break;
					case 1:
						gmZncpQENCXBgXTtYIMuRsUmNdK.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 1923594338;
						continue;
					case 3:
						gmZncpQENCXBgXTtYIMuRsUmNdK = this;
						num = 1923594338;
						continue;
					case 6:
						gmZncpQENCXBgXTtYIMuRsUmNdK.yTpclTGilwkctRfZRSWbqEDLYSX = KiFYlhhjZbNikEnaNHGLRlhmzJU;
						gmZncpQENCXBgXTtYIMuRsUmNdK.hDvAMaTqLegLZzPsyeYTryTcCaC = lMvQGEdGoYKDXnJUDIpWwVzOVi;
						gmZncpQENCXBgXTtYIMuRsUmNdK.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						num = 1923594337;
						continue;
					case 4:
						goto IL_0087;
					case 2:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = 1923594343;
							continue;
						}
						goto IL_0087;
					default:
						return gmZncpQENCXBgXTtYIMuRsUmNdK;
					}
					break;
				}
				goto IL_0012;
				IL_0087:
				gmZncpQENCXBgXTtYIMuRsUmNdK = new GmZncpQENCXBgXTtYIMuRsUmNdK(0);
				num = 1923594341;
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
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					if (lzqgRXjFXvJPbHjfzyAmNfcqezXL != 0)
					{
						goto IL_000e;
					}
					goto IL_014b;
					IL_000e:
					int num = 644065682;
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x2663A99A)
						{
						case 9:
							break;
						case 8:
							if (lzqgRXjFXvJPbHjfzyAmNfcqezXL != 3)
							{
								num = 644065680;
								continue;
							}
							goto case 2;
						case 3:
							ROIAQqmuIOLPmWsDFnqKaIcGvuX = CnoBfyrNEtAZwlNRolKAKkdfJFf.Current;
							num = 644065695;
							continue;
						case 4:
							goto IL_0075;
						case 5:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ROIAQqmuIOLPmWsDFnqKaIcGvuX;
							num = 644065691;
							continue;
						case 1:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
							return true;
						case 6:
							goto IL_0114;
						case 0:
							CQRLKixCRZsNcEjuFwEfMRVhCeB();
							dFHCmbtYybSfaXsUBamgCDGqAOXG();
							num = 644065680;
							continue;
						case 7:
							goto IL_014b;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
							num = 644065692;
							continue;
						default:
							return false;
						}
						break;
						IL_0114:
						int num2;
						if (CnoBfyrNEtAZwlNRolKAKkdfJFf.MoveNext())
						{
							num = 644065689;
							num2 = num;
						}
						else
						{
							num = 644065690;
							num2 = num;
						}
					}
					goto IL_000e;
					IL_014b:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 644065680;
						goto IL_0013;
					}
					goto IL_0075;
					IL_0075:
					UpDcZCdRFRVHhvZFSKYNbaUPQiRE = TempListPool.GetTList<ActionElementMap>();
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
					lNngRbzpWmAreDgucIlTGNYIfsgA = UpDcZCdRFRVHhvZFSKYNbaUPQiRE.list;
					ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetElementMapsWithElementTarget(yTpclTGilwkctRfZRSWbqEDLYSX, true, hDvAMaTqLegLZzPsyeYTryTcCaC, RKQUCYjAXkOQEvYPFrRsAzEcuaK, lNngRbzpWmAreDgucIlTGNYIfsgA, false, out dixoKLwWFavlKaFeyAFkjHPTKWd);
					CnoBfyrNEtAZwlNRolKAKkdfJFf = lNngRbzpWmAreDgucIlTGNYIfsgA.GetEnumerator();
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
					num = 644065692;
					goto IL_0013;
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
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -1704174960;
					while (true)
					{
						switch (num ^ -1704174959)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 1:
							case 2:
							case 3:
								try
								{
									int lzqgRXjFXvJPbHjfzyAmNfcqezXL2 = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
									while (true)
									{
										int num2 = -1704174960;
										while (true)
										{
											switch (num2 ^ -1704174959)
											{
											case 0:
												break;
											default:
												return;
											case 1:
												switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL2)
												{
												case 2:
												case 3:
													try
													{
														return;
													}
													finally
													{
														CQRLKixCRZsNcEjuFwEfMRVhCeB();
													}
												}
												goto IL_0076;
											case 2:
												return;
											}
											break;
											IL_0076:
											num2 = -1704174957;
										}
									}
								}
								finally
								{
									dFHCmbtYybSfaXsUBamgCDGqAOXG();
								}
							}
							goto IL_0039;
						case 0:
							return;
						}
						break;
						IL_0039:
						num = -1704174959;
					}
				}
			}

			[DebuggerHidden]
			public GmZncpQENCXBgXTtYIMuRsUmNdK(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void dFHCmbtYybSfaXsUBamgCDGqAOXG()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (UpDcZCdRFRVHhvZFSKYNbaUPQiRE != null)
				{
					((IDisposable)UpDcZCdRFRVHhvZFSKYNbaUPQiRE).Dispose();
				}
			}

			private void CQRLKixCRZsNcEjuFwEfMRVhCeB()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
				((IDisposable)CnoBfyrNEtAZwlNRolKAKkdfJFf/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class MdJySsICcqtzjdywGpaWwPUEBEN : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int hDvAMaTqLegLZzPsyeYTryTcCaC;

			public int lMvQGEdGoYKDXnJUDIpWwVzOVi;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public IList<ActionElementMap> FjcEmtDpyQdRVfMMVaowrEbijUP;

			public int DSzqeznJMthXjIavFJabxUnCKHK;

			public int jlMvTvxfwvCZlEduHkrByVsyFJq;

			public ActionElementMap bqItoAlOFtipHazpMyTOPrsBnVu;

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
				MdJySsICcqtzjdywGpaWwPUEBEN mdJySsICcqtzjdywGpaWwPUEBEN = default(MdJySsICcqtzjdywGpaWwPUEBEN);
				while (true)
				{
					switch (num ^ 0x4240CE6)
					{
					case 0:
						break;
					case 2:
						mdJySsICcqtzjdywGpaWwPUEBEN = this;
						num = 69471463;
						continue;
					case 3:
						goto IL_004e;
					default:
						mdJySsICcqtzjdywGpaWwPUEBEN.hDvAMaTqLegLZzPsyeYTryTcCaC = lMvQGEdGoYKDXnJUDIpWwVzOVi;
						mdJySsICcqtzjdywGpaWwPUEBEN.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return mdJySsICcqtzjdywGpaWwPUEBEN;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				mdJySsICcqtzjdywGpaWwPUEBEN = new MdJySsICcqtzjdywGpaWwPUEBEN(0);
				mdJySsICcqtzjdywGpaWwPUEBEN.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 69471463;
				goto IL_0028;
				IL_0023:
				num = 69471460;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = -1500470666;
					goto IL_001f;
				case 0:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -1500470658;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1500470668)
						{
						case 8:
							num = -1500470659;
							continue;
						case 4:
							return true;
						case 0:
							break;
						case 9:
							goto end_IL_001f;
						case 10:
							if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
							{
								ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -1500470671;
								continue;
							}
							goto case 6;
						case 11:
							goto IL_00c6;
						case 1:
							goto IL_0104;
						case 2:
							jlMvTvxfwvCZlEduHkrByVsyFJq++;
							num = -1500470669;
							continue;
						case 3:
							RDkWcsTpvDaNZojjIZONnoEBXPC = bqItoAlOFtipHazpMyTOPrsBnVu;
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							num = -1500470672;
							continue;
						case 6:
							if (hDvAMaTqLegLZzPsyeYTryTcCaC >= 0)
							{
								FjcEmtDpyQdRVfMMVaowrEbijUP = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.ButtonMaps;
								DSzqeznJMthXjIavFJabxUnCKHK = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttonMapCount;
								jlMvTvxfwvCZlEduHkrByVsyFJq = 0;
								num = -1500470669;
								continue;
							}
							goto end_IL_0008;
						case 7:
							goto IL_0196;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
						{
							num = -1500470665;
							num2 = num;
						}
						else
						{
							num = -1500470667;
							num2 = num;
						}
						continue;
						IL_0196:
						int num3;
						if (jlMvTvxfwvCZlEduHkrByVsyFJq >= DSzqeznJMthXjIavFJabxUnCKHK)
						{
							num = -1500470671;
							num3 = num;
						}
						else
						{
							num = -1500470657;
							num3 = num;
						}
						continue;
						IL_00c6:
						bqItoAlOFtipHazpMyTOPrsBnVu = FjcEmtDpyQdRVfMMVaowrEbijUP[jlMvTvxfwvCZlEduHkrByVsyFJq];
						int num4;
						if (bqItoAlOFtipHazpMyTOPrsBnVu._actionId == hDvAMaTqLegLZzPsyeYTryTcCaC)
						{
							num = -1500470668;
							num4 = num;
						}
						else
						{
							num = -1500470666;
							num4 = num;
						}
						continue;
						IL_0104:
						int num5;
						if (bqItoAlOFtipHazpMyTOPrsBnVu.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -1500470665;
							num5 = num;
						}
						else
						{
							num = -1500470666;
							num5 = num;
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
			public MdJySsICcqtzjdywGpaWwPUEBEN(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class eBWCFkURVSiUGYkrwOfFDuAYgel : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ControllerMap eRtoQSFdzNGKcVeofCcwFdixCwlq;

			public ControllerMap dpEHnIOdFJcjTJXgjRwdzBylCqB;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public IList<ActionElementMap> jrPNmMGnhnKALKTFImZHliRVWUa;

			public int MHkKzUMvxNrAfVfLZaHgHVAuFHC;

			public int woXaVpXfFZduViolayThoZTAUrK;

			public ActionElementMap FySpdRuESxTFmAPZEJlPESJEOWn;

			public int VkgMdGRNVgKBYKQxyIMJUnChdiN;

			public ActionElementMap RsKVmgyxTBUZGUkLekuAgAeHkhI;

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
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0064;
				IL_0012:
				int num = 1980987523;
				goto IL_0017;
				IL_0017:
				eBWCFkURVSiUGYkrwOfFDuAYgel eBWCFkURVSiUGYkrwOfFDuAYgel2 = default(eBWCFkURVSiUGYkrwOfFDuAYgel);
				while (true)
				{
					switch (num ^ 0x76137880)
					{
					case 4:
						break;
					case 3:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = 1980987520;
							continue;
						}
						goto IL_0064;
					case 5:
						num = 1980987521;
						continue;
					case 0:
						eBWCFkURVSiUGYkrwOfFDuAYgel2 = this;
						num = 1980987525;
						continue;
					case 2:
						goto IL_0064;
					default:
						eBWCFkURVSiUGYkrwOfFDuAYgel2.eRtoQSFdzNGKcVeofCcwFdixCwlq = dpEHnIOdFJcjTJXgjRwdzBylCqB;
						eBWCFkURVSiUGYkrwOfFDuAYgel2.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return eBWCFkURVSiUGYkrwOfFDuAYgel2;
					}
					break;
				}
				goto IL_0012;
				IL_0064:
				eBWCFkURVSiUGYkrwOfFDuAYgel2 = new eBWCFkURVSiUGYkrwOfFDuAYgel(0);
				eBWCFkURVSiUGYkrwOfFDuAYgel2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 1980987521;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				int num11;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				default:
					num = -737322305;
					goto IL_001a;
				case 0:
					goto IL_00ae;
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -737322312;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ -737322326)
						{
						case 19:
							break;
						case 9:
							if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								goto IL_008d;
							}
							goto case 5;
						case 4:
							goto IL_00ae;
						case 1:
							goto IL_00e2;
						case 21:
							num = -737322332;
							continue;
						case 15:
							goto IL_0108;
						case 5:
							jrPNmMGnhnKALKTFImZHliRVWUa = eRtoQSFdzNGKcVeofCcwFdixCwlq.ButtonMaps;
							if (jrPNmMGnhnKALKTFImZHliRVWUa != null)
							{
								MHkKzUMvxNrAfVfLZaHgHVAuFHC = jrPNmMGnhnKALKTFImZHliRVWUa.Count;
								num = -737322329;
								continue;
							}
							goto default;
						case 10:
							woXaVpXfFZduViolayThoZTAUrK++;
							num = -737322327;
							continue;
						case 12:
							num = -737322334;
							continue;
						case 16:
							RDkWcsTpvDaNZojjIZONnoEBXPC = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ZzSaCQHlhEgTijsOQGwUlyKTOzqG._categoryId).userAssignable, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerType, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerId, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._id, FySpdRuESxTFmAPZEJlPESJEOWn.KAixZgRycuVSHIYaEVNGzKGIdgV, FySpdRuESxTFmAPZEJlPESJEOWn._actionId, FySpdRuESxTFmAPZEJlPESJEOWn._elementType, FySpdRuESxTFmAPZEJlPESJEOWn._elementIdentifierId, FySpdRuESxTFmAPZEJlPESJEOWn.keyCode, FySpdRuESxTFmAPZEJlPESJEOWn.modifierKeyFlags);
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 17:
							goto IL_0226;
						case 0:
							FySpdRuESxTFmAPZEJlPESJEOWn = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt[woXaVpXfFZduViolayThoZTAUrK];
							if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								goto IL_026b;
							}
							goto case 7;
						case 7:
							VkgMdGRNVgKBYKQxyIMJUnChdiN = 0;
							num = -737322330;
							continue;
						case 8:
							goto IL_029d;
						case 20:
							RsKVmgyxTBUZGUkLekuAgAeHkhI = jrPNmMGnhnKALKTFImZHliRVWUa[VkgMdGRNVgKBYKQxyIMJUnChdiN];
							num = -737322328;
							continue;
						case 3:
							goto IL_02e0;
						case 6:
							goto IL_030c;
						case 11:
							goto IL_0333;
						case 18:
							VkgMdGRNVgKBYKQxyIMJUnChdiN++;
							num = -737322334;
							continue;
						case 13:
							woXaVpXfFZduViolayThoZTAUrK = 0;
							num = -737322327;
							continue;
						case 2:
							goto IL_037d;
						default:
							return false;
						}
						break;
						IL_037d:
						int num2;
						if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
						{
							num = -737322331;
							num2 = num;
						}
						else
						{
							num = -737322324;
							num2 = num;
						}
						continue;
						IL_0108:
						int num3;
						if (RsKVmgyxTBUZGUkLekuAgAeHkhI.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -737322324;
							num3 = num;
						}
						else
						{
							num = -737322312;
							num3 = num;
						}
						continue;
						IL_02e0:
						int num4;
						if (woXaVpXfFZduViolayThoZTAUrK >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt.Count)
						{
							num = -737322332;
							num4 = num;
						}
						else
						{
							num = -737322326;
							num4 = num;
						}
						continue;
						IL_0333:
						int num5;
						if (!eRtoQSFdzNGKcVeofCcwFdixCwlq._enabled)
						{
							num = -737322332;
							num5 = num;
						}
						else
						{
							num = -737322321;
							num5 = num;
						}
						continue;
						IL_026b:
						int num6;
						if (FySpdRuESxTFmAPZEJlPESJEOWn.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = -737322323;
							num6 = num;
						}
						else
						{
							num = -737322336;
							num6 = num;
						}
						continue;
						IL_008d:
						int num7;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG._enabled)
						{
							num = -737322335;
							num7 = num;
						}
						else
						{
							num = -737322332;
							num7 = num;
						}
						continue;
						IL_030c:
						int num8;
						if (!FySpdRuESxTFmAPZEJlPESJEOWn.CheckForAssignmentConflict(RsKVmgyxTBUZGUkLekuAgAeHkhI))
						{
							num = -737322312;
							num8 = num;
						}
						else
						{
							num = -737322310;
							num8 = num;
						}
						continue;
						IL_029d:
						int num9;
						if (VkgMdGRNVgKBYKQxyIMJUnChdiN >= MHkKzUMvxNrAfVfLZaHgHVAuFHC)
						{
							num = -737322336;
							num9 = num;
						}
						else
						{
							num = -737322306;
							num9 = num;
						}
						continue;
						IL_0226:
						int num10;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt != null)
						{
							num = -737322333;
							num10 = num;
						}
						else
						{
							num = -737322332;
							num10 = num;
						}
					}
					goto default;
					IL_00ae:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
						num = -737322332;
						goto IL_001a;
					}
					goto IL_00e2;
					IL_00e2:
					if (eRtoQSFdzNGKcVeofCcwFdixCwlq == null)
					{
						num = -737322332;
						num11 = num;
					}
					else
					{
						num = -737322309;
						num11 = num;
					}
					goto IL_001a;
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
			public eBWCFkURVSiUGYkrwOfFDuAYgel(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ZWOCgQLNYaNYvTJuQXoEciUBEBC : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ActionElementMap MzATACNcsUpFsuEcdOAkGvOQVeI;

			public ActionElementMap dAuEWWkVFHeztWZBXuicejvoVSv;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public int YmZytEfkkStZPBCpneASKGaVNnH;

			public ActionElementMap nOBvNTipMegXgCNBJDrWIZKazYi;

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
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_004b;
				IL_0012:
				int num = -253274927;
				goto IL_0017;
				IL_0017:
				ZWOCgQLNYaNYvTJuQXoEciUBEBC zWOCgQLNYaNYvTJuQXoEciUBEBC = default(ZWOCgQLNYaNYvTJuQXoEciUBEBC);
				while (true)
				{
					switch (num ^ -253274926)
					{
					case 0:
						break;
					case 2:
						zWOCgQLNYaNYvTJuQXoEciUBEBC.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -253274925;
						continue;
					case 4:
						goto IL_004b;
					case 3:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							zWOCgQLNYaNYvTJuQXoEciUBEBC = this;
							num = -253274925;
							continue;
						}
						goto IL_004b;
					default:
						zWOCgQLNYaNYvTJuQXoEciUBEBC.MzATACNcsUpFsuEcdOAkGvOQVeI = dAuEWWkVFHeztWZBXuicejvoVSv;
						zWOCgQLNYaNYvTJuQXoEciUBEBC.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return zWOCgQLNYaNYvTJuQXoEciUBEBC;
					}
					break;
				}
				goto IL_0012;
				IL_004b:
				zWOCgQLNYaNYvTJuQXoEciUBEBC = new ZWOCgQLNYaNYvTJuQXoEciUBEBC(0);
				num = -253274928;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = 159054317;
					while (true)
					{
						switch (num ^ 0x97AF9E8)
						{
						case 15:
							break;
						case 2:
							YmZytEfkkStZPBCpneASKGaVNnH++;
							num = 159054318;
							continue;
						case 6:
						{
							int num4;
							if (YmZytEfkkStZPBCpneASKGaVNnH < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt.Count)
							{
								num = 159054305;
								num4 = num;
							}
							else
							{
								num = 159054312;
								num4 = num;
							}
							continue;
						}
						case 3:
						{
							int num7;
							if (nOBvNTipMegXgCNBJDrWIZKazYi.CheckForAssignmentConflict(MzATACNcsUpFsuEcdOAkGvOQVeI))
							{
								num = 159054319;
								num7 = num;
							}
							else
							{
								num = 159054314;
								num7 = num;
							}
							continue;
						}
						case 16:
						{
							int num2;
							if (MzATACNcsUpFsuEcdOAkGvOQVeI.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = 159054310;
								num2 = num;
							}
							else
							{
								num = 159054312;
								num2 = num;
							}
							continue;
						}
						case 14:
							YmZytEfkkStZPBCpneASKGaVNnH = 0;
							num = 159054318;
							continue;
						case 4:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 159054307;
							continue;
						case 10:
						{
							int num5;
							if (nOBvNTipMegXgCNBJDrWIZKazYi.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = 159054315;
								num5 = num;
							}
							else
							{
								num = 159054314;
								num5 = num;
							}
							continue;
						}
						case 1:
						{
							int num8;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG._enabled)
							{
								num = 159054328;
								num8 = num;
							}
							else
							{
								num = 159054312;
								num8 = num;
							}
							continue;
						}
						case 8:
							if (MzATACNcsUpFsuEcdOAkGvOQVeI != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt != null)
							{
								int num6;
								if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
								{
									num = 159054310;
									num6 = num;
								}
								else
								{
									num = 159054313;
									num6 = num;
								}
								continue;
							}
							goto default;
						case 9:
						{
							nOBvNTipMegXgCNBJDrWIZKazYi = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt[YmZytEfkkStZPBCpneASKGaVNnH];
							int num3;
							if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								num = 159054306;
								num3 = num;
							}
							else
							{
								num = 159054315;
								num3 = num;
							}
							continue;
						}
						case 12:
							num = 159054312;
							continue;
						case 13:
							num = 159054312;
							continue;
						case 7:
							RDkWcsTpvDaNZojjIZONnoEBXPC = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ZzSaCQHlhEgTijsOQGwUlyKTOzqG._categoryId).userAssignable, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerType, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerId, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._id, nOBvNTipMegXgCNBJDrWIZKazYi.KAixZgRycuVSHIYaEVNGzKGIdgV, nOBvNTipMegXgCNBJDrWIZKazYi._actionId, nOBvNTipMegXgCNBJDrWIZKazYi._elementType, nOBvNTipMegXgCNBJDrWIZKazYi._elementIdentifierId, nOBvNTipMegXgCNBJDrWIZKazYi.keyCode, nOBvNTipMegXgCNBJDrWIZKazYi.modifierKeyFlags);
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 5:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								break;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 159054314;
								continue;
							default:
								num = 159054309;
								continue;
							}
							goto case 4;
						case 11:
							if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
							{
								ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 159054308;
								continue;
							}
							goto case 8;
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
			public ZWOCgQLNYaNYvTJuQXoEciUBEBC(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ELQVZFjsAHeyABBhIiEekhIgJHfB : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ElementAssignmentConflictCheck XoQvEtmGuEoQzAIlaNmgxPliHTu;

			public ElementAssignmentConflictCheck UQPnpLguhtCEkQPRaxuaPxhrRag;

			public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

			public bool AsggrPyUWCnFFjkCeamlXvALxt;

			public ElementAssignment UPDCfEAspbdKjHkxhBJNAtyRLhoD;

			public int jiAkIvoZDyLBycNRHyCIVHXRFsZ;

			public ActionElementMap baGThmbPDvGCKErDJcDynOIFJAK;

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
				goto IL_0052;
				IL_0028:
				int num;
				ELQVZFjsAHeyABBhIiEekhIgJHfB eLQVZFjsAHeyABBhIiEekhIgJHfB = default(ELQVZFjsAHeyABBhIiEekhIgJHfB);
				while (true)
				{
					switch (num ^ -1828117847)
					{
					case 2:
						break;
					case 1:
						eLQVZFjsAHeyABBhIiEekhIgJHfB = this;
						num = -1828117847;
						continue;
					case 4:
						goto IL_0052;
					case 0:
						eLQVZFjsAHeyABBhIiEekhIgJHfB.XoQvEtmGuEoQzAIlaNmgxPliHTu = UQPnpLguhtCEkQPRaxuaPxhrRag;
						num = -1828117846;
						continue;
					default:
						eLQVZFjsAHeyABBhIiEekhIgJHfB.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						return eLQVZFjsAHeyABBhIiEekhIgJHfB;
					}
					break;
				}
				goto IL_0023;
				IL_0052:
				eLQVZFjsAHeyABBhIiEekhIgJHfB = new ELQVZFjsAHeyABBhIiEekhIgJHfB(0);
				eLQVZFjsAHeyABBhIiEekhIgJHfB.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -1828117847;
				goto IL_0028;
				IL_0023:
				num = -1828117848;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				default:
					num = 544656163;
					goto IL_001a;
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = 544656167;
					goto IL_001a;
				case 0:
					goto IL_023f;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x2076CB21)
						{
						case 0:
							break;
						case 9:
							goto IL_005e;
						case 3:
							goto IL_0084;
						case 5:
							num = 544656169;
							continue;
						case 2:
							num = 544656169;
							continue;
						case 1:
							jiAkIvoZDyLBycNRHyCIVHXRFsZ = 0;
							num = 544656162;
							continue;
						case 11:
							goto IL_00d5;
						case 7:
							if (baGThmbPDvGCKErDJcDynOIFJAK.KAixZgRycuVSHIYaEVNGzKGIdgV != XoQvEtmGuEoQzAIlaNmgxPliHTu.elementMapId && baGThmbPDvGCKErDJcDynOIFJAK.CheckForAssignmentConflict(UPDCfEAspbdKjHkxhBJNAtyRLhoD))
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ZzSaCQHlhEgTijsOQGwUlyKTOzqG._categoryId).userAssignable, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerType, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._controllerId, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._id, baGThmbPDvGCKErDJcDynOIFJAK.KAixZgRycuVSHIYaEVNGzKGIdgV, baGThmbPDvGCKErDJcDynOIFJAK._actionId, baGThmbPDvGCKErDJcDynOIFJAK._elementType, baGThmbPDvGCKErDJcDynOIFJAK._elementIdentifierId, baGThmbPDvGCKErDJcDynOIFJAK.keyCode, baGThmbPDvGCKErDJcDynOIFJAK.modifierKeyFlags);
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							}
							goto case 6;
						case 12:
							if (!RKQUCYjAXkOQEvYPFrRsAzEcuaK)
							{
								goto case 7;
							}
							goto IL_01e0;
						case 6:
							jiAkIvoZDyLBycNRHyCIVHXRFsZ++;
							num = 544656162;
							continue;
						case 10:
							baGThmbPDvGCKErDJcDynOIFJAK = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt[jiAkIvoZDyLBycNRHyCIVHXRFsZ];
							num = 544656173;
							continue;
						case 4:
							goto IL_023f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_01e0:
						int num2;
						if (baGThmbPDvGCKErDJcDynOIFJAK.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num = 544656166;
							num2 = num;
						}
						else
						{
							num = 544656167;
							num2 = num;
						}
						continue;
						IL_0084:
						int num3;
						if (jiAkIvoZDyLBycNRHyCIVHXRFsZ < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt.Count)
						{
							num = 544656171;
							num3 = num;
						}
						else
						{
							num = 544656169;
							num3 = num;
						}
					}
					goto default;
					IL_023f:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 544656164;
						goto IL_001a;
					}
					goto IL_005e;
					IL_00d5:
					if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PioeGocjsgFCXBLzvVOeVwBrJevt == null)
					{
						break;
					}
					UPDCfEAspbdKjHkxhBJNAtyRLhoD = XoQvEtmGuEoQzAIlaNmgxPliHTu.ToElementAssignment();
					num = 544656160;
					goto IL_001a;
					IL_005e:
					if (RKQUCYjAXkOQEvYPFrRsAzEcuaK)
					{
						int num4;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG._enabled)
						{
							num = 544656170;
							num4 = num;
						}
						else
						{
							num = 544656169;
							num4 = num;
						}
						goto IL_001a;
					}
					goto IL_00d5;
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
			public ELQVZFjsAHeyABBhIiEekhIgJHfB(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

		private readonly AList<ActionElementMap> PioeGocjsgFCXBLzvVOeVwBrJevt;

		private readonly ReadOnlyCollection<ActionElementMap> LtBhVrBrfmibudLDebyVhJNhWXCw;

		private readonly AList<ActionElementMap> eagikhgBLGgDWavnxIFHHkyWQFp;

		private readonly ReadOnlyCollection<ActionElementMap> qmSQTaRoCBFbyqKDAoCfxsXgWLI;

		protected int _playerId;

		protected int _controllerId;

		protected ControllerType _controllerType;

		private static int TbDhfBsHjBGdJykcocaYNzEaReh;

		private static int nextUid
		{
			get
			{
				int tbDhfBsHjBGdJykcocaYNzEaReh = TbDhfBsHjBGdJykcocaYNzEaReh;
				if (TbDhfBsHjBGdJykcocaYNzEaReh == int.MaxValue)
				{
					TbDhfBsHjBGdJykcocaYNzEaReh = 0;
				}
				else
				{
					while (true)
					{
						TbDhfBsHjBGdJykcocaYNzEaReh++;
						int num = 2142157089;
						while (true)
						{
							switch (num ^ 0x7FAEB923)
							{
							case 0:
								num = 2142157090;
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
				return tbDhfBsHjBGdJykcocaYNzEaReh;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = 712490803;
						while (true)
						{
							switch (num ^ 0x2A77BF32)
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
							num = 712490802;
						}
					}
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return -1;
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return eagikhgBLGgDWavnxIFHHkyWQFp.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return PioeGocjsgFCXBLzvVOeVwBrJevt.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return qmSQTaRoCBFbyqKDAoCfxsXgWLI;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return LtBhVrBrfmibudLDebyVhJNhWXCw;
			}
		}

		internal AList<ActionElementMap> ButtonMaps_orig
		{
			get
			{
				return PioeGocjsgFCXBLzvVOeVwBrJevt;
			}
		}

		public ControllerMap()
		{
			_id = nextUid;
			_sourceMapId = -1;
			PioeGocjsgFCXBLzvVOeVwBrJevt = new AList<ActionElementMap>();
			LtBhVrBrfmibudLDebyVhJNhWXCw = new ReadOnlyCollection<ActionElementMap>(PioeGocjsgFCXBLzvVOeVwBrJevt);
			eagikhgBLGgDWavnxIFHHkyWQFp = new AList<ActionElementMap>();
			qmSQTaRoCBFbyqKDAoCfxsXgWLI = new ReadOnlyCollection<ActionElementMap>(eagikhgBLGgDWavnxIFHHkyWQFp);
			SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
		}

		public ControllerMap(ControllerMap source)
			: this()
		{
			_id = nextUid;
			_sourceMapId = source._sourceMapId;
			_categoryId = source._categoryId;
			_layoutId = source._layoutId;
			_name = source._name;
			_hardwareGuid = source._hardwareGuid;
			_enabled = source._enabled;
			_playerId = source._playerId;
			_controllerId = source._controllerId;
			_controllerType = source._controllerType;
			if (source.PioeGocjsgFCXBLzvVOeVwBrJevt != null)
			{
				int count = source.PioeGocjsgFCXBLzvVOeVwBrJevt.Count;
				for (int i = 0; i < count; i++)
				{
					QrBKEhqfnZFiWfSKQsgfyGtGEVE(new ActionElementMap(source.PioeGocjsgFCXBLzvVOeVwBrJevt[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (actionId < 0)
			{
				goto IL_001f;
			}
			int num = buttonMapCount;
			int num2 = 0;
			int num3 = -91091313;
			goto IL_0024;
			IL_0024:
			while (true)
			{
				switch (num3 ^ -91091313)
				{
				case 3:
					break;
				case 2:
					return false;
				case 1:
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2]._actionId != actionId)
					{
						goto IL_0069;
					}
					return true;
				default:
					if (num2 >= num)
					{
						return false;
					}
					goto case 1;
				}
				break;
				IL_0069:
				num2++;
				num3 = -91091313;
			}
			goto IL_001f;
			IL_001f:
			num3 = -91091315;
			goto IL_0024;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			AList<ActionElementMap> aList = eagikhgBLGgDWavnxIFHHkyWQFp;
			int num = 0;
			while (num < aList.Count)
			{
				while (true)
				{
					if (eagikhgBLGgDWavnxIFHHkyWQFp[num].elementIdentifierId == elementIdentifierId)
					{
						return true;
					}
					num++;
					int num2 = -1568915927;
					while (true)
					{
						switch (num2 ^ -1568915925)
						{
						case 0:
							num2 = -1568915926;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0044;
						}
						break;
					}
					continue;
					end_IL_0044:
					break;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			AList<ActionElementMap> aList = eagikhgBLGgDWavnxIFHHkyWQFp;
			int num = 1636025775;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x6183C5AC)
				{
				case 5:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				case 2:
					num = 1636025772;
					continue;
				case 3:
					num2 = 0;
					num = 1636025774;
					continue;
				case 4:
					if (eagikhgBLGgDWavnxIFHHkyWQFp[num2].keyCode == keyCode && eagikhgBLGgDWavnxIFHHkyWQFp[num2].modifierKeyFlags == modifierKeys)
					{
						return true;
					}
					num2++;
					num = 1636025772;
					continue;
				default:
					if (num2 >= aList.Count)
					{
						return false;
					}
					goto case 4;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 1636025773;
			goto IL_0012;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (elementMap == null)
			{
				goto IL_001e;
			}
			AList<ActionElementMap> aList = eagikhgBLGgDWavnxIFHHkyWQFp;
			int num = 0;
			int num2 = -1794961655;
			goto IL_0023;
			IL_0023:
			while (true)
			{
				switch (num2 ^ -1794961656)
				{
				case 0:
					break;
				case 3:
					return false;
				case 1:
				{
					int num3;
					if (num < aList.Count)
					{
						num2 = -1794961654;
						num3 = num2;
					}
					else
					{
						num2 = -1794961652;
						num3 = num2;
					}
					continue;
				}
				case 2:
					if (eagikhgBLGgDWavnxIFHHkyWQFp[num].KAixZgRycuVSHIYaEVNGzKGIdgV == elementMap.id)
					{
						return true;
					}
					num++;
					num2 = -1794961655;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_001e;
			IL_001e:
			num2 = -1794961653;
			goto IL_0023;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			AList<ActionElementMap> aList = eagikhgBLGgDWavnxIFHHkyWQFp;
			int num = 0;
			int num2 = 420206098;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x190BD612)
				{
				case 2:
					break;
				case 1:
					return false;
				case 3:
					if (eagikhgBLGgDWavnxIFHHkyWQFp[num].KAixZgRycuVSHIYaEVNGzKGIdgV != elementMapId)
					{
						goto IL_0063;
					}
					return true;
				default:
					if (num >= aList.Count)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_0063:
				num++;
				num2 = 420206098;
			}
			goto IL_0019;
			IL_0019:
			num2 = 420206099;
			goto IL_001e;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementAssignment.elementMapId);
			if (elementMap == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
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
					num = -1273716545;
					goto IL_0012;
				}
				throw new NotImplementedException();
			}
			goto IL_008b;
			IL_000d:
			num = -1273716548;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1273716547)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				return false;
			default:
				goto IL_008b;
			}
			goto IL_000d;
			IL_008b:
			return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, KVNLqybISELdZVRJeMgGCnyHIcv.tqXxoFypSRMjqbMSyPdRCcUlCPX(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				goto IL_001d;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.BakeActionElementMap(this, actionElementMap);
			int num = -301513703;
			goto IL_0022;
			IL_0022:
			switch (num ^ -301513704)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				QrBKEhqfnZFiWfSKQsgfyGtGEVE(actionElementMap);
				result = actionElementMap;
				return true;
			}
			goto IL_001d;
			IL_001d:
			num = -301513702;
			goto IL_0022;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = -1759919047;
					while (true)
					{
						switch (num ^ -1759919048)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						result = null;
						num = -1759919046;
					}
				}
			}
			uMjNfzSRUHmtmVcLMWHjlDVbxsX uMjNfzSRUHmtmVcLMWHjlDVbxsX2 = uMjNfzSRUHmtmVcLMWHjlDVbxsX.GfmBBOdBWBAJKCgHamBoQtPqQiti(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, uMjNfzSRUHmtmVcLMWHjlDVbxsX2.gWianwYlPTpUyiakpxkqBHyQIsw, uMjNfzSRUHmtmVcLMWHjlDVbxsX2.DhQEwkTxibArHJgkUgHzhoHRHFXw, uMjNfzSRUHmtmVcLMWHjlDVbxsX2.dCsxkoqMnFjzELpbGHaMzDGxaiu, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			QrBKEhqfnZFiWfSKQsgfyGtGEVE(actionElementMap);
			int num = 2038503899;
			goto IL_0012;
			IL_000d:
			num = 2038503900;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x798119D8)
				{
				case 2:
					break;
				case 3:
					result = actionElementMap;
					num = 2038503897;
					continue;
				case 0:
					result = null;
					return false;
				case 4:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = 2038503896;
					continue;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, KVNLqybISELdZVRJeMgGCnyHIcv.tqXxoFypSRMjqbMSyPdRCcUlCPX(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			int num;
			if (elementMap == null)
			{
				result = null;
				num = -1185490740;
			}
			else
			{
				int num2 = tkoKQpzVFmVQeufHwySksyFNoHJ(elementMapId);
				int num3;
				if (num2 < 0)
				{
					num = -1185490746;
					num3 = num;
				}
				else
				{
					num = -1185490751;
					num3 = num;
				}
			}
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1185490748)
				{
				case 6:
					break;
				case 5:
				{
					int num2 = tkoKQpzVFmVQeufHwySksyFNoHJ(elementMapId);
					if (num2 < 0)
					{
						result = null;
						return false;
					}
					elementMap.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					elementMap._actionId = actionId;
					num = -1185490748;
					continue;
				}
				case 7:
					QrBKEhqfnZFiWfSKQsgfyGtGEVE(elementMap);
					num = -1185490751;
					continue;
				case 4:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					result = null;
					num = -1185490745;
					continue;
				case 10:
					elementMap._modifierKey3 = modifierKey3;
					num = -1185490739;
					continue;
				case 1:
					elementMap._modifierKey2 = modifierKey2;
					num = -1185490738;
					continue;
				case 2:
					DeleteElementMap(elementMapId);
					elementMap._elementType = ControllerElementType.Button;
					num = -1185490749;
					continue;
				case 0:
					elementMap._elementType = ControllerElementType.Button;
					elementMap._axisContribution = axisContribution;
					elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
					elementMap._modifierKey1 = modifierKey1;
					num = -1185490747;
					continue;
				case 3:
					return false;
				case 8:
					return false;
				default:
					ReInput.controllers.Keyboard.BakeActionElementMap(this, elementMap);
					result = elementMap;
					return true;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -1185490752;
			goto IL_0015;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			uMjNfzSRUHmtmVcLMWHjlDVbxsX uMjNfzSRUHmtmVcLMWHjlDVbxsX2 = uMjNfzSRUHmtmVcLMWHjlDVbxsX.GfmBBOdBWBAJKCgHamBoQtPqQiti(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, uMjNfzSRUHmtmVcLMWHjlDVbxsX2.gWianwYlPTpUyiakpxkqBHyQIsw, uMjNfzSRUHmtmVcLMWHjlDVbxsX2.DhQEwkTxibArHJgkUgHzhoHRHFXw, uMjNfzSRUHmtmVcLMWHjlDVbxsX2.dCsxkoqMnFjzELpbGHaMzDGxaiu, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				result = null;
				return false;
			}
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				goto IL_003a;
			}
			int num;
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				QrBKEhqfnZFiWfSKQsgfyGtGEVE(elementMap);
				num = 312851565;
				goto IL_003f;
			}
			goto IL_00b5;
			IL_003a:
			num = 312851563;
			goto IL_003f;
			IL_00b5:
			int num2 = tkoKQpzVFmVQeufHwySksyFNoHJ(elementMapId);
			if (num2 >= 0)
			{
				CMutJYldqVFwACUDBjHKpaGMJfl(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
				BakeElementMap(elementMap);
				result = elementMap;
				num = 312851560;
			}
			else
			{
				result = null;
				num = 312851562;
			}
			goto IL_003f;
			IL_003f:
			switch (num ^ 0x12A5BC69)
			{
			case 0:
				break;
			case 2:
				result = null;
				return false;
			case 3:
				return false;
			case 4:
				goto IL_00b5;
			default:
				return true;
			}
			goto IL_003a;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int num = tkoKQpzVFmVQeufHwySksyFNoHJ(elementMapId);
			while (true)
			{
				int num2 = 1649706623;
				while (true)
				{
					switch (num2 ^ 0x6254867E)
					{
					case 2:
						break;
					case 1:
						if (num < 0)
						{
							num2 = 1649706622;
							continue;
						}
						tGfcYLadyDZRkEpeHYeWcClUIwM(elementMapId, num);
						num2 = 1649706621;
						continue;
					case 0:
						return false;
					default:
						return true;
					}
					break;
				}
			}
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			int num2 = default(int);
			int num3 = default(int);
			if (elementMapId < 0)
			{
				num = 1043296251;
			}
			else
			{
				num2 = buttonMapCount;
				num3 = 0;
				num = 1043296253;
			}
			goto IL_001e;
			IL_0019:
			num = 1043296254;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x3E2F6FFF)
				{
				case 0:
					break;
				case 1:
					return null;
				case 3:
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num3].KAixZgRycuVSHIYaEVNGzKGIdgV != elementMapId)
					{
						goto IL_006d;
					}
					return PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
				case 4:
					return null;
				default:
					if (num3 >= num2)
					{
						return null;
					}
					goto case 3;
				}
				break;
				IL_006d:
				num3++;
				num = 1043296253;
			}
			goto IL_0019;
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num = elementMapCount;
			int num2;
			if (num == 0)
			{
				num2 = 378400336;
				goto IL_001e;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			using (IEnumerator<ActionElementMap> enumerator = AllMaps.GetEnumerator())
			{
				ActionElementMap current = default(ActionElementMap);
				while (true)
				{
					IL_00c0:
					int num3;
					int num4;
					if (!enumerator.MoveNext())
					{
						num3 = 378400339;
						num4 = num3;
					}
					else
					{
						num3 = 378400337;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x168DEE50)
						{
						case 2:
							num3 = 378400337;
							continue;
						default:
							goto end_IL_006e;
						case 1:
							current = enumerator.Current;
							if (skipDisabledMaps)
							{
								int num5;
								if (!current.gmbIkkevNmPVGSTIwKcAwoPYANrc)
								{
									num3 = 378400340;
									num5 = num3;
								}
								else
								{
									num3 = 378400336;
									num5 = num3;
								}
								continue;
							}
							goto case 0;
						case 0:
							list.Add(current);
							num3 = 378400340;
							continue;
						case 4:
							break;
						case 3:
							goto end_IL_006e;
						}
						goto IL_00c0;
						continue;
						end_IL_006e:
						break;
					}
					break;
				}
			}
			return list.ToArray();
			IL_001e:
			switch (num2 ^ 0x168DEE50)
			{
			case 2:
				break;
			case 1:
				return EmptyObjects<ActionElementMap>.array;
			default:
				return EmptyObjects<ActionElementMap>.array;
			}
			goto IL_0019;
			IL_0019:
			num2 = 378400337;
			goto IL_001e;
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			if (results == null)
			{
				while (true)
				{
					switch (0x2CC00334 ^ 0x2CC00336)
					{
					case 0:
						continue;
					case 2:
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
			IEnumerator<ActionElementMap> enumerator = AllMaps.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						ActionElementMap current = enumerator.Current;
						if (current._actionId != actionId)
						{
							break;
						}
						int num2;
						int num3;
						if (!skipDisabledMaps)
						{
							num2 = 491495627;
							num3 = num2;
						}
						else
						{
							num2 = 491495625;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x1D4BA0CA)
							{
							case 0:
								num2 = 491495624;
								continue;
							case 1:
								num++;
								num2 = 491495630;
								continue;
							case 3:
								break;
							case 2:
								goto end_IL_004f;
							default:
								goto end_IL_0094;
							}
							int num4;
							if (!current.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = 491495630;
								num4 = num2;
							}
							else
							{
								num2 = 491495627;
								num4 = num2;
							}
							continue;
							end_IL_004f:
							break;
						}
						continue;
						end_IL_0094:
						break;
					}
				}
			}
			finally
			{
				if (enumerator != null)
				{
					while (true)
					{
						IL_00c8:
						int num5 = 491495624;
						while (true)
						{
							switch (num5 ^ 0x1D4BA0CA)
							{
							case 0:
								break;
							default:
								goto end_IL_00cd;
							case 2:
								goto IL_00e6;
							case 1:
								goto end_IL_00cd;
							}
							goto IL_00c8;
							IL_00e6:
							enumerator.Dispose();
							num5 = 491495627;
							continue;
							end_IL_00cd:
							break;
						}
						break;
					}
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num6 = 0;
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
						int num7;
						if (skipDisabledMaps)
						{
							int num8;
							if (!current2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num7 = 491495625;
								num8 = num7;
							}
							else
							{
								num7 = 491495630;
								num8 = num7;
							}
							goto IL_011c;
						}
						goto IL_016d;
						IL_016d:
						array[num6] = current2;
						num7 = 491495626;
						goto IL_011c;
						IL_011c:
						while (true)
						{
							switch (num7 ^ 0x1D4BA0CA)
							{
							case 2:
								num7 = 491495627;
								continue;
							case 1:
								break;
							case 4:
								goto IL_016d;
							case 0:
								num6++;
								num7 = 491495625;
								continue;
							default:
								goto end_IL_013d;
							}
							break;
						}
						continue;
						end_IL_013d:
						break;
					}
				}
				return array;
			}
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			YEIUguRNhSUeVDgIZbiqwJIGauv yEIUguRNhSUeVDgIZbiqwJIGauv = new YEIUguRNhSUeVDgIZbiqwJIGauv(-2);
			yEIUguRNhSUeVDgIZbiqwJIGauv.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			while (true)
			{
				int num = 1320549145;
				while (true)
				{
					switch (num ^ 0x4EB5FB1B)
					{
					case 0:
						break;
					case 2:
						goto IL_002d;
					default:
						yEIUguRNhSUeVDgIZbiqwJIGauv.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
						return yEIUguRNhSUeVDgIZbiqwJIGauv;
					}
					break;
					IL_002d:
					yEIUguRNhSUeVDgIZbiqwJIGauv.lMvQGEdGoYKDXnJUDIpWwVzOVi = actionId;
					num = 1320549146;
				}
			}
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			int num2 = 839342915;
			goto IL_0012;
			IL_000d:
			num2 = 839342917;
			goto IL_0012;
			IL_0012:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x32075B46)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				case 4:
					return PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
				case 5:
					num3 = 0;
					num2 = 839342912;
					continue;
				case 2:
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num3]._actionId == actionId)
					{
						if (!skipDisabledMaps)
						{
							goto case 4;
						}
						if (PioeGocjsgFCXBLzvVOeVwBrJevt[num3].gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num2 = 839342914;
							continue;
						}
					}
					num3++;
					num2 = 839342912;
					continue;
				case 6:
				{
					int num4;
					if (num3 < num)
					{
						num2 = 839342916;
						num4 = num2;
					}
					else
					{
						num2 = 839342919;
						num4 = num2;
					}
					continue;
				}
				default:
					return null;
				}
				break;
			}
			goto IL_000d;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(auqagPyfULkTIGtBZGYbYCoEQli2, skipDisabledMaps);
			auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			EMuDIhhMQMeRGoyswefgfpFYcTI eMuDIhhMQMeRGoyswefgfpFYcTI = new EMuDIhhMQMeRGoyswefgfpFYcTI(-2);
			eMuDIhhMQMeRGoyswefgfpFYcTI.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			eMuDIhhMQMeRGoyswefgfpFYcTI.KiFYlhhjZbNikEnaNHGLRlhmzJU = elementTarget;
			eMuDIhhMQMeRGoyswefgfpFYcTI.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
			return eMuDIhhMQMeRGoyswefgfpFYcTI;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			IEnumerable<ActionElementMap> result = default(IEnumerable<ActionElementMap>);
			while (true)
			{
				int num = 797794649;
				while (true)
				{
					switch (num ^ 0x2F8D6158)
					{
					case 0:
						break;
					case 1:
						result = ElementMapsWithElementTarget(auqagPyfULkTIGtBZGYbYCoEQli2, actionId, skipDisabledMaps);
						num = 797794651;
						continue;
					case 3:
						auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
						num = 797794650;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			GmZncpQENCXBgXTtYIMuRsUmNdK gmZncpQENCXBgXTtYIMuRsUmNdK = new GmZncpQENCXBgXTtYIMuRsUmNdK(-2);
			gmZncpQENCXBgXTtYIMuRsUmNdK.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			gmZncpQENCXBgXTtYIMuRsUmNdK.KiFYlhhjZbNikEnaNHGLRlhmzJU = elementTarget;
			while (true)
			{
				int num = 649383178;
				while (true)
				{
					switch (num ^ 0x26B4CD08)
					{
					case 0:
						break;
					case 2:
						goto IL_0034;
					default:
						return gmZncpQENCXBgXTtYIMuRsUmNdK;
					}
					break;
					IL_0034:
					gmZncpQENCXBgXTtYIMuRsUmNdK.lMvQGEdGoYKDXnJUDIpWwVzOVi = actionId;
					gmZncpQENCXBgXTtYIMuRsUmNdK.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
					num = 649383177;
				}
			}
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(auqagPyfULkTIGtBZGYbYCoEQli2, skipDisabledMaps);
			auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			bool flag;
			return GetFirstElementMapWithElementTarget(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			int num = 128073916;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x7A240BD)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
			{
				ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(auqagPyfULkTIGtBZGYbYCoEQli2, actionId, skipDisabledMaps);
				auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
				return firstElementMapWithElementTarget;
			}
			}
			goto IL_0019;
			IL_0019:
			num = 128073919;
			goto IL_001e;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			int num = 1972913846;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x759846B6)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			default:
				return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}
			goto IL_000d;
			IL_000d:
			num = 1972913847;
			goto IL_0012;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			bool flag;
			return GetFirstElementMapWithElementTarget(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(auqagPyfULkTIGtBZGYbYCoEQli2, skipDisabledMaps, results);
			int num = -1933845103;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1933845103)
				{
				case 3:
					break;
				case 1:
					return 0;
				case 0:
					goto IL_0055;
				default:
					return elementMapsWithElementTarget;
				}
				break;
				IL_0055:
				auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
				num = -1933845101;
			}
			goto IL_0019;
			IL_0019:
			num = -1933845104;
			goto IL_001e;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			bool flag;
			return GetElementMapsWithElementTarget(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(auqagPyfULkTIGtBZGYbYCoEQli2, actionId, skipDisabledMaps, results);
			auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = 241405289;
					while (true)
					{
						switch (num ^ 0xE638D6B)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return 0;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 241405290;
					}
				}
			}
			bool flag;
			return GetElementMapsWithElementTarget(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = 501166471;
					while (true)
					{
						switch (num ^ 0x1DDF3186)
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
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 501166470;
					}
				}
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return GetFirstElementMapMatch(predicate, false);
		}

		internal virtual ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return RGaBKvFAkDgfISXRUuNIxGhHxtA(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return GetElementMapMatches(predicate, false, results, false);
		}

		internal virtual int GetElementMapMatches(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return dRWnvheqcJKvidnVipVYcQyXbmGA(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					switch (-801965084 ^ -801965088)
					{
					case 0:
						break;
					case 3:
						goto end_IL_000d;
					case 1:
						goto IL_0048;
					case 4:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return;
					default:
						goto IL_0071;
					}
					continue;
					end_IL_000d:
					break;
				}
				goto IL_0033;
			}
			goto IL_0048;
			IL_0033:
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_0071;
			IL_0048:
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			goto IL_0033;
			IL_0071:
			int count = eagikhgBLGgDWavnxIFHHkyWQFp.Count;
			try
			{
				int num = 0;
				ActionElementMap obj = default(ActionElementMap);
				while (true)
				{
					int num2;
					int num3;
					if (num < count)
					{
						num2 = -801965086;
						num3 = num2;
					}
					else
					{
						num2 = -801965088;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -801965088)
						{
						case 6:
							num2 = -801965086;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
						{
							int num4;
							if (!predicate(obj))
							{
								num2 = -801965084;
								num4 = num2;
							}
							else
							{
								num2 = -801965083;
								num4 = num2;
							}
							continue;
						}
						case 4:
							num++;
							num2 = -801965087;
							continue;
						case 5:
							actionToPerform(obj);
							num2 = -801965084;
							continue;
						case 2:
							obj = eagikhgBLGgDWavnxIFHHkyWQFp[num];
							num2 = -801965085;
							continue;
						case 0:
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			while (true)
			{
				PioeGocjsgFCXBLzvVOeVwBrJevt.Clear();
				eagikhgBLGgDWavnxIFHHkyWQFp.Clear();
				int num = -1172861098;
				while (true)
				{
					switch (num ^ -1172861098)
					{
					case 2:
						goto IL_001a;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_001a:
					num = -1172861097;
				}
			}
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num = 0;
			int count = eagikhgBLGgDWavnxIFHHkyWQFp.Count;
			int num2 = 0;
			int num3 = 1987166795;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num3 ^ 0x7671C24A)
				{
				case 6:
					break;
				case 2:
					num2++;
					num3 = 1987166795;
					continue;
				case 1:
				{
					int num4;
					if (num2 < count)
					{
						num3 = 1987166793;
						num4 = num3;
					}
					else
					{
						num3 = 1987166794;
						num4 = num3;
					}
					continue;
				}
				case 4:
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc != state)
					{
						actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc = state;
						num++;
						num3 = 1987166792;
						continue;
					}
					goto case 2;
				case 5:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				case 3:
					actionElementMap = eagikhgBLGgDWavnxIFHHkyWQFp[num2];
					num3 = 1987166798;
					continue;
				default:
					return num;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num3 = 1987166799;
			goto IL_0012;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (PioeGocjsgFCXBLzvVOeVwBrJevt != null && index >= 0)
			{
				if (index >= PioeGocjsgFCXBLzvVOeVwBrJevt.Count)
				{
					num = 2141118804;
					goto IL_0012;
				}
				return PioeGocjsgFCXBLzvVOeVwBrJevt[index];
			}
			goto IL_0065;
			IL_0065:
			return null;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x7F9EE155)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = 2141118806;
					continue;
				case 3:
					return null;
				default:
					goto IL_0065;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 2141118807;
			goto IL_0012;
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(PioeGocjsgFCXBLzvVOeVwBrJevt);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = PioeGocjsgFCXBLzvVOeVwBrJevt.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			int num = 0;
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = 603413621;
					num3 = num2;
				}
				else
				{
					num2 = 603413618;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x23F75C71)
					{
					case 5:
						num2 = 603413618;
						continue;
					case 1:
						num++;
						num2 = 603413617;
						continue;
					case 2:
						list.Add(actionElementMap);
						num2 = 603413616;
						continue;
					case 3:
						actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num];
						if (skipDisabledMaps)
						{
							int num4;
							if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num2 = 603413616;
								num4 = num2;
							}
							else
							{
								num2 = 603413619;
								num4 = num2;
							}
							continue;
						}
						goto case 2;
					case 0:
						break;
					default:
						return list.ToArray();
					}
					break;
				}
			}
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return PaablZAXKaYQUGnfsHybeSmsOhbe(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				goto IL_002c;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 2141485409;
			goto IL_0031;
			IL_0031:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num6 = default(int);
			int num7 = default(int);
			ActionElementMap[] array = default(ActionElementMap[]);
			while (true)
			{
				switch (num4 ^ 0x7FA4796A)
				{
				case 14:
					break;
				case 9:
					if (actionElementMap2._actionId != actionId)
					{
						goto case 5;
					}
					if (skipDisabledMaps)
					{
						int num9;
						if (!actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num4 = 2141485423;
							num9 = num4;
						}
						else
						{
							num4 = 2141485413;
							num9 = num4;
						}
						continue;
					}
					goto case 15;
				case 11:
				{
					int num11;
					if (num3 >= num)
					{
						num4 = 2141485418;
						num11 = num4;
					}
					else
					{
						num4 = 2141485410;
						num11 = num4;
					}
					continue;
				}
				case 13:
					return EmptyObjects<ActionElementMap>.array;
				case 8:
					actionElementMap2 = PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
					num4 = 2141485411;
					continue;
				case 1:
				{
					int num5;
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num4 = 2141485416;
						num5 = num4;
					}
					else
					{
						num4 = 2141485420;
						num5 = num4;
					}
					continue;
				}
				case 4:
					num6 = 0;
					num7 = 0;
					num4 = 2141485417;
					continue;
				case 3:
				{
					int num10;
					if (num7 >= num)
					{
						num4 = 2141485414;
						num10 = num4;
					}
					else
					{
						num4 = 2141485421;
						num10 = num4;
					}
					continue;
				}
				case 5:
					num3++;
					num4 = 2141485409;
					continue;
				case 2:
					array[num6] = actionElementMap;
					num4 = 2141485408;
					continue;
				case 6:
					num7++;
					num4 = 2141485417;
					continue;
				case 7:
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num7];
					if (actionElementMap._actionId == actionId)
					{
						int num8;
						if (skipDisabledMaps)
						{
							num4 = 2141485419;
							num8 = num4;
						}
						else
						{
							num4 = 2141485416;
							num8 = num4;
						}
						continue;
					}
					goto case 6;
				case 15:
					num2++;
					num4 = 2141485423;
					continue;
				case 10:
					num6++;
					num4 = 2141485420;
					continue;
				case 0:
					if (num2 == 0)
					{
						return EmptyObjects<ActionElementMap>.array;
					}
					array = new ActionElementMap[num2];
					num4 = 2141485422;
					continue;
				default:
					return array;
				}
				break;
			}
			goto IL_002c;
			IL_002c:
			num4 = 2141485415;
			goto IL_0031;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			int num;
			if (inputAction == null)
			{
				num = 1389118223;
				goto IL_0012;
			}
			return GetButtonMapsWithAction(inputAction.id, results);
			IL_000d:
			num = 1389118222;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x52CC430F)
				{
				case 3:
					break;
				case 1:
					goto IL_002f;
				case 2:
					return 0;
				default:
					ListTools.TryClear(results);
					return 0;
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				num = 1389118221;
			}
			goto IL_000d;
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.aOPpCNUcjpGHQGAwmiMbcBLiLlOK(actionName, true);
			int num;
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				num = 1860899266;
				goto IL_0012;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
			IL_000d:
			num = 1860899265;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x6EEB11C0)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			default:
				return 0;
			}
			goto IL_000d;
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return TqINzOXHPesSFSrUfMuwCzFfcdY(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return ButtonMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			MdJySsICcqtzjdywGpaWwPUEBEN mdJySsICcqtzjdywGpaWwPUEBEN = new MdJySsICcqtzjdywGpaWwPUEBEN(-2);
			mdJySsICcqtzjdywGpaWwPUEBEN.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			mdJySsICcqtzjdywGpaWwPUEBEN.lMvQGEdGoYKDXnJUDIpWwVzOVi = actionId;
			while (true)
			{
				int num = 1397142674;
				while (true)
				{
					switch (num ^ 0x5346B493)
					{
					case 0:
						break;
					case 1:
						goto IL_0034;
					default:
						return mdJySsICcqtzjdywGpaWwPUEBEN;
					}
					break;
					IL_0034:
					mdJySsICcqtzjdywGpaWwPUEBEN.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
					num = 1397142673;
				}
			}
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = -169719609;
					while (true)
					{
						switch (num ^ -169719610)
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
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = -169719612;
					}
				}
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
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
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = 840062323;
			goto IL_0024;
			IL_0024:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x32125571)
				{
				case 7:
					break;
				case 1:
					actionElementMap = buttonMaps[num2];
					if (actionElementMap._actionId == actionId)
					{
						int num4;
						if (skipDisabledMaps)
						{
							num = 840062322;
							num4 = num;
						}
						else
						{
							num = 840062325;
							num4 = num;
						}
						continue;
					}
					goto IL_008a;
				case 2:
					num3 = buttonMapCount;
					num = 840062324;
					continue;
				case 4:
					return actionElementMap;
				case 8:
					return null;
				case 5:
					num2 = 0;
					num = 840062321;
					continue;
				case 3:
					if (actionElementMap.enabled)
					{
						num = 840062325;
						continue;
					}
					goto IL_008a;
				case 0:
					num = 840062327;
					continue;
				default:
					{
						if (num2 >= num3)
						{
							return null;
						}
						goto case 1;
					}
					IL_008a:
					num2++;
					num = 840062327;
					continue;
				}
				break;
			}
			goto IL_001f;
			IL_001f:
			num = 840062329;
			goto IL_0024;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int actionId = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return RGaBKvFAkDgfISXRUuNIxGhHxtA(predicate, false);
		}

		internal ActionElementMap RGaBKvFAkDgfISXRUuNIxGhHxtA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				ActionElementMap actionElementMap = default(ActionElementMap);
				while (true)
				{
					IL_00c1:
					int num3;
					int num4;
					if (num2 < num)
					{
						num3 = -1754813276;
						num4 = num3;
					}
					else
					{
						num3 = -1754813273;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ -1754813275)
						{
						case 6:
							num3 = -1754813276;
							continue;
						default:
							goto end_IL_0043;
						case 0:
							num2++;
							num3 = -1754813279;
							continue;
						case 5:
						{
							int num6;
							if (actionElementMap.enabled)
							{
								num3 = -1754813274;
								num6 = num3;
							}
							else
							{
								num3 = -1754813275;
								num6 = num3;
							}
							continue;
						}
						case 3:
							if (P_0(actionElementMap))
							{
								return actionElementMap;
							}
							goto case 0;
						case 1:
						{
							actionElementMap = buttonMaps[num2];
							int num5;
							if (P_1)
							{
								num3 = -1754813280;
								num5 = num3;
							}
							else
							{
								num3 = -1754813274;
								num5 = num3;
							}
							continue;
						}
						case 4:
							break;
						case 2:
							goto end_IL_0043;
						}
						goto IL_00c1;
						continue;
						end_IL_0043:
						break;
					}
					break;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return dRWnvheqcJKvidnVipVYcQyXbmGA(predicate, false, results, false);
		}

		internal int dRWnvheqcJKvidnVipVYcQyXbmGA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0042;
			IL_0003:
			int num = 425786073;
			goto IL_0008;
			IL_0008:
			int num6 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x1960FADC)
				{
				case 0:
					break;
				case 2:
					P_2.Clear();
					num = 425786074;
					continue;
				case 4:
					goto IL_0042;
				case 7:
					goto IL_0057;
				case 6:
					num = 425786079;
					continue;
				case 5:
					throw new ArgumentNullException("predicate");
				case 1:
					num6 = P_2.Count;
					num = 425786079;
					continue;
				default:
				{
					IList<ActionElementMap> buttonMaps = ButtonMaps;
					int num2 = buttonMapCount;
					try
					{
						int num3 = 0;
						while (true)
						{
							IL_00a8:
							int num4 = 425786077;
							while (true)
							{
								switch (num4 ^ 0x1960FADC)
								{
								case 0:
									break;
								case 1:
									num4 = 425786073;
									continue;
								case 3:
									num3++;
									num4 = 425786073;
									continue;
								case 4:
									if (P_0(actionElementMap))
									{
										P_2.Add(actionElementMap);
										num4 = 425786079;
										continue;
									}
									goto case 3;
								case 2:
									actionElementMap = buttonMaps[num3];
									if (P_1)
									{
										int num5;
										if (actionElementMap.enabled)
										{
											num4 = 425786072;
											num5 = num4;
										}
										else
										{
											num4 = 425786079;
											num5 = num4;
										}
										continue;
									}
									goto case 4;
								default:
									if (num3 >= num2)
									{
										goto end_IL_00ad;
									}
									goto case 2;
								}
								goto IL_00a8;
								continue;
								end_IL_00ad:
								break;
							}
							break;
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
					}
					return P_2.Count - num6;
				}
				}
				break;
			}
			goto IL_0003;
			IL_0042:
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0057;
			IL_0057:
			num6 = 0;
			int num7;
			if (P_3)
			{
				num = 425786077;
				num7 = num;
			}
			else
			{
				num = 425786078;
				num7 = num;
			}
			goto IL_0008;
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			goto IL_004b;
			IL_0072:
			int num;
			int num2;
			if (actionToPerform != null)
			{
				num = 745663205;
				num2 = num;
			}
			else
			{
				num = 745663201;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 745663204;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x2C71EAE5)
			{
			case 3:
				break;
			case 1:
				return;
			case 2:
				goto IL_004b;
			case 4:
				throw new ArgumentNullException("actionToPerform");
			case 5:
				goto IL_0072;
			default:
			{
				int count = PioeGocjsgFCXBLzvVOeVwBrJevt.Count;
				try
				{
					int num3 = 0;
					while (true)
					{
						int num4;
						int num5;
						if (num3 >= count)
						{
							num4 = 745663204;
							num5 = num4;
						}
						else
						{
							num4 = 745663207;
							num5 = num4;
						}
						while (true)
						{
							switch (num4 ^ 0x2C71EAE5)
							{
							case 0:
								num4 = 745663207;
								continue;
							default:
								return;
							case 4:
								break;
							case 3:
								num3++;
								num4 = 745663201;
								continue;
							case 2:
							{
								ActionElementMap obj = PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
								if (predicate(obj))
								{
									actionToPerform(obj);
									num4 = 745663206;
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
					ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
					return;
				}
			}
			}
			goto IL_0019;
			IL_004b:
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			goto IL_0072;
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			bool result = default(bool);
			int num2;
			if (num != 0)
			{
				result = false;
				num2 = 41021767;
			}
			else
			{
				num2 = 41021761;
			}
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x271F146)
				{
				case 2:
					break;
				case 5:
				{
					ActionElementMap actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
					if (actionElementMap != null && actionElementMap._actionId == actionId)
					{
						tGfcYLadyDZRkEpeHYeWcClUIwM(actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV, num3);
						result = true;
						num2 = 41021766;
						continue;
					}
					goto case 0;
				}
				case 7:
					return false;
				case 0:
					num3--;
					num2 = 41021760;
					continue;
				case 4:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num2 = 41021765;
					continue;
				case 1:
					num3 = num - 1;
					num2 = 41021760;
					continue;
				case 3:
					return false;
				default:
					if (num3 < 0)
					{
						return result;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num2 = 41021762;
			goto IL_0015;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num = 0;
			int count = PioeGocjsgFCXBLzvVOeVwBrJevt.Count;
			int num2 = 0;
			int num3 = -1460279858;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num3 ^ -1460279860)
				{
				case 3:
					break;
				case 6:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				case 0:
					num++;
					num3 = -1460279859;
					continue;
				case 4:
					actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc = state;
					num3 = -1460279860;
					continue;
				case 1:
					num2++;
					num3 = -1460279858;
					continue;
				case 5:
				{
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
					int num4;
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc != state)
					{
						num3 = -1460279864;
						num4 = num3;
					}
					else
					{
						num3 = -1460279859;
						num4 = num3;
					}
					continue;
				}
				default:
					if (num2 >= count)
					{
						return num;
					}
					goto case 5;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num3 = -1460279862;
			goto IL_0012;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (skipDisabledMaps)
			{
				if (_enabled)
				{
					goto IL_0031;
				}
				goto IL_0124;
			}
			goto IL_0126;
			IL_0124:
			return false;
			IL_0036:
			int num;
			int num3 = default(int);
			int num2 = default(int);
			int count = default(int);
			IList<ActionElementMap> buttonMaps = default(IList<ActionElementMap>);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num5 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -516709435)
				{
				case 13:
					break;
				case 6:
					num3 = 0;
					num = -516709440;
					continue;
				case 7:
					num2++;
					num = -516709434;
					continue;
				case 3:
					goto IL_0093;
				case 2:
					count = buttonMaps.Count;
					num2 = 0;
					num = -516709434;
					continue;
				case 4:
					goto IL_00bb;
				case 11:
					goto IL_00d8;
				case 5:
					num = -516709425;
					continue;
				case 9:
					goto IL_00f2;
				case 1:
					goto IL_0104;
				case 8:
					goto IL_0124;
				case 12:
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
					if (!skipDisabledMaps)
					{
						goto case 6;
					}
					goto IL_0161;
				case 10:
					goto IL_017e;
				default:
					return false;
				}
				break;
				IL_017e:
				int num4;
				if (num3 < count)
				{
					num = -516709436;
					num4 = num;
				}
				else
				{
					num = -516709438;
					num4 = num;
				}
				continue;
				IL_0093:
				int num6;
				if (num2 < num5)
				{
					num = -516709431;
					num6 = num;
				}
				else
				{
					num = -516709435;
					num6 = num;
				}
				continue;
				IL_00d8:
				if (actionElementMap != actionElementMap2)
				{
					num = -516709439;
					continue;
				}
				goto IL_00c8;
				IL_0161:
				int num7;
				if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = -516709437;
					num7 = num;
				}
				else
				{
					num = -516709438;
					num7 = num;
				}
				continue;
				IL_00bb:
				if (actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
				goto IL_00c8;
				IL_00f2:
				if (!controllerMap._enabled)
				{
					num = -516709427;
					continue;
				}
				goto IL_0126;
				IL_0104:
				actionElementMap2 = buttonMaps[num3];
				if (skipDisabledMaps)
				{
					if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = -516709426;
						continue;
					}
					goto IL_00c8;
				}
				goto IL_00d8;
				IL_00c8:
				num3++;
				num = -516709425;
			}
			goto IL_0031;
			IL_0126:
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return false;
			}
			buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			num5 = buttonMapCount;
			num = -516709433;
			goto IL_0036;
			IL_0031:
			num = -516709428;
			goto IL_0036;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int num;
			int num2 = default(int);
			if (actionElementMap != null)
			{
				if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
				{
					goto IL_0026;
				}
				if (skipDisabledMaps)
				{
					if (!_enabled)
					{
						goto IL_006d;
					}
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 1962120940;
						goto IL_002b;
					}
				}
				num2 = 0;
				num = 1962120933;
				goto IL_002b;
			}
			goto IL_007f;
			IL_002b:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x74F396E4)
				{
				case 6:
					break;
				case 0:
					goto IL_005f;
				case 8:
					goto IL_006d;
				case 1:
					num = 1962120928;
					continue;
				case 3:
					goto IL_007f;
				case 2:
					goto IL_009b;
				case 4:
					goto IL_00bd;
				case 5:
					goto IL_00df;
				default:
					return false;
				}
				break;
				IL_00df:
				if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
				goto IL_00ea;
				IL_009b:
				actionElementMap2 = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
				if (!skipDisabledMaps)
				{
					goto IL_005f;
				}
				if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 1962120932;
					continue;
				}
				goto IL_00ea;
				IL_00bd:
				int num3;
				if (num2 >= PioeGocjsgFCXBLzvVOeVwBrJevt.Count)
				{
					num = 1962120931;
					num3 = num;
				}
				else
				{
					num = 1962120934;
					num3 = num;
				}
				continue;
				IL_005f:
				if (actionElementMap2 != actionElementMap)
				{
					num = 1962120929;
					continue;
				}
				goto IL_00ea;
				IL_00ea:
				num2++;
				num = 1962120928;
			}
			goto IL_0026;
			IL_007f:
			return false;
			IL_0026:
			num = 1962120935;
			goto IL_002b;
			IL_006d:
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return false;
			}
			if (skipDisabledMaps)
			{
				goto IL_0028;
			}
			goto IL_0067;
			IL_0067:
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 252812766;
			goto IL_002d;
			IL_005d:
			if (!_enabled)
			{
				return false;
			}
			goto IL_0067;
			IL_0028:
			num = 252812767;
			goto IL_002d;
			IL_002d:
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0xF119DDB)
				{
				case 2:
					break;
				case 4:
					goto IL_005d;
				case 3:
					goto IL_008c;
				case 0:
					goto IL_009b;
				case 6:
					num = 252812764;
					continue;
				case 5:
					num2 = 0;
					num = 252812765;
					continue;
				case 1:
					goto IL_00d9;
				default:
					if (num2 >= PioeGocjsgFCXBLzvVOeVwBrJevt.Count)
					{
						return false;
					}
					goto IL_00d9;
				}
				break;
				IL_00d9:
				actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
				int num3;
				if (!skipDisabledMaps)
				{
					num = 252812763;
					num3 = num;
				}
				else
				{
					num = 252812760;
					num3 = num;
				}
				continue;
				IL_008c:
				if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 252812763;
					continue;
				}
				goto IL_00b5;
				IL_00b5:
				num2++;
				num = 252812764;
				continue;
				IL_009b:
				if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
				goto IL_00b5;
			}
			goto IL_0028;
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
			eBWCFkURVSiUGYkrwOfFDuAYgel eBWCFkURVSiUGYkrwOfFDuAYgel2 = new eBWCFkURVSiUGYkrwOfFDuAYgel(-2);
			eBWCFkURVSiUGYkrwOfFDuAYgel2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			eBWCFkURVSiUGYkrwOfFDuAYgel2.dpEHnIOdFJcjTJXgjRwdzBylCqB = controllerMap;
			while (true)
			{
				int num = -1064633531;
				while (true)
				{
					switch (num ^ -1064633529)
					{
					case 0:
						break;
					case 2:
						goto IL_0034;
					default:
						return eBWCFkURVSiUGYkrwOfFDuAYgel2;
					}
					break;
					IL_0034:
					eBWCFkURVSiUGYkrwOfFDuAYgel2.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
					num = -1064633530;
				}
			}
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			ZWOCgQLNYaNYvTJuQXoEciUBEBC zWOCgQLNYaNYvTJuQXoEciUBEBC = new ZWOCgQLNYaNYvTJuQXoEciUBEBC(-2);
			while (true)
			{
				int num = 280000857;
				while (true)
				{
					switch (num ^ 0x10B07958)
					{
					case 0:
						break;
					case 1:
						goto IL_0026;
					default:
						zWOCgQLNYaNYvTJuQXoEciUBEBC.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
						return zWOCgQLNYaNYvTJuQXoEciUBEBC;
					}
					break;
					IL_0026:
					zWOCgQLNYaNYvTJuQXoEciUBEBC.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					zWOCgQLNYaNYvTJuQXoEciUBEBC.dAuEWWkVFHeztWZBXuicejvoVSv = actionElementMap;
					num = 280000858;
				}
			}
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			ELQVZFjsAHeyABBhIiEekhIgJHfB eLQVZFjsAHeyABBhIiEekhIgJHfB = new ELQVZFjsAHeyABBhIiEekhIgJHfB(-2);
			while (true)
			{
				int num = 163780141;
				while (true)
				{
					switch (num ^ 0x9C3162C)
					{
					case 2:
						break;
					case 1:
						goto IL_0026;
					default:
						return eLQVZFjsAHeyABBhIiEekhIgJHfB;
					}
					break;
					IL_0026:
					eLQVZFjsAHeyABBhIiEekhIgJHfB.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					eLQVZFjsAHeyABBhIiEekhIgJHfB.UQPnpLguhtCEkQPRaxuaPxhrRag = conflictCheck;
					eLQVZFjsAHeyABBhIiEekhIgJHfB.AsggrPyUWCnFFjkCeamlXvALxt = skipDisabledMaps;
					num = 163780140;
				}
			}
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			if (controllerMap == null)
			{
				goto IL_0021;
			}
			int num;
			if (skipDisabledMaps)
			{
				if (!_enabled)
				{
					goto IL_0124;
				}
				if (!controllerMap._enabled)
				{
					num = 1658596037;
					goto IL_0026;
				}
			}
			int num2 = 0;
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return num2;
			}
			IList<ActionElementMap> pioeGocjsgFCXBLzvVOeVwBrJevt = controllerMap.PioeGocjsgFCXBLzvVOeVwBrJevt;
			num = 1658596038;
			goto IL_0026;
			IL_0021:
			num = 1658596044;
			goto IL_0026;
			IL_0124:
			return 0;
			IL_0026:
			int count = default(int);
			int num4 = default(int);
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x62DC2ACA)
				{
				case 14:
					break;
				case 13:
					count = pioeGocjsgFCXBLzvVOeVwBrJevt.Count;
					num = 1658596042;
					continue;
				case 4:
					goto IL_0088;
				case 7:
					goto IL_009e;
				case 9:
					num4 = 0;
					num = 1658596041;
					continue;
				case 6:
					return 0;
				case 12:
					goto IL_00f0;
				case 15:
					goto IL_0124;
				case 16:
					num = 1658596034;
					continue;
				case 11:
					goto IL_014d;
				case 0:
					num3 = PioeGocjsgFCXBLzvVOeVwBrJevt.Count - 1;
					num = 1658596040;
					continue;
				case 8:
					num3--;
					num = 1658596040;
					continue;
				case 10:
					if (skipDisabledMaps)
					{
						goto IL_0196;
					}
					goto case 1;
				case 1:
					if (actionElementMap.CheckForAssignmentConflict(pioeGocjsgFCXBLzvVOeVwBrJevt[num4]))
					{
						tGfcYLadyDZRkEpeHYeWcClUIwM(actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV, num3);
						num2++;
						num = 1658596058;
						continue;
					}
					goto case 5;
				case 3:
					num = 1658596046;
					continue;
				case 5:
					num4++;
					num = 1658596046;
					continue;
				default:
					if (num3 < 0)
					{
						return num2;
					}
					goto IL_009e;
				}
				break;
				IL_0196:
				int num5;
				if (!pioeGocjsgFCXBLzvVOeVwBrJevt[num4].gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 1658596047;
					num5 = num;
				}
				else
				{
					num = 1658596043;
					num5 = num;
				}
				continue;
				IL_0088:
				int num6;
				if (num4 < count)
				{
					num = 1658596032;
					num6 = num;
				}
				else
				{
					num = 1658596034;
					num6 = num;
				}
				continue;
				IL_00f0:
				if (pioeGocjsgFCXBLzvVOeVwBrJevt == null)
				{
					return num2;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null && !mapCategory.userAssignable)
				{
					return num2;
				}
				int buttonMapCount2 = buttonMapCount;
				num = 1658596039;
				continue;
				IL_014d:
				int num7;
				if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 1658596034;
					num7 = num;
				}
				else
				{
					num = 1658596035;
					num7 = num;
				}
				continue;
				IL_009e:
				actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
				int num8;
				if (!skipDisabledMaps)
				{
					num = 1658596035;
					num8 = num;
				}
				else
				{
					num = 1658596033;
					num8 = num;
				}
			}
			goto IL_0021;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			if (actionElementMap == null)
			{
				goto IL_001e;
			}
			int num;
			if (skipDisabledMaps)
			{
				num = 223462068;
				goto IL_0023;
			}
			goto IL_0106;
			IL_0023:
			int num3 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0xD51C2B5)
				{
				case 4:
					break;
				case 12:
					return 0;
				case 1:
					if (_enabled)
					{
						goto IL_0081;
					}
					goto case 7;
				case 10:
					return num3;
				case 3:
					goto IL_00a7;
				case 6:
					return num3;
				case 8:
					goto IL_00d8;
				case 7:
					return 0;
				case 9:
					num3++;
					num = 223462078;
					continue;
				case 2:
					tGfcYLadyDZRkEpeHYeWcClUIwM(actionElementMap2.KAixZgRycuVSHIYaEVNGzKGIdgV, num2);
					num = 223462076;
					continue;
				case 11:
					num2--;
					num = 223462064;
					continue;
				case 0:
					return num3;
				default:
					if (num2 < 0)
					{
						return num3;
					}
					goto IL_00d8;
				}
				break;
				IL_00d8:
				actionElementMap2 = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
				if (skipDisabledMaps)
				{
					int num4;
					if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 223462070;
						num4 = num;
					}
					else
					{
						num = 223462078;
						num4 = num;
					}
					continue;
				}
				goto IL_00a7;
				IL_00a7:
				int num5;
				if (!actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					num = 223462078;
					num5 = num;
				}
				else
				{
					num = 223462071;
					num5 = num;
				}
				continue;
				IL_0081:
				if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 223462066;
					continue;
				}
				goto IL_0106;
			}
			goto IL_001e;
			IL_0106:
			num3 = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null)
			{
				if (mapCategory.userAssignable)
				{
					if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
					{
						num = 223462069;
					}
					else
					{
						num2 = PioeGocjsgFCXBLzvVOeVwBrJevt.Count - 1;
						num = 223462064;
					}
				}
				else
				{
					num = 223462079;
				}
			}
			else
			{
				num = 223462067;
			}
			goto IL_0023;
			IL_001e:
			num = 223462073;
			goto IL_0023;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button)
			{
				goto IL_003f;
			}
			goto IL_00ca;
			IL_0044:
			int num;
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			ElementAssignment elementAssignment = default(ElementAssignment);
			while (true)
			{
				switch (num ^ 0x36AAA24A)
				{
				case 7:
					break;
				case 0:
					goto IL_0078;
				case 5:
					goto IL_0093;
				case 8:
					goto IL_00be;
				case 1:
					num3--;
					num = 917152334;
					continue;
				case 3:
					goto IL_011a;
				case 6:
					tGfcYLadyDZRkEpeHYeWcClUIwM(actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV, num3);
					num2++;
					num = 917152331;
					continue;
				case 4:
					goto IL_015a;
				default:
					return num2;
				}
				break;
				IL_015a:
				int num4;
				if (num3 < 0)
				{
					num = 917152328;
					num4 = num;
				}
				else
				{
					num = 917152335;
					num4 = num;
				}
				continue;
				IL_0078:
				int num5;
				if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					num = 917152332;
					num5 = num;
				}
				else
				{
					num = 917152331;
					num5 = num;
				}
				continue;
				IL_011a:
				int num6;
				if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV != conflictCheck.elementMapId)
				{
					num = 917152330;
					num6 = num;
				}
				else
				{
					num = 917152331;
					num6 = num;
				}
				continue;
				IL_0093:
				actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num3];
				if (skipDisabledMaps)
				{
					int num7;
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 917152329;
						num7 = num;
					}
					else
					{
						num = 917152331;
						num7 = num;
					}
					continue;
				}
				goto IL_011a;
			}
			goto IL_003f;
			IL_00be:
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			goto IL_00ca;
			IL_00ca:
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
			num2 = 0;
			num3 = PioeGocjsgFCXBLzvVOeVwBrJevt.Count - 1;
			num = 917152334;
			goto IL_0044;
			IL_003f:
			num = 917152322;
			goto IL_0044;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = 2004248128;
					while (true)
					{
						switch (num ^ 0x77766641)
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
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 2004248129;
					}
				}
			}
			return DisableElementAssignmentConflicts(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return DisableElementAssignmentConflicts(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return DisableElementAssignmentConflicts(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return DisableElementAssignmentConflicts(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return DisableElementAssignmentConflicts(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int DisableElementAssignmentConflicts(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
				goto IL_0013;
			}
			goto IL_019d;
			IL_019d:
			if (P_0 == null)
			{
				return 0;
			}
			int num;
			if (P_1)
			{
				int num2;
				if (_enabled)
				{
					num = 304161487;
					num2 = num;
				}
				else
				{
					num = 304161481;
					num2 = num;
				}
				goto IL_0018;
			}
			goto IL_008a;
			IL_008a:
			int num3 = 0;
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return num3;
			}
			IList<ActionElementMap> pioeGocjsgFCXBLzvVOeVwBrJevt = P_0.PioeGocjsgFCXBLzvVOeVwBrJevt;
			int num4 = default(int);
			int count = default(int);
			int num5 = default(int);
			if (pioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				num = 304161483;
			}
			else
			{
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null && !mapCategory.userAssignable)
				{
					return num3;
				}
				num4 = buttonMapCount;
				count = pioeGocjsgFCXBLzvVOeVwBrJevt.Count;
				num5 = 0;
				num = 304161474;
			}
			goto IL_0018;
			IL_0013:
			num = 304161473;
			goto IL_0018;
			IL_0018:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num6 = default(int);
			while (true)
			{
				switch (num ^ 0x122122C5)
				{
				case 15:
					break;
				case 13:
					goto IL_006c;
				case 12:
					return 0;
				case 6:
					actionElementMap2.enabled = false;
					num = 304161479;
					continue;
				case 10:
					goto IL_00bc;
				case 5:
					actionElementMap = pioeGocjsgFCXBLzvVOeVwBrJevt[num6];
					num = 304161478;
					continue;
				case 9:
					num = 304161485;
					continue;
				case 14:
					return num3;
				case 2:
					if (P_2 != null)
					{
						P_2.Add(actionElementMap2);
						num = 304161477;
						continue;
					}
					goto case 0;
				case 8:
					num5++;
					num = 304161474;
					continue;
				case 1:
					goto IL_0150;
				case 3:
					goto IL_016a;
				case 16:
					num6++;
					num = 304161476;
					continue;
				case 4:
					goto IL_019d;
				case 11:
					actionElementMap2 = PioeGocjsgFCXBLzvVOeVwBrJevt[num5];
					if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num6 = 0;
						num = 304161476;
						continue;
					}
					goto case 8;
				case 0:
					num3++;
					num = 304161484;
					continue;
				default:
					if (num5 >= num4)
					{
						return num3;
					}
					goto case 11;
				}
				break;
				IL_016a:
				if (P_1)
				{
					int num7;
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 304161493;
						num7 = num;
					}
					else
					{
						num = 304161480;
						num7 = num;
					}
					continue;
				}
				goto IL_006c;
				IL_0150:
				int num8;
				if (num6 < count)
				{
					num = 304161472;
					num8 = num;
				}
				else
				{
					num = 304161485;
					num8 = num;
				}
				continue;
				IL_00bc:
				if (!P_0._enabled)
				{
					num = 304161481;
					continue;
				}
				goto IL_008a;
				IL_006c:
				int num9;
				if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					num = 304161475;
					num9 = num;
				}
				else
				{
					num = 304161493;
					num9 = num;
				}
			}
			goto IL_0013;
		}

		internal virtual int DisableElementAssignmentConflicts(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
				goto IL_000d;
			}
			goto IL_006b;
			IL_006b:
			if (P_0 == null)
			{
				return 0;
			}
			int num;
			if (P_1)
			{
				if (!_enabled)
				{
					goto IL_00a9;
				}
				if (!P_0.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 390706208;
					goto IL_0012;
				}
			}
			int num2 = 0;
			if (P_0.elementIdentifierId < 0)
			{
				return num2;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			int num3 = default(int);
			int num4 = default(int);
			if (mapCategory != null)
			{
				if (!mapCategory.userAssignable)
				{
					return num2;
				}
				num3 = buttonMapCount;
				num4 = 0;
				num = 390706210;
			}
			else
			{
				num = 390706214;
			}
			goto IL_0012;
			IL_00a9:
			return 0;
			IL_000d:
			num = 390706212;
			goto IL_0012;
			IL_0012:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x1749B420)
				{
				case 8:
					break;
				case 3:
					num4++;
					num = 390706210;
					continue;
				case 7:
					num2++;
					num = 390706211;
					continue;
				case 5:
					P_2.Add(actionElementMap);
					num = 390706215;
					continue;
				case 4:
					goto IL_006b;
				case 6:
					return num2;
				case 0:
					goto IL_00a9;
				case 1:
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num4];
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc || !P_0.CheckForAssignmentConflict(actionElementMap))
					{
						goto case 3;
					}
					goto IL_00fd;
				default:
					if (num4 >= num3)
					{
						return num2;
					}
					goto case 1;
				}
				break;
				IL_00fd:
				actionElementMap.enabled = false;
				int num5;
				if (P_2 != null)
				{
					num = 390706213;
					num5 = num;
				}
				else
				{
					num = 390706215;
					num5 = num;
				}
			}
			goto IL_000d;
		}

		internal virtual int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null)
			{
				goto IL_0003;
			}
			goto IL_005d;
			IL_0003:
			int num = 1499008696;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ 0x59590EBD)
				{
				case 8:
					break;
				case 3:
					num3 = buttonMapCount;
					num2 = 0;
					num = 1499008701;
					continue;
				case 6:
					goto IL_005d;
				case 11:
					if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						actionElementMap.enabled = false;
						num = 1499008700;
						continue;
					}
					goto case 10;
				case 7:
					num4++;
					num = 1499008695;
					continue;
				case 10:
					num2++;
					num = 1499008701;
					continue;
				case 5:
					if (!P_3)
					{
						P_2.Clear();
						num = 1499008699;
						continue;
					}
					goto IL_005d;
				case 4:
					return 0;
				case 1:
					if (P_2 != null)
					{
						P_2.Add(actionElementMap);
						num = 1499008698;
						continue;
					}
					goto case 7;
				case 9:
					return 0;
				case 2:
					goto IL_0132;
				case 12:
					goto IL_0156;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto IL_0156;
				}
				break;
				IL_0156:
				actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
				int num5;
				if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = 1499008703;
					num5 = num;
				}
				else
				{
					num = 1499008695;
					num5 = num;
				}
				continue;
				IL_0132:
				int num6;
				if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV != P_0.elementMapId)
				{
					num = 1499008694;
					num6 = num;
				}
				else
				{
					num = 1499008695;
					num6 = num;
				}
			}
			goto IL_0003;
			IL_005d:
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				num = 1499008697;
			}
			else
			{
				if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory == null)
				{
					num = 1499008692;
				}
				else
				{
					if (!mapCategory.userAssignable)
					{
						return 0;
					}
					elementAssignment = P_0.ToElementAssignment();
					num4 = 0;
					num = 1499008702;
				}
			}
			goto IL_0008;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			if (actionToPerform == null)
			{
				goto IL_0021;
			}
			goto IL_014c;
			IL_014c:
			if (controllerMap == null)
			{
				return 0;
			}
			int num;
			if (skipDisabledMaps)
			{
				num = 649430147;
				goto IL_0026;
			}
			goto IL_00bd;
			IL_0021:
			num = 649430149;
			goto IL_0026;
			IL_0026:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			IList<ActionElementMap> list = default(IList<ActionElementMap>);
			int num3 = default(int);
			int num4 = default(int);
			int count = default(int);
			while (true)
			{
				int num5;
				switch (num ^ 0x26B58484)
				{
				case 2:
					break;
				case 10:
					actionElementMap = eagikhgBLGgDWavnxIFHHkyWQFp[num2];
					if (!skipDisabledMaps)
					{
						goto case 9;
					}
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 649430157;
						continue;
					}
					goto IL_01e0;
				case 6:
					if (!skipDisabledMaps)
					{
						goto default;
					}
					if (list[num3].gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 649430148;
						continue;
					}
					goto IL_01fc;
				case 3:
					return 0;
				case 7:
					if (!_enabled)
					{
						goto case 3;
					}
					goto IL_00e2;
				case 1:
					throw new ArgumentNullException("actionToPerform");
				case 5:
					goto IL_0109;
				case 4:
					goto IL_014c;
				case 9:
					num3 = 0;
					goto IL_01ed;
				default:
					if (actionElementMap.CheckForAssignmentConflict(list[num3]))
					{
						try
						{
							actionToPerform(actionElementMap);
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
							return num4;
						}
						num4++;
						goto IL_01e0;
					}
					goto IL_01fc;
				case 8:
					{
						if (num2 >= 0)
						{
							goto case 10;
						}
						num5 = 649430150;
						goto IL_01ac;
					}
					IL_01e0:
					num2--;
					num5 = 649430148;
					goto IL_01ac;
					IL_01ed:
					if (num3 < count)
					{
						goto case 6;
					}
					num5 = 649430149;
					goto IL_01ac;
					IL_01fc:
					num3++;
					num5 = 649430151;
					goto IL_01ac;
					IL_01ac:
					while (true)
					{
						switch (num5 ^ 0x26B58484)
						{
						case 4:
							num5 = 649430145;
							continue;
						case 0:
							break;
						case 1:
							goto IL_01e0;
						case 3:
							goto IL_01ed;
						case 5:
							goto IL_01fc;
						default:
							return num4;
						}
						break;
					}
					goto case 8;
				}
				break;
				IL_0109:
				if (list == null)
				{
					return num4;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null && !mapCategory.userAssignable)
				{
					return num4;
				}
				count = list.Count;
				num2 = eagikhgBLGgDWavnxIFHHkyWQFp.Count - 1;
				num = 649430156;
				continue;
				IL_00e2:
				if (!controllerMap._enabled)
				{
					num = 649430151;
					continue;
				}
				goto IL_00bd;
			}
			goto IL_0021;
			IL_00bd:
			num4 = 0;
			if (eagikhgBLGgDWavnxIFHHkyWQFp == null)
			{
				return num4;
			}
			list = controllerMap.eagikhgBLGgDWavnxIFHHkyWQFp;
			num = 649430145;
			goto IL_0026;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0;
			}
			if (actionToPerform == null)
			{
				goto IL_0021;
			}
			goto IL_00fe;
			IL_0134:
			int num = 2015853443;
			goto IL_0139;
			IL_0021:
			int num2 = 2015853443;
			goto IL_0026;
			IL_0026:
			int num3 = default(int);
			switch (num2 ^ 0x78277B80)
			{
			case 5:
				break;
			case 1:
				goto IL_0056;
			case 0:
				goto IL_0089;
			case 3:
				throw new ArgumentNullException("actionToPerform");
			case 4:
				return 0;
			case 2:
				return num3;
			case 6:
				goto IL_00fe;
			default:
				goto IL_010b;
			}
			goto IL_0021;
			IL_010b:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
			{
				try
				{
					actionToPerform(actionElementMap2);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
					return num3;
				}
				num3++;
				goto IL_0134;
			}
			goto IL_0156;
			IL_0139:
			switch (num ^ 0x78277B80)
			{
			case 0:
				break;
			case 3:
				goto IL_0156;
			case 2:
				goto IL_0161;
			default:
				return num3;
			}
			goto IL_0134;
			IL_0156:
			int num4 = num4 - 1;
			num = 2015853442;
			goto IL_0139;
			IL_00fe:
			if (actionElementMap != null)
			{
				if (skipDisabledMaps)
				{
					if (!_enabled)
					{
						goto IL_0056;
					}
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num2 = 2015853441;
						goto IL_0026;
					}
				}
				num3 = 0;
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory == null)
				{
					return num3;
				}
				if (!mapCategory.userAssignable)
				{
					return num3;
				}
				if (eagikhgBLGgDWavnxIFHHkyWQFp != null)
				{
					num4 = eagikhgBLGgDWavnxIFHHkyWQFp.Count - 1;
					goto IL_0161;
				}
				num2 = 2015853442;
			}
			else
			{
				num2 = 2015853444;
			}
			goto IL_0026;
			IL_0161:
			if (num4 >= 0)
			{
				goto IL_0089;
			}
			num = 2015853441;
			goto IL_0139;
			IL_0089:
			actionElementMap2 = eagikhgBLGgDWavnxIFHHkyWQFp[num4];
			if (!skipDisabledMaps)
			{
				goto IL_010b;
			}
			if (actionElementMap2.gmbIkkevNmPVGSTIwKcAwoPYANrc)
			{
				num2 = 2015853447;
				goto IL_0026;
			}
			goto IL_0156;
			IL_0056:
			return 0;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_009c;
			IL_001e:
			int num;
			int num3 = default(int);
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ElementAssignment elementAssignment = default(ElementAssignment);
			while (true)
			{
				int num4;
				switch (num ^ -1966946145)
				{
				case 5:
					break;
				case 9:
					return 0;
				case 6:
					return 0;
				case 8:
					num3 = eagikhgBLGgDWavnxIFHHkyWQFp.Count - 1;
					goto IL_01b0;
				case 7:
					goto IL_009c;
				case 3:
					num2 = 0;
					num = -1966946153;
					continue;
				case 1:
					actionElementMap = eagikhgBLGgDWavnxIFHHkyWQFp[num3];
					if (!skipDisabledMaps)
					{
						goto case 4;
					}
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = -1966946149;
						continue;
					}
					goto IL_01a5;
				case 4:
					if (actionElementMap.KAixZgRycuVSHIYaEVNGzKGIdgV != conflictCheck.elementMapId)
					{
						num = -1966946145;
						continue;
					}
					goto IL_01a5;
				case 2:
					return 0;
				case 10:
					return 0;
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
								return num2;
							}
							num2++;
							goto IL_0183;
						}
						goto IL_01a5;
					}
					IL_01a5:
					num3--;
					num4 = -1966946146;
					goto IL_0188;
					IL_01b0:
					if (num3 >= 0)
					{
						goto case 1;
					}
					num4 = -1966946147;
					goto IL_0188;
					IL_0188:
					switch (num4 ^ -1966946145)
					{
					case 0:
						break;
					case 3:
						goto IL_01a5;
					case 1:
						goto IL_01b0;
					default:
						return num2;
					}
					goto IL_0183;
					IL_0183:
					num4 = -1966946148;
					goto IL_0188;
				}
				break;
			}
			goto IL_0019;
			IL_009c:
			if (skipDisabledMaps && !_enabled)
			{
				num = -1966946155;
			}
			else
			{
				if (eagikhgBLGgDWavnxIFHHkyWQFp == null)
				{
					return 0;
				}
				if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null)
				{
					if (mapCategory.userAssignable)
					{
						elementAssignment = conflictCheck.ToElementAssignment();
						num = -1966946148;
					}
					else
					{
						num = -1966946151;
					}
				}
				else
				{
					num = -1966946147;
				}
			}
			goto IL_001e;
			IL_0019:
			num = -1966946154;
			goto IL_001e;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return EmptyObjects<string>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return new string[0];
			}
			string[] array = new string[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = PioeGocjsgFCXBLzvVOeVwBrJevt[num2].FcZlvtEnXFMiEicBtcTcDitrjYGb;
					num2++;
					int num3 = 1332400526;
					while (true)
					{
						switch (num3 ^ 0x4F6AD18F)
						{
						case 0:
							num3 = 1332400525;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0059;
						}
						break;
					}
					continue;
					end_IL_0059:
					break;
				}
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return string.Empty;
			}
			try
			{
				return LxAJUQVkKiSNqkaHsfsZAlQLTqTK().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return string.Empty;
			}
			try
			{
				return LxAJUQVkKiSNqkaHsfsZAlQLTqTK().ToJsonString();
			}
			catch (Exception ex)
			{
				while (true)
				{
					int num = 1306925407;
					while (true)
					{
						switch (num ^ 0x4DE6195D)
						{
						case 0:
							break;
						case 2:
							goto IL_004c;
						default:
							return string.Empty;
						}
						break;
						IL_004c:
						Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
						num = 1306925404;
					}
				}
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			int num;
			string text;
			if (controllerTemplate == null)
			{
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.trWVNTJMAihjoCbseTOaZKfBTFD(templateTypeGuid);
				if (!(hardwareJoystickTemplateMap != null))
				{
					num = 561565173;
					goto IL_001e;
				}
				text = hardwareJoystickTemplateMap.ClassName;
				goto IL_009f;
			}
			return ControllerTemplateMap.FromControllerMap(controllerTemplate, this);
			IL_0019:
			num = 561565174;
			goto IL_001e;
			IL_009f:
			string text2 = text;
			Logger.LogError("The Controller does not implement " + text2 + ".", true);
			return null;
			IL_001e:
			switch (num ^ 0x2178CDF4)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				goto IL_008a;
			}
			goto IL_0019;
			IL_008a:
			text = templateTypeGuid.ToString();
			goto IL_009f;
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			int num;
			int num2;
			if ((object)templateInterfaceType == null)
			{
				num = 1132668779;
				num2 = num;
			}
			else
			{
				num = 1132668776;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = 1132668782;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				object obj;
				IControllerTemplate controllerTemplate;
				switch (num ^ 0x4383276B)
				{
				case 4:
					break;
				case 3:
					if (controller == null)
					{
						num = 1132668777;
						continue;
					}
					obj = controller.GetTemplate(templateInterfaceType);
					if (obj == null)
					{
						num = 1132668781;
						continue;
					}
					goto IL_0065;
				case 6:
					obj = controller.GetTemplate(templateInterfaceType) as ControllerTemplate;
					goto IL_0065;
				case 1:
					Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", true);
					num = 1132668780;
					continue;
				case 0:
					throw new ArgumentNullException("templateInterfaceType");
				case 2:
					Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
					return null;
				case 5:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				default:
					{
						return null;
					}
					IL_0065:
					controllerTemplate = (IControllerTemplate)obj;
					if (controllerTemplate == null)
					{
						num = 1132668778;
						continue;
					}
					return ControllerTemplateMap.FromControllerMap(controllerTemplate, this);
				}
				break;
			}
			goto IL_0010;
		}

		private ControllerTemplateMap tJImcqErHZwRyNYLzBIacCZByma(IControllerTemplate P_0)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.FromControllerMap(P_0, this);
		}

		internal virtual bool AddActionMapping_BeforeBake(ActionElementMap P_0)
		{
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0._elementType))
			{
				return false;
			}
			QrBKEhqfnZFiWfSKQsgfyGtGEVE(P_0);
			return true;
		}

		internal virtual int GetElementMaps_Append(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count2 = default(int);
			int num2 = default(int);
			while (true)
			{
				int count = P_0.Count;
				int num = -770013609;
				while (true)
				{
					switch (num ^ -770013610)
					{
					case 0:
						num = -770013611;
						continue;
					case 3:
						break;
					case 1:
						count2 = PioeGocjsgFCXBLzvVOeVwBrJevt.Count;
						num2 = 0;
						num = -770013612;
						continue;
					case 6:
						P_0.Add(PioeGocjsgFCXBLzvVOeVwBrJevt[num2]);
						num = -770013613;
						continue;
					case 4:
						if (P_1)
						{
							int num4;
							if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2].gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								num = -770013616;
								num4 = num;
							}
							else
							{
								num = -770013613;
								num4 = num;
							}
							continue;
						}
						goto case 6;
					case 5:
						num2++;
						num = -770013612;
						continue;
					case 2:
					{
						int num3;
						if (num2 >= count2)
						{
							num = -770013615;
							num3 = num;
						}
						else
						{
							num = -770013614;
							num3 = num;
						}
						continue;
					}
					default:
						return P_0.Count - count;
					}
					break;
				}
			}
		}

		internal virtual ActionElementMap GetFirstElementMapWithMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_2))
			{
				return null;
			}
			int num = FirstIndexOfElementMapping(P_0, P_1, P_2);
			while (true)
			{
				int num2 = -384654348;
				while (true)
				{
					switch (num2 ^ -384654346)
					{
					case 0:
						break;
					case 2:
						if (num < 0)
						{
							goto IL_0037;
						}
						return PioeGocjsgFCXBLzvVOeVwBrJevt[num];
					default:
						return null;
					}
					break;
					IL_0037:
					num2 = -384654345;
				}
			}
		}

		internal virtual int GetElementMapsWithElementIdentifier(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = 0;
				int num2;
				if (!P_2)
				{
					P_1.Clear();
					num2 = -160140783;
					goto IL_0013;
				}
				goto IL_006f;
				IL_0013:
				while (true)
				{
					switch (num2 ^ -160140778)
					{
					case 3:
						num2 = -160140782;
						continue;
					case 4:
						break;
					case 7:
						goto IL_0055;
					case 0:
						goto IL_006f;
					case 6:
						if (PioeGocjsgFCXBLzvVOeVwBrJevt[num3]._elementIdentifierId == P_0)
						{
							P_1.Add(PioeGocjsgFCXBLzvVOeVwBrJevt[num3]);
							num2 = -160140777;
							continue;
						}
						goto case 1;
					case 1:
						num3++;
						num2 = -160140780;
						continue;
					case 5:
						num2 = -160140780;
						continue;
					default:
						if (num3 >= num4)
						{
							return P_1.Count - num;
						}
						goto case 6;
					}
					break;
					IL_0055:
					if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
					{
						return 0;
					}
					num4 = buttonMapCount;
					num3 = 0;
					num2 = -160140781;
				}
				continue;
				IL_006f:
				num = P_1.Count;
				num2 = -160140783;
				goto IL_0013;
			}
		}

		internal virtual bool ContainsElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			int num2 = 0;
			while (true)
			{
				int num3 = -1214249440;
				while (true)
				{
					switch (num3 ^ -1214249439)
					{
					case 2:
						break;
					case 1:
						num3 = -1214249439;
						continue;
					case 4:
						if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2]._actionId == P_1)
						{
							return true;
						}
						goto IL_0057;
					case 3:
						if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2]._elementIdentifierId == P_0)
						{
							num3 = -1214249435;
							continue;
						}
						goto IL_0057;
					default:
						{
							if (num2 >= num)
							{
								return false;
							}
							goto case 3;
						}
						IL_0057:
						num2++;
						num3 = -1214249439;
						continue;
					}
					break;
				}
			}
		}

		internal virtual int FirstIndexOfElementMapping(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_2))
			{
				return -1;
			}
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2]._elementIdentifierId == P_0 && PioeGocjsgFCXBLzvVOeVwBrJevt[num2]._actionId == P_1)
					{
						return num2;
					}
					num2++;
					int num3 = -246585981;
					while (true)
					{
						switch (num3 ^ -246585981)
						{
						case 2:
							num3 = -246585982;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003e;
						}
						break;
					}
					continue;
					end_IL_003e:
					break;
				}
			}
			return -1;
		}

		internal int tkoKQpzVFmVQeufHwySksyFNoHJ(int P_0)
		{
			if (PioeGocjsgFCXBLzvVOeVwBrJevt == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					int num3;
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2].KAixZgRycuVSHIYaEVNGzKGIdgV == P_0)
					{
						num3 = 1205041795;
					}
					else
					{
						num2++;
						num3 = 1205041792;
					}
					while (true)
					{
						switch (num3 ^ 0x47D37A83)
						{
						case 2:
							num3 = 1205041794;
							continue;
						case 1:
							break;
						case 0:
							return num2;
						default:
							goto end_IL_0037;
						}
						break;
					}
					continue;
					end_IL_0037:
					break;
				}
			}
			return -1;
		}

		internal int PaablZAXKaYQUGnfsHybeSmsOhbe(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			goto IL_0071;
			IL_0003:
			int num = -64344994;
			goto IL_0008;
			IL_0008:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -64344997)
				{
				case 0:
					break;
				case 5:
					throw new ArgumentNullException("results");
				case 1:
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
					num = -64345006;
					continue;
				case 2:
					num = -64344996;
					continue;
				case 8:
					goto IL_0071;
				case 9:
					if (P_0)
					{
						goto IL_0088;
					}
					goto case 6;
				case 6:
					P_1.Add(actionElementMap);
					num4++;
					num = -64345007;
					continue;
				case 3:
					num3 = buttonMapCount;
					num4 = 0;
					num2 = 0;
					num = -64344999;
					continue;
				case 10:
					num2++;
					num = -64344996;
					continue;
				case 4:
					P_1.Clear();
					num = -64345000;
					continue;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto case 1;
				}
				break;
				IL_0088:
				int num5;
				if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = -64345007;
					num5 = num;
				}
				else
				{
					num = -64344995;
					num5 = num;
				}
			}
			goto IL_0003;
			IL_0071:
			int num6;
			if (!P_2)
			{
				num = -64344993;
				num6 = num;
			}
			else
			{
				num = -64345000;
				num6 = num;
			}
			goto IL_0008;
		}

		internal int TqINzOXHPesSFSrUfMuwCzFfcdY(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				if (!P_3)
				{
					P_2.Clear();
					num = -1947217035;
					goto IL_0016;
				}
				goto IL_00de;
				IL_0016:
				while (true)
				{
					switch (num ^ -1947217028)
					{
					case 2:
						num = -1947217025;
						continue;
					case 0:
						if (P_1)
						{
							goto IL_0051;
						}
						goto case 4;
					case 8:
						num2++;
						num = -1947217030;
						continue;
					case 5:
						break;
					case 1:
						num2 = 0;
						num = -1947217030;
						continue;
					case 3:
						goto end_IL_0016;
					case 4:
						P_2.Add(actionElementMap);
						num = -1947217029;
						continue;
					case 7:
						num4++;
						num = -1947217036;
						continue;
					case 9:
						goto IL_00de;
					default:
						if (num2 >= num3)
						{
							return num4;
						}
						break;
					}
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
					int num5;
					if (actionElementMap._actionId != P_0)
					{
						num = -1947217036;
						num5 = num;
					}
					else
					{
						num = -1947217028;
						num5 = num;
					}
					continue;
					IL_0051:
					int num6;
					if (actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = -1947217032;
						num6 = num;
					}
					else
					{
						num = -1947217036;
						num6 = num;
					}
					continue;
					end_IL_0016:
					break;
				}
				continue;
				IL_00de:
				num3 = buttonMapCount;
				if (num3 == 0)
				{
					break;
				}
				num4 = 0;
				num = -1947217027;
				goto IL_0016;
			}
			return 0;
		}

		internal virtual int GetElementMapsWithAction(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				IL_00df:
				int num;
				if (!P_3)
				{
					P_2.Clear();
					num = 1673067681;
					goto IL_0016;
				}
				goto IL_00ad;
				IL_0016:
				while (true)
				{
					switch (num ^ 0x63B8FCA9)
					{
					case 0:
						num = 1673067691;
						continue;
					case 4:
						P_2.Add(actionElementMap);
						num4++;
						num = 1673067690;
						continue;
					case 6:
						break;
					case 5:
						goto IL_0079;
					case 9:
						num = 1673067688;
						continue;
					case 8:
						goto end_IL_0016;
					case 7:
						goto IL_00c8;
					case 2:
						goto IL_00df;
					case 3:
						num2++;
						num = 1673067688;
						continue;
					default:
						if (num2 >= num3)
						{
							return num4;
						}
						goto IL_0079;
					}
					int num5;
					if (!actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						num = 1673067690;
						num5 = num;
					}
					else
					{
						num = 1673067693;
						num5 = num;
					}
					continue;
					IL_00c8:
					int num6;
					if (!P_1)
					{
						num = 1673067693;
						num6 = num;
					}
					else
					{
						num = 1673067695;
						num6 = num;
					}
					continue;
					IL_0079:
					actionElementMap = PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
					int num7;
					if (actionElementMap._actionId == P_0)
					{
						num = 1673067694;
						num7 = num;
					}
					else
					{
						num = 1673067690;
						num7 = num;
					}
					continue;
					end_IL_0016:
					break;
				}
				goto IL_00ad;
				IL_00ad:
				if (P_0 < 0)
				{
					break;
				}
				num4 = 0;
				num3 = buttonMapCount;
				num2 = 0;
				num = 1673067680;
				goto IL_0016;
			}
			return 0;
		}

		internal virtual ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1)
			{
				goto IL_000a;
			}
			goto IL_008f;
			IL_000a:
			int num = -2018787273;
			goto IL_000f;
			IL_000f:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -2018787277)
				{
				case 6:
					break;
				case 7:
					goto IL_003f;
				case 5:
				{
					int elementIdentifierId = P_0.elementIdentifierId;
					num2 = 0;
					num = -2018787276;
					continue;
				}
				case 1:
					goto IL_0064;
				case 4:
					goto IL_0085;
				case 2:
					goto IL_00bf;
				case 3:
					goto IL_00ee;
				default:
					return null;
				}
				break;
				IL_0064:
				if (P_1)
				{
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2]._actionId == P_2)
					{
						num = -2018787280;
						continue;
					}
					goto IL_00e0;
				}
				goto IL_00ee;
				IL_00e0:
				num2++;
				num = -2018787276;
				continue;
				IL_00bf:
				if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2].IsTarget(P_0))
				{
					return PioeGocjsgFCXBLzvVOeVwBrJevt[num2];
				}
				goto IL_00e0;
				IL_00ee:
				if (!P_3)
				{
					goto IL_00bf;
				}
				if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2].gmbIkkevNmPVGSTIwKcAwoPYANrc)
				{
					num = -2018787279;
					continue;
				}
				goto IL_00e0;
				IL_003f:
				int num4;
				if (num2 >= num3)
				{
					num = -2018787277;
					num4 = num;
				}
				else
				{
					num = -2018787278;
					num4 = num;
				}
			}
			goto IL_000a;
			IL_008f:
			if (!oSmCFuBsWuhMXBHghUirqIFiPmAi(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0.elementType))
			{
				return null;
			}
			num3 = buttonMapCount;
			num = -2018787274;
			goto IL_000f;
			IL_0085:
			if (P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			goto IL_008f;
		}

		internal virtual int GetElementMapsWithElementTarget(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = 0;
				int num2 = -1838468295;
				while (true)
				{
					switch (num2 ^ -1838468299)
					{
					case 4:
						num2 = -1838468290;
						continue;
					case 14:
						P_4.Clear();
						num2 = -1838468304;
						continue;
					case 7:
						return num;
					case 2:
						P_4.Add(PioeGocjsgFCXBLzvVOeVwBrJevt[num3]);
						num++;
						num2 = -1838468294;
						continue;
					case 1:
					{
						int num9;
						if (PioeGocjsgFCXBLzvVOeVwBrJevt[num3].gmbIkkevNmPVGSTIwKcAwoPYANrc)
						{
							num2 = -1838468296;
							num9 = num2;
						}
						else
						{
							num2 = -1838468294;
							num9 = num2;
						}
						continue;
					}
					case 13:
					{
						int num7;
						if (!PioeGocjsgFCXBLzvVOeVwBrJevt[num3].IsTarget(P_0))
						{
							num2 = -1838468294;
							num7 = num2;
						}
						else
						{
							num2 = -1838468297;
							num7 = num2;
						}
						continue;
					}
					case 9:
					{
						int num10;
						if (P_3)
						{
							num2 = -1838468300;
							num10 = num2;
						}
						else
						{
							num2 = -1838468296;
							num10 = num2;
						}
						continue;
					}
					case 12:
					{
						int num8;
						if (!P_5)
						{
							num2 = -1838468293;
							num8 = num2;
						}
						else
						{
							num2 = -1838468304;
							num8 = num2;
						}
						continue;
					}
					case 3:
					{
						int num6;
						if (!P_1)
						{
							num2 = -1838468292;
							num6 = num2;
						}
						else
						{
							num2 = -1838468291;
							num6 = num2;
						}
						continue;
					}
					case 10:
						num2 = -1838468301;
						continue;
					case 5:
						P_6 = false;
						if (!P_1 || P_2 >= 0)
						{
							if (!oSmCFuBsWuhMXBHghUirqIFiPmAi(P_0))
							{
								P_6 = true;
								return num;
							}
							if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0.elementType))
							{
								num2 = -1838468299;
								continue;
							}
							num4 = buttonMapCount;
							int elementIdentifierId = P_0.elementIdentifierId;
							num3 = 0;
							num2 = -1838468289;
						}
						else
						{
							P_6 = true;
							num2 = -1838468302;
						}
						continue;
					case 15:
						num3++;
						num2 = -1838468301;
						continue;
					case 0:
						return num;
					case 11:
						break;
					case 8:
					{
						int num5;
						if (PioeGocjsgFCXBLzvVOeVwBrJevt[num3]._actionId != P_2)
						{
							num2 = -1838468294;
							num5 = num2;
						}
						else
						{
							num2 = -1838468292;
							num5 = num2;
						}
						continue;
					}
					default:
						if (num3 >= num4)
						{
							return num;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		internal void DWfqRrTmjQCuqbFAiFRBseSVqsw(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap == null)
			{
				return;
			}
			while (elementMap._elementType != P_1)
			{
				while (true)
				{
					elementMap._elementType = P_1;
					int num = -199919276;
					while (true)
					{
						switch (num ^ -199919274)
						{
						case 4:
							num = -199919275;
							continue;
						case 2:
							if (P_1 == ControllerElementType.Button)
							{
								elementMap._axisRange = AxisRange.Full;
								elementMap._invert = false;
								num = -199919274;
								continue;
							}
							goto default;
						case 1:
							break;
						case 3:
							goto end_IL_004b;
						default:
							DeleteElementMap(P_0);
							AddElementMap(elementMap);
							return;
						}
						break;
					}
					continue;
					end_IL_004b:
					break;
				}
			}
		}

		internal virtual bool AddElementMap(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!gfpRnucHhqKGhIOvKPuSfkLNcyE(P_0._elementType))
			{
				return false;
			}
			PioeGocjsgFCXBLzvVOeVwBrJevt.Add(P_0);
			while (true)
			{
				int num = -1308948515;
				while (true)
				{
					switch (num ^ -1308948516)
					{
					case 0:
						break;
					case 1:
						goto IL_0040;
					default:
						return true;
					}
					break;
					IL_0040:
					kHDMPMlaIVHtlZBBhMcCDjBjBPwI(P_0);
					num = -1308948514;
				}
			}
		}

		internal bool oSmCFuBsWuhMXBHghUirqIFiPmAi(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			Controller controller = P_0.controller;
			int num;
			if (controller != null && controller.type == _controllerType)
			{
				if (controller.id != _controllerId)
				{
					num = -994143003;
					goto IL_0008;
				}
				return true;
			}
			goto IL_0050;
			IL_0050:
			return false;
			IL_0008:
			switch (num ^ -994143001)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_0050;
			}
			goto IL_0003;
			IL_0003:
			num = -994143002;
			goto IL_0008;
		}

		internal bool DkhRhjKLQXwNxkpqdeFywUnylNa(string P_0)
		{
			bool result = default(bool);
			try
			{
				Import(SerializedObject.FromXml(GetType(), P_0));
				while (true)
				{
					IL_0013:
					int num = -484489249;
					while (true)
					{
						switch (num ^ -484489250)
						{
						case 0:
							break;
						default:
							goto end_IL_0018;
						case 1:
							goto IL_0031;
						case 2:
							goto end_IL_0018;
						}
						goto IL_0013;
						IL_0031:
						result = true;
						num = -484489252;
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
				result = false;
			}
			return result;
		}

		internal bool ZBvKFuYGMGApMupjgtoRbVyCULG(string P_0)
		{
			bool result = default(bool);
			try
			{
				Import(SerializedObject.FromJson(GetType(), P_0));
				while (true)
				{
					IL_0013:
					int num = -1257562990;
					while (true)
					{
						switch (num ^ -1257562989)
						{
						case 2:
							break;
						default:
							goto end_IL_0018;
						case 1:
							goto IL_0031;
						case 0:
							goto end_IL_0018;
						}
						goto IL_0013;
						IL_0031:
						result = true;
						num = -1257562989;
						continue;
						end_IL_0018:
						break;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				result = false;
			}
			return result;
		}

		internal void kHDMPMlaIVHtlZBBhMcCDjBjBPwI(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (-70508083 ^ -70508084)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			eagikhgBLGgDWavnxIFHHkyWQFp.Add(P_0);
			eagikhgBLGgDWavnxIFHHkyWQFp.Sort(wLIrbkQlRLbWBEvbupPmmMdsIpob.Default);
		}

		internal void udQNkupzhbYmxPUEpZCAgqlazFz(int P_0)
		{
			int num = iMlgfqAmwLblnRBtrqmwZQvYyuCu(P_0);
			if (num >= 0)
			{
				eagikhgBLGgDWavnxIFHHkyWQFp.RemoveAt(num);
			}
		}

		internal void rVjdaWIUamskmtniHHVYvihwePYi(int P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			goto IL_0059;
			IL_0003:
			int num = -1905810586;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1905810585)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 5:
					eagikhgBLGgDWavnxIFHHkyWQFp[num2] = P_1;
					eagikhgBLGgDWavnxIFHHkyWQFp.Sort(wLIrbkQlRLbWBEvbupPmmMdsIpob.Default);
					num = -1905810587;
					continue;
				case 3:
					goto IL_0059;
				case 4:
					if (num2 < 0)
					{
						return;
					}
					goto case 5;
				case 2:
					return;
				}
				break;
			}
			goto IL_0003;
			IL_0059:
			num2 = iMlgfqAmwLblnRBtrqmwZQvYyuCu(P_0);
			num = -1905810589;
			goto IL_0008;
		}

		internal static void CMutJYldqVFwACUDBjHKpaGMJfl(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			while (true)
			{
				int num = -2107504271;
				while (true)
				{
					switch (num ^ -2107504270)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						P_0._elementIdentifierId = P_3;
						P_0._axisContribution = P_2;
						P_0._axisRange = P_5;
						num = -2107504272;
						continue;
					case 4:
						P_0._invert = P_6;
						num = -2107504269;
						continue;
					case 2:
					{
						int num2;
						if (P_4 != ControllerElementType.Axis)
						{
							num = -2107504269;
							num2 = num;
						}
						else
						{
							num = -2107504266;
							num2 = num;
						}
						continue;
					}
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
			SerializedObject value = default(SerializedObject);
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			SerializedObject value2 = default(SerializedObject);
			while (true)
			{
				int num = 1193475974;
				while (true)
				{
					switch (num ^ 0x4722FF8A)
					{
					case 0:
						break;
					case 7:
						num = 1193475980;
						continue;
					case 1:
						value = null;
						if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value) && value != null)
						{
							num2 = 0;
							num = 1193475981;
							continue;
						}
						goto default;
					case 12:
						_sourceMapId = -1;
						_categoryId = -1;
						num = 1193475977;
						continue;
					case 2:
					{
						int num4;
						if (!flag)
						{
							num = 1193475968;
							num4 = num;
						}
						else
						{
							num = 1193475979;
							num4 = num;
						}
						continue;
					}
					case 5:
						if (ActionElementMap.YuthJqnjOQMiolEvklDruXMdObP(actionElementMap))
						{
							QrBKEhqfnZFiWfSKQsgfyGtGEVE(actionElementMap);
							num = 1193475969;
							continue;
						}
						goto case 11;
					case 11:
						num2++;
						num = 1193475980;
						continue;
					case 8:
						if (!value.TryGetDeserializedValue<SerializedObject>(num2, out value2))
						{
							int num5;
							if (value2 == null)
							{
								num = 1193475982;
								num5 = num;
							}
							else
							{
								num = 1193475969;
								num5 = num;
							}
							continue;
						}
						goto case 4;
					case 3:
						_layoutId = -1;
						_name = string.Empty;
						_hardwareGuid = Guid.Empty;
						_enabled = true;
						P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
						P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
						P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
						P_0.TryGetDeserializedValueByRef("name", ref _name);
						P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
						P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
						num = 1193475976;
						continue;
					case 6:
					{
						int num3;
						if (num2 < value.count)
						{
							num = 1193475970;
							num3 = num;
						}
						else
						{
							num = 1193475971;
							num3 = num;
						}
						continue;
					}
					case 10:
						ClearElementMaps();
						flag = true;
						num = 1193475979;
						continue;
					case 4:
						actionElementMap = new ActionElementMap();
						actionElementMap.kLnQybMiVBnKwrnVkGeKjoKJKGa(value2);
						num = 1193475983;
						continue;
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
			goto IL_033f;
			IL_033f:
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			int num = -1748524501;
			goto IL_001b;
			IL_0016:
			num = -1748524497;
			goto IL_001b;
			IL_001b:
			string value = default(string);
			Joystick joystick = default(Joystick);
			int num2 = default(int);
			List<object> list = default(List<object>);
			Guid guid = default(Guid);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1748524498)
				{
				case 9:
					break;
				case 8:
					num = -1748524498;
					continue;
				case 11:
					value = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
					num = -1748524509;
					continue;
				case 14:
					num2++;
					num = -1748524498;
					continue;
				case 17:
					P_0.Add("name", _name);
					P_0.Add("hardwareGuid", _hardwareGuid);
					P_0.Add("enabled", _enabled);
					num = -1748524502;
					continue;
				case 15:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
					});
					num = -1748524500;
					continue;
				case 3:
					num2 = 0;
					num = -1748524506;
					continue;
				case 7:
					if (PioeGocjsgFCXBLzvVOeVwBrJevt[num2] != null)
					{
						list.Add(PioeGocjsgFCXBLzvVOeVwBrJevt[num2].LxAJUQVkKiSNqkaHsfsZAlQLTqTK());
						num = -1748524512;
						continue;
					}
					goto case 14;
				case 13:
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
					num = -1748524510;
					continue;
				case 10:
					P_0.Add("categoryId", _categoryId);
					P_0.Add("layoutId", _layoutId);
					num = -1748524481;
					continue;
				case 12:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					num = -1748524511;
					continue;
				case 2:
					P_0.Add("sourceMapId", _sourceMapId);
					num = -1748524508;
					continue;
				case 4:
					num3 = buttonMapCount;
					num = -1748524482;
					continue;
				case 6:
					if (object.ReferenceEquals(GetType(), typeof(JoystickMap)))
					{
						joystick = ReInput.controllers.GetJoystick(_controllerId);
						guid = ((joystick != null) ? joystick.hardwareTypeGuid : Guid.Empty);
						num = -1748524507;
						continue;
					}
					goto case 12;
				case 16:
					list = new List<object>();
					P_0.Add("buttonMaps", list);
					num = -1748524499;
					continue;
				case 1:
					goto IL_033f;
				case 5:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "dataVersion",
						value = 2.ToString()
					});
					num = -1748524504;
					continue;
				default:
					if (num2 >= num3)
					{
						return;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0016;
		}

		private bool gfpRnucHhqKGhIOvKPuSfkLNcyE(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void tGfcYLadyDZRkEpeHYeWcClUIwM(int P_0, int P_1)
		{
			udQNkupzhbYmxPUEpZCAgqlazFz(P_0);
			if (P_1 < 0)
			{
				return;
			}
			if (P_1 >= buttonMapCount)
			{
				while (true)
				{
					switch (-957589106 ^ -957589108)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			PioeGocjsgFCXBLzvVOeVwBrJevt.RemoveAt(P_1);
		}

		private void QrBKEhqfnZFiWfSKQsgfyGtGEVE(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				PioeGocjsgFCXBLzvVOeVwBrJevt.Add(P_0);
				kHDMPMlaIVHtlZBBhMcCDjBjBPwI(P_0);
			}
		}

		private void IHxmSDKKIwNhZSiegkoDGkyChCu(ActionElementMap P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (P_1 >= 0)
			{
				int num;
				int num2;
				if (P_1 < buttonMapCount)
				{
					num = -168355846;
					num2 = num;
				}
				else
				{
					num = -168355842;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -168355846)
					{
					case 3:
						num = -168355848;
						continue;
					case 2:
						break;
					case 0:
						rVjdaWIUamskmtniHHVYvihwePYi(PioeGocjsgFCXBLzvVOeVwBrJevt[P_1].KAixZgRycuVSHIYaEVNGzKGIdgV, P_0);
						num = -168355845;
						continue;
					case 4:
						return;
					default:
						PioeGocjsgFCXBLzvVOeVwBrJevt[P_1] = P_0;
						return;
					}
					break;
				}
			}
		}

		private int iMlgfqAmwLblnRBtrqmwZQvYyuCu(int P_0)
		{
			if (eagikhgBLGgDWavnxIFHHkyWQFp == null)
			{
				return -1;
			}
			int count = eagikhgBLGgDWavnxIFHHkyWQFp.Count;
			int num = 0;
			while (true)
			{
				int num2 = 919469092;
				while (true)
				{
					switch (num2 ^ 0x36CDFC27)
					{
					case 2:
						break;
					case 3:
						num2 = 919469095;
						continue;
					case 4:
						if (eagikhgBLGgDWavnxIFHHkyWQFp[num].KAixZgRycuVSHIYaEVNGzKGIdgV == P_0)
						{
							num2 = 919469094;
							continue;
						}
						num++;
						num2 = 919469095;
						continue;
					case 1:
						return num;
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

		private SerializedObject LxAJUQVkKiSNqkaHsfsZAlQLTqTK()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ExportDataToSerializedObject(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap rHXUBQoqejbkONabpWgwEqatBJ(ControllerType P_0)
		{
			switch (P_0)
			{
			default:
				while (true)
				{
					switch (-1728448594 ^ -1728448593)
					{
					case 2:
						continue;
					case 1:
						if (P_0 == ControllerType.Custom)
						{
							return new CustomControllerMap();
						}
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerType.Keyboard;
			case ControllerType.Keyboard:
				return new KeyboardMap();
			case ControllerType.Mouse:
				return new MouseMap();
			case ControllerType.Joystick:
				return new JoystickMap();
			}
		}

		internal static ControllerMap FZqRTqABKbJkpfzezuYqcIlCetj(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			switch (P_0.type)
			{
			case ControllerType.Keyboard:
				return KeyboardMap.Blank(P_1, P_2);
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

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = rHXUBQoqejbkONabpWgwEqatBJ(controllerType);
			try
			{
				controllerMap.DkhRhjKLQXwNxkpqdeFywUnylNa(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
