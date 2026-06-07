using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class TtRqhWZWuulwetCBhugDmAwVtfIk : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					private CustomControllerMap VWFfxPjRKQCDyercMEqrSwQhLrtM;

					public CustomControllerMap wociEpLFbzKolRwnWObGgFZWmpXm;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public TtRqhWZWuulwetCBhugDmAwVtfIk(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00eb;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0 || VWFfxPjRKQCDyercMEqrSwQhLrtM == null)
							{
								return false;
							}
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
							goto IL_0117;
							IL_00eb:
							if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
							{
								ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							kdOQxMRxfBprWWxzhobszTGNskAP = null;
							goto IL_0105;
							IL_0117:
							if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								if (gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == huYafrIsSOmDxgVyGZWCXtREVVkLb)
								{
									kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Custom, huYafrIsSOmDxgVyGZWCXtREVVkLb, VWFfxPjRKQCDyercMEqrSwQhLrtM, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj, gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).TptZzDLPedINfuoxMyhBGLwShqDI).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
						TtRqhWZWuulwetCBhugDmAwVtfIk ttRqhWZWuulwetCBhugDmAwVtfIk;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ttRqhWZWuulwetCBhugDmAwVtfIk = this;
						}
						else
						{
							ttRqhWZWuulwetCBhugDmAwVtfIk = new TtRqhWZWuulwetCBhugDmAwVtfIk(0);
							ttRqhWZWuulwetCBhugDmAwVtfIk.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						ttRqhWZWuulwetCBhugDmAwVtfIk.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						ttRqhWZWuulwetCBhugDmAwVtfIk.VWFfxPjRKQCDyercMEqrSwQhLrtM = wociEpLFbzKolRwnWObGgFZWmpXm;
						ttRqhWZWuulwetCBhugDmAwVtfIk.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						ttRqhWZWuulwetCBhugDmAwVtfIk.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						return ttRqhWZWuulwetCBhugDmAwVtfIk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class BcegbOgXRCbuIWNwvWglQGYJRPXIA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private CustomControllerMap VWFfxPjRKQCDyercMEqrSwQhLrtM;

					public CustomControllerMap wociEpLFbzKolRwnWObGgFZWmpXm;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public BcegbOgXRCbuIWNwvWglQGYJRPXIA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00f1;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0 || PZbZkBoGnFCjWtQvUxrXIJOdhXlgA == null)
							{
								return false;
							}
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
							goto IL_011d;
							IL_00f1:
							if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
							{
								ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							kdOQxMRxfBprWWxzhobszTGNskAP = null;
							goto IL_010b;
							IL_011d:
							if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								if (gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == huYafrIsSOmDxgVyGZWCXtREVVkLb)
								{
									kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Custom, huYafrIsSOmDxgVyGZWCXtREVVkLb, VWFfxPjRKQCDyercMEqrSwQhLrtM, PZbZkBoGnFCjWtQvUxrXIJOdhXlgA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj, gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).TptZzDLPedINfuoxMyhBGLwShqDI).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
						BcegbOgXRCbuIWNwvWglQGYJRPXIA bcegbOgXRCbuIWNwvWglQGYJRPXIA;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							bcegbOgXRCbuIWNwvWglQGYJRPXIA = this;
						}
						else
						{
							bcegbOgXRCbuIWNwvWglQGYJRPXIA = new BcegbOgXRCbuIWNwvWglQGYJRPXIA(0);
							bcegbOgXRCbuIWNwvWglQGYJRPXIA.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						bcegbOgXRCbuIWNwvWglQGYJRPXIA.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						bcegbOgXRCbuIWNwvWglQGYJRPXIA.VWFfxPjRKQCDyercMEqrSwQhLrtM = wociEpLFbzKolRwnWObGgFZWmpXm;
						bcegbOgXRCbuIWNwvWglQGYJRPXIA.PZbZkBoGnFCjWtQvUxrXIJOdhXlgA = NHvoQUmVUvFdqqRTiMRJbyTctFXf;
						bcegbOgXRCbuIWNwvWglQGYJRPXIA.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						bcegbOgXRCbuIWNwvWglQGYJRPXIA.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						return bcegbOgXRCbuIWNwvWglQGYJRPXIA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class JIVBQnHiAYGmJxhfHNAHiskstUpD : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public JIVBQnHiAYGmJxhfHNAHiskstUpD(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00f3;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerId < 0 || WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
							goto IL_011f;
							IL_00f3:
							if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
							{
								ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							kdOQxMRxfBprWWxzhobszTGNskAP = null;
							goto IL_010d;
							IL_011f:
							if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								if (gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerId)
								{
									kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.bECRepayJEoXmyRqxiLVebVhEsIGA(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj, gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).TptZzDLPedINfuoxMyhBGLwShqDI).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
						JIVBQnHiAYGmJxhfHNAHiskstUpD jIVBQnHiAYGmJxhfHNAHiskstUpD;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							jIVBQnHiAYGmJxhfHNAHiskstUpD = this;
						}
						else
						{
							jIVBQnHiAYGmJxhfHNAHiskstUpD = new JIVBQnHiAYGmJxhfHNAHiskstUpD(0);
							jIVBQnHiAYGmJxhfHNAHiskstUpD.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						jIVBQnHiAYGmJxhfHNAHiskstUpD.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						jIVBQnHiAYGmJxhfHNAHiskstUpD.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						jIVBQnHiAYGmJxhfHNAHiskstUpD.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						return jIVBQnHiAYGmJxhfHNAHiskstUpD;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class aEhJvfUTurBDKCbcGEiGtHqcWhmL<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where _0001 : ControllerMap
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> eDbALhXqhwryDCzXbcuaiSkdOcST;

					public gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> zYmtgfjDPayCuIjLSblcAKweVXRB;

					private _0001 GCNTwjfEdkJtdhyaVbdIRoFGZFGd;

					public _0001 RVMLqQNSslAqwGMuyEJXyoopEWlX;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType iiAseQhJlTDpIYUMvxnFhgxryRVx;

					public ControllerType vnjysvClwLaZLJZXLIvHXdnrvegb;

					private int lxChKGtJBxIacLhtXIHbfKmQxJjk;

					public int wknmPPWKOJTFTpcNMaFdaYmTgoNJA;

					private InputMapCategory ZYEZdaZwbnoKegffaArJMrlCIZpV;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public aEhJvfUTurBDKCbcGEiGtHqcWhmL(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_014a;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (eDbALhXqhwryDCzXbcuaiSkdOcST == null || GCNTwjfEdkJtdhyaVbdIRoFGZFGd == null)
							{
								return false;
							}
							ZYEZdaZwbnoKegffaArJMrlCIZpV = ReInput.mapping.GetMapCategory(GCNTwjfEdkJtdhyaVbdIRoFGZFGd.categoryId);
							if (ZYEZdaZwbnoKegffaArJMrlCIZpV == null)
							{
								return false;
							}
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0176;
							IL_0176:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < eDbALhXqhwryDCzXbcuaiSkdOcST.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								ControllerMap controllerMap = eDbALhXqhwryDCzXbcuaiSkdOcST.wBgVECvNnnPzuAKlDGDoAWwKEEhT(eolRghqutZOOIGqvOFTzJOGfYTsn);
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMap.enabled) && (eTTawGSopVMvmFmPchxUidtHdmgj || !gZXxEqHwrHYIyUJtInpLwgTukJaY.qcLRVIzkIURtsVmxArtISfXIFjRj(ZYEZdaZwbnoKegffaArJMrlCIZpV, controllerMap)))
								{
									mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = controllerMap.ElementAssignmentConflicts(GCNTwjfEdkJtdhyaVbdIRoFGZFGd, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								ElementAssignmentConflictInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.controllerType = iiAseQhJlTDpIYUMvxnFhgxryRVx;
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.controllerId = lxChKGtJBxIacLhtXIHbfKmQxJjk;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							goto IL_0164;
							IL_0164:
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						aEhJvfUTurBDKCbcGEiGtHqcWhmL<_0001> aEhJvfUTurBDKCbcGEiGtHqcWhmL2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							aEhJvfUTurBDKCbcGEiGtHqcWhmL2 = this;
						}
						else
						{
							aEhJvfUTurBDKCbcGEiGtHqcWhmL2 = new aEhJvfUTurBDKCbcGEiGtHqcWhmL<_0001>(0);
							aEhJvfUTurBDKCbcGEiGtHqcWhmL2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						aEhJvfUTurBDKCbcGEiGtHqcWhmL2.iiAseQhJlTDpIYUMvxnFhgxryRVx = vnjysvClwLaZLJZXLIvHXdnrvegb;
						aEhJvfUTurBDKCbcGEiGtHqcWhmL2.lxChKGtJBxIacLhtXIHbfKmQxJjk = wknmPPWKOJTFTpcNMaFdaYmTgoNJA;
						aEhJvfUTurBDKCbcGEiGtHqcWhmL2.GCNTwjfEdkJtdhyaVbdIRoFGZFGd = RVMLqQNSslAqwGMuyEJXyoopEWlX;
						aEhJvfUTurBDKCbcGEiGtHqcWhmL2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						aEhJvfUTurBDKCbcGEiGtHqcWhmL2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						aEhJvfUTurBDKCbcGEiGtHqcWhmL2.eDbALhXqhwryDCzXbcuaiSkdOcST = zYmtgfjDPayCuIjLSblcAKweVXRB;
						return aEhJvfUTurBDKCbcGEiGtHqcWhmL2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class FmxKETAVbVbanRNHNhchQmnqaqCN<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where _0001 : ControllerMap
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> eDbALhXqhwryDCzXbcuaiSkdOcST;

					public gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> zYmtgfjDPayCuIjLSblcAKweVXRB;

					private ActionElementMap RiRbalOrVdCZfFNEtmqeRZqJAmFTA;

					public ActionElementMap jXfsOUvIRunaSWkrIPvKTOhwUlfV;

					private _0001 GCNTwjfEdkJtdhyaVbdIRoFGZFGd;

					public _0001 RVMLqQNSslAqwGMuyEJXyoopEWlX;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType iiAseQhJlTDpIYUMvxnFhgxryRVx;

					public ControllerType vnjysvClwLaZLJZXLIvHXdnrvegb;

					private int lxChKGtJBxIacLhtXIHbfKmQxJjk;

					public int wknmPPWKOJTFTpcNMaFdaYmTgoNJA;

					private InputMapCategory ZYEZdaZwbnoKegffaArJMrlCIZpV;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public FmxKETAVbVbanRNHNhchQmnqaqCN(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0141;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (eDbALhXqhwryDCzXbcuaiSkdOcST == null || RiRbalOrVdCZfFNEtmqeRZqJAmFTA == null)
							{
								return false;
							}
							ZYEZdaZwbnoKegffaArJMrlCIZpV = ((GCNTwjfEdkJtdhyaVbdIRoFGZFGd != null) ? ReInput.mapping.GetMapCategory(GCNTwjfEdkJtdhyaVbdIRoFGZFGd.categoryId) : null);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_016d;
							IL_016d:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < eDbALhXqhwryDCzXbcuaiSkdOcST.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								ControllerMap controllerMap = eDbALhXqhwryDCzXbcuaiSkdOcST.wBgVECvNnnPzuAKlDGDoAWwKEEhT(eolRghqutZOOIGqvOFTzJOGfYTsn);
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMap.enabled) && (eTTawGSopVMvmFmPchxUidtHdmgj || !gZXxEqHwrHYIyUJtInpLwgTukJaY.qcLRVIzkIURtsVmxArtISfXIFjRj(ZYEZdaZwbnoKegffaArJMrlCIZpV, controllerMap)))
								{
									mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = controllerMap.ElementAssignmentConflicts(RiRbalOrVdCZfFNEtmqeRZqJAmFTA, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_016d;
							IL_0141:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								ElementAssignmentConflictInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.controllerType = iiAseQhJlTDpIYUMvxnFhgxryRVx;
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.controllerId = lxChKGtJBxIacLhtXIHbfKmQxJjk;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						FmxKETAVbVbanRNHNhchQmnqaqCN<_0001> fmxKETAVbVbanRNHNhchQmnqaqCN;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							fmxKETAVbVbanRNHNhchQmnqaqCN = this;
						}
						else
						{
							fmxKETAVbVbanRNHNhchQmnqaqCN = new FmxKETAVbVbanRNHNhchQmnqaqCN<_0001>(0);
							fmxKETAVbVbanRNHNhchQmnqaqCN.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						fmxKETAVbVbanRNHNhchQmnqaqCN.iiAseQhJlTDpIYUMvxnFhgxryRVx = vnjysvClwLaZLJZXLIvHXdnrvegb;
						fmxKETAVbVbanRNHNhchQmnqaqCN.lxChKGtJBxIacLhtXIHbfKmQxJjk = wknmPPWKOJTFTpcNMaFdaYmTgoNJA;
						fmxKETAVbVbanRNHNhchQmnqaqCN.GCNTwjfEdkJtdhyaVbdIRoFGZFGd = RVMLqQNSslAqwGMuyEJXyoopEWlX;
						fmxKETAVbVbanRNHNhchQmnqaqCN.RiRbalOrVdCZfFNEtmqeRZqJAmFTA = jXfsOUvIRunaSWkrIPvKTOhwUlfV;
						fmxKETAVbVbanRNHNhchQmnqaqCN.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						fmxKETAVbVbanRNHNhchQmnqaqCN.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						fmxKETAVbVbanRNHNhchQmnqaqCN.eDbALhXqhwryDCzXbcuaiSkdOcST = zYmtgfjDPayCuIjLSblcAKweVXRB;
						return fmxKETAVbVbanRNHNhchQmnqaqCN;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class yEfijpLgegfPueAjPfbeFZRruLsr<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where _0001 : ControllerMap
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> eDbALhXqhwryDCzXbcuaiSkdOcST;

					public gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> zYmtgfjDPayCuIjLSblcAKweVXRB;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private InputMapCategory ZYEZdaZwbnoKegffaArJMrlCIZpV;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public yEfijpLgegfPueAjPfbeFZRruLsr(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_01ab;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (eDbALhXqhwryDCzXbcuaiSkdOcST == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(WeJFlXuVmFcPnwQYoDnnchsJRzmFA.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerType, WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerId, WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerMapId);
							ZYEZdaZwbnoKegffaArJMrlCIZpV = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerMapCategoryId));
							if (ZYEZdaZwbnoKegffaArJMrlCIZpV == null)
							{
								return false;
							}
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_01d7;
							IL_01ab:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								ElementAssignmentConflictInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.controllerType = WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerType;
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.controllerId = WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerId;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							goto IL_01c5;
							IL_01d7:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < eDbALhXqhwryDCzXbcuaiSkdOcST.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								ControllerMap controllerMap = eDbALhXqhwryDCzXbcuaiSkdOcST.wBgVECvNnnPzuAKlDGDoAWwKEEhT(eolRghqutZOOIGqvOFTzJOGfYTsn);
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMap.enabled) && (eTTawGSopVMvmFmPchxUidtHdmgj || !gZXxEqHwrHYIyUJtInpLwgTukJaY.qcLRVIzkIURtsVmxArtISfXIFjRj(ZYEZdaZwbnoKegffaArJMrlCIZpV, controllerMap)))
								{
									mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = controllerMap.ElementAssignmentConflicts(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						yEfijpLgegfPueAjPfbeFZRruLsr<_0001> yEfijpLgegfPueAjPfbeFZRruLsr2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							yEfijpLgegfPueAjPfbeFZRruLsr2 = this;
						}
						else
						{
							yEfijpLgegfPueAjPfbeFZRruLsr2 = new yEfijpLgegfPueAjPfbeFZRruLsr<_0001>(0);
							yEfijpLgegfPueAjPfbeFZRruLsr2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						yEfijpLgegfPueAjPfbeFZRruLsr2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						yEfijpLgegfPueAjPfbeFZRruLsr2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						yEfijpLgegfPueAjPfbeFZRruLsr2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						yEfijpLgegfPueAjPfbeFZRruLsr2.eDbALhXqhwryDCzXbcuaiSkdOcST = zYmtgfjDPayCuIjLSblcAKweVXRB;
						return yEfijpLgegfPueAjPfbeFZRruLsr2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class rlAClOzMfBeMaSqRfmBGhmLXHYlx : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					private JoystickMap FiFsRZmsfAlMtxuDUQHizqOuHnljA;

					public JoystickMap IrOaOiFrZJrGmpirPsrIrIXKRXRhA;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public rlAClOzMfBeMaSqRfmBGhmLXHYlx(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00ea;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0 || FiFsRZmsfAlMtxuDUQHizqOuHnljA == null)
							{
								return false;
							}
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
							goto IL_0116;
							IL_00ea:
							if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
							{
								ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							kdOQxMRxfBprWWxzhobszTGNskAP = null;
							goto IL_0104;
							IL_0116:
							if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								if (gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == gOiPPdQXptOcZupOsvpkYdiPsPSw)
								{
									kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Joystick, gOiPPdQXptOcZupOsvpkYdiPsPSw, FiFsRZmsfAlMtxuDUQHizqOuHnljA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj, gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).TptZzDLPedINfuoxMyhBGLwShqDI).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
						rlAClOzMfBeMaSqRfmBGhmLXHYlx rlAClOzMfBeMaSqRfmBGhmLXHYlx2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							rlAClOzMfBeMaSqRfmBGhmLXHYlx2 = this;
						}
						else
						{
							rlAClOzMfBeMaSqRfmBGhmLXHYlx2 = new rlAClOzMfBeMaSqRfmBGhmLXHYlx(0);
							rlAClOzMfBeMaSqRfmBGhmLXHYlx2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						rlAClOzMfBeMaSqRfmBGhmLXHYlx2.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						rlAClOzMfBeMaSqRfmBGhmLXHYlx2.FiFsRZmsfAlMtxuDUQHizqOuHnljA = IrOaOiFrZJrGmpirPsrIrIXKRXRhA;
						rlAClOzMfBeMaSqRfmBGhmLXHYlx2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						rlAClOzMfBeMaSqRfmBGhmLXHYlx2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						return rlAClOzMfBeMaSqRfmBGhmLXHYlx2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class rUuIoLygMrbPRHBiyxVlcHXBnAdm : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private JoystickMap FiFsRZmsfAlMtxuDUQHizqOuHnljA;

					public JoystickMap IrOaOiFrZJrGmpirPsrIrIXKRXRhA;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public rUuIoLygMrbPRHBiyxVlcHXBnAdm(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00f0;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0 || PZbZkBoGnFCjWtQvUxrXIJOdhXlgA == null)
							{
								return false;
							}
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
							goto IL_011c;
							IL_00f0:
							if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
							{
								ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							kdOQxMRxfBprWWxzhobszTGNskAP = null;
							goto IL_010a;
							IL_011c:
							if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								if (gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == gOiPPdQXptOcZupOsvpkYdiPsPSw)
								{
									kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Joystick, gOiPPdQXptOcZupOsvpkYdiPsPSw, FiFsRZmsfAlMtxuDUQHizqOuHnljA, PZbZkBoGnFCjWtQvUxrXIJOdhXlgA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj, gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).TptZzDLPedINfuoxMyhBGLwShqDI).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
						rUuIoLygMrbPRHBiyxVlcHXBnAdm rUuIoLygMrbPRHBiyxVlcHXBnAdm2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							rUuIoLygMrbPRHBiyxVlcHXBnAdm2 = this;
						}
						else
						{
							rUuIoLygMrbPRHBiyxVlcHXBnAdm2 = new rUuIoLygMrbPRHBiyxVlcHXBnAdm(0);
							rUuIoLygMrbPRHBiyxVlcHXBnAdm2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						rUuIoLygMrbPRHBiyxVlcHXBnAdm2.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						rUuIoLygMrbPRHBiyxVlcHXBnAdm2.FiFsRZmsfAlMtxuDUQHizqOuHnljA = IrOaOiFrZJrGmpirPsrIrIXKRXRhA;
						rUuIoLygMrbPRHBiyxVlcHXBnAdm2.PZbZkBoGnFCjWtQvUxrXIJOdhXlgA = NHvoQUmVUvFdqqRTiMRJbyTctFXf;
						rUuIoLygMrbPRHBiyxVlcHXBnAdm2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						rUuIoLygMrbPRHBiyxVlcHXBnAdm2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						return rUuIoLygMrbPRHBiyxVlcHXBnAdm2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class saGbpDuiGelCWMLvtoZUsSWHlnbE : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					public ConflictCheckingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public saGbpDuiGelCWMLvtoZUsSWHlnbE(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							ConflictCheckingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00f3;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerId < 0 || WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
							goto IL_011f;
							IL_00f3:
							if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
							{
								ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							kdOQxMRxfBprWWxzhobszTGNskAP = null;
							goto IL_010d;
							IL_011f:
							if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc())
							{
								if (gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == WeJFlXuVmFcPnwQYoDnnchsJRzmFA.controllerId)
								{
									kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.bECRepayJEoXmyRqxiLVebVhEsIGA(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj, gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(aWiJmJHWwqZlYdpLUbqxiFaJSHeg).TptZzDLPedINfuoxMyhBGLwShqDI).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
						saGbpDuiGelCWMLvtoZUsSWHlnbE saGbpDuiGelCWMLvtoZUsSWHlnbE2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							saGbpDuiGelCWMLvtoZUsSWHlnbE2 = this;
						}
						else
						{
							saGbpDuiGelCWMLvtoZUsSWHlnbE2 = new saGbpDuiGelCWMLvtoZUsSWHlnbE(0);
							saGbpDuiGelCWMLvtoZUsSWHlnbE2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						saGbpDuiGelCWMLvtoZUsSWHlnbE2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						saGbpDuiGelCWMLvtoZUsSWHlnbE2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						saGbpDuiGelCWMLvtoZUsSWHlnbE2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						return saGbpDuiGelCWMLvtoZUsSWHlnbE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm;

				private readonly ControllerHelper eHuiQIUmbPfDCAmSwYoMRKeanDnjb;

				private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
					EVSYfBRoRmlZGWzbtVEKHpHdIHIm = P_0;
					eHuiQIUmbPfDCAmSwYoMRKeanDnjb = P_1;
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => zICZZCccXciZUccGppXlkEPUwHKP(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ImeVxUiMMNeZpmFnGKZkLLbaeFAs(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => CdDIAQKzDtmpDvahYvPDoCAEhNxrA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => tulhqQqnyLKnfCJWdcHLOkUWCBnFA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => zICZZCccXciZUccGppXlkEPUwHKP(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ImeVxUiMMNeZpmFnGKZkLLbaeFAs(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => CdDIAQKzDtmpDvahYvPDoCAEhNxrA(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => tulhqQqnyLKnfCJWdcHLOkUWCBnFA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return zICZZCccXciZUccGppXlkEPUwHKP(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ImeVxUiMMNeZpmFnGKZkLLbaeFAs(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return CdDIAQKzDtmpDvahYvPDoCAEhNxrA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return tulhqQqnyLKnfCJWdcHLOkUWCBnFA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => qFiuBxtcrMZNCQdSZzSoDFDyTabj(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => HKXaLFkRUmMDpVePUmSmvgUqQPwO(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => sBtzBSFmJhmBXUwLUdjNmSIdHycV(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => TkjtoAfIkpBwoawmImAIkNkRqtGlA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => qFiuBxtcrMZNCQdSZzSoDFDyTabj(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => HKXaLFkRUmMDpVePUmSmvgUqQPwO(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => sBtzBSFmJhmBXUwLUdjNmSIdHycV(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => TkjtoAfIkpBwoawmImAIkNkRqtGlA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return qFiuBxtcrMZNCQdSZzSoDFDyTabj(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return HKXaLFkRUmMDpVePUmSmvgUqQPwO(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return sBtzBSFmJhmBXUwLUdjNmSIdHycV(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return TkjtoAfIkpBwoawmImAIkNkRqtGlA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => PkedvKucqBZBeMsixdsfvRHEAkYHA(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => wybdezbMizHuACtHjlXhldgRzhkLA(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => KMZAnACDzFMMWtFRhGOEJFRcunSR(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => AUwflLfcFWUOiJhcaHSYydXsBRabA(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => PkedvKucqBZBeMsixdsfvRHEAkYHA(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => wybdezbMizHuACtHjlXhldgRzhkLA(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => KMZAnACDzFMMWtFRhGOEJFRcunSR(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => AUwflLfcFWUOiJhcaHSYydXsBRabA(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return PkedvKucqBZBeMsixdsfvRHEAkYHA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return wybdezbMizHuACtHjlXhldgRzhkLA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return KMZAnACDzFMMWtFRhGOEJFRcunSR(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return AUwflLfcFWUOiJhcaHSYydXsBRabA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => hGvFzVtHWEjUYYZGRbXUWateMzEd(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => mWzmVkMlujVKtaGKzjnqPOwaVEve(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ZTjOEMvfFkcvyHYPehHUpBmTibGib(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => YaBfyVSqvvsWjSsDKoghrsAQVjff(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => hGvFzVtHWEjUYYZGRbXUWateMzEd(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => mWzmVkMlujVKtaGKzjnqPOwaVEve(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ZTjOEMvfFkcvyHYPehHUpBmTibGib(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => YaBfyVSqvvsWjSsDKoghrsAQVjff(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return hGvFzVtHWEjUYYZGRbXUWateMzEd(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return mWzmVkMlujVKtaGKzjnqPOwaVEve(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ZTjOEMvfFkcvyHYPehHUpBmTibGib(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return YaBfyVSqvvsWjSsDKoghrsAQVjff(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool zICZZCccXciZUccGppXlkEPUwHKP(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0 && DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Joystick, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI))
						{
							return true;
						}
					}
					return false;
				}

				private bool zICZZCccXciZUccGppXlkEPUwHKP(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0 && DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI))
						{
							return true;
						}
					}
					return false;
				}

				private bool zICZZCccXciZUccGppXlkEPUwHKP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0.controllerId && DfOJivizqfIPJQnfpwGuHOPlHtax(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI))
						{
							return true;
						}
					}
					return false;
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Keyboard, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return DfOJivizqfIPJQnfpwGuHOPlHtax(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Mouse, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return DfOJivizqfIPJQnfpwGuHOPlHtax(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0 && DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Custom, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI))
						{
							return true;
						}
					}
					return false;
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0 && DfOJivizqfIPJQnfpwGuHOPlHtax(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI))
						{
							return true;
						}
					}
					return false;
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0.controllerId && DfOJivizqfIPJQnfpwGuHOPlHtax(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new rlAClOzMfBeMaSqRfmBGhmLXHYlx(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0,
						IrOaOiFrZJrGmpirPsrIrIXKRXRhA = P_1,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_2,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new rUuIoLygMrbPRHBiyxVlcHXBnAdm(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0,
						IrOaOiFrZJrGmpirPsrIrIXKRXRhA = P_1,
						NHvoQUmVUvFdqqRTiMRJbyTctFXf = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_4
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new saGbpDuiGelCWMLvtoZUsSWHlnbE(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Keyboard, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return bECRepayJEoXmyRqxiLVebVhEsIGA(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Mouse, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return bECRepayJEoXmyRqxiLVebVhEsIGA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return bECRepayJEoXmyRqxiLVebVhEsIGA(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new TtRqhWZWuulwetCBhugDmAwVtfIk(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0,
						wociEpLFbzKolRwnWObGgFZWmpXm = P_1,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_2,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new BcegbOgXRCbuIWNwvWglQGYJRPXIA(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0,
						wociEpLFbzKolRwnWObGgFZWmpXm = P_1,
						NHvoQUmVUvFdqqRTiMRJbyTctFXf = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_4
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new JIVBQnHiAYGmJxhfHNAHiskstUpD(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2
					};
				}

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Joystick, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI);
						}
					}
					return num;
				}

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI);
						}
					}
					return num;
				}

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0.controllerId)
						{
							num += czMydpzERgypAziEXGtLKUcLbCoaA(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI);
						}
					}
					return num;
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Keyboard, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return czMydpzERgypAziEXGtLKUcLbCoaA(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc);
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Mouse, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return czMydpzERgypAziEXGtLKUcLbCoaA(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA);
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Custom, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI);
						}
					}
					return num;
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += czMydpzERgypAziEXGtLKUcLbCoaA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI);
						}
					}
					return num;
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0.controllerId)
						{
							num += czMydpzERgypAziEXGtLKUcLbCoaA(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI);
						}
					}
					return num;
				}

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Joystick, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI, P_4);
						}
					}
					return num;
				}

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI, P_5);
						}
					}
					return num;
				}

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0.controllerId)
						{
							num += sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI, P_3);
						}
					}
					return num;
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Keyboard, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc, P_3);
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc, P_4);
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.hYrEQHtzSgUzJzQQFKbPgtEKWsrc, P_3);
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Mouse, 0, P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA, P_3);
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA, P_4);
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.gthMaiIzQGonAWQggIJCBsFpiAYqA, P_3);
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Custom, P_0, P_1, P_2, P_3, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI, P_4);
						}
					}
					return num;
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							num += sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI, P_5);
						}
					}
					return num;
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0.controllerId)
						{
							num += sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI, P_3);
						}
					}
					return num;
				}

				private bool DfOJivizqfIPJQnfpwGuHOPlHtax<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_5.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !qcLRVIzkIURtsVmxArtISfXIFjRj(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool DfOJivizqfIPJQnfpwGuHOPlHtax<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_6.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !qcLRVIzkIURtsVmxArtISfXIFjRj(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool DfOJivizqfIPJQnfpwGuHOPlHtax<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_3.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !qcLRVIzkIURtsVmxArtISfXIFjRj(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bECRepayJEoXmyRqxiLVebVhEsIGA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_5) where _0001 : ControllerMap
				{
					return new aEhJvfUTurBDKCbcGEiGtHqcWhmL<_0001>(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						vnjysvClwLaZLJZXLIvHXdnrvegb = P_0,
						wknmPPWKOJTFTpcNMaFdaYmTgoNJA = P_1,
						RVMLqQNSslAqwGMuyEJXyoopEWlX = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_4,
						zYmtgfjDPayCuIjLSblcAKweVXRB = P_5
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> bECRepayJEoXmyRqxiLVebVhEsIGA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_6) where _0001 : ControllerMap
				{
					return new FmxKETAVbVbanRNHNhchQmnqaqCN<_0001>(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						vnjysvClwLaZLJZXLIvHXdnrvegb = P_0,
						wknmPPWKOJTFTpcNMaFdaYmTgoNJA = P_1,
						RVMLqQNSslAqwGMuyEJXyoopEWlX = P_2,
						jXfsOUvIRunaSWkrIPvKTOhwUlfV = P_3,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_4,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_5,
						zYmtgfjDPayCuIjLSblcAKweVXRB = P_6
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> bECRepayJEoXmyRqxiLVebVhEsIGA<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_3) where _0001 : ControllerMap
				{
					return new yEfijpLgegfPueAjPfbeFZRruLsr<_0001>(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2,
						zYmtgfjDPayCuIjLSblcAKweVXRB = P_3
					};
				}

				private int czMydpzERgypAziEXGtLKUcLbCoaA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_5.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !qcLRVIzkIURtsVmxArtISfXIFjRj(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int czMydpzERgypAziEXGtLKUcLbCoaA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_6.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !qcLRVIzkIURtsVmxArtISfXIFjRj(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int czMydpzERgypAziEXGtLKUcLbCoaA<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_3.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !qcLRVIzkIURtsVmxArtISfXIFjRj(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int sWqUNaVaNBJPqcgsUJCHjBMovBmz<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_5.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !qcLRVIzkIURtsVmxArtISfXIFjRj(mapCategory, controllerMap)))
						{
							num += controllerMap.sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int sWqUNaVaNBJPqcgsUJCHjBMovBmz<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_6.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !qcLRVIzkIURtsVmxArtISfXIFjRj(inputMapCategory, controllerMap)))
						{
							num += controllerMap.sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int sWqUNaVaNBJPqcgsUJCHjBMovBmz<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.uOrObmhYSFFSSYAgXWUdMpLCHkkc(); i++)
					{
						ControllerMap controllerMap = P_3.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !qcLRVIzkIURtsVmxArtISfXIFjRj(inputMapCategory, controllerMap)))
						{
							num += controllerMap.sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool qcLRVIzkIURtsVmxArtISfXIFjRj(InputMapCategory P_0, ControllerMap P_1)
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
			internal interface SXCOzPpaBVgCpGDHSTAYSkvnQSpe
			{
				DsaFviOLajAIGcAxmEeEgGjWfzgd eLqQPipDQCccAcJjGtKnPvdLRJXEb { get; }

				ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs { get; }

				int mueqHgIkLYeeWIkgOmnbTNFVJkWJ { get; }

				bool kUiCmZCewQfczGBdspnXBabLzrLy(Controller P_0);

				bool kUiCmZCewQfczGBdspnXBabLzrLy(int P_0);

				void vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(int P_0);

				void vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(Controller P_0);

				void WuiyfDSveVmGESDBZkyAfcQMggwx(int P_0);

				Controller BXBKHrCmMwnClRajoDNsKgTWBgIcb(int P_0);

				Controller nOkTvbQKSHGWxOmobkZjUjbFejHs(string P_0);

				int oKnsZBCQtgEufGaLOKQQPSmAuaDB(Controller P_0);

				int oKnsZBCQtgEufGaLOKQQPSmAuaDB(int P_0);

				int sOYaTkmOKzOZEmINPCOCVyaAHHeY(string P_0);

				void HnrFpPpHGPbrJRZcbYcTrFvnwjvi();

				DsaFviOLajAIGcAxmEeEgGjWfzgd USCGiuQyHUkFhIyPnQnjKGLOTfzD(int P_0);

				DsaFviOLajAIGcAxmEeEgGjWfzgd USCGiuQyHUkFhIyPnQnjKGLOTfzD(Controller P_0);

				void CcUGCZEweDezQjHrSyWovXsLGcbg(DsaFviOLajAIGcAxmEeEgGjWfzgd P_0);
			}

			internal interface DsaFviOLajAIGcAxmEeEgGjWfzgd
			{
				GNnLMzlpRKtFyJlexoafWNjfiSkf TptZzDLPedINfuoxMyhBGLwShqDI { get; }

				Controller NlFnBAIUQPMwtvacPcDKoOszCbeW { get; }

				double uGwfwPDkEJpdKZnZXuVKrawXgwbL { get; }
			}

			[DefaultMember("Item")]
			internal sealed class WFpJqeQluRdrTsObLAtdFlaFHUgWA<_0001, _0002> : SXCOzPpaBVgCpGDHSTAYSkvnQSpe where _0001 : Controller where _0002 : ControllerMap
			{
				public class XlqldUOnPwEDWvojhDbBMGKeZXpF : DsaFviOLajAIGcAxmEeEgGjWfzgd
				{
					public _0001 NlFnBAIUQPMwtvacPcDKoOszCbeW;

					public gQqXfkghDzUgcWaoRfIdjveCqyDU<_0002> TptZzDLPedINfuoxMyhBGLwShqDI;

					public double uGwfwPDkEJpdKZnZXuVKrawXgwbL;

					Controller DsaFviOLajAIGcAxmEeEgGjWfzgd.pyVlCoaLSfshrSPImqeYpHmmtksU => NlFnBAIUQPMwtvacPcDKoOszCbeW;

					GNnLMzlpRKtFyJlexoafWNjfiSkf DsaFviOLajAIGcAxmEeEgGjWfzgd.AKbCMShFIFmVguSWitawCsgQCFHmA => TptZzDLPedINfuoxMyhBGLwShqDI;

					double DsaFviOLajAIGcAxmEeEgGjWfzgd.gdMZsZGYFpJVOtRUTQnHfXYyktZq => uGwfwPDkEJpdKZnZXuVKrawXgwbL;

					public XlqldUOnPwEDWvojhDbBMGKeZXpF(_0001 P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0002> P_1)
					{
						NlFnBAIUQPMwtvacPcDKoOszCbeW = P_0;
						TptZzDLPedINfuoxMyhBGLwShqDI = P_1;
					}

					public void bUMuJaeQqjFBSNrQicyffpOEtQCw()
					{
						uGwfwPDkEJpdKZnZXuVKrawXgwbL = ReInput.unscaledTime;
					}
				}

				private List<XlqldUOnPwEDWvojhDbBMGKeZXpF> vgykPhbigkeVbdfSvoLHgDXxKMQQA;

				private List<_0001> OTKODZJutlaUkSfCYDLHiKetROzyA;

				private ReadOnlyCollection<_0001> jjJvZGIvXrjtltrPIUpAImTrzsUf;

				private readonly ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

				int SXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ => vgykPhbigkeVbdfSvoLHgDXxKMQQA.Count;

				public IList<_0001> DGYIefDUHDCgTkMJljXnKsXPXps => jjJvZGIvXrjtltrPIUpAImTrzsUf;

				public XlqldUOnPwEDWvojhDbBMGKeZXpF eLqQPipDQCccAcJjGtKnPvdLRJXEb => vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0];

				ControllerType SXCOzPpaBVgCpGDHSTAYSkvnQSpe.qwgjCbRzxrpcbcpGuDjyBQzIUaDs => FHHqpHICfRrjYzaZOfxGJuaReWmv;

				DsaFviOLajAIGcAxmEeEgGjWfzgd SXCOzPpaBVgCpGDHSTAYSkvnQSpe.xTxGJEAramlWWCqKFIAKBdRPrPuPc => vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0];

				public WFpJqeQluRdrTsObLAtdFlaFHUgWA()
				{
					if ((object)DXYiJElpUHxcPboaihvPaElwMWxMA.agDbGadWfnhyiYMklBvLcHCFdoAn<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					FHHqpHICfRrjYzaZOfxGJuaReWmv = DXYiJElpUHxcPboaihvPaElwMWxMA.MXBTEGohIsfZjKPxjsPkPtPwYYfA(typeof(_0001));
					vgykPhbigkeVbdfSvoLHgDXxKMQQA = new List<XlqldUOnPwEDWvojhDbBMGKeZXpF>();
					OTKODZJutlaUkSfCYDLHiKetROzyA = new List<_0001>();
					jjJvZGIvXrjtltrPIUpAImTrzsUf = new ReadOnlyCollection<_0001>(OTKODZJutlaUkSfCYDLHiKetROzyA);
				}

				public XlqldUOnPwEDWvojhDbBMGKeZXpF USCGiuQyHUkFhIyPnQnjKGLOTfzD(int P_0)
				{
					if (FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Keyboard || FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0);
					if (num < 0)
					{
						return null;
					}
					return vgykPhbigkeVbdfSvoLHgDXxKMQQA[num];
				}

				public XlqldUOnPwEDWvojhDbBMGKeZXpF USCGiuQyHUkFhIyPnQnjKGLOTfzD(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return USCGiuQyHUkFhIyPnQnjKGLOTfzD(P_0.id);
				}

				public void CcUGCZEweDezQjHrSyWovXsLGcbg(XlqldUOnPwEDWvojhDbBMGKeZXpF P_0)
				{
					if (P_0 != null)
					{
						vgykPhbigkeVbdfSvoLHgDXxKMQQA.Add(P_0);
						OTKODZJutlaUkSfCYDLHiKetROzyA.Add(P_0.NlFnBAIUQPMwtvacPcDKoOszCbeW);
					}
				}

				public void vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(int P_0)
				{
					if (FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Keyboard || FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Count; i++)
					{
						if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[i].NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							WuiyfDSveVmGESDBZkyAfcQMggwx(i);
							break;
						}
					}
				}

				void SXCOzPpaBVgCpGDHSTAYSkvnQSpe.vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in vTTGlUJsIZEYJJmZLyYCiUGZmgUiA
					this.vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(P_0);
				}

				public void vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(_0001 P_0)
				{
					if (P_0 != null && P_0.type == FHHqpHICfRrjYzaZOfxGJuaReWmv)
					{
						vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(P_0.id);
					}
				}

				public void WuiyfDSveVmGESDBZkyAfcQMggwx(int P_0)
				{
					if (P_0 >= 0 && P_0 < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Count)
					{
						vgykPhbigkeVbdfSvoLHgDXxKMQQA.RemoveAt(P_0);
						OTKODZJutlaUkSfCYDLHiKetROzyA.RemoveAt(P_0);
					}
				}

				void SXCOzPpaBVgCpGDHSTAYSkvnQSpe.WuiyfDSveVmGESDBZkyAfcQMggwx(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in WuiyfDSveVmGESDBZkyAfcQMggwx
					this.WuiyfDSveVmGESDBZkyAfcQMggwx(P_0);
				}

				public _0001 BXBKHrCmMwnClRajoDNsKgTWBgIcb(int P_0)
				{
					if (FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Keyboard || FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0);
					if (num < 0)
					{
						return null;
					}
					return vgykPhbigkeVbdfSvoLHgDXxKMQQA[num].NlFnBAIUQPMwtvacPcDKoOszCbeW;
				}

				public bool kUiCmZCewQfczGBdspnXBabLzrLy(int P_0)
				{
					if (FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Keyboard || FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Count; i++)
					{
						if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[i].NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool SXCOzPpaBVgCpGDHSTAYSkvnQSpe.kUiCmZCewQfczGBdspnXBabLzrLy(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in kUiCmZCewQfczGBdspnXBabLzrLy
					return this.kUiCmZCewQfczGBdspnXBabLzrLy(P_0);
				}

				public bool kUiCmZCewQfczGBdspnXBabLzrLy(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != FHHqpHICfRrjYzaZOfxGJuaReWmv)
					{
						return false;
					}
					return kUiCmZCewQfczGBdspnXBabLzrLy(P_0.id);
				}

				public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(int P_0)
				{
					if (FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Keyboard || FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Count; i++)
					{
						if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[i].NlFnBAIUQPMwtvacPcDKoOszCbeW.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int SXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in oKnsZBCQtgEufGaLOKQQPSmAuaDB
					return this.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0);
				}

				public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != FHHqpHICfRrjYzaZOfxGJuaReWmv)
					{
						return -1;
					}
					return oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0.id);
				}

				public int sOYaTkmOKzOZEmINPCOCVyaAHHeY(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Count; i++)
					{
						if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[i].NlFnBAIUQPMwtvacPcDKoOszCbeW.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int SXCOzPpaBVgCpGDHSTAYSkvnQSpe.sOYaTkmOKzOZEmINPCOCVyaAHHeY(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in sOYaTkmOKzOZEmINPCOCVyaAHHeY
					return this.sOYaTkmOKzOZEmINPCOCVyaAHHeY(P_0);
				}

				public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
				{
					vgykPhbigkeVbdfSvoLHgDXxKMQQA.Clear();
					OTKODZJutlaUkSfCYDLHiKetROzyA.Clear();
				}

				void SXCOzPpaBVgCpGDHSTAYSkvnQSpe.HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
				{
					//ILSpy generated this explicit interface implementation from .override directive in HnrFpPpHGPbrJRZcbYcTrFvnwjvi
					this.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				}

				private DsaFviOLajAIGcAxmEeEgGjWfzgd MgaEHRAAeoYrhTGEDSTEQbPyAyZy(int P_0)
				{
					return USCGiuQyHUkFhIyPnQnjKGLOTfzD(P_0);
				}

				DsaFviOLajAIGcAxmEeEgGjWfzgd SXCOzPpaBVgCpGDHSTAYSkvnQSpe.USCGiuQyHUkFhIyPnQnjKGLOTfzD(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in MgaEHRAAeoYrhTGEDSTEQbPyAyZy
					return this.MgaEHRAAeoYrhTGEDSTEQbPyAyZy(P_0);
				}

				private DsaFviOLajAIGcAxmEeEgGjWfzgd MgaEHRAAeoYrhTGEDSTEQbPyAyZy(Controller P_0)
				{
					if (P_0 as _0001 == null)
					{
						return null;
					}
					return USCGiuQyHUkFhIyPnQnjKGLOTfzD(P_0 as _0001);
				}

				DsaFviOLajAIGcAxmEeEgGjWfzgd SXCOzPpaBVgCpGDHSTAYSkvnQSpe.USCGiuQyHUkFhIyPnQnjKGLOTfzD(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in MgaEHRAAeoYrhTGEDSTEQbPyAyZy
					return this.MgaEHRAAeoYrhTGEDSTEQbPyAyZy(P_0);
				}

				private void WsyiNNGeYBPSZWEgGxCkWknxEHZb(DsaFviOLajAIGcAxmEeEgGjWfzgd P_0)
				{
					CcUGCZEweDezQjHrSyWovXsLGcbg((XlqldUOnPwEDWvojhDbBMGKeZXpF)P_0);
				}

				void SXCOzPpaBVgCpGDHSTAYSkvnQSpe.CcUGCZEweDezQjHrSyWovXsLGcbg(DsaFviOLajAIGcAxmEeEgGjWfzgd P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in WsyiNNGeYBPSZWEgGxCkWknxEHZb
					this.WsyiNNGeYBPSZWEgGxCkWknxEHZb(P_0);
				}

				private void nXJYzFKagTfAOHKPWAqBqaXzHxqOA(Controller P_0)
				{
					vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(P_0 as _0001);
				}

				void SXCOzPpaBVgCpGDHSTAYSkvnQSpe.vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in nXJYzFKagTfAOHKPWAqBqaXzHxqOA
					this.nXJYzFKagTfAOHKPWAqBqaXzHxqOA(P_0);
				}

				private Controller giNBWwYrUGjmxcTiLBEcInQIiUGO(int P_0)
				{
					return BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
				}

				Controller SXCOzPpaBVgCpGDHSTAYSkvnQSpe.BXBKHrCmMwnClRajoDNsKgTWBgIcb(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in giNBWwYrUGjmxcTiLBEcInQIiUGO
					return this.giNBWwYrUGjmxcTiLBEcInQIiUGO(P_0);
				}

				private bool GUyxkevuezKENpbezYRrOQUJaALR(Controller P_0)
				{
					return kUiCmZCewQfczGBdspnXBabLzrLy(P_0 as _0001);
				}

				bool SXCOzPpaBVgCpGDHSTAYSkvnQSpe.kUiCmZCewQfczGBdspnXBabLzrLy(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in GUyxkevuezKENpbezYRrOQUJaALR
					return this.GUyxkevuezKENpbezYRrOQUJaALR(P_0);
				}

				private int sezQderZxVtWacSMeRcmahxWXGbY(Controller P_0)
				{
					return oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0 as _0001);
				}

				int SXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in sezQderZxVtWacSMeRcmahxWXGbY
					return this.sezQderZxVtWacSMeRcmahxWXGbY(P_0);
				}

				private Controller hrlTuWNQYFUWRQkfkrPLxdbGWjPn(string P_0)
				{
					int num = sOYaTkmOKzOZEmINPCOCVyaAHHeY(P_0);
					if (num < 0)
					{
						return null;
					}
					return vgykPhbigkeVbdfSvoLHgDXxKMQQA[num].NlFnBAIUQPMwtvacPcDKoOszCbeW;
				}

				Controller SXCOzPpaBVgCpGDHSTAYSkvnQSpe.nOkTvbQKSHGWxOmobkZjUjbFejHs(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in hrlTuWNQYFUWRQkfkrPLxdbGWjPn
					return this.hrlTuWNQYFUWRQkfkrPLxdbGWjPn(P_0);
				}
			}

			internal class IeLBOIaMcgdDkrPSUjVKJmcCVPTh
			{
				public readonly int mueqHgIkLYeeWIkgOmnbTNFVJkWJ;

				private ControllerType[] GiBmJGgWLyPSRLUkdDrDQSSHLcjc;

				private SXCOzPpaBVgCpGDHSTAYSkvnQSpe[] fpKyQVVRtVTHrZDhZIZVLdtLBoQiA;

				public SXCOzPpaBVgCpGDHSTAYSkvnQSpe hxBYYsnPbJHHRUcGFZWKtdBDPbOO(int P_0)
				{
					return fpKyQVVRtVTHrZDhZIZVLdtLBoQiA[P_0];
				}

				public ControllerType LeEsMlgZmXpMgkJaNUVyZJfYGbYB(int P_0)
				{
					return GiBmJGgWLyPSRLUkdDrDQSSHLcjc[P_0];
				}

				public IeLBOIaMcgdDkrPSUjVKJmcCVPTh(int P_0)
				{
					mueqHgIkLYeeWIkgOmnbTNFVJkWJ = MathTools.Max(0, P_0);
					GiBmJGgWLyPSRLUkdDrDQSSHLcjc = new ControllerType[P_0];
					fpKyQVVRtVTHrZDhZIZVLdtLBoQiA = new SXCOzPpaBVgCpGDHSTAYSkvnQSpe[P_0];
				}

				public SXCOzPpaBVgCpGDHSTAYSkvnQSpe xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType P_0)
				{
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						if (P_0 == GiBmJGgWLyPSRLUkdDrDQSSHLcjc[i])
						{
							return fpKyQVVRtVTHrZDhZIZVLdtLBoQiA[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void QJWXdgrgJOldCwgJHcUABiRFVvoo(int P_0, ControllerType P_1, SXCOzPpaBVgCpGDHSTAYSkvnQSpe P_2)
				{
					GiBmJGgWLyPSRLUkdDrDQSSHLcjc[P_0] = P_1;
					fpKyQVVRtVTHrZDhZIZVLdtLBoQiA[P_0] = P_2;
				}
			}

			private class NMuECpOqnCZghHDQvwyeWgvyRblU
			{
				public class tOpMLMVaYQCkprKEImznVyIboOKw
				{
					public int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> TptZzDLPedINfuoxMyhBGLwShqDI;

					public double LGHGvxJRMFevzDjAkzcZGueGpawVA;

					public tOpMLMVaYQCkprKEImznVyIboOKw(int P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> P_1, double P_2)
					{
						gOiPPdQXptOcZupOsvpkYdiPsPSw = P_0;
						TptZzDLPedINfuoxMyhBGLwShqDI = P_1;
						LGHGvxJRMFevzDjAkzcZGueGpawVA = P_2;
					}
				}

				private readonly List<tOpMLMVaYQCkprKEImznVyIboOKw> LztWhAIbukRXonlavhcowoysBOjjA;

				private readonly Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm;

				public NMuECpOqnCZghHDQvwyeWgvyRblU(Player P_0)
				{
					EVSYfBRoRmlZGWzbtVEKHpHdIHIm = P_0;
					LztWhAIbukRXonlavhcowoysBOjjA = new List<tOpMLMVaYQCkprKEImznVyIboOKw>();
				}

				public void XwxmMWfpySNSMASbMCDIaCKEBrGP(Joystick P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> P_1)
				{
					for (int i = 0; i < LztWhAIbukRXonlavhcowoysBOjjA.Count; i++)
					{
						tOpMLMVaYQCkprKEImznVyIboOKw tOpMLMVaYQCkprKEImznVyIboOKw2 = LztWhAIbukRXonlavhcowoysBOjjA[i];
						if (tOpMLMVaYQCkprKEImznVyIboOKw2.gOiPPdQXptOcZupOsvpkYdiPsPSw == P_0.id)
						{
							tOpMLMVaYQCkprKEImznVyIboOKw2.TptZzDLPedINfuoxMyhBGLwShqDI = P_1;
							tOpMLMVaYQCkprKEImznVyIboOKw2.LGHGvxJRMFevzDjAkzcZGueGpawVA = ReInput.realTime;
							return;
						}
					}
					tOpMLMVaYQCkprKEImznVyIboOKw item = new tOpMLMVaYQCkprKEImznVyIboOKw(P_0.id, P_1, ReInput.realTime);
					LztWhAIbukRXonlavhcowoysBOjjA.Add(item);
				}

				public void XwxmMWfpySNSMASbMCDIaCKEBrGP(WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF P_0)
				{
					XwxmMWfpySNSMASbMCDIaCKEBrGP(P_0.NlFnBAIUQPMwtvacPcDKoOszCbeW, P_0.TptZzDLPedINfuoxMyhBGLwShqDI);
				}

				public void VUZmAykhHLsWLfavrDegXhDpAMeHA()
				{
					for (int i = 0; i < LztWhAIbukRXonlavhcowoysBOjjA.Count; i++)
					{
						if (!EVSYfBRoRmlZGWzbtVEKHpHdIHIm.controllers.ContainsController(ControllerType.Joystick, LztWhAIbukRXonlavhcowoysBOjjA[i].gOiPPdQXptOcZupOsvpkYdiPsPSw))
						{
							LztWhAIbukRXonlavhcowoysBOjjA[i].TptZzDLPedINfuoxMyhBGLwShqDI = null;
						}
					}
				}

				public tOpMLMVaYQCkprKEImznVyIboOKw qvSSugCCSQvBSEBLimOCnZkOkXpP(int P_0)
				{
					int num = oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0);
					if (num < 0)
					{
						return null;
					}
					return LztWhAIbukRXonlavhcowoysBOjjA[num];
				}

				public bool kUiCmZCewQfczGBdspnXBabLzrLy(int P_0)
				{
					for (int i = 0; i < LztWhAIbukRXonlavhcowoysBOjjA.Count; i++)
					{
						if (LztWhAIbukRXonlavhcowoysBOjjA[i].gOiPPdQXptOcZupOsvpkYdiPsPSw == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(int P_0)
				{
					for (int i = 0; i < LztWhAIbukRXonlavhcowoysBOjjA.Count; i++)
					{
						if (LztWhAIbukRXonlavhcowoysBOjjA[i].gOiPPdQXptOcZupOsvpkYdiPsPSw == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
				{
					LztWhAIbukRXonlavhcowoysBOjjA.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class kMVyJQiWjzaAbRhbJEgZmTPcFsqq : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private int xwKWiAPvHlDAuRWHTihmtTQXNyEp;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe VUxdgmAHeNjWtdVKcnoPRwcKLjrHB;

					private int pvKHDqdhKjwKxxMRvhkcvrrdjQmc;

					private int KPzcVBnmZXDxZtyglRXvOitPTlXE;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf zrAheEDsRBptOGaOaooUrJvheremc;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					private IEnumerator<ActionElementMap> MwxNdpIagihdSIFhJiFBDdHBndQcB;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public kMVyJQiWjzaAbRhbJEgZmTPcFsqq(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0177;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
							{
								ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
								return false;
							}
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							xwKWiAPvHlDAuRWHTihmtTQXNyEp = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_01f7;
							IL_0177:
							if (MwxNdpIagihdSIFhJiFBDdHBndQcB.MoveNext())
							{
								ActionElementMap current = MwxNdpIagihdSIFhJiFBDdHBndQcB.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MwxNdpIagihdSIFhJiFBDdHBndQcB = null;
							goto IL_0191;
							IL_0191:
							NzdxphehSibRzjWKzxPfRniEANPG++;
							goto IL_01a3;
							IL_01cd:
							if (KPzcVBnmZXDxZtyglRXvOitPTlXE < pvKHDqdhKjwKxxMRvhkcvrrdjQmc)
							{
								zrAheEDsRBptOGaOaooUrJvheremc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.wBgVECvNnnPzuAKlDGDoAWwKEEhT(KPzcVBnmZXDxZtyglRXvOitPTlXE).TptZzDLPedINfuoxMyhBGLwShqDI;
								JkaoTQsxRcqYFKIdAdYYqerngJbC = zrAheEDsRBptOGaOaooUrJvheremc.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								NzdxphehSibRzjWKzxPfRniEANPG = 0;
								goto IL_01a3;
							}
							VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_01f7;
							IL_01a3:
							if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
							{
								if (zrAheEDsRBptOGaOaooUrJvheremc.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG) is ControllerMapWithAxes controllerMapWithAxes && (!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									MwxNdpIagihdSIFhJiFBDdHBndQcB = controllerMapWithAxes.AxisMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							zrAheEDsRBptOGaOaooUrJvheremc = null;
							KPzcVBnmZXDxZtyglRXvOitPTlXE++;
							goto IL_01cd;
							IL_01f7:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < xwKWiAPvHlDAuRWHTihmtTQXNyEp)
							{
								VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(eolRghqutZOOIGqvOFTzJOGfYTsn);
								pvKHDqdhKjwKxxMRvhkcvrrdjQmc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								KPzcVBnmZXDxZtyglRXvOitPTlXE = 0;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MwxNdpIagihdSIFhJiFBDdHBndQcB != null)
						{
							MwxNdpIagihdSIFhJiFBDdHBndQcB.Dispose();
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
						kMVyJQiWjzaAbRhbJEgZmTPcFsqq kMVyJQiWjzaAbRhbJEgZmTPcFsqq2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							kMVyJQiWjzaAbRhbJEgZmTPcFsqq2 = this;
						}
						else
						{
							kMVyJQiWjzaAbRhbJEgZmTPcFsqq2 = new kMVyJQiWjzaAbRhbJEgZmTPcFsqq(0);
							kMVyJQiWjzaAbRhbJEgZmTPcFsqq2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						kMVyJQiWjzaAbRhbJEgZmTPcFsqq2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						kMVyJQiWjzaAbRhbJEgZmTPcFsqq2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return kMVyJQiWjzaAbRhbJEgZmTPcFsqq2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class bxbekWJPVzTNlROpPIjWWfEeIaWJ : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private int xwKWiAPvHlDAuRWHTihmtTQXNyEp;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe VUxdgmAHeNjWtdVKcnoPRwcKLjrHB;

					private int pvKHDqdhKjwKxxMRvhkcvrrdjQmc;

					private int KPzcVBnmZXDxZtyglRXvOitPTlXE;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf zrAheEDsRBptOGaOaooUrJvheremc;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					private IEnumerator<ActionElementMap> MwxNdpIagihdSIFhJiFBDdHBndQcB;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public bxbekWJPVzTNlROpPIjWWfEeIaWJ(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_016c;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
							{
								ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
								return false;
							}
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							xwKWiAPvHlDAuRWHTihmtTQXNyEp = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_01ec;
							IL_016c:
							if (MwxNdpIagihdSIFhJiFBDdHBndQcB.MoveNext())
							{
								ActionElementMap current = MwxNdpIagihdSIFhJiFBDdHBndQcB.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MwxNdpIagihdSIFhJiFBDdHBndQcB = null;
							goto IL_0186;
							IL_0186:
							NzdxphehSibRzjWKzxPfRniEANPG++;
							goto IL_0198;
							IL_01c2:
							if (KPzcVBnmZXDxZtyglRXvOitPTlXE < pvKHDqdhKjwKxxMRvhkcvrrdjQmc)
							{
								zrAheEDsRBptOGaOaooUrJvheremc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.wBgVECvNnnPzuAKlDGDoAWwKEEhT(KPzcVBnmZXDxZtyglRXvOitPTlXE).TptZzDLPedINfuoxMyhBGLwShqDI;
								JkaoTQsxRcqYFKIdAdYYqerngJbC = zrAheEDsRBptOGaOaooUrJvheremc.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								NzdxphehSibRzjWKzxPfRniEANPG = 0;
								goto IL_0198;
							}
							VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_01ec;
							IL_0198:
							if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
							{
								ControllerMap controllerMap = zrAheEDsRBptOGaOaooUrJvheremc.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG);
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMap.enabled) && controllerMap.ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									MwxNdpIagihdSIFhJiFBDdHBndQcB = controllerMap.ButtonMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							zrAheEDsRBptOGaOaooUrJvheremc = null;
							KPzcVBnmZXDxZtyglRXvOitPTlXE++;
							goto IL_01c2;
							IL_01ec:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < xwKWiAPvHlDAuRWHTihmtTQXNyEp)
							{
								VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(eolRghqutZOOIGqvOFTzJOGfYTsn);
								pvKHDqdhKjwKxxMRvhkcvrrdjQmc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								KPzcVBnmZXDxZtyglRXvOitPTlXE = 0;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MwxNdpIagihdSIFhJiFBDdHBndQcB != null)
						{
							MwxNdpIagihdSIFhJiFBDdHBndQcB.Dispose();
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
						bxbekWJPVzTNlROpPIjWWfEeIaWJ bxbekWJPVzTNlROpPIjWWfEeIaWJ2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							bxbekWJPVzTNlROpPIjWWfEeIaWJ2 = this;
						}
						else
						{
							bxbekWJPVzTNlROpPIjWWfEeIaWJ2 = new bxbekWJPVzTNlROpPIjWWfEeIaWJ(0);
							bxbekWJPVzTNlROpPIjWWfEeIaWJ2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						bxbekWJPVzTNlROpPIjWWfEeIaWJ2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						bxbekWJPVzTNlROpPIjWWfEeIaWJ2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return bxbekWJPVzTNlROpPIjWWfEeIaWJ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class eReuXNfWHJJwKGPdWbvbXsbCPhxl : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IList<ControllerMap> zOZbwwaKOrLRdsAGKllBbfGbvckmb;

					private int GMqtCaMlQBCNVPqPhjaGBGDgwvTfA;

					private IEnumerator<ActionElementMap> LUEmcHMCyddiegmmbfvPKwLXlRcs;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public eReuXNfWHJJwKGPdWbvbXsbCPhxl(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0150;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_01ab;
							IL_0150:
							if (LUEmcHMCyddiegmmbfvPKwLXlRcs.MoveNext())
							{
								ActionElementMap current = LUEmcHMCyddiegmmbfvPKwLXlRcs.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							LUEmcHMCyddiegmmbfvPKwLXlRcs = null;
							goto IL_016a;
							IL_017c:
							if (GMqtCaMlQBCNVPqPhjaGBGDgwvTfA < zOZbwwaKOrLRdsAGKllBbfGbvckmb.Count)
							{
								if (!(zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].enabled) && zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									LUEmcHMCyddiegmmbfvPKwLXlRcs = (zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA] as ControllerMapWithAxes).AxisMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							zOZbwwaKOrLRdsAGKllBbfGbvckmb = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_01ab;
							IL_016a:
							GMqtCaMlQBCNVPqPhjaGBGDgwvTfA++;
							goto IL_017c;
							IL_01ab:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ)
							{
								zOZbwwaKOrLRdsAGKllBbfGbvckmb = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(eolRghqutZOOIGqvOFTzJOGfYTsn).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
								GMqtCaMlQBCNVPqPhjaGBGDgwvTfA = 0;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (LUEmcHMCyddiegmmbfvPKwLXlRcs != null)
						{
							LUEmcHMCyddiegmmbfvPKwLXlRcs.Dispose();
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
						eReuXNfWHJJwKGPdWbvbXsbCPhxl eReuXNfWHJJwKGPdWbvbXsbCPhxl2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							eReuXNfWHJJwKGPdWbvbXsbCPhxl2 = this;
						}
						else
						{
							eReuXNfWHJJwKGPdWbvbXsbCPhxl2 = new eReuXNfWHJJwKGPdWbvbXsbCPhxl(0);
							eReuXNfWHJJwKGPdWbvbXsbCPhxl2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						eReuXNfWHJJwKGPdWbvbXsbCPhxl2.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						eReuXNfWHJJwKGPdWbvbXsbCPhxl2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						eReuXNfWHJJwKGPdWbvbXsbCPhxl2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return eReuXNfWHJJwKGPdWbvbXsbCPhxl2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class imBgocRWAYxWpEMUTXslgkOyECrH : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private IList<ControllerMap> TGIBJpiYBDdIZLuxcgKiqMfbSUMDb;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ActionElementMap> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public imBgocRWAYxWpEMUTXslgkOyECrH(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_014f;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
							int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(ewwLiKFmCKbnVFhcViVbHODDzYHW);
							if (num < 0)
							{
								return false;
							}
							TGIBJpiYBDdIZLuxcgKiqMfbSUMDb = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_017b;
							IL_014f:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ActionElementMap current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							goto IL_0169;
							IL_017b:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < TGIBJpiYBDdIZLuxcgKiqMfbSUMDb.Count)
							{
								if (!(TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].enabled) && TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = (TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn] as ControllerMapWithAxes).AxisMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						imBgocRWAYxWpEMUTXslgkOyECrH imBgocRWAYxWpEMUTXslgkOyECrH2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							imBgocRWAYxWpEMUTXslgkOyECrH2 = this;
						}
						else
						{
							imBgocRWAYxWpEMUTXslgkOyECrH2 = new imBgocRWAYxWpEMUTXslgkOyECrH(0);
							imBgocRWAYxWpEMUTXslgkOyECrH2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						imBgocRWAYxWpEMUTXslgkOyECrH2.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						imBgocRWAYxWpEMUTXslgkOyECrH2.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						imBgocRWAYxWpEMUTXslgkOyECrH2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						imBgocRWAYxWpEMUTXslgkOyECrH2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return imBgocRWAYxWpEMUTXslgkOyECrH2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class xDUlGoJpijiacNJcqbyEoCpZefgS : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IList<ControllerMap> zOZbwwaKOrLRdsAGKllBbfGbvckmb;

					private int GMqtCaMlQBCNVPqPhjaGBGDgwvTfA;

					private IEnumerator<ActionElementMap> LUEmcHMCyddiegmmbfvPKwLXlRcs;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public xDUlGoJpijiacNJcqbyEoCpZefgS(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_012c;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0187;
							IL_012c:
							if (LUEmcHMCyddiegmmbfvPKwLXlRcs.MoveNext())
							{
								ActionElementMap current = LUEmcHMCyddiegmmbfvPKwLXlRcs.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							LUEmcHMCyddiegmmbfvPKwLXlRcs = null;
							goto IL_0146;
							IL_0158:
							if (GMqtCaMlQBCNVPqPhjaGBGDgwvTfA < zOZbwwaKOrLRdsAGKllBbfGbvckmb.Count)
							{
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].enabled) && zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									LUEmcHMCyddiegmmbfvPKwLXlRcs = zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].ButtonMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							zOZbwwaKOrLRdsAGKllBbfGbvckmb = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_0187;
							IL_0146:
							GMqtCaMlQBCNVPqPhjaGBGDgwvTfA++;
							goto IL_0158;
							IL_0187:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ)
							{
								zOZbwwaKOrLRdsAGKllBbfGbvckmb = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(eolRghqutZOOIGqvOFTzJOGfYTsn).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
								GMqtCaMlQBCNVPqPhjaGBGDgwvTfA = 0;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (LUEmcHMCyddiegmmbfvPKwLXlRcs != null)
						{
							LUEmcHMCyddiegmmbfvPKwLXlRcs.Dispose();
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
						xDUlGoJpijiacNJcqbyEoCpZefgS xDUlGoJpijiacNJcqbyEoCpZefgS2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							xDUlGoJpijiacNJcqbyEoCpZefgS2 = this;
						}
						else
						{
							xDUlGoJpijiacNJcqbyEoCpZefgS2 = new xDUlGoJpijiacNJcqbyEoCpZefgS(0);
							xDUlGoJpijiacNJcqbyEoCpZefgS2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						xDUlGoJpijiacNJcqbyEoCpZefgS2.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						xDUlGoJpijiacNJcqbyEoCpZefgS2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						xDUlGoJpijiacNJcqbyEoCpZefgS2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return xDUlGoJpijiacNJcqbyEoCpZefgS2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class QJNkrcMmWdxPeTHyzaYxDuclDxMMA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private IList<ControllerMap> TGIBJpiYBDdIZLuxcgKiqMfbSUMDb;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ActionElementMap> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public QJNkrcMmWdxPeTHyzaYxDuclDxMMA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_012b;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
							int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(ewwLiKFmCKbnVFhcViVbHODDzYHW);
							if (num < 0)
							{
								return false;
							}
							TGIBJpiYBDdIZLuxcgKiqMfbSUMDb = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0157;
							IL_012b:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ActionElementMap current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							goto IL_0145;
							IL_0157:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < TGIBJpiYBDdIZLuxcgKiqMfbSUMDb.Count)
							{
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].enabled) && TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].ButtonMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						QJNkrcMmWdxPeTHyzaYxDuclDxMMA qJNkrcMmWdxPeTHyzaYxDuclDxMMA;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							qJNkrcMmWdxPeTHyzaYxDuclDxMMA = this;
						}
						else
						{
							qJNkrcMmWdxPeTHyzaYxDuclDxMMA = new QJNkrcMmWdxPeTHyzaYxDuclDxMMA(0);
							qJNkrcMmWdxPeTHyzaYxDuclDxMMA.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						qJNkrcMmWdxPeTHyzaYxDuclDxMMA.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						qJNkrcMmWdxPeTHyzaYxDuclDxMMA.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						qJNkrcMmWdxPeTHyzaYxDuclDxMMA.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						qJNkrcMmWdxPeTHyzaYxDuclDxMMA.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return qJNkrcMmWdxPeTHyzaYxDuclDxMMA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class KSWRodpGJcSOBCatlPeFCfALRcBP : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IList<ControllerMap> zOZbwwaKOrLRdsAGKllBbfGbvckmb;

					private int GMqtCaMlQBCNVPqPhjaGBGDgwvTfA;

					private IEnumerator<ActionElementMap> LUEmcHMCyddiegmmbfvPKwLXlRcs;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public KSWRodpGJcSOBCatlPeFCfALRcBP(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_012c;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0187;
							IL_012c:
							if (LUEmcHMCyddiegmmbfvPKwLXlRcs.MoveNext())
							{
								ActionElementMap current = LUEmcHMCyddiegmmbfvPKwLXlRcs.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							LUEmcHMCyddiegmmbfvPKwLXlRcs = null;
							goto IL_0146;
							IL_0158:
							if (GMqtCaMlQBCNVPqPhjaGBGDgwvTfA < zOZbwwaKOrLRdsAGKllBbfGbvckmb.Count)
							{
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].enabled) && zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									LUEmcHMCyddiegmmbfvPKwLXlRcs = zOZbwwaKOrLRdsAGKllBbfGbvckmb[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].ElementMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							zOZbwwaKOrLRdsAGKllBbfGbvckmb = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_0187;
							IL_0146:
							GMqtCaMlQBCNVPqPhjaGBGDgwvTfA++;
							goto IL_0158;
							IL_0187:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ)
							{
								zOZbwwaKOrLRdsAGKllBbfGbvckmb = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(eolRghqutZOOIGqvOFTzJOGfYTsn).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
								GMqtCaMlQBCNVPqPhjaGBGDgwvTfA = 0;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (LUEmcHMCyddiegmmbfvPKwLXlRcs != null)
						{
							LUEmcHMCyddiegmmbfvPKwLXlRcs.Dispose();
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
						KSWRodpGJcSOBCatlPeFCfALRcBP kSWRodpGJcSOBCatlPeFCfALRcBP;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							kSWRodpGJcSOBCatlPeFCfALRcBP = this;
						}
						else
						{
							kSWRodpGJcSOBCatlPeFCfALRcBP = new KSWRodpGJcSOBCatlPeFCfALRcBP(0);
							kSWRodpGJcSOBCatlPeFCfALRcBP.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						kSWRodpGJcSOBCatlPeFCfALRcBP.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						kSWRodpGJcSOBCatlPeFCfALRcBP.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						kSWRodpGJcSOBCatlPeFCfALRcBP.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return kSWRodpGJcSOBCatlPeFCfALRcBP;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class xiJMEzeKrtMwQVffhoDrflrBzAjg : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private IList<ControllerMap> TGIBJpiYBDdIZLuxcgKiqMfbSUMDb;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ActionElementMap> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public xiJMEzeKrtMwQVffhoDrflrBzAjg(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_012b;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
							int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(ewwLiKFmCKbnVFhcViVbHODDzYHW);
							if (num < 0)
							{
								return false;
							}
							TGIBJpiYBDdIZLuxcgKiqMfbSUMDb = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0157;
							IL_012b:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ActionElementMap current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							goto IL_0145;
							IL_0157:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < TGIBJpiYBDdIZLuxcgKiqMfbSUMDb.Count)
							{
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].enabled) && TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].ElementMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						xiJMEzeKrtMwQVffhoDrflrBzAjg xiJMEzeKrtMwQVffhoDrflrBzAjg2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							xiJMEzeKrtMwQVffhoDrflrBzAjg2 = this;
						}
						else
						{
							xiJMEzeKrtMwQVffhoDrflrBzAjg2 = new xiJMEzeKrtMwQVffhoDrflrBzAjg(0);
							xiJMEzeKrtMwQVffhoDrflrBzAjg2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						xiJMEzeKrtMwQVffhoDrflrBzAjg2.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						xiJMEzeKrtMwQVffhoDrflrBzAjg2.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						xiJMEzeKrtMwQVffhoDrflrBzAjg2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						xiJMEzeKrtMwQVffhoDrflrBzAjg2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return xiJMEzeKrtMwQVffhoDrflrBzAjg2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class eqlGGMFbVJnvDtzveODlyQwHsCDK : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private int FYaAMRGqoDSSWPerFwNcTLQJyYeP;

					public int qHziAbvFUwsFWKYqEOolHHfukCxi;

					private IList<ControllerMap> TGIBJpiYBDdIZLuxcgKiqMfbSUMDb;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public eqlGGMFbVJnvDtzveODlyQwHsCDK(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return false;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_00b0;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(ewwLiKFmCKbnVFhcViVbHODDzYHW);
						if (num < 0)
						{
							return false;
						}
						TGIBJpiYBDdIZLuxcgKiqMfbSUMDb = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
						eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
						goto IL_00c2;
						IL_00c2:
						if (eolRghqutZOOIGqvOFTzJOGfYTsn < TGIBJpiYBDdIZLuxcgKiqMfbSUMDb.Count)
						{
							if (TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].categoryId == FYaAMRGqoDSSWPerFwNcTLQJyYeP)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn];
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						eolRghqutZOOIGqvOFTzJOGfYTsn++;
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
						eqlGGMFbVJnvDtzveODlyQwHsCDK eqlGGMFbVJnvDtzveODlyQwHsCDK2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							eqlGGMFbVJnvDtzveODlyQwHsCDK2 = this;
						}
						else
						{
							eqlGGMFbVJnvDtzveODlyQwHsCDK2 = new eqlGGMFbVJnvDtzveODlyQwHsCDK(0);
							eqlGGMFbVJnvDtzveODlyQwHsCDK2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						eqlGGMFbVJnvDtzveODlyQwHsCDK2.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						eqlGGMFbVJnvDtzveODlyQwHsCDK2.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						eqlGGMFbVJnvDtzveODlyQwHsCDK2.FYaAMRGqoDSSWPerFwNcTLQJyYeP = qHziAbvFUwsFWKYqEOolHHfukCxi;
						return eqlGGMFbVJnvDtzveODlyQwHsCDK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class TGLarDMyXKCvXlSKXKzsFhVlMZfT<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<_0001>, IEnumerator<_0001> where _0001 : ControllerMap
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private _0001 USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private int FYaAMRGqoDSSWPerFwNcTLQJyYeP;

					public int qHziAbvFUwsFWKYqEOolHHfukCxi;

					private IList<_0001> TGIBJpiYBDdIZLuxcgKiqMfbSUMDb;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public TGLarDMyXKCvXlSKXKzsFhVlMZfT(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return false;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_00b9;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						ControllerType controllerType = DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<_0001>();
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(ewwLiKFmCKbnVFhcViVbHODDzYHW);
						if (num < 0)
						{
							return false;
						}
						TGIBJpiYBDdIZLuxcgKiqMfbSUMDb = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU<_0001>();
						eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
						goto IL_00cb;
						IL_00cb:
						if (eolRghqutZOOIGqvOFTzJOGfYTsn < TGIBJpiYBDdIZLuxcgKiqMfbSUMDb.Count)
						{
							if (TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn].categoryId == FYaAMRGqoDSSWPerFwNcTLQJyYeP)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = TGIBJpiYBDdIZLuxcgKiqMfbSUMDb[eolRghqutZOOIGqvOFTzJOGfYTsn];
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						eolRghqutZOOIGqvOFTzJOGfYTsn++;
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
						TGLarDMyXKCvXlSKXKzsFhVlMZfT<_0001> tGLarDMyXKCvXlSKXKzsFhVlMZfT;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							tGLarDMyXKCvXlSKXKzsFhVlMZfT = this;
						}
						else
						{
							tGLarDMyXKCvXlSKXKzsFhVlMZfT = new TGLarDMyXKCvXlSKXKzsFhVlMZfT<_0001>(0);
							tGLarDMyXKCvXlSKXKzsFhVlMZfT.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						tGLarDMyXKCvXlSKXKzsFhVlMZfT.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						tGLarDMyXKCvXlSKXKzsFhVlMZfT.FYaAMRGqoDSSWPerFwNcTLQJyYeP = qHziAbvFUwsFWKYqEOolHHfukCxi;
						return tGLarDMyXKCvXlSKXKzsFhVlMZfT;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class XKxKRJQloIBfucPEZcNYLGcfpUYL : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private int xwKWiAPvHlDAuRWHTihmtTQXNyEp;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe VUxdgmAHeNjWtdVKcnoPRwcKLjrHB;

					private int pvKHDqdhKjwKxxMRvhkcvrrdjQmc;

					private int KPzcVBnmZXDxZtyglRXvOitPTlXE;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf zrAheEDsRBptOGaOaooUrJvheremc;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					private IEnumerator<ActionElementMap> MwxNdpIagihdSIFhJiFBDdHBndQcB;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public XKxKRJQloIBfucPEZcNYLGcfpUYL(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_016c;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
							{
								ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
								return false;
							}
							if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
							{
								return false;
							}
							xwKWiAPvHlDAuRWHTihmtTQXNyEp = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_01ec;
							IL_016c:
							if (MwxNdpIagihdSIFhJiFBDdHBndQcB.MoveNext())
							{
								ActionElementMap current = MwxNdpIagihdSIFhJiFBDdHBndQcB.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MwxNdpIagihdSIFhJiFBDdHBndQcB = null;
							goto IL_0186;
							IL_0186:
							NzdxphehSibRzjWKzxPfRniEANPG++;
							goto IL_0198;
							IL_01c2:
							if (KPzcVBnmZXDxZtyglRXvOitPTlXE < pvKHDqdhKjwKxxMRvhkcvrrdjQmc)
							{
								zrAheEDsRBptOGaOaooUrJvheremc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.wBgVECvNnnPzuAKlDGDoAWwKEEhT(KPzcVBnmZXDxZtyglRXvOitPTlXE).TptZzDLPedINfuoxMyhBGLwShqDI;
								JkaoTQsxRcqYFKIdAdYYqerngJbC = zrAheEDsRBptOGaOaooUrJvheremc.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								NzdxphehSibRzjWKzxPfRniEANPG = 0;
								goto IL_0198;
							}
							VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_01ec;
							IL_0198:
							if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
							{
								ControllerMap controllerMap = zrAheEDsRBptOGaOaooUrJvheremc.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG);
								if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMap.enabled) && controllerMap.ContainsAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf))
								{
									MwxNdpIagihdSIFhJiFBDdHBndQcB = controllerMap.ElementMapsWithAction(oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							zrAheEDsRBptOGaOaooUrJvheremc = null;
							KPzcVBnmZXDxZtyglRXvOitPTlXE++;
							goto IL_01c2;
							IL_01ec:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < xwKWiAPvHlDAuRWHTihmtTQXNyEp)
							{
								VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(eolRghqutZOOIGqvOFTzJOGfYTsn);
								pvKHDqdhKjwKxxMRvhkcvrrdjQmc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								KPzcVBnmZXDxZtyglRXvOitPTlXE = 0;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MwxNdpIagihdSIFhJiFBDdHBndQcB != null)
						{
							MwxNdpIagihdSIFhJiFBDdHBndQcB.Dispose();
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
						XKxKRJQloIBfucPEZcNYLGcfpUYL xKxKRJQloIBfucPEZcNYLGcfpUYL;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							xKxKRJQloIBfucPEZcNYLGcfpUYL = this;
						}
						else
						{
							xKxKRJQloIBfucPEZcNYLGcfpUYL = new XKxKRJQloIBfucPEZcNYLGcfpUYL(0);
							xKxKRJQloIBfucPEZcNYLGcfpUYL.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						xKxKRJQloIBfucPEZcNYLGcfpUYL.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						xKxKRJQloIBfucPEZcNYLGcfpUYL.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return xKxKRJQloIBfucPEZcNYLGcfpUYL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class mGyhsuwvXqlBignILjSYEmMDdltLA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IControllerElementTarget rVgBEjIeKffMbzgnTZciiDWgcyTG;

					public IControllerElementTarget HQhUPrZFsWAouBRHfSQZsgJAROS;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool HbNiAsSHfVgoxJMAwnfDFRnWeGvdA;

					public bool miyQcIyerNKBuYEvrsNdyauqcls;

					private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

					public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int ScNPEtvedaARGbEnJdXxKSHaFxsr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IList<ControllerMap> PyMllUcAVPRbifnuWMikWhOmIpmc;

					private int BAOvRnApdEzItNGHIUKbTddAPVEo;

					private int CvEbIJnzztnOHpNEfWcAJTRohMvK;

					private TempListPool.TList<ActionElementMap> EdCjAMJCiLVPKGqNFEzThfbgHOCP;

					private List<ActionElementMap>.Enumerator MyWGbgerVyqBlfimtglTDcoXYmuR;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public mGyhsuwvXqlBignILjSYEmMDdltLA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if ((uint)(gwbUsvLqBorYvZEWvPDttSzVhFNo - -4) > 1u && gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
						{
							return;
						}
						try
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != -4 && gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return;
							}
							try
							{
							}
							finally
							{
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
							}
						}
						finally
						{
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_017c;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (rVgBEjIeKffMbzgnTZciiDWgcyTG == null)
							{
								return false;
							}
							Controller controller = rVgBEjIeKffMbzgnTZciiDWgcyTG.controller;
							if (controller == null)
							{
								return false;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controller.type);
							ScNPEtvedaARGbEnJdXxKSHaFxsr = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_01e4;
							IL_017c:
							if (MyWGbgerVyqBlfimtglTDcoXYmuR.MoveNext())
							{
								ActionElementMap current = MyWGbgerVyqBlfimtglTDcoXYmuR.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							cjHgXFFYGWhdIQKUJynxjVusYouQA();
							MyWGbgerVyqBlfimtglTDcoXYmuR = default(List<ActionElementMap>.Enumerator);
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							EdCjAMJCiLVPKGqNFEzThfbgHOCP = null;
							goto IL_01a8;
							IL_01e4:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < ScNPEtvedaARGbEnJdXxKSHaFxsr)
							{
								GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(AEpFbNhiazpfukEJmuNHcDAbfQLWA).TptZzDLPedINfuoxMyhBGLwShqDI;
								_ = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								PyMllUcAVPRbifnuWMikWhOmIpmc = gNnLMzlpRKtFyJlexoafWNjfiSkf.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
								BAOvRnApdEzItNGHIUKbTddAPVEo = PyMllUcAVPRbifnuWMikWhOmIpmc.Count;
								CvEbIJnzztnOHpNEfWcAJTRohMvK = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (CvEbIJnzztnOHpNEfWcAJTRohMvK < BAOvRnApdEzItNGHIUKbTddAPVEo)
							{
								ControllerMap controllerMap = PyMllUcAVPRbifnuWMikWhOmIpmc[CvEbIJnzztnOHpNEfWcAJTRohMvK];
								if (!SkVfnydpDzxVINVmPxKjrMVDeYYIA || controllerMap.enabled)
								{
									EdCjAMJCiLVPKGqNFEzThfbgHOCP = TempListPool.GetTList<ActionElementMap>();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
									List<ActionElementMap> list = EdCjAMJCiLVPKGqNFEzThfbgHOCP.list;
									controllerMap.DByGazdclNMniEHyXlrfkPzVFmhE(rVgBEjIeKffMbzgnTZciiDWgcyTG, HbNiAsSHfVgoxJMAwnfDFRnWeGvdA, oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA, list, true, out var _);
									MyWGbgerVyqBlfimtglTDcoXYmuR = list.GetEnumerator();
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							PyMllUcAVPRbifnuWMikWhOmIpmc = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_01e4;
							IL_01a8:
							CvEbIJnzztnOHpNEfWcAJTRohMvK++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (EdCjAMJCiLVPKGqNFEzThfbgHOCP != null)
						{
							((IDisposable)EdCjAMJCiLVPKGqNFEzThfbgHOCP).Dispose();
						}
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						((IDisposable)MyWGbgerVyqBlfimtglTDcoXYmuR/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						mGyhsuwvXqlBignILjSYEmMDdltLA mGyhsuwvXqlBignILjSYEmMDdltLA2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							mGyhsuwvXqlBignILjSYEmMDdltLA2 = this;
						}
						else
						{
							mGyhsuwvXqlBignILjSYEmMDdltLA2 = new mGyhsuwvXqlBignILjSYEmMDdltLA(0);
							mGyhsuwvXqlBignILjSYEmMDdltLA2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						mGyhsuwvXqlBignILjSYEmMDdltLA2.rVgBEjIeKffMbzgnTZciiDWgcyTG = HQhUPrZFsWAouBRHfSQZsgJAROS;
						mGyhsuwvXqlBignILjSYEmMDdltLA2.HbNiAsSHfVgoxJMAwnfDFRnWeGvdA = miyQcIyerNKBuYEvrsNdyauqcls;
						mGyhsuwvXqlBignILjSYEmMDdltLA2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
						mGyhsuwvXqlBignILjSYEmMDdltLA2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						return mGyhsuwvXqlBignILjSYEmMDdltLA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class rlTijqFCKUecYdnsLrjCALMgaJTBb : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int xwKWiAPvHlDAuRWHTihmtTQXNyEp;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe VUxdgmAHeNjWtdVKcnoPRwcKLjrHB;

					private int pvKHDqdhKjwKxxMRvhkcvrrdjQmc;

					private int KPzcVBnmZXDxZtyglRXvOitPTlXE;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf zrAheEDsRBptOGaOaooUrJvheremc;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public rlTijqFCKUecYdnsLrjCALMgaJTBb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return false;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							NzdxphehSibRzjWKzxPfRniEANPG++;
							goto IL_0104;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						xwKWiAPvHlDAuRWHTihmtTQXNyEp = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
						goto IL_0151;
						IL_0104:
						if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = zrAheEDsRBptOGaOaooUrJvheremc.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG);
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						zrAheEDsRBptOGaOaooUrJvheremc = null;
						KPzcVBnmZXDxZtyglRXvOitPTlXE++;
						goto IL_0129;
						IL_0129:
						if (KPzcVBnmZXDxZtyglRXvOitPTlXE < pvKHDqdhKjwKxxMRvhkcvrrdjQmc)
						{
							zrAheEDsRBptOGaOaooUrJvheremc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.wBgVECvNnnPzuAKlDGDoAWwKEEhT(KPzcVBnmZXDxZtyglRXvOitPTlXE).TptZzDLPedINfuoxMyhBGLwShqDI;
							JkaoTQsxRcqYFKIdAdYYqerngJbC = zrAheEDsRBptOGaOaooUrJvheremc.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							NzdxphehSibRzjWKzxPfRniEANPG = 0;
							goto IL_0104;
						}
						VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = null;
						eolRghqutZOOIGqvOFTzJOGfYTsn++;
						goto IL_0151;
						IL_0151:
						if (eolRghqutZOOIGqvOFTzJOGfYTsn < xwKWiAPvHlDAuRWHTihmtTQXNyEp)
						{
							VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(eolRghqutZOOIGqvOFTzJOGfYTsn);
							pvKHDqdhKjwKxxMRvhkcvrrdjQmc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							KPzcVBnmZXDxZtyglRXvOitPTlXE = 0;
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
						rlTijqFCKUecYdnsLrjCALMgaJTBb rlTijqFCKUecYdnsLrjCALMgaJTBb2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							rlTijqFCKUecYdnsLrjCALMgaJTBb2 = this;
						}
						else
						{
							rlTijqFCKUecYdnsLrjCALMgaJTBb2 = new rlTijqFCKUecYdnsLrjCALMgaJTBb(0);
							rlTijqFCKUecYdnsLrjCALMgaJTBb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return rlTijqFCKUecYdnsLrjCALMgaJTBb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class krIBaNFaKJevbiOQOwZfHoeyqoOHb<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<_0001>, IEnumerator<_0001> where _0001 : ControllerMap
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private _0001 USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int yeqqmTJBkMQNqIFPRMJpXpRTmeSv;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf ylotEwFLZtkYulYcOjkttCvFbkr;

					private int BAOvRnApdEzItNGHIUKbTddAPVEo;

					private int CvEbIJnzztnOHpNEfWcAJTRohMvK;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public krIBaNFaKJevbiOQOwZfHoeyqoOHb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						default:
							return false;
						case 0:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
							{
								ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
								return false;
							}
							if (DXYiJElpUHxcPboaihvPaElwMWxMA.wYgUMQshagKpNAshunamdyfpQdkl<_0001>(out var controllerType))
							{
								ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
								yeqqmTJBkMQNqIFPRMJpXpRTmeSv = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
								goto IL_011b;
							}
							yeqqmTJBkMQNqIFPRMJpXpRTmeSv = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_0264;
						}
						case 1:
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							CvEbIJnzztnOHpNEfWcAJTRohMvK++;
							goto IL_00f6;
						case 2:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								goto IL_0207;
							}
							IL_0207:
							NzdxphehSibRzjWKzxPfRniEANPG++;
							goto IL_0217;
							IL_0264:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA >= yeqqmTJBkMQNqIFPRMJpXpRTmeSv)
							{
								break;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(AEpFbNhiazpfukEJmuNHcDAbfQLWA);
							BAOvRnApdEzItNGHIUKbTddAPVEo = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							CvEbIJnzztnOHpNEfWcAJTRohMvK = 0;
							goto IL_023c;
							IL_011b:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < yeqqmTJBkMQNqIFPRMJpXpRTmeSv)
							{
								ylotEwFLZtkYulYcOjkttCvFbkr = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(AEpFbNhiazpfukEJmuNHcDAbfQLWA).TptZzDLPedINfuoxMyhBGLwShqDI;
								BAOvRnApdEzItNGHIUKbTddAPVEo = ylotEwFLZtkYulYcOjkttCvFbkr.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								CvEbIJnzztnOHpNEfWcAJTRohMvK = 0;
								goto IL_00f6;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = null;
							break;
							IL_0217:
							if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
							{
								if (ylotEwFLZtkYulYcOjkttCvFbkr.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG) is _0001 uSjDTWbJtWhEBdYYYfLUglTcnnGrA)
								{
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								goto IL_0207;
							}
							ylotEwFLZtkYulYcOjkttCvFbkr = null;
							CvEbIJnzztnOHpNEfWcAJTRohMvK++;
							goto IL_023c;
							IL_023c:
							if (CvEbIJnzztnOHpNEfWcAJTRohMvK < BAOvRnApdEzItNGHIUKbTddAPVEo)
							{
								ylotEwFLZtkYulYcOjkttCvFbkr = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(CvEbIJnzztnOHpNEfWcAJTRohMvK).TptZzDLPedINfuoxMyhBGLwShqDI;
								JkaoTQsxRcqYFKIdAdYYqerngJbC = ylotEwFLZtkYulYcOjkttCvFbkr.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								NzdxphehSibRzjWKzxPfRniEANPG = 0;
								goto IL_0217;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_0264;
							IL_00f6:
							if (CvEbIJnzztnOHpNEfWcAJTRohMvK < BAOvRnApdEzItNGHIUKbTddAPVEo)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = (_0001)ylotEwFLZtkYulYcOjkttCvFbkr.wBgVECvNnnPzuAKlDGDoAWwKEEhT(CvEbIJnzztnOHpNEfWcAJTRohMvK);
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							ylotEwFLZtkYulYcOjkttCvFbkr = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
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
						krIBaNFaKJevbiOQOwZfHoeyqoOHb<_0001> krIBaNFaKJevbiOQOwZfHoeyqoOHb2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							krIBaNFaKJevbiOQOwZfHoeyqoOHb2 = this;
						}
						else
						{
							krIBaNFaKJevbiOQOwZfHoeyqoOHb2 = new krIBaNFaKJevbiOQOwZfHoeyqoOHb<_0001>(0);
							krIBaNFaKJevbiOQOwZfHoeyqoOHb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return krIBaNFaKJevbiOQOwZfHoeyqoOHb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class WzAcmKffGHQClQfCAQRtzThPHPlHb : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int ynNBoCIVPdNeRGtCvUtczSglIwhaA;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf ylotEwFLZtkYulYcOjkttCvFbkr;

					private int BAOvRnApdEzItNGHIUKbTddAPVEo;

					private int CvEbIJnzztnOHpNEfWcAJTRohMvK;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public WzAcmKffGHQClQfCAQRtzThPHPlHb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return false;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							CvEbIJnzztnOHpNEfWcAJTRohMvK++;
							goto IL_00e2;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
						ynNBoCIVPdNeRGtCvUtczSglIwhaA = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
						goto IL_0107;
						IL_00e2:
						if (CvEbIJnzztnOHpNEfWcAJTRohMvK < BAOvRnApdEzItNGHIUKbTddAPVEo)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = ylotEwFLZtkYulYcOjkttCvFbkr.wBgVECvNnnPzuAKlDGDoAWwKEEhT(CvEbIJnzztnOHpNEfWcAJTRohMvK);
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						ylotEwFLZtkYulYcOjkttCvFbkr = null;
						AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
						goto IL_0107;
						IL_0107:
						if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < ynNBoCIVPdNeRGtCvUtczSglIwhaA)
						{
							ylotEwFLZtkYulYcOjkttCvFbkr = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(AEpFbNhiazpfukEJmuNHcDAbfQLWA).TptZzDLPedINfuoxMyhBGLwShqDI;
							BAOvRnApdEzItNGHIUKbTddAPVEo = ylotEwFLZtkYulYcOjkttCvFbkr.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							CvEbIJnzztnOHpNEfWcAJTRohMvK = 0;
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
						WzAcmKffGHQClQfCAQRtzThPHPlHb wzAcmKffGHQClQfCAQRtzThPHPlHb;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							wzAcmKffGHQClQfCAQRtzThPHPlHb = this;
						}
						else
						{
							wzAcmKffGHQClQfCAQRtzThPHPlHb = new WzAcmKffGHQClQfCAQRtzThPHPlHb(0);
							wzAcmKffGHQClQfCAQRtzThPHPlHb.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						wzAcmKffGHQClQfCAQRtzThPHPlHb.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						return wzAcmKffGHQClQfCAQRtzThPHPlHb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class ZKbbQuMahYOyStINJjWvFTvMlDBi : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int FYaAMRGqoDSSWPerFwNcTLQJyYeP;

					public int qHziAbvFUwsFWKYqEOolHHfukCxi;

					private int xwKWiAPvHlDAuRWHTihmtTQXNyEp;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe VUxdgmAHeNjWtdVKcnoPRwcKLjrHB;

					private int pvKHDqdhKjwKxxMRvhkcvrrdjQmc;

					private int KPzcVBnmZXDxZtyglRXvOitPTlXE;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf zrAheEDsRBptOGaOaooUrJvheremc;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ZKbbQuMahYOyStINJjWvFTvMlDBi(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return false;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_0104;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						xwKWiAPvHlDAuRWHTihmtTQXNyEp = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
						goto IL_0161;
						IL_0104:
						NzdxphehSibRzjWKzxPfRniEANPG++;
						goto IL_0114;
						IL_0161:
						if (eolRghqutZOOIGqvOFTzJOGfYTsn < xwKWiAPvHlDAuRWHTihmtTQXNyEp)
						{
							VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(eolRghqutZOOIGqvOFTzJOGfYTsn);
							pvKHDqdhKjwKxxMRvhkcvrrdjQmc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							KPzcVBnmZXDxZtyglRXvOitPTlXE = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
						{
							ControllerMap controllerMap = zrAheEDsRBptOGaOaooUrJvheremc.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG);
							if (controllerMap.categoryId == FYaAMRGqoDSSWPerFwNcTLQJyYeP)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = controllerMap;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							goto IL_0104;
						}
						zrAheEDsRBptOGaOaooUrJvheremc = null;
						KPzcVBnmZXDxZtyglRXvOitPTlXE++;
						goto IL_0139;
						IL_0139:
						if (KPzcVBnmZXDxZtyglRXvOitPTlXE < pvKHDqdhKjwKxxMRvhkcvrrdjQmc)
						{
							zrAheEDsRBptOGaOaooUrJvheremc = VUxdgmAHeNjWtdVKcnoPRwcKLjrHB.wBgVECvNnnPzuAKlDGDoAWwKEEhT(KPzcVBnmZXDxZtyglRXvOitPTlXE).TptZzDLPedINfuoxMyhBGLwShqDI;
							JkaoTQsxRcqYFKIdAdYYqerngJbC = zrAheEDsRBptOGaOaooUrJvheremc.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							NzdxphehSibRzjWKzxPfRniEANPG = 0;
							goto IL_0114;
						}
						VUxdgmAHeNjWtdVKcnoPRwcKLjrHB = null;
						eolRghqutZOOIGqvOFTzJOGfYTsn++;
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
						ZKbbQuMahYOyStINJjWvFTvMlDBi zKbbQuMahYOyStINJjWvFTvMlDBi;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							zKbbQuMahYOyStINJjWvFTvMlDBi = this;
						}
						else
						{
							zKbbQuMahYOyStINJjWvFTvMlDBi = new ZKbbQuMahYOyStINJjWvFTvMlDBi(0);
							zKbbQuMahYOyStINJjWvFTvMlDBi.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						zKbbQuMahYOyStINJjWvFTvMlDBi.FYaAMRGqoDSSWPerFwNcTLQJyYeP = qHziAbvFUwsFWKYqEOolHHfukCxi;
						return zKbbQuMahYOyStINJjWvFTvMlDBi;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class LeCgkfYycoeyEKigIPFbCQQfUTQM<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<_0001>, IEnumerator<_0001> where _0001 : ControllerMap
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private _0001 USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int FYaAMRGqoDSSWPerFwNcTLQJyYeP;

					public int qHziAbvFUwsFWKYqEOolHHfukCxi;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe ewCgwqhaUCqLmCxGkEjUAlhkAwBe;

					private int yeqqmTJBkMQNqIFPRMJpXpRTmeSv;

					private int kUSSjtstCFlXUbOTBzdjRFSFpbgB;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf ylotEwFLZtkYulYcOjkttCvFbkr;

					private int BAOvRnApdEzItNGHIUKbTddAPVEo;

					private int TTGTDDJbfewxjMKcCGoWANfSgZIT;

					private int JkaoTQsxRcqYFKIdAdYYqerngJbC;

					private int NzdxphehSibRzjWKzxPfRniEANPG;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public LeCgkfYycoeyEKigIPFbCQQfUTQM(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						default:
							return false;
						case 0:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
							{
								ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
								return false;
							}
							if (DXYiJElpUHxcPboaihvPaElwMWxMA.wYgUMQshagKpNAshunamdyfpQdkl<_0001>(out var _))
							{
								ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.LlWQkHhlCXfbDQPxkkJhDCIMKJyN<_0001>();
								yeqqmTJBkMQNqIFPRMJpXpRTmeSv = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								kUSSjtstCFlXUbOTBzdjRFSFpbgB = 0;
								goto IL_0124;
							}
							yeqqmTJBkMQNqIFPRMJpXpRTmeSv = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							kUSSjtstCFlXUbOTBzdjRFSFpbgB = 0;
							goto IL_0287;
						}
						case 1:
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_00eb;
						case 2:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								goto IL_0224;
							}
							IL_0224:
							NzdxphehSibRzjWKzxPfRniEANPG++;
							goto IL_0236;
							IL_00eb:
							TTGTDDJbfewxjMKcCGoWANfSgZIT++;
							goto IL_00fd;
							IL_0124:
							if (kUSSjtstCFlXUbOTBzdjRFSFpbgB < yeqqmTJBkMQNqIFPRMJpXpRTmeSv)
							{
								ylotEwFLZtkYulYcOjkttCvFbkr = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(kUSSjtstCFlXUbOTBzdjRFSFpbgB).TptZzDLPedINfuoxMyhBGLwShqDI;
								BAOvRnApdEzItNGHIUKbTddAPVEo = ylotEwFLZtkYulYcOjkttCvFbkr.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								TTGTDDJbfewxjMKcCGoWANfSgZIT = 0;
								goto IL_00fd;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = null;
							break;
							IL_0287:
							if (kUSSjtstCFlXUbOTBzdjRFSFpbgB >= yeqqmTJBkMQNqIFPRMJpXpRTmeSv)
							{
								break;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(kUSSjtstCFlXUbOTBzdjRFSFpbgB);
							BAOvRnApdEzItNGHIUKbTddAPVEo = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							TTGTDDJbfewxjMKcCGoWANfSgZIT = 0;
							goto IL_025d;
							IL_0236:
							if (NzdxphehSibRzjWKzxPfRniEANPG < JkaoTQsxRcqYFKIdAdYYqerngJbC)
							{
								if (ylotEwFLZtkYulYcOjkttCvFbkr.wBgVECvNnnPzuAKlDGDoAWwKEEhT(NzdxphehSibRzjWKzxPfRniEANPG) is _0001 val && val.categoryId == FYaAMRGqoDSSWPerFwNcTLQJyYeP)
								{
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = val;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								goto IL_0224;
							}
							ylotEwFLZtkYulYcOjkttCvFbkr = null;
							TTGTDDJbfewxjMKcCGoWANfSgZIT++;
							goto IL_025d;
							IL_00fd:
							if (TTGTDDJbfewxjMKcCGoWANfSgZIT < BAOvRnApdEzItNGHIUKbTddAPVEo)
							{
								ControllerMap controllerMap = ylotEwFLZtkYulYcOjkttCvFbkr.wBgVECvNnnPzuAKlDGDoAWwKEEhT(TTGTDDJbfewxjMKcCGoWANfSgZIT);
								if (controllerMap.categoryId == FYaAMRGqoDSSWPerFwNcTLQJyYeP)
								{
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = (_0001)controllerMap;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
									return true;
								}
								goto IL_00eb;
							}
							ylotEwFLZtkYulYcOjkttCvFbkr = null;
							kUSSjtstCFlXUbOTBzdjRFSFpbgB++;
							goto IL_0124;
							IL_025d:
							if (TTGTDDJbfewxjMKcCGoWANfSgZIT < BAOvRnApdEzItNGHIUKbTddAPVEo)
							{
								ylotEwFLZtkYulYcOjkttCvFbkr = ewCgwqhaUCqLmCxGkEjUAlhkAwBe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(TTGTDDJbfewxjMKcCGoWANfSgZIT).TptZzDLPedINfuoxMyhBGLwShqDI;
								JkaoTQsxRcqYFKIdAdYYqerngJbC = ylotEwFLZtkYulYcOjkttCvFbkr.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
								NzdxphehSibRzjWKzxPfRniEANPG = 0;
								goto IL_0236;
							}
							ewCgwqhaUCqLmCxGkEjUAlhkAwBe = null;
							kUSSjtstCFlXUbOTBzdjRFSFpbgB++;
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
						LeCgkfYycoeyEKigIPFbCQQfUTQM<_0001> leCgkfYycoeyEKigIPFbCQQfUTQM;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							leCgkfYycoeyEKigIPFbCQQfUTQM = this;
						}
						else
						{
							leCgkfYycoeyEKigIPFbCQQfUTQM = new LeCgkfYycoeyEKigIPFbCQQfUTQM<_0001>(0);
							leCgkfYycoeyEKigIPFbCQQfUTQM.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						leCgkfYycoeyEKigIPFbCQQfUTQM.FYaAMRGqoDSSWPerFwNcTLQJyYeP = qHziAbvFUwsFWKYqEOolHHfukCxi;
						return leCgkfYycoeyEKigIPFbCQQfUTQM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class vvZrFgSFLOVAzYtNpAwVqeWKqPOf : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public MapHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs;

					public ControllerType zMVppMXkpFDJplkUbOPXtnZQmeFP;

					private int FYaAMRGqoDSSWPerFwNcTLQJyYeP;

					public int qHziAbvFUwsFWKYqEOolHHfukCxi;

					private SXCOzPpaBVgCpGDHSTAYSkvnQSpe pKyBvEiYRiGqnvQxTYXJwaRQgHgb;

					private int ScNPEtvedaARGbEnJdXxKSHaFxsr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private GNnLMzlpRKtFyJlexoafWNjfiSkf ylotEwFLZtkYulYcOjkttCvFbkr;

					private int BAOvRnApdEzItNGHIUKbTddAPVEo;

					private int CvEbIJnzztnOHpNEfWcAJTRohMvK;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public vvZrFgSFLOVAzYtNpAwVqeWKqPOf(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						MapHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
						{
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
							{
								return false;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_00e2;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						pKyBvEiYRiGqnvQxTYXJwaRQgHgb = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(qwgjCbRzxrpcbcpGuDjyBQzIUaDs);
						ScNPEtvedaARGbEnJdXxKSHaFxsr = pKyBvEiYRiGqnvQxTYXJwaRQgHgb.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
						goto IL_0117;
						IL_00f2:
						if (CvEbIJnzztnOHpNEfWcAJTRohMvK < BAOvRnApdEzItNGHIUKbTddAPVEo)
						{
							ControllerMap controllerMap = ylotEwFLZtkYulYcOjkttCvFbkr.wBgVECvNnnPzuAKlDGDoAWwKEEhT(CvEbIJnzztnOHpNEfWcAJTRohMvK);
							if (controllerMap.categoryId == FYaAMRGqoDSSWPerFwNcTLQJyYeP)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = controllerMap;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							goto IL_00e2;
						}
						ylotEwFLZtkYulYcOjkttCvFbkr = null;
						AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
						goto IL_0117;
						IL_00e2:
						CvEbIJnzztnOHpNEfWcAJTRohMvK++;
						goto IL_00f2;
						IL_0117:
						if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < ScNPEtvedaARGbEnJdXxKSHaFxsr)
						{
							ylotEwFLZtkYulYcOjkttCvFbkr = pKyBvEiYRiGqnvQxTYXJwaRQgHgb.wBgVECvNnnPzuAKlDGDoAWwKEEhT(AEpFbNhiazpfukEJmuNHcDAbfQLWA).TptZzDLPedINfuoxMyhBGLwShqDI;
							BAOvRnApdEzItNGHIUKbTddAPVEo = ylotEwFLZtkYulYcOjkttCvFbkr.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							CvEbIJnzztnOHpNEfWcAJTRohMvK = 0;
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
						vvZrFgSFLOVAzYtNpAwVqeWKqPOf vvZrFgSFLOVAzYtNpAwVqeWKqPOf2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							vvZrFgSFLOVAzYtNpAwVqeWKqPOf2 = this;
						}
						else
						{
							vvZrFgSFLOVAzYtNpAwVqeWKqPOf2 = new vvZrFgSFLOVAzYtNpAwVqeWKqPOf(0);
							vvZrFgSFLOVAzYtNpAwVqeWKqPOf2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						vvZrFgSFLOVAzYtNpAwVqeWKqPOf2.FYaAMRGqoDSSWPerFwNcTLQJyYeP = qHziAbvFUwsFWKYqEOolHHfukCxi;
						vvZrFgSFLOVAzYtNpAwVqeWKqPOf2.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = zMVppMXkpFDJplkUbOPXtnZQmeFP;
						return vvZrFgSFLOVAzYtNpAwVqeWKqPOf2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly rTFRhglKgUYuRjbuHfpVdAGUmulr SzAlkHRsFmmywikNMZAOfymAFHAD;

				private Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm;

				private ControllerHelper eHuiQIUmbPfDCAmSwYoMRKeanDnjb;

				private readonly ControllerMapEnabler CeLyYqqZReJizLqQuGLxwidXwcXg;

				private readonly ControllerMapLayoutManager wWMsshRHwHGtHoprxgvGUbnfyaIt;

				private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

				public ControllerMapLayoutManager layoutManager => wWMsshRHwHGtHoprxgvGUbnfyaIt;

				public ControllerMapEnabler mapEnabler => CeLyYqqZReJizLqQuGLxwidXwcXg;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.gqUiUBMjacceXtcqdHhhSMgwWdoB(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, rTFRhglKgUYuRjbuHfpVdAGUmulr P_2, ControllerMapLayoutManager.nwmaXXBRLHdsFSHrcaeHCCJdihJCc P_3, ControllerMapEnabler.bfKxbNaTbdokMFkgReyogCBTNRVl P_4)
				{
					TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
					EVSYfBRoRmlZGWzbtVEKHpHdIHIm = P_0;
					eHuiQIUmbPfDCAmSwYoMRKeanDnjb = P_1;
					SzAlkHRsFmmywikNMZAOfymAFHAD = P_2;
					CeLyYqqZReJizLqQuGLxwidXwcXg = new ControllerMapEnabler(P_0, P_4);
					wWMsshRHwHGtHoprxgvGUbnfyaIt = new ControllerMapLayoutManager(P_0, P_3);
					wWMsshRHwHGtHoprxgvGUbnfyaIt.JqrISrmXfbadXiBbijoAhvOtGFrGb += CeLyYqqZReJizLqQuGLxwidXwcXg.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					XnXdRlcKehhdgeJcSnrxcKaPuiiDb(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void XnXdRlcKehhdgeJcSnrxcKaPuiiDb<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						MlDbDbkRprNUJISQRLOKlPwUXJAH(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void XnXdRlcKehhdgeJcSnrxcKaPuiiDb<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						MlDbDbkRprNUJISQRLOKlPwUXJAH(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void XnXdRlcKehhdgeJcSnrxcKaPuiiDb(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void XnXdRlcKehhdgeJcSnrxcKaPuiiDb(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, P_2, P_3, P_4);
					}
				}

				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new rlTijqFCKUecYdnsLrjCALMgaJTBb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num; j++)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU(results, true);
						}
					}
					return results.Count;
				}

				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new krIBaNFaKJevbiOQOwZfHoeyqoOHb<T>(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (DXYiJElpUHxcPboaihvPaElwMWxMA.wYgUMQshagKpNAshunamdyfpQdkl<T>(out var controllerType))
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int i = 0; i < num; i++)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU(results, true);
						}
					}
					else
					{
						int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; j++)
						{
							SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe2 = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(j);
							int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe2.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							for (int k = 0; k < num2; k++)
							{
								sXCOzPpaBVgCpGDHSTAYSkvnQSpe2.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k).TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU(results, true);
							}
						}
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new WzAcmKffGHQClQfCAQRtzThPHPlHb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num; i++)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new ZKbbQuMahYOyStINJjWvFTvMlDBi(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						qHziAbvFUwsFWKYqEOolHHfukCxi = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new LeCgkfYycoeyEKigIPFbCQQfUTQM<T>(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						qHziAbvFUwsFWKYqEOolHHfukCxi = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new vvZrFgSFLOVAzYtNpAwVqeWKqPOf(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						qHziAbvFUwsFWKYqEOolHHfukCxi = categoryId,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num; j++)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (DXYiJElpUHxcPboaihvPaElwMWxMA.wYgUMQshagKpNAshunamdyfpQdkl<T>(out var controllerType))
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int i = 0; i < num; i++)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(categoryId, results, true);
						}
					}
					else
					{
						int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; j++)
						{
							SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe2 = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(j);
							int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe2.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							for (int k = 0; k < num2; k++)
							{
								sXCOzPpaBVgCpGDHSTAYSkvnQSpe2.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k).TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num; i++)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return UMNYBBsOhxiEsRLZMLsvhXZrCzDj<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return UMNYBBsOhxiEsRLZMLsvhXZrCzDj(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					return kwqQdIGyMZGEpYAtHOJzxyBAEjpb(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType).USCGiuQyHUkFhIyPnQnjKGLOTfzD(controllerId)?.TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return kwqQdIGyMZGEpYAtHOJzxyBAEjpb<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					DsaFviOLajAIGcAxmEeEgGjWfzgd dsaFviOLajAIGcAxmEeEgGjWfzgd = LlWQkHhlCXfbDQPxkkJhDCIMKJyN<T>().USCGiuQyHUkFhIyPnQnjKGLOTfzD(controllerId);
					if (dsaFviOLajAIGcAxmEeEgGjWfzgd == null)
					{
						return 0;
					}
					dsaFviOLajAIGcAxmEeEgGjWfzgd.TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)PvGGEvixOPRrFPKHxiEcAbVbCEDAA(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)PvGGEvixOPRrFPKHxiEcAbVbCEDAA(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (T)PvGGEvixOPRrFPKHxiEcAbVbCEDAA(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.uQYBazlQkgnkWSHYtTMdrfuXbodA(mapId);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)GMtbuOOPLUFtLDbWOBhQyqzcuFEF(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return GMtbuOOPLUFtLDbWOBhQyqzcuFEF(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						TppstQSeaHljWBzRORrvelHZpBaH(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						TppstQSeaHljWBzRORrvelHZpBaH(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						TppstQSeaHljWBzRORrvelHZpBaH(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						TppstQSeaHljWBzRORrvelHZpBaH(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						TppstQSeaHljWBzRORrvelHZpBaH(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						TppstQSeaHljWBzRORrvelHZpBaH(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return EcAoSIOGzOLvCLIpjJTPClCqFOgGA(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return EcAoSIOGzOLvCLIpjJTPClCqFOgGA(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return TlczZHkMUKtccsFuTkUbVXOUYUJE(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return TlczZHkMUKtccsFuTkUbVXOUYUJE(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						wYYJYjJiguVwFeXpkAixnekgXsgD(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						wYYJYjJiguVwFeXpkAixnekgXsgD(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						wYYJYjJiguVwFeXpkAixnekgXsgD(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else if (mapId >= 0)
					{
						CfRxsfJxryBfBvMGROXFflMgEAgX(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						CfRxsfJxryBfBvMGROXFflMgEAgX(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						CfRxsfJxryBfBvMGROXFflMgEAgX(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else if (mapId >= 0)
					{
						CfRxsfJxryBfBvMGROXFflMgEAgX(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						CfRxsfJxryBfBvMGROXFflMgEAgX(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						CfRxsfJxryBfBvMGROXFflMgEAgX(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMaps(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMapsInCategory(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMapsInCategory(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i));
						for (int j = 0; j < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; j++)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
						for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.hZGQqfkCleotngNoRVwWiwgaxpqJ(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMapsInLayout(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.MhFfHQJfswgLoAKuIqLhegBcfMdrA(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMapsForController(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMapsForController(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(controllerId);
					if (num >= 0)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(controllerId);
					if (num >= 0)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						ClearMapsForControllerInLayout(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(controllerId);
					if (num >= 0)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.MhFfHQJfswgLoAKuIqLhegBcfMdrA(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ClearMaps(eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i), userAssignableOnly);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return TxgGkivsqDryhXPtIRVaXwKnnZPb(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return TxgGkivsqDryhXPtIRVaXwKnnZPb(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ActionElementMap actionElementMap = TxgGkivsqDryhXPtIRVaXwKnnZPb(eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return bcyTonfFSpgfGDMmRwwqiVDsItbQA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return bcyTonfFSpgfGDMmRwwqiVDsItbQA(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new bxbekWJPVzTNlROpPIjWWfEeIaWJ(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					return vMhhEsupVSeWoEmsrktUBeeepPjwA(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return vMhhEsupVSeWoEmsrktUBeeepPjwA(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return IAFaiPDVSznVecIdjDdpGufUQUZb(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return TEiMjvivGCRlGtaAWhNdBExTsstN(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return TEiMjvivGCRlGtaAWhNdBExTsstN(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ActionElementMap actionElementMap = TEiMjvivGCRlGtaAWhNdBExTsstN(eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return mOBiFFEMDyVgDBJSrccabPQUuiCg(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return mOBiFFEMDyVgDBJSrccabPQUuiCg(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new kMVyJQiWjzaAbRhbJEgZmTPcFsqq(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return AzVSaHhpGdlIUAxEwBowRPkChzr(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return AzVSaHhpGdlIUAxEwBowRPkChzr(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return AInCQcdygmFlEHaSEZaUCkYWhGekc(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ActionElementMap actionElementMap = XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return crWOQZIWbDAhnRdUFPTKddSYazFe(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return crWOQZIWbDAhnRdUFPTKddSYazFe(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new XKxKRJQloIBfucPEZcNYLGcfpUYL(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return MxxSPMuZpDpLYPCHFNVeSQGZKUYt(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return MxxSPMuZpDpLYPCHFNVeSQGZKUYt(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return zwdxASlITbuZpVbhYqYmCmlNvatv(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, skipDisabledMaps);
					xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return elCkhYpANChLaaQLuyMfQmZgFLYPA(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, actionId, skipDisabledMaps);
					xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return elCkhYpANChLaaQLuyMfQmZgFLYPA(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, skipDisabledMaps);
					xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return XVBIGuwjdUxtMPnVgYILXbpHJhcM(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, actionId, skipDisabledMaps);
					xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return XVBIGuwjdUxtMPnVgYILXbpHJhcM(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, skipDisabledMaps, results);
					xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return DByGazdclNMniEHyXlrfkPzVFmhE(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, actionId, skipDisabledMaps, results);
					xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return DByGazdclNMniEHyXlrfkPzVFmhE(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<T>.array;
					}
					return emtuMhLJGInsddCYXfnphdoHVFBK<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return emtuMhLJGInsddCYXfnphdoHVFBK(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<T>.array;
					}
					return eFngKnGUAKRMCBwmxgtadjBjeWmtA<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return eFngKnGUAKRMCBwmxgtadjBjeWmtA(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ArrayTools.Combine(ref array, eFngKnGUAKRMCBwmxgtadjBjeWmtA(eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int num = 0;
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num2; j++)
						{
							num += sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.HbzjtdgEBLcCNdnZwTdoIUxQxhhs(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int num = 0;
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num2; i++)
					{
						num += sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.HbzjtdgEBLcCNdnZwTdoIUxQxhhs(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType).USCGiuQyHUkFhIyPnQnjKGLOTfzD(controllerId)?.TptZzDLPedINfuoxMyhBGLwShqDI.HbzjtdgEBLcCNdnZwTdoIUxQxhhs(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num2; j++)
						{
							num += sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.UzlqMeTirfouITPkuRdrViGHexfk(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ControllerType controllerType = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.LeEsMlgZmXpMgkJaNUVyZJfYGbYB(i);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num2; i++)
					{
						num += sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.UzlqMeTirfouITPkuRdrViGHexfk(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num2; i++)
					{
						num += sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.UzlqMeTirfouITPkuRdrViGHexfk(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controller.type).USCGiuQyHUkFhIyPnQnjKGLOTfzD(controller.id)?.TptZzDLPedINfuoxMyhBGLwShqDI.UzlqMeTirfouITPkuRdrViGHexfk(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controller.type).USCGiuQyHUkFhIyPnQnjKGLOTfzD(controller.id)?.TptZzDLPedINfuoxMyhBGLwShqDI.UzlqMeTirfouITPkuRdrViGHexfk(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						RWmxhPBAQQRNAMxIRnDCWUoHwkgx(false);
						break;
					case ControllerType.Keyboard:
						bFNXZgUNgqMRHForlQjFsvWmTYtb(false);
						break;
					case ControllerType.Mouse:
						kaIWKFDTncvOVzfylELjBtYAKxzWA(false);
						break;
					case ControllerType.Custom:
						BLWgpfKTwSRTIKfrAjnbIaWBLaTsA(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num; j++)
						{
							if (sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI.pHuElLFczKyOhoMhAZMDtrwwhujdb(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num; i++)
					{
						if (sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.pHuElLFczKyOhoMhAZMDtrwwhujdb(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.fWPoynXPcUbbMgtVneKpoHRjctAr(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.fWPoynXPcUbbMgtVneKpoHRjctAr(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, behaviorName);
				}

				internal void gUxczTgMdKUcYRnCXamteWaCXJodc()
				{
					CeLyYqqZReJizLqQuGLxwidXwcXg.LoadDefaults();
					wWMsshRHwHGtHoprxgvGUbnfyaIt.LoadDefaults();
				}

				internal void RWmxhPBAQQRNAMxIRnDCWUoHwkgx(bool P_0)
				{
					if (SzAlkHRsFmmywikNMZAOfymAFHAD.LlRxoVXhLaCufaqregBgRIXLYVTV == null)
					{
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick);
					eHuiQIUmbPfDCAmSwYoMRKeanDnjb.boNSEKuFFoQzYuEJbTHAMBvFjgjG.VUZmAykhHLsWLfavrDegXhDpAMeHA();
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num; i++)
					{
						WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF xlqldUOnPwEDWvojhDbBMGKeZXpF = (WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF)sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.uOrObmhYSFFSSYAgXWUdMpLCHkkc();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).enabled;
							}
						}
						xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(false);
						for (int k = 0; k < SzAlkHRsFmmywikNMZAOfymAFHAD.LlRxoVXhLaCufaqregBgRIXLYVTV.Length; k++)
						{
							AOTkYVAkHHEeZBPVEQBFVVaKDnyI(xlqldUOnPwEDWvojhDbBMGKeZXpF.NlFnBAIUQPMwtvacPcDKoOszCbeW, xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI, SzAlkHRsFmmywikNMZAOfymAFHAD.LlRxoVXhLaCufaqregBgRIXLYVTV[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.uOrObmhYSFFSSYAgXWUdMpLCHkkc());
							for (int l = 0; l < num3; l++)
							{
								xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.wBgVECvNnnPzuAKlDGDoAWwKEEhT(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = false;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.Apply();
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void bFNXZgUNgqMRHForlQjFsvWmTYtb(bool P_0)
				{
					if (SzAlkHRsFmmywikNMZAOfymAFHAD.yzDggJDycoAvhEefFThchOmFnyEeA == null)
					{
						return;
					}
					GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Keyboard).USCGiuQyHUkFhIyPnQnjKGLOTfzD(0).TptZzDLPedINfuoxMyhBGLwShqDI;
					bool[] array = null;
					if (!P_0)
					{
						int num = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).enabled;
						}
					}
					gNnLMzlpRKtFyJlexoafWNjfiSkf.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(false);
					for (int j = 0; j < SzAlkHRsFmmywikNMZAOfymAFHAD.yzDggJDycoAvhEefFThchOmFnyEeA.Length; j++)
					{
						fltsBxmjXaFeMfcWglOfHGHvtAQsA fltsBxmjXaFeMfcWglOfHGHvtAQsA2 = SzAlkHRsFmmywikNMZAOfymAFHAD.yzDggJDycoAvhEefFThchOmFnyEeA[j];
						if (fltsBxmjXaFeMfcWglOfHGHvtAQsA2.FYaAMRGqoDSSWPerFwNcTLQJyYeP >= 0 && fltsBxmjXaFeMfcWglOfHGHvtAQsA2.OnYyrXkHonthpTXTrJziQfCINLNQ >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, fltsBxmjXaFeMfcWglOfHGHvtAQsA2.FYaAMRGqoDSSWPerFwNcTLQJyYeP, fltsBxmjXaFeMfcWglOfHGHvtAQsA2.OnYyrXkHonthpTXTrJziQfCINLNQ);
							if (P_0)
							{
								keyboardMap.enabled = fltsBxmjXaFeMfcWglOfHGHvtAQsA2.qrFAJzEnuAtGtkafVRuztFxWFLWaA;
							}
							TppstQSeaHljWBzRORrvelHZpBaH(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ);
						for (int k = 0; k < num2; k++)
						{
							gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = false;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.Apply();
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void kaIWKFDTncvOVzfylELjBtYAKxzWA(bool P_0)
				{
					if (SzAlkHRsFmmywikNMZAOfymAFHAD.gtZixQzArNlcDXKsSAGETjSKdddf == null)
					{
						return;
					}
					GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Mouse).USCGiuQyHUkFhIyPnQnjKGLOTfzD(0).TptZzDLPedINfuoxMyhBGLwShqDI;
					bool[] array = null;
					if (!P_0)
					{
						int num = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).enabled;
						}
					}
					gNnLMzlpRKtFyJlexoafWNjfiSkf.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(false);
					for (int j = 0; j < SzAlkHRsFmmywikNMZAOfymAFHAD.gtZixQzArNlcDXKsSAGETjSKdddf.Length; j++)
					{
						fltsBxmjXaFeMfcWglOfHGHvtAQsA fltsBxmjXaFeMfcWglOfHGHvtAQsA2 = SzAlkHRsFmmywikNMZAOfymAFHAD.gtZixQzArNlcDXKsSAGETjSKdddf[j];
						if (fltsBxmjXaFeMfcWglOfHGHvtAQsA2.FYaAMRGqoDSSWPerFwNcTLQJyYeP >= 0 && fltsBxmjXaFeMfcWglOfHGHvtAQsA2.OnYyrXkHonthpTXTrJziQfCINLNQ >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, fltsBxmjXaFeMfcWglOfHGHvtAQsA2.FYaAMRGqoDSSWPerFwNcTLQJyYeP, fltsBxmjXaFeMfcWglOfHGHvtAQsA2.OnYyrXkHonthpTXTrJziQfCINLNQ);
							if (P_0)
							{
								mouseMap.enabled = fltsBxmjXaFeMfcWglOfHGHvtAQsA2.qrFAJzEnuAtGtkafVRuztFxWFLWaA;
							}
							TppstQSeaHljWBzRORrvelHZpBaH(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ);
						for (int k = 0; k < num2; k++)
						{
							gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = false;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.Apply();
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void BLWgpfKTwSRTIKfrAjnbIaWBLaTsA(bool P_0)
				{
					if (SzAlkHRsFmmywikNMZAOfymAFHAD.kbQUGGuuKcowZNPnkWWWXMiKcRrv == null)
					{
						return;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num; i++)
					{
						WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF xlqldUOnPwEDWvojhDbBMGKeZXpF = (WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF)sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.uOrObmhYSFFSSYAgXWUdMpLCHkkc();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).enabled;
							}
						}
						xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(false);
						for (int k = 0; k < SzAlkHRsFmmywikNMZAOfymAFHAD.kbQUGGuuKcowZNPnkWWWXMiKcRrv.Length; k++)
						{
							MFgSmlrHplebMQVLMqglYoEdZYKh(xlqldUOnPwEDWvojhDbBMGKeZXpF.NlFnBAIUQPMwtvacPcDKoOszCbeW, xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI, SzAlkHRsFmmywikNMZAOfymAFHAD.kbQUGGuuKcowZNPnkWWWXMiKcRrv[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.uOrObmhYSFFSSYAgXWUdMpLCHkkc());
							for (int l = 0; l < num3; l++)
							{
								xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI.wBgVECvNnnPzuAKlDGDoAWwKEEhT(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = false;
					wWMsshRHwHGtHoprxgvGUbnfyaIt.Apply();
					wWMsshRHwHGtHoprxgvGUbnfyaIt.loadFromUserDataStore = loadFromUserDataStore;
				}

				private SXCOzPpaBVgCpGDHSTAYSkvnQSpe LlWQkHhlCXfbDQPxkkJhDCIMKJyN<_0001>() where _0001 : ControllerMap
				{
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(DXYiJElpUHxcPboaihvPaElwMWxMA.ejxglTRdxitZRdZwDnLNMlthRJaP<_0001>());
				}

				internal gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> oAyGefUjvpvpXDYPIMINXrcNwJG(Joystick P_0, bool P_1)
				{
					if (P_0 == null || SzAlkHRsFmmywikNMZAOfymAFHAD.LlRxoVXhLaCufaqregBgRIXLYVTV == null)
					{
						return null;
					}
					gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> gQqXfkghDzUgcWaoRfIdjveCqyDU2 = new gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap>(P_0.id);
					for (int i = 0; i < SzAlkHRsFmmywikNMZAOfymAFHAD.LlRxoVXhLaCufaqregBgRIXLYVTV.Length; i++)
					{
						AOTkYVAkHHEeZBPVEQBFVVaKDnyI(P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU2, SzAlkHRsFmmywikNMZAOfymAFHAD.LlRxoVXhLaCufaqregBgRIXLYVTV[i], P_1);
					}
					if (gQqXfkghDzUgcWaoRfIdjveCqyDU2.uOrObmhYSFFSSYAgXWUdMpLCHkkc() == 0)
					{
						return null;
					}
					return gQqXfkghDzUgcWaoRfIdjveCqyDU2;
				}

				private void AOTkYVAkHHEeZBPVEQBFVVaKDnyI(Joystick P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> P_1, fltsBxmjXaFeMfcWglOfHGHvtAQsA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.FYaAMRGqoDSSWPerFwNcTLQJyYeP >= 0 && P_2.OnYyrXkHonthpTXTrJziQfCINLNQ >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.HetfeQvTGnionvvgSERhKCeYNRCzA(P_0, P_2.FYaAMRGqoDSSWPerFwNcTLQJyYeP, P_2.OnYyrXkHonthpTXTrJziQfCINLNQ);
						cnpecuLKhtzxTyAKhiBbYvieXuGi(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.qrFAJzEnuAtGtkafVRuztFxWFLWaA ? BoolOption.True : BoolOption.False);
						}
						P_1.ObmRPnBAXLGPNSMVFccJbPKCnMoh(joystickMap, boolOption);
					}
				}

				internal gQqXfkghDzUgcWaoRfIdjveCqyDU<CustomControllerMap> zXZqXzVDvNjfAjPKxPibqLSWVHlk(CustomController P_0, bool P_1)
				{
					if (P_0 == null || SzAlkHRsFmmywikNMZAOfymAFHAD.kbQUGGuuKcowZNPnkWWWXMiKcRrv == null)
					{
						return null;
					}
					gQqXfkghDzUgcWaoRfIdjveCqyDU<CustomControllerMap> gQqXfkghDzUgcWaoRfIdjveCqyDU2 = new gQqXfkghDzUgcWaoRfIdjveCqyDU<CustomControllerMap>(P_0.id);
					for (int i = 0; i < SzAlkHRsFmmywikNMZAOfymAFHAD.kbQUGGuuKcowZNPnkWWWXMiKcRrv.Length; i++)
					{
						MFgSmlrHplebMQVLMqglYoEdZYKh(P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU2, SzAlkHRsFmmywikNMZAOfymAFHAD.kbQUGGuuKcowZNPnkWWWXMiKcRrv[i], P_1);
					}
					if (gQqXfkghDzUgcWaoRfIdjveCqyDU2.uOrObmhYSFFSSYAgXWUdMpLCHkkc() == 0)
					{
						return null;
					}
					return gQqXfkghDzUgcWaoRfIdjveCqyDU2;
				}

				private void MFgSmlrHplebMQVLMqglYoEdZYKh(CustomController P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU<CustomControllerMap> P_1, fltsBxmjXaFeMfcWglOfHGHvtAQsA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.FYaAMRGqoDSSWPerFwNcTLQJyYeP >= 0 && P_2.OnYyrXkHonthpTXTrJziQfCINLNQ >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.opgKaKVcPgBILvSltCnRcmUcNLJab(P_2.FYaAMRGqoDSSWPerFwNcTLQJyYeP, P_0.sourceControllerId, P_2.OnYyrXkHonthpTXTrJziQfCINLNQ);
						cnpecuLKhtzxTyAKhiBbYvieXuGi(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.qrFAJzEnuAtGtkafVRuztFxWFLWaA ? BoolOption.True : BoolOption.False);
						}
						P_1.ObmRPnBAXLGPNSMVFccJbPKCnMoh(customControllerMap, boolOption);
					}
				}

				internal void cnpecuLKhtzxTyAKhiBbYvieXuGi(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
						P_0.cnpecuLKhtzxTyAKhiBbYvieXuGi(P_1);
					}
				}

				private IList<_0001> UMNYBBsOhxiEsRLZMLsvhXZrCzDj<_0001>(int P_0) where _0001 : ControllerMap
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = LlWQkHhlCXfbDQPxkkJhDCIMKJyN<_0001>();
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU<_0001>();
				}

				private IList<_0001> UMNYBBsOhxiEsRLZMLsvhXZrCzDj<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return LlWQkHhlCXfbDQPxkkJhDCIMKJyN<_0001>().USCGiuQyHUkFhIyPnQnjKGLOTfzD(P_0)?.TptZzDLPedINfuoxMyhBGLwShqDI.itpbouhXOYOtZjzdgSiMXIyyMwxU<_0001>();
				}

				private IList<ControllerMap> UMNYBBsOhxiEsRLZMLsvhXZrCzDj(ControllerType P_0, int P_1)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
				}

				private IList<ControllerMap> UMNYBBsOhxiEsRLZMLsvhXZrCzDj(Controller P_0)
				{
					return UMNYBBsOhxiEsRLZMLsvhXZrCzDj(P_0.type, P_0.id);
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(Controller P_0, int P_1, int P_2)
				{
					MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, P_2, BoolOption.Default);
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(Controller P_0, string P_1, string P_2)
				{
					MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, P_2, BoolOption.Default);
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num >= 0)
					{
						Controller controller = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW;
						ControllerMap controllerMap = ReInput.UserData.gpidnRqlHkndAPBFkaLBVVnkohYm(controller, P_2, P_3);
						TppstQSeaHljWBzRORrvelHZpBaH(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void MlDbDbkRprNUJISQRLOKlPwUXJAH(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					MlDbDbkRprNUJISQRLOKlPwUXJAH(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void TppstQSeaHljWBzRORrvelHZpBaH(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0.type);
						int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0.id);
						if (num >= 0)
						{
							cnpecuLKhtzxTyAKhiBbYvieXuGi(P_0, P_1);
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.ObmRPnBAXLGPNSMVFccJbPKCnMoh(P_1, P_2);
							CeLyYqqZReJizLqQuGLxwidXwcXg.Apply();
						}
					}
				}

				private void TppstQSeaHljWBzRORrvelHZpBaH(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						TppstQSeaHljWBzRORrvelHZpBaH(controller, P_2, P_3);
					}
				}

				private bool EcAoSIOGzOLvCLIpjJTPClCqFOgGA(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0).oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.goGesjEFofcTayLyzynfoITRPCBk(P_0);
					if (!controllerMap.AKoiGBWTSOgKxCCVfbEbkmuDWlgqA(P_2))
					{
						return false;
					}
					TppstQSeaHljWBzRORrvelHZpBaH(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int gEsrWBjevaqAJLCvrZGllXJhvpTV(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0).oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (EcAoSIOGzOLvCLIpjJTPClCqFOgGA(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool TlczZHkMUKtccsFuTkUbVXOUYUJE(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0).oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.goGesjEFofcTayLyzynfoITRPCBk(P_0);
					if (!controllerMap.WqkzUgQGMPNMmYMhyoCrrrilwIbc(P_2))
					{
						return false;
					}
					TppstQSeaHljWBzRORrvelHZpBaH(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int cGSfHjFsHVWnMfkFcfozagyYKKWib(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0).oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (TlczZHkMUKtccsFuTkUbVXOUYUJE(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void wYYJYjJiguVwFeXpkAixnekgXsgD(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num >= 0)
					{
						Controller controller = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW;
						ControllerMap controllerMap = ControllerMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(controller, P_2, P_3);
						TppstQSeaHljWBzRORrvelHZpBaH(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void wYYJYjJiguVwFeXpkAixnekgXsgD(Controller P_0, int P_1, int P_2)
				{
					wYYJYjJiguVwFeXpkAixnekgXsgD(P_0.type, P_0.id, P_1, P_2);
				}

				private void wYYJYjJiguVwFeXpkAixnekgXsgD(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						wYYJYjJiguVwFeXpkAixnekgXsgD(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void wYYJYjJiguVwFeXpkAixnekgXsgD(Controller P_0, string P_1, string P_2)
				{
					wYYJYjJiguVwFeXpkAixnekgXsgD(P_0.type, P_0.id, P_1, P_2);
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(ControllerType P_0, int P_1, int P_2)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num >= 0)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.YAfLYztzDMkKhMgJEbHWHcoyOYqB(P_2);
					}
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(Controller P_0, int P_1)
				{
					CfRxsfJxryBfBvMGROXFflMgEAgX(P_0.type, P_0.id, P_1);
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num >= 0)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_2);
					}
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(Controller P_0, ControllerMap P_1)
				{
					CfRxsfJxryBfBvMGROXFflMgEAgX(P_0.type, P_0.id, P_1.id);
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num >= 0)
					{
						sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_2, P_3);
					}
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(Controller P_0, int P_1, int P_2)
				{
					CfRxsfJxryBfBvMGROXFflMgEAgX(P_0.type, P_0.id, P_1, P_2);
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.hZGQqfkCleotngNoRVwWiwgaxpqJ(mapCategoryId, layoutId);
						}
					}
				}

				private void CfRxsfJxryBfBvMGROXFflMgEAgX(Controller P_0, string P_1, string P_2)
				{
					CfRxsfJxryBfBvMGROXFflMgEAgX(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap PvGGEvixOPRrFPKHxiEcAbVbCEDAA(ControllerType P_0, int P_1, int P_2)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					return sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.uQYBazlQkgnkWSHYtTMdrfuXbodA(P_2);
				}

				private ControllerMap PvGGEvixOPRrFPKHxiEcAbVbCEDAA(Controller P_0, int P_1)
				{
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(P_0.type, P_0.id, P_1);
				}

				private ControllerMap PvGGEvixOPRrFPKHxiEcAbVbCEDAA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					return sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.uQYBazlQkgnkWSHYtTMdrfuXbodA(P_2, P_3);
				}

				private ControllerMap PvGGEvixOPRrFPKHxiEcAbVbCEDAA(Controller P_0, int P_1, int P_2)
				{
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap PvGGEvixOPRrFPKHxiEcAbVbCEDAA(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap PvGGEvixOPRrFPKHxiEcAbVbCEDAA(Controller P_0, string P_1, string P_2)
				{
					return PvGGEvixOPRrFPKHxiEcAbVbCEDAA(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap GMtbuOOPLUFtLDbWOBhQyqzcuFEF(ControllerType P_0, int P_1, int P_2)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					return sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.MKYPSXkjaVPWrnUsjBtUycLpghekA(P_2);
				}

				private ControllerMap GMtbuOOPLUFtLDbWOBhQyqzcuFEF(Controller P_0, int P_1)
				{
					return GMtbuOOPLUFtLDbWOBhQyqzcuFEF(P_0.type, P_0.id, P_1);
				}

				private ControllerMap GMtbuOOPLUFtLDbWOBhQyqzcuFEF(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GMtbuOOPLUFtLDbWOBhQyqzcuFEF(P_0, P_1, mapCategoryId);
				}

				private ControllerMap GMtbuOOPLUFtLDbWOBhQyqzcuFEF(Controller P_0, string P_1)
				{
					return GMtbuOOPLUFtLDbWOBhQyqzcuFEF(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] utDhQMcgpouHkyuHDozHLIPDthDu(ControllerType P_0)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = 0;
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						num += sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; j++)
					{
						GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI;
						for (int k = 0; k < gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; k++)
						{
							array[num] = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] emtuMhLJGInsddCYXfnphdoHVFBK(ControllerType P_0, int P_1, bool P_2)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI;
					for (int i = 0; i < gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ControllerMap controllerMap = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW;
						list.Add(ControllerMapSaveData.goGesjEFofcTayLyzynfoITRPCBk(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] emtuMhLJGInsddCYXfnphdoHVFBK<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = DXYiJElpUHxcPboaihvPaElwMWxMA.gItAobfJhZtpZbQASGIIXWhmEiLe<_0001>();
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI;
					for (int i = 0; i < gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						ControllerMap controllerMap = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW;
						list.Add(ControllerMapSaveData.goGesjEFofcTayLyzynfoITRPCBk<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] eFngKnGUAKRMCBwmxgtadjBjeWmtA(ControllerType P_0, bool P_1)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI;
						for (int j = 0; j < gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; j++)
						{
							ControllerMap controllerMap = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW;
							list.Add(ControllerMapSaveData.goGesjEFofcTayLyzynfoITRPCBk(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] eFngKnGUAKRMCBwmxgtadjBjeWmtA<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = DXYiJElpUHxcPboaihvPaElwMWxMA.gItAobfJhZtpZbQASGIIXWhmEiLe<_0001>();
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI;
						for (int j = 0; j < gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; j++)
						{
							ControllerMap controllerMap = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW;
							list.Add(ControllerMapSaveData.goGesjEFofcTayLyzynfoITRPCBk<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int NloARrxwmisPIiVHlElIZpJqYCWN(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return 0;
					}
					return sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.kULyUgOGRYyaYzxPmFROPMgfrdZQ(P_2, P_3, false);
				}

				private int NloARrxwmisPIiVHlElIZpJqYCWN(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return NloARrxwmisPIiVHlElIZpJqYCWN(P_0.type, P_0.id, P_1, P_2);
				}

				private int NloARrxwmisPIiVHlElIZpJqYCWN(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return NloARrxwmisPIiVHlElIZpJqYCWN(P_0, P_1, mapCategoryId, P_3);
				}

				private int NloARrxwmisPIiVHlElIZpJqYCWN(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return NloARrxwmisPIiVHlElIZpJqYCWN(P_0.type, P_0.id, P_1, P_2);
				}

				private IEnumerable<ControllerMap> kwqQdIGyMZGEpYAtHOJzxyBAEjpb(ControllerType P_0, int P_1, int P_2)
				{
					return new eqlGGMFbVJnvDtzveODlyQwHsCDK(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_1,
						qHziAbvFUwsFWKYqEOolHHfukCxi = P_2
					};
				}

				private IEnumerable<_0001> kwqQdIGyMZGEpYAtHOJzxyBAEjpb<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new TGLarDMyXKCvXlSKXKzsFhVlMZfT<_0001>(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_0,
						qHziAbvFUwsFWKYqEOolHHfukCxi = P_1
					};
				}

				private ActionElementMap TxgGkivsqDryhXPtIRVaXwKnnZPb(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
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

				private ActionElementMap TxgGkivsqDryhXPtIRVaXwKnnZPb(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return TxgGkivsqDryhXPtIRVaXwKnnZPb(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> bcyTonfFSpgfGDMmRwwqiVDsItbQA(ControllerType P_0, int P_1, bool P_2)
				{
					return new xDUlGoJpijiacNJcqbyEoCpZefgS(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_1,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_2
					};
				}

				private IEnumerable<ActionElementMap> bcyTonfFSpgfGDMmRwwqiVDsItbQA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return bcyTonfFSpgfGDMmRwwqiVDsItbQA(P_0, num, P_2);
				}

				private ActionElementMap TEiMjvivGCRlGtaAWhNdBExTsstN(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
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

				private ActionElementMap TEiMjvivGCRlGtaAWhNdBExTsstN(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return TEiMjvivGCRlGtaAWhNdBExTsstN(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> mOBiFFEMDyVgDBJSrccabPQUuiCg(ControllerType P_0, int P_1, bool P_2)
				{
					return new eReuXNfWHJJwKGPdWbvbXsbCPhxl(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_1,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_2
					};
				}

				private IEnumerable<ActionElementMap> mOBiFFEMDyVgDBJSrccabPQUuiCg(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return mOBiFFEMDyVgDBJSrccabPQUuiCg(P_0, num, P_2);
				}

				private ActionElementMap XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
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

				private ActionElementMap XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> crWOQZIWbDAhnRdUFPTKddSYazFe(ControllerType P_0, int P_1, bool P_2)
				{
					return new KSWRodpGJcSOBCatlPeFCfALRcBP(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_1,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_2
					};
				}

				private IEnumerable<ActionElementMap> crWOQZIWbDAhnRdUFPTKddSYazFe(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return crWOQZIWbDAhnRdUFPTKddSYazFe(P_0, num, P_2);
				}

				private int IAFaiPDVSznVecIdjDdpGufUQUZb(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num2; j++)
						{
							GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI;
							int num3 = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.IAFaiPDVSznVecIdjDdpGufUQUZb(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int AInCQcdygmFlEHaSEZaUCkYWhGekc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num2; j++)
						{
							GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI;
							int num3 = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							for (int k = 0; k < num3; k++)
							{
								if (gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.AInCQcdygmFlEHaSEZaUCkYWhGekc(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int zwdxASlITbuZpVbhYqYmCmlNvatv(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i);
						int num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						for (int j = 0; j < num2; j++)
						{
							GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j).TptZzDLPedINfuoxMyhBGLwShqDI;
							int num3 = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.zwdxASlITbuZpVbhYqYmCmlNvatv(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int vMhhEsupVSeWoEmsrktUBeeepPjwA(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].IAFaiPDVSznVecIdjDdpGufUQUZb(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int vMhhEsupVSeWoEmsrktUBeeepPjwA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return vMhhEsupVSeWoEmsrktUBeeepPjwA(P_0, num, P_2, P_3, P_4);
				}

				private int AzVSaHhpGdlIUAxEwBowRPkChzr(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).AInCQcdygmFlEHaSEZaUCkYWhGekc(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int AzVSaHhpGdlIUAxEwBowRPkChzr(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return AzVSaHhpGdlIUAxEwBowRPkChzr(P_0, num, P_2, P_3, P_4);
				}

				private int MxxSPMuZpDpLYPCHFNVeSQGZKUYt(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					for (int i = 0; i < sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
					{
						IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].zwdxASlITbuZpVbhYqYmCmlNvatv(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int MxxSPMuZpDpLYPCHFNVeSQGZKUYt(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_1);
					return MxxSPMuZpDpLYPCHFNVeSQGZKUYt(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap TxgGkivsqDryhXPtIRVaXwKnnZPb(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
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

				private ActionElementMap TxgGkivsqDryhXPtIRVaXwKnnZPb(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return TxgGkivsqDryhXPtIRVaXwKnnZPb(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> bcyTonfFSpgfGDMmRwwqiVDsItbQA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new QJNkrcMmWdxPeTHyzaYxDuclDxMMA(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_1,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3
					};
				}

				private IEnumerable<ActionElementMap> bcyTonfFSpgfGDMmRwwqiVDsItbQA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return bcyTonfFSpgfGDMmRwwqiVDsItbQA(P_0, P_1, num, P_3);
				}

				private ActionElementMap TEiMjvivGCRlGtaAWhNdBExTsstN(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
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

				private ActionElementMap TEiMjvivGCRlGtaAWhNdBExTsstN(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return TEiMjvivGCRlGtaAWhNdBExTsstN(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> mOBiFFEMDyVgDBJSrccabPQUuiCg(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new imBgocRWAYxWpEMUTXslgkOyECrH(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_1,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3
					};
				}

				private IEnumerable<ActionElementMap> mOBiFFEMDyVgDBJSrccabPQUuiCg(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return mOBiFFEMDyVgDBJSrccabPQUuiCg(P_0, P_1, num, P_3);
				}

				private ActionElementMap XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
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

				private ActionElementMap XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return XGUFJOJMJPsnFVLUAdJGmyvdSGZcA(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> crWOQZIWbDAhnRdUFPTKddSYazFe(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new xiJMEzeKrtMwQVffhoDrflrBzAjg(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zMVppMXkpFDJplkUbOPXtnZQmeFP = P_0,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_1,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3
					};
				}

				private IEnumerable<ActionElementMap> crWOQZIWbDAhnRdUFPTKddSYazFe(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return crWOQZIWbDAhnRdUFPTKddSYazFe(P_0, P_1, num, P_3);
				}

				private int vMhhEsupVSeWoEmsrktUBeeepPjwA(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.IAFaiPDVSznVecIdjDdpGufUQUZb(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int vMhhEsupVSeWoEmsrktUBeeepPjwA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return vMhhEsupVSeWoEmsrktUBeeepPjwA(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int AzVSaHhpGdlIUAxEwBowRPkChzr(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.AInCQcdygmFlEHaSEZaUCkYWhGekc(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int AzVSaHhpGdlIUAxEwBowRPkChzr(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return AzVSaHhpGdlIUAxEwBowRPkChzr(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int MxxSPMuZpDpLYPCHFNVeSQGZKUYt(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).TptZzDLPedINfuoxMyhBGLwShqDI.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].zwdxASlITbuZpVbhYqYmCmlNvatv(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int MxxSPMuZpDpLYPCHFNVeSQGZKUYt(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
					return MxxSPMuZpDpLYPCHFNVeSQGZKUYt(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap XVBIGuwjdUxtMPnVgYILXbpHJhcM(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controller.type);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					for (int i = 0; i < num; i++)
					{
						GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI;
						_ = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						IList<ControllerMap> list = gNnLMzlpRKtFyJlexoafWNjfiSkf.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.XVBIGuwjdUxtMPnVgYILXbpHJhcM(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				private IEnumerable<ActionElementMap> elCkhYpANChLaaQLuyMfQmZgFLYPA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new mGyhsuwvXqlBignILjSYEmMDdltLA(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						HQhUPrZFsWAouBRHfSQZsgJAROS = P_0,
						miyQcIyerNKBuYEvrsNdyauqcls = P_1,
						imPhNiAdSzPIDbaiYHKoCuSQkYkF = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3
					};
				}

				private int DByGazdclNMniEHyXlrfkPzVFmhE(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controller.type);
					int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).TptZzDLPedINfuoxMyhBGLwShqDI;
						_ = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
						IList<ControllerMap> list = gNnLMzlpRKtFyJlexoafWNjfiSkf.tdSzpPHKfmBDODKRfKLNtbvfkBRHb;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.DByGazdclNMniEHyXlrfkPzVFmhE(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
							}
						}
					}
					return num2;
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class xjNFgaGEAxzCGpMvmKEUcJisAlKHb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int NllHoiusTYORayNdGrDUQSJcNLpr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public xjNFgaGEAxzCGpMvmKEUcJisAlKHb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
							NllHoiusTYORayNdGrDUQSJcNLpr = aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NllHoiusTYORayNdGrDUQSJcNLpr)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = aafAjXCVQhgjOdPPxNvbSSUPrlbR[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllAxes().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						xjNFgaGEAxzCGpMvmKEUcJisAlKHb xjNFgaGEAxzCGpMvmKEUcJisAlKHb2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							xjNFgaGEAxzCGpMvmKEUcJisAlKHb2 = this;
						}
						else
						{
							xjNFgaGEAxzCGpMvmKEUcJisAlKHb2 = new xjNFgaGEAxzCGpMvmKEUcJisAlKHb(0);
							xjNFgaGEAxzCGpMvmKEUcJisAlKHb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return xjNFgaGEAxzCGpMvmKEUcJisAlKHb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class LfwujtPnGFELmcqOdfYEUNBdKSMW : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int NllHoiusTYORayNdGrDUQSJcNLpr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public LfwujtPnGFELmcqOdfYEUNBdKSMW(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
							NllHoiusTYORayNdGrDUQSJcNLpr = aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NllHoiusTYORayNdGrDUQSJcNLpr)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = aafAjXCVQhgjOdPPxNvbSSUPrlbR[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllButtons().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						LfwujtPnGFELmcqOdfYEUNBdKSMW lfwujtPnGFELmcqOdfYEUNBdKSMW;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							lfwujtPnGFELmcqOdfYEUNBdKSMW = this;
						}
						else
						{
							lfwujtPnGFELmcqOdfYEUNBdKSMW = new LfwujtPnGFELmcqOdfYEUNBdKSMW(0);
							lfwujtPnGFELmcqOdfYEUNBdKSMW.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return lfwujtPnGFELmcqOdfYEUNBdKSMW;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class SZCtUZsswIBnVIdhyhBkNKpkaIPI : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int NllHoiusTYORayNdGrDUQSJcNLpr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public SZCtUZsswIBnVIdhyhBkNKpkaIPI(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
							NllHoiusTYORayNdGrDUQSJcNLpr = aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NllHoiusTYORayNdGrDUQSJcNLpr)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = aafAjXCVQhgjOdPPxNvbSSUPrlbR[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllButtonsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						SZCtUZsswIBnVIdhyhBkNKpkaIPI sZCtUZsswIBnVIdhyhBkNKpkaIPI;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							sZCtUZsswIBnVIdhyhBkNKpkaIPI = this;
						}
						else
						{
							sZCtUZsswIBnVIdhyhBkNKpkaIPI = new SZCtUZsswIBnVIdhyhBkNKpkaIPI(0);
							sZCtUZsswIBnVIdhyhBkNKpkaIPI.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return sZCtUZsswIBnVIdhyhBkNKpkaIPI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class tGkRCxqjDJFvMcNEHBgfByIAWcqeb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int NllHoiusTYORayNdGrDUQSJcNLpr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public tGkRCxqjDJFvMcNEHBgfByIAWcqeb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
							NllHoiusTYORayNdGrDUQSJcNLpr = aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NllHoiusTYORayNdGrDUQSJcNLpr)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = aafAjXCVQhgjOdPPxNvbSSUPrlbR[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllElements().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						tGkRCxqjDJFvMcNEHBgfByIAWcqeb tGkRCxqjDJFvMcNEHBgfByIAWcqeb2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							tGkRCxqjDJFvMcNEHBgfByIAWcqeb2 = this;
						}
						else
						{
							tGkRCxqjDJFvMcNEHBgfByIAWcqeb2 = new tGkRCxqjDJFvMcNEHBgfByIAWcqeb(0);
							tGkRCxqjDJFvMcNEHBgfByIAWcqeb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return tGkRCxqjDJFvMcNEHBgfByIAWcqeb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ciQPfjTPmZeEphrFVDUPeZnOfxHY : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int NllHoiusTYORayNdGrDUQSJcNLpr;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ciQPfjTPmZeEphrFVDUPeZnOfxHY(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
							NllHoiusTYORayNdGrDUQSJcNLpr = aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NllHoiusTYORayNdGrDUQSJcNLpr)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = aafAjXCVQhgjOdPPxNvbSSUPrlbR[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllElementsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						ciQPfjTPmZeEphrFVDUPeZnOfxHY ciQPfjTPmZeEphrFVDUPeZnOfxHY2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ciQPfjTPmZeEphrFVDUPeZnOfxHY2 = this;
						}
						else
						{
							ciQPfjTPmZeEphrFVDUPeZnOfxHY2 = new ciQPfjTPmZeEphrFVDUPeZnOfxHY(0);
							ciQPfjTPmZeEphrFVDUPeZnOfxHY2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return ciQPfjTPmZeEphrFVDUPeZnOfxHY2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wUucRgbVYYEBbGdFtjuNcomFdvoXb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int NtuazDdlGImEegbrpFaEfJdcDBfq;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public wUucRgbVYYEBbGdFtjuNcomFdvoXb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
							NtuazDdlGImEegbrpFaEfJdcDBfq = UIhbyKfYtNBZjDUqliRDlZLkiScK.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NtuazDdlGImEegbrpFaEfJdcDBfq)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = UIhbyKfYtNBZjDUqliRDlZLkiScK[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllAxes().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						wUucRgbVYYEBbGdFtjuNcomFdvoXb wUucRgbVYYEBbGdFtjuNcomFdvoXb2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							wUucRgbVYYEBbGdFtjuNcomFdvoXb2 = this;
						}
						else
						{
							wUucRgbVYYEBbGdFtjuNcomFdvoXb2 = new wUucRgbVYYEBbGdFtjuNcomFdvoXb(0);
							wUucRgbVYYEBbGdFtjuNcomFdvoXb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return wUucRgbVYYEBbGdFtjuNcomFdvoXb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class KSKIWENcIzBbPdldfSKdPuVuLmTDb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int NtuazDdlGImEegbrpFaEfJdcDBfq;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public KSKIWENcIzBbPdldfSKdPuVuLmTDb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
							NtuazDdlGImEegbrpFaEfJdcDBfq = UIhbyKfYtNBZjDUqliRDlZLkiScK.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NtuazDdlGImEegbrpFaEfJdcDBfq)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = UIhbyKfYtNBZjDUqliRDlZLkiScK[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllButtons().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						KSKIWENcIzBbPdldfSKdPuVuLmTDb kSKIWENcIzBbPdldfSKdPuVuLmTDb;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							kSKIWENcIzBbPdldfSKdPuVuLmTDb = this;
						}
						else
						{
							kSKIWENcIzBbPdldfSKdPuVuLmTDb = new KSKIWENcIzBbPdldfSKdPuVuLmTDb(0);
							kSKIWENcIzBbPdldfSKdPuVuLmTDb.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return kSKIWENcIzBbPdldfSKdPuVuLmTDb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class bKCTQOYynqlRkBgiGdKYyqFGUzMT : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int NtuazDdlGImEegbrpFaEfJdcDBfq;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public bKCTQOYynqlRkBgiGdKYyqFGUzMT(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
							NtuazDdlGImEegbrpFaEfJdcDBfq = UIhbyKfYtNBZjDUqliRDlZLkiScK.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NtuazDdlGImEegbrpFaEfJdcDBfq)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = UIhbyKfYtNBZjDUqliRDlZLkiScK[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllButtonsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						bKCTQOYynqlRkBgiGdKYyqFGUzMT bKCTQOYynqlRkBgiGdKYyqFGUzMT2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							bKCTQOYynqlRkBgiGdKYyqFGUzMT2 = this;
						}
						else
						{
							bKCTQOYynqlRkBgiGdKYyqFGUzMT2 = new bKCTQOYynqlRkBgiGdKYyqFGUzMT(0);
							bKCTQOYynqlRkBgiGdKYyqFGUzMT2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return bKCTQOYynqlRkBgiGdKYyqFGUzMT2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZSXgHWogNvJrmoUjmomURyhrsydH : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int NtuazDdlGImEegbrpFaEfJdcDBfq;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ZSXgHWogNvJrmoUjmomURyhrsydH(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
							NtuazDdlGImEegbrpFaEfJdcDBfq = UIhbyKfYtNBZjDUqliRDlZLkiScK.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NtuazDdlGImEegbrpFaEfJdcDBfq)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = UIhbyKfYtNBZjDUqliRDlZLkiScK[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllElements().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						ZSXgHWogNvJrmoUjmomURyhrsydH zSXgHWogNvJrmoUjmomURyhrsydH;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							zSXgHWogNvJrmoUjmomURyhrsydH = this;
						}
						else
						{
							zSXgHWogNvJrmoUjmomURyhrsydH = new ZSXgHWogNvJrmoUjmomURyhrsydH(0);
							zSXgHWogNvJrmoUjmomURyhrsydH.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return zSXgHWogNvJrmoUjmomURyhrsydH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class tjpxalzuQUMvvJaLxYFHZkICDzMA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int NtuazDdlGImEegbrpFaEfJdcDBfq;

					private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

					private IEnumerator<ControllerPollingInfo> MAgtMVEQAhdnIrDfsBUadgjNeEXJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public tjpxalzuQUMvvJaLxYFHZkICDzMA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00c5;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
							NtuazDdlGImEegbrpFaEfJdcDBfq = UIhbyKfYtNBZjDUqliRDlZLkiScK.Count;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
							goto IL_00f1;
							IL_00c5:
							if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ.MoveNext())
							{
								ControllerPollingInfo current = MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ = null;
							AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
							goto IL_00f1;
							IL_00f1:
							if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < NtuazDdlGImEegbrpFaEfJdcDBfq)
							{
								MAgtMVEQAhdnIrDfsBUadgjNeEXJ = UIhbyKfYtNBZjDUqliRDlZLkiScK[AEpFbNhiazpfukEJmuNHcDAbfQLWA].PollForAllElementsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (MAgtMVEQAhdnIrDfsBUadgjNeEXJ != null)
						{
							MAgtMVEQAhdnIrDfsBUadgjNeEXJ.Dispose();
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
						tjpxalzuQUMvvJaLxYFHZkICDzMA tjpxalzuQUMvvJaLxYFHZkICDzMA2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							tjpxalzuQUMvvJaLxYFHZkICDzMA2 = this;
						}
						else
						{
							tjpxalzuQUMvvJaLxYFHZkICDzMA2 = new tjpxalzuQUMvvJaLxYFHZkICDzMA(0);
							tjpxalzuQUMvvJaLxYFHZkICDzMA2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return tjpxalzuQUMvvJaLxYFHZkICDzMA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class SSpyXwxREuPlYoCDpDeMdSEokftfb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public SSpyXwxREuPlYoCDpDeMdSEokftfb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0)
								{
									return false;
								}
								CustomController customController = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(huYafrIsSOmDxgVyGZWCXtREVVkLb);
								if (customController == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = customController.PollForAllAxes().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						SSpyXwxREuPlYoCDpDeMdSEokftfb sSpyXwxREuPlYoCDpDeMdSEokftfb;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							sSpyXwxREuPlYoCDpDeMdSEokftfb = this;
						}
						else
						{
							sSpyXwxREuPlYoCDpDeMdSEokftfb = new SSpyXwxREuPlYoCDpDeMdSEokftfb(0);
							sSpyXwxREuPlYoCDpDeMdSEokftfb.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						sSpyXwxREuPlYoCDpDeMdSEokftfb.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						return sSpyXwxREuPlYoCDpDeMdSEokftfb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class egtyWhmwDPNKyuDDSfshajtxeOxQ : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public egtyWhmwDPNKyuDDSfshajtxeOxQ(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0)
								{
									return false;
								}
								CustomController customController = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(huYafrIsSOmDxgVyGZWCXtREVVkLb);
								if (customController == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = customController.PollForAllButtons().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						egtyWhmwDPNKyuDDSfshajtxeOxQ egtyWhmwDPNKyuDDSfshajtxeOxQ2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							egtyWhmwDPNKyuDDSfshajtxeOxQ2 = this;
						}
						else
						{
							egtyWhmwDPNKyuDDSfshajtxeOxQ2 = new egtyWhmwDPNKyuDDSfshajtxeOxQ(0);
							egtyWhmwDPNKyuDDSfshajtxeOxQ2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						egtyWhmwDPNKyuDDSfshajtxeOxQ2.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						return egtyWhmwDPNKyuDDSfshajtxeOxQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class XxWVQZTiJMIEsCpodVDLoQLedlzu : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public XxWVQZTiJMIEsCpodVDLoQLedlzu(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0)
								{
									return false;
								}
								CustomController customController = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(huYafrIsSOmDxgVyGZWCXtREVVkLb);
								if (customController == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = customController.PollForAllButtonsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						XxWVQZTiJMIEsCpodVDLoQLedlzu xxWVQZTiJMIEsCpodVDLoQLedlzu;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							xxWVQZTiJMIEsCpodVDLoQLedlzu = this;
						}
						else
						{
							xxWVQZTiJMIEsCpodVDLoQLedlzu = new XxWVQZTiJMIEsCpodVDLoQLedlzu(0);
							xxWVQZTiJMIEsCpodVDLoQLedlzu.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						xxWVQZTiJMIEsCpodVDLoQLedlzu.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						return xxWVQZTiJMIEsCpodVDLoQLedlzu;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class LHXtxylzAsONpUGTTOVBXPmjJtNF : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public LHXtxylzAsONpUGTTOVBXPmjJtNF(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0)
								{
									return false;
								}
								CustomController customController = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(huYafrIsSOmDxgVyGZWCXtREVVkLb);
								if (customController == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = customController.PollForAllElements().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						LHXtxylzAsONpUGTTOVBXPmjJtNF lHXtxylzAsONpUGTTOVBXPmjJtNF;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							lHXtxylzAsONpUGTTOVBXPmjJtNF = this;
						}
						else
						{
							lHXtxylzAsONpUGTTOVBXPmjJtNF = new LHXtxylzAsONpUGTTOVBXPmjJtNF(0);
							lHXtxylzAsONpUGTTOVBXPmjJtNF.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						lHXtxylzAsONpUGTTOVBXPmjJtNF.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						return lHXtxylzAsONpUGTTOVBXPmjJtNF;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WcSxjkHUoPhyTJXntubcbmfmUBcI : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int huYafrIsSOmDxgVyGZWCXtREVVkLb;

					public int zIsKEqaEtnZxGsBfLbxmVqkeAugFA;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public WcSxjkHUoPhyTJXntubcbmfmUBcI(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (huYafrIsSOmDxgVyGZWCXtREVVkLb < 0)
								{
									return false;
								}
								CustomController customController = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(huYafrIsSOmDxgVyGZWCXtREVVkLb);
								if (customController == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = customController.PollForAllElementsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						WcSxjkHUoPhyTJXntubcbmfmUBcI wcSxjkHUoPhyTJXntubcbmfmUBcI;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							wcSxjkHUoPhyTJXntubcbmfmUBcI = this;
						}
						else
						{
							wcSxjkHUoPhyTJXntubcbmfmUBcI = new WcSxjkHUoPhyTJXntubcbmfmUBcI(0);
							wcSxjkHUoPhyTJXntubcbmfmUBcI.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						wcSxjkHUoPhyTJXntubcbmfmUBcI.huYafrIsSOmDxgVyGZWCXtREVVkLb = zIsKEqaEtnZxGsBfLbxmVqkeAugFA;
						return wcSxjkHUoPhyTJXntubcbmfmUBcI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ihlTjokSvBtWUpCAasEcPQNvdfVW : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ihlTjokSvBtWUpCAasEcPQNvdfVW(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0)
								{
									return false;
								}
								Joystick joystick = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(gOiPPdQXptOcZupOsvpkYdiPsPSw);
								if (joystick == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = joystick.PollForAllAxes().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						ihlTjokSvBtWUpCAasEcPQNvdfVW ihlTjokSvBtWUpCAasEcPQNvdfVW2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ihlTjokSvBtWUpCAasEcPQNvdfVW2 = this;
						}
						else
						{
							ihlTjokSvBtWUpCAasEcPQNvdfVW2 = new ihlTjokSvBtWUpCAasEcPQNvdfVW(0);
							ihlTjokSvBtWUpCAasEcPQNvdfVW2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						ihlTjokSvBtWUpCAasEcPQNvdfVW2.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						return ihlTjokSvBtWUpCAasEcPQNvdfVW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ryrxCgObaWFlJaJnrjigeTSwfLQK : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ryrxCgObaWFlJaJnrjigeTSwfLQK(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0)
								{
									return false;
								}
								Joystick joystick = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(gOiPPdQXptOcZupOsvpkYdiPsPSw);
								if (joystick == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = joystick.PollForAllButtons().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						ryrxCgObaWFlJaJnrjigeTSwfLQK ryrxCgObaWFlJaJnrjigeTSwfLQK2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ryrxCgObaWFlJaJnrjigeTSwfLQK2 = this;
						}
						else
						{
							ryrxCgObaWFlJaJnrjigeTSwfLQK2 = new ryrxCgObaWFlJaJnrjigeTSwfLQK(0);
							ryrxCgObaWFlJaJnrjigeTSwfLQK2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						ryrxCgObaWFlJaJnrjigeTSwfLQK2.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						return ryrxCgObaWFlJaJnrjigeTSwfLQK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class KZsJkvipjGDIMKTVxYPKKUXLqRHcb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public KZsJkvipjGDIMKTVxYPKKUXLqRHcb(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0)
								{
									return false;
								}
								Joystick joystick = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(gOiPPdQXptOcZupOsvpkYdiPsPSw);
								if (joystick == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = joystick.PollForAllButtonsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						KZsJkvipjGDIMKTVxYPKKUXLqRHcb kZsJkvipjGDIMKTVxYPKKUXLqRHcb;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							kZsJkvipjGDIMKTVxYPKKUXLqRHcb = this;
						}
						else
						{
							kZsJkvipjGDIMKTVxYPKKUXLqRHcb = new KZsJkvipjGDIMKTVxYPKKUXLqRHcb(0);
							kZsJkvipjGDIMKTVxYPKKUXLqRHcb.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						kZsJkvipjGDIMKTVxYPKKUXLqRHcb.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						return kZsJkvipjGDIMKTVxYPKKUXLqRHcb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ayHolDbWKcRVIySjtMqLvhAwsTgf : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ayHolDbWKcRVIySjtMqLvhAwsTgf(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0)
								{
									return false;
								}
								Joystick joystick = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(gOiPPdQXptOcZupOsvpkYdiPsPSw);
								if (joystick == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = joystick.PollForAllElements().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						ayHolDbWKcRVIySjtMqLvhAwsTgf ayHolDbWKcRVIySjtMqLvhAwsTgf2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ayHolDbWKcRVIySjtMqLvhAwsTgf2 = this;
						}
						else
						{
							ayHolDbWKcRVIySjtMqLvhAwsTgf2 = new ayHolDbWKcRVIySjtMqLvhAwsTgf(0);
							ayHolDbWKcRVIySjtMqLvhAwsTgf2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						ayHolDbWKcRVIySjtMqLvhAwsTgf2.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						return ayHolDbWKcRVIySjtMqLvhAwsTgf2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ftRruKCAQchLJpABnRoZITvzzjIK : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int gOiPPdQXptOcZupOsvpkYdiPsPSw;

					public int aDzAHPYDmmtJzoDoQQliFJCeHIDs;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ftRruKCAQchLJpABnRoZITvzzjIK(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
							{
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (gOiPPdQXptOcZupOsvpkYdiPsPSw < 0)
								{
									return false;
								}
								Joystick joystick = gZXxEqHwrHYIyUJtInpLwgTukJaY.eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(gOiPPdQXptOcZupOsvpkYdiPsPSw);
								if (joystick == null)
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = joystick.PollForAllElementsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								ControllerPollingInfo uSjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(current);
								uSjDTWbJtWhEBdYYYfLUglTcnnGrA.playerId = gZXxEqHwrHYIyUJtInpLwgTukJaY.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = uSjDTWbJtWhEBdYYYfLUglTcnnGrA;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						ftRruKCAQchLJpABnRoZITvzzjIK ftRruKCAQchLJpABnRoZITvzzjIK2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ftRruKCAQchLJpABnRoZITvzzjIK2 = this;
						}
						else
						{
							ftRruKCAQchLJpABnRoZITvzzjIK2 = new ftRruKCAQchLJpABnRoZITvzzjIK(0);
							ftRruKCAQchLJpABnRoZITvzzjIK2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						ftRruKCAQchLJpABnRoZITvzzjIK2.gOiPPdQXptOcZupOsvpkYdiPsPSw = aDzAHPYDmmtJzoDoQQliFJCeHIDs;
						return ftRruKCAQchLJpABnRoZITvzzjIK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm;

				private readonly ControllerHelper eHuiQIUmbPfDCAmSwYoMRKeanDnjb;

				private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
					EVSYfBRoRmlZGWzbtVEKHpHdIHIm = P_0;
					eHuiQIUmbPfDCAmSwYoMRKeanDnjb = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Joystick => ZFQPSDJcKZhWWHjXyOvBmZRuBmLmA(controllerId), 
						ControllerType.Mouse => PoFgtZdPjGCJOIrJBmGogpiAalkf(), 
						ControllerType.Custom => WYEQVWQbCamIVkUJsucyXGswgEHIA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Joystick => TSsZtTNgJLeYxFRpZPSUynhIoYcxA(controllerId), 
						ControllerType.Mouse => EDKIaPiqBGEcZBwOHJFQiQpNsxnu(), 
						ControllerType.Custom => uUiPhFIplLVGcEnYpMbEdkjDQlQN(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Joystick => dqjcWYFFuiYLRFzdMUNoqiHwKvMjA(controllerId), 
						ControllerType.Mouse => YJkTxoYUIqmURpYBEKhJVmPwBJIH(), 
						ControllerType.Custom => frNQPRtpMnDVZuUhICTYDjSRazdq(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Joystick => bbgaALKRIObjZebUDTnCpzMOYpl(controllerId), 
						ControllerType.Mouse => wWmcUNvOElUYXQSGOgqHskSYKmRX(), 
						ControllerType.Custom => aLmsncwhQHymTBbjxTLQPbOHKCqu(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV(), 
						ControllerType.Joystick => UGJsIWrLkfCXXAgactfSLfQfzdab(controllerId), 
						ControllerType.Mouse => OLGGVbOoPzFfzkuSaBfROOhrrMzM(), 
						ControllerType.Custom => CDAnUZFkhdIbQmxVWnlVIedquAxr(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ULtaVEESJmqfDbraMhrzPodihJNDA(), 
						ControllerType.Joystick => jLqomNZmEgJcbVNpJbaCjYhuJLTq(controllerId), 
						ControllerType.Mouse => bSseUnOHIWiSfbOImWOjQdnBeeSab(), 
						ControllerType.Custom => UkqQsviXdNDzwJWRzsseIocxhZpF(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => klEGtgXqpcnAfMgCcWTxSOsmdWkb(), 
						ControllerType.Joystick => xBvExNCWMJkTZXNDZiUvCOncrPrSA(controllerId), 
						ControllerType.Mouse => hfcNcDmbtLKyvvHvvJlkyvKCMFri(), 
						ControllerType.Custom => naCfrYkNkGlXjVvdmYiSDNDFOeZTA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ULtaVEESJmqfDbraMhrzPodihJNDA(), 
						ControllerType.Joystick => RVDGPqEvDAwMpCzuKUxThApWMOTAA(controllerId), 
						ControllerType.Mouse => CgOhupIcrKhbfzOvEhqFojuLLkjp(), 
						ControllerType.Custom => mwpBCnCvAzFoObigAtkufAMgEQGlb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => klEGtgXqpcnAfMgCcWTxSOsmdWkb(), 
						ControllerType.Joystick => qIziKcXjejvaniFgdSKtXmUPJERe(controllerId), 
						ControllerType.Mouse => wnFkpRdMAAeDUMnvXkXhVbQrtMWx(), 
						ControllerType.Custom => odvpmlDQOaJazHjiHGMRGJOZvwpaA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => cSoGNXgqSKUXrxwyoWKDfxZGhFMP(controllerId), 
						ControllerType.Mouse => aNECRxgTvdIxEuDrjWbXdFsyQYvkA(), 
						ControllerType.Custom => nPGgnFxfFlCbDirHtOpNMWUDzEKrA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Joystick => LmCCtDIwlaCJxvyeVOIcdGXStBwKA(), 
						ControllerType.Mouse => PoFgtZdPjGCJOIrJBmGogpiAalkf(), 
						ControllerType.Custom => QrZwrFYntBxbzmVMFdWwoGjhPhbt(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Joystick => lQpAvvzDrddilGPtTfxaaPyhkPhnc(), 
						ControllerType.Mouse => YJkTxoYUIqmURpYBEKhJVmPwBJIH(), 
						ControllerType.Custom => JJnFilLfLRmWzvZcjAyBtncumIKi(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Joystick => hFeKUCpfSEghxHjtsKtNScwBpCtEb(), 
						ControllerType.Mouse => wWmcUNvOElUYXQSGOgqHskSYKmRX(), 
						ControllerType.Custom => nsnDqPkTWYRhBjUVRlLQIcJJqEsIc(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV(), 
						ControllerType.Joystick => qWJTWzUSmTbOBDUgekTSYbTASvcK(), 
						ControllerType.Mouse => OLGGVbOoPzFfzkuSaBfROOhrrMzM(), 
						ControllerType.Custom => EJrRvJQyAHmTWrRypumjyNJPxAxU(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ULtaVEESJmqfDbraMhrzPodihJNDA(), 
						ControllerType.Joystick => wydrzWDnlpVBVEbRWzHPiqLZvimr(), 
						ControllerType.Mouse => bSseUnOHIWiSfbOImWOjQdnBeeSab(), 
						ControllerType.Custom => FUFeTXEnsdlGKxZULrzYgWhlRliEA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => klEGtgXqpcnAfMgCcWTxSOsmdWkb(), 
						ControllerType.Joystick => TPWIHjQClyZpndrKcjszPaqjKscv(), 
						ControllerType.Mouse => hfcNcDmbtLKyvvHvvJlkyvKCMFri(), 
						ControllerType.Custom => rxkozAGDxDRznZgNovkNfzIMWBDW(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ULtaVEESJmqfDbraMhrzPodihJNDA(), 
						ControllerType.Joystick => ntSVuvEKSOIBzXFeKRpYkOMKJJpW(), 
						ControllerType.Mouse => CgOhupIcrKhbfzOvEhqFojuLLkjp(), 
						ControllerType.Custom => qVOfhPqHAmewrWNjBWivQlBINRnM(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => klEGtgXqpcnAfMgCcWTxSOsmdWkb(), 
						ControllerType.Joystick => KmWZqXFjZMlaFOFQirvAmUjMBOoi(), 
						ControllerType.Mouse => wnFkpRdMAAeDUMnvXkXhVbQrtMWx(), 
						ControllerType.Custom => KQOSGgLIEeSOXecyJTvxjcRkQpir(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => kuupDKpzqIzRQUJLxmVOVonVOxcE(), 
						ControllerType.Mouse => aNECRxgTvdIxEuDrjWbXdFsyQYvkA(), 
						ControllerType.Custom => UpPqyUhkWnRbFwCZwnjTGqKWVKbW(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo ZFQPSDJcKZhWWHjXyOvBmZRuBmLmA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					Joystick joystick = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo TSsZtTNgJLeYxFRpZPSUynhIoYcxA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					Joystick joystick = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo dqjcWYFFuiYLRFzdMUNoqiHwKvMjA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					Joystick joystick = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo bbgaALKRIObjZebUDTnCpzMOYpl(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					Joystick joystick = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo UGJsIWrLkfCXXAgactfSLfQfzdab(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					Joystick joystick = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> jLqomNZmEgJcbVNpJbaCjYhuJLTq(int P_0)
				{
					return new ayHolDbWKcRVIySjtMqLvhAwsTgf(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> xBvExNCWMJkTZXNDZiUvCOncrPrSA(int P_0)
				{
					return new ftRruKCAQchLJpABnRoZITvzzjIK(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> RVDGPqEvDAwMpCzuKUxThApWMOTAA(int P_0)
				{
					return new ryrxCgObaWFlJaJnrjigeTSwfLQK(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> qIziKcXjejvaniFgdSKtXmUPJERe(int P_0)
				{
					return new KZsJkvipjGDIMKTVxYPKKUXLqRHcb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> cSoGNXgqSKUXrxwyoWKDfxZGhFMP(int P_0)
				{
					return new ihlTjokSvBtWUpCAasEcPQNvdfVW(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						aDzAHPYDmmtJzoDoQQliFJCeHIDs = P_0
					};
				}

				private ControllerPollingInfo LmCCtDIwlaCJxvyeVOIcdGXStBwKA()
				{
					IList<Joystick> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo NLAqwwcVeQAFylvkVATfsKXonfxT()
				{
					IList<Joystick> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo lQpAvvzDrddilGPtTfxaaPyhkPhnc()
				{
					IList<Joystick> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo hFeKUCpfSEghxHjtsKtNScwBpCtEb()
				{
					IList<Joystick> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo qWJTWzUSmTbOBDUgekTSYbTASvcK()
				{
					IList<Joystick> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.PdFjgUgShCeNVIYphsmXMSjBojLS.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private IEnumerable<ControllerPollingInfo> wydrzWDnlpVBVEbRWzHPiqLZvimr()
				{
					return new ZSXgHWogNvJrmoUjmomURyhrsydH(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> TPWIHjQClyZpndrKcjszPaqjKscv()
				{
					return new tjpxalzuQUMvvJaLxYFHZkICDzMA(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> ntSVuvEKSOIBzXFeKRpYkOMKJJpW()
				{
					return new KSKIWENcIzBbPdldfSKdPuVuLmTDb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> KmWZqXFjZMlaFOFQirvAmUjMBOoi()
				{
					return new bKCTQOYynqlRkBgiGdKYyqFGUzMT(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> kuupDKpzqIzRQUJLxmVOVonVOxcE()
				{
					return new wUucRgbVYYEBbGdFtjuNcomFdvoXb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private ControllerPollingInfo tTcTpZtooBSnURBfRqwLSbjujuaE()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.GGdAnaCXnyHOgPTuPgvpCHWGGAfT)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo CxMGZpAJbEoXeXyMMiRsRtkVxmYhA()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.GGdAnaCXnyHOgPTuPgvpCHWGGAfT)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> ULtaVEESJmqfDbraMhrzPodihJNDA()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.GGdAnaCXnyHOgPTuPgvpCHWGGAfT)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> klEGtgXqpcnAfMgCcWTxSOsmdWkb()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.GGdAnaCXnyHOgPTuPgvpCHWGGAfT)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo PoFgtZdPjGCJOIrJBmGogpiAalkf()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo EDKIaPiqBGEcZBwOHJFQiQpNsxnu()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo YJkTxoYUIqmURpYBEKhJVmPwBJIH()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo wWmcUNvOElUYXQSGOgqHskSYKmRX()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo OLGGVbOoPzFfzkuSaBfROOhrrMzM()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> bSseUnOHIWiSfbOImWOjQdnBeeSab()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> hfcNcDmbtLKyvvHvvJlkyvKCMFri()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> CgOhupIcrKhbfzOvEhqFojuLLkjp()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> wnFkpRdMAAeDUMnvXkXhVbQrtMWx()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> aNECRxgTvdIxEuDrjWbXdFsyQYvkA()
				{
					if (!eHuiQIUmbPfDCAmSwYoMRKeanDnjb.jWlTboEMHXFauyXfleHJQTsTEibQ)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return eHuiQIUmbPfDCAmSwYoMRKeanDnjb.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo WYEQVWQbCamIVkUJsucyXGswgEHIA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					CustomController customController = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo uUiPhFIplLVGcEnYpMbEdkjDQlQN(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					CustomController customController = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo frNQPRtpMnDVZuUhICTYDjSRazdq(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					CustomController customController = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo aLmsncwhQHymTBbjxTLQPbOHKCqu(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					CustomController customController = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private ControllerPollingInfo CDAnUZFkhdIbQmxVWnlVIedquAxr(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					CustomController customController = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> UkqQsviXdNDzwJWRzsseIocxhZpF(int P_0)
				{
					return new LHXtxylzAsONpUGTTOVBXPmjJtNF(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> naCfrYkNkGlXjVvdmYiSDNDFOeZTA(int P_0)
				{
					return new WcSxjkHUoPhyTJXntubcbmfmUBcI(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> mwpBCnCvAzFoObigAtkufAMgEQGlb(int P_0)
				{
					return new egtyWhmwDPNKyuDDSfshajtxeOxQ(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> odvpmlDQOaJazHjiHGMRGJOZvwpaA(int P_0)
				{
					return new XxWVQZTiJMIEsCpodVDLoQLedlzu(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> nPGgnFxfFlCbDirHtOpNMWUDzEKrA(int P_0)
				{
					return new SSpyXwxREuPlYoCDpDeMdSEokftfb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
						zIsKEqaEtnZxGsBfLbxmVqkeAugFA = P_0
					};
				}

				private ControllerPollingInfo QrZwrFYntBxbzmVMFdWwoGjhPhbt()
				{
					IList<CustomController> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo dOogWtGRTNTWKToFNDTyVXMbxHpO()
				{
					IList<CustomController> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo JJnFilLfLRmWzvZcjAyBtncumIKi()
				{
					IList<CustomController> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo nsnDqPkTWYRhBjUVRlLQIcJJqEsIc()
				{
					IList<CustomController> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo EJrRvJQyAHmTWrRypumjyNJPxAxU()
				{
					IList<CustomController> list = eHuiQIUmbPfDCAmSwYoMRKeanDnjb.iFFMkBTbnLoLYCisndOOEbrBetsE.DGYIefDUHDCgTkMJljXnKsXPXps;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private IEnumerable<ControllerPollingInfo> FUFeTXEnsdlGKxZULrzYgWhlRliEA()
				{
					return new tGkRCxqjDJFvMcNEHBgfByIAWcqeb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> rxkozAGDxDRznZgNovkNfzIMWBDW()
				{
					return new ciQPfjTPmZeEphrFVDUPeZnOfxHY(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> qVOfhPqHAmewrWNjBWivQlBINRnM()
				{
					return new LfwujtPnGFELmcqOdfYEUNBdKSMW(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> KQOSGgLIEeSOXecyJTvxjcRkQpir()
				{
					return new SZCtUZsswIBnVIdhyhBkNKpkaIPI(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				private IEnumerable<ControllerPollingInfo> UpPqyUhkWnRbFwCZwnjTGqKWVKbW()
				{
					return new xjNFgaGEAxzCGpMvmKEUcJisAlKHb(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}
			}

			[Serializable]
			private sealed class FPANpSvZzZdTGEeevdfrntowJUMJ
			{
				public static readonly FPANpSvZzZdTGEeevdfrntowJUMJ _003C_003E9 = new FPANpSvZzZdTGEeevdfrntowJUMJ();

				public static Action<Exception> _003C_003E9__23_0;

				public static Action<Exception> _003C_003E9__23_1;

				internal void RNYfBxlXqgVTaUzqbvmLNBgrMKsj(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void rzJPukxoxMDRkFqqoKYAzRjrIEwe(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class FMLqPCKinhHXAYnoYztOrHAqrwBS : IDisposable, IEnumerable, IEnumerator, IEnumerable<Controller>, IEnumerator<Controller>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Controller USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public ControllerHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int ZFJvXfGRtNSgFFpSrrBrVmKZdSCO;

				private IList<Joystick> fDYTSleFqGStTUiUBWoGdWNmQuVN;

				private int EGPbWnnBzyCRjePyQWEQxlcFKIro;

				private IList<CustomController> llpPmAkJaNeftlDUKASoSsjEZzeC;

				private int lRafmbLqOPWKAMHugiOeNRqRppoV;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
					}
				}

				[DebuggerHidden]
				public FMLqPCKinhHXAYnoYztOrHAqrwBS(int P_0)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
					nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					ControllerHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.jWlTboEMHXFauyXfleHJQTsTEibQ)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.Mouse;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						goto IL_0070;
					case 2:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						goto IL_0094;
					case 3:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						lRafmbLqOPWKAMHugiOeNRqRppoV++;
						goto IL_00ec;
					case 4:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							lRafmbLqOPWKAMHugiOeNRqRppoV++;
							break;
						}
						IL_0094:
						ZFJvXfGRtNSgFFpSrrBrVmKZdSCO = gZXxEqHwrHYIyUJtInpLwgTukJaY.joystickCount;
						fDYTSleFqGStTUiUBWoGdWNmQuVN = gZXxEqHwrHYIyUJtInpLwgTukJaY.Joysticks;
						lRafmbLqOPWKAMHugiOeNRqRppoV = 0;
						goto IL_00ec;
						IL_00ec:
						if (lRafmbLqOPWKAMHugiOeNRqRppoV < ZFJvXfGRtNSgFFpSrrBrVmKZdSCO)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = fDYTSleFqGStTUiUBWoGdWNmQuVN[lRafmbLqOPWKAMHugiOeNRqRppoV];
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 3;
							return true;
						}
						EGPbWnnBzyCRjePyQWEQxlcFKIro = gZXxEqHwrHYIyUJtInpLwgTukJaY.customControllerCount;
						llpPmAkJaNeftlDUKASoSsjEZzeC = gZXxEqHwrHYIyUJtInpLwgTukJaY.CustomControllers;
						lRafmbLqOPWKAMHugiOeNRqRppoV = 0;
						break;
						IL_0070:
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.GGdAnaCXnyHOgPTuPgvpCHWGGAfT)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.Keyboard;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
							return true;
						}
						goto IL_0094;
					}
					if (lRafmbLqOPWKAMHugiOeNRqRppoV < EGPbWnnBzyCRjePyQWEQxlcFKIro)
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = llpPmAkJaNeftlDUKASoSsjEZzeC[lRafmbLqOPWKAMHugiOeNRqRppoV];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 4;
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
					FMLqPCKinhHXAYnoYztOrHAqrwBS fMLqPCKinhHXAYnoYztOrHAqrwBS;
					if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
						fMLqPCKinhHXAYnoYztOrHAqrwBS = this;
					}
					else
					{
						fMLqPCKinhHXAYnoYztOrHAqrwBS = new FMLqPCKinhHXAYnoYztOrHAqrwBS(0);
						fMLqPCKinhHXAYnoYztOrHAqrwBS.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					}
					return fMLqPCKinhHXAYnoYztOrHAqrwBS;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly IeLBOIaMcgdDkrPSUjVKJmcCVPTh QWmExxfHwSKcZBfRpLiNncXzNbPS;

			private bool jWlTboEMHXFauyXfleHJQTsTEibQ;

			private bool GGdAnaCXnyHOgPTuPgvpCHWGGAfT;

			private bool bCamddXQTLVSSwJQqSFFvzWMjjvx;

			private double PqukyquTQsfWDwVhQpDSrQarkgvg;

			private double XpGVkAfRVRBitzxQZOkcTpNQdlVKA;

			private SafeAction<ControllerAssignmentChangedEventArgs> PfnrdbYdSUQuINaDnsyoXhDfPmpt = new SafeAction<ControllerAssignmentChangedEventArgs>(FPANpSvZzZdTGEeevdfrntowJUMJ._003C_003E9.RNYfBxlXqgVTaUzqbvmLNBgrMKsj);

			private SafeAction<ControllerAssignmentChangedEventArgs> ArFcvadhFuaKfZSnEGsjSJOShNKN = new SafeAction<ControllerAssignmentChangedEventArgs>(FPANpSvZzZdTGEeevdfrntowJUMJ._003C_003E9.rzJPukxoxMDRkFqqoKYAzRjrIEwe);

			private readonly NMuECpOqnCZghHDQvwyeWgvyRblU boNSEKuFFoQzYuEJbTHAMBvFjgjG;

			private readonly Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm;

			private readonly ozJCNCgYiYUtKitDXELFzszuhHbtA poHBjfNcWvllzJNNsERwbrPxRXyc;

			private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap> PdFjgUgShCeNVIYphsmXMSjBojLS => (WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick);

			private gQqXfkghDzUgcWaoRfIdjveCqyDU<KeyboardMap> hYrEQHtzSgUzJzQQFKbPgtEKWsrc => (gQqXfkghDzUgcWaoRfIdjveCqyDU<KeyboardMap>)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Keyboard).USCGiuQyHUkFhIyPnQnjKGLOTfzD(0).TptZzDLPedINfuoxMyhBGLwShqDI;

			private gQqXfkghDzUgcWaoRfIdjveCqyDU<MouseMap> gthMaiIzQGonAWQggIJCBsFpiAYqA => (gQqXfkghDzUgcWaoRfIdjveCqyDU<MouseMap>)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Mouse).USCGiuQyHUkFhIyPnQnjKGLOTfzD(0).TptZzDLPedINfuoxMyhBGLwShqDI;

			private WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap> iFFMkBTbnLoLYCisndOOEbrBetsE => (WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return jWlTboEMHXFauyXfleHJQTsTEibQ;
				}
				set
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						if (jWlTboEMHXFauyXfleHJQTsTEibQ == value)
						{
							return;
						}
						jWlTboEMHXFauyXfleHJQTsTEibQ = value;
						if (value)
						{
							poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(Mouse);
						}
						else
						{
							poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (PfnrdbYdSUQuINaDnsyoXhDfPmpt.Count > 0)
							{
								PfnrdbYdSUQuINaDnsyoXhDfPmpt.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (ArFcvadhFuaKfZSnEGsjSJOShNKN.Count > 0)
						{
							ArFcvadhFuaKfZSnEGsjSJOShNKN.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return GGdAnaCXnyHOgPTuPgvpCHWGGAfT;
				}
				set
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						if (GGdAnaCXnyHOgPTuPgvpCHWGGAfT == value)
						{
							return;
						}
						GGdAnaCXnyHOgPTuPgvpCHWGGAfT = value;
						if (value)
						{
							poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(Keyboard);
						}
						else
						{
							poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (PfnrdbYdSUQuINaDnsyoXhDfPmpt.Count > 0)
							{
								PfnrdbYdSUQuINaDnsyoXhDfPmpt.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (ArFcvadhFuaKfZSnEGsjSJOShNKN.Count > 0)
						{
							ArFcvadhFuaKfZSnEGsjSJOShNKN.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return bCamddXQTLVSSwJQqSFFvzWMjjvx;
				}
				set
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						bCamddXQTLVSSwJQqSFFvzWMjjvx = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick).mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick) as WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>).DGYIefDUHDCgTkMJljXnKsXPXps;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom).mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom) as WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>).DGYIefDUHDCgTkMJljXnKsXPXps;
				}
			}

			public IEnumerable<Controller> Controllers => new FMLqPCKinhHXAYnoYztOrHAqrwBS(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					PfnrdbYdSUQuINaDnsyoXhDfPmpt.AddDelegate(value);
				}
				remove
				{
					PfnrdbYdSUQuINaDnsyoXhDfPmpt.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					ArFcvadhFuaKfZSnEGsjSJOShNKN.AddDelegate(value);
				}
				remove
				{
					ArFcvadhFuaKfZSnEGsjSJOShNKN.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, rTFRhglKgUYuRjbuHfpVdAGUmulr P_1, ControllerMapLayoutManager.nwmaXXBRLHdsFSHrcaeHCCJdihJCc P_2, ControllerMapEnabler.bfKxbNaTbdokMFkgReyogCBTNRVl P_3)
			{
				TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
				EVSYfBRoRmlZGWzbtVEKHpHdIHIm = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				QWmExxfHwSKcZBfRpLiNncXzNbPS = new IeLBOIaMcgdDkrPSUjVKJmcCVPTh(4);
				QWmExxfHwSKcZBfRpLiNncXzNbPS.QJWXdgrgJOldCwgJHcUABiRFVvoo(0, ControllerType.Joystick, new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>());
				QWmExxfHwSKcZBfRpLiNncXzNbPS.QJWXdgrgJOldCwgJHcUABiRFVvoo(1, ControllerType.Keyboard, new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Keyboard, KeyboardMap>());
				QWmExxfHwSKcZBfRpLiNncXzNbPS.QJWXdgrgJOldCwgJHcUABiRFVvoo(2, ControllerType.Mouse, new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Mouse, MouseMap>());
				QWmExxfHwSKcZBfRpLiNncXzNbPS.QJWXdgrgJOldCwgJHcUABiRFVvoo(3, ControllerType.Custom, new WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>());
				boNSEKuFFoQzYuEJbTHAMBvFjgjG = new NMuECpOqnCZghHDQvwyeWgvyRblU(P_0);
				poHBjfNcWvllzJNNsERwbrPxRXyc = new ozJCNCgYiYUtKitDXELFzszuhHbtA(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return (T)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(DXYiJElpUHxcPboaihvPaElwMWxMA.MXBTEGohIsfZjKPxjsPkPtPwYYfA<T>()).BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType).BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return (T)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(DXYiJElpUHxcPboaihvPaElwMWxMA.MXBTEGohIsfZjKPxjsPkPtPwYYfA<T>()).nOkTvbQKSHGWxOmobkZjUjbFejHs(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(controllerType).nOkTvbQKSHGWxOmobkZjUjbFejHs(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					zATZtKwijtiXAsAuMoaoeUTntTAC(controllerId, removeFromOtherPlayers);
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
					hhPdXeFwCFVkagwuxTRKvKHhjTMTA(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						zATZtKwijtiXAsAuMoaoeUTntTAC(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						hhPdXeFwCFVkagwuxTRKvKHhjTMTA(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					zATZtKwijtiXAsAuMoaoeUTntTAC(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
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
					hhPdXeFwCFVkagwuxTRKvKHhjTMTA(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					BLeFCCClaKSzNNgDflPvlbiyZIQM(controllerId);
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
					jSFqOYETANyBAUjypvvlDmVpEDmD(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					BLeFCCClaKSzNNgDflPvlbiyZIQM(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					jSFqOYETANyBAUjypvvlDmVpEDmD(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						BLeFCCClaKSzNNgDflPvlbiyZIQM(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						jSFqOYETANyBAUjypvvlDmVpEDmD(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return GGdAnaCXnyHOgPTuPgvpCHWGGAfT;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return jWlTboEMHXFauyXfleHJQTsTEibQ;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick).kUiCmZCewQfczGBdspnXBabLzrLy(controllerId), 
					ControllerType.Keyboard => GGdAnaCXnyHOgPTuPgvpCHWGGAfT, 
					ControllerType.Mouse => jWlTboEMHXFauyXfleHJQTsTEibQ, 
					ControllerType.Custom => QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom).kUiCmZCewQfczGBdspnXBabLzrLy(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					vJmyjEBxExTFYxcVkfmapRmzKGFl();
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
					UZfVsmKnKptQSDpQfiJwVzhrmyVv();
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					vJmyjEBxExTFYxcVkfmapRmzKGFl();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					UZfVsmKnKptQSDpQfiJwVzhrmyVv();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				vJmyjEBxExTFYxcVkfmapRmzKGFl();
				UZfVsmKnKptQSDpQfiJwVzhrmyVv();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				iWBVZyVWidBEOiapZFaTnShztHlW(ControllerType.Joystick, ref result, ref num);
				if (jWlTboEMHXFauyXfleHJQTsTEibQ && PqukyquTQsfWDwVhQpDSrQarkgvg > num)
				{
					result = Mouse;
					num = PqukyquTQsfWDwVhQpDSrQarkgvg;
				}
				if (GGdAnaCXnyHOgPTuPgvpCHWGGAfT && XpGVkAfRVRBitzxQZOkcTpNQdlVKA > num)
				{
					result = Keyboard;
					num = XpGVkAfRVRBitzxQZOkcTpNQdlVKA;
				}
				iWBVZyVWidBEOiapZFaTnShztHlW(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					iWBVZyVWidBEOiapZFaTnShztHlW(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (GGdAnaCXnyHOgPTuPgvpCHWGGAfT && XpGVkAfRVRBitzxQZOkcTpNQdlVKA > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (jWlTboEMHXFauyXfleHJQTsTEibQ && PqukyquTQsfWDwVhQpDSrQarkgvg > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void iWBVZyVWidBEOiapZFaTnShztHlW(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
				int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				for (int i = 0; i < num; i++)
				{
					double num2 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).uGwfwPDkEJpdKZnZXuVKrawXgwbL;
					if (!(num2 <= P_2))
					{
						P_1 = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).NlFnBAIUQPMwtvacPcDKoOszCbeW;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(DXYiJElpUHxcPboaihvPaElwMWxMA.MXBTEGohIsfZjKPxjsPkPtPwYYfA<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.seOLgneYbXEgZXaAbbHCDgUxbVJlA(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.seOLgneYbXEgZXaAbbHCDgUxbVJlA(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.wZhqKwEuhTOxaksFvBZVcwiARRaN(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.wZhqKwEuhTOxaksFvBZVcwiARRaN(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.RfrIJnQlYqBtRxmhlHtbKUtvakBoA(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
				{
					Controller controller = RJqXuiLyQfGOsWOjSUhsRPkUIhGM(QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i).qwgjCbRzxrpcbcpGuDjyBQzIUaDs, Controller.dFkVXhAFwrQgvJljPtxUJDLIqhzH, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				int mueqHgIkLYeeWIkgOmnbTNFVJkWJ = QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				for (int i = 0; i < mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
				{
					Controller controller = RJqXuiLyQfGOsWOjSUhsRPkUIhGM(QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i).qwgjCbRzxrpcbcpGuDjyBQzIUaDs, Controller.NfNTreNAWxuYBJmtoEPkaJedDOZb, templateType);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return poHBjfNcWvllzJNNsERwbrPxRXyc.tWtWyiwhraIpSCZoPgyYnIEdINde<TInterface>();
			}

			private Controller RJqXuiLyQfGOsWOjSUhsRPkUIhGM<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
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
					if (GGdAnaCXnyHOgPTuPgvpCHWGGAfT && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (jWlTboEMHXFauyXfleHJQTsTEibQ && P_1(Mouse, P_2))
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

			internal void gUxczTgMdKUcYRnCXamteWaCXJodc()
			{
				for (int i = 0; i < QWmExxfHwSKcZBfRpLiNncXzNbPS.mueqHgIkLYeeWIkgOmnbTNFVJkWJ; i++)
				{
					QWmExxfHwSKcZBfRpLiNncXzNbPS.hxBYYsnPbJHHRUcGFZWKtdBDPbOO(i).HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				}
				QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Keyboard).CcUGCZEweDezQjHrSyWovXsLGcbg(new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Keyboard, KeyboardMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF(ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.ZvUlvpaVsbPQTtRuvnrrPLgdkCtF, new gQqXfkghDzUgcWaoRfIdjveCqyDU<KeyboardMap>(0)));
				QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Mouse).CcUGCZEweDezQjHrSyWovXsLGcbg(new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Mouse, MouseMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF(ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.yBqJFIogVEdRIuiInajAqimbcbNA, new gQqXfkghDzUgcWaoRfIdjveCqyDU<MouseMap>(0)));
				boNSEKuFFoQzYuEJbTHAMBvFjgjG.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				XpGVkAfRVRBitzxQZOkcTpNQdlVKA = 0.0;
				PqukyquTQsfWDwVhQpDSrQarkgvg = 0.0;
				maps.gUxczTgMdKUcYRnCXamteWaCXJodc();
			}

			internal double zIQGyACPBFeXjpPgLmNEBPgviprRA(int P_0)
			{
				return boNSEKuFFoQzYuEJbTHAMBvFjgjG.qvSSugCCSQvBSEBLimOCnZkOkXpP(P_0)?.LGHGvxJRMFevzDjAkzcZGueGpawVA ?? (-1.0);
			}

			internal void zATZtKwijtiXAsAuMoaoeUTntTAC(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick);
				if (sXCOzPpaBVgCpGDHSTAYSkvnQSpe.kUiCmZCewQfczGBdspnXBabLzrLy(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				NMuECpOqnCZghHDQvwyeWgvyRblU.tOpMLMVaYQCkprKEImznVyIboOKw tOpMLMVaYQCkprKEImznVyIboOKw = boNSEKuFFoQzYuEJbTHAMBvFjgjG.qvSSugCCSQvBSEBLimOCnZkOkXpP(P_0.id);
				WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF xlqldUOnPwEDWvojhDbBMGKeZXpF;
				if (tOpMLMVaYQCkprKEImznVyIboOKw != null && tOpMLMVaYQCkprKEImznVyIboOKw.TptZzDLPedINfuoxMyhBGLwShqDI != null)
				{
					xlqldUOnPwEDWvojhDbBMGKeZXpF = new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF(P_0, tOpMLMVaYQCkprKEImznVyIboOKw.TptZzDLPedINfuoxMyhBGLwShqDI);
				}
				else
				{
					gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap> gQqXfkghDzUgcWaoRfIdjveCqyDU2 = maps.oAyGefUjvpvpXDYPIMINXrcNwJG(P_0, true);
					if (gQqXfkghDzUgcWaoRfIdjveCqyDU2 == null)
					{
						gQqXfkghDzUgcWaoRfIdjveCqyDU2 = new gQqXfkghDzUgcWaoRfIdjveCqyDU<JoystickMap>(P_0.id);
					}
					xlqldUOnPwEDWvojhDbBMGKeZXpF = new WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF(P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU2);
				}
				sXCOzPpaBVgCpGDHSTAYSkvnQSpe.CcUGCZEweDezQjHrSyWovXsLGcbg(xlqldUOnPwEDWvojhDbBMGKeZXpF);
				boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(xlqldUOnPwEDWvojhDbBMGKeZXpF);
				poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(P_0);
				maps.layoutManager.Apply();
				if (PfnrdbYdSUQuINaDnsyoXhDfPmpt.Count > 0)
				{
					PfnrdbYdSUQuINaDnsyoXhDfPmpt.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void zATZtKwijtiXAsAuMoaoeUTntTAC(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					zATZtKwijtiXAsAuMoaoeUTntTAC(joystick, P_1);
				}
			}

			internal void BLeFCCClaKSzNNgDflPvlbiyZIQM(int P_0)
			{
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick);
				if (sXCOzPpaBVgCpGDHSTAYSkvnQSpe.kUiCmZCewQfczGBdspnXBabLzrLy(P_0))
				{
					if (sXCOzPpaBVgCpGDHSTAYSkvnQSpe.USCGiuQyHUkFhIyPnQnjKGLOTfzD(P_0) is WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF xlqldUOnPwEDWvojhDbBMGKeZXpF)
					{
						boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(xlqldUOnPwEDWvojhDbBMGKeZXpF);
					}
					sXCOzPpaBVgCpGDHSTAYSkvnQSpe.vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(joystick);
					if (ArFcvadhFuaKfZSnEGsjSJOShNKN.Count > 0)
					{
						ArFcvadhFuaKfZSnEGsjSJOShNKN.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void BLeFCCClaKSzNNgDflPvlbiyZIQM(Joystick P_0)
			{
				if (P_0 != null)
				{
					BLeFCCClaKSzNNgDflPvlbiyZIQM(P_0.id);
				}
			}

			internal void vJmyjEBxExTFYxcVkfmapRmzKGFl()
			{
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Joystick);
				for (int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ - 1; num >= 0; num--)
				{
					boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num) as WFpJqeQluRdrTsObLAtdFlaFHUgWA<Joystick, JoystickMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF);
					poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW);
					int id = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW.id;
					sXCOzPpaBVgCpGDHSTAYSkvnQSpe.WuiyfDSveVmGESDBZkyAfcQMggwx(num);
					if (ArFcvadhFuaKfZSnEGsjSJOShNKN.Count > 0)
					{
						ArFcvadhFuaKfZSnEGsjSJOShNKN.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, id, ControllerType.Joystick, false));
					}
				}
				sXCOzPpaBVgCpGDHSTAYSkvnQSpe.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			}

			internal void hhPdXeFwCFVkagwuxTRKvKHhjTMTA(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom);
				if (!sXCOzPpaBVgCpGDHSTAYSkvnQSpe.kUiCmZCewQfczGBdspnXBabLzrLy(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					gQqXfkghDzUgcWaoRfIdjveCqyDU<CustomControllerMap> gQqXfkghDzUgcWaoRfIdjveCqyDU2 = maps.zXZqXzVDvNjfAjPKxPibqLSWVHlk(P_0, true);
					if (gQqXfkghDzUgcWaoRfIdjveCqyDU2 == null)
					{
						gQqXfkghDzUgcWaoRfIdjveCqyDU2 = new gQqXfkghDzUgcWaoRfIdjveCqyDU<CustomControllerMap>(P_0.id);
					}
					WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF xlqldUOnPwEDWvojhDbBMGKeZXpF = new WFpJqeQluRdrTsObLAtdFlaFHUgWA<CustomController, CustomControllerMap>.XlqldUOnPwEDWvojhDbBMGKeZXpF(P_0, gQqXfkghDzUgcWaoRfIdjveCqyDU2);
					sXCOzPpaBVgCpGDHSTAYSkvnQSpe.CcUGCZEweDezQjHrSyWovXsLGcbg(xlqldUOnPwEDWvojhDbBMGKeZXpF);
					poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(P_0);
					maps.layoutManager.Apply();
					if (PfnrdbYdSUQuINaDnsyoXhDfPmpt.Count > 0)
					{
						PfnrdbYdSUQuINaDnsyoXhDfPmpt.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void hhPdXeFwCFVkagwuxTRKvKHhjTMTA(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					hhPdXeFwCFVkagwuxTRKvKHhjTMTA(customController, P_1);
				}
			}

			internal void jSFqOYETANyBAUjypvvlDmVpEDmD(int P_0)
			{
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom);
				if (sXCOzPpaBVgCpGDHSTAYSkvnQSpe.kUiCmZCewQfczGBdspnXBabLzrLy(P_0))
				{
					sXCOzPpaBVgCpGDHSTAYSkvnQSpe.USCGiuQyHUkFhIyPnQnjKGLOTfzD(P_0);
					sXCOzPpaBVgCpGDHSTAYSkvnQSpe.vTTGlUJsIZEYJJmZLyYCiUGZmgUiA(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(customController);
					if (ArFcvadhFuaKfZSnEGsjSJOShNKN.Count > 0)
					{
						ArFcvadhFuaKfZSnEGsjSJOShNKN.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void jSFqOYETANyBAUjypvvlDmVpEDmD(CustomController P_0)
			{
				if (P_0 != null)
				{
					jSFqOYETANyBAUjypvvlDmVpEDmD(P_0.id);
				}
			}

			internal void UZfVsmKnKptQSDpQfiJwVzhrmyVv()
			{
				SXCOzPpaBVgCpGDHSTAYSkvnQSpe sXCOzPpaBVgCpGDHSTAYSkvnQSpe = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Custom);
				for (int num = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.mueqHgIkLYeeWIkgOmnbTNFVJkWJ - 1; num >= 0; num--)
				{
					poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW);
					int id = sXCOzPpaBVgCpGDHSTAYSkvnQSpe.wBgVECvNnnPzuAKlDGDoAWwKEEhT(num).NlFnBAIUQPMwtvacPcDKoOszCbeW.id;
					sXCOzPpaBVgCpGDHSTAYSkvnQSpe.WuiyfDSveVmGESDBZkyAfcQMggwx(num);
					if (ArFcvadhFuaKfZSnEGsjSJOShNKN.Count > 0)
					{
						ArFcvadhFuaKfZSnEGsjSJOShNKN.Invoke(new ControllerAssignmentChangedEventArgs(EVSYfBRoRmlZGWzbtVEKHpHdIHIm.id, id, ControllerType.Custom, false));
					}
				}
				sXCOzPpaBVgCpGDHSTAYSkvnQSpe.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			}

			internal CustomController eiZBKaQajfzCsvOZQPpHqLgKHDPAA(int P_0)
			{
				CustomController customController = EVSYfBRoRmlZGWzbtVEKHpHdIHIm.inUOqNgJETupWWjKfbAYdNjpQXjNA.eiZBKaQajfzCsvOZQPpHqLgKHDPAA(P_0);
				if (customController == null)
				{
					return null;
				}
				hhPdXeFwCFVkagwuxTRKvKHhjTMTA(customController, false);
				return customController;
			}

			internal void PlFBNAjCNTWRECIVqiIHVkQyHLgYA(Action<bool, int, int> P_0)
			{
				QvrEnaETRBmpgYqffMRsfybiCHlL<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void udeqtaQvveMctPjzIohkHolDJZEK(Keyboard P_0, BxbbvKXhLYllwMlNukVwsgZhBIs P_1, Action<bool, int, int> P_2)
			{
				if (!GGdAnaCXnyHOgPTuPgvpCHWGGAfT || !P_0.enabled)
				{
					return;
				}
				apEvzhCxScCyCSOHWwpxJiwGvlOo oFeUqmJOHJUglpytNJpnwvLOYyjD = HuFUPnVcilGVsLkOQFTNYtvJAVLr.OFeUqmJOHJUglpytNJpnwvLOYyjD;
				bool flag = false;
				GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Keyboard).USCGiuQyHUkFhIyPnQnjKGLOTfzD(0).TptZzDLPedINfuoxMyhBGLwShqDI;
				int num = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.fHfLawVRnAIjFLcvXQTtiXDuzgak;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						bool num2 = actionElementMap._modifierKey1 != ModifierKey.None || actionElementMap._modifierKey2 != ModifierKey.None || actionElementMap._modifierKey3 != ModifierKey.None;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						bool flag2 = false;
						ModifierKeyFlags modifierKeyFlags;
						xiZMFJaKprrLjxtEMQahBCVGvYER xiZMFJaKprrLjxtEMQahBCVGvYER2;
						if (num2)
						{
							modifierKeyFlags = actionElementMap.modifierKeyFlags;
							if (P_0.adWmGbiOufRWIJOuXfEhtFDuBHOA(keyboardKeyCode, modifierKeyFlags))
							{
								if (!P_1.dCKIupBMxKqhLvPdSVYDavTVKoCz(keyboardKeyCode, modifierKeyFlags))
								{
									xiZMFJaKprrLjxtEMQahBCVGvYER2 = xiZMFJaKprrLjxtEMQahBCVGvYER.jodeWACReFvZpoQyUvqnhZRwyafZ(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
									xiZMFJaKprrLjxtEMQahBCVGvYER2.AOPGPeIJDRnFsspPPHHIIysuRBXlA(ReInput.currentUpdateLoop, true);
									flag2 = true;
									goto IL_0119;
								}
							}
							else
							{
								xiZMFJaKprrLjxtEMQahBCVGvYER2 = xiZMFJaKprrLjxtEMQahBCVGvYER.ogSoWIxzvUDUVzjUjkNpiqjoeECDA(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
								if (xiZMFJaKprrLjxtEMQahBCVGvYER2 != null)
								{
									goto IL_0119;
								}
							}
							goto IL_0170;
						}
						modifierKeyFlags = ModifierKeyFlags.None;
						ButtonStateFlags buttonStateFlags = P_0.UZVGEYSBDBxHaOdubTHSxJdnGrbt(actionElementMap.UxnXexdLmPFrOAXyWtEwqWmaGYzH);
						goto IL_0137;
						IL_0137:
						if (buttonStateFlags != ButtonStateFlags.Off && (flag2 || !P_1.dCKIupBMxKqhLvPdSVYDavTVKoCz(keyboardKeyCode, modifierKeyFlags)))
						{
							trEbujEKCtKmzuNkvEIILTyZypQhA(P_0, keyboardMap, actionElementMap, oFeUqmJOHJUglpytNJpnwvLOYyjD, buttonStateFlags);
							P_2(arg1: true, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId);
							flag = true;
							continue;
						}
						goto IL_0170;
						IL_0119:
						buttonStateFlags = xiZMFJaKprrLjxtEMQahBCVGvYER2.KOonZeRJAKnjZeFdpIRXKghDSnUW(true);
						goto IL_0137;
						IL_0170:
						if (oFeUqmJOHJUglpytNJpnwvLOYyjD.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA != 0f)
						{
							oFeUqmJOHJUglpytNJpnwvLOYyjD.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
						}
						if (oFeUqmJOHJUglpytNJpnwvLOYyjD.TlaqgRjZoXTHZctfJfQNHFcpcgkiA != ButtonStateFlags.Off)
						{
							oFeUqmJOHJUglpytNJpnwvLOYyjD.TlaqgRjZoXTHZctfJfQNHFcpcgkiA = ButtonStateFlags.Off;
						}
						P_2(arg1: false, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId);
					}
				}
				if (flag)
				{
					XpGVkAfRVRBitzxQZOkcTpNQdlVKA = ReInput.unscaledTime;
				}
			}

			private static void trEbujEKCtKmzuNkvEIILTyZypQhA(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, apEvzhCxScCyCSOHWwpxJiwGvlOo P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = num;
				P_3.TlaqgRjZoXTHZctfJfQNHFcpcgkiA = P_4;
				P_3.NlFnBAIUQPMwtvacPcDKoOszCbeW = P_0;
				P_3.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = ControllerType.Keyboard;
				P_3.HdUojRicHUlIpCmGkuawfkOvHDMt = ControllerElementType.Button;
				P_3.JkHyuiFgCXoofKLRpBbmEBHplCHc = P_2;
				P_3.bCyRjgRlhEVQenEXvcdthvtYiSbS = P_1;
				if (P_3.MTBSIFqhnKFvwdHvcsxlkEEenegt)
				{
					P_3.MTBSIFqhnKFvwdHvcsxlkEEenegt = false;
				}
				if (P_3.jOVOQeWSEfyXonPsrDrEkEafiRYjA)
				{
					P_3.jOVOQeWSEfyXonPsrDrEkEafiRYjA = false;
				}
			}

			internal void nUIrOpOZVYPmPcGzbrdcEqVHBGQgA(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!jWlTboEMHXFauyXfleHJQTsTEibQ || !P_0.enabled)
				{
					return;
				}
				GNnLMzlpRKtFyJlexoafWNjfiSkf gNnLMzlpRKtFyJlexoafWNjfiSkf = QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(ControllerType.Mouse).USCGiuQyHUkFhIyPnQnjKGLOTfzD(0).TptZzDLPedINfuoxMyhBGLwShqDI;
				apEvzhCxScCyCSOHWwpxJiwGvlOo oFeUqmJOHJUglpytNJpnwvLOYyjD = HuFUPnVcilGVsLkOQFTNYtvJAVLr.OFeUqmJOHJUglpytNJpnwvLOYyjD;
				bool flag = false;
				int num = gNnLMzlpRKtFyJlexoafWNjfiSkf.mueqHgIkLYeeWIkgOmnbTNFVJkWJ;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)gNnLMzlpRKtFyJlexoafWNjfiSkf.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.GPlzLcAOtWAUBGwtdgGxSZUwAxXqA;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.tdwRMoEqKHSujkiiWAstXtSvQagE(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.tdwRMoEqKHSujkiiWAstXtSvQagE(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId);
									continue;
								}
							}
							oFeUqmJOHJUglpytNJpnwvLOYyjD.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = num2;
							oFeUqmJOHJUglpytNJpnwvLOYyjD.NlFnBAIUQPMwtvacPcDKoOszCbeW = P_0;
							oFeUqmJOHJUglpytNJpnwvLOYyjD.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = ControllerType.Mouse;
							oFeUqmJOHJUglpytNJpnwvLOYyjD.HdUojRicHUlIpCmGkuawfkOvHDMt = ControllerElementType.Axis;
							oFeUqmJOHJUglpytNJpnwvLOYyjD.JkHyuiFgCXoofKLRpBbmEBHplCHc = actionElementMap;
							oFeUqmJOHJUglpytNJpnwvLOYyjD.bCyRjgRlhEVQenEXvcdthvtYiSbS = mouseMap;
							if (oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA)
							{
								oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA = false;
							}
							if (oFeUqmJOHJUglpytNJpnwvLOYyjD.RhXowIZXszdLMoQbhhfmCCkDJqne != AxisCoordinateMode.Relative)
							{
								oFeUqmJOHJUglpytNJpnwvLOYyjD.RhXowIZXszdLMoQbhhfmCCkDJqne = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.fHfLawVRnAIjFLcvXQTtiXDuzgak;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.VSiihPxGuiGUWdrCYhBKGgUwyktU(actionElementMap2, actionId2, out var pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, out oFeUqmJOHJUglpytNJpnwvLOYyjD.MTBSIFqhnKFvwdHvcsxlkEEenegt))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.UZVGEYSBDBxHaOdubTHSxJdnGrbt(actionElementMap2.UxnXexdLmPFrOAXyWtEwqWmaGYzH);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId2);
							continue;
						}
						oFeUqmJOHJUglpytNJpnwvLOYyjD.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
						oFeUqmJOHJUglpytNJpnwvLOYyjD.TlaqgRjZoXTHZctfJfQNHFcpcgkiA = buttonStateFlags;
						oFeUqmJOHJUglpytNJpnwvLOYyjD.NlFnBAIUQPMwtvacPcDKoOszCbeW = P_0;
						oFeUqmJOHJUglpytNJpnwvLOYyjD.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = ControllerType.Mouse;
						oFeUqmJOHJUglpytNJpnwvLOYyjD.HdUojRicHUlIpCmGkuawfkOvHDMt = ControllerElementType.Button;
						oFeUqmJOHJUglpytNJpnwvLOYyjD.JkHyuiFgCXoofKLRpBbmEBHplCHc = actionElementMap2;
						oFeUqmJOHJUglpytNJpnwvLOYyjD.bCyRjgRlhEVQenEXvcdthvtYiSbS = mouseMap;
						if (oFeUqmJOHJUglpytNJpnwvLOYyjD.MTBSIFqhnKFvwdHvcsxlkEEenegt)
						{
							oFeUqmJOHJUglpytNJpnwvLOYyjD.MTBSIFqhnKFvwdHvcsxlkEEenegt = false;
						}
						if (oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA)
						{
							oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA = false;
						}
						P_1(arg1: true, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					PqukyquTQsfWDwVhQpDSrQarkgvg = ReInput.unscaledTime;
				}
			}

			internal void ZjOEKgUNGspsGGDiCATLelCyJLFdb(Action<bool, int, int> P_0)
			{
				QvrEnaETRBmpgYqffMRsfybiCHlL<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void QvrEnaETRBmpgYqffMRsfybiCHlL<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				WFpJqeQluRdrTsObLAtdFlaFHUgWA<_0001, _0002> wFpJqeQluRdrTsObLAtdFlaFHUgWA = (WFpJqeQluRdrTsObLAtdFlaFHUgWA<_0001, _0002>)QWmExxfHwSKcZBfRpLiNncXzNbPS.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(P_0);
				apEvzhCxScCyCSOHWwpxJiwGvlOo oFeUqmJOHJUglpytNJpnwvLOYyjD = HuFUPnVcilGVsLkOQFTNYtvJAVLr.OFeUqmJOHJUglpytNJpnwvLOYyjD;
				int num = wFpJqeQluRdrTsObLAtdFlaFHUgWA.uOrObmhYSFFSSYAgXWUdMpLCHkkc();
				for (int i = 0; i < num; i++)
				{
					WFpJqeQluRdrTsObLAtdFlaFHUgWA<_0001, _0002>.XlqldUOnPwEDWvojhDbBMGKeZXpF xlqldUOnPwEDWvojhDbBMGKeZXpF = wFpJqeQluRdrTsObLAtdFlaFHUgWA.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i);
					_0001 nlFnBAIUQPMwtvacPcDKoOszCbeW = xlqldUOnPwEDWvojhDbBMGKeZXpF.NlFnBAIUQPMwtvacPcDKoOszCbeW;
					if (!nlFnBAIUQPMwtvacPcDKoOszCbeW.enabled)
					{
						continue;
					}
					gQqXfkghDzUgcWaoRfIdjveCqyDU<_0002> tptZzDLPedINfuoxMyhBGLwShqDI = xlqldUOnPwEDWvojhDbBMGKeZXpF.TptZzDLPedINfuoxMyhBGLwShqDI;
					bool flag = false;
					int num2 = tptZzDLPedINfuoxMyhBGLwShqDI.uOrObmhYSFFSSYAgXWUdMpLCHkkc();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = tptZzDLPedINfuoxMyhBGLwShqDI.wBgVECvNnnPzuAKlDGDoAWwKEEhT(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.GPlzLcAOtWAUBGwtdgGxSZUwAxXqA;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!nlFnBAIUQPMwtvacPcDKoOszCbeW.tdwRMoEqKHSujkiiWAstXtSvQagE(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									nlFnBAIUQPMwtvacPcDKoOszCbeW.tdwRMoEqKHSujkiiWAstXtSvQagE(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId);
										continue;
									}
								}
								oFeUqmJOHJUglpytNJpnwvLOYyjD.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = num3;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.NlFnBAIUQPMwtvacPcDKoOszCbeW = nlFnBAIUQPMwtvacPcDKoOszCbeW;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = P_0;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.HdUojRicHUlIpCmGkuawfkOvHDMt = ControllerElementType.Axis;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.JkHyuiFgCXoofKLRpBbmEBHplCHc = actionElementMap;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.bCyRjgRlhEVQenEXvcdthvtYiSbS = val;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA = nlFnBAIUQPMwtvacPcDKoOszCbeW.calibrationMap.Axes[actionElementMap.UxnXexdLmPFrOAXyWtEwqWmaGYzH].applyRangeCalibration;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.RhXowIZXszdLMoQbhhfmCCkDJqne = nlFnBAIUQPMwtvacPcDKoOszCbeW.Axes[actionElementMap.elementIndex].LCaxfXkPMXiCslbaIiVAoElQhhmD?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.fHfLawVRnAIjFLcvXQTtiXDuzgak;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
								int uxnXexdLmPFrOAXyWtEwqWmaGYzH = actionElementMap2.UxnXexdLmPFrOAXyWtEwqWmaGYzH;
								if (!rqtnLNZhFnXlOElwWRYTZPIFKmcw(nlFnBAIUQPMwtvacPcDKoOszCbeW, i, uxnXexdLmPFrOAXyWtEwqWmaGYzH, actionElementMap2, tptZzDLPedINfuoxMyhBGLwShqDI, actionId2, ref pWbMhcBQKZEHHDwvEOhqpAUJhzfpA) && !nlFnBAIUQPMwtvacPcDKoOszCbeW.VSiihPxGuiGUWdrCYhBKGgUwyktU(actionElementMap2, actionId2, out pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, out oFeUqmJOHJUglpytNJpnwvLOYyjD.MTBSIFqhnKFvwdHvcsxlkEEenegt))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = nlFnBAIUQPMwtvacPcDKoOszCbeW.UZVGEYSBDBxHaOdubTHSxJdnGrbt(actionElementMap2.UxnXexdLmPFrOAXyWtEwqWmaGYzH);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId2);
									continue;
								}
								oFeUqmJOHJUglpytNJpnwvLOYyjD.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.TlaqgRjZoXTHZctfJfQNHFcpcgkiA = buttonStateFlags;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.NlFnBAIUQPMwtvacPcDKoOszCbeW = nlFnBAIUQPMwtvacPcDKoOszCbeW;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.qwgjCbRzxrpcbcpGuDjyBQzIUaDs = P_0;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.HdUojRicHUlIpCmGkuawfkOvHDMt = ControllerElementType.Button;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.JkHyuiFgCXoofKLRpBbmEBHplCHc = actionElementMap2;
								oFeUqmJOHJUglpytNJpnwvLOYyjD.bCyRjgRlhEVQenEXvcdthvtYiSbS = val;
								if (oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA)
								{
									oFeUqmJOHJUglpytNJpnwvLOYyjD.jOVOQeWSEfyXonPsrDrEkEafiRYjA = false;
								}
								P_1(arg1: true, EVSYfBRoRmlZGWzbtVEKHpHdIHIm.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							xlqldUOnPwEDWvojhDbBMGKeZXpF.bUMuJaeQqjFBSNrQicyffpOEtQCw();
						}
					}
				}
			}

			private bool rqtnLNZhFnXlOElwWRYTZPIFKmcw<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.WlduKdCdymfJzhLxPcswpRugJOzgb.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.WlduKdCdymfJzhLxPcswpRugJOzgb.GetUnknownHatButtons(P_2);
				if (ffBVWsEbzDTqikoaYuxUNIMbVpkO(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.VSiihPxGuiGUWdrCYhBKGgUwyktU(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool ffBVWsEbzDTqikoaYuxUNIMbVpkO<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (vTpmQynrMQvibuWotGMiktbiRovA(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool vTpmQynrMQvibuWotGMiktbiRovA<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, gQqXfkghDzUgcWaoRfIdjveCqyDU<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.uOrObmhYSFFSSYAgXWUdMpLCHkkc();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.wBgVECvNnnPzuAKlDGDoAWwKEEhT(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int uxnXexdLmPFrOAXyWtEwqWmaGYzH = buttonMaps[j].UxnXexdLmPFrOAXyWtEwqWmaGYzH;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(uxnXexdLmPFrOAXyWtEwqWmaGYzH))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private readonly sQUhNuelsgdElREOuzBUnZbPDjkc inUOqNgJETupWWjKfbAYdNjpQXjNA;

		private bool UokItRMIjdQDKoBLDHTyGiBLdwFi;

		private int HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

		private string gbaFwplwRPDIuUufIuWmknaoIHDK;

		private string TmIuKcqmfrQpAERlXCtnNqgermxE;

		private bool ncdeijtAGZWOXJkaRjWdEzQdLQeX;

		private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
			}
			internal set
			{
				HZrDwOTOuvYGJkZRWDMDnUPlFNTs = hZrDwOTOuvYGJkZRWDMDnUPlFNTs;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return string.Empty;
				}
				return gbaFwplwRPDIuUufIuWmknaoIHDK;
			}
			internal set
			{
				gbaFwplwRPDIuUufIuWmknaoIHDK = text;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return string.Empty;
				}
				return TmIuKcqmfrQpAERlXCtnNqgermxE;
			}
			internal set
			{
				TmIuKcqmfrQpAERlXCtnNqgermxE = tmIuKcqmfrQpAERlXCtnNqgermxE;
			}
		}

		public bool isPlaying
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return ncdeijtAGZWOXJkaRjWdEzQdLQeX;
			}
			set
			{
				ncdeijtAGZWOXJkaRjWdEzQdLQeX = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, rTFRhglKgUYuRjbuHfpVdAGUmulr P_4, ControllerMapLayoutManager.nwmaXXBRLHdsFSHrcaeHCCJdihJCc P_5, ControllerMapEnabler.bfKxbNaTbdokMFkgReyogCBTNRVl P_6)
		{
			UokItRMIjdQDKoBLDHTyGiBLdwFi = P_0;
			HZrDwOTOuvYGJkZRWDMDnUPlFNTs = P_1;
			gbaFwplwRPDIuUufIuWmknaoIHDK = P_2;
			TmIuKcqmfrQpAERlXCtnNqgermxE = P_3;
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
			controllers = new ControllerHelper(this, P_4, P_5, P_6);
			inUOqNgJETupWWjKfbAYdNjpQXjNA = ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA;
			gUxczTgMdKUcYRnCXamteWaCXJodc();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(HZrDwOTOuvYGJkZRWDMDnUPlFNTs));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.PKxzXBSMXndnnwoVrPblHLVDZExv() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.PKxzXBSMXndnnwoVrPblHLVDZExv() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.WBIaBbghQpgzOEKyaCjXLOtiaWQP() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.WBIaBbghQpgzOEKyaCjXLOtiaWQP() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.mjQmQdEkqdYvFzOGOLRYyQYeGhCg() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.mjQmQdEkqdYvFzOGOLRYyQYeGhCg() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.BYuNmqXmcJEOqFjaSxNMkOUwwGWl() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.BYuNmqXmcJEOqFjaSxNMkOUwwGWl() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.YefNDmxYaFaOfckhdzXTHQWiUwIP() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.YefNDmxYaFaOfckhdzXTHQWiUwIP() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ZbZXwRDbpUbpKjPSFNzyAkHgzaVKB() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ZbZXwRDbpUbpKjPSFNzyAkHgzaVKB() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.QslgJubMTuHarludIYDjkIVdWerS() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.QslgJubMTuHarludIYDjkIVdWerS() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ExzCcLBqDxDpCccDPnSlIdKQoEOxA(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ExzCcLBqDxDpCccDPnSlIdKQoEOxA(speed) ?? false;
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.qLLgoCHAuTvEpknkLUncjRjpPpCPA(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.qLLgoCHAuTvEpknkLUncjRjpPpCPA(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.dIRAKDCSExHVTMEwLyuUgaSxPzmYA(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.dIRAKDCSExHVTMEwLyuUgaSxPzmYA(speed) ?? false;
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.MijQAzbgipqhmrRTMEAjRYehWkeS(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.MijQAzbgipqhmrRTMEAjRYehWkeS(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.MijQAzbgipqhmrRTMEAjRYehWkeS(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.MijQAzbgipqhmrRTMEAjRYehWkeS(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.OnVkLWxiYqOUxNEiNSRDGpDMlRXW(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.OnVkLWxiYqOUxNEiNSRDGpDMlRXW(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.FKIXfMMuStjlooachfgAhGsYeFxdA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.FKIXfMMuStjlooachfgAhGsYeFxdA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.FKIXfMMuStjlooachfgAhGsYeFxdA(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.FKIXfMMuStjlooachfgAhGsYeFxdA(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.XujDkxfqkqnIoHYvDKerQvlfvmkYA() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.XujDkxfqkqnIoHYvDKerQvlfvmkYA() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.GspCLfBRlvRsOJxFwoAeDebWMIwrA() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.GspCLfBRlvRsOJxFwoAeDebWMIwrA() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.eaNjLDcSHnFbCqctTYQcrKwgfyGlA() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.eaNjLDcSHnFbCqctTYQcrKwgfyGlA() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.NIoDqkKPjEoFxDUldIBBPhbfUQJKB() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.NIoDqkKPjEoFxDUldIBBPhbfUQJKB() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.EickhBxXSpLJmZfmCdxGysHgYJXu() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.EickhBxXSpLJmZfmCdxGysHgYJXu() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.EXdFXyZnCrhwMnlrmXSAPFUZVQyX() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.EXdFXyZnCrhwMnlrmXSAPFUZVQyX() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ddtetPkUaprMIuFlUQlSEQgCcCGx() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ddtetPkUaprMIuFlUQlSEQgCcCGx() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZlvhHCrmeggpCOfNIDXCQCunDzyG(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.JvCQEBnihGgWAAjTHDJxmlzweJXl(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.UPJyzJfSImIVFrUAgnlUdKEeyYFs(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZoallhXCnkkFstxNDrZMEEPwpCHQ(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.kKaUCxZhJdapkBzUcxWGoijaMqLGb() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.kKaUCxZhJdapkBzUcxWGoijaMqLGb() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.OhtneIzCDqXfuNzzZylFuTRKqweh() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.OhtneIzCDqXfuNzzZylFuTRKqweh() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ilFAZwkIaxHKmyAvsBXuJQNIEkYs() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ilFAZwkIaxHKmyAvsBXuJQNIEkYs() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.unhchykaxdiheOqgVQewBhsRIfZDA() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.unhchykaxdiheOqgVQewBhsRIfZDA() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.fFYMTDlJiVbySbkKFktNzGIHtFWr() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.fFYMTDlJiVbySbkKFktNzGIHtFWr() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.vZjFXFEfAwXLmGsqgVakMDqwjAqm() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.vZjFXFEfAwXLmGsqgVakMDqwjAqm() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.sSAcKCHLnzXXRUDysDovidHtMfIDA() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.sSAcKCHLnzXXRUDysDovidHtMfIDA() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.xPqNPIUyKmOkDxnElSvJUJmnqPx() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.xPqNPIUyKmOkDxnElSvJUJmnqPx() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.PSacIhqypanSwWLRlLNySDKJuXOi() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.PSacIhqypanSwWLRlLNySDKJuXOi() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.qPcUkEjeSlfflnmFngxJeNHykYzH(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.qPcUkEjeSlfflnmFngxJeNHykYzH(speed) ?? false;
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.qDrbhExdaMtikEgOjSQeXXgpcOE(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.qDrbhExdaMtikEgOjSQeXXgpcOE(speed) ?? false;
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.GtCARhmiIoXvysANTyjIfnagnZoV(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.GtCARhmiIoXvysANTyjIfnagnZoV(speed) ?? false;
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.LPlGqCDEjrLvrznYozZSKYQyLwZgA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.LPlGqCDEjrLvrznYozZSKYQyLwZgA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.LPlGqCDEjrLvrznYozZSKYQyLwZgA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.LPlGqCDEjrLvrznYozZSKYQyLwZgA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.mQrzgDhVvvDGCmvHktGucwxMaJWl(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.mQrzgDhVvvDGCmvHktGucwxMaJWl(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.lIQHAOspqBODIsDHNyDmBsnQWNEQ() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.lIQHAOspqBODIsDHNyDmBsnQWNEQ() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.IIGKRCnbezOzZtZctpspeCdMcGyh() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.IIGKRCnbezOzZtZctpspeCdMcGyh() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.JmphWjkypJvmbntpVBPMUvADBKVu() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.JmphWjkypJvmbntpVBPMUvADBKVu() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.OkilHHDaqVFWlDDtostqEcGEVAwAA() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.OkilHHDaqVFWlDDtostqEcGEVAwAA() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ZLGCVshBdxlKdulKDJOCVMHiBPyhb() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ZLGCVshBdxlKdulKDJOCVMHiBPyhb() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.RlPdEncQLrsGZBhKIQtgNrUbzrwX() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.RlPdEncQLrsGZBhKIQtgNrUbzrwX() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.nRtweucGmOdDTZEodSgPcojlorYW() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.nRtweucGmOdDTZEodSgPcojlorYW() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.nXelWkdvbdInWlBJkKFtBSczQyqT(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.zCvrNMlAaaEKYlmCVGMtYuQLoYCf(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.IesbutQVEpGxUrbMpdmhdfrpdEAs(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.IDeHUsbeAVYZrkJqVAIcAymjnCGpA(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.NreGZYDpIwKJFFCjzXwBDlXbsyuaA() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.NreGZYDpIwKJFFCjzXwBDlXbsyuaA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.NATzAVhLaNeKJjngavEgVgcCAjhSA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.NATzAVhLaNeKJjngavEgVgcCAjhSA() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.AcvdmOzScVMcmBUZvbBnEUPMUIFm() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.AcvdmOzScVMcmBUZvbBnEUPMUIFm() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.HqTUEvWMbnrGUEHWWUiDJMMFFUPo() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.HqTUEvWMbnrGUEHWWUiDJMMFFUPo() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.qMrEIVBOXEVidwZRmnJsHUjElcFG() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.qMrEIVBOXEVidwZRmnJsHUjElcFG() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ARqkTOKJToBnOJOxCZVrebmHrddFA() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ARqkTOKJToBnOJOxCZVrebmHrddFA() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.CllAsyZUJKwtqgDsmoSEQPEtzZgc() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.CllAsyZUJKwtqgDsmoSEQPEtzZgc() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.lgwUymtCKsIjYiLRmNXjaOAGppAYA() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.lgwUymtCKsIjYiLRmNXjaOAGppAYA() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.AcvdmOzScVMcmBUZvbBnEUPMUIFm();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.AcvdmOzScVMcmBUZvbBnEUPMUIFm();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.AcvdmOzScVMcmBUZvbBnEUPMUIFm();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.AcvdmOzScVMcmBUZvbBnEUPMUIFm();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.qMrEIVBOXEVidwZRmnJsHUjElcFG();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.qMrEIVBOXEVidwZRmnJsHUjElcFG();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.qMrEIVBOXEVidwZRmnJsHUjElcFG();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.qMrEIVBOXEVidwZRmnJsHUjElcFG();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.HqTUEvWMbnrGUEHWWUiDJMMFFUPo();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.HqTUEvWMbnrGUEHWWUiDJMMFFUPo();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.HqTUEvWMbnrGUEHWWUiDJMMFFUPo();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.HqTUEvWMbnrGUEHWWUiDJMMFFUPo();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.ARqkTOKJToBnOJOxCZVrebmHrddFA();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionName, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.ARqkTOKJToBnOJOxCZVrebmHrddFA();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, xAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.x = huFUPnVcilGVsLkOQFTNYtvJAVLr.ARqkTOKJToBnOJOxCZVrebmHrddFA();
			}
			huFUPnVcilGVsLkOQFTNYtvJAVLr = inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, yAxisActionId, true);
			if (huFUPnVcilGVsLkOQFTNYtvJAVLr != null)
			{
				result.y = huFUPnVcilGVsLkOQFTNYtvJAVLr.ARqkTOKJToBnOJOxCZVrebmHrddFA();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ZjbiUaIRTyNDkZWLNzBGgFdratSI() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ZjbiUaIRTyNDkZWLNzBGgFdratSI() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.VhPmGEPUpbTBQGqXfbGDkwRUotxR() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.VhPmGEPUpbTBQGqXfbGDkwRUotxR() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.KZRfFGjixsSnxYJAdiWaARhtVuoh() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.KZRfFGjixsSnxYJAdiWaARhtVuoh() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.ADjNgNvqOyPofYrVzKcEWCAdlwEw() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.ADjNgNvqOyPofYrVzKcEWCAdlwEw() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.AxZtHedypmAohTRRWAUAOcTwrRrR() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.AxZtHedypmAohTRRWAUAOcTwrRrR() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.vjbBgkjnTWudJfIykEIacpReYQZQB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.vjbBgkjnTWudJfIykEIacpReYQZQB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.qBNYDeVHZwgZzAdiNtmDFbgTiPysA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.qBNYDeVHZwgZzAdiNtmDFbgTiPysA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.KhnXrfljsXCjgbYlebvmBTCekgGtA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return AxisCoordinateMode.Absolute;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.KhnXrfljsXCjgbYlebvmBTCekgGtA() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.eWtqIheNhXRbhUtxauGdKrtxgDin();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.eWtqIheNhXRbhUtxauGdKrtxgDin();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionName, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return inUOqNgJETupWWjKfbAYdNjpQXjNA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionId, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.abWrLiCkIBdlWPdchohOrGKFiXObA(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.abWrLiCkIBdlWPdchohOrGKFiXObA(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.abWrLiCkIBdlWPdchohOrGKFiXObA(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.abWrLiCkIBdlWPdchohOrGKFiXObA(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.zxdATkhGiNhihCcZghZLxiRuTsiE(HZrDwOTOuvYGJkZRWDMDnUPlFNTs, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					inUOqNgJETupWWjKfbAYdNjpQXjNA.yqqymcbAhhEzQBAmGSXCHsLkByobA(HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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

		internal void ooNidbhWzBcZZJydutNALDEuSswc()
		{
			gUxczTgMdKUcYRnCXamteWaCXJodc();
		}

		private void gUxczTgMdKUcYRnCXamteWaCXJodc()
		{
			controllers.gUxczTgMdKUcYRnCXamteWaCXJodc();
			ncdeijtAGZWOXJkaRjWdEzQdLQeX = false;
		}
	}
}
