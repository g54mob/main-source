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
		private sealed class TAijlMJvGtSPCkkUTrutsQITjMi : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMapWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

			public int gmlZVSBTtPIWuYPylEQcoNUGUio;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public ActionElementMap WycJzDLiPpnjjTwPTiblgfYHqVh;

			public IEnumerator<ActionElementMap> oOiJQmAZYlkNpzlhWqZoTNEPwmU;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				TAijlMJvGtSPCkkUTrutsQITjMi tAijlMJvGtSPCkkUTrutsQITjMi;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					tAijlMJvGtSPCkkUTrutsQITjMi = this;
				}
				else
				{
					tAijlMJvGtSPCkkUTrutsQITjMi = new TAijlMJvGtSPCkkUTrutsQITjMi(0);
					tAijlMJvGtSPCkkUTrutsQITjMi.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				tAijlMJvGtSPCkkUTrutsQITjMi.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
				tAijlMJvGtSPCkkUTrutsQITjMi.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return tAijlMJvGtSPCkkUTrutsQITjMi;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
						{
							break;
						}
						oOiJQmAZYlkNpzlhWqZoTNEPwmU = GxphHAMqMhNBLjnlhXuBQmXaALiE.AxisMaps.GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00cf;
					case 2:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_00cf;
						}
						IL_00cf:
						while (oOiJQmAZYlkNpzlhWqZoTNEPwmU.MoveNext())
						{
							WycJzDLiPpnjjTwPTiblgfYHqVh = oOiJQmAZYlkNpzlhWqZoTNEPwmU.Current;
							if (WycJzDLiPpnjjTwPTiblgfYHqVh._actionId == aCGiPaCCkBbVoaUFLfEYHFYRMYCM && (!IftNYOsoyZKKlecDyJEriHNLMeG || WycJzDLiPpnjjTwPTiblgfYHqVh.fnEBjitvkHhPtXTzRLmBYpIxFbt))
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = WycJzDLiPpnjjTwPTiblgfYHqVh;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						chVanVroUjkfSDecEZVwJLCZdvCD();
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						chVanVroUjkfSDecEZVwJLCZdvCD();
					}
				}
			}

			[DebuggerHidden]
			public TAijlMJvGtSPCkkUTrutsQITjMi(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void chVanVroUjkfSDecEZVwJLCZdvCD()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (oOiJQmAZYlkNpzlhWqZoTNEPwmU != null)
				{
					oOiJQmAZYlkNpzlhWqZoTNEPwmU.Dispose();
				}
			}
		}

		private sealed class KUznxClsdARSCiQThjqMDjCDPUn : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMapWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ControllerMap nuUgjEKzUuMYBIiHUtitJvzUOOl;

			public ControllerMap sNhfYAVoaqivqYEVUlVeZtnUREN;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public ElementAssignmentConflictInfo sgDnHZAKyoKDNbgFQREgCFsnaAY;

			public ControllerMapWithAxes ucEIcmJKDSoCPAVbsdwbzdhMoZR;

			public IList<ActionElementMap> KIWqlmkjNynIbSvvkkIMXwwltpR;

			public int KRnitAzpBUEJAHqYFAmeEALHaXsn;

			public int AZdJyxbwxOciBTxHWgYSvgrbRGz;

			public ActionElementMap gVOhmBtbLLLAJFUmJmmuhRHMFWm;

			public int vwkKnkqBHlzpcQsamlcAXHKlXEB;

			public ActionElementMap fUhEsMyezcbicJQhPywAloseCGw;

			public IEnumerator<ElementAssignmentConflictInfo> KaEfmXsndxbkMawYqOndCLZNcHFj;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				KUznxClsdARSCiQThjqMDjCDPUn kUznxClsdARSCiQThjqMDjCDPUn;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					kUznxClsdARSCiQThjqMDjCDPUn = this;
				}
				else
				{
					kUznxClsdARSCiQThjqMDjCDPUn = new KUznxClsdARSCiQThjqMDjCDPUn(0);
					kUznxClsdARSCiQThjqMDjCDPUn.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				kUznxClsdARSCiQThjqMDjCDPUn.nuUgjEKzUuMYBIiHUtitJvzUOOl = sNhfYAVoaqivqYEVUlVeZtnUREN;
				kUznxClsdARSCiQThjqMDjCDPUn.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return kUznxClsdARSCiQThjqMDjCDPUn;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						if (nuUgjEKzUuMYBIiHUtitJvzUOOl == null)
						{
							break;
						}
						KaEfmXsndxbkMawYqOndCLZNcHFj = ((ControllerMap)GxphHAMqMhNBLjnlhXuBQmXaALiE).ElementAssignmentConflicts(nuUgjEKzUuMYBIiHUtitJvzUOOl, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00b9;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00b9;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_026a;
						}
						IL_0297:
						if (AZdJyxbwxOciBTxHWgYSvgrbRGz >= GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR.Count)
						{
							break;
						}
						gVOhmBtbLLLAJFUmJmmuhRHMFWm = GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR[AZdJyxbwxOciBTxHWgYSvgrbRGz];
						if (!IftNYOsoyZKKlecDyJEriHNLMeG || gVOhmBtbLLLAJFUmJmmuhRHMFWm.fnEBjitvkHhPtXTzRLmBYpIxFbt)
						{
							vwkKnkqBHlzpcQsamlcAXHKlXEB = 0;
							goto IL_0278;
						}
						goto IL_0289;
						IL_026a:
						vwkKnkqBHlzpcQsamlcAXHKlXEB++;
						goto IL_0278;
						IL_0278:
						if (vwkKnkqBHlzpcQsamlcAXHKlXEB < KRnitAzpBUEJAHqYFAmeEALHaXsn)
						{
							fUhEsMyezcbicJQhPywAloseCGw = KIWqlmkjNynIbSvvkkIMXwwltpR[vwkKnkqBHlzpcQsamlcAXHKlXEB];
							if ((!IftNYOsoyZKKlecDyJEriHNLMeG || fUhEsMyezcbicJQhPywAloseCGw.fnEBjitvkHhPtXTzRLmBYpIxFbt) && gVOhmBtbLLLAJFUmJmmuhRHMFWm.CheckForAssignmentConflict(fUhEsMyezcbicJQhPywAloseCGw))
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(GxphHAMqMhNBLjnlhXuBQmXaALiE._categoryId).userAssignable, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerType, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerId, GxphHAMqMhNBLjnlhXuBQmXaALiE._id, gVOhmBtbLLLAJFUmJmmuhRHMFWm.JYRMuwETpVNRqJXmtBgBFhZdTeP, gVOhmBtbLLLAJFUmJmmuhRHMFWm._actionId, gVOhmBtbLLLAJFUmJmmuhRHMFWm._elementType, gVOhmBtbLLLAJFUmJmmuhRHMFWm._elementIdentifierId, gVOhmBtbLLLAJFUmJmmuhRHMFWm.keyCode, gVOhmBtbLLLAJFUmJmmuhRHMFWm.modifierKeyFlags);
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								return true;
							}
							goto IL_026a;
						}
						goto IL_0289;
						IL_00b9:
						if (KaEfmXsndxbkMawYqOndCLZNcHFj.MoveNext())
						{
							sgDnHZAKyoKDNbgFQREgCFsnaAY = KaEfmXsndxbkMawYqOndCLZNcHFj.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = sgDnHZAKyoKDNbgFQREgCFsnaAY;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						xJmOHvAruQrlprcjjyHyofaoiNQC();
						ucEIcmJKDSoCPAVbsdwbzdhMoZR = nuUgjEKzUuMYBIiHUtitJvzUOOl as ControllerMapWithAxes;
						if (ucEIcmJKDSoCPAVbsdwbzdhMoZR == null || (IftNYOsoyZKKlecDyJEriHNLMeG && (!GxphHAMqMhNBLjnlhXuBQmXaALiE._enabled || !ucEIcmJKDSoCPAVbsdwbzdhMoZR._enabled)))
						{
							break;
						}
						KIWqlmkjNynIbSvvkkIMXwwltpR = ucEIcmJKDSoCPAVbsdwbzdhMoZR.AxisMaps;
						if (KIWqlmkjNynIbSvvkkIMXwwltpR == null)
						{
							break;
						}
						KRnitAzpBUEJAHqYFAmeEALHaXsn = KIWqlmkjNynIbSvvkkIMXwwltpR.Count;
						AZdJyxbwxOciBTxHWgYSvgrbRGz = 0;
						goto IL_0297;
						IL_0289:
						AZdJyxbwxOciBTxHWgYSvgrbRGz++;
						goto IL_0297;
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						xJmOHvAruQrlprcjjyHyofaoiNQC();
					}
				}
			}

			[DebuggerHidden]
			public KUznxClsdARSCiQThjqMDjCDPUn(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void xJmOHvAruQrlprcjjyHyofaoiNQC()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (KaEfmXsndxbkMawYqOndCLZNcHFj != null)
				{
					KaEfmXsndxbkMawYqOndCLZNcHFj.Dispose();
				}
			}
		}

		private sealed class SsWFBZBlIzJzwaAIfYrnOhJCPiCb : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMapWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ActionElementMap PgtyCGUpZbAlPcnBMkOdtmXxupEd;

			public ActionElementMap mHXCJMfdawKqIiVysYybBSiVrhGm;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public ElementAssignmentConflictInfo XRuVChafSQEgSQXqRhJonhIuJfx;

			public int MnCtmvwLnTifWFWdMfUSRnJWQyDB;

			public ActionElementMap HHnGBomKCOaVzcljGQeDdXRsOhr;

			public IEnumerator<ElementAssignmentConflictInfo> pQQgDOamAImrOBYOzBHtmuoGCli;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				SsWFBZBlIzJzwaAIfYrnOhJCPiCb ssWFBZBlIzJzwaAIfYrnOhJCPiCb;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					ssWFBZBlIzJzwaAIfYrnOhJCPiCb = this;
				}
				else
				{
					ssWFBZBlIzJzwaAIfYrnOhJCPiCb = new SsWFBZBlIzJzwaAIfYrnOhJCPiCb(0);
					ssWFBZBlIzJzwaAIfYrnOhJCPiCb.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				ssWFBZBlIzJzwaAIfYrnOhJCPiCb.PgtyCGUpZbAlPcnBMkOdtmXxupEd = mHXCJMfdawKqIiVysYybBSiVrhGm;
				ssWFBZBlIzJzwaAIfYrnOhJCPiCb.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return ssWFBZBlIzJzwaAIfYrnOhJCPiCb;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						if (PgtyCGUpZbAlPcnBMkOdtmXxupEd == null)
						{
							break;
						}
						pQQgDOamAImrOBYOzBHtmuoGCli = ((ControllerMap)GxphHAMqMhNBLjnlhXuBQmXaALiE).ElementAssignmentConflicts(PgtyCGUpZbAlPcnBMkOdtmXxupEd, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00b9;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00b9;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_01f6;
						}
						IL_00b9:
						if (pQQgDOamAImrOBYOzBHtmuoGCli.MoveNext())
						{
							XRuVChafSQEgSQXqRhJonhIuJfx = pQQgDOamAImrOBYOzBHtmuoGCli.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = XRuVChafSQEgSQXqRhJonhIuJfx;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						EdJjrVbPTpMnGGxMAFYafucXcSIe();
						if ((IftNYOsoyZKKlecDyJEriHNLMeG && (!GxphHAMqMhNBLjnlhXuBQmXaALiE._enabled || !PgtyCGUpZbAlPcnBMkOdtmXxupEd.fnEBjitvkHhPtXTzRLmBYpIxFbt)) || GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR == null)
						{
							break;
						}
						MnCtmvwLnTifWFWdMfUSRnJWQyDB = 0;
						goto IL_0204;
						IL_01f6:
						MnCtmvwLnTifWFWdMfUSRnJWQyDB++;
						goto IL_0204;
						IL_0204:
						if (MnCtmvwLnTifWFWdMfUSRnJWQyDB >= GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR.Count)
						{
							break;
						}
						HHnGBomKCOaVzcljGQeDdXRsOhr = GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR[MnCtmvwLnTifWFWdMfUSRnJWQyDB];
						if ((!IftNYOsoyZKKlecDyJEriHNLMeG || HHnGBomKCOaVzcljGQeDdXRsOhr.fnEBjitvkHhPtXTzRLmBYpIxFbt) && HHnGBomKCOaVzcljGQeDdXRsOhr.CheckForAssignmentConflict(PgtyCGUpZbAlPcnBMkOdtmXxupEd))
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(GxphHAMqMhNBLjnlhXuBQmXaALiE._categoryId).userAssignable, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerType, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerId, GxphHAMqMhNBLjnlhXuBQmXaALiE._id, HHnGBomKCOaVzcljGQeDdXRsOhr.JYRMuwETpVNRqJXmtBgBFhZdTeP, HHnGBomKCOaVzcljGQeDdXRsOhr._actionId, HHnGBomKCOaVzcljGQeDdXRsOhr._elementType, HHnGBomKCOaVzcljGQeDdXRsOhr._elementIdentifierId, HHnGBomKCOaVzcljGQeDdXRsOhr.keyCode, HHnGBomKCOaVzcljGQeDdXRsOhr.modifierKeyFlags);
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							return true;
						}
						goto IL_01f6;
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						EdJjrVbPTpMnGGxMAFYafucXcSIe();
					}
				}
			}

			[DebuggerHidden]
			public SsWFBZBlIzJzwaAIfYrnOhJCPiCb(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void EdJjrVbPTpMnGGxMAFYafucXcSIe()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (pQQgDOamAImrOBYOzBHtmuoGCli != null)
				{
					pQQgDOamAImrOBYOzBHtmuoGCli.Dispose();
				}
			}
		}

		private sealed class zpbREHNoSTDXDETAlnDxFnICdYbk : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMapWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

			public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public ElementAssignmentConflictInfo dYVjoTVqSFbhmegXjhqKDBLjqPF;

			public ElementAssignment LqmZWLyrHrdyRvqZrnhiRaDmKWT;

			public int mhlGMtEArpthJntuNnJwFgsLCFcA;

			public ActionElementMap OKvVqXZGnfogAtqGdBKRJadRAStm;

			public IEnumerator<ElementAssignmentConflictInfo> TbflGFzCIegMUBWwFNgaaCYefLCG;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				zpbREHNoSTDXDETAlnDxFnICdYbk zpbREHNoSTDXDETAlnDxFnICdYbk2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					zpbREHNoSTDXDETAlnDxFnICdYbk2 = this;
				}
				else
				{
					zpbREHNoSTDXDETAlnDxFnICdYbk2 = new zpbREHNoSTDXDETAlnDxFnICdYbk(0);
					zpbREHNoSTDXDETAlnDxFnICdYbk2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				zpbREHNoSTDXDETAlnDxFnICdYbk2.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
				zpbREHNoSTDXDETAlnDxFnICdYbk2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return zpbREHNoSTDXDETAlnDxFnICdYbk2;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						TbflGFzCIegMUBWwFNgaaCYefLCG = ((ControllerMap)GxphHAMqMhNBLjnlhXuBQmXaALiE).ElementAssignmentConflicts(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00ae;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00ae;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_0207;
						}
						IL_0215:
						if (mhlGMtEArpthJntuNnJwFgsLCFcA >= GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR.Count)
						{
							break;
						}
						OKvVqXZGnfogAtqGdBKRJadRAStm = GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR[mhlGMtEArpthJntuNnJwFgsLCFcA];
						if ((!IftNYOsoyZKKlecDyJEriHNLMeG || OKvVqXZGnfogAtqGdBKRJadRAStm.fnEBjitvkHhPtXTzRLmBYpIxFbt) && OKvVqXZGnfogAtqGdBKRJadRAStm.JYRMuwETpVNRqJXmtBgBFhZdTeP != CNxRWxtJdpKgAXgEBkMvLnqPffs.elementMapId && OKvVqXZGnfogAtqGdBKRJadRAStm.CheckForAssignmentConflict(LqmZWLyrHrdyRvqZrnhiRaDmKWT))
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(GxphHAMqMhNBLjnlhXuBQmXaALiE._categoryId).userAssignable, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerType, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerId, GxphHAMqMhNBLjnlhXuBQmXaALiE._id, OKvVqXZGnfogAtqGdBKRJadRAStm.JYRMuwETpVNRqJXmtBgBFhZdTeP, OKvVqXZGnfogAtqGdBKRJadRAStm._actionId, OKvVqXZGnfogAtqGdBKRJadRAStm._elementType, OKvVqXZGnfogAtqGdBKRJadRAStm._elementIdentifierId, OKvVqXZGnfogAtqGdBKRJadRAStm.keyCode, OKvVqXZGnfogAtqGdBKRJadRAStm.modifierKeyFlags);
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							return true;
						}
						goto IL_0207;
						IL_0207:
						mhlGMtEArpthJntuNnJwFgsLCFcA++;
						goto IL_0215;
						IL_00ae:
						if (TbflGFzCIegMUBWwFNgaaCYefLCG.MoveNext())
						{
							dYVjoTVqSFbhmegXjhqKDBLjqPF = TbflGFzCIegMUBWwFNgaaCYefLCG.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = dYVjoTVqSFbhmegXjhqKDBLjqPF;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						zbOGcIPpsCGOSHnnKIyVBOylOKpv();
						if ((IftNYOsoyZKKlecDyJEriHNLMeG && !GxphHAMqMhNBLjnlhXuBQmXaALiE._enabled) || GxphHAMqMhNBLjnlhXuBQmXaALiE.QIIPyfmhjZfWULtHNJkLimftCMR == null)
						{
							break;
						}
						LqmZWLyrHrdyRvqZrnhiRaDmKWT = CNxRWxtJdpKgAXgEBkMvLnqPffs.ToElementAssignment();
						mhlGMtEArpthJntuNnJwFgsLCFcA = 0;
						goto IL_0215;
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						zbOGcIPpsCGOSHnnKIyVBOylOKpv();
					}
				}
			}

			[DebuggerHidden]
			public zpbREHNoSTDXDETAlnDxFnICdYbk(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void zbOGcIPpsCGOSHnnKIyVBOylOKpv()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (TbflGFzCIegMUBWwFNgaaCYefLCG != null)
				{
					TbflGFzCIegMUBWwFNgaaCYefLCG.Dispose();
				}
			}
		}

		private readonly IList<ActionElementMap> QIIPyfmhjZfWULtHNJkLimftCMR;

		private readonly ReadOnlyCollection<ActionElementMap> fZFJTzWfQggZrbhChXEHUkWJLcvN;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
				{
					return 0;
				}
				return QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return fZFJTzWfQggZrbhChXEHUkWJLcvN;
			}
		}

		internal AList<ActionElementMap> AxisMaps_orig => (AList<ActionElementMap>)QIIPyfmhjZfWULtHNJkLimftCMR;

		public ControllerMapWithAxes()
		{
			QIIPyfmhjZfWULtHNJkLimftCMR = new AList<ActionElementMap>();
			fZFJTzWfQggZrbhChXEHUkWJLcvN = new ReadOnlyCollection<ActionElementMap>(QIIPyfmhjZfWULtHNJkLimftCMR);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes controllerMap)
			: base(controllerMap)
		{
			QIIPyfmhjZfWULtHNJkLimftCMR = new AList<ActionElementMap>();
			fZFJTzWfQggZrbhChXEHUkWJLcvN = new ReadOnlyCollection<ActionElementMap>(QIIPyfmhjZfWULtHNJkLimftCMR);
			if (controllerMap.QIIPyfmhjZfWULtHNJkLimftCMR != null)
			{
				int count = controllerMap.QIIPyfmhjZfWULtHNJkLimftCMR.Count;
				for (int i = 0; i < count; i++)
				{
					WCGfZRZjeZiaYggHzNoEKCSWLck(new ActionElementMap(controllerMap.QIIPyfmhjZfWULtHNJkLimftCMR[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return false;
			}
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				if (QIIPyfmhjZfWULtHNJkLimftCMR[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			WCGfZRZjeZiaYggHzNoEKCSWLck(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				WCGfZRZjeZiaYggHzNoEKCSWLck(elementMap);
			}
			int num = AyFJSUQpkjeWhBnjxzCqmBfyBqG(elementMapId);
			if (num < 0)
			{
				return false;
			}
			ControllerMap.PnTxkUsNLsMLtRkowVxXNqXtKTz(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = AyFJSUQpkjeWhBnjxzCqmBfyBqG(elementMapId);
			if (num < 0)
			{
				return false;
			}
			wsrjUcoSENYomkTwEAZaBOuTKhS(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			bool flag = base.DeleteElementMapsWithAction(actionId);
			return flag | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return null;
			}
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				if (QIIPyfmhjZfWULtHNJkLimftCMR[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == elementMapId)
				{
					return QIIPyfmhjZfWULtHNJkLimftCMR[i];
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal override ActionElementMap LbHFzRhtKzMoxHHeraoJEMXHiGoC(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.LbHFzRhtKzMoxHHeraoJEMXHiGoC(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return tcLJUVCmOdIjVhTGkYGPOInWszO(P_0, P_1);
		}

		internal override int tMcZjSpjAIyKwgdHGinagsvLTzE(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.tMcZjSpjAIyKwgdHGinagsvLTzE(P_0, P_1, P_2, P_3);
			return num + tgTybbCzlUYSUBCDcConeGPKZqh(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			base.ClearElementMaps();
			QIIPyfmhjZfWULtHNJkLimftCMR.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null || index < 0 || index >= QIIPyfmhjZfWULtHNJkLimftCMR.Count)
			{
				return null;
			}
			return QIIPyfmhjZfWULtHNJkLimftCMR[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(QIIPyfmhjZfWULtHNJkLimftCMR);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return JoPQMeHZQGVhbHCoKrTzMYVBIZx(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
				ActionElementMap actionElementMap2 = QIIPyfmhjZfWULtHNJkLimftCMR[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return OPLgbMnDTUePxNEOivAOYPYzSya(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			TAijlMJvGtSPCkkUTrutsQITjMi tAijlMJvGtSPCkkUTrutsQITjMi = new TAijlMJvGtSPCkkUTrutsQITjMi(-2);
			tAijlMJvGtSPCkkUTrutsQITjMi.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			tAijlMJvGtSPCkkUTrutsQITjMi.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
			tAijlMJvGtSPCkkUTrutsQITjMi.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return tAijlMJvGtSPCkkUTrutsQITjMi;
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return tcLJUVCmOdIjVhTGkYGPOInWszO(predicate, false);
		}

		internal ActionElementMap tcLJUVCmOdIjVhTGkYGPOInWszO(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return tgTybbCzlUYSUBCDcConeGPKZqh(predicate, false, results, false);
		}

		internal int tgTybbCzlUYSUBCDcConeGPKZqh(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = QIIPyfmhjZfWULtHNJkLimftCMR[i];
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
			return DeleteAxisMapsWithAction(ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				if (QIIPyfmhjZfWULtHNJkLimftCMR[num2] != null && QIIPyfmhjZfWULtHNJkLimftCMR[num2]._actionId == actionId)
				{
					wsrjUcoSENYomkTwEAZaBOuTKhS(QIIPyfmhjZfWULtHNJkLimftCMR[num2].JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int num = 0;
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt != state)
				{
					actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (skipDisabledMaps && !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
			{
				return false;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return false;
			}
			for (int i = 0; i < QIIPyfmhjZfWULtHNJkLimftCMR.Count; i++)
			{
				ActionElementMap actionElementMap2 = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < QIIPyfmhjZfWULtHNJkLimftCMR.Count; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if ((!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			KUznxClsdARSCiQThjqMDjCDPUn kUznxClsdARSCiQThjqMDjCDPUn = new KUznxClsdARSCiQThjqMDjCDPUn(-2);
			kUznxClsdARSCiQThjqMDjCDPUn.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			kUznxClsdARSCiQThjqMDjCDPUn.sNhfYAVoaqivqYEVUlVeZtnUREN = controllerMap;
			kUznxClsdARSCiQThjqMDjCDPUn.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return kUznxClsdARSCiQThjqMDjCDPUn;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			SsWFBZBlIzJzwaAIfYrnOhJCPiCb ssWFBZBlIzJzwaAIfYrnOhJCPiCb = new SsWFBZBlIzJzwaAIfYrnOhJCPiCb(-2);
			ssWFBZBlIzJzwaAIfYrnOhJCPiCb.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			ssWFBZBlIzJzwaAIfYrnOhJCPiCb.mHXCJMfdawKqIiVysYybBSiVrhGm = actionElementMap;
			ssWFBZBlIzJzwaAIfYrnOhJCPiCb.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return ssWFBZBlIzJzwaAIfYrnOhJCPiCb;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			zpbREHNoSTDXDETAlnDxFnICdYbk zpbREHNoSTDXDETAlnDxFnICdYbk2 = new zpbREHNoSTDXDETAlnDxFnICdYbk(-2);
			zpbREHNoSTDXDETAlnDxFnICdYbk2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			zpbREHNoSTDXDETAlnDxFnICdYbk2.VliyeXpMEMSvNHleVqLftHsOCYq = conflictCheck;
			zpbREHNoSTDXDETAlnDxFnICdYbk2.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return zpbREHNoSTDXDETAlnDxFnICdYbk2;
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
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
			_ = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			int count = axisMaps.Count;
			for (int num2 = QIIPyfmhjZfWULtHNJkLimftCMR.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[num2];
				if (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							wsrjUcoSENYomkTwEAZaBOuTKhS(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return num;
			}
			for (int num2 = QIIPyfmhjZfWULtHNJkLimftCMR.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = QIIPyfmhjZfWULtHNJkLimftCMR[num2];
				if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					wsrjUcoSENYomkTwEAZaBOuTKhS(actionElementMap2.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
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
			for (int num2 = QIIPyfmhjZfWULtHNJkLimftCMR.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[num2];
				if ((!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					wsrjUcoSENYomkTwEAZaBOuTKhS(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
					num++;
				}
			}
			return num;
		}

		internal override int uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
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
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (!actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal override int uYwxIBEwgxONcHwzfXTGnIioFcq(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override int uYwxIBEwgxONcHwzfXTGnIioFcq(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
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
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				array[i] = QIIPyfmhjZfWULtHNJkLimftCMR[i].elementIdentifierName;
			}
			return array;
		}

		internal override bool iXVFNbKWeZKqDcDBYTqLDREGlmD(ActionElementMap P_0)
		{
			if (base.iXVFNbKWeZKqDcDBYTqLDREGlmD(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementType))
			{
				return false;
			}
			WCGfZRZjeZiaYggHzNoEKCSWLck(P_0);
			return true;
		}

		internal override int VPLwlUlbVJcGxInkzAvGWInfZls(List<ActionElementMap> P_0, bool P_1)
		{
			base.VPLwlUlbVJcGxInkzAvGWInfZls(P_0, P_1);
			int count = P_0.Count;
			int count2 = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || QIIPyfmhjZfWULtHNJkLimftCMR[i].fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					P_0.Add(QIIPyfmhjZfWULtHNJkLimftCMR[i]);
				}
			}
			return P_0.Count - count;
		}

		internal override ActionElementMap abscXzkbpziyejRZVLMtgMvqAFy(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.abscXzkbpziyejRZVLMtgMvqAFy(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_2))
			{
				return null;
			}
			int num = kncrJkmpVAOgmtLIWIwSzrcRtQu(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return QIIPyfmhjZfWULtHNJkLimftCMR[num];
			}
			throw new NotImplementedException();
		}

		internal override int NKYfbOdBSBNhrFNHdTAMOylLEUac(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.NKYfbOdBSBNhrFNHdTAMOylLEUac(P_0, P_1, P_2);
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return P_1.Count - num;
			}
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				if (QIIPyfmhjZfWULtHNJkLimftCMR[i]._elementIdentifierId == P_0)
				{
					P_1.Add(QIIPyfmhjZfWULtHNJkLimftCMR[i]);
				}
			}
			return P_1.Count - num;
		}

		internal override bool VwahVJeKeHeJMeEBtlOFHnajoCLq(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.VwahVJeKeHeJMeEBtlOFHnajoCLq(P_0, P_1, P_2))
			{
				return true;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
				for (int i = 0; i < count; i++)
				{
					if (QIIPyfmhjZfWULtHNJkLimftCMR[i]._elementIdentifierId == P_0 && QIIPyfmhjZfWULtHNJkLimftCMR[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal override int kncrJkmpVAOgmtLIWIwSzrcRtQu(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.kncrJkmpVAOgmtLIWIwSzrcRtQu(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_2))
			{
				return -1;
			}
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
				for (int i = 0; i < count; i++)
				{
					if (QIIPyfmhjZfWULtHNJkLimftCMR[i]._elementIdentifierId == P_0 && QIIPyfmhjZfWULtHNJkLimftCMR[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int AyFJSUQpkjeWhBnjxzCqmBfyBqG(int P_0)
		{
			if (QIIPyfmhjZfWULtHNJkLimftCMR == null)
			{
				return -1;
			}
			int count = QIIPyfmhjZfWULtHNJkLimftCMR.Count;
			for (int i = 0; i < count; i++)
			{
				if (QIIPyfmhjZfWULtHNJkLimftCMR[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int JoPQMeHZQGVhbHCoKrTzMYVBIZx(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (!P_0 || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int OPLgbMnDTUePxNEOivAOYPYzSya(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal override int paPqgnqavLYCqgponTssufOHcpc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.paPqgnqavLYCqgponTssufOHcpc(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = QIIPyfmhjZfWULtHNJkLimftCMR[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override ActionElementMap TythgSbwYmNijsQNDAZZfufNFdk(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.TythgSbwYmNijsQNDAZZfufNFdk(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || QIIPyfmhjZfWULtHNJkLimftCMR[i]._actionId == P_2) && (!P_3 || QIIPyfmhjZfWULtHNJkLimftCMR[i].fnEBjitvkHhPtXTzRLmBYpIxFbt) && QIIPyfmhjZfWULtHNJkLimftCMR[i].IsTarget(P_0))
				{
					return QIIPyfmhjZfWULtHNJkLimftCMR[i];
				}
			}
			return null;
		}

		internal override int VOIVoTgEPzUDZzgXkQydAIFJfLn(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.VOIVoTgEPzUDZzgXkQydAIFJfLn(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || QIIPyfmhjZfWULtHNJkLimftCMR[i]._actionId == P_2) && (!P_3 || QIIPyfmhjZfWULtHNJkLimftCMR[i].fnEBjitvkHhPtXTzRLmBYpIxFbt) && QIIPyfmhjZfWULtHNJkLimftCMR[i].IsTarget(P_0))
				{
					P_4.Add(QIIPyfmhjZfWULtHNJkLimftCMR[i]);
					num++;
				}
			}
			return num;
		}

		internal override bool IatatAaUtWRxlkFXsRjmLeztlkR(ActionElementMap P_0)
		{
			if (base.IatatAaUtWRxlkFXsRjmLeztlkR(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0._elementType))
			{
				return false;
			}
			QIIPyfmhjZfWULtHNJkLimftCMR.Add(P_0);
			jLuFBQmqnmBfWMLqKnmNxPAKHds(P_0);
			return true;
		}

		private bool bbEggoxgYPAkARDGnCkXZJCiEYGa(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void wsrjUcoSENYomkTwEAZaBOuTKhS(int P_0, int P_1)
		{
			hgneUeifSUUGUGPrMpPNWRmXcVz(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				QIIPyfmhjZfWULtHNJkLimftCMR.RemoveAt(P_1);
			}
		}

		private void WCGfZRZjeZiaYggHzNoEKCSWLck(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				QIIPyfmhjZfWULtHNJkLimftCMR.Add(P_0);
				jLuFBQmqnmBfWMLqKnmNxPAKHds(P_0);
			}
		}

		private void PTKxECPQwvfmMIsNmoaNcBTwTiU(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				yoQxGAHDlXiVoeZUaJPtQogDvOO(QIIPyfmhjZfWULtHNJkLimftCMR[P_1].JYRMuwETpVNRqJXmtBgBFhZdTeP, P_0);
				QIIPyfmhjZfWULtHNJkLimftCMR[P_1] = P_0;
			}
		}

		internal override void jcgUSwYyXKIwVuYwxHnWUgkgsoK(SerializedObject P_0)
		{
			base.jcgUSwYyXKIwVuYwxHnWUgkgsoK(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (QIIPyfmhjZfWULtHNJkLimftCMR[i] != null)
				{
					list.Add(QIIPyfmhjZfWULtHNJkLimftCMR[i].MtzBZMSurJCTTdjsBqkSRhDyHCFi());
				}
			}
		}

		internal override bool tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			bool flag = base.tlMbXbDwaaKJTudkJIuTPdZmwuo(P_0);
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
						actionElementMap.tlMbXbDwaaKJTudkJIuTPdZmwuo(value2);
						if (ActionElementMap.ZRWaEectppfsHBsWRgRqpGFYQNNI(actionElementMap))
						{
							WCGfZRZjeZiaYggHzNoEKCSWLck(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> IpzGIEirJtNikfXZAVwCmIiczniW(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> bIrdhmEIusYDyDWcPWAKuvIQvRE(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> pDYFRjHwoJgdODAsyLXYqavkrTs(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
