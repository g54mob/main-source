using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class hesfhWHfQZHtTxgtLHbIXoaeqPqj : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int UAZmuuImHxrLjeFHWUXwtcPduJiU;

					private ElementAssignmentConflictInfo vttgBKMlDGyAXlKBhRCFstzveDCL;

					private int wYyNzhPkIMWzshfPthzkjdTBcIHbA;

					private int KSvOoJWmPXpYgCKwCldjZNtxfNRH;

					public int TaFFppGpvvlLFGphVdDrfAUVfzYEb;

					private CustomControllerMap GFKMwqahLlghEniqKcKebAtgxjZg;

					public CustomControllerMap mQfLqhDUNnyrFyqjKwchaJxcOTxC;

					public ConflictCheckingHelper FEnGmrwIaTtQgqQNMYqVMavMLFXd;

					private bool mcKrCPVADgeKiBjJwXekVLQiLipkA;

					public bool WWIzVHFHaCPrpzObisSXlFTmUqyh;

					private bool qZuZFQUMpChuZbwhGgzMLvAwaUZmA;

					public bool LRWvaeCenYhHIYvVoassREwYrfXV;

					private int jEjfmIzbPWWqphlFbYFmGjolhySFA;

					private IEnumerator<ElementAssignmentConflictInfo> zBtDqTAmAXJEEaGqqvXsDhfpqBST;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vttgBKMlDGyAXlKBhRCFstzveDCL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vttgBKMlDGyAXlKBhRCFstzveDCL;
						}
					}

					[DebuggerHidden]
					public hesfhWHfQZHtTxgtLHbIXoaeqPqj(int P_0)
					{
						UAZmuuImHxrLjeFHWUXwtcPduJiU = P_0;
						wYyNzhPkIMWzshfPthzkjdTBcIHbA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int uAZmuuImHxrLjeFHWUXwtcPduJiU = UAZmuuImHxrLjeFHWUXwtcPduJiU;
						if (uAZmuuImHxrLjeFHWUXwtcPduJiU == -3 || uAZmuuImHxrLjeFHWUXwtcPduJiU == 1)
						{
							try
							{
							}
							finally
							{
								SyGTYknZmyJwiiAWCjhcTufOUokN();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int uAZmuuImHxrLjeFHWUXwtcPduJiU = UAZmuuImHxrLjeFHWUXwtcPduJiU;
							ConflictCheckingHelper fEnGmrwIaTtQgqQNMYqVMavMLFXd = FEnGmrwIaTtQgqQNMYqVMavMLFXd;
							if (uAZmuuImHxrLjeFHWUXwtcPduJiU != 0)
							{
								if (uAZmuuImHxrLjeFHWUXwtcPduJiU != 1)
								{
									return false;
								}
								UAZmuuImHxrLjeFHWUXwtcPduJiU = -3;
								goto IL_00eb;
							}
							UAZmuuImHxrLjeFHWUXwtcPduJiU = -1;
							if (KSvOoJWmPXpYgCKwCldjZNtxfNRH < 0 || GFKMwqahLlghEniqKcKebAtgxjZg == null)
							{
								return false;
							}
							jEjfmIzbPWWqphlFbYFmGjolhySFA = 0;
							goto IL_0117;
							IL_00eb:
							if (zBtDqTAmAXJEEaGqqvXsDhfpqBST.MoveNext())
							{
								ElementAssignmentConflictInfo current = zBtDqTAmAXJEEaGqqvXsDhfpqBST.Current;
								vttgBKMlDGyAXlKBhRCFstzveDCL = current;
								UAZmuuImHxrLjeFHWUXwtcPduJiU = 1;
								return true;
							}
							SyGTYknZmyJwiiAWCjhcTufOUokN();
							zBtDqTAmAXJEEaGqqvXsDhfpqBST = null;
							goto IL_0105;
							IL_0117:
							if (jEjfmIzbPWWqphlFbYFmGjolhySFA < fEnGmrwIaTtQgqQNMYqVMavMLFXd.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA())
							{
								if (fEnGmrwIaTtQgqQNMYqVMavMLFXd.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(jEjfmIzbPWWqphlFbYFmGjolhySFA).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == KSvOoJWmPXpYgCKwCldjZNtxfNRH)
								{
									zBtDqTAmAXJEEaGqqvXsDhfpqBST = fEnGmrwIaTtQgqQNMYqVMavMLFXd.sEOAFNLzpEumWkPBYCLduPzcVAiC(ControllerType.Custom, KSvOoJWmPXpYgCKwCldjZNtxfNRH, GFKMwqahLlghEniqKcKebAtgxjZg, mcKrCPVADgeKiBjJwXekVLQiLipkA, qZuZFQUMpChuZbwhGgzMLvAwaUZmA, fEnGmrwIaTtQgqQNMYqVMavMLFXd.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(jEjfmIzbPWWqphlFbYFmGjolhySFA).HCqsUTYybVMCVwCYQIskQMgrlygr).GetEnumerator();
									UAZmuuImHxrLjeFHWUXwtcPduJiU = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							jEjfmIzbPWWqphlFbYFmGjolhySFA++;
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

					private void SyGTYknZmyJwiiAWCjhcTufOUokN()
					{
						UAZmuuImHxrLjeFHWUXwtcPduJiU = -1;
						if (zBtDqTAmAXJEEaGqqvXsDhfpqBST != null)
						{
							zBtDqTAmAXJEEaGqqvXsDhfpqBST.Dispose();
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
						hesfhWHfQZHtTxgtLHbIXoaeqPqj hesfhWHfQZHtTxgtLHbIXoaeqPqj2;
						if (UAZmuuImHxrLjeFHWUXwtcPduJiU == -2 && wYyNzhPkIMWzshfPthzkjdTBcIHbA == Environment.CurrentManagedThreadId)
						{
							UAZmuuImHxrLjeFHWUXwtcPduJiU = 0;
							hesfhWHfQZHtTxgtLHbIXoaeqPqj2 = this;
						}
						else
						{
							hesfhWHfQZHtTxgtLHbIXoaeqPqj2 = new hesfhWHfQZHtTxgtLHbIXoaeqPqj(0);
							hesfhWHfQZHtTxgtLHbIXoaeqPqj2.FEnGmrwIaTtQgqQNMYqVMavMLFXd = FEnGmrwIaTtQgqQNMYqVMavMLFXd;
						}
						hesfhWHfQZHtTxgtLHbIXoaeqPqj2.KSvOoJWmPXpYgCKwCldjZNtxfNRH = TaFFppGpvvlLFGphVdDrfAUVfzYEb;
						hesfhWHfQZHtTxgtLHbIXoaeqPqj2.GFKMwqahLlghEniqKcKebAtgxjZg = mQfLqhDUNnyrFyqjKwchaJxcOTxC;
						hesfhWHfQZHtTxgtLHbIXoaeqPqj2.mcKrCPVADgeKiBjJwXekVLQiLipkA = WWIzVHFHaCPrpzObisSXlFTmUqyh;
						hesfhWHfQZHtTxgtLHbIXoaeqPqj2.qZuZFQUMpChuZbwhGgzMLvAwaUZmA = LRWvaeCenYhHIYvVoassREwYrfXV;
						return hesfhWHfQZHtTxgtLHbIXoaeqPqj2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class bmBnyCXojvUSvVUENTJsriMorMrt : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int qwCGZBAoZncxonvnIDtmPUSrslmIA;

					private ElementAssignmentConflictInfo lVlmDWwBGRaeqVMpWNZzIdAtcHtK;

					private int sUJhDhubDrKFLHxxJjTRrHZSwuvI;

					private int bpjgFFHruynRySvvCydswbwGdmox;

					public int mFxqsxxhJregVhWBnihrlmGEJvpAb;

					private ActionElementMap moWQbsVLBYRyCFvkZRfMfaAzojiT;

					public ActionElementMap ZTnbvLuOfSFgIxEkBtftDApYNuJk;

					public ConflictCheckingHelper yzHlGRAILBJfWUkFLDnOFWmIhJYpA;

					private CustomControllerMap JtYCPTEEzlWKBVGdGeoJNVehOQRi;

					public CustomControllerMap HXIDDeabSfAGaNvNFbohhZXJAROW;

					private bool KbojQRZdHLcJHfmZeWPyGwPuzHxgA;

					public bool PoZkLrVStifHwLRIXrOEtHYHDGJq;

					private bool txsofAhnMLnSBWhzJgrIEVJdZoavA;

					public bool CoriKFfCUSdlaGycnIUyDSRHFPtMA;

					private int luDaPxAdWjfrJtrqgUUedHWOzUeDA;

					private IEnumerator<ElementAssignmentConflictInfo> hFnpabPgIOjPooPREcmiirrrTvzr;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return lVlmDWwBGRaeqVMpWNZzIdAtcHtK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lVlmDWwBGRaeqVMpWNZzIdAtcHtK;
						}
					}

					[DebuggerHidden]
					public bmBnyCXojvUSvVUENTJsriMorMrt(int P_0)
					{
						qwCGZBAoZncxonvnIDtmPUSrslmIA = P_0;
						sUJhDhubDrKFLHxxJjTRrHZSwuvI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qwCGZBAoZncxonvnIDtmPUSrslmIA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								BjTfUUGQAyHBQoHeTkpYbEqjrRSNB();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = qwCGZBAoZncxonvnIDtmPUSrslmIA;
							ConflictCheckingHelper conflictCheckingHelper = yzHlGRAILBJfWUkFLDnOFWmIhJYpA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qwCGZBAoZncxonvnIDtmPUSrslmIA = -3;
								goto IL_00f1;
							}
							qwCGZBAoZncxonvnIDtmPUSrslmIA = -1;
							if (bpjgFFHruynRySvvCydswbwGdmox < 0 || moWQbsVLBYRyCFvkZRfMfaAzojiT == null)
							{
								return false;
							}
							luDaPxAdWjfrJtrqgUUedHWOzUeDA = 0;
							goto IL_011d;
							IL_00f1:
							if (hFnpabPgIOjPooPREcmiirrrTvzr.MoveNext())
							{
								ElementAssignmentConflictInfo current = hFnpabPgIOjPooPREcmiirrrTvzr.Current;
								lVlmDWwBGRaeqVMpWNZzIdAtcHtK = current;
								qwCGZBAoZncxonvnIDtmPUSrslmIA = 1;
								return true;
							}
							BjTfUUGQAyHBQoHeTkpYbEqjrRSNB();
							hFnpabPgIOjPooPREcmiirrrTvzr = null;
							goto IL_010b;
							IL_011d:
							if (luDaPxAdWjfrJtrqgUUedHWOzUeDA < conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA())
							{
								if (conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(luDaPxAdWjfrJtrqgUUedHWOzUeDA).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == bpjgFFHruynRySvvCydswbwGdmox)
								{
									hFnpabPgIOjPooPREcmiirrrTvzr = conflictCheckingHelper.IiZKwJyWArPQuZvNEKPqwjpqdkegA(ControllerType.Custom, bpjgFFHruynRySvvCydswbwGdmox, JtYCPTEEzlWKBVGdGeoJNVehOQRi, moWQbsVLBYRyCFvkZRfMfaAzojiT, KbojQRZdHLcJHfmZeWPyGwPuzHxgA, txsofAhnMLnSBWhzJgrIEVJdZoavA, conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(luDaPxAdWjfrJtrqgUUedHWOzUeDA).HCqsUTYybVMCVwCYQIskQMgrlygr).GetEnumerator();
									qwCGZBAoZncxonvnIDtmPUSrslmIA = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							luDaPxAdWjfrJtrqgUUedHWOzUeDA++;
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

					private void BjTfUUGQAyHBQoHeTkpYbEqjrRSNB()
					{
						qwCGZBAoZncxonvnIDtmPUSrslmIA = -1;
						if (hFnpabPgIOjPooPREcmiirrrTvzr != null)
						{
							hFnpabPgIOjPooPREcmiirrrTvzr.Dispose();
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
						bmBnyCXojvUSvVUENTJsriMorMrt bmBnyCXojvUSvVUENTJsriMorMrt2;
						if (qwCGZBAoZncxonvnIDtmPUSrslmIA == -2 && sUJhDhubDrKFLHxxJjTRrHZSwuvI == Environment.CurrentManagedThreadId)
						{
							qwCGZBAoZncxonvnIDtmPUSrslmIA = 0;
							bmBnyCXojvUSvVUENTJsriMorMrt2 = this;
						}
						else
						{
							bmBnyCXojvUSvVUENTJsriMorMrt2 = new bmBnyCXojvUSvVUENTJsriMorMrt(0);
							bmBnyCXojvUSvVUENTJsriMorMrt2.yzHlGRAILBJfWUkFLDnOFWmIhJYpA = yzHlGRAILBJfWUkFLDnOFWmIhJYpA;
						}
						bmBnyCXojvUSvVUENTJsriMorMrt2.bpjgFFHruynRySvvCydswbwGdmox = mFxqsxxhJregVhWBnihrlmGEJvpAb;
						bmBnyCXojvUSvVUENTJsriMorMrt2.JtYCPTEEzlWKBVGdGeoJNVehOQRi = HXIDDeabSfAGaNvNFbohhZXJAROW;
						bmBnyCXojvUSvVUENTJsriMorMrt2.moWQbsVLBYRyCFvkZRfMfaAzojiT = ZTnbvLuOfSFgIxEkBtftDApYNuJk;
						bmBnyCXojvUSvVUENTJsriMorMrt2.KbojQRZdHLcJHfmZeWPyGwPuzHxgA = PoZkLrVStifHwLRIXrOEtHYHDGJq;
						bmBnyCXojvUSvVUENTJsriMorMrt2.txsofAhnMLnSBWhzJgrIEVJdZoavA = CoriKFfCUSdlaGycnIUyDSRHFPtMA;
						return bmBnyCXojvUSvVUENTJsriMorMrt2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class jYaEDWVxOvcqLnGVvmxOPVkVesTF : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int OKvFMyhCjXdaqrunTJvWuRENsxgFA;

					private ElementAssignmentConflictInfo lIvEdwIjPJKarEoYFusXKnkZtnXIB;

					private int buHeoVQxNiUtykydzTlDfNtArDkW;

					private ElementAssignmentConflictCheck AyhGMwExBoxpBbhdkOcCiBAbHIhGb;

					public ElementAssignmentConflictCheck SXdQCmsBBEIwSPenRlSYqMCkpzQB;

					public ConflictCheckingHelper jdgdQVRIfPKGVgcnZjBtVmwafo;

					private bool ndJyCvAIVJeRoKUyboMKIOhekhiAb;

					public bool CHBGvcnirZemmuhPgVmSvfaHOSrN;

					private bool IOblmlCwabqGegnvYDZAbphqGMIfA;

					public bool XlXyjxBKkgfkjvKxsnkMzJoEeYNY;

					private int CXsGGJxyqOqxowTjKpfueAHESKHH;

					private IEnumerator<ElementAssignmentConflictInfo> YIrqaUKbdGbIoKseqaxcGnVulGLr;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return lIvEdwIjPJKarEoYFusXKnkZtnXIB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lIvEdwIjPJKarEoYFusXKnkZtnXIB;
						}
					}

					[DebuggerHidden]
					public jYaEDWVxOvcqLnGVvmxOPVkVesTF(int P_0)
					{
						OKvFMyhCjXdaqrunTJvWuRENsxgFA = P_0;
						buHeoVQxNiUtykydzTlDfNtArDkW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int oKvFMyhCjXdaqrunTJvWuRENsxgFA = OKvFMyhCjXdaqrunTJvWuRENsxgFA;
						if (oKvFMyhCjXdaqrunTJvWuRENsxgFA == -3 || oKvFMyhCjXdaqrunTJvWuRENsxgFA == 1)
						{
							try
							{
							}
							finally
							{
								SkTtymqIVkwRcIbhnBXWOhsTchjy();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int oKvFMyhCjXdaqrunTJvWuRENsxgFA = OKvFMyhCjXdaqrunTJvWuRENsxgFA;
							ConflictCheckingHelper conflictCheckingHelper = jdgdQVRIfPKGVgcnZjBtVmwafo;
							if (oKvFMyhCjXdaqrunTJvWuRENsxgFA != 0)
							{
								if (oKvFMyhCjXdaqrunTJvWuRENsxgFA != 1)
								{
									return false;
								}
								OKvFMyhCjXdaqrunTJvWuRENsxgFA = -3;
								goto IL_00f3;
							}
							OKvFMyhCjXdaqrunTJvWuRENsxgFA = -1;
							if (AyhGMwExBoxpBbhdkOcCiBAbHIhGb.controllerId < 0 || AyhGMwExBoxpBbhdkOcCiBAbHIhGb.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							CXsGGJxyqOqxowTjKpfueAHESKHH = 0;
							goto IL_011f;
							IL_00f3:
							if (YIrqaUKbdGbIoKseqaxcGnVulGLr.MoveNext())
							{
								ElementAssignmentConflictInfo current = YIrqaUKbdGbIoKseqaxcGnVulGLr.Current;
								lIvEdwIjPJKarEoYFusXKnkZtnXIB = current;
								OKvFMyhCjXdaqrunTJvWuRENsxgFA = 1;
								return true;
							}
							SkTtymqIVkwRcIbhnBXWOhsTchjy();
							YIrqaUKbdGbIoKseqaxcGnVulGLr = null;
							goto IL_010d;
							IL_011f:
							if (CXsGGJxyqOqxowTjKpfueAHESKHH < conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA())
							{
								if (conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(CXsGGJxyqOqxowTjKpfueAHESKHH).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == AyhGMwExBoxpBbhdkOcCiBAbHIhGb.controllerId)
								{
									YIrqaUKbdGbIoKseqaxcGnVulGLr = conflictCheckingHelper.pIpKAGdBTEhEdjrYNTqNltYrbGQi(AyhGMwExBoxpBbhdkOcCiBAbHIhGb, ndJyCvAIVJeRoKUyboMKIOhekhiAb, IOblmlCwabqGegnvYDZAbphqGMIfA, conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(CXsGGJxyqOqxowTjKpfueAHESKHH).HCqsUTYybVMCVwCYQIskQMgrlygr).GetEnumerator();
									OKvFMyhCjXdaqrunTJvWuRENsxgFA = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							CXsGGJxyqOqxowTjKpfueAHESKHH++;
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

					private void SkTtymqIVkwRcIbhnBXWOhsTchjy()
					{
						OKvFMyhCjXdaqrunTJvWuRENsxgFA = -1;
						if (YIrqaUKbdGbIoKseqaxcGnVulGLr != null)
						{
							YIrqaUKbdGbIoKseqaxcGnVulGLr.Dispose();
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
						jYaEDWVxOvcqLnGVvmxOPVkVesTF jYaEDWVxOvcqLnGVvmxOPVkVesTF2;
						if (OKvFMyhCjXdaqrunTJvWuRENsxgFA == -2 && buHeoVQxNiUtykydzTlDfNtArDkW == Environment.CurrentManagedThreadId)
						{
							OKvFMyhCjXdaqrunTJvWuRENsxgFA = 0;
							jYaEDWVxOvcqLnGVvmxOPVkVesTF2 = this;
						}
						else
						{
							jYaEDWVxOvcqLnGVvmxOPVkVesTF2 = new jYaEDWVxOvcqLnGVvmxOPVkVesTF(0);
							jYaEDWVxOvcqLnGVvmxOPVkVesTF2.jdgdQVRIfPKGVgcnZjBtVmwafo = jdgdQVRIfPKGVgcnZjBtVmwafo;
						}
						jYaEDWVxOvcqLnGVvmxOPVkVesTF2.AyhGMwExBoxpBbhdkOcCiBAbHIhGb = SXdQCmsBBEIwSPenRlSYqMCkpzQB;
						jYaEDWVxOvcqLnGVvmxOPVkVesTF2.ndJyCvAIVJeRoKUyboMKIOhekhiAb = CHBGvcnirZemmuhPgVmSvfaHOSrN;
						jYaEDWVxOvcqLnGVvmxOPVkVesTF2.IOblmlCwabqGegnvYDZAbphqGMIfA = XlXyjxBKkgfkjvKxsnkMzJoEeYNY;
						return jYaEDWVxOvcqLnGVvmxOPVkVesTF2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class SsMaGtIRnCbdrIWLmJvTWOsJsZMM<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int hvIoDLsVPiOuyFVmbGUIqgfhmLDp;

					private ElementAssignmentConflictInfo ygZPBzNVwwJmPLEiEbSCQknAlLkU;

					private int YNybtLSzlfvDrAoRFepSnJjuiTgS;

					private global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> ysHgpAAAibKagzfBRKZyVyDiuUdKA;

					public global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> FPgCCxOWamIxVndYwTCqzWgEhuYJ;

					private _0001 BHMLmTcCkCcoJvRiejdedCllnrwTA;

					public _0001 wQCkCJqHGMRIVBlzjWLalJRMXxQB;

					private bool xGAzALiDYcdBhBwhpENUevRFcdYnb;

					public bool LPocTydYSPwnPhYhDXZAARtyCSGLA;

					private bool yugwYMSNrSSEWcnKNvFiwoBfGQYp;

					public bool SDvWCwYNrVFRXSCWnwPrtuiFxuDP;

					public ConflictCheckingHelper sYFOjtgLpbfrOgBxjMXvEyMmXUweA;

					private ControllerType XBuiPbJZcNvpGwCYUtiCRiWnrhxu;

					public ControllerType EEUgMEGWQarefCrpcVfZDfUfQYDhA;

					private int mxqjsrfLBaHPcHjPJfAqpExAaDoZA;

					public int dZOKiwBdGtIQOFlCFcadvZFhugBA;

					private InputMapCategory iBqyrwjCjOGnwatgIvHgFgwzVkFw;

					private int USveonxnfazFlcwipkjiwpJLxkbf;

					private IEnumerator<ElementAssignmentConflictInfo> hyhECoImiSTUkvgwxYWihQxcMTVv;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ygZPBzNVwwJmPLEiEbSCQknAlLkU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ygZPBzNVwwJmPLEiEbSCQknAlLkU;
						}
					}

					[DebuggerHidden]
					public SsMaGtIRnCbdrIWLmJvTWOsJsZMM(int P_0)
					{
						hvIoDLsVPiOuyFVmbGUIqgfhmLDp = P_0;
						YNybtLSzlfvDrAoRFepSnJjuiTgS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hvIoDLsVPiOuyFVmbGUIqgfhmLDp;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								LTylDJpOizAJZzKBcXupELMhEBHH();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hvIoDLsVPiOuyFVmbGUIqgfhmLDp;
							ConflictCheckingHelper conflictCheckingHelper = sYFOjtgLpbfrOgBxjMXvEyMmXUweA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hvIoDLsVPiOuyFVmbGUIqgfhmLDp = -3;
								goto IL_014a;
							}
							hvIoDLsVPiOuyFVmbGUIqgfhmLDp = -1;
							if (ysHgpAAAibKagzfBRKZyVyDiuUdKA == null || BHMLmTcCkCcoJvRiejdedCllnrwTA == null)
							{
								return false;
							}
							iBqyrwjCjOGnwatgIvHgFgwzVkFw = ReInput.mapping.GetMapCategory(BHMLmTcCkCcoJvRiejdedCllnrwTA.categoryId);
							if (iBqyrwjCjOGnwatgIvHgFgwzVkFw == null)
							{
								return false;
							}
							USveonxnfazFlcwipkjiwpJLxkbf = 0;
							goto IL_0176;
							IL_0176:
							if (USveonxnfazFlcwipkjiwpJLxkbf < ysHgpAAAibKagzfBRKZyVyDiuUdKA.RaeomPUMtcefLDSAzqHUlBVAPqHO())
							{
								ControllerMap controllerMap = ysHgpAAAibKagzfBRKZyVyDiuUdKA.ShwbZGTrLUidtHoOuNTxBfnGibOXb(USveonxnfazFlcwipkjiwpJLxkbf);
								if ((!xGAzALiDYcdBhBwhpENUevRFcdYnb || controllerMap.enabled) && (yugwYMSNrSSEWcnKNvFiwoBfGQYp || !conflictCheckingHelper.MwknJNHEbiTReBtRwLeFnhscBjJGA(iBqyrwjCjOGnwatgIvHgFgwzVkFw, controllerMap)))
								{
									hyhECoImiSTUkvgwxYWihQxcMTVv = controllerMap.ElementAssignmentConflicts(BHMLmTcCkCcoJvRiejdedCllnrwTA, xGAzALiDYcdBhBwhpENUevRFcdYnb).GetEnumerator();
									hvIoDLsVPiOuyFVmbGUIqgfhmLDp = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (hyhECoImiSTUkvgwxYWihQxcMTVv.MoveNext())
							{
								ElementAssignmentConflictInfo current = hyhECoImiSTUkvgwxYWihQxcMTVv.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.uMYADhiMneGWyAejQgJejScskHph.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								elementAssignmentConflictInfo.controllerType = XBuiPbJZcNvpGwCYUtiCRiWnrhxu;
								elementAssignmentConflictInfo.controllerId = mxqjsrfLBaHPcHjPJfAqpExAaDoZA;
								ygZPBzNVwwJmPLEiEbSCQknAlLkU = elementAssignmentConflictInfo;
								hvIoDLsVPiOuyFVmbGUIqgfhmLDp = 1;
								return true;
							}
							LTylDJpOizAJZzKBcXupELMhEBHH();
							hyhECoImiSTUkvgwxYWihQxcMTVv = null;
							goto IL_0164;
							IL_0164:
							USveonxnfazFlcwipkjiwpJLxkbf++;
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

					private void LTylDJpOizAJZzKBcXupELMhEBHH()
					{
						hvIoDLsVPiOuyFVmbGUIqgfhmLDp = -1;
						if (hyhECoImiSTUkvgwxYWihQxcMTVv != null)
						{
							hyhECoImiSTUkvgwxYWihQxcMTVv.Dispose();
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
						SsMaGtIRnCbdrIWLmJvTWOsJsZMM<_0001> ssMaGtIRnCbdrIWLmJvTWOsJsZMM;
						if (hvIoDLsVPiOuyFVmbGUIqgfhmLDp == -2 && YNybtLSzlfvDrAoRFepSnJjuiTgS == Environment.CurrentManagedThreadId)
						{
							hvIoDLsVPiOuyFVmbGUIqgfhmLDp = 0;
							ssMaGtIRnCbdrIWLmJvTWOsJsZMM = this;
						}
						else
						{
							ssMaGtIRnCbdrIWLmJvTWOsJsZMM = new SsMaGtIRnCbdrIWLmJvTWOsJsZMM<_0001>(0);
							ssMaGtIRnCbdrIWLmJvTWOsJsZMM.sYFOjtgLpbfrOgBxjMXvEyMmXUweA = sYFOjtgLpbfrOgBxjMXvEyMmXUweA;
						}
						ssMaGtIRnCbdrIWLmJvTWOsJsZMM.XBuiPbJZcNvpGwCYUtiCRiWnrhxu = EEUgMEGWQarefCrpcVfZDfUfQYDhA;
						ssMaGtIRnCbdrIWLmJvTWOsJsZMM.mxqjsrfLBaHPcHjPJfAqpExAaDoZA = dZOKiwBdGtIQOFlCFcadvZFhugBA;
						ssMaGtIRnCbdrIWLmJvTWOsJsZMM.BHMLmTcCkCcoJvRiejdedCllnrwTA = wQCkCJqHGMRIVBlzjWLalJRMXxQB;
						ssMaGtIRnCbdrIWLmJvTWOsJsZMM.xGAzALiDYcdBhBwhpENUevRFcdYnb = LPocTydYSPwnPhYhDXZAARtyCSGLA;
						ssMaGtIRnCbdrIWLmJvTWOsJsZMM.yugwYMSNrSSEWcnKNvFiwoBfGQYp = SDvWCwYNrVFRXSCWnwPrtuiFxuDP;
						ssMaGtIRnCbdrIWLmJvTWOsJsZMM.ysHgpAAAibKagzfBRKZyVyDiuUdKA = FPgCCxOWamIxVndYwTCqzWgEhuYJ;
						return ssMaGtIRnCbdrIWLmJvTWOsJsZMM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class fcMfFDfYVsLOEUTdnoPkjpdBnnecA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int YdjDOYBHqaibqmYxMDLiaYWDIWhtB;

					private ElementAssignmentConflictInfo HbyeUvVrkNeaDGNnWTeHhMpvJdZH;

					private int AXuZJzcVkNUVTLFgwmgJOAjOtHcx;

					private global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> oUkKJJPYnISdEoSqRCfHsFiOdRoX;

					public global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> bMBaDheGNgvIgsocNGckkFetqyKR;

					private ActionElementMap AZJcASIpPAdMOCjtsbqTBzMDehZeA;

					public ActionElementMap mRpvIaqHVRUwqpgNRWRFmOJxthjP;

					private _0001 egrDByEOXXYHcKnWJYTzfRynnXWfA;

					public _0001 yYpUnABbviuTzVwdzDhclMqWDnDdA;

					private bool nlyCcNheZmGAkKNvxWtubWOrYkOl;

					public bool KDqLOEvtgqqycLkqjkZsfUVAJjL;

					private bool pszAwRPEMGUJeTEclYbMRjyXjoHm;

					public bool lYGGxlLmWYsHvjpEWoXLxuEeJBxr;

					public ConflictCheckingHelper XNkVLvjyMOZnhXCBKIsceRIYzMuG;

					private ControllerType jxXmPABBTICWedSJYUQwrlzsiblD;

					public ControllerType FGzaPMjMuqHdIlTMchghDadmzpGuA;

					private int AnacJSispsMWYQaUPqzzJFgEIkhh;

					public int FOGdRhbjlVGxthOEWWmjFcSOPgVg;

					private InputMapCategory iexKUhnMHFNCMGKMlShtJTikLdOW;

					private int faIZsFIcDLVmRNWgfuvjEIdhPBwx;

					private IEnumerator<ElementAssignmentConflictInfo> zoQnpJtLANuqEWcBboIOCdAWodZi;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HbyeUvVrkNeaDGNnWTeHhMpvJdZH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HbyeUvVrkNeaDGNnWTeHhMpvJdZH;
						}
					}

					[DebuggerHidden]
					public fcMfFDfYVsLOEUTdnoPkjpdBnnecA(int P_0)
					{
						YdjDOYBHqaibqmYxMDLiaYWDIWhtB = P_0;
						AXuZJzcVkNUVTLFgwmgJOAjOtHcx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ydjDOYBHqaibqmYxMDLiaYWDIWhtB = YdjDOYBHqaibqmYxMDLiaYWDIWhtB;
						if (ydjDOYBHqaibqmYxMDLiaYWDIWhtB == -3 || ydjDOYBHqaibqmYxMDLiaYWDIWhtB == 1)
						{
							try
							{
							}
							finally
							{
								dipbakBRFHzZVMdziPRVuVzmlbcR();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ydjDOYBHqaibqmYxMDLiaYWDIWhtB = YdjDOYBHqaibqmYxMDLiaYWDIWhtB;
							ConflictCheckingHelper xNkVLvjyMOZnhXCBKIsceRIYzMuG = XNkVLvjyMOZnhXCBKIsceRIYzMuG;
							if (ydjDOYBHqaibqmYxMDLiaYWDIWhtB != 0)
							{
								if (ydjDOYBHqaibqmYxMDLiaYWDIWhtB != 1)
								{
									return false;
								}
								YdjDOYBHqaibqmYxMDLiaYWDIWhtB = -3;
								goto IL_0141;
							}
							YdjDOYBHqaibqmYxMDLiaYWDIWhtB = -1;
							if (oUkKJJPYnISdEoSqRCfHsFiOdRoX == null || AZJcASIpPAdMOCjtsbqTBzMDehZeA == null)
							{
								return false;
							}
							iexKUhnMHFNCMGKMlShtJTikLdOW = ((egrDByEOXXYHcKnWJYTzfRynnXWfA != null) ? ReInput.mapping.GetMapCategory(egrDByEOXXYHcKnWJYTzfRynnXWfA.categoryId) : null);
							faIZsFIcDLVmRNWgfuvjEIdhPBwx = 0;
							goto IL_016d;
							IL_016d:
							if (faIZsFIcDLVmRNWgfuvjEIdhPBwx < oUkKJJPYnISdEoSqRCfHsFiOdRoX.RaeomPUMtcefLDSAzqHUlBVAPqHO())
							{
								ControllerMap controllerMap = oUkKJJPYnISdEoSqRCfHsFiOdRoX.ShwbZGTrLUidtHoOuNTxBfnGibOXb(faIZsFIcDLVmRNWgfuvjEIdhPBwx);
								if ((!nlyCcNheZmGAkKNvxWtubWOrYkOl || controllerMap.enabled) && (pszAwRPEMGUJeTEclYbMRjyXjoHm || !xNkVLvjyMOZnhXCBKIsceRIYzMuG.MwknJNHEbiTReBtRwLeFnhscBjJGA(iexKUhnMHFNCMGKMlShtJTikLdOW, controllerMap)))
								{
									zoQnpJtLANuqEWcBboIOCdAWodZi = controllerMap.ElementAssignmentConflicts(AZJcASIpPAdMOCjtsbqTBzMDehZeA, nlyCcNheZmGAkKNvxWtubWOrYkOl).GetEnumerator();
									YdjDOYBHqaibqmYxMDLiaYWDIWhtB = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							faIZsFIcDLVmRNWgfuvjEIdhPBwx++;
							goto IL_016d;
							IL_0141:
							if (zoQnpJtLANuqEWcBboIOCdAWodZi.MoveNext())
							{
								ElementAssignmentConflictInfo current = zoQnpJtLANuqEWcBboIOCdAWodZi.Current;
								ElementAssignmentConflictInfo hbyeUvVrkNeaDGNnWTeHhMpvJdZH = new ElementAssignmentConflictInfo(current);
								hbyeUvVrkNeaDGNnWTeHhMpvJdZH.playerId = xNkVLvjyMOZnhXCBKIsceRIYzMuG.uMYADhiMneGWyAejQgJejScskHph.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								hbyeUvVrkNeaDGNnWTeHhMpvJdZH.controllerType = jxXmPABBTICWedSJYUQwrlzsiblD;
								hbyeUvVrkNeaDGNnWTeHhMpvJdZH.controllerId = AnacJSispsMWYQaUPqzzJFgEIkhh;
								HbyeUvVrkNeaDGNnWTeHhMpvJdZH = hbyeUvVrkNeaDGNnWTeHhMpvJdZH;
								YdjDOYBHqaibqmYxMDLiaYWDIWhtB = 1;
								return true;
							}
							dipbakBRFHzZVMdziPRVuVzmlbcR();
							zoQnpJtLANuqEWcBboIOCdAWodZi = null;
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

					private void dipbakBRFHzZVMdziPRVuVzmlbcR()
					{
						YdjDOYBHqaibqmYxMDLiaYWDIWhtB = -1;
						if (zoQnpJtLANuqEWcBboIOCdAWodZi != null)
						{
							zoQnpJtLANuqEWcBboIOCdAWodZi.Dispose();
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
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA<_0001> fcMfFDfYVsLOEUTdnoPkjpdBnnecA2;
						if (YdjDOYBHqaibqmYxMDLiaYWDIWhtB == -2 && AXuZJzcVkNUVTLFgwmgJOAjOtHcx == Environment.CurrentManagedThreadId)
						{
							YdjDOYBHqaibqmYxMDLiaYWDIWhtB = 0;
							fcMfFDfYVsLOEUTdnoPkjpdBnnecA2 = this;
						}
						else
						{
							fcMfFDfYVsLOEUTdnoPkjpdBnnecA2 = new fcMfFDfYVsLOEUTdnoPkjpdBnnecA<_0001>(0);
							fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.XNkVLvjyMOZnhXCBKIsceRIYzMuG = XNkVLvjyMOZnhXCBKIsceRIYzMuG;
						}
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.jxXmPABBTICWedSJYUQwrlzsiblD = FGzaPMjMuqHdIlTMchghDadmzpGuA;
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.AnacJSispsMWYQaUPqzzJFgEIkhh = FOGdRhbjlVGxthOEWWmjFcSOPgVg;
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.egrDByEOXXYHcKnWJYTzfRynnXWfA = yYpUnABbviuTzVwdzDhclMqWDnDdA;
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.AZJcASIpPAdMOCjtsbqTBzMDehZeA = mRpvIaqHVRUwqpgNRWRFmOJxthjP;
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.nlyCcNheZmGAkKNvxWtubWOrYkOl = KDqLOEvtgqqycLkqjkZsfUVAJjL;
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.pszAwRPEMGUJeTEclYbMRjyXjoHm = lYGGxlLmWYsHvjpEWoXLxuEeJBxr;
						fcMfFDfYVsLOEUTdnoPkjpdBnnecA2.oUkKJJPYnISdEoSqRCfHsFiOdRoX = bMBaDheGNgvIgsocNGckkFetqyKR;
						return fcMfFDfYVsLOEUTdnoPkjpdBnnecA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class OvKChzFHQLdNNduVdzOlOiVCOMIKA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int qfgJDfeOhOVuUFaxsakOIWfQHUsLA;

					private ElementAssignmentConflictInfo RyueizicNTpDrliCrczkJNbXBECU;

					private int XzQKFxsofixxioyOdnFZTbxoAIVT;

					private global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> ExaVnLSrMaSRgFFiFHUxvJxQTjcB;

					public global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> tuddJXpcOwRzekQwYDzzALCpFWtJ;

					private ElementAssignmentConflictCheck tcBbSqxTSLNyxeNJkfOQEGsdHehq;

					public ElementAssignmentConflictCheck veaCaZPMZdvPVGLhJohkOdpehGnb;

					private bool VmaRamyvpJleeBSDhHApFrcOGRme;

					public bool AVjUyOfBZEzbLtEEpoTNnfdGTGEQ;

					private bool EXjZYfcchIgMjuSoxDfxgJWNplnEA;

					public bool gihwvwhyAsaVHsQBqTUhTVTHNBEv;

					public ConflictCheckingHelper ENPJrypllGhiURFdDKTSRKGpBvWHA;

					private InputMapCategory bSePqWXTvFnacebFhWALQDZzJqqM;

					private int fGMASUXDPIHhmIkNIrZvJAwATFGm;

					private IEnumerator<ElementAssignmentConflictInfo> iEROGkUdJeAzjfGGYNmtmROjrmuNA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RyueizicNTpDrliCrczkJNbXBECU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RyueizicNTpDrliCrczkJNbXBECU;
						}
					}

					[DebuggerHidden]
					public OvKChzFHQLdNNduVdzOlOiVCOMIKA(int P_0)
					{
						qfgJDfeOhOVuUFaxsakOIWfQHUsLA = P_0;
						XzQKFxsofixxioyOdnFZTbxoAIVT = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qfgJDfeOhOVuUFaxsakOIWfQHUsLA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								NvgPFIbnVXgqsYQQZtIDGfFHKgUV();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = qfgJDfeOhOVuUFaxsakOIWfQHUsLA;
							ConflictCheckingHelper eNPJrypllGhiURFdDKTSRKGpBvWHA = ENPJrypllGhiURFdDKTSRKGpBvWHA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qfgJDfeOhOVuUFaxsakOIWfQHUsLA = -3;
								goto IL_01ab;
							}
							qfgJDfeOhOVuUFaxsakOIWfQHUsLA = -1;
							if (ExaVnLSrMaSRgFFiFHUxvJxQTjcB == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(tcBbSqxTSLNyxeNJkfOQEGsdHehq.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(tcBbSqxTSLNyxeNJkfOQEGsdHehq.controllerType, tcBbSqxTSLNyxeNJkfOQEGsdHehq.controllerId, tcBbSqxTSLNyxeNJkfOQEGsdHehq.controllerMapId);
							bSePqWXTvFnacebFhWALQDZzJqqM = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(tcBbSqxTSLNyxeNJkfOQEGsdHehq.controllerMapCategoryId));
							if (bSePqWXTvFnacebFhWALQDZzJqqM == null)
							{
								return false;
							}
							fGMASUXDPIHhmIkNIrZvJAwATFGm = 0;
							goto IL_01d7;
							IL_01ab:
							if (iEROGkUdJeAzjfGGYNmtmROjrmuNA.MoveNext())
							{
								ElementAssignmentConflictInfo current = iEROGkUdJeAzjfGGYNmtmROjrmuNA.Current;
								ElementAssignmentConflictInfo ryueizicNTpDrliCrczkJNbXBECU = new ElementAssignmentConflictInfo(current);
								ryueizicNTpDrliCrczkJNbXBECU.playerId = eNPJrypllGhiURFdDKTSRKGpBvWHA.uMYADhiMneGWyAejQgJejScskHph.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								ryueizicNTpDrliCrczkJNbXBECU.controllerType = tcBbSqxTSLNyxeNJkfOQEGsdHehq.controllerType;
								ryueizicNTpDrliCrczkJNbXBECU.controllerId = tcBbSqxTSLNyxeNJkfOQEGsdHehq.controllerId;
								RyueizicNTpDrliCrczkJNbXBECU = ryueizicNTpDrliCrczkJNbXBECU;
								qfgJDfeOhOVuUFaxsakOIWfQHUsLA = 1;
								return true;
							}
							NvgPFIbnVXgqsYQQZtIDGfFHKgUV();
							iEROGkUdJeAzjfGGYNmtmROjrmuNA = null;
							goto IL_01c5;
							IL_01d7:
							if (fGMASUXDPIHhmIkNIrZvJAwATFGm < ExaVnLSrMaSRgFFiFHUxvJxQTjcB.RaeomPUMtcefLDSAzqHUlBVAPqHO())
							{
								ControllerMap controllerMap = ExaVnLSrMaSRgFFiFHUxvJxQTjcB.ShwbZGTrLUidtHoOuNTxBfnGibOXb(fGMASUXDPIHhmIkNIrZvJAwATFGm);
								if ((!VmaRamyvpJleeBSDhHApFrcOGRme || controllerMap.enabled) && (EXjZYfcchIgMjuSoxDfxgJWNplnEA || !eNPJrypllGhiURFdDKTSRKGpBvWHA.MwknJNHEbiTReBtRwLeFnhscBjJGA(bSePqWXTvFnacebFhWALQDZzJqqM, controllerMap)))
								{
									iEROGkUdJeAzjfGGYNmtmROjrmuNA = controllerMap.ElementAssignmentConflicts(tcBbSqxTSLNyxeNJkfOQEGsdHehq, VmaRamyvpJleeBSDhHApFrcOGRme).GetEnumerator();
									qfgJDfeOhOVuUFaxsakOIWfQHUsLA = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							fGMASUXDPIHhmIkNIrZvJAwATFGm++;
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

					private void NvgPFIbnVXgqsYQQZtIDGfFHKgUV()
					{
						qfgJDfeOhOVuUFaxsakOIWfQHUsLA = -1;
						if (iEROGkUdJeAzjfGGYNmtmROjrmuNA != null)
						{
							iEROGkUdJeAzjfGGYNmtmROjrmuNA.Dispose();
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
						OvKChzFHQLdNNduVdzOlOiVCOMIKA<_0001> ovKChzFHQLdNNduVdzOlOiVCOMIKA;
						if (qfgJDfeOhOVuUFaxsakOIWfQHUsLA == -2 && XzQKFxsofixxioyOdnFZTbxoAIVT == Environment.CurrentManagedThreadId)
						{
							qfgJDfeOhOVuUFaxsakOIWfQHUsLA = 0;
							ovKChzFHQLdNNduVdzOlOiVCOMIKA = this;
						}
						else
						{
							ovKChzFHQLdNNduVdzOlOiVCOMIKA = new OvKChzFHQLdNNduVdzOlOiVCOMIKA<_0001>(0);
							ovKChzFHQLdNNduVdzOlOiVCOMIKA.ENPJrypllGhiURFdDKTSRKGpBvWHA = ENPJrypllGhiURFdDKTSRKGpBvWHA;
						}
						ovKChzFHQLdNNduVdzOlOiVCOMIKA.tcBbSqxTSLNyxeNJkfOQEGsdHehq = veaCaZPMZdvPVGLhJohkOdpehGnb;
						ovKChzFHQLdNNduVdzOlOiVCOMIKA.VmaRamyvpJleeBSDhHApFrcOGRme = AVjUyOfBZEzbLtEEpoTNnfdGTGEQ;
						ovKChzFHQLdNNduVdzOlOiVCOMIKA.EXjZYfcchIgMjuSoxDfxgJWNplnEA = gihwvwhyAsaVHsQBqTUhTVTHNBEv;
						ovKChzFHQLdNNduVdzOlOiVCOMIKA.ExaVnLSrMaSRgFFiFHUxvJxQTjcB = tuddJXpcOwRzekQwYDzzALCpFWtJ;
						return ovKChzFHQLdNNduVdzOlOiVCOMIKA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class RvxgSObThmqCXYazTusHOqXyNLJI : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int DnAhenIlwGtYXUBRkjMlXLmglaFi;

					private ElementAssignmentConflictInfo xPecidKWtYYOVUpaFJjLuAdpAKWFA;

					private int DeuehPYjnoPPtGBeZHHbiWvWKxjZ;

					private int zKgNygfiMoAMOIdJKbrVdmmmOWoI;

					public int soISgsIIUNKwLuPTmBdhIEDrxXok;

					private JoystickMap BknjeDPAiEEQDGTIOrYMoTTDaBtCb;

					public JoystickMap zsqGoHFxJyOhIBPxdtxrbVheoOaS;

					public ConflictCheckingHelper CGkBBJgOaJmxDdtVHmufYKnWrFSpb;

					private bool mCZOfwqaQuvFozDlNYAWucGzKLIh;

					public bool OUSJUNpWKOwJEuNYJEdpJiryIoSN;

					private bool xEueZrikNrQdIvncDVawfRjjqWvwA;

					public bool ViDSiqhKNfmGVjVwZqgVizlgalVu;

					private int rhpeTrKVwyyFJtSYiRTCbDindLXaA;

					private IEnumerator<ElementAssignmentConflictInfo> sDhNRGrahBNZrUEURMcRtEFLbAut;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return xPecidKWtYYOVUpaFJjLuAdpAKWFA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xPecidKWtYYOVUpaFJjLuAdpAKWFA;
						}
					}

					[DebuggerHidden]
					public RvxgSObThmqCXYazTusHOqXyNLJI(int P_0)
					{
						DnAhenIlwGtYXUBRkjMlXLmglaFi = P_0;
						DeuehPYjnoPPtGBeZHHbiWvWKxjZ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dnAhenIlwGtYXUBRkjMlXLmglaFi = DnAhenIlwGtYXUBRkjMlXLmglaFi;
						if (dnAhenIlwGtYXUBRkjMlXLmglaFi == -3 || dnAhenIlwGtYXUBRkjMlXLmglaFi == 1)
						{
							try
							{
							}
							finally
							{
								SNmkwldNVYLxjSasdqbINbfgGOCK();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int dnAhenIlwGtYXUBRkjMlXLmglaFi = DnAhenIlwGtYXUBRkjMlXLmglaFi;
							ConflictCheckingHelper cGkBBJgOaJmxDdtVHmufYKnWrFSpb = CGkBBJgOaJmxDdtVHmufYKnWrFSpb;
							if (dnAhenIlwGtYXUBRkjMlXLmglaFi != 0)
							{
								if (dnAhenIlwGtYXUBRkjMlXLmglaFi != 1)
								{
									return false;
								}
								DnAhenIlwGtYXUBRkjMlXLmglaFi = -3;
								goto IL_00ea;
							}
							DnAhenIlwGtYXUBRkjMlXLmglaFi = -1;
							if (zKgNygfiMoAMOIdJKbrVdmmmOWoI < 0 || BknjeDPAiEEQDGTIOrYMoTTDaBtCb == null)
							{
								return false;
							}
							rhpeTrKVwyyFJtSYiRTCbDindLXaA = 0;
							goto IL_0116;
							IL_00ea:
							if (sDhNRGrahBNZrUEURMcRtEFLbAut.MoveNext())
							{
								ElementAssignmentConflictInfo current = sDhNRGrahBNZrUEURMcRtEFLbAut.Current;
								xPecidKWtYYOVUpaFJjLuAdpAKWFA = current;
								DnAhenIlwGtYXUBRkjMlXLmglaFi = 1;
								return true;
							}
							SNmkwldNVYLxjSasdqbINbfgGOCK();
							sDhNRGrahBNZrUEURMcRtEFLbAut = null;
							goto IL_0104;
							IL_0116:
							if (rhpeTrKVwyyFJtSYiRTCbDindLXaA < cGkBBJgOaJmxDdtVHmufYKnWrFSpb.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA())
							{
								if (cGkBBJgOaJmxDdtVHmufYKnWrFSpb.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(rhpeTrKVwyyFJtSYiRTCbDindLXaA).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == zKgNygfiMoAMOIdJKbrVdmmmOWoI)
								{
									sDhNRGrahBNZrUEURMcRtEFLbAut = cGkBBJgOaJmxDdtVHmufYKnWrFSpb.sEOAFNLzpEumWkPBYCLduPzcVAiC(ControllerType.Joystick, zKgNygfiMoAMOIdJKbrVdmmmOWoI, BknjeDPAiEEQDGTIOrYMoTTDaBtCb, mCZOfwqaQuvFozDlNYAWucGzKLIh, xEueZrikNrQdIvncDVawfRjjqWvwA, cGkBBJgOaJmxDdtVHmufYKnWrFSpb.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(rhpeTrKVwyyFJtSYiRTCbDindLXaA).HCqsUTYybVMCVwCYQIskQMgrlygr).GetEnumerator();
									DnAhenIlwGtYXUBRkjMlXLmglaFi = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							rhpeTrKVwyyFJtSYiRTCbDindLXaA++;
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

					private void SNmkwldNVYLxjSasdqbINbfgGOCK()
					{
						DnAhenIlwGtYXUBRkjMlXLmglaFi = -1;
						if (sDhNRGrahBNZrUEURMcRtEFLbAut != null)
						{
							sDhNRGrahBNZrUEURMcRtEFLbAut.Dispose();
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
						RvxgSObThmqCXYazTusHOqXyNLJI rvxgSObThmqCXYazTusHOqXyNLJI;
						if (DnAhenIlwGtYXUBRkjMlXLmglaFi == -2 && DeuehPYjnoPPtGBeZHHbiWvWKxjZ == Environment.CurrentManagedThreadId)
						{
							DnAhenIlwGtYXUBRkjMlXLmglaFi = 0;
							rvxgSObThmqCXYazTusHOqXyNLJI = this;
						}
						else
						{
							rvxgSObThmqCXYazTusHOqXyNLJI = new RvxgSObThmqCXYazTusHOqXyNLJI(0);
							rvxgSObThmqCXYazTusHOqXyNLJI.CGkBBJgOaJmxDdtVHmufYKnWrFSpb = CGkBBJgOaJmxDdtVHmufYKnWrFSpb;
						}
						rvxgSObThmqCXYazTusHOqXyNLJI.zKgNygfiMoAMOIdJKbrVdmmmOWoI = soISgsIIUNKwLuPTmBdhIEDrxXok;
						rvxgSObThmqCXYazTusHOqXyNLJI.BknjeDPAiEEQDGTIOrYMoTTDaBtCb = zsqGoHFxJyOhIBPxdtxrbVheoOaS;
						rvxgSObThmqCXYazTusHOqXyNLJI.mCZOfwqaQuvFozDlNYAWucGzKLIh = OUSJUNpWKOwJEuNYJEdpJiryIoSN;
						rvxgSObThmqCXYazTusHOqXyNLJI.xEueZrikNrQdIvncDVawfRjjqWvwA = ViDSiqhKNfmGVjVwZqgVizlgalVu;
						return rvxgSObThmqCXYazTusHOqXyNLJI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class TkFJvPqyqSBXwJHKAQWwVrByuWBH : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int dJictrGyiCeuHgfFDemDYeRnJGVWB;

					private ElementAssignmentConflictInfo ytWcXsGFGtknVddZpkOzedueZSsQB;

					private int OhQAtoicQiMZjUvZiNCpYemyzmGNA;

					private int iRVCHWgihWIJcXXmMFSqKuoPLnAe;

					public int CcGFDVEMEBRqlHRHFUbAVcXnWmDl;

					private ActionElementMap EmTCFMkVTlXKOQiCqAGoZjiCBiXg;

					public ActionElementMap icLkKleTznVFTqWdrEAJftkxxCPd;

					public ConflictCheckingHelper pEjBdMoDnlaYNAKWBRwahwjftmDP;

					private JoystickMap MPKfkoQyvQhGXsXscrbjQAGYUOFJ;

					public JoystickMap sGhXdzULbGvKwULPOBoISiYGfiVJA;

					private bool ZpfnCyBYHfzEqnxuJyLBaeHEQVbd;

					public bool qBcezGfVgVcqHPDZEAjxQiTtSLZDA;

					private bool zwwoYOqFgCoAMDXILjeqPIvUZyUo;

					public bool liSyRWqbdongpcGwgrtYKifrQXjN;

					private int KCnhuGqaEDWhPvtaErhbdymoPUGq;

					private IEnumerator<ElementAssignmentConflictInfo> QTsWbNEWuwDDFhJjkaraswXQfoWo;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ytWcXsGFGtknVddZpkOzedueZSsQB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ytWcXsGFGtknVddZpkOzedueZSsQB;
						}
					}

					[DebuggerHidden]
					public TkFJvPqyqSBXwJHKAQWwVrByuWBH(int P_0)
					{
						dJictrGyiCeuHgfFDemDYeRnJGVWB = P_0;
						OhQAtoicQiMZjUvZiNCpYemyzmGNA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dJictrGyiCeuHgfFDemDYeRnJGVWB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								EKwtMilkoeuDnyAbYhQxJrwTrgVqA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = dJictrGyiCeuHgfFDemDYeRnJGVWB;
							ConflictCheckingHelper conflictCheckingHelper = pEjBdMoDnlaYNAKWBRwahwjftmDP;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dJictrGyiCeuHgfFDemDYeRnJGVWB = -3;
								goto IL_00f0;
							}
							dJictrGyiCeuHgfFDemDYeRnJGVWB = -1;
							if (iRVCHWgihWIJcXXmMFSqKuoPLnAe < 0 || EmTCFMkVTlXKOQiCqAGoZjiCBiXg == null)
							{
								return false;
							}
							KCnhuGqaEDWhPvtaErhbdymoPUGq = 0;
							goto IL_011c;
							IL_00f0:
							if (QTsWbNEWuwDDFhJjkaraswXQfoWo.MoveNext())
							{
								ElementAssignmentConflictInfo current = QTsWbNEWuwDDFhJjkaraswXQfoWo.Current;
								ytWcXsGFGtknVddZpkOzedueZSsQB = current;
								dJictrGyiCeuHgfFDemDYeRnJGVWB = 1;
								return true;
							}
							EKwtMilkoeuDnyAbYhQxJrwTrgVqA();
							QTsWbNEWuwDDFhJjkaraswXQfoWo = null;
							goto IL_010a;
							IL_011c:
							if (KCnhuGqaEDWhPvtaErhbdymoPUGq < conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA())
							{
								if (conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(KCnhuGqaEDWhPvtaErhbdymoPUGq).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == iRVCHWgihWIJcXXmMFSqKuoPLnAe)
								{
									QTsWbNEWuwDDFhJjkaraswXQfoWo = conflictCheckingHelper.IiZKwJyWArPQuZvNEKPqwjpqdkegA(ControllerType.Joystick, iRVCHWgihWIJcXXmMFSqKuoPLnAe, MPKfkoQyvQhGXsXscrbjQAGYUOFJ, EmTCFMkVTlXKOQiCqAGoZjiCBiXg, ZpfnCyBYHfzEqnxuJyLBaeHEQVbd, zwwoYOqFgCoAMDXILjeqPIvUZyUo, conflictCheckingHelper.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(KCnhuGqaEDWhPvtaErhbdymoPUGq).HCqsUTYybVMCVwCYQIskQMgrlygr).GetEnumerator();
									dJictrGyiCeuHgfFDemDYeRnJGVWB = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							KCnhuGqaEDWhPvtaErhbdymoPUGq++;
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

					private void EKwtMilkoeuDnyAbYhQxJrwTrgVqA()
					{
						dJictrGyiCeuHgfFDemDYeRnJGVWB = -1;
						if (QTsWbNEWuwDDFhJjkaraswXQfoWo != null)
						{
							QTsWbNEWuwDDFhJjkaraswXQfoWo.Dispose();
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
						TkFJvPqyqSBXwJHKAQWwVrByuWBH tkFJvPqyqSBXwJHKAQWwVrByuWBH;
						if (dJictrGyiCeuHgfFDemDYeRnJGVWB == -2 && OhQAtoicQiMZjUvZiNCpYemyzmGNA == Environment.CurrentManagedThreadId)
						{
							dJictrGyiCeuHgfFDemDYeRnJGVWB = 0;
							tkFJvPqyqSBXwJHKAQWwVrByuWBH = this;
						}
						else
						{
							tkFJvPqyqSBXwJHKAQWwVrByuWBH = new TkFJvPqyqSBXwJHKAQWwVrByuWBH(0);
							tkFJvPqyqSBXwJHKAQWwVrByuWBH.pEjBdMoDnlaYNAKWBRwahwjftmDP = pEjBdMoDnlaYNAKWBRwahwjftmDP;
						}
						tkFJvPqyqSBXwJHKAQWwVrByuWBH.iRVCHWgihWIJcXXmMFSqKuoPLnAe = CcGFDVEMEBRqlHRHFUbAVcXnWmDl;
						tkFJvPqyqSBXwJHKAQWwVrByuWBH.MPKfkoQyvQhGXsXscrbjQAGYUOFJ = sGhXdzULbGvKwULPOBoISiYGfiVJA;
						tkFJvPqyqSBXwJHKAQWwVrByuWBH.EmTCFMkVTlXKOQiCqAGoZjiCBiXg = icLkKleTznVFTqWdrEAJftkxxCPd;
						tkFJvPqyqSBXwJHKAQWwVrByuWBH.ZpfnCyBYHfzEqnxuJyLBaeHEQVbd = qBcezGfVgVcqHPDZEAjxQiTtSLZDA;
						tkFJvPqyqSBXwJHKAQWwVrByuWBH.zwwoYOqFgCoAMDXILjeqPIvUZyUo = liSyRWqbdongpcGwgrtYKifrQXjN;
						return tkFJvPqyqSBXwJHKAQWwVrByuWBH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class GntehHmoIBTWjSupRXjXJGUecrZH : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int othubxHvQqCchhCcidLqmRYRssHk;

					private ElementAssignmentConflictInfo dBFrlXYrAjDGJCoYAUzTtStdFSSN;

					private int CnkrvmHSIZJlGLDxAfyjCrdTjKYA;

					private ElementAssignmentConflictCheck PPNqguDFQcGCFWxeIUmRaSmRDysH;

					public ElementAssignmentConflictCheck TEAfjIYlnfNYEBaFYrVDilOgpNxW;

					public ConflictCheckingHelper QEcNdyuXMuFnNqhQjLSgYvyPqXvd;

					private bool fXhErvMsToZhrNDXTVlYbqalwJiV;

					public bool MsOhbvVAyIybqwRGpIdbgDQMsekE;

					private bool OawdtrixRvaQKSUZgdMRnnujcEFOA;

					public bool NCbGMNFjmsZvknTVqcfwjGzMilpAb;

					private int UdfUKMoXfhALmJBRgsRNjcLTHkYx;

					private IEnumerator<ElementAssignmentConflictInfo> NslBewFzZyBcmEGwNwKMkXuzxmFE;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dBFrlXYrAjDGJCoYAUzTtStdFSSN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dBFrlXYrAjDGJCoYAUzTtStdFSSN;
						}
					}

					[DebuggerHidden]
					public GntehHmoIBTWjSupRXjXJGUecrZH(int P_0)
					{
						othubxHvQqCchhCcidLqmRYRssHk = P_0;
						CnkrvmHSIZJlGLDxAfyjCrdTjKYA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = othubxHvQqCchhCcidLqmRYRssHk;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								ycoWfEbxSHJTBQwPswRDzjKyJEBd();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = othubxHvQqCchhCcidLqmRYRssHk;
							ConflictCheckingHelper qEcNdyuXMuFnNqhQjLSgYvyPqXvd = QEcNdyuXMuFnNqhQjLSgYvyPqXvd;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								othubxHvQqCchhCcidLqmRYRssHk = -3;
								goto IL_00f3;
							}
							othubxHvQqCchhCcidLqmRYRssHk = -1;
							if (PPNqguDFQcGCFWxeIUmRaSmRDysH.controllerId < 0 || PPNqguDFQcGCFWxeIUmRaSmRDysH.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							UdfUKMoXfhALmJBRgsRNjcLTHkYx = 0;
							goto IL_011f;
							IL_00f3:
							if (NslBewFzZyBcmEGwNwKMkXuzxmFE.MoveNext())
							{
								ElementAssignmentConflictInfo current = NslBewFzZyBcmEGwNwKMkXuzxmFE.Current;
								dBFrlXYrAjDGJCoYAUzTtStdFSSN = current;
								othubxHvQqCchhCcidLqmRYRssHk = 1;
								return true;
							}
							ycoWfEbxSHJTBQwPswRDzjKyJEBd();
							NslBewFzZyBcmEGwNwKMkXuzxmFE = null;
							goto IL_010d;
							IL_011f:
							if (UdfUKMoXfhALmJBRgsRNjcLTHkYx < qEcNdyuXMuFnNqhQjLSgYvyPqXvd.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA())
							{
								if (qEcNdyuXMuFnNqhQjLSgYvyPqXvd.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(UdfUKMoXfhALmJBRgsRNjcLTHkYx).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == PPNqguDFQcGCFWxeIUmRaSmRDysH.controllerId)
								{
									NslBewFzZyBcmEGwNwKMkXuzxmFE = qEcNdyuXMuFnNqhQjLSgYvyPqXvd.pIpKAGdBTEhEdjrYNTqNltYrbGQi(PPNqguDFQcGCFWxeIUmRaSmRDysH, fXhErvMsToZhrNDXTVlYbqalwJiV, OawdtrixRvaQKSUZgdMRnnujcEFOA, qEcNdyuXMuFnNqhQjLSgYvyPqXvd.HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(UdfUKMoXfhALmJBRgsRNjcLTHkYx).HCqsUTYybVMCVwCYQIskQMgrlygr).GetEnumerator();
									othubxHvQqCchhCcidLqmRYRssHk = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							UdfUKMoXfhALmJBRgsRNjcLTHkYx++;
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

					private void ycoWfEbxSHJTBQwPswRDzjKyJEBd()
					{
						othubxHvQqCchhCcidLqmRYRssHk = -1;
						if (NslBewFzZyBcmEGwNwKMkXuzxmFE != null)
						{
							NslBewFzZyBcmEGwNwKMkXuzxmFE.Dispose();
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
						GntehHmoIBTWjSupRXjXJGUecrZH gntehHmoIBTWjSupRXjXJGUecrZH;
						if (othubxHvQqCchhCcidLqmRYRssHk == -2 && CnkrvmHSIZJlGLDxAfyjCrdTjKYA == Environment.CurrentManagedThreadId)
						{
							othubxHvQqCchhCcidLqmRYRssHk = 0;
							gntehHmoIBTWjSupRXjXJGUecrZH = this;
						}
						else
						{
							gntehHmoIBTWjSupRXjXJGUecrZH = new GntehHmoIBTWjSupRXjXJGUecrZH(0);
							gntehHmoIBTWjSupRXjXJGUecrZH.QEcNdyuXMuFnNqhQjLSgYvyPqXvd = QEcNdyuXMuFnNqhQjLSgYvyPqXvd;
						}
						gntehHmoIBTWjSupRXjXJGUecrZH.PPNqguDFQcGCFWxeIUmRaSmRDysH = TEAfjIYlnfNYEBaFYrVDilOgpNxW;
						gntehHmoIBTWjSupRXjXJGUecrZH.fXhErvMsToZhrNDXTVlYbqalwJiV = MsOhbvVAyIybqwRGpIdbgDQMsekE;
						gntehHmoIBTWjSupRXjXJGUecrZH.OawdtrixRvaQKSUZgdMRnnujcEFOA = NCbGMNFjmsZvknTVqcfwjGzMilpAb;
						return gntehHmoIBTWjSupRXjXJGUecrZH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player uMYADhiMneGWyAejQgJejScskHph;

				private readonly ControllerHelper HPIjxjFDYVXWvuwHVgbzBHmTkzOE;

				private readonly int gPqcZwOfDkxhrxuYamCzlPNEUTGr;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					gPqcZwOfDkxhrxuYamCzlPNEUTGr = ReInput.id;
					uMYADhiMneGWyAejQgJejScskHph = P_0;
					HPIjxjFDYVXWvuwHVgbzBHmTkzOE = P_1;
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => rKaSmLoPJtDIkGwcfkQKKWWyLgdC(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => NAqWflavZXfnZWAQpEOgwneaZBW(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ZZDCvfEgNUfAUueFzpuynUocZALh(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => mwYSNZwrnWMVpCaDikwRzsJlPsdn(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => gDrbZSHfQxcMGSYTfevGPUbYhKWpA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => rFdgOBwBrChnBOsPaDyjdTSHDPetA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => QWcfQuMJwuXlRFxRKDVSttOzmDZ(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => OLcdIuOXCrSeoufkpbsWLABvaKJ(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return HDyNIptPXfObkiSrFhUoVDpFidmz(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return pxbJrgCgRUEyARTSzWpRdhCCpSRI(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return JOLWiuviHaKkVOIfLTSMlKGSsvSL(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return lvbkbVOExSQhdmTYiwKhJPAhMWhG(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => iGnnghdiegfguJllgnOVSsaOlTiR(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => qZZYQpKJYTPpwlczmjZaOOmbhmZl(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ctQncKITAwpYeRzAmIRHLpzgUPTO(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => jEOroejOVbuOxVDIZVUxwxRiKQxy(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => HWsNDEStShCJNTnawzOHrfssKGYf(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => oXmbvtbQtpKCEoNPmnnFGCLGoGSTB(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => RvJOcHSfhanRYnQxtNwgPYrhElMm(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => KVvAlBSVOwCskNEGqdHThNXKdTll(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return MEfkrncronBQQNiQpUilHiRDFVGAA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return EBUhVYbFSVYXzDEpogQjVfdyNXzXA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return vXIYHAjPyjTMNdtdrndeiVHtwxWT(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return PCjNfSaSVRhfDmSKkCqhxmjkatLJ(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => VOLNmOVUtgBNXepVMGjpoXAsfXEHA(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => LZqoEfxSLuYYanyrkmeGdqbBPfvw(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => VioVVJtAeEhBpjfwEiDJBvWvBkyDA(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => eEwlHlRRRirQWJcWocoZVtyniRkC(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => ZhRwenMHVuXwqszAzuPvDCwzdKvjA(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => esDwOVbwhSluZXcALMzovhsoNJSQ(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => krtxWARvNWKihnFfIpWigyUNstJl(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => XXBqrQLDucfJSJxSYbYbHucIlmeJA(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return yxGvcSjzojCTPOymOifxvtdLipVi(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return mlcFvYjFqTjWEhOndcOYbDrgsWqT(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return vUtnzjAEBbewhVzKjFxIeHFkFtbg(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return FtnTgRhEAhrFsiSLFUakjkhWzFnj(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => jGvbqFWSRznmYsUQVAkhQIUgPIXB(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => zOZejadxstZcEfKydAmvfPLfUAkQc(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => oEWfqLmOgqzcLPEnSBJyPsJqXyXC(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => TVQcFCFbandQDEtLIqnElRHkmVRAA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => piChmcFXHLoMaVEPEQTzCRYxSOODA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => acieBaGdYWyDmymuCnZxkjgzbORO(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => CmQbfboLRbkrgIYCdgatJwUWwKJE(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => ebeWJLcdNCaMadggMLPFhDBHLvsU(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != gPqcZwOfDkxhrxuYamCzlPNEUTGr)
					{
						ReInput.CheckInitialized(gPqcZwOfDkxhrxuYamCzlPNEUTGr);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return RUEGOWGWfdSkKygBOBnktJjVUuSK(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return aYoQWmeqdvFxPpLYHUFJMXxyuxHh(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return MTvVSbSGrwWxMTnwxpxXPqMOVadp(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return WnemAiiGZRVLyQeaNplrnCDJhTTHA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool rKaSmLoPJtDIkGwcfkQKKWWyLgdC(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0 && TCnTFxsUfuapdEUJYQwenxeRoXeM(ControllerType.Joystick, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr))
						{
							return true;
						}
					}
					return false;
				}

				private bool gDrbZSHfQxcMGSYTfevGPUbYhKWpA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0 && FDogepIbuUUcSXRBhbcVbtRPbCNL(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr))
						{
							return true;
						}
					}
					return false;
				}

				private bool HDyNIptPXfObkiSrFhUoVDpFidmz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0.controllerId && sJGgbojwtIbwPqjAGRQBhOIsdLHMA(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr))
						{
							return true;
						}
					}
					return false;
				}

				private bool NAqWflavZXfnZWAQpEOgwneaZBW(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return TCnTFxsUfuapdEUJYQwenxeRoXeM(ControllerType.Keyboard, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private bool rFdgOBwBrChnBOsPaDyjdTSHDPetA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return FDogepIbuUUcSXRBhbcVbtRPbCNL(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private bool pxbJrgCgRUEyARTSzWpRdhCCpSRI(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return sJGgbojwtIbwPqjAGRQBhOIsdLHMA(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private bool ZZDCvfEgNUfAUueFzpuynUocZALh(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return TCnTFxsUfuapdEUJYQwenxeRoXeM(ControllerType.Mouse, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private bool QWcfQuMJwuXlRFxRKDVSttOzmDZ(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return FDogepIbuUUcSXRBhbcVbtRPbCNL(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private bool JOLWiuviHaKkVOIfLTSMlKGSsvSL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return sJGgbojwtIbwPqjAGRQBhOIsdLHMA(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private bool mwYSNZwrnWMVpCaDikwRzsJlPsdn(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0 && TCnTFxsUfuapdEUJYQwenxeRoXeM(ControllerType.Custom, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr))
						{
							return true;
						}
					}
					return false;
				}

				private bool OLcdIuOXCrSeoufkpbsWLABvaKJ(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0 && FDogepIbuUUcSXRBhbcVbtRPbCNL(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr))
						{
							return true;
						}
					}
					return false;
				}

				private bool lvbkbVOExSQhdmTYiwKhJPAhMWhG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0.controllerId && sJGgbojwtIbwPqjAGRQBhOIsdLHMA(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(RvxgSObThmqCXYazTusHOqXyNLJI))]
				private IEnumerable<ElementAssignmentConflictInfo> iGnnghdiegfguJllgnOVSsaOlTiR(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new RvxgSObThmqCXYazTusHOqXyNLJI(-2)
					{
						CGkBBJgOaJmxDdtVHmufYKnWrFSpb = this,
						soISgsIIUNKwLuPTmBdhIEDrxXok = P_0,
						zsqGoHFxJyOhIBPxdtxrbVheoOaS = P_1,
						OUSJUNpWKOwJEuNYJEdpJiryIoSN = P_2,
						ViDSiqhKNfmGVjVwZqgVizlgalVu = P_3
					};
				}

				[IteratorStateMachine(typeof(TkFJvPqyqSBXwJHKAQWwVrByuWBH))]
				private IEnumerable<ElementAssignmentConflictInfo> HWsNDEStShCJNTnawzOHrfssKGYf(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new TkFJvPqyqSBXwJHKAQWwVrByuWBH(-2)
					{
						pEjBdMoDnlaYNAKWBRwahwjftmDP = this,
						CcGFDVEMEBRqlHRHFUbAVcXnWmDl = P_0,
						sGhXdzULbGvKwULPOBoISiYGfiVJA = P_1,
						icLkKleTznVFTqWdrEAJftkxxCPd = P_2,
						qBcezGfVgVcqHPDZEAjxQiTtSLZDA = P_3,
						liSyRWqbdongpcGwgrtYKifrQXjN = P_4
					};
				}

				[IteratorStateMachine(typeof(GntehHmoIBTWjSupRXjXJGUecrZH))]
				private IEnumerable<ElementAssignmentConflictInfo> MEfkrncronBQQNiQpUilHiRDFVGAA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new GntehHmoIBTWjSupRXjXJGUecrZH(-2)
					{
						QEcNdyuXMuFnNqhQjLSgYvyPqXvd = this,
						TEAfjIYlnfNYEBaFYrVDilOgpNxW = P_0,
						MsOhbvVAyIybqwRGpIdbgDQMsekE = P_1,
						NCbGMNFjmsZvknTVqcfwjGzMilpAb = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> qZZYQpKJYTPpwlczmjZaOOmbhmZl(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return sEOAFNLzpEumWkPBYCLduPzcVAiC(ControllerType.Keyboard, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private IEnumerable<ElementAssignmentConflictInfo> oXmbvtbQtpKCEoNPmnnFGCLGoGSTB(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return IiZKwJyWArPQuZvNEKPqwjpqdkegA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private IEnumerable<ElementAssignmentConflictInfo> EBUhVYbFSVYXzDEpogQjVfdyNXzXA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return pIpKAGdBTEhEdjrYNTqNltYrbGQi(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private IEnumerable<ElementAssignmentConflictInfo> ctQncKITAwpYeRzAmIRHLpzgUPTO(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return sEOAFNLzpEumWkPBYCLduPzcVAiC(ControllerType.Mouse, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> RvJOcHSfhanRYnQxtNwgPYrhElMm(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return IiZKwJyWArPQuZvNEKPqwjpqdkegA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> vXIYHAjPyjTMNdtdrndeiVHtwxWT(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return pIpKAGdBTEhEdjrYNTqNltYrbGQi(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				[IteratorStateMachine(typeof(hesfhWHfQZHtTxgtLHbIXoaeqPqj))]
				private IEnumerable<ElementAssignmentConflictInfo> jEOroejOVbuOxVDIZVUxwxRiKQxy(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new hesfhWHfQZHtTxgtLHbIXoaeqPqj(-2)
					{
						FEnGmrwIaTtQgqQNMYqVMavMLFXd = this,
						TaFFppGpvvlLFGphVdDrfAUVfzYEb = P_0,
						mQfLqhDUNnyrFyqjKwchaJxcOTxC = P_1,
						WWIzVHFHaCPrpzObisSXlFTmUqyh = P_2,
						LRWvaeCenYhHIYvVoassREwYrfXV = P_3
					};
				}

				[IteratorStateMachine(typeof(bmBnyCXojvUSvVUENTJsriMorMrt))]
				private IEnumerable<ElementAssignmentConflictInfo> KVvAlBSVOwCskNEGqdHThNXKdTll(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new bmBnyCXojvUSvVUENTJsriMorMrt(-2)
					{
						yzHlGRAILBJfWUkFLDnOFWmIhJYpA = this,
						mFxqsxxhJregVhWBnihrlmGEJvpAb = P_0,
						HXIDDeabSfAGaNvNFbohhZXJAROW = P_1,
						ZTnbvLuOfSFgIxEkBtftDApYNuJk = P_2,
						PoZkLrVStifHwLRIXrOEtHYHDGJq = P_3,
						CoriKFfCUSdlaGycnIUyDSRHFPtMA = P_4
					};
				}

				[IteratorStateMachine(typeof(jYaEDWVxOvcqLnGVvmxOPVkVesTF))]
				private IEnumerable<ElementAssignmentConflictInfo> PCjNfSaSVRhfDmSKkCqhxmjkatLJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new jYaEDWVxOvcqLnGVvmxOPVkVesTF(-2)
					{
						jdgdQVRIfPKGVgcnZjBtVmwafo = this,
						SXdQCmsBBEIwSPenRlSYqMCkpzQB = P_0,
						CHBGvcnirZemmuhPgVmSvfaHOSrN = P_1,
						XlXyjxBKkgfkjvKxsnkMzJoEeYNY = P_2
					};
				}

				private int VOLNmOVUtgBNXepVMGjpoXAsfXEHA(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += TjXKssOGwaaJYOyAKaXMHRhMxMFj(ControllerType.Joystick, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr);
						}
					}
					return num;
				}

				private int ZhRwenMHVuXwqszAzuPvDCwzdKvjA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += HbjOFVizefrSBLAzhxEWOMQZsMoW(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr);
						}
					}
					return num;
				}

				private int yxGvcSjzojCTPOymOifxvtdLipVi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0.controllerId)
						{
							num += qWINgtcqqGhLksNMpluyaoayQhFR(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr);
						}
					}
					return num;
				}

				private int LZqoEfxSLuYYanyrkmeGdqbBPfvw(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return TjXKssOGwaaJYOyAKaXMHRhMxMFj(ControllerType.Keyboard, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private int esDwOVbwhSluZXcALMzovhsoNJSQ(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return HbjOFVizefrSBLAzhxEWOMQZsMoW(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private int mlcFvYjFqTjWEhOndcOYbDrgsWqT(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return qWINgtcqqGhLksNMpluyaoayQhFR(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV);
				}

				private int VioVVJtAeEhBpjfwEiDJBvWvBkyDA(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return TjXKssOGwaaJYOyAKaXMHRhMxMFj(ControllerType.Mouse, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private int krtxWARvNWKihnFfIpWigyUNstJl(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return HbjOFVizefrSBLAzhxEWOMQZsMoW(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private int vUtnzjAEBbewhVzKjFxIeHFkFtbg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return qWINgtcqqGhLksNMpluyaoayQhFR(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA);
				}

				private int eEwlHlRRRirQWJcWocoZVtyniRkC(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += TjXKssOGwaaJYOyAKaXMHRhMxMFj(ControllerType.Custom, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr);
						}
					}
					return num;
				}

				private int XXBqrQLDucfJSJxSYbYbHucIlmeJA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += HbjOFVizefrSBLAzhxEWOMQZsMoW(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr);
						}
					}
					return num;
				}

				private int FtnTgRhEAhrFsiSLFUakjkhWzFnj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0.controllerId)
						{
							num += qWINgtcqqGhLksNMpluyaoayQhFR(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr);
						}
					}
					return num;
				}

				private int jGvbqFWSRznmYsUQVAkhQIUgPIXB(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += zJqbLgxhbXNldIHOVBGKMxpTzLzm(ControllerType.Joystick, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr, P_4);
						}
					}
					return num;
				}

				private int piChmcFXHLoMaVEPEQTzCRYxSOODA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += uKkrpngRYmdthpXKlmEnRGnpMBRi(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr, P_5);
						}
					}
					return num;
				}

				private int RUEGOWGWfdSkKygBOBnktJjVUuSK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0.controllerId)
						{
							num += YyikgQSqQhoVqKwkGCuwBkDWSRhK(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.IdXntCWLqmcpKWdMbubqFFsVDjNx.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr, P_3);
						}
					}
					return num;
				}

				private int zOZejadxstZcEfKydAmvfPLfUAkQc(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return zJqbLgxhbXNldIHOVBGKMxpTzLzm(ControllerType.Keyboard, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV, P_3);
				}

				private int acieBaGdYWyDmymuCnZxkjgzbORO(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return uKkrpngRYmdthpXKlmEnRGnpMBRi(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV, P_4);
				}

				private int aYoQWmeqdvFxPpLYHUFJMXxyuxHh(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return YyikgQSqQhoVqKwkGCuwBkDWSRhK(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.VZCoPBsGbmJMgghTsdBTAjjoGqsV, P_3);
				}

				private int oEWfqLmOgqzcLPEnSBJyPsJqXyXC(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return zJqbLgxhbXNldIHOVBGKMxpTzLzm(ControllerType.Mouse, 0, P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA, P_3);
				}

				private int CmQbfboLRbkrgIYCdgatJwUWwKJE(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return uKkrpngRYmdthpXKlmEnRGnpMBRi(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA, P_4);
				}

				private int MTvVSbSGrwWxMTnwxpxXPqMOVadp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return YyikgQSqQhoVqKwkGCuwBkDWSRhK(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.umNPfzmglfihAHAQFrHLVbbipBXyA, P_3);
				}

				private int TVQcFCFbandQDEtLIqnElRHkmVRAA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += zJqbLgxhbXNldIHOVBGKMxpTzLzm(ControllerType.Custom, P_0, P_1, P_2, P_3, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr, P_4);
						}
					}
					return num;
				}

				private int ebeWJLcdNCaMadggMLPFhDBHLvsU(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							num += uKkrpngRYmdthpXKlmEnRGnpMBRi(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr, P_5);
						}
					}
					return num;
				}

				private int WnemAiiGZRVLyQeaNplrnCDJhTTHA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.CWLECYOaiOjsDtPLimRKPeEPiywaA(); i++)
					{
						if (HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0.controllerId)
						{
							num += YyikgQSqQhoVqKwkGCuwBkDWSRhK(P_0, P_1, P_2, HPIjxjFDYVXWvuwHVgbzBHmTkzOE.jQagOUghReThwXIwYFFvuoKdhwOj.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i).HCqsUTYybVMCVwCYQIskQMgrlygr, P_3);
						}
					}
					return num;
				}

				private bool TCnTFxsUfuapdEUJYQwenxeRoXeM<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_5.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool FDogepIbuUUcSXRBhbcVbtRPbCNL<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_6.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool sJGgbojwtIbwPqjAGRQBhOIsdLHMA<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_3.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(SsMaGtIRnCbdrIWLmJvTWOsJsZMM))]
				private IEnumerable<ElementAssignmentConflictInfo> sEOAFNLzpEumWkPBYCLduPzcVAiC<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_5) where _0001 : ControllerMap
				{
					return new SsMaGtIRnCbdrIWLmJvTWOsJsZMM<_0001>(-2)
					{
						sYFOjtgLpbfrOgBxjMXvEyMmXUweA = this,
						EEUgMEGWQarefCrpcVfZDfUfQYDhA = P_0,
						dZOKiwBdGtIQOFlCFcadvZFhugBA = P_1,
						wQCkCJqHGMRIVBlzjWLalJRMXxQB = P_2,
						LPocTydYSPwnPhYhDXZAARtyCSGLA = P_3,
						SDvWCwYNrVFRXSCWnwPrtuiFxuDP = P_4,
						FPgCCxOWamIxVndYwTCqzWgEhuYJ = P_5
					};
				}

				[IteratorStateMachine(typeof(fcMfFDfYVsLOEUTdnoPkjpdBnnecA))]
				private IEnumerable<ElementAssignmentConflictInfo> IiZKwJyWArPQuZvNEKPqwjpqdkegA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_6) where _0001 : ControllerMap
				{
					return new fcMfFDfYVsLOEUTdnoPkjpdBnnecA<_0001>(-2)
					{
						XNkVLvjyMOZnhXCBKIsceRIYzMuG = this,
						FGzaPMjMuqHdIlTMchghDadmzpGuA = P_0,
						FOGdRhbjlVGxthOEWWmjFcSOPgVg = P_1,
						yYpUnABbviuTzVwdzDhclMqWDnDdA = P_2,
						mRpvIaqHVRUwqpgNRWRFmOJxthjP = P_3,
						KDqLOEvtgqqycLkqjkZsfUVAJjL = P_4,
						lYGGxlLmWYsHvjpEWoXLxuEeJBxr = P_5,
						bMBaDheGNgvIgsocNGckkFetqyKR = P_6
					};
				}

				[IteratorStateMachine(typeof(OvKChzFHQLdNNduVdzOlOiVCOMIKA))]
				private IEnumerable<ElementAssignmentConflictInfo> pIpKAGdBTEhEdjrYNTqNltYrbGQi<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_3) where _0001 : ControllerMap
				{
					return new OvKChzFHQLdNNduVdzOlOiVCOMIKA<_0001>(-2)
					{
						ENPJrypllGhiURFdDKTSRKGpBvWHA = this,
						veaCaZPMZdvPVGLhJohkOdpehGnb = P_0,
						AVjUyOfBZEzbLtEEpoTNnfdGTGEQ = P_1,
						gihwvwhyAsaVHsQBqTUhTVTHNBEv = P_2,
						tuddJXpcOwRzekQwYDzzALCpFWtJ = P_3
					};
				}

				private int TjXKssOGwaaJYOyAKaXMHRhMxMFj<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_5.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int HbjOFVizefrSBLAzhxEWOMQZsMoW<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_6.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int qWINgtcqqGhLksNMpluyaoayQhFR<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_3.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int zJqbLgxhbXNldIHOVBGKMxpTzLzm<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_5.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(mapCategory, controllerMap)))
						{
							num += controllerMap.vktnuWxNzkftrdKLECoAFlKxxZVR(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int uKkrpngRYmdthpXKlmEnRGnpMBRi<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_6.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(inputMapCategory, controllerMap)))
						{
							num += controllerMap.zFYfwFdloxCUWaLFFnIoYLdVvyPiB(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int YyikgQSqQhoVqKwkGCuwBkDWSRhK<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.RaeomPUMtcefLDSAzqHUlBVAPqHO(); i++)
					{
						ControllerMap controllerMap = P_3.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !MwknJNHEbiTReBtRwLeFnhscBjJGA(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RXiaSbGxTjBngXQARUXBmIjqPtfzA(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool MwknJNHEbiTReBtRwLeFnhscBjJGA(InputMapCategory P_0, ControllerMap P_1)
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
			internal interface unzVxbtGRmQZzSvYceNVtoUGFLPd
			{
				hfLYAzMldWckrgTmUxrPPSWxmrCj vhtvabKtNEpzrCCHAcgBCuIhIVsfb { get; }

				ControllerType RnJpoDfFtBKuYnlGelTlylszpsZN { get; }

				int umplaoBWNrHpDalRCquleOiTParq { get; }

				bool FakAmIvfEVYksSJrCCWPcbwUCZIB(Controller P_0);

				bool BsgehaiWaTDIVAjKTpeWrtLjZWiM(int P_0);

				void qVUSrCgskajxxHBZIbzlMkvVRbmrA(int P_0);

				void tOADxGCqTfeVNeBqcNLlxRSvrxeNB(Controller P_0);

				void VrubidYQNwPKnPJaUaYQCSusGvMX(int P_0);

				Controller srFCiMaywLRdTHCeENBnRscpJzkEb(int P_0);

				Controller xwIczbdsEWFyJsfwHWQrAWolXTSQ(string P_0);

				int XddXBBksUPrMesfAKcwIIgvxrABj(Controller P_0);

				int ghrxZqMyoYcbUFqIXMxXbMUJPIAP(int P_0);

				int AyfUalmighPUhWsTnbjlERkmLjfr(string P_0);

				void rathYiUMZUILQLDtwGIGWMqiANoKA();

				hfLYAzMldWckrgTmUxrPPSWxmrCj jxGNMeDStoCqCXFxSStAYeBTQCmC(int P_0);

				hfLYAzMldWckrgTmUxrPPSWxmrCj EFKNXLZJHdgoPYngfcwzBLhZyKpc(Controller P_0);

				void FfSCzSboPbLWILMRSkHVFCPxZzVM(hfLYAzMldWckrgTmUxrPPSWxmrCj P_0);
			}

			internal interface hfLYAzMldWckrgTmUxrPPSWxmrCj
			{
				cAOEnjfvQnLBHThOTZsixNhIbMMJ XCfFEHCAovUlErZTLVujHEbwOdRG { get; }

				Controller KHNnRvXGgofSbETmKmwfENQvePGfb { get; }

				double VumrgdvHaLTaRsjrZxMuNKrNcNNM { get; }
			}

			[DefaultMember("Item")]
			internal sealed class yvMungSQMqFTsqBLbgYkYfemOFGR<_0001, _0002> : unzVxbtGRmQZzSvYceNVtoUGFLPd where _0001 : Controller where _0002 : ControllerMap
			{
				public class bYDcyWECHLgfltcQBjcCpqKRnGVv : hfLYAzMldWckrgTmUxrPPSWxmrCj
				{
					public _0001 IXFfJcQlRcjJSXDHlZIdknOrcNrEA;

					public global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0002> HCqsUTYybVMCVwCYQIskQMgrlygr;

					public double KVbMeVzqlFGMzAQyywAzOuTSeEnv;

					Controller hfLYAzMldWckrgTmUxrPPSWxmrCj.ULtIyAZpLgDoQHjWorBhbnCemYJo => IXFfJcQlRcjJSXDHlZIdknOrcNrEA;

					cAOEnjfvQnLBHThOTZsixNhIbMMJ hfLYAzMldWckrgTmUxrPPSWxmrCj.DiwOzoBZHgVEyTcLuCdOakSFOZwe => HCqsUTYybVMCVwCYQIskQMgrlygr;

					double hfLYAzMldWckrgTmUxrPPSWxmrCj.BtKtpTJAZTIKLKbSRHpearCmyNrn => KVbMeVzqlFGMzAQyywAzOuTSeEnv;

					public bYDcyWECHLgfltcQBjcCpqKRnGVv(_0001 P_0, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0002> P_1)
					{
						IXFfJcQlRcjJSXDHlZIdknOrcNrEA = P_0;
						HCqsUTYybVMCVwCYQIskQMgrlygr = P_1;
					}

					public void dDMundcRBxaovBmVXrEYmuZBtMYk()
					{
						KVbMeVzqlFGMzAQyywAzOuTSeEnv = ReInput.unscaledTime;
					}
				}

				private List<bYDcyWECHLgfltcQBjcCpqKRnGVv> fEGuhlibMLXgMCXPBKkNpHVgfNMO;

				private List<_0001> TNEpwCBCfOfeQJOiSbaaumnFLhWBA;

				private ReadOnlyCollection<_0001> NkvbDFYkJkVAbhrpSTpGKrrEjpvF;

				private readonly ControllerType oTTptnhmktacKffEtovqtGUvdONQ;

				int unzVxbtGRmQZzSvYceNVtoUGFLPd.umplaoBWNrHpDalRCquleOiTParq => fEGuhlibMLXgMCXPBKkNpHVgfNMO.Count;

				public IList<_0001> ONvuBkVYHnIsPvDHhAeUTNTVqEEQ => NkvbDFYkJkVAbhrpSTpGKrrEjpvF;

				public bYDcyWECHLgfltcQBjcCpqKRnGVv qGwAuwMMxZUqzYOMvElKDnKUbUgR => fEGuhlibMLXgMCXPBKkNpHVgfNMO[P_0];

				ControllerType unzVxbtGRmQZzSvYceNVtoUGFLPd.RnJpoDfFtBKuYnlGelTlylszpsZN => oTTptnhmktacKffEtovqtGUvdONQ;

				hfLYAzMldWckrgTmUxrPPSWxmrCj unzVxbtGRmQZzSvYceNVtoUGFLPd.stTUaAgKmcipRWvBAVfBhvitsHgH => fEGuhlibMLXgMCXPBKkNpHVgfNMO[index];

				public yvMungSQMqFTsqBLbgYkYfemOFGR()
				{
					if ((object)pMvvECjJycyKibKKCAXEnFbBPTVk.ZiMdoEbUQLTkkiymUAoLDIkvJuiBA<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					oTTptnhmktacKffEtovqtGUvdONQ = pMvvECjJycyKibKKCAXEnFbBPTVk.WVUQwFjeRhevfhUdbNZYjvGXpxKM(typeof(_0001));
					fEGuhlibMLXgMCXPBKkNpHVgfNMO = new List<bYDcyWECHLgfltcQBjcCpqKRnGVv>();
					TNEpwCBCfOfeQJOiSbaaumnFLhWBA = new List<_0001>();
					NkvbDFYkJkVAbhrpSTpGKrrEjpvF = new ReadOnlyCollection<_0001>(TNEpwCBCfOfeQJOiSbaaumnFLhWBA);
				}

				public bYDcyWECHLgfltcQBjcCpqKRnGVv yoVmDOIjkepJezQNZERxEAbGdPtdA(int P_0)
				{
					if (oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Keyboard || oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = aLTukwVBmAMZPnIyIdgjTaoDtgPN(P_0);
					if (num < 0)
					{
						return null;
					}
					return fEGuhlibMLXgMCXPBKkNpHVgfNMO[num];
				}

				public bYDcyWECHLgfltcQBjcCpqKRnGVv IAJgNBDkMqMiXvxtdBzRzMMQonBe(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return yoVmDOIjkepJezQNZERxEAbGdPtdA(P_0.id);
				}

				public void OwdKURULOylBLcuiTGHICOiuJgxQ(bYDcyWECHLgfltcQBjcCpqKRnGVv P_0)
				{
					if (P_0 != null)
					{
						fEGuhlibMLXgMCXPBKkNpHVgfNMO.Add(P_0);
						TNEpwCBCfOfeQJOiSbaaumnFLhWBA.Add(P_0.IXFfJcQlRcjJSXDHlZIdknOrcNrEA);
					}
				}

				public void GxMJFSNVaJMbhwbsqjLMdnROgAKR(int P_0)
				{
					if (oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Keyboard || oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (aLTukwVBmAMZPnIyIdgjTaoDtgPN(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < fEGuhlibMLXgMCXPBKkNpHVgfNMO.Count; i++)
					{
						if (fEGuhlibMLXgMCXPBKkNpHVgfNMO[i].IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							bgqyyZWhswsXnieYEbArOTlxddhBA(i);
							break;
						}
					}
				}

				void unzVxbtGRmQZzSvYceNVtoUGFLPd.qVUSrCgskajxxHBZIbzlMkvVRbmrA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in GxMJFSNVaJMbhwbsqjLMdnROgAKR
					this.GxMJFSNVaJMbhwbsqjLMdnROgAKR(P_0);
				}

				public void XUzBezvbZLuNRqNqZdPuJlVLwsYOA(_0001 P_0)
				{
					if (P_0 != null && P_0.type == oTTptnhmktacKffEtovqtGUvdONQ)
					{
						GxMJFSNVaJMbhwbsqjLMdnROgAKR(P_0.id);
					}
				}

				public void bgqyyZWhswsXnieYEbArOTlxddhBA(int P_0)
				{
					if (P_0 >= 0 && P_0 < fEGuhlibMLXgMCXPBKkNpHVgfNMO.Count)
					{
						fEGuhlibMLXgMCXPBKkNpHVgfNMO.RemoveAt(P_0);
						TNEpwCBCfOfeQJOiSbaaumnFLhWBA.RemoveAt(P_0);
					}
				}

				void unzVxbtGRmQZzSvYceNVtoUGFLPd.VrubidYQNwPKnPJaUaYQCSusGvMX(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in bgqyyZWhswsXnieYEbArOTlxddhBA
					this.bgqyyZWhswsXnieYEbArOTlxddhBA(P_0);
				}

				public _0001 vHZEYGWPbXdkITvqEqYLxDnueIxY(int P_0)
				{
					if (oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Keyboard || oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = aLTukwVBmAMZPnIyIdgjTaoDtgPN(P_0);
					if (num < 0)
					{
						return null;
					}
					return fEGuhlibMLXgMCXPBKkNpHVgfNMO[num].IXFfJcQlRcjJSXDHlZIdknOrcNrEA;
				}

				public bool EymsnWWXHySlmhDLNDpjBUfCERJH(int P_0)
				{
					if (oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Keyboard || oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < fEGuhlibMLXgMCXPBKkNpHVgfNMO.Count; i++)
					{
						if (fEGuhlibMLXgMCXPBKkNpHVgfNMO[i].IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool unzVxbtGRmQZzSvYceNVtoUGFLPd.BsgehaiWaTDIVAjKTpeWrtLjZWiM(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in EymsnWWXHySlmhDLNDpjBUfCERJH
					return this.EymsnWWXHySlmhDLNDpjBUfCERJH(P_0);
				}

				public bool uvXhkXTLcSZvOmMlwuChxuNXpgMV(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != oTTptnhmktacKffEtovqtGUvdONQ)
					{
						return false;
					}
					return EymsnWWXHySlmhDLNDpjBUfCERJH(P_0.id);
				}

				public int aLTukwVBmAMZPnIyIdgjTaoDtgPN(int P_0)
				{
					if (oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Keyboard || oTTptnhmktacKffEtovqtGUvdONQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < fEGuhlibMLXgMCXPBKkNpHVgfNMO.Count; i++)
					{
						if (fEGuhlibMLXgMCXPBKkNpHVgfNMO[i].IXFfJcQlRcjJSXDHlZIdknOrcNrEA.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int unzVxbtGRmQZzSvYceNVtoUGFLPd.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in aLTukwVBmAMZPnIyIdgjTaoDtgPN
					return this.aLTukwVBmAMZPnIyIdgjTaoDtgPN(P_0);
				}

				public int EUqUcyILAbjbiRhYLKZJARMbQCXK(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != oTTptnhmktacKffEtovqtGUvdONQ)
					{
						return -1;
					}
					return aLTukwVBmAMZPnIyIdgjTaoDtgPN(P_0.id);
				}

				public int VeOLEVunrRIoORqomDvnXHGbKMxl(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < fEGuhlibMLXgMCXPBKkNpHVgfNMO.Count; i++)
					{
						if (fEGuhlibMLXgMCXPBKkNpHVgfNMO[i].IXFfJcQlRcjJSXDHlZIdknOrcNrEA.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int unzVxbtGRmQZzSvYceNVtoUGFLPd.AyfUalmighPUhWsTnbjlERkmLjfr(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in VeOLEVunrRIoORqomDvnXHGbKMxl
					return this.VeOLEVunrRIoORqomDvnXHGbKMxl(P_0);
				}

				public void QYddAujwdPIPaCJfNwbWcufLRHTQ()
				{
					fEGuhlibMLXgMCXPBKkNpHVgfNMO.Clear();
					TNEpwCBCfOfeQJOiSbaaumnFLhWBA.Clear();
				}

				void unzVxbtGRmQZzSvYceNVtoUGFLPd.rathYiUMZUILQLDtwGIGWMqiANoKA()
				{
					//ILSpy generated this explicit interface implementation from .override directive in QYddAujwdPIPaCJfNwbWcufLRHTQ
					this.QYddAujwdPIPaCJfNwbWcufLRHTQ();
				}

				hfLYAzMldWckrgTmUxrPPSWxmrCj unzVxbtGRmQZzSvYceNVtoUGFLPd.GetEntry(int controllerId)
				{
					return yoVmDOIjkepJezQNZERxEAbGdPtdA(controllerId);
				}

				hfLYAzMldWckrgTmUxrPPSWxmrCj unzVxbtGRmQZzSvYceNVtoUGFLPd.GetEntry(Controller controller)
				{
					if (controller as _0001 == null)
					{
						return null;
					}
					return IAJgNBDkMqMiXvxtdBzRzMMQonBe(controller as _0001);
				}

				void unzVxbtGRmQZzSvYceNVtoUGFLPd.AddEntry(hfLYAzMldWckrgTmUxrPPSWxmrCj entry)
				{
					OwdKURULOylBLcuiTGHICOiuJgxQ((bYDcyWECHLgfltcQBjcCpqKRnGVv)entry);
				}

				void unzVxbtGRmQZzSvYceNVtoUGFLPd.RemoveController(Controller controller)
				{
					XUzBezvbZLuNRqNqZdPuJlVLwsYOA(controller as _0001);
				}

				Controller unzVxbtGRmQZzSvYceNVtoUGFLPd.GetController(int controllerId)
				{
					return vHZEYGWPbXdkITvqEqYLxDnueIxY(controllerId);
				}

				bool unzVxbtGRmQZzSvYceNVtoUGFLPd.Contains(Controller controller)
				{
					return uvXhkXTLcSZvOmMlwuChxuNXpgMV(controller as _0001);
				}

				int unzVxbtGRmQZzSvYceNVtoUGFLPd.IndexOf(Controller controller)
				{
					return EUqUcyILAbjbiRhYLKZJARMbQCXK(controller as _0001);
				}

				Controller unzVxbtGRmQZzSvYceNVtoUGFLPd.GetControllerWithTag(string tag)
				{
					int num = VeOLEVunrRIoORqomDvnXHGbKMxl(tag);
					if (num < 0)
					{
						return null;
					}
					return fEGuhlibMLXgMCXPBKkNpHVgfNMO[num].IXFfJcQlRcjJSXDHlZIdknOrcNrEA;
				}
			}

			internal class wOaGkOwKQRDPDjoJiYyBamBnEPjC
			{
				public readonly int nQoHyMZYKlXumNJJFucpVpPhPqyH;

				private ControllerType[] RPePBqVAWygubmkYVMFoPRaLscMy;

				private unzVxbtGRmQZzSvYceNVtoUGFLPd[] IjPBotFTSpgvFxTNatGrUkClgtzp;

				public unzVxbtGRmQZzSvYceNVtoUGFLPd pfUhQqMOQUcMOBkLkFFSadSuHYzqA(int P_0)
				{
					return IjPBotFTSpgvFxTNatGrUkClgtzp[P_0];
				}

				public ControllerType mElCMzgxjPgeRvvlDnlkQMRNcWthA(int P_0)
				{
					return RPePBqVAWygubmkYVMFoPRaLscMy[P_0];
				}

				public wOaGkOwKQRDPDjoJiYyBamBnEPjC(int P_0)
				{
					nQoHyMZYKlXumNJJFucpVpPhPqyH = MathTools.Max(0, P_0);
					RPePBqVAWygubmkYVMFoPRaLscMy = new ControllerType[P_0];
					IjPBotFTSpgvFxTNatGrUkClgtzp = new unzVxbtGRmQZzSvYceNVtoUGFLPd[P_0];
				}

				public unzVxbtGRmQZzSvYceNVtoUGFLPd fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType P_0)
				{
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						if (P_0 == RPePBqVAWygubmkYVMFoPRaLscMy[i])
						{
							return IjPBotFTSpgvFxTNatGrUkClgtzp[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void RVkHnwTSgTBHrpRuripGHORPPnoB(int P_0, ControllerType P_1, unzVxbtGRmQZzSvYceNVtoUGFLPd P_2)
				{
					RPePBqVAWygubmkYVMFoPRaLscMy[P_0] = P_1;
					IjPBotFTSpgvFxTNatGrUkClgtzp[P_0] = P_2;
				}
			}

			private class fALzHtOiVzaKOePkTTRfslfNFuDTA
			{
				public class PBCZTSFgsbIkElJkuEOyibACCLaT
				{
					public int npXVqbLQhdrjJIrnKqhjcFXSVGBY;

					public global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> YWDCBsksBJiokrUWqltxMJNgsBzrA;

					public double zwfCVCcJhGEqFBWDnqIuWnKJezOk;

					public PBCZTSFgsbIkElJkuEOyibACCLaT(int P_0, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> P_1, double P_2)
					{
						npXVqbLQhdrjJIrnKqhjcFXSVGBY = P_0;
						YWDCBsksBJiokrUWqltxMJNgsBzrA = P_1;
						zwfCVCcJhGEqFBWDnqIuWnKJezOk = P_2;
					}
				}

				private readonly List<PBCZTSFgsbIkElJkuEOyibACCLaT> ajoVQjikyJBEBVAtiEVzYIgmkQnp;

				private readonly Player FGOiHEAgmqmOTXcRDbiqEMsDCcDy;

				public fALzHtOiVzaKOePkTTRfslfNFuDTA(Player P_0)
				{
					FGOiHEAgmqmOTXcRDbiqEMsDCcDy = P_0;
					ajoVQjikyJBEBVAtiEVzYIgmkQnp = new List<PBCZTSFgsbIkElJkuEOyibACCLaT>();
				}

				public void RjrJNviSShgBdtqhJifSAJGsDecKA(Joystick P_0, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> P_1)
				{
					for (int i = 0; i < ajoVQjikyJBEBVAtiEVzYIgmkQnp.Count; i++)
					{
						PBCZTSFgsbIkElJkuEOyibACCLaT pBCZTSFgsbIkElJkuEOyibACCLaT = ajoVQjikyJBEBVAtiEVzYIgmkQnp[i];
						if (pBCZTSFgsbIkElJkuEOyibACCLaT.npXVqbLQhdrjJIrnKqhjcFXSVGBY == P_0.id)
						{
							pBCZTSFgsbIkElJkuEOyibACCLaT.YWDCBsksBJiokrUWqltxMJNgsBzrA = P_1;
							pBCZTSFgsbIkElJkuEOyibACCLaT.zwfCVCcJhGEqFBWDnqIuWnKJezOk = ReInput.realTime;
							return;
						}
					}
					PBCZTSFgsbIkElJkuEOyibACCLaT item = new PBCZTSFgsbIkElJkuEOyibACCLaT(P_0.id, P_1, ReInput.realTime);
					ajoVQjikyJBEBVAtiEVzYIgmkQnp.Add(item);
				}

				public void XPEGVPiUiDmECOTmlAliQkZBsMwn(yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv P_0)
				{
					RjrJNviSShgBdtqhJifSAJGsDecKA(P_0.IXFfJcQlRcjJSXDHlZIdknOrcNrEA, P_0.HCqsUTYybVMCVwCYQIskQMgrlygr);
				}

				public void LKHntflETRpLKIgsFwjVjUTpTlcA()
				{
					for (int i = 0; i < ajoVQjikyJBEBVAtiEVzYIgmkQnp.Count; i++)
					{
						if (!FGOiHEAgmqmOTXcRDbiqEMsDCcDy.controllers.ContainsController(ControllerType.Joystick, ajoVQjikyJBEBVAtiEVzYIgmkQnp[i].npXVqbLQhdrjJIrnKqhjcFXSVGBY))
						{
							ajoVQjikyJBEBVAtiEVzYIgmkQnp[i].YWDCBsksBJiokrUWqltxMJNgsBzrA = null;
						}
					}
				}

				public PBCZTSFgsbIkElJkuEOyibACCLaT EmuKMJVOtciyrJfMSfycJsXauaPK(int P_0)
				{
					int num = BdmUAxFKSwseJCXMqCenYddbxwqE(P_0);
					if (num < 0)
					{
						return null;
					}
					return ajoVQjikyJBEBVAtiEVzYIgmkQnp[num];
				}

				public bool iMDxPeOjREvWSqdThajHoDSOKCow(int P_0)
				{
					for (int i = 0; i < ajoVQjikyJBEBVAtiEVzYIgmkQnp.Count; i++)
					{
						if (ajoVQjikyJBEBVAtiEVzYIgmkQnp[i].npXVqbLQhdrjJIrnKqhjcFXSVGBY == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int BdmUAxFKSwseJCXMqCenYddbxwqE(int P_0)
				{
					for (int i = 0; i < ajoVQjikyJBEBVAtiEVzYIgmkQnp.Count; i++)
					{
						if (ajoVQjikyJBEBVAtiEVzYIgmkQnp[i].npXVqbLQhdrjJIrnKqhjcFXSVGBY == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void BqgBcqjyLqwRboYOYXfuMZVNjryj()
				{
					ajoVQjikyJBEBVAtiEVzYIgmkQnp.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class GZyxMkgBEISaAFXojLMEJLLBdOTc : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int rpJoEvXIOfJIjkAGaVjCDemPGage;

					private ActionElementMap LOZevAAlEtPWVWDVaEDsrJQrGsJFA;

					private int MJrTGxgClJdMDdaQXwaunzjoFCBbA;

					public MapHelper MlCJkkOvZrSQmXhSJCAORzvBpbcr;

					private int CypDDnGXlEgUTlBOULArzWKKBjRz;

					public int edigFzkAywkWwcDIltQQkveLRcdAA;

					private bool aVHMCbqGPtYggHzmiaCfSDdrvdvc;

					public bool GJTfEUafKoPwWxAtiZbSuRfmhneSA;

					private int mIxMXGnEdRvyCYGrqBIjWbPZqexg;

					private int dBDyoamhHOomgYQvujEAfwoUJBcF;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd HquubBDEyDqeCczqctlfeUNFNSTg;

					private int GCNPViwsQNddcEcXKhfUdRAbNYph;

					private int svduftvAePElnDochAnqNLwbEtVg;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ qNePldwyaftrPZQcfHvKTmlYpzok;

					private int WKZOhykWBHEuHjFIBwavrjptHuVE;

					private int UXnGjRPxFaHMieFHPsnzNAcEkZSf;

					private IEnumerator<ActionElementMap> HGszitvjUrHkpogmYHdDVWcsRrXG;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return LOZevAAlEtPWVWDVaEDsrJQrGsJFA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LOZevAAlEtPWVWDVaEDsrJQrGsJFA;
						}
					}

					[DebuggerHidden]
					public GZyxMkgBEISaAFXojLMEJLLBdOTc(int P_0)
					{
						rpJoEvXIOfJIjkAGaVjCDemPGage = P_0;
						MJrTGxgClJdMDdaQXwaunzjoFCBbA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rpJoEvXIOfJIjkAGaVjCDemPGage;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								krRRfLisRWTgiiyTiTZazwhekXrV();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rpJoEvXIOfJIjkAGaVjCDemPGage;
							MapHelper mlCJkkOvZrSQmXhSJCAORzvBpbcr = MlCJkkOvZrSQmXhSJCAORzvBpbcr;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								rpJoEvXIOfJIjkAGaVjCDemPGage = -3;
								goto IL_0177;
							}
							rpJoEvXIOfJIjkAGaVjCDemPGage = -1;
							if (ReInput._id != mlCJkkOvZrSQmXhSJCAORzvBpbcr.ZlswVIRxaKsbbROVvxEyieXLglZjA)
							{
								ReInput.CheckInitialized(mlCJkkOvZrSQmXhSJCAORzvBpbcr.ZlswVIRxaKsbbROVvxEyieXLglZjA);
								return false;
							}
							if (CypDDnGXlEgUTlBOULArzWKKBjRz < 0)
							{
								return false;
							}
							mIxMXGnEdRvyCYGrqBIjWbPZqexg = mlCJkkOvZrSQmXhSJCAORzvBpbcr.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
							dBDyoamhHOomgYQvujEAfwoUJBcF = 0;
							goto IL_01f7;
							IL_0177:
							if (HGszitvjUrHkpogmYHdDVWcsRrXG.MoveNext())
							{
								ActionElementMap current = HGszitvjUrHkpogmYHdDVWcsRrXG.Current;
								LOZevAAlEtPWVWDVaEDsrJQrGsJFA = current;
								rpJoEvXIOfJIjkAGaVjCDemPGage = 1;
								return true;
							}
							krRRfLisRWTgiiyTiTZazwhekXrV();
							HGszitvjUrHkpogmYHdDVWcsRrXG = null;
							goto IL_0191;
							IL_0191:
							UXnGjRPxFaHMieFHPsnzNAcEkZSf++;
							goto IL_01a3;
							IL_01cd:
							if (svduftvAePElnDochAnqNLwbEtVg < GCNPViwsQNddcEcXKhfUdRAbNYph)
							{
								qNePldwyaftrPZQcfHvKTmlYpzok = HquubBDEyDqeCczqctlfeUNFNSTg.XyKTgMxvPKsPsAOqAWrzShIBzUTi(svduftvAePElnDochAnqNLwbEtVg).XCfFEHCAovUlErZTLVujHEbwOdRG;
								WKZOhykWBHEuHjFIBwavrjptHuVE = qNePldwyaftrPZQcfHvKTmlYpzok.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								UXnGjRPxFaHMieFHPsnzNAcEkZSf = 0;
								goto IL_01a3;
							}
							HquubBDEyDqeCczqctlfeUNFNSTg = null;
							dBDyoamhHOomgYQvujEAfwoUJBcF++;
							goto IL_01f7;
							IL_01a3:
							if (UXnGjRPxFaHMieFHPsnzNAcEkZSf < WKZOhykWBHEuHjFIBwavrjptHuVE)
							{
								if (qNePldwyaftrPZQcfHvKTmlYpzok.vTSKHbrOptkhUmIMjLsBXHAVebGj(UXnGjRPxFaHMieFHPsnzNAcEkZSf) is ControllerMapWithAxes controllerMapWithAxes && (!aVHMCbqGPtYggHzmiaCfSDdrvdvc || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(CypDDnGXlEgUTlBOULArzWKKBjRz))
								{
									HGszitvjUrHkpogmYHdDVWcsRrXG = controllerMapWithAxes.AxisMapsWithAction(CypDDnGXlEgUTlBOULArzWKKBjRz, aVHMCbqGPtYggHzmiaCfSDdrvdvc).GetEnumerator();
									rpJoEvXIOfJIjkAGaVjCDemPGage = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							qNePldwyaftrPZQcfHvKTmlYpzok = null;
							svduftvAePElnDochAnqNLwbEtVg++;
							goto IL_01cd;
							IL_01f7:
							if (dBDyoamhHOomgYQvujEAfwoUJBcF < mIxMXGnEdRvyCYGrqBIjWbPZqexg)
							{
								HquubBDEyDqeCczqctlfeUNFNSTg = mlCJkkOvZrSQmXhSJCAORzvBpbcr.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(dBDyoamhHOomgYQvujEAfwoUJBcF);
								GCNPViwsQNddcEcXKhfUdRAbNYph = HquubBDEyDqeCczqctlfeUNFNSTg.umplaoBWNrHpDalRCquleOiTParq;
								svduftvAePElnDochAnqNLwbEtVg = 0;
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

					private void krRRfLisRWTgiiyTiTZazwhekXrV()
					{
						rpJoEvXIOfJIjkAGaVjCDemPGage = -1;
						if (HGszitvjUrHkpogmYHdDVWcsRrXG != null)
						{
							HGszitvjUrHkpogmYHdDVWcsRrXG.Dispose();
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
						GZyxMkgBEISaAFXojLMEJLLBdOTc gZyxMkgBEISaAFXojLMEJLLBdOTc;
						if (rpJoEvXIOfJIjkAGaVjCDemPGage == -2 && MJrTGxgClJdMDdaQXwaunzjoFCBbA == Environment.CurrentManagedThreadId)
						{
							rpJoEvXIOfJIjkAGaVjCDemPGage = 0;
							gZyxMkgBEISaAFXojLMEJLLBdOTc = this;
						}
						else
						{
							gZyxMkgBEISaAFXojLMEJLLBdOTc = new GZyxMkgBEISaAFXojLMEJLLBdOTc(0);
							gZyxMkgBEISaAFXojLMEJLLBdOTc.MlCJkkOvZrSQmXhSJCAORzvBpbcr = MlCJkkOvZrSQmXhSJCAORzvBpbcr;
						}
						gZyxMkgBEISaAFXojLMEJLLBdOTc.CypDDnGXlEgUTlBOULArzWKKBjRz = edigFzkAywkWwcDIltQQkveLRcdAA;
						gZyxMkgBEISaAFXojLMEJLLBdOTc.aVHMCbqGPtYggHzmiaCfSDdrvdvc = GJTfEUafKoPwWxAtiZbSuRfmhneSA;
						return gZyxMkgBEISaAFXojLMEJLLBdOTc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class NmKzoMZoxKjeQRAmzErFtqQLGPyo : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int gBIPVVTrbBYyySBpSHqOwGkJZncK;

					private ActionElementMap NjErBvSQEaIQyrQNDdGBwkpyaicK;

					private int xNFBWTSBJAQIiGYnWKBDZtRbZuYC;

					public MapHelper MdwgWPcFTloWYZaeqPnEetZgdbFYb;

					private int UJBayalYyBblDAegklIPeFLCqvLj;

					public int YiiQEuKvYGQMEPmMqhneHhQvkBxW;

					private bool MgHaJzUxlRhTqFfzFnLsvOhAlLTsA;

					public bool sZZODyLGZjGetFojUxFRNcwGtYznA;

					private int dHELVMdgXtKhBvJMLzfZoSFpDbvR;

					private int ofdwEtxqWWVzQYniPRnrTPSMKLbD;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd bdaeoeYYdXfOuqblbAWXaNqRcDtcA;

					private int qhGkEQbtiQADqvvtYOIkpMUlJuPV;

					private int OkZTKJrUEqSedAavDFCALYAUNPCd;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ SLZLTENflTZQXasvzljKUZgmVHKk;

					private int DYzXvtYTftufmlxjDePqcWstcGFt;

					private int aPCIrvMceSsTvYiuKKdqrgNAfXDbA;

					private IEnumerator<ActionElementMap> EtmxQaBlEDsXoKPJisHFbBhufUeh;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return NjErBvSQEaIQyrQNDdGBwkpyaicK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NjErBvSQEaIQyrQNDdGBwkpyaicK;
						}
					}

					[DebuggerHidden]
					public NmKzoMZoxKjeQRAmzErFtqQLGPyo(int P_0)
					{
						gBIPVVTrbBYyySBpSHqOwGkJZncK = P_0;
						xNFBWTSBJAQIiGYnWKBDZtRbZuYC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = gBIPVVTrbBYyySBpSHqOwGkJZncK;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								BhpUnfzdFgKIFfgHRHoXBOtKIurnA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = gBIPVVTrbBYyySBpSHqOwGkJZncK;
							MapHelper mdwgWPcFTloWYZaeqPnEetZgdbFYb = MdwgWPcFTloWYZaeqPnEetZgdbFYb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								gBIPVVTrbBYyySBpSHqOwGkJZncK = -3;
								goto IL_016c;
							}
							gBIPVVTrbBYyySBpSHqOwGkJZncK = -1;
							if (ReInput._id != mdwgWPcFTloWYZaeqPnEetZgdbFYb.ZlswVIRxaKsbbROVvxEyieXLglZjA)
							{
								ReInput.CheckInitialized(mdwgWPcFTloWYZaeqPnEetZgdbFYb.ZlswVIRxaKsbbROVvxEyieXLglZjA);
								return false;
							}
							if (UJBayalYyBblDAegklIPeFLCqvLj < 0)
							{
								return false;
							}
							dHELVMdgXtKhBvJMLzfZoSFpDbvR = mdwgWPcFTloWYZaeqPnEetZgdbFYb.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
							ofdwEtxqWWVzQYniPRnrTPSMKLbD = 0;
							goto IL_01ec;
							IL_016c:
							if (EtmxQaBlEDsXoKPJisHFbBhufUeh.MoveNext())
							{
								ActionElementMap current = EtmxQaBlEDsXoKPJisHFbBhufUeh.Current;
								NjErBvSQEaIQyrQNDdGBwkpyaicK = current;
								gBIPVVTrbBYyySBpSHqOwGkJZncK = 1;
								return true;
							}
							BhpUnfzdFgKIFfgHRHoXBOtKIurnA();
							EtmxQaBlEDsXoKPJisHFbBhufUeh = null;
							goto IL_0186;
							IL_0186:
							aPCIrvMceSsTvYiuKKdqrgNAfXDbA++;
							goto IL_0198;
							IL_01c2:
							if (OkZTKJrUEqSedAavDFCALYAUNPCd < qhGkEQbtiQADqvvtYOIkpMUlJuPV)
							{
								SLZLTENflTZQXasvzljKUZgmVHKk = bdaeoeYYdXfOuqblbAWXaNqRcDtcA.XyKTgMxvPKsPsAOqAWrzShIBzUTi(OkZTKJrUEqSedAavDFCALYAUNPCd).XCfFEHCAovUlErZTLVujHEbwOdRG;
								DYzXvtYTftufmlxjDePqcWstcGFt = SLZLTENflTZQXasvzljKUZgmVHKk.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								aPCIrvMceSsTvYiuKKdqrgNAfXDbA = 0;
								goto IL_0198;
							}
							bdaeoeYYdXfOuqblbAWXaNqRcDtcA = null;
							ofdwEtxqWWVzQYniPRnrTPSMKLbD++;
							goto IL_01ec;
							IL_0198:
							if (aPCIrvMceSsTvYiuKKdqrgNAfXDbA < DYzXvtYTftufmlxjDePqcWstcGFt)
							{
								ControllerMap controllerMap = SLZLTENflTZQXasvzljKUZgmVHKk.vTSKHbrOptkhUmIMjLsBXHAVebGj(aPCIrvMceSsTvYiuKKdqrgNAfXDbA);
								if ((!MgHaJzUxlRhTqFfzFnLsvOhAlLTsA || controllerMap.enabled) && controllerMap.ContainsAction(UJBayalYyBblDAegklIPeFLCqvLj))
								{
									EtmxQaBlEDsXoKPJisHFbBhufUeh = controllerMap.ButtonMapsWithAction(UJBayalYyBblDAegklIPeFLCqvLj, MgHaJzUxlRhTqFfzFnLsvOhAlLTsA).GetEnumerator();
									gBIPVVTrbBYyySBpSHqOwGkJZncK = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							SLZLTENflTZQXasvzljKUZgmVHKk = null;
							OkZTKJrUEqSedAavDFCALYAUNPCd++;
							goto IL_01c2;
							IL_01ec:
							if (ofdwEtxqWWVzQYniPRnrTPSMKLbD < dHELVMdgXtKhBvJMLzfZoSFpDbvR)
							{
								bdaeoeYYdXfOuqblbAWXaNqRcDtcA = mdwgWPcFTloWYZaeqPnEetZgdbFYb.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(ofdwEtxqWWVzQYniPRnrTPSMKLbD);
								qhGkEQbtiQADqvvtYOIkpMUlJuPV = bdaeoeYYdXfOuqblbAWXaNqRcDtcA.umplaoBWNrHpDalRCquleOiTParq;
								OkZTKJrUEqSedAavDFCALYAUNPCd = 0;
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

					private void BhpUnfzdFgKIFfgHRHoXBOtKIurnA()
					{
						gBIPVVTrbBYyySBpSHqOwGkJZncK = -1;
						if (EtmxQaBlEDsXoKPJisHFbBhufUeh != null)
						{
							EtmxQaBlEDsXoKPJisHFbBhufUeh.Dispose();
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
						NmKzoMZoxKjeQRAmzErFtqQLGPyo nmKzoMZoxKjeQRAmzErFtqQLGPyo;
						if (gBIPVVTrbBYyySBpSHqOwGkJZncK == -2 && xNFBWTSBJAQIiGYnWKBDZtRbZuYC == Environment.CurrentManagedThreadId)
						{
							gBIPVVTrbBYyySBpSHqOwGkJZncK = 0;
							nmKzoMZoxKjeQRAmzErFtqQLGPyo = this;
						}
						else
						{
							nmKzoMZoxKjeQRAmzErFtqQLGPyo = new NmKzoMZoxKjeQRAmzErFtqQLGPyo(0);
							nmKzoMZoxKjeQRAmzErFtqQLGPyo.MdwgWPcFTloWYZaeqPnEetZgdbFYb = MdwgWPcFTloWYZaeqPnEetZgdbFYb;
						}
						nmKzoMZoxKjeQRAmzErFtqQLGPyo.UJBayalYyBblDAegklIPeFLCqvLj = YiiQEuKvYGQMEPmMqhneHhQvkBxW;
						nmKzoMZoxKjeQRAmzErFtqQLGPyo.MgHaJzUxlRhTqFfzFnLsvOhAlLTsA = sZZODyLGZjGetFojUxFRNcwGtYznA;
						return nmKzoMZoxKjeQRAmzErFtqQLGPyo;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class EBNlXMtlKsrlMELQqKgScvapQBHc : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int xDwdecynHIRzcNxNFFvQhfSmqXVS;

					private ActionElementMap qwstdpybwsQuekkEUvnsuejRCcgM;

					private int TblUkEWIlFBjIdIMmgxOwydAbxZhA;

					private int cnsGXNMdCduUWoSXTseHJnbiYCxB;

					public int idfVULaDTVxqJPCpWcWQuXMQPuZ;

					public MapHelper XqZkjlyJBysBlXfKNWjIVSRCDaUN;

					private ControllerType svRPvyNRgZMTcFWoouXHRfAAKZvB;

					public ControllerType pXiELUuPvMWyyLGKROIBtFgZJJzx;

					private bool JFAzzlPDCIhueYRIISYxEaHiReqv;

					public bool CENCkOMqYhTFUfAOaftptEdPECaHA;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd YDNMGlnAQPgavEgIcrDzBFjxwvpMA;

					private int peOzGahUsOfDRqpNhbRncWTKicvBA;

					private IList<ControllerMap> wdpCfHIKgjdpHCNxjTIAnHJWSJZjb;

					private int DQJcKYEtFSoWVNSBxRTzWMIoiITeA;

					private IEnumerator<ActionElementMap> KoedOUlkqLehhVYmXuZgWFudAlvS;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return qwstdpybwsQuekkEUvnsuejRCcgM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qwstdpybwsQuekkEUvnsuejRCcgM;
						}
					}

					[DebuggerHidden]
					public EBNlXMtlKsrlMELQqKgScvapQBHc(int P_0)
					{
						xDwdecynHIRzcNxNFFvQhfSmqXVS = P_0;
						TblUkEWIlFBjIdIMmgxOwydAbxZhA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = xDwdecynHIRzcNxNFFvQhfSmqXVS;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								kQFEsZkJWKzBssJxMGjqBUyuyqwAA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = xDwdecynHIRzcNxNFFvQhfSmqXVS;
							MapHelper xqZkjlyJBysBlXfKNWjIVSRCDaUN = XqZkjlyJBysBlXfKNWjIVSRCDaUN;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								xDwdecynHIRzcNxNFFvQhfSmqXVS = -3;
								goto IL_0150;
							}
							xDwdecynHIRzcNxNFFvQhfSmqXVS = -1;
							if (cnsGXNMdCduUWoSXTseHJnbiYCxB < 0)
							{
								return false;
							}
							YDNMGlnAQPgavEgIcrDzBFjxwvpMA = xqZkjlyJBysBlXfKNWjIVSRCDaUN.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(svRPvyNRgZMTcFWoouXHRfAAKZvB);
							peOzGahUsOfDRqpNhbRncWTKicvBA = 0;
							goto IL_01ab;
							IL_0150:
							if (KoedOUlkqLehhVYmXuZgWFudAlvS.MoveNext())
							{
								ActionElementMap current = KoedOUlkqLehhVYmXuZgWFudAlvS.Current;
								qwstdpybwsQuekkEUvnsuejRCcgM = current;
								xDwdecynHIRzcNxNFFvQhfSmqXVS = 1;
								return true;
							}
							kQFEsZkJWKzBssJxMGjqBUyuyqwAA();
							KoedOUlkqLehhVYmXuZgWFudAlvS = null;
							goto IL_016a;
							IL_017c:
							if (DQJcKYEtFSoWVNSBxRTzWMIoiITeA < wdpCfHIKgjdpHCNxjTIAnHJWSJZjb.Count)
							{
								if (!(wdpCfHIKgjdpHCNxjTIAnHJWSJZjb[DQJcKYEtFSoWVNSBxRTzWMIoiITeA] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!JFAzzlPDCIhueYRIISYxEaHiReqv || wdpCfHIKgjdpHCNxjTIAnHJWSJZjb[DQJcKYEtFSoWVNSBxRTzWMIoiITeA].enabled) && wdpCfHIKgjdpHCNxjTIAnHJWSJZjb[DQJcKYEtFSoWVNSBxRTzWMIoiITeA].ContainsAction(cnsGXNMdCduUWoSXTseHJnbiYCxB))
								{
									KoedOUlkqLehhVYmXuZgWFudAlvS = (wdpCfHIKgjdpHCNxjTIAnHJWSJZjb[DQJcKYEtFSoWVNSBxRTzWMIoiITeA] as ControllerMapWithAxes).AxisMapsWithAction(cnsGXNMdCduUWoSXTseHJnbiYCxB, JFAzzlPDCIhueYRIISYxEaHiReqv).GetEnumerator();
									xDwdecynHIRzcNxNFFvQhfSmqXVS = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							wdpCfHIKgjdpHCNxjTIAnHJWSJZjb = null;
							peOzGahUsOfDRqpNhbRncWTKicvBA++;
							goto IL_01ab;
							IL_016a:
							DQJcKYEtFSoWVNSBxRTzWMIoiITeA++;
							goto IL_017c;
							IL_01ab:
							if (peOzGahUsOfDRqpNhbRncWTKicvBA < YDNMGlnAQPgavEgIcrDzBFjxwvpMA.umplaoBWNrHpDalRCquleOiTParq)
							{
								wdpCfHIKgjdpHCNxjTIAnHJWSJZjb = YDNMGlnAQPgavEgIcrDzBFjxwvpMA.XyKTgMxvPKsPsAOqAWrzShIBzUTi(peOzGahUsOfDRqpNhbRncWTKicvBA).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
								DQJcKYEtFSoWVNSBxRTzWMIoiITeA = 0;
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

					private void kQFEsZkJWKzBssJxMGjqBUyuyqwAA()
					{
						xDwdecynHIRzcNxNFFvQhfSmqXVS = -1;
						if (KoedOUlkqLehhVYmXuZgWFudAlvS != null)
						{
							KoedOUlkqLehhVYmXuZgWFudAlvS.Dispose();
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
						EBNlXMtlKsrlMELQqKgScvapQBHc eBNlXMtlKsrlMELQqKgScvapQBHc;
						if (xDwdecynHIRzcNxNFFvQhfSmqXVS == -2 && TblUkEWIlFBjIdIMmgxOwydAbxZhA == Environment.CurrentManagedThreadId)
						{
							xDwdecynHIRzcNxNFFvQhfSmqXVS = 0;
							eBNlXMtlKsrlMELQqKgScvapQBHc = this;
						}
						else
						{
							eBNlXMtlKsrlMELQqKgScvapQBHc = new EBNlXMtlKsrlMELQqKgScvapQBHc(0);
							eBNlXMtlKsrlMELQqKgScvapQBHc.XqZkjlyJBysBlXfKNWjIVSRCDaUN = XqZkjlyJBysBlXfKNWjIVSRCDaUN;
						}
						eBNlXMtlKsrlMELQqKgScvapQBHc.svRPvyNRgZMTcFWoouXHRfAAKZvB = pXiELUuPvMWyyLGKROIBtFgZJJzx;
						eBNlXMtlKsrlMELQqKgScvapQBHc.cnsGXNMdCduUWoSXTseHJnbiYCxB = idfVULaDTVxqJPCpWcWQuXMQPuZ;
						eBNlXMtlKsrlMELQqKgScvapQBHc.JFAzzlPDCIhueYRIISYxEaHiReqv = CENCkOMqYhTFUfAOaftptEdPECaHA;
						return eBNlXMtlKsrlMELQqKgScvapQBHc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class WWqrGeJopnPMCMywlmtqRMmTJBRG : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int mFajTZinYedYSATanMVPCeRapSQr;

					private ActionElementMap JjTkPIvkrCqhTcZnOuYhtvWtHFBP;

					private int xMWEtscVlTGetQpMrJXLFMsArGPlb;

					private int DDiHVOvEfpbjjHMshpXWsFXwkxkrA;

					public int SNRQPhHAabhdyeWblpElaWTjjFwrA;

					public MapHelper paNnxLRXIMOFlFEeCJvuSVZtDzqu;

					private ControllerType qCwzZDTiIesPrtlqxzLdlCYqWIQg;

					public ControllerType FrYzbZopyOmOUozmBVqzlqPwfsDk;

					private int tASwWfLoDsCsNdTCTZivkqXLsvEF;

					public int ulrhAXGBEbyczHzzfeXuRFKLFopv;

					private bool sFHnNmMcZfBniLtgFsxojwiEfUDq;

					public bool FrxpGrRxFcBpfrkjdJpnDHNxVYUI;

					private IList<ControllerMap> yKOONFftXsxzxWEznaKoBvUvLPIJ;

					private int sQOkiOuGOtZuuUehYOAATHbwIoQy;

					private IEnumerator<ActionElementMap> iDDKrKYlrrRFEKOxxFvndBivKXiAb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return JjTkPIvkrCqhTcZnOuYhtvWtHFBP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JjTkPIvkrCqhTcZnOuYhtvWtHFBP;
						}
					}

					[DebuggerHidden]
					public WWqrGeJopnPMCMywlmtqRMmTJBRG(int P_0)
					{
						mFajTZinYedYSATanMVPCeRapSQr = P_0;
						xMWEtscVlTGetQpMrJXLFMsArGPlb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mFajTZinYedYSATanMVPCeRapSQr;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								xzJLNfSUorVhSvaPGRMyABTtfIRiA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = mFajTZinYedYSATanMVPCeRapSQr;
							MapHelper mapHelper = paNnxLRXIMOFlFEeCJvuSVZtDzqu;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mFajTZinYedYSATanMVPCeRapSQr = -3;
								goto IL_014f;
							}
							mFajTZinYedYSATanMVPCeRapSQr = -1;
							if (DDiHVOvEfpbjjHMshpXWsFXwkxkrA < 0)
							{
								return false;
							}
							unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(qCwzZDTiIesPrtlqxzLdlCYqWIQg);
							int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(tASwWfLoDsCsNdTCTZivkqXLsvEF);
							if (num2 < 0)
							{
								return false;
							}
							yKOONFftXsxzxWEznaKoBvUvLPIJ = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num2).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
							sQOkiOuGOtZuuUehYOAATHbwIoQy = 0;
							goto IL_017b;
							IL_014f:
							if (iDDKrKYlrrRFEKOxxFvndBivKXiAb.MoveNext())
							{
								ActionElementMap current = iDDKrKYlrrRFEKOxxFvndBivKXiAb.Current;
								JjTkPIvkrCqhTcZnOuYhtvWtHFBP = current;
								mFajTZinYedYSATanMVPCeRapSQr = 1;
								return true;
							}
							xzJLNfSUorVhSvaPGRMyABTtfIRiA();
							iDDKrKYlrrRFEKOxxFvndBivKXiAb = null;
							goto IL_0169;
							IL_017b:
							if (sQOkiOuGOtZuuUehYOAATHbwIoQy < yKOONFftXsxzxWEznaKoBvUvLPIJ.Count)
							{
								if (!(yKOONFftXsxzxWEznaKoBvUvLPIJ[sQOkiOuGOtZuuUehYOAATHbwIoQy] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!sFHnNmMcZfBniLtgFsxojwiEfUDq || yKOONFftXsxzxWEznaKoBvUvLPIJ[sQOkiOuGOtZuuUehYOAATHbwIoQy].enabled) && yKOONFftXsxzxWEznaKoBvUvLPIJ[sQOkiOuGOtZuuUehYOAATHbwIoQy].ContainsAction(DDiHVOvEfpbjjHMshpXWsFXwkxkrA))
								{
									iDDKrKYlrrRFEKOxxFvndBivKXiAb = (yKOONFftXsxzxWEznaKoBvUvLPIJ[sQOkiOuGOtZuuUehYOAATHbwIoQy] as ControllerMapWithAxes).AxisMapsWithAction(DDiHVOvEfpbjjHMshpXWsFXwkxkrA, sFHnNmMcZfBniLtgFsxojwiEfUDq).GetEnumerator();
									mFajTZinYedYSATanMVPCeRapSQr = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							sQOkiOuGOtZuuUehYOAATHbwIoQy++;
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

					private void xzJLNfSUorVhSvaPGRMyABTtfIRiA()
					{
						mFajTZinYedYSATanMVPCeRapSQr = -1;
						if (iDDKrKYlrrRFEKOxxFvndBivKXiAb != null)
						{
							iDDKrKYlrrRFEKOxxFvndBivKXiAb.Dispose();
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
						WWqrGeJopnPMCMywlmtqRMmTJBRG wWqrGeJopnPMCMywlmtqRMmTJBRG;
						if (mFajTZinYedYSATanMVPCeRapSQr == -2 && xMWEtscVlTGetQpMrJXLFMsArGPlb == Environment.CurrentManagedThreadId)
						{
							mFajTZinYedYSATanMVPCeRapSQr = 0;
							wWqrGeJopnPMCMywlmtqRMmTJBRG = this;
						}
						else
						{
							wWqrGeJopnPMCMywlmtqRMmTJBRG = new WWqrGeJopnPMCMywlmtqRMmTJBRG(0);
							wWqrGeJopnPMCMywlmtqRMmTJBRG.paNnxLRXIMOFlFEeCJvuSVZtDzqu = paNnxLRXIMOFlFEeCJvuSVZtDzqu;
						}
						wWqrGeJopnPMCMywlmtqRMmTJBRG.qCwzZDTiIesPrtlqxzLdlCYqWIQg = FrYzbZopyOmOUozmBVqzlqPwfsDk;
						wWqrGeJopnPMCMywlmtqRMmTJBRG.tASwWfLoDsCsNdTCTZivkqXLsvEF = ulrhAXGBEbyczHzzfeXuRFKLFopv;
						wWqrGeJopnPMCMywlmtqRMmTJBRG.DDiHVOvEfpbjjHMshpXWsFXwkxkrA = SNRQPhHAabhdyeWblpElaWTjjFwrA;
						wWqrGeJopnPMCMywlmtqRMmTJBRG.sFHnNmMcZfBniLtgFsxojwiEfUDq = FrxpGrRxFcBpfrkjdJpnDHNxVYUI;
						return wWqrGeJopnPMCMywlmtqRMmTJBRG;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class NundRmLQIKHQXhLCGQRNwFxafwGJA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int xRCdorIOExNCrcapdTfMcNOYyzWR;

					private ActionElementMap VHdcWAhyvqRTzeuVNIhedezNFHaV;

					private int lfUXqTiiZVmWfipNMPDPqHwTKidU;

					private int iGHfAszkIgjOkFeokqqTsxPGnOvz;

					public int UYYPDHapVYRIoFfmempHNdAgIIRBA;

					public MapHelper adOIdLxHdzWqitVFIIEVTaWxRVQq;

					private ControllerType KobSaZZLvmYKjUiAYGruVcfyfAQx;

					public ControllerType fujuSIfnlvgqheNeaKPAaaFGlFqy;

					private bool kkhlqHdmPnXxcqZNiIApkGxaCpLiA;

					public bool yvjFXxCFSBEQCWQbGlIGelCDJFIL;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd htlePHwcGuRHCekPiGSfpPKjSPgt;

					private int qJGoDzWaeuOftAbsiDbPUgiSOHDM;

					private IList<ControllerMap> kWAQnSZUlBjMdUxYLPMEfWUdVwnA;

					private int xRgDOYPujSJptSmliGxwMXNYyKrg;

					private IEnumerator<ActionElementMap> ZwtDgvJkTUbmyuLiVDhnhkmGNlSw;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return VHdcWAhyvqRTzeuVNIhedezNFHaV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VHdcWAhyvqRTzeuVNIhedezNFHaV;
						}
					}

					[DebuggerHidden]
					public NundRmLQIKHQXhLCGQRNwFxafwGJA(int P_0)
					{
						xRCdorIOExNCrcapdTfMcNOYyzWR = P_0;
						lfUXqTiiZVmWfipNMPDPqHwTKidU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = xRCdorIOExNCrcapdTfMcNOYyzWR;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								DJFfGuvmhNRreBtqbbNREMnYMvGjA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = xRCdorIOExNCrcapdTfMcNOYyzWR;
							MapHelper mapHelper = adOIdLxHdzWqitVFIIEVTaWxRVQq;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								xRCdorIOExNCrcapdTfMcNOYyzWR = -3;
								goto IL_012c;
							}
							xRCdorIOExNCrcapdTfMcNOYyzWR = -1;
							if (iGHfAszkIgjOkFeokqqTsxPGnOvz < 0)
							{
								return false;
							}
							htlePHwcGuRHCekPiGSfpPKjSPgt = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(KobSaZZLvmYKjUiAYGruVcfyfAQx);
							qJGoDzWaeuOftAbsiDbPUgiSOHDM = 0;
							goto IL_0187;
							IL_012c:
							if (ZwtDgvJkTUbmyuLiVDhnhkmGNlSw.MoveNext())
							{
								ActionElementMap current = ZwtDgvJkTUbmyuLiVDhnhkmGNlSw.Current;
								VHdcWAhyvqRTzeuVNIhedezNFHaV = current;
								xRCdorIOExNCrcapdTfMcNOYyzWR = 1;
								return true;
							}
							DJFfGuvmhNRreBtqbbNREMnYMvGjA();
							ZwtDgvJkTUbmyuLiVDhnhkmGNlSw = null;
							goto IL_0146;
							IL_0158:
							if (xRgDOYPujSJptSmliGxwMXNYyKrg < kWAQnSZUlBjMdUxYLPMEfWUdVwnA.Count)
							{
								if ((!kkhlqHdmPnXxcqZNiIApkGxaCpLiA || kWAQnSZUlBjMdUxYLPMEfWUdVwnA[xRgDOYPujSJptSmliGxwMXNYyKrg].enabled) && kWAQnSZUlBjMdUxYLPMEfWUdVwnA[xRgDOYPujSJptSmliGxwMXNYyKrg].ContainsAction(iGHfAszkIgjOkFeokqqTsxPGnOvz))
								{
									ZwtDgvJkTUbmyuLiVDhnhkmGNlSw = kWAQnSZUlBjMdUxYLPMEfWUdVwnA[xRgDOYPujSJptSmliGxwMXNYyKrg].ButtonMapsWithAction(iGHfAszkIgjOkFeokqqTsxPGnOvz, kkhlqHdmPnXxcqZNiIApkGxaCpLiA).GetEnumerator();
									xRCdorIOExNCrcapdTfMcNOYyzWR = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							kWAQnSZUlBjMdUxYLPMEfWUdVwnA = null;
							qJGoDzWaeuOftAbsiDbPUgiSOHDM++;
							goto IL_0187;
							IL_0146:
							xRgDOYPujSJptSmliGxwMXNYyKrg++;
							goto IL_0158;
							IL_0187:
							if (qJGoDzWaeuOftAbsiDbPUgiSOHDM < htlePHwcGuRHCekPiGSfpPKjSPgt.umplaoBWNrHpDalRCquleOiTParq)
							{
								kWAQnSZUlBjMdUxYLPMEfWUdVwnA = htlePHwcGuRHCekPiGSfpPKjSPgt.XyKTgMxvPKsPsAOqAWrzShIBzUTi(qJGoDzWaeuOftAbsiDbPUgiSOHDM).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
								xRgDOYPujSJptSmliGxwMXNYyKrg = 0;
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

					private void DJFfGuvmhNRreBtqbbNREMnYMvGjA()
					{
						xRCdorIOExNCrcapdTfMcNOYyzWR = -1;
						if (ZwtDgvJkTUbmyuLiVDhnhkmGNlSw != null)
						{
							ZwtDgvJkTUbmyuLiVDhnhkmGNlSw.Dispose();
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
						NundRmLQIKHQXhLCGQRNwFxafwGJA nundRmLQIKHQXhLCGQRNwFxafwGJA;
						if (xRCdorIOExNCrcapdTfMcNOYyzWR == -2 && lfUXqTiiZVmWfipNMPDPqHwTKidU == Environment.CurrentManagedThreadId)
						{
							xRCdorIOExNCrcapdTfMcNOYyzWR = 0;
							nundRmLQIKHQXhLCGQRNwFxafwGJA = this;
						}
						else
						{
							nundRmLQIKHQXhLCGQRNwFxafwGJA = new NundRmLQIKHQXhLCGQRNwFxafwGJA(0);
							nundRmLQIKHQXhLCGQRNwFxafwGJA.adOIdLxHdzWqitVFIIEVTaWxRVQq = adOIdLxHdzWqitVFIIEVTaWxRVQq;
						}
						nundRmLQIKHQXhLCGQRNwFxafwGJA.KobSaZZLvmYKjUiAYGruVcfyfAQx = fujuSIfnlvgqheNeaKPAaaFGlFqy;
						nundRmLQIKHQXhLCGQRNwFxafwGJA.iGHfAszkIgjOkFeokqqTsxPGnOvz = UYYPDHapVYRIoFfmempHNdAgIIRBA;
						nundRmLQIKHQXhLCGQRNwFxafwGJA.kkhlqHdmPnXxcqZNiIApkGxaCpLiA = yvjFXxCFSBEQCWQbGlIGelCDJFIL;
						return nundRmLQIKHQXhLCGQRNwFxafwGJA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class eWkUwmItgGoxTJQMFetmPWyMiieP : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int cNwwhgEGHLJZGquSllclqDNtwNyN;

					private ActionElementMap lXrXLxzdYZOzxwocpEprjmcXMHDm;

					private int QuOxZOaRGJEtIoUizMOsirKffSTc;

					private int TIGZdUefsGrRXRKuqFxZHUZBniAN;

					public int MnLWjQHpuLTEKIorCjYMdhNCFxci;

					public MapHelper tSJsZaOqNSrsLjYfjQShqkCfXQXE;

					private ControllerType neUctCbHbjYLXjqvxksdcbwfUyYoA;

					public ControllerType eyMFtJkrnnNysiSyZSEaSEDJvbkBA;

					private int ZjTauyCdsPGTXSfihkYerbWKTjqf;

					public int tUWjbrrFLnBmWNGBnvdtAydMzgx;

					private bool vpWfWSMDrxpKviSHwxiuFnVPrvTj;

					public bool oSBDdjciNGGIWsxMjmCUikEBrHVN;

					private IList<ControllerMap> zVQxjyfExLRXszEIFsjktQYASosB;

					private int yvVzXZhcfRkoebmJATZWhNNZELLE;

					private IEnumerator<ActionElementMap> rVAszyGzZtUPwSeebeHJdssfVDZj;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return lXrXLxzdYZOzxwocpEprjmcXMHDm;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lXrXLxzdYZOzxwocpEprjmcXMHDm;
						}
					}

					[DebuggerHidden]
					public eWkUwmItgGoxTJQMFetmPWyMiieP(int P_0)
					{
						cNwwhgEGHLJZGquSllclqDNtwNyN = P_0;
						QuOxZOaRGJEtIoUizMOsirKffSTc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cNwwhgEGHLJZGquSllclqDNtwNyN;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								KaTYnfmazUCVeawqOolNerXcMVsC();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = cNwwhgEGHLJZGquSllclqDNtwNyN;
							MapHelper mapHelper = tSJsZaOqNSrsLjYfjQShqkCfXQXE;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cNwwhgEGHLJZGquSllclqDNtwNyN = -3;
								goto IL_012b;
							}
							cNwwhgEGHLJZGquSllclqDNtwNyN = -1;
							if (TIGZdUefsGrRXRKuqFxZHUZBniAN < 0)
							{
								return false;
							}
							unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(neUctCbHbjYLXjqvxksdcbwfUyYoA);
							int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(ZjTauyCdsPGTXSfihkYerbWKTjqf);
							if (num2 < 0)
							{
								return false;
							}
							zVQxjyfExLRXszEIFsjktQYASosB = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num2).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
							yvVzXZhcfRkoebmJATZWhNNZELLE = 0;
							goto IL_0157;
							IL_012b:
							if (rVAszyGzZtUPwSeebeHJdssfVDZj.MoveNext())
							{
								ActionElementMap current = rVAszyGzZtUPwSeebeHJdssfVDZj.Current;
								lXrXLxzdYZOzxwocpEprjmcXMHDm = current;
								cNwwhgEGHLJZGquSllclqDNtwNyN = 1;
								return true;
							}
							KaTYnfmazUCVeawqOolNerXcMVsC();
							rVAszyGzZtUPwSeebeHJdssfVDZj = null;
							goto IL_0145;
							IL_0157:
							if (yvVzXZhcfRkoebmJATZWhNNZELLE < zVQxjyfExLRXszEIFsjktQYASosB.Count)
							{
								if ((!vpWfWSMDrxpKviSHwxiuFnVPrvTj || zVQxjyfExLRXszEIFsjktQYASosB[yvVzXZhcfRkoebmJATZWhNNZELLE].enabled) && zVQxjyfExLRXszEIFsjktQYASosB[yvVzXZhcfRkoebmJATZWhNNZELLE].ContainsAction(TIGZdUefsGrRXRKuqFxZHUZBniAN))
								{
									rVAszyGzZtUPwSeebeHJdssfVDZj = zVQxjyfExLRXszEIFsjktQYASosB[yvVzXZhcfRkoebmJATZWhNNZELLE].ButtonMapsWithAction(TIGZdUefsGrRXRKuqFxZHUZBniAN, vpWfWSMDrxpKviSHwxiuFnVPrvTj).GetEnumerator();
									cNwwhgEGHLJZGquSllclqDNtwNyN = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							yvVzXZhcfRkoebmJATZWhNNZELLE++;
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

					private void KaTYnfmazUCVeawqOolNerXcMVsC()
					{
						cNwwhgEGHLJZGquSllclqDNtwNyN = -1;
						if (rVAszyGzZtUPwSeebeHJdssfVDZj != null)
						{
							rVAszyGzZtUPwSeebeHJdssfVDZj.Dispose();
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
						eWkUwmItgGoxTJQMFetmPWyMiieP eWkUwmItgGoxTJQMFetmPWyMiieP2;
						if (cNwwhgEGHLJZGquSllclqDNtwNyN == -2 && QuOxZOaRGJEtIoUizMOsirKffSTc == Environment.CurrentManagedThreadId)
						{
							cNwwhgEGHLJZGquSllclqDNtwNyN = 0;
							eWkUwmItgGoxTJQMFetmPWyMiieP2 = this;
						}
						else
						{
							eWkUwmItgGoxTJQMFetmPWyMiieP2 = new eWkUwmItgGoxTJQMFetmPWyMiieP(0);
							eWkUwmItgGoxTJQMFetmPWyMiieP2.tSJsZaOqNSrsLjYfjQShqkCfXQXE = tSJsZaOqNSrsLjYfjQShqkCfXQXE;
						}
						eWkUwmItgGoxTJQMFetmPWyMiieP2.neUctCbHbjYLXjqvxksdcbwfUyYoA = eyMFtJkrnnNysiSyZSEaSEDJvbkBA;
						eWkUwmItgGoxTJQMFetmPWyMiieP2.ZjTauyCdsPGTXSfihkYerbWKTjqf = tUWjbrrFLnBmWNGBnvdtAydMzgx;
						eWkUwmItgGoxTJQMFetmPWyMiieP2.TIGZdUefsGrRXRKuqFxZHUZBniAN = MnLWjQHpuLTEKIorCjYMdhNCFxci;
						eWkUwmItgGoxTJQMFetmPWyMiieP2.vpWfWSMDrxpKviSHwxiuFnVPrvTj = oSBDdjciNGGIWsxMjmCUikEBrHVN;
						return eWkUwmItgGoxTJQMFetmPWyMiieP2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class mihDzncxnJvsufOPXPNEHpWmshzOA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int nhLoqTcMgulxkYbVlRDCEcKGCkqq;

					private ActionElementMap ZfEbrPPftoMbBIMwZYHlGdLdRSdX;

					private int RaZeIfFRlPbUMCMFeWvEtMPrObMMA;

					private int QGbNFqMtXBOnwKdLleSNLBzqhBaC;

					public int pnZsxxbAYJUHBYHIrjdIkkynfoEoA;

					public MapHelper oTWPSjZspGEFUQUSLsCvRDOSUZPM;

					private ControllerType SZtxkAXmBWDktFkPsANOzxhgquLgA;

					public ControllerType UbgQvkYQRvrMijDAGauhBLTDgHI;

					private bool ABGcsdIYNiQKKkOxJDUPFPNRrBuU;

					public bool drKupBWrcKPPdqgZkfFHawmwbtYy;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd PCuzHwuwYopTZLjQtjITGFJkyVqP;

					private int DFlhmNBJcoKKbBoTAvfxCxRJiiKkb;

					private IList<ControllerMap> ZkVTXvpcPxkKzRoLYmpJeewnpomm;

					private int uRignbskjywTJxCtXtNqqdVRbvJu;

					private IEnumerator<ActionElementMap> zqDQEJLUPefIguCzZgzgeChbpyaF;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZfEbrPPftoMbBIMwZYHlGdLdRSdX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZfEbrPPftoMbBIMwZYHlGdLdRSdX;
						}
					}

					[DebuggerHidden]
					public mihDzncxnJvsufOPXPNEHpWmshzOA(int P_0)
					{
						nhLoqTcMgulxkYbVlRDCEcKGCkqq = P_0;
						RaZeIfFRlPbUMCMFeWvEtMPrObMMA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = nhLoqTcMgulxkYbVlRDCEcKGCkqq;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								itSceXAJpEuQVAidULBFeeLgyuGLb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = nhLoqTcMgulxkYbVlRDCEcKGCkqq;
							MapHelper mapHelper = oTWPSjZspGEFUQUSLsCvRDOSUZPM;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								nhLoqTcMgulxkYbVlRDCEcKGCkqq = -3;
								goto IL_012c;
							}
							nhLoqTcMgulxkYbVlRDCEcKGCkqq = -1;
							if (QGbNFqMtXBOnwKdLleSNLBzqhBaC < 0)
							{
								return false;
							}
							PCuzHwuwYopTZLjQtjITGFJkyVqP = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(SZtxkAXmBWDktFkPsANOzxhgquLgA);
							DFlhmNBJcoKKbBoTAvfxCxRJiiKkb = 0;
							goto IL_0187;
							IL_012c:
							if (zqDQEJLUPefIguCzZgzgeChbpyaF.MoveNext())
							{
								ActionElementMap current = zqDQEJLUPefIguCzZgzgeChbpyaF.Current;
								ZfEbrPPftoMbBIMwZYHlGdLdRSdX = current;
								nhLoqTcMgulxkYbVlRDCEcKGCkqq = 1;
								return true;
							}
							itSceXAJpEuQVAidULBFeeLgyuGLb();
							zqDQEJLUPefIguCzZgzgeChbpyaF = null;
							goto IL_0146;
							IL_0158:
							if (uRignbskjywTJxCtXtNqqdVRbvJu < ZkVTXvpcPxkKzRoLYmpJeewnpomm.Count)
							{
								if ((!ABGcsdIYNiQKKkOxJDUPFPNRrBuU || ZkVTXvpcPxkKzRoLYmpJeewnpomm[uRignbskjywTJxCtXtNqqdVRbvJu].enabled) && ZkVTXvpcPxkKzRoLYmpJeewnpomm[uRignbskjywTJxCtXtNqqdVRbvJu].ContainsAction(QGbNFqMtXBOnwKdLleSNLBzqhBaC))
								{
									zqDQEJLUPefIguCzZgzgeChbpyaF = ZkVTXvpcPxkKzRoLYmpJeewnpomm[uRignbskjywTJxCtXtNqqdVRbvJu].ElementMapsWithAction(QGbNFqMtXBOnwKdLleSNLBzqhBaC, ABGcsdIYNiQKKkOxJDUPFPNRrBuU).GetEnumerator();
									nhLoqTcMgulxkYbVlRDCEcKGCkqq = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							ZkVTXvpcPxkKzRoLYmpJeewnpomm = null;
							DFlhmNBJcoKKbBoTAvfxCxRJiiKkb++;
							goto IL_0187;
							IL_0146:
							uRignbskjywTJxCtXtNqqdVRbvJu++;
							goto IL_0158;
							IL_0187:
							if (DFlhmNBJcoKKbBoTAvfxCxRJiiKkb < PCuzHwuwYopTZLjQtjITGFJkyVqP.umplaoBWNrHpDalRCquleOiTParq)
							{
								ZkVTXvpcPxkKzRoLYmpJeewnpomm = PCuzHwuwYopTZLjQtjITGFJkyVqP.XyKTgMxvPKsPsAOqAWrzShIBzUTi(DFlhmNBJcoKKbBoTAvfxCxRJiiKkb).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
								uRignbskjywTJxCtXtNqqdVRbvJu = 0;
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

					private void itSceXAJpEuQVAidULBFeeLgyuGLb()
					{
						nhLoqTcMgulxkYbVlRDCEcKGCkqq = -1;
						if (zqDQEJLUPefIguCzZgzgeChbpyaF != null)
						{
							zqDQEJLUPefIguCzZgzgeChbpyaF.Dispose();
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
						mihDzncxnJvsufOPXPNEHpWmshzOA mihDzncxnJvsufOPXPNEHpWmshzOA2;
						if (nhLoqTcMgulxkYbVlRDCEcKGCkqq == -2 && RaZeIfFRlPbUMCMFeWvEtMPrObMMA == Environment.CurrentManagedThreadId)
						{
							nhLoqTcMgulxkYbVlRDCEcKGCkqq = 0;
							mihDzncxnJvsufOPXPNEHpWmshzOA2 = this;
						}
						else
						{
							mihDzncxnJvsufOPXPNEHpWmshzOA2 = new mihDzncxnJvsufOPXPNEHpWmshzOA(0);
							mihDzncxnJvsufOPXPNEHpWmshzOA2.oTWPSjZspGEFUQUSLsCvRDOSUZPM = oTWPSjZspGEFUQUSLsCvRDOSUZPM;
						}
						mihDzncxnJvsufOPXPNEHpWmshzOA2.SZtxkAXmBWDktFkPsANOzxhgquLgA = UbgQvkYQRvrMijDAGauhBLTDgHI;
						mihDzncxnJvsufOPXPNEHpWmshzOA2.QGbNFqMtXBOnwKdLleSNLBzqhBaC = pnZsxxbAYJUHBYHIrjdIkkynfoEoA;
						mihDzncxnJvsufOPXPNEHpWmshzOA2.ABGcsdIYNiQKKkOxJDUPFPNRrBuU = drKupBWrcKPPdqgZkfFHawmwbtYy;
						return mihDzncxnJvsufOPXPNEHpWmshzOA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class BVgVDxmsqGmCDXSXVLuiKxnogdVi : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int GILJMeSATdezjCVPugoiBDWekUaHB;

					private ActionElementMap wqYLryBiNtfyFGNjXXJYdRdAizTmA;

					private int MWvGLVRzMmBVUReLEIdLEDSSjbeAb;

					private int QwKeKTyBoShRvUxVQuDafftuZCfC;

					public int EOrwkpbkzHlAyzsteELKhSSJHGSs;

					public MapHelper qXLeExwhRMekgReXHqUMtzlxLSXW;

					private ControllerType cwgBxUImjKqKgZFkTLBNhQoUcolJ;

					public ControllerType MxAIhLwAiCHnkPLkdUWVqemBELvV;

					private int gRsfYffwlJhmrmPEZaMLzfLsfwNF;

					public int vqLwOOQKSqaTBNDqHGCRoDStwNQF;

					private bool IXUQCVlXBxVkstfNVnxlPEaHwVee;

					public bool vDtcmQpSZOGEJppeDTDYdkXEOwdS;

					private IList<ControllerMap> qNcfzIkgLQeBscNKbGDoODOxgtYFA;

					private int xMLnBDfCfJHkcEgnaVfcQmNVLBkT;

					private IEnumerator<ActionElementMap> CiueObAxZoxVRTrIrTGioamLhshH;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return wqYLryBiNtfyFGNjXXJYdRdAizTmA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wqYLryBiNtfyFGNjXXJYdRdAizTmA;
						}
					}

					[DebuggerHidden]
					public BVgVDxmsqGmCDXSXVLuiKxnogdVi(int P_0)
					{
						GILJMeSATdezjCVPugoiBDWekUaHB = P_0;
						MWvGLVRzMmBVUReLEIdLEDSSjbeAb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gILJMeSATdezjCVPugoiBDWekUaHB = GILJMeSATdezjCVPugoiBDWekUaHB;
						if (gILJMeSATdezjCVPugoiBDWekUaHB == -3 || gILJMeSATdezjCVPugoiBDWekUaHB == 1)
						{
							try
							{
							}
							finally
							{
								jpPZeLaekjCNfUneOnoXiwEUmErq();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gILJMeSATdezjCVPugoiBDWekUaHB = GILJMeSATdezjCVPugoiBDWekUaHB;
							MapHelper mapHelper = qXLeExwhRMekgReXHqUMtzlxLSXW;
							if (gILJMeSATdezjCVPugoiBDWekUaHB != 0)
							{
								if (gILJMeSATdezjCVPugoiBDWekUaHB != 1)
								{
									return false;
								}
								GILJMeSATdezjCVPugoiBDWekUaHB = -3;
								goto IL_012b;
							}
							GILJMeSATdezjCVPugoiBDWekUaHB = -1;
							if (QwKeKTyBoShRvUxVQuDafftuZCfC < 0)
							{
								return false;
							}
							unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(cwgBxUImjKqKgZFkTLBNhQoUcolJ);
							int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(gRsfYffwlJhmrmPEZaMLzfLsfwNF);
							if (num < 0)
							{
								return false;
							}
							qNcfzIkgLQeBscNKbGDoODOxgtYFA = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
							xMLnBDfCfJHkcEgnaVfcQmNVLBkT = 0;
							goto IL_0157;
							IL_012b:
							if (CiueObAxZoxVRTrIrTGioamLhshH.MoveNext())
							{
								ActionElementMap current = CiueObAxZoxVRTrIrTGioamLhshH.Current;
								wqYLryBiNtfyFGNjXXJYdRdAizTmA = current;
								GILJMeSATdezjCVPugoiBDWekUaHB = 1;
								return true;
							}
							jpPZeLaekjCNfUneOnoXiwEUmErq();
							CiueObAxZoxVRTrIrTGioamLhshH = null;
							goto IL_0145;
							IL_0157:
							if (xMLnBDfCfJHkcEgnaVfcQmNVLBkT < qNcfzIkgLQeBscNKbGDoODOxgtYFA.Count)
							{
								if ((!IXUQCVlXBxVkstfNVnxlPEaHwVee || qNcfzIkgLQeBscNKbGDoODOxgtYFA[xMLnBDfCfJHkcEgnaVfcQmNVLBkT].enabled) && qNcfzIkgLQeBscNKbGDoODOxgtYFA[xMLnBDfCfJHkcEgnaVfcQmNVLBkT].ContainsAction(QwKeKTyBoShRvUxVQuDafftuZCfC))
								{
									CiueObAxZoxVRTrIrTGioamLhshH = qNcfzIkgLQeBscNKbGDoODOxgtYFA[xMLnBDfCfJHkcEgnaVfcQmNVLBkT].ElementMapsWithAction(QwKeKTyBoShRvUxVQuDafftuZCfC, IXUQCVlXBxVkstfNVnxlPEaHwVee).GetEnumerator();
									GILJMeSATdezjCVPugoiBDWekUaHB = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							xMLnBDfCfJHkcEgnaVfcQmNVLBkT++;
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

					private void jpPZeLaekjCNfUneOnoXiwEUmErq()
					{
						GILJMeSATdezjCVPugoiBDWekUaHB = -1;
						if (CiueObAxZoxVRTrIrTGioamLhshH != null)
						{
							CiueObAxZoxVRTrIrTGioamLhshH.Dispose();
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
						BVgVDxmsqGmCDXSXVLuiKxnogdVi bVgVDxmsqGmCDXSXVLuiKxnogdVi;
						if (GILJMeSATdezjCVPugoiBDWekUaHB == -2 && MWvGLVRzMmBVUReLEIdLEDSSjbeAb == Environment.CurrentManagedThreadId)
						{
							GILJMeSATdezjCVPugoiBDWekUaHB = 0;
							bVgVDxmsqGmCDXSXVLuiKxnogdVi = this;
						}
						else
						{
							bVgVDxmsqGmCDXSXVLuiKxnogdVi = new BVgVDxmsqGmCDXSXVLuiKxnogdVi(0);
							bVgVDxmsqGmCDXSXVLuiKxnogdVi.qXLeExwhRMekgReXHqUMtzlxLSXW = qXLeExwhRMekgReXHqUMtzlxLSXW;
						}
						bVgVDxmsqGmCDXSXVLuiKxnogdVi.cwgBxUImjKqKgZFkTLBNhQoUcolJ = MxAIhLwAiCHnkPLkdUWVqemBELvV;
						bVgVDxmsqGmCDXSXVLuiKxnogdVi.gRsfYffwlJhmrmPEZaMLzfLsfwNF = vqLwOOQKSqaTBNDqHGCRoDStwNQF;
						bVgVDxmsqGmCDXSXVLuiKxnogdVi.QwKeKTyBoShRvUxVQuDafftuZCfC = EOrwkpbkzHlAyzsteELKhSSJHGSs;
						bVgVDxmsqGmCDXSXVLuiKxnogdVi.IXUQCVlXBxVkstfNVnxlPEaHwVee = vDtcmQpSZOGEJppeDTDYdkXEOwdS;
						return bVgVDxmsqGmCDXSXVLuiKxnogdVi;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class CAYZlSBifkVnsdQZOxroZQasnsxI : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int jrsyFklEUukhaIkJWiaqaDRUdZVPA;

					private ControllerMap IuPewTLzginfUYpBedfbAcrLOjWn;

					private int AlmUdDvUTYDixxmpkgARlXIOkTao;

					public MapHelper NvImDabpJvemFfYZKohUFlAqfODcA;

					private ControllerType vXyIEPMtIeDOwJvclMdVsjeVcfCm;

					public ControllerType bKXbthhavcLebLFHOiiTVZCSMaaqA;

					private int crJGHkIjIUvAkUSAPVMXpNSjjRwEA;

					public int lubMJvSBUTpLvyguthQSlSrBgRNJ;

					private int AzHgklJspLinKrulAepVuYlCetKH;

					public int rrbLaRZDGYYiBeoJSqEuftzJhgCC;

					private IList<ControllerMap> uBtWctoRaJourWiiCBrNdvotHBaG;

					private int jHPcuQTLBoobrWygFUvMQcJLEthL;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return IuPewTLzginfUYpBedfbAcrLOjWn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return IuPewTLzginfUYpBedfbAcrLOjWn;
						}
					}

					[DebuggerHidden]
					public CAYZlSBifkVnsdQZOxroZQasnsxI(int P_0)
					{
						jrsyFklEUukhaIkJWiaqaDRUdZVPA = P_0;
						AlmUdDvUTYDixxmpkgARlXIOkTao = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = jrsyFklEUukhaIkJWiaqaDRUdZVPA;
						MapHelper nvImDabpJvemFfYZKohUFlAqfODcA = NvImDabpJvemFfYZKohUFlAqfODcA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							jrsyFklEUukhaIkJWiaqaDRUdZVPA = -1;
							goto IL_00b0;
						}
						jrsyFklEUukhaIkJWiaqaDRUdZVPA = -1;
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = nvImDabpJvemFfYZKohUFlAqfODcA.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(vXyIEPMtIeDOwJvclMdVsjeVcfCm);
						int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(crJGHkIjIUvAkUSAPVMXpNSjjRwEA);
						if (num2 < 0)
						{
							return false;
						}
						uBtWctoRaJourWiiCBrNdvotHBaG = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num2).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
						jHPcuQTLBoobrWygFUvMQcJLEthL = 0;
						goto IL_00c2;
						IL_00c2:
						if (jHPcuQTLBoobrWygFUvMQcJLEthL < uBtWctoRaJourWiiCBrNdvotHBaG.Count)
						{
							if (uBtWctoRaJourWiiCBrNdvotHBaG[jHPcuQTLBoobrWygFUvMQcJLEthL].categoryId == AzHgklJspLinKrulAepVuYlCetKH)
							{
								IuPewTLzginfUYpBedfbAcrLOjWn = uBtWctoRaJourWiiCBrNdvotHBaG[jHPcuQTLBoobrWygFUvMQcJLEthL];
								jrsyFklEUukhaIkJWiaqaDRUdZVPA = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						jHPcuQTLBoobrWygFUvMQcJLEthL++;
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
						CAYZlSBifkVnsdQZOxroZQasnsxI cAYZlSBifkVnsdQZOxroZQasnsxI;
						if (jrsyFklEUukhaIkJWiaqaDRUdZVPA == -2 && AlmUdDvUTYDixxmpkgARlXIOkTao == Environment.CurrentManagedThreadId)
						{
							jrsyFklEUukhaIkJWiaqaDRUdZVPA = 0;
							cAYZlSBifkVnsdQZOxroZQasnsxI = this;
						}
						else
						{
							cAYZlSBifkVnsdQZOxroZQasnsxI = new CAYZlSBifkVnsdQZOxroZQasnsxI(0);
							cAYZlSBifkVnsdQZOxroZQasnsxI.NvImDabpJvemFfYZKohUFlAqfODcA = NvImDabpJvemFfYZKohUFlAqfODcA;
						}
						cAYZlSBifkVnsdQZOxroZQasnsxI.vXyIEPMtIeDOwJvclMdVsjeVcfCm = bKXbthhavcLebLFHOiiTVZCSMaaqA;
						cAYZlSBifkVnsdQZOxroZQasnsxI.crJGHkIjIUvAkUSAPVMXpNSjjRwEA = lubMJvSBUTpLvyguthQSlSrBgRNJ;
						cAYZlSBifkVnsdQZOxroZQasnsxI.AzHgklJspLinKrulAepVuYlCetKH = rrbLaRZDGYYiBeoJSqEuftzJhgCC;
						return cAYZlSBifkVnsdQZOxroZQasnsxI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class fuaquNQfvvJhsjFejIkdgYRKEAJH<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int TrqUSsCyrBgAlqwfblKWqbLKFRSIA;

					private _0001 dgZDBcLECrELpROTespXlKkRQZIV;

					private int qzwdVEglDgIFEbyVhQsGucdjJbAsb;

					public MapHelper aoOAUuQSNvkiTGnBbCHHUKQFeoRn;

					private int QeFhGnTDcHwCxNsIIloYTPmbEfYr;

					public int VuJaJBDQJLbNdDjbThrwFAwBMJnib;

					private int WFraYpXpjoTyRYpiBWTvFpjUekkm;

					public int OebTSKtqYpRrVjFJqJrjErDrmvkR;

					private IList<_0001> GZXtsIMsRgVrUarpujArCfqdYDXS;

					private int aowhtShjqRHjTrzwyjDrdOdbCmRh;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return dgZDBcLECrELpROTespXlKkRQZIV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dgZDBcLECrELpROTespXlKkRQZIV;
						}
					}

					[DebuggerHidden]
					public fuaquNQfvvJhsjFejIkdgYRKEAJH(int P_0)
					{
						TrqUSsCyrBgAlqwfblKWqbLKFRSIA = P_0;
						qzwdVEglDgIFEbyVhQsGucdjJbAsb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int trqUSsCyrBgAlqwfblKWqbLKFRSIA = TrqUSsCyrBgAlqwfblKWqbLKFRSIA;
						MapHelper mapHelper = aoOAUuQSNvkiTGnBbCHHUKQFeoRn;
						if (trqUSsCyrBgAlqwfblKWqbLKFRSIA != 0)
						{
							if (trqUSsCyrBgAlqwfblKWqbLKFRSIA != 1)
							{
								return false;
							}
							TrqUSsCyrBgAlqwfblKWqbLKFRSIA = -1;
							goto IL_00b9;
						}
						TrqUSsCyrBgAlqwfblKWqbLKFRSIA = -1;
						ControllerType controllerType = pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<_0001>();
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(QeFhGnTDcHwCxNsIIloYTPmbEfYr);
						if (num < 0)
						{
							return false;
						}
						GZXtsIMsRgVrUarpujArCfqdYDXS = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.OTHClbrQcXCnssDoyJmJAaYPGLYu<_0001>();
						aowhtShjqRHjTrzwyjDrdOdbCmRh = 0;
						goto IL_00cb;
						IL_00cb:
						if (aowhtShjqRHjTrzwyjDrdOdbCmRh < GZXtsIMsRgVrUarpujArCfqdYDXS.Count)
						{
							if (GZXtsIMsRgVrUarpujArCfqdYDXS[aowhtShjqRHjTrzwyjDrdOdbCmRh].categoryId == WFraYpXpjoTyRYpiBWTvFpjUekkm)
							{
								dgZDBcLECrELpROTespXlKkRQZIV = GZXtsIMsRgVrUarpujArCfqdYDXS[aowhtShjqRHjTrzwyjDrdOdbCmRh];
								TrqUSsCyrBgAlqwfblKWqbLKFRSIA = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						aowhtShjqRHjTrzwyjDrdOdbCmRh++;
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
						fuaquNQfvvJhsjFejIkdgYRKEAJH<_0001> fuaquNQfvvJhsjFejIkdgYRKEAJH2;
						if (TrqUSsCyrBgAlqwfblKWqbLKFRSIA == -2 && qzwdVEglDgIFEbyVhQsGucdjJbAsb == Environment.CurrentManagedThreadId)
						{
							TrqUSsCyrBgAlqwfblKWqbLKFRSIA = 0;
							fuaquNQfvvJhsjFejIkdgYRKEAJH2 = this;
						}
						else
						{
							fuaquNQfvvJhsjFejIkdgYRKEAJH2 = new fuaquNQfvvJhsjFejIkdgYRKEAJH<_0001>(0);
							fuaquNQfvvJhsjFejIkdgYRKEAJH2.aoOAUuQSNvkiTGnBbCHHUKQFeoRn = aoOAUuQSNvkiTGnBbCHHUKQFeoRn;
						}
						fuaquNQfvvJhsjFejIkdgYRKEAJH2.QeFhGnTDcHwCxNsIIloYTPmbEfYr = VuJaJBDQJLbNdDjbThrwFAwBMJnib;
						fuaquNQfvvJhsjFejIkdgYRKEAJH2.WFraYpXpjoTyRYpiBWTvFpjUekkm = OebTSKtqYpRrVjFJqJrjErDrmvkR;
						return fuaquNQfvvJhsjFejIkdgYRKEAJH2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class jyAFiPMOKtdOJocJvLfReiuAcHuH : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int pQloLfdQcGGgkUSNnfvdqgFAfViT;

					private ActionElementMap TksWdBxydxsEqINPEvfninOKaveH;

					private int XfxjsONOcrzcwmLKJVMpEVuZKqaC;

					public MapHelper dpNpgItJlPBQMqYOEHWHnYgAMZXg;

					private int hHSEyYnvEPiJQMVootongjDFDhBIA;

					public int CdFhBfIKtjandzvThilXDVJXlgGD;

					private bool UatrWoLGcRBBYlzjymGwCUgmwAtD;

					public bool TwpFGYHQZlBOSEajHfOJUpNMTBhRb;

					private int GcGdBLYHKWHfmkIRIahxxxavXuWbA;

					private int ERjwkAiEJQETghIimNkhUwxNtZox;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd xuzhqLOgaDKwpETeKModRlpWLoXd;

					private int aBDaUggutceaFGOasqdvCtIWtCIp;

					private int YloBrUqJgQETKhVdvqttvXtYTrTfA;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ dOvwVJnPzteBGBVUXDEpVGSNireX;

					private int kOKEhrKXOxatdrtzgGvqAtjDeuUAb;

					private int ZjXxEmCPpAEvFdCNfFEDMDftTuqlA;

					private IEnumerator<ActionElementMap> HWwdgsCRgkhiuKWCUgyonhymGGO;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return TksWdBxydxsEqINPEvfninOKaveH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TksWdBxydxsEqINPEvfninOKaveH;
						}
					}

					[DebuggerHidden]
					public jyAFiPMOKtdOJocJvLfReiuAcHuH(int P_0)
					{
						pQloLfdQcGGgkUSNnfvdqgFAfViT = P_0;
						XfxjsONOcrzcwmLKJVMpEVuZKqaC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pQloLfdQcGGgkUSNnfvdqgFAfViT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								bVTNkuKTTcTtSyrPrlWAyJjDfkKm();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = pQloLfdQcGGgkUSNnfvdqgFAfViT;
							MapHelper mapHelper = dpNpgItJlPBQMqYOEHWHnYgAMZXg;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pQloLfdQcGGgkUSNnfvdqgFAfViT = -3;
								goto IL_016c;
							}
							pQloLfdQcGGgkUSNnfvdqgFAfViT = -1;
							if (ReInput._id != mapHelper.ZlswVIRxaKsbbROVvxEyieXLglZjA)
							{
								ReInput.CheckInitialized(mapHelper.ZlswVIRxaKsbbROVvxEyieXLglZjA);
								return false;
							}
							if (hHSEyYnvEPiJQMVootongjDFDhBIA < 0)
							{
								return false;
							}
							GcGdBLYHKWHfmkIRIahxxxavXuWbA = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
							ERjwkAiEJQETghIimNkhUwxNtZox = 0;
							goto IL_01ec;
							IL_016c:
							if (HWwdgsCRgkhiuKWCUgyonhymGGO.MoveNext())
							{
								ActionElementMap current = HWwdgsCRgkhiuKWCUgyonhymGGO.Current;
								TksWdBxydxsEqINPEvfninOKaveH = current;
								pQloLfdQcGGgkUSNnfvdqgFAfViT = 1;
								return true;
							}
							bVTNkuKTTcTtSyrPrlWAyJjDfkKm();
							HWwdgsCRgkhiuKWCUgyonhymGGO = null;
							goto IL_0186;
							IL_0186:
							ZjXxEmCPpAEvFdCNfFEDMDftTuqlA++;
							goto IL_0198;
							IL_01c2:
							if (YloBrUqJgQETKhVdvqttvXtYTrTfA < aBDaUggutceaFGOasqdvCtIWtCIp)
							{
								dOvwVJnPzteBGBVUXDEpVGSNireX = xuzhqLOgaDKwpETeKModRlpWLoXd.XyKTgMxvPKsPsAOqAWrzShIBzUTi(YloBrUqJgQETKhVdvqttvXtYTrTfA).XCfFEHCAovUlErZTLVujHEbwOdRG;
								kOKEhrKXOxatdrtzgGvqAtjDeuUAb = dOvwVJnPzteBGBVUXDEpVGSNireX.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								ZjXxEmCPpAEvFdCNfFEDMDftTuqlA = 0;
								goto IL_0198;
							}
							xuzhqLOgaDKwpETeKModRlpWLoXd = null;
							ERjwkAiEJQETghIimNkhUwxNtZox++;
							goto IL_01ec;
							IL_0198:
							if (ZjXxEmCPpAEvFdCNfFEDMDftTuqlA < kOKEhrKXOxatdrtzgGvqAtjDeuUAb)
							{
								ControllerMap controllerMap = dOvwVJnPzteBGBVUXDEpVGSNireX.vTSKHbrOptkhUmIMjLsBXHAVebGj(ZjXxEmCPpAEvFdCNfFEDMDftTuqlA);
								if ((!UatrWoLGcRBBYlzjymGwCUgmwAtD || controllerMap.enabled) && controllerMap.ContainsAction(hHSEyYnvEPiJQMVootongjDFDhBIA))
								{
									HWwdgsCRgkhiuKWCUgyonhymGGO = controllerMap.ElementMapsWithAction(hHSEyYnvEPiJQMVootongjDFDhBIA, UatrWoLGcRBBYlzjymGwCUgmwAtD).GetEnumerator();
									pQloLfdQcGGgkUSNnfvdqgFAfViT = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							dOvwVJnPzteBGBVUXDEpVGSNireX = null;
							YloBrUqJgQETKhVdvqttvXtYTrTfA++;
							goto IL_01c2;
							IL_01ec:
							if (ERjwkAiEJQETghIimNkhUwxNtZox < GcGdBLYHKWHfmkIRIahxxxavXuWbA)
							{
								xuzhqLOgaDKwpETeKModRlpWLoXd = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(ERjwkAiEJQETghIimNkhUwxNtZox);
								aBDaUggutceaFGOasqdvCtIWtCIp = xuzhqLOgaDKwpETeKModRlpWLoXd.umplaoBWNrHpDalRCquleOiTParq;
								YloBrUqJgQETKhVdvqttvXtYTrTfA = 0;
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

					private void bVTNkuKTTcTtSyrPrlWAyJjDfkKm()
					{
						pQloLfdQcGGgkUSNnfvdqgFAfViT = -1;
						if (HWwdgsCRgkhiuKWCUgyonhymGGO != null)
						{
							HWwdgsCRgkhiuKWCUgyonhymGGO.Dispose();
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
						jyAFiPMOKtdOJocJvLfReiuAcHuH jyAFiPMOKtdOJocJvLfReiuAcHuH2;
						if (pQloLfdQcGGgkUSNnfvdqgFAfViT == -2 && XfxjsONOcrzcwmLKJVMpEVuZKqaC == Environment.CurrentManagedThreadId)
						{
							pQloLfdQcGGgkUSNnfvdqgFAfViT = 0;
							jyAFiPMOKtdOJocJvLfReiuAcHuH2 = this;
						}
						else
						{
							jyAFiPMOKtdOJocJvLfReiuAcHuH2 = new jyAFiPMOKtdOJocJvLfReiuAcHuH(0);
							jyAFiPMOKtdOJocJvLfReiuAcHuH2.dpNpgItJlPBQMqYOEHWHnYgAMZXg = dpNpgItJlPBQMqYOEHWHnYgAMZXg;
						}
						jyAFiPMOKtdOJocJvLfReiuAcHuH2.hHSEyYnvEPiJQMVootongjDFDhBIA = CdFhBfIKtjandzvThilXDVJXlgGD;
						jyAFiPMOKtdOJocJvLfReiuAcHuH2.UatrWoLGcRBBYlzjymGwCUgmwAtD = TwpFGYHQZlBOSEajHfOJUpNMTBhRb;
						return jyAFiPMOKtdOJocJvLfReiuAcHuH2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class CxRzvoaOdZdhPgQybWzHDBMovmFq : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int BrBWScORiSIPHaOUqacOHdOBfQRFb;

					private ActionElementMap sEUGrUcZAJWMLvImSLdaHWmAMCuNB;

					private int kKOoDjXHQUSYDMRPuPLBhOaeDzis;

					private IControllerElementTarget tBxwbgakVuUsxhRuAHSQSkLiPDYL;

					public IControllerElementTarget CgWYkaeckhpRNncAGUPZOiXjemIm;

					public MapHelper VNRuxWKLXLFEfSdQVcnQkfJbdFiT;

					private bool xypbpdJMrQdzUScKRtDlsRufPlUpA;

					public bool ujTkDwvYJTRMRLKSIosbrqSJsbEN;

					private bool veKfjuQevXKpaUzUblPlBnhalzos;

					public bool UCKROzdcisfmJqWpDPDhuGCBMpZL;

					private int WUUtJJzNbMLzXEVoiMpSZyAZIWno;

					public int saPkQZBkavasUuxaBpqpoZspPCbx;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd CWDyJZJgUageJMWTDnqRAVvWhYjF;

					private int doQJTyyzlPHDTXpmPYPePcBdEDfy;

					private int ChHZJNiEqxdgDkORucPVxKIGUPpVA;

					private IList<ControllerMap> UhPaQOFNnqeuTXDsiHGlWWPrehGeA;

					private int PLXxNlKzKFMXYjBuuoataCjhcION;

					private int vMeKSxIVackTzfxdWRcWGqOvuTlF;

					private TempListPool.TList<ActionElementMap> TRZZrBxKNxHxKuzTecKoJNuzlFAk;

					private List<ActionElementMap>.Enumerator zWTFVBnWjdjbWsLcpIkXjtNsVHwp;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return sEUGrUcZAJWMLvImSLdaHWmAMCuNB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sEUGrUcZAJWMLvImSLdaHWmAMCuNB;
						}
					}

					[DebuggerHidden]
					public CxRzvoaOdZdhPgQybWzHDBMovmFq(int P_0)
					{
						BrBWScORiSIPHaOUqacOHdOBfQRFb = P_0;
						kKOoDjXHQUSYDMRPuPLBhOaeDzis = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int brBWScORiSIPHaOUqacOHdOBfQRFb = BrBWScORiSIPHaOUqacOHdOBfQRFb;
						if ((uint)(brBWScORiSIPHaOUqacOHdOBfQRFb - -4) > 1u && brBWScORiSIPHaOUqacOHdOBfQRFb != 1)
						{
							return;
						}
						try
						{
							if (brBWScORiSIPHaOUqacOHdOBfQRFb != -4 && brBWScORiSIPHaOUqacOHdOBfQRFb != 1)
							{
								return;
							}
							try
							{
							}
							finally
							{
								rdWTCswENAXWkKJiJrSqXyghlYLD();
							}
						}
						finally
						{
							iFXYnxpiEzAmowDbkTKJmpFSapciA();
						}
					}

					private bool MoveNext()
					{
						try
						{
							int brBWScORiSIPHaOUqacOHdOBfQRFb = BrBWScORiSIPHaOUqacOHdOBfQRFb;
							MapHelper vNRuxWKLXLFEfSdQVcnQkfJbdFiT = VNRuxWKLXLFEfSdQVcnQkfJbdFiT;
							if (brBWScORiSIPHaOUqacOHdOBfQRFb != 0)
							{
								if (brBWScORiSIPHaOUqacOHdOBfQRFb != 1)
								{
									return false;
								}
								BrBWScORiSIPHaOUqacOHdOBfQRFb = -4;
								goto IL_017c;
							}
							BrBWScORiSIPHaOUqacOHdOBfQRFb = -1;
							if (tBxwbgakVuUsxhRuAHSQSkLiPDYL == null)
							{
								return false;
							}
							Controller controller = tBxwbgakVuUsxhRuAHSQSkLiPDYL.controller;
							if (controller == null)
							{
								return false;
							}
							CWDyJZJgUageJMWTDnqRAVvWhYjF = vNRuxWKLXLFEfSdQVcnQkfJbdFiT.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controller.type);
							doQJTyyzlPHDTXpmPYPePcBdEDfy = CWDyJZJgUageJMWTDnqRAVvWhYjF.umplaoBWNrHpDalRCquleOiTParq;
							ChHZJNiEqxdgDkORucPVxKIGUPpVA = 0;
							goto IL_01e4;
							IL_017c:
							if (zWTFVBnWjdjbWsLcpIkXjtNsVHwp.MoveNext())
							{
								ActionElementMap current = zWTFVBnWjdjbWsLcpIkXjtNsVHwp.Current;
								sEUGrUcZAJWMLvImSLdaHWmAMCuNB = current;
								BrBWScORiSIPHaOUqacOHdOBfQRFb = 1;
								return true;
							}
							rdWTCswENAXWkKJiJrSqXyghlYLD();
							zWTFVBnWjdjbWsLcpIkXjtNsVHwp = default(List<ActionElementMap>.Enumerator);
							iFXYnxpiEzAmowDbkTKJmpFSapciA();
							TRZZrBxKNxHxKuzTecKoJNuzlFAk = null;
							goto IL_01a8;
							IL_01e4:
							if (ChHZJNiEqxdgDkORucPVxKIGUPpVA < doQJTyyzlPHDTXpmPYPePcBdEDfy)
							{
								cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = CWDyJZJgUageJMWTDnqRAVvWhYjF.XyKTgMxvPKsPsAOqAWrzShIBzUTi(ChHZJNiEqxdgDkORucPVxKIGUPpVA).XCfFEHCAovUlErZTLVujHEbwOdRG;
								_ = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								UhPaQOFNnqeuTXDsiHGlWWPrehGeA = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
								PLXxNlKzKFMXYjBuuoataCjhcION = UhPaQOFNnqeuTXDsiHGlWWPrehGeA.Count;
								vMeKSxIVackTzfxdWRcWGqOvuTlF = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (vMeKSxIVackTzfxdWRcWGqOvuTlF < PLXxNlKzKFMXYjBuuoataCjhcION)
							{
								ControllerMap controllerMap = UhPaQOFNnqeuTXDsiHGlWWPrehGeA[vMeKSxIVackTzfxdWRcWGqOvuTlF];
								if (!xypbpdJMrQdzUScKRtDlsRufPlUpA || controllerMap.enabled)
								{
									TRZZrBxKNxHxKuzTecKoJNuzlFAk = TempListPool.GetTList<ActionElementMap>();
									BrBWScORiSIPHaOUqacOHdOBfQRFb = -3;
									List<ActionElementMap> list = TRZZrBxKNxHxKuzTecKoJNuzlFAk.list;
									controllerMap.xbMqqhNCHHsGgJNjWdODBOazhjtNA(tBxwbgakVuUsxhRuAHSQSkLiPDYL, veKfjuQevXKpaUzUblPlBnhalzos, WUUtJJzNbMLzXEVoiMpSZyAZIWno, xypbpdJMrQdzUScKRtDlsRufPlUpA, list, true, out var _);
									zWTFVBnWjdjbWsLcpIkXjtNsVHwp = list.GetEnumerator();
									BrBWScORiSIPHaOUqacOHdOBfQRFb = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							UhPaQOFNnqeuTXDsiHGlWWPrehGeA = null;
							ChHZJNiEqxdgDkORucPVxKIGUPpVA++;
							goto IL_01e4;
							IL_01a8:
							vMeKSxIVackTzfxdWRcWGqOvuTlF++;
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

					private void iFXYnxpiEzAmowDbkTKJmpFSapciA()
					{
						BrBWScORiSIPHaOUqacOHdOBfQRFb = -1;
						if (TRZZrBxKNxHxKuzTecKoJNuzlFAk != null)
						{
							((IDisposable)TRZZrBxKNxHxKuzTecKoJNuzlFAk).Dispose();
						}
					}

					private void rdWTCswENAXWkKJiJrSqXyghlYLD()
					{
						BrBWScORiSIPHaOUqacOHdOBfQRFb = -3;
						((IDisposable)zWTFVBnWjdjbWsLcpIkXjtNsVHwp/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						CxRzvoaOdZdhPgQybWzHDBMovmFq cxRzvoaOdZdhPgQybWzHDBMovmFq;
						if (BrBWScORiSIPHaOUqacOHdOBfQRFb == -2 && kKOoDjXHQUSYDMRPuPLBhOaeDzis == Environment.CurrentManagedThreadId)
						{
							BrBWScORiSIPHaOUqacOHdOBfQRFb = 0;
							cxRzvoaOdZdhPgQybWzHDBMovmFq = this;
						}
						else
						{
							cxRzvoaOdZdhPgQybWzHDBMovmFq = new CxRzvoaOdZdhPgQybWzHDBMovmFq(0);
							cxRzvoaOdZdhPgQybWzHDBMovmFq.VNRuxWKLXLFEfSdQVcnQkfJbdFiT = VNRuxWKLXLFEfSdQVcnQkfJbdFiT;
						}
						cxRzvoaOdZdhPgQybWzHDBMovmFq.tBxwbgakVuUsxhRuAHSQSkLiPDYL = CgWYkaeckhpRNncAGUPZOiXjemIm;
						cxRzvoaOdZdhPgQybWzHDBMovmFq.veKfjuQevXKpaUzUblPlBnhalzos = UCKROzdcisfmJqWpDPDhuGCBMpZL;
						cxRzvoaOdZdhPgQybWzHDBMovmFq.WUUtJJzNbMLzXEVoiMpSZyAZIWno = saPkQZBkavasUuxaBpqpoZspPCbx;
						cxRzvoaOdZdhPgQybWzHDBMovmFq.xypbpdJMrQdzUScKRtDlsRufPlUpA = ujTkDwvYJTRMRLKSIosbrqSJsbEN;
						return cxRzvoaOdZdhPgQybWzHDBMovmFq;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class JzyYowPiqbtKtxLOdmIJuPQDgOlY : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int ctBlWidDwFGMGYAcSgDkEiQUQtKSA;

					private ControllerMap mYtPeOMnusaLRKhaDVhKRTsPLJzZA;

					private int vNwgTRbCYIBHUQAICscxKSBOnyZCA;

					public MapHelper JzdfdcuTkSuWrQppvntVaEkAgIEJ;

					private int UjGweucVnYQoSxhPYWUcDNTQkMuS;

					private int xlzdhpllGxDTmrfnKEPsEEVeoQLC;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd hFLZNPSHycgosxliSRfNEgSFaMoAA;

					private int hqVnQMFURUPQBDJhHOUNhGaFKaLc;

					private int xYwxcxiJjJjREbimeHNEmznRLByM;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ xIacykhLIhZSWvpbpByysKuHSARn;

					private int TzxhZrYuMubEHDOsLtRxEKGZYFjk;

					private int hYHebdYasTpmsWnVntMVFlZJbcYaA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return mYtPeOMnusaLRKhaDVhKRTsPLJzZA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return mYtPeOMnusaLRKhaDVhKRTsPLJzZA;
						}
					}

					[DebuggerHidden]
					public JzyYowPiqbtKtxLOdmIJuPQDgOlY(int P_0)
					{
						ctBlWidDwFGMGYAcSgDkEiQUQtKSA = P_0;
						vNwgTRbCYIBHUQAICscxKSBOnyZCA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = ctBlWidDwFGMGYAcSgDkEiQUQtKSA;
						MapHelper jzdfdcuTkSuWrQppvntVaEkAgIEJ = JzdfdcuTkSuWrQppvntVaEkAgIEJ;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							ctBlWidDwFGMGYAcSgDkEiQUQtKSA = -1;
							hYHebdYasTpmsWnVntMVFlZJbcYaA++;
							goto IL_0104;
						}
						ctBlWidDwFGMGYAcSgDkEiQUQtKSA = -1;
						if (ReInput._id != jzdfdcuTkSuWrQppvntVaEkAgIEJ.ZlswVIRxaKsbbROVvxEyieXLglZjA)
						{
							ReInput.CheckInitialized(jzdfdcuTkSuWrQppvntVaEkAgIEJ.ZlswVIRxaKsbbROVvxEyieXLglZjA);
							return false;
						}
						UjGweucVnYQoSxhPYWUcDNTQkMuS = jzdfdcuTkSuWrQppvntVaEkAgIEJ.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
						xlzdhpllGxDTmrfnKEPsEEVeoQLC = 0;
						goto IL_0151;
						IL_0104:
						if (hYHebdYasTpmsWnVntMVFlZJbcYaA < TzxhZrYuMubEHDOsLtRxEKGZYFjk)
						{
							mYtPeOMnusaLRKhaDVhKRTsPLJzZA = xIacykhLIhZSWvpbpByysKuHSARn.vTSKHbrOptkhUmIMjLsBXHAVebGj(hYHebdYasTpmsWnVntMVFlZJbcYaA);
							ctBlWidDwFGMGYAcSgDkEiQUQtKSA = 1;
							return true;
						}
						xIacykhLIhZSWvpbpByysKuHSARn = null;
						xYwxcxiJjJjREbimeHNEmznRLByM++;
						goto IL_0129;
						IL_0129:
						if (xYwxcxiJjJjREbimeHNEmznRLByM < hqVnQMFURUPQBDJhHOUNhGaFKaLc)
						{
							xIacykhLIhZSWvpbpByysKuHSARn = hFLZNPSHycgosxliSRfNEgSFaMoAA.XyKTgMxvPKsPsAOqAWrzShIBzUTi(xYwxcxiJjJjREbimeHNEmznRLByM).XCfFEHCAovUlErZTLVujHEbwOdRG;
							TzxhZrYuMubEHDOsLtRxEKGZYFjk = xIacykhLIhZSWvpbpByysKuHSARn.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							hYHebdYasTpmsWnVntMVFlZJbcYaA = 0;
							goto IL_0104;
						}
						hFLZNPSHycgosxliSRfNEgSFaMoAA = null;
						xlzdhpllGxDTmrfnKEPsEEVeoQLC++;
						goto IL_0151;
						IL_0151:
						if (xlzdhpllGxDTmrfnKEPsEEVeoQLC < UjGweucVnYQoSxhPYWUcDNTQkMuS)
						{
							hFLZNPSHycgosxliSRfNEgSFaMoAA = jzdfdcuTkSuWrQppvntVaEkAgIEJ.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(xlzdhpllGxDTmrfnKEPsEEVeoQLC);
							hqVnQMFURUPQBDJhHOUNhGaFKaLc = hFLZNPSHycgosxliSRfNEgSFaMoAA.umplaoBWNrHpDalRCquleOiTParq;
							xYwxcxiJjJjREbimeHNEmznRLByM = 0;
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
						JzyYowPiqbtKtxLOdmIJuPQDgOlY jzyYowPiqbtKtxLOdmIJuPQDgOlY;
						if (ctBlWidDwFGMGYAcSgDkEiQUQtKSA == -2 && vNwgTRbCYIBHUQAICscxKSBOnyZCA == Environment.CurrentManagedThreadId)
						{
							ctBlWidDwFGMGYAcSgDkEiQUQtKSA = 0;
							jzyYowPiqbtKtxLOdmIJuPQDgOlY = this;
						}
						else
						{
							jzyYowPiqbtKtxLOdmIJuPQDgOlY = new JzyYowPiqbtKtxLOdmIJuPQDgOlY(0);
							jzyYowPiqbtKtxLOdmIJuPQDgOlY.JzdfdcuTkSuWrQppvntVaEkAgIEJ = JzdfdcuTkSuWrQppvntVaEkAgIEJ;
						}
						return jzyYowPiqbtKtxLOdmIJuPQDgOlY;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class IDdhDXLcSwRZSGgfcoNoBuFNfYae<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int byZBcdFZXZlsVgPJbRzNIfMxzKYS;

					private _0001 pdPGPFgISOIPmFRiFBtYmprIFgJDC;

					private int kyzNLlweeoUdWBdLIcbtVVbyibBAA;

					public MapHelper fFbfyiKgvjuRuVLFussSxPDsPrBs;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd QDLLsHjvybsEmfbjpOKKTRItEipK;

					private int LYxSaiZeTYJtrTgKXNeETSHQGmSx;

					private int WEljsIINRHPopukiprmxJNBGrwLL;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ rTjfFhCcjUpgdDvOXSyRvwuRwGcDA;

					private int mNTkvnRynjWDckRGWDTUQuRZOAxQ;

					private int bYSmccHQrQZpUKMnDdFzHeUanvsN;

					private int zbUsryvIVqWUgHdAvcDkqyYwubuw;

					private int rGMHMZOTuJulkRhIuCvyEXahWjdC;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return pdPGPFgISOIPmFRiFBtYmprIFgJDC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return pdPGPFgISOIPmFRiFBtYmprIFgJDC;
						}
					}

					[DebuggerHidden]
					public IDdhDXLcSwRZSGgfcoNoBuFNfYae(int P_0)
					{
						byZBcdFZXZlsVgPJbRzNIfMxzKYS = P_0;
						kyzNLlweeoUdWBdLIcbtVVbyibBAA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = byZBcdFZXZlsVgPJbRzNIfMxzKYS;
						MapHelper mapHelper = fFbfyiKgvjuRuVLFussSxPDsPrBs;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							byZBcdFZXZlsVgPJbRzNIfMxzKYS = -1;
							if (ReInput._id != mapHelper.ZlswVIRxaKsbbROVvxEyieXLglZjA)
							{
								ReInput.CheckInitialized(mapHelper.ZlswVIRxaKsbbROVvxEyieXLglZjA);
								return false;
							}
							if (pMvvECjJycyKibKKCAXEnFbBPTVk.LbshPzWFARxecbNlUzfmeCirsbrs<_0001>(out var controllerType))
							{
								QDLLsHjvybsEmfbjpOKKTRItEipK = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
								LYxSaiZeTYJtrTgKXNeETSHQGmSx = QDLLsHjvybsEmfbjpOKKTRItEipK.umplaoBWNrHpDalRCquleOiTParq;
								WEljsIINRHPopukiprmxJNBGrwLL = 0;
								goto IL_011b;
							}
							LYxSaiZeTYJtrTgKXNeETSHQGmSx = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
							WEljsIINRHPopukiprmxJNBGrwLL = 0;
							goto IL_0264;
						}
						case 1:
							byZBcdFZXZlsVgPJbRzNIfMxzKYS = -1;
							bYSmccHQrQZpUKMnDdFzHeUanvsN++;
							goto IL_00f6;
						case 2:
							{
								byZBcdFZXZlsVgPJbRzNIfMxzKYS = -1;
								goto IL_0207;
							}
							IL_0207:
							rGMHMZOTuJulkRhIuCvyEXahWjdC++;
							goto IL_0217;
							IL_0264:
							if (WEljsIINRHPopukiprmxJNBGrwLL >= LYxSaiZeTYJtrTgKXNeETSHQGmSx)
							{
								break;
							}
							QDLLsHjvybsEmfbjpOKKTRItEipK = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(WEljsIINRHPopukiprmxJNBGrwLL);
							mNTkvnRynjWDckRGWDTUQuRZOAxQ = QDLLsHjvybsEmfbjpOKKTRItEipK.umplaoBWNrHpDalRCquleOiTParq;
							bYSmccHQrQZpUKMnDdFzHeUanvsN = 0;
							goto IL_023c;
							IL_011b:
							if (WEljsIINRHPopukiprmxJNBGrwLL < LYxSaiZeTYJtrTgKXNeETSHQGmSx)
							{
								rTjfFhCcjUpgdDvOXSyRvwuRwGcDA = QDLLsHjvybsEmfbjpOKKTRItEipK.XyKTgMxvPKsPsAOqAWrzShIBzUTi(WEljsIINRHPopukiprmxJNBGrwLL).XCfFEHCAovUlErZTLVujHEbwOdRG;
								mNTkvnRynjWDckRGWDTUQuRZOAxQ = rTjfFhCcjUpgdDvOXSyRvwuRwGcDA.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								bYSmccHQrQZpUKMnDdFzHeUanvsN = 0;
								goto IL_00f6;
							}
							QDLLsHjvybsEmfbjpOKKTRItEipK = null;
							break;
							IL_0217:
							if (rGMHMZOTuJulkRhIuCvyEXahWjdC < zbUsryvIVqWUgHdAvcDkqyYwubuw)
							{
								if (rTjfFhCcjUpgdDvOXSyRvwuRwGcDA.vTSKHbrOptkhUmIMjLsBXHAVebGj(rGMHMZOTuJulkRhIuCvyEXahWjdC) is _0001 val)
								{
									pdPGPFgISOIPmFRiFBtYmprIFgJDC = val;
									byZBcdFZXZlsVgPJbRzNIfMxzKYS = 2;
									return true;
								}
								goto IL_0207;
							}
							rTjfFhCcjUpgdDvOXSyRvwuRwGcDA = null;
							bYSmccHQrQZpUKMnDdFzHeUanvsN++;
							goto IL_023c;
							IL_023c:
							if (bYSmccHQrQZpUKMnDdFzHeUanvsN < mNTkvnRynjWDckRGWDTUQuRZOAxQ)
							{
								rTjfFhCcjUpgdDvOXSyRvwuRwGcDA = QDLLsHjvybsEmfbjpOKKTRItEipK.XyKTgMxvPKsPsAOqAWrzShIBzUTi(bYSmccHQrQZpUKMnDdFzHeUanvsN).XCfFEHCAovUlErZTLVujHEbwOdRG;
								zbUsryvIVqWUgHdAvcDkqyYwubuw = rTjfFhCcjUpgdDvOXSyRvwuRwGcDA.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								rGMHMZOTuJulkRhIuCvyEXahWjdC = 0;
								goto IL_0217;
							}
							QDLLsHjvybsEmfbjpOKKTRItEipK = null;
							WEljsIINRHPopukiprmxJNBGrwLL++;
							goto IL_0264;
							IL_00f6:
							if (bYSmccHQrQZpUKMnDdFzHeUanvsN < mNTkvnRynjWDckRGWDTUQuRZOAxQ)
							{
								pdPGPFgISOIPmFRiFBtYmprIFgJDC = (_0001)rTjfFhCcjUpgdDvOXSyRvwuRwGcDA.vTSKHbrOptkhUmIMjLsBXHAVebGj(bYSmccHQrQZpUKMnDdFzHeUanvsN);
								byZBcdFZXZlsVgPJbRzNIfMxzKYS = 1;
								return true;
							}
							rTjfFhCcjUpgdDvOXSyRvwuRwGcDA = null;
							WEljsIINRHPopukiprmxJNBGrwLL++;
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
						IDdhDXLcSwRZSGgfcoNoBuFNfYae<_0001> ddhDXLcSwRZSGgfcoNoBuFNfYae;
						if (byZBcdFZXZlsVgPJbRzNIfMxzKYS == -2 && kyzNLlweeoUdWBdLIcbtVVbyibBAA == Environment.CurrentManagedThreadId)
						{
							byZBcdFZXZlsVgPJbRzNIfMxzKYS = 0;
							ddhDXLcSwRZSGgfcoNoBuFNfYae = this;
						}
						else
						{
							ddhDXLcSwRZSGgfcoNoBuFNfYae = new IDdhDXLcSwRZSGgfcoNoBuFNfYae<_0001>(0);
							ddhDXLcSwRZSGgfcoNoBuFNfYae.fFbfyiKgvjuRuVLFussSxPDsPrBs = fFbfyiKgvjuRuVLFussSxPDsPrBs;
						}
						return ddhDXLcSwRZSGgfcoNoBuFNfYae;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class iMdRjMzUgsRmMdCumYwemenubOJfA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int MZPmEPLQilxHKPiyvVnGJKCUVTWF;

					private ControllerMap PqfxbbPWYsblPKvaBFICriVwsGRA;

					private int LikIRUeFEfKPAlrMJrdSNVWQJHUL;

					public MapHelper iXnYgaqEGjCWDhgSkeWneuPGhTuN;

					private ControllerType igltDpmTOefCNBAvyIZxHXYsRGTj;

					public ControllerType jDleKoHUKNPrAuPRFBxieiTaKkYac;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd vbVIgVWWBYoWdixNTnARFHCPInpfA;

					private int gxGWzYmKjEmSTfyTMOVyZdvSIRyJ;

					private int lszFEcLYYugLerqvgfMbVbJOhBjD;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ USSaCYdzCVnZhPAANHDrcCPBxXBp;

					private int MCvgOrDiWtnFTVfYOfobBFwqtaEt;

					private int xPjaXyodPnNPYDbvNdNQnqmOsrGG;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return PqfxbbPWYsblPKvaBFICriVwsGRA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PqfxbbPWYsblPKvaBFICriVwsGRA;
						}
					}

					[DebuggerHidden]
					public iMdRjMzUgsRmMdCumYwemenubOJfA(int P_0)
					{
						MZPmEPLQilxHKPiyvVnGJKCUVTWF = P_0;
						LikIRUeFEfKPAlrMJrdSNVWQJHUL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int mZPmEPLQilxHKPiyvVnGJKCUVTWF = MZPmEPLQilxHKPiyvVnGJKCUVTWF;
						MapHelper mapHelper = iXnYgaqEGjCWDhgSkeWneuPGhTuN;
						if (mZPmEPLQilxHKPiyvVnGJKCUVTWF != 0)
						{
							if (mZPmEPLQilxHKPiyvVnGJKCUVTWF != 1)
							{
								return false;
							}
							MZPmEPLQilxHKPiyvVnGJKCUVTWF = -1;
							xPjaXyodPnNPYDbvNdNQnqmOsrGG++;
							goto IL_00e2;
						}
						MZPmEPLQilxHKPiyvVnGJKCUVTWF = -1;
						if (ReInput._id != mapHelper.ZlswVIRxaKsbbROVvxEyieXLglZjA)
						{
							ReInput.CheckInitialized(mapHelper.ZlswVIRxaKsbbROVvxEyieXLglZjA);
							return false;
						}
						vbVIgVWWBYoWdixNTnARFHCPInpfA = mapHelper.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(igltDpmTOefCNBAvyIZxHXYsRGTj);
						gxGWzYmKjEmSTfyTMOVyZdvSIRyJ = vbVIgVWWBYoWdixNTnARFHCPInpfA.umplaoBWNrHpDalRCquleOiTParq;
						lszFEcLYYugLerqvgfMbVbJOhBjD = 0;
						goto IL_0107;
						IL_00e2:
						if (xPjaXyodPnNPYDbvNdNQnqmOsrGG < MCvgOrDiWtnFTVfYOfobBFwqtaEt)
						{
							PqfxbbPWYsblPKvaBFICriVwsGRA = USSaCYdzCVnZhPAANHDrcCPBxXBp.vTSKHbrOptkhUmIMjLsBXHAVebGj(xPjaXyodPnNPYDbvNdNQnqmOsrGG);
							MZPmEPLQilxHKPiyvVnGJKCUVTWF = 1;
							return true;
						}
						USSaCYdzCVnZhPAANHDrcCPBxXBp = null;
						lszFEcLYYugLerqvgfMbVbJOhBjD++;
						goto IL_0107;
						IL_0107:
						if (lszFEcLYYugLerqvgfMbVbJOhBjD < gxGWzYmKjEmSTfyTMOVyZdvSIRyJ)
						{
							USSaCYdzCVnZhPAANHDrcCPBxXBp = vbVIgVWWBYoWdixNTnARFHCPInpfA.XyKTgMxvPKsPsAOqAWrzShIBzUTi(lszFEcLYYugLerqvgfMbVbJOhBjD).XCfFEHCAovUlErZTLVujHEbwOdRG;
							MCvgOrDiWtnFTVfYOfobBFwqtaEt = USSaCYdzCVnZhPAANHDrcCPBxXBp.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							xPjaXyodPnNPYDbvNdNQnqmOsrGG = 0;
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
						iMdRjMzUgsRmMdCumYwemenubOJfA iMdRjMzUgsRmMdCumYwemenubOJfA2;
						if (MZPmEPLQilxHKPiyvVnGJKCUVTWF == -2 && LikIRUeFEfKPAlrMJrdSNVWQJHUL == Environment.CurrentManagedThreadId)
						{
							MZPmEPLQilxHKPiyvVnGJKCUVTWF = 0;
							iMdRjMzUgsRmMdCumYwemenubOJfA2 = this;
						}
						else
						{
							iMdRjMzUgsRmMdCumYwemenubOJfA2 = new iMdRjMzUgsRmMdCumYwemenubOJfA(0);
							iMdRjMzUgsRmMdCumYwemenubOJfA2.iXnYgaqEGjCWDhgSkeWneuPGhTuN = iXnYgaqEGjCWDhgSkeWneuPGhTuN;
						}
						iMdRjMzUgsRmMdCumYwemenubOJfA2.igltDpmTOefCNBAvyIZxHXYsRGTj = jDleKoHUKNPrAuPRFBxieiTaKkYac;
						return iMdRjMzUgsRmMdCumYwemenubOJfA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class bAKsvwUeXvmOxbBfxBKmksdrmrzl : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int BoTGUZQUNbTgPPasNodlKONRqqaY;

					private ControllerMap QjeanowqHgdDpTijkXAkUVHtHpdw;

					private int HkijaYVkBMwpaaqnqecVsNugWNkx;

					public MapHelper UPCVDjlCEVsMBLHwuALQhHFJOKhHb;

					private int clyhFRymkcbMZbzHuyuYwJAAJsGh;

					public int YXejKjKnxJxzPrLimaYKUHnqwMsb;

					private int DNHqjAkwNLlrKuSJpsXQvLaZRzVg;

					private int jpUDvOvVPeobfstLMZIEXUyZqVOD;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd uWalqovKiICoUFokwGdsSlHQsyteA;

					private int DvboBmcwkTchDyKJJLKyDqJPfcux;

					private int yvRIpDiBYIhYuFfBBTnMOgyYfESP;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ WZMZIjRAtnCcxCRDpVodLBqpbhMJ;

					private int UHhITqLdmfdsXiRfxjUxfucCpZtfB;

					private int pFLyHfZgPqnxnBZNxneOcNbFxnfk;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return QjeanowqHgdDpTijkXAkUVHtHpdw;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QjeanowqHgdDpTijkXAkUVHtHpdw;
						}
					}

					[DebuggerHidden]
					public bAKsvwUeXvmOxbBfxBKmksdrmrzl(int P_0)
					{
						BoTGUZQUNbTgPPasNodlKONRqqaY = P_0;
						HkijaYVkBMwpaaqnqecVsNugWNkx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int boTGUZQUNbTgPPasNodlKONRqqaY = BoTGUZQUNbTgPPasNodlKONRqqaY;
						MapHelper uPCVDjlCEVsMBLHwuALQhHFJOKhHb = UPCVDjlCEVsMBLHwuALQhHFJOKhHb;
						if (boTGUZQUNbTgPPasNodlKONRqqaY != 0)
						{
							if (boTGUZQUNbTgPPasNodlKONRqqaY != 1)
							{
								return false;
							}
							BoTGUZQUNbTgPPasNodlKONRqqaY = -1;
							goto IL_0104;
						}
						BoTGUZQUNbTgPPasNodlKONRqqaY = -1;
						if (ReInput._id != uPCVDjlCEVsMBLHwuALQhHFJOKhHb.ZlswVIRxaKsbbROVvxEyieXLglZjA)
						{
							ReInput.CheckInitialized(uPCVDjlCEVsMBLHwuALQhHFJOKhHb.ZlswVIRxaKsbbROVvxEyieXLglZjA);
							return false;
						}
						DNHqjAkwNLlrKuSJpsXQvLaZRzVg = uPCVDjlCEVsMBLHwuALQhHFJOKhHb.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
						jpUDvOvVPeobfstLMZIEXUyZqVOD = 0;
						goto IL_0161;
						IL_0104:
						pFLyHfZgPqnxnBZNxneOcNbFxnfk++;
						goto IL_0114;
						IL_0161:
						if (jpUDvOvVPeobfstLMZIEXUyZqVOD < DNHqjAkwNLlrKuSJpsXQvLaZRzVg)
						{
							uWalqovKiICoUFokwGdsSlHQsyteA = uPCVDjlCEVsMBLHwuALQhHFJOKhHb.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(jpUDvOvVPeobfstLMZIEXUyZqVOD);
							DvboBmcwkTchDyKJJLKyDqJPfcux = uWalqovKiICoUFokwGdsSlHQsyteA.umplaoBWNrHpDalRCquleOiTParq;
							yvRIpDiBYIhYuFfBBTnMOgyYfESP = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (pFLyHfZgPqnxnBZNxneOcNbFxnfk < UHhITqLdmfdsXiRfxjUxfucCpZtfB)
						{
							ControllerMap controllerMap = WZMZIjRAtnCcxCRDpVodLBqpbhMJ.vTSKHbrOptkhUmIMjLsBXHAVebGj(pFLyHfZgPqnxnBZNxneOcNbFxnfk);
							if (controllerMap.categoryId == clyhFRymkcbMZbzHuyuYwJAAJsGh)
							{
								QjeanowqHgdDpTijkXAkUVHtHpdw = controllerMap;
								BoTGUZQUNbTgPPasNodlKONRqqaY = 1;
								return true;
							}
							goto IL_0104;
						}
						WZMZIjRAtnCcxCRDpVodLBqpbhMJ = null;
						yvRIpDiBYIhYuFfBBTnMOgyYfESP++;
						goto IL_0139;
						IL_0139:
						if (yvRIpDiBYIhYuFfBBTnMOgyYfESP < DvboBmcwkTchDyKJJLKyDqJPfcux)
						{
							WZMZIjRAtnCcxCRDpVodLBqpbhMJ = uWalqovKiICoUFokwGdsSlHQsyteA.XyKTgMxvPKsPsAOqAWrzShIBzUTi(yvRIpDiBYIhYuFfBBTnMOgyYfESP).XCfFEHCAovUlErZTLVujHEbwOdRG;
							UHhITqLdmfdsXiRfxjUxfucCpZtfB = WZMZIjRAtnCcxCRDpVodLBqpbhMJ.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							pFLyHfZgPqnxnBZNxneOcNbFxnfk = 0;
							goto IL_0114;
						}
						uWalqovKiICoUFokwGdsSlHQsyteA = null;
						jpUDvOvVPeobfstLMZIEXUyZqVOD++;
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
						bAKsvwUeXvmOxbBfxBKmksdrmrzl bAKsvwUeXvmOxbBfxBKmksdrmrzl2;
						if (BoTGUZQUNbTgPPasNodlKONRqqaY == -2 && HkijaYVkBMwpaaqnqecVsNugWNkx == Environment.CurrentManagedThreadId)
						{
							BoTGUZQUNbTgPPasNodlKONRqqaY = 0;
							bAKsvwUeXvmOxbBfxBKmksdrmrzl2 = this;
						}
						else
						{
							bAKsvwUeXvmOxbBfxBKmksdrmrzl2 = new bAKsvwUeXvmOxbBfxBKmksdrmrzl(0);
							bAKsvwUeXvmOxbBfxBKmksdrmrzl2.UPCVDjlCEVsMBLHwuALQhHFJOKhHb = UPCVDjlCEVsMBLHwuALQhHFJOKhHb;
						}
						bAKsvwUeXvmOxbBfxBKmksdrmrzl2.clyhFRymkcbMZbzHuyuYwJAAJsGh = YXejKjKnxJxzPrLimaYKUHnqwMsb;
						return bAKsvwUeXvmOxbBfxBKmksdrmrzl2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class bUvXffQqSLnSvIcEeToofoYSqQuQ<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int JqPvQJohUakGtaZhAbShZJaZbTwHA;

					private _0001 dDJhFyddswvilBStRdCjSUWXNtBlA;

					private int ESmSwNxnJnjniwcyEXGcZdHUeFQAA;

					public MapHelper CCEDpabTzitIwqvLFszzjaMkJaORA;

					private int JHoXguPtExXKutkZAKStmNbZdrki;

					public int jyheyUXGrhzflOncWyiaavzIxFpG;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd fVXLKWYdnOOdXsrvaEhswPKYoChe;

					private int nZsjwnXprZScyCPZHOyIWEyDPzut;

					private int bLMHhzzlEZwSRvfeSzzaQdfVatIT;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ VixtPfqVtruRuXHyMBFgfhmsCpPx;

					private int MGgraOCcdNMbepdKAnLBRyPzCZjs;

					private int llPbjctjTCASRVjcfUdvpJEZdWHg;

					private int aNllJBRuaBlCRimmjrwtTABXiSKV;

					private int zSQFgSkksGDUWsOUavQlfVRKjyhC;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return dDJhFyddswvilBStRdCjSUWXNtBlA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dDJhFyddswvilBStRdCjSUWXNtBlA;
						}
					}

					[DebuggerHidden]
					public bUvXffQqSLnSvIcEeToofoYSqQuQ(int P_0)
					{
						JqPvQJohUakGtaZhAbShZJaZbTwHA = P_0;
						ESmSwNxnJnjniwcyEXGcZdHUeFQAA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int jqPvQJohUakGtaZhAbShZJaZbTwHA = JqPvQJohUakGtaZhAbShZJaZbTwHA;
						MapHelper cCEDpabTzitIwqvLFszzjaMkJaORA = CCEDpabTzitIwqvLFszzjaMkJaORA;
						switch (jqPvQJohUakGtaZhAbShZJaZbTwHA)
						{
						default:
							return false;
						case 0:
						{
							JqPvQJohUakGtaZhAbShZJaZbTwHA = -1;
							if (ReInput._id != cCEDpabTzitIwqvLFszzjaMkJaORA.ZlswVIRxaKsbbROVvxEyieXLglZjA)
							{
								ReInput.CheckInitialized(cCEDpabTzitIwqvLFszzjaMkJaORA.ZlswVIRxaKsbbROVvxEyieXLglZjA);
								return false;
							}
							if (pMvvECjJycyKibKKCAXEnFbBPTVk.LbshPzWFARxecbNlUzfmeCirsbrs<_0001>(out var _))
							{
								fVXLKWYdnOOdXsrvaEhswPKYoChe = cCEDpabTzitIwqvLFszzjaMkJaORA.KVtyxWzVfPVirhAQibWNcJzwQwbc<_0001>();
								nZsjwnXprZScyCPZHOyIWEyDPzut = fVXLKWYdnOOdXsrvaEhswPKYoChe.umplaoBWNrHpDalRCquleOiTParq;
								bLMHhzzlEZwSRvfeSzzaQdfVatIT = 0;
								goto IL_0124;
							}
							nZsjwnXprZScyCPZHOyIWEyDPzut = cCEDpabTzitIwqvLFszzjaMkJaORA.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
							bLMHhzzlEZwSRvfeSzzaQdfVatIT = 0;
							goto IL_0287;
						}
						case 1:
							JqPvQJohUakGtaZhAbShZJaZbTwHA = -1;
							goto IL_00eb;
						case 2:
							{
								JqPvQJohUakGtaZhAbShZJaZbTwHA = -1;
								goto IL_0224;
							}
							IL_0224:
							zSQFgSkksGDUWsOUavQlfVRKjyhC++;
							goto IL_0236;
							IL_00eb:
							llPbjctjTCASRVjcfUdvpJEZdWHg++;
							goto IL_00fd;
							IL_0124:
							if (bLMHhzzlEZwSRvfeSzzaQdfVatIT < nZsjwnXprZScyCPZHOyIWEyDPzut)
							{
								VixtPfqVtruRuXHyMBFgfhmsCpPx = fVXLKWYdnOOdXsrvaEhswPKYoChe.XyKTgMxvPKsPsAOqAWrzShIBzUTi(bLMHhzzlEZwSRvfeSzzaQdfVatIT).XCfFEHCAovUlErZTLVujHEbwOdRG;
								MGgraOCcdNMbepdKAnLBRyPzCZjs = VixtPfqVtruRuXHyMBFgfhmsCpPx.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								llPbjctjTCASRVjcfUdvpJEZdWHg = 0;
								goto IL_00fd;
							}
							fVXLKWYdnOOdXsrvaEhswPKYoChe = null;
							break;
							IL_0287:
							if (bLMHhzzlEZwSRvfeSzzaQdfVatIT >= nZsjwnXprZScyCPZHOyIWEyDPzut)
							{
								break;
							}
							fVXLKWYdnOOdXsrvaEhswPKYoChe = cCEDpabTzitIwqvLFszzjaMkJaORA.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(bLMHhzzlEZwSRvfeSzzaQdfVatIT);
							MGgraOCcdNMbepdKAnLBRyPzCZjs = fVXLKWYdnOOdXsrvaEhswPKYoChe.umplaoBWNrHpDalRCquleOiTParq;
							llPbjctjTCASRVjcfUdvpJEZdWHg = 0;
							goto IL_025d;
							IL_0236:
							if (zSQFgSkksGDUWsOUavQlfVRKjyhC < aNllJBRuaBlCRimmjrwtTABXiSKV)
							{
								if (VixtPfqVtruRuXHyMBFgfhmsCpPx.vTSKHbrOptkhUmIMjLsBXHAVebGj(zSQFgSkksGDUWsOUavQlfVRKjyhC) is _0001 val && val.categoryId == JHoXguPtExXKutkZAKStmNbZdrki)
								{
									dDJhFyddswvilBStRdCjSUWXNtBlA = val;
									JqPvQJohUakGtaZhAbShZJaZbTwHA = 2;
									return true;
								}
								goto IL_0224;
							}
							VixtPfqVtruRuXHyMBFgfhmsCpPx = null;
							llPbjctjTCASRVjcfUdvpJEZdWHg++;
							goto IL_025d;
							IL_00fd:
							if (llPbjctjTCASRVjcfUdvpJEZdWHg < MGgraOCcdNMbepdKAnLBRyPzCZjs)
							{
								ControllerMap controllerMap = VixtPfqVtruRuXHyMBFgfhmsCpPx.vTSKHbrOptkhUmIMjLsBXHAVebGj(llPbjctjTCASRVjcfUdvpJEZdWHg);
								if (controllerMap.categoryId == JHoXguPtExXKutkZAKStmNbZdrki)
								{
									dDJhFyddswvilBStRdCjSUWXNtBlA = (_0001)controllerMap;
									JqPvQJohUakGtaZhAbShZJaZbTwHA = 1;
									return true;
								}
								goto IL_00eb;
							}
							VixtPfqVtruRuXHyMBFgfhmsCpPx = null;
							bLMHhzzlEZwSRvfeSzzaQdfVatIT++;
							goto IL_0124;
							IL_025d:
							if (llPbjctjTCASRVjcfUdvpJEZdWHg < MGgraOCcdNMbepdKAnLBRyPzCZjs)
							{
								VixtPfqVtruRuXHyMBFgfhmsCpPx = fVXLKWYdnOOdXsrvaEhswPKYoChe.XyKTgMxvPKsPsAOqAWrzShIBzUTi(llPbjctjTCASRVjcfUdvpJEZdWHg).XCfFEHCAovUlErZTLVujHEbwOdRG;
								aNllJBRuaBlCRimmjrwtTABXiSKV = VixtPfqVtruRuXHyMBFgfhmsCpPx.dPIPVObnFHWdtcklJKiYcLFrwbdF;
								zSQFgSkksGDUWsOUavQlfVRKjyhC = 0;
								goto IL_0236;
							}
							fVXLKWYdnOOdXsrvaEhswPKYoChe = null;
							bLMHhzzlEZwSRvfeSzzaQdfVatIT++;
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
						bUvXffQqSLnSvIcEeToofoYSqQuQ<_0001> bUvXffQqSLnSvIcEeToofoYSqQuQ2;
						if (JqPvQJohUakGtaZhAbShZJaZbTwHA == -2 && ESmSwNxnJnjniwcyEXGcZdHUeFQAA == Environment.CurrentManagedThreadId)
						{
							JqPvQJohUakGtaZhAbShZJaZbTwHA = 0;
							bUvXffQqSLnSvIcEeToofoYSqQuQ2 = this;
						}
						else
						{
							bUvXffQqSLnSvIcEeToofoYSqQuQ2 = new bUvXffQqSLnSvIcEeToofoYSqQuQ<_0001>(0);
							bUvXffQqSLnSvIcEeToofoYSqQuQ2.CCEDpabTzitIwqvLFszzjaMkJaORA = CCEDpabTzitIwqvLFszzjaMkJaORA;
						}
						bUvXffQqSLnSvIcEeToofoYSqQuQ2.JHoXguPtExXKutkZAKStmNbZdrki = jyheyUXGrhzflOncWyiaavzIxFpG;
						return bUvXffQqSLnSvIcEeToofoYSqQuQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class JiismeOIbldvIYBfVGnUBkMvatwkA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int zbDfJpqRoeaIljcXBOPRGEZAMcdmb;

					private ControllerMap eYZElmoEuDJaKofvlwGKLulOsbIH;

					private int UNMbEUfINTdaNQIpACIjidNiCMxNb;

					public MapHelper YEwdmVIjGUjcWEyffLbIfdJZeJWPc;

					private ControllerType oeqJdealAuChKxKVcDKhrmPkgkAA;

					public ControllerType cUwwkLPljkCiPCGemaGXeMTmEhLcb;

					private int qvUfqKMtKNLxkGOqYfUEyvSlOCiw;

					public int pdYrlDtaWaCwyyZnJAGVOOBFmibI;

					private unzVxbtGRmQZzSvYceNVtoUGFLPd JlvDzjvRmzcpJiHWVosvDBhrdUzV;

					private int zkMnuVoiNFofxdajWpOBOoQnoeoF;

					private int blcXVaHiqmXXqniwgPEmxphNHCZFA;

					private cAOEnjfvQnLBHThOTZsixNhIbMMJ BBgLRCuaEIAMFePIEMEjfhPHsHuhA;

					private int VLjxdtslJWizKOLvrEysDPPAkbpEb;

					private int ArRdtVtOHarSFgNZSjzbopOIBOyA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return eYZElmoEuDJaKofvlwGKLulOsbIH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return eYZElmoEuDJaKofvlwGKLulOsbIH;
						}
					}

					[DebuggerHidden]
					public JiismeOIbldvIYBfVGnUBkMvatwkA(int P_0)
					{
						zbDfJpqRoeaIljcXBOPRGEZAMcdmb = P_0;
						UNMbEUfINTdaNQIpACIjidNiCMxNb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = zbDfJpqRoeaIljcXBOPRGEZAMcdmb;
						MapHelper yEwdmVIjGUjcWEyffLbIfdJZeJWPc = YEwdmVIjGUjcWEyffLbIfdJZeJWPc;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							zbDfJpqRoeaIljcXBOPRGEZAMcdmb = -1;
							goto IL_00e2;
						}
						zbDfJpqRoeaIljcXBOPRGEZAMcdmb = -1;
						if (ReInput._id != yEwdmVIjGUjcWEyffLbIfdJZeJWPc.ZlswVIRxaKsbbROVvxEyieXLglZjA)
						{
							ReInput.CheckInitialized(yEwdmVIjGUjcWEyffLbIfdJZeJWPc.ZlswVIRxaKsbbROVvxEyieXLglZjA);
							return false;
						}
						JlvDzjvRmzcpJiHWVosvDBhrdUzV = yEwdmVIjGUjcWEyffLbIfdJZeJWPc.TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(oeqJdealAuChKxKVcDKhrmPkgkAA);
						zkMnuVoiNFofxdajWpOBOoQnoeoF = JlvDzjvRmzcpJiHWVosvDBhrdUzV.umplaoBWNrHpDalRCquleOiTParq;
						blcXVaHiqmXXqniwgPEmxphNHCZFA = 0;
						goto IL_0117;
						IL_00f2:
						if (ArRdtVtOHarSFgNZSjzbopOIBOyA < VLjxdtslJWizKOLvrEysDPPAkbpEb)
						{
							ControllerMap controllerMap = BBgLRCuaEIAMFePIEMEjfhPHsHuhA.vTSKHbrOptkhUmIMjLsBXHAVebGj(ArRdtVtOHarSFgNZSjzbopOIBOyA);
							if (controllerMap.categoryId == qvUfqKMtKNLxkGOqYfUEyvSlOCiw)
							{
								eYZElmoEuDJaKofvlwGKLulOsbIH = controllerMap;
								zbDfJpqRoeaIljcXBOPRGEZAMcdmb = 1;
								return true;
							}
							goto IL_00e2;
						}
						BBgLRCuaEIAMFePIEMEjfhPHsHuhA = null;
						blcXVaHiqmXXqniwgPEmxphNHCZFA++;
						goto IL_0117;
						IL_00e2:
						ArRdtVtOHarSFgNZSjzbopOIBOyA++;
						goto IL_00f2;
						IL_0117:
						if (blcXVaHiqmXXqniwgPEmxphNHCZFA < zkMnuVoiNFofxdajWpOBOoQnoeoF)
						{
							BBgLRCuaEIAMFePIEMEjfhPHsHuhA = JlvDzjvRmzcpJiHWVosvDBhrdUzV.XyKTgMxvPKsPsAOqAWrzShIBzUTi(blcXVaHiqmXXqniwgPEmxphNHCZFA).XCfFEHCAovUlErZTLVujHEbwOdRG;
							VLjxdtslJWizKOLvrEysDPPAkbpEb = BBgLRCuaEIAMFePIEMEjfhPHsHuhA.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							ArRdtVtOHarSFgNZSjzbopOIBOyA = 0;
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
						JiismeOIbldvIYBfVGnUBkMvatwkA jiismeOIbldvIYBfVGnUBkMvatwkA;
						if (zbDfJpqRoeaIljcXBOPRGEZAMcdmb == -2 && UNMbEUfINTdaNQIpACIjidNiCMxNb == Environment.CurrentManagedThreadId)
						{
							zbDfJpqRoeaIljcXBOPRGEZAMcdmb = 0;
							jiismeOIbldvIYBfVGnUBkMvatwkA = this;
						}
						else
						{
							jiismeOIbldvIYBfVGnUBkMvatwkA = new JiismeOIbldvIYBfVGnUBkMvatwkA(0);
							jiismeOIbldvIYBfVGnUBkMvatwkA.YEwdmVIjGUjcWEyffLbIfdJZeJWPc = YEwdmVIjGUjcWEyffLbIfdJZeJWPc;
						}
						jiismeOIbldvIYBfVGnUBkMvatwkA.qvUfqKMtKNLxkGOqYfUEyvSlOCiw = pdYrlDtaWaCwyyZnJAGVOOBFmibI;
						jiismeOIbldvIYBfVGnUBkMvatwkA.oeqJdealAuChKxKVcDKhrmPkgkAA = cUwwkLPljkCiPCGemaGXeMTmEhLcb;
						return jiismeOIbldvIYBfVGnUBkMvatwkA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly FGaEqsabChAigPfOzNCChKOtJbXxA cXRyXaxggpaJsZaemjqOBPdpLRojA;

				private Player uGaXRNkobFvqnjGuEcSTbzwjvaCE;

				private ControllerHelper TQlzyJwOQKbKYcTuWcLoNRFoMMUd;

				private readonly ControllerMapEnabler OdUFmiThpsaxDGLsHCKDqrIQbgitA;

				private readonly ControllerMapLayoutManager OfaQZOJpYbicCUgkHVCzqdElCNht;

				private readonly int ZlswVIRxaKsbbROVvxEyieXLglZjA;

				public ControllerMapLayoutManager layoutManager => OfaQZOJpYbicCUgkHVCzqdElCNht;

				public ControllerMapEnabler mapEnabler => OdUFmiThpsaxDGLsHCKDqrIQbgitA;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
						{
							ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return uGaXRNkobFvqnjGuEcSTbzwjvaCE.ChjszcuelKVDqAqbDuLbZvXLnYZV.RlKvfUYTewvvmbMXFjOtndRBcIeAA(uGaXRNkobFvqnjGuEcSTbzwjvaCE.bSdaAPhhDIswtzqbUxjtIHqKNnBS);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, FGaEqsabChAigPfOzNCChKOtJbXxA P_2, ControllerMapLayoutManager.LGBrMNZdvgtEkBpNABJGpIHRtmbV P_3, ControllerMapEnabler.ZppkwHkpXIKClTnElCTrJXPsNYtW P_4)
				{
					ZlswVIRxaKsbbROVvxEyieXLglZjA = ReInput.id;
					uGaXRNkobFvqnjGuEcSTbzwjvaCE = P_0;
					TQlzyJwOQKbKYcTuWcLoNRFoMMUd = P_1;
					cXRyXaxggpaJsZaemjqOBPdpLRojA = P_2;
					OdUFmiThpsaxDGLsHCKDqrIQbgitA = new ControllerMapEnabler(P_0, P_4);
					OfaQZOJpYbicCUgkHVCzqdElCNht = new ControllerMapLayoutManager(P_0, P_3);
					OfaQZOJpYbicCUgkHVCzqdElCNht.hHyjWwNggkfgmkXfLqDELNQAjexg += OdUFmiThpsaxDGLsHCKDqrIQbgitA.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					uKvUkNwoFerKUcSfJAvzEGpAogCw<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					kXvPiwbGGunSTLwXuQvIjJWupPko<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					lZgmIGNdoMYjvFKDcTteVefYAbVf(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					SOMBPpiEhhZHqPaltIrnvqHhuXPU(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					uKvUkNwoFerKUcSfJAvzEGpAogCw<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					kXvPiwbGGunSTLwXuQvIjJWupPko<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					lZgmIGNdoMYjvFKDcTteVefYAbVf(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					SOMBPpiEhhZHqPaltIrnvqHhuXPU(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void uKvUkNwoFerKUcSfJAvzEGpAogCw<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						JoSftUitpQFObQcRdHaaWaFYbspEb(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void kXvPiwbGGunSTLwXuQvIjJWupPko<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						KLHamqGhHEhWJZVRJYKXojbOLQUd(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void lZgmIGNdoMYjvFKDcTteVefYAbVf(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						JoSftUitpQFObQcRdHaaWaFYbspEb(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void SOMBPpiEhhZHqPaltIrnvqHhuXPU(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						KLHamqGhHEhWJZVRJYKXojbOLQUd(P_0, P_1, P_2, P_3, P_4);
					}
				}

				[IteratorStateMachine(typeof(JzyYowPiqbtKtxLOdmIJuPQDgOlY))]
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new JzyYowPiqbtKtxLOdmIJuPQDgOlY(-2)
					{
						JzdfdcuTkSuWrQppvntVaEkAgIEJ = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num; j++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.uFiXZDmUUZxCMuSCTyaBanWZsfue(results, true);
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(IDdhDXLcSwRZSGgfcoNoBuFNfYae))]
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new IDdhDXLcSwRZSGgfcoNoBuFNfYae<T>(-2)
					{
						fFbfyiKgvjuRuVLFussSxPDsPrBs = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (pMvvECjJycyKibKKCAXEnFbBPTVk.LbshPzWFARxecbNlUzfmeCirsbrs<T>(out var controllerType))
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int i = 0; i < num; i++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.zyodZAUtXJCcCQWFsOcMmHurfeIr(results, true);
						}
					}
					else
					{
						int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
						for (int j = 0; j < nQoHyMZYKlXumNJJFucpVpPhPqyH; j++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd3 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(j);
							int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd3.umplaoBWNrHpDalRCquleOiTParq;
							for (int k = 0; k < num2; k++)
							{
								unzVxbtGRmQZzSvYceNVtoUGFLPd3.XyKTgMxvPKsPsAOqAWrzShIBzUTi(k).XCfFEHCAovUlErZTLVujHEbwOdRG.zyodZAUtXJCcCQWFsOcMmHurfeIr(results, true);
							}
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(iMdRjMzUgsRmMdCumYwemenubOJfA))]
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new iMdRjMzUgsRmMdCumYwemenubOJfA(-2)
					{
						iXnYgaqEGjCWDhgSkeWneuPGhTuN = this,
						jDleKoHUKNPrAuPRFBxieiTaKkYac = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.uFiXZDmUUZxCMuSCTyaBanWZsfue(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				[IteratorStateMachine(typeof(bAKsvwUeXvmOxbBfxBKmksdrmrzl))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new bAKsvwUeXvmOxbBfxBKmksdrmrzl(-2)
					{
						UPCVDjlCEVsMBLHwuALQhHFJOKhHb = this,
						YXejKjKnxJxzPrLimaYKUHnqwMsb = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				[IteratorStateMachine(typeof(bUvXffQqSLnSvIcEeToofoYSqQuQ))]
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new bUvXffQqSLnSvIcEeToofoYSqQuQ<T>(-2)
					{
						CCEDpabTzitIwqvLFszzjaMkJaORA = this,
						jyheyUXGrhzflOncWyiaavzIxFpG = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				[IteratorStateMachine(typeof(JiismeOIbldvIYBfVGnUBkMvatwkA))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new JiismeOIbldvIYBfVGnUBkMvatwkA(-2)
					{
						YEwdmVIjGUjcWEyffLbIfdJZeJWPc = this,
						pdYrlDtaWaCwyyZnJAGVOOBFmibI = categoryId,
						cUwwkLPljkCiPCGemaGXeMTmEhLcb = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num; j++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.mXXILoxJQISGTPWejapKwCuWDBVK(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (pMvvECjJycyKibKKCAXEnFbBPTVk.LbshPzWFARxecbNlUzfmeCirsbrs<T>(out var controllerType))
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int i = 0; i < num; i++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.VfkIcgEybPAkyidRjeNbYvoCKXQAb(categoryId, results, true);
						}
					}
					else
					{
						int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
						for (int j = 0; j < nQoHyMZYKlXumNJJFucpVpPhPqyH; j++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd3 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(j);
							int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd3.umplaoBWNrHpDalRCquleOiTParq;
							for (int k = 0; k < num2; k++)
							{
								unzVxbtGRmQZzSvYceNVtoUGFLPd3.XyKTgMxvPKsPsAOqAWrzShIBzUTi(k).XCfFEHCAovUlErZTLVujHEbwOdRG.VfkIcgEybPAkyidRjeNbYvoCKXQAb(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.mXXILoxJQISGTPWejapKwCuWDBVK(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return kmCdCCcOqRRlAcYVWZXzZzUtRrlu<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return KKxDHchASZaAvcANJlhqLKeUPkkAB(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					return aoWqBmajNOIaIaHVkpwEmLiCcFqLA(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					return TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType).jxGNMeDStoCqCXFxSStAYeBTQCmC(controllerId)?.XCfFEHCAovUlErZTLVujHEbwOdRG.mXXILoxJQISGTPWejapKwCuWDBVK(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return HlWCcNkALUYYHKqYohHflaSbNnwU<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					hfLYAzMldWckrgTmUxrPPSWxmrCj hfLYAzMldWckrgTmUxrPPSWxmrCj2 = KVtyxWzVfPVirhAQibWNcJzwQwbc<T>().jxGNMeDStoCqCXFxSStAYeBTQCmC(controllerId);
					if (hfLYAzMldWckrgTmUxrPPSWxmrCj2 == null)
					{
						return 0;
					}
					hfLYAzMldWckrgTmUxrPPSWxmrCj2.XCfFEHCAovUlErZTLVujHEbwOdRG.VfkIcgEybPAkyidRjeNbYvoCKXQAb(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)VDmVzrZzDZBTQVlbRYaDWJCwadgx(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)UFHQeujEIbEXWBqbmgHdglefXxXIA(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return (T)xgpwdLDRWZtZxoaUWHTxpHGBwJcw(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.fWutEWSRGZiCSdXAHfPjOdoTHqPW(mapId);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return VDmVzrZzDZBTQVlbRYaDWJCwadgx(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return UFHQeujEIbEXWBqbmgHdglefXxXIA(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return xgpwdLDRWZtZxoaUWHTxpHGBwJcw(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)JfFYoAknvQQlGbrwHbKMmsDNDRMu(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return JfFYoAknvQQlGbrwHbKMmsDNDRMu(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						BmwVOqKalAddCcmltaaeBLOhXfQb(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						AVaSRouYasqkgxKttFnBvhYDwyvT(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						BmwVOqKalAddCcmltaaeBLOhXfQb(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						BmwVOqKalAddCcmltaaeBLOhXfQb(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						AVaSRouYasqkgxKttFnBvhYDwyvT(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						BmwVOqKalAddCcmltaaeBLOhXfQb(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return false;
					}
					return ZYSltmgLrWzfnQFprixbhcvsvEHJ(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return false;
					}
					return ZYSltmgLrWzfnQFprixbhcvsvEHJ(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return false;
					}
					return KDOSYnzxHDnDMMFpCuGVUOPLctcKA(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return false;
					}
					return KDOSYnzxHDnDMMFpCuGVUOPLctcKA(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						AiIwLvUiwwBMacGExsYcMSQPBKvTA(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						YagZkCQmSBBDLaNVmfoFhgATZnhf(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						AiIwLvUiwwBMacGExsYcMSQPBKvTA(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else if (mapId >= 0)
					{
						rWWEOhINslmPBknOWBfvmpVDLNod(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						viwmVkeTvLtCxOrJNFmovfmKtFz(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						FaHcoyDQmCpuTSVMhsQuidCCHljIb(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else if (mapId >= 0)
					{
						rWWEOhINslmPBknOWBfvmpVDLNod(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						viwmVkeTvLtCxOrJNFmovfmKtFz(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						FaHcoyDQmCpuTSVMhsQuidCCHljIb(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMaps(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.WAHmrQkTfVMcwJAGSsNNiprebbhE(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMapsInCategory(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMapsInCategory(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i));
						for (int j = 0; j < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; j++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.FdTukuwOVcUHvqlNIdvyGVDvxgyTA(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.FdTukuwOVcUHvqlNIdvyGVDvxgyTA(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
						for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.DejThZHWHQACkjdZxCbrSOUjlmag(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMapsInLayout(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.oWnpLRxwMFKUgwlDOHqlNsAnZCvg(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMapsForController(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMapsForController(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(controllerId);
					if (num >= 0)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.WAHmrQkTfVMcwJAGSsNNiprebbhE(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(controllerId);
					if (num >= 0)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.FdTukuwOVcUHvqlNIdvyGVDvxgyTA(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
					}
					else
					{
						ClearMapsForControllerInLayout(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(controllerId);
					if (num >= 0)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.oWnpLRxwMFKUgwlDOHqlNsAnZCvg(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					for (int i = 0; i < TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						ClearMaps(TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i), userAssignableOnly);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return ZdvwtlFGoEAUvNzWVEgelPeGQWeT(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return ZRYBEICGLYyICqAZAkTfdgUTrhtE(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						ActionElementMap actionElementMap = ZRYBEICGLYyICqAZAkTfdgUTrhtE(TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return kZVTnzuqLzlXSnpDIETahStjTPbs(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return WGdIVKXkNTGQujJQgsJgoNwtaATM(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(NmKzoMZoxKjeQRAmzErFtqQLGPyo))]
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new NmKzoMZoxKjeQRAmzErFtqQLGPyo(-2)
					{
						MdwgWPcFTloWYZaeqPnEetZgdbFYb = this,
						YiiQEuKvYGQMEPmMqhneHhQvkBxW = actionId,
						sZZODyLGZjGetFojUxFRNcwGtYznA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					return OfBQPuGXlcggBJultinmceDfWuDX(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					return lpwkJNitzxrsTGzvBdUuoLsbPAbC(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return SOzmkHTJJIHILiQLZIToJrxcbNcNA(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return pOvOwZRyvAXrhLiQcHlIhbhjkySt(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return bDkHivxObHBVucrUrDZuIjeyJDEIA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						ActionElementMap actionElementMap = bDkHivxObHBVucrUrDZuIjeyJDEIA(TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return usDWvRUvHuIVItfuQrWIQsZyvBmB(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return IeYYMvkbYfBgTGFbzHCRKabVlDzh(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(GZyxMkgBEISaAFXojLMEJLLBdOTc))]
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new GZyxMkgBEISaAFXojLMEJLLBdOTc(-2)
					{
						MlCJkkOvZrSQmXhSJCAORzvBpbcr = this,
						edigFzkAywkWwcDIltQQkveLRcdAA = actionId,
						GJTfEUafKoPwWxAtiZbSuRfmhneSA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return oTngtCkwPPIGhPGRCuCcjRZopharA(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return NbOSaBxgUcyXgtxnecAndpRSdqYU(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return QCShaWhLRXRUypuCqBmFHKyMSLUt(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return PogjBoBKopsNbJHWmHgXCgupcyXz(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return ZIShSrccLtsNvlAseoNWtrjfHsvQ(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						ActionElementMap actionElementMap = ZIShSrccLtsNvlAseoNWtrjfHsvQ(TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return keNfFNCjrnRWcrtGgBMbhwUjBDaHb(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return sFSFDyHyALAhlQmklZFPawpvEPGT(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(jyAFiPMOKtdOJocJvLfReiuAcHuH))]
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new jyAFiPMOKtdOJocJvLfReiuAcHuH(-2)
					{
						dpNpgItJlPBQMqYOEHWHnYgAMZXg = this,
						CdFhBfIKtjandzvThilXDVJXlgGD = actionId,
						TwpFGYHQZlBOSEajHfOJUpNMTBhRb = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return uedVModhCNlXBpEgsInxDPHQRKuK(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					return JbnCryyRxxjstfwJPpdxNDslrFnJ(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return ZLUDKmyFiSuPpIdIHppttydqqVvP(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, skipDisabledMaps);
					VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return mOaicZrsDJJHEVoLNqMesSJMWDLV(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, actionId, skipDisabledMaps);
					VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return mOaicZrsDJJHEVoLNqMesSJMWDLV(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, skipDisabledMaps);
					VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return XQBTJqubmpVcXmcIOcjQgITPEvxr(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, actionId, skipDisabledMaps);
					VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return XQBTJqubmpVcXmcIOcjQgITPEvxr(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, skipDisabledMaps, results);
					VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return vSxDviyLOiFgeTYSMQsSTkbuFirH(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, actionId, skipDisabledMaps, results);
					VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return vSxDviyLOiFgeTYSMQsSTkbuFirH(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<T>.array;
					}
					return vPpzFrBmSWLxBodhCcGkXIgExGcx<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return BPrpWxWdKxaOSfpHuyuQTRlhTmESA(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<T>.array;
					}
					return ybABDDjlNiFfaSoMhfzJbGCnenfdA<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return APDPkVEchTdOpeaGgNIXeITbBPJyA(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						ArrayTools.Combine(ref array, APDPkVEchTdOpeaGgNIXeITbBPJyA(TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int num = 0;
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num2; j++)
						{
							num += unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.VWGzdoBThkOUORuwXXbipcqAkOKr(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int num = 0;
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num2; i++)
					{
						num += unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.VWGzdoBThkOUORuwXXbipcqAkOKr(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					return TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType).jxGNMeDStoCqCXFxSStAYeBTQCmC(controllerId)?.XCfFEHCAovUlErZTLVujHEbwOdRG.VWGzdoBThkOUORuwXXbipcqAkOKr(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num2; j++)
						{
							num += unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.dXChXczPTMQuIwvXWqQAgmabauky(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						ControllerType controllerType = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.mElCMzgxjPgeRvvlDnlkQMRNcWthA(i);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num2; i++)
					{
						num += unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.dXChXczPTMQuIwvXWqQAgmabauky(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num2; i++)
					{
						num += unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.OJUwoTNqZzzoQeEhKnRbVDOvIEaz(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					return TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controller.type).jxGNMeDStoCqCXFxSStAYeBTQCmC(controller.id)?.XCfFEHCAovUlErZTLVujHEbwOdRG.dXChXczPTMQuIwvXWqQAgmabauky(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					return TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controller.type).jxGNMeDStoCqCXFxSStAYeBTQCmC(controller.id)?.XCfFEHCAovUlErZTLVujHEbwOdRG.OJUwoTNqZzzoQeEhKnRbVDOvIEaz(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						FtbdMhilYYbDcYJEVLnJEagRwxer(false);
						break;
					case ControllerType.Keyboard:
						PHrCsrQbySgaJgoPTrVydHoSzKVqA(false);
						break;
					case ControllerType.Mouse:
						FkItCCpSIQXMpguYktGhpYJfkWWg(false);
						break;
					case ControllerType.Custom:
						fnGLPBnRdSggBahZmFtOXrAMKEpN(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num; j++)
						{
							if (unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG.QmLrlBlcATRMWJelJvlKusVrkQqV(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
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
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num; i++)
					{
						if (unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.QmLrlBlcATRMWJelJvlKusVrkQqV(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return uGaXRNkobFvqnjGuEcSTbzwjvaCE.ChjszcuelKVDqAqbDuLbZvXLnYZV.HTrjSoiJIJXjtkLAhefMBsTvgqWT(uGaXRNkobFvqnjGuEcSTbzwjvaCE.bSdaAPhhDIswtzqbUxjtIHqKNnBS, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != ZlswVIRxaKsbbROVvxEyieXLglZjA)
					{
						ReInput.CheckInitialized(ZlswVIRxaKsbbROVvxEyieXLglZjA);
						return null;
					}
					return uGaXRNkobFvqnjGuEcSTbzwjvaCE.ChjszcuelKVDqAqbDuLbZvXLnYZV.WhFrPEcblINBrBoGPgGyBBcAnAKib(uGaXRNkobFvqnjGuEcSTbzwjvaCE.bSdaAPhhDIswtzqbUxjtIHqKNnBS, behaviorName);
				}

				internal void ScCJNQQMUEjRDEPsEnNNpdlVceCN()
				{
					OdUFmiThpsaxDGLsHCKDqrIQbgitA.LoadDefaults();
					OfaQZOJpYbicCUgkHVCzqdElCNht.LoadDefaults();
				}

				internal void FtbdMhilYYbDcYJEVLnJEagRwxer(bool P_0)
				{
					if (cXRyXaxggpaJsZaemjqOBPdpLRojA.BziOHMGXJuGZRhlTEFpkxBvsdCdy == null)
					{
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick);
					TQlzyJwOQKbKYcTuWcLoNRFoMMUd.KTGnihwWgjrSAXzmfssQSNNTwGSo.LKHntflETRpLKIgsFwjVjUTpTlcA();
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num; i++)
					{
						yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv bYDcyWECHLgfltcQBjcCpqKRnGVv = (yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv)unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.RaeomPUMtcefLDSAzqHUlBVAPqHO();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.ShwbZGTrLUidtHoOuNTxBfnGibOXb(j).enabled;
							}
						}
						bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.iTFhTnrpYoduWWIQFhlCVogFEeHN(false);
						for (int k = 0; k < cXRyXaxggpaJsZaemjqOBPdpLRojA.BziOHMGXJuGZRhlTEFpkxBvsdCdy.Length; k++)
						{
							ciGaLaretUAfMeHWXhhjbtToZNIv(bYDcyWECHLgfltcQBjcCpqKRnGVv.IXFfJcQlRcjJSXDHlZIdknOrcNrEA, bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr, cXRyXaxggpaJsZaemjqOBPdpLRojA.BziOHMGXJuGZRhlTEFpkxBvsdCdy[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.RaeomPUMtcefLDSAzqHUlBVAPqHO());
							for (int l = 0; l < num3; l++)
							{
								bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.ShwbZGTrLUidtHoOuNTxBfnGibOXb(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore;
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = false;
					OfaQZOJpYbicCUgkHVCzqdElCNht.Apply();
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void PHrCsrQbySgaJgoPTrVydHoSzKVqA(bool P_0)
				{
					if (cXRyXaxggpaJsZaemjqOBPdpLRojA.XdwqcfEhMtZQkjQmOqjsljlejnLGA == null)
					{
						return;
					}
					cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Keyboard).jxGNMeDStoCqCXFxSStAYeBTQCmC(0).XCfFEHCAovUlErZTLVujHEbwOdRG;
					bool[] array = null;
					if (!P_0)
					{
						int num = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(i).enabled;
						}
					}
					cAOEnjfvQnLBHThOTZsixNhIbMMJ2.WAHmrQkTfVMcwJAGSsNNiprebbhE(false);
					for (int j = 0; j < cXRyXaxggpaJsZaemjqOBPdpLRojA.XdwqcfEhMtZQkjQmOqjsljlejnLGA.Length; j++)
					{
						TVIGMrwEtFEKfGycARzmMhJONZcUA tVIGMrwEtFEKfGycARzmMhJONZcUA = cXRyXaxggpaJsZaemjqOBPdpLRojA.XdwqcfEhMtZQkjQmOqjsljlejnLGA[j];
						if (tVIGMrwEtFEKfGycARzmMhJONZcUA.whSlbAbOxXlbxImcsuElXrPNlDdS >= 0 && tVIGMrwEtFEKfGycARzmMhJONZcUA.FEULWlmVvmsgSVOyotuWSPiqrmUb >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, tVIGMrwEtFEKfGycARzmMhJONZcUA.whSlbAbOxXlbxImcsuElXrPNlDdS, tVIGMrwEtFEKfGycARzmMhJONZcUA.FEULWlmVvmsgSVOyotuWSPiqrmUb);
							if (P_0)
							{
								keyboardMap.enabled = tVIGMrwEtFEKfGycARzmMhJONZcUA.IRJNrpnGhBRgGUTRdWhFXPAnHgNK;
							}
							BmwVOqKalAddCcmltaaeBLOhXfQb(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF);
						for (int k = 0; k < num2; k++)
						{
							cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore;
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = false;
					OfaQZOJpYbicCUgkHVCzqdElCNht.Apply();
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void FkItCCpSIQXMpguYktGhpYJfkWWg(bool P_0)
				{
					if (cXRyXaxggpaJsZaemjqOBPdpLRojA.LiXasPKtgVaRaINANMdHFmtqraLQA == null)
					{
						return;
					}
					cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Mouse).jxGNMeDStoCqCXFxSStAYeBTQCmC(0).XCfFEHCAovUlErZTLVujHEbwOdRG;
					bool[] array = null;
					if (!P_0)
					{
						int num = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(i).enabled;
						}
					}
					cAOEnjfvQnLBHThOTZsixNhIbMMJ2.WAHmrQkTfVMcwJAGSsNNiprebbhE(false);
					for (int j = 0; j < cXRyXaxggpaJsZaemjqOBPdpLRojA.LiXasPKtgVaRaINANMdHFmtqraLQA.Length; j++)
					{
						TVIGMrwEtFEKfGycARzmMhJONZcUA tVIGMrwEtFEKfGycARzmMhJONZcUA = cXRyXaxggpaJsZaemjqOBPdpLRojA.LiXasPKtgVaRaINANMdHFmtqraLQA[j];
						if (tVIGMrwEtFEKfGycARzmMhJONZcUA.whSlbAbOxXlbxImcsuElXrPNlDdS >= 0 && tVIGMrwEtFEKfGycARzmMhJONZcUA.FEULWlmVvmsgSVOyotuWSPiqrmUb >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, tVIGMrwEtFEKfGycARzmMhJONZcUA.whSlbAbOxXlbxImcsuElXrPNlDdS, tVIGMrwEtFEKfGycARzmMhJONZcUA.FEULWlmVvmsgSVOyotuWSPiqrmUb);
							if (P_0)
							{
								mouseMap.enabled = tVIGMrwEtFEKfGycARzmMhJONZcUA.IRJNrpnGhBRgGUTRdWhFXPAnHgNK;
							}
							BmwVOqKalAddCcmltaaeBLOhXfQb(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF);
						for (int k = 0; k < num2; k++)
						{
							cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore;
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = false;
					OfaQZOJpYbicCUgkHVCzqdElCNht.Apply();
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void fnGLPBnRdSggBahZmFtOXrAMKEpN(bool P_0)
				{
					if (cXRyXaxggpaJsZaemjqOBPdpLRojA.jFiiypBRkHeDmtEOvDbHPWdNAqVtA == null)
					{
						return;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num; i++)
					{
						yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv bYDcyWECHLgfltcQBjcCpqKRnGVv = (yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv)unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.RaeomPUMtcefLDSAzqHUlBVAPqHO();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.ShwbZGTrLUidtHoOuNTxBfnGibOXb(j).enabled;
							}
						}
						bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.iTFhTnrpYoduWWIQFhlCVogFEeHN(false);
						for (int k = 0; k < cXRyXaxggpaJsZaemjqOBPdpLRojA.jFiiypBRkHeDmtEOvDbHPWdNAqVtA.Length; k++)
						{
							NPyWULQFsBpURKsfzdCGhuSmJDEQ(bYDcyWECHLgfltcQBjcCpqKRnGVv.IXFfJcQlRcjJSXDHlZIdknOrcNrEA, bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr, cXRyXaxggpaJsZaemjqOBPdpLRojA.jFiiypBRkHeDmtEOvDbHPWdNAqVtA[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.RaeomPUMtcefLDSAzqHUlBVAPqHO());
							for (int l = 0; l < num3; l++)
							{
								bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr.ShwbZGTrLUidtHoOuNTxBfnGibOXb(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore;
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = false;
					OfaQZOJpYbicCUgkHVCzqdElCNht.Apply();
					OfaQZOJpYbicCUgkHVCzqdElCNht.loadFromUserDataStore = loadFromUserDataStore;
				}

				private unzVxbtGRmQZzSvYceNVtoUGFLPd KVtyxWzVfPVirhAQibWNcJzwQwbc<_0001>() where _0001 : ControllerMap
				{
					return TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(pMvvECjJycyKibKKCAXEnFbBPTVk.SkNjRvhdpjKAujKrVASbRGtQyGXb<_0001>());
				}

				internal global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> CVsmJZGCrpynlUiWlHsIELLSaaSl(Joystick P_0, bool P_1)
				{
					if (P_0 == null || cXRyXaxggpaJsZaemjqOBPdpLRojA.BziOHMGXJuGZRhlTEFpkxBvsdCdy == null)
					{
						return null;
					}
					global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> igBMMomXzYsKPUuCnpqyGLgpzshG = new global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap>(P_0.id);
					for (int i = 0; i < cXRyXaxggpaJsZaemjqOBPdpLRojA.BziOHMGXJuGZRhlTEFpkxBvsdCdy.Length; i++)
					{
						ciGaLaretUAfMeHWXhhjbtToZNIv(P_0, igBMMomXzYsKPUuCnpqyGLgpzshG, cXRyXaxggpaJsZaemjqOBPdpLRojA.BziOHMGXJuGZRhlTEFpkxBvsdCdy[i], P_1);
					}
					if (igBMMomXzYsKPUuCnpqyGLgpzshG.RaeomPUMtcefLDSAzqHUlBVAPqHO() == 0)
					{
						return null;
					}
					return igBMMomXzYsKPUuCnpqyGLgpzshG;
				}

				private void ciGaLaretUAfMeHWXhhjbtToZNIv(Joystick P_0, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> P_1, TVIGMrwEtFEKfGycARzmMhJONZcUA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.whSlbAbOxXlbxImcsuElXrPNlDdS >= 0 && P_2.FEULWlmVvmsgSVOyotuWSPiqrmUb >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.gYrdCGSkLMLRiPRFTdAQQekZgBRu(P_0, P_2.whSlbAbOxXlbxImcsuElXrPNlDdS, P_2.FEULWlmVvmsgSVOyotuWSPiqrmUb);
						ESTpCbOkBFCpCFfteFzCbHaJDHXK(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.IRJNrpnGhBRgGUTRdWhFXPAnHgNK ? BoolOption.True : BoolOption.False);
						}
						P_1.pycDubsBYYWyaKsmZKewxhTHCcUk(joystickMap, boolOption);
					}
				}

				internal global::IgBMMomXzYsKPUuCnpqyGLgpzshG<CustomControllerMap> tGJFSnfAKfEIdGHGDNETyatlqhJd(CustomController P_0, bool P_1)
				{
					if (P_0 == null || cXRyXaxggpaJsZaemjqOBPdpLRojA.jFiiypBRkHeDmtEOvDbHPWdNAqVtA == null)
					{
						return null;
					}
					global::IgBMMomXzYsKPUuCnpqyGLgpzshG<CustomControllerMap> igBMMomXzYsKPUuCnpqyGLgpzshG = new global::IgBMMomXzYsKPUuCnpqyGLgpzshG<CustomControllerMap>(P_0.id);
					for (int i = 0; i < cXRyXaxggpaJsZaemjqOBPdpLRojA.jFiiypBRkHeDmtEOvDbHPWdNAqVtA.Length; i++)
					{
						NPyWULQFsBpURKsfzdCGhuSmJDEQ(P_0, igBMMomXzYsKPUuCnpqyGLgpzshG, cXRyXaxggpaJsZaemjqOBPdpLRojA.jFiiypBRkHeDmtEOvDbHPWdNAqVtA[i], P_1);
					}
					if (igBMMomXzYsKPUuCnpqyGLgpzshG.RaeomPUMtcefLDSAzqHUlBVAPqHO() == 0)
					{
						return null;
					}
					return igBMMomXzYsKPUuCnpqyGLgpzshG;
				}

				private void NPyWULQFsBpURKsfzdCGhuSmJDEQ(CustomController P_0, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<CustomControllerMap> P_1, TVIGMrwEtFEKfGycARzmMhJONZcUA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.whSlbAbOxXlbxImcsuElXrPNlDdS >= 0 && P_2.FEULWlmVvmsgSVOyotuWSPiqrmUb >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.TUkZAWXnygEsdIliJViGaMjbPySaA(P_2.whSlbAbOxXlbxImcsuElXrPNlDdS, P_0.sourceControllerId, P_2.FEULWlmVvmsgSVOyotuWSPiqrmUb);
						ESTpCbOkBFCpCFfteFzCbHaJDHXK(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.IRJNrpnGhBRgGUTRdWhFXPAnHgNK ? BoolOption.True : BoolOption.False);
						}
						P_1.pycDubsBYYWyaKsmZKewxhTHCcUk(customControllerMap, boolOption);
					}
				}

				internal void ESTpCbOkBFCpCFfteFzCbHaJDHXK(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = uGaXRNkobFvqnjGuEcSTbzwjvaCE.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
						P_0.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(P_1);
					}
				}

				private IList<_0001> kmCdCCcOqRRlAcYVWZXzZzUtRrlu<_0001>(int P_0) where _0001 : ControllerMap
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = KVtyxWzVfPVirhAQibWNcJzwQwbc<_0001>();
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.OTHClbrQcXCnssDoyJmJAaYPGLYu<_0001>();
				}

				private IList<_0001> UwNnUYQqiIINifmOPlwlVZMtuWTNA<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return KVtyxWzVfPVirhAQibWNcJzwQwbc<_0001>().EFKNXLZJHdgoPYngfcwzBLhZyKpc(P_0)?.XCfFEHCAovUlErZTLVujHEbwOdRG.OTHClbrQcXCnssDoyJmJAaYPGLYu<_0001>();
				}

				private IList<ControllerMap> KKxDHchASZaAvcANJlhqLKeUPkkAB(ControllerType P_0, int P_1)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
				}

				private IList<ControllerMap> UwNnUYQqiIINifmOPlwlVZMtuWTNA(Controller P_0)
				{
					return KKxDHchASZaAvcANJlhqLKeUPkkAB(P_0.type, P_0.id);
				}

				private void LdigWuBpWfAXhPoqrSNBAMhohqTM(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					JoSftUitpQFObQcRdHaaWaFYbspEb(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void eSuAEBfNSvOxGuTuUyUMUiFYeooZ(Controller P_0, int P_1, int P_2)
				{
					UjDjKsiiHUJMzXpgHYyNwEASpEfk(P_0, P_1, P_2, BoolOption.Default);
				}

				private void ekifQRhwpeCRTaMpbNjCuNUiivIuB(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					KLHamqGhHEhWJZVRJYKXojbOLQUd(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void CojgaAkHWQfECUaArXeWLSKNNmLGb(Controller P_0, string P_1, string P_2)
				{
					IMVbBpEBWUXGOBBkldjIWcNYSmodA(P_0, P_1, P_2, BoolOption.Default);
				}

				private void JoSftUitpQFObQcRdHaaWaFYbspEb(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num >= 0)
					{
						Controller controller = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb;
						ControllerMap controllerMap = ReInput.UserData.pmpsiHEijmkjdZKEijxiUJpJmdUO(controller, P_2, P_3);
						BmwVOqKalAddCcmltaaeBLOhXfQb(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void UjDjKsiiHUJMzXpgHYyNwEASpEfk(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					JoSftUitpQFObQcRdHaaWaFYbspEb(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void KLHamqGhHEhWJZVRJYKXojbOLQUd(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						JoSftUitpQFObQcRdHaaWaFYbspEb(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void IMVbBpEBWUXGOBBkldjIWcNYSmodA(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					KLHamqGhHEhWJZVRJYKXojbOLQUd(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void AVaSRouYasqkgxKttFnBvhYDwyvT(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0.type);
						int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_0.id);
						if (num >= 0)
						{
							ESTpCbOkBFCpCFfteFzCbHaJDHXK(P_0, P_1);
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.pjcKwlVjkGMmomxyiheMmoZQYsQe(P_1, P_2);
							OdUFmiThpsaxDGLsHCKDqrIQbgitA.Apply();
						}
					}
				}

				private void BmwVOqKalAddCcmltaaeBLOhXfQb(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						AVaSRouYasqkgxKttFnBvhYDwyvT(controller, P_2, P_3);
					}
				}

				private bool ZYSltmgLrWzfnQFprixbhcvsvEHJ(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0).ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.ctcJORaseVdEGWTaltoRzKkQCnen(P_0);
					if (!controllerMap.VRbbXiDzmMpStCRmIpyxpYvZIHmN(P_2))
					{
						return false;
					}
					BmwVOqKalAddCcmltaaeBLOhXfQb(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int pcNbEQFHMzvjBdAKOxVPpXBvKINV(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0).ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (ZYSltmgLrWzfnQFprixbhcvsvEHJ(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool KDOSYnzxHDnDMMFpCuGVUOPLctcKA(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0).ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.ctcJORaseVdEGWTaltoRzKkQCnen(P_0);
					if (!controllerMap.aCgJOqCmItyUDepKiDUWdUcxtvms(P_2))
					{
						return false;
					}
					BmwVOqKalAddCcmltaaeBLOhXfQb(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int tDRHpqaoxFsvaOZWrKAqCkYpSeavA(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0).ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (KDOSYnzxHDnDMMFpCuGVUOPLctcKA(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void AiIwLvUiwwBMacGExsYcMSQPBKvTA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num >= 0)
					{
						Controller controller = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb;
						ControllerMap controllerMap = ControllerMap.LUNDdDBVsDcbaPNGFVLvOAKUDshGA(controller, P_2, P_3);
						BmwVOqKalAddCcmltaaeBLOhXfQb(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void maQIeNoHXQcFKxBqGFAOKRhuOLqdb(Controller P_0, int P_1, int P_2)
				{
					AiIwLvUiwwBMacGExsYcMSQPBKvTA(P_0.type, P_0.id, P_1, P_2);
				}

				private void YagZkCQmSBBDLaNVmfoFhgATZnhf(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						AiIwLvUiwwBMacGExsYcMSQPBKvTA(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void WYYEqYIbtDgYJejlvUyglQjbIpIvA(Controller P_0, string P_1, string P_2)
				{
					YagZkCQmSBBDLaNVmfoFhgATZnhf(P_0.type, P_0.id, P_1, P_2);
				}

				private void rWWEOhINslmPBknOWBfvmpVDLNod(ControllerType P_0, int P_1, int P_2)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num >= 0)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.ApbGUuaCkmPNzcEirDGQkYiqYQct(P_2);
					}
				}

				private void TXVoxTYRUkwEfmfCKKPUotRBWmzm(Controller P_0, int P_1)
				{
					rWWEOhINslmPBknOWBfvmpVDLNod(P_0.type, P_0.id, P_1);
				}

				private void YiwgFBCaezEDryehUMlDoRoGcssbb(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num >= 0)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.WKSysfAbXmrdYtNKXQAeVTdQtdYM(P_2);
					}
				}

				private void mHICcAHrWWamkZsyaRHDCPWNfNgE(Controller P_0, ControllerMap P_1)
				{
					rWWEOhINslmPBknOWBfvmpVDLNod(P_0.type, P_0.id, P_1.id);
				}

				private void viwmVkeTvLtCxOrJNFmovfmKtFz(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num >= 0)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.DejThZHWHQACkjdZxCbrSOUjlmag(P_2, P_3);
					}
				}

				private void dYMeApFxENbzhFmnEtkgrBNavovtb(Controller P_0, int P_1, int P_2)
				{
					viwmVkeTvLtCxOrJNFmovfmKtFz(P_0.type, P_0.id, P_1, P_2);
				}

				private void FaHcoyDQmCpuTSVMhsQuidCCHljIb(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.DejThZHWHQACkjdZxCbrSOUjlmag(mapCategoryId, layoutId);
						}
					}
				}

				private void hDiDlcfoBcJTvAaVhPcZXsowNlJyA(Controller P_0, string P_1, string P_2)
				{
					FaHcoyDQmCpuTSVMhsQuidCCHljIb(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap VDmVzrZzDZBTQVlbRYaDWJCwadgx(ControllerType P_0, int P_1, int P_2)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					return unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.fWutEWSRGZiCSdXAHfPjOdoTHqPW(P_2);
				}

				private ControllerMap egBGqFuPVYNOUjFdGrmwGooRiKR(Controller P_0, int P_1)
				{
					return VDmVzrZzDZBTQVlbRYaDWJCwadgx(P_0.type, P_0.id, P_1);
				}

				private ControllerMap UFHQeujEIbEXWBqbmgHdglefXxXIA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					return unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.rheiopvirTnXMwxNBdbmJOZuIjOx(P_2, P_3);
				}

				private ControllerMap JTqLdmPMzWMxLixoxHQkBnJMDapE(Controller P_0, int P_1, int P_2)
				{
					return UFHQeujEIbEXWBqbmgHdglefXxXIA(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap xgpwdLDRWZtZxoaUWHTxpHGBwJcw(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return UFHQeujEIbEXWBqbmgHdglefXxXIA(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap QDyLlQitqBSZIwRxMASUcdQJciFK(Controller P_0, string P_1, string P_2)
				{
					return xgpwdLDRWZtZxoaUWHTxpHGBwJcw(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap JfFYoAknvQQlGbrwHbKMmsDNDRMu(ControllerType P_0, int P_1, int P_2)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					return unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.mLMEKjjBssTlhfsAsirVyiDkCEkjb(P_2);
				}

				private ControllerMap IzdsHVRAnmiThHVoSnQTAgeTkdWDb(Controller P_0, int P_1)
				{
					return JfFYoAknvQQlGbrwHbKMmsDNDRMu(P_0.type, P_0.id, P_1);
				}

				private ControllerMap nOBKnvmBjmcMiJZdPpLGKKPXBnpxA(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return JfFYoAknvQQlGbrwHbKMmsDNDRMu(P_0, P_1, mapCategoryId);
				}

				private ControllerMap kGtJfjALccOVGelYsYrQmlsJHeId(Controller P_0, string P_1)
				{
					return nOBKnvmBjmcMiJZdPpLGKKPXBnpxA(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] PxcgRlbWdFAWuIJNwrvObfxlmbZyA(ControllerType P_0)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = 0;
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						num += unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.dPIPVObnFHWdtcklJKiYcLFrwbdF;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; j++)
					{
						cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG;
						for (int k = 0; k < cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF; k++)
						{
							array[num] = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] BPrpWxWdKxaOSfpHuyuQTRlhTmESA(ControllerType P_0, int P_1, bool P_2)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG;
					for (int i = 0; i < cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF; i++)
					{
						ControllerMap controllerMap = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb;
						list.Add(ControllerMapSaveData.NpWHBrNTgtvAEnIawgZHiSnmWCDh(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] vPpzFrBmSWLxBodhCcGkXIgExGcx<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = pMvvECjJycyKibKKCAXEnFbBPTVk.cOFgbhhmfdLXQHXDShqzGIpKMXBrA<_0001>();
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG;
					for (int i = 0; i < cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF; i++)
					{
						ControllerMap controllerMap = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb;
						list.Add(ControllerMapSaveData.NpWHBrNTgtvAEnIawgZHiSnmWCDh<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] APDPkVEchTdOpeaGgNIXeITbBPJyA(ControllerType P_0, bool P_1)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG;
						for (int j = 0; j < cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF; j++)
						{
							ControllerMap controllerMap = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).KHNnRvXGgofSbETmKmwfENQvePGfb;
							list.Add(ControllerMapSaveData.NpWHBrNTgtvAEnIawgZHiSnmWCDh(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] ybABDDjlNiFfaSoMhfzJbGCnenfdA<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = pMvvECjJycyKibKKCAXEnFbBPTVk.cOFgbhhmfdLXQHXDShqzGIpKMXBrA<_0001>();
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG;
						for (int j = 0; j < cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF; j++)
						{
							ControllerMap controllerMap = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).KHNnRvXGgofSbETmKmwfENQvePGfb;
							list.Add(ControllerMapSaveData.NpWHBrNTgtvAEnIawgZHiSnmWCDh<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int hErmXaTvnhXmCTNTEShrDVyLCzWf(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return 0;
					}
					return unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.mXXILoxJQISGTPWejapKwCuWDBVK(P_2, P_3, false);
				}

				private int oxMjRCEbMrpoEqadddGaCiEdDDrUA(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return hErmXaTvnhXmCTNTEShrDVyLCzWf(P_0.type, P_0.id, P_1, P_2);
				}

				private int wyyMJiPVCvLTVkbwzbFpdIfUqofM(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return hErmXaTvnhXmCTNTEShrDVyLCzWf(P_0, P_1, mapCategoryId, P_3);
				}

				private int DAbyvxvNhQVaGJLADCcolTmVpIQh(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return wyyMJiPVCvLTVkbwzbFpdIfUqofM(P_0.type, P_0.id, P_1, P_2);
				}

				[IteratorStateMachine(typeof(CAYZlSBifkVnsdQZOxroZQasnsxI))]
				private IEnumerable<ControllerMap> aoWqBmajNOIaIaHVkpwEmLiCcFqLA(ControllerType P_0, int P_1, int P_2)
				{
					return new CAYZlSBifkVnsdQZOxroZQasnsxI(-2)
					{
						NvImDabpJvemFfYZKohUFlAqfODcA = this,
						bKXbthhavcLebLFHOiiTVZCSMaaqA = P_0,
						lubMJvSBUTpLvyguthQSlSrBgRNJ = P_1,
						rrbLaRZDGYYiBeoJSqEuftzJhgCC = P_2
					};
				}

				[IteratorStateMachine(typeof(fuaquNQfvvJhsjFejIkdgYRKEAJH))]
				private IEnumerable<_0001> HlWCcNkALUYYHKqYohHflaSbNnwU<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new fuaquNQfvvJhsjFejIkdgYRKEAJH<_0001>(-2)
					{
						aoOAUuQSNvkiTGnBbCHHUKQFeoRn = this,
						VuJaJBDQJLbNdDjbThrwFAwBMJnib = P_0,
						OebTSKtqYpRrVjFJqJrjErDrmvkR = P_1
					};
				}

				private ActionElementMap ZRYBEICGLYyICqAZAkTfdgUTrhtE(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
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

				private ActionElementMap wVQwecSxMzbLQzZxYVhtrFVabcmL(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return ZRYBEICGLYyICqAZAkTfdgUTrhtE(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(NundRmLQIKHQXhLCGQRNwFxafwGJA))]
				private IEnumerable<ActionElementMap> WGdIVKXkNTGQujJQgsJgoNwtaATM(ControllerType P_0, int P_1, bool P_2)
				{
					return new NundRmLQIKHQXhLCGQRNwFxafwGJA(-2)
					{
						adOIdLxHdzWqitVFIIEVTaWxRVQq = this,
						fujuSIfnlvgqheNeaKPAaaFGlFqy = P_0,
						UYYPDHapVYRIoFfmempHNdAgIIRBA = P_1,
						yvjFXxCFSBEQCWQbGlIGelCDJFIL = P_2
					};
				}

				private IEnumerable<ActionElementMap> CuQrKIEizyDzrdlORFdYxbrnyEcs(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return WGdIVKXkNTGQujJQgsJgoNwtaATM(P_0, num, P_2);
				}

				private ActionElementMap bDkHivxObHBVucrUrDZuIjeyJDEIA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
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

				private ActionElementMap CQkfGMjkjQEZVeDfZBtpljNfSPVKA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return bDkHivxObHBVucrUrDZuIjeyJDEIA(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(EBNlXMtlKsrlMELQqKgScvapQBHc))]
				private IEnumerable<ActionElementMap> IeYYMvkbYfBgTGFbzHCRKabVlDzh(ControllerType P_0, int P_1, bool P_2)
				{
					return new EBNlXMtlKsrlMELQqKgScvapQBHc(-2)
					{
						XqZkjlyJBysBlXfKNWjIVSRCDaUN = this,
						pXiELUuPvMWyyLGKROIBtFgZJJzx = P_0,
						idfVULaDTVxqJPCpWcWQuXMQPuZ = P_1,
						CENCkOMqYhTFUfAOaftptEdPECaHA = P_2
					};
				}

				private IEnumerable<ActionElementMap> CbkNJHuaiMqDHmincOFndtESeJhN(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return IeYYMvkbYfBgTGFbzHCRKabVlDzh(P_0, num, P_2);
				}

				private ActionElementMap ZIShSrccLtsNvlAseoNWtrjfHsvQ(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
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

				private ActionElementMap DWqTAgVhxLavsZqenSSRwqsAyOYs(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return ZIShSrccLtsNvlAseoNWtrjfHsvQ(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(mihDzncxnJvsufOPXPNEHpWmshzOA))]
				private IEnumerable<ActionElementMap> sFSFDyHyALAhlQmklZFPawpvEPGT(ControllerType P_0, int P_1, bool P_2)
				{
					return new mihDzncxnJvsufOPXPNEHpWmshzOA(-2)
					{
						oTWPSjZspGEFUQUSLsCvRDOSUZPM = this,
						UbgQvkYQRvrMijDAGauhBLTDgHI = P_0,
						pnZsxxbAYJUHBYHIrjdIkkynfoEoA = P_1,
						drKupBWrcKPPdqgZkfFHawmwbtYy = P_2
					};
				}

				private IEnumerable<ActionElementMap> JSRDGlwGCXGKBuubqKbtYyIwkTFB(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return sFSFDyHyALAhlQmklZFPawpvEPGT(P_0, num, P_2);
				}

				private int SOzmkHTJJIHILiQLZIToJrxcbNcNA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num2; j++)
						{
							cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG;
							int num3 = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.zxIHNhwcNoificncticNOWSTUgFvA(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int QCShaWhLRXRUypuCqBmFHKyMSLUt(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num2; j++)
						{
							cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG;
							int num3 = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							for (int k = 0; k < num3; k++)
							{
								if (cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.UPErmvGxbaexRBBoUJNfdGoesNwy(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int ZLUDKmyFiSuPpIdIHppttydqqVvP(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int nQoHyMZYKlXumNJJFucpVpPhPqyH = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
					for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
					{
						unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i);
						int num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
						for (int j = 0; j < num2; j++)
						{
							cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(j).XCfFEHCAovUlErZTLVujHEbwOdRG;
							int num3 = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.TPGoRsOaoYnEGuXZQSOypYbEQESv(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int lpwkJNitzxrsTGzvBdUuoLsbPAbC(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].zxIHNhwcNoificncticNOWSTUgFvA(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int TIjddCMVzgJfnVpiVMffSMfXUVoI(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return lpwkJNitzxrsTGzvBdUuoLsbPAbC(P_0, num, P_2, P_3, P_4);
				}

				private int NbOSaBxgUcyXgtxnecAndpRSdqYU(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).UPErmvGxbaexRBBoUJNfdGoesNwy(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int BsmsEepDeBAeCIjUvvqrDoWRQFDkA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return NbOSaBxgUcyXgtxnecAndpRSdqYU(P_0, num, P_2, P_3, P_4);
				}

				private int JbnCryyRxxjstfwJPpdxNDslrFnJ(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					for (int i = 0; i < unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq; i++)
					{
						IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].TPGoRsOaoYnEGuXZQSOypYbEQESv(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int NVgVZNvZBAZuSpFgLXLGMRPgmFR(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_1);
					return JbnCryyRxxjstfwJPpdxNDslrFnJ(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap ZdvwtlFGoEAUvNzWVEgelPeGQWeT(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
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

				private ActionElementMap BbptmmkqfckeVHsHweWaDGxnXCTi(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return ZdvwtlFGoEAUvNzWVEgelPeGQWeT(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(eWkUwmItgGoxTJQMFetmPWyMiieP))]
				private IEnumerable<ActionElementMap> kZVTnzuqLzlXSnpDIETahStjTPbs(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new eWkUwmItgGoxTJQMFetmPWyMiieP(-2)
					{
						tSJsZaOqNSrsLjYfjQShqkCfXQXE = this,
						eyMFtJkrnnNysiSyZSEaSEDJvbkBA = P_0,
						tUWjbrrFLnBmWNGBnvdtAydMzgx = P_1,
						MnLWjQHpuLTEKIorCjYMdhNCFxci = P_2,
						oSBDdjciNGGIWsxMjmCUikEBrHVN = P_3
					};
				}

				private IEnumerable<ActionElementMap> RXHEHWsNhldtqGOShCXbnODvvWxb(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return kZVTnzuqLzlXSnpDIETahStjTPbs(P_0, P_1, num, P_3);
				}

				private ActionElementMap pOvOwZRyvAXrhLiQcHlIhbhjkySt(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
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

				private ActionElementMap hzryqLLOVhznzpwSAveQFFjQgMbf(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return pOvOwZRyvAXrhLiQcHlIhbhjkySt(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(WWqrGeJopnPMCMywlmtqRMmTJBRG))]
				private IEnumerable<ActionElementMap> usDWvRUvHuIVItfuQrWIQsZyvBmB(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new WWqrGeJopnPMCMywlmtqRMmTJBRG(-2)
					{
						paNnxLRXIMOFlFEeCJvuSVZtDzqu = this,
						FrYzbZopyOmOUozmBVqzlqPwfsDk = P_0,
						ulrhAXGBEbyczHzzfeXuRFKLFopv = P_1,
						SNRQPhHAabhdyeWblpElaWTjjFwrA = P_2,
						FrxpGrRxFcBpfrkjdJpnDHNxVYUI = P_3
					};
				}

				private IEnumerable<ActionElementMap> sfHHVWGBlaokeuwalVRgdemvNYXA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return usDWvRUvHuIVItfuQrWIQsZyvBmB(P_0, P_1, num, P_3);
				}

				private ActionElementMap PogjBoBKopsNbJHWmHgXCgupcyXz(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
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

				private ActionElementMap betgbtlnSOQwhFlHErxmjFAYKRbG(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return PogjBoBKopsNbJHWmHgXCgupcyXz(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(BVgVDxmsqGmCDXSXVLuiKxnogdVi))]
				private IEnumerable<ActionElementMap> keNfFNCjrnRWcrtGgBMbhwUjBDaHb(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new BVgVDxmsqGmCDXSXVLuiKxnogdVi(-2)
					{
						qXLeExwhRMekgReXHqUMtzlxLSXW = this,
						MxAIhLwAiCHnkPLkdUWVqemBELvV = P_0,
						vqLwOOQKSqaTBNDqHGCRoDStwNQF = P_1,
						EOrwkpbkzHlAyzsteELKhSSJHGSs = P_2,
						vDtcmQpSZOGEJppeDTDYdkXEOwdS = P_3
					};
				}

				private IEnumerable<ActionElementMap> bcNCYmCJgFHATYsLpGERQHwPxZYW(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return keNfFNCjrnRWcrtGgBMbhwUjBDaHb(P_0, P_1, num, P_3);
				}

				private int OfBQPuGXlcggBJultinmceDfWuDX(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.zxIHNhwcNoificncticNOWSTUgFvA(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int VChRuLuTPNHNxyhJfCqOgnKAfideb(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return OfBQPuGXlcggBJultinmceDfWuDX(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int oTngtCkwPPIGhPGRCuCcjRZopharA(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.UPErmvGxbaexRBBoUJNfdGoesNwy(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int aFIpuzZuVSkobVeLzgNAtijuGExr(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return oTngtCkwPPIGhPGRCuCcjRZopharA(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int uedVModhCNlXBpEgsInxDPHQRKuK(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.ghrxZqMyoYcbUFqIXMxXbMUJPIAP(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).XCfFEHCAovUlErZTLVujHEbwOdRG.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].TPGoRsOaoYnEGuXZQSOypYbEQESv(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int maNYmXJXPmCHvnnNULJdJkNITnHV(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
					return uedVModhCNlXBpEgsInxDPHQRKuK(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap XQBTJqubmpVcXmcIOcjQgITPEvxr(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controller.type);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					for (int i = 0; i < num; i++)
					{
						cAOEnjfvQnLBHThOTZsixNhIbMMJ obj = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG;
						_ = obj.dPIPVObnFHWdtcklJKiYcLFrwbdF;
						IList<ControllerMap> list = obj.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.ULkNEiizKoMslClQddTEvQaQhqGD(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				[IteratorStateMachine(typeof(CxRzvoaOdZdhPgQybWzHDBMovmFq))]
				private IEnumerable<ActionElementMap> mOaicZrsDJJHEVoLNqMesSJMWDLV(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new CxRzvoaOdZdhPgQybWzHDBMovmFq(-2)
					{
						VNRuxWKLXLFEfSdQVcnQkfJbdFiT = this,
						CgWYkaeckhpRNncAGUPZOiXjemIm = P_0,
						UCKROzdcisfmJqWpDPDhuGCBMpZL = P_1,
						saPkQZBkavasUuxaBpqpoZspPCbx = P_2,
						ujTkDwvYJTRMRLKSIosbrqSJsbEN = P_3
					};
				}

				private int vSxDviyLOiFgeTYSMQsSTkbuFirH(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = TQlzyJwOQKbKYcTuWcLoNRFoMMUd.ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controller.type);
					int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						cAOEnjfvQnLBHThOTZsixNhIbMMJ obj = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).XCfFEHCAovUlErZTLVujHEbwOdRG;
						_ = obj.dPIPVObnFHWdtcklJKiYcLFrwbdF;
						IList<ControllerMap> list = obj.PtadOXaKnNYvHaIVdbIfOjXTOAmCA;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.xbMqqhNCHHsGgJNjWdODBOazhjtNA(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
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
				private sealed class XtwlpoQpsUTmpYjNASnFebkLHkifA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int UYssxhFHJXaZABcHYvYIkHuVRgxI;

					private ControllerPollingInfo iYHixiouXVAbflPdTemTGFfYnvfI;

					private int wZzFyZTnLXIKYSnHHzFhekmYBTlF;

					public PollingHelper nlZlkrOaoNCSnduEYrzzGKkNsrjJ;

					private IList<CustomController> TlVaNLEpwcfVEAnqiicwVHsJSwaHB;

					private int bOagerVcfsZMlEtbivvfYdoLdkLb;

					private int ASGzcsUtBEasiHnkGsUnHorqVpbO;

					private IEnumerator<ControllerPollingInfo> wbZVsmFTdsmzYXSdYpbcZeMzZbJi;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return iYHixiouXVAbflPdTemTGFfYnvfI;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return iYHixiouXVAbflPdTemTGFfYnvfI;
						}
					}

					[DebuggerHidden]
					public XtwlpoQpsUTmpYjNASnFebkLHkifA(int P_0)
					{
						UYssxhFHJXaZABcHYvYIkHuVRgxI = P_0;
						wZzFyZTnLXIKYSnHHzFhekmYBTlF = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int uYssxhFHJXaZABcHYvYIkHuVRgxI = UYssxhFHJXaZABcHYvYIkHuVRgxI;
						if (uYssxhFHJXaZABcHYvYIkHuVRgxI == -3 || uYssxhFHJXaZABcHYvYIkHuVRgxI == 1)
						{
							try
							{
							}
							finally
							{
								RBdSeeclXcSfOHfvjWGpolTMICcf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int uYssxhFHJXaZABcHYvYIkHuVRgxI = UYssxhFHJXaZABcHYvYIkHuVRgxI;
							PollingHelper pollingHelper = nlZlkrOaoNCSnduEYrzzGKkNsrjJ;
							if (uYssxhFHJXaZABcHYvYIkHuVRgxI != 0)
							{
								if (uYssxhFHJXaZABcHYvYIkHuVRgxI != 1)
								{
									return false;
								}
								UYssxhFHJXaZABcHYvYIkHuVRgxI = -3;
								goto IL_00c5;
							}
							UYssxhFHJXaZABcHYvYIkHuVRgxI = -1;
							TlVaNLEpwcfVEAnqiicwVHsJSwaHB = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							bOagerVcfsZMlEtbivvfYdoLdkLb = TlVaNLEpwcfVEAnqiicwVHsJSwaHB.Count;
							ASGzcsUtBEasiHnkGsUnHorqVpbO = 0;
							goto IL_00f1;
							IL_00c5:
							if (wbZVsmFTdsmzYXSdYpbcZeMzZbJi.MoveNext())
							{
								ControllerPollingInfo current = wbZVsmFTdsmzYXSdYpbcZeMzZbJi.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								iYHixiouXVAbflPdTemTGFfYnvfI = controllerPollingInfo;
								UYssxhFHJXaZABcHYvYIkHuVRgxI = 1;
								return true;
							}
							RBdSeeclXcSfOHfvjWGpolTMICcf();
							wbZVsmFTdsmzYXSdYpbcZeMzZbJi = null;
							ASGzcsUtBEasiHnkGsUnHorqVpbO++;
							goto IL_00f1;
							IL_00f1:
							if (ASGzcsUtBEasiHnkGsUnHorqVpbO < bOagerVcfsZMlEtbivvfYdoLdkLb)
							{
								wbZVsmFTdsmzYXSdYpbcZeMzZbJi = TlVaNLEpwcfVEAnqiicwVHsJSwaHB[ASGzcsUtBEasiHnkGsUnHorqVpbO].PollForAllAxes().GetEnumerator();
								UYssxhFHJXaZABcHYvYIkHuVRgxI = -3;
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

					private void RBdSeeclXcSfOHfvjWGpolTMICcf()
					{
						UYssxhFHJXaZABcHYvYIkHuVRgxI = -1;
						if (wbZVsmFTdsmzYXSdYpbcZeMzZbJi != null)
						{
							wbZVsmFTdsmzYXSdYpbcZeMzZbJi.Dispose();
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
						XtwlpoQpsUTmpYjNASnFebkLHkifA xtwlpoQpsUTmpYjNASnFebkLHkifA;
						if (UYssxhFHJXaZABcHYvYIkHuVRgxI == -2 && wZzFyZTnLXIKYSnHHzFhekmYBTlF == Environment.CurrentManagedThreadId)
						{
							UYssxhFHJXaZABcHYvYIkHuVRgxI = 0;
							xtwlpoQpsUTmpYjNASnFebkLHkifA = this;
						}
						else
						{
							xtwlpoQpsUTmpYjNASnFebkLHkifA = new XtwlpoQpsUTmpYjNASnFebkLHkifA(0);
							xtwlpoQpsUTmpYjNASnFebkLHkifA.nlZlkrOaoNCSnduEYrzzGKkNsrjJ = nlZlkrOaoNCSnduEYrzzGKkNsrjJ;
						}
						return xtwlpoQpsUTmpYjNASnFebkLHkifA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class hsBHulPvyeAdVoEwDctLGtXUzLuRA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int NvrmKlnVQBrmcFauXgLeUFgEobyA;

					private ControllerPollingInfo CpUTTAnHgIKIDoAaKuqSyXRkmePG;

					private int ILYBOXBAvoZytqcnybDdZbNDbOsw;

					public PollingHelper rHqypVvKQgzowiUzXsjQmkPhJXAP;

					private IList<CustomController> DdhkIToJbbpWnCZnsBMTNZwasoQc;

					private int jGTYaYCyeNpiJufrbAyToxJdOpE;

					private int ViTyskjBTWcCtEoRqsiyGVWoLWbl;

					private IEnumerator<ControllerPollingInfo> qqbOnevgPVupbFhfbQmxBBsREQjJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return CpUTTAnHgIKIDoAaKuqSyXRkmePG;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CpUTTAnHgIKIDoAaKuqSyXRkmePG;
						}
					}

					[DebuggerHidden]
					public hsBHulPvyeAdVoEwDctLGtXUzLuRA(int P_0)
					{
						NvrmKlnVQBrmcFauXgLeUFgEobyA = P_0;
						ILYBOXBAvoZytqcnybDdZbNDbOsw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int nvrmKlnVQBrmcFauXgLeUFgEobyA = NvrmKlnVQBrmcFauXgLeUFgEobyA;
						if (nvrmKlnVQBrmcFauXgLeUFgEobyA == -3 || nvrmKlnVQBrmcFauXgLeUFgEobyA == 1)
						{
							try
							{
							}
							finally
							{
								HlIIyASiGvFmFptXQepBgAtJNdlP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int nvrmKlnVQBrmcFauXgLeUFgEobyA = NvrmKlnVQBrmcFauXgLeUFgEobyA;
							PollingHelper pollingHelper = rHqypVvKQgzowiUzXsjQmkPhJXAP;
							if (nvrmKlnVQBrmcFauXgLeUFgEobyA != 0)
							{
								if (nvrmKlnVQBrmcFauXgLeUFgEobyA != 1)
								{
									return false;
								}
								NvrmKlnVQBrmcFauXgLeUFgEobyA = -3;
								goto IL_00c5;
							}
							NvrmKlnVQBrmcFauXgLeUFgEobyA = -1;
							DdhkIToJbbpWnCZnsBMTNZwasoQc = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							jGTYaYCyeNpiJufrbAyToxJdOpE = DdhkIToJbbpWnCZnsBMTNZwasoQc.Count;
							ViTyskjBTWcCtEoRqsiyGVWoLWbl = 0;
							goto IL_00f1;
							IL_00c5:
							if (qqbOnevgPVupbFhfbQmxBBsREQjJ.MoveNext())
							{
								ControllerPollingInfo current = qqbOnevgPVupbFhfbQmxBBsREQjJ.Current;
								ControllerPollingInfo cpUTTAnHgIKIDoAaKuqSyXRkmePG = new ControllerPollingInfo(current);
								cpUTTAnHgIKIDoAaKuqSyXRkmePG.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								CpUTTAnHgIKIDoAaKuqSyXRkmePG = cpUTTAnHgIKIDoAaKuqSyXRkmePG;
								NvrmKlnVQBrmcFauXgLeUFgEobyA = 1;
								return true;
							}
							HlIIyASiGvFmFptXQepBgAtJNdlP();
							qqbOnevgPVupbFhfbQmxBBsREQjJ = null;
							ViTyskjBTWcCtEoRqsiyGVWoLWbl++;
							goto IL_00f1;
							IL_00f1:
							if (ViTyskjBTWcCtEoRqsiyGVWoLWbl < jGTYaYCyeNpiJufrbAyToxJdOpE)
							{
								qqbOnevgPVupbFhfbQmxBBsREQjJ = DdhkIToJbbpWnCZnsBMTNZwasoQc[ViTyskjBTWcCtEoRqsiyGVWoLWbl].PollForAllButtons().GetEnumerator();
								NvrmKlnVQBrmcFauXgLeUFgEobyA = -3;
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

					private void HlIIyASiGvFmFptXQepBgAtJNdlP()
					{
						NvrmKlnVQBrmcFauXgLeUFgEobyA = -1;
						if (qqbOnevgPVupbFhfbQmxBBsREQjJ != null)
						{
							qqbOnevgPVupbFhfbQmxBBsREQjJ.Dispose();
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
						hsBHulPvyeAdVoEwDctLGtXUzLuRA hsBHulPvyeAdVoEwDctLGtXUzLuRA2;
						if (NvrmKlnVQBrmcFauXgLeUFgEobyA == -2 && ILYBOXBAvoZytqcnybDdZbNDbOsw == Environment.CurrentManagedThreadId)
						{
							NvrmKlnVQBrmcFauXgLeUFgEobyA = 0;
							hsBHulPvyeAdVoEwDctLGtXUzLuRA2 = this;
						}
						else
						{
							hsBHulPvyeAdVoEwDctLGtXUzLuRA2 = new hsBHulPvyeAdVoEwDctLGtXUzLuRA(0);
							hsBHulPvyeAdVoEwDctLGtXUzLuRA2.rHqypVvKQgzowiUzXsjQmkPhJXAP = rHqypVvKQgzowiUzXsjQmkPhJXAP;
						}
						return hsBHulPvyeAdVoEwDctLGtXUzLuRA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class sPhCwZeJItfluCNFMIYjiVhLKpxP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int jwiAHxDVbdFlrIotAUePMMLCmdIEE;

					private ControllerPollingInfo wfiUhWXGaGTyZvrrQuizywkbwghm;

					private int itWClQYHdGTEIbcfimhPeznJoUtm;

					public PollingHelper aSzvJigLurHSdNkzenBGgLjoaKOcA;

					private IList<CustomController> RTMiwnAGuGRIWpovixcLiNIgqluk;

					private int jYZNrBUzFrguKqPIHgTHJWzCNRWnA;

					private int JKjduStIzVkNFsMYyLVPzGvfCxpeA;

					private IEnumerator<ControllerPollingInfo> iKVKuTszdOogSuPiwFPCxIOhKkZi;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wfiUhWXGaGTyZvrrQuizywkbwghm;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wfiUhWXGaGTyZvrrQuizywkbwghm;
						}
					}

					[DebuggerHidden]
					public sPhCwZeJItfluCNFMIYjiVhLKpxP(int P_0)
					{
						jwiAHxDVbdFlrIotAUePMMLCmdIEE = P_0;
						itWClQYHdGTEIbcfimhPeznJoUtm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = jwiAHxDVbdFlrIotAUePMMLCmdIEE;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								xsOiqQffqahYodwteyjzaIvhDiJEb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = jwiAHxDVbdFlrIotAUePMMLCmdIEE;
							PollingHelper pollingHelper = aSzvJigLurHSdNkzenBGgLjoaKOcA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								jwiAHxDVbdFlrIotAUePMMLCmdIEE = -3;
								goto IL_00c5;
							}
							jwiAHxDVbdFlrIotAUePMMLCmdIEE = -1;
							RTMiwnAGuGRIWpovixcLiNIgqluk = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							jYZNrBUzFrguKqPIHgTHJWzCNRWnA = RTMiwnAGuGRIWpovixcLiNIgqluk.Count;
							JKjduStIzVkNFsMYyLVPzGvfCxpeA = 0;
							goto IL_00f1;
							IL_00c5:
							if (iKVKuTszdOogSuPiwFPCxIOhKkZi.MoveNext())
							{
								ControllerPollingInfo current = iKVKuTszdOogSuPiwFPCxIOhKkZi.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								wfiUhWXGaGTyZvrrQuizywkbwghm = controllerPollingInfo;
								jwiAHxDVbdFlrIotAUePMMLCmdIEE = 1;
								return true;
							}
							xsOiqQffqahYodwteyjzaIvhDiJEb();
							iKVKuTszdOogSuPiwFPCxIOhKkZi = null;
							JKjduStIzVkNFsMYyLVPzGvfCxpeA++;
							goto IL_00f1;
							IL_00f1:
							if (JKjduStIzVkNFsMYyLVPzGvfCxpeA < jYZNrBUzFrguKqPIHgTHJWzCNRWnA)
							{
								iKVKuTszdOogSuPiwFPCxIOhKkZi = RTMiwnAGuGRIWpovixcLiNIgqluk[JKjduStIzVkNFsMYyLVPzGvfCxpeA].PollForAllButtonsDown().GetEnumerator();
								jwiAHxDVbdFlrIotAUePMMLCmdIEE = -3;
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

					private void xsOiqQffqahYodwteyjzaIvhDiJEb()
					{
						jwiAHxDVbdFlrIotAUePMMLCmdIEE = -1;
						if (iKVKuTszdOogSuPiwFPCxIOhKkZi != null)
						{
							iKVKuTszdOogSuPiwFPCxIOhKkZi.Dispose();
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
						sPhCwZeJItfluCNFMIYjiVhLKpxP sPhCwZeJItfluCNFMIYjiVhLKpxP2;
						if (jwiAHxDVbdFlrIotAUePMMLCmdIEE == -2 && itWClQYHdGTEIbcfimhPeznJoUtm == Environment.CurrentManagedThreadId)
						{
							jwiAHxDVbdFlrIotAUePMMLCmdIEE = 0;
							sPhCwZeJItfluCNFMIYjiVhLKpxP2 = this;
						}
						else
						{
							sPhCwZeJItfluCNFMIYjiVhLKpxP2 = new sPhCwZeJItfluCNFMIYjiVhLKpxP(0);
							sPhCwZeJItfluCNFMIYjiVhLKpxP2.aSzvJigLurHSdNkzenBGgLjoaKOcA = aSzvJigLurHSdNkzenBGgLjoaKOcA;
						}
						return sPhCwZeJItfluCNFMIYjiVhLKpxP2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FwXAFhIihiHZlsVsnnFgiBOlvdKY : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GqqlEkQXuxPfsPpLciEJKmXHNvcBb;

					private ControllerPollingInfo ftrqARMoPSttZrnfKIpTCZsqHQMrA;

					private int XLFjaAHskMGrElKfQjISJLwXuqBPA;

					public PollingHelper jSDOKsxjBpHbUGePGsKuTqerIKNUA;

					private IList<CustomController> csZNIgRCkDcChfAZSUMOSCiaTMWX;

					private int AtgGrkHxedniikHOaDhFFaTuZWOn;

					private int DSmbrpKNwEiEYqQzCnYDPnNWPlJc;

					private IEnumerator<ControllerPollingInfo> YhOiEcycAPiSXiKpYlCoHJxyjQWAA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ftrqARMoPSttZrnfKIpTCZsqHQMrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ftrqARMoPSttZrnfKIpTCZsqHQMrA;
						}
					}

					[DebuggerHidden]
					public FwXAFhIihiHZlsVsnnFgiBOlvdKY(int P_0)
					{
						GqqlEkQXuxPfsPpLciEJKmXHNvcBb = P_0;
						XLFjaAHskMGrElKfQjISJLwXuqBPA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gqqlEkQXuxPfsPpLciEJKmXHNvcBb = GqqlEkQXuxPfsPpLciEJKmXHNvcBb;
						if (gqqlEkQXuxPfsPpLciEJKmXHNvcBb == -3 || gqqlEkQXuxPfsPpLciEJKmXHNvcBb == 1)
						{
							try
							{
							}
							finally
							{
								PKpIgwHKyEgrlgaJEKcRUSgubmom();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gqqlEkQXuxPfsPpLciEJKmXHNvcBb = GqqlEkQXuxPfsPpLciEJKmXHNvcBb;
							PollingHelper pollingHelper = jSDOKsxjBpHbUGePGsKuTqerIKNUA;
							if (gqqlEkQXuxPfsPpLciEJKmXHNvcBb != 0)
							{
								if (gqqlEkQXuxPfsPpLciEJKmXHNvcBb != 1)
								{
									return false;
								}
								GqqlEkQXuxPfsPpLciEJKmXHNvcBb = -3;
								goto IL_00c5;
							}
							GqqlEkQXuxPfsPpLciEJKmXHNvcBb = -1;
							csZNIgRCkDcChfAZSUMOSCiaTMWX = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							AtgGrkHxedniikHOaDhFFaTuZWOn = csZNIgRCkDcChfAZSUMOSCiaTMWX.Count;
							DSmbrpKNwEiEYqQzCnYDPnNWPlJc = 0;
							goto IL_00f1;
							IL_00c5:
							if (YhOiEcycAPiSXiKpYlCoHJxyjQWAA.MoveNext())
							{
								ControllerPollingInfo current = YhOiEcycAPiSXiKpYlCoHJxyjQWAA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								ftrqARMoPSttZrnfKIpTCZsqHQMrA = controllerPollingInfo;
								GqqlEkQXuxPfsPpLciEJKmXHNvcBb = 1;
								return true;
							}
							PKpIgwHKyEgrlgaJEKcRUSgubmom();
							YhOiEcycAPiSXiKpYlCoHJxyjQWAA = null;
							DSmbrpKNwEiEYqQzCnYDPnNWPlJc++;
							goto IL_00f1;
							IL_00f1:
							if (DSmbrpKNwEiEYqQzCnYDPnNWPlJc < AtgGrkHxedniikHOaDhFFaTuZWOn)
							{
								YhOiEcycAPiSXiKpYlCoHJxyjQWAA = csZNIgRCkDcChfAZSUMOSCiaTMWX[DSmbrpKNwEiEYqQzCnYDPnNWPlJc].PollForAllElements().GetEnumerator();
								GqqlEkQXuxPfsPpLciEJKmXHNvcBb = -3;
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

					private void PKpIgwHKyEgrlgaJEKcRUSgubmom()
					{
						GqqlEkQXuxPfsPpLciEJKmXHNvcBb = -1;
						if (YhOiEcycAPiSXiKpYlCoHJxyjQWAA != null)
						{
							YhOiEcycAPiSXiKpYlCoHJxyjQWAA.Dispose();
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
						FwXAFhIihiHZlsVsnnFgiBOlvdKY fwXAFhIihiHZlsVsnnFgiBOlvdKY;
						if (GqqlEkQXuxPfsPpLciEJKmXHNvcBb == -2 && XLFjaAHskMGrElKfQjISJLwXuqBPA == Environment.CurrentManagedThreadId)
						{
							GqqlEkQXuxPfsPpLciEJKmXHNvcBb = 0;
							fwXAFhIihiHZlsVsnnFgiBOlvdKY = this;
						}
						else
						{
							fwXAFhIihiHZlsVsnnFgiBOlvdKY = new FwXAFhIihiHZlsVsnnFgiBOlvdKY(0);
							fwXAFhIihiHZlsVsnnFgiBOlvdKY.jSDOKsxjBpHbUGePGsKuTqerIKNUA = jSDOKsxjBpHbUGePGsKuTqerIKNUA;
						}
						return fwXAFhIihiHZlsVsnnFgiBOlvdKY;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class SyxgghjPKwOsGgznEfhCksvwzuvkB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EKqnIJHmvdvyfFDCUfcfcFZJeJGyA;

					private ControllerPollingInfo qvktzBgENNnawYndIvfMODoAlwyq;

					private int ZHanMwflIAxSuHYyvAlTyCKSAdzdA;

					public PollingHelper nwgDlQaJhlHKKEaIJYhqROtZkBXXA;

					private IList<CustomController> rBLtQrmNvYCXCxnowPhKkdhtAeBg;

					private int DQIVHlfrauXDLNEzqNexOWJPEJWb;

					private int oVDSYgUNpeuFEetCpKTCdOgeEBZV;

					private IEnumerator<ControllerPollingInfo> HDcaSPdXnJyvZMXpjWYMDKIdqfMPA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qvktzBgENNnawYndIvfMODoAlwyq;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qvktzBgENNnawYndIvfMODoAlwyq;
						}
					}

					[DebuggerHidden]
					public SyxgghjPKwOsGgznEfhCksvwzuvkB(int P_0)
					{
						EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = P_0;
						ZHanMwflIAxSuHYyvAlTyCKSAdzdA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int eKqnIJHmvdvyfFDCUfcfcFZJeJGyA = EKqnIJHmvdvyfFDCUfcfcFZJeJGyA;
						if (eKqnIJHmvdvyfFDCUfcfcFZJeJGyA == -3 || eKqnIJHmvdvyfFDCUfcfcFZJeJGyA == 1)
						{
							try
							{
							}
							finally
							{
								RTpaThbKzOGklKUWjYayNaLRQXGiA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int eKqnIJHmvdvyfFDCUfcfcFZJeJGyA = EKqnIJHmvdvyfFDCUfcfcFZJeJGyA;
							PollingHelper pollingHelper = nwgDlQaJhlHKKEaIJYhqROtZkBXXA;
							if (eKqnIJHmvdvyfFDCUfcfcFZJeJGyA != 0)
							{
								if (eKqnIJHmvdvyfFDCUfcfcFZJeJGyA != 1)
								{
									return false;
								}
								EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = -3;
								goto IL_00c5;
							}
							EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = -1;
							rBLtQrmNvYCXCxnowPhKkdhtAeBg = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							DQIVHlfrauXDLNEzqNexOWJPEJWb = rBLtQrmNvYCXCxnowPhKkdhtAeBg.Count;
							oVDSYgUNpeuFEetCpKTCdOgeEBZV = 0;
							goto IL_00f1;
							IL_00c5:
							if (HDcaSPdXnJyvZMXpjWYMDKIdqfMPA.MoveNext())
							{
								ControllerPollingInfo current = HDcaSPdXnJyvZMXpjWYMDKIdqfMPA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								qvktzBgENNnawYndIvfMODoAlwyq = controllerPollingInfo;
								EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = 1;
								return true;
							}
							RTpaThbKzOGklKUWjYayNaLRQXGiA();
							HDcaSPdXnJyvZMXpjWYMDKIdqfMPA = null;
							oVDSYgUNpeuFEetCpKTCdOgeEBZV++;
							goto IL_00f1;
							IL_00f1:
							if (oVDSYgUNpeuFEetCpKTCdOgeEBZV < DQIVHlfrauXDLNEzqNexOWJPEJWb)
							{
								HDcaSPdXnJyvZMXpjWYMDKIdqfMPA = rBLtQrmNvYCXCxnowPhKkdhtAeBg[oVDSYgUNpeuFEetCpKTCdOgeEBZV].PollForAllElementsDown().GetEnumerator();
								EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = -3;
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

					private void RTpaThbKzOGklKUWjYayNaLRQXGiA()
					{
						EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = -1;
						if (HDcaSPdXnJyvZMXpjWYMDKIdqfMPA != null)
						{
							HDcaSPdXnJyvZMXpjWYMDKIdqfMPA.Dispose();
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
						SyxgghjPKwOsGgznEfhCksvwzuvkB syxgghjPKwOsGgznEfhCksvwzuvkB;
						if (EKqnIJHmvdvyfFDCUfcfcFZJeJGyA == -2 && ZHanMwflIAxSuHYyvAlTyCKSAdzdA == Environment.CurrentManagedThreadId)
						{
							EKqnIJHmvdvyfFDCUfcfcFZJeJGyA = 0;
							syxgghjPKwOsGgznEfhCksvwzuvkB = this;
						}
						else
						{
							syxgghjPKwOsGgznEfhCksvwzuvkB = new SyxgghjPKwOsGgznEfhCksvwzuvkB(0);
							syxgghjPKwOsGgznEfhCksvwzuvkB.nwgDlQaJhlHKKEaIJYhqROtZkBXXA = nwgDlQaJhlHKKEaIJYhqROtZkBXXA;
						}
						return syxgghjPKwOsGgznEfhCksvwzuvkB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WEPLGspqurExCzDvRQTWNUmMFwGM : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int MJASlIUFMcyNmNHmwuxwlbDViMmy;

					private ControllerPollingInfo jhMycwOfFDnEOZxtYgbRWgkCHIli;

					private int vvvprxuTPqPogwcDMfalFbXKDJxIA;

					public PollingHelper jpIkJewgCsmzvYecBEuaJHnfAGnr;

					private IList<Joystick> YGkVUOuEmqHMPExQwkWJuZovbHXm;

					private int YsLFjzTsKehLRKZqMtUrGKFykoXgb;

					private int dUpVbFLXbnDauLijhEWNOdeagSrL;

					private IEnumerator<ControllerPollingInfo> UEXNTIvHxAZNarWJUBDkCUdfKpUD;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return jhMycwOfFDnEOZxtYgbRWgkCHIli;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jhMycwOfFDnEOZxtYgbRWgkCHIli;
						}
					}

					[DebuggerHidden]
					public WEPLGspqurExCzDvRQTWNUmMFwGM(int P_0)
					{
						MJASlIUFMcyNmNHmwuxwlbDViMmy = P_0;
						vvvprxuTPqPogwcDMfalFbXKDJxIA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int mJASlIUFMcyNmNHmwuxwlbDViMmy = MJASlIUFMcyNmNHmwuxwlbDViMmy;
						if (mJASlIUFMcyNmNHmwuxwlbDViMmy == -3 || mJASlIUFMcyNmNHmwuxwlbDViMmy == 1)
						{
							try
							{
							}
							finally
							{
								NDtaKVxEUovKRjABckxQdDmyAXET();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int mJASlIUFMcyNmNHmwuxwlbDViMmy = MJASlIUFMcyNmNHmwuxwlbDViMmy;
							PollingHelper pollingHelper = jpIkJewgCsmzvYecBEuaJHnfAGnr;
							if (mJASlIUFMcyNmNHmwuxwlbDViMmy != 0)
							{
								if (mJASlIUFMcyNmNHmwuxwlbDViMmy != 1)
								{
									return false;
								}
								MJASlIUFMcyNmNHmwuxwlbDViMmy = -3;
								goto IL_00c5;
							}
							MJASlIUFMcyNmNHmwuxwlbDViMmy = -1;
							YGkVUOuEmqHMPExQwkWJuZovbHXm = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							YsLFjzTsKehLRKZqMtUrGKFykoXgb = YGkVUOuEmqHMPExQwkWJuZovbHXm.Count;
							dUpVbFLXbnDauLijhEWNOdeagSrL = 0;
							goto IL_00f1;
							IL_00c5:
							if (UEXNTIvHxAZNarWJUBDkCUdfKpUD.MoveNext())
							{
								ControllerPollingInfo current = UEXNTIvHxAZNarWJUBDkCUdfKpUD.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								jhMycwOfFDnEOZxtYgbRWgkCHIli = controllerPollingInfo;
								MJASlIUFMcyNmNHmwuxwlbDViMmy = 1;
								return true;
							}
							NDtaKVxEUovKRjABckxQdDmyAXET();
							UEXNTIvHxAZNarWJUBDkCUdfKpUD = null;
							dUpVbFLXbnDauLijhEWNOdeagSrL++;
							goto IL_00f1;
							IL_00f1:
							if (dUpVbFLXbnDauLijhEWNOdeagSrL < YsLFjzTsKehLRKZqMtUrGKFykoXgb)
							{
								UEXNTIvHxAZNarWJUBDkCUdfKpUD = YGkVUOuEmqHMPExQwkWJuZovbHXm[dUpVbFLXbnDauLijhEWNOdeagSrL].PollForAllAxes().GetEnumerator();
								MJASlIUFMcyNmNHmwuxwlbDViMmy = -3;
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

					private void NDtaKVxEUovKRjABckxQdDmyAXET()
					{
						MJASlIUFMcyNmNHmwuxwlbDViMmy = -1;
						if (UEXNTIvHxAZNarWJUBDkCUdfKpUD != null)
						{
							UEXNTIvHxAZNarWJUBDkCUdfKpUD.Dispose();
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
						WEPLGspqurExCzDvRQTWNUmMFwGM wEPLGspqurExCzDvRQTWNUmMFwGM;
						if (MJASlIUFMcyNmNHmwuxwlbDViMmy == -2 && vvvprxuTPqPogwcDMfalFbXKDJxIA == Environment.CurrentManagedThreadId)
						{
							MJASlIUFMcyNmNHmwuxwlbDViMmy = 0;
							wEPLGspqurExCzDvRQTWNUmMFwGM = this;
						}
						else
						{
							wEPLGspqurExCzDvRQTWNUmMFwGM = new WEPLGspqurExCzDvRQTWNUmMFwGM(0);
							wEPLGspqurExCzDvRQTWNUmMFwGM.jpIkJewgCsmzvYecBEuaJHnfAGnr = jpIkJewgCsmzvYecBEuaJHnfAGnr;
						}
						return wEPLGspqurExCzDvRQTWNUmMFwGM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wHhVRWPHaYXVixjZFVfeNGXFGfrjA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int syniiGqMKIVtvHtuZUEFVosXHzbj;

					private ControllerPollingInfo nncrUNcATeQgAPBNqSZTWkXOEXSV;

					private int ikXTjlIPpJJuNTmkACUbxwwIupce;

					public PollingHelper BZgzzuOfLteDHMogEMYdLMxbOEQH;

					private IList<Joystick> BOrmSIJBMFudKyRyqDPnloTVpmJb;

					private int aKvgFFZTTRDcEgeHtpANEMotXDsjA;

					private int cWiLIuUxobPmpBkqHLTVdefJjmPw;

					private IEnumerator<ControllerPollingInfo> syqXuJefEYlTnBbTaORanccHGXGHA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return nncrUNcATeQgAPBNqSZTWkXOEXSV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nncrUNcATeQgAPBNqSZTWkXOEXSV;
						}
					}

					[DebuggerHidden]
					public wHhVRWPHaYXVixjZFVfeNGXFGfrjA(int P_0)
					{
						syniiGqMKIVtvHtuZUEFVosXHzbj = P_0;
						ikXTjlIPpJJuNTmkACUbxwwIupce = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = syniiGqMKIVtvHtuZUEFVosXHzbj;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								JlRNjfRSBaanYEpDMcxaEhiFimtq();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = syniiGqMKIVtvHtuZUEFVosXHzbj;
							PollingHelper bZgzzuOfLteDHMogEMYdLMxbOEQH = BZgzzuOfLteDHMogEMYdLMxbOEQH;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								syniiGqMKIVtvHtuZUEFVosXHzbj = -3;
								goto IL_00c5;
							}
							syniiGqMKIVtvHtuZUEFVosXHzbj = -1;
							BOrmSIJBMFudKyRyqDPnloTVpmJb = bZgzzuOfLteDHMogEMYdLMxbOEQH.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							aKvgFFZTTRDcEgeHtpANEMotXDsjA = BOrmSIJBMFudKyRyqDPnloTVpmJb.Count;
							cWiLIuUxobPmpBkqHLTVdefJjmPw = 0;
							goto IL_00f1;
							IL_00c5:
							if (syqXuJefEYlTnBbTaORanccHGXGHA.MoveNext())
							{
								ControllerPollingInfo current = syqXuJefEYlTnBbTaORanccHGXGHA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = bZgzzuOfLteDHMogEMYdLMxbOEQH.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								nncrUNcATeQgAPBNqSZTWkXOEXSV = controllerPollingInfo;
								syniiGqMKIVtvHtuZUEFVosXHzbj = 1;
								return true;
							}
							JlRNjfRSBaanYEpDMcxaEhiFimtq();
							syqXuJefEYlTnBbTaORanccHGXGHA = null;
							cWiLIuUxobPmpBkqHLTVdefJjmPw++;
							goto IL_00f1;
							IL_00f1:
							if (cWiLIuUxobPmpBkqHLTVdefJjmPw < aKvgFFZTTRDcEgeHtpANEMotXDsjA)
							{
								syqXuJefEYlTnBbTaORanccHGXGHA = BOrmSIJBMFudKyRyqDPnloTVpmJb[cWiLIuUxobPmpBkqHLTVdefJjmPw].PollForAllButtons().GetEnumerator();
								syniiGqMKIVtvHtuZUEFVosXHzbj = -3;
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

					private void JlRNjfRSBaanYEpDMcxaEhiFimtq()
					{
						syniiGqMKIVtvHtuZUEFVosXHzbj = -1;
						if (syqXuJefEYlTnBbTaORanccHGXGHA != null)
						{
							syqXuJefEYlTnBbTaORanccHGXGHA.Dispose();
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
						wHhVRWPHaYXVixjZFVfeNGXFGfrjA wHhVRWPHaYXVixjZFVfeNGXFGfrjA2;
						if (syniiGqMKIVtvHtuZUEFVosXHzbj == -2 && ikXTjlIPpJJuNTmkACUbxwwIupce == Environment.CurrentManagedThreadId)
						{
							syniiGqMKIVtvHtuZUEFVosXHzbj = 0;
							wHhVRWPHaYXVixjZFVfeNGXFGfrjA2 = this;
						}
						else
						{
							wHhVRWPHaYXVixjZFVfeNGXFGfrjA2 = new wHhVRWPHaYXVixjZFVfeNGXFGfrjA(0);
							wHhVRWPHaYXVixjZFVfeNGXFGfrjA2.BZgzzuOfLteDHMogEMYdLMxbOEQH = BZgzzuOfLteDHMogEMYdLMxbOEQH;
						}
						return wHhVRWPHaYXVixjZFVfeNGXFGfrjA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class NXtHVKYgTHpJXBUEgujDXSBjvayV : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pIGIVkNCmHnFfwZaFuicieaSPSOU;

					private ControllerPollingInfo IgnFfxDKkMrsIaSPFlQgbPzDsvZVB;

					private int RUkFsrXsmiKEueGNolGEMqFVAFjc;

					public PollingHelper BAsihFELTSBNsnYqnZcJcdARqaVr;

					private IList<Joystick> jpGflEtRaxXirzzlvvPwYHNSxKvR;

					private int ohwcNkLIQOPnfyOBtRyhnUStmNPf;

					private int XDEKxFiTwogslwsdyrcPFUvKBdlB;

					private IEnumerator<ControllerPollingInfo> yWkJpsoRbivOrJmMDFbLKKZvBAlAb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return IgnFfxDKkMrsIaSPFlQgbPzDsvZVB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return IgnFfxDKkMrsIaSPFlQgbPzDsvZVB;
						}
					}

					[DebuggerHidden]
					public NXtHVKYgTHpJXBUEgujDXSBjvayV(int P_0)
					{
						pIGIVkNCmHnFfwZaFuicieaSPSOU = P_0;
						RUkFsrXsmiKEueGNolGEMqFVAFjc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pIGIVkNCmHnFfwZaFuicieaSPSOU;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								pRNySiRnWqsEJXniIWgrMRqfiDdM();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = pIGIVkNCmHnFfwZaFuicieaSPSOU;
							PollingHelper bAsihFELTSBNsnYqnZcJcdARqaVr = BAsihFELTSBNsnYqnZcJcdARqaVr;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pIGIVkNCmHnFfwZaFuicieaSPSOU = -3;
								goto IL_00c5;
							}
							pIGIVkNCmHnFfwZaFuicieaSPSOU = -1;
							jpGflEtRaxXirzzlvvPwYHNSxKvR = bAsihFELTSBNsnYqnZcJcdARqaVr.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							ohwcNkLIQOPnfyOBtRyhnUStmNPf = jpGflEtRaxXirzzlvvPwYHNSxKvR.Count;
							XDEKxFiTwogslwsdyrcPFUvKBdlB = 0;
							goto IL_00f1;
							IL_00c5:
							if (yWkJpsoRbivOrJmMDFbLKKZvBAlAb.MoveNext())
							{
								ControllerPollingInfo current = yWkJpsoRbivOrJmMDFbLKKZvBAlAb.Current;
								ControllerPollingInfo ignFfxDKkMrsIaSPFlQgbPzDsvZVB = new ControllerPollingInfo(current);
								ignFfxDKkMrsIaSPFlQgbPzDsvZVB.playerId = bAsihFELTSBNsnYqnZcJcdARqaVr.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								IgnFfxDKkMrsIaSPFlQgbPzDsvZVB = ignFfxDKkMrsIaSPFlQgbPzDsvZVB;
								pIGIVkNCmHnFfwZaFuicieaSPSOU = 1;
								return true;
							}
							pRNySiRnWqsEJXniIWgrMRqfiDdM();
							yWkJpsoRbivOrJmMDFbLKKZvBAlAb = null;
							XDEKxFiTwogslwsdyrcPFUvKBdlB++;
							goto IL_00f1;
							IL_00f1:
							if (XDEKxFiTwogslwsdyrcPFUvKBdlB < ohwcNkLIQOPnfyOBtRyhnUStmNPf)
							{
								yWkJpsoRbivOrJmMDFbLKKZvBAlAb = jpGflEtRaxXirzzlvvPwYHNSxKvR[XDEKxFiTwogslwsdyrcPFUvKBdlB].PollForAllButtonsDown().GetEnumerator();
								pIGIVkNCmHnFfwZaFuicieaSPSOU = -3;
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

					private void pRNySiRnWqsEJXniIWgrMRqfiDdM()
					{
						pIGIVkNCmHnFfwZaFuicieaSPSOU = -1;
						if (yWkJpsoRbivOrJmMDFbLKKZvBAlAb != null)
						{
							yWkJpsoRbivOrJmMDFbLKKZvBAlAb.Dispose();
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
						NXtHVKYgTHpJXBUEgujDXSBjvayV nXtHVKYgTHpJXBUEgujDXSBjvayV;
						if (pIGIVkNCmHnFfwZaFuicieaSPSOU == -2 && RUkFsrXsmiKEueGNolGEMqFVAFjc == Environment.CurrentManagedThreadId)
						{
							pIGIVkNCmHnFfwZaFuicieaSPSOU = 0;
							nXtHVKYgTHpJXBUEgujDXSBjvayV = this;
						}
						else
						{
							nXtHVKYgTHpJXBUEgujDXSBjvayV = new NXtHVKYgTHpJXBUEgujDXSBjvayV(0);
							nXtHVKYgTHpJXBUEgujDXSBjvayV.BAsihFELTSBNsnYqnZcJcdARqaVr = BAsihFELTSBNsnYqnZcJcdARqaVr;
						}
						return nXtHVKYgTHpJXBUEgujDXSBjvayV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class dgsftAeApGGzXmZJEARBcVnYTjDY : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int acMersdKSiMQMulUjrYGtlSHslPR;

					private ControllerPollingInfo dZsEoVHuSKCOpTOkRWxIJZAaJWuA;

					private int yLUKUdWdmFXdwyZlvtGPGPYWvgJx;

					public PollingHelper jtYHnKocWpDJoSyriaAmMppOQSjL;

					private IList<Joystick> iogNmFoZkZhUUfEknrWbelgHIHNO;

					private int WJlwjolLgqRdhEtnklxwvjrGbBij;

					private int JbEkhHNZawPJStfQPiZUSafbQrfm;

					private IEnumerator<ControllerPollingInfo> ReITqeGwzCDhdailjUgXKPSCksfD;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dZsEoVHuSKCOpTOkRWxIJZAaJWuA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dZsEoVHuSKCOpTOkRWxIJZAaJWuA;
						}
					}

					[DebuggerHidden]
					public dgsftAeApGGzXmZJEARBcVnYTjDY(int P_0)
					{
						acMersdKSiMQMulUjrYGtlSHslPR = P_0;
						yLUKUdWdmFXdwyZlvtGPGPYWvgJx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = acMersdKSiMQMulUjrYGtlSHslPR;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aCsXbnnxOrmiRrzKJZghUGcJhfwR();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = acMersdKSiMQMulUjrYGtlSHslPR;
							PollingHelper pollingHelper = jtYHnKocWpDJoSyriaAmMppOQSjL;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								acMersdKSiMQMulUjrYGtlSHslPR = -3;
								goto IL_00c5;
							}
							acMersdKSiMQMulUjrYGtlSHslPR = -1;
							iogNmFoZkZhUUfEknrWbelgHIHNO = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							WJlwjolLgqRdhEtnklxwvjrGbBij = iogNmFoZkZhUUfEknrWbelgHIHNO.Count;
							JbEkhHNZawPJStfQPiZUSafbQrfm = 0;
							goto IL_00f1;
							IL_00c5:
							if (ReITqeGwzCDhdailjUgXKPSCksfD.MoveNext())
							{
								ControllerPollingInfo current = ReITqeGwzCDhdailjUgXKPSCksfD.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								dZsEoVHuSKCOpTOkRWxIJZAaJWuA = controllerPollingInfo;
								acMersdKSiMQMulUjrYGtlSHslPR = 1;
								return true;
							}
							aCsXbnnxOrmiRrzKJZghUGcJhfwR();
							ReITqeGwzCDhdailjUgXKPSCksfD = null;
							JbEkhHNZawPJStfQPiZUSafbQrfm++;
							goto IL_00f1;
							IL_00f1:
							if (JbEkhHNZawPJStfQPiZUSafbQrfm < WJlwjolLgqRdhEtnklxwvjrGbBij)
							{
								ReITqeGwzCDhdailjUgXKPSCksfD = iogNmFoZkZhUUfEknrWbelgHIHNO[JbEkhHNZawPJStfQPiZUSafbQrfm].PollForAllElements().GetEnumerator();
								acMersdKSiMQMulUjrYGtlSHslPR = -3;
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

					private void aCsXbnnxOrmiRrzKJZghUGcJhfwR()
					{
						acMersdKSiMQMulUjrYGtlSHslPR = -1;
						if (ReITqeGwzCDhdailjUgXKPSCksfD != null)
						{
							ReITqeGwzCDhdailjUgXKPSCksfD.Dispose();
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
						dgsftAeApGGzXmZJEARBcVnYTjDY dgsftAeApGGzXmZJEARBcVnYTjDY2;
						if (acMersdKSiMQMulUjrYGtlSHslPR == -2 && yLUKUdWdmFXdwyZlvtGPGPYWvgJx == Environment.CurrentManagedThreadId)
						{
							acMersdKSiMQMulUjrYGtlSHslPR = 0;
							dgsftAeApGGzXmZJEARBcVnYTjDY2 = this;
						}
						else
						{
							dgsftAeApGGzXmZJEARBcVnYTjDY2 = new dgsftAeApGGzXmZJEARBcVnYTjDY(0);
							dgsftAeApGGzXmZJEARBcVnYTjDY2.jtYHnKocWpDJoSyriaAmMppOQSjL = jtYHnKocWpDJoSyriaAmMppOQSjL;
						}
						return dgsftAeApGGzXmZJEARBcVnYTjDY2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class LGIuzunrEfyOUHiItdOIgFqnIUTp : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int CdSSZVbQuGlMntFFrSmGkLPiQzrs;

					private ControllerPollingInfo qtdroYoFWYpjoTOpbltOwHTSSuvp;

					private int xidjDxuedNCftOZbDaQzslBQWwLs;

					public PollingHelper LmmpBxdAPiAhquNicTUxkyytJOaG;

					private IList<Joystick> PxbMmHQvhLVKrLhSwUecpEtusVVF;

					private int cdaeorFDqULdnsaHfkBSNSvYNxrEA;

					private int pJHkvzVEesLwPPjHpWOWbGQQLcHs;

					private IEnumerator<ControllerPollingInfo> ScmemMohFBnXsqiVGSBHWaodjmIc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qtdroYoFWYpjoTOpbltOwHTSSuvp;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qtdroYoFWYpjoTOpbltOwHTSSuvp;
						}
					}

					[DebuggerHidden]
					public LGIuzunrEfyOUHiItdOIgFqnIUTp(int P_0)
					{
						CdSSZVbQuGlMntFFrSmGkLPiQzrs = P_0;
						xidjDxuedNCftOZbDaQzslBQWwLs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int cdSSZVbQuGlMntFFrSmGkLPiQzrs = CdSSZVbQuGlMntFFrSmGkLPiQzrs;
						if (cdSSZVbQuGlMntFFrSmGkLPiQzrs == -3 || cdSSZVbQuGlMntFFrSmGkLPiQzrs == 1)
						{
							try
							{
							}
							finally
							{
								UvJWHGbjojNKmFaMbCSwmKoaHXIS();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int cdSSZVbQuGlMntFFrSmGkLPiQzrs = CdSSZVbQuGlMntFFrSmGkLPiQzrs;
							PollingHelper lmmpBxdAPiAhquNicTUxkyytJOaG = LmmpBxdAPiAhquNicTUxkyytJOaG;
							if (cdSSZVbQuGlMntFFrSmGkLPiQzrs != 0)
							{
								if (cdSSZVbQuGlMntFFrSmGkLPiQzrs != 1)
								{
									return false;
								}
								CdSSZVbQuGlMntFFrSmGkLPiQzrs = -3;
								goto IL_00c5;
							}
							CdSSZVbQuGlMntFFrSmGkLPiQzrs = -1;
							PxbMmHQvhLVKrLhSwUecpEtusVVF = lmmpBxdAPiAhquNicTUxkyytJOaG.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
							cdaeorFDqULdnsaHfkBSNSvYNxrEA = PxbMmHQvhLVKrLhSwUecpEtusVVF.Count;
							pJHkvzVEesLwPPjHpWOWbGQQLcHs = 0;
							goto IL_00f1;
							IL_00c5:
							if (ScmemMohFBnXsqiVGSBHWaodjmIc.MoveNext())
							{
								ControllerPollingInfo current = ScmemMohFBnXsqiVGSBHWaodjmIc.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = lmmpBxdAPiAhquNicTUxkyytJOaG.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								qtdroYoFWYpjoTOpbltOwHTSSuvp = controllerPollingInfo;
								CdSSZVbQuGlMntFFrSmGkLPiQzrs = 1;
								return true;
							}
							UvJWHGbjojNKmFaMbCSwmKoaHXIS();
							ScmemMohFBnXsqiVGSBHWaodjmIc = null;
							pJHkvzVEesLwPPjHpWOWbGQQLcHs++;
							goto IL_00f1;
							IL_00f1:
							if (pJHkvzVEesLwPPjHpWOWbGQQLcHs < cdaeorFDqULdnsaHfkBSNSvYNxrEA)
							{
								ScmemMohFBnXsqiVGSBHWaodjmIc = PxbMmHQvhLVKrLhSwUecpEtusVVF[pJHkvzVEesLwPPjHpWOWbGQQLcHs].PollForAllElementsDown().GetEnumerator();
								CdSSZVbQuGlMntFFrSmGkLPiQzrs = -3;
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

					private void UvJWHGbjojNKmFaMbCSwmKoaHXIS()
					{
						CdSSZVbQuGlMntFFrSmGkLPiQzrs = -1;
						if (ScmemMohFBnXsqiVGSBHWaodjmIc != null)
						{
							ScmemMohFBnXsqiVGSBHWaodjmIc.Dispose();
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
						LGIuzunrEfyOUHiItdOIgFqnIUTp lGIuzunrEfyOUHiItdOIgFqnIUTp;
						if (CdSSZVbQuGlMntFFrSmGkLPiQzrs == -2 && xidjDxuedNCftOZbDaQzslBQWwLs == Environment.CurrentManagedThreadId)
						{
							CdSSZVbQuGlMntFFrSmGkLPiQzrs = 0;
							lGIuzunrEfyOUHiItdOIgFqnIUTp = this;
						}
						else
						{
							lGIuzunrEfyOUHiItdOIgFqnIUTp = new LGIuzunrEfyOUHiItdOIgFqnIUTp(0);
							lGIuzunrEfyOUHiItdOIgFqnIUTp.LmmpBxdAPiAhquNicTUxkyytJOaG = LmmpBxdAPiAhquNicTUxkyytJOaG;
						}
						return lGIuzunrEfyOUHiItdOIgFqnIUTp;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class sCWgAolYwBMFjyMhLRNFlGYBWsPv : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int SuTMkVGFzMwMuyvJnVfotIoPIoJdA;

					private ControllerPollingInfo beHGtlEBZwCHEzdxNzXZuJAGwEeD;

					private int zSqEqQhaHvWdZCqKyBTGblGHdkHTA;

					private int ArlFXdBCjHQKzcfbyiQxWBxDjAufb;

					public int WDOMmtdVtfmAqthfZfaNJXsPNYl;

					public PollingHelper KczroUjmFVerQZOalvYlrJCzexJr;

					private IEnumerator<ControllerPollingInfo> cJxGilEelesTBJJbHUvOAobOgnzlA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return beHGtlEBZwCHEzdxNzXZuJAGwEeD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return beHGtlEBZwCHEzdxNzXZuJAGwEeD;
						}
					}

					[DebuggerHidden]
					public sCWgAolYwBMFjyMhLRNFlGYBWsPv(int P_0)
					{
						SuTMkVGFzMwMuyvJnVfotIoPIoJdA = P_0;
						zSqEqQhaHvWdZCqKyBTGblGHdkHTA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int suTMkVGFzMwMuyvJnVfotIoPIoJdA = SuTMkVGFzMwMuyvJnVfotIoPIoJdA;
						if (suTMkVGFzMwMuyvJnVfotIoPIoJdA == -3 || suTMkVGFzMwMuyvJnVfotIoPIoJdA == 1)
						{
							try
							{
							}
							finally
							{
								OUZmgzCaCHTkLPkczcKncsqFEPeZ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int suTMkVGFzMwMuyvJnVfotIoPIoJdA = SuTMkVGFzMwMuyvJnVfotIoPIoJdA;
							PollingHelper kczroUjmFVerQZOalvYlrJCzexJr = KczroUjmFVerQZOalvYlrJCzexJr;
							switch (suTMkVGFzMwMuyvJnVfotIoPIoJdA)
							{
							default:
								return false;
							case 0:
							{
								SuTMkVGFzMwMuyvJnVfotIoPIoJdA = -1;
								if (ArlFXdBCjHQKzcfbyiQxWBxDjAufb < 0)
								{
									return false;
								}
								CustomController customController = kczroUjmFVerQZOalvYlrJCzexJr.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(ArlFXdBCjHQKzcfbyiQxWBxDjAufb);
								if (customController == null)
								{
									return false;
								}
								cJxGilEelesTBJJbHUvOAobOgnzlA = customController.PollForAllAxes().GetEnumerator();
								SuTMkVGFzMwMuyvJnVfotIoPIoJdA = -3;
								break;
							}
							case 1:
								SuTMkVGFzMwMuyvJnVfotIoPIoJdA = -3;
								break;
							}
							if (cJxGilEelesTBJJbHUvOAobOgnzlA.MoveNext())
							{
								ControllerPollingInfo current = cJxGilEelesTBJJbHUvOAobOgnzlA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = kczroUjmFVerQZOalvYlrJCzexJr.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								beHGtlEBZwCHEzdxNzXZuJAGwEeD = controllerPollingInfo;
								SuTMkVGFzMwMuyvJnVfotIoPIoJdA = 1;
								return true;
							}
							OUZmgzCaCHTkLPkczcKncsqFEPeZ();
							cJxGilEelesTBJJbHUvOAobOgnzlA = null;
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

					private void OUZmgzCaCHTkLPkczcKncsqFEPeZ()
					{
						SuTMkVGFzMwMuyvJnVfotIoPIoJdA = -1;
						if (cJxGilEelesTBJJbHUvOAobOgnzlA != null)
						{
							cJxGilEelesTBJJbHUvOAobOgnzlA.Dispose();
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
						sCWgAolYwBMFjyMhLRNFlGYBWsPv sCWgAolYwBMFjyMhLRNFlGYBWsPv2;
						if (SuTMkVGFzMwMuyvJnVfotIoPIoJdA == -2 && zSqEqQhaHvWdZCqKyBTGblGHdkHTA == Environment.CurrentManagedThreadId)
						{
							SuTMkVGFzMwMuyvJnVfotIoPIoJdA = 0;
							sCWgAolYwBMFjyMhLRNFlGYBWsPv2 = this;
						}
						else
						{
							sCWgAolYwBMFjyMhLRNFlGYBWsPv2 = new sCWgAolYwBMFjyMhLRNFlGYBWsPv(0);
							sCWgAolYwBMFjyMhLRNFlGYBWsPv2.KczroUjmFVerQZOalvYlrJCzexJr = KczroUjmFVerQZOalvYlrJCzexJr;
						}
						sCWgAolYwBMFjyMhLRNFlGYBWsPv2.ArlFXdBCjHQKzcfbyiQxWBxDjAufb = WDOMmtdVtfmAqthfZfaNJXsPNYl;
						return sCWgAolYwBMFjyMhLRNFlGYBWsPv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class OSYbpccjmNnDamxAcKyMRlUMFNiB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int MdUfecCRyDbrMTQlEVcZBLVnMsdk;

					private ControllerPollingInfo rJgNhUbIzlCxnfTLKumkRFzYcAXw;

					private int HzblPglGWJolgUAGFjqxaIphhVSU;

					private int mIHnTfkKhCSurDVKCYAANrhwaFwc;

					public int kYrtGQxBeyjCwGjjhcWCoQwtJkIl;

					public PollingHelper ajwVnDbNixqmVYsjNnONesUpZAsD;

					private IEnumerator<ControllerPollingInfo> wLKSszoChFLEGanmKvSxFDACAktO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rJgNhUbIzlCxnfTLKumkRFzYcAXw;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rJgNhUbIzlCxnfTLKumkRFzYcAXw;
						}
					}

					[DebuggerHidden]
					public OSYbpccjmNnDamxAcKyMRlUMFNiB(int P_0)
					{
						MdUfecCRyDbrMTQlEVcZBLVnMsdk = P_0;
						HzblPglGWJolgUAGFjqxaIphhVSU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int mdUfecCRyDbrMTQlEVcZBLVnMsdk = MdUfecCRyDbrMTQlEVcZBLVnMsdk;
						if (mdUfecCRyDbrMTQlEVcZBLVnMsdk == -3 || mdUfecCRyDbrMTQlEVcZBLVnMsdk == 1)
						{
							try
							{
							}
							finally
							{
								FAdDOArpYxkXuNOewsONNkJDUray();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int mdUfecCRyDbrMTQlEVcZBLVnMsdk = MdUfecCRyDbrMTQlEVcZBLVnMsdk;
							PollingHelper pollingHelper = ajwVnDbNixqmVYsjNnONesUpZAsD;
							switch (mdUfecCRyDbrMTQlEVcZBLVnMsdk)
							{
							default:
								return false;
							case 0:
							{
								MdUfecCRyDbrMTQlEVcZBLVnMsdk = -1;
								if (mIHnTfkKhCSurDVKCYAANrhwaFwc < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(mIHnTfkKhCSurDVKCYAANrhwaFwc);
								if (customController == null)
								{
									return false;
								}
								wLKSszoChFLEGanmKvSxFDACAktO = customController.PollForAllButtons().GetEnumerator();
								MdUfecCRyDbrMTQlEVcZBLVnMsdk = -3;
								break;
							}
							case 1:
								MdUfecCRyDbrMTQlEVcZBLVnMsdk = -3;
								break;
							}
							if (wLKSszoChFLEGanmKvSxFDACAktO.MoveNext())
							{
								ControllerPollingInfo current = wLKSszoChFLEGanmKvSxFDACAktO.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								rJgNhUbIzlCxnfTLKumkRFzYcAXw = controllerPollingInfo;
								MdUfecCRyDbrMTQlEVcZBLVnMsdk = 1;
								return true;
							}
							FAdDOArpYxkXuNOewsONNkJDUray();
							wLKSszoChFLEGanmKvSxFDACAktO = null;
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

					private void FAdDOArpYxkXuNOewsONNkJDUray()
					{
						MdUfecCRyDbrMTQlEVcZBLVnMsdk = -1;
						if (wLKSszoChFLEGanmKvSxFDACAktO != null)
						{
							wLKSszoChFLEGanmKvSxFDACAktO.Dispose();
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
						OSYbpccjmNnDamxAcKyMRlUMFNiB oSYbpccjmNnDamxAcKyMRlUMFNiB;
						if (MdUfecCRyDbrMTQlEVcZBLVnMsdk == -2 && HzblPglGWJolgUAGFjqxaIphhVSU == Environment.CurrentManagedThreadId)
						{
							MdUfecCRyDbrMTQlEVcZBLVnMsdk = 0;
							oSYbpccjmNnDamxAcKyMRlUMFNiB = this;
						}
						else
						{
							oSYbpccjmNnDamxAcKyMRlUMFNiB = new OSYbpccjmNnDamxAcKyMRlUMFNiB(0);
							oSYbpccjmNnDamxAcKyMRlUMFNiB.ajwVnDbNixqmVYsjNnONesUpZAsD = ajwVnDbNixqmVYsjNnONesUpZAsD;
						}
						oSYbpccjmNnDamxAcKyMRlUMFNiB.mIHnTfkKhCSurDVKCYAANrhwaFwc = kYrtGQxBeyjCwGjjhcWCoQwtJkIl;
						return oSYbpccjmNnDamxAcKyMRlUMFNiB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fJfeNFTqfrHkDQvWBjqYDLXRxsZv : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int RirXSnDUCrarqWGZAXhfeKfHnQMl;

					private ControllerPollingInfo LmVJgxrxeClLpuyiOwXogRrexRSi;

					private int dZXHZBpRsVhLqEYYBTLItKyhcROHA;

					private int gghZpCHqBleddwRpNeGNaPpKsNGh;

					public int vhMZMEnVDUgQfieRtGnjgptHECQQA;

					public PollingHelper bbFejVNMvcdRgaLYLdaDXGOmbVVgb;

					private IEnumerator<ControllerPollingInfo> ArhzmniBThJHoqKHCrjCMeOVDDJAA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LmVJgxrxeClLpuyiOwXogRrexRSi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LmVJgxrxeClLpuyiOwXogRrexRSi;
						}
					}

					[DebuggerHidden]
					public fJfeNFTqfrHkDQvWBjqYDLXRxsZv(int P_0)
					{
						RirXSnDUCrarqWGZAXhfeKfHnQMl = P_0;
						dZXHZBpRsVhLqEYYBTLItKyhcROHA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rirXSnDUCrarqWGZAXhfeKfHnQMl = RirXSnDUCrarqWGZAXhfeKfHnQMl;
						if (rirXSnDUCrarqWGZAXhfeKfHnQMl == -3 || rirXSnDUCrarqWGZAXhfeKfHnQMl == 1)
						{
							try
							{
							}
							finally
							{
								stRXIuuUYffBosAeYgubCWIlKEawA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int rirXSnDUCrarqWGZAXhfeKfHnQMl = RirXSnDUCrarqWGZAXhfeKfHnQMl;
							PollingHelper pollingHelper = bbFejVNMvcdRgaLYLdaDXGOmbVVgb;
							switch (rirXSnDUCrarqWGZAXhfeKfHnQMl)
							{
							default:
								return false;
							case 0:
							{
								RirXSnDUCrarqWGZAXhfeKfHnQMl = -1;
								if (gghZpCHqBleddwRpNeGNaPpKsNGh < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(gghZpCHqBleddwRpNeGNaPpKsNGh);
								if (customController == null)
								{
									return false;
								}
								ArhzmniBThJHoqKHCrjCMeOVDDJAA = customController.PollForAllButtonsDown().GetEnumerator();
								RirXSnDUCrarqWGZAXhfeKfHnQMl = -3;
								break;
							}
							case 1:
								RirXSnDUCrarqWGZAXhfeKfHnQMl = -3;
								break;
							}
							if (ArhzmniBThJHoqKHCrjCMeOVDDJAA.MoveNext())
							{
								ControllerPollingInfo current = ArhzmniBThJHoqKHCrjCMeOVDDJAA.Current;
								ControllerPollingInfo lmVJgxrxeClLpuyiOwXogRrexRSi = new ControllerPollingInfo(current);
								lmVJgxrxeClLpuyiOwXogRrexRSi.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								LmVJgxrxeClLpuyiOwXogRrexRSi = lmVJgxrxeClLpuyiOwXogRrexRSi;
								RirXSnDUCrarqWGZAXhfeKfHnQMl = 1;
								return true;
							}
							stRXIuuUYffBosAeYgubCWIlKEawA();
							ArhzmniBThJHoqKHCrjCMeOVDDJAA = null;
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

					private void stRXIuuUYffBosAeYgubCWIlKEawA()
					{
						RirXSnDUCrarqWGZAXhfeKfHnQMl = -1;
						if (ArhzmniBThJHoqKHCrjCMeOVDDJAA != null)
						{
							ArhzmniBThJHoqKHCrjCMeOVDDJAA.Dispose();
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
						fJfeNFTqfrHkDQvWBjqYDLXRxsZv fJfeNFTqfrHkDQvWBjqYDLXRxsZv2;
						if (RirXSnDUCrarqWGZAXhfeKfHnQMl == -2 && dZXHZBpRsVhLqEYYBTLItKyhcROHA == Environment.CurrentManagedThreadId)
						{
							RirXSnDUCrarqWGZAXhfeKfHnQMl = 0;
							fJfeNFTqfrHkDQvWBjqYDLXRxsZv2 = this;
						}
						else
						{
							fJfeNFTqfrHkDQvWBjqYDLXRxsZv2 = new fJfeNFTqfrHkDQvWBjqYDLXRxsZv(0);
							fJfeNFTqfrHkDQvWBjqYDLXRxsZv2.bbFejVNMvcdRgaLYLdaDXGOmbVVgb = bbFejVNMvcdRgaLYLdaDXGOmbVVgb;
						}
						fJfeNFTqfrHkDQvWBjqYDLXRxsZv2.gghZpCHqBleddwRpNeGNaPpKsNGh = vhMZMEnVDUgQfieRtGnjgptHECQQA;
						return fJfeNFTqfrHkDQvWBjqYDLXRxsZv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class zsmksytheNueGQpblzWYibcYIhlj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YncZzMqLMseEDeCQUYrXHDuDNrnb;

					private ControllerPollingInfo yHrTvuuoYlxpfPfhHvUCtvXxgMAc;

					private int ITzurvZxCwlnPrelfjwWEUntCgbfb;

					private int XaYMAbOAiiqWgGTCLizykXfcjSYf;

					public int PgRqIdwiUtbLhdwRPusAPmnEuzgu;

					public PollingHelper hZWHcpodPvAzfJFIEauVlooLtUEn;

					private IEnumerator<ControllerPollingInfo> IatpmSmnYVuwNrvUTCfnnqBdFwiK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return yHrTvuuoYlxpfPfhHvUCtvXxgMAc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return yHrTvuuoYlxpfPfhHvUCtvXxgMAc;
						}
					}

					[DebuggerHidden]
					public zsmksytheNueGQpblzWYibcYIhlj(int P_0)
					{
						YncZzMqLMseEDeCQUYrXHDuDNrnb = P_0;
						ITzurvZxCwlnPrelfjwWEUntCgbfb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int yncZzMqLMseEDeCQUYrXHDuDNrnb = YncZzMqLMseEDeCQUYrXHDuDNrnb;
						if (yncZzMqLMseEDeCQUYrXHDuDNrnb == -3 || yncZzMqLMseEDeCQUYrXHDuDNrnb == 1)
						{
							try
							{
							}
							finally
							{
								RKdOZThCeQIgOtwqUvzSyUPflUuo();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int yncZzMqLMseEDeCQUYrXHDuDNrnb = YncZzMqLMseEDeCQUYrXHDuDNrnb;
							PollingHelper pollingHelper = hZWHcpodPvAzfJFIEauVlooLtUEn;
							switch (yncZzMqLMseEDeCQUYrXHDuDNrnb)
							{
							default:
								return false;
							case 0:
							{
								YncZzMqLMseEDeCQUYrXHDuDNrnb = -1;
								if (XaYMAbOAiiqWgGTCLizykXfcjSYf < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(XaYMAbOAiiqWgGTCLizykXfcjSYf);
								if (customController == null)
								{
									return false;
								}
								IatpmSmnYVuwNrvUTCfnnqBdFwiK = customController.PollForAllElements().GetEnumerator();
								YncZzMqLMseEDeCQUYrXHDuDNrnb = -3;
								break;
							}
							case 1:
								YncZzMqLMseEDeCQUYrXHDuDNrnb = -3;
								break;
							}
							if (IatpmSmnYVuwNrvUTCfnnqBdFwiK.MoveNext())
							{
								ControllerPollingInfo current = IatpmSmnYVuwNrvUTCfnnqBdFwiK.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								yHrTvuuoYlxpfPfhHvUCtvXxgMAc = controllerPollingInfo;
								YncZzMqLMseEDeCQUYrXHDuDNrnb = 1;
								return true;
							}
							RKdOZThCeQIgOtwqUvzSyUPflUuo();
							IatpmSmnYVuwNrvUTCfnnqBdFwiK = null;
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

					private void RKdOZThCeQIgOtwqUvzSyUPflUuo()
					{
						YncZzMqLMseEDeCQUYrXHDuDNrnb = -1;
						if (IatpmSmnYVuwNrvUTCfnnqBdFwiK != null)
						{
							IatpmSmnYVuwNrvUTCfnnqBdFwiK.Dispose();
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
						zsmksytheNueGQpblzWYibcYIhlj zsmksytheNueGQpblzWYibcYIhlj2;
						if (YncZzMqLMseEDeCQUYrXHDuDNrnb == -2 && ITzurvZxCwlnPrelfjwWEUntCgbfb == Environment.CurrentManagedThreadId)
						{
							YncZzMqLMseEDeCQUYrXHDuDNrnb = 0;
							zsmksytheNueGQpblzWYibcYIhlj2 = this;
						}
						else
						{
							zsmksytheNueGQpblzWYibcYIhlj2 = new zsmksytheNueGQpblzWYibcYIhlj(0);
							zsmksytheNueGQpblzWYibcYIhlj2.hZWHcpodPvAzfJFIEauVlooLtUEn = hZWHcpodPvAzfJFIEauVlooLtUEn;
						}
						zsmksytheNueGQpblzWYibcYIhlj2.XaYMAbOAiiqWgGTCLizykXfcjSYf = PgRqIdwiUtbLhdwRPusAPmnEuzgu;
						return zsmksytheNueGQpblzWYibcYIhlj2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class eOpeusTNKuDQyJbBFGNfgCjPIXSJA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int oHKiKGVjGbJligSTWcNfHmRMnplgA;

					private ControllerPollingInfo NLREdlUtxtbuGAyEfOOhkcdQCbFF;

					private int TRuDFPGfBaBfSPDtQSpsahYtdHIgb;

					private int ELuvEiMFtjizQQwUFZrKsxiKrBIb;

					public int cVzWhmAXAgsSydMgHFUqMpgmFubCA;

					public PollingHelper jnIcsEBRnJteTIOegOPFGyUjkytXA;

					private IEnumerator<ControllerPollingInfo> NUaKMtlwcGmdTVDAbggAAwIcSAVf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return NLREdlUtxtbuGAyEfOOhkcdQCbFF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NLREdlUtxtbuGAyEfOOhkcdQCbFF;
						}
					}

					[DebuggerHidden]
					public eOpeusTNKuDQyJbBFGNfgCjPIXSJA(int P_0)
					{
						oHKiKGVjGbJligSTWcNfHmRMnplgA = P_0;
						TRuDFPGfBaBfSPDtQSpsahYtdHIgb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = oHKiKGVjGbJligSTWcNfHmRMnplgA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								nxCfWFPlBPqHXEuZdxuDADOHdwrK();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = oHKiKGVjGbJligSTWcNfHmRMnplgA;
							PollingHelper pollingHelper = jnIcsEBRnJteTIOegOPFGyUjkytXA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								oHKiKGVjGbJligSTWcNfHmRMnplgA = -1;
								if (ELuvEiMFtjizQQwUFZrKsxiKrBIb < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(ELuvEiMFtjizQQwUFZrKsxiKrBIb);
								if (customController == null)
								{
									return false;
								}
								NUaKMtlwcGmdTVDAbggAAwIcSAVf = customController.PollForAllElementsDown().GetEnumerator();
								oHKiKGVjGbJligSTWcNfHmRMnplgA = -3;
								break;
							}
							case 1:
								oHKiKGVjGbJligSTWcNfHmRMnplgA = -3;
								break;
							}
							if (NUaKMtlwcGmdTVDAbggAAwIcSAVf.MoveNext())
							{
								ControllerPollingInfo current = NUaKMtlwcGmdTVDAbggAAwIcSAVf.Current;
								ControllerPollingInfo nLREdlUtxtbuGAyEfOOhkcdQCbFF = new ControllerPollingInfo(current);
								nLREdlUtxtbuGAyEfOOhkcdQCbFF.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								NLREdlUtxtbuGAyEfOOhkcdQCbFF = nLREdlUtxtbuGAyEfOOhkcdQCbFF;
								oHKiKGVjGbJligSTWcNfHmRMnplgA = 1;
								return true;
							}
							nxCfWFPlBPqHXEuZdxuDADOHdwrK();
							NUaKMtlwcGmdTVDAbggAAwIcSAVf = null;
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

					private void nxCfWFPlBPqHXEuZdxuDADOHdwrK()
					{
						oHKiKGVjGbJligSTWcNfHmRMnplgA = -1;
						if (NUaKMtlwcGmdTVDAbggAAwIcSAVf != null)
						{
							NUaKMtlwcGmdTVDAbggAAwIcSAVf.Dispose();
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
						eOpeusTNKuDQyJbBFGNfgCjPIXSJA eOpeusTNKuDQyJbBFGNfgCjPIXSJA2;
						if (oHKiKGVjGbJligSTWcNfHmRMnplgA == -2 && TRuDFPGfBaBfSPDtQSpsahYtdHIgb == Environment.CurrentManagedThreadId)
						{
							oHKiKGVjGbJligSTWcNfHmRMnplgA = 0;
							eOpeusTNKuDQyJbBFGNfgCjPIXSJA2 = this;
						}
						else
						{
							eOpeusTNKuDQyJbBFGNfgCjPIXSJA2 = new eOpeusTNKuDQyJbBFGNfgCjPIXSJA(0);
							eOpeusTNKuDQyJbBFGNfgCjPIXSJA2.jnIcsEBRnJteTIOegOPFGyUjkytXA = jnIcsEBRnJteTIOegOPFGyUjkytXA;
						}
						eOpeusTNKuDQyJbBFGNfgCjPIXSJA2.ELuvEiMFtjizQQwUFZrKsxiKrBIb = cVzWhmAXAgsSydMgHFUqMpgmFubCA;
						return eOpeusTNKuDQyJbBFGNfgCjPIXSJA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class UuAiominRescdhvkIrphaoVGXgpv : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int MmsUpWVnLwZqBsLrsuxoyUVtEtWd;

					private ControllerPollingInfo GbjruLzVtbagKImXnxhHCBBTevSi;

					private int DwTkdIvSjnKSOoSDBAvnDUDIbgwb;

					private int fORqMMGrzRIJlirxcUlPSXbTrIkT;

					public int sqkGQIIFxHCzvCzyaBTjZrzbBGgjb;

					public PollingHelper rfPkTswyEplWpOlYWGCqUZKEoxYr;

					private IEnumerator<ControllerPollingInfo> ReEocqFkLwecQdQSUptQZnMRpgdT;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GbjruLzVtbagKImXnxhHCBBTevSi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GbjruLzVtbagKImXnxhHCBBTevSi;
						}
					}

					[DebuggerHidden]
					public UuAiominRescdhvkIrphaoVGXgpv(int P_0)
					{
						MmsUpWVnLwZqBsLrsuxoyUVtEtWd = P_0;
						DwTkdIvSjnKSOoSDBAvnDUDIbgwb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int mmsUpWVnLwZqBsLrsuxoyUVtEtWd = MmsUpWVnLwZqBsLrsuxoyUVtEtWd;
						if (mmsUpWVnLwZqBsLrsuxoyUVtEtWd == -3 || mmsUpWVnLwZqBsLrsuxoyUVtEtWd == 1)
						{
							try
							{
							}
							finally
							{
								kScFHtBbYoERAYlkbqamSnvjPZoOA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int mmsUpWVnLwZqBsLrsuxoyUVtEtWd = MmsUpWVnLwZqBsLrsuxoyUVtEtWd;
							PollingHelper pollingHelper = rfPkTswyEplWpOlYWGCqUZKEoxYr;
							switch (mmsUpWVnLwZqBsLrsuxoyUVtEtWd)
							{
							default:
								return false;
							case 0:
							{
								MmsUpWVnLwZqBsLrsuxoyUVtEtWd = -1;
								if (fORqMMGrzRIJlirxcUlPSXbTrIkT < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(fORqMMGrzRIJlirxcUlPSXbTrIkT);
								if (joystick == null)
								{
									return false;
								}
								ReEocqFkLwecQdQSUptQZnMRpgdT = joystick.PollForAllAxes().GetEnumerator();
								MmsUpWVnLwZqBsLrsuxoyUVtEtWd = -3;
								break;
							}
							case 1:
								MmsUpWVnLwZqBsLrsuxoyUVtEtWd = -3;
								break;
							}
							if (ReEocqFkLwecQdQSUptQZnMRpgdT.MoveNext())
							{
								ControllerPollingInfo current = ReEocqFkLwecQdQSUptQZnMRpgdT.Current;
								ControllerPollingInfo gbjruLzVtbagKImXnxhHCBBTevSi = new ControllerPollingInfo(current);
								gbjruLzVtbagKImXnxhHCBBTevSi.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								GbjruLzVtbagKImXnxhHCBBTevSi = gbjruLzVtbagKImXnxhHCBBTevSi;
								MmsUpWVnLwZqBsLrsuxoyUVtEtWd = 1;
								return true;
							}
							kScFHtBbYoERAYlkbqamSnvjPZoOA();
							ReEocqFkLwecQdQSUptQZnMRpgdT = null;
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

					private void kScFHtBbYoERAYlkbqamSnvjPZoOA()
					{
						MmsUpWVnLwZqBsLrsuxoyUVtEtWd = -1;
						if (ReEocqFkLwecQdQSUptQZnMRpgdT != null)
						{
							ReEocqFkLwecQdQSUptQZnMRpgdT.Dispose();
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
						UuAiominRescdhvkIrphaoVGXgpv uuAiominRescdhvkIrphaoVGXgpv;
						if (MmsUpWVnLwZqBsLrsuxoyUVtEtWd == -2 && DwTkdIvSjnKSOoSDBAvnDUDIbgwb == Environment.CurrentManagedThreadId)
						{
							MmsUpWVnLwZqBsLrsuxoyUVtEtWd = 0;
							uuAiominRescdhvkIrphaoVGXgpv = this;
						}
						else
						{
							uuAiominRescdhvkIrphaoVGXgpv = new UuAiominRescdhvkIrphaoVGXgpv(0);
							uuAiominRescdhvkIrphaoVGXgpv.rfPkTswyEplWpOlYWGCqUZKEoxYr = rfPkTswyEplWpOlYWGCqUZKEoxYr;
						}
						uuAiominRescdhvkIrphaoVGXgpv.fORqMMGrzRIJlirxcUlPSXbTrIkT = sqkGQIIFxHCzvCzyaBTjZrzbBGgjb;
						return uuAiominRescdhvkIrphaoVGXgpv;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class TNMipyWfCndvmkADJQUrZMODdkuEA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ODHZAbhUiNuStJAnXEACkFVAoPqHb;

					private ControllerPollingInfo FbLlFpJQEeFALcCzyfjYsGitPBeS;

					private int ZluVoSdMIDcWXIgfqjoRLOERAMvo;

					private int wQGqHSzprUFcngyoLqCXGRrSDEyF;

					public int uzCXlIyqVXZgGrkPgbsSDgUzFyvU;

					public PollingHelper CYoEDcekvDgoatuehSCDPpssDPDy;

					private IEnumerator<ControllerPollingInfo> HdJDfztvYToPHPymZueKFagNKVkr;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return FbLlFpJQEeFALcCzyfjYsGitPBeS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FbLlFpJQEeFALcCzyfjYsGitPBeS;
						}
					}

					[DebuggerHidden]
					public TNMipyWfCndvmkADJQUrZMODdkuEA(int P_0)
					{
						ODHZAbhUiNuStJAnXEACkFVAoPqHb = P_0;
						ZluVoSdMIDcWXIgfqjoRLOERAMvo = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int oDHZAbhUiNuStJAnXEACkFVAoPqHb = ODHZAbhUiNuStJAnXEACkFVAoPqHb;
						if (oDHZAbhUiNuStJAnXEACkFVAoPqHb == -3 || oDHZAbhUiNuStJAnXEACkFVAoPqHb == 1)
						{
							try
							{
							}
							finally
							{
								VfGLxwuVINFmjnMMNNJSIAMoPQGy();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int oDHZAbhUiNuStJAnXEACkFVAoPqHb = ODHZAbhUiNuStJAnXEACkFVAoPqHb;
							PollingHelper cYoEDcekvDgoatuehSCDPpssDPDy = CYoEDcekvDgoatuehSCDPpssDPDy;
							switch (oDHZAbhUiNuStJAnXEACkFVAoPqHb)
							{
							default:
								return false;
							case 0:
							{
								ODHZAbhUiNuStJAnXEACkFVAoPqHb = -1;
								if (wQGqHSzprUFcngyoLqCXGRrSDEyF < 0)
								{
									return false;
								}
								Joystick joystick = cYoEDcekvDgoatuehSCDPpssDPDy.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(wQGqHSzprUFcngyoLqCXGRrSDEyF);
								if (joystick == null)
								{
									return false;
								}
								HdJDfztvYToPHPymZueKFagNKVkr = joystick.PollForAllButtons().GetEnumerator();
								ODHZAbhUiNuStJAnXEACkFVAoPqHb = -3;
								break;
							}
							case 1:
								ODHZAbhUiNuStJAnXEACkFVAoPqHb = -3;
								break;
							}
							if (HdJDfztvYToPHPymZueKFagNKVkr.MoveNext())
							{
								ControllerPollingInfo current = HdJDfztvYToPHPymZueKFagNKVkr.Current;
								ControllerPollingInfo fbLlFpJQEeFALcCzyfjYsGitPBeS = new ControllerPollingInfo(current);
								fbLlFpJQEeFALcCzyfjYsGitPBeS.playerId = cYoEDcekvDgoatuehSCDPpssDPDy.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								FbLlFpJQEeFALcCzyfjYsGitPBeS = fbLlFpJQEeFALcCzyfjYsGitPBeS;
								ODHZAbhUiNuStJAnXEACkFVAoPqHb = 1;
								return true;
							}
							VfGLxwuVINFmjnMMNNJSIAMoPQGy();
							HdJDfztvYToPHPymZueKFagNKVkr = null;
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

					private void VfGLxwuVINFmjnMMNNJSIAMoPQGy()
					{
						ODHZAbhUiNuStJAnXEACkFVAoPqHb = -1;
						if (HdJDfztvYToPHPymZueKFagNKVkr != null)
						{
							HdJDfztvYToPHPymZueKFagNKVkr.Dispose();
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
						TNMipyWfCndvmkADJQUrZMODdkuEA tNMipyWfCndvmkADJQUrZMODdkuEA;
						if (ODHZAbhUiNuStJAnXEACkFVAoPqHb == -2 && ZluVoSdMIDcWXIgfqjoRLOERAMvo == Environment.CurrentManagedThreadId)
						{
							ODHZAbhUiNuStJAnXEACkFVAoPqHb = 0;
							tNMipyWfCndvmkADJQUrZMODdkuEA = this;
						}
						else
						{
							tNMipyWfCndvmkADJQUrZMODdkuEA = new TNMipyWfCndvmkADJQUrZMODdkuEA(0);
							tNMipyWfCndvmkADJQUrZMODdkuEA.CYoEDcekvDgoatuehSCDPpssDPDy = CYoEDcekvDgoatuehSCDPpssDPDy;
						}
						tNMipyWfCndvmkADJQUrZMODdkuEA.wQGqHSzprUFcngyoLqCXGRrSDEyF = uzCXlIyqVXZgGrkPgbsSDgUzFyvU;
						return tNMipyWfCndvmkADJQUrZMODdkuEA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wOPWzvqxTtSsnXNnXDcHrVJiDIbM : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int lYxdNtAZiSegmVqhSyakMOdFOQNfA;

					private ControllerPollingInfo ZmJUOzffwhblXNCxSmbynwrgrePS;

					private int aQcEIEpvuWFPxuqdWQLYfgumBxNT;

					private int mrxUPLEtslEqJgrElyDvXnIFVJFf;

					public int AegLPvNJIpLNsLdWPlugzCPHIEtIA;

					public PollingHelper OsVivFBQFZkNKJdGWdhdySFqhAPEA;

					private IEnumerator<ControllerPollingInfo> YzgnJjdDJIKSrdHqtAnFRDktlaiL;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZmJUOzffwhblXNCxSmbynwrgrePS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZmJUOzffwhblXNCxSmbynwrgrePS;
						}
					}

					[DebuggerHidden]
					public wOPWzvqxTtSsnXNnXDcHrVJiDIbM(int P_0)
					{
						lYxdNtAZiSegmVqhSyakMOdFOQNfA = P_0;
						aQcEIEpvuWFPxuqdWQLYfgumBxNT = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = lYxdNtAZiSegmVqhSyakMOdFOQNfA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RLpAlTFLjxOnceasUqdUOQByvppJ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = lYxdNtAZiSegmVqhSyakMOdFOQNfA;
							PollingHelper osVivFBQFZkNKJdGWdhdySFqhAPEA = OsVivFBQFZkNKJdGWdhdySFqhAPEA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								lYxdNtAZiSegmVqhSyakMOdFOQNfA = -1;
								if (mrxUPLEtslEqJgrElyDvXnIFVJFf < 0)
								{
									return false;
								}
								Joystick joystick = osVivFBQFZkNKJdGWdhdySFqhAPEA.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(mrxUPLEtslEqJgrElyDvXnIFVJFf);
								if (joystick == null)
								{
									return false;
								}
								YzgnJjdDJIKSrdHqtAnFRDktlaiL = joystick.PollForAllButtonsDown().GetEnumerator();
								lYxdNtAZiSegmVqhSyakMOdFOQNfA = -3;
								break;
							}
							case 1:
								lYxdNtAZiSegmVqhSyakMOdFOQNfA = -3;
								break;
							}
							if (YzgnJjdDJIKSrdHqtAnFRDktlaiL.MoveNext())
							{
								ControllerPollingInfo current = YzgnJjdDJIKSrdHqtAnFRDktlaiL.Current;
								ControllerPollingInfo zmJUOzffwhblXNCxSmbynwrgrePS = new ControllerPollingInfo(current);
								zmJUOzffwhblXNCxSmbynwrgrePS.playerId = osVivFBQFZkNKJdGWdhdySFqhAPEA.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								ZmJUOzffwhblXNCxSmbynwrgrePS = zmJUOzffwhblXNCxSmbynwrgrePS;
								lYxdNtAZiSegmVqhSyakMOdFOQNfA = 1;
								return true;
							}
							RLpAlTFLjxOnceasUqdUOQByvppJ();
							YzgnJjdDJIKSrdHqtAnFRDktlaiL = null;
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

					private void RLpAlTFLjxOnceasUqdUOQByvppJ()
					{
						lYxdNtAZiSegmVqhSyakMOdFOQNfA = -1;
						if (YzgnJjdDJIKSrdHqtAnFRDktlaiL != null)
						{
							YzgnJjdDJIKSrdHqtAnFRDktlaiL.Dispose();
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
						wOPWzvqxTtSsnXNnXDcHrVJiDIbM wOPWzvqxTtSsnXNnXDcHrVJiDIbM2;
						if (lYxdNtAZiSegmVqhSyakMOdFOQNfA == -2 && aQcEIEpvuWFPxuqdWQLYfgumBxNT == Environment.CurrentManagedThreadId)
						{
							lYxdNtAZiSegmVqhSyakMOdFOQNfA = 0;
							wOPWzvqxTtSsnXNnXDcHrVJiDIbM2 = this;
						}
						else
						{
							wOPWzvqxTtSsnXNnXDcHrVJiDIbM2 = new wOPWzvqxTtSsnXNnXDcHrVJiDIbM(0);
							wOPWzvqxTtSsnXNnXDcHrVJiDIbM2.OsVivFBQFZkNKJdGWdhdySFqhAPEA = OsVivFBQFZkNKJdGWdhdySFqhAPEA;
						}
						wOPWzvqxTtSsnXNnXDcHrVJiDIbM2.mrxUPLEtslEqJgrElyDvXnIFVJFf = AegLPvNJIpLNsLdWPlugzCPHIEtIA;
						return wOPWzvqxTtSsnXNnXDcHrVJiDIbM2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class KkljTzMkDwlpsXJVkhQIcKRpfKr : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pQPIMBDkIfvcZHudsAAONOqQxBxl;

					private ControllerPollingInfo tbxgXQUcyrgJwjgoxtONQTOwxkXh;

					private int JyBAfZnvcmVOGKVVtGQYHiESYTDP;

					private int KRkJdVXOYMrqcdQmXTmCrthtPVxT;

					public int MDaYCQZEYAlvnwxLxoTcMZJWFYAL;

					public PollingHelper jOTsxTzQjlaNPwakliNOvqdFmPoo;

					private IEnumerator<ControllerPollingInfo> nKvdwIhKnxXqQVZckRuTrMcrYfOc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tbxgXQUcyrgJwjgoxtONQTOwxkXh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tbxgXQUcyrgJwjgoxtONQTOwxkXh;
						}
					}

					[DebuggerHidden]
					public KkljTzMkDwlpsXJVkhQIcKRpfKr(int P_0)
					{
						pQPIMBDkIfvcZHudsAAONOqQxBxl = P_0;
						JyBAfZnvcmVOGKVVtGQYHiESYTDP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pQPIMBDkIfvcZHudsAAONOqQxBxl;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								eUKtdBknCTcEoeLQDVRHDnHwRUueA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = pQPIMBDkIfvcZHudsAAONOqQxBxl;
							PollingHelper pollingHelper = jOTsxTzQjlaNPwakliNOvqdFmPoo;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								pQPIMBDkIfvcZHudsAAONOqQxBxl = -1;
								if (KRkJdVXOYMrqcdQmXTmCrthtPVxT < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(KRkJdVXOYMrqcdQmXTmCrthtPVxT);
								if (joystick == null)
								{
									return false;
								}
								nKvdwIhKnxXqQVZckRuTrMcrYfOc = joystick.PollForAllElements().GetEnumerator();
								pQPIMBDkIfvcZHudsAAONOqQxBxl = -3;
								break;
							}
							case 1:
								pQPIMBDkIfvcZHudsAAONOqQxBxl = -3;
								break;
							}
							if (nKvdwIhKnxXqQVZckRuTrMcrYfOc.MoveNext())
							{
								ControllerPollingInfo current = nKvdwIhKnxXqQVZckRuTrMcrYfOc.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								tbxgXQUcyrgJwjgoxtONQTOwxkXh = controllerPollingInfo;
								pQPIMBDkIfvcZHudsAAONOqQxBxl = 1;
								return true;
							}
							eUKtdBknCTcEoeLQDVRHDnHwRUueA();
							nKvdwIhKnxXqQVZckRuTrMcrYfOc = null;
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

					private void eUKtdBknCTcEoeLQDVRHDnHwRUueA()
					{
						pQPIMBDkIfvcZHudsAAONOqQxBxl = -1;
						if (nKvdwIhKnxXqQVZckRuTrMcrYfOc != null)
						{
							nKvdwIhKnxXqQVZckRuTrMcrYfOc.Dispose();
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
						KkljTzMkDwlpsXJVkhQIcKRpfKr kkljTzMkDwlpsXJVkhQIcKRpfKr;
						if (pQPIMBDkIfvcZHudsAAONOqQxBxl == -2 && JyBAfZnvcmVOGKVVtGQYHiESYTDP == Environment.CurrentManagedThreadId)
						{
							pQPIMBDkIfvcZHudsAAONOqQxBxl = 0;
							kkljTzMkDwlpsXJVkhQIcKRpfKr = this;
						}
						else
						{
							kkljTzMkDwlpsXJVkhQIcKRpfKr = new KkljTzMkDwlpsXJVkhQIcKRpfKr(0);
							kkljTzMkDwlpsXJVkhQIcKRpfKr.jOTsxTzQjlaNPwakliNOvqdFmPoo = jOTsxTzQjlaNPwakliNOvqdFmPoo;
						}
						kkljTzMkDwlpsXJVkhQIcKRpfKr.KRkJdVXOYMrqcdQmXTmCrthtPVxT = MDaYCQZEYAlvnwxLxoTcMZJWFYAL;
						return kkljTzMkDwlpsXJVkhQIcKRpfKr;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RgewBOCaoJDSutbmNyVQdpAGkAmG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int cMDFDPbFzhcgGRqGzzhLaKgmkSPMA;

					private ControllerPollingInfo obwiXfiOghAmTIzMhPGuJFbhmqkRc;

					private int eFUHqRhNkMNihELdMeEMCGZgePWYA;

					private int mGpgIOiUuIWgLFiORbSNStviPbHqA;

					public int pgutQuOSKwvTJphksDcvgqlhmyrl;

					public PollingHelper VTCocJbjakPCIuvfDSVcfLJIXqzv;

					private IEnumerator<ControllerPollingInfo> iFFFSSzorHvmeXXESQKcMKpwZNRe;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return obwiXfiOghAmTIzMhPGuJFbhmqkRc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return obwiXfiOghAmTIzMhPGuJFbhmqkRc;
						}
					}

					[DebuggerHidden]
					public RgewBOCaoJDSutbmNyVQdpAGkAmG(int P_0)
					{
						cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = P_0;
						eFUHqRhNkMNihELdMeEMCGZgePWYA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cMDFDPbFzhcgGRqGzzhLaKgmkSPMA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RDxGzsHpzUqhDahNtXOGCTwBrJPA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = cMDFDPbFzhcgGRqGzzhLaKgmkSPMA;
							PollingHelper vTCocJbjakPCIuvfDSVcfLJIXqzv = VTCocJbjakPCIuvfDSVcfLJIXqzv;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = -1;
								if (mGpgIOiUuIWgLFiORbSNStviPbHqA < 0)
								{
									return false;
								}
								Joystick joystick = vTCocJbjakPCIuvfDSVcfLJIXqzv.ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(mGpgIOiUuIWgLFiORbSNStviPbHqA);
								if (joystick == null)
								{
									return false;
								}
								iFFFSSzorHvmeXXESQKcMKpwZNRe = joystick.PollForAllElementsDown().GetEnumerator();
								cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = -3;
								break;
							}
							case 1:
								cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = -3;
								break;
							}
							if (iFFFSSzorHvmeXXESQKcMKpwZNRe.MoveNext())
							{
								ControllerPollingInfo current = iFFFSSzorHvmeXXESQKcMKpwZNRe.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = vTCocJbjakPCIuvfDSVcfLJIXqzv.DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
								obwiXfiOghAmTIzMhPGuJFbhmqkRc = controllerPollingInfo;
								cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = 1;
								return true;
							}
							RDxGzsHpzUqhDahNtXOGCTwBrJPA();
							iFFFSSzorHvmeXXESQKcMKpwZNRe = null;
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

					private void RDxGzsHpzUqhDahNtXOGCTwBrJPA()
					{
						cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = -1;
						if (iFFFSSzorHvmeXXESQKcMKpwZNRe != null)
						{
							iFFFSSzorHvmeXXESQKcMKpwZNRe.Dispose();
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
						RgewBOCaoJDSutbmNyVQdpAGkAmG rgewBOCaoJDSutbmNyVQdpAGkAmG;
						if (cMDFDPbFzhcgGRqGzzhLaKgmkSPMA == -2 && eFUHqRhNkMNihELdMeEMCGZgePWYA == Environment.CurrentManagedThreadId)
						{
							cMDFDPbFzhcgGRqGzzhLaKgmkSPMA = 0;
							rgewBOCaoJDSutbmNyVQdpAGkAmG = this;
						}
						else
						{
							rgewBOCaoJDSutbmNyVQdpAGkAmG = new RgewBOCaoJDSutbmNyVQdpAGkAmG(0);
							rgewBOCaoJDSutbmNyVQdpAGkAmG.VTCocJbjakPCIuvfDSVcfLJIXqzv = VTCocJbjakPCIuvfDSVcfLJIXqzv;
						}
						rgewBOCaoJDSutbmNyVQdpAGkAmG.mGpgIOiUuIWgLFiORbSNStviPbHqA = pgutQuOSKwvTJphksDcvgqlhmyrl;
						return rgewBOCaoJDSutbmNyVQdpAGkAmG;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player DflLCitpSbkullboBbVzQaMlsgrT;

				private readonly ControllerHelper ROvEHkhIeyZxExtvMLRkIxBpLlft;

				private readonly int ELbTCnJfzVsonXdFjpozQGSaIyPg;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					ELbTCnJfzVsonXdFjpozQGSaIyPg = ReInput.id;
					DflLCitpSbkullboBbVzQaMlsgrT = P_0;
					ROvEHkhIeyZxExtvMLRkIxBpLlft = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ZhmgIzaowjZQncJEZAbJYhbtYdyK(), 
						ControllerType.Joystick => dCZUCbFolvJrVYnCxEiukXIluXRR(controllerId), 
						ControllerType.Mouse => tykSUiBIykbDNCafzhxifTpDkSqpA(), 
						ControllerType.Custom => HyOuqfVgxBmrPDOCkJNvfrLJqPay(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => josgSEeizTEaKTTuyjCeyrNicSaeb(), 
						ControllerType.Joystick => nJqDdGfQPcMiHTOjTfqyJgupKbrWA(controllerId), 
						ControllerType.Mouse => QSfqIWJIDVJZwuuldcldjlKHDUfE(), 
						ControllerType.Custom => FtTvFkPBtfDwqPqBSKLoisrnIrED(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ZhmgIzaowjZQncJEZAbJYhbtYdyK(), 
						ControllerType.Joystick => ziyriWwrhGOnJfEtEfFHweoxdxtfA(controllerId), 
						ControllerType.Mouse => UJzzDkTWekupUEahfTFBJUqJHcNS(), 
						ControllerType.Custom => pVJsmauEYsICGXZazrQaOkTVvUcY(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => josgSEeizTEaKTTuyjCeyrNicSaeb(), 
						ControllerType.Joystick => nEQnXtQCtJgfYbssCnbPQRzlulTe(controllerId), 
						ControllerType.Mouse => DTctDvweYjrnmaXXCSFNDKGTFLAIA(), 
						ControllerType.Custom => siODUbGFelswBwfrscXGWrpDdyuE(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf(), 
						ControllerType.Joystick => ZCvXScEhcDTRjOYJkTmVxGxRMpnQ(controllerId), 
						ControllerType.Mouse => HnsTwKVdpUqKDGfwFfXIxHDzyoPd(), 
						ControllerType.Custom => IYVLPhJaJLHiphJpuOkeXdUCCZrtA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GPGUSmoHvAaXEdOCpguXoqsjiWhSA(), 
						ControllerType.Joystick => udBIkvDsEyxKxnpjZjUdGVXkDSQE(controllerId), 
						ControllerType.Mouse => RbjODPcOxkDjXJdPeRhcSuEKGVNQ(), 
						ControllerType.Custom => JkCiBWENdONliFQQKxKKscGjfGCt(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => lYPmkunxFAdIUTTJrnejVLAyjlnaA(), 
						ControllerType.Joystick => STDQCECCsPehJeAQtpJyRJDTKXN(controllerId), 
						ControllerType.Mouse => VpzptnyofDNaFycYsxtByrepwOeQ(), 
						ControllerType.Custom => NBarVWujZggHfPEssNsmRAxMCUOF(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GPGUSmoHvAaXEdOCpguXoqsjiWhSA(), 
						ControllerType.Joystick => RUUEtiEWfmFqjEHPoROLpugdRcjhA(controllerId), 
						ControllerType.Mouse => WtbGxnZMeQziiYfMzphUxvuFQRHe(), 
						ControllerType.Custom => EKvNIWgpmTiekCUTSDYDTDgFvFaaA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => lYPmkunxFAdIUTTJrnejVLAyjlnaA(), 
						ControllerType.Joystick => cAkANJklonHJJtMTIyCQSblVAhzCA(controllerId), 
						ControllerType.Mouse => hNHszEmswLTlwNIUGOglpnIHfaaGA(), 
						ControllerType.Custom => FVUzULFiMyHuDHWEdSguuQakNgwVA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => AhkPgqAqgyddbWpxddzqcwKblKRT(controllerId), 
						ControllerType.Mouse => irTXCNzEeTgiOimqHNRDdBNEfZAjB(), 
						ControllerType.Custom => lwEjWgTWLvRsBHqImiXlIPbeqcJj(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ZhmgIzaowjZQncJEZAbJYhbtYdyK(), 
						ControllerType.Joystick => jkbaxDJCEzlePbPaxtAsrWTStXeL(), 
						ControllerType.Mouse => tykSUiBIykbDNCafzhxifTpDkSqpA(), 
						ControllerType.Custom => JbyyVHOrbFvcxDUJRKLxhwRoBtAB(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ZhmgIzaowjZQncJEZAbJYhbtYdyK(), 
						ControllerType.Joystick => rECtFBSuuogvDeTOkOOVCalaTKte(), 
						ControllerType.Mouse => UJzzDkTWekupUEahfTFBJUqJHcNS(), 
						ControllerType.Custom => eymXHpVcmiYBcNZcqLmlhTiIIKUv(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => josgSEeizTEaKTTuyjCeyrNicSaeb(), 
						ControllerType.Joystick => ErEFHOCfbmZTiYFrYhobGcQpyZoc(), 
						ControllerType.Mouse => DTctDvweYjrnmaXXCSFNDKGTFLAIA(), 
						ControllerType.Custom => DfWfnnAykgbHBVFiAjzRurqHJYhXA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf(), 
						ControllerType.Joystick => UdVOQssMlZkfyypfssoMMPhEjENz(), 
						ControllerType.Mouse => HnsTwKVdpUqKDGfwFfXIxHDzyoPd(), 
						ControllerType.Custom => SFOSXABCNTfDwjXdjIBdPnFJJRlS(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GPGUSmoHvAaXEdOCpguXoqsjiWhSA(), 
						ControllerType.Joystick => NYgFBftxjqtlIJMCdHwUccftcrxhA(), 
						ControllerType.Mouse => RbjODPcOxkDjXJdPeRhcSuEKGVNQ(), 
						ControllerType.Custom => RqLKbqXkEjgqrhTfAvMqcNyVyFljA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => lYPmkunxFAdIUTTJrnejVLAyjlnaA(), 
						ControllerType.Joystick => tBYHvIFRkhCagkStKitnKbqQWejf(), 
						ControllerType.Mouse => VpzptnyofDNaFycYsxtByrepwOeQ(), 
						ControllerType.Custom => PYwKERqbKMHnXPcsLZXpDGmOAtDK(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GPGUSmoHvAaXEdOCpguXoqsjiWhSA(), 
						ControllerType.Joystick => TsRAxEIkHiFeoQfqQJSVkDvbRiPD(), 
						ControllerType.Mouse => WtbGxnZMeQziiYfMzphUxvuFQRHe(), 
						ControllerType.Custom => yzCrxeLJSqDpCaWuZjVjrzjnNTzf(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => lYPmkunxFAdIUTTJrnejVLAyjlnaA(), 
						ControllerType.Joystick => zxEcmRKQodXLPXgOpQxmZEqxHONh(), 
						ControllerType.Mouse => hNHszEmswLTlwNIUGOglpnIHfaaGA(), 
						ControllerType.Custom => ZjkfOpnAKkxPCqjRpoYdWOQrlAtL(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != ELbTCnJfzVsonXdFjpozQGSaIyPg)
					{
						ReInput.CheckInitialized(ELbTCnJfzVsonXdFjpozQGSaIyPg);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => uPlQDXvYKzPBftZowCfXCBZCUonS(), 
						ControllerType.Mouse => irTXCNzEeTgiOimqHNRDdBNEfZAjB(), 
						ControllerType.Custom => BTPVsrESiSSraMpkjdkPxbhpQSrN(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo dCZUCbFolvJrVYnCxEiukXIluXRR(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					Joystick joystick = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo nJqDdGfQPcMiHTOjTfqyJgupKbrWA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					Joystick joystick = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo ziyriWwrhGOnJfEtEfFHweoxdxtfA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					Joystick joystick = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo nEQnXtQCtJgfYbssCnbPQRzlulTe(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					Joystick joystick = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo ZCvXScEhcDTRjOYJkTmVxGxRMpnQ(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					Joystick joystick = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				[IteratorStateMachine(typeof(KkljTzMkDwlpsXJVkhQIcKRpfKr))]
				private IEnumerable<ControllerPollingInfo> udBIkvDsEyxKxnpjZjUdGVXkDSQE(int P_0)
				{
					return new KkljTzMkDwlpsXJVkhQIcKRpfKr(-2)
					{
						jOTsxTzQjlaNPwakliNOvqdFmPoo = this,
						MDaYCQZEYAlvnwxLxoTcMZJWFYAL = P_0
					};
				}

				[IteratorStateMachine(typeof(RgewBOCaoJDSutbmNyVQdpAGkAmG))]
				private IEnumerable<ControllerPollingInfo> STDQCECCsPehJeAQtpJyRJDTKXN(int P_0)
				{
					return new RgewBOCaoJDSutbmNyVQdpAGkAmG(-2)
					{
						VTCocJbjakPCIuvfDSVcfLJIXqzv = this,
						pgutQuOSKwvTJphksDcvgqlhmyrl = P_0
					};
				}

				[IteratorStateMachine(typeof(TNMipyWfCndvmkADJQUrZMODdkuEA))]
				private IEnumerable<ControllerPollingInfo> RUUEtiEWfmFqjEHPoROLpugdRcjhA(int P_0)
				{
					return new TNMipyWfCndvmkADJQUrZMODdkuEA(-2)
					{
						CYoEDcekvDgoatuehSCDPpssDPDy = this,
						uzCXlIyqVXZgGrkPgbsSDgUzFyvU = P_0
					};
				}

				[IteratorStateMachine(typeof(wOPWzvqxTtSsnXNnXDcHrVJiDIbM))]
				private IEnumerable<ControllerPollingInfo> cAkANJklonHJJtMTIyCQSblVAhzCA(int P_0)
				{
					return new wOPWzvqxTtSsnXNnXDcHrVJiDIbM(-2)
					{
						OsVivFBQFZkNKJdGWdhdySFqhAPEA = this,
						AegLPvNJIpLNsLdWPlugzCPHIEtIA = P_0
					};
				}

				[IteratorStateMachine(typeof(UuAiominRescdhvkIrphaoVGXgpv))]
				private IEnumerable<ControllerPollingInfo> AhkPgqAqgyddbWpxddzqcwKblKRT(int P_0)
				{
					return new UuAiominRescdhvkIrphaoVGXgpv(-2)
					{
						rfPkTswyEplWpOlYWGCqUZKEoxYr = this,
						sqkGQIIFxHCzvCzyaBTjZrzbBGgjb = P_0
					};
				}

				private ControllerPollingInfo jkbaxDJCEzlePbPaxtAsrWTStXeL()
				{
					IList<Joystick> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo SfjZQqFdRnqhbanTedznzZgrqiGD()
				{
					IList<Joystick> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo rECtFBSuuogvDeTOkOOVCalaTKte()
				{
					IList<Joystick> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo ErEFHOCfbmZTiYFrYhobGcQpyZoc()
				{
					IList<Joystick> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo UdVOQssMlZkfyypfssoMMPhEjENz()
				{
					IList<Joystick> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.IdXntCWLqmcpKWdMbubqFFsVDjNx.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				[IteratorStateMachine(typeof(dgsftAeApGGzXmZJEARBcVnYTjDY))]
				private IEnumerable<ControllerPollingInfo> NYgFBftxjqtlIJMCdHwUccftcrxhA()
				{
					return new dgsftAeApGGzXmZJEARBcVnYTjDY(-2)
					{
						jtYHnKocWpDJoSyriaAmMppOQSjL = this
					};
				}

				[IteratorStateMachine(typeof(LGIuzunrEfyOUHiItdOIgFqnIUTp))]
				private IEnumerable<ControllerPollingInfo> tBYHvIFRkhCagkStKitnKbqQWejf()
				{
					return new LGIuzunrEfyOUHiItdOIgFqnIUTp(-2)
					{
						LmmpBxdAPiAhquNicTUxkyytJOaG = this
					};
				}

				[IteratorStateMachine(typeof(wHhVRWPHaYXVixjZFVfeNGXFGfrjA))]
				private IEnumerable<ControllerPollingInfo> TsRAxEIkHiFeoQfqQJSVkDvbRiPD()
				{
					return new wHhVRWPHaYXVixjZFVfeNGXFGfrjA(-2)
					{
						BZgzzuOfLteDHMogEMYdLMxbOEQH = this
					};
				}

				[IteratorStateMachine(typeof(NXtHVKYgTHpJXBUEgujDXSBjvayV))]
				private IEnumerable<ControllerPollingInfo> zxEcmRKQodXLPXgOpQxmZEqxHONh()
				{
					return new NXtHVKYgTHpJXBUEgujDXSBjvayV(-2)
					{
						BAsihFELTSBNsnYqnZcJcdARqaVr = this
					};
				}

				[IteratorStateMachine(typeof(WEPLGspqurExCzDvRQTWNUmMFwGM))]
				private IEnumerable<ControllerPollingInfo> uPlQDXvYKzPBftZowCfXCBZCUonS()
				{
					return new WEPLGspqurExCzDvRQTWNUmMFwGM(-2)
					{
						jpIkJewgCsmzvYecBEuaJHnfAGnr = this
					};
				}

				private ControllerPollingInfo ZhmgIzaowjZQncJEZAbJYhbtYdyK()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.yZXyKtusfpuhWKpfOGivkRfZYcjW)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo josgSEeizTEaKTTuyjCeyrNicSaeb()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.yZXyKtusfpuhWKpfOGivkRfZYcjW)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> GPGUSmoHvAaXEdOCpguXoqsjiWhSA()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.yZXyKtusfpuhWKpfOGivkRfZYcjW)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> lYPmkunxFAdIUTTJrnejVLAyjlnaA()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.yZXyKtusfpuhWKpfOGivkRfZYcjW)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo tykSUiBIykbDNCafzhxifTpDkSqpA()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo QSfqIWJIDVJZwuuldcldjlKHDUfE()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo UJzzDkTWekupUEahfTFBJUqJHcNS()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo DTctDvweYjrnmaXXCSFNDKGTFLAIA()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo HnsTwKVdpUqKDGfwFfXIxHDzyoPd()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> RbjODPcOxkDjXJdPeRhcSuEKGVNQ()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> VpzptnyofDNaFycYsxtByrepwOeQ()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> WtbGxnZMeQziiYfMzphUxvuFQRHe()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> hNHszEmswLTlwNIUGOglpnIHfaaGA()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> irTXCNzEeTgiOimqHNRDdBNEfZAjB()
				{
					if (!ROvEHkhIeyZxExtvMLRkIxBpLlft.AyylMzYuhLVMwgAkkqmLtJeSZafC)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ROvEHkhIeyZxExtvMLRkIxBpLlft.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo HyOuqfVgxBmrPDOCkJNvfrLJqPay(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					CustomController customController = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo FtTvFkPBtfDwqPqBSKLoisrnIrED(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					CustomController customController = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo pVJsmauEYsICGXZazrQaOkTVvUcY(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					CustomController customController = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo siODUbGFelswBwfrscXGWrpDdyuE(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					CustomController customController = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				private ControllerPollingInfo IYVLPhJaJLHiphJpuOkeXdUCCZrtA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					CustomController customController = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.vHZEYGWPbXdkITvqEqYLxDnueIxY(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
					}
					return result;
				}

				[IteratorStateMachine(typeof(zsmksytheNueGQpblzWYibcYIhlj))]
				private IEnumerable<ControllerPollingInfo> JkCiBWENdONliFQQKxKKscGjfGCt(int P_0)
				{
					return new zsmksytheNueGQpblzWYibcYIhlj(-2)
					{
						hZWHcpodPvAzfJFIEauVlooLtUEn = this,
						PgRqIdwiUtbLhdwRPusAPmnEuzgu = P_0
					};
				}

				[IteratorStateMachine(typeof(eOpeusTNKuDQyJbBFGNfgCjPIXSJA))]
				private IEnumerable<ControllerPollingInfo> NBarVWujZggHfPEssNsmRAxMCUOF(int P_0)
				{
					return new eOpeusTNKuDQyJbBFGNfgCjPIXSJA(-2)
					{
						jnIcsEBRnJteTIOegOPFGyUjkytXA = this,
						cVzWhmAXAgsSydMgHFUqMpgmFubCA = P_0
					};
				}

				[IteratorStateMachine(typeof(OSYbpccjmNnDamxAcKyMRlUMFNiB))]
				private IEnumerable<ControllerPollingInfo> EKvNIWgpmTiekCUTSDYDTDgFvFaaA(int P_0)
				{
					return new OSYbpccjmNnDamxAcKyMRlUMFNiB(-2)
					{
						ajwVnDbNixqmVYsjNnONesUpZAsD = this,
						kYrtGQxBeyjCwGjjhcWCoQwtJkIl = P_0
					};
				}

				[IteratorStateMachine(typeof(fJfeNFTqfrHkDQvWBjqYDLXRxsZv))]
				private IEnumerable<ControllerPollingInfo> FVUzULFiMyHuDHWEdSguuQakNgwVA(int P_0)
				{
					return new fJfeNFTqfrHkDQvWBjqYDLXRxsZv(-2)
					{
						bbFejVNMvcdRgaLYLdaDXGOmbVVgb = this,
						vhMZMEnVDUgQfieRtGnjgptHECQQA = P_0
					};
				}

				[IteratorStateMachine(typeof(sCWgAolYwBMFjyMhLRNFlGYBWsPv))]
				private IEnumerable<ControllerPollingInfo> lwEjWgTWLvRsBHqImiXlIPbeqcJj(int P_0)
				{
					return new sCWgAolYwBMFjyMhLRNFlGYBWsPv(-2)
					{
						KczroUjmFVerQZOalvYlrJCzexJr = this,
						WDOMmtdVtfmAqthfZfaNJXsPNYl = P_0
					};
				}

				private ControllerPollingInfo JbyyVHOrbFvcxDUJRKLxhwRoBtAB()
				{
					IList<CustomController> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo pwDPttcNHatCkErbmkCdkwljrDtC()
				{
					IList<CustomController> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo eymXHpVcmiYBcNZcqLmlhTiIIKUv()
				{
					IList<CustomController> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo DfWfnnAykgbHBVFiAjzRurqHJYhXA()
				{
					IList<CustomController> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo SFOSXABCNTfDwjXdjIBdPnFJJRlS()
				{
					IList<CustomController> list = ROvEHkhIeyZxExtvMLRkIxBpLlft.jQagOUghReThwXIwYFFvuoKdhwOj.ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = DflLCitpSbkullboBbVzQaMlsgrT.bSdaAPhhDIswtzqbUxjtIHqKNnBS;
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				[IteratorStateMachine(typeof(FwXAFhIihiHZlsVsnnFgiBOlvdKY))]
				private IEnumerable<ControllerPollingInfo> RqLKbqXkEjgqrhTfAvMqcNyVyFljA()
				{
					return new FwXAFhIihiHZlsVsnnFgiBOlvdKY(-2)
					{
						jSDOKsxjBpHbUGePGsKuTqerIKNUA = this
					};
				}

				[IteratorStateMachine(typeof(SyxgghjPKwOsGgznEfhCksvwzuvkB))]
				private IEnumerable<ControllerPollingInfo> PYwKERqbKMHnXPcsLZXpDGmOAtDK()
				{
					return new SyxgghjPKwOsGgznEfhCksvwzuvkB(-2)
					{
						nwgDlQaJhlHKKEaIJYhqROtZkBXXA = this
					};
				}

				[IteratorStateMachine(typeof(hsBHulPvyeAdVoEwDctLGtXUzLuRA))]
				private IEnumerable<ControllerPollingInfo> yzCrxeLJSqDpCaWuZjVjrzjnNTzf()
				{
					return new hsBHulPvyeAdVoEwDctLGtXUzLuRA(-2)
					{
						rHqypVvKQgzowiUzXsjQmkPhJXAP = this
					};
				}

				[IteratorStateMachine(typeof(sPhCwZeJItfluCNFMIYjiVhLKpxP))]
				private IEnumerable<ControllerPollingInfo> ZjkfOpnAKkxPCqjRpoYdWOQrlAtL()
				{
					return new sPhCwZeJItfluCNFMIYjiVhLKpxP(-2)
					{
						aSzvJigLurHSdNkzenBGgLjoaKOcA = this
					};
				}

				[IteratorStateMachine(typeof(XtwlpoQpsUTmpYjNASnFebkLHkifA))]
				private IEnumerable<ControllerPollingInfo> BTPVsrESiSSraMpkjdkPxbhpQSrN()
				{
					return new XtwlpoQpsUTmpYjNASnFebkLHkifA(-2)
					{
						nlZlkrOaoNCSnduEYrzzGKkNsrjJ = this
					};
				}
			}

			[Serializable]
			private sealed class rCdIpSpjVcXSnGkOXAasCFwXhWcp
			{
				public static readonly rCdIpSpjVcXSnGkOXAasCFwXhWcp _003C_003E9 = new rCdIpSpjVcXSnGkOXAasCFwXhWcp();

				public static Action<Exception> _003C_003E9__23_0;

				public static Action<Exception> _003C_003E9__23_1;

				internal void rChwkLuOgykPDzGjvVSPqqIGqzrB(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void fxmMDQUUpFhWJmTjqpzIPrFlVbQO(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class jZiASQHAZInlhESGAkOVKAAvFbnGB : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
			{
				private int eKHFoEuaApQScSwMsFSLWkqlztgL;

				private Controller stUXORouDfTKdZVdqKwQwNCCqtyn;

				private int RGdqGdmCnRawoCcjYByenrFhLAJaA;

				public ControllerHelper CXGbLBSqkbCfFAQeMcUnckNvchad;

				private int BlOVSyEDxMNNManDnTtJgFMvsboB;

				private IList<Joystick> FdKMmWFIiXhSkbVypfJlilVJeAvy;

				private int MngdxGmYEoArrVvfBJZeUTFPYcWb;

				private IList<CustomController> WTLZRjBvkmZCrNWJNmTOLSEqpNhe;

				private int GVeUPMiTXXuBRZmDxAxyKKlnfWed;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return stUXORouDfTKdZVdqKwQwNCCqtyn;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return stUXORouDfTKdZVdqKwQwNCCqtyn;
					}
				}

				[DebuggerHidden]
				public jZiASQHAZInlhESGAkOVKAAvFbnGB(int P_0)
				{
					eKHFoEuaApQScSwMsFSLWkqlztgL = P_0;
					RGdqGdmCnRawoCcjYByenrFhLAJaA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = eKHFoEuaApQScSwMsFSLWkqlztgL;
					ControllerHelper cXGbLBSqkbCfFAQeMcUnckNvchad = CXGbLBSqkbCfFAQeMcUnckNvchad;
					switch (num)
					{
					default:
						return false;
					case 0:
						eKHFoEuaApQScSwMsFSLWkqlztgL = -1;
						if (ReInput._id != cXGbLBSqkbCfFAQeMcUnckNvchad.RULaWCpoqxXrOllctyoBfIHiSgsT)
						{
							ReInput.CheckInitialized(cXGbLBSqkbCfFAQeMcUnckNvchad.RULaWCpoqxXrOllctyoBfIHiSgsT);
							return false;
						}
						if (cXGbLBSqkbCfFAQeMcUnckNvchad.AyylMzYuhLVMwgAkkqmLtJeSZafC)
						{
							stUXORouDfTKdZVdqKwQwNCCqtyn = cXGbLBSqkbCfFAQeMcUnckNvchad.Mouse;
							eKHFoEuaApQScSwMsFSLWkqlztgL = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						eKHFoEuaApQScSwMsFSLWkqlztgL = -1;
						goto IL_0070;
					case 2:
						eKHFoEuaApQScSwMsFSLWkqlztgL = -1;
						goto IL_0094;
					case 3:
						eKHFoEuaApQScSwMsFSLWkqlztgL = -1;
						GVeUPMiTXXuBRZmDxAxyKKlnfWed++;
						goto IL_00ec;
					case 4:
						{
							eKHFoEuaApQScSwMsFSLWkqlztgL = -1;
							GVeUPMiTXXuBRZmDxAxyKKlnfWed++;
							break;
						}
						IL_0094:
						BlOVSyEDxMNNManDnTtJgFMvsboB = cXGbLBSqkbCfFAQeMcUnckNvchad.joystickCount;
						FdKMmWFIiXhSkbVypfJlilVJeAvy = cXGbLBSqkbCfFAQeMcUnckNvchad.Joysticks;
						GVeUPMiTXXuBRZmDxAxyKKlnfWed = 0;
						goto IL_00ec;
						IL_00ec:
						if (GVeUPMiTXXuBRZmDxAxyKKlnfWed < BlOVSyEDxMNNManDnTtJgFMvsboB)
						{
							stUXORouDfTKdZVdqKwQwNCCqtyn = FdKMmWFIiXhSkbVypfJlilVJeAvy[GVeUPMiTXXuBRZmDxAxyKKlnfWed];
							eKHFoEuaApQScSwMsFSLWkqlztgL = 3;
							return true;
						}
						MngdxGmYEoArrVvfBJZeUTFPYcWb = cXGbLBSqkbCfFAQeMcUnckNvchad.customControllerCount;
						WTLZRjBvkmZCrNWJNmTOLSEqpNhe = cXGbLBSqkbCfFAQeMcUnckNvchad.CustomControllers;
						GVeUPMiTXXuBRZmDxAxyKKlnfWed = 0;
						break;
						IL_0070:
						if (cXGbLBSqkbCfFAQeMcUnckNvchad.yZXyKtusfpuhWKpfOGivkRfZYcjW)
						{
							stUXORouDfTKdZVdqKwQwNCCqtyn = cXGbLBSqkbCfFAQeMcUnckNvchad.Keyboard;
							eKHFoEuaApQScSwMsFSLWkqlztgL = 2;
							return true;
						}
						goto IL_0094;
					}
					if (GVeUPMiTXXuBRZmDxAxyKKlnfWed < MngdxGmYEoArrVvfBJZeUTFPYcWb)
					{
						stUXORouDfTKdZVdqKwQwNCCqtyn = WTLZRjBvkmZCrNWJNmTOLSEqpNhe[GVeUPMiTXXuBRZmDxAxyKKlnfWed];
						eKHFoEuaApQScSwMsFSLWkqlztgL = 4;
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
					jZiASQHAZInlhESGAkOVKAAvFbnGB jZiASQHAZInlhESGAkOVKAAvFbnGB2;
					if (eKHFoEuaApQScSwMsFSLWkqlztgL == -2 && RGdqGdmCnRawoCcjYByenrFhLAJaA == Environment.CurrentManagedThreadId)
					{
						eKHFoEuaApQScSwMsFSLWkqlztgL = 0;
						jZiASQHAZInlhESGAkOVKAAvFbnGB2 = this;
					}
					else
					{
						jZiASQHAZInlhESGAkOVKAAvFbnGB2 = new jZiASQHAZInlhESGAkOVKAAvFbnGB(0);
						jZiASQHAZInlhESGAkOVKAAvFbnGB2.CXGbLBSqkbCfFAQeMcUnckNvchad = CXGbLBSqkbCfFAQeMcUnckNvchad;
					}
					return jZiASQHAZInlhESGAkOVKAAvFbnGB2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly wOaGkOwKQRDPDjoJiYyBamBnEPjC ntKuRXciJqfKneCsEPXNAdvJolGM;

			private bool AyylMzYuhLVMwgAkkqmLtJeSZafC;

			private bool yZXyKtusfpuhWKpfOGivkRfZYcjW;

			private bool KYQpNOOadODpKfocuYWAAuVJnLGhb;

			private double hIZGuHgkOrPbxloXSJiNheYDCOfP;

			private double tyYuOjXpYJVChVPZlGPIvetYTZxi;

			private SafeAction<ControllerAssignmentChangedEventArgs> mNBTKiJphXfFvbOlpsgysLqnfbuc = new SafeAction<ControllerAssignmentChangedEventArgs>(rCdIpSpjVcXSnGkOXAasCFwXhWcp._003C_003E9.rChwkLuOgykPDzGjvVSPqqIGqzrB);

			private SafeAction<ControllerAssignmentChangedEventArgs> QlVdPWtCzkFbzyklcKGmuGEjNxpo = new SafeAction<ControllerAssignmentChangedEventArgs>(rCdIpSpjVcXSnGkOXAasCFwXhWcp._003C_003E9.fxmMDQUUpFhWJmTjqpzIPrFlVbQO);

			private readonly fALzHtOiVzaKOePkTTRfslfNFuDTA KTGnihwWgjrSAXzmfssQSNNTwGSo;

			private readonly Player MNgVGdKGZLcjYDYrstqreoJYyzGT;

			private readonly OjcmMGKoEtsDrpMbbivWBgdDESNv fpqGkxTZweHZBwMJglfYrACIIxOx;

			private readonly int RULaWCpoqxXrOllctyoBfIHiSgsT;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap> IdXntCWLqmcpKWdMbubqFFsVDjNx => (yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick);

			private global::IgBMMomXzYsKPUuCnpqyGLgpzshG<KeyboardMap> VZCoPBsGbmJMgghTsdBTAjjoGqsV => (global::IgBMMomXzYsKPUuCnpqyGLgpzshG<KeyboardMap>)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Keyboard).jxGNMeDStoCqCXFxSStAYeBTQCmC(0).XCfFEHCAovUlErZTLVujHEbwOdRG;

			private global::IgBMMomXzYsKPUuCnpqyGLgpzshG<MouseMap> umNPfzmglfihAHAQFrHLVbbipBXyA => (global::IgBMMomXzYsKPUuCnpqyGLgpzshG<MouseMap>)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Mouse).jxGNMeDStoCqCXFxSStAYeBTQCmC(0).XCfFEHCAovUlErZTLVujHEbwOdRG;

			private yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap> jQagOUghReThwXIwYFFvuoKdhwOj => (yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return false;
					}
					return AyylMzYuhLVMwgAkkqmLtJeSZafC;
				}
				set
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						if (AyylMzYuhLVMwgAkkqmLtJeSZafC == value)
						{
							return;
						}
						AyylMzYuhLVMwgAkkqmLtJeSZafC = value;
						if (value)
						{
							fpqGkxTZweHZBwMJglfYrACIIxOx.mcsxbweWRGUKtgrASoFyRmtDKWxj(Mouse);
						}
						else
						{
							fpqGkxTZweHZBwMJglfYrACIIxOx.HOZrlIfnvifRuONAxZciwsfqtFKU(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (mNBTKiJphXfFvbOlpsgysLqnfbuc.Count > 0)
							{
								mNBTKiJphXfFvbOlpsgysLqnfbuc.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (QlVdPWtCzkFbzyklcKGmuGEjNxpo.Count > 0)
						{
							QlVdPWtCzkFbzyklcKGmuGEjNxpo.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return false;
					}
					return yZXyKtusfpuhWKpfOGivkRfZYcjW;
				}
				set
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						if (yZXyKtusfpuhWKpfOGivkRfZYcjW == value)
						{
							return;
						}
						yZXyKtusfpuhWKpfOGivkRfZYcjW = value;
						if (value)
						{
							fpqGkxTZweHZBwMJglfYrACIIxOx.mcsxbweWRGUKtgrASoFyRmtDKWxj(Keyboard);
						}
						else
						{
							fpqGkxTZweHZBwMJglfYrACIIxOx.HOZrlIfnvifRuONAxZciwsfqtFKU(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (mNBTKiJphXfFvbOlpsgysLqnfbuc.Count > 0)
							{
								mNBTKiJphXfFvbOlpsgysLqnfbuc.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (QlVdPWtCzkFbzyklcKGmuGEjNxpo.Count > 0)
						{
							QlVdPWtCzkFbzyklcKGmuGEjNxpo.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return false;
					}
					return KYQpNOOadODpKfocuYWAAuVJnLGhb;
				}
				set
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						KYQpNOOadODpKfocuYWAAuVJnLGhb = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return 0;
					}
					return ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick).umplaoBWNrHpDalRCquleOiTParq;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick) as yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>).ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return 0;
					}
					return ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom).umplaoBWNrHpDalRCquleOiTParq;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom) as yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>).ONvuBkVYHnIsPvDHhAeUTNTVqEEQ;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				[IteratorStateMachine(typeof(jZiASQHAZInlhESGAkOVKAAvFbnGB))]
				get
				{
					return new jZiASQHAZInlhESGAkOVKAAvFbnGB(-2)
					{
						CXGbLBSqkbCfFAQeMcUnckNvchad = this
					};
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					mNBTKiJphXfFvbOlpsgysLqnfbuc.AddDelegate(value);
				}
				remove
				{
					mNBTKiJphXfFvbOlpsgysLqnfbuc.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					QlVdPWtCzkFbzyklcKGmuGEjNxpo.AddDelegate(value);
				}
				remove
				{
					QlVdPWtCzkFbzyklcKGmuGEjNxpo.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, FGaEqsabChAigPfOzNCChKOtJbXxA P_1, ControllerMapLayoutManager.LGBrMNZdvgtEkBpNABJGpIHRtmbV P_2, ControllerMapEnabler.ZppkwHkpXIKClTnElCTrJXPsNYtW P_3)
			{
				RULaWCpoqxXrOllctyoBfIHiSgsT = ReInput.id;
				MNgVGdKGZLcjYDYrstqreoJYyzGT = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				ntKuRXciJqfKneCsEPXNAdvJolGM = new wOaGkOwKQRDPDjoJiYyBamBnEPjC(4);
				ntKuRXciJqfKneCsEPXNAdvJolGM.RVkHnwTSgTBHrpRuripGHORPPnoB(0, ControllerType.Joystick, new yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>());
				ntKuRXciJqfKneCsEPXNAdvJolGM.RVkHnwTSgTBHrpRuripGHORPPnoB(1, ControllerType.Keyboard, new yvMungSQMqFTsqBLbgYkYfemOFGR<Keyboard, KeyboardMap>());
				ntKuRXciJqfKneCsEPXNAdvJolGM.RVkHnwTSgTBHrpRuripGHORPPnoB(2, ControllerType.Mouse, new yvMungSQMqFTsqBLbgYkYfemOFGR<Mouse, MouseMap>());
				ntKuRXciJqfKneCsEPXNAdvJolGM.RVkHnwTSgTBHrpRuripGHORPPnoB(3, ControllerType.Custom, new yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>());
				KTGnihwWgjrSAXzmfssQSNNTwGSo = new fALzHtOiVzaKOePkTTRfslfNFuDTA(P_0);
				fpqGkxTZweHZBwMJglfYrACIIxOx = new OjcmMGKoEtsDrpMbbivWBgdDESNv(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				return (T)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(pMvvECjJycyKibKKCAXEnFbBPTVk.lyqMztbyatoMUKMuxYoMSsQxpNMe<T>()).srFCiMaywLRdTHCeENBnRscpJzkEb(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				return ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType).srFCiMaywLRdTHCeENBnRscpJzkEb(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				return (T)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(pMvvECjJycyKibKKCAXEnFbBPTVk.lyqMztbyatoMUKMuxYoMSsQxpNMe<T>()).xwIczbdsEWFyJsfwHWQrAWolXTSQ(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				return ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(controllerType).xwIczbdsEWFyJsfwHWQrAWolXTSQ(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					QvduXAJMYkmcpcZCinwuOxLnkDLR(controllerId, removeFromOtherPlayers);
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
					xQIXpqWHkvPkhpIWOZmbBrSOnsoP(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						sCIFHToWfQnhEAfArrKPFMLckxRK(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						bCgofTxPFyNtRkcVhedbRvowccTD(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					sCIFHToWfQnhEAfArrKPFMLckxRK(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
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
					bCgofTxPFyNtRkcVhedbRvowccTD(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					gEhneSstbudEWGSmADMxIwHFCfAH(controllerId);
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
					QNcfDzLraNXhjQCTBGVTGrASeOLuA(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					gEhneSstbudEWGSmADMxIwHFCfAH(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					QNcfDzLraNXhjQCTBGVTGrASeOLuA(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						XlhpsUFMcRPoOyGhZKitXyTxQmsU(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						nmWYJXdDOFaYTdfPaMyVuplNdRBw(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return yZXyKtusfpuhWKpfOGivkRfZYcjW;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return AyylMzYuhLVMwgAkkqmLtJeSZafC;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick).BsgehaiWaTDIVAjKTpeWrtLjZWiM(controllerId), 
					ControllerType.Keyboard => yZXyKtusfpuhWKpfOGivkRfZYcjW, 
					ControllerType.Mouse => AyylMzYuhLVMwgAkkqmLtJeSZafC, 
					ControllerType.Custom => ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom).BsgehaiWaTDIVAjKTpeWrtLjZWiM(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
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
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					GNvPvAvrsaNPDMZIRcyEwwgknUkg();
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
					zCbfIAhjHIHOIbqUbNdbOmHRFRKW();
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
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					GNvPvAvrsaNPDMZIRcyEwwgknUkg();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					zCbfIAhjHIHOIbqUbNdbOmHRFRKW();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return;
				}
				GNvPvAvrsaNPDMZIRcyEwwgknUkg();
				zCbfIAhjHIHOIbqUbNdbOmHRFRKW();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				eegFAZxSUmBBNbTukrDNqiNdGxhS(ControllerType.Joystick, ref result, ref num);
				if (AyylMzYuhLVMwgAkkqmLtJeSZafC && hIZGuHgkOrPbxloXSJiNheYDCOfP > num)
				{
					result = Mouse;
					num = hIZGuHgkOrPbxloXSJiNheYDCOfP;
				}
				if (yZXyKtusfpuhWKpfOGivkRfZYcjW && tyYuOjXpYJVChVPZlGPIvetYTZxi > num)
				{
					result = Keyboard;
					num = tyYuOjXpYJVChVPZlGPIvetYTZxi;
				}
				eegFAZxSUmBBNbTukrDNqiNdGxhS(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					eegFAZxSUmBBNbTukrDNqiNdGxhS(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (yZXyKtusfpuhWKpfOGivkRfZYcjW && tyYuOjXpYJVChVPZlGPIvetYTZxi > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (AyylMzYuhLVMwgAkkqmLtJeSZafC && hIZGuHgkOrPbxloXSJiNheYDCOfP > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void eegFAZxSUmBBNbTukrDNqiNdGxhS(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
				int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq;
				for (int i = 0; i < num; i++)
				{
					double num2 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).VumrgdvHaLTaRsjrZxMuNKrNcNNM;
					if (!(num2 <= P_2))
					{
						P_1 = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(i).KHNnRvXGgofSbETmKmwfENQvePGfb;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(pMvvECjJycyKibKKCAXEnFbBPTVk.lyqMztbyatoMUKMuxYoMSsQxpNMe<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						MNgVGdKGZLcjYDYrstqreoJYyzGT.ChjszcuelKVDqAqbDuLbZvXLnYZV.HKTTrRHibBJVyaZqSouJhcDeBXirA(MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						MNgVGdKGZLcjYDYrstqreoJYyzGT.ChjszcuelKVDqAqbDuLbZvXLnYZV.mssgDBdmbLhHnAQMgcuPnUhZQfidb(MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						MNgVGdKGZLcjYDYrstqreoJYyzGT.ChjszcuelKVDqAqbDuLbZvXLnYZV.YVQdcJlswpQYfZifMRqocozGRlZH(MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						MNgVGdKGZLcjYDYrstqreoJYyzGT.ChjszcuelKVDqAqbDuLbZvXLnYZV.CLVHynSjFWTzxAZfhfQzUblfEOps(MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
					{
						ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					}
					else
					{
						MNgVGdKGZLcjYDYrstqreoJYyzGT.ChjszcuelKVDqAqbDuLbZvXLnYZV.ZcOnLgmAXFOJxxCycKNMXUNvuzgU(MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				int nQoHyMZYKlXumNJJFucpVpPhPqyH = ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
				for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
				{
					Controller controller = muEbJGjtsIPvVurqvtKoiZaLvkqoA(ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i).RnJpoDfFtBKuYnlGelTlylszpsZN, Controller.GxctryFQdLTiRyKyXNsoBJqPIENh, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return null;
				}
				int nQoHyMZYKlXumNJJFucpVpPhPqyH = ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH;
				for (int i = 0; i < nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
				{
					Controller controller = muEbJGjtsIPvVurqvtKoiZaLvkqoA(ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i).RnJpoDfFtBKuYnlGelTlylszpsZN, Controller.jfyhkrMaNhjjBjaTcjQCIBTYndmh, templateType);
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
				if (ReInput._id != RULaWCpoqxXrOllctyoBfIHiSgsT)
				{
					ReInput.CheckInitialized(RULaWCpoqxXrOllctyoBfIHiSgsT);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return fpqGkxTZweHZBwMJglfYrACIIxOx.SCJuuKoJjCugoMTQgClkGCmJsHoD<TInterface>();
			}

			private Controller muEbJGjtsIPvVurqvtKoiZaLvkqoA<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
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
					if (yZXyKtusfpuhWKpfOGivkRfZYcjW && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (AyylMzYuhLVMwgAkkqmLtJeSZafC && P_1(Mouse, P_2))
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

			internal void NLQiQJfFmwuMTEbcvURSdbYICIih()
			{
				for (int i = 0; i < ntKuRXciJqfKneCsEPXNAdvJolGM.nQoHyMZYKlXumNJJFucpVpPhPqyH; i++)
				{
					ntKuRXciJqfKneCsEPXNAdvJolGM.pfUhQqMOQUcMOBkLkFFSadSuHYzqA(i).rathYiUMZUILQLDtwGIGWMqiANoKA();
				}
				ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Keyboard).FfSCzSboPbLWILMRSkHVFCPxZzVM(new yvMungSQMqFTsqBLbgYkYfemOFGR<Keyboard, KeyboardMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv(ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.IHPfnLMrgyTtYeIwxJsMlnCYMDst, new global::IgBMMomXzYsKPUuCnpqyGLgpzshG<KeyboardMap>(0)));
				ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Mouse).FfSCzSboPbLWILMRSkHVFCPxZzVM(new yvMungSQMqFTsqBLbgYkYfemOFGR<Mouse, MouseMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv(ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.QsgkmYvQGAwyNumMjGEvekEAbBLHA, new global::IgBMMomXzYsKPUuCnpqyGLgpzshG<MouseMap>(0)));
				KTGnihwWgjrSAXzmfssQSNNTwGSo.BqgBcqjyLqwRboYOYXfuMZVNjryj();
				tyYuOjXpYJVChVPZlGPIvetYTZxi = 0.0;
				hIZGuHgkOrPbxloXSJiNheYDCOfP = 0.0;
				maps.ScCJNQQMUEjRDEPsEnNNpdlVceCN();
			}

			internal double lLSxpTRMcNgXMYtOMTfcsVDWpGpX(int P_0)
			{
				return KTGnihwWgjrSAXzmfssQSNNTwGSo.EmuKMJVOtciyrJfMSfycJsXauaPK(P_0)?.zwfCVCcJhGEqFBWDnqIuWnKJezOk ?? (-1.0);
			}

			internal void sCIFHToWfQnhEAfArrKPFMLckxRK(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick);
				if (unzVxbtGRmQZzSvYceNVtoUGFLPd2.BsgehaiWaTDIVAjKTpeWrtLjZWiM(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				fALzHtOiVzaKOePkTTRfslfNFuDTA.PBCZTSFgsbIkElJkuEOyibACCLaT pBCZTSFgsbIkElJkuEOyibACCLaT = KTGnihwWgjrSAXzmfssQSNNTwGSo.EmuKMJVOtciyrJfMSfycJsXauaPK(P_0.id);
				yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv bYDcyWECHLgfltcQBjcCpqKRnGVv;
				if (pBCZTSFgsbIkElJkuEOyibACCLaT != null && pBCZTSFgsbIkElJkuEOyibACCLaT.YWDCBsksBJiokrUWqltxMJNgsBzrA != null)
				{
					bYDcyWECHLgfltcQBjcCpqKRnGVv = new yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv(P_0, pBCZTSFgsbIkElJkuEOyibACCLaT.YWDCBsksBJiokrUWqltxMJNgsBzrA);
				}
				else
				{
					global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap> igBMMomXzYsKPUuCnpqyGLgpzshG = maps.CVsmJZGCrpynlUiWlHsIELLSaaSl(P_0, true);
					if (igBMMomXzYsKPUuCnpqyGLgpzshG == null)
					{
						igBMMomXzYsKPUuCnpqyGLgpzshG = new global::IgBMMomXzYsKPUuCnpqyGLgpzshG<JoystickMap>(P_0.id);
					}
					bYDcyWECHLgfltcQBjcCpqKRnGVv = new yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv(P_0, igBMMomXzYsKPUuCnpqyGLgpzshG);
				}
				unzVxbtGRmQZzSvYceNVtoUGFLPd2.FfSCzSboPbLWILMRSkHVFCPxZzVM(bYDcyWECHLgfltcQBjcCpqKRnGVv);
				KTGnihwWgjrSAXzmfssQSNNTwGSo.XPEGVPiUiDmECOTmlAliQkZBsMwn(bYDcyWECHLgfltcQBjcCpqKRnGVv);
				fpqGkxTZweHZBwMJglfYrACIIxOx.mcsxbweWRGUKtgrASoFyRmtDKWxj(P_0);
				maps.layoutManager.Apply();
				if (mNBTKiJphXfFvbOlpsgysLqnfbuc.Count > 0)
				{
					mNBTKiJphXfFvbOlpsgysLqnfbuc.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void QvduXAJMYkmcpcZCinwuOxLnkDLR(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					sCIFHToWfQnhEAfArrKPFMLckxRK(joystick, P_1);
				}
			}

			internal void gEhneSstbudEWGSmADMxIwHFCfAH(int P_0)
			{
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick);
				if (unzVxbtGRmQZzSvYceNVtoUGFLPd2.BsgehaiWaTDIVAjKTpeWrtLjZWiM(P_0))
				{
					if (unzVxbtGRmQZzSvYceNVtoUGFLPd2.jxGNMeDStoCqCXFxSStAYeBTQCmC(P_0) is yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv bYDcyWECHLgfltcQBjcCpqKRnGVv)
					{
						KTGnihwWgjrSAXzmfssQSNNTwGSo.XPEGVPiUiDmECOTmlAliQkZBsMwn(bYDcyWECHLgfltcQBjcCpqKRnGVv);
					}
					unzVxbtGRmQZzSvYceNVtoUGFLPd2.qVUSrCgskajxxHBZIbzlMkvVRbmrA(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					fpqGkxTZweHZBwMJglfYrACIIxOx.HOZrlIfnvifRuONAxZciwsfqtFKU(joystick);
					if (QlVdPWtCzkFbzyklcKGmuGEjNxpo.Count > 0)
					{
						QlVdPWtCzkFbzyklcKGmuGEjNxpo.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void XlhpsUFMcRPoOyGhZKitXyTxQmsU(Joystick P_0)
			{
				if (P_0 != null)
				{
					gEhneSstbudEWGSmADMxIwHFCfAH(P_0.id);
				}
			}

			internal void GNvPvAvrsaNPDMZIRcyEwwgknUkg()
			{
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Joystick);
				for (int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq - 1; num >= 0; num--)
				{
					KTGnihwWgjrSAXzmfssQSNNTwGSo.XPEGVPiUiDmECOTmlAliQkZBsMwn(unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num) as yvMungSQMqFTsqBLbgYkYfemOFGR<Joystick, JoystickMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv);
					fpqGkxTZweHZBwMJglfYrACIIxOx.HOZrlIfnvifRuONAxZciwsfqtFKU(unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb);
					int id = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb.id;
					unzVxbtGRmQZzSvYceNVtoUGFLPd2.VrubidYQNwPKnPJaUaYQCSusGvMX(num);
					if (QlVdPWtCzkFbzyklcKGmuGEjNxpo.Count > 0)
					{
						QlVdPWtCzkFbzyklcKGmuGEjNxpo.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, id, ControllerType.Joystick, false));
					}
				}
				unzVxbtGRmQZzSvYceNVtoUGFLPd2.rathYiUMZUILQLDtwGIGWMqiANoKA();
			}

			internal void bCgofTxPFyNtRkcVhedbRvowccTD(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom);
				if (!unzVxbtGRmQZzSvYceNVtoUGFLPd2.BsgehaiWaTDIVAjKTpeWrtLjZWiM(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::IgBMMomXzYsKPUuCnpqyGLgpzshG<CustomControllerMap> igBMMomXzYsKPUuCnpqyGLgpzshG = maps.tGJFSnfAKfEIdGHGDNETyatlqhJd(P_0, true);
					if (igBMMomXzYsKPUuCnpqyGLgpzshG == null)
					{
						igBMMomXzYsKPUuCnpqyGLgpzshG = new global::IgBMMomXzYsKPUuCnpqyGLgpzshG<CustomControllerMap>(P_0.id);
					}
					yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv bYDcyWECHLgfltcQBjcCpqKRnGVv = new yvMungSQMqFTsqBLbgYkYfemOFGR<CustomController, CustomControllerMap>.bYDcyWECHLgfltcQBjcCpqKRnGVv(P_0, igBMMomXzYsKPUuCnpqyGLgpzshG);
					unzVxbtGRmQZzSvYceNVtoUGFLPd2.FfSCzSboPbLWILMRSkHVFCPxZzVM(bYDcyWECHLgfltcQBjcCpqKRnGVv);
					fpqGkxTZweHZBwMJglfYrACIIxOx.mcsxbweWRGUKtgrASoFyRmtDKWxj(P_0);
					maps.layoutManager.Apply();
					if (mNBTKiJphXfFvbOlpsgysLqnfbuc.Count > 0)
					{
						mNBTKiJphXfFvbOlpsgysLqnfbuc.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void xQIXpqWHkvPkhpIWOZmbBrSOnsoP(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					bCgofTxPFyNtRkcVhedbRvowccTD(customController, P_1);
				}
			}

			internal void QNcfDzLraNXhjQCTBGVTGrASeOLuA(int P_0)
			{
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom);
				if (unzVxbtGRmQZzSvYceNVtoUGFLPd2.BsgehaiWaTDIVAjKTpeWrtLjZWiM(P_0))
				{
					unzVxbtGRmQZzSvYceNVtoUGFLPd2.jxGNMeDStoCqCXFxSStAYeBTQCmC(P_0);
					unzVxbtGRmQZzSvYceNVtoUGFLPd2.qVUSrCgskajxxHBZIbzlMkvVRbmrA(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					fpqGkxTZweHZBwMJglfYrACIIxOx.HOZrlIfnvifRuONAxZciwsfqtFKU(customController);
					if (QlVdPWtCzkFbzyklcKGmuGEjNxpo.Count > 0)
					{
						QlVdPWtCzkFbzyklcKGmuGEjNxpo.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void nmWYJXdDOFaYTdfPaMyVuplNdRBw(CustomController P_0)
			{
				if (P_0 != null)
				{
					QNcfDzLraNXhjQCTBGVTGrASeOLuA(P_0.id);
				}
			}

			internal void zCbfIAhjHIHOIbqUbNdbOmHRFRKW()
			{
				unzVxbtGRmQZzSvYceNVtoUGFLPd unzVxbtGRmQZzSvYceNVtoUGFLPd2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Custom);
				for (int num = unzVxbtGRmQZzSvYceNVtoUGFLPd2.umplaoBWNrHpDalRCquleOiTParq - 1; num >= 0; num--)
				{
					fpqGkxTZweHZBwMJglfYrACIIxOx.HOZrlIfnvifRuONAxZciwsfqtFKU(unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb);
					int id = unzVxbtGRmQZzSvYceNVtoUGFLPd2.XyKTgMxvPKsPsAOqAWrzShIBzUTi(num).KHNnRvXGgofSbETmKmwfENQvePGfb.id;
					unzVxbtGRmQZzSvYceNVtoUGFLPd2.VrubidYQNwPKnPJaUaYQCSusGvMX(num);
					if (QlVdPWtCzkFbzyklcKGmuGEjNxpo.Count > 0)
					{
						QlVdPWtCzkFbzyklcKGmuGEjNxpo.Invoke(new ControllerAssignmentChangedEventArgs(MNgVGdKGZLcjYDYrstqreoJYyzGT.id, id, ControllerType.Custom, false));
					}
				}
				unzVxbtGRmQZzSvYceNVtoUGFLPd2.rathYiUMZUILQLDtwGIGWMqiANoKA();
			}

			internal CustomController lVctFxZAoBDjNfaaAhcAsKuwuxfG(int P_0)
			{
				CustomController customController = MNgVGdKGZLcjYDYrstqreoJYyzGT.ChjszcuelKVDqAqbDuLbZvXLnYZV.BRugcGeISrSegSkXsKuwCEfyEwuDb(P_0);
				if (customController == null)
				{
					return null;
				}
				bCgofTxPFyNtRkcVhedbRvowccTD(customController, false);
				return customController;
			}

			internal void sLcDWLPBVKCTODdQsSzxhTLYVcIHA(Action<bool, int, int> P_0)
			{
				SlbQCQUvpMjOcteaAxfdxfThdfgY<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void HYCtoLyFwTaRVGqzlBBEjsDWTtxL(Keyboard P_0, rACoEbOYRqZwIwjFrZCMRTeoChil P_1, Action<bool, int, int> P_2)
			{
				if (!yZXyKtusfpuhWKpfOGivkRfZYcjW || !P_0.enabled)
				{
					return;
				}
				OZvjmzSbmZlSrQThaAEaunubDygp ogrdJsETggnJUgcgqCbTgJfFRarCB = dhgRPzBCLEtjJBicagpEtUtuCThf.OgrdJsETggnJUgcgqCbTgJfFRarCB;
				bool flag = false;
				cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Keyboard).jxGNMeDStoCqCXFxSStAYeBTQCmC(0).XCfFEHCAovUlErZTLVujHEbwOdRG;
				int num = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.OEydHsjiiTRjhFtrBfeqPfyluIMc;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						bool num2 = actionElementMap._modifierKey1 != ModifierKey.None || actionElementMap._modifierKey2 != ModifierKey.None || actionElementMap._modifierKey3 != ModifierKey.None;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						bool flag2 = false;
						ModifierKeyFlags modifierKeyFlags;
						ZVeDITCkNUczQyzeiCRedgPnAJmWA zVeDITCkNUczQyzeiCRedgPnAJmWA;
						if (num2)
						{
							modifierKeyFlags = actionElementMap.modifierKeyFlags;
							if (P_0.yVcNqBAEUxlpRZSbUhvGHtzNLxSO(keyboardKeyCode, modifierKeyFlags))
							{
								if (!P_1.SQPMkVXXuMMCRToVuxpmOxmjpipw(keyboardKeyCode, modifierKeyFlags))
								{
									zVeDITCkNUczQyzeiCRedgPnAJmWA = ZVeDITCkNUczQyzeiCRedgPnAJmWA.kVAOkDyfOTCsVgEDxHEistYqhGEbA(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA);
									zVeDITCkNUczQyzeiCRedgPnAJmWA.VnuHeZNaQAlXPxqYmEJJCfgVeIat(ReInput.currentUpdateLoop, true);
									flag2 = true;
									goto IL_0119;
								}
							}
							else
							{
								zVeDITCkNUczQyzeiCRedgPnAJmWA = ZVeDITCkNUczQyzeiCRedgPnAJmWA.yJdlzQowkVunjlXfmkoITHuOVkEK(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA);
								if (zVeDITCkNUczQyzeiCRedgPnAJmWA != null)
								{
									goto IL_0119;
								}
							}
							goto IL_0170;
						}
						modifierKeyFlags = ModifierKeyFlags.None;
						ButtonStateFlags buttonStateFlags = P_0.kyqBftSHvuReXoRMAYBSHHnbCbRK(actionElementMap.rLYEVHHFczfqTKqknfIMkkwHoRbL);
						goto IL_0137;
						IL_0137:
						if (buttonStateFlags != ButtonStateFlags.Off && (flag2 || !P_1.SQPMkVXXuMMCRToVuxpmOxmjpipw(keyboardKeyCode, modifierKeyFlags)))
						{
							HoQotorYemALzIDGxtpuiNYECT(P_0, keyboardMap, actionElementMap, ogrdJsETggnJUgcgqCbTgJfFRarCB, buttonStateFlags);
							P_2(arg1: true, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId);
							flag = true;
							continue;
						}
						goto IL_0170;
						IL_0119:
						buttonStateFlags = zVeDITCkNUczQyzeiCRedgPnAJmWA.yKITVwafHDGnibrEGdrzgWPaUXtlA(true);
						goto IL_0137;
						IL_0170:
						if (ogrdJsETggnJUgcgqCbTgJfFRarCB.dKjQlYjISFyLZyMKxHykaYJBtKbvA != 0f)
						{
							ogrdJsETggnJUgcgqCbTgJfFRarCB.dKjQlYjISFyLZyMKxHykaYJBtKbvA = 0f;
						}
						if (ogrdJsETggnJUgcgqCbTgJfFRarCB.hEfdzFRvhOiuyBJZAEggXaJnkvJg != ButtonStateFlags.Off)
						{
							ogrdJsETggnJUgcgqCbTgJfFRarCB.hEfdzFRvhOiuyBJZAEggXaJnkvJg = ButtonStateFlags.Off;
						}
						P_2(arg1: false, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId);
					}
				}
				if (flag)
				{
					tyYuOjXpYJVChVPZlGPIvetYTZxi = ReInput.unscaledTime;
				}
			}

			private static void HoQotorYemALzIDGxtpuiNYECT(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, OZvjmzSbmZlSrQThaAEaunubDygp P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.dKjQlYjISFyLZyMKxHykaYJBtKbvA = num;
				P_3.hEfdzFRvhOiuyBJZAEggXaJnkvJg = P_4;
				P_3.eDvTslFgEuDWJTqavCGIFTDCsszfA = P_0;
				P_3.MvqRCBgfUzCHHAPLRdXAEoUfyTSsB = ControllerType.Keyboard;
				P_3.wLwHEbLivxrxJsPECRaxloNRdGnEA = ControllerElementType.Button;
				P_3.qNAMqNvLwTIsOUIjlOJuVlYHDMZW = P_2;
				P_3.dmVInoNlTDANRAHkKKXILhGyCbyab = P_1;
				if (P_3.uJJEzbtKHsRvZbJfDcEnNajtCxby)
				{
					P_3.uJJEzbtKHsRvZbJfDcEnNajtCxby = false;
				}
				if (P_3.UIKbpZdPuZJQqYINNXdWOoAwckfSA)
				{
					P_3.UIKbpZdPuZJQqYINNXdWOoAwckfSA = false;
				}
			}

			internal void POKgQdGHwsVMMCmyozzMtbxtxGuW(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!AyylMzYuhLVMwgAkkqmLtJeSZafC || !P_0.enabled)
				{
					return;
				}
				cAOEnjfvQnLBHThOTZsixNhIbMMJ cAOEnjfvQnLBHThOTZsixNhIbMMJ2 = ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(ControllerType.Mouse).jxGNMeDStoCqCXFxSStAYeBTQCmC(0).XCfFEHCAovUlErZTLVujHEbwOdRG;
				OZvjmzSbmZlSrQThaAEaunubDygp ogrdJsETggnJUgcgqCbTgJfFRarCB = dhgRPzBCLEtjJBicagpEtUtuCThf.OgrdJsETggnJUgcgqCbTgJfFRarCB;
				bool flag = false;
				int num = cAOEnjfvQnLBHThOTZsixNhIbMMJ2.dPIPVObnFHWdtcklJKiYcLFrwbdF;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)cAOEnjfvQnLBHThOTZsixNhIbMMJ2.vTSKHbrOptkhUmIMjLsBXHAVebGj(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.gnACjIDiJtzVNBgxjZoHVTGsGgGKA;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.aPIflIGGTRTchvDHqKrPQgyOxRkM(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.aPIflIGGTRTchvDHqKrPQgyOxRkM(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId);
									continue;
								}
							}
							ogrdJsETggnJUgcgqCbTgJfFRarCB.dKjQlYjISFyLZyMKxHykaYJBtKbvA = num2;
							ogrdJsETggnJUgcgqCbTgJfFRarCB.eDvTslFgEuDWJTqavCGIFTDCsszfA = P_0;
							ogrdJsETggnJUgcgqCbTgJfFRarCB.MvqRCBgfUzCHHAPLRdXAEoUfyTSsB = ControllerType.Mouse;
							ogrdJsETggnJUgcgqCbTgJfFRarCB.wLwHEbLivxrxJsPECRaxloNRdGnEA = ControllerElementType.Axis;
							ogrdJsETggnJUgcgqCbTgJfFRarCB.qNAMqNvLwTIsOUIjlOJuVlYHDMZW = actionElementMap;
							ogrdJsETggnJUgcgqCbTgJfFRarCB.dmVInoNlTDANRAHkKKXILhGyCbyab = mouseMap;
							if (ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA)
							{
								ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA = false;
							}
							if (ogrdJsETggnJUgcgqCbTgJfFRarCB.cMxdMKHfsYDHanfBEuvKteGarXiMA != AxisCoordinateMode.Relative)
							{
								ogrdJsETggnJUgcgqCbTgJfFRarCB.cMxdMKHfsYDHanfBEuvKteGarXiMA = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.OEydHsjiiTRjhFtrBfeqPfyluIMc;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.IsLhMigbUjEXecGyOLVKpDqHLWvyA(actionElementMap2, actionId2, out var dKjQlYjISFyLZyMKxHykaYJBtKbvA, out ogrdJsETggnJUgcgqCbTgJfFRarCB.uJJEzbtKHsRvZbJfDcEnNajtCxby))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.kyqBftSHvuReXoRMAYBSHHnbCbRK(actionElementMap2.rLYEVHHFczfqTKqknfIMkkwHoRbL);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId2);
							continue;
						}
						ogrdJsETggnJUgcgqCbTgJfFRarCB.dKjQlYjISFyLZyMKxHykaYJBtKbvA = dKjQlYjISFyLZyMKxHykaYJBtKbvA;
						ogrdJsETggnJUgcgqCbTgJfFRarCB.hEfdzFRvhOiuyBJZAEggXaJnkvJg = buttonStateFlags;
						ogrdJsETggnJUgcgqCbTgJfFRarCB.eDvTslFgEuDWJTqavCGIFTDCsszfA = P_0;
						ogrdJsETggnJUgcgqCbTgJfFRarCB.MvqRCBgfUzCHHAPLRdXAEoUfyTSsB = ControllerType.Mouse;
						ogrdJsETggnJUgcgqCbTgJfFRarCB.wLwHEbLivxrxJsPECRaxloNRdGnEA = ControllerElementType.Button;
						ogrdJsETggnJUgcgqCbTgJfFRarCB.qNAMqNvLwTIsOUIjlOJuVlYHDMZW = actionElementMap2;
						ogrdJsETggnJUgcgqCbTgJfFRarCB.dmVInoNlTDANRAHkKKXILhGyCbyab = mouseMap;
						if (ogrdJsETggnJUgcgqCbTgJfFRarCB.uJJEzbtKHsRvZbJfDcEnNajtCxby)
						{
							ogrdJsETggnJUgcgqCbTgJfFRarCB.uJJEzbtKHsRvZbJfDcEnNajtCxby = false;
						}
						if (ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA)
						{
							ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA = false;
						}
						P_1(arg1: true, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					hIZGuHgkOrPbxloXSJiNheYDCOfP = ReInput.unscaledTime;
				}
			}

			internal void VaCGzzeLWzaTBFxroNYhMMikEzuj(Action<bool, int, int> P_0)
			{
				SlbQCQUvpMjOcteaAxfdxfThdfgY<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void SlbQCQUvpMjOcteaAxfdxfThdfgY<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				yvMungSQMqFTsqBLbgYkYfemOFGR<_0001, _0002> yvMungSQMqFTsqBLbgYkYfemOFGR2 = (yvMungSQMqFTsqBLbgYkYfemOFGR<_0001, _0002>)ntKuRXciJqfKneCsEPXNAdvJolGM.fIvElAOCkJUcHKafaaNxIAGEVNzh(P_0);
				OZvjmzSbmZlSrQThaAEaunubDygp ogrdJsETggnJUgcgqCbTgJfFRarCB = dhgRPzBCLEtjJBicagpEtUtuCThf.OgrdJsETggnJUgcgqCbTgJfFRarCB;
				int num = yvMungSQMqFTsqBLbgYkYfemOFGR2.CWLECYOaiOjsDtPLimRKPeEPiywaA();
				for (int i = 0; i < num; i++)
				{
					yvMungSQMqFTsqBLbgYkYfemOFGR<_0001, _0002>.bYDcyWECHLgfltcQBjcCpqKRnGVv bYDcyWECHLgfltcQBjcCpqKRnGVv = yvMungSQMqFTsqBLbgYkYfemOFGR2.jkTmhXYPKjjXEdzcfyrnGPPahhrCA(i);
					_0001 iXFfJcQlRcjJSXDHlZIdknOrcNrEA = bYDcyWECHLgfltcQBjcCpqKRnGVv.IXFfJcQlRcjJSXDHlZIdknOrcNrEA;
					if (!iXFfJcQlRcjJSXDHlZIdknOrcNrEA.enabled)
					{
						continue;
					}
					global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0002> hCqsUTYybVMCVwCYQIskQMgrlygr = bYDcyWECHLgfltcQBjcCpqKRnGVv.HCqsUTYybVMCVwCYQIskQMgrlygr;
					bool flag = false;
					int num2 = hCqsUTYybVMCVwCYQIskQMgrlygr.RaeomPUMtcefLDSAzqHUlBVAPqHO();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = hCqsUTYybVMCVwCYQIskQMgrlygr.ShwbZGTrLUidtHoOuNTxBfnGibOXb(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.gnACjIDiJtzVNBgxjZoHVTGsGgGKA;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!iXFfJcQlRcjJSXDHlZIdknOrcNrEA.aPIflIGGTRTchvDHqKrPQgyOxRkM(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									iXFfJcQlRcjJSXDHlZIdknOrcNrEA.aPIflIGGTRTchvDHqKrPQgyOxRkM(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId);
										continue;
									}
								}
								ogrdJsETggnJUgcgqCbTgJfFRarCB.dKjQlYjISFyLZyMKxHykaYJBtKbvA = num3;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.eDvTslFgEuDWJTqavCGIFTDCsszfA = iXFfJcQlRcjJSXDHlZIdknOrcNrEA;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.MvqRCBgfUzCHHAPLRdXAEoUfyTSsB = P_0;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.wLwHEbLivxrxJsPECRaxloNRdGnEA = ControllerElementType.Axis;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.qNAMqNvLwTIsOUIjlOJuVlYHDMZW = actionElementMap;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.dmVInoNlTDANRAHkKKXILhGyCbyab = val;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA = iXFfJcQlRcjJSXDHlZIdknOrcNrEA.calibrationMap.Axes[actionElementMap.rLYEVHHFczfqTKqknfIMkkwHoRbL].applyRangeCalibration;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.cMxdMKHfsYDHanfBEuvKteGarXiMA = iXFfJcQlRcjJSXDHlZIdknOrcNrEA.Axes[actionElementMap.elementIndex].ecxPoTuiSHhzEinOJuPZQXPtumTW?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.OEydHsjiiTRjhFtrBfeqPfyluIMc;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float dKjQlYjISFyLZyMKxHykaYJBtKbvA = 0f;
								int rLYEVHHFczfqTKqknfIMkkwHoRbL = actionElementMap2.rLYEVHHFczfqTKqknfIMkkwHoRbL;
								if (!sBJkJvnhhefRkfCjzLqbQVMmFQXWA(iXFfJcQlRcjJSXDHlZIdknOrcNrEA, i, rLYEVHHFczfqTKqknfIMkkwHoRbL, actionElementMap2, hCqsUTYybVMCVwCYQIskQMgrlygr, actionId2, ref dKjQlYjISFyLZyMKxHykaYJBtKbvA) && !iXFfJcQlRcjJSXDHlZIdknOrcNrEA.IsLhMigbUjEXecGyOLVKpDqHLWvyA(actionElementMap2, actionId2, out dKjQlYjISFyLZyMKxHykaYJBtKbvA, out ogrdJsETggnJUgcgqCbTgJfFRarCB.uJJEzbtKHsRvZbJfDcEnNajtCxby))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = iXFfJcQlRcjJSXDHlZIdknOrcNrEA.kyqBftSHvuReXoRMAYBSHHnbCbRK(actionElementMap2.rLYEVHHFczfqTKqknfIMkkwHoRbL);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId2);
									continue;
								}
								ogrdJsETggnJUgcgqCbTgJfFRarCB.dKjQlYjISFyLZyMKxHykaYJBtKbvA = dKjQlYjISFyLZyMKxHykaYJBtKbvA;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.hEfdzFRvhOiuyBJZAEggXaJnkvJg = buttonStateFlags;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.eDvTslFgEuDWJTqavCGIFTDCsszfA = iXFfJcQlRcjJSXDHlZIdknOrcNrEA;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.MvqRCBgfUzCHHAPLRdXAEoUfyTSsB = P_0;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.wLwHEbLivxrxJsPECRaxloNRdGnEA = ControllerElementType.Button;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.qNAMqNvLwTIsOUIjlOJuVlYHDMZW = actionElementMap2;
								ogrdJsETggnJUgcgqCbTgJfFRarCB.dmVInoNlTDANRAHkKKXILhGyCbyab = val;
								if (ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA)
								{
									ogrdJsETggnJUgcgqCbTgJfFRarCB.UIKbpZdPuZJQqYINNXdWOoAwckfSA = false;
								}
								P_1(arg1: true, MNgVGdKGZLcjYDYrstqreoJYyzGT.bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							bYDcyWECHLgfltcQBjcCpqKRnGVv.dDMundcRBxaovBmVXrEYmuZBtMYk();
						}
					}
				}
			}

			private bool sBJkJvnhhefRkfCjzLqbQVMmFQXWA<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.jaSaHPudVtcyecnoPKkgZIAqgGJr.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.jaSaHPudVtcyecnoPKkgZIAqgGJr.GetUnknownHatButtons(P_2);
				if (GBcgxdlWUXuNfmqxbyhvPgukwKTX(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.uabTTFdLmcHfacHzwsFmzogjgfZP(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool GBcgxdlWUXuNfmqxbyhvPgukwKTX<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (iXhAOQcgpWliThliGtHTJaRufceaB(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool iXhAOQcgpWliThliGtHTJaRufceaB<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::IgBMMomXzYsKPUuCnpqyGLgpzshG<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.RaeomPUMtcefLDSAzqHUlBVAPqHO();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.ShwbZGTrLUidtHoOuNTxBfnGibOXb(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int rLYEVHHFczfqTKqknfIMkkwHoRbL = buttonMaps[j].rLYEVHHFczfqTKqknfIMkkwHoRbL;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(rLYEVHHFczfqTKqknfIMkkwHoRbL))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private readonly UgrefFwqJPPdjZGiGDKKCkBeaSXZ ChjszcuelKVDqAqbDuLbZvXLnYZV;

		private bool gVyuFIaNPueFxCQRCBPVBBLuDyUN;

		private int bSdaAPhhDIswtzqbUxjtIHqKNnBS;

		private string XdnpjQZIDBFQoHjHgJzMNTnaXybFA;

		private string sSORZzZNgfOhKAbjNUbQXpskxQDX;

		private bool YkReTYWDBpmIvxkdFpmXimFNfhvn;

		private readonly int RwpOtxJbZifhzFfdDJTUqDwzkBfA;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
					return -1;
				}
				return bSdaAPhhDIswtzqbUxjtIHqKNnBS;
			}
			internal set
			{
				bSdaAPhhDIswtzqbUxjtIHqKNnBS = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
					return string.Empty;
				}
				return XdnpjQZIDBFQoHjHgJzMNTnaXybFA;
			}
			internal set
			{
				XdnpjQZIDBFQoHjHgJzMNTnaXybFA = xdnpjQZIDBFQoHjHgJzMNTnaXybFA;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
					return string.Empty;
				}
				return sSORZzZNgfOhKAbjNUbQXpskxQDX;
			}
			internal set
			{
				sSORZzZNgfOhKAbjNUbQXpskxQDX = text;
			}
		}

		public bool isPlaying
		{
			get
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
					return false;
				}
				return YkReTYWDBpmIvxkdFpmXimFNfhvn;
			}
			set
			{
				YkReTYWDBpmIvxkdFpmXimFNfhvn = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, FGaEqsabChAigPfOzNCChKOtJbXxA P_4, ControllerMapLayoutManager.LGBrMNZdvgtEkBpNABJGpIHRtmbV P_5, ControllerMapEnabler.ZppkwHkpXIKClTnElCTrJXPsNYtW P_6)
		{
			gVyuFIaNPueFxCQRCBPVBBLuDyUN = P_0;
			bSdaAPhhDIswtzqbUxjtIHqKNnBS = P_1;
			XdnpjQZIDBFQoHjHgJzMNTnaXybFA = P_2;
			sSORZzZNgfOhKAbjNUbQXpskxQDX = P_3;
			RwpOtxJbZifhzFfdDJTUqDwzkBfA = ReInput.id;
			controllers = new ControllerHelper(this, P_4, P_5, P_6);
			ChjszcuelKVDqAqbDuLbZvXLnYZV = ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX;
			RRkafoEhvAlGkIfwofhocHFGOlzJ();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(bSdaAPhhDIswtzqbUxjtIHqKNnBS));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.MxEcNwtqdlIeerRnDukWeLuLhuJf() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.MxEcNwtqdlIeerRnDukWeLuLhuJf() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.rXrZPQfPVJBUbrjAjiOwpsbsoMBx() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.rXrZPQfPVJBUbrjAjiOwpsbsoMBx() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.rrhxDOjcPWqQgLfbTarpEkBOkrpI() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.rrhxDOjcPWqQgLfbTarpEkBOkrpI() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.liXbUFHVCBpFhLWTDlKOjLPFBciB() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.liXbUFHVCBpFhLWTDlKOjLPFBciB() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.IMesJCWkGWMkoFOzoNTQcWNjPzhC() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.IMesJCWkGWMkoFOzoNTQcWNjPzhC() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.OIdzQJjuZVtKkZuiimJuXxTbGrpS() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.OIdzQJjuZVtKkZuiimJuXxTbGrpS() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.KzdFwycHikmAYbIGeasoFGFhyGKTB() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.KzdFwycHikmAYbIGeasoFGFhyGKTB() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.xGzEFpGsojiRndDhgKgoTOCODuKHB(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.xGzEFpGsojiRndDhgKgoTOCODuKHB(speed) ?? false;
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.gLJFtiAyWSigKkAxGnnnHaGHaSXZ(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.gLJFtiAyWSigKkAxGnnnHaGHaSXZ(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.UJzDLqngfKZfwwGFxLGcXaeidbxL(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.UJzDLqngfKZfwwGFxLGcXaeidbxL(speed) ?? false;
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.qozCBEkJHtwbCPinkrfRknkdhoqeb(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.qozCBEkJHtwbCPinkrfRknkdhoqeb(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.qozCBEkJHtwbCPinkrfRknkdhoqeb(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.qozCBEkJHtwbCPinkrfRknkdhoqeb(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.jVjJkYKrrNEiZSHbnGbmIcYwvyOO(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.jVjJkYKrrNEiZSHbnGbmIcYwvyOO(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.GBgOspgmWlzNTXGUrDJdabTMgeLbb(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.GBgOspgmWlzNTXGUrDJdabTMgeLbb(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.GBgOspgmWlzNTXGUrDJdabTMgeLbb(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.GBgOspgmWlzNTXGUrDJdabTMgeLbb(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.UbUVWSbJsilCmSHGMfehdGYCIgCW() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.UbUVWSbJsilCmSHGMfehdGYCIgCW() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.GQiBxAivXCVFEsHXHZjXqdpTfmLc() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.GQiBxAivXCVFEsHXHZjXqdpTfmLc() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.qlKBOPfbpvRTxIgGgYfNUsruDPswA() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.qlKBOPfbpvRTxIgGgYfNUsruDPswA() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.LmfrdlDnMtLuYDOWHWUteOtwwgQN() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.LmfrdlDnMtLuYDOWHWUteOtwwgQN() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.fITinqfPzqbfabpxMpdpXBmDXFlv() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.fITinqfPzqbfabpxMpdpXBmDXFlv() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.miaYeVbqUiWlNiWtwobHLCmPYlNd() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.miaYeVbqUiWlNiWtwobHLCmPYlNd() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.wFjQJJLAvFQAiYmkUddgklxfsbWHA() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.wFjQJJLAvFQAiYmkUddgklxfsbWHA() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.aSkFSZcJqLreBjrkkTkqHznORRms(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.gMUidRrAJBVfQXwzFgOBRHdmiDnV(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.jWyfoGfUnNiFrhZEghPKISabVpZxc(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.nLufdwkEohyuAlrbcHZUXnkIkaihA(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.hSwdgViNMjnoHaXGdaynKZfSMbgEA() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.hSwdgViNMjnoHaXGdaynKZfSMbgEA() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.OdOMJtTggWNcMYBGCqrFyAsBXDYv() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.OdOMJtTggWNcMYBGCqrFyAsBXDYv() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.UmCYrzZMweTSJRYbCywvSFwqDXcv() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.UmCYrzZMweTSJRYbCywvSFwqDXcv() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.SXkkCHQJRMzOMmxushyoGBTkBdoIA() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.SXkkCHQJRMzOMmxushyoGBTkBdoIA() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.TagQxdEpgEJNLcLxWDqJBKBfzXpOA() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.TagQxdEpgEJNLcLxWDqJBKBfzXpOA() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.cZhWZRGqyHFnygvAvSMnAcTrdhlJ() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.cZhWZRGqyHFnygvAvSMnAcTrdhlJ() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.btfJMvnFgnhSOnWsOHJeYcVCLnPl() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.btfJMvnFgnhSOnWsOHJeYcVCLnPl() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.NnjhgnrvOwajKeXwSEqNBRvoSlWB() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.NnjhgnrvOwajKeXwSEqNBRvoSlWB() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.JbBDNNzhKAhAleqsuVYMGJoVCIgj() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.JbBDNNzhKAhAleqsuVYMGJoVCIgj() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.IOKNZPyiJUFNvjeFKQCCUSZGeVLc(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.IOKNZPyiJUFNvjeFKQCCUSZGeVLc(speed) ?? false;
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.WbGXiRufRLdVFrbmBJNuPjWWTCZj(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.WbGXiRufRLdVFrbmBJNuPjWWTCZj(speed) ?? false;
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.sJXRlomLwvumiMtlrFCyzJDlKXYd(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.sJXRlomLwvumiMtlrFCyzJDlKXYd(speed) ?? false;
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.MbiGHOFuOrudkJTfefnEApGkcIcZB(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.MbiGHOFuOrudkJTfefnEApGkcIcZB(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.MbiGHOFuOrudkJTfefnEApGkcIcZB(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.MbiGHOFuOrudkJTfefnEApGkcIcZB(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.bCRGhyLPrIrwZcSBolJdJdKGiajh(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.bCRGhyLPrIrwZcSBolJdJdKGiajh(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.fekVflJRTBrwpLSQSFoanCIvRlAy() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.fekVflJRTBrwpLSQSFoanCIvRlAy() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.nwHOEJwTdZLLNSGpDtDXAvEyveRv() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.nwHOEJwTdZLLNSGpDtDXAvEyveRv() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.GaqpYWpDXSGJnuNRYvOQFpdCdgDX() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.GaqpYWpDXSGJnuNRYvOQFpdCdgDX() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.FRQHTzPnYughiSpCuiHJGALtWMmPA() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.FRQHTzPnYughiSpCuiHJGALtWMmPA() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.hOSuOVrMBzfKDtHoTIHnFcQXgnWSA() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.hOSuOVrMBzfKDtHoTIHnFcQXgnWSA() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.SAtfgtyMVjIlidHIgorrvnAuINli() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.SAtfgtyMVjIlidHIgorrvnAuINli() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.hpKBlFdTbcLxxEDttXJWVHxJfGLTA() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.hpKBlFdTbcLxxEDttXJWVHxJfGLTA() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.jNpRuMFZZAHiussLdkzGZNDqeNnO(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.mUOKHNwMMYtprLvHEhhFDWYTQRjx(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.ysomKHpiWEBEtWEuSCSGixYYdbSnA(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.FzhLsuTQgoJrztoBTfbcivRJcDHEA(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.lLjRBQUrTCvvTBKsvnwQLDDOIjbL() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.lLjRBQUrTCvvTBKsvnwQLDDOIjbL() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.LWgnGcdKmURDmXofDlCdzZkFIQIU() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.LWgnGcdKmURDmXofDlCdzZkFIQIU() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.YUjfnjGGGnqMPGxXAPaENJeIDUqWc() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.YUjfnjGGGnqMPGxXAPaENJeIDUqWc() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.TCDdfCbKggAPtiwQGokuKSEFYXbDA() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.TCDdfCbKggAPtiwQGokuKSEFYXbDA() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.gFAaxRimefDUHASXCLCgGaxeRyOBA() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.gFAaxRimefDUHASXCLCgGaxeRyOBA() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.GzjLUajTFUHUlvGsMBpskFQeAJPjA() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.GzjLUajTFUHUlvGsMBpskFQeAJPjA() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.CEanUklplMerNgobhMomgCKByRHvB() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.CEanUklplMerNgobhMomgCKByRHvB() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.TchNrNGLZqpqhynPGrgMfaRTHfDI() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0f;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.TchNrNGLZqpqhynPGrgMfaRTHfDI() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.YUjfnjGGGnqMPGxXAPaENJeIDUqWc();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.YUjfnjGGGnqMPGxXAPaENJeIDUqWc();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.YUjfnjGGGnqMPGxXAPaENJeIDUqWc();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.YUjfnjGGGnqMPGxXAPaENJeIDUqWc();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.gFAaxRimefDUHASXCLCgGaxeRyOBA();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.gFAaxRimefDUHASXCLCgGaxeRyOBA();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.gFAaxRimefDUHASXCLCgGaxeRyOBA();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.gFAaxRimefDUHASXCLCgGaxeRyOBA();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.TCDdfCbKggAPtiwQGokuKSEFYXbDA();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.TCDdfCbKggAPtiwQGokuKSEFYXbDA();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.TCDdfCbKggAPtiwQGokuKSEFYXbDA();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.TCDdfCbKggAPtiwQGokuKSEFYXbDA();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.GzjLUajTFUHUlvGsMBpskFQeAJPjA();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionName, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.GzjLUajTFUHUlvGsMBpskFQeAJPjA();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, xAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.x = dhgRPzBCLEtjJBicagpEtUtuCThf2.GzjLUajTFUHUlvGsMBpskFQeAJPjA();
			}
			dhgRPzBCLEtjJBicagpEtUtuCThf2 = ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, yAxisActionId, true);
			if (dhgRPzBCLEtjJBicagpEtUtuCThf2 != null)
			{
				result.y = dhgRPzBCLEtjJBicagpEtUtuCThf2.GzjLUajTFUHUlvGsMBpskFQeAJPjA();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.LXLPgcvnRsPAOdhoJwEChctmxuoo() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.LXLPgcvnRsPAOdhoJwEChctmxuoo() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.HMPFEoFRINMQtOwnhBKCwkYZitiGA() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.HMPFEoFRINMQtOwnhBKCwkYZitiGA() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.OboXbWJjsLlPftXoIOqFYsWmBCAj() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.OboXbWJjsLlPftXoIOqFYsWmBCAj() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.ttYncCqZNaEMomAFsgeRDmLuIMvab() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return 0.0;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.ttYncCqZNaEMomAFsgeRDmLuIMvab() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.XtfqXDnNNCanHiYdrTIZBTaRqCcT() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.XtfqXDnNNCanHiYdrTIZBTaRqCcT() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.bbTJDBYubXJGDMKKbWFHaqAdnTaB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.bbTJDBYubXJGDMKKbWFHaqAdnTaB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.ZMJFBMeekjOGMaOeHZvgyJsKTlrPA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.ZMJFBMeekjOGMaOeHZvgyJsKTlrPA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.bwoebdhvgzUuoIkpIOXswqkaitvB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return AxisCoordinateMode.Absolute;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.bwoebdhvgzUuoIkpIOXswqkaitvB() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.sCJioeEbdozgSmoBldokHvfiZUcT();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.sCJioeEbdozgSmoBldokHvfiZUcT();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.baBOLEYgyzDsjIjkljKfhMidPlQCb(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.baBOLEYgyzDsjIjkljKfhMidPlQCb(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.pwHtsFYQtWhrDZNXssuNhOlGrgzF(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.pwHtsFYQtWhrDZNXssuNhOlGrgzF(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.cDsZNOLAeniGJlXONhiinQbijkWA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionName, true)?.iYaMCoEdjxKTlzCtBEfPqzoZlTNs(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return false;
			}
			return ChjszcuelKVDqAqbDuLbZvXLnYZV.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(bSdaAPhhDIswtzqbUxjtIHqKNnBS, actionId, true)?.iYaMCoEdjxKTlzCtBEfPqzoZlTNs(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.gmvAqoNbzAuRVbsAoAwhnaoGdAXkA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.KczjIfgZmFZCOgdjYlkEkYlDxOyQA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return;
			}
			int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
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
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.UBNVULzDbyIisGIxcgVVapKBagTJc(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.VwCeBVPhYLGQbKoryCsNcFSxCFoab(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return;
			}
			int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.OWWBWdFkavRVfATYarUqGPAcuUgUC(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.ShyVkXysYsRTSRCKwHCxwTqephGb(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return;
			}
			int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.ikefwaqbaDAJQINVEimkoUYlDFslA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.jlJpRdBavUZTDNNJtyhnbVBFfkhH(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.TFwPLSoKQNHvQEXCOJTMrtAXkqsS(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return;
			}
			int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.lILWaGhfMJNLhZiwuQbenXHJAzqe(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return;
			}
			int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.rPqVwbhlRaSWrbwsIDLurMjWDLSC(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.ztguvYSkvCgCetFwKtYdGbJEjsxA(bSdaAPhhDIswtzqbUxjtIHqKNnBS, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				return;
			}
			int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
				{
					ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
				}
				else
				{
					ChjszcuelKVDqAqbDuLbZvXLnYZV.RoagorIhsiazzzWhlzBBSGDcHShYA(bSdaAPhhDIswtzqbUxjtIHqKNnBS);
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
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
			if (ReInput._id != RwpOtxJbZifhzFfdDJTUqDwzkBfA)
			{
				ReInput.CheckInitialized(RwpOtxJbZifhzFfdDJTUqDwzkBfA);
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

		internal void rknyJtVGTpYJZQwOYGBBqMWdnfaF()
		{
			RRkafoEhvAlGkIfwofhocHFGOlzJ();
		}

		private void RRkafoEhvAlGkIfwofhocHFGOlzJ()
		{
			controllers.NLQiQJfFmwuMTEbcvURSdbYICIih();
			YkReTYWDBpmIvxkdFpmXimFNfhvn = false;
		}
	}
}
