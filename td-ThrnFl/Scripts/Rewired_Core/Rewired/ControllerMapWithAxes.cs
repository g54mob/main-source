using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerMapWithAxes : ControllerMap
	{
		private sealed class FQgHtBWZKqVaKynMIXMbtXIWdUVu : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int ncaDIUGJqVFrUTBRsfvXRsFSQqMQA;

			private ActionElementMap QvofyyGlFkGjLfzYNWjXOMrMaPiJ;

			private int BesBbLiZALBXBQPJVvUnCPrCbzlbb;

			public ControllerMapWithAxes YdRHiPaPNrTqiaxZyLjrvrvYrcgx;

			private int rzEdCQJCfAzOCiQSMTOxRucFeMxC;

			public int QLdhpofhbinGmfOYDMyrHPQyomZpc;

			private bool FczwRAQJCJJLDyjCfApURkFsxMrU;

			public bool ItPBSAMozlCyCaEWdfkMawNGEwBOA;

			private IEnumerator<ActionElementMap> lbDGlAXkxLLzQQJbngNVRHudDmFI;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return QvofyyGlFkGjLfzYNWjXOMrMaPiJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return QvofyyGlFkGjLfzYNWjXOMrMaPiJ;
				}
			}

			[DebuggerHidden]
			public FQgHtBWZKqVaKynMIXMbtXIWdUVu(int P_0)
			{
				ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = P_0;
				BesBbLiZALBXBQPJVvUnCPrCbzlbb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = ncaDIUGJqVFrUTBRsfvXRsFSQqMQA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						HvgDbtqdmTnmkMruddQJzSmfpDVn();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = ncaDIUGJqVFrUTBRsfvXRsFSQqMQA;
					ControllerMapWithAxes ydRHiPaPNrTqiaxZyLjrvrvYrcgx = YdRHiPaPNrTqiaxZyLjrvrvYrcgx;
					switch (num)
					{
					default:
						return false;
					case 0:
						ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = -1;
						if (ReInput._id != ydRHiPaPNrTqiaxZyLjrvrvYrcgx.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(ydRHiPaPNrTqiaxZyLjrvrvYrcgx.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						if (rzEdCQJCfAzOCiQSMTOxRucFeMxC < 0)
						{
							return false;
						}
						lbDGlAXkxLLzQQJbngNVRHudDmFI = ydRHiPaPNrTqiaxZyLjrvrvYrcgx.AxisMaps.GetEnumerator();
						ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = -3;
						break;
					case 1:
						ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = -3;
						break;
					}
					while (lbDGlAXkxLLzQQJbngNVRHudDmFI.MoveNext())
					{
						ActionElementMap current = lbDGlAXkxLLzQQJbngNVRHudDmFI.Current;
						if (current._actionId == rzEdCQJCfAzOCiQSMTOxRucFeMxC && (!FczwRAQJCJJLDyjCfApURkFsxMrU || current.IdtDkaTUBQdYslzoHMBnxOLemrRM))
						{
							QvofyyGlFkGjLfzYNWjXOMrMaPiJ = current;
							ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = 1;
							return true;
						}
					}
					HvgDbtqdmTnmkMruddQJzSmfpDVn();
					lbDGlAXkxLLzQQJbngNVRHudDmFI = null;
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

			private void HvgDbtqdmTnmkMruddQJzSmfpDVn()
			{
				ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = -1;
				if (lbDGlAXkxLLzQQJbngNVRHudDmFI != null)
				{
					lbDGlAXkxLLzQQJbngNVRHudDmFI.Dispose();
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
				FQgHtBWZKqVaKynMIXMbtXIWdUVu fQgHtBWZKqVaKynMIXMbtXIWdUVu;
				if (ncaDIUGJqVFrUTBRsfvXRsFSQqMQA == -2 && BesBbLiZALBXBQPJVvUnCPrCbzlbb == Environment.CurrentManagedThreadId)
				{
					ncaDIUGJqVFrUTBRsfvXRsFSQqMQA = 0;
					fQgHtBWZKqVaKynMIXMbtXIWdUVu = this;
				}
				else
				{
					fQgHtBWZKqVaKynMIXMbtXIWdUVu = new FQgHtBWZKqVaKynMIXMbtXIWdUVu(0);
					fQgHtBWZKqVaKynMIXMbtXIWdUVu.YdRHiPaPNrTqiaxZyLjrvrvYrcgx = YdRHiPaPNrTqiaxZyLjrvrvYrcgx;
				}
				fQgHtBWZKqVaKynMIXMbtXIWdUVu.rzEdCQJCfAzOCiQSMTOxRucFeMxC = QLdhpofhbinGmfOYDMyrHPQyomZpc;
				fQgHtBWZKqVaKynMIXMbtXIWdUVu.FczwRAQJCJJLDyjCfApURkFsxMrU = ItPBSAMozlCyCaEWdfkMawNGEwBOA;
				return fQgHtBWZKqVaKynMIXMbtXIWdUVu;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class ZhrHTZazFpOEDgivNFXdExgLhFqrA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int JkZghQDvYQpapBJCELPRlHzYRJxq;

			private ElementAssignmentConflictInfo iHzRbsLmFEgmgRDbmQyeunSumCJI;

			private int KYJUKoIAGVBmscmFeQdLchzWTWaM;

			public ControllerMapWithAxes TVvIoIhZuSfDoXFpTBKiHHbjTJZIA;

			private ControllerMap rZZaGngSEkqbayIrYmmHPwahSFLWA;

			public ControllerMap OSXdCvQvJklfbSQmYVsLkOtcBhOBA;

			private bool BaYMTCLJjtcLJpQcCBCkDXSakowd;

			public bool enBwJxwEwJrOqBfVcVQuGZVzLcZH;

			private IList<ActionElementMap> OQIceCxkjYlBcyRdUAqJGMwcCxfj;

			private int DpkeMtVnNLruLvTJdYahhAUWTlGB;

			private IEnumerator<ElementAssignmentConflictInfo> ZtWEZXtHhHlYgXrKijMlztVhcKgh;

			private int qgLgOZRnVlerwjmhLUfCSPkrRTAx;

			private ActionElementMap uhXgseuFIeirGisDqjCzHYSOVTiL;

			private int McCiCCFymedyCGuBAGDqTvQdKCLLc;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return iHzRbsLmFEgmgRDbmQyeunSumCJI;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return iHzRbsLmFEgmgRDbmQyeunSumCJI;
				}
			}

			[DebuggerHidden]
			public ZhrHTZazFpOEDgivNFXdExgLhFqrA(int P_0)
			{
				JkZghQDvYQpapBJCELPRlHzYRJxq = P_0;
				KYJUKoIAGVBmscmFeQdLchzWTWaM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int jkZghQDvYQpapBJCELPRlHzYRJxq = JkZghQDvYQpapBJCELPRlHzYRJxq;
				if (jkZghQDvYQpapBJCELPRlHzYRJxq == -3 || jkZghQDvYQpapBJCELPRlHzYRJxq == 1)
				{
					try
					{
					}
					finally
					{
						OtJUECnSZyIopVnrALhkMvxMjfSp();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int jkZghQDvYQpapBJCELPRlHzYRJxq = JkZghQDvYQpapBJCELPRlHzYRJxq;
					ControllerMapWithAxes tVvIoIhZuSfDoXFpTBKiHHbjTJZIA = TVvIoIhZuSfDoXFpTBKiHHbjTJZIA;
					switch (jkZghQDvYQpapBJCELPRlHzYRJxq)
					{
					default:
						return false;
					case 0:
						JkZghQDvYQpapBJCELPRlHzYRJxq = -1;
						if (ReInput._id != tVvIoIhZuSfDoXFpTBKiHHbjTJZIA.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(tVvIoIhZuSfDoXFpTBKiHHbjTJZIA.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						if (rZZaGngSEkqbayIrYmmHPwahSFLWA == null)
						{
							return false;
						}
						ZtWEZXtHhHlYgXrKijMlztVhcKgh = ((ControllerMap)tVvIoIhZuSfDoXFpTBKiHHbjTJZIA).ElementAssignmentConflicts(rZZaGngSEkqbayIrYmmHPwahSFLWA, BaYMTCLJjtcLJpQcCBCkDXSakowd).GetEnumerator();
						JkZghQDvYQpapBJCELPRlHzYRJxq = -3;
						goto IL_00af;
					case 1:
						JkZghQDvYQpapBJCELPRlHzYRJxq = -3;
						goto IL_00af;
					case 2:
						{
							JkZghQDvYQpapBJCELPRlHzYRJxq = -1;
							goto IL_0232;
						}
						IL_0244:
						if (McCiCCFymedyCGuBAGDqTvQdKCLLc < DpkeMtVnNLruLvTJdYahhAUWTlGB)
						{
							ActionElementMap actionElementMap = OQIceCxkjYlBcyRdUAqJGMwcCxfj[McCiCCFymedyCGuBAGDqTvQdKCLLc];
							if ((!BaYMTCLJjtcLJpQcCBCkDXSakowd || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && uhXgseuFIeirGisDqjCzHYSOVTiL.CheckForAssignmentConflict(actionElementMap))
							{
								iHzRbsLmFEgmgRDbmQyeunSumCJI = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(tVvIoIhZuSfDoXFpTBKiHHbjTJZIA._categoryId).userAssignable, -1, tVvIoIhZuSfDoXFpTBKiHHbjTJZIA._controllerType, tVvIoIhZuSfDoXFpTBKiHHbjTJZIA._controllerId, tVvIoIhZuSfDoXFpTBKiHHbjTJZIA._id, uhXgseuFIeirGisDqjCzHYSOVTiL.JtzYMpqdJGMyIjXIPHXXckWafklL, uhXgseuFIeirGisDqjCzHYSOVTiL._actionId, uhXgseuFIeirGisDqjCzHYSOVTiL._elementType, uhXgseuFIeirGisDqjCzHYSOVTiL._elementIdentifierId, uhXgseuFIeirGisDqjCzHYSOVTiL.keyCode, uhXgseuFIeirGisDqjCzHYSOVTiL.modifierKeyFlags);
								JkZghQDvYQpapBJCELPRlHzYRJxq = 2;
								return true;
							}
							goto IL_0232;
						}
						uhXgseuFIeirGisDqjCzHYSOVTiL = null;
						goto IL_025c;
						IL_0232:
						McCiCCFymedyCGuBAGDqTvQdKCLLc++;
						goto IL_0244;
						IL_026e:
						if (qgLgOZRnVlerwjmhLUfCSPkrRTAx < tVvIoIhZuSfDoXFpTBKiHHbjTJZIA.heefmnJwnAsndFhqylRYpRcfPmTg.Count)
						{
							uhXgseuFIeirGisDqjCzHYSOVTiL = tVvIoIhZuSfDoXFpTBKiHHbjTJZIA.heefmnJwnAsndFhqylRYpRcfPmTg[qgLgOZRnVlerwjmhLUfCSPkrRTAx];
							if (!BaYMTCLJjtcLJpQcCBCkDXSakowd || uhXgseuFIeirGisDqjCzHYSOVTiL.IdtDkaTUBQdYslzoHMBnxOLemrRM)
							{
								McCiCCFymedyCGuBAGDqTvQdKCLLc = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (ZtWEZXtHhHlYgXrKijMlztVhcKgh.MoveNext())
						{
							ElementAssignmentConflictInfo current = ZtWEZXtHhHlYgXrKijMlztVhcKgh.Current;
							iHzRbsLmFEgmgRDbmQyeunSumCJI = current;
							JkZghQDvYQpapBJCELPRlHzYRJxq = 1;
							return true;
						}
						OtJUECnSZyIopVnrALhkMvxMjfSp();
						ZtWEZXtHhHlYgXrKijMlztVhcKgh = null;
						if (!(rZZaGngSEkqbayIrYmmHPwahSFLWA is ControllerMapWithAxes controllerMapWithAxes))
						{
							return false;
						}
						if (BaYMTCLJjtcLJpQcCBCkDXSakowd && (!tVvIoIhZuSfDoXFpTBKiHHbjTJZIA._enabled || !controllerMapWithAxes._enabled))
						{
							return false;
						}
						OQIceCxkjYlBcyRdUAqJGMwcCxfj = controllerMapWithAxes.AxisMaps;
						if (OQIceCxkjYlBcyRdUAqJGMwcCxfj == null)
						{
							return false;
						}
						DpkeMtVnNLruLvTJdYahhAUWTlGB = OQIceCxkjYlBcyRdUAqJGMwcCxfj.Count;
						qgLgOZRnVlerwjmhLUfCSPkrRTAx = 0;
						goto IL_026e;
						IL_025c:
						qgLgOZRnVlerwjmhLUfCSPkrRTAx++;
						goto IL_026e;
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

			private void OtJUECnSZyIopVnrALhkMvxMjfSp()
			{
				JkZghQDvYQpapBJCELPRlHzYRJxq = -1;
				if (ZtWEZXtHhHlYgXrKijMlztVhcKgh != null)
				{
					ZtWEZXtHhHlYgXrKijMlztVhcKgh.Dispose();
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
				ZhrHTZazFpOEDgivNFXdExgLhFqrA zhrHTZazFpOEDgivNFXdExgLhFqrA;
				if (JkZghQDvYQpapBJCELPRlHzYRJxq == -2 && KYJUKoIAGVBmscmFeQdLchzWTWaM == Environment.CurrentManagedThreadId)
				{
					JkZghQDvYQpapBJCELPRlHzYRJxq = 0;
					zhrHTZazFpOEDgivNFXdExgLhFqrA = this;
				}
				else
				{
					zhrHTZazFpOEDgivNFXdExgLhFqrA = new ZhrHTZazFpOEDgivNFXdExgLhFqrA(0);
					zhrHTZazFpOEDgivNFXdExgLhFqrA.TVvIoIhZuSfDoXFpTBKiHHbjTJZIA = TVvIoIhZuSfDoXFpTBKiHHbjTJZIA;
				}
				zhrHTZazFpOEDgivNFXdExgLhFqrA.rZZaGngSEkqbayIrYmmHPwahSFLWA = OSXdCvQvJklfbSQmYVsLkOtcBhOBA;
				zhrHTZazFpOEDgivNFXdExgLhFqrA.BaYMTCLJjtcLJpQcCBCkDXSakowd = enBwJxwEwJrOqBfVcVQuGZVzLcZH;
				return zhrHTZazFpOEDgivNFXdExgLhFqrA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class EMkCaxotbghggCKVmynsrdHTGFZE : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int nCdSjdDBJfIRNVsLTRGpaLjFPrfr;

			private ElementAssignmentConflictInfo VzAGhdYAFaHyMMbLcnLEaotsGAWI;

			private int EgMJTZYOGzJwsguXraYctWoRLcOH;

			public ControllerMapWithAxes cgcxCyKTeBwgJkJQFcsouacffJYO;

			private ActionElementMap UmfBDBRhewrbzdwvspRafJNrKkhp;

			public ActionElementMap sSreTkArcpUsMmYgnsDfvvDpfvwPA;

			private bool nvGRxVNhMcpJOQepPujTqYrgdgSe;

			public bool tFBCdBqAvjaPzeXEvjGVhGazJZiK;

			private IEnumerator<ElementAssignmentConflictInfo> OGudynLreEiHXYtHILMbxrgcJCVb;

			private int lpKdYtmBVFwEbMiWRIctFubGMLVu;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return VzAGhdYAFaHyMMbLcnLEaotsGAWI;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return VzAGhdYAFaHyMMbLcnLEaotsGAWI;
				}
			}

			[DebuggerHidden]
			public EMkCaxotbghggCKVmynsrdHTGFZE(int P_0)
			{
				nCdSjdDBJfIRNVsLTRGpaLjFPrfr = P_0;
				EgMJTZYOGzJwsguXraYctWoRLcOH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = nCdSjdDBJfIRNVsLTRGpaLjFPrfr;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						CPTqMmOAUnhGSJSHESkXgRZPNsDb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = nCdSjdDBJfIRNVsLTRGpaLjFPrfr;
					ControllerMapWithAxes controllerMapWithAxes = cgcxCyKTeBwgJkJQFcsouacffJYO;
					switch (num)
					{
					default:
						return false;
					case 0:
						nCdSjdDBJfIRNVsLTRGpaLjFPrfr = -1;
						if (ReInput._id != controllerMapWithAxes.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						if (UmfBDBRhewrbzdwvspRafJNrKkhp == null)
						{
							return false;
						}
						OGudynLreEiHXYtHILMbxrgcJCVb = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(UmfBDBRhewrbzdwvspRafJNrKkhp, nvGRxVNhMcpJOQepPujTqYrgdgSe).GetEnumerator();
						nCdSjdDBJfIRNVsLTRGpaLjFPrfr = -3;
						goto IL_00ad;
					case 1:
						nCdSjdDBJfIRNVsLTRGpaLjFPrfr = -3;
						goto IL_00ad;
					case 2:
						{
							nCdSjdDBJfIRNVsLTRGpaLjFPrfr = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (OGudynLreEiHXYtHILMbxrgcJCVb.MoveNext())
						{
							ElementAssignmentConflictInfo current = OGudynLreEiHXYtHILMbxrgcJCVb.Current;
							VzAGhdYAFaHyMMbLcnLEaotsGAWI = current;
							nCdSjdDBJfIRNVsLTRGpaLjFPrfr = 1;
							return true;
						}
						CPTqMmOAUnhGSJSHESkXgRZPNsDb();
						OGudynLreEiHXYtHILMbxrgcJCVb = null;
						if (nvGRxVNhMcpJOQepPujTqYrgdgSe && (!controllerMapWithAxes._enabled || !UmfBDBRhewrbzdwvspRafJNrKkhp.IdtDkaTUBQdYslzoHMBnxOLemrRM))
						{
							return false;
						}
						if (controllerMapWithAxes.heefmnJwnAsndFhqylRYpRcfPmTg == null)
						{
							return false;
						}
						lpKdYtmBVFwEbMiWRIctFubGMLVu = 0;
						goto IL_01bb;
						IL_01bb:
						if (lpKdYtmBVFwEbMiWRIctFubGMLVu < controllerMapWithAxes.heefmnJwnAsndFhqylRYpRcfPmTg.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.heefmnJwnAsndFhqylRYpRcfPmTg[lpKdYtmBVFwEbMiWRIctFubGMLVu];
							if ((!nvGRxVNhMcpJOQepPujTqYrgdgSe || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(UmfBDBRhewrbzdwvspRafJNrKkhp))
							{
								VzAGhdYAFaHyMMbLcnLEaotsGAWI = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								nCdSjdDBJfIRNVsLTRGpaLjFPrfr = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						lpKdYtmBVFwEbMiWRIctFubGMLVu++;
						goto IL_01bb;
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

			private void CPTqMmOAUnhGSJSHESkXgRZPNsDb()
			{
				nCdSjdDBJfIRNVsLTRGpaLjFPrfr = -1;
				if (OGudynLreEiHXYtHILMbxrgcJCVb != null)
				{
					OGudynLreEiHXYtHILMbxrgcJCVb.Dispose();
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
				EMkCaxotbghggCKVmynsrdHTGFZE eMkCaxotbghggCKVmynsrdHTGFZE;
				if (nCdSjdDBJfIRNVsLTRGpaLjFPrfr == -2 && EgMJTZYOGzJwsguXraYctWoRLcOH == Environment.CurrentManagedThreadId)
				{
					nCdSjdDBJfIRNVsLTRGpaLjFPrfr = 0;
					eMkCaxotbghggCKVmynsrdHTGFZE = this;
				}
				else
				{
					eMkCaxotbghggCKVmynsrdHTGFZE = new EMkCaxotbghggCKVmynsrdHTGFZE(0);
					eMkCaxotbghggCKVmynsrdHTGFZE.cgcxCyKTeBwgJkJQFcsouacffJYO = cgcxCyKTeBwgJkJQFcsouacffJYO;
				}
				eMkCaxotbghggCKVmynsrdHTGFZE.UmfBDBRhewrbzdwvspRafJNrKkhp = sSreTkArcpUsMmYgnsDfvvDpfvwPA;
				eMkCaxotbghggCKVmynsrdHTGFZE.nvGRxVNhMcpJOQepPujTqYrgdgSe = tFBCdBqAvjaPzeXEvjGVhGazJZiK;
				return eMkCaxotbghggCKVmynsrdHTGFZE;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class eJPdTsWtWVeIGqEaIfAPDKyrCiMQ : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ordcHbxbAcbahiJzTFTMajWUpzzbA;

			private ElementAssignmentConflictInfo twGArVDJTUvHLLJSePXDfNMLkxdN;

			private int mPAQYjDyXGxJMJevDnHDXfipGlBT;

			public ControllerMapWithAxes ZfpUhUiPiYCnHjxdcQjoNWyriMXl;

			private ElementAssignmentConflictCheck fezEVjZkOPFwJYIsUbADNnzrKAdL;

			public ElementAssignmentConflictCheck hyzdiJvlLeymEFZYvIOfyianmjfg;

			private bool PjRWLGjrSriDiitYZolPZZUGDbJb;

			public bool JFhpKWdGQXAMpjGKhTjfTSgesILKA;

			private ElementAssignment lxCtaXFjrDsgqEpajBXbbmcEvqaZ;

			private IEnumerator<ElementAssignmentConflictInfo> zRGJEMfyajihQMEmzVEWicJmIQygA;

			private int dzjOtbJKnSXFTINfDFJOKWpsCQVI;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return twGArVDJTUvHLLJSePXDfNMLkxdN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return twGArVDJTUvHLLJSePXDfNMLkxdN;
				}
			}

			[DebuggerHidden]
			public eJPdTsWtWVeIGqEaIfAPDKyrCiMQ(int P_0)
			{
				ordcHbxbAcbahiJzTFTMajWUpzzbA = P_0;
				mPAQYjDyXGxJMJevDnHDXfipGlBT = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = ordcHbxbAcbahiJzTFTMajWUpzzbA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						qlPecIjvCUTefCNvIadlTbVAAjPlA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = ordcHbxbAcbahiJzTFTMajWUpzzbA;
					ControllerMapWithAxes zfpUhUiPiYCnHjxdcQjoNWyriMXl = ZfpUhUiPiYCnHjxdcQjoNWyriMXl;
					switch (num)
					{
					default:
						return false;
					case 0:
						ordcHbxbAcbahiJzTFTMajWUpzzbA = -1;
						if (ReInput._id != zfpUhUiPiYCnHjxdcQjoNWyriMXl.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(zfpUhUiPiYCnHjxdcQjoNWyriMXl.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						zRGJEMfyajihQMEmzVEWicJmIQygA = ((ControllerMap)zfpUhUiPiYCnHjxdcQjoNWyriMXl).ElementAssignmentConflicts(fezEVjZkOPFwJYIsUbADNnzrKAdL, PjRWLGjrSriDiitYZolPZZUGDbJb).GetEnumerator();
						ordcHbxbAcbahiJzTFTMajWUpzzbA = -3;
						goto IL_009e;
					case 1:
						ordcHbxbAcbahiJzTFTMajWUpzzbA = -3;
						goto IL_009e;
					case 2:
						{
							ordcHbxbAcbahiJzTFTMajWUpzzbA = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (dzjOtbJKnSXFTINfDFJOKWpsCQVI < zfpUhUiPiYCnHjxdcQjoNWyriMXl.heefmnJwnAsndFhqylRYpRcfPmTg.Count)
						{
							ActionElementMap actionElementMap = zfpUhUiPiYCnHjxdcQjoNWyriMXl.heefmnJwnAsndFhqylRYpRcfPmTg[dzjOtbJKnSXFTINfDFJOKWpsCQVI];
							if ((!PjRWLGjrSriDiitYZolPZZUGDbJb || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != fezEVjZkOPFwJYIsUbADNnzrKAdL.elementMapId && actionElementMap.CheckForAssignmentConflict(lxCtaXFjrDsgqEpajBXbbmcEvqaZ))
							{
								twGArVDJTUvHLLJSePXDfNMLkxdN = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(zfpUhUiPiYCnHjxdcQjoNWyriMXl._categoryId).userAssignable, -1, zfpUhUiPiYCnHjxdcQjoNWyriMXl._controllerType, zfpUhUiPiYCnHjxdcQjoNWyriMXl._controllerId, zfpUhUiPiYCnHjxdcQjoNWyriMXl._id, actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								ordcHbxbAcbahiJzTFTMajWUpzzbA = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (zRGJEMfyajihQMEmzVEWicJmIQygA.MoveNext())
						{
							ElementAssignmentConflictInfo current = zRGJEMfyajihQMEmzVEWicJmIQygA.Current;
							twGArVDJTUvHLLJSePXDfNMLkxdN = current;
							ordcHbxbAcbahiJzTFTMajWUpzzbA = 1;
							return true;
						}
						qlPecIjvCUTefCNvIadlTbVAAjPlA();
						zRGJEMfyajihQMEmzVEWicJmIQygA = null;
						if (PjRWLGjrSriDiitYZolPZZUGDbJb && !zfpUhUiPiYCnHjxdcQjoNWyriMXl._enabled)
						{
							return false;
						}
						if (zfpUhUiPiYCnHjxdcQjoNWyriMXl.heefmnJwnAsndFhqylRYpRcfPmTg == null)
						{
							return false;
						}
						lxCtaXFjrDsgqEpajBXbbmcEvqaZ = fezEVjZkOPFwJYIsUbADNnzrKAdL.ToElementAssignment();
						dzjOtbJKnSXFTINfDFJOKWpsCQVI = 0;
						goto IL_01c7;
						IL_01b5:
						dzjOtbJKnSXFTINfDFJOKWpsCQVI++;
						goto IL_01c7;
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

			private void qlPecIjvCUTefCNvIadlTbVAAjPlA()
			{
				ordcHbxbAcbahiJzTFTMajWUpzzbA = -1;
				if (zRGJEMfyajihQMEmzVEWicJmIQygA != null)
				{
					zRGJEMfyajihQMEmzVEWicJmIQygA.Dispose();
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
				eJPdTsWtWVeIGqEaIfAPDKyrCiMQ eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2;
				if (ordcHbxbAcbahiJzTFTMajWUpzzbA == -2 && mPAQYjDyXGxJMJevDnHDXfipGlBT == Environment.CurrentManagedThreadId)
				{
					ordcHbxbAcbahiJzTFTMajWUpzzbA = 0;
					eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2 = this;
				}
				else
				{
					eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2 = new eJPdTsWtWVeIGqEaIfAPDKyrCiMQ(0);
					eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2.ZfpUhUiPiYCnHjxdcQjoNWyriMXl = ZfpUhUiPiYCnHjxdcQjoNWyriMXl;
				}
				eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2.fezEVjZkOPFwJYIsUbADNnzrKAdL = hyzdiJvlLeymEFZYvIOfyianmjfg;
				eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2.PjRWLGjrSriDiitYZolPZZUGDbJb = JFhpKWdGQXAMpjGKhTjfTSgesILKA;
				return eJPdTsWtWVeIGqEaIfAPDKyrCiMQ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> heefmnJwnAsndFhqylRYpRcfPmTg;

		private readonly ReadOnlyCollection<ActionElementMap> PjoJYljEErujtfHMphPpBzKrLDad;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return 0;
				}
				if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
				{
					return 0;
				}
				return heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return PjoJYljEErujtfHMphPpBzKrLDad;
			}
		}

		internal AList<ActionElementMap> FVvHzSvPZciZtfhxafuWoQECqRce => (AList<ActionElementMap>)heefmnJwnAsndFhqylRYpRcfPmTg;

		public ControllerMapWithAxes()
		{
			heefmnJwnAsndFhqylRYpRcfPmTg = new AList<ActionElementMap>();
			PjoJYljEErujtfHMphPpBzKrLDad = new ReadOnlyCollection<ActionElementMap>(heefmnJwnAsndFhqylRYpRcfPmTg);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			heefmnJwnAsndFhqylRYpRcfPmTg = new AList<ActionElementMap>();
			PjoJYljEErujtfHMphPpBzKrLDad = new ReadOnlyCollection<ActionElementMap>(heefmnJwnAsndFhqylRYpRcfPmTg);
			if (P_0.heefmnJwnAsndFhqylRYpRcfPmTg != null)
			{
				int count = P_0.heefmnJwnAsndFhqylRYpRcfPmTg.Count;
				for (int i = 0; i < count; i++)
				{
					xTSmaZbgFkVMThKcFuiGhoquYRkH(new ActionElementMap(P_0.heefmnJwnAsndFhqylRYpRcfPmTg[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return false;
			}
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				if (heefmnJwnAsndFhqylRYpRcfPmTg[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			xTSmaZbgFkVMThKcFuiGhoquYRkH(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				xTSmaZbgFkVMThKcFuiGhoquYRkH(elementMap);
			}
			if (sliBfaMtVySSUCWglatHHnsmcPmB(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.dPlbLqJPIpqKVByoBbxwKcPmmhrac(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = sliBfaMtVySSUCWglatHHnsmcPmB(elementMapId);
			if (num < 0)
			{
				return false;
			}
			XOiBokAEkTQzDiwLTnfmVcBMChOHb(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return null;
			}
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				if (heefmnJwnAsndFhqylRYpRcfPmTg[i].JtzYMpqdJGMyIjXIPHXXckWafklL == elementMapId)
				{
					return heefmnJwnAsndFhqylRYpRcfPmTg[i];
				}
			}
			return null;
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
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
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap amQKwePITZzEJKISXVpvFRxFscbh(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.NRywdmgQRRPVQktRbNMmmpfgXffv(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return ObUUIXnNuPJsrjqKjYOZTlDYioPI(P_0, P_1);
		}

		internal virtual int hfydqQcqiFrUInmJfzlAjFualOBz(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.FvRJBZpHmtrKIZhJYtShooONUZwU(P_0, P_1, P_2, P_3) + XIxYMIDMonepouFpRUDxbFsxefcCA(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return;
			}
			base.ClearElementMaps();
			heefmnJwnAsndFhqylRYpRcfPmTg.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null || index < 0 || index >= heefmnJwnAsndFhqylRYpRcfPmTg.Count)
			{
				return null;
			}
			return heefmnJwnAsndFhqylRYpRcfPmTg[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(heefmnJwnAsndFhqylRYpRcfPmTg);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return OOBoCDCdlhfQkhQAQMoxWMCIOhjSA(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
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
				ActionElementMap actionElementMap2 = heefmnJwnAsndFhqylRYpRcfPmTg[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return zAdIrIPxfpJpvWgDHYHaQkdADeCG(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(FQgHtBWZKqVaKynMIXMbtXIWdUVu))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new FQgHtBWZKqVaKynMIXMbtXIWdUVu(-2)
			{
				YdRHiPaPNrTqiaxZyLjrvrvYrcgx = this,
				QLdhpofhbinGmfOYDMyrHPQyomZpc = actionId,
				ItPBSAMozlCyCaEWdfkMawNGEwBOA = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			return ObUUIXnNuPJsrjqKjYOZTlDYioPI(predicate, false);
		}

		internal ActionElementMap ObUUIXnNuPJsrjqKjYOZTlDYioPI(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num = axisMapCount;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
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
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return XIxYMIDMonepouFpRUDxbFsxefcCA(predicate, false, results, false);
		}

		internal int XIxYMIDMonepouFpRUDxbFsxefcCA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num2 = axisMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetAxisMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachAxisMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
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
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = heefmnJwnAsndFhqylRYpRcfPmTg[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
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
			return DeleteAxisMapsWithAction(ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
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
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (heefmnJwnAsndFhqylRYpRcfPmTg[num2] != null && heefmnJwnAsndFhqylRYpRcfPmTg[num2]._actionId == actionId)
				{
					XOiBokAEkTQzDiwLTnfmVcBMChOHb(heefmnJwnAsndFhqylRYpRcfPmTg[num2].JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int num = 0;
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM != state)
				{
					actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
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
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return false;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (skipDisabledMaps && !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (actionElementMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
			{
				return false;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return false;
			}
			for (int i = 0; i < heefmnJwnAsndFhqylRYpRcfPmTg.Count; i++)
			{
				ActionElementMap actionElementMap2 = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
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
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < heefmnJwnAsndFhqylRYpRcfPmTg.Count; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if ((!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(ZhrHTZazFpOEDgivNFXdExgLhFqrA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new ZhrHTZazFpOEDgivNFXdExgLhFqrA(-2)
			{
				TVvIoIhZuSfDoXFpTBKiHHbjTJZIA = this,
				OSXdCvQvJklfbSQmYVsLkOtcBhOBA = controllerMap,
				enBwJxwEwJrOqBfVcVQuGZVzLcZH = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(EMkCaxotbghggCKVmynsrdHTGFZE))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new EMkCaxotbghggCKVmynsrdHTGFZE(-2)
			{
				cgcxCyKTeBwgJkJQFcsouacffJYO = this,
				sSreTkArcpUsMmYgnsDfvvDpfvwPA = actionElementMap,
				tFBCdBqAvjaPzeXEvjGVhGazJZiK = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(eJPdTsWtWVeIGqEaIfAPDKyrCiMQ))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new eJPdTsWtWVeIGqEaIfAPDKyrCiMQ(-2)
			{
				ZfpUhUiPiYCnHjxdcQjoNWyriMXl = this,
				hyzdiJvlLeymEFZYvIOfyianmjfg = conflictCheck,
				JFhpKWdGQXAMpjGKhTjfTSgesILKA = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			int count = axisMaps.Count;
			for (int num2 = heefmnJwnAsndFhqylRYpRcfPmTg.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[num2];
				if (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							XOiBokAEkTQzDiwLTnfmVcBMChOHb(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
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
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return num;
			}
			for (int num2 = heefmnJwnAsndFhqylRYpRcfPmTg.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = heefmnJwnAsndFhqylRYpRcfPmTg[num2];
				if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					XOiBokAEkTQzDiwLTnfmVcBMChOHb(actionElementMap2.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return num;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
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
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int num2 = heefmnJwnAsndFhqylRYpRcfPmTg.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[num2];
				if ((!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					XOiBokAEkTQzDiwLTnfmVcBMChOHb(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int hNpMRtijaMvYxHpMGHPdvpiNeCcV(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.ItCUGWipsbSXnwPaLdhDyEkLPfzc(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (!actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int LXvBZGBtNrTCansYjMbBizxhppxCc(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.APpATFydmqdisQTNkPBnodjHbwzp(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.IdtDkaTUBQdYslzoHMBnxOLemrRM))
			{
				return num;
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
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int oPVabSHxVjbJPkovCfWVCmrEzObQ(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.aHLeYxerPeUnYNeIEbCAvvtUSnFN(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return num;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.FullAxis && P_0.elementAssignmentType != ElementAssignmentType.SplitAxis)
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
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public string[] GetAxisNames()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<string>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = heefmnJwnAsndFhqylRYpRcfPmTg[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool XMUWRrhQJZVsqbAeNFBrKCQZNVWb(ActionElementMap P_0)
		{
			if (base.oFdZMpJjJyspammNnQEQXfobMABp(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(elementType))
			{
				return false;
			}
			xTSmaZbgFkVMThKcFuiGhoquYRkH(P_0);
			return true;
		}

		internal virtual int xRQcPLFIodlmjgeUIQOLywnFVkwjb(List<ActionElementMap> P_0, bool P_1)
		{
			base.UjKRdpolAWgWhIhFNERzeONGPEKGb(P_0, P_1);
			int count = P_0.Count;
			int count2 = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || heefmnJwnAsndFhqylRYpRcfPmTg[i].IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					P_0.Add(heefmnJwnAsndFhqylRYpRcfPmTg[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap NrSsYhZvfgQKOyAbKRmaEebLCvGL(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.pemGBSalQNQYjohYAGBTankGHslaA(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(P_2))
			{
				return null;
			}
			int num = PNaJsMzrSfaVlzqIatuEyErhVDGE(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return heefmnJwnAsndFhqylRYpRcfPmTg[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int VucCUgxZGLotISCICTBdFBmTHktG(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.GFPBGygEJGRDENNwiJIkHlTcrEis(P_0, P_1, P_2);
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return P_1.Count - num;
			}
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				if (heefmnJwnAsndFhqylRYpRcfPmTg[i]._elementIdentifierId == P_0)
				{
					P_1.Add(heefmnJwnAsndFhqylRYpRcfPmTg[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool VUDOgqZeKmhngRteyErzpjisfdZJ(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.NnZBpgBBcNqbCrOiWLJipZMsNMtj(P_0, P_1, P_2))
			{
				return true;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
				for (int i = 0; i < count; i++)
				{
					if (heefmnJwnAsndFhqylRYpRcfPmTg[i]._elementIdentifierId == P_0 && heefmnJwnAsndFhqylRYpRcfPmTg[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int BHocpjitYWwSIksciQIUhqCWAdJA(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.PNaJsMzrSfaVlzqIatuEyErhVDGE(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(P_2))
			{
				return -1;
			}
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
				for (int i = 0; i < count; i++)
				{
					if (heefmnJwnAsndFhqylRYpRcfPmTg[i]._elementIdentifierId == P_0 && heefmnJwnAsndFhqylRYpRcfPmTg[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int sliBfaMtVySSUCWglatHHnsmcPmB(int P_0)
		{
			if (heefmnJwnAsndFhqylRYpRcfPmTg == null)
			{
				return -1;
			}
			int count = heefmnJwnAsndFhqylRYpRcfPmTg.Count;
			for (int i = 0; i < count; i++)
			{
				if (heefmnJwnAsndFhqylRYpRcfPmTg[i].JtzYMpqdJGMyIjXIPHXXckWafklL == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int OOBoCDCdlhfQkhQAQMoxWMCIOhjSA(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = axisMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (!P_0 || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int zAdIrIPxfpJpvWgDHYHaQkdADeCG(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int num = axisMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int yzTjqrylGSgfKcUmnHnGncSHdBJH(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.cZhlovFicBbegtZKBDXbQpHySFih(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = heefmnJwnAsndFhqylRYpRcfPmTg[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap NxaGJHCzUsbYJsMejjDWinCYmWJN(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.daBPlcrTfpFvPZUhwqVBCZWmbSyH(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || heefmnJwnAsndFhqylRYpRcfPmTg[i]._actionId == P_2) && (!P_3 || heefmnJwnAsndFhqylRYpRcfPmTg[i].IdtDkaTUBQdYslzoHMBnxOLemrRM) && heefmnJwnAsndFhqylRYpRcfPmTg[i].IsTarget(P_0))
				{
					return heefmnJwnAsndFhqylRYpRcfPmTg[i];
				}
			}
			return null;
		}

		internal virtual int HihlBEsPWTQNBZzhYVnQjqVuhGRr(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.UlFArbKTYQdEqAtLPNCFxsiTzHnb(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || heefmnJwnAsndFhqylRYpRcfPmTg[i]._actionId == P_2) && (!P_3 || heefmnJwnAsndFhqylRYpRcfPmTg[i].IdtDkaTUBQdYslzoHMBnxOLemrRM) && heefmnJwnAsndFhqylRYpRcfPmTg[i].IsTarget(P_0))
				{
					P_4.Add(heefmnJwnAsndFhqylRYpRcfPmTg[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool ASRFFXetgINNuGBxHFMynRGMtaTfb(ActionElementMap P_0)
		{
			if (base.rABROfEDwiWxichKRjAJaMtoqWMo(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!cmeaGaBgnsaqNvqFgipmCxIbHTenA(P_0._elementType))
			{
				return false;
			}
			heefmnJwnAsndFhqylRYpRcfPmTg.Add(P_0);
			pomCAwjEmQpDobmuvwRNpcKrsivIA(P_0);
			return true;
		}

		private bool cmeaGaBgnsaqNvqFgipmCxIbHTenA(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void XOiBokAEkTQzDiwLTnfmVcBMChOHb(int P_0, int P_1)
		{
			bwcafwKatcNdtKlmLOmQWWDqMRBc(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				heefmnJwnAsndFhqylRYpRcfPmTg.RemoveAt(P_1);
			}
		}

		private void xTSmaZbgFkVMThKcFuiGhoquYRkH(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				heefmnJwnAsndFhqylRYpRcfPmTg.Add(P_0);
				pomCAwjEmQpDobmuvwRNpcKrsivIA(P_0);
			}
		}

		private void rOtFmUIOjZGHcxIFUCxNNqumsquVA(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				TyaQRWFMelqyoPCgqRNbwsdTfYigA(heefmnJwnAsndFhqylRYpRcfPmTg[P_1].JtzYMpqdJGMyIjXIPHXXckWafklL, P_0);
				heefmnJwnAsndFhqylRYpRcfPmTg[P_1] = P_0;
			}
		}

		internal virtual void gdmDLiKYfbPmESIKsHHiUgjqiktq(SerializedObject P_0)
		{
			base.DlmSYCzIIucAJHOoZCCoIGfCWPMK(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (heefmnJwnAsndFhqylRYpRcfPmTg[i] != null)
				{
					list.Add(heefmnJwnAsndFhqylRYpRcfPmTg[i].ZbfJTMRtbmDfNrFSMKKfiGzhjUdo());
				}
			}
		}

		internal virtual bool qwvPOxwLkTaALoYPCFliwVkicJgA(SerializedObject P_0)
		{
			bool flag = base.kCvDSGukbMnBdmPCsgkebjtPzZQF(P_0);
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("axisMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.PrgcKkEfUlCmHYYlVROGdYJqqrgqA(value2);
						if (ActionElementMap.FafLWUVisEGIhtnPwShoQNryjuiw(actionElementMap))
						{
							xTSmaZbgFkVMThKcFuiGhoquYRkH(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> HYySrTzmBRTSnOiEOnmdKNfxygBG(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> wQjzozWWawmBplfgmExnKNypctBY(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> oRmtjyPKXOfdONVrzvomDFqpEyFQ(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
