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
		private sealed class aCKiYoCmtquntmarlYdnpibFfPMab : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int IwQenpxoJPJajFbkDQONbiePqdLp;

			private ActionElementMap fxAGGZeomwLcelArmpABHIUJvTtl;

			private int ewYNEwjttBDMsTYciGdtMMEBlewy;

			public ControllerMapWithAxes lPhAZyhIcjitLLgmVoWfbaAFUzfNA;

			private int QueaWnjMrKdoxcybfAqdUrFGMbwM;

			public int hnPIQJVpYgbJVMZblEFbYDthtdGT;

			private bool qqPRwduUbHQFuyunGAAMCNcrDZwh;

			public bool pAtpEdmYLvnlrqptIVsCpoGVrMAC;

			private IEnumerator<ActionElementMap> URfzBbrHKZFGjOdKCcNLgEDejWSxA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return fxAGGZeomwLcelArmpABHIUJvTtl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return fxAGGZeomwLcelArmpABHIUJvTtl;
				}
			}

			[DebuggerHidden]
			public aCKiYoCmtquntmarlYdnpibFfPMab(int P_0)
			{
				IwQenpxoJPJajFbkDQONbiePqdLp = P_0;
				ewYNEwjttBDMsTYciGdtMMEBlewy = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int iwQenpxoJPJajFbkDQONbiePqdLp = IwQenpxoJPJajFbkDQONbiePqdLp;
				if (iwQenpxoJPJajFbkDQONbiePqdLp == -3 || iwQenpxoJPJajFbkDQONbiePqdLp == 1)
				{
					try
					{
					}
					finally
					{
						iDKeQKFOHZqjFxARKWvVDaBeTYCDA();
					}
				}
				URfzBbrHKZFGjOdKCcNLgEDejWSxA = null;
				IwQenpxoJPJajFbkDQONbiePqdLp = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int iwQenpxoJPJajFbkDQONbiePqdLp = IwQenpxoJPJajFbkDQONbiePqdLp;
					ControllerMapWithAxes controllerMapWithAxes = lPhAZyhIcjitLLgmVoWfbaAFUzfNA;
					switch (iwQenpxoJPJajFbkDQONbiePqdLp)
					{
					default:
						return false;
					case 0:
						IwQenpxoJPJajFbkDQONbiePqdLp = -1;
						if (ReInput._id != controllerMapWithAxes.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						if (QueaWnjMrKdoxcybfAqdUrFGMbwM < 0)
						{
							return false;
						}
						URfzBbrHKZFGjOdKCcNLgEDejWSxA = controllerMapWithAxes.AxisMaps.GetEnumerator();
						IwQenpxoJPJajFbkDQONbiePqdLp = -3;
						break;
					case 1:
						IwQenpxoJPJajFbkDQONbiePqdLp = -3;
						break;
					}
					while (URfzBbrHKZFGjOdKCcNLgEDejWSxA.MoveNext())
					{
						ActionElementMap current = URfzBbrHKZFGjOdKCcNLgEDejWSxA.Current;
						if (current._actionId == QueaWnjMrKdoxcybfAqdUrFGMbwM && (!qqPRwduUbHQFuyunGAAMCNcrDZwh || current.fpFEHHilwCsNTxvZcaeleakbBkQCb))
						{
							fxAGGZeomwLcelArmpABHIUJvTtl = current;
							IwQenpxoJPJajFbkDQONbiePqdLp = 1;
							return true;
						}
					}
					iDKeQKFOHZqjFxARKWvVDaBeTYCDA();
					URfzBbrHKZFGjOdKCcNLgEDejWSxA = null;
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

			private void iDKeQKFOHZqjFxARKWvVDaBeTYCDA()
			{
				IwQenpxoJPJajFbkDQONbiePqdLp = -1;
				if (URfzBbrHKZFGjOdKCcNLgEDejWSxA != null)
				{
					URfzBbrHKZFGjOdKCcNLgEDejWSxA.Dispose();
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
				aCKiYoCmtquntmarlYdnpibFfPMab aCKiYoCmtquntmarlYdnpibFfPMab2;
				if (IwQenpxoJPJajFbkDQONbiePqdLp == -2 && ewYNEwjttBDMsTYciGdtMMEBlewy == Environment.CurrentManagedThreadId)
				{
					IwQenpxoJPJajFbkDQONbiePqdLp = 0;
					aCKiYoCmtquntmarlYdnpibFfPMab2 = this;
				}
				else
				{
					aCKiYoCmtquntmarlYdnpibFfPMab2 = new aCKiYoCmtquntmarlYdnpibFfPMab(0);
					aCKiYoCmtquntmarlYdnpibFfPMab2.lPhAZyhIcjitLLgmVoWfbaAFUzfNA = lPhAZyhIcjitLLgmVoWfbaAFUzfNA;
				}
				aCKiYoCmtquntmarlYdnpibFfPMab2.QueaWnjMrKdoxcybfAqdUrFGMbwM = hnPIQJVpYgbJVMZblEFbYDthtdGT;
				aCKiYoCmtquntmarlYdnpibFfPMab2.qqPRwduUbHQFuyunGAAMCNcrDZwh = pAtpEdmYLvnlrqptIVsCpoGVrMAC;
				return aCKiYoCmtquntmarlYdnpibFfPMab2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class qmHAyuCQuvARkluCmpkdRaBCMYniA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ipzBYrdlnYCxIDVzjkuTRiWJtCuWA;

			private ElementAssignmentConflictInfo JGVebBjuSQdhHHbUDvRmfdffIxGr;

			private int hrOxRjipHNzRaosDDCHhhCiDFaxd;

			public ControllerMapWithAxes uyZeTxjDZQmQJPUWsyhqAyMipEWp;

			private ControllerMap MTvElGkKrqmvRIASxRTRhZNyYDIj;

			public ControllerMap dArnKRwchiqEQGLOhDxFjCovmdBd;

			private bool umolOwnAczGhmtthxpkeAmazWvtw;

			public bool VahFdWQcXJgaNXMuLdaoAXsmPYILA;

			private IList<ActionElementMap> rbyRHdRHCWgsZckQdmrLXSBzFDcV;

			private int aYYBTdzfOFSkXrnsAUfecopJBCwT;

			private IEnumerator<ElementAssignmentConflictInfo> oYypqkPAHPoHJRHfBYsrwZsaxOrI;

			private int LShBniedyfogNenWuCOIADFByCLYb;

			private ActionElementMap RdbZJAOnmBazkKeHerlaEjXCQnWA;

			private int hSoHfvWOTaXvnoTurEuaiQjXaZKZ;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JGVebBjuSQdhHHbUDvRmfdffIxGr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JGVebBjuSQdhHHbUDvRmfdffIxGr;
				}
			}

			[DebuggerHidden]
			public qmHAyuCQuvARkluCmpkdRaBCMYniA(int P_0)
			{
				ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = P_0;
				hrOxRjipHNzRaosDDCHhhCiDFaxd = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = ipzBYrdlnYCxIDVzjkuTRiWJtCuWA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						hgpNffHqekIfYEBSxZKoiXEPtiLjA();
					}
				}
				rbyRHdRHCWgsZckQdmrLXSBzFDcV = null;
				oYypqkPAHPoHJRHfBYsrwZsaxOrI = null;
				RdbZJAOnmBazkKeHerlaEjXCQnWA = null;
				ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = ipzBYrdlnYCxIDVzjkuTRiWJtCuWA;
					ControllerMapWithAxes controllerMapWithAxes = uyZeTxjDZQmQJPUWsyhqAyMipEWp;
					switch (num)
					{
					default:
						return false;
					case 0:
						ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = -1;
						if (ReInput._id != controllerMapWithAxes.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						if (MTvElGkKrqmvRIASxRTRhZNyYDIj == null)
						{
							return false;
						}
						oYypqkPAHPoHJRHfBYsrwZsaxOrI = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(MTvElGkKrqmvRIASxRTRhZNyYDIj, umolOwnAczGhmtthxpkeAmazWvtw).GetEnumerator();
						ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = -3;
						goto IL_00af;
					case 1:
						ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = -3;
						goto IL_00af;
					case 2:
						{
							ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = -1;
							goto IL_0232;
						}
						IL_0244:
						if (hSoHfvWOTaXvnoTurEuaiQjXaZKZ < aYYBTdzfOFSkXrnsAUfecopJBCwT)
						{
							ActionElementMap actionElementMap = rbyRHdRHCWgsZckQdmrLXSBzFDcV[hSoHfvWOTaXvnoTurEuaiQjXaZKZ];
							if ((!umolOwnAczGhmtthxpkeAmazWvtw || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && RdbZJAOnmBazkKeHerlaEjXCQnWA.CheckForAssignmentConflict(actionElementMap))
							{
								JGVebBjuSQdhHHbUDvRmfdffIxGr = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, RdbZJAOnmBazkKeHerlaEjXCQnWA.oETQtUYpoAHvrDdxockLYpfjFkywA, RdbZJAOnmBazkKeHerlaEjXCQnWA._actionId, RdbZJAOnmBazkKeHerlaEjXCQnWA._elementType, RdbZJAOnmBazkKeHerlaEjXCQnWA._elementIdentifierId, RdbZJAOnmBazkKeHerlaEjXCQnWA.keyCode, RdbZJAOnmBazkKeHerlaEjXCQnWA.modifierKeyFlags);
								ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = 2;
								return true;
							}
							goto IL_0232;
						}
						RdbZJAOnmBazkKeHerlaEjXCQnWA = null;
						goto IL_025c;
						IL_0232:
						hSoHfvWOTaXvnoTurEuaiQjXaZKZ++;
						goto IL_0244;
						IL_026e:
						if (LShBniedyfogNenWuCOIADFByCLYb < controllerMapWithAxes.OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count)
						{
							RdbZJAOnmBazkKeHerlaEjXCQnWA = controllerMapWithAxes.OnIQqWtWuWbTYNHMFKsIsROmAWIE[LShBniedyfogNenWuCOIADFByCLYb];
							if (!umolOwnAczGhmtthxpkeAmazWvtw || RdbZJAOnmBazkKeHerlaEjXCQnWA.fpFEHHilwCsNTxvZcaeleakbBkQCb)
							{
								hSoHfvWOTaXvnoTurEuaiQjXaZKZ = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (oYypqkPAHPoHJRHfBYsrwZsaxOrI.MoveNext())
						{
							ElementAssignmentConflictInfo current = oYypqkPAHPoHJRHfBYsrwZsaxOrI.Current;
							JGVebBjuSQdhHHbUDvRmfdffIxGr = current;
							ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = 1;
							return true;
						}
						hgpNffHqekIfYEBSxZKoiXEPtiLjA();
						oYypqkPAHPoHJRHfBYsrwZsaxOrI = null;
						if (!(MTvElGkKrqmvRIASxRTRhZNyYDIj is ControllerMapWithAxes controllerMapWithAxes2))
						{
							return false;
						}
						if (umolOwnAczGhmtthxpkeAmazWvtw && (!controllerMapWithAxes._enabled || !controllerMapWithAxes2._enabled))
						{
							return false;
						}
						rbyRHdRHCWgsZckQdmrLXSBzFDcV = controllerMapWithAxes2.AxisMaps;
						if (rbyRHdRHCWgsZckQdmrLXSBzFDcV == null)
						{
							return false;
						}
						aYYBTdzfOFSkXrnsAUfecopJBCwT = rbyRHdRHCWgsZckQdmrLXSBzFDcV.Count;
						LShBniedyfogNenWuCOIADFByCLYb = 0;
						goto IL_026e;
						IL_025c:
						LShBniedyfogNenWuCOIADFByCLYb++;
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

			private void hgpNffHqekIfYEBSxZKoiXEPtiLjA()
			{
				ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = -1;
				if (oYypqkPAHPoHJRHfBYsrwZsaxOrI != null)
				{
					oYypqkPAHPoHJRHfBYsrwZsaxOrI.Dispose();
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
				qmHAyuCQuvARkluCmpkdRaBCMYniA qmHAyuCQuvARkluCmpkdRaBCMYniA2;
				if (ipzBYrdlnYCxIDVzjkuTRiWJtCuWA == -2 && hrOxRjipHNzRaosDDCHhhCiDFaxd == Environment.CurrentManagedThreadId)
				{
					ipzBYrdlnYCxIDVzjkuTRiWJtCuWA = 0;
					qmHAyuCQuvARkluCmpkdRaBCMYniA2 = this;
				}
				else
				{
					qmHAyuCQuvARkluCmpkdRaBCMYniA2 = new qmHAyuCQuvARkluCmpkdRaBCMYniA(0);
					qmHAyuCQuvARkluCmpkdRaBCMYniA2.uyZeTxjDZQmQJPUWsyhqAyMipEWp = uyZeTxjDZQmQJPUWsyhqAyMipEWp;
				}
				qmHAyuCQuvARkluCmpkdRaBCMYniA2.MTvElGkKrqmvRIASxRTRhZNyYDIj = dArnKRwchiqEQGLOhDxFjCovmdBd;
				qmHAyuCQuvARkluCmpkdRaBCMYniA2.umolOwnAczGhmtthxpkeAmazWvtw = VahFdWQcXJgaNXMuLdaoAXsmPYILA;
				return qmHAyuCQuvARkluCmpkdRaBCMYniA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class pbWCvNCBEgasXJCvLfJmlqEAUPGhA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int CkLrIobyntKgITyMgrdazKnEewGB;

			private ElementAssignmentConflictInfo oNohwUcmayKxrYneBEpMzcEbKRPQ;

			private int xIuyQgwblnSDPswsUNrwkMLKUELK;

			public ControllerMapWithAxes DhQIdZkmiHbHyegdahLaxPRssGHx;

			private ActionElementMap rgJuJyfZVwkLWfMDNsNwiiXifPod;

			public ActionElementMap JaBLmVJqPhurbGdXADotKyusVyzn;

			private bool YtcudcvzAqgVfKmNmHnNjknxshHj;

			public bool SGthdsULMdlnCgelEMpBgMXqYxpf;

			private IEnumerator<ElementAssignmentConflictInfo> pLYSqVlcGGidaYLCcykWaaUbRSJq;

			private int OzybEDCmFJFSOEzoUDdGKKHJEEkb;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return oNohwUcmayKxrYneBEpMzcEbKRPQ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return oNohwUcmayKxrYneBEpMzcEbKRPQ;
				}
			}

			[DebuggerHidden]
			public pbWCvNCBEgasXJCvLfJmlqEAUPGhA(int P_0)
			{
				CkLrIobyntKgITyMgrdazKnEewGB = P_0;
				xIuyQgwblnSDPswsUNrwkMLKUELK = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int ckLrIobyntKgITyMgrdazKnEewGB = CkLrIobyntKgITyMgrdazKnEewGB;
				if (ckLrIobyntKgITyMgrdazKnEewGB == -3 || ckLrIobyntKgITyMgrdazKnEewGB == 1)
				{
					try
					{
					}
					finally
					{
						hZhBKdkEvUCgzRVhqCpchUqQbAhQ();
					}
				}
				pLYSqVlcGGidaYLCcykWaaUbRSJq = null;
				CkLrIobyntKgITyMgrdazKnEewGB = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int ckLrIobyntKgITyMgrdazKnEewGB = CkLrIobyntKgITyMgrdazKnEewGB;
					ControllerMapWithAxes dhQIdZkmiHbHyegdahLaxPRssGHx = DhQIdZkmiHbHyegdahLaxPRssGHx;
					switch (ckLrIobyntKgITyMgrdazKnEewGB)
					{
					default:
						return false;
					case 0:
						CkLrIobyntKgITyMgrdazKnEewGB = -1;
						if (ReInput._id != dhQIdZkmiHbHyegdahLaxPRssGHx.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(dhQIdZkmiHbHyegdahLaxPRssGHx.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						if (rgJuJyfZVwkLWfMDNsNwiiXifPod == null)
						{
							return false;
						}
						pLYSqVlcGGidaYLCcykWaaUbRSJq = ((ControllerMap)dhQIdZkmiHbHyegdahLaxPRssGHx).ElementAssignmentConflicts(rgJuJyfZVwkLWfMDNsNwiiXifPod, YtcudcvzAqgVfKmNmHnNjknxshHj).GetEnumerator();
						CkLrIobyntKgITyMgrdazKnEewGB = -3;
						goto IL_00ad;
					case 1:
						CkLrIobyntKgITyMgrdazKnEewGB = -3;
						goto IL_00ad;
					case 2:
						{
							CkLrIobyntKgITyMgrdazKnEewGB = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (pLYSqVlcGGidaYLCcykWaaUbRSJq.MoveNext())
						{
							ElementAssignmentConflictInfo current = pLYSqVlcGGidaYLCcykWaaUbRSJq.Current;
							oNohwUcmayKxrYneBEpMzcEbKRPQ = current;
							CkLrIobyntKgITyMgrdazKnEewGB = 1;
							return true;
						}
						hZhBKdkEvUCgzRVhqCpchUqQbAhQ();
						pLYSqVlcGGidaYLCcykWaaUbRSJq = null;
						if (YtcudcvzAqgVfKmNmHnNjknxshHj && (!dhQIdZkmiHbHyegdahLaxPRssGHx._enabled || !rgJuJyfZVwkLWfMDNsNwiiXifPod.fpFEHHilwCsNTxvZcaeleakbBkQCb))
						{
							return false;
						}
						if (dhQIdZkmiHbHyegdahLaxPRssGHx.OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
						{
							return false;
						}
						OzybEDCmFJFSOEzoUDdGKKHJEEkb = 0;
						goto IL_01bb;
						IL_01bb:
						if (OzybEDCmFJFSOEzoUDdGKKHJEEkb < dhQIdZkmiHbHyegdahLaxPRssGHx.OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count)
						{
							ActionElementMap actionElementMap = dhQIdZkmiHbHyegdahLaxPRssGHx.OnIQqWtWuWbTYNHMFKsIsROmAWIE[OzybEDCmFJFSOEzoUDdGKKHJEEkb];
							if ((!YtcudcvzAqgVfKmNmHnNjknxshHj || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(rgJuJyfZVwkLWfMDNsNwiiXifPod))
							{
								oNohwUcmayKxrYneBEpMzcEbKRPQ = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(dhQIdZkmiHbHyegdahLaxPRssGHx._categoryId).userAssignable, -1, dhQIdZkmiHbHyegdahLaxPRssGHx._controllerType, dhQIdZkmiHbHyegdahLaxPRssGHx._controllerId, dhQIdZkmiHbHyegdahLaxPRssGHx._id, actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								CkLrIobyntKgITyMgrdazKnEewGB = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						OzybEDCmFJFSOEzoUDdGKKHJEEkb++;
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

			private void hZhBKdkEvUCgzRVhqCpchUqQbAhQ()
			{
				CkLrIobyntKgITyMgrdazKnEewGB = -1;
				if (pLYSqVlcGGidaYLCcykWaaUbRSJq != null)
				{
					pLYSqVlcGGidaYLCcykWaaUbRSJq.Dispose();
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
				pbWCvNCBEgasXJCvLfJmlqEAUPGhA pbWCvNCBEgasXJCvLfJmlqEAUPGhA2;
				if (CkLrIobyntKgITyMgrdazKnEewGB == -2 && xIuyQgwblnSDPswsUNrwkMLKUELK == Environment.CurrentManagedThreadId)
				{
					CkLrIobyntKgITyMgrdazKnEewGB = 0;
					pbWCvNCBEgasXJCvLfJmlqEAUPGhA2 = this;
				}
				else
				{
					pbWCvNCBEgasXJCvLfJmlqEAUPGhA2 = new pbWCvNCBEgasXJCvLfJmlqEAUPGhA(0);
					pbWCvNCBEgasXJCvLfJmlqEAUPGhA2.DhQIdZkmiHbHyegdahLaxPRssGHx = DhQIdZkmiHbHyegdahLaxPRssGHx;
				}
				pbWCvNCBEgasXJCvLfJmlqEAUPGhA2.rgJuJyfZVwkLWfMDNsNwiiXifPod = JaBLmVJqPhurbGdXADotKyusVyzn;
				pbWCvNCBEgasXJCvLfJmlqEAUPGhA2.YtcudcvzAqgVfKmNmHnNjknxshHj = SGthdsULMdlnCgelEMpBgMXqYxpf;
				return pbWCvNCBEgasXJCvLfJmlqEAUPGhA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class JDzyAXehQXnGrsHgzflLMRgavzPe : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int LNBNOiXtAuhGWwSmVuQyexFHoitA;

			private ElementAssignmentConflictInfo ARcAqxvqeCOJaFzrBuDVgpqCumoE;

			private int XkkYfWduuGuczDMUyDADEYVwjqGaA;

			public ControllerMapWithAxes gODnMlQBBYfguBzKTzScOgJusxMV;

			private ElementAssignmentConflictCheck WMPtfWpGlRGByCfXrYqPAgYkbPio;

			public ElementAssignmentConflictCheck IQLQRaFcQsEnpXbkOstrlMJiVjsO;

			private bool wexfIgNaYbhtuwZMqwRfELgVwKgq;

			public bool qSRtfhTWlRDZOWbrIBGfHXVfKFMq;

			private ElementAssignment CaoOTofzABrhTEsJYutjxyPZhUtf;

			private IEnumerator<ElementAssignmentConflictInfo> IGkgjdIZXdxijiMTQplOSfavyZlBA;

			private int CqBdjCnVWIAdiWnScisMNaYzTNKh;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ARcAqxvqeCOJaFzrBuDVgpqCumoE;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ARcAqxvqeCOJaFzrBuDVgpqCumoE;
				}
			}

			[DebuggerHidden]
			public JDzyAXehQXnGrsHgzflLMRgavzPe(int P_0)
			{
				LNBNOiXtAuhGWwSmVuQyexFHoitA = P_0;
				XkkYfWduuGuczDMUyDADEYVwjqGaA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int lNBNOiXtAuhGWwSmVuQyexFHoitA = LNBNOiXtAuhGWwSmVuQyexFHoitA;
				if (lNBNOiXtAuhGWwSmVuQyexFHoitA == -3 || lNBNOiXtAuhGWwSmVuQyexFHoitA == 1)
				{
					try
					{
					}
					finally
					{
						FjdDFrPmzEklQFaMdyMvqvqXSkAU();
					}
				}
				IGkgjdIZXdxijiMTQplOSfavyZlBA = null;
				LNBNOiXtAuhGWwSmVuQyexFHoitA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int lNBNOiXtAuhGWwSmVuQyexFHoitA = LNBNOiXtAuhGWwSmVuQyexFHoitA;
					ControllerMapWithAxes controllerMapWithAxes = gODnMlQBBYfguBzKTzScOgJusxMV;
					switch (lNBNOiXtAuhGWwSmVuQyexFHoitA)
					{
					default:
						return false;
					case 0:
						LNBNOiXtAuhGWwSmVuQyexFHoitA = -1;
						if (ReInput._id != controllerMapWithAxes.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						IGkgjdIZXdxijiMTQplOSfavyZlBA = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(WMPtfWpGlRGByCfXrYqPAgYkbPio, wexfIgNaYbhtuwZMqwRfELgVwKgq).GetEnumerator();
						LNBNOiXtAuhGWwSmVuQyexFHoitA = -3;
						goto IL_009e;
					case 1:
						LNBNOiXtAuhGWwSmVuQyexFHoitA = -3;
						goto IL_009e;
					case 2:
						{
							LNBNOiXtAuhGWwSmVuQyexFHoitA = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (CqBdjCnVWIAdiWnScisMNaYzTNKh < controllerMapWithAxes.OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.OnIQqWtWuWbTYNHMFKsIsROmAWIE[CqBdjCnVWIAdiWnScisMNaYzTNKh];
							if ((!wexfIgNaYbhtuwZMqwRfELgVwKgq || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != WMPtfWpGlRGByCfXrYqPAgYkbPio.elementMapId && actionElementMap.CheckForAssignmentConflict(CaoOTofzABrhTEsJYutjxyPZhUtf))
							{
								ARcAqxvqeCOJaFzrBuDVgpqCumoE = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								LNBNOiXtAuhGWwSmVuQyexFHoitA = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (IGkgjdIZXdxijiMTQplOSfavyZlBA.MoveNext())
						{
							ElementAssignmentConflictInfo current = IGkgjdIZXdxijiMTQplOSfavyZlBA.Current;
							ARcAqxvqeCOJaFzrBuDVgpqCumoE = current;
							LNBNOiXtAuhGWwSmVuQyexFHoitA = 1;
							return true;
						}
						FjdDFrPmzEklQFaMdyMvqvqXSkAU();
						IGkgjdIZXdxijiMTQplOSfavyZlBA = null;
						if (wexfIgNaYbhtuwZMqwRfELgVwKgq && !controllerMapWithAxes._enabled)
						{
							return false;
						}
						if (controllerMapWithAxes.OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
						{
							return false;
						}
						CaoOTofzABrhTEsJYutjxyPZhUtf = WMPtfWpGlRGByCfXrYqPAgYkbPio.ToElementAssignment();
						CqBdjCnVWIAdiWnScisMNaYzTNKh = 0;
						goto IL_01c7;
						IL_01b5:
						CqBdjCnVWIAdiWnScisMNaYzTNKh++;
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

			private void FjdDFrPmzEklQFaMdyMvqvqXSkAU()
			{
				LNBNOiXtAuhGWwSmVuQyexFHoitA = -1;
				if (IGkgjdIZXdxijiMTQplOSfavyZlBA != null)
				{
					IGkgjdIZXdxijiMTQplOSfavyZlBA.Dispose();
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
				JDzyAXehQXnGrsHgzflLMRgavzPe jDzyAXehQXnGrsHgzflLMRgavzPe;
				if (LNBNOiXtAuhGWwSmVuQyexFHoitA == -2 && XkkYfWduuGuczDMUyDADEYVwjqGaA == Environment.CurrentManagedThreadId)
				{
					LNBNOiXtAuhGWwSmVuQyexFHoitA = 0;
					jDzyAXehQXnGrsHgzflLMRgavzPe = this;
				}
				else
				{
					jDzyAXehQXnGrsHgzflLMRgavzPe = new JDzyAXehQXnGrsHgzflLMRgavzPe(0);
					jDzyAXehQXnGrsHgzflLMRgavzPe.gODnMlQBBYfguBzKTzScOgJusxMV = gODnMlQBBYfguBzKTzScOgJusxMV;
				}
				jDzyAXehQXnGrsHgzflLMRgavzPe.WMPtfWpGlRGByCfXrYqPAgYkbPio = IQLQRaFcQsEnpXbkOstrlMJiVjsO;
				jDzyAXehQXnGrsHgzflLMRgavzPe.wexfIgNaYbhtuwZMqwRfELgVwKgq = qSRtfhTWlRDZOWbrIBGfHXVfKFMq;
				return jDzyAXehQXnGrsHgzflLMRgavzPe;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> OnIQqWtWuWbTYNHMFKsIsROmAWIE;

		private readonly ReadOnlyCollection<ActionElementMap> weEgItLElfxWWpCoYfUdMRMmXMvu;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return 0;
				}
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
				{
					return 0;
				}
				return OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return weEgItLElfxWWpCoYfUdMRMmXMvu;
			}
		}

		internal AList<ActionElementMap> aXVuCzREgytjInHGJBGAdDfTzxrQ => (AList<ActionElementMap>)OnIQqWtWuWbTYNHMFKsIsROmAWIE;

		public ControllerMapWithAxes()
		{
			OnIQqWtWuWbTYNHMFKsIsROmAWIE = new AList<ActionElementMap>();
			weEgItLElfxWWpCoYfUdMRMmXMvu = new ReadOnlyCollection<ActionElementMap>(OnIQqWtWuWbTYNHMFKsIsROmAWIE);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			OnIQqWtWuWbTYNHMFKsIsROmAWIE = new AList<ActionElementMap>();
			weEgItLElfxWWpCoYfUdMRMmXMvu = new ReadOnlyCollection<ActionElementMap>(OnIQqWtWuWbTYNHMFKsIsROmAWIE);
			ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
			if (P_0.OnIQqWtWuWbTYNHMFKsIsROmAWIE != null)
			{
				int count = P_0.OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
				for (int i = 0; i < count; i++)
				{
					YuwPAgRikqkGgnePwYFMuOVpVThK(new ActionElementMap(P_0.OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]));
				}
			}
			ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return false;
			}
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			YuwPAgRikqkGgnePwYFMuOVpVThK(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Axis;
				YuwPAgRikqkGgnePwYFMuOVpVThK(elementMap);
			}
			if (TgEuNEodQuFTrUnxOBTbjGQfhpKjb(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.QdHGgBretdLFkyCDGZYipGsllcwO(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			NYrIpryxvdZqmpgEkCfTusMBMiPF();
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = TgEuNEodQuFTrUnxOBTbjGQfhpKjb(elementMapId);
			if (num < 0)
			{
				return false;
			}
			ekIgRVuQZToqyisqqhOyfNsJxgRp(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return null;
			}
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].oETQtUYpoAHvrDdxockLYpfjFkywA == elementMapId)
				{
					return OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap RbcxiRbAfPqIyGEdgeezEPwQIpqv(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.shYLCVYqeFdYjcuwKYtizeWbDwqy(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return dnsdsoTJbRAsAnfWUzkJUmIBrzGE(P_0, P_1);
		}

		internal virtual int SpSeRxQLNRXTrcCsIWSQKpFnCPUeA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.eavfqqgRRryNzHBuhehtClpUwAzeb(P_0, P_1, P_2, P_3) + wLVQlhlYXxpgLoiYmrwfgcJwXmvy(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return;
			}
			base.ClearElementMaps();
			OnIQqWtWuWbTYNHMFKsIsROmAWIE.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null || index < 0 || index >= OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count)
			{
				return null;
			}
			return OnIQqWtWuWbTYNHMFKsIsROmAWIE[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(OnIQqWtWuWbTYNHMFKsIsROmAWIE);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return virTfkqVMnaZBWndlRXvXzzRshmF(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
				ActionElementMap actionElementMap2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return SnLrFGpHIpHUKIDNyEbgJPJFWWZpA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(aCKiYoCmtquntmarlYdnpibFfPMab))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new aCKiYoCmtquntmarlYdnpibFfPMab(-2)
			{
				lPhAZyhIcjitLLgmVoWfbaAFUzfNA = this,
				hnPIQJVpYgbJVMZblEFbYDthtdGT = actionId,
				pAtpEdmYLvnlrqptIVsCpoGVrMAC = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			return dnsdsoTJbRAsAnfWUzkJUmIBrzGE(predicate, false);
		}

		internal ActionElementMap dnsdsoTJbRAsAnfWUzkJUmIBrzGE(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return wLVQlhlYXxpgLoiYmrwfgcJwXmvy(predicate, false, results, false);
		}

		internal int wLVQlhlYXxpgLoiYmrwfgcJwXmvy(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
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
			return DeleteAxisMapsWithAction(ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[num2] != null && OnIQqWtWuWbTYNHMFKsIsROmAWIE[num2]._actionId == actionId)
				{
					ekIgRVuQZToqyisqqhOyfNsJxgRp(OnIQqWtWuWbTYNHMFKsIsROmAWIE[num2].oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int num = 0;
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb != state)
				{
					actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (skipDisabledMaps && !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
			{
				return false;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return false;
			}
			for (int i = 0; i < OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count; i++)
			{
				ActionElementMap actionElementMap2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if ((!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(qmHAyuCQuvARkluCmpkdRaBCMYniA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new qmHAyuCQuvARkluCmpkdRaBCMYniA(-2)
			{
				uyZeTxjDZQmQJPUWsyhqAyMipEWp = this,
				dArnKRwchiqEQGLOhDxFjCovmdBd = controllerMap,
				VahFdWQcXJgaNXMuLdaoAXsmPYILA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(pbWCvNCBEgasXJCvLfJmlqEAUPGhA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new pbWCvNCBEgasXJCvLfJmlqEAUPGhA(-2)
			{
				DhQIdZkmiHbHyegdahLaxPRssGHx = this,
				JaBLmVJqPhurbGdXADotKyusVyzn = actionElementMap,
				SGthdsULMdlnCgelEMpBgMXqYxpf = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(JDzyAXehQXnGrsHgzflLMRgavzPe))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new JDzyAXehQXnGrsHgzflLMRgavzPe(-2)
			{
				gODnMlQBBYfguBzKTzScOgJusxMV = this,
				IQLQRaFcQsEnpXbkOstrlMJiVjsO = conflictCheck,
				qSRtfhTWlRDZOWbrIBGfHXVfKFMq = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
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
			_ = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			int count = axisMaps.Count;
			for (int num2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[num2];
				if (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							ekIgRVuQZToqyisqqhOyfNsJxgRp(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return num;
			}
			for (int num2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE[num2];
				if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					ekIgRVuQZToqyisqqhOyfNsJxgRp(actionElementMap2.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
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
			for (int num2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[num2];
				if ((!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					ekIgRVuQZToqyisqqhOyfNsJxgRp(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int KLDvqYMoBMCTKPabjHwzetXAZFbo(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.nvmchnKoGxXFaoBqqNGNvPjIqMun(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
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
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (!actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int gBDGslJSefvHXqqbUjONkkEkUyunA(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.lcZlggKEXkqAPCwiNeGdvZOKjNuk(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int FxvYcbtsitMDkwGFhrEZNBQLDnoj(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.TkdZQUCDguLHxVfhnjqQyiCLqOMJ(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
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
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				array[i] = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool gFyppaLybTUNLpVbumHBHPrGGPGk(ActionElementMap P_0)
		{
			if (base.ZsPqvQrjowcgLqmuMupUIUTcDTMs(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(elementType))
			{
				return false;
			}
			YuwPAgRikqkGgnePwYFMuOVpVThK(P_0);
			return true;
		}

		internal virtual int SFaFquuRTtDzMsQbbFpNtkSCHtdq(List<ActionElementMap> P_0, bool P_1)
		{
			base.vqaXCYYIhKNPKOEecIkrfTkLlJDMA(P_0, P_1);
			int count = P_0.Count;
			int count2 = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					P_0.Add(OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap cAuVpWxHMyRMbaZOnyIwZrKITaPL(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.YSEbqnGErPYLIWehbqoBhlTPihkeb(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(P_2))
			{
				return null;
			}
			int num = yeSwNhTrKtnYGhtLVUlYnhhoKdNl(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return OnIQqWtWuWbTYNHMFKsIsROmAWIE[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int oYSxYDBCwFpxxOGjpaQrYCZCfUat(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.vjtrFFQofKYynFPXHpVoAoxzXuhC(P_0, P_1, P_2);
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return P_1.Count - num;
			}
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._elementIdentifierId == P_0)
				{
					P_1.Add(OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool ySnzWBzuvomVJHETBlqxaGFzwJGg(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.cApqyZdpFLngxdbLjgqiypzhAEct(P_0, P_1, P_2))
			{
				return true;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
				for (int i = 0; i < count; i++)
				{
					if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._elementIdentifierId == P_0 && OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int mfhNRUIaUAfrxoFHHAdUIqFNQBcDA(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.yeSwNhTrKtnYGhtLVUlYnhhoKdNl(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(P_2))
			{
				return -1;
			}
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
				for (int i = 0; i < count; i++)
				{
					if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._elementIdentifierId == P_0 && OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int TgEuNEodQuFTrUnxOBTbjGQfhpKjb(int P_0)
		{
			if (OnIQqWtWuWbTYNHMFKsIsROmAWIE == null)
			{
				return -1;
			}
			int count = OnIQqWtWuWbTYNHMFKsIsROmAWIE.Count;
			for (int i = 0; i < count; i++)
			{
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].oETQtUYpoAHvrDdxockLYpfjFkywA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int virTfkqVMnaZBWndlRXvXzzRshmF(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (!P_0 || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int SnLrFGpHIpHUKIDNyEbgJPJFWWZpA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int HOrQjGUadSzUlisFGgGOeqhCijUK(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.NsDAUTdPDDxqNrCesiwnZQUpFRfaA(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap axSGeujwziyPsteFSfsUozxRATOsA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.KxrsILBDQpdqcePUNUZVkTrjmufQA(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._actionId == P_2) && (!P_3 || OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].fpFEHHilwCsNTxvZcaeleakbBkQCb) && OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].IsTarget(P_0))
				{
					return OnIQqWtWuWbTYNHMFKsIsROmAWIE[i];
				}
			}
			return null;
		}

		internal virtual int cqLWsfSFzFZIeVdGdUCYcLadeZSU(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.rBPavCiiyAlojGkIqSyYebDCbwCgA(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]._actionId == P_2) && (!P_3 || OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].fpFEHHilwCsNTxvZcaeleakbBkQCb) && OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].IsTarget(P_0))
				{
					P_4.Add(OnIQqWtWuWbTYNHMFKsIsROmAWIE[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool nCbkyiFyDGQYVNSSaffsSIlFRbUM(ActionElementMap P_0)
		{
			if (base.UShaZMuDukPvPwnrsztNpMZlRrNe(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!JHIPkTlDQebUifxkFCfymZhaQxrg(P_0._elementType))
			{
				return false;
			}
			OnIQqWtWuWbTYNHMFKsIsROmAWIE.Add(P_0);
			IEKFdHyLBMRIBawFQLeZlGdsqfiP(P_0);
			return true;
		}

		private bool JHIPkTlDQebUifxkFCfymZhaQxrg(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void ekIgRVuQZToqyisqqhOyfNsJxgRp(int P_0, int P_1)
		{
			OVMcPGiNBsSQAOJWyFpceVfjMXGwA(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				OnIQqWtWuWbTYNHMFKsIsROmAWIE.RemoveAt(P_1);
			}
		}

		private void YuwPAgRikqkGgnePwYFMuOVpVThK(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				OnIQqWtWuWbTYNHMFKsIsROmAWIE.Add(P_0);
				IEKFdHyLBMRIBawFQLeZlGdsqfiP(P_0);
			}
		}

		private void WgTjRzwvITSQXUfylGGJdTBhuprO(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				qBKYqzpkXrfxTBpBHVsfvIYAxJjs(OnIQqWtWuWbTYNHMFKsIsROmAWIE[P_1].oETQtUYpoAHvrDdxockLYpfjFkywA, P_0);
				OnIQqWtWuWbTYNHMFKsIsROmAWIE[P_1] = P_0;
			}
		}

		internal virtual void FKGcJxgKnbWlqQzYFumHXKEnpdaE(SerializedObject P_0)
		{
			base.ccGlFtRmhwrbuTunsxwiZCRPTZVC(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (OnIQqWtWuWbTYNHMFKsIsROmAWIE[i] != null)
				{
					list.Add(OnIQqWtWuWbTYNHMFKsIsROmAWIE[i].gKPyKtvIOoYDmxjbtpXpzKKsHdmL());
				}
			}
		}

		internal virtual bool XjEaitRHqkbrjJTpaKmpnvgruzOK(SerializedObject P_0)
		{
			bool flag = base.XQNasbYvCKmFWyBnNCTsukEWkaNM(P_0);
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
						actionElementMap.eCQgvXXJzdnqwECUsFlURVcvFcrP(value2);
						if (ActionElementMap.evHDvbedLElPGfboBQYyRNAjBnjcA(actionElementMap))
						{
							YuwPAgRikqkGgnePwYFMuOVpVThK(actionElementMap);
						}
					}
				}
			}
			NYrIpryxvdZqmpgEkCfTusMBMiPF();
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> qtWrYuDBNDCMSQpVbSdtNVesnkUL(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> NcFGYOsLBstAJpXTSKbzZLwDgYAb(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> HAAMHTbmmMkFtBTEICxiWKVivlUG(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
