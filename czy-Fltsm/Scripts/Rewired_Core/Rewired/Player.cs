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
	public sealed class Player : sZLAxvZSvDRmVjMjTVRhHfujppQp
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class pUlIkmEVBKSpcPnscAmcIyFsgqBdb : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int IaGnrCDJEstMWMEEpsPKQhkhCZJO;

					private ElementAssignmentConflictInfo xmwDlmJPSTmSiVVUAuwvJqAbcuxY;

					private int iJnaXuYLVBBTKNSiEQKUWcbJEePc;

					private int WvqgTpHLSWENNMmdbzQLsRUtwjaV;

					public int PDIzcRXtkuivcyNcsfyLFzhNBnhpA;

					private CustomControllerMap KgPiVCtqmicUfFYltDFEIpzyddkR;

					public CustomControllerMap uhwGSTUqZySOaUybpwRHXHmgRMSN;

					public ConflictCheckingHelper LFcGVHxFFYaHTDUZhMtjEfTSxVwdA;

					private bool iWRLDzEAczqNHVAyDJAvyvrumSxB;

					public bool QLLaklgEvJQxUPVoJJLbASqovCXJA;

					private bool uhtUuaPagPWWaQFqtEeyUWdeSPqk;

					public bool NWPDcQIJoRkzrymULVPYsKVMMvyn;

					private int lAerGweaEHQkQJLUAemUpBZbkwtF;

					private IEnumerator<ElementAssignmentConflictInfo> tFqXtjDRLIoovUCrJUkEoYIbjRdN;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return xmwDlmJPSTmSiVVUAuwvJqAbcuxY;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xmwDlmJPSTmSiVVUAuwvJqAbcuxY;
						}
					}

					[DebuggerHidden]
					public pUlIkmEVBKSpcPnscAmcIyFsgqBdb(int P_0)
					{
						IaGnrCDJEstMWMEEpsPKQhkhCZJO = P_0;
						iJnaXuYLVBBTKNSiEQKUWcbJEePc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iaGnrCDJEstMWMEEpsPKQhkhCZJO = IaGnrCDJEstMWMEEpsPKQhkhCZJO;
						if (iaGnrCDJEstMWMEEpsPKQhkhCZJO == -3 || iaGnrCDJEstMWMEEpsPKQhkhCZJO == 1)
						{
							try
							{
							}
							finally
							{
								GHFRNMofhteCPUGTnnGQeaWUZcLT();
							}
						}
						tFqXtjDRLIoovUCrJUkEoYIbjRdN = null;
						IaGnrCDJEstMWMEEpsPKQhkhCZJO = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int iaGnrCDJEstMWMEEpsPKQhkhCZJO = IaGnrCDJEstMWMEEpsPKQhkhCZJO;
							ConflictCheckingHelper lFcGVHxFFYaHTDUZhMtjEfTSxVwdA = LFcGVHxFFYaHTDUZhMtjEfTSxVwdA;
							if (iaGnrCDJEstMWMEEpsPKQhkhCZJO != 0)
							{
								if (iaGnrCDJEstMWMEEpsPKQhkhCZJO != 1)
								{
									return false;
								}
								IaGnrCDJEstMWMEEpsPKQhkhCZJO = -3;
								goto IL_00eb;
							}
							IaGnrCDJEstMWMEEpsPKQhkhCZJO = -1;
							if (WvqgTpHLSWENNMmdbzQLsRUtwjaV < 0 || KgPiVCtqmicUfFYltDFEIpzyddkR == null)
							{
								return false;
							}
							lAerGweaEHQkQJLUAemUpBZbkwtF = 0;
							goto IL_0117;
							IL_00eb:
							if (tFqXtjDRLIoovUCrJUkEoYIbjRdN.MoveNext())
							{
								ElementAssignmentConflictInfo current = tFqXtjDRLIoovUCrJUkEoYIbjRdN.Current;
								xmwDlmJPSTmSiVVUAuwvJqAbcuxY = current;
								IaGnrCDJEstMWMEEpsPKQhkhCZJO = 1;
								return true;
							}
							GHFRNMofhteCPUGTnnGQeaWUZcLT();
							tFqXtjDRLIoovUCrJUkEoYIbjRdN = null;
							goto IL_0105;
							IL_0117:
							if (lAerGweaEHQkQJLUAemUpBZbkwtF < lFcGVHxFFYaHTDUZhMtjEfTSxVwdA.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB())
							{
								if (lFcGVHxFFYaHTDUZhMtjEfTSxVwdA.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(lAerGweaEHQkQJLUAemUpBZbkwtF).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == WvqgTpHLSWENNMmdbzQLsRUtwjaV)
								{
									tFqXtjDRLIoovUCrJUkEoYIbjRdN = lFcGVHxFFYaHTDUZhMtjEfTSxVwdA.mXNrHdSIaZRQrWiOlPvLDMkavZDq(ControllerType.Custom, WvqgTpHLSWENNMmdbzQLsRUtwjaV, KgPiVCtqmicUfFYltDFEIpzyddkR, iWRLDzEAczqNHVAyDJAvyvrumSxB, uhtUuaPagPWWaQFqtEeyUWdeSPqk, lFcGVHxFFYaHTDUZhMtjEfTSxVwdA.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(lAerGweaEHQkQJLUAemUpBZbkwtF).ZZnBfQBoEAksLWJBlRShlDbbsdXd).GetEnumerator();
									IaGnrCDJEstMWMEEpsPKQhkhCZJO = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							lAerGweaEHQkQJLUAemUpBZbkwtF++;
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

					private void GHFRNMofhteCPUGTnnGQeaWUZcLT()
					{
						IaGnrCDJEstMWMEEpsPKQhkhCZJO = -1;
						if (tFqXtjDRLIoovUCrJUkEoYIbjRdN != null)
						{
							tFqXtjDRLIoovUCrJUkEoYIbjRdN.Dispose();
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
						pUlIkmEVBKSpcPnscAmcIyFsgqBdb pUlIkmEVBKSpcPnscAmcIyFsgqBdb2;
						if (IaGnrCDJEstMWMEEpsPKQhkhCZJO == -2 && iJnaXuYLVBBTKNSiEQKUWcbJEePc == Environment.CurrentManagedThreadId)
						{
							IaGnrCDJEstMWMEEpsPKQhkhCZJO = 0;
							pUlIkmEVBKSpcPnscAmcIyFsgqBdb2 = this;
						}
						else
						{
							pUlIkmEVBKSpcPnscAmcIyFsgqBdb2 = new pUlIkmEVBKSpcPnscAmcIyFsgqBdb(0);
							pUlIkmEVBKSpcPnscAmcIyFsgqBdb2.LFcGVHxFFYaHTDUZhMtjEfTSxVwdA = LFcGVHxFFYaHTDUZhMtjEfTSxVwdA;
						}
						pUlIkmEVBKSpcPnscAmcIyFsgqBdb2.WvqgTpHLSWENNMmdbzQLsRUtwjaV = PDIzcRXtkuivcyNcsfyLFzhNBnhpA;
						pUlIkmEVBKSpcPnscAmcIyFsgqBdb2.KgPiVCtqmicUfFYltDFEIpzyddkR = uhwGSTUqZySOaUybpwRHXHmgRMSN;
						pUlIkmEVBKSpcPnscAmcIyFsgqBdb2.iWRLDzEAczqNHVAyDJAvyvrumSxB = QLLaklgEvJQxUPVoJJLbASqovCXJA;
						pUlIkmEVBKSpcPnscAmcIyFsgqBdb2.uhtUuaPagPWWaQFqtEeyUWdeSPqk = NWPDcQIJoRkzrymULVPYsKVMMvyn;
						return pUlIkmEVBKSpcPnscAmcIyFsgqBdb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class tGlniXSkkauYsdZoXaCSGxmtUIjA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int geNKdpzAAsBVZLQqhKISpAzbYzHq;

					private ElementAssignmentConflictInfo lnsJhonsTOgGVzYsrCePrWdzBaCY;

					private int eLUJuFlVSqkiwjPykKItIceGbgSr;

					private int nNaKMnKnSlVjPaiFbHmWVBJOahJE;

					public int makjLReMLmQYusUsOOuDBxMSjnGE;

					private ActionElementMap uVBqCRKOPJKhstrHgMcpYlhpnHib;

					public ActionElementMap NlmigxvwHBvrrPPhwqMJiWECtVsX;

					public ConflictCheckingHelper gCIDpDaOObThioUmMMubpDaQPnqB;

					private CustomControllerMap ZGJkTjPwiyumiducpoPxybBfjYyy;

					public CustomControllerMap HdHGYUbpVkcyZvmOiBJDDYsRqBdFA;

					private bool KXbHnfKECOtssCKIZqKYBnugNJIL;

					public bool FtKbrDhMihOTBhhFdoKiqKzINIwQb;

					private bool tHfufosDSOuAikoRwCouwgmzsDKc;

					public bool YniPUvoLbHZTBCfpQhoEviqJXwQd;

					private int zfOCJLiPBmRHuZkxDlNMwFnMAJPl;

					private IEnumerator<ElementAssignmentConflictInfo> bYwgiDIILHmvPMYSpbLYcJKrnfWZ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return lnsJhonsTOgGVzYsrCePrWdzBaCY;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lnsJhonsTOgGVzYsrCePrWdzBaCY;
						}
					}

					[DebuggerHidden]
					public tGlniXSkkauYsdZoXaCSGxmtUIjA(int P_0)
					{
						geNKdpzAAsBVZLQqhKISpAzbYzHq = P_0;
						eLUJuFlVSqkiwjPykKItIceGbgSr = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = geNKdpzAAsBVZLQqhKISpAzbYzHq;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								LuYHVoFwXhjWzhtwgSgetjXjLZnj();
							}
						}
						bYwgiDIILHmvPMYSpbLYcJKrnfWZ = null;
						geNKdpzAAsBVZLQqhKISpAzbYzHq = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = geNKdpzAAsBVZLQqhKISpAzbYzHq;
							ConflictCheckingHelper conflictCheckingHelper = gCIDpDaOObThioUmMMubpDaQPnqB;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								geNKdpzAAsBVZLQqhKISpAzbYzHq = -3;
								goto IL_00f1;
							}
							geNKdpzAAsBVZLQqhKISpAzbYzHq = -1;
							if (nNaKMnKnSlVjPaiFbHmWVBJOahJE < 0 || uVBqCRKOPJKhstrHgMcpYlhpnHib == null)
							{
								return false;
							}
							zfOCJLiPBmRHuZkxDlNMwFnMAJPl = 0;
							goto IL_011d;
							IL_00f1:
							if (bYwgiDIILHmvPMYSpbLYcJKrnfWZ.MoveNext())
							{
								ElementAssignmentConflictInfo current = bYwgiDIILHmvPMYSpbLYcJKrnfWZ.Current;
								lnsJhonsTOgGVzYsrCePrWdzBaCY = current;
								geNKdpzAAsBVZLQqhKISpAzbYzHq = 1;
								return true;
							}
							LuYHVoFwXhjWzhtwgSgetjXjLZnj();
							bYwgiDIILHmvPMYSpbLYcJKrnfWZ = null;
							goto IL_010b;
							IL_011d:
							if (zfOCJLiPBmRHuZkxDlNMwFnMAJPl < conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB())
							{
								if (conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(zfOCJLiPBmRHuZkxDlNMwFnMAJPl).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == nNaKMnKnSlVjPaiFbHmWVBJOahJE)
								{
									bYwgiDIILHmvPMYSpbLYcJKrnfWZ = conflictCheckingHelper.SdKztNzZHycRMlYChiSJDAgaqHJB(ControllerType.Custom, nNaKMnKnSlVjPaiFbHmWVBJOahJE, ZGJkTjPwiyumiducpoPxybBfjYyy, uVBqCRKOPJKhstrHgMcpYlhpnHib, KXbHnfKECOtssCKIZqKYBnugNJIL, tHfufosDSOuAikoRwCouwgmzsDKc, conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(zfOCJLiPBmRHuZkxDlNMwFnMAJPl).ZZnBfQBoEAksLWJBlRShlDbbsdXd).GetEnumerator();
									geNKdpzAAsBVZLQqhKISpAzbYzHq = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							zfOCJLiPBmRHuZkxDlNMwFnMAJPl++;
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

					private void LuYHVoFwXhjWzhtwgSgetjXjLZnj()
					{
						geNKdpzAAsBVZLQqhKISpAzbYzHq = -1;
						if (bYwgiDIILHmvPMYSpbLYcJKrnfWZ != null)
						{
							bYwgiDIILHmvPMYSpbLYcJKrnfWZ.Dispose();
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
						tGlniXSkkauYsdZoXaCSGxmtUIjA tGlniXSkkauYsdZoXaCSGxmtUIjA2;
						if (geNKdpzAAsBVZLQqhKISpAzbYzHq == -2 && eLUJuFlVSqkiwjPykKItIceGbgSr == Environment.CurrentManagedThreadId)
						{
							geNKdpzAAsBVZLQqhKISpAzbYzHq = 0;
							tGlniXSkkauYsdZoXaCSGxmtUIjA2 = this;
						}
						else
						{
							tGlniXSkkauYsdZoXaCSGxmtUIjA2 = new tGlniXSkkauYsdZoXaCSGxmtUIjA(0);
							tGlniXSkkauYsdZoXaCSGxmtUIjA2.gCIDpDaOObThioUmMMubpDaQPnqB = gCIDpDaOObThioUmMMubpDaQPnqB;
						}
						tGlniXSkkauYsdZoXaCSGxmtUIjA2.nNaKMnKnSlVjPaiFbHmWVBJOahJE = makjLReMLmQYusUsOOuDBxMSjnGE;
						tGlniXSkkauYsdZoXaCSGxmtUIjA2.ZGJkTjPwiyumiducpoPxybBfjYyy = HdHGYUbpVkcyZvmOiBJDDYsRqBdFA;
						tGlniXSkkauYsdZoXaCSGxmtUIjA2.uVBqCRKOPJKhstrHgMcpYlhpnHib = NlmigxvwHBvrrPPhwqMJiWECtVsX;
						tGlniXSkkauYsdZoXaCSGxmtUIjA2.KXbHnfKECOtssCKIZqKYBnugNJIL = FtKbrDhMihOTBhhFdoKiqKzINIwQb;
						tGlniXSkkauYsdZoXaCSGxmtUIjA2.tHfufosDSOuAikoRwCouwgmzsDKc = YniPUvoLbHZTBCfpQhoEviqJXwQd;
						return tGlniXSkkauYsdZoXaCSGxmtUIjA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class nejgXgCNBiFGiiTGAgLgIyThXggGc : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int GwiZzYLniUIeNESycKckafvRlOHF;

					private ElementAssignmentConflictInfo ptkatQsqSCAlEMZVJFwhWWVbpOmj;

					private int pgIrxdDSrxNzFOoFOAAxQhESVMDG;

					private ElementAssignmentConflictCheck KfiXcSyYUhFlwRrkNDdkidhtGAUp;

					public ElementAssignmentConflictCheck MAaSFkvnUZDiBjbnodEcFFbjubIKB;

					public ConflictCheckingHelper bdaObFRDYDZbrvFpNbkTjgigcgMqA;

					private bool zZOcBZBQQIlnPonfYZrwpkMkjbBY;

					public bool UUQSVUyxkMaSFIlSNTNyALXNTGQT;

					private bool IjixZiDxFcaFSGiYdmarEKvoOtEc;

					public bool HXAcaVEDxrVUOFJaVlDiIyXOYPsl;

					private int ECvRRpshdTeKNaESjJQCEDaMSUirA;

					private IEnumerator<ElementAssignmentConflictInfo> OXuDzwHLmLfuVJejNKIEdnmmZMstA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ptkatQsqSCAlEMZVJFwhWWVbpOmj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ptkatQsqSCAlEMZVJFwhWWVbpOmj;
						}
					}

					[DebuggerHidden]
					public nejgXgCNBiFGiiTGAgLgIyThXggGc(int P_0)
					{
						GwiZzYLniUIeNESycKckafvRlOHF = P_0;
						pgIrxdDSrxNzFOoFOAAxQhESVMDG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwiZzYLniUIeNESycKckafvRlOHF = GwiZzYLniUIeNESycKckafvRlOHF;
						if (gwiZzYLniUIeNESycKckafvRlOHF == -3 || gwiZzYLniUIeNESycKckafvRlOHF == 1)
						{
							try
							{
							}
							finally
							{
								IxMzKMjAMtHYVsFeIriyviLZivKBA();
							}
						}
						OXuDzwHLmLfuVJejNKIEdnmmZMstA = null;
						GwiZzYLniUIeNESycKckafvRlOHF = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int gwiZzYLniUIeNESycKckafvRlOHF = GwiZzYLniUIeNESycKckafvRlOHF;
							ConflictCheckingHelper conflictCheckingHelper = bdaObFRDYDZbrvFpNbkTjgigcgMqA;
							if (gwiZzYLniUIeNESycKckafvRlOHF != 0)
							{
								if (gwiZzYLniUIeNESycKckafvRlOHF != 1)
								{
									return false;
								}
								GwiZzYLniUIeNESycKckafvRlOHF = -3;
								goto IL_00f3;
							}
							GwiZzYLniUIeNESycKckafvRlOHF = -1;
							if (KfiXcSyYUhFlwRrkNDdkidhtGAUp.controllerId < 0 || KfiXcSyYUhFlwRrkNDdkidhtGAUp.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							ECvRRpshdTeKNaESjJQCEDaMSUirA = 0;
							goto IL_011f;
							IL_00f3:
							if (OXuDzwHLmLfuVJejNKIEdnmmZMstA.MoveNext())
							{
								ElementAssignmentConflictInfo current = OXuDzwHLmLfuVJejNKIEdnmmZMstA.Current;
								ptkatQsqSCAlEMZVJFwhWWVbpOmj = current;
								GwiZzYLniUIeNESycKckafvRlOHF = 1;
								return true;
							}
							IxMzKMjAMtHYVsFeIriyviLZivKBA();
							OXuDzwHLmLfuVJejNKIEdnmmZMstA = null;
							goto IL_010d;
							IL_011f:
							if (ECvRRpshdTeKNaESjJQCEDaMSUirA < conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB())
							{
								if (conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(ECvRRpshdTeKNaESjJQCEDaMSUirA).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == KfiXcSyYUhFlwRrkNDdkidhtGAUp.controllerId)
								{
									OXuDzwHLmLfuVJejNKIEdnmmZMstA = conflictCheckingHelper.nWmEFwqqSNFLSDZZwcibfGnfEtxGb(KfiXcSyYUhFlwRrkNDdkidhtGAUp, zZOcBZBQQIlnPonfYZrwpkMkjbBY, IjixZiDxFcaFSGiYdmarEKvoOtEc, conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(ECvRRpshdTeKNaESjJQCEDaMSUirA).ZZnBfQBoEAksLWJBlRShlDbbsdXd).GetEnumerator();
									GwiZzYLniUIeNESycKckafvRlOHF = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							ECvRRpshdTeKNaESjJQCEDaMSUirA++;
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

					private void IxMzKMjAMtHYVsFeIriyviLZivKBA()
					{
						GwiZzYLniUIeNESycKckafvRlOHF = -1;
						if (OXuDzwHLmLfuVJejNKIEdnmmZMstA != null)
						{
							OXuDzwHLmLfuVJejNKIEdnmmZMstA.Dispose();
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
						nejgXgCNBiFGiiTGAgLgIyThXggGc nejgXgCNBiFGiiTGAgLgIyThXggGc2;
						if (GwiZzYLniUIeNESycKckafvRlOHF == -2 && pgIrxdDSrxNzFOoFOAAxQhESVMDG == Environment.CurrentManagedThreadId)
						{
							GwiZzYLniUIeNESycKckafvRlOHF = 0;
							nejgXgCNBiFGiiTGAgLgIyThXggGc2 = this;
						}
						else
						{
							nejgXgCNBiFGiiTGAgLgIyThXggGc2 = new nejgXgCNBiFGiiTGAgLgIyThXggGc(0);
							nejgXgCNBiFGiiTGAgLgIyThXggGc2.bdaObFRDYDZbrvFpNbkTjgigcgMqA = bdaObFRDYDZbrvFpNbkTjgigcgMqA;
						}
						nejgXgCNBiFGiiTGAgLgIyThXggGc2.KfiXcSyYUhFlwRrkNDdkidhtGAUp = MAaSFkvnUZDiBjbnodEcFFbjubIKB;
						nejgXgCNBiFGiiTGAgLgIyThXggGc2.zZOcBZBQQIlnPonfYZrwpkMkjbBY = UUQSVUyxkMaSFIlSNTNyALXNTGQT;
						nejgXgCNBiFGiiTGAgLgIyThXggGc2.IjixZiDxFcaFSGiYdmarEKvoOtEc = HXAcaVEDxrVUOFJaVlDiIyXOYPsl;
						return nejgXgCNBiFGiiTGAgLgIyThXggGc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class GTZYDPXycRSTMgoAJjEfvGBHnJbV<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int nqJMbttIkhAOLrhZQlkaHCFtHBog;

					private ElementAssignmentConflictInfo krEYNxKfYdfcJhbrxtgVpEpMPXLb;

					private int KBnXclZPeesnOukAsiQeSKIaZJRm;

					private global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> qPYamqXnjuQGTZCYeccAFhqccKMeA;

					public global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> HTfWPVNrlxpDaVoJNVlEIlFACjzJA;

					private _0001 TBJvduvfFDMmWDbANMOPvGgldDMb;

					public _0001 ktNRdwbJMXBxvBxgOtdrTYkWKTEbA;

					private bool rTJCJxdnPdatMIMsWigyGbcgqvpT;

					public bool JNxWvQTCJUZdyoGeqqXsseUwAKpV;

					private bool krzcTsPKeVduhYWRwicIXEqhXEny;

					public bool SdaZPSVEkKhvcoGBUByFAzFNFiay;

					public ConflictCheckingHelper ckSsBDdwhaFjfxceEybXTudkGcRL;

					private ControllerType PbfSUVOzRQFjbIBLjNgekfzftOCh;

					public ControllerType CZPZzsBsThAeORuyNKldMfxnKRsh;

					private int eGzpkDqIAxfRPHWIknFMtcMWDvRl;

					public int bbIpTIviiNYotwGknITWESaPncVwA;

					private InputMapCategory cFvsnIaGuLYHRGWbzWgQgnVtQwqn;

					private int CVqgdVKagzoXUwEbSoLEgZaTbzOTA;

					private IEnumerator<ElementAssignmentConflictInfo> nhwPpUPxxVgPTDvyGpeSKKrkXSoC;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return krEYNxKfYdfcJhbrxtgVpEpMPXLb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return krEYNxKfYdfcJhbrxtgVpEpMPXLb;
						}
					}

					[DebuggerHidden]
					public GTZYDPXycRSTMgoAJjEfvGBHnJbV(int P_0)
					{
						nqJMbttIkhAOLrhZQlkaHCFtHBog = P_0;
						KBnXclZPeesnOukAsiQeSKIaZJRm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = nqJMbttIkhAOLrhZQlkaHCFtHBog;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								HmdEkvFefyGsqQRELloBmtdhPSwFb();
							}
						}
						cFvsnIaGuLYHRGWbzWgQgnVtQwqn = null;
						nhwPpUPxxVgPTDvyGpeSKKrkXSoC = null;
						nqJMbttIkhAOLrhZQlkaHCFtHBog = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = nqJMbttIkhAOLrhZQlkaHCFtHBog;
							ConflictCheckingHelper conflictCheckingHelper = ckSsBDdwhaFjfxceEybXTudkGcRL;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								nqJMbttIkhAOLrhZQlkaHCFtHBog = -3;
								goto IL_014a;
							}
							nqJMbttIkhAOLrhZQlkaHCFtHBog = -1;
							if (qPYamqXnjuQGTZCYeccAFhqccKMeA == null || TBJvduvfFDMmWDbANMOPvGgldDMb == null)
							{
								return false;
							}
							cFvsnIaGuLYHRGWbzWgQgnVtQwqn = ReInput.mapping.GetMapCategory(TBJvduvfFDMmWDbANMOPvGgldDMb.categoryId);
							if (cFvsnIaGuLYHRGWbzWgQgnVtQwqn == null)
							{
								return false;
							}
							CVqgdVKagzoXUwEbSoLEgZaTbzOTA = 0;
							goto IL_0176;
							IL_0176:
							if (CVqgdVKagzoXUwEbSoLEgZaTbzOTA < qPYamqXnjuQGTZCYeccAFhqccKMeA.BnLfdLdejZPchYBMOscGuqKWagU())
							{
								ControllerMap controllerMap = qPYamqXnjuQGTZCYeccAFhqccKMeA.QctWoySrGTZJSArZHyJFYsCcnKlK(CVqgdVKagzoXUwEbSoLEgZaTbzOTA);
								if ((!rTJCJxdnPdatMIMsWigyGbcgqvpT || controllerMap.enabled) && (krzcTsPKeVduhYWRwicIXEqhXEny || !conflictCheckingHelper.QGpEhRYeXhnXcdAvDPhtMPsahqIc(cFvsnIaGuLYHRGWbzWgQgnVtQwqn, controllerMap)))
								{
									nhwPpUPxxVgPTDvyGpeSKKrkXSoC = controllerMap.ElementAssignmentConflicts(TBJvduvfFDMmWDbANMOPvGgldDMb, rTJCJxdnPdatMIMsWigyGbcgqvpT).GetEnumerator();
									nqJMbttIkhAOLrhZQlkaHCFtHBog = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (nhwPpUPxxVgPTDvyGpeSKKrkXSoC.MoveNext())
							{
								ElementAssignmentConflictInfo current = nhwPpUPxxVgPTDvyGpeSKKrkXSoC.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.cPDEDRHxuzfcPPmupWHGPWNmnoOtA.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								elementAssignmentConflictInfo.controllerType = PbfSUVOzRQFjbIBLjNgekfzftOCh;
								elementAssignmentConflictInfo.controllerId = eGzpkDqIAxfRPHWIknFMtcMWDvRl;
								krEYNxKfYdfcJhbrxtgVpEpMPXLb = elementAssignmentConflictInfo;
								nqJMbttIkhAOLrhZQlkaHCFtHBog = 1;
								return true;
							}
							HmdEkvFefyGsqQRELloBmtdhPSwFb();
							nhwPpUPxxVgPTDvyGpeSKKrkXSoC = null;
							goto IL_0164;
							IL_0164:
							CVqgdVKagzoXUwEbSoLEgZaTbzOTA++;
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

					private void HmdEkvFefyGsqQRELloBmtdhPSwFb()
					{
						nqJMbttIkhAOLrhZQlkaHCFtHBog = -1;
						if (nhwPpUPxxVgPTDvyGpeSKKrkXSoC != null)
						{
							nhwPpUPxxVgPTDvyGpeSKKrkXSoC.Dispose();
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
						GTZYDPXycRSTMgoAJjEfvGBHnJbV<_0001> gTZYDPXycRSTMgoAJjEfvGBHnJbV;
						if (nqJMbttIkhAOLrhZQlkaHCFtHBog == -2 && KBnXclZPeesnOukAsiQeSKIaZJRm == Environment.CurrentManagedThreadId)
						{
							nqJMbttIkhAOLrhZQlkaHCFtHBog = 0;
							gTZYDPXycRSTMgoAJjEfvGBHnJbV = this;
						}
						else
						{
							gTZYDPXycRSTMgoAJjEfvGBHnJbV = new GTZYDPXycRSTMgoAJjEfvGBHnJbV<_0001>(0);
							gTZYDPXycRSTMgoAJjEfvGBHnJbV.ckSsBDdwhaFjfxceEybXTudkGcRL = ckSsBDdwhaFjfxceEybXTudkGcRL;
						}
						gTZYDPXycRSTMgoAJjEfvGBHnJbV.PbfSUVOzRQFjbIBLjNgekfzftOCh = CZPZzsBsThAeORuyNKldMfxnKRsh;
						gTZYDPXycRSTMgoAJjEfvGBHnJbV.eGzpkDqIAxfRPHWIknFMtcMWDvRl = bbIpTIviiNYotwGknITWESaPncVwA;
						gTZYDPXycRSTMgoAJjEfvGBHnJbV.TBJvduvfFDMmWDbANMOPvGgldDMb = ktNRdwbJMXBxvBxgOtdrTYkWKTEbA;
						gTZYDPXycRSTMgoAJjEfvGBHnJbV.rTJCJxdnPdatMIMsWigyGbcgqvpT = JNxWvQTCJUZdyoGeqqXsseUwAKpV;
						gTZYDPXycRSTMgoAJjEfvGBHnJbV.krzcTsPKeVduhYWRwicIXEqhXEny = SdaZPSVEkKhvcoGBUByFAzFNFiay;
						gTZYDPXycRSTMgoAJjEfvGBHnJbV.qPYamqXnjuQGTZCYeccAFhqccKMeA = HTfWPVNrlxpDaVoJNVlEIlFACjzJA;
						return gTZYDPXycRSTMgoAJjEfvGBHnJbV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class pnFUYxJLQtoIfjgeUDoAClAJJzFw<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int GlaDdoUwnpViRiteniFSzZpOUACm;

					private ElementAssignmentConflictInfo RdrHlDGCfKrCeSskdlwzqEInSHkfA;

					private int GIrMFNrwxQpKmvcvFVntrHUUZMVG;

					private global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> omtVNbIoaVUkdIvpgixvHqZGUDPR;

					public global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> xPITOBzLChsyZYVzyTMYJRLzcEvl;

					private ActionElementMap UdOyJmZtWRssvofmHANhDOnBupexA;

					public ActionElementMap cQcDHEzDMAFQBTmMcSqrVdqtLrIV;

					private _0001 uDyICSLmQYdLFNeJqdeJmcJlwLhn;

					public _0001 oLsbiaKImpZjWfvcMdYMYSDOazeU;

					private bool nAxGZdemIpneJiruMwpCQjrnAYlw;

					public bool EGEoveNzidlGNMarRnUhBsvROWIR;

					private bool flyCBbGMJBdsNlznWCdiaoJJdjcrA;

					public bool xlLwmPGhRTpeMDVJpopxSRfiTMII;

					public ConflictCheckingHelper BOfWALebNRDpKDjKnCpGSDdAPfTjA;

					private ControllerType zKGEfkQDCPlgHFwJtQnOYwQwtqUr;

					public ControllerType XAyOImNWnbRnrRpPHViHZZWuzcpk;

					private int URlZrutJarKilsYNiCPFmfHMcQGhA;

					public int LPBHaZsKeCdgKBfPbEhVCeJWaPalA;

					private InputMapCategory muQJHZeICtudBoFKuCDQgHgprfdA;

					private int rMNdlfVhUQbEmgxbUBABOtMzRJFNA;

					private IEnumerator<ElementAssignmentConflictInfo> rPLhebcTAAQUhyTzWgXozufSikut;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RdrHlDGCfKrCeSskdlwzqEInSHkfA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RdrHlDGCfKrCeSskdlwzqEInSHkfA;
						}
					}

					[DebuggerHidden]
					public pnFUYxJLQtoIfjgeUDoAClAJJzFw(int P_0)
					{
						GlaDdoUwnpViRiteniFSzZpOUACm = P_0;
						GIrMFNrwxQpKmvcvFVntrHUUZMVG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int glaDdoUwnpViRiteniFSzZpOUACm = GlaDdoUwnpViRiteniFSzZpOUACm;
						if (glaDdoUwnpViRiteniFSzZpOUACm == -3 || glaDdoUwnpViRiteniFSzZpOUACm == 1)
						{
							try
							{
							}
							finally
							{
								jdatrCITUSvGiirgFcwfBKUszzJe();
							}
						}
						muQJHZeICtudBoFKuCDQgHgprfdA = null;
						rPLhebcTAAQUhyTzWgXozufSikut = null;
						GlaDdoUwnpViRiteniFSzZpOUACm = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int glaDdoUwnpViRiteniFSzZpOUACm = GlaDdoUwnpViRiteniFSzZpOUACm;
							ConflictCheckingHelper bOfWALebNRDpKDjKnCpGSDdAPfTjA = BOfWALebNRDpKDjKnCpGSDdAPfTjA;
							if (glaDdoUwnpViRiteniFSzZpOUACm != 0)
							{
								if (glaDdoUwnpViRiteniFSzZpOUACm != 1)
								{
									return false;
								}
								GlaDdoUwnpViRiteniFSzZpOUACm = -3;
								goto IL_0141;
							}
							GlaDdoUwnpViRiteniFSzZpOUACm = -1;
							if (omtVNbIoaVUkdIvpgixvHqZGUDPR == null || UdOyJmZtWRssvofmHANhDOnBupexA == null)
							{
								return false;
							}
							muQJHZeICtudBoFKuCDQgHgprfdA = ((uDyICSLmQYdLFNeJqdeJmcJlwLhn != null) ? ReInput.mapping.GetMapCategory(uDyICSLmQYdLFNeJqdeJmcJlwLhn.categoryId) : null);
							rMNdlfVhUQbEmgxbUBABOtMzRJFNA = 0;
							goto IL_016d;
							IL_016d:
							if (rMNdlfVhUQbEmgxbUBABOtMzRJFNA < omtVNbIoaVUkdIvpgixvHqZGUDPR.BnLfdLdejZPchYBMOscGuqKWagU())
							{
								ControllerMap controllerMap = omtVNbIoaVUkdIvpgixvHqZGUDPR.QctWoySrGTZJSArZHyJFYsCcnKlK(rMNdlfVhUQbEmgxbUBABOtMzRJFNA);
								if ((!nAxGZdemIpneJiruMwpCQjrnAYlw || controllerMap.enabled) && (flyCBbGMJBdsNlznWCdiaoJJdjcrA || !bOfWALebNRDpKDjKnCpGSDdAPfTjA.QGpEhRYeXhnXcdAvDPhtMPsahqIc(muQJHZeICtudBoFKuCDQgHgprfdA, controllerMap)))
								{
									rPLhebcTAAQUhyTzWgXozufSikut = controllerMap.ElementAssignmentConflicts(UdOyJmZtWRssvofmHANhDOnBupexA, nAxGZdemIpneJiruMwpCQjrnAYlw).GetEnumerator();
									GlaDdoUwnpViRiteniFSzZpOUACm = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							rMNdlfVhUQbEmgxbUBABOtMzRJFNA++;
							goto IL_016d;
							IL_0141:
							if (rPLhebcTAAQUhyTzWgXozufSikut.MoveNext())
							{
								ElementAssignmentConflictInfo current = rPLhebcTAAQUhyTzWgXozufSikut.Current;
								ElementAssignmentConflictInfo rdrHlDGCfKrCeSskdlwzqEInSHkfA = new ElementAssignmentConflictInfo(current);
								rdrHlDGCfKrCeSskdlwzqEInSHkfA.playerId = bOfWALebNRDpKDjKnCpGSDdAPfTjA.cPDEDRHxuzfcPPmupWHGPWNmnoOtA.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								rdrHlDGCfKrCeSskdlwzqEInSHkfA.controllerType = zKGEfkQDCPlgHFwJtQnOYwQwtqUr;
								rdrHlDGCfKrCeSskdlwzqEInSHkfA.controllerId = URlZrutJarKilsYNiCPFmfHMcQGhA;
								RdrHlDGCfKrCeSskdlwzqEInSHkfA = rdrHlDGCfKrCeSskdlwzqEInSHkfA;
								GlaDdoUwnpViRiteniFSzZpOUACm = 1;
								return true;
							}
							jdatrCITUSvGiirgFcwfBKUszzJe();
							rPLhebcTAAQUhyTzWgXozufSikut = null;
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

					private void jdatrCITUSvGiirgFcwfBKUszzJe()
					{
						GlaDdoUwnpViRiteniFSzZpOUACm = -1;
						if (rPLhebcTAAQUhyTzWgXozufSikut != null)
						{
							rPLhebcTAAQUhyTzWgXozufSikut.Dispose();
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
						pnFUYxJLQtoIfjgeUDoAClAJJzFw<_0001> pnFUYxJLQtoIfjgeUDoAClAJJzFw2;
						if (GlaDdoUwnpViRiteniFSzZpOUACm == -2 && GIrMFNrwxQpKmvcvFVntrHUUZMVG == Environment.CurrentManagedThreadId)
						{
							GlaDdoUwnpViRiteniFSzZpOUACm = 0;
							pnFUYxJLQtoIfjgeUDoAClAJJzFw2 = this;
						}
						else
						{
							pnFUYxJLQtoIfjgeUDoAClAJJzFw2 = new pnFUYxJLQtoIfjgeUDoAClAJJzFw<_0001>(0);
							pnFUYxJLQtoIfjgeUDoAClAJJzFw2.BOfWALebNRDpKDjKnCpGSDdAPfTjA = BOfWALebNRDpKDjKnCpGSDdAPfTjA;
						}
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.zKGEfkQDCPlgHFwJtQnOYwQwtqUr = XAyOImNWnbRnrRpPHViHZZWuzcpk;
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.URlZrutJarKilsYNiCPFmfHMcQGhA = LPBHaZsKeCdgKBfPbEhVCeJWaPalA;
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.uDyICSLmQYdLFNeJqdeJmcJlwLhn = oLsbiaKImpZjWfvcMdYMYSDOazeU;
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.UdOyJmZtWRssvofmHANhDOnBupexA = cQcDHEzDMAFQBTmMcSqrVdqtLrIV;
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.nAxGZdemIpneJiruMwpCQjrnAYlw = EGEoveNzidlGNMarRnUhBsvROWIR;
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.flyCBbGMJBdsNlznWCdiaoJJdjcrA = xlLwmPGhRTpeMDVJpopxSRfiTMII;
						pnFUYxJLQtoIfjgeUDoAClAJJzFw2.omtVNbIoaVUkdIvpgixvHqZGUDPR = xPITOBzLChsyZYVzyTMYJRLzcEvl;
						return pnFUYxJLQtoIfjgeUDoAClAJJzFw2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class IjZYoFYGFAMfcSDECNpNJrsKlEts<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int cspUNRtcuVOejrkgFRbcxRWKWELJ;

					private ElementAssignmentConflictInfo DhdrPJxELYxIfPLiIMdAyKIJABve;

					private int NyFSIXtgyrFpDCsPOOIrelAcQEgl;

					private global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> APxQWLBeczZyifdQkdoiIbuWaNGY;

					public global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> hHmzUncfHvxPXSRdjiGXvfrldJSJA;

					private ElementAssignmentConflictCheck rhAciEEgXKJvSqYMPPOkwdHtmoESA;

					public ElementAssignmentConflictCheck jWdqPvIqNuFLsapGoCNFtNUyxzvV;

					private bool VRbmSKbwoCOTVlBHMeyPqESAYCJp;

					public bool IisAxouTUFgVkPOHWEojGoWWmQhu;

					private bool SGmdXLlauXLyKYMzIEGTmmzFLzGm;

					public bool oGcmNAiHLnElmEnUHQnXwmmFIRrm;

					public ConflictCheckingHelper CSGBKEaqgHLRbDpkKimuJibAxvrvB;

					private InputMapCategory hNrfJoWoTOSlFOKNYdxtzgmlurDe;

					private int tXJFBcAXIZlhXapUzcIPqzPOdRbN;

					private IEnumerator<ElementAssignmentConflictInfo> wKFqERKMrFROyNPnZeVygffsfZI;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DhdrPJxELYxIfPLiIMdAyKIJABve;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DhdrPJxELYxIfPLiIMdAyKIJABve;
						}
					}

					[DebuggerHidden]
					public IjZYoFYGFAMfcSDECNpNJrsKlEts(int P_0)
					{
						cspUNRtcuVOejrkgFRbcxRWKWELJ = P_0;
						NyFSIXtgyrFpDCsPOOIrelAcQEgl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cspUNRtcuVOejrkgFRbcxRWKWELJ;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								NKxBMoHcCYJQZauBgPYbxpsZModmA();
							}
						}
						hNrfJoWoTOSlFOKNYdxtzgmlurDe = null;
						wKFqERKMrFROyNPnZeVygffsfZI = null;
						cspUNRtcuVOejrkgFRbcxRWKWELJ = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = cspUNRtcuVOejrkgFRbcxRWKWELJ;
							ConflictCheckingHelper cSGBKEaqgHLRbDpkKimuJibAxvrvB = CSGBKEaqgHLRbDpkKimuJibAxvrvB;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cspUNRtcuVOejrkgFRbcxRWKWELJ = -3;
								goto IL_01ab;
							}
							cspUNRtcuVOejrkgFRbcxRWKWELJ = -1;
							if (APxQWLBeczZyifdQkdoiIbuWaNGY == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(rhAciEEgXKJvSqYMPPOkwdHtmoESA.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(rhAciEEgXKJvSqYMPPOkwdHtmoESA.controllerType, rhAciEEgXKJvSqYMPPOkwdHtmoESA.controllerId, rhAciEEgXKJvSqYMPPOkwdHtmoESA.controllerMapId);
							hNrfJoWoTOSlFOKNYdxtzgmlurDe = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(rhAciEEgXKJvSqYMPPOkwdHtmoESA.controllerMapCategoryId));
							if (hNrfJoWoTOSlFOKNYdxtzgmlurDe == null)
							{
								return false;
							}
							tXJFBcAXIZlhXapUzcIPqzPOdRbN = 0;
							goto IL_01d7;
							IL_01ab:
							if (wKFqERKMrFROyNPnZeVygffsfZI.MoveNext())
							{
								ElementAssignmentConflictInfo current = wKFqERKMrFROyNPnZeVygffsfZI.Current;
								ElementAssignmentConflictInfo dhdrPJxELYxIfPLiIMdAyKIJABve = new ElementAssignmentConflictInfo(current);
								dhdrPJxELYxIfPLiIMdAyKIJABve.playerId = cSGBKEaqgHLRbDpkKimuJibAxvrvB.cPDEDRHxuzfcPPmupWHGPWNmnoOtA.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								dhdrPJxELYxIfPLiIMdAyKIJABve.controllerType = rhAciEEgXKJvSqYMPPOkwdHtmoESA.controllerType;
								dhdrPJxELYxIfPLiIMdAyKIJABve.controllerId = rhAciEEgXKJvSqYMPPOkwdHtmoESA.controllerId;
								DhdrPJxELYxIfPLiIMdAyKIJABve = dhdrPJxELYxIfPLiIMdAyKIJABve;
								cspUNRtcuVOejrkgFRbcxRWKWELJ = 1;
								return true;
							}
							NKxBMoHcCYJQZauBgPYbxpsZModmA();
							wKFqERKMrFROyNPnZeVygffsfZI = null;
							goto IL_01c5;
							IL_01d7:
							if (tXJFBcAXIZlhXapUzcIPqzPOdRbN < APxQWLBeczZyifdQkdoiIbuWaNGY.BnLfdLdejZPchYBMOscGuqKWagU())
							{
								ControllerMap controllerMap = APxQWLBeczZyifdQkdoiIbuWaNGY.QctWoySrGTZJSArZHyJFYsCcnKlK(tXJFBcAXIZlhXapUzcIPqzPOdRbN);
								if ((!VRbmSKbwoCOTVlBHMeyPqESAYCJp || controllerMap.enabled) && (SGmdXLlauXLyKYMzIEGTmmzFLzGm || !cSGBKEaqgHLRbDpkKimuJibAxvrvB.QGpEhRYeXhnXcdAvDPhtMPsahqIc(hNrfJoWoTOSlFOKNYdxtzgmlurDe, controllerMap)))
								{
									wKFqERKMrFROyNPnZeVygffsfZI = controllerMap.ElementAssignmentConflicts(rhAciEEgXKJvSqYMPPOkwdHtmoESA, VRbmSKbwoCOTVlBHMeyPqESAYCJp).GetEnumerator();
									cspUNRtcuVOejrkgFRbcxRWKWELJ = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							tXJFBcAXIZlhXapUzcIPqzPOdRbN++;
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

					private void NKxBMoHcCYJQZauBgPYbxpsZModmA()
					{
						cspUNRtcuVOejrkgFRbcxRWKWELJ = -1;
						if (wKFqERKMrFROyNPnZeVygffsfZI != null)
						{
							wKFqERKMrFROyNPnZeVygffsfZI.Dispose();
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
						IjZYoFYGFAMfcSDECNpNJrsKlEts<_0001> ijZYoFYGFAMfcSDECNpNJrsKlEts;
						if (cspUNRtcuVOejrkgFRbcxRWKWELJ == -2 && NyFSIXtgyrFpDCsPOOIrelAcQEgl == Environment.CurrentManagedThreadId)
						{
							cspUNRtcuVOejrkgFRbcxRWKWELJ = 0;
							ijZYoFYGFAMfcSDECNpNJrsKlEts = this;
						}
						else
						{
							ijZYoFYGFAMfcSDECNpNJrsKlEts = new IjZYoFYGFAMfcSDECNpNJrsKlEts<_0001>(0);
							ijZYoFYGFAMfcSDECNpNJrsKlEts.CSGBKEaqgHLRbDpkKimuJibAxvrvB = CSGBKEaqgHLRbDpkKimuJibAxvrvB;
						}
						ijZYoFYGFAMfcSDECNpNJrsKlEts.rhAciEEgXKJvSqYMPPOkwdHtmoESA = jWdqPvIqNuFLsapGoCNFtNUyxzvV;
						ijZYoFYGFAMfcSDECNpNJrsKlEts.VRbmSKbwoCOTVlBHMeyPqESAYCJp = IisAxouTUFgVkPOHWEojGoWWmQhu;
						ijZYoFYGFAMfcSDECNpNJrsKlEts.SGmdXLlauXLyKYMzIEGTmmzFLzGm = oGcmNAiHLnElmEnUHQnXwmmFIRrm;
						ijZYoFYGFAMfcSDECNpNJrsKlEts.APxQWLBeczZyifdQkdoiIbuWaNGY = hHmzUncfHvxPXSRdjiGXvfrldJSJA;
						return ijZYoFYGFAMfcSDECNpNJrsKlEts;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class HjyfvcyMEjtMqazgeKVndPykwPsw : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int FpPDiLJVxNdPkXeWRnSXVaDuOzqzA;

					private ElementAssignmentConflictInfo zKxlrPXTmVwxqaxnwIMnXECxjYtK;

					private int FabiBxVeahviKaidsJwFhcAETjGw;

					private int xDlCIObcLhqmhurClZKrMaRslENr;

					public int gPBkZKFBFUdakKdIRheJinivadZDb;

					private JoystickMap PwcpmrMhtTmzubPyfhfyakCLBDCE;

					public JoystickMap lpbfmrSHElPkrnFeKJKDCLAsjEBM;

					public ConflictCheckingHelper YAlKPhHSzMPIyPEjZRbPljQnTVvG;

					private bool wUIRZOvCptBHPLLIcDlcBZfnpUncA;

					public bool IJZfYreyZFxGtQTFoUpTmCWkNcju;

					private bool pchGGLjoSaJAzROfeTiSsCEzCQOR;

					public bool ZEIdSUgGCkHmsTurkrTjTkKirxuo;

					private int hfgKEZJujvvvyTRTRoKsAqNpZnsf;

					private IEnumerator<ElementAssignmentConflictInfo> mUakGsgMoUFjYfaNcTtvJCkFcEJib;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zKxlrPXTmVwxqaxnwIMnXECxjYtK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zKxlrPXTmVwxqaxnwIMnXECxjYtK;
						}
					}

					[DebuggerHidden]
					public HjyfvcyMEjtMqazgeKVndPykwPsw(int P_0)
					{
						FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = P_0;
						FabiBxVeahviKaidsJwFhcAETjGw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int fpPDiLJVxNdPkXeWRnSXVaDuOzqzA = FpPDiLJVxNdPkXeWRnSXVaDuOzqzA;
						if (fpPDiLJVxNdPkXeWRnSXVaDuOzqzA == -3 || fpPDiLJVxNdPkXeWRnSXVaDuOzqzA == 1)
						{
							try
							{
							}
							finally
							{
								USbCxZaqGRivIesrSoFcqgUcWGvuA();
							}
						}
						mUakGsgMoUFjYfaNcTtvJCkFcEJib = null;
						FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int fpPDiLJVxNdPkXeWRnSXVaDuOzqzA = FpPDiLJVxNdPkXeWRnSXVaDuOzqzA;
							ConflictCheckingHelper yAlKPhHSzMPIyPEjZRbPljQnTVvG = YAlKPhHSzMPIyPEjZRbPljQnTVvG;
							if (fpPDiLJVxNdPkXeWRnSXVaDuOzqzA != 0)
							{
								if (fpPDiLJVxNdPkXeWRnSXVaDuOzqzA != 1)
								{
									return false;
								}
								FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = -3;
								goto IL_00ea;
							}
							FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = -1;
							if (xDlCIObcLhqmhurClZKrMaRslENr < 0 || PwcpmrMhtTmzubPyfhfyakCLBDCE == null)
							{
								return false;
							}
							hfgKEZJujvvvyTRTRoKsAqNpZnsf = 0;
							goto IL_0116;
							IL_00ea:
							if (mUakGsgMoUFjYfaNcTtvJCkFcEJib.MoveNext())
							{
								ElementAssignmentConflictInfo current = mUakGsgMoUFjYfaNcTtvJCkFcEJib.Current;
								zKxlrPXTmVwxqaxnwIMnXECxjYtK = current;
								FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = 1;
								return true;
							}
							USbCxZaqGRivIesrSoFcqgUcWGvuA();
							mUakGsgMoUFjYfaNcTtvJCkFcEJib = null;
							goto IL_0104;
							IL_0116:
							if (hfgKEZJujvvvyTRTRoKsAqNpZnsf < yAlKPhHSzMPIyPEjZRbPljQnTVvG.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB())
							{
								if (yAlKPhHSzMPIyPEjZRbPljQnTVvG.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(hfgKEZJujvvvyTRTRoKsAqNpZnsf).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == xDlCIObcLhqmhurClZKrMaRslENr)
								{
									mUakGsgMoUFjYfaNcTtvJCkFcEJib = yAlKPhHSzMPIyPEjZRbPljQnTVvG.mXNrHdSIaZRQrWiOlPvLDMkavZDq(ControllerType.Joystick, xDlCIObcLhqmhurClZKrMaRslENr, PwcpmrMhtTmzubPyfhfyakCLBDCE, wUIRZOvCptBHPLLIcDlcBZfnpUncA, pchGGLjoSaJAzROfeTiSsCEzCQOR, yAlKPhHSzMPIyPEjZRbPljQnTVvG.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(hfgKEZJujvvvyTRTRoKsAqNpZnsf).ZZnBfQBoEAksLWJBlRShlDbbsdXd).GetEnumerator();
									FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							hfgKEZJujvvvyTRTRoKsAqNpZnsf++;
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

					private void USbCxZaqGRivIesrSoFcqgUcWGvuA()
					{
						FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = -1;
						if (mUakGsgMoUFjYfaNcTtvJCkFcEJib != null)
						{
							mUakGsgMoUFjYfaNcTtvJCkFcEJib.Dispose();
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
						HjyfvcyMEjtMqazgeKVndPykwPsw hjyfvcyMEjtMqazgeKVndPykwPsw;
						if (FpPDiLJVxNdPkXeWRnSXVaDuOzqzA == -2 && FabiBxVeahviKaidsJwFhcAETjGw == Environment.CurrentManagedThreadId)
						{
							FpPDiLJVxNdPkXeWRnSXVaDuOzqzA = 0;
							hjyfvcyMEjtMqazgeKVndPykwPsw = this;
						}
						else
						{
							hjyfvcyMEjtMqazgeKVndPykwPsw = new HjyfvcyMEjtMqazgeKVndPykwPsw(0);
							hjyfvcyMEjtMqazgeKVndPykwPsw.YAlKPhHSzMPIyPEjZRbPljQnTVvG = YAlKPhHSzMPIyPEjZRbPljQnTVvG;
						}
						hjyfvcyMEjtMqazgeKVndPykwPsw.xDlCIObcLhqmhurClZKrMaRslENr = gPBkZKFBFUdakKdIRheJinivadZDb;
						hjyfvcyMEjtMqazgeKVndPykwPsw.PwcpmrMhtTmzubPyfhfyakCLBDCE = lpbfmrSHElPkrnFeKJKDCLAsjEBM;
						hjyfvcyMEjtMqazgeKVndPykwPsw.wUIRZOvCptBHPLLIcDlcBZfnpUncA = IJZfYreyZFxGtQTFoUpTmCWkNcju;
						hjyfvcyMEjtMqazgeKVndPykwPsw.pchGGLjoSaJAzROfeTiSsCEzCQOR = ZEIdSUgGCkHmsTurkrTjTkKirxuo;
						return hjyfvcyMEjtMqazgeKVndPykwPsw;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class NyMSAdhOxJUnBnZHhspKiTwomusl : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int trdcxNzifLKXqRiWPPNnFkaRKOwi;

					private ElementAssignmentConflictInfo aOLYSQUWHkBayXCMCHfVKCTHTQBp;

					private int UcNqLExOVxpgANFMDDrFBETaXezx;

					private int wGSRJiprhFAyJlyMjDuMlcHRXZnp;

					public int MePeQxEJHEtdUpxOspzyuFotDSoiA;

					private ActionElementMap YQOmHjpkMcXtfujtTUhOwNUExJow;

					public ActionElementMap kvIstBzGCaxhqYyHKildCNOlhhiQ;

					public ConflictCheckingHelper lxgGUaGhugokuQiJaoHEmGMlkysHA;

					private JoystickMap ItBGqYFmbVPTmQyKHrITbjjQwAuP;

					public JoystickMap eTeBsDPviJPeDmKYtcRsnmhUbaor;

					private bool TumokUWOXkHLLXoqquNhNXJKPKOX;

					public bool ujtwduIkzOQAgnHIfGWRNaevNdkj;

					private bool lhbXDarlDLeCxhBFuRjGoySIagdK;

					public bool bvFcMmdGsnCYYBYhFaAuZnWxCFUEb;

					private int WbuvRujRfWZbkRbfbYzDCAXyCehk;

					private IEnumerator<ElementAssignmentConflictInfo> KPzCqjFOffnnyPKsHUWYDYcYcqjF;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aOLYSQUWHkBayXCMCHfVKCTHTQBp;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aOLYSQUWHkBayXCMCHfVKCTHTQBp;
						}
					}

					[DebuggerHidden]
					public NyMSAdhOxJUnBnZHhspKiTwomusl(int P_0)
					{
						trdcxNzifLKXqRiWPPNnFkaRKOwi = P_0;
						UcNqLExOVxpgANFMDDrFBETaXezx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = trdcxNzifLKXqRiWPPNnFkaRKOwi;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								GWjLJIkchjcjEMEurGtZaWVHNyoX();
							}
						}
						KPzCqjFOffnnyPKsHUWYDYcYcqjF = null;
						trdcxNzifLKXqRiWPPNnFkaRKOwi = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = trdcxNzifLKXqRiWPPNnFkaRKOwi;
							ConflictCheckingHelper conflictCheckingHelper = lxgGUaGhugokuQiJaoHEmGMlkysHA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								trdcxNzifLKXqRiWPPNnFkaRKOwi = -3;
								goto IL_00f0;
							}
							trdcxNzifLKXqRiWPPNnFkaRKOwi = -1;
							if (wGSRJiprhFAyJlyMjDuMlcHRXZnp < 0 || YQOmHjpkMcXtfujtTUhOwNUExJow == null)
							{
								return false;
							}
							WbuvRujRfWZbkRbfbYzDCAXyCehk = 0;
							goto IL_011c;
							IL_00f0:
							if (KPzCqjFOffnnyPKsHUWYDYcYcqjF.MoveNext())
							{
								ElementAssignmentConflictInfo current = KPzCqjFOffnnyPKsHUWYDYcYcqjF.Current;
								aOLYSQUWHkBayXCMCHfVKCTHTQBp = current;
								trdcxNzifLKXqRiWPPNnFkaRKOwi = 1;
								return true;
							}
							GWjLJIkchjcjEMEurGtZaWVHNyoX();
							KPzCqjFOffnnyPKsHUWYDYcYcqjF = null;
							goto IL_010a;
							IL_011c:
							if (WbuvRujRfWZbkRbfbYzDCAXyCehk < conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB())
							{
								if (conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(WbuvRujRfWZbkRbfbYzDCAXyCehk).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == wGSRJiprhFAyJlyMjDuMlcHRXZnp)
								{
									KPzCqjFOffnnyPKsHUWYDYcYcqjF = conflictCheckingHelper.SdKztNzZHycRMlYChiSJDAgaqHJB(ControllerType.Joystick, wGSRJiprhFAyJlyMjDuMlcHRXZnp, ItBGqYFmbVPTmQyKHrITbjjQwAuP, YQOmHjpkMcXtfujtTUhOwNUExJow, TumokUWOXkHLLXoqquNhNXJKPKOX, lhbXDarlDLeCxhBFuRjGoySIagdK, conflictCheckingHelper.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(WbuvRujRfWZbkRbfbYzDCAXyCehk).ZZnBfQBoEAksLWJBlRShlDbbsdXd).GetEnumerator();
									trdcxNzifLKXqRiWPPNnFkaRKOwi = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							WbuvRujRfWZbkRbfbYzDCAXyCehk++;
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

					private void GWjLJIkchjcjEMEurGtZaWVHNyoX()
					{
						trdcxNzifLKXqRiWPPNnFkaRKOwi = -1;
						if (KPzCqjFOffnnyPKsHUWYDYcYcqjF != null)
						{
							KPzCqjFOffnnyPKsHUWYDYcYcqjF.Dispose();
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
						NyMSAdhOxJUnBnZHhspKiTwomusl nyMSAdhOxJUnBnZHhspKiTwomusl;
						if (trdcxNzifLKXqRiWPPNnFkaRKOwi == -2 && UcNqLExOVxpgANFMDDrFBETaXezx == Environment.CurrentManagedThreadId)
						{
							trdcxNzifLKXqRiWPPNnFkaRKOwi = 0;
							nyMSAdhOxJUnBnZHhspKiTwomusl = this;
						}
						else
						{
							nyMSAdhOxJUnBnZHhspKiTwomusl = new NyMSAdhOxJUnBnZHhspKiTwomusl(0);
							nyMSAdhOxJUnBnZHhspKiTwomusl.lxgGUaGhugokuQiJaoHEmGMlkysHA = lxgGUaGhugokuQiJaoHEmGMlkysHA;
						}
						nyMSAdhOxJUnBnZHhspKiTwomusl.wGSRJiprhFAyJlyMjDuMlcHRXZnp = MePeQxEJHEtdUpxOspzyuFotDSoiA;
						nyMSAdhOxJUnBnZHhspKiTwomusl.ItBGqYFmbVPTmQyKHrITbjjQwAuP = eTeBsDPviJPeDmKYtcRsnmhUbaor;
						nyMSAdhOxJUnBnZHhspKiTwomusl.YQOmHjpkMcXtfujtTUhOwNUExJow = kvIstBzGCaxhqYyHKildCNOlhhiQ;
						nyMSAdhOxJUnBnZHhspKiTwomusl.TumokUWOXkHLLXoqquNhNXJKPKOX = ujtwduIkzOQAgnHIfGWRNaevNdkj;
						nyMSAdhOxJUnBnZHhspKiTwomusl.lhbXDarlDLeCxhBFuRjGoySIagdK = bvFcMmdGsnCYYBYhFaAuZnWxCFUEb;
						return nyMSAdhOxJUnBnZHhspKiTwomusl;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class KSsZrdlUBQdnQcpckzohsQxkuoaL : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int kIwFvNCQVzGsUWNrHxsGTLrLLqeYA;

					private ElementAssignmentConflictInfo hwWkfhZZRostwyHenUzrSGKpYTxC;

					private int YJopwREJRXvbSfSIStCQzcAhvdpT;

					private ElementAssignmentConflictCheck TqCKbUCJJjbgusxdnCbhLORTLPLX;

					public ElementAssignmentConflictCheck RAHeeqRhaospzrvInwYdVzxuJdOG;

					public ConflictCheckingHelper IxnGOQAvHtOtePYHEfwMfrFNmgWGb;

					private bool rfyaTJZtIbXPGvCAuCOyGcFhOZLn;

					public bool EHVqkPSMBLvIGYmSCgdBDweKbwJhA;

					private bool MhnyBLgpGqwgxwBKFeplYNXbYWyV;

					public bool LXoXczkYljFJRJBSJFYUxkOShfQy;

					private int GeyVLilQkmCsLzEGLzPlCfqZMazr;

					private IEnumerator<ElementAssignmentConflictInfo> FHqrMEQQkbMfVerTesBqZPsfajsz;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hwWkfhZZRostwyHenUzrSGKpYTxC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hwWkfhZZRostwyHenUzrSGKpYTxC;
						}
					}

					[DebuggerHidden]
					public KSsZrdlUBQdnQcpckzohsQxkuoaL(int P_0)
					{
						kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = P_0;
						YJopwREJRXvbSfSIStCQzcAhvdpT = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = kIwFvNCQVzGsUWNrHxsGTLrLLqeYA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								uUnrDmgqiYVxmwIjNLFfUoEkkPoX();
							}
						}
						FHqrMEQQkbMfVerTesBqZPsfajsz = null;
						kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = kIwFvNCQVzGsUWNrHxsGTLrLLqeYA;
							ConflictCheckingHelper ixnGOQAvHtOtePYHEfwMfrFNmgWGb = IxnGOQAvHtOtePYHEfwMfrFNmgWGb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = -3;
								goto IL_00f3;
							}
							kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = -1;
							if (TqCKbUCJJjbgusxdnCbhLORTLPLX.controllerId < 0 || TqCKbUCJJjbgusxdnCbhLORTLPLX.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							GeyVLilQkmCsLzEGLzPlCfqZMazr = 0;
							goto IL_011f;
							IL_00f3:
							if (FHqrMEQQkbMfVerTesBqZPsfajsz.MoveNext())
							{
								ElementAssignmentConflictInfo current = FHqrMEQQkbMfVerTesBqZPsfajsz.Current;
								hwWkfhZZRostwyHenUzrSGKpYTxC = current;
								kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = 1;
								return true;
							}
							uUnrDmgqiYVxmwIjNLFfUoEkkPoX();
							FHqrMEQQkbMfVerTesBqZPsfajsz = null;
							goto IL_010d;
							IL_011f:
							if (GeyVLilQkmCsLzEGLzPlCfqZMazr < ixnGOQAvHtOtePYHEfwMfrFNmgWGb.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB())
							{
								if (ixnGOQAvHtOtePYHEfwMfrFNmgWGb.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(GeyVLilQkmCsLzEGLzPlCfqZMazr).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == TqCKbUCJJjbgusxdnCbhLORTLPLX.controllerId)
								{
									FHqrMEQQkbMfVerTesBqZPsfajsz = ixnGOQAvHtOtePYHEfwMfrFNmgWGb.nWmEFwqqSNFLSDZZwcibfGnfEtxGb(TqCKbUCJJjbgusxdnCbhLORTLPLX, rfyaTJZtIbXPGvCAuCOyGcFhOZLn, MhnyBLgpGqwgxwBKFeplYNXbYWyV, ixnGOQAvHtOtePYHEfwMfrFNmgWGb.NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(GeyVLilQkmCsLzEGLzPlCfqZMazr).ZZnBfQBoEAksLWJBlRShlDbbsdXd).GetEnumerator();
									kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							GeyVLilQkmCsLzEGLzPlCfqZMazr++;
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

					private void uUnrDmgqiYVxmwIjNLFfUoEkkPoX()
					{
						kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = -1;
						if (FHqrMEQQkbMfVerTesBqZPsfajsz != null)
						{
							FHqrMEQQkbMfVerTesBqZPsfajsz.Dispose();
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
						KSsZrdlUBQdnQcpckzohsQxkuoaL kSsZrdlUBQdnQcpckzohsQxkuoaL;
						if (kIwFvNCQVzGsUWNrHxsGTLrLLqeYA == -2 && YJopwREJRXvbSfSIStCQzcAhvdpT == Environment.CurrentManagedThreadId)
						{
							kIwFvNCQVzGsUWNrHxsGTLrLLqeYA = 0;
							kSsZrdlUBQdnQcpckzohsQxkuoaL = this;
						}
						else
						{
							kSsZrdlUBQdnQcpckzohsQxkuoaL = new KSsZrdlUBQdnQcpckzohsQxkuoaL(0);
							kSsZrdlUBQdnQcpckzohsQxkuoaL.IxnGOQAvHtOtePYHEfwMfrFNmgWGb = IxnGOQAvHtOtePYHEfwMfrFNmgWGb;
						}
						kSsZrdlUBQdnQcpckzohsQxkuoaL.TqCKbUCJJjbgusxdnCbhLORTLPLX = RAHeeqRhaospzrvInwYdVzxuJdOG;
						kSsZrdlUBQdnQcpckzohsQxkuoaL.rfyaTJZtIbXPGvCAuCOyGcFhOZLn = EHVqkPSMBLvIGYmSCgdBDweKbwJhA;
						kSsZrdlUBQdnQcpckzohsQxkuoaL.MhnyBLgpGqwgxwBKFeplYNXbYWyV = LXoXczkYljFJRJBSJFYUxkOShfQy;
						return kSsZrdlUBQdnQcpckzohsQxkuoaL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player cPDEDRHxuzfcPPmupWHGPWNmnoOtA;

				private readonly ControllerHelper NRJCaXbABINlIIQnGaRTvskMPaxMb;

				private readonly int eTpwEQRGUlaLQGFRBHzDRGaQzZptA;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					eTpwEQRGUlaLQGFRBHzDRGaQzZptA = ReInput.id;
					cPDEDRHxuzfcPPmupWHGPWNmnoOtA = P_0;
					NRJCaXbABINlIIQnGaRTvskMPaxMb = P_1;
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => fmjgPhftScenBeJvMfRwfhfgWTKS(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => JgzlRLvgwOvRIeaFrOtaLVQuSLyS(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => NdYFFTFXdZOJhMfAWROGELnmQZcl(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => siZKUbvBeHGyUuYKTZjjCbqligQV(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => yCqCUmkZTeeXbqeKUJOubBCQDWjGA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => rgsWnvfqeZOTqcmUPCLNhgvThZFzA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => MIFpawRMAdelIrBcoBebEGSMpwyeb(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => EgKOrgxgEZlFBSgaLQGIplbZfrbcA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return RpNBsmGKkTBTYmnozMtuUoJdFpB(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return rbgkGUDuGHpadlsJSLjlUbdOjzcgA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ZnKlPAyfWtbUaekimQvoGlfAdwlBA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return zmqjtvRkgBAoCEEZRDPJImxnbYGSA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => wHyUiXuJnrVADtJeRlzbpZVAeJHo(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => kDUKJZNvJQtfNPygBJUWxsDrrfmu(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => cDJruFDHelqJVbTjXsGvgIXePWwD(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => jzNheSwUMeieMjXDctgLTiRiIiGg(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => HmfBImDPZiuicrflHjCbVEQuTObpA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => sidcRJLtsmwOblyYPOKrdqeiUMhK(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => NPUtExVqUffxvRkZKoWbiSLdUjjB(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => EMcZszLNZveiBfnXZKorSIsSOjOgA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return MbagEXbPbainrxATYHXNymoLcLru(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return SYRIkmMrVAxRYgcuXAtTAiYcVsYL(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return dGVcWygulcogeHzmWlCQZmedRjfq(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return JFmeUectYGcTyGANHZbLHMYqQgaib(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => HGkhckKcbipaWKQroQXENhBqFrYb(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => XkhDEReYxvyCFRqhHHCyCGpRjtOD(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => FRpWkxwXxLlfALmbtsCraOjzioJL(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => oWrRaJGJSrBDjtOjJwTdwOUxJaFq(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => LgYlMRVDIthCFUHTECwVCqHpiSAcb(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => iOCCDfyusNFEyvPXcmIIWyNcjXvu(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => sPoPRgYdCXHSWHcezQjOLXzJQwyr(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => FFCmkWAfyjpvgjHyfnFHPLrOqHzB(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return eJHBposQbgUqwkovtbNJWqGRJsir(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return mOpSWwgabOrqxVssKClcErUsKIPq(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return vfguHmLAYuIQIvDOIycjFkYyJEzB(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return ZHwqGIedTsgRBkIJoKxOfEEUtvQeA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => fwgmsUTBPgNHXKPNcpdIteripRpy(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => nmCeiWgpviIkniHpOfHVcHySACLS(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => aFRHgxdWBjoZwbrqdAsKwNZsgTkX(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => RJNYMkYkpmkmkViOhwOsmikgEJghA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => vtTxcYUaKWagTeFApEiBHwtbMYpJA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => gghyICTkVNHxNCWxrygJHADdjYgv(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ArFLyFfpIsbGGyoTWCJPgcZOqmss(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => mGrFTtIrUZNcFpHhxVgdsUkZNhHPA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != eTpwEQRGUlaLQGFRBHzDRGaQzZptA)
					{
						ReInput.CheckInitialized(eTpwEQRGUlaLQGFRBHzDRGaQzZptA);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return NmRWNuNniqOunYbYnJUOWyMBQElO(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ydxEDYbvekwxcJZVqcxtAnSFsgyWb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return OPecLVViwfaPxfvfSKGlpofWkiYFb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return EhpPObpSGxlBBqfJeMPnEcJNDoMb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool fmjgPhftScenBeJvMfRwfhfgWTKS(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0 && JAmUFLvyVzBpIaOOjDSAQFQDPfRD(ControllerType.Joystick, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd))
						{
							return true;
						}
					}
					return false;
				}

				private bool yCqCUmkZTeeXbqeKUJOubBCQDWjGA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0 && BhtEhJFujLVodhCYUvOfGdkTpraU(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd))
						{
							return true;
						}
					}
					return false;
				}

				private bool RpNBsmGKkTBTYmnozMtuUoJdFpB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0.controllerId && eUXyXKbWsZIScDfNbnntjnnaXxmf(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd))
						{
							return true;
						}
					}
					return false;
				}

				private bool JgzlRLvgwOvRIeaFrOtaLVQuSLyS(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return JAmUFLvyVzBpIaOOjDSAQFQDPfRD(ControllerType.Keyboard, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private bool rgsWnvfqeZOTqcmUPCLNhgvThZFzA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return BhtEhJFujLVodhCYUvOfGdkTpraU(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private bool rbgkGUDuGHpadlsJSLjlUbdOjzcgA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return eUXyXKbWsZIScDfNbnntjnnaXxmf(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private bool NdYFFTFXdZOJhMfAWROGELnmQZcl(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return JAmUFLvyVzBpIaOOjDSAQFQDPfRD(ControllerType.Mouse, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private bool MIFpawRMAdelIrBcoBebEGSMpwyeb(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return BhtEhJFujLVodhCYUvOfGdkTpraU(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private bool ZnKlPAyfWtbUaekimQvoGlfAdwlBA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return eUXyXKbWsZIScDfNbnntjnnaXxmf(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private bool siZKUbvBeHGyUuYKTZjjCbqligQV(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0 && JAmUFLvyVzBpIaOOjDSAQFQDPfRD(ControllerType.Custom, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd))
						{
							return true;
						}
					}
					return false;
				}

				private bool EgKOrgxgEZlFBSgaLQGIplbZfrbcA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0 && BhtEhJFujLVodhCYUvOfGdkTpraU(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd))
						{
							return true;
						}
					}
					return false;
				}

				private bool zmqjtvRkgBAoCEEZRDPJImxnbYGSA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0.controllerId && eUXyXKbWsZIScDfNbnntjnnaXxmf(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(HjyfvcyMEjtMqazgeKVndPykwPsw))]
				private IEnumerable<ElementAssignmentConflictInfo> wHyUiXuJnrVADtJeRlzbpZVAeJHo(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new HjyfvcyMEjtMqazgeKVndPykwPsw(-2)
					{
						YAlKPhHSzMPIyPEjZRbPljQnTVvG = this,
						gPBkZKFBFUdakKdIRheJinivadZDb = P_0,
						lpbfmrSHElPkrnFeKJKDCLAsjEBM = P_1,
						IJZfYreyZFxGtQTFoUpTmCWkNcju = P_2,
						ZEIdSUgGCkHmsTurkrTjTkKirxuo = P_3
					};
				}

				[IteratorStateMachine(typeof(NyMSAdhOxJUnBnZHhspKiTwomusl))]
				private IEnumerable<ElementAssignmentConflictInfo> HmfBImDPZiuicrflHjCbVEQuTObpA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new NyMSAdhOxJUnBnZHhspKiTwomusl(-2)
					{
						lxgGUaGhugokuQiJaoHEmGMlkysHA = this,
						MePeQxEJHEtdUpxOspzyuFotDSoiA = P_0,
						eTeBsDPviJPeDmKYtcRsnmhUbaor = P_1,
						kvIstBzGCaxhqYyHKildCNOlhhiQ = P_2,
						ujtwduIkzOQAgnHIfGWRNaevNdkj = P_3,
						bvFcMmdGsnCYYBYhFaAuZnWxCFUEb = P_4
					};
				}

				[IteratorStateMachine(typeof(KSsZrdlUBQdnQcpckzohsQxkuoaL))]
				private IEnumerable<ElementAssignmentConflictInfo> MbagEXbPbainrxATYHXNymoLcLru(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new KSsZrdlUBQdnQcpckzohsQxkuoaL(-2)
					{
						IxnGOQAvHtOtePYHEfwMfrFNmgWGb = this,
						RAHeeqRhaospzrvInwYdVzxuJdOG = P_0,
						EHVqkPSMBLvIGYmSCgdBDweKbwJhA = P_1,
						LXoXczkYljFJRJBSJFYUxkOShfQy = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> kDUKJZNvJQtfNPygBJUWxsDrrfmu(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return mXNrHdSIaZRQrWiOlPvLDMkavZDq(ControllerType.Keyboard, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private IEnumerable<ElementAssignmentConflictInfo> sidcRJLtsmwOblyYPOKrdqeiUMhK(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return SdKztNzZHycRMlYChiSJDAgaqHJB(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private IEnumerable<ElementAssignmentConflictInfo> SYRIkmMrVAxRYgcuXAtTAiYcVsYL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return nWmEFwqqSNFLSDZZwcibfGnfEtxGb(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private IEnumerable<ElementAssignmentConflictInfo> cDJruFDHelqJVbTjXsGvgIXePWwD(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return mXNrHdSIaZRQrWiOlPvLDMkavZDq(ControllerType.Mouse, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> NPUtExVqUffxvRkZKoWbiSLdUjjB(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return SdKztNzZHycRMlYChiSJDAgaqHJB(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> dGVcWygulcogeHzmWlCQZmedRjfq(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return nWmEFwqqSNFLSDZZwcibfGnfEtxGb(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				[IteratorStateMachine(typeof(pUlIkmEVBKSpcPnscAmcIyFsgqBdb))]
				private IEnumerable<ElementAssignmentConflictInfo> jzNheSwUMeieMjXDctgLTiRiIiGg(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new pUlIkmEVBKSpcPnscAmcIyFsgqBdb(-2)
					{
						LFcGVHxFFYaHTDUZhMtjEfTSxVwdA = this,
						PDIzcRXtkuivcyNcsfyLFzhNBnhpA = P_0,
						uhwGSTUqZySOaUybpwRHXHmgRMSN = P_1,
						QLLaklgEvJQxUPVoJJLbASqovCXJA = P_2,
						NWPDcQIJoRkzrymULVPYsKVMMvyn = P_3
					};
				}

				[IteratorStateMachine(typeof(tGlniXSkkauYsdZoXaCSGxmtUIjA))]
				private IEnumerable<ElementAssignmentConflictInfo> EMcZszLNZveiBfnXZKorSIsSOjOgA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new tGlniXSkkauYsdZoXaCSGxmtUIjA(-2)
					{
						gCIDpDaOObThioUmMMubpDaQPnqB = this,
						makjLReMLmQYusUsOOuDBxMSjnGE = P_0,
						HdHGYUbpVkcyZvmOiBJDDYsRqBdFA = P_1,
						NlmigxvwHBvrrPPhwqMJiWECtVsX = P_2,
						FtKbrDhMihOTBhhFdoKiqKzINIwQb = P_3,
						YniPUvoLbHZTBCfpQhoEviqJXwQd = P_4
					};
				}

				[IteratorStateMachine(typeof(nejgXgCNBiFGiiTGAgLgIyThXggGc))]
				private IEnumerable<ElementAssignmentConflictInfo> JFmeUectYGcTyGANHZbLHMYqQgaib(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new nejgXgCNBiFGiiTGAgLgIyThXggGc(-2)
					{
						bdaObFRDYDZbrvFpNbkTjgigcgMqA = this,
						MAaSFkvnUZDiBjbnodEcFFbjubIKB = P_0,
						UUQSVUyxkMaSFIlSNTNyALXNTGQT = P_1,
						HXAcaVEDxrVUOFJaVlDiIyXOYPsl = P_2
					};
				}

				private int HGkhckKcbipaWKQroQXENhBqFrYb(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += ZwUSHWZmpxECdmLThfLkkoGOidsDA(ControllerType.Joystick, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd);
						}
					}
					return num;
				}

				private int LgYlMRVDIthCFUHTECwVCqHpiSAcb(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += NsOMvzrnijyktBuOXbctvpXnYPQ(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd);
						}
					}
					return num;
				}

				private int eJHBposQbgUqwkovtbNJWqGRJsir(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0.controllerId)
						{
							num += eiXnNLzvaNxhROBcELHKFKHejLeL(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd);
						}
					}
					return num;
				}

				private int XkhDEReYxvyCFRqhHHCyCGpRjtOD(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return ZwUSHWZmpxECdmLThfLkkoGOidsDA(ControllerType.Keyboard, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private int iOCCDfyusNFEyvPXcmIIWyNcjXvu(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return NsOMvzrnijyktBuOXbctvpXnYPQ(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private int mOpSWwgabOrqxVssKClcErUsKIPq(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return eiXnNLzvaNxhROBcELHKFKHejLeL(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP);
				}

				private int FRpWkxwXxLlfALmbtsCraOjzioJL(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return ZwUSHWZmpxECdmLThfLkkoGOidsDA(ControllerType.Mouse, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private int sPoPRgYdCXHSWHcezQjOLXzJQwyr(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return NsOMvzrnijyktBuOXbctvpXnYPQ(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private int vfguHmLAYuIQIvDOIycjFkYyJEzB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return eiXnNLzvaNxhROBcELHKFKHejLeL(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA);
				}

				private int oWrRaJGJSrBDjtOjJwTdwOUxJaFq(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += ZwUSHWZmpxECdmLThfLkkoGOidsDA(ControllerType.Custom, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd);
						}
					}
					return num;
				}

				private int FFCmkWAfyjpvgjHyfnFHPLrOqHzB(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += NsOMvzrnijyktBuOXbctvpXnYPQ(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd);
						}
					}
					return num;
				}

				private int ZHwqGIedTsgRBkIJoKxOfEEUtvQeA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0.controllerId)
						{
							num += eiXnNLzvaNxhROBcELHKFKHejLeL(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd);
						}
					}
					return num;
				}

				private int fwgmsUTBPgNHXKPNcpdIteripRpy(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += fxrUSWmHqWGTCJaZihlafdUaVLGAc(ControllerType.Joystick, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd, P_4);
						}
					}
					return num;
				}

				private int vtTxcYUaKWagTeFApEiBHwtbMYpJA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += amlGiBtJEznRCJFIYPDTuqMxFEoKA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd, P_5);
						}
					}
					return num;
				}

				private int NmRWNuNniqOunYbYnJUOWyMBQElO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0.controllerId)
						{
							num += QHzxqgRENwtkPsbvhcTUiFqICYAy(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd, P_3);
						}
					}
					return num;
				}

				private int nmCeiWgpviIkniHpOfHVcHySACLS(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return fxrUSWmHqWGTCJaZihlafdUaVLGAc(ControllerType.Keyboard, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP, P_3);
				}

				private int gghyICTkVNHxNCWxrygJHADdjYgv(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return amlGiBtJEznRCJFIYPDTuqMxFEoKA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP, P_4);
				}

				private int ydxEDYbvekwxcJZVqcxtAnSFsgyWb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return QHzxqgRENwtkPsbvhcTUiFqICYAy(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.XDZJdplUohcdZWoKLNyfdyKeLgTP, P_3);
				}

				private int aFRHgxdWBjoZwbrqdAsKwNZsgTkX(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return fxrUSWmHqWGTCJaZihlafdUaVLGAc(ControllerType.Mouse, 0, P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA, P_3);
				}

				private int ArFLyFfpIsbGGyoTWCJPgcZOqmss(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return amlGiBtJEznRCJFIYPDTuqMxFEoKA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA, P_4);
				}

				private int OPecLVViwfaPxfvfSKGlpofWkiYFb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return QHzxqgRENwtkPsbvhcTUiFqICYAy(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.kYzyDbbcurDfceHgiahBYEaZTqFA, P_3);
				}

				private int RJNYMkYkpmkmkViOhwOsmikgEJghA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += fxrUSWmHqWGTCJaZihlafdUaVLGAc(ControllerType.Custom, P_0, P_1, P_2, P_3, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd, P_4);
						}
					}
					return num;
				}

				private int mGrFTtIrUZNcFpHhxVgdsUkZNhHPA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							num += amlGiBtJEznRCJFIYPDTuqMxFEoKA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd, P_5);
						}
					}
					return num;
				}

				private int EhpPObpSGxlBBqfJeMPnEcJNDoMb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.OlEGRykNhNKGseDKgLykUcpcZeJDB(); i++)
					{
						if (NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0.controllerId)
						{
							num += QHzxqgRENwtkPsbvhcTUiFqICYAy(P_0, P_1, P_2, NRJCaXbABINlIIQnGaRTvskMPaxMb.lUxGdkbYWtSnFlYjpNoPFLnfztjK.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i).ZZnBfQBoEAksLWJBlRShlDbbsdXd, P_3);
						}
					}
					return num;
				}

				private bool JAmUFLvyVzBpIaOOjDSAQFQDPfRD<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_5.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool BhtEhJFujLVodhCYUvOfGdkTpraU<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_6.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool eUXyXKbWsZIScDfNbnntjnnaXxmf<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_3.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(GTZYDPXycRSTMgoAJjEfvGBHnJbV))]
				private IEnumerable<ElementAssignmentConflictInfo> mXNrHdSIaZRQrWiOlPvLDMkavZDq<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_5) where _0001 : ControllerMap
				{
					return new GTZYDPXycRSTMgoAJjEfvGBHnJbV<_0001>(-2)
					{
						ckSsBDdwhaFjfxceEybXTudkGcRL = this,
						CZPZzsBsThAeORuyNKldMfxnKRsh = P_0,
						bbIpTIviiNYotwGknITWESaPncVwA = P_1,
						ktNRdwbJMXBxvBxgOtdrTYkWKTEbA = P_2,
						JNxWvQTCJUZdyoGeqqXsseUwAKpV = P_3,
						SdaZPSVEkKhvcoGBUByFAzFNFiay = P_4,
						HTfWPVNrlxpDaVoJNVlEIlFACjzJA = P_5
					};
				}

				[IteratorStateMachine(typeof(pnFUYxJLQtoIfjgeUDoAClAJJzFw))]
				private IEnumerable<ElementAssignmentConflictInfo> SdKztNzZHycRMlYChiSJDAgaqHJB<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_6) where _0001 : ControllerMap
				{
					return new pnFUYxJLQtoIfjgeUDoAClAJJzFw<_0001>(-2)
					{
						BOfWALebNRDpKDjKnCpGSDdAPfTjA = this,
						XAyOImNWnbRnrRpPHViHZZWuzcpk = P_0,
						LPBHaZsKeCdgKBfPbEhVCeJWaPalA = P_1,
						oLsbiaKImpZjWfvcMdYMYSDOazeU = P_2,
						cQcDHEzDMAFQBTmMcSqrVdqtLrIV = P_3,
						EGEoveNzidlGNMarRnUhBsvROWIR = P_4,
						xlLwmPGhRTpeMDVJpopxSRfiTMII = P_5,
						xPITOBzLChsyZYVzyTMYJRLzcEvl = P_6
					};
				}

				[IteratorStateMachine(typeof(IjZYoFYGFAMfcSDECNpNJrsKlEts))]
				private IEnumerable<ElementAssignmentConflictInfo> nWmEFwqqSNFLSDZZwcibfGnfEtxGb<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_3) where _0001 : ControllerMap
				{
					return new IjZYoFYGFAMfcSDECNpNJrsKlEts<_0001>(-2)
					{
						CSGBKEaqgHLRbDpkKimuJibAxvrvB = this,
						jWdqPvIqNuFLsapGoCNFtNUyxzvV = P_0,
						IisAxouTUFgVkPOHWEojGoWWmQhu = P_1,
						oGcmNAiHLnElmEnUHQnXwmmFIRrm = P_2,
						hHmzUncfHvxPXSRdjiGXvfrldJSJA = P_3
					};
				}

				private int ZwUSHWZmpxECdmLThfLkkoGOidsDA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_5.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int NsOMvzrnijyktBuOXbctvpXnYPQ<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_6.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int eiXnNLzvaNxhROBcELHKFKHejLeL<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_3.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int fxrUSWmHqWGTCJaZihlafdUaVLGAc<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_5.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(mapCategory, controllerMap)))
						{
							num += controllerMap.zeztsRkmbKBGcHGbkLmxixfnHyMA(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int amlGiBtJEznRCJFIYPDTuqMxFEoKA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_6.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.xARvIziAnsCgxrFCUVjIgaMtFsaHA(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int QHzxqgRENwtkPsbvhcTUiFqICYAy<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.BnLfdLdejZPchYBMOscGuqKWagU(); i++)
					{
						ControllerMap controllerMap = P_3.QctWoySrGTZJSArZHyJFYsCcnKlK(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !QGpEhRYeXhnXcdAvDPhtMPsahqIc(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RijTjPgqOiHkBmeJciVrzMTgrgKF(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool QGpEhRYeXhnXcdAvDPhtMPsahqIc(InputMapCategory P_0, ControllerMap P_1)
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
			internal interface oqyCGPauVpdeCYocXRLbgQLkEJqSb
			{
				rhYdZBfPeTRSAgWthmAnYqtbiubLA pgyvgDTbYJhTYoYSzNZlJqxvRNVQ { get; }

				ControllerType VNMWmvmTyINKrZrRDngTDyNxkgou { get; }

				int yqhlCDSAeeNknWUrdPHIJVxJgUrb { get; }

				bool ZLjLPSeueYicDimMrHzsLzGSGxmL(Controller P_0);

				bool TppoEOtwrQsjeHgBuhTqETedUKXv(int P_0);

				void sHXmrmxafdDTEfbGteIHKDUZalPUA(int P_0);

				void dmJuCwhIAcvJgfRlqmYDaofjvZZI(Controller P_0);

				void BVtvvXJSUrkeWvnblchyxjLwafdeA(int P_0);

				Controller yoMbXcrAnMFCsmsnfsFTRCTxgrNq(int P_0);

				Controller pQZeuXnOJNMraNudmbPNbnNdDWfi(string P_0);

				int NggDUbirTGqDVbYXnjPoihCfgfkCb(Controller P_0);

				int qtobEIFmvZfFrfjFmUGnNGjVuSxuA(int P_0);

				int OkwAdFpNlwEyQAiGGoCXhzBsDtMtA(string P_0);

				void djoFrUBAnDwBpvguRjmklfNcJFJs();

				rhYdZBfPeTRSAgWthmAnYqtbiubLA xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(int P_0);

				rhYdZBfPeTRSAgWthmAnYqtbiubLA YtFeKfEkAmOQogEaQlNHkzuLDejT(Controller P_0);

				void FWRYswoIAsiqrxIUfggdsRmvUjsv(rhYdZBfPeTRSAgWthmAnYqtbiubLA P_0);
			}

			internal interface rhYdZBfPeTRSAgWthmAnYqtbiubLA
			{
				wfTqPVowqyEtwvBJoegCIMAGtbtoA ZVqQCpBpHaJoxANGetaJnsjmlMojA { get; }

				Controller UCMOBjKhfpoECrfBzBtZepnlTjUc { get; }

				double LsrdLSuplQGcDIuPafGpkCGZDCoe { get; }
			}

			[DefaultMember("Item")]
			internal sealed class kiJAeGTUDdTpPSkOAFpElaZegNnkA<_0001, _0002> : oqyCGPauVpdeCYocXRLbgQLkEJqSb where _0001 : Controller where _0002 : ControllerMap
			{
				public class xNKZnmZDWSpEQNETiUDuIefVGQwY : rhYdZBfPeTRSAgWthmAnYqtbiubLA
				{
					public _0001 OGKSTOLCyntwnzWvSpSVBzuxFIIC;

					public global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0002> ZZnBfQBoEAksLWJBlRShlDbbsdXd;

					public double ChmzvzuyIQcMsclCHrFLxmdAQNWC;

					Controller rhYdZBfPeTRSAgWthmAnYqtbiubLA.CUszycWOLlGgvtdVFumXGjnoQmii => OGKSTOLCyntwnzWvSpSVBzuxFIIC;

					wfTqPVowqyEtwvBJoegCIMAGtbtoA rhYdZBfPeTRSAgWthmAnYqtbiubLA.TWjNZDMbUduxPrmfVwlwJpJXBQHs => ZZnBfQBoEAksLWJBlRShlDbbsdXd;

					double rhYdZBfPeTRSAgWthmAnYqtbiubLA.TkLWujEDIUDicDiNyuOKaVzqLTMsA => ChmzvzuyIQcMsclCHrFLxmdAQNWC;

					public xNKZnmZDWSpEQNETiUDuIefVGQwY(_0001 P_0, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0002> P_1)
					{
						OGKSTOLCyntwnzWvSpSVBzuxFIIC = P_0;
						ZZnBfQBoEAksLWJBlRShlDbbsdXd = P_1;
					}

					public void bBZgHHlMPcCfOdIlwbCkZgETpsze()
					{
						ChmzvzuyIQcMsclCHrFLxmdAQNWC = ReInput.unscaledTime;
					}
				}

				private List<xNKZnmZDWSpEQNETiUDuIefVGQwY> rsTFvFfuRSpvpcYOmTjnMByywXps;

				private List<_0001> LRDfaEUoBJMrWenboDUeZQfRjpDc;

				private ReadOnlyCollection<_0001> FNsfaxTVQvGlMJJmzGaslDEKTxCw;

				private readonly ControllerType gjMEuTkxvgXApNqPSBwOYCnjKYeU;

				int oqyCGPauVpdeCYocXRLbgQLkEJqSb.yqhlCDSAeeNknWUrdPHIJVxJgUrb => rsTFvFfuRSpvpcYOmTjnMByywXps.Count;

				public IList<_0001> UZcAPMUGUwfkiXcIAXBceGyLvShu => FNsfaxTVQvGlMJJmzGaslDEKTxCw;

				public xNKZnmZDWSpEQNETiUDuIefVGQwY eufUjCJXkIFWIkvNGGWmaupQSGFo => rsTFvFfuRSpvpcYOmTjnMByywXps[P_0];

				ControllerType oqyCGPauVpdeCYocXRLbgQLkEJqSb.VNMWmvmTyINKrZrRDngTDyNxkgou => gjMEuTkxvgXApNqPSBwOYCnjKYeU;

				rhYdZBfPeTRSAgWthmAnYqtbiubLA oqyCGPauVpdeCYocXRLbgQLkEJqSb.gKEJVslJxvvWosbYxVyfWPJlIwFq => rsTFvFfuRSpvpcYOmTjnMByywXps[index];

				public kiJAeGTUDdTpPSkOAFpElaZegNnkA()
				{
					if ((object)bVcNkmaJvbHeBNQRpaleQvWHeXqv.XgRfAyDRPYKrLGTzzHBfbpPjgWDj<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					gjMEuTkxvgXApNqPSBwOYCnjKYeU = bVcNkmaJvbHeBNQRpaleQvWHeXqv.OnLYJboGGeZFMLKwCBymIGxZgjpHA(typeof(_0001));
					rsTFvFfuRSpvpcYOmTjnMByywXps = new List<xNKZnmZDWSpEQNETiUDuIefVGQwY>();
					LRDfaEUoBJMrWenboDUeZQfRjpDc = new List<_0001>();
					FNsfaxTVQvGlMJJmzGaslDEKTxCw = new ReadOnlyCollection<_0001>(LRDfaEUoBJMrWenboDUeZQfRjpDc);
				}

				public xNKZnmZDWSpEQNETiUDuIefVGQwY iJMGcrJvuhnTHNIRqyJVpOiCTMQB(int P_0)
				{
					if (gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Keyboard || gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iyEdQWSwfNhxyLqrzPUZiBkLgbaf(P_0);
					if (num < 0)
					{
						return null;
					}
					return rsTFvFfuRSpvpcYOmTjnMByywXps[num];
				}

				public xNKZnmZDWSpEQNETiUDuIefVGQwY WBELnbEPRzfaoLMcAnapGqfWNckR(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return iJMGcrJvuhnTHNIRqyJVpOiCTMQB(P_0.id);
				}

				public void OEkNrzRGDbzeuGejyEsmfDDudoEhA(xNKZnmZDWSpEQNETiUDuIefVGQwY P_0)
				{
					if (P_0 != null)
					{
						rsTFvFfuRSpvpcYOmTjnMByywXps.Add(P_0);
						LRDfaEUoBJMrWenboDUeZQfRjpDc.Add(P_0.OGKSTOLCyntwnzWvSpSVBzuxFIIC);
					}
				}

				public void UkBSAsACrKLaMUEpDgucGYyCUGrwA(int P_0)
				{
					if (gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Keyboard || gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (iyEdQWSwfNhxyLqrzPUZiBkLgbaf(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < rsTFvFfuRSpvpcYOmTjnMByywXps.Count; i++)
					{
						if (rsTFvFfuRSpvpcYOmTjnMByywXps[i].OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							hcfEthVRdzCdASMZhyfRjGEhYtQv(i);
							break;
						}
					}
				}

				void oqyCGPauVpdeCYocXRLbgQLkEJqSb.sHXmrmxafdDTEfbGteIHKDUZalPUA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in UkBSAsACrKLaMUEpDgucGYyCUGrwA
					this.UkBSAsACrKLaMUEpDgucGYyCUGrwA(P_0);
				}

				public void PisXrTkFIQZtaWrbofmEACwZsezIA(_0001 P_0)
				{
					if (P_0 != null && P_0.type == gjMEuTkxvgXApNqPSBwOYCnjKYeU)
					{
						UkBSAsACrKLaMUEpDgucGYyCUGrwA(P_0.id);
					}
				}

				public void hcfEthVRdzCdASMZhyfRjGEhYtQv(int P_0)
				{
					if (P_0 >= 0 && P_0 < rsTFvFfuRSpvpcYOmTjnMByywXps.Count)
					{
						rsTFvFfuRSpvpcYOmTjnMByywXps.RemoveAt(P_0);
						LRDfaEUoBJMrWenboDUeZQfRjpDc.RemoveAt(P_0);
					}
				}

				void oqyCGPauVpdeCYocXRLbgQLkEJqSb.BVtvvXJSUrkeWvnblchyxjLwafdeA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in hcfEthVRdzCdASMZhyfRjGEhYtQv
					this.hcfEthVRdzCdASMZhyfRjGEhYtQv(P_0);
				}

				public _0001 xDIVdsRoUWOYzrpExtspKIKqOwIe(int P_0)
				{
					if (gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Keyboard || gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iyEdQWSwfNhxyLqrzPUZiBkLgbaf(P_0);
					if (num < 0)
					{
						return null;
					}
					return rsTFvFfuRSpvpcYOmTjnMByywXps[num].OGKSTOLCyntwnzWvSpSVBzuxFIIC;
				}

				public bool ULfuloXPWvEeLFdEufiPAqWSEImOA(int P_0)
				{
					if (gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Keyboard || gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < rsTFvFfuRSpvpcYOmTjnMByywXps.Count; i++)
					{
						if (rsTFvFfuRSpvpcYOmTjnMByywXps[i].OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool oqyCGPauVpdeCYocXRLbgQLkEJqSb.TppoEOtwrQsjeHgBuhTqETedUKXv(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in ULfuloXPWvEeLFdEufiPAqWSEImOA
					return this.ULfuloXPWvEeLFdEufiPAqWSEImOA(P_0);
				}

				public bool oiGtplYatPFdtCyoVphXYqwDmcbK(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != gjMEuTkxvgXApNqPSBwOYCnjKYeU)
					{
						return false;
					}
					return ULfuloXPWvEeLFdEufiPAqWSEImOA(P_0.id);
				}

				public int iyEdQWSwfNhxyLqrzPUZiBkLgbaf(int P_0)
				{
					if (gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Keyboard || gjMEuTkxvgXApNqPSBwOYCnjKYeU == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < rsTFvFfuRSpvpcYOmTjnMByywXps.Count; i++)
					{
						if (rsTFvFfuRSpvpcYOmTjnMByywXps[i].OGKSTOLCyntwnzWvSpSVBzuxFIIC.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int oqyCGPauVpdeCYocXRLbgQLkEJqSb.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in iyEdQWSwfNhxyLqrzPUZiBkLgbaf
					return this.iyEdQWSwfNhxyLqrzPUZiBkLgbaf(P_0);
				}

				public int MjzqDUBzYaDnHfhHmjrproptYGqy(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != gjMEuTkxvgXApNqPSBwOYCnjKYeU)
					{
						return -1;
					}
					return iyEdQWSwfNhxyLqrzPUZiBkLgbaf(P_0.id);
				}

				public int BGHeSfAzkCtsrpnvZscDsetfmIOvA(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < rsTFvFfuRSpvpcYOmTjnMByywXps.Count; i++)
					{
						if (rsTFvFfuRSpvpcYOmTjnMByywXps[i].OGKSTOLCyntwnzWvSpSVBzuxFIIC.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int oqyCGPauVpdeCYocXRLbgQLkEJqSb.OkwAdFpNlwEyQAiGGoCXhzBsDtMtA(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in BGHeSfAzkCtsrpnvZscDsetfmIOvA
					return this.BGHeSfAzkCtsrpnvZscDsetfmIOvA(P_0);
				}

				public void SCmzRWsRiGPzVuiugtEsJjGRWRuu()
				{
					rsTFvFfuRSpvpcYOmTjnMByywXps.Clear();
					LRDfaEUoBJMrWenboDUeZQfRjpDc.Clear();
				}

				void oqyCGPauVpdeCYocXRLbgQLkEJqSb.djoFrUBAnDwBpvguRjmklfNcJFJs()
				{
					//ILSpy generated this explicit interface implementation from .override directive in SCmzRWsRiGPzVuiugtEsJjGRWRuu
					this.SCmzRWsRiGPzVuiugtEsJjGRWRuu();
				}

				rhYdZBfPeTRSAgWthmAnYqtbiubLA oqyCGPauVpdeCYocXRLbgQLkEJqSb.GetEntry(int controllerId)
				{
					return iJMGcrJvuhnTHNIRqyJVpOiCTMQB(controllerId);
				}

				rhYdZBfPeTRSAgWthmAnYqtbiubLA oqyCGPauVpdeCYocXRLbgQLkEJqSb.GetEntry(Controller controller)
				{
					if (controller as _0001 == null)
					{
						return null;
					}
					return WBELnbEPRzfaoLMcAnapGqfWNckR(controller as _0001);
				}

				void oqyCGPauVpdeCYocXRLbgQLkEJqSb.AddEntry(rhYdZBfPeTRSAgWthmAnYqtbiubLA entry)
				{
					OEkNrzRGDbzeuGejyEsmfDDudoEhA((xNKZnmZDWSpEQNETiUDuIefVGQwY)entry);
				}

				void oqyCGPauVpdeCYocXRLbgQLkEJqSb.RemoveController(Controller controller)
				{
					PisXrTkFIQZtaWrbofmEACwZsezIA(controller as _0001);
				}

				Controller oqyCGPauVpdeCYocXRLbgQLkEJqSb.GetController(int controllerId)
				{
					return xDIVdsRoUWOYzrpExtspKIKqOwIe(controllerId);
				}

				bool oqyCGPauVpdeCYocXRLbgQLkEJqSb.Contains(Controller controller)
				{
					return oiGtplYatPFdtCyoVphXYqwDmcbK(controller as _0001);
				}

				int oqyCGPauVpdeCYocXRLbgQLkEJqSb.IndexOf(Controller controller)
				{
					return MjzqDUBzYaDnHfhHmjrproptYGqy(controller as _0001);
				}

				Controller oqyCGPauVpdeCYocXRLbgQLkEJqSb.GetControllerWithTag(string tag)
				{
					int num = BGHeSfAzkCtsrpnvZscDsetfmIOvA(tag);
					if (num < 0)
					{
						return null;
					}
					return rsTFvFfuRSpvpcYOmTjnMByywXps[num].OGKSTOLCyntwnzWvSpSVBzuxFIIC;
				}
			}

			internal class yTppLmdkPEkruVlzDxplVYNljUCq
			{
				public readonly int nnvlqoAEVkrjBxsIuTjXaJmrTSFG;

				private ControllerType[] HUbDIWCGFrzGAQMTutyUEoXVfofoA;

				private oqyCGPauVpdeCYocXRLbgQLkEJqSb[] UZCyhRENBmBJkfFGZGpTtjnpGxKGb;

				public oqyCGPauVpdeCYocXRLbgQLkEJqSb feNNrANNfBoPvvOtNuHmGhPiUhWG(int P_0)
				{
					return UZCyhRENBmBJkfFGZGpTtjnpGxKGb[P_0];
				}

				public ControllerType awyYJXzOuOzOwNueelCIhHaLlOCp(int P_0)
				{
					return HUbDIWCGFrzGAQMTutyUEoXVfofoA[P_0];
				}

				public yTppLmdkPEkruVlzDxplVYNljUCq(int P_0)
				{
					nnvlqoAEVkrjBxsIuTjXaJmrTSFG = MathTools.Max(0, P_0);
					HUbDIWCGFrzGAQMTutyUEoXVfofoA = new ControllerType[P_0];
					UZCyhRENBmBJkfFGZGpTtjnpGxKGb = new oqyCGPauVpdeCYocXRLbgQLkEJqSb[P_0];
				}

				public oqyCGPauVpdeCYocXRLbgQLkEJqSb nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType P_0)
				{
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						if (P_0 == HUbDIWCGFrzGAQMTutyUEoXVfofoA[i])
						{
							return UZCyhRENBmBJkfFGZGpTtjnpGxKGb[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void BohQSFQnBIthgDfCAITBiTnLbPSAA(int P_0, ControllerType P_1, oqyCGPauVpdeCYocXRLbgQLkEJqSb P_2)
				{
					HUbDIWCGFrzGAQMTutyUEoXVfofoA[P_0] = P_1;
					UZCyhRENBmBJkfFGZGpTtjnpGxKGb[P_0] = P_2;
				}
			}

			private class hMEdODXgCmwsxlgvcleZEdSDNowO
			{
				public class ZCPnOoKMzyRodRdbHvtEHhzADZTx
				{
					public int hoGpJHSYecXRqsDmxScLPawAEWmP;

					public global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> YrKAVQboSIQQXeSJDYCLyPsyBiWH;

					public double xkyyWcdRkDWAmhkEUBpUgtzVHltfA;

					public ZCPnOoKMzyRodRdbHvtEHhzADZTx(int P_0, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> P_1, double P_2)
					{
						hoGpJHSYecXRqsDmxScLPawAEWmP = P_0;
						YrKAVQboSIQQXeSJDYCLyPsyBiWH = P_1;
						xkyyWcdRkDWAmhkEUBpUgtzVHltfA = P_2;
					}
				}

				private readonly List<ZCPnOoKMzyRodRdbHvtEHhzADZTx> kspHKFdDnYfzgfZaZoBDtABkfEKX;

				private readonly Player LTLFpqLHrpNSktsKeXUQzyRBeMiK;

				public hMEdODXgCmwsxlgvcleZEdSDNowO(Player P_0)
				{
					LTLFpqLHrpNSktsKeXUQzyRBeMiK = P_0;
					kspHKFdDnYfzgfZaZoBDtABkfEKX = new List<ZCPnOoKMzyRodRdbHvtEHhzADZTx>();
				}

				public void XvkEqHbEHivdYDtmiMimzmhuwpHF(Joystick P_0, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> P_1)
				{
					for (int i = 0; i < kspHKFdDnYfzgfZaZoBDtABkfEKX.Count; i++)
					{
						ZCPnOoKMzyRodRdbHvtEHhzADZTx zCPnOoKMzyRodRdbHvtEHhzADZTx = kspHKFdDnYfzgfZaZoBDtABkfEKX[i];
						if (zCPnOoKMzyRodRdbHvtEHhzADZTx.hoGpJHSYecXRqsDmxScLPawAEWmP == P_0.id)
						{
							zCPnOoKMzyRodRdbHvtEHhzADZTx.YrKAVQboSIQQXeSJDYCLyPsyBiWH = P_1;
							zCPnOoKMzyRodRdbHvtEHhzADZTx.xkyyWcdRkDWAmhkEUBpUgtzVHltfA = ReInput.realTime;
							return;
						}
					}
					ZCPnOoKMzyRodRdbHvtEHhzADZTx item = new ZCPnOoKMzyRodRdbHvtEHhzADZTx(P_0.id, P_1, ReInput.realTime);
					kspHKFdDnYfzgfZaZoBDtABkfEKX.Add(item);
				}

				public void PpLGmxhxQKcSjmfZEMLEhelNMwJE(kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY P_0)
				{
					XvkEqHbEHivdYDtmiMimzmhuwpHF(P_0.OGKSTOLCyntwnzWvSpSVBzuxFIIC, P_0.ZZnBfQBoEAksLWJBlRShlDbbsdXd);
				}

				public void VoPocBoXXMaHsmmpJFDBIEjJvFYWA()
				{
					for (int i = 0; i < kspHKFdDnYfzgfZaZoBDtABkfEKX.Count; i++)
					{
						if (!LTLFpqLHrpNSktsKeXUQzyRBeMiK.controllers.ContainsController(ControllerType.Joystick, kspHKFdDnYfzgfZaZoBDtABkfEKX[i].hoGpJHSYecXRqsDmxScLPawAEWmP))
						{
							kspHKFdDnYfzgfZaZoBDtABkfEKX[i].YrKAVQboSIQQXeSJDYCLyPsyBiWH = null;
						}
					}
				}

				public ZCPnOoKMzyRodRdbHvtEHhzADZTx ERjAZxdKopfEKWpJlqEQgkgqZkoKA(int P_0)
				{
					int num = VVxqRLOBVnLEakaKPohNxeAferFZ(P_0);
					if (num < 0)
					{
						return null;
					}
					return kspHKFdDnYfzgfZaZoBDtABkfEKX[num];
				}

				public bool wZAHuYRKYNiHpEjSMUDvXdvEPSPq(int P_0)
				{
					for (int i = 0; i < kspHKFdDnYfzgfZaZoBDtABkfEKX.Count; i++)
					{
						if (kspHKFdDnYfzgfZaZoBDtABkfEKX[i].hoGpJHSYecXRqsDmxScLPawAEWmP == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int VVxqRLOBVnLEakaKPohNxeAferFZ(int P_0)
				{
					for (int i = 0; i < kspHKFdDnYfzgfZaZoBDtABkfEKX.Count; i++)
					{
						if (kspHKFdDnYfzgfZaZoBDtABkfEKX[i].hoGpJHSYecXRqsDmxScLPawAEWmP == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void BThvpMunOzRYWCIPfUaKnwuTkvBn()
				{
					kspHKFdDnYfzgfZaZoBDtABkfEKX.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class GffqwonREDFalbUIQuacemaHqfpV : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int dsARpwSrZiIptIpNJIkyoWVRqKVM;

					private ActionElementMap JKCgDgLGZwfJomvGRaZMImrfsFgi;

					private int CWuZjFxAwKqmoCCDcDVEWmOyLOms;

					public MapHelper YTVtbQPbKqyBVrDNecfgqIQFWpVU;

					private int KIwIZHAWcVsPalrBtjLPAdvMhgah;

					public int iXbICZNBtxhiPpQNEvvoSPTPuuKK;

					private bool qoKQVehSVwBeXvnsNERatJsfGbCx;

					public bool QUYDwiclRlKYjybwNMQmcsWavDNI;

					private int ywsDLqmFBQnBbgLLXlyBhCEDzwUO;

					private int vCSGtGtDaTBURDyJRSWkrEDMoFVpA;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb NrdJbtKSrIBIdAMlZhWZRqkBRBqO;

					private int SdEnKEdFrKQJBayKhbGkCrftGFIU;

					private int amgkjZqJnIIoGfSbEbtMoXXnDUibA;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA cbhwFtrlkYXmrPxCEEswVOYHnDt;

					private int EQCmLXvjXKSaLBxCuHZNYdGzpBqP;

					private int OLgSFlQCGfrpTGeMcMRLmzDGGiho;

					private IEnumerator<ActionElementMap> HylIqJkNZyFtOUPvpcofsRXufHqu;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return JKCgDgLGZwfJomvGRaZMImrfsFgi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JKCgDgLGZwfJomvGRaZMImrfsFgi;
						}
					}

					[DebuggerHidden]
					public GffqwonREDFalbUIQuacemaHqfpV(int P_0)
					{
						dsARpwSrZiIptIpNJIkyoWVRqKVM = P_0;
						CWuZjFxAwKqmoCCDcDVEWmOyLOms = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dsARpwSrZiIptIpNJIkyoWVRqKVM;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								wOYyfTnYSVCRDYSKFeSDQSVoVKvB();
							}
						}
						NrdJbtKSrIBIdAMlZhWZRqkBRBqO = null;
						cbhwFtrlkYXmrPxCEEswVOYHnDt = null;
						HylIqJkNZyFtOUPvpcofsRXufHqu = null;
						dsARpwSrZiIptIpNJIkyoWVRqKVM = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = dsARpwSrZiIptIpNJIkyoWVRqKVM;
							MapHelper yTVtbQPbKqyBVrDNecfgqIQFWpVU = YTVtbQPbKqyBVrDNecfgqIQFWpVU;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dsARpwSrZiIptIpNJIkyoWVRqKVM = -3;
								goto IL_0177;
							}
							dsARpwSrZiIptIpNJIkyoWVRqKVM = -1;
							if (ReInput._id != yTVtbQPbKqyBVrDNecfgqIQFWpVU.JUxUMkAhrDjRItbYUWjYRNgFpzir)
							{
								ReInput.CheckInitialized(yTVtbQPbKqyBVrDNecfgqIQFWpVU.JUxUMkAhrDjRItbYUWjYRNgFpzir);
								return false;
							}
							if (KIwIZHAWcVsPalrBtjLPAdvMhgah < 0)
							{
								return false;
							}
							ywsDLqmFBQnBbgLLXlyBhCEDzwUO = yTVtbQPbKqyBVrDNecfgqIQFWpVU.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
							vCSGtGtDaTBURDyJRSWkrEDMoFVpA = 0;
							goto IL_01f7;
							IL_0177:
							if (HylIqJkNZyFtOUPvpcofsRXufHqu.MoveNext())
							{
								ActionElementMap current = HylIqJkNZyFtOUPvpcofsRXufHqu.Current;
								JKCgDgLGZwfJomvGRaZMImrfsFgi = current;
								dsARpwSrZiIptIpNJIkyoWVRqKVM = 1;
								return true;
							}
							wOYyfTnYSVCRDYSKFeSDQSVoVKvB();
							HylIqJkNZyFtOUPvpcofsRXufHqu = null;
							goto IL_0191;
							IL_0191:
							OLgSFlQCGfrpTGeMcMRLmzDGGiho++;
							goto IL_01a3;
							IL_01cd:
							if (amgkjZqJnIIoGfSbEbtMoXXnDUibA < SdEnKEdFrKQJBayKhbGkCrftGFIU)
							{
								cbhwFtrlkYXmrPxCEEswVOYHnDt = NrdJbtKSrIBIdAMlZhWZRqkBRBqO.LNTBMmjuONFUBLurbFbXivzHrdyGb(amgkjZqJnIIoGfSbEbtMoXXnDUibA).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								EQCmLXvjXKSaLBxCuHZNYdGzpBqP = cbhwFtrlkYXmrPxCEEswVOYHnDt.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								OLgSFlQCGfrpTGeMcMRLmzDGGiho = 0;
								goto IL_01a3;
							}
							NrdJbtKSrIBIdAMlZhWZRqkBRBqO = null;
							vCSGtGtDaTBURDyJRSWkrEDMoFVpA++;
							goto IL_01f7;
							IL_01a3:
							if (OLgSFlQCGfrpTGeMcMRLmzDGGiho < EQCmLXvjXKSaLBxCuHZNYdGzpBqP)
							{
								if (cbhwFtrlkYXmrPxCEEswVOYHnDt.tMPEVPdgqovMveUHOiirPevVOylqA(OLgSFlQCGfrpTGeMcMRLmzDGGiho) is ControllerMapWithAxes controllerMapWithAxes && (!qoKQVehSVwBeXvnsNERatJsfGbCx || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(KIwIZHAWcVsPalrBtjLPAdvMhgah))
								{
									HylIqJkNZyFtOUPvpcofsRXufHqu = controllerMapWithAxes.AxisMapsWithAction(KIwIZHAWcVsPalrBtjLPAdvMhgah, qoKQVehSVwBeXvnsNERatJsfGbCx).GetEnumerator();
									dsARpwSrZiIptIpNJIkyoWVRqKVM = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							cbhwFtrlkYXmrPxCEEswVOYHnDt = null;
							amgkjZqJnIIoGfSbEbtMoXXnDUibA++;
							goto IL_01cd;
							IL_01f7:
							if (vCSGtGtDaTBURDyJRSWkrEDMoFVpA < ywsDLqmFBQnBbgLLXlyBhCEDzwUO)
							{
								NrdJbtKSrIBIdAMlZhWZRqkBRBqO = yTVtbQPbKqyBVrDNecfgqIQFWpVU.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(vCSGtGtDaTBURDyJRSWkrEDMoFVpA);
								SdEnKEdFrKQJBayKhbGkCrftGFIU = NrdJbtKSrIBIdAMlZhWZRqkBRBqO.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
								amgkjZqJnIIoGfSbEbtMoXXnDUibA = 0;
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

					private void wOYyfTnYSVCRDYSKFeSDQSVoVKvB()
					{
						dsARpwSrZiIptIpNJIkyoWVRqKVM = -1;
						if (HylIqJkNZyFtOUPvpcofsRXufHqu != null)
						{
							HylIqJkNZyFtOUPvpcofsRXufHqu.Dispose();
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
						GffqwonREDFalbUIQuacemaHqfpV gffqwonREDFalbUIQuacemaHqfpV;
						if (dsARpwSrZiIptIpNJIkyoWVRqKVM == -2 && CWuZjFxAwKqmoCCDcDVEWmOyLOms == Environment.CurrentManagedThreadId)
						{
							dsARpwSrZiIptIpNJIkyoWVRqKVM = 0;
							gffqwonREDFalbUIQuacemaHqfpV = this;
						}
						else
						{
							gffqwonREDFalbUIQuacemaHqfpV = new GffqwonREDFalbUIQuacemaHqfpV(0);
							gffqwonREDFalbUIQuacemaHqfpV.YTVtbQPbKqyBVrDNecfgqIQFWpVU = YTVtbQPbKqyBVrDNecfgqIQFWpVU;
						}
						gffqwonREDFalbUIQuacemaHqfpV.KIwIZHAWcVsPalrBtjLPAdvMhgah = iXbICZNBtxhiPpQNEvvoSPTPuuKK;
						gffqwonREDFalbUIQuacemaHqfpV.qoKQVehSVwBeXvnsNERatJsfGbCx = QUYDwiclRlKYjybwNMQmcsWavDNI;
						return gffqwonREDFalbUIQuacemaHqfpV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class HrZAocbAqLUFtvvzCMIljEreTTTBB : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int mDBHAhBKaAEwZIcstfagDDJJPRNkB;

					private ActionElementMap JBFDaBjNXjYkJVRDeUKtHWQqayNy;

					private int hpUiYlLeALDwDgoFfHvhyISlpXtq;

					public MapHelper WynBBxMEWcdwxMWtVjGiUBynqvcv;

					private int WNIDjKegPGzNmcUpFeIpDQkUleeW;

					public int YZfSLOBPDTmovrGXDFCOCmndzJMpA;

					private bool ObKQJPFlgMpQHNUkkuPSvNUOBvqI;

					public bool klKChMGWIiYLEKmvrowfZDhQMPWD;

					private int nCREwxoOJwJutVPgyWvgHqFfdWvb;

					private int cSkfvDwNzRKrlcqwwzuPgqqYgAEY;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb tgjXhYFPmKhcNiEqOZzjiZZRUTUT;

					private int cuBLScgDvJtJHJnmpxZAYBvjqNei;

					private int CZGNUgiZPlQeCszxuEikkYjMEDvS;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA GoMcSiFUuETjwFYkKEOwKfRqxLbWA;

					private int HhsBiZTnyklPPTyiuikIZMNjwUwW;

					private int ioDaZFBfMVphMwzOpMQrUyaAPCaD;

					private IEnumerator<ActionElementMap> YJvhsMQsyYROVyCABLNbCJUcStNx;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return JBFDaBjNXjYkJVRDeUKtHWQqayNy;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JBFDaBjNXjYkJVRDeUKtHWQqayNy;
						}
					}

					[DebuggerHidden]
					public HrZAocbAqLUFtvvzCMIljEreTTTBB(int P_0)
					{
						mDBHAhBKaAEwZIcstfagDDJJPRNkB = P_0;
						hpUiYlLeALDwDgoFfHvhyISlpXtq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mDBHAhBKaAEwZIcstfagDDJJPRNkB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								FHaWBJukYzbcmTZYcTRnlgWMSiKU();
							}
						}
						tgjXhYFPmKhcNiEqOZzjiZZRUTUT = null;
						GoMcSiFUuETjwFYkKEOwKfRqxLbWA = null;
						YJvhsMQsyYROVyCABLNbCJUcStNx = null;
						mDBHAhBKaAEwZIcstfagDDJJPRNkB = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = mDBHAhBKaAEwZIcstfagDDJJPRNkB;
							MapHelper wynBBxMEWcdwxMWtVjGiUBynqvcv = WynBBxMEWcdwxMWtVjGiUBynqvcv;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mDBHAhBKaAEwZIcstfagDDJJPRNkB = -3;
								goto IL_016c;
							}
							mDBHAhBKaAEwZIcstfagDDJJPRNkB = -1;
							if (ReInput._id != wynBBxMEWcdwxMWtVjGiUBynqvcv.JUxUMkAhrDjRItbYUWjYRNgFpzir)
							{
								ReInput.CheckInitialized(wynBBxMEWcdwxMWtVjGiUBynqvcv.JUxUMkAhrDjRItbYUWjYRNgFpzir);
								return false;
							}
							if (WNIDjKegPGzNmcUpFeIpDQkUleeW < 0)
							{
								return false;
							}
							nCREwxoOJwJutVPgyWvgHqFfdWvb = wynBBxMEWcdwxMWtVjGiUBynqvcv.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
							cSkfvDwNzRKrlcqwwzuPgqqYgAEY = 0;
							goto IL_01ec;
							IL_016c:
							if (YJvhsMQsyYROVyCABLNbCJUcStNx.MoveNext())
							{
								ActionElementMap current = YJvhsMQsyYROVyCABLNbCJUcStNx.Current;
								JBFDaBjNXjYkJVRDeUKtHWQqayNy = current;
								mDBHAhBKaAEwZIcstfagDDJJPRNkB = 1;
								return true;
							}
							FHaWBJukYzbcmTZYcTRnlgWMSiKU();
							YJvhsMQsyYROVyCABLNbCJUcStNx = null;
							goto IL_0186;
							IL_0186:
							ioDaZFBfMVphMwzOpMQrUyaAPCaD++;
							goto IL_0198;
							IL_01c2:
							if (CZGNUgiZPlQeCszxuEikkYjMEDvS < cuBLScgDvJtJHJnmpxZAYBvjqNei)
							{
								GoMcSiFUuETjwFYkKEOwKfRqxLbWA = tgjXhYFPmKhcNiEqOZzjiZZRUTUT.LNTBMmjuONFUBLurbFbXivzHrdyGb(CZGNUgiZPlQeCszxuEikkYjMEDvS).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								HhsBiZTnyklPPTyiuikIZMNjwUwW = GoMcSiFUuETjwFYkKEOwKfRqxLbWA.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								ioDaZFBfMVphMwzOpMQrUyaAPCaD = 0;
								goto IL_0198;
							}
							tgjXhYFPmKhcNiEqOZzjiZZRUTUT = null;
							cSkfvDwNzRKrlcqwwzuPgqqYgAEY++;
							goto IL_01ec;
							IL_0198:
							if (ioDaZFBfMVphMwzOpMQrUyaAPCaD < HhsBiZTnyklPPTyiuikIZMNjwUwW)
							{
								ControllerMap controllerMap = GoMcSiFUuETjwFYkKEOwKfRqxLbWA.tMPEVPdgqovMveUHOiirPevVOylqA(ioDaZFBfMVphMwzOpMQrUyaAPCaD);
								if ((!ObKQJPFlgMpQHNUkkuPSvNUOBvqI || controllerMap.enabled) && controllerMap.ContainsAction(WNIDjKegPGzNmcUpFeIpDQkUleeW))
								{
									YJvhsMQsyYROVyCABLNbCJUcStNx = controllerMap.ButtonMapsWithAction(WNIDjKegPGzNmcUpFeIpDQkUleeW, ObKQJPFlgMpQHNUkkuPSvNUOBvqI).GetEnumerator();
									mDBHAhBKaAEwZIcstfagDDJJPRNkB = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							GoMcSiFUuETjwFYkKEOwKfRqxLbWA = null;
							CZGNUgiZPlQeCszxuEikkYjMEDvS++;
							goto IL_01c2;
							IL_01ec:
							if (cSkfvDwNzRKrlcqwwzuPgqqYgAEY < nCREwxoOJwJutVPgyWvgHqFfdWvb)
							{
								tgjXhYFPmKhcNiEqOZzjiZZRUTUT = wynBBxMEWcdwxMWtVjGiUBynqvcv.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(cSkfvDwNzRKrlcqwwzuPgqqYgAEY);
								cuBLScgDvJtJHJnmpxZAYBvjqNei = tgjXhYFPmKhcNiEqOZzjiZZRUTUT.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
								CZGNUgiZPlQeCszxuEikkYjMEDvS = 0;
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

					private void FHaWBJukYzbcmTZYcTRnlgWMSiKU()
					{
						mDBHAhBKaAEwZIcstfagDDJJPRNkB = -1;
						if (YJvhsMQsyYROVyCABLNbCJUcStNx != null)
						{
							YJvhsMQsyYROVyCABLNbCJUcStNx.Dispose();
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
						HrZAocbAqLUFtvvzCMIljEreTTTBB hrZAocbAqLUFtvvzCMIljEreTTTBB;
						if (mDBHAhBKaAEwZIcstfagDDJJPRNkB == -2 && hpUiYlLeALDwDgoFfHvhyISlpXtq == Environment.CurrentManagedThreadId)
						{
							mDBHAhBKaAEwZIcstfagDDJJPRNkB = 0;
							hrZAocbAqLUFtvvzCMIljEreTTTBB = this;
						}
						else
						{
							hrZAocbAqLUFtvvzCMIljEreTTTBB = new HrZAocbAqLUFtvvzCMIljEreTTTBB(0);
							hrZAocbAqLUFtvvzCMIljEreTTTBB.WynBBxMEWcdwxMWtVjGiUBynqvcv = WynBBxMEWcdwxMWtVjGiUBynqvcv;
						}
						hrZAocbAqLUFtvvzCMIljEreTTTBB.WNIDjKegPGzNmcUpFeIpDQkUleeW = YZfSLOBPDTmovrGXDFCOCmndzJMpA;
						hrZAocbAqLUFtvvzCMIljEreTTTBB.ObKQJPFlgMpQHNUkkuPSvNUOBvqI = klKChMGWIiYLEKmvrowfZDhQMPWD;
						return hrZAocbAqLUFtvvzCMIljEreTTTBB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class CGWKkdeOqdAVQcqKZlbYzJGjWMwuA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int hfxBpWgtOXfDRCjWakCosEjDcDwwb;

					private ActionElementMap qNlJuHlGfxIcRfCBtGSOpPSPEmDRA;

					private int ZyidcKRozEJnnyJBBWqSNGiYdkKB;

					private int yshnVdHMauHSpGrBcsZMmzIwrYtl;

					public int gJwOKehQAItHTxrFKNUmHYcINhFH;

					public MapHelper LPQcGTfEQvtrQfETkSTswQaAoKxf;

					private ControllerType cNAQERMMAIgoyFrDLzBpUuESmEkUA;

					public ControllerType jQrFXcGbwRPeFYrRidvhxCTHZTQbA;

					private bool JcHfkFGVNHMKLkoNfspBbUecMuTM;

					public bool CkEaBceTDmJfhfZPHPKJWKUDBMJJb;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb WIsFPXsVQWUGdWFTTqVPiUdQhOGA;

					private int jaZfDQmvhHmxyKBSCAmTDrgAooKuA;

					private IList<ControllerMap> iligzjZGhuFxwncmyfEscMsWJQui;

					private int VTQVZgJgQJHcujIYWxuBzTvecAko;

					private IEnumerator<ActionElementMap> YblzVkaOjOmNMhvnwUaQjOXpezMW;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return qNlJuHlGfxIcRfCBtGSOpPSPEmDRA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qNlJuHlGfxIcRfCBtGSOpPSPEmDRA;
						}
					}

					[DebuggerHidden]
					public CGWKkdeOqdAVQcqKZlbYzJGjWMwuA(int P_0)
					{
						hfxBpWgtOXfDRCjWakCosEjDcDwwb = P_0;
						ZyidcKRozEJnnyJBBWqSNGiYdkKB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hfxBpWgtOXfDRCjWakCosEjDcDwwb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								onWxatpAJNtTNSMmrOFCtzLwyFPK();
							}
						}
						WIsFPXsVQWUGdWFTTqVPiUdQhOGA = null;
						iligzjZGhuFxwncmyfEscMsWJQui = null;
						YblzVkaOjOmNMhvnwUaQjOXpezMW = null;
						hfxBpWgtOXfDRCjWakCosEjDcDwwb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hfxBpWgtOXfDRCjWakCosEjDcDwwb;
							MapHelper lPQcGTfEQvtrQfETkSTswQaAoKxf = LPQcGTfEQvtrQfETkSTswQaAoKxf;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hfxBpWgtOXfDRCjWakCosEjDcDwwb = -3;
								goto IL_0150;
							}
							hfxBpWgtOXfDRCjWakCosEjDcDwwb = -1;
							if (yshnVdHMauHSpGrBcsZMmzIwrYtl < 0)
							{
								return false;
							}
							WIsFPXsVQWUGdWFTTqVPiUdQhOGA = lPQcGTfEQvtrQfETkSTswQaAoKxf.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(cNAQERMMAIgoyFrDLzBpUuESmEkUA);
							jaZfDQmvhHmxyKBSCAmTDrgAooKuA = 0;
							goto IL_01ab;
							IL_0150:
							if (YblzVkaOjOmNMhvnwUaQjOXpezMW.MoveNext())
							{
								ActionElementMap current = YblzVkaOjOmNMhvnwUaQjOXpezMW.Current;
								qNlJuHlGfxIcRfCBtGSOpPSPEmDRA = current;
								hfxBpWgtOXfDRCjWakCosEjDcDwwb = 1;
								return true;
							}
							onWxatpAJNtTNSMmrOFCtzLwyFPK();
							YblzVkaOjOmNMhvnwUaQjOXpezMW = null;
							goto IL_016a;
							IL_017c:
							if (VTQVZgJgQJHcujIYWxuBzTvecAko < iligzjZGhuFxwncmyfEscMsWJQui.Count)
							{
								if (!(iligzjZGhuFxwncmyfEscMsWJQui[VTQVZgJgQJHcujIYWxuBzTvecAko] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!JcHfkFGVNHMKLkoNfspBbUecMuTM || iligzjZGhuFxwncmyfEscMsWJQui[VTQVZgJgQJHcujIYWxuBzTvecAko].enabled) && iligzjZGhuFxwncmyfEscMsWJQui[VTQVZgJgQJHcujIYWxuBzTvecAko].ContainsAction(yshnVdHMauHSpGrBcsZMmzIwrYtl))
								{
									YblzVkaOjOmNMhvnwUaQjOXpezMW = (iligzjZGhuFxwncmyfEscMsWJQui[VTQVZgJgQJHcujIYWxuBzTvecAko] as ControllerMapWithAxes).AxisMapsWithAction(yshnVdHMauHSpGrBcsZMmzIwrYtl, JcHfkFGVNHMKLkoNfspBbUecMuTM).GetEnumerator();
									hfxBpWgtOXfDRCjWakCosEjDcDwwb = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							iligzjZGhuFxwncmyfEscMsWJQui = null;
							jaZfDQmvhHmxyKBSCAmTDrgAooKuA++;
							goto IL_01ab;
							IL_016a:
							VTQVZgJgQJHcujIYWxuBzTvecAko++;
							goto IL_017c;
							IL_01ab:
							if (jaZfDQmvhHmxyKBSCAmTDrgAooKuA < WIsFPXsVQWUGdWFTTqVPiUdQhOGA.yqhlCDSAeeNknWUrdPHIJVxJgUrb)
							{
								iligzjZGhuFxwncmyfEscMsWJQui = WIsFPXsVQWUGdWFTTqVPiUdQhOGA.LNTBMmjuONFUBLurbFbXivzHrdyGb(jaZfDQmvhHmxyKBSCAmTDrgAooKuA).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
								VTQVZgJgQJHcujIYWxuBzTvecAko = 0;
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

					private void onWxatpAJNtTNSMmrOFCtzLwyFPK()
					{
						hfxBpWgtOXfDRCjWakCosEjDcDwwb = -1;
						if (YblzVkaOjOmNMhvnwUaQjOXpezMW != null)
						{
							YblzVkaOjOmNMhvnwUaQjOXpezMW.Dispose();
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
						CGWKkdeOqdAVQcqKZlbYzJGjWMwuA cGWKkdeOqdAVQcqKZlbYzJGjWMwuA;
						if (hfxBpWgtOXfDRCjWakCosEjDcDwwb == -2 && ZyidcKRozEJnnyJBBWqSNGiYdkKB == Environment.CurrentManagedThreadId)
						{
							hfxBpWgtOXfDRCjWakCosEjDcDwwb = 0;
							cGWKkdeOqdAVQcqKZlbYzJGjWMwuA = this;
						}
						else
						{
							cGWKkdeOqdAVQcqKZlbYzJGjWMwuA = new CGWKkdeOqdAVQcqKZlbYzJGjWMwuA(0);
							cGWKkdeOqdAVQcqKZlbYzJGjWMwuA.LPQcGTfEQvtrQfETkSTswQaAoKxf = LPQcGTfEQvtrQfETkSTswQaAoKxf;
						}
						cGWKkdeOqdAVQcqKZlbYzJGjWMwuA.cNAQERMMAIgoyFrDLzBpUuESmEkUA = jQrFXcGbwRPeFYrRidvhxCTHZTQbA;
						cGWKkdeOqdAVQcqKZlbYzJGjWMwuA.yshnVdHMauHSpGrBcsZMmzIwrYtl = gJwOKehQAItHTxrFKNUmHYcINhFH;
						cGWKkdeOqdAVQcqKZlbYzJGjWMwuA.JcHfkFGVNHMKLkoNfspBbUecMuTM = CkEaBceTDmJfhfZPHPKJWKUDBMJJb;
						return cGWKkdeOqdAVQcqKZlbYzJGjWMwuA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class YBxRgIQOtyBzxiivWCFOgepaJXyIB : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int wRjCldfkHvkgduZbScalfsqyULrl;

					private ActionElementMap VVUARmeekXLSoWJqjzgZMdfhdTqV;

					private int huRkkKGMcWEoSFmHEqFpxmJlMJmH;

					private int DdfAteykDuNbOeIzYkFkqpeczQHk;

					public int CvGQJgIlNwNDMkkGKhZRnyMjHBSB;

					public MapHelper vnQtadMQXXCqOjQxhuKWrTuxlpPQ;

					private ControllerType gFhdinYQJjhWMHxbEYSDMJzmDGpO;

					public ControllerType ZPZAcrrEdPfctgIfoQLHxCawrluZ;

					private int fDDijPiMGnkcumDZuKoTkXqTpexpA;

					public int guqDqhTZKuWDQxcrCBgQelPNqvYC;

					private bool eGCwuOXXEuKTRxphiSIMWyFIMIsw;

					public bool FIaVkHYbEtCtUaJeEWwNFmmzKHlbA;

					private IList<ControllerMap> wPBBTjIkYrrROpkwSQNIacltuRdrA;

					private int csHKripyZiuxHmfszQhcaFGmNers;

					private IEnumerator<ActionElementMap> iaIoDmHTksbjrmfmQYiHgFTnkRBY;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return VVUARmeekXLSoWJqjzgZMdfhdTqV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VVUARmeekXLSoWJqjzgZMdfhdTqV;
						}
					}

					[DebuggerHidden]
					public YBxRgIQOtyBzxiivWCFOgepaJXyIB(int P_0)
					{
						wRjCldfkHvkgduZbScalfsqyULrl = P_0;
						huRkkKGMcWEoSFmHEqFpxmJlMJmH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = wRjCldfkHvkgduZbScalfsqyULrl;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								jMjEJTQdgfNjHWAhhbUzqcnoWmn();
							}
						}
						wPBBTjIkYrrROpkwSQNIacltuRdrA = null;
						iaIoDmHTksbjrmfmQYiHgFTnkRBY = null;
						wRjCldfkHvkgduZbScalfsqyULrl = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = wRjCldfkHvkgduZbScalfsqyULrl;
							MapHelper mapHelper = vnQtadMQXXCqOjQxhuKWrTuxlpPQ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								wRjCldfkHvkgduZbScalfsqyULrl = -3;
								goto IL_014f;
							}
							wRjCldfkHvkgduZbScalfsqyULrl = -1;
							if (DdfAteykDuNbOeIzYkFkqpeczQHk < 0)
							{
								return false;
							}
							oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(gFhdinYQJjhWMHxbEYSDMJzmDGpO);
							int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(fDDijPiMGnkcumDZuKoTkXqTpexpA);
							if (num2 < 0)
							{
								return false;
							}
							wPBBTjIkYrrROpkwSQNIacltuRdrA = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num2).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
							csHKripyZiuxHmfszQhcaFGmNers = 0;
							goto IL_017b;
							IL_014f:
							if (iaIoDmHTksbjrmfmQYiHgFTnkRBY.MoveNext())
							{
								ActionElementMap current = iaIoDmHTksbjrmfmQYiHgFTnkRBY.Current;
								VVUARmeekXLSoWJqjzgZMdfhdTqV = current;
								wRjCldfkHvkgduZbScalfsqyULrl = 1;
								return true;
							}
							jMjEJTQdgfNjHWAhhbUzqcnoWmn();
							iaIoDmHTksbjrmfmQYiHgFTnkRBY = null;
							goto IL_0169;
							IL_017b:
							if (csHKripyZiuxHmfszQhcaFGmNers < wPBBTjIkYrrROpkwSQNIacltuRdrA.Count)
							{
								if (!(wPBBTjIkYrrROpkwSQNIacltuRdrA[csHKripyZiuxHmfszQhcaFGmNers] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!eGCwuOXXEuKTRxphiSIMWyFIMIsw || wPBBTjIkYrrROpkwSQNIacltuRdrA[csHKripyZiuxHmfszQhcaFGmNers].enabled) && wPBBTjIkYrrROpkwSQNIacltuRdrA[csHKripyZiuxHmfszQhcaFGmNers].ContainsAction(DdfAteykDuNbOeIzYkFkqpeczQHk))
								{
									iaIoDmHTksbjrmfmQYiHgFTnkRBY = (wPBBTjIkYrrROpkwSQNIacltuRdrA[csHKripyZiuxHmfszQhcaFGmNers] as ControllerMapWithAxes).AxisMapsWithAction(DdfAteykDuNbOeIzYkFkqpeczQHk, eGCwuOXXEuKTRxphiSIMWyFIMIsw).GetEnumerator();
									wRjCldfkHvkgduZbScalfsqyULrl = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							csHKripyZiuxHmfszQhcaFGmNers++;
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

					private void jMjEJTQdgfNjHWAhhbUzqcnoWmn()
					{
						wRjCldfkHvkgduZbScalfsqyULrl = -1;
						if (iaIoDmHTksbjrmfmQYiHgFTnkRBY != null)
						{
							iaIoDmHTksbjrmfmQYiHgFTnkRBY.Dispose();
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
						YBxRgIQOtyBzxiivWCFOgepaJXyIB yBxRgIQOtyBzxiivWCFOgepaJXyIB;
						if (wRjCldfkHvkgduZbScalfsqyULrl == -2 && huRkkKGMcWEoSFmHEqFpxmJlMJmH == Environment.CurrentManagedThreadId)
						{
							wRjCldfkHvkgduZbScalfsqyULrl = 0;
							yBxRgIQOtyBzxiivWCFOgepaJXyIB = this;
						}
						else
						{
							yBxRgIQOtyBzxiivWCFOgepaJXyIB = new YBxRgIQOtyBzxiivWCFOgepaJXyIB(0);
							yBxRgIQOtyBzxiivWCFOgepaJXyIB.vnQtadMQXXCqOjQxhuKWrTuxlpPQ = vnQtadMQXXCqOjQxhuKWrTuxlpPQ;
						}
						yBxRgIQOtyBzxiivWCFOgepaJXyIB.gFhdinYQJjhWMHxbEYSDMJzmDGpO = ZPZAcrrEdPfctgIfoQLHxCawrluZ;
						yBxRgIQOtyBzxiivWCFOgepaJXyIB.fDDijPiMGnkcumDZuKoTkXqTpexpA = guqDqhTZKuWDQxcrCBgQelPNqvYC;
						yBxRgIQOtyBzxiivWCFOgepaJXyIB.DdfAteykDuNbOeIzYkFkqpeczQHk = CvGQJgIlNwNDMkkGKhZRnyMjHBSB;
						yBxRgIQOtyBzxiivWCFOgepaJXyIB.eGCwuOXXEuKTRxphiSIMWyFIMIsw = FIaVkHYbEtCtUaJeEWwNFmmzKHlbA;
						return yBxRgIQOtyBzxiivWCFOgepaJXyIB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class PpmWyAUuJDepsvsPdwPnmUEuqohJ : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int pvPWdPBURqisQGkmKjCmFUlWhlvo;

					private ActionElementMap PVaTfucnafBdMhWMmttCKGMZkPTlA;

					private int lBVebznfEEtqOQqWxNcfTXPHsyMo;

					private int kCGDFAmjJbgJJMUhZBJnCbmUjACV;

					public int SFFAAzdKJHaTWdtZLKryqdmkGyDc;

					public MapHelper eZVsKpgBaiUIZLOAnfPpmyzpHtvf;

					private ControllerType UqwCTdCOolYwYryXzzhCksGkjKrdA;

					public ControllerType rGmAZicTuenWWAHzNgkwRFgSPRTP;

					private bool yyzbzNqKgoXPZIKBtxZXhQkXhuP;

					public bool qKkaWLPGHQygdcKmfPMoXirVzDnM;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb xFkSBrrJVhpxfYGdLbQXQzntDlPd;

					private int enBfnRBPlfdcKiixLRMfpzPITVcS;

					private IList<ControllerMap> ijBNJDEpDavRdqEarqqgOydEDNFX;

					private int jEdVziCsaLLaWoasTdPUvcoAoKUh;

					private IEnumerator<ActionElementMap> NIwrYXGSpHSUNAlqiGkBQFMAzLnD;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return PVaTfucnafBdMhWMmttCKGMZkPTlA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PVaTfucnafBdMhWMmttCKGMZkPTlA;
						}
					}

					[DebuggerHidden]
					public PpmWyAUuJDepsvsPdwPnmUEuqohJ(int P_0)
					{
						pvPWdPBURqisQGkmKjCmFUlWhlvo = P_0;
						lBVebznfEEtqOQqWxNcfTXPHsyMo = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pvPWdPBURqisQGkmKjCmFUlWhlvo;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RVKPuEisjYXWDplXCooflKjAtizG();
							}
						}
						xFkSBrrJVhpxfYGdLbQXQzntDlPd = null;
						ijBNJDEpDavRdqEarqqgOydEDNFX = null;
						NIwrYXGSpHSUNAlqiGkBQFMAzLnD = null;
						pvPWdPBURqisQGkmKjCmFUlWhlvo = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pvPWdPBURqisQGkmKjCmFUlWhlvo;
							MapHelper mapHelper = eZVsKpgBaiUIZLOAnfPpmyzpHtvf;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pvPWdPBURqisQGkmKjCmFUlWhlvo = -3;
								goto IL_012c;
							}
							pvPWdPBURqisQGkmKjCmFUlWhlvo = -1;
							if (kCGDFAmjJbgJJMUhZBJnCbmUjACV < 0)
							{
								return false;
							}
							xFkSBrrJVhpxfYGdLbQXQzntDlPd = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(UqwCTdCOolYwYryXzzhCksGkjKrdA);
							enBfnRBPlfdcKiixLRMfpzPITVcS = 0;
							goto IL_0187;
							IL_012c:
							if (NIwrYXGSpHSUNAlqiGkBQFMAzLnD.MoveNext())
							{
								ActionElementMap current = NIwrYXGSpHSUNAlqiGkBQFMAzLnD.Current;
								PVaTfucnafBdMhWMmttCKGMZkPTlA = current;
								pvPWdPBURqisQGkmKjCmFUlWhlvo = 1;
								return true;
							}
							RVKPuEisjYXWDplXCooflKjAtizG();
							NIwrYXGSpHSUNAlqiGkBQFMAzLnD = null;
							goto IL_0146;
							IL_0158:
							if (jEdVziCsaLLaWoasTdPUvcoAoKUh < ijBNJDEpDavRdqEarqqgOydEDNFX.Count)
							{
								if ((!yyzbzNqKgoXPZIKBtxZXhQkXhuP || ijBNJDEpDavRdqEarqqgOydEDNFX[jEdVziCsaLLaWoasTdPUvcoAoKUh].enabled) && ijBNJDEpDavRdqEarqqgOydEDNFX[jEdVziCsaLLaWoasTdPUvcoAoKUh].ContainsAction(kCGDFAmjJbgJJMUhZBJnCbmUjACV))
								{
									NIwrYXGSpHSUNAlqiGkBQFMAzLnD = ijBNJDEpDavRdqEarqqgOydEDNFX[jEdVziCsaLLaWoasTdPUvcoAoKUh].ButtonMapsWithAction(kCGDFAmjJbgJJMUhZBJnCbmUjACV, yyzbzNqKgoXPZIKBtxZXhQkXhuP).GetEnumerator();
									pvPWdPBURqisQGkmKjCmFUlWhlvo = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							ijBNJDEpDavRdqEarqqgOydEDNFX = null;
							enBfnRBPlfdcKiixLRMfpzPITVcS++;
							goto IL_0187;
							IL_0146:
							jEdVziCsaLLaWoasTdPUvcoAoKUh++;
							goto IL_0158;
							IL_0187:
							if (enBfnRBPlfdcKiixLRMfpzPITVcS < xFkSBrrJVhpxfYGdLbQXQzntDlPd.yqhlCDSAeeNknWUrdPHIJVxJgUrb)
							{
								ijBNJDEpDavRdqEarqqgOydEDNFX = xFkSBrrJVhpxfYGdLbQXQzntDlPd.LNTBMmjuONFUBLurbFbXivzHrdyGb(enBfnRBPlfdcKiixLRMfpzPITVcS).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
								jEdVziCsaLLaWoasTdPUvcoAoKUh = 0;
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

					private void RVKPuEisjYXWDplXCooflKjAtizG()
					{
						pvPWdPBURqisQGkmKjCmFUlWhlvo = -1;
						if (NIwrYXGSpHSUNAlqiGkBQFMAzLnD != null)
						{
							NIwrYXGSpHSUNAlqiGkBQFMAzLnD.Dispose();
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
						PpmWyAUuJDepsvsPdwPnmUEuqohJ ppmWyAUuJDepsvsPdwPnmUEuqohJ;
						if (pvPWdPBURqisQGkmKjCmFUlWhlvo == -2 && lBVebznfEEtqOQqWxNcfTXPHsyMo == Environment.CurrentManagedThreadId)
						{
							pvPWdPBURqisQGkmKjCmFUlWhlvo = 0;
							ppmWyAUuJDepsvsPdwPnmUEuqohJ = this;
						}
						else
						{
							ppmWyAUuJDepsvsPdwPnmUEuqohJ = new PpmWyAUuJDepsvsPdwPnmUEuqohJ(0);
							ppmWyAUuJDepsvsPdwPnmUEuqohJ.eZVsKpgBaiUIZLOAnfPpmyzpHtvf = eZVsKpgBaiUIZLOAnfPpmyzpHtvf;
						}
						ppmWyAUuJDepsvsPdwPnmUEuqohJ.UqwCTdCOolYwYryXzzhCksGkjKrdA = rGmAZicTuenWWAHzNgkwRFgSPRTP;
						ppmWyAUuJDepsvsPdwPnmUEuqohJ.kCGDFAmjJbgJJMUhZBJnCbmUjACV = SFFAAzdKJHaTWdtZLKryqdmkGyDc;
						ppmWyAUuJDepsvsPdwPnmUEuqohJ.yyzbzNqKgoXPZIKBtxZXhQkXhuP = qKkaWLPGHQygdcKmfPMoXirVzDnM;
						return ppmWyAUuJDepsvsPdwPnmUEuqohJ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class mjrAhOLOnFTRkxuNsiOMmMBQPwFV : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int uObVpWFESUanffGPKHHJwLirmTXqA;

					private ActionElementMap lbsIKNgDPGogIYIbMAzPQJFTaEeJA;

					private int QLJJgatEMIiexbIHOwnYoXUnFhjuA;

					private int FVPdoupKfJLxcjJfRgKvmIcZHsbT;

					public int USGaVaAWdKFlxscknKIojWwgKLRCB;

					public MapHelper dqMUQlVSbXFHiBkIAflPVxydFTsD;

					private ControllerType dcRsUoACqynewUYcKLqBSbDviGbm;

					public ControllerType gfLgXfonmsElBsfrmaxAbaeBRnLV;

					private int NBScpUkNrSScaAybUPTIjQAYgTZbb;

					public int pJFnwXqRWCfqPpcXeBABrlLvIlFT;

					private bool jRBdqwITkmTXOJGWNVQStsiLYdsjA;

					public bool iHIgSRGlIPVyxRCTMSzgqBzFQRsqA;

					private IList<ControllerMap> joZRyJckHMElwNnZoNsVCYxCSsPg;

					private int kmQIshqorSYEDPCvpJscOcsBfOihA;

					private IEnumerator<ActionElementMap> pCTkkITEgswARgifERibGVVrNbcK;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return lbsIKNgDPGogIYIbMAzPQJFTaEeJA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lbsIKNgDPGogIYIbMAzPQJFTaEeJA;
						}
					}

					[DebuggerHidden]
					public mjrAhOLOnFTRkxuNsiOMmMBQPwFV(int P_0)
					{
						uObVpWFESUanffGPKHHJwLirmTXqA = P_0;
						QLJJgatEMIiexbIHOwnYoXUnFhjuA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = uObVpWFESUanffGPKHHJwLirmTXqA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								SAAmVDfsoBFgLQwxpdPrRqOyGENkA();
							}
						}
						joZRyJckHMElwNnZoNsVCYxCSsPg = null;
						pCTkkITEgswARgifERibGVVrNbcK = null;
						uObVpWFESUanffGPKHHJwLirmTXqA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = uObVpWFESUanffGPKHHJwLirmTXqA;
							MapHelper mapHelper = dqMUQlVSbXFHiBkIAflPVxydFTsD;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								uObVpWFESUanffGPKHHJwLirmTXqA = -3;
								goto IL_012b;
							}
							uObVpWFESUanffGPKHHJwLirmTXqA = -1;
							if (FVPdoupKfJLxcjJfRgKvmIcZHsbT < 0)
							{
								return false;
							}
							oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(dcRsUoACqynewUYcKLqBSbDviGbm);
							int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(NBScpUkNrSScaAybUPTIjQAYgTZbb);
							if (num2 < 0)
							{
								return false;
							}
							joZRyJckHMElwNnZoNsVCYxCSsPg = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num2).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
							kmQIshqorSYEDPCvpJscOcsBfOihA = 0;
							goto IL_0157;
							IL_012b:
							if (pCTkkITEgswARgifERibGVVrNbcK.MoveNext())
							{
								ActionElementMap current = pCTkkITEgswARgifERibGVVrNbcK.Current;
								lbsIKNgDPGogIYIbMAzPQJFTaEeJA = current;
								uObVpWFESUanffGPKHHJwLirmTXqA = 1;
								return true;
							}
							SAAmVDfsoBFgLQwxpdPrRqOyGENkA();
							pCTkkITEgswARgifERibGVVrNbcK = null;
							goto IL_0145;
							IL_0157:
							if (kmQIshqorSYEDPCvpJscOcsBfOihA < joZRyJckHMElwNnZoNsVCYxCSsPg.Count)
							{
								if ((!jRBdqwITkmTXOJGWNVQStsiLYdsjA || joZRyJckHMElwNnZoNsVCYxCSsPg[kmQIshqorSYEDPCvpJscOcsBfOihA].enabled) && joZRyJckHMElwNnZoNsVCYxCSsPg[kmQIshqorSYEDPCvpJscOcsBfOihA].ContainsAction(FVPdoupKfJLxcjJfRgKvmIcZHsbT))
								{
									pCTkkITEgswARgifERibGVVrNbcK = joZRyJckHMElwNnZoNsVCYxCSsPg[kmQIshqorSYEDPCvpJscOcsBfOihA].ButtonMapsWithAction(FVPdoupKfJLxcjJfRgKvmIcZHsbT, jRBdqwITkmTXOJGWNVQStsiLYdsjA).GetEnumerator();
									uObVpWFESUanffGPKHHJwLirmTXqA = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							kmQIshqorSYEDPCvpJscOcsBfOihA++;
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

					private void SAAmVDfsoBFgLQwxpdPrRqOyGENkA()
					{
						uObVpWFESUanffGPKHHJwLirmTXqA = -1;
						if (pCTkkITEgswARgifERibGVVrNbcK != null)
						{
							pCTkkITEgswARgifERibGVVrNbcK.Dispose();
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
						mjrAhOLOnFTRkxuNsiOMmMBQPwFV mjrAhOLOnFTRkxuNsiOMmMBQPwFV2;
						if (uObVpWFESUanffGPKHHJwLirmTXqA == -2 && QLJJgatEMIiexbIHOwnYoXUnFhjuA == Environment.CurrentManagedThreadId)
						{
							uObVpWFESUanffGPKHHJwLirmTXqA = 0;
							mjrAhOLOnFTRkxuNsiOMmMBQPwFV2 = this;
						}
						else
						{
							mjrAhOLOnFTRkxuNsiOMmMBQPwFV2 = new mjrAhOLOnFTRkxuNsiOMmMBQPwFV(0);
							mjrAhOLOnFTRkxuNsiOMmMBQPwFV2.dqMUQlVSbXFHiBkIAflPVxydFTsD = dqMUQlVSbXFHiBkIAflPVxydFTsD;
						}
						mjrAhOLOnFTRkxuNsiOMmMBQPwFV2.dcRsUoACqynewUYcKLqBSbDviGbm = gfLgXfonmsElBsfrmaxAbaeBRnLV;
						mjrAhOLOnFTRkxuNsiOMmMBQPwFV2.NBScpUkNrSScaAybUPTIjQAYgTZbb = pJFnwXqRWCfqPpcXeBABrlLvIlFT;
						mjrAhOLOnFTRkxuNsiOMmMBQPwFV2.FVPdoupKfJLxcjJfRgKvmIcZHsbT = USGaVaAWdKFlxscknKIojWwgKLRCB;
						mjrAhOLOnFTRkxuNsiOMmMBQPwFV2.jRBdqwITkmTXOJGWNVQStsiLYdsjA = iHIgSRGlIPVyxRCTMSzgqBzFQRsqA;
						return mjrAhOLOnFTRkxuNsiOMmMBQPwFV2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class wfcsCBwWcQSLTyrGawXqOUrshHUH : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int hwKBrvJhjtQTXPaGEEeuxhjYEqPSA;

					private ActionElementMap LwBXmpOjilEPcimnyfmHehsbdUWWB;

					private int RDWyNHCawStcfysIFlAuhHwjapjR;

					private int IzuQMMHaiIWgBwqiOATfgeosOjDgb;

					public int faMgSZgfNIBrseLNYEAsAPNhlwlGb;

					public MapHelper eRJRXpAcDNbbcaPgytANyjLIHMae;

					private ControllerType KjmbtiSxODJSSINOJQuaCnGazicq;

					public ControllerType KEuojHdhFGyLtACizdrCjMwXFXaqA;

					private bool GCPAbZFXOvUcdASswObnOmwTtNLnA;

					public bool lTVFffdFdVKlCUAKLBqdrHDqcdfdb;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb VYbDKChTTfIdyjWVUhxdbMiehJFY;

					private int BDsjudOvzliXEWwEQEMHUgigisvL;

					private IList<ControllerMap> VCCdUXCgMmTIQllOnOXjeDZExbVac;

					private int oFhjrVhxoxuUaNkughYIRSmFIlqq;

					private IEnumerator<ActionElementMap> hwUoXxEJZxXRBMXsyBcCNlYrjtDj;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return LwBXmpOjilEPcimnyfmHehsbdUWWB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LwBXmpOjilEPcimnyfmHehsbdUWWB;
						}
					}

					[DebuggerHidden]
					public wfcsCBwWcQSLTyrGawXqOUrshHUH(int P_0)
					{
						hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = P_0;
						RDWyNHCawStcfysIFlAuhHwjapjR = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hwKBrvJhjtQTXPaGEEeuxhjYEqPSA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								eNPfTlSOqZklgStcpaDnRcisDmvu();
							}
						}
						VYbDKChTTfIdyjWVUhxdbMiehJFY = null;
						VCCdUXCgMmTIQllOnOXjeDZExbVac = null;
						hwUoXxEJZxXRBMXsyBcCNlYrjtDj = null;
						hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hwKBrvJhjtQTXPaGEEeuxhjYEqPSA;
							MapHelper mapHelper = eRJRXpAcDNbbcaPgytANyjLIHMae;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = -3;
								goto IL_012c;
							}
							hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = -1;
							if (IzuQMMHaiIWgBwqiOATfgeosOjDgb < 0)
							{
								return false;
							}
							VYbDKChTTfIdyjWVUhxdbMiehJFY = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(KjmbtiSxODJSSINOJQuaCnGazicq);
							BDsjudOvzliXEWwEQEMHUgigisvL = 0;
							goto IL_0187;
							IL_012c:
							if (hwUoXxEJZxXRBMXsyBcCNlYrjtDj.MoveNext())
							{
								ActionElementMap current = hwUoXxEJZxXRBMXsyBcCNlYrjtDj.Current;
								LwBXmpOjilEPcimnyfmHehsbdUWWB = current;
								hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = 1;
								return true;
							}
							eNPfTlSOqZklgStcpaDnRcisDmvu();
							hwUoXxEJZxXRBMXsyBcCNlYrjtDj = null;
							goto IL_0146;
							IL_0158:
							if (oFhjrVhxoxuUaNkughYIRSmFIlqq < VCCdUXCgMmTIQllOnOXjeDZExbVac.Count)
							{
								if ((!GCPAbZFXOvUcdASswObnOmwTtNLnA || VCCdUXCgMmTIQllOnOXjeDZExbVac[oFhjrVhxoxuUaNkughYIRSmFIlqq].enabled) && VCCdUXCgMmTIQllOnOXjeDZExbVac[oFhjrVhxoxuUaNkughYIRSmFIlqq].ContainsAction(IzuQMMHaiIWgBwqiOATfgeosOjDgb))
								{
									hwUoXxEJZxXRBMXsyBcCNlYrjtDj = VCCdUXCgMmTIQllOnOXjeDZExbVac[oFhjrVhxoxuUaNkughYIRSmFIlqq].ElementMapsWithAction(IzuQMMHaiIWgBwqiOATfgeosOjDgb, GCPAbZFXOvUcdASswObnOmwTtNLnA).GetEnumerator();
									hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							VCCdUXCgMmTIQllOnOXjeDZExbVac = null;
							BDsjudOvzliXEWwEQEMHUgigisvL++;
							goto IL_0187;
							IL_0146:
							oFhjrVhxoxuUaNkughYIRSmFIlqq++;
							goto IL_0158;
							IL_0187:
							if (BDsjudOvzliXEWwEQEMHUgigisvL < VYbDKChTTfIdyjWVUhxdbMiehJFY.yqhlCDSAeeNknWUrdPHIJVxJgUrb)
							{
								VCCdUXCgMmTIQllOnOXjeDZExbVac = VYbDKChTTfIdyjWVUhxdbMiehJFY.LNTBMmjuONFUBLurbFbXivzHrdyGb(BDsjudOvzliXEWwEQEMHUgigisvL).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
								oFhjrVhxoxuUaNkughYIRSmFIlqq = 0;
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

					private void eNPfTlSOqZklgStcpaDnRcisDmvu()
					{
						hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = -1;
						if (hwUoXxEJZxXRBMXsyBcCNlYrjtDj != null)
						{
							hwUoXxEJZxXRBMXsyBcCNlYrjtDj.Dispose();
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
						wfcsCBwWcQSLTyrGawXqOUrshHUH wfcsCBwWcQSLTyrGawXqOUrshHUH2;
						if (hwKBrvJhjtQTXPaGEEeuxhjYEqPSA == -2 && RDWyNHCawStcfysIFlAuhHwjapjR == Environment.CurrentManagedThreadId)
						{
							hwKBrvJhjtQTXPaGEEeuxhjYEqPSA = 0;
							wfcsCBwWcQSLTyrGawXqOUrshHUH2 = this;
						}
						else
						{
							wfcsCBwWcQSLTyrGawXqOUrshHUH2 = new wfcsCBwWcQSLTyrGawXqOUrshHUH(0);
							wfcsCBwWcQSLTyrGawXqOUrshHUH2.eRJRXpAcDNbbcaPgytANyjLIHMae = eRJRXpAcDNbbcaPgytANyjLIHMae;
						}
						wfcsCBwWcQSLTyrGawXqOUrshHUH2.KjmbtiSxODJSSINOJQuaCnGazicq = KEuojHdhFGyLtACizdrCjMwXFXaqA;
						wfcsCBwWcQSLTyrGawXqOUrshHUH2.IzuQMMHaiIWgBwqiOATfgeosOjDgb = faMgSZgfNIBrseLNYEAsAPNhlwlGb;
						wfcsCBwWcQSLTyrGawXqOUrshHUH2.GCPAbZFXOvUcdASswObnOmwTtNLnA = lTVFffdFdVKlCUAKLBqdrHDqcdfdb;
						return wfcsCBwWcQSLTyrGawXqOUrshHUH2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class PKrBMBIttFRAqKvEugqYYfIcEyoPA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int UUQFOWRMtyXVUpOJDZYUizrqOrVC;

					private ActionElementMap ulDsYkIEomEaQzeSioaqgGJIxmLc;

					private int UjwWLxOHDbxNzdYQzAwluLlUjgRL;

					private int SbJszprWKNjHMuwyrLPCOjYoADECA;

					public int SNylmTqcgGigFRryFfwkAZpJpUty;

					public MapHelper qgMJpFdEEFAdVxFUmrPuCLKvGymj;

					private ControllerType sKrFMuhNmXCOLqfvgLgtuMXEgaAib;

					public ControllerType KlTSZjpSxXLDVxMrOarjFGJBmXWn;

					private int aWhdiNwTyUwPOSjXiMHpOpwafxwfA;

					public int nHKGjcJLRbgYgdBKyvjfNPjpFiddA;

					private bool YcBrZnofOwkfLNmiwjYLgafLjoHHb;

					public bool jfibdghgIZnscdBbqNycqGgAtiIlA;

					private IList<ControllerMap> qkfuDinGVRrcXAXuMiiIjEtvxAxi;

					private int xcSFcjduyOfKXbyufLOKnbgMDFDJB;

					private IEnumerator<ActionElementMap> SYjEvNTSgpSBuxOcOUcUBwTRxRIl;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ulDsYkIEomEaQzeSioaqgGJIxmLc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ulDsYkIEomEaQzeSioaqgGJIxmLc;
						}
					}

					[DebuggerHidden]
					public PKrBMBIttFRAqKvEugqYYfIcEyoPA(int P_0)
					{
						UUQFOWRMtyXVUpOJDZYUizrqOrVC = P_0;
						UjwWLxOHDbxNzdYQzAwluLlUjgRL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int uUQFOWRMtyXVUpOJDZYUizrqOrVC = UUQFOWRMtyXVUpOJDZYUizrqOrVC;
						if (uUQFOWRMtyXVUpOJDZYUizrqOrVC == -3 || uUQFOWRMtyXVUpOJDZYUizrqOrVC == 1)
						{
							try
							{
							}
							finally
							{
								nPWUCfhUbqVtOirlzlZzBTjUESIu();
							}
						}
						qkfuDinGVRrcXAXuMiiIjEtvxAxi = null;
						SYjEvNTSgpSBuxOcOUcUBwTRxRIl = null;
						UUQFOWRMtyXVUpOJDZYUizrqOrVC = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int uUQFOWRMtyXVUpOJDZYUizrqOrVC = UUQFOWRMtyXVUpOJDZYUizrqOrVC;
							MapHelper mapHelper = qgMJpFdEEFAdVxFUmrPuCLKvGymj;
							if (uUQFOWRMtyXVUpOJDZYUizrqOrVC != 0)
							{
								if (uUQFOWRMtyXVUpOJDZYUizrqOrVC != 1)
								{
									return false;
								}
								UUQFOWRMtyXVUpOJDZYUizrqOrVC = -3;
								goto IL_012b;
							}
							UUQFOWRMtyXVUpOJDZYUizrqOrVC = -1;
							if (SbJszprWKNjHMuwyrLPCOjYoADECA < 0)
							{
								return false;
							}
							oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(sKrFMuhNmXCOLqfvgLgtuMXEgaAib);
							int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(aWhdiNwTyUwPOSjXiMHpOpwafxwfA);
							if (num < 0)
							{
								return false;
							}
							qkfuDinGVRrcXAXuMiiIjEtvxAxi = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
							xcSFcjduyOfKXbyufLOKnbgMDFDJB = 0;
							goto IL_0157;
							IL_012b:
							if (SYjEvNTSgpSBuxOcOUcUBwTRxRIl.MoveNext())
							{
								ActionElementMap current = SYjEvNTSgpSBuxOcOUcUBwTRxRIl.Current;
								ulDsYkIEomEaQzeSioaqgGJIxmLc = current;
								UUQFOWRMtyXVUpOJDZYUizrqOrVC = 1;
								return true;
							}
							nPWUCfhUbqVtOirlzlZzBTjUESIu();
							SYjEvNTSgpSBuxOcOUcUBwTRxRIl = null;
							goto IL_0145;
							IL_0157:
							if (xcSFcjduyOfKXbyufLOKnbgMDFDJB < qkfuDinGVRrcXAXuMiiIjEtvxAxi.Count)
							{
								if ((!YcBrZnofOwkfLNmiwjYLgafLjoHHb || qkfuDinGVRrcXAXuMiiIjEtvxAxi[xcSFcjduyOfKXbyufLOKnbgMDFDJB].enabled) && qkfuDinGVRrcXAXuMiiIjEtvxAxi[xcSFcjduyOfKXbyufLOKnbgMDFDJB].ContainsAction(SbJszprWKNjHMuwyrLPCOjYoADECA))
								{
									SYjEvNTSgpSBuxOcOUcUBwTRxRIl = qkfuDinGVRrcXAXuMiiIjEtvxAxi[xcSFcjduyOfKXbyufLOKnbgMDFDJB].ElementMapsWithAction(SbJszprWKNjHMuwyrLPCOjYoADECA, YcBrZnofOwkfLNmiwjYLgafLjoHHb).GetEnumerator();
									UUQFOWRMtyXVUpOJDZYUizrqOrVC = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							xcSFcjduyOfKXbyufLOKnbgMDFDJB++;
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

					private void nPWUCfhUbqVtOirlzlZzBTjUESIu()
					{
						UUQFOWRMtyXVUpOJDZYUizrqOrVC = -1;
						if (SYjEvNTSgpSBuxOcOUcUBwTRxRIl != null)
						{
							SYjEvNTSgpSBuxOcOUcUBwTRxRIl.Dispose();
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
						PKrBMBIttFRAqKvEugqYYfIcEyoPA pKrBMBIttFRAqKvEugqYYfIcEyoPA;
						if (UUQFOWRMtyXVUpOJDZYUizrqOrVC == -2 && UjwWLxOHDbxNzdYQzAwluLlUjgRL == Environment.CurrentManagedThreadId)
						{
							UUQFOWRMtyXVUpOJDZYUizrqOrVC = 0;
							pKrBMBIttFRAqKvEugqYYfIcEyoPA = this;
						}
						else
						{
							pKrBMBIttFRAqKvEugqYYfIcEyoPA = new PKrBMBIttFRAqKvEugqYYfIcEyoPA(0);
							pKrBMBIttFRAqKvEugqYYfIcEyoPA.qgMJpFdEEFAdVxFUmrPuCLKvGymj = qgMJpFdEEFAdVxFUmrPuCLKvGymj;
						}
						pKrBMBIttFRAqKvEugqYYfIcEyoPA.sKrFMuhNmXCOLqfvgLgtuMXEgaAib = KlTSZjpSxXLDVxMrOarjFGJBmXWn;
						pKrBMBIttFRAqKvEugqYYfIcEyoPA.aWhdiNwTyUwPOSjXiMHpOpwafxwfA = nHKGjcJLRbgYgdBKyvjfNPjpFiddA;
						pKrBMBIttFRAqKvEugqYYfIcEyoPA.SbJszprWKNjHMuwyrLPCOjYoADECA = SNylmTqcgGigFRryFfwkAZpJpUty;
						pKrBMBIttFRAqKvEugqYYfIcEyoPA.YcBrZnofOwkfLNmiwjYLgafLjoHHb = jfibdghgIZnscdBbqNycqGgAtiIlA;
						return pKrBMBIttFRAqKvEugqYYfIcEyoPA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class MBPLIoGKodVzJPSCngGMsSXihsQk : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int vPhUXUuaPdDRJcGMnfDKKksKiLsmA;

					private ControllerMap WgGtAdCjvdVirwWCFYKBdjQJfndm;

					private int MXryPfwaIRAYORYqNxqpUAhIfHBu;

					public MapHelper FGZCGRgUUsUgnNELxMmkevqsUeFB;

					private ControllerType rnfcNdNxTlZdDtZbIjSlTBHLburU;

					public ControllerType pVUyBVhuqpKLQhcKzaBjiwpWioVx;

					private int gYIQqKmtPRkbVuCHoxulkDrbFJRm;

					public int ficIBDFdVYeTUJMnCZYorUYThosoA;

					private int MBEHfZDOsSHKrARutdHntHAMLojkA;

					public int dgcqGlYlYTHikWntzTTUYzSLbnrl;

					private IList<ControllerMap> eeaTBJzhOYoCKaqtzYgxCAKtdJFBA;

					private int xYIypsKRUxhVQqKncbrmfSoXDMGR;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WgGtAdCjvdVirwWCFYKBdjQJfndm;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WgGtAdCjvdVirwWCFYKBdjQJfndm;
						}
					}

					[DebuggerHidden]
					public MBPLIoGKodVzJPSCngGMsSXihsQk(int P_0)
					{
						vPhUXUuaPdDRJcGMnfDKKksKiLsmA = P_0;
						MXryPfwaIRAYORYqNxqpUAhIfHBu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						eeaTBJzhOYoCKaqtzYgxCAKtdJFBA = null;
						vPhUXUuaPdDRJcGMnfDKKksKiLsmA = -2;
					}

					private bool MoveNext()
					{
						int num = vPhUXUuaPdDRJcGMnfDKKksKiLsmA;
						MapHelper fGZCGRgUUsUgnNELxMmkevqsUeFB = FGZCGRgUUsUgnNELxMmkevqsUeFB;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							vPhUXUuaPdDRJcGMnfDKKksKiLsmA = -1;
							goto IL_00b0;
						}
						vPhUXUuaPdDRJcGMnfDKKksKiLsmA = -1;
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = fGZCGRgUUsUgnNELxMmkevqsUeFB.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(rnfcNdNxTlZdDtZbIjSlTBHLburU);
						int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(gYIQqKmtPRkbVuCHoxulkDrbFJRm);
						if (num2 < 0)
						{
							return false;
						}
						eeaTBJzhOYoCKaqtzYgxCAKtdJFBA = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num2).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
						xYIypsKRUxhVQqKncbrmfSoXDMGR = 0;
						goto IL_00c2;
						IL_00c2:
						if (xYIypsKRUxhVQqKncbrmfSoXDMGR < eeaTBJzhOYoCKaqtzYgxCAKtdJFBA.Count)
						{
							if (eeaTBJzhOYoCKaqtzYgxCAKtdJFBA[xYIypsKRUxhVQqKncbrmfSoXDMGR].categoryId == MBEHfZDOsSHKrARutdHntHAMLojkA)
							{
								WgGtAdCjvdVirwWCFYKBdjQJfndm = eeaTBJzhOYoCKaqtzYgxCAKtdJFBA[xYIypsKRUxhVQqKncbrmfSoXDMGR];
								vPhUXUuaPdDRJcGMnfDKKksKiLsmA = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						xYIypsKRUxhVQqKncbrmfSoXDMGR++;
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
						MBPLIoGKodVzJPSCngGMsSXihsQk mBPLIoGKodVzJPSCngGMsSXihsQk;
						if (vPhUXUuaPdDRJcGMnfDKKksKiLsmA == -2 && MXryPfwaIRAYORYqNxqpUAhIfHBu == Environment.CurrentManagedThreadId)
						{
							vPhUXUuaPdDRJcGMnfDKKksKiLsmA = 0;
							mBPLIoGKodVzJPSCngGMsSXihsQk = this;
						}
						else
						{
							mBPLIoGKodVzJPSCngGMsSXihsQk = new MBPLIoGKodVzJPSCngGMsSXihsQk(0);
							mBPLIoGKodVzJPSCngGMsSXihsQk.FGZCGRgUUsUgnNELxMmkevqsUeFB = FGZCGRgUUsUgnNELxMmkevqsUeFB;
						}
						mBPLIoGKodVzJPSCngGMsSXihsQk.rnfcNdNxTlZdDtZbIjSlTBHLburU = pVUyBVhuqpKLQhcKzaBjiwpWioVx;
						mBPLIoGKodVzJPSCngGMsSXihsQk.gYIQqKmtPRkbVuCHoxulkDrbFJRm = ficIBDFdVYeTUJMnCZYorUYThosoA;
						mBPLIoGKodVzJPSCngGMsSXihsQk.MBEHfZDOsSHKrARutdHntHAMLojkA = dgcqGlYlYTHikWntzTTUYzSLbnrl;
						return mBPLIoGKodVzJPSCngGMsSXihsQk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class phtKbfPHuaelFAPbOhhDtVoCsWwcA<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int BqvDGQJCgAdkMGXkQMvcRGkSoJbt;

					private _0001 vyKgMObCDsrpCEbMCRKtmIPgDDbLB;

					private int uJjCAaifAfgrlGeYprFsNfYJcxpAA;

					public MapHelper gsNUXWRKEsPYsiZCIuNfbebNglqh;

					private int QDWLPZIrBCepEjJbxJUqeDhxbcng;

					public int ZUCzApWBKAGrCJxqmfCWOzLZwDOFA;

					private int KygFfBbAurljeemziwlFktWGbcXjA;

					public int AcsFCyaPlatjqXIRBMoTbwjjbqBe;

					private IList<_0001> QIIfJkHBAxEXdKPoJHzDbcBbHRyw;

					private int gstHmgmZfUEhkBkhFaQBjSKpaEidb;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return vyKgMObCDsrpCEbMCRKtmIPgDDbLB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vyKgMObCDsrpCEbMCRKtmIPgDDbLB;
						}
					}

					[DebuggerHidden]
					public phtKbfPHuaelFAPbOhhDtVoCsWwcA(int P_0)
					{
						BqvDGQJCgAdkMGXkQMvcRGkSoJbt = P_0;
						uJjCAaifAfgrlGeYprFsNfYJcxpAA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						QIIfJkHBAxEXdKPoJHzDbcBbHRyw = null;
						BqvDGQJCgAdkMGXkQMvcRGkSoJbt = -2;
					}

					private bool MoveNext()
					{
						int bqvDGQJCgAdkMGXkQMvcRGkSoJbt = BqvDGQJCgAdkMGXkQMvcRGkSoJbt;
						MapHelper mapHelper = gsNUXWRKEsPYsiZCIuNfbebNglqh;
						if (bqvDGQJCgAdkMGXkQMvcRGkSoJbt != 0)
						{
							if (bqvDGQJCgAdkMGXkQMvcRGkSoJbt != 1)
							{
								return false;
							}
							BqvDGQJCgAdkMGXkQMvcRGkSoJbt = -1;
							goto IL_00b9;
						}
						BqvDGQJCgAdkMGXkQMvcRGkSoJbt = -1;
						ControllerType controllerType = bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<_0001>();
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(QDWLPZIrBCepEjJbxJUqeDhxbcng);
						if (num < 0)
						{
							return false;
						}
						QIIfJkHBAxEXdKPoJHzDbcBbHRyw = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.UVMfVDFkzMYcRREfXCclhxjeHNlXb<_0001>();
						gstHmgmZfUEhkBkhFaQBjSKpaEidb = 0;
						goto IL_00cb;
						IL_00cb:
						if (gstHmgmZfUEhkBkhFaQBjSKpaEidb < QIIfJkHBAxEXdKPoJHzDbcBbHRyw.Count)
						{
							if (QIIfJkHBAxEXdKPoJHzDbcBbHRyw[gstHmgmZfUEhkBkhFaQBjSKpaEidb].categoryId == KygFfBbAurljeemziwlFktWGbcXjA)
							{
								vyKgMObCDsrpCEbMCRKtmIPgDDbLB = QIIfJkHBAxEXdKPoJHzDbcBbHRyw[gstHmgmZfUEhkBkhFaQBjSKpaEidb];
								BqvDGQJCgAdkMGXkQMvcRGkSoJbt = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						gstHmgmZfUEhkBkhFaQBjSKpaEidb++;
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
						phtKbfPHuaelFAPbOhhDtVoCsWwcA<_0001> phtKbfPHuaelFAPbOhhDtVoCsWwcA2;
						if (BqvDGQJCgAdkMGXkQMvcRGkSoJbt == -2 && uJjCAaifAfgrlGeYprFsNfYJcxpAA == Environment.CurrentManagedThreadId)
						{
							BqvDGQJCgAdkMGXkQMvcRGkSoJbt = 0;
							phtKbfPHuaelFAPbOhhDtVoCsWwcA2 = this;
						}
						else
						{
							phtKbfPHuaelFAPbOhhDtVoCsWwcA2 = new phtKbfPHuaelFAPbOhhDtVoCsWwcA<_0001>(0);
							phtKbfPHuaelFAPbOhhDtVoCsWwcA2.gsNUXWRKEsPYsiZCIuNfbebNglqh = gsNUXWRKEsPYsiZCIuNfbebNglqh;
						}
						phtKbfPHuaelFAPbOhhDtVoCsWwcA2.QDWLPZIrBCepEjJbxJUqeDhxbcng = ZUCzApWBKAGrCJxqmfCWOzLZwDOFA;
						phtKbfPHuaelFAPbOhhDtVoCsWwcA2.KygFfBbAurljeemziwlFktWGbcXjA = AcsFCyaPlatjqXIRBMoTbwjjbqBe;
						return phtKbfPHuaelFAPbOhhDtVoCsWwcA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class ldHRAjXJVaRBcYRfIlkjJMLAJeJCA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int neuERgcjTKYJsmCEYADBTkQJHTn;

					private ActionElementMap JzfEFtaguoZKTSuIlLUHmPjIwmPhA;

					private int VygqwCQgHorNFKRYwMkRhRyPCAHv;

					public MapHelper pILbmhooUpepaMJgfodaINzQWaTb;

					private int lePpegigPIhljmxSZBCVPBkVjkol;

					public int SVKQqNZPLqWWGNFiGjVbhcuPbnveb;

					private bool OfgnocCEZQObhBZuTiBidxrwleMr;

					public bool FeiZWuDNYsiLdABwKtMhQOsVDkAh;

					private int MdHBSfCHTRyNXWaOpcQDtCBdNarIb;

					private int AralLidcUNAfFgjvZdXLCRWTkHDsA;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb floHexHDrGXkSkgAtOrHuiECOZcw;

					private int oEGTXChmgtnGowPbPPCZjkrSLMzv;

					private int OzfVeghyxNAfbvHiWhYZGcIEmdiXA;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA xtyCtzAqawuCpCtHsDqBgkzBVnPjc;

					private int mVXmhZPSNwPJYFbiNIIYSMKBcinKA;

					private int LwIbZYXYiLJuiuDQAjrbogOnBgPHA;

					private IEnumerator<ActionElementMap> JgNPhGblCbEBPEJDhvHYZdKuDSzeA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return JzfEFtaguoZKTSuIlLUHmPjIwmPhA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JzfEFtaguoZKTSuIlLUHmPjIwmPhA;
						}
					}

					[DebuggerHidden]
					public ldHRAjXJVaRBcYRfIlkjJMLAJeJCA(int P_0)
					{
						neuERgcjTKYJsmCEYADBTkQJHTn = P_0;
						VygqwCQgHorNFKRYwMkRhRyPCAHv = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = neuERgcjTKYJsmCEYADBTkQJHTn;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								lNAFYKcFCvwvvfOMSoOoEPULMdxjA();
							}
						}
						floHexHDrGXkSkgAtOrHuiECOZcw = null;
						xtyCtzAqawuCpCtHsDqBgkzBVnPjc = null;
						JgNPhGblCbEBPEJDhvHYZdKuDSzeA = null;
						neuERgcjTKYJsmCEYADBTkQJHTn = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = neuERgcjTKYJsmCEYADBTkQJHTn;
							MapHelper mapHelper = pILbmhooUpepaMJgfodaINzQWaTb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								neuERgcjTKYJsmCEYADBTkQJHTn = -3;
								goto IL_016c;
							}
							neuERgcjTKYJsmCEYADBTkQJHTn = -1;
							if (ReInput._id != mapHelper.JUxUMkAhrDjRItbYUWjYRNgFpzir)
							{
								ReInput.CheckInitialized(mapHelper.JUxUMkAhrDjRItbYUWjYRNgFpzir);
								return false;
							}
							if (lePpegigPIhljmxSZBCVPBkVjkol < 0)
							{
								return false;
							}
							MdHBSfCHTRyNXWaOpcQDtCBdNarIb = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
							AralLidcUNAfFgjvZdXLCRWTkHDsA = 0;
							goto IL_01ec;
							IL_016c:
							if (JgNPhGblCbEBPEJDhvHYZdKuDSzeA.MoveNext())
							{
								ActionElementMap current = JgNPhGblCbEBPEJDhvHYZdKuDSzeA.Current;
								JzfEFtaguoZKTSuIlLUHmPjIwmPhA = current;
								neuERgcjTKYJsmCEYADBTkQJHTn = 1;
								return true;
							}
							lNAFYKcFCvwvvfOMSoOoEPULMdxjA();
							JgNPhGblCbEBPEJDhvHYZdKuDSzeA = null;
							goto IL_0186;
							IL_0186:
							LwIbZYXYiLJuiuDQAjrbogOnBgPHA++;
							goto IL_0198;
							IL_01c2:
							if (OzfVeghyxNAfbvHiWhYZGcIEmdiXA < oEGTXChmgtnGowPbPPCZjkrSLMzv)
							{
								xtyCtzAqawuCpCtHsDqBgkzBVnPjc = floHexHDrGXkSkgAtOrHuiECOZcw.LNTBMmjuONFUBLurbFbXivzHrdyGb(OzfVeghyxNAfbvHiWhYZGcIEmdiXA).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								mVXmhZPSNwPJYFbiNIIYSMKBcinKA = xtyCtzAqawuCpCtHsDqBgkzBVnPjc.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								LwIbZYXYiLJuiuDQAjrbogOnBgPHA = 0;
								goto IL_0198;
							}
							floHexHDrGXkSkgAtOrHuiECOZcw = null;
							AralLidcUNAfFgjvZdXLCRWTkHDsA++;
							goto IL_01ec;
							IL_0198:
							if (LwIbZYXYiLJuiuDQAjrbogOnBgPHA < mVXmhZPSNwPJYFbiNIIYSMKBcinKA)
							{
								ControllerMap controllerMap = xtyCtzAqawuCpCtHsDqBgkzBVnPjc.tMPEVPdgqovMveUHOiirPevVOylqA(LwIbZYXYiLJuiuDQAjrbogOnBgPHA);
								if ((!OfgnocCEZQObhBZuTiBidxrwleMr || controllerMap.enabled) && controllerMap.ContainsAction(lePpegigPIhljmxSZBCVPBkVjkol))
								{
									JgNPhGblCbEBPEJDhvHYZdKuDSzeA = controllerMap.ElementMapsWithAction(lePpegigPIhljmxSZBCVPBkVjkol, OfgnocCEZQObhBZuTiBidxrwleMr).GetEnumerator();
									neuERgcjTKYJsmCEYADBTkQJHTn = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							xtyCtzAqawuCpCtHsDqBgkzBVnPjc = null;
							OzfVeghyxNAfbvHiWhYZGcIEmdiXA++;
							goto IL_01c2;
							IL_01ec:
							if (AralLidcUNAfFgjvZdXLCRWTkHDsA < MdHBSfCHTRyNXWaOpcQDtCBdNarIb)
							{
								floHexHDrGXkSkgAtOrHuiECOZcw = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(AralLidcUNAfFgjvZdXLCRWTkHDsA);
								oEGTXChmgtnGowPbPPCZjkrSLMzv = floHexHDrGXkSkgAtOrHuiECOZcw.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
								OzfVeghyxNAfbvHiWhYZGcIEmdiXA = 0;
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

					private void lNAFYKcFCvwvvfOMSoOoEPULMdxjA()
					{
						neuERgcjTKYJsmCEYADBTkQJHTn = -1;
						if (JgNPhGblCbEBPEJDhvHYZdKuDSzeA != null)
						{
							JgNPhGblCbEBPEJDhvHYZdKuDSzeA.Dispose();
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
						ldHRAjXJVaRBcYRfIlkjJMLAJeJCA ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2;
						if (neuERgcjTKYJsmCEYADBTkQJHTn == -2 && VygqwCQgHorNFKRYwMkRhRyPCAHv == Environment.CurrentManagedThreadId)
						{
							neuERgcjTKYJsmCEYADBTkQJHTn = 0;
							ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2 = this;
						}
						else
						{
							ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2 = new ldHRAjXJVaRBcYRfIlkjJMLAJeJCA(0);
							ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2.pILbmhooUpepaMJgfodaINzQWaTb = pILbmhooUpepaMJgfodaINzQWaTb;
						}
						ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2.lePpegigPIhljmxSZBCVPBkVjkol = SVKQqNZPLqWWGNFiGjVbhcuPbnveb;
						ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2.OfgnocCEZQObhBZuTiBidxrwleMr = FeiZWuDNYsiLdABwKtMhQOsVDkAh;
						return ldHRAjXJVaRBcYRfIlkjJMLAJeJCA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class IgYCiWjAkUvZcAbzOSxvuGtubauw : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int TqOLnADYxXxfqARRHZBcMVxHQliJ;

					private ActionElementMap ozBcGoMxHGgWauQttAqAjrJIUAPj;

					private int sNlKNQAXLymmFaQBpsjSGVacfDZA;

					private IControllerElementTarget zFeEzYryGvqDONvlbwpylEouJRjF;

					public IControllerElementTarget EcLftAhHxqFjwCHRdpojjrglAadFb;

					public MapHelper LQAChaaBMEXhCvwHueNqOLqjRLRVA;

					private bool xIaiqXDTqHLftQNZyklFygFvlHbi;

					public bool iVUErOuKQEgYsdNpxLeHWpoDrihf;

					private bool zADchEFfmGZdTwFXCcpXuXQaviRJ;

					public bool AeLGOPaRfxFBcCQFauiZLRhXpQuW;

					private int KhJYxreYkNZOesnnZMnqoalFEXOF;

					public int axSTPfGKnqGMnKMfkRKRLwPxCpOL;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb MJAIxrYmJzVIauDYwQYrvpMQVdQV;

					private int fsHtOWfqmCSdsnWbgIzSwEezVTGP;

					private int KTOdMxhdfiLOegrEXjqjjdvAOHWFA;

					private IList<ControllerMap> ECCBIgYNmjYPgjmxHnvRdetlzjfG;

					private int HdSwsBDbNCUylLwrZVPHBrYztSrr;

					private int bwlTGJFGnxSqKDOcngnqbkrxkTMj;

					private TempListPool.TList<ActionElementMap> DnMehfwSGqjwfSQCXPcUqwZpdwjg;

					private List<ActionElementMap>.Enumerator ngIQWpcsakNhjOpXGBidYCumJaXj;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ozBcGoMxHGgWauQttAqAjrJIUAPj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ozBcGoMxHGgWauQttAqAjrJIUAPj;
						}
					}

					[DebuggerHidden]
					public IgYCiWjAkUvZcAbzOSxvuGtubauw(int P_0)
					{
						TqOLnADYxXxfqARRHZBcMVxHQliJ = P_0;
						sNlKNQAXLymmFaQBpsjSGVacfDZA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int tqOLnADYxXxfqARRHZBcMVxHQliJ = TqOLnADYxXxfqARRHZBcMVxHQliJ;
						if ((uint)(tqOLnADYxXxfqARRHZBcMVxHQliJ - -4) <= 1u || tqOLnADYxXxfqARRHZBcMVxHQliJ == 1)
						{
							try
							{
								if (tqOLnADYxXxfqARRHZBcMVxHQliJ == -4 || tqOLnADYxXxfqARRHZBcMVxHQliJ == 1)
								{
									try
									{
									}
									finally
									{
										fVZQEQzkLLgrNwPSsyGQmnZpZnym();
									}
								}
							}
							finally
							{
								icKfeRcbTmCEVcQkPaxdYXoGCbTab();
							}
						}
						MJAIxrYmJzVIauDYwQYrvpMQVdQV = null;
						ECCBIgYNmjYPgjmxHnvRdetlzjfG = null;
						DnMehfwSGqjwfSQCXPcUqwZpdwjg = null;
						ngIQWpcsakNhjOpXGBidYCumJaXj = default(List<ActionElementMap>.Enumerator);
						TqOLnADYxXxfqARRHZBcMVxHQliJ = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int tqOLnADYxXxfqARRHZBcMVxHQliJ = TqOLnADYxXxfqARRHZBcMVxHQliJ;
							MapHelper lQAChaaBMEXhCvwHueNqOLqjRLRVA = LQAChaaBMEXhCvwHueNqOLqjRLRVA;
							if (tqOLnADYxXxfqARRHZBcMVxHQliJ != 0)
							{
								if (tqOLnADYxXxfqARRHZBcMVxHQliJ != 1)
								{
									return false;
								}
								TqOLnADYxXxfqARRHZBcMVxHQliJ = -4;
								goto IL_017c;
							}
							TqOLnADYxXxfqARRHZBcMVxHQliJ = -1;
							if (zFeEzYryGvqDONvlbwpylEouJRjF == null)
							{
								return false;
							}
							Controller controller = zFeEzYryGvqDONvlbwpylEouJRjF.controller;
							if (controller == null)
							{
								return false;
							}
							MJAIxrYmJzVIauDYwQYrvpMQVdQV = lQAChaaBMEXhCvwHueNqOLqjRLRVA.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controller.type);
							fsHtOWfqmCSdsnWbgIzSwEezVTGP = MJAIxrYmJzVIauDYwQYrvpMQVdQV.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							KTOdMxhdfiLOegrEXjqjjdvAOHWFA = 0;
							goto IL_01e4;
							IL_017c:
							if (ngIQWpcsakNhjOpXGBidYCumJaXj.MoveNext())
							{
								ActionElementMap current = ngIQWpcsakNhjOpXGBidYCumJaXj.Current;
								ozBcGoMxHGgWauQttAqAjrJIUAPj = current;
								TqOLnADYxXxfqARRHZBcMVxHQliJ = 1;
								return true;
							}
							fVZQEQzkLLgrNwPSsyGQmnZpZnym();
							ngIQWpcsakNhjOpXGBidYCumJaXj = default(List<ActionElementMap>.Enumerator);
							icKfeRcbTmCEVcQkPaxdYXoGCbTab();
							DnMehfwSGqjwfSQCXPcUqwZpdwjg = null;
							goto IL_01a8;
							IL_01e4:
							if (KTOdMxhdfiLOegrEXjqjjdvAOHWFA < fsHtOWfqmCSdsnWbgIzSwEezVTGP)
							{
								wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = MJAIxrYmJzVIauDYwQYrvpMQVdQV.LNTBMmjuONFUBLurbFbXivzHrdyGb(KTOdMxhdfiLOegrEXjqjjdvAOHWFA).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								_ = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								ECCBIgYNmjYPgjmxHnvRdetlzjfG = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
								HdSwsBDbNCUylLwrZVPHBrYztSrr = ECCBIgYNmjYPgjmxHnvRdetlzjfG.Count;
								bwlTGJFGnxSqKDOcngnqbkrxkTMj = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (bwlTGJFGnxSqKDOcngnqbkrxkTMj < HdSwsBDbNCUylLwrZVPHBrYztSrr)
							{
								ControllerMap controllerMap = ECCBIgYNmjYPgjmxHnvRdetlzjfG[bwlTGJFGnxSqKDOcngnqbkrxkTMj];
								if (!xIaiqXDTqHLftQNZyklFygFvlHbi || controllerMap.enabled)
								{
									DnMehfwSGqjwfSQCXPcUqwZpdwjg = TempListPool.GetTList<ActionElementMap>();
									TqOLnADYxXxfqARRHZBcMVxHQliJ = -3;
									List<ActionElementMap> list = DnMehfwSGqjwfSQCXPcUqwZpdwjg.list;
									controllerMap.xVXvATEIJOyARtowfnOzbVGdtuAe(zFeEzYryGvqDONvlbwpylEouJRjF, zADchEFfmGZdTwFXCcpXuXQaviRJ, KhJYxreYkNZOesnnZMnqoalFEXOF, xIaiqXDTqHLftQNZyklFygFvlHbi, list, true, out var _);
									ngIQWpcsakNhjOpXGBidYCumJaXj = list.GetEnumerator();
									TqOLnADYxXxfqARRHZBcMVxHQliJ = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							ECCBIgYNmjYPgjmxHnvRdetlzjfG = null;
							KTOdMxhdfiLOegrEXjqjjdvAOHWFA++;
							goto IL_01e4;
							IL_01a8:
							bwlTGJFGnxSqKDOcngnqbkrxkTMj++;
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

					private void icKfeRcbTmCEVcQkPaxdYXoGCbTab()
					{
						TqOLnADYxXxfqARRHZBcMVxHQliJ = -1;
						if (DnMehfwSGqjwfSQCXPcUqwZpdwjg != null)
						{
							((IDisposable)DnMehfwSGqjwfSQCXPcUqwZpdwjg).Dispose();
						}
					}

					private void fVZQEQzkLLgrNwPSsyGQmnZpZnym()
					{
						TqOLnADYxXxfqARRHZBcMVxHQliJ = -3;
						((IDisposable)ngIQWpcsakNhjOpXGBidYCumJaXj/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						IgYCiWjAkUvZcAbzOSxvuGtubauw igYCiWjAkUvZcAbzOSxvuGtubauw;
						if (TqOLnADYxXxfqARRHZBcMVxHQliJ == -2 && sNlKNQAXLymmFaQBpsjSGVacfDZA == Environment.CurrentManagedThreadId)
						{
							TqOLnADYxXxfqARRHZBcMVxHQliJ = 0;
							igYCiWjAkUvZcAbzOSxvuGtubauw = this;
						}
						else
						{
							igYCiWjAkUvZcAbzOSxvuGtubauw = new IgYCiWjAkUvZcAbzOSxvuGtubauw(0);
							igYCiWjAkUvZcAbzOSxvuGtubauw.LQAChaaBMEXhCvwHueNqOLqjRLRVA = LQAChaaBMEXhCvwHueNqOLqjRLRVA;
						}
						igYCiWjAkUvZcAbzOSxvuGtubauw.zFeEzYryGvqDONvlbwpylEouJRjF = EcLftAhHxqFjwCHRdpojjrglAadFb;
						igYCiWjAkUvZcAbzOSxvuGtubauw.zADchEFfmGZdTwFXCcpXuXQaviRJ = AeLGOPaRfxFBcCQFauiZLRhXpQuW;
						igYCiWjAkUvZcAbzOSxvuGtubauw.KhJYxreYkNZOesnnZMnqoalFEXOF = axSTPfGKnqGMnKMfkRKRLwPxCpOL;
						igYCiWjAkUvZcAbzOSxvuGtubauw.xIaiqXDTqHLftQNZyklFygFvlHbi = iVUErOuKQEgYsdNpxLeHWpoDrihf;
						return igYCiWjAkUvZcAbzOSxvuGtubauw;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class NHlCdCQHdgOuIJiJKMxhDOpRcAIv : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int iuSXwGevpMPgjochrdySDRxWVfjpA;

					private ControllerMap qgkhiVXtBpxFgDjUkGtwuBIJXMQD;

					private int hVpGplFUDLlcvgnVhNDLhbcSJkyW;

					public MapHelper BOibeIbfpBJGQveyETOzaDTUeenFb;

					private int MSDzLGhIwZKnjPaUvgtSeEsMBWNW;

					private int tAoRcZeOcshtJFVqblvGavvcQeewA;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb rGEWQhDZpddYJPkffSCfdmtDjCPU;

					private int pSQqayAqZQFdrEpCgohaHEpXTGZVA;

					private int jHjbpVzDoGeFnfLzNkumZLYZbHVRA;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA bDblTQkSHicvlBxcEJpADkHPExqh;

					private int PEmgeDhXXhrRmDpnkLKHyvvRYQQaA;

					private int zHKomRHbjUIwPqUNAjfbiJgBanhK;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return qgkhiVXtBpxFgDjUkGtwuBIJXMQD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qgkhiVXtBpxFgDjUkGtwuBIJXMQD;
						}
					}

					[DebuggerHidden]
					public NHlCdCQHdgOuIJiJKMxhDOpRcAIv(int P_0)
					{
						iuSXwGevpMPgjochrdySDRxWVfjpA = P_0;
						hVpGplFUDLlcvgnVhNDLhbcSJkyW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						rGEWQhDZpddYJPkffSCfdmtDjCPU = null;
						bDblTQkSHicvlBxcEJpADkHPExqh = null;
						iuSXwGevpMPgjochrdySDRxWVfjpA = -2;
					}

					private bool MoveNext()
					{
						int num = iuSXwGevpMPgjochrdySDRxWVfjpA;
						MapHelper bOibeIbfpBJGQveyETOzaDTUeenFb = BOibeIbfpBJGQveyETOzaDTUeenFb;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							iuSXwGevpMPgjochrdySDRxWVfjpA = -1;
							zHKomRHbjUIwPqUNAjfbiJgBanhK++;
							goto IL_0104;
						}
						iuSXwGevpMPgjochrdySDRxWVfjpA = -1;
						if (ReInput._id != bOibeIbfpBJGQveyETOzaDTUeenFb.JUxUMkAhrDjRItbYUWjYRNgFpzir)
						{
							ReInput.CheckInitialized(bOibeIbfpBJGQveyETOzaDTUeenFb.JUxUMkAhrDjRItbYUWjYRNgFpzir);
							return false;
						}
						MSDzLGhIwZKnjPaUvgtSeEsMBWNW = bOibeIbfpBJGQveyETOzaDTUeenFb.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
						tAoRcZeOcshtJFVqblvGavvcQeewA = 0;
						goto IL_0151;
						IL_0104:
						if (zHKomRHbjUIwPqUNAjfbiJgBanhK < PEmgeDhXXhrRmDpnkLKHyvvRYQQaA)
						{
							qgkhiVXtBpxFgDjUkGtwuBIJXMQD = bDblTQkSHicvlBxcEJpADkHPExqh.tMPEVPdgqovMveUHOiirPevVOylqA(zHKomRHbjUIwPqUNAjfbiJgBanhK);
							iuSXwGevpMPgjochrdySDRxWVfjpA = 1;
							return true;
						}
						bDblTQkSHicvlBxcEJpADkHPExqh = null;
						jHjbpVzDoGeFnfLzNkumZLYZbHVRA++;
						goto IL_0129;
						IL_0129:
						if (jHjbpVzDoGeFnfLzNkumZLYZbHVRA < pSQqayAqZQFdrEpCgohaHEpXTGZVA)
						{
							bDblTQkSHicvlBxcEJpADkHPExqh = rGEWQhDZpddYJPkffSCfdmtDjCPU.LNTBMmjuONFUBLurbFbXivzHrdyGb(jHjbpVzDoGeFnfLzNkumZLYZbHVRA).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							PEmgeDhXXhrRmDpnkLKHyvvRYQQaA = bDblTQkSHicvlBxcEJpADkHPExqh.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							zHKomRHbjUIwPqUNAjfbiJgBanhK = 0;
							goto IL_0104;
						}
						rGEWQhDZpddYJPkffSCfdmtDjCPU = null;
						tAoRcZeOcshtJFVqblvGavvcQeewA++;
						goto IL_0151;
						IL_0151:
						if (tAoRcZeOcshtJFVqblvGavvcQeewA < MSDzLGhIwZKnjPaUvgtSeEsMBWNW)
						{
							rGEWQhDZpddYJPkffSCfdmtDjCPU = bOibeIbfpBJGQveyETOzaDTUeenFb.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(tAoRcZeOcshtJFVqblvGavvcQeewA);
							pSQqayAqZQFdrEpCgohaHEpXTGZVA = rGEWQhDZpddYJPkffSCfdmtDjCPU.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							jHjbpVzDoGeFnfLzNkumZLYZbHVRA = 0;
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
						NHlCdCQHdgOuIJiJKMxhDOpRcAIv nHlCdCQHdgOuIJiJKMxhDOpRcAIv;
						if (iuSXwGevpMPgjochrdySDRxWVfjpA == -2 && hVpGplFUDLlcvgnVhNDLhbcSJkyW == Environment.CurrentManagedThreadId)
						{
							iuSXwGevpMPgjochrdySDRxWVfjpA = 0;
							nHlCdCQHdgOuIJiJKMxhDOpRcAIv = this;
						}
						else
						{
							nHlCdCQHdgOuIJiJKMxhDOpRcAIv = new NHlCdCQHdgOuIJiJKMxhDOpRcAIv(0);
							nHlCdCQHdgOuIJiJKMxhDOpRcAIv.BOibeIbfpBJGQveyETOzaDTUeenFb = BOibeIbfpBJGQveyETOzaDTUeenFb;
						}
						return nHlCdCQHdgOuIJiJKMxhDOpRcAIv;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class WGyeulCQftCltoHnPJVSuORRXdPM<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int tjCtTBCsWKGuybpQYIqhvBnriAjM;

					private _0001 vyGWfbHfRNgfFbhfqhUibEELyswJA;

					private int yjmAbBvforBujbEgrMGBwJEaxoki;

					public MapHelper ncgpeQPdsstUNnURNPfkYEmsvekL;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb GWUEYpesbiMYVUPwKJpquarbLAMnA;

					private int LemgXWgOURMLQexHozZyueeOIujPA;

					private int CbcjYuVAMYQFOGAhSGVHgUuCrbwW;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA xQeYkXdIsZMxSPHRuHLtJdBBIjNl;

					private int uwWqFTGGgszFJSWJzudghoqTANWK;

					private int hVcbGGMgJWZlulsebuDkRxqRfJu;

					private int jYJkKqyUCloJRjTUGsOYTtavhBbb;

					private int hXFeAxFoEEFQBvSoVkvCnzyhUGGX;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return vyGWfbHfRNgfFbhfqhUibEELyswJA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vyGWfbHfRNgfFbhfqhUibEELyswJA;
						}
					}

					[DebuggerHidden]
					public WGyeulCQftCltoHnPJVSuORRXdPM(int P_0)
					{
						tjCtTBCsWKGuybpQYIqhvBnriAjM = P_0;
						yjmAbBvforBujbEgrMGBwJEaxoki = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						GWUEYpesbiMYVUPwKJpquarbLAMnA = null;
						xQeYkXdIsZMxSPHRuHLtJdBBIjNl = null;
						tjCtTBCsWKGuybpQYIqhvBnriAjM = -2;
					}

					private bool MoveNext()
					{
						int num = tjCtTBCsWKGuybpQYIqhvBnriAjM;
						MapHelper mapHelper = ncgpeQPdsstUNnURNPfkYEmsvekL;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							tjCtTBCsWKGuybpQYIqhvBnriAjM = -1;
							if (ReInput._id != mapHelper.JUxUMkAhrDjRItbYUWjYRNgFpzir)
							{
								ReInput.CheckInitialized(mapHelper.JUxUMkAhrDjRItbYUWjYRNgFpzir);
								return false;
							}
							if (bVcNkmaJvbHeBNQRpaleQvWHeXqv.RkpAQNVHmMMuVLgUrSmQLXsfjnGE<_0001>(out var controllerType))
							{
								GWUEYpesbiMYVUPwKJpquarbLAMnA = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
								LemgXWgOURMLQexHozZyueeOIujPA = GWUEYpesbiMYVUPwKJpquarbLAMnA.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
								CbcjYuVAMYQFOGAhSGVHgUuCrbwW = 0;
								goto IL_011b;
							}
							LemgXWgOURMLQexHozZyueeOIujPA = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
							CbcjYuVAMYQFOGAhSGVHgUuCrbwW = 0;
							goto IL_0264;
						}
						case 1:
							tjCtTBCsWKGuybpQYIqhvBnriAjM = -1;
							hVcbGGMgJWZlulsebuDkRxqRfJu++;
							goto IL_00f6;
						case 2:
							{
								tjCtTBCsWKGuybpQYIqhvBnriAjM = -1;
								goto IL_0207;
							}
							IL_0207:
							hXFeAxFoEEFQBvSoVkvCnzyhUGGX++;
							goto IL_0217;
							IL_0264:
							if (CbcjYuVAMYQFOGAhSGVHgUuCrbwW >= LemgXWgOURMLQexHozZyueeOIujPA)
							{
								break;
							}
							GWUEYpesbiMYVUPwKJpquarbLAMnA = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(CbcjYuVAMYQFOGAhSGVHgUuCrbwW);
							uwWqFTGGgszFJSWJzudghoqTANWK = GWUEYpesbiMYVUPwKJpquarbLAMnA.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							hVcbGGMgJWZlulsebuDkRxqRfJu = 0;
							goto IL_023c;
							IL_011b:
							if (CbcjYuVAMYQFOGAhSGVHgUuCrbwW < LemgXWgOURMLQexHozZyueeOIujPA)
							{
								xQeYkXdIsZMxSPHRuHLtJdBBIjNl = GWUEYpesbiMYVUPwKJpquarbLAMnA.LNTBMmjuONFUBLurbFbXivzHrdyGb(CbcjYuVAMYQFOGAhSGVHgUuCrbwW).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								uwWqFTGGgszFJSWJzudghoqTANWK = xQeYkXdIsZMxSPHRuHLtJdBBIjNl.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								hVcbGGMgJWZlulsebuDkRxqRfJu = 0;
								goto IL_00f6;
							}
							GWUEYpesbiMYVUPwKJpquarbLAMnA = null;
							break;
							IL_0217:
							if (hXFeAxFoEEFQBvSoVkvCnzyhUGGX < jYJkKqyUCloJRjTUGsOYTtavhBbb)
							{
								if (xQeYkXdIsZMxSPHRuHLtJdBBIjNl.tMPEVPdgqovMveUHOiirPevVOylqA(hXFeAxFoEEFQBvSoVkvCnzyhUGGX) is _0001 val)
								{
									vyGWfbHfRNgfFbhfqhUibEELyswJA = val;
									tjCtTBCsWKGuybpQYIqhvBnriAjM = 2;
									return true;
								}
								goto IL_0207;
							}
							xQeYkXdIsZMxSPHRuHLtJdBBIjNl = null;
							hVcbGGMgJWZlulsebuDkRxqRfJu++;
							goto IL_023c;
							IL_023c:
							if (hVcbGGMgJWZlulsebuDkRxqRfJu < uwWqFTGGgszFJSWJzudghoqTANWK)
							{
								xQeYkXdIsZMxSPHRuHLtJdBBIjNl = GWUEYpesbiMYVUPwKJpquarbLAMnA.LNTBMmjuONFUBLurbFbXivzHrdyGb(hVcbGGMgJWZlulsebuDkRxqRfJu).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								jYJkKqyUCloJRjTUGsOYTtavhBbb = xQeYkXdIsZMxSPHRuHLtJdBBIjNl.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								hXFeAxFoEEFQBvSoVkvCnzyhUGGX = 0;
								goto IL_0217;
							}
							GWUEYpesbiMYVUPwKJpquarbLAMnA = null;
							CbcjYuVAMYQFOGAhSGVHgUuCrbwW++;
							goto IL_0264;
							IL_00f6:
							if (hVcbGGMgJWZlulsebuDkRxqRfJu < uwWqFTGGgszFJSWJzudghoqTANWK)
							{
								vyGWfbHfRNgfFbhfqhUibEELyswJA = (_0001)xQeYkXdIsZMxSPHRuHLtJdBBIjNl.tMPEVPdgqovMveUHOiirPevVOylqA(hVcbGGMgJWZlulsebuDkRxqRfJu);
								tjCtTBCsWKGuybpQYIqhvBnriAjM = 1;
								return true;
							}
							xQeYkXdIsZMxSPHRuHLtJdBBIjNl = null;
							CbcjYuVAMYQFOGAhSGVHgUuCrbwW++;
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
						WGyeulCQftCltoHnPJVSuORRXdPM<_0001> wGyeulCQftCltoHnPJVSuORRXdPM;
						if (tjCtTBCsWKGuybpQYIqhvBnriAjM == -2 && yjmAbBvforBujbEgrMGBwJEaxoki == Environment.CurrentManagedThreadId)
						{
							tjCtTBCsWKGuybpQYIqhvBnriAjM = 0;
							wGyeulCQftCltoHnPJVSuORRXdPM = this;
						}
						else
						{
							wGyeulCQftCltoHnPJVSuORRXdPM = new WGyeulCQftCltoHnPJVSuORRXdPM<_0001>(0);
							wGyeulCQftCltoHnPJVSuORRXdPM.ncgpeQPdsstUNnURNPfkYEmsvekL = ncgpeQPdsstUNnURNPfkYEmsvekL;
						}
						return wGyeulCQftCltoHnPJVSuORRXdPM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class oTgmaTevUlYrPPhgNBSxFAdcOcSB : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int QfMrvbIzRaLLxlevOkgeeebCSJfw;

					private ControllerMap FzbMuHyJPJdRKtUmZosiKtZZRmlM;

					private int ZvbSDmzKVuZzvVPJySKwyhpWCBhjA;

					public MapHelper oKaSPSpvVgfiyNPXJrjNDoiGAFBGA;

					private ControllerType ocmUuXbEXjgJwpyyLwvVaCdcTLqF;

					public ControllerType nlkTdIFLFUTfhpvYgMjKXroSkOfh;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb bXOpJbZkWZybSIwGodJlsAdRlnMH;

					private int wJLdsijLqNfimNzIvaxAqEWOcIZJA;

					private int hHiRCIEgLhcQVdVnZYCNQkKIXlEUA;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA AuTYHgiJTWHjUzjRkEkDJQuHcFoJA;

					private int UbuTmDWNAyTFmhFVvTLJcVFycAji;

					private int jSiCjCAzYsprzefosNEmWUDIpahSA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return FzbMuHyJPJdRKtUmZosiKtZZRmlM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FzbMuHyJPJdRKtUmZosiKtZZRmlM;
						}
					}

					[DebuggerHidden]
					public oTgmaTevUlYrPPhgNBSxFAdcOcSB(int P_0)
					{
						QfMrvbIzRaLLxlevOkgeeebCSJfw = P_0;
						ZvbSDmzKVuZzvVPJySKwyhpWCBhjA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						bXOpJbZkWZybSIwGodJlsAdRlnMH = null;
						AuTYHgiJTWHjUzjRkEkDJQuHcFoJA = null;
						QfMrvbIzRaLLxlevOkgeeebCSJfw = -2;
					}

					private bool MoveNext()
					{
						int qfMrvbIzRaLLxlevOkgeeebCSJfw = QfMrvbIzRaLLxlevOkgeeebCSJfw;
						MapHelper mapHelper = oKaSPSpvVgfiyNPXJrjNDoiGAFBGA;
						if (qfMrvbIzRaLLxlevOkgeeebCSJfw != 0)
						{
							if (qfMrvbIzRaLLxlevOkgeeebCSJfw != 1)
							{
								return false;
							}
							QfMrvbIzRaLLxlevOkgeeebCSJfw = -1;
							jSiCjCAzYsprzefosNEmWUDIpahSA++;
							goto IL_00e2;
						}
						QfMrvbIzRaLLxlevOkgeeebCSJfw = -1;
						if (ReInput._id != mapHelper.JUxUMkAhrDjRItbYUWjYRNgFpzir)
						{
							ReInput.CheckInitialized(mapHelper.JUxUMkAhrDjRItbYUWjYRNgFpzir);
							return false;
						}
						bXOpJbZkWZybSIwGodJlsAdRlnMH = mapHelper.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ocmUuXbEXjgJwpyyLwvVaCdcTLqF);
						wJLdsijLqNfimNzIvaxAqEWOcIZJA = bXOpJbZkWZybSIwGodJlsAdRlnMH.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						hHiRCIEgLhcQVdVnZYCNQkKIXlEUA = 0;
						goto IL_0107;
						IL_00e2:
						if (jSiCjCAzYsprzefosNEmWUDIpahSA < UbuTmDWNAyTFmhFVvTLJcVFycAji)
						{
							FzbMuHyJPJdRKtUmZosiKtZZRmlM = AuTYHgiJTWHjUzjRkEkDJQuHcFoJA.tMPEVPdgqovMveUHOiirPevVOylqA(jSiCjCAzYsprzefosNEmWUDIpahSA);
							QfMrvbIzRaLLxlevOkgeeebCSJfw = 1;
							return true;
						}
						AuTYHgiJTWHjUzjRkEkDJQuHcFoJA = null;
						hHiRCIEgLhcQVdVnZYCNQkKIXlEUA++;
						goto IL_0107;
						IL_0107:
						if (hHiRCIEgLhcQVdVnZYCNQkKIXlEUA < wJLdsijLqNfimNzIvaxAqEWOcIZJA)
						{
							AuTYHgiJTWHjUzjRkEkDJQuHcFoJA = bXOpJbZkWZybSIwGodJlsAdRlnMH.LNTBMmjuONFUBLurbFbXivzHrdyGb(hHiRCIEgLhcQVdVnZYCNQkKIXlEUA).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							UbuTmDWNAyTFmhFVvTLJcVFycAji = AuTYHgiJTWHjUzjRkEkDJQuHcFoJA.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							jSiCjCAzYsprzefosNEmWUDIpahSA = 0;
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
						oTgmaTevUlYrPPhgNBSxFAdcOcSB oTgmaTevUlYrPPhgNBSxFAdcOcSB2;
						if (QfMrvbIzRaLLxlevOkgeeebCSJfw == -2 && ZvbSDmzKVuZzvVPJySKwyhpWCBhjA == Environment.CurrentManagedThreadId)
						{
							QfMrvbIzRaLLxlevOkgeeebCSJfw = 0;
							oTgmaTevUlYrPPhgNBSxFAdcOcSB2 = this;
						}
						else
						{
							oTgmaTevUlYrPPhgNBSxFAdcOcSB2 = new oTgmaTevUlYrPPhgNBSxFAdcOcSB(0);
							oTgmaTevUlYrPPhgNBSxFAdcOcSB2.oKaSPSpvVgfiyNPXJrjNDoiGAFBGA = oKaSPSpvVgfiyNPXJrjNDoiGAFBGA;
						}
						oTgmaTevUlYrPPhgNBSxFAdcOcSB2.ocmUuXbEXjgJwpyyLwvVaCdcTLqF = nlkTdIFLFUTfhpvYgMjKXroSkOfh;
						return oTgmaTevUlYrPPhgNBSxFAdcOcSB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class voHSrOXTOsDSKDkaYExEXZStPsMu : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int BNCFOrBSreUfuptToMDPlgkJgKVF;

					private ControllerMap AWfTeOnUOfSxWxseTnnOblkpzbMP;

					private int JwhfoiAjMDRYPAuUTPclTjToDQRJ;

					public MapHelper KOVEiTyxDGgFefshZqBuktsFWWCG;

					private int sDdEivcdlzlBgNXONPZoGRlCqZpx;

					public int GAjukeZMmYRPEFCSRfLmEpqelmhNA;

					private int FSKavihhSWtLliKYMYHwtCRLMHihb;

					private int duZCMwecOzcIYzIUfoeyDeXhLchTb;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb uhjxCLgfDVGtnYdGJMcUSibIkqSe;

					private int BqqWcUhjRGXoeYSOibFQuaEVcdFf;

					private int ojKJVtxqDBIXZatYcRecfhRILQjiA;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA GbHnCDCquetsGcSYCMuDyLJpnQrK;

					private int KUwIiEWenwEQalhoSndBBnFxZkIF;

					private int tgGvvTIsAduDOvXSQNOmJTAHOxGN;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return AWfTeOnUOfSxWxseTnnOblkpzbMP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AWfTeOnUOfSxWxseTnnOblkpzbMP;
						}
					}

					[DebuggerHidden]
					public voHSrOXTOsDSKDkaYExEXZStPsMu(int P_0)
					{
						BNCFOrBSreUfuptToMDPlgkJgKVF = P_0;
						JwhfoiAjMDRYPAuUTPclTjToDQRJ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						uhjxCLgfDVGtnYdGJMcUSibIkqSe = null;
						GbHnCDCquetsGcSYCMuDyLJpnQrK = null;
						BNCFOrBSreUfuptToMDPlgkJgKVF = -2;
					}

					private bool MoveNext()
					{
						int bNCFOrBSreUfuptToMDPlgkJgKVF = BNCFOrBSreUfuptToMDPlgkJgKVF;
						MapHelper kOVEiTyxDGgFefshZqBuktsFWWCG = KOVEiTyxDGgFefshZqBuktsFWWCG;
						if (bNCFOrBSreUfuptToMDPlgkJgKVF != 0)
						{
							if (bNCFOrBSreUfuptToMDPlgkJgKVF != 1)
							{
								return false;
							}
							BNCFOrBSreUfuptToMDPlgkJgKVF = -1;
							goto IL_0104;
						}
						BNCFOrBSreUfuptToMDPlgkJgKVF = -1;
						if (ReInput._id != kOVEiTyxDGgFefshZqBuktsFWWCG.JUxUMkAhrDjRItbYUWjYRNgFpzir)
						{
							ReInput.CheckInitialized(kOVEiTyxDGgFefshZqBuktsFWWCG.JUxUMkAhrDjRItbYUWjYRNgFpzir);
							return false;
						}
						FSKavihhSWtLliKYMYHwtCRLMHihb = kOVEiTyxDGgFefshZqBuktsFWWCG.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
						duZCMwecOzcIYzIUfoeyDeXhLchTb = 0;
						goto IL_0161;
						IL_0104:
						tgGvvTIsAduDOvXSQNOmJTAHOxGN++;
						goto IL_0114;
						IL_0161:
						if (duZCMwecOzcIYzIUfoeyDeXhLchTb < FSKavihhSWtLliKYMYHwtCRLMHihb)
						{
							uhjxCLgfDVGtnYdGJMcUSibIkqSe = kOVEiTyxDGgFefshZqBuktsFWWCG.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(duZCMwecOzcIYzIUfoeyDeXhLchTb);
							BqqWcUhjRGXoeYSOibFQuaEVcdFf = uhjxCLgfDVGtnYdGJMcUSibIkqSe.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							ojKJVtxqDBIXZatYcRecfhRILQjiA = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (tgGvvTIsAduDOvXSQNOmJTAHOxGN < KUwIiEWenwEQalhoSndBBnFxZkIF)
						{
							ControllerMap controllerMap = GbHnCDCquetsGcSYCMuDyLJpnQrK.tMPEVPdgqovMveUHOiirPevVOylqA(tgGvvTIsAduDOvXSQNOmJTAHOxGN);
							if (controllerMap.categoryId == sDdEivcdlzlBgNXONPZoGRlCqZpx)
							{
								AWfTeOnUOfSxWxseTnnOblkpzbMP = controllerMap;
								BNCFOrBSreUfuptToMDPlgkJgKVF = 1;
								return true;
							}
							goto IL_0104;
						}
						GbHnCDCquetsGcSYCMuDyLJpnQrK = null;
						ojKJVtxqDBIXZatYcRecfhRILQjiA++;
						goto IL_0139;
						IL_0139:
						if (ojKJVtxqDBIXZatYcRecfhRILQjiA < BqqWcUhjRGXoeYSOibFQuaEVcdFf)
						{
							GbHnCDCquetsGcSYCMuDyLJpnQrK = uhjxCLgfDVGtnYdGJMcUSibIkqSe.LNTBMmjuONFUBLurbFbXivzHrdyGb(ojKJVtxqDBIXZatYcRecfhRILQjiA).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							KUwIiEWenwEQalhoSndBBnFxZkIF = GbHnCDCquetsGcSYCMuDyLJpnQrK.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							tgGvvTIsAduDOvXSQNOmJTAHOxGN = 0;
							goto IL_0114;
						}
						uhjxCLgfDVGtnYdGJMcUSibIkqSe = null;
						duZCMwecOzcIYzIUfoeyDeXhLchTb++;
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
						voHSrOXTOsDSKDkaYExEXZStPsMu voHSrOXTOsDSKDkaYExEXZStPsMu2;
						if (BNCFOrBSreUfuptToMDPlgkJgKVF == -2 && JwhfoiAjMDRYPAuUTPclTjToDQRJ == Environment.CurrentManagedThreadId)
						{
							BNCFOrBSreUfuptToMDPlgkJgKVF = 0;
							voHSrOXTOsDSKDkaYExEXZStPsMu2 = this;
						}
						else
						{
							voHSrOXTOsDSKDkaYExEXZStPsMu2 = new voHSrOXTOsDSKDkaYExEXZStPsMu(0);
							voHSrOXTOsDSKDkaYExEXZStPsMu2.KOVEiTyxDGgFefshZqBuktsFWWCG = KOVEiTyxDGgFefshZqBuktsFWWCG;
						}
						voHSrOXTOsDSKDkaYExEXZStPsMu2.sDdEivcdlzlBgNXONPZoGRlCqZpx = GAjukeZMmYRPEFCSRfLmEpqelmhNA;
						return voHSrOXTOsDSKDkaYExEXZStPsMu2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class xTywURXANSgiEwFJDQTIMHtMlEVW<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int JPCDjnrAPdEmIKymhbTXcZZTHaLK;

					private _0001 vAUQuOiPnbAjGyMmcrpDdCpTrUql;

					private int YoftunofUcCHHGbzxBfAfiyAJTjEA;

					public MapHelper EJFicOENsxyoTBoYkCtVHAbwkBlK;

					private int XWxZSOYKNqIxZRTYzcxHeXGXuhRMA;

					public int dnmarecImwBPMiglenFOtZOrErOSB;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb tIODSkVccJwomAioFibEhVsYfsQXA;

					private int jzzjXBGaWOAEJaCaeBBwjDJBtQXK;

					private int buBouRgZpEqFiJhgdYMOlKsFlgbD;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA ZEgGVLddcqbxFbovbAeWKbLogdmFA;

					private int SRvvEaFqZCZDJBVLdkYjguSxNgOE;

					private int fpKFiUyLYDrimhBxSVtDWxxLtxyV;

					private int aioOrfMtUxgkXWxMhIRqsiLWAboA;

					private int viXROgxYtDrvfINDBzMVAaaKXjUx;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return vAUQuOiPnbAjGyMmcrpDdCpTrUql;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vAUQuOiPnbAjGyMmcrpDdCpTrUql;
						}
					}

					[DebuggerHidden]
					public xTywURXANSgiEwFJDQTIMHtMlEVW(int P_0)
					{
						JPCDjnrAPdEmIKymhbTXcZZTHaLK = P_0;
						YoftunofUcCHHGbzxBfAfiyAJTjEA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						tIODSkVccJwomAioFibEhVsYfsQXA = null;
						ZEgGVLddcqbxFbovbAeWKbLogdmFA = null;
						JPCDjnrAPdEmIKymhbTXcZZTHaLK = -2;
					}

					private bool MoveNext()
					{
						int jPCDjnrAPdEmIKymhbTXcZZTHaLK = JPCDjnrAPdEmIKymhbTXcZZTHaLK;
						MapHelper eJFicOENsxyoTBoYkCtVHAbwkBlK = EJFicOENsxyoTBoYkCtVHAbwkBlK;
						switch (jPCDjnrAPdEmIKymhbTXcZZTHaLK)
						{
						default:
							return false;
						case 0:
						{
							JPCDjnrAPdEmIKymhbTXcZZTHaLK = -1;
							if (ReInput._id != eJFicOENsxyoTBoYkCtVHAbwkBlK.JUxUMkAhrDjRItbYUWjYRNgFpzir)
							{
								ReInput.CheckInitialized(eJFicOENsxyoTBoYkCtVHAbwkBlK.JUxUMkAhrDjRItbYUWjYRNgFpzir);
								return false;
							}
							if (bVcNkmaJvbHeBNQRpaleQvWHeXqv.RkpAQNVHmMMuVLgUrSmQLXsfjnGE<_0001>(out var _))
							{
								tIODSkVccJwomAioFibEhVsYfsQXA = eJFicOENsxyoTBoYkCtVHAbwkBlK.GoyqvLmpEQapPKDVVmOoCFeazQFLA<_0001>();
								jzzjXBGaWOAEJaCaeBBwjDJBtQXK = tIODSkVccJwomAioFibEhVsYfsQXA.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
								buBouRgZpEqFiJhgdYMOlKsFlgbD = 0;
								goto IL_0124;
							}
							jzzjXBGaWOAEJaCaeBBwjDJBtQXK = eJFicOENsxyoTBoYkCtVHAbwkBlK.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
							buBouRgZpEqFiJhgdYMOlKsFlgbD = 0;
							goto IL_0287;
						}
						case 1:
							JPCDjnrAPdEmIKymhbTXcZZTHaLK = -1;
							goto IL_00eb;
						case 2:
							{
								JPCDjnrAPdEmIKymhbTXcZZTHaLK = -1;
								goto IL_0224;
							}
							IL_0224:
							viXROgxYtDrvfINDBzMVAaaKXjUx++;
							goto IL_0236;
							IL_00eb:
							fpKFiUyLYDrimhBxSVtDWxxLtxyV++;
							goto IL_00fd;
							IL_0124:
							if (buBouRgZpEqFiJhgdYMOlKsFlgbD < jzzjXBGaWOAEJaCaeBBwjDJBtQXK)
							{
								ZEgGVLddcqbxFbovbAeWKbLogdmFA = tIODSkVccJwomAioFibEhVsYfsQXA.LNTBMmjuONFUBLurbFbXivzHrdyGb(buBouRgZpEqFiJhgdYMOlKsFlgbD).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								SRvvEaFqZCZDJBVLdkYjguSxNgOE = ZEgGVLddcqbxFbovbAeWKbLogdmFA.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								fpKFiUyLYDrimhBxSVtDWxxLtxyV = 0;
								goto IL_00fd;
							}
							tIODSkVccJwomAioFibEhVsYfsQXA = null;
							break;
							IL_0287:
							if (buBouRgZpEqFiJhgdYMOlKsFlgbD >= jzzjXBGaWOAEJaCaeBBwjDJBtQXK)
							{
								break;
							}
							tIODSkVccJwomAioFibEhVsYfsQXA = eJFicOENsxyoTBoYkCtVHAbwkBlK.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(buBouRgZpEqFiJhgdYMOlKsFlgbD);
							SRvvEaFqZCZDJBVLdkYjguSxNgOE = tIODSkVccJwomAioFibEhVsYfsQXA.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							fpKFiUyLYDrimhBxSVtDWxxLtxyV = 0;
							goto IL_025d;
							IL_0236:
							if (viXROgxYtDrvfINDBzMVAaaKXjUx < aioOrfMtUxgkXWxMhIRqsiLWAboA)
							{
								if (ZEgGVLddcqbxFbovbAeWKbLogdmFA.tMPEVPdgqovMveUHOiirPevVOylqA(viXROgxYtDrvfINDBzMVAaaKXjUx) is _0001 val && val.categoryId == XWxZSOYKNqIxZRTYzcxHeXGXuhRMA)
								{
									vAUQuOiPnbAjGyMmcrpDdCpTrUql = val;
									JPCDjnrAPdEmIKymhbTXcZZTHaLK = 2;
									return true;
								}
								goto IL_0224;
							}
							ZEgGVLddcqbxFbovbAeWKbLogdmFA = null;
							fpKFiUyLYDrimhBxSVtDWxxLtxyV++;
							goto IL_025d;
							IL_00fd:
							if (fpKFiUyLYDrimhBxSVtDWxxLtxyV < SRvvEaFqZCZDJBVLdkYjguSxNgOE)
							{
								ControllerMap controllerMap = ZEgGVLddcqbxFbovbAeWKbLogdmFA.tMPEVPdgqovMveUHOiirPevVOylqA(fpKFiUyLYDrimhBxSVtDWxxLtxyV);
								if (controllerMap.categoryId == XWxZSOYKNqIxZRTYzcxHeXGXuhRMA)
								{
									vAUQuOiPnbAjGyMmcrpDdCpTrUql = (_0001)controllerMap;
									JPCDjnrAPdEmIKymhbTXcZZTHaLK = 1;
									return true;
								}
								goto IL_00eb;
							}
							ZEgGVLddcqbxFbovbAeWKbLogdmFA = null;
							buBouRgZpEqFiJhgdYMOlKsFlgbD++;
							goto IL_0124;
							IL_025d:
							if (fpKFiUyLYDrimhBxSVtDWxxLtxyV < SRvvEaFqZCZDJBVLdkYjguSxNgOE)
							{
								ZEgGVLddcqbxFbovbAeWKbLogdmFA = tIODSkVccJwomAioFibEhVsYfsQXA.LNTBMmjuONFUBLurbFbXivzHrdyGb(fpKFiUyLYDrimhBxSVtDWxxLtxyV).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
								aioOrfMtUxgkXWxMhIRqsiLWAboA = ZEgGVLddcqbxFbovbAeWKbLogdmFA.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
								viXROgxYtDrvfINDBzMVAaaKXjUx = 0;
								goto IL_0236;
							}
							tIODSkVccJwomAioFibEhVsYfsQXA = null;
							buBouRgZpEqFiJhgdYMOlKsFlgbD++;
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
						xTywURXANSgiEwFJDQTIMHtMlEVW<_0001> xTywURXANSgiEwFJDQTIMHtMlEVW2;
						if (JPCDjnrAPdEmIKymhbTXcZZTHaLK == -2 && YoftunofUcCHHGbzxBfAfiyAJTjEA == Environment.CurrentManagedThreadId)
						{
							JPCDjnrAPdEmIKymhbTXcZZTHaLK = 0;
							xTywURXANSgiEwFJDQTIMHtMlEVW2 = this;
						}
						else
						{
							xTywURXANSgiEwFJDQTIMHtMlEVW2 = new xTywURXANSgiEwFJDQTIMHtMlEVW<_0001>(0);
							xTywURXANSgiEwFJDQTIMHtMlEVW2.EJFicOENsxyoTBoYkCtVHAbwkBlK = EJFicOENsxyoTBoYkCtVHAbwkBlK;
						}
						xTywURXANSgiEwFJDQTIMHtMlEVW2.XWxZSOYKNqIxZRTYzcxHeXGXuhRMA = dnmarecImwBPMiglenFOtZOrErOSB;
						return xTywURXANSgiEwFJDQTIMHtMlEVW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class DzdTpULHgaEBfIwmicWanmfdpbDdb : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int jMIGwHzTnreQCAyCuwojpgsIbuGv;

					private ControllerMap ycQjJEvPHKJrxARmCBPyueYGTmdv;

					private int CYFLfsTOEIIewajmzfJNWxiASkMi;

					public MapHelper McnxblsqLNMPbCCskEQqKIwadPjp;

					private ControllerType aQhpYLbQcTEkOuJLciieGJJJtsXR;

					public ControllerType grpChdSakdFMojuxJAbtsnaqbvuJA;

					private int whZnFaPGHKNZRoTdnpsyXppjEMNl;

					public int xDLwabwtJnToNYKueBllfIoNvqWt;

					private oqyCGPauVpdeCYocXRLbgQLkEJqSb BAcFWVbancMGkCKLauDTqiSzRGEOA;

					private int tbHiifpLbEOMQFYmfUXhtbLrEqLQ;

					private int hxjBIAIBlnUrLTLnNNdCApEReOkx;

					private wfTqPVowqyEtwvBJoegCIMAGtbtoA PAhGnqvaRTuAorbZvdhBYFkLAXHY;

					private int JvskpXnEGLeHlgUeCKFUslcWvtCN;

					private int OqaomXIeHOjLjfWImsSXQLQGfRpsA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ycQjJEvPHKJrxARmCBPyueYGTmdv;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ycQjJEvPHKJrxARmCBPyueYGTmdv;
						}
					}

					[DebuggerHidden]
					public DzdTpULHgaEBfIwmicWanmfdpbDdb(int P_0)
					{
						jMIGwHzTnreQCAyCuwojpgsIbuGv = P_0;
						CYFLfsTOEIIewajmzfJNWxiASkMi = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						BAcFWVbancMGkCKLauDTqiSzRGEOA = null;
						PAhGnqvaRTuAorbZvdhBYFkLAXHY = null;
						jMIGwHzTnreQCAyCuwojpgsIbuGv = -2;
					}

					private bool MoveNext()
					{
						int num = jMIGwHzTnreQCAyCuwojpgsIbuGv;
						MapHelper mcnxblsqLNMPbCCskEQqKIwadPjp = McnxblsqLNMPbCCskEQqKIwadPjp;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							jMIGwHzTnreQCAyCuwojpgsIbuGv = -1;
							goto IL_00e2;
						}
						jMIGwHzTnreQCAyCuwojpgsIbuGv = -1;
						if (ReInput._id != mcnxblsqLNMPbCCskEQqKIwadPjp.JUxUMkAhrDjRItbYUWjYRNgFpzir)
						{
							ReInput.CheckInitialized(mcnxblsqLNMPbCCskEQqKIwadPjp.JUxUMkAhrDjRItbYUWjYRNgFpzir);
							return false;
						}
						BAcFWVbancMGkCKLauDTqiSzRGEOA = mcnxblsqLNMPbCCskEQqKIwadPjp.DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(aQhpYLbQcTEkOuJLciieGJJJtsXR);
						tbHiifpLbEOMQFYmfUXhtbLrEqLQ = BAcFWVbancMGkCKLauDTqiSzRGEOA.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						hxjBIAIBlnUrLTLnNNdCApEReOkx = 0;
						goto IL_0117;
						IL_00f2:
						if (OqaomXIeHOjLjfWImsSXQLQGfRpsA < JvskpXnEGLeHlgUeCKFUslcWvtCN)
						{
							ControllerMap controllerMap = PAhGnqvaRTuAorbZvdhBYFkLAXHY.tMPEVPdgqovMveUHOiirPevVOylqA(OqaomXIeHOjLjfWImsSXQLQGfRpsA);
							if (controllerMap.categoryId == whZnFaPGHKNZRoTdnpsyXppjEMNl)
							{
								ycQjJEvPHKJrxARmCBPyueYGTmdv = controllerMap;
								jMIGwHzTnreQCAyCuwojpgsIbuGv = 1;
								return true;
							}
							goto IL_00e2;
						}
						PAhGnqvaRTuAorbZvdhBYFkLAXHY = null;
						hxjBIAIBlnUrLTLnNNdCApEReOkx++;
						goto IL_0117;
						IL_00e2:
						OqaomXIeHOjLjfWImsSXQLQGfRpsA++;
						goto IL_00f2;
						IL_0117:
						if (hxjBIAIBlnUrLTLnNNdCApEReOkx < tbHiifpLbEOMQFYmfUXhtbLrEqLQ)
						{
							PAhGnqvaRTuAorbZvdhBYFkLAXHY = BAcFWVbancMGkCKLauDTqiSzRGEOA.LNTBMmjuONFUBLurbFbXivzHrdyGb(hxjBIAIBlnUrLTLnNNdCApEReOkx).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							JvskpXnEGLeHlgUeCKFUslcWvtCN = PAhGnqvaRTuAorbZvdhBYFkLAXHY.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							OqaomXIeHOjLjfWImsSXQLQGfRpsA = 0;
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
						DzdTpULHgaEBfIwmicWanmfdpbDdb dzdTpULHgaEBfIwmicWanmfdpbDdb;
						if (jMIGwHzTnreQCAyCuwojpgsIbuGv == -2 && CYFLfsTOEIIewajmzfJNWxiASkMi == Environment.CurrentManagedThreadId)
						{
							jMIGwHzTnreQCAyCuwojpgsIbuGv = 0;
							dzdTpULHgaEBfIwmicWanmfdpbDdb = this;
						}
						else
						{
							dzdTpULHgaEBfIwmicWanmfdpbDdb = new DzdTpULHgaEBfIwmicWanmfdpbDdb(0);
							dzdTpULHgaEBfIwmicWanmfdpbDdb.McnxblsqLNMPbCCskEQqKIwadPjp = McnxblsqLNMPbCCskEQqKIwadPjp;
						}
						dzdTpULHgaEBfIwmicWanmfdpbDdb.whZnFaPGHKNZRoTdnpsyXppjEMNl = xDLwabwtJnToNYKueBllfIoNvqWt;
						dzdTpULHgaEBfIwmicWanmfdpbDdb.aQhpYLbQcTEkOuJLciieGJJJtsXR = grpChdSakdFMojuxJAbtsnaqbvuJA;
						return dzdTpULHgaEBfIwmicWanmfdpbDdb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly ReblhCinFkWhDVFLEbjmzIdfVvaS woIyjSwuvaEdDlGzDfNkDyEbPFNRA;

				private Player cXdEAfjSjCuVWDsJjJXnETWxsdzp;

				private ControllerHelper DsajybfsHVDRfAdKzGTCFoiyZWnnA;

				private readonly ControllerMapEnabler WZHhVSAounNRujhEarLlYpdQulVe;

				private readonly ControllerMapLayoutManager GXdgVwFYHycEnnaxyWiHUTljDTEVA;

				private readonly int JUxUMkAhrDjRItbYUWjYRNgFpzir;

				public ControllerMapLayoutManager layoutManager => GXdgVwFYHycEnnaxyWiHUTljDTEVA;

				public ControllerMapEnabler mapEnabler => WZHhVSAounNRujhEarLlYpdQulVe;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
						{
							ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return cXdEAfjSjCuVWDsJjJXnETWxsdzp.CRkeKMxiPDzGLacrcoQHokrPEViD.BUHchcVExxcLLVISomzDIDkZWYHs(cXdEAfjSjCuVWDsJjJXnETWxsdzp.hNoRiloMAZCwMJhqxCSNjcRIpGck);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, ReblhCinFkWhDVFLEbjmzIdfVvaS P_2, ControllerMapLayoutManager.VRUPdzKgeveqVvQabkIaYFoBcpSf P_3, ControllerMapEnabler.LoufCxnWRPkzSbBIKyhZshokUpWL P_4)
				{
					JUxUMkAhrDjRItbYUWjYRNgFpzir = ReInput.id;
					cXdEAfjSjCuVWDsJjJXnETWxsdzp = P_0;
					DsajybfsHVDRfAdKzGTCFoiyZWnnA = P_1;
					woIyjSwuvaEdDlGzDfNkDyEbPFNRA = P_2;
					WZHhVSAounNRujhEarLlYpdQulVe = new ControllerMapEnabler(P_0, P_4);
					GXdgVwFYHycEnnaxyWiHUTljDTEVA = new ControllerMapLayoutManager(P_0, P_3);
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.twnNccQQbryNDOsCkBHwuJsUQpUO += WZHhVSAounNRujhEarLlYpdQulVe.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					auqrEvhyOtuGfYcosMrZvzUAqxti<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					uEidAIyPYrqumvYKZIeeCdKoVTPd<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					tfnsfwEbkNagEezTBikOhcFOCYqwA(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					QSRhCDtiuecxJBloCeKBbGoIfVgWB(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					auqrEvhyOtuGfYcosMrZvzUAqxti<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					uEidAIyPYrqumvYKZIeeCdKoVTPd<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					tfnsfwEbkNagEezTBikOhcFOCYqwA(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					QSRhCDtiuecxJBloCeKBbGoIfVgWB(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void auqrEvhyOtuGfYcosMrZvzUAqxti<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						TvBqLoaooHqQIQnCUZtKNIaOmRIg(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void uEidAIyPYrqumvYKZIeeCdKoVTPd<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						WmCgtGJEaHaZsgvGmfvvSPGKsDpKA(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void tfnsfwEbkNagEezTBikOhcFOCYqwA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						TvBqLoaooHqQIQnCUZtKNIaOmRIg(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void QSRhCDtiuecxJBloCeKBbGoIfVgWB(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						WmCgtGJEaHaZsgvGmfvvSPGKsDpKA(P_0, P_1, P_2, P_3, P_4);
					}
				}

				[IteratorStateMachine(typeof(NHlCdCQHdgOuIJiJKMxhDOpRcAIv))]
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new NHlCdCQHdgOuIJiJKMxhDOpRcAIv(-2)
					{
						BOibeIbfpBJGQveyETOzaDTUeenFb = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num; j++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.itneGtrZDUMHlUsFasJnFNSNHaHP(results, true);
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(WGyeulCQftCltoHnPJVSuORRXdPM))]
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new WGyeulCQftCltoHnPJVSuORRXdPM<T>(-2)
					{
						ncgpeQPdsstUNnURNPfkYEmsvekL = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (bVcNkmaJvbHeBNQRpaleQvWHeXqv.RkpAQNVHmMMuVLgUrSmQLXsfjnGE<T>(out var controllerType))
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int i = 0; i < num; i++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.bDvgaggBWKCmxDqECVlwURFIhetCc(results, true);
						}
					}
					else
					{
						int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
						for (int j = 0; j < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; j++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb3 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(j);
							int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb3.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							for (int k = 0; k < num2; k++)
							{
								oqyCGPauVpdeCYocXRLbgQLkEJqSb3.LNTBMmjuONFUBLurbFbXivzHrdyGb(k).ZVqQCpBpHaJoxANGetaJnsjmlMojA.bDvgaggBWKCmxDqECVlwURFIhetCc(results, true);
							}
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(oTgmaTevUlYrPPhgNBSxFAdcOcSB))]
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new oTgmaTevUlYrPPhgNBSxFAdcOcSB(-2)
					{
						oKaSPSpvVgfiyNPXJrjNDoiGAFBGA = this,
						nlkTdIFLFUTfhpvYgMjKXroSkOfh = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.itneGtrZDUMHlUsFasJnFNSNHaHP(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				[IteratorStateMachine(typeof(voHSrOXTOsDSKDkaYExEXZStPsMu))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new voHSrOXTOsDSKDkaYExEXZStPsMu(-2)
					{
						KOVEiTyxDGgFefshZqBuktsFWWCG = this,
						GAjukeZMmYRPEFCSRfLmEpqelmhNA = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				[IteratorStateMachine(typeof(xTywURXANSgiEwFJDQTIMHtMlEVW))]
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new xTywURXANSgiEwFJDQTIMHtMlEVW<T>(-2)
					{
						EJFicOENsxyoTBoYkCtVHAbwkBlK = this,
						dnmarecImwBPMiglenFOtZOrErOSB = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				[IteratorStateMachine(typeof(DzdTpULHgaEBfIwmicWanmfdpbDdb))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new DzdTpULHgaEBfIwmicWanmfdpbDdb(-2)
					{
						McnxblsqLNMPbCCskEQqKIwadPjp = this,
						xDLwabwtJnToNYKueBllfIoNvqWt = categoryId,
						grpChdSakdFMojuxJAbtsnaqbvuJA = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num; j++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.ibSjZCazFZFmitMzMTvwZVTQNBqJ(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (bVcNkmaJvbHeBNQRpaleQvWHeXqv.RkpAQNVHmMMuVLgUrSmQLXsfjnGE<T>(out var controllerType))
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int i = 0; i < num; i++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.NCxnbUhGsOHSBJJEIHsFKEXMENzWA(categoryId, results, true);
						}
					}
					else
					{
						int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
						for (int j = 0; j < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; j++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb3 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(j);
							int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb3.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
							for (int k = 0; k < num2; k++)
							{
								oqyCGPauVpdeCYocXRLbgQLkEJqSb3.LNTBMmjuONFUBLurbFbXivzHrdyGb(k).ZVqQCpBpHaJoxANGetaJnsjmlMojA.NCxnbUhGsOHSBJJEIHsFKEXMENzWA(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.ibSjZCazFZFmitMzMTvwZVTQNBqJ(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return wTVLyoRitKXbxmmQrydDaWdlfRAG<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return MRsQAQVtPEyRCsBIWOVMxKHTskVi(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					return qVPMYnzMLWGhZpGTLHuhmBISHDpB(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					return DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(controllerId)?.ZVqQCpBpHaJoxANGetaJnsjmlMojA.ibSjZCazFZFmitMzMTvwZVTQNBqJ(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return VyVWhtxHCZGoqaRFJjsTSGlbvdXO<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					rhYdZBfPeTRSAgWthmAnYqtbiubLA rhYdZBfPeTRSAgWthmAnYqtbiubLA2 = GoyqvLmpEQapPKDVVmOoCFeazQFLA<T>().xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(controllerId);
					if (rhYdZBfPeTRSAgWthmAnYqtbiubLA2 == null)
					{
						return 0;
					}
					rhYdZBfPeTRSAgWthmAnYqtbiubLA2.ZVqQCpBpHaJoxANGetaJnsjmlMojA.NCxnbUhGsOHSBJJEIHsFKEXMENzWA(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)RdrslPMgUWhnzrfkmyZrvVtyrtHr(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)UaGvoOcTewxxlvwVTsoTSRvlrcae(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return (T)lFugltKZRYzAOIMTlyEFIAhZEZPn(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.tLdBkiHQJEXErXZFyiEPjfLXpcmt(mapId);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return RdrslPMgUWhnzrfkmyZrvVtyrtHr(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return UaGvoOcTewxxlvwVTsoTSRvlrcae(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return lFugltKZRYzAOIMTlyEFIAhZEZPn(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)NBWEdezXePaFbHUradxeVZcPUHvq(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return NBWEdezXePaFbHUradxeVZcPUHvq(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						DrlmOaBijJsTUArfQmVSqVkjDrEK(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						IilMRUvErvKEZNmyGeAzMAtNroCq(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						DrlmOaBijJsTUArfQmVSqVkjDrEK(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						DrlmOaBijJsTUArfQmVSqVkjDrEK(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						IilMRUvErvKEZNmyGeAzMAtNroCq(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						DrlmOaBijJsTUArfQmVSqVkjDrEK(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return false;
					}
					return VcVkqCpCEZsLOkeqMPTNQaMmWtyn(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return false;
					}
					return VcVkqCpCEZsLOkeqMPTNQaMmWtyn(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return false;
					}
					return CbTFZxeAIGfvwkyefdejbqeBvyJd(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return false;
					}
					return CbTFZxeAIGfvwkyefdejbqeBvyJd(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						UGBEMFNitpIeRiyPIilYrqtXyAOp(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						AFlaEqCFPWezeIMYThApnIfDAHAYA(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						UGBEMFNitpIeRiyPIilYrqtXyAOp(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else if (mapId >= 0)
					{
						fkHEVRPcOiDEsjKkrkiZcNAXIZNRA(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						xizNhrxyAkdJdwQqsFyMEhKsQfmv(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						PjMdbEJBdZKSgbYRYwhSWpnIGdMR(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else if (mapId >= 0)
					{
						fkHEVRPcOiDEsjKkrkiZcNAXIZNRA(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						xizNhrxyAkdJdwQqsFyMEhKsQfmv(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						PjMdbEJBdZKSgbYRYwhSWpnIGdMR(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMaps(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.QDUsnVdZMYTaRnjRbpJrZHCiEhGEA(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMapsInCategory(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMapsInCategory(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i));
						for (int j = 0; j < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; j++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.XaSbGCzYHnzACWSixUcAkcwdwUZH(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.XaSbGCzYHnzACWSixUcAkcwdwUZH(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
						for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.ZhqFEnCBLTHuLVrMGAtDGrfjRrLFA(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMapsInLayout(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.gkeemdwidQdkNIYqpusPimXtiXEgA(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMapsForController(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMapsForController(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(controllerId);
					if (num >= 0)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.QDUsnVdZMYTaRnjRbpJrZHCiEhGEA(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(controllerId);
					if (num >= 0)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.XaSbGCzYHnzACWSixUcAkcwdwUZH(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
					}
					else
					{
						ClearMapsForControllerInLayout(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(controllerId);
					if (num >= 0)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.gkeemdwidQdkNIYqpusPimXtiXEgA(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					for (int i = 0; i < DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						ClearMaps(DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i), userAssignableOnly);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return XhcttLUKbTseIvkBwSHICbFMHKFZ(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return HGJRYoHdDXIMdbOTbKFVBOZBVdGZ(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						ActionElementMap actionElementMap = HGJRYoHdDXIMdbOTbKFVBOZBVdGZ(DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return cjWimFbbEqirlZvCtCgAIFMtOFIo(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return KtaAloUEWKwPLRJsJezETHIzOEee(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(HrZAocbAqLUFtvvzCMIljEreTTTBB))]
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new HrZAocbAqLUFtvvzCMIljEreTTTBB(-2)
					{
						WynBBxMEWcdwxMWtVjGiUBynqvcv = this,
						YZfSLOBPDTmovrGXDFCOCmndzJMpA = actionId,
						klKChMGWIiYLEKmvrowfZDhQMPWD = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					return OZOMdIJmJrIEmfiqOWjQFsetmouh(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					return rqngzfplaqDJqcqqccCUVzevFROl(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return OjofpYOCrRoefKAeaaEvCGHaNALD(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return psoTTtKPuRdnSAbFXQcclSUfNitz(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return jcdftLakCUdJZLFeIkjCIfPoBjvI(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						ActionElementMap actionElementMap = jcdftLakCUdJZLFeIkjCIfPoBjvI(DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return olCqZHBDepoayDuofeSahRJirviw(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return UERgVJxEsqQjqmOKAEinzjADGjYhA(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(GffqwonREDFalbUIQuacemaHqfpV))]
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new GffqwonREDFalbUIQuacemaHqfpV(-2)
					{
						YTVtbQPbKqyBVrDNecfgqIQFWpVU = this,
						iXbICZNBtxhiPpQNEvvoSPTPuuKK = actionId,
						QUYDwiclRlKYjybwNMQmcsWavDNI = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return yQyoNujjKAmaCeGUxhVQiamwAbDO(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return FYVbtkcTazrRLFsLDlRDEeeQgjjC(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GBPxRcwWLAsyLRTeHHQziTfYJlRc(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return VpljgAIKfoQQWxnDNiXpjtTzxoeV(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return HRPFsBhYmujGUVpMLyfmGUnfuuKd(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						ActionElementMap actionElementMap = HRPFsBhYmujGUVpMLyfmGUnfuuKd(DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return kYEMzzsksoebBNrXRvuVLvVnBiNG(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return yBHUiKCjNUDiOkWbKyQxDpKpFOxF(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(ldHRAjXJVaRBcYRfIlkjJMLAJeJCA))]
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new ldHRAjXJVaRBcYRfIlkjJMLAJeJCA(-2)
					{
						pILbmhooUpepaMJgfodaINzQWaTb = this,
						SVKQqNZPLqWWGNFiGjVbhcuPbnveb = actionId,
						FeiZWuDNYsiLdABwKtMhQOsVDkAh = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return mVmjKGclDAhZugDdZMdZIsuSzNDbA(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					return NBuhVQnXYsQJKXNdadYXfeHfejGdb(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return HYXXlCjtcHtXSoVXcSQPKQLoRAIE(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, skipDisabledMaps);
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return aothuhuGWIdhbjGgctHELigQTPai(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, actionId, skipDisabledMaps);
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return aothuhuGWIdhbjGgctHELigQTPai(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, skipDisabledMaps);
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return XuEgUGruvelvmGUFnfQcLxuVJhEN(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, actionId, skipDisabledMaps);
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return XuEgUGruvelvmGUFnfQcLxuVJhEN(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, skipDisabledMaps, results);
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return dHufMQfpVtYdXSpFfJfiCgGcsFIRA(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, actionId, skipDisabledMaps, results);
					XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return dHufMQfpVtYdXSpFfJfiCgGcsFIRA(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<T>.array;
					}
					return dYcAMJSDVPClqgUstKbGFkJJIGLlc<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return NcoFPeFPqQsdsZGRMZcspOzDexcA(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<T>.array;
					}
					return iCJaMrHgOvFRPTyDUuUjtQbjHvWSA<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return MWoxpLIwAWwWChRToprbTydAFaw(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						ArrayTools.Combine(ref array, MWoxpLIwAWwWChRToprbTydAFaw(DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int num = 0;
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num2; j++)
						{
							num += oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.DLRBeWGGavWuxmrjsGuYkINIYUttA(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int num = 0;
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num2; i++)
					{
						num += oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.DLRBeWGGavWuxmrjsGuYkINIYUttA(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					return DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(controllerId)?.ZVqQCpBpHaJoxANGetaJnsjmlMojA.DLRBeWGGavWuxmrjsGuYkINIYUttA(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num2; j++)
						{
							num += oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.rJVWmIcbINEQxSdUdrucHMZbmoDi(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						ControllerType controllerType = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.awyYJXzOuOzOwNueelCIhHaLlOCp(i);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num2; i++)
					{
						num += oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.rJVWmIcbINEQxSdUdrucHMZbmoDi(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num2; i++)
					{
						num += oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.SsVtmzQxWaEvnUPuhmJHyjzvKcJj(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					return DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controller.type).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(controller.id)?.ZVqQCpBpHaJoxANGetaJnsjmlMojA.rJVWmIcbINEQxSdUdrucHMZbmoDi(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					return DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controller.type).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(controller.id)?.ZVqQCpBpHaJoxANGetaJnsjmlMojA.SsVtmzQxWaEvnUPuhmJHyjzvKcJj(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						FWqWFZfyDXWxXqYNmaMpnFFFRhFx(false);
						break;
					case ControllerType.Keyboard:
						HzsYdTXFjFOIuEwOwWiMcZFAxEwN(false);
						break;
					case ControllerType.Mouse:
						LwRRHmiaFTigGKaTPnERChyhfcfIA(false);
						break;
					case ControllerType.Custom:
						nSPBAbiigHoCsiCIZnQkwozCKKWPA(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num; j++)
						{
							if (oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA.GuSgtscPPKyrljskiEekPeDzIGLd(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
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
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num; i++)
					{
						if (oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.GuSgtscPPKyrljskiEekPeDzIGLd(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return cXdEAfjSjCuVWDsJjJXnETWxsdzp.CRkeKMxiPDzGLacrcoQHokrPEViD.ZSaXaWxiHUTBOKAFUdCciNmpaevcA(cXdEAfjSjCuVWDsJjJXnETWxsdzp.hNoRiloMAZCwMJhqxCSNjcRIpGck, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != JUxUMkAhrDjRItbYUWjYRNgFpzir)
					{
						ReInput.CheckInitialized(JUxUMkAhrDjRItbYUWjYRNgFpzir);
						return null;
					}
					return cXdEAfjSjCuVWDsJjJXnETWxsdzp.CRkeKMxiPDzGLacrcoQHokrPEViD.KSWKFupatZtHQrFKolbYiPjSGdhh(cXdEAfjSjCuVWDsJjJXnETWxsdzp.hNoRiloMAZCwMJhqxCSNjcRIpGck, behaviorName);
				}

				internal void QhHbMsEJDHJTogalvqUvkUETdircb()
				{
					WZHhVSAounNRujhEarLlYpdQulVe.LoadDefaults();
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.LoadDefaults();
				}

				internal void FWqWFZfyDXWxXqYNmaMpnFFFRhFx(bool P_0)
				{
					if (woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LmlSFaFoWvyewBNUdgkKQSKixSEP == null)
					{
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick);
					DsajybfsHVDRfAdKzGTCFoiyZWnnA.WeTlLgtnEcedzdjbKVXuxepDCgfF.VoPocBoXXMaHsmmpJFDBIEjJvFYWA();
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num; i++)
					{
						kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY xNKZnmZDWSpEQNETiUDuIefVGQwY = (kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY)oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.BnLfdLdejZPchYBMOscGuqKWagU();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.QctWoySrGTZJSArZHyJFYsCcnKlK(j).enabled;
							}
						}
						xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.iqSANVwLXpOXpyJymYHiyPLFsEkC(false);
						for (int k = 0; k < woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LmlSFaFoWvyewBNUdgkKQSKixSEP.Length; k++)
						{
							qvDTYIkBgLkBvjhXinQFEXqcvDtO(xNKZnmZDWSpEQNETiUDuIefVGQwY.OGKSTOLCyntwnzWvSpSVBzuxFIIC, xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd, woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LmlSFaFoWvyewBNUdgkKQSKixSEP[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.BnLfdLdejZPchYBMOscGuqKWagU());
							for (int l = 0; l < num3; l++)
							{
								xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.QctWoySrGTZJSArZHyJFYsCcnKlK(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = false;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.Apply();
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void HzsYdTXFjFOIuEwOwWiMcZFAxEwN(bool P_0)
				{
					if (woIyjSwuvaEdDlGzDfNkDyEbPFNRA.XXnjTWJFjawJVJpTdMvGWYkqdGcE == null)
					{
						return;
					}
					wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Keyboard).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(0).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
					bool[] array = null;
					if (!P_0)
					{
						int num = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(i).enabled;
						}
					}
					wfTqPVowqyEtwvBJoegCIMAGtbtoA2.QDUsnVdZMYTaRnjRbpJrZHCiEhGEA(false);
					for (int j = 0; j < woIyjSwuvaEdDlGzDfNkDyEbPFNRA.XXnjTWJFjawJVJpTdMvGWYkqdGcE.Length; j++)
					{
						HiJTMJvhgQklUObpnWHEIWyMFAFg hiJTMJvhgQklUObpnWHEIWyMFAFg = woIyjSwuvaEdDlGzDfNkDyEbPFNRA.XXnjTWJFjawJVJpTdMvGWYkqdGcE[j];
						if (hiJTMJvhgQklUObpnWHEIWyMFAFg.wBXumreqCUREJmlYLtVPesfZJGTb >= 0 && hiJTMJvhgQklUObpnWHEIWyMFAFg.RsPDIDzPOhPEHjqPDCKIvHauCjRDA >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, hiJTMJvhgQklUObpnWHEIWyMFAFg.wBXumreqCUREJmlYLtVPesfZJGTb, hiJTMJvhgQklUObpnWHEIWyMFAFg.RsPDIDzPOhPEHjqPDCKIvHauCjRDA);
							if (P_0)
							{
								keyboardMap.enabled = hiJTMJvhgQklUObpnWHEIWyMFAFg.WUGiULgmqGSpdggWKNvheXdtbBmQ;
							}
							DrlmOaBijJsTUArfQmVSqVkjDrEK(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo);
						for (int k = 0; k < num2; k++)
						{
							wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = false;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.Apply();
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void LwRRHmiaFTigGKaTPnERChyhfcfIA(bool P_0)
				{
					if (woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LCAfmdVWfUbLNhbHoEAxZxEcpoey == null)
					{
						return;
					}
					wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Mouse).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(0).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
					bool[] array = null;
					if (!P_0)
					{
						int num = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(i).enabled;
						}
					}
					wfTqPVowqyEtwvBJoegCIMAGtbtoA2.QDUsnVdZMYTaRnjRbpJrZHCiEhGEA(false);
					for (int j = 0; j < woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LCAfmdVWfUbLNhbHoEAxZxEcpoey.Length; j++)
					{
						HiJTMJvhgQklUObpnWHEIWyMFAFg hiJTMJvhgQklUObpnWHEIWyMFAFg = woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LCAfmdVWfUbLNhbHoEAxZxEcpoey[j];
						if (hiJTMJvhgQklUObpnWHEIWyMFAFg.wBXumreqCUREJmlYLtVPesfZJGTb >= 0 && hiJTMJvhgQklUObpnWHEIWyMFAFg.RsPDIDzPOhPEHjqPDCKIvHauCjRDA >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, hiJTMJvhgQklUObpnWHEIWyMFAFg.wBXumreqCUREJmlYLtVPesfZJGTb, hiJTMJvhgQklUObpnWHEIWyMFAFg.RsPDIDzPOhPEHjqPDCKIvHauCjRDA);
							if (P_0)
							{
								mouseMap.enabled = hiJTMJvhgQklUObpnWHEIWyMFAFg.WUGiULgmqGSpdggWKNvheXdtbBmQ;
							}
							DrlmOaBijJsTUArfQmVSqVkjDrEK(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo);
						for (int k = 0; k < num2; k++)
						{
							wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = false;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.Apply();
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void nSPBAbiigHoCsiCIZnQkwozCKKWPA(bool P_0)
				{
					if (woIyjSwuvaEdDlGzDfNkDyEbPFNRA.vdnbzJEwhKdCXsMJYIKdlGQNikwQ == null)
					{
						return;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num; i++)
					{
						kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY xNKZnmZDWSpEQNETiUDuIefVGQwY = (kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY)oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.BnLfdLdejZPchYBMOscGuqKWagU();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.QctWoySrGTZJSArZHyJFYsCcnKlK(j).enabled;
							}
						}
						xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.iqSANVwLXpOXpyJymYHiyPLFsEkC(false);
						for (int k = 0; k < woIyjSwuvaEdDlGzDfNkDyEbPFNRA.vdnbzJEwhKdCXsMJYIKdlGQNikwQ.Length; k++)
						{
							JpdJSlRBjUjaeuAyUNfoAotebLxgA(xNKZnmZDWSpEQNETiUDuIefVGQwY.OGKSTOLCyntwnzWvSpSVBzuxFIIC, xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd, woIyjSwuvaEdDlGzDfNkDyEbPFNRA.vdnbzJEwhKdCXsMJYIKdlGQNikwQ[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.BnLfdLdejZPchYBMOscGuqKWagU());
							for (int l = 0; l < num3; l++)
							{
								xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd.QctWoySrGTZJSArZHyJFYsCcnKlK(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = false;
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.Apply();
					GXdgVwFYHycEnnaxyWiHUTljDTEVA.loadFromUserDataStore = loadFromUserDataStore;
				}

				private oqyCGPauVpdeCYocXRLbgQLkEJqSb GoyqvLmpEQapPKDVVmOoCFeazQFLA<_0001>() where _0001 : ControllerMap
				{
					return DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(bVcNkmaJvbHeBNQRpaleQvWHeXqv.WPAMmjaTkemihFOLiHpmwzpMGwfu<_0001>());
				}

				internal global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> AJrIbhXCyqDOKFcHYTyyStyEgmnEb(Joystick P_0, bool P_1)
				{
					if (P_0 == null || woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LmlSFaFoWvyewBNUdgkKQSKixSEP == null)
					{
						return null;
					}
					global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> aHIwDYxlaXXEqmpFSbWKzMJxRrGM = new global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap>(P_0.id);
					for (int i = 0; i < woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LmlSFaFoWvyewBNUdgkKQSKixSEP.Length; i++)
					{
						qvDTYIkBgLkBvjhXinQFEXqcvDtO(P_0, aHIwDYxlaXXEqmpFSbWKzMJxRrGM, woIyjSwuvaEdDlGzDfNkDyEbPFNRA.LmlSFaFoWvyewBNUdgkKQSKixSEP[i], P_1);
					}
					if (aHIwDYxlaXXEqmpFSbWKzMJxRrGM.BnLfdLdejZPchYBMOscGuqKWagU() == 0)
					{
						return null;
					}
					return aHIwDYxlaXXEqmpFSbWKzMJxRrGM;
				}

				private void qvDTYIkBgLkBvjhXinQFEXqcvDtO(Joystick P_0, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> P_1, HiJTMJvhgQklUObpnWHEIWyMFAFg P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.wBXumreqCUREJmlYLtVPesfZJGTb >= 0 && P_2.RsPDIDzPOhPEHjqPDCKIvHauCjRDA >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.yZmJysTiAJlrPpOSedEsHtLLwPgAA(P_0, P_2.wBXumreqCUREJmlYLtVPesfZJGTb, P_2.RsPDIDzPOhPEHjqPDCKIvHauCjRDA);
						KTKJqTPkIUCqdztsJbksFOXTJZiiA(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.WUGiULgmqGSpdggWKNvheXdtbBmQ ? BoolOption.True : BoolOption.False);
						}
						P_1.dBrKOHxMLZdwXcsvyMxYGJgRBQjfA(joystickMap, boolOption);
					}
				}

				internal global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<CustomControllerMap> lwAlIcmhLgAwbiwAivcfhTBzZckAA(CustomController P_0, bool P_1)
				{
					if (P_0 == null || woIyjSwuvaEdDlGzDfNkDyEbPFNRA.vdnbzJEwhKdCXsMJYIKdlGQNikwQ == null)
					{
						return null;
					}
					global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<CustomControllerMap> aHIwDYxlaXXEqmpFSbWKzMJxRrGM = new global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<CustomControllerMap>(P_0.id);
					for (int i = 0; i < woIyjSwuvaEdDlGzDfNkDyEbPFNRA.vdnbzJEwhKdCXsMJYIKdlGQNikwQ.Length; i++)
					{
						JpdJSlRBjUjaeuAyUNfoAotebLxgA(P_0, aHIwDYxlaXXEqmpFSbWKzMJxRrGM, woIyjSwuvaEdDlGzDfNkDyEbPFNRA.vdnbzJEwhKdCXsMJYIKdlGQNikwQ[i], P_1);
					}
					if (aHIwDYxlaXXEqmpFSbWKzMJxRrGM.BnLfdLdejZPchYBMOscGuqKWagU() == 0)
					{
						return null;
					}
					return aHIwDYxlaXXEqmpFSbWKzMJxRrGM;
				}

				private void JpdJSlRBjUjaeuAyUNfoAotebLxgA(CustomController P_0, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<CustomControllerMap> P_1, HiJTMJvhgQklUObpnWHEIWyMFAFg P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.wBXumreqCUREJmlYLtVPesfZJGTb >= 0 && P_2.RsPDIDzPOhPEHjqPDCKIvHauCjRDA >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.DgbFjiULnlYfIPOraXwotTKzqNpf(P_2.wBXumreqCUREJmlYLtVPesfZJGTb, P_0.sourceControllerId, P_2.RsPDIDzPOhPEHjqPDCKIvHauCjRDA);
						KTKJqTPkIUCqdztsJbksFOXTJZiiA(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.WUGiULgmqGSpdggWKNvheXdtbBmQ ? BoolOption.True : BoolOption.False);
						}
						P_1.dBrKOHxMLZdwXcsvyMxYGJgRBQjfA(customControllerMap, boolOption);
					}
				}

				internal void KTKJqTPkIUCqdztsJbksFOXTJZiiA(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = cXdEAfjSjCuVWDsJjJXnETWxsdzp.hNoRiloMAZCwMJhqxCSNjcRIpGck;
						P_0.CfhpsvHyWfICgEKNRdHQTCKBrgig(P_1);
					}
				}

				private IList<_0001> wTVLyoRitKXbxmmQrydDaWdlfRAG<_0001>(int P_0) where _0001 : ControllerMap
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = GoyqvLmpEQapPKDVVmOoCFeazQFLA<_0001>();
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.UVMfVDFkzMYcRREfXCclhxjeHNlXb<_0001>();
				}

				private IList<_0001> EHMTeHRxyBnVpSBokXZryzchUkPc<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return GoyqvLmpEQapPKDVVmOoCFeazQFLA<_0001>().YtFeKfEkAmOQogEaQlNHkzuLDejT(P_0)?.ZVqQCpBpHaJoxANGetaJnsjmlMojA.UVMfVDFkzMYcRREfXCclhxjeHNlXb<_0001>();
				}

				private IList<ControllerMap> MRsQAQVtPEyRCsBIWOVMxKHTskVi(ControllerType P_0, int P_1)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
				}

				private IList<ControllerMap> EHMTeHRxyBnVpSBokXZryzchUkPc(Controller P_0)
				{
					return MRsQAQVtPEyRCsBIWOVMxKHTskVi(P_0.type, P_0.id);
				}

				private void ZcbLmYETIybGNlbJQukhhQOqefee(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					TvBqLoaooHqQIQnCUZtKNIaOmRIg(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void cNjFMzUMVaLTzKdfdrrupbiAwUJh(Controller P_0, int P_1, int P_2)
				{
					MWCgqMvxMZwrEtvzqOtlPczMxlAv(P_0, P_1, P_2, BoolOption.Default);
				}

				private void ovdDVrllodtBicnoqMrkgjRwdDbg(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					WmCgtGJEaHaZsgvGmfvvSPGKsDpKA(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void IvcfQwUJBVohfKSVIHCsfLzJcRgF(Controller P_0, string P_1, string P_2)
				{
					QxWICNInVZuSdhMbIAvuFRsGmfBI(P_0, P_1, P_2, BoolOption.Default);
				}

				private void TvBqLoaooHqQIQnCUZtKNIaOmRIg(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num >= 0)
					{
						Controller controller = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc;
						ControllerMap controllerMap = ReInput.UserData.vniVhbPNujcZYbXBXYJYpZOHjbtl(controller, P_2, P_3);
						DrlmOaBijJsTUArfQmVSqVkjDrEK(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void MWCgqMvxMZwrEtvzqOtlPczMxlAv(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					TvBqLoaooHqQIQnCUZtKNIaOmRIg(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void WmCgtGJEaHaZsgvGmfvvSPGKsDpKA(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						TvBqLoaooHqQIQnCUZtKNIaOmRIg(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void QxWICNInVZuSdhMbIAvuFRsGmfBI(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					WmCgtGJEaHaZsgvGmfvvSPGKsDpKA(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void IilMRUvErvKEZNmyGeAzMAtNroCq(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0.type);
						int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_0.id);
						if (num >= 0)
						{
							KTKJqTPkIUCqdztsJbksFOXTJZiiA(P_0, P_1);
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.faxiPJYKqFdyTYHwJLKqXoJMGSreA(P_1, P_2);
							WZHhVSAounNRujhEarLlYpdQulVe.Apply();
						}
					}
				}

				private void DrlmOaBijJsTUArfQmVSqVkjDrEK(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						IilMRUvErvKEZNmyGeAzMAtNroCq(controller, P_2, P_3);
					}
				}

				private bool VcVkqCpCEZsLOkeqMPTNQaMmWtyn(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0).qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.qsvHbdffvMuvxyqzGXpxONTMtALL(P_0);
					try
					{
						ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
						if (!controllerMap.DSwzGEIPxVsmAwNxbOBVGsSTDVPr(P_2))
						{
							return false;
						}
					}
					finally
					{
						ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
					}
					DrlmOaBijJsTUArfQmVSqVkjDrEK(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int vdQZRsEZDerDkJeBjzknCyghPYyM(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0).qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (VcVkqCpCEZsLOkeqMPTNQaMmWtyn(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool CbTFZxeAIGfvwkyefdejbqeBvyJd(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0).qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.qsvHbdffvMuvxyqzGXpxONTMtALL(P_0);
					try
					{
						ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
						if (!controllerMap.cYpJMAZAHaucwCGHTHnaOlZdlVNm(P_2))
						{
							return false;
						}
					}
					finally
					{
						ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
					}
					DrlmOaBijJsTUArfQmVSqVkjDrEK(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int rBYsVEzLuENQRnMFWvkITUpvejLI(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0).qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (CbTFZxeAIGfvwkyefdejbqeBvyJd(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void UGBEMFNitpIeRiyPIilYrqtXyAOp(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num >= 0)
					{
						Controller controller = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc;
						ControllerMap controllerMap = ControllerMap.RGWeWlUjVEJhFbPqqedJvIlSkpWG(controller, P_2, P_3);
						DrlmOaBijJsTUArfQmVSqVkjDrEK(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void yCXIFzBxWNqlhTLhfTbcMiGizBTAA(Controller P_0, int P_1, int P_2)
				{
					UGBEMFNitpIeRiyPIilYrqtXyAOp(P_0.type, P_0.id, P_1, P_2);
				}

				private void AFlaEqCFPWezeIMYThApnIfDAHAYA(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						UGBEMFNitpIeRiyPIilYrqtXyAOp(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void IHLzQmRuMQqCkTcJELKKnGXvrrxc(Controller P_0, string P_1, string P_2)
				{
					AFlaEqCFPWezeIMYThApnIfDAHAYA(P_0.type, P_0.id, P_1, P_2);
				}

				private void fkHEVRPcOiDEsjKkrkiZcNAXIZNRA(ControllerType P_0, int P_1, int P_2)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num >= 0)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.MNoZMEpfobzdGGvOQtNwdPreUsVC(P_2);
					}
				}

				private void VCCFrheFVzNMSdUXlcswaZgFxqUdb(Controller P_0, int P_1)
				{
					fkHEVRPcOiDEsjKkrkiZcNAXIZNRA(P_0.type, P_0.id, P_1);
				}

				private void KtnKBrryfefnOSnyfExlqPwWcxDd(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num >= 0)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.KxFclFLIOfyXdPHLgunScAUWyrpt(P_2);
					}
				}

				private void ixJoZmWucJsWZnVvHcWpdIuRBtRs(Controller P_0, ControllerMap P_1)
				{
					fkHEVRPcOiDEsjKkrkiZcNAXIZNRA(P_0.type, P_0.id, P_1.id);
				}

				private void xizNhrxyAkdJdwQqsFyMEhKsQfmv(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num >= 0)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.ZhqFEnCBLTHuLVrMGAtDGrfjRrLFA(P_2, P_3);
					}
				}

				private void nJFNDFyZNUBjUGqrCNhIqCcveZQg(Controller P_0, int P_1, int P_2)
				{
					xizNhrxyAkdJdwQqsFyMEhKsQfmv(P_0.type, P_0.id, P_1, P_2);
				}

				private void PjMdbEJBdZKSgbYRYwhSWpnIGdMR(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.ZhqFEnCBLTHuLVrMGAtDGrfjRrLFA(mapCategoryId, layoutId);
						}
					}
				}

				private void plbmbWnnWjfqGKtEYHIdVXDknhkJ(Controller P_0, string P_1, string P_2)
				{
					PjMdbEJBdZKSgbYRYwhSWpnIGdMR(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap RdrslPMgUWhnzrfkmyZrvVtyrtHr(ControllerType P_0, int P_1, int P_2)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					return oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.tLdBkiHQJEXErXZFyiEPjfLXpcmt(P_2);
				}

				private ControllerMap yFhPGKMkCSdqdkgKWpMMoDRaVqbkA(Controller P_0, int P_1)
				{
					return RdrslPMgUWhnzrfkmyZrvVtyrtHr(P_0.type, P_0.id, P_1);
				}

				private ControllerMap UaGvoOcTewxxlvwVTsoTSRvlrcae(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					return oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.bQpvSZierUbmzKOWyWENemYalbAB(P_2, P_3);
				}

				private ControllerMap ZmzDGQcGiRQgkAMeYRkIeeWWxDSLA(Controller P_0, int P_1, int P_2)
				{
					return UaGvoOcTewxxlvwVTsoTSRvlrcae(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap lFugltKZRYzAOIMTlyEFIAhZEZPn(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return UaGvoOcTewxxlvwVTsoTSRvlrcae(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap GIlbMeEpzOImdnMqxtbgeDjXKueKA(Controller P_0, string P_1, string P_2)
				{
					return lFugltKZRYzAOIMTlyEFIAhZEZPn(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap NBWEdezXePaFbHUradxeVZcPUHvq(ControllerType P_0, int P_1, int P_2)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					return oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.uwTTSJAxnhVtQSVHRKonNwreMAJF(P_2);
				}

				private ControllerMap QGqKIjYiKhhiOnzmzjZjFPzRpPtC(Controller P_0, int P_1)
				{
					return NBWEdezXePaFbHUradxeVZcPUHvq(P_0.type, P_0.id, P_1);
				}

				private ControllerMap tXOmEHziQlqGPxakiwZivskDbXSg(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return NBWEdezXePaFbHUradxeVZcPUHvq(P_0, P_1, mapCategoryId);
				}

				private ControllerMap eZirMFJuIboulGjoTejwNLCTmNpV(Controller P_0, string P_1)
				{
					return tXOmEHziQlqGPxakiwZivskDbXSg(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] VebGBZVDcQIgXbNSTKIwUvQnlvur(ControllerType P_0)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = 0;
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						num += oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; j++)
					{
						wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
						for (int k = 0; k < wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo; k++)
						{
							array[num] = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] NcoFPeFPqQsdsZGRMZcspOzDexcA(ControllerType P_0, int P_1, bool P_2)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
					for (int i = 0; i < wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo; i++)
					{
						ControllerMap controllerMap = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc;
						list.Add(ControllerMapSaveData.VUPNKdEZWgnTzDORBcTvaPtqKYmGA(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] dYcAMJSDVPClqgUstKbGFkJJIGLlc<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = bVcNkmaJvbHeBNQRpaleQvWHeXqv.kwAmnVpusybgnlLYlBcXfzSGBOem<_0001>();
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
					for (int i = 0; i < wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo; i++)
					{
						ControllerMap controllerMap = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc;
						list.Add(ControllerMapSaveData.VUPNKdEZWgnTzDORBcTvaPtqKYmGA<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] MWoxpLIwAWwWChRToprbTydAFaw(ControllerType P_0, bool P_1)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
						for (int j = 0; j < wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo; j++)
						{
							ControllerMap controllerMap = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).UCMOBjKhfpoECrfBzBtZepnlTjUc;
							list.Add(ControllerMapSaveData.VUPNKdEZWgnTzDORBcTvaPtqKYmGA(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] iCJaMrHgOvFRPTyDUuUjtQbjHvWSA<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = bVcNkmaJvbHeBNQRpaleQvWHeXqv.kwAmnVpusybgnlLYlBcXfzSGBOem<_0001>();
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
						for (int j = 0; j < wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo; j++)
						{
							ControllerMap controllerMap = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).UCMOBjKhfpoECrfBzBtZepnlTjUc;
							list.Add(ControllerMapSaveData.VUPNKdEZWgnTzDORBcTvaPtqKYmGA<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int dxgFfGJMmmFzxclAhdxVZkVKFIhrB(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return 0;
					}
					return oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.ibSjZCazFZFmitMzMTvwZVTQNBqJ(P_2, P_3, false);
				}

				private int cGDOomXABiWFpSGgYczKVRpxlXKq(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return dxgFfGJMmmFzxclAhdxVZkVKFIhrB(P_0.type, P_0.id, P_1, P_2);
				}

				private int azfAYSUHqrpoCwrOdaHSyGKvcCv(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return dxgFfGJMmmFzxclAhdxVZkVKFIhrB(P_0, P_1, mapCategoryId, P_3);
				}

				private int JCiHdVkieNPrnfrHgidQZSXRVtnyA(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return azfAYSUHqrpoCwrOdaHSyGKvcCv(P_0.type, P_0.id, P_1, P_2);
				}

				[IteratorStateMachine(typeof(MBPLIoGKodVzJPSCngGMsSXihsQk))]
				private IEnumerable<ControllerMap> qVPMYnzMLWGhZpGTLHuhmBISHDpB(ControllerType P_0, int P_1, int P_2)
				{
					return new MBPLIoGKodVzJPSCngGMsSXihsQk(-2)
					{
						FGZCGRgUUsUgnNELxMmkevqsUeFB = this,
						pVUyBVhuqpKLQhcKzaBjiwpWioVx = P_0,
						ficIBDFdVYeTUJMnCZYorUYThosoA = P_1,
						dgcqGlYlYTHikWntzTTUYzSLbnrl = P_2
					};
				}

				[IteratorStateMachine(typeof(phtKbfPHuaelFAPbOhhDtVoCsWwcA))]
				private IEnumerable<_0001> VyVWhtxHCZGoqaRFJjsTSGlbvdXO<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new phtKbfPHuaelFAPbOhhDtVoCsWwcA<_0001>(-2)
					{
						gsNUXWRKEsPYsiZCIuNfbebNglqh = this,
						ZUCzApWBKAGrCJxqmfCWOzLZwDOFA = P_0,
						AcsFCyaPlatjqXIRBMoTbwjjbqBe = P_1
					};
				}

				private ActionElementMap HGJRYoHdDXIMdbOTbKFVBOZBVdGZ(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
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

				private ActionElementMap iMVUnUBBPqaRdjVorHmNWMiwZtTeA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return HGJRYoHdDXIMdbOTbKFVBOZBVdGZ(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(PpmWyAUuJDepsvsPdwPnmUEuqohJ))]
				private IEnumerable<ActionElementMap> KtaAloUEWKwPLRJsJezETHIzOEee(ControllerType P_0, int P_1, bool P_2)
				{
					return new PpmWyAUuJDepsvsPdwPnmUEuqohJ(-2)
					{
						eZVsKpgBaiUIZLOAnfPpmyzpHtvf = this,
						rGmAZicTuenWWAHzNgkwRFgSPRTP = P_0,
						SFFAAzdKJHaTWdtZLKryqdmkGyDc = P_1,
						qKkaWLPGHQygdcKmfPMoXirVzDnM = P_2
					};
				}

				private IEnumerable<ActionElementMap> SKNVggPNsrAPSLmLqgCuCQYdrODy(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return KtaAloUEWKwPLRJsJezETHIzOEee(P_0, num, P_2);
				}

				private ActionElementMap jcdftLakCUdJZLFeIkjCIfPoBjvI(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
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

				private ActionElementMap AMdXfykHwXjSwvaNcQGHIfsdRewi(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return jcdftLakCUdJZLFeIkjCIfPoBjvI(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(CGWKkdeOqdAVQcqKZlbYzJGjWMwuA))]
				private IEnumerable<ActionElementMap> UERgVJxEsqQjqmOKAEinzjADGjYhA(ControllerType P_0, int P_1, bool P_2)
				{
					return new CGWKkdeOqdAVQcqKZlbYzJGjWMwuA(-2)
					{
						LPQcGTfEQvtrQfETkSTswQaAoKxf = this,
						jQrFXcGbwRPeFYrRidvhxCTHZTQbA = P_0,
						gJwOKehQAItHTxrFKNUmHYcINhFH = P_1,
						CkEaBceTDmJfhfZPHPKJWKUDBMJJb = P_2
					};
				}

				private IEnumerable<ActionElementMap> AzNUflQxXWxsCZyRCcDGMhKHRODA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return UERgVJxEsqQjqmOKAEinzjADGjYhA(P_0, num, P_2);
				}

				private ActionElementMap HRPFsBhYmujGUVpMLyfmGUnfuuKd(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
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

				private ActionElementMap PltgSQUvgIFJRElxUlpbzNRWbAflA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return HRPFsBhYmujGUVpMLyfmGUnfuuKd(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(wfcsCBwWcQSLTyrGawXqOUrshHUH))]
				private IEnumerable<ActionElementMap> yBHUiKCjNUDiOkWbKyQxDpKpFOxF(ControllerType P_0, int P_1, bool P_2)
				{
					return new wfcsCBwWcQSLTyrGawXqOUrshHUH(-2)
					{
						eRJRXpAcDNbbcaPgytANyjLIHMae = this,
						KEuojHdhFGyLtACizdrCjMwXFXaqA = P_0,
						faMgSZgfNIBrseLNYEAsAPNhlwlGb = P_1,
						lTVFffdFdVKlCUAKLBqdrHDqcdfdb = P_2
					};
				}

				private IEnumerable<ActionElementMap> BlUqGkluFBvgfCdfDlbHbIVmdeoEA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return yBHUiKCjNUDiOkWbKyQxDpKpFOxF(P_0, num, P_2);
				}

				private int OjofpYOCrRoefKAeaaEvCGHaNALD(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num2; j++)
						{
							wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							int num3 = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.lkBCrZtdEzTNPDljURszfhzPaVej(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int GBPxRcwWLAsyLRTeHHQziTfYJlRc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num2; j++)
						{
							wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							int num3 = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							for (int k = 0; k < num3; k++)
							{
								if (wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.ONZxNRLiOvYiNvpMrcVcERUuJXkc(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int HYXXlCjtcHtXSoVXcSQPKQLoRAIE(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
					for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
					{
						oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i);
						int num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
						for (int j = 0; j < num2; j++)
						{
							wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(j).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
							int num3 = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.LPMKAKNrPSmdGMWdQtQBGKFQKxwb(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int rqngzfplaqDJqcqqccCUVzevFROl(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].lkBCrZtdEzTNPDljURszfhzPaVej(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int HbaDomBLuxBzGEppcgtRHdGeRWVtb(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return rqngzfplaqDJqcqqccCUVzevFROl(P_0, num, P_2, P_3, P_4);
				}

				private int FYVbtkcTazrRLFsLDlRDEeeQgjjC(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).ONZxNRLiOvYiNvpMrcVcERUuJXkc(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int TpjXMfefzYEpSNTSMZLkXheHHmJc(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return FYVbtkcTazrRLFsLDlRDEeeQgjjC(P_0, num, P_2, P_3, P_4);
				}

				private int NBuhVQnXYsQJKXNdadYXfeHfejGdb(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					for (int i = 0; i < oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb; i++)
					{
						IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].LPMKAKNrPSmdGMWdQtQBGKFQKxwb(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int XYWlAtSLEMEnVFwEHxgbIvwTGsaWA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_1);
					return NBuhVQnXYsQJKXNdadYXfeHfejGdb(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap XhcttLUKbTseIvkBwSHICbFMHKFZ(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
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

				private ActionElementMap BGoAwChjqlFAwfxSHZVYFmCttTmPA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return XhcttLUKbTseIvkBwSHICbFMHKFZ(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(mjrAhOLOnFTRkxuNsiOMmMBQPwFV))]
				private IEnumerable<ActionElementMap> cjWimFbbEqirlZvCtCgAIFMtOFIo(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new mjrAhOLOnFTRkxuNsiOMmMBQPwFV(-2)
					{
						dqMUQlVSbXFHiBkIAflPVxydFTsD = this,
						gfLgXfonmsElBsfrmaxAbaeBRnLV = P_0,
						pJFnwXqRWCfqPpcXeBABrlLvIlFT = P_1,
						USGaVaAWdKFlxscknKIojWwgKLRCB = P_2,
						iHIgSRGlIPVyxRCTMSzgqBzFQRsqA = P_3
					};
				}

				private IEnumerable<ActionElementMap> LkMPNnxYGuKBOgLBjszbASnzQtlu(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return cjWimFbbEqirlZvCtCgAIFMtOFIo(P_0, P_1, num, P_3);
				}

				private ActionElementMap psoTTtKPuRdnSAbFXQcclSUfNitz(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
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

				private ActionElementMap rbyIzriQQocNOQXhprYsMyAYBoOTA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return psoTTtKPuRdnSAbFXQcclSUfNitz(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(YBxRgIQOtyBzxiivWCFOgepaJXyIB))]
				private IEnumerable<ActionElementMap> olCqZHBDepoayDuofeSahRJirviw(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new YBxRgIQOtyBzxiivWCFOgepaJXyIB(-2)
					{
						vnQtadMQXXCqOjQxhuKWrTuxlpPQ = this,
						ZPZAcrrEdPfctgIfoQLHxCawrluZ = P_0,
						guqDqhTZKuWDQxcrCBgQelPNqvYC = P_1,
						CvGQJgIlNwNDMkkGKhZRnyMjHBSB = P_2,
						FIaVkHYbEtCtUaJeEWwNFmmzKHlbA = P_3
					};
				}

				private IEnumerable<ActionElementMap> mZkMObDHQmUWBOjfXtyfOIBsiHrV(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return olCqZHBDepoayDuofeSahRJirviw(P_0, P_1, num, P_3);
				}

				private ActionElementMap VpljgAIKfoQQWxnDNiXpjtTzxoeV(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
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

				private ActionElementMap vGwDrZEcZLyyGGxQvMGUpUjGdWQSA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return VpljgAIKfoQQWxnDNiXpjtTzxoeV(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(PKrBMBIttFRAqKvEugqYYfIcEyoPA))]
				private IEnumerable<ActionElementMap> kYEMzzsksoebBNrXRvuVLvVnBiNG(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new PKrBMBIttFRAqKvEugqYYfIcEyoPA(-2)
					{
						qgMJpFdEEFAdVxFUmrPuCLKvGymj = this,
						KlTSZjpSxXLDVxMrOarjFGJBmXWn = P_0,
						nHKGjcJLRbgYgdBKyvjfNPjpFiddA = P_1,
						SNylmTqcgGigFRryFfwkAZpJpUty = P_2,
						jfibdghgIZnscdBbqNycqGgAtiIlA = P_3
					};
				}

				private IEnumerable<ActionElementMap> ljEXXAGvUSkcmAKUAzdxgZZXJypj(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return kYEMzzsksoebBNrXRvuVLvVnBiNG(P_0, P_1, num, P_3);
				}

				private int OZOMdIJmJrIEmfiqOWjQFsetmouh(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.lkBCrZtdEzTNPDljURszfhzPaVej(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int NxazhtzYDEnsCIMSEHIgClZQkbOd(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return OZOMdIJmJrIEmfiqOWjQFsetmouh(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int yQyoNujjKAmaCeGUxhVQiamwAbDO(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.ONZxNRLiOvYiNvpMrcVcERUuJXkc(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int iuTBoPcWSDqMSIzQWCHazAEcWMMJA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return yQyoNujjKAmaCeGUxhVQiamwAbDO(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int mVmjKGclDAhZugDdZMdZIsuSzNDbA(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.qtobEIFmvZfFrfjFmUGnNGjVuSxuA(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).ZVqQCpBpHaJoxANGetaJnsjmlMojA.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].LPMKAKNrPSmdGMWdQtQBGKFQKxwb(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int yMQcjrKpUfFzWdXUrhaZtacEmzoLA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
					return mVmjKGclDAhZugDdZMdZIsuSzNDbA(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap XuEgUGruvelvmGUFnfQcLxuVJhEN(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controller.type);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					for (int i = 0; i < num; i++)
					{
						wfTqPVowqyEtwvBJoegCIMAGtbtoA obj = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
						_ = obj.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
						IList<ControllerMap> list = obj.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.KArrUOdDybdkCKycWMMqbUtKVtfsA(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				[IteratorStateMachine(typeof(IgYCiWjAkUvZcAbzOSxvuGtubauw))]
				private IEnumerable<ActionElementMap> aothuhuGWIdhbjGgctHELigQTPai(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new IgYCiWjAkUvZcAbzOSxvuGtubauw(-2)
					{
						LQAChaaBMEXhCvwHueNqOLqjRLRVA = this,
						EcLftAhHxqFjwCHRdpojjrglAadFb = P_0,
						AeLGOPaRfxFBcCQFauiZLRhXpQuW = P_1,
						axSTPfGKnqGMnKMfkRKRLwPxCpOL = P_2,
						iVUErOuKQEgYsdNpxLeHWpoDrihf = P_3
					};
				}

				private int dHufMQfpVtYdXSpFfJfiCgGcsFIRA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = DsajybfsHVDRfAdKzGTCFoiyZWnnA.tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controller.type);
					int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						wfTqPVowqyEtwvBJoegCIMAGtbtoA obj = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
						_ = obj.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
						IList<ControllerMap> list = obj.PNtTVhXmkSBOmygWCFnFOJyBLMPu;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.xVXvATEIJOyARtowfnOzbVGdtuAe(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
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
				private sealed class LEtuEJZnHuMEdwAlSUhBDDTwsRvA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int CNbarRMRMQgWdclMxKEsjDHJQNEfb;

					private ControllerPollingInfo meQFfOgnCQucOPRwoYFhhpWUXbWy;

					private int wfegUzhUMOPszBqyeVMLpJLWQNUfA;

					public PollingHelper fYSGoBVMrKzuODpXneUFvMHBAaYP;

					private IList<CustomController> TVEUYdoItbnoxZItZTYImoBEsPTf;

					private int lQfqdCGRfpAnbiHoLmCFvSWHgzRs;

					private int WRLApUFpIHQMLvQlhSfJmfUcOdQU;

					private IEnumerator<ControllerPollingInfo> kCUHOYKsCtnSbraZxDAYDednPRygb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return meQFfOgnCQucOPRwoYFhhpWUXbWy;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return meQFfOgnCQucOPRwoYFhhpWUXbWy;
						}
					}

					[DebuggerHidden]
					public LEtuEJZnHuMEdwAlSUhBDDTwsRvA(int P_0)
					{
						CNbarRMRMQgWdclMxKEsjDHJQNEfb = P_0;
						wfegUzhUMOPszBqyeVMLpJLWQNUfA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int cNbarRMRMQgWdclMxKEsjDHJQNEfb = CNbarRMRMQgWdclMxKEsjDHJQNEfb;
						if (cNbarRMRMQgWdclMxKEsjDHJQNEfb == -3 || cNbarRMRMQgWdclMxKEsjDHJQNEfb == 1)
						{
							try
							{
							}
							finally
							{
								FfyeNAxEwdOqzhaeSVrBTQYOhILv();
							}
						}
						TVEUYdoItbnoxZItZTYImoBEsPTf = null;
						kCUHOYKsCtnSbraZxDAYDednPRygb = null;
						CNbarRMRMQgWdclMxKEsjDHJQNEfb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int cNbarRMRMQgWdclMxKEsjDHJQNEfb = CNbarRMRMQgWdclMxKEsjDHJQNEfb;
							PollingHelper pollingHelper = fYSGoBVMrKzuODpXneUFvMHBAaYP;
							if (cNbarRMRMQgWdclMxKEsjDHJQNEfb != 0)
							{
								if (cNbarRMRMQgWdclMxKEsjDHJQNEfb != 1)
								{
									return false;
								}
								CNbarRMRMQgWdclMxKEsjDHJQNEfb = -3;
								goto IL_00c5;
							}
							CNbarRMRMQgWdclMxKEsjDHJQNEfb = -1;
							TVEUYdoItbnoxZItZTYImoBEsPTf = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							lQfqdCGRfpAnbiHoLmCFvSWHgzRs = TVEUYdoItbnoxZItZTYImoBEsPTf.Count;
							WRLApUFpIHQMLvQlhSfJmfUcOdQU = 0;
							goto IL_00f1;
							IL_00c5:
							if (kCUHOYKsCtnSbraZxDAYDednPRygb.MoveNext())
							{
								ControllerPollingInfo current = kCUHOYKsCtnSbraZxDAYDednPRygb.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								meQFfOgnCQucOPRwoYFhhpWUXbWy = controllerPollingInfo;
								CNbarRMRMQgWdclMxKEsjDHJQNEfb = 1;
								return true;
							}
							FfyeNAxEwdOqzhaeSVrBTQYOhILv();
							kCUHOYKsCtnSbraZxDAYDednPRygb = null;
							WRLApUFpIHQMLvQlhSfJmfUcOdQU++;
							goto IL_00f1;
							IL_00f1:
							if (WRLApUFpIHQMLvQlhSfJmfUcOdQU < lQfqdCGRfpAnbiHoLmCFvSWHgzRs)
							{
								kCUHOYKsCtnSbraZxDAYDednPRygb = TVEUYdoItbnoxZItZTYImoBEsPTf[WRLApUFpIHQMLvQlhSfJmfUcOdQU].PollForAllAxes().GetEnumerator();
								CNbarRMRMQgWdclMxKEsjDHJQNEfb = -3;
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

					private void FfyeNAxEwdOqzhaeSVrBTQYOhILv()
					{
						CNbarRMRMQgWdclMxKEsjDHJQNEfb = -1;
						if (kCUHOYKsCtnSbraZxDAYDednPRygb != null)
						{
							kCUHOYKsCtnSbraZxDAYDednPRygb.Dispose();
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
						LEtuEJZnHuMEdwAlSUhBDDTwsRvA lEtuEJZnHuMEdwAlSUhBDDTwsRvA;
						if (CNbarRMRMQgWdclMxKEsjDHJQNEfb == -2 && wfegUzhUMOPszBqyeVMLpJLWQNUfA == Environment.CurrentManagedThreadId)
						{
							CNbarRMRMQgWdclMxKEsjDHJQNEfb = 0;
							lEtuEJZnHuMEdwAlSUhBDDTwsRvA = this;
						}
						else
						{
							lEtuEJZnHuMEdwAlSUhBDDTwsRvA = new LEtuEJZnHuMEdwAlSUhBDDTwsRvA(0);
							lEtuEJZnHuMEdwAlSUhBDDTwsRvA.fYSGoBVMrKzuODpXneUFvMHBAaYP = fYSGoBVMrKzuODpXneUFvMHBAaYP;
						}
						return lEtuEJZnHuMEdwAlSUhBDDTwsRvA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class boCxPROblnZTaIphqGwfOsVCTxHd : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int DBkprqguEJIJFpXtTNshtyamoJMj;

					private ControllerPollingInfo IqZHIueoUJuUiKAvbRVyJbkeascP;

					private int UzLHIfEZirwbSGJoTDGVmFgDUEBS;

					public PollingHelper tThcghcxNhgEVATigWQmPzqxoHpy;

					private IList<CustomController> TVmshfdfWscRGiyGJZcpchweSyZs;

					private int zdFpKsRsBjItKxrvOdGGsqHJGvEx;

					private int LwSsfIosIXvwEsHQNWZYzIxuQVUy;

					private IEnumerator<ControllerPollingInfo> qTqGXUyjEChEIvuwKmrHiiVNWKSx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return IqZHIueoUJuUiKAvbRVyJbkeascP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return IqZHIueoUJuUiKAvbRVyJbkeascP;
						}
					}

					[DebuggerHidden]
					public boCxPROblnZTaIphqGwfOsVCTxHd(int P_0)
					{
						DBkprqguEJIJFpXtTNshtyamoJMj = P_0;
						UzLHIfEZirwbSGJoTDGVmFgDUEBS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dBkprqguEJIJFpXtTNshtyamoJMj = DBkprqguEJIJFpXtTNshtyamoJMj;
						if (dBkprqguEJIJFpXtTNshtyamoJMj == -3 || dBkprqguEJIJFpXtTNshtyamoJMj == 1)
						{
							try
							{
							}
							finally
							{
								PTXbWgFHAyAlgTSKtUdhTUvXdWOE();
							}
						}
						TVmshfdfWscRGiyGJZcpchweSyZs = null;
						qTqGXUyjEChEIvuwKmrHiiVNWKSx = null;
						DBkprqguEJIJFpXtTNshtyamoJMj = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int dBkprqguEJIJFpXtTNshtyamoJMj = DBkprqguEJIJFpXtTNshtyamoJMj;
							PollingHelper pollingHelper = tThcghcxNhgEVATigWQmPzqxoHpy;
							if (dBkprqguEJIJFpXtTNshtyamoJMj != 0)
							{
								if (dBkprqguEJIJFpXtTNshtyamoJMj != 1)
								{
									return false;
								}
								DBkprqguEJIJFpXtTNshtyamoJMj = -3;
								goto IL_00c5;
							}
							DBkprqguEJIJFpXtTNshtyamoJMj = -1;
							TVmshfdfWscRGiyGJZcpchweSyZs = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							zdFpKsRsBjItKxrvOdGGsqHJGvEx = TVmshfdfWscRGiyGJZcpchweSyZs.Count;
							LwSsfIosIXvwEsHQNWZYzIxuQVUy = 0;
							goto IL_00f1;
							IL_00c5:
							if (qTqGXUyjEChEIvuwKmrHiiVNWKSx.MoveNext())
							{
								ControllerPollingInfo current = qTqGXUyjEChEIvuwKmrHiiVNWKSx.Current;
								ControllerPollingInfo iqZHIueoUJuUiKAvbRVyJbkeascP = new ControllerPollingInfo(current);
								iqZHIueoUJuUiKAvbRVyJbkeascP.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								IqZHIueoUJuUiKAvbRVyJbkeascP = iqZHIueoUJuUiKAvbRVyJbkeascP;
								DBkprqguEJIJFpXtTNshtyamoJMj = 1;
								return true;
							}
							PTXbWgFHAyAlgTSKtUdhTUvXdWOE();
							qTqGXUyjEChEIvuwKmrHiiVNWKSx = null;
							LwSsfIosIXvwEsHQNWZYzIxuQVUy++;
							goto IL_00f1;
							IL_00f1:
							if (LwSsfIosIXvwEsHQNWZYzIxuQVUy < zdFpKsRsBjItKxrvOdGGsqHJGvEx)
							{
								qTqGXUyjEChEIvuwKmrHiiVNWKSx = TVmshfdfWscRGiyGJZcpchweSyZs[LwSsfIosIXvwEsHQNWZYzIxuQVUy].PollForAllButtons().GetEnumerator();
								DBkprqguEJIJFpXtTNshtyamoJMj = -3;
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

					private void PTXbWgFHAyAlgTSKtUdhTUvXdWOE()
					{
						DBkprqguEJIJFpXtTNshtyamoJMj = -1;
						if (qTqGXUyjEChEIvuwKmrHiiVNWKSx != null)
						{
							qTqGXUyjEChEIvuwKmrHiiVNWKSx.Dispose();
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
						boCxPROblnZTaIphqGwfOsVCTxHd boCxPROblnZTaIphqGwfOsVCTxHd2;
						if (DBkprqguEJIJFpXtTNshtyamoJMj == -2 && UzLHIfEZirwbSGJoTDGVmFgDUEBS == Environment.CurrentManagedThreadId)
						{
							DBkprqguEJIJFpXtTNshtyamoJMj = 0;
							boCxPROblnZTaIphqGwfOsVCTxHd2 = this;
						}
						else
						{
							boCxPROblnZTaIphqGwfOsVCTxHd2 = new boCxPROblnZTaIphqGwfOsVCTxHd(0);
							boCxPROblnZTaIphqGwfOsVCTxHd2.tThcghcxNhgEVATigWQmPzqxoHpy = tThcghcxNhgEVATigWQmPzqxoHpy;
						}
						return boCxPROblnZTaIphqGwfOsVCTxHd2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class steWnvfRBcmFLwJYbihRZmWHcxMiA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int bHvCMNEqiwRkIWwehVhnjXguldfK;

					private ControllerPollingInfo kSrFVsQmrDMliVsmhTJDNKLhnqYP;

					private int aWVWyyDpmNuTpLEmTMunHyWTEwQI;

					public PollingHelper cOuBAWbxbaOmUvlyVIywVXQeAWjJ;

					private IList<CustomController> BmFCtPDJvZghlaZqGTWxyZhEcgNmB;

					private int xJMuAlLAmeQjpUDPaallplOINLtg;

					private int DYiWpasUkCDtmGGZBksdIlWjrtYL;

					private IEnumerator<ControllerPollingInfo> wXCtRfbZqNWSjOsnFexgADllSTam;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kSrFVsQmrDMliVsmhTJDNKLhnqYP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kSrFVsQmrDMliVsmhTJDNKLhnqYP;
						}
					}

					[DebuggerHidden]
					public steWnvfRBcmFLwJYbihRZmWHcxMiA(int P_0)
					{
						bHvCMNEqiwRkIWwehVhnjXguldfK = P_0;
						aWVWyyDpmNuTpLEmTMunHyWTEwQI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bHvCMNEqiwRkIWwehVhnjXguldfK;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								xOHbuimhfnaxNOicJALVjDCvgNqI();
							}
						}
						BmFCtPDJvZghlaZqGTWxyZhEcgNmB = null;
						wXCtRfbZqNWSjOsnFexgADllSTam = null;
						bHvCMNEqiwRkIWwehVhnjXguldfK = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bHvCMNEqiwRkIWwehVhnjXguldfK;
							PollingHelper pollingHelper = cOuBAWbxbaOmUvlyVIywVXQeAWjJ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bHvCMNEqiwRkIWwehVhnjXguldfK = -3;
								goto IL_00c5;
							}
							bHvCMNEqiwRkIWwehVhnjXguldfK = -1;
							BmFCtPDJvZghlaZqGTWxyZhEcgNmB = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							xJMuAlLAmeQjpUDPaallplOINLtg = BmFCtPDJvZghlaZqGTWxyZhEcgNmB.Count;
							DYiWpasUkCDtmGGZBksdIlWjrtYL = 0;
							goto IL_00f1;
							IL_00c5:
							if (wXCtRfbZqNWSjOsnFexgADllSTam.MoveNext())
							{
								ControllerPollingInfo current = wXCtRfbZqNWSjOsnFexgADllSTam.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								kSrFVsQmrDMliVsmhTJDNKLhnqYP = controllerPollingInfo;
								bHvCMNEqiwRkIWwehVhnjXguldfK = 1;
								return true;
							}
							xOHbuimhfnaxNOicJALVjDCvgNqI();
							wXCtRfbZqNWSjOsnFexgADllSTam = null;
							DYiWpasUkCDtmGGZBksdIlWjrtYL++;
							goto IL_00f1;
							IL_00f1:
							if (DYiWpasUkCDtmGGZBksdIlWjrtYL < xJMuAlLAmeQjpUDPaallplOINLtg)
							{
								wXCtRfbZqNWSjOsnFexgADllSTam = BmFCtPDJvZghlaZqGTWxyZhEcgNmB[DYiWpasUkCDtmGGZBksdIlWjrtYL].PollForAllButtonsDown().GetEnumerator();
								bHvCMNEqiwRkIWwehVhnjXguldfK = -3;
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

					private void xOHbuimhfnaxNOicJALVjDCvgNqI()
					{
						bHvCMNEqiwRkIWwehVhnjXguldfK = -1;
						if (wXCtRfbZqNWSjOsnFexgADllSTam != null)
						{
							wXCtRfbZqNWSjOsnFexgADllSTam.Dispose();
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
						steWnvfRBcmFLwJYbihRZmWHcxMiA steWnvfRBcmFLwJYbihRZmWHcxMiA2;
						if (bHvCMNEqiwRkIWwehVhnjXguldfK == -2 && aWVWyyDpmNuTpLEmTMunHyWTEwQI == Environment.CurrentManagedThreadId)
						{
							bHvCMNEqiwRkIWwehVhnjXguldfK = 0;
							steWnvfRBcmFLwJYbihRZmWHcxMiA2 = this;
						}
						else
						{
							steWnvfRBcmFLwJYbihRZmWHcxMiA2 = new steWnvfRBcmFLwJYbihRZmWHcxMiA(0);
							steWnvfRBcmFLwJYbihRZmWHcxMiA2.cOuBAWbxbaOmUvlyVIywVXQeAWjJ = cOuBAWbxbaOmUvlyVIywVXQeAWjJ;
						}
						return steWnvfRBcmFLwJYbihRZmWHcxMiA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class PhMUNHpTgpvhCvTrAyzKqEvtvotI : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YkzFALPlDqHJDpWIDbGpZuUBbxNd;

					private ControllerPollingInfo druVxQDKGDZceJszxGxCkVmuSbsB;

					private int BUMvbgOazFHQzPmSlrXuoTtHyWkd;

					public PollingHelper pNUZBCcKpeTDzYUElhFSXIJzAvwi;

					private IList<CustomController> sIYvGCEJbWwiILeUhzngbQRwLYjp;

					private int GvlGFWWthsBPJfUNVxCpRqegQEzGb;

					private int JUfGsBbPvPpEfEKyIdSdHwWEGXAAe;

					private IEnumerator<ControllerPollingInfo> IQLDvWjRBGwucewzxjJGoIngMItF;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return druVxQDKGDZceJszxGxCkVmuSbsB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return druVxQDKGDZceJszxGxCkVmuSbsB;
						}
					}

					[DebuggerHidden]
					public PhMUNHpTgpvhCvTrAyzKqEvtvotI(int P_0)
					{
						YkzFALPlDqHJDpWIDbGpZuUBbxNd = P_0;
						BUMvbgOazFHQzPmSlrXuoTtHyWkd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ykzFALPlDqHJDpWIDbGpZuUBbxNd = YkzFALPlDqHJDpWIDbGpZuUBbxNd;
						if (ykzFALPlDqHJDpWIDbGpZuUBbxNd == -3 || ykzFALPlDqHJDpWIDbGpZuUBbxNd == 1)
						{
							try
							{
							}
							finally
							{
								XqwZNOCNjVtYAUZIvpIpfrFojOXi();
							}
						}
						sIYvGCEJbWwiILeUhzngbQRwLYjp = null;
						IQLDvWjRBGwucewzxjJGoIngMItF = null;
						YkzFALPlDqHJDpWIDbGpZuUBbxNd = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ykzFALPlDqHJDpWIDbGpZuUBbxNd = YkzFALPlDqHJDpWIDbGpZuUBbxNd;
							PollingHelper pollingHelper = pNUZBCcKpeTDzYUElhFSXIJzAvwi;
							if (ykzFALPlDqHJDpWIDbGpZuUBbxNd != 0)
							{
								if (ykzFALPlDqHJDpWIDbGpZuUBbxNd != 1)
								{
									return false;
								}
								YkzFALPlDqHJDpWIDbGpZuUBbxNd = -3;
								goto IL_00c5;
							}
							YkzFALPlDqHJDpWIDbGpZuUBbxNd = -1;
							sIYvGCEJbWwiILeUhzngbQRwLYjp = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							GvlGFWWthsBPJfUNVxCpRqegQEzGb = sIYvGCEJbWwiILeUhzngbQRwLYjp.Count;
							JUfGsBbPvPpEfEKyIdSdHwWEGXAAe = 0;
							goto IL_00f1;
							IL_00c5:
							if (IQLDvWjRBGwucewzxjJGoIngMItF.MoveNext())
							{
								ControllerPollingInfo current = IQLDvWjRBGwucewzxjJGoIngMItF.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								druVxQDKGDZceJszxGxCkVmuSbsB = controllerPollingInfo;
								YkzFALPlDqHJDpWIDbGpZuUBbxNd = 1;
								return true;
							}
							XqwZNOCNjVtYAUZIvpIpfrFojOXi();
							IQLDvWjRBGwucewzxjJGoIngMItF = null;
							JUfGsBbPvPpEfEKyIdSdHwWEGXAAe++;
							goto IL_00f1;
							IL_00f1:
							if (JUfGsBbPvPpEfEKyIdSdHwWEGXAAe < GvlGFWWthsBPJfUNVxCpRqegQEzGb)
							{
								IQLDvWjRBGwucewzxjJGoIngMItF = sIYvGCEJbWwiILeUhzngbQRwLYjp[JUfGsBbPvPpEfEKyIdSdHwWEGXAAe].PollForAllElements().GetEnumerator();
								YkzFALPlDqHJDpWIDbGpZuUBbxNd = -3;
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

					private void XqwZNOCNjVtYAUZIvpIpfrFojOXi()
					{
						YkzFALPlDqHJDpWIDbGpZuUBbxNd = -1;
						if (IQLDvWjRBGwucewzxjJGoIngMItF != null)
						{
							IQLDvWjRBGwucewzxjJGoIngMItF.Dispose();
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
						PhMUNHpTgpvhCvTrAyzKqEvtvotI phMUNHpTgpvhCvTrAyzKqEvtvotI;
						if (YkzFALPlDqHJDpWIDbGpZuUBbxNd == -2 && BUMvbgOazFHQzPmSlrXuoTtHyWkd == Environment.CurrentManagedThreadId)
						{
							YkzFALPlDqHJDpWIDbGpZuUBbxNd = 0;
							phMUNHpTgpvhCvTrAyzKqEvtvotI = this;
						}
						else
						{
							phMUNHpTgpvhCvTrAyzKqEvtvotI = new PhMUNHpTgpvhCvTrAyzKqEvtvotI(0);
							phMUNHpTgpvhCvTrAyzKqEvtvotI.pNUZBCcKpeTDzYUElhFSXIJzAvwi = pNUZBCcKpeTDzYUElhFSXIJzAvwi;
						}
						return phMUNHpTgpvhCvTrAyzKqEvtvotI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class EgmjaBUhPdCSfNccSZIqRTYnmqSU : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EfBHnaSoJaCIPxBYzJDNeemJNjNc;

					private ControllerPollingInfo cinkvbtXEMGVHqwatEPoxdNOggZw;

					private int RctJCWcLVPaXmdhgOMpNTzHAhCQB;

					public PollingHelper zIdgyehepicDnATTaYCSpeKFHnwL;

					private IList<CustomController> xCOmkHjcWLOyfXocNImyDcKjrGwQ;

					private int PtXPOncHyxltshONLwiMtOzVvCeV;

					private int uHIBrSBYitdYfYjLMkjwSgJgJRaN;

					private IEnumerator<ControllerPollingInfo> ZChBBpChaOHNyrXsMwfynIplNxjU;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return cinkvbtXEMGVHqwatEPoxdNOggZw;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return cinkvbtXEMGVHqwatEPoxdNOggZw;
						}
					}

					[DebuggerHidden]
					public EgmjaBUhPdCSfNccSZIqRTYnmqSU(int P_0)
					{
						EfBHnaSoJaCIPxBYzJDNeemJNjNc = P_0;
						RctJCWcLVPaXmdhgOMpNTzHAhCQB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int efBHnaSoJaCIPxBYzJDNeemJNjNc = EfBHnaSoJaCIPxBYzJDNeemJNjNc;
						if (efBHnaSoJaCIPxBYzJDNeemJNjNc == -3 || efBHnaSoJaCIPxBYzJDNeemJNjNc == 1)
						{
							try
							{
							}
							finally
							{
								RuwYKHceiPNSSqmFOFTAENmJuLhoA();
							}
						}
						xCOmkHjcWLOyfXocNImyDcKjrGwQ = null;
						ZChBBpChaOHNyrXsMwfynIplNxjU = null;
						EfBHnaSoJaCIPxBYzJDNeemJNjNc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int efBHnaSoJaCIPxBYzJDNeemJNjNc = EfBHnaSoJaCIPxBYzJDNeemJNjNc;
							PollingHelper pollingHelper = zIdgyehepicDnATTaYCSpeKFHnwL;
							if (efBHnaSoJaCIPxBYzJDNeemJNjNc != 0)
							{
								if (efBHnaSoJaCIPxBYzJDNeemJNjNc != 1)
								{
									return false;
								}
								EfBHnaSoJaCIPxBYzJDNeemJNjNc = -3;
								goto IL_00c5;
							}
							EfBHnaSoJaCIPxBYzJDNeemJNjNc = -1;
							xCOmkHjcWLOyfXocNImyDcKjrGwQ = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							PtXPOncHyxltshONLwiMtOzVvCeV = xCOmkHjcWLOyfXocNImyDcKjrGwQ.Count;
							uHIBrSBYitdYfYjLMkjwSgJgJRaN = 0;
							goto IL_00f1;
							IL_00c5:
							if (ZChBBpChaOHNyrXsMwfynIplNxjU.MoveNext())
							{
								ControllerPollingInfo current = ZChBBpChaOHNyrXsMwfynIplNxjU.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								cinkvbtXEMGVHqwatEPoxdNOggZw = controllerPollingInfo;
								EfBHnaSoJaCIPxBYzJDNeemJNjNc = 1;
								return true;
							}
							RuwYKHceiPNSSqmFOFTAENmJuLhoA();
							ZChBBpChaOHNyrXsMwfynIplNxjU = null;
							uHIBrSBYitdYfYjLMkjwSgJgJRaN++;
							goto IL_00f1;
							IL_00f1:
							if (uHIBrSBYitdYfYjLMkjwSgJgJRaN < PtXPOncHyxltshONLwiMtOzVvCeV)
							{
								ZChBBpChaOHNyrXsMwfynIplNxjU = xCOmkHjcWLOyfXocNImyDcKjrGwQ[uHIBrSBYitdYfYjLMkjwSgJgJRaN].PollForAllElementsDown().GetEnumerator();
								EfBHnaSoJaCIPxBYzJDNeemJNjNc = -3;
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

					private void RuwYKHceiPNSSqmFOFTAENmJuLhoA()
					{
						EfBHnaSoJaCIPxBYzJDNeemJNjNc = -1;
						if (ZChBBpChaOHNyrXsMwfynIplNxjU != null)
						{
							ZChBBpChaOHNyrXsMwfynIplNxjU.Dispose();
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
						EgmjaBUhPdCSfNccSZIqRTYnmqSU egmjaBUhPdCSfNccSZIqRTYnmqSU;
						if (EfBHnaSoJaCIPxBYzJDNeemJNjNc == -2 && RctJCWcLVPaXmdhgOMpNTzHAhCQB == Environment.CurrentManagedThreadId)
						{
							EfBHnaSoJaCIPxBYzJDNeemJNjNc = 0;
							egmjaBUhPdCSfNccSZIqRTYnmqSU = this;
						}
						else
						{
							egmjaBUhPdCSfNccSZIqRTYnmqSU = new EgmjaBUhPdCSfNccSZIqRTYnmqSU(0);
							egmjaBUhPdCSfNccSZIqRTYnmqSU.zIdgyehepicDnATTaYCSpeKFHnwL = zIdgyehepicDnATTaYCSpeKFHnwL;
						}
						return egmjaBUhPdCSfNccSZIqRTYnmqSU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class AKwXKcypbkTzaPwTeaeaqBXOuvnc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GXFgDiVJTxBSLjNdVXJKSJaTdYZp;

					private ControllerPollingInfo tuVEvQLpyGJLbzqevaFpjcFWlLEV;

					private int rNchwNtkCdCjNAUStjBNReoOlZGCA;

					public PollingHelper bOBChMfCZhRKOwVbydfIcTKpOeMl;

					private IList<Joystick> MuhSCszNvnkwuoZXLlTxLIXlVVuI;

					private int QPOomHQQHjxRchujnbhZfVqewmok;

					private int pjaQUtWgMqOxNbPgOFxtdGFcPoIP;

					private IEnumerator<ControllerPollingInfo> UfWHOaklUTEtLRNLnasAfJlxeArO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tuVEvQLpyGJLbzqevaFpjcFWlLEV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tuVEvQLpyGJLbzqevaFpjcFWlLEV;
						}
					}

					[DebuggerHidden]
					public AKwXKcypbkTzaPwTeaeaqBXOuvnc(int P_0)
					{
						GXFgDiVJTxBSLjNdVXJKSJaTdYZp = P_0;
						rNchwNtkCdCjNAUStjBNReoOlZGCA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gXFgDiVJTxBSLjNdVXJKSJaTdYZp = GXFgDiVJTxBSLjNdVXJKSJaTdYZp;
						if (gXFgDiVJTxBSLjNdVXJKSJaTdYZp == -3 || gXFgDiVJTxBSLjNdVXJKSJaTdYZp == 1)
						{
							try
							{
							}
							finally
							{
								JvqIzpevZlpNoNWYFMHeYPHyuNpn();
							}
						}
						MuhSCszNvnkwuoZXLlTxLIXlVVuI = null;
						UfWHOaklUTEtLRNLnasAfJlxeArO = null;
						GXFgDiVJTxBSLjNdVXJKSJaTdYZp = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int gXFgDiVJTxBSLjNdVXJKSJaTdYZp = GXFgDiVJTxBSLjNdVXJKSJaTdYZp;
							PollingHelper pollingHelper = bOBChMfCZhRKOwVbydfIcTKpOeMl;
							if (gXFgDiVJTxBSLjNdVXJKSJaTdYZp != 0)
							{
								if (gXFgDiVJTxBSLjNdVXJKSJaTdYZp != 1)
								{
									return false;
								}
								GXFgDiVJTxBSLjNdVXJKSJaTdYZp = -3;
								goto IL_00c5;
							}
							GXFgDiVJTxBSLjNdVXJKSJaTdYZp = -1;
							MuhSCszNvnkwuoZXLlTxLIXlVVuI = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							QPOomHQQHjxRchujnbhZfVqewmok = MuhSCszNvnkwuoZXLlTxLIXlVVuI.Count;
							pjaQUtWgMqOxNbPgOFxtdGFcPoIP = 0;
							goto IL_00f1;
							IL_00c5:
							if (UfWHOaklUTEtLRNLnasAfJlxeArO.MoveNext())
							{
								ControllerPollingInfo current = UfWHOaklUTEtLRNLnasAfJlxeArO.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								tuVEvQLpyGJLbzqevaFpjcFWlLEV = controllerPollingInfo;
								GXFgDiVJTxBSLjNdVXJKSJaTdYZp = 1;
								return true;
							}
							JvqIzpevZlpNoNWYFMHeYPHyuNpn();
							UfWHOaklUTEtLRNLnasAfJlxeArO = null;
							pjaQUtWgMqOxNbPgOFxtdGFcPoIP++;
							goto IL_00f1;
							IL_00f1:
							if (pjaQUtWgMqOxNbPgOFxtdGFcPoIP < QPOomHQQHjxRchujnbhZfVqewmok)
							{
								UfWHOaklUTEtLRNLnasAfJlxeArO = MuhSCszNvnkwuoZXLlTxLIXlVVuI[pjaQUtWgMqOxNbPgOFxtdGFcPoIP].PollForAllAxes().GetEnumerator();
								GXFgDiVJTxBSLjNdVXJKSJaTdYZp = -3;
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

					private void JvqIzpevZlpNoNWYFMHeYPHyuNpn()
					{
						GXFgDiVJTxBSLjNdVXJKSJaTdYZp = -1;
						if (UfWHOaklUTEtLRNLnasAfJlxeArO != null)
						{
							UfWHOaklUTEtLRNLnasAfJlxeArO.Dispose();
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
						AKwXKcypbkTzaPwTeaeaqBXOuvnc aKwXKcypbkTzaPwTeaeaqBXOuvnc;
						if (GXFgDiVJTxBSLjNdVXJKSJaTdYZp == -2 && rNchwNtkCdCjNAUStjBNReoOlZGCA == Environment.CurrentManagedThreadId)
						{
							GXFgDiVJTxBSLjNdVXJKSJaTdYZp = 0;
							aKwXKcypbkTzaPwTeaeaqBXOuvnc = this;
						}
						else
						{
							aKwXKcypbkTzaPwTeaeaqBXOuvnc = new AKwXKcypbkTzaPwTeaeaqBXOuvnc(0);
							aKwXKcypbkTzaPwTeaeaqBXOuvnc.bOBChMfCZhRKOwVbydfIcTKpOeMl = bOBChMfCZhRKOwVbydfIcTKpOeMl;
						}
						return aKwXKcypbkTzaPwTeaeaqBXOuvnc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class iGqUhkSIxRElHPiUkYIOkNgZpxKQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qrafjqHjXFHlSEfzihbrcyPGVJIlB;

					private ControllerPollingInfo xuvRffxGlnAlMdGxTqfpbihSNedD;

					private int iBMgKBXhSOAzgivzrCxHZOBUJiLab;

					public PollingHelper JotauEGXGudSglyjpAtVayYlPKdzA;

					private IList<Joystick> LQmrlaYTOGlUMYrCBosbQyDJrUHl;

					private int ivoYApADEESxhYAMUhddnWXnRRNQ;

					private int mHnRYvFzkiUEilpgsefoAOdRecyD;

					private IEnumerator<ControllerPollingInfo> ahvbbfvjRZehWCtAVmeGnUFDkLxNA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return xuvRffxGlnAlMdGxTqfpbihSNedD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xuvRffxGlnAlMdGxTqfpbihSNedD;
						}
					}

					[DebuggerHidden]
					public iGqUhkSIxRElHPiUkYIOkNgZpxKQ(int P_0)
					{
						qrafjqHjXFHlSEfzihbrcyPGVJIlB = P_0;
						iBMgKBXhSOAzgivzrCxHZOBUJiLab = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qrafjqHjXFHlSEfzihbrcyPGVJIlB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RCNwHqIErpBzAuMnwFIppBXwwQSA();
							}
						}
						LQmrlaYTOGlUMYrCBosbQyDJrUHl = null;
						ahvbbfvjRZehWCtAVmeGnUFDkLxNA = null;
						qrafjqHjXFHlSEfzihbrcyPGVJIlB = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = qrafjqHjXFHlSEfzihbrcyPGVJIlB;
							PollingHelper jotauEGXGudSglyjpAtVayYlPKdzA = JotauEGXGudSglyjpAtVayYlPKdzA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qrafjqHjXFHlSEfzihbrcyPGVJIlB = -3;
								goto IL_00c5;
							}
							qrafjqHjXFHlSEfzihbrcyPGVJIlB = -1;
							LQmrlaYTOGlUMYrCBosbQyDJrUHl = jotauEGXGudSglyjpAtVayYlPKdzA.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							ivoYApADEESxhYAMUhddnWXnRRNQ = LQmrlaYTOGlUMYrCBosbQyDJrUHl.Count;
							mHnRYvFzkiUEilpgsefoAOdRecyD = 0;
							goto IL_00f1;
							IL_00c5:
							if (ahvbbfvjRZehWCtAVmeGnUFDkLxNA.MoveNext())
							{
								ControllerPollingInfo current = ahvbbfvjRZehWCtAVmeGnUFDkLxNA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = jotauEGXGudSglyjpAtVayYlPKdzA.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								xuvRffxGlnAlMdGxTqfpbihSNedD = controllerPollingInfo;
								qrafjqHjXFHlSEfzihbrcyPGVJIlB = 1;
								return true;
							}
							RCNwHqIErpBzAuMnwFIppBXwwQSA();
							ahvbbfvjRZehWCtAVmeGnUFDkLxNA = null;
							mHnRYvFzkiUEilpgsefoAOdRecyD++;
							goto IL_00f1;
							IL_00f1:
							if (mHnRYvFzkiUEilpgsefoAOdRecyD < ivoYApADEESxhYAMUhddnWXnRRNQ)
							{
								ahvbbfvjRZehWCtAVmeGnUFDkLxNA = LQmrlaYTOGlUMYrCBosbQyDJrUHl[mHnRYvFzkiUEilpgsefoAOdRecyD].PollForAllButtons().GetEnumerator();
								qrafjqHjXFHlSEfzihbrcyPGVJIlB = -3;
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

					private void RCNwHqIErpBzAuMnwFIppBXwwQSA()
					{
						qrafjqHjXFHlSEfzihbrcyPGVJIlB = -1;
						if (ahvbbfvjRZehWCtAVmeGnUFDkLxNA != null)
						{
							ahvbbfvjRZehWCtAVmeGnUFDkLxNA.Dispose();
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
						iGqUhkSIxRElHPiUkYIOkNgZpxKQ iGqUhkSIxRElHPiUkYIOkNgZpxKQ2;
						if (qrafjqHjXFHlSEfzihbrcyPGVJIlB == -2 && iBMgKBXhSOAzgivzrCxHZOBUJiLab == Environment.CurrentManagedThreadId)
						{
							qrafjqHjXFHlSEfzihbrcyPGVJIlB = 0;
							iGqUhkSIxRElHPiUkYIOkNgZpxKQ2 = this;
						}
						else
						{
							iGqUhkSIxRElHPiUkYIOkNgZpxKQ2 = new iGqUhkSIxRElHPiUkYIOkNgZpxKQ(0);
							iGqUhkSIxRElHPiUkYIOkNgZpxKQ2.JotauEGXGudSglyjpAtVayYlPKdzA = JotauEGXGudSglyjpAtVayYlPKdzA;
						}
						return iGqUhkSIxRElHPiUkYIOkNgZpxKQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class XJwYSoRcKSrKcfYNRMmbwuitkwHg : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int dvXGjUUnsOdzUUvAyLbEFKHSWEbm;

					private ControllerPollingInfo MAiklLFehRdAjoGAaNjIqcGgGvggA;

					private int BkNPUMIvtjuetICNyIGyfTBVeYyeA;

					public PollingHelper HHjqbpGgQVaxVoPlAdLfXObXhikJA;

					private IList<Joystick> hlHaFosBzyKmKBwsCmZYrkoWCsWj;

					private int kYzjjAWNXJnjAIXUYmNJUvptuxgj;

					private int JSRLJFrDOjnYBCVbNjEIsMzWhBYX;

					private IEnumerator<ControllerPollingInfo> gFrcpEfemxwfMdWPqQLdlEelDQEw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return MAiklLFehRdAjoGAaNjIqcGgGvggA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return MAiklLFehRdAjoGAaNjIqcGgGvggA;
						}
					}

					[DebuggerHidden]
					public XJwYSoRcKSrKcfYNRMmbwuitkwHg(int P_0)
					{
						dvXGjUUnsOdzUUvAyLbEFKHSWEbm = P_0;
						BkNPUMIvtjuetICNyIGyfTBVeYyeA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dvXGjUUnsOdzUUvAyLbEFKHSWEbm;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								bQMVVQIzRlieszTdnLgJveLddRCS();
							}
						}
						hlHaFosBzyKmKBwsCmZYrkoWCsWj = null;
						gFrcpEfemxwfMdWPqQLdlEelDQEw = null;
						dvXGjUUnsOdzUUvAyLbEFKHSWEbm = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = dvXGjUUnsOdzUUvAyLbEFKHSWEbm;
							PollingHelper hHjqbpGgQVaxVoPlAdLfXObXhikJA = HHjqbpGgQVaxVoPlAdLfXObXhikJA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dvXGjUUnsOdzUUvAyLbEFKHSWEbm = -3;
								goto IL_00c5;
							}
							dvXGjUUnsOdzUUvAyLbEFKHSWEbm = -1;
							hlHaFosBzyKmKBwsCmZYrkoWCsWj = hHjqbpGgQVaxVoPlAdLfXObXhikJA.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							kYzjjAWNXJnjAIXUYmNJUvptuxgj = hlHaFosBzyKmKBwsCmZYrkoWCsWj.Count;
							JSRLJFrDOjnYBCVbNjEIsMzWhBYX = 0;
							goto IL_00f1;
							IL_00c5:
							if (gFrcpEfemxwfMdWPqQLdlEelDQEw.MoveNext())
							{
								ControllerPollingInfo current = gFrcpEfemxwfMdWPqQLdlEelDQEw.Current;
								ControllerPollingInfo mAiklLFehRdAjoGAaNjIqcGgGvggA = new ControllerPollingInfo(current);
								mAiklLFehRdAjoGAaNjIqcGgGvggA.playerId = hHjqbpGgQVaxVoPlAdLfXObXhikJA.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								MAiklLFehRdAjoGAaNjIqcGgGvggA = mAiklLFehRdAjoGAaNjIqcGgGvggA;
								dvXGjUUnsOdzUUvAyLbEFKHSWEbm = 1;
								return true;
							}
							bQMVVQIzRlieszTdnLgJveLddRCS();
							gFrcpEfemxwfMdWPqQLdlEelDQEw = null;
							JSRLJFrDOjnYBCVbNjEIsMzWhBYX++;
							goto IL_00f1;
							IL_00f1:
							if (JSRLJFrDOjnYBCVbNjEIsMzWhBYX < kYzjjAWNXJnjAIXUYmNJUvptuxgj)
							{
								gFrcpEfemxwfMdWPqQLdlEelDQEw = hlHaFosBzyKmKBwsCmZYrkoWCsWj[JSRLJFrDOjnYBCVbNjEIsMzWhBYX].PollForAllButtonsDown().GetEnumerator();
								dvXGjUUnsOdzUUvAyLbEFKHSWEbm = -3;
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

					private void bQMVVQIzRlieszTdnLgJveLddRCS()
					{
						dvXGjUUnsOdzUUvAyLbEFKHSWEbm = -1;
						if (gFrcpEfemxwfMdWPqQLdlEelDQEw != null)
						{
							gFrcpEfemxwfMdWPqQLdlEelDQEw.Dispose();
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
						XJwYSoRcKSrKcfYNRMmbwuitkwHg xJwYSoRcKSrKcfYNRMmbwuitkwHg;
						if (dvXGjUUnsOdzUUvAyLbEFKHSWEbm == -2 && BkNPUMIvtjuetICNyIGyfTBVeYyeA == Environment.CurrentManagedThreadId)
						{
							dvXGjUUnsOdzUUvAyLbEFKHSWEbm = 0;
							xJwYSoRcKSrKcfYNRMmbwuitkwHg = this;
						}
						else
						{
							xJwYSoRcKSrKcfYNRMmbwuitkwHg = new XJwYSoRcKSrKcfYNRMmbwuitkwHg(0);
							xJwYSoRcKSrKcfYNRMmbwuitkwHg.HHjqbpGgQVaxVoPlAdLfXObXhikJA = HHjqbpGgQVaxVoPlAdLfXObXhikJA;
						}
						return xJwYSoRcKSrKcfYNRMmbwuitkwHg;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xTftksldeBbHsDMMdJgpBXIYbtecA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ggDyaYgDLbTwlMkBYSjqKVdBbbwN;

					private ControllerPollingInfo zLQNNMSEnPWmpbbDLvzLozgSwDbP;

					private int yuBPiVLcdYDDHQImSfzfrOvQewir;

					public PollingHelper bKRwOkjLFgAtNkxkJdXQvGGCgUKp;

					private IList<Joystick> ghhhpKjpGWcrEBhQRhLjNVDmTeEA;

					private int IYgavYoWpvElUAcaPnOAFCWkWjXPB;

					private int JGFfvvFAzdKznWZTeNPecdAjoUIhA;

					private IEnumerator<ControllerPollingInfo> DfZhKWTQpLVhAGmvArvfbNmIFaMFA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zLQNNMSEnPWmpbbDLvzLozgSwDbP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zLQNNMSEnPWmpbbDLvzLozgSwDbP;
						}
					}

					[DebuggerHidden]
					public xTftksldeBbHsDMMdJgpBXIYbtecA(int P_0)
					{
						ggDyaYgDLbTwlMkBYSjqKVdBbbwN = P_0;
						yuBPiVLcdYDDHQImSfzfrOvQewir = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ggDyaYgDLbTwlMkBYSjqKVdBbbwN;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								qfpISXcyVoyMsQNVkfuFnnTVWnDKA();
							}
						}
						ghhhpKjpGWcrEBhQRhLjNVDmTeEA = null;
						DfZhKWTQpLVhAGmvArvfbNmIFaMFA = null;
						ggDyaYgDLbTwlMkBYSjqKVdBbbwN = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ggDyaYgDLbTwlMkBYSjqKVdBbbwN;
							PollingHelper pollingHelper = bKRwOkjLFgAtNkxkJdXQvGGCgUKp;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ggDyaYgDLbTwlMkBYSjqKVdBbbwN = -3;
								goto IL_00c5;
							}
							ggDyaYgDLbTwlMkBYSjqKVdBbbwN = -1;
							ghhhpKjpGWcrEBhQRhLjNVDmTeEA = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							IYgavYoWpvElUAcaPnOAFCWkWjXPB = ghhhpKjpGWcrEBhQRhLjNVDmTeEA.Count;
							JGFfvvFAzdKznWZTeNPecdAjoUIhA = 0;
							goto IL_00f1;
							IL_00c5:
							if (DfZhKWTQpLVhAGmvArvfbNmIFaMFA.MoveNext())
							{
								ControllerPollingInfo current = DfZhKWTQpLVhAGmvArvfbNmIFaMFA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								zLQNNMSEnPWmpbbDLvzLozgSwDbP = controllerPollingInfo;
								ggDyaYgDLbTwlMkBYSjqKVdBbbwN = 1;
								return true;
							}
							qfpISXcyVoyMsQNVkfuFnnTVWnDKA();
							DfZhKWTQpLVhAGmvArvfbNmIFaMFA = null;
							JGFfvvFAzdKznWZTeNPecdAjoUIhA++;
							goto IL_00f1;
							IL_00f1:
							if (JGFfvvFAzdKznWZTeNPecdAjoUIhA < IYgavYoWpvElUAcaPnOAFCWkWjXPB)
							{
								DfZhKWTQpLVhAGmvArvfbNmIFaMFA = ghhhpKjpGWcrEBhQRhLjNVDmTeEA[JGFfvvFAzdKznWZTeNPecdAjoUIhA].PollForAllElements().GetEnumerator();
								ggDyaYgDLbTwlMkBYSjqKVdBbbwN = -3;
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

					private void qfpISXcyVoyMsQNVkfuFnnTVWnDKA()
					{
						ggDyaYgDLbTwlMkBYSjqKVdBbbwN = -1;
						if (DfZhKWTQpLVhAGmvArvfbNmIFaMFA != null)
						{
							DfZhKWTQpLVhAGmvArvfbNmIFaMFA.Dispose();
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
						xTftksldeBbHsDMMdJgpBXIYbtecA xTftksldeBbHsDMMdJgpBXIYbtecA2;
						if (ggDyaYgDLbTwlMkBYSjqKVdBbbwN == -2 && yuBPiVLcdYDDHQImSfzfrOvQewir == Environment.CurrentManagedThreadId)
						{
							ggDyaYgDLbTwlMkBYSjqKVdBbbwN = 0;
							xTftksldeBbHsDMMdJgpBXIYbtecA2 = this;
						}
						else
						{
							xTftksldeBbHsDMMdJgpBXIYbtecA2 = new xTftksldeBbHsDMMdJgpBXIYbtecA(0);
							xTftksldeBbHsDMMdJgpBXIYbtecA2.bKRwOkjLFgAtNkxkJdXQvGGCgUKp = bKRwOkjLFgAtNkxkJdXQvGGCgUKp;
						}
						return xTftksldeBbHsDMMdJgpBXIYbtecA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZYVFjCGeBaBKtmpPGDQyWBLrjCmIb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int OAPAnTevgDsJQNCcODVaPyQcrbGE;

					private ControllerPollingInfo aQutiXbHKHRVovuASAeANwBUaUvb;

					private int hAkjaHjrqEFNYbguukpJdPsGIgeZA;

					public PollingHelper BbxgiHdoStnXXIKlByyDcDLxnNJCb;

					private IList<Joystick> HPsfLtRvsQevGElwDQzSlCKceiksA;

					private int gKvpDFWOvVRHUSeKIcsshbGCKlAM;

					private int bWAySDOcxtWoqrPEWlfeWBlKGqgy;

					private IEnumerator<ControllerPollingInfo> WHxKjUdpiKAFmIWtxbbjKzNrDdBFb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aQutiXbHKHRVovuASAeANwBUaUvb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aQutiXbHKHRVovuASAeANwBUaUvb;
						}
					}

					[DebuggerHidden]
					public ZYVFjCGeBaBKtmpPGDQyWBLrjCmIb(int P_0)
					{
						OAPAnTevgDsJQNCcODVaPyQcrbGE = P_0;
						hAkjaHjrqEFNYbguukpJdPsGIgeZA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int oAPAnTevgDsJQNCcODVaPyQcrbGE = OAPAnTevgDsJQNCcODVaPyQcrbGE;
						if (oAPAnTevgDsJQNCcODVaPyQcrbGE == -3 || oAPAnTevgDsJQNCcODVaPyQcrbGE == 1)
						{
							try
							{
							}
							finally
							{
								OmMKNoajdkDnFDbHOXrAvRBmyJzKA();
							}
						}
						HPsfLtRvsQevGElwDQzSlCKceiksA = null;
						WHxKjUdpiKAFmIWtxbbjKzNrDdBFb = null;
						OAPAnTevgDsJQNCcODVaPyQcrbGE = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int oAPAnTevgDsJQNCcODVaPyQcrbGE = OAPAnTevgDsJQNCcODVaPyQcrbGE;
							PollingHelper bbxgiHdoStnXXIKlByyDcDLxnNJCb = BbxgiHdoStnXXIKlByyDcDLxnNJCb;
							if (oAPAnTevgDsJQNCcODVaPyQcrbGE != 0)
							{
								if (oAPAnTevgDsJQNCcODVaPyQcrbGE != 1)
								{
									return false;
								}
								OAPAnTevgDsJQNCcODVaPyQcrbGE = -3;
								goto IL_00c5;
							}
							OAPAnTevgDsJQNCcODVaPyQcrbGE = -1;
							HPsfLtRvsQevGElwDQzSlCKceiksA = bbxgiHdoStnXXIKlByyDcDLxnNJCb.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
							gKvpDFWOvVRHUSeKIcsshbGCKlAM = HPsfLtRvsQevGElwDQzSlCKceiksA.Count;
							bWAySDOcxtWoqrPEWlfeWBlKGqgy = 0;
							goto IL_00f1;
							IL_00c5:
							if (WHxKjUdpiKAFmIWtxbbjKzNrDdBFb.MoveNext())
							{
								ControllerPollingInfo current = WHxKjUdpiKAFmIWtxbbjKzNrDdBFb.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = bbxgiHdoStnXXIKlByyDcDLxnNJCb.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								aQutiXbHKHRVovuASAeANwBUaUvb = controllerPollingInfo;
								OAPAnTevgDsJQNCcODVaPyQcrbGE = 1;
								return true;
							}
							OmMKNoajdkDnFDbHOXrAvRBmyJzKA();
							WHxKjUdpiKAFmIWtxbbjKzNrDdBFb = null;
							bWAySDOcxtWoqrPEWlfeWBlKGqgy++;
							goto IL_00f1;
							IL_00f1:
							if (bWAySDOcxtWoqrPEWlfeWBlKGqgy < gKvpDFWOvVRHUSeKIcsshbGCKlAM)
							{
								WHxKjUdpiKAFmIWtxbbjKzNrDdBFb = HPsfLtRvsQevGElwDQzSlCKceiksA[bWAySDOcxtWoqrPEWlfeWBlKGqgy].PollForAllElementsDown().GetEnumerator();
								OAPAnTevgDsJQNCcODVaPyQcrbGE = -3;
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

					private void OmMKNoajdkDnFDbHOXrAvRBmyJzKA()
					{
						OAPAnTevgDsJQNCcODVaPyQcrbGE = -1;
						if (WHxKjUdpiKAFmIWtxbbjKzNrDdBFb != null)
						{
							WHxKjUdpiKAFmIWtxbbjKzNrDdBFb.Dispose();
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
						ZYVFjCGeBaBKtmpPGDQyWBLrjCmIb zYVFjCGeBaBKtmpPGDQyWBLrjCmIb;
						if (OAPAnTevgDsJQNCcODVaPyQcrbGE == -2 && hAkjaHjrqEFNYbguukpJdPsGIgeZA == Environment.CurrentManagedThreadId)
						{
							OAPAnTevgDsJQNCcODVaPyQcrbGE = 0;
							zYVFjCGeBaBKtmpPGDQyWBLrjCmIb = this;
						}
						else
						{
							zYVFjCGeBaBKtmpPGDQyWBLrjCmIb = new ZYVFjCGeBaBKtmpPGDQyWBLrjCmIb(0);
							zYVFjCGeBaBKtmpPGDQyWBLrjCmIb.BbxgiHdoStnXXIKlByyDcDLxnNJCb = BbxgiHdoStnXXIKlByyDcDLxnNJCb;
						}
						return zYVFjCGeBaBKtmpPGDQyWBLrjCmIb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class eBTHlAizKUhAYQoxyqVbSxVXyqyC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int AfAddlLwALmCHYAtCEgKOBnBgiid;

					private ControllerPollingInfo vUAkNHVHIluqbDmckiWfHMkOViBO;

					private int jfrxeschWyTvcmGBDuJoKPlZyrif;

					private int IYoMMRXRyMuXUHkEHzhLahSFKELL;

					public int GASoFUmMOscYvUnqIIvEqbsgfTrp;

					public PollingHelper KWixhaaAQMHDtljlQrqXMbffJhix;

					private IEnumerator<ControllerPollingInfo> uUytcZnGgpClipissfGmkLSGJvODb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vUAkNHVHIluqbDmckiWfHMkOViBO;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vUAkNHVHIluqbDmckiWfHMkOViBO;
						}
					}

					[DebuggerHidden]
					public eBTHlAizKUhAYQoxyqVbSxVXyqyC(int P_0)
					{
						AfAddlLwALmCHYAtCEgKOBnBgiid = P_0;
						jfrxeschWyTvcmGBDuJoKPlZyrif = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int afAddlLwALmCHYAtCEgKOBnBgiid = AfAddlLwALmCHYAtCEgKOBnBgiid;
						if (afAddlLwALmCHYAtCEgKOBnBgiid == -3 || afAddlLwALmCHYAtCEgKOBnBgiid == 1)
						{
							try
							{
							}
							finally
							{
								AFObVgRBaCADybfuKvkPJZVJBkRE();
							}
						}
						uUytcZnGgpClipissfGmkLSGJvODb = null;
						AfAddlLwALmCHYAtCEgKOBnBgiid = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int afAddlLwALmCHYAtCEgKOBnBgiid = AfAddlLwALmCHYAtCEgKOBnBgiid;
							PollingHelper kWixhaaAQMHDtljlQrqXMbffJhix = KWixhaaAQMHDtljlQrqXMbffJhix;
							switch (afAddlLwALmCHYAtCEgKOBnBgiid)
							{
							default:
								return false;
							case 0:
							{
								AfAddlLwALmCHYAtCEgKOBnBgiid = -1;
								if (IYoMMRXRyMuXUHkEHzhLahSFKELL < 0)
								{
									return false;
								}
								CustomController customController = kWixhaaAQMHDtljlQrqXMbffJhix.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(IYoMMRXRyMuXUHkEHzhLahSFKELL);
								if (customController == null)
								{
									return false;
								}
								uUytcZnGgpClipissfGmkLSGJvODb = customController.PollForAllAxes().GetEnumerator();
								AfAddlLwALmCHYAtCEgKOBnBgiid = -3;
								break;
							}
							case 1:
								AfAddlLwALmCHYAtCEgKOBnBgiid = -3;
								break;
							}
							if (uUytcZnGgpClipissfGmkLSGJvODb.MoveNext())
							{
								ControllerPollingInfo current = uUytcZnGgpClipissfGmkLSGJvODb.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = kWixhaaAQMHDtljlQrqXMbffJhix.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								vUAkNHVHIluqbDmckiWfHMkOViBO = controllerPollingInfo;
								AfAddlLwALmCHYAtCEgKOBnBgiid = 1;
								return true;
							}
							AFObVgRBaCADybfuKvkPJZVJBkRE();
							uUytcZnGgpClipissfGmkLSGJvODb = null;
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

					private void AFObVgRBaCADybfuKvkPJZVJBkRE()
					{
						AfAddlLwALmCHYAtCEgKOBnBgiid = -1;
						if (uUytcZnGgpClipissfGmkLSGJvODb != null)
						{
							uUytcZnGgpClipissfGmkLSGJvODb.Dispose();
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
						eBTHlAizKUhAYQoxyqVbSxVXyqyC eBTHlAizKUhAYQoxyqVbSxVXyqyC2;
						if (AfAddlLwALmCHYAtCEgKOBnBgiid == -2 && jfrxeschWyTvcmGBDuJoKPlZyrif == Environment.CurrentManagedThreadId)
						{
							AfAddlLwALmCHYAtCEgKOBnBgiid = 0;
							eBTHlAizKUhAYQoxyqVbSxVXyqyC2 = this;
						}
						else
						{
							eBTHlAizKUhAYQoxyqVbSxVXyqyC2 = new eBTHlAizKUhAYQoxyqVbSxVXyqyC(0);
							eBTHlAizKUhAYQoxyqVbSxVXyqyC2.KWixhaaAQMHDtljlQrqXMbffJhix = KWixhaaAQMHDtljlQrqXMbffJhix;
						}
						eBTHlAizKUhAYQoxyqVbSxVXyqyC2.IYoMMRXRyMuXUHkEHzhLahSFKELL = GASoFUmMOscYvUnqIIvEqbsgfTrp;
						return eBTHlAizKUhAYQoxyqVbSxVXyqyC2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class CiNNoRhPcllJyWZqRHjSaAUEbZafA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YZBdWGLlqWFapneHtZRnueNjCSuc;

					private ControllerPollingInfo hCveGkaacoKeKYFWzRXAfqEEFGcbb;

					private int BnwuiEgJPEfQPsuViTPZJhIhAJrdA;

					private int ulDLczdQLHWqLnXQrtbiqIMiqcoX;

					public int aMitocucvnbkXyTaKDhcKLLpBFbvA;

					public PollingHelper safhKnqDGyeKaFsvuVMdoNVtTBDDA;

					private IEnumerator<ControllerPollingInfo> cyJbjDnxuEqnbEnjlYrTsIzSyrSI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hCveGkaacoKeKYFWzRXAfqEEFGcbb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hCveGkaacoKeKYFWzRXAfqEEFGcbb;
						}
					}

					[DebuggerHidden]
					public CiNNoRhPcllJyWZqRHjSaAUEbZafA(int P_0)
					{
						YZBdWGLlqWFapneHtZRnueNjCSuc = P_0;
						BnwuiEgJPEfQPsuViTPZJhIhAJrdA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int yZBdWGLlqWFapneHtZRnueNjCSuc = YZBdWGLlqWFapneHtZRnueNjCSuc;
						if (yZBdWGLlqWFapneHtZRnueNjCSuc == -3 || yZBdWGLlqWFapneHtZRnueNjCSuc == 1)
						{
							try
							{
							}
							finally
							{
								TDaXDeuwLeDrFtsjLRtrozsDbdBs();
							}
						}
						cyJbjDnxuEqnbEnjlYrTsIzSyrSI = null;
						YZBdWGLlqWFapneHtZRnueNjCSuc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int yZBdWGLlqWFapneHtZRnueNjCSuc = YZBdWGLlqWFapneHtZRnueNjCSuc;
							PollingHelper pollingHelper = safhKnqDGyeKaFsvuVMdoNVtTBDDA;
							switch (yZBdWGLlqWFapneHtZRnueNjCSuc)
							{
							default:
								return false;
							case 0:
							{
								YZBdWGLlqWFapneHtZRnueNjCSuc = -1;
								if (ulDLczdQLHWqLnXQrtbiqIMiqcoX < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(ulDLczdQLHWqLnXQrtbiqIMiqcoX);
								if (customController == null)
								{
									return false;
								}
								cyJbjDnxuEqnbEnjlYrTsIzSyrSI = customController.PollForAllButtons().GetEnumerator();
								YZBdWGLlqWFapneHtZRnueNjCSuc = -3;
								break;
							}
							case 1:
								YZBdWGLlqWFapneHtZRnueNjCSuc = -3;
								break;
							}
							if (cyJbjDnxuEqnbEnjlYrTsIzSyrSI.MoveNext())
							{
								ControllerPollingInfo current = cyJbjDnxuEqnbEnjlYrTsIzSyrSI.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								hCveGkaacoKeKYFWzRXAfqEEFGcbb = controllerPollingInfo;
								YZBdWGLlqWFapneHtZRnueNjCSuc = 1;
								return true;
							}
							TDaXDeuwLeDrFtsjLRtrozsDbdBs();
							cyJbjDnxuEqnbEnjlYrTsIzSyrSI = null;
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

					private void TDaXDeuwLeDrFtsjLRtrozsDbdBs()
					{
						YZBdWGLlqWFapneHtZRnueNjCSuc = -1;
						if (cyJbjDnxuEqnbEnjlYrTsIzSyrSI != null)
						{
							cyJbjDnxuEqnbEnjlYrTsIzSyrSI.Dispose();
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
						CiNNoRhPcllJyWZqRHjSaAUEbZafA ciNNoRhPcllJyWZqRHjSaAUEbZafA;
						if (YZBdWGLlqWFapneHtZRnueNjCSuc == -2 && BnwuiEgJPEfQPsuViTPZJhIhAJrdA == Environment.CurrentManagedThreadId)
						{
							YZBdWGLlqWFapneHtZRnueNjCSuc = 0;
							ciNNoRhPcllJyWZqRHjSaAUEbZafA = this;
						}
						else
						{
							ciNNoRhPcllJyWZqRHjSaAUEbZafA = new CiNNoRhPcllJyWZqRHjSaAUEbZafA(0);
							ciNNoRhPcllJyWZqRHjSaAUEbZafA.safhKnqDGyeKaFsvuVMdoNVtTBDDA = safhKnqDGyeKaFsvuVMdoNVtTBDDA;
						}
						ciNNoRhPcllJyWZqRHjSaAUEbZafA.ulDLczdQLHWqLnXQrtbiqIMiqcoX = aMitocucvnbkXyTaKDhcKLLpBFbvA;
						return ciNNoRhPcllJyWZqRHjSaAUEbZafA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class pVmCMpAsJcEfimBqmFvywewJcLsC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int FUubZFMmHarHXoFYlBQJGZYHxltPA;

					private ControllerPollingInfo ZnQUELipjNoJWQoltfPGVBEozjfT;

					private int rLSIshwlwKnbTyVSckfuQPSfLHrf;

					private int oUcbIkdWWoaCUhKuCwBvzRGpIwzWb;

					public int fCZRhemNQZySWKESAOHDWBITcUbY;

					public PollingHelper teEXmxKvsdadJrDZwSTtfxtyMNip;

					private IEnumerator<ControllerPollingInfo> ERcwiDvQWubzFBYYpOSsOhpXUNkeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZnQUELipjNoJWQoltfPGVBEozjfT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZnQUELipjNoJWQoltfPGVBEozjfT;
						}
					}

					[DebuggerHidden]
					public pVmCMpAsJcEfimBqmFvywewJcLsC(int P_0)
					{
						FUubZFMmHarHXoFYlBQJGZYHxltPA = P_0;
						rLSIshwlwKnbTyVSckfuQPSfLHrf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int fUubZFMmHarHXoFYlBQJGZYHxltPA = FUubZFMmHarHXoFYlBQJGZYHxltPA;
						if (fUubZFMmHarHXoFYlBQJGZYHxltPA == -3 || fUubZFMmHarHXoFYlBQJGZYHxltPA == 1)
						{
							try
							{
							}
							finally
							{
								gSWDtYvCTgpxPMhjjDJJlclthSNbA();
							}
						}
						ERcwiDvQWubzFBYYpOSsOhpXUNkeA = null;
						FUubZFMmHarHXoFYlBQJGZYHxltPA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int fUubZFMmHarHXoFYlBQJGZYHxltPA = FUubZFMmHarHXoFYlBQJGZYHxltPA;
							PollingHelper pollingHelper = teEXmxKvsdadJrDZwSTtfxtyMNip;
							switch (fUubZFMmHarHXoFYlBQJGZYHxltPA)
							{
							default:
								return false;
							case 0:
							{
								FUubZFMmHarHXoFYlBQJGZYHxltPA = -1;
								if (oUcbIkdWWoaCUhKuCwBvzRGpIwzWb < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(oUcbIkdWWoaCUhKuCwBvzRGpIwzWb);
								if (customController == null)
								{
									return false;
								}
								ERcwiDvQWubzFBYYpOSsOhpXUNkeA = customController.PollForAllButtonsDown().GetEnumerator();
								FUubZFMmHarHXoFYlBQJGZYHxltPA = -3;
								break;
							}
							case 1:
								FUubZFMmHarHXoFYlBQJGZYHxltPA = -3;
								break;
							}
							if (ERcwiDvQWubzFBYYpOSsOhpXUNkeA.MoveNext())
							{
								ControllerPollingInfo current = ERcwiDvQWubzFBYYpOSsOhpXUNkeA.Current;
								ControllerPollingInfo znQUELipjNoJWQoltfPGVBEozjfT = new ControllerPollingInfo(current);
								znQUELipjNoJWQoltfPGVBEozjfT.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								ZnQUELipjNoJWQoltfPGVBEozjfT = znQUELipjNoJWQoltfPGVBEozjfT;
								FUubZFMmHarHXoFYlBQJGZYHxltPA = 1;
								return true;
							}
							gSWDtYvCTgpxPMhjjDJJlclthSNbA();
							ERcwiDvQWubzFBYYpOSsOhpXUNkeA = null;
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

					private void gSWDtYvCTgpxPMhjjDJJlclthSNbA()
					{
						FUubZFMmHarHXoFYlBQJGZYHxltPA = -1;
						if (ERcwiDvQWubzFBYYpOSsOhpXUNkeA != null)
						{
							ERcwiDvQWubzFBYYpOSsOhpXUNkeA.Dispose();
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
						pVmCMpAsJcEfimBqmFvywewJcLsC pVmCMpAsJcEfimBqmFvywewJcLsC2;
						if (FUubZFMmHarHXoFYlBQJGZYHxltPA == -2 && rLSIshwlwKnbTyVSckfuQPSfLHrf == Environment.CurrentManagedThreadId)
						{
							FUubZFMmHarHXoFYlBQJGZYHxltPA = 0;
							pVmCMpAsJcEfimBqmFvywewJcLsC2 = this;
						}
						else
						{
							pVmCMpAsJcEfimBqmFvywewJcLsC2 = new pVmCMpAsJcEfimBqmFvywewJcLsC(0);
							pVmCMpAsJcEfimBqmFvywewJcLsC2.teEXmxKvsdadJrDZwSTtfxtyMNip = teEXmxKvsdadJrDZwSTtfxtyMNip;
						}
						pVmCMpAsJcEfimBqmFvywewJcLsC2.oUcbIkdWWoaCUhKuCwBvzRGpIwzWb = fCZRhemNQZySWKESAOHDWBITcUbY;
						return pVmCMpAsJcEfimBqmFvywewJcLsC2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xgbKxUuMvCgAxqgaEnAkLwFUUMMM : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int KqvQYFxoWdaEvOzFvPnRytmVRSEk;

					private ControllerPollingInfo mLIpGXdlpFvXYlScqoWqSKWfigfM;

					private int QgcbeRORVpsTyFikUEHadfStjyKMA;

					private int LZPZFPHAddmTDuhZgKkGPmWodNbj;

					public int VhGVvVnWJaKbQTxQoUHscTMMCpFQ;

					public PollingHelper bEZGCZgdQmZFKnjFfHZfZUZJvAjuA;

					private IEnumerator<ControllerPollingInfo> YwMxwxINMbQuFpLkcCHKospdNVHA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return mLIpGXdlpFvXYlScqoWqSKWfigfM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return mLIpGXdlpFvXYlScqoWqSKWfigfM;
						}
					}

					[DebuggerHidden]
					public xgbKxUuMvCgAxqgaEnAkLwFUUMMM(int P_0)
					{
						KqvQYFxoWdaEvOzFvPnRytmVRSEk = P_0;
						QgcbeRORVpsTyFikUEHadfStjyKMA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int kqvQYFxoWdaEvOzFvPnRytmVRSEk = KqvQYFxoWdaEvOzFvPnRytmVRSEk;
						if (kqvQYFxoWdaEvOzFvPnRytmVRSEk == -3 || kqvQYFxoWdaEvOzFvPnRytmVRSEk == 1)
						{
							try
							{
							}
							finally
							{
								XgjGtSglBLGfFJbdrOyFLiRbWJpb();
							}
						}
						YwMxwxINMbQuFpLkcCHKospdNVHA = null;
						KqvQYFxoWdaEvOzFvPnRytmVRSEk = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int kqvQYFxoWdaEvOzFvPnRytmVRSEk = KqvQYFxoWdaEvOzFvPnRytmVRSEk;
							PollingHelper pollingHelper = bEZGCZgdQmZFKnjFfHZfZUZJvAjuA;
							switch (kqvQYFxoWdaEvOzFvPnRytmVRSEk)
							{
							default:
								return false;
							case 0:
							{
								KqvQYFxoWdaEvOzFvPnRytmVRSEk = -1;
								if (LZPZFPHAddmTDuhZgKkGPmWodNbj < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(LZPZFPHAddmTDuhZgKkGPmWodNbj);
								if (customController == null)
								{
									return false;
								}
								YwMxwxINMbQuFpLkcCHKospdNVHA = customController.PollForAllElements().GetEnumerator();
								KqvQYFxoWdaEvOzFvPnRytmVRSEk = -3;
								break;
							}
							case 1:
								KqvQYFxoWdaEvOzFvPnRytmVRSEk = -3;
								break;
							}
							if (YwMxwxINMbQuFpLkcCHKospdNVHA.MoveNext())
							{
								ControllerPollingInfo current = YwMxwxINMbQuFpLkcCHKospdNVHA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								mLIpGXdlpFvXYlScqoWqSKWfigfM = controllerPollingInfo;
								KqvQYFxoWdaEvOzFvPnRytmVRSEk = 1;
								return true;
							}
							XgjGtSglBLGfFJbdrOyFLiRbWJpb();
							YwMxwxINMbQuFpLkcCHKospdNVHA = null;
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

					private void XgjGtSglBLGfFJbdrOyFLiRbWJpb()
					{
						KqvQYFxoWdaEvOzFvPnRytmVRSEk = -1;
						if (YwMxwxINMbQuFpLkcCHKospdNVHA != null)
						{
							YwMxwxINMbQuFpLkcCHKospdNVHA.Dispose();
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
						xgbKxUuMvCgAxqgaEnAkLwFUUMMM xgbKxUuMvCgAxqgaEnAkLwFUUMMM2;
						if (KqvQYFxoWdaEvOzFvPnRytmVRSEk == -2 && QgcbeRORVpsTyFikUEHadfStjyKMA == Environment.CurrentManagedThreadId)
						{
							KqvQYFxoWdaEvOzFvPnRytmVRSEk = 0;
							xgbKxUuMvCgAxqgaEnAkLwFUUMMM2 = this;
						}
						else
						{
							xgbKxUuMvCgAxqgaEnAkLwFUUMMM2 = new xgbKxUuMvCgAxqgaEnAkLwFUUMMM(0);
							xgbKxUuMvCgAxqgaEnAkLwFUUMMM2.bEZGCZgdQmZFKnjFfHZfZUZJvAjuA = bEZGCZgdQmZFKnjFfHZfZUZJvAjuA;
						}
						xgbKxUuMvCgAxqgaEnAkLwFUUMMM2.LZPZFPHAddmTDuhZgKkGPmWodNbj = VhGVvVnWJaKbQTxQoUHscTMMCpFQ;
						return xgbKxUuMvCgAxqgaEnAkLwFUUMMM2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ykgjbSIgDfwvFxIWmkGJtpMBJyvh : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sqPJVqCPCsRxTGWZxahVLgoOrCKg;

					private ControllerPollingInfo DAYqXXDvyeDDzeShGrhHNGHSVCso;

					private int LpvAbniwEfZpprcgnGGGMhftEDnp;

					private int IrnmceFxAaWEGoplezsTJQUANnor;

					public int iRydkMLtRrIcFDXhobtEvSTckXUJ;

					public PollingHelper luDvXqUFgEKyakEvFuQpXDhnwxSL;

					private IEnumerator<ControllerPollingInfo> BkdqPyyNpZROObAWUoDajnZeASakA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DAYqXXDvyeDDzeShGrhHNGHSVCso;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DAYqXXDvyeDDzeShGrhHNGHSVCso;
						}
					}

					[DebuggerHidden]
					public ykgjbSIgDfwvFxIWmkGJtpMBJyvh(int P_0)
					{
						sqPJVqCPCsRxTGWZxahVLgoOrCKg = P_0;
						LpvAbniwEfZpprcgnGGGMhftEDnp = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sqPJVqCPCsRxTGWZxahVLgoOrCKg;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								zFHPqvEEoCtHgwCEYORpfpUDtDOh();
							}
						}
						BkdqPyyNpZROObAWUoDajnZeASakA = null;
						sqPJVqCPCsRxTGWZxahVLgoOrCKg = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = sqPJVqCPCsRxTGWZxahVLgoOrCKg;
							PollingHelper pollingHelper = luDvXqUFgEKyakEvFuQpXDhnwxSL;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								sqPJVqCPCsRxTGWZxahVLgoOrCKg = -1;
								if (IrnmceFxAaWEGoplezsTJQUANnor < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(IrnmceFxAaWEGoplezsTJQUANnor);
								if (customController == null)
								{
									return false;
								}
								BkdqPyyNpZROObAWUoDajnZeASakA = customController.PollForAllElementsDown().GetEnumerator();
								sqPJVqCPCsRxTGWZxahVLgoOrCKg = -3;
								break;
							}
							case 1:
								sqPJVqCPCsRxTGWZxahVLgoOrCKg = -3;
								break;
							}
							if (BkdqPyyNpZROObAWUoDajnZeASakA.MoveNext())
							{
								ControllerPollingInfo current = BkdqPyyNpZROObAWUoDajnZeASakA.Current;
								ControllerPollingInfo dAYqXXDvyeDDzeShGrhHNGHSVCso = new ControllerPollingInfo(current);
								dAYqXXDvyeDDzeShGrhHNGHSVCso.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								DAYqXXDvyeDDzeShGrhHNGHSVCso = dAYqXXDvyeDDzeShGrhHNGHSVCso;
								sqPJVqCPCsRxTGWZxahVLgoOrCKg = 1;
								return true;
							}
							zFHPqvEEoCtHgwCEYORpfpUDtDOh();
							BkdqPyyNpZROObAWUoDajnZeASakA = null;
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

					private void zFHPqvEEoCtHgwCEYORpfpUDtDOh()
					{
						sqPJVqCPCsRxTGWZxahVLgoOrCKg = -1;
						if (BkdqPyyNpZROObAWUoDajnZeASakA != null)
						{
							BkdqPyyNpZROObAWUoDajnZeASakA.Dispose();
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
						ykgjbSIgDfwvFxIWmkGJtpMBJyvh ykgjbSIgDfwvFxIWmkGJtpMBJyvh2;
						if (sqPJVqCPCsRxTGWZxahVLgoOrCKg == -2 && LpvAbniwEfZpprcgnGGGMhftEDnp == Environment.CurrentManagedThreadId)
						{
							sqPJVqCPCsRxTGWZxahVLgoOrCKg = 0;
							ykgjbSIgDfwvFxIWmkGJtpMBJyvh2 = this;
						}
						else
						{
							ykgjbSIgDfwvFxIWmkGJtpMBJyvh2 = new ykgjbSIgDfwvFxIWmkGJtpMBJyvh(0);
							ykgjbSIgDfwvFxIWmkGJtpMBJyvh2.luDvXqUFgEKyakEvFuQpXDhnwxSL = luDvXqUFgEKyakEvFuQpXDhnwxSL;
						}
						ykgjbSIgDfwvFxIWmkGJtpMBJyvh2.IrnmceFxAaWEGoplezsTJQUANnor = iRydkMLtRrIcFDXhobtEvSTckXUJ;
						return ykgjbSIgDfwvFxIWmkGJtpMBJyvh2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class YQPbRYlAKhMlGBFptQUNDtgOsUUH : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GrxbFadYGranufQGDTDSqHfhbAKrE;

					private ControllerPollingInfo UcinaxanAeFKleijIOInhpceNifFB;

					private int BpKrnFepVsumrIKFsMzJyrfKtzFS;

					private int dVUPiKDqEMjIKIuzRMvmdGKPMDJB;

					public int iplBocFqxOXVIBfKBuzDUSxrQtHd;

					public PollingHelper dsSCPCljXassUyNHrpMIvipUGnhN;

					private IEnumerator<ControllerPollingInfo> PJbBQOFCnWpjLFNdAWsuJxRoeOK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return UcinaxanAeFKleijIOInhpceNifFB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return UcinaxanAeFKleijIOInhpceNifFB;
						}
					}

					[DebuggerHidden]
					public YQPbRYlAKhMlGBFptQUNDtgOsUUH(int P_0)
					{
						GrxbFadYGranufQGDTDSqHfhbAKrE = P_0;
						BpKrnFepVsumrIKFsMzJyrfKtzFS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int grxbFadYGranufQGDTDSqHfhbAKrE = GrxbFadYGranufQGDTDSqHfhbAKrE;
						if (grxbFadYGranufQGDTDSqHfhbAKrE == -3 || grxbFadYGranufQGDTDSqHfhbAKrE == 1)
						{
							try
							{
							}
							finally
							{
								aQxCnNqUHfjEzLErUKJSIlAfqRJw();
							}
						}
						PJbBQOFCnWpjLFNdAWsuJxRoeOK = null;
						GrxbFadYGranufQGDTDSqHfhbAKrE = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int grxbFadYGranufQGDTDSqHfhbAKrE = GrxbFadYGranufQGDTDSqHfhbAKrE;
							PollingHelper pollingHelper = dsSCPCljXassUyNHrpMIvipUGnhN;
							switch (grxbFadYGranufQGDTDSqHfhbAKrE)
							{
							default:
								return false;
							case 0:
							{
								GrxbFadYGranufQGDTDSqHfhbAKrE = -1;
								if (dVUPiKDqEMjIKIuzRMvmdGKPMDJB < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(dVUPiKDqEMjIKIuzRMvmdGKPMDJB);
								if (joystick == null)
								{
									return false;
								}
								PJbBQOFCnWpjLFNdAWsuJxRoeOK = joystick.PollForAllAxes().GetEnumerator();
								GrxbFadYGranufQGDTDSqHfhbAKrE = -3;
								break;
							}
							case 1:
								GrxbFadYGranufQGDTDSqHfhbAKrE = -3;
								break;
							}
							if (PJbBQOFCnWpjLFNdAWsuJxRoeOK.MoveNext())
							{
								ControllerPollingInfo current = PJbBQOFCnWpjLFNdAWsuJxRoeOK.Current;
								ControllerPollingInfo ucinaxanAeFKleijIOInhpceNifFB = new ControllerPollingInfo(current);
								ucinaxanAeFKleijIOInhpceNifFB.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								UcinaxanAeFKleijIOInhpceNifFB = ucinaxanAeFKleijIOInhpceNifFB;
								GrxbFadYGranufQGDTDSqHfhbAKrE = 1;
								return true;
							}
							aQxCnNqUHfjEzLErUKJSIlAfqRJw();
							PJbBQOFCnWpjLFNdAWsuJxRoeOK = null;
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

					private void aQxCnNqUHfjEzLErUKJSIlAfqRJw()
					{
						GrxbFadYGranufQGDTDSqHfhbAKrE = -1;
						if (PJbBQOFCnWpjLFNdAWsuJxRoeOK != null)
						{
							PJbBQOFCnWpjLFNdAWsuJxRoeOK.Dispose();
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
						YQPbRYlAKhMlGBFptQUNDtgOsUUH yQPbRYlAKhMlGBFptQUNDtgOsUUH;
						if (GrxbFadYGranufQGDTDSqHfhbAKrE == -2 && BpKrnFepVsumrIKFsMzJyrfKtzFS == Environment.CurrentManagedThreadId)
						{
							GrxbFadYGranufQGDTDSqHfhbAKrE = 0;
							yQPbRYlAKhMlGBFptQUNDtgOsUUH = this;
						}
						else
						{
							yQPbRYlAKhMlGBFptQUNDtgOsUUH = new YQPbRYlAKhMlGBFptQUNDtgOsUUH(0);
							yQPbRYlAKhMlGBFptQUNDtgOsUUH.dsSCPCljXassUyNHrpMIvipUGnhN = dsSCPCljXassUyNHrpMIvipUGnhN;
						}
						yQPbRYlAKhMlGBFptQUNDtgOsUUH.dVUPiKDqEMjIKIuzRMvmdGKPMDJB = iplBocFqxOXVIBfKBuzDUSxrQtHd;
						return yQPbRYlAKhMlGBFptQUNDtgOsUUH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FOJWfQBKRafDHeCYgJpPnapFuwXw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int SaMFJFqqxGgSKlhmmKfmqumQAHTt;

					private ControllerPollingInfo LfGKkLMVNpLzqOEqVPEqTwDhlLXw;

					private int JUjjKosGTIfIyalwNTRdmPhZeUMeA;

					private int wgBRdiwOcJHjYMNfcLTpxmaEwJJT;

					public int mIJBsuhYEYkAzFoEFAGeibbjnoCr;

					public PollingHelper GhvIROxycQGgJLhnAhuzcUZsTyod;

					private IEnumerator<ControllerPollingInfo> PZConJyRtQMMgzrfiVWyoNdRJKBD;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LfGKkLMVNpLzqOEqVPEqTwDhlLXw;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LfGKkLMVNpLzqOEqVPEqTwDhlLXw;
						}
					}

					[DebuggerHidden]
					public FOJWfQBKRafDHeCYgJpPnapFuwXw(int P_0)
					{
						SaMFJFqqxGgSKlhmmKfmqumQAHTt = P_0;
						JUjjKosGTIfIyalwNTRdmPhZeUMeA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int saMFJFqqxGgSKlhmmKfmqumQAHTt = SaMFJFqqxGgSKlhmmKfmqumQAHTt;
						if (saMFJFqqxGgSKlhmmKfmqumQAHTt == -3 || saMFJFqqxGgSKlhmmKfmqumQAHTt == 1)
						{
							try
							{
							}
							finally
							{
								ZTwsOGzHgUKApNHckiemdjBkCJtd();
							}
						}
						PZConJyRtQMMgzrfiVWyoNdRJKBD = null;
						SaMFJFqqxGgSKlhmmKfmqumQAHTt = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int saMFJFqqxGgSKlhmmKfmqumQAHTt = SaMFJFqqxGgSKlhmmKfmqumQAHTt;
							PollingHelper ghvIROxycQGgJLhnAhuzcUZsTyod = GhvIROxycQGgJLhnAhuzcUZsTyod;
							switch (saMFJFqqxGgSKlhmmKfmqumQAHTt)
							{
							default:
								return false;
							case 0:
							{
								SaMFJFqqxGgSKlhmmKfmqumQAHTt = -1;
								if (wgBRdiwOcJHjYMNfcLTpxmaEwJJT < 0)
								{
									return false;
								}
								Joystick joystick = ghvIROxycQGgJLhnAhuzcUZsTyod.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(wgBRdiwOcJHjYMNfcLTpxmaEwJJT);
								if (joystick == null)
								{
									return false;
								}
								PZConJyRtQMMgzrfiVWyoNdRJKBD = joystick.PollForAllButtons().GetEnumerator();
								SaMFJFqqxGgSKlhmmKfmqumQAHTt = -3;
								break;
							}
							case 1:
								SaMFJFqqxGgSKlhmmKfmqumQAHTt = -3;
								break;
							}
							if (PZConJyRtQMMgzrfiVWyoNdRJKBD.MoveNext())
							{
								ControllerPollingInfo current = PZConJyRtQMMgzrfiVWyoNdRJKBD.Current;
								ControllerPollingInfo lfGKkLMVNpLzqOEqVPEqTwDhlLXw = new ControllerPollingInfo(current);
								lfGKkLMVNpLzqOEqVPEqTwDhlLXw.playerId = ghvIROxycQGgJLhnAhuzcUZsTyod.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								LfGKkLMVNpLzqOEqVPEqTwDhlLXw = lfGKkLMVNpLzqOEqVPEqTwDhlLXw;
								SaMFJFqqxGgSKlhmmKfmqumQAHTt = 1;
								return true;
							}
							ZTwsOGzHgUKApNHckiemdjBkCJtd();
							PZConJyRtQMMgzrfiVWyoNdRJKBD = null;
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

					private void ZTwsOGzHgUKApNHckiemdjBkCJtd()
					{
						SaMFJFqqxGgSKlhmmKfmqumQAHTt = -1;
						if (PZConJyRtQMMgzrfiVWyoNdRJKBD != null)
						{
							PZConJyRtQMMgzrfiVWyoNdRJKBD.Dispose();
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
						FOJWfQBKRafDHeCYgJpPnapFuwXw fOJWfQBKRafDHeCYgJpPnapFuwXw;
						if (SaMFJFqqxGgSKlhmmKfmqumQAHTt == -2 && JUjjKosGTIfIyalwNTRdmPhZeUMeA == Environment.CurrentManagedThreadId)
						{
							SaMFJFqqxGgSKlhmmKfmqumQAHTt = 0;
							fOJWfQBKRafDHeCYgJpPnapFuwXw = this;
						}
						else
						{
							fOJWfQBKRafDHeCYgJpPnapFuwXw = new FOJWfQBKRafDHeCYgJpPnapFuwXw(0);
							fOJWfQBKRafDHeCYgJpPnapFuwXw.GhvIROxycQGgJLhnAhuzcUZsTyod = GhvIROxycQGgJLhnAhuzcUZsTyod;
						}
						fOJWfQBKRafDHeCYgJpPnapFuwXw.wgBRdiwOcJHjYMNfcLTpxmaEwJJT = mIJBsuhYEYkAzFoEFAGeibbjnoCr;
						return fOJWfQBKRafDHeCYgJpPnapFuwXw;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class woGgpXbhCudCQzwmkiFpQmcyxSAS : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pjiQAFYbhVCUNYhidABGKzWXFEmlA;

					private ControllerPollingInfo LnMWTRuldcjPwdhunuCGDAQyimwIA;

					private int kSlfVieivNEbGZIyzCxuFOXAmzoxb;

					private int aTahRpDLbkiqcnEXCmVBemxBxXerA;

					public int KvTWVzEHyodRPfTwHJQmUkJYSIpA;

					public PollingHelper ExYCtdKUAMLOtuhTpJSPYJywyOgIA;

					private IEnumerator<ControllerPollingInfo> QCdjaDywSXPgKPZdYmpbawLlMzHu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LnMWTRuldcjPwdhunuCGDAQyimwIA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LnMWTRuldcjPwdhunuCGDAQyimwIA;
						}
					}

					[DebuggerHidden]
					public woGgpXbhCudCQzwmkiFpQmcyxSAS(int P_0)
					{
						pjiQAFYbhVCUNYhidABGKzWXFEmlA = P_0;
						kSlfVieivNEbGZIyzCxuFOXAmzoxb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pjiQAFYbhVCUNYhidABGKzWXFEmlA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								HQoAXzEUkuOoJQGrjmDskfciszKAb();
							}
						}
						QCdjaDywSXPgKPZdYmpbawLlMzHu = null;
						pjiQAFYbhVCUNYhidABGKzWXFEmlA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pjiQAFYbhVCUNYhidABGKzWXFEmlA;
							PollingHelper exYCtdKUAMLOtuhTpJSPYJywyOgIA = ExYCtdKUAMLOtuhTpJSPYJywyOgIA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								pjiQAFYbhVCUNYhidABGKzWXFEmlA = -1;
								if (aTahRpDLbkiqcnEXCmVBemxBxXerA < 0)
								{
									return false;
								}
								Joystick joystick = exYCtdKUAMLOtuhTpJSPYJywyOgIA.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(aTahRpDLbkiqcnEXCmVBemxBxXerA);
								if (joystick == null)
								{
									return false;
								}
								QCdjaDywSXPgKPZdYmpbawLlMzHu = joystick.PollForAllButtonsDown().GetEnumerator();
								pjiQAFYbhVCUNYhidABGKzWXFEmlA = -3;
								break;
							}
							case 1:
								pjiQAFYbhVCUNYhidABGKzWXFEmlA = -3;
								break;
							}
							if (QCdjaDywSXPgKPZdYmpbawLlMzHu.MoveNext())
							{
								ControllerPollingInfo current = QCdjaDywSXPgKPZdYmpbawLlMzHu.Current;
								ControllerPollingInfo lnMWTRuldcjPwdhunuCGDAQyimwIA = new ControllerPollingInfo(current);
								lnMWTRuldcjPwdhunuCGDAQyimwIA.playerId = exYCtdKUAMLOtuhTpJSPYJywyOgIA.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								LnMWTRuldcjPwdhunuCGDAQyimwIA = lnMWTRuldcjPwdhunuCGDAQyimwIA;
								pjiQAFYbhVCUNYhidABGKzWXFEmlA = 1;
								return true;
							}
							HQoAXzEUkuOoJQGrjmDskfciszKAb();
							QCdjaDywSXPgKPZdYmpbawLlMzHu = null;
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

					private void HQoAXzEUkuOoJQGrjmDskfciszKAb()
					{
						pjiQAFYbhVCUNYhidABGKzWXFEmlA = -1;
						if (QCdjaDywSXPgKPZdYmpbawLlMzHu != null)
						{
							QCdjaDywSXPgKPZdYmpbawLlMzHu.Dispose();
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
						woGgpXbhCudCQzwmkiFpQmcyxSAS woGgpXbhCudCQzwmkiFpQmcyxSAS2;
						if (pjiQAFYbhVCUNYhidABGKzWXFEmlA == -2 && kSlfVieivNEbGZIyzCxuFOXAmzoxb == Environment.CurrentManagedThreadId)
						{
							pjiQAFYbhVCUNYhidABGKzWXFEmlA = 0;
							woGgpXbhCudCQzwmkiFpQmcyxSAS2 = this;
						}
						else
						{
							woGgpXbhCudCQzwmkiFpQmcyxSAS2 = new woGgpXbhCudCQzwmkiFpQmcyxSAS(0);
							woGgpXbhCudCQzwmkiFpQmcyxSAS2.ExYCtdKUAMLOtuhTpJSPYJywyOgIA = ExYCtdKUAMLOtuhTpJSPYJywyOgIA;
						}
						woGgpXbhCudCQzwmkiFpQmcyxSAS2.aTahRpDLbkiqcnEXCmVBemxBxXerA = KvTWVzEHyodRPfTwHJQmUkJYSIpA;
						return woGgpXbhCudCQzwmkiFpQmcyxSAS2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class GavnulkcdUCPGcQUodOmsvjDtrdhA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int puIhPtSkNmfNmhzuVIvierJGBpCeA;

					private ControllerPollingInfo hEqjfkNulwiMHXPnKhAlvnjqLzkq;

					private int DpQzmjgUznCyxgPQUJpwcHpSfDay;

					private int KrtcebOBrLIbHHKrgBkyICGrTrIl;

					public int UabfPqELFJuFIEIOMbmGDtaQLKheA;

					public PollingHelper hTGdvheckwXAsSSdOZimOIWPkXDdb;

					private IEnumerator<ControllerPollingInfo> dPmmuEwTRoPpTjBWVdwChGxrqYABb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hEqjfkNulwiMHXPnKhAlvnjqLzkq;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hEqjfkNulwiMHXPnKhAlvnjqLzkq;
						}
					}

					[DebuggerHidden]
					public GavnulkcdUCPGcQUodOmsvjDtrdhA(int P_0)
					{
						puIhPtSkNmfNmhzuVIvierJGBpCeA = P_0;
						DpQzmjgUznCyxgPQUJpwcHpSfDay = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = puIhPtSkNmfNmhzuVIvierJGBpCeA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								gGNgunzXPOkpDhzXmkklGCsaMOTG();
							}
						}
						dPmmuEwTRoPpTjBWVdwChGxrqYABb = null;
						puIhPtSkNmfNmhzuVIvierJGBpCeA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = puIhPtSkNmfNmhzuVIvierJGBpCeA;
							PollingHelper pollingHelper = hTGdvheckwXAsSSdOZimOIWPkXDdb;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								puIhPtSkNmfNmhzuVIvierJGBpCeA = -1;
								if (KrtcebOBrLIbHHKrgBkyICGrTrIl < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(KrtcebOBrLIbHHKrgBkyICGrTrIl);
								if (joystick == null)
								{
									return false;
								}
								dPmmuEwTRoPpTjBWVdwChGxrqYABb = joystick.PollForAllElements().GetEnumerator();
								puIhPtSkNmfNmhzuVIvierJGBpCeA = -3;
								break;
							}
							case 1:
								puIhPtSkNmfNmhzuVIvierJGBpCeA = -3;
								break;
							}
							if (dPmmuEwTRoPpTjBWVdwChGxrqYABb.MoveNext())
							{
								ControllerPollingInfo current = dPmmuEwTRoPpTjBWVdwChGxrqYABb.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								hEqjfkNulwiMHXPnKhAlvnjqLzkq = controllerPollingInfo;
								puIhPtSkNmfNmhzuVIvierJGBpCeA = 1;
								return true;
							}
							gGNgunzXPOkpDhzXmkklGCsaMOTG();
							dPmmuEwTRoPpTjBWVdwChGxrqYABb = null;
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

					private void gGNgunzXPOkpDhzXmkklGCsaMOTG()
					{
						puIhPtSkNmfNmhzuVIvierJGBpCeA = -1;
						if (dPmmuEwTRoPpTjBWVdwChGxrqYABb != null)
						{
							dPmmuEwTRoPpTjBWVdwChGxrqYABb.Dispose();
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
						GavnulkcdUCPGcQUodOmsvjDtrdhA gavnulkcdUCPGcQUodOmsvjDtrdhA;
						if (puIhPtSkNmfNmhzuVIvierJGBpCeA == -2 && DpQzmjgUznCyxgPQUJpwcHpSfDay == Environment.CurrentManagedThreadId)
						{
							puIhPtSkNmfNmhzuVIvierJGBpCeA = 0;
							gavnulkcdUCPGcQUodOmsvjDtrdhA = this;
						}
						else
						{
							gavnulkcdUCPGcQUodOmsvjDtrdhA = new GavnulkcdUCPGcQUodOmsvjDtrdhA(0);
							gavnulkcdUCPGcQUodOmsvjDtrdhA.hTGdvheckwXAsSSdOZimOIWPkXDdb = hTGdvheckwXAsSSdOZimOIWPkXDdb;
						}
						gavnulkcdUCPGcQUodOmsvjDtrdhA.KrtcebOBrLIbHHKrgBkyICGrTrIl = UabfPqELFJuFIEIOMbmGDtaQLKheA;
						return gavnulkcdUCPGcQUodOmsvjDtrdhA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class NYlQneHHhIidFAVmmmZgDUIOrgBHb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int kuWYMfKTcwOxfYkBYWOrtvPiEDgK;

					private ControllerPollingInfo izhCoFVQlaOoeTjLojwIalAmcJDJ;

					private int afZtSzejjLOKCyazhbaqryfmLInf;

					private int ebsLLcVbvBHYcEfBiUlxWmCoDpaX;

					public int jcjXWCRcRdfFuPcfFUDZHAEhFkGDA;

					public PollingHelper BpPzCpcdpxgMzAyGwkSAAmNYoYtc;

					private IEnumerator<ControllerPollingInfo> wUWLEkqGhULPLzmClXpKtJhmcNyu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return izhCoFVQlaOoeTjLojwIalAmcJDJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return izhCoFVQlaOoeTjLojwIalAmcJDJ;
						}
					}

					[DebuggerHidden]
					public NYlQneHHhIidFAVmmmZgDUIOrgBHb(int P_0)
					{
						kuWYMfKTcwOxfYkBYWOrtvPiEDgK = P_0;
						afZtSzejjLOKCyazhbaqryfmLInf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = kuWYMfKTcwOxfYkBYWOrtvPiEDgK;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								HJElZFCgoeEMAYLkwqauriuinXcl();
							}
						}
						wUWLEkqGhULPLzmClXpKtJhmcNyu = null;
						kuWYMfKTcwOxfYkBYWOrtvPiEDgK = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = kuWYMfKTcwOxfYkBYWOrtvPiEDgK;
							PollingHelper bpPzCpcdpxgMzAyGwkSAAmNYoYtc = BpPzCpcdpxgMzAyGwkSAAmNYoYtc;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								kuWYMfKTcwOxfYkBYWOrtvPiEDgK = -1;
								if (ebsLLcVbvBHYcEfBiUlxWmCoDpaX < 0)
								{
									return false;
								}
								Joystick joystick = bpPzCpcdpxgMzAyGwkSAAmNYoYtc.ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(ebsLLcVbvBHYcEfBiUlxWmCoDpaX);
								if (joystick == null)
								{
									return false;
								}
								wUWLEkqGhULPLzmClXpKtJhmcNyu = joystick.PollForAllElementsDown().GetEnumerator();
								kuWYMfKTcwOxfYkBYWOrtvPiEDgK = -3;
								break;
							}
							case 1:
								kuWYMfKTcwOxfYkBYWOrtvPiEDgK = -3;
								break;
							}
							if (wUWLEkqGhULPLzmClXpKtJhmcNyu.MoveNext())
							{
								ControllerPollingInfo current = wUWLEkqGhULPLzmClXpKtJhmcNyu.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = bpPzCpcdpxgMzAyGwkSAAmNYoYtc.VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
								izhCoFVQlaOoeTjLojwIalAmcJDJ = controllerPollingInfo;
								kuWYMfKTcwOxfYkBYWOrtvPiEDgK = 1;
								return true;
							}
							HJElZFCgoeEMAYLkwqauriuinXcl();
							wUWLEkqGhULPLzmClXpKtJhmcNyu = null;
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

					private void HJElZFCgoeEMAYLkwqauriuinXcl()
					{
						kuWYMfKTcwOxfYkBYWOrtvPiEDgK = -1;
						if (wUWLEkqGhULPLzmClXpKtJhmcNyu != null)
						{
							wUWLEkqGhULPLzmClXpKtJhmcNyu.Dispose();
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
						NYlQneHHhIidFAVmmmZgDUIOrgBHb nYlQneHHhIidFAVmmmZgDUIOrgBHb;
						if (kuWYMfKTcwOxfYkBYWOrtvPiEDgK == -2 && afZtSzejjLOKCyazhbaqryfmLInf == Environment.CurrentManagedThreadId)
						{
							kuWYMfKTcwOxfYkBYWOrtvPiEDgK = 0;
							nYlQneHHhIidFAVmmmZgDUIOrgBHb = this;
						}
						else
						{
							nYlQneHHhIidFAVmmmZgDUIOrgBHb = new NYlQneHHhIidFAVmmmZgDUIOrgBHb(0);
							nYlQneHHhIidFAVmmmZgDUIOrgBHb.BpPzCpcdpxgMzAyGwkSAAmNYoYtc = BpPzCpcdpxgMzAyGwkSAAmNYoYtc;
						}
						nYlQneHHhIidFAVmmmZgDUIOrgBHb.ebsLLcVbvBHYcEfBiUlxWmCoDpaX = jcjXWCRcRdfFuPcfFUDZHAEhFkGDA;
						return nYlQneHHhIidFAVmmmZgDUIOrgBHb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player VqTJAfoFfgEMjDvxycPrzrbhcOic;

				private readonly ControllerHelper ZlmYCWkDrnLdbVEwhuLQrYwzliIi;

				private readonly int ApaEUFWHgUgEEIjOEJWPmlfooYyZA;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					ApaEUFWHgUgEEIjOEJWPmlfooYyZA = ReInput.id;
					VqTJAfoFfgEMjDvxycPrzrbhcOic = P_0;
					ZlmYCWkDrnLdbVEwhuLQrYwzliIi = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => LwjPdRnztiLvWWeCkMtddgUpnUBO(), 
						ControllerType.Joystick => hlMHgHIhsyBXkkJDYBXGHythANyN(controllerId), 
						ControllerType.Mouse => pPdXFGIMftkjeogyQGGUduYZqERjA(), 
						ControllerType.Custom => JkHAnZMieUgVyalZPqiJpMeDkDReA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tvtVnurryKGarvtlNlDSYVeoEwLF(), 
						ControllerType.Joystick => xVvskueQErKPufsQgPqSFHevhVGd(controllerId), 
						ControllerType.Mouse => MiostmUKTMnlBYqrQBBTIEINnVWab(), 
						ControllerType.Custom => ZHIreWYvGuItNvFnrPnMJQPvmEbO(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => LwjPdRnztiLvWWeCkMtddgUpnUBO(), 
						ControllerType.Joystick => txzaacgfoVlequFohoexrJLvthSlA(controllerId), 
						ControllerType.Mouse => KWwdGKSOblbFlqwiMeczmmHZboeIA(), 
						ControllerType.Custom => rCKjKGbNPfikxvbaQbaWjePJSAXF(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tvtVnurryKGarvtlNlDSYVeoEwLF(), 
						ControllerType.Joystick => tRZDkFFnJEoInZxxlrSvpDulaiqGA(controllerId), 
						ControllerType.Mouse => XgvUuBrDRmNUTYYGlmonmXvNZptg(), 
						ControllerType.Custom => qbXcUDiDpgtMuKUuJxRwzmGFhxDhA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA(), 
						ControllerType.Joystick => BzwBLSVhjWXbMyhKDdLpBCWPCvKtA(controllerId), 
						ControllerType.Mouse => RpzcIuFOyRQQsegosgImhQuCxgeHB(), 
						ControllerType.Custom => OMcCPOKGSEAQvCeRiNIJKrQJPOPA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ELVALMdCcBxjdkpZGUPlXUXbSMYq(), 
						ControllerType.Joystick => wwMRBLWRpzAJINScobONbVmekZls(controllerId), 
						ControllerType.Mouse => ZqrOpdWcbnTgpGYBrSUzbvGyJcx(), 
						ControllerType.Custom => LdHDjukTgVFjRBrTHbIyYBdUpGnEc(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => nYctSoOOHEanGjISwBBAerkztUqA(), 
						ControllerType.Joystick => QzALNyTfLbjMCClJpnMfbDaBVMgNB(controllerId), 
						ControllerType.Mouse => TuNoJlTmKGIaHURPYCdPFRxLUNSA(), 
						ControllerType.Custom => XDjHyiajCnZQMldfPJqMcqSAdQlWA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ELVALMdCcBxjdkpZGUPlXUXbSMYq(), 
						ControllerType.Joystick => FsNihQHuafAEQnnGBfidZiRxaTEm(controllerId), 
						ControllerType.Mouse => OLoRVZMiNDBJDqoaSUrmMDYFcIsp(), 
						ControllerType.Custom => IalJeolrIXILPkWbPztWkJBYRTPA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => nYctSoOOHEanGjISwBBAerkztUqA(), 
						ControllerType.Joystick => soluExhyheOpcZqSxwdcftSRtxAU(controllerId), 
						ControllerType.Mouse => pvOccHpzfOBCHdRRjFBTUlEJcXDe(), 
						ControllerType.Custom => TEBDJpGBBprCcoQLYGTQcxZuHyRdA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => QxnPURytjNUMknsOWtITtshKXyD(controllerId), 
						ControllerType.Mouse => uPAFWbcgzQExfEFveDkrsvivjVhV(), 
						ControllerType.Custom => hLHfkQBCSiLxcbUHLDVJDnWocmqlA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => LwjPdRnztiLvWWeCkMtddgUpnUBO(), 
						ControllerType.Joystick => hyiTybIUTisUiRGvGRnGQlgCgdVDA(), 
						ControllerType.Mouse => pPdXFGIMftkjeogyQGGUduYZqERjA(), 
						ControllerType.Custom => JGrldbHFoYdNXbpRuAlzSCBwYZGX(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => LwjPdRnztiLvWWeCkMtddgUpnUBO(), 
						ControllerType.Joystick => pXTQgrNvdbeWkEJOBfhvvZDeAJCs(), 
						ControllerType.Mouse => KWwdGKSOblbFlqwiMeczmmHZboeIA(), 
						ControllerType.Custom => ohzbKBKQbvGlNbDlHYVNYADIcUxY(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => tvtVnurryKGarvtlNlDSYVeoEwLF(), 
						ControllerType.Joystick => YTBqWdRsoperamYIfHQQvYDjKewS(), 
						ControllerType.Mouse => XgvUuBrDRmNUTYYGlmonmXvNZptg(), 
						ControllerType.Custom => VzVuVDhRlfrVgdblnEOnMeNNIIGL(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA(), 
						ControllerType.Joystick => MKHAploQKNPoAqEVDkVhEmSGubc(), 
						ControllerType.Mouse => RpzcIuFOyRQQsegosgImhQuCxgeHB(), 
						ControllerType.Custom => QTPtHuEFWEJtFDkiCKyVcSaTQDUm(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ELVALMdCcBxjdkpZGUPlXUXbSMYq(), 
						ControllerType.Joystick => THpASTegrvPcxhJPUXZoREZvfjAC(), 
						ControllerType.Mouse => ZqrOpdWcbnTgpGYBrSUzbvGyJcx(), 
						ControllerType.Custom => RPKaiCGkBoQaUtTchzkWuGJNIXUQ(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => nYctSoOOHEanGjISwBBAerkztUqA(), 
						ControllerType.Joystick => zFLDSwCpAuWkFQtJvtRZfoKMOYEq(), 
						ControllerType.Mouse => TuNoJlTmKGIaHURPYCdPFRxLUNSA(), 
						ControllerType.Custom => HarMPfngRNAjyFnzaHoRmeZGnEwRA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ELVALMdCcBxjdkpZGUPlXUXbSMYq(), 
						ControllerType.Joystick => RlYRHZDDtbtvRkRcjwSzTayraFyr(), 
						ControllerType.Mouse => OLoRVZMiNDBJDqoaSUrmMDYFcIsp(), 
						ControllerType.Custom => aGTscMCFcvNffCdbwGLFAEKzFrAj(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => nYctSoOOHEanGjISwBBAerkztUqA(), 
						ControllerType.Joystick => nPPfnfVubgGlwJdHQzhUpsBnSTyeA(), 
						ControllerType.Mouse => pvOccHpzfOBCHdRRjFBTUlEJcXDe(), 
						ControllerType.Custom => JWthmXcxRlQRbEpMEWJFrJnvCfWM(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != ApaEUFWHgUgEEIjOEJWPmlfooYyZA)
					{
						ReInput.CheckInitialized(ApaEUFWHgUgEEIjOEJWPmlfooYyZA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => oNgWnTkJaSpSxTtHmSvFnuKjyUUA(), 
						ControllerType.Mouse => uPAFWbcgzQExfEFveDkrsvivjVhV(), 
						ControllerType.Custom => BqKcdTTpvNnXJgLvObXhWREdmGQT(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo hlMHgHIhsyBXkkJDYBXGHythANyN(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					Joystick joystick = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo xVvskueQErKPufsQgPqSFHevhVGd(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					Joystick joystick = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo txzaacgfoVlequFohoexrJLvthSlA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					Joystick joystick = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo tRZDkFFnJEoInZxxlrSvpDulaiqGA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					Joystick joystick = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo BzwBLSVhjWXbMyhKDdLpBCWPCvKtA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					Joystick joystick = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				[IteratorStateMachine(typeof(GavnulkcdUCPGcQUodOmsvjDtrdhA))]
				private IEnumerable<ControllerPollingInfo> wwMRBLWRpzAJINScobONbVmekZls(int P_0)
				{
					return new GavnulkcdUCPGcQUodOmsvjDtrdhA(-2)
					{
						hTGdvheckwXAsSSdOZimOIWPkXDdb = this,
						UabfPqELFJuFIEIOMbmGDtaQLKheA = P_0
					};
				}

				[IteratorStateMachine(typeof(NYlQneHHhIidFAVmmmZgDUIOrgBHb))]
				private IEnumerable<ControllerPollingInfo> QzALNyTfLbjMCClJpnMfbDaBVMgNB(int P_0)
				{
					return new NYlQneHHhIidFAVmmmZgDUIOrgBHb(-2)
					{
						BpPzCpcdpxgMzAyGwkSAAmNYoYtc = this,
						jcjXWCRcRdfFuPcfFUDZHAEhFkGDA = P_0
					};
				}

				[IteratorStateMachine(typeof(FOJWfQBKRafDHeCYgJpPnapFuwXw))]
				private IEnumerable<ControllerPollingInfo> FsNihQHuafAEQnnGBfidZiRxaTEm(int P_0)
				{
					return new FOJWfQBKRafDHeCYgJpPnapFuwXw(-2)
					{
						GhvIROxycQGgJLhnAhuzcUZsTyod = this,
						mIJBsuhYEYkAzFoEFAGeibbjnoCr = P_0
					};
				}

				[IteratorStateMachine(typeof(woGgpXbhCudCQzwmkiFpQmcyxSAS))]
				private IEnumerable<ControllerPollingInfo> soluExhyheOpcZqSxwdcftSRtxAU(int P_0)
				{
					return new woGgpXbhCudCQzwmkiFpQmcyxSAS(-2)
					{
						ExYCtdKUAMLOtuhTpJSPYJywyOgIA = this,
						KvTWVzEHyodRPfTwHJQmUkJYSIpA = P_0
					};
				}

				[IteratorStateMachine(typeof(YQPbRYlAKhMlGBFptQUNDtgOsUUH))]
				private IEnumerable<ControllerPollingInfo> QxnPURytjNUMknsOWtITtshKXyD(int P_0)
				{
					return new YQPbRYlAKhMlGBFptQUNDtgOsUUH(-2)
					{
						dsSCPCljXassUyNHrpMIvipUGnhN = this,
						iplBocFqxOXVIBfKBuzDUSxrQtHd = P_0
					};
				}

				private ControllerPollingInfo hyiTybIUTisUiRGvGRnGQlgCgdVDA()
				{
					IList<Joystick> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo AusLSgShyumKUMxwBqGXIekvpezt()
				{
					IList<Joystick> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo pXTQgrNvdbeWkEJOBfhvvZDeAJCs()
				{
					IList<Joystick> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo YTBqWdRsoperamYIfHQQvYDjKewS()
				{
					IList<Joystick> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo MKHAploQKNPoAqEVDkVhEmSGubc()
				{
					IList<Joystick> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UFGhwsaNrpaMrxiFMNXUJcJPEpsBb.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				[IteratorStateMachine(typeof(xTftksldeBbHsDMMdJgpBXIYbtecA))]
				private IEnumerable<ControllerPollingInfo> THpASTegrvPcxhJPUXZoREZvfjAC()
				{
					return new xTftksldeBbHsDMMdJgpBXIYbtecA(-2)
					{
						bKRwOkjLFgAtNkxkJdXQvGGCgUKp = this
					};
				}

				[IteratorStateMachine(typeof(ZYVFjCGeBaBKtmpPGDQyWBLrjCmIb))]
				private IEnumerable<ControllerPollingInfo> zFLDSwCpAuWkFQtJvtRZfoKMOYEq()
				{
					return new ZYVFjCGeBaBKtmpPGDQyWBLrjCmIb(-2)
					{
						BbxgiHdoStnXXIKlByyDcDLxnNJCb = this
					};
				}

				[IteratorStateMachine(typeof(iGqUhkSIxRElHPiUkYIOkNgZpxKQ))]
				private IEnumerable<ControllerPollingInfo> RlYRHZDDtbtvRkRcjwSzTayraFyr()
				{
					return new iGqUhkSIxRElHPiUkYIOkNgZpxKQ(-2)
					{
						JotauEGXGudSglyjpAtVayYlPKdzA = this
					};
				}

				[IteratorStateMachine(typeof(XJwYSoRcKSrKcfYNRMmbwuitkwHg))]
				private IEnumerable<ControllerPollingInfo> nPPfnfVubgGlwJdHQzhUpsBnSTyeA()
				{
					return new XJwYSoRcKSrKcfYNRMmbwuitkwHg(-2)
					{
						HHjqbpGgQVaxVoPlAdLfXObXhikJA = this
					};
				}

				[IteratorStateMachine(typeof(AKwXKcypbkTzaPwTeaeaqBXOuvnc))]
				private IEnumerable<ControllerPollingInfo> oNgWnTkJaSpSxTtHmSvFnuKjyUUA()
				{
					return new AKwXKcypbkTzaPwTeaeaqBXOuvnc(-2)
					{
						bOBChMfCZhRKOwVbydfIcTKpOeMl = this
					};
				}

				private ControllerPollingInfo LwjPdRnztiLvWWeCkMtddgUpnUBO()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.ejAcZFbhagbRvuNefCVJGXCXAmObb)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo tvtVnurryKGarvtlNlDSYVeoEwLF()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.ejAcZFbhagbRvuNefCVJGXCXAmObb)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> ELVALMdCcBxjdkpZGUPlXUXbSMYq()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.ejAcZFbhagbRvuNefCVJGXCXAmObb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> nYctSoOOHEanGjISwBBAerkztUqA()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.ejAcZFbhagbRvuNefCVJGXCXAmObb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo pPdXFGIMftkjeogyQGGUduYZqERjA()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo MiostmUKTMnlBYqrQBBTIEINnVWab()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo KWwdGKSOblbFlqwiMeczmmHZboeIA()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo XgvUuBrDRmNUTYYGlmonmXvNZptg()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo RpzcIuFOyRQQsegosgImhQuCxgeHB()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> ZqrOpdWcbnTgpGYBrSUzbvGyJcx()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> TuNoJlTmKGIaHURPYCdPFRxLUNSA()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> OLoRVZMiNDBJDqoaSUrmMDYFcIsp()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> pvOccHpzfOBCHdRRjFBTUlEJcXDe()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> uPAFWbcgzQExfEFveDkrsvivjVhV()
				{
					if (!ZlmYCWkDrnLdbVEwhuLQrYwzliIi.UAxtacLohAYptSzTVDHGWKcWNHOq)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ZlmYCWkDrnLdbVEwhuLQrYwzliIi.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo JkHAnZMieUgVyalZPqiJpMeDkDReA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					CustomController customController = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo ZHIreWYvGuItNvFnrPnMJQPvmEbO(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					CustomController customController = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo rCKjKGbNPfikxvbaQbaWjePJSAXF(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					CustomController customController = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo qbXcUDiDpgtMuKUuJxRwzmGFhxDhA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					CustomController customController = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				private ControllerPollingInfo OMcCPOKGSEAQvCeRiNIJKrQJPOPA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					CustomController customController = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.xDIVdsRoUWOYzrpExtspKIKqOwIe(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
					}
					return result;
				}

				[IteratorStateMachine(typeof(xgbKxUuMvCgAxqgaEnAkLwFUUMMM))]
				private IEnumerable<ControllerPollingInfo> LdHDjukTgVFjRBrTHbIyYBdUpGnEc(int P_0)
				{
					return new xgbKxUuMvCgAxqgaEnAkLwFUUMMM(-2)
					{
						bEZGCZgdQmZFKnjFfHZfZUZJvAjuA = this,
						VhGVvVnWJaKbQTxQoUHscTMMCpFQ = P_0
					};
				}

				[IteratorStateMachine(typeof(ykgjbSIgDfwvFxIWmkGJtpMBJyvh))]
				private IEnumerable<ControllerPollingInfo> XDjHyiajCnZQMldfPJqMcqSAdQlWA(int P_0)
				{
					return new ykgjbSIgDfwvFxIWmkGJtpMBJyvh(-2)
					{
						luDvXqUFgEKyakEvFuQpXDhnwxSL = this,
						iRydkMLtRrIcFDXhobtEvSTckXUJ = P_0
					};
				}

				[IteratorStateMachine(typeof(CiNNoRhPcllJyWZqRHjSaAUEbZafA))]
				private IEnumerable<ControllerPollingInfo> IalJeolrIXILPkWbPztWkJBYRTPA(int P_0)
				{
					return new CiNNoRhPcllJyWZqRHjSaAUEbZafA(-2)
					{
						safhKnqDGyeKaFsvuVMdoNVtTBDDA = this,
						aMitocucvnbkXyTaKDhcKLLpBFbvA = P_0
					};
				}

				[IteratorStateMachine(typeof(pVmCMpAsJcEfimBqmFvywewJcLsC))]
				private IEnumerable<ControllerPollingInfo> TEBDJpGBBprCcoQLYGTQcxZuHyRdA(int P_0)
				{
					return new pVmCMpAsJcEfimBqmFvywewJcLsC(-2)
					{
						teEXmxKvsdadJrDZwSTtfxtyMNip = this,
						fCZRhemNQZySWKESAOHDWBITcUbY = P_0
					};
				}

				[IteratorStateMachine(typeof(eBTHlAizKUhAYQoxyqVbSxVXyqyC))]
				private IEnumerable<ControllerPollingInfo> hLHfkQBCSiLxcbUHLDVJDnWocmqlA(int P_0)
				{
					return new eBTHlAizKUhAYQoxyqVbSxVXyqyC(-2)
					{
						KWixhaaAQMHDtljlQrqXMbffJhix = this,
						GASoFUmMOscYvUnqIIvEqbsgfTrp = P_0
					};
				}

				private ControllerPollingInfo JGrldbHFoYdNXbpRuAlzSCBwYZGX()
				{
					IList<CustomController> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo fpCqGFpLWllZvovwBfJBDmJrOxAt()
				{
					IList<CustomController> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo ohzbKBKQbvGlNbDlHYVNYADIcUxY()
				{
					IList<CustomController> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo VzVuVDhRlfrVgdblnEOnMeNNIIGL()
				{
					IList<CustomController> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo QTPtHuEFWEJtFDkiCKyVcSaTQDUm()
				{
					IList<CustomController> list = ZlmYCWkDrnLdbVEwhuLQrYwzliIi.lUxGdkbYWtSnFlYjpNoPFLnfztjK.UZcAPMUGUwfkiXcIAXBceGyLvShu;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = VqTJAfoFfgEMjDvxycPrzrbhcOic.hNoRiloMAZCwMJhqxCSNjcRIpGck;
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				[IteratorStateMachine(typeof(PhMUNHpTgpvhCvTrAyzKqEvtvotI))]
				private IEnumerable<ControllerPollingInfo> RPKaiCGkBoQaUtTchzkWuGJNIXUQ()
				{
					return new PhMUNHpTgpvhCvTrAyzKqEvtvotI(-2)
					{
						pNUZBCcKpeTDzYUElhFSXIJzAvwi = this
					};
				}

				[IteratorStateMachine(typeof(EgmjaBUhPdCSfNccSZIqRTYnmqSU))]
				private IEnumerable<ControllerPollingInfo> HarMPfngRNAjyFnzaHoRmeZGnEwRA()
				{
					return new EgmjaBUhPdCSfNccSZIqRTYnmqSU(-2)
					{
						zIdgyehepicDnATTaYCSpeKFHnwL = this
					};
				}

				[IteratorStateMachine(typeof(boCxPROblnZTaIphqGwfOsVCTxHd))]
				private IEnumerable<ControllerPollingInfo> aGTscMCFcvNffCdbwGLFAEKzFrAj()
				{
					return new boCxPROblnZTaIphqGwfOsVCTxHd(-2)
					{
						tThcghcxNhgEVATigWQmPzqxoHpy = this
					};
				}

				[IteratorStateMachine(typeof(steWnvfRBcmFLwJYbihRZmWHcxMiA))]
				private IEnumerable<ControllerPollingInfo> JWthmXcxRlQRbEpMEWJFrJnvCfWM()
				{
					return new steWnvfRBcmFLwJYbihRZmWHcxMiA(-2)
					{
						cOuBAWbxbaOmUvlyVIywVXQeAWjJ = this
					};
				}

				[IteratorStateMachine(typeof(LEtuEJZnHuMEdwAlSUhBDDTwsRvA))]
				private IEnumerable<ControllerPollingInfo> BqKcdTTpvNnXJgLvObXhWREdmGQT()
				{
					return new LEtuEJZnHuMEdwAlSUhBDDTwsRvA(-2)
					{
						fYSGoBVMrKzuODpXneUFvMHBAaYP = this
					};
				}
			}

			[Serializable]
			private sealed class zdwmVaaKUtdrGHqHgPtSEfRBiAXib
			{
				public static readonly zdwmVaaKUtdrGHqHgPtSEfRBiAXib _003C_003E9 = new zdwmVaaKUtdrGHqHgPtSEfRBiAXib();

				public static Action<Exception> _003C_003E9__26_0;

				public static Action<Exception> _003C_003E9__26_1;

				internal void LSimvyknHneZuVhfzygqmQZyCWzi(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void LwNIIbobOMCnfyhZjPPokTvUiOBV(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class rpNYaDbaTmxroDJyYaLMNjVLUvgJ : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
			{
				private int AkNchtYsijSAbTmPqDaaCZdeEMIcA;

				private Controller xBizjeApVdgZslumvdfVaIdUGGvrA;

				private int HTsEatpVOzIxQUoGICMAzRlqWNOV;

				public ControllerHelper jBcgNoHPMJUSCeeGWIoLbqRKrJbdB;

				private int skkaAjWiGcSAFnzmZXApBGKjrArD;

				private IList<Joystick> ozSpEhMWqKPrBEpSAcLfGBJIKcle;

				private int zRYsSXhhnvpxOaAZAaiEOmrFDiie;

				private IList<CustomController> FzOBARFJDDDVBbskwRzSsHWlDWNl;

				private int hWOpbZSfhYSTsLqkdEFjjhOFFeKs;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return xBizjeApVdgZslumvdfVaIdUGGvrA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xBizjeApVdgZslumvdfVaIdUGGvrA;
					}
				}

				[DebuggerHidden]
				public rpNYaDbaTmxroDJyYaLMNjVLUvgJ(int P_0)
				{
					AkNchtYsijSAbTmPqDaaCZdeEMIcA = P_0;
					HTsEatpVOzIxQUoGICMAzRlqWNOV = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ozSpEhMWqKPrBEpSAcLfGBJIKcle = null;
					FzOBARFJDDDVBbskwRzSsHWlDWNl = null;
					AkNchtYsijSAbTmPqDaaCZdeEMIcA = -2;
				}

				private bool MoveNext()
				{
					int akNchtYsijSAbTmPqDaaCZdeEMIcA = AkNchtYsijSAbTmPqDaaCZdeEMIcA;
					ControllerHelper controllerHelper = jBcgNoHPMJUSCeeGWIoLbqRKrJbdB;
					switch (akNchtYsijSAbTmPqDaaCZdeEMIcA)
					{
					default:
						return false;
					case 0:
						AkNchtYsijSAbTmPqDaaCZdeEMIcA = -1;
						if (ReInput._id != controllerHelper.FgGVJqaPpwFzrFLpERRfYcoowJJg)
						{
							ReInput.CheckInitialized(controllerHelper.FgGVJqaPpwFzrFLpERRfYcoowJJg);
							return false;
						}
						if (controllerHelper.UAxtacLohAYptSzTVDHGWKcWNHOq)
						{
							xBizjeApVdgZslumvdfVaIdUGGvrA = controllerHelper.Mouse;
							AkNchtYsijSAbTmPqDaaCZdeEMIcA = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						AkNchtYsijSAbTmPqDaaCZdeEMIcA = -1;
						goto IL_0070;
					case 2:
						AkNchtYsijSAbTmPqDaaCZdeEMIcA = -1;
						goto IL_0094;
					case 3:
						AkNchtYsijSAbTmPqDaaCZdeEMIcA = -1;
						hWOpbZSfhYSTsLqkdEFjjhOFFeKs++;
						goto IL_00ec;
					case 4:
						{
							AkNchtYsijSAbTmPqDaaCZdeEMIcA = -1;
							hWOpbZSfhYSTsLqkdEFjjhOFFeKs++;
							break;
						}
						IL_0094:
						skkaAjWiGcSAFnzmZXApBGKjrArD = controllerHelper.joystickCount;
						ozSpEhMWqKPrBEpSAcLfGBJIKcle = controllerHelper.Joysticks;
						hWOpbZSfhYSTsLqkdEFjjhOFFeKs = 0;
						goto IL_00ec;
						IL_00ec:
						if (hWOpbZSfhYSTsLqkdEFjjhOFFeKs < skkaAjWiGcSAFnzmZXApBGKjrArD)
						{
							xBizjeApVdgZslumvdfVaIdUGGvrA = ozSpEhMWqKPrBEpSAcLfGBJIKcle[hWOpbZSfhYSTsLqkdEFjjhOFFeKs];
							AkNchtYsijSAbTmPqDaaCZdeEMIcA = 3;
							return true;
						}
						zRYsSXhhnvpxOaAZAaiEOmrFDiie = controllerHelper.customControllerCount;
						FzOBARFJDDDVBbskwRzSsHWlDWNl = controllerHelper.CustomControllers;
						hWOpbZSfhYSTsLqkdEFjjhOFFeKs = 0;
						break;
						IL_0070:
						if (controllerHelper.ejAcZFbhagbRvuNefCVJGXCXAmObb)
						{
							xBizjeApVdgZslumvdfVaIdUGGvrA = controllerHelper.Keyboard;
							AkNchtYsijSAbTmPqDaaCZdeEMIcA = 2;
							return true;
						}
						goto IL_0094;
					}
					if (hWOpbZSfhYSTsLqkdEFjjhOFFeKs < zRYsSXhhnvpxOaAZAaiEOmrFDiie)
					{
						xBizjeApVdgZslumvdfVaIdUGGvrA = FzOBARFJDDDVBbskwRzSsHWlDWNl[hWOpbZSfhYSTsLqkdEFjjhOFFeKs];
						AkNchtYsijSAbTmPqDaaCZdeEMIcA = 4;
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
					rpNYaDbaTmxroDJyYaLMNjVLUvgJ rpNYaDbaTmxroDJyYaLMNjVLUvgJ2;
					if (AkNchtYsijSAbTmPqDaaCZdeEMIcA == -2 && HTsEatpVOzIxQUoGICMAzRlqWNOV == Environment.CurrentManagedThreadId)
					{
						AkNchtYsijSAbTmPqDaaCZdeEMIcA = 0;
						rpNYaDbaTmxroDJyYaLMNjVLUvgJ2 = this;
					}
					else
					{
						rpNYaDbaTmxroDJyYaLMNjVLUvgJ2 = new rpNYaDbaTmxroDJyYaLMNjVLUvgJ(0);
						rpNYaDbaTmxroDJyYaLMNjVLUvgJ2.jBcgNoHPMJUSCeeGWIoLbqRKrJbdB = jBcgNoHPMJUSCeeGWIoLbqRKrJbdB;
					}
					return rpNYaDbaTmxroDJyYaLMNjVLUvgJ2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly yTppLmdkPEkruVlzDxplVYNljUCq tpLAStrOAbmqGMDjpNidjCONHxnfA;

			private bool UAxtacLohAYptSzTVDHGWKcWNHOq;

			private bool ejAcZFbhagbRvuNefCVJGXCXAmObb;

			private bool UJZGgyLyeTDCrOhpJnjwJeoJDPtg;

			private double zRCjqrbJkuFlUTAMlkevOrzNSRSe;

			private double rrNgbZAABMutEirMEGduuIWWiFChb;

			private double kbIPdyHwGAleDRhkVBFiGhQhQoymA;

			private ControllerType NLSciAEGtrGhrxuSvVdxfzeuSNdZ;

			private int JNfKGkyINqVVlsbbVMjssFIAHKWV = -1;

			private SafeAction<ControllerAssignmentChangedEventArgs> wPORUgEhqYCPGhZZMKLQVNgdkjQiA = new SafeAction<ControllerAssignmentChangedEventArgs>(zdwmVaaKUtdrGHqHgPtSEfRBiAXib._003C_003E9.LSimvyknHneZuVhfzygqmQZyCWzi);

			private SafeAction<ControllerAssignmentChangedEventArgs> CcGxqqcIsbNtGYzcTzFKDBddIlEU = new SafeAction<ControllerAssignmentChangedEventArgs>(zdwmVaaKUtdrGHqHgPtSEfRBiAXib._003C_003E9.LwNIIbobOMCnfyhZjPPokTvUiOBV);

			private readonly hMEdODXgCmwsxlgvcleZEdSDNowO WeTlLgtnEcedzdjbKVXuxepDCgfF;

			private readonly Player UolvMVFsCEWDrjcoHINZAHaIEhxLA;

			private readonly WbtTwlDPwwjUlDmYIZawuYHsCcBA zNfpPFMhkvbbaOWVXQFeSIdWtofJ;

			private readonly int FgGVJqaPpwFzrFLpERRfYcoowJJg;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap> UFGhwsaNrpaMrxiFMNXUJcJPEpsBb => (kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick);

			private global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<KeyboardMap> XDZJdplUohcdZWoKLNyfdyKeLgTP => (global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<KeyboardMap>)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Keyboard).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(0).ZVqQCpBpHaJoxANGetaJnsjmlMojA;

			private global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<MouseMap> kYzyDbbcurDfceHgiahBYEaZTqFA => (global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<MouseMap>)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Mouse).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(0).ZVqQCpBpHaJoxANGetaJnsjmlMojA;

			private kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap> lUxGdkbYWtSnFlYjpNoPFLnfztjK => (kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return false;
					}
					return UAxtacLohAYptSzTVDHGWKcWNHOq;
				}
				set
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						if (UAxtacLohAYptSzTVDHGWKcWNHOq == value)
						{
							return;
						}
						UAxtacLohAYptSzTVDHGWKcWNHOq = value;
						if (value)
						{
							zNfpPFMhkvbbaOWVXQFeSIdWtofJ.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(Mouse);
						}
						else
						{
							zNfpPFMhkvbbaOWVXQFeSIdWtofJ.XwKsqBusctndNwTHULgAVhQaVOrh(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Count > 0)
							{
								wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (CcGxqqcIsbNtGYzcTzFKDBddIlEU.Count > 0)
						{
							CcGxqqcIsbNtGYzcTzFKDBddIlEU.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return false;
					}
					return ejAcZFbhagbRvuNefCVJGXCXAmObb;
				}
				set
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						if (ejAcZFbhagbRvuNefCVJGXCXAmObb == value)
						{
							return;
						}
						ejAcZFbhagbRvuNefCVJGXCXAmObb = value;
						if (value)
						{
							zNfpPFMhkvbbaOWVXQFeSIdWtofJ.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(Keyboard);
						}
						else
						{
							zNfpPFMhkvbbaOWVXQFeSIdWtofJ.XwKsqBusctndNwTHULgAVhQaVOrh(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Count > 0)
							{
								wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (CcGxqqcIsbNtGYzcTzFKDBddIlEU.Count > 0)
						{
							CcGxqqcIsbNtGYzcTzFKDBddIlEU.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return false;
					}
					return UJZGgyLyeTDCrOhpJnjwJeoJDPtg;
				}
				set
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						UJZGgyLyeTDCrOhpJnjwJeoJDPtg = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return 0;
					}
					return tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick).yqhlCDSAeeNknWUrdPHIJVxJgUrb;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick) as kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>).UZcAPMUGUwfkiXcIAXBceGyLvShu;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return 0;
					}
					return tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom).yqhlCDSAeeNknWUrdPHIJVxJgUrb;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom) as kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>).UZcAPMUGUwfkiXcIAXBceGyLvShu;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				[IteratorStateMachine(typeof(rpNYaDbaTmxroDJyYaLMNjVLUvgJ))]
				get
				{
					return new rpNYaDbaTmxroDJyYaLMNjVLUvgJ(-2)
					{
						jBcgNoHPMJUSCeeGWIoLbqRKrJbdB = this
					};
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					wPORUgEhqYCPGhZZMKLQVNgdkjQiA.AddDelegate(value);
				}
				remove
				{
					wPORUgEhqYCPGhZZMKLQVNgdkjQiA.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					CcGxqqcIsbNtGYzcTzFKDBddIlEU.AddDelegate(value);
				}
				remove
				{
					CcGxqqcIsbNtGYzcTzFKDBddIlEU.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, ReblhCinFkWhDVFLEbjmzIdfVvaS P_1, ControllerMapLayoutManager.VRUPdzKgeveqVvQabkIaYFoBcpSf P_2, ControllerMapEnabler.LoufCxnWRPkzSbBIKyhZshokUpWL P_3)
			{
				FgGVJqaPpwFzrFLpERRfYcoowJJg = ReInput.id;
				UolvMVFsCEWDrjcoHINZAHaIEhxLA = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				tpLAStrOAbmqGMDjpNidjCONHxnfA = new yTppLmdkPEkruVlzDxplVYNljUCq(4);
				tpLAStrOAbmqGMDjpNidjCONHxnfA.BohQSFQnBIthgDfCAITBiTnLbPSAA(0, ControllerType.Joystick, new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>());
				tpLAStrOAbmqGMDjpNidjCONHxnfA.BohQSFQnBIthgDfCAITBiTnLbPSAA(1, ControllerType.Keyboard, new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Keyboard, KeyboardMap>());
				tpLAStrOAbmqGMDjpNidjCONHxnfA.BohQSFQnBIthgDfCAITBiTnLbPSAA(2, ControllerType.Mouse, new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Mouse, MouseMap>());
				tpLAStrOAbmqGMDjpNidjCONHxnfA.BohQSFQnBIthgDfCAITBiTnLbPSAA(3, ControllerType.Custom, new kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>());
				WeTlLgtnEcedzdjbKVXuxepDCgfF = new hMEdODXgCmwsxlgvcleZEdSDNowO(P_0);
				zNfpPFMhkvbbaOWVXQFeSIdWtofJ = new WbtTwlDPwwjUlDmYIZawuYHsCcBA(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				return (T)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(bVcNkmaJvbHeBNQRpaleQvWHeXqv.zzvIXJkhxoPAdanZIgbgivDbxfvgA<T>()).yoMbXcrAnMFCsmsnfsFTRCTxgrNq(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				return tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType).yoMbXcrAnMFCsmsnfsFTRCTxgrNq(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				return (T)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(bVcNkmaJvbHeBNQRpaleQvWHeXqv.zzvIXJkhxoPAdanZIgbgivDbxfvgA<T>()).pQZeuXnOJNMraNudmbPNbnNdDWfi(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				return tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(controllerType).pQZeuXnOJNMraNudmbPNbnNdDWfi(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					CimaUiWtHnGIGOFLFXJWvscbRRkX(controllerId, removeFromOtherPlayers);
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
					rPFiTAJfzgEQSDAFzCNXeDzAscDY(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						kgFzKznruBeNzkDBKoxpkVkyQsiO(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						tUpQztgzMvrGeWQbWPjNmBYocgiw(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					kgFzKznruBeNzkDBKoxpkVkyQsiO(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
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
					tUpQztgzMvrGeWQbWPjNmBYocgiw(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					aHoecyjpwfZVlrepzckXCtgAFMzVB(controllerId);
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
					UvlWJHGszIPTQgsImcEtYWpMGMmF(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					aHoecyjpwfZVlrepzckXCtgAFMzVB(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					UvlWJHGszIPTQgsImcEtYWpMGMmF(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						DkOncnMnWrWxeEmylVVbowdiaRdA(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						xnNwTjwEZWCgoEZEDKFvKFCBQBgAb(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return ejAcZFbhagbRvuNefCVJGXCXAmObb;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return UAxtacLohAYptSzTVDHGWKcWNHOq;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick).TppoEOtwrQsjeHgBuhTqETedUKXv(controllerId), 
					ControllerType.Keyboard => ejAcZFbhagbRvuNefCVJGXCXAmObb, 
					ControllerType.Mouse => UAxtacLohAYptSzTVDHGWKcWNHOq, 
					ControllerType.Custom => tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom).TppoEOtwrQsjeHgBuhTqETedUKXv(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
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
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					GtyCEykctlKfysqBsOXiRHFmQbRY();
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
					neqvcyeJADcyhTOPMpERtFeZjBjfA();
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
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					GtyCEykctlKfysqBsOXiRHFmQbRY();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					neqvcyeJADcyhTOPMpERtFeZjBjfA();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return;
				}
				GtyCEykctlKfysqBsOXiRHFmQbRY();
				neqvcyeJADcyhTOPMpERtFeZjBjfA();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				qGrCOpcsBpSnsORfVQEpYDipwlGY(ControllerType.Joystick, ref result, ref num);
				if (UAxtacLohAYptSzTVDHGWKcWNHOq && zRCjqrbJkuFlUTAMlkevOrzNSRSe > num)
				{
					result = Mouse;
					num = zRCjqrbJkuFlUTAMlkevOrzNSRSe;
				}
				if (ejAcZFbhagbRvuNefCVJGXCXAmObb && rrNgbZAABMutEirMEGduuIWWiFChb > num)
				{
					result = Keyboard;
					num = rrNgbZAABMutEirMEGduuIWWiFChb;
				}
				qGrCOpcsBpSnsORfVQEpYDipwlGY(ControllerType.Custom, ref result, ref num);
				if (JNfKGkyINqVVlsbbVMjssFIAHKWV >= 0)
				{
					Controller controller = GetController(NLSciAEGtrGhrxuSvVdxfzeuSNdZ, JNfKGkyINqVVlsbbVMjssFIAHKWV);
					if (controller != null && kbIPdyHwGAleDRhkVBFiGhQhQoymA >= num)
					{
						result = controller;
						num = kbIPdyHwGAleDRhkVBFiGhQhQoymA;
					}
				}
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					qGrCOpcsBpSnsORfVQEpYDipwlGY(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (ejAcZFbhagbRvuNefCVJGXCXAmObb && rrNgbZAABMutEirMEGduuIWWiFChb > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (UAxtacLohAYptSzTVDHGWKcWNHOq && zRCjqrbJkuFlUTAMlkevOrzNSRSe > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				if (JNfKGkyINqVVlsbbVMjssFIAHKWV >= 0 && controllerType == NLSciAEGtrGhrxuSvVdxfzeuSNdZ)
				{
					Controller controller = GetController(NLSciAEGtrGhrxuSvVdxfzeuSNdZ, JNfKGkyINqVVlsbbVMjssFIAHKWV);
					if (controller != null && kbIPdyHwGAleDRhkVBFiGhQhQoymA >= num)
					{
						result = controller;
						num = kbIPdyHwGAleDRhkVBFiGhQhQoymA;
					}
				}
				return result;
			}

			public bool SetLastActiveController(Controller controller)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return false;
				}
				if (controller == null)
				{
					return false;
				}
				if (!ContainsController(controller))
				{
					return false;
				}
				JNfKGkyINqVVlsbbVMjssFIAHKWV = controller.id;
				NLSciAEGtrGhrxuSvVdxfzeuSNdZ = controller.type;
				kbIPdyHwGAleDRhkVBFiGhQhQoymA = ReInput.unscaledTime;
				return true;
			}

			private void qGrCOpcsBpSnsORfVQEpYDipwlGY(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
				int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb;
				for (int i = 0; i < num; i++)
				{
					double num2 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).LsrdLSuplQGcDIuPafGpkCGZDCoe;
					if (!(num2 <= P_2))
					{
						P_1 = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(i).UCMOBjKhfpoECrfBzBtZepnlTjUc;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(bVcNkmaJvbHeBNQRpaleQvWHeXqv.zzvIXJkhxoPAdanZIgbgivDbxfvgA<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						UolvMVFsCEWDrjcoHINZAHaIEhxLA.CRkeKMxiPDzGLacrcoQHokrPEViD.VWYqmbYHyEBrPpqrhBLhPKemXtFk(UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						UolvMVFsCEWDrjcoHINZAHaIEhxLA.CRkeKMxiPDzGLacrcoQHokrPEViD.cqtWpxzNeUbCSyXVLBSdrJULliPJ(UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						UolvMVFsCEWDrjcoHINZAHaIEhxLA.CRkeKMxiPDzGLacrcoQHokrPEViD.MlBBuxyQfgImUapsxiiUPTMAfRogb(UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						UolvMVFsCEWDrjcoHINZAHaIEhxLA.CRkeKMxiPDzGLacrcoQHokrPEViD.ClYlSTVINRFNWmcAUSIVxMhfIDUE(UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
					{
						ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					}
					else
					{
						UolvMVFsCEWDrjcoHINZAHaIEhxLA.CRkeKMxiPDzGLacrcoQHokrPEViD.TbDOVSvIGUfMKFibPbaiyLktppFr(UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
				for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
				{
					Controller controller = wfFYNcuvnJHfgTRxOzRIchLDwYLJ(tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i).VNMWmvmTyINKrZrRDngTDyNxkgou, Controller.AlbEsUMpPCJhgQLDiFsMaiuPkGoQA, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return null;
				}
				int nnvlqoAEVkrjBxsIuTjXaJmrTSFG = tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG;
				for (int i = 0; i < nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
				{
					Controller controller = wfFYNcuvnJHfgTRxOzRIchLDwYLJ(tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i).VNMWmvmTyINKrZrRDngTDyNxkgou, Controller.tglgkFHnvyFSgFaKTCTizAkQHrFx, templateType);
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
				if (ReInput._id != FgGVJqaPpwFzrFLpERRfYcoowJJg)
				{
					ReInput.CheckInitialized(FgGVJqaPpwFzrFLpERRfYcoowJJg);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return zNfpPFMhkvbbaOWVXQFeSIdWtofJ.MHQnzUbHMBcCPeeKTudObjnLDeRbA<TInterface>();
			}

			private Controller wfFYNcuvnJHfgTRxOzRIchLDwYLJ<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
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
					if (ejAcZFbhagbRvuNefCVJGXCXAmObb && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (UAxtacLohAYptSzTVDHGWKcWNHOq && P_1(Mouse, P_2))
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

			internal void HZNhnhuVrtfIqixbObjqCXrCsMZn()
			{
				for (int i = 0; i < tpLAStrOAbmqGMDjpNidjCONHxnfA.nnvlqoAEVkrjBxsIuTjXaJmrTSFG; i++)
				{
					tpLAStrOAbmqGMDjpNidjCONHxnfA.feNNrANNfBoPvvOtNuHmGhPiUhWG(i).djoFrUBAnDwBpvguRjmklfNcJFJs();
				}
				tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Keyboard).FWRYswoIAsiqrxIUfggdsRmvUjsv(new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Keyboard, KeyboardMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY(ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.IeYgCxBcbnFZhKaxGJMqKHnEVRHi, new global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<KeyboardMap>(0)));
				tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Mouse).FWRYswoIAsiqrxIUfggdsRmvUjsv(new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Mouse, MouseMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY(ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.QRdffiyBXZIwyIaPCjnZBUdIBmik, new global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<MouseMap>(0)));
				WeTlLgtnEcedzdjbKVXuxepDCgfF.BThvpMunOzRYWCIPfUaKnwuTkvBn();
				rrNgbZAABMutEirMEGduuIWWiFChb = 0.0;
				zRCjqrbJkuFlUTAMlkevOrzNSRSe = 0.0;
				maps.QhHbMsEJDHJTogalvqUvkUETdircb();
			}

			internal double dvPcspUFpGAddujJxHGMEVqOSUGBA(int P_0)
			{
				return WeTlLgtnEcedzdjbKVXuxepDCgfF.ERjAZxdKopfEKWpJlqEQgkgqZkoKA(P_0)?.xkyyWcdRkDWAmhkEUBpUgtzVHltfA ?? (-1.0);
			}

			internal void kgFzKznruBeNzkDBKoxpkVkyQsiO(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick);
				if (oqyCGPauVpdeCYocXRLbgQLkEJqSb2.TppoEOtwrQsjeHgBuhTqETedUKXv(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				hMEdODXgCmwsxlgvcleZEdSDNowO.ZCPnOoKMzyRodRdbHvtEHhzADZTx zCPnOoKMzyRodRdbHvtEHhzADZTx = WeTlLgtnEcedzdjbKVXuxepDCgfF.ERjAZxdKopfEKWpJlqEQgkgqZkoKA(P_0.id);
				kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY xNKZnmZDWSpEQNETiUDuIefVGQwY;
				if (zCPnOoKMzyRodRdbHvtEHhzADZTx != null && zCPnOoKMzyRodRdbHvtEHhzADZTx.YrKAVQboSIQQXeSJDYCLyPsyBiWH != null)
				{
					xNKZnmZDWSpEQNETiUDuIefVGQwY = new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY(P_0, zCPnOoKMzyRodRdbHvtEHhzADZTx.YrKAVQboSIQQXeSJDYCLyPsyBiWH);
				}
				else
				{
					global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap> aHIwDYxlaXXEqmpFSbWKzMJxRrGM = maps.AJrIbhXCyqDOKFcHYTyyStyEgmnEb(P_0, true);
					if (aHIwDYxlaXXEqmpFSbWKzMJxRrGM == null)
					{
						aHIwDYxlaXXEqmpFSbWKzMJxRrGM = new global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<JoystickMap>(P_0.id);
					}
					xNKZnmZDWSpEQNETiUDuIefVGQwY = new kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY(P_0, aHIwDYxlaXXEqmpFSbWKzMJxRrGM);
				}
				oqyCGPauVpdeCYocXRLbgQLkEJqSb2.FWRYswoIAsiqrxIUfggdsRmvUjsv(xNKZnmZDWSpEQNETiUDuIefVGQwY);
				WeTlLgtnEcedzdjbKVXuxepDCgfF.PpLGmxhxQKcSjmfZEMLEhelNMwJE(xNKZnmZDWSpEQNETiUDuIefVGQwY);
				zNfpPFMhkvbbaOWVXQFeSIdWtofJ.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(P_0);
				maps.layoutManager.Apply();
				if (wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Count > 0)
				{
					wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void CimaUiWtHnGIGOFLFXJWvscbRRkX(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					kgFzKznruBeNzkDBKoxpkVkyQsiO(joystick, P_1);
				}
			}

			internal void aHoecyjpwfZVlrepzckXCtgAFMzVB(int P_0)
			{
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick);
				if (oqyCGPauVpdeCYocXRLbgQLkEJqSb2.TppoEOtwrQsjeHgBuhTqETedUKXv(P_0))
				{
					if (oqyCGPauVpdeCYocXRLbgQLkEJqSb2.xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(P_0) is kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY xNKZnmZDWSpEQNETiUDuIefVGQwY)
					{
						WeTlLgtnEcedzdjbKVXuxepDCgfF.PpLGmxhxQKcSjmfZEMLEhelNMwJE(xNKZnmZDWSpEQNETiUDuIefVGQwY);
					}
					oqyCGPauVpdeCYocXRLbgQLkEJqSb2.sHXmrmxafdDTEfbGteIHKDUZalPUA(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					zNfpPFMhkvbbaOWVXQFeSIdWtofJ.XwKsqBusctndNwTHULgAVhQaVOrh(joystick);
					if (CcGxqqcIsbNtGYzcTzFKDBddIlEU.Count > 0)
					{
						CcGxqqcIsbNtGYzcTzFKDBddIlEU.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void DkOncnMnWrWxeEmylVVbowdiaRdA(Joystick P_0)
			{
				if (P_0 != null)
				{
					aHoecyjpwfZVlrepzckXCtgAFMzVB(P_0.id);
				}
			}

			internal void GtyCEykctlKfysqBsOXiRHFmQbRY()
			{
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Joystick);
				for (int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb - 1; num >= 0; num--)
				{
					WeTlLgtnEcedzdjbKVXuxepDCgfF.PpLGmxhxQKcSjmfZEMLEhelNMwJE(oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num) as kiJAeGTUDdTpPSkOAFpElaZegNnkA<Joystick, JoystickMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY);
					zNfpPFMhkvbbaOWVXQFeSIdWtofJ.XwKsqBusctndNwTHULgAVhQaVOrh(oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc);
					int id = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc.id;
					oqyCGPauVpdeCYocXRLbgQLkEJqSb2.BVtvvXJSUrkeWvnblchyxjLwafdeA(num);
					if (CcGxqqcIsbNtGYzcTzFKDBddIlEU.Count > 0)
					{
						CcGxqqcIsbNtGYzcTzFKDBddIlEU.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, id, ControllerType.Joystick, false));
					}
				}
				oqyCGPauVpdeCYocXRLbgQLkEJqSb2.djoFrUBAnDwBpvguRjmklfNcJFJs();
			}

			internal void tUpQztgzMvrGeWQbWPjNmBYocgiw(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom);
				if (!oqyCGPauVpdeCYocXRLbgQLkEJqSb2.TppoEOtwrQsjeHgBuhTqETedUKXv(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<CustomControllerMap> aHIwDYxlaXXEqmpFSbWKzMJxRrGM = maps.lwAlIcmhLgAwbiwAivcfhTBzZckAA(P_0, true);
					if (aHIwDYxlaXXEqmpFSbWKzMJxRrGM == null)
					{
						aHIwDYxlaXXEqmpFSbWKzMJxRrGM = new global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<CustomControllerMap>(P_0.id);
					}
					kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY xNKZnmZDWSpEQNETiUDuIefVGQwY = new kiJAeGTUDdTpPSkOAFpElaZegNnkA<CustomController, CustomControllerMap>.xNKZnmZDWSpEQNETiUDuIefVGQwY(P_0, aHIwDYxlaXXEqmpFSbWKzMJxRrGM);
					oqyCGPauVpdeCYocXRLbgQLkEJqSb2.FWRYswoIAsiqrxIUfggdsRmvUjsv(xNKZnmZDWSpEQNETiUDuIefVGQwY);
					zNfpPFMhkvbbaOWVXQFeSIdWtofJ.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(P_0);
					maps.layoutManager.Apply();
					if (wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Count > 0)
					{
						wPORUgEhqYCPGhZZMKLQVNgdkjQiA.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void rPFiTAJfzgEQSDAFzCNXeDzAscDY(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					tUpQztgzMvrGeWQbWPjNmBYocgiw(customController, P_1);
				}
			}

			internal void UvlWJHGszIPTQgsImcEtYWpMGMmF(int P_0)
			{
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom);
				if (oqyCGPauVpdeCYocXRLbgQLkEJqSb2.TppoEOtwrQsjeHgBuhTqETedUKXv(P_0))
				{
					oqyCGPauVpdeCYocXRLbgQLkEJqSb2.xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(P_0);
					oqyCGPauVpdeCYocXRLbgQLkEJqSb2.sHXmrmxafdDTEfbGteIHKDUZalPUA(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					zNfpPFMhkvbbaOWVXQFeSIdWtofJ.XwKsqBusctndNwTHULgAVhQaVOrh(customController);
					if (CcGxqqcIsbNtGYzcTzFKDBddIlEU.Count > 0)
					{
						CcGxqqcIsbNtGYzcTzFKDBddIlEU.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void xnNwTjwEZWCgoEZEDKFvKFCBQBgAb(CustomController P_0)
			{
				if (P_0 != null)
				{
					UvlWJHGszIPTQgsImcEtYWpMGMmF(P_0.id);
				}
			}

			internal void neqvcyeJADcyhTOPMpERtFeZjBjfA()
			{
				oqyCGPauVpdeCYocXRLbgQLkEJqSb oqyCGPauVpdeCYocXRLbgQLkEJqSb2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Custom);
				for (int num = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.yqhlCDSAeeNknWUrdPHIJVxJgUrb - 1; num >= 0; num--)
				{
					zNfpPFMhkvbbaOWVXQFeSIdWtofJ.XwKsqBusctndNwTHULgAVhQaVOrh(oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc);
					int id = oqyCGPauVpdeCYocXRLbgQLkEJqSb2.LNTBMmjuONFUBLurbFbXivzHrdyGb(num).UCMOBjKhfpoECrfBzBtZepnlTjUc.id;
					oqyCGPauVpdeCYocXRLbgQLkEJqSb2.BVtvvXJSUrkeWvnblchyxjLwafdeA(num);
					if (CcGxqqcIsbNtGYzcTzFKDBddIlEU.Count > 0)
					{
						CcGxqqcIsbNtGYzcTzFKDBddIlEU.Invoke(new ControllerAssignmentChangedEventArgs(UolvMVFsCEWDrjcoHINZAHaIEhxLA.id, id, ControllerType.Custom, false));
					}
				}
				oqyCGPauVpdeCYocXRLbgQLkEJqSb2.djoFrUBAnDwBpvguRjmklfNcJFJs();
			}

			internal CustomController fKtQgLUcPCNtyJrdtEScHpPmjqUM(int P_0)
			{
				CustomController customController = UolvMVFsCEWDrjcoHINZAHaIEhxLA.CRkeKMxiPDzGLacrcoQHokrPEViD.NprxOsPQZmIODMrEVTJSdqAawKNH(P_0);
				if (customController == null)
				{
					return null;
				}
				tUpQztgzMvrGeWQbWPjNmBYocgiw(customController, false);
				return customController;
			}

			internal void mYjFmbIOwNlJfBZCXYiXsgDEiXdd(Action<bool, int, int> P_0)
			{
				QsqFqcVgJXsRkRbxrAHqSegdjZoB<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void FMVuajrXjATxmmToWcysWcqOCVMeA(Keyboard P_0, hDRjlPfDOtRlfpMOOkqkYoBqMUPDA P_1, Action<bool, int, int> P_2)
			{
				if (!ejAcZFbhagbRvuNefCVJGXCXAmObb || !P_0.enabled)
				{
					return;
				}
				GzcteHVAfAafMobmLlSAJXPvwqFL udmQYSAbdznnxGatFkGbeSAHoaYM = lXvJAREcFJqTwbpbVaXyWnOsESQEA.UdmQYSAbdznnxGatFkGbeSAHoaYM;
				bool flag = false;
				wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Keyboard).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(0).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
				int num = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				hDRjlPfDOtRlfpMOOkqkYoBqMUPDA.GPNEdVBuhanaiWVCDlGZFxWBuBir gPNEdVBuhanaiWVCDlGZFxWBuBir = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? hDRjlPfDOtRlfpMOOkqkYoBqMUPDA.GPNEdVBuhanaiWVCDlGZFxWBuBir.OverlapModifiers : hDRjlPfDOtRlfpMOOkqkYoBqMUPDA.GPNEdVBuhanaiWVCDlGZFxWBuBir.Normal);
				XQbPBhlyQFBGpNmlFgFIDEslKZJP.xyrBiUFcLFiQhnXPGmvEmNtNzoeY xyrBiUFcLFiQhnXPGmvEmNtNzoeY = new XQbPBhlyQFBGpNmlFgFIDEslKZJP.xyrBiUFcLFiQhnXPGmvEmNtNzoeY
				{
					NTcSwwzbfIqHmkxShleEAhkncBPdA = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.OurlyxeFzWBnIptcmgMKsPUxiwjO;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
						bool flag3 = false;
						bool flag4;
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							ButtonStateFlags buttonStateFlags = (P_0.qqdvAhHPNsZIohampAoagYdZvzxD(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag4)
							{
								XQbPBhlyQFBGpNmlFgFIDEslKZJP xQbPBhlyQFBGpNmlFgFIDEslKZJP = XQbPBhlyQFBGpNmlFgFIDEslKZJP.mzqCowBlnAZAIhNmHwTkniNCLRvWA(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA);
								if (xQbPBhlyQFBGpNmlFgFIDEslKZJP != null && xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(true) != ButtonStateFlags.Off)
								{
									flag4 = true;
								}
							}
						}
						else
						{
							ButtonStateFlags buttonStateFlags = P_0.yzzkYDFOMvoraCJYdYbiyAQxmSiO(actionElementMap.fpLTJzOTpoUWkyThKhrqRzXDquMW);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag4 && !flag2 && !P_1.XOMztahPytDHXYdiiONMPUglMfIN(keyboardKeyCode, modifierKeyFlags, gPNEdVBuhanaiWVCDlGZFxWBuBir, out flag3))
						{
							P_1.iBxkGUQTfciyHIQJlpMouAvSXJsn(keyboardKeyCode, modifierKeyFlags);
						}
					}
				}
				for (int k = 0; k < num; k++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(k);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.OurlyxeFzWBnIptcmgMKsPUxiwjO;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
						bool flag5 = false;
						bool flag3 = false;
						ButtonStateFlags buttonStateFlags;
						bool flag4;
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							buttonStateFlags = (P_0.qqdvAhHPNsZIohampAoagYdZvzxD(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag4)
							{
								XQbPBhlyQFBGpNmlFgFIDEslKZJP xQbPBhlyQFBGpNmlFgFIDEslKZJP = XQbPBhlyQFBGpNmlFgFIDEslKZJP.mzqCowBlnAZAIhNmHwTkniNCLRvWA(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA);
								if (xQbPBhlyQFBGpNmlFgFIDEslKZJP != null && xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(true) != ButtonStateFlags.Off)
								{
									flag4 = true;
								}
							}
						}
						else
						{
							buttonStateFlags = P_0.yzzkYDFOMvoraCJYdYbiyAQxmSiO(actionElementMap.fpLTJzOTpoUWkyThKhrqRzXDquMW);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag4)
						{
							if (!flag2)
							{
								flag5 = P_1.XOMztahPytDHXYdiiONMPUglMfIN(keyboardKeyCode, modifierKeyFlags, gPNEdVBuhanaiWVCDlGZFxWBuBir, out flag3);
							}
							if (flag3 || modifierKeyFlags != ModifierKeyFlags.None)
							{
								xyrBiUFcLFiQhnXPGmvEmNtNzoeY.YZuvVKhNrLMKJgCgkzLHkkjferjG = flag5;
								XQbPBhlyQFBGpNmlFgFIDEslKZJP xQbPBhlyQFBGpNmlFgFIDEslKZJP = XQbPBhlyQFBGpNmlFgFIDEslKZJP.AlseqFygUpijvvuzMomIBteKutUo(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, xyrBiUFcLFiQhnXPGmvEmNtNzoeY);
								if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
								{
									xQbPBhlyQFBGpNmlFgFIDEslKZJP.nXeuusDIfwjcSbkGqdARxzcJGoBzA = flag5;
								}
								else if (flag5)
								{
									xQbPBhlyQFBGpNmlFgFIDEslKZJP.nXeuusDIfwjcSbkGqdARxzcJGoBzA = true;
								}
								xQbPBhlyQFBGpNmlFgFIDEslKZJP.GUcHXzOThGSFFpQpOLrdpEwsgVbw(ReInput.currentUpdateLoop, buttonStateFlags, true);
								buttonStateFlags = xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(true);
							}
						}
						if (buttonStateFlags != ButtonStateFlags.Off)
						{
							CCYoJErQmFoWpRnNeDGTIgFXFMvjA(P_0, keyboardMap, actionElementMap, udmQYSAbdznnxGatFkGbeSAHoaYM, buttonStateFlags);
							P_2(arg1: true, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId);
							flag = true;
							continue;
						}
						if (udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS != 0f)
						{
							udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS = 0f;
						}
						if (udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA != ButtonStateFlags.Off)
						{
							udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA = ButtonStateFlags.Off;
						}
						P_2(arg1: false, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId);
					}
				}
				if (flag)
				{
					rrNgbZAABMutEirMEGduuIWWiFChb = ReInput.unscaledTime;
				}
			}

			private static void CCYoJErQmFoWpRnNeDGTIgFXFMvjA(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, GzcteHVAfAafMobmLlSAJXPvwqFL P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.nVgyBosFgMfEgEIRGJBOvhwPcECS = num;
				P_3.dxmfwlBKyJgKTHhYIvbCzwuzluuxA = P_4;
				P_3.ybknGBKDxfcqoptlGzrmiunQcNQd = P_0;
				P_3.WcxJgpdLbutPonSkkyogJpvoNTle = ControllerType.Keyboard;
				P_3.iKxJuNMacuDbqIfJzRyJOHaTUoKh = ControllerElementType.Button;
				P_3.oINnxwklOGWjkmeFEwCWyrYLGwxc = P_2;
				P_3.rvQeyYKKuOtqobffnuGgObRodBPG = P_1;
				if (P_3.kWUoNReOofPXiVuzclhTsWonzAKF)
				{
					P_3.kWUoNReOofPXiVuzclhTsWonzAKF = false;
				}
				if (P_3.MdZuMpKNfEqOTajQmIcoBxjeyrOg)
				{
					P_3.MdZuMpKNfEqOTajQmIcoBxjeyrOg = false;
				}
			}

			internal void PoZFjRDtojkUvqrMFOxsMSKfKyFE(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!UAxtacLohAYptSzTVDHGWKcWNHOq || !P_0.enabled)
				{
					return;
				}
				wfTqPVowqyEtwvBJoegCIMAGtbtoA wfTqPVowqyEtwvBJoegCIMAGtbtoA2 = tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(ControllerType.Mouse).xpLQGkMQDvVaNbiMlEfVfvZFVSPmA(0).ZVqQCpBpHaJoxANGetaJnsjmlMojA;
				GzcteHVAfAafMobmLlSAJXPvwqFL udmQYSAbdznnxGatFkGbeSAHoaYM = lXvJAREcFJqTwbpbVaXyWnOsESQEA.UdmQYSAbdznnxGatFkGbeSAHoaYM;
				bool flag = false;
				int num = wfTqPVowqyEtwvBJoegCIMAGtbtoA2.rRNsYbuGoAwgMGKrqdvwNwutVwQo;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)wfTqPVowqyEtwvBJoegCIMAGtbtoA2.tMPEVPdgqovMveUHOiirPevVOylqA(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.muRswczhYozagKzkUJyzqdvmqubg;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.utDGiyZiGObpWBRWDGOhdnZIgBZv(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.utDGiyZiGObpWBRWDGOhdnZIgBZv(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId);
									continue;
								}
							}
							udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS = num2;
							udmQYSAbdznnxGatFkGbeSAHoaYM.ybknGBKDxfcqoptlGzrmiunQcNQd = P_0;
							udmQYSAbdznnxGatFkGbeSAHoaYM.WcxJgpdLbutPonSkkyogJpvoNTle = ControllerType.Mouse;
							udmQYSAbdznnxGatFkGbeSAHoaYM.iKxJuNMacuDbqIfJzRyJOHaTUoKh = ControllerElementType.Axis;
							udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc = actionElementMap;
							udmQYSAbdznnxGatFkGbeSAHoaYM.rvQeyYKKuOtqobffnuGgObRodBPG = mouseMap;
							if (udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg)
							{
								udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg = false;
							}
							if (udmQYSAbdznnxGatFkGbeSAHoaYM.eTmTAeqmpDvAHPsCtSeuLWngFCNH != AxisCoordinateMode.Relative)
							{
								udmQYSAbdznnxGatFkGbeSAHoaYM.eTmTAeqmpDvAHPsCtSeuLWngFCNH = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.OurlyxeFzWBnIptcmgMKsPUxiwjO;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.OoMHmAdcRmxeTmnlxkbcciLNKMWV(actionElementMap2, actionId2, out var nVgyBosFgMfEgEIRGJBOvhwPcECS, out udmQYSAbdznnxGatFkGbeSAHoaYM.kWUoNReOofPXiVuzclhTsWonzAKF))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.yzzkYDFOMvoraCJYdYbiyAQxmSiO(actionElementMap2.fpLTJzOTpoUWkyThKhrqRzXDquMW);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId2);
							continue;
						}
						udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS = nVgyBosFgMfEgEIRGJBOvhwPcECS;
						udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA = buttonStateFlags;
						udmQYSAbdznnxGatFkGbeSAHoaYM.ybknGBKDxfcqoptlGzrmiunQcNQd = P_0;
						udmQYSAbdznnxGatFkGbeSAHoaYM.WcxJgpdLbutPonSkkyogJpvoNTle = ControllerType.Mouse;
						udmQYSAbdznnxGatFkGbeSAHoaYM.iKxJuNMacuDbqIfJzRyJOHaTUoKh = ControllerElementType.Button;
						udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc = actionElementMap2;
						udmQYSAbdznnxGatFkGbeSAHoaYM.rvQeyYKKuOtqobffnuGgObRodBPG = mouseMap;
						if (udmQYSAbdznnxGatFkGbeSAHoaYM.kWUoNReOofPXiVuzclhTsWonzAKF)
						{
							udmQYSAbdznnxGatFkGbeSAHoaYM.kWUoNReOofPXiVuzclhTsWonzAKF = false;
						}
						if (udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg)
						{
							udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg = false;
						}
						P_1(arg1: true, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					zRCjqrbJkuFlUTAMlkevOrzNSRSe = ReInput.unscaledTime;
				}
			}

			internal void BCNHLDCvTkkKgrheRTuBozLwyWVp(Action<bool, int, int> P_0)
			{
				QsqFqcVgJXsRkRbxrAHqSegdjZoB<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void QsqFqcVgJXsRkRbxrAHqSegdjZoB<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				kiJAeGTUDdTpPSkOAFpElaZegNnkA<_0001, _0002> kiJAeGTUDdTpPSkOAFpElaZegNnkA2 = (kiJAeGTUDdTpPSkOAFpElaZegNnkA<_0001, _0002>)tpLAStrOAbmqGMDjpNidjCONHxnfA.nzwDDoBYZWSecwmyVNwVlAlWJZIv(P_0);
				GzcteHVAfAafMobmLlSAJXPvwqFL udmQYSAbdznnxGatFkGbeSAHoaYM = lXvJAREcFJqTwbpbVaXyWnOsESQEA.UdmQYSAbdznnxGatFkGbeSAHoaYM;
				int num = kiJAeGTUDdTpPSkOAFpElaZegNnkA2.OlEGRykNhNKGseDKgLykUcpcZeJDB();
				for (int i = 0; i < num; i++)
				{
					kiJAeGTUDdTpPSkOAFpElaZegNnkA<_0001, _0002>.xNKZnmZDWSpEQNETiUDuIefVGQwY xNKZnmZDWSpEQNETiUDuIefVGQwY = kiJAeGTUDdTpPSkOAFpElaZegNnkA2.bIdivaZNcgbpPNtDUCVjnqLmhAOc(i);
					_0001 oGKSTOLCyntwnzWvSpSVBzuxFIIC = xNKZnmZDWSpEQNETiUDuIefVGQwY.OGKSTOLCyntwnzWvSpSVBzuxFIIC;
					if (!oGKSTOLCyntwnzWvSpSVBzuxFIIC.enabled)
					{
						continue;
					}
					global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0002> zZnBfQBoEAksLWJBlRShlDbbsdXd = xNKZnmZDWSpEQNETiUDuIefVGQwY.ZZnBfQBoEAksLWJBlRShlDbbsdXd;
					bool flag = false;
					int num2 = zZnBfQBoEAksLWJBlRShlDbbsdXd.BnLfdLdejZPchYBMOscGuqKWagU();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = zZnBfQBoEAksLWJBlRShlDbbsdXd.QctWoySrGTZJSArZHyJFYsCcnKlK(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.muRswczhYozagKzkUJyzqdvmqubg;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!oGKSTOLCyntwnzWvSpSVBzuxFIIC.utDGiyZiGObpWBRWDGOhdnZIgBZv(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									oGKSTOLCyntwnzWvSpSVBzuxFIIC.utDGiyZiGObpWBRWDGOhdnZIgBZv(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId);
										continue;
									}
								}
								udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS = num3;
								udmQYSAbdznnxGatFkGbeSAHoaYM.ybknGBKDxfcqoptlGzrmiunQcNQd = oGKSTOLCyntwnzWvSpSVBzuxFIIC;
								udmQYSAbdznnxGatFkGbeSAHoaYM.WcxJgpdLbutPonSkkyogJpvoNTle = P_0;
								udmQYSAbdznnxGatFkGbeSAHoaYM.iKxJuNMacuDbqIfJzRyJOHaTUoKh = ControllerElementType.Axis;
								udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc = actionElementMap;
								udmQYSAbdznnxGatFkGbeSAHoaYM.rvQeyYKKuOtqobffnuGgObRodBPG = val;
								udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg = oGKSTOLCyntwnzWvSpSVBzuxFIIC.calibrationMap.Axes[actionElementMap.fpLTJzOTpoUWkyThKhrqRzXDquMW].applyRangeCalibration;
								udmQYSAbdznnxGatFkGbeSAHoaYM.eTmTAeqmpDvAHPsCtSeuLWngFCNH = oGKSTOLCyntwnzWvSpSVBzuxFIIC.Axes[actionElementMap.elementIndex].aWgdabdFXKHTbUDLyoVfrwOlgFah?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.OurlyxeFzWBnIptcmgMKsPUxiwjO;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float nVgyBosFgMfEgEIRGJBOvhwPcECS = 0f;
								int fpLTJzOTpoUWkyThKhrqRzXDquMW = actionElementMap2.fpLTJzOTpoUWkyThKhrqRzXDquMW;
								if (!yXYMpJgKyljUPsKoUZwLabUaUycD(oGKSTOLCyntwnzWvSpSVBzuxFIIC, i, fpLTJzOTpoUWkyThKhrqRzXDquMW, actionElementMap2, zZnBfQBoEAksLWJBlRShlDbbsdXd, actionId2, ref nVgyBosFgMfEgEIRGJBOvhwPcECS) && !oGKSTOLCyntwnzWvSpSVBzuxFIIC.OoMHmAdcRmxeTmnlxkbcciLNKMWV(actionElementMap2, actionId2, out nVgyBosFgMfEgEIRGJBOvhwPcECS, out udmQYSAbdznnxGatFkGbeSAHoaYM.kWUoNReOofPXiVuzclhTsWonzAKF))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = oGKSTOLCyntwnzWvSpSVBzuxFIIC.yzzkYDFOMvoraCJYdYbiyAQxmSiO(actionElementMap2.fpLTJzOTpoUWkyThKhrqRzXDquMW);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId2);
									continue;
								}
								udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS = nVgyBosFgMfEgEIRGJBOvhwPcECS;
								udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA = buttonStateFlags;
								udmQYSAbdznnxGatFkGbeSAHoaYM.ybknGBKDxfcqoptlGzrmiunQcNQd = oGKSTOLCyntwnzWvSpSVBzuxFIIC;
								udmQYSAbdznnxGatFkGbeSAHoaYM.WcxJgpdLbutPonSkkyogJpvoNTle = P_0;
								udmQYSAbdznnxGatFkGbeSAHoaYM.iKxJuNMacuDbqIfJzRyJOHaTUoKh = ControllerElementType.Button;
								udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc = actionElementMap2;
								udmQYSAbdznnxGatFkGbeSAHoaYM.rvQeyYKKuOtqobffnuGgObRodBPG = val;
								if (udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg)
								{
									udmQYSAbdznnxGatFkGbeSAHoaYM.MdZuMpKNfEqOTajQmIcoBxjeyrOg = false;
								}
								P_1(arg1: true, UolvMVFsCEWDrjcoHINZAHaIEhxLA.hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							xNKZnmZDWSpEQNETiUDuIefVGQwY.bBZgHHlMPcCfOdIlwbCkZgETpsze();
						}
					}
				}
			}

			private bool yXYMpJgKyljUPsKoUZwLabUaUycD<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.vAJlxjrsCepUBGzroHjWcArmXQkU.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.vAJlxjrsCepUBGzroHjWcArmXQkU.GetUnknownHatButtons(P_2);
				if (KkhemLoDjErnSAkKUSqFsLZiEEoC(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.kyuOdCuxIzFBaEiPRoQDIZEzdwqc(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool KkhemLoDjErnSAkKUSqFsLZiEEoC<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (iiwVMmvlsFYIaJabWeuvToabAyVgA(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool iiwVMmvlsFYIaJabWeuvToabAyVgA<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::AHIwDYxlaXXEqmpFSbWKzMJxRrGM<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.BnLfdLdejZPchYBMOscGuqKWagU();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.QctWoySrGTZJSArZHyJFYsCcnKlK(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int fpLTJzOTpoUWkyThKhrqRzXDquMW = buttonMaps[j].fpLTJzOTpoUWkyThKhrqRzXDquMW;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(fpLTJzOTpoUWkyThKhrqRzXDquMW))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private const string lEOrVZNLCwzxZUepwphhPmqagRDB = "player";

		private readonly AIeedhFnMWGfSehpftpyUhoWcUabB CRkeKMxiPDzGLacrcoQHokrPEViD;

		private bool uNjEzuFfMtoAYjoSHdibMwqoEchfb;

		private int hNoRiloMAZCwMJhqxCSNjcRIpGck;

		private string LewwISQXUmLRNCvPSyBcSwmcSvB;

		private string cqBCXGKbeiPGxemAqMxmmVVgSVyc;

		private readonly string SxGoDbXSYFWkodffZfEWdTfwMwlO;

		private bool SxGGPeNAccuoMPengZfvZmQBxhGE;

		private readonly int LnvmXTENaYtFQvqmQFadBAomtywJ;

		private readonly pdfeDVjdjwArmqtCcVAoNpExpqyM LmVOEUjhHJblsPcmNeOQbBePcvAIA;

		private int UTrtajtOCpdoOXwSoMIsAXBBGsUO;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
					return -1;
				}
				return hNoRiloMAZCwMJhqxCSNjcRIpGck;
			}
			internal set
			{
				hNoRiloMAZCwMJhqxCSNjcRIpGck = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
					return string.Empty;
				}
				return LewwISQXUmLRNCvPSyBcSwmcSvB;
			}
			internal set
			{
				LewwISQXUmLRNCvPSyBcSwmcSvB = lewwISQXUmLRNCvPSyBcSwmcSvB;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return cqBCXGKbeiPGxemAqMxmmVVgSVyc;
				}
				return LmVOEUjhHJblsPcmNeOQbBePcvAIA.HKQoqutKkgeGtFcRmtcKMQqgsDoY;
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
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
					return false;
				}
				return SxGGPeNAccuoMPengZfvZmQBxhGE;
			}
			set
			{
				SxGGPeNAccuoMPengZfvZmQBxhGE = value;
			}
		}

		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return cqBCXGKbeiPGxemAqMxmmVVgSVyc;
			}
			set
			{
				cqBCXGKbeiPGxemAqMxmmVVgSVyc = value;
				LmVOEUjhHJblsPcmNeOQbBePcvAIA.XIvHPuMcrskwDDbqHcWqpyJRLTkr();
			}
		}

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.keyCategory => "player";

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.scriptingName => LewwISQXUmLRNCvPSyBcSwmcSvB;

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.nonLocalizedDescriptiveName
		{
			get
			{
				return cqBCXGKbeiPGxemAqMxmmVVgSVyc;
			}
			set
			{
				cqBCXGKbeiPGxemAqMxmmVVgSVyc = value;
			}
		}

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.key => SxGoDbXSYFWkodffZfEWdTfwMwlO;

		int sZLAxvZSvDRmVjMjTVRhHfujppQp.autoGeneratedValueFlags
		{
			get
			{
				return UTrtajtOCpdoOXwSoMIsAXBBGsUO;
			}
			set
			{
				UTrtajtOCpdoOXwSoMIsAXBBGsUO = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, ReblhCinFkWhDVFLEbjmzIdfVvaS P_5, ControllerMapLayoutManager.VRUPdzKgeveqVvQabkIaYFoBcpSf P_6, ControllerMapEnabler.LoufCxnWRPkzSbBIKyhZshokUpWL P_7)
		{
			uNjEzuFfMtoAYjoSHdibMwqoEchfb = P_0;
			hNoRiloMAZCwMJhqxCSNjcRIpGck = P_1;
			LewwISQXUmLRNCvPSyBcSwmcSvB = P_2;
			cqBCXGKbeiPGxemAqMxmmVVgSVyc = P_3;
			SxGoDbXSYFWkodffZfEWdTfwMwlO = P_4;
			LnvmXTENaYtFQvqmQFadBAomtywJ = ReInput.id;
			LmVOEUjhHJblsPcmNeOQbBePcvAIA = pdfeDVjdjwArmqtCcVAoNpExpqyM.FFjXRWNznybaCatfhwLUCHTjGTKc(this);
			controllers = new ControllerHelper(this, P_5, P_6, P_7);
			CRkeKMxiPDzGLacrcoQHokrPEViD = ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp;
			RsfKzYPMmToXTiWaVlAGZLcOAKECA();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(hNoRiloMAZCwMJhqxCSNjcRIpGck));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.IPBglEDiskLyDaFoCmNkHNTILvkoD() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.IPBglEDiskLyDaFoCmNkHNTILvkoD() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.riuGhwaMOAdFGDFRYDzUUxYehYkQ() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.riuGhwaMOAdFGDFRYDzUUxYehYkQ() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.bSwJemwUEXGGBhhqyxFRvLmWIqGY() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.bSwJemwUEXGGBhhqyxFRvLmWIqGY() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.nEpMkgAlUKaHmxrXsfKeYHsLoBLs() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.nEpMkgAlUKaHmxrXsfKeYHsLoBLs() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.MsrPrsRShXkgVvDLLEcmCVbzOLQcA() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.MsrPrsRShXkgVvDLLEcmCVbzOLQcA() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.IVgCBhoYMSCaNnypJLyYwFolNdOM() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.IVgCBhoYMSCaNnypJLyYwFolNdOM() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.IgudzUOMbpcOxmaZREBGjJgoJIdR() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.IgudzUOMbpcOxmaZREBGjJgoJIdR() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.hckAhLzhvsGrGziwjLVYftlXjutR(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.hckAhLzhvsGrGziwjLVYftlXjutR(speed) ?? false;
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.mXMcUQLDjZKLbSwyrIXXizIZMakC(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.mXMcUQLDjZKLbSwyrIXXizIZMakC(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.KAqgQWsIxLEjXBUDMPaMLyXeYtAn(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.KAqgQWsIxLEjXBUDMPaMLyXeYtAn(speed) ?? false;
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.iLyUWcCExyFVnKqBTGfvQeHpisZi(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.iLyUWcCExyFVnKqBTGfvQeHpisZi(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.iLyUWcCExyFVnKqBTGfvQeHpisZi(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.iLyUWcCExyFVnKqBTGfvQeHpisZi(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.jemjNeDdmCWQgidsYMLMtrxauMpI(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.jemjNeDdmCWQgidsYMLMtrxauMpI(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.ItrlVrVHcgtqpFPEduZHYaUCqwsA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.ItrlVrVHcgtqpFPEduZHYaUCqwsA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.ItrlVrVHcgtqpFPEduZHYaUCqwsA(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.ItrlVrVHcgtqpFPEduZHYaUCqwsA(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.UETjCacldnZLRsCFfOVVOpvGqwdQ() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.UETjCacldnZLRsCFfOVVOpvGqwdQ() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.ATbRCRlVsJgfySlKcqwDTzADtFRI() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.ATbRCRlVsJgfySlKcqwDTzADtFRI() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.uVNPDdyMewbdUMNPZOzbJiEcBZXf() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.uVNPDdyMewbdUMNPZOzbJiEcBZXf() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.XTygVrQDMeWzdvNCcbVUNEDkwhfC() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.XTygVrQDMeWzdvNCcbVUNEDkwhfC() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.lRGuwAswCvNtFPgHzSVLyVOVTlEC() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.lRGuwAswCvNtFPgHzSVLyVOVTlEC() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.yWxoBlcLzlemoOuRRYRbcWvDjOcV() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.yWxoBlcLzlemoOuRRYRbcWvDjOcV() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.saeQPtCwGGaeReinxCUMSwIrhYpF() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.saeQPtCwGGaeReinxCUMSwIrhYpF() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.qfpXhjfjlYYkePIpHDLQoLKWBrRh(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.aLFewbsSRKTevbkDwJKnaUEoVhEF(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.pDtbvuVIiYvWApoDKoxqfFNJzLoF(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.vwxyvUDOvuAmhVAeHauaKJLGtoDO(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.zPnrApSpNsImmvGZMcFVanMSfpHKA() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.zPnrApSpNsImmvGZMcFVanMSfpHKA() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.KCXSSDWhrBKElyGJfiInJrZHDPlM() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.KCXSSDWhrBKElyGJfiInJrZHDPlM() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.EVDaaHKwprBiqlvanCLDzZZcIJDp() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.EVDaaHKwprBiqlvanCLDzZZcIJDp() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.KhxBPpPiOXgSvGNtPRGOvHsskrZq() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.KhxBPpPiOXgSvGNtPRGOvHsskrZq() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.BljscRLzpNviyYundTExtmvpLKYc() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.BljscRLzpNviyYundTExtmvpLKYc() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.wmkdKpTjlGQnDOmTMMrTrHwnIdMn() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.wmkdKpTjlGQnDOmTMMrTrHwnIdMn() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.rGkjONohjkzPrXbjtneWnEsYAJiY() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.rGkjONohjkzPrXbjtneWnEsYAJiY() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.PssLqSiqevMTMMAUxerYquegHQSU() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.PssLqSiqevMTMMAUxerYquegHQSU() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.TcMLIdmkPPhJICPtZbiektZPSCJSA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.TcMLIdmkPPhJICPtZbiektZPSCJSA() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.YrTrWftClZWtgPLbnibohShAEeuZ(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.YrTrWftClZWtgPLbnibohShAEeuZ(speed) ?? false;
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.YfTFApbwCYgRwLFdqfiQjkzWPNuab(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.YfTFApbwCYgRwLFdqfiQjkzWPNuab(speed) ?? false;
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.mASgYYxHWsnQZmJkMriECBovlKfw(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.mASgYYxHWsnQZmJkMriECBovlKfw(speed) ?? false;
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.YLhODevbPifVPfCqHgMeDIrcXKTZ(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.YLhODevbPifVPfCqHgMeDIrcXKTZ(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.YLhODevbPifVPfCqHgMeDIrcXKTZ(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.YLhODevbPifVPfCqHgMeDIrcXKTZ(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.tUWRRMMUWPlLcOYXTSOBqCIELkSU(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.tUWRRMMUWPlLcOYXTSOBqCIELkSU(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.MlFIiayGhxVYtdBnJSeOifmmXqPP(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.MlFIiayGhxVYtdBnJSeOifmmXqPP(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.MlFIiayGhxVYtdBnJSeOifmmXqPP(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.MlFIiayGhxVYtdBnJSeOifmmXqPP(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.xdtelTQZIAOrSbeDpLVYUthjzRlF() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.xdtelTQZIAOrSbeDpLVYUthjzRlF() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.xhWVfrbsxAxhqeaigwQjfdPqaBad() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.xhWVfrbsxAxhqeaigwQjfdPqaBad() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.KzMLkitOPOzISfQfTrceQUKGuebA() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.KzMLkitOPOzISfQfTrceQUKGuebA() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.HNTYPDOjRxFFLksZTwvjllazYDRK() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.HNTYPDOjRxFFLksZTwvjllazYDRK() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.tlDAVpqQQoUumHLpmFcRHXlNablBb() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.tlDAVpqQQoUumHLpmFcRHXlNablBb() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.SgsZyJhnWgsoZNcDPZVRIXrmkMEV() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.SgsZyJhnWgsoZNcDPZVRIXrmkMEV() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.pZNwfbMswzBhQnSkWqbkqnETAquh() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.pZNwfbMswzBhQnSkWqbkqnETAquh() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.nvalaqICANEbLAMkUCPeuioeDCAD(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.sDFSvvrgLZVbOvNMdKQzsoxBDPQh(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yJpVtbiNHVKuWuwrhrneCQbIDpps(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.PsezMEgvboHOLnQudCEJXuFTNgKA(hNoRiloMAZCwMJhqxCSNjcRIpGck);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.zNaDAwIDQVnPuTtpIZSukgwOvEWqA() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.zNaDAwIDQVnPuTtpIZSukgwOvEWqA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.PhtHWpmnxNpVNzyigfJhEPPVAdcb() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.PhtHWpmnxNpVNzyigfJhEPPVAdcb() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.MsemiDNvFwuvkRHSoRvueQDDCJHf() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.MsemiDNvFwuvkRHSoRvueQDDCJHf() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.DeKBwydovtExYTMFfxXAMhbNoHGib() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.DeKBwydovtExYTMFfxXAMhbNoHGib() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.iARuJzhKfksmmefEbtjGLMIccAzj() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.iARuJzhKfksmmefEbtjGLMIccAzj() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.MqeXSgkURrlITajbbOSBTjoHZyCA() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.MqeXSgkURrlITajbbOSBTjoHZyCA() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.ExxDOAmagHRcREqfGZQurrWsFuDc() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.ExxDOAmagHRcREqfGZQurrWsFuDc() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.BdaHQfLkEvGBCUeozQWwIYuZHFar() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0f;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.BdaHQfLkEvGBCUeozQWwIYuZHFar() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MsemiDNvFwuvkRHSoRvueQDDCJHf();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MsemiDNvFwuvkRHSoRvueQDDCJHf();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MsemiDNvFwuvkRHSoRvueQDDCJHf();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MsemiDNvFwuvkRHSoRvueQDDCJHf();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.iARuJzhKfksmmefEbtjGLMIccAzj();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.iARuJzhKfksmmefEbtjGLMIccAzj();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.iARuJzhKfksmmefEbtjGLMIccAzj();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.iARuJzhKfksmmefEbtjGLMIccAzj();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.DeKBwydovtExYTMFfxXAMhbNoHGib();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.DeKBwydovtExYTMFfxXAMhbNoHGib();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.DeKBwydovtExYTMFfxXAMhbNoHGib();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.DeKBwydovtExYTMFfxXAMhbNoHGib();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MqeXSgkURrlITajbbOSBTjoHZyCA();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionName, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MqeXSgkURrlITajbbOSBTjoHZyCA();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, xAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.x = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MqeXSgkURrlITajbbOSBTjoHZyCA();
			}
			lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, yAxisActionId, true);
			if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2 != null)
			{
				result.y = lXvJAREcFJqTwbpbVaXyWnOsESQEA2.MqeXSgkURrlITajbbOSBTjoHZyCA();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.XiKxkUgGTtihtRtvqpcwOGOecMTd() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.XiKxkUgGTtihtRtvqpcwOGOecMTd() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.XuKFMGOoNSwfKUGeWhrwBSlRElRQ() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.XuKFMGOoNSwfKUGeWhrwBSlRElRQ() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.KElJOkInzYZLQVwltsxzlrlgwXtM() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.KElJOkInzYZLQVwltsxzlrlgwXtM() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.roHxuXfMZhsRBUAwHVnNJcpuOWDc() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return 0.0;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.roHxuXfMZhsRBUAwHVnNJcpuOWDc() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.LQaElQuMCTXqbYumMnzYmPARIRub() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.LQaElQuMCTXqbYumMnzYmPARIRub() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.vDulGhZlxqUzfkQBKWdlZKXfafgjA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.vDulGhZlxqUzfkQBKWdlZKXfafgjA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.FuQAMivUrksgreotkQRWeINQfpWi() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.FuQAMivUrksgreotkQRWeINQfpWi() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.bNxKzNquaqGmLwDjtddfJNBiYgOuA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return AxisCoordinateMode.Absolute;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.bNxKzNquaqGmLwDjtddfJNBiYgOuA() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.eBQtUYNynlYApWIXWJsWoIZiGIVd();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.eBQtUYNynlYApWIXWJsWoIZiGIVd();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.jFAgNigHnmLKAJcfKPxPNnXhxbjAA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.jFAgNigHnmLKAJcfKPxPNnXhxbjAA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.vjIfirZTXZjTihsQVnZfKGdMCzMO(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.vjIfirZTXZjTihsQVnZfKGdMCzMO(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.yLGNSfUwPfuUzLFYtyWCODvdszHP(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionName, true)?.mejgJWIJguAiMBDakeUrxDLpVBwLb(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return false;
			}
			return CRkeKMxiPDzGLacrcoQHokrPEViD.QHFuKKuEdmbuZhdfgZkffCESrqCA(hNoRiloMAZCwMJhqxCSNjcRIpGck, actionId, true)?.mejgJWIJguAiMBDakeUrxDLpVBwLb(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.aqgUnKWIiTAvsXXXJXLPGtXMGkmK(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.YzwDPDEulUeIbXAejJrihiSLIIBO(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return;
			}
			int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
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
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.CKQXkzqZatMhVaJsZoNfQAbaqqsL(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.HjNWYhELCEqeUuEgJHbjwxflDMDj(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return;
			}
			int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.GiFVsBvqhyrjWdkRKniMqBvidGbV(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.GWnNWYxKppAtezaHLImqIPwgxhAoA(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return;
			}
			int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.wwlztUdzlQzFjtCgvPmExbspBaPe(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.zYGimPQmaRBbmIhUQwXDpOcFrfAbb(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.XafEMybRlEZQvsFyfaDsUvIZusBd(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return;
			}
			int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.xxUnDwoscGdfClXhNaxYIyiPvCDP(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return;
			}
			int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.fhjiMNgrypbwMRCfnzuKOQfKvTzv(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.hOapnBVPvmJYrTZQBOxurcUDBdLv(hNoRiloMAZCwMJhqxCSNjcRIpGck, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				return;
			}
			int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
				{
					ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
				}
				else
				{
					CRkeKMxiPDzGLacrcoQHokrPEViD.HwflNHcrppPpGiGoEcxjzBosIwUh(hNoRiloMAZCwMJhqxCSNjcRIpGck);
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
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
			if (ReInput._id != LnvmXTENaYtFQvqmQFadBAomtywJ)
			{
				ReInput.CheckInitialized(LnvmXTENaYtFQvqmQFadBAomtywJ);
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

		internal void pyygxPYLYmsaiqzvtCnfTNjdktTv()
		{
			RsfKzYPMmToXTiWaVlAGZLcOAKECA();
		}

		private void RsfKzYPMmToXTiWaVlAGZLcOAKECA()
		{
			controllers.HZNhnhuVrtfIqixbObjqCXrCsMZn();
			SxGGPeNAccuoMPengZfvZmQBxhGE = false;
		}
	}
}
