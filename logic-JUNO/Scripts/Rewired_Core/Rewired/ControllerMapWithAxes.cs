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
		private sealed class yjKMgJUBBLGyfvDFnGudbsuxnaHoA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int GqMvaKPzNsvMrAGXRTnDpdDnINQd;

			private ActionElementMap nQAPEuYrKHqOowiTiWiPVpVxaCoFA;

			private int kiEQbZTaBqTiiYXYeuVhADJzNAtI;

			public ControllerMapWithAxes pknbDXwKQGRsLzSWTrNvoKHlEMkP;

			private int MMueSQELDtuznDtJjrpbwGSiIKnXA;

			public int jPMIcEdsDfKJSHTzLSdYAgVnINOA;

			private bool eWDtXQIuPoeTujKNMCRAEWlBVulZ;

			public bool bZnFrMYOyYeXnrdFKdIYbIrdLINx;

			private IEnumerator<ActionElementMap> YxdufMJsseLRpXCsMrUFUWAGrnZn;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return nQAPEuYrKHqOowiTiWiPVpVxaCoFA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nQAPEuYrKHqOowiTiWiPVpVxaCoFA;
				}
			}

			[DebuggerHidden]
			public yjKMgJUBBLGyfvDFnGudbsuxnaHoA(int P_0)
			{
				GqMvaKPzNsvMrAGXRTnDpdDnINQd = P_0;
				kiEQbZTaBqTiiYXYeuVhADJzNAtI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gqMvaKPzNsvMrAGXRTnDpdDnINQd = GqMvaKPzNsvMrAGXRTnDpdDnINQd;
				if (gqMvaKPzNsvMrAGXRTnDpdDnINQd == -3 || gqMvaKPzNsvMrAGXRTnDpdDnINQd == 1)
				{
					try
					{
					}
					finally
					{
						kDICYtgjbgFkTLprCjmViEGCFjJEA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gqMvaKPzNsvMrAGXRTnDpdDnINQd = GqMvaKPzNsvMrAGXRTnDpdDnINQd;
					ControllerMapWithAxes controllerMapWithAxes = pknbDXwKQGRsLzSWTrNvoKHlEMkP;
					switch (gqMvaKPzNsvMrAGXRTnDpdDnINQd)
					{
					default:
						return false;
					case 0:
						GqMvaKPzNsvMrAGXRTnDpdDnINQd = -1;
						if (ReInput._id != controllerMapWithAxes.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						if (MMueSQELDtuznDtJjrpbwGSiIKnXA < 0)
						{
							return false;
						}
						YxdufMJsseLRpXCsMrUFUWAGrnZn = controllerMapWithAxes.AxisMaps.GetEnumerator();
						GqMvaKPzNsvMrAGXRTnDpdDnINQd = -3;
						break;
					case 1:
						GqMvaKPzNsvMrAGXRTnDpdDnINQd = -3;
						break;
					}
					while (YxdufMJsseLRpXCsMrUFUWAGrnZn.MoveNext())
					{
						ActionElementMap current = YxdufMJsseLRpXCsMrUFUWAGrnZn.Current;
						if (current._actionId == MMueSQELDtuznDtJjrpbwGSiIKnXA && (!eWDtXQIuPoeTujKNMCRAEWlBVulZ || current.vWZNVuVXYnOfJimlqfUderrRDbRk))
						{
							nQAPEuYrKHqOowiTiWiPVpVxaCoFA = current;
							GqMvaKPzNsvMrAGXRTnDpdDnINQd = 1;
							return true;
						}
					}
					kDICYtgjbgFkTLprCjmViEGCFjJEA();
					YxdufMJsseLRpXCsMrUFUWAGrnZn = null;
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

			private void kDICYtgjbgFkTLprCjmViEGCFjJEA()
			{
				GqMvaKPzNsvMrAGXRTnDpdDnINQd = -1;
				if (YxdufMJsseLRpXCsMrUFUWAGrnZn != null)
				{
					YxdufMJsseLRpXCsMrUFUWAGrnZn.Dispose();
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
				yjKMgJUBBLGyfvDFnGudbsuxnaHoA yjKMgJUBBLGyfvDFnGudbsuxnaHoA2;
				if (GqMvaKPzNsvMrAGXRTnDpdDnINQd == -2 && kiEQbZTaBqTiiYXYeuVhADJzNAtI == Environment.CurrentManagedThreadId)
				{
					GqMvaKPzNsvMrAGXRTnDpdDnINQd = 0;
					yjKMgJUBBLGyfvDFnGudbsuxnaHoA2 = this;
				}
				else
				{
					yjKMgJUBBLGyfvDFnGudbsuxnaHoA2 = new yjKMgJUBBLGyfvDFnGudbsuxnaHoA(0);
					yjKMgJUBBLGyfvDFnGudbsuxnaHoA2.pknbDXwKQGRsLzSWTrNvoKHlEMkP = pknbDXwKQGRsLzSWTrNvoKHlEMkP;
				}
				yjKMgJUBBLGyfvDFnGudbsuxnaHoA2.MMueSQELDtuznDtJjrpbwGSiIKnXA = jPMIcEdsDfKJSHTzLSdYAgVnINOA;
				yjKMgJUBBLGyfvDFnGudbsuxnaHoA2.eWDtXQIuPoeTujKNMCRAEWlBVulZ = bZnFrMYOyYeXnrdFKdIYbIrdLINx;
				return yjKMgJUBBLGyfvDFnGudbsuxnaHoA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class yZNbuDyWIIMCuxIcyAtrJqAokpyJA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ccdfAKDBLbZyIYaNfRlXcPBrZrrv;

			private ElementAssignmentConflictInfo LSJNyeNuOlccDGKaFCoqrmiPFERcA;

			private int zTtkbaGDHqykVfiCFWTBrXZpqxak;

			public ControllerMapWithAxes glTVwEzCvzhFJGlomhaijMRSvtDBA;

			private ControllerMap GNtpktCZVLzUZZsjvILtxMEQfEXe;

			public ControllerMap nZvefhIACNabIFJjfKQHCfTEHJIRb;

			private bool eNogxZEXEILouBsBvnlciGnhTSyqB;

			public bool LadWRxokvkCpJMVSJbjsRrhOQnTM;

			private IList<ActionElementMap> toiSVKjsitmxDdXkhImJBiQNmmzS;

			private int alGaRSjLoaYbBsaSWGcuQqkbfhldb;

			private IEnumerator<ElementAssignmentConflictInfo> kfuRpTzFowvpVODHHYLdyxtGUGqy;

			private int VLtCvVPpUWGpZiHoalJIXMWSbdGs;

			private ActionElementMap FZrJTmylDLxpvltCLCsnKBsnTfwX;

			private int vEutCxajmDobDnCAfpJuccUxilBC;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return LSJNyeNuOlccDGKaFCoqrmiPFERcA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LSJNyeNuOlccDGKaFCoqrmiPFERcA;
				}
			}

			[DebuggerHidden]
			public yZNbuDyWIIMCuxIcyAtrJqAokpyJA(int P_0)
			{
				ccdfAKDBLbZyIYaNfRlXcPBrZrrv = P_0;
				zTtkbaGDHqykVfiCFWTBrXZpqxak = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = ccdfAKDBLbZyIYaNfRlXcPBrZrrv;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						dFjjnSbaSXmUQMGijRDsPEHlJVMu();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = ccdfAKDBLbZyIYaNfRlXcPBrZrrv;
					ControllerMapWithAxes controllerMapWithAxes = glTVwEzCvzhFJGlomhaijMRSvtDBA;
					switch (num)
					{
					default:
						return false;
					case 0:
						ccdfAKDBLbZyIYaNfRlXcPBrZrrv = -1;
						if (ReInput._id != controllerMapWithAxes.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						if (GNtpktCZVLzUZZsjvILtxMEQfEXe == null)
						{
							return false;
						}
						kfuRpTzFowvpVODHHYLdyxtGUGqy = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(GNtpktCZVLzUZZsjvILtxMEQfEXe, eNogxZEXEILouBsBvnlciGnhTSyqB).GetEnumerator();
						ccdfAKDBLbZyIYaNfRlXcPBrZrrv = -3;
						goto IL_00af;
					case 1:
						ccdfAKDBLbZyIYaNfRlXcPBrZrrv = -3;
						goto IL_00af;
					case 2:
						{
							ccdfAKDBLbZyIYaNfRlXcPBrZrrv = -1;
							goto IL_0232;
						}
						IL_0244:
						if (vEutCxajmDobDnCAfpJuccUxilBC < alGaRSjLoaYbBsaSWGcuQqkbfhldb)
						{
							ActionElementMap actionElementMap = toiSVKjsitmxDdXkhImJBiQNmmzS[vEutCxajmDobDnCAfpJuccUxilBC];
							if ((!eNogxZEXEILouBsBvnlciGnhTSyqB || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && FZrJTmylDLxpvltCLCsnKBsnTfwX.CheckForAssignmentConflict(actionElementMap))
							{
								LSJNyeNuOlccDGKaFCoqrmiPFERcA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, FZrJTmylDLxpvltCLCsnKBsnTfwX.kzHrLfsGRteEloHDejoDrezLTRte, FZrJTmylDLxpvltCLCsnKBsnTfwX._actionId, FZrJTmylDLxpvltCLCsnKBsnTfwX._elementType, FZrJTmylDLxpvltCLCsnKBsnTfwX._elementIdentifierId, FZrJTmylDLxpvltCLCsnKBsnTfwX.keyCode, FZrJTmylDLxpvltCLCsnKBsnTfwX.modifierKeyFlags);
								ccdfAKDBLbZyIYaNfRlXcPBrZrrv = 2;
								return true;
							}
							goto IL_0232;
						}
						FZrJTmylDLxpvltCLCsnKBsnTfwX = null;
						goto IL_025c;
						IL_0232:
						vEutCxajmDobDnCAfpJuccUxilBC++;
						goto IL_0244;
						IL_026e:
						if (VLtCvVPpUWGpZiHoalJIXMWSbdGs < controllerMapWithAxes.COKsUhVIexooKQPdJlLSyjGAwvHS.Count)
						{
							FZrJTmylDLxpvltCLCsnKBsnTfwX = controllerMapWithAxes.COKsUhVIexooKQPdJlLSyjGAwvHS[VLtCvVPpUWGpZiHoalJIXMWSbdGs];
							if (!eNogxZEXEILouBsBvnlciGnhTSyqB || FZrJTmylDLxpvltCLCsnKBsnTfwX.vWZNVuVXYnOfJimlqfUderrRDbRk)
							{
								vEutCxajmDobDnCAfpJuccUxilBC = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (kfuRpTzFowvpVODHHYLdyxtGUGqy.MoveNext())
						{
							ElementAssignmentConflictInfo current = kfuRpTzFowvpVODHHYLdyxtGUGqy.Current;
							LSJNyeNuOlccDGKaFCoqrmiPFERcA = current;
							ccdfAKDBLbZyIYaNfRlXcPBrZrrv = 1;
							return true;
						}
						dFjjnSbaSXmUQMGijRDsPEHlJVMu();
						kfuRpTzFowvpVODHHYLdyxtGUGqy = null;
						if (!(GNtpktCZVLzUZZsjvILtxMEQfEXe is ControllerMapWithAxes controllerMapWithAxes2))
						{
							return false;
						}
						if (eNogxZEXEILouBsBvnlciGnhTSyqB && (!controllerMapWithAxes._enabled || !controllerMapWithAxes2._enabled))
						{
							return false;
						}
						toiSVKjsitmxDdXkhImJBiQNmmzS = controllerMapWithAxes2.AxisMaps;
						if (toiSVKjsitmxDdXkhImJBiQNmmzS == null)
						{
							return false;
						}
						alGaRSjLoaYbBsaSWGcuQqkbfhldb = toiSVKjsitmxDdXkhImJBiQNmmzS.Count;
						VLtCvVPpUWGpZiHoalJIXMWSbdGs = 0;
						goto IL_026e;
						IL_025c:
						VLtCvVPpUWGpZiHoalJIXMWSbdGs++;
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

			private void dFjjnSbaSXmUQMGijRDsPEHlJVMu()
			{
				ccdfAKDBLbZyIYaNfRlXcPBrZrrv = -1;
				if (kfuRpTzFowvpVODHHYLdyxtGUGqy != null)
				{
					kfuRpTzFowvpVODHHYLdyxtGUGqy.Dispose();
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
				yZNbuDyWIIMCuxIcyAtrJqAokpyJA yZNbuDyWIIMCuxIcyAtrJqAokpyJA2;
				if (ccdfAKDBLbZyIYaNfRlXcPBrZrrv == -2 && zTtkbaGDHqykVfiCFWTBrXZpqxak == Environment.CurrentManagedThreadId)
				{
					ccdfAKDBLbZyIYaNfRlXcPBrZrrv = 0;
					yZNbuDyWIIMCuxIcyAtrJqAokpyJA2 = this;
				}
				else
				{
					yZNbuDyWIIMCuxIcyAtrJqAokpyJA2 = new yZNbuDyWIIMCuxIcyAtrJqAokpyJA(0);
					yZNbuDyWIIMCuxIcyAtrJqAokpyJA2.glTVwEzCvzhFJGlomhaijMRSvtDBA = glTVwEzCvzhFJGlomhaijMRSvtDBA;
				}
				yZNbuDyWIIMCuxIcyAtrJqAokpyJA2.GNtpktCZVLzUZZsjvILtxMEQfEXe = nZvefhIACNabIFJjfKQHCfTEHJIRb;
				yZNbuDyWIIMCuxIcyAtrJqAokpyJA2.eNogxZEXEILouBsBvnlciGnhTSyqB = LadWRxokvkCpJMVSJbjsRrhOQnTM;
				return yZNbuDyWIIMCuxIcyAtrJqAokpyJA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class jbSDzmBoeNFxLWJDZxWsbaBwQeZiA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int QxRizpXcMUgTgEXEmlkhnOHaGZdw;

			private ElementAssignmentConflictInfo aUctdrQrGLRvrXyMVJOEbgPNcAWl;

			private int zNcMaTCANKiJHHzYMVOsswYiojSlA;

			public ControllerMapWithAxes NbKBQidCWeigyFlZjeIiUbCaCfKPB;

			private ActionElementMap pgZhwRJKrThxSizqNxhimHfYASjk;

			public ActionElementMap LLjosthbEDyfLVvQdlhsPnWnJwm;

			private bool IEauaHLvgBbrvZkbqUYRbgaVjREt;

			public bool GbnBlHdauGdkKqjVEyTBesOUIlgQA;

			private IEnumerator<ElementAssignmentConflictInfo> xfQiCmBRqtusmAZqkDxELsFHRfCsA;

			private int CYgEfngJGsbAKEXNqCOjUWBxSzJLA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return aUctdrQrGLRvrXyMVJOEbgPNcAWl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aUctdrQrGLRvrXyMVJOEbgPNcAWl;
				}
			}

			[DebuggerHidden]
			public jbSDzmBoeNFxLWJDZxWsbaBwQeZiA(int P_0)
			{
				QxRizpXcMUgTgEXEmlkhnOHaGZdw = P_0;
				zNcMaTCANKiJHHzYMVOsswYiojSlA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int qxRizpXcMUgTgEXEmlkhnOHaGZdw = QxRizpXcMUgTgEXEmlkhnOHaGZdw;
				if (qxRizpXcMUgTgEXEmlkhnOHaGZdw == -3 || qxRizpXcMUgTgEXEmlkhnOHaGZdw == 1)
				{
					try
					{
					}
					finally
					{
						pfrENWUTTjEhjGODepkwpblcthiMA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int qxRizpXcMUgTgEXEmlkhnOHaGZdw = QxRizpXcMUgTgEXEmlkhnOHaGZdw;
					ControllerMapWithAxes nbKBQidCWeigyFlZjeIiUbCaCfKPB = NbKBQidCWeigyFlZjeIiUbCaCfKPB;
					switch (qxRizpXcMUgTgEXEmlkhnOHaGZdw)
					{
					default:
						return false;
					case 0:
						QxRizpXcMUgTgEXEmlkhnOHaGZdw = -1;
						if (ReInput._id != nbKBQidCWeigyFlZjeIiUbCaCfKPB.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(nbKBQidCWeigyFlZjeIiUbCaCfKPB.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						if (pgZhwRJKrThxSizqNxhimHfYASjk == null)
						{
							return false;
						}
						xfQiCmBRqtusmAZqkDxELsFHRfCsA = ((ControllerMap)nbKBQidCWeigyFlZjeIiUbCaCfKPB).ElementAssignmentConflicts(pgZhwRJKrThxSizqNxhimHfYASjk, IEauaHLvgBbrvZkbqUYRbgaVjREt).GetEnumerator();
						QxRizpXcMUgTgEXEmlkhnOHaGZdw = -3;
						goto IL_00ad;
					case 1:
						QxRizpXcMUgTgEXEmlkhnOHaGZdw = -3;
						goto IL_00ad;
					case 2:
						{
							QxRizpXcMUgTgEXEmlkhnOHaGZdw = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (xfQiCmBRqtusmAZqkDxELsFHRfCsA.MoveNext())
						{
							ElementAssignmentConflictInfo current = xfQiCmBRqtusmAZqkDxELsFHRfCsA.Current;
							aUctdrQrGLRvrXyMVJOEbgPNcAWl = current;
							QxRizpXcMUgTgEXEmlkhnOHaGZdw = 1;
							return true;
						}
						pfrENWUTTjEhjGODepkwpblcthiMA();
						xfQiCmBRqtusmAZqkDxELsFHRfCsA = null;
						if (IEauaHLvgBbrvZkbqUYRbgaVjREt && (!nbKBQidCWeigyFlZjeIiUbCaCfKPB._enabled || !pgZhwRJKrThxSizqNxhimHfYASjk.vWZNVuVXYnOfJimlqfUderrRDbRk))
						{
							return false;
						}
						if (nbKBQidCWeigyFlZjeIiUbCaCfKPB.COKsUhVIexooKQPdJlLSyjGAwvHS == null)
						{
							return false;
						}
						CYgEfngJGsbAKEXNqCOjUWBxSzJLA = 0;
						goto IL_01bb;
						IL_01bb:
						if (CYgEfngJGsbAKEXNqCOjUWBxSzJLA < nbKBQidCWeigyFlZjeIiUbCaCfKPB.COKsUhVIexooKQPdJlLSyjGAwvHS.Count)
						{
							ActionElementMap actionElementMap = nbKBQidCWeigyFlZjeIiUbCaCfKPB.COKsUhVIexooKQPdJlLSyjGAwvHS[CYgEfngJGsbAKEXNqCOjUWBxSzJLA];
							if ((!IEauaHLvgBbrvZkbqUYRbgaVjREt || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(pgZhwRJKrThxSizqNxhimHfYASjk))
							{
								aUctdrQrGLRvrXyMVJOEbgPNcAWl = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(nbKBQidCWeigyFlZjeIiUbCaCfKPB._categoryId).userAssignable, -1, nbKBQidCWeigyFlZjeIiUbCaCfKPB._controllerType, nbKBQidCWeigyFlZjeIiUbCaCfKPB._controllerId, nbKBQidCWeigyFlZjeIiUbCaCfKPB._id, actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								QxRizpXcMUgTgEXEmlkhnOHaGZdw = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						CYgEfngJGsbAKEXNqCOjUWBxSzJLA++;
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

			private void pfrENWUTTjEhjGODepkwpblcthiMA()
			{
				QxRizpXcMUgTgEXEmlkhnOHaGZdw = -1;
				if (xfQiCmBRqtusmAZqkDxELsFHRfCsA != null)
				{
					xfQiCmBRqtusmAZqkDxELsFHRfCsA.Dispose();
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
				jbSDzmBoeNFxLWJDZxWsbaBwQeZiA jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2;
				if (QxRizpXcMUgTgEXEmlkhnOHaGZdw == -2 && zNcMaTCANKiJHHzYMVOsswYiojSlA == Environment.CurrentManagedThreadId)
				{
					QxRizpXcMUgTgEXEmlkhnOHaGZdw = 0;
					jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2 = this;
				}
				else
				{
					jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2 = new jbSDzmBoeNFxLWJDZxWsbaBwQeZiA(0);
					jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2.NbKBQidCWeigyFlZjeIiUbCaCfKPB = NbKBQidCWeigyFlZjeIiUbCaCfKPB;
				}
				jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2.pgZhwRJKrThxSizqNxhimHfYASjk = LLjosthbEDyfLVvQdlhsPnWnJwm;
				jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2.IEauaHLvgBbrvZkbqUYRbgaVjREt = GbnBlHdauGdkKqjVEyTBesOUIlgQA;
				return jbSDzmBoeNFxLWJDZxWsbaBwQeZiA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class BelGmqQfLuomrbdhxHuHdSIWpOWHA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int HCNJTnpBPZpyKhSayolAgzgpCJfW;

			private ElementAssignmentConflictInfo SDmESDJLIjAHseWFBEhRbggIwDbEB;

			private int PCyjPrFwWrrTlUIusPdLENOATAHJ;

			public ControllerMapWithAxes yHZMOEeflznSyowlHBfwOgISALVl;

			private ElementAssignmentConflictCheck UAHRljVGTwUNiRppphNFKTTEmyfL;

			public ElementAssignmentConflictCheck AjRdABkdcXUyrRWAYngljtSEmSvAb;

			private bool ayxEjTaxkQasenlomXQxjGbtfxpPA;

			public bool kMXluMrSXuQQUZaZELMrVoSVkBJJ;

			private ElementAssignment YbyTRTTfqcceHPcbCjpdnWAdExkK;

			private IEnumerator<ElementAssignmentConflictInfo> UaiAlClglIWfzFdvMOuQxSdHmkop;

			private int UiRVtlTEsbfLgLReejpMIPNNKcNwA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return SDmESDJLIjAHseWFBEhRbggIwDbEB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SDmESDJLIjAHseWFBEhRbggIwDbEB;
				}
			}

			[DebuggerHidden]
			public BelGmqQfLuomrbdhxHuHdSIWpOWHA(int P_0)
			{
				HCNJTnpBPZpyKhSayolAgzgpCJfW = P_0;
				PCyjPrFwWrrTlUIusPdLENOATAHJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int hCNJTnpBPZpyKhSayolAgzgpCJfW = HCNJTnpBPZpyKhSayolAgzgpCJfW;
				if (hCNJTnpBPZpyKhSayolAgzgpCJfW == -3 || hCNJTnpBPZpyKhSayolAgzgpCJfW == 1)
				{
					try
					{
					}
					finally
					{
						HwbDFUdRTdcLSMajrLzfudmvTmPC();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int hCNJTnpBPZpyKhSayolAgzgpCJfW = HCNJTnpBPZpyKhSayolAgzgpCJfW;
					ControllerMapWithAxes controllerMapWithAxes = yHZMOEeflznSyowlHBfwOgISALVl;
					switch (hCNJTnpBPZpyKhSayolAgzgpCJfW)
					{
					default:
						return false;
					case 0:
						HCNJTnpBPZpyKhSayolAgzgpCJfW = -1;
						if (ReInput._id != controllerMapWithAxes.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						UaiAlClglIWfzFdvMOuQxSdHmkop = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(UAHRljVGTwUNiRppphNFKTTEmyfL, ayxEjTaxkQasenlomXQxjGbtfxpPA).GetEnumerator();
						HCNJTnpBPZpyKhSayolAgzgpCJfW = -3;
						goto IL_009e;
					case 1:
						HCNJTnpBPZpyKhSayolAgzgpCJfW = -3;
						goto IL_009e;
					case 2:
						{
							HCNJTnpBPZpyKhSayolAgzgpCJfW = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (UiRVtlTEsbfLgLReejpMIPNNKcNwA < controllerMapWithAxes.COKsUhVIexooKQPdJlLSyjGAwvHS.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.COKsUhVIexooKQPdJlLSyjGAwvHS[UiRVtlTEsbfLgLReejpMIPNNKcNwA];
							if ((!ayxEjTaxkQasenlomXQxjGbtfxpPA || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != UAHRljVGTwUNiRppphNFKTTEmyfL.elementMapId && actionElementMap.CheckForAssignmentConflict(YbyTRTTfqcceHPcbCjpdnWAdExkK))
							{
								SDmESDJLIjAHseWFBEhRbggIwDbEB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								HCNJTnpBPZpyKhSayolAgzgpCJfW = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (UaiAlClglIWfzFdvMOuQxSdHmkop.MoveNext())
						{
							ElementAssignmentConflictInfo current = UaiAlClglIWfzFdvMOuQxSdHmkop.Current;
							SDmESDJLIjAHseWFBEhRbggIwDbEB = current;
							HCNJTnpBPZpyKhSayolAgzgpCJfW = 1;
							return true;
						}
						HwbDFUdRTdcLSMajrLzfudmvTmPC();
						UaiAlClglIWfzFdvMOuQxSdHmkop = null;
						if (ayxEjTaxkQasenlomXQxjGbtfxpPA && !controllerMapWithAxes._enabled)
						{
							return false;
						}
						if (controllerMapWithAxes.COKsUhVIexooKQPdJlLSyjGAwvHS == null)
						{
							return false;
						}
						YbyTRTTfqcceHPcbCjpdnWAdExkK = UAHRljVGTwUNiRppphNFKTTEmyfL.ToElementAssignment();
						UiRVtlTEsbfLgLReejpMIPNNKcNwA = 0;
						goto IL_01c7;
						IL_01b5:
						UiRVtlTEsbfLgLReejpMIPNNKcNwA++;
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

			private void HwbDFUdRTdcLSMajrLzfudmvTmPC()
			{
				HCNJTnpBPZpyKhSayolAgzgpCJfW = -1;
				if (UaiAlClglIWfzFdvMOuQxSdHmkop != null)
				{
					UaiAlClglIWfzFdvMOuQxSdHmkop.Dispose();
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
				BelGmqQfLuomrbdhxHuHdSIWpOWHA belGmqQfLuomrbdhxHuHdSIWpOWHA;
				if (HCNJTnpBPZpyKhSayolAgzgpCJfW == -2 && PCyjPrFwWrrTlUIusPdLENOATAHJ == Environment.CurrentManagedThreadId)
				{
					HCNJTnpBPZpyKhSayolAgzgpCJfW = 0;
					belGmqQfLuomrbdhxHuHdSIWpOWHA = this;
				}
				else
				{
					belGmqQfLuomrbdhxHuHdSIWpOWHA = new BelGmqQfLuomrbdhxHuHdSIWpOWHA(0);
					belGmqQfLuomrbdhxHuHdSIWpOWHA.yHZMOEeflznSyowlHBfwOgISALVl = yHZMOEeflznSyowlHBfwOgISALVl;
				}
				belGmqQfLuomrbdhxHuHdSIWpOWHA.UAHRljVGTwUNiRppphNFKTTEmyfL = AjRdABkdcXUyrRWAYngljtSEmSvAb;
				belGmqQfLuomrbdhxHuHdSIWpOWHA.ayxEjTaxkQasenlomXQxjGbtfxpPA = kMXluMrSXuQQUZaZELMrVoSVkBJJ;
				return belGmqQfLuomrbdhxHuHdSIWpOWHA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> COKsUhVIexooKQPdJlLSyjGAwvHS;

		private readonly ReadOnlyCollection<ActionElementMap> ayAFuEBpVUCsMPyCINNxfOVWYvgeA;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return 0;
				}
				if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
				{
					return 0;
				}
				return COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return ayAFuEBpVUCsMPyCINNxfOVWYvgeA;
			}
		}

		internal AList<ActionElementMap> qqVpkQtIIJaqAkwgRpBKJtupJCwOA => (AList<ActionElementMap>)COKsUhVIexooKQPdJlLSyjGAwvHS;

		public ControllerMapWithAxes()
		{
			COKsUhVIexooKQPdJlLSyjGAwvHS = new AList<ActionElementMap>();
			ayAFuEBpVUCsMPyCINNxfOVWYvgeA = new ReadOnlyCollection<ActionElementMap>(COKsUhVIexooKQPdJlLSyjGAwvHS);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			COKsUhVIexooKQPdJlLSyjGAwvHS = new AList<ActionElementMap>();
			ayAFuEBpVUCsMPyCINNxfOVWYvgeA = new ReadOnlyCollection<ActionElementMap>(COKsUhVIexooKQPdJlLSyjGAwvHS);
			if (P_0.COKsUhVIexooKQPdJlLSyjGAwvHS != null)
			{
				int count = P_0.COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
				for (int i = 0; i < count; i++)
				{
					WgkuZVljONcRmgcjqWGSknWTNeeR(new ActionElementMap(P_0.COKsUhVIexooKQPdJlLSyjGAwvHS[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return false;
			}
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				if (COKsUhVIexooKQPdJlLSyjGAwvHS[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			WgkuZVljONcRmgcjqWGSknWTNeeR(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				WgkuZVljONcRmgcjqWGSknWTNeeR(elementMap);
			}
			if (LAOjcdcSiPkCdbTVKbIlcONgPUTEB(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.CeVoAmLHxQSjknnHUHqszbVVJNxd(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = LAOjcdcSiPkCdbTVKbIlcONgPUTEB(elementMapId);
			if (num < 0)
			{
				return false;
			}
			uPUJuVWvHejsPlGhkNJkxxqnRQKd(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return null;
			}
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				if (COKsUhVIexooKQPdJlLSyjGAwvHS[i].kzHrLfsGRteEloHDejoDrezLTRte == elementMapId)
				{
					return COKsUhVIexooKQPdJlLSyjGAwvHS[i];
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap FHortoVsXydpiFPJsGzvYEpsBYtt(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.iuEMKcoaYuVSxnbUEyRwlXTDXQpl(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return rmesfZjdvoqJGguLEgxXIFrbESFX(P_0, P_1);
		}

		internal virtual int YiOVYTglbkAerrAkWLrEUUIDsbTf(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.kmxcRNjEbMkIpQCMnmoprJkiXrcq(P_0, P_1, P_2, P_3) + iKJflMXhRWnOVxozonktmYHWLzyD(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return;
			}
			base.ClearElementMaps();
			COKsUhVIexooKQPdJlLSyjGAwvHS.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null || index < 0 || index >= COKsUhVIexooKQPdJlLSyjGAwvHS.Count)
			{
				return null;
			}
			return COKsUhVIexooKQPdJlLSyjGAwvHS[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(COKsUhVIexooKQPdJlLSyjGAwvHS);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return hxzzdHOYuUCHHFnXvYtxTkyvVYnf(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
				ActionElementMap actionElementMap2 = COKsUhVIexooKQPdJlLSyjGAwvHS[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return GMNFzlRQsOUDALCxejgsZVWbplWq(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(yjKMgJUBBLGyfvDFnGudbsuxnaHoA))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new yjKMgJUBBLGyfvDFnGudbsuxnaHoA(-2)
			{
				pknbDXwKQGRsLzSWTrNvoKHlEMkP = this,
				jPMIcEdsDfKJSHTzLSdYAgVnINOA = actionId,
				bZnFrMYOyYeXnrdFKdIYbIrdLINx = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			return rmesfZjdvoqJGguLEgxXIFrbESFX(predicate, false);
		}

		internal ActionElementMap rmesfZjdvoqJGguLEgxXIFrbESFX(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return iKJflMXhRWnOVxozonktmYHWLzyD(predicate, false, results, false);
		}

		internal int iKJflMXhRWnOVxozonktmYHWLzyD(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
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
			return DeleteAxisMapsWithAction(ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (COKsUhVIexooKQPdJlLSyjGAwvHS[num2] != null && COKsUhVIexooKQPdJlLSyjGAwvHS[num2]._actionId == actionId)
				{
					uPUJuVWvHejsPlGhkNJkxxqnRQKd(COKsUhVIexooKQPdJlLSyjGAwvHS[num2].kzHrLfsGRteEloHDejoDrezLTRte, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int num = 0;
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk != state)
				{
					actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (skipDisabledMaps && !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
			{
				return false;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return false;
			}
			for (int i = 0; i < COKsUhVIexooKQPdJlLSyjGAwvHS.Count; i++)
			{
				ActionElementMap actionElementMap2 = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < COKsUhVIexooKQPdJlLSyjGAwvHS.Count; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if ((!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(yZNbuDyWIIMCuxIcyAtrJqAokpyJA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new yZNbuDyWIIMCuxIcyAtrJqAokpyJA(-2)
			{
				glTVwEzCvzhFJGlomhaijMRSvtDBA = this,
				nZvefhIACNabIFJjfKQHCfTEHJIRb = controllerMap,
				LadWRxokvkCpJMVSJbjsRrhOQnTM = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(jbSDzmBoeNFxLWJDZxWsbaBwQeZiA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new jbSDzmBoeNFxLWJDZxWsbaBwQeZiA(-2)
			{
				NbKBQidCWeigyFlZjeIiUbCaCfKPB = this,
				LLjosthbEDyfLVvQdlhsPnWnJwm = actionElementMap,
				GbnBlHdauGdkKqjVEyTBesOUIlgQA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(BelGmqQfLuomrbdhxHuHdSIWpOWHA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new BelGmqQfLuomrbdhxHuHdSIWpOWHA(-2)
			{
				yHZMOEeflznSyowlHBfwOgISALVl = this,
				AjRdABkdcXUyrRWAYngljtSEmSvAb = conflictCheck,
				kMXluMrSXuQQUZaZELMrVoSVkBJJ = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
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
			_ = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			int count = axisMaps.Count;
			for (int num2 = COKsUhVIexooKQPdJlLSyjGAwvHS.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[num2];
				if (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							uPUJuVWvHejsPlGhkNJkxxqnRQKd(actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, num2);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return num;
			}
			for (int num2 = COKsUhVIexooKQPdJlLSyjGAwvHS.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = COKsUhVIexooKQPdJlLSyjGAwvHS[num2];
				if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					uPUJuVWvHejsPlGhkNJkxxqnRQKd(actionElementMap2.kzHrLfsGRteEloHDejoDrezLTRte, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
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
			for (int num2 = COKsUhVIexooKQPdJlLSyjGAwvHS.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[num2];
				if ((!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					uPUJuVWvHejsPlGhkNJkxxqnRQKd(actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int IRPsLveRpxIgSKSPjhMvubUmkboj(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.lhoZhSkWcQiKkhcUsCDVAbumRbhbA(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
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
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (!actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int gbHacIvEfQScNxhPMLPLyEFOVlbI(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.jjBRzRaCxXgpPBoKPyxthlDsuMvW(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int PknDYYPRUCNvghFglduDPzXjgetX(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.JrrMBvqXYDRKjEDTxGqUHoNrLTPEA(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
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
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				array[i] = COKsUhVIexooKQPdJlLSyjGAwvHS[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool ozsFxTibTudXVrmZePzNEVqibhHFb(ActionElementMap P_0)
		{
			if (base.LtPlOjVYNTfYZlErEqgWUUqCmfNC(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(elementType))
			{
				return false;
			}
			WgkuZVljONcRmgcjqWGSknWTNeeR(P_0);
			return true;
		}

		internal virtual int GummhDQjwUufSdFbzyCFnZWuQFmh(List<ActionElementMap> P_0, bool P_1)
		{
			base.hpqSabusThMLITaQcbpxXKvxXcUQ(P_0, P_1);
			int count = P_0.Count;
			int count2 = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || COKsUhVIexooKQPdJlLSyjGAwvHS[i].vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					P_0.Add(COKsUhVIexooKQPdJlLSyjGAwvHS[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap yAwpTlVVmXnKthJejopqPPJmKgEQ(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.EoMduUgdNytAMhPHzClBtYEjnCnv(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(P_2))
			{
				return null;
			}
			int num = uKQzuGflsGWiYcDzJtLWvdiMIfKiA(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return COKsUhVIexooKQPdJlLSyjGAwvHS[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int eEMxjmhNSegsrcRJrljhfEImuhpuA(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.xonFjqeWWbHFzWPtLrmcEPfLfugx(P_0, P_1, P_2);
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return P_1.Count - num;
			}
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				if (COKsUhVIexooKQPdJlLSyjGAwvHS[i]._elementIdentifierId == P_0)
				{
					P_1.Add(COKsUhVIexooKQPdJlLSyjGAwvHS[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool yffSbwPwXFuzTIEjLIqzccGJaBLY(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.sapUymPQxuCcfmyfjEnyybsZOplQ(P_0, P_1, P_2))
			{
				return true;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
				for (int i = 0; i < count; i++)
				{
					if (COKsUhVIexooKQPdJlLSyjGAwvHS[i]._elementIdentifierId == P_0 && COKsUhVIexooKQPdJlLSyjGAwvHS[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int iLlFXrhaiziuljndNLyQcyMhPgrAb(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.uKQzuGflsGWiYcDzJtLWvdiMIfKiA(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(P_2))
			{
				return -1;
			}
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
				for (int i = 0; i < count; i++)
				{
					if (COKsUhVIexooKQPdJlLSyjGAwvHS[i]._elementIdentifierId == P_0 && COKsUhVIexooKQPdJlLSyjGAwvHS[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int LAOjcdcSiPkCdbTVKbIlcONgPUTEB(int P_0)
		{
			if (COKsUhVIexooKQPdJlLSyjGAwvHS == null)
			{
				return -1;
			}
			int count = COKsUhVIexooKQPdJlLSyjGAwvHS.Count;
			for (int i = 0; i < count; i++)
			{
				if (COKsUhVIexooKQPdJlLSyjGAwvHS[i].kzHrLfsGRteEloHDejoDrezLTRte == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int hxzzdHOYuUCHHFnXvYtxTkyvVYnf(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (!P_0 || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int GMNFzlRQsOUDALCxejgsZVWbplWq(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int PubmKfuHDtnqphdfCDhOaaegeZDSA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.TmXDUiZTjaAxVkVMuzfnVVNJDceO(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap iCGsmHCDVJCTwnXjAlPKfoonalJl(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.IspGxunnuOvRuAdoVQLNZwuTNSyf(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || COKsUhVIexooKQPdJlLSyjGAwvHS[i]._actionId == P_2) && (!P_3 || COKsUhVIexooKQPdJlLSyjGAwvHS[i].vWZNVuVXYnOfJimlqfUderrRDbRk) && COKsUhVIexooKQPdJlLSyjGAwvHS[i].IsTarget(P_0))
				{
					return COKsUhVIexooKQPdJlLSyjGAwvHS[i];
				}
			}
			return null;
		}

		internal virtual int ixByqIsnRuFIgCicvEJUwMrDLoPw(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.biNGvbASEzcfdrNskXzGrsWeiLTVA(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || COKsUhVIexooKQPdJlLSyjGAwvHS[i]._actionId == P_2) && (!P_3 || COKsUhVIexooKQPdJlLSyjGAwvHS[i].vWZNVuVXYnOfJimlqfUderrRDbRk) && COKsUhVIexooKQPdJlLSyjGAwvHS[i].IsTarget(P_0))
				{
					P_4.Add(COKsUhVIexooKQPdJlLSyjGAwvHS[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool fvbyXApfAlBZpOwfsyiiMiMnISJd(ActionElementMap P_0)
		{
			if (base.ElxoijAztPBQPndXqbcVrWBFEkYHA(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!JgKoLmZJyFbmokmSHmXgLqcEKlkiA(P_0._elementType))
			{
				return false;
			}
			COKsUhVIexooKQPdJlLSyjGAwvHS.Add(P_0);
			SSQfFmKlDdRCBfFbKpGLxXqWYkrf(P_0);
			return true;
		}

		private bool JgKoLmZJyFbmokmSHmXgLqcEKlkiA(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void uPUJuVWvHejsPlGhkNJkxxqnRQKd(int P_0, int P_1)
		{
			QIOZVxWMlTDVWBVkcoVaNAuTusPJ(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				COKsUhVIexooKQPdJlLSyjGAwvHS.RemoveAt(P_1);
			}
		}

		private void WgkuZVljONcRmgcjqWGSknWTNeeR(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				COKsUhVIexooKQPdJlLSyjGAwvHS.Add(P_0);
				SSQfFmKlDdRCBfFbKpGLxXqWYkrf(P_0);
			}
		}

		private void ODrPUjMkfaZJdLWxvXXIjUFVQayB(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				sNYoQWBqtQgiROknVvKfdbNoiBeH(COKsUhVIexooKQPdJlLSyjGAwvHS[P_1].kzHrLfsGRteEloHDejoDrezLTRte, P_0);
				COKsUhVIexooKQPdJlLSyjGAwvHS[P_1] = P_0;
			}
		}

		internal virtual void FxGiueOrkMAJvLwZZbzyZvJBaQdHA(SerializedObject P_0)
		{
			base.uwAYdMrDJPhumhAFmaccaZNzGqEyA(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (COKsUhVIexooKQPdJlLSyjGAwvHS[i] != null)
				{
					list.Add(COKsUhVIexooKQPdJlLSyjGAwvHS[i].yLLQaYNTgPqJqwARjNubvJJUJcvv());
				}
			}
		}

		internal virtual bool ZvUegIihCHvwfHYPcXvbgdzHrKHlA(SerializedObject P_0)
		{
			bool flag = base.ZVXtcMiUwlpvErxTZfSqcUNoHRIn(P_0);
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
						actionElementMap.gCKvccrHYEoqqBekokCUNAtDNOif(value2);
						if (ActionElementMap.shTAdQDevfqGEetMFpDyDnHLMEor(actionElementMap))
						{
							WgkuZVljONcRmgcjqWGSknWTNeeR(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> uTQxtZjLtknDOJXblALnXhfMcGHCA(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> VHJJUrARpTJoQymbXiLtcPASnXBcb(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> LnUmCoZPSlMrjOLsKZHcYiYIoGXX(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
