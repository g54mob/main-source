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
		private sealed class kDOiIfASNmArXLYBwfkYrjrehWOq : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int EBCGvgcHnNPaVAcShYTwSckGesTKb;

			private ActionElementMap hvOYxCWIViRdSMjTrqDqGZAcqkzf;

			private int eSUTEpVRJVpUQiqEdGuUNPMajvcK;

			public ControllerMapWithAxes xrviHfqaAjXlfLESIOZQrtGckudL;

			private int CwQGecRRGAoDMBTuhvStXDdJuiKA;

			public int rmXDQScjgalVvmnXcmKENVnKicWeA;

			private bool qMXXDiGIDVAsAFcPHHXnNesCOnwI;

			public bool hfplGaOdmngtLHxJXfOriBceNqMv;

			private IEnumerator<ActionElementMap> EnnrAiNjkLSDJbXsFWCoFTNRZrCG;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return hvOYxCWIViRdSMjTrqDqGZAcqkzf;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hvOYxCWIViRdSMjTrqDqGZAcqkzf;
				}
			}

			[DebuggerHidden]
			public kDOiIfASNmArXLYBwfkYrjrehWOq(int P_0)
			{
				EBCGvgcHnNPaVAcShYTwSckGesTKb = P_0;
				eSUTEpVRJVpUQiqEdGuUNPMajvcK = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int eBCGvgcHnNPaVAcShYTwSckGesTKb = EBCGvgcHnNPaVAcShYTwSckGesTKb;
				if (eBCGvgcHnNPaVAcShYTwSckGesTKb == -3 || eBCGvgcHnNPaVAcShYTwSckGesTKb == 1)
				{
					try
					{
					}
					finally
					{
						oXKjKVePlRHrrDjpRUoiUtPNDZWrA();
					}
				}
				EnnrAiNjkLSDJbXsFWCoFTNRZrCG = null;
				EBCGvgcHnNPaVAcShYTwSckGesTKb = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int eBCGvgcHnNPaVAcShYTwSckGesTKb = EBCGvgcHnNPaVAcShYTwSckGesTKb;
					ControllerMapWithAxes controllerMapWithAxes = xrviHfqaAjXlfLESIOZQrtGckudL;
					switch (eBCGvgcHnNPaVAcShYTwSckGesTKb)
					{
					default:
						return false;
					case 0:
						EBCGvgcHnNPaVAcShYTwSckGesTKb = -1;
						if (ReInput._id != controllerMapWithAxes.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						if (CwQGecRRGAoDMBTuhvStXDdJuiKA < 0)
						{
							return false;
						}
						EnnrAiNjkLSDJbXsFWCoFTNRZrCG = controllerMapWithAxes.AxisMaps.GetEnumerator();
						EBCGvgcHnNPaVAcShYTwSckGesTKb = -3;
						break;
					case 1:
						EBCGvgcHnNPaVAcShYTwSckGesTKb = -3;
						break;
					}
					while (EnnrAiNjkLSDJbXsFWCoFTNRZrCG.MoveNext())
					{
						ActionElementMap current = EnnrAiNjkLSDJbXsFWCoFTNRZrCG.Current;
						if (current._actionId == CwQGecRRGAoDMBTuhvStXDdJuiKA && (!qMXXDiGIDVAsAFcPHHXnNesCOnwI || current.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
						{
							hvOYxCWIViRdSMjTrqDqGZAcqkzf = current;
							EBCGvgcHnNPaVAcShYTwSckGesTKb = 1;
							return true;
						}
					}
					oXKjKVePlRHrrDjpRUoiUtPNDZWrA();
					EnnrAiNjkLSDJbXsFWCoFTNRZrCG = null;
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

			private void oXKjKVePlRHrrDjpRUoiUtPNDZWrA()
			{
				EBCGvgcHnNPaVAcShYTwSckGesTKb = -1;
				if (EnnrAiNjkLSDJbXsFWCoFTNRZrCG != null)
				{
					EnnrAiNjkLSDJbXsFWCoFTNRZrCG.Dispose();
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
				kDOiIfASNmArXLYBwfkYrjrehWOq kDOiIfASNmArXLYBwfkYrjrehWOq2;
				if (EBCGvgcHnNPaVAcShYTwSckGesTKb == -2 && eSUTEpVRJVpUQiqEdGuUNPMajvcK == Environment.CurrentManagedThreadId)
				{
					EBCGvgcHnNPaVAcShYTwSckGesTKb = 0;
					kDOiIfASNmArXLYBwfkYrjrehWOq2 = this;
				}
				else
				{
					kDOiIfASNmArXLYBwfkYrjrehWOq2 = new kDOiIfASNmArXLYBwfkYrjrehWOq(0);
					kDOiIfASNmArXLYBwfkYrjrehWOq2.xrviHfqaAjXlfLESIOZQrtGckudL = xrviHfqaAjXlfLESIOZQrtGckudL;
				}
				kDOiIfASNmArXLYBwfkYrjrehWOq2.CwQGecRRGAoDMBTuhvStXDdJuiKA = rmXDQScjgalVvmnXcmKENVnKicWeA;
				kDOiIfASNmArXLYBwfkYrjrehWOq2.qMXXDiGIDVAsAFcPHHXnNesCOnwI = hfplGaOdmngtLHxJXfOriBceNqMv;
				return kDOiIfASNmArXLYBwfkYrjrehWOq2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class aGTKideRUtDNEZFmtrbEhkDvcXnGA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int sjfJIqJmXArhqwoDsbpaglEgHDmib;

			private ElementAssignmentConflictInfo JkDcGSBvEQvpxaDqMJcPqhvCfsSBA;

			private int zYdpuGEcVNFdzBOOKaFemTIqNYft;

			public ControllerMapWithAxes gsDENorKfANOroDwbloNFmUJbFMdA;

			private ControllerMap EztctZbWBqWwtEncihAuzaJRYFINA;

			public ControllerMap vEtrMBCeUiHsezjbcgGgiyAMHhZJA;

			private bool gogvbxBAfjpYfWJjerJdPsGQuije;

			public bool LdjPPHqjuZcMjsYUExDTKsGXJQvc;

			private IList<ActionElementMap> rDqREknjwMyHxFQsumigWLwYIguF;

			private int kWxLwYRaFrozHQYfXaTLnvQmToqb;

			private IEnumerator<ElementAssignmentConflictInfo> swopvdjViNcqnuNDYNKEnfaFHsju;

			private int BTpGptZGCdcwnImgnhBrCKRPHNXcA;

			private ActionElementMap JFdcLCabTuoeJFxICReSTKzkRTjx;

			private int zQaabiikrsTlNbBKoBvBCrbcaQKkB;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JkDcGSBvEQvpxaDqMJcPqhvCfsSBA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JkDcGSBvEQvpxaDqMJcPqhvCfsSBA;
				}
			}

			[DebuggerHidden]
			public aGTKideRUtDNEZFmtrbEhkDvcXnGA(int P_0)
			{
				sjfJIqJmXArhqwoDsbpaglEgHDmib = P_0;
				zYdpuGEcVNFdzBOOKaFemTIqNYft = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = sjfJIqJmXArhqwoDsbpaglEgHDmib;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						rdvbbsHzOgdvwViqyYFTvYGqCjBxA();
					}
				}
				rDqREknjwMyHxFQsumigWLwYIguF = null;
				swopvdjViNcqnuNDYNKEnfaFHsju = null;
				JFdcLCabTuoeJFxICReSTKzkRTjx = null;
				sjfJIqJmXArhqwoDsbpaglEgHDmib = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = sjfJIqJmXArhqwoDsbpaglEgHDmib;
					ControllerMapWithAxes controllerMapWithAxes = gsDENorKfANOroDwbloNFmUJbFMdA;
					switch (num)
					{
					default:
						return false;
					case 0:
						sjfJIqJmXArhqwoDsbpaglEgHDmib = -1;
						if (ReInput._id != controllerMapWithAxes.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						if (EztctZbWBqWwtEncihAuzaJRYFINA == null)
						{
							return false;
						}
						swopvdjViNcqnuNDYNKEnfaFHsju = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(EztctZbWBqWwtEncihAuzaJRYFINA, gogvbxBAfjpYfWJjerJdPsGQuije).GetEnumerator();
						sjfJIqJmXArhqwoDsbpaglEgHDmib = -3;
						goto IL_00af;
					case 1:
						sjfJIqJmXArhqwoDsbpaglEgHDmib = -3;
						goto IL_00af;
					case 2:
						{
							sjfJIqJmXArhqwoDsbpaglEgHDmib = -1;
							goto IL_0232;
						}
						IL_0244:
						if (zQaabiikrsTlNbBKoBvBCrbcaQKkB < kWxLwYRaFrozHQYfXaTLnvQmToqb)
						{
							ActionElementMap actionElementMap = rDqREknjwMyHxFQsumigWLwYIguF[zQaabiikrsTlNbBKoBvBCrbcaQKkB];
							if ((!gogvbxBAfjpYfWJjerJdPsGQuije || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && JFdcLCabTuoeJFxICReSTKzkRTjx.CheckForAssignmentConflict(actionElementMap))
							{
								JkDcGSBvEQvpxaDqMJcPqhvCfsSBA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, JFdcLCabTuoeJFxICReSTKzkRTjx.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, JFdcLCabTuoeJFxICReSTKzkRTjx._actionId, JFdcLCabTuoeJFxICReSTKzkRTjx._elementType, JFdcLCabTuoeJFxICReSTKzkRTjx._elementIdentifierId, JFdcLCabTuoeJFxICReSTKzkRTjx.keyCode, JFdcLCabTuoeJFxICReSTKzkRTjx.modifierKeyFlags);
								sjfJIqJmXArhqwoDsbpaglEgHDmib = 2;
								return true;
							}
							goto IL_0232;
						}
						JFdcLCabTuoeJFxICReSTKzkRTjx = null;
						goto IL_025c;
						IL_0232:
						zQaabiikrsTlNbBKoBvBCrbcaQKkB++;
						goto IL_0244;
						IL_026e:
						if (BTpGptZGCdcwnImgnhBrCKRPHNXcA < controllerMapWithAxes.AsASIPXswErewsBzAgFtlBFLeHGGA.Count)
						{
							JFdcLCabTuoeJFxICReSTKzkRTjx = controllerMapWithAxes.AsASIPXswErewsBzAgFtlBFLeHGGA[BTpGptZGCdcwnImgnhBrCKRPHNXcA];
							if (!gogvbxBAfjpYfWJjerJdPsGQuije || JFdcLCabTuoeJFxICReSTKzkRTjx.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
							{
								zQaabiikrsTlNbBKoBvBCrbcaQKkB = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (swopvdjViNcqnuNDYNKEnfaFHsju.MoveNext())
						{
							ElementAssignmentConflictInfo current = swopvdjViNcqnuNDYNKEnfaFHsju.Current;
							JkDcGSBvEQvpxaDqMJcPqhvCfsSBA = current;
							sjfJIqJmXArhqwoDsbpaglEgHDmib = 1;
							return true;
						}
						rdvbbsHzOgdvwViqyYFTvYGqCjBxA();
						swopvdjViNcqnuNDYNKEnfaFHsju = null;
						if (!(EztctZbWBqWwtEncihAuzaJRYFINA is ControllerMapWithAxes controllerMapWithAxes2))
						{
							return false;
						}
						if (gogvbxBAfjpYfWJjerJdPsGQuije && (!controllerMapWithAxes._enabled || !controllerMapWithAxes2._enabled))
						{
							return false;
						}
						rDqREknjwMyHxFQsumigWLwYIguF = controllerMapWithAxes2.AxisMaps;
						if (rDqREknjwMyHxFQsumigWLwYIguF == null)
						{
							return false;
						}
						kWxLwYRaFrozHQYfXaTLnvQmToqb = rDqREknjwMyHxFQsumigWLwYIguF.Count;
						BTpGptZGCdcwnImgnhBrCKRPHNXcA = 0;
						goto IL_026e;
						IL_025c:
						BTpGptZGCdcwnImgnhBrCKRPHNXcA++;
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

			private void rdvbbsHzOgdvwViqyYFTvYGqCjBxA()
			{
				sjfJIqJmXArhqwoDsbpaglEgHDmib = -1;
				if (swopvdjViNcqnuNDYNKEnfaFHsju != null)
				{
					swopvdjViNcqnuNDYNKEnfaFHsju.Dispose();
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
				aGTKideRUtDNEZFmtrbEhkDvcXnGA aGTKideRUtDNEZFmtrbEhkDvcXnGA2;
				if (sjfJIqJmXArhqwoDsbpaglEgHDmib == -2 && zYdpuGEcVNFdzBOOKaFemTIqNYft == Environment.CurrentManagedThreadId)
				{
					sjfJIqJmXArhqwoDsbpaglEgHDmib = 0;
					aGTKideRUtDNEZFmtrbEhkDvcXnGA2 = this;
				}
				else
				{
					aGTKideRUtDNEZFmtrbEhkDvcXnGA2 = new aGTKideRUtDNEZFmtrbEhkDvcXnGA(0);
					aGTKideRUtDNEZFmtrbEhkDvcXnGA2.gsDENorKfANOroDwbloNFmUJbFMdA = gsDENorKfANOroDwbloNFmUJbFMdA;
				}
				aGTKideRUtDNEZFmtrbEhkDvcXnGA2.EztctZbWBqWwtEncihAuzaJRYFINA = vEtrMBCeUiHsezjbcgGgiyAMHhZJA;
				aGTKideRUtDNEZFmtrbEhkDvcXnGA2.gogvbxBAfjpYfWJjerJdPsGQuije = LdjPPHqjuZcMjsYUExDTKsGXJQvc;
				return aGTKideRUtDNEZFmtrbEhkDvcXnGA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class jKvbCwiimwGbfRDSQmJpiApjSKV : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int GQRbfRHkUdzKUafUtSwOyMAvjraW;

			private ElementAssignmentConflictInfo yJwleBEcSsAoNfrCYPmzuyAAARZK;

			private int xfssjbWNJvGqfTlUNSpHxWFbRhPm;

			public ControllerMapWithAxes XDSOKWEaAXpEQVxHvGuVyoVBZILL;

			private ActionElementMap vLNaLxHffkgugYOuYjRHrXgRoMkJ;

			public ActionElementMap DgNDsKKthfhlFtftPQdUgrmHWvnAA;

			private bool CvmypnNoUygbTpdEhGXocfvWnaHC;

			public bool GevvKzoyVplZwZToLFWevXOFVYlD;

			private IEnumerator<ElementAssignmentConflictInfo> zFWECEXmtKtwUlwApflfxYdKBdXf;

			private int CDglLTidYDGTchPNjBKKIHWmJFMYA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return yJwleBEcSsAoNfrCYPmzuyAAARZK;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yJwleBEcSsAoNfrCYPmzuyAAARZK;
				}
			}

			[DebuggerHidden]
			public jKvbCwiimwGbfRDSQmJpiApjSKV(int P_0)
			{
				GQRbfRHkUdzKUafUtSwOyMAvjraW = P_0;
				xfssjbWNJvGqfTlUNSpHxWFbRhPm = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gQRbfRHkUdzKUafUtSwOyMAvjraW = GQRbfRHkUdzKUafUtSwOyMAvjraW;
				if (gQRbfRHkUdzKUafUtSwOyMAvjraW == -3 || gQRbfRHkUdzKUafUtSwOyMAvjraW == 1)
				{
					try
					{
					}
					finally
					{
						rTtVKmURSOuqToZJpqFZkAyrXwvF();
					}
				}
				zFWECEXmtKtwUlwApflfxYdKBdXf = null;
				GQRbfRHkUdzKUafUtSwOyMAvjraW = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int gQRbfRHkUdzKUafUtSwOyMAvjraW = GQRbfRHkUdzKUafUtSwOyMAvjraW;
					ControllerMapWithAxes xDSOKWEaAXpEQVxHvGuVyoVBZILL = XDSOKWEaAXpEQVxHvGuVyoVBZILL;
					switch (gQRbfRHkUdzKUafUtSwOyMAvjraW)
					{
					default:
						return false;
					case 0:
						GQRbfRHkUdzKUafUtSwOyMAvjraW = -1;
						if (ReInput._id != xDSOKWEaAXpEQVxHvGuVyoVBZILL.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(xDSOKWEaAXpEQVxHvGuVyoVBZILL.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						if (vLNaLxHffkgugYOuYjRHrXgRoMkJ == null)
						{
							return false;
						}
						zFWECEXmtKtwUlwApflfxYdKBdXf = ((ControllerMap)xDSOKWEaAXpEQVxHvGuVyoVBZILL).ElementAssignmentConflicts(vLNaLxHffkgugYOuYjRHrXgRoMkJ, CvmypnNoUygbTpdEhGXocfvWnaHC).GetEnumerator();
						GQRbfRHkUdzKUafUtSwOyMAvjraW = -3;
						goto IL_00ad;
					case 1:
						GQRbfRHkUdzKUafUtSwOyMAvjraW = -3;
						goto IL_00ad;
					case 2:
						{
							GQRbfRHkUdzKUafUtSwOyMAvjraW = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (zFWECEXmtKtwUlwApflfxYdKBdXf.MoveNext())
						{
							ElementAssignmentConflictInfo current = zFWECEXmtKtwUlwApflfxYdKBdXf.Current;
							yJwleBEcSsAoNfrCYPmzuyAAARZK = current;
							GQRbfRHkUdzKUafUtSwOyMAvjraW = 1;
							return true;
						}
						rTtVKmURSOuqToZJpqFZkAyrXwvF();
						zFWECEXmtKtwUlwApflfxYdKBdXf = null;
						if (CvmypnNoUygbTpdEhGXocfvWnaHC && (!xDSOKWEaAXpEQVxHvGuVyoVBZILL._enabled || !vLNaLxHffkgugYOuYjRHrXgRoMkJ.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
						{
							return false;
						}
						if (xDSOKWEaAXpEQVxHvGuVyoVBZILL.AsASIPXswErewsBzAgFtlBFLeHGGA == null)
						{
							return false;
						}
						CDglLTidYDGTchPNjBKKIHWmJFMYA = 0;
						goto IL_01bb;
						IL_01bb:
						if (CDglLTidYDGTchPNjBKKIHWmJFMYA < xDSOKWEaAXpEQVxHvGuVyoVBZILL.AsASIPXswErewsBzAgFtlBFLeHGGA.Count)
						{
							ActionElementMap actionElementMap = xDSOKWEaAXpEQVxHvGuVyoVBZILL.AsASIPXswErewsBzAgFtlBFLeHGGA[CDglLTidYDGTchPNjBKKIHWmJFMYA];
							if ((!CvmypnNoUygbTpdEhGXocfvWnaHC || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(vLNaLxHffkgugYOuYjRHrXgRoMkJ))
							{
								yJwleBEcSsAoNfrCYPmzuyAAARZK = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(xDSOKWEaAXpEQVxHvGuVyoVBZILL._categoryId).userAssignable, -1, xDSOKWEaAXpEQVxHvGuVyoVBZILL._controllerType, xDSOKWEaAXpEQVxHvGuVyoVBZILL._controllerId, xDSOKWEaAXpEQVxHvGuVyoVBZILL._id, actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								GQRbfRHkUdzKUafUtSwOyMAvjraW = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						CDglLTidYDGTchPNjBKKIHWmJFMYA++;
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

			private void rTtVKmURSOuqToZJpqFZkAyrXwvF()
			{
				GQRbfRHkUdzKUafUtSwOyMAvjraW = -1;
				if (zFWECEXmtKtwUlwApflfxYdKBdXf != null)
				{
					zFWECEXmtKtwUlwApflfxYdKBdXf.Dispose();
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
				jKvbCwiimwGbfRDSQmJpiApjSKV jKvbCwiimwGbfRDSQmJpiApjSKV2;
				if (GQRbfRHkUdzKUafUtSwOyMAvjraW == -2 && xfssjbWNJvGqfTlUNSpHxWFbRhPm == Environment.CurrentManagedThreadId)
				{
					GQRbfRHkUdzKUafUtSwOyMAvjraW = 0;
					jKvbCwiimwGbfRDSQmJpiApjSKV2 = this;
				}
				else
				{
					jKvbCwiimwGbfRDSQmJpiApjSKV2 = new jKvbCwiimwGbfRDSQmJpiApjSKV(0);
					jKvbCwiimwGbfRDSQmJpiApjSKV2.XDSOKWEaAXpEQVxHvGuVyoVBZILL = XDSOKWEaAXpEQVxHvGuVyoVBZILL;
				}
				jKvbCwiimwGbfRDSQmJpiApjSKV2.vLNaLxHffkgugYOuYjRHrXgRoMkJ = DgNDsKKthfhlFtftPQdUgrmHWvnAA;
				jKvbCwiimwGbfRDSQmJpiApjSKV2.CvmypnNoUygbTpdEhGXocfvWnaHC = GevvKzoyVplZwZToLFWevXOFVYlD;
				return jKvbCwiimwGbfRDSQmJpiApjSKV2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class JjlcnUKYZHpEPZArmqTuByJHyIFk : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int JvHcLTblZctreDfitQxrlblgnrgw;

			private ElementAssignmentConflictInfo AxeCmdXgWQiQUgOXSxhujJdrqzcs;

			private int HLwKzTXTCIwcZywylRVeZRBHdvSM;

			public ControllerMapWithAxes aSXvQgcBtOdwUaOcKJVDjXHJbqUtA;

			private ElementAssignmentConflictCheck CsZzUZDtNBAOSbMbqHqiDAQLKwuF;

			public ElementAssignmentConflictCheck QHYAdloygfvVyNOPEwMgAXRFimCA;

			private bool cYvflClwzhdGeFgUfIYpXszoXcIB;

			public bool evLPbkzWJZgJejNNBoPASLTIZGSp;

			private ElementAssignment OYqxPtTzcLobpzkjPljCssRuNmdS;

			private IEnumerator<ElementAssignmentConflictInfo> SHgetmrGbhQuRhsdNTgruoaCCWpdA;

			private int WKJlqLRckICgMthundtnOKYKEBGF;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return AxeCmdXgWQiQUgOXSxhujJdrqzcs;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return AxeCmdXgWQiQUgOXSxhujJdrqzcs;
				}
			}

			[DebuggerHidden]
			public JjlcnUKYZHpEPZArmqTuByJHyIFk(int P_0)
			{
				JvHcLTblZctreDfitQxrlblgnrgw = P_0;
				HLwKzTXTCIwcZywylRVeZRBHdvSM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int jvHcLTblZctreDfitQxrlblgnrgw = JvHcLTblZctreDfitQxrlblgnrgw;
				if (jvHcLTblZctreDfitQxrlblgnrgw == -3 || jvHcLTblZctreDfitQxrlblgnrgw == 1)
				{
					try
					{
					}
					finally
					{
						VHfgDonxVAYvsqwqqlJGlLoaihQiA();
					}
				}
				SHgetmrGbhQuRhsdNTgruoaCCWpdA = null;
				JvHcLTblZctreDfitQxrlblgnrgw = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int jvHcLTblZctreDfitQxrlblgnrgw = JvHcLTblZctreDfitQxrlblgnrgw;
					ControllerMapWithAxes controllerMapWithAxes = aSXvQgcBtOdwUaOcKJVDjXHJbqUtA;
					switch (jvHcLTblZctreDfitQxrlblgnrgw)
					{
					default:
						return false;
					case 0:
						JvHcLTblZctreDfitQxrlblgnrgw = -1;
						if (ReInput._id != controllerMapWithAxes.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						SHgetmrGbhQuRhsdNTgruoaCCWpdA = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(CsZzUZDtNBAOSbMbqHqiDAQLKwuF, cYvflClwzhdGeFgUfIYpXszoXcIB).GetEnumerator();
						JvHcLTblZctreDfitQxrlblgnrgw = -3;
						goto IL_009e;
					case 1:
						JvHcLTblZctreDfitQxrlblgnrgw = -3;
						goto IL_009e;
					case 2:
						{
							JvHcLTblZctreDfitQxrlblgnrgw = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (WKJlqLRckICgMthundtnOKYKEBGF < controllerMapWithAxes.AsASIPXswErewsBzAgFtlBFLeHGGA.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.AsASIPXswErewsBzAgFtlBFLeHGGA[WKJlqLRckICgMthundtnOKYKEBGF];
							if ((!cYvflClwzhdGeFgUfIYpXszoXcIB || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != CsZzUZDtNBAOSbMbqHqiDAQLKwuF.elementMapId && actionElementMap.CheckForAssignmentConflict(OYqxPtTzcLobpzkjPljCssRuNmdS))
							{
								AxeCmdXgWQiQUgOXSxhujJdrqzcs = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								JvHcLTblZctreDfitQxrlblgnrgw = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (SHgetmrGbhQuRhsdNTgruoaCCWpdA.MoveNext())
						{
							ElementAssignmentConflictInfo current = SHgetmrGbhQuRhsdNTgruoaCCWpdA.Current;
							AxeCmdXgWQiQUgOXSxhujJdrqzcs = current;
							JvHcLTblZctreDfitQxrlblgnrgw = 1;
							return true;
						}
						VHfgDonxVAYvsqwqqlJGlLoaihQiA();
						SHgetmrGbhQuRhsdNTgruoaCCWpdA = null;
						if (cYvflClwzhdGeFgUfIYpXszoXcIB && !controllerMapWithAxes._enabled)
						{
							return false;
						}
						if (controllerMapWithAxes.AsASIPXswErewsBzAgFtlBFLeHGGA == null)
						{
							return false;
						}
						OYqxPtTzcLobpzkjPljCssRuNmdS = CsZzUZDtNBAOSbMbqHqiDAQLKwuF.ToElementAssignment();
						WKJlqLRckICgMthundtnOKYKEBGF = 0;
						goto IL_01c7;
						IL_01b5:
						WKJlqLRckICgMthundtnOKYKEBGF++;
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

			private void VHfgDonxVAYvsqwqqlJGlLoaihQiA()
			{
				JvHcLTblZctreDfitQxrlblgnrgw = -1;
				if (SHgetmrGbhQuRhsdNTgruoaCCWpdA != null)
				{
					SHgetmrGbhQuRhsdNTgruoaCCWpdA.Dispose();
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
				JjlcnUKYZHpEPZArmqTuByJHyIFk jjlcnUKYZHpEPZArmqTuByJHyIFk;
				if (JvHcLTblZctreDfitQxrlblgnrgw == -2 && HLwKzTXTCIwcZywylRVeZRBHdvSM == Environment.CurrentManagedThreadId)
				{
					JvHcLTblZctreDfitQxrlblgnrgw = 0;
					jjlcnUKYZHpEPZArmqTuByJHyIFk = this;
				}
				else
				{
					jjlcnUKYZHpEPZArmqTuByJHyIFk = new JjlcnUKYZHpEPZArmqTuByJHyIFk(0);
					jjlcnUKYZHpEPZArmqTuByJHyIFk.aSXvQgcBtOdwUaOcKJVDjXHJbqUtA = aSXvQgcBtOdwUaOcKJVDjXHJbqUtA;
				}
				jjlcnUKYZHpEPZArmqTuByJHyIFk.CsZzUZDtNBAOSbMbqHqiDAQLKwuF = QHYAdloygfvVyNOPEwMgAXRFimCA;
				jjlcnUKYZHpEPZArmqTuByJHyIFk.cYvflClwzhdGeFgUfIYpXszoXcIB = evLPbkzWJZgJejNNBoPASLTIZGSp;
				return jjlcnUKYZHpEPZArmqTuByJHyIFk;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> AsASIPXswErewsBzAgFtlBFLeHGGA;

		private readonly ReadOnlyCollection<ActionElementMap> cYKyybdJXjdugQGTLNOZRKlJHltb;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return 0;
				}
				if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
				{
					return 0;
				}
				return AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return cYKyybdJXjdugQGTLNOZRKlJHltb;
			}
		}

		internal AList<ActionElementMap> muRswczhYozagKzkUJyzqdvmqubg => (AList<ActionElementMap>)AsASIPXswErewsBzAgFtlBFLeHGGA;

		public ControllerMapWithAxes()
		{
			AsASIPXswErewsBzAgFtlBFLeHGGA = new AList<ActionElementMap>();
			cYKyybdJXjdugQGTLNOZRKlJHltb = new ReadOnlyCollection<ActionElementMap>(AsASIPXswErewsBzAgFtlBFLeHGGA);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			AsASIPXswErewsBzAgFtlBFLeHGGA = new AList<ActionElementMap>();
			cYKyybdJXjdugQGTLNOZRKlJHltb = new ReadOnlyCollection<ActionElementMap>(AsASIPXswErewsBzAgFtlBFLeHGGA);
			ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
			if (P_0.AsASIPXswErewsBzAgFtlBFLeHGGA != null)
			{
				int count = P_0.AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
				for (int i = 0; i < count; i++)
				{
					MVqJnjjQNgEjOKxVrUfflcBOOMph(new ActionElementMap(P_0.AsASIPXswErewsBzAgFtlBFLeHGGA[i]));
				}
			}
			ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return false;
			}
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (AsASIPXswErewsBzAgFtlBFLeHGGA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			MVqJnjjQNgEjOKxVrUfflcBOOMph(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Axis;
				MVqJnjjQNgEjOKxVrUfflcBOOMph(elementMap);
			}
			if (BcCgaPMimyFTFrZWBCHKXOMSixGD(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.IDJjaUCBNnGXUSVrFFTHXssIHzsaA(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			DEraIyQiBlsRSAaUjxRenWgmpJJT();
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = BcCgaPMimyFTFrZWBCHKXOMSixGD(elementMapId);
			if (num < 0)
			{
				return false;
			}
			aPWFPKKStTImANDIptFDhymmkbVOA(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return null;
			}
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (AsASIPXswErewsBzAgFtlBFLeHGGA[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == elementMapId)
				{
					return AsASIPXswErewsBzAgFtlBFLeHGGA[i];
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap VYupzKBnNLsKQdYDtdIWRLwtsIcf(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.sEEZASgeCTfEHdNKZIwJegYcGniSB(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return dQmlhpjplFWsiOCDTeKsXxsguIAK(P_0, P_1);
		}

		internal virtual int UuGePmfgdLJLZgRMPTZrqZDKrMYFA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.aTzfofhvprNRBsUCiwcGsmftAHteA(P_0, P_1, P_2, P_3) + mIHxxkBYppPaxLsyrFtWtgFXLlvW(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return;
			}
			base.ClearElementMaps();
			AsASIPXswErewsBzAgFtlBFLeHGGA.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null || index < 0 || index >= AsASIPXswErewsBzAgFtlBFLeHGGA.Count)
			{
				return null;
			}
			return AsASIPXswErewsBzAgFtlBFLeHGGA[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(AsASIPXswErewsBzAgFtlBFLeHGGA);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return jFvPfdIuclmJtdbZeIIWIDtevlgO(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.MaBqBGMglwlFblDVqevucOFjoimZA(actionName, true);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.MaBqBGMglwlFblDVqevucOFjoimZA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
				ActionElementMap actionElementMap2 = AsASIPXswErewsBzAgFtlBFLeHGGA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			InputAction inputAction = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.MaBqBGMglwlFblDVqevucOFjoimZA(actionName, true);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			InputAction inputAction = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.MaBqBGMglwlFblDVqevucOFjoimZA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return ONZxNRLiOvYiNvpMrcVcERUuJXkc(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(kDOiIfASNmArXLYBwfkYrjrehWOq))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new kDOiIfASNmArXLYBwfkYrjrehWOq(-2)
			{
				xrviHfqaAjXlfLESIOZQrtGckudL = this,
				rmXDQScjgalVvmnXcmKENVnKicWeA = actionId,
				hfplGaOdmngtLHxJXfOriBceNqMv = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			return dQmlhpjplFWsiOCDTeKsXxsguIAK(predicate, false);
		}

		internal ActionElementMap dQmlhpjplFWsiOCDTeKsXxsguIAK(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return mIHxxkBYppPaxLsyrFtWtgFXLlvW(predicate, false, results, false);
		}

		internal int mIHxxkBYppPaxLsyrFtWtgFXLlvW(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
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
			return DeleteAxisMapsWithAction(ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (AsASIPXswErewsBzAgFtlBFLeHGGA[num2] != null && AsASIPXswErewsBzAgFtlBFLeHGGA[num2]._actionId == actionId)
				{
					aPWFPKKStTImANDIptFDhymmkbVOA(AsASIPXswErewsBzAgFtlBFLeHGGA[num2].gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int num = 0;
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb != state)
				{
					actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (skipDisabledMaps && !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
			{
				return false;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return false;
			}
			for (int i = 0; i < AsASIPXswErewsBzAgFtlBFLeHGGA.Count; i++)
			{
				ActionElementMap actionElementMap2 = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < AsASIPXswErewsBzAgFtlBFLeHGGA.Count; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if ((!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(aGTKideRUtDNEZFmtrbEhkDvcXnGA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new aGTKideRUtDNEZFmtrbEhkDvcXnGA(-2)
			{
				gsDENorKfANOroDwbloNFmUJbFMdA = this,
				vEtrMBCeUiHsezjbcgGgiyAMHhZJA = controllerMap,
				LdjPPHqjuZcMjsYUExDTKsGXJQvc = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(jKvbCwiimwGbfRDSQmJpiApjSKV))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new jKvbCwiimwGbfRDSQmJpiApjSKV(-2)
			{
				XDSOKWEaAXpEQVxHvGuVyoVBZILL = this,
				DgNDsKKthfhlFtftPQdUgrmHWvnAA = actionElementMap,
				GevvKzoyVplZwZToLFWevXOFVYlD = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(JjlcnUKYZHpEPZArmqTuByJHyIFk))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new JjlcnUKYZHpEPZArmqTuByJHyIFk(-2)
			{
				aSXvQgcBtOdwUaOcKJVDjXHJbqUtA = this,
				QHYAdloygfvVyNOPEwMgAXRFimCA = conflictCheck,
				evLPbkzWJZgJejNNBoPASLTIZGSp = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
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
			_ = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			int count = axisMaps.Count;
			for (int num2 = AsASIPXswErewsBzAgFtlBFLeHGGA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[num2];
				if (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							aPWFPKKStTImANDIptFDhymmkbVOA(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return num;
			}
			for (int num2 = AsASIPXswErewsBzAgFtlBFLeHGGA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = AsASIPXswErewsBzAgFtlBFLeHGGA[num2];
				if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					aPWFPKKStTImANDIptFDhymmkbVOA(actionElementMap2.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
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
			for (int num2 = AsASIPXswErewsBzAgFtlBFLeHGGA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[num2];
				if ((!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					aPWFPKKStTImANDIptFDhymmkbVOA(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int MNHrsTiAbImNoyYFuvzEhBZxkCbM(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.zeztsRkmbKBGcHGbkLmxixfnHyMA(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
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
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (!actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int waHImegrQtdVtPZZFEBqtnWTEzobb(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.xARvIziAnsCgxrFCUVjIgaMtFsaHA(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int ZCdbKoDEEvgWGbVeyOekpMEeRQujA(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.RijTjPgqOiHkBmeJciVrzMTgrgKF(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
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
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				array[i] = AsASIPXswErewsBzAgFtlBFLeHGGA[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool qZyvhTfXeNGxiCPVbdyoEjunJYnc(ActionElementMap P_0)
		{
			if (base.LqBWpTNVWgCahBpYNHcxDtZTDUKt(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(elementType))
			{
				return false;
			}
			MVqJnjjQNgEjOKxVrUfflcBOOMph(P_0);
			return true;
		}

		internal virtual int KgwfqfdGrlnfcODTqmeoseMhUovbA(List<ActionElementMap> P_0, bool P_1)
		{
			base.jLiOCZmkHIDRyrrIzWdIIlgyZKXm(P_0, P_1);
			int count = P_0.Count;
			int count2 = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || AsASIPXswErewsBzAgFtlBFLeHGGA[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					P_0.Add(AsASIPXswErewsBzAgFtlBFLeHGGA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap uEsFwBBKecPLPDiomedVQoIrfURP(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.WUEgoskwDJPRgXjNyRzamrFiRkqs(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(P_2))
			{
				return null;
			}
			int num = aAMiwmpEmdzmmAPnWDlzmhPNViXf(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return AsASIPXswErewsBzAgFtlBFLeHGGA[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int aUCxTGvcOVhVBjdHkrnCRZVdXQiH(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.xhndsUmEMIbUZqInGbwJJVaGZCvX(P_0, P_1, P_2);
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return P_1.Count - num;
			}
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (AsASIPXswErewsBzAgFtlBFLeHGGA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(AsASIPXswErewsBzAgFtlBFLeHGGA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool uvnzVAHFfocYbgxsUkKYvNaUbBCE(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.cdhaxGXtpPjMZObHwdOTnzVMDJkC(P_0, P_1, P_2))
			{
				return true;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
				for (int i = 0; i < count; i++)
				{
					if (AsASIPXswErewsBzAgFtlBFLeHGGA[i]._elementIdentifierId == P_0 && AsASIPXswErewsBzAgFtlBFLeHGGA[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int mZvJDXkyxIrhPRhfGyyvtXKqMFaG(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.aAMiwmpEmdzmmAPnWDlzmhPNViXf(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(P_2))
			{
				return -1;
			}
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
				for (int i = 0; i < count; i++)
				{
					if (AsASIPXswErewsBzAgFtlBFLeHGGA[i]._elementIdentifierId == P_0 && AsASIPXswErewsBzAgFtlBFLeHGGA[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int BcCgaPMimyFTFrZWBCHKXOMSixGD(int P_0)
		{
			if (AsASIPXswErewsBzAgFtlBFLeHGGA == null)
			{
				return -1;
			}
			int count = AsASIPXswErewsBzAgFtlBFLeHGGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (AsASIPXswErewsBzAgFtlBFLeHGGA[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int jFvPfdIuclmJtdbZeIIWIDtevlgO(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (!P_0 || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int ONZxNRLiOvYiNvpMrcVcERUuJXkc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int XllYoJaMVMrlTDOhFtbbbobnnGOL(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.LPMKAKNrPSmdGMWdQtQBGKFQKxwb(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap cxGEwnGMHyTNWTYjTTbdkDtkqYEs(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.KArrUOdDybdkCKycWMMqbUtKVtfsA(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || AsASIPXswErewsBzAgFtlBFLeHGGA[i]._actionId == P_2) && (!P_3 || AsASIPXswErewsBzAgFtlBFLeHGGA[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && AsASIPXswErewsBzAgFtlBFLeHGGA[i].IsTarget(P_0))
				{
					return AsASIPXswErewsBzAgFtlBFLeHGGA[i];
				}
			}
			return null;
		}

		internal virtual int mtHQoaggXPBWUcUccgNbCpuSiWWuA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.xVXvATEIJOyARtowfnOzbVGdtuAe(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || AsASIPXswErewsBzAgFtlBFLeHGGA[i]._actionId == P_2) && (!P_3 || AsASIPXswErewsBzAgFtlBFLeHGGA[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && AsASIPXswErewsBzAgFtlBFLeHGGA[i].IsTarget(P_0))
				{
					P_4.Add(AsASIPXswErewsBzAgFtlBFLeHGGA[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool bhnacdhxzCxGfBykjQqBaHhsswGX(ActionElementMap P_0)
		{
			if (base.GPdkcFUsjoTOrNAJlHqqwoEMaYBR(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!LKENDUZPokzfSWVIYFxZnQdPJJvH(P_0._elementType))
			{
				return false;
			}
			AsASIPXswErewsBzAgFtlBFLeHGGA.Add(P_0);
			WEOFbWYubWBUzHTzVhrcAwdLmeydA(P_0);
			return true;
		}

		private bool LKENDUZPokzfSWVIYFxZnQdPJJvH(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void aPWFPKKStTImANDIptFDhymmkbVOA(int P_0, int P_1)
		{
			CUlJDIMfaiGkqhgipiTqWlDEKbSC(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				AsASIPXswErewsBzAgFtlBFLeHGGA.RemoveAt(P_1);
			}
		}

		private void MVqJnjjQNgEjOKxVrUfflcBOOMph(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				AsASIPXswErewsBzAgFtlBFLeHGGA.Add(P_0);
				WEOFbWYubWBUzHTzVhrcAwdLmeydA(P_0);
			}
		}

		private void KKFBNuCSmNXWpxXWaGRmwLXCfmrq(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				kWWKsaFzfxhjruhxYEbWimOfkCnRA(AsASIPXswErewsBzAgFtlBFLeHGGA[P_1].gjHUlVyQSQsjZEOHtHfmeehEQpiIA, P_0);
				AsASIPXswErewsBzAgFtlBFLeHGGA[P_1] = P_0;
			}
		}

		internal virtual void HPEBoYGhctKSPxJFSThDIsAKcgmx(SerializedObject P_0)
		{
			base.wYUtAyzJWerCAyBPvoWTKhOuCwNg(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (AsASIPXswErewsBzAgFtlBFLeHGGA[i] != null)
				{
					list.Add(AsASIPXswErewsBzAgFtlBFLeHGGA[i].mPXookHxaeOSKUADmcsOiVKFOQqi());
				}
			}
		}

		internal virtual bool TJWksjhMAmzRtoZedliMmcFIghQG(SerializedObject P_0)
		{
			bool flag = base.LmTqdyqGkCajsHdLEdEZdPWfUzJl(P_0);
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
						actionElementMap.qbSInOBzRpLbKGdknAatzCqAWxtMA(value2);
						if (ActionElementMap.aODDhkZGfEYPsGiSODPHcMQUMixpA(actionElementMap))
						{
							MVqJnjjQNgEjOKxVrUfflcBOOMph(actionElementMap);
						}
					}
				}
			}
			DEraIyQiBlsRSAaUjxRenWgmpJJT();
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> eWArHzbBlTIYkzqxcLDSKfiTjaQs(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> DbZEONYHxmZhuShnSmHMWLFJxpEp(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> ZEQOmWZLKGiVLongXPSTJtLTyIWF(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
