using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class KTILEtYJnevtqJezMcdYapEDpwIjA : IComparer<ActionElementMap>
		{
			public static KTILEtYJnevtqJezMcdYapEDpwIjA XgEieFSkudaaPiezMkkmgJYmwhVVA;

			public static KTILEtYJnevtqJezMcdYapEDpwIjA KShhHtLIaTmfgyhciINjadapDzhDb => XgEieFSkudaaPiezMkkmgJYmwhVVA ?? (XgEieFSkudaaPiezMkkmgJYmwhVVA = new KTILEtYJnevtqJezMcdYapEDpwIjA());

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
					return x.id.CompareTo(y.id);
				}
				if (x._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				} <= y._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				})
				{
					return -1;
				}
				return 1;
			}

			int IComparer<ActionElementMap>.Compare(ActionElementMap x, ActionElementMap y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Compare
				return this.Compare(x, y);
			}
		}

		private sealed class bhdWnueZXngYoHFLIysfnzmTRGpI : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int GuvwIDHNLVmLfAucMoUsbdgWIGMt;

			private ActionElementMap eGwYzkZDOEfffIPwIJzdbuChEjRE;

			private int zQEGkkGgYTfgkiwDXKikDPIKPnIdc;

			public ControllerMap wbfwTFoArQvODQMwSfPZhTbJSsPTA;

			private int EYZKUfZccmoxadBbfccUGKfZoXLh;

			public int pSowWKtLXbDYKJtxDDNhNIbqHUem;

			private bool pbFXGyOzXpxMEaeLhOYIIUkgFLmj;

			public bool fgbziSNKKsIjMlHJVjtDBaHrajoab;

			private IList<ActionElementMap> VmmlDLdnuEpzhLDIhphhycyVPqpm;

			private int WyNZtJbgrhMrznrSBTlbaaPSATd;

			private int ToATPpBEZuYbwOBSdVtyKajGQgTk;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return eGwYzkZDOEfffIPwIJzdbuChEjRE;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return eGwYzkZDOEfffIPwIJzdbuChEjRE;
				}
			}

			[DebuggerHidden]
			public bhdWnueZXngYoHFLIysfnzmTRGpI(int P_0)
			{
				GuvwIDHNLVmLfAucMoUsbdgWIGMt = P_0;
				zQEGkkGgYTfgkiwDXKikDPIKPnIdc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int guvwIDHNLVmLfAucMoUsbdgWIGMt = GuvwIDHNLVmLfAucMoUsbdgWIGMt;
				ControllerMap controllerMap = wbfwTFoArQvODQMwSfPZhTbJSsPTA;
				if (guvwIDHNLVmLfAucMoUsbdgWIGMt != 0)
				{
					if (guvwIDHNLVmLfAucMoUsbdgWIGMt != 1)
					{
						return false;
					}
					GuvwIDHNLVmLfAucMoUsbdgWIGMt = -1;
					goto IL_00af;
				}
				GuvwIDHNLVmLfAucMoUsbdgWIGMt = -1;
				if (ReInput._id != controllerMap.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(controllerMap.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return false;
				}
				if (EYZKUfZccmoxadBbfccUGKfZoXLh < 0)
				{
					return false;
				}
				VmmlDLdnuEpzhLDIhphhycyVPqpm = controllerMap.ButtonMaps;
				WyNZtJbgrhMrznrSBTlbaaPSATd = controllerMap.buttonMapCount;
				ToATPpBEZuYbwOBSdVtyKajGQgTk = 0;
				goto IL_00bf;
				IL_00bf:
				if (ToATPpBEZuYbwOBSdVtyKajGQgTk < WyNZtJbgrhMrznrSBTlbaaPSATd)
				{
					ActionElementMap actionElementMap = VmmlDLdnuEpzhLDIhphhycyVPqpm[ToATPpBEZuYbwOBSdVtyKajGQgTk];
					if (actionElementMap._actionId == EYZKUfZccmoxadBbfccUGKfZoXLh && (!pbFXGyOzXpxMEaeLhOYIIUkgFLmj || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
					{
						eGwYzkZDOEfffIPwIJzdbuChEjRE = actionElementMap;
						GuvwIDHNLVmLfAucMoUsbdgWIGMt = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				ToATPpBEZuYbwOBSdVtyKajGQgTk++;
				goto IL_00bf;
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				bhdWnueZXngYoHFLIysfnzmTRGpI bhdWnueZXngYoHFLIysfnzmTRGpI2;
				if (GuvwIDHNLVmLfAucMoUsbdgWIGMt == -2 && zQEGkkGgYTfgkiwDXKikDPIKPnIdc == Environment.CurrentManagedThreadId)
				{
					GuvwIDHNLVmLfAucMoUsbdgWIGMt = 0;
					bhdWnueZXngYoHFLIysfnzmTRGpI2 = this;
				}
				else
				{
					bhdWnueZXngYoHFLIysfnzmTRGpI2 = new bhdWnueZXngYoHFLIysfnzmTRGpI(0);
					bhdWnueZXngYoHFLIysfnzmTRGpI2.wbfwTFoArQvODQMwSfPZhTbJSsPTA = wbfwTFoArQvODQMwSfPZhTbJSsPTA;
				}
				bhdWnueZXngYoHFLIysfnzmTRGpI2.EYZKUfZccmoxadBbfccUGKfZoXLh = pSowWKtLXbDYKJtxDDNhNIbqHUem;
				bhdWnueZXngYoHFLIysfnzmTRGpI2.pbFXGyOzXpxMEaeLhOYIIUkgFLmj = fgbziSNKKsIjMlHJVjtDBaHrajoab;
				return bhdWnueZXngYoHFLIysfnzmTRGpI2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class ECDfJznFAgcptpfNdeyQwEKsbmShA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int rqbGeNEJsVSRpAoZgcSHEtbrDvhZA;

			private ElementAssignmentConflictInfo xTVlEoQgdLAZJiLDgKpRQSRdwNsW;

			private int lQyExJOmehFxsziSQDpSCIzlFURc;

			public ControllerMap xxlHlKrETLQnHvnEoypnxrsZtPSy;

			private ControllerMap SccPStLejbcvQPFhJWScCYOTSvwr;

			public ControllerMap uEuIZnLlOabYRizkndxEggyFekAjA;

			private bool yOoxjZkdPnceZgVhIACawWCNNGyKA;

			public bool dFOAaWBGdnMswpTQgOVAcdlnnplhb;

			private IList<ActionElementMap> akrZiFLcQDYyUkqNfQnOmJXAYdOD;

			private int TkdQELKbUOvxnXZVWeFkemIBbEZk;

			private int xaAwGsXivGpOOjazAyCChdGremyb;

			private ActionElementMap tjfdUTaFXmIzFGNmkHdyJFpaTiFvc;

			private int cZzWtybXKMApejfxOdatNyLprKFf;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return xTVlEoQgdLAZJiLDgKpRQSRdwNsW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return xTVlEoQgdLAZJiLDgKpRQSRdwNsW;
				}
			}

			[DebuggerHidden]
			public ECDfJznFAgcptpfNdeyQwEKsbmShA(int P_0)
			{
				rqbGeNEJsVSRpAoZgcSHEtbrDvhZA = P_0;
				lQyExJOmehFxsziSQDpSCIzlFURc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = rqbGeNEJsVSRpAoZgcSHEtbrDvhZA;
				ControllerMap controllerMap = xxlHlKrETLQnHvnEoypnxrsZtPSy;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					rqbGeNEJsVSRpAoZgcSHEtbrDvhZA = -1;
					goto IL_019c;
				}
				rqbGeNEJsVSRpAoZgcSHEtbrDvhZA = -1;
				if (ReInput._id != controllerMap.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(controllerMap.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return false;
				}
				if (SccPStLejbcvQPFhJWScCYOTSvwr == null || controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
				{
					return false;
				}
				if (yOoxjZkdPnceZgVhIACawWCNNGyKA && (!controllerMap._enabled || !SccPStLejbcvQPFhJWScCYOTSvwr._enabled))
				{
					return false;
				}
				akrZiFLcQDYyUkqNfQnOmJXAYdOD = SccPStLejbcvQPFhJWScCYOTSvwr.ButtonMaps;
				if (akrZiFLcQDYyUkqNfQnOmJXAYdOD == null)
				{
					return false;
				}
				TkdQELKbUOvxnXZVWeFkemIBbEZk = akrZiFLcQDYyUkqNfQnOmJXAYdOD.Count;
				xaAwGsXivGpOOjazAyCChdGremyb = 0;
				goto IL_01d4;
				IL_01d4:
				if (xaAwGsXivGpOOjazAyCChdGremyb < controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA.Count)
				{
					tjfdUTaFXmIzFGNmkHdyJFpaTiFvc = controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA[xaAwGsXivGpOOjazAyCChdGremyb];
					if (!yOoxjZkdPnceZgVhIACawWCNNGyKA || tjfdUTaFXmIzFGNmkHdyJFpaTiFvc.amuHcHIpLQrjMsPzQKBWApxhXPxj)
					{
						cZzWtybXKMApejfxOdatNyLprKFf = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (cZzWtybXKMApejfxOdatNyLprKFf < TkdQELKbUOvxnXZVWeFkemIBbEZk)
				{
					ActionElementMap actionElementMap = akrZiFLcQDYyUkqNfQnOmJXAYdOD[cZzWtybXKMApejfxOdatNyLprKFf];
					if ((!yOoxjZkdPnceZgVhIACawWCNNGyKA || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && tjfdUTaFXmIzFGNmkHdyJFpaTiFvc.CheckForAssignmentConflict(actionElementMap))
					{
						xTVlEoQgdLAZJiLDgKpRQSRdwNsW = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, tjfdUTaFXmIzFGNmkHdyJFpaTiFvc.xYazCGhLJSNpewHjYMCgVGmvJCJk, tjfdUTaFXmIzFGNmkHdyJFpaTiFvc._actionId, tjfdUTaFXmIzFGNmkHdyJFpaTiFvc._elementType, tjfdUTaFXmIzFGNmkHdyJFpaTiFvc._elementIdentifierId, tjfdUTaFXmIzFGNmkHdyJFpaTiFvc.keyCode, tjfdUTaFXmIzFGNmkHdyJFpaTiFvc.modifierKeyFlags);
						rqbGeNEJsVSRpAoZgcSHEtbrDvhZA = 1;
						return true;
					}
					goto IL_019c;
				}
				tjfdUTaFXmIzFGNmkHdyJFpaTiFvc = null;
				goto IL_01c4;
				IL_01c4:
				xaAwGsXivGpOOjazAyCChdGremyb++;
				goto IL_01d4;
				IL_019c:
				cZzWtybXKMApejfxOdatNyLprKFf++;
				goto IL_01ac;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				ECDfJznFAgcptpfNdeyQwEKsbmShA eCDfJznFAgcptpfNdeyQwEKsbmShA;
				if (rqbGeNEJsVSRpAoZgcSHEtbrDvhZA == -2 && lQyExJOmehFxsziSQDpSCIzlFURc == Environment.CurrentManagedThreadId)
				{
					rqbGeNEJsVSRpAoZgcSHEtbrDvhZA = 0;
					eCDfJznFAgcptpfNdeyQwEKsbmShA = this;
				}
				else
				{
					eCDfJznFAgcptpfNdeyQwEKsbmShA = new ECDfJznFAgcptpfNdeyQwEKsbmShA(0);
					eCDfJznFAgcptpfNdeyQwEKsbmShA.xxlHlKrETLQnHvnEoypnxrsZtPSy = xxlHlKrETLQnHvnEoypnxrsZtPSy;
				}
				eCDfJznFAgcptpfNdeyQwEKsbmShA.SccPStLejbcvQPFhJWScCYOTSvwr = uEuIZnLlOabYRizkndxEggyFekAjA;
				eCDfJznFAgcptpfNdeyQwEKsbmShA.yOoxjZkdPnceZgVhIACawWCNNGyKA = dFOAaWBGdnMswpTQgOVAcdlnnplhb;
				return eCDfJznFAgcptpfNdeyQwEKsbmShA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class MsXsTEoVwjfYrUqWgfwwSgAazmwi : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int qjXcaziUwspBokYpLHDySzQIbviuA;

			private ElementAssignmentConflictInfo HRgbdQgmVWdXABWHpyjWNfcBwklv;

			private int DBdCHXIOHDhOuAQHBAZEdkTGySChA;

			public ControllerMap jaQGoRNzMugKdNqhImHbDSssEfcZ;

			private ActionElementMap cYXXtpAyFfhEftUGZuoMdpABhEgf;

			public ActionElementMap uuPtbujTzJSywXOLInSWeiDtIbsJA;

			private bool nLuepQfoVmHeafDjZfFrhzGiBTTlc;

			public bool rNBdXkVtUrUTEAnJZkVAoMTERBMq;

			private int ZZkscPcUJdQmBjQHIofLDFHcJpNQ;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return HRgbdQgmVWdXABWHpyjWNfcBwklv;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return HRgbdQgmVWdXABWHpyjWNfcBwklv;
				}
			}

			[DebuggerHidden]
			public MsXsTEoVwjfYrUqWgfwwSgAazmwi(int P_0)
			{
				qjXcaziUwspBokYpLHDySzQIbviuA = P_0;
				DBdCHXIOHDhOuAQHBAZEdkTGySChA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = qjXcaziUwspBokYpLHDySzQIbviuA;
				ControllerMap controllerMap = jaQGoRNzMugKdNqhImHbDSssEfcZ;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					qjXcaziUwspBokYpLHDySzQIbviuA = -1;
					goto IL_0111;
				}
				qjXcaziUwspBokYpLHDySzQIbviuA = -1;
				if (ReInput._id != controllerMap.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(controllerMap.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return false;
				}
				if (cYXXtpAyFfhEftUGZuoMdpABhEgf == null || controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
				{
					return false;
				}
				if (nLuepQfoVmHeafDjZfFrhzGiBTTlc && (!controllerMap._enabled || !cYXXtpAyFfhEftUGZuoMdpABhEgf.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					return false;
				}
				ZZkscPcUJdQmBjQHIofLDFHcJpNQ = 0;
				goto IL_0121;
				IL_0111:
				ZZkscPcUJdQmBjQHIofLDFHcJpNQ++;
				goto IL_0121;
				IL_0121:
				if (ZZkscPcUJdQmBjQHIofLDFHcJpNQ < controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA.Count)
				{
					ActionElementMap actionElementMap = controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA[ZZkscPcUJdQmBjQHIofLDFHcJpNQ];
					if ((!nLuepQfoVmHeafDjZfFrhzGiBTTlc || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(cYXXtpAyFfhEftUGZuoMdpABhEgf))
					{
						HRgbdQgmVWdXABWHpyjWNfcBwklv = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						qjXcaziUwspBokYpLHDySzQIbviuA = 1;
						return true;
					}
					goto IL_0111;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				MsXsTEoVwjfYrUqWgfwwSgAazmwi msXsTEoVwjfYrUqWgfwwSgAazmwi;
				if (qjXcaziUwspBokYpLHDySzQIbviuA == -2 && DBdCHXIOHDhOuAQHBAZEdkTGySChA == Environment.CurrentManagedThreadId)
				{
					qjXcaziUwspBokYpLHDySzQIbviuA = 0;
					msXsTEoVwjfYrUqWgfwwSgAazmwi = this;
				}
				else
				{
					msXsTEoVwjfYrUqWgfwwSgAazmwi = new MsXsTEoVwjfYrUqWgfwwSgAazmwi(0);
					msXsTEoVwjfYrUqWgfwwSgAazmwi.jaQGoRNzMugKdNqhImHbDSssEfcZ = jaQGoRNzMugKdNqhImHbDSssEfcZ;
				}
				msXsTEoVwjfYrUqWgfwwSgAazmwi.cYXXtpAyFfhEftUGZuoMdpABhEgf = uuPtbujTzJSywXOLInSWeiDtIbsJA;
				msXsTEoVwjfYrUqWgfwwSgAazmwi.nLuepQfoVmHeafDjZfFrhzGiBTTlc = rNBdXkVtUrUTEAnJZkVAoMTERBMq;
				return msXsTEoVwjfYrUqWgfwwSgAazmwi;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class MzZTNMehGuHGIAdDZSmmjfaXexGhA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int InDqKommMlqcqspDTutEECGCIlgBA;

			private ElementAssignmentConflictInfo sNhAZGRTrcCJVjYODHvJDQbukyPEb;

			private int vPyhvksZHiWvXWpTROGoILHlOCGQ;

			public ControllerMap SHaINVvwWXdfaUvViEpCsXDnRrRV;

			private bool FNPCvnEcmtDVIJOrVvrcODmBwwAMA;

			public bool farvizMDLZlXkzIbanHhIqjYewru;

			private ElementAssignmentConflictCheck WYafnGqxPQgjFhgAEvFohAmZXDfaA;

			public ElementAssignmentConflictCheck QxmrzsFfkPibCTYaNsSKYuXfzFMA;

			private ElementAssignment PqGTedkoGeYpQOTvgSqMorvZnidb;

			private int qppfEnVoFwjjHIMTsOjogwPBCzNtb;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return sNhAZGRTrcCJVjYODHvJDQbukyPEb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return sNhAZGRTrcCJVjYODHvJDQbukyPEb;
				}
			}

			[DebuggerHidden]
			public MzZTNMehGuHGIAdDZSmmjfaXexGhA(int P_0)
			{
				InDqKommMlqcqspDTutEECGCIlgBA = P_0;
				vPyhvksZHiWvXWpTROGoILHlOCGQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int inDqKommMlqcqspDTutEECGCIlgBA = InDqKommMlqcqspDTutEECGCIlgBA;
				ControllerMap sHaINVvwWXdfaUvViEpCsXDnRrRV = SHaINVvwWXdfaUvViEpCsXDnRrRV;
				if (inDqKommMlqcqspDTutEECGCIlgBA != 0)
				{
					if (inDqKommMlqcqspDTutEECGCIlgBA != 1)
					{
						return false;
					}
					InDqKommMlqcqspDTutEECGCIlgBA = -1;
					goto IL_0123;
				}
				InDqKommMlqcqspDTutEECGCIlgBA = -1;
				if (ReInput._id != sHaINVvwWXdfaUvViEpCsXDnRrRV.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(sHaINVvwWXdfaUvViEpCsXDnRrRV.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return false;
				}
				if (FNPCvnEcmtDVIJOrVvrcODmBwwAMA && !sHaINVvwWXdfaUvViEpCsXDnRrRV._enabled)
				{
					return false;
				}
				if (sHaINVvwWXdfaUvViEpCsXDnRrRV.FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
				{
					return false;
				}
				PqGTedkoGeYpQOTvgSqMorvZnidb = WYafnGqxPQgjFhgAEvFohAmZXDfaA.ToElementAssignment();
				qppfEnVoFwjjHIMTsOjogwPBCzNtb = 0;
				goto IL_0133;
				IL_0133:
				if (qppfEnVoFwjjHIMTsOjogwPBCzNtb < sHaINVvwWXdfaUvViEpCsXDnRrRV.FjveXygLrTmbIVbkIpJCAFRSCXclA.Count)
				{
					ActionElementMap actionElementMap = sHaINVvwWXdfaUvViEpCsXDnRrRV.FjveXygLrTmbIVbkIpJCAFRSCXclA[qppfEnVoFwjjHIMTsOjogwPBCzNtb];
					if ((!FNPCvnEcmtDVIJOrVvrcODmBwwAMA || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != WYafnGqxPQgjFhgAEvFohAmZXDfaA.elementMapId && actionElementMap.CheckForAssignmentConflict(PqGTedkoGeYpQOTvgSqMorvZnidb))
					{
						sNhAZGRTrcCJVjYODHvJDQbukyPEb = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(sHaINVvwWXdfaUvViEpCsXDnRrRV._categoryId).userAssignable, -1, sHaINVvwWXdfaUvViEpCsXDnRrRV._controllerType, sHaINVvwWXdfaUvViEpCsXDnRrRV._controllerId, sHaINVvwWXdfaUvViEpCsXDnRrRV._id, actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						InDqKommMlqcqspDTutEECGCIlgBA = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				qppfEnVoFwjjHIMTsOjogwPBCzNtb++;
				goto IL_0133;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				MzZTNMehGuHGIAdDZSmmjfaXexGhA mzZTNMehGuHGIAdDZSmmjfaXexGhA;
				if (InDqKommMlqcqspDTutEECGCIlgBA == -2 && vPyhvksZHiWvXWpTROGoILHlOCGQ == Environment.CurrentManagedThreadId)
				{
					InDqKommMlqcqspDTutEECGCIlgBA = 0;
					mzZTNMehGuHGIAdDZSmmjfaXexGhA = this;
				}
				else
				{
					mzZTNMehGuHGIAdDZSmmjfaXexGhA = new MzZTNMehGuHGIAdDZSmmjfaXexGhA(0);
					mzZTNMehGuHGIAdDZSmmjfaXexGhA.SHaINVvwWXdfaUvViEpCsXDnRrRV = SHaINVvwWXdfaUvViEpCsXDnRrRV;
				}
				mzZTNMehGuHGIAdDZSmmjfaXexGhA.WYafnGqxPQgjFhgAEvFohAmZXDfaA = QxmrzsFfkPibCTYaNsSKYuXfzFMA;
				mzZTNMehGuHGIAdDZSmmjfaXexGhA.FNPCvnEcmtDVIJOrVvrcODmBwwAMA = farvizMDLZlXkzIbanHhIqjYewru;
				return mzZTNMehGuHGIAdDZSmmjfaXexGhA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class elOeIwLhqLjcQFjvyIOITaIZjEKh : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int LfGroTEvUeSuiejQEKxsvxVRgxQI;

			private ActionElementMap PtRYHWLAghyVLmHpRFbEzYSLYFcm;

			private int QJVMgqbODSYIfeBtEafGgDMEGXPz;

			public ControllerMap YjakRtEfCyAloFYtByUuIWQhDbrkA;

			private int gkKmXHSMDteKRXpZlJZQcjUrjETS;

			public int INWqCZyfeUztiTROFgsDbYfZxTPJ;

			private bool rYIzylwkeQeFCIwfssaWvGqsSbhx;

			public bool gvsfbWMeRvDSgiVSAiiyFbmArEanA;

			private IEnumerator<ActionElementMap> XNquanjdLtxWXlFxJveeIDJFwloA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return PtRYHWLAghyVLmHpRFbEzYSLYFcm;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PtRYHWLAghyVLmHpRFbEzYSLYFcm;
				}
			}

			[DebuggerHidden]
			public elOeIwLhqLjcQFjvyIOITaIZjEKh(int P_0)
			{
				LfGroTEvUeSuiejQEKxsvxVRgxQI = P_0;
				QJVMgqbODSYIfeBtEafGgDMEGXPz = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int lfGroTEvUeSuiejQEKxsvxVRgxQI = LfGroTEvUeSuiejQEKxsvxVRgxQI;
				if (lfGroTEvUeSuiejQEKxsvxVRgxQI == -3 || lfGroTEvUeSuiejQEKxsvxVRgxQI == 1)
				{
					try
					{
					}
					finally
					{
						ewntpYRZsQddxdoexHgEZiJQOubx();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int lfGroTEvUeSuiejQEKxsvxVRgxQI = LfGroTEvUeSuiejQEKxsvxVRgxQI;
					ControllerMap yjakRtEfCyAloFYtByUuIWQhDbrkA = YjakRtEfCyAloFYtByUuIWQhDbrkA;
					switch (lfGroTEvUeSuiejQEKxsvxVRgxQI)
					{
					default:
						return false;
					case 0:
						LfGroTEvUeSuiejQEKxsvxVRgxQI = -1;
						if (ReInput._id != yjakRtEfCyAloFYtByUuIWQhDbrkA.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(yjakRtEfCyAloFYtByUuIWQhDbrkA.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						XNquanjdLtxWXlFxJveeIDJFwloA = yjakRtEfCyAloFYtByUuIWQhDbrkA.AllMaps.GetEnumerator();
						LfGroTEvUeSuiejQEKxsvxVRgxQI = -3;
						break;
					case 1:
						LfGroTEvUeSuiejQEKxsvxVRgxQI = -3;
						break;
					}
					while (XNquanjdLtxWXlFxJveeIDJFwloA.MoveNext())
					{
						ActionElementMap current = XNquanjdLtxWXlFxJveeIDJFwloA.Current;
						if (current._actionId == gkKmXHSMDteKRXpZlJZQcjUrjETS && (!rYIzylwkeQeFCIwfssaWvGqsSbhx || current.amuHcHIpLQrjMsPzQKBWApxhXPxj))
						{
							PtRYHWLAghyVLmHpRFbEzYSLYFcm = current;
							LfGroTEvUeSuiejQEKxsvxVRgxQI = 1;
							return true;
						}
					}
					ewntpYRZsQddxdoexHgEZiJQOubx();
					XNquanjdLtxWXlFxJveeIDJFwloA = null;
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

			private void ewntpYRZsQddxdoexHgEZiJQOubx()
			{
				LfGroTEvUeSuiejQEKxsvxVRgxQI = -1;
				if (XNquanjdLtxWXlFxJveeIDJFwloA != null)
				{
					XNquanjdLtxWXlFxJveeIDJFwloA.Dispose();
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
				elOeIwLhqLjcQFjvyIOITaIZjEKh elOeIwLhqLjcQFjvyIOITaIZjEKh2;
				if (LfGroTEvUeSuiejQEKxsvxVRgxQI == -2 && QJVMgqbODSYIfeBtEafGgDMEGXPz == Environment.CurrentManagedThreadId)
				{
					LfGroTEvUeSuiejQEKxsvxVRgxQI = 0;
					elOeIwLhqLjcQFjvyIOITaIZjEKh2 = this;
				}
				else
				{
					elOeIwLhqLjcQFjvyIOITaIZjEKh2 = new elOeIwLhqLjcQFjvyIOITaIZjEKh(0);
					elOeIwLhqLjcQFjvyIOITaIZjEKh2.YjakRtEfCyAloFYtByUuIWQhDbrkA = YjakRtEfCyAloFYtByUuIWQhDbrkA;
				}
				elOeIwLhqLjcQFjvyIOITaIZjEKh2.gkKmXHSMDteKRXpZlJZQcjUrjETS = INWqCZyfeUztiTROFgsDbYfZxTPJ;
				elOeIwLhqLjcQFjvyIOITaIZjEKh2.rYIzylwkeQeFCIwfssaWvGqsSbhx = gvsfbWMeRvDSgiVSAiiyFbmArEanA;
				return elOeIwLhqLjcQFjvyIOITaIZjEKh2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class tMEviKANUDIiRHqmOcShHiSegfbE : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int fAbewumSQGvSXxQYpEayTyvjqSLM;

			private ActionElementMap zhRuVHcAMeGUiqPiPtgdnnjWKeuj;

			private int zIpTnXhebSFyAQlHpzPhEkUxZoet;

			public ControllerMap LjHpdcjNxIOKnonqpDygEfHFiVwDA;

			private IControllerElementTarget kQAbGRieBouMUoWkCOLeMGaYzEfFA;

			public IControllerElementTarget OIIltsYfNDLmndonhHxhEmLzAcZLA;

			private bool aIMJNFwKjgwBlHylwHKmFXXrEJPK;

			public bool utfBtOdMQORHKCeERyyVOVzdOSPk;

			private TempListPool.TList<ActionElementMap> yuZuBibjoRNTctlTIGrdtIilVOaO;

			private List<ActionElementMap>.Enumerator GbWgramXqPBhikBBNiEwHHDUVFBcb;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return zhRuVHcAMeGUiqPiPtgdnnjWKeuj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zhRuVHcAMeGUiqPiPtgdnnjWKeuj;
				}
			}

			[DebuggerHidden]
			public tMEviKANUDIiRHqmOcShHiSegfbE(int P_0)
			{
				fAbewumSQGvSXxQYpEayTyvjqSLM = P_0;
				zIpTnXhebSFyAQlHpzPhEkUxZoet = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = fAbewumSQGvSXxQYpEayTyvjqSLM;
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
						SkLxofxsvBWaaqJyaCqkECfbXTlE();
					}
				}
				finally
				{
					phJQOZwpnIBgiaLOHpOZhTxSYrrrA();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = fAbewumSQGvSXxQYpEayTyvjqSLM;
					ControllerMap ljHpdcjNxIOKnonqpDygEfHFiVwDA = LjHpdcjNxIOKnonqpDygEfHFiVwDA;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						fAbewumSQGvSXxQYpEayTyvjqSLM = -1;
						if (ReInput._id != ljHpdcjNxIOKnonqpDygEfHFiVwDA.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(ljHpdcjNxIOKnonqpDygEfHFiVwDA.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						yuZuBibjoRNTctlTIGrdtIilVOaO = TempListPool.GetTList<ActionElementMap>();
						fAbewumSQGvSXxQYpEayTyvjqSLM = -3;
						List<ActionElementMap> list = yuZuBibjoRNTctlTIGrdtIilVOaO.list;
						ljHpdcjNxIOKnonqpDygEfHFiVwDA.ggkUfUXAPQaWoiBsYcQlTMWUVBprA(kQAbGRieBouMUoWkCOLeMGaYzEfFA, false, -1, aIMJNFwKjgwBlHylwHKmFXXrEJPK, list, false, out var _);
						GbWgramXqPBhikBBNiEwHHDUVFBcb = list.GetEnumerator();
						fAbewumSQGvSXxQYpEayTyvjqSLM = -4;
						break;
					}
					case 1:
						fAbewumSQGvSXxQYpEayTyvjqSLM = -4;
						break;
					}
					if (GbWgramXqPBhikBBNiEwHHDUVFBcb.MoveNext())
					{
						ActionElementMap current = GbWgramXqPBhikBBNiEwHHDUVFBcb.Current;
						zhRuVHcAMeGUiqPiPtgdnnjWKeuj = current;
						fAbewumSQGvSXxQYpEayTyvjqSLM = 1;
						return true;
					}
					SkLxofxsvBWaaqJyaCqkECfbXTlE();
					GbWgramXqPBhikBBNiEwHHDUVFBcb = default(List<ActionElementMap>.Enumerator);
					phJQOZwpnIBgiaLOHpOZhTxSYrrrA();
					yuZuBibjoRNTctlTIGrdtIilVOaO = null;
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

			private void phJQOZwpnIBgiaLOHpOZhTxSYrrrA()
			{
				fAbewumSQGvSXxQYpEayTyvjqSLM = -1;
				if (yuZuBibjoRNTctlTIGrdtIilVOaO != null)
				{
					((IDisposable)yuZuBibjoRNTctlTIGrdtIilVOaO).Dispose();
				}
			}

			private void SkLxofxsvBWaaqJyaCqkECfbXTlE()
			{
				fAbewumSQGvSXxQYpEayTyvjqSLM = -3;
				((IDisposable)GbWgramXqPBhikBBNiEwHHDUVFBcb/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				tMEviKANUDIiRHqmOcShHiSegfbE tMEviKANUDIiRHqmOcShHiSegfbE2;
				if (fAbewumSQGvSXxQYpEayTyvjqSLM == -2 && zIpTnXhebSFyAQlHpzPhEkUxZoet == Environment.CurrentManagedThreadId)
				{
					fAbewumSQGvSXxQYpEayTyvjqSLM = 0;
					tMEviKANUDIiRHqmOcShHiSegfbE2 = this;
				}
				else
				{
					tMEviKANUDIiRHqmOcShHiSegfbE2 = new tMEviKANUDIiRHqmOcShHiSegfbE(0);
					tMEviKANUDIiRHqmOcShHiSegfbE2.LjHpdcjNxIOKnonqpDygEfHFiVwDA = LjHpdcjNxIOKnonqpDygEfHFiVwDA;
				}
				tMEviKANUDIiRHqmOcShHiSegfbE2.kQAbGRieBouMUoWkCOLeMGaYzEfFA = OIIltsYfNDLmndonhHxhEmLzAcZLA;
				tMEviKANUDIiRHqmOcShHiSegfbE2.aIMJNFwKjgwBlHylwHKmFXXrEJPK = utfBtOdMQORHKCeERyyVOVzdOSPk;
				return tMEviKANUDIiRHqmOcShHiSegfbE2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class RGyAcVSoNWmoueZVhkYhdbWKwNzH : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int fqHnlnbRLoWBXzUrqwiZUOAPjBUE;

			private ActionElementMap roGDbWpnxQcmBJWxzSdGEsPSNEVOA;

			private int aCfaRNRCTGQnBqYPltSuSLpMHnAi;

			public ControllerMap PAdJhBBphCDPkVCWhgllFAoLHSJKA;

			private IControllerElementTarget SBZmPToEuJhLShBWHyrbcLflLdPD;

			public IControllerElementTarget VPQPPisEpqDkQWPlqTOsJpDZVlAh;

			private int tymHJtBbeDDbsAYZvJOfzBImGLvJA;

			public int AKVgOQvhjNjjzaCwvYqBsgGUiIdfb;

			private bool QSKAljSHJghVePlvlcSFLgrpnkdB;

			public bool PKsNYCssSoRDpykjujXaebekADDhb;

			private TempListPool.TList<ActionElementMap> NbgCxBgXForGKUvAMwJwYvNtTZgg;

			private List<ActionElementMap>.Enumerator XIqTvBitMKraIbXzKvDooMOhvnpJ;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return roGDbWpnxQcmBJWxzSdGEsPSNEVOA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return roGDbWpnxQcmBJWxzSdGEsPSNEVOA;
				}
			}

			[DebuggerHidden]
			public RGyAcVSoNWmoueZVhkYhdbWKwNzH(int P_0)
			{
				fqHnlnbRLoWBXzUrqwiZUOAPjBUE = P_0;
				aCfaRNRCTGQnBqYPltSuSLpMHnAi = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = fqHnlnbRLoWBXzUrqwiZUOAPjBUE;
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
						RaIVjrspirWVRXPonzHgmLDEtPBS();
					}
				}
				finally
				{
					ehsGNIXsGdgkfCeNxMutJAaMwRZFA();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = fqHnlnbRLoWBXzUrqwiZUOAPjBUE;
					ControllerMap pAdJhBBphCDPkVCWhgllFAoLHSJKA = PAdJhBBphCDPkVCWhgllFAoLHSJKA;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						fqHnlnbRLoWBXzUrqwiZUOAPjBUE = -1;
						if (ReInput._id != pAdJhBBphCDPkVCWhgllFAoLHSJKA.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(pAdJhBBphCDPkVCWhgllFAoLHSJKA.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						NbgCxBgXForGKUvAMwJwYvNtTZgg = TempListPool.GetTList<ActionElementMap>();
						fqHnlnbRLoWBXzUrqwiZUOAPjBUE = -3;
						List<ActionElementMap> list = NbgCxBgXForGKUvAMwJwYvNtTZgg.list;
						pAdJhBBphCDPkVCWhgllFAoLHSJKA.ggkUfUXAPQaWoiBsYcQlTMWUVBprA(SBZmPToEuJhLShBWHyrbcLflLdPD, true, tymHJtBbeDDbsAYZvJOfzBImGLvJA, QSKAljSHJghVePlvlcSFLgrpnkdB, list, false, out var _);
						XIqTvBitMKraIbXzKvDooMOhvnpJ = list.GetEnumerator();
						fqHnlnbRLoWBXzUrqwiZUOAPjBUE = -4;
						break;
					}
					case 1:
						fqHnlnbRLoWBXzUrqwiZUOAPjBUE = -4;
						break;
					}
					if (XIqTvBitMKraIbXzKvDooMOhvnpJ.MoveNext())
					{
						ActionElementMap current = XIqTvBitMKraIbXzKvDooMOhvnpJ.Current;
						roGDbWpnxQcmBJWxzSdGEsPSNEVOA = current;
						fqHnlnbRLoWBXzUrqwiZUOAPjBUE = 1;
						return true;
					}
					RaIVjrspirWVRXPonzHgmLDEtPBS();
					XIqTvBitMKraIbXzKvDooMOhvnpJ = default(List<ActionElementMap>.Enumerator);
					ehsGNIXsGdgkfCeNxMutJAaMwRZFA();
					NbgCxBgXForGKUvAMwJwYvNtTZgg = null;
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

			private void ehsGNIXsGdgkfCeNxMutJAaMwRZFA()
			{
				fqHnlnbRLoWBXzUrqwiZUOAPjBUE = -1;
				if (NbgCxBgXForGKUvAMwJwYvNtTZgg != null)
				{
					((IDisposable)NbgCxBgXForGKUvAMwJwYvNtTZgg).Dispose();
				}
			}

			private void RaIVjrspirWVRXPonzHgmLDEtPBS()
			{
				fqHnlnbRLoWBXzUrqwiZUOAPjBUE = -3;
				((IDisposable)XIqTvBitMKraIbXzKvDooMOhvnpJ/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				RGyAcVSoNWmoueZVhkYhdbWKwNzH rGyAcVSoNWmoueZVhkYhdbWKwNzH;
				if (fqHnlnbRLoWBXzUrqwiZUOAPjBUE == -2 && aCfaRNRCTGQnBqYPltSuSLpMHnAi == Environment.CurrentManagedThreadId)
				{
					fqHnlnbRLoWBXzUrqwiZUOAPjBUE = 0;
					rGyAcVSoNWmoueZVhkYhdbWKwNzH = this;
				}
				else
				{
					rGyAcVSoNWmoueZVhkYhdbWKwNzH = new RGyAcVSoNWmoueZVhkYhdbWKwNzH(0);
					rGyAcVSoNWmoueZVhkYhdbWKwNzH.PAdJhBBphCDPkVCWhgllFAoLHSJKA = PAdJhBBphCDPkVCWhgllFAoLHSJKA;
				}
				rGyAcVSoNWmoueZVhkYhdbWKwNzH.SBZmPToEuJhLShBWHyrbcLflLdPD = VPQPPisEpqDkQWPlqTOsJpDZVlAh;
				rGyAcVSoNWmoueZVhkYhdbWKwNzH.tymHJtBbeDDbsAYZvJOfzBImGLvJA = AKVgOQvhjNjjzaCwvYqBsgGUiIdfb;
				rGyAcVSoNWmoueZVhkYhdbWKwNzH.QSKAljSHJghVePlvlcSFLgrpnkdB = PKsNYCssSoRDpykjujXaebekADDhb;
				return rGyAcVSoNWmoueZVhkYhdbWKwNzH;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name = string.Empty;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int lJEMGWAUGjJITDkYXUyWTwcHpUqo;

		private readonly AList<ActionElementMap> FjveXygLrTmbIVbkIpJCAFRSCXclA;

		private readonly ReadOnlyCollection<ActionElementMap> GzSrUnRlVRUqYPthruNMLMtidySM;

		private readonly AList<ActionElementMap> kPYjXodpTYrcUuHRWswhPfrndUBGA;

		private readonly ReadOnlyCollection<ActionElementMap> lgwTNSmlQTVBhRLWtjbwdxiqOTiw;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int DBgClSEmQiwxMoUHcpVvyFbwZByy;

		private static int AHhTiuMzhSGXbwAwGgdocxrswvlmA
		{
			get
			{
				int dBgClSEmQiwxMoUHcpVvyFbwZByy = DBgClSEmQiwxMoUHcpVvyFbwZByy;
				if (DBgClSEmQiwxMoUHcpVvyFbwZByy == int.MaxValue)
				{
					DBgClSEmQiwxMoUHcpVvyFbwZByy = 0;
					return dBgClSEmQiwxMoUHcpVvyFbwZByy;
				}
				DBgClSEmQiwxMoUHcpVvyFbwZByy++;
				return dBgClSEmQiwxMoUHcpVvyFbwZByy;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = num;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = text;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = guid;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return -1;
				}
				return _playerId;
			}
			internal set
			{
				_playerId = num;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = num;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return 0;
				}
				return kPYjXodpTYrcUuHRWswhPfrndUBGA.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return 0;
				}
				return FjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return lgwTNSmlQTVBhRLWtjbwdxiqOTiw;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return lgwTNSmlQTVBhRLWtjbwdxiqOTiw;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return GzSrUnRlVRUqYPthruNMLMtidySM;
			}
		}

		internal AList<ActionElementMap> XJOdguxXwMRhhVigJirOJaRIWSEt => FjveXygLrTmbIVbkIpJCAFRSCXclA;

		public ControllerMap()
		{
			_id = AHhTiuMzhSGXbwAwGgdocxrswvlmA;
			_sourceMapId = -1;
			FjveXygLrTmbIVbkIpJCAFRSCXclA = new AList<ActionElementMap>();
			GzSrUnRlVRUqYPthruNMLMtidySM = new ReadOnlyCollection<ActionElementMap>(FjveXygLrTmbIVbkIpJCAFRSCXclA);
			kPYjXodpTYrcUuHRWswhPfrndUBGA = new AList<ActionElementMap>();
			lgwTNSmlQTVBhRLWtjbwdxiqOTiw = new ReadOnlyCollection<ActionElementMap>(kPYjXodpTYrcUuHRWswhPfrndUBGA);
			lJEMGWAUGjJITDkYXUyWTwcHpUqo = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = AHhTiuMzhSGXbwAwGgdocxrswvlmA;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			if (P_0.FjveXygLrTmbIVbkIpJCAFRSCXclA != null)
			{
				int count = P_0.FjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
				for (int i = 0; i < count; i++)
				{
					LGjUZvRtIOJMLQaZtaRGejeKWsgi(new ActionElementMap(P_0.FjveXygLrTmbIVbkIpJCAFRSCXclA[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			InputAction inputAction = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.VImAJPVLgiorGVOJDSOudNQAjQHW(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			AList<ActionElementMap> aList = kPYjXodpTYrcUuHRWswhPfrndUBGA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (kPYjXodpTYrcUuHRWswhPfrndUBGA[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			AList<ActionElementMap> aList = kPYjXodpTYrcUuHRWswhPfrndUBGA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (kPYjXodpTYrcUuHRWswhPfrndUBGA[i].keyCode == keyCode && kPYjXodpTYrcUuHRWswhPfrndUBGA[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = kPYjXodpTYrcUuHRWswhPfrndUBGA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (kPYjXodpTYrcUuHRWswhPfrndUBGA[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			AList<ActionElementMap> aList = kPYjXodpTYrcUuHRWswhPfrndUBGA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (kPYjXodpTYrcUuHRWswhPfrndUBGA[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (GetElementMap(elementAssignment.elementMapId) == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, moNrVnhMyxFSevnVWYTclYHmdtVI.cTKZnruLFvxhZtYhgEqaKiQIZvgl(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.XxMvlVzqErvGSYjarMeZYpjHprtT(this, actionElementMap);
			LGjUZvRtIOJMLQaZtaRGejeKWsgi(actionElementMap);
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			ERzpAcEPwaeYZpgZgfnRECmQBftab eRzpAcEPwaeYZpgZgfnRECmQBftab = ERzpAcEPwaeYZpgZgfnRECmQBftab.ZhyRfbEGFlFXXqDwoCUocpySwIQN(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, eRzpAcEPwaeYZpgZgfnRECmQBftab.RswHfKxHnnAnlfLRjsAdTkfMKKiUA, eRzpAcEPwaeYZpgZgfnRECmQBftab.eNVgwhZRbfahWjDlZSLDwKLKgIeFA, eRzpAcEPwaeYZpgZgfnRECmQBftab.BSSCanDCbXxlUpGCcVhxoxYiWQXo, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			LGjUZvRtIOJMLQaZtaRGejeKWsgi(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, moNrVnhMyxFSevnVWYTclYHmdtVI.cTKZnruLFvxhZtYhgEqaKiQIZvgl(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (EnPYuZBHFBmjRaahEvlyghdOFrpW(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				LGjUZvRtIOJMLQaZtaRGejeKWsgi(elementMap);
			}
			if (EnPYuZBHFBmjRaahEvlyghdOFrpW(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.dMkfpKbsZmZlOlWdlLPmClgAJITFA();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.XxMvlVzqErvGSYjarMeZYpjHprtT(this, elementMap);
			result = elementMap;
			return true;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			ERzpAcEPwaeYZpgZgfnRECmQBftab eRzpAcEPwaeYZpgZgfnRECmQBftab = ERzpAcEPwaeYZpgZgfnRECmQBftab.ZhyRfbEGFlFXXqDwoCUocpySwIQN(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, eRzpAcEPwaeYZpgZgfnRECmQBftab.RswHfKxHnnAnlfLRjsAdTkfMKKiUA, eRzpAcEPwaeYZpgZgfnRECmQBftab.eNVgwhZRbfahWjDlZSLDwKLKgIeFA, eRzpAcEPwaeYZpgZgfnRECmQBftab.BSSCanDCbXxlUpGCcVhxoxYiWQXo, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				LGjUZvRtIOJMLQaZtaRGejeKWsgi(elementMap);
			}
			if (EnPYuZBHFBmjRaahEvlyghdOFrpW(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			PBeemRQYRbxAhddOggEZTxxxXJLD(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			int num = EnPYuZBHFBmjRaahEvlyghdOFrpW(elementMapId);
			if (num < 0)
			{
				return false;
			}
			BaZJhhdzhzbTqKONPpVmVbujapyE(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == elementMapId)
				{
					return FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				}
			}
			return null;
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = elementMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (!skipDisabledMaps || allMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					list.Add(allMap);
				}
			}
			return list.ToArray();
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(skipDisabledMaps: false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return yxRQTYzGEGjxNBGOMIYGdOrNNmmu(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			foreach (ActionElementMap allMap2 in AllMaps)
			{
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return AvmYEXAwkVTWWehMOUUIzJXxGqQr(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(elOeIwLhqLjcQFjvyIOITaIZjEKh))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new elOeIwLhqLjcQFjvyIOITaIZjEKh(-2)
			{
				YjakRtEfCyAloFYtByUuIWQhDbrkA = this,
				INWqCZyfeUztiTROFgsDbYfZxTPJ = actionId,
				gvsfbWMeRvDSgiVSAiiyFbmArEanA = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._actionId == actionId && (!skipDisabledMaps || FjveXygLrTmbIVbkIpJCAFRSCXclA[i].amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					return FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, skipDisabledMaps);
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
			return result;
		}

		[IteratorStateMachine(typeof(tMEviKANUDIiRHqmOcShHiSegfbE))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new tMEviKANUDIiRHqmOcShHiSegfbE(-2)
			{
				LjHpdcjNxIOKnonqpDygEfHFiVwDA = this,
				OIIltsYfNDLmndonhHxhEmLzAcZLA = elementTarget,
				utfBtOdMQORHKCeERyyVOVzdOSPk = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, actionId, skipDisabledMaps);
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(RGyAcVSoNWmoueZVhkYhdbWKwNzH))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new RGyAcVSoNWmoueZVhkYhdbWKwNzH(-2)
			{
				PAdJhBBphCDPkVCWhgllFAoLHSJKA = this,
				VPQPPisEpqDkQWPlqTOsJpDZVlAh = elementTarget,
				AKVgOQvhjNjjzaCwvYqBsgGUiIdfb = actionId,
				PKsNYCssSoRDpykjujXaebekADDhb = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, skipDisabledMaps);
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			bool flag;
			return DjWWuZsxtpUwnYvonxAcnwebFqAJ(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, actionId, skipDisabledMaps);
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			bool flag;
			return DjWWuZsxtpUwnYvonxAcnwebFqAJ(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, skipDisabledMaps, results);
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			bool flag;
			return ggkUfUXAPQaWoiBsYcQlTMWUVBprA(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, actionId, skipDisabledMaps, results);
			QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			bool flag;
			return ggkUfUXAPQaWoiBsYcQlTMWUVBprA(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			return nCbYVejBPTmuorSDmZRrJJavRJoB(predicate, false);
		}

		internal virtual ActionElementMap nCbYVejBPTmuorSDmZRrJJavRJoB(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return ByRDdShLtDtLttQKTDuiDerPWGPWA(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return jjMuuekUwblocWYvTLbSPbiSpkQi(predicate, false, results, false);
		}

		internal virtual int jjMuuekUwblocWYvTLbSPbiSpkQi(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return KKWjuRObtNgvRYhaWRhIRFttQbjP(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
			int count = kPYjXodpTYrcUuHRWswhPfrndUBGA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = kPYjXodpTYrcUuHRWswhPfrndUBGA[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return;
			}
			FjveXygLrTmbIVbkIpJCAFRSCXclA.Clear();
			kPYjXodpTYrcUuHRWswhPfrndUBGA.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int num = 0;
			int count = kPYjXodpTYrcUuHRWswhPfrndUBGA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = kPYjXodpTYrcUuHRWswhPfrndUBGA[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj != state)
				{
					actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null || index < 0 || index >= FjveXygLrTmbIVbkIpJCAFRSCXclA.Count)
			{
				return null;
			}
			return FjveXygLrTmbIVbkIpJCAFRSCXclA[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(FjveXygLrTmbIVbkIpJCAFRSCXclA);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return sckDfTBqpZUNmjnGMcxISbAXWraO(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.VImAJPVLgiorGVOJDSOudNQAjQHW(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.VImAJPVLgiorGVOJDSOudNQAjQHW(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num2];
			int num3 = 0;
			for (int j = 0; j < num; j++)
			{
				ActionElementMap actionElementMap2 = FjveXygLrTmbIVbkIpJCAFRSCXclA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			InputAction inputAction = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.VImAJPVLgiorGVOJDSOudNQAjQHW(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			InputAction inputAction = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.VImAJPVLgiorGVOJDSOudNQAjQHW(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return evuAGWdmBtXdeDdtbgwnSOyyQUPhA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(bhdWnueZXngYoHFLIysfnzmTRGpI))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new bhdWnueZXngYoHFLIysfnzmTRGpI(-2)
			{
				wbfwTFoArQvODQMwSfPZhTbJSsPTA = this,
				pSowWKtLXbDYKJtxDDNhNIbqHUem = actionId,
				fgbziSNKKsIjMlHJVjtDBaHrajoab = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.enabled))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			return ByRDdShLtDtLttQKTDuiDerPWGPWA(predicate, false);
		}

		internal ActionElementMap ByRDdShLtDtLttQKTDuiDerPWGPWA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return KKWjuRObtNgvRYhaWRhIRFttQbjP(predicate, false, results, false);
		}

		internal int KKWjuRObtNgvRYhaWRhIRFttQbjP(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_3)
			{
				P_2.Clear();
			}
			else
			{
				num = P_2.Count;
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num2 = buttonMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
			int count = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					BaZJhhdzhzbTqKONPpVmVbujapyE(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int num = 0;
			int count = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj != state)
				{
					actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj = state;
					num++;
				}
			}
			return num;
		}

		public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
		{
			return DoesElementAssignmentConflict(controllerMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
		{
			return DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
		{
			return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false);
		}

		public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return false;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int num = buttonMapCount;
			int count = buttonMaps.Count;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (skipDisabledMaps && !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (actionElementMap == null || FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
			{
				return false;
			}
			for (int i = 0; i < FjveXygLrTmbIVbkIpJCAFRSCXclA.Count; i++)
			{
				ActionElementMap actionElementMap2 = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return false;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < FjveXygLrTmbIVbkIpJCAFRSCXclA.Count; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if ((!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return ElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return ElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		[IteratorStateMachine(typeof(ECDfJznFAgcptpfNdeyQwEKsbmShA))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new ECDfJznFAgcptpfNdeyQwEKsbmShA(-2)
			{
				xxlHlKrETLQnHvnEoypnxrsZtPSy = this,
				uEuIZnLlOabYRizkndxEggyFekAjA = controllerMap,
				dFOAaWBGdnMswpTQgOVAcdlnnplhb = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(MsXsTEoVwjfYrUqWgfwwSgAazmwi))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new MsXsTEoVwjfYrUqWgfwwSgAazmwi(-2)
			{
				jaQGoRNzMugKdNqhImHbDSssEfcZ = this,
				uuPtbujTzJSywXOLInSWeiDtIbsJA = actionElementMap,
				rNBdXkVtUrUTEAnJZkVAoMTERBMq = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(MzZTNMehGuHGIAdDZSmmjfaXexGhA))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new MzZTNMehGuHGIAdDZSmmjfaXexGhA(-2)
			{
				SHaINVvwWXdfaUvViEpCsXDnRrRV = this,
				QxmrzsFfkPibCTYaNsSKYuXfzFMA = conflictCheck,
				farvizMDLZlXkzIbanHhIqjYewru = skipDisabledMaps
			};
		}

		public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return num;
			}
			IList<ActionElementMap> fjveXygLrTmbIVbkIpJCAFRSCXclA = controllerMap.FjveXygLrTmbIVbkIpJCAFRSCXclA;
			if (fjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = fjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			for (int num2 = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[num2];
				if (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || fjveXygLrTmbIVbkIpJCAFRSCXclA[i].amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(fjveXygLrTmbIVbkIpJCAFRSCXclA[i]))
						{
							BaZJhhdzhzbTqKONPpVmVbujapyE(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
			{
				return 0;
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
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return num;
			}
			for (int num2 = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = FjveXygLrTmbIVbkIpJCAFRSCXclA[num2];
				if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					BaZJhhdzhzbTqKONPpVmVbujapyE(actionElementMap2.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
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
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[num2];
				if ((!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					BaZJhhdzhzbTqKONPpVmVbujapyE(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return wGJXfttiznxlxdlGIfuiHggUqnTV(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return mHsExafuwcnSQXWQrJQEBJLSIWLCA(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return MZIiBSxUJkBlkAMDPNstKEDPEHpn(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return wGJXfttiznxlxdlGIfuiHggUqnTV(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return mHsExafuwcnSQXWQrJQEBJLSIWLCA(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return MZIiBSxUJkBlkAMDPNstKEDPEHpn(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int wGJXfttiznxlxdlGIfuiHggUqnTV(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0._enabled))
			{
				return 0;
			}
			int num = 0;
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return num;
			}
			IList<ActionElementMap> fjveXygLrTmbIVbkIpJCAFRSCXclA = P_0.FjveXygLrTmbIVbkIpJCAFRSCXclA;
			if (fjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = fjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (!actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = fjveXygLrTmbIVbkIpJCAFRSCXclA[j];
					if ((!P_1 || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						actionElementMap.enabled = false;
						P_2?.Add(actionElementMap);
						num++;
						break;
					}
				}
			}
			return num;
		}

		internal virtual int mHsExafuwcnSQXWQrJQEBJLSIWLCA(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.amuHcHIpLQrjMsPzQKBWApxhXPxj))
			{
				return 0;
			}
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
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int MZIiBSxUJkBlkAMDPNstKEDPEHpn(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return 0;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
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
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int num = 0;
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(controllerMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(actionElementMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(conflictCheck, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (kPYjXodpTYrcUuHRWswhPfrndUBGA == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.kPYjXodpTYrcUuHRWswhPfrndUBGA;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = list.Count;
			for (int num2 = kPYjXodpTYrcUuHRWswhPfrndUBGA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = kPYjXodpTYrcUuHRWswhPfrndUBGA[num2];
				if (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(list[i]))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num;
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
			{
				return 0;
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
			if (kPYjXodpTYrcUuHRWswhPfrndUBGA == null)
			{
				return num;
			}
			for (int num2 = kPYjXodpTYrcUuHRWswhPfrndUBGA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = kPYjXodpTYrcUuHRWswhPfrndUBGA[num2];
				if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					try
					{
						actionToPerform(actionElementMap2);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (kPYjXodpTYrcUuHRWswhPfrndUBGA == null)
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
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = kPYjXodpTYrcUuHRWswhPfrndUBGA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = kPYjXodpTYrcUuHRWswhPfrndUBGA[num2];
				if ((!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					try
					{
						actionToPerform(actionElementMap);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<string>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return new string[0];
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = FjveXygLrTmbIVbkIpJCAFRSCXclA[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return string.Empty;
			}
			try
			{
				return ljFUdbjwbjNRliJLGkpSbbDuzfhQ().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return string.Empty;
			}
			try
			{
				return ljFUdbjwbjNRliJLGkpSbbDuzfhQ().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				WRScrEekSojpdBXyEFARqvkVFcPPb wRScrEekSojpdBXyEFARqvkVFcPPb = ReInput.vIwqoVqeOjBtSKOUlpaSczWHzkThB(templateTypeGuid);
				string text = ((wRScrEekSojpdBXyEFARqvkVFcPPb != null) ? wRScrEekSojpdBXyEFARqvkVFcPPb.yNrMSTbxzQDGulhBuxNfjpYIDjri : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.qQBJNkYOGecrgXLtarpZybwboFVc(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (templateInterfaceType == null)
			{
				throw new ArgumentNullException("templateInterfaceType");
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.qQBJNkYOGecrgXLtarpZybwboFVc(controllerTemplate, this);
		}

		private ControllerTemplateMap ZdFHAOFPUbuBWHIijohrVoCTBgxOA(IControllerTemplate P_0)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.qQBJNkYOGecrgXLtarpZybwboFVc(P_0, this);
		}

		internal virtual bool SRgvEhEXnsACwdSpkBjYoWEkqxLb(ActionElementMap P_0)
		{
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_0._elementType))
			{
				return false;
			}
			LGjUZvRtIOJMLQaZtaRGejeKWsgi(P_0);
			return true;
		}

		internal virtual int yxRQTYzGEGjxNBGOMIYGdOrNNmmu(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = FjveXygLrTmbIVbkIpJCAFRSCXclA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || FjveXygLrTmbIVbkIpJCAFRSCXclA[i].amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					P_0.Add(FjveXygLrTmbIVbkIpJCAFRSCXclA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap HnhwRbtUSHfqZdDsLQzeXYDJIqHd(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_2))
			{
				return null;
			}
			int num = tHhcunbcbjgFVVanpTynUPswOpwKA(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return FjveXygLrTmbIVbkIpJCAFRSCXclA[num];
		}

		internal virtual int gWMpzXjwXYLcqSKbnABZEsflXeOEA(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_2)
			{
				P_1.Clear();
			}
			else
			{
				num = P_1.Count;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(FjveXygLrTmbIVbkIpJCAFRSCXclA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool vcWheJiEcLpRmfgrBOYBMUspXxXgA(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._elementIdentifierId == P_0 && FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int tHhcunbcbjgFVVanpTynUPswOpwKA(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_2))
			{
				return -1;
			}
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._elementIdentifierId == P_0 && FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int EnPYuZBHFBmjRaahEvlyghdOFrpW(int P_0)
		{
			if (FjveXygLrTmbIVbkIpJCAFRSCXclA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int sckDfTBqpZUNmjnGMcxISbAXWraO(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = buttonMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (!P_0 || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int evuAGWdmBtXdeDdtbgwnSOyyQUPhA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_3)
			{
				P_2.Clear();
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return 0;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int AvmYEXAwkVTWWehMOUUIzJXxGqQr(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap DjWWuZsxtpUwnYvonxAcnwebFqAJ(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!GQyDvGULunNdAIZszjHSkpJyEIAA(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._actionId == P_2) && (!P_3 || FjveXygLrTmbIVbkIpJCAFRSCXclA[i].amuHcHIpLQrjMsPzQKBWApxhXPxj) && FjveXygLrTmbIVbkIpJCAFRSCXclA[i].IsTarget(P_0))
				{
					return FjveXygLrTmbIVbkIpJCAFRSCXclA[i];
				}
			}
			return null;
		}

		internal virtual int ggkUfUXAPQaWoiBsYcQlTMWUVBprA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_5)
			{
				P_4.Clear();
			}
			P_6 = false;
			if (P_1 && P_2 < 0)
			{
				P_6 = true;
				return num;
			}
			if (!GQyDvGULunNdAIZszjHSkpJyEIAA(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || FjveXygLrTmbIVbkIpJCAFRSCXclA[i]._actionId == P_2) && (!P_3 || FjveXygLrTmbIVbkIpJCAFRSCXclA[i].amuHcHIpLQrjMsPzQKBWApxhXPxj) && FjveXygLrTmbIVbkIpJCAFRSCXclA[i].IsTarget(P_0))
				{
					P_4.Add(FjveXygLrTmbIVbkIpJCAFRSCXclA[i]);
					num++;
				}
			}
			return num;
		}

		internal void TCTuCHYdJBYtoRCYYYGUaaxlPkEq(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap != null && elementMap._elementType != P_1)
			{
				elementMap._elementType = P_1;
				if (P_1 == ControllerElementType.Button)
				{
					elementMap._axisRange = AxisRange.Full;
					elementMap._invert = false;
				}
				DeleteElementMap(P_0);
				ZRIjyELwkgRbWriDAtViXcLrmcip(elementMap);
			}
		}

		internal virtual bool ZRIjyELwkgRbWriDAtViXcLrmcip(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!IFBbDFJXHxOwadYNhlgABltTjJSXA(P_0._elementType))
			{
				return false;
			}
			FjveXygLrTmbIVbkIpJCAFRSCXclA.Add(P_0);
			TaftfVXgsIkQEpjduYRuDmWoWzXe(P_0);
			return true;
		}

		internal bool GQyDvGULunNdAIZszjHSkpJyEIAA(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			Controller controller = P_0.controller;
			if (controller == null || controller.type != _controllerType || controller.id != _controllerId)
			{
				return false;
			}
			return true;
		}

		internal bool MFaAXBJyXaUpDOnUWyDXvVkOxez(string P_0)
		{
			try
			{
				OWwCarBlxYJQRgjRztrVxMZOfXiRA(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool pgQbXDUmKkGKZAkRwZMiPjMIfDeGb(string P_0)
		{
			try
			{
				OWwCarBlxYJQRgjRztrVxMZOfXiRA(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void TaftfVXgsIkQEpjduYRuDmWoWzXe(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				kPYjXodpTYrcUuHRWswhPfrndUBGA.Add(P_0);
				kPYjXodpTYrcUuHRWswhPfrndUBGA.Sort(KTILEtYJnevtqJezMcdYapEDpwIjA.KShhHtLIaTmfgyhciINjadapDzhDb);
			}
		}

		internal void JljXLKBTmsVgJTbmKETRDrcvMavEb(int P_0)
		{
			int num = SFuWyWMiOLMMFVLxnWwyJSRmvvJE(P_0);
			if (num >= 0)
			{
				kPYjXodpTYrcUuHRWswhPfrndUBGA.RemoveAt(num);
			}
		}

		internal void xmddktKtoriRKAXnxuGKTgXExcYy(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = SFuWyWMiOLMMFVLxnWwyJSRmvvJE(P_0);
				if (num >= 0)
				{
					kPYjXodpTYrcUuHRWswhPfrndUBGA[num] = P_1;
					kPYjXodpTYrcUuHRWswhPfrndUBGA.Sort(KTILEtYJnevtqJezMcdYapEDpwIjA.KShhHtLIaTmfgyhciINjadapDzhDb);
				}
			}
		}

		internal static void PBeemRQYRbxAhddOggEZTxxxXJLD(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.dMkfpKbsZmZlOlWdlLPmClgAJITFA();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			P_0._elementIdentifierId = P_3;
			P_0._axisContribution = P_2;
			P_0._axisRange = P_5;
			if (P_4 == ControllerElementType.Axis)
			{
				P_0._invert = P_6;
			}
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId)?.XxMvlVzqErvGSYjarMeZYpjHprtT(this, map);
			}
		}

		internal virtual bool OWwCarBlxYJQRgjRztrVxMZOfXiRA(SerializedObject P_0)
		{
			bool flag = false;
			_sourceMapId = -1;
			_categoryId = -1;
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
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.pcbbqZaMalVdvJdmSXlnpndbZtQJ(value2);
						if (ActionElementMap.boixdvODcOFbHcLGxCkDabPrIIMjb(actionElementMap))
						{
							LGjUZvRtIOJMLQaZtaRGejeKWsgi(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void tglDbhCwCmLTnbODONPFbTRTAiqHA(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "dataVersion",
				lPGTilhMaDlHVZPffTpyFffKvRGC = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string lPGTilhMaDlHVZPffTpyFffKvRGC = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
				{
					ielDRFPPVThNrLWgcnBdvoVjXqeg = "hardwareGuid",
					lPGTilhMaDlHVZPffTpyFffKvRGC = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
				{
					ielDRFPPVThNrLWgcnBdvoVjXqeg = "hardwareName",
					lPGTilhMaDlHVZPffTpyFffKvRGC = lPGTilhMaDlHVZPffTpyFffKvRGC
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ZGFlSbWGOfUmLZdUdkUpxhWKZcME = "xmlns",
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "xsi",
				MFDdXiyHcPkUibxNoPMtNRhjvlXA = null,
				lPGTilhMaDlHVZPffTpyFffKvRGC = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ZGFlSbWGOfUmLZdUdkUpxhWKZcME = "xsi",
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "schemaLocation",
				MFDdXiyHcPkUibxNoPMtNRhjvlXA = null,
				lPGTilhMaDlHVZPffTpyFffKvRGC = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
			});
			P_0.Add("sourceMapId", _sourceMapId);
			P_0.Add("categoryId", _categoryId);
			P_0.Add("layoutId", _layoutId);
			P_0.Add("name", _name);
			P_0.Add("hardwareGuid", _hardwareGuid);
			P_0.Add("enabled", _enabled);
			int num = buttonMapCount;
			List<object> list = new List<object>();
			P_0.Add("buttonMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (FjveXygLrTmbIVbkIpJCAFRSCXclA[i] != null)
				{
					list.Add(FjveXygLrTmbIVbkIpJCAFRSCXclA[i].vnkhapAzxkdihiiJDhDEbFBqtmXz());
				}
			}
		}

		private bool IFBbDFJXHxOwadYNhlgABltTjJSXA(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void BaZJhhdzhzbTqKONPpVmVbujapyE(int P_0, int P_1)
		{
			JljXLKBTmsVgJTbmKETRDrcvMavEb(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				FjveXygLrTmbIVbkIpJCAFRSCXclA.RemoveAt(P_1);
			}
		}

		private void LGjUZvRtIOJMLQaZtaRGejeKWsgi(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				FjveXygLrTmbIVbkIpJCAFRSCXclA.Add(P_0);
				TaftfVXgsIkQEpjduYRuDmWoWzXe(P_0);
			}
		}

		private void yvHQxLDAAlqHMSIeYkOpUymKLATA(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				xmddktKtoriRKAXnxuGKTgXExcYy(FjveXygLrTmbIVbkIpJCAFRSCXclA[P_1].xYazCGhLJSNpewHjYMCgVGmvJCJk, P_0);
				FjveXygLrTmbIVbkIpJCAFRSCXclA[P_1] = P_0;
			}
		}

		private int SFuWyWMiOLMMFVLxnWwyJSRmvvJE(int P_0)
		{
			if (kPYjXodpTYrcUuHRWswhPfrndUBGA == null)
			{
				return -1;
			}
			int count = kPYjXodpTYrcUuHRWswhPfrndUBGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (kPYjXodpTYrcUuHRWswhPfrndUBGA[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject ljFUdbjwbjNRliJLGkpSbbDuzfhQ()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			tglDbhCwCmLTnbODONPFbTRTAiqHA(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap jQKDXoimuSpEWcCdpBenThEztXonA(ControllerType P_0)
		{
			return P_0 switch
			{
				ControllerType.Keyboard => new KeyboardMap(), 
				ControllerType.Mouse => new MouseMap(), 
				ControllerType.Joystick => new JoystickMap(), 
				ControllerType.Custom => new CustomControllerMap(), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerMap CBbGqaKJwSYpkPPFPCLVxIghJIzWA(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.VAEnbEnWtHBalrdrrAWtkeGcduIdA(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.HsWpYztryjDgjTsaGEGyAuWhNivW(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.FfZldRzgvSdPWmHQzEEUzcZhYDeA(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.MVHnYJGaDhkxSLeIEDskEDGaPFUOA(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = jQKDXoimuSpEWcCdpBenThEztXonA(controllerType);
			try
			{
				controllerMap.MFaAXBJyXaUpDOnUWyDXvVkOxez(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}

		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = jQKDXoimuSpEWcCdpBenThEztXonA(controllerType);
			try
			{
				controllerMap.pgQbXDUmKkGKZAkRwZMiPjMIfDeGb(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
