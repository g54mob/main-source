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
		private sealed class xzdWIkJlKcXekloZTNWIMkqTiIzl : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int PGvfvrCyKLCFkGdUlwQoRnhNGJkj;

			private ActionElementMap cNtKMFLmPyBrfduXOrNyffLPUKUUA;

			private int bpxCBkYWwJegjIEDKHFQgdHZNiHg;

			public ControllerMapWithAxes qmMVkyfKJxJjOdsIxkLOCMRBELKg;

			private int VtLzEhEVWEQLgrcHRAUOeeEMaALV;

			public int uXyWZNivrinbKHZXRhVYuekhWpzd;

			private bool vxidTdJHINYkdNjDgosdJktjqiXhA;

			public bool sDIuptPDtrFFcDtHombfyFxXmSbCA;

			private IEnumerator<ActionElementMap> PvCDvlQXxTgoeIVwwWbeGaEajrjDb;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return cNtKMFLmPyBrfduXOrNyffLPUKUUA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cNtKMFLmPyBrfduXOrNyffLPUKUUA;
				}
			}

			[DebuggerHidden]
			public xzdWIkJlKcXekloZTNWIMkqTiIzl(int P_0)
			{
				PGvfvrCyKLCFkGdUlwQoRnhNGJkj = P_0;
				bpxCBkYWwJegjIEDKHFQgdHZNiHg = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int pGvfvrCyKLCFkGdUlwQoRnhNGJkj = PGvfvrCyKLCFkGdUlwQoRnhNGJkj;
				if (pGvfvrCyKLCFkGdUlwQoRnhNGJkj == -3 || pGvfvrCyKLCFkGdUlwQoRnhNGJkj == 1)
				{
					try
					{
					}
					finally
					{
						ljbWcYpNwHVJSVMrwJscMOSyrUtD();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int pGvfvrCyKLCFkGdUlwQoRnhNGJkj = PGvfvrCyKLCFkGdUlwQoRnhNGJkj;
					ControllerMapWithAxes controllerMapWithAxes = qmMVkyfKJxJjOdsIxkLOCMRBELKg;
					switch (pGvfvrCyKLCFkGdUlwQoRnhNGJkj)
					{
					default:
						return false;
					case 0:
						PGvfvrCyKLCFkGdUlwQoRnhNGJkj = -1;
						if (ReInput._id != controllerMapWithAxes.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						if (VtLzEhEVWEQLgrcHRAUOeeEMaALV < 0)
						{
							return false;
						}
						PvCDvlQXxTgoeIVwwWbeGaEajrjDb = controllerMapWithAxes.AxisMaps.GetEnumerator();
						PGvfvrCyKLCFkGdUlwQoRnhNGJkj = -3;
						break;
					case 1:
						PGvfvrCyKLCFkGdUlwQoRnhNGJkj = -3;
						break;
					}
					while (PvCDvlQXxTgoeIVwwWbeGaEajrjDb.MoveNext())
					{
						ActionElementMap current = PvCDvlQXxTgoeIVwwWbeGaEajrjDb.Current;
						if (current._actionId == VtLzEhEVWEQLgrcHRAUOeeEMaALV && (!vxidTdJHINYkdNjDgosdJktjqiXhA || current.amuHcHIpLQrjMsPzQKBWApxhXPxj))
						{
							cNtKMFLmPyBrfduXOrNyffLPUKUUA = current;
							PGvfvrCyKLCFkGdUlwQoRnhNGJkj = 1;
							return true;
						}
					}
					ljbWcYpNwHVJSVMrwJscMOSyrUtD();
					PvCDvlQXxTgoeIVwwWbeGaEajrjDb = null;
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

			private void ljbWcYpNwHVJSVMrwJscMOSyrUtD()
			{
				PGvfvrCyKLCFkGdUlwQoRnhNGJkj = -1;
				if (PvCDvlQXxTgoeIVwwWbeGaEajrjDb != null)
				{
					PvCDvlQXxTgoeIVwwWbeGaEajrjDb.Dispose();
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
				xzdWIkJlKcXekloZTNWIMkqTiIzl xzdWIkJlKcXekloZTNWIMkqTiIzl2;
				if (PGvfvrCyKLCFkGdUlwQoRnhNGJkj == -2 && bpxCBkYWwJegjIEDKHFQgdHZNiHg == Environment.CurrentManagedThreadId)
				{
					PGvfvrCyKLCFkGdUlwQoRnhNGJkj = 0;
					xzdWIkJlKcXekloZTNWIMkqTiIzl2 = this;
				}
				else
				{
					xzdWIkJlKcXekloZTNWIMkqTiIzl2 = new xzdWIkJlKcXekloZTNWIMkqTiIzl(0);
					xzdWIkJlKcXekloZTNWIMkqTiIzl2.qmMVkyfKJxJjOdsIxkLOCMRBELKg = qmMVkyfKJxJjOdsIxkLOCMRBELKg;
				}
				xzdWIkJlKcXekloZTNWIMkqTiIzl2.VtLzEhEVWEQLgrcHRAUOeeEMaALV = uXyWZNivrinbKHZXRhVYuekhWpzd;
				xzdWIkJlKcXekloZTNWIMkqTiIzl2.vxidTdJHINYkdNjDgosdJktjqiXhA = sDIuptPDtrFFcDtHombfyFxXmSbCA;
				return xzdWIkJlKcXekloZTNWIMkqTiIzl2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class vvogWsbbRrvHzdFsAESKKnGKNdUs : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int nyCODhCvWYVTTMtNFEZqMkNNjMJF;

			private ElementAssignmentConflictInfo SseegJYADUFBQhOqtpTXDXodjIvRb;

			private int gKCPbLVDMBwVChPAzBwwPjTPbcGr;

			public ControllerMapWithAxes xJoNblkIoGgWMMHmWALFeyPwOjly;

			private ControllerMap TeWzEGFiEmYhYNrwRnRiXAOkxHpH;

			public ControllerMap gDATxYFsZyfEVNHfJFpqINPxeDapA;

			private bool jpFwbyUSPvIRdqpHZaUHEwrzRMIOA;

			public bool McEINAGjcNaKGdCSflQNgnnecfafE;

			private IList<ActionElementMap> wFHELlcmbEROYFveVvXaZdOxlsDVA;

			private int derxVjCWvTeCMaLScFHPIXmDaxZx;

			private IEnumerator<ElementAssignmentConflictInfo> zkTFhyiofTaGWKMPfhcUWGpiDUGbA;

			private int EoMrOuWTRlQOMoeqUqpfvaUkvXgL;

			private ActionElementMap OZCMDFhlAmYRcnAWneXIipsXFrIP;

			private int enFdVftFyeXzaldMNUHBUUmFqZfh;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return SseegJYADUFBQhOqtpTXDXodjIvRb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SseegJYADUFBQhOqtpTXDXodjIvRb;
				}
			}

			[DebuggerHidden]
			public vvogWsbbRrvHzdFsAESKKnGKNdUs(int P_0)
			{
				nyCODhCvWYVTTMtNFEZqMkNNjMJF = P_0;
				gKCPbLVDMBwVChPAzBwwPjTPbcGr = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = nyCODhCvWYVTTMtNFEZqMkNNjMJF;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						oUfznwoLsJcJIByBBaFvcJVGJkdA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = nyCODhCvWYVTTMtNFEZqMkNNjMJF;
					ControllerMapWithAxes controllerMapWithAxes = xJoNblkIoGgWMMHmWALFeyPwOjly;
					switch (num)
					{
					default:
						return false;
					case 0:
						nyCODhCvWYVTTMtNFEZqMkNNjMJF = -1;
						if (ReInput._id != controllerMapWithAxes.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						if (TeWzEGFiEmYhYNrwRnRiXAOkxHpH == null)
						{
							return false;
						}
						zkTFhyiofTaGWKMPfhcUWGpiDUGbA = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(TeWzEGFiEmYhYNrwRnRiXAOkxHpH, jpFwbyUSPvIRdqpHZaUHEwrzRMIOA).GetEnumerator();
						nyCODhCvWYVTTMtNFEZqMkNNjMJF = -3;
						goto IL_00af;
					case 1:
						nyCODhCvWYVTTMtNFEZqMkNNjMJF = -3;
						goto IL_00af;
					case 2:
						{
							nyCODhCvWYVTTMtNFEZqMkNNjMJF = -1;
							goto IL_0232;
						}
						IL_0244:
						if (enFdVftFyeXzaldMNUHBUUmFqZfh < derxVjCWvTeCMaLScFHPIXmDaxZx)
						{
							ActionElementMap actionElementMap = wFHELlcmbEROYFveVvXaZdOxlsDVA[enFdVftFyeXzaldMNUHBUUmFqZfh];
							if ((!jpFwbyUSPvIRdqpHZaUHEwrzRMIOA || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && OZCMDFhlAmYRcnAWneXIipsXFrIP.CheckForAssignmentConflict(actionElementMap))
							{
								SseegJYADUFBQhOqtpTXDXodjIvRb = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, OZCMDFhlAmYRcnAWneXIipsXFrIP.xYazCGhLJSNpewHjYMCgVGmvJCJk, OZCMDFhlAmYRcnAWneXIipsXFrIP._actionId, OZCMDFhlAmYRcnAWneXIipsXFrIP._elementType, OZCMDFhlAmYRcnAWneXIipsXFrIP._elementIdentifierId, OZCMDFhlAmYRcnAWneXIipsXFrIP.keyCode, OZCMDFhlAmYRcnAWneXIipsXFrIP.modifierKeyFlags);
								nyCODhCvWYVTTMtNFEZqMkNNjMJF = 2;
								return true;
							}
							goto IL_0232;
						}
						OZCMDFhlAmYRcnAWneXIipsXFrIP = null;
						goto IL_025c;
						IL_0232:
						enFdVftFyeXzaldMNUHBUUmFqZfh++;
						goto IL_0244;
						IL_026e:
						if (EoMrOuWTRlQOMoeqUqpfvaUkvXgL < controllerMapWithAxes.DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count)
						{
							OZCMDFhlAmYRcnAWneXIipsXFrIP = controllerMapWithAxes.DqbiEKKNzCfRLANvvimzQiCuGfnZ[EoMrOuWTRlQOMoeqUqpfvaUkvXgL];
							if (!jpFwbyUSPvIRdqpHZaUHEwrzRMIOA || OZCMDFhlAmYRcnAWneXIipsXFrIP.amuHcHIpLQrjMsPzQKBWApxhXPxj)
							{
								enFdVftFyeXzaldMNUHBUUmFqZfh = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (zkTFhyiofTaGWKMPfhcUWGpiDUGbA.MoveNext())
						{
							ElementAssignmentConflictInfo current = zkTFhyiofTaGWKMPfhcUWGpiDUGbA.Current;
							SseegJYADUFBQhOqtpTXDXodjIvRb = current;
							nyCODhCvWYVTTMtNFEZqMkNNjMJF = 1;
							return true;
						}
						oUfznwoLsJcJIByBBaFvcJVGJkdA();
						zkTFhyiofTaGWKMPfhcUWGpiDUGbA = null;
						if (!(TeWzEGFiEmYhYNrwRnRiXAOkxHpH is ControllerMapWithAxes controllerMapWithAxes2))
						{
							return false;
						}
						if (jpFwbyUSPvIRdqpHZaUHEwrzRMIOA && (!controllerMapWithAxes._enabled || !controllerMapWithAxes2._enabled))
						{
							return false;
						}
						wFHELlcmbEROYFveVvXaZdOxlsDVA = controllerMapWithAxes2.AxisMaps;
						if (wFHELlcmbEROYFveVvXaZdOxlsDVA == null)
						{
							return false;
						}
						derxVjCWvTeCMaLScFHPIXmDaxZx = wFHELlcmbEROYFveVvXaZdOxlsDVA.Count;
						EoMrOuWTRlQOMoeqUqpfvaUkvXgL = 0;
						goto IL_026e;
						IL_025c:
						EoMrOuWTRlQOMoeqUqpfvaUkvXgL++;
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

			private void oUfznwoLsJcJIByBBaFvcJVGJkdA()
			{
				nyCODhCvWYVTTMtNFEZqMkNNjMJF = -1;
				if (zkTFhyiofTaGWKMPfhcUWGpiDUGbA != null)
				{
					zkTFhyiofTaGWKMPfhcUWGpiDUGbA.Dispose();
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
				vvogWsbbRrvHzdFsAESKKnGKNdUs vvogWsbbRrvHzdFsAESKKnGKNdUs2;
				if (nyCODhCvWYVTTMtNFEZqMkNNjMJF == -2 && gKCPbLVDMBwVChPAzBwwPjTPbcGr == Environment.CurrentManagedThreadId)
				{
					nyCODhCvWYVTTMtNFEZqMkNNjMJF = 0;
					vvogWsbbRrvHzdFsAESKKnGKNdUs2 = this;
				}
				else
				{
					vvogWsbbRrvHzdFsAESKKnGKNdUs2 = new vvogWsbbRrvHzdFsAESKKnGKNdUs(0);
					vvogWsbbRrvHzdFsAESKKnGKNdUs2.xJoNblkIoGgWMMHmWALFeyPwOjly = xJoNblkIoGgWMMHmWALFeyPwOjly;
				}
				vvogWsbbRrvHzdFsAESKKnGKNdUs2.TeWzEGFiEmYhYNrwRnRiXAOkxHpH = gDATxYFsZyfEVNHfJFpqINPxeDapA;
				vvogWsbbRrvHzdFsAESKKnGKNdUs2.jpFwbyUSPvIRdqpHZaUHEwrzRMIOA = McEINAGjcNaKGdCSflQNgnnecfafE;
				return vvogWsbbRrvHzdFsAESKKnGKNdUs2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class eBhbpXIfxsuASGVDdCvTUUDWuupdA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int JOyMxUKRLzpyfEHQIuFMFNHGVPXO;

			private ElementAssignmentConflictInfo tUJdrGfBFeSambTQkhwfaPHnxgwEc;

			private int exThasBEClmkSrkOaEfTKTICvxit;

			public ControllerMapWithAxes ABbEQJHRFFsHvjRFUGvXEPOkrfwdA;

			private ActionElementMap qyiReqOVmutCVipqnASBWuhoBEJQ;

			public ActionElementMap GYsybBkFwfZteXQnoOuUUszsFbIh;

			private bool JjDgwqEEloFKyMDnUHxypNwdxZqIA;

			public bool RbYetcHtrbUNJMvLyzogvMGmxbIMA;

			private IEnumerator<ElementAssignmentConflictInfo> abtwCHSihAIJpeLmQgIzaKZhlfqec;

			private int VZJQhQxvLVGfVTqBKadIiiXBZjxTA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return tUJdrGfBFeSambTQkhwfaPHnxgwEc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tUJdrGfBFeSambTQkhwfaPHnxgwEc;
				}
			}

			[DebuggerHidden]
			public eBhbpXIfxsuASGVDdCvTUUDWuupdA(int P_0)
			{
				JOyMxUKRLzpyfEHQIuFMFNHGVPXO = P_0;
				exThasBEClmkSrkOaEfTKTICvxit = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int jOyMxUKRLzpyfEHQIuFMFNHGVPXO = JOyMxUKRLzpyfEHQIuFMFNHGVPXO;
				if (jOyMxUKRLzpyfEHQIuFMFNHGVPXO == -3 || jOyMxUKRLzpyfEHQIuFMFNHGVPXO == 1)
				{
					try
					{
					}
					finally
					{
						oNOSNbFwWOnMsArNCBBHDEnUnzAs();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int jOyMxUKRLzpyfEHQIuFMFNHGVPXO = JOyMxUKRLzpyfEHQIuFMFNHGVPXO;
					ControllerMapWithAxes aBbEQJHRFFsHvjRFUGvXEPOkrfwdA = ABbEQJHRFFsHvjRFUGvXEPOkrfwdA;
					switch (jOyMxUKRLzpyfEHQIuFMFNHGVPXO)
					{
					default:
						return false;
					case 0:
						JOyMxUKRLzpyfEHQIuFMFNHGVPXO = -1;
						if (ReInput._id != aBbEQJHRFFsHvjRFUGvXEPOkrfwdA.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(aBbEQJHRFFsHvjRFUGvXEPOkrfwdA.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						if (qyiReqOVmutCVipqnASBWuhoBEJQ == null)
						{
							return false;
						}
						abtwCHSihAIJpeLmQgIzaKZhlfqec = ((ControllerMap)aBbEQJHRFFsHvjRFUGvXEPOkrfwdA).ElementAssignmentConflicts(qyiReqOVmutCVipqnASBWuhoBEJQ, JjDgwqEEloFKyMDnUHxypNwdxZqIA).GetEnumerator();
						JOyMxUKRLzpyfEHQIuFMFNHGVPXO = -3;
						goto IL_00ad;
					case 1:
						JOyMxUKRLzpyfEHQIuFMFNHGVPXO = -3;
						goto IL_00ad;
					case 2:
						{
							JOyMxUKRLzpyfEHQIuFMFNHGVPXO = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (abtwCHSihAIJpeLmQgIzaKZhlfqec.MoveNext())
						{
							ElementAssignmentConflictInfo current = abtwCHSihAIJpeLmQgIzaKZhlfqec.Current;
							tUJdrGfBFeSambTQkhwfaPHnxgwEc = current;
							JOyMxUKRLzpyfEHQIuFMFNHGVPXO = 1;
							return true;
						}
						oNOSNbFwWOnMsArNCBBHDEnUnzAs();
						abtwCHSihAIJpeLmQgIzaKZhlfqec = null;
						if (JjDgwqEEloFKyMDnUHxypNwdxZqIA && (!aBbEQJHRFFsHvjRFUGvXEPOkrfwdA._enabled || !qyiReqOVmutCVipqnASBWuhoBEJQ.amuHcHIpLQrjMsPzQKBWApxhXPxj))
						{
							return false;
						}
						if (aBbEQJHRFFsHvjRFUGvXEPOkrfwdA.DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
						{
							return false;
						}
						VZJQhQxvLVGfVTqBKadIiiXBZjxTA = 0;
						goto IL_01bb;
						IL_01bb:
						if (VZJQhQxvLVGfVTqBKadIiiXBZjxTA < aBbEQJHRFFsHvjRFUGvXEPOkrfwdA.DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count)
						{
							ActionElementMap actionElementMap = aBbEQJHRFFsHvjRFUGvXEPOkrfwdA.DqbiEKKNzCfRLANvvimzQiCuGfnZ[VZJQhQxvLVGfVTqBKadIiiXBZjxTA];
							if ((!JjDgwqEEloFKyMDnUHxypNwdxZqIA || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(qyiReqOVmutCVipqnASBWuhoBEJQ))
							{
								tUJdrGfBFeSambTQkhwfaPHnxgwEc = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(aBbEQJHRFFsHvjRFUGvXEPOkrfwdA._categoryId).userAssignable, -1, aBbEQJHRFFsHvjRFUGvXEPOkrfwdA._controllerType, aBbEQJHRFFsHvjRFUGvXEPOkrfwdA._controllerId, aBbEQJHRFFsHvjRFUGvXEPOkrfwdA._id, actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								JOyMxUKRLzpyfEHQIuFMFNHGVPXO = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						VZJQhQxvLVGfVTqBKadIiiXBZjxTA++;
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

			private void oNOSNbFwWOnMsArNCBBHDEnUnzAs()
			{
				JOyMxUKRLzpyfEHQIuFMFNHGVPXO = -1;
				if (abtwCHSihAIJpeLmQgIzaKZhlfqec != null)
				{
					abtwCHSihAIJpeLmQgIzaKZhlfqec.Dispose();
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
				eBhbpXIfxsuASGVDdCvTUUDWuupdA eBhbpXIfxsuASGVDdCvTUUDWuupdA2;
				if (JOyMxUKRLzpyfEHQIuFMFNHGVPXO == -2 && exThasBEClmkSrkOaEfTKTICvxit == Environment.CurrentManagedThreadId)
				{
					JOyMxUKRLzpyfEHQIuFMFNHGVPXO = 0;
					eBhbpXIfxsuASGVDdCvTUUDWuupdA2 = this;
				}
				else
				{
					eBhbpXIfxsuASGVDdCvTUUDWuupdA2 = new eBhbpXIfxsuASGVDdCvTUUDWuupdA(0);
					eBhbpXIfxsuASGVDdCvTUUDWuupdA2.ABbEQJHRFFsHvjRFUGvXEPOkrfwdA = ABbEQJHRFFsHvjRFUGvXEPOkrfwdA;
				}
				eBhbpXIfxsuASGVDdCvTUUDWuupdA2.qyiReqOVmutCVipqnASBWuhoBEJQ = GYsybBkFwfZteXQnoOuUUszsFbIh;
				eBhbpXIfxsuASGVDdCvTUUDWuupdA2.JjDgwqEEloFKyMDnUHxypNwdxZqIA = RbYetcHtrbUNJMvLyzogvMGmxbIMA;
				return eBhbpXIfxsuASGVDdCvTUUDWuupdA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class IVUQuNNZKPTJcvovVaDiwQYegGkp : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int IJymTYodEafHXErkOAIfyIuRHRRpA;

			private ElementAssignmentConflictInfo XiLQUiSVNWhyfECLfZCeKfeYnDLP;

			private int AXDdvCKoNKsKwOmkSSyuwwCuARtr;

			public ControllerMapWithAxes bkoAlnpkPGYbIoajrwNXwWagQjMb;

			private ElementAssignmentConflictCheck BqcfdSYkGXWizFujVLkqgPTuZmBs;

			public ElementAssignmentConflictCheck LsgyEqeetiuDkKNSkEPEHMGwvMHX;

			private bool bDQUlearljqZrfMgGvvQiLjZwlXw;

			public bool pnkpufcGAPjrRVbBipkQdXWtkinw;

			private ElementAssignment PLuTqOOnLXJYNUzoKOWVVMVMTMG;

			private IEnumerator<ElementAssignmentConflictInfo> RAZlqreeihSviRylmBYhHLjxqvWG;

			private int HtqftIcSnCWelTPiMhQnczBevmbZb;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return XiLQUiSVNWhyfECLfZCeKfeYnDLP;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return XiLQUiSVNWhyfECLfZCeKfeYnDLP;
				}
			}

			[DebuggerHidden]
			public IVUQuNNZKPTJcvovVaDiwQYegGkp(int P_0)
			{
				IJymTYodEafHXErkOAIfyIuRHRRpA = P_0;
				AXDdvCKoNKsKwOmkSSyuwwCuARtr = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int iJymTYodEafHXErkOAIfyIuRHRRpA = IJymTYodEafHXErkOAIfyIuRHRRpA;
				if (iJymTYodEafHXErkOAIfyIuRHRRpA == -3 || iJymTYodEafHXErkOAIfyIuRHRRpA == 1)
				{
					try
					{
					}
					finally
					{
						IwKFohoGfATjXUCyRysSSBxDFxpj();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int iJymTYodEafHXErkOAIfyIuRHRRpA = IJymTYodEafHXErkOAIfyIuRHRRpA;
					ControllerMapWithAxes controllerMapWithAxes = bkoAlnpkPGYbIoajrwNXwWagQjMb;
					switch (iJymTYodEafHXErkOAIfyIuRHRRpA)
					{
					default:
						return false;
					case 0:
						IJymTYodEafHXErkOAIfyIuRHRRpA = -1;
						if (ReInput._id != controllerMapWithAxes.lJEMGWAUGjJITDkYXUyWTwcHpUqo)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.lJEMGWAUGjJITDkYXUyWTwcHpUqo);
							return false;
						}
						RAZlqreeihSviRylmBYhHLjxqvWG = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(BqcfdSYkGXWizFujVLkqgPTuZmBs, bDQUlearljqZrfMgGvvQiLjZwlXw).GetEnumerator();
						IJymTYodEafHXErkOAIfyIuRHRRpA = -3;
						goto IL_009e;
					case 1:
						IJymTYodEafHXErkOAIfyIuRHRRpA = -3;
						goto IL_009e;
					case 2:
						{
							IJymTYodEafHXErkOAIfyIuRHRRpA = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (HtqftIcSnCWelTPiMhQnczBevmbZb < controllerMapWithAxes.DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.DqbiEKKNzCfRLANvvimzQiCuGfnZ[HtqftIcSnCWelTPiMhQnczBevmbZb];
							if ((!bDQUlearljqZrfMgGvvQiLjZwlXw || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != BqcfdSYkGXWizFujVLkqgPTuZmBs.elementMapId && actionElementMap.CheckForAssignmentConflict(PLuTqOOnLXJYNUzoKOWVVMVMTMG))
							{
								XiLQUiSVNWhyfECLfZCeKfeYnDLP = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								IJymTYodEafHXErkOAIfyIuRHRRpA = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (RAZlqreeihSviRylmBYhHLjxqvWG.MoveNext())
						{
							ElementAssignmentConflictInfo current = RAZlqreeihSviRylmBYhHLjxqvWG.Current;
							XiLQUiSVNWhyfECLfZCeKfeYnDLP = current;
							IJymTYodEafHXErkOAIfyIuRHRRpA = 1;
							return true;
						}
						IwKFohoGfATjXUCyRysSSBxDFxpj();
						RAZlqreeihSviRylmBYhHLjxqvWG = null;
						if (bDQUlearljqZrfMgGvvQiLjZwlXw && !controllerMapWithAxes._enabled)
						{
							return false;
						}
						if (controllerMapWithAxes.DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
						{
							return false;
						}
						PLuTqOOnLXJYNUzoKOWVVMVMTMG = BqcfdSYkGXWizFujVLkqgPTuZmBs.ToElementAssignment();
						HtqftIcSnCWelTPiMhQnczBevmbZb = 0;
						goto IL_01c7;
						IL_01b5:
						HtqftIcSnCWelTPiMhQnczBevmbZb++;
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

			private void IwKFohoGfATjXUCyRysSSBxDFxpj()
			{
				IJymTYodEafHXErkOAIfyIuRHRRpA = -1;
				if (RAZlqreeihSviRylmBYhHLjxqvWG != null)
				{
					RAZlqreeihSviRylmBYhHLjxqvWG.Dispose();
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
				IVUQuNNZKPTJcvovVaDiwQYegGkp iVUQuNNZKPTJcvovVaDiwQYegGkp;
				if (IJymTYodEafHXErkOAIfyIuRHRRpA == -2 && AXDdvCKoNKsKwOmkSSyuwwCuARtr == Environment.CurrentManagedThreadId)
				{
					IJymTYodEafHXErkOAIfyIuRHRRpA = 0;
					iVUQuNNZKPTJcvovVaDiwQYegGkp = this;
				}
				else
				{
					iVUQuNNZKPTJcvovVaDiwQYegGkp = new IVUQuNNZKPTJcvovVaDiwQYegGkp(0);
					iVUQuNNZKPTJcvovVaDiwQYegGkp.bkoAlnpkPGYbIoajrwNXwWagQjMb = bkoAlnpkPGYbIoajrwNXwWagQjMb;
				}
				iVUQuNNZKPTJcvovVaDiwQYegGkp.BqcfdSYkGXWizFujVLkqgPTuZmBs = LsgyEqeetiuDkKNSkEPEHMGwvMHX;
				iVUQuNNZKPTJcvovVaDiwQYegGkp.bDQUlearljqZrfMgGvvQiLjZwlXw = pnkpufcGAPjrRVbBipkQdXWtkinw;
				return iVUQuNNZKPTJcvovVaDiwQYegGkp;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> DqbiEKKNzCfRLANvvimzQiCuGfnZ;

		private readonly ReadOnlyCollection<ActionElementMap> bDxVupuiYjXVJiYOeQiIspPiXnUo;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return 0;
				}
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
				{
					return 0;
				}
				return DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
				{
					ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return bDxVupuiYjXVJiYOeQiIspPiXnUo;
			}
		}

		internal AList<ActionElementMap> nMqKclaILiuPNcXmtCkhJbgHzQSu => (AList<ActionElementMap>)DqbiEKKNzCfRLANvvimzQiCuGfnZ;

		public ControllerMapWithAxes()
		{
			DqbiEKKNzCfRLANvvimzQiCuGfnZ = new AList<ActionElementMap>();
			bDxVupuiYjXVJiYOeQiIspPiXnUo = new ReadOnlyCollection<ActionElementMap>(DqbiEKKNzCfRLANvvimzQiCuGfnZ);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			DqbiEKKNzCfRLANvvimzQiCuGfnZ = new AList<ActionElementMap>();
			bDxVupuiYjXVJiYOeQiIspPiXnUo = new ReadOnlyCollection<ActionElementMap>(DqbiEKKNzCfRLANvvimzQiCuGfnZ);
			if (P_0.DqbiEKKNzCfRLANvvimzQiCuGfnZ != null)
			{
				int count = P_0.DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
				for (int i = 0; i < count; i++)
				{
					LHPGFkhoBmsodIepCkhxaQQxkmQkA(new ActionElementMap(P_0.DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return false;
			}
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			LHPGFkhoBmsodIepCkhxaQQxkmQkA(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				LHPGFkhoBmsodIepCkhxaQQxkmQkA(elementMap);
			}
			if (IGhWcQTgrwgzeEHRkzhGIkPrhKxab(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.PBeemRQYRbxAhddOggEZTxxxXJLD(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = IGhWcQTgrwgzeEHRkzhGIkPrhKxab(elementMapId);
			if (num < 0)
			{
				return false;
			}
			hTdFpDJeIRGmpxEoCsAVLfPDXWee(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return null;
			}
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == elementMapId)
				{
					return DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap IdNfjZSaENcOrDRJAlUCBchKrEPXA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.nCbYVejBPTmuorSDmZRrJJavRJoB(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return gmZHdckoyRBkXGwDgdPeGebdDAdPb(P_0, P_1);
		}

		internal virtual int RJtLWtzePDdfmhKrcmdviKynqlve(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.jjMuuekUwblocWYvTLbSPbiSpkQi(P_0, P_1, P_2, P_3) + xTaffdGulzCYkpcWISKtGYurDSAb(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return;
			}
			base.ClearElementMaps();
			DqbiEKKNzCfRLANvvimzQiCuGfnZ.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null || index < 0 || index >= DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count)
			{
				return null;
			}
			return DqbiEKKNzCfRLANvvimzQiCuGfnZ[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(DqbiEKKNzCfRLANvvimzQiCuGfnZ);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return eeCAxqVMhlFbCBoDPnrQfGqZxNFV(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
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
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
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
			int num = axisMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
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
				ActionElementMap actionElementMap2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return VOcVbUIzhfxsVVgzSTRZlwURMvuu(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(xzdWIkJlKcXekloZTNWIMkqTiIzl))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new xzdWIkJlKcXekloZTNWIMkqTiIzl(-2)
			{
				qmMVkyfKJxJjOdsIxkLOCMRBELKg = this,
				uXyWZNivrinbKHZXRhVYuekhWpzd = actionId,
				sDIuptPDtrFFcDtHombfyFxXmSbCA = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
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
			IList<ActionElementMap> axisMaps = AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return null;
			}
			return gmZHdckoyRBkXGwDgdPeGebdDAdPb(predicate, false);
		}

		internal ActionElementMap gmZHdckoyRBkXGwDgdPeGebdDAdPb(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			return xTaffdGulzCYkpcWISKtGYurDSAb(predicate, false, results, false);
		}

		internal int xTaffdGulzCYkpcWISKtGYurDSAb(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
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
			return DeleteAxisMapsWithAction(ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
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
			int num = axisMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[num2] != null && DqbiEKKNzCfRLANvvimzQiCuGfnZ[num2]._actionId == actionId)
				{
					hTdFpDJeIRGmpxEoCsAVLfPDXWee(DqbiEKKNzCfRLANvvimzQiCuGfnZ[num2].xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int num = 0;
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj != state)
				{
					actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (skipDisabledMaps && !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
			{
				return false;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return false;
			}
			for (int i = 0; i < DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count; i++)
			{
				ActionElementMap actionElementMap2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if ((!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(vvogWsbbRrvHzdFsAESKKnGKNdUs))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new vvogWsbbRrvHzdFsAESKKnGKNdUs(-2)
			{
				xJoNblkIoGgWMMHmWALFeyPwOjly = this,
				gDATxYFsZyfEVNHfJFpqINPxeDapA = controllerMap,
				McEINAGjcNaKGdCSflQNgnnecfafE = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(eBhbpXIfxsuASGVDdCvTUUDWuupdA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new eBhbpXIfxsuASGVDdCvTUUDWuupdA(-2)
			{
				ABbEQJHRFFsHvjRFUGvXEPOkrfwdA = this,
				GYsybBkFwfZteXQnoOuUUszsFbIh = actionElementMap,
				RbYetcHtrbUNJMvLyzogvMGmxbIMA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(IVUQuNNZKPTJcvovVaDiwQYegGkp))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new IVUQuNNZKPTJcvovVaDiwQYegGkp(-2)
			{
				bkoAlnpkPGYbIoajrwNXwWagQjMb = this,
				LsgyEqeetiuDkKNSkEPEHMGwvMHX = conflictCheck,
				pnkpufcGAPjrRVbBipkQdXWtkinw = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
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
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
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
			_ = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			int count = axisMaps.Count;
			for (int num2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[num2];
				if (!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							hTdFpDJeIRGmpxEoCsAVLfPDXWee(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
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
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return num;
			}
			for (int num2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ[num2];
				if ((!skipDisabledMaps || actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					hTdFpDJeIRGmpxEoCsAVLfPDXWee(actionElementMap2.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
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
			for (int num2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[num2];
				if ((!skipDisabledMaps || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj) && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					hTdFpDJeIRGmpxEoCsAVLfPDXWee(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int NvsahEpHsOdzHMmRDWUUEmYYAeAu(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.wGJXfttiznxlxdlGIfuiHggUqnTV(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
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
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (!actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
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

		internal virtual int lIwoPtwRrvjpUbZLcqFsCZPuBKTD(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.mHsExafuwcnSQXWQrJQEBJLSIWLCA(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.amuHcHIpLQrjMsPzQKBWApxhXPxj))
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
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int KBQqGhYAXnGizblePmZwvlFZBmLoA(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.MZIiBSxUJkBlkAMDPNstKEDPEHpn(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
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
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj && actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != lJEMGWAUGjJITDkYXUyWTwcHpUqo)
			{
				ReInput.CheckInitialized(lJEMGWAUGjJITDkYXUyWTwcHpUqo);
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
				array[i] = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool jhTwjaiCSFneOclBYEWkfzkQWdhq(ActionElementMap P_0)
		{
			if (base.SRgvEhEXnsACwdSpkBjYoWEkqxLb(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(elementType))
			{
				return false;
			}
			LHPGFkhoBmsodIepCkhxaQQxkmQkA(P_0);
			return true;
		}

		internal virtual int BeRucgZCulZXLbNBXLIwTjXYOBCk(List<ActionElementMap> P_0, bool P_1)
		{
			base.yxRQTYzGEGjxNBGOMIYGdOrNNmmu(P_0, P_1);
			int count = P_0.Count;
			int count2 = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					P_0.Add(DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap rdNnTUSWhsivqjrsNfKFrcFCTqcU(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.HnhwRbtUSHfqZdDsLQzeXYDJIqHd(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(P_2))
			{
				return null;
			}
			int num = tHhcunbcbjgFVVanpTynUPswOpwKA(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return DqbiEKKNzCfRLANvvimzQiCuGfnZ[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int zodahDFyTDKVigDFJfGOIqICMlDIB(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.gWMpzXjwXYLcqSKbnABZEsflXeOEA(P_0, P_1, P_2);
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return P_1.Count - num;
			}
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._elementIdentifierId == P_0)
				{
					P_1.Add(DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool vJIfzJKTWwXGQMVvrnHEUEWjVRbT(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.vcWheJiEcLpRmfgrBOYBMUspXxXgA(P_0, P_1, P_2))
			{
				return true;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
				for (int i = 0; i < count; i++)
				{
					if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._elementIdentifierId == P_0 && DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int fhGtJKfhpQuHqvCfvBRdgUCRQyVhA(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.tHhcunbcbjgFVVanpTynUPswOpwKA(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(P_2))
			{
				return -1;
			}
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
				for (int i = 0; i < count; i++)
				{
					if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._elementIdentifierId == P_0 && DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int IGhWcQTgrwgzeEHRkzhGIkPrhKxab(int P_0)
		{
			if (DqbiEKKNzCfRLANvvimzQiCuGfnZ == null)
			{
				return -1;
			}
			int count = DqbiEKKNzCfRLANvvimzQiCuGfnZ.Count;
			for (int i = 0; i < count; i++)
			{
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].xYazCGhLJSNpewHjYMCgVGmvJCJk == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int eeCAxqVMhlFbCBoDPnrQfGqZxNFV(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (!P_0 || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int VOcVbUIzhfxsVVgzSTRZlwURMvuu(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int YqQGAWzjMKhZoBblenErfGaSTRbDA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.AvmYEXAwkVTWWehMOUUIzJXxGqQr(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap bfbyDiHiAukzvrOxkQItFjaFScrP(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.DjWWuZsxtpUwnYvonxAcnwebFqAJ(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._actionId == P_2) && (!P_3 || DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].amuHcHIpLQrjMsPzQKBWApxhXPxj) && DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].IsTarget(P_0))
				{
					return DqbiEKKNzCfRLANvvimzQiCuGfnZ[i];
				}
			}
			return null;
		}

		internal virtual int zQieotlZMHerhMFeNexxYpfjojhJ(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.ggkUfUXAPQaWoiBsYcQlTMWUVBprA(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]._actionId == P_2) && (!P_3 || DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].amuHcHIpLQrjMsPzQKBWApxhXPxj) && DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].IsTarget(P_0))
				{
					P_4.Add(DqbiEKKNzCfRLANvvimzQiCuGfnZ[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool kxIiVocKqCeKIQuuGPyZukxFCHhe(ActionElementMap P_0)
		{
			if (base.ZRIjyELwkgRbWriDAtViXcLrmcip(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!UWdJDPUhvoQTluVClhoJWycebdOO(P_0._elementType))
			{
				return false;
			}
			DqbiEKKNzCfRLANvvimzQiCuGfnZ.Add(P_0);
			TaftfVXgsIkQEpjduYRuDmWoWzXe(P_0);
			return true;
		}

		private bool UWdJDPUhvoQTluVClhoJWycebdOO(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void hTdFpDJeIRGmpxEoCsAVLfPDXWee(int P_0, int P_1)
		{
			JljXLKBTmsVgJTbmKETRDrcvMavEb(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				DqbiEKKNzCfRLANvvimzQiCuGfnZ.RemoveAt(P_1);
			}
		}

		private void LHPGFkhoBmsodIepCkhxaQQxkmQkA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				DqbiEKKNzCfRLANvvimzQiCuGfnZ.Add(P_0);
				TaftfVXgsIkQEpjduYRuDmWoWzXe(P_0);
			}
		}

		private void BTuDilJEhDwYILaUJoCuNgEfHOEX(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				xmddktKtoriRKAXnxuGKTgXExcYy(DqbiEKKNzCfRLANvvimzQiCuGfnZ[P_1].xYazCGhLJSNpewHjYMCgVGmvJCJk, P_0);
				DqbiEKKNzCfRLANvvimzQiCuGfnZ[P_1] = P_0;
			}
		}

		internal virtual void YNrnwFDCfrTkuVTBjtOBraBjLEXp(SerializedObject P_0)
		{
			base.tglDbhCwCmLTnbODONPFbTRTAiqHA(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (DqbiEKKNzCfRLANvvimzQiCuGfnZ[i] != null)
				{
					list.Add(DqbiEKKNzCfRLANvvimzQiCuGfnZ[i].vnkhapAzxkdihiiJDhDEbFBqtmXz());
				}
			}
		}

		internal virtual bool EXpusnmQXqZHsYzLWQiCFyjhWdjm(SerializedObject P_0)
		{
			bool flag = base.OWwCarBlxYJQRgjRztrVxMZOfXiRA(P_0);
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
						actionElementMap.pcbbqZaMalVdvJdmSXlnpndbZtQJ(value2);
						if (ActionElementMap.boixdvODcOFbHcLGxCkDabPrIIMjb(actionElementMap))
						{
							LHPGFkhoBmsodIepCkhxaQQxkmQkA(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> pNfCbyAsqRPoXrDrPDiMqbraQSzSA(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> EioLKONbgiyTTsXbhccItCWiuRtw(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> KDpkKLKNXQfOkbOympeXlcKgkUzBA(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
