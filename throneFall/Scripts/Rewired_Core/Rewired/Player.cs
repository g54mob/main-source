using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player : LnhaMJXLiFbdSGpizhhMTtFDjtXy
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class KtXeXSGVEAfixiItGMMLmuyIoyIN : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int rJmUjkNKFokqBzBLDeSfWQXZEVSDA;

					private ElementAssignmentConflictInfo KLChAQCBJZMNhroZuiCSBJxkFmwpB;

					private int VPtTzEnCTgUQeuZeqircEXxMUlBA;

					private int bjCciXDXXOUEIPYyBkuoivpTDnrn;

					public int ongwNjNituaaneJzGrGaxnQdVpujA;

					private CustomControllerMap bthHusdMhaeLqJqsZrdnOCWMQbzWA;

					public CustomControllerMap FGQIfdEHYqKXjdOkJEhmVvZMYiZK;

					public ConflictCheckingHelper guKhkpxrWKFOCxsITYFSvkesETrgA;

					private bool JleoZgYBlwrGuePnSdrqyGUImLUA;

					public bool fnlFXXbKgJIoTzolhzlSpWHUbYGoA;

					private bool XkXnwWVlvBBPbbTxRmhXIKMAEYhh;

					public bool ehxeDqXRbNjmiERFnynhTogyrjlfA;

					private int YOIEHYkVFRLdPeKFoKNxzogJaneL;

					private IEnumerator<ElementAssignmentConflictInfo> MQWVEJXgIAsdmzJmxcYdqjpBBNseA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KLChAQCBJZMNhroZuiCSBJxkFmwpB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KLChAQCBJZMNhroZuiCSBJxkFmwpB;
						}
					}

					[DebuggerHidden]
					public KtXeXSGVEAfixiItGMMLmuyIoyIN(int P_0)
					{
						rJmUjkNKFokqBzBLDeSfWQXZEVSDA = P_0;
						VPtTzEnCTgUQeuZeqircEXxMUlBA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rJmUjkNKFokqBzBLDeSfWQXZEVSDA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								nLfdeiyveliVOxqSXZiloMnyiaIAA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rJmUjkNKFokqBzBLDeSfWQXZEVSDA;
							ConflictCheckingHelper conflictCheckingHelper = guKhkpxrWKFOCxsITYFSvkesETrgA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								rJmUjkNKFokqBzBLDeSfWQXZEVSDA = -3;
								goto IL_00eb;
							}
							rJmUjkNKFokqBzBLDeSfWQXZEVSDA = -1;
							if (bjCciXDXXOUEIPYyBkuoivpTDnrn < 0 || bthHusdMhaeLqJqsZrdnOCWMQbzWA == null)
							{
								return false;
							}
							YOIEHYkVFRLdPeKFoKNxzogJaneL = 0;
							goto IL_0117;
							IL_00eb:
							if (MQWVEJXgIAsdmzJmxcYdqjpBBNseA.MoveNext())
							{
								ElementAssignmentConflictInfo current = MQWVEJXgIAsdmzJmxcYdqjpBBNseA.Current;
								KLChAQCBJZMNhroZuiCSBJxkFmwpB = current;
								rJmUjkNKFokqBzBLDeSfWQXZEVSDA = 1;
								return true;
							}
							nLfdeiyveliVOxqSXZiloMnyiaIAA();
							MQWVEJXgIAsdmzJmxcYdqjpBBNseA = null;
							goto IL_0105;
							IL_0117:
							if (YOIEHYkVFRLdPeKFoKNxzogJaneL < conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA())
							{
								if (conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(YOIEHYkVFRLdPeKFoKNxzogJaneL).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == bjCciXDXXOUEIPYyBkuoivpTDnrn)
								{
									MQWVEJXgIAsdmzJmxcYdqjpBBNseA = conflictCheckingHelper.RxzMeTCuzVQZcxiZVXguBcFCfTYu(ControllerType.Custom, bjCciXDXXOUEIPYyBkuoivpTDnrn, bthHusdMhaeLqJqsZrdnOCWMQbzWA, JleoZgYBlwrGuePnSdrqyGUImLUA, XkXnwWVlvBBPbbTxRmhXIKMAEYhh, conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(YOIEHYkVFRLdPeKFoKNxzogJaneL).oMRwDdJdVKppZpMVZzpvvqJvcOCA).GetEnumerator();
									rJmUjkNKFokqBzBLDeSfWQXZEVSDA = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							YOIEHYkVFRLdPeKFoKNxzogJaneL++;
							goto IL_0117;
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

					private void nLfdeiyveliVOxqSXZiloMnyiaIAA()
					{
						rJmUjkNKFokqBzBLDeSfWQXZEVSDA = -1;
						if (MQWVEJXgIAsdmzJmxcYdqjpBBNseA != null)
						{
							MQWVEJXgIAsdmzJmxcYdqjpBBNseA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						KtXeXSGVEAfixiItGMMLmuyIoyIN ktXeXSGVEAfixiItGMMLmuyIoyIN;
						if (rJmUjkNKFokqBzBLDeSfWQXZEVSDA == -2 && VPtTzEnCTgUQeuZeqircEXxMUlBA == Environment.CurrentManagedThreadId)
						{
							rJmUjkNKFokqBzBLDeSfWQXZEVSDA = 0;
							ktXeXSGVEAfixiItGMMLmuyIoyIN = this;
						}
						else
						{
							ktXeXSGVEAfixiItGMMLmuyIoyIN = new KtXeXSGVEAfixiItGMMLmuyIoyIN(0);
							ktXeXSGVEAfixiItGMMLmuyIoyIN.guKhkpxrWKFOCxsITYFSvkesETrgA = guKhkpxrWKFOCxsITYFSvkesETrgA;
						}
						ktXeXSGVEAfixiItGMMLmuyIoyIN.bjCciXDXXOUEIPYyBkuoivpTDnrn = ongwNjNituaaneJzGrGaxnQdVpujA;
						ktXeXSGVEAfixiItGMMLmuyIoyIN.bthHusdMhaeLqJqsZrdnOCWMQbzWA = FGQIfdEHYqKXjdOkJEhmVvZMYiZK;
						ktXeXSGVEAfixiItGMMLmuyIoyIN.JleoZgYBlwrGuePnSdrqyGUImLUA = fnlFXXbKgJIoTzolhzlSpWHUbYGoA;
						ktXeXSGVEAfixiItGMMLmuyIoyIN.XkXnwWVlvBBPbbTxRmhXIKMAEYhh = ehxeDqXRbNjmiERFnynhTogyrjlfA;
						return ktXeXSGVEAfixiItGMMLmuyIoyIN;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QwkGOsMbuehDMUCnISbcOCDYQLnc : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int VhhzNJhNNqKPYsAzHDsnrnOHErSGA;

					private ElementAssignmentConflictInfo GMEFQGbEEUYVSWbvHyCuxkSFigJR;

					private int LIcFVplpPqyxrUMpUpkIGNTcTaNy;

					private int CAYtWTYgunYBOVDdVtcvLXeuckSH;

					public int BAKWxfcTusRpTRXgakkEZWcadVNA;

					private ActionElementMap PfmXwWUFDwFyOQyGFaPvCIZalIpA;

					public ActionElementMap oiGkJXxlWDMysewcKyquszbkBeti;

					public ConflictCheckingHelper HHikcVRNrEELaNPoKmDNzosyHJyD;

					private CustomControllerMap gHtiiRVhxsBdjKklTarYsNsBACtgA;

					public CustomControllerMap eqfDzeitOiYlQQCLGhpkECBnTZiEb;

					private bool pmBaMJYRfEeqrbTmxYBzZDsEXJZd;

					public bool weijGbGWtbwSEWXMYfcXMNIfgYhdA;

					private bool OHeHYoHEYEvtJBfETeJokLPEyEU;

					public bool xbUoCJunULGEEtEmsEBbdQTbhZLl;

					private int CgudXtyoOuIaxmfwjCTvelQccGGGA;

					private IEnumerator<ElementAssignmentConflictInfo> KUEcZjMvEDfkMgtLVIhvmVtDrnVGA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GMEFQGbEEUYVSWbvHyCuxkSFigJR;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GMEFQGbEEUYVSWbvHyCuxkSFigJR;
						}
					}

					[DebuggerHidden]
					public QwkGOsMbuehDMUCnISbcOCDYQLnc(int P_0)
					{
						VhhzNJhNNqKPYsAzHDsnrnOHErSGA = P_0;
						LIcFVplpPqyxrUMpUpkIGNTcTaNy = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int vhhzNJhNNqKPYsAzHDsnrnOHErSGA = VhhzNJhNNqKPYsAzHDsnrnOHErSGA;
						if (vhhzNJhNNqKPYsAzHDsnrnOHErSGA == -3 || vhhzNJhNNqKPYsAzHDsnrnOHErSGA == 1)
						{
							try
							{
							}
							finally
							{
								qryavSLgKhybaYjcUaVFdieTbRwr();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int vhhzNJhNNqKPYsAzHDsnrnOHErSGA = VhhzNJhNNqKPYsAzHDsnrnOHErSGA;
							ConflictCheckingHelper hHikcVRNrEELaNPoKmDNzosyHJyD = HHikcVRNrEELaNPoKmDNzosyHJyD;
							if (vhhzNJhNNqKPYsAzHDsnrnOHErSGA != 0)
							{
								if (vhhzNJhNNqKPYsAzHDsnrnOHErSGA != 1)
								{
									return false;
								}
								VhhzNJhNNqKPYsAzHDsnrnOHErSGA = -3;
								goto IL_00f1;
							}
							VhhzNJhNNqKPYsAzHDsnrnOHErSGA = -1;
							if (CAYtWTYgunYBOVDdVtcvLXeuckSH < 0 || PfmXwWUFDwFyOQyGFaPvCIZalIpA == null)
							{
								return false;
							}
							CgudXtyoOuIaxmfwjCTvelQccGGGA = 0;
							goto IL_011d;
							IL_00f1:
							if (KUEcZjMvEDfkMgtLVIhvmVtDrnVGA.MoveNext())
							{
								ElementAssignmentConflictInfo current = KUEcZjMvEDfkMgtLVIhvmVtDrnVGA.Current;
								GMEFQGbEEUYVSWbvHyCuxkSFigJR = current;
								VhhzNJhNNqKPYsAzHDsnrnOHErSGA = 1;
								return true;
							}
							qryavSLgKhybaYjcUaVFdieTbRwr();
							KUEcZjMvEDfkMgtLVIhvmVtDrnVGA = null;
							goto IL_010b;
							IL_011d:
							if (CgudXtyoOuIaxmfwjCTvelQccGGGA < hHikcVRNrEELaNPoKmDNzosyHJyD.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA())
							{
								if (hHikcVRNrEELaNPoKmDNzosyHJyD.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(CgudXtyoOuIaxmfwjCTvelQccGGGA).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == CAYtWTYgunYBOVDdVtcvLXeuckSH)
								{
									KUEcZjMvEDfkMgtLVIhvmVtDrnVGA = hHikcVRNrEELaNPoKmDNzosyHJyD.rqsUFdfINmfUQMRTTKhJNzdIsJKd(ControllerType.Custom, CAYtWTYgunYBOVDdVtcvLXeuckSH, gHtiiRVhxsBdjKklTarYsNsBACtgA, PfmXwWUFDwFyOQyGFaPvCIZalIpA, pmBaMJYRfEeqrbTmxYBzZDsEXJZd, OHeHYoHEYEvtJBfETeJokLPEyEU, hHikcVRNrEELaNPoKmDNzosyHJyD.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(CgudXtyoOuIaxmfwjCTvelQccGGGA).oMRwDdJdVKppZpMVZzpvvqJvcOCA).GetEnumerator();
									VhhzNJhNNqKPYsAzHDsnrnOHErSGA = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							CgudXtyoOuIaxmfwjCTvelQccGGGA++;
							goto IL_011d;
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

					private void qryavSLgKhybaYjcUaVFdieTbRwr()
					{
						VhhzNJhNNqKPYsAzHDsnrnOHErSGA = -1;
						if (KUEcZjMvEDfkMgtLVIhvmVtDrnVGA != null)
						{
							KUEcZjMvEDfkMgtLVIhvmVtDrnVGA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						QwkGOsMbuehDMUCnISbcOCDYQLnc qwkGOsMbuehDMUCnISbcOCDYQLnc;
						if (VhhzNJhNNqKPYsAzHDsnrnOHErSGA == -2 && LIcFVplpPqyxrUMpUpkIGNTcTaNy == Environment.CurrentManagedThreadId)
						{
							VhhzNJhNNqKPYsAzHDsnrnOHErSGA = 0;
							qwkGOsMbuehDMUCnISbcOCDYQLnc = this;
						}
						else
						{
							qwkGOsMbuehDMUCnISbcOCDYQLnc = new QwkGOsMbuehDMUCnISbcOCDYQLnc(0);
							qwkGOsMbuehDMUCnISbcOCDYQLnc.HHikcVRNrEELaNPoKmDNzosyHJyD = HHikcVRNrEELaNPoKmDNzosyHJyD;
						}
						qwkGOsMbuehDMUCnISbcOCDYQLnc.CAYtWTYgunYBOVDdVtcvLXeuckSH = BAKWxfcTusRpTRXgakkEZWcadVNA;
						qwkGOsMbuehDMUCnISbcOCDYQLnc.gHtiiRVhxsBdjKklTarYsNsBACtgA = eqfDzeitOiYlQQCLGhpkECBnTZiEb;
						qwkGOsMbuehDMUCnISbcOCDYQLnc.PfmXwWUFDwFyOQyGFaPvCIZalIpA = oiGkJXxlWDMysewcKyquszbkBeti;
						qwkGOsMbuehDMUCnISbcOCDYQLnc.pmBaMJYRfEeqrbTmxYBzZDsEXJZd = weijGbGWtbwSEWXMYfcXMNIfgYhdA;
						qwkGOsMbuehDMUCnISbcOCDYQLnc.OHeHYoHEYEvtJBfETeJokLPEyEU = xbUoCJunULGEEtEmsEBbdQTbhZLl;
						return qwkGOsMbuehDMUCnISbcOCDYQLnc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class YOTewGHSYwaZzloTgBlXTmkbfgdab : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ruUqfaBmxOVMGpmrKaBNurCxnTUI;

					private ElementAssignmentConflictInfo GRWHXagHTEVTTzESrlRCSWmRthhf;

					private int EdoEoJXjZfYNWzJraiZYAunyTREI;

					private ElementAssignmentConflictCheck lFCspwsIHdAHdwPnnphHwCYNAUJS;

					public ElementAssignmentConflictCheck vpKLeKvOBJDxWKDmCruJRlCOEtZkA;

					public ConflictCheckingHelper WtSNCfPSPZqqkMDwhLCagyHAluNO;

					private bool EnkeIxBhTEkuSRYgyABXpjdORhCR;

					public bool jwqyiowxtCSNCfqTnExBSamtZYXL;

					private bool jYMUpEHivyxAYpbFXKZoAtwEOspB;

					public bool mTaTHvAfafKLZyQnjdfDEkkkQGbn;

					private int xMPOqVcNeRGTQhmRFPcfXJRgBUbZ;

					private IEnumerator<ElementAssignmentConflictInfo> hbYeYCHShXyrYJJepravjsRIaAbt;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GRWHXagHTEVTTzESrlRCSWmRthhf;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GRWHXagHTEVTTzESrlRCSWmRthhf;
						}
					}

					[DebuggerHidden]
					public YOTewGHSYwaZzloTgBlXTmkbfgdab(int P_0)
					{
						ruUqfaBmxOVMGpmrKaBNurCxnTUI = P_0;
						EdoEoJXjZfYNWzJraiZYAunyTREI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ruUqfaBmxOVMGpmrKaBNurCxnTUI;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								lwgCuufcZjcHMJspcKxNfbgnDvHv();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = ruUqfaBmxOVMGpmrKaBNurCxnTUI;
							ConflictCheckingHelper wtSNCfPSPZqqkMDwhLCagyHAluNO = WtSNCfPSPZqqkMDwhLCagyHAluNO;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ruUqfaBmxOVMGpmrKaBNurCxnTUI = -3;
								goto IL_00f3;
							}
							ruUqfaBmxOVMGpmrKaBNurCxnTUI = -1;
							if (lFCspwsIHdAHdwPnnphHwCYNAUJS.controllerId < 0 || lFCspwsIHdAHdwPnnphHwCYNAUJS.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							xMPOqVcNeRGTQhmRFPcfXJRgBUbZ = 0;
							goto IL_011f;
							IL_00f3:
							if (hbYeYCHShXyrYJJepravjsRIaAbt.MoveNext())
							{
								ElementAssignmentConflictInfo current = hbYeYCHShXyrYJJepravjsRIaAbt.Current;
								GRWHXagHTEVTTzESrlRCSWmRthhf = current;
								ruUqfaBmxOVMGpmrKaBNurCxnTUI = 1;
								return true;
							}
							lwgCuufcZjcHMJspcKxNfbgnDvHv();
							hbYeYCHShXyrYJJepravjsRIaAbt = null;
							goto IL_010d;
							IL_011f:
							if (xMPOqVcNeRGTQhmRFPcfXJRgBUbZ < wtSNCfPSPZqqkMDwhLCagyHAluNO.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA())
							{
								if (wtSNCfPSPZqqkMDwhLCagyHAluNO.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(xMPOqVcNeRGTQhmRFPcfXJRgBUbZ).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == lFCspwsIHdAHdwPnnphHwCYNAUJS.controllerId)
								{
									hbYeYCHShXyrYJJepravjsRIaAbt = wtSNCfPSPZqqkMDwhLCagyHAluNO.OWAjeWgsXDMoNyiMQKUEYbEHDhuDA(lFCspwsIHdAHdwPnnphHwCYNAUJS, EnkeIxBhTEkuSRYgyABXpjdORhCR, jYMUpEHivyxAYpbFXKZoAtwEOspB, wtSNCfPSPZqqkMDwhLCagyHAluNO.oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(xMPOqVcNeRGTQhmRFPcfXJRgBUbZ).oMRwDdJdVKppZpMVZzpvvqJvcOCA).GetEnumerator();
									ruUqfaBmxOVMGpmrKaBNurCxnTUI = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							xMPOqVcNeRGTQhmRFPcfXJRgBUbZ++;
							goto IL_011f;
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

					private void lwgCuufcZjcHMJspcKxNfbgnDvHv()
					{
						ruUqfaBmxOVMGpmrKaBNurCxnTUI = -1;
						if (hbYeYCHShXyrYJJepravjsRIaAbt != null)
						{
							hbYeYCHShXyrYJJepravjsRIaAbt.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						YOTewGHSYwaZzloTgBlXTmkbfgdab yOTewGHSYwaZzloTgBlXTmkbfgdab;
						if (ruUqfaBmxOVMGpmrKaBNurCxnTUI == -2 && EdoEoJXjZfYNWzJraiZYAunyTREI == Environment.CurrentManagedThreadId)
						{
							ruUqfaBmxOVMGpmrKaBNurCxnTUI = 0;
							yOTewGHSYwaZzloTgBlXTmkbfgdab = this;
						}
						else
						{
							yOTewGHSYwaZzloTgBlXTmkbfgdab = new YOTewGHSYwaZzloTgBlXTmkbfgdab(0);
							yOTewGHSYwaZzloTgBlXTmkbfgdab.WtSNCfPSPZqqkMDwhLCagyHAluNO = WtSNCfPSPZqqkMDwhLCagyHAluNO;
						}
						yOTewGHSYwaZzloTgBlXTmkbfgdab.lFCspwsIHdAHdwPnnphHwCYNAUJS = vpKLeKvOBJDxWKDmCruJRlCOEtZkA;
						yOTewGHSYwaZzloTgBlXTmkbfgdab.EnkeIxBhTEkuSRYgyABXpjdORhCR = jwqyiowxtCSNCfqTnExBSamtZYXL;
						yOTewGHSYwaZzloTgBlXTmkbfgdab.jYMUpEHivyxAYpbFXKZoAtwEOspB = mTaTHvAfafKLZyQnjdfDEkkkQGbn;
						return yOTewGHSYwaZzloTgBlXTmkbfgdab;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class pjhUetJifHrCZHaFlDaAbhclBJwLA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int WtnvZjFZpZjSYFysXuBLudFTupF;

					private ElementAssignmentConflictInfo HcephOMepYabtGgVJDLbWvkYZIR;

					private int lbTVBHBgbyfqPFVHEEiHFQjfYDOfB;

					private global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> VbgJqITOymLUEyCZCSPtTVSWEaXg;

					public global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> seJxqpJDirQUdyjEzFZdEOmsFbuab;

					private _0001 krfWDszkJFJvFwcfrovpltiXlFME;

					public _0001 DHjmCCjsPVeiaOLvkdHUJETiOVDiA;

					private bool MtrcqBbcOrIcZxbnscCVaMHSUvkdA;

					public bool sXBzWwNNUEIYzNxJOMDTiFnQIxaH;

					private bool FhLcQWDvvTxkqzWYWEhzHJNTYayJ;

					public bool bqScauPQtITqpVzUuCOkEnmvjizO;

					public ConflictCheckingHelper HgvLzprrgQSoCbhsLYyVGSWOUEk;

					private ControllerType apTdQlUuUCIBcbbKBfzZqOOLptZh;

					public ControllerType zLxqfABTQrNMJcLbhmREIrMXUWpH;

					private int RiTOwnwBNjcAMuVUGLjvzDfkPCEK;

					public int SaosssfHnVIjgRodZSfhQnZjwkYP;

					private InputMapCategory XsZXCmaxjTIOOdPkJDWzcpgVAydt;

					private int vICcCfAidnxKHEzuyFlpUNTjvdPeA;

					private IEnumerator<ElementAssignmentConflictInfo> CjKmJqNKiNhpGaekaCBpQQpITvlm;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HcephOMepYabtGgVJDLbWvkYZIR;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HcephOMepYabtGgVJDLbWvkYZIR;
						}
					}

					[DebuggerHidden]
					public pjhUetJifHrCZHaFlDaAbhclBJwLA(int P_0)
					{
						WtnvZjFZpZjSYFysXuBLudFTupF = P_0;
						lbTVBHBgbyfqPFVHEEiHFQjfYDOfB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int wtnvZjFZpZjSYFysXuBLudFTupF = WtnvZjFZpZjSYFysXuBLudFTupF;
						if (wtnvZjFZpZjSYFysXuBLudFTupF == -3 || wtnvZjFZpZjSYFysXuBLudFTupF == 1)
						{
							try
							{
							}
							finally
							{
								ulXgNZCeyqEddzmRhjSmcrWNUEnQA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int wtnvZjFZpZjSYFysXuBLudFTupF = WtnvZjFZpZjSYFysXuBLudFTupF;
							ConflictCheckingHelper hgvLzprrgQSoCbhsLYyVGSWOUEk = HgvLzprrgQSoCbhsLYyVGSWOUEk;
							if (wtnvZjFZpZjSYFysXuBLudFTupF != 0)
							{
								if (wtnvZjFZpZjSYFysXuBLudFTupF != 1)
								{
									return false;
								}
								WtnvZjFZpZjSYFysXuBLudFTupF = -3;
								goto IL_014a;
							}
							WtnvZjFZpZjSYFysXuBLudFTupF = -1;
							if (VbgJqITOymLUEyCZCSPtTVSWEaXg == null || krfWDszkJFJvFwcfrovpltiXlFME == null)
							{
								return false;
							}
							XsZXCmaxjTIOOdPkJDWzcpgVAydt = ReInput.mapping.GetMapCategory(krfWDszkJFJvFwcfrovpltiXlFME.categoryId);
							if (XsZXCmaxjTIOOdPkJDWzcpgVAydt == null)
							{
								return false;
							}
							vICcCfAidnxKHEzuyFlpUNTjvdPeA = 0;
							goto IL_0176;
							IL_0176:
							if (vICcCfAidnxKHEzuyFlpUNTjvdPeA < VbgJqITOymLUEyCZCSPtTVSWEaXg.cLFOTXBjzlMfxMSeRWBhGFJkuhvb())
							{
								ControllerMap controllerMap = VbgJqITOymLUEyCZCSPtTVSWEaXg.bPBvSQSPFBOEZzzSdKegAflIdxiN(vICcCfAidnxKHEzuyFlpUNTjvdPeA);
								if ((!MtrcqBbcOrIcZxbnscCVaMHSUvkdA || controllerMap.enabled) && (FhLcQWDvvTxkqzWYWEhzHJNTYayJ || !hgvLzprrgQSoCbhsLYyVGSWOUEk.xFJxgRUfFnyUEQNlhboIYkoIvOzc(XsZXCmaxjTIOOdPkJDWzcpgVAydt, controllerMap)))
								{
									CjKmJqNKiNhpGaekaCBpQQpITvlm = controllerMap.ElementAssignmentConflicts(krfWDszkJFJvFwcfrovpltiXlFME, MtrcqBbcOrIcZxbnscCVaMHSUvkdA).GetEnumerator();
									WtnvZjFZpZjSYFysXuBLudFTupF = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (CjKmJqNKiNhpGaekaCBpQQpITvlm.MoveNext())
							{
								ElementAssignmentConflictInfo current = CjKmJqNKiNhpGaekaCBpQQpITvlm.Current;
								ElementAssignmentConflictInfo hcephOMepYabtGgVJDLbWvkYZIR = new ElementAssignmentConflictInfo(current);
								hcephOMepYabtGgVJDLbWvkYZIR.playerId = hgvLzprrgQSoCbhsLYyVGSWOUEk.JDxgevEtpjfpWERpTQvxWAuWtuFpA.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								hcephOMepYabtGgVJDLbWvkYZIR.controllerType = apTdQlUuUCIBcbbKBfzZqOOLptZh;
								hcephOMepYabtGgVJDLbWvkYZIR.controllerId = RiTOwnwBNjcAMuVUGLjvzDfkPCEK;
								HcephOMepYabtGgVJDLbWvkYZIR = hcephOMepYabtGgVJDLbWvkYZIR;
								WtnvZjFZpZjSYFysXuBLudFTupF = 1;
								return true;
							}
							ulXgNZCeyqEddzmRhjSmcrWNUEnQA();
							CjKmJqNKiNhpGaekaCBpQQpITvlm = null;
							goto IL_0164;
							IL_0164:
							vICcCfAidnxKHEzuyFlpUNTjvdPeA++;
							goto IL_0176;
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

					private void ulXgNZCeyqEddzmRhjSmcrWNUEnQA()
					{
						WtnvZjFZpZjSYFysXuBLudFTupF = -1;
						if (CjKmJqNKiNhpGaekaCBpQQpITvlm != null)
						{
							CjKmJqNKiNhpGaekaCBpQQpITvlm.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						pjhUetJifHrCZHaFlDaAbhclBJwLA<_0001> pjhUetJifHrCZHaFlDaAbhclBJwLA2;
						if (WtnvZjFZpZjSYFysXuBLudFTupF == -2 && lbTVBHBgbyfqPFVHEEiHFQjfYDOfB == Environment.CurrentManagedThreadId)
						{
							WtnvZjFZpZjSYFysXuBLudFTupF = 0;
							pjhUetJifHrCZHaFlDaAbhclBJwLA2 = this;
						}
						else
						{
							pjhUetJifHrCZHaFlDaAbhclBJwLA2 = new pjhUetJifHrCZHaFlDaAbhclBJwLA<_0001>(0);
							pjhUetJifHrCZHaFlDaAbhclBJwLA2.HgvLzprrgQSoCbhsLYyVGSWOUEk = HgvLzprrgQSoCbhsLYyVGSWOUEk;
						}
						pjhUetJifHrCZHaFlDaAbhclBJwLA2.apTdQlUuUCIBcbbKBfzZqOOLptZh = zLxqfABTQrNMJcLbhmREIrMXUWpH;
						pjhUetJifHrCZHaFlDaAbhclBJwLA2.RiTOwnwBNjcAMuVUGLjvzDfkPCEK = SaosssfHnVIjgRodZSfhQnZjwkYP;
						pjhUetJifHrCZHaFlDaAbhclBJwLA2.krfWDszkJFJvFwcfrovpltiXlFME = DHjmCCjsPVeiaOLvkdHUJETiOVDiA;
						pjhUetJifHrCZHaFlDaAbhclBJwLA2.MtrcqBbcOrIcZxbnscCVaMHSUvkdA = sXBzWwNNUEIYzNxJOMDTiFnQIxaH;
						pjhUetJifHrCZHaFlDaAbhclBJwLA2.FhLcQWDvvTxkqzWYWEhzHJNTYayJ = bqScauPQtITqpVzUuCOkEnmvjizO;
						pjhUetJifHrCZHaFlDaAbhclBJwLA2.VbgJqITOymLUEyCZCSPtTVSWEaXg = seJxqpJDirQUdyjEzFZdEOmsFbuab;
						return pjhUetJifHrCZHaFlDaAbhclBJwLA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class YjbhwBHARlpuyCBpoWRlKanjvGQH<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int hLEwcOGfmvcUUHHjBsShpxUmlWPM;

					private ElementAssignmentConflictInfo opPZYtIVeUXQnHEbZCKSOhdNaXjhA;

					private int rHXbWpvSgWsjlUccrfdAxpxaETMgA;

					private global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> RkNXoBAFbNMvkdIsSqZWVBgqADMKA;

					public global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> GbgBpbchXtppEFncIpvrDLyeDwaAc;

					private ActionElementMap poivuOVVZTrMkZGzzflSCwQdxlnH;

					public ActionElementMap RAEEkwvnNEOZIaCVSFGWRrBLibZr;

					private _0001 XNCbEsBvRSmKOoBIQIhuefwXHvig;

					public _0001 FHANJCCyrbwrRGSluoipOimgtjlI;

					private bool KDVDaFDkDfNvYRFfayJhtWEHVCaiA;

					public bool pUaNKSDnvrHVAlCytZeYLOAnhWBbA;

					private bool GiOEcFDWQRvlKUSiqrDBpayvGpdMA;

					public bool OJhTnpUYpTsBTyaQBINCMiUSROHK;

					public ConflictCheckingHelper cCHZdvaNAJNyPKGVTgRhHIYkKlEq;

					private ControllerType SOyISGCTNNTpIwTCLJPjAjzCZoLo;

					public ControllerType oqQfhOFtopOxksGEpbekDafAcncY;

					private int hFNHOEIppjSpeuFQMSnexqumUWHCA;

					public int qDdKBpwjpSdzLdcGXoTaWgouqJzRA;

					private InputMapCategory VpQehHoBqAzoRHEMeoikqgYsjghb;

					private int YlnMmHTzPWRsnIUcioLcpDpNcVAy;

					private IEnumerator<ElementAssignmentConflictInfo> KDbjDRwcXAEZwDHcobpRxjGwWshz;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return opPZYtIVeUXQnHEbZCKSOhdNaXjhA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return opPZYtIVeUXQnHEbZCKSOhdNaXjhA;
						}
					}

					[DebuggerHidden]
					public YjbhwBHARlpuyCBpoWRlKanjvGQH(int P_0)
					{
						hLEwcOGfmvcUUHHjBsShpxUmlWPM = P_0;
						rHXbWpvSgWsjlUccrfdAxpxaETMgA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hLEwcOGfmvcUUHHjBsShpxUmlWPM;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								ETICtuAqHEcFpHNnnQRIPxQCpfUF();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hLEwcOGfmvcUUHHjBsShpxUmlWPM;
							ConflictCheckingHelper conflictCheckingHelper = cCHZdvaNAJNyPKGVTgRhHIYkKlEq;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hLEwcOGfmvcUUHHjBsShpxUmlWPM = -3;
								goto IL_0141;
							}
							hLEwcOGfmvcUUHHjBsShpxUmlWPM = -1;
							if (RkNXoBAFbNMvkdIsSqZWVBgqADMKA == null || poivuOVVZTrMkZGzzflSCwQdxlnH == null)
							{
								return false;
							}
							VpQehHoBqAzoRHEMeoikqgYsjghb = ((XNCbEsBvRSmKOoBIQIhuefwXHvig != null) ? ReInput.mapping.GetMapCategory(XNCbEsBvRSmKOoBIQIhuefwXHvig.categoryId) : null);
							YlnMmHTzPWRsnIUcioLcpDpNcVAy = 0;
							goto IL_016d;
							IL_016d:
							if (YlnMmHTzPWRsnIUcioLcpDpNcVAy < RkNXoBAFbNMvkdIsSqZWVBgqADMKA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb())
							{
								ControllerMap controllerMap = RkNXoBAFbNMvkdIsSqZWVBgqADMKA.bPBvSQSPFBOEZzzSdKegAflIdxiN(YlnMmHTzPWRsnIUcioLcpDpNcVAy);
								if ((!KDVDaFDkDfNvYRFfayJhtWEHVCaiA || controllerMap.enabled) && (GiOEcFDWQRvlKUSiqrDBpayvGpdMA || !conflictCheckingHelper.xFJxgRUfFnyUEQNlhboIYkoIvOzc(VpQehHoBqAzoRHEMeoikqgYsjghb, controllerMap)))
								{
									KDbjDRwcXAEZwDHcobpRxjGwWshz = controllerMap.ElementAssignmentConflicts(poivuOVVZTrMkZGzzflSCwQdxlnH, KDVDaFDkDfNvYRFfayJhtWEHVCaiA).GetEnumerator();
									hLEwcOGfmvcUUHHjBsShpxUmlWPM = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							YlnMmHTzPWRsnIUcioLcpDpNcVAy++;
							goto IL_016d;
							IL_0141:
							if (KDbjDRwcXAEZwDHcobpRxjGwWshz.MoveNext())
							{
								ElementAssignmentConflictInfo current = KDbjDRwcXAEZwDHcobpRxjGwWshz.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.JDxgevEtpjfpWERpTQvxWAuWtuFpA.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								elementAssignmentConflictInfo.controllerType = SOyISGCTNNTpIwTCLJPjAjzCZoLo;
								elementAssignmentConflictInfo.controllerId = hFNHOEIppjSpeuFQMSnexqumUWHCA;
								opPZYtIVeUXQnHEbZCKSOhdNaXjhA = elementAssignmentConflictInfo;
								hLEwcOGfmvcUUHHjBsShpxUmlWPM = 1;
								return true;
							}
							ETICtuAqHEcFpHNnnQRIPxQCpfUF();
							KDbjDRwcXAEZwDHcobpRxjGwWshz = null;
							goto IL_015b;
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

					private void ETICtuAqHEcFpHNnnQRIPxQCpfUF()
					{
						hLEwcOGfmvcUUHHjBsShpxUmlWPM = -1;
						if (KDbjDRwcXAEZwDHcobpRxjGwWshz != null)
						{
							KDbjDRwcXAEZwDHcobpRxjGwWshz.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						YjbhwBHARlpuyCBpoWRlKanjvGQH<_0001> yjbhwBHARlpuyCBpoWRlKanjvGQH;
						if (hLEwcOGfmvcUUHHjBsShpxUmlWPM == -2 && rHXbWpvSgWsjlUccrfdAxpxaETMgA == Environment.CurrentManagedThreadId)
						{
							hLEwcOGfmvcUUHHjBsShpxUmlWPM = 0;
							yjbhwBHARlpuyCBpoWRlKanjvGQH = this;
						}
						else
						{
							yjbhwBHARlpuyCBpoWRlKanjvGQH = new YjbhwBHARlpuyCBpoWRlKanjvGQH<_0001>(0);
							yjbhwBHARlpuyCBpoWRlKanjvGQH.cCHZdvaNAJNyPKGVTgRhHIYkKlEq = cCHZdvaNAJNyPKGVTgRhHIYkKlEq;
						}
						yjbhwBHARlpuyCBpoWRlKanjvGQH.SOyISGCTNNTpIwTCLJPjAjzCZoLo = oqQfhOFtopOxksGEpbekDafAcncY;
						yjbhwBHARlpuyCBpoWRlKanjvGQH.hFNHOEIppjSpeuFQMSnexqumUWHCA = qDdKBpwjpSdzLdcGXoTaWgouqJzRA;
						yjbhwBHARlpuyCBpoWRlKanjvGQH.XNCbEsBvRSmKOoBIQIhuefwXHvig = FHANJCCyrbwrRGSluoipOimgtjlI;
						yjbhwBHARlpuyCBpoWRlKanjvGQH.poivuOVVZTrMkZGzzflSCwQdxlnH = RAEEkwvnNEOZIaCVSFGWRrBLibZr;
						yjbhwBHARlpuyCBpoWRlKanjvGQH.KDVDaFDkDfNvYRFfayJhtWEHVCaiA = pUaNKSDnvrHVAlCytZeYLOAnhWBbA;
						yjbhwBHARlpuyCBpoWRlKanjvGQH.GiOEcFDWQRvlKUSiqrDBpayvGpdMA = OJhTnpUYpTsBTyaQBINCMiUSROHK;
						yjbhwBHARlpuyCBpoWRlKanjvGQH.RkNXoBAFbNMvkdIsSqZWVBgqADMKA = GbgBpbchXtppEFncIpvrDLyeDwaAc;
						return yjbhwBHARlpuyCBpoWRlKanjvGQH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class bIfxNfOPOASwhxYDqnRoNdHegAakA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int XRLhllrjSFVcTGzZvtVzfnKkCKwb;

					private ElementAssignmentConflictInfo gIRAHpnABCqsJeEUueqdavtpSFkf;

					private int glbhFfnklzOuYjEYkwBKgXtUYnlF;

					private global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> nlXlnzHsvlfrbWMXYIQDWMDajPFFA;

					public global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> WjKwvTcLUdHGMrukTUeulSCJnHXp;

					private ElementAssignmentConflictCheck ERsgLyBiGSLaBZfHpQgBHjqLDuRpA;

					public ElementAssignmentConflictCheck SSLLoFGmKsaSlEFTSSzsrdtKndgCb;

					private bool idRSjsjHpYfIOMzCwIKqaTnagSIT;

					public bool vEMCKIewJLMAviwMemQKKadsEYydA;

					private bool lgKakzrvfTWnZpzoowwasPItHhNu;

					public bool VQGdBqysMddezxKRpHPyaYFtEPot;

					public ConflictCheckingHelper zEwivgHybXDEmLWzKdSRNoCLMhqJA;

					private InputMapCategory GNEHQAfoSVrAtTKgDkWbNPBclCD;

					private int CxzhcMImTHTyQNmZFmyoyawwGPsS;

					private IEnumerator<ElementAssignmentConflictInfo> LmuwHgDPFnYlTNWoFrfsoWTXamCD;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return gIRAHpnABCqsJeEUueqdavtpSFkf;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return gIRAHpnABCqsJeEUueqdavtpSFkf;
						}
					}

					[DebuggerHidden]
					public bIfxNfOPOASwhxYDqnRoNdHegAakA(int P_0)
					{
						XRLhllrjSFVcTGzZvtVzfnKkCKwb = P_0;
						glbhFfnklzOuYjEYkwBKgXtUYnlF = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xRLhllrjSFVcTGzZvtVzfnKkCKwb = XRLhllrjSFVcTGzZvtVzfnKkCKwb;
						if (xRLhllrjSFVcTGzZvtVzfnKkCKwb == -3 || xRLhllrjSFVcTGzZvtVzfnKkCKwb == 1)
						{
							try
							{
							}
							finally
							{
								oOPgzUcuJCrZEqBKIocCPjHvfgkDb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int xRLhllrjSFVcTGzZvtVzfnKkCKwb = XRLhllrjSFVcTGzZvtVzfnKkCKwb;
							ConflictCheckingHelper conflictCheckingHelper = zEwivgHybXDEmLWzKdSRNoCLMhqJA;
							if (xRLhllrjSFVcTGzZvtVzfnKkCKwb != 0)
							{
								if (xRLhllrjSFVcTGzZvtVzfnKkCKwb != 1)
								{
									return false;
								}
								XRLhllrjSFVcTGzZvtVzfnKkCKwb = -3;
								goto IL_01ab;
							}
							XRLhllrjSFVcTGzZvtVzfnKkCKwb = -1;
							if (nlXlnzHsvlfrbWMXYIQDWMDajPFFA == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.controllerType, ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.controllerId, ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.controllerMapId);
							GNEHQAfoSVrAtTKgDkWbNPBclCD = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.controllerMapCategoryId));
							if (GNEHQAfoSVrAtTKgDkWbNPBclCD == null)
							{
								return false;
							}
							CxzhcMImTHTyQNmZFmyoyawwGPsS = 0;
							goto IL_01d7;
							IL_01ab:
							if (LmuwHgDPFnYlTNWoFrfsoWTXamCD.MoveNext())
							{
								ElementAssignmentConflictInfo current = LmuwHgDPFnYlTNWoFrfsoWTXamCD.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.JDxgevEtpjfpWERpTQvxWAuWtuFpA.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								elementAssignmentConflictInfo.controllerType = ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.controllerType;
								elementAssignmentConflictInfo.controllerId = ERsgLyBiGSLaBZfHpQgBHjqLDuRpA.controllerId;
								gIRAHpnABCqsJeEUueqdavtpSFkf = elementAssignmentConflictInfo;
								XRLhllrjSFVcTGzZvtVzfnKkCKwb = 1;
								return true;
							}
							oOPgzUcuJCrZEqBKIocCPjHvfgkDb();
							LmuwHgDPFnYlTNWoFrfsoWTXamCD = null;
							goto IL_01c5;
							IL_01d7:
							if (CxzhcMImTHTyQNmZFmyoyawwGPsS < nlXlnzHsvlfrbWMXYIQDWMDajPFFA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb())
							{
								ControllerMap controllerMap = nlXlnzHsvlfrbWMXYIQDWMDajPFFA.bPBvSQSPFBOEZzzSdKegAflIdxiN(CxzhcMImTHTyQNmZFmyoyawwGPsS);
								if ((!idRSjsjHpYfIOMzCwIKqaTnagSIT || controllerMap.enabled) && (lgKakzrvfTWnZpzoowwasPItHhNu || !conflictCheckingHelper.xFJxgRUfFnyUEQNlhboIYkoIvOzc(GNEHQAfoSVrAtTKgDkWbNPBclCD, controllerMap)))
								{
									LmuwHgDPFnYlTNWoFrfsoWTXamCD = controllerMap.ElementAssignmentConflicts(ERsgLyBiGSLaBZfHpQgBHjqLDuRpA, idRSjsjHpYfIOMzCwIKqaTnagSIT).GetEnumerator();
									XRLhllrjSFVcTGzZvtVzfnKkCKwb = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							CxzhcMImTHTyQNmZFmyoyawwGPsS++;
							goto IL_01d7;
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

					private void oOPgzUcuJCrZEqBKIocCPjHvfgkDb()
					{
						XRLhllrjSFVcTGzZvtVzfnKkCKwb = -1;
						if (LmuwHgDPFnYlTNWoFrfsoWTXamCD != null)
						{
							LmuwHgDPFnYlTNWoFrfsoWTXamCD.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						bIfxNfOPOASwhxYDqnRoNdHegAakA<_0001> bIfxNfOPOASwhxYDqnRoNdHegAakA2;
						if (XRLhllrjSFVcTGzZvtVzfnKkCKwb == -2 && glbhFfnklzOuYjEYkwBKgXtUYnlF == Environment.CurrentManagedThreadId)
						{
							XRLhllrjSFVcTGzZvtVzfnKkCKwb = 0;
							bIfxNfOPOASwhxYDqnRoNdHegAakA2 = this;
						}
						else
						{
							bIfxNfOPOASwhxYDqnRoNdHegAakA2 = new bIfxNfOPOASwhxYDqnRoNdHegAakA<_0001>(0);
							bIfxNfOPOASwhxYDqnRoNdHegAakA2.zEwivgHybXDEmLWzKdSRNoCLMhqJA = zEwivgHybXDEmLWzKdSRNoCLMhqJA;
						}
						bIfxNfOPOASwhxYDqnRoNdHegAakA2.ERsgLyBiGSLaBZfHpQgBHjqLDuRpA = SSLLoFGmKsaSlEFTSSzsrdtKndgCb;
						bIfxNfOPOASwhxYDqnRoNdHegAakA2.idRSjsjHpYfIOMzCwIKqaTnagSIT = vEMCKIewJLMAviwMemQKKadsEYydA;
						bIfxNfOPOASwhxYDqnRoNdHegAakA2.lgKakzrvfTWnZpzoowwasPItHhNu = VQGdBqysMddezxKRpHPyaYFtEPot;
						bIfxNfOPOASwhxYDqnRoNdHegAakA2.nlXlnzHsvlfrbWMXYIQDWMDajPFFA = WjKwvTcLUdHGMrukTUeulSCJnHXp;
						return bIfxNfOPOASwhxYDqnRoNdHegAakA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class oLQJGMqzTrdFvPNjGfjAifZExPnpA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int aDvGZraPqJwYpFLXtDeyomuKIhlhb;

					private ElementAssignmentConflictInfo CANEAlFHxDdndHVgEtuOJrnNdGaV;

					private int ePTDvHFvBfaCTXAmUClgfRpqthRf;

					private int AARFxuDuSxiduuRTNuwWjOmQnWIGb;

					public int PfnFykPXQYqvvthDriIuvpBBZzKU;

					private JoystickMap asYWkLWySLxenAYANXeBmPUvVfDf;

					public JoystickMap EbBAnRCTjzOGgQAnkkXcInnSOEMj;

					public ConflictCheckingHelper nqDxOJJRyUCvboWFldBolixNHHwT;

					private bool FUqnyovbireYIcsNKQHZlFWHjSiHA;

					public bool xIxcbZeySJqLsMvGItLoaqtMPwyWA;

					private bool WOVfbrjBPyFGsgniMRnfoMrNfMVAA;

					public bool qtmQtcqHFcDznuRuYGdAVItUUztr;

					private int GRYhXhJVujyHfyqUjMaNCCsLFZlO;

					private IEnumerator<ElementAssignmentConflictInfo> NtMFxCuQjGktBJYCEDgSIDPfCGSq;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return CANEAlFHxDdndHVgEtuOJrnNdGaV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CANEAlFHxDdndHVgEtuOJrnNdGaV;
						}
					}

					[DebuggerHidden]
					public oLQJGMqzTrdFvPNjGfjAifZExPnpA(int P_0)
					{
						aDvGZraPqJwYpFLXtDeyomuKIhlhb = P_0;
						ePTDvHFvBfaCTXAmUClgfRpqthRf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = aDvGZraPqJwYpFLXtDeyomuKIhlhb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								bgFdWtHsTRwgFaZogixVcslAFImY();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = aDvGZraPqJwYpFLXtDeyomuKIhlhb;
							ConflictCheckingHelper conflictCheckingHelper = nqDxOJJRyUCvboWFldBolixNHHwT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								aDvGZraPqJwYpFLXtDeyomuKIhlhb = -3;
								goto IL_00ea;
							}
							aDvGZraPqJwYpFLXtDeyomuKIhlhb = -1;
							if (AARFxuDuSxiduuRTNuwWjOmQnWIGb < 0 || asYWkLWySLxenAYANXeBmPUvVfDf == null)
							{
								return false;
							}
							GRYhXhJVujyHfyqUjMaNCCsLFZlO = 0;
							goto IL_0116;
							IL_00ea:
							if (NtMFxCuQjGktBJYCEDgSIDPfCGSq.MoveNext())
							{
								ElementAssignmentConflictInfo current = NtMFxCuQjGktBJYCEDgSIDPfCGSq.Current;
								CANEAlFHxDdndHVgEtuOJrnNdGaV = current;
								aDvGZraPqJwYpFLXtDeyomuKIhlhb = 1;
								return true;
							}
							bgFdWtHsTRwgFaZogixVcslAFImY();
							NtMFxCuQjGktBJYCEDgSIDPfCGSq = null;
							goto IL_0104;
							IL_0116:
							if (GRYhXhJVujyHfyqUjMaNCCsLFZlO < conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA())
							{
								if (conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(GRYhXhJVujyHfyqUjMaNCCsLFZlO).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == AARFxuDuSxiduuRTNuwWjOmQnWIGb)
								{
									NtMFxCuQjGktBJYCEDgSIDPfCGSq = conflictCheckingHelper.RxzMeTCuzVQZcxiZVXguBcFCfTYu(ControllerType.Joystick, AARFxuDuSxiduuRTNuwWjOmQnWIGb, asYWkLWySLxenAYANXeBmPUvVfDf, FUqnyovbireYIcsNKQHZlFWHjSiHA, WOVfbrjBPyFGsgniMRnfoMrNfMVAA, conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(GRYhXhJVujyHfyqUjMaNCCsLFZlO).oMRwDdJdVKppZpMVZzpvvqJvcOCA).GetEnumerator();
									aDvGZraPqJwYpFLXtDeyomuKIhlhb = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							GRYhXhJVujyHfyqUjMaNCCsLFZlO++;
							goto IL_0116;
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

					private void bgFdWtHsTRwgFaZogixVcslAFImY()
					{
						aDvGZraPqJwYpFLXtDeyomuKIhlhb = -1;
						if (NtMFxCuQjGktBJYCEDgSIDPfCGSq != null)
						{
							NtMFxCuQjGktBJYCEDgSIDPfCGSq.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						oLQJGMqzTrdFvPNjGfjAifZExPnpA oLQJGMqzTrdFvPNjGfjAifZExPnpA2;
						if (aDvGZraPqJwYpFLXtDeyomuKIhlhb == -2 && ePTDvHFvBfaCTXAmUClgfRpqthRf == Environment.CurrentManagedThreadId)
						{
							aDvGZraPqJwYpFLXtDeyomuKIhlhb = 0;
							oLQJGMqzTrdFvPNjGfjAifZExPnpA2 = this;
						}
						else
						{
							oLQJGMqzTrdFvPNjGfjAifZExPnpA2 = new oLQJGMqzTrdFvPNjGfjAifZExPnpA(0);
							oLQJGMqzTrdFvPNjGfjAifZExPnpA2.nqDxOJJRyUCvboWFldBolixNHHwT = nqDxOJJRyUCvboWFldBolixNHHwT;
						}
						oLQJGMqzTrdFvPNjGfjAifZExPnpA2.AARFxuDuSxiduuRTNuwWjOmQnWIGb = PfnFykPXQYqvvthDriIuvpBBZzKU;
						oLQJGMqzTrdFvPNjGfjAifZExPnpA2.asYWkLWySLxenAYANXeBmPUvVfDf = EbBAnRCTjzOGgQAnkkXcInnSOEMj;
						oLQJGMqzTrdFvPNjGfjAifZExPnpA2.FUqnyovbireYIcsNKQHZlFWHjSiHA = xIxcbZeySJqLsMvGItLoaqtMPwyWA;
						oLQJGMqzTrdFvPNjGfjAifZExPnpA2.WOVfbrjBPyFGsgniMRnfoMrNfMVAA = qtmQtcqHFcDznuRuYGdAVItUUztr;
						return oLQJGMqzTrdFvPNjGfjAifZExPnpA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class symypZzZwHjyEMNABIZfcgLIuatW : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int IuDFYnrTsNRNjsLZhfdOJwJzSehL;

					private ElementAssignmentConflictInfo RdxfXuGGIiGkzmpJsTGuYeelbQGy;

					private int xpjRJcxqUzepDmFZxJdiBHmYhcgs;

					private int LjqOsAfgmRFhOKWPXfGzRnmnqRkiA;

					public int jUhDdHCHCGIoLEYVfKXTUuHqZOdMb;

					private ActionElementMap zdmuwJroRsJeaPQmdPFnublodHjdA;

					public ActionElementMap XUiMQrpPToLuxhAEkhLMBWxDKhxUA;

					public ConflictCheckingHelper UvGblIrSdoezvZNQWFljcSvRqenDA;

					private JoystickMap dgfhTyRAyFRIbndVttyaxMUwbUpS;

					public JoystickMap ZtMXjdJzlHtLMFUZTdnVvbQombtL;

					private bool ugINVgCbSoUEWqJrEepIPkwmFEPcA;

					public bool TnLPbQIXyKNetCaFDAkgXKTTGHlU;

					private bool WBGsCrmaRXbuAbGIddpboteZkgaA;

					public bool CsfthUtylhXCJzqwnaZJjmvHXFRj;

					private int noUYQUbHMCScjydiLawsUjeEcIkQ;

					private IEnumerator<ElementAssignmentConflictInfo> ddVHkXJcqpGsnmnbfrsvJwHmqcoN;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RdxfXuGGIiGkzmpJsTGuYeelbQGy;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RdxfXuGGIiGkzmpJsTGuYeelbQGy;
						}
					}

					[DebuggerHidden]
					public symypZzZwHjyEMNABIZfcgLIuatW(int P_0)
					{
						IuDFYnrTsNRNjsLZhfdOJwJzSehL = P_0;
						xpjRJcxqUzepDmFZxJdiBHmYhcgs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iuDFYnrTsNRNjsLZhfdOJwJzSehL = IuDFYnrTsNRNjsLZhfdOJwJzSehL;
						if (iuDFYnrTsNRNjsLZhfdOJwJzSehL == -3 || iuDFYnrTsNRNjsLZhfdOJwJzSehL == 1)
						{
							try
							{
							}
							finally
							{
								hwDmvgeguvfcFjXpJDXkQdolvevU();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int iuDFYnrTsNRNjsLZhfdOJwJzSehL = IuDFYnrTsNRNjsLZhfdOJwJzSehL;
							ConflictCheckingHelper uvGblIrSdoezvZNQWFljcSvRqenDA = UvGblIrSdoezvZNQWFljcSvRqenDA;
							if (iuDFYnrTsNRNjsLZhfdOJwJzSehL != 0)
							{
								if (iuDFYnrTsNRNjsLZhfdOJwJzSehL != 1)
								{
									return false;
								}
								IuDFYnrTsNRNjsLZhfdOJwJzSehL = -3;
								goto IL_00f0;
							}
							IuDFYnrTsNRNjsLZhfdOJwJzSehL = -1;
							if (LjqOsAfgmRFhOKWPXfGzRnmnqRkiA < 0 || zdmuwJroRsJeaPQmdPFnublodHjdA == null)
							{
								return false;
							}
							noUYQUbHMCScjydiLawsUjeEcIkQ = 0;
							goto IL_011c;
							IL_00f0:
							if (ddVHkXJcqpGsnmnbfrsvJwHmqcoN.MoveNext())
							{
								ElementAssignmentConflictInfo current = ddVHkXJcqpGsnmnbfrsvJwHmqcoN.Current;
								RdxfXuGGIiGkzmpJsTGuYeelbQGy = current;
								IuDFYnrTsNRNjsLZhfdOJwJzSehL = 1;
								return true;
							}
							hwDmvgeguvfcFjXpJDXkQdolvevU();
							ddVHkXJcqpGsnmnbfrsvJwHmqcoN = null;
							goto IL_010a;
							IL_011c:
							if (noUYQUbHMCScjydiLawsUjeEcIkQ < uvGblIrSdoezvZNQWFljcSvRqenDA.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA())
							{
								if (uvGblIrSdoezvZNQWFljcSvRqenDA.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(noUYQUbHMCScjydiLawsUjeEcIkQ).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == LjqOsAfgmRFhOKWPXfGzRnmnqRkiA)
								{
									ddVHkXJcqpGsnmnbfrsvJwHmqcoN = uvGblIrSdoezvZNQWFljcSvRqenDA.rqsUFdfINmfUQMRTTKhJNzdIsJKd(ControllerType.Joystick, LjqOsAfgmRFhOKWPXfGzRnmnqRkiA, dgfhTyRAyFRIbndVttyaxMUwbUpS, zdmuwJroRsJeaPQmdPFnublodHjdA, ugINVgCbSoUEWqJrEepIPkwmFEPcA, WBGsCrmaRXbuAbGIddpboteZkgaA, uvGblIrSdoezvZNQWFljcSvRqenDA.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(noUYQUbHMCScjydiLawsUjeEcIkQ).oMRwDdJdVKppZpMVZzpvvqJvcOCA).GetEnumerator();
									IuDFYnrTsNRNjsLZhfdOJwJzSehL = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							noUYQUbHMCScjydiLawsUjeEcIkQ++;
							goto IL_011c;
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

					private void hwDmvgeguvfcFjXpJDXkQdolvevU()
					{
						IuDFYnrTsNRNjsLZhfdOJwJzSehL = -1;
						if (ddVHkXJcqpGsnmnbfrsvJwHmqcoN != null)
						{
							ddVHkXJcqpGsnmnbfrsvJwHmqcoN.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						symypZzZwHjyEMNABIZfcgLIuatW symypZzZwHjyEMNABIZfcgLIuatW2;
						if (IuDFYnrTsNRNjsLZhfdOJwJzSehL == -2 && xpjRJcxqUzepDmFZxJdiBHmYhcgs == Environment.CurrentManagedThreadId)
						{
							IuDFYnrTsNRNjsLZhfdOJwJzSehL = 0;
							symypZzZwHjyEMNABIZfcgLIuatW2 = this;
						}
						else
						{
							symypZzZwHjyEMNABIZfcgLIuatW2 = new symypZzZwHjyEMNABIZfcgLIuatW(0);
							symypZzZwHjyEMNABIZfcgLIuatW2.UvGblIrSdoezvZNQWFljcSvRqenDA = UvGblIrSdoezvZNQWFljcSvRqenDA;
						}
						symypZzZwHjyEMNABIZfcgLIuatW2.LjqOsAfgmRFhOKWPXfGzRnmnqRkiA = jUhDdHCHCGIoLEYVfKXTUuHqZOdMb;
						symypZzZwHjyEMNABIZfcgLIuatW2.dgfhTyRAyFRIbndVttyaxMUwbUpS = ZtMXjdJzlHtLMFUZTdnVvbQombtL;
						symypZzZwHjyEMNABIZfcgLIuatW2.zdmuwJroRsJeaPQmdPFnublodHjdA = XUiMQrpPToLuxhAEkhLMBWxDKhxUA;
						symypZzZwHjyEMNABIZfcgLIuatW2.ugINVgCbSoUEWqJrEepIPkwmFEPcA = TnLPbQIXyKNetCaFDAkgXKTTGHlU;
						symypZzZwHjyEMNABIZfcgLIuatW2.WBGsCrmaRXbuAbGIddpboteZkgaA = CsfthUtylhXCJzqwnaZJjmvHXFRj;
						return symypZzZwHjyEMNABIZfcgLIuatW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class xfUHODKjEMusHBXxQUUGOqAIaepFb : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int BKGeIbHYOtcnVPsmzLKpEZCnVulQA;

					private ElementAssignmentConflictInfo KkGHNeFIojdzUJYXOaETKfVbUiKA;

					private int zkErJvYtSZAuNESFmJetvolXOdwo;

					private ElementAssignmentConflictCheck wDcfAoQFSxDtzhFcLkPEaTqppPAOA;

					public ElementAssignmentConflictCheck sOlTEOJIbsroyGHHJCOYZQmKHzJC;

					public ConflictCheckingHelper xvJbpaKdWhJidjtUgRWfuxyrTePlA;

					private bool KgETllDsZvAMRKdXEeYLMHqNZtKI;

					public bool dIfONjWzCHaZVlXNmEHeXyRmgiUS;

					private bool zJRBDreaVianuXBBpWNQWbeHEShBA;

					public bool qNOcdZwnatSEKktXliVvvLjszuXf;

					private int ntQvuAzCfwcdIFARhhhEzMRtNmouA;

					private IEnumerator<ElementAssignmentConflictInfo> cIAPpeWFlzUsKNhKGExPFNVLrhpTA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KkGHNeFIojdzUJYXOaETKfVbUiKA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KkGHNeFIojdzUJYXOaETKfVbUiKA;
						}
					}

					[DebuggerHidden]
					public xfUHODKjEMusHBXxQUUGOqAIaepFb(int P_0)
					{
						BKGeIbHYOtcnVPsmzLKpEZCnVulQA = P_0;
						zkErJvYtSZAuNESFmJetvolXOdwo = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bKGeIbHYOtcnVPsmzLKpEZCnVulQA = BKGeIbHYOtcnVPsmzLKpEZCnVulQA;
						if (bKGeIbHYOtcnVPsmzLKpEZCnVulQA == -3 || bKGeIbHYOtcnVPsmzLKpEZCnVulQA == 1)
						{
							try
							{
							}
							finally
							{
								HUZMaSudxKzifNvevChGIavSNTzP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int bKGeIbHYOtcnVPsmzLKpEZCnVulQA = BKGeIbHYOtcnVPsmzLKpEZCnVulQA;
							ConflictCheckingHelper conflictCheckingHelper = xvJbpaKdWhJidjtUgRWfuxyrTePlA;
							if (bKGeIbHYOtcnVPsmzLKpEZCnVulQA != 0)
							{
								if (bKGeIbHYOtcnVPsmzLKpEZCnVulQA != 1)
								{
									return false;
								}
								BKGeIbHYOtcnVPsmzLKpEZCnVulQA = -3;
								goto IL_00f3;
							}
							BKGeIbHYOtcnVPsmzLKpEZCnVulQA = -1;
							if (wDcfAoQFSxDtzhFcLkPEaTqppPAOA.controllerId < 0 || wDcfAoQFSxDtzhFcLkPEaTqppPAOA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							ntQvuAzCfwcdIFARhhhEzMRtNmouA = 0;
							goto IL_011f;
							IL_00f3:
							if (cIAPpeWFlzUsKNhKGExPFNVLrhpTA.MoveNext())
							{
								ElementAssignmentConflictInfo current = cIAPpeWFlzUsKNhKGExPFNVLrhpTA.Current;
								KkGHNeFIojdzUJYXOaETKfVbUiKA = current;
								BKGeIbHYOtcnVPsmzLKpEZCnVulQA = 1;
								return true;
							}
							HUZMaSudxKzifNvevChGIavSNTzP();
							cIAPpeWFlzUsKNhKGExPFNVLrhpTA = null;
							goto IL_010d;
							IL_011f:
							if (ntQvuAzCfwcdIFARhhhEzMRtNmouA < conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA())
							{
								if (conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(ntQvuAzCfwcdIFARhhhEzMRtNmouA).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == wDcfAoQFSxDtzhFcLkPEaTqppPAOA.controllerId)
								{
									cIAPpeWFlzUsKNhKGExPFNVLrhpTA = conflictCheckingHelper.OWAjeWgsXDMoNyiMQKUEYbEHDhuDA(wDcfAoQFSxDtzhFcLkPEaTqppPAOA, KgETllDsZvAMRKdXEeYLMHqNZtKI, zJRBDreaVianuXBBpWNQWbeHEShBA, conflictCheckingHelper.oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(ntQvuAzCfwcdIFARhhhEzMRtNmouA).oMRwDdJdVKppZpMVZzpvvqJvcOCA).GetEnumerator();
									BKGeIbHYOtcnVPsmzLKpEZCnVulQA = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							ntQvuAzCfwcdIFARhhhEzMRtNmouA++;
							goto IL_011f;
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

					private void HUZMaSudxKzifNvevChGIavSNTzP()
					{
						BKGeIbHYOtcnVPsmzLKpEZCnVulQA = -1;
						if (cIAPpeWFlzUsKNhKGExPFNVLrhpTA != null)
						{
							cIAPpeWFlzUsKNhKGExPFNVLrhpTA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						xfUHODKjEMusHBXxQUUGOqAIaepFb xfUHODKjEMusHBXxQUUGOqAIaepFb2;
						if (BKGeIbHYOtcnVPsmzLKpEZCnVulQA == -2 && zkErJvYtSZAuNESFmJetvolXOdwo == Environment.CurrentManagedThreadId)
						{
							BKGeIbHYOtcnVPsmzLKpEZCnVulQA = 0;
							xfUHODKjEMusHBXxQUUGOqAIaepFb2 = this;
						}
						else
						{
							xfUHODKjEMusHBXxQUUGOqAIaepFb2 = new xfUHODKjEMusHBXxQUUGOqAIaepFb(0);
							xfUHODKjEMusHBXxQUUGOqAIaepFb2.xvJbpaKdWhJidjtUgRWfuxyrTePlA = xvJbpaKdWhJidjtUgRWfuxyrTePlA;
						}
						xfUHODKjEMusHBXxQUUGOqAIaepFb2.wDcfAoQFSxDtzhFcLkPEaTqppPAOA = sOlTEOJIbsroyGHHJCOYZQmKHzJC;
						xfUHODKjEMusHBXxQUUGOqAIaepFb2.KgETllDsZvAMRKdXEeYLMHqNZtKI = dIfONjWzCHaZVlXNmEHeXyRmgiUS;
						xfUHODKjEMusHBXxQUUGOqAIaepFb2.zJRBDreaVianuXBBpWNQWbeHEShBA = qNOcdZwnatSEKktXliVvvLjszuXf;
						return xfUHODKjEMusHBXxQUUGOqAIaepFb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player JDxgevEtpjfpWERpTQvxWAuWtuFpA;

				private readonly ControllerHelper oFlFLjIIIAZeNEpyEubwitRrYiuX;

				private readonly int VeTWfwZnNphYJiQKvBNwGnZqFDmfA;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					VeTWfwZnNphYJiQKvBNwGnZqFDmfA = ReInput.id;
					JDxgevEtpjfpWERpTQvxWAuWtuFpA = P_0;
					oFlFLjIIIAZeNEpyEubwitRrYiuX = P_1;
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => ACPjoBvMByAqAFVeuqpFSfMEXZJLA(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => oqDrqrlkbMJAXHJAXyRHXJbIpVnn(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => crmkgxNkqDqSwhSRulqbQXWCKHrv(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => BjtbhTpLfJsrVHqFnTnICaHRoyXJ(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => BpWAjAcxQqWrqTBHaTqXvNlyhGwEA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => YVOwOPrEtDqEtTmPvwpyqlMvgLIIA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => pGlsBQLIVxdyNGubKXWSEozwdcjM(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => pvspOGdRPHTWIbWrhMehlzMdnpuX(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return qnVqbfqPYyISmbngMVBpapMphvAC(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return OnMijeTIVVPhcCiAabRUJKKikbjeb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return yYycCmyOJzTLlPRdKkLVSzYeKsgv(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return WiQDSPPgnNFvDxuInHnogyGFXCVFA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ZUCVHtqxmdnHCWQfdBNOhUayYNKU(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => RPoHulPaUYpwWuCjvFilDjgJTzxy(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => PezUfUVQPdhUAMYKvUxQcrYQFOld(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => ExqKkIkBgNrDFQQcQLuFLHnESJrB(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => unTFlWbPOkRblaIifKyQCQrEEEuGB(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ZhFRejBergjXoYGRphqOlbLGNYyU(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => quEeLPOhreCqonrsQChmNlBSSiL(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => pKCuTJLpEvefWMJOfAQQEIPeMlNo(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return jNKVvtvuVapboSUtmfmysVvnLIuD(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return dmvhKKWsUYeJFDhzbPWcYxuCTcBf(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return UFfAnMikkuFpfePhiFaxLANPvjcx(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return sTIDjSGrTAXQbBzEhVDkGKzSPcrCA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => mAcSqUMhqbaObvVmPcwsTKNCTKgE(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => gVqmlmYDvRjQgEbxOlFUnnxapTjA(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => yvDBhRcugZteRwdqHoSMslWBOgKU(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => NSNmBtMFDdhSkjScfsbKJszBJoCdb(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => yrydMrPZTzNPGvHOkuOcuSkNgSDu(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => LEomqZuGfVBThAIOKbwzOhaWDTeCA(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => VCWkUEQEFLEZRkxnXmTrNkOnzypo(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => oHiTYbMirpaoAESsZXgkBssasKDB(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return JjtEkCoheieftBAwFZpcGdxznofW(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return RcRAjKGouQOdcgctikTNHWdOoEYvA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return WcAZGnFNRoJaZGQsaKlJZZeIHBXf(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return cHCOjiosUaIEUvLESQBzKmryAxVZ(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => YYUqRkTpMyrQMbiSWvFlpqGSvRsO(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => IYqPZooNuuLtmPaacfkssUJmCzGi(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => LTviJXplObsMnYtzLNUfgAoWOPvP(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => oMtWxWWumalddkUZBEmRawFIOLtN(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => GstCdcWpXQdtSBSRDCtokDSFjCeU(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ZqBvteVwIZKkUnqkFcCuGReFaEzqA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => xdrsJvrNTqDXReTOcIvuJkgewozmA(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => VrLCsTpQDXetAhcuVzSOiGTfudSvA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VeTWfwZnNphYJiQKvBNwGnZqFDmfA)
					{
						ReInput.CheckInitialized(VeTWfwZnNphYJiQKvBNwGnZqFDmfA);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return skhYoOHchkqnotIHNAilECntTWoqA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return HpHdqoDpjmFkzreEQfXAmjtAzkvrA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return zCEqhdJCzbfYgOxyighIwHKcoQLK(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return zUPasslPGIsURXaBIcgiWBhvLFnD(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool ACPjoBvMByAqAFVeuqpFSfMEXZJLA(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0 && kMWdnVxdtrCDwFJnNdxyAqGpVIfc(ControllerType.Joystick, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA))
						{
							return true;
						}
					}
					return false;
				}

				private bool BpWAjAcxQqWrqTBHaTqXvNlyhGwEA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0 && ksXkEjBCwNzxcUlNkCmCWqDjjbzs(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA))
						{
							return true;
						}
					}
					return false;
				}

				private bool qnVqbfqPYyISmbngMVBpapMphvAC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0.controllerId && RqjDfmlStXRhbmECBJRQtXAYJDjO(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA))
						{
							return true;
						}
					}
					return false;
				}

				private bool oqDrqrlkbMJAXHJAXyRHXJbIpVnn(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return kMWdnVxdtrCDwFJnNdxyAqGpVIfc(ControllerType.Keyboard, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private bool YVOwOPrEtDqEtTmPvwpyqlMvgLIIA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return ksXkEjBCwNzxcUlNkCmCWqDjjbzs(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private bool OnMijeTIVVPhcCiAabRUJKKikbjeb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return RqjDfmlStXRhbmECBJRQtXAYJDjO(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private bool crmkgxNkqDqSwhSRulqbQXWCKHrv(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return kMWdnVxdtrCDwFJnNdxyAqGpVIfc(ControllerType.Mouse, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private bool pGlsBQLIVxdyNGubKXWSEozwdcjM(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return ksXkEjBCwNzxcUlNkCmCWqDjjbzs(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private bool yYycCmyOJzTLlPRdKkLVSzYeKsgv(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return RqjDfmlStXRhbmECBJRQtXAYJDjO(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private bool BjtbhTpLfJsrVHqFnTnICaHRoyXJ(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0 && kMWdnVxdtrCDwFJnNdxyAqGpVIfc(ControllerType.Custom, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA))
						{
							return true;
						}
					}
					return false;
				}

				private bool pvspOGdRPHTWIbWrhMehlzMdnpuX(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0 && ksXkEjBCwNzxcUlNkCmCWqDjjbzs(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA))
						{
							return true;
						}
					}
					return false;
				}

				private bool WiQDSPPgnNFvDxuInHnogyGFXCVFA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0.controllerId && RqjDfmlStXRhbmECBJRQtXAYJDjO(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(oLQJGMqzTrdFvPNjGfjAifZExPnpA))]
				private IEnumerable<ElementAssignmentConflictInfo> ZUCVHtqxmdnHCWQfdBNOhUayYNKU(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new oLQJGMqzTrdFvPNjGfjAifZExPnpA(-2)
					{
						nqDxOJJRyUCvboWFldBolixNHHwT = this,
						PfnFykPXQYqvvthDriIuvpBBZzKU = P_0,
						EbBAnRCTjzOGgQAnkkXcInnSOEMj = P_1,
						xIxcbZeySJqLsMvGItLoaqtMPwyWA = P_2,
						qtmQtcqHFcDznuRuYGdAVItUUztr = P_3
					};
				}

				[IteratorStateMachine(typeof(symypZzZwHjyEMNABIZfcgLIuatW))]
				private IEnumerable<ElementAssignmentConflictInfo> unTFlWbPOkRblaIifKyQCQrEEEuGB(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new symypZzZwHjyEMNABIZfcgLIuatW(-2)
					{
						UvGblIrSdoezvZNQWFljcSvRqenDA = this,
						jUhDdHCHCGIoLEYVfKXTUuHqZOdMb = P_0,
						ZtMXjdJzlHtLMFUZTdnVvbQombtL = P_1,
						XUiMQrpPToLuxhAEkhLMBWxDKhxUA = P_2,
						TnLPbQIXyKNetCaFDAkgXKTTGHlU = P_3,
						CsfthUtylhXCJzqwnaZJjmvHXFRj = P_4
					};
				}

				[IteratorStateMachine(typeof(xfUHODKjEMusHBXxQUUGOqAIaepFb))]
				private IEnumerable<ElementAssignmentConflictInfo> jNKVvtvuVapboSUtmfmysVvnLIuD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new xfUHODKjEMusHBXxQUUGOqAIaepFb(-2)
					{
						xvJbpaKdWhJidjtUgRWfuxyrTePlA = this,
						sOlTEOJIbsroyGHHJCOYZQmKHzJC = P_0,
						dIfONjWzCHaZVlXNmEHeXyRmgiUS = P_1,
						qNOcdZwnatSEKktXliVvvLjszuXf = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> RPoHulPaUYpwWuCjvFilDjgJTzxy(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return RxzMeTCuzVQZcxiZVXguBcFCfTYu(ControllerType.Keyboard, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> ZhFRejBergjXoYGRphqOlbLGNYyU(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return rqsUFdfINmfUQMRTTKhJNzdIsJKd(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> dmvhKKWsUYeJFDhzbPWcYxuCTcBf(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return OWAjeWgsXDMoNyiMQKUEYbEHDhuDA(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> PezUfUVQPdhUAMYKvUxQcrYQFOld(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return RxzMeTCuzVQZcxiZVXguBcFCfTYu(ControllerType.Mouse, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private IEnumerable<ElementAssignmentConflictInfo> quEeLPOhreCqonrsQChmNlBSSiL(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return rqsUFdfINmfUQMRTTKhJNzdIsJKd(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private IEnumerable<ElementAssignmentConflictInfo> UFfAnMikkuFpfePhiFaxLANPvjcx(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return OWAjeWgsXDMoNyiMQKUEYbEHDhuDA(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				[IteratorStateMachine(typeof(KtXeXSGVEAfixiItGMMLmuyIoyIN))]
				private IEnumerable<ElementAssignmentConflictInfo> ExqKkIkBgNrDFQQcQLuFLHnESJrB(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new KtXeXSGVEAfixiItGMMLmuyIoyIN(-2)
					{
						guKhkpxrWKFOCxsITYFSvkesETrgA = this,
						ongwNjNituaaneJzGrGaxnQdVpujA = P_0,
						FGQIfdEHYqKXjdOkJEhmVvZMYiZK = P_1,
						fnlFXXbKgJIoTzolhzlSpWHUbYGoA = P_2,
						ehxeDqXRbNjmiERFnynhTogyrjlfA = P_3
					};
				}

				[IteratorStateMachine(typeof(QwkGOsMbuehDMUCnISbcOCDYQLnc))]
				private IEnumerable<ElementAssignmentConflictInfo> pKCuTJLpEvefWMJOfAQQEIPeMlNo(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new QwkGOsMbuehDMUCnISbcOCDYQLnc(-2)
					{
						HHikcVRNrEELaNPoKmDNzosyHJyD = this,
						BAKWxfcTusRpTRXgakkEZWcadVNA = P_0,
						eqfDzeitOiYlQQCLGhpkECBnTZiEb = P_1,
						oiGkJXxlWDMysewcKyquszbkBeti = P_2,
						weijGbGWtbwSEWXMYfcXMNIfgYhdA = P_3,
						xbUoCJunULGEEtEmsEBbdQTbhZLl = P_4
					};
				}

				[IteratorStateMachine(typeof(YOTewGHSYwaZzloTgBlXTmkbfgdab))]
				private IEnumerable<ElementAssignmentConflictInfo> sTIDjSGrTAXQbBzEhVDkGKzSPcrCA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new YOTewGHSYwaZzloTgBlXTmkbfgdab(-2)
					{
						WtSNCfPSPZqqkMDwhLCagyHAluNO = this,
						vpKLeKvOBJDxWKDmCruJRlCOEtZkA = P_0,
						jwqyiowxtCSNCfqTnExBSamtZYXL = P_1,
						mTaTHvAfafKLZyQnjdfDEkkkQGbn = P_2
					};
				}

				private int mAcSqUMhqbaObvVmPcwsTKNCTKgE(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += aZuyqsHwolNNeJQSDtbRwcrecbrKA(ControllerType.Joystick, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA);
						}
					}
					return num;
				}

				private int yrydMrPZTzNPGvHOkuOcuSkNgSDu(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += qKCxkLnammzHbAavoZfRvLAvGlUJ(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA);
						}
					}
					return num;
				}

				private int JjtEkCoheieftBAwFZpcGdxznofW(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0.controllerId)
						{
							num += JjGEnvksZPkCnkGebdbFVwOdnlP(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA);
						}
					}
					return num;
				}

				private int gVqmlmYDvRjQgEbxOlFUnnxapTjA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return aZuyqsHwolNNeJQSDtbRwcrecbrKA(ControllerType.Keyboard, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private int LEomqZuGfVBThAIOKbwzOhaWDTeCA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return qKCxkLnammzHbAavoZfRvLAvGlUJ(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private int RcRAjKGouQOdcgctikTNHWdOoEYvA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return JjGEnvksZPkCnkGebdbFVwOdnlP(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA);
				}

				private int yvDBhRcugZteRwdqHoSMslWBOgKU(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return aZuyqsHwolNNeJQSDtbRwcrecbrKA(ControllerType.Mouse, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private int VCWkUEQEFLEZRkxnXmTrNkOnzypo(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return qKCxkLnammzHbAavoZfRvLAvGlUJ(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private int WcAZGnFNRoJaZGQsaKlJZZeIHBXf(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return JjGEnvksZPkCnkGebdbFVwOdnlP(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd);
				}

				private int NSNmBtMFDdhSkjScfsbKJszBJoCdb(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += aZuyqsHwolNNeJQSDtbRwcrecbrKA(ControllerType.Custom, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA);
						}
					}
					return num;
				}

				private int oHiTYbMirpaoAESsZXgkBssasKDB(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += qKCxkLnammzHbAavoZfRvLAvGlUJ(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA);
						}
					}
					return num;
				}

				private int cHCOjiosUaIEUvLESQBzKmryAxVZ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0.controllerId)
						{
							num += JjGEnvksZPkCnkGebdbFVwOdnlP(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA);
						}
					}
					return num;
				}

				private int YYUqRkTpMyrQMbiSWvFlpqGSvRsO(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += OaVvtmuolMIuZRCCYaPDjItjLXHn(ControllerType.Joystick, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA, P_4);
						}
					}
					return num;
				}

				private int GstCdcWpXQdtSBSRDCtokDSFjCeU(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += FCFIHhvUThRAFokZqGrqFyxFUGnNA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA, P_5);
						}
					}
					return num;
				}

				private int skhYoOHchkqnotIHNAilECntTWoqA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0.controllerId)
						{
							num += fhFShIRbComyKFGcDzcdiMHaCSHf(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.nsqaHMJRypoBaiNKqPflbeoJljtcc.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA, P_3);
						}
					}
					return num;
				}

				private int IYqPZooNuuLtmPaacfkssUJmCzGi(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return OaVvtmuolMIuZRCCYaPDjItjLXHn(ControllerType.Keyboard, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA, P_3);
				}

				private int ZqBvteVwIZKkUnqkFcCuGReFaEzqA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return FCFIHhvUThRAFokZqGrqFyxFUGnNA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA, P_4);
				}

				private int HpHdqoDpjmFkzreEQfXAmjtAzkvrA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return fhFShIRbComyKFGcDzcdiMHaCSHf(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.ePfiMHzGjpesAJnXbjUSelvGCgSwA, P_3);
				}

				private int LTviJXplObsMnYtzLNUfgAoWOPvP(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return OaVvtmuolMIuZRCCYaPDjItjLXHn(ControllerType.Mouse, 0, P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd, P_3);
				}

				private int xdrsJvrNTqDXReTOcIvuJkgewozmA(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return FCFIHhvUThRAFokZqGrqFyxFUGnNA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd, P_4);
				}

				private int zCEqhdJCzbfYgOxyighIwHKcoQLK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return fhFShIRbComyKFGcDzcdiMHaCSHf(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.NyePHlzdYcQlmXMNKIEWEhoQBjbd, P_3);
				}

				private int oMtWxWWumalddkUZBEmRawFIOLtN(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += OaVvtmuolMIuZRCCYaPDjItjLXHn(ControllerType.Custom, P_0, P_1, P_2, P_3, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA, P_4);
						}
					}
					return num;
				}

				private int VrLCsTpQDXetAhcuVzSOiGTfudSvA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							num += FCFIHhvUThRAFokZqGrqFyxFUGnNA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA, P_5);
						}
					}
					return num;
				}

				private int zUPasslPGIsURXaBIcgiWBhvLFnD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.nmydqOADyBNZdjaBvZQRcgEpucQnA(); i++)
					{
						if (oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0.controllerId)
						{
							num += fhFShIRbComyKFGcDzcdiMHaCSHf(P_0, P_1, P_2, oFlFLjIIIAZeNEpyEubwitRrYiuX.GfTgEEjlXpJyESOaZaYqHyCNHnys.MtwZFyLUwaaefeuyimwLjZMYlHAB(i).oMRwDdJdVKppZpMVZzpvvqJvcOCA, P_3);
						}
					}
					return num;
				}

				private bool kMWdnVxdtrCDwFJnNdxyAqGpVIfc<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_5) where _0001 : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return false;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_5.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_5.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool ksXkEjBCwNzxcUlNkCmCWqDjjbzs<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_6.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool RqjDfmlStXRhbmECBJRQtXAYJDjO<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_3) where _0001 : ControllerMap
				{
					if (P_3 == null)
					{
						return false;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return false;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_3.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_3.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(pjhUetJifHrCZHaFlDaAbhclBJwLA))]
				private IEnumerable<ElementAssignmentConflictInfo> RxzMeTCuzVQZcxiZVXguBcFCfTYu<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_5) where _0001 : ControllerMap
				{
					return new pjhUetJifHrCZHaFlDaAbhclBJwLA<_0001>(-2)
					{
						HgvLzprrgQSoCbhsLYyVGSWOUEk = this,
						zLxqfABTQrNMJcLbhmREIrMXUWpH = P_0,
						SaosssfHnVIjgRodZSfhQnZjwkYP = P_1,
						DHjmCCjsPVeiaOLvkdHUJETiOVDiA = P_2,
						sXBzWwNNUEIYzNxJOMDTiFnQIxaH = P_3,
						bqScauPQtITqpVzUuCOkEnmvjizO = P_4,
						seJxqpJDirQUdyjEzFZdEOmsFbuab = P_5
					};
				}

				[IteratorStateMachine(typeof(YjbhwBHARlpuyCBpoWRlKanjvGQH))]
				private IEnumerable<ElementAssignmentConflictInfo> rqsUFdfINmfUQMRTTKhJNzdIsJKd<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_6) where _0001 : ControllerMap
				{
					return new YjbhwBHARlpuyCBpoWRlKanjvGQH<_0001>(-2)
					{
						cCHZdvaNAJNyPKGVTgRhHIYkKlEq = this,
						oqQfhOFtopOxksGEpbekDafAcncY = P_0,
						qDdKBpwjpSdzLdcGXoTaWgouqJzRA = P_1,
						FHANJCCyrbwrRGSluoipOimgtjlI = P_2,
						RAEEkwvnNEOZIaCVSFGWRrBLibZr = P_3,
						pUaNKSDnvrHVAlCytZeYLOAnhWBbA = P_4,
						OJhTnpUYpTsBTyaQBINCMiUSROHK = P_5,
						GbgBpbchXtppEFncIpvrDLyeDwaAc = P_6
					};
				}

				[IteratorStateMachine(typeof(bIfxNfOPOASwhxYDqnRoNdHegAakA))]
				private IEnumerable<ElementAssignmentConflictInfo> OWAjeWgsXDMoNyiMQKUEYbEHDhuDA<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_3) where _0001 : ControllerMap
				{
					return new bIfxNfOPOASwhxYDqnRoNdHegAakA<_0001>(-2)
					{
						zEwivgHybXDEmLWzKdSRNoCLMhqJA = this,
						SSLLoFGmKsaSlEFTSSzsrdtKndgCb = P_0,
						vEMCKIewJLMAviwMemQKKadsEYydA = P_1,
						VQGdBqysMddezxKRpHPyaYFtEPot = P_2,
						WjKwvTcLUdHGMrukTUeulSCJnHXp = P_3
					};
				}

				private int aZuyqsHwolNNeJQSDtbRwcrecbrKA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_5) where _0001 : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_5.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int qKCxkLnammzHbAavoZfRvLAvGlUJ<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_6.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int JjGEnvksZPkCnkGebdbFVwOdnlP<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_3) where _0001 : ControllerMap
				{
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_3.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int OaVvtmuolMIuZRCCYaPDjItjLXHn<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
				{
					P_6?.Clear();
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_5.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(mapCategory, controllerMap)))
						{
							num += controllerMap.ItCUGWipsbSXnwPaLdhDyEkLPfzc(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int FCFIHhvUThRAFokZqGrqFyxFUGnNA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_6.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.APpATFydmqdisQTNkPBnodjHbwzp(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int fhFShIRbComyKFGcDzcdiMHaCSHf<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
				{
					P_4?.Clear();
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.cLFOTXBjzlMfxMSeRWBhGFJkuhvb(); i++)
					{
						ControllerMap controllerMap = P_3.bPBvSQSPFBOEZzzSdKegAflIdxiN(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !xFJxgRUfFnyUEQNlhboIYkoIvOzc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.aHLeYxerPeUnYNeIEbCAvvtUSnFN(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool xFJxgRUfFnyUEQNlhboIYkoIvOzc(InputMapCategory P_0, ControllerMap P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0.checkConflictsWithAllCategories)
					{
						return false;
					}
					IList<int> checkConflictsCategoryIds = P_0.checkConflictsCategoryIds;
					if (checkConflictsCategoryIds == null)
					{
						return true;
					}
					for (int i = 0; i < checkConflictsCategoryIds.Count; i++)
					{
						if (checkConflictsCategoryIds[i] == P_1.categoryId)
						{
							return false;
						}
					}
					return true;
				}
			}

			[DefaultMember("Item")]
			internal interface XCOErbHoOlwtReVrlBlQrQooVXdNA
			{
				AWgeajfBjHIPFotyXrmQOkYDysesA UrCcCzZmZFSONZaBHdbCRpMByVMw { get; }

				ControllerType idcYZHmwzKfFqwHCdeEqJLeNeyfm { get; }

				int FwIGimYHKsSdutRnXvajJeatuVHB { get; }

				bool oOXPmokktGMnIRoFFVPZZMxeDCzm(Controller P_0);

				bool yaFPMojfoCAlpmKQWVrPKhXZLKMn(int P_0);

				void FEdcTOhMabuIZIwDFIawVBpdirGdA(int P_0);

				void SYnZBSfYPewZnMNmICoesAMVfsWK(Controller P_0);

				void uhXVKlHLXfhlVEnsVOFXtxuMubqy(int P_0);

				Controller TboWkWvykGGIbVogRCGoTdcLCrUW(int P_0);

				Controller SfhVyrnbGHBXzmosWNNspAwTFPwg(string P_0);

				int otOelPAnOKxSKUdABxlDsvxLlrlnA(Controller P_0);

				int HtWvGaTgyVAQoAaAUFaMIkCnEUsO(int P_0);

				int fhQCCvhpeaalPNVBwlgizmwGzvBQ(string P_0);

				void CLSkRuJgRJjGgKMdtHVRtsgEFuGj();

				AWgeajfBjHIPFotyXrmQOkYDysesA QlllfGYgQhzrYUdVBsXmntapKYEs(int P_0);

				AWgeajfBjHIPFotyXrmQOkYDysesA hvjJnZKuRgeBnRejcBjucuBjYccW(Controller P_0);

				void evzuTMkhZsadeiMLXCSIMuVNyjfmA(AWgeajfBjHIPFotyXrmQOkYDysesA P_0);
			}

			internal interface AWgeajfBjHIPFotyXrmQOkYDysesA
			{
				BpzomrqmbmNinOxWAGGlQTtkPnsX iuMldFPvAqBfeiUXQrGwudCQSSbq { get; }

				Controller pQefzbMuBblbJGuGRnxcoWyVLFcD { get; }

				double ybVAhVaiUKVjjdhyCBrBovvlJpHc { get; }
			}

			[DefaultMember("Item")]
			internal sealed class TEzcHaVJErqgWnDVyEPxJbcUKPwoA<_0001, _0002> : XCOErbHoOlwtReVrlBlQrQooVXdNA where _0001 : Controller where _0002 : ControllerMap
			{
				public class AQofIYFZBCdRNEcCaMfJVSEGzChdB : AWgeajfBjHIPFotyXrmQOkYDysesA
				{
					public _0001 bJkzuoVFDtsUqMpDgBxoNgOZJmNj;

					public global::vvqWcefspViLvBkIonynvYaRLpFT<_0002> oMRwDdJdVKppZpMVZzpvvqJvcOCA;

					public double rgSYjXqjQElcDBwSrXrgtDEoCTJE;

					Controller AWgeajfBjHIPFotyXrmQOkYDysesA.hvYIoKATIxTZoUUYfGUeAEOIMInD => bJkzuoVFDtsUqMpDgBxoNgOZJmNj;

					BpzomrqmbmNinOxWAGGlQTtkPnsX AWgeajfBjHIPFotyXrmQOkYDysesA.yYPLmxCbTrUiCMrmhGNRTBoxuOGN => oMRwDdJdVKppZpMVZzpvvqJvcOCA;

					double AWgeajfBjHIPFotyXrmQOkYDysesA.qhfYLNOTPGbfvLsAYhavNOYSKZNM => rgSYjXqjQElcDBwSrXrgtDEoCTJE;

					public AQofIYFZBCdRNEcCaMfJVSEGzChdB(_0001 P_0, global::vvqWcefspViLvBkIonynvYaRLpFT<_0002> P_1)
					{
						bJkzuoVFDtsUqMpDgBxoNgOZJmNj = P_0;
						oMRwDdJdVKppZpMVZzpvvqJvcOCA = P_1;
					}

					public void SLtVxKbNLsTVuKJsKTLqBBvnfcmb()
					{
						rgSYjXqjQElcDBwSrXrgtDEoCTJE = ReInput.unscaledTime;
					}
				}

				private List<AQofIYFZBCdRNEcCaMfJVSEGzChdB> OwlkGjvDEATguRbVCrTOINHICXuaA;

				private List<_0001> gWjEkOShVBNceDwoJhnvRhCfbcmC;

				private ReadOnlyCollection<_0001> uaQnLPNKDbZuFaTfHwCNhPxglvFp;

				private readonly ControllerType FksCFjkwcsUNiesAypfdfAUDLEjrA;

				int XCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB => OwlkGjvDEATguRbVCrTOINHICXuaA.Count;

				public IList<_0001> pXSxwkIiHkcbzcvFuFlFiSHpDWydA => uaQnLPNKDbZuFaTfHwCNhPxglvFp;

				public AQofIYFZBCdRNEcCaMfJVSEGzChdB ZWTYWiZilWoPHVUEuwmTwHGepOMU => OwlkGjvDEATguRbVCrTOINHICXuaA[P_0];

				ControllerType XCOErbHoOlwtReVrlBlQrQooVXdNA.idcYZHmwzKfFqwHCdeEqJLeNeyfm => FksCFjkwcsUNiesAypfdfAUDLEjrA;

				AWgeajfBjHIPFotyXrmQOkYDysesA XCOErbHoOlwtReVrlBlQrQooVXdNA.PkaeuCjNapKFzLzNZcIEGOqVOuEU => OwlkGjvDEATguRbVCrTOINHICXuaA[index];

				public TEzcHaVJErqgWnDVyEPxJbcUKPwoA()
				{
					if ((object)SVQbmGoCgjXlQooYDoNZCFflMVzP.qqfCvQPqQGHYUrbwJjmCzcyDiREg<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					FksCFjkwcsUNiesAypfdfAUDLEjrA = SVQbmGoCgjXlQooYDoNZCFflMVzP.lKxuyBclViGMVsApqlKPSvKnBlsn(typeof(_0001));
					OwlkGjvDEATguRbVCrTOINHICXuaA = new List<AQofIYFZBCdRNEcCaMfJVSEGzChdB>();
					gWjEkOShVBNceDwoJhnvRhCfbcmC = new List<_0001>();
					uaQnLPNKDbZuFaTfHwCNhPxglvFp = new ReadOnlyCollection<_0001>(gWjEkOShVBNceDwoJhnvRhCfbcmC);
				}

				public AQofIYFZBCdRNEcCaMfJVSEGzChdB PYqvITNalvcWZiHnIEgzpnVqNTKc(int P_0)
				{
					if (FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Keyboard || FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = LvyWVuOXgTarfeRyPjjcuivzifdh(P_0);
					if (num < 0)
					{
						return null;
					}
					return OwlkGjvDEATguRbVCrTOINHICXuaA[num];
				}

				public AQofIYFZBCdRNEcCaMfJVSEGzChdB fRcDWXKWAdOhvumdiaOMAAImScjKA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return PYqvITNalvcWZiHnIEgzpnVqNTKc(P_0.id);
				}

				public void fEEyeHVkEtiJdnQcSEKZzFoAIaRS(AQofIYFZBCdRNEcCaMfJVSEGzChdB P_0)
				{
					if (P_0 != null)
					{
						OwlkGjvDEATguRbVCrTOINHICXuaA.Add(P_0);
						gWjEkOShVBNceDwoJhnvRhCfbcmC.Add(P_0.bJkzuoVFDtsUqMpDgBxoNgOZJmNj);
					}
				}

				public void zMbylEEmoMjpFdhefAGHCIDKqUojB(int P_0)
				{
					if (FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Keyboard || FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (LvyWVuOXgTarfeRyPjjcuivzifdh(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < OwlkGjvDEATguRbVCrTOINHICXuaA.Count; i++)
					{
						if (OwlkGjvDEATguRbVCrTOINHICXuaA[i].bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							MpDIjLDEqjEoFdAGJMVyjHpDqzZP(i);
							break;
						}
					}
				}

				void XCOErbHoOlwtReVrlBlQrQooVXdNA.FEdcTOhMabuIZIwDFIawVBpdirGdA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in zMbylEEmoMjpFdhefAGHCIDKqUojB
					this.zMbylEEmoMjpFdhefAGHCIDKqUojB(P_0);
				}

				public void oIQUQjiJLSfejdkmWwYjKDLnNkwQ(_0001 P_0)
				{
					if (P_0 != null && P_0.type == FksCFjkwcsUNiesAypfdfAUDLEjrA)
					{
						zMbylEEmoMjpFdhefAGHCIDKqUojB(P_0.id);
					}
				}

				public void MpDIjLDEqjEoFdAGJMVyjHpDqzZP(int P_0)
				{
					if (P_0 >= 0 && P_0 < OwlkGjvDEATguRbVCrTOINHICXuaA.Count)
					{
						OwlkGjvDEATguRbVCrTOINHICXuaA.RemoveAt(P_0);
						gWjEkOShVBNceDwoJhnvRhCfbcmC.RemoveAt(P_0);
					}
				}

				void XCOErbHoOlwtReVrlBlQrQooVXdNA.uhXVKlHLXfhlVEnsVOFXtxuMubqy(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in MpDIjLDEqjEoFdAGJMVyjHpDqzZP
					this.MpDIjLDEqjEoFdAGJMVyjHpDqzZP(P_0);
				}

				public _0001 IQqufKJAvGLbeYSsNBHECdpKEWPn(int P_0)
				{
					if (FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Keyboard || FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = LvyWVuOXgTarfeRyPjjcuivzifdh(P_0);
					if (num < 0)
					{
						return null;
					}
					return OwlkGjvDEATguRbVCrTOINHICXuaA[num].bJkzuoVFDtsUqMpDgBxoNgOZJmNj;
				}

				public bool fmJZUQXzHzNrUmhLMkMagGvqNUbx(int P_0)
				{
					if (FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Keyboard || FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < OwlkGjvDEATguRbVCrTOINHICXuaA.Count; i++)
					{
						if (OwlkGjvDEATguRbVCrTOINHICXuaA[i].bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool XCOErbHoOlwtReVrlBlQrQooVXdNA.yaFPMojfoCAlpmKQWVrPKhXZLKMn(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in fmJZUQXzHzNrUmhLMkMagGvqNUbx
					return this.fmJZUQXzHzNrUmhLMkMagGvqNUbx(P_0);
				}

				public bool BisITVKkmXKbmdjqnTjcIhHxgxqg(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != FksCFjkwcsUNiesAypfdfAUDLEjrA)
					{
						return false;
					}
					return fmJZUQXzHzNrUmhLMkMagGvqNUbx(P_0.id);
				}

				public int LvyWVuOXgTarfeRyPjjcuivzifdh(int P_0)
				{
					if (FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Keyboard || FksCFjkwcsUNiesAypfdfAUDLEjrA == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < OwlkGjvDEATguRbVCrTOINHICXuaA.Count; i++)
					{
						if (OwlkGjvDEATguRbVCrTOINHICXuaA[i].bJkzuoVFDtsUqMpDgBxoNgOZJmNj.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int XCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in LvyWVuOXgTarfeRyPjjcuivzifdh
					return this.LvyWVuOXgTarfeRyPjjcuivzifdh(P_0);
				}

				public int llXnmqRIVkfWIIiIUgNCitUVOIfBA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != FksCFjkwcsUNiesAypfdfAUDLEjrA)
					{
						return -1;
					}
					return LvyWVuOXgTarfeRyPjjcuivzifdh(P_0.id);
				}

				public int qxzdtVKlpSfhwUScfoUuAkKZFADPA(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < OwlkGjvDEATguRbVCrTOINHICXuaA.Count; i++)
					{
						if (OwlkGjvDEATguRbVCrTOINHICXuaA[i].bJkzuoVFDtsUqMpDgBxoNgOZJmNj.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int XCOErbHoOlwtReVrlBlQrQooVXdNA.fhQCCvhpeaalPNVBwlgizmwGzvBQ(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in qxzdtVKlpSfhwUScfoUuAkKZFADPA
					return this.qxzdtVKlpSfhwUScfoUuAkKZFADPA(P_0);
				}

				public void rOKwsqoehKQgQPPnSfcZHWttBBnS()
				{
					OwlkGjvDEATguRbVCrTOINHICXuaA.Clear();
					gWjEkOShVBNceDwoJhnvRhCfbcmC.Clear();
				}

				void XCOErbHoOlwtReVrlBlQrQooVXdNA.CLSkRuJgRJjGgKMdtHVRtsgEFuGj()
				{
					//ILSpy generated this explicit interface implementation from .override directive in rOKwsqoehKQgQPPnSfcZHWttBBnS
					this.rOKwsqoehKQgQPPnSfcZHWttBBnS();
				}

				AWgeajfBjHIPFotyXrmQOkYDysesA XCOErbHoOlwtReVrlBlQrQooVXdNA.GetEntry(int controllerId)
				{
					return PYqvITNalvcWZiHnIEgzpnVqNTKc(controllerId);
				}

				AWgeajfBjHIPFotyXrmQOkYDysesA XCOErbHoOlwtReVrlBlQrQooVXdNA.GetEntry(Controller controller)
				{
					if (controller as _0001 == null)
					{
						return null;
					}
					return fRcDWXKWAdOhvumdiaOMAAImScjKA(controller as _0001);
				}

				void XCOErbHoOlwtReVrlBlQrQooVXdNA.AddEntry(AWgeajfBjHIPFotyXrmQOkYDysesA entry)
				{
					fEEyeHVkEtiJdnQcSEKZzFoAIaRS((AQofIYFZBCdRNEcCaMfJVSEGzChdB)entry);
				}

				void XCOErbHoOlwtReVrlBlQrQooVXdNA.RemoveController(Controller controller)
				{
					oIQUQjiJLSfejdkmWwYjKDLnNkwQ(controller as _0001);
				}

				Controller XCOErbHoOlwtReVrlBlQrQooVXdNA.GetController(int controllerId)
				{
					return IQqufKJAvGLbeYSsNBHECdpKEWPn(controllerId);
				}

				bool XCOErbHoOlwtReVrlBlQrQooVXdNA.Contains(Controller controller)
				{
					return BisITVKkmXKbmdjqnTjcIhHxgxqg(controller as _0001);
				}

				int XCOErbHoOlwtReVrlBlQrQooVXdNA.IndexOf(Controller controller)
				{
					return llXnmqRIVkfWIIiIUgNCitUVOIfBA(controller as _0001);
				}

				Controller XCOErbHoOlwtReVrlBlQrQooVXdNA.GetControllerWithTag(string tag)
				{
					int num = qxzdtVKlpSfhwUScfoUuAkKZFADPA(tag);
					if (num < 0)
					{
						return null;
					}
					return OwlkGjvDEATguRbVCrTOINHICXuaA[num].bJkzuoVFDtsUqMpDgBxoNgOZJmNj;
				}
			}

			internal class PGHOuYhTMIlgfkLkxnNQDmeZfWZu
			{
				public readonly int CdDMVOEYEeaEACfRYzOcwBUJJAEg;

				private ControllerType[] oeFexsFWIjpDHarYKWGdwamfLkowA;

				private XCOErbHoOlwtReVrlBlQrQooVXdNA[] fwysWrQpSaEExaoFdhRknMGFTfTr;

				public XCOErbHoOlwtReVrlBlQrQooVXdNA AQncRaVEtJlioIjHbOyFGxGWSnZE(int P_0)
				{
					return fwysWrQpSaEExaoFdhRknMGFTfTr[P_0];
				}

				public ControllerType JVGUyxtSjWjXjesjYdedruJrrSFy(int P_0)
				{
					return oeFexsFWIjpDHarYKWGdwamfLkowA[P_0];
				}

				public PGHOuYhTMIlgfkLkxnNQDmeZfWZu(int P_0)
				{
					CdDMVOEYEeaEACfRYzOcwBUJJAEg = MathTools.Max(0, P_0);
					oeFexsFWIjpDHarYKWGdwamfLkowA = new ControllerType[P_0];
					fwysWrQpSaEExaoFdhRknMGFTfTr = new XCOErbHoOlwtReVrlBlQrQooVXdNA[P_0];
				}

				public XCOErbHoOlwtReVrlBlQrQooVXdNA YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType P_0)
				{
					for (int i = 0; i < CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						if (P_0 == oeFexsFWIjpDHarYKWGdwamfLkowA[i])
						{
							return fwysWrQpSaEExaoFdhRknMGFTfTr[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void mMHlffAECEsojiLNkhxeuVYngPRR(int P_0, ControllerType P_1, XCOErbHoOlwtReVrlBlQrQooVXdNA P_2)
				{
					oeFexsFWIjpDHarYKWGdwamfLkowA[P_0] = P_1;
					fwysWrQpSaEExaoFdhRknMGFTfTr[P_0] = P_2;
				}
			}

			private class ClezMzHGVattqKgyOdCeSSlvJsdy
			{
				public class cQnfrIYYceEdekKgheHtgNGgJDGHA
				{
					public int QyubKfOhziEGjjJtTBcwCZTygOrgb;

					public global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> jEshaibPFWVyCZKVvsbiceLQTpLh;

					public double ImIWjGbBlBlRvMCFclPdriStRtqn;

					public cQnfrIYYceEdekKgheHtgNGgJDGHA(int P_0, global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> P_1, double P_2)
					{
						QyubKfOhziEGjjJtTBcwCZTygOrgb = P_0;
						jEshaibPFWVyCZKVvsbiceLQTpLh = P_1;
						ImIWjGbBlBlRvMCFclPdriStRtqn = P_2;
					}
				}

				private readonly List<cQnfrIYYceEdekKgheHtgNGgJDGHA> TUDBezvAmCOqhAQpdVIqfvoIvCTs;

				private readonly Player oudkQQFWgzhDzCsDYpppxJexPovx;

				public ClezMzHGVattqKgyOdCeSSlvJsdy(Player P_0)
				{
					oudkQQFWgzhDzCsDYpppxJexPovx = P_0;
					TUDBezvAmCOqhAQpdVIqfvoIvCTs = new List<cQnfrIYYceEdekKgheHtgNGgJDGHA>();
				}

				public void sSWztljGhasrZynGQgGVpWPMcAYD(Joystick P_0, global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> P_1)
				{
					for (int i = 0; i < TUDBezvAmCOqhAQpdVIqfvoIvCTs.Count; i++)
					{
						cQnfrIYYceEdekKgheHtgNGgJDGHA cQnfrIYYceEdekKgheHtgNGgJDGHA2 = TUDBezvAmCOqhAQpdVIqfvoIvCTs[i];
						if (cQnfrIYYceEdekKgheHtgNGgJDGHA2.QyubKfOhziEGjjJtTBcwCZTygOrgb == P_0.id)
						{
							cQnfrIYYceEdekKgheHtgNGgJDGHA2.jEshaibPFWVyCZKVvsbiceLQTpLh = P_1;
							cQnfrIYYceEdekKgheHtgNGgJDGHA2.ImIWjGbBlBlRvMCFclPdriStRtqn = ReInput.realTime;
							return;
						}
					}
					cQnfrIYYceEdekKgheHtgNGgJDGHA item = new cQnfrIYYceEdekKgheHtgNGgJDGHA(P_0.id, P_1, ReInput.realTime);
					TUDBezvAmCOqhAQpdVIqfvoIvCTs.Add(item);
				}

				public void gZpjNDtGeUrUwDBkkyFfrQNpWxSH(TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB P_0)
				{
					sSWztljGhasrZynGQgGVpWPMcAYD(P_0.bJkzuoVFDtsUqMpDgBxoNgOZJmNj, P_0.oMRwDdJdVKppZpMVZzpvvqJvcOCA);
				}

				public void gbfqNdeHCQhYfcFejApocQQfxVXUB()
				{
					for (int i = 0; i < TUDBezvAmCOqhAQpdVIqfvoIvCTs.Count; i++)
					{
						if (!oudkQQFWgzhDzCsDYpppxJexPovx.controllers.ContainsController(ControllerType.Joystick, TUDBezvAmCOqhAQpdVIqfvoIvCTs[i].QyubKfOhziEGjjJtTBcwCZTygOrgb))
						{
							TUDBezvAmCOqhAQpdVIqfvoIvCTs[i].jEshaibPFWVyCZKVvsbiceLQTpLh = null;
						}
					}
				}

				public cQnfrIYYceEdekKgheHtgNGgJDGHA hBVhmVHYlzSVDNIMNCczhcDFKwvJb(int P_0)
				{
					int num = muFmorWpEzWXhLaZbWFkbSlBVnWS(P_0);
					if (num < 0)
					{
						return null;
					}
					return TUDBezvAmCOqhAQpdVIqfvoIvCTs[num];
				}

				public bool PzgFVoZjVHVQqzqPscdEFVYsRMIjA(int P_0)
				{
					for (int i = 0; i < TUDBezvAmCOqhAQpdVIqfvoIvCTs.Count; i++)
					{
						if (TUDBezvAmCOqhAQpdVIqfvoIvCTs[i].QyubKfOhziEGjjJtTBcwCZTygOrgb == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int muFmorWpEzWXhLaZbWFkbSlBVnWS(int P_0)
				{
					for (int i = 0; i < TUDBezvAmCOqhAQpdVIqfvoIvCTs.Count; i++)
					{
						if (TUDBezvAmCOqhAQpdVIqfvoIvCTs[i].QyubKfOhziEGjjJtTBcwCZTygOrgb == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void sDLVQweCBxoHLnqWFDKnbiJpCjCfA()
				{
					TUDBezvAmCOqhAQpdVIqfvoIvCTs.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class xPPoHEdSZFdtuAUVeqMRLaHpFvuUA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int UeinQQCDYuTgsbzAnUUBilczYKWV;

					private ActionElementMap kYuXXKPOqoavpTRQdMBvEWSDsfxD;

					private int rWAAuvlxvYsxxnwQInfxCivUeOxaA;

					public MapHelper lVpGmaDDowhOGQOiGXqPafPzpMsc;

					private int bIEjHzKSbZhwdESSPJEqElGurwdf;

					public int NnJzGdFokjtLCOOsoFFRIfcdkcLl;

					private bool DnkluYjJEsGjKfYrdgzTblXRlfTEA;

					public bool lQyaUSaaOnHrqHRrnyUJyRnGbjKK;

					private int DxWjmQqxCIjGyHLApeUofzjrbqVuA;

					private int AsogIkhutReJKDrArHkXYJskxJKw;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA iDDeATAOkADVyEdsxCsoGXFbtNzqb;

					private int dPgfzehocGPSCXCXDxqNMDMDnBBo;

					private int PiOFYfysqQnsXAFkoBWdiesXCSzL;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX VWNBixlkemCzlCmXigDZonkgzbYd;

					private int zeoSmxfYYGxnKqjNUIpkMrrVGVbt;

					private int lmKysRONJtNcIpgDOCfguwigzmkU;

					private IEnumerator<ActionElementMap> uvXeRjiJWwaaHGbuZKWOCqyCuXfX;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return kYuXXKPOqoavpTRQdMBvEWSDsfxD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kYuXXKPOqoavpTRQdMBvEWSDsfxD;
						}
					}

					[DebuggerHidden]
					public xPPoHEdSZFdtuAUVeqMRLaHpFvuUA(int P_0)
					{
						UeinQQCDYuTgsbzAnUUBilczYKWV = P_0;
						rWAAuvlxvYsxxnwQInfxCivUeOxaA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ueinQQCDYuTgsbzAnUUBilczYKWV = UeinQQCDYuTgsbzAnUUBilczYKWV;
						if (ueinQQCDYuTgsbzAnUUBilczYKWV == -3 || ueinQQCDYuTgsbzAnUUBilczYKWV == 1)
						{
							try
							{
							}
							finally
							{
								RyWRDgrBCZLIWtVrfCbfMbhYRAXD();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ueinQQCDYuTgsbzAnUUBilczYKWV = UeinQQCDYuTgsbzAnUUBilczYKWV;
							MapHelper mapHelper = lVpGmaDDowhOGQOiGXqPafPzpMsc;
							if (ueinQQCDYuTgsbzAnUUBilczYKWV != 0)
							{
								if (ueinQQCDYuTgsbzAnUUBilczYKWV != 1)
								{
									return false;
								}
								UeinQQCDYuTgsbzAnUUBilczYKWV = -3;
								goto IL_0177;
							}
							UeinQQCDYuTgsbzAnUUBilczYKWV = -1;
							if (ReInput._id != mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
							{
								ReInput.CheckInitialized(mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
								return false;
							}
							if (bIEjHzKSbZhwdESSPJEqElGurwdf < 0)
							{
								return false;
							}
							DxWjmQqxCIjGyHLApeUofzjrbqVuA = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
							AsogIkhutReJKDrArHkXYJskxJKw = 0;
							goto IL_01f7;
							IL_0177:
							if (uvXeRjiJWwaaHGbuZKWOCqyCuXfX.MoveNext())
							{
								ActionElementMap current = uvXeRjiJWwaaHGbuZKWOCqyCuXfX.Current;
								kYuXXKPOqoavpTRQdMBvEWSDsfxD = current;
								UeinQQCDYuTgsbzAnUUBilczYKWV = 1;
								return true;
							}
							RyWRDgrBCZLIWtVrfCbfMbhYRAXD();
							uvXeRjiJWwaaHGbuZKWOCqyCuXfX = null;
							goto IL_0191;
							IL_0191:
							lmKysRONJtNcIpgDOCfguwigzmkU++;
							goto IL_01a3;
							IL_01cd:
							if (PiOFYfysqQnsXAFkoBWdiesXCSzL < dPgfzehocGPSCXCXDxqNMDMDnBBo)
							{
								VWNBixlkemCzlCmXigDZonkgzbYd = iDDeATAOkADVyEdsxCsoGXFbtNzqb.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(PiOFYfysqQnsXAFkoBWdiesXCSzL).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								zeoSmxfYYGxnKqjNUIpkMrrVGVbt = VWNBixlkemCzlCmXigDZonkgzbYd.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								lmKysRONJtNcIpgDOCfguwigzmkU = 0;
								goto IL_01a3;
							}
							iDDeATAOkADVyEdsxCsoGXFbtNzqb = null;
							AsogIkhutReJKDrArHkXYJskxJKw++;
							goto IL_01f7;
							IL_01a3:
							if (lmKysRONJtNcIpgDOCfguwigzmkU < zeoSmxfYYGxnKqjNUIpkMrrVGVbt)
							{
								if (VWNBixlkemCzlCmXigDZonkgzbYd.IMbAidiclopVawbUkoIYAkGvwawAA(lmKysRONJtNcIpgDOCfguwigzmkU) is ControllerMapWithAxes controllerMapWithAxes && (!DnkluYjJEsGjKfYrdgzTblXRlfTEA || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(bIEjHzKSbZhwdESSPJEqElGurwdf))
								{
									uvXeRjiJWwaaHGbuZKWOCqyCuXfX = controllerMapWithAxes.AxisMapsWithAction(bIEjHzKSbZhwdESSPJEqElGurwdf, DnkluYjJEsGjKfYrdgzTblXRlfTEA).GetEnumerator();
									UeinQQCDYuTgsbzAnUUBilczYKWV = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							VWNBixlkemCzlCmXigDZonkgzbYd = null;
							PiOFYfysqQnsXAFkoBWdiesXCSzL++;
							goto IL_01cd;
							IL_01f7:
							if (AsogIkhutReJKDrArHkXYJskxJKw < DxWjmQqxCIjGyHLApeUofzjrbqVuA)
							{
								iDDeATAOkADVyEdsxCsoGXFbtNzqb = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(AsogIkhutReJKDrArHkXYJskxJKw);
								dPgfzehocGPSCXCXDxqNMDMDnBBo = iDDeATAOkADVyEdsxCsoGXFbtNzqb.FwIGimYHKsSdutRnXvajJeatuVHB;
								PiOFYfysqQnsXAFkoBWdiesXCSzL = 0;
								goto IL_01cd;
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

					private void RyWRDgrBCZLIWtVrfCbfMbhYRAXD()
					{
						UeinQQCDYuTgsbzAnUUBilczYKWV = -1;
						if (uvXeRjiJWwaaHGbuZKWOCqyCuXfX != null)
						{
							uvXeRjiJWwaaHGbuZKWOCqyCuXfX.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						xPPoHEdSZFdtuAUVeqMRLaHpFvuUA xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2;
						if (UeinQQCDYuTgsbzAnUUBilczYKWV == -2 && rWAAuvlxvYsxxnwQInfxCivUeOxaA == Environment.CurrentManagedThreadId)
						{
							UeinQQCDYuTgsbzAnUUBilczYKWV = 0;
							xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2 = this;
						}
						else
						{
							xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2 = new xPPoHEdSZFdtuAUVeqMRLaHpFvuUA(0);
							xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2.lVpGmaDDowhOGQOiGXqPafPzpMsc = lVpGmaDDowhOGQOiGXqPafPzpMsc;
						}
						xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2.bIEjHzKSbZhwdESSPJEqElGurwdf = NnJzGdFokjtLCOOsoFFRIfcdkcLl;
						xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2.DnkluYjJEsGjKfYrdgzTblXRlfTEA = lQyaUSaaOnHrqHRrnyUJyRnGbjKK;
						return xPPoHEdSZFdtuAUVeqMRLaHpFvuUA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class ybxIPWkCjVcUePAwmriSuESrfZCkA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int PTlAlDIYjWxlGsJbFZUBaJanQNOcb;

					private ActionElementMap ichGBlZQGnZjAqOEMToEZbjIWeQT;

					private int UeokzBDCVLDnWhLGXgBEvabDSRutA;

					public MapHelper fnZsdHIwNujzurRcbaZTEQVZxppF;

					private int jAgLYquJSEJSfVkwruyWLRDmHchT;

					public int byHVmiLBMJSjiAOGjrcfisGRjVTw;

					private bool dQsrLhPmfGcxWwodAQHvrZfcJEbi;

					public bool ZqPpwGbFqDFDJdpLsWATPsojORBA;

					private int WQnhQUwXBkUlMoCoKcUnBJANleZc;

					private int XvKKGdgfyZSgsBGtANWikcHgpGHR;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA GPPVWiBrrWarOdLxkDxEHHkpEZHQ;

					private int XPnoVGkwbVwqQsbxHBszOOmFoAzD;

					private int rBoolUkPCrdxBRBmEFWJujWixFqx;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX zesffSdUpMPyfvtdoMoPZtiITPqoA;

					private int mkQPshVdlgkCSgnhMhSbhXuHxIjOA;

					private int BBhPabHdmTqjNJfyDdgvIWBmkNfo;

					private IEnumerator<ActionElementMap> xIBKJqSldEEDMTkJnBvKgEdWylYOA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ichGBlZQGnZjAqOEMToEZbjIWeQT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ichGBlZQGnZjAqOEMToEZbjIWeQT;
						}
					}

					[DebuggerHidden]
					public ybxIPWkCjVcUePAwmriSuESrfZCkA(int P_0)
					{
						PTlAlDIYjWxlGsJbFZUBaJanQNOcb = P_0;
						UeokzBDCVLDnWhLGXgBEvabDSRutA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pTlAlDIYjWxlGsJbFZUBaJanQNOcb = PTlAlDIYjWxlGsJbFZUBaJanQNOcb;
						if (pTlAlDIYjWxlGsJbFZUBaJanQNOcb == -3 || pTlAlDIYjWxlGsJbFZUBaJanQNOcb == 1)
						{
							try
							{
							}
							finally
							{
								kUExatkgJfgrpexFIdrEgflgNkXaA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int pTlAlDIYjWxlGsJbFZUBaJanQNOcb = PTlAlDIYjWxlGsJbFZUBaJanQNOcb;
							MapHelper mapHelper = fnZsdHIwNujzurRcbaZTEQVZxppF;
							if (pTlAlDIYjWxlGsJbFZUBaJanQNOcb != 0)
							{
								if (pTlAlDIYjWxlGsJbFZUBaJanQNOcb != 1)
								{
									return false;
								}
								PTlAlDIYjWxlGsJbFZUBaJanQNOcb = -3;
								goto IL_016c;
							}
							PTlAlDIYjWxlGsJbFZUBaJanQNOcb = -1;
							if (ReInput._id != mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
							{
								ReInput.CheckInitialized(mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
								return false;
							}
							if (jAgLYquJSEJSfVkwruyWLRDmHchT < 0)
							{
								return false;
							}
							WQnhQUwXBkUlMoCoKcUnBJANleZc = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
							XvKKGdgfyZSgsBGtANWikcHgpGHR = 0;
							goto IL_01ec;
							IL_016c:
							if (xIBKJqSldEEDMTkJnBvKgEdWylYOA.MoveNext())
							{
								ActionElementMap current = xIBKJqSldEEDMTkJnBvKgEdWylYOA.Current;
								ichGBlZQGnZjAqOEMToEZbjIWeQT = current;
								PTlAlDIYjWxlGsJbFZUBaJanQNOcb = 1;
								return true;
							}
							kUExatkgJfgrpexFIdrEgflgNkXaA();
							xIBKJqSldEEDMTkJnBvKgEdWylYOA = null;
							goto IL_0186;
							IL_0186:
							BBhPabHdmTqjNJfyDdgvIWBmkNfo++;
							goto IL_0198;
							IL_01c2:
							if (rBoolUkPCrdxBRBmEFWJujWixFqx < XPnoVGkwbVwqQsbxHBszOOmFoAzD)
							{
								zesffSdUpMPyfvtdoMoPZtiITPqoA = GPPVWiBrrWarOdLxkDxEHHkpEZHQ.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(rBoolUkPCrdxBRBmEFWJujWixFqx).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								mkQPshVdlgkCSgnhMhSbhXuHxIjOA = zesffSdUpMPyfvtdoMoPZtiITPqoA.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								BBhPabHdmTqjNJfyDdgvIWBmkNfo = 0;
								goto IL_0198;
							}
							GPPVWiBrrWarOdLxkDxEHHkpEZHQ = null;
							XvKKGdgfyZSgsBGtANWikcHgpGHR++;
							goto IL_01ec;
							IL_0198:
							if (BBhPabHdmTqjNJfyDdgvIWBmkNfo < mkQPshVdlgkCSgnhMhSbhXuHxIjOA)
							{
								ControllerMap controllerMap = zesffSdUpMPyfvtdoMoPZtiITPqoA.IMbAidiclopVawbUkoIYAkGvwawAA(BBhPabHdmTqjNJfyDdgvIWBmkNfo);
								if ((!dQsrLhPmfGcxWwodAQHvrZfcJEbi || controllerMap.enabled) && controllerMap.ContainsAction(jAgLYquJSEJSfVkwruyWLRDmHchT))
								{
									xIBKJqSldEEDMTkJnBvKgEdWylYOA = controllerMap.ButtonMapsWithAction(jAgLYquJSEJSfVkwruyWLRDmHchT, dQsrLhPmfGcxWwodAQHvrZfcJEbi).GetEnumerator();
									PTlAlDIYjWxlGsJbFZUBaJanQNOcb = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							zesffSdUpMPyfvtdoMoPZtiITPqoA = null;
							rBoolUkPCrdxBRBmEFWJujWixFqx++;
							goto IL_01c2;
							IL_01ec:
							if (XvKKGdgfyZSgsBGtANWikcHgpGHR < WQnhQUwXBkUlMoCoKcUnBJANleZc)
							{
								GPPVWiBrrWarOdLxkDxEHHkpEZHQ = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(XvKKGdgfyZSgsBGtANWikcHgpGHR);
								XPnoVGkwbVwqQsbxHBszOOmFoAzD = GPPVWiBrrWarOdLxkDxEHHkpEZHQ.FwIGimYHKsSdutRnXvajJeatuVHB;
								rBoolUkPCrdxBRBmEFWJujWixFqx = 0;
								goto IL_01c2;
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

					private void kUExatkgJfgrpexFIdrEgflgNkXaA()
					{
						PTlAlDIYjWxlGsJbFZUBaJanQNOcb = -1;
						if (xIBKJqSldEEDMTkJnBvKgEdWylYOA != null)
						{
							xIBKJqSldEEDMTkJnBvKgEdWylYOA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						ybxIPWkCjVcUePAwmriSuESrfZCkA ybxIPWkCjVcUePAwmriSuESrfZCkA2;
						if (PTlAlDIYjWxlGsJbFZUBaJanQNOcb == -2 && UeokzBDCVLDnWhLGXgBEvabDSRutA == Environment.CurrentManagedThreadId)
						{
							PTlAlDIYjWxlGsJbFZUBaJanQNOcb = 0;
							ybxIPWkCjVcUePAwmriSuESrfZCkA2 = this;
						}
						else
						{
							ybxIPWkCjVcUePAwmriSuESrfZCkA2 = new ybxIPWkCjVcUePAwmriSuESrfZCkA(0);
							ybxIPWkCjVcUePAwmriSuESrfZCkA2.fnZsdHIwNujzurRcbaZTEQVZxppF = fnZsdHIwNujzurRcbaZTEQVZxppF;
						}
						ybxIPWkCjVcUePAwmriSuESrfZCkA2.jAgLYquJSEJSfVkwruyWLRDmHchT = byHVmiLBMJSjiAOGjrcfisGRjVTw;
						ybxIPWkCjVcUePAwmriSuESrfZCkA2.dQsrLhPmfGcxWwodAQHvrZfcJEbi = ZqPpwGbFqDFDJdpLsWATPsojORBA;
						return ybxIPWkCjVcUePAwmriSuESrfZCkA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class luaQBHuhhdUKBLkTnxRxDEzPQArr : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int YrZTGebKDTkOIAnDUjsNJECCCFdUA;

					private ActionElementMap BmXfLpvRylxXOtbGVhupZRlxboOn;

					private int sjACIbBjEMCiqLIGjkwXZnXgrnfE;

					private int FCTTuTTlzqALmhrOSxxlcMbMlGuu;

					public int BGCsnEzHDEsYSOhEwpjZXFFqFDYaA;

					public MapHelper eAiVcbriRjoKDGcWOFoHoNNmruyo;

					private ControllerType LnwKfrOQHKDzlAyYvlwCyzquUdrc;

					public ControllerType ONNawMbfxBXvCUlIOQLKMFovUXJV;

					private bool qPrHpfWzQJXeYXzAJJGmrXZIujIJ;

					public bool vuiFyEDXGccwkngWdfsooOthAEMeb;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA rPienokAgYNiFvMIrMAemzJRtbND;

					private int OmbqMwiBsZHelnzVqaQelwHgnyXO;

					private IList<ControllerMap> FLWPtJNsucGsfCUdWZIZaaLmFonG;

					private int ydivyAZZFLlplEBHsnWcnFICxEtT;

					private IEnumerator<ActionElementMap> rAFwgUsAsUSYZYSeUiYzjPqPLfXV;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return BmXfLpvRylxXOtbGVhupZRlxboOn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BmXfLpvRylxXOtbGVhupZRlxboOn;
						}
					}

					[DebuggerHidden]
					public luaQBHuhhdUKBLkTnxRxDEzPQArr(int P_0)
					{
						YrZTGebKDTkOIAnDUjsNJECCCFdUA = P_0;
						sjACIbBjEMCiqLIGjkwXZnXgrnfE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int yrZTGebKDTkOIAnDUjsNJECCCFdUA = YrZTGebKDTkOIAnDUjsNJECCCFdUA;
						if (yrZTGebKDTkOIAnDUjsNJECCCFdUA == -3 || yrZTGebKDTkOIAnDUjsNJECCCFdUA == 1)
						{
							try
							{
							}
							finally
							{
								HBqClLrYwFsfSrjlFqghxzuMoAGj();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int yrZTGebKDTkOIAnDUjsNJECCCFdUA = YrZTGebKDTkOIAnDUjsNJECCCFdUA;
							MapHelper mapHelper = eAiVcbriRjoKDGcWOFoHoNNmruyo;
							if (yrZTGebKDTkOIAnDUjsNJECCCFdUA != 0)
							{
								if (yrZTGebKDTkOIAnDUjsNJECCCFdUA != 1)
								{
									return false;
								}
								YrZTGebKDTkOIAnDUjsNJECCCFdUA = -3;
								goto IL_0150;
							}
							YrZTGebKDTkOIAnDUjsNJECCCFdUA = -1;
							if (FCTTuTTlzqALmhrOSxxlcMbMlGuu < 0)
							{
								return false;
							}
							rPienokAgYNiFvMIrMAemzJRtbND = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(LnwKfrOQHKDzlAyYvlwCyzquUdrc);
							OmbqMwiBsZHelnzVqaQelwHgnyXO = 0;
							goto IL_01ab;
							IL_0150:
							if (rAFwgUsAsUSYZYSeUiYzjPqPLfXV.MoveNext())
							{
								ActionElementMap current = rAFwgUsAsUSYZYSeUiYzjPqPLfXV.Current;
								BmXfLpvRylxXOtbGVhupZRlxboOn = current;
								YrZTGebKDTkOIAnDUjsNJECCCFdUA = 1;
								return true;
							}
							HBqClLrYwFsfSrjlFqghxzuMoAGj();
							rAFwgUsAsUSYZYSeUiYzjPqPLfXV = null;
							goto IL_016a;
							IL_017c:
							if (ydivyAZZFLlplEBHsnWcnFICxEtT < FLWPtJNsucGsfCUdWZIZaaLmFonG.Count)
							{
								if (!(FLWPtJNsucGsfCUdWZIZaaLmFonG[ydivyAZZFLlplEBHsnWcnFICxEtT] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!qPrHpfWzQJXeYXzAJJGmrXZIujIJ || FLWPtJNsucGsfCUdWZIZaaLmFonG[ydivyAZZFLlplEBHsnWcnFICxEtT].enabled) && FLWPtJNsucGsfCUdWZIZaaLmFonG[ydivyAZZFLlplEBHsnWcnFICxEtT].ContainsAction(FCTTuTTlzqALmhrOSxxlcMbMlGuu))
								{
									rAFwgUsAsUSYZYSeUiYzjPqPLfXV = (FLWPtJNsucGsfCUdWZIZaaLmFonG[ydivyAZZFLlplEBHsnWcnFICxEtT] as ControllerMapWithAxes).AxisMapsWithAction(FCTTuTTlzqALmhrOSxxlcMbMlGuu, qPrHpfWzQJXeYXzAJJGmrXZIujIJ).GetEnumerator();
									YrZTGebKDTkOIAnDUjsNJECCCFdUA = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							FLWPtJNsucGsfCUdWZIZaaLmFonG = null;
							OmbqMwiBsZHelnzVqaQelwHgnyXO++;
							goto IL_01ab;
							IL_016a:
							ydivyAZZFLlplEBHsnWcnFICxEtT++;
							goto IL_017c;
							IL_01ab:
							if (OmbqMwiBsZHelnzVqaQelwHgnyXO < rPienokAgYNiFvMIrMAemzJRtbND.FwIGimYHKsSdutRnXvajJeatuVHB)
							{
								FLWPtJNsucGsfCUdWZIZaaLmFonG = rPienokAgYNiFvMIrMAemzJRtbND.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(OmbqMwiBsZHelnzVqaQelwHgnyXO).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
								ydivyAZZFLlplEBHsnWcnFICxEtT = 0;
								goto IL_017c;
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

					private void HBqClLrYwFsfSrjlFqghxzuMoAGj()
					{
						YrZTGebKDTkOIAnDUjsNJECCCFdUA = -1;
						if (rAFwgUsAsUSYZYSeUiYzjPqPLfXV != null)
						{
							rAFwgUsAsUSYZYSeUiYzjPqPLfXV.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						luaQBHuhhdUKBLkTnxRxDEzPQArr luaQBHuhhdUKBLkTnxRxDEzPQArr2;
						if (YrZTGebKDTkOIAnDUjsNJECCCFdUA == -2 && sjACIbBjEMCiqLIGjkwXZnXgrnfE == Environment.CurrentManagedThreadId)
						{
							YrZTGebKDTkOIAnDUjsNJECCCFdUA = 0;
							luaQBHuhhdUKBLkTnxRxDEzPQArr2 = this;
						}
						else
						{
							luaQBHuhhdUKBLkTnxRxDEzPQArr2 = new luaQBHuhhdUKBLkTnxRxDEzPQArr(0);
							luaQBHuhhdUKBLkTnxRxDEzPQArr2.eAiVcbriRjoKDGcWOFoHoNNmruyo = eAiVcbriRjoKDGcWOFoHoNNmruyo;
						}
						luaQBHuhhdUKBLkTnxRxDEzPQArr2.LnwKfrOQHKDzlAyYvlwCyzquUdrc = ONNawMbfxBXvCUlIOQLKMFovUXJV;
						luaQBHuhhdUKBLkTnxRxDEzPQArr2.FCTTuTTlzqALmhrOSxxlcMbMlGuu = BGCsnEzHDEsYSOhEwpjZXFFqFDYaA;
						luaQBHuhhdUKBLkTnxRxDEzPQArr2.qPrHpfWzQJXeYXzAJJGmrXZIujIJ = vuiFyEDXGccwkngWdfsooOthAEMeb;
						return luaQBHuhhdUKBLkTnxRxDEzPQArr2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class dNVOXyAtkuGqgJwmyhvnemKhZJvx : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int XrRhoNjMhztCqREumKdGtRJOWJgi;

					private ActionElementMap atuhsMorbVKatlpsFLIyMeWZZvzh;

					private int ExxTyeChUSZWLuWoeUXOvqQJEgpE;

					private int mnJtUUgEhwSrTHasaAfNacNOcpIt;

					public int bmOxhEUqikAIuPflyHgdjRLTZWIc;

					public MapHelper UOiXBTOMGLFxPAGkZCshInDNrpQUA;

					private ControllerType VTZcTFGMAnwJZTyayMsmbUKWKIaKA;

					public ControllerType oCraDHjlsXdrmjVuCEngOEVWYjzu;

					private int GPbaUldKLvuxjewAGjKouBHzveoUA;

					public int JuQqSNLaGiXxTKjpudWlwFWrcmDJ;

					private bool LVgWJmJSTiLMAWpkWkshQKsgCGxCA;

					public bool ejQxXtWbJpPaHazdwrAwaOXRcHcKA;

					private IList<ControllerMap> JCzjsZuQVrxMXHFjmhxlCyCJoXcMA;

					private int PHhfGGjmAkoXETXrLBZFsutMybwl;

					private IEnumerator<ActionElementMap> NOgFsOTngeofgVblsoBcufcHeREp;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return atuhsMorbVKatlpsFLIyMeWZZvzh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return atuhsMorbVKatlpsFLIyMeWZZvzh;
						}
					}

					[DebuggerHidden]
					public dNVOXyAtkuGqgJwmyhvnemKhZJvx(int P_0)
					{
						XrRhoNjMhztCqREumKdGtRJOWJgi = P_0;
						ExxTyeChUSZWLuWoeUXOvqQJEgpE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xrRhoNjMhztCqREumKdGtRJOWJgi = XrRhoNjMhztCqREumKdGtRJOWJgi;
						if (xrRhoNjMhztCqREumKdGtRJOWJgi == -3 || xrRhoNjMhztCqREumKdGtRJOWJgi == 1)
						{
							try
							{
							}
							finally
							{
								EHgnApJaYeCnoaFQTBCjrjXRSdfL();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int xrRhoNjMhztCqREumKdGtRJOWJgi = XrRhoNjMhztCqREumKdGtRJOWJgi;
							MapHelper uOiXBTOMGLFxPAGkZCshInDNrpQUA = UOiXBTOMGLFxPAGkZCshInDNrpQUA;
							if (xrRhoNjMhztCqREumKdGtRJOWJgi != 0)
							{
								if (xrRhoNjMhztCqREumKdGtRJOWJgi != 1)
								{
									return false;
								}
								XrRhoNjMhztCqREumKdGtRJOWJgi = -3;
								goto IL_014f;
							}
							XrRhoNjMhztCqREumKdGtRJOWJgi = -1;
							if (mnJtUUgEhwSrTHasaAfNacNOcpIt < 0)
							{
								return false;
							}
							XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = uOiXBTOMGLFxPAGkZCshInDNrpQUA.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(VTZcTFGMAnwJZTyayMsmbUKWKIaKA);
							int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(GPbaUldKLvuxjewAGjKouBHzveoUA);
							if (num < 0)
							{
								return false;
							}
							JCzjsZuQVrxMXHFjmhxlCyCJoXcMA = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
							PHhfGGjmAkoXETXrLBZFsutMybwl = 0;
							goto IL_017b;
							IL_014f:
							if (NOgFsOTngeofgVblsoBcufcHeREp.MoveNext())
							{
								ActionElementMap current = NOgFsOTngeofgVblsoBcufcHeREp.Current;
								atuhsMorbVKatlpsFLIyMeWZZvzh = current;
								XrRhoNjMhztCqREumKdGtRJOWJgi = 1;
								return true;
							}
							EHgnApJaYeCnoaFQTBCjrjXRSdfL();
							NOgFsOTngeofgVblsoBcufcHeREp = null;
							goto IL_0169;
							IL_017b:
							if (PHhfGGjmAkoXETXrLBZFsutMybwl < JCzjsZuQVrxMXHFjmhxlCyCJoXcMA.Count)
							{
								if (!(JCzjsZuQVrxMXHFjmhxlCyCJoXcMA[PHhfGGjmAkoXETXrLBZFsutMybwl] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!LVgWJmJSTiLMAWpkWkshQKsgCGxCA || JCzjsZuQVrxMXHFjmhxlCyCJoXcMA[PHhfGGjmAkoXETXrLBZFsutMybwl].enabled) && JCzjsZuQVrxMXHFjmhxlCyCJoXcMA[PHhfGGjmAkoXETXrLBZFsutMybwl].ContainsAction(mnJtUUgEhwSrTHasaAfNacNOcpIt))
								{
									NOgFsOTngeofgVblsoBcufcHeREp = (JCzjsZuQVrxMXHFjmhxlCyCJoXcMA[PHhfGGjmAkoXETXrLBZFsutMybwl] as ControllerMapWithAxes).AxisMapsWithAction(mnJtUUgEhwSrTHasaAfNacNOcpIt, LVgWJmJSTiLMAWpkWkshQKsgCGxCA).GetEnumerator();
									XrRhoNjMhztCqREumKdGtRJOWJgi = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							PHhfGGjmAkoXETXrLBZFsutMybwl++;
							goto IL_017b;
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

					private void EHgnApJaYeCnoaFQTBCjrjXRSdfL()
					{
						XrRhoNjMhztCqREumKdGtRJOWJgi = -1;
						if (NOgFsOTngeofgVblsoBcufcHeREp != null)
						{
							NOgFsOTngeofgVblsoBcufcHeREp.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						dNVOXyAtkuGqgJwmyhvnemKhZJvx dNVOXyAtkuGqgJwmyhvnemKhZJvx2;
						if (XrRhoNjMhztCqREumKdGtRJOWJgi == -2 && ExxTyeChUSZWLuWoeUXOvqQJEgpE == Environment.CurrentManagedThreadId)
						{
							XrRhoNjMhztCqREumKdGtRJOWJgi = 0;
							dNVOXyAtkuGqgJwmyhvnemKhZJvx2 = this;
						}
						else
						{
							dNVOXyAtkuGqgJwmyhvnemKhZJvx2 = new dNVOXyAtkuGqgJwmyhvnemKhZJvx(0);
							dNVOXyAtkuGqgJwmyhvnemKhZJvx2.UOiXBTOMGLFxPAGkZCshInDNrpQUA = UOiXBTOMGLFxPAGkZCshInDNrpQUA;
						}
						dNVOXyAtkuGqgJwmyhvnemKhZJvx2.VTZcTFGMAnwJZTyayMsmbUKWKIaKA = oCraDHjlsXdrmjVuCEngOEVWYjzu;
						dNVOXyAtkuGqgJwmyhvnemKhZJvx2.GPbaUldKLvuxjewAGjKouBHzveoUA = JuQqSNLaGiXxTKjpudWlwFWrcmDJ;
						dNVOXyAtkuGqgJwmyhvnemKhZJvx2.mnJtUUgEhwSrTHasaAfNacNOcpIt = bmOxhEUqikAIuPflyHgdjRLTZWIc;
						dNVOXyAtkuGqgJwmyhvnemKhZJvx2.LVgWJmJSTiLMAWpkWkshQKsgCGxCA = ejQxXtWbJpPaHazdwrAwaOXRcHcKA;
						return dNVOXyAtkuGqgJwmyhvnemKhZJvx2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class cCIfWuKeGNtvfUmYBSXQkuvCkhwk : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int AhlwMhBjCsXdZbDzmDcXdHMawjggA;

					private ActionElementMap uVOXEEgOtjEqJdNRODLlYcjnFLWFA;

					private int OqxCGVtfTMdzZhWZRKtMXBkrynLf;

					private int VRooIiwkGtfZQxomhnXKGpHwIPFH;

					public int vGpzXtlVfDlGCWqfrubWwGiSULdC;

					public MapHelper RpdLQZsfCuLREwTtTDnQeQNHPBiE;

					private ControllerType hhQEgHHOtdOtLXWQLZFbqFrCAScjA;

					public ControllerType MgCCkMqDfcVPNjDkzeSPgZVsiPCkA;

					private bool PtKIVAuZokKKHjTrxBuMHrfKxvdc;

					public bool LOKFxfgZKUrnixZpBTaLGVAbQZmsA;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA CeEbkJpAEranqzcFxGFkYPYPfBWU;

					private int VAdnWtLBefdtLKTgvskEVxwcUXrLA;

					private IList<ControllerMap> ZGdQgzGaQsYAeNJpRzGNWlSkJFUp;

					private int QfFymIKDlXGDHJHbneBrbaVaKoNV;

					private IEnumerator<ActionElementMap> cFYGndGgDHFZQpimIaGqUaeucryu;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return uVOXEEgOtjEqJdNRODLlYcjnFLWFA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uVOXEEgOtjEqJdNRODLlYcjnFLWFA;
						}
					}

					[DebuggerHidden]
					public cCIfWuKeGNtvfUmYBSXQkuvCkhwk(int P_0)
					{
						AhlwMhBjCsXdZbDzmDcXdHMawjggA = P_0;
						OqxCGVtfTMdzZhWZRKtMXBkrynLf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ahlwMhBjCsXdZbDzmDcXdHMawjggA = AhlwMhBjCsXdZbDzmDcXdHMawjggA;
						if (ahlwMhBjCsXdZbDzmDcXdHMawjggA == -3 || ahlwMhBjCsXdZbDzmDcXdHMawjggA == 1)
						{
							try
							{
							}
							finally
							{
								sTmshkqKfYMMCQeaoaISxQdaEtqm();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ahlwMhBjCsXdZbDzmDcXdHMawjggA = AhlwMhBjCsXdZbDzmDcXdHMawjggA;
							MapHelper rpdLQZsfCuLREwTtTDnQeQNHPBiE = RpdLQZsfCuLREwTtTDnQeQNHPBiE;
							if (ahlwMhBjCsXdZbDzmDcXdHMawjggA != 0)
							{
								if (ahlwMhBjCsXdZbDzmDcXdHMawjggA != 1)
								{
									return false;
								}
								AhlwMhBjCsXdZbDzmDcXdHMawjggA = -3;
								goto IL_012c;
							}
							AhlwMhBjCsXdZbDzmDcXdHMawjggA = -1;
							if (VRooIiwkGtfZQxomhnXKGpHwIPFH < 0)
							{
								return false;
							}
							CeEbkJpAEranqzcFxGFkYPYPfBWU = rpdLQZsfCuLREwTtTDnQeQNHPBiE.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(hhQEgHHOtdOtLXWQLZFbqFrCAScjA);
							VAdnWtLBefdtLKTgvskEVxwcUXrLA = 0;
							goto IL_0187;
							IL_012c:
							if (cFYGndGgDHFZQpimIaGqUaeucryu.MoveNext())
							{
								ActionElementMap current = cFYGndGgDHFZQpimIaGqUaeucryu.Current;
								uVOXEEgOtjEqJdNRODLlYcjnFLWFA = current;
								AhlwMhBjCsXdZbDzmDcXdHMawjggA = 1;
								return true;
							}
							sTmshkqKfYMMCQeaoaISxQdaEtqm();
							cFYGndGgDHFZQpimIaGqUaeucryu = null;
							goto IL_0146;
							IL_0158:
							if (QfFymIKDlXGDHJHbneBrbaVaKoNV < ZGdQgzGaQsYAeNJpRzGNWlSkJFUp.Count)
							{
								if ((!PtKIVAuZokKKHjTrxBuMHrfKxvdc || ZGdQgzGaQsYAeNJpRzGNWlSkJFUp[QfFymIKDlXGDHJHbneBrbaVaKoNV].enabled) && ZGdQgzGaQsYAeNJpRzGNWlSkJFUp[QfFymIKDlXGDHJHbneBrbaVaKoNV].ContainsAction(VRooIiwkGtfZQxomhnXKGpHwIPFH))
								{
									cFYGndGgDHFZQpimIaGqUaeucryu = ZGdQgzGaQsYAeNJpRzGNWlSkJFUp[QfFymIKDlXGDHJHbneBrbaVaKoNV].ButtonMapsWithAction(VRooIiwkGtfZQxomhnXKGpHwIPFH, PtKIVAuZokKKHjTrxBuMHrfKxvdc).GetEnumerator();
									AhlwMhBjCsXdZbDzmDcXdHMawjggA = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							ZGdQgzGaQsYAeNJpRzGNWlSkJFUp = null;
							VAdnWtLBefdtLKTgvskEVxwcUXrLA++;
							goto IL_0187;
							IL_0146:
							QfFymIKDlXGDHJHbneBrbaVaKoNV++;
							goto IL_0158;
							IL_0187:
							if (VAdnWtLBefdtLKTgvskEVxwcUXrLA < CeEbkJpAEranqzcFxGFkYPYPfBWU.FwIGimYHKsSdutRnXvajJeatuVHB)
							{
								ZGdQgzGaQsYAeNJpRzGNWlSkJFUp = CeEbkJpAEranqzcFxGFkYPYPfBWU.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(VAdnWtLBefdtLKTgvskEVxwcUXrLA).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
								QfFymIKDlXGDHJHbneBrbaVaKoNV = 0;
								goto IL_0158;
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

					private void sTmshkqKfYMMCQeaoaISxQdaEtqm()
					{
						AhlwMhBjCsXdZbDzmDcXdHMawjggA = -1;
						if (cFYGndGgDHFZQpimIaGqUaeucryu != null)
						{
							cFYGndGgDHFZQpimIaGqUaeucryu.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						cCIfWuKeGNtvfUmYBSXQkuvCkhwk cCIfWuKeGNtvfUmYBSXQkuvCkhwk2;
						if (AhlwMhBjCsXdZbDzmDcXdHMawjggA == -2 && OqxCGVtfTMdzZhWZRKtMXBkrynLf == Environment.CurrentManagedThreadId)
						{
							AhlwMhBjCsXdZbDzmDcXdHMawjggA = 0;
							cCIfWuKeGNtvfUmYBSXQkuvCkhwk2 = this;
						}
						else
						{
							cCIfWuKeGNtvfUmYBSXQkuvCkhwk2 = new cCIfWuKeGNtvfUmYBSXQkuvCkhwk(0);
							cCIfWuKeGNtvfUmYBSXQkuvCkhwk2.RpdLQZsfCuLREwTtTDnQeQNHPBiE = RpdLQZsfCuLREwTtTDnQeQNHPBiE;
						}
						cCIfWuKeGNtvfUmYBSXQkuvCkhwk2.hhQEgHHOtdOtLXWQLZFbqFrCAScjA = MgCCkMqDfcVPNjDkzeSPgZVsiPCkA;
						cCIfWuKeGNtvfUmYBSXQkuvCkhwk2.VRooIiwkGtfZQxomhnXKGpHwIPFH = vGpzXtlVfDlGCWqfrubWwGiSULdC;
						cCIfWuKeGNtvfUmYBSXQkuvCkhwk2.PtKIVAuZokKKHjTrxBuMHrfKxvdc = LOKFxfgZKUrnixZpBTaLGVAbQZmsA;
						return cCIfWuKeGNtvfUmYBSXQkuvCkhwk2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class NIHCEeVZcXlEbUWECvqhgzqytuWO : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int PCRxOmPKLUiaynoQgBbiJbFFHXSAA;

					private ActionElementMap OMChzjmTMOsbBhtikmLySyqtHKrq;

					private int fjfeJEhrPOMvghEYaAFpFxrVdjqY;

					private int yrlDMCdbqXiodSdkbjkEbuDtIyylA;

					public int nfeieQKSmYiqozJpZWkPiKNgNVMxA;

					public MapHelper AdezkWLZVVIxxozeiByKBUZTLlkb;

					private ControllerType OPrJvUYnhkgnhdjnwnAuOlmPgBuH;

					public ControllerType PFjHJNwLdmZDAZRcSFIdlORdzGUJ;

					private int ecufOabLmSGhhqDciVhxSSrkkNIFb;

					public int IMxrHxaqTMFeQBYKOkgiNlkNmrMlA;

					private bool SFvERGZrtiEMRedZxuibEwRvEzlOA;

					public bool XKsejfxVBHHrghrCobLJIPKdAXfnA;

					private IList<ControllerMap> EMvmJtwFAEGslfgMUofwIIYsZWOLA;

					private int FiyeTNmUeKIXEcXmRoQJMPNdpAvS;

					private IEnumerator<ActionElementMap> CfnJyYLTQcpEEFgautGAEsJPPyzD;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return OMChzjmTMOsbBhtikmLySyqtHKrq;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OMChzjmTMOsbBhtikmLySyqtHKrq;
						}
					}

					[DebuggerHidden]
					public NIHCEeVZcXlEbUWECvqhgzqytuWO(int P_0)
					{
						PCRxOmPKLUiaynoQgBbiJbFFHXSAA = P_0;
						fjfeJEhrPOMvghEYaAFpFxrVdjqY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pCRxOmPKLUiaynoQgBbiJbFFHXSAA = PCRxOmPKLUiaynoQgBbiJbFFHXSAA;
						if (pCRxOmPKLUiaynoQgBbiJbFFHXSAA == -3 || pCRxOmPKLUiaynoQgBbiJbFFHXSAA == 1)
						{
							try
							{
							}
							finally
							{
								hnceuxxlnVAtSibiFUjCUDpSHEMAb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int pCRxOmPKLUiaynoQgBbiJbFFHXSAA = PCRxOmPKLUiaynoQgBbiJbFFHXSAA;
							MapHelper adezkWLZVVIxxozeiByKBUZTLlkb = AdezkWLZVVIxxozeiByKBUZTLlkb;
							if (pCRxOmPKLUiaynoQgBbiJbFFHXSAA != 0)
							{
								if (pCRxOmPKLUiaynoQgBbiJbFFHXSAA != 1)
								{
									return false;
								}
								PCRxOmPKLUiaynoQgBbiJbFFHXSAA = -3;
								goto IL_012b;
							}
							PCRxOmPKLUiaynoQgBbiJbFFHXSAA = -1;
							if (yrlDMCdbqXiodSdkbjkEbuDtIyylA < 0)
							{
								return false;
							}
							XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = adezkWLZVVIxxozeiByKBUZTLlkb.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(OPrJvUYnhkgnhdjnwnAuOlmPgBuH);
							int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(ecufOabLmSGhhqDciVhxSSrkkNIFb);
							if (num < 0)
							{
								return false;
							}
							EMvmJtwFAEGslfgMUofwIIYsZWOLA = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
							FiyeTNmUeKIXEcXmRoQJMPNdpAvS = 0;
							goto IL_0157;
							IL_012b:
							if (CfnJyYLTQcpEEFgautGAEsJPPyzD.MoveNext())
							{
								ActionElementMap current = CfnJyYLTQcpEEFgautGAEsJPPyzD.Current;
								OMChzjmTMOsbBhtikmLySyqtHKrq = current;
								PCRxOmPKLUiaynoQgBbiJbFFHXSAA = 1;
								return true;
							}
							hnceuxxlnVAtSibiFUjCUDpSHEMAb();
							CfnJyYLTQcpEEFgautGAEsJPPyzD = null;
							goto IL_0145;
							IL_0157:
							if (FiyeTNmUeKIXEcXmRoQJMPNdpAvS < EMvmJtwFAEGslfgMUofwIIYsZWOLA.Count)
							{
								if ((!SFvERGZrtiEMRedZxuibEwRvEzlOA || EMvmJtwFAEGslfgMUofwIIYsZWOLA[FiyeTNmUeKIXEcXmRoQJMPNdpAvS].enabled) && EMvmJtwFAEGslfgMUofwIIYsZWOLA[FiyeTNmUeKIXEcXmRoQJMPNdpAvS].ContainsAction(yrlDMCdbqXiodSdkbjkEbuDtIyylA))
								{
									CfnJyYLTQcpEEFgautGAEsJPPyzD = EMvmJtwFAEGslfgMUofwIIYsZWOLA[FiyeTNmUeKIXEcXmRoQJMPNdpAvS].ButtonMapsWithAction(yrlDMCdbqXiodSdkbjkEbuDtIyylA, SFvERGZrtiEMRedZxuibEwRvEzlOA).GetEnumerator();
									PCRxOmPKLUiaynoQgBbiJbFFHXSAA = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							FiyeTNmUeKIXEcXmRoQJMPNdpAvS++;
							goto IL_0157;
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

					private void hnceuxxlnVAtSibiFUjCUDpSHEMAb()
					{
						PCRxOmPKLUiaynoQgBbiJbFFHXSAA = -1;
						if (CfnJyYLTQcpEEFgautGAEsJPPyzD != null)
						{
							CfnJyYLTQcpEEFgautGAEsJPPyzD.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						NIHCEeVZcXlEbUWECvqhgzqytuWO nIHCEeVZcXlEbUWECvqhgzqytuWO;
						if (PCRxOmPKLUiaynoQgBbiJbFFHXSAA == -2 && fjfeJEhrPOMvghEYaAFpFxrVdjqY == Environment.CurrentManagedThreadId)
						{
							PCRxOmPKLUiaynoQgBbiJbFFHXSAA = 0;
							nIHCEeVZcXlEbUWECvqhgzqytuWO = this;
						}
						else
						{
							nIHCEeVZcXlEbUWECvqhgzqytuWO = new NIHCEeVZcXlEbUWECvqhgzqytuWO(0);
							nIHCEeVZcXlEbUWECvqhgzqytuWO.AdezkWLZVVIxxozeiByKBUZTLlkb = AdezkWLZVVIxxozeiByKBUZTLlkb;
						}
						nIHCEeVZcXlEbUWECvqhgzqytuWO.OPrJvUYnhkgnhdjnwnAuOlmPgBuH = PFjHJNwLdmZDAZRcSFIdlORdzGUJ;
						nIHCEeVZcXlEbUWECvqhgzqytuWO.ecufOabLmSGhhqDciVhxSSrkkNIFb = IMxrHxaqTMFeQBYKOkgiNlkNmrMlA;
						nIHCEeVZcXlEbUWECvqhgzqytuWO.yrlDMCdbqXiodSdkbjkEbuDtIyylA = nfeieQKSmYiqozJpZWkPiKNgNVMxA;
						nIHCEeVZcXlEbUWECvqhgzqytuWO.SFvERGZrtiEMRedZxuibEwRvEzlOA = XKsejfxVBHHrghrCobLJIPKdAXfnA;
						return nIHCEeVZcXlEbUWECvqhgzqytuWO;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class LQCXBhoizUfFWFkPOkOJWTYYlkBm : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int YwcgQLajutECMzXVqQKRbjYgIsEPA;

					private ActionElementMap sUjtDXQxztCKvFUkYcCcnpPZcWDiA;

					private int mnqvknAlxEKveRiBfciFbzJZEpabA;

					private int pvQllcXKzCmbYVGbumlMuHLSphWM;

					public int KyqFthkIKUEgrDoUqReXJfoVvesr;

					public MapHelper FcnahzKzkDoylBWdYNmAgQGuRDfD;

					private ControllerType pIWWuEMxRJLrBlfVbEDHUDtGeixW;

					public ControllerType nRQNYrriSOiAqvXxXGJlOwVtrFlo;

					private bool dprSAjNeTdfjkDzjYhBUoWNncNEeA;

					public bool QFdBSLFLwVKqLXfJjdYMFTmeKleDc;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA cNXhNwvFSxaifObOqdFKefVULHYbA;

					private int wMCElVWTyxzgBjBNusieCTTAknuh;

					private IList<ControllerMap> wAsEjriwTyQRTFGBHpjSWLcDWpWaA;

					private int RIBgGdrnhjFxrkGtCfijZRDjrhpx;

					private IEnumerator<ActionElementMap> MfqNgNKKEziYEnPvGVvxNsnLObQx;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return sUjtDXQxztCKvFUkYcCcnpPZcWDiA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sUjtDXQxztCKvFUkYcCcnpPZcWDiA;
						}
					}

					[DebuggerHidden]
					public LQCXBhoizUfFWFkPOkOJWTYYlkBm(int P_0)
					{
						YwcgQLajutECMzXVqQKRbjYgIsEPA = P_0;
						mnqvknAlxEKveRiBfciFbzJZEpabA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ywcgQLajutECMzXVqQKRbjYgIsEPA = YwcgQLajutECMzXVqQKRbjYgIsEPA;
						if (ywcgQLajutECMzXVqQKRbjYgIsEPA == -3 || ywcgQLajutECMzXVqQKRbjYgIsEPA == 1)
						{
							try
							{
							}
							finally
							{
								HDbWzVGbtNdXzbDvHYIQDCBKaiqN();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ywcgQLajutECMzXVqQKRbjYgIsEPA = YwcgQLajutECMzXVqQKRbjYgIsEPA;
							MapHelper fcnahzKzkDoylBWdYNmAgQGuRDfD = FcnahzKzkDoylBWdYNmAgQGuRDfD;
							if (ywcgQLajutECMzXVqQKRbjYgIsEPA != 0)
							{
								if (ywcgQLajutECMzXVqQKRbjYgIsEPA != 1)
								{
									return false;
								}
								YwcgQLajutECMzXVqQKRbjYgIsEPA = -3;
								goto IL_012c;
							}
							YwcgQLajutECMzXVqQKRbjYgIsEPA = -1;
							if (pvQllcXKzCmbYVGbumlMuHLSphWM < 0)
							{
								return false;
							}
							cNXhNwvFSxaifObOqdFKefVULHYbA = fcnahzKzkDoylBWdYNmAgQGuRDfD.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(pIWWuEMxRJLrBlfVbEDHUDtGeixW);
							wMCElVWTyxzgBjBNusieCTTAknuh = 0;
							goto IL_0187;
							IL_012c:
							if (MfqNgNKKEziYEnPvGVvxNsnLObQx.MoveNext())
							{
								ActionElementMap current = MfqNgNKKEziYEnPvGVvxNsnLObQx.Current;
								sUjtDXQxztCKvFUkYcCcnpPZcWDiA = current;
								YwcgQLajutECMzXVqQKRbjYgIsEPA = 1;
								return true;
							}
							HDbWzVGbtNdXzbDvHYIQDCBKaiqN();
							MfqNgNKKEziYEnPvGVvxNsnLObQx = null;
							goto IL_0146;
							IL_0158:
							if (RIBgGdrnhjFxrkGtCfijZRDjrhpx < wAsEjriwTyQRTFGBHpjSWLcDWpWaA.Count)
							{
								if ((!dprSAjNeTdfjkDzjYhBUoWNncNEeA || wAsEjriwTyQRTFGBHpjSWLcDWpWaA[RIBgGdrnhjFxrkGtCfijZRDjrhpx].enabled) && wAsEjriwTyQRTFGBHpjSWLcDWpWaA[RIBgGdrnhjFxrkGtCfijZRDjrhpx].ContainsAction(pvQllcXKzCmbYVGbumlMuHLSphWM))
								{
									MfqNgNKKEziYEnPvGVvxNsnLObQx = wAsEjriwTyQRTFGBHpjSWLcDWpWaA[RIBgGdrnhjFxrkGtCfijZRDjrhpx].ElementMapsWithAction(pvQllcXKzCmbYVGbumlMuHLSphWM, dprSAjNeTdfjkDzjYhBUoWNncNEeA).GetEnumerator();
									YwcgQLajutECMzXVqQKRbjYgIsEPA = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							wAsEjriwTyQRTFGBHpjSWLcDWpWaA = null;
							wMCElVWTyxzgBjBNusieCTTAknuh++;
							goto IL_0187;
							IL_0146:
							RIBgGdrnhjFxrkGtCfijZRDjrhpx++;
							goto IL_0158;
							IL_0187:
							if (wMCElVWTyxzgBjBNusieCTTAknuh < cNXhNwvFSxaifObOqdFKefVULHYbA.FwIGimYHKsSdutRnXvajJeatuVHB)
							{
								wAsEjriwTyQRTFGBHpjSWLcDWpWaA = cNXhNwvFSxaifObOqdFKefVULHYbA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(wMCElVWTyxzgBjBNusieCTTAknuh).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
								RIBgGdrnhjFxrkGtCfijZRDjrhpx = 0;
								goto IL_0158;
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

					private void HDbWzVGbtNdXzbDvHYIQDCBKaiqN()
					{
						YwcgQLajutECMzXVqQKRbjYgIsEPA = -1;
						if (MfqNgNKKEziYEnPvGVvxNsnLObQx != null)
						{
							MfqNgNKKEziYEnPvGVvxNsnLObQx.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						LQCXBhoizUfFWFkPOkOJWTYYlkBm lQCXBhoizUfFWFkPOkOJWTYYlkBm;
						if (YwcgQLajutECMzXVqQKRbjYgIsEPA == -2 && mnqvknAlxEKveRiBfciFbzJZEpabA == Environment.CurrentManagedThreadId)
						{
							YwcgQLajutECMzXVqQKRbjYgIsEPA = 0;
							lQCXBhoizUfFWFkPOkOJWTYYlkBm = this;
						}
						else
						{
							lQCXBhoizUfFWFkPOkOJWTYYlkBm = new LQCXBhoizUfFWFkPOkOJWTYYlkBm(0);
							lQCXBhoizUfFWFkPOkOJWTYYlkBm.FcnahzKzkDoylBWdYNmAgQGuRDfD = FcnahzKzkDoylBWdYNmAgQGuRDfD;
						}
						lQCXBhoizUfFWFkPOkOJWTYYlkBm.pIWWuEMxRJLrBlfVbEDHUDtGeixW = nRQNYrriSOiAqvXxXGJlOwVtrFlo;
						lQCXBhoizUfFWFkPOkOJWTYYlkBm.pvQllcXKzCmbYVGbumlMuHLSphWM = KyqFthkIKUEgrDoUqReXJfoVvesr;
						lQCXBhoizUfFWFkPOkOJWTYYlkBm.dprSAjNeTdfjkDzjYhBUoWNncNEeA = QFdBSLFLwVKqLXfJjdYMFTmeKleDc;
						return lQCXBhoizUfFWFkPOkOJWTYYlkBm;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class mOFgnhrUuHxPlKWZAeGdlQhANefW : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int vtywuaTPSmSiRARutvKzcGSCYlSE;

					private ActionElementMap ZBxBaqIRdsZXpUhvQOWFqjeovZze;

					private int vGWtIHASGxkywYJhJcUSkWMwfEKC;

					private int johpMNvuZFnOZPRvRCnbAXrGxNTW;

					public int lzYdIrcnpMAxYemfbfGFDWIAdCoYb;

					public MapHelper TjecKvdEXJBWAUoXMPvZEmdJKHfH;

					private ControllerType JMLCzGCXvNvJSnIyCFOKjYwhcaDaB;

					public ControllerType pMxykNlfgTWMSUpycoHGTusvFZPS;

					private int RhZcTfhsrEcUXWnEGkzKeITBGjhUB;

					public int SGeISEFvEhMJzGIZKDFSHZMFKcavA;

					private bool dnzNyDugLwymWwZdOgyawkYbrmCr;

					public bool WrWuGUaJLNqntmGyKgKNIETeAePuA;

					private IList<ControllerMap> JZNFFQtADDoiGtIYigAfbBWNSpyv;

					private int AcceRPFufMHXStXpzpibIzTvLNKeA;

					private IEnumerator<ActionElementMap> xvZgKrXlvrcGpAkhsGCneTutPpBZ;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZBxBaqIRdsZXpUhvQOWFqjeovZze;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZBxBaqIRdsZXpUhvQOWFqjeovZze;
						}
					}

					[DebuggerHidden]
					public mOFgnhrUuHxPlKWZAeGdlQhANefW(int P_0)
					{
						vtywuaTPSmSiRARutvKzcGSCYlSE = P_0;
						vGWtIHASGxkywYJhJcUSkWMwfEKC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = vtywuaTPSmSiRARutvKzcGSCYlSE;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MgcyfZdhacnmXHHeDFpEDkAkGRDm();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = vtywuaTPSmSiRARutvKzcGSCYlSE;
							MapHelper tjecKvdEXJBWAUoXMPvZEmdJKHfH = TjecKvdEXJBWAUoXMPvZEmdJKHfH;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								vtywuaTPSmSiRARutvKzcGSCYlSE = -3;
								goto IL_012b;
							}
							vtywuaTPSmSiRARutvKzcGSCYlSE = -1;
							if (johpMNvuZFnOZPRvRCnbAXrGxNTW < 0)
							{
								return false;
							}
							XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = tjecKvdEXJBWAUoXMPvZEmdJKHfH.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(JMLCzGCXvNvJSnIyCFOKjYwhcaDaB);
							int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(RhZcTfhsrEcUXWnEGkzKeITBGjhUB);
							if (num2 < 0)
							{
								return false;
							}
							JZNFFQtADDoiGtIYigAfbBWNSpyv = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num2).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
							AcceRPFufMHXStXpzpibIzTvLNKeA = 0;
							goto IL_0157;
							IL_012b:
							if (xvZgKrXlvrcGpAkhsGCneTutPpBZ.MoveNext())
							{
								ActionElementMap current = xvZgKrXlvrcGpAkhsGCneTutPpBZ.Current;
								ZBxBaqIRdsZXpUhvQOWFqjeovZze = current;
								vtywuaTPSmSiRARutvKzcGSCYlSE = 1;
								return true;
							}
							MgcyfZdhacnmXHHeDFpEDkAkGRDm();
							xvZgKrXlvrcGpAkhsGCneTutPpBZ = null;
							goto IL_0145;
							IL_0157:
							if (AcceRPFufMHXStXpzpibIzTvLNKeA < JZNFFQtADDoiGtIYigAfbBWNSpyv.Count)
							{
								if ((!dnzNyDugLwymWwZdOgyawkYbrmCr || JZNFFQtADDoiGtIYigAfbBWNSpyv[AcceRPFufMHXStXpzpibIzTvLNKeA].enabled) && JZNFFQtADDoiGtIYigAfbBWNSpyv[AcceRPFufMHXStXpzpibIzTvLNKeA].ContainsAction(johpMNvuZFnOZPRvRCnbAXrGxNTW))
								{
									xvZgKrXlvrcGpAkhsGCneTutPpBZ = JZNFFQtADDoiGtIYigAfbBWNSpyv[AcceRPFufMHXStXpzpibIzTvLNKeA].ElementMapsWithAction(johpMNvuZFnOZPRvRCnbAXrGxNTW, dnzNyDugLwymWwZdOgyawkYbrmCr).GetEnumerator();
									vtywuaTPSmSiRARutvKzcGSCYlSE = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							AcceRPFufMHXStXpzpibIzTvLNKeA++;
							goto IL_0157;
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

					private void MgcyfZdhacnmXHHeDFpEDkAkGRDm()
					{
						vtywuaTPSmSiRARutvKzcGSCYlSE = -1;
						if (xvZgKrXlvrcGpAkhsGCneTutPpBZ != null)
						{
							xvZgKrXlvrcGpAkhsGCneTutPpBZ.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						mOFgnhrUuHxPlKWZAeGdlQhANefW mOFgnhrUuHxPlKWZAeGdlQhANefW2;
						if (vtywuaTPSmSiRARutvKzcGSCYlSE == -2 && vGWtIHASGxkywYJhJcUSkWMwfEKC == Environment.CurrentManagedThreadId)
						{
							vtywuaTPSmSiRARutvKzcGSCYlSE = 0;
							mOFgnhrUuHxPlKWZAeGdlQhANefW2 = this;
						}
						else
						{
							mOFgnhrUuHxPlKWZAeGdlQhANefW2 = new mOFgnhrUuHxPlKWZAeGdlQhANefW(0);
							mOFgnhrUuHxPlKWZAeGdlQhANefW2.TjecKvdEXJBWAUoXMPvZEmdJKHfH = TjecKvdEXJBWAUoXMPvZEmdJKHfH;
						}
						mOFgnhrUuHxPlKWZAeGdlQhANefW2.JMLCzGCXvNvJSnIyCFOKjYwhcaDaB = pMxykNlfgTWMSUpycoHGTusvFZPS;
						mOFgnhrUuHxPlKWZAeGdlQhANefW2.RhZcTfhsrEcUXWnEGkzKeITBGjhUB = SGeISEFvEhMJzGIZKDFSHZMFKcavA;
						mOFgnhrUuHxPlKWZAeGdlQhANefW2.johpMNvuZFnOZPRvRCnbAXrGxNTW = lzYdIrcnpMAxYemfbfGFDWIAdCoYb;
						mOFgnhrUuHxPlKWZAeGdlQhANefW2.dnzNyDugLwymWwZdOgyawkYbrmCr = WrWuGUaJLNqntmGyKgKNIETeAePuA;
						return mOFgnhrUuHxPlKWZAeGdlQhANefW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class pRrDhEWypfnmWoSLFxqhcFkCTxBO : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int SCDxtmmBQpCGQLQVZrvvqrRcTRtR;

					private ControllerMap xCaIlLAkgjKcmBmNhqHutsjzpgsH;

					private int hVLaBXgMRHtRFaSdpSDKEXMkvZKm;

					public MapHelper oGbbJkoTliDXfuZLXuAXiGIOWCjk;

					private ControllerType GrXgmNjVEhSgQhWeooXQeDazpqmbb;

					public ControllerType CwaJTdfvrdVKNChHJxWMsQracdMF;

					private int HygbcmosAZjgCZRKWJCIqrKBPNYG;

					public int WlMGcdPsYAoCZdIoixmJSnndCmjkA;

					private int zroACpgOnAeNmCsphJfGRNnYugozb;

					public int YjIorXQSXDJxbhnaDRlpCLbvDrcn;

					private IList<ControllerMap> TqYlkfbOLAeNLbNqLzGOkErPVFGKA;

					private int IXiSOSGqHfXAZDcaScZXCvPthOTnA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return xCaIlLAkgjKcmBmNhqHutsjzpgsH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xCaIlLAkgjKcmBmNhqHutsjzpgsH;
						}
					}

					[DebuggerHidden]
					public pRrDhEWypfnmWoSLFxqhcFkCTxBO(int P_0)
					{
						SCDxtmmBQpCGQLQVZrvvqrRcTRtR = P_0;
						hVLaBXgMRHtRFaSdpSDKEXMkvZKm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int sCDxtmmBQpCGQLQVZrvvqrRcTRtR = SCDxtmmBQpCGQLQVZrvvqrRcTRtR;
						MapHelper mapHelper = oGbbJkoTliDXfuZLXuAXiGIOWCjk;
						if (sCDxtmmBQpCGQLQVZrvvqrRcTRtR != 0)
						{
							if (sCDxtmmBQpCGQLQVZrvvqrRcTRtR != 1)
							{
								return false;
							}
							SCDxtmmBQpCGQLQVZrvvqrRcTRtR = -1;
							goto IL_00b0;
						}
						SCDxtmmBQpCGQLQVZrvvqrRcTRtR = -1;
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(GrXgmNjVEhSgQhWeooXQeDazpqmbb);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(HygbcmosAZjgCZRKWJCIqrKBPNYG);
						if (num < 0)
						{
							return false;
						}
						TqYlkfbOLAeNLbNqLzGOkErPVFGKA = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						IXiSOSGqHfXAZDcaScZXCvPthOTnA = 0;
						goto IL_00c2;
						IL_00c2:
						if (IXiSOSGqHfXAZDcaScZXCvPthOTnA < TqYlkfbOLAeNLbNqLzGOkErPVFGKA.Count)
						{
							if (TqYlkfbOLAeNLbNqLzGOkErPVFGKA[IXiSOSGqHfXAZDcaScZXCvPthOTnA].categoryId == zroACpgOnAeNmCsphJfGRNnYugozb)
							{
								xCaIlLAkgjKcmBmNhqHutsjzpgsH = TqYlkfbOLAeNLbNqLzGOkErPVFGKA[IXiSOSGqHfXAZDcaScZXCvPthOTnA];
								SCDxtmmBQpCGQLQVZrvvqrRcTRtR = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						IXiSOSGqHfXAZDcaScZXCvPthOTnA++;
						goto IL_00c2;
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						pRrDhEWypfnmWoSLFxqhcFkCTxBO pRrDhEWypfnmWoSLFxqhcFkCTxBO2;
						if (SCDxtmmBQpCGQLQVZrvvqrRcTRtR == -2 && hVLaBXgMRHtRFaSdpSDKEXMkvZKm == Environment.CurrentManagedThreadId)
						{
							SCDxtmmBQpCGQLQVZrvvqrRcTRtR = 0;
							pRrDhEWypfnmWoSLFxqhcFkCTxBO2 = this;
						}
						else
						{
							pRrDhEWypfnmWoSLFxqhcFkCTxBO2 = new pRrDhEWypfnmWoSLFxqhcFkCTxBO(0);
							pRrDhEWypfnmWoSLFxqhcFkCTxBO2.oGbbJkoTliDXfuZLXuAXiGIOWCjk = oGbbJkoTliDXfuZLXuAXiGIOWCjk;
						}
						pRrDhEWypfnmWoSLFxqhcFkCTxBO2.GrXgmNjVEhSgQhWeooXQeDazpqmbb = CwaJTdfvrdVKNChHJxWMsQracdMF;
						pRrDhEWypfnmWoSLFxqhcFkCTxBO2.HygbcmosAZjgCZRKWJCIqrKBPNYG = WlMGcdPsYAoCZdIoixmJSnndCmjkA;
						pRrDhEWypfnmWoSLFxqhcFkCTxBO2.zroACpgOnAeNmCsphJfGRNnYugozb = YjIorXQSXDJxbhnaDRlpCLbvDrcn;
						return pRrDhEWypfnmWoSLFxqhcFkCTxBO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class KGRHAFVLbgEsWeHectVqZGBacQtGA<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int sbXeauVctArbBrfdoqTBHuDgKZmU;

					private _0001 KusBluDGIoyiXOsLdjgCWuobERoJA;

					private int RhVtEUwrFbeRcvMVTjKHFypfxPwf;

					public MapHelper ZezbgqBPVoONhsBBqmMWQdIfqadz;

					private int vrksJpKboCvERIcAHepHaEoBEryBA;

					public int qhkUdZYQDCmeTWpnUqexnpavHDNW;

					private int vuGaOxHWbfsafnRsWTLwNylcTaMfA;

					public int tlQcCmmAEyodeaHrfsytnDlZjMFb;

					private IList<_0001> dKaBQIDkVzcMsGhphpHkBvgLUNnPA;

					private int PCPhLMkKaUSazwOyrkiiUWfBnUho;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return KusBluDGIoyiXOsLdjgCWuobERoJA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KusBluDGIoyiXOsLdjgCWuobERoJA;
						}
					}

					[DebuggerHidden]
					public KGRHAFVLbgEsWeHectVqZGBacQtGA(int P_0)
					{
						sbXeauVctArbBrfdoqTBHuDgKZmU = P_0;
						RhVtEUwrFbeRcvMVTjKHFypfxPwf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = sbXeauVctArbBrfdoqTBHuDgKZmU;
						MapHelper zezbgqBPVoONhsBBqmMWQdIfqadz = ZezbgqBPVoONhsBBqmMWQdIfqadz;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							sbXeauVctArbBrfdoqTBHuDgKZmU = -1;
							goto IL_00b9;
						}
						sbXeauVctArbBrfdoqTBHuDgKZmU = -1;
						ControllerType controllerType = SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<_0001>();
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = zezbgqBPVoONhsBBqmMWQdIfqadz.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
						int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(vrksJpKboCvERIcAHepHaEoBEryBA);
						if (num2 < 0)
						{
							return false;
						}
						dKaBQIDkVzcMsGhphpHkBvgLUNnPA = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num2).iuMldFPvAqBfeiUXQrGwudCQSSbq.xHmZixgDkANrStEshDECgdGlDTscb<_0001>();
						PCPhLMkKaUSazwOyrkiiUWfBnUho = 0;
						goto IL_00cb;
						IL_00cb:
						if (PCPhLMkKaUSazwOyrkiiUWfBnUho < dKaBQIDkVzcMsGhphpHkBvgLUNnPA.Count)
						{
							if (dKaBQIDkVzcMsGhphpHkBvgLUNnPA[PCPhLMkKaUSazwOyrkiiUWfBnUho].categoryId == vuGaOxHWbfsafnRsWTLwNylcTaMfA)
							{
								KusBluDGIoyiXOsLdjgCWuobERoJA = dKaBQIDkVzcMsGhphpHkBvgLUNnPA[PCPhLMkKaUSazwOyrkiiUWfBnUho];
								sbXeauVctArbBrfdoqTBHuDgKZmU = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						PCPhLMkKaUSazwOyrkiiUWfBnUho++;
						goto IL_00cb;
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
					IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
					{
						KGRHAFVLbgEsWeHectVqZGBacQtGA<_0001> kGRHAFVLbgEsWeHectVqZGBacQtGA;
						if (sbXeauVctArbBrfdoqTBHuDgKZmU == -2 && RhVtEUwrFbeRcvMVTjKHFypfxPwf == Environment.CurrentManagedThreadId)
						{
							sbXeauVctArbBrfdoqTBHuDgKZmU = 0;
							kGRHAFVLbgEsWeHectVqZGBacQtGA = this;
						}
						else
						{
							kGRHAFVLbgEsWeHectVqZGBacQtGA = new KGRHAFVLbgEsWeHectVqZGBacQtGA<_0001>(0);
							kGRHAFVLbgEsWeHectVqZGBacQtGA.ZezbgqBPVoONhsBBqmMWQdIfqadz = ZezbgqBPVoONhsBBqmMWQdIfqadz;
						}
						kGRHAFVLbgEsWeHectVqZGBacQtGA.vrksJpKboCvERIcAHepHaEoBEryBA = qhkUdZYQDCmeTWpnUqexnpavHDNW;
						kGRHAFVLbgEsWeHectVqZGBacQtGA.vuGaOxHWbfsafnRsWTLwNylcTaMfA = tlQcCmmAEyodeaHrfsytnDlZjMFb;
						return kGRHAFVLbgEsWeHectVqZGBacQtGA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class QmrPpZTsGiNGhpkeacYYETyyziCJA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int GYCrlVoaEZXKwVTfuqBgJNHwFWMe;

					private ActionElementMap mZZboPhwnynVOABTBlgiEBOiOcKLA;

					private int iWOLLqYDGcaASlRRMaKiddXdqACLA;

					public MapHelper EAsYQImdxSpMifYhZAZKAkWcOkdE;

					private int ArtMEIuEOEemkHgchGboLLRxnxru;

					public int puklTxXEKuLFHuVdeGnIgmXdLdsp;

					private bool dQUrNCOnWKqkwkzrhqlLnJWSDaBKA;

					public bool whCkkMNOJybkqzDpshBSGwXhRXTr;

					private int ttjTjTTZAHSGOPJPXtkuQkwHjkkP;

					private int zAYfYIxXDRVmGJGolVpsLqpxGVOM;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA QHUKHRVPcMwfTBSJLXxicXrgBFjk;

					private int FSkzimrytnGRpFgevxawfyAkiIsn;

					private int lYZsTWpGeRVmkUHbouyooMfeMnfw;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX YfQcSTkmleWTqtOIQbIqryQvebOWA;

					private int ZvdVzjHkCoEXFagjdyFfMfxhhgqp;

					private int oVucIeRBtThUxHhVieNWFqvXOgOyA;

					private IEnumerator<ActionElementMap> eUfpQsdsZvRGQloGFGhjKTpIgWiMA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return mZZboPhwnynVOABTBlgiEBOiOcKLA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return mZZboPhwnynVOABTBlgiEBOiOcKLA;
						}
					}

					[DebuggerHidden]
					public QmrPpZTsGiNGhpkeacYYETyyziCJA(int P_0)
					{
						GYCrlVoaEZXKwVTfuqBgJNHwFWMe = P_0;
						iWOLLqYDGcaASlRRMaKiddXdqACLA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gYCrlVoaEZXKwVTfuqBgJNHwFWMe = GYCrlVoaEZXKwVTfuqBgJNHwFWMe;
						if (gYCrlVoaEZXKwVTfuqBgJNHwFWMe == -3 || gYCrlVoaEZXKwVTfuqBgJNHwFWMe == 1)
						{
							try
							{
							}
							finally
							{
								KlwZpsFWThTicnlZuaSJVcrxkdwS();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gYCrlVoaEZXKwVTfuqBgJNHwFWMe = GYCrlVoaEZXKwVTfuqBgJNHwFWMe;
							MapHelper eAsYQImdxSpMifYhZAZKAkWcOkdE = EAsYQImdxSpMifYhZAZKAkWcOkdE;
							if (gYCrlVoaEZXKwVTfuqBgJNHwFWMe != 0)
							{
								if (gYCrlVoaEZXKwVTfuqBgJNHwFWMe != 1)
								{
									return false;
								}
								GYCrlVoaEZXKwVTfuqBgJNHwFWMe = -3;
								goto IL_016c;
							}
							GYCrlVoaEZXKwVTfuqBgJNHwFWMe = -1;
							if (ReInput._id != eAsYQImdxSpMifYhZAZKAkWcOkdE.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
							{
								ReInput.CheckInitialized(eAsYQImdxSpMifYhZAZKAkWcOkdE.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
								return false;
							}
							if (ArtMEIuEOEemkHgchGboLLRxnxru < 0)
							{
								return false;
							}
							ttjTjTTZAHSGOPJPXtkuQkwHjkkP = eAsYQImdxSpMifYhZAZKAkWcOkdE.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
							zAYfYIxXDRVmGJGolVpsLqpxGVOM = 0;
							goto IL_01ec;
							IL_016c:
							if (eUfpQsdsZvRGQloGFGhjKTpIgWiMA.MoveNext())
							{
								ActionElementMap current = eUfpQsdsZvRGQloGFGhjKTpIgWiMA.Current;
								mZZboPhwnynVOABTBlgiEBOiOcKLA = current;
								GYCrlVoaEZXKwVTfuqBgJNHwFWMe = 1;
								return true;
							}
							KlwZpsFWThTicnlZuaSJVcrxkdwS();
							eUfpQsdsZvRGQloGFGhjKTpIgWiMA = null;
							goto IL_0186;
							IL_0186:
							oVucIeRBtThUxHhVieNWFqvXOgOyA++;
							goto IL_0198;
							IL_01c2:
							if (lYZsTWpGeRVmkUHbouyooMfeMnfw < FSkzimrytnGRpFgevxawfyAkiIsn)
							{
								YfQcSTkmleWTqtOIQbIqryQvebOWA = QHUKHRVPcMwfTBSJLXxicXrgBFjk.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(lYZsTWpGeRVmkUHbouyooMfeMnfw).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								ZvdVzjHkCoEXFagjdyFfMfxhhgqp = YfQcSTkmleWTqtOIQbIqryQvebOWA.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								oVucIeRBtThUxHhVieNWFqvXOgOyA = 0;
								goto IL_0198;
							}
							QHUKHRVPcMwfTBSJLXxicXrgBFjk = null;
							zAYfYIxXDRVmGJGolVpsLqpxGVOM++;
							goto IL_01ec;
							IL_0198:
							if (oVucIeRBtThUxHhVieNWFqvXOgOyA < ZvdVzjHkCoEXFagjdyFfMfxhhgqp)
							{
								ControllerMap controllerMap = YfQcSTkmleWTqtOIQbIqryQvebOWA.IMbAidiclopVawbUkoIYAkGvwawAA(oVucIeRBtThUxHhVieNWFqvXOgOyA);
								if ((!dQUrNCOnWKqkwkzrhqlLnJWSDaBKA || controllerMap.enabled) && controllerMap.ContainsAction(ArtMEIuEOEemkHgchGboLLRxnxru))
								{
									eUfpQsdsZvRGQloGFGhjKTpIgWiMA = controllerMap.ElementMapsWithAction(ArtMEIuEOEemkHgchGboLLRxnxru, dQUrNCOnWKqkwkzrhqlLnJWSDaBKA).GetEnumerator();
									GYCrlVoaEZXKwVTfuqBgJNHwFWMe = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							YfQcSTkmleWTqtOIQbIqryQvebOWA = null;
							lYZsTWpGeRVmkUHbouyooMfeMnfw++;
							goto IL_01c2;
							IL_01ec:
							if (zAYfYIxXDRVmGJGolVpsLqpxGVOM < ttjTjTTZAHSGOPJPXtkuQkwHjkkP)
							{
								QHUKHRVPcMwfTBSJLXxicXrgBFjk = eAsYQImdxSpMifYhZAZKAkWcOkdE.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(zAYfYIxXDRVmGJGolVpsLqpxGVOM);
								FSkzimrytnGRpFgevxawfyAkiIsn = QHUKHRVPcMwfTBSJLXxicXrgBFjk.FwIGimYHKsSdutRnXvajJeatuVHB;
								lYZsTWpGeRVmkUHbouyooMfeMnfw = 0;
								goto IL_01c2;
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

					private void KlwZpsFWThTicnlZuaSJVcrxkdwS()
					{
						GYCrlVoaEZXKwVTfuqBgJNHwFWMe = -1;
						if (eUfpQsdsZvRGQloGFGhjKTpIgWiMA != null)
						{
							eUfpQsdsZvRGQloGFGhjKTpIgWiMA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						QmrPpZTsGiNGhpkeacYYETyyziCJA qmrPpZTsGiNGhpkeacYYETyyziCJA;
						if (GYCrlVoaEZXKwVTfuqBgJNHwFWMe == -2 && iWOLLqYDGcaASlRRMaKiddXdqACLA == Environment.CurrentManagedThreadId)
						{
							GYCrlVoaEZXKwVTfuqBgJNHwFWMe = 0;
							qmrPpZTsGiNGhpkeacYYETyyziCJA = this;
						}
						else
						{
							qmrPpZTsGiNGhpkeacYYETyyziCJA = new QmrPpZTsGiNGhpkeacYYETyyziCJA(0);
							qmrPpZTsGiNGhpkeacYYETyyziCJA.EAsYQImdxSpMifYhZAZKAkWcOkdE = EAsYQImdxSpMifYhZAZKAkWcOkdE;
						}
						qmrPpZTsGiNGhpkeacYYETyyziCJA.ArtMEIuEOEemkHgchGboLLRxnxru = puklTxXEKuLFHuVdeGnIgmXdLdsp;
						qmrPpZTsGiNGhpkeacYYETyyziCJA.dQUrNCOnWKqkwkzrhqlLnJWSDaBKA = whCkkMNOJybkqzDpshBSGwXhRXTr;
						return qmrPpZTsGiNGhpkeacYYETyyziCJA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class vGsBxclAnWAQhrnqoOqOkqEIIebFA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int gBqFkeDwiPGybvYWhnJFYHElAIlW;

					private ActionElementMap HLbPDIWmIMhodNUuLgVfdRquCTCH;

					private int BvzbpkWEDFhbdLHilKmUMaPSpfQC;

					private IControllerElementTarget STSIYolzRvQjBawaROUXfpDUGHgX;

					public IControllerElementTarget ppvCOchzcooSjsWxVWgCzdNXehiG;

					public MapHelper whcFQCHDFEFsPpRGEnbNYNZRvPIpA;

					private bool UGGLFdThnHEEedfWCpImoLoBIhyEA;

					public bool HSulRicDQCpgpQUeZrZkKWpphaoG;

					private bool QplBHgJBzWIYATYroWxyabOUpfSC;

					public bool vQhgpfisytCExjtUApSuzDCxOKjbb;

					private int nfzblRmhlBBInPecpOuBuVOvTKJN;

					public int ZMeuvZUmXmLtudkhKddoHkgNWMJH;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA jjgGIVMWAddTnZYRMwaQhNduebLY;

					private int AEtZrqrEdCMivQDeCENhAoPBnLHwA;

					private int ttkxMTjdqwiJfNJFfSIQxUQimZHu;

					private IList<ControllerMap> npkyMEUrpxTZpIgybJxmrXRXbAeg;

					private int oZwWRxRoCOLtccgyprriVdhHcAkdA;

					private int KzJuqnPuNlZpRyrqLWqPhUmTwcHf;

					private TempListPool.TList<ActionElementMap> udsFvHyRJceSynsVjpfzmwgTzniK;

					private List<ActionElementMap>.Enumerator CkwbOPkDlsYVmdUimvsEQPLQLpSJ;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return HLbPDIWmIMhodNUuLgVfdRquCTCH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HLbPDIWmIMhodNUuLgVfdRquCTCH;
						}
					}

					[DebuggerHidden]
					public vGsBxclAnWAQhrnqoOqOkqEIIebFA(int P_0)
					{
						gBqFkeDwiPGybvYWhnJFYHElAIlW = P_0;
						BvzbpkWEDFhbdLHilKmUMaPSpfQC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = gBqFkeDwiPGybvYWhnJFYHElAIlW;
						if ((uint)(num - -4) > 1u && num != 1)
						{
							return;
						}
						try
						{
							if (num != -4 && num != 1)
							{
								return;
							}
							try
							{
							}
							finally
							{
								WTvlfknGSPbeCDTTANcfHwiTtfluA();
							}
						}
						finally
						{
							RPuRprgCIwcVYnvpduFYZMJwplCX();
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = gBqFkeDwiPGybvYWhnJFYHElAIlW;
							MapHelper mapHelper = whcFQCHDFEFsPpRGEnbNYNZRvPIpA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								gBqFkeDwiPGybvYWhnJFYHElAIlW = -4;
								goto IL_017c;
							}
							gBqFkeDwiPGybvYWhnJFYHElAIlW = -1;
							if (STSIYolzRvQjBawaROUXfpDUGHgX == null)
							{
								return false;
							}
							Controller controller = STSIYolzRvQjBawaROUXfpDUGHgX.controller;
							if (controller == null)
							{
								return false;
							}
							jjgGIVMWAddTnZYRMwaQhNduebLY = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controller.type);
							AEtZrqrEdCMivQDeCENhAoPBnLHwA = jjgGIVMWAddTnZYRMwaQhNduebLY.FwIGimYHKsSdutRnXvajJeatuVHB;
							ttkxMTjdqwiJfNJFfSIQxUQimZHu = 0;
							goto IL_01e4;
							IL_017c:
							if (CkwbOPkDlsYVmdUimvsEQPLQLpSJ.MoveNext())
							{
								ActionElementMap current = CkwbOPkDlsYVmdUimvsEQPLQLpSJ.Current;
								HLbPDIWmIMhodNUuLgVfdRquCTCH = current;
								gBqFkeDwiPGybvYWhnJFYHElAIlW = 1;
								return true;
							}
							WTvlfknGSPbeCDTTANcfHwiTtfluA();
							CkwbOPkDlsYVmdUimvsEQPLQLpSJ = default(List<ActionElementMap>.Enumerator);
							RPuRprgCIwcVYnvpduFYZMJwplCX();
							udsFvHyRJceSynsVjpfzmwgTzniK = null;
							goto IL_01a8;
							IL_01e4:
							if (ttkxMTjdqwiJfNJFfSIQxUQimZHu < AEtZrqrEdCMivQDeCENhAoPBnLHwA)
							{
								BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = jjgGIVMWAddTnZYRMwaQhNduebLY.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(ttkxMTjdqwiJfNJFfSIQxUQimZHu).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								_ = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								npkyMEUrpxTZpIgybJxmrXRXbAeg = bpzomrqmbmNinOxWAGGlQTtkPnsX.wdPauRHjrIQblVZUuLzuKLqlKgKE;
								oZwWRxRoCOLtccgyprriVdhHcAkdA = npkyMEUrpxTZpIgybJxmrXRXbAeg.Count;
								KzJuqnPuNlZpRyrqLWqPhUmTwcHf = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (KzJuqnPuNlZpRyrqLWqPhUmTwcHf < oZwWRxRoCOLtccgyprriVdhHcAkdA)
							{
								ControllerMap controllerMap = npkyMEUrpxTZpIgybJxmrXRXbAeg[KzJuqnPuNlZpRyrqLWqPhUmTwcHf];
								if (!UGGLFdThnHEEedfWCpImoLoBIhyEA || controllerMap.enabled)
								{
									udsFvHyRJceSynsVjpfzmwgTzniK = TempListPool.GetTList<ActionElementMap>();
									gBqFkeDwiPGybvYWhnJFYHElAIlW = -3;
									List<ActionElementMap> list = udsFvHyRJceSynsVjpfzmwgTzniK.list;
									controllerMap.UlFArbKTYQdEqAtLPNCFxsiTzHnb(STSIYolzRvQjBawaROUXfpDUGHgX, QplBHgJBzWIYATYroWxyabOUpfSC, nfzblRmhlBBInPecpOuBuVOvTKJN, UGGLFdThnHEEedfWCpImoLoBIhyEA, list, true, out var _);
									CkwbOPkDlsYVmdUimvsEQPLQLpSJ = list.GetEnumerator();
									gBqFkeDwiPGybvYWhnJFYHElAIlW = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							npkyMEUrpxTZpIgybJxmrXRXbAeg = null;
							ttkxMTjdqwiJfNJFfSIQxUQimZHu++;
							goto IL_01e4;
							IL_01a8:
							KzJuqnPuNlZpRyrqLWqPhUmTwcHf++;
							goto IL_01ba;
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

					private void RPuRprgCIwcVYnvpduFYZMJwplCX()
					{
						gBqFkeDwiPGybvYWhnJFYHElAIlW = -1;
						if (udsFvHyRJceSynsVjpfzmwgTzniK != null)
						{
							((IDisposable)udsFvHyRJceSynsVjpfzmwgTzniK).Dispose();
						}
					}

					private void WTvlfknGSPbeCDTTANcfHwiTtfluA()
					{
						gBqFkeDwiPGybvYWhnJFYHElAIlW = -3;
						((IDisposable)CkwbOPkDlsYVmdUimvsEQPLQLpSJ/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						vGsBxclAnWAQhrnqoOqOkqEIIebFA vGsBxclAnWAQhrnqoOqOkqEIIebFA2;
						if (gBqFkeDwiPGybvYWhnJFYHElAIlW == -2 && BvzbpkWEDFhbdLHilKmUMaPSpfQC == Environment.CurrentManagedThreadId)
						{
							gBqFkeDwiPGybvYWhnJFYHElAIlW = 0;
							vGsBxclAnWAQhrnqoOqOkqEIIebFA2 = this;
						}
						else
						{
							vGsBxclAnWAQhrnqoOqOkqEIIebFA2 = new vGsBxclAnWAQhrnqoOqOkqEIIebFA(0);
							vGsBxclAnWAQhrnqoOqOkqEIIebFA2.whcFQCHDFEFsPpRGEnbNYNZRvPIpA = whcFQCHDFEFsPpRGEnbNYNZRvPIpA;
						}
						vGsBxclAnWAQhrnqoOqOkqEIIebFA2.STSIYolzRvQjBawaROUXfpDUGHgX = ppvCOchzcooSjsWxVWgCzdNXehiG;
						vGsBxclAnWAQhrnqoOqOkqEIIebFA2.QplBHgJBzWIYATYroWxyabOUpfSC = vQhgpfisytCExjtUApSuzDCxOKjbb;
						vGsBxclAnWAQhrnqoOqOkqEIIebFA2.nfzblRmhlBBInPecpOuBuVOvTKJN = ZMeuvZUmXmLtudkhKddoHkgNWMJH;
						vGsBxclAnWAQhrnqoOqOkqEIIebFA2.UGGLFdThnHEEedfWCpImoLoBIhyEA = HSulRicDQCpgpQUeZrZkKWpphaoG;
						return vGsBxclAnWAQhrnqoOqOkqEIIebFA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class gJVAMoOOogCjZAsUwIDErXQzQCTz : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int NIssNeiLoKepaTlcTJKdJjMuEhaJA;

					private ControllerMap DhQCQDJmvduxzimGOcNxgkfxXZlB;

					private int KwZpdNXQMBahgLiQTDrapmLeNgbq;

					public MapHelper wPMGTeeluNORTBXnGukIlBeIooDae;

					private int ruhdWqxctNEFykxPBeHpgqZkREMiA;

					private int AAMODjgSxoakSuIzJcHjnOUIPijP;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA EwixpNVKkdrHIguiRKeGvYCrfCUN;

					private int EIcmBIQRCEAscWKDMXTFEnEvCEKCA;

					private int KJTGuvnffOcQiukstFONNRvlzVQm;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX GSTAooaWIyrmoemnqryxBHwvQZrH;

					private int woWeHxeHQfTIvMUkWHwkorKvhIRQA;

					private int QioVMrJHaABDOBLPsDVUySZtmTkg;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return DhQCQDJmvduxzimGOcNxgkfxXZlB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DhQCQDJmvduxzimGOcNxgkfxXZlB;
						}
					}

					[DebuggerHidden]
					public gJVAMoOOogCjZAsUwIDErXQzQCTz(int P_0)
					{
						NIssNeiLoKepaTlcTJKdJjMuEhaJA = P_0;
						KwZpdNXQMBahgLiQTDrapmLeNgbq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int nIssNeiLoKepaTlcTJKdJjMuEhaJA = NIssNeiLoKepaTlcTJKdJjMuEhaJA;
						MapHelper mapHelper = wPMGTeeluNORTBXnGukIlBeIooDae;
						if (nIssNeiLoKepaTlcTJKdJjMuEhaJA != 0)
						{
							if (nIssNeiLoKepaTlcTJKdJjMuEhaJA != 1)
							{
								return false;
							}
							NIssNeiLoKepaTlcTJKdJjMuEhaJA = -1;
							QioVMrJHaABDOBLPsDVUySZtmTkg++;
							goto IL_0104;
						}
						NIssNeiLoKepaTlcTJKdJjMuEhaJA = -1;
						if (ReInput._id != mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
						{
							ReInput.CheckInitialized(mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
							return false;
						}
						ruhdWqxctNEFykxPBeHpgqZkREMiA = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
						AAMODjgSxoakSuIzJcHjnOUIPijP = 0;
						goto IL_0151;
						IL_0104:
						if (QioVMrJHaABDOBLPsDVUySZtmTkg < woWeHxeHQfTIvMUkWHwkorKvhIRQA)
						{
							DhQCQDJmvduxzimGOcNxgkfxXZlB = GSTAooaWIyrmoemnqryxBHwvQZrH.IMbAidiclopVawbUkoIYAkGvwawAA(QioVMrJHaABDOBLPsDVUySZtmTkg);
							NIssNeiLoKepaTlcTJKdJjMuEhaJA = 1;
							return true;
						}
						GSTAooaWIyrmoemnqryxBHwvQZrH = null;
						KJTGuvnffOcQiukstFONNRvlzVQm++;
						goto IL_0129;
						IL_0129:
						if (KJTGuvnffOcQiukstFONNRvlzVQm < EIcmBIQRCEAscWKDMXTFEnEvCEKCA)
						{
							GSTAooaWIyrmoemnqryxBHwvQZrH = EwixpNVKkdrHIguiRKeGvYCrfCUN.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(KJTGuvnffOcQiukstFONNRvlzVQm).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							woWeHxeHQfTIvMUkWHwkorKvhIRQA = GSTAooaWIyrmoemnqryxBHwvQZrH.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							QioVMrJHaABDOBLPsDVUySZtmTkg = 0;
							goto IL_0104;
						}
						EwixpNVKkdrHIguiRKeGvYCrfCUN = null;
						AAMODjgSxoakSuIzJcHjnOUIPijP++;
						goto IL_0151;
						IL_0151:
						if (AAMODjgSxoakSuIzJcHjnOUIPijP < ruhdWqxctNEFykxPBeHpgqZkREMiA)
						{
							EwixpNVKkdrHIguiRKeGvYCrfCUN = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(AAMODjgSxoakSuIzJcHjnOUIPijP);
							EIcmBIQRCEAscWKDMXTFEnEvCEKCA = EwixpNVKkdrHIguiRKeGvYCrfCUN.FwIGimYHKsSdutRnXvajJeatuVHB;
							KJTGuvnffOcQiukstFONNRvlzVQm = 0;
							goto IL_0129;
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						gJVAMoOOogCjZAsUwIDErXQzQCTz gJVAMoOOogCjZAsUwIDErXQzQCTz2;
						if (NIssNeiLoKepaTlcTJKdJjMuEhaJA == -2 && KwZpdNXQMBahgLiQTDrapmLeNgbq == Environment.CurrentManagedThreadId)
						{
							NIssNeiLoKepaTlcTJKdJjMuEhaJA = 0;
							gJVAMoOOogCjZAsUwIDErXQzQCTz2 = this;
						}
						else
						{
							gJVAMoOOogCjZAsUwIDErXQzQCTz2 = new gJVAMoOOogCjZAsUwIDErXQzQCTz(0);
							gJVAMoOOogCjZAsUwIDErXQzQCTz2.wPMGTeeluNORTBXnGukIlBeIooDae = wPMGTeeluNORTBXnGukIlBeIooDae;
						}
						return gJVAMoOOogCjZAsUwIDErXQzQCTz2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class psQIVLSmoncsiFDohMfvGcqfnpEBc<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int EhwCZdCONALRdCGHwytMbPYXGNmh;

					private _0001 GncrEVZrIXmpOOJiAmETWVfpkXhi;

					private int PExVnjakjhCoMzFRIumerrOUpdN;

					public MapHelper YSKMEyNcramPOOwFfvGLQDVYcdvT;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA fWcAbNEwisaHURkzoHPHFoIPHWLqA;

					private int apWewwGgVTeAXWwUAXtZoqDkusmu;

					private int nnEOnYXPaQLDNbcGctFoaPtmnilg;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX OaIxKvtmrHPsDqlIOxQUDPsrEBCi;

					private int LyuBRtOpPiagWrMtZGVHvBZxOLsc;

					private int AIvQHaYlIBGRoXrhEKjieiSAdmGh;

					private int IjnVgxmBJxjCmGQegMbvFQMKlEGB;

					private int IWlhbRXhZGdDAhSxfbHhQvZFVGHoA;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return GncrEVZrIXmpOOJiAmETWVfpkXhi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GncrEVZrIXmpOOJiAmETWVfpkXhi;
						}
					}

					[DebuggerHidden]
					public psQIVLSmoncsiFDohMfvGcqfnpEBc(int P_0)
					{
						EhwCZdCONALRdCGHwytMbPYXGNmh = P_0;
						PExVnjakjhCoMzFRIumerrOUpdN = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int ehwCZdCONALRdCGHwytMbPYXGNmh = EhwCZdCONALRdCGHwytMbPYXGNmh;
						MapHelper ySKMEyNcramPOOwFfvGLQDVYcdvT = YSKMEyNcramPOOwFfvGLQDVYcdvT;
						switch (ehwCZdCONALRdCGHwytMbPYXGNmh)
						{
						default:
							return false;
						case 0:
						{
							EhwCZdCONALRdCGHwytMbPYXGNmh = -1;
							if (ReInput._id != ySKMEyNcramPOOwFfvGLQDVYcdvT.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
							{
								ReInput.CheckInitialized(ySKMEyNcramPOOwFfvGLQDVYcdvT.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
								return false;
							}
							if (SVQbmGoCgjXlQooYDoNZCFflMVzP.uKTtsjLiKSZYEkajJsfrTScFdaTk<_0001>(out var controllerType))
							{
								fWcAbNEwisaHURkzoHPHFoIPHWLqA = ySKMEyNcramPOOwFfvGLQDVYcdvT.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
								apWewwGgVTeAXWwUAXtZoqDkusmu = fWcAbNEwisaHURkzoHPHFoIPHWLqA.FwIGimYHKsSdutRnXvajJeatuVHB;
								nnEOnYXPaQLDNbcGctFoaPtmnilg = 0;
								goto IL_011b;
							}
							apWewwGgVTeAXWwUAXtZoqDkusmu = ySKMEyNcramPOOwFfvGLQDVYcdvT.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
							nnEOnYXPaQLDNbcGctFoaPtmnilg = 0;
							goto IL_0264;
						}
						case 1:
							EhwCZdCONALRdCGHwytMbPYXGNmh = -1;
							AIvQHaYlIBGRoXrhEKjieiSAdmGh++;
							goto IL_00f6;
						case 2:
							{
								EhwCZdCONALRdCGHwytMbPYXGNmh = -1;
								goto IL_0207;
							}
							IL_0207:
							IWlhbRXhZGdDAhSxfbHhQvZFVGHoA++;
							goto IL_0217;
							IL_0264:
							if (nnEOnYXPaQLDNbcGctFoaPtmnilg >= apWewwGgVTeAXWwUAXtZoqDkusmu)
							{
								break;
							}
							fWcAbNEwisaHURkzoHPHFoIPHWLqA = ySKMEyNcramPOOwFfvGLQDVYcdvT.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(nnEOnYXPaQLDNbcGctFoaPtmnilg);
							LyuBRtOpPiagWrMtZGVHvBZxOLsc = fWcAbNEwisaHURkzoHPHFoIPHWLqA.FwIGimYHKsSdutRnXvajJeatuVHB;
							AIvQHaYlIBGRoXrhEKjieiSAdmGh = 0;
							goto IL_023c;
							IL_011b:
							if (nnEOnYXPaQLDNbcGctFoaPtmnilg < apWewwGgVTeAXWwUAXtZoqDkusmu)
							{
								OaIxKvtmrHPsDqlIOxQUDPsrEBCi = fWcAbNEwisaHURkzoHPHFoIPHWLqA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(nnEOnYXPaQLDNbcGctFoaPtmnilg).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								LyuBRtOpPiagWrMtZGVHvBZxOLsc = OaIxKvtmrHPsDqlIOxQUDPsrEBCi.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								AIvQHaYlIBGRoXrhEKjieiSAdmGh = 0;
								goto IL_00f6;
							}
							fWcAbNEwisaHURkzoHPHFoIPHWLqA = null;
							break;
							IL_0217:
							if (IWlhbRXhZGdDAhSxfbHhQvZFVGHoA < IjnVgxmBJxjCmGQegMbvFQMKlEGB)
							{
								if (OaIxKvtmrHPsDqlIOxQUDPsrEBCi.IMbAidiclopVawbUkoIYAkGvwawAA(IWlhbRXhZGdDAhSxfbHhQvZFVGHoA) is _0001 gncrEVZrIXmpOOJiAmETWVfpkXhi)
								{
									GncrEVZrIXmpOOJiAmETWVfpkXhi = gncrEVZrIXmpOOJiAmETWVfpkXhi;
									EhwCZdCONALRdCGHwytMbPYXGNmh = 2;
									return true;
								}
								goto IL_0207;
							}
							OaIxKvtmrHPsDqlIOxQUDPsrEBCi = null;
							AIvQHaYlIBGRoXrhEKjieiSAdmGh++;
							goto IL_023c;
							IL_023c:
							if (AIvQHaYlIBGRoXrhEKjieiSAdmGh < LyuBRtOpPiagWrMtZGVHvBZxOLsc)
							{
								OaIxKvtmrHPsDqlIOxQUDPsrEBCi = fWcAbNEwisaHURkzoHPHFoIPHWLqA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(AIvQHaYlIBGRoXrhEKjieiSAdmGh).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								IjnVgxmBJxjCmGQegMbvFQMKlEGB = OaIxKvtmrHPsDqlIOxQUDPsrEBCi.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								IWlhbRXhZGdDAhSxfbHhQvZFVGHoA = 0;
								goto IL_0217;
							}
							fWcAbNEwisaHURkzoHPHFoIPHWLqA = null;
							nnEOnYXPaQLDNbcGctFoaPtmnilg++;
							goto IL_0264;
							IL_00f6:
							if (AIvQHaYlIBGRoXrhEKjieiSAdmGh < LyuBRtOpPiagWrMtZGVHvBZxOLsc)
							{
								GncrEVZrIXmpOOJiAmETWVfpkXhi = (_0001)OaIxKvtmrHPsDqlIOxQUDPsrEBCi.IMbAidiclopVawbUkoIYAkGvwawAA(AIvQHaYlIBGRoXrhEKjieiSAdmGh);
								EhwCZdCONALRdCGHwytMbPYXGNmh = 1;
								return true;
							}
							OaIxKvtmrHPsDqlIOxQUDPsrEBCi = null;
							nnEOnYXPaQLDNbcGctFoaPtmnilg++;
							goto IL_011b;
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
					IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
					{
						psQIVLSmoncsiFDohMfvGcqfnpEBc<_0001> psQIVLSmoncsiFDohMfvGcqfnpEBc2;
						if (EhwCZdCONALRdCGHwytMbPYXGNmh == -2 && PExVnjakjhCoMzFRIumerrOUpdN == Environment.CurrentManagedThreadId)
						{
							EhwCZdCONALRdCGHwytMbPYXGNmh = 0;
							psQIVLSmoncsiFDohMfvGcqfnpEBc2 = this;
						}
						else
						{
							psQIVLSmoncsiFDohMfvGcqfnpEBc2 = new psQIVLSmoncsiFDohMfvGcqfnpEBc<_0001>(0);
							psQIVLSmoncsiFDohMfvGcqfnpEBc2.YSKMEyNcramPOOwFfvGLQDVYcdvT = YSKMEyNcramPOOwFfvGLQDVYcdvT;
						}
						return psQIVLSmoncsiFDohMfvGcqfnpEBc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class TKWXYTgsjrLmLmefajrOJtYiYhsA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int nPwpKPGnSqJQmQWmkoEDsRMgaNmM;

					private ControllerMap sxDPVragIJdITdMlztYJUGklWgwiA;

					private int eVBycWxJMeHgsolEGkaDayIyMFgS;

					public MapHelper FMAymobjEeNphciMbiFiHXRceTWWA;

					private ControllerType ZqIzrpjdWfidvOevtZYoomGSrTfq;

					public ControllerType ALCaBoRzSOUlsAMTCucfJDDsgkku;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA SLaORLVDhXfVDjBfWRfGgASztFJm;

					private int XjhFoCtXfPpvnqiFDFZreIvgGpGF;

					private int AIOPdoUJMpeZEqvubLwgsnfukhTM;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX vIfUqSutGEmwNCQQKTAaVEDniJzBA;

					private int poUiMtWDSqWylOBWFrbceisUigcq;

					private int YfKFSuifVkzikMIdUsaBGEagsqmVb;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return sxDPVragIJdITdMlztYJUGklWgwiA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sxDPVragIJdITdMlztYJUGklWgwiA;
						}
					}

					[DebuggerHidden]
					public TKWXYTgsjrLmLmefajrOJtYiYhsA(int P_0)
					{
						nPwpKPGnSqJQmQWmkoEDsRMgaNmM = P_0;
						eVBycWxJMeHgsolEGkaDayIyMFgS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = nPwpKPGnSqJQmQWmkoEDsRMgaNmM;
						MapHelper fMAymobjEeNphciMbiFiHXRceTWWA = FMAymobjEeNphciMbiFiHXRceTWWA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							nPwpKPGnSqJQmQWmkoEDsRMgaNmM = -1;
							YfKFSuifVkzikMIdUsaBGEagsqmVb++;
							goto IL_00e2;
						}
						nPwpKPGnSqJQmQWmkoEDsRMgaNmM = -1;
						if (ReInput._id != fMAymobjEeNphciMbiFiHXRceTWWA.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
						{
							ReInput.CheckInitialized(fMAymobjEeNphciMbiFiHXRceTWWA.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
							return false;
						}
						SLaORLVDhXfVDjBfWRfGgASztFJm = fMAymobjEeNphciMbiFiHXRceTWWA.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ZqIzrpjdWfidvOevtZYoomGSrTfq);
						XjhFoCtXfPpvnqiFDFZreIvgGpGF = SLaORLVDhXfVDjBfWRfGgASztFJm.FwIGimYHKsSdutRnXvajJeatuVHB;
						AIOPdoUJMpeZEqvubLwgsnfukhTM = 0;
						goto IL_0107;
						IL_00e2:
						if (YfKFSuifVkzikMIdUsaBGEagsqmVb < poUiMtWDSqWylOBWFrbceisUigcq)
						{
							sxDPVragIJdITdMlztYJUGklWgwiA = vIfUqSutGEmwNCQQKTAaVEDniJzBA.IMbAidiclopVawbUkoIYAkGvwawAA(YfKFSuifVkzikMIdUsaBGEagsqmVb);
							nPwpKPGnSqJQmQWmkoEDsRMgaNmM = 1;
							return true;
						}
						vIfUqSutGEmwNCQQKTAaVEDniJzBA = null;
						AIOPdoUJMpeZEqvubLwgsnfukhTM++;
						goto IL_0107;
						IL_0107:
						if (AIOPdoUJMpeZEqvubLwgsnfukhTM < XjhFoCtXfPpvnqiFDFZreIvgGpGF)
						{
							vIfUqSutGEmwNCQQKTAaVEDniJzBA = SLaORLVDhXfVDjBfWRfGgASztFJm.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(AIOPdoUJMpeZEqvubLwgsnfukhTM).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							poUiMtWDSqWylOBWFrbceisUigcq = vIfUqSutGEmwNCQQKTAaVEDniJzBA.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							YfKFSuifVkzikMIdUsaBGEagsqmVb = 0;
							goto IL_00e2;
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						TKWXYTgsjrLmLmefajrOJtYiYhsA tKWXYTgsjrLmLmefajrOJtYiYhsA;
						if (nPwpKPGnSqJQmQWmkoEDsRMgaNmM == -2 && eVBycWxJMeHgsolEGkaDayIyMFgS == Environment.CurrentManagedThreadId)
						{
							nPwpKPGnSqJQmQWmkoEDsRMgaNmM = 0;
							tKWXYTgsjrLmLmefajrOJtYiYhsA = this;
						}
						else
						{
							tKWXYTgsjrLmLmefajrOJtYiYhsA = new TKWXYTgsjrLmLmefajrOJtYiYhsA(0);
							tKWXYTgsjrLmLmefajrOJtYiYhsA.FMAymobjEeNphciMbiFiHXRceTWWA = FMAymobjEeNphciMbiFiHXRceTWWA;
						}
						tKWXYTgsjrLmLmefajrOJtYiYhsA.ZqIzrpjdWfidvOevtZYoomGSrTfq = ALCaBoRzSOUlsAMTCucfJDDsgkku;
						return tKWXYTgsjrLmLmefajrOJtYiYhsA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class AOlyOkNJPoODBuFnwyNlFndLmyDr : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int ubocvRBhZoRHhQWcAmQsxgTpkpEj;

					private ControllerMap zzFzHsxGFfMeHCfhfNDvjyDFtvXS;

					private int gsDAlCMXMBSISnkjpvJCDiiUZUMk;

					public MapHelper jChDrriUKCJfrMoipLQVuRZfHETx;

					private int FAXgXRfnuxNQzgyVfbnXNJIloXaqb;

					public int bPLmNORzrGcWFiLNffxRhYPAWqgy;

					private int wEiiKQjvXSgWkxtZwftJJGadjZtzA;

					private int SErcpGcaTlVFZgfBJsQDuuajJcspA;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA TfLYcgqkqFVZezcJzqqzORcuoJHC;

					private int iYfGylQeMCVzfGDMVLrevZfykOj;

					private int NkuHuTbsWZUsEAzNQSZRnqocWXuH;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX znffbdAbtwWnHJlVkBWwovqZEbuv;

					private int luExOiGkfgLLjAhssHLaZksRZHXD;

					private int WVkVKhUKFfDSXQQByCqPNFpjExXeA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return zzFzHsxGFfMeHCfhfNDvjyDFtvXS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zzFzHsxGFfMeHCfhfNDvjyDFtvXS;
						}
					}

					[DebuggerHidden]
					public AOlyOkNJPoODBuFnwyNlFndLmyDr(int P_0)
					{
						ubocvRBhZoRHhQWcAmQsxgTpkpEj = P_0;
						gsDAlCMXMBSISnkjpvJCDiiUZUMk = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = ubocvRBhZoRHhQWcAmQsxgTpkpEj;
						MapHelper mapHelper = jChDrriUKCJfrMoipLQVuRZfHETx;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							ubocvRBhZoRHhQWcAmQsxgTpkpEj = -1;
							goto IL_0104;
						}
						ubocvRBhZoRHhQWcAmQsxgTpkpEj = -1;
						if (ReInput._id != mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
						{
							ReInput.CheckInitialized(mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
							return false;
						}
						wEiiKQjvXSgWkxtZwftJJGadjZtzA = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
						SErcpGcaTlVFZgfBJsQDuuajJcspA = 0;
						goto IL_0161;
						IL_0104:
						WVkVKhUKFfDSXQQByCqPNFpjExXeA++;
						goto IL_0114;
						IL_0161:
						if (SErcpGcaTlVFZgfBJsQDuuajJcspA < wEiiKQjvXSgWkxtZwftJJGadjZtzA)
						{
							TfLYcgqkqFVZezcJzqqzORcuoJHC = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(SErcpGcaTlVFZgfBJsQDuuajJcspA);
							iYfGylQeMCVzfGDMVLrevZfykOj = TfLYcgqkqFVZezcJzqqzORcuoJHC.FwIGimYHKsSdutRnXvajJeatuVHB;
							NkuHuTbsWZUsEAzNQSZRnqocWXuH = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (WVkVKhUKFfDSXQQByCqPNFpjExXeA < luExOiGkfgLLjAhssHLaZksRZHXD)
						{
							ControllerMap controllerMap = znffbdAbtwWnHJlVkBWwovqZEbuv.IMbAidiclopVawbUkoIYAkGvwawAA(WVkVKhUKFfDSXQQByCqPNFpjExXeA);
							if (controllerMap.categoryId == FAXgXRfnuxNQzgyVfbnXNJIloXaqb)
							{
								zzFzHsxGFfMeHCfhfNDvjyDFtvXS = controllerMap;
								ubocvRBhZoRHhQWcAmQsxgTpkpEj = 1;
								return true;
							}
							goto IL_0104;
						}
						znffbdAbtwWnHJlVkBWwovqZEbuv = null;
						NkuHuTbsWZUsEAzNQSZRnqocWXuH++;
						goto IL_0139;
						IL_0139:
						if (NkuHuTbsWZUsEAzNQSZRnqocWXuH < iYfGylQeMCVzfGDMVLrevZfykOj)
						{
							znffbdAbtwWnHJlVkBWwovqZEbuv = TfLYcgqkqFVZezcJzqqzORcuoJHC.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(NkuHuTbsWZUsEAzNQSZRnqocWXuH).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							luExOiGkfgLLjAhssHLaZksRZHXD = znffbdAbtwWnHJlVkBWwovqZEbuv.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							WVkVKhUKFfDSXQQByCqPNFpjExXeA = 0;
							goto IL_0114;
						}
						TfLYcgqkqFVZezcJzqqzORcuoJHC = null;
						SErcpGcaTlVFZgfBJsQDuuajJcspA++;
						goto IL_0161;
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						AOlyOkNJPoODBuFnwyNlFndLmyDr aOlyOkNJPoODBuFnwyNlFndLmyDr;
						if (ubocvRBhZoRHhQWcAmQsxgTpkpEj == -2 && gsDAlCMXMBSISnkjpvJCDiiUZUMk == Environment.CurrentManagedThreadId)
						{
							ubocvRBhZoRHhQWcAmQsxgTpkpEj = 0;
							aOlyOkNJPoODBuFnwyNlFndLmyDr = this;
						}
						else
						{
							aOlyOkNJPoODBuFnwyNlFndLmyDr = new AOlyOkNJPoODBuFnwyNlFndLmyDr(0);
							aOlyOkNJPoODBuFnwyNlFndLmyDr.jChDrriUKCJfrMoipLQVuRZfHETx = jChDrriUKCJfrMoipLQVuRZfHETx;
						}
						aOlyOkNJPoODBuFnwyNlFndLmyDr.FAXgXRfnuxNQzgyVfbnXNJIloXaqb = bPLmNORzrGcWFiLNffxRhYPAWqgy;
						return aOlyOkNJPoODBuFnwyNlFndLmyDr;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class SeUPQjZZAIzOPNmElvLjSjKeHCKS<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int qceEcRdAOzpfZhpbPeVeBucrxDGwA;

					private _0001 AkaxKwyooxRCNZSlGXUabqGhfcfK;

					private int vCLcOHoHHkSOCtmsHFrneCVkEBqq;

					public MapHelper dMjZcuAbdfbnGwSZABuoVkOUlsgq;

					private int kbZHroYtMoxmWczLLWBiRixtAjIgA;

					public int OQQFOUeUtsIAFfNwTfjzFXrDutNPb;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA WlsjrQFNtNljxlPzfrNrHlTeEuPFA;

					private int QKVKxdEtsARdYBHwAtiVnkjzhpCe;

					private int OufJThqUsOdFrcEeHaTptnflrlkG;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX qtCjvjzgrifoAAasHaEpkMwCIzpSA;

					private int fTfOYnVxSwWWqmCXoWOgmVZIHJSA;

					private int AZckHugUBRRdxYzkcCRaMKOzpvrp;

					private int DvGbBxMoGChrpzkjimoDqDWbAwtB;

					private int MHvObAtleTpcydjGjoowSMRuDhVBA;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return AkaxKwyooxRCNZSlGXUabqGhfcfK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AkaxKwyooxRCNZSlGXUabqGhfcfK;
						}
					}

					[DebuggerHidden]
					public SeUPQjZZAIzOPNmElvLjSjKeHCKS(int P_0)
					{
						qceEcRdAOzpfZhpbPeVeBucrxDGwA = P_0;
						vCLcOHoHHkSOCtmsHFrneCVkEBqq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = qceEcRdAOzpfZhpbPeVeBucrxDGwA;
						MapHelper mapHelper = dMjZcuAbdfbnGwSZABuoVkOUlsgq;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							qceEcRdAOzpfZhpbPeVeBucrxDGwA = -1;
							if (ReInput._id != mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
							{
								ReInput.CheckInitialized(mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
								return false;
							}
							if (SVQbmGoCgjXlQooYDoNZCFflMVzP.uKTtsjLiKSZYEkajJsfrTScFdaTk<_0001>(out var _))
							{
								WlsjrQFNtNljxlPzfrNrHlTeEuPFA = mapHelper.hMYKUbiVXSFgGgJOpMgFRsZUGKGS<_0001>();
								QKVKxdEtsARdYBHwAtiVnkjzhpCe = WlsjrQFNtNljxlPzfrNrHlTeEuPFA.FwIGimYHKsSdutRnXvajJeatuVHB;
								OufJThqUsOdFrcEeHaTptnflrlkG = 0;
								goto IL_0124;
							}
							QKVKxdEtsARdYBHwAtiVnkjzhpCe = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
							OufJThqUsOdFrcEeHaTptnflrlkG = 0;
							goto IL_0287;
						}
						case 1:
							qceEcRdAOzpfZhpbPeVeBucrxDGwA = -1;
							goto IL_00eb;
						case 2:
							{
								qceEcRdAOzpfZhpbPeVeBucrxDGwA = -1;
								goto IL_0224;
							}
							IL_0224:
							MHvObAtleTpcydjGjoowSMRuDhVBA++;
							goto IL_0236;
							IL_00eb:
							AZckHugUBRRdxYzkcCRaMKOzpvrp++;
							goto IL_00fd;
							IL_0124:
							if (OufJThqUsOdFrcEeHaTptnflrlkG < QKVKxdEtsARdYBHwAtiVnkjzhpCe)
							{
								qtCjvjzgrifoAAasHaEpkMwCIzpSA = WlsjrQFNtNljxlPzfrNrHlTeEuPFA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(OufJThqUsOdFrcEeHaTptnflrlkG).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								fTfOYnVxSwWWqmCXoWOgmVZIHJSA = qtCjvjzgrifoAAasHaEpkMwCIzpSA.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								AZckHugUBRRdxYzkcCRaMKOzpvrp = 0;
								goto IL_00fd;
							}
							WlsjrQFNtNljxlPzfrNrHlTeEuPFA = null;
							break;
							IL_0287:
							if (OufJThqUsOdFrcEeHaTptnflrlkG >= QKVKxdEtsARdYBHwAtiVnkjzhpCe)
							{
								break;
							}
							WlsjrQFNtNljxlPzfrNrHlTeEuPFA = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(OufJThqUsOdFrcEeHaTptnflrlkG);
							fTfOYnVxSwWWqmCXoWOgmVZIHJSA = WlsjrQFNtNljxlPzfrNrHlTeEuPFA.FwIGimYHKsSdutRnXvajJeatuVHB;
							AZckHugUBRRdxYzkcCRaMKOzpvrp = 0;
							goto IL_025d;
							IL_0236:
							if (MHvObAtleTpcydjGjoowSMRuDhVBA < DvGbBxMoGChrpzkjimoDqDWbAwtB)
							{
								if (qtCjvjzgrifoAAasHaEpkMwCIzpSA.IMbAidiclopVawbUkoIYAkGvwawAA(MHvObAtleTpcydjGjoowSMRuDhVBA) is _0001 val && val.categoryId == kbZHroYtMoxmWczLLWBiRixtAjIgA)
								{
									AkaxKwyooxRCNZSlGXUabqGhfcfK = val;
									qceEcRdAOzpfZhpbPeVeBucrxDGwA = 2;
									return true;
								}
								goto IL_0224;
							}
							qtCjvjzgrifoAAasHaEpkMwCIzpSA = null;
							AZckHugUBRRdxYzkcCRaMKOzpvrp++;
							goto IL_025d;
							IL_00fd:
							if (AZckHugUBRRdxYzkcCRaMKOzpvrp < fTfOYnVxSwWWqmCXoWOgmVZIHJSA)
							{
								ControllerMap controllerMap = qtCjvjzgrifoAAasHaEpkMwCIzpSA.IMbAidiclopVawbUkoIYAkGvwawAA(AZckHugUBRRdxYzkcCRaMKOzpvrp);
								if (controllerMap.categoryId == kbZHroYtMoxmWczLLWBiRixtAjIgA)
								{
									AkaxKwyooxRCNZSlGXUabqGhfcfK = (_0001)controllerMap;
									qceEcRdAOzpfZhpbPeVeBucrxDGwA = 1;
									return true;
								}
								goto IL_00eb;
							}
							qtCjvjzgrifoAAasHaEpkMwCIzpSA = null;
							OufJThqUsOdFrcEeHaTptnflrlkG++;
							goto IL_0124;
							IL_025d:
							if (AZckHugUBRRdxYzkcCRaMKOzpvrp < fTfOYnVxSwWWqmCXoWOgmVZIHJSA)
							{
								qtCjvjzgrifoAAasHaEpkMwCIzpSA = WlsjrQFNtNljxlPzfrNrHlTeEuPFA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(AZckHugUBRRdxYzkcCRaMKOzpvrp).iuMldFPvAqBfeiUXQrGwudCQSSbq;
								DvGbBxMoGChrpzkjimoDqDWbAwtB = qtCjvjzgrifoAAasHaEpkMwCIzpSA.AenMnPaenKXbTfnmKTHZLLNLsyPr;
								MHvObAtleTpcydjGjoowSMRuDhVBA = 0;
								goto IL_0236;
							}
							WlsjrQFNtNljxlPzfrNrHlTeEuPFA = null;
							OufJThqUsOdFrcEeHaTptnflrlkG++;
							goto IL_0287;
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
					IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
					{
						SeUPQjZZAIzOPNmElvLjSjKeHCKS<_0001> seUPQjZZAIzOPNmElvLjSjKeHCKS;
						if (qceEcRdAOzpfZhpbPeVeBucrxDGwA == -2 && vCLcOHoHHkSOCtmsHFrneCVkEBqq == Environment.CurrentManagedThreadId)
						{
							qceEcRdAOzpfZhpbPeVeBucrxDGwA = 0;
							seUPQjZZAIzOPNmElvLjSjKeHCKS = this;
						}
						else
						{
							seUPQjZZAIzOPNmElvLjSjKeHCKS = new SeUPQjZZAIzOPNmElvLjSjKeHCKS<_0001>(0);
							seUPQjZZAIzOPNmElvLjSjKeHCKS.dMjZcuAbdfbnGwSZABuoVkOUlsgq = dMjZcuAbdfbnGwSZABuoVkOUlsgq;
						}
						seUPQjZZAIzOPNmElvLjSjKeHCKS.kbZHroYtMoxmWczLLWBiRixtAjIgA = OQQFOUeUtsIAFfNwTfjzFXrDutNPb;
						return seUPQjZZAIzOPNmElvLjSjKeHCKS;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class qyJWOaVQnmBOqFFnYtcNeRAZpbYx : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int EkubZlbecdvzVtHLMAGGnTLaiMZk;

					private ControllerMap HmogswzzUUlemjTbannFaulkbiin;

					private int fXhosKXnTSVMbVwlHZXkSlRgUmLl;

					public MapHelper zOROdHmgYHXVuxDvUhaREhDAVTeY;

					private ControllerType DEJsjlvmxLCtPFLSWcSJXAifWyWmA;

					public ControllerType JhBQRJAhfhAJfVpkllHOrfXEWhru;

					private int TGpCqSBFIIOJCBluXZOBXeEPDOQW;

					public int WtpWPRwBSdafSibvILTCGjVnNmFz;

					private XCOErbHoOlwtReVrlBlQrQooVXdNA wDACljgwwuoPvtrICMvkmTjTAEFkA;

					private int SXzhHLhzoQRFVcnbBDmSGvsLFmCvA;

					private int MuRlKcYgyrByIoEwhPOjIcnbKSdQ;

					private BpzomrqmbmNinOxWAGGlQTtkPnsX goBrYKjKJLpvsUMXLBoVSDFnHMNc;

					private int qWGCPxndBZGWsDHfurbjceNymjJQA;

					private int jeUPZtOeYMLCufmBQiysDypaoBip;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return HmogswzzUUlemjTbannFaulkbiin;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HmogswzzUUlemjTbannFaulkbiin;
						}
					}

					[DebuggerHidden]
					public qyJWOaVQnmBOqFFnYtcNeRAZpbYx(int P_0)
					{
						EkubZlbecdvzVtHLMAGGnTLaiMZk = P_0;
						fXhosKXnTSVMbVwlHZXkSlRgUmLl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int ekubZlbecdvzVtHLMAGGnTLaiMZk = EkubZlbecdvzVtHLMAGGnTLaiMZk;
						MapHelper mapHelper = zOROdHmgYHXVuxDvUhaREhDAVTeY;
						if (ekubZlbecdvzVtHLMAGGnTLaiMZk != 0)
						{
							if (ekubZlbecdvzVtHLMAGGnTLaiMZk != 1)
							{
								return false;
							}
							EkubZlbecdvzVtHLMAGGnTLaiMZk = -1;
							goto IL_00e2;
						}
						EkubZlbecdvzVtHLMAGGnTLaiMZk = -1;
						if (ReInput._id != mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu)
						{
							ReInput.CheckInitialized(mapHelper.qxBDhAOfmFYKVMWNeBZhDsRbGthu);
							return false;
						}
						wDACljgwwuoPvtrICMvkmTjTAEFkA = mapHelper.oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(DEJsjlvmxLCtPFLSWcSJXAifWyWmA);
						SXzhHLhzoQRFVcnbBDmSGvsLFmCvA = wDACljgwwuoPvtrICMvkmTjTAEFkA.FwIGimYHKsSdutRnXvajJeatuVHB;
						MuRlKcYgyrByIoEwhPOjIcnbKSdQ = 0;
						goto IL_0117;
						IL_00f2:
						if (jeUPZtOeYMLCufmBQiysDypaoBip < qWGCPxndBZGWsDHfurbjceNymjJQA)
						{
							ControllerMap controllerMap = goBrYKjKJLpvsUMXLBoVSDFnHMNc.IMbAidiclopVawbUkoIYAkGvwawAA(jeUPZtOeYMLCufmBQiysDypaoBip);
							if (controllerMap.categoryId == TGpCqSBFIIOJCBluXZOBXeEPDOQW)
							{
								HmogswzzUUlemjTbannFaulkbiin = controllerMap;
								EkubZlbecdvzVtHLMAGGnTLaiMZk = 1;
								return true;
							}
							goto IL_00e2;
						}
						goBrYKjKJLpvsUMXLBoVSDFnHMNc = null;
						MuRlKcYgyrByIoEwhPOjIcnbKSdQ++;
						goto IL_0117;
						IL_00e2:
						jeUPZtOeYMLCufmBQiysDypaoBip++;
						goto IL_00f2;
						IL_0117:
						if (MuRlKcYgyrByIoEwhPOjIcnbKSdQ < SXzhHLhzoQRFVcnbBDmSGvsLFmCvA)
						{
							goBrYKjKJLpvsUMXLBoVSDFnHMNc = wDACljgwwuoPvtrICMvkmTjTAEFkA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(MuRlKcYgyrByIoEwhPOjIcnbKSdQ).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							qWGCPxndBZGWsDHfurbjceNymjJQA = goBrYKjKJLpvsUMXLBoVSDFnHMNc.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							jeUPZtOeYMLCufmBQiysDypaoBip = 0;
							goto IL_00f2;
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						qyJWOaVQnmBOqFFnYtcNeRAZpbYx qyJWOaVQnmBOqFFnYtcNeRAZpbYx2;
						if (EkubZlbecdvzVtHLMAGGnTLaiMZk == -2 && fXhosKXnTSVMbVwlHZXkSlRgUmLl == Environment.CurrentManagedThreadId)
						{
							EkubZlbecdvzVtHLMAGGnTLaiMZk = 0;
							qyJWOaVQnmBOqFFnYtcNeRAZpbYx2 = this;
						}
						else
						{
							qyJWOaVQnmBOqFFnYtcNeRAZpbYx2 = new qyJWOaVQnmBOqFFnYtcNeRAZpbYx(0);
							qyJWOaVQnmBOqFFnYtcNeRAZpbYx2.zOROdHmgYHXVuxDvUhaREhDAVTeY = zOROdHmgYHXVuxDvUhaREhDAVTeY;
						}
						qyJWOaVQnmBOqFFnYtcNeRAZpbYx2.TGpCqSBFIIOJCBluXZOBXeEPDOQW = WtpWPRwBSdafSibvILTCGjVnNmFz;
						qyJWOaVQnmBOqFFnYtcNeRAZpbYx2.DEJsjlvmxLCtPFLSWcSJXAifWyWmA = JhBQRJAhfhAJfVpkllHOrfXEWhru;
						return qyJWOaVQnmBOqFFnYtcNeRAZpbYx2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly wsTGaisyEgVqWobCcVTBhcYPpDji TNiSWoykewpsMCKkxfrXeTxHJZST;

				private Player NWXgpFxDsMZANkuENTnSKhpLOtmS;

				private ControllerHelper oHMEJVxlADgIsblHZLzlGkLDMGmZB;

				private readonly ControllerMapEnabler tqbWFyGEdtCWlQGuUDcAQBOifyAR;

				private readonly ControllerMapLayoutManager zULBgAdQCmjRcCVkAMYcQPWHZPaLD;

				private readonly int qxBDhAOfmFYKVMWNeBZhDsRbGthu;

				public ControllerMapLayoutManager layoutManager => zULBgAdQCmjRcCVkAMYcQPWHZPaLD;

				public ControllerMapEnabler mapEnabler => tqbWFyGEdtCWlQGuUDcAQBOifyAR;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
						{
							ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return NWXgpFxDsMZANkuENTnSKhpLOtmS.pUcBslzzLOiQjTlQsQkqXLxySpX.yxlcXWJyivSECaVXCcPaGrFzeWGN(NWXgpFxDsMZANkuENTnSKhpLOtmS.QCUoYDqLLDFsRwBhDegcxJcsDftHA);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, wsTGaisyEgVqWobCcVTBhcYPpDji P_2, ControllerMapLayoutManager.ccDuPLOhlbrAqOTHJEHJSRpBmDEb P_3, ControllerMapEnabler.ybCAJZdDMTpCNSaMwMfysgFQeUXm P_4)
				{
					qxBDhAOfmFYKVMWNeBZhDsRbGthu = ReInput.id;
					NWXgpFxDsMZANkuENTnSKhpLOtmS = P_0;
					oHMEJVxlADgIsblHZLzlGkLDMGmZB = P_1;
					TNiSWoykewpsMCKkxfrXeTxHJZST = P_2;
					tqbWFyGEdtCWlQGuUDcAQBOifyAR = new ControllerMapEnabler(P_0, P_4);
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD = new ControllerMapLayoutManager(P_0, P_3);
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.YzTLDMMsotHSOvKHCMxXuKFsAtNy += tqbWFyGEdtCWlQGuUDcAQBOifyAR.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					ZXUBINjgJhZlermfIscafodedmwS<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					THSAexiOpRnfBEZHjsFUIKIwXAwA<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					KPLpGAANlJrpRMPMbbMrJyyskWzQA(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					fczHddfknkGiSAOfocesIXZFCHzIA(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					ZXUBINjgJhZlermfIscafodedmwS<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					THSAexiOpRnfBEZHjsFUIKIwXAwA<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					KPLpGAANlJrpRMPMbbMrJyyskWzQA(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					fczHddfknkGiSAOfocesIXZFCHzIA(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void ZXUBINjgJhZlermfIscafodedmwS<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						sVzDvYkdrVvyRbhXytDfHvRwcKLi(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void THSAexiOpRnfBEZHjsFUIKIwXAwA<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						dBejIoLStDfQlAiTUqXMVivwKDeR(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void KPLpGAANlJrpRMPMbbMrJyyskWzQA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						sVzDvYkdrVvyRbhXytDfHvRwcKLi(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void fczHddfknkGiSAOfocesIXZFCHzIA(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						dBejIoLStDfQlAiTUqXMVivwKDeR(P_0, P_1, P_2, P_3, P_4);
					}
				}

				[IteratorStateMachine(typeof(gJVAMoOOogCjZAsUwIDErXQzQCTz))]
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new gJVAMoOOogCjZAsUwIDErXQzQCTz(-2)
					{
						wPMGTeeluNORTBXnGukIlBeIooDae = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num; j++)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.RUFIjNpOMATOulSOKbRSLbddBuES(results, true);
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(psQIVLSmoncsiFDohMfvGcqfnpEBc))]
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new psQIVLSmoncsiFDohMfvGcqfnpEBc<T>(-2)
					{
						YSKMEyNcramPOOwFfvGLQDVYcdvT = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (SVQbmGoCgjXlQooYDoNZCFflMVzP.uKTtsjLiKSZYEkajJsfrTScFdaTk<T>(out var controllerType))
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int i = 0; i < num; i++)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.EpFEDGeDREylcBXNbGHHHRyRxukpA(results, true);
						}
					}
					else
					{
						int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
						for (int j = 0; j < cdDMVOEYEeaEACfRYzOcwBUJJAEg; j++)
						{
							XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA2 = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(j);
							int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA2.FwIGimYHKsSdutRnXvajJeatuVHB;
							for (int k = 0; k < num2; k++)
							{
								xCOErbHoOlwtReVrlBlQrQooVXdNA2.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(k).iuMldFPvAqBfeiUXQrGwudCQSSbq.EpFEDGeDREylcBXNbGHHHRyRxukpA(results, true);
							}
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(TKWXYTgsjrLmLmefajrOJtYiYhsA))]
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new TKWXYTgsjrLmLmefajrOJtYiYhsA(-2)
					{
						FMAymobjEeNphciMbiFiHXRceTWWA = this,
						ALCaBoRzSOUlsAMTCucfJDDsgkku = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num; i++)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.RUFIjNpOMATOulSOKbRSLbddBuES(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				[IteratorStateMachine(typeof(AOlyOkNJPoODBuFnwyNlFndLmyDr))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new AOlyOkNJPoODBuFnwyNlFndLmyDr(-2)
					{
						jChDrriUKCJfrMoipLQVuRZfHETx = this,
						bPLmNORzrGcWFiLNffxRhYPAWqgy = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				[IteratorStateMachine(typeof(SeUPQjZZAIzOPNmElvLjSjKeHCKS))]
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new SeUPQjZZAIzOPNmElvLjSjKeHCKS<T>(-2)
					{
						dMjZcuAbdfbnGwSZABuoVkOUlsgq = this,
						OQQFOUeUtsIAFfNwTfjzFXrDutNPb = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				[IteratorStateMachine(typeof(qyJWOaVQnmBOqFFnYtcNeRAZpbYx))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new qyJWOaVQnmBOqFFnYtcNeRAZpbYx(-2)
					{
						zOROdHmgYHXVuxDvUhaREhDAVTeY = this,
						WtpWPRwBSdafSibvILTCGjVnNmFz = categoryId,
						JhBQRJAhfhAJfVpkllHOrfXEWhru = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory(int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num; j++)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.RMmgmgyYADttzCMqapdLJSwiSVfu(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory<T>(int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					if (SVQbmGoCgjXlQooYDoNZCFflMVzP.uKTtsjLiKSZYEkajJsfrTScFdaTk<T>(out var controllerType))
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int i = 0; i < num; i++)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.enDIsebVlULiIsfJmEDuOFwqbRmp(categoryId, results, true);
						}
					}
					else
					{
						int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
						for (int j = 0; j < cdDMVOEYEeaEACfRYzOcwBUJJAEg; j++)
						{
							XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA2 = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(j);
							int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA2.FwIGimYHKsSdutRnXvajJeatuVHB;
							for (int k = 0; k < num2; k++)
							{
								xCOErbHoOlwtReVrlBlQrQooVXdNA2.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(k).iuMldFPvAqBfeiUXQrGwudCQSSbq.enDIsebVlULiIsfJmEDuOFwqbRmp(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType, results);
				}

				public int GetAllMapsInCategory(int categoryId, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num; i++)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.RMmgmgyYADttzCMqapdLJSwiSVfu(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return BWnssKRVqEEkcBvZXAykaWMZzzDD<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return jtSvDmTjMCIhHDNFiIoxgbefHeKpA(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMaps(controller.type, controller.id);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return TjMdmgbFHVFkZQNptnFmoyFgLQtc(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId);
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					ListTools.TryClear(results);
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return 0;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					return oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType).QlllfGYgQhzrYUdVBsXmntapKYEs(controllerId)?.iuMldFPvAqBfeiUXQrGwudCQSSbq.RMmgmgyYADttzCMqapdLJSwiSVfu(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId, results);
				}

				public int GetMapsInCategory(Controller controller, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId, results);
				}

				public int GetMapsInCategory(Controller controller, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId, results);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return yYpTQLtwDVRhpJTItTCkWEAJDrWfA<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory<T>(controllerId, mapCategoryId);
				}

				public int GetMapsInCategory<T>(int controllerId, int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					AWgeajfBjHIPFotyXrmQOkYDysesA aWgeajfBjHIPFotyXrmQOkYDysesA = hMYKUbiVXSFgGgJOpMgFRsZUGKGS<T>().QlllfGYgQhzrYUdVBsXmntapKYEs(controllerId);
					if (aWgeajfBjHIPFotyXrmQOkYDysesA == null)
					{
						return 0;
					}
					aWgeajfBjHIPFotyXrmQOkYDysesA.iuMldFPvAqBfeiUXQrGwudCQSSbq.enDIsebVlULiIsfJmEDuOFwqbRmp(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerId, mapCategoryId, results);
				}

				public T GetMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)cqJBFlUTLYcRmYjhOExWrJCSlpYw(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)tihKshyQeEsuQCbbPOcyWwFLtnZ(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return (T)ESYCJJANMCDwDtsWHsEyWkOhIXWS(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.INVFVAGZCWtTcuaCYfycKpoxOyjEb(mapId);
							if (controllerMap != null)
							{
								return controllerMap;
							}
						}
					}
					return null;
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return cqJBFlUTLYcRmYjhOExWrJCSlpYw(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return tihKshyQeEsuQCbbPOcyWwFLtnZ(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return ESYCJJANMCDwDtsWHsEyWkOhIXWS(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, mapId);
				}

				public ControllerMap GetMap(Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryId, layoutId);
				}

				public ControllerMap GetMap(Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryName, layoutName);
				}

				public T GetFirstMapInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory<T>(controllerId, mapCategoryId);
				}

				public T GetFirstMapInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)mqkWqAtXrZMtyelaGRKVJDZdBdeI(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory(controllerType, controllerId, mapCategoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return mqkWqAtXrZMtyelaGRKVJDZdBdeI(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryName);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryId);
				}

				public void AddMap<T>(int controllerId, ControllerMap map) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						udJunQFQkBoMThJimctryITPELLS(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						vERBdufdmzXLOuopqWcSAMChlsXW(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						udJunQFQkBoMThJimctryITPELLS(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						udJunQFQkBoMThJimctryITPELLS(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						vERBdufdmzXLOuopqWcSAMChlsXW(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						udJunQFQkBoMThJimctryITPELLS(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					return eLthPyrNRXOQPTuxkljsMohMenvS(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					return eLthPyrNRXOQPTuxkljsMohMenvS(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml<T>(controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromXml(ControllerType controllerType, int controllerId, List<string> xmlStrings)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml(controllerType, controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public bool AddMapFromJson<T>(int controllerId, string jsonString) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					return lLzahFaBQCwedHtYTXUmrHTvpCrB(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					return lLzahFaBQCwedHtYTXUmrHTvpCrB(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson<T>(controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromJson(ControllerType controllerType, int controllerId, List<string> jsonStrings)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson(controllerType, controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public void AddEmptyMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						pQbdrrNRqrmxSPCQmcZxFdYfoOReb(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						vtLFtQEFIOgglehNnTaGcMODvTZmc(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						pQbdrrNRqrmxSPCQmcZxFdYfoOReb(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						AddEmptyMap(controllerType, controllerId, mapCategoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else if (mapId >= 0)
					{
						KkzIkfFvFaBBbvozJpAoPqtfFDYm(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						KHBrUHbmJqVWoBmrCSAnWFtCxbxn(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						kIkaKwDNkTgHtCYUqpPlCSOkXdHKA(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else if (mapId >= 0)
					{
						KkzIkfFvFaBBbvozJpAoPqtfFDYm(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						KHBrUHbmJqVWoBmrCSAnWFtCxbxn(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						kIkaKwDNkTgHtCYUqpPlCSOkXdHKA(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMaps(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.nriLYbhcDKlhSQqUTXhWHvxImzPv(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMapsInCategory(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory<T>(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMapsInCategory(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i));
						for (int j = 0; j < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; j++)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.qmqWeqnLrtuHKnNULcrYiNBBkGBc(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.qmqWeqnLrtuHKnNULcrYiNBBkGBc(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(controllerType, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
						for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.mREkhHOoMFnpKkDVewLkxiSTMdOp(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory(controllerType, mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInLayout<T>(int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMapsInLayout(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.JkIJDBqweWHvIhFpHpKwuPiTPJTt(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout(controllerType, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMapsForController(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMapsForController(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController<T>(controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(controllerId);
					if (num >= 0)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.nriLYbhcDKlhSQqUTXhWHvxImzPv(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(controllerId);
					if (num >= 0)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.qmqWeqnLrtuHKnNULcrYiNBBkGBc(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController(controllerType, controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
					}
					else
					{
						ClearMapsForControllerInLayout(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(controllerId);
					if (num >= 0)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.JkIJDBqweWHvIhFpHpKwuPiTPJTt(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout(controllerType, controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearAllMaps(bool userAssignableOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					for (int i = 0; i < oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						ClearMaps(oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i), userAssignableOnly);
					}
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return yvQxEfCZePftBORIKIhtJUiymEAuA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return uIpPzERhWLLxkxYUHvAoWoyfjmLj(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						ActionElementMap actionElementMap = uIpPzERhWLLxkxYUHvAoWoyfjmLj(oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return RkaDHtxjDoCcqgiBHWCxaSlHcVTcb(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return jqIfoOSJuKhlSyQzrGTbVwJPCpuc(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(ybxIPWkCjVcUePAwmriSuESrfZCkA))]
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new ybxIPWkCjVcUePAwmriSuESrfZCkA(-2)
					{
						fnZsdHIwNujzurRcbaZTEQVZxppF = this,
						byHVmiLBMJSjiAOGjrcfisGRjVTw = actionId,
						ZqPpwGbFqDFDJdpLsWATPsojORBA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ButtonMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controller == null)
					{
						results.Clear();
						return 0;
					}
					return zqJviARttpJhdGhdyitdTDhTiAbE(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					return KdTjIFjhvqDUleZtWicnEJNNcRXSA(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return dYSABoYXwHbfcjVmGErlYrgOHEOd(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetButtonMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return KDQBqJACtNacPSUGtMKNZGlLTiyhA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return ANDGUhqDlAstAmOUeIYjGenKJUid(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						ActionElementMap actionElementMap = ANDGUhqDlAstAmOUeIYjGenKJUid(oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return JlkLmbDFrxejzHalJqwRgfeIEfdob(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return ruzGidnEdmBuleRTuQCYtpjpkjTz(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(xPPoHEdSZFdtuAUVeqMRLaHpFvuUA))]
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new xPPoHEdSZFdtuAUVeqMRLaHpFvuUA(-2)
					{
						lVpGmaDDowhOGQOiGXqPafPzpMsc = this,
						NnJzGdFokjtLCOOsoFFRIfcdkcLl = actionId,
						lQyaUSaaOnHrqHRrnyUJyRnGbjKK = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return AxisMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return NaCZtSzMXQvXXZBZLXYzibFQdYYH(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return mjzILeoQQvmYUkfelNiCIXSiyurB(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return dotArIqIVMpBOqCShpVWcwsaZdwl(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetAxisMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return aFHDFgUycquHJYKKlTjYhIkRTgzm(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return mRtyrxdAHsilLmjajOWLODdBGeLS(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						ActionElementMap actionElementMap = mRtyrxdAHsilLmjajOWLODdBGeLS(oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return LmajwZyxuovYGkESjFvaZAXHBFYd(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return HSzbdcAkOQWBLPLyiILUBCtBLJkj(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(QmrPpZTsGiNGhpkeacYYETyyziCJA))]
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new QmrPpZTsGiNGhpkeacYYETyyziCJA(-2)
					{
						EAsYQImdxSpMifYhZAZKAkWcOkdE = this,
						puklTxXEKuLFHuVdeGnIgmXdLdsp = actionId,
						whCkkMNOJybkqzDpshBSGwXhRXTr = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ElementMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return TSMDbegYSOBQfihepmVqgjRaxRGR(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					return cSCikyzlDgFYXyzoQakgcPyPyrBo(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return eWdsesreiRiNHVzCIeboElxQZbTH(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, skipDisabledMaps);
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return VAFQBByRLOsHaQmJODExPeNsjRjS(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, actionId, skipDisabledMaps);
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return VAFQBByRLOsHaQmJODExPeNsjRjS(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, skipDisabledMaps);
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return oEmGhkpeeqwadhUKPLoBZKLbqpZu(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, actionId, skipDisabledMaps);
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return oEmGhkpeeqwadhUKPLoBZKLbqpZu(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, skipDisabledMaps, results);
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return ClScpucpYhPmEaISNWBFMetCZXBhA(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, actionId, skipDisabledMaps, results);
					qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return ClScpucpYhPmEaISNWBFMetCZXBhA(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<T>.array;
					}
					return GzAlMpQHATFylxupNPvpmBoujUWT<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return gaOyrjZEPuhlcsVAldtXsnUXinqd(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<T>.array;
					}
					return BpxtbFopXvTGUZVCigwACLQFojJS<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return haiQuDDlMWjIXzCSnHqErNlJHbrC(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						ArrayTools.Combine(ref array, haiQuDDlMWjIXzCSnHqErNlJHbrC(oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int num = 0;
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num2; j++)
						{
							num += xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.snfgHqeWhhuliGUmOACpBMmFwAmqb(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int num = 0;
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num2; i++)
					{
						num += xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.snfgHqeWhhuliGUmOACpBMmFwAmqb(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return SetAllMapsEnabled(state, controller.type, controller.id);
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					return oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType).QlllfGYgQhzrYUdVBsXmntapKYEs(controllerId)?.iuMldFPvAqBfeiUXQrGwudCQSSbq.snfgHqeWhhuliGUmOACpBMmFwAmqb(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num2; j++)
						{
							num += xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.SFvtnsmVNPVoUdHeJVaLHiOXkCPc(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						ControllerType controllerType = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.JVGUyxtSjWjXjesjYdedruJrrSFy(i);
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							num += SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num2; i++)
					{
						num += xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.SFvtnsmVNPVoUdHeJVaLHiOXkCPc(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId, int layoutId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num2; i++)
					{
						num += xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.fuvdURCmJqmXatybPRScygCLvAQP(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					return oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controller.type).QlllfGYgQhzrYUdVBsXmntapKYEs(controller.id)?.iuMldFPvAqBfeiUXQrGwudCQSSbq.SFvtnsmVNPVoUdHeJVaLHiOXkCPc(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					if (layoutId < 0)
					{
						return 0;
					}
					return oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controller.type).QlllfGYgQhzrYUdVBsXmntapKYEs(controller.id)?.iuMldFPvAqBfeiUXQrGwudCQSSbq.fuvdURCmJqmXatybPRScygCLvAQP(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controller.type, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId, layoutId);
				}

				public void LoadDefaultMaps(ControllerType controllerType)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						kFIwgzppSLLkKPnAOCuGgdgjghGpA(false);
						break;
					case ControllerType.Keyboard:
						yxEUApNVgRRDjrbXWPSpemumAYnEA(false);
						break;
					case ControllerType.Mouse:
						cWhwsUsbGLevXnXUjNuyAILFpcqt(false);
						break;
					case ControllerType.Custom:
						UffIdLFobHoNtlhHbqeHggUHiEPkB(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					if (category == null)
					{
						return false;
					}
					return ContainsMapInCategory(category.id);
				}

				public bool ContainsMapInCategory(int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num; j++)
						{
							if (xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq.hyYPHlcCUipcFEdfEkRkFPgNAIhB(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return false;
					}
					return ContainsMapInCategory(mapCategoryId);
				}

				public bool ContainsMapInCategory(ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num; i++)
					{
						if (xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.hyYPHlcCUipcFEdfEkRkFPgNAIhB(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return NWXgpFxDsMZANkuENTnSKhpLOtmS.pUcBslzzLOiQjTlQsQkqXLxySpX.mcSowgfWkICbLviMcwKVuFBXwNmK(NWXgpFxDsMZANkuENTnSKhpLOtmS.QCUoYDqLLDFsRwBhDegcxJcsDftHA, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != qxBDhAOfmFYKVMWNeBZhDsRbGthu)
					{
						ReInput.CheckInitialized(qxBDhAOfmFYKVMWNeBZhDsRbGthu);
						return null;
					}
					return NWXgpFxDsMZANkuENTnSKhpLOtmS.pUcBslzzLOiQjTlQsQkqXLxySpX.nuatKlntTuiBBKKYpVnEkwckMurb(NWXgpFxDsMZANkuENTnSKhpLOtmS.QCUoYDqLLDFsRwBhDegcxJcsDftHA, behaviorName);
				}

				internal void fRhGpSCPIRrCppVeVncCBMljliwlb()
				{
					tqbWFyGEdtCWlQGuUDcAQBOifyAR.LoadDefaults();
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.LoadDefaults();
				}

				internal void kFIwgzppSLLkKPnAOCuGgdgjghGpA(bool P_0)
				{
					if (TNiSWoykewpsMCKkxfrXeTxHJZST.eqPyeGVRLvklvknRHsUnSfbSdMLJA == null)
					{
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick);
					oHMEJVxlADgIsblHZLzlGkLDMGmZB.vdnCirvuIizHaUoSqnEPbKLjQhml.gbfqNdeHCQhYfcFejApocQQfxVXUB();
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num; i++)
					{
						TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB aQofIYFZBCdRNEcCaMfJVSEGzChdB = (TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB)xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.bPBvSQSPFBOEZzzSdKegAflIdxiN(j).enabled;
							}
						}
						aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.DfojLzcKXzZwoZWTOcDbeoQvanIc(false);
						for (int k = 0; k < TNiSWoykewpsMCKkxfrXeTxHJZST.eqPyeGVRLvklvknRHsUnSfbSdMLJA.Length; k++)
						{
							NVhzziiXvZKGeMoOKZocQLBQrTst(aQofIYFZBCdRNEcCaMfJVSEGzChdB.bJkzuoVFDtsUqMpDgBxoNgOZJmNj, aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA, TNiSWoykewpsMCKkxfrXeTxHJZST.eqPyeGVRLvklvknRHsUnSfbSdMLJA[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb());
							for (int l = 0; l < num3; l++)
							{
								aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.bPBvSQSPFBOEZzzSdKegAflIdxiN(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = false;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.Apply();
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void yxEUApNVgRRDjrbXWPSpemumAYnEA(bool P_0)
				{
					if (TNiSWoykewpsMCKkxfrXeTxHJZST.uNVOzXaSoVjCcneDIgzSGhUvvtr == null)
					{
						return;
					}
					BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Keyboard).QlllfGYgQhzrYUdVBsXmntapKYEs(0).iuMldFPvAqBfeiUXQrGwudCQSSbq;
					bool[] array = null;
					if (!P_0)
					{
						int num = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(i).enabled;
						}
					}
					bpzomrqmbmNinOxWAGGlQTtkPnsX.nriLYbhcDKlhSQqUTXhWHvxImzPv(false);
					for (int j = 0; j < TNiSWoykewpsMCKkxfrXeTxHJZST.uNVOzXaSoVjCcneDIgzSGhUvvtr.Length; j++)
					{
						cHjmmntdHIjqPzwYHqwnEXRwXGEG cHjmmntdHIjqPzwYHqwnEXRwXGEG2 = TNiSWoykewpsMCKkxfrXeTxHJZST.uNVOzXaSoVjCcneDIgzSGhUvvtr[j];
						if (cHjmmntdHIjqPzwYHqwnEXRwXGEG2.HrfRSFyptKGHiJiupViPyNXjDVYB >= 0 && cHjmmntdHIjqPzwYHqwnEXRwXGEG2.owtjhdfbLbdJQeOQjiyhelFGHrSMA >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, cHjmmntdHIjqPzwYHqwnEXRwXGEG2.HrfRSFyptKGHiJiupViPyNXjDVYB, cHjmmntdHIjqPzwYHqwnEXRwXGEG2.owtjhdfbLbdJQeOQjiyhelFGHrSMA);
							if (P_0)
							{
								keyboardMap.enabled = cHjmmntdHIjqPzwYHqwnEXRwXGEG2.peyhhfqyjAaciFITizTMuKSZhVzr;
							}
							udJunQFQkBoMThJimctryITPELLS(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr);
						for (int k = 0; k < num2; k++)
						{
							bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = false;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.Apply();
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void cWhwsUsbGLevXnXUjNuyAILFpcqt(bool P_0)
				{
					if (TNiSWoykewpsMCKkxfrXeTxHJZST.wtwUgVXSeOykKEDQQmoMDDrEsvjH == null)
					{
						return;
					}
					BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Mouse).QlllfGYgQhzrYUdVBsXmntapKYEs(0).iuMldFPvAqBfeiUXQrGwudCQSSbq;
					bool[] array = null;
					if (!P_0)
					{
						int num = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(i).enabled;
						}
					}
					bpzomrqmbmNinOxWAGGlQTtkPnsX.nriLYbhcDKlhSQqUTXhWHvxImzPv(false);
					for (int j = 0; j < TNiSWoykewpsMCKkxfrXeTxHJZST.wtwUgVXSeOykKEDQQmoMDDrEsvjH.Length; j++)
					{
						cHjmmntdHIjqPzwYHqwnEXRwXGEG cHjmmntdHIjqPzwYHqwnEXRwXGEG2 = TNiSWoykewpsMCKkxfrXeTxHJZST.wtwUgVXSeOykKEDQQmoMDDrEsvjH[j];
						if (cHjmmntdHIjqPzwYHqwnEXRwXGEG2.HrfRSFyptKGHiJiupViPyNXjDVYB >= 0 && cHjmmntdHIjqPzwYHqwnEXRwXGEG2.owtjhdfbLbdJQeOQjiyhelFGHrSMA >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, cHjmmntdHIjqPzwYHqwnEXRwXGEG2.HrfRSFyptKGHiJiupViPyNXjDVYB, cHjmmntdHIjqPzwYHqwnEXRwXGEG2.owtjhdfbLbdJQeOQjiyhelFGHrSMA);
							if (P_0)
							{
								mouseMap.enabled = cHjmmntdHIjqPzwYHqwnEXRwXGEG2.peyhhfqyjAaciFITizTMuKSZhVzr;
							}
							udJunQFQkBoMThJimctryITPELLS(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr);
						for (int k = 0; k < num2; k++)
						{
							bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = false;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.Apply();
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void UffIdLFobHoNtlhHbqeHggUHiEPkB(bool P_0)
				{
					if (TNiSWoykewpsMCKkxfrXeTxHJZST.CnHMibYUuEiICHVOgczIzulryavH == null)
					{
						return;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num; i++)
					{
						TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB aQofIYFZBCdRNEcCaMfJVSEGzChdB = (TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB)xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.bPBvSQSPFBOEZzzSdKegAflIdxiN(j).enabled;
							}
						}
						aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.DfojLzcKXzZwoZWTOcDbeoQvanIc(false);
						for (int k = 0; k < TNiSWoykewpsMCKkxfrXeTxHJZST.CnHMibYUuEiICHVOgczIzulryavH.Length; k++)
						{
							qCTfaRHMyGAlzZVpcnVPApCYUJkO(aQofIYFZBCdRNEcCaMfJVSEGzChdB.bJkzuoVFDtsUqMpDgBxoNgOZJmNj, aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA, TNiSWoykewpsMCKkxfrXeTxHJZST.CnHMibYUuEiICHVOgczIzulryavH[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb());
							for (int l = 0; l < num3; l++)
							{
								aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA.bPBvSQSPFBOEZzzSdKegAflIdxiN(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = false;
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.Apply();
					zULBgAdQCmjRcCVkAMYcQPWHZPaLD.loadFromUserDataStore = loadFromUserDataStore;
				}

				private XCOErbHoOlwtReVrlBlQrQooVXdNA hMYKUbiVXSFgGgJOpMgFRsZUGKGS<_0001>() where _0001 : ControllerMap
				{
					return oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(SVQbmGoCgjXlQooYDoNZCFflMVzP.layuPNmdlkWxagmCWvNTmMGadukr<_0001>());
				}

				internal global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> bkXGCHPudgqZVVzAcSVHnpFoyvyj(Joystick P_0, bool P_1)
				{
					if (P_0 == null || TNiSWoykewpsMCKkxfrXeTxHJZST.eqPyeGVRLvklvknRHsUnSfbSdMLJA == null)
					{
						return null;
					}
					global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> vvqWcefspViLvBkIonynvYaRLpFT2 = new global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap>(P_0.id);
					for (int i = 0; i < TNiSWoykewpsMCKkxfrXeTxHJZST.eqPyeGVRLvklvknRHsUnSfbSdMLJA.Length; i++)
					{
						NVhzziiXvZKGeMoOKZocQLBQrTst(P_0, vvqWcefspViLvBkIonynvYaRLpFT2, TNiSWoykewpsMCKkxfrXeTxHJZST.eqPyeGVRLvklvknRHsUnSfbSdMLJA[i], P_1);
					}
					if (vvqWcefspViLvBkIonynvYaRLpFT2.cLFOTXBjzlMfxMSeRWBhGFJkuhvb() == 0)
					{
						return null;
					}
					return vvqWcefspViLvBkIonynvYaRLpFT2;
				}

				private void NVhzziiXvZKGeMoOKZocQLBQrTst(Joystick P_0, global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> P_1, cHjmmntdHIjqPzwYHqwnEXRwXGEG P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.HrfRSFyptKGHiJiupViPyNXjDVYB >= 0 && P_2.owtjhdfbLbdJQeOQjiyhelFGHrSMA >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.HOUfLSHZDFkgOKHPGTiFhpwlDNfDA(P_0, P_2.HrfRSFyptKGHiJiupViPyNXjDVYB, P_2.owtjhdfbLbdJQeOQjiyhelFGHrSMA);
						hgwfRdRoPADdcEgrryWFCEolgFdeA(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.peyhhfqyjAaciFITizTMuKSZhVzr ? BoolOption.True : BoolOption.False);
						}
						P_1.WmLHpxnOQHBjYDImEYJbWAZjtCyP(joystickMap, boolOption);
					}
				}

				internal global::vvqWcefspViLvBkIonynvYaRLpFT<CustomControllerMap> SYeQzCklMcFtsXUNOGGQLkmBfyjDA(CustomController P_0, bool P_1)
				{
					if (P_0 == null || TNiSWoykewpsMCKkxfrXeTxHJZST.CnHMibYUuEiICHVOgczIzulryavH == null)
					{
						return null;
					}
					global::vvqWcefspViLvBkIonynvYaRLpFT<CustomControllerMap> vvqWcefspViLvBkIonynvYaRLpFT2 = new global::vvqWcefspViLvBkIonynvYaRLpFT<CustomControllerMap>(P_0.id);
					for (int i = 0; i < TNiSWoykewpsMCKkxfrXeTxHJZST.CnHMibYUuEiICHVOgczIzulryavH.Length; i++)
					{
						qCTfaRHMyGAlzZVpcnVPApCYUJkO(P_0, vvqWcefspViLvBkIonynvYaRLpFT2, TNiSWoykewpsMCKkxfrXeTxHJZST.CnHMibYUuEiICHVOgczIzulryavH[i], P_1);
					}
					if (vvqWcefspViLvBkIonynvYaRLpFT2.cLFOTXBjzlMfxMSeRWBhGFJkuhvb() == 0)
					{
						return null;
					}
					return vvqWcefspViLvBkIonynvYaRLpFT2;
				}

				private void qCTfaRHMyGAlzZVpcnVPApCYUJkO(CustomController P_0, global::vvqWcefspViLvBkIonynvYaRLpFT<CustomControllerMap> P_1, cHjmmntdHIjqPzwYHqwnEXRwXGEG P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.HrfRSFyptKGHiJiupViPyNXjDVYB >= 0 && P_2.owtjhdfbLbdJQeOQjiyhelFGHrSMA >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.yfDgYQQnkvFLLsPwIrQTpTtJiskJ(P_2.HrfRSFyptKGHiJiupViPyNXjDVYB, P_0.sourceControllerId, P_2.owtjhdfbLbdJQeOQjiyhelFGHrSMA);
						hgwfRdRoPADdcEgrryWFCEolgFdeA(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.peyhhfqyjAaciFITizTMuKSZhVzr ? BoolOption.True : BoolOption.False);
						}
						P_1.WmLHpxnOQHBjYDImEYJbWAZjtCyP(customControllerMap, boolOption);
					}
				}

				internal void hgwfRdRoPADdcEgrryWFCEolgFdeA(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = NWXgpFxDsMZANkuENTnSKhpLOtmS.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
						P_0.jqLSrLTCddLEpzgJvILfPrtjvnhn(P_1);
					}
				}

				private IList<_0001> BWnssKRVqEEkcBvZXAykaWMZzzDD<_0001>(int P_0) where _0001 : ControllerMap
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = hMYKUbiVXSFgGgJOpMgFRsZUGKGS<_0001>();
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.xHmZixgDkANrStEshDECgdGlDTscb<_0001>();
				}

				private IList<_0001> pFcyhWXwcBwUSjGTMvJwgMmVMBfD<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return hMYKUbiVXSFgGgJOpMgFRsZUGKGS<_0001>().hvjJnZKuRgeBnRejcBjucuBjYccW(P_0)?.iuMldFPvAqBfeiUXQrGwudCQSSbq.xHmZixgDkANrStEshDECgdGlDTscb<_0001>();
				}

				private IList<ControllerMap> jtSvDmTjMCIhHDNFiIoxgbefHeKpA(ControllerType P_0, int P_1)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
				}

				private IList<ControllerMap> pFcyhWXwcBwUSjGTMvJwgMmVMBfD(Controller P_0)
				{
					return jtSvDmTjMCIhHDNFiIoxgbefHeKpA(P_0.type, P_0.id);
				}

				private void qNBqMuMCWegEFEgxaYyKbfSGmrRc(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					sVzDvYkdrVvyRbhXytDfHvRwcKLi(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void VCDmUBKLUyWietfmZBVRnYXyeeUM(Controller P_0, int P_1, int P_2)
				{
					dXieHkjNPHsrJCjqQVWWRESohlLn(P_0, P_1, P_2, BoolOption.Default);
				}

				private void JvLsZLtrWtiZtXhVWwLJsMLMliUc(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					dBejIoLStDfQlAiTUqXMVivwKDeR(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void dwIAHUAlONpZujpAwhZZrSxbyBxg(Controller P_0, string P_1, string P_2)
				{
					vTynPfCmKZzqsQgsmmpPBDZiGiOS(P_0, P_1, P_2, BoolOption.Default);
				}

				private void sVzDvYkdrVvyRbhXytDfHvRwcKLi(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num >= 0)
					{
						Controller controller = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD;
						ControllerMap controllerMap = ReInput.UserData.OeYxQTPxhjuQLWoMvQabxOxprQcK(controller, P_2, P_3);
						udJunQFQkBoMThJimctryITPELLS(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void dXieHkjNPHsrJCjqQVWWRESohlLn(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					sVzDvYkdrVvyRbhXytDfHvRwcKLi(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void dBejIoLStDfQlAiTUqXMVivwKDeR(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						sVzDvYkdrVvyRbhXytDfHvRwcKLi(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void vTynPfCmKZzqsQgsmmpPBDZiGiOS(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					dBejIoLStDfQlAiTUqXMVivwKDeR(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void vERBdufdmzXLOuopqWcSAMChlsXW(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0.type);
						int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_0.id);
						if (num >= 0)
						{
							hgwfRdRoPADdcEgrryWFCEolgFdeA(P_0, P_1);
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.GzPHotUelFdfIAjjlmwFsRqukYuZ(P_1, P_2);
							tqbWFyGEdtCWlQGuUDcAQBOifyAR.Apply();
						}
					}
				}

				private void udJunQFQkBoMThJimctryITPELLS(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						vERBdufdmzXLOuopqWcSAMChlsXW(controller, P_2, P_3);
					}
				}

				private bool eLthPyrNRXOQPTuxkljsMohMenvS(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0).HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.VCNuXHtewMrFgNwrcjRWWguohOtc(P_0);
					if (!controllerMap.qESTfaKFuDWdLXNwHaloUDjbMBOQ(P_2))
					{
						return false;
					}
					udJunQFQkBoMThJimctryITPELLS(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int KtatgQOPCygSvaiGVbUGYJNJFUxEA(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0).HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (eLthPyrNRXOQPTuxkljsMohMenvS(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool lLzahFaBQCwedHtYTXUmrHTvpCrB(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0).HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.VCNuXHtewMrFgNwrcjRWWguohOtc(P_0);
					if (!controllerMap.RKLsmaPAZctazlWBrXTtKsDHpkUC(P_2))
					{
						return false;
					}
					udJunQFQkBoMThJimctryITPELLS(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int GOwRgmnnhSGAMKvUsBqhXIYLeGQF(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0).HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (lLzahFaBQCwedHtYTXUmrHTvpCrB(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void pQbdrrNRqrmxSPCQmcZxFdYfoOReb(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num >= 0)
					{
						Controller controller = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD;
						ControllerMap controllerMap = ControllerMap.yhcDnHWEcCKyYWCiWEaejISeqkXh(controller, P_2, P_3);
						udJunQFQkBoMThJimctryITPELLS(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void NqzAsFEbRXLuumtuVCFHCcnIRZWqA(Controller P_0, int P_1, int P_2)
				{
					pQbdrrNRqrmxSPCQmcZxFdYfoOReb(P_0.type, P_0.id, P_1, P_2);
				}

				private void vtLFtQEFIOgglehNnTaGcMODvTZmc(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						pQbdrrNRqrmxSPCQmcZxFdYfoOReb(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void bipASSZArAdSnwTrsxUfjbxDxSyF(Controller P_0, string P_1, string P_2)
				{
					vtLFtQEFIOgglehNnTaGcMODvTZmc(P_0.type, P_0.id, P_1, P_2);
				}

				private void KkzIkfFvFaBBbvozJpAoPqtfFDYm(ControllerType P_0, int P_1, int P_2)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num >= 0)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.dAQsyazdcjePZdDiyVkNxdaEBCEw(P_2);
					}
				}

				private void kPaCCLbTOpoZRSrYNCKFLZBxhwXz(Controller P_0, int P_1)
				{
					KkzIkfFvFaBBbvozJpAoPqtfFDYm(P_0.type, P_0.id, P_1);
				}

				private void lRZdDVnKcoqVLrVxNsSGoyUkoCIh(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num >= 0)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.jufQhhDyVvUqswXIYFjxoChuipqm(P_2);
					}
				}

				private void PzhlySIyfRLWSOtybEbMrwNfnOWl(Controller P_0, ControllerMap P_1)
				{
					KkzIkfFvFaBBbvozJpAoPqtfFDYm(P_0.type, P_0.id, P_1.id);
				}

				private void KHBrUHbmJqVWoBmrCSAnWFtCxbxn(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num >= 0)
					{
						xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.mREkhHOoMFnpKkDVewLkxiSTMdOp(P_2, P_3);
					}
				}

				private void EibyAferWYCaFzifmzrbcbJRisZM(Controller P_0, int P_1, int P_2)
				{
					KHBrUHbmJqVWoBmrCSAnWFtCxbxn(P_0.type, P_0.id, P_1, P_2);
				}

				private void kIkaKwDNkTgHtCYUqpPlCSOkXdHKA(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.mREkhHOoMFnpKkDVewLkxiSTMdOp(mapCategoryId, layoutId);
						}
					}
				}

				private void YlFBewrVJxcaXtpNctQIHmkSdxnH(Controller P_0, string P_1, string P_2)
				{
					kIkaKwDNkTgHtCYUqpPlCSOkXdHKA(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap cqJBFlUTLYcRmYjhOExWrJCSlpYw(ControllerType P_0, int P_1, int P_2)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					return xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.INVFVAGZCWtTcuaCYfycKpoxOyjEb(P_2);
				}

				private ControllerMap VvDpxkSoFYHfwTMNeSgfDmoUeouP(Controller P_0, int P_1)
				{
					return cqJBFlUTLYcRmYjhOExWrJCSlpYw(P_0.type, P_0.id, P_1);
				}

				private ControllerMap tihKshyQeEsuQCbbPOcyWwFLtnZ(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					return xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.YtDMQfqGdAaPehuBCaitgSJGvSuf(P_2, P_3);
				}

				private ControllerMap iLBhvmfQhPlttPrvqQSbtsruhLDuA(Controller P_0, int P_1, int P_2)
				{
					return tihKshyQeEsuQCbbPOcyWwFLtnZ(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap ESYCJJANMCDwDtsWHsEyWkOhIXWS(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return tihKshyQeEsuQCbbPOcyWwFLtnZ(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap lvLGpYBjqOQdcgrfLzXXlJAphcvsA(Controller P_0, string P_1, string P_2)
				{
					return ESYCJJANMCDwDtsWHsEyWkOhIXWS(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap mqkWqAtXrZMtyelaGRKVJDZdBdeI(ControllerType P_0, int P_1, int P_2)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					return xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.XtfgZdEJozGwPpAIbwcOXlFEAqQl(P_2);
				}

				private ControllerMap dGOhLcWlgxwJhSqxFXIbRuAhpjuE(Controller P_0, int P_1)
				{
					return mqkWqAtXrZMtyelaGRKVJDZdBdeI(P_0.type, P_0.id, P_1);
				}

				private ControllerMap SxmZRrfzSbdEUEdjWOAHzgTjvzBi(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return mqkWqAtXrZMtyelaGRKVJDZdBdeI(P_0, P_1, mapCategoryId);
				}

				private ControllerMap ZvUMxrRDPfgnuIhrdfVDmLnxAFclA(Controller P_0, string P_1)
				{
					return SxmZRrfzSbdEUEdjWOAHzgTjvzBi(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] aGLfqtNqfMzPEGgDtuuDModPxZpj(ControllerType P_0)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = 0;
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						num += xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.AenMnPaenKXbTfnmKTHZLLNLsyPr;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; j++)
					{
						BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq;
						for (int k = 0; k < bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr; k++)
						{
							array[num] = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] gaOyrjZEPuhlcsVAldtXsnUXinqd(ControllerType P_0, int P_1, bool P_2)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq;
					for (int i = 0; i < bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr; i++)
					{
						ControllerMap controllerMap = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD;
						list.Add(ControllerMapSaveData.ygxoxFCEHeVEgwJYjlxYBbEQsGlS(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] GzAlMpQHATFylxupNPvpmBoujUWT<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = SVQbmGoCgjXlQooYDoNZCFflMVzP.HVgFfddVfuwcqGWPPbjurndwZjzH<_0001>();
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq;
					for (int i = 0; i < bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr; i++)
					{
						ControllerMap controllerMap = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD;
						list.Add(ControllerMapSaveData.ygxoxFCEHeVEgwJYjlxYBbEQsGlS<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] haiQuDDlMWjIXzCSnHqErNlJHbrC(ControllerType P_0, bool P_1)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq;
						for (int j = 0; j < bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr; j++)
						{
							ControllerMap controllerMap = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).pQefzbMuBblbJGuGRnxcoWyVLFcD;
							list.Add(ControllerMapSaveData.ygxoxFCEHeVEgwJYjlxYBbEQsGlS(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] BpxtbFopXvTGUZVCigwACLQFojJS<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = SVQbmGoCgjXlQooYDoNZCFflMVzP.HVgFfddVfuwcqGWPPbjurndwZjzH<_0001>();
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq;
						for (int j = 0; j < bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr; j++)
						{
							ControllerMap controllerMap = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).pQefzbMuBblbJGuGRnxcoWyVLFcD;
							list.Add(ControllerMapSaveData.ygxoxFCEHeVEgwJYjlxYBbEQsGlS<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int CVGaUqIuxyEoaASPFLVoaaodLQoAb(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return 0;
					}
					return xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.RMmgmgyYADttzCMqapdLJSwiSVfu(P_2, P_3, false);
				}

				private int TixtvGTCmgTggzjmeFFtJUdDDGDF(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return CVGaUqIuxyEoaASPFLVoaaodLQoAb(P_0.type, P_0.id, P_1, P_2);
				}

				private int NIPhEuAAeoannxojyAxyWlBausRd(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return CVGaUqIuxyEoaASPFLVoaaodLQoAb(P_0, P_1, mapCategoryId, P_3);
				}

				private int wPSACbbgzVFasOOESZJdaIqdIvsfA(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return NIPhEuAAeoannxojyAxyWlBausRd(P_0.type, P_0.id, P_1, P_2);
				}

				[IteratorStateMachine(typeof(pRrDhEWypfnmWoSLFxqhcFkCTxBO))]
				private IEnumerable<ControllerMap> TjMdmgbFHVFkZQNptnFmoyFgLQtc(ControllerType P_0, int P_1, int P_2)
				{
					return new pRrDhEWypfnmWoSLFxqhcFkCTxBO(-2)
					{
						oGbbJkoTliDXfuZLXuAXiGIOWCjk = this,
						CwaJTdfvrdVKNChHJxWMsQracdMF = P_0,
						WlMGcdPsYAoCZdIoixmJSnndCmjkA = P_1,
						YjIorXQSXDJxbhnaDRlpCLbvDrcn = P_2
					};
				}

				[IteratorStateMachine(typeof(KGRHAFVLbgEsWeHectVqZGBacQtGA))]
				private IEnumerable<_0001> yYpTQLtwDVRhpJTItTCkWEAJDrWfA<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new KGRHAFVLbgEsWeHectVqZGBacQtGA<_0001>(-2)
					{
						ZezbgqBPVoONhsBBqmMWQdIfqadz = this,
						qhkUdZYQDCmeTWpnUqexnpavHDNW = P_0,
						tlQcCmmAEyodeaHrfsytnDlZjMFb = P_1
					};
				}

				private ActionElementMap uIpPzERhWLLxkxYUHvAoWoyfjmLj(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								ActionElementMap firstButtonMapWithAction = list[j].GetFirstButtonMapWithAction(P_1, P_2);
								if (firstButtonMapWithAction != null)
								{
									return firstButtonMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap RjxXYaVbEgUEwePpVNOeSCVCfzSZ(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return uIpPzERhWLLxkxYUHvAoWoyfjmLj(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(cCIfWuKeGNtvfUmYBSXQkuvCkhwk))]
				private IEnumerable<ActionElementMap> jqIfoOSJuKhlSyQzrGTbVwJPCpuc(ControllerType P_0, int P_1, bool P_2)
				{
					return new cCIfWuKeGNtvfUmYBSXQkuvCkhwk(-2)
					{
						RpdLQZsfCuLREwTtTDnQeQNHPBiE = this,
						MgCCkMqDfcVPNjDkzeSPgZVsiPCkA = P_0,
						vGpzXtlVfDlGCWqfrubWwGiSULdC = P_1,
						LOKFxfgZKUrnixZpBTaLGVAbQZmsA = P_2
					};
				}

				private IEnumerable<ActionElementMap> hldXRIPxrfVGXiAAAjyTAMlNyQMbA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return jqIfoOSJuKhlSyQzrGTbVwJPCpuc(P_0, num, P_2);
				}

				private ActionElementMap ANDGUhqDlAstAmOUeIYjGenKJUid(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return null;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								ActionElementMap firstAxisMapWithAction = (list[j] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_1, P_2);
								if (firstAxisMapWithAction != null)
								{
									return firstAxisMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap pBJiUGuIhLoJxYEhQjgqQyXVSFxX(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return ANDGUhqDlAstAmOUeIYjGenKJUid(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(luaQBHuhhdUKBLkTnxRxDEzPQArr))]
				private IEnumerable<ActionElementMap> ruzGidnEdmBuleRTuQCYtpjpkjTz(ControllerType P_0, int P_1, bool P_2)
				{
					return new luaQBHuhhdUKBLkTnxRxDEzPQArr(-2)
					{
						eAiVcbriRjoKDGcWOFoHoNNmruyo = this,
						ONNawMbfxBXvCUlIOQLKMFovUXJV = P_0,
						BGCsnEzHDEsYSOhEwpjZXFFqFDYaA = P_1,
						vuiFyEDXGccwkngWdfsooOthAEMeb = P_2
					};
				}

				private IEnumerable<ActionElementMap> dlFzDXhybHwBdjgzlUnuUeWiRDTj(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return ruzGidnEdmBuleRTuQCYtpjpkjTz(P_0, num, P_2);
				}

				private ActionElementMap mRtyrxdAHsilLmjajOWLODdBGeLS(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								ActionElementMap firstElementMapWithAction = list[j].GetFirstElementMapWithAction(P_1, P_2);
								if (firstElementMapWithAction != null)
								{
									return firstElementMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap mmZetgJAnMMAQLGsgPTEpZikXYwfA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return mRtyrxdAHsilLmjajOWLODdBGeLS(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(LQCXBhoizUfFWFkPOkOJWTYYlkBm))]
				private IEnumerable<ActionElementMap> HSzbdcAkOQWBLPLyiILUBCtBLJkj(ControllerType P_0, int P_1, bool P_2)
				{
					return new LQCXBhoizUfFWFkPOkOJWTYYlkBm(-2)
					{
						FcnahzKzkDoylBWdYNmAgQGuRDfD = this,
						nRQNYrriSOiAqvXxXGJlOwVtrFlo = P_0,
						KyqFthkIKUEgrDoUqReXJfoVvesr = P_1,
						QFdBSLFLwVKqLXfJjdYMFTmeKleDc = P_2
					};
				}

				private IEnumerable<ActionElementMap> qKgmjKrjUDMvyjVgfPZobJoOnazW(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return HSzbdcAkOQWBLPLyiILUBCtBLJkj(P_0, num, P_2);
				}

				private int dYSABoYXwHbfcjVmGErlYrgOHEOd(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num2; j++)
						{
							BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							int num3 = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.EgnvWttVZzOYqsuCulAEtGHhygvF(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int dotArIqIVMpBOqCShpVWcwsaZdwl(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num2; j++)
						{
							BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							int num3 = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							for (int k = 0; k < num3; k++)
							{
								if (bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.zAdIrIPxfpJpvWgDHYHaQkdADeCG(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int eWdsesreiRiNHVzCIeboElxQZbTH(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int cdDMVOEYEeaEACfRYzOcwBUJJAEg = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
					for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
					{
						XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i);
						int num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
						for (int j = 0; j < num2; j++)
						{
							BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(j).iuMldFPvAqBfeiUXQrGwudCQSSbq;
							int num3 = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.cZhlovFicBbegtZKBDXbQpHySFih(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int KdTjIFjhvqDUleZtWicnEJNNcRXSA(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].EgnvWttVZzOYqsuCulAEtGHhygvF(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int oXEeNIETrrlkJdUcSWHcolbtfKSuA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return KdTjIFjhvqDUleZtWicnEJNNcRXSA(P_0, num, P_2, P_3, P_4);
				}

				private int mjzILeoQQvmYUkfelNiCIXSiyurB(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).zAdIrIPxfpJpvWgDHYHaQkdADeCG(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int oJsqufkkDUZqnkAcqpcfXUDvBdhE(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return mjzILeoQQvmYUkfelNiCIXSiyurB(P_0, num, P_2, P_3, P_4);
				}

				private int cSCikyzlDgFYXyzoQakgcPyPyrBo(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					for (int i = 0; i < xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB; i++)
					{
						IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].cZhlovFicBbegtZKBDXbQpHySFih(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int uWyobDQPVUCaMVLFfEGQvTZjTghU(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_1);
					return cSCikyzlDgFYXyzoQakgcPyPyrBo(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap yvQxEfCZePftBORIKIhtJUiymEAuA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							ActionElementMap firstButtonMapWithAction = list[i].GetFirstButtonMapWithAction(P_2, P_3);
							if (firstButtonMapWithAction != null)
							{
								return firstButtonMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap atGfXmgzdlXTnIQDlHtzGmjhDNnrb(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return yvQxEfCZePftBORIKIhtJUiymEAuA(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(NIHCEeVZcXlEbUWECvqhgzqytuWO))]
				private IEnumerable<ActionElementMap> RkaDHtxjDoCcqgiBHWCxaSlHcVTcb(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new NIHCEeVZcXlEbUWECvqhgzqytuWO(-2)
					{
						AdezkWLZVVIxxozeiByKBUZTLlkb = this,
						PFjHJNwLdmZDAZRcSFIdlORdzGUJ = P_0,
						IMxrHxaqTMFeQBYKOkgiNlkNmrMlA = P_1,
						nfeieQKSmYiqozJpZWkPiKNgNVMxA = P_2,
						XKsejfxVBHHrghrCobLJIPKdAXfnA = P_3
					};
				}

				private IEnumerable<ActionElementMap> sKcRkDnMViLGVFoOZxBSOoUFxzwQ(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return RkaDHtxjDoCcqgiBHWCxaSlHcVTcb(P_0, P_1, num, P_3);
				}

				private ActionElementMap KDQBqJACtNacPSUGtMKNZGlLTiyhA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
					for (int i = 0; i < list.Count; i++)
					{
						if (!(list[i] is ControllerMapWithAxes))
						{
							return null;
						}
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							ActionElementMap firstAxisMapWithAction = (list[i] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_2, P_3);
							if (firstAxisMapWithAction != null)
							{
								return firstAxisMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap OrWAYBCqXgaWXoLsDdcVfmtoVwRBA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return KDQBqJACtNacPSUGtMKNZGlLTiyhA(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(dNVOXyAtkuGqgJwmyhvnemKhZJvx))]
				private IEnumerable<ActionElementMap> JlkLmbDFrxejzHalJqwRgfeIEfdob(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new dNVOXyAtkuGqgJwmyhvnemKhZJvx(-2)
					{
						UOiXBTOMGLFxPAGkZCshInDNrpQUA = this,
						oCraDHjlsXdrmjVuCEngOEVWYjzu = P_0,
						JuQqSNLaGiXxTKjpudWlwFWrcmDJ = P_1,
						bmOxhEUqikAIuPflyHgdjRLTZWIc = P_2,
						ejQxXtWbJpPaHazdwrAwaOXRcHcKA = P_3
					};
				}

				private IEnumerable<ActionElementMap> LWQPnRXqHiLJKhtizJIWCEqAmZwJ(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return JlkLmbDFrxejzHalJqwRgfeIEfdob(P_0, P_1, num, P_3);
				}

				private ActionElementMap aFHDFgUycquHJYKKlTjYhIkRTgzm(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							ActionElementMap firstElementMapWithAction = list[i].GetFirstElementMapWithAction(P_2, P_3);
							if (firstElementMapWithAction != null)
							{
								return firstElementMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap CXEECjCaIDalJbABHtutWQAwWELFA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return aFHDFgUycquHJYKKlTjYhIkRTgzm(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(mOFgnhrUuHxPlKWZAeGdlQhANefW))]
				private IEnumerable<ActionElementMap> LmajwZyxuovYGkESjFvaZAXHBFYd(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new mOFgnhrUuHxPlKWZAeGdlQhANefW(-2)
					{
						TjecKvdEXJBWAUoXMPvZEmdJKHfH = this,
						pMxykNlfgTWMSUpycoHGTusvFZPS = P_0,
						SGeISEFvEhMJzGIZKDFSHZMFKcavA = P_1,
						lzYdIrcnpMAxYemfbfGFDWIAdCoYb = P_2,
						WrWuGUaJLNqntmGyKgKNIETeAePuA = P_3
					};
				}

				private IEnumerable<ActionElementMap> WMiaxwCMaIzjpfLTcPMUoMqrRTef(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return LmajwZyxuovYGkESjFvaZAXHBFYd(P_0, P_1, num, P_3);
				}

				private int zqJviARttpJhdGhdyitdTDhTiAbE(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.EgnvWttVZzOYqsuCulAEtGHhygvF(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int eSBGHchNCpaTRnZqdnHoYAwXyPEA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return zqJviARttpJhdGhdyitdTDhTiAbE(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int NaCZtSzMXQvXXZBZLXYzibFQdYYH(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.zAdIrIPxfpJpvWgDHYHaQkdADeCG(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int XylgNpeGPHxFJsEDmclFpYzGeQTBA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return NaCZtSzMXQvXXZBZLXYzibFQdYYH(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int TSMDbegYSOBQfihepmVqgjRaxRGR(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.HtWvGaTgyVAQoAaAUFaMIkCnEUsO(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).iuMldFPvAqBfeiUXQrGwudCQSSbq.wdPauRHjrIQblVZUuLzuKLqlKgKE;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].cZhlovFicBbegtZKBDXbQpHySFih(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int RlcIOTWGZlqqPqxJVAyaseFwlFll(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
					return TSMDbegYSOBQfihepmVqgjRaxRGR(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap oEmGhkpeeqwadhUKPLoBZKLbqpZu(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					if (P_0 == null)
					{
						return null;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return null;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controller.type);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					for (int i = 0; i < num; i++)
					{
						BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq;
						_ = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
						IList<ControllerMap> list = bpzomrqmbmNinOxWAGGlQTtkPnsX.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.daBPlcrTfpFvPZUhwqVBCZWmbSyH(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				[IteratorStateMachine(typeof(vGsBxclAnWAQhrnqoOqOkqEIIebFA))]
				private IEnumerable<ActionElementMap> VAFQBByRLOsHaQmJODExPeNsjRjS(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new vGsBxclAnWAQhrnqoOqOkqEIIebFA(-2)
					{
						whcFQCHDFEFsPpRGEnbNYNZRvPIpA = this,
						ppvCOchzcooSjsWxVWgCzdNXehiG = P_0,
						vQhgpfisytCExjtUApSuzDCxOKjbb = P_1,
						ZMeuvZUmXmLtudkhKddoHkgNWMJH = P_2,
						HSulRicDQCpgpQUeZrZkKWpphaoG = P_3
					};
				}

				private int ClScpucpYhPmEaISNWBFMetCZXBhA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_0 == null)
					{
						return 0;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return 0;
					}
					XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = oHMEJVxlADgIsblHZLzlGkLDMGmZB.AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controller.type);
					int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).iuMldFPvAqBfeiUXQrGwudCQSSbq;
						_ = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
						IList<ControllerMap> list = bpzomrqmbmNinOxWAGGlQTtkPnsX.wdPauRHjrIQblVZUuLzuKLqlKgKE;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.UlFArbKTYQdEqAtLPNCFxsiTzHnb(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
							}
						}
					}
					return num2;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class mDZTdyVsPDNINFDbReXQLkWvyTME : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pqFFQrIKTQeDuIEXDRqZCVmmlNRMB;

					private ControllerPollingInfo ZOkCGyDlPIkhPRkhWJpCerrCqtZxB;

					private int LSOelNaITAvjcwNtUUesaVconPRY;

					public PollingHelper GAogPhFteIJbRgwOTTwgpzwjeuTS;

					private IList<CustomController> svuzHJeWepkycckyptLnqoqmogOJ;

					private int GfRLCwOlkvfcwITttzcoCrbdKrQYA;

					private int xbhaQoBBLDPDAQJgVkDoitfUKdTN;

					private IEnumerator<ControllerPollingInfo> LsmhbiYjNdtJcGAKDVahcyIVbVzO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZOkCGyDlPIkhPRkhWJpCerrCqtZxB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZOkCGyDlPIkhPRkhWJpCerrCqtZxB;
						}
					}

					[DebuggerHidden]
					public mDZTdyVsPDNINFDbReXQLkWvyTME(int P_0)
					{
						pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = P_0;
						LSOelNaITAvjcwNtUUesaVconPRY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pqFFQrIKTQeDuIEXDRqZCVmmlNRMB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								kpQIkabNlnubmGmjegZkcRfwWIGLA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = pqFFQrIKTQeDuIEXDRqZCVmmlNRMB;
							PollingHelper gAogPhFteIJbRgwOTTwgpzwjeuTS = GAogPhFteIJbRgwOTTwgpzwjeuTS;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = -3;
								goto IL_00c5;
							}
							pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = -1;
							svuzHJeWepkycckyptLnqoqmogOJ = gAogPhFteIJbRgwOTTwgpzwjeuTS.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							GfRLCwOlkvfcwITttzcoCrbdKrQYA = svuzHJeWepkycckyptLnqoqmogOJ.Count;
							xbhaQoBBLDPDAQJgVkDoitfUKdTN = 0;
							goto IL_00f1;
							IL_00c5:
							if (LsmhbiYjNdtJcGAKDVahcyIVbVzO.MoveNext())
							{
								ControllerPollingInfo current = LsmhbiYjNdtJcGAKDVahcyIVbVzO.Current;
								ControllerPollingInfo zOkCGyDlPIkhPRkhWJpCerrCqtZxB = new ControllerPollingInfo(current);
								zOkCGyDlPIkhPRkhWJpCerrCqtZxB.playerId = gAogPhFteIJbRgwOTTwgpzwjeuTS.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								ZOkCGyDlPIkhPRkhWJpCerrCqtZxB = zOkCGyDlPIkhPRkhWJpCerrCqtZxB;
								pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = 1;
								return true;
							}
							kpQIkabNlnubmGmjegZkcRfwWIGLA();
							LsmhbiYjNdtJcGAKDVahcyIVbVzO = null;
							xbhaQoBBLDPDAQJgVkDoitfUKdTN++;
							goto IL_00f1;
							IL_00f1:
							if (xbhaQoBBLDPDAQJgVkDoitfUKdTN < GfRLCwOlkvfcwITttzcoCrbdKrQYA)
							{
								LsmhbiYjNdtJcGAKDVahcyIVbVzO = svuzHJeWepkycckyptLnqoqmogOJ[xbhaQoBBLDPDAQJgVkDoitfUKdTN].PollForAllAxes().GetEnumerator();
								pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = -3;
								goto IL_00c5;
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

					private void kpQIkabNlnubmGmjegZkcRfwWIGLA()
					{
						pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = -1;
						if (LsmhbiYjNdtJcGAKDVahcyIVbVzO != null)
						{
							LsmhbiYjNdtJcGAKDVahcyIVbVzO.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mDZTdyVsPDNINFDbReXQLkWvyTME mDZTdyVsPDNINFDbReXQLkWvyTME2;
						if (pqFFQrIKTQeDuIEXDRqZCVmmlNRMB == -2 && LSOelNaITAvjcwNtUUesaVconPRY == Environment.CurrentManagedThreadId)
						{
							pqFFQrIKTQeDuIEXDRqZCVmmlNRMB = 0;
							mDZTdyVsPDNINFDbReXQLkWvyTME2 = this;
						}
						else
						{
							mDZTdyVsPDNINFDbReXQLkWvyTME2 = new mDZTdyVsPDNINFDbReXQLkWvyTME(0);
							mDZTdyVsPDNINFDbReXQLkWvyTME2.GAogPhFteIJbRgwOTTwgpzwjeuTS = GAogPhFteIJbRgwOTTwgpzwjeuTS;
						}
						return mDZTdyVsPDNINFDbReXQLkWvyTME2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IBoAtbCcohWSxhwiUgtKWJlqFfSD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qZOPOMikTBMSEIfybcfIIlZWEwJIA;

					private ControllerPollingInfo tdpJtQgvDFwxjtQwRCpZTZTQDoxx;

					private int xativREczfloVbrxnuwcgkBhcCWW;

					public PollingHelper ESDLiDuzAdVPSxslEoVTTpLVVOwJ;

					private IList<CustomController> ouMMIJdRBwrIRPUFpbAUgvRCCwGn;

					private int YSnPvUZBWtwcZETyclqbkdwpMnBQ;

					private int uaqaAyHkRBKhJvDRxnxzSbGUkJZNA;

					private IEnumerator<ControllerPollingInfo> VfIggkmHDOeRRIYlszNcGecfaARbb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tdpJtQgvDFwxjtQwRCpZTZTQDoxx;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tdpJtQgvDFwxjtQwRCpZTZTQDoxx;
						}
					}

					[DebuggerHidden]
					public IBoAtbCcohWSxhwiUgtKWJlqFfSD(int P_0)
					{
						qZOPOMikTBMSEIfybcfIIlZWEwJIA = P_0;
						xativREczfloVbrxnuwcgkBhcCWW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qZOPOMikTBMSEIfybcfIIlZWEwJIA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								uVhSoEJSPmHrbcBiBoRMXjnpnDRC();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = qZOPOMikTBMSEIfybcfIIlZWEwJIA;
							PollingHelper eSDLiDuzAdVPSxslEoVTTpLVVOwJ = ESDLiDuzAdVPSxslEoVTTpLVVOwJ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qZOPOMikTBMSEIfybcfIIlZWEwJIA = -3;
								goto IL_00c5;
							}
							qZOPOMikTBMSEIfybcfIIlZWEwJIA = -1;
							ouMMIJdRBwrIRPUFpbAUgvRCCwGn = eSDLiDuzAdVPSxslEoVTTpLVVOwJ.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							YSnPvUZBWtwcZETyclqbkdwpMnBQ = ouMMIJdRBwrIRPUFpbAUgvRCCwGn.Count;
							uaqaAyHkRBKhJvDRxnxzSbGUkJZNA = 0;
							goto IL_00f1;
							IL_00c5:
							if (VfIggkmHDOeRRIYlszNcGecfaARbb.MoveNext())
							{
								ControllerPollingInfo current = VfIggkmHDOeRRIYlszNcGecfaARbb.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = eSDLiDuzAdVPSxslEoVTTpLVVOwJ.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								tdpJtQgvDFwxjtQwRCpZTZTQDoxx = controllerPollingInfo;
								qZOPOMikTBMSEIfybcfIIlZWEwJIA = 1;
								return true;
							}
							uVhSoEJSPmHrbcBiBoRMXjnpnDRC();
							VfIggkmHDOeRRIYlszNcGecfaARbb = null;
							uaqaAyHkRBKhJvDRxnxzSbGUkJZNA++;
							goto IL_00f1;
							IL_00f1:
							if (uaqaAyHkRBKhJvDRxnxzSbGUkJZNA < YSnPvUZBWtwcZETyclqbkdwpMnBQ)
							{
								VfIggkmHDOeRRIYlszNcGecfaARbb = ouMMIJdRBwrIRPUFpbAUgvRCCwGn[uaqaAyHkRBKhJvDRxnxzSbGUkJZNA].PollForAllButtons().GetEnumerator();
								qZOPOMikTBMSEIfybcfIIlZWEwJIA = -3;
								goto IL_00c5;
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

					private void uVhSoEJSPmHrbcBiBoRMXjnpnDRC()
					{
						qZOPOMikTBMSEIfybcfIIlZWEwJIA = -1;
						if (VfIggkmHDOeRRIYlszNcGecfaARbb != null)
						{
							VfIggkmHDOeRRIYlszNcGecfaARbb.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						IBoAtbCcohWSxhwiUgtKWJlqFfSD boAtbCcohWSxhwiUgtKWJlqFfSD;
						if (qZOPOMikTBMSEIfybcfIIlZWEwJIA == -2 && xativREczfloVbrxnuwcgkBhcCWW == Environment.CurrentManagedThreadId)
						{
							qZOPOMikTBMSEIfybcfIIlZWEwJIA = 0;
							boAtbCcohWSxhwiUgtKWJlqFfSD = this;
						}
						else
						{
							boAtbCcohWSxhwiUgtKWJlqFfSD = new IBoAtbCcohWSxhwiUgtKWJlqFfSD(0);
							boAtbCcohWSxhwiUgtKWJlqFfSD.ESDLiDuzAdVPSxslEoVTTpLVVOwJ = ESDLiDuzAdVPSxslEoVTTpLVVOwJ;
						}
						return boAtbCcohWSxhwiUgtKWJlqFfSD;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class BeIxOPxDAiWKCPTNVqFoVannihHeA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int AePlUlETheSfTrXnRhPKhlRMrmug;

					private ControllerPollingInfo PvFkgWOwsLIejqlvZezkBMcXGqPX;

					private int PFnwJINnjVjbgIwvlmsMlXxlXYPW;

					public PollingHelper LeQvfcdgqwfdTQqlzCIPDxhMCGoR;

					private IList<CustomController> aLhFEzbHiRqacxgvhvuIFsMWjmIJA;

					private int MmVDTRDLgVXedaUEuUIhwdcHJup;

					private int wzCTOKkojUbklApWzhOSZSdTrhVsA;

					private IEnumerator<ControllerPollingInfo> DyqxgTtPtRHxebXgfQpNERUBYRvH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PvFkgWOwsLIejqlvZezkBMcXGqPX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PvFkgWOwsLIejqlvZezkBMcXGqPX;
						}
					}

					[DebuggerHidden]
					public BeIxOPxDAiWKCPTNVqFoVannihHeA(int P_0)
					{
						AePlUlETheSfTrXnRhPKhlRMrmug = P_0;
						PFnwJINnjVjbgIwvlmsMlXxlXYPW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int aePlUlETheSfTrXnRhPKhlRMrmug = AePlUlETheSfTrXnRhPKhlRMrmug;
						if (aePlUlETheSfTrXnRhPKhlRMrmug == -3 || aePlUlETheSfTrXnRhPKhlRMrmug == 1)
						{
							try
							{
							}
							finally
							{
								SbhKTMacJhlsWzfzvohsndKPsmfd();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int aePlUlETheSfTrXnRhPKhlRMrmug = AePlUlETheSfTrXnRhPKhlRMrmug;
							PollingHelper leQvfcdgqwfdTQqlzCIPDxhMCGoR = LeQvfcdgqwfdTQqlzCIPDxhMCGoR;
							if (aePlUlETheSfTrXnRhPKhlRMrmug != 0)
							{
								if (aePlUlETheSfTrXnRhPKhlRMrmug != 1)
								{
									return false;
								}
								AePlUlETheSfTrXnRhPKhlRMrmug = -3;
								goto IL_00c5;
							}
							AePlUlETheSfTrXnRhPKhlRMrmug = -1;
							aLhFEzbHiRqacxgvhvuIFsMWjmIJA = leQvfcdgqwfdTQqlzCIPDxhMCGoR.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							MmVDTRDLgVXedaUEuUIhwdcHJup = aLhFEzbHiRqacxgvhvuIFsMWjmIJA.Count;
							wzCTOKkojUbklApWzhOSZSdTrhVsA = 0;
							goto IL_00f1;
							IL_00c5:
							if (DyqxgTtPtRHxebXgfQpNERUBYRvH.MoveNext())
							{
								ControllerPollingInfo current = DyqxgTtPtRHxebXgfQpNERUBYRvH.Current;
								ControllerPollingInfo pvFkgWOwsLIejqlvZezkBMcXGqPX = new ControllerPollingInfo(current);
								pvFkgWOwsLIejqlvZezkBMcXGqPX.playerId = leQvfcdgqwfdTQqlzCIPDxhMCGoR.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								PvFkgWOwsLIejqlvZezkBMcXGqPX = pvFkgWOwsLIejqlvZezkBMcXGqPX;
								AePlUlETheSfTrXnRhPKhlRMrmug = 1;
								return true;
							}
							SbhKTMacJhlsWzfzvohsndKPsmfd();
							DyqxgTtPtRHxebXgfQpNERUBYRvH = null;
							wzCTOKkojUbklApWzhOSZSdTrhVsA++;
							goto IL_00f1;
							IL_00f1:
							if (wzCTOKkojUbklApWzhOSZSdTrhVsA < MmVDTRDLgVXedaUEuUIhwdcHJup)
							{
								DyqxgTtPtRHxebXgfQpNERUBYRvH = aLhFEzbHiRqacxgvhvuIFsMWjmIJA[wzCTOKkojUbklApWzhOSZSdTrhVsA].PollForAllButtonsDown().GetEnumerator();
								AePlUlETheSfTrXnRhPKhlRMrmug = -3;
								goto IL_00c5;
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

					private void SbhKTMacJhlsWzfzvohsndKPsmfd()
					{
						AePlUlETheSfTrXnRhPKhlRMrmug = -1;
						if (DyqxgTtPtRHxebXgfQpNERUBYRvH != null)
						{
							DyqxgTtPtRHxebXgfQpNERUBYRvH.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						BeIxOPxDAiWKCPTNVqFoVannihHeA beIxOPxDAiWKCPTNVqFoVannihHeA;
						if (AePlUlETheSfTrXnRhPKhlRMrmug == -2 && PFnwJINnjVjbgIwvlmsMlXxlXYPW == Environment.CurrentManagedThreadId)
						{
							AePlUlETheSfTrXnRhPKhlRMrmug = 0;
							beIxOPxDAiWKCPTNVqFoVannihHeA = this;
						}
						else
						{
							beIxOPxDAiWKCPTNVqFoVannihHeA = new BeIxOPxDAiWKCPTNVqFoVannihHeA(0);
							beIxOPxDAiWKCPTNVqFoVannihHeA.LeQvfcdgqwfdTQqlzCIPDxhMCGoR = LeQvfcdgqwfdTQqlzCIPDxhMCGoR;
						}
						return beIxOPxDAiWKCPTNVqFoVannihHeA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class meohdhlcdnHcVQYwmImlyDKDxteK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int txDkyRDoMcUGjWTOfZCaVZOrxGxb;

					private ControllerPollingInfo GCYsTTXFaJMfMgphRgORgelKEofB;

					private int ivgSLQOmLXIkXexdVHhRiaUxeoxD;

					public PollingHelper YoikQoVCwUiLhZGTHvLBiHvOxDb;

					private IList<CustomController> LisxfsEsaKldZsuTBBXJnCwWeQwiA;

					private int lILboyGMwkXUCJrOxXuYawRKyGmlA;

					private int ijBbTvkBoDkBoljpFluQjgpenNRAb;

					private IEnumerator<ControllerPollingInfo> rtduSmlbOMpSfTPtDLghiwhQAmiG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GCYsTTXFaJMfMgphRgORgelKEofB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GCYsTTXFaJMfMgphRgORgelKEofB;
						}
					}

					[DebuggerHidden]
					public meohdhlcdnHcVQYwmImlyDKDxteK(int P_0)
					{
						txDkyRDoMcUGjWTOfZCaVZOrxGxb = P_0;
						ivgSLQOmLXIkXexdVHhRiaUxeoxD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = txDkyRDoMcUGjWTOfZCaVZOrxGxb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								oCYHmycGkPYNTrnFRJZWJngIExCWA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = txDkyRDoMcUGjWTOfZCaVZOrxGxb;
							PollingHelper yoikQoVCwUiLhZGTHvLBiHvOxDb = YoikQoVCwUiLhZGTHvLBiHvOxDb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								txDkyRDoMcUGjWTOfZCaVZOrxGxb = -3;
								goto IL_00c5;
							}
							txDkyRDoMcUGjWTOfZCaVZOrxGxb = -1;
							LisxfsEsaKldZsuTBBXJnCwWeQwiA = yoikQoVCwUiLhZGTHvLBiHvOxDb.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							lILboyGMwkXUCJrOxXuYawRKyGmlA = LisxfsEsaKldZsuTBBXJnCwWeQwiA.Count;
							ijBbTvkBoDkBoljpFluQjgpenNRAb = 0;
							goto IL_00f1;
							IL_00c5:
							if (rtduSmlbOMpSfTPtDLghiwhQAmiG.MoveNext())
							{
								ControllerPollingInfo current = rtduSmlbOMpSfTPtDLghiwhQAmiG.Current;
								ControllerPollingInfo gCYsTTXFaJMfMgphRgORgelKEofB = new ControllerPollingInfo(current);
								gCYsTTXFaJMfMgphRgORgelKEofB.playerId = yoikQoVCwUiLhZGTHvLBiHvOxDb.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								GCYsTTXFaJMfMgphRgORgelKEofB = gCYsTTXFaJMfMgphRgORgelKEofB;
								txDkyRDoMcUGjWTOfZCaVZOrxGxb = 1;
								return true;
							}
							oCYHmycGkPYNTrnFRJZWJngIExCWA();
							rtduSmlbOMpSfTPtDLghiwhQAmiG = null;
							ijBbTvkBoDkBoljpFluQjgpenNRAb++;
							goto IL_00f1;
							IL_00f1:
							if (ijBbTvkBoDkBoljpFluQjgpenNRAb < lILboyGMwkXUCJrOxXuYawRKyGmlA)
							{
								rtduSmlbOMpSfTPtDLghiwhQAmiG = LisxfsEsaKldZsuTBBXJnCwWeQwiA[ijBbTvkBoDkBoljpFluQjgpenNRAb].PollForAllElements().GetEnumerator();
								txDkyRDoMcUGjWTOfZCaVZOrxGxb = -3;
								goto IL_00c5;
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

					private void oCYHmycGkPYNTrnFRJZWJngIExCWA()
					{
						txDkyRDoMcUGjWTOfZCaVZOrxGxb = -1;
						if (rtduSmlbOMpSfTPtDLghiwhQAmiG != null)
						{
							rtduSmlbOMpSfTPtDLghiwhQAmiG.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						meohdhlcdnHcVQYwmImlyDKDxteK meohdhlcdnHcVQYwmImlyDKDxteK2;
						if (txDkyRDoMcUGjWTOfZCaVZOrxGxb == -2 && ivgSLQOmLXIkXexdVHhRiaUxeoxD == Environment.CurrentManagedThreadId)
						{
							txDkyRDoMcUGjWTOfZCaVZOrxGxb = 0;
							meohdhlcdnHcVQYwmImlyDKDxteK2 = this;
						}
						else
						{
							meohdhlcdnHcVQYwmImlyDKDxteK2 = new meohdhlcdnHcVQYwmImlyDKDxteK(0);
							meohdhlcdnHcVQYwmImlyDKDxteK2.YoikQoVCwUiLhZGTHvLBiHvOxDb = YoikQoVCwUiLhZGTHvLBiHvOxDb;
						}
						return meohdhlcdnHcVQYwmImlyDKDxteK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xfWOQvGuOhTIikMhkoVZXzKZqVHe : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int dtBwBxQnowZBWEGiFteqqNnvTgTb;

					private ControllerPollingInfo BfHbFHjLFSERGNhlPccZJpkwVgMPA;

					private int mQLuoReCRThURWmLueIwLWvkjDlc;

					public PollingHelper WFFTnKnjjmnUodWCKmOxjEvxXTdf;

					private IList<CustomController> EQyfZdjPLTSnawahbEIVaPlHsGpvA;

					private int eijLrNmWlnJmvYmElhGlxCGdeApY;

					private int DEkBskDErbeseetSmNEHGOyeUZtKc;

					private IEnumerator<ControllerPollingInfo> apReVXWAvAbGbGynyoDXvVYFHvyq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BfHbFHjLFSERGNhlPccZJpkwVgMPA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BfHbFHjLFSERGNhlPccZJpkwVgMPA;
						}
					}

					[DebuggerHidden]
					public xfWOQvGuOhTIikMhkoVZXzKZqVHe(int P_0)
					{
						dtBwBxQnowZBWEGiFteqqNnvTgTb = P_0;
						mQLuoReCRThURWmLueIwLWvkjDlc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dtBwBxQnowZBWEGiFteqqNnvTgTb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								yHIUzdwThRrFNHMIiwflZkLhdRwJA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = dtBwBxQnowZBWEGiFteqqNnvTgTb;
							PollingHelper wFFTnKnjjmnUodWCKmOxjEvxXTdf = WFFTnKnjjmnUodWCKmOxjEvxXTdf;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dtBwBxQnowZBWEGiFteqqNnvTgTb = -3;
								goto IL_00c5;
							}
							dtBwBxQnowZBWEGiFteqqNnvTgTb = -1;
							EQyfZdjPLTSnawahbEIVaPlHsGpvA = wFFTnKnjjmnUodWCKmOxjEvxXTdf.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							eijLrNmWlnJmvYmElhGlxCGdeApY = EQyfZdjPLTSnawahbEIVaPlHsGpvA.Count;
							DEkBskDErbeseetSmNEHGOyeUZtKc = 0;
							goto IL_00f1;
							IL_00c5:
							if (apReVXWAvAbGbGynyoDXvVYFHvyq.MoveNext())
							{
								ControllerPollingInfo current = apReVXWAvAbGbGynyoDXvVYFHvyq.Current;
								ControllerPollingInfo bfHbFHjLFSERGNhlPccZJpkwVgMPA = new ControllerPollingInfo(current);
								bfHbFHjLFSERGNhlPccZJpkwVgMPA.playerId = wFFTnKnjjmnUodWCKmOxjEvxXTdf.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								BfHbFHjLFSERGNhlPccZJpkwVgMPA = bfHbFHjLFSERGNhlPccZJpkwVgMPA;
								dtBwBxQnowZBWEGiFteqqNnvTgTb = 1;
								return true;
							}
							yHIUzdwThRrFNHMIiwflZkLhdRwJA();
							apReVXWAvAbGbGynyoDXvVYFHvyq = null;
							DEkBskDErbeseetSmNEHGOyeUZtKc++;
							goto IL_00f1;
							IL_00f1:
							if (DEkBskDErbeseetSmNEHGOyeUZtKc < eijLrNmWlnJmvYmElhGlxCGdeApY)
							{
								apReVXWAvAbGbGynyoDXvVYFHvyq = EQyfZdjPLTSnawahbEIVaPlHsGpvA[DEkBskDErbeseetSmNEHGOyeUZtKc].PollForAllElementsDown().GetEnumerator();
								dtBwBxQnowZBWEGiFteqqNnvTgTb = -3;
								goto IL_00c5;
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

					private void yHIUzdwThRrFNHMIiwflZkLhdRwJA()
					{
						dtBwBxQnowZBWEGiFteqqNnvTgTb = -1;
						if (apReVXWAvAbGbGynyoDXvVYFHvyq != null)
						{
							apReVXWAvAbGbGynyoDXvVYFHvyq.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						xfWOQvGuOhTIikMhkoVZXzKZqVHe xfWOQvGuOhTIikMhkoVZXzKZqVHe2;
						if (dtBwBxQnowZBWEGiFteqqNnvTgTb == -2 && mQLuoReCRThURWmLueIwLWvkjDlc == Environment.CurrentManagedThreadId)
						{
							dtBwBxQnowZBWEGiFteqqNnvTgTb = 0;
							xfWOQvGuOhTIikMhkoVZXzKZqVHe2 = this;
						}
						else
						{
							xfWOQvGuOhTIikMhkoVZXzKZqVHe2 = new xfWOQvGuOhTIikMhkoVZXzKZqVHe(0);
							xfWOQvGuOhTIikMhkoVZXzKZqVHe2.WFFTnKnjjmnUodWCKmOxjEvxXTdf = WFFTnKnjjmnUodWCKmOxjEvxXTdf;
						}
						return xfWOQvGuOhTIikMhkoVZXzKZqVHe2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class hOyykamskuEiribcCWCFsqUcoDwd : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pxpecSFgCtGDKESazZrvbKDxRQAHA;

					private ControllerPollingInfo CYvkGkVbzMuUqKNfJodMfqwmfLZm;

					private int ElYbXhGlRjnoKczVNFxkzyFurPHhA;

					public PollingHelper OBfbHufbKdIhLJnuUNVhoHdJEzFF;

					private IList<Joystick> rWLydCbkazItnHXIrpPUUPyNlZrz;

					private int vbgTjfKUEtcybOqoNHCurVJUsHpJ;

					private int IlUnhTSXNuDoWUWnwKZMxSmOtsZx;

					private IEnumerator<ControllerPollingInfo> rTshpAmhDNaaOhuYJkStbdUZvScFA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return CYvkGkVbzMuUqKNfJodMfqwmfLZm;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CYvkGkVbzMuUqKNfJodMfqwmfLZm;
						}
					}

					[DebuggerHidden]
					public hOyykamskuEiribcCWCFsqUcoDwd(int P_0)
					{
						pxpecSFgCtGDKESazZrvbKDxRQAHA = P_0;
						ElYbXhGlRjnoKczVNFxkzyFurPHhA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pxpecSFgCtGDKESazZrvbKDxRQAHA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								wtYeYZuWArASfyVXxrwTKgcMBaej();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = pxpecSFgCtGDKESazZrvbKDxRQAHA;
							PollingHelper oBfbHufbKdIhLJnuUNVhoHdJEzFF = OBfbHufbKdIhLJnuUNVhoHdJEzFF;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pxpecSFgCtGDKESazZrvbKDxRQAHA = -3;
								goto IL_00c5;
							}
							pxpecSFgCtGDKESazZrvbKDxRQAHA = -1;
							rWLydCbkazItnHXIrpPUUPyNlZrz = oBfbHufbKdIhLJnuUNVhoHdJEzFF.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							vbgTjfKUEtcybOqoNHCurVJUsHpJ = rWLydCbkazItnHXIrpPUUPyNlZrz.Count;
							IlUnhTSXNuDoWUWnwKZMxSmOtsZx = 0;
							goto IL_00f1;
							IL_00c5:
							if (rTshpAmhDNaaOhuYJkStbdUZvScFA.MoveNext())
							{
								ControllerPollingInfo current = rTshpAmhDNaaOhuYJkStbdUZvScFA.Current;
								ControllerPollingInfo cYvkGkVbzMuUqKNfJodMfqwmfLZm = new ControllerPollingInfo(current);
								cYvkGkVbzMuUqKNfJodMfqwmfLZm.playerId = oBfbHufbKdIhLJnuUNVhoHdJEzFF.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								CYvkGkVbzMuUqKNfJodMfqwmfLZm = cYvkGkVbzMuUqKNfJodMfqwmfLZm;
								pxpecSFgCtGDKESazZrvbKDxRQAHA = 1;
								return true;
							}
							wtYeYZuWArASfyVXxrwTKgcMBaej();
							rTshpAmhDNaaOhuYJkStbdUZvScFA = null;
							IlUnhTSXNuDoWUWnwKZMxSmOtsZx++;
							goto IL_00f1;
							IL_00f1:
							if (IlUnhTSXNuDoWUWnwKZMxSmOtsZx < vbgTjfKUEtcybOqoNHCurVJUsHpJ)
							{
								rTshpAmhDNaaOhuYJkStbdUZvScFA = rWLydCbkazItnHXIrpPUUPyNlZrz[IlUnhTSXNuDoWUWnwKZMxSmOtsZx].PollForAllAxes().GetEnumerator();
								pxpecSFgCtGDKESazZrvbKDxRQAHA = -3;
								goto IL_00c5;
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

					private void wtYeYZuWArASfyVXxrwTKgcMBaej()
					{
						pxpecSFgCtGDKESazZrvbKDxRQAHA = -1;
						if (rTshpAmhDNaaOhuYJkStbdUZvScFA != null)
						{
							rTshpAmhDNaaOhuYJkStbdUZvScFA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						hOyykamskuEiribcCWCFsqUcoDwd hOyykamskuEiribcCWCFsqUcoDwd2;
						if (pxpecSFgCtGDKESazZrvbKDxRQAHA == -2 && ElYbXhGlRjnoKczVNFxkzyFurPHhA == Environment.CurrentManagedThreadId)
						{
							pxpecSFgCtGDKESazZrvbKDxRQAHA = 0;
							hOyykamskuEiribcCWCFsqUcoDwd2 = this;
						}
						else
						{
							hOyykamskuEiribcCWCFsqUcoDwd2 = new hOyykamskuEiribcCWCFsqUcoDwd(0);
							hOyykamskuEiribcCWCFsqUcoDwd2.OBfbHufbKdIhLJnuUNVhoHdJEzFF = OBfbHufbKdIhLJnuUNVhoHdJEzFF;
						}
						return hOyykamskuEiribcCWCFsqUcoDwd2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class BrEbtGUPgVNwAqFRYoyxgPRvGvZT : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HnMAUWcpSRQyNjKuMvVSuSwpEVPiA;

					private ControllerPollingInfo KTswPKdFtcZgEALfhWYpbLJgByUb;

					private int JyuGbzZvLSHqrMuiThFcWTuiusQy;

					public PollingHelper iPHELmBtBoYPjZckPFNmiTbBCMcEA;

					private IList<Joystick> gfYMMUAePSwLVxHLnaIYEkktflEn;

					private int JUWteZAqRMRcitcHgJNErImTXRUw;

					private int HFHiAkTmjwXdHUggWAVMEjvncqdK;

					private IEnumerator<ControllerPollingInfo> TkFEVHdbGLBsXAsZnjSdShcxSTwy;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KTswPKdFtcZgEALfhWYpbLJgByUb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KTswPKdFtcZgEALfhWYpbLJgByUb;
						}
					}

					[DebuggerHidden]
					public BrEbtGUPgVNwAqFRYoyxgPRvGvZT(int P_0)
					{
						HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = P_0;
						JyuGbzZvLSHqrMuiThFcWTuiusQy = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hnMAUWcpSRQyNjKuMvVSuSwpEVPiA = HnMAUWcpSRQyNjKuMvVSuSwpEVPiA;
						if (hnMAUWcpSRQyNjKuMvVSuSwpEVPiA == -3 || hnMAUWcpSRQyNjKuMvVSuSwpEVPiA == 1)
						{
							try
							{
							}
							finally
							{
								cUcHEvGPpjMJuJXMLfbjzcYfcOHE();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int hnMAUWcpSRQyNjKuMvVSuSwpEVPiA = HnMAUWcpSRQyNjKuMvVSuSwpEVPiA;
							PollingHelper pollingHelper = iPHELmBtBoYPjZckPFNmiTbBCMcEA;
							if (hnMAUWcpSRQyNjKuMvVSuSwpEVPiA != 0)
							{
								if (hnMAUWcpSRQyNjKuMvVSuSwpEVPiA != 1)
								{
									return false;
								}
								HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = -3;
								goto IL_00c5;
							}
							HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = -1;
							gfYMMUAePSwLVxHLnaIYEkktflEn = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							JUWteZAqRMRcitcHgJNErImTXRUw = gfYMMUAePSwLVxHLnaIYEkktflEn.Count;
							HFHiAkTmjwXdHUggWAVMEjvncqdK = 0;
							goto IL_00f1;
							IL_00c5:
							if (TkFEVHdbGLBsXAsZnjSdShcxSTwy.MoveNext())
							{
								ControllerPollingInfo current = TkFEVHdbGLBsXAsZnjSdShcxSTwy.Current;
								ControllerPollingInfo kTswPKdFtcZgEALfhWYpbLJgByUb = new ControllerPollingInfo(current);
								kTswPKdFtcZgEALfhWYpbLJgByUb.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								KTswPKdFtcZgEALfhWYpbLJgByUb = kTswPKdFtcZgEALfhWYpbLJgByUb;
								HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = 1;
								return true;
							}
							cUcHEvGPpjMJuJXMLfbjzcYfcOHE();
							TkFEVHdbGLBsXAsZnjSdShcxSTwy = null;
							HFHiAkTmjwXdHUggWAVMEjvncqdK++;
							goto IL_00f1;
							IL_00f1:
							if (HFHiAkTmjwXdHUggWAVMEjvncqdK < JUWteZAqRMRcitcHgJNErImTXRUw)
							{
								TkFEVHdbGLBsXAsZnjSdShcxSTwy = gfYMMUAePSwLVxHLnaIYEkktflEn[HFHiAkTmjwXdHUggWAVMEjvncqdK].PollForAllButtons().GetEnumerator();
								HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = -3;
								goto IL_00c5;
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

					private void cUcHEvGPpjMJuJXMLfbjzcYfcOHE()
					{
						HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = -1;
						if (TkFEVHdbGLBsXAsZnjSdShcxSTwy != null)
						{
							TkFEVHdbGLBsXAsZnjSdShcxSTwy.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						BrEbtGUPgVNwAqFRYoyxgPRvGvZT brEbtGUPgVNwAqFRYoyxgPRvGvZT;
						if (HnMAUWcpSRQyNjKuMvVSuSwpEVPiA == -2 && JyuGbzZvLSHqrMuiThFcWTuiusQy == Environment.CurrentManagedThreadId)
						{
							HnMAUWcpSRQyNjKuMvVSuSwpEVPiA = 0;
							brEbtGUPgVNwAqFRYoyxgPRvGvZT = this;
						}
						else
						{
							brEbtGUPgVNwAqFRYoyxgPRvGvZT = new BrEbtGUPgVNwAqFRYoyxgPRvGvZT(0);
							brEbtGUPgVNwAqFRYoyxgPRvGvZT.iPHELmBtBoYPjZckPFNmiTbBCMcEA = iPHELmBtBoYPjZckPFNmiTbBCMcEA;
						}
						return brEbtGUPgVNwAqFRYoyxgPRvGvZT;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class mFSvPYDVwUugxYGutasAuLDHwFCG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int MtfxnyEqdWaeHhwlWfFlTipmWewf;

					private ControllerPollingInfo fpKHwnRGwFTmkFnLAPVregxGxMbh;

					private int wkdRluGjklvVuhzAGsvJbNolSjfL;

					public PollingHelper kiTPPPOUTNggCVcawjsKHFWhCgfP;

					private IList<Joystick> MypXiWcdkmNwRohsqMAxdHrsODXE;

					private int RUZDSsMXUVuqJtrTktEaCUWDbyjs;

					private int sWfqwfhOPhVNOdVghRgdmzQmbHNs;

					private IEnumerator<ControllerPollingInfo> JIXVGgjClbhLRQlESgvIpSPFMMPk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return fpKHwnRGwFTmkFnLAPVregxGxMbh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return fpKHwnRGwFTmkFnLAPVregxGxMbh;
						}
					}

					[DebuggerHidden]
					public mFSvPYDVwUugxYGutasAuLDHwFCG(int P_0)
					{
						MtfxnyEqdWaeHhwlWfFlTipmWewf = P_0;
						wkdRluGjklvVuhzAGsvJbNolSjfL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int mtfxnyEqdWaeHhwlWfFlTipmWewf = MtfxnyEqdWaeHhwlWfFlTipmWewf;
						if (mtfxnyEqdWaeHhwlWfFlTipmWewf == -3 || mtfxnyEqdWaeHhwlWfFlTipmWewf == 1)
						{
							try
							{
							}
							finally
							{
								McewvsEVOvvMfALkVvQgtRcTFhNK();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int mtfxnyEqdWaeHhwlWfFlTipmWewf = MtfxnyEqdWaeHhwlWfFlTipmWewf;
							PollingHelper pollingHelper = kiTPPPOUTNggCVcawjsKHFWhCgfP;
							if (mtfxnyEqdWaeHhwlWfFlTipmWewf != 0)
							{
								if (mtfxnyEqdWaeHhwlWfFlTipmWewf != 1)
								{
									return false;
								}
								MtfxnyEqdWaeHhwlWfFlTipmWewf = -3;
								goto IL_00c5;
							}
							MtfxnyEqdWaeHhwlWfFlTipmWewf = -1;
							MypXiWcdkmNwRohsqMAxdHrsODXE = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							RUZDSsMXUVuqJtrTktEaCUWDbyjs = MypXiWcdkmNwRohsqMAxdHrsODXE.Count;
							sWfqwfhOPhVNOdVghRgdmzQmbHNs = 0;
							goto IL_00f1;
							IL_00c5:
							if (JIXVGgjClbhLRQlESgvIpSPFMMPk.MoveNext())
							{
								ControllerPollingInfo current = JIXVGgjClbhLRQlESgvIpSPFMMPk.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								fpKHwnRGwFTmkFnLAPVregxGxMbh = controllerPollingInfo;
								MtfxnyEqdWaeHhwlWfFlTipmWewf = 1;
								return true;
							}
							McewvsEVOvvMfALkVvQgtRcTFhNK();
							JIXVGgjClbhLRQlESgvIpSPFMMPk = null;
							sWfqwfhOPhVNOdVghRgdmzQmbHNs++;
							goto IL_00f1;
							IL_00f1:
							if (sWfqwfhOPhVNOdVghRgdmzQmbHNs < RUZDSsMXUVuqJtrTktEaCUWDbyjs)
							{
								JIXVGgjClbhLRQlESgvIpSPFMMPk = MypXiWcdkmNwRohsqMAxdHrsODXE[sWfqwfhOPhVNOdVghRgdmzQmbHNs].PollForAllButtonsDown().GetEnumerator();
								MtfxnyEqdWaeHhwlWfFlTipmWewf = -3;
								goto IL_00c5;
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

					private void McewvsEVOvvMfALkVvQgtRcTFhNK()
					{
						MtfxnyEqdWaeHhwlWfFlTipmWewf = -1;
						if (JIXVGgjClbhLRQlESgvIpSPFMMPk != null)
						{
							JIXVGgjClbhLRQlESgvIpSPFMMPk.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mFSvPYDVwUugxYGutasAuLDHwFCG mFSvPYDVwUugxYGutasAuLDHwFCG2;
						if (MtfxnyEqdWaeHhwlWfFlTipmWewf == -2 && wkdRluGjklvVuhzAGsvJbNolSjfL == Environment.CurrentManagedThreadId)
						{
							MtfxnyEqdWaeHhwlWfFlTipmWewf = 0;
							mFSvPYDVwUugxYGutasAuLDHwFCG2 = this;
						}
						else
						{
							mFSvPYDVwUugxYGutasAuLDHwFCG2 = new mFSvPYDVwUugxYGutasAuLDHwFCG(0);
							mFSvPYDVwUugxYGutasAuLDHwFCG2.kiTPPPOUTNggCVcawjsKHFWhCgfP = kiTPPPOUTNggCVcawjsKHFWhCgfP;
						}
						return mFSvPYDVwUugxYGutasAuLDHwFCG2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class MXXxXOvdvVqOdzRZXBQIcRpmOrxgb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ZqxULkuPUjBhsAjEshVFIUYhybbTA;

					private ControllerPollingInfo YisQkiASmTLfqEiGbGVyewHmxPqrA;

					private int LvzaRpBqGOYNYjdLmPcQbQiwmuvC;

					public PollingHelper IhxzpUxEKcFwMiNzrKVxfblaiQBhb;

					private IList<Joystick> RwDEBRnceAzjqaCiuTnaDaqlJBdQ;

					private int tYGFEokmcllqDeJrzDgjQIrchrGcb;

					private int yrpdGZCIgtYimDcKKvdTLxjVRSNCA;

					private IEnumerator<ControllerPollingInfo> iuhinqXdoXMqZtjmagJAHnZukaNvA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return YisQkiASmTLfqEiGbGVyewHmxPqrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YisQkiASmTLfqEiGbGVyewHmxPqrA;
						}
					}

					[DebuggerHidden]
					public MXXxXOvdvVqOdzRZXBQIcRpmOrxgb(int P_0)
					{
						ZqxULkuPUjBhsAjEshVFIUYhybbTA = P_0;
						LvzaRpBqGOYNYjdLmPcQbQiwmuvC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int zqxULkuPUjBhsAjEshVFIUYhybbTA = ZqxULkuPUjBhsAjEshVFIUYhybbTA;
						if (zqxULkuPUjBhsAjEshVFIUYhybbTA == -3 || zqxULkuPUjBhsAjEshVFIUYhybbTA == 1)
						{
							try
							{
							}
							finally
							{
								RSDchrHkWsbVjkqYOxEeszazfpANA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int zqxULkuPUjBhsAjEshVFIUYhybbTA = ZqxULkuPUjBhsAjEshVFIUYhybbTA;
							PollingHelper ihxzpUxEKcFwMiNzrKVxfblaiQBhb = IhxzpUxEKcFwMiNzrKVxfblaiQBhb;
							if (zqxULkuPUjBhsAjEshVFIUYhybbTA != 0)
							{
								if (zqxULkuPUjBhsAjEshVFIUYhybbTA != 1)
								{
									return false;
								}
								ZqxULkuPUjBhsAjEshVFIUYhybbTA = -3;
								goto IL_00c5;
							}
							ZqxULkuPUjBhsAjEshVFIUYhybbTA = -1;
							RwDEBRnceAzjqaCiuTnaDaqlJBdQ = ihxzpUxEKcFwMiNzrKVxfblaiQBhb.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							tYGFEokmcllqDeJrzDgjQIrchrGcb = RwDEBRnceAzjqaCiuTnaDaqlJBdQ.Count;
							yrpdGZCIgtYimDcKKvdTLxjVRSNCA = 0;
							goto IL_00f1;
							IL_00c5:
							if (iuhinqXdoXMqZtjmagJAHnZukaNvA.MoveNext())
							{
								ControllerPollingInfo current = iuhinqXdoXMqZtjmagJAHnZukaNvA.Current;
								ControllerPollingInfo yisQkiASmTLfqEiGbGVyewHmxPqrA = new ControllerPollingInfo(current);
								yisQkiASmTLfqEiGbGVyewHmxPqrA.playerId = ihxzpUxEKcFwMiNzrKVxfblaiQBhb.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								YisQkiASmTLfqEiGbGVyewHmxPqrA = yisQkiASmTLfqEiGbGVyewHmxPqrA;
								ZqxULkuPUjBhsAjEshVFIUYhybbTA = 1;
								return true;
							}
							RSDchrHkWsbVjkqYOxEeszazfpANA();
							iuhinqXdoXMqZtjmagJAHnZukaNvA = null;
							yrpdGZCIgtYimDcKKvdTLxjVRSNCA++;
							goto IL_00f1;
							IL_00f1:
							if (yrpdGZCIgtYimDcKKvdTLxjVRSNCA < tYGFEokmcllqDeJrzDgjQIrchrGcb)
							{
								iuhinqXdoXMqZtjmagJAHnZukaNvA = RwDEBRnceAzjqaCiuTnaDaqlJBdQ[yrpdGZCIgtYimDcKKvdTLxjVRSNCA].PollForAllElements().GetEnumerator();
								ZqxULkuPUjBhsAjEshVFIUYhybbTA = -3;
								goto IL_00c5;
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

					private void RSDchrHkWsbVjkqYOxEeszazfpANA()
					{
						ZqxULkuPUjBhsAjEshVFIUYhybbTA = -1;
						if (iuhinqXdoXMqZtjmagJAHnZukaNvA != null)
						{
							iuhinqXdoXMqZtjmagJAHnZukaNvA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						MXXxXOvdvVqOdzRZXBQIcRpmOrxgb mXXxXOvdvVqOdzRZXBQIcRpmOrxgb;
						if (ZqxULkuPUjBhsAjEshVFIUYhybbTA == -2 && LvzaRpBqGOYNYjdLmPcQbQiwmuvC == Environment.CurrentManagedThreadId)
						{
							ZqxULkuPUjBhsAjEshVFIUYhybbTA = 0;
							mXXxXOvdvVqOdzRZXBQIcRpmOrxgb = this;
						}
						else
						{
							mXXxXOvdvVqOdzRZXBQIcRpmOrxgb = new MXXxXOvdvVqOdzRZXBQIcRpmOrxgb(0);
							mXXxXOvdvVqOdzRZXBQIcRpmOrxgb.IhxzpUxEKcFwMiNzrKVxfblaiQBhb = IhxzpUxEKcFwMiNzrKVxfblaiQBhb;
						}
						return mXXxXOvdvVqOdzRZXBQIcRpmOrxgb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class cYdBUibeWkjBsfQQhqwJBHojPMehD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int fMvjRGowLBbVjyFKgdJJPRJSxVZB;

					private ControllerPollingInfo DCQEMUfCBBUIcUrCsmXrVLBckGBC;

					private int UWIbBxIdzCuYHULlQmDwMVDaCcxEb;

					public PollingHelper qCDEXnFiZjNMOFforjKoyHcNhXUzA;

					private IList<Joystick> koOZwVDyhIoiXGOnnhFfKibUpshM;

					private int HmJGBbMCsDbGRtkByBCVjhnqXhJuA;

					private int UsmRUdUmqhXKnMLymZUHOKDsitlC;

					private IEnumerator<ControllerPollingInfo> xtBQYupSlGFYvppsRLTAnuoFonGN;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DCQEMUfCBBUIcUrCsmXrVLBckGBC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DCQEMUfCBBUIcUrCsmXrVLBckGBC;
						}
					}

					[DebuggerHidden]
					public cYdBUibeWkjBsfQQhqwJBHojPMehD(int P_0)
					{
						fMvjRGowLBbVjyFKgdJJPRJSxVZB = P_0;
						UWIbBxIdzCuYHULlQmDwMVDaCcxEb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = fMvjRGowLBbVjyFKgdJJPRJSxVZB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								biifcSwzeigaWUrYqaLtVuaUUJkV();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = fMvjRGowLBbVjyFKgdJJPRJSxVZB;
							PollingHelper pollingHelper = qCDEXnFiZjNMOFforjKoyHcNhXUzA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								fMvjRGowLBbVjyFKgdJJPRJSxVZB = -3;
								goto IL_00c5;
							}
							fMvjRGowLBbVjyFKgdJJPRJSxVZB = -1;
							koOZwVDyhIoiXGOnnhFfKibUpshM = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
							HmJGBbMCsDbGRtkByBCVjhnqXhJuA = koOZwVDyhIoiXGOnnhFfKibUpshM.Count;
							UsmRUdUmqhXKnMLymZUHOKDsitlC = 0;
							goto IL_00f1;
							IL_00c5:
							if (xtBQYupSlGFYvppsRLTAnuoFonGN.MoveNext())
							{
								ControllerPollingInfo current = xtBQYupSlGFYvppsRLTAnuoFonGN.Current;
								ControllerPollingInfo dCQEMUfCBBUIcUrCsmXrVLBckGBC = new ControllerPollingInfo(current);
								dCQEMUfCBBUIcUrCsmXrVLBckGBC.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								DCQEMUfCBBUIcUrCsmXrVLBckGBC = dCQEMUfCBBUIcUrCsmXrVLBckGBC;
								fMvjRGowLBbVjyFKgdJJPRJSxVZB = 1;
								return true;
							}
							biifcSwzeigaWUrYqaLtVuaUUJkV();
							xtBQYupSlGFYvppsRLTAnuoFonGN = null;
							UsmRUdUmqhXKnMLymZUHOKDsitlC++;
							goto IL_00f1;
							IL_00f1:
							if (UsmRUdUmqhXKnMLymZUHOKDsitlC < HmJGBbMCsDbGRtkByBCVjhnqXhJuA)
							{
								xtBQYupSlGFYvppsRLTAnuoFonGN = koOZwVDyhIoiXGOnnhFfKibUpshM[UsmRUdUmqhXKnMLymZUHOKDsitlC].PollForAllElementsDown().GetEnumerator();
								fMvjRGowLBbVjyFKgdJJPRJSxVZB = -3;
								goto IL_00c5;
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

					private void biifcSwzeigaWUrYqaLtVuaUUJkV()
					{
						fMvjRGowLBbVjyFKgdJJPRJSxVZB = -1;
						if (xtBQYupSlGFYvppsRLTAnuoFonGN != null)
						{
							xtBQYupSlGFYvppsRLTAnuoFonGN.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						cYdBUibeWkjBsfQQhqwJBHojPMehD cYdBUibeWkjBsfQQhqwJBHojPMehD2;
						if (fMvjRGowLBbVjyFKgdJJPRJSxVZB == -2 && UWIbBxIdzCuYHULlQmDwMVDaCcxEb == Environment.CurrentManagedThreadId)
						{
							fMvjRGowLBbVjyFKgdJJPRJSxVZB = 0;
							cYdBUibeWkjBsfQQhqwJBHojPMehD2 = this;
						}
						else
						{
							cYdBUibeWkjBsfQQhqwJBHojPMehD2 = new cYdBUibeWkjBsfQQhqwJBHojPMehD(0);
							cYdBUibeWkjBsfQQhqwJBHojPMehD2.qCDEXnFiZjNMOFforjKoyHcNhXUzA = qCDEXnFiZjNMOFforjKoyHcNhXUzA;
						}
						return cYdBUibeWkjBsfQQhqwJBHojPMehD2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FoxuNgqKwUaFDdxnSAOYSdEzuSbm : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int rCqUERHrqDfvUpJyaaohKionkdxc;

					private ControllerPollingInfo EtmFkhLQVbOfeqAjKhwOGLRaLgEfb;

					private int KeXARQoKLoAaxRBWdAUZKIMhdsbFA;

					private int fyIzVbJGzIrbBoydpHGeetlzEZGf;

					public int haiqeooIJiCLgHzxkBqlesBYiLcxA;

					public PollingHelper hYeEOdsHIwGyMSckEDihWMXMhlpA;

					private IEnumerator<ControllerPollingInfo> HQUYCjvvxniGjUUpQmOFRurqrLDl;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return EtmFkhLQVbOfeqAjKhwOGLRaLgEfb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return EtmFkhLQVbOfeqAjKhwOGLRaLgEfb;
						}
					}

					[DebuggerHidden]
					public FoxuNgqKwUaFDdxnSAOYSdEzuSbm(int P_0)
					{
						rCqUERHrqDfvUpJyaaohKionkdxc = P_0;
						KeXARQoKLoAaxRBWdAUZKIMhdsbFA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rCqUERHrqDfvUpJyaaohKionkdxc;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								rcqOIlDWSIJilEJgsRiqNbmpNKKH();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rCqUERHrqDfvUpJyaaohKionkdxc;
							PollingHelper pollingHelper = hYeEOdsHIwGyMSckEDihWMXMhlpA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								rCqUERHrqDfvUpJyaaohKionkdxc = -1;
								if (fyIzVbJGzIrbBoydpHGeetlzEZGf < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(fyIzVbJGzIrbBoydpHGeetlzEZGf);
								if (customController == null)
								{
									return false;
								}
								HQUYCjvvxniGjUUpQmOFRurqrLDl = customController.PollForAllAxes().GetEnumerator();
								rCqUERHrqDfvUpJyaaohKionkdxc = -3;
								break;
							}
							case 1:
								rCqUERHrqDfvUpJyaaohKionkdxc = -3;
								break;
							}
							if (HQUYCjvvxniGjUUpQmOFRurqrLDl.MoveNext())
							{
								ControllerPollingInfo current = HQUYCjvvxniGjUUpQmOFRurqrLDl.Current;
								ControllerPollingInfo etmFkhLQVbOfeqAjKhwOGLRaLgEfb = new ControllerPollingInfo(current);
								etmFkhLQVbOfeqAjKhwOGLRaLgEfb.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								EtmFkhLQVbOfeqAjKhwOGLRaLgEfb = etmFkhLQVbOfeqAjKhwOGLRaLgEfb;
								rCqUERHrqDfvUpJyaaohKionkdxc = 1;
								return true;
							}
							rcqOIlDWSIJilEJgsRiqNbmpNKKH();
							HQUYCjvvxniGjUUpQmOFRurqrLDl = null;
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

					private void rcqOIlDWSIJilEJgsRiqNbmpNKKH()
					{
						rCqUERHrqDfvUpJyaaohKionkdxc = -1;
						if (HQUYCjvvxniGjUUpQmOFRurqrLDl != null)
						{
							HQUYCjvvxniGjUUpQmOFRurqrLDl.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						FoxuNgqKwUaFDdxnSAOYSdEzuSbm foxuNgqKwUaFDdxnSAOYSdEzuSbm;
						if (rCqUERHrqDfvUpJyaaohKionkdxc == -2 && KeXARQoKLoAaxRBWdAUZKIMhdsbFA == Environment.CurrentManagedThreadId)
						{
							rCqUERHrqDfvUpJyaaohKionkdxc = 0;
							foxuNgqKwUaFDdxnSAOYSdEzuSbm = this;
						}
						else
						{
							foxuNgqKwUaFDdxnSAOYSdEzuSbm = new FoxuNgqKwUaFDdxnSAOYSdEzuSbm(0);
							foxuNgqKwUaFDdxnSAOYSdEzuSbm.hYeEOdsHIwGyMSckEDihWMXMhlpA = hYeEOdsHIwGyMSckEDihWMXMhlpA;
						}
						foxuNgqKwUaFDdxnSAOYSdEzuSbm.fyIzVbJGzIrbBoydpHGeetlzEZGf = haiqeooIJiCLgHzxkBqlesBYiLcxA;
						return foxuNgqKwUaFDdxnSAOYSdEzuSbm;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class zhpQRbhhnzTSpxZvjQTnwmdohDtz : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int rqrIdmNeRGSckYczRdmEgLVRKPLF;

					private ControllerPollingInfo QBPgrWhihwArZqyBToxlTsnmjOxHb;

					private int uPKYTguVOCNLOLeKQQneFxbZWHmW;

					private int TpvPBPleIRylYICPFrRJmKzMqMdl;

					public int VqAXBCeTkzstEDplgLHLZCgBZJmQ;

					public PollingHelper ZzBGxZaeLaoDbTkeQkVELAkPfFKy;

					private IEnumerator<ControllerPollingInfo> LUlEwlnYhSpxyfhkLwWogIIiyMJF;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return QBPgrWhihwArZqyBToxlTsnmjOxHb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QBPgrWhihwArZqyBToxlTsnmjOxHb;
						}
					}

					[DebuggerHidden]
					public zhpQRbhhnzTSpxZvjQTnwmdohDtz(int P_0)
					{
						rqrIdmNeRGSckYczRdmEgLVRKPLF = P_0;
						uPKYTguVOCNLOLeKQQneFxbZWHmW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rqrIdmNeRGSckYczRdmEgLVRKPLF;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								knGVmQuFIwbwEAIybfHEwwXrddMJA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rqrIdmNeRGSckYczRdmEgLVRKPLF;
							PollingHelper zzBGxZaeLaoDbTkeQkVELAkPfFKy = ZzBGxZaeLaoDbTkeQkVELAkPfFKy;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								rqrIdmNeRGSckYczRdmEgLVRKPLF = -1;
								if (TpvPBPleIRylYICPFrRJmKzMqMdl < 0)
								{
									return false;
								}
								CustomController customController = zzBGxZaeLaoDbTkeQkVELAkPfFKy.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(TpvPBPleIRylYICPFrRJmKzMqMdl);
								if (customController == null)
								{
									return false;
								}
								LUlEwlnYhSpxyfhkLwWogIIiyMJF = customController.PollForAllButtons().GetEnumerator();
								rqrIdmNeRGSckYczRdmEgLVRKPLF = -3;
								break;
							}
							case 1:
								rqrIdmNeRGSckYczRdmEgLVRKPLF = -3;
								break;
							}
							if (LUlEwlnYhSpxyfhkLwWogIIiyMJF.MoveNext())
							{
								ControllerPollingInfo current = LUlEwlnYhSpxyfhkLwWogIIiyMJF.Current;
								ControllerPollingInfo qBPgrWhihwArZqyBToxlTsnmjOxHb = new ControllerPollingInfo(current);
								qBPgrWhihwArZqyBToxlTsnmjOxHb.playerId = zzBGxZaeLaoDbTkeQkVELAkPfFKy.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								QBPgrWhihwArZqyBToxlTsnmjOxHb = qBPgrWhihwArZqyBToxlTsnmjOxHb;
								rqrIdmNeRGSckYczRdmEgLVRKPLF = 1;
								return true;
							}
							knGVmQuFIwbwEAIybfHEwwXrddMJA();
							LUlEwlnYhSpxyfhkLwWogIIiyMJF = null;
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

					private void knGVmQuFIwbwEAIybfHEwwXrddMJA()
					{
						rqrIdmNeRGSckYczRdmEgLVRKPLF = -1;
						if (LUlEwlnYhSpxyfhkLwWogIIiyMJF != null)
						{
							LUlEwlnYhSpxyfhkLwWogIIiyMJF.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						zhpQRbhhnzTSpxZvjQTnwmdohDtz zhpQRbhhnzTSpxZvjQTnwmdohDtz2;
						if (rqrIdmNeRGSckYczRdmEgLVRKPLF == -2 && uPKYTguVOCNLOLeKQQneFxbZWHmW == Environment.CurrentManagedThreadId)
						{
							rqrIdmNeRGSckYczRdmEgLVRKPLF = 0;
							zhpQRbhhnzTSpxZvjQTnwmdohDtz2 = this;
						}
						else
						{
							zhpQRbhhnzTSpxZvjQTnwmdohDtz2 = new zhpQRbhhnzTSpxZvjQTnwmdohDtz(0);
							zhpQRbhhnzTSpxZvjQTnwmdohDtz2.ZzBGxZaeLaoDbTkeQkVELAkPfFKy = ZzBGxZaeLaoDbTkeQkVELAkPfFKy;
						}
						zhpQRbhhnzTSpxZvjQTnwmdohDtz2.TpvPBPleIRylYICPFrRJmKzMqMdl = VqAXBCeTkzstEDplgLHLZCgBZJmQ;
						return zhpQRbhhnzTSpxZvjQTnwmdohDtz2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class UTOtAFWtXmDfbHGYCtWBeJPpmQth : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sRGyJtKaKadAGHPRZlqyVkbrmrso;

					private ControllerPollingInfo kesXdrcaeVeULfvuDenhWDjCBvgSA;

					private int OIohQRayKIuIQVWnKQAZCeuVZBsh;

					private int RXCGxQFMNeAVPPrvKclKEPjBwwudc;

					public int MphoLCgRRXhHBxBZaFowCLrbgMep;

					public PollingHelper GRkVLDYirhviYITGYrrQblIEtVfY;

					private IEnumerator<ControllerPollingInfo> veEzZnjsZcDgWpoHXHsBajCxnNrmA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kesXdrcaeVeULfvuDenhWDjCBvgSA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kesXdrcaeVeULfvuDenhWDjCBvgSA;
						}
					}

					[DebuggerHidden]
					public UTOtAFWtXmDfbHGYCtWBeJPpmQth(int P_0)
					{
						sRGyJtKaKadAGHPRZlqyVkbrmrso = P_0;
						OIohQRayKIuIQVWnKQAZCeuVZBsh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sRGyJtKaKadAGHPRZlqyVkbrmrso;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								JFeyVqjeScKaGfxaJKtcxoCHDUUHA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = sRGyJtKaKadAGHPRZlqyVkbrmrso;
							PollingHelper gRkVLDYirhviYITGYrrQblIEtVfY = GRkVLDYirhviYITGYrrQblIEtVfY;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								sRGyJtKaKadAGHPRZlqyVkbrmrso = -1;
								if (RXCGxQFMNeAVPPrvKclKEPjBwwudc < 0)
								{
									return false;
								}
								CustomController customController = gRkVLDYirhviYITGYrrQblIEtVfY.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(RXCGxQFMNeAVPPrvKclKEPjBwwudc);
								if (customController == null)
								{
									return false;
								}
								veEzZnjsZcDgWpoHXHsBajCxnNrmA = customController.PollForAllButtonsDown().GetEnumerator();
								sRGyJtKaKadAGHPRZlqyVkbrmrso = -3;
								break;
							}
							case 1:
								sRGyJtKaKadAGHPRZlqyVkbrmrso = -3;
								break;
							}
							if (veEzZnjsZcDgWpoHXHsBajCxnNrmA.MoveNext())
							{
								ControllerPollingInfo current = veEzZnjsZcDgWpoHXHsBajCxnNrmA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = gRkVLDYirhviYITGYrrQblIEtVfY.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								kesXdrcaeVeULfvuDenhWDjCBvgSA = controllerPollingInfo;
								sRGyJtKaKadAGHPRZlqyVkbrmrso = 1;
								return true;
							}
							JFeyVqjeScKaGfxaJKtcxoCHDUUHA();
							veEzZnjsZcDgWpoHXHsBajCxnNrmA = null;
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

					private void JFeyVqjeScKaGfxaJKtcxoCHDUUHA()
					{
						sRGyJtKaKadAGHPRZlqyVkbrmrso = -1;
						if (veEzZnjsZcDgWpoHXHsBajCxnNrmA != null)
						{
							veEzZnjsZcDgWpoHXHsBajCxnNrmA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						UTOtAFWtXmDfbHGYCtWBeJPpmQth uTOtAFWtXmDfbHGYCtWBeJPpmQth;
						if (sRGyJtKaKadAGHPRZlqyVkbrmrso == -2 && OIohQRayKIuIQVWnKQAZCeuVZBsh == Environment.CurrentManagedThreadId)
						{
							sRGyJtKaKadAGHPRZlqyVkbrmrso = 0;
							uTOtAFWtXmDfbHGYCtWBeJPpmQth = this;
						}
						else
						{
							uTOtAFWtXmDfbHGYCtWBeJPpmQth = new UTOtAFWtXmDfbHGYCtWBeJPpmQth(0);
							uTOtAFWtXmDfbHGYCtWBeJPpmQth.GRkVLDYirhviYITGYrrQblIEtVfY = GRkVLDYirhviYITGYrrQblIEtVfY;
						}
						uTOtAFWtXmDfbHGYCtWBeJPpmQth.RXCGxQFMNeAVPPrvKclKEPjBwwudc = MphoLCgRRXhHBxBZaFowCLrbgMep;
						return uTOtAFWtXmDfbHGYCtWBeJPpmQth;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IiVhGogIgYYHgJqjoZkNHiuabGViA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ngRljfjkDxhPkaxGHyJmerZhDHDdA;

					private ControllerPollingInfo LIosfxjwoRmEJQfjMmgRSJnPoogV;

					private int nGSCDxYCExaCvEkpqQxBvOpBhqFEA;

					private int oklcdhTivlrbADDSCsdbZYhIdlgg;

					public int aVcvIppYWuLuZoqBMifRyhdsItIx;

					public PollingHelper EotDfdDbXmZUDeESXmzUKOmhqUyUA;

					private IEnumerator<ControllerPollingInfo> lLSKFCjEZYJfjmGPUmrsOJULXUGC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LIosfxjwoRmEJQfjMmgRSJnPoogV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LIosfxjwoRmEJQfjMmgRSJnPoogV;
						}
					}

					[DebuggerHidden]
					public IiVhGogIgYYHgJqjoZkNHiuabGViA(int P_0)
					{
						ngRljfjkDxhPkaxGHyJmerZhDHDdA = P_0;
						nGSCDxYCExaCvEkpqQxBvOpBhqFEA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ngRljfjkDxhPkaxGHyJmerZhDHDdA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								qUMfHVcyDRFBoqmdRwaHRaZDAOWg();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = ngRljfjkDxhPkaxGHyJmerZhDHDdA;
							PollingHelper eotDfdDbXmZUDeESXmzUKOmhqUyUA = EotDfdDbXmZUDeESXmzUKOmhqUyUA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								ngRljfjkDxhPkaxGHyJmerZhDHDdA = -1;
								if (oklcdhTivlrbADDSCsdbZYhIdlgg < 0)
								{
									return false;
								}
								CustomController customController = eotDfdDbXmZUDeESXmzUKOmhqUyUA.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(oklcdhTivlrbADDSCsdbZYhIdlgg);
								if (customController == null)
								{
									return false;
								}
								lLSKFCjEZYJfjmGPUmrsOJULXUGC = customController.PollForAllElements().GetEnumerator();
								ngRljfjkDxhPkaxGHyJmerZhDHDdA = -3;
								break;
							}
							case 1:
								ngRljfjkDxhPkaxGHyJmerZhDHDdA = -3;
								break;
							}
							if (lLSKFCjEZYJfjmGPUmrsOJULXUGC.MoveNext())
							{
								ControllerPollingInfo current = lLSKFCjEZYJfjmGPUmrsOJULXUGC.Current;
								ControllerPollingInfo lIosfxjwoRmEJQfjMmgRSJnPoogV = new ControllerPollingInfo(current);
								lIosfxjwoRmEJQfjMmgRSJnPoogV.playerId = eotDfdDbXmZUDeESXmzUKOmhqUyUA.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								LIosfxjwoRmEJQfjMmgRSJnPoogV = lIosfxjwoRmEJQfjMmgRSJnPoogV;
								ngRljfjkDxhPkaxGHyJmerZhDHDdA = 1;
								return true;
							}
							qUMfHVcyDRFBoqmdRwaHRaZDAOWg();
							lLSKFCjEZYJfjmGPUmrsOJULXUGC = null;
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

					private void qUMfHVcyDRFBoqmdRwaHRaZDAOWg()
					{
						ngRljfjkDxhPkaxGHyJmerZhDHDdA = -1;
						if (lLSKFCjEZYJfjmGPUmrsOJULXUGC != null)
						{
							lLSKFCjEZYJfjmGPUmrsOJULXUGC.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						IiVhGogIgYYHgJqjoZkNHiuabGViA iiVhGogIgYYHgJqjoZkNHiuabGViA;
						if (ngRljfjkDxhPkaxGHyJmerZhDHDdA == -2 && nGSCDxYCExaCvEkpqQxBvOpBhqFEA == Environment.CurrentManagedThreadId)
						{
							ngRljfjkDxhPkaxGHyJmerZhDHDdA = 0;
							iiVhGogIgYYHgJqjoZkNHiuabGViA = this;
						}
						else
						{
							iiVhGogIgYYHgJqjoZkNHiuabGViA = new IiVhGogIgYYHgJqjoZkNHiuabGViA(0);
							iiVhGogIgYYHgJqjoZkNHiuabGViA.EotDfdDbXmZUDeESXmzUKOmhqUyUA = EotDfdDbXmZUDeESXmzUKOmhqUyUA;
						}
						iiVhGogIgYYHgJqjoZkNHiuabGViA.oklcdhTivlrbADDSCsdbZYhIdlgg = aVcvIppYWuLuZoqBMifRyhdsItIx;
						return iiVhGogIgYYHgJqjoZkNHiuabGViA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class VYCWXsAONndAYIaRWIckdcvhAVso : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int BthosMSjIyKyIpRPLEhkDIDkDlXW;

					private ControllerPollingInfo kawnkbXUzgpSkFSaaJFmLuswdClT;

					private int gAXfqNmEDzIIuUjhPGkliSGBTRmFA;

					private int vDPuFOZLByKNZFVgWDCkVObuirhAA;

					public int BgYHNmJiQdajEgEaIZVzhdyCskPQ;

					public PollingHelper GVdYWWSQvGNobDUcvQSUFrYDatXh;

					private IEnumerator<ControllerPollingInfo> clJoqCgCaXoDTQMTyytBhOqSWMvP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kawnkbXUzgpSkFSaaJFmLuswdClT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kawnkbXUzgpSkFSaaJFmLuswdClT;
						}
					}

					[DebuggerHidden]
					public VYCWXsAONndAYIaRWIckdcvhAVso(int P_0)
					{
						BthosMSjIyKyIpRPLEhkDIDkDlXW = P_0;
						gAXfqNmEDzIIuUjhPGkliSGBTRmFA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bthosMSjIyKyIpRPLEhkDIDkDlXW = BthosMSjIyKyIpRPLEhkDIDkDlXW;
						if (bthosMSjIyKyIpRPLEhkDIDkDlXW == -3 || bthosMSjIyKyIpRPLEhkDIDkDlXW == 1)
						{
							try
							{
							}
							finally
							{
								KJlstVEgTGgorRePscTSlIrnthNf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int bthosMSjIyKyIpRPLEhkDIDkDlXW = BthosMSjIyKyIpRPLEhkDIDkDlXW;
							PollingHelper gVdYWWSQvGNobDUcvQSUFrYDatXh = GVdYWWSQvGNobDUcvQSUFrYDatXh;
							switch (bthosMSjIyKyIpRPLEhkDIDkDlXW)
							{
							default:
								return false;
							case 0:
							{
								BthosMSjIyKyIpRPLEhkDIDkDlXW = -1;
								if (vDPuFOZLByKNZFVgWDCkVObuirhAA < 0)
								{
									return false;
								}
								CustomController customController = gVdYWWSQvGNobDUcvQSUFrYDatXh.aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(vDPuFOZLByKNZFVgWDCkVObuirhAA);
								if (customController == null)
								{
									return false;
								}
								clJoqCgCaXoDTQMTyytBhOqSWMvP = customController.PollForAllElementsDown().GetEnumerator();
								BthosMSjIyKyIpRPLEhkDIDkDlXW = -3;
								break;
							}
							case 1:
								BthosMSjIyKyIpRPLEhkDIDkDlXW = -3;
								break;
							}
							if (clJoqCgCaXoDTQMTyytBhOqSWMvP.MoveNext())
							{
								ControllerPollingInfo current = clJoqCgCaXoDTQMTyytBhOqSWMvP.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = gVdYWWSQvGNobDUcvQSUFrYDatXh.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								kawnkbXUzgpSkFSaaJFmLuswdClT = controllerPollingInfo;
								BthosMSjIyKyIpRPLEhkDIDkDlXW = 1;
								return true;
							}
							KJlstVEgTGgorRePscTSlIrnthNf();
							clJoqCgCaXoDTQMTyytBhOqSWMvP = null;
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

					private void KJlstVEgTGgorRePscTSlIrnthNf()
					{
						BthosMSjIyKyIpRPLEhkDIDkDlXW = -1;
						if (clJoqCgCaXoDTQMTyytBhOqSWMvP != null)
						{
							clJoqCgCaXoDTQMTyytBhOqSWMvP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						VYCWXsAONndAYIaRWIckdcvhAVso vYCWXsAONndAYIaRWIckdcvhAVso;
						if (BthosMSjIyKyIpRPLEhkDIDkDlXW == -2 && gAXfqNmEDzIIuUjhPGkliSGBTRmFA == Environment.CurrentManagedThreadId)
						{
							BthosMSjIyKyIpRPLEhkDIDkDlXW = 0;
							vYCWXsAONndAYIaRWIckdcvhAVso = this;
						}
						else
						{
							vYCWXsAONndAYIaRWIckdcvhAVso = new VYCWXsAONndAYIaRWIckdcvhAVso(0);
							vYCWXsAONndAYIaRWIckdcvhAVso.GVdYWWSQvGNobDUcvQSUFrYDatXh = GVdYWWSQvGNobDUcvQSUFrYDatXh;
						}
						vYCWXsAONndAYIaRWIckdcvhAVso.vDPuFOZLByKNZFVgWDCkVObuirhAA = BgYHNmJiQdajEgEaIZVzhdyCskPQ;
						return vYCWXsAONndAYIaRWIckdcvhAVso;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class nelGsczZlrHeDegzDstuRPxieTHE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zbVjsWFKXtXgvczHtZrbDuKNQGcR;

					private ControllerPollingInfo hrKfBHiOHeFDqFPmiFmWnTLtuyep;

					private int smsMOfyDUwjdwvPIUbBayqUqzxIn;

					private int AkMaMHJpjSyZDffuxeOUfpVfOGpb;

					public int HzZyiSVftSGjXizadMsaOfbNGSEv;

					public PollingHelper WRerwmjSOmrbHJHMTBvpzwIsxEoi;

					private IEnumerator<ControllerPollingInfo> ymfIexYPBpTAqsUyPeIRqSmlyaJG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hrKfBHiOHeFDqFPmiFmWnTLtuyep;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hrKfBHiOHeFDqFPmiFmWnTLtuyep;
						}
					}

					[DebuggerHidden]
					public nelGsczZlrHeDegzDstuRPxieTHE(int P_0)
					{
						zbVjsWFKXtXgvczHtZrbDuKNQGcR = P_0;
						smsMOfyDUwjdwvPIUbBayqUqzxIn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zbVjsWFKXtXgvczHtZrbDuKNQGcR;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RbPfIpoTIxoJwwJaubSfSPvJDMUL();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = zbVjsWFKXtXgvczHtZrbDuKNQGcR;
							PollingHelper wRerwmjSOmrbHJHMTBvpzwIsxEoi = WRerwmjSOmrbHJHMTBvpzwIsxEoi;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								zbVjsWFKXtXgvczHtZrbDuKNQGcR = -1;
								if (AkMaMHJpjSyZDffuxeOUfpVfOGpb < 0)
								{
									return false;
								}
								Joystick joystick = wRerwmjSOmrbHJHMTBvpzwIsxEoi.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(AkMaMHJpjSyZDffuxeOUfpVfOGpb);
								if (joystick == null)
								{
									return false;
								}
								ymfIexYPBpTAqsUyPeIRqSmlyaJG = joystick.PollForAllAxes().GetEnumerator();
								zbVjsWFKXtXgvczHtZrbDuKNQGcR = -3;
								break;
							}
							case 1:
								zbVjsWFKXtXgvczHtZrbDuKNQGcR = -3;
								break;
							}
							if (ymfIexYPBpTAqsUyPeIRqSmlyaJG.MoveNext())
							{
								ControllerPollingInfo current = ymfIexYPBpTAqsUyPeIRqSmlyaJG.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = wRerwmjSOmrbHJHMTBvpzwIsxEoi.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								hrKfBHiOHeFDqFPmiFmWnTLtuyep = controllerPollingInfo;
								zbVjsWFKXtXgvczHtZrbDuKNQGcR = 1;
								return true;
							}
							RbPfIpoTIxoJwwJaubSfSPvJDMUL();
							ymfIexYPBpTAqsUyPeIRqSmlyaJG = null;
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

					private void RbPfIpoTIxoJwwJaubSfSPvJDMUL()
					{
						zbVjsWFKXtXgvczHtZrbDuKNQGcR = -1;
						if (ymfIexYPBpTAqsUyPeIRqSmlyaJG != null)
						{
							ymfIexYPBpTAqsUyPeIRqSmlyaJG.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						nelGsczZlrHeDegzDstuRPxieTHE nelGsczZlrHeDegzDstuRPxieTHE2;
						if (zbVjsWFKXtXgvczHtZrbDuKNQGcR == -2 && smsMOfyDUwjdwvPIUbBayqUqzxIn == Environment.CurrentManagedThreadId)
						{
							zbVjsWFKXtXgvczHtZrbDuKNQGcR = 0;
							nelGsczZlrHeDegzDstuRPxieTHE2 = this;
						}
						else
						{
							nelGsczZlrHeDegzDstuRPxieTHE2 = new nelGsczZlrHeDegzDstuRPxieTHE(0);
							nelGsczZlrHeDegzDstuRPxieTHE2.WRerwmjSOmrbHJHMTBvpzwIsxEoi = WRerwmjSOmrbHJHMTBvpzwIsxEoi;
						}
						nelGsczZlrHeDegzDstuRPxieTHE2.AkMaMHJpjSyZDffuxeOUfpVfOGpb = HzZyiSVftSGjXizadMsaOfbNGSEv;
						return nelGsczZlrHeDegzDstuRPxieTHE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class yczyEaNmKeaSSrqDQyVkkFKrRgGV : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int lMkeNfaFgIktLSxdCgHHcGBmtBMw;

					private ControllerPollingInfo qoeHXrGTOlKippErvGeJjVgFnBGBb;

					private int qxBBGIqGCGNPbBlltdnYHySrGUXmA;

					private int LJhPCYsnbXcmBJbuUixEFlTeeRQrb;

					public int NjpVWAbBVCTWusCHxbeDgOKFEsLW;

					public PollingHelper dIVzRojEtWPKWiPekNFSgGmMfDvx;

					private IEnumerator<ControllerPollingInfo> aQiDajoEQONbvYQkOhhZgkstXJGL;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qoeHXrGTOlKippErvGeJjVgFnBGBb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qoeHXrGTOlKippErvGeJjVgFnBGBb;
						}
					}

					[DebuggerHidden]
					public yczyEaNmKeaSSrqDQyVkkFKrRgGV(int P_0)
					{
						lMkeNfaFgIktLSxdCgHHcGBmtBMw = P_0;
						qxBBGIqGCGNPbBlltdnYHySrGUXmA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = lMkeNfaFgIktLSxdCgHHcGBmtBMw;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								iohRejhKdYBRkoQSYUXEbKeYUcEB();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = lMkeNfaFgIktLSxdCgHHcGBmtBMw;
							PollingHelper pollingHelper = dIVzRojEtWPKWiPekNFSgGmMfDvx;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								lMkeNfaFgIktLSxdCgHHcGBmtBMw = -1;
								if (LJhPCYsnbXcmBJbuUixEFlTeeRQrb < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(LJhPCYsnbXcmBJbuUixEFlTeeRQrb);
								if (joystick == null)
								{
									return false;
								}
								aQiDajoEQONbvYQkOhhZgkstXJGL = joystick.PollForAllButtons().GetEnumerator();
								lMkeNfaFgIktLSxdCgHHcGBmtBMw = -3;
								break;
							}
							case 1:
								lMkeNfaFgIktLSxdCgHHcGBmtBMw = -3;
								break;
							}
							if (aQiDajoEQONbvYQkOhhZgkstXJGL.MoveNext())
							{
								ControllerPollingInfo current = aQiDajoEQONbvYQkOhhZgkstXJGL.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								qoeHXrGTOlKippErvGeJjVgFnBGBb = controllerPollingInfo;
								lMkeNfaFgIktLSxdCgHHcGBmtBMw = 1;
								return true;
							}
							iohRejhKdYBRkoQSYUXEbKeYUcEB();
							aQiDajoEQONbvYQkOhhZgkstXJGL = null;
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

					private void iohRejhKdYBRkoQSYUXEbKeYUcEB()
					{
						lMkeNfaFgIktLSxdCgHHcGBmtBMw = -1;
						if (aQiDajoEQONbvYQkOhhZgkstXJGL != null)
						{
							aQiDajoEQONbvYQkOhhZgkstXJGL.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						yczyEaNmKeaSSrqDQyVkkFKrRgGV yczyEaNmKeaSSrqDQyVkkFKrRgGV2;
						if (lMkeNfaFgIktLSxdCgHHcGBmtBMw == -2 && qxBBGIqGCGNPbBlltdnYHySrGUXmA == Environment.CurrentManagedThreadId)
						{
							lMkeNfaFgIktLSxdCgHHcGBmtBMw = 0;
							yczyEaNmKeaSSrqDQyVkkFKrRgGV2 = this;
						}
						else
						{
							yczyEaNmKeaSSrqDQyVkkFKrRgGV2 = new yczyEaNmKeaSSrqDQyVkkFKrRgGV(0);
							yczyEaNmKeaSSrqDQyVkkFKrRgGV2.dIVzRojEtWPKWiPekNFSgGmMfDvx = dIVzRojEtWPKWiPekNFSgGmMfDvx;
						}
						yczyEaNmKeaSSrqDQyVkkFKrRgGV2.LJhPCYsnbXcmBJbuUixEFlTeeRQrb = NjpVWAbBVCTWusCHxbeDgOKFEsLW;
						return yczyEaNmKeaSSrqDQyVkkFKrRgGV2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class HYucLxrCNoCHJiYvYBpKDEDfYQXIB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int WHUvDfKqwTPGEtWfBrsjdkznSOnJ;

					private ControllerPollingInfo sDcYsbknwqEXpOzpZsbvCjpWeGfJ;

					private int LgTAgIcgiDruJqpdXsRVEMyCohfjA;

					private int VfABcZbNoiSzfDzIwkvsSkQdhBnLA;

					public int dPHfvvIEjomOrGOjYjjbMHKxMZRb;

					public PollingHelper nGqcSTACDSqHkbCEJkeyrDFQtMppA;

					private IEnumerator<ControllerPollingInfo> fqJhDxwgFJppZqlgoBRCmiyNChWFA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return sDcYsbknwqEXpOzpZsbvCjpWeGfJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sDcYsbknwqEXpOzpZsbvCjpWeGfJ;
						}
					}

					[DebuggerHidden]
					public HYucLxrCNoCHJiYvYBpKDEDfYQXIB(int P_0)
					{
						WHUvDfKqwTPGEtWfBrsjdkznSOnJ = P_0;
						LgTAgIcgiDruJqpdXsRVEMyCohfjA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int wHUvDfKqwTPGEtWfBrsjdkznSOnJ = WHUvDfKqwTPGEtWfBrsjdkznSOnJ;
						if (wHUvDfKqwTPGEtWfBrsjdkznSOnJ == -3 || wHUvDfKqwTPGEtWfBrsjdkznSOnJ == 1)
						{
							try
							{
							}
							finally
							{
								yBEHiJCCbgmlYpWqHZvLnRZMNdZX();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int wHUvDfKqwTPGEtWfBrsjdkznSOnJ = WHUvDfKqwTPGEtWfBrsjdkznSOnJ;
							PollingHelper pollingHelper = nGqcSTACDSqHkbCEJkeyrDFQtMppA;
							switch (wHUvDfKqwTPGEtWfBrsjdkznSOnJ)
							{
							default:
								return false;
							case 0:
							{
								WHUvDfKqwTPGEtWfBrsjdkznSOnJ = -1;
								if (VfABcZbNoiSzfDzIwkvsSkQdhBnLA < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(VfABcZbNoiSzfDzIwkvsSkQdhBnLA);
								if (joystick == null)
								{
									return false;
								}
								fqJhDxwgFJppZqlgoBRCmiyNChWFA = joystick.PollForAllButtonsDown().GetEnumerator();
								WHUvDfKqwTPGEtWfBrsjdkznSOnJ = -3;
								break;
							}
							case 1:
								WHUvDfKqwTPGEtWfBrsjdkznSOnJ = -3;
								break;
							}
							if (fqJhDxwgFJppZqlgoBRCmiyNChWFA.MoveNext())
							{
								ControllerPollingInfo current = fqJhDxwgFJppZqlgoBRCmiyNChWFA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								sDcYsbknwqEXpOzpZsbvCjpWeGfJ = controllerPollingInfo;
								WHUvDfKqwTPGEtWfBrsjdkznSOnJ = 1;
								return true;
							}
							yBEHiJCCbgmlYpWqHZvLnRZMNdZX();
							fqJhDxwgFJppZqlgoBRCmiyNChWFA = null;
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

					private void yBEHiJCCbgmlYpWqHZvLnRZMNdZX()
					{
						WHUvDfKqwTPGEtWfBrsjdkznSOnJ = -1;
						if (fqJhDxwgFJppZqlgoBRCmiyNChWFA != null)
						{
							fqJhDxwgFJppZqlgoBRCmiyNChWFA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						HYucLxrCNoCHJiYvYBpKDEDfYQXIB hYucLxrCNoCHJiYvYBpKDEDfYQXIB;
						if (WHUvDfKqwTPGEtWfBrsjdkznSOnJ == -2 && LgTAgIcgiDruJqpdXsRVEMyCohfjA == Environment.CurrentManagedThreadId)
						{
							WHUvDfKqwTPGEtWfBrsjdkznSOnJ = 0;
							hYucLxrCNoCHJiYvYBpKDEDfYQXIB = this;
						}
						else
						{
							hYucLxrCNoCHJiYvYBpKDEDfYQXIB = new HYucLxrCNoCHJiYvYBpKDEDfYQXIB(0);
							hYucLxrCNoCHJiYvYBpKDEDfYQXIB.nGqcSTACDSqHkbCEJkeyrDFQtMppA = nGqcSTACDSqHkbCEJkeyrDFQtMppA;
						}
						hYucLxrCNoCHJiYvYBpKDEDfYQXIB.VfABcZbNoiSzfDzIwkvsSkQdhBnLA = dPHfvvIEjomOrGOjYjjbMHKxMZRb;
						return hYucLxrCNoCHJiYvYBpKDEDfYQXIB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class hABQLZkSeWiAVhNHWeaPKjAtMxsCA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int WEeGoDMoGwAWjENlvBHToFaaVpZo;

					private ControllerPollingInfo OoOgEEDqswaRQecaqUoAalMCQrhGA;

					private int mnqTXFgcivElehLLuMTNZcSgHDnDA;

					private int beXREZYWXFPhAicgChZXYPzHNpPi;

					public int jMPapYGZUTEzLvIByKXxrRFsEaih;

					public PollingHelper OfycGLbadqfNfnpqefGLmEpdGXEwA;

					private IEnumerator<ControllerPollingInfo> YZQRHiceEatwWKnTzjWlKMSToCJx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return OoOgEEDqswaRQecaqUoAalMCQrhGA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OoOgEEDqswaRQecaqUoAalMCQrhGA;
						}
					}

					[DebuggerHidden]
					public hABQLZkSeWiAVhNHWeaPKjAtMxsCA(int P_0)
					{
						WEeGoDMoGwAWjENlvBHToFaaVpZo = P_0;
						mnqTXFgcivElehLLuMTNZcSgHDnDA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int wEeGoDMoGwAWjENlvBHToFaaVpZo = WEeGoDMoGwAWjENlvBHToFaaVpZo;
						if (wEeGoDMoGwAWjENlvBHToFaaVpZo == -3 || wEeGoDMoGwAWjENlvBHToFaaVpZo == 1)
						{
							try
							{
							}
							finally
							{
								RFhbPXbuKYLhGYOSEBCYCUVCEGOgA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int wEeGoDMoGwAWjENlvBHToFaaVpZo = WEeGoDMoGwAWjENlvBHToFaaVpZo;
							PollingHelper ofycGLbadqfNfnpqefGLmEpdGXEwA = OfycGLbadqfNfnpqefGLmEpdGXEwA;
							switch (wEeGoDMoGwAWjENlvBHToFaaVpZo)
							{
							default:
								return false;
							case 0:
							{
								WEeGoDMoGwAWjENlvBHToFaaVpZo = -1;
								if (beXREZYWXFPhAicgChZXYPzHNpPi < 0)
								{
									return false;
								}
								Joystick joystick = ofycGLbadqfNfnpqefGLmEpdGXEwA.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(beXREZYWXFPhAicgChZXYPzHNpPi);
								if (joystick == null)
								{
									return false;
								}
								YZQRHiceEatwWKnTzjWlKMSToCJx = joystick.PollForAllElements().GetEnumerator();
								WEeGoDMoGwAWjENlvBHToFaaVpZo = -3;
								break;
							}
							case 1:
								WEeGoDMoGwAWjENlvBHToFaaVpZo = -3;
								break;
							}
							if (YZQRHiceEatwWKnTzjWlKMSToCJx.MoveNext())
							{
								ControllerPollingInfo current = YZQRHiceEatwWKnTzjWlKMSToCJx.Current;
								ControllerPollingInfo ooOgEEDqswaRQecaqUoAalMCQrhGA = new ControllerPollingInfo(current);
								ooOgEEDqswaRQecaqUoAalMCQrhGA.playerId = ofycGLbadqfNfnpqefGLmEpdGXEwA.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								OoOgEEDqswaRQecaqUoAalMCQrhGA = ooOgEEDqswaRQecaqUoAalMCQrhGA;
								WEeGoDMoGwAWjENlvBHToFaaVpZo = 1;
								return true;
							}
							RFhbPXbuKYLhGYOSEBCYCUVCEGOgA();
							YZQRHiceEatwWKnTzjWlKMSToCJx = null;
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

					private void RFhbPXbuKYLhGYOSEBCYCUVCEGOgA()
					{
						WEeGoDMoGwAWjENlvBHToFaaVpZo = -1;
						if (YZQRHiceEatwWKnTzjWlKMSToCJx != null)
						{
							YZQRHiceEatwWKnTzjWlKMSToCJx.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						hABQLZkSeWiAVhNHWeaPKjAtMxsCA hABQLZkSeWiAVhNHWeaPKjAtMxsCA2;
						if (WEeGoDMoGwAWjENlvBHToFaaVpZo == -2 && mnqTXFgcivElehLLuMTNZcSgHDnDA == Environment.CurrentManagedThreadId)
						{
							WEeGoDMoGwAWjENlvBHToFaaVpZo = 0;
							hABQLZkSeWiAVhNHWeaPKjAtMxsCA2 = this;
						}
						else
						{
							hABQLZkSeWiAVhNHWeaPKjAtMxsCA2 = new hABQLZkSeWiAVhNHWeaPKjAtMxsCA(0);
							hABQLZkSeWiAVhNHWeaPKjAtMxsCA2.OfycGLbadqfNfnpqefGLmEpdGXEwA = OfycGLbadqfNfnpqefGLmEpdGXEwA;
						}
						hABQLZkSeWiAVhNHWeaPKjAtMxsCA2.beXREZYWXFPhAicgChZXYPzHNpPi = jMPapYGZUTEzLvIByKXxrRFsEaih;
						return hABQLZkSeWiAVhNHWeaPKjAtMxsCA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kVLlCCNXaWCkWmGrOWhDOLlaecYdA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HXqlwJIDnaTQutXYkqnObIyAMmlg;

					private ControllerPollingInfo TmPprhLPueNfvkzMKDQdkXjSomSk;

					private int LqrKQVmgVNVAHNKhNZvTtIPSPjkm;

					private int NOGkHCPqmNNLttBOWFfCSctYJthP;

					public int EQBkTeDbCbBWpcxgrUnsZnxBZsXo;

					public PollingHelper ixAEHqEkxhwcpFdCjUvYuBuCkFY;

					private IEnumerator<ControllerPollingInfo> LvoqtKoRqSuIUYmHZpZffwOWiJfN;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TmPprhLPueNfvkzMKDQdkXjSomSk;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TmPprhLPueNfvkzMKDQdkXjSomSk;
						}
					}

					[DebuggerHidden]
					public kVLlCCNXaWCkWmGrOWhDOLlaecYdA(int P_0)
					{
						HXqlwJIDnaTQutXYkqnObIyAMmlg = P_0;
						LqrKQVmgVNVAHNKhNZvTtIPSPjkm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hXqlwJIDnaTQutXYkqnObIyAMmlg = HXqlwJIDnaTQutXYkqnObIyAMmlg;
						if (hXqlwJIDnaTQutXYkqnObIyAMmlg == -3 || hXqlwJIDnaTQutXYkqnObIyAMmlg == 1)
						{
							try
							{
							}
							finally
							{
								kmiQyzAxpaPDHnOxCiKPjvLMijvq();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int hXqlwJIDnaTQutXYkqnObIyAMmlg = HXqlwJIDnaTQutXYkqnObIyAMmlg;
							PollingHelper pollingHelper = ixAEHqEkxhwcpFdCjUvYuBuCkFY;
							switch (hXqlwJIDnaTQutXYkqnObIyAMmlg)
							{
							default:
								return false;
							case 0:
							{
								HXqlwJIDnaTQutXYkqnObIyAMmlg = -1;
								if (NOGkHCPqmNNLttBOWFfCSctYJthP < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(NOGkHCPqmNNLttBOWFfCSctYJthP);
								if (joystick == null)
								{
									return false;
								}
								LvoqtKoRqSuIUYmHZpZffwOWiJfN = joystick.PollForAllElementsDown().GetEnumerator();
								HXqlwJIDnaTQutXYkqnObIyAMmlg = -3;
								break;
							}
							case 1:
								HXqlwJIDnaTQutXYkqnObIyAMmlg = -3;
								break;
							}
							if (LvoqtKoRqSuIUYmHZpZffwOWiJfN.MoveNext())
							{
								ControllerPollingInfo current = LvoqtKoRqSuIUYmHZpZffwOWiJfN.Current;
								ControllerPollingInfo tmPprhLPueNfvkzMKDQdkXjSomSk = new ControllerPollingInfo(current);
								tmPprhLPueNfvkzMKDQdkXjSomSk.playerId = pollingHelper.mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
								TmPprhLPueNfvkzMKDQdkXjSomSk = tmPprhLPueNfvkzMKDQdkXjSomSk;
								HXqlwJIDnaTQutXYkqnObIyAMmlg = 1;
								return true;
							}
							kmiQyzAxpaPDHnOxCiKPjvLMijvq();
							LvoqtKoRqSuIUYmHZpZffwOWiJfN = null;
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

					private void kmiQyzAxpaPDHnOxCiKPjvLMijvq()
					{
						HXqlwJIDnaTQutXYkqnObIyAMmlg = -1;
						if (LvoqtKoRqSuIUYmHZpZffwOWiJfN != null)
						{
							LvoqtKoRqSuIUYmHZpZffwOWiJfN.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						kVLlCCNXaWCkWmGrOWhDOLlaecYdA kVLlCCNXaWCkWmGrOWhDOLlaecYdA2;
						if (HXqlwJIDnaTQutXYkqnObIyAMmlg == -2 && LqrKQVmgVNVAHNKhNZvTtIPSPjkm == Environment.CurrentManagedThreadId)
						{
							HXqlwJIDnaTQutXYkqnObIyAMmlg = 0;
							kVLlCCNXaWCkWmGrOWhDOLlaecYdA2 = this;
						}
						else
						{
							kVLlCCNXaWCkWmGrOWhDOLlaecYdA2 = new kVLlCCNXaWCkWmGrOWhDOLlaecYdA(0);
							kVLlCCNXaWCkWmGrOWhDOLlaecYdA2.ixAEHqEkxhwcpFdCjUvYuBuCkFY = ixAEHqEkxhwcpFdCjUvYuBuCkFY;
						}
						kVLlCCNXaWCkWmGrOWhDOLlaecYdA2.NOGkHCPqmNNLttBOWFfCSctYJthP = EQBkTeDbCbBWpcxgrUnsZnxBZsXo;
						return kVLlCCNXaWCkWmGrOWhDOLlaecYdA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player mOCsmmeKqwHJjkmeEEcrjEbVscJd;

				private readonly ControllerHelper aYUvFeshgpAmcuErTKzzhaHNdSLg;

				private readonly int zYOIvfMLxIbBPQRReOcafpAKOCfy;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					zYOIvfMLxIbBPQRReOcafpAKOCfy = ReInput.id;
					mOCsmmeKqwHJjkmeEEcrjEbVscJd = P_0;
					aYUvFeshgpAmcuErTKzzhaHNdSLg = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gZDMEvljckxmLdjDYaHQAnhBsIAeA(), 
						ControllerType.Joystick => CMqBatYQfeUObDFEyYvnFLARGJtU(controllerId), 
						ControllerType.Mouse => GnPtegQlqtycfNWliDynohpxQTKl(), 
						ControllerType.Custom => khbCCnSyvIbOxIsEvTKaOrTnfDWx(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => SVDaiCtsnKRcaUzmnFixWvVUGbGl(), 
						ControllerType.Joystick => MTBVZMeZWxLhlCraUtoxHofFbERg(controllerId), 
						ControllerType.Mouse => vHIpEGCZEEjwApWaeBtcSkfplRJv(), 
						ControllerType.Custom => cHspTcQIVwmmUKswTPgxTfyRDAiu(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gZDMEvljckxmLdjDYaHQAnhBsIAeA(), 
						ControllerType.Joystick => IaPhDCelzTNxrxidVRSUYPcPnhLUA(controllerId), 
						ControllerType.Mouse => pvSdNuUDkpkWcTFxigQOfywlfojdA(), 
						ControllerType.Custom => AfeKoUdEVntcwMsyRTpZlXrgUWgb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => SVDaiCtsnKRcaUzmnFixWvVUGbGl(), 
						ControllerType.Joystick => GwzjNfNEGMsDasEoNVqAruFZwkdN(controllerId), 
						ControllerType.Mouse => gGPbrzrwQoKOEnTLFGEEyVAjgTqu(), 
						ControllerType.Custom => LybdlrAVayIDhTbjzynLHznfZhQfA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA(), 
						ControllerType.Joystick => wnWsEaPemSKqZRfXdulWEJpxpuJl(controllerId), 
						ControllerType.Mouse => odFFlYCOvFXJpmDdKliDSWPByonbA(), 
						ControllerType.Custom => tiajdzGVYALVVSjkzdteICusHRTb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tAlCysxntPLowBHEucpCjDkVnSXjA(), 
						ControllerType.Joystick => LTimabYSknHUPDudYLwwdjRIJRwYA(controllerId), 
						ControllerType.Mouse => kKCbJFzvlxEdvYTtruEntCDwRfng(), 
						ControllerType.Custom => mbnGYAbRlDwaAIOMZbqDnTIJlIoPA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UiyUgaoVoDbfsGFDsjqskTUInJHm(), 
						ControllerType.Joystick => hxcOcWLVOpHXZUySXiUSBrDtYsjJ(controllerId), 
						ControllerType.Mouse => aaGLsdxhrWHBhhMYrmSSFecDQWXc(), 
						ControllerType.Custom => eTTAJSJvLxnZXFWuzkEbmuluWKsbA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tAlCysxntPLowBHEucpCjDkVnSXjA(), 
						ControllerType.Joystick => cevTIoFvlpVeLAiLzHRYZduJeiHeA(controllerId), 
						ControllerType.Mouse => dkOmuzAGGVdUYEVdgAgVmYxrREbxA(), 
						ControllerType.Custom => lvYqcGhmJQVWSZNNVNBYciBjPXAE(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UiyUgaoVoDbfsGFDsjqskTUInJHm(), 
						ControllerType.Joystick => DOZyhXnpuqRibejNDoBJvgdjPvBq(controllerId), 
						ControllerType.Mouse => UuPNAinucKUMgKOxDvmzKYmdcYac(), 
						ControllerType.Custom => kivawVYOYlqPfFxUqDthdOuCFqOu(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => tODGhcFeTjWEVTpjeqHfXKrRIDhF(controllerId), 
						ControllerType.Mouse => TCswsTmciWkVstooOiAWwjTPdXcp(), 
						ControllerType.Custom => AMndJmEUZeQijUAWhRxcgzhEwmzFA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gZDMEvljckxmLdjDYaHQAnhBsIAeA(), 
						ControllerType.Joystick => YyIzZBCYIuHynqAsyDwxCPXyjjMh(), 
						ControllerType.Mouse => GnPtegQlqtycfNWliDynohpxQTKl(), 
						ControllerType.Custom => kUVQEFNPdWNCEASMOjPKjAkQSDNGA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gZDMEvljckxmLdjDYaHQAnhBsIAeA(), 
						ControllerType.Joystick => OxtlVNDjyfrPbnFVlFDQdxgSCXNhA(), 
						ControllerType.Mouse => pvSdNuUDkpkWcTFxigQOfywlfojdA(), 
						ControllerType.Custom => LKJzxfQAcrFaUYTglElsEOmcwYeT(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => SVDaiCtsnKRcaUzmnFixWvVUGbGl(), 
						ControllerType.Joystick => vhnLhXTjnhcyxhPZFCalybgXMaxjA(), 
						ControllerType.Mouse => gGPbrzrwQoKOEnTLFGEEyVAjgTqu(), 
						ControllerType.Custom => aLvDuhxbufaytSteZyYIGEwdMeXi(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA(), 
						ControllerType.Joystick => vnqgGstbgYWeWpAfztfJzcnejArO(), 
						ControllerType.Mouse => odFFlYCOvFXJpmDdKliDSWPByonbA(), 
						ControllerType.Custom => tXdXuAAtXKucEwddefUqDyPtjBHiA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tAlCysxntPLowBHEucpCjDkVnSXjA(), 
						ControllerType.Joystick => wiDtqtwGjrCFwAFQohnBHEvHrnJy(), 
						ControllerType.Mouse => kKCbJFzvlxEdvYTtruEntCDwRfng(), 
						ControllerType.Custom => yacRgkWIKmDpXMvlFBpvsuunLCZh(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UiyUgaoVoDbfsGFDsjqskTUInJHm(), 
						ControllerType.Joystick => STpjfACBByLfMpJEXJtahCzkEQVGA(), 
						ControllerType.Mouse => aaGLsdxhrWHBhhMYrmSSFecDQWXc(), 
						ControllerType.Custom => yoPEaJtqGXuejMJcUBUmaByimYrT(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tAlCysxntPLowBHEucpCjDkVnSXjA(), 
						ControllerType.Joystick => glumupTrirnaOTTlJPMUHyFRSDhy(), 
						ControllerType.Mouse => dkOmuzAGGVdUYEVdgAgVmYxrREbxA(), 
						ControllerType.Custom => NgrHqnQAdxMmEpooEeyaMpZBTVGB(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UiyUgaoVoDbfsGFDsjqskTUInJHm(), 
						ControllerType.Joystick => EolZOJBEcedslBYSkJZnqouPXBbQ(), 
						ControllerType.Mouse => UuPNAinucKUMgKOxDvmzKYmdcYac(), 
						ControllerType.Custom => gXZfZzicChPYmraFqGtynTCBjbHv(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != zYOIvfMLxIbBPQRReOcafpAKOCfy)
					{
						ReInput.CheckInitialized(zYOIvfMLxIbBPQRReOcafpAKOCfy);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => ZAYlREiEFeoHpiqSjoEQvBGeefDE(), 
						ControllerType.Mouse => TCswsTmciWkVstooOiAWwjTPdXcp(), 
						ControllerType.Custom => sdgQirNdgFjOGBfwiZzIKDtZeWNy(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo CMqBatYQfeUObDFEyYvnFLARGJtU(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					Joystick joystick = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo MTBVZMeZWxLhlCraUtoxHofFbERg(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					Joystick joystick = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo IaPhDCelzTNxrxidVRSUYPcPnhLUA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					Joystick joystick = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo GwzjNfNEGMsDasEoNVqAruFZwkdN(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					Joystick joystick = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo wnWsEaPemSKqZRfXdulWEJpxpuJl(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					Joystick joystick = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				[IteratorStateMachine(typeof(hABQLZkSeWiAVhNHWeaPKjAtMxsCA))]
				private IEnumerable<ControllerPollingInfo> LTimabYSknHUPDudYLwwdjRIJRwYA(int P_0)
				{
					return new hABQLZkSeWiAVhNHWeaPKjAtMxsCA(-2)
					{
						OfycGLbadqfNfnpqefGLmEpdGXEwA = this,
						jMPapYGZUTEzLvIByKXxrRFsEaih = P_0
					};
				}

				[IteratorStateMachine(typeof(kVLlCCNXaWCkWmGrOWhDOLlaecYdA))]
				private IEnumerable<ControllerPollingInfo> hxcOcWLVOpHXZUySXiUSBrDtYsjJ(int P_0)
				{
					return new kVLlCCNXaWCkWmGrOWhDOLlaecYdA(-2)
					{
						ixAEHqEkxhwcpFdCjUvYuBuCkFY = this,
						EQBkTeDbCbBWpcxgrUnsZnxBZsXo = P_0
					};
				}

				[IteratorStateMachine(typeof(yczyEaNmKeaSSrqDQyVkkFKrRgGV))]
				private IEnumerable<ControllerPollingInfo> cevTIoFvlpVeLAiLzHRYZduJeiHeA(int P_0)
				{
					return new yczyEaNmKeaSSrqDQyVkkFKrRgGV(-2)
					{
						dIVzRojEtWPKWiPekNFSgGmMfDvx = this,
						NjpVWAbBVCTWusCHxbeDgOKFEsLW = P_0
					};
				}

				[IteratorStateMachine(typeof(HYucLxrCNoCHJiYvYBpKDEDfYQXIB))]
				private IEnumerable<ControllerPollingInfo> DOZyhXnpuqRibejNDoBJvgdjPvBq(int P_0)
				{
					return new HYucLxrCNoCHJiYvYBpKDEDfYQXIB(-2)
					{
						nGqcSTACDSqHkbCEJkeyrDFQtMppA = this,
						dPHfvvIEjomOrGOjYjjbMHKxMZRb = P_0
					};
				}

				[IteratorStateMachine(typeof(nelGsczZlrHeDegzDstuRPxieTHE))]
				private IEnumerable<ControllerPollingInfo> tODGhcFeTjWEVTpjeqHfXKrRIDhF(int P_0)
				{
					return new nelGsczZlrHeDegzDstuRPxieTHE(-2)
					{
						WRerwmjSOmrbHJHMTBvpzwIsxEoi = this,
						HzZyiSVftSGjXizadMsaOfbNGSEv = P_0
					};
				}

				private ControllerPollingInfo YyIzZBCYIuHynqAsyDwxCPXyjjMh()
				{
					IList<Joystick> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo bVKqrGAqjivBTzcpjxecMuDPjcmW()
				{
					IList<Joystick> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo OxtlVNDjyfrPbnFVlFDQdxgSCXNhA()
				{
					IList<Joystick> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo vhnLhXTjnhcyxhPZFCalybgXMaxjA()
				{
					IList<Joystick> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo vnqgGstbgYWeWpAfztfJzcnejArO()
				{
					IList<Joystick> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.nsqaHMJRypoBaiNKqPflbeoJljtcc.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				[IteratorStateMachine(typeof(MXXxXOvdvVqOdzRZXBQIcRpmOrxgb))]
				private IEnumerable<ControllerPollingInfo> wiDtqtwGjrCFwAFQohnBHEvHrnJy()
				{
					return new MXXxXOvdvVqOdzRZXBQIcRpmOrxgb(-2)
					{
						IhxzpUxEKcFwMiNzrKVxfblaiQBhb = this
					};
				}

				[IteratorStateMachine(typeof(cYdBUibeWkjBsfQQhqwJBHojPMehD))]
				private IEnumerable<ControllerPollingInfo> STpjfACBByLfMpJEXJtahCzkEQVGA()
				{
					return new cYdBUibeWkjBsfQQhqwJBHojPMehD(-2)
					{
						qCDEXnFiZjNMOFforjKoyHcNhXUzA = this
					};
				}

				[IteratorStateMachine(typeof(BrEbtGUPgVNwAqFRYoyxgPRvGvZT))]
				private IEnumerable<ControllerPollingInfo> glumupTrirnaOTTlJPMUHyFRSDhy()
				{
					return new BrEbtGUPgVNwAqFRYoyxgPRvGvZT(-2)
					{
						iPHELmBtBoYPjZckPFNmiTbBCMcEA = this
					};
				}

				[IteratorStateMachine(typeof(mFSvPYDVwUugxYGutasAuLDHwFCG))]
				private IEnumerable<ControllerPollingInfo> EolZOJBEcedslBYSkJZnqouPXBbQ()
				{
					return new mFSvPYDVwUugxYGutasAuLDHwFCG(-2)
					{
						kiTPPPOUTNggCVcawjsKHFWhCgfP = this
					};
				}

				[IteratorStateMachine(typeof(hOyykamskuEiribcCWCFsqUcoDwd))]
				private IEnumerable<ControllerPollingInfo> ZAYlREiEFeoHpiqSjoEQvBGeefDE()
				{
					return new hOyykamskuEiribcCWCFsqUcoDwd(-2)
					{
						OBfbHufbKdIhLJnuUNVhoHdJEzFF = this
					};
				}

				private ControllerPollingInfo gZDMEvljckxmLdjDYaHQAnhBsIAeA()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.VIygShhdlkkGoNLzLunyBKxrIoNx)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo SVDaiCtsnKRcaUzmnFixWvVUGbGl()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.VIygShhdlkkGoNLzLunyBKxrIoNx)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> tAlCysxntPLowBHEucpCjDkVnSXjA()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.VIygShhdlkkGoNLzLunyBKxrIoNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> UiyUgaoVoDbfsGFDsjqskTUInJHm()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.VIygShhdlkkGoNLzLunyBKxrIoNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo GnPtegQlqtycfNWliDynohpxQTKl()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo vHIpEGCZEEjwApWaeBtcSkfplRJv()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo pvSdNuUDkpkWcTFxigQOfywlfojdA()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo gGPbrzrwQoKOEnTLFGEEyVAjgTqu()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo odFFlYCOvFXJpmDdKliDSWPByonbA()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> kKCbJFzvlxEdvYTtruEntCDwRfng()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> aaGLsdxhrWHBhhMYrmSSFecDQWXc()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> dkOmuzAGGVdUYEVdgAgVmYxrREbxA()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> UuPNAinucKUMgKOxDvmzKYmdcYac()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> TCswsTmciWkVstooOiAWwjTPdXcp()
				{
					if (!aYUvFeshgpAmcuErTKzzhaHNdSLg.npVlBITUuAGcohoQfGvxQtRwgJJjA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return aYUvFeshgpAmcuErTKzzhaHNdSLg.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo khbCCnSyvIbOxIsEvTKaOrTnfDWx(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					CustomController customController = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo cHspTcQIVwmmUKswTPgxTfyRDAiu(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					CustomController customController = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo AfeKoUdEVntcwMsyRTpZlXrgUWgb(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					CustomController customController = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo LybdlrAVayIDhTbjzynLHznfZhQfA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					CustomController customController = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				private ControllerPollingInfo tiajdzGVYALVVSjkzdteICusHRTb(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					CustomController customController = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.IQqufKJAvGLbeYSsNBHECdpKEWPn(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
					}
					return result;
				}

				[IteratorStateMachine(typeof(IiVhGogIgYYHgJqjoZkNHiuabGViA))]
				private IEnumerable<ControllerPollingInfo> mbnGYAbRlDwaAIOMZbqDnTIJlIoPA(int P_0)
				{
					return new IiVhGogIgYYHgJqjoZkNHiuabGViA(-2)
					{
						EotDfdDbXmZUDeESXmzUKOmhqUyUA = this,
						aVcvIppYWuLuZoqBMifRyhdsItIx = P_0
					};
				}

				[IteratorStateMachine(typeof(VYCWXsAONndAYIaRWIckdcvhAVso))]
				private IEnumerable<ControllerPollingInfo> eTTAJSJvLxnZXFWuzkEbmuluWKsbA(int P_0)
				{
					return new VYCWXsAONndAYIaRWIckdcvhAVso(-2)
					{
						GVdYWWSQvGNobDUcvQSUFrYDatXh = this,
						BgYHNmJiQdajEgEaIZVzhdyCskPQ = P_0
					};
				}

				[IteratorStateMachine(typeof(zhpQRbhhnzTSpxZvjQTnwmdohDtz))]
				private IEnumerable<ControllerPollingInfo> lvYqcGhmJQVWSZNNVNBYciBjPXAE(int P_0)
				{
					return new zhpQRbhhnzTSpxZvjQTnwmdohDtz(-2)
					{
						ZzBGxZaeLaoDbTkeQkVELAkPfFKy = this,
						VqAXBCeTkzstEDplgLHLZCgBZJmQ = P_0
					};
				}

				[IteratorStateMachine(typeof(UTOtAFWtXmDfbHGYCtWBeJPpmQth))]
				private IEnumerable<ControllerPollingInfo> kivawVYOYlqPfFxUqDthdOuCFqOu(int P_0)
				{
					return new UTOtAFWtXmDfbHGYCtWBeJPpmQth(-2)
					{
						GRkVLDYirhviYITGYrrQblIEtVfY = this,
						MphoLCgRRXhHBxBZaFowCLrbgMep = P_0
					};
				}

				[IteratorStateMachine(typeof(FoxuNgqKwUaFDdxnSAOYSdEzuSbm))]
				private IEnumerable<ControllerPollingInfo> AMndJmEUZeQijUAWhRxcgzhEwmzFA(int P_0)
				{
					return new FoxuNgqKwUaFDdxnSAOYSdEzuSbm(-2)
					{
						hYeEOdsHIwGyMSckEDihWMXMhlpA = this,
						haiqeooIJiCLgHzxkBqlesBYiLcxA = P_0
					};
				}

				private ControllerPollingInfo kUVQEFNPdWNCEASMOjPKjAkQSDNGA()
				{
					IList<CustomController> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo OmkLflhzHxwIkZOnlFxyNUwPExJZ()
				{
					IList<CustomController> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo LKJzxfQAcrFaUYTglElsEOmcwYeT()
				{
					IList<CustomController> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo aLvDuhxbufaytSteZyYIGEwdMeXi()
				{
					IList<CustomController> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo tXdXuAAtXKucEwddefUqDyPtjBHiA()
				{
					IList<CustomController> list = aYUvFeshgpAmcuErTKzzhaHNdSLg.GfTgEEjlXpJyESOaZaYqHyCNHnys.pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = mOCsmmeKqwHJjkmeEEcrjEbVscJd.QCUoYDqLLDFsRwBhDegcxJcsDftHA;
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				[IteratorStateMachine(typeof(meohdhlcdnHcVQYwmImlyDKDxteK))]
				private IEnumerable<ControllerPollingInfo> yacRgkWIKmDpXMvlFBpvsuunLCZh()
				{
					return new meohdhlcdnHcVQYwmImlyDKDxteK(-2)
					{
						YoikQoVCwUiLhZGTHvLBiHvOxDb = this
					};
				}

				[IteratorStateMachine(typeof(xfWOQvGuOhTIikMhkoVZXzKZqVHe))]
				private IEnumerable<ControllerPollingInfo> yoPEaJtqGXuejMJcUBUmaByimYrT()
				{
					return new xfWOQvGuOhTIikMhkoVZXzKZqVHe(-2)
					{
						WFFTnKnjjmnUodWCKmOxjEvxXTdf = this
					};
				}

				[IteratorStateMachine(typeof(IBoAtbCcohWSxhwiUgtKWJlqFfSD))]
				private IEnumerable<ControllerPollingInfo> NgrHqnQAdxMmEpooEeyaMpZBTVGB()
				{
					return new IBoAtbCcohWSxhwiUgtKWJlqFfSD(-2)
					{
						ESDLiDuzAdVPSxslEoVTTpLVVOwJ = this
					};
				}

				[IteratorStateMachine(typeof(BeIxOPxDAiWKCPTNVqFoVannihHeA))]
				private IEnumerable<ControllerPollingInfo> gXZfZzicChPYmraFqGtynTCBjbHv()
				{
					return new BeIxOPxDAiWKCPTNVqFoVannihHeA(-2)
					{
						LeQvfcdgqwfdTQqlzCIPDxhMCGoR = this
					};
				}

				[IteratorStateMachine(typeof(mDZTdyVsPDNINFDbReXQLkWvyTME))]
				private IEnumerable<ControllerPollingInfo> sdgQirNdgFjOGBfwiZzIKDtZeWNy()
				{
					return new mDZTdyVsPDNINFDbReXQLkWvyTME(-2)
					{
						GAogPhFteIJbRgwOTTwgpzwjeuTS = this
					};
				}
			}

			[Serializable]
			private sealed class WpGFuQmmBbFiTDaUKTFvxlqjEIWBA
			{
				public static readonly WpGFuQmmBbFiTDaUKTFvxlqjEIWBA _003C_003E9 = new WpGFuQmmBbFiTDaUKTFvxlqjEIWBA();

				public static Action<Exception> _003C_003E9__23_0;

				public static Action<Exception> _003C_003E9__23_1;

				internal void YSCQQwnnCnbNdudOalAHXewinoBX(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void WEHrjSNdrYzijvjNjoUXkDKLxUed(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class EKPgwOVmHRApFJCMfHPUhHUpWrFu : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
			{
				private int ZXeGCOxhScxlWZDIlVPAnewPazOm;

				private Controller JFvkSRlDNuKbJULdhGzBNSQyAxMW;

				private int sABqhthrGHNWIrnNuznfALLSKhnA;

				public ControllerHelper rofjRJVBaalbjFSKRAfyFkcLtgYP;

				private int cEbUlQLIHZGshjpbkDCgKZXHngLqA;

				private IList<Joystick> qmbMiUCFkWtPAceuuhOuDlJtRURX;

				private int fBIsXdngENhlLIYrkDCOYnFpvSKbA;

				private IList<CustomController> niyknxOXxvIsVQTYKidTqHIQizFm;

				private int zlRIuIleNAqXrQWamSFllRKVLvOr;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return JFvkSRlDNuKbJULdhGzBNSQyAxMW;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return JFvkSRlDNuKbJULdhGzBNSQyAxMW;
					}
				}

				[DebuggerHidden]
				public EKPgwOVmHRApFJCMfHPUhHUpWrFu(int P_0)
				{
					ZXeGCOxhScxlWZDIlVPAnewPazOm = P_0;
					sABqhthrGHNWIrnNuznfALLSKhnA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zXeGCOxhScxlWZDIlVPAnewPazOm = ZXeGCOxhScxlWZDIlVPAnewPazOm;
					ControllerHelper controllerHelper = rofjRJVBaalbjFSKRAfyFkcLtgYP;
					switch (zXeGCOxhScxlWZDIlVPAnewPazOm)
					{
					default:
						return false;
					case 0:
						ZXeGCOxhScxlWZDIlVPAnewPazOm = -1;
						if (ReInput._id != controllerHelper.wfmuXIaoakKjmqWgarKGApFWiAIK)
						{
							ReInput.CheckInitialized(controllerHelper.wfmuXIaoakKjmqWgarKGApFWiAIK);
							return false;
						}
						if (controllerHelper.npVlBITUuAGcohoQfGvxQtRwgJJjA)
						{
							JFvkSRlDNuKbJULdhGzBNSQyAxMW = controllerHelper.Mouse;
							ZXeGCOxhScxlWZDIlVPAnewPazOm = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						ZXeGCOxhScxlWZDIlVPAnewPazOm = -1;
						goto IL_0070;
					case 2:
						ZXeGCOxhScxlWZDIlVPAnewPazOm = -1;
						goto IL_0094;
					case 3:
						ZXeGCOxhScxlWZDIlVPAnewPazOm = -1;
						zlRIuIleNAqXrQWamSFllRKVLvOr++;
						goto IL_00ec;
					case 4:
						{
							ZXeGCOxhScxlWZDIlVPAnewPazOm = -1;
							zlRIuIleNAqXrQWamSFllRKVLvOr++;
							break;
						}
						IL_0094:
						cEbUlQLIHZGshjpbkDCgKZXHngLqA = controllerHelper.joystickCount;
						qmbMiUCFkWtPAceuuhOuDlJtRURX = controllerHelper.Joysticks;
						zlRIuIleNAqXrQWamSFllRKVLvOr = 0;
						goto IL_00ec;
						IL_00ec:
						if (zlRIuIleNAqXrQWamSFllRKVLvOr < cEbUlQLIHZGshjpbkDCgKZXHngLqA)
						{
							JFvkSRlDNuKbJULdhGzBNSQyAxMW = qmbMiUCFkWtPAceuuhOuDlJtRURX[zlRIuIleNAqXrQWamSFllRKVLvOr];
							ZXeGCOxhScxlWZDIlVPAnewPazOm = 3;
							return true;
						}
						fBIsXdngENhlLIYrkDCOYnFpvSKbA = controllerHelper.customControllerCount;
						niyknxOXxvIsVQTYKidTqHIQizFm = controllerHelper.CustomControllers;
						zlRIuIleNAqXrQWamSFllRKVLvOr = 0;
						break;
						IL_0070:
						if (controllerHelper.VIygShhdlkkGoNLzLunyBKxrIoNx)
						{
							JFvkSRlDNuKbJULdhGzBNSQyAxMW = controllerHelper.Keyboard;
							ZXeGCOxhScxlWZDIlVPAnewPazOm = 2;
							return true;
						}
						goto IL_0094;
					}
					if (zlRIuIleNAqXrQWamSFllRKVLvOr < fBIsXdngENhlLIYrkDCOYnFpvSKbA)
					{
						JFvkSRlDNuKbJULdhGzBNSQyAxMW = niyknxOXxvIsVQTYKidTqHIQizFm[zlRIuIleNAqXrQWamSFllRKVLvOr];
						ZXeGCOxhScxlWZDIlVPAnewPazOm = 4;
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
				IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator()
				{
					EKPgwOVmHRApFJCMfHPUhHUpWrFu eKPgwOVmHRApFJCMfHPUhHUpWrFu;
					if (ZXeGCOxhScxlWZDIlVPAnewPazOm == -2 && sABqhthrGHNWIrnNuznfALLSKhnA == Environment.CurrentManagedThreadId)
					{
						ZXeGCOxhScxlWZDIlVPAnewPazOm = 0;
						eKPgwOVmHRApFJCMfHPUhHUpWrFu = this;
					}
					else
					{
						eKPgwOVmHRApFJCMfHPUhHUpWrFu = new EKPgwOVmHRApFJCMfHPUhHUpWrFu(0);
						eKPgwOVmHRApFJCMfHPUhHUpWrFu.rofjRJVBaalbjFSKRAfyFkcLtgYP = rofjRJVBaalbjFSKRAfyFkcLtgYP;
					}
					return eKPgwOVmHRApFJCMfHPUhHUpWrFu;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly PGHOuYhTMIlgfkLkxnNQDmeZfWZu AcfCfNjbBhWbVvFwHWSElpzdBveZ;

			private bool npVlBITUuAGcohoQfGvxQtRwgJJjA;

			private bool VIygShhdlkkGoNLzLunyBKxrIoNx;

			private bool pjwfGXGjNzImpkarbFHDAZncDejA;

			private double AsuSLNnhYgIDPuKBPMKMAtCrUGDH;

			private double GnzBAtkWMUkcVnMJmNHZkEncOFHXA;

			private SafeAction<ControllerAssignmentChangedEventArgs> VFomvQUIhOdKXuAYaUnjPxBBulJM = new SafeAction<ControllerAssignmentChangedEventArgs>(WpGFuQmmBbFiTDaUKTFvxlqjEIWBA._003C_003E9.YSCQQwnnCnbNdudOalAHXewinoBX);

			private SafeAction<ControllerAssignmentChangedEventArgs> nawYRGqGpdIWXfhzdnFdVTYHifDYA = new SafeAction<ControllerAssignmentChangedEventArgs>(WpGFuQmmBbFiTDaUKTFvxlqjEIWBA._003C_003E9.WEHrjSNdrYzijvjNjoUXkDKLxUed);

			private readonly ClezMzHGVattqKgyOdCeSSlvJsdy vdnCirvuIizHaUoSqnEPbKLjQhml;

			private readonly Player jCNyzhPxVMAruYwdvzvqZVDwhvmG;

			private readonly luVyYQZUAigRpetoezTKghxXGpjb QaVOTlMKqtePvdUDliIHWUSijhqk;

			private readonly int wfmuXIaoakKjmqWgarKGApFWiAIK;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap> nsqaHMJRypoBaiNKqPflbeoJljtcc => (TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick);

			private global::vvqWcefspViLvBkIonynvYaRLpFT<KeyboardMap> ePfiMHzGjpesAJnXbjUSelvGCgSwA => (global::vvqWcefspViLvBkIonynvYaRLpFT<KeyboardMap>)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Keyboard).QlllfGYgQhzrYUdVBsXmntapKYEs(0).iuMldFPvAqBfeiUXQrGwudCQSSbq;

			private global::vvqWcefspViLvBkIonynvYaRLpFT<MouseMap> NyePHlzdYcQlmXMNKIEWEhoQBjbd => (global::vvqWcefspViLvBkIonynvYaRLpFT<MouseMap>)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Mouse).QlllfGYgQhzrYUdVBsXmntapKYEs(0).iuMldFPvAqBfeiUXQrGwudCQSSbq;

			private TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap> GfTgEEjlXpJyESOaZaYqHyCNHnys => (TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return false;
					}
					return npVlBITUuAGcohoQfGvxQtRwgJJjA;
				}
				set
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						if (npVlBITUuAGcohoQfGvxQtRwgJJjA == value)
						{
							return;
						}
						npVlBITUuAGcohoQfGvxQtRwgJJjA = value;
						if (value)
						{
							QaVOTlMKqtePvdUDliIHWUSijhqk.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(Mouse);
						}
						else
						{
							QaVOTlMKqtePvdUDliIHWUSijhqk.mcLDGeazCzmWxNKScdthBzTSViJc(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (VFomvQUIhOdKXuAYaUnjPxBBulJM.Count > 0)
							{
								VFomvQUIhOdKXuAYaUnjPxBBulJM.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (nawYRGqGpdIWXfhzdnFdVTYHifDYA.Count > 0)
						{
							nawYRGqGpdIWXfhzdnFdVTYHifDYA.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return false;
					}
					return VIygShhdlkkGoNLzLunyBKxrIoNx;
				}
				set
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						if (VIygShhdlkkGoNLzLunyBKxrIoNx == value)
						{
							return;
						}
						VIygShhdlkkGoNLzLunyBKxrIoNx = value;
						if (value)
						{
							QaVOTlMKqtePvdUDliIHWUSijhqk.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(Keyboard);
						}
						else
						{
							QaVOTlMKqtePvdUDliIHWUSijhqk.mcLDGeazCzmWxNKScdthBzTSViJc(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (VFomvQUIhOdKXuAYaUnjPxBBulJM.Count > 0)
							{
								VFomvQUIhOdKXuAYaUnjPxBBulJM.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (nawYRGqGpdIWXfhzdnFdVTYHifDYA.Count > 0)
						{
							nawYRGqGpdIWXfhzdnFdVTYHifDYA.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return false;
					}
					return pjwfGXGjNzImpkarbFHDAZncDejA;
				}
				set
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						pjwfGXGjNzImpkarbFHDAZncDejA = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return 0;
					}
					return AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick).FwIGimYHKsSdutRnXvajJeatuVHB;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick) as TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>).pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return 0;
					}
					return AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom).FwIGimYHKsSdutRnXvajJeatuVHB;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom) as TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>).pXSxwkIiHkcbzcvFuFlFiSHpDWydA;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				[IteratorStateMachine(typeof(EKPgwOVmHRApFJCMfHPUhHUpWrFu))]
				get
				{
					return new EKPgwOVmHRApFJCMfHPUhHUpWrFu(-2)
					{
						rofjRJVBaalbjFSKRAfyFkcLtgYP = this
					};
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					VFomvQUIhOdKXuAYaUnjPxBBulJM.AddDelegate(value);
				}
				remove
				{
					VFomvQUIhOdKXuAYaUnjPxBBulJM.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					nawYRGqGpdIWXfhzdnFdVTYHifDYA.AddDelegate(value);
				}
				remove
				{
					nawYRGqGpdIWXfhzdnFdVTYHifDYA.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, wsTGaisyEgVqWobCcVTBhcYPpDji P_1, ControllerMapLayoutManager.ccDuPLOhlbrAqOTHJEHJSRpBmDEb P_2, ControllerMapEnabler.ybCAJZdDMTpCNSaMwMfysgFQeUXm P_3)
			{
				wfmuXIaoakKjmqWgarKGApFWiAIK = ReInput.id;
				jCNyzhPxVMAruYwdvzvqZVDwhvmG = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				AcfCfNjbBhWbVvFwHWSElpzdBveZ = new PGHOuYhTMIlgfkLkxnNQDmeZfWZu(4);
				AcfCfNjbBhWbVvFwHWSElpzdBveZ.mMHlffAECEsojiLNkhxeuVYngPRR(0, ControllerType.Joystick, new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>());
				AcfCfNjbBhWbVvFwHWSElpzdBveZ.mMHlffAECEsojiLNkhxeuVYngPRR(1, ControllerType.Keyboard, new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Keyboard, KeyboardMap>());
				AcfCfNjbBhWbVvFwHWSElpzdBveZ.mMHlffAECEsojiLNkhxeuVYngPRR(2, ControllerType.Mouse, new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Mouse, MouseMap>());
				AcfCfNjbBhWbVvFwHWSElpzdBveZ.mMHlffAECEsojiLNkhxeuVYngPRR(3, ControllerType.Custom, new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>());
				vdnCirvuIizHaUoSqnEPbKLjQhml = new ClezMzHGVattqKgyOdCeSSlvJsdy(P_0);
				QaVOTlMKqtePvdUDliIHWUSijhqk = new luVyYQZUAigRpetoezTKghxXGpjb(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				return (T)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(SVQbmGoCgjXlQooYDoNZCFflMVzP.GpDEkhsBiqfPoBLEipLBKrkLdvuKA<T>()).TboWkWvykGGIbVogRCGoTdcLCrUW(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				return AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType).TboWkWvykGGIbVogRCGoTdcLCrUW(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				return (T)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(SVQbmGoCgjXlQooYDoNZCFflMVzP.GpDEkhsBiqfPoBLEipLBKrkLdvuKA<T>()).SfhVyrnbGHBXzmosWNNspAwTFPwg(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				return AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(controllerType).SfhVyrnbGHBXzmosWNNspAwTFPwg(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					bfSdvCGPOhcBXbdAxqrhIhHPTPlcA(controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					AddController(ControllerType.Keyboard, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					AddController(ControllerType.Mouse, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					WCnRXsNDykhDXapITllciTSeiWOk(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						PPdwvLjDdXACcjBWqTJSqmLQuijqA(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						IUPlYNsSLxOsntNkkdjuBmtCQenBb(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					PPdwvLjDdXACcjBWqTJSqmLQuijqA(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
					break;
				case ControllerType.Keyboard:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasKeyboard = true;
					break;
				case ControllerType.Mouse:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasMouse = true;
					break;
				case ControllerType.Custom:
					IUPlYNsSLxOsntNkkdjuBmtCQenBb(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					XWGDDYvtrpbEwHTePDQsGjJxmSmeA(controllerId);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					RemoveController(ControllerType.Keyboard, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					RemoveController(ControllerType.Mouse, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					xwVrzhEhkAQYJPcPSGCWUWEuGefl(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					XWGDDYvtrpbEwHTePDQsGjJxmSmeA(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					xwVrzhEhkAQYJPcPSGCWUWEuGefl(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						kuKQKMUyjGRckdffCfIoilNVwQYH(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						MetzsPiLEKFpbqKBxAdSiJvtHFrIb(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return VIygShhdlkkGoNLzLunyBKxrIoNx;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return npVlBITUuAGcohoQfGvxQtRwgJJjA;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick).yaFPMojfoCAlpmKQWVrPKhXZLKMn(controllerId), 
					ControllerType.Keyboard => VIygShhdlkkGoNLzLunyBKxrIoNx, 
					ControllerType.Mouse => npVlBITUuAGcohoQfGvxQtRwgJJjA, 
					ControllerType.Custom => AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom).yaFPMojfoCAlpmKQWVrPKhXZLKMn(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return false;
				}
				if (controller == null)
				{
					return false;
				}
				return ContainsController(controller.type, controller.id);
			}

			public void ClearControllersOfType<T>() where T : Controller
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					vgQcvOAmmznwjzNWKRjLkTwEibSHA();
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					hasKeyboard = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					hasMouse = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					MTYVDOkKHHjfqytUivuyjhRfOFsx();
					return;
				}
				if ((object)typeFromHandle == typeof(Controller))
				{
					ClearAllControllers();
					return;
				}
				throw new NotImplementedException();
			}

			public void ClearControllersOfType(ControllerType controllerType)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					vgQcvOAmmznwjzNWKRjLkTwEibSHA();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					MTYVDOkKHHjfqytUivuyjhRfOFsx();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return;
				}
				vgQcvOAmmznwjzNWKRjLkTwEibSHA();
				MTYVDOkKHHjfqytUivuyjhRfOFsx();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				HXJcnPeeUlLyhGwshdiApBTFqhDiA(ControllerType.Joystick, ref result, ref num);
				if (npVlBITUuAGcohoQfGvxQtRwgJJjA && AsuSLNnhYgIDPuKBPMKMAtCrUGDH > num)
				{
					result = Mouse;
					num = AsuSLNnhYgIDPuKBPMKMAtCrUGDH;
				}
				if (VIygShhdlkkGoNLzLunyBKxrIoNx && GnzBAtkWMUkcVnMJmNHZkEncOFHXA > num)
				{
					result = Keyboard;
					num = GnzBAtkWMUkcVnMJmNHZkEncOFHXA;
				}
				HXJcnPeeUlLyhGwshdiApBTFqhDiA(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					HXJcnPeeUlLyhGwshdiApBTFqhDiA(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (VIygShhdlkkGoNLzLunyBKxrIoNx && GnzBAtkWMUkcVnMJmNHZkEncOFHXA > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (npVlBITUuAGcohoQfGvxQtRwgJJjA && AsuSLNnhYgIDPuKBPMKMAtCrUGDH > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void HXJcnPeeUlLyhGwshdiApBTFqhDiA(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
				int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB;
				for (int i = 0; i < num; i++)
				{
					double num2 = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).ybVAhVaiUKVjjdhyCBrBovvlJpHc;
					if (!(num2 <= P_2))
					{
						P_1 = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(i).pQefzbMuBblbJGuGRnxcoWyVLFcD;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(SVQbmGoCgjXlQooYDoNZCFflMVzP.GpDEkhsBiqfPoBLEipLBKrkLdvuKA<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						jCNyzhPxVMAruYwdvzvqZVDwhvmG.pUcBslzzLOiQjTlQsQkqXLxySpX.sVabTNUrlETeQUUwZknIHXVWfPKt(jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						jCNyzhPxVMAruYwdvzvqZVDwhvmG.pUcBslzzLOiQjTlQsQkqXLxySpX.PBBtsPxOhCcMJVWEjxkWdunddSSf(jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						jCNyzhPxVMAruYwdvzvqZVDwhvmG.pUcBslzzLOiQjTlQsQkqXLxySpX.pobhFHImmgUdNtKdVLUhgRxuYRdOA(jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						jCNyzhPxVMAruYwdvzvqZVDwhvmG.pUcBslzzLOiQjTlQsQkqXLxySpX.xYqSQzBeNJGPJZGhmiugtwvZFAFu(jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
					{
						ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					}
					else
					{
						jCNyzhPxVMAruYwdvzvqZVDwhvmG.pUcBslzzLOiQjTlQsQkqXLxySpX.wMbbfulHXSejTabwlCgVgpFTjjKk(jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				int cdDMVOEYEeaEACfRYzOcwBUJJAEg = AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
				for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
				{
					Controller controller = FghldSmGiJEIhwYwwbRhmRaldiER(AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i).idcYZHmwzKfFqwHCdeEqJLeNeyfm, Controller.rOPITeINKEzatjJGCwWrwbTjtUdo, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return null;
				}
				int cdDMVOEYEeaEACfRYzOcwBUJJAEg = AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg;
				for (int i = 0; i < cdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
				{
					Controller controller = FghldSmGiJEIhwYwwbRhmRaldiER(AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i).idcYZHmwzKfFqwHCdeEqJLeNeyfm, Controller.YtPGVhJzckwEfcCDzOgHxmTylrAQ, templateType);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate<T>() where T : class
			{
				return GetFirstControllerWithTemplate(typeof(T));
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (ReInput._id != wfmuXIaoakKjmqWgarKGApFWiAIK)
				{
					ReInput.CheckInitialized(wfmuXIaoakKjmqWgarKGApFWiAIK);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return QaVOTlMKqtePvdUDliIHWUSijhqk.btiRIkziHJeHEgVVxcNtCxMgrcSvb<TInterface>();
			}

			private Controller FghldSmGiJEIhwYwwbRhmRaldiER<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
			{
				switch (P_0)
				{
				case ControllerType.Joystick:
				{
					int num2 = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					for (int j = 0; j < num2; j++)
					{
						if (P_1(joysticks[j], P_2))
						{
							return joysticks[j];
						}
					}
					return null;
				}
				case ControllerType.Keyboard:
					if (VIygShhdlkkGoNLzLunyBKxrIoNx && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (npVlBITUuAGcohoQfGvxQtRwgJJjA && P_1(Mouse, P_2))
					{
						return Mouse;
					}
					return null;
				case ControllerType.Custom:
				{
					int num = customControllerCount;
					IList<CustomController> customControllers = CustomControllers;
					for (int i = 0; i < num; i++)
					{
						if (P_1(customControllers[i], P_2))
						{
							return customControllers[i];
						}
					}
					return null;
				}
				default:
					throw new NotImplementedException();
				}
			}

			internal void kavHKXihabNTtFcqgcRJJGAejEYTA()
			{
				for (int i = 0; i < AcfCfNjbBhWbVvFwHWSElpzdBveZ.CdDMVOEYEeaEACfRYzOcwBUJJAEg; i++)
				{
					AcfCfNjbBhWbVvFwHWSElpzdBveZ.AQncRaVEtJlioIjHbOyFGxGWSnZE(i).CLSkRuJgRJjGgKMdtHVRtsgEFuGj();
				}
				AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Keyboard).evzuTMkhZsadeiMLXCSIMuVNyjfmA(new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Keyboard, KeyboardMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB(ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.drgNjPBDklMoqhfwuCfPMsCoXTQl, new global::vvqWcefspViLvBkIonynvYaRLpFT<KeyboardMap>(0)));
				AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Mouse).evzuTMkhZsadeiMLXCSIMuVNyjfmA(new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Mouse, MouseMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB(ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.vdLMjGufKFZFbdHWwGFoTfIgNRfT, new global::vvqWcefspViLvBkIonynvYaRLpFT<MouseMap>(0)));
				vdnCirvuIizHaUoSqnEPbKLjQhml.sDLVQweCBxoHLnqWFDKnbiJpCjCfA();
				GnzBAtkWMUkcVnMJmNHZkEncOFHXA = 0.0;
				AsuSLNnhYgIDPuKBPMKMAtCrUGDH = 0.0;
				maps.fRhGpSCPIRrCppVeVncCBMljliwlb();
			}

			internal double QyzXhNQhoUjocBcABuyxLmPmBUZV(int P_0)
			{
				return vdnCirvuIizHaUoSqnEPbKLjQhml.hBVhmVHYlzSVDNIMNCczhcDFKwvJb(P_0)?.ImIWjGbBlBlRvMCFclPdriStRtqn ?? (-1.0);
			}

			internal void PPdwvLjDdXACcjBWqTJSqmLQuijqA(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick);
				if (xCOErbHoOlwtReVrlBlQrQooVXdNA.yaFPMojfoCAlpmKQWVrPKhXZLKMn(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				ClezMzHGVattqKgyOdCeSSlvJsdy.cQnfrIYYceEdekKgheHtgNGgJDGHA cQnfrIYYceEdekKgheHtgNGgJDGHA = vdnCirvuIizHaUoSqnEPbKLjQhml.hBVhmVHYlzSVDNIMNCczhcDFKwvJb(P_0.id);
				TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB aQofIYFZBCdRNEcCaMfJVSEGzChdB;
				if (cQnfrIYYceEdekKgheHtgNGgJDGHA != null && cQnfrIYYceEdekKgheHtgNGgJDGHA.jEshaibPFWVyCZKVvsbiceLQTpLh != null)
				{
					aQofIYFZBCdRNEcCaMfJVSEGzChdB = new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB(P_0, cQnfrIYYceEdekKgheHtgNGgJDGHA.jEshaibPFWVyCZKVvsbiceLQTpLh);
				}
				else
				{
					global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap> vvqWcefspViLvBkIonynvYaRLpFT2 = maps.bkXGCHPudgqZVVzAcSVHnpFoyvyj(P_0, true);
					if (vvqWcefspViLvBkIonynvYaRLpFT2 == null)
					{
						vvqWcefspViLvBkIonynvYaRLpFT2 = new global::vvqWcefspViLvBkIonynvYaRLpFT<JoystickMap>(P_0.id);
					}
					aQofIYFZBCdRNEcCaMfJVSEGzChdB = new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB(P_0, vvqWcefspViLvBkIonynvYaRLpFT2);
				}
				xCOErbHoOlwtReVrlBlQrQooVXdNA.evzuTMkhZsadeiMLXCSIMuVNyjfmA(aQofIYFZBCdRNEcCaMfJVSEGzChdB);
				vdnCirvuIizHaUoSqnEPbKLjQhml.gZpjNDtGeUrUwDBkkyFfrQNpWxSH(aQofIYFZBCdRNEcCaMfJVSEGzChdB);
				QaVOTlMKqtePvdUDliIHWUSijhqk.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(P_0);
				maps.layoutManager.Apply();
				if (VFomvQUIhOdKXuAYaUnjPxBBulJM.Count > 0)
				{
					VFomvQUIhOdKXuAYaUnjPxBBulJM.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void bfSdvCGPOhcBXbdAxqrhIhHPTPlcA(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					PPdwvLjDdXACcjBWqTJSqmLQuijqA(joystick, P_1);
				}
			}

			internal void XWGDDYvtrpbEwHTePDQsGjJxmSmeA(int P_0)
			{
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick);
				if (xCOErbHoOlwtReVrlBlQrQooVXdNA.yaFPMojfoCAlpmKQWVrPKhXZLKMn(P_0))
				{
					if (xCOErbHoOlwtReVrlBlQrQooVXdNA.QlllfGYgQhzrYUdVBsXmntapKYEs(P_0) is TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB aQofIYFZBCdRNEcCaMfJVSEGzChdB)
					{
						vdnCirvuIizHaUoSqnEPbKLjQhml.gZpjNDtGeUrUwDBkkyFfrQNpWxSH(aQofIYFZBCdRNEcCaMfJVSEGzChdB);
					}
					xCOErbHoOlwtReVrlBlQrQooVXdNA.FEdcTOhMabuIZIwDFIawVBpdirGdA(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					QaVOTlMKqtePvdUDliIHWUSijhqk.mcLDGeazCzmWxNKScdthBzTSViJc(joystick);
					if (nawYRGqGpdIWXfhzdnFdVTYHifDYA.Count > 0)
					{
						nawYRGqGpdIWXfhzdnFdVTYHifDYA.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void kuKQKMUyjGRckdffCfIoilNVwQYH(Joystick P_0)
			{
				if (P_0 != null)
				{
					XWGDDYvtrpbEwHTePDQsGjJxmSmeA(P_0.id);
				}
			}

			internal void vgQcvOAmmznwjzNWKRjLkTwEibSHA()
			{
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Joystick);
				for (int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB - 1; num >= 0; num--)
				{
					vdnCirvuIizHaUoSqnEPbKLjQhml.gZpjNDtGeUrUwDBkkyFfrQNpWxSH(xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num) as TEzcHaVJErqgWnDVyEPxJbcUKPwoA<Joystick, JoystickMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB);
					QaVOTlMKqtePvdUDliIHWUSijhqk.mcLDGeazCzmWxNKScdthBzTSViJc(xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD);
					int id = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD.id;
					xCOErbHoOlwtReVrlBlQrQooVXdNA.uhXVKlHLXfhlVEnsVOFXtxuMubqy(num);
					if (nawYRGqGpdIWXfhzdnFdVTYHifDYA.Count > 0)
					{
						nawYRGqGpdIWXfhzdnFdVTYHifDYA.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, id, ControllerType.Joystick, false));
					}
				}
				xCOErbHoOlwtReVrlBlQrQooVXdNA.CLSkRuJgRJjGgKMdtHVRtsgEFuGj();
			}

			internal void IUPlYNsSLxOsntNkkdjuBmtCQenBb(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom);
				if (!xCOErbHoOlwtReVrlBlQrQooVXdNA.yaFPMojfoCAlpmKQWVrPKhXZLKMn(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::vvqWcefspViLvBkIonynvYaRLpFT<CustomControllerMap> vvqWcefspViLvBkIonynvYaRLpFT2 = maps.SYeQzCklMcFtsXUNOGGQLkmBfyjDA(P_0, true);
					if (vvqWcefspViLvBkIonynvYaRLpFT2 == null)
					{
						vvqWcefspViLvBkIonynvYaRLpFT2 = new global::vvqWcefspViLvBkIonynvYaRLpFT<CustomControllerMap>(P_0.id);
					}
					TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB aQofIYFZBCdRNEcCaMfJVSEGzChdB = new TEzcHaVJErqgWnDVyEPxJbcUKPwoA<CustomController, CustomControllerMap>.AQofIYFZBCdRNEcCaMfJVSEGzChdB(P_0, vvqWcefspViLvBkIonynvYaRLpFT2);
					xCOErbHoOlwtReVrlBlQrQooVXdNA.evzuTMkhZsadeiMLXCSIMuVNyjfmA(aQofIYFZBCdRNEcCaMfJVSEGzChdB);
					QaVOTlMKqtePvdUDliIHWUSijhqk.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(P_0);
					maps.layoutManager.Apply();
					if (VFomvQUIhOdKXuAYaUnjPxBBulJM.Count > 0)
					{
						VFomvQUIhOdKXuAYaUnjPxBBulJM.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void WCnRXsNDykhDXapITllciTSeiWOk(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					IUPlYNsSLxOsntNkkdjuBmtCQenBb(customController, P_1);
				}
			}

			internal void xwVrzhEhkAQYJPcPSGCWUWEuGefl(int P_0)
			{
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom);
				if (xCOErbHoOlwtReVrlBlQrQooVXdNA.yaFPMojfoCAlpmKQWVrPKhXZLKMn(P_0))
				{
					xCOErbHoOlwtReVrlBlQrQooVXdNA.QlllfGYgQhzrYUdVBsXmntapKYEs(P_0);
					xCOErbHoOlwtReVrlBlQrQooVXdNA.FEdcTOhMabuIZIwDFIawVBpdirGdA(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					QaVOTlMKqtePvdUDliIHWUSijhqk.mcLDGeazCzmWxNKScdthBzTSViJc(customController);
					if (nawYRGqGpdIWXfhzdnFdVTYHifDYA.Count > 0)
					{
						nawYRGqGpdIWXfhzdnFdVTYHifDYA.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void MetzsPiLEKFpbqKBxAdSiJvtHFrIb(CustomController P_0)
			{
				if (P_0 != null)
				{
					xwVrzhEhkAQYJPcPSGCWUWEuGefl(P_0.id);
				}
			}

			internal void MTYVDOkKHHjfqytUivuyjhRfOFsx()
			{
				XCOErbHoOlwtReVrlBlQrQooVXdNA xCOErbHoOlwtReVrlBlQrQooVXdNA = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Custom);
				for (int num = xCOErbHoOlwtReVrlBlQrQooVXdNA.FwIGimYHKsSdutRnXvajJeatuVHB - 1; num >= 0; num--)
				{
					QaVOTlMKqtePvdUDliIHWUSijhqk.mcLDGeazCzmWxNKScdthBzTSViJc(xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD);
					int id = xCOErbHoOlwtReVrlBlQrQooVXdNA.mQlgnCgVVTgLKiBwFJBeTdYjqlxY(num).pQefzbMuBblbJGuGRnxcoWyVLFcD.id;
					xCOErbHoOlwtReVrlBlQrQooVXdNA.uhXVKlHLXfhlVEnsVOFXtxuMubqy(num);
					if (nawYRGqGpdIWXfhzdnFdVTYHifDYA.Count > 0)
					{
						nawYRGqGpdIWXfhzdnFdVTYHifDYA.Invoke(new ControllerAssignmentChangedEventArgs(jCNyzhPxVMAruYwdvzvqZVDwhvmG.id, id, ControllerType.Custom, false));
					}
				}
				xCOErbHoOlwtReVrlBlQrQooVXdNA.CLSkRuJgRJjGgKMdtHVRtsgEFuGj();
			}

			internal CustomController SJRNVrENMUrcnoVqTLuFZBeURoZt(int P_0)
			{
				CustomController customController = jCNyzhPxVMAruYwdvzvqZVDwhvmG.pUcBslzzLOiQjTlQsQkqXLxySpX.eCVKPANUKkNwYdDVztQrzDjKaPIm(P_0);
				if (customController == null)
				{
					return null;
				}
				IUPlYNsSLxOsntNkkdjuBmtCQenBb(customController, false);
				return customController;
			}

			internal void ZwLqbBSaVPuGqqcMpiiiqfTwmkyt(Action<bool, int, int> P_0)
			{
				rGckEbXjfTpYryoCXkcwKBwRlWhc<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void qqnYDDzmuSpodLwvwjWZEPDqMZRN(Keyboard P_0, EPtbMtcNLxEwgFhZDmUBmgoMYKWwB P_1, Action<bool, int, int> P_2)
			{
				if (!VIygShhdlkkGoNLzLunyBKxrIoNx || !P_0.enabled)
				{
					return;
				}
				tKUMXrVinCzCNNrjdJwlBkKZkBUd rNAjWiULcxaHcrHcrwUEqUvhydNl = KvDFldULABgCdeUydTfHpQtIJWLLA.rNAjWiULcxaHcrHcrwUEqUvhydNl;
				bool flag = false;
				BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Keyboard).QlllfGYgQhzrYUdVBsXmntapKYEs(0).iuMldFPvAqBfeiUXQrGwudCQSSbq;
				int num = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				EPtbMtcNLxEwgFhZDmUBmgoMYKWwB.pdzlEfVIqqtvdztHpdiaFmnlaTzDA pdzlEfVIqqtvdztHpdiaFmnlaTzDA = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? EPtbMtcNLxEwgFhZDmUBmgoMYKWwB.pdzlEfVIqqtvdztHpdiaFmnlaTzDA.OverlapModifiers : EPtbMtcNLxEwgFhZDmUBmgoMYKWwB.pdzlEfVIqqtvdztHpdiaFmnlaTzDA.Normal);
				qFNgDRrnPTMkkavmrIgfBeDFETAv.WUHurmJAWFcLcGfYqOLliBIxfqzbA wUHurmJAWFcLcGfYqOLliBIxfqzbA = new qFNgDRrnPTMkkavmrIgfBeDFETAv.WUHurmJAWFcLcGfYqOLliBIxfqzbA
				{
					wXGyLKxbaAgMtaRNDnQlqOTXiRAeA = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.tVVQZXmeiSGqPDWfAiktOetHVuiqA;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
						bool flag3 = false;
						bool flag4 = false;
						ButtonStateFlags buttonStateFlags;
						bool flag5;
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							buttonStateFlags = (P_0.NBEMNDAYaEajSpvXyzBgUpljRiF(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag5)
							{
								qFNgDRrnPTMkkavmrIgfBeDFETAv qFNgDRrnPTMkkavmrIgfBeDFETAv2 = qFNgDRrnPTMkkavmrIgfBeDFETAv.PaIcNCEzwSbNPYsnjMfNFgwwfJynA(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL);
								if (qFNgDRrnPTMkkavmrIgfBeDFETAv2 != null && qFNgDRrnPTMkkavmrIgfBeDFETAv2.FVjAxchnFYwMYuxIVvqkbzNCaHRn(true) != ButtonStateFlags.Off)
								{
									flag5 = true;
								}
							}
						}
						else
						{
							buttonStateFlags = P_0.HpZEldNdLxRgzrmHTLDLaNzFqMdR(actionElementMap.YBnBsBBQkmlNrgHwodJTdPugtaTMB);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag5)
						{
							if (!flag2)
							{
								flag3 = P_1.snmTSUzIxfbSCGprMGlnvLLDpzVeA(keyboardKeyCode, modifierKeyFlags, pdzlEfVIqqtvdztHpdiaFmnlaTzDA, out flag4);
							}
							if (flag4 || modifierKeyFlags != ModifierKeyFlags.None)
							{
								wUHurmJAWFcLcGfYqOLliBIxfqzbA.tPUCuutcqHBoOHChWCLykdSNCmwGA = flag3;
								qFNgDRrnPTMkkavmrIgfBeDFETAv qFNgDRrnPTMkkavmrIgfBeDFETAv2 = qFNgDRrnPTMkkavmrIgfBeDFETAv.jMGCLfspLbgwqGFqqaWdFfVsXnTr(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, wUHurmJAWFcLcGfYqOLliBIxfqzbA);
								if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
								{
									qFNgDRrnPTMkkavmrIgfBeDFETAv2.MyIZVYTmyodvNZERGEqohVHhEkOs = flag3;
								}
								else if (flag3)
								{
									qFNgDRrnPTMkkavmrIgfBeDFETAv2.MyIZVYTmyodvNZERGEqohVHhEkOs = true;
								}
								qFNgDRrnPTMkkavmrIgfBeDFETAv2.lfKimNUJuYcKGCLemsfAxPNWOXgp(ReInput.currentUpdateLoop, buttonStateFlags, true);
								buttonStateFlags = qFNgDRrnPTMkkavmrIgfBeDFETAv2.FVjAxchnFYwMYuxIVvqkbzNCaHRn(true);
							}
						}
						if (buttonStateFlags != ButtonStateFlags.Off)
						{
							ptuNgadEjDENqHkQKtcogSmvGMwbb(P_0, keyboardMap, actionElementMap, rNAjWiULcxaHcrHcrwUEqUvhydNl, buttonStateFlags);
							P_2(arg1: true, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId);
							flag = true;
							continue;
						}
						if (rNAjWiULcxaHcrHcrwUEqUvhydNl.GOiNKRoMWKyzNzKoozlslZrtATjA != 0f)
						{
							rNAjWiULcxaHcrHcrwUEqUvhydNl.GOiNKRoMWKyzNzKoozlslZrtATjA = 0f;
						}
						if (rNAjWiULcxaHcrHcrwUEqUvhydNl.CVMZNPCylTVHCKoXLOBzekBJyWnL != ButtonStateFlags.Off)
						{
							rNAjWiULcxaHcrHcrwUEqUvhydNl.CVMZNPCylTVHCKoXLOBzekBJyWnL = ButtonStateFlags.Off;
						}
						P_2(arg1: false, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId);
					}
				}
				if (flag)
				{
					GnzBAtkWMUkcVnMJmNHZkEncOFHXA = ReInput.unscaledTime;
				}
			}

			private static void ptuNgadEjDENqHkQKtcogSmvGMwbb(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, tKUMXrVinCzCNNrjdJwlBkKZkBUd P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.GOiNKRoMWKyzNzKoozlslZrtATjA = num;
				P_3.CVMZNPCylTVHCKoXLOBzekBJyWnL = P_4;
				P_3.VLUIfnKKjvzhnKuFuDPRuLOeeWRD = P_0;
				P_3.vfVeBQhSnuinpARHOMDwZEKERoWb = ControllerType.Keyboard;
				P_3.LYLgOnMerqSBdnaEDajeYeNfsORp = ControllerElementType.Button;
				P_3.JZvUFQoyfKJbmBbXcGTbuYJtMRhC = P_2;
				P_3.YUaJrgILmIazxKuyTKaNKELGbJIC = P_1;
				if (P_3.FToHZtaDzbCutwxPAVNoofPXbfLg)
				{
					P_3.FToHZtaDzbCutwxPAVNoofPXbfLg = false;
				}
				if (P_3.vShHqXKpeIviKTYZWoBNZkYQeJNi)
				{
					P_3.vShHqXKpeIviKTYZWoBNZkYQeJNi = false;
				}
			}

			internal void gAbkZnLgotbUoLaTjqHNIjpRUqAf(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!npVlBITUuAGcohoQfGvxQtRwgJJjA || !P_0.enabled)
				{
					return;
				}
				BpzomrqmbmNinOxWAGGlQTtkPnsX bpzomrqmbmNinOxWAGGlQTtkPnsX = AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(ControllerType.Mouse).QlllfGYgQhzrYUdVBsXmntapKYEs(0).iuMldFPvAqBfeiUXQrGwudCQSSbq;
				tKUMXrVinCzCNNrjdJwlBkKZkBUd rNAjWiULcxaHcrHcrwUEqUvhydNl = KvDFldULABgCdeUydTfHpQtIJWLLA.rNAjWiULcxaHcrHcrwUEqUvhydNl;
				bool flag = false;
				int num = bpzomrqmbmNinOxWAGGlQTtkPnsX.AenMnPaenKXbTfnmKTHZLLNLsyPr;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)bpzomrqmbmNinOxWAGGlQTtkPnsX.IMbAidiclopVawbUkoIYAkGvwawAA(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.FVvHzSvPZciZtfhxafuWoQECqRce;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.XglhTAFUTWrgNiTLtRyIhzqaCFSn(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.XglhTAFUTWrgNiTLtRyIhzqaCFSn(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId);
									continue;
								}
							}
							rNAjWiULcxaHcrHcrwUEqUvhydNl.GOiNKRoMWKyzNzKoozlslZrtATjA = num2;
							rNAjWiULcxaHcrHcrwUEqUvhydNl.VLUIfnKKjvzhnKuFuDPRuLOeeWRD = P_0;
							rNAjWiULcxaHcrHcrwUEqUvhydNl.vfVeBQhSnuinpARHOMDwZEKERoWb = ControllerType.Mouse;
							rNAjWiULcxaHcrHcrwUEqUvhydNl.LYLgOnMerqSBdnaEDajeYeNfsORp = ControllerElementType.Axis;
							rNAjWiULcxaHcrHcrwUEqUvhydNl.JZvUFQoyfKJbmBbXcGTbuYJtMRhC = actionElementMap;
							rNAjWiULcxaHcrHcrwUEqUvhydNl.YUaJrgILmIazxKuyTKaNKELGbJIC = mouseMap;
							if (rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi)
							{
								rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi = false;
							}
							if (rNAjWiULcxaHcrHcrwUEqUvhydNl.NwQwDKsxmNujMwoLJmSBNnCMZeIm != AxisCoordinateMode.Relative)
							{
								rNAjWiULcxaHcrHcrwUEqUvhydNl.NwQwDKsxmNujMwoLJmSBNnCMZeIm = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.tVVQZXmeiSGqPDWfAiktOetHVuiqA;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.vbmcnelKUgsFKFaLNCcLsjwpAYBF(actionElementMap2, actionId2, out var gOiNKRoMWKyzNzKoozlslZrtATjA, out rNAjWiULcxaHcrHcrwUEqUvhydNl.FToHZtaDzbCutwxPAVNoofPXbfLg))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.HpZEldNdLxRgzrmHTLDLaNzFqMdR(actionElementMap2.YBnBsBBQkmlNrgHwodJTdPugtaTMB);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId2);
							continue;
						}
						rNAjWiULcxaHcrHcrwUEqUvhydNl.GOiNKRoMWKyzNzKoozlslZrtATjA = gOiNKRoMWKyzNzKoozlslZrtATjA;
						rNAjWiULcxaHcrHcrwUEqUvhydNl.CVMZNPCylTVHCKoXLOBzekBJyWnL = buttonStateFlags;
						rNAjWiULcxaHcrHcrwUEqUvhydNl.VLUIfnKKjvzhnKuFuDPRuLOeeWRD = P_0;
						rNAjWiULcxaHcrHcrwUEqUvhydNl.vfVeBQhSnuinpARHOMDwZEKERoWb = ControllerType.Mouse;
						rNAjWiULcxaHcrHcrwUEqUvhydNl.LYLgOnMerqSBdnaEDajeYeNfsORp = ControllerElementType.Button;
						rNAjWiULcxaHcrHcrwUEqUvhydNl.JZvUFQoyfKJbmBbXcGTbuYJtMRhC = actionElementMap2;
						rNAjWiULcxaHcrHcrwUEqUvhydNl.YUaJrgILmIazxKuyTKaNKELGbJIC = mouseMap;
						if (rNAjWiULcxaHcrHcrwUEqUvhydNl.FToHZtaDzbCutwxPAVNoofPXbfLg)
						{
							rNAjWiULcxaHcrHcrwUEqUvhydNl.FToHZtaDzbCutwxPAVNoofPXbfLg = false;
						}
						if (rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi)
						{
							rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi = false;
						}
						P_1(arg1: true, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					AsuSLNnhYgIDPuKBPMKMAtCrUGDH = ReInput.unscaledTime;
				}
			}

			internal void eqlZktjnOqQBlMofrGOadMeUiUGv(Action<bool, int, int> P_0)
			{
				rGckEbXjfTpYryoCXkcwKBwRlWhc<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void rGckEbXjfTpYryoCXkcwKBwRlWhc<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				TEzcHaVJErqgWnDVyEPxJbcUKPwoA<_0001, _0002> tEzcHaVJErqgWnDVyEPxJbcUKPwoA = (TEzcHaVJErqgWnDVyEPxJbcUKPwoA<_0001, _0002>)AcfCfNjbBhWbVvFwHWSElpzdBveZ.YZCheSLIYOKljVOrxozqzaUsbJZR(P_0);
				tKUMXrVinCzCNNrjdJwlBkKZkBUd rNAjWiULcxaHcrHcrwUEqUvhydNl = KvDFldULABgCdeUydTfHpQtIJWLLA.rNAjWiULcxaHcrHcrwUEqUvhydNl;
				int num = tEzcHaVJErqgWnDVyEPxJbcUKPwoA.nmydqOADyBNZdjaBvZQRcgEpucQnA();
				for (int i = 0; i < num; i++)
				{
					TEzcHaVJErqgWnDVyEPxJbcUKPwoA<_0001, _0002>.AQofIYFZBCdRNEcCaMfJVSEGzChdB aQofIYFZBCdRNEcCaMfJVSEGzChdB = tEzcHaVJErqgWnDVyEPxJbcUKPwoA.MtwZFyLUwaaefeuyimwLjZMYlHAB(i);
					_0001 bJkzuoVFDtsUqMpDgBxoNgOZJmNj = aQofIYFZBCdRNEcCaMfJVSEGzChdB.bJkzuoVFDtsUqMpDgBxoNgOZJmNj;
					if (!bJkzuoVFDtsUqMpDgBxoNgOZJmNj.enabled)
					{
						continue;
					}
					global::vvqWcefspViLvBkIonynvYaRLpFT<_0002> oMRwDdJdVKppZpMVZzpvvqJvcOCA = aQofIYFZBCdRNEcCaMfJVSEGzChdB.oMRwDdJdVKppZpMVZzpvvqJvcOCA;
					bool flag = false;
					int num2 = oMRwDdJdVKppZpMVZzpvvqJvcOCA.cLFOTXBjzlMfxMSeRWBhGFJkuhvb();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = oMRwDdJdVKppZpMVZzpvvqJvcOCA.bPBvSQSPFBOEZzzSdKegAflIdxiN(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.FVvHzSvPZciZtfhxafuWoQECqRce;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!bJkzuoVFDtsUqMpDgBxoNgOZJmNj.XglhTAFUTWrgNiTLtRyIhzqaCFSn(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									bJkzuoVFDtsUqMpDgBxoNgOZJmNj.XglhTAFUTWrgNiTLtRyIhzqaCFSn(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId);
										continue;
									}
								}
								rNAjWiULcxaHcrHcrwUEqUvhydNl.GOiNKRoMWKyzNzKoozlslZrtATjA = num3;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.VLUIfnKKjvzhnKuFuDPRuLOeeWRD = bJkzuoVFDtsUqMpDgBxoNgOZJmNj;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.vfVeBQhSnuinpARHOMDwZEKERoWb = P_0;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.LYLgOnMerqSBdnaEDajeYeNfsORp = ControllerElementType.Axis;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.JZvUFQoyfKJbmBbXcGTbuYJtMRhC = actionElementMap;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.YUaJrgILmIazxKuyTKaNKELGbJIC = val;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi = bJkzuoVFDtsUqMpDgBxoNgOZJmNj.calibrationMap.Axes[actionElementMap.YBnBsBBQkmlNrgHwodJTdPugtaTMB].applyRangeCalibration;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.NwQwDKsxmNujMwoLJmSBNnCMZeIm = bJkzuoVFDtsUqMpDgBxoNgOZJmNj.Axes[actionElementMap.elementIndex].RWCEZctGAZWeIhWIQMIAdNROmnEb?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.tVVQZXmeiSGqPDWfAiktOetHVuiqA;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float gOiNKRoMWKyzNzKoozlslZrtATjA = 0f;
								int yBnBsBBQkmlNrgHwodJTdPugtaTMB = actionElementMap2.YBnBsBBQkmlNrgHwodJTdPugtaTMB;
								if (!VlgbwdsxldoZURhmcfgiyShSEFde(bJkzuoVFDtsUqMpDgBxoNgOZJmNj, i, yBnBsBBQkmlNrgHwodJTdPugtaTMB, actionElementMap2, oMRwDdJdVKppZpMVZzpvvqJvcOCA, actionId2, ref gOiNKRoMWKyzNzKoozlslZrtATjA) && !bJkzuoVFDtsUqMpDgBxoNgOZJmNj.vbmcnelKUgsFKFaLNCcLsjwpAYBF(actionElementMap2, actionId2, out gOiNKRoMWKyzNzKoozlslZrtATjA, out rNAjWiULcxaHcrHcrwUEqUvhydNl.FToHZtaDzbCutwxPAVNoofPXbfLg))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = bJkzuoVFDtsUqMpDgBxoNgOZJmNj.HpZEldNdLxRgzrmHTLDLaNzFqMdR(actionElementMap2.YBnBsBBQkmlNrgHwodJTdPugtaTMB);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId2);
									continue;
								}
								rNAjWiULcxaHcrHcrwUEqUvhydNl.GOiNKRoMWKyzNzKoozlslZrtATjA = gOiNKRoMWKyzNzKoozlslZrtATjA;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.CVMZNPCylTVHCKoXLOBzekBJyWnL = buttonStateFlags;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.VLUIfnKKjvzhnKuFuDPRuLOeeWRD = bJkzuoVFDtsUqMpDgBxoNgOZJmNj;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.vfVeBQhSnuinpARHOMDwZEKERoWb = P_0;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.LYLgOnMerqSBdnaEDajeYeNfsORp = ControllerElementType.Button;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.JZvUFQoyfKJbmBbXcGTbuYJtMRhC = actionElementMap2;
								rNAjWiULcxaHcrHcrwUEqUvhydNl.YUaJrgILmIazxKuyTKaNKELGbJIC = val;
								if (rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi)
								{
									rNAjWiULcxaHcrHcrwUEqUvhydNl.vShHqXKpeIviKTYZWoBNZkYQeJNi = false;
								}
								P_1(arg1: true, jCNyzhPxVMAruYwdvzvqZVDwhvmG.QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							aQofIYFZBCdRNEcCaMfJVSEGzChdB.SLtVxKbNLsTVuKJsKTLqBBvnfcmb();
						}
					}
				}
			}

			private bool VlgbwdsxldoZURhmcfgiyShSEFde<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.EnxeINdfRsPNEfNsWCRpkeCWEWlpA.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.EnxeINdfRsPNEfNsWCRpkeCWEWlpA.GetUnknownHatButtons(P_2);
				if (vkLHNheHQQkoFnpnuaZgoBkSWIph(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.NkQdRnwkFdMIpxtgrAatYeYHtQbd(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool vkLHNheHQQkoFnpnuaZgoBkSWIph<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (JHMcvEfMtRZpxefscISEVIXLadOm(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool JHMcvEfMtRZpxefscISEVIXLadOm<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::vvqWcefspViLvBkIonynvYaRLpFT<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.cLFOTXBjzlMfxMSeRWBhGFJkuhvb();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.bPBvSQSPFBOEZzzSdKegAflIdxiN(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int yBnBsBBQkmlNrgHwodJTdPugtaTMB = buttonMaps[j].YBnBsBBQkmlNrgHwodJTdPugtaTMB;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(yBnBsBBQkmlNrgHwodJTdPugtaTMB))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private const string MDeWavJKQesqgdtSWXaWJfBAuCEm = "player";

		private readonly rvADANidBCTaBLMwFOZPaxTGMMzTB pUcBslzzLOiQjTlQsQkqXLxySpX;

		private bool BlRaAWffTzUZVbNNXCCALaNACienA;

		private int QCUoYDqLLDFsRwBhDegcxJcsDftHA;

		private string wnUPEYQJBKhyAmZYnoiFqzPYmmPD;

		private string BdthrsCelaWgrXlMqcVbwwSfYjGb;

		private readonly string fzalcVZJVHGNhIOapUcxUxMUNuoqA;

		private bool tXwrvCPZgmzWTclEOvdODaXfvwXf;

		private readonly int cNZRinUcdORKVAjvssCENMHEPgrV;

		private readonly CMZFLplsuqkvbBvNYmZBVurZoVpI sIxRfkliQXDyjuUpffepHQTbvhLV;

		private int pXJXBZxnNzCvRAsPKYwJKioxYoNy;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
					return -1;
				}
				return QCUoYDqLLDFsRwBhDegcxJcsDftHA;
			}
			internal set
			{
				QCUoYDqLLDFsRwBhDegcxJcsDftHA = qCUoYDqLLDFsRwBhDegcxJcsDftHA;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
					return string.Empty;
				}
				return wnUPEYQJBKhyAmZYnoiFqzPYmmPD;
			}
			internal set
			{
				wnUPEYQJBKhyAmZYnoiFqzPYmmPD = text;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return BdthrsCelaWgrXlMqcVbwwSfYjGb;
				}
				return sIxRfkliQXDyjuUpffepHQTbvhLV.qJkqRAxrrocPcPhIKAOpCMJUoZxfA;
			}
			internal set
			{
				nonLocalizedDescriptiveName = text;
			}
		}

		public bool isPlaying
		{
			get
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
					return false;
				}
				return tXwrvCPZgmzWTclEOvdODaXfvwXf;
			}
			set
			{
				tXwrvCPZgmzWTclEOvdODaXfvwXf = value;
			}
		}

		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return BdthrsCelaWgrXlMqcVbwwSfYjGb;
			}
			set
			{
				BdthrsCelaWgrXlMqcVbwwSfYjGb = value;
				sIxRfkliQXDyjuUpffepHQTbvhLV.wkNCiIKcomvvEiZxnJmXtmqxRPdW();
			}
		}

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.keyCategory => "player";

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.scriptingName => wnUPEYQJBKhyAmZYnoiFqzPYmmPD;

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName
		{
			get
			{
				return BdthrsCelaWgrXlMqcVbwwSfYjGb;
			}
			set
			{
				BdthrsCelaWgrXlMqcVbwwSfYjGb = value;
			}
		}

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.key => fzalcVZJVHGNhIOapUcxUxMUNuoqA;

		int LnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags
		{
			get
			{
				return pXJXBZxnNzCvRAsPKYwJKioxYoNy;
			}
			set
			{
				pXJXBZxnNzCvRAsPKYwJKioxYoNy = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, wsTGaisyEgVqWobCcVTBhcYPpDji P_5, ControllerMapLayoutManager.ccDuPLOhlbrAqOTHJEHJSRpBmDEb P_6, ControllerMapEnabler.ybCAJZdDMTpCNSaMwMfysgFQeUXm P_7)
		{
			BlRaAWffTzUZVbNNXCCALaNACienA = P_0;
			QCUoYDqLLDFsRwBhDegcxJcsDftHA = P_1;
			wnUPEYQJBKhyAmZYnoiFqzPYmmPD = P_2;
			BdthrsCelaWgrXlMqcVbwwSfYjGb = P_3;
			fzalcVZJVHGNhIOapUcxUxMUNuoqA = P_4;
			cNZRinUcdORKVAjvssCENMHEPgrV = ReInput.id;
			sIxRfkliQXDyjuUpffepHQTbvhLV = CMZFLplsuqkvbBvNYmZBVurZoVpI.mcPyJtFwDcyGtHKiRQGaIYyPGBGg(this);
			controllers = new ControllerHelper(this, P_5, P_6, P_7);
			pUcBslzzLOiQjTlQsQkqXLxySpX = ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw;
			uGBfKyZBlVREOVBlzpyhXnNiUUTW();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(QCUoYDqLLDFsRwBhDegcxJcsDftHA));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jonBMeBgjqmpKxavKozLAPygznlzb() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jonBMeBgjqmpKxavKozLAPygznlzb() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.AHAfXYajBSoiRkPUeJcdIbrWdSzT() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.AHAfXYajBSoiRkPUeJcdIbrWdSzT() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.QhIFFGmODJeZADKlMzrwrvViMkFFA() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.QhIFFGmODJeZADKlMzrwrvViMkFFA() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.ErHrVSCsDYUYvOhOGtaLWvLzkRUv() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.ErHrVSCsDYUYvOhOGtaLWvLzkRUv() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.leJpQSBpsXypUKkUlFCVJOOJkVZW() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.leJpQSBpsXypUKkUlFCVJOOJkVZW() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.vrSuqTsbLGDvCIrahfArgEVLgbLiA() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.vrSuqTsbLGDvCIrahfArgEVLgbLiA() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jJOOiwSjatfNcHHSlzJnnXBSKHmJ() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jJOOiwSjatfNcHHSlzJnnXBSKHmJ() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.QoYnapdumcutNIkvTnBhtWWxoDqI(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.QoYnapdumcutNIkvTnBhtWWxoDqI(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName)
		{
			return GetButtonDoublePressHold(actionName, 0f);
		}

		public bool GetButtonDoublePressHold(int actionId)
		{
			return GetButtonDoublePressHold(actionId, 0f);
		}

		public bool GetButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.TWgLCmJHQFLpcxWpHeDkkWKfOdtj(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.TWgLCmJHQFLpcxWpHeDkkWKfOdtj(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.bYYGrmiMaVaqWzWEkxGjsYiEgnNS(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.bYYGrmiMaVaqWzWEkxGjsYiEgnNS(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(string actionName)
		{
			return GetButtonDoublePressUp(actionName, 0f);
		}

		public bool GetButtonDoublePressUp(int actionId)
		{
			return GetButtonDoublePressUp(actionId, 0f);
		}

		public bool GetButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.NzQrTYSnDcGRqbNdniVOSQqJoqAG(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.NzQrTYSnDcGRqbNdniVOSQqJoqAG(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.NzQrTYSnDcGRqbNdniVOSQqJoqAG(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.NzQrTYSnDcGRqbNdniVOSQqJoqAG(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.KfKWyEBfMWRJtXfkuyNnrMnWwSgd(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.KfKWyEBfMWRJtXfkuyNnrMnWwSgd(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.vkBYJdlMzighvOYTkGrsYDUmsodE(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.vkBYJdlMzighvOYTkGrsYDUmsodE(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.vkBYJdlMzighvOYTkGrsYDUmsodE(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.vkBYJdlMzighvOYTkGrsYDUmsodE(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.bongdQqmupfQSHXCTmfmQNCkYumU() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.bongdQqmupfQSHXCTmfmQNCkYumU() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.tHJnnjrHfPYknbNDKOKeNLhbhpQu() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.tHJnnjrHfPYknbNDKOKeNLhbhpQu() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.RvdqpLgLtagjFduEnuOEFivMTDAm() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.RvdqpLgLtagjFduEnuOEFivMTDAm() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.qAzFnnISixTyoWOKoTqCFzESwanA() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.qAzFnnISixTyoWOKoTqCFzESwanA() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.OsyHPaidTpYBYijoDgHmuEybJsBh() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.OsyHPaidTpYBYijoDgHmuEybJsBh() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.TYRlaLcnebEhljBSxanWDgYblAxxA() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.TYRlaLcnebEhljBSxanWDgYblAxxA() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.VKhtDAKdScfYZJwREarPYfPRnkrA() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.VKhtDAKdScfYZJwREarPYfPRnkrA() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.JEFotBfKuCFGvwYyxpZnsLteLmQH(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.TXtRpXqPUSQzmCzvIxwIgfDABDRg(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.GhNWHSHMvWqeTQRWiSfThsuptNnI(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.WtTJvoPdusNImqFjvWaFUmyqosAF(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.SZRUDVYaAebPzKtUqmvcmrhqprOp() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.SZRUDVYaAebPzKtUqmvcmrhqprOp() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.lmrvcvGDgXHliFQXRgyQBsUnLruE() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.lmrvcvGDgXHliFQXRgyQBsUnLruE() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.pXjVqdAzojvTbKvxXpykfDkEPpQj() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.pXjVqdAzojvTbKvxXpykfDkEPpQj() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.lHHuINDJBTdpehTarhalhiDIerGx() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.lHHuINDJBTdpehTarhalhiDIerGx() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.cZnPzBTkHgebnurRTrMvxFZoHRQ() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.cZnPzBTkHgebnurRTrMvxFZoHRQ() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.TLGzmXXWqWqdMxqYeLawjKRLjOHj() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.TLGzmXXWqWqdMxqYeLawjKRLjOHj() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.OHEgpxkImiJCqolaVZUxvFDoULlV() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.OHEgpxkImiJCqolaVZUxvFDoULlV() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.icISRcgmlpGTPhvBVPBbXqHOwYNCA() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.icISRcgmlpGTPhvBVPBbXqHOwYNCA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.irkDtFaWCXlYTvtuvGUVfEsfFYIm() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.irkDtFaWCXlYTvtuvGUVfEsfFYIm() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.zEbnlZdaiDyetgJiLTFBfyCksxhK(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.zEbnlZdaiDyetgJiLTFBfyCksxhK(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName)
		{
			return GetNegativeButtonDoublePressHold(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressHold(int actionId)
		{
			return GetNegativeButtonDoublePressHold(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.xplklLjFBUdExfyeGIYreySaXLpwA(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.xplklLjFBUdExfyeGIYreySaXLpwA(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(string actionName)
		{
			return GetNegativeButtonDoublePressDown(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(int actionId)
		{
			return GetNegativeButtonDoublePressDown(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.ZywGlizWJkjZOJCxihYfIdZPfKmM(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.ZywGlizWJkjZOJCxihYfIdZPfKmM(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(string actionName)
		{
			return GetNegativeButtonDoublePressUp(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(int actionId)
		{
			return GetNegativeButtonDoublePressUp(actionId, 0f);
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.IUwmguQiJVJAbdBMtRmgmQtufkZN(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.IUwmguQiJVJAbdBMtRmgmQtufkZN(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jJneXQoPwtMJsElqheSfDuRYcmEWA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jJneXQoPwtMJsElqheSfDuRYcmEWA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jJneXQoPwtMJsElqheSfDuRYcmEWA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jJneXQoPwtMJsElqheSfDuRYcmEWA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.WPHBHjUnRAgFXAwQRWvlCCQRCpohA() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.WPHBHjUnRAgFXAwQRWvlCCQRCpohA() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.QcKgRpnjObkdVpdAhACjXQCKkbT() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.QcKgRpnjObkdVpdAhACjXQCKkbT() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.zLRaEWaNUNqANdVnZVCXenCmgBzG() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.zLRaEWaNUNqANdVnZVCXenCmgBzG() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.ccfbVnEYphSAKDcOvANEplTREnGG() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.ccfbVnEYphSAKDcOvANEplTREnGG() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.KBxcgZydRgMdteooSrGuDoCtzlkw() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.KBxcgZydRgMdteooSrGuDoCtzlkw() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jtWfJjCxRaLtWlmSjupulMQKlEFlA() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jtWfJjCxRaLtWlmSjupulMQKlEFlA() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.SwdFNDSojvQADMMjyGKRyavbMKvL() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.SwdFNDSojvQADMMjyGKRyavbMKvL() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.WCPUExUBFBLAdpPEksHneVoQLNwB(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.HgzxcTpkYNIHJWrFZmhAcdKviFFW(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.LHJXSRkJSZXhLHBsTtPHWCOewreo(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.sHEScTEugnAJDsDHUqOjHVLpNQzC(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.GECGbGVSZFbGpcWiwvgJuuHcRUDUA() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.GECGbGVSZFbGpcWiwvgJuuHcRUDUA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.yfNogkwubBsGKCahGLJuSIojWNik() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.yfNogkwubBsGKCahGLJuSIojWNik() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.vDILMvZTSozNrqNZOlPRyQknMOMj() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.vDILMvZTSozNrqNZOlPRyQknMOMj() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.cSmTNGoDybvqVlYYDlRblGGxcFDQ() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.cSmTNGoDybvqVlYYDlRblGGxcFDQ() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.JrvFLXhmewpPhJaTZAZzRipCiguO() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.JrvFLXhmewpPhJaTZAZzRipCiguO() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.vHGqiugXaRiLTkkhTgchZCUUTHhC() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.vHGqiugXaRiLTkkhTgchZCUUTHhC() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.jpLkkNkxMBEvyhxWgflApKtEPryb() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.jpLkkNkxMBEvyhxWgflApKtEPryb() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.orEirFTIDxeIXGlfJPoRyMZnkLdjA() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.orEirFTIDxeIXGlfJPoRyMZnkLdjA() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.vDILMvZTSozNrqNZOlPRyQknMOMj();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.vDILMvZTSozNrqNZOlPRyQknMOMj();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.vDILMvZTSozNrqNZOlPRyQknMOMj();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.vDILMvZTSozNrqNZOlPRyQknMOMj();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.JrvFLXhmewpPhJaTZAZzRipCiguO();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.JrvFLXhmewpPhJaTZAZzRipCiguO();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.JrvFLXhmewpPhJaTZAZzRipCiguO();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.JrvFLXhmewpPhJaTZAZzRipCiguO();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.cSmTNGoDybvqVlYYDlRblGGxcFDQ();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.cSmTNGoDybvqVlYYDlRblGGxcFDQ();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.cSmTNGoDybvqVlYYDlRblGGxcFDQ();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.cSmTNGoDybvqVlYYDlRblGGxcFDQ();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.vHGqiugXaRiLTkkhTgchZCUUTHhC();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionName, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.vHGqiugXaRiLTkkhTgchZCUUTHhC();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, xAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.x = kvDFldULABgCdeUydTfHpQtIJWLLA.vHGqiugXaRiLTkkhTgchZCUUTHhC();
			}
			kvDFldULABgCdeUydTfHpQtIJWLLA = pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, yAxisActionId, true);
			if (kvDFldULABgCdeUydTfHpQtIJWLLA != null)
			{
				result.y = kvDFldULABgCdeUydTfHpQtIJWLLA.vHGqiugXaRiLTkkhTgchZCUUTHhC();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.kkCMeeKTjhrwiKoUDXBaWhCJwOJA() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.kkCMeeKTjhrwiKoUDXBaWhCJwOJA() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.uxegwgUfCSjdHhmrsPkVHgChpSSJ() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.uxegwgUfCSjdHhmrsPkVHgChpSSJ() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.loVHpKAOaIHANgBeDxZSpdAMcXqFA() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.loVHpKAOaIHANgBeDxZSpdAMcXqFA() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.dHKEBxDinhUJtHFtxOqVNNKUXyb() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0.0;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.dHKEBxDinhUJtHFtxOqVNNKUXyb() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.scEfVaoZVNYzgbzgkXgKasWzUeKe() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.scEfVaoZVNYzgbzgkXgKasWzUeKe() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.WRYQxHHnakkgcPLKsDTKZLoXwljq() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.WRYQxHHnakkgcPLKsDTKZLoXwljq() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.gxodwCtJoyfkiVuuCcwbwlegnKLG() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.gxodwCtJoyfkiVuuCcwbwlegnKLG() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.SNBQIheQzuBxKRrsDgTMELsAqgJlA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return AxisCoordinateMode.Absolute;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.SNBQIheQzuBxKRrsDgTMELsAqgJlA() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.FoeAtyFrrbPFunbJapNzsBbSQNIG();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.FoeAtyFrrbPFunbJapNzsBbSQNIG();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.YskeyUbRiqSRHpHgeoLcXzmNdzsPA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.YskeyUbRiqSRHpHgeoLcXzmNdzsPA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.UKmKVTHWYFiMjClZtAjEUfQkSxHR(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.UKmKVTHWYFiMjClZtAjEUfQkSxHR(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.ZimQjDSkGlLRmehJHaubWQGDxxKl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionName, true)?.ZOTeygDrbgabFIkjQguMlJmpJJnSA(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return false;
			}
			return pUcBslzzLOiQjTlQsQkqXLxySpX.rHxPDwYVNrsGvqoRZhPDldvonnvd(QCUoYDqLLDFsRwBhDegcxJcsDftHA, actionId, true)?.ZOTeygDrbgabFIkjQguMlJmpJJnSA(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.JBWbAibIbBpkjtyMlajopEyeLIvib(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.xlOepvKqaKjguaqjDpGPfVfnSOSH(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, (object[])null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionId, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionName, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.hniBgTsVlhuVUTtbxEOUWgMSaihbA(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.oFtxMXUeOKljBJNrnjLMiXURHpAl(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.rivoBbpbcwiqPIOAgGXrGiWCpSoVA(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.rZTLhotjktHgpBGUrmGDfLHDSvZQB(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.NtNKIkvoVIqycKFAZbGztCQVNCWF(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.SAyhDnUCrVQojQDDqlruUqBpfhDx(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.qTHhKfxISbMsIFKHHWTACCeriCME(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.UyeLcWqonGduVHMaxYLvEMJhYOGrA(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.AHDkxfgFjlgdLbqoRhYbGKCheLyXB(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.ABGsOfDCuqSJuimXxbsFktfhvbQz(QCUoYDqLLDFsRwBhDegcxJcsDftHA, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
				{
					ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				}
				else
				{
					pUcBslzzLOiQjTlQsQkqXLxySpX.kVLGEfyuodSITNBdcAYYbKXYaMTo(QCUoYDqLLDFsRwBhDegcxJcsDftHA);
				}
			}
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return 0f;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					num = MathTools.Max(joystick.GetVibration(motorIndex), num);
				}
			}
			return num;
		}

		public void StopVibration()
		{
			if (ReInput._id != cNZRinUcdORKVAjvssCENMHEPgrV)
			{
				ReInput.CheckInitialized(cNZRinUcdORKVAjvssCENMHEPgrV);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.StopVibration();
				}
			}
		}

		internal void CBGhIjYyDmelzRzyLLPGLAQLNzWP()
		{
			uGBfKyZBlVREOVBlzpyhXnNiUUTW();
		}

		private void uGBfKyZBlVREOVBlzpyhXnNiUUTW()
		{
			controllers.kavHKXihabNTtFcqgcRJJGAejEYTA();
			tXwrvCPZgmzWTclEOvdODaXfvwXf = false;
		}
	}
}
