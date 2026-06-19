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
	public sealed class Player : gDrCmzJNXwFvGTMAYKGQspUqeYD
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class hzxAuzgynQAnCruStmfFipLVRvPsA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int OdGlWZdhculwavFckzNlTXwAMbJi;

					private ElementAssignmentConflictInfo jnoIvftpgTQIWqpyDjtQIxACFzfN;

					private int ijvamCwAjPNZnqYmDjRhTzsuHXiu;

					private int QqugJujaeEIPtBDZohZoBbWIMyqnB;

					public int TfKLgUhTMeFlWFLGpSvgmhhofqnbA;

					private CustomControllerMap WELiNVcDGgkGBzuZaLIloHjFocyEA;

					public CustomControllerMap aMahIAKgbkGMEuhVetYaYigFgJIY;

					public ConflictCheckingHelper DggIHSiLvGyVxkdvaXqUTkVvISsBA;

					private bool wALHRwcVqfavlcRoSOehlxvZdQKI;

					public bool IhHkqyatVJtfumPSQyEYXtuRADNW;

					private bool wdlGOxtQMFSxYlAMuFRFXbLFRIsg;

					public bool RrBecHdUUJJhTNkuMIAxvhTpwswo;

					private int bZgzVzKmgRUUouHsRtkjigTQjwrG;

					private IEnumerator<ElementAssignmentConflictInfo> jIaMlahqrUAqPvTRWFfvdWYSEMzY;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return jnoIvftpgTQIWqpyDjtQIxACFzfN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jnoIvftpgTQIWqpyDjtQIxACFzfN;
						}
					}

					[DebuggerHidden]
					public hzxAuzgynQAnCruStmfFipLVRvPsA(int P_0)
					{
						OdGlWZdhculwavFckzNlTXwAMbJi = P_0;
						ijvamCwAjPNZnqYmDjRhTzsuHXiu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int odGlWZdhculwavFckzNlTXwAMbJi = OdGlWZdhculwavFckzNlTXwAMbJi;
						if (odGlWZdhculwavFckzNlTXwAMbJi == -3 || odGlWZdhculwavFckzNlTXwAMbJi == 1)
						{
							try
							{
							}
							finally
							{
								SdDLaXCJXdYPlbhrkZeflDGpvxBG();
							}
						}
						jIaMlahqrUAqPvTRWFfvdWYSEMzY = null;
						OdGlWZdhculwavFckzNlTXwAMbJi = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int odGlWZdhculwavFckzNlTXwAMbJi = OdGlWZdhculwavFckzNlTXwAMbJi;
							ConflictCheckingHelper dggIHSiLvGyVxkdvaXqUTkVvISsBA = DggIHSiLvGyVxkdvaXqUTkVvISsBA;
							if (odGlWZdhculwavFckzNlTXwAMbJi != 0)
							{
								if (odGlWZdhculwavFckzNlTXwAMbJi != 1)
								{
									return false;
								}
								OdGlWZdhculwavFckzNlTXwAMbJi = -3;
								goto IL_00eb;
							}
							OdGlWZdhculwavFckzNlTXwAMbJi = -1;
							if (QqugJujaeEIPtBDZohZoBbWIMyqnB < 0 || WELiNVcDGgkGBzuZaLIloHjFocyEA == null)
							{
								return false;
							}
							bZgzVzKmgRUUouHsRtkjigTQjwrG = 0;
							goto IL_0117;
							IL_00eb:
							if (jIaMlahqrUAqPvTRWFfvdWYSEMzY.MoveNext())
							{
								ElementAssignmentConflictInfo current = jIaMlahqrUAqPvTRWFfvdWYSEMzY.Current;
								jnoIvftpgTQIWqpyDjtQIxACFzfN = current;
								OdGlWZdhculwavFckzNlTXwAMbJi = 1;
								return true;
							}
							SdDLaXCJXdYPlbhrkZeflDGpvxBG();
							jIaMlahqrUAqPvTRWFfvdWYSEMzY = null;
							goto IL_0105;
							IL_0117:
							if (bZgzVzKmgRUUouHsRtkjigTQjwrG < dggIHSiLvGyVxkdvaXqUTkVvISsBA.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv())
							{
								if (dggIHSiLvGyVxkdvaXqUTkVvISsBA.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(bZgzVzKmgRUUouHsRtkjigTQjwrG).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == QqugJujaeEIPtBDZohZoBbWIMyqnB)
								{
									jIaMlahqrUAqPvTRWFfvdWYSEMzY = dggIHSiLvGyVxkdvaXqUTkVvISsBA.kBTUZmcyGFAiVnTqgkCgKTsNAVLH(ControllerType.Custom, QqugJujaeEIPtBDZohZoBbWIMyqnB, WELiNVcDGgkGBzuZaLIloHjFocyEA, wALHRwcVqfavlcRoSOehlxvZdQKI, wdlGOxtQMFSxYlAMuFRFXbLFRIsg, dggIHSiLvGyVxkdvaXqUTkVvISsBA.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(bZgzVzKmgRUUouHsRtkjigTQjwrG).ZfxPjujFGUgoCbyzcaKfutLOglBy).GetEnumerator();
									OdGlWZdhculwavFckzNlTXwAMbJi = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							bZgzVzKmgRUUouHsRtkjigTQjwrG++;
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

					private void SdDLaXCJXdYPlbhrkZeflDGpvxBG()
					{
						OdGlWZdhculwavFckzNlTXwAMbJi = -1;
						if (jIaMlahqrUAqPvTRWFfvdWYSEMzY != null)
						{
							jIaMlahqrUAqPvTRWFfvdWYSEMzY.Dispose();
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
						hzxAuzgynQAnCruStmfFipLVRvPsA hzxAuzgynQAnCruStmfFipLVRvPsA2;
						if (OdGlWZdhculwavFckzNlTXwAMbJi == -2 && ijvamCwAjPNZnqYmDjRhTzsuHXiu == Environment.CurrentManagedThreadId)
						{
							OdGlWZdhculwavFckzNlTXwAMbJi = 0;
							hzxAuzgynQAnCruStmfFipLVRvPsA2 = this;
						}
						else
						{
							hzxAuzgynQAnCruStmfFipLVRvPsA2 = new hzxAuzgynQAnCruStmfFipLVRvPsA(0);
							hzxAuzgynQAnCruStmfFipLVRvPsA2.DggIHSiLvGyVxkdvaXqUTkVvISsBA = DggIHSiLvGyVxkdvaXqUTkVvISsBA;
						}
						hzxAuzgynQAnCruStmfFipLVRvPsA2.QqugJujaeEIPtBDZohZoBbWIMyqnB = TfKLgUhTMeFlWFLGpSvgmhhofqnbA;
						hzxAuzgynQAnCruStmfFipLVRvPsA2.WELiNVcDGgkGBzuZaLIloHjFocyEA = aMahIAKgbkGMEuhVetYaYigFgJIY;
						hzxAuzgynQAnCruStmfFipLVRvPsA2.wALHRwcVqfavlcRoSOehlxvZdQKI = IhHkqyatVJtfumPSQyEYXtuRADNW;
						hzxAuzgynQAnCruStmfFipLVRvPsA2.wdlGOxtQMFSxYlAMuFRFXbLFRIsg = RrBecHdUUJJhTNkuMIAxvhTpwswo;
						return hzxAuzgynQAnCruStmfFipLVRvPsA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class fwYBnhywKqdggMEfbCpvkRfRiVCxA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int sGHMPyNuAeHQfkMAuHsjijQYuQTC;

					private ElementAssignmentConflictInfo vmmcxzCVhYsWvmWIsYjgncvAZxUGA;

					private int oKOcmOdNgwqsSaOYihLABNyorbEqb;

					private int dRiWOeanRfRPjVSSmCJbSHTjibTR;

					public int uEuazMKUwiKSKLYuFRsyGDttouCi;

					private ActionElementMap sTBisXqfsDGMFAaHjFTPiTxUDqLWA;

					public ActionElementMap JQkFyiGBnJOjFHqREfZuflETbGksB;

					public ConflictCheckingHelper igYcFqdMgAbJZgHwnnVVjiPnOUfUA;

					private CustomControllerMap ZmFaNcGbAsbmMhQKBoYURjFFOJgfc;

					public CustomControllerMap BeNeIVLqpmqgbYmsfpEiLpoqeCjEA;

					private bool AAnJPysoaWzfClLgIlSjAwuTWUGH;

					public bool RUCgpImzCdvHvSTxltXHJYvcjTov;

					private bool vFpAmfUwtWPsGNNIxULNrTyYpRPk;

					public bool ESsPLuGOnPZqjdDBXyexwDcaFEGw;

					private int djSKQQUdtkVxKqjZOqLphCdxBhRk;

					private IEnumerator<ElementAssignmentConflictInfo> zyuDsMgGlFpjljxyidExOkWKCiMM;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vmmcxzCVhYsWvmWIsYjgncvAZxUGA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vmmcxzCVhYsWvmWIsYjgncvAZxUGA;
						}
					}

					[DebuggerHidden]
					public fwYBnhywKqdggMEfbCpvkRfRiVCxA(int P_0)
					{
						sGHMPyNuAeHQfkMAuHsjijQYuQTC = P_0;
						oKOcmOdNgwqsSaOYihLABNyorbEqb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sGHMPyNuAeHQfkMAuHsjijQYuQTC;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								HWQRspfbMxjvBQXOnTGViBtGYEvF();
							}
						}
						zyuDsMgGlFpjljxyidExOkWKCiMM = null;
						sGHMPyNuAeHQfkMAuHsjijQYuQTC = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = sGHMPyNuAeHQfkMAuHsjijQYuQTC;
							ConflictCheckingHelper conflictCheckingHelper = igYcFqdMgAbJZgHwnnVVjiPnOUfUA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								sGHMPyNuAeHQfkMAuHsjijQYuQTC = -3;
								goto IL_00f1;
							}
							sGHMPyNuAeHQfkMAuHsjijQYuQTC = -1;
							if (dRiWOeanRfRPjVSSmCJbSHTjibTR < 0 || sTBisXqfsDGMFAaHjFTPiTxUDqLWA == null)
							{
								return false;
							}
							djSKQQUdtkVxKqjZOqLphCdxBhRk = 0;
							goto IL_011d;
							IL_00f1:
							if (zyuDsMgGlFpjljxyidExOkWKCiMM.MoveNext())
							{
								ElementAssignmentConflictInfo current = zyuDsMgGlFpjljxyidExOkWKCiMM.Current;
								vmmcxzCVhYsWvmWIsYjgncvAZxUGA = current;
								sGHMPyNuAeHQfkMAuHsjijQYuQTC = 1;
								return true;
							}
							HWQRspfbMxjvBQXOnTGViBtGYEvF();
							zyuDsMgGlFpjljxyidExOkWKCiMM = null;
							goto IL_010b;
							IL_011d:
							if (djSKQQUdtkVxKqjZOqLphCdxBhRk < conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv())
							{
								if (conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(djSKQQUdtkVxKqjZOqLphCdxBhRk).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == dRiWOeanRfRPjVSSmCJbSHTjibTR)
								{
									zyuDsMgGlFpjljxyidExOkWKCiMM = conflictCheckingHelper.UcOEzoDGtkIwfAtochhdQuUJLbTp(ControllerType.Custom, dRiWOeanRfRPjVSSmCJbSHTjibTR, ZmFaNcGbAsbmMhQKBoYURjFFOJgfc, sTBisXqfsDGMFAaHjFTPiTxUDqLWA, AAnJPysoaWzfClLgIlSjAwuTWUGH, vFpAmfUwtWPsGNNIxULNrTyYpRPk, conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(djSKQQUdtkVxKqjZOqLphCdxBhRk).ZfxPjujFGUgoCbyzcaKfutLOglBy).GetEnumerator();
									sGHMPyNuAeHQfkMAuHsjijQYuQTC = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							djSKQQUdtkVxKqjZOqLphCdxBhRk++;
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

					private void HWQRspfbMxjvBQXOnTGViBtGYEvF()
					{
						sGHMPyNuAeHQfkMAuHsjijQYuQTC = -1;
						if (zyuDsMgGlFpjljxyidExOkWKCiMM != null)
						{
							zyuDsMgGlFpjljxyidExOkWKCiMM.Dispose();
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
						fwYBnhywKqdggMEfbCpvkRfRiVCxA fwYBnhywKqdggMEfbCpvkRfRiVCxA2;
						if (sGHMPyNuAeHQfkMAuHsjijQYuQTC == -2 && oKOcmOdNgwqsSaOYihLABNyorbEqb == Environment.CurrentManagedThreadId)
						{
							sGHMPyNuAeHQfkMAuHsjijQYuQTC = 0;
							fwYBnhywKqdggMEfbCpvkRfRiVCxA2 = this;
						}
						else
						{
							fwYBnhywKqdggMEfbCpvkRfRiVCxA2 = new fwYBnhywKqdggMEfbCpvkRfRiVCxA(0);
							fwYBnhywKqdggMEfbCpvkRfRiVCxA2.igYcFqdMgAbJZgHwnnVVjiPnOUfUA = igYcFqdMgAbJZgHwnnVVjiPnOUfUA;
						}
						fwYBnhywKqdggMEfbCpvkRfRiVCxA2.dRiWOeanRfRPjVSSmCJbSHTjibTR = uEuazMKUwiKSKLYuFRsyGDttouCi;
						fwYBnhywKqdggMEfbCpvkRfRiVCxA2.ZmFaNcGbAsbmMhQKBoYURjFFOJgfc = BeNeIVLqpmqgbYmsfpEiLpoqeCjEA;
						fwYBnhywKqdggMEfbCpvkRfRiVCxA2.sTBisXqfsDGMFAaHjFTPiTxUDqLWA = JQkFyiGBnJOjFHqREfZuflETbGksB;
						fwYBnhywKqdggMEfbCpvkRfRiVCxA2.AAnJPysoaWzfClLgIlSjAwuTWUGH = RUCgpImzCdvHvSTxltXHJYvcjTov;
						fwYBnhywKqdggMEfbCpvkRfRiVCxA2.vFpAmfUwtWPsGNNIxULNrTyYpRPk = ESsPLuGOnPZqjdDBXyexwDcaFEGw;
						return fwYBnhywKqdggMEfbCpvkRfRiVCxA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class bFfeHhkpvyqWQmSoNWEPpyJeUtyW : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int QxuDJZhCUMMIvnAOxBDkltEmogNE;

					private ElementAssignmentConflictInfo zusaqZGekYOpadtbECcYVaBOgbqK;

					private int fkYzasrGglDHjnVUHqDQFjYtWTZJ;

					private ElementAssignmentConflictCheck GHkDoDUsczHoKwEvCQgTnhxEHeIE;

					public ElementAssignmentConflictCheck ODgwDrDbmDDsfFSRjtJJkMrNTkWOA;

					public ConflictCheckingHelper bByBbWkzoDzbNUUPGohshnuHqlUEA;

					private bool tAITYgbwcWbahLDWTmcTwEHXupNd;

					public bool EyCpLBMNSUQXfrgsMiCXRGBqIDGHA;

					private bool EOwcfKfoRiUodfJOyPrXZJGXMDrN;

					public bool JEowUGcDGfAmHiAlKKLABRSvXmmc;

					private int CGdtRwYiHRpUxhxaicXzOZyttXiR;

					private IEnumerator<ElementAssignmentConflictInfo> MSyDhdhCONjglENDIiDxKgeNLNcGb;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zusaqZGekYOpadtbECcYVaBOgbqK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zusaqZGekYOpadtbECcYVaBOgbqK;
						}
					}

					[DebuggerHidden]
					public bFfeHhkpvyqWQmSoNWEPpyJeUtyW(int P_0)
					{
						QxuDJZhCUMMIvnAOxBDkltEmogNE = P_0;
						fkYzasrGglDHjnVUHqDQFjYtWTZJ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int qxuDJZhCUMMIvnAOxBDkltEmogNE = QxuDJZhCUMMIvnAOxBDkltEmogNE;
						if (qxuDJZhCUMMIvnAOxBDkltEmogNE == -3 || qxuDJZhCUMMIvnAOxBDkltEmogNE == 1)
						{
							try
							{
							}
							finally
							{
								SrIxkPXiZlGKvHSMLtILsFRuqaCm();
							}
						}
						MSyDhdhCONjglENDIiDxKgeNLNcGb = null;
						QxuDJZhCUMMIvnAOxBDkltEmogNE = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int qxuDJZhCUMMIvnAOxBDkltEmogNE = QxuDJZhCUMMIvnAOxBDkltEmogNE;
							ConflictCheckingHelper conflictCheckingHelper = bByBbWkzoDzbNUUPGohshnuHqlUEA;
							if (qxuDJZhCUMMIvnAOxBDkltEmogNE != 0)
							{
								if (qxuDJZhCUMMIvnAOxBDkltEmogNE != 1)
								{
									return false;
								}
								QxuDJZhCUMMIvnAOxBDkltEmogNE = -3;
								goto IL_00f3;
							}
							QxuDJZhCUMMIvnAOxBDkltEmogNE = -1;
							if (GHkDoDUsczHoKwEvCQgTnhxEHeIE.controllerId < 0 || GHkDoDUsczHoKwEvCQgTnhxEHeIE.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							CGdtRwYiHRpUxhxaicXzOZyttXiR = 0;
							goto IL_011f;
							IL_00f3:
							if (MSyDhdhCONjglENDIiDxKgeNLNcGb.MoveNext())
							{
								ElementAssignmentConflictInfo current = MSyDhdhCONjglENDIiDxKgeNLNcGb.Current;
								zusaqZGekYOpadtbECcYVaBOgbqK = current;
								QxuDJZhCUMMIvnAOxBDkltEmogNE = 1;
								return true;
							}
							SrIxkPXiZlGKvHSMLtILsFRuqaCm();
							MSyDhdhCONjglENDIiDxKgeNLNcGb = null;
							goto IL_010d;
							IL_011f:
							if (CGdtRwYiHRpUxhxaicXzOZyttXiR < conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv())
							{
								if (conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(CGdtRwYiHRpUxhxaicXzOZyttXiR).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == GHkDoDUsczHoKwEvCQgTnhxEHeIE.controllerId)
								{
									MSyDhdhCONjglENDIiDxKgeNLNcGb = conflictCheckingHelper.pBqGBliUqBpNcjmlfvvWDJvSCqdeB(GHkDoDUsczHoKwEvCQgTnhxEHeIE, tAITYgbwcWbahLDWTmcTwEHXupNd, EOwcfKfoRiUodfJOyPrXZJGXMDrN, conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(CGdtRwYiHRpUxhxaicXzOZyttXiR).ZfxPjujFGUgoCbyzcaKfutLOglBy).GetEnumerator();
									QxuDJZhCUMMIvnAOxBDkltEmogNE = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							CGdtRwYiHRpUxhxaicXzOZyttXiR++;
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

					private void SrIxkPXiZlGKvHSMLtILsFRuqaCm()
					{
						QxuDJZhCUMMIvnAOxBDkltEmogNE = -1;
						if (MSyDhdhCONjglENDIiDxKgeNLNcGb != null)
						{
							MSyDhdhCONjglENDIiDxKgeNLNcGb.Dispose();
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
						bFfeHhkpvyqWQmSoNWEPpyJeUtyW bFfeHhkpvyqWQmSoNWEPpyJeUtyW2;
						if (QxuDJZhCUMMIvnAOxBDkltEmogNE == -2 && fkYzasrGglDHjnVUHqDQFjYtWTZJ == Environment.CurrentManagedThreadId)
						{
							QxuDJZhCUMMIvnAOxBDkltEmogNE = 0;
							bFfeHhkpvyqWQmSoNWEPpyJeUtyW2 = this;
						}
						else
						{
							bFfeHhkpvyqWQmSoNWEPpyJeUtyW2 = new bFfeHhkpvyqWQmSoNWEPpyJeUtyW(0);
							bFfeHhkpvyqWQmSoNWEPpyJeUtyW2.bByBbWkzoDzbNUUPGohshnuHqlUEA = bByBbWkzoDzbNUUPGohshnuHqlUEA;
						}
						bFfeHhkpvyqWQmSoNWEPpyJeUtyW2.GHkDoDUsczHoKwEvCQgTnhxEHeIE = ODgwDrDbmDDsfFSRjtJJkMrNTkWOA;
						bFfeHhkpvyqWQmSoNWEPpyJeUtyW2.tAITYgbwcWbahLDWTmcTwEHXupNd = EyCpLBMNSUQXfrgsMiCXRGBqIDGHA;
						bFfeHhkpvyqWQmSoNWEPpyJeUtyW2.EOwcfKfoRiUodfJOyPrXZJGXMDrN = JEowUGcDGfAmHiAlKKLABRSvXmmc;
						return bFfeHhkpvyqWQmSoNWEPpyJeUtyW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QPRNFQzkSVcNwcPuMDJMlqTwlIngA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int bPJAYmJBclVCtIQPREkNQKEQfUugA;

					private ElementAssignmentConflictInfo kWYELGifNvGrYUyHmfkXaOKheYLn;

					private int IWfMckvrIyCvuNfwjrFVLBCLzGVN;

					private global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> kKGinzbVXsMcdscQflmrQakVTFKh;

					public global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> HqplPUrPRfcDGcVfQhilHTZhnirvA;

					private _0001 JADFfyXjFXUKYccNMtVdsyWYliPq;

					public _0001 gPJVbdVzwPpjFErSTKoURHgxYWSq;

					private bool lBXXeODxzhlmOxIFdfJyJyNIszTA;

					public bool XPjQDNjClIFRSXLIrpIJvCARHShg;

					private bool emdFzmxIEFwNgpxIjrEzWcsYDKjD;

					public bool OXqJRfvUIGxSpXhBTrqKFTyUbcib;

					public ConflictCheckingHelper mjAbsQXrCaFHRWzCNPjsWirTFLRn;

					private ControllerType LZxKLMwMTQRDXfnlaAQZbExMgmAl;

					public ControllerType GbXRytjdtjKvsiYmKVdCXvBEVHoF;

					private int qjvnDWSSsltEfgLgrilzyXIxWNBF;

					public int fYCXLRVJCHMqRDOKoWUrVweqSjPw;

					private InputMapCategory eBnrvREiYLkZtvaXegpnxwZSCxeAA;

					private int KqugdCMgOlhDkenZZjEtWWckrcCjA;

					private IEnumerator<ElementAssignmentConflictInfo> dgcHgLjFZRkidkGDHoQzJYWNMNiI;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kWYELGifNvGrYUyHmfkXaOKheYLn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kWYELGifNvGrYUyHmfkXaOKheYLn;
						}
					}

					[DebuggerHidden]
					public QPRNFQzkSVcNwcPuMDJMlqTwlIngA(int P_0)
					{
						bPJAYmJBclVCtIQPREkNQKEQfUugA = P_0;
						IWfMckvrIyCvuNfwjrFVLBCLzGVN = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bPJAYmJBclVCtIQPREkNQKEQfUugA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								TMvjueARLmggOJakGMdefabEgVcfb();
							}
						}
						eBnrvREiYLkZtvaXegpnxwZSCxeAA = null;
						dgcHgLjFZRkidkGDHoQzJYWNMNiI = null;
						bPJAYmJBclVCtIQPREkNQKEQfUugA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bPJAYmJBclVCtIQPREkNQKEQfUugA;
							ConflictCheckingHelper conflictCheckingHelper = mjAbsQXrCaFHRWzCNPjsWirTFLRn;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bPJAYmJBclVCtIQPREkNQKEQfUugA = -3;
								goto IL_014a;
							}
							bPJAYmJBclVCtIQPREkNQKEQfUugA = -1;
							if (kKGinzbVXsMcdscQflmrQakVTFKh == null || JADFfyXjFXUKYccNMtVdsyWYliPq == null)
							{
								return false;
							}
							eBnrvREiYLkZtvaXegpnxwZSCxeAA = ReInput.mapping.GetMapCategory(JADFfyXjFXUKYccNMtVdsyWYliPq.categoryId);
							if (eBnrvREiYLkZtvaXegpnxwZSCxeAA == null)
							{
								return false;
							}
							KqugdCMgOlhDkenZZjEtWWckrcCjA = 0;
							goto IL_0176;
							IL_0176:
							if (KqugdCMgOlhDkenZZjEtWWckrcCjA < kKGinzbVXsMcdscQflmrQakVTFKh.PHddzgndMnzRWWZdLPxBNVqdUdeV())
							{
								ControllerMap controllerMap = kKGinzbVXsMcdscQflmrQakVTFKh.SypULfmhiRJaajsxCpMqFoMTkKpm(KqugdCMgOlhDkenZZjEtWWckrcCjA);
								if ((!lBXXeODxzhlmOxIFdfJyJyNIszTA || controllerMap.enabled) && (emdFzmxIEFwNgpxIjrEzWcsYDKjD || !conflictCheckingHelper.SLfcMiaLExLjpOHgQzOSRCRJUyun(eBnrvREiYLkZtvaXegpnxwZSCxeAA, controllerMap)))
								{
									dgcHgLjFZRkidkGDHoQzJYWNMNiI = controllerMap.ElementAssignmentConflicts(JADFfyXjFXUKYccNMtVdsyWYliPq, lBXXeODxzhlmOxIFdfJyJyNIszTA).GetEnumerator();
									bPJAYmJBclVCtIQPREkNQKEQfUugA = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (dgcHgLjFZRkidkGDHoQzJYWNMNiI.MoveNext())
							{
								ElementAssignmentConflictInfo current = dgcHgLjFZRkidkGDHoQzJYWNMNiI.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.orVjZWDAGzIyrFrEcbEjXUZHCpSHA.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								elementAssignmentConflictInfo.controllerType = LZxKLMwMTQRDXfnlaAQZbExMgmAl;
								elementAssignmentConflictInfo.controllerId = qjvnDWSSsltEfgLgrilzyXIxWNBF;
								kWYELGifNvGrYUyHmfkXaOKheYLn = elementAssignmentConflictInfo;
								bPJAYmJBclVCtIQPREkNQKEQfUugA = 1;
								return true;
							}
							TMvjueARLmggOJakGMdefabEgVcfb();
							dgcHgLjFZRkidkGDHoQzJYWNMNiI = null;
							goto IL_0164;
							IL_0164:
							KqugdCMgOlhDkenZZjEtWWckrcCjA++;
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

					private void TMvjueARLmggOJakGMdefabEgVcfb()
					{
						bPJAYmJBclVCtIQPREkNQKEQfUugA = -1;
						if (dgcHgLjFZRkidkGDHoQzJYWNMNiI != null)
						{
							dgcHgLjFZRkidkGDHoQzJYWNMNiI.Dispose();
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
						QPRNFQzkSVcNwcPuMDJMlqTwlIngA<_0001> qPRNFQzkSVcNwcPuMDJMlqTwlIngA;
						if (bPJAYmJBclVCtIQPREkNQKEQfUugA == -2 && IWfMckvrIyCvuNfwjrFVLBCLzGVN == Environment.CurrentManagedThreadId)
						{
							bPJAYmJBclVCtIQPREkNQKEQfUugA = 0;
							qPRNFQzkSVcNwcPuMDJMlqTwlIngA = this;
						}
						else
						{
							qPRNFQzkSVcNwcPuMDJMlqTwlIngA = new QPRNFQzkSVcNwcPuMDJMlqTwlIngA<_0001>(0);
							qPRNFQzkSVcNwcPuMDJMlqTwlIngA.mjAbsQXrCaFHRWzCNPjsWirTFLRn = mjAbsQXrCaFHRWzCNPjsWirTFLRn;
						}
						qPRNFQzkSVcNwcPuMDJMlqTwlIngA.LZxKLMwMTQRDXfnlaAQZbExMgmAl = GbXRytjdtjKvsiYmKVdCXvBEVHoF;
						qPRNFQzkSVcNwcPuMDJMlqTwlIngA.qjvnDWSSsltEfgLgrilzyXIxWNBF = fYCXLRVJCHMqRDOKoWUrVweqSjPw;
						qPRNFQzkSVcNwcPuMDJMlqTwlIngA.JADFfyXjFXUKYccNMtVdsyWYliPq = gPJVbdVzwPpjFErSTKoURHgxYWSq;
						qPRNFQzkSVcNwcPuMDJMlqTwlIngA.lBXXeODxzhlmOxIFdfJyJyNIszTA = XPjQDNjClIFRSXLIrpIJvCARHShg;
						qPRNFQzkSVcNwcPuMDJMlqTwlIngA.emdFzmxIEFwNgpxIjrEzWcsYDKjD = OXqJRfvUIGxSpXhBTrqKFTyUbcib;
						qPRNFQzkSVcNwcPuMDJMlqTwlIngA.kKGinzbVXsMcdscQflmrQakVTFKh = HqplPUrPRfcDGcVfQhilHTZhnirvA;
						return qPRNFQzkSVcNwcPuMDJMlqTwlIngA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ziNSguvyUrsbPYbIFrLpLuMcolNK<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int EhcZKnkkLvZSnXMConlhofnrEXSR;

					private ElementAssignmentConflictInfo DddirIaVLAwYADEOyatSJPGKhCwPA;

					private int IKlIPSPkZEjZMKVsQUMKaGTlAcZd;

					private global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> oPfsVamMGVhuHbxLzsqYgWDlHATrA;

					public global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> ltENOAHKcdBglFrHhoEnFGFKYhpxA;

					private ActionElementMap KgOnVrpteLvmFPuMINAMTqrcZuyW;

					public ActionElementMap sriFPVXgRGYzPwgzxrWtGqbEiMeB;

					private _0001 cZmCzBniCYlrbarlrhqehRfGESpE;

					public _0001 kfmmbNwStrryLYOFUTxZRPbJwkUA;

					private bool rvdEDmOGsrbyrdJKLucjTNdCzXlX;

					public bool QfKBhrGnEfhUdYfJGxTUgQjcaVIrA;

					private bool vLwkFmaHvDeiddOJBNiZofVcQigFA;

					public bool tHHsqQqtzHtFganhsrrYLOfVGyMf;

					public ConflictCheckingHelper LRlqCESnvVdnuKQeebqzeKrClyHFB;

					private ControllerType xKSGzzaogHJwtHodiOgnKPIRSlERA;

					public ControllerType JWsYrtzkLrTaLoCpKjQuUJMZIevcA;

					private int CTzhtpXwIdKyJJqljdGcrhDbfPAiA;

					public int DwJEgOeUSOMuesqfkAcoylRxoSoaA;

					private InputMapCategory azscRESFkExkXXQnXJRojpNZGqvP;

					private int zgHhwnpooMMURIDwDFglsKiEYZic;

					private IEnumerator<ElementAssignmentConflictInfo> fwRGcqAOsYvIJNLLHCUNzspbQlkeA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DddirIaVLAwYADEOyatSJPGKhCwPA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DddirIaVLAwYADEOyatSJPGKhCwPA;
						}
					}

					[DebuggerHidden]
					public ziNSguvyUrsbPYbIFrLpLuMcolNK(int P_0)
					{
						EhcZKnkkLvZSnXMConlhofnrEXSR = P_0;
						IKlIPSPkZEjZMKVsQUMKaGTlAcZd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ehcZKnkkLvZSnXMConlhofnrEXSR = EhcZKnkkLvZSnXMConlhofnrEXSR;
						if (ehcZKnkkLvZSnXMConlhofnrEXSR == -3 || ehcZKnkkLvZSnXMConlhofnrEXSR == 1)
						{
							try
							{
							}
							finally
							{
								haenXBuhcAzuUVnEIbzOEhYXyHFH();
							}
						}
						azscRESFkExkXXQnXJRojpNZGqvP = null;
						fwRGcqAOsYvIJNLLHCUNzspbQlkeA = null;
						EhcZKnkkLvZSnXMConlhofnrEXSR = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ehcZKnkkLvZSnXMConlhofnrEXSR = EhcZKnkkLvZSnXMConlhofnrEXSR;
							ConflictCheckingHelper lRlqCESnvVdnuKQeebqzeKrClyHFB = LRlqCESnvVdnuKQeebqzeKrClyHFB;
							if (ehcZKnkkLvZSnXMConlhofnrEXSR != 0)
							{
								if (ehcZKnkkLvZSnXMConlhofnrEXSR != 1)
								{
									return false;
								}
								EhcZKnkkLvZSnXMConlhofnrEXSR = -3;
								goto IL_0141;
							}
							EhcZKnkkLvZSnXMConlhofnrEXSR = -1;
							if (oPfsVamMGVhuHbxLzsqYgWDlHATrA == null || KgOnVrpteLvmFPuMINAMTqrcZuyW == null)
							{
								return false;
							}
							azscRESFkExkXXQnXJRojpNZGqvP = ((cZmCzBniCYlrbarlrhqehRfGESpE != null) ? ReInput.mapping.GetMapCategory(cZmCzBniCYlrbarlrhqehRfGESpE.categoryId) : null);
							zgHhwnpooMMURIDwDFglsKiEYZic = 0;
							goto IL_016d;
							IL_016d:
							if (zgHhwnpooMMURIDwDFglsKiEYZic < oPfsVamMGVhuHbxLzsqYgWDlHATrA.PHddzgndMnzRWWZdLPxBNVqdUdeV())
							{
								ControllerMap controllerMap = oPfsVamMGVhuHbxLzsqYgWDlHATrA.SypULfmhiRJaajsxCpMqFoMTkKpm(zgHhwnpooMMURIDwDFglsKiEYZic);
								if ((!rvdEDmOGsrbyrdJKLucjTNdCzXlX || controllerMap.enabled) && (vLwkFmaHvDeiddOJBNiZofVcQigFA || !lRlqCESnvVdnuKQeebqzeKrClyHFB.SLfcMiaLExLjpOHgQzOSRCRJUyun(azscRESFkExkXXQnXJRojpNZGqvP, controllerMap)))
								{
									fwRGcqAOsYvIJNLLHCUNzspbQlkeA = controllerMap.ElementAssignmentConflicts(KgOnVrpteLvmFPuMINAMTqrcZuyW, rvdEDmOGsrbyrdJKLucjTNdCzXlX).GetEnumerator();
									EhcZKnkkLvZSnXMConlhofnrEXSR = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							zgHhwnpooMMURIDwDFglsKiEYZic++;
							goto IL_016d;
							IL_0141:
							if (fwRGcqAOsYvIJNLLHCUNzspbQlkeA.MoveNext())
							{
								ElementAssignmentConflictInfo current = fwRGcqAOsYvIJNLLHCUNzspbQlkeA.Current;
								ElementAssignmentConflictInfo dddirIaVLAwYADEOyatSJPGKhCwPA = new ElementAssignmentConflictInfo(current);
								dddirIaVLAwYADEOyatSJPGKhCwPA.playerId = lRlqCESnvVdnuKQeebqzeKrClyHFB.orVjZWDAGzIyrFrEcbEjXUZHCpSHA.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								dddirIaVLAwYADEOyatSJPGKhCwPA.controllerType = xKSGzzaogHJwtHodiOgnKPIRSlERA;
								dddirIaVLAwYADEOyatSJPGKhCwPA.controllerId = CTzhtpXwIdKyJJqljdGcrhDbfPAiA;
								DddirIaVLAwYADEOyatSJPGKhCwPA = dddirIaVLAwYADEOyatSJPGKhCwPA;
								EhcZKnkkLvZSnXMConlhofnrEXSR = 1;
								return true;
							}
							haenXBuhcAzuUVnEIbzOEhYXyHFH();
							fwRGcqAOsYvIJNLLHCUNzspbQlkeA = null;
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

					private void haenXBuhcAzuUVnEIbzOEhYXyHFH()
					{
						EhcZKnkkLvZSnXMConlhofnrEXSR = -1;
						if (fwRGcqAOsYvIJNLLHCUNzspbQlkeA != null)
						{
							fwRGcqAOsYvIJNLLHCUNzspbQlkeA.Dispose();
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
						ziNSguvyUrsbPYbIFrLpLuMcolNK<_0001> ziNSguvyUrsbPYbIFrLpLuMcolNK2;
						if (EhcZKnkkLvZSnXMConlhofnrEXSR == -2 && IKlIPSPkZEjZMKVsQUMKaGTlAcZd == Environment.CurrentManagedThreadId)
						{
							EhcZKnkkLvZSnXMConlhofnrEXSR = 0;
							ziNSguvyUrsbPYbIFrLpLuMcolNK2 = this;
						}
						else
						{
							ziNSguvyUrsbPYbIFrLpLuMcolNK2 = new ziNSguvyUrsbPYbIFrLpLuMcolNK<_0001>(0);
							ziNSguvyUrsbPYbIFrLpLuMcolNK2.LRlqCESnvVdnuKQeebqzeKrClyHFB = LRlqCESnvVdnuKQeebqzeKrClyHFB;
						}
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.xKSGzzaogHJwtHodiOgnKPIRSlERA = JWsYrtzkLrTaLoCpKjQuUJMZIevcA;
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.CTzhtpXwIdKyJJqljdGcrhDbfPAiA = DwJEgOeUSOMuesqfkAcoylRxoSoaA;
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.cZmCzBniCYlrbarlrhqehRfGESpE = kfmmbNwStrryLYOFUTxZRPbJwkUA;
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.KgOnVrpteLvmFPuMINAMTqrcZuyW = sriFPVXgRGYzPwgzxrWtGqbEiMeB;
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.rvdEDmOGsrbyrdJKLucjTNdCzXlX = QfKBhrGnEfhUdYfJGxTUgQjcaVIrA;
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.vLwkFmaHvDeiddOJBNiZofVcQigFA = tHHsqQqtzHtFganhsrrYLOfVGyMf;
						ziNSguvyUrsbPYbIFrLpLuMcolNK2.oPfsVamMGVhuHbxLzsqYgWDlHATrA = ltENOAHKcdBglFrHhoEnFGFKYhpxA;
						return ziNSguvyUrsbPYbIFrLpLuMcolNK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class WkTluKsUpWhwIhBiHcaiGGutvDnt<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int qwlAHKLLOHQcXIjEGIGBcTMbXhLi;

					private ElementAssignmentConflictInfo PFrhdGHyiClHemFbBePndCSkdRjZ;

					private int PcTIaYTSGbDbpldpLeNMfuSFFXgM;

					private global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> WLbxKOpeAhCgAEKapKbPHFqjbEMJB;

					public global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> vIgLMmYgrbLTnfyFaHPimcbSfKYIA;

					private ElementAssignmentConflictCheck rBYjsHKkbADfcKjsURBJGsRWnpOHA;

					public ElementAssignmentConflictCheck lZjTRwwcjuuXABagtpIsmwAZlapW;

					private bool HWbxOPPwWKoNfEyhXrrupeUdkBHq;

					public bool IIarDdKyLPVOuyrdLbKGPYVnVHpD;

					private bool EihNQFoYRyhcvGBFgRupQbeeVCK;

					public bool yAaoaLYdghhcAtEwIoIyzQsgOUzI;

					public ConflictCheckingHelper CtOGWJAdKXpJFWkGfibVFffYHgrPA;

					private InputMapCategory lndjVfiEMEDMnjwyFhiQcWaWTdLT;

					private int jWPfBnjomNJznBJgkzFkMxTvNMlAA;

					private IEnumerator<ElementAssignmentConflictInfo> cbMbVZtzinkVyJtxgsGybtbSrdJw;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PFrhdGHyiClHemFbBePndCSkdRjZ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PFrhdGHyiClHemFbBePndCSkdRjZ;
						}
					}

					[DebuggerHidden]
					public WkTluKsUpWhwIhBiHcaiGGutvDnt(int P_0)
					{
						qwlAHKLLOHQcXIjEGIGBcTMbXhLi = P_0;
						PcTIaYTSGbDbpldpLeNMfuSFFXgM = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qwlAHKLLOHQcXIjEGIGBcTMbXhLi;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								VgdJSvEZoWKOlZWrliNQsXcgdvro();
							}
						}
						lndjVfiEMEDMnjwyFhiQcWaWTdLT = null;
						cbMbVZtzinkVyJtxgsGybtbSrdJw = null;
						qwlAHKLLOHQcXIjEGIGBcTMbXhLi = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = qwlAHKLLOHQcXIjEGIGBcTMbXhLi;
							ConflictCheckingHelper ctOGWJAdKXpJFWkGfibVFffYHgrPA = CtOGWJAdKXpJFWkGfibVFffYHgrPA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qwlAHKLLOHQcXIjEGIGBcTMbXhLi = -3;
								goto IL_01ab;
							}
							qwlAHKLLOHQcXIjEGIGBcTMbXhLi = -1;
							if (WLbxKOpeAhCgAEKapKbPHFqjbEMJB == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(rBYjsHKkbADfcKjsURBJGsRWnpOHA.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(rBYjsHKkbADfcKjsURBJGsRWnpOHA.controllerType, rBYjsHKkbADfcKjsURBJGsRWnpOHA.controllerId, rBYjsHKkbADfcKjsURBJGsRWnpOHA.controllerMapId);
							lndjVfiEMEDMnjwyFhiQcWaWTdLT = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(rBYjsHKkbADfcKjsURBJGsRWnpOHA.controllerMapCategoryId));
							if (lndjVfiEMEDMnjwyFhiQcWaWTdLT == null)
							{
								return false;
							}
							jWPfBnjomNJznBJgkzFkMxTvNMlAA = 0;
							goto IL_01d7;
							IL_01ab:
							if (cbMbVZtzinkVyJtxgsGybtbSrdJw.MoveNext())
							{
								ElementAssignmentConflictInfo current = cbMbVZtzinkVyJtxgsGybtbSrdJw.Current;
								ElementAssignmentConflictInfo pFrhdGHyiClHemFbBePndCSkdRjZ = new ElementAssignmentConflictInfo(current);
								pFrhdGHyiClHemFbBePndCSkdRjZ.playerId = ctOGWJAdKXpJFWkGfibVFffYHgrPA.orVjZWDAGzIyrFrEcbEjXUZHCpSHA.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								pFrhdGHyiClHemFbBePndCSkdRjZ.controllerType = rBYjsHKkbADfcKjsURBJGsRWnpOHA.controllerType;
								pFrhdGHyiClHemFbBePndCSkdRjZ.controllerId = rBYjsHKkbADfcKjsURBJGsRWnpOHA.controllerId;
								PFrhdGHyiClHemFbBePndCSkdRjZ = pFrhdGHyiClHemFbBePndCSkdRjZ;
								qwlAHKLLOHQcXIjEGIGBcTMbXhLi = 1;
								return true;
							}
							VgdJSvEZoWKOlZWrliNQsXcgdvro();
							cbMbVZtzinkVyJtxgsGybtbSrdJw = null;
							goto IL_01c5;
							IL_01d7:
							if (jWPfBnjomNJznBJgkzFkMxTvNMlAA < WLbxKOpeAhCgAEKapKbPHFqjbEMJB.PHddzgndMnzRWWZdLPxBNVqdUdeV())
							{
								ControllerMap controllerMap = WLbxKOpeAhCgAEKapKbPHFqjbEMJB.SypULfmhiRJaajsxCpMqFoMTkKpm(jWPfBnjomNJznBJgkzFkMxTvNMlAA);
								if ((!HWbxOPPwWKoNfEyhXrrupeUdkBHq || controllerMap.enabled) && (EihNQFoYRyhcvGBFgRupQbeeVCK || !ctOGWJAdKXpJFWkGfibVFffYHgrPA.SLfcMiaLExLjpOHgQzOSRCRJUyun(lndjVfiEMEDMnjwyFhiQcWaWTdLT, controllerMap)))
								{
									cbMbVZtzinkVyJtxgsGybtbSrdJw = controllerMap.ElementAssignmentConflicts(rBYjsHKkbADfcKjsURBJGsRWnpOHA, HWbxOPPwWKoNfEyhXrrupeUdkBHq).GetEnumerator();
									qwlAHKLLOHQcXIjEGIGBcTMbXhLi = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							jWPfBnjomNJznBJgkzFkMxTvNMlAA++;
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

					private void VgdJSvEZoWKOlZWrliNQsXcgdvro()
					{
						qwlAHKLLOHQcXIjEGIGBcTMbXhLi = -1;
						if (cbMbVZtzinkVyJtxgsGybtbSrdJw != null)
						{
							cbMbVZtzinkVyJtxgsGybtbSrdJw.Dispose();
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
						WkTluKsUpWhwIhBiHcaiGGutvDnt<_0001> wkTluKsUpWhwIhBiHcaiGGutvDnt;
						if (qwlAHKLLOHQcXIjEGIGBcTMbXhLi == -2 && PcTIaYTSGbDbpldpLeNMfuSFFXgM == Environment.CurrentManagedThreadId)
						{
							qwlAHKLLOHQcXIjEGIGBcTMbXhLi = 0;
							wkTluKsUpWhwIhBiHcaiGGutvDnt = this;
						}
						else
						{
							wkTluKsUpWhwIhBiHcaiGGutvDnt = new WkTluKsUpWhwIhBiHcaiGGutvDnt<_0001>(0);
							wkTluKsUpWhwIhBiHcaiGGutvDnt.CtOGWJAdKXpJFWkGfibVFffYHgrPA = CtOGWJAdKXpJFWkGfibVFffYHgrPA;
						}
						wkTluKsUpWhwIhBiHcaiGGutvDnt.rBYjsHKkbADfcKjsURBJGsRWnpOHA = lZjTRwwcjuuXABagtpIsmwAZlapW;
						wkTluKsUpWhwIhBiHcaiGGutvDnt.HWbxOPPwWKoNfEyhXrrupeUdkBHq = IIarDdKyLPVOuyrdLbKGPYVnVHpD;
						wkTluKsUpWhwIhBiHcaiGGutvDnt.EihNQFoYRyhcvGBFgRupQbeeVCK = yAaoaLYdghhcAtEwIoIyzQsgOUzI;
						wkTluKsUpWhwIhBiHcaiGGutvDnt.WLbxKOpeAhCgAEKapKbPHFqjbEMJB = vIgLMmYgrbLTnfyFaHPimcbSfKYIA;
						return wkTluKsUpWhwIhBiHcaiGGutvDnt;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class THufltjKutkOYyRSvdUMcscGLCagc : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int HrXIsChpZHuNUDekSuTuhcLRVgyP;

					private ElementAssignmentConflictInfo nnbbQUnHOBqlCTLLdLOCUyKQRGrL;

					private int JXreDorCGnIbuDGXvGzygvSnDiSGA;

					private int hybkYFMJzpEsDPHgeOHGRsJNLRXl;

					public int uOLCFRedpSlyKfzaERjcHegkIwDYb;

					private JoystickMap BzqlekqLZDklOWEtkkGTxEckWXCl;

					public JoystickMap hLnhQswumpXGJIZIFProXFKJJDBo;

					public ConflictCheckingHelper GWhAnmfGXSVSIukqMIGkwxAUMFvi;

					private bool yYISHNTNVfOZvyjmhseZYRhEhVvQ;

					public bool QjVfCaAJxTzYHrEbpiamzWKLZbhv;

					private bool nyvWZSBszsVcZaNkjOPlxYuGPJYD;

					public bool HAUdRFGgPsceSiJTdYTQEWORuZeI;

					private int pAiIoWhiLlvKEmovSxgFFoTYClmg;

					private IEnumerator<ElementAssignmentConflictInfo> qzmaUrfIGGTrgvRhdtwAQVskOHHjb;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return nnbbQUnHOBqlCTLLdLOCUyKQRGrL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nnbbQUnHOBqlCTLLdLOCUyKQRGrL;
						}
					}

					[DebuggerHidden]
					public THufltjKutkOYyRSvdUMcscGLCagc(int P_0)
					{
						HrXIsChpZHuNUDekSuTuhcLRVgyP = P_0;
						JXreDorCGnIbuDGXvGzygvSnDiSGA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hrXIsChpZHuNUDekSuTuhcLRVgyP = HrXIsChpZHuNUDekSuTuhcLRVgyP;
						if (hrXIsChpZHuNUDekSuTuhcLRVgyP == -3 || hrXIsChpZHuNUDekSuTuhcLRVgyP == 1)
						{
							try
							{
							}
							finally
							{
								ONtfhGGuaXwjqXLVDEMBArSHLDrFb();
							}
						}
						qzmaUrfIGGTrgvRhdtwAQVskOHHjb = null;
						HrXIsChpZHuNUDekSuTuhcLRVgyP = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hrXIsChpZHuNUDekSuTuhcLRVgyP = HrXIsChpZHuNUDekSuTuhcLRVgyP;
							ConflictCheckingHelper gWhAnmfGXSVSIukqMIGkwxAUMFvi = GWhAnmfGXSVSIukqMIGkwxAUMFvi;
							if (hrXIsChpZHuNUDekSuTuhcLRVgyP != 0)
							{
								if (hrXIsChpZHuNUDekSuTuhcLRVgyP != 1)
								{
									return false;
								}
								HrXIsChpZHuNUDekSuTuhcLRVgyP = -3;
								goto IL_00ea;
							}
							HrXIsChpZHuNUDekSuTuhcLRVgyP = -1;
							if (hybkYFMJzpEsDPHgeOHGRsJNLRXl < 0 || BzqlekqLZDklOWEtkkGTxEckWXCl == null)
							{
								return false;
							}
							pAiIoWhiLlvKEmovSxgFFoTYClmg = 0;
							goto IL_0116;
							IL_00ea:
							if (qzmaUrfIGGTrgvRhdtwAQVskOHHjb.MoveNext())
							{
								ElementAssignmentConflictInfo current = qzmaUrfIGGTrgvRhdtwAQVskOHHjb.Current;
								nnbbQUnHOBqlCTLLdLOCUyKQRGrL = current;
								HrXIsChpZHuNUDekSuTuhcLRVgyP = 1;
								return true;
							}
							ONtfhGGuaXwjqXLVDEMBArSHLDrFb();
							qzmaUrfIGGTrgvRhdtwAQVskOHHjb = null;
							goto IL_0104;
							IL_0116:
							if (pAiIoWhiLlvKEmovSxgFFoTYClmg < gWhAnmfGXSVSIukqMIGkwxAUMFvi.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv())
							{
								if (gWhAnmfGXSVSIukqMIGkwxAUMFvi.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(pAiIoWhiLlvKEmovSxgFFoTYClmg).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == hybkYFMJzpEsDPHgeOHGRsJNLRXl)
								{
									qzmaUrfIGGTrgvRhdtwAQVskOHHjb = gWhAnmfGXSVSIukqMIGkwxAUMFvi.kBTUZmcyGFAiVnTqgkCgKTsNAVLH(ControllerType.Joystick, hybkYFMJzpEsDPHgeOHGRsJNLRXl, BzqlekqLZDklOWEtkkGTxEckWXCl, yYISHNTNVfOZvyjmhseZYRhEhVvQ, nyvWZSBszsVcZaNkjOPlxYuGPJYD, gWhAnmfGXSVSIukqMIGkwxAUMFvi.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(pAiIoWhiLlvKEmovSxgFFoTYClmg).ZfxPjujFGUgoCbyzcaKfutLOglBy).GetEnumerator();
									HrXIsChpZHuNUDekSuTuhcLRVgyP = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							pAiIoWhiLlvKEmovSxgFFoTYClmg++;
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

					private void ONtfhGGuaXwjqXLVDEMBArSHLDrFb()
					{
						HrXIsChpZHuNUDekSuTuhcLRVgyP = -1;
						if (qzmaUrfIGGTrgvRhdtwAQVskOHHjb != null)
						{
							qzmaUrfIGGTrgvRhdtwAQVskOHHjb.Dispose();
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
						THufltjKutkOYyRSvdUMcscGLCagc tHufltjKutkOYyRSvdUMcscGLCagc;
						if (HrXIsChpZHuNUDekSuTuhcLRVgyP == -2 && JXreDorCGnIbuDGXvGzygvSnDiSGA == Environment.CurrentManagedThreadId)
						{
							HrXIsChpZHuNUDekSuTuhcLRVgyP = 0;
							tHufltjKutkOYyRSvdUMcscGLCagc = this;
						}
						else
						{
							tHufltjKutkOYyRSvdUMcscGLCagc = new THufltjKutkOYyRSvdUMcscGLCagc(0);
							tHufltjKutkOYyRSvdUMcscGLCagc.GWhAnmfGXSVSIukqMIGkwxAUMFvi = GWhAnmfGXSVSIukqMIGkwxAUMFvi;
						}
						tHufltjKutkOYyRSvdUMcscGLCagc.hybkYFMJzpEsDPHgeOHGRsJNLRXl = uOLCFRedpSlyKfzaERjcHegkIwDYb;
						tHufltjKutkOYyRSvdUMcscGLCagc.BzqlekqLZDklOWEtkkGTxEckWXCl = hLnhQswumpXGJIZIFProXFKJJDBo;
						tHufltjKutkOYyRSvdUMcscGLCagc.yYISHNTNVfOZvyjmhseZYRhEhVvQ = QjVfCaAJxTzYHrEbpiamzWKLZbhv;
						tHufltjKutkOYyRSvdUMcscGLCagc.nyvWZSBszsVcZaNkjOPlxYuGPJYD = HAUdRFGgPsceSiJTdYTQEWORuZeI;
						return tHufltjKutkOYyRSvdUMcscGLCagc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class PaERIcPqHDKtjEYjmrihrIuXjjoR : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int hThkcQNIDNAHOemyCMLMWAqcXcqj;

					private ElementAssignmentConflictInfo kJRWcPqkzwJNCypmRgcaDDRekTFQ;

					private int WyHwtDVCxjjwaqPqWgmoILZXrzvC;

					private int ckAtBjFqNFnilGsogEvpuGPklAjS;

					public int IZHjKghMpAFzkSUszcoVdvkEnRqfb;

					private ActionElementMap YuYUXiLLgclnFDOXEJothYSxMGoX;

					public ActionElementMap yzQtrYVswuHbAnchPTgOJdMIVekP;

					public ConflictCheckingHelper tWmeKpXvUyqqUFLnxcElCJAQWxyGA;

					private JoystickMap WsTboPJnVDIJCTliSQNaayxtFBedA;

					public JoystickMap oeYkMSjKJaynPRigLAZDcpcztmbb;

					private bool FriuuXkbdowVpojQpgGIkEPboLEIA;

					public bool sgxeKboaXCEmQIBkiXyqOKeICsgH;

					private bool lGtANvHCLRwmDYcznUOnnDShSlzV;

					public bool zJeOjcPGkhYoIpZcYDXleEKMYCCB;

					private int WYothnDvrILaKkTHmLwcTJTHRqhL;

					private IEnumerator<ElementAssignmentConflictInfo> SktgkhhLqxhCYySIIRrsWeGrprpB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kJRWcPqkzwJNCypmRgcaDDRekTFQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kJRWcPqkzwJNCypmRgcaDDRekTFQ;
						}
					}

					[DebuggerHidden]
					public PaERIcPqHDKtjEYjmrihrIuXjjoR(int P_0)
					{
						hThkcQNIDNAHOemyCMLMWAqcXcqj = P_0;
						WyHwtDVCxjjwaqPqWgmoILZXrzvC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hThkcQNIDNAHOemyCMLMWAqcXcqj;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								GrnJjLYTGptpivYqugEgRJMmdDeC();
							}
						}
						SktgkhhLqxhCYySIIRrsWeGrprpB = null;
						hThkcQNIDNAHOemyCMLMWAqcXcqj = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hThkcQNIDNAHOemyCMLMWAqcXcqj;
							ConflictCheckingHelper conflictCheckingHelper = tWmeKpXvUyqqUFLnxcElCJAQWxyGA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hThkcQNIDNAHOemyCMLMWAqcXcqj = -3;
								goto IL_00f0;
							}
							hThkcQNIDNAHOemyCMLMWAqcXcqj = -1;
							if (ckAtBjFqNFnilGsogEvpuGPklAjS < 0 || YuYUXiLLgclnFDOXEJothYSxMGoX == null)
							{
								return false;
							}
							WYothnDvrILaKkTHmLwcTJTHRqhL = 0;
							goto IL_011c;
							IL_00f0:
							if (SktgkhhLqxhCYySIIRrsWeGrprpB.MoveNext())
							{
								ElementAssignmentConflictInfo current = SktgkhhLqxhCYySIIRrsWeGrprpB.Current;
								kJRWcPqkzwJNCypmRgcaDDRekTFQ = current;
								hThkcQNIDNAHOemyCMLMWAqcXcqj = 1;
								return true;
							}
							GrnJjLYTGptpivYqugEgRJMmdDeC();
							SktgkhhLqxhCYySIIRrsWeGrprpB = null;
							goto IL_010a;
							IL_011c:
							if (WYothnDvrILaKkTHmLwcTJTHRqhL < conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv())
							{
								if (conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(WYothnDvrILaKkTHmLwcTJTHRqhL).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == ckAtBjFqNFnilGsogEvpuGPklAjS)
								{
									SktgkhhLqxhCYySIIRrsWeGrprpB = conflictCheckingHelper.UcOEzoDGtkIwfAtochhdQuUJLbTp(ControllerType.Joystick, ckAtBjFqNFnilGsogEvpuGPklAjS, WsTboPJnVDIJCTliSQNaayxtFBedA, YuYUXiLLgclnFDOXEJothYSxMGoX, FriuuXkbdowVpojQpgGIkEPboLEIA, lGtANvHCLRwmDYcznUOnnDShSlzV, conflictCheckingHelper.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(WYothnDvrILaKkTHmLwcTJTHRqhL).ZfxPjujFGUgoCbyzcaKfutLOglBy).GetEnumerator();
									hThkcQNIDNAHOemyCMLMWAqcXcqj = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							WYothnDvrILaKkTHmLwcTJTHRqhL++;
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

					private void GrnJjLYTGptpivYqugEgRJMmdDeC()
					{
						hThkcQNIDNAHOemyCMLMWAqcXcqj = -1;
						if (SktgkhhLqxhCYySIIRrsWeGrprpB != null)
						{
							SktgkhhLqxhCYySIIRrsWeGrprpB.Dispose();
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
						PaERIcPqHDKtjEYjmrihrIuXjjoR paERIcPqHDKtjEYjmrihrIuXjjoR;
						if (hThkcQNIDNAHOemyCMLMWAqcXcqj == -2 && WyHwtDVCxjjwaqPqWgmoILZXrzvC == Environment.CurrentManagedThreadId)
						{
							hThkcQNIDNAHOemyCMLMWAqcXcqj = 0;
							paERIcPqHDKtjEYjmrihrIuXjjoR = this;
						}
						else
						{
							paERIcPqHDKtjEYjmrihrIuXjjoR = new PaERIcPqHDKtjEYjmrihrIuXjjoR(0);
							paERIcPqHDKtjEYjmrihrIuXjjoR.tWmeKpXvUyqqUFLnxcElCJAQWxyGA = tWmeKpXvUyqqUFLnxcElCJAQWxyGA;
						}
						paERIcPqHDKtjEYjmrihrIuXjjoR.ckAtBjFqNFnilGsogEvpuGPklAjS = IZHjKghMpAFzkSUszcoVdvkEnRqfb;
						paERIcPqHDKtjEYjmrihrIuXjjoR.WsTboPJnVDIJCTliSQNaayxtFBedA = oeYkMSjKJaynPRigLAZDcpcztmbb;
						paERIcPqHDKtjEYjmrihrIuXjjoR.YuYUXiLLgclnFDOXEJothYSxMGoX = yzQtrYVswuHbAnchPTgOJdMIVekP;
						paERIcPqHDKtjEYjmrihrIuXjjoR.FriuuXkbdowVpojQpgGIkEPboLEIA = sgxeKboaXCEmQIBkiXyqOKeICsgH;
						paERIcPqHDKtjEYjmrihrIuXjjoR.lGtANvHCLRwmDYcznUOnnDShSlzV = zJeOjcPGkhYoIpZcYDXleEKMYCCB;
						return paERIcPqHDKtjEYjmrihrIuXjjoR;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ATqhtwJEbQMtsNHChMjEjmvPnnum : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int wikDnUkQhfeikgIZUotfQmtiqzkM;

					private ElementAssignmentConflictInfo hBIiSwdcvmigGBKjojPETxUGnFhv;

					private int ApgygIeirHFduKKaBcPpAiKKAshqb;

					private ElementAssignmentConflictCheck TPOChDembrOyOaJZcLuMUvFsXQLw;

					public ElementAssignmentConflictCheck NzZkTtnTIyioBOIiqbnWCttLJAKs;

					public ConflictCheckingHelper UWleSDBhxprlUvinNGrheYXeqpAU;

					private bool hiicsIjyYjJWyIoDnVsVRXeWQqTE;

					public bool SLTTsGeLhFhUiEdkVqgcbYmcpnZDc;

					private bool YCrghQKCyoawVPQkUqJYHpDUVqgF;

					public bool BAyVXiCTCdNopucJWTQnkIGbkGEF;

					private int OZcsVdHdQgOmzARgGMCCNLiyAzfQ;

					private IEnumerator<ElementAssignmentConflictInfo> TLqsUFgPAdYdxZhxzEOLSkoYnmcO;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hBIiSwdcvmigGBKjojPETxUGnFhv;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hBIiSwdcvmigGBKjojPETxUGnFhv;
						}
					}

					[DebuggerHidden]
					public ATqhtwJEbQMtsNHChMjEjmvPnnum(int P_0)
					{
						wikDnUkQhfeikgIZUotfQmtiqzkM = P_0;
						ApgygIeirHFduKKaBcPpAiKKAshqb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = wikDnUkQhfeikgIZUotfQmtiqzkM;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								izvsDvMrCMjjMNqFGXMARcWNTQow();
							}
						}
						TLqsUFgPAdYdxZhxzEOLSkoYnmcO = null;
						wikDnUkQhfeikgIZUotfQmtiqzkM = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = wikDnUkQhfeikgIZUotfQmtiqzkM;
							ConflictCheckingHelper uWleSDBhxprlUvinNGrheYXeqpAU = UWleSDBhxprlUvinNGrheYXeqpAU;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								wikDnUkQhfeikgIZUotfQmtiqzkM = -3;
								goto IL_00f3;
							}
							wikDnUkQhfeikgIZUotfQmtiqzkM = -1;
							if (TPOChDembrOyOaJZcLuMUvFsXQLw.controllerId < 0 || TPOChDembrOyOaJZcLuMUvFsXQLw.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							OZcsVdHdQgOmzARgGMCCNLiyAzfQ = 0;
							goto IL_011f;
							IL_00f3:
							if (TLqsUFgPAdYdxZhxzEOLSkoYnmcO.MoveNext())
							{
								ElementAssignmentConflictInfo current = TLqsUFgPAdYdxZhxzEOLSkoYnmcO.Current;
								hBIiSwdcvmigGBKjojPETxUGnFhv = current;
								wikDnUkQhfeikgIZUotfQmtiqzkM = 1;
								return true;
							}
							izvsDvMrCMjjMNqFGXMARcWNTQow();
							TLqsUFgPAdYdxZhxzEOLSkoYnmcO = null;
							goto IL_010d;
							IL_011f:
							if (OZcsVdHdQgOmzARgGMCCNLiyAzfQ < uWleSDBhxprlUvinNGrheYXeqpAU.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv())
							{
								if (uWleSDBhxprlUvinNGrheYXeqpAU.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(OZcsVdHdQgOmzARgGMCCNLiyAzfQ).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == TPOChDembrOyOaJZcLuMUvFsXQLw.controllerId)
								{
									TLqsUFgPAdYdxZhxzEOLSkoYnmcO = uWleSDBhxprlUvinNGrheYXeqpAU.pBqGBliUqBpNcjmlfvvWDJvSCqdeB(TPOChDembrOyOaJZcLuMUvFsXQLw, hiicsIjyYjJWyIoDnVsVRXeWQqTE, YCrghQKCyoawVPQkUqJYHpDUVqgF, uWleSDBhxprlUvinNGrheYXeqpAU.VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(OZcsVdHdQgOmzARgGMCCNLiyAzfQ).ZfxPjujFGUgoCbyzcaKfutLOglBy).GetEnumerator();
									wikDnUkQhfeikgIZUotfQmtiqzkM = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							OZcsVdHdQgOmzARgGMCCNLiyAzfQ++;
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

					private void izvsDvMrCMjjMNqFGXMARcWNTQow()
					{
						wikDnUkQhfeikgIZUotfQmtiqzkM = -1;
						if (TLqsUFgPAdYdxZhxzEOLSkoYnmcO != null)
						{
							TLqsUFgPAdYdxZhxzEOLSkoYnmcO.Dispose();
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
						ATqhtwJEbQMtsNHChMjEjmvPnnum aTqhtwJEbQMtsNHChMjEjmvPnnum;
						if (wikDnUkQhfeikgIZUotfQmtiqzkM == -2 && ApgygIeirHFduKKaBcPpAiKKAshqb == Environment.CurrentManagedThreadId)
						{
							wikDnUkQhfeikgIZUotfQmtiqzkM = 0;
							aTqhtwJEbQMtsNHChMjEjmvPnnum = this;
						}
						else
						{
							aTqhtwJEbQMtsNHChMjEjmvPnnum = new ATqhtwJEbQMtsNHChMjEjmvPnnum(0);
							aTqhtwJEbQMtsNHChMjEjmvPnnum.UWleSDBhxprlUvinNGrheYXeqpAU = UWleSDBhxprlUvinNGrheYXeqpAU;
						}
						aTqhtwJEbQMtsNHChMjEjmvPnnum.TPOChDembrOyOaJZcLuMUvFsXQLw = NzZkTtnTIyioBOIiqbnWCttLJAKs;
						aTqhtwJEbQMtsNHChMjEjmvPnnum.hiicsIjyYjJWyIoDnVsVRXeWQqTE = SLTTsGeLhFhUiEdkVqgcbYmcpnZDc;
						aTqhtwJEbQMtsNHChMjEjmvPnnum.YCrghQKCyoawVPQkUqJYHpDUVqgF = BAyVXiCTCdNopucJWTQnkIGbkGEF;
						return aTqhtwJEbQMtsNHChMjEjmvPnnum;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player orVjZWDAGzIyrFrEcbEjXUZHCpSHA;

				private readonly ControllerHelper VtHkgKoXnIipwvIFbPMizpocDljQ;

				private readonly int aqzKCXlUohNTyqBzGWseFLopBCrkA;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					aqzKCXlUohNTyqBzGWseFLopBCrkA = ReInput.id;
					orVjZWDAGzIyrFrEcbEjXUZHCpSHA = P_0;
					VtHkgKoXnIipwvIFbPMizpocDljQ = P_1;
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => xsxFPqCVmwLpfcPDfXKNDohGFUJCd(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => XdpYRSFHWIlRaVrjqdwDEuQDvMur(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => PdEFXEhrVHZXDxTwPbZthDdXeWcKA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => qkPAikJKhXeOaBcjSWvMPsROxTGD(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => wmOJzWcnagNTDEkVRqPyAGxcBry(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => tcwSvuBOAZdLIeHoYZEcVntkxCToA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ONHXixrlahNvqCyGzOrCLSWpGbaU(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => SdSZpnJuoRLrvnWCEZJjiTxuylpj(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return DZvaJSKzuoTBrtmMhWedpYQyBqTs(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return zFkaYPgvuVycLlYzZFiAVPnxrusTA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return BPKtRECmoxCKVDQcpsDqXpfhprMB(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return bKaeleBlGFyomgvvEpAkudpGODMJA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => yDiTaWIlRhGGpYrEWeTSaeFjgGDM(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => siIATSGlfWbzdneUKPRpReZWJcqTA(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => kkPczxlBrnvybEijGkbCfkEXfAmW(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => bDPprJMyacklkCofhuqqMfoFdFQt(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ZhtjSxtFpkzsCGoTYxPKLBUXzRvO(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => qkjilGhGUcmEPSjuKDLWeWiPkHfT(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => NpGxSutZCplvHknAPvltleOCXYvG(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => YhuokydptnRupSjbAdvMFLktAeEuA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return SeiukSNpJkuNJMcvLHAwfowkoIvV(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return IBZYrnedpYjUwTGlMyQaLMhXWgEg(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return pLDKvSTTuoyUwaIXXVtWPgYcklp(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return RbcLMnFocWIHWxsfAToeDAANXlcy(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => PtKazvsNAvWnEdLeqVTcGsbFmMjq(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => VirAHEEMunemtidGMXUVPIAqjqABA(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => NtnKqEIBAHjkgoVEwvFGxgzKvBFk(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => eZhtiIsiiroFZYmJMKWCvyUKMdLp(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => DBOpAszwdzGfrhpFHlaynCBGZRMF(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => cJYXuBYICVOCsCvSdBvKNZCNMltb(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => aabXbgnqTeMmgtAmckbkClePxsfA(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => JkEqLxqZZlreVCMrsougCANlzaZk(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return ieBbxgOHDcqjWPDLqAosLOCcjtsd(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return wRbpMvCNFSCqNawUHdeLHLSRzLRp(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return rKmcwCbvgeuMuWCfRrdVIkeRiUWp(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return BluTADIPbcILpezdfKmptPSdDuKsA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => zZyWqTbPzeBBvdIrfduzqTnDCOrx(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => poYwAVKCXsMUFJMPJOqyrtenDsBF(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => oFXhyiGTphyFSNKIuJblrtVFPQqUA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => NmZKWfcxRwhsOcPoujFZhrcHECgGb(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => zUDbQJcclOsrtPwFuxBixCfYTdrH(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => cIrMAVvgrNwlxpSZkdlgKCJMIBgW(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => EUVWkGJBeqqAkXLtLpIcdoRjDlmt(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => wHnFNcDJuXQajiYRqAfINIaqFgRBA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != aqzKCXlUohNTyqBzGWseFLopBCrkA)
					{
						ReInput.CheckInitialized(aqzKCXlUohNTyqBzGWseFLopBCrkA);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return RPFQVnrLOybkNvxyixVpZOIotDln(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return kdrfBFVXIeahMwNdbVuWyqQLhpqo(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return WkoDSmfMfzZDOGHyXXWudrGtdGDB(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return KxbDLZBpgQhrfFnBhEDeFacyNIgr(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool xsxFPqCVmwLpfcPDfXKNDohGFUJCd(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0 && NfqIFIXfEvGBcRLeaGEhdTXiCCBfb(ControllerType.Joystick, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy))
						{
							return true;
						}
					}
					return false;
				}

				private bool wmOJzWcnagNTDEkVRqPyAGxcBry(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0 && DhpExAbSZTfoXgCmVEXGVHgkzogUA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy))
						{
							return true;
						}
					}
					return false;
				}

				private bool DZvaJSKzuoTBrtmMhWedpYQyBqTs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0.controllerId && oVHglTPWLRCGUmDlgmSCywxRUxkg(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy))
						{
							return true;
						}
					}
					return false;
				}

				private bool XdpYRSFHWIlRaVrjqdwDEuQDvMur(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return NfqIFIXfEvGBcRLeaGEhdTXiCCBfb(ControllerType.Keyboard, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private bool tcwSvuBOAZdLIeHoYZEcVntkxCToA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return DhpExAbSZTfoXgCmVEXGVHgkzogUA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private bool zFkaYPgvuVycLlYzZFiAVPnxrusTA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return oVHglTPWLRCGUmDlgmSCywxRUxkg(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private bool PdEFXEhrVHZXDxTwPbZthDdXeWcKA(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return NfqIFIXfEvGBcRLeaGEhdTXiCCBfb(ControllerType.Mouse, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private bool ONHXixrlahNvqCyGzOrCLSWpGbaU(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return DhpExAbSZTfoXgCmVEXGVHgkzogUA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private bool BPKtRECmoxCKVDQcpsDqXpfhprMB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return oVHglTPWLRCGUmDlgmSCywxRUxkg(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private bool qkPAikJKhXeOaBcjSWvMPsROxTGD(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0 && NfqIFIXfEvGBcRLeaGEhdTXiCCBfb(ControllerType.Custom, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy))
						{
							return true;
						}
					}
					return false;
				}

				private bool SdSZpnJuoRLrvnWCEZJjiTxuylpj(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0 && DhpExAbSZTfoXgCmVEXGVHgkzogUA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy))
						{
							return true;
						}
					}
					return false;
				}

				private bool bKaeleBlGFyomgvvEpAkudpGODMJA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0.controllerId && oVHglTPWLRCGUmDlgmSCywxRUxkg(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(THufltjKutkOYyRSvdUMcscGLCagc))]
				private IEnumerable<ElementAssignmentConflictInfo> yDiTaWIlRhGGpYrEWeTSaeFjgGDM(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new THufltjKutkOYyRSvdUMcscGLCagc(-2)
					{
						GWhAnmfGXSVSIukqMIGkwxAUMFvi = this,
						uOLCFRedpSlyKfzaERjcHegkIwDYb = P_0,
						hLnhQswumpXGJIZIFProXFKJJDBo = P_1,
						QjVfCaAJxTzYHrEbpiamzWKLZbhv = P_2,
						HAUdRFGgPsceSiJTdYTQEWORuZeI = P_3
					};
				}

				[IteratorStateMachine(typeof(PaERIcPqHDKtjEYjmrihrIuXjjoR))]
				private IEnumerable<ElementAssignmentConflictInfo> ZhtjSxtFpkzsCGoTYxPKLBUXzRvO(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new PaERIcPqHDKtjEYjmrihrIuXjjoR(-2)
					{
						tWmeKpXvUyqqUFLnxcElCJAQWxyGA = this,
						IZHjKghMpAFzkSUszcoVdvkEnRqfb = P_0,
						oeYkMSjKJaynPRigLAZDcpcztmbb = P_1,
						yzQtrYVswuHbAnchPTgOJdMIVekP = P_2,
						sgxeKboaXCEmQIBkiXyqOKeICsgH = P_3,
						zJeOjcPGkhYoIpZcYDXleEKMYCCB = P_4
					};
				}

				[IteratorStateMachine(typeof(ATqhtwJEbQMtsNHChMjEjmvPnnum))]
				private IEnumerable<ElementAssignmentConflictInfo> SeiukSNpJkuNJMcvLHAwfowkoIvV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new ATqhtwJEbQMtsNHChMjEjmvPnnum(-2)
					{
						UWleSDBhxprlUvinNGrheYXeqpAU = this,
						NzZkTtnTIyioBOIiqbnWCttLJAKs = P_0,
						SLTTsGeLhFhUiEdkVqgcbYmcpnZDc = P_1,
						BAyVXiCTCdNopucJWTQnkIGbkGEF = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> siIATSGlfWbzdneUKPRpReZWJcqTA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return kBTUZmcyGFAiVnTqgkCgKTsNAVLH(ControllerType.Keyboard, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private IEnumerable<ElementAssignmentConflictInfo> qkjilGhGUcmEPSjuKDLWeWiPkHfT(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return UcOEzoDGtkIwfAtochhdQuUJLbTp(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private IEnumerable<ElementAssignmentConflictInfo> IBZYrnedpYjUwTGlMyQaLMhXWgEg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return pBqGBliUqBpNcjmlfvvWDJvSCqdeB(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private IEnumerable<ElementAssignmentConflictInfo> kkPczxlBrnvybEijGkbCfkEXfAmW(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return kBTUZmcyGFAiVnTqgkCgKTsNAVLH(ControllerType.Mouse, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> NpGxSutZCplvHknAPvltleOCXYvG(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return UcOEzoDGtkIwfAtochhdQuUJLbTp(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private IEnumerable<ElementAssignmentConflictInfo> pLDKvSTTuoyUwaIXXVtWPgYcklp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return pBqGBliUqBpNcjmlfvvWDJvSCqdeB(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				[IteratorStateMachine(typeof(hzxAuzgynQAnCruStmfFipLVRvPsA))]
				private IEnumerable<ElementAssignmentConflictInfo> bDPprJMyacklkCofhuqqMfoFdFQt(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new hzxAuzgynQAnCruStmfFipLVRvPsA(-2)
					{
						DggIHSiLvGyVxkdvaXqUTkVvISsBA = this,
						TfKLgUhTMeFlWFLGpSvgmhhofqnbA = P_0,
						aMahIAKgbkGMEuhVetYaYigFgJIY = P_1,
						IhHkqyatVJtfumPSQyEYXtuRADNW = P_2,
						RrBecHdUUJJhTNkuMIAxvhTpwswo = P_3
					};
				}

				[IteratorStateMachine(typeof(fwYBnhywKqdggMEfbCpvkRfRiVCxA))]
				private IEnumerable<ElementAssignmentConflictInfo> YhuokydptnRupSjbAdvMFLktAeEuA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new fwYBnhywKqdggMEfbCpvkRfRiVCxA(-2)
					{
						igYcFqdMgAbJZgHwnnVVjiPnOUfUA = this,
						uEuazMKUwiKSKLYuFRsyGDttouCi = P_0,
						BeNeIVLqpmqgbYmsfpEiLpoqeCjEA = P_1,
						JQkFyiGBnJOjFHqREfZuflETbGksB = P_2,
						RUCgpImzCdvHvSTxltXHJYvcjTov = P_3,
						ESsPLuGOnPZqjdDBXyexwDcaFEGw = P_4
					};
				}

				[IteratorStateMachine(typeof(bFfeHhkpvyqWQmSoNWEPpyJeUtyW))]
				private IEnumerable<ElementAssignmentConflictInfo> RbcLMnFocWIHWxsfAToeDAANXlcy(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new bFfeHhkpvyqWQmSoNWEPpyJeUtyW(-2)
					{
						bByBbWkzoDzbNUUPGohshnuHqlUEA = this,
						ODgwDrDbmDDsfFSRjtJJkMrNTkWOA = P_0,
						EyCpLBMNSUQXfrgsMiCXRGBqIDGHA = P_1,
						JEowUGcDGfAmHiAlKKLABRSvXmmc = P_2
					};
				}

				private int PtKazvsNAvWnEdLeqVTcGsbFmMjq(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += RYYOZZnYNrHEFDtpwRKNvSYltcaS(ControllerType.Joystick, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy);
						}
					}
					return num;
				}

				private int DBOpAszwdzGfrhpFHlaynCBGZRMF(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += DhebWoFDNotgOOVYFLuBiQtcaZLcA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy);
						}
					}
					return num;
				}

				private int ieBbxgOHDcqjWPDLqAosLOCcjtsd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0.controllerId)
						{
							num += wgFafORfBDDjvInzRUKlSuVNfqgIA(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy);
						}
					}
					return num;
				}

				private int VirAHEEMunemtidGMXUVPIAqjqABA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return RYYOZZnYNrHEFDtpwRKNvSYltcaS(ControllerType.Keyboard, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private int cJYXuBYICVOCsCvSdBvKNZCNMltb(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return DhebWoFDNotgOOVYFLuBiQtcaZLcA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private int wRbpMvCNFSCqNawUHdeLHLSRzLRp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return wgFafORfBDDjvInzRUKlSuVNfqgIA(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ);
				}

				private int NtnKqEIBAHjkgoVEwvFGxgzKvBFk(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return RYYOZZnYNrHEFDtpwRKNvSYltcaS(ControllerType.Mouse, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private int aabXbgnqTeMmgtAmckbkClePxsfA(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return DhebWoFDNotgOOVYFLuBiQtcaZLcA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private int rKmcwCbvgeuMuWCfRrdVIkeRiUWp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return wgFafORfBDDjvInzRUKlSuVNfqgIA(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA);
				}

				private int eZhtiIsiiroFZYmJMKWCvyUKMdLp(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += RYYOZZnYNrHEFDtpwRKNvSYltcaS(ControllerType.Custom, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy);
						}
					}
					return num;
				}

				private int JkEqLxqZZlreVCMrsougCANlzaZk(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += DhebWoFDNotgOOVYFLuBiQtcaZLcA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy);
						}
					}
					return num;
				}

				private int BluTADIPbcILpezdfKmptPSdDuKsA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0.controllerId)
						{
							num += wgFafORfBDDjvInzRUKlSuVNfqgIA(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy);
						}
					}
					return num;
				}

				private int zZyWqTbPzeBBvdIrfduzqTnDCOrx(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += ptxmKFOLQUWLmZNjloyHqSMesWER(ControllerType.Joystick, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy, P_4);
						}
					}
					return num;
				}

				private int zUDbQJcclOsrtPwFuxBixCfYTdrH(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += sshGySZFabCPwkueNdKcejAWFDuHb(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy, P_5);
						}
					}
					return num;
				}

				private int RPFQVnrLOybkNvxyixVpZOIotDln(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0.controllerId)
						{
							num += CKpfXdbffopLlBCTmbChvDarEXGx(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy, P_3);
						}
					}
					return num;
				}

				private int poYwAVKCXsMUFJMPJOqyrtenDsBF(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return ptxmKFOLQUWLmZNjloyHqSMesWER(ControllerType.Keyboard, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ, P_3);
				}

				private int cIrMAVvgrNwlxpSZkdlgKCJMIBgW(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return sshGySZFabCPwkueNdKcejAWFDuHb(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ, P_4);
				}

				private int kdrfBFVXIeahMwNdbVuWyqQLhpqo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return CKpfXdbffopLlBCTmbChvDarEXGx(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.PiNZhsRUWlBfjdmkYBrEaNEVLfRQ, P_3);
				}

				private int oFXhyiGTphyFSNKIuJblrtVFPQqUA(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return ptxmKFOLQUWLmZNjloyHqSMesWER(ControllerType.Mouse, 0, P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA, P_3);
				}

				private int EUVWkGJBeqqAkXLtLpIcdoRjDlmt(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return sshGySZFabCPwkueNdKcejAWFDuHb(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA, P_4);
				}

				private int WkoDSmfMfzZDOGHyXXWudrGtdGDB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return CKpfXdbffopLlBCTmbChvDarEXGx(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.oQKkVKLcGwcDDRHfnhtQdXMVMQmeA, P_3);
				}

				private int NmZKWfcxRwhsOcPoujFZhrcHECgGb(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += ptxmKFOLQUWLmZNjloyHqSMesWER(ControllerType.Custom, P_0, P_1, P_2, P_3, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy, P_4);
						}
					}
					return num;
				}

				private int wHnFNcDJuXQajiYRqAfINIaqFgRBA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							num += sshGySZFabCPwkueNdKcejAWFDuHb(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy, P_5);
						}
					}
					return num;
				}

				private int KxbDLZBpgQhrfFnBhEDeFacyNIgr(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.YmSeLrtRLFpSMgEaKXjHdYhoBnBv(); i++)
					{
						if (VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0.controllerId)
						{
							num += CKpfXdbffopLlBCTmbChvDarEXGx(P_0, P_1, P_2, VtHkgKoXnIipwvIFbPMizpocDljQ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.zvMbuwhKhiBzRkZRDFUkocyNifGI(i).ZfxPjujFGUgoCbyzcaKfutLOglBy, P_3);
						}
					}
					return num;
				}

				private bool NfqIFIXfEvGBcRLeaGEhdTXiCCBfb<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_5.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool DhpExAbSZTfoXgCmVEXGVHgkzogUA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_6.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool oVHglTPWLRCGUmDlgmSCywxRUxkg<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_3.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(QPRNFQzkSVcNwcPuMDJMlqTwlIngA))]
				private IEnumerable<ElementAssignmentConflictInfo> kBTUZmcyGFAiVnTqgkCgKTsNAVLH<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_5) where _0001 : ControllerMap
				{
					return new QPRNFQzkSVcNwcPuMDJMlqTwlIngA<_0001>(-2)
					{
						mjAbsQXrCaFHRWzCNPjsWirTFLRn = this,
						GbXRytjdtjKvsiYmKVdCXvBEVHoF = P_0,
						fYCXLRVJCHMqRDOKoWUrVweqSjPw = P_1,
						gPJVbdVzwPpjFErSTKoURHgxYWSq = P_2,
						XPjQDNjClIFRSXLIrpIJvCARHShg = P_3,
						OXqJRfvUIGxSpXhBTrqKFTyUbcib = P_4,
						HqplPUrPRfcDGcVfQhilHTZhnirvA = P_5
					};
				}

				[IteratorStateMachine(typeof(ziNSguvyUrsbPYbIFrLpLuMcolNK))]
				private IEnumerable<ElementAssignmentConflictInfo> UcOEzoDGtkIwfAtochhdQuUJLbTp<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_6) where _0001 : ControllerMap
				{
					return new ziNSguvyUrsbPYbIFrLpLuMcolNK<_0001>(-2)
					{
						LRlqCESnvVdnuKQeebqzeKrClyHFB = this,
						JWsYrtzkLrTaLoCpKjQuUJMZIevcA = P_0,
						DwJEgOeUSOMuesqfkAcoylRxoSoaA = P_1,
						kfmmbNwStrryLYOFUTxZRPbJwkUA = P_2,
						sriFPVXgRGYzPwgzxrWtGqbEiMeB = P_3,
						QfKBhrGnEfhUdYfJGxTUgQjcaVIrA = P_4,
						tHHsqQqtzHtFganhsrrYLOfVGyMf = P_5,
						ltENOAHKcdBglFrHhoEnFGFKYhpxA = P_6
					};
				}

				[IteratorStateMachine(typeof(WkTluKsUpWhwIhBiHcaiGGutvDnt))]
				private IEnumerable<ElementAssignmentConflictInfo> pBqGBliUqBpNcjmlfvvWDJvSCqdeB<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_3) where _0001 : ControllerMap
				{
					return new WkTluKsUpWhwIhBiHcaiGGutvDnt<_0001>(-2)
					{
						CtOGWJAdKXpJFWkGfibVFffYHgrPA = this,
						lZjTRwwcjuuXABagtpIsmwAZlapW = P_0,
						IIarDdKyLPVOuyrdLbKGPYVnVHpD = P_1,
						yAaoaLYdghhcAtEwIoIyzQsgOUzI = P_2,
						vIgLMmYgrbLTnfyFaHPimcbSfKYIA = P_3
					};
				}

				private int RYYOZZnYNrHEFDtpwRKNvSYltcaS<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_5.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int DhebWoFDNotgOOVYFLuBiQtcaZLcA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_6.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int wgFafORfBDDjvInzRUKlSuVNfqgIA<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_3.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int ptxmKFOLQUWLmZNjloyHqSMesWER<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_5.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(mapCategory, controllerMap)))
						{
							num += controllerMap.nvmchnKoGxXFaoBqqNGNvPjIqMun(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int sshGySZFabCPwkueNdKcejAWFDuHb<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_6.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(inputMapCategory, controllerMap)))
						{
							num += controllerMap.lcZlggKEXkqAPCwiNeGdvZOKjNuk(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int CKpfXdbffopLlBCTmbChvDarEXGx<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.PHddzgndMnzRWWZdLPxBNVqdUdeV(); i++)
					{
						ControllerMap controllerMap = P_3.SypULfmhiRJaajsxCpMqFoMTkKpm(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !SLfcMiaLExLjpOHgQzOSRCRJUyun(inputMapCategory, controllerMap)))
						{
							num += controllerMap.TkdZQUCDguLHxVfhnjqQyiCLqOMJ(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool SLfcMiaLExLjpOHgQzOSRCRJUyun(InputMapCategory P_0, ControllerMap P_1)
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
			internal interface kQwkAQGpxfuwmZzSQKYSLJHpqSgU
			{
				bBElDCzNQPgEkhpZsNHGoblOIrlYA hBkdHEzyCLJpyZoWcWCMCzKOOjHD { get; }

				ControllerType TPIQqyGTASNUJuhnOYleKvROifiv { get; }

				int kVgCrHansgVHQdOwmDKoORLmXnGv { get; }

				bool ZjpzVRUHWWgepDOiiuyTAOMjaBgU(Controller P_0);

				bool DSdoBNNkTAayMeNbzQdZDhkYfJTT(int P_0);

				void siLcGpDBztVaiOujsFRwOGMosiDe(int P_0);

				void roXswfXyHcdAAQTJzhKuzlhIoSZc(Controller P_0);

				void LQbMjStSslnckQnXaloDiXXXoihS(int P_0);

				Controller qQYlezDDREZgCHEPytzgINVOkfXk(int P_0);

				Controller nLHkDUZclLIHCaoFvermawROQHjJ(string P_0);

				int NAwKKoVcnUdBddppaTUXqqAGPgiDb(Controller P_0);

				int eoyYPrzBBUZZQhpjyHILTteiVtU(int P_0);

				int AlwhCYHTRaeLcRmpZVFgmFxTadSe(string P_0);

				void ngoVuNjwmJsyRYmSIkpBkyTZCVPj();

				bBElDCzNQPgEkhpZsNHGoblOIrlYA tLHWYncFxtGelWBkmFooasRaAXBz(int P_0);

				bBElDCzNQPgEkhpZsNHGoblOIrlYA GaJgQuIamoKKQXLUVHCwfVaefbveA(Controller P_0);

				void FyBLmrCvsgFqDUgqwtrShNoWgkoT(bBElDCzNQPgEkhpZsNHGoblOIrlYA P_0);
			}

			internal interface bBElDCzNQPgEkhpZsNHGoblOIrlYA
			{
				yiZTVAYmYqfnMStnvrnpZDWxfexCA LYmUAmbCzgGoTbembTlgBdvFhNexA { get; }

				Controller SCIEAWsfXbkuiCOHobGqAdbARGfbA { get; }

				double JqthFYGXJWQNUhgYzeDjzhUuOiek { get; }
			}

			[DefaultMember("Item")]
			internal sealed class gIJedRrdlfvGfpypDoGdkbLXCohk<_0001, _0002> : kQwkAQGpxfuwmZzSQKYSLJHpqSgU where _0001 : Controller where _0002 : ControllerMap
			{
				public class hiWJtllRqMdCqcwtrhSJVifgeTuZ : bBElDCzNQPgEkhpZsNHGoblOIrlYA
				{
					public _0001 CeCCWHxtgtrfLYpuZqBgEmzIGJGG;

					public global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0002> ZfxPjujFGUgoCbyzcaKfutLOglBy;

					public double UmubroOsWCKmuBKZWKikibsjyTMN;

					Controller bBElDCzNQPgEkhpZsNHGoblOIrlYA.OswjdvuTadSHLQQtEtkwFSjXLwmJ => CeCCWHxtgtrfLYpuZqBgEmzIGJGG;

					yiZTVAYmYqfnMStnvrnpZDWxfexCA bBElDCzNQPgEkhpZsNHGoblOIrlYA.JTfTHIuOexJjvOJBGjeNcGZinNXFA => ZfxPjujFGUgoCbyzcaKfutLOglBy;

					double bBElDCzNQPgEkhpZsNHGoblOIrlYA.HMHQieydgEgsMKZhhsDzQWxPaSCdb => UmubroOsWCKmuBKZWKikibsjyTMN;

					public hiWJtllRqMdCqcwtrhSJVifgeTuZ(_0001 P_0, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0002> P_1)
					{
						CeCCWHxtgtrfLYpuZqBgEmzIGJGG = P_0;
						ZfxPjujFGUgoCbyzcaKfutLOglBy = P_1;
					}

					public void bhVoIEFYkcEzsKTgvwTVIRcyoBzK()
					{
						UmubroOsWCKmuBKZWKikibsjyTMN = ReInput.unscaledTime;
					}
				}

				private List<hiWJtllRqMdCqcwtrhSJVifgeTuZ> jYJdlUKTzGWhRTPijtkCJHmTVUpRA;

				private List<_0001> PRHftvabAJaOPZIXkrOtWLOkFunU;

				private ReadOnlyCollection<_0001> XSaCcqBnizuvwCmAoPtZnyCzcqEtA;

				private readonly ControllerType qkYEiEYcZaIGTellTnAvPipKuBcY;

				int kQwkAQGpxfuwmZzSQKYSLJHpqSgU.kVgCrHansgVHQdOwmDKoORLmXnGv => jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Count;

				public IList<_0001> MvqWdXawFeajMsaqNWoPtaauNvng => XSaCcqBnizuvwCmAoPtZnyCzcqEtA;

				public hiWJtllRqMdCqcwtrhSJVifgeTuZ wwbOxBflIQiKaTwlFGTPtQlzUJFM => jYJdlUKTzGWhRTPijtkCJHmTVUpRA[P_0];

				ControllerType kQwkAQGpxfuwmZzSQKYSLJHpqSgU.TPIQqyGTASNUJuhnOYleKvROifiv => qkYEiEYcZaIGTellTnAvPipKuBcY;

				bBElDCzNQPgEkhpZsNHGoblOIrlYA kQwkAQGpxfuwmZzSQKYSLJHpqSgU.uJWeLjEVTfKGKGHswtxUBRRUcpHab => jYJdlUKTzGWhRTPijtkCJHmTVUpRA[index];

				public gIJedRrdlfvGfpypDoGdkbLXCohk()
				{
					if ((object)nwsTruCLxjorysrNysDvPYrmMcrb.FcJrUfjHnESDhlZBkEPSisPUvHZh<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					qkYEiEYcZaIGTellTnAvPipKuBcY = nwsTruCLxjorysrNysDvPYrmMcrb.KJVnZiWiqanBkcZAJRrTVEjwWizT(typeof(_0001));
					jYJdlUKTzGWhRTPijtkCJHmTVUpRA = new List<hiWJtllRqMdCqcwtrhSJVifgeTuZ>();
					PRHftvabAJaOPZIXkrOtWLOkFunU = new List<_0001>();
					XSaCcqBnizuvwCmAoPtZnyCzcqEtA = new ReadOnlyCollection<_0001>(PRHftvabAJaOPZIXkrOtWLOkFunU);
				}

				public hiWJtllRqMdCqcwtrhSJVifgeTuZ kOSbOhzAFvHhjDaeprhiBwQrqYUuA(int P_0)
				{
					if (qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Keyboard || qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iSKrcZgFgDfcIwJBuSpahNHadDeG(P_0);
					if (num < 0)
					{
						return null;
					}
					return jYJdlUKTzGWhRTPijtkCJHmTVUpRA[num];
				}

				public hiWJtllRqMdCqcwtrhSJVifgeTuZ AHOevkcyrzCcImmYZUvIFRdvcdyEA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return kOSbOhzAFvHhjDaeprhiBwQrqYUuA(P_0.id);
				}

				public void UHiJzcjjvtfQGdoNzbrXmKJRjCWj(hiWJtllRqMdCqcwtrhSJVifgeTuZ P_0)
				{
					if (P_0 != null)
					{
						jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Add(P_0);
						PRHftvabAJaOPZIXkrOtWLOkFunU.Add(P_0.CeCCWHxtgtrfLYpuZqBgEmzIGJGG);
					}
				}

				public void GgLrExucJGmeufDRSGrPFPkblJrUA(int P_0)
				{
					if (qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Keyboard || qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (iSKrcZgFgDfcIwJBuSpahNHadDeG(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Count; i++)
					{
						if (jYJdlUKTzGWhRTPijtkCJHmTVUpRA[i].CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							bdrxaIbNdjdkuftgkimqsQZEiuEC(i);
							break;
						}
					}
				}

				void kQwkAQGpxfuwmZzSQKYSLJHpqSgU.siLcGpDBztVaiOujsFRwOGMosiDe(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in GgLrExucJGmeufDRSGrPFPkblJrUA
					this.GgLrExucJGmeufDRSGrPFPkblJrUA(P_0);
				}

				public void LKanrAAJsKNnYrHBtSjbXIgawjdX(_0001 P_0)
				{
					if (P_0 != null && P_0.type == qkYEiEYcZaIGTellTnAvPipKuBcY)
					{
						GgLrExucJGmeufDRSGrPFPkblJrUA(P_0.id);
					}
				}

				public void bdrxaIbNdjdkuftgkimqsQZEiuEC(int P_0)
				{
					if (P_0 >= 0 && P_0 < jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Count)
					{
						jYJdlUKTzGWhRTPijtkCJHmTVUpRA.RemoveAt(P_0);
						PRHftvabAJaOPZIXkrOtWLOkFunU.RemoveAt(P_0);
					}
				}

				void kQwkAQGpxfuwmZzSQKYSLJHpqSgU.LQbMjStSslnckQnXaloDiXXXoihS(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in bdrxaIbNdjdkuftgkimqsQZEiuEC
					this.bdrxaIbNdjdkuftgkimqsQZEiuEC(P_0);
				}

				public _0001 lbQLGldyKUQHJMQDqmaKPaUNAXWr(int P_0)
				{
					if (qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Keyboard || qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iSKrcZgFgDfcIwJBuSpahNHadDeG(P_0);
					if (num < 0)
					{
						return null;
					}
					return jYJdlUKTzGWhRTPijtkCJHmTVUpRA[num].CeCCWHxtgtrfLYpuZqBgEmzIGJGG;
				}

				public bool CHjqvjdcctTansGcdffcBzUxFNybA(int P_0)
				{
					if (qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Keyboard || qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Count; i++)
					{
						if (jYJdlUKTzGWhRTPijtkCJHmTVUpRA[i].CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool kQwkAQGpxfuwmZzSQKYSLJHpqSgU.DSdoBNNkTAayMeNbzQdZDhkYfJTT(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in CHjqvjdcctTansGcdffcBzUxFNybA
					return this.CHjqvjdcctTansGcdffcBzUxFNybA(P_0);
				}

				public bool mgUdgecnRBDtXnGOEEsmZjmmjtpAA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != qkYEiEYcZaIGTellTnAvPipKuBcY)
					{
						return false;
					}
					return CHjqvjdcctTansGcdffcBzUxFNybA(P_0.id);
				}

				public int iSKrcZgFgDfcIwJBuSpahNHadDeG(int P_0)
				{
					if (qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Keyboard || qkYEiEYcZaIGTellTnAvPipKuBcY == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Count; i++)
					{
						if (jYJdlUKTzGWhRTPijtkCJHmTVUpRA[i].CeCCWHxtgtrfLYpuZqBgEmzIGJGG.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int kQwkAQGpxfuwmZzSQKYSLJHpqSgU.eoyYPrzBBUZZQhpjyHILTteiVtU(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in iSKrcZgFgDfcIwJBuSpahNHadDeG
					return this.iSKrcZgFgDfcIwJBuSpahNHadDeG(P_0);
				}

				public int CmvuHZhzwiaPjGFbbHcGgibIxHgjA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != qkYEiEYcZaIGTellTnAvPipKuBcY)
					{
						return -1;
					}
					return iSKrcZgFgDfcIwJBuSpahNHadDeG(P_0.id);
				}

				public int JcNLOiLfSCLkJAkFSxtsjXfCZfOI(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Count; i++)
					{
						if (jYJdlUKTzGWhRTPijtkCJHmTVUpRA[i].CeCCWHxtgtrfLYpuZqBgEmzIGJGG.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int kQwkAQGpxfuwmZzSQKYSLJHpqSgU.AlwhCYHTRaeLcRmpZVFgmFxTadSe(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in JcNLOiLfSCLkJAkFSxtsjXfCZfOI
					return this.JcNLOiLfSCLkJAkFSxtsjXfCZfOI(P_0);
				}

				public void WegLRXWqOEBffkTOxPPRmWWotQoiA()
				{
					jYJdlUKTzGWhRTPijtkCJHmTVUpRA.Clear();
					PRHftvabAJaOPZIXkrOtWLOkFunU.Clear();
				}

				void kQwkAQGpxfuwmZzSQKYSLJHpqSgU.ngoVuNjwmJsyRYmSIkpBkyTZCVPj()
				{
					//ILSpy generated this explicit interface implementation from .override directive in WegLRXWqOEBffkTOxPPRmWWotQoiA
					this.WegLRXWqOEBffkTOxPPRmWWotQoiA();
				}

				bBElDCzNQPgEkhpZsNHGoblOIrlYA kQwkAQGpxfuwmZzSQKYSLJHpqSgU.GetEntry(int controllerId)
				{
					return kOSbOhzAFvHhjDaeprhiBwQrqYUuA(controllerId);
				}

				bBElDCzNQPgEkhpZsNHGoblOIrlYA kQwkAQGpxfuwmZzSQKYSLJHpqSgU.GetEntry(Controller controller)
				{
					if (controller as _0001 == null)
					{
						return null;
					}
					return AHOevkcyrzCcImmYZUvIFRdvcdyEA(controller as _0001);
				}

				void kQwkAQGpxfuwmZzSQKYSLJHpqSgU.AddEntry(bBElDCzNQPgEkhpZsNHGoblOIrlYA entry)
				{
					UHiJzcjjvtfQGdoNzbrXmKJRjCWj((hiWJtllRqMdCqcwtrhSJVifgeTuZ)entry);
				}

				void kQwkAQGpxfuwmZzSQKYSLJHpqSgU.RemoveController(Controller controller)
				{
					LKanrAAJsKNnYrHBtSjbXIgawjdX(controller as _0001);
				}

				Controller kQwkAQGpxfuwmZzSQKYSLJHpqSgU.GetController(int controllerId)
				{
					return lbQLGldyKUQHJMQDqmaKPaUNAXWr(controllerId);
				}

				bool kQwkAQGpxfuwmZzSQKYSLJHpqSgU.Contains(Controller controller)
				{
					return mgUdgecnRBDtXnGOEEsmZjmmjtpAA(controller as _0001);
				}

				int kQwkAQGpxfuwmZzSQKYSLJHpqSgU.IndexOf(Controller controller)
				{
					return CmvuHZhzwiaPjGFbbHcGgibIxHgjA(controller as _0001);
				}

				Controller kQwkAQGpxfuwmZzSQKYSLJHpqSgU.GetControllerWithTag(string tag)
				{
					int num = JcNLOiLfSCLkJAkFSxtsjXfCZfOI(tag);
					if (num < 0)
					{
						return null;
					}
					return jYJdlUKTzGWhRTPijtkCJHmTVUpRA[num].CeCCWHxtgtrfLYpuZqBgEmzIGJGG;
				}
			}

			internal class gRltVhNwrOhpOgLZSJcAURRChXEp
			{
				public readonly int zKrhkjardydsdIOgpYiwrSsGSvBf;

				private ControllerType[] TonDYNgSzhdUopNzzVvdtjVygptdA;

				private kQwkAQGpxfuwmZzSQKYSLJHpqSgU[] UbSpxQipbmsVOkIiYjusfopQsaYVA;

				public kQwkAQGpxfuwmZzSQKYSLJHpqSgU tbVNuTxMhLaKLUfmQkxRFJdRuRWn(int P_0)
				{
					return UbSpxQipbmsVOkIiYjusfopQsaYVA[P_0];
				}

				public ControllerType aYslZWNqYSKQCmfApyVjmxykTTGL(int P_0)
				{
					return TonDYNgSzhdUopNzzVvdtjVygptdA[P_0];
				}

				public gRltVhNwrOhpOgLZSJcAURRChXEp(int P_0)
				{
					zKrhkjardydsdIOgpYiwrSsGSvBf = MathTools.Max(0, P_0);
					TonDYNgSzhdUopNzzVvdtjVygptdA = new ControllerType[P_0];
					UbSpxQipbmsVOkIiYjusfopQsaYVA = new kQwkAQGpxfuwmZzSQKYSLJHpqSgU[P_0];
				}

				public kQwkAQGpxfuwmZzSQKYSLJHpqSgU fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType P_0)
				{
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						if (P_0 == TonDYNgSzhdUopNzzVvdtjVygptdA[i])
						{
							return UbSpxQipbmsVOkIiYjusfopQsaYVA[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void RKlWKWojrOdxIgssFeWecvfcoAKvB(int P_0, ControllerType P_1, kQwkAQGpxfuwmZzSQKYSLJHpqSgU P_2)
				{
					TonDYNgSzhdUopNzzVvdtjVygptdA[P_0] = P_1;
					UbSpxQipbmsVOkIiYjusfopQsaYVA[P_0] = P_2;
				}
			}

			private class dgIKCyledkyNeIFfbrDuVCBslLke
			{
				public class PILdMxjsHkBmDykRUqypsInnOUDKA
				{
					public int tOUpYGeKfuNDITUOqTQoKmmdRoqe;

					public global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> INAQEXZBaUMevJYlIZhmlocNQWUI;

					public double hLilGvJNKDgCAHAsNisdEavDeytKB;

					public PILdMxjsHkBmDykRUqypsInnOUDKA(int P_0, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> P_1, double P_2)
					{
						tOUpYGeKfuNDITUOqTQoKmmdRoqe = P_0;
						INAQEXZBaUMevJYlIZhmlocNQWUI = P_1;
						hLilGvJNKDgCAHAsNisdEavDeytKB = P_2;
					}
				}

				private readonly List<PILdMxjsHkBmDykRUqypsInnOUDKA> gSnVYpLXDGjJOSQKMlgusDHHTCWh;

				private readonly Player HzRdnzixZbUKONMcpkWlFcBqPlacb;

				public dgIKCyledkyNeIFfbrDuVCBslLke(Player P_0)
				{
					HzRdnzixZbUKONMcpkWlFcBqPlacb = P_0;
					gSnVYpLXDGjJOSQKMlgusDHHTCWh = new List<PILdMxjsHkBmDykRUqypsInnOUDKA>();
				}

				public void LZsUvCLEfyfQuqMKbXlNixrFvpLh(Joystick P_0, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> P_1)
				{
					for (int i = 0; i < gSnVYpLXDGjJOSQKMlgusDHHTCWh.Count; i++)
					{
						PILdMxjsHkBmDykRUqypsInnOUDKA pILdMxjsHkBmDykRUqypsInnOUDKA = gSnVYpLXDGjJOSQKMlgusDHHTCWh[i];
						if (pILdMxjsHkBmDykRUqypsInnOUDKA.tOUpYGeKfuNDITUOqTQoKmmdRoqe == P_0.id)
						{
							pILdMxjsHkBmDykRUqypsInnOUDKA.INAQEXZBaUMevJYlIZhmlocNQWUI = P_1;
							pILdMxjsHkBmDykRUqypsInnOUDKA.hLilGvJNKDgCAHAsNisdEavDeytKB = ReInput.realTime;
							return;
						}
					}
					PILdMxjsHkBmDykRUqypsInnOUDKA item = new PILdMxjsHkBmDykRUqypsInnOUDKA(P_0.id, P_1, ReInput.realTime);
					gSnVYpLXDGjJOSQKMlgusDHHTCWh.Add(item);
				}

				public void FtBEPoXRBEsaNFaFHHVxkcykJPZk(gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ P_0)
				{
					LZsUvCLEfyfQuqMKbXlNixrFvpLh(P_0.CeCCWHxtgtrfLYpuZqBgEmzIGJGG, P_0.ZfxPjujFGUgoCbyzcaKfutLOglBy);
				}

				public void ZRHzgWWvzWNKMVbVIgKoTRxyjGOW()
				{
					for (int i = 0; i < gSnVYpLXDGjJOSQKMlgusDHHTCWh.Count; i++)
					{
						if (!HzRdnzixZbUKONMcpkWlFcBqPlacb.controllers.ContainsController(ControllerType.Joystick, gSnVYpLXDGjJOSQKMlgusDHHTCWh[i].tOUpYGeKfuNDITUOqTQoKmmdRoqe))
						{
							gSnVYpLXDGjJOSQKMlgusDHHTCWh[i].INAQEXZBaUMevJYlIZhmlocNQWUI = null;
						}
					}
				}

				public PILdMxjsHkBmDykRUqypsInnOUDKA AsxiJmiuEtKWeOJloRPztouBBjojA(int P_0)
				{
					int num = HYvTPQePzrQJUVCkUbooiCEWBsZaA(P_0);
					if (num < 0)
					{
						return null;
					}
					return gSnVYpLXDGjJOSQKMlgusDHHTCWh[num];
				}

				public bool yXMZoBpZgTkBTjtsNhUUGurzCRRp(int P_0)
				{
					for (int i = 0; i < gSnVYpLXDGjJOSQKMlgusDHHTCWh.Count; i++)
					{
						if (gSnVYpLXDGjJOSQKMlgusDHHTCWh[i].tOUpYGeKfuNDITUOqTQoKmmdRoqe == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int HYvTPQePzrQJUVCkUbooiCEWBsZaA(int P_0)
				{
					for (int i = 0; i < gSnVYpLXDGjJOSQKMlgusDHHTCWh.Count; i++)
					{
						if (gSnVYpLXDGjJOSQKMlgusDHHTCWh[i].tOUpYGeKfuNDITUOqTQoKmmdRoqe == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void HPnMpFOmuzeEckbdmdppjeyIicDjc()
				{
					gSnVYpLXDGjJOSQKMlgusDHHTCWh.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class UjdTijXDeRPeNAPiPgvVvxyqXgvU : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int pOOvpxkPvoXtBjanOVlVtKZqcLFaA;

					private ActionElementMap VpUaehxffyGlSFgyKelxdDlMldyzA;

					private int YRiDKwTGCOgeGpjofORpXQPHNOwe;

					public MapHelper UqHnHLznmcethMNnzoTRnIUkibXL;

					private int KfoKyGoQmRaFUEDzawAoDJttgPcl;

					public int ealIXIjXRjqsbSlVRicJLZdsnOUE;

					private bool glGWPzXclaOclQnOSPGHkQqCvyEw;

					public bool AwQXujYfijUBBNUAAXERvCMLubPH;

					private int uBugRziKvELFXaHbYhlkdaCeUpQbb;

					private int hBWInTHXQVYEfxJlOTTTjVHpRILcA;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU FPvehiFcNExUXOpBCeNifAwaqQkJB;

					private int WHQdWTaNNQMTfZZeyzJPbPnWBCIuA;

					private int skiCxOEONMsosdGVHyahfjFIAPsbb;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA uRdkWKTHHsaLWSyVNDNFjuOnKkZr;

					private int GVCxTOPidGhexCoqznSaXFWKAYsMA;

					private int QHgRBokCezTtrfLmjAAazrXzehdM;

					private IEnumerator<ActionElementMap> XDvdqSBGfubjqAlDcVdIdzNaHOuNc;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return VpUaehxffyGlSFgyKelxdDlMldyzA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VpUaehxffyGlSFgyKelxdDlMldyzA;
						}
					}

					[DebuggerHidden]
					public UjdTijXDeRPeNAPiPgvVvxyqXgvU(int P_0)
					{
						pOOvpxkPvoXtBjanOVlVtKZqcLFaA = P_0;
						YRiDKwTGCOgeGpjofORpXQPHNOwe = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pOOvpxkPvoXtBjanOVlVtKZqcLFaA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aOSmHaNGcPeSlfdoIHftJDSZVGGPA();
							}
						}
						FPvehiFcNExUXOpBCeNifAwaqQkJB = null;
						uRdkWKTHHsaLWSyVNDNFjuOnKkZr = null;
						XDvdqSBGfubjqAlDcVdIdzNaHOuNc = null;
						pOOvpxkPvoXtBjanOVlVtKZqcLFaA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pOOvpxkPvoXtBjanOVlVtKZqcLFaA;
							MapHelper uqHnHLznmcethMNnzoTRnIUkibXL = UqHnHLznmcethMNnzoTRnIUkibXL;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pOOvpxkPvoXtBjanOVlVtKZqcLFaA = -3;
								goto IL_0177;
							}
							pOOvpxkPvoXtBjanOVlVtKZqcLFaA = -1;
							if (ReInput._id != uqHnHLznmcethMNnzoTRnIUkibXL.FvpSbjgVkHHcsEibBaxvEemsoaLB)
							{
								ReInput.CheckInitialized(uqHnHLznmcethMNnzoTRnIUkibXL.FvpSbjgVkHHcsEibBaxvEemsoaLB);
								return false;
							}
							if (KfoKyGoQmRaFUEDzawAoDJttgPcl < 0)
							{
								return false;
							}
							uBugRziKvELFXaHbYhlkdaCeUpQbb = uqHnHLznmcethMNnzoTRnIUkibXL.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
							hBWInTHXQVYEfxJlOTTTjVHpRILcA = 0;
							goto IL_01f7;
							IL_0177:
							if (XDvdqSBGfubjqAlDcVdIdzNaHOuNc.MoveNext())
							{
								ActionElementMap current = XDvdqSBGfubjqAlDcVdIdzNaHOuNc.Current;
								VpUaehxffyGlSFgyKelxdDlMldyzA = current;
								pOOvpxkPvoXtBjanOVlVtKZqcLFaA = 1;
								return true;
							}
							aOSmHaNGcPeSlfdoIHftJDSZVGGPA();
							XDvdqSBGfubjqAlDcVdIdzNaHOuNc = null;
							goto IL_0191;
							IL_0191:
							QHgRBokCezTtrfLmjAAazrXzehdM++;
							goto IL_01a3;
							IL_01cd:
							if (skiCxOEONMsosdGVHyahfjFIAPsbb < WHQdWTaNNQMTfZZeyzJPbPnWBCIuA)
							{
								uRdkWKTHHsaLWSyVNDNFjuOnKkZr = FPvehiFcNExUXOpBCeNifAwaqQkJB.LiHJOfWLuRlIpTeFwKoewXdglkyu(skiCxOEONMsosdGVHyahfjFIAPsbb).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								GVCxTOPidGhexCoqznSaXFWKAYsMA = uRdkWKTHHsaLWSyVNDNFjuOnKkZr.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								QHgRBokCezTtrfLmjAAazrXzehdM = 0;
								goto IL_01a3;
							}
							FPvehiFcNExUXOpBCeNifAwaqQkJB = null;
							hBWInTHXQVYEfxJlOTTTjVHpRILcA++;
							goto IL_01f7;
							IL_01a3:
							if (QHgRBokCezTtrfLmjAAazrXzehdM < GVCxTOPidGhexCoqznSaXFWKAYsMA)
							{
								if (uRdkWKTHHsaLWSyVNDNFjuOnKkZr.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(QHgRBokCezTtrfLmjAAazrXzehdM) is ControllerMapWithAxes controllerMapWithAxes && (!glGWPzXclaOclQnOSPGHkQqCvyEw || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(KfoKyGoQmRaFUEDzawAoDJttgPcl))
								{
									XDvdqSBGfubjqAlDcVdIdzNaHOuNc = controllerMapWithAxes.AxisMapsWithAction(KfoKyGoQmRaFUEDzawAoDJttgPcl, glGWPzXclaOclQnOSPGHkQqCvyEw).GetEnumerator();
									pOOvpxkPvoXtBjanOVlVtKZqcLFaA = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							uRdkWKTHHsaLWSyVNDNFjuOnKkZr = null;
							skiCxOEONMsosdGVHyahfjFIAPsbb++;
							goto IL_01cd;
							IL_01f7:
							if (hBWInTHXQVYEfxJlOTTTjVHpRILcA < uBugRziKvELFXaHbYhlkdaCeUpQbb)
							{
								FPvehiFcNExUXOpBCeNifAwaqQkJB = uqHnHLznmcethMNnzoTRnIUkibXL.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(hBWInTHXQVYEfxJlOTTTjVHpRILcA);
								WHQdWTaNNQMTfZZeyzJPbPnWBCIuA = FPvehiFcNExUXOpBCeNifAwaqQkJB.kVgCrHansgVHQdOwmDKoORLmXnGv;
								skiCxOEONMsosdGVHyahfjFIAPsbb = 0;
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

					private void aOSmHaNGcPeSlfdoIHftJDSZVGGPA()
					{
						pOOvpxkPvoXtBjanOVlVtKZqcLFaA = -1;
						if (XDvdqSBGfubjqAlDcVdIdzNaHOuNc != null)
						{
							XDvdqSBGfubjqAlDcVdIdzNaHOuNc.Dispose();
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
						UjdTijXDeRPeNAPiPgvVvxyqXgvU ujdTijXDeRPeNAPiPgvVvxyqXgvU;
						if (pOOvpxkPvoXtBjanOVlVtKZqcLFaA == -2 && YRiDKwTGCOgeGpjofORpXQPHNOwe == Environment.CurrentManagedThreadId)
						{
							pOOvpxkPvoXtBjanOVlVtKZqcLFaA = 0;
							ujdTijXDeRPeNAPiPgvVvxyqXgvU = this;
						}
						else
						{
							ujdTijXDeRPeNAPiPgvVvxyqXgvU = new UjdTijXDeRPeNAPiPgvVvxyqXgvU(0);
							ujdTijXDeRPeNAPiPgvVvxyqXgvU.UqHnHLznmcethMNnzoTRnIUkibXL = UqHnHLznmcethMNnzoTRnIUkibXL;
						}
						ujdTijXDeRPeNAPiPgvVvxyqXgvU.KfoKyGoQmRaFUEDzawAoDJttgPcl = ealIXIjXRjqsbSlVRicJLZdsnOUE;
						ujdTijXDeRPeNAPiPgvVvxyqXgvU.glGWPzXclaOclQnOSPGHkQqCvyEw = AwQXujYfijUBBNUAAXERvCMLubPH;
						return ujdTijXDeRPeNAPiPgvVvxyqXgvU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class TRPgshaHYVNXNIQJJSHQRsteOANV : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int wENHGmgWKIfgrRqCelrBOnHkCAZP;

					private ActionElementMap RxFIaIdwfpTqxmOjpUFCKYKBczDl;

					private int juCFEqEvqDvgxOPvsCqKUfEANSfbA;

					public MapHelper WZxBMyssScavFnNeGZxFLmxAeAsC;

					private int StEDxJDCzMuRCNPZUJJOxWalJboJA;

					public int IxhrTPtNjBzqPWobCvNnjopADOMP;

					private bool WWWAQMnQrObJpkcMxnohstUxUEqk;

					public bool kKWQQLiCscBGytlMqcrOAaHnfNCjA;

					private int bdVfQxAdieSPAiShhmNMYKyMSmMx;

					private int yXiClKJGRXXnFeLQrxbmeryroTYfb;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU dHjMxHrtQGSalngSVBmAeQRkwOKHA;

					private int oWJLXhMDDLzTnkVOymVlBIbWfagm;

					private int SwCTIlUzxzQceXfTjsjBbsjvGErr;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA OPSJMlspWOXvSzgQRGDDFoPTGKnhb;

					private int BqpaGxQCeZthaDGphftSnLQgRqKA;

					private int kmHkcWpjFZrtmPIXiPMvDewdEXsG;

					private IEnumerator<ActionElementMap> AplEmHgcKEdOfLBqQgYOuVUVcoHjb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return RxFIaIdwfpTqxmOjpUFCKYKBczDl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RxFIaIdwfpTqxmOjpUFCKYKBczDl;
						}
					}

					[DebuggerHidden]
					public TRPgshaHYVNXNIQJJSHQRsteOANV(int P_0)
					{
						wENHGmgWKIfgrRqCelrBOnHkCAZP = P_0;
						juCFEqEvqDvgxOPvsCqKUfEANSfbA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = wENHGmgWKIfgrRqCelrBOnHkCAZP;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								DDmSJIQIoxncUcIydhWAiaUjPhOuA();
							}
						}
						dHjMxHrtQGSalngSVBmAeQRkwOKHA = null;
						OPSJMlspWOXvSzgQRGDDFoPTGKnhb = null;
						AplEmHgcKEdOfLBqQgYOuVUVcoHjb = null;
						wENHGmgWKIfgrRqCelrBOnHkCAZP = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = wENHGmgWKIfgrRqCelrBOnHkCAZP;
							MapHelper wZxBMyssScavFnNeGZxFLmxAeAsC = WZxBMyssScavFnNeGZxFLmxAeAsC;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								wENHGmgWKIfgrRqCelrBOnHkCAZP = -3;
								goto IL_016c;
							}
							wENHGmgWKIfgrRqCelrBOnHkCAZP = -1;
							if (ReInput._id != wZxBMyssScavFnNeGZxFLmxAeAsC.FvpSbjgVkHHcsEibBaxvEemsoaLB)
							{
								ReInput.CheckInitialized(wZxBMyssScavFnNeGZxFLmxAeAsC.FvpSbjgVkHHcsEibBaxvEemsoaLB);
								return false;
							}
							if (StEDxJDCzMuRCNPZUJJOxWalJboJA < 0)
							{
								return false;
							}
							bdVfQxAdieSPAiShhmNMYKyMSmMx = wZxBMyssScavFnNeGZxFLmxAeAsC.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
							yXiClKJGRXXnFeLQrxbmeryroTYfb = 0;
							goto IL_01ec;
							IL_016c:
							if (AplEmHgcKEdOfLBqQgYOuVUVcoHjb.MoveNext())
							{
								ActionElementMap current = AplEmHgcKEdOfLBqQgYOuVUVcoHjb.Current;
								RxFIaIdwfpTqxmOjpUFCKYKBczDl = current;
								wENHGmgWKIfgrRqCelrBOnHkCAZP = 1;
								return true;
							}
							DDmSJIQIoxncUcIydhWAiaUjPhOuA();
							AplEmHgcKEdOfLBqQgYOuVUVcoHjb = null;
							goto IL_0186;
							IL_0186:
							kmHkcWpjFZrtmPIXiPMvDewdEXsG++;
							goto IL_0198;
							IL_01c2:
							if (SwCTIlUzxzQceXfTjsjBbsjvGErr < oWJLXhMDDLzTnkVOymVlBIbWfagm)
							{
								OPSJMlspWOXvSzgQRGDDFoPTGKnhb = dHjMxHrtQGSalngSVBmAeQRkwOKHA.LiHJOfWLuRlIpTeFwKoewXdglkyu(SwCTIlUzxzQceXfTjsjBbsjvGErr).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								BqpaGxQCeZthaDGphftSnLQgRqKA = OPSJMlspWOXvSzgQRGDDFoPTGKnhb.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								kmHkcWpjFZrtmPIXiPMvDewdEXsG = 0;
								goto IL_0198;
							}
							dHjMxHrtQGSalngSVBmAeQRkwOKHA = null;
							yXiClKJGRXXnFeLQrxbmeryroTYfb++;
							goto IL_01ec;
							IL_0198:
							if (kmHkcWpjFZrtmPIXiPMvDewdEXsG < BqpaGxQCeZthaDGphftSnLQgRqKA)
							{
								ControllerMap controllerMap = OPSJMlspWOXvSzgQRGDDFoPTGKnhb.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(kmHkcWpjFZrtmPIXiPMvDewdEXsG);
								if ((!WWWAQMnQrObJpkcMxnohstUxUEqk || controllerMap.enabled) && controllerMap.ContainsAction(StEDxJDCzMuRCNPZUJJOxWalJboJA))
								{
									AplEmHgcKEdOfLBqQgYOuVUVcoHjb = controllerMap.ButtonMapsWithAction(StEDxJDCzMuRCNPZUJJOxWalJboJA, WWWAQMnQrObJpkcMxnohstUxUEqk).GetEnumerator();
									wENHGmgWKIfgrRqCelrBOnHkCAZP = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							OPSJMlspWOXvSzgQRGDDFoPTGKnhb = null;
							SwCTIlUzxzQceXfTjsjBbsjvGErr++;
							goto IL_01c2;
							IL_01ec:
							if (yXiClKJGRXXnFeLQrxbmeryroTYfb < bdVfQxAdieSPAiShhmNMYKyMSmMx)
							{
								dHjMxHrtQGSalngSVBmAeQRkwOKHA = wZxBMyssScavFnNeGZxFLmxAeAsC.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(yXiClKJGRXXnFeLQrxbmeryroTYfb);
								oWJLXhMDDLzTnkVOymVlBIbWfagm = dHjMxHrtQGSalngSVBmAeQRkwOKHA.kVgCrHansgVHQdOwmDKoORLmXnGv;
								SwCTIlUzxzQceXfTjsjBbsjvGErr = 0;
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

					private void DDmSJIQIoxncUcIydhWAiaUjPhOuA()
					{
						wENHGmgWKIfgrRqCelrBOnHkCAZP = -1;
						if (AplEmHgcKEdOfLBqQgYOuVUVcoHjb != null)
						{
							AplEmHgcKEdOfLBqQgYOuVUVcoHjb.Dispose();
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
						TRPgshaHYVNXNIQJJSHQRsteOANV tRPgshaHYVNXNIQJJSHQRsteOANV;
						if (wENHGmgWKIfgrRqCelrBOnHkCAZP == -2 && juCFEqEvqDvgxOPvsCqKUfEANSfbA == Environment.CurrentManagedThreadId)
						{
							wENHGmgWKIfgrRqCelrBOnHkCAZP = 0;
							tRPgshaHYVNXNIQJJSHQRsteOANV = this;
						}
						else
						{
							tRPgshaHYVNXNIQJJSHQRsteOANV = new TRPgshaHYVNXNIQJJSHQRsteOANV(0);
							tRPgshaHYVNXNIQJJSHQRsteOANV.WZxBMyssScavFnNeGZxFLmxAeAsC = WZxBMyssScavFnNeGZxFLmxAeAsC;
						}
						tRPgshaHYVNXNIQJJSHQRsteOANV.StEDxJDCzMuRCNPZUJJOxWalJboJA = IxhrTPtNjBzqPWobCvNnjopADOMP;
						tRPgshaHYVNXNIQJJSHQRsteOANV.WWWAQMnQrObJpkcMxnohstUxUEqk = kKWQQLiCscBGytlMqcrOAaHnfNCjA;
						return tRPgshaHYVNXNIQJJSHQRsteOANV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class CfKYskAqKbOLsLnwACkrEyIAATsU : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int hGzonDJWyPLZzCDkzGLDDJvBXKoN;

					private ActionElementMap oLvcgSiJNxqwfVlzuBVxxEEgUnNDA;

					private int TesfJffCGOIRTLozOPWDWzKzymaL;

					private int cwzVPwnWSoFMLlhxjbOtffUJAVrvA;

					public int aNoXSfLpqOdZhBOvHSKJxUofuYDRA;

					public MapHelper NNEaaUXQijjugMFrvXyFpNwrrKrg;

					private ControllerType olUWCOyasADmGIIjKZICFxMtyHktA;

					public ControllerType nlliFjVwABwwlAzbrKqGRWFkCWEQ;

					private bool XdDmCDsfNZIhtRfwuusRokNPhJJB;

					public bool YeIkDvnLzqbvPmCjAfBqEFQiENTYA;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU OzGBVMYwbMeKslJnOkvmfCMCEiSiA;

					private int vRwZRfIZbNzEBduQRtmtyeHfhIeB;

					private IList<ControllerMap> khksrmjhFoDnIIsOnoCDfxcfWCqL;

					private int FpOnHxvOmBwcMGaaLAbcewdBzXex;

					private IEnumerator<ActionElementMap> WwnLNdAnPOYTmQDJhinbeaHAPuWJA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return oLvcgSiJNxqwfVlzuBVxxEEgUnNDA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oLvcgSiJNxqwfVlzuBVxxEEgUnNDA;
						}
					}

					[DebuggerHidden]
					public CfKYskAqKbOLsLnwACkrEyIAATsU(int P_0)
					{
						hGzonDJWyPLZzCDkzGLDDJvBXKoN = P_0;
						TesfJffCGOIRTLozOPWDWzKzymaL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hGzonDJWyPLZzCDkzGLDDJvBXKoN;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								qsWtckJZlHzJrxSKkHlnuFDDjfFV();
							}
						}
						OzGBVMYwbMeKslJnOkvmfCMCEiSiA = null;
						khksrmjhFoDnIIsOnoCDfxcfWCqL = null;
						WwnLNdAnPOYTmQDJhinbeaHAPuWJA = null;
						hGzonDJWyPLZzCDkzGLDDJvBXKoN = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hGzonDJWyPLZzCDkzGLDDJvBXKoN;
							MapHelper nNEaaUXQijjugMFrvXyFpNwrrKrg = NNEaaUXQijjugMFrvXyFpNwrrKrg;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hGzonDJWyPLZzCDkzGLDDJvBXKoN = -3;
								goto IL_0150;
							}
							hGzonDJWyPLZzCDkzGLDDJvBXKoN = -1;
							if (cwzVPwnWSoFMLlhxjbOtffUJAVrvA < 0)
							{
								return false;
							}
							OzGBVMYwbMeKslJnOkvmfCMCEiSiA = nNEaaUXQijjugMFrvXyFpNwrrKrg.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(olUWCOyasADmGIIjKZICFxMtyHktA);
							vRwZRfIZbNzEBduQRtmtyeHfhIeB = 0;
							goto IL_01ab;
							IL_0150:
							if (WwnLNdAnPOYTmQDJhinbeaHAPuWJA.MoveNext())
							{
								ActionElementMap current = WwnLNdAnPOYTmQDJhinbeaHAPuWJA.Current;
								oLvcgSiJNxqwfVlzuBVxxEEgUnNDA = current;
								hGzonDJWyPLZzCDkzGLDDJvBXKoN = 1;
								return true;
							}
							qsWtckJZlHzJrxSKkHlnuFDDjfFV();
							WwnLNdAnPOYTmQDJhinbeaHAPuWJA = null;
							goto IL_016a;
							IL_017c:
							if (FpOnHxvOmBwcMGaaLAbcewdBzXex < khksrmjhFoDnIIsOnoCDfxcfWCqL.Count)
							{
								if (!(khksrmjhFoDnIIsOnoCDfxcfWCqL[FpOnHxvOmBwcMGaaLAbcewdBzXex] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!XdDmCDsfNZIhtRfwuusRokNPhJJB || khksrmjhFoDnIIsOnoCDfxcfWCqL[FpOnHxvOmBwcMGaaLAbcewdBzXex].enabled) && khksrmjhFoDnIIsOnoCDfxcfWCqL[FpOnHxvOmBwcMGaaLAbcewdBzXex].ContainsAction(cwzVPwnWSoFMLlhxjbOtffUJAVrvA))
								{
									WwnLNdAnPOYTmQDJhinbeaHAPuWJA = (khksrmjhFoDnIIsOnoCDfxcfWCqL[FpOnHxvOmBwcMGaaLAbcewdBzXex] as ControllerMapWithAxes).AxisMapsWithAction(cwzVPwnWSoFMLlhxjbOtffUJAVrvA, XdDmCDsfNZIhtRfwuusRokNPhJJB).GetEnumerator();
									hGzonDJWyPLZzCDkzGLDDJvBXKoN = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							khksrmjhFoDnIIsOnoCDfxcfWCqL = null;
							vRwZRfIZbNzEBduQRtmtyeHfhIeB++;
							goto IL_01ab;
							IL_016a:
							FpOnHxvOmBwcMGaaLAbcewdBzXex++;
							goto IL_017c;
							IL_01ab:
							if (vRwZRfIZbNzEBduQRtmtyeHfhIeB < OzGBVMYwbMeKslJnOkvmfCMCEiSiA.kVgCrHansgVHQdOwmDKoORLmXnGv)
							{
								khksrmjhFoDnIIsOnoCDfxcfWCqL = OzGBVMYwbMeKslJnOkvmfCMCEiSiA.LiHJOfWLuRlIpTeFwKoewXdglkyu(vRwZRfIZbNzEBduQRtmtyeHfhIeB).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
								FpOnHxvOmBwcMGaaLAbcewdBzXex = 0;
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

					private void qsWtckJZlHzJrxSKkHlnuFDDjfFV()
					{
						hGzonDJWyPLZzCDkzGLDDJvBXKoN = -1;
						if (WwnLNdAnPOYTmQDJhinbeaHAPuWJA != null)
						{
							WwnLNdAnPOYTmQDJhinbeaHAPuWJA.Dispose();
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
						CfKYskAqKbOLsLnwACkrEyIAATsU cfKYskAqKbOLsLnwACkrEyIAATsU;
						if (hGzonDJWyPLZzCDkzGLDDJvBXKoN == -2 && TesfJffCGOIRTLozOPWDWzKzymaL == Environment.CurrentManagedThreadId)
						{
							hGzonDJWyPLZzCDkzGLDDJvBXKoN = 0;
							cfKYskAqKbOLsLnwACkrEyIAATsU = this;
						}
						else
						{
							cfKYskAqKbOLsLnwACkrEyIAATsU = new CfKYskAqKbOLsLnwACkrEyIAATsU(0);
							cfKYskAqKbOLsLnwACkrEyIAATsU.NNEaaUXQijjugMFrvXyFpNwrrKrg = NNEaaUXQijjugMFrvXyFpNwrrKrg;
						}
						cfKYskAqKbOLsLnwACkrEyIAATsU.olUWCOyasADmGIIjKZICFxMtyHktA = nlliFjVwABwwlAzbrKqGRWFkCWEQ;
						cfKYskAqKbOLsLnwACkrEyIAATsU.cwzVPwnWSoFMLlhxjbOtffUJAVrvA = aNoXSfLpqOdZhBOvHSKJxUofuYDRA;
						cfKYskAqKbOLsLnwACkrEyIAATsU.XdDmCDsfNZIhtRfwuusRokNPhJJB = YeIkDvnLzqbvPmCjAfBqEFQiENTYA;
						return cfKYskAqKbOLsLnwACkrEyIAATsU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class KExSwRuqNmpfTDSDVUKtxJrcdIudA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int yVfWfwDuzlmwZTrDVhVOoCqLDZzH;

					private ActionElementMap TZUAWjUDSHPvIpWScyDeXDdESTcI;

					private int nqZaRTyEpWMDeypOLxCQskJWXUig;

					private int DAfWUxIsOoVIeBYXLbLJnrkNyoHL;

					public int MuQMpUyXHeRJzZgKLihqgmgCILNl;

					public MapHelper tkIsicupnJPokKjTygJvkiiAEgRAb;

					private ControllerType sbtnuqwTptgImkbFNnFiPqrTqFtq;

					public ControllerType DNAyoDTDZpyXHrDfQAyELscJcsJb;

					private int ndXixUqdefZaSsLblPfuSToqRltP;

					public int gXsNGgpldwKaoWfAJASjpZpiAdIq;

					private bool mcESkVxlwaiNtYHDzfLpkTBvVDywA;

					public bool FmuRwKobcfFluBqCXUnqShaEXIlCA;

					private IList<ControllerMap> mQTgNaIJynTNkXKEPhIrdnvYMSrt;

					private int mrRdldhTzqRhtlROsAgXLlSZWzxpA;

					private IEnumerator<ActionElementMap> yCGmlrnTSkplHFeKLDjsjaTYhOXW;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return TZUAWjUDSHPvIpWScyDeXDdESTcI;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TZUAWjUDSHPvIpWScyDeXDdESTcI;
						}
					}

					[DebuggerHidden]
					public KExSwRuqNmpfTDSDVUKtxJrcdIudA(int P_0)
					{
						yVfWfwDuzlmwZTrDVhVOoCqLDZzH = P_0;
						nqZaRTyEpWMDeypOLxCQskJWXUig = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yVfWfwDuzlmwZTrDVhVOoCqLDZzH;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								pgAdEAppDkOVLatygDwpekaKEZko();
							}
						}
						mQTgNaIJynTNkXKEPhIrdnvYMSrt = null;
						yCGmlrnTSkplHFeKLDjsjaTYhOXW = null;
						yVfWfwDuzlmwZTrDVhVOoCqLDZzH = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = yVfWfwDuzlmwZTrDVhVOoCqLDZzH;
							MapHelper mapHelper = tkIsicupnJPokKjTygJvkiiAEgRAb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yVfWfwDuzlmwZTrDVhVOoCqLDZzH = -3;
								goto IL_014f;
							}
							yVfWfwDuzlmwZTrDVhVOoCqLDZzH = -1;
							if (DAfWUxIsOoVIeBYXLbLJnrkNyoHL < 0)
							{
								return false;
							}
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(sbtnuqwTptgImkbFNnFiPqrTqFtq);
							int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(ndXixUqdefZaSsLblPfuSToqRltP);
							if (num2 < 0)
							{
								return false;
							}
							mQTgNaIJynTNkXKEPhIrdnvYMSrt = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num2).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
							mrRdldhTzqRhtlROsAgXLlSZWzxpA = 0;
							goto IL_017b;
							IL_014f:
							if (yCGmlrnTSkplHFeKLDjsjaTYhOXW.MoveNext())
							{
								ActionElementMap current = yCGmlrnTSkplHFeKLDjsjaTYhOXW.Current;
								TZUAWjUDSHPvIpWScyDeXDdESTcI = current;
								yVfWfwDuzlmwZTrDVhVOoCqLDZzH = 1;
								return true;
							}
							pgAdEAppDkOVLatygDwpekaKEZko();
							yCGmlrnTSkplHFeKLDjsjaTYhOXW = null;
							goto IL_0169;
							IL_017b:
							if (mrRdldhTzqRhtlROsAgXLlSZWzxpA < mQTgNaIJynTNkXKEPhIrdnvYMSrt.Count)
							{
								if (!(mQTgNaIJynTNkXKEPhIrdnvYMSrt[mrRdldhTzqRhtlROsAgXLlSZWzxpA] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!mcESkVxlwaiNtYHDzfLpkTBvVDywA || mQTgNaIJynTNkXKEPhIrdnvYMSrt[mrRdldhTzqRhtlROsAgXLlSZWzxpA].enabled) && mQTgNaIJynTNkXKEPhIrdnvYMSrt[mrRdldhTzqRhtlROsAgXLlSZWzxpA].ContainsAction(DAfWUxIsOoVIeBYXLbLJnrkNyoHL))
								{
									yCGmlrnTSkplHFeKLDjsjaTYhOXW = (mQTgNaIJynTNkXKEPhIrdnvYMSrt[mrRdldhTzqRhtlROsAgXLlSZWzxpA] as ControllerMapWithAxes).AxisMapsWithAction(DAfWUxIsOoVIeBYXLbLJnrkNyoHL, mcESkVxlwaiNtYHDzfLpkTBvVDywA).GetEnumerator();
									yVfWfwDuzlmwZTrDVhVOoCqLDZzH = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							mrRdldhTzqRhtlROsAgXLlSZWzxpA++;
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

					private void pgAdEAppDkOVLatygDwpekaKEZko()
					{
						yVfWfwDuzlmwZTrDVhVOoCqLDZzH = -1;
						if (yCGmlrnTSkplHFeKLDjsjaTYhOXW != null)
						{
							yCGmlrnTSkplHFeKLDjsjaTYhOXW.Dispose();
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
						KExSwRuqNmpfTDSDVUKtxJrcdIudA kExSwRuqNmpfTDSDVUKtxJrcdIudA;
						if (yVfWfwDuzlmwZTrDVhVOoCqLDZzH == -2 && nqZaRTyEpWMDeypOLxCQskJWXUig == Environment.CurrentManagedThreadId)
						{
							yVfWfwDuzlmwZTrDVhVOoCqLDZzH = 0;
							kExSwRuqNmpfTDSDVUKtxJrcdIudA = this;
						}
						else
						{
							kExSwRuqNmpfTDSDVUKtxJrcdIudA = new KExSwRuqNmpfTDSDVUKtxJrcdIudA(0);
							kExSwRuqNmpfTDSDVUKtxJrcdIudA.tkIsicupnJPokKjTygJvkiiAEgRAb = tkIsicupnJPokKjTygJvkiiAEgRAb;
						}
						kExSwRuqNmpfTDSDVUKtxJrcdIudA.sbtnuqwTptgImkbFNnFiPqrTqFtq = DNAyoDTDZpyXHrDfQAyELscJcsJb;
						kExSwRuqNmpfTDSDVUKtxJrcdIudA.ndXixUqdefZaSsLblPfuSToqRltP = gXsNGgpldwKaoWfAJASjpZpiAdIq;
						kExSwRuqNmpfTDSDVUKtxJrcdIudA.DAfWUxIsOoVIeBYXLbLJnrkNyoHL = MuQMpUyXHeRJzZgKLihqgmgCILNl;
						kExSwRuqNmpfTDSDVUKtxJrcdIudA.mcESkVxlwaiNtYHDzfLpkTBvVDywA = FmuRwKobcfFluBqCXUnqShaEXIlCA;
						return kExSwRuqNmpfTDSDVUKtxJrcdIudA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class VlkOjZwflTwcKImrejQCbMEHdchi : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int jqHLhSvupeKoszEMNvPLKwppfmbN;

					private ActionElementMap RXePdbMdYxBzchnilduncNGgSODYA;

					private int xbRrmWTcTIccSzqtgjChWBMwjAVB;

					private int yZALUVCtlncynlcJAMrKLeqhGDIU;

					public int MLZClwPxoTsJvWCJMXrClcfLNCcI;

					public MapHelper cDRupiMNSoSTxcDyoqbOdHxWQqpl;

					private ControllerType WsukLkaqCbCeqFiviYofvWYNUPbP;

					public ControllerType dHePdrYMLqSfedkZIdzPGtkbSvXj;

					private bool aVycboEyqcFFbvUoEHscCbWHIeoQ;

					public bool iggkGKxirQLaPBsQcCJFMBvgWEhN;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU dlcQdiJydnbxFdGoAsQcHclOKQJm;

					private int wtJcvACdJdnacnPRUOFGwgBzFMeCb;

					private IList<ControllerMap> yNJYBCwqxaGRHXmAoebJZUdxbKHW;

					private int lJdTAhagMLcJsFDQCnudwSmfhjUN;

					private IEnumerator<ActionElementMap> DMobBMaDcTkEdtuFnTPyFmNbHwvbA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return RXePdbMdYxBzchnilduncNGgSODYA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RXePdbMdYxBzchnilduncNGgSODYA;
						}
					}

					[DebuggerHidden]
					public VlkOjZwflTwcKImrejQCbMEHdchi(int P_0)
					{
						jqHLhSvupeKoszEMNvPLKwppfmbN = P_0;
						xbRrmWTcTIccSzqtgjChWBMwjAVB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = jqHLhSvupeKoszEMNvPLKwppfmbN;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								DUCLwXWtCETxhYdPRtVCcYxlsFbg();
							}
						}
						dlcQdiJydnbxFdGoAsQcHclOKQJm = null;
						yNJYBCwqxaGRHXmAoebJZUdxbKHW = null;
						DMobBMaDcTkEdtuFnTPyFmNbHwvbA = null;
						jqHLhSvupeKoszEMNvPLKwppfmbN = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = jqHLhSvupeKoszEMNvPLKwppfmbN;
							MapHelper mapHelper = cDRupiMNSoSTxcDyoqbOdHxWQqpl;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								jqHLhSvupeKoszEMNvPLKwppfmbN = -3;
								goto IL_012c;
							}
							jqHLhSvupeKoszEMNvPLKwppfmbN = -1;
							if (yZALUVCtlncynlcJAMrKLeqhGDIU < 0)
							{
								return false;
							}
							dlcQdiJydnbxFdGoAsQcHclOKQJm = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(WsukLkaqCbCeqFiviYofvWYNUPbP);
							wtJcvACdJdnacnPRUOFGwgBzFMeCb = 0;
							goto IL_0187;
							IL_012c:
							if (DMobBMaDcTkEdtuFnTPyFmNbHwvbA.MoveNext())
							{
								ActionElementMap current = DMobBMaDcTkEdtuFnTPyFmNbHwvbA.Current;
								RXePdbMdYxBzchnilduncNGgSODYA = current;
								jqHLhSvupeKoszEMNvPLKwppfmbN = 1;
								return true;
							}
							DUCLwXWtCETxhYdPRtVCcYxlsFbg();
							DMobBMaDcTkEdtuFnTPyFmNbHwvbA = null;
							goto IL_0146;
							IL_0158:
							if (lJdTAhagMLcJsFDQCnudwSmfhjUN < yNJYBCwqxaGRHXmAoebJZUdxbKHW.Count)
							{
								if ((!aVycboEyqcFFbvUoEHscCbWHIeoQ || yNJYBCwqxaGRHXmAoebJZUdxbKHW[lJdTAhagMLcJsFDQCnudwSmfhjUN].enabled) && yNJYBCwqxaGRHXmAoebJZUdxbKHW[lJdTAhagMLcJsFDQCnudwSmfhjUN].ContainsAction(yZALUVCtlncynlcJAMrKLeqhGDIU))
								{
									DMobBMaDcTkEdtuFnTPyFmNbHwvbA = yNJYBCwqxaGRHXmAoebJZUdxbKHW[lJdTAhagMLcJsFDQCnudwSmfhjUN].ButtonMapsWithAction(yZALUVCtlncynlcJAMrKLeqhGDIU, aVycboEyqcFFbvUoEHscCbWHIeoQ).GetEnumerator();
									jqHLhSvupeKoszEMNvPLKwppfmbN = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							yNJYBCwqxaGRHXmAoebJZUdxbKHW = null;
							wtJcvACdJdnacnPRUOFGwgBzFMeCb++;
							goto IL_0187;
							IL_0146:
							lJdTAhagMLcJsFDQCnudwSmfhjUN++;
							goto IL_0158;
							IL_0187:
							if (wtJcvACdJdnacnPRUOFGwgBzFMeCb < dlcQdiJydnbxFdGoAsQcHclOKQJm.kVgCrHansgVHQdOwmDKoORLmXnGv)
							{
								yNJYBCwqxaGRHXmAoebJZUdxbKHW = dlcQdiJydnbxFdGoAsQcHclOKQJm.LiHJOfWLuRlIpTeFwKoewXdglkyu(wtJcvACdJdnacnPRUOFGwgBzFMeCb).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
								lJdTAhagMLcJsFDQCnudwSmfhjUN = 0;
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

					private void DUCLwXWtCETxhYdPRtVCcYxlsFbg()
					{
						jqHLhSvupeKoszEMNvPLKwppfmbN = -1;
						if (DMobBMaDcTkEdtuFnTPyFmNbHwvbA != null)
						{
							DMobBMaDcTkEdtuFnTPyFmNbHwvbA.Dispose();
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
						VlkOjZwflTwcKImrejQCbMEHdchi vlkOjZwflTwcKImrejQCbMEHdchi;
						if (jqHLhSvupeKoszEMNvPLKwppfmbN == -2 && xbRrmWTcTIccSzqtgjChWBMwjAVB == Environment.CurrentManagedThreadId)
						{
							jqHLhSvupeKoszEMNvPLKwppfmbN = 0;
							vlkOjZwflTwcKImrejQCbMEHdchi = this;
						}
						else
						{
							vlkOjZwflTwcKImrejQCbMEHdchi = new VlkOjZwflTwcKImrejQCbMEHdchi(0);
							vlkOjZwflTwcKImrejQCbMEHdchi.cDRupiMNSoSTxcDyoqbOdHxWQqpl = cDRupiMNSoSTxcDyoqbOdHxWQqpl;
						}
						vlkOjZwflTwcKImrejQCbMEHdchi.WsukLkaqCbCeqFiviYofvWYNUPbP = dHePdrYMLqSfedkZIdzPGtkbSvXj;
						vlkOjZwflTwcKImrejQCbMEHdchi.yZALUVCtlncynlcJAMrKLeqhGDIU = MLZClwPxoTsJvWCJMXrClcfLNCcI;
						vlkOjZwflTwcKImrejQCbMEHdchi.aVycboEyqcFFbvUoEHscCbWHIeoQ = iggkGKxirQLaPBsQcCJFMBvgWEhN;
						return vlkOjZwflTwcKImrejQCbMEHdchi;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class ckhdDFxLBZBdGQAnbXbhvFDjFvHU : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int esvRpXlFmSorVfjtXwKqCWkOOYLS;

					private ActionElementMap zfubWAAYtWMwgFbTRimyOXXozHykA;

					private int QlTeyviRmQRyDAbjLXylCNKEXijU;

					private int NFAijiDZDRfCcKJfSXWXpyJmfvmc;

					public int QtMHJnueBKvrTHCSsBFBGPynGOXQA;

					public MapHelper npOGLTlFwZFDCgnWRykqIYdShKmR;

					private ControllerType xYTqelucOaxpSzECVAKwROHGHnhjA;

					public ControllerType cHLmvmCAVkUCfJJDxsSzymqmiRFD;

					private int FxQJrFdPDYWcGZJDFsAjTAMzgYTbA;

					public int thVyiQSDsInltKyxfoRiufZWsmBs;

					private bool hTRkkpnkSumHkzKeOPVdfPuynccY;

					public bool sIEeIEDYuDkcJlhdLXsHIOzsfQwEA;

					private IList<ControllerMap> jKXvkKMwjSBxMsAzzLQuJqvlwTHR;

					private int ikYDiwfERSiAfcqRmVvLDFwgPPwuA;

					private IEnumerator<ActionElementMap> xhHklHjhmkeudFHXDAIKbZPUiQoiA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return zfubWAAYtWMwgFbTRimyOXXozHykA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zfubWAAYtWMwgFbTRimyOXXozHykA;
						}
					}

					[DebuggerHidden]
					public ckhdDFxLBZBdGQAnbXbhvFDjFvHU(int P_0)
					{
						esvRpXlFmSorVfjtXwKqCWkOOYLS = P_0;
						QlTeyviRmQRyDAbjLXylCNKEXijU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = esvRpXlFmSorVfjtXwKqCWkOOYLS;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								AFUeNUCXEVfwpMnNuyCOSMGTgDThb();
							}
						}
						jKXvkKMwjSBxMsAzzLQuJqvlwTHR = null;
						xhHklHjhmkeudFHXDAIKbZPUiQoiA = null;
						esvRpXlFmSorVfjtXwKqCWkOOYLS = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = esvRpXlFmSorVfjtXwKqCWkOOYLS;
							MapHelper mapHelper = npOGLTlFwZFDCgnWRykqIYdShKmR;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								esvRpXlFmSorVfjtXwKqCWkOOYLS = -3;
								goto IL_012b;
							}
							esvRpXlFmSorVfjtXwKqCWkOOYLS = -1;
							if (NFAijiDZDRfCcKJfSXWXpyJmfvmc < 0)
							{
								return false;
							}
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(xYTqelucOaxpSzECVAKwROHGHnhjA);
							int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(FxQJrFdPDYWcGZJDFsAjTAMzgYTbA);
							if (num2 < 0)
							{
								return false;
							}
							jKXvkKMwjSBxMsAzzLQuJqvlwTHR = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num2).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
							ikYDiwfERSiAfcqRmVvLDFwgPPwuA = 0;
							goto IL_0157;
							IL_012b:
							if (xhHklHjhmkeudFHXDAIKbZPUiQoiA.MoveNext())
							{
								ActionElementMap current = xhHklHjhmkeudFHXDAIKbZPUiQoiA.Current;
								zfubWAAYtWMwgFbTRimyOXXozHykA = current;
								esvRpXlFmSorVfjtXwKqCWkOOYLS = 1;
								return true;
							}
							AFUeNUCXEVfwpMnNuyCOSMGTgDThb();
							xhHklHjhmkeudFHXDAIKbZPUiQoiA = null;
							goto IL_0145;
							IL_0157:
							if (ikYDiwfERSiAfcqRmVvLDFwgPPwuA < jKXvkKMwjSBxMsAzzLQuJqvlwTHR.Count)
							{
								if ((!hTRkkpnkSumHkzKeOPVdfPuynccY || jKXvkKMwjSBxMsAzzLQuJqvlwTHR[ikYDiwfERSiAfcqRmVvLDFwgPPwuA].enabled) && jKXvkKMwjSBxMsAzzLQuJqvlwTHR[ikYDiwfERSiAfcqRmVvLDFwgPPwuA].ContainsAction(NFAijiDZDRfCcKJfSXWXpyJmfvmc))
								{
									xhHklHjhmkeudFHXDAIKbZPUiQoiA = jKXvkKMwjSBxMsAzzLQuJqvlwTHR[ikYDiwfERSiAfcqRmVvLDFwgPPwuA].ButtonMapsWithAction(NFAijiDZDRfCcKJfSXWXpyJmfvmc, hTRkkpnkSumHkzKeOPVdfPuynccY).GetEnumerator();
									esvRpXlFmSorVfjtXwKqCWkOOYLS = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							ikYDiwfERSiAfcqRmVvLDFwgPPwuA++;
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

					private void AFUeNUCXEVfwpMnNuyCOSMGTgDThb()
					{
						esvRpXlFmSorVfjtXwKqCWkOOYLS = -1;
						if (xhHklHjhmkeudFHXDAIKbZPUiQoiA != null)
						{
							xhHklHjhmkeudFHXDAIKbZPUiQoiA.Dispose();
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
						ckhdDFxLBZBdGQAnbXbhvFDjFvHU ckhdDFxLBZBdGQAnbXbhvFDjFvHU2;
						if (esvRpXlFmSorVfjtXwKqCWkOOYLS == -2 && QlTeyviRmQRyDAbjLXylCNKEXijU == Environment.CurrentManagedThreadId)
						{
							esvRpXlFmSorVfjtXwKqCWkOOYLS = 0;
							ckhdDFxLBZBdGQAnbXbhvFDjFvHU2 = this;
						}
						else
						{
							ckhdDFxLBZBdGQAnbXbhvFDjFvHU2 = new ckhdDFxLBZBdGQAnbXbhvFDjFvHU(0);
							ckhdDFxLBZBdGQAnbXbhvFDjFvHU2.npOGLTlFwZFDCgnWRykqIYdShKmR = npOGLTlFwZFDCgnWRykqIYdShKmR;
						}
						ckhdDFxLBZBdGQAnbXbhvFDjFvHU2.xYTqelucOaxpSzECVAKwROHGHnhjA = cHLmvmCAVkUCfJJDxsSzymqmiRFD;
						ckhdDFxLBZBdGQAnbXbhvFDjFvHU2.FxQJrFdPDYWcGZJDFsAjTAMzgYTbA = thVyiQSDsInltKyxfoRiufZWsmBs;
						ckhdDFxLBZBdGQAnbXbhvFDjFvHU2.NFAijiDZDRfCcKJfSXWXpyJmfvmc = QtMHJnueBKvrTHCSsBFBGPynGOXQA;
						ckhdDFxLBZBdGQAnbXbhvFDjFvHU2.hTRkkpnkSumHkzKeOPVdfPuynccY = sIEeIEDYuDkcJlhdLXsHIOzsfQwEA;
						return ckhdDFxLBZBdGQAnbXbhvFDjFvHU2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class qceelYWiEIMAbJqefzURPLnHwwOI : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int tWKGlmDoPtwJtDOmBifXCmhrUvXhA;

					private ActionElementMap LXLmuwsKMlqPMXvBzKxyisoKmHQS;

					private int RfGnTEgNGEjeDRliIVwXcFwUeKjl;

					private int OcgxSTdNCKKyjHjIBNUQrQgPVmJu;

					public int rVSifACnHAdYSXzmNLoBUXbEvWjD;

					public MapHelper oQBVNUmAUDarHJEzrCiqGdbrJEiEb;

					private ControllerType IgTrhoKqVGMqbIoCCzXeBCNifaab;

					public ControllerType OcacxEeZnQyVRzTMksczZDioXCwv;

					private bool KeHPdIdUuracFviChumKjosoaOBn;

					public bool hnPgdsneTTNrmlToGqvSMBLNhexfA;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU TfROTBZhzozQYEfXquKbyqcNWFeB;

					private int BfkrrkcXIbiaazkSTHEwNduHhlbg;

					private IList<ControllerMap> DYSkMMGSweaUiIeywSSIMEVWeoBFA;

					private int slrBlGhDIlVKYdqGxBTtZYgyPewnA;

					private IEnumerator<ActionElementMap> dSGUJyewbnZSpvIOddEbQpCAHgHDA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return LXLmuwsKMlqPMXvBzKxyisoKmHQS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LXLmuwsKMlqPMXvBzKxyisoKmHQS;
						}
					}

					[DebuggerHidden]
					public qceelYWiEIMAbJqefzURPLnHwwOI(int P_0)
					{
						tWKGlmDoPtwJtDOmBifXCmhrUvXhA = P_0;
						RfGnTEgNGEjeDRliIVwXcFwUeKjl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = tWKGlmDoPtwJtDOmBifXCmhrUvXhA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								akNpeqscOTaaKvBYgfpOYheHEnpiA();
							}
						}
						TfROTBZhzozQYEfXquKbyqcNWFeB = null;
						DYSkMMGSweaUiIeywSSIMEVWeoBFA = null;
						dSGUJyewbnZSpvIOddEbQpCAHgHDA = null;
						tWKGlmDoPtwJtDOmBifXCmhrUvXhA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = tWKGlmDoPtwJtDOmBifXCmhrUvXhA;
							MapHelper mapHelper = oQBVNUmAUDarHJEzrCiqGdbrJEiEb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								tWKGlmDoPtwJtDOmBifXCmhrUvXhA = -3;
								goto IL_012c;
							}
							tWKGlmDoPtwJtDOmBifXCmhrUvXhA = -1;
							if (OcgxSTdNCKKyjHjIBNUQrQgPVmJu < 0)
							{
								return false;
							}
							TfROTBZhzozQYEfXquKbyqcNWFeB = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(IgTrhoKqVGMqbIoCCzXeBCNifaab);
							BfkrrkcXIbiaazkSTHEwNduHhlbg = 0;
							goto IL_0187;
							IL_012c:
							if (dSGUJyewbnZSpvIOddEbQpCAHgHDA.MoveNext())
							{
								ActionElementMap current = dSGUJyewbnZSpvIOddEbQpCAHgHDA.Current;
								LXLmuwsKMlqPMXvBzKxyisoKmHQS = current;
								tWKGlmDoPtwJtDOmBifXCmhrUvXhA = 1;
								return true;
							}
							akNpeqscOTaaKvBYgfpOYheHEnpiA();
							dSGUJyewbnZSpvIOddEbQpCAHgHDA = null;
							goto IL_0146;
							IL_0158:
							if (slrBlGhDIlVKYdqGxBTtZYgyPewnA < DYSkMMGSweaUiIeywSSIMEVWeoBFA.Count)
							{
								if ((!KeHPdIdUuracFviChumKjosoaOBn || DYSkMMGSweaUiIeywSSIMEVWeoBFA[slrBlGhDIlVKYdqGxBTtZYgyPewnA].enabled) && DYSkMMGSweaUiIeywSSIMEVWeoBFA[slrBlGhDIlVKYdqGxBTtZYgyPewnA].ContainsAction(OcgxSTdNCKKyjHjIBNUQrQgPVmJu))
								{
									dSGUJyewbnZSpvIOddEbQpCAHgHDA = DYSkMMGSweaUiIeywSSIMEVWeoBFA[slrBlGhDIlVKYdqGxBTtZYgyPewnA].ElementMapsWithAction(OcgxSTdNCKKyjHjIBNUQrQgPVmJu, KeHPdIdUuracFviChumKjosoaOBn).GetEnumerator();
									tWKGlmDoPtwJtDOmBifXCmhrUvXhA = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							DYSkMMGSweaUiIeywSSIMEVWeoBFA = null;
							BfkrrkcXIbiaazkSTHEwNduHhlbg++;
							goto IL_0187;
							IL_0146:
							slrBlGhDIlVKYdqGxBTtZYgyPewnA++;
							goto IL_0158;
							IL_0187:
							if (BfkrrkcXIbiaazkSTHEwNduHhlbg < TfROTBZhzozQYEfXquKbyqcNWFeB.kVgCrHansgVHQdOwmDKoORLmXnGv)
							{
								DYSkMMGSweaUiIeywSSIMEVWeoBFA = TfROTBZhzozQYEfXquKbyqcNWFeB.LiHJOfWLuRlIpTeFwKoewXdglkyu(BfkrrkcXIbiaazkSTHEwNduHhlbg).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
								slrBlGhDIlVKYdqGxBTtZYgyPewnA = 0;
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

					private void akNpeqscOTaaKvBYgfpOYheHEnpiA()
					{
						tWKGlmDoPtwJtDOmBifXCmhrUvXhA = -1;
						if (dSGUJyewbnZSpvIOddEbQpCAHgHDA != null)
						{
							dSGUJyewbnZSpvIOddEbQpCAHgHDA.Dispose();
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
						qceelYWiEIMAbJqefzURPLnHwwOI qceelYWiEIMAbJqefzURPLnHwwOI2;
						if (tWKGlmDoPtwJtDOmBifXCmhrUvXhA == -2 && RfGnTEgNGEjeDRliIVwXcFwUeKjl == Environment.CurrentManagedThreadId)
						{
							tWKGlmDoPtwJtDOmBifXCmhrUvXhA = 0;
							qceelYWiEIMAbJqefzURPLnHwwOI2 = this;
						}
						else
						{
							qceelYWiEIMAbJqefzURPLnHwwOI2 = new qceelYWiEIMAbJqefzURPLnHwwOI(0);
							qceelYWiEIMAbJqefzURPLnHwwOI2.oQBVNUmAUDarHJEzrCiqGdbrJEiEb = oQBVNUmAUDarHJEzrCiqGdbrJEiEb;
						}
						qceelYWiEIMAbJqefzURPLnHwwOI2.IgTrhoKqVGMqbIoCCzXeBCNifaab = OcacxEeZnQyVRzTMksczZDioXCwv;
						qceelYWiEIMAbJqefzURPLnHwwOI2.OcgxSTdNCKKyjHjIBNUQrQgPVmJu = rVSifACnHAdYSXzmNLoBUXbEvWjD;
						qceelYWiEIMAbJqefzURPLnHwwOI2.KeHPdIdUuracFviChumKjosoaOBn = hnPgdsneTTNrmlToGqvSMBLNhexfA;
						return qceelYWiEIMAbJqefzURPLnHwwOI2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class LghjOSLgFPVCWGSqtwblsKKVwfgs : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int WXQBUBvBogFJeCbcOCAdpOvVFnJl;

					private ActionElementMap mRRdaJwgcyrOAIaEnytPnYGppomv;

					private int WhqOQyuTllhnBGEqwgVYnOzjfqBhA;

					private int QfRthuLKcJJZmZcUcXGdPaYByGQp;

					public int EPqdWnCSSXubAyGfEdXmJlAuXFfd;

					public MapHelper uDCLDUVesPaQxEnqlfeZZdGMQHks;

					private ControllerType eKnFSjhaYHeKvkUTxjfGhJVgxxWrB;

					public ControllerType UiVrJaTrXXvFnQpRXMaKEJRuETSL;

					private int urzFuYAWAScRkbQxjzOQXsiTUwis;

					public int pMGGznbrdnECIyCahrgSESpJQztWb;

					private bool AGZuHkUqoyubxiwMfwPgvQhcntJX;

					public bool nGunzvCxuHpmGmLJbetDZoqrfjWaA;

					private IList<ControllerMap> uNxyTdXLaBpeztTpBbNjqNzEyArj;

					private int fwODaoUfCGLQjVmQWiVpyOgwCMHz;

					private IEnumerator<ActionElementMap> IXvGhGghCdbDCLIYXerpOIBswoYDA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return mRRdaJwgcyrOAIaEnytPnYGppomv;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return mRRdaJwgcyrOAIaEnytPnYGppomv;
						}
					}

					[DebuggerHidden]
					public LghjOSLgFPVCWGSqtwblsKKVwfgs(int P_0)
					{
						WXQBUBvBogFJeCbcOCAdpOvVFnJl = P_0;
						WhqOQyuTllhnBGEqwgVYnOzjfqBhA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int wXQBUBvBogFJeCbcOCAdpOvVFnJl = WXQBUBvBogFJeCbcOCAdpOvVFnJl;
						if (wXQBUBvBogFJeCbcOCAdpOvVFnJl == -3 || wXQBUBvBogFJeCbcOCAdpOvVFnJl == 1)
						{
							try
							{
							}
							finally
							{
								xSIrEyXeHkHlajPJkkWAAObvENMTA();
							}
						}
						uNxyTdXLaBpeztTpBbNjqNzEyArj = null;
						IXvGhGghCdbDCLIYXerpOIBswoYDA = null;
						WXQBUBvBogFJeCbcOCAdpOvVFnJl = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int wXQBUBvBogFJeCbcOCAdpOvVFnJl = WXQBUBvBogFJeCbcOCAdpOvVFnJl;
							MapHelper mapHelper = uDCLDUVesPaQxEnqlfeZZdGMQHks;
							if (wXQBUBvBogFJeCbcOCAdpOvVFnJl != 0)
							{
								if (wXQBUBvBogFJeCbcOCAdpOvVFnJl != 1)
								{
									return false;
								}
								WXQBUBvBogFJeCbcOCAdpOvVFnJl = -3;
								goto IL_012b;
							}
							WXQBUBvBogFJeCbcOCAdpOvVFnJl = -1;
							if (QfRthuLKcJJZmZcUcXGdPaYByGQp < 0)
							{
								return false;
							}
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(eKnFSjhaYHeKvkUTxjfGhJVgxxWrB);
							int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(urzFuYAWAScRkbQxjzOQXsiTUwis);
							if (num < 0)
							{
								return false;
							}
							uNxyTdXLaBpeztTpBbNjqNzEyArj = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
							fwODaoUfCGLQjVmQWiVpyOgwCMHz = 0;
							goto IL_0157;
							IL_012b:
							if (IXvGhGghCdbDCLIYXerpOIBswoYDA.MoveNext())
							{
								ActionElementMap current = IXvGhGghCdbDCLIYXerpOIBswoYDA.Current;
								mRRdaJwgcyrOAIaEnytPnYGppomv = current;
								WXQBUBvBogFJeCbcOCAdpOvVFnJl = 1;
								return true;
							}
							xSIrEyXeHkHlajPJkkWAAObvENMTA();
							IXvGhGghCdbDCLIYXerpOIBswoYDA = null;
							goto IL_0145;
							IL_0157:
							if (fwODaoUfCGLQjVmQWiVpyOgwCMHz < uNxyTdXLaBpeztTpBbNjqNzEyArj.Count)
							{
								if ((!AGZuHkUqoyubxiwMfwPgvQhcntJX || uNxyTdXLaBpeztTpBbNjqNzEyArj[fwODaoUfCGLQjVmQWiVpyOgwCMHz].enabled) && uNxyTdXLaBpeztTpBbNjqNzEyArj[fwODaoUfCGLQjVmQWiVpyOgwCMHz].ContainsAction(QfRthuLKcJJZmZcUcXGdPaYByGQp))
								{
									IXvGhGghCdbDCLIYXerpOIBswoYDA = uNxyTdXLaBpeztTpBbNjqNzEyArj[fwODaoUfCGLQjVmQWiVpyOgwCMHz].ElementMapsWithAction(QfRthuLKcJJZmZcUcXGdPaYByGQp, AGZuHkUqoyubxiwMfwPgvQhcntJX).GetEnumerator();
									WXQBUBvBogFJeCbcOCAdpOvVFnJl = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							fwODaoUfCGLQjVmQWiVpyOgwCMHz++;
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

					private void xSIrEyXeHkHlajPJkkWAAObvENMTA()
					{
						WXQBUBvBogFJeCbcOCAdpOvVFnJl = -1;
						if (IXvGhGghCdbDCLIYXerpOIBswoYDA != null)
						{
							IXvGhGghCdbDCLIYXerpOIBswoYDA.Dispose();
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
						LghjOSLgFPVCWGSqtwblsKKVwfgs lghjOSLgFPVCWGSqtwblsKKVwfgs;
						if (WXQBUBvBogFJeCbcOCAdpOvVFnJl == -2 && WhqOQyuTllhnBGEqwgVYnOzjfqBhA == Environment.CurrentManagedThreadId)
						{
							WXQBUBvBogFJeCbcOCAdpOvVFnJl = 0;
							lghjOSLgFPVCWGSqtwblsKKVwfgs = this;
						}
						else
						{
							lghjOSLgFPVCWGSqtwblsKKVwfgs = new LghjOSLgFPVCWGSqtwblsKKVwfgs(0);
							lghjOSLgFPVCWGSqtwblsKKVwfgs.uDCLDUVesPaQxEnqlfeZZdGMQHks = uDCLDUVesPaQxEnqlfeZZdGMQHks;
						}
						lghjOSLgFPVCWGSqtwblsKKVwfgs.eKnFSjhaYHeKvkUTxjfGhJVgxxWrB = UiVrJaTrXXvFnQpRXMaKEJRuETSL;
						lghjOSLgFPVCWGSqtwblsKKVwfgs.urzFuYAWAScRkbQxjzOQXsiTUwis = pMGGznbrdnECIyCahrgSESpJQztWb;
						lghjOSLgFPVCWGSqtwblsKKVwfgs.QfRthuLKcJJZmZcUcXGdPaYByGQp = EPqdWnCSSXubAyGfEdXmJlAuXFfd;
						lghjOSLgFPVCWGSqtwblsKKVwfgs.AGZuHkUqoyubxiwMfwPgvQhcntJX = nGunzvCxuHpmGmLJbetDZoqrfjWaA;
						return lghjOSLgFPVCWGSqtwblsKKVwfgs;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class CHBeYhaJOrFhbBiwmBHhNtNDgsOrA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int zdZQLWllnSPbXSmuSKpnkalqQoM;

					private ControllerMap WJGtBuwEBhgXXVucCZxwmVQaodzk;

					private int EtfwfgCkYTKhqgOWYcRIDjvlYrND;

					public MapHelper TMHbSLKewczYWaDywzZTnTdRHXgK;

					private ControllerType nIvjRozZpbBffGDBFmoCSOFoqxlV;

					public ControllerType nSOeJABkSzGykYQkgURQhJrpbQLk;

					private int eTIONLUpyJkRlJvdxwMSjphIWUDe;

					public int zNebBUkzhKpHarxVBPRHjXGqVnmpA;

					private int GCIHzKqXYAUpBgACmYlCQfMbAptw;

					public int rkiTYeuXgNKyYdbPolEdFvUmhqrR;

					private IList<ControllerMap> khyWFEPhwOoCmJvTsMpGDJGAFGZcA;

					private int bAOPrvyDqdWNsTdNjmgZciiusLES;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WJGtBuwEBhgXXVucCZxwmVQaodzk;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WJGtBuwEBhgXXVucCZxwmVQaodzk;
						}
					}

					[DebuggerHidden]
					public CHBeYhaJOrFhbBiwmBHhNtNDgsOrA(int P_0)
					{
						zdZQLWllnSPbXSmuSKpnkalqQoM = P_0;
						EtfwfgCkYTKhqgOWYcRIDjvlYrND = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						khyWFEPhwOoCmJvTsMpGDJGAFGZcA = null;
						zdZQLWllnSPbXSmuSKpnkalqQoM = -2;
					}

					private bool MoveNext()
					{
						int num = zdZQLWllnSPbXSmuSKpnkalqQoM;
						MapHelper tMHbSLKewczYWaDywzZTnTdRHXgK = TMHbSLKewczYWaDywzZTnTdRHXgK;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							zdZQLWllnSPbXSmuSKpnkalqQoM = -1;
							goto IL_00b0;
						}
						zdZQLWllnSPbXSmuSKpnkalqQoM = -1;
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = tMHbSLKewczYWaDywzZTnTdRHXgK.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(nIvjRozZpbBffGDBFmoCSOFoqxlV);
						int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(eTIONLUpyJkRlJvdxwMSjphIWUDe);
						if (num2 < 0)
						{
							return false;
						}
						khyWFEPhwOoCmJvTsMpGDJGAFGZcA = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num2).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
						bAOPrvyDqdWNsTdNjmgZciiusLES = 0;
						goto IL_00c2;
						IL_00c2:
						if (bAOPrvyDqdWNsTdNjmgZciiusLES < khyWFEPhwOoCmJvTsMpGDJGAFGZcA.Count)
						{
							if (khyWFEPhwOoCmJvTsMpGDJGAFGZcA[bAOPrvyDqdWNsTdNjmgZciiusLES].categoryId == GCIHzKqXYAUpBgACmYlCQfMbAptw)
							{
								WJGtBuwEBhgXXVucCZxwmVQaodzk = khyWFEPhwOoCmJvTsMpGDJGAFGZcA[bAOPrvyDqdWNsTdNjmgZciiusLES];
								zdZQLWllnSPbXSmuSKpnkalqQoM = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						bAOPrvyDqdWNsTdNjmgZciiusLES++;
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
						CHBeYhaJOrFhbBiwmBHhNtNDgsOrA cHBeYhaJOrFhbBiwmBHhNtNDgsOrA;
						if (zdZQLWllnSPbXSmuSKpnkalqQoM == -2 && EtfwfgCkYTKhqgOWYcRIDjvlYrND == Environment.CurrentManagedThreadId)
						{
							zdZQLWllnSPbXSmuSKpnkalqQoM = 0;
							cHBeYhaJOrFhbBiwmBHhNtNDgsOrA = this;
						}
						else
						{
							cHBeYhaJOrFhbBiwmBHhNtNDgsOrA = new CHBeYhaJOrFhbBiwmBHhNtNDgsOrA(0);
							cHBeYhaJOrFhbBiwmBHhNtNDgsOrA.TMHbSLKewczYWaDywzZTnTdRHXgK = TMHbSLKewczYWaDywzZTnTdRHXgK;
						}
						cHBeYhaJOrFhbBiwmBHhNtNDgsOrA.nIvjRozZpbBffGDBFmoCSOFoqxlV = nSOeJABkSzGykYQkgURQhJrpbQLk;
						cHBeYhaJOrFhbBiwmBHhNtNDgsOrA.eTIONLUpyJkRlJvdxwMSjphIWUDe = zNebBUkzhKpHarxVBPRHjXGqVnmpA;
						cHBeYhaJOrFhbBiwmBHhNtNDgsOrA.GCIHzKqXYAUpBgACmYlCQfMbAptw = rkiTYeuXgNKyYdbPolEdFvUmhqrR;
						return cHBeYhaJOrFhbBiwmBHhNtNDgsOrA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class dLhAfsgfGsprlNeXNqeeICwFpRkYb<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int NRlHZopEmIeuplYELeGDKoWfMcnC;

					private _0001 hyGeUFwltwGlsCgyAdXAVSNayMjr;

					private int qgtOUdCuVnplRtysiKJTMYVkulhd;

					public MapHelper euToHPrjegaGGFFsDgtYrynyVzweA;

					private int McCHFOcbREcwsGZrcMEDfVPKLqfW;

					public int JqMNCisoiQjlcfMIrPFrywDykAOeA;

					private int IysFzEwFAtmvKNqFfAcmdpWfXbRkA;

					public int SgcRSxQxnersQwocMRGyuXiOeZXh;

					private IList<_0001> YeMtjnrsDlDtBrEHUktwsZoKGUmD;

					private int gRdAqvUuDMbxOEcZEHXueXIfIBcpB;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return hyGeUFwltwGlsCgyAdXAVSNayMjr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hyGeUFwltwGlsCgyAdXAVSNayMjr;
						}
					}

					[DebuggerHidden]
					public dLhAfsgfGsprlNeXNqeeICwFpRkYb(int P_0)
					{
						NRlHZopEmIeuplYELeGDKoWfMcnC = P_0;
						qgtOUdCuVnplRtysiKJTMYVkulhd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						YeMtjnrsDlDtBrEHUktwsZoKGUmD = null;
						NRlHZopEmIeuplYELeGDKoWfMcnC = -2;
					}

					private bool MoveNext()
					{
						int nRlHZopEmIeuplYELeGDKoWfMcnC = NRlHZopEmIeuplYELeGDKoWfMcnC;
						MapHelper mapHelper = euToHPrjegaGGFFsDgtYrynyVzweA;
						if (nRlHZopEmIeuplYELeGDKoWfMcnC != 0)
						{
							if (nRlHZopEmIeuplYELeGDKoWfMcnC != 1)
							{
								return false;
							}
							NRlHZopEmIeuplYELeGDKoWfMcnC = -1;
							goto IL_00b9;
						}
						NRlHZopEmIeuplYELeGDKoWfMcnC = -1;
						ControllerType controllerType = nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<_0001>();
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(McCHFOcbREcwsGZrcMEDfVPKLqfW);
						if (num < 0)
						{
							return false;
						}
						YeMtjnrsDlDtBrEHUktwsZoKGUmD = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.MpEiHMOPFAgyzhELMElGisruXUvLA<_0001>();
						gRdAqvUuDMbxOEcZEHXueXIfIBcpB = 0;
						goto IL_00cb;
						IL_00cb:
						if (gRdAqvUuDMbxOEcZEHXueXIfIBcpB < YeMtjnrsDlDtBrEHUktwsZoKGUmD.Count)
						{
							if (YeMtjnrsDlDtBrEHUktwsZoKGUmD[gRdAqvUuDMbxOEcZEHXueXIfIBcpB].categoryId == IysFzEwFAtmvKNqFfAcmdpWfXbRkA)
							{
								hyGeUFwltwGlsCgyAdXAVSNayMjr = YeMtjnrsDlDtBrEHUktwsZoKGUmD[gRdAqvUuDMbxOEcZEHXueXIfIBcpB];
								NRlHZopEmIeuplYELeGDKoWfMcnC = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						gRdAqvUuDMbxOEcZEHXueXIfIBcpB++;
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
						dLhAfsgfGsprlNeXNqeeICwFpRkYb<_0001> dLhAfsgfGsprlNeXNqeeICwFpRkYb2;
						if (NRlHZopEmIeuplYELeGDKoWfMcnC == -2 && qgtOUdCuVnplRtysiKJTMYVkulhd == Environment.CurrentManagedThreadId)
						{
							NRlHZopEmIeuplYELeGDKoWfMcnC = 0;
							dLhAfsgfGsprlNeXNqeeICwFpRkYb2 = this;
						}
						else
						{
							dLhAfsgfGsprlNeXNqeeICwFpRkYb2 = new dLhAfsgfGsprlNeXNqeeICwFpRkYb<_0001>(0);
							dLhAfsgfGsprlNeXNqeeICwFpRkYb2.euToHPrjegaGGFFsDgtYrynyVzweA = euToHPrjegaGGFFsDgtYrynyVzweA;
						}
						dLhAfsgfGsprlNeXNqeeICwFpRkYb2.McCHFOcbREcwsGZrcMEDfVPKLqfW = JqMNCisoiQjlcfMIrPFrywDykAOeA;
						dLhAfsgfGsprlNeXNqeeICwFpRkYb2.IysFzEwFAtmvKNqFfAcmdpWfXbRkA = SgcRSxQxnersQwocMRGyuXiOeZXh;
						return dLhAfsgfGsprlNeXNqeeICwFpRkYb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class xFHSIihlfmhHEhnFFpxEOaPhifPO : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int pTgAACYGDRYGrFMcNnRqIWahkINo;

					private ActionElementMap RTbEZeWEGuPQnHcqqZZwUAjxKnBu;

					private int LbcwmBouhoHTfpHuvYhocToycDJu;

					public MapHelper htOlvjWeKGkwRxrhiAtETMDniHmaA;

					private int vbPvFhMEfKlSLTiPAKGyMnaqwwmp;

					public int IYIuqMhOlahGigmIBvQQfvwwlovCb;

					private bool KDwyubssdSChBeFQGTUVaMfXxdQS;

					public bool VGqZVvvwtgiaHpUAFyYYLqPiUlID;

					private int CgJoKmjqhVCPtVhsasVmRoJYujrw;

					private int ARizvMJyiPldNDNDOYIgOMQoETFd;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU lqwEwiidLCsqwWPsiWukUfYjzYoGA;

					private int mBAqHDZkMnzASFlFScVqoPjnVUhk;

					private int IuvMalJyZZlPPChORjPyroAvsggN;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA fnaFpkMgWwSCJCzvjHtsnivaPePS;

					private int wQNwRYhfWaZSwyYHQJpbDKjufUjd;

					private int FGKBTytIBwDEHwoNHwSDvCYMhFSA;

					private IEnumerator<ActionElementMap> ZENAxZbNutIDzMnbmuMdjOWHnNdeb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return RTbEZeWEGuPQnHcqqZZwUAjxKnBu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RTbEZeWEGuPQnHcqqZZwUAjxKnBu;
						}
					}

					[DebuggerHidden]
					public xFHSIihlfmhHEhnFFpxEOaPhifPO(int P_0)
					{
						pTgAACYGDRYGrFMcNnRqIWahkINo = P_0;
						LbcwmBouhoHTfpHuvYhocToycDJu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pTgAACYGDRYGrFMcNnRqIWahkINo;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								jIUHIBtpsrrSPtYwFPCJCOGouanj();
							}
						}
						lqwEwiidLCsqwWPsiWukUfYjzYoGA = null;
						fnaFpkMgWwSCJCzvjHtsnivaPePS = null;
						ZENAxZbNutIDzMnbmuMdjOWHnNdeb = null;
						pTgAACYGDRYGrFMcNnRqIWahkINo = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pTgAACYGDRYGrFMcNnRqIWahkINo;
							MapHelper mapHelper = htOlvjWeKGkwRxrhiAtETMDniHmaA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pTgAACYGDRYGrFMcNnRqIWahkINo = -3;
								goto IL_016c;
							}
							pTgAACYGDRYGrFMcNnRqIWahkINo = -1;
							if (ReInput._id != mapHelper.FvpSbjgVkHHcsEibBaxvEemsoaLB)
							{
								ReInput.CheckInitialized(mapHelper.FvpSbjgVkHHcsEibBaxvEemsoaLB);
								return false;
							}
							if (vbPvFhMEfKlSLTiPAKGyMnaqwwmp < 0)
							{
								return false;
							}
							CgJoKmjqhVCPtVhsasVmRoJYujrw = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
							ARizvMJyiPldNDNDOYIgOMQoETFd = 0;
							goto IL_01ec;
							IL_016c:
							if (ZENAxZbNutIDzMnbmuMdjOWHnNdeb.MoveNext())
							{
								ActionElementMap current = ZENAxZbNutIDzMnbmuMdjOWHnNdeb.Current;
								RTbEZeWEGuPQnHcqqZZwUAjxKnBu = current;
								pTgAACYGDRYGrFMcNnRqIWahkINo = 1;
								return true;
							}
							jIUHIBtpsrrSPtYwFPCJCOGouanj();
							ZENAxZbNutIDzMnbmuMdjOWHnNdeb = null;
							goto IL_0186;
							IL_0186:
							FGKBTytIBwDEHwoNHwSDvCYMhFSA++;
							goto IL_0198;
							IL_01c2:
							if (IuvMalJyZZlPPChORjPyroAvsggN < mBAqHDZkMnzASFlFScVqoPjnVUhk)
							{
								fnaFpkMgWwSCJCzvjHtsnivaPePS = lqwEwiidLCsqwWPsiWukUfYjzYoGA.LiHJOfWLuRlIpTeFwKoewXdglkyu(IuvMalJyZZlPPChORjPyroAvsggN).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								wQNwRYhfWaZSwyYHQJpbDKjufUjd = fnaFpkMgWwSCJCzvjHtsnivaPePS.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								FGKBTytIBwDEHwoNHwSDvCYMhFSA = 0;
								goto IL_0198;
							}
							lqwEwiidLCsqwWPsiWukUfYjzYoGA = null;
							ARizvMJyiPldNDNDOYIgOMQoETFd++;
							goto IL_01ec;
							IL_0198:
							if (FGKBTytIBwDEHwoNHwSDvCYMhFSA < wQNwRYhfWaZSwyYHQJpbDKjufUjd)
							{
								ControllerMap controllerMap = fnaFpkMgWwSCJCzvjHtsnivaPePS.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(FGKBTytIBwDEHwoNHwSDvCYMhFSA);
								if ((!KDwyubssdSChBeFQGTUVaMfXxdQS || controllerMap.enabled) && controllerMap.ContainsAction(vbPvFhMEfKlSLTiPAKGyMnaqwwmp))
								{
									ZENAxZbNutIDzMnbmuMdjOWHnNdeb = controllerMap.ElementMapsWithAction(vbPvFhMEfKlSLTiPAKGyMnaqwwmp, KDwyubssdSChBeFQGTUVaMfXxdQS).GetEnumerator();
									pTgAACYGDRYGrFMcNnRqIWahkINo = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							fnaFpkMgWwSCJCzvjHtsnivaPePS = null;
							IuvMalJyZZlPPChORjPyroAvsggN++;
							goto IL_01c2;
							IL_01ec:
							if (ARizvMJyiPldNDNDOYIgOMQoETFd < CgJoKmjqhVCPtVhsasVmRoJYujrw)
							{
								lqwEwiidLCsqwWPsiWukUfYjzYoGA = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(ARizvMJyiPldNDNDOYIgOMQoETFd);
								mBAqHDZkMnzASFlFScVqoPjnVUhk = lqwEwiidLCsqwWPsiWukUfYjzYoGA.kVgCrHansgVHQdOwmDKoORLmXnGv;
								IuvMalJyZZlPPChORjPyroAvsggN = 0;
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

					private void jIUHIBtpsrrSPtYwFPCJCOGouanj()
					{
						pTgAACYGDRYGrFMcNnRqIWahkINo = -1;
						if (ZENAxZbNutIDzMnbmuMdjOWHnNdeb != null)
						{
							ZENAxZbNutIDzMnbmuMdjOWHnNdeb.Dispose();
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
						xFHSIihlfmhHEhnFFpxEOaPhifPO xFHSIihlfmhHEhnFFpxEOaPhifPO2;
						if (pTgAACYGDRYGrFMcNnRqIWahkINo == -2 && LbcwmBouhoHTfpHuvYhocToycDJu == Environment.CurrentManagedThreadId)
						{
							pTgAACYGDRYGrFMcNnRqIWahkINo = 0;
							xFHSIihlfmhHEhnFFpxEOaPhifPO2 = this;
						}
						else
						{
							xFHSIihlfmhHEhnFFpxEOaPhifPO2 = new xFHSIihlfmhHEhnFFpxEOaPhifPO(0);
							xFHSIihlfmhHEhnFFpxEOaPhifPO2.htOlvjWeKGkwRxrhiAtETMDniHmaA = htOlvjWeKGkwRxrhiAtETMDniHmaA;
						}
						xFHSIihlfmhHEhnFFpxEOaPhifPO2.vbPvFhMEfKlSLTiPAKGyMnaqwwmp = IYIuqMhOlahGigmIBvQQfvwwlovCb;
						xFHSIihlfmhHEhnFFpxEOaPhifPO2.KDwyubssdSChBeFQGTUVaMfXxdQS = VGqZVvvwtgiaHpUAFyYYLqPiUlID;
						return xFHSIihlfmhHEhnFFpxEOaPhifPO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class GSjwVNoOChJQfnZZKHKdgjLZzaV : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int BsWBHTtTeXjCAlhyOYPEXvYiZsIB;

					private ActionElementMap oATebpuhsSowWXZQwVQdkDddLETF;

					private int uxLAOYghzPBoCIJkWnnAEPZkXeTkb;

					private IControllerElementTarget ngyGfNeBsxMaeNmZasxBmoaXLGrdA;

					public IControllerElementTarget CdZdVOFRdmnOwubfevMcsurErpbc;

					public MapHelper NSOkblvOoUovcPuptsAZGLkUKQFy;

					private bool lmgekCzJYDVhLxrxttLgdEFMuXhh;

					public bool gZUSWTGirSaZSOrScAvwDzrqohje;

					private bool lZFmVZlpOWFRzXKbFxQknIMPmUNi;

					public bool QCFjOYCOBdoFUnvffGniSUbaENkKA;

					private int IjPIkaIYcFFuSPZjUVWTbpRsZwUE;

					public int sbOVkgkxLeEYRpSDzUgqUMTILCUK;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU AoKbfgJepxOSEyXmbZNWteCfCuQdb;

					private int huTpOXBOIEHdEdAPlpsrxliCpKGcb;

					private int IGyOaMLBkHKQcNoiOrCOipOrYUMb;

					private IList<ControllerMap> MyERRfubKvGCKIhXYcxmkiwIAunw;

					private int PYWqqGzonSkgPwcNEhYkgQYKCPrDb;

					private int nThLZMrgLhMcgwGCubrNgZrKbIQK;

					private TempListPool.TList<ActionElementMap> NqOkQkUGyofMPbsaGYavbhRObgjM;

					private List<ActionElementMap>.Enumerator nEQEYgKTOsPeNfxNDOmMJDmNBSPU;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return oATebpuhsSowWXZQwVQdkDddLETF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oATebpuhsSowWXZQwVQdkDddLETF;
						}
					}

					[DebuggerHidden]
					public GSjwVNoOChJQfnZZKHKdgjLZzaV(int P_0)
					{
						BsWBHTtTeXjCAlhyOYPEXvYiZsIB = P_0;
						uxLAOYghzPBoCIJkWnnAEPZkXeTkb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bsWBHTtTeXjCAlhyOYPEXvYiZsIB = BsWBHTtTeXjCAlhyOYPEXvYiZsIB;
						if ((uint)(bsWBHTtTeXjCAlhyOYPEXvYiZsIB - -4) <= 1u || bsWBHTtTeXjCAlhyOYPEXvYiZsIB == 1)
						{
							try
							{
								if (bsWBHTtTeXjCAlhyOYPEXvYiZsIB == -4 || bsWBHTtTeXjCAlhyOYPEXvYiZsIB == 1)
								{
									try
									{
									}
									finally
									{
										ryFUERTjlVqpnHIsblPvrzBONkco();
									}
								}
							}
							finally
							{
								wdYqYsGjHgSbKhCCOmSMSqFdsRkB();
							}
						}
						AoKbfgJepxOSEyXmbZNWteCfCuQdb = null;
						MyERRfubKvGCKIhXYcxmkiwIAunw = null;
						NqOkQkUGyofMPbsaGYavbhRObgjM = null;
						nEQEYgKTOsPeNfxNDOmMJDmNBSPU = default(List<ActionElementMap>.Enumerator);
						BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int bsWBHTtTeXjCAlhyOYPEXvYiZsIB = BsWBHTtTeXjCAlhyOYPEXvYiZsIB;
							MapHelper nSOkblvOoUovcPuptsAZGLkUKQFy = NSOkblvOoUovcPuptsAZGLkUKQFy;
							if (bsWBHTtTeXjCAlhyOYPEXvYiZsIB != 0)
							{
								if (bsWBHTtTeXjCAlhyOYPEXvYiZsIB != 1)
								{
									return false;
								}
								BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -4;
								goto IL_017c;
							}
							BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -1;
							if (ngyGfNeBsxMaeNmZasxBmoaXLGrdA == null)
							{
								return false;
							}
							Controller controller = ngyGfNeBsxMaeNmZasxBmoaXLGrdA.controller;
							if (controller == null)
							{
								return false;
							}
							AoKbfgJepxOSEyXmbZNWteCfCuQdb = nSOkblvOoUovcPuptsAZGLkUKQFy.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controller.type);
							huTpOXBOIEHdEdAPlpsrxliCpKGcb = AoKbfgJepxOSEyXmbZNWteCfCuQdb.kVgCrHansgVHQdOwmDKoORLmXnGv;
							IGyOaMLBkHKQcNoiOrCOipOrYUMb = 0;
							goto IL_01e4;
							IL_017c:
							if (nEQEYgKTOsPeNfxNDOmMJDmNBSPU.MoveNext())
							{
								ActionElementMap current = nEQEYgKTOsPeNfxNDOmMJDmNBSPU.Current;
								oATebpuhsSowWXZQwVQdkDddLETF = current;
								BsWBHTtTeXjCAlhyOYPEXvYiZsIB = 1;
								return true;
							}
							ryFUERTjlVqpnHIsblPvrzBONkco();
							nEQEYgKTOsPeNfxNDOmMJDmNBSPU = default(List<ActionElementMap>.Enumerator);
							wdYqYsGjHgSbKhCCOmSMSqFdsRkB();
							NqOkQkUGyofMPbsaGYavbhRObgjM = null;
							goto IL_01a8;
							IL_01e4:
							if (IGyOaMLBkHKQcNoiOrCOipOrYUMb < huTpOXBOIEHdEdAPlpsrxliCpKGcb)
							{
								yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = AoKbfgJepxOSEyXmbZNWteCfCuQdb.LiHJOfWLuRlIpTeFwKoewXdglkyu(IGyOaMLBkHKQcNoiOrCOipOrYUMb).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								_ = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								MyERRfubKvGCKIhXYcxmkiwIAunw = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
								PYWqqGzonSkgPwcNEhYkgQYKCPrDb = MyERRfubKvGCKIhXYcxmkiwIAunw.Count;
								nThLZMrgLhMcgwGCubrNgZrKbIQK = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (nThLZMrgLhMcgwGCubrNgZrKbIQK < PYWqqGzonSkgPwcNEhYkgQYKCPrDb)
							{
								ControllerMap controllerMap = MyERRfubKvGCKIhXYcxmkiwIAunw[nThLZMrgLhMcgwGCubrNgZrKbIQK];
								if (!lmgekCzJYDVhLxrxttLgdEFMuXhh || controllerMap.enabled)
								{
									NqOkQkUGyofMPbsaGYavbhRObgjM = TempListPool.GetTList<ActionElementMap>();
									BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -3;
									List<ActionElementMap> list = NqOkQkUGyofMPbsaGYavbhRObgjM.list;
									controllerMap.rBPavCiiyAlojGkIqSyYebDCbwCgA(ngyGfNeBsxMaeNmZasxBmoaXLGrdA, lZFmVZlpOWFRzXKbFxQknIMPmUNi, IjPIkaIYcFFuSPZjUVWTbpRsZwUE, lmgekCzJYDVhLxrxttLgdEFMuXhh, list, true, out var _);
									nEQEYgKTOsPeNfxNDOmMJDmNBSPU = list.GetEnumerator();
									BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							MyERRfubKvGCKIhXYcxmkiwIAunw = null;
							IGyOaMLBkHKQcNoiOrCOipOrYUMb++;
							goto IL_01e4;
							IL_01a8:
							nThLZMrgLhMcgwGCubrNgZrKbIQK++;
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

					private void wdYqYsGjHgSbKhCCOmSMSqFdsRkB()
					{
						BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -1;
						if (NqOkQkUGyofMPbsaGYavbhRObgjM != null)
						{
							((IDisposable)NqOkQkUGyofMPbsaGYavbhRObgjM).Dispose();
						}
					}

					private void ryFUERTjlVqpnHIsblPvrzBONkco()
					{
						BsWBHTtTeXjCAlhyOYPEXvYiZsIB = -3;
						((IDisposable)nEQEYgKTOsPeNfxNDOmMJDmNBSPU/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						GSjwVNoOChJQfnZZKHKdgjLZzaV gSjwVNoOChJQfnZZKHKdgjLZzaV;
						if (BsWBHTtTeXjCAlhyOYPEXvYiZsIB == -2 && uxLAOYghzPBoCIJkWnnAEPZkXeTkb == Environment.CurrentManagedThreadId)
						{
							BsWBHTtTeXjCAlhyOYPEXvYiZsIB = 0;
							gSjwVNoOChJQfnZZKHKdgjLZzaV = this;
						}
						else
						{
							gSjwVNoOChJQfnZZKHKdgjLZzaV = new GSjwVNoOChJQfnZZKHKdgjLZzaV(0);
							gSjwVNoOChJQfnZZKHKdgjLZzaV.NSOkblvOoUovcPuptsAZGLkUKQFy = NSOkblvOoUovcPuptsAZGLkUKQFy;
						}
						gSjwVNoOChJQfnZZKHKdgjLZzaV.ngyGfNeBsxMaeNmZasxBmoaXLGrdA = CdZdVOFRdmnOwubfevMcsurErpbc;
						gSjwVNoOChJQfnZZKHKdgjLZzaV.lZFmVZlpOWFRzXKbFxQknIMPmUNi = QCFjOYCOBdoFUnvffGniSUbaENkKA;
						gSjwVNoOChJQfnZZKHKdgjLZzaV.IjPIkaIYcFFuSPZjUVWTbpRsZwUE = sbOVkgkxLeEYRpSDzUgqUMTILCUK;
						gSjwVNoOChJQfnZZKHKdgjLZzaV.lmgekCzJYDVhLxrxttLgdEFMuXhh = gZUSWTGirSaZSOrScAvwDzrqohje;
						return gSjwVNoOChJQfnZZKHKdgjLZzaV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class VxIhZefBaRkaypfHzaEUlxwODOu : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int gpYpkDSvXYpyBDwHuPvzGPbxDitbA;

					private ControllerMap uLwvjvrVZnjAYuYHjBrHtbHuELQf;

					private int rRxEMkbxeHtGBBJxwSAigeijknyy;

					public MapHelper TJyicPVuBJaUoZrCXLHUWGLrljlV;

					private int KUDpLoNYgTURrgmuosjCdoorLPFc;

					private int jXetaEOEUefjxIcIiWwhownDCbaHb;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU zcISOebNXndGbyOFcFNQcslaDXVRA;

					private int bQUwgfwghSHbHIxcnbkLjPnajHJjb;

					private int hrmtYLDWQeZDikLScvJAIEypKHEA;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA jzxxNPAGzaoIJsLELETbCbDwZGoi;

					private int REaeaGjJhhHLSKGPpoDkravcwTQY;

					private int zfYmBObHBSIMxJEaFjuIbrseSpvFA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return uLwvjvrVZnjAYuYHjBrHtbHuELQf;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uLwvjvrVZnjAYuYHjBrHtbHuELQf;
						}
					}

					[DebuggerHidden]
					public VxIhZefBaRkaypfHzaEUlxwODOu(int P_0)
					{
						gpYpkDSvXYpyBDwHuPvzGPbxDitbA = P_0;
						rRxEMkbxeHtGBBJxwSAigeijknyy = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						zcISOebNXndGbyOFcFNQcslaDXVRA = null;
						jzxxNPAGzaoIJsLELETbCbDwZGoi = null;
						gpYpkDSvXYpyBDwHuPvzGPbxDitbA = -2;
					}

					private bool MoveNext()
					{
						int num = gpYpkDSvXYpyBDwHuPvzGPbxDitbA;
						MapHelper tJyicPVuBJaUoZrCXLHUWGLrljlV = TJyicPVuBJaUoZrCXLHUWGLrljlV;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							gpYpkDSvXYpyBDwHuPvzGPbxDitbA = -1;
							zfYmBObHBSIMxJEaFjuIbrseSpvFA++;
							goto IL_0104;
						}
						gpYpkDSvXYpyBDwHuPvzGPbxDitbA = -1;
						if (ReInput._id != tJyicPVuBJaUoZrCXLHUWGLrljlV.FvpSbjgVkHHcsEibBaxvEemsoaLB)
						{
							ReInput.CheckInitialized(tJyicPVuBJaUoZrCXLHUWGLrljlV.FvpSbjgVkHHcsEibBaxvEemsoaLB);
							return false;
						}
						KUDpLoNYgTURrgmuosjCdoorLPFc = tJyicPVuBJaUoZrCXLHUWGLrljlV.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
						jXetaEOEUefjxIcIiWwhownDCbaHb = 0;
						goto IL_0151;
						IL_0104:
						if (zfYmBObHBSIMxJEaFjuIbrseSpvFA < REaeaGjJhhHLSKGPpoDkravcwTQY)
						{
							uLwvjvrVZnjAYuYHjBrHtbHuELQf = jzxxNPAGzaoIJsLELETbCbDwZGoi.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(zfYmBObHBSIMxJEaFjuIbrseSpvFA);
							gpYpkDSvXYpyBDwHuPvzGPbxDitbA = 1;
							return true;
						}
						jzxxNPAGzaoIJsLELETbCbDwZGoi = null;
						hrmtYLDWQeZDikLScvJAIEypKHEA++;
						goto IL_0129;
						IL_0129:
						if (hrmtYLDWQeZDikLScvJAIEypKHEA < bQUwgfwghSHbHIxcnbkLjPnajHJjb)
						{
							jzxxNPAGzaoIJsLELETbCbDwZGoi = zcISOebNXndGbyOFcFNQcslaDXVRA.LiHJOfWLuRlIpTeFwKoewXdglkyu(hrmtYLDWQeZDikLScvJAIEypKHEA).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							REaeaGjJhhHLSKGPpoDkravcwTQY = jzxxNPAGzaoIJsLELETbCbDwZGoi.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							zfYmBObHBSIMxJEaFjuIbrseSpvFA = 0;
							goto IL_0104;
						}
						zcISOebNXndGbyOFcFNQcslaDXVRA = null;
						jXetaEOEUefjxIcIiWwhownDCbaHb++;
						goto IL_0151;
						IL_0151:
						if (jXetaEOEUefjxIcIiWwhownDCbaHb < KUDpLoNYgTURrgmuosjCdoorLPFc)
						{
							zcISOebNXndGbyOFcFNQcslaDXVRA = tJyicPVuBJaUoZrCXLHUWGLrljlV.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(jXetaEOEUefjxIcIiWwhownDCbaHb);
							bQUwgfwghSHbHIxcnbkLjPnajHJjb = zcISOebNXndGbyOFcFNQcslaDXVRA.kVgCrHansgVHQdOwmDKoORLmXnGv;
							hrmtYLDWQeZDikLScvJAIEypKHEA = 0;
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
						VxIhZefBaRkaypfHzaEUlxwODOu vxIhZefBaRkaypfHzaEUlxwODOu;
						if (gpYpkDSvXYpyBDwHuPvzGPbxDitbA == -2 && rRxEMkbxeHtGBBJxwSAigeijknyy == Environment.CurrentManagedThreadId)
						{
							gpYpkDSvXYpyBDwHuPvzGPbxDitbA = 0;
							vxIhZefBaRkaypfHzaEUlxwODOu = this;
						}
						else
						{
							vxIhZefBaRkaypfHzaEUlxwODOu = new VxIhZefBaRkaypfHzaEUlxwODOu(0);
							vxIhZefBaRkaypfHzaEUlxwODOu.TJyicPVuBJaUoZrCXLHUWGLrljlV = TJyicPVuBJaUoZrCXLHUWGLrljlV;
						}
						return vxIhZefBaRkaypfHzaEUlxwODOu;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class YGahmcCsRtytHPRDIGUjChJuQyLwA<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int dMQpNGwFuEQiSYcmRJRYwmlSRZfl;

					private _0001 zZSANcfrWVzmrEJBrNaBLIIsrtaF;

					private int aHuaKKRmNfPXFEykauLqdHAZOocT;

					public MapHelper dbwvFJfcYwbjhWpeWDIXDvwHfceZ;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU UXQECqYIJqfAlFyERBuDDzzMKBWz;

					private int VfaeFDcvaDOTySmrbbKBevybizpBA;

					private int EeixqxnneOYgkveJTgUilSaltycw;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA vLkGTEBEKVSdqotJdScIWFzwVKZC;

					private int uSUuVOuGIepWxxbHqvCXmDqeJbUL;

					private int nENbjHyNALKJJXDSfOvmlYrHsgHv;

					private int jeBwNJKFolfejWvbZlvzCsfPFoLp;

					private int xwJgGmEtuSWMpoGEWhqjreySDDIHb;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return zZSANcfrWVzmrEJBrNaBLIIsrtaF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zZSANcfrWVzmrEJBrNaBLIIsrtaF;
						}
					}

					[DebuggerHidden]
					public YGahmcCsRtytHPRDIGUjChJuQyLwA(int P_0)
					{
						dMQpNGwFuEQiSYcmRJRYwmlSRZfl = P_0;
						aHuaKKRmNfPXFEykauLqdHAZOocT = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						UXQECqYIJqfAlFyERBuDDzzMKBWz = null;
						vLkGTEBEKVSdqotJdScIWFzwVKZC = null;
						dMQpNGwFuEQiSYcmRJRYwmlSRZfl = -2;
					}

					private bool MoveNext()
					{
						int num = dMQpNGwFuEQiSYcmRJRYwmlSRZfl;
						MapHelper mapHelper = dbwvFJfcYwbjhWpeWDIXDvwHfceZ;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							dMQpNGwFuEQiSYcmRJRYwmlSRZfl = -1;
							if (ReInput._id != mapHelper.FvpSbjgVkHHcsEibBaxvEemsoaLB)
							{
								ReInput.CheckInitialized(mapHelper.FvpSbjgVkHHcsEibBaxvEemsoaLB);
								return false;
							}
							if (nwsTruCLxjorysrNysDvPYrmMcrb.VHpESMrQhYEDlczIeXNfYRtSaZGd<_0001>(out var controllerType))
							{
								UXQECqYIJqfAlFyERBuDDzzMKBWz = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
								VfaeFDcvaDOTySmrbbKBevybizpBA = UXQECqYIJqfAlFyERBuDDzzMKBWz.kVgCrHansgVHQdOwmDKoORLmXnGv;
								EeixqxnneOYgkveJTgUilSaltycw = 0;
								goto IL_011b;
							}
							VfaeFDcvaDOTySmrbbKBevybizpBA = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
							EeixqxnneOYgkveJTgUilSaltycw = 0;
							goto IL_0264;
						}
						case 1:
							dMQpNGwFuEQiSYcmRJRYwmlSRZfl = -1;
							nENbjHyNALKJJXDSfOvmlYrHsgHv++;
							goto IL_00f6;
						case 2:
							{
								dMQpNGwFuEQiSYcmRJRYwmlSRZfl = -1;
								goto IL_0207;
							}
							IL_0207:
							xwJgGmEtuSWMpoGEWhqjreySDDIHb++;
							goto IL_0217;
							IL_0264:
							if (EeixqxnneOYgkveJTgUilSaltycw >= VfaeFDcvaDOTySmrbbKBevybizpBA)
							{
								break;
							}
							UXQECqYIJqfAlFyERBuDDzzMKBWz = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(EeixqxnneOYgkveJTgUilSaltycw);
							uSUuVOuGIepWxxbHqvCXmDqeJbUL = UXQECqYIJqfAlFyERBuDDzzMKBWz.kVgCrHansgVHQdOwmDKoORLmXnGv;
							nENbjHyNALKJJXDSfOvmlYrHsgHv = 0;
							goto IL_023c;
							IL_011b:
							if (EeixqxnneOYgkveJTgUilSaltycw < VfaeFDcvaDOTySmrbbKBevybizpBA)
							{
								vLkGTEBEKVSdqotJdScIWFzwVKZC = UXQECqYIJqfAlFyERBuDDzzMKBWz.LiHJOfWLuRlIpTeFwKoewXdglkyu(EeixqxnneOYgkveJTgUilSaltycw).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								uSUuVOuGIepWxxbHqvCXmDqeJbUL = vLkGTEBEKVSdqotJdScIWFzwVKZC.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								nENbjHyNALKJJXDSfOvmlYrHsgHv = 0;
								goto IL_00f6;
							}
							UXQECqYIJqfAlFyERBuDDzzMKBWz = null;
							break;
							IL_0217:
							if (xwJgGmEtuSWMpoGEWhqjreySDDIHb < jeBwNJKFolfejWvbZlvzCsfPFoLp)
							{
								if (vLkGTEBEKVSdqotJdScIWFzwVKZC.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(xwJgGmEtuSWMpoGEWhqjreySDDIHb) is _0001 val)
								{
									zZSANcfrWVzmrEJBrNaBLIIsrtaF = val;
									dMQpNGwFuEQiSYcmRJRYwmlSRZfl = 2;
									return true;
								}
								goto IL_0207;
							}
							vLkGTEBEKVSdqotJdScIWFzwVKZC = null;
							nENbjHyNALKJJXDSfOvmlYrHsgHv++;
							goto IL_023c;
							IL_023c:
							if (nENbjHyNALKJJXDSfOvmlYrHsgHv < uSUuVOuGIepWxxbHqvCXmDqeJbUL)
							{
								vLkGTEBEKVSdqotJdScIWFzwVKZC = UXQECqYIJqfAlFyERBuDDzzMKBWz.LiHJOfWLuRlIpTeFwKoewXdglkyu(nENbjHyNALKJJXDSfOvmlYrHsgHv).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								jeBwNJKFolfejWvbZlvzCsfPFoLp = vLkGTEBEKVSdqotJdScIWFzwVKZC.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								xwJgGmEtuSWMpoGEWhqjreySDDIHb = 0;
								goto IL_0217;
							}
							UXQECqYIJqfAlFyERBuDDzzMKBWz = null;
							EeixqxnneOYgkveJTgUilSaltycw++;
							goto IL_0264;
							IL_00f6:
							if (nENbjHyNALKJJXDSfOvmlYrHsgHv < uSUuVOuGIepWxxbHqvCXmDqeJbUL)
							{
								zZSANcfrWVzmrEJBrNaBLIIsrtaF = (_0001)vLkGTEBEKVSdqotJdScIWFzwVKZC.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(nENbjHyNALKJJXDSfOvmlYrHsgHv);
								dMQpNGwFuEQiSYcmRJRYwmlSRZfl = 1;
								return true;
							}
							vLkGTEBEKVSdqotJdScIWFzwVKZC = null;
							EeixqxnneOYgkveJTgUilSaltycw++;
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
						YGahmcCsRtytHPRDIGUjChJuQyLwA<_0001> yGahmcCsRtytHPRDIGUjChJuQyLwA;
						if (dMQpNGwFuEQiSYcmRJRYwmlSRZfl == -2 && aHuaKKRmNfPXFEykauLqdHAZOocT == Environment.CurrentManagedThreadId)
						{
							dMQpNGwFuEQiSYcmRJRYwmlSRZfl = 0;
							yGahmcCsRtytHPRDIGUjChJuQyLwA = this;
						}
						else
						{
							yGahmcCsRtytHPRDIGUjChJuQyLwA = new YGahmcCsRtytHPRDIGUjChJuQyLwA<_0001>(0);
							yGahmcCsRtytHPRDIGUjChJuQyLwA.dbwvFJfcYwbjhWpeWDIXDvwHfceZ = dbwvFJfcYwbjhWpeWDIXDvwHfceZ;
						}
						return yGahmcCsRtytHPRDIGUjChJuQyLwA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class ctiyHpCEBfBYHgXZUIGbEYSNJFqN : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int SjUsjeozjelXXSjZBvoVlZzpUJpi;

					private ControllerMap VXrXoIQwxXdPoUdMQZxHRUPosljN;

					private int BXnOBtDYpwNhPyFjjfJNhhtdPChKA;

					public MapHelper cikrVRJjdqhyUowdCegySbslBEFv;

					private ControllerType wXaOKGXrcbaAWKiWEpPizHdRKyqh;

					public ControllerType zGeHnHzjuIHIZYinjHapADidnOfF;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU naSboupuuFongrhgtyTQrgfsccCN;

					private int eEHcnYPCHZmYjgcvselZxOOvFXTb;

					private int zLiSAPeTvvpOfikXKCRinQQhcmUu;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA OpTNZjAwrIKzyQervPleSvmaPIeW;

					private int YYuTpCwTpaNGQYareDEmtGZFAlrKA;

					private int ftgkvHHDuwQnBGoWfCLPgXBnebvFb;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return VXrXoIQwxXdPoUdMQZxHRUPosljN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VXrXoIQwxXdPoUdMQZxHRUPosljN;
						}
					}

					[DebuggerHidden]
					public ctiyHpCEBfBYHgXZUIGbEYSNJFqN(int P_0)
					{
						SjUsjeozjelXXSjZBvoVlZzpUJpi = P_0;
						BXnOBtDYpwNhPyFjjfJNhhtdPChKA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						naSboupuuFongrhgtyTQrgfsccCN = null;
						OpTNZjAwrIKzyQervPleSvmaPIeW = null;
						SjUsjeozjelXXSjZBvoVlZzpUJpi = -2;
					}

					private bool MoveNext()
					{
						int sjUsjeozjelXXSjZBvoVlZzpUJpi = SjUsjeozjelXXSjZBvoVlZzpUJpi;
						MapHelper mapHelper = cikrVRJjdqhyUowdCegySbslBEFv;
						if (sjUsjeozjelXXSjZBvoVlZzpUJpi != 0)
						{
							if (sjUsjeozjelXXSjZBvoVlZzpUJpi != 1)
							{
								return false;
							}
							SjUsjeozjelXXSjZBvoVlZzpUJpi = -1;
							ftgkvHHDuwQnBGoWfCLPgXBnebvFb++;
							goto IL_00e2;
						}
						SjUsjeozjelXXSjZBvoVlZzpUJpi = -1;
						if (ReInput._id != mapHelper.FvpSbjgVkHHcsEibBaxvEemsoaLB)
						{
							ReInput.CheckInitialized(mapHelper.FvpSbjgVkHHcsEibBaxvEemsoaLB);
							return false;
						}
						naSboupuuFongrhgtyTQrgfsccCN = mapHelper.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(wXaOKGXrcbaAWKiWEpPizHdRKyqh);
						eEHcnYPCHZmYjgcvselZxOOvFXTb = naSboupuuFongrhgtyTQrgfsccCN.kVgCrHansgVHQdOwmDKoORLmXnGv;
						zLiSAPeTvvpOfikXKCRinQQhcmUu = 0;
						goto IL_0107;
						IL_00e2:
						if (ftgkvHHDuwQnBGoWfCLPgXBnebvFb < YYuTpCwTpaNGQYareDEmtGZFAlrKA)
						{
							VXrXoIQwxXdPoUdMQZxHRUPosljN = OpTNZjAwrIKzyQervPleSvmaPIeW.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(ftgkvHHDuwQnBGoWfCLPgXBnebvFb);
							SjUsjeozjelXXSjZBvoVlZzpUJpi = 1;
							return true;
						}
						OpTNZjAwrIKzyQervPleSvmaPIeW = null;
						zLiSAPeTvvpOfikXKCRinQQhcmUu++;
						goto IL_0107;
						IL_0107:
						if (zLiSAPeTvvpOfikXKCRinQQhcmUu < eEHcnYPCHZmYjgcvselZxOOvFXTb)
						{
							OpTNZjAwrIKzyQervPleSvmaPIeW = naSboupuuFongrhgtyTQrgfsccCN.LiHJOfWLuRlIpTeFwKoewXdglkyu(zLiSAPeTvvpOfikXKCRinQQhcmUu).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							YYuTpCwTpaNGQYareDEmtGZFAlrKA = OpTNZjAwrIKzyQervPleSvmaPIeW.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							ftgkvHHDuwQnBGoWfCLPgXBnebvFb = 0;
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
						ctiyHpCEBfBYHgXZUIGbEYSNJFqN ctiyHpCEBfBYHgXZUIGbEYSNJFqN2;
						if (SjUsjeozjelXXSjZBvoVlZzpUJpi == -2 && BXnOBtDYpwNhPyFjjfJNhhtdPChKA == Environment.CurrentManagedThreadId)
						{
							SjUsjeozjelXXSjZBvoVlZzpUJpi = 0;
							ctiyHpCEBfBYHgXZUIGbEYSNJFqN2 = this;
						}
						else
						{
							ctiyHpCEBfBYHgXZUIGbEYSNJFqN2 = new ctiyHpCEBfBYHgXZUIGbEYSNJFqN(0);
							ctiyHpCEBfBYHgXZUIGbEYSNJFqN2.cikrVRJjdqhyUowdCegySbslBEFv = cikrVRJjdqhyUowdCegySbslBEFv;
						}
						ctiyHpCEBfBYHgXZUIGbEYSNJFqN2.wXaOKGXrcbaAWKiWEpPizHdRKyqh = zGeHnHzjuIHIZYinjHapADidnOfF;
						return ctiyHpCEBfBYHgXZUIGbEYSNJFqN2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class hkHRpVxhmggOicfAFsstEjCGSrKv : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int DSSFPqbxikANAMWPbFiciLusliPG;

					private ControllerMap OYjNyLZumnvjcUFAYyipcBaEZcGQ;

					private int ZYnpEdgvuZBztdHMSGCWOxDDSfLK;

					public MapHelper MQBYMOUvUMwGKORaUzgZvoVyZQZA;

					private int cyvjycBPNlcDGyhuMsOZQLzhrYtL;

					public int MDhVsxbjIWGPugsmScWPgwiGHlrNb;

					private int BtIHlpPXwQlTPfSgLRKNXMRsCIgkA;

					private int xOBFOzCIehiQgbbwsobRVrLmmhvIb;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU mNxcbTIeVXMIPfHREfPraVwvFjIyA;

					private int FPaAQJPNHAiFOArmzLqvDfeexpRCA;

					private int epWZNaRuxFuJlUxgdjrDkMXfZsbK;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA KFTdASasYgskiIJmBWzqpdHWUyrkA;

					private int MYkSAZaoVeAqGWdMTiBaAwBKOzIh;

					private int rcGujWgssrrDiYNoZaFBKQOoKsIXA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return OYjNyLZumnvjcUFAYyipcBaEZcGQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OYjNyLZumnvjcUFAYyipcBaEZcGQ;
						}
					}

					[DebuggerHidden]
					public hkHRpVxhmggOicfAFsstEjCGSrKv(int P_0)
					{
						DSSFPqbxikANAMWPbFiciLusliPG = P_0;
						ZYnpEdgvuZBztdHMSGCWOxDDSfLK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						mNxcbTIeVXMIPfHREfPraVwvFjIyA = null;
						KFTdASasYgskiIJmBWzqpdHWUyrkA = null;
						DSSFPqbxikANAMWPbFiciLusliPG = -2;
					}

					private bool MoveNext()
					{
						int dSSFPqbxikANAMWPbFiciLusliPG = DSSFPqbxikANAMWPbFiciLusliPG;
						MapHelper mQBYMOUvUMwGKORaUzgZvoVyZQZA = MQBYMOUvUMwGKORaUzgZvoVyZQZA;
						if (dSSFPqbxikANAMWPbFiciLusliPG != 0)
						{
							if (dSSFPqbxikANAMWPbFiciLusliPG != 1)
							{
								return false;
							}
							DSSFPqbxikANAMWPbFiciLusliPG = -1;
							goto IL_0104;
						}
						DSSFPqbxikANAMWPbFiciLusliPG = -1;
						if (ReInput._id != mQBYMOUvUMwGKORaUzgZvoVyZQZA.FvpSbjgVkHHcsEibBaxvEemsoaLB)
						{
							ReInput.CheckInitialized(mQBYMOUvUMwGKORaUzgZvoVyZQZA.FvpSbjgVkHHcsEibBaxvEemsoaLB);
							return false;
						}
						BtIHlpPXwQlTPfSgLRKNXMRsCIgkA = mQBYMOUvUMwGKORaUzgZvoVyZQZA.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
						xOBFOzCIehiQgbbwsobRVrLmmhvIb = 0;
						goto IL_0161;
						IL_0104:
						rcGujWgssrrDiYNoZaFBKQOoKsIXA++;
						goto IL_0114;
						IL_0161:
						if (xOBFOzCIehiQgbbwsobRVrLmmhvIb < BtIHlpPXwQlTPfSgLRKNXMRsCIgkA)
						{
							mNxcbTIeVXMIPfHREfPraVwvFjIyA = mQBYMOUvUMwGKORaUzgZvoVyZQZA.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(xOBFOzCIehiQgbbwsobRVrLmmhvIb);
							FPaAQJPNHAiFOArmzLqvDfeexpRCA = mNxcbTIeVXMIPfHREfPraVwvFjIyA.kVgCrHansgVHQdOwmDKoORLmXnGv;
							epWZNaRuxFuJlUxgdjrDkMXfZsbK = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (rcGujWgssrrDiYNoZaFBKQOoKsIXA < MYkSAZaoVeAqGWdMTiBaAwBKOzIh)
						{
							ControllerMap controllerMap = KFTdASasYgskiIJmBWzqpdHWUyrkA.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(rcGujWgssrrDiYNoZaFBKQOoKsIXA);
							if (controllerMap.categoryId == cyvjycBPNlcDGyhuMsOZQLzhrYtL)
							{
								OYjNyLZumnvjcUFAYyipcBaEZcGQ = controllerMap;
								DSSFPqbxikANAMWPbFiciLusliPG = 1;
								return true;
							}
							goto IL_0104;
						}
						KFTdASasYgskiIJmBWzqpdHWUyrkA = null;
						epWZNaRuxFuJlUxgdjrDkMXfZsbK++;
						goto IL_0139;
						IL_0139:
						if (epWZNaRuxFuJlUxgdjrDkMXfZsbK < FPaAQJPNHAiFOArmzLqvDfeexpRCA)
						{
							KFTdASasYgskiIJmBWzqpdHWUyrkA = mNxcbTIeVXMIPfHREfPraVwvFjIyA.LiHJOfWLuRlIpTeFwKoewXdglkyu(epWZNaRuxFuJlUxgdjrDkMXfZsbK).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							MYkSAZaoVeAqGWdMTiBaAwBKOzIh = KFTdASasYgskiIJmBWzqpdHWUyrkA.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							rcGujWgssrrDiYNoZaFBKQOoKsIXA = 0;
							goto IL_0114;
						}
						mNxcbTIeVXMIPfHREfPraVwvFjIyA = null;
						xOBFOzCIehiQgbbwsobRVrLmmhvIb++;
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
						hkHRpVxhmggOicfAFsstEjCGSrKv hkHRpVxhmggOicfAFsstEjCGSrKv2;
						if (DSSFPqbxikANAMWPbFiciLusliPG == -2 && ZYnpEdgvuZBztdHMSGCWOxDDSfLK == Environment.CurrentManagedThreadId)
						{
							DSSFPqbxikANAMWPbFiciLusliPG = 0;
							hkHRpVxhmggOicfAFsstEjCGSrKv2 = this;
						}
						else
						{
							hkHRpVxhmggOicfAFsstEjCGSrKv2 = new hkHRpVxhmggOicfAFsstEjCGSrKv(0);
							hkHRpVxhmggOicfAFsstEjCGSrKv2.MQBYMOUvUMwGKORaUzgZvoVyZQZA = MQBYMOUvUMwGKORaUzgZvoVyZQZA;
						}
						hkHRpVxhmggOicfAFsstEjCGSrKv2.cyvjycBPNlcDGyhuMsOZQLzhrYtL = MDhVsxbjIWGPugsmScWPgwiGHlrNb;
						return hkHRpVxhmggOicfAFsstEjCGSrKv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class fmvkChzfInuklTzGlUtIRplFZDUA<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int VqIHkaTbBfaBsvOxeyompVNkSCTh;

					private _0001 fcMIrPEXhtOlqDYlhyEeehhskNaF;

					private int AQdxiwCmXgRuhrNjqkqjbiYdSJze;

					public MapHelper CFZqjNibAliBjeeuvaLuSQrPrrfY;

					private int ZYnhKXmmroTjbgfcktqyKDQmGkDZ;

					public int viakrniNGqILiXpBoPEbSzWjrcIO;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU jHSFOhalKJDkIebAbIkxUAqgrnQxb;

					private int zBtdeSylEOQnpVnenAyJuBZmgcVL;

					private int fXLuJQSmrEkZAehTsRnnyJIccZrj;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA HAkSVMTMjujLpCXxijUxZFFNwQed;

					private int AWjjGrxXGCLXzaIhqvNQlisYWoIK;

					private int bUQdyNGKoXCuMGUVBTusEBvmQqatA;

					private int gxcCIqcvFEUuUvdDDnDqjPukWHzQ;

					private int llXSSlVYBFtlVpldQMJeZjkvxgAW;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return fcMIrPEXhtOlqDYlhyEeehhskNaF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return fcMIrPEXhtOlqDYlhyEeehhskNaF;
						}
					}

					[DebuggerHidden]
					public fmvkChzfInuklTzGlUtIRplFZDUA(int P_0)
					{
						VqIHkaTbBfaBsvOxeyompVNkSCTh = P_0;
						AQdxiwCmXgRuhrNjqkqjbiYdSJze = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						jHSFOhalKJDkIebAbIkxUAqgrnQxb = null;
						HAkSVMTMjujLpCXxijUxZFFNwQed = null;
						VqIHkaTbBfaBsvOxeyompVNkSCTh = -2;
					}

					private bool MoveNext()
					{
						int vqIHkaTbBfaBsvOxeyompVNkSCTh = VqIHkaTbBfaBsvOxeyompVNkSCTh;
						MapHelper cFZqjNibAliBjeeuvaLuSQrPrrfY = CFZqjNibAliBjeeuvaLuSQrPrrfY;
						switch (vqIHkaTbBfaBsvOxeyompVNkSCTh)
						{
						default:
							return false;
						case 0:
						{
							VqIHkaTbBfaBsvOxeyompVNkSCTh = -1;
							if (ReInput._id != cFZqjNibAliBjeeuvaLuSQrPrrfY.FvpSbjgVkHHcsEibBaxvEemsoaLB)
							{
								ReInput.CheckInitialized(cFZqjNibAliBjeeuvaLuSQrPrrfY.FvpSbjgVkHHcsEibBaxvEemsoaLB);
								return false;
							}
							if (nwsTruCLxjorysrNysDvPYrmMcrb.VHpESMrQhYEDlczIeXNfYRtSaZGd<_0001>(out var _))
							{
								jHSFOhalKJDkIebAbIkxUAqgrnQxb = cFZqjNibAliBjeeuvaLuSQrPrrfY.SKsWnSEQeUQpbujbIQBNQowZdTZo<_0001>();
								zBtdeSylEOQnpVnenAyJuBZmgcVL = jHSFOhalKJDkIebAbIkxUAqgrnQxb.kVgCrHansgVHQdOwmDKoORLmXnGv;
								fXLuJQSmrEkZAehTsRnnyJIccZrj = 0;
								goto IL_0124;
							}
							zBtdeSylEOQnpVnenAyJuBZmgcVL = cFZqjNibAliBjeeuvaLuSQrPrrfY.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
							fXLuJQSmrEkZAehTsRnnyJIccZrj = 0;
							goto IL_0287;
						}
						case 1:
							VqIHkaTbBfaBsvOxeyompVNkSCTh = -1;
							goto IL_00eb;
						case 2:
							{
								VqIHkaTbBfaBsvOxeyompVNkSCTh = -1;
								goto IL_0224;
							}
							IL_0224:
							llXSSlVYBFtlVpldQMJeZjkvxgAW++;
							goto IL_0236;
							IL_00eb:
							bUQdyNGKoXCuMGUVBTusEBvmQqatA++;
							goto IL_00fd;
							IL_0124:
							if (fXLuJQSmrEkZAehTsRnnyJIccZrj < zBtdeSylEOQnpVnenAyJuBZmgcVL)
							{
								HAkSVMTMjujLpCXxijUxZFFNwQed = jHSFOhalKJDkIebAbIkxUAqgrnQxb.LiHJOfWLuRlIpTeFwKoewXdglkyu(fXLuJQSmrEkZAehTsRnnyJIccZrj).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								AWjjGrxXGCLXzaIhqvNQlisYWoIK = HAkSVMTMjujLpCXxijUxZFFNwQed.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								bUQdyNGKoXCuMGUVBTusEBvmQqatA = 0;
								goto IL_00fd;
							}
							jHSFOhalKJDkIebAbIkxUAqgrnQxb = null;
							break;
							IL_0287:
							if (fXLuJQSmrEkZAehTsRnnyJIccZrj >= zBtdeSylEOQnpVnenAyJuBZmgcVL)
							{
								break;
							}
							jHSFOhalKJDkIebAbIkxUAqgrnQxb = cFZqjNibAliBjeeuvaLuSQrPrrfY.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(fXLuJQSmrEkZAehTsRnnyJIccZrj);
							AWjjGrxXGCLXzaIhqvNQlisYWoIK = jHSFOhalKJDkIebAbIkxUAqgrnQxb.kVgCrHansgVHQdOwmDKoORLmXnGv;
							bUQdyNGKoXCuMGUVBTusEBvmQqatA = 0;
							goto IL_025d;
							IL_0236:
							if (llXSSlVYBFtlVpldQMJeZjkvxgAW < gxcCIqcvFEUuUvdDDnDqjPukWHzQ)
							{
								if (HAkSVMTMjujLpCXxijUxZFFNwQed.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(llXSSlVYBFtlVpldQMJeZjkvxgAW) is _0001 val && val.categoryId == ZYnhKXmmroTjbgfcktqyKDQmGkDZ)
								{
									fcMIrPEXhtOlqDYlhyEeehhskNaF = val;
									VqIHkaTbBfaBsvOxeyompVNkSCTh = 2;
									return true;
								}
								goto IL_0224;
							}
							HAkSVMTMjujLpCXxijUxZFFNwQed = null;
							bUQdyNGKoXCuMGUVBTusEBvmQqatA++;
							goto IL_025d;
							IL_00fd:
							if (bUQdyNGKoXCuMGUVBTusEBvmQqatA < AWjjGrxXGCLXzaIhqvNQlisYWoIK)
							{
								ControllerMap controllerMap = HAkSVMTMjujLpCXxijUxZFFNwQed.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(bUQdyNGKoXCuMGUVBTusEBvmQqatA);
								if (controllerMap.categoryId == ZYnhKXmmroTjbgfcktqyKDQmGkDZ)
								{
									fcMIrPEXhtOlqDYlhyEeehhskNaF = (_0001)controllerMap;
									VqIHkaTbBfaBsvOxeyompVNkSCTh = 1;
									return true;
								}
								goto IL_00eb;
							}
							HAkSVMTMjujLpCXxijUxZFFNwQed = null;
							fXLuJQSmrEkZAehTsRnnyJIccZrj++;
							goto IL_0124;
							IL_025d:
							if (bUQdyNGKoXCuMGUVBTusEBvmQqatA < AWjjGrxXGCLXzaIhqvNQlisYWoIK)
							{
								HAkSVMTMjujLpCXxijUxZFFNwQed = jHSFOhalKJDkIebAbIkxUAqgrnQxb.LiHJOfWLuRlIpTeFwKoewXdglkyu(bUQdyNGKoXCuMGUVBTusEBvmQqatA).LYmUAmbCzgGoTbembTlgBdvFhNexA;
								gxcCIqcvFEUuUvdDDnDqjPukWHzQ = HAkSVMTMjujLpCXxijUxZFFNwQed.dOLVGySRSIHymrnVvPaFOKsKLzWn;
								llXSSlVYBFtlVpldQMJeZjkvxgAW = 0;
								goto IL_0236;
							}
							jHSFOhalKJDkIebAbIkxUAqgrnQxb = null;
							fXLuJQSmrEkZAehTsRnnyJIccZrj++;
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
						fmvkChzfInuklTzGlUtIRplFZDUA<_0001> fmvkChzfInuklTzGlUtIRplFZDUA2;
						if (VqIHkaTbBfaBsvOxeyompVNkSCTh == -2 && AQdxiwCmXgRuhrNjqkqjbiYdSJze == Environment.CurrentManagedThreadId)
						{
							VqIHkaTbBfaBsvOxeyompVNkSCTh = 0;
							fmvkChzfInuklTzGlUtIRplFZDUA2 = this;
						}
						else
						{
							fmvkChzfInuklTzGlUtIRplFZDUA2 = new fmvkChzfInuklTzGlUtIRplFZDUA<_0001>(0);
							fmvkChzfInuklTzGlUtIRplFZDUA2.CFZqjNibAliBjeeuvaLuSQrPrrfY = CFZqjNibAliBjeeuvaLuSQrPrrfY;
						}
						fmvkChzfInuklTzGlUtIRplFZDUA2.ZYnhKXmmroTjbgfcktqyKDQmGkDZ = viakrniNGqILiXpBoPEbSzWjrcIO;
						return fmvkChzfInuklTzGlUtIRplFZDUA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class BvfqpVtjGuuDTHeSxeVJblhAFcDEb : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int fjYKeMLHFhupmjjcvJfQiAkpNxIu;

					private ControllerMap ghCBZXcPpKrnTNlYLvYZIpEbvnvgA;

					private int OuJPlztccYQPGZwKaoRmRHgjBHEY;

					public MapHelper OyttvkGnkNSWVpYoxHJZBkfFSHpg;

					private ControllerType mvjXKMLCCZOwuVElxTpJNvPkEvBT;

					public ControllerType amttkseSFlGCCHZVOeCuykkLscHb;

					private int mlTfUddtzWXNnFlBscXXKrtALCTk;

					public int zZZPiaKUnrfshbDQfoeQopqoEnIeA;

					private kQwkAQGpxfuwmZzSQKYSLJHpqSgU VvwFGKOJLobYYhkzrCmcxhIEKJSQ;

					private int faNHywNHXYaSsyWKyxFWozFUTtRP;

					private int bnPQDYeHpClfwcLSMmtBVAuzPukA;

					private yiZTVAYmYqfnMStnvrnpZDWxfexCA HfnSdlBMpVulKYcxwcoyJGuuaULaA;

					private int LxiwKHDiLZRBYBQADEfwfyMxkKwb;

					private int AvqzqSgezCGRHjhktuRcHIYhtQveA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ghCBZXcPpKrnTNlYLvYZIpEbvnvgA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ghCBZXcPpKrnTNlYLvYZIpEbvnvgA;
						}
					}

					[DebuggerHidden]
					public BvfqpVtjGuuDTHeSxeVJblhAFcDEb(int P_0)
					{
						fjYKeMLHFhupmjjcvJfQiAkpNxIu = P_0;
						OuJPlztccYQPGZwKaoRmRHgjBHEY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						VvwFGKOJLobYYhkzrCmcxhIEKJSQ = null;
						HfnSdlBMpVulKYcxwcoyJGuuaULaA = null;
						fjYKeMLHFhupmjjcvJfQiAkpNxIu = -2;
					}

					private bool MoveNext()
					{
						int num = fjYKeMLHFhupmjjcvJfQiAkpNxIu;
						MapHelper oyttvkGnkNSWVpYoxHJZBkfFSHpg = OyttvkGnkNSWVpYoxHJZBkfFSHpg;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							fjYKeMLHFhupmjjcvJfQiAkpNxIu = -1;
							goto IL_00e2;
						}
						fjYKeMLHFhupmjjcvJfQiAkpNxIu = -1;
						if (ReInput._id != oyttvkGnkNSWVpYoxHJZBkfFSHpg.FvpSbjgVkHHcsEibBaxvEemsoaLB)
						{
							ReInput.CheckInitialized(oyttvkGnkNSWVpYoxHJZBkfFSHpg.FvpSbjgVkHHcsEibBaxvEemsoaLB);
							return false;
						}
						VvwFGKOJLobYYhkzrCmcxhIEKJSQ = oyttvkGnkNSWVpYoxHJZBkfFSHpg.NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(mvjXKMLCCZOwuVElxTpJNvPkEvBT);
						faNHywNHXYaSsyWKyxFWozFUTtRP = VvwFGKOJLobYYhkzrCmcxhIEKJSQ.kVgCrHansgVHQdOwmDKoORLmXnGv;
						bnPQDYeHpClfwcLSMmtBVAuzPukA = 0;
						goto IL_0117;
						IL_00f2:
						if (AvqzqSgezCGRHjhktuRcHIYhtQveA < LxiwKHDiLZRBYBQADEfwfyMxkKwb)
						{
							ControllerMap controllerMap = HfnSdlBMpVulKYcxwcoyJGuuaULaA.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(AvqzqSgezCGRHjhktuRcHIYhtQveA);
							if (controllerMap.categoryId == mlTfUddtzWXNnFlBscXXKrtALCTk)
							{
								ghCBZXcPpKrnTNlYLvYZIpEbvnvgA = controllerMap;
								fjYKeMLHFhupmjjcvJfQiAkpNxIu = 1;
								return true;
							}
							goto IL_00e2;
						}
						HfnSdlBMpVulKYcxwcoyJGuuaULaA = null;
						bnPQDYeHpClfwcLSMmtBVAuzPukA++;
						goto IL_0117;
						IL_00e2:
						AvqzqSgezCGRHjhktuRcHIYhtQveA++;
						goto IL_00f2;
						IL_0117:
						if (bnPQDYeHpClfwcLSMmtBVAuzPukA < faNHywNHXYaSsyWKyxFWozFUTtRP)
						{
							HfnSdlBMpVulKYcxwcoyJGuuaULaA = VvwFGKOJLobYYhkzrCmcxhIEKJSQ.LiHJOfWLuRlIpTeFwKoewXdglkyu(bnPQDYeHpClfwcLSMmtBVAuzPukA).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							LxiwKHDiLZRBYBQADEfwfyMxkKwb = HfnSdlBMpVulKYcxwcoyJGuuaULaA.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							AvqzqSgezCGRHjhktuRcHIYhtQveA = 0;
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
						BvfqpVtjGuuDTHeSxeVJblhAFcDEb bvfqpVtjGuuDTHeSxeVJblhAFcDEb;
						if (fjYKeMLHFhupmjjcvJfQiAkpNxIu == -2 && OuJPlztccYQPGZwKaoRmRHgjBHEY == Environment.CurrentManagedThreadId)
						{
							fjYKeMLHFhupmjjcvJfQiAkpNxIu = 0;
							bvfqpVtjGuuDTHeSxeVJblhAFcDEb = this;
						}
						else
						{
							bvfqpVtjGuuDTHeSxeVJblhAFcDEb = new BvfqpVtjGuuDTHeSxeVJblhAFcDEb(0);
							bvfqpVtjGuuDTHeSxeVJblhAFcDEb.OyttvkGnkNSWVpYoxHJZBkfFSHpg = OyttvkGnkNSWVpYoxHJZBkfFSHpg;
						}
						bvfqpVtjGuuDTHeSxeVJblhAFcDEb.mlTfUddtzWXNnFlBscXXKrtALCTk = zZZPiaKUnrfshbDQfoeQopqoEnIeA;
						bvfqpVtjGuuDTHeSxeVJblhAFcDEb.mvjXKMLCCZOwuVElxTpJNvPkEvBT = amttkseSFlGCCHZVOeCuykkLscHb;
						return bvfqpVtjGuuDTHeSxeVJblhAFcDEb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly FBvloJYAnsSEnqZpZgYHeIbOgKik cKOPxRIiDkGdvUfXUfYTHtYABAFdb;

				private Player swxGGcbRFMcJsNuxioMKeTGKUsrLb;

				private ControllerHelper NrkDisCXbVyNVgpcypOhEhgkNVtkb;

				private readonly ControllerMapEnabler WyPnxTisElZnKUCThEySZDvnhrVK;

				private readonly ControllerMapLayoutManager UYjDHzopjggWTbTFhPhoIYxCrWOKA;

				private readonly int FvpSbjgVkHHcsEibBaxvEemsoaLB;

				public ControllerMapLayoutManager layoutManager => UYjDHzopjggWTbTFhPhoIYxCrWOKA;

				public ControllerMapEnabler mapEnabler => WyPnxTisElZnKUCThEySZDvnhrVK;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
						{
							ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return swxGGcbRFMcJsNuxioMKeTGKUsrLb.KwoqKDZYKDbbxTNWppgajTwqRqyj.NvFilYvRjbHxgmgfnyIyVkaoPTTE(swxGGcbRFMcJsNuxioMKeTGKUsrLb.jPsZpqMAcPAnkudOsRQkwDRvcsej);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, FBvloJYAnsSEnqZpZgYHeIbOgKik P_2, ControllerMapLayoutManager.ZwEHsomBYpCwhUwueCrLPncgybEq P_3, ControllerMapEnabler.JmqjWaNbmLkTeEMjBbAurWsDFFCl P_4)
				{
					FvpSbjgVkHHcsEibBaxvEemsoaLB = ReInput.id;
					swxGGcbRFMcJsNuxioMKeTGKUsrLb = P_0;
					NrkDisCXbVyNVgpcypOhEhgkNVtkb = P_1;
					cKOPxRIiDkGdvUfXUfYTHtYABAFdb = P_2;
					WyPnxTisElZnKUCThEySZDvnhrVK = new ControllerMapEnabler(P_0, P_4);
					UYjDHzopjggWTbTFhPhoIYxCrWOKA = new ControllerMapLayoutManager(P_0, P_3);
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.buhuabueJhyVhtyejBQPnQenGmUq += WyPnxTisElZnKUCThEySZDvnhrVK.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					mVozgIBmpxsTzdQgxDmxkWifjbkB<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					ukuxKHEgnjKgACgmOeLLaHlNRWJsA<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					rjntzbaDSVZyuWgxWbGjhcNfjDsm(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					OQTZAANwOwpjrARCXJBiRNgWOwaK(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					mVozgIBmpxsTzdQgxDmxkWifjbkB<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					ukuxKHEgnjKgACgmOeLLaHlNRWJsA<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					rjntzbaDSVZyuWgxWbGjhcNfjDsm(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					OQTZAANwOwpjrARCXJBiRNgWOwaK(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void mVozgIBmpxsTzdQgxDmxkWifjbkB<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ZrRsspIEaHixonoJXAAbMBwfjuOf(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void ukuxKHEgnjKgACgmOeLLaHlNRWJsA<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						YrGgnTibURyDWHKcrPkWeESEdOjCc(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void rjntzbaDSVZyuWgxWbGjhcNfjDsm(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ZrRsspIEaHixonoJXAAbMBwfjuOf(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void OQTZAANwOwpjrARCXJBiRNgWOwaK(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						YrGgnTibURyDWHKcrPkWeESEdOjCc(P_0, P_1, P_2, P_3, P_4);
					}
				}

				[IteratorStateMachine(typeof(VxIhZefBaRkaypfHzaEUlxwODOu))]
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new VxIhZefBaRkaypfHzaEUlxwODOu(-2)
					{
						TJyicPVuBJaUoZrCXLHUWGLrljlV = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num; j++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.qZjeYeHXhKLXPibtxyEEpUEcsxJZA(results, true);
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(YGahmcCsRtytHPRDIGUjChJuQyLwA))]
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new YGahmcCsRtytHPRDIGUjChJuQyLwA<T>(-2)
					{
						dbwvFJfcYwbjhWpeWDIXDvwHfceZ = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (nwsTruCLxjorysrNysDvPYrmMcrb.VHpESMrQhYEDlczIeXNfYRtSaZGd<T>(out var controllerType))
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int i = 0; i < num; i++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.jdtDelhgwMFkPjBgYmwNdYFeQfbRB(results, true);
						}
					}
					else
					{
						int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
						for (int j = 0; j < zKrhkjardydsdIOgpYiwrSsGSvBf; j++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU3 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(j);
							int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU3.kVgCrHansgVHQdOwmDKoORLmXnGv;
							for (int k = 0; k < num2; k++)
							{
								kQwkAQGpxfuwmZzSQKYSLJHpqSgU3.LiHJOfWLuRlIpTeFwKoewXdglkyu(k).LYmUAmbCzgGoTbembTlgBdvFhNexA.jdtDelhgwMFkPjBgYmwNdYFeQfbRB(results, true);
							}
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(ctiyHpCEBfBYHgXZUIGbEYSNJFqN))]
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new ctiyHpCEBfBYHgXZUIGbEYSNJFqN(-2)
					{
						cikrVRJjdqhyUowdCegySbslBEFv = this,
						zGeHnHzjuIHIZYinjHapADidnOfF = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.qZjeYeHXhKLXPibtxyEEpUEcsxJZA(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				[IteratorStateMachine(typeof(hkHRpVxhmggOicfAFsstEjCGSrKv))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new hkHRpVxhmggOicfAFsstEjCGSrKv(-2)
					{
						MQBYMOUvUMwGKORaUzgZvoVyZQZA = this,
						MDhVsxbjIWGPugsmScWPgwiGHlrNb = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				[IteratorStateMachine(typeof(fmvkChzfInuklTzGlUtIRplFZDUA))]
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new fmvkChzfInuklTzGlUtIRplFZDUA<T>(-2)
					{
						CFZqjNibAliBjeeuvaLuSQrPrrfY = this,
						viakrniNGqILiXpBoPEbSzWjrcIO = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				[IteratorStateMachine(typeof(BvfqpVtjGuuDTHeSxeVJblhAFcDEb))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new BvfqpVtjGuuDTHeSxeVJblhAFcDEb(-2)
					{
						OyttvkGnkNSWVpYoxHJZBkfFSHpg = this,
						zZZPiaKUnrfshbDQfoeQopqoEnIeA = categoryId,
						amttkseSFlGCCHZVOeCuykkLscHb = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num; j++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.aFEBFZUTdLBsQCYPDvEVuQRnnSwBA(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (nwsTruCLxjorysrNysDvPYrmMcrb.VHpESMrQhYEDlczIeXNfYRtSaZGd<T>(out var controllerType))
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int i = 0; i < num; i++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.JfrlMFHCQOWdjeHmPriyBvBzAozk(categoryId, results, true);
						}
					}
					else
					{
						int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
						for (int j = 0; j < zKrhkjardydsdIOgpYiwrSsGSvBf; j++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU3 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(j);
							int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU3.kVgCrHansgVHQdOwmDKoORLmXnGv;
							for (int k = 0; k < num2; k++)
							{
								kQwkAQGpxfuwmZzSQKYSLJHpqSgU3.LiHJOfWLuRlIpTeFwKoewXdglkyu(k).LYmUAmbCzgGoTbembTlgBdvFhNexA.JfrlMFHCQOWdjeHmPriyBvBzAozk(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.aFEBFZUTdLBsQCYPDvEVuQRnnSwBA(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return yVXZFtpiBAFqXRssuxbslndYsDUh<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return WUwWyRnfxQaqgPeDRPzraZJotBVG(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					return euXWLNBCeVBUZCUwEEIBxFRxYUNs(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					return NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType).tLHWYncFxtGelWBkmFooasRaAXBz(controllerId)?.LYmUAmbCzgGoTbembTlgBdvFhNexA.aFEBFZUTdLBsQCYPDvEVuQRnnSwBA(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return FUFLzuDuuNesSFXhYIxqJcnIfyTaA<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					bBElDCzNQPgEkhpZsNHGoblOIrlYA bBElDCzNQPgEkhpZsNHGoblOIrlYA2 = SKsWnSEQeUQpbujbIQBNQowZdTZo<T>().tLHWYncFxtGelWBkmFooasRaAXBz(controllerId);
					if (bBElDCzNQPgEkhpZsNHGoblOIrlYA2 == null)
					{
						return 0;
					}
					bBElDCzNQPgEkhpZsNHGoblOIrlYA2.LYmUAmbCzgGoTbembTlgBdvFhNexA.JfrlMFHCQOWdjeHmPriyBvBzAozk(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)RXhmCNechKvhXSIcdEYSklrLkQNd(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)MEIAhDItxohRLCBWODbgDBRSVmor(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return (T)laiwauctWWdEspvWcfqyRtIgOSRe(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.fHrjwvjTfKKrFychjJNqyiTwdfss(mapId);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return RXhmCNechKvhXSIcdEYSklrLkQNd(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return MEIAhDItxohRLCBWODbgDBRSVmor(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return laiwauctWWdEspvWcfqyRtIgOSRe(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)VbCzxJPQgLRLKyRjleBaUmBmMltc(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return VbCzxJPQgLRLKyRjleBaUmBmMltc(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						DUdvUzltJHiNozeBBZCtrEoOlSCO(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						IIrIDFJNgtKFtwECRXvCVThujaIk(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						DUdvUzltJHiNozeBBZCtrEoOlSCO(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						DUdvUzltJHiNozeBBZCtrEoOlSCO(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						IIrIDFJNgtKFtwECRXvCVThujaIk(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						DUdvUzltJHiNozeBBZCtrEoOlSCO(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return false;
					}
					return NGZamZBXeNCVkTvQBbWuBnKVGsmAA(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return false;
					}
					return NGZamZBXeNCVkTvQBbWuBnKVGsmAA(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return false;
					}
					return SGVZLKYGaCGlDZQOaIyKwZweouHm(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return false;
					}
					return SGVZLKYGaCGlDZQOaIyKwZweouHm(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						AbHYOSrJBdkhvBdeXofpexQqJBSD(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						IbhkCfhedCVfUjPiWMNGFybsGKGM(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						AbHYOSrJBdkhvBdeXofpexQqJBSD(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else if (mapId >= 0)
					{
						vITGHCixuiqWMftIeIdcLECsHUFdb(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						nmrYdmZycwAZHHZSvErlPDIRfecgA(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						XArfBvbLRlMCQZpNWktVYnbEeGS(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else if (mapId >= 0)
					{
						vITGHCixuiqWMftIeIdcLECsHUFdb(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						nmrYdmZycwAZHHZSvErlPDIRfecgA(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						XArfBvbLRlMCQZpNWktVYnbEeGS(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMaps(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.EiIwrYBZkAwgrQtvgdMGMZILqgOt(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMapsInCategory(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMapsInCategory(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i));
						for (int j = 0; j < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; j++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.BfWbHTVUatbhubnaoBChbHqAIzPN(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.BfWbHTVUatbhubnaoBChbHqAIzPN(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
						for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.FGmFWgHudTpevBaqjNmkQgvEAiNNB(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMapsInLayout(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.sIigssDIXOvojshIgEpmCfHBCMADc(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMapsForController(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMapsForController(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(controllerId);
					if (num >= 0)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.EiIwrYBZkAwgrQtvgdMGMZILqgOt(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(controllerId);
					if (num >= 0)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.BfWbHTVUatbhubnaoBChbHqAIzPN(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
					}
					else
					{
						ClearMapsForControllerInLayout(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(controllerId);
					if (num >= 0)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.sIigssDIXOvojshIgEpmCfHBCMADc(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					for (int i = 0; i < NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						ClearMaps(NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i), userAssignableOnly);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return HEuRlKmjRDCayaUxtbKzvRPhpFFzA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return NJJSElrdvVGQNbfpkUGkmFHyLaEAA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						ActionElementMap actionElementMap = NJJSElrdvVGQNbfpkUGkmFHyLaEAA(NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return ueMqMTPiDcrjJeiMqngxTQBIUsWd(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return IxgWCjmryIqGnyJdExybIVVYVLaH(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(TRPgshaHYVNXNIQJJSHQRsteOANV))]
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new TRPgshaHYVNXNIQJJSHQRsteOANV(-2)
					{
						WZxBMyssScavFnNeGZxFLmxAeAsC = this,
						IxhrTPtNjBzqPWobCvNnjopADOMP = actionId,
						kKWQQLiCscBGytlMqcrOAaHnfNCjA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					return SfYaWBhtWhKGAUlKBQDrYiyCYjqS(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					return xvtFjobFQwUVYoVInmTjCSiGkSCBA(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return QowbrmosiJdcCfPoxtfnBHARlCBW(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return pVunLaqTOJQtqEVrOilVReCIOndO(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return jAltUCUOSEvGxeynBxMxZeNNgSrp(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						ActionElementMap actionElementMap = jAltUCUOSEvGxeynBxMxZeNNgSrp(NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return mjGwHMxQEhEgIiHKaQXLiyFXTsmX(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return WDTIJEAHQeatOAToELfYscCCksOmc(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(UjdTijXDeRPeNAPiPgvVvxyqXgvU))]
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new UjdTijXDeRPeNAPiPgvVvxyqXgvU(-2)
					{
						UqHnHLznmcethMNnzoTRnIUkibXL = this,
						ealIXIjXRjqsbSlVRicJLZdsnOUE = actionId,
						AwQXujYfijUBBNUAAXERvCMLubPH = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return sLquldHonAsgsXswoojllgxVqsLd(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return VeVnMmSZnxlnpsrWSeEiBnunpOdL(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return UYRnhvUTsUgJzwedIGsUbUHzKFxj(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return ZOlewByjFwaMseCxOdUQOmPWTlwGA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return LvRFhAHLyahHouiPIhhLRpIKfQIh(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						ActionElementMap actionElementMap = LvRFhAHLyahHouiPIhhLRpIKfQIh(NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return aBMWFwMKpcaFvoDvWqYeSIhUURJf(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return kAPCLDuhjEGPwRgVFpvAKeOAzCpo(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(xFHSIihlfmhHEhnFFpxEOaPhifPO))]
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new xFHSIihlfmhHEhnFFpxEOaPhifPO(-2)
					{
						htOlvjWeKGkwRxrhiAtETMDniHmaA = this,
						IYIuqMhOlahGigmIBvQQfvwwlovCb = actionId,
						VGqZVvvwtgiaHpUAFyYYLqPiUlID = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return mbeeQFEAxYYBKukXUigcsbwpkOZz(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					return BcihHLhJkwbTeQuXjYTiIpFCSkAeb(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return HxNHaBHGZHthmHZvrVTmDJCLYgYk(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, skipDisabledMaps);
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return uRdbMgOouMxAXMmmjaZfIRkjCgeJ(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, actionId, skipDisabledMaps);
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return uRdbMgOouMxAXMmmjaZfIRkjCgeJ(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, skipDisabledMaps);
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return HTEbKPKNLuEhSZdbwqXTEGoeXgWY(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, actionId, skipDisabledMaps);
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return HTEbKPKNLuEhSZdbwqXTEGoeXgWY(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, skipDisabledMaps, results);
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return rIyfOTNnfvBxjHExitgDmpOPrEODA(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, actionId, skipDisabledMaps, results);
					JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return rIyfOTNnfvBxjHExitgDmpOPrEODA(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<T>.array;
					}
					return lqqMKuwfXanEGdKEayxPfRfrXGZd<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return JSsFtAlAhekiNgggEaOPbrSYPdzbA(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<T>.array;
					}
					return ieBpSwSaspXLrHxnDwRCFnbCxaSy<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return ISElWcnBYEaicjQrWZcSmRcSAGaU(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						ArrayTools.Combine(ref array, ISElWcnBYEaicjQrWZcSmRcSAGaU(NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int num = 0;
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num2; j++)
						{
							num += kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.PhHjaJwKAnziTQaRrUtpHVPbCBfy(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int num = 0;
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num2; i++)
					{
						num += kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.PhHjaJwKAnziTQaRrUtpHVPbCBfy(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					return NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType).tLHWYncFxtGelWBkmFooasRaAXBz(controllerId)?.LYmUAmbCzgGoTbembTlgBdvFhNexA.PhHjaJwKAnziTQaRrUtpHVPbCBfy(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num2; j++)
						{
							num += kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.dGZSqDEnqFYsLbEsemONCUFOfABm(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						ControllerType controllerType = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.aYslZWNqYSKQCmfApyVjmxykTTGL(i);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num2; i++)
					{
						num += kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.dGZSqDEnqFYsLbEsemONCUFOfABm(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num2; i++)
					{
						num += kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.QuVvmkgcbeUZkpWDszswvbSWNXcb(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					return NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controller.type).tLHWYncFxtGelWBkmFooasRaAXBz(controller.id)?.LYmUAmbCzgGoTbembTlgBdvFhNexA.dGZSqDEnqFYsLbEsemONCUFOfABm(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					return NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controller.type).tLHWYncFxtGelWBkmFooasRaAXBz(controller.id)?.LYmUAmbCzgGoTbembTlgBdvFhNexA.QuVvmkgcbeUZkpWDszswvbSWNXcb(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						ZriLZCTatFGjdaPdbWZSusZoxgTkA(false);
						break;
					case ControllerType.Keyboard:
						RasNdShhTTBWOlZqpwnnxJTdGBmY(false);
						break;
					case ControllerType.Mouse:
						DRDJIpKtxBajkxzUKFruVukEbnfe(false);
						break;
					case ControllerType.Custom:
						ztHGEmMoQBcYMgtcAMVRCxjhdBSnc(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num; j++)
						{
							if (kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA.QtMcFoEyvKavLQoQjZZLQRaCXEFm(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
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
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num; i++)
					{
						if (kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.QtMcFoEyvKavLQoQjZZLQRaCXEFm(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return swxGGcbRFMcJsNuxioMKeTGKUsrLb.KwoqKDZYKDbbxTNWppgajTwqRqyj.VpuNDZZuzINQmbsfHDcBrOyCzwtf(swxGGcbRFMcJsNuxioMKeTGKUsrLb.jPsZpqMAcPAnkudOsRQkwDRvcsej, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != FvpSbjgVkHHcsEibBaxvEemsoaLB)
					{
						ReInput.CheckInitialized(FvpSbjgVkHHcsEibBaxvEemsoaLB);
						return null;
					}
					return swxGGcbRFMcJsNuxioMKeTGKUsrLb.KwoqKDZYKDbbxTNWppgajTwqRqyj.OyKOFlNzKDxseCZpbakxpSXhTRdF(swxGGcbRFMcJsNuxioMKeTGKUsrLb.jPsZpqMAcPAnkudOsRQkwDRvcsej, behaviorName);
				}

				internal void QBFIOvrjnFXLABGPyERQbTCqTnfRA()
				{
					WyPnxTisElZnKUCThEySZDvnhrVK.LoadDefaults();
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.LoadDefaults();
				}

				internal void ZriLZCTatFGjdaPdbWZSusZoxgTkA(bool P_0)
				{
					if (cKOPxRIiDkGdvUfXUfYTHtYABAFdb.FjdRDzhzanLcKonqytljPoMLGPUdA == null)
					{
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick);
					NrkDisCXbVyNVgpcypOhEhgkNVtkb.YjBcjKBRZyLgPAULJtKNolmycTvt.ZRHzgWWvzWNKMVbVIgKoTRxyjGOW();
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num; i++)
					{
						gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ hiWJtllRqMdCqcwtrhSJVifgeTuZ = (gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ)kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.PHddzgndMnzRWWZdLPxBNVqdUdeV();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.SypULfmhiRJaajsxCpMqFoMTkKpm(j).enabled;
							}
						}
						hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.yMEKuWSmzlISJJurbDPNvEDqjrct(false);
						for (int k = 0; k < cKOPxRIiDkGdvUfXUfYTHtYABAFdb.FjdRDzhzanLcKonqytljPoMLGPUdA.Length; k++)
						{
							iXHNGHEMWPTHNCTbbCZeTnqVSAxq(hiWJtllRqMdCqcwtrhSJVifgeTuZ.CeCCWHxtgtrfLYpuZqBgEmzIGJGG, hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy, cKOPxRIiDkGdvUfXUfYTHtYABAFdb.FjdRDzhzanLcKonqytljPoMLGPUdA[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.PHddzgndMnzRWWZdLPxBNVqdUdeV());
							for (int l = 0; l < num3; l++)
							{
								hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.SypULfmhiRJaajsxCpMqFoMTkKpm(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = false;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.Apply();
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void RasNdShhTTBWOlZqpwnnxJTdGBmY(bool P_0)
				{
					if (cKOPxRIiDkGdvUfXUfYTHtYABAFdb.PcvajCnQfqKirskJggZxCLGLoaocA == null)
					{
						return;
					}
					yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Keyboard).tLHWYncFxtGelWBkmFooasRaAXBz(0).LYmUAmbCzgGoTbembTlgBdvFhNexA;
					bool[] array = null;
					if (!P_0)
					{
						int num = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(i).enabled;
						}
					}
					yiZTVAYmYqfnMStnvrnpZDWxfexCA2.EiIwrYBZkAwgrQtvgdMGMZILqgOt(false);
					for (int j = 0; j < cKOPxRIiDkGdvUfXUfYTHtYABAFdb.PcvajCnQfqKirskJggZxCLGLoaocA.Length; j++)
					{
						PFFTPKJTOCcLmdfRwTmvXmybQpDh pFFTPKJTOCcLmdfRwTmvXmybQpDh = cKOPxRIiDkGdvUfXUfYTHtYABAFdb.PcvajCnQfqKirskJggZxCLGLoaocA[j];
						if (pFFTPKJTOCcLmdfRwTmvXmybQpDh.mAJfafQvISRBmZsXAEuqfhiscMOkA >= 0 && pFFTPKJTOCcLmdfRwTmvXmybQpDh.JYVdYUJmufBAbEAjAAHbUucDnkRfA >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, pFFTPKJTOCcLmdfRwTmvXmybQpDh.mAJfafQvISRBmZsXAEuqfhiscMOkA, pFFTPKJTOCcLmdfRwTmvXmybQpDh.JYVdYUJmufBAbEAjAAHbUucDnkRfA);
							if (P_0)
							{
								keyboardMap.enabled = pFFTPKJTOCcLmdfRwTmvXmybQpDh.YSSaKAJKGGspXKDkRXyOnnpQJWmyA;
							}
							DUdvUzltJHiNozeBBZCtrEoOlSCO(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn);
						for (int k = 0; k < num2; k++)
						{
							yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = false;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.Apply();
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void DRDJIpKtxBajkxzUKFruVukEbnfe(bool P_0)
				{
					if (cKOPxRIiDkGdvUfXUfYTHtYABAFdb.ZZMftirkNQfndUEfzFVWKHCBDpaJA == null)
					{
						return;
					}
					yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Mouse).tLHWYncFxtGelWBkmFooasRaAXBz(0).LYmUAmbCzgGoTbembTlgBdvFhNexA;
					bool[] array = null;
					if (!P_0)
					{
						int num = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(i).enabled;
						}
					}
					yiZTVAYmYqfnMStnvrnpZDWxfexCA2.EiIwrYBZkAwgrQtvgdMGMZILqgOt(false);
					for (int j = 0; j < cKOPxRIiDkGdvUfXUfYTHtYABAFdb.ZZMftirkNQfndUEfzFVWKHCBDpaJA.Length; j++)
					{
						PFFTPKJTOCcLmdfRwTmvXmybQpDh pFFTPKJTOCcLmdfRwTmvXmybQpDh = cKOPxRIiDkGdvUfXUfYTHtYABAFdb.ZZMftirkNQfndUEfzFVWKHCBDpaJA[j];
						if (pFFTPKJTOCcLmdfRwTmvXmybQpDh.mAJfafQvISRBmZsXAEuqfhiscMOkA >= 0 && pFFTPKJTOCcLmdfRwTmvXmybQpDh.JYVdYUJmufBAbEAjAAHbUucDnkRfA >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, pFFTPKJTOCcLmdfRwTmvXmybQpDh.mAJfafQvISRBmZsXAEuqfhiscMOkA, pFFTPKJTOCcLmdfRwTmvXmybQpDh.JYVdYUJmufBAbEAjAAHbUucDnkRfA);
							if (P_0)
							{
								mouseMap.enabled = pFFTPKJTOCcLmdfRwTmvXmybQpDh.YSSaKAJKGGspXKDkRXyOnnpQJWmyA;
							}
							DUdvUzltJHiNozeBBZCtrEoOlSCO(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn);
						for (int k = 0; k < num2; k++)
						{
							yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = false;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.Apply();
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void ztHGEmMoQBcYMgtcAMVRCxjhdBSnc(bool P_0)
				{
					if (cKOPxRIiDkGdvUfXUfYTHtYABAFdb.zEnrwIeRMGbGzHGhBDSOwAMukjwp == null)
					{
						return;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num; i++)
					{
						gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ hiWJtllRqMdCqcwtrhSJVifgeTuZ = (gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ)kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.PHddzgndMnzRWWZdLPxBNVqdUdeV();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.SypULfmhiRJaajsxCpMqFoMTkKpm(j).enabled;
							}
						}
						hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.yMEKuWSmzlISJJurbDPNvEDqjrct(false);
						for (int k = 0; k < cKOPxRIiDkGdvUfXUfYTHtYABAFdb.zEnrwIeRMGbGzHGhBDSOwAMukjwp.Length; k++)
						{
							VQvXcBnVuKwQWLIEJaXBBltJAjdc(hiWJtllRqMdCqcwtrhSJVifgeTuZ.CeCCWHxtgtrfLYpuZqBgEmzIGJGG, hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy, cKOPxRIiDkGdvUfXUfYTHtYABAFdb.zEnrwIeRMGbGzHGhBDSOwAMukjwp[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.PHddzgndMnzRWWZdLPxBNVqdUdeV());
							for (int l = 0; l < num3; l++)
							{
								hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy.SypULfmhiRJaajsxCpMqFoMTkKpm(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = false;
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.Apply();
					UYjDHzopjggWTbTFhPhoIYxCrWOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				private kQwkAQGpxfuwmZzSQKYSLJHpqSgU SKsWnSEQeUQpbujbIQBNQowZdTZo<_0001>() where _0001 : ControllerMap
				{
					return NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(nwsTruCLxjorysrNysDvPYrmMcrb.QTSvuaSRAcyyNeZnbicDtrpbJvdv<_0001>());
				}

				internal global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> ApbBbqkbKqoKuUTfRshFDymDxfjrB(Joystick P_0, bool P_1)
				{
					if (P_0 == null || cKOPxRIiDkGdvUfXUfYTHtYABAFdb.FjdRDzhzanLcKonqytljPoMLGPUdA == null)
					{
						return null;
					}
					global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> ueUsBXRzKVLCQLMbRoTxcbDAhmUZ = new global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap>(P_0.id);
					for (int i = 0; i < cKOPxRIiDkGdvUfXUfYTHtYABAFdb.FjdRDzhzanLcKonqytljPoMLGPUdA.Length; i++)
					{
						iXHNGHEMWPTHNCTbbCZeTnqVSAxq(P_0, ueUsBXRzKVLCQLMbRoTxcbDAhmUZ, cKOPxRIiDkGdvUfXUfYTHtYABAFdb.FjdRDzhzanLcKonqytljPoMLGPUdA[i], P_1);
					}
					if (ueUsBXRzKVLCQLMbRoTxcbDAhmUZ.PHddzgndMnzRWWZdLPxBNVqdUdeV() == 0)
					{
						return null;
					}
					return ueUsBXRzKVLCQLMbRoTxcbDAhmUZ;
				}

				private void iXHNGHEMWPTHNCTbbCZeTnqVSAxq(Joystick P_0, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> P_1, PFFTPKJTOCcLmdfRwTmvXmybQpDh P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.mAJfafQvISRBmZsXAEuqfhiscMOkA >= 0 && P_2.JYVdYUJmufBAbEAjAAHbUucDnkRfA >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.cEwcgjjduDknbeUijZLXUaDeJMmZ(P_0, P_2.mAJfafQvISRBmZsXAEuqfhiscMOkA, P_2.JYVdYUJmufBAbEAjAAHbUucDnkRfA);
						CsUcoIEdaYqkNpAMGzzHSHTgKUySA(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.YSSaKAJKGGspXKDkRXyOnnpQJWmyA ? BoolOption.True : BoolOption.False);
						}
						P_1.xhnAMWEZdHretLBRjxonoDkcnRzPA(joystickMap, boolOption);
					}
				}

				internal global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<CustomControllerMap> lZIwYdEIvgogPNwcjWrKMLBADbqZ(CustomController P_0, bool P_1)
				{
					if (P_0 == null || cKOPxRIiDkGdvUfXUfYTHtYABAFdb.zEnrwIeRMGbGzHGhBDSOwAMukjwp == null)
					{
						return null;
					}
					global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<CustomControllerMap> ueUsBXRzKVLCQLMbRoTxcbDAhmUZ = new global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<CustomControllerMap>(P_0.id);
					for (int i = 0; i < cKOPxRIiDkGdvUfXUfYTHtYABAFdb.zEnrwIeRMGbGzHGhBDSOwAMukjwp.Length; i++)
					{
						VQvXcBnVuKwQWLIEJaXBBltJAjdc(P_0, ueUsBXRzKVLCQLMbRoTxcbDAhmUZ, cKOPxRIiDkGdvUfXUfYTHtYABAFdb.zEnrwIeRMGbGzHGhBDSOwAMukjwp[i], P_1);
					}
					if (ueUsBXRzKVLCQLMbRoTxcbDAhmUZ.PHddzgndMnzRWWZdLPxBNVqdUdeV() == 0)
					{
						return null;
					}
					return ueUsBXRzKVLCQLMbRoTxcbDAhmUZ;
				}

				private void VQvXcBnVuKwQWLIEJaXBBltJAjdc(CustomController P_0, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<CustomControllerMap> P_1, PFFTPKJTOCcLmdfRwTmvXmybQpDh P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.mAJfafQvISRBmZsXAEuqfhiscMOkA >= 0 && P_2.JYVdYUJmufBAbEAjAAHbUucDnkRfA >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.RifLOhoZwdAImmgTfQyFqnUIpNjg(P_2.mAJfafQvISRBmZsXAEuqfhiscMOkA, P_0.sourceControllerId, P_2.JYVdYUJmufBAbEAjAAHbUucDnkRfA);
						CsUcoIEdaYqkNpAMGzzHSHTgKUySA(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.YSSaKAJKGGspXKDkRXyOnnpQJWmyA ? BoolOption.True : BoolOption.False);
						}
						P_1.xhnAMWEZdHretLBRjxonoDkcnRzPA(customControllerMap, boolOption);
					}
				}

				internal void CsUcoIEdaYqkNpAMGzzHSHTgKUySA(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = swxGGcbRFMcJsNuxioMKeTGKUsrLb.jPsZpqMAcPAnkudOsRQkwDRvcsej;
						P_0.YdxptuxNGpUaQtWkYqBlEXOcgbkk(P_1);
					}
				}

				private IList<_0001> yVXZFtpiBAFqXRssuxbslndYsDUh<_0001>(int P_0) where _0001 : ControllerMap
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = SKsWnSEQeUQpbujbIQBNQowZdTZo<_0001>();
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.MpEiHMOPFAgyzhELMElGisruXUvLA<_0001>();
				}

				private IList<_0001> IoKcXlxmJLBhxfGbjAIoFzvQqLaIA<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return SKsWnSEQeUQpbujbIQBNQowZdTZo<_0001>().GaJgQuIamoKKQXLUVHCwfVaefbveA(P_0)?.LYmUAmbCzgGoTbembTlgBdvFhNexA.MpEiHMOPFAgyzhELMElGisruXUvLA<_0001>();
				}

				private IList<ControllerMap> WUwWyRnfxQaqgPeDRPzraZJotBVG(ControllerType P_0, int P_1)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
				}

				private IList<ControllerMap> IoKcXlxmJLBhxfGbjAIoFzvQqLaIA(Controller P_0)
				{
					return WUwWyRnfxQaqgPeDRPzraZJotBVG(P_0.type, P_0.id);
				}

				private void ZAhRBXgxpgzkmGmTXjKKgGERadqT(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					ZrRsspIEaHixonoJXAAbMBwfjuOf(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void ePlHvwgAnmRRJteDmcsJmGolbSJF(Controller P_0, int P_1, int P_2)
				{
					MwKbkZGVkXsnuHAPzlqIcCjEpaSrb(P_0, P_1, P_2, BoolOption.Default);
				}

				private void aylVsqRCidhgOZGhbRFVtGrDkcxj(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					YrGgnTibURyDWHKcrPkWeESEdOjCc(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void IRmhlfgtpBidTrnBJOwHwreanHkh(Controller P_0, string P_1, string P_2)
				{
					CtQSlSyAtHehPGHBNGXBEAudPbJy(P_0, P_1, P_2, BoolOption.Default);
				}

				private void ZrRsspIEaHixonoJXAAbMBwfjuOf(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num >= 0)
					{
						Controller controller = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
						ControllerMap controllerMap = ReInput.UserData.zQmRzuxxMzBJuAOvKUHvmpMofonu(controller, P_2, P_3);
						DUdvUzltJHiNozeBBZCtrEoOlSCO(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void MwKbkZGVkXsnuHAPzlqIcCjEpaSrb(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					ZrRsspIEaHixonoJXAAbMBwfjuOf(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void YrGgnTibURyDWHKcrPkWeESEdOjCc(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						ZrRsspIEaHixonoJXAAbMBwfjuOf(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void CtQSlSyAtHehPGHBNGXBEAudPbJy(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					YrGgnTibURyDWHKcrPkWeESEdOjCc(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void IIrIDFJNgtKFtwECRXvCVThujaIk(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0.type);
						int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_0.id);
						if (num >= 0)
						{
							CsUcoIEdaYqkNpAMGzzHSHTgKUySA(P_0, P_1);
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.vYfFPABoODncxWxSQwJZgGFldPlsA(P_1, P_2);
							WyPnxTisElZnKUCThEySZDvnhrVK.Apply();
						}
					}
				}

				private void DUdvUzltJHiNozeBBZCtrEoOlSCO(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						IIrIDFJNgtKFtwECRXvCVThujaIk(controller, P_2, P_3);
					}
				}

				private bool NGZamZBXeNCVkTvQBbWuBnKVGsmAA(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0).eoyYPrzBBUZZQhpjyHILTteiVtU(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.cqhZHeJRTSeEFHBVRFEAXCJriwBEA(P_0);
					try
					{
						ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
						if (!controllerMap.RNeOYPoEHRIsiNlToZQsNTYcDSPS(P_2))
						{
							return false;
						}
					}
					finally
					{
						ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
					}
					DUdvUzltJHiNozeBBZCtrEoOlSCO(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int vFQONpyzfcpDMwHdyYlYHmaEeVoAA(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0).eoyYPrzBBUZZQhpjyHILTteiVtU(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (NGZamZBXeNCVkTvQBbWuBnKVGsmAA(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool SGVZLKYGaCGlDZQOaIyKwZweouHm(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0).eoyYPrzBBUZZQhpjyHILTteiVtU(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.cqhZHeJRTSeEFHBVRFEAXCJriwBEA(P_0);
					try
					{
						ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
						if (!controllerMap.iBjFSVlKzgmNUdLlAycNVGDMotNK(P_2))
						{
							return false;
						}
					}
					finally
					{
						ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
					}
					DUdvUzltJHiNozeBBZCtrEoOlSCO(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int neQcUNVENKZirKdVViMdChaStoVC(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0).eoyYPrzBBUZZQhpjyHILTteiVtU(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (SGVZLKYGaCGlDZQOaIyKwZweouHm(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void AbHYOSrJBdkhvBdeXofpexQqJBSD(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num >= 0)
					{
						Controller controller = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
						ControllerMap controllerMap = ControllerMap.TLEobasZFUPjrWXdtnOusyvdjpCg(controller, P_2, P_3);
						DUdvUzltJHiNozeBBZCtrEoOlSCO(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void sDTGDeFZyZGrJaxRsWmXzyYNcEDn(Controller P_0, int P_1, int P_2)
				{
					AbHYOSrJBdkhvBdeXofpexQqJBSD(P_0.type, P_0.id, P_1, P_2);
				}

				private void IbhkCfhedCVfUjPiWMNGFybsGKGM(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						AbHYOSrJBdkhvBdeXofpexQqJBSD(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void IfThsfdmAQcMMywARKqxcEQUsGjH(Controller P_0, string P_1, string P_2)
				{
					IbhkCfhedCVfUjPiWMNGFybsGKGM(P_0.type, P_0.id, P_1, P_2);
				}

				private void vITGHCixuiqWMftIeIdcLECsHUFdb(ControllerType P_0, int P_1, int P_2)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num >= 0)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.CRwNOXHJLrfFovcLPgaXskHNrFHN(P_2);
					}
				}

				private void PDWFlixGzvzSqlHlqjzRUpqqczER(Controller P_0, int P_1)
				{
					vITGHCixuiqWMftIeIdcLECsHUFdb(P_0.type, P_0.id, P_1);
				}

				private void KUxMmaRZYynEsrYXoBPWdHVpjnXD(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num >= 0)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.EZqnACzogfZLFijpruddjSxtetBB(P_2);
					}
				}

				private void yTNuFriuEBPKlEUXQhrOezmqmZZG(Controller P_0, ControllerMap P_1)
				{
					vITGHCixuiqWMftIeIdcLECsHUFdb(P_0.type, P_0.id, P_1.id);
				}

				private void nmrYdmZycwAZHHZSvErlPDIRfecgA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num >= 0)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.FGmFWgHudTpevBaqjNmkQgvEAiNNB(P_2, P_3);
					}
				}

				private void hENBBEEbvIPlcpJKNABvhscGnnWf(Controller P_0, int P_1, int P_2)
				{
					nmrYdmZycwAZHHZSvErlPDIRfecgA(P_0.type, P_0.id, P_1, P_2);
				}

				private void XArfBvbLRlMCQZpNWktVYnbEeGS(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.FGmFWgHudTpevBaqjNmkQgvEAiNNB(mapCategoryId, layoutId);
						}
					}
				}

				private void xGdmkVVAevbCknBaTIYGQPZFKcaU(Controller P_0, string P_1, string P_2)
				{
					XArfBvbLRlMCQZpNWktVYnbEeGS(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap RXhmCNechKvhXSIcdEYSklrLkQNd(ControllerType P_0, int P_1, int P_2)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					return kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.fHrjwvjTfKKrFychjJNqyiTwdfss(P_2);
				}

				private ControllerMap ydpAUBEeyWIiDQPiBnVfwWNPytbIA(Controller P_0, int P_1)
				{
					return RXhmCNechKvhXSIcdEYSklrLkQNd(P_0.type, P_0.id, P_1);
				}

				private ControllerMap MEIAhDItxohRLCBWODbgDBRSVmor(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					return kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ruhplQURSYrFJxrwxBAfdLeXySbi(P_2, P_3);
				}

				private ControllerMap ZMrIWHeOMFiyOpxMJgddboErEGAAA(Controller P_0, int P_1, int P_2)
				{
					return MEIAhDItxohRLCBWODbgDBRSVmor(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap laiwauctWWdEspvWcfqyRtIgOSRe(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return MEIAhDItxohRLCBWODbgDBRSVmor(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap QCbIOhJKDKdoDBdIyfoBZShamzqx(Controller P_0, string P_1, string P_2)
				{
					return laiwauctWWdEspvWcfqyRtIgOSRe(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap VbCzxJPQgLRLKyRjleBaUmBmMltc(ControllerType P_0, int P_1, int P_2)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					return kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.uYLJqIaTsvVGebbjARlMOjuRRzJh(P_2);
				}

				private ControllerMap UleIkgeyGprciSlPsuxSGbRquWnI(Controller P_0, int P_1)
				{
					return VbCzxJPQgLRLKyRjleBaUmBmMltc(P_0.type, P_0.id, P_1);
				}

				private ControllerMap tuCwzKJEThcItAGIvrCTyaegeeIu(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return VbCzxJPQgLRLKyRjleBaUmBmMltc(P_0, P_1, mapCategoryId);
				}

				private ControllerMap qcwUWYzDozKyFhyOGyiDMSQcMShg(Controller P_0, string P_1)
				{
					return tuCwzKJEThcItAGIvrCTyaegeeIu(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] ZFdQmArIBWqVxWeiIHsZPUiUsJke(ControllerType P_0)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = 0;
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						num += kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.dOLVGySRSIHymrnVvPaFOKsKLzWn;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; j++)
					{
						yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA;
						for (int k = 0; k < yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn; k++)
						{
							array[num] = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] JSsFtAlAhekiNgggEaOPbrSYPdzbA(ControllerType P_0, int P_1, bool P_2)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA;
					for (int i = 0; i < yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn; i++)
					{
						ControllerMap controllerMap = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
						list.Add(ControllerMapSaveData.RrBuWyaxyukNBkJrMOCMOLbBMZwV(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] lqqMKuwfXanEGdKEayxPfRfrXGZd<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = nwsTruCLxjorysrNysDvPYrmMcrb.erIwLCJKPshyVOuDaSfkwJWzIceK<_0001>();
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA;
					for (int i = 0; i < yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn; i++)
					{
						ControllerMap controllerMap = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
						list.Add(ControllerMapSaveData.RrBuWyaxyukNBkJrMOCMOLbBMZwV<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] ISElWcnBYEaicjQrWZcSmRcSAGaU(ControllerType P_0, bool P_1)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA;
						for (int j = 0; j < yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn; j++)
						{
							ControllerMap controllerMap = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
							list.Add(ControllerMapSaveData.RrBuWyaxyukNBkJrMOCMOLbBMZwV(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] ieBpSwSaspXLrHxnDwRCFnbCxaSy<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = nwsTruCLxjorysrNysDvPYrmMcrb.erIwLCJKPshyVOuDaSfkwJWzIceK<_0001>();
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA;
						for (int j = 0; j < yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn; j++)
						{
							ControllerMap controllerMap = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
							list.Add(ControllerMapSaveData.RrBuWyaxyukNBkJrMOCMOLbBMZwV<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int bxsFxRwMWkMbZGOuqaompxPwfVbgA(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return 0;
					}
					return kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.aFEBFZUTdLBsQCYPDvEVuQRnnSwBA(P_2, P_3, false);
				}

				private int sjRIEplnjeQILjyKDcHjEMnAYkUf(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return bxsFxRwMWkMbZGOuqaompxPwfVbgA(P_0.type, P_0.id, P_1, P_2);
				}

				private int qEtBCBmJdsgrKAzFFmrywXQzBvCCb(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return bxsFxRwMWkMbZGOuqaompxPwfVbgA(P_0, P_1, mapCategoryId, P_3);
				}

				private int DDeHdCMeMVihJHKtvTctLuJkfufAA(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return qEtBCBmJdsgrKAzFFmrywXQzBvCCb(P_0.type, P_0.id, P_1, P_2);
				}

				[IteratorStateMachine(typeof(CHBeYhaJOrFhbBiwmBHhNtNDgsOrA))]
				private IEnumerable<ControllerMap> euXWLNBCeVBUZCUwEEIBxFRxYUNs(ControllerType P_0, int P_1, int P_2)
				{
					return new CHBeYhaJOrFhbBiwmBHhNtNDgsOrA(-2)
					{
						TMHbSLKewczYWaDywzZTnTdRHXgK = this,
						nSOeJABkSzGykYQkgURQhJrpbQLk = P_0,
						zNebBUkzhKpHarxVBPRHjXGqVnmpA = P_1,
						rkiTYeuXgNKyYdbPolEdFvUmhqrR = P_2
					};
				}

				[IteratorStateMachine(typeof(dLhAfsgfGsprlNeXNqeeICwFpRkYb))]
				private IEnumerable<_0001> FUFLzuDuuNesSFXhYIxqJcnIfyTaA<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new dLhAfsgfGsprlNeXNqeeICwFpRkYb<_0001>(-2)
					{
						euToHPrjegaGGFFsDgtYrynyVzweA = this,
						JqMNCisoiQjlcfMIrPFrywDykAOeA = P_0,
						SgcRSxQxnersQwocMRGyuXiOeZXh = P_1
					};
				}

				private ActionElementMap NJJSElrdvVGQNbfpkUGkmFHyLaEAA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
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

				private ActionElementMap gOPrrZnbhmALDFmQgIdogDqRnqTFA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return NJJSElrdvVGQNbfpkUGkmFHyLaEAA(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(VlkOjZwflTwcKImrejQCbMEHdchi))]
				private IEnumerable<ActionElementMap> IxgWCjmryIqGnyJdExybIVVYVLaH(ControllerType P_0, int P_1, bool P_2)
				{
					return new VlkOjZwflTwcKImrejQCbMEHdchi(-2)
					{
						cDRupiMNSoSTxcDyoqbOdHxWQqpl = this,
						dHePdrYMLqSfedkZIdzPGtkbSvXj = P_0,
						MLZClwPxoTsJvWCJMXrClcfLNCcI = P_1,
						iggkGKxirQLaPBsQcCJFMBvgWEhN = P_2
					};
				}

				private IEnumerable<ActionElementMap> GoPsyjvZKdATaoclltVPBkQWeRFx(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return IxgWCjmryIqGnyJdExybIVVYVLaH(P_0, num, P_2);
				}

				private ActionElementMap jAltUCUOSEvGxeynBxMxZeNNgSrp(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
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

				private ActionElementMap AqfVUbWwYJbjKCjMjHDaXGwCCEit(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return jAltUCUOSEvGxeynBxMxZeNNgSrp(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(CfKYskAqKbOLsLnwACkrEyIAATsU))]
				private IEnumerable<ActionElementMap> WDTIJEAHQeatOAToELfYscCCksOmc(ControllerType P_0, int P_1, bool P_2)
				{
					return new CfKYskAqKbOLsLnwACkrEyIAATsU(-2)
					{
						NNEaaUXQijjugMFrvXyFpNwrrKrg = this,
						nlliFjVwABwwlAzbrKqGRWFkCWEQ = P_0,
						aNoXSfLpqOdZhBOvHSKJxUofuYDRA = P_1,
						YeIkDvnLzqbvPmCjAfBqEFQiENTYA = P_2
					};
				}

				private IEnumerable<ActionElementMap> GhjCMeLsXVMlQdOWAdnsLIzntUCt(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return WDTIJEAHQeatOAToELfYscCCksOmc(P_0, num, P_2);
				}

				private ActionElementMap LvRFhAHLyahHouiPIhhLRpIKfQIh(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
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

				private ActionElementMap ZmzDOVgyMIeVjIkFJDaCECNxpBtaA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return LvRFhAHLyahHouiPIhhLRpIKfQIh(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(qceelYWiEIMAbJqefzURPLnHwwOI))]
				private IEnumerable<ActionElementMap> kAPCLDuhjEGPwRgVFpvAKeOAzCpo(ControllerType P_0, int P_1, bool P_2)
				{
					return new qceelYWiEIMAbJqefzURPLnHwwOI(-2)
					{
						oQBVNUmAUDarHJEzrCiqGdbrJEiEb = this,
						OcacxEeZnQyVRzTMksczZDioXCwv = P_0,
						rVSifACnHAdYSXzmNLoBUXbEvWjD = P_1,
						hnPgdsneTTNrmlToGqvSMBLNhexfA = P_2
					};
				}

				private IEnumerable<ActionElementMap> DjQwAnLGvHfyFbWBQyouqRRHQjeR(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return kAPCLDuhjEGPwRgVFpvAKeOAzCpo(P_0, num, P_2);
				}

				private int QowbrmosiJdcCfPoxtfnBHARlCBW(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num2; j++)
						{
							yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							int num3 = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.hGHOjSLPgnLbpeTHVWqYczIgnyiC(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int UYRnhvUTsUgJzwedIGsUbUHzKFxj(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num2; j++)
						{
							yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							int num3 = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							for (int k = 0; k < num3; k++)
							{
								if (yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.SnLrFGpHIpHUKIDNyEbgJPJFWWZpA(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int HxNHaBHGZHthmHZvrVTmDJCLYgYk(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int zKrhkjardydsdIOgpYiwrSsGSvBf = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
					for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
					{
						kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i);
						int num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
						for (int j = 0; j < num2; j++)
						{
							yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(j).LYmUAmbCzgGoTbembTlgBdvFhNexA;
							int num3 = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.NsDAUTdPDDxqNrCesiwnZQUpFRfaA(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int xvtFjobFQwUVYoVInmTjCSiGkSCBA(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].hGHOjSLPgnLbpeTHVWqYczIgnyiC(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int NviIodhNYtgbySDBldoeCuUmiHLaA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return xvtFjobFQwUVYoVInmTjCSiGkSCBA(P_0, num, P_2, P_3, P_4);
				}

				private int VeVnMmSZnxlnpsrWSeEiBnunpOdL(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).SnLrFGpHIpHUKIDNyEbgJPJFWWZpA(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int HNtLkTMZPSAnJqfbBcKmSqbyaUiq(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return VeVnMmSZnxlnpsrWSeEiBnunpOdL(P_0, num, P_2, P_3, P_4);
				}

				private int BcihHLhJkwbTeQuXjYTiIpFCSkAeb(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					for (int i = 0; i < kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv; i++)
					{
						IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].NsDAUTdPDDxqNrCesiwnZQUpFRfaA(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int XxUYGyaZiIqrvFGkGZnMwdqeazqw(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_1);
					return BcihHLhJkwbTeQuXjYTiIpFCSkAeb(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap HEuRlKmjRDCayaUxtbKzvRPhpFFzA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
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

				private ActionElementMap HAkKgDVkQjVEKQLcUFShfWOYTUcP(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return HEuRlKmjRDCayaUxtbKzvRPhpFFzA(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(ckhdDFxLBZBdGQAnbXbhvFDjFvHU))]
				private IEnumerable<ActionElementMap> ueMqMTPiDcrjJeiMqngxTQBIUsWd(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new ckhdDFxLBZBdGQAnbXbhvFDjFvHU(-2)
					{
						npOGLTlFwZFDCgnWRykqIYdShKmR = this,
						cHLmvmCAVkUCfJJDxsSzymqmiRFD = P_0,
						thVyiQSDsInltKyxfoRiufZWsmBs = P_1,
						QtMHJnueBKvrTHCSsBFBGPynGOXQA = P_2,
						sIEeIEDYuDkcJlhdLXsHIOzsfQwEA = P_3
					};
				}

				private IEnumerable<ActionElementMap> NpOyTsVMyaiHcHQbuEqOBVjGtqfv(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return ueMqMTPiDcrjJeiMqngxTQBIUsWd(P_0, P_1, num, P_3);
				}

				private ActionElementMap pVunLaqTOJQtqEVrOilVReCIOndO(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
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

				private ActionElementMap fCuGheyEmsDNqJgJsSTRbxCrRpEGA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return pVunLaqTOJQtqEVrOilVReCIOndO(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(KExSwRuqNmpfTDSDVUKtxJrcdIudA))]
				private IEnumerable<ActionElementMap> mjGwHMxQEhEgIiHKaQXLiyFXTsmX(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new KExSwRuqNmpfTDSDVUKtxJrcdIudA(-2)
					{
						tkIsicupnJPokKjTygJvkiiAEgRAb = this,
						DNAyoDTDZpyXHrDfQAyELscJcsJb = P_0,
						gXsNGgpldwKaoWfAJASjpZpiAdIq = P_1,
						MuQMpUyXHeRJzZgKLihqgmgCILNl = P_2,
						FmuRwKobcfFluBqCXUnqShaEXIlCA = P_3
					};
				}

				private IEnumerable<ActionElementMap> mxcXUydtqykIzfQFKErGBLDNNYrdb(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return mjGwHMxQEhEgIiHKaQXLiyFXTsmX(P_0, P_1, num, P_3);
				}

				private ActionElementMap ZOlewByjFwaMseCxOdUQOmPWTlwGA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
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

				private ActionElementMap dCmllIAmbNeciHGwunFhJrxleXUhA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return ZOlewByjFwaMseCxOdUQOmPWTlwGA(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(LghjOSLgFPVCWGSqtwblsKKVwfgs))]
				private IEnumerable<ActionElementMap> aBMWFwMKpcaFvoDvWqYeSIhUURJf(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new LghjOSLgFPVCWGSqtwblsKKVwfgs(-2)
					{
						uDCLDUVesPaQxEnqlfeZZdGMQHks = this,
						UiVrJaTrXXvFnQpRXMaKEJRuETSL = P_0,
						pMGGznbrdnECIyCahrgSESpJQztWb = P_1,
						EPqdWnCSSXubAyGfEdXmJlAuXFfd = P_2,
						nGunzvCxuHpmGmLJbetDZoqrfjWaA = P_3
					};
				}

				private IEnumerable<ActionElementMap> fgEZsXcHiCoFKbaXLyGKbkJkYMpK(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return aBMWFwMKpcaFvoDvWqYeSIhUURJf(P_0, P_1, num, P_3);
				}

				private int SfYaWBhtWhKGAUlKBQDrYiyCYjqS(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.hGHOjSLPgnLbpeTHVWqYczIgnyiC(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int RCknviFcgQenwnqiRTKLTAzdrdGO(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return SfYaWBhtWhKGAUlKBQDrYiyCYjqS(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int sLquldHonAsgsXswoojllgxVqsLd(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.SnLrFGpHIpHUKIDNyEbgJPJFWWZpA(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int kwJhoWwmqTEQgUqyXsEPNzGHVXIk(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return sLquldHonAsgsXswoojllgxVqsLd(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int mbeeQFEAxYYBKukXUigcsbwpkOZz(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.eoyYPrzBBUZZQhpjyHILTteiVtU(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).LYmUAmbCzgGoTbembTlgBdvFhNexA.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].NsDAUTdPDDxqNrCesiwnZQUpFRfaA(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int qgKrkQamFjxgTeqiSlkIxcrxuiZA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
					return mbeeQFEAxYYBKukXUigcsbwpkOZz(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap HTEbKPKNLuEhSZdbwqXTEGoeXgWY(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controller.type);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					for (int i = 0; i < num; i++)
					{
						yiZTVAYmYqfnMStnvrnpZDWxfexCA obj = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA;
						_ = obj.dOLVGySRSIHymrnVvPaFOKsKLzWn;
						IList<ControllerMap> list = obj.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.KxrsILBDQpdqcePUNUZVkTrjmufQA(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				[IteratorStateMachine(typeof(GSjwVNoOChJQfnZZKHKdgjLZzaV))]
				private IEnumerable<ActionElementMap> uRdbMgOouMxAXMmmjaZfIRkjCgeJ(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new GSjwVNoOChJQfnZZKHKdgjLZzaV(-2)
					{
						NSOkblvOoUovcPuptsAZGLkUKQFy = this,
						CdZdVOFRdmnOwubfevMcsurErpbc = P_0,
						QCFjOYCOBdoFUnvffGniSUbaENkKA = P_1,
						sbOVkgkxLeEYRpSDzUgqUMTILCUK = P_2,
						gZUSWTGirSaZSOrScAvwDzrqohje = P_3
					};
				}

				private int rIyfOTNnfvBxjHExitgDmpOPrEODA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = NrkDisCXbVyNVgpcypOhEhgkNVtkb.pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controller.type);
					int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						yiZTVAYmYqfnMStnvrnpZDWxfexCA obj = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).LYmUAmbCzgGoTbembTlgBdvFhNexA;
						_ = obj.dOLVGySRSIHymrnVvPaFOKsKLzWn;
						IList<ControllerMap> list = obj.ZJzTGetGXOZfQRcUBkGoPKceTlVg;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.rBPavCiiyAlojGkIqSyYebDCbwCgA(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
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
				private sealed class RJpCgVnTBJeMaBniiIVSWrJqAzJX : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int MHnknCsWoYJIHUpcaFLPOvVolQGv;

					private ControllerPollingInfo aFMFbTRewSfayFoKvIEWcaIbxoWDB;

					private int gGcDKesZyWrmBHRMjbBsMMNpIQKs;

					public PollingHelper tWCBmQEvPCVkkckjuZZgOaHmLbIdA;

					private IList<CustomController> VROERyEGBrxzHeWREMFfjcVlavDS;

					private int lnbwdDsqLvMvTNHSAbPomZGuIwPt;

					private int INfnDkxwFAMvhYXeMgwxpGZlwSRA;

					private IEnumerator<ControllerPollingInfo> qBYHQLgcgdLKZGKreNPjZndOtQotA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aFMFbTRewSfayFoKvIEWcaIbxoWDB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aFMFbTRewSfayFoKvIEWcaIbxoWDB;
						}
					}

					[DebuggerHidden]
					public RJpCgVnTBJeMaBniiIVSWrJqAzJX(int P_0)
					{
						MHnknCsWoYJIHUpcaFLPOvVolQGv = P_0;
						gGcDKesZyWrmBHRMjbBsMMNpIQKs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int mHnknCsWoYJIHUpcaFLPOvVolQGv = MHnknCsWoYJIHUpcaFLPOvVolQGv;
						if (mHnknCsWoYJIHUpcaFLPOvVolQGv == -3 || mHnknCsWoYJIHUpcaFLPOvVolQGv == 1)
						{
							try
							{
							}
							finally
							{
								VDahRXaHEnXmRmYYDrekfASxdFJfb();
							}
						}
						VROERyEGBrxzHeWREMFfjcVlavDS = null;
						qBYHQLgcgdLKZGKreNPjZndOtQotA = null;
						MHnknCsWoYJIHUpcaFLPOvVolQGv = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int mHnknCsWoYJIHUpcaFLPOvVolQGv = MHnknCsWoYJIHUpcaFLPOvVolQGv;
							PollingHelper pollingHelper = tWCBmQEvPCVkkckjuZZgOaHmLbIdA;
							if (mHnknCsWoYJIHUpcaFLPOvVolQGv != 0)
							{
								if (mHnknCsWoYJIHUpcaFLPOvVolQGv != 1)
								{
									return false;
								}
								MHnknCsWoYJIHUpcaFLPOvVolQGv = -3;
								goto IL_00c5;
							}
							MHnknCsWoYJIHUpcaFLPOvVolQGv = -1;
							VROERyEGBrxzHeWREMFfjcVlavDS = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
							lnbwdDsqLvMvTNHSAbPomZGuIwPt = VROERyEGBrxzHeWREMFfjcVlavDS.Count;
							INfnDkxwFAMvhYXeMgwxpGZlwSRA = 0;
							goto IL_00f1;
							IL_00c5:
							if (qBYHQLgcgdLKZGKreNPjZndOtQotA.MoveNext())
							{
								ControllerPollingInfo current = qBYHQLgcgdLKZGKreNPjZndOtQotA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								aFMFbTRewSfayFoKvIEWcaIbxoWDB = controllerPollingInfo;
								MHnknCsWoYJIHUpcaFLPOvVolQGv = 1;
								return true;
							}
							VDahRXaHEnXmRmYYDrekfASxdFJfb();
							qBYHQLgcgdLKZGKreNPjZndOtQotA = null;
							INfnDkxwFAMvhYXeMgwxpGZlwSRA++;
							goto IL_00f1;
							IL_00f1:
							if (INfnDkxwFAMvhYXeMgwxpGZlwSRA < lnbwdDsqLvMvTNHSAbPomZGuIwPt)
							{
								qBYHQLgcgdLKZGKreNPjZndOtQotA = VROERyEGBrxzHeWREMFfjcVlavDS[INfnDkxwFAMvhYXeMgwxpGZlwSRA].PollForAllAxes().GetEnumerator();
								MHnknCsWoYJIHUpcaFLPOvVolQGv = -3;
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

					private void VDahRXaHEnXmRmYYDrekfASxdFJfb()
					{
						MHnknCsWoYJIHUpcaFLPOvVolQGv = -1;
						if (qBYHQLgcgdLKZGKreNPjZndOtQotA != null)
						{
							qBYHQLgcgdLKZGKreNPjZndOtQotA.Dispose();
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
						RJpCgVnTBJeMaBniiIVSWrJqAzJX rJpCgVnTBJeMaBniiIVSWrJqAzJX;
						if (MHnknCsWoYJIHUpcaFLPOvVolQGv == -2 && gGcDKesZyWrmBHRMjbBsMMNpIQKs == Environment.CurrentManagedThreadId)
						{
							MHnknCsWoYJIHUpcaFLPOvVolQGv = 0;
							rJpCgVnTBJeMaBniiIVSWrJqAzJX = this;
						}
						else
						{
							rJpCgVnTBJeMaBniiIVSWrJqAzJX = new RJpCgVnTBJeMaBniiIVSWrJqAzJX(0);
							rJpCgVnTBJeMaBniiIVSWrJqAzJX.tWCBmQEvPCVkkckjuZZgOaHmLbIdA = tWCBmQEvPCVkkckjuZZgOaHmLbIdA;
						}
						return rJpCgVnTBJeMaBniiIVSWrJqAzJX;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class dmYtHKynNhTJCpSFxZwORgirGJFh : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int TacannUrsJfXfAEJQWOWkuiLmfYGA;

					private ControllerPollingInfo EVXfYncSkLsmEuhJehYRYQeNwnmPA;

					private int YYFaSyhcWpsfeFlCYNNoMtakCZLNA;

					public PollingHelper vtuyslUhfbWlUjClvXTfGaIXExVA;

					private IList<CustomController> JYmtbyXOokCLygPyWGrYMbqNOrBCb;

					private int dbFaSldrzfqloNOHVyHnozBcooIWA;

					private int LZUOfJUtcZjkeDKqIkQlaZrFQSUW;

					private IEnumerator<ControllerPollingInfo> oRiBHFbIiQmWwUCQDKayuvJmWJSWA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return EVXfYncSkLsmEuhJehYRYQeNwnmPA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return EVXfYncSkLsmEuhJehYRYQeNwnmPA;
						}
					}

					[DebuggerHidden]
					public dmYtHKynNhTJCpSFxZwORgirGJFh(int P_0)
					{
						TacannUrsJfXfAEJQWOWkuiLmfYGA = P_0;
						YYFaSyhcWpsfeFlCYNNoMtakCZLNA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int tacannUrsJfXfAEJQWOWkuiLmfYGA = TacannUrsJfXfAEJQWOWkuiLmfYGA;
						if (tacannUrsJfXfAEJQWOWkuiLmfYGA == -3 || tacannUrsJfXfAEJQWOWkuiLmfYGA == 1)
						{
							try
							{
							}
							finally
							{
								FQJnChforsGtAongsZDMQEQugoAU();
							}
						}
						JYmtbyXOokCLygPyWGrYMbqNOrBCb = null;
						oRiBHFbIiQmWwUCQDKayuvJmWJSWA = null;
						TacannUrsJfXfAEJQWOWkuiLmfYGA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int tacannUrsJfXfAEJQWOWkuiLmfYGA = TacannUrsJfXfAEJQWOWkuiLmfYGA;
							PollingHelper pollingHelper = vtuyslUhfbWlUjClvXTfGaIXExVA;
							if (tacannUrsJfXfAEJQWOWkuiLmfYGA != 0)
							{
								if (tacannUrsJfXfAEJQWOWkuiLmfYGA != 1)
								{
									return false;
								}
								TacannUrsJfXfAEJQWOWkuiLmfYGA = -3;
								goto IL_00c5;
							}
							TacannUrsJfXfAEJQWOWkuiLmfYGA = -1;
							JYmtbyXOokCLygPyWGrYMbqNOrBCb = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
							dbFaSldrzfqloNOHVyHnozBcooIWA = JYmtbyXOokCLygPyWGrYMbqNOrBCb.Count;
							LZUOfJUtcZjkeDKqIkQlaZrFQSUW = 0;
							goto IL_00f1;
							IL_00c5:
							if (oRiBHFbIiQmWwUCQDKayuvJmWJSWA.MoveNext())
							{
								ControllerPollingInfo current = oRiBHFbIiQmWwUCQDKayuvJmWJSWA.Current;
								ControllerPollingInfo eVXfYncSkLsmEuhJehYRYQeNwnmPA = new ControllerPollingInfo(current);
								eVXfYncSkLsmEuhJehYRYQeNwnmPA.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								EVXfYncSkLsmEuhJehYRYQeNwnmPA = eVXfYncSkLsmEuhJehYRYQeNwnmPA;
								TacannUrsJfXfAEJQWOWkuiLmfYGA = 1;
								return true;
							}
							FQJnChforsGtAongsZDMQEQugoAU();
							oRiBHFbIiQmWwUCQDKayuvJmWJSWA = null;
							LZUOfJUtcZjkeDKqIkQlaZrFQSUW++;
							goto IL_00f1;
							IL_00f1:
							if (LZUOfJUtcZjkeDKqIkQlaZrFQSUW < dbFaSldrzfqloNOHVyHnozBcooIWA)
							{
								oRiBHFbIiQmWwUCQDKayuvJmWJSWA = JYmtbyXOokCLygPyWGrYMbqNOrBCb[LZUOfJUtcZjkeDKqIkQlaZrFQSUW].PollForAllButtons().GetEnumerator();
								TacannUrsJfXfAEJQWOWkuiLmfYGA = -3;
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

					private void FQJnChforsGtAongsZDMQEQugoAU()
					{
						TacannUrsJfXfAEJQWOWkuiLmfYGA = -1;
						if (oRiBHFbIiQmWwUCQDKayuvJmWJSWA != null)
						{
							oRiBHFbIiQmWwUCQDKayuvJmWJSWA.Dispose();
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
						dmYtHKynNhTJCpSFxZwORgirGJFh dmYtHKynNhTJCpSFxZwORgirGJFh2;
						if (TacannUrsJfXfAEJQWOWkuiLmfYGA == -2 && YYFaSyhcWpsfeFlCYNNoMtakCZLNA == Environment.CurrentManagedThreadId)
						{
							TacannUrsJfXfAEJQWOWkuiLmfYGA = 0;
							dmYtHKynNhTJCpSFxZwORgirGJFh2 = this;
						}
						else
						{
							dmYtHKynNhTJCpSFxZwORgirGJFh2 = new dmYtHKynNhTJCpSFxZwORgirGJFh(0);
							dmYtHKynNhTJCpSFxZwORgirGJFh2.vtuyslUhfbWlUjClvXTfGaIXExVA = vtuyslUhfbWlUjClvXTfGaIXExVA;
						}
						return dmYtHKynNhTJCpSFxZwORgirGJFh2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class oPolvuFqxeyDhFruyTouAxCaPaUW : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zjzGSKeDKmRZwbSIeYZSokKNwFjh;

					private ControllerPollingInfo qXpdLjJgZPtrWUaEkeIaYOZOvrIdA;

					private int urFLktfbCZLsJoKOEXtMGhQwjHIu;

					public PollingHelper kjwOJdDRyqighYWsMjFAIOnDRhRb;

					private IList<CustomController> RMLknQlGNLzvVqRKUbRWQtfTBrVO;

					private int bJUauutrcqMUJpmnpqfCktEzKGhW;

					private int DvqLrdYGGMSnWvqzUWfITRUKImYn;

					private IEnumerator<ControllerPollingInfo> yZWpNiDZSZuOLvVPSdtJNBrUXraK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qXpdLjJgZPtrWUaEkeIaYOZOvrIdA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qXpdLjJgZPtrWUaEkeIaYOZOvrIdA;
						}
					}

					[DebuggerHidden]
					public oPolvuFqxeyDhFruyTouAxCaPaUW(int P_0)
					{
						zjzGSKeDKmRZwbSIeYZSokKNwFjh = P_0;
						urFLktfbCZLsJoKOEXtMGhQwjHIu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zjzGSKeDKmRZwbSIeYZSokKNwFjh;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								nLNjllQTDbkijtoEIVnguBGGtbsH();
							}
						}
						RMLknQlGNLzvVqRKUbRWQtfTBrVO = null;
						yZWpNiDZSZuOLvVPSdtJNBrUXraK = null;
						zjzGSKeDKmRZwbSIeYZSokKNwFjh = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = zjzGSKeDKmRZwbSIeYZSokKNwFjh;
							PollingHelper pollingHelper = kjwOJdDRyqighYWsMjFAIOnDRhRb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								zjzGSKeDKmRZwbSIeYZSokKNwFjh = -3;
								goto IL_00c5;
							}
							zjzGSKeDKmRZwbSIeYZSokKNwFjh = -1;
							RMLknQlGNLzvVqRKUbRWQtfTBrVO = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
							bJUauutrcqMUJpmnpqfCktEzKGhW = RMLknQlGNLzvVqRKUbRWQtfTBrVO.Count;
							DvqLrdYGGMSnWvqzUWfITRUKImYn = 0;
							goto IL_00f1;
							IL_00c5:
							if (yZWpNiDZSZuOLvVPSdtJNBrUXraK.MoveNext())
							{
								ControllerPollingInfo current = yZWpNiDZSZuOLvVPSdtJNBrUXraK.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								qXpdLjJgZPtrWUaEkeIaYOZOvrIdA = controllerPollingInfo;
								zjzGSKeDKmRZwbSIeYZSokKNwFjh = 1;
								return true;
							}
							nLNjllQTDbkijtoEIVnguBGGtbsH();
							yZWpNiDZSZuOLvVPSdtJNBrUXraK = null;
							DvqLrdYGGMSnWvqzUWfITRUKImYn++;
							goto IL_00f1;
							IL_00f1:
							if (DvqLrdYGGMSnWvqzUWfITRUKImYn < bJUauutrcqMUJpmnpqfCktEzKGhW)
							{
								yZWpNiDZSZuOLvVPSdtJNBrUXraK = RMLknQlGNLzvVqRKUbRWQtfTBrVO[DvqLrdYGGMSnWvqzUWfITRUKImYn].PollForAllButtonsDown().GetEnumerator();
								zjzGSKeDKmRZwbSIeYZSokKNwFjh = -3;
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

					private void nLNjllQTDbkijtoEIVnguBGGtbsH()
					{
						zjzGSKeDKmRZwbSIeYZSokKNwFjh = -1;
						if (yZWpNiDZSZuOLvVPSdtJNBrUXraK != null)
						{
							yZWpNiDZSZuOLvVPSdtJNBrUXraK.Dispose();
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
						oPolvuFqxeyDhFruyTouAxCaPaUW oPolvuFqxeyDhFruyTouAxCaPaUW2;
						if (zjzGSKeDKmRZwbSIeYZSokKNwFjh == -2 && urFLktfbCZLsJoKOEXtMGhQwjHIu == Environment.CurrentManagedThreadId)
						{
							zjzGSKeDKmRZwbSIeYZSokKNwFjh = 0;
							oPolvuFqxeyDhFruyTouAxCaPaUW2 = this;
						}
						else
						{
							oPolvuFqxeyDhFruyTouAxCaPaUW2 = new oPolvuFqxeyDhFruyTouAxCaPaUW(0);
							oPolvuFqxeyDhFruyTouAxCaPaUW2.kjwOJdDRyqighYWsMjFAIOnDRhRb = kjwOJdDRyqighYWsMjFAIOnDRhRb;
						}
						return oPolvuFqxeyDhFruyTouAxCaPaUW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DJSAHMPhIjrXcABTNlwnldbAmAxk : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EPnCXJhELknLzEVoSuyQUyicbmBY;

					private ControllerPollingInfo bpuNnwbWgDZoYekCuRgQvyHXDcxl;

					private int JsIjfjgMBXZPZyhCaikFbyNgbeem;

					public PollingHelper dnCbRRAtqmCXXzduczynCKLGEDkQ;

					private IList<CustomController> klSRYNcYNUkliwyccqfFaLLBDnpg;

					private int AqhGZJsYTcdPrvhtWaPSpsoXEHpGA;

					private int BorGoEzHZJtURpfQqYJClPGhWvUJ;

					private IEnumerator<ControllerPollingInfo> IuNFLXNOtMqcEHNYaycvxAGJZdnL;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return bpuNnwbWgDZoYekCuRgQvyHXDcxl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bpuNnwbWgDZoYekCuRgQvyHXDcxl;
						}
					}

					[DebuggerHidden]
					public DJSAHMPhIjrXcABTNlwnldbAmAxk(int P_0)
					{
						EPnCXJhELknLzEVoSuyQUyicbmBY = P_0;
						JsIjfjgMBXZPZyhCaikFbyNgbeem = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ePnCXJhELknLzEVoSuyQUyicbmBY = EPnCXJhELknLzEVoSuyQUyicbmBY;
						if (ePnCXJhELknLzEVoSuyQUyicbmBY == -3 || ePnCXJhELknLzEVoSuyQUyicbmBY == 1)
						{
							try
							{
							}
							finally
							{
								TQmhVPgmJDdGifzuiliCLcPBiuFeb();
							}
						}
						klSRYNcYNUkliwyccqfFaLLBDnpg = null;
						IuNFLXNOtMqcEHNYaycvxAGJZdnL = null;
						EPnCXJhELknLzEVoSuyQUyicbmBY = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ePnCXJhELknLzEVoSuyQUyicbmBY = EPnCXJhELknLzEVoSuyQUyicbmBY;
							PollingHelper pollingHelper = dnCbRRAtqmCXXzduczynCKLGEDkQ;
							if (ePnCXJhELknLzEVoSuyQUyicbmBY != 0)
							{
								if (ePnCXJhELknLzEVoSuyQUyicbmBY != 1)
								{
									return false;
								}
								EPnCXJhELknLzEVoSuyQUyicbmBY = -3;
								goto IL_00c5;
							}
							EPnCXJhELknLzEVoSuyQUyicbmBY = -1;
							klSRYNcYNUkliwyccqfFaLLBDnpg = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
							AqhGZJsYTcdPrvhtWaPSpsoXEHpGA = klSRYNcYNUkliwyccqfFaLLBDnpg.Count;
							BorGoEzHZJtURpfQqYJClPGhWvUJ = 0;
							goto IL_00f1;
							IL_00c5:
							if (IuNFLXNOtMqcEHNYaycvxAGJZdnL.MoveNext())
							{
								ControllerPollingInfo current = IuNFLXNOtMqcEHNYaycvxAGJZdnL.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								bpuNnwbWgDZoYekCuRgQvyHXDcxl = controllerPollingInfo;
								EPnCXJhELknLzEVoSuyQUyicbmBY = 1;
								return true;
							}
							TQmhVPgmJDdGifzuiliCLcPBiuFeb();
							IuNFLXNOtMqcEHNYaycvxAGJZdnL = null;
							BorGoEzHZJtURpfQqYJClPGhWvUJ++;
							goto IL_00f1;
							IL_00f1:
							if (BorGoEzHZJtURpfQqYJClPGhWvUJ < AqhGZJsYTcdPrvhtWaPSpsoXEHpGA)
							{
								IuNFLXNOtMqcEHNYaycvxAGJZdnL = klSRYNcYNUkliwyccqfFaLLBDnpg[BorGoEzHZJtURpfQqYJClPGhWvUJ].PollForAllElements().GetEnumerator();
								EPnCXJhELknLzEVoSuyQUyicbmBY = -3;
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

					private void TQmhVPgmJDdGifzuiliCLcPBiuFeb()
					{
						EPnCXJhELknLzEVoSuyQUyicbmBY = -1;
						if (IuNFLXNOtMqcEHNYaycvxAGJZdnL != null)
						{
							IuNFLXNOtMqcEHNYaycvxAGJZdnL.Dispose();
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
						DJSAHMPhIjrXcABTNlwnldbAmAxk dJSAHMPhIjrXcABTNlwnldbAmAxk;
						if (EPnCXJhELknLzEVoSuyQUyicbmBY == -2 && JsIjfjgMBXZPZyhCaikFbyNgbeem == Environment.CurrentManagedThreadId)
						{
							EPnCXJhELknLzEVoSuyQUyicbmBY = 0;
							dJSAHMPhIjrXcABTNlwnldbAmAxk = this;
						}
						else
						{
							dJSAHMPhIjrXcABTNlwnldbAmAxk = new DJSAHMPhIjrXcABTNlwnldbAmAxk(0);
							dJSAHMPhIjrXcABTNlwnldbAmAxk.dnCbRRAtqmCXXzduczynCKLGEDkQ = dnCbRRAtqmCXXzduczynCKLGEDkQ;
						}
						return dJSAHMPhIjrXcABTNlwnldbAmAxk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ShwrlKmpHfUgRiaKRFABYWCWtqCh : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GvpcTokLKuiMoIYhasUsfCeeBYdEA;

					private ControllerPollingInfo oIbckkLynGIjQNMzwJLqaFwdzBEB;

					private int JCxeJPIFjBNyjMrBBHwSEbrljqIV;

					public PollingHelper pMdmZxRuMscdTtTprZtfobEuEncl;

					private IList<CustomController> rIScwUVWmPbgVCeQYqbTLEYQnZuXA;

					private int BqJwOmWgYbvnQIhjQjlfggtykZyeA;

					private int qiWReDnWBptoFzltDhCDFBVPUbcE;

					private IEnumerator<ControllerPollingInfo> XtHqgebYIRXQSoABoTXaEzOqvpG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oIbckkLynGIjQNMzwJLqaFwdzBEB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oIbckkLynGIjQNMzwJLqaFwdzBEB;
						}
					}

					[DebuggerHidden]
					public ShwrlKmpHfUgRiaKRFABYWCWtqCh(int P_0)
					{
						GvpcTokLKuiMoIYhasUsfCeeBYdEA = P_0;
						JCxeJPIFjBNyjMrBBHwSEbrljqIV = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gvpcTokLKuiMoIYhasUsfCeeBYdEA = GvpcTokLKuiMoIYhasUsfCeeBYdEA;
						if (gvpcTokLKuiMoIYhasUsfCeeBYdEA == -3 || gvpcTokLKuiMoIYhasUsfCeeBYdEA == 1)
						{
							try
							{
							}
							finally
							{
								RQoNYMGRSHbMgDMfTsUxCBqezMbr();
							}
						}
						rIScwUVWmPbgVCeQYqbTLEYQnZuXA = null;
						XtHqgebYIRXQSoABoTXaEzOqvpG = null;
						GvpcTokLKuiMoIYhasUsfCeeBYdEA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int gvpcTokLKuiMoIYhasUsfCeeBYdEA = GvpcTokLKuiMoIYhasUsfCeeBYdEA;
							PollingHelper pollingHelper = pMdmZxRuMscdTtTprZtfobEuEncl;
							if (gvpcTokLKuiMoIYhasUsfCeeBYdEA != 0)
							{
								if (gvpcTokLKuiMoIYhasUsfCeeBYdEA != 1)
								{
									return false;
								}
								GvpcTokLKuiMoIYhasUsfCeeBYdEA = -3;
								goto IL_00c5;
							}
							GvpcTokLKuiMoIYhasUsfCeeBYdEA = -1;
							rIScwUVWmPbgVCeQYqbTLEYQnZuXA = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
							BqJwOmWgYbvnQIhjQjlfggtykZyeA = rIScwUVWmPbgVCeQYqbTLEYQnZuXA.Count;
							qiWReDnWBptoFzltDhCDFBVPUbcE = 0;
							goto IL_00f1;
							IL_00c5:
							if (XtHqgebYIRXQSoABoTXaEzOqvpG.MoveNext())
							{
								ControllerPollingInfo current = XtHqgebYIRXQSoABoTXaEzOqvpG.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								oIbckkLynGIjQNMzwJLqaFwdzBEB = controllerPollingInfo;
								GvpcTokLKuiMoIYhasUsfCeeBYdEA = 1;
								return true;
							}
							RQoNYMGRSHbMgDMfTsUxCBqezMbr();
							XtHqgebYIRXQSoABoTXaEzOqvpG = null;
							qiWReDnWBptoFzltDhCDFBVPUbcE++;
							goto IL_00f1;
							IL_00f1:
							if (qiWReDnWBptoFzltDhCDFBVPUbcE < BqJwOmWgYbvnQIhjQjlfggtykZyeA)
							{
								XtHqgebYIRXQSoABoTXaEzOqvpG = rIScwUVWmPbgVCeQYqbTLEYQnZuXA[qiWReDnWBptoFzltDhCDFBVPUbcE].PollForAllElementsDown().GetEnumerator();
								GvpcTokLKuiMoIYhasUsfCeeBYdEA = -3;
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

					private void RQoNYMGRSHbMgDMfTsUxCBqezMbr()
					{
						GvpcTokLKuiMoIYhasUsfCeeBYdEA = -1;
						if (XtHqgebYIRXQSoABoTXaEzOqvpG != null)
						{
							XtHqgebYIRXQSoABoTXaEzOqvpG.Dispose();
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
						ShwrlKmpHfUgRiaKRFABYWCWtqCh shwrlKmpHfUgRiaKRFABYWCWtqCh;
						if (GvpcTokLKuiMoIYhasUsfCeeBYdEA == -2 && JCxeJPIFjBNyjMrBBHwSEbrljqIV == Environment.CurrentManagedThreadId)
						{
							GvpcTokLKuiMoIYhasUsfCeeBYdEA = 0;
							shwrlKmpHfUgRiaKRFABYWCWtqCh = this;
						}
						else
						{
							shwrlKmpHfUgRiaKRFABYWCWtqCh = new ShwrlKmpHfUgRiaKRFABYWCWtqCh(0);
							shwrlKmpHfUgRiaKRFABYWCWtqCh.pMdmZxRuMscdTtTprZtfobEuEncl = pMdmZxRuMscdTtTprZtfobEuEncl;
						}
						return shwrlKmpHfUgRiaKRFABYWCWtqCh;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class MyKdFPUfLiyFXqHEdibHlMNnzjvT : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YVFbBzDbdxzKpeGXWTGzdHqiHXJPA;

					private ControllerPollingInfo xARElHkrMOvTPOQYovKSavJxxIGU;

					private int lIyGgUHLgxnxnhweebSatkyfKMUJ;

					public PollingHelper zmPGxRRchpXXeNnDnwCvzpKGVuUH;

					private IList<Joystick> OwjpClHMVrjaABcrATmKOONOhQeeA;

					private int KKMqWOurlfdwEOBycmBeoigFrfmg;

					private int bmwuMkefsybjncIQJKmMGwTFlhEcb;

					private IEnumerator<ControllerPollingInfo> MFSHOtbIqZAjvbwtiSzfBqpCIRlJB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return xARElHkrMOvTPOQYovKSavJxxIGU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xARElHkrMOvTPOQYovKSavJxxIGU;
						}
					}

					[DebuggerHidden]
					public MyKdFPUfLiyFXqHEdibHlMNnzjvT(int P_0)
					{
						YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = P_0;
						lIyGgUHLgxnxnhweebSatkyfKMUJ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int yVFbBzDbdxzKpeGXWTGzdHqiHXJPA = YVFbBzDbdxzKpeGXWTGzdHqiHXJPA;
						if (yVFbBzDbdxzKpeGXWTGzdHqiHXJPA == -3 || yVFbBzDbdxzKpeGXWTGzdHqiHXJPA == 1)
						{
							try
							{
							}
							finally
							{
								BZaBdaGSvnxRAiwqSXOPNRFBeIzaA();
							}
						}
						OwjpClHMVrjaABcrATmKOONOhQeeA = null;
						MFSHOtbIqZAjvbwtiSzfBqpCIRlJB = null;
						YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int yVFbBzDbdxzKpeGXWTGzdHqiHXJPA = YVFbBzDbdxzKpeGXWTGzdHqiHXJPA;
							PollingHelper pollingHelper = zmPGxRRchpXXeNnDnwCvzpKGVuUH;
							if (yVFbBzDbdxzKpeGXWTGzdHqiHXJPA != 0)
							{
								if (yVFbBzDbdxzKpeGXWTGzdHqiHXJPA != 1)
								{
									return false;
								}
								YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = -3;
								goto IL_00c5;
							}
							YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = -1;
							OwjpClHMVrjaABcrATmKOONOhQeeA = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
							KKMqWOurlfdwEOBycmBeoigFrfmg = OwjpClHMVrjaABcrATmKOONOhQeeA.Count;
							bmwuMkefsybjncIQJKmMGwTFlhEcb = 0;
							goto IL_00f1;
							IL_00c5:
							if (MFSHOtbIqZAjvbwtiSzfBqpCIRlJB.MoveNext())
							{
								ControllerPollingInfo current = MFSHOtbIqZAjvbwtiSzfBqpCIRlJB.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								xARElHkrMOvTPOQYovKSavJxxIGU = controllerPollingInfo;
								YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = 1;
								return true;
							}
							BZaBdaGSvnxRAiwqSXOPNRFBeIzaA();
							MFSHOtbIqZAjvbwtiSzfBqpCIRlJB = null;
							bmwuMkefsybjncIQJKmMGwTFlhEcb++;
							goto IL_00f1;
							IL_00f1:
							if (bmwuMkefsybjncIQJKmMGwTFlhEcb < KKMqWOurlfdwEOBycmBeoigFrfmg)
							{
								MFSHOtbIqZAjvbwtiSzfBqpCIRlJB = OwjpClHMVrjaABcrATmKOONOhQeeA[bmwuMkefsybjncIQJKmMGwTFlhEcb].PollForAllAxes().GetEnumerator();
								YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = -3;
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

					private void BZaBdaGSvnxRAiwqSXOPNRFBeIzaA()
					{
						YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = -1;
						if (MFSHOtbIqZAjvbwtiSzfBqpCIRlJB != null)
						{
							MFSHOtbIqZAjvbwtiSzfBqpCIRlJB.Dispose();
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
						MyKdFPUfLiyFXqHEdibHlMNnzjvT myKdFPUfLiyFXqHEdibHlMNnzjvT;
						if (YVFbBzDbdxzKpeGXWTGzdHqiHXJPA == -2 && lIyGgUHLgxnxnhweebSatkyfKMUJ == Environment.CurrentManagedThreadId)
						{
							YVFbBzDbdxzKpeGXWTGzdHqiHXJPA = 0;
							myKdFPUfLiyFXqHEdibHlMNnzjvT = this;
						}
						else
						{
							myKdFPUfLiyFXqHEdibHlMNnzjvT = new MyKdFPUfLiyFXqHEdibHlMNnzjvT(0);
							myKdFPUfLiyFXqHEdibHlMNnzjvT.zmPGxRRchpXXeNnDnwCvzpKGVuUH = zmPGxRRchpXXeNnDnwCvzpKGVuUH;
						}
						return myKdFPUfLiyFXqHEdibHlMNnzjvT;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ebcAjvmTnZfDdiIczDDzhNggwSWi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mKkHxxZzzJltgCkHbAoYarLsmSUOA;

					private ControllerPollingInfo vsdPsoZEonaURCKmMJpUibwzYKrQ;

					private int uaQiQYDrgKzdYgEBwFqoNFNvXjPOA;

					public PollingHelper FJfKkLhVksvKIDGVgsyotpQMhPdM;

					private IList<Joystick> LnsUttiqeOXKmvhyQXzSBdZsqsJk;

					private int iXyCnygunEMpProTJixQuHnCYHXF;

					private int aobdJNzRDqvEaCNHlmvEPUAeOboR;

					private IEnumerator<ControllerPollingInfo> ojphkDxbXuzmOJmYCjpRXFqAMpq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vsdPsoZEonaURCKmMJpUibwzYKrQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vsdPsoZEonaURCKmMJpUibwzYKrQ;
						}
					}

					[DebuggerHidden]
					public ebcAjvmTnZfDdiIczDDzhNggwSWi(int P_0)
					{
						mKkHxxZzzJltgCkHbAoYarLsmSUOA = P_0;
						uaQiQYDrgKzdYgEBwFqoNFNvXjPOA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mKkHxxZzzJltgCkHbAoYarLsmSUOA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								VzMacSueenFDPDFsmXGhmXDaZzEv();
							}
						}
						LnsUttiqeOXKmvhyQXzSBdZsqsJk = null;
						ojphkDxbXuzmOJmYCjpRXFqAMpq = null;
						mKkHxxZzzJltgCkHbAoYarLsmSUOA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = mKkHxxZzzJltgCkHbAoYarLsmSUOA;
							PollingHelper fJfKkLhVksvKIDGVgsyotpQMhPdM = FJfKkLhVksvKIDGVgsyotpQMhPdM;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mKkHxxZzzJltgCkHbAoYarLsmSUOA = -3;
								goto IL_00c5;
							}
							mKkHxxZzzJltgCkHbAoYarLsmSUOA = -1;
							LnsUttiqeOXKmvhyQXzSBdZsqsJk = fJfKkLhVksvKIDGVgsyotpQMhPdM.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
							iXyCnygunEMpProTJixQuHnCYHXF = LnsUttiqeOXKmvhyQXzSBdZsqsJk.Count;
							aobdJNzRDqvEaCNHlmvEPUAeOboR = 0;
							goto IL_00f1;
							IL_00c5:
							if (ojphkDxbXuzmOJmYCjpRXFqAMpq.MoveNext())
							{
								ControllerPollingInfo current = ojphkDxbXuzmOJmYCjpRXFqAMpq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = fJfKkLhVksvKIDGVgsyotpQMhPdM.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								vsdPsoZEonaURCKmMJpUibwzYKrQ = controllerPollingInfo;
								mKkHxxZzzJltgCkHbAoYarLsmSUOA = 1;
								return true;
							}
							VzMacSueenFDPDFsmXGhmXDaZzEv();
							ojphkDxbXuzmOJmYCjpRXFqAMpq = null;
							aobdJNzRDqvEaCNHlmvEPUAeOboR++;
							goto IL_00f1;
							IL_00f1:
							if (aobdJNzRDqvEaCNHlmvEPUAeOboR < iXyCnygunEMpProTJixQuHnCYHXF)
							{
								ojphkDxbXuzmOJmYCjpRXFqAMpq = LnsUttiqeOXKmvhyQXzSBdZsqsJk[aobdJNzRDqvEaCNHlmvEPUAeOboR].PollForAllButtons().GetEnumerator();
								mKkHxxZzzJltgCkHbAoYarLsmSUOA = -3;
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

					private void VzMacSueenFDPDFsmXGhmXDaZzEv()
					{
						mKkHxxZzzJltgCkHbAoYarLsmSUOA = -1;
						if (ojphkDxbXuzmOJmYCjpRXFqAMpq != null)
						{
							ojphkDxbXuzmOJmYCjpRXFqAMpq.Dispose();
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
						ebcAjvmTnZfDdiIczDDzhNggwSWi ebcAjvmTnZfDdiIczDDzhNggwSWi2;
						if (mKkHxxZzzJltgCkHbAoYarLsmSUOA == -2 && uaQiQYDrgKzdYgEBwFqoNFNvXjPOA == Environment.CurrentManagedThreadId)
						{
							mKkHxxZzzJltgCkHbAoYarLsmSUOA = 0;
							ebcAjvmTnZfDdiIczDDzhNggwSWi2 = this;
						}
						else
						{
							ebcAjvmTnZfDdiIczDDzhNggwSWi2 = new ebcAjvmTnZfDdiIczDDzhNggwSWi(0);
							ebcAjvmTnZfDdiIczDDzhNggwSWi2.FJfKkLhVksvKIDGVgsyotpQMhPdM = FJfKkLhVksvKIDGVgsyotpQMhPdM;
						}
						return ebcAjvmTnZfDdiIczDDzhNggwSWi2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class XguQJjvOcWtIMGhjIDRQbKcWcnLAA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pXLWcXwKXMdHmzlXrCHtKmBjXhbK;

					private ControllerPollingInfo WBiqIKfFHHKqFRngteAjxLQDwTaj;

					private int ROPyIJovRdxaPxgptIHVcaZekZmRA;

					public PollingHelper HkvikqwixRfQjPLuJMHKUhjyxaOc;

					private IList<Joystick> xOBqUjGoHsYbgqxQBzfxegmfeZWK;

					private int sdzezLBahXhdeEbuhVxeSHnmQpawb;

					private int LXJWXCNribAItvuDUINfpAdbWYWT;

					private IEnumerator<ControllerPollingInfo> iJrcuBVDUnkEgUlrjXOOyaiCBTEU;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WBiqIKfFHHKqFRngteAjxLQDwTaj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WBiqIKfFHHKqFRngteAjxLQDwTaj;
						}
					}

					[DebuggerHidden]
					public XguQJjvOcWtIMGhjIDRQbKcWcnLAA(int P_0)
					{
						pXLWcXwKXMdHmzlXrCHtKmBjXhbK = P_0;
						ROPyIJovRdxaPxgptIHVcaZekZmRA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pXLWcXwKXMdHmzlXrCHtKmBjXhbK;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								tCxTRuXxpdmGUJDeJWeqmTIPOIR();
							}
						}
						xOBqUjGoHsYbgqxQBzfxegmfeZWK = null;
						iJrcuBVDUnkEgUlrjXOOyaiCBTEU = null;
						pXLWcXwKXMdHmzlXrCHtKmBjXhbK = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pXLWcXwKXMdHmzlXrCHtKmBjXhbK;
							PollingHelper hkvikqwixRfQjPLuJMHKUhjyxaOc = HkvikqwixRfQjPLuJMHKUhjyxaOc;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pXLWcXwKXMdHmzlXrCHtKmBjXhbK = -3;
								goto IL_00c5;
							}
							pXLWcXwKXMdHmzlXrCHtKmBjXhbK = -1;
							xOBqUjGoHsYbgqxQBzfxegmfeZWK = hkvikqwixRfQjPLuJMHKUhjyxaOc.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
							sdzezLBahXhdeEbuhVxeSHnmQpawb = xOBqUjGoHsYbgqxQBzfxegmfeZWK.Count;
							LXJWXCNribAItvuDUINfpAdbWYWT = 0;
							goto IL_00f1;
							IL_00c5:
							if (iJrcuBVDUnkEgUlrjXOOyaiCBTEU.MoveNext())
							{
								ControllerPollingInfo current = iJrcuBVDUnkEgUlrjXOOyaiCBTEU.Current;
								ControllerPollingInfo wBiqIKfFHHKqFRngteAjxLQDwTaj = new ControllerPollingInfo(current);
								wBiqIKfFHHKqFRngteAjxLQDwTaj.playerId = hkvikqwixRfQjPLuJMHKUhjyxaOc.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								WBiqIKfFHHKqFRngteAjxLQDwTaj = wBiqIKfFHHKqFRngteAjxLQDwTaj;
								pXLWcXwKXMdHmzlXrCHtKmBjXhbK = 1;
								return true;
							}
							tCxTRuXxpdmGUJDeJWeqmTIPOIR();
							iJrcuBVDUnkEgUlrjXOOyaiCBTEU = null;
							LXJWXCNribAItvuDUINfpAdbWYWT++;
							goto IL_00f1;
							IL_00f1:
							if (LXJWXCNribAItvuDUINfpAdbWYWT < sdzezLBahXhdeEbuhVxeSHnmQpawb)
							{
								iJrcuBVDUnkEgUlrjXOOyaiCBTEU = xOBqUjGoHsYbgqxQBzfxegmfeZWK[LXJWXCNribAItvuDUINfpAdbWYWT].PollForAllButtonsDown().GetEnumerator();
								pXLWcXwKXMdHmzlXrCHtKmBjXhbK = -3;
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

					private void tCxTRuXxpdmGUJDeJWeqmTIPOIR()
					{
						pXLWcXwKXMdHmzlXrCHtKmBjXhbK = -1;
						if (iJrcuBVDUnkEgUlrjXOOyaiCBTEU != null)
						{
							iJrcuBVDUnkEgUlrjXOOyaiCBTEU.Dispose();
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
						XguQJjvOcWtIMGhjIDRQbKcWcnLAA xguQJjvOcWtIMGhjIDRQbKcWcnLAA;
						if (pXLWcXwKXMdHmzlXrCHtKmBjXhbK == -2 && ROPyIJovRdxaPxgptIHVcaZekZmRA == Environment.CurrentManagedThreadId)
						{
							pXLWcXwKXMdHmzlXrCHtKmBjXhbK = 0;
							xguQJjvOcWtIMGhjIDRQbKcWcnLAA = this;
						}
						else
						{
							xguQJjvOcWtIMGhjIDRQbKcWcnLAA = new XguQJjvOcWtIMGhjIDRQbKcWcnLAA(0);
							xguQJjvOcWtIMGhjIDRQbKcWcnLAA.HkvikqwixRfQjPLuJMHKUhjyxaOc = HkvikqwixRfQjPLuJMHKUhjyxaOc;
						}
						return xguQJjvOcWtIMGhjIDRQbKcWcnLAA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lxrpwxNdCNDXGfPmwyjUKcQtOwmQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int cIVMeDKgnhQiPxObJfgJAFncWueIA;

					private ControllerPollingInfo zpYYTLiSRXiuVUnhMjqalradwAbr;

					private int ksXTyYfcVEBRvdjQFcQKeOhptXoi;

					public PollingHelper zmVqQfLXncbpxZQIOyRhyYMfHjKI;

					private IList<Joystick> yrhazgRSXIJcRsnLRgmkCaBcaQyfA;

					private int EzmHjDOcPnvvoJuMGFVfToOdWwDv;

					private int THJfhecSHlgbTDolbzWNkmYIaRWuA;

					private IEnumerator<ControllerPollingInfo> PDFhQNKvJPqxokjPBOyKeiyvOzQab;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zpYYTLiSRXiuVUnhMjqalradwAbr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zpYYTLiSRXiuVUnhMjqalradwAbr;
						}
					}

					[DebuggerHidden]
					public lxrpwxNdCNDXGfPmwyjUKcQtOwmQ(int P_0)
					{
						cIVMeDKgnhQiPxObJfgJAFncWueIA = P_0;
						ksXTyYfcVEBRvdjQFcQKeOhptXoi = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cIVMeDKgnhQiPxObJfgJAFncWueIA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								eGvgKEWqjgCOWqlxrgxcBcVqHoJJA();
							}
						}
						yrhazgRSXIJcRsnLRgmkCaBcaQyfA = null;
						PDFhQNKvJPqxokjPBOyKeiyvOzQab = null;
						cIVMeDKgnhQiPxObJfgJAFncWueIA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = cIVMeDKgnhQiPxObJfgJAFncWueIA;
							PollingHelper pollingHelper = zmVqQfLXncbpxZQIOyRhyYMfHjKI;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cIVMeDKgnhQiPxObJfgJAFncWueIA = -3;
								goto IL_00c5;
							}
							cIVMeDKgnhQiPxObJfgJAFncWueIA = -1;
							yrhazgRSXIJcRsnLRgmkCaBcaQyfA = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
							EzmHjDOcPnvvoJuMGFVfToOdWwDv = yrhazgRSXIJcRsnLRgmkCaBcaQyfA.Count;
							THJfhecSHlgbTDolbzWNkmYIaRWuA = 0;
							goto IL_00f1;
							IL_00c5:
							if (PDFhQNKvJPqxokjPBOyKeiyvOzQab.MoveNext())
							{
								ControllerPollingInfo current = PDFhQNKvJPqxokjPBOyKeiyvOzQab.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								zpYYTLiSRXiuVUnhMjqalradwAbr = controllerPollingInfo;
								cIVMeDKgnhQiPxObJfgJAFncWueIA = 1;
								return true;
							}
							eGvgKEWqjgCOWqlxrgxcBcVqHoJJA();
							PDFhQNKvJPqxokjPBOyKeiyvOzQab = null;
							THJfhecSHlgbTDolbzWNkmYIaRWuA++;
							goto IL_00f1;
							IL_00f1:
							if (THJfhecSHlgbTDolbzWNkmYIaRWuA < EzmHjDOcPnvvoJuMGFVfToOdWwDv)
							{
								PDFhQNKvJPqxokjPBOyKeiyvOzQab = yrhazgRSXIJcRsnLRgmkCaBcaQyfA[THJfhecSHlgbTDolbzWNkmYIaRWuA].PollForAllElements().GetEnumerator();
								cIVMeDKgnhQiPxObJfgJAFncWueIA = -3;
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

					private void eGvgKEWqjgCOWqlxrgxcBcVqHoJJA()
					{
						cIVMeDKgnhQiPxObJfgJAFncWueIA = -1;
						if (PDFhQNKvJPqxokjPBOyKeiyvOzQab != null)
						{
							PDFhQNKvJPqxokjPBOyKeiyvOzQab.Dispose();
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
						lxrpwxNdCNDXGfPmwyjUKcQtOwmQ lxrpwxNdCNDXGfPmwyjUKcQtOwmQ2;
						if (cIVMeDKgnhQiPxObJfgJAFncWueIA == -2 && ksXTyYfcVEBRvdjQFcQKeOhptXoi == Environment.CurrentManagedThreadId)
						{
							cIVMeDKgnhQiPxObJfgJAFncWueIA = 0;
							lxrpwxNdCNDXGfPmwyjUKcQtOwmQ2 = this;
						}
						else
						{
							lxrpwxNdCNDXGfPmwyjUKcQtOwmQ2 = new lxrpwxNdCNDXGfPmwyjUKcQtOwmQ(0);
							lxrpwxNdCNDXGfPmwyjUKcQtOwmQ2.zmVqQfLXncbpxZQIOyRhyYMfHjKI = zmVqQfLXncbpxZQIOyRhyYMfHjKI;
						}
						return lxrpwxNdCNDXGfPmwyjUKcQtOwmQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class TZRDxJSvfmtSXWaxHtBLQVNONHmw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GfZYmeQbNTFmusLeXdCJAUkFjiELA;

					private ControllerPollingInfo oOcprfBGxFGJbQlIVaLJEOylbhOx;

					private int jAiGcQDgQYvTkVsYziQwUwivpPii;

					public PollingHelper XuvDyWSsubeHtxrPWmxcIsTYEUHS;

					private IList<Joystick> TjciXwlyEYHjiOLAOhsbDXKRGhgQA;

					private int eHzjkCuCXHFxgxokZxNLyHYfeECL;

					private int nzIaXGacFzMzMYQcFmjTTDpdEpix;

					private IEnumerator<ControllerPollingInfo> MGlYzVJqSCoBKbPXqpmMyjDCxkFw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oOcprfBGxFGJbQlIVaLJEOylbhOx;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oOcprfBGxFGJbQlIVaLJEOylbhOx;
						}
					}

					[DebuggerHidden]
					public TZRDxJSvfmtSXWaxHtBLQVNONHmw(int P_0)
					{
						GfZYmeQbNTFmusLeXdCJAUkFjiELA = P_0;
						jAiGcQDgQYvTkVsYziQwUwivpPii = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gfZYmeQbNTFmusLeXdCJAUkFjiELA = GfZYmeQbNTFmusLeXdCJAUkFjiELA;
						if (gfZYmeQbNTFmusLeXdCJAUkFjiELA == -3 || gfZYmeQbNTFmusLeXdCJAUkFjiELA == 1)
						{
							try
							{
							}
							finally
							{
								MkOdTneQVgilrjQfVVufeUZeFWdTB();
							}
						}
						TjciXwlyEYHjiOLAOhsbDXKRGhgQA = null;
						MGlYzVJqSCoBKbPXqpmMyjDCxkFw = null;
						GfZYmeQbNTFmusLeXdCJAUkFjiELA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int gfZYmeQbNTFmusLeXdCJAUkFjiELA = GfZYmeQbNTFmusLeXdCJAUkFjiELA;
							PollingHelper xuvDyWSsubeHtxrPWmxcIsTYEUHS = XuvDyWSsubeHtxrPWmxcIsTYEUHS;
							if (gfZYmeQbNTFmusLeXdCJAUkFjiELA != 0)
							{
								if (gfZYmeQbNTFmusLeXdCJAUkFjiELA != 1)
								{
									return false;
								}
								GfZYmeQbNTFmusLeXdCJAUkFjiELA = -3;
								goto IL_00c5;
							}
							GfZYmeQbNTFmusLeXdCJAUkFjiELA = -1;
							TjciXwlyEYHjiOLAOhsbDXKRGhgQA = xuvDyWSsubeHtxrPWmxcIsTYEUHS.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
							eHzjkCuCXHFxgxokZxNLyHYfeECL = TjciXwlyEYHjiOLAOhsbDXKRGhgQA.Count;
							nzIaXGacFzMzMYQcFmjTTDpdEpix = 0;
							goto IL_00f1;
							IL_00c5:
							if (MGlYzVJqSCoBKbPXqpmMyjDCxkFw.MoveNext())
							{
								ControllerPollingInfo current = MGlYzVJqSCoBKbPXqpmMyjDCxkFw.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = xuvDyWSsubeHtxrPWmxcIsTYEUHS.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								oOcprfBGxFGJbQlIVaLJEOylbhOx = controllerPollingInfo;
								GfZYmeQbNTFmusLeXdCJAUkFjiELA = 1;
								return true;
							}
							MkOdTneQVgilrjQfVVufeUZeFWdTB();
							MGlYzVJqSCoBKbPXqpmMyjDCxkFw = null;
							nzIaXGacFzMzMYQcFmjTTDpdEpix++;
							goto IL_00f1;
							IL_00f1:
							if (nzIaXGacFzMzMYQcFmjTTDpdEpix < eHzjkCuCXHFxgxokZxNLyHYfeECL)
							{
								MGlYzVJqSCoBKbPXqpmMyjDCxkFw = TjciXwlyEYHjiOLAOhsbDXKRGhgQA[nzIaXGacFzMzMYQcFmjTTDpdEpix].PollForAllElementsDown().GetEnumerator();
								GfZYmeQbNTFmusLeXdCJAUkFjiELA = -3;
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

					private void MkOdTneQVgilrjQfVVufeUZeFWdTB()
					{
						GfZYmeQbNTFmusLeXdCJAUkFjiELA = -1;
						if (MGlYzVJqSCoBKbPXqpmMyjDCxkFw != null)
						{
							MGlYzVJqSCoBKbPXqpmMyjDCxkFw.Dispose();
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
						TZRDxJSvfmtSXWaxHtBLQVNONHmw tZRDxJSvfmtSXWaxHtBLQVNONHmw;
						if (GfZYmeQbNTFmusLeXdCJAUkFjiELA == -2 && jAiGcQDgQYvTkVsYziQwUwivpPii == Environment.CurrentManagedThreadId)
						{
							GfZYmeQbNTFmusLeXdCJAUkFjiELA = 0;
							tZRDxJSvfmtSXWaxHtBLQVNONHmw = this;
						}
						else
						{
							tZRDxJSvfmtSXWaxHtBLQVNONHmw = new TZRDxJSvfmtSXWaxHtBLQVNONHmw(0);
							tZRDxJSvfmtSXWaxHtBLQVNONHmw.XuvDyWSsubeHtxrPWmxcIsTYEUHS = XuvDyWSsubeHtxrPWmxcIsTYEUHS;
						}
						return tZRDxJSvfmtSXWaxHtBLQVNONHmw;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class oYTHoBUVNSxiwjUIpvxYJNhwfXoI : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int SlQBrcfRGLhyhrfyJGNbdDJeZbmKA;

					private ControllerPollingInfo jzMaRCbtyzlkPboKfxHSQKmRjxBub;

					private int nIlxtnUtoqDXEZCzIdANZrvibRmG;

					private int CTmSwYhAqWajqwWmQiEynIyaVIXd;

					public int KyIZFVUluapIPbbQFLNnvpwHrQpq;

					public PollingHelper CbctvzMGqQHJRKgHFImcHTlYOccjb;

					private IEnumerator<ControllerPollingInfo> ewafQABQptfDAIIAhDITUbGjbcQT;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return jzMaRCbtyzlkPboKfxHSQKmRjxBub;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jzMaRCbtyzlkPboKfxHSQKmRjxBub;
						}
					}

					[DebuggerHidden]
					public oYTHoBUVNSxiwjUIpvxYJNhwfXoI(int P_0)
					{
						SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = P_0;
						nIlxtnUtoqDXEZCzIdANZrvibRmG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int slQBrcfRGLhyhrfyJGNbdDJeZbmKA = SlQBrcfRGLhyhrfyJGNbdDJeZbmKA;
						if (slQBrcfRGLhyhrfyJGNbdDJeZbmKA == -3 || slQBrcfRGLhyhrfyJGNbdDJeZbmKA == 1)
						{
							try
							{
							}
							finally
							{
								SKWbpMlQdYLKQEQHPOuaIoXsMCZu();
							}
						}
						ewafQABQptfDAIIAhDITUbGjbcQT = null;
						SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int slQBrcfRGLhyhrfyJGNbdDJeZbmKA = SlQBrcfRGLhyhrfyJGNbdDJeZbmKA;
							PollingHelper cbctvzMGqQHJRKgHFImcHTlYOccjb = CbctvzMGqQHJRKgHFImcHTlYOccjb;
							switch (slQBrcfRGLhyhrfyJGNbdDJeZbmKA)
							{
							default:
								return false;
							case 0:
							{
								SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = -1;
								if (CTmSwYhAqWajqwWmQiEynIyaVIXd < 0)
								{
									return false;
								}
								CustomController customController = cbctvzMGqQHJRKgHFImcHTlYOccjb.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(CTmSwYhAqWajqwWmQiEynIyaVIXd);
								if (customController == null)
								{
									return false;
								}
								ewafQABQptfDAIIAhDITUbGjbcQT = customController.PollForAllAxes().GetEnumerator();
								SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = -3;
								break;
							}
							case 1:
								SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = -3;
								break;
							}
							if (ewafQABQptfDAIIAhDITUbGjbcQT.MoveNext())
							{
								ControllerPollingInfo current = ewafQABQptfDAIIAhDITUbGjbcQT.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = cbctvzMGqQHJRKgHFImcHTlYOccjb.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								jzMaRCbtyzlkPboKfxHSQKmRjxBub = controllerPollingInfo;
								SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = 1;
								return true;
							}
							SKWbpMlQdYLKQEQHPOuaIoXsMCZu();
							ewafQABQptfDAIIAhDITUbGjbcQT = null;
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

					private void SKWbpMlQdYLKQEQHPOuaIoXsMCZu()
					{
						SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = -1;
						if (ewafQABQptfDAIIAhDITUbGjbcQT != null)
						{
							ewafQABQptfDAIIAhDITUbGjbcQT.Dispose();
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
						oYTHoBUVNSxiwjUIpvxYJNhwfXoI oYTHoBUVNSxiwjUIpvxYJNhwfXoI2;
						if (SlQBrcfRGLhyhrfyJGNbdDJeZbmKA == -2 && nIlxtnUtoqDXEZCzIdANZrvibRmG == Environment.CurrentManagedThreadId)
						{
							SlQBrcfRGLhyhrfyJGNbdDJeZbmKA = 0;
							oYTHoBUVNSxiwjUIpvxYJNhwfXoI2 = this;
						}
						else
						{
							oYTHoBUVNSxiwjUIpvxYJNhwfXoI2 = new oYTHoBUVNSxiwjUIpvxYJNhwfXoI(0);
							oYTHoBUVNSxiwjUIpvxYJNhwfXoI2.CbctvzMGqQHJRKgHFImcHTlYOccjb = CbctvzMGqQHJRKgHFImcHTlYOccjb;
						}
						oYTHoBUVNSxiwjUIpvxYJNhwfXoI2.CTmSwYhAqWajqwWmQiEynIyaVIXd = KyIZFVUluapIPbbQFLNnvpwHrQpq;
						return oYTHoBUVNSxiwjUIpvxYJNhwfXoI2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class SLDzoIToIlXZKpOOSHmtjJKvbAeGA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int UyTrwHpmNYVHTKOQuEdQbfqEeTGM;

					private ControllerPollingInfo rWdJAvApWmOwueZagIQvxVSvTPip;

					private int DjaQaXUFlITOvDdvxGEohCIMlEhoA;

					private int uJRzcyDspPiozCzsaSwNjTKBgfow;

					public int ujkRshKcNdbstCBSTlgLEGJaIWdfB;

					public PollingHelper eztGUgiYwaBMUhJRBlLMFWRvGWFNb;

					private IEnumerator<ControllerPollingInfo> isFvhMFGlYaEHjVjgFFsljxpdjAF;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rWdJAvApWmOwueZagIQvxVSvTPip;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rWdJAvApWmOwueZagIQvxVSvTPip;
						}
					}

					[DebuggerHidden]
					public SLDzoIToIlXZKpOOSHmtjJKvbAeGA(int P_0)
					{
						UyTrwHpmNYVHTKOQuEdQbfqEeTGM = P_0;
						DjaQaXUFlITOvDdvxGEohCIMlEhoA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int uyTrwHpmNYVHTKOQuEdQbfqEeTGM = UyTrwHpmNYVHTKOQuEdQbfqEeTGM;
						if (uyTrwHpmNYVHTKOQuEdQbfqEeTGM == -3 || uyTrwHpmNYVHTKOQuEdQbfqEeTGM == 1)
						{
							try
							{
							}
							finally
							{
								HfkmHjKwjugpvYFFYDwYpmeszeFT();
							}
						}
						isFvhMFGlYaEHjVjgFFsljxpdjAF = null;
						UyTrwHpmNYVHTKOQuEdQbfqEeTGM = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int uyTrwHpmNYVHTKOQuEdQbfqEeTGM = UyTrwHpmNYVHTKOQuEdQbfqEeTGM;
							PollingHelper pollingHelper = eztGUgiYwaBMUhJRBlLMFWRvGWFNb;
							switch (uyTrwHpmNYVHTKOQuEdQbfqEeTGM)
							{
							default:
								return false;
							case 0:
							{
								UyTrwHpmNYVHTKOQuEdQbfqEeTGM = -1;
								if (uJRzcyDspPiozCzsaSwNjTKBgfow < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(uJRzcyDspPiozCzsaSwNjTKBgfow);
								if (customController == null)
								{
									return false;
								}
								isFvhMFGlYaEHjVjgFFsljxpdjAF = customController.PollForAllButtons().GetEnumerator();
								UyTrwHpmNYVHTKOQuEdQbfqEeTGM = -3;
								break;
							}
							case 1:
								UyTrwHpmNYVHTKOQuEdQbfqEeTGM = -3;
								break;
							}
							if (isFvhMFGlYaEHjVjgFFsljxpdjAF.MoveNext())
							{
								ControllerPollingInfo current = isFvhMFGlYaEHjVjgFFsljxpdjAF.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								rWdJAvApWmOwueZagIQvxVSvTPip = controllerPollingInfo;
								UyTrwHpmNYVHTKOQuEdQbfqEeTGM = 1;
								return true;
							}
							HfkmHjKwjugpvYFFYDwYpmeszeFT();
							isFvhMFGlYaEHjVjgFFsljxpdjAF = null;
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

					private void HfkmHjKwjugpvYFFYDwYpmeszeFT()
					{
						UyTrwHpmNYVHTKOQuEdQbfqEeTGM = -1;
						if (isFvhMFGlYaEHjVjgFFsljxpdjAF != null)
						{
							isFvhMFGlYaEHjVjgFFsljxpdjAF.Dispose();
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
						SLDzoIToIlXZKpOOSHmtjJKvbAeGA sLDzoIToIlXZKpOOSHmtjJKvbAeGA;
						if (UyTrwHpmNYVHTKOQuEdQbfqEeTGM == -2 && DjaQaXUFlITOvDdvxGEohCIMlEhoA == Environment.CurrentManagedThreadId)
						{
							UyTrwHpmNYVHTKOQuEdQbfqEeTGM = 0;
							sLDzoIToIlXZKpOOSHmtjJKvbAeGA = this;
						}
						else
						{
							sLDzoIToIlXZKpOOSHmtjJKvbAeGA = new SLDzoIToIlXZKpOOSHmtjJKvbAeGA(0);
							sLDzoIToIlXZKpOOSHmtjJKvbAeGA.eztGUgiYwaBMUhJRBlLMFWRvGWFNb = eztGUgiYwaBMUhJRBlLMFWRvGWFNb;
						}
						sLDzoIToIlXZKpOOSHmtjJKvbAeGA.uJRzcyDspPiozCzsaSwNjTKBgfow = ujkRshKcNdbstCBSTlgLEGJaIWdfB;
						return sLDzoIToIlXZKpOOSHmtjJKvbAeGA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fUaSDmqxGiGoQVezhIPXtqFwvXqD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int PgDDSHilHoPfdDamgJqAISDwyhxc;

					private ControllerPollingInfo DrSrEKSqTLcZmxBHkRGvKfOFZgbs;

					private int zjYCKiSmFSnMnZTlhfpBRHZWHGhq;

					private int eVkgYtwSkgEWkhRIbuAIKOEjddfdA;

					public int nyDZqdGBiPcSatFuBNJqTDEgfTxW;

					public PollingHelper fhMMscelKvafjEXddjWSoNxRKOgq;

					private IEnumerator<ControllerPollingInfo> CTgqyCBsauOhvhrgyHBZgwxsUWam;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DrSrEKSqTLcZmxBHkRGvKfOFZgbs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DrSrEKSqTLcZmxBHkRGvKfOFZgbs;
						}
					}

					[DebuggerHidden]
					public fUaSDmqxGiGoQVezhIPXtqFwvXqD(int P_0)
					{
						PgDDSHilHoPfdDamgJqAISDwyhxc = P_0;
						zjYCKiSmFSnMnZTlhfpBRHZWHGhq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pgDDSHilHoPfdDamgJqAISDwyhxc = PgDDSHilHoPfdDamgJqAISDwyhxc;
						if (pgDDSHilHoPfdDamgJqAISDwyhxc == -3 || pgDDSHilHoPfdDamgJqAISDwyhxc == 1)
						{
							try
							{
							}
							finally
							{
								oONLFfNdaWtjgxBioIcvifGqTHpA();
							}
						}
						CTgqyCBsauOhvhrgyHBZgwxsUWam = null;
						PgDDSHilHoPfdDamgJqAISDwyhxc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int pgDDSHilHoPfdDamgJqAISDwyhxc = PgDDSHilHoPfdDamgJqAISDwyhxc;
							PollingHelper pollingHelper = fhMMscelKvafjEXddjWSoNxRKOgq;
							switch (pgDDSHilHoPfdDamgJqAISDwyhxc)
							{
							default:
								return false;
							case 0:
							{
								PgDDSHilHoPfdDamgJqAISDwyhxc = -1;
								if (eVkgYtwSkgEWkhRIbuAIKOEjddfdA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(eVkgYtwSkgEWkhRIbuAIKOEjddfdA);
								if (customController == null)
								{
									return false;
								}
								CTgqyCBsauOhvhrgyHBZgwxsUWam = customController.PollForAllButtonsDown().GetEnumerator();
								PgDDSHilHoPfdDamgJqAISDwyhxc = -3;
								break;
							}
							case 1:
								PgDDSHilHoPfdDamgJqAISDwyhxc = -3;
								break;
							}
							if (CTgqyCBsauOhvhrgyHBZgwxsUWam.MoveNext())
							{
								ControllerPollingInfo current = CTgqyCBsauOhvhrgyHBZgwxsUWam.Current;
								ControllerPollingInfo drSrEKSqTLcZmxBHkRGvKfOFZgbs = new ControllerPollingInfo(current);
								drSrEKSqTLcZmxBHkRGvKfOFZgbs.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								DrSrEKSqTLcZmxBHkRGvKfOFZgbs = drSrEKSqTLcZmxBHkRGvKfOFZgbs;
								PgDDSHilHoPfdDamgJqAISDwyhxc = 1;
								return true;
							}
							oONLFfNdaWtjgxBioIcvifGqTHpA();
							CTgqyCBsauOhvhrgyHBZgwxsUWam = null;
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

					private void oONLFfNdaWtjgxBioIcvifGqTHpA()
					{
						PgDDSHilHoPfdDamgJqAISDwyhxc = -1;
						if (CTgqyCBsauOhvhrgyHBZgwxsUWam != null)
						{
							CTgqyCBsauOhvhrgyHBZgwxsUWam.Dispose();
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
						fUaSDmqxGiGoQVezhIPXtqFwvXqD fUaSDmqxGiGoQVezhIPXtqFwvXqD2;
						if (PgDDSHilHoPfdDamgJqAISDwyhxc == -2 && zjYCKiSmFSnMnZTlhfpBRHZWHGhq == Environment.CurrentManagedThreadId)
						{
							PgDDSHilHoPfdDamgJqAISDwyhxc = 0;
							fUaSDmqxGiGoQVezhIPXtqFwvXqD2 = this;
						}
						else
						{
							fUaSDmqxGiGoQVezhIPXtqFwvXqD2 = new fUaSDmqxGiGoQVezhIPXtqFwvXqD(0);
							fUaSDmqxGiGoQVezhIPXtqFwvXqD2.fhMMscelKvafjEXddjWSoNxRKOgq = fhMMscelKvafjEXddjWSoNxRKOgq;
						}
						fUaSDmqxGiGoQVezhIPXtqFwvXqD2.eVkgYtwSkgEWkhRIbuAIKOEjddfdA = nyDZqdGBiPcSatFuBNJqTDEgfTxW;
						return fUaSDmqxGiGoQVezhIPXtqFwvXqD2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lKxahNcELEgCRnVOBTRZWMJfOFCYA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int IohxKGZawnkADvMbqdciAnyyTEOkA;

					private ControllerPollingInfo cPCXYYJaTHgJaIgYbXBXDREIxjfo;

					private int CiukbYczFtVFKagSHGxHslEGjlIH;

					private int NDDJAQvMBjeedHNxdXLrSuGXwxbH;

					public int TeIulAHMbsKfgonmpiILAjKjZkRbA;

					public PollingHelper zeFEYMNwswPZoWuraStKHYXoZZvF;

					private IEnumerator<ControllerPollingInfo> WHoBjrBVvIBQYoXnjbNaDjaGtMHU;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return cPCXYYJaTHgJaIgYbXBXDREIxjfo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return cPCXYYJaTHgJaIgYbXBXDREIxjfo;
						}
					}

					[DebuggerHidden]
					public lKxahNcELEgCRnVOBTRZWMJfOFCYA(int P_0)
					{
						IohxKGZawnkADvMbqdciAnyyTEOkA = P_0;
						CiukbYczFtVFKagSHGxHslEGjlIH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iohxKGZawnkADvMbqdciAnyyTEOkA = IohxKGZawnkADvMbqdciAnyyTEOkA;
						if (iohxKGZawnkADvMbqdciAnyyTEOkA == -3 || iohxKGZawnkADvMbqdciAnyyTEOkA == 1)
						{
							try
							{
							}
							finally
							{
								TxcbWiUWPNpSBobRwGPDdYaMZDFUA();
							}
						}
						WHoBjrBVvIBQYoXnjbNaDjaGtMHU = null;
						IohxKGZawnkADvMbqdciAnyyTEOkA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int iohxKGZawnkADvMbqdciAnyyTEOkA = IohxKGZawnkADvMbqdciAnyyTEOkA;
							PollingHelper pollingHelper = zeFEYMNwswPZoWuraStKHYXoZZvF;
							switch (iohxKGZawnkADvMbqdciAnyyTEOkA)
							{
							default:
								return false;
							case 0:
							{
								IohxKGZawnkADvMbqdciAnyyTEOkA = -1;
								if (NDDJAQvMBjeedHNxdXLrSuGXwxbH < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(NDDJAQvMBjeedHNxdXLrSuGXwxbH);
								if (customController == null)
								{
									return false;
								}
								WHoBjrBVvIBQYoXnjbNaDjaGtMHU = customController.PollForAllElements().GetEnumerator();
								IohxKGZawnkADvMbqdciAnyyTEOkA = -3;
								break;
							}
							case 1:
								IohxKGZawnkADvMbqdciAnyyTEOkA = -3;
								break;
							}
							if (WHoBjrBVvIBQYoXnjbNaDjaGtMHU.MoveNext())
							{
								ControllerPollingInfo current = WHoBjrBVvIBQYoXnjbNaDjaGtMHU.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								cPCXYYJaTHgJaIgYbXBXDREIxjfo = controllerPollingInfo;
								IohxKGZawnkADvMbqdciAnyyTEOkA = 1;
								return true;
							}
							TxcbWiUWPNpSBobRwGPDdYaMZDFUA();
							WHoBjrBVvIBQYoXnjbNaDjaGtMHU = null;
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

					private void TxcbWiUWPNpSBobRwGPDdYaMZDFUA()
					{
						IohxKGZawnkADvMbqdciAnyyTEOkA = -1;
						if (WHoBjrBVvIBQYoXnjbNaDjaGtMHU != null)
						{
							WHoBjrBVvIBQYoXnjbNaDjaGtMHU.Dispose();
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
						lKxahNcELEgCRnVOBTRZWMJfOFCYA lKxahNcELEgCRnVOBTRZWMJfOFCYA2;
						if (IohxKGZawnkADvMbqdciAnyyTEOkA == -2 && CiukbYczFtVFKagSHGxHslEGjlIH == Environment.CurrentManagedThreadId)
						{
							IohxKGZawnkADvMbqdciAnyyTEOkA = 0;
							lKxahNcELEgCRnVOBTRZWMJfOFCYA2 = this;
						}
						else
						{
							lKxahNcELEgCRnVOBTRZWMJfOFCYA2 = new lKxahNcELEgCRnVOBTRZWMJfOFCYA(0);
							lKxahNcELEgCRnVOBTRZWMJfOFCYA2.zeFEYMNwswPZoWuraStKHYXoZZvF = zeFEYMNwswPZoWuraStKHYXoZZvF;
						}
						lKxahNcELEgCRnVOBTRZWMJfOFCYA2.NDDJAQvMBjeedHNxdXLrSuGXwxbH = TeIulAHMbsKfgonmpiILAjKjZkRbA;
						return lKxahNcELEgCRnVOBTRZWMJfOFCYA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ePgbeLmEzzaerOTudrzcuPOiEMrS : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sTJZKrwunaZWhbigsvZqQnuxaaIk;

					private ControllerPollingInfo TxUuNCnlQwDDZVPHDEiyGrZvfDkZ;

					private int LSrIyuAomzTcJEgIoVKxXXlUQbrI;

					private int CvxUezvGgcIYsDVZhgrmESAzVekDb;

					public int alukJallWdwbLyTfuylAsPDFzOEB;

					public PollingHelper vxHrDvoFESAhUJsTUtJASBnWxUYK;

					private IEnumerator<ControllerPollingInfo> TojTPzQmVZeQuEWsVZMHymBFOTkw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TxUuNCnlQwDDZVPHDEiyGrZvfDkZ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TxUuNCnlQwDDZVPHDEiyGrZvfDkZ;
						}
					}

					[DebuggerHidden]
					public ePgbeLmEzzaerOTudrzcuPOiEMrS(int P_0)
					{
						sTJZKrwunaZWhbigsvZqQnuxaaIk = P_0;
						LSrIyuAomzTcJEgIoVKxXXlUQbrI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sTJZKrwunaZWhbigsvZqQnuxaaIk;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								veXRSmewuGpcWTCaHaBIuulwekYu();
							}
						}
						TojTPzQmVZeQuEWsVZMHymBFOTkw = null;
						sTJZKrwunaZWhbigsvZqQnuxaaIk = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = sTJZKrwunaZWhbigsvZqQnuxaaIk;
							PollingHelper pollingHelper = vxHrDvoFESAhUJsTUtJASBnWxUYK;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								sTJZKrwunaZWhbigsvZqQnuxaaIk = -1;
								if (CvxUezvGgcIYsDVZhgrmESAzVekDb < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(CvxUezvGgcIYsDVZhgrmESAzVekDb);
								if (customController == null)
								{
									return false;
								}
								TojTPzQmVZeQuEWsVZMHymBFOTkw = customController.PollForAllElementsDown().GetEnumerator();
								sTJZKrwunaZWhbigsvZqQnuxaaIk = -3;
								break;
							}
							case 1:
								sTJZKrwunaZWhbigsvZqQnuxaaIk = -3;
								break;
							}
							if (TojTPzQmVZeQuEWsVZMHymBFOTkw.MoveNext())
							{
								ControllerPollingInfo current = TojTPzQmVZeQuEWsVZMHymBFOTkw.Current;
								ControllerPollingInfo txUuNCnlQwDDZVPHDEiyGrZvfDkZ = new ControllerPollingInfo(current);
								txUuNCnlQwDDZVPHDEiyGrZvfDkZ.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								TxUuNCnlQwDDZVPHDEiyGrZvfDkZ = txUuNCnlQwDDZVPHDEiyGrZvfDkZ;
								sTJZKrwunaZWhbigsvZqQnuxaaIk = 1;
								return true;
							}
							veXRSmewuGpcWTCaHaBIuulwekYu();
							TojTPzQmVZeQuEWsVZMHymBFOTkw = null;
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

					private void veXRSmewuGpcWTCaHaBIuulwekYu()
					{
						sTJZKrwunaZWhbigsvZqQnuxaaIk = -1;
						if (TojTPzQmVZeQuEWsVZMHymBFOTkw != null)
						{
							TojTPzQmVZeQuEWsVZMHymBFOTkw.Dispose();
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
						ePgbeLmEzzaerOTudrzcuPOiEMrS ePgbeLmEzzaerOTudrzcuPOiEMrS2;
						if (sTJZKrwunaZWhbigsvZqQnuxaaIk == -2 && LSrIyuAomzTcJEgIoVKxXXlUQbrI == Environment.CurrentManagedThreadId)
						{
							sTJZKrwunaZWhbigsvZqQnuxaaIk = 0;
							ePgbeLmEzzaerOTudrzcuPOiEMrS2 = this;
						}
						else
						{
							ePgbeLmEzzaerOTudrzcuPOiEMrS2 = new ePgbeLmEzzaerOTudrzcuPOiEMrS(0);
							ePgbeLmEzzaerOTudrzcuPOiEMrS2.vxHrDvoFESAhUJsTUtJASBnWxUYK = vxHrDvoFESAhUJsTUtJASBnWxUYK;
						}
						ePgbeLmEzzaerOTudrzcuPOiEMrS2.CvxUezvGgcIYsDVZhgrmESAzVekDb = alukJallWdwbLyTfuylAsPDFzOEB;
						return ePgbeLmEzzaerOTudrzcuPOiEMrS2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class GODplTRMsxCjqkeNmHVcGlwbfIOI : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int SRxgDhkfyfQnAfcyCwWnUJvQnZzu;

					private ControllerPollingInfo ChmdekHUmoNOVwBPNqDIuaiuflvfb;

					private int DnYUvWKlbyjqZJrvxhmcStbposNqA;

					private int fTUVmdjdISHjyhNGQjDIyGWwTXRM;

					public int mSlFqdxSKSZQagAPOxmaLqKCXuFh;

					public PollingHelper rwQWVZPGfckCgVDhykuhcLpjJknM;

					private IEnumerator<ControllerPollingInfo> RbDdtJmBubzKTannacLNbLruKtCy;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ChmdekHUmoNOVwBPNqDIuaiuflvfb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ChmdekHUmoNOVwBPNqDIuaiuflvfb;
						}
					}

					[DebuggerHidden]
					public GODplTRMsxCjqkeNmHVcGlwbfIOI(int P_0)
					{
						SRxgDhkfyfQnAfcyCwWnUJvQnZzu = P_0;
						DnYUvWKlbyjqZJrvxhmcStbposNqA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int sRxgDhkfyfQnAfcyCwWnUJvQnZzu = SRxgDhkfyfQnAfcyCwWnUJvQnZzu;
						if (sRxgDhkfyfQnAfcyCwWnUJvQnZzu == -3 || sRxgDhkfyfQnAfcyCwWnUJvQnZzu == 1)
						{
							try
							{
							}
							finally
							{
								wMfCwUUrFvzfVsZXFYcbXGEQIyBG();
							}
						}
						RbDdtJmBubzKTannacLNbLruKtCy = null;
						SRxgDhkfyfQnAfcyCwWnUJvQnZzu = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int sRxgDhkfyfQnAfcyCwWnUJvQnZzu = SRxgDhkfyfQnAfcyCwWnUJvQnZzu;
							PollingHelper pollingHelper = rwQWVZPGfckCgVDhykuhcLpjJknM;
							switch (sRxgDhkfyfQnAfcyCwWnUJvQnZzu)
							{
							default:
								return false;
							case 0:
							{
								SRxgDhkfyfQnAfcyCwWnUJvQnZzu = -1;
								if (fTUVmdjdISHjyhNGQjDIyGWwTXRM < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(fTUVmdjdISHjyhNGQjDIyGWwTXRM);
								if (joystick == null)
								{
									return false;
								}
								RbDdtJmBubzKTannacLNbLruKtCy = joystick.PollForAllAxes().GetEnumerator();
								SRxgDhkfyfQnAfcyCwWnUJvQnZzu = -3;
								break;
							}
							case 1:
								SRxgDhkfyfQnAfcyCwWnUJvQnZzu = -3;
								break;
							}
							if (RbDdtJmBubzKTannacLNbLruKtCy.MoveNext())
							{
								ControllerPollingInfo current = RbDdtJmBubzKTannacLNbLruKtCy.Current;
								ControllerPollingInfo chmdekHUmoNOVwBPNqDIuaiuflvfb = new ControllerPollingInfo(current);
								chmdekHUmoNOVwBPNqDIuaiuflvfb.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								ChmdekHUmoNOVwBPNqDIuaiuflvfb = chmdekHUmoNOVwBPNqDIuaiuflvfb;
								SRxgDhkfyfQnAfcyCwWnUJvQnZzu = 1;
								return true;
							}
							wMfCwUUrFvzfVsZXFYcbXGEQIyBG();
							RbDdtJmBubzKTannacLNbLruKtCy = null;
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

					private void wMfCwUUrFvzfVsZXFYcbXGEQIyBG()
					{
						SRxgDhkfyfQnAfcyCwWnUJvQnZzu = -1;
						if (RbDdtJmBubzKTannacLNbLruKtCy != null)
						{
							RbDdtJmBubzKTannacLNbLruKtCy.Dispose();
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
						GODplTRMsxCjqkeNmHVcGlwbfIOI gODplTRMsxCjqkeNmHVcGlwbfIOI;
						if (SRxgDhkfyfQnAfcyCwWnUJvQnZzu == -2 && DnYUvWKlbyjqZJrvxhmcStbposNqA == Environment.CurrentManagedThreadId)
						{
							SRxgDhkfyfQnAfcyCwWnUJvQnZzu = 0;
							gODplTRMsxCjqkeNmHVcGlwbfIOI = this;
						}
						else
						{
							gODplTRMsxCjqkeNmHVcGlwbfIOI = new GODplTRMsxCjqkeNmHVcGlwbfIOI(0);
							gODplTRMsxCjqkeNmHVcGlwbfIOI.rwQWVZPGfckCgVDhykuhcLpjJknM = rwQWVZPGfckCgVDhykuhcLpjJknM;
						}
						gODplTRMsxCjqkeNmHVcGlwbfIOI.fTUVmdjdISHjyhNGQjDIyGWwTXRM = mSlFqdxSKSZQagAPOxmaLqKCXuFh;
						return gODplTRMsxCjqkeNmHVcGlwbfIOI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class PRNQdPvyrqUDrrtgpdeefjvwLbFo : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int QaIPYLARUUykOKUFtaDlxgltUFyB;

					private ControllerPollingInfo ZjSAuEGwxrGfYltKGPPTJYFIIIDWA;

					private int FvpxbqKjIKCDAPEpGUwInfvwBHME;

					private int kKRSdbANSFrzkjBFlCvIqGifkGFs;

					public int gTwqbDpwWiGJsNeGMLJfnzCAnYp;

					public PollingHelper CFnUTHJUCUKRnmPLHqoYjkZBGKmh;

					private IEnumerator<ControllerPollingInfo> FYAmAGGElAgQQWaZbgIDFxTcWCLWA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZjSAuEGwxrGfYltKGPPTJYFIIIDWA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZjSAuEGwxrGfYltKGPPTJYFIIIDWA;
						}
					}

					[DebuggerHidden]
					public PRNQdPvyrqUDrrtgpdeefjvwLbFo(int P_0)
					{
						QaIPYLARUUykOKUFtaDlxgltUFyB = P_0;
						FvpxbqKjIKCDAPEpGUwInfvwBHME = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int qaIPYLARUUykOKUFtaDlxgltUFyB = QaIPYLARUUykOKUFtaDlxgltUFyB;
						if (qaIPYLARUUykOKUFtaDlxgltUFyB == -3 || qaIPYLARUUykOKUFtaDlxgltUFyB == 1)
						{
							try
							{
							}
							finally
							{
								NaBFeXPDxMxMkoqthbpViglTvDxFA();
							}
						}
						FYAmAGGElAgQQWaZbgIDFxTcWCLWA = null;
						QaIPYLARUUykOKUFtaDlxgltUFyB = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int qaIPYLARUUykOKUFtaDlxgltUFyB = QaIPYLARUUykOKUFtaDlxgltUFyB;
							PollingHelper cFnUTHJUCUKRnmPLHqoYjkZBGKmh = CFnUTHJUCUKRnmPLHqoYjkZBGKmh;
							switch (qaIPYLARUUykOKUFtaDlxgltUFyB)
							{
							default:
								return false;
							case 0:
							{
								QaIPYLARUUykOKUFtaDlxgltUFyB = -1;
								if (kKRSdbANSFrzkjBFlCvIqGifkGFs < 0)
								{
									return false;
								}
								Joystick joystick = cFnUTHJUCUKRnmPLHqoYjkZBGKmh.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(kKRSdbANSFrzkjBFlCvIqGifkGFs);
								if (joystick == null)
								{
									return false;
								}
								FYAmAGGElAgQQWaZbgIDFxTcWCLWA = joystick.PollForAllButtons().GetEnumerator();
								QaIPYLARUUykOKUFtaDlxgltUFyB = -3;
								break;
							}
							case 1:
								QaIPYLARUUykOKUFtaDlxgltUFyB = -3;
								break;
							}
							if (FYAmAGGElAgQQWaZbgIDFxTcWCLWA.MoveNext())
							{
								ControllerPollingInfo current = FYAmAGGElAgQQWaZbgIDFxTcWCLWA.Current;
								ControllerPollingInfo zjSAuEGwxrGfYltKGPPTJYFIIIDWA = new ControllerPollingInfo(current);
								zjSAuEGwxrGfYltKGPPTJYFIIIDWA.playerId = cFnUTHJUCUKRnmPLHqoYjkZBGKmh.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								ZjSAuEGwxrGfYltKGPPTJYFIIIDWA = zjSAuEGwxrGfYltKGPPTJYFIIIDWA;
								QaIPYLARUUykOKUFtaDlxgltUFyB = 1;
								return true;
							}
							NaBFeXPDxMxMkoqthbpViglTvDxFA();
							FYAmAGGElAgQQWaZbgIDFxTcWCLWA = null;
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

					private void NaBFeXPDxMxMkoqthbpViglTvDxFA()
					{
						QaIPYLARUUykOKUFtaDlxgltUFyB = -1;
						if (FYAmAGGElAgQQWaZbgIDFxTcWCLWA != null)
						{
							FYAmAGGElAgQQWaZbgIDFxTcWCLWA.Dispose();
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
						PRNQdPvyrqUDrrtgpdeefjvwLbFo pRNQdPvyrqUDrrtgpdeefjvwLbFo;
						if (QaIPYLARUUykOKUFtaDlxgltUFyB == -2 && FvpxbqKjIKCDAPEpGUwInfvwBHME == Environment.CurrentManagedThreadId)
						{
							QaIPYLARUUykOKUFtaDlxgltUFyB = 0;
							pRNQdPvyrqUDrrtgpdeefjvwLbFo = this;
						}
						else
						{
							pRNQdPvyrqUDrrtgpdeefjvwLbFo = new PRNQdPvyrqUDrrtgpdeefjvwLbFo(0);
							pRNQdPvyrqUDrrtgpdeefjvwLbFo.CFnUTHJUCUKRnmPLHqoYjkZBGKmh = CFnUTHJUCUKRnmPLHqoYjkZBGKmh;
						}
						pRNQdPvyrqUDrrtgpdeefjvwLbFo.kKRSdbANSFrzkjBFlCvIqGifkGFs = gTwqbDpwWiGJsNeGMLJfnzCAnYp;
						return pRNQdPvyrqUDrrtgpdeefjvwLbFo;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ipOcSXHcJeOqIOUgvOEGZagXTmOC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zesCxGsXBPErzdGCkAYxkMryPuRc;

					private ControllerPollingInfo LQIQLQCnXyuRCALAyBrxBFWRareX;

					private int iNfHHtIjNNxbwngGsUmDRLPVtkmp;

					private int sMwGLqrFPgXmMhxbLESsbefafAsgA;

					public int IzddGAkGxiRbxQVbdaEvNxqaCVCp;

					public PollingHelper QQAFnmsQqMoMNYvdaQZsYygBBPuX;

					private IEnumerator<ControllerPollingInfo> GIpbaUIWqNZuutaVHucExtTOFuXFb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LQIQLQCnXyuRCALAyBrxBFWRareX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LQIQLQCnXyuRCALAyBrxBFWRareX;
						}
					}

					[DebuggerHidden]
					public ipOcSXHcJeOqIOUgvOEGZagXTmOC(int P_0)
					{
						zesCxGsXBPErzdGCkAYxkMryPuRc = P_0;
						iNfHHtIjNNxbwngGsUmDRLPVtkmp = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zesCxGsXBPErzdGCkAYxkMryPuRc;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								TsmiJianYcDknkxPiLGDqmkPQySpA();
							}
						}
						GIpbaUIWqNZuutaVHucExtTOFuXFb = null;
						zesCxGsXBPErzdGCkAYxkMryPuRc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = zesCxGsXBPErzdGCkAYxkMryPuRc;
							PollingHelper qQAFnmsQqMoMNYvdaQZsYygBBPuX = QQAFnmsQqMoMNYvdaQZsYygBBPuX;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								zesCxGsXBPErzdGCkAYxkMryPuRc = -1;
								if (sMwGLqrFPgXmMhxbLESsbefafAsgA < 0)
								{
									return false;
								}
								Joystick joystick = qQAFnmsQqMoMNYvdaQZsYygBBPuX.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(sMwGLqrFPgXmMhxbLESsbefafAsgA);
								if (joystick == null)
								{
									return false;
								}
								GIpbaUIWqNZuutaVHucExtTOFuXFb = joystick.PollForAllButtonsDown().GetEnumerator();
								zesCxGsXBPErzdGCkAYxkMryPuRc = -3;
								break;
							}
							case 1:
								zesCxGsXBPErzdGCkAYxkMryPuRc = -3;
								break;
							}
							if (GIpbaUIWqNZuutaVHucExtTOFuXFb.MoveNext())
							{
								ControllerPollingInfo current = GIpbaUIWqNZuutaVHucExtTOFuXFb.Current;
								ControllerPollingInfo lQIQLQCnXyuRCALAyBrxBFWRareX = new ControllerPollingInfo(current);
								lQIQLQCnXyuRCALAyBrxBFWRareX.playerId = qQAFnmsQqMoMNYvdaQZsYygBBPuX.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								LQIQLQCnXyuRCALAyBrxBFWRareX = lQIQLQCnXyuRCALAyBrxBFWRareX;
								zesCxGsXBPErzdGCkAYxkMryPuRc = 1;
								return true;
							}
							TsmiJianYcDknkxPiLGDqmkPQySpA();
							GIpbaUIWqNZuutaVHucExtTOFuXFb = null;
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

					private void TsmiJianYcDknkxPiLGDqmkPQySpA()
					{
						zesCxGsXBPErzdGCkAYxkMryPuRc = -1;
						if (GIpbaUIWqNZuutaVHucExtTOFuXFb != null)
						{
							GIpbaUIWqNZuutaVHucExtTOFuXFb.Dispose();
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
						ipOcSXHcJeOqIOUgvOEGZagXTmOC ipOcSXHcJeOqIOUgvOEGZagXTmOC2;
						if (zesCxGsXBPErzdGCkAYxkMryPuRc == -2 && iNfHHtIjNNxbwngGsUmDRLPVtkmp == Environment.CurrentManagedThreadId)
						{
							zesCxGsXBPErzdGCkAYxkMryPuRc = 0;
							ipOcSXHcJeOqIOUgvOEGZagXTmOC2 = this;
						}
						else
						{
							ipOcSXHcJeOqIOUgvOEGZagXTmOC2 = new ipOcSXHcJeOqIOUgvOEGZagXTmOC(0);
							ipOcSXHcJeOqIOUgvOEGZagXTmOC2.QQAFnmsQqMoMNYvdaQZsYygBBPuX = QQAFnmsQqMoMNYvdaQZsYygBBPuX;
						}
						ipOcSXHcJeOqIOUgvOEGZagXTmOC2.sMwGLqrFPgXmMhxbLESsbefafAsgA = IzddGAkGxiRbxQVbdaEvNxqaCVCp;
						return ipOcSXHcJeOqIOUgvOEGZagXTmOC2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class SYlYioUcFGAPsdXwpFVVgefwumnuA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pTSBNiEyhmGNStOQSTwXpzLdAkMrA;

					private ControllerPollingInfo pjcBdtFhFoCQtogFXQVQmunXyakR;

					private int XJAowkKhPhOiXJysLKiTdQjrTEgx;

					private int SOrkvwodEZUBbgTXfSxHPWKUGLUC;

					public int WazJniepENLoNtkyFlnqwaavNhxD;

					public PollingHelper dnYFhiCIKsaYCilFFBbRLPUgaUDEb;

					private IEnumerator<ControllerPollingInfo> xtwUmFIShmBphGWqKdnjRNpKDXWZA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return pjcBdtFhFoCQtogFXQVQmunXyakR;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return pjcBdtFhFoCQtogFXQVQmunXyakR;
						}
					}

					[DebuggerHidden]
					public SYlYioUcFGAPsdXwpFVVgefwumnuA(int P_0)
					{
						pTSBNiEyhmGNStOQSTwXpzLdAkMrA = P_0;
						XJAowkKhPhOiXJysLKiTdQjrTEgx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pTSBNiEyhmGNStOQSTwXpzLdAkMrA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								ghBiIoFtNMgItUphhxZKHosPHNBD();
							}
						}
						xtwUmFIShmBphGWqKdnjRNpKDXWZA = null;
						pTSBNiEyhmGNStOQSTwXpzLdAkMrA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pTSBNiEyhmGNStOQSTwXpzLdAkMrA;
							PollingHelper pollingHelper = dnYFhiCIKsaYCilFFBbRLPUgaUDEb;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								pTSBNiEyhmGNStOQSTwXpzLdAkMrA = -1;
								if (SOrkvwodEZUBbgTXfSxHPWKUGLUC < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(SOrkvwodEZUBbgTXfSxHPWKUGLUC);
								if (joystick == null)
								{
									return false;
								}
								xtwUmFIShmBphGWqKdnjRNpKDXWZA = joystick.PollForAllElements().GetEnumerator();
								pTSBNiEyhmGNStOQSTwXpzLdAkMrA = -3;
								break;
							}
							case 1:
								pTSBNiEyhmGNStOQSTwXpzLdAkMrA = -3;
								break;
							}
							if (xtwUmFIShmBphGWqKdnjRNpKDXWZA.MoveNext())
							{
								ControllerPollingInfo current = xtwUmFIShmBphGWqKdnjRNpKDXWZA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								pjcBdtFhFoCQtogFXQVQmunXyakR = controllerPollingInfo;
								pTSBNiEyhmGNStOQSTwXpzLdAkMrA = 1;
								return true;
							}
							ghBiIoFtNMgItUphhxZKHosPHNBD();
							xtwUmFIShmBphGWqKdnjRNpKDXWZA = null;
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

					private void ghBiIoFtNMgItUphhxZKHosPHNBD()
					{
						pTSBNiEyhmGNStOQSTwXpzLdAkMrA = -1;
						if (xtwUmFIShmBphGWqKdnjRNpKDXWZA != null)
						{
							xtwUmFIShmBphGWqKdnjRNpKDXWZA.Dispose();
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
						SYlYioUcFGAPsdXwpFVVgefwumnuA sYlYioUcFGAPsdXwpFVVgefwumnuA;
						if (pTSBNiEyhmGNStOQSTwXpzLdAkMrA == -2 && XJAowkKhPhOiXJysLKiTdQjrTEgx == Environment.CurrentManagedThreadId)
						{
							pTSBNiEyhmGNStOQSTwXpzLdAkMrA = 0;
							sYlYioUcFGAPsdXwpFVVgefwumnuA = this;
						}
						else
						{
							sYlYioUcFGAPsdXwpFVVgefwumnuA = new SYlYioUcFGAPsdXwpFVVgefwumnuA(0);
							sYlYioUcFGAPsdXwpFVVgefwumnuA.dnYFhiCIKsaYCilFFBbRLPUgaUDEb = dnYFhiCIKsaYCilFFBbRLPUgaUDEb;
						}
						sYlYioUcFGAPsdXwpFVVgefwumnuA.SOrkvwodEZUBbgTXfSxHPWKUGLUC = WazJniepENLoNtkyFlnqwaavNhxD;
						return sYlYioUcFGAPsdXwpFVVgefwumnuA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class LChWvfrIBIVddojWbQQTPHQlylZx : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int gQEGwmcAZuGPFjbnTBHUoRnLJkqE;

					private ControllerPollingInfo yBzMIErBlsOOEshSdsdxzQvFtmHd;

					private int aDRfvyQKLBAPsZGIecwDivgZpGzU;

					private int uDmVyfxLdFASOzbXnkeCRCXXonsC;

					public int vXpLKFtnhfVSGyHvQWFySYeEhOGe;

					public PollingHelper PoZapwSyRzUwZtXGzrfpLPgfqfGq;

					private IEnumerator<ControllerPollingInfo> aYExAhKGPGLRzMkciLihitfLQOcw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return yBzMIErBlsOOEshSdsdxzQvFtmHd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return yBzMIErBlsOOEshSdsdxzQvFtmHd;
						}
					}

					[DebuggerHidden]
					public LChWvfrIBIVddojWbQQTPHQlylZx(int P_0)
					{
						gQEGwmcAZuGPFjbnTBHUoRnLJkqE = P_0;
						aDRfvyQKLBAPsZGIecwDivgZpGzU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = gQEGwmcAZuGPFjbnTBHUoRnLJkqE;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								VGCYHCsQKwSSynLKpCpJdckDfaijb();
							}
						}
						aYExAhKGPGLRzMkciLihitfLQOcw = null;
						gQEGwmcAZuGPFjbnTBHUoRnLJkqE = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = gQEGwmcAZuGPFjbnTBHUoRnLJkqE;
							PollingHelper poZapwSyRzUwZtXGzrfpLPgfqfGq = PoZapwSyRzUwZtXGzrfpLPgfqfGq;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								gQEGwmcAZuGPFjbnTBHUoRnLJkqE = -1;
								if (uDmVyfxLdFASOzbXnkeCRCXXonsC < 0)
								{
									return false;
								}
								Joystick joystick = poZapwSyRzUwZtXGzrfpLPgfqfGq.TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(uDmVyfxLdFASOzbXnkeCRCXXonsC);
								if (joystick == null)
								{
									return false;
								}
								aYExAhKGPGLRzMkciLihitfLQOcw = joystick.PollForAllElementsDown().GetEnumerator();
								gQEGwmcAZuGPFjbnTBHUoRnLJkqE = -3;
								break;
							}
							case 1:
								gQEGwmcAZuGPFjbnTBHUoRnLJkqE = -3;
								break;
							}
							if (aYExAhKGPGLRzMkciLihitfLQOcw.MoveNext())
							{
								ControllerPollingInfo current = aYExAhKGPGLRzMkciLihitfLQOcw.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = poZapwSyRzUwZtXGzrfpLPgfqfGq.LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
								yBzMIErBlsOOEshSdsdxzQvFtmHd = controllerPollingInfo;
								gQEGwmcAZuGPFjbnTBHUoRnLJkqE = 1;
								return true;
							}
							VGCYHCsQKwSSynLKpCpJdckDfaijb();
							aYExAhKGPGLRzMkciLihitfLQOcw = null;
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

					private void VGCYHCsQKwSSynLKpCpJdckDfaijb()
					{
						gQEGwmcAZuGPFjbnTBHUoRnLJkqE = -1;
						if (aYExAhKGPGLRzMkciLihitfLQOcw != null)
						{
							aYExAhKGPGLRzMkciLihitfLQOcw.Dispose();
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
						LChWvfrIBIVddojWbQQTPHQlylZx lChWvfrIBIVddojWbQQTPHQlylZx;
						if (gQEGwmcAZuGPFjbnTBHUoRnLJkqE == -2 && aDRfvyQKLBAPsZGIecwDivgZpGzU == Environment.CurrentManagedThreadId)
						{
							gQEGwmcAZuGPFjbnTBHUoRnLJkqE = 0;
							lChWvfrIBIVddojWbQQTPHQlylZx = this;
						}
						else
						{
							lChWvfrIBIVddojWbQQTPHQlylZx = new LChWvfrIBIVddojWbQQTPHQlylZx(0);
							lChWvfrIBIVddojWbQQTPHQlylZx.PoZapwSyRzUwZtXGzrfpLPgfqfGq = PoZapwSyRzUwZtXGzrfpLPgfqfGq;
						}
						lChWvfrIBIVddojWbQQTPHQlylZx.uDmVyfxLdFASOzbXnkeCRCXXonsC = vXpLKFtnhfVSGyHvQWFySYeEhOGe;
						return lChWvfrIBIVddojWbQQTPHQlylZx;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player LygdTBSVpqRMeuUHrrvkeHtYavSM;

				private readonly ControllerHelper TpoWsRYPPdXSZiYAafufuKgMwWMJ;

				private readonly int GueEKUDwEKcUasQmBjReAgxiVVoNb;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					GueEKUDwEKcUasQmBjReAgxiVVoNb = ReInput.id;
					LygdTBSVpqRMeuUHrrvkeHtYavSM = P_0;
					TpoWsRYPPdXSZiYAafufuKgMwWMJ = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => JuxtfSBLTkVnwxjgbAyWwyYUBfDF(), 
						ControllerType.Joystick => zgQXfIsEfwXaQZhhFUwpKklGGTaf(controllerId), 
						ControllerType.Mouse => pmjpFHylVdUxUJSYPTJhjKUsFJFY(), 
						ControllerType.Custom => ZKHbCScCcQFQUUtjUngRBeagKVXc(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zrtPLvBWNGMpRKFvCaHzDeVFLlRE(), 
						ControllerType.Joystick => xujkbtMbspeQUQlMpsCxKhZISsWQ(controllerId), 
						ControllerType.Mouse => SlotlfmjtUWvjrjRXOMgPtAcTYAr(), 
						ControllerType.Custom => BlYsaBmXyagnxIPNwAaziUFQlBnz(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => JuxtfSBLTkVnwxjgbAyWwyYUBfDF(), 
						ControllerType.Joystick => fyxHepRfMVAuEGuMsLjSyKJYigCYA(controllerId), 
						ControllerType.Mouse => MqHSJbwNxQXFzNYXxjUQvNoZnekA(), 
						ControllerType.Custom => vhOnKFJyljqDJOXHBcxxqhaqHyTj(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zrtPLvBWNGMpRKFvCaHzDeVFLlRE(), 
						ControllerType.Joystick => bYVDqMJnnYMUNhiPkBRICqueIbmtb(controllerId), 
						ControllerType.Mouse => FitQiCXrnwVpdnyIyzCQbJlcYRvf(), 
						ControllerType.Custom => qVNJKQdcPajQUCpQSiCBhcUmryXHA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY(), 
						ControllerType.Joystick => NysNPCrNbWvoCNgTOWCIVCCokCQc(controllerId), 
						ControllerType.Mouse => DrnkSfkrSNeKMkZSbvFTHBgGpnujA(), 
						ControllerType.Custom => EEMdCOiJgYOEgYIGAJEjHDnjFKEAb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => AmDDeTREpPrsXFxaNAsIIVlSDyIC(), 
						ControllerType.Joystick => kAIVJKiQFbnZkswEfcJiwjoHTWft(controllerId), 
						ControllerType.Mouse => NjebSkTwKpnPCWLyEDXjsLbhmGcY(), 
						ControllerType.Custom => TYZitfhRSHTtpOkrgiBRKVdYJTzx(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zeIblBUSoLvcLCNoXXOylVdDdyMS(), 
						ControllerType.Joystick => QXQYVhnjpbUSwWMvgFZYYxkcVswg(controllerId), 
						ControllerType.Mouse => LSawwQHyQACSWrabSfLOYJFKCBZx(), 
						ControllerType.Custom => VEfHevXckvsMmYeHULzzjcQzfTlx(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => AmDDeTREpPrsXFxaNAsIIVlSDyIC(), 
						ControllerType.Joystick => TnTasRnYzpMsqSgzMwpYMLrCxDKd(controllerId), 
						ControllerType.Mouse => OicVPAqWvTbZrXBAVLFXZLOoBLmq(), 
						ControllerType.Custom => EXqaTxJlFAcUfZkioKmSjVLscSRS(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zeIblBUSoLvcLCNoXXOylVdDdyMS(), 
						ControllerType.Joystick => aknQYaRaDwCpWDgokHqNlsKeusQiA(controllerId), 
						ControllerType.Mouse => zuIaklNBXKcLfKrliaWybFdsVpHY(), 
						ControllerType.Custom => HBEXmgpftCCUZtpHTCdqzPNdWFK(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => CDlcfHrHLthTadXGBZPbdEbSbVylA(controllerId), 
						ControllerType.Mouse => yGzJuOPBUKvLzBXlEhStscEjWnU(), 
						ControllerType.Custom => vMLfsZmJawAjGADhYRSqwBQZDnyZ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => JuxtfSBLTkVnwxjgbAyWwyYUBfDF(), 
						ControllerType.Joystick => vacqeecUbwuMAyLVXfixHAkvDaPEA(), 
						ControllerType.Mouse => pmjpFHylVdUxUJSYPTJhjKUsFJFY(), 
						ControllerType.Custom => VfxYfcdsWMDRdAEnpMaAIVNcVOYTb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => JuxtfSBLTkVnwxjgbAyWwyYUBfDF(), 
						ControllerType.Joystick => rBFxcubVFtbKIfEkCskUuQZVAGCT(), 
						ControllerType.Mouse => MqHSJbwNxQXFzNYXxjUQvNoZnekA(), 
						ControllerType.Custom => yfpUUiARxQvnQULKnUqDnFlNZfN(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zrtPLvBWNGMpRKFvCaHzDeVFLlRE(), 
						ControllerType.Joystick => WRFwIefEKntrSDqgeiBhuRJSkdwr(), 
						ControllerType.Mouse => FitQiCXrnwVpdnyIyzCQbJlcYRvf(), 
						ControllerType.Custom => JATuGAHfTjjsQEJNcJuONbDwJgGk(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY(), 
						ControllerType.Joystick => OZSTSLDgKEBNrzjIOfGBmlGfPTss(), 
						ControllerType.Mouse => DrnkSfkrSNeKMkZSbvFTHBgGpnujA(), 
						ControllerType.Custom => QxRPDryfuOLpfaHITwrgzqaeoEYN(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => AmDDeTREpPrsXFxaNAsIIVlSDyIC(), 
						ControllerType.Joystick => XffYXKWWAjDPLGjxVSgXKPOGkkYg(), 
						ControllerType.Mouse => NjebSkTwKpnPCWLyEDXjsLbhmGcY(), 
						ControllerType.Custom => PNQcYZkHdyKlaYbEuwgxbWFmKHAl(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zeIblBUSoLvcLCNoXXOylVdDdyMS(), 
						ControllerType.Joystick => ngXFInkyyieorhxzqLSeFuClxVGab(), 
						ControllerType.Mouse => LSawwQHyQACSWrabSfLOYJFKCBZx(), 
						ControllerType.Custom => VeddRqiBzVhpMhCVzszqatTvVBsdb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => AmDDeTREpPrsXFxaNAsIIVlSDyIC(), 
						ControllerType.Joystick => TjWvDCpgRnVntXXAolxWWccAaCct(), 
						ControllerType.Mouse => OicVPAqWvTbZrXBAVLFXZLOoBLmq(), 
						ControllerType.Custom => elDctDmGrbbDVxbVdjNsJNGMuCQT(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => zeIblBUSoLvcLCNoXXOylVdDdyMS(), 
						ControllerType.Joystick => fjHirqpxXyFtSCltJOgrjiLCfSgt(), 
						ControllerType.Mouse => zuIaklNBXKcLfKrliaWybFdsVpHY(), 
						ControllerType.Custom => JwvZqACZzzQPJfkiXIGcdglQZaQAA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != GueEKUDwEKcUasQmBjReAgxiVVoNb)
					{
						ReInput.CheckInitialized(GueEKUDwEKcUasQmBjReAgxiVVoNb);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => snoIpoMxzcjueakZSNaMiMgthPAj(), 
						ControllerType.Mouse => yGzJuOPBUKvLzBXlEhStscEjWnU(), 
						ControllerType.Custom => JKMnSFjHhDLjvZVvVOpITOOMLCEe(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo zgQXfIsEfwXaQZhhFUwpKklGGTaf(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					Joystick joystick = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo xujkbtMbspeQUQlMpsCxKhZISsWQ(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					Joystick joystick = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo fyxHepRfMVAuEGuMsLjSyKJYigCYA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					Joystick joystick = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo bYVDqMJnnYMUNhiPkBRICqueIbmtb(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					Joystick joystick = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo NysNPCrNbWvoCNgTOWCIVCCokCQc(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					Joystick joystick = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				[IteratorStateMachine(typeof(SYlYioUcFGAPsdXwpFVVgefwumnuA))]
				private IEnumerable<ControllerPollingInfo> kAIVJKiQFbnZkswEfcJiwjoHTWft(int P_0)
				{
					return new SYlYioUcFGAPsdXwpFVVgefwumnuA(-2)
					{
						dnYFhiCIKsaYCilFFBbRLPUgaUDEb = this,
						WazJniepENLoNtkyFlnqwaavNhxD = P_0
					};
				}

				[IteratorStateMachine(typeof(LChWvfrIBIVddojWbQQTPHQlylZx))]
				private IEnumerable<ControllerPollingInfo> QXQYVhnjpbUSwWMvgFZYYxkcVswg(int P_0)
				{
					return new LChWvfrIBIVddojWbQQTPHQlylZx(-2)
					{
						PoZapwSyRzUwZtXGzrfpLPgfqfGq = this,
						vXpLKFtnhfVSGyHvQWFySYeEhOGe = P_0
					};
				}

				[IteratorStateMachine(typeof(PRNQdPvyrqUDrrtgpdeefjvwLbFo))]
				private IEnumerable<ControllerPollingInfo> TnTasRnYzpMsqSgzMwpYMLrCxDKd(int P_0)
				{
					return new PRNQdPvyrqUDrrtgpdeefjvwLbFo(-2)
					{
						CFnUTHJUCUKRnmPLHqoYjkZBGKmh = this,
						gTwqbDpwWiGJsNeGMLJfnzCAnYp = P_0
					};
				}

				[IteratorStateMachine(typeof(ipOcSXHcJeOqIOUgvOEGZagXTmOC))]
				private IEnumerable<ControllerPollingInfo> aknQYaRaDwCpWDgokHqNlsKeusQiA(int P_0)
				{
					return new ipOcSXHcJeOqIOUgvOEGZagXTmOC(-2)
					{
						QQAFnmsQqMoMNYvdaQZsYygBBPuX = this,
						IzddGAkGxiRbxQVbdaEvNxqaCVCp = P_0
					};
				}

				[IteratorStateMachine(typeof(GODplTRMsxCjqkeNmHVcGlwbfIOI))]
				private IEnumerable<ControllerPollingInfo> CDlcfHrHLthTadXGBZPbdEbSbVylA(int P_0)
				{
					return new GODplTRMsxCjqkeNmHVcGlwbfIOI(-2)
					{
						rwQWVZPGfckCgVDhykuhcLpjJknM = this,
						mSlFqdxSKSZQagAPOxmaLqKCXuFh = P_0
					};
				}

				private ControllerPollingInfo vacqeecUbwuMAyLVXfixHAkvDaPEA()
				{
					IList<Joystick> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo QYixQnevCsaUebbWKdJeHToAcbpeA()
				{
					IList<Joystick> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo rBFxcubVFtbKIfEkCskUuQZVAGCT()
				{
					IList<Joystick> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo WRFwIefEKntrSDqgeiBhuRJSkdwr()
				{
					IList<Joystick> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo OZSTSLDgKEBNrzjIOfGBmlGfPTss()
				{
					IList<Joystick> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.SFAHkfrETxQOZFFlVqQxfxXoeRaK.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				[IteratorStateMachine(typeof(lxrpwxNdCNDXGfPmwyjUKcQtOwmQ))]
				private IEnumerable<ControllerPollingInfo> XffYXKWWAjDPLGjxVSgXKPOGkkYg()
				{
					return new lxrpwxNdCNDXGfPmwyjUKcQtOwmQ(-2)
					{
						zmVqQfLXncbpxZQIOyRhyYMfHjKI = this
					};
				}

				[IteratorStateMachine(typeof(TZRDxJSvfmtSXWaxHtBLQVNONHmw))]
				private IEnumerable<ControllerPollingInfo> ngXFInkyyieorhxzqLSeFuClxVGab()
				{
					return new TZRDxJSvfmtSXWaxHtBLQVNONHmw(-2)
					{
						XuvDyWSsubeHtxrPWmxcIsTYEUHS = this
					};
				}

				[IteratorStateMachine(typeof(ebcAjvmTnZfDdiIczDDzhNggwSWi))]
				private IEnumerable<ControllerPollingInfo> TjWvDCpgRnVntXXAolxWWccAaCct()
				{
					return new ebcAjvmTnZfDdiIczDDzhNggwSWi(-2)
					{
						FJfKkLhVksvKIDGVgsyotpQMhPdM = this
					};
				}

				[IteratorStateMachine(typeof(XguQJjvOcWtIMGhjIDRQbKcWcnLAA))]
				private IEnumerable<ControllerPollingInfo> fjHirqpxXyFtSCltJOgrjiLCfSgt()
				{
					return new XguQJjvOcWtIMGhjIDRQbKcWcnLAA(-2)
					{
						HkvikqwixRfQjPLuJMHKUhjyxaOc = this
					};
				}

				[IteratorStateMachine(typeof(MyKdFPUfLiyFXqHEdibHlMNnzjvT))]
				private IEnumerable<ControllerPollingInfo> snoIpoMxzcjueakZSNaMiMgthPAj()
				{
					return new MyKdFPUfLiyFXqHEdibHlMNnzjvT(-2)
					{
						zmPGxRRchpXXeNnDnwCvzpKGVuUH = this
					};
				}

				private ControllerPollingInfo JuxtfSBLTkVnwxjgbAyWwyYUBfDF()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.gKUHCNRAqlPFJLIgQSiAOIcTrOO)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo zrtPLvBWNGMpRKFvCaHzDeVFLlRE()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.gKUHCNRAqlPFJLIgQSiAOIcTrOO)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> AmDDeTREpPrsXFxaNAsIIVlSDyIC()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.gKUHCNRAqlPFJLIgQSiAOIcTrOO)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> zeIblBUSoLvcLCNoXXOylVdDdyMS()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.gKUHCNRAqlPFJLIgQSiAOIcTrOO)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo pmjpFHylVdUxUJSYPTJhjKUsFJFY()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo SlotlfmjtUWvjrjRXOMgPtAcTYAr()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo MqHSJbwNxQXFzNYXxjUQvNoZnekA()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo FitQiCXrnwVpdnyIyzCQbJlcYRvf()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo DrnkSfkrSNeKMkZSbvFTHBgGpnujA()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> NjebSkTwKpnPCWLyEDXjsLbhmGcY()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> LSawwQHyQACSWrabSfLOYJFKCBZx()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> OicVPAqWvTbZrXBAVLFXZLOoBLmq()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> zuIaklNBXKcLfKrliaWybFdsVpHY()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> yGzJuOPBUKvLzBXlEhStscEjWnU()
				{
					if (!TpoWsRYPPdXSZiYAafufuKgMwWMJ.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TpoWsRYPPdXSZiYAafufuKgMwWMJ.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo ZKHbCScCcQFQUUtjUngRBeagKVXc(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					CustomController customController = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo BlYsaBmXyagnxIPNwAaziUFQlBnz(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					CustomController customController = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo vhOnKFJyljqDJOXHBcxxqhaqHyTj(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					CustomController customController = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo qVNJKQdcPajQUCpQSiCBhcUmryXHA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					CustomController customController = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				private ControllerPollingInfo EEMdCOiJgYOEgYIGAJEjHDnjFKEAb(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					CustomController customController = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.lbQLGldyKUQHJMQDqmaKPaUNAXWr(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
					}
					return result;
				}

				[IteratorStateMachine(typeof(lKxahNcELEgCRnVOBTRZWMJfOFCYA))]
				private IEnumerable<ControllerPollingInfo> TYZitfhRSHTtpOkrgiBRKVdYJTzx(int P_0)
				{
					return new lKxahNcELEgCRnVOBTRZWMJfOFCYA(-2)
					{
						zeFEYMNwswPZoWuraStKHYXoZZvF = this,
						TeIulAHMbsKfgonmpiILAjKjZkRbA = P_0
					};
				}

				[IteratorStateMachine(typeof(ePgbeLmEzzaerOTudrzcuPOiEMrS))]
				private IEnumerable<ControllerPollingInfo> VEfHevXckvsMmYeHULzzjcQzfTlx(int P_0)
				{
					return new ePgbeLmEzzaerOTudrzcuPOiEMrS(-2)
					{
						vxHrDvoFESAhUJsTUtJASBnWxUYK = this,
						alukJallWdwbLyTfuylAsPDFzOEB = P_0
					};
				}

				[IteratorStateMachine(typeof(SLDzoIToIlXZKpOOSHmtjJKvbAeGA))]
				private IEnumerable<ControllerPollingInfo> EXqaTxJlFAcUfZkioKmSjVLscSRS(int P_0)
				{
					return new SLDzoIToIlXZKpOOSHmtjJKvbAeGA(-2)
					{
						eztGUgiYwaBMUhJRBlLMFWRvGWFNb = this,
						ujkRshKcNdbstCBSTlgLEGJaIWdfB = P_0
					};
				}

				[IteratorStateMachine(typeof(fUaSDmqxGiGoQVezhIPXtqFwvXqD))]
				private IEnumerable<ControllerPollingInfo> HBEXmgpftCCUZtpHTCdqzPNdWFK(int P_0)
				{
					return new fUaSDmqxGiGoQVezhIPXtqFwvXqD(-2)
					{
						fhMMscelKvafjEXddjWSoNxRKOgq = this,
						nyDZqdGBiPcSatFuBNJqTDEgfTxW = P_0
					};
				}

				[IteratorStateMachine(typeof(oYTHoBUVNSxiwjUIpvxYJNhwfXoI))]
				private IEnumerable<ControllerPollingInfo> vMLfsZmJawAjGADhYRSqwBQZDnyZ(int P_0)
				{
					return new oYTHoBUVNSxiwjUIpvxYJNhwfXoI(-2)
					{
						CbctvzMGqQHJRKgHFImcHTlYOccjb = this,
						KyIZFVUluapIPbbQFLNnvpwHrQpq = P_0
					};
				}

				private ControllerPollingInfo VfxYfcdsWMDRdAEnpMaAIVNcVOYTb()
				{
					IList<CustomController> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo rMGwYGJAafPtBRHUMFOcWqVQCyAR()
				{
					IList<CustomController> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo yfpUUiARxQvnQULKnUqDnFlNZfN()
				{
					IList<CustomController> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo JATuGAHfTjjsQEJNcJuONbDwJgGk()
				{
					IList<CustomController> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo QxRPDryfuOLpfaHITwrgzqaeoEYN()
				{
					IList<CustomController> list = TpoWsRYPPdXSZiYAafufuKgMwWMJ.zTfcdvjNudcnrgUXuTdqeOnDGmtLb.MvqWdXawFeajMsaqNWoPtaauNvng;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = LygdTBSVpqRMeuUHrrvkeHtYavSM.jPsZpqMAcPAnkudOsRQkwDRvcsej;
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				[IteratorStateMachine(typeof(DJSAHMPhIjrXcABTNlwnldbAmAxk))]
				private IEnumerable<ControllerPollingInfo> PNQcYZkHdyKlaYbEuwgxbWFmKHAl()
				{
					return new DJSAHMPhIjrXcABTNlwnldbAmAxk(-2)
					{
						dnCbRRAtqmCXXzduczynCKLGEDkQ = this
					};
				}

				[IteratorStateMachine(typeof(ShwrlKmpHfUgRiaKRFABYWCWtqCh))]
				private IEnumerable<ControllerPollingInfo> VeddRqiBzVhpMhCVzszqatTvVBsdb()
				{
					return new ShwrlKmpHfUgRiaKRFABYWCWtqCh(-2)
					{
						pMdmZxRuMscdTtTprZtfobEuEncl = this
					};
				}

				[IteratorStateMachine(typeof(dmYtHKynNhTJCpSFxZwORgirGJFh))]
				private IEnumerable<ControllerPollingInfo> elDctDmGrbbDVxbVdjNsJNGMuCQT()
				{
					return new dmYtHKynNhTJCpSFxZwORgirGJFh(-2)
					{
						vtuyslUhfbWlUjClvXTfGaIXExVA = this
					};
				}

				[IteratorStateMachine(typeof(oPolvuFqxeyDhFruyTouAxCaPaUW))]
				private IEnumerable<ControllerPollingInfo> JwvZqACZzzQPJfkiXIGcdglQZaQAA()
				{
					return new oPolvuFqxeyDhFruyTouAxCaPaUW(-2)
					{
						kjwOJdDRyqighYWsMjFAIOnDRhRb = this
					};
				}

				[IteratorStateMachine(typeof(RJpCgVnTBJeMaBniiIVSWrJqAzJX))]
				private IEnumerable<ControllerPollingInfo> JKMnSFjHhDLjvZVvVOpITOOMLCEe()
				{
					return new RJpCgVnTBJeMaBniiIVSWrJqAzJX(-2)
					{
						tWCBmQEvPCVkkckjuZZgOaHmLbIdA = this
					};
				}
			}

			[Serializable]
			private sealed class rHkcLreWgtNjySHdxzqjtmRimFJvA
			{
				public static readonly rHkcLreWgtNjySHdxzqjtmRimFJvA _003C_003E9 = new rHkcLreWgtNjySHdxzqjtmRimFJvA();

				public static Action<Exception> _003C_003E9__23_0;

				public static Action<Exception> _003C_003E9__23_1;

				internal void pgiYrZJixlrACyzbTrvDQJLperKr(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void znhBOpzmCEDmIjlGEyFDLnwIWkzgA(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class fDzZQftgQDPDiXghGyIOkClghyGP : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
			{
				private int cwEvypZUvywxbRSnQawWgRPQqhNI;

				private Controller oTNBefPyaiomaEECuEDUUxxEcNGA;

				private int XwcHMUFbECkYvtvAiEDtDBmOiPiS;

				public ControllerHelper CKHgmekrXePkWjJhGcIcmAZsSxPoc;

				private int DVRvIntUiPPdKzuOHbvuIZeStOMF;

				private IList<Joystick> XFTtXzqeDUgMjkdTPlhwEQauHzCh;

				private int WsiXwMXDzRJmmYlITezAsdkacVVU;

				private IList<CustomController> GQMEEUacStPbifWxhWGTzvvVHcYhA;

				private int CHbhTxiJkEKWSyMBVsovZknWOyDmA;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return oTNBefPyaiomaEECuEDUUxxEcNGA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return oTNBefPyaiomaEECuEDUUxxEcNGA;
					}
				}

				[DebuggerHidden]
				public fDzZQftgQDPDiXghGyIOkClghyGP(int P_0)
				{
					cwEvypZUvywxbRSnQawWgRPQqhNI = P_0;
					XwcHMUFbECkYvtvAiEDtDBmOiPiS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					XFTtXzqeDUgMjkdTPlhwEQauHzCh = null;
					GQMEEUacStPbifWxhWGTzvvVHcYhA = null;
					cwEvypZUvywxbRSnQawWgRPQqhNI = -2;
				}

				private bool MoveNext()
				{
					int num = cwEvypZUvywxbRSnQawWgRPQqhNI;
					ControllerHelper cKHgmekrXePkWjJhGcIcmAZsSxPoc = CKHgmekrXePkWjJhGcIcmAZsSxPoc;
					switch (num)
					{
					default:
						return false;
					case 0:
						cwEvypZUvywxbRSnQawWgRPQqhNI = -1;
						if (ReInput._id != cKHgmekrXePkWjJhGcIcmAZsSxPoc.XiAVSxWCRuFONouRLWQSZfiZbHPf)
						{
							ReInput.CheckInitialized(cKHgmekrXePkWjJhGcIcmAZsSxPoc.XiAVSxWCRuFONouRLWQSZfiZbHPf);
							return false;
						}
						if (cKHgmekrXePkWjJhGcIcmAZsSxPoc.GDdxgjfcPSYtRjQrUeQjHPapDEQp)
						{
							oTNBefPyaiomaEECuEDUUxxEcNGA = cKHgmekrXePkWjJhGcIcmAZsSxPoc.Mouse;
							cwEvypZUvywxbRSnQawWgRPQqhNI = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						cwEvypZUvywxbRSnQawWgRPQqhNI = -1;
						goto IL_0070;
					case 2:
						cwEvypZUvywxbRSnQawWgRPQqhNI = -1;
						goto IL_0094;
					case 3:
						cwEvypZUvywxbRSnQawWgRPQqhNI = -1;
						CHbhTxiJkEKWSyMBVsovZknWOyDmA++;
						goto IL_00ec;
					case 4:
						{
							cwEvypZUvywxbRSnQawWgRPQqhNI = -1;
							CHbhTxiJkEKWSyMBVsovZknWOyDmA++;
							break;
						}
						IL_0094:
						DVRvIntUiPPdKzuOHbvuIZeStOMF = cKHgmekrXePkWjJhGcIcmAZsSxPoc.joystickCount;
						XFTtXzqeDUgMjkdTPlhwEQauHzCh = cKHgmekrXePkWjJhGcIcmAZsSxPoc.Joysticks;
						CHbhTxiJkEKWSyMBVsovZknWOyDmA = 0;
						goto IL_00ec;
						IL_00ec:
						if (CHbhTxiJkEKWSyMBVsovZknWOyDmA < DVRvIntUiPPdKzuOHbvuIZeStOMF)
						{
							oTNBefPyaiomaEECuEDUUxxEcNGA = XFTtXzqeDUgMjkdTPlhwEQauHzCh[CHbhTxiJkEKWSyMBVsovZknWOyDmA];
							cwEvypZUvywxbRSnQawWgRPQqhNI = 3;
							return true;
						}
						WsiXwMXDzRJmmYlITezAsdkacVVU = cKHgmekrXePkWjJhGcIcmAZsSxPoc.customControllerCount;
						GQMEEUacStPbifWxhWGTzvvVHcYhA = cKHgmekrXePkWjJhGcIcmAZsSxPoc.CustomControllers;
						CHbhTxiJkEKWSyMBVsovZknWOyDmA = 0;
						break;
						IL_0070:
						if (cKHgmekrXePkWjJhGcIcmAZsSxPoc.gKUHCNRAqlPFJLIgQSiAOIcTrOO)
						{
							oTNBefPyaiomaEECuEDUUxxEcNGA = cKHgmekrXePkWjJhGcIcmAZsSxPoc.Keyboard;
							cwEvypZUvywxbRSnQawWgRPQqhNI = 2;
							return true;
						}
						goto IL_0094;
					}
					if (CHbhTxiJkEKWSyMBVsovZknWOyDmA < WsiXwMXDzRJmmYlITezAsdkacVVU)
					{
						oTNBefPyaiomaEECuEDUUxxEcNGA = GQMEEUacStPbifWxhWGTzvvVHcYhA[CHbhTxiJkEKWSyMBVsovZknWOyDmA];
						cwEvypZUvywxbRSnQawWgRPQqhNI = 4;
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
					fDzZQftgQDPDiXghGyIOkClghyGP fDzZQftgQDPDiXghGyIOkClghyGP2;
					if (cwEvypZUvywxbRSnQawWgRPQqhNI == -2 && XwcHMUFbECkYvtvAiEDtDBmOiPiS == Environment.CurrentManagedThreadId)
					{
						cwEvypZUvywxbRSnQawWgRPQqhNI = 0;
						fDzZQftgQDPDiXghGyIOkClghyGP2 = this;
					}
					else
					{
						fDzZQftgQDPDiXghGyIOkClghyGP2 = new fDzZQftgQDPDiXghGyIOkClghyGP(0);
						fDzZQftgQDPDiXghGyIOkClghyGP2.CKHgmekrXePkWjJhGcIcmAZsSxPoc = CKHgmekrXePkWjJhGcIcmAZsSxPoc;
					}
					return fDzZQftgQDPDiXghGyIOkClghyGP2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly gRltVhNwrOhpOgLZSJcAURRChXEp pPDQdaRyZpmNuhNRmtdGwAjucCjC;

			private bool GDdxgjfcPSYtRjQrUeQjHPapDEQp;

			private bool gKUHCNRAqlPFJLIgQSiAOIcTrOO;

			private bool UjTKuxjwQXJWHnLVGeCHGNiyEPvf;

			private double zvUvqiTPhuTfkqGuablCXJviHBEx;

			private double nKZgdImsxWtlkAUwPIoNHgQdbGSGA;

			private SafeAction<ControllerAssignmentChangedEventArgs> yNCVMpmIAYtPieZjXQGbACcWxiAU = new SafeAction<ControllerAssignmentChangedEventArgs>(rHkcLreWgtNjySHdxzqjtmRimFJvA._003C_003E9.pgiYrZJixlrACyzbTrvDQJLperKr);

			private SafeAction<ControllerAssignmentChangedEventArgs> MzUQstIUKjJRibiCYjozKKfYhgUiA = new SafeAction<ControllerAssignmentChangedEventArgs>(rHkcLreWgtNjySHdxzqjtmRimFJvA._003C_003E9.znhBOpzmCEDmIjlGEyFDLnwIWkzgA);

			private readonly dgIKCyledkyNeIFfbrDuVCBslLke YjBcjKBRZyLgPAULJtKNolmycTvt;

			private readonly Player YRfRQYlsuKTDHUiMKjGuDMclqkfAA;

			private readonly YTvdJthXdoAvuaeWVmMDxzYuGHkq zrnpQWstBtbKEfxuUPOVLlwnuddF;

			private readonly int XiAVSxWCRuFONouRLWQSZfiZbHPf;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap> SFAHkfrETxQOZFFlVqQxfxXoeRaK => (gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick);

			private global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<KeyboardMap> PiNZhsRUWlBfjdmkYBrEaNEVLfRQ => (global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<KeyboardMap>)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Keyboard).tLHWYncFxtGelWBkmFooasRaAXBz(0).LYmUAmbCzgGoTbembTlgBdvFhNexA;

			private global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<MouseMap> oQKkVKLcGwcDDRHfnhtQdXMVMQmeA => (global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<MouseMap>)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Mouse).tLHWYncFxtGelWBkmFooasRaAXBz(0).LYmUAmbCzgGoTbembTlgBdvFhNexA;

			private gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap> zTfcdvjNudcnrgUXuTdqeOnDGmtLb => (gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return false;
					}
					return GDdxgjfcPSYtRjQrUeQjHPapDEQp;
				}
				set
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						if (GDdxgjfcPSYtRjQrUeQjHPapDEQp == value)
						{
							return;
						}
						GDdxgjfcPSYtRjQrUeQjHPapDEQp = value;
						if (value)
						{
							zrnpQWstBtbKEfxuUPOVLlwnuddF.qevgkVDPuVaeixjpkpKzloScNZWQ(Mouse);
						}
						else
						{
							zrnpQWstBtbKEfxuUPOVLlwnuddF.XVEqIlUIOtfUtTWfTYpbORGLUmrF(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (yNCVMpmIAYtPieZjXQGbACcWxiAU.Count > 0)
							{
								yNCVMpmIAYtPieZjXQGbACcWxiAU.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (MzUQstIUKjJRibiCYjozKKfYhgUiA.Count > 0)
						{
							MzUQstIUKjJRibiCYjozKKfYhgUiA.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return false;
					}
					return gKUHCNRAqlPFJLIgQSiAOIcTrOO;
				}
				set
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						if (gKUHCNRAqlPFJLIgQSiAOIcTrOO == value)
						{
							return;
						}
						gKUHCNRAqlPFJLIgQSiAOIcTrOO = value;
						if (value)
						{
							zrnpQWstBtbKEfxuUPOVLlwnuddF.qevgkVDPuVaeixjpkpKzloScNZWQ(Keyboard);
						}
						else
						{
							zrnpQWstBtbKEfxuUPOVLlwnuddF.XVEqIlUIOtfUtTWfTYpbORGLUmrF(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (yNCVMpmIAYtPieZjXQGbACcWxiAU.Count > 0)
							{
								yNCVMpmIAYtPieZjXQGbACcWxiAU.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (MzUQstIUKjJRibiCYjozKKfYhgUiA.Count > 0)
						{
							MzUQstIUKjJRibiCYjozKKfYhgUiA.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return false;
					}
					return UjTKuxjwQXJWHnLVGeCHGNiyEPvf;
				}
				set
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						UjTKuxjwQXJWHnLVGeCHGNiyEPvf = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return 0;
					}
					return pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick).kVgCrHansgVHQdOwmDKoORLmXnGv;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick) as gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>).MvqWdXawFeajMsaqNWoPtaauNvng;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return 0;
					}
					return pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom).kVgCrHansgVHQdOwmDKoORLmXnGv;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom) as gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>).MvqWdXawFeajMsaqNWoPtaauNvng;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				[IteratorStateMachine(typeof(fDzZQftgQDPDiXghGyIOkClghyGP))]
				get
				{
					return new fDzZQftgQDPDiXghGyIOkClghyGP(-2)
					{
						CKHgmekrXePkWjJhGcIcmAZsSxPoc = this
					};
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					yNCVMpmIAYtPieZjXQGbACcWxiAU.AddDelegate(value);
				}
				remove
				{
					yNCVMpmIAYtPieZjXQGbACcWxiAU.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					MzUQstIUKjJRibiCYjozKKfYhgUiA.AddDelegate(value);
				}
				remove
				{
					MzUQstIUKjJRibiCYjozKKfYhgUiA.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, FBvloJYAnsSEnqZpZgYHeIbOgKik P_1, ControllerMapLayoutManager.ZwEHsomBYpCwhUwueCrLPncgybEq P_2, ControllerMapEnabler.JmqjWaNbmLkTeEMjBbAurWsDFFCl P_3)
			{
				XiAVSxWCRuFONouRLWQSZfiZbHPf = ReInput.id;
				YRfRQYlsuKTDHUiMKjGuDMclqkfAA = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				pPDQdaRyZpmNuhNRmtdGwAjucCjC = new gRltVhNwrOhpOgLZSJcAURRChXEp(4);
				pPDQdaRyZpmNuhNRmtdGwAjucCjC.RKlWKWojrOdxIgssFeWecvfcoAKvB(0, ControllerType.Joystick, new gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>());
				pPDQdaRyZpmNuhNRmtdGwAjucCjC.RKlWKWojrOdxIgssFeWecvfcoAKvB(1, ControllerType.Keyboard, new gIJedRrdlfvGfpypDoGdkbLXCohk<Keyboard, KeyboardMap>());
				pPDQdaRyZpmNuhNRmtdGwAjucCjC.RKlWKWojrOdxIgssFeWecvfcoAKvB(2, ControllerType.Mouse, new gIJedRrdlfvGfpypDoGdkbLXCohk<Mouse, MouseMap>());
				pPDQdaRyZpmNuhNRmtdGwAjucCjC.RKlWKWojrOdxIgssFeWecvfcoAKvB(3, ControllerType.Custom, new gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>());
				YjBcjKBRZyLgPAULJtKNolmycTvt = new dgIKCyledkyNeIFfbrDuVCBslLke(P_0);
				zrnpQWstBtbKEfxuUPOVLlwnuddF = new YTvdJthXdoAvuaeWVmMDxzYuGHkq(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				return (T)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(nwsTruCLxjorysrNysDvPYrmMcrb.dfvDLWAKHiMABTZxNGqFIaJKWcthA<T>()).qQYlezDDREZgCHEPytzgINVOkfXk(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				return pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType).qQYlezDDREZgCHEPytzgINVOkfXk(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				return (T)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(nwsTruCLxjorysrNysDvPYrmMcrb.dfvDLWAKHiMABTZxNGqFIaJKWcthA<T>()).nLHkDUZclLIHCaoFvermawROQHjJ(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				return pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(controllerType).nLHkDUZclLIHCaoFvermawROQHjJ(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					OIuWbVezyvMuddnlQChHygoQCcsB(controllerId, removeFromOtherPlayers);
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
					lRbeJCrRkLIqEyrmwAuljhxObJVA(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						kHPLUaPgAFSVVTIfZbsAfukHtven(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						lzlUhqMkgvSdKtQXViQghcMPojmX(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					kHPLUaPgAFSVVTIfZbsAfukHtven(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
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
					lzlUhqMkgvSdKtQXViQghcMPojmX(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					wBeLchZyIvqHFDJZkfxmhewsQZzlA(controllerId);
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
					URbIuOcJTULugLoMbbQYBdczVXoE(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					wBeLchZyIvqHFDJZkfxmhewsQZzlA(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					URbIuOcJTULugLoMbbQYBdczVXoE(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						LzezTvgERKIGTzMMzYAetGwELbBP(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						xQTPLqEGtCryUaBiQWsOAYOkOOmL(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return gKUHCNRAqlPFJLIgQSiAOIcTrOO;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return GDdxgjfcPSYtRjQrUeQjHPapDEQp;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick).DSdoBNNkTAayMeNbzQdZDhkYfJTT(controllerId), 
					ControllerType.Keyboard => gKUHCNRAqlPFJLIgQSiAOIcTrOO, 
					ControllerType.Mouse => GDdxgjfcPSYtRjQrUeQjHPapDEQp, 
					ControllerType.Custom => pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom).DSdoBNNkTAayMeNbzQdZDhkYfJTT(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
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
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					AoaFWrEQDnNxGTefdeSBJIZNCaHMA();
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
					pasTczUiaHLgTkJlBBJufsomqYrZA();
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
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					AoaFWrEQDnNxGTefdeSBJIZNCaHMA();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					pasTczUiaHLgTkJlBBJufsomqYrZA();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return;
				}
				AoaFWrEQDnNxGTefdeSBJIZNCaHMA();
				pasTczUiaHLgTkJlBBJufsomqYrZA();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				ycdnOwSndjJrWknRUjHSOzkMsQWl(ControllerType.Joystick, ref result, ref num);
				if (GDdxgjfcPSYtRjQrUeQjHPapDEQp && zvUvqiTPhuTfkqGuablCXJviHBEx > num)
				{
					result = Mouse;
					num = zvUvqiTPhuTfkqGuablCXJviHBEx;
				}
				if (gKUHCNRAqlPFJLIgQSiAOIcTrOO && nKZgdImsxWtlkAUwPIoNHgQdbGSGA > num)
				{
					result = Keyboard;
					num = nKZgdImsxWtlkAUwPIoNHgQdbGSGA;
				}
				ycdnOwSndjJrWknRUjHSOzkMsQWl(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					ycdnOwSndjJrWknRUjHSOzkMsQWl(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (gKUHCNRAqlPFJLIgQSiAOIcTrOO && nKZgdImsxWtlkAUwPIoNHgQdbGSGA > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (GDdxgjfcPSYtRjQrUeQjHPapDEQp && zvUvqiTPhuTfkqGuablCXJviHBEx > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void ycdnOwSndjJrWknRUjHSOzkMsQWl(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
				int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv;
				for (int i = 0; i < num; i++)
				{
					double num2 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).JqthFYGXJWQNUhgYzeDjzhUuOiek;
					if (!(num2 <= P_2))
					{
						P_1 = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(i).SCIEAWsfXbkuiCOHobGqAdbARGfbA;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(nwsTruCLxjorysrNysDvPYrmMcrb.dfvDLWAKHiMABTZxNGqFIaJKWcthA<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						YRfRQYlsuKTDHUiMKjGuDMclqkfAA.KwoqKDZYKDbbxTNWppgajTwqRqyj.BrOiqvyGyKjhnWZmTAAcAqIVEJXb(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						YRfRQYlsuKTDHUiMKjGuDMclqkfAA.KwoqKDZYKDbbxTNWppgajTwqRqyj.wKtOmwFQxSdGcDdOGAhCiAAsasPi(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						YRfRQYlsuKTDHUiMKjGuDMclqkfAA.KwoqKDZYKDbbxTNWppgajTwqRqyj.MFRIiiUwBqJseQyEacdlKPWnyUoT(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						YRfRQYlsuKTDHUiMKjGuDMclqkfAA.KwoqKDZYKDbbxTNWppgajTwqRqyj.EqSxISdReDBnmRFMTTkouHOYJtKK(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
					{
						ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					}
					else
					{
						YRfRQYlsuKTDHUiMKjGuDMclqkfAA.KwoqKDZYKDbbxTNWppgajTwqRqyj.FeTCZPXIyIlZgenBOpYHdiuCygLi(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				int zKrhkjardydsdIOgpYiwrSsGSvBf = pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
				for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
				{
					Controller controller = wIBUJjSjVBZhWmoZBurvfBLujMLi(pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i).TPIQqyGTASNUJuhnOYleKvROifiv, Controller.CldhkNCkjGevYQnznnzdOruwoLwfA, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return null;
				}
				int zKrhkjardydsdIOgpYiwrSsGSvBf = pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf;
				for (int i = 0; i < zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
				{
					Controller controller = wIBUJjSjVBZhWmoZBurvfBLujMLi(pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i).TPIQqyGTASNUJuhnOYleKvROifiv, Controller.vfxisWBzPytHQHawYsXJOealniZIb, templateType);
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
				if (ReInput._id != XiAVSxWCRuFONouRLWQSZfiZbHPf)
				{
					ReInput.CheckInitialized(XiAVSxWCRuFONouRLWQSZfiZbHPf);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return zrnpQWstBtbKEfxuUPOVLlwnuddF.IgIylPTTuRBEtTXkGHmhoOzerfFQ<TInterface>();
			}

			private Controller wIBUJjSjVBZhWmoZBurvfBLujMLi<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
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
					if (gKUHCNRAqlPFJLIgQSiAOIcTrOO && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (GDdxgjfcPSYtRjQrUeQjHPapDEQp && P_1(Mouse, P_2))
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

			internal void VYXZtmOJZxEYSXQZHqXXVczxfLXo()
			{
				for (int i = 0; i < pPDQdaRyZpmNuhNRmtdGwAjucCjC.zKrhkjardydsdIOgpYiwrSsGSvBf; i++)
				{
					pPDQdaRyZpmNuhNRmtdGwAjucCjC.tbVNuTxMhLaKLUfmQkxRFJdRuRWn(i).ngoVuNjwmJsyRYmSIkpBkyTZCVPj();
				}
				pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Keyboard).FyBLmrCvsgFqDUgqwtrShNoWgkoT(new gIJedRrdlfvGfpypDoGdkbLXCohk<Keyboard, KeyboardMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ(ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.WbGyhovABrZvNbHXBQtDZzjtIeFm, new global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<KeyboardMap>(0)));
				pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Mouse).FyBLmrCvsgFqDUgqwtrShNoWgkoT(new gIJedRrdlfvGfpypDoGdkbLXCohk<Mouse, MouseMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ(ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.MojdWfKBpNKzYvgrFqSyOknzCmgl, new global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<MouseMap>(0)));
				YjBcjKBRZyLgPAULJtKNolmycTvt.HPnMpFOmuzeEckbdmdppjeyIicDjc();
				nKZgdImsxWtlkAUwPIoNHgQdbGSGA = 0.0;
				zvUvqiTPhuTfkqGuablCXJviHBEx = 0.0;
				maps.QBFIOvrjnFXLABGPyERQbTCqTnfRA();
			}

			internal double xHZkqkwXGizDRXfssLfMEwlRRUOA(int P_0)
			{
				return YjBcjKBRZyLgPAULJtKNolmycTvt.AsxiJmiuEtKWeOJloRPztouBBjojA(P_0)?.hLilGvJNKDgCAHAsNisdEavDeytKB ?? (-1.0);
			}

			internal void kHPLUaPgAFSVVTIfZbsAfukHtven(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick);
				if (kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.DSdoBNNkTAayMeNbzQdZDhkYfJTT(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				dgIKCyledkyNeIFfbrDuVCBslLke.PILdMxjsHkBmDykRUqypsInnOUDKA pILdMxjsHkBmDykRUqypsInnOUDKA = YjBcjKBRZyLgPAULJtKNolmycTvt.AsxiJmiuEtKWeOJloRPztouBBjojA(P_0.id);
				gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ hiWJtllRqMdCqcwtrhSJVifgeTuZ;
				if (pILdMxjsHkBmDykRUqypsInnOUDKA != null && pILdMxjsHkBmDykRUqypsInnOUDKA.INAQEXZBaUMevJYlIZhmlocNQWUI != null)
				{
					hiWJtllRqMdCqcwtrhSJVifgeTuZ = new gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ(P_0, pILdMxjsHkBmDykRUqypsInnOUDKA.INAQEXZBaUMevJYlIZhmlocNQWUI);
				}
				else
				{
					global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap> ueUsBXRzKVLCQLMbRoTxcbDAhmUZ = maps.ApbBbqkbKqoKuUTfRshFDymDxfjrB(P_0, true);
					if (ueUsBXRzKVLCQLMbRoTxcbDAhmUZ == null)
					{
						ueUsBXRzKVLCQLMbRoTxcbDAhmUZ = new global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<JoystickMap>(P_0.id);
					}
					hiWJtllRqMdCqcwtrhSJVifgeTuZ = new gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ(P_0, ueUsBXRzKVLCQLMbRoTxcbDAhmUZ);
				}
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.FyBLmrCvsgFqDUgqwtrShNoWgkoT(hiWJtllRqMdCqcwtrhSJVifgeTuZ);
				YjBcjKBRZyLgPAULJtKNolmycTvt.FtBEPoXRBEsaNFaFHHVxkcykJPZk(hiWJtllRqMdCqcwtrhSJVifgeTuZ);
				zrnpQWstBtbKEfxuUPOVLlwnuddF.qevgkVDPuVaeixjpkpKzloScNZWQ(P_0);
				maps.layoutManager.Apply();
				if (yNCVMpmIAYtPieZjXQGbACcWxiAU.Count > 0)
				{
					yNCVMpmIAYtPieZjXQGbACcWxiAU.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void OIuWbVezyvMuddnlQChHygoQCcsB(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					kHPLUaPgAFSVVTIfZbsAfukHtven(joystick, P_1);
				}
			}

			internal void wBeLchZyIvqHFDJZkfxmhewsQZzlA(int P_0)
			{
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick);
				if (kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.DSdoBNNkTAayMeNbzQdZDhkYfJTT(P_0))
				{
					if (kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.tLHWYncFxtGelWBkmFooasRaAXBz(P_0) is gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ hiWJtllRqMdCqcwtrhSJVifgeTuZ)
					{
						YjBcjKBRZyLgPAULJtKNolmycTvt.FtBEPoXRBEsaNFaFHHVxkcykJPZk(hiWJtllRqMdCqcwtrhSJVifgeTuZ);
					}
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.siLcGpDBztVaiOujsFRwOGMosiDe(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					zrnpQWstBtbKEfxuUPOVLlwnuddF.XVEqIlUIOtfUtTWfTYpbORGLUmrF(joystick);
					if (MzUQstIUKjJRibiCYjozKKfYhgUiA.Count > 0)
					{
						MzUQstIUKjJRibiCYjozKKfYhgUiA.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void LzezTvgERKIGTzMMzYAetGwELbBP(Joystick P_0)
			{
				if (P_0 != null)
				{
					wBeLchZyIvqHFDJZkfxmhewsQZzlA(P_0.id);
				}
			}

			internal void AoaFWrEQDnNxGTefdeSBJIZNCaHMA()
			{
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Joystick);
				for (int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv - 1; num >= 0; num--)
				{
					YjBcjKBRZyLgPAULJtKNolmycTvt.FtBEPoXRBEsaNFaFHHVxkcykJPZk(kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num) as gIJedRrdlfvGfpypDoGdkbLXCohk<Joystick, JoystickMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ);
					zrnpQWstBtbKEfxuUPOVLlwnuddF.XVEqIlUIOtfUtTWfTYpbORGLUmrF(kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA);
					int id = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA.id;
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LQbMjStSslnckQnXaloDiXXXoihS(num);
					if (MzUQstIUKjJRibiCYjozKKfYhgUiA.Count > 0)
					{
						MzUQstIUKjJRibiCYjozKKfYhgUiA.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, id, ControllerType.Joystick, false));
					}
				}
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.ngoVuNjwmJsyRYmSIkpBkyTZCVPj();
			}

			internal void lzlUhqMkgvSdKtQXViQghcMPojmX(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom);
				if (!kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.DSdoBNNkTAayMeNbzQdZDhkYfJTT(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<CustomControllerMap> ueUsBXRzKVLCQLMbRoTxcbDAhmUZ = maps.lZIwYdEIvgogPNwcjWrKMLBADbqZ(P_0, true);
					if (ueUsBXRzKVLCQLMbRoTxcbDAhmUZ == null)
					{
						ueUsBXRzKVLCQLMbRoTxcbDAhmUZ = new global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<CustomControllerMap>(P_0.id);
					}
					gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ hiWJtllRqMdCqcwtrhSJVifgeTuZ = new gIJedRrdlfvGfpypDoGdkbLXCohk<CustomController, CustomControllerMap>.hiWJtllRqMdCqcwtrhSJVifgeTuZ(P_0, ueUsBXRzKVLCQLMbRoTxcbDAhmUZ);
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.FyBLmrCvsgFqDUgqwtrShNoWgkoT(hiWJtllRqMdCqcwtrhSJVifgeTuZ);
					zrnpQWstBtbKEfxuUPOVLlwnuddF.qevgkVDPuVaeixjpkpKzloScNZWQ(P_0);
					maps.layoutManager.Apply();
					if (yNCVMpmIAYtPieZjXQGbACcWxiAU.Count > 0)
					{
						yNCVMpmIAYtPieZjXQGbACcWxiAU.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void lRbeJCrRkLIqEyrmwAuljhxObJVA(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					lzlUhqMkgvSdKtQXViQghcMPojmX(customController, P_1);
				}
			}

			internal void URbIuOcJTULugLoMbbQYBdczVXoE(int P_0)
			{
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom);
				if (kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.DSdoBNNkTAayMeNbzQdZDhkYfJTT(P_0))
				{
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.tLHWYncFxtGelWBkmFooasRaAXBz(P_0);
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.siLcGpDBztVaiOujsFRwOGMosiDe(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					zrnpQWstBtbKEfxuUPOVLlwnuddF.XVEqIlUIOtfUtTWfTYpbORGLUmrF(customController);
					if (MzUQstIUKjJRibiCYjozKKfYhgUiA.Count > 0)
					{
						MzUQstIUKjJRibiCYjozKKfYhgUiA.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void xQTPLqEGtCryUaBiQWsOAYOkOOmL(CustomController P_0)
			{
				if (P_0 != null)
				{
					URbIuOcJTULugLoMbbQYBdczVXoE(P_0.id);
				}
			}

			internal void pasTczUiaHLgTkJlBBJufsomqYrZA()
			{
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU kQwkAQGpxfuwmZzSQKYSLJHpqSgU2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Custom);
				for (int num = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.kVgCrHansgVHQdOwmDKoORLmXnGv - 1; num >= 0; num--)
				{
					zrnpQWstBtbKEfxuUPOVLlwnuddF.XVEqIlUIOtfUtTWfTYpbORGLUmrF(kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA);
					int id = kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LiHJOfWLuRlIpTeFwKoewXdglkyu(num).SCIEAWsfXbkuiCOHobGqAdbARGfbA.id;
					kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.LQbMjStSslnckQnXaloDiXXXoihS(num);
					if (MzUQstIUKjJRibiCYjozKKfYhgUiA.Count > 0)
					{
						MzUQstIUKjJRibiCYjozKKfYhgUiA.Invoke(new ControllerAssignmentChangedEventArgs(YRfRQYlsuKTDHUiMKjGuDMclqkfAA.id, id, ControllerType.Custom, false));
					}
				}
				kQwkAQGpxfuwmZzSQKYSLJHpqSgU2.ngoVuNjwmJsyRYmSIkpBkyTZCVPj();
			}

			internal CustomController rnhUcOaCxYNpUoUBuFFBUKNVtpON(int P_0)
			{
				CustomController customController = YRfRQYlsuKTDHUiMKjGuDMclqkfAA.KwoqKDZYKDbbxTNWppgajTwqRqyj.NLzlMtxpmeUuvzoGWKnjaIzBvDLD(P_0);
				if (customController == null)
				{
					return null;
				}
				lzlUhqMkgvSdKtQXViQghcMPojmX(customController, false);
				return customController;
			}

			internal void ixzXWswlmXttFeghQHkgbzqpdItI(Action<bool, int, int> P_0)
			{
				URaZqzxcGRCcvaULqjPaTPaSBsNR<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void ZjZqckTJJWCjMbHENznRqXwlBUGsA(Keyboard P_0, tdFhvYnMcljrBbWwTZbXrjFZQZDt P_1, Action<bool, int, int> P_2)
			{
				if (!gKUHCNRAqlPFJLIgQSiAOIcTrOO || !P_0.enabled)
				{
					return;
				}
				SBynEInnXScqeNSQWonpGhTGfeBk wzoQHPqALdrNTnDRAKRUbKCeEzAm = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.WzoQHPqALdrNTnDRAKRUbKCeEzAm;
				bool flag = false;
				yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Keyboard).tLHWYncFxtGelWBkmFooasRaAXBz(0).LYmUAmbCzgGoTbembTlgBdvFhNexA;
				int num = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				tdFhvYnMcljrBbWwTZbXrjFZQZDt.YVTedMIxFqWaUWhaGKNojIWgEYqLA yVTedMIxFqWaUWhaGKNojIWgEYqLA = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? tdFhvYnMcljrBbWwTZbXrjFZQZDt.YVTedMIxFqWaUWhaGKNojIWgEYqLA.OverlapModifiers : tdFhvYnMcljrBbWwTZbXrjFZQZDt.YVTedMIxFqWaUWhaGKNojIWgEYqLA.Normal);
				LmbZyiZanDTITkLTIvRrQkCQStTE.dSdTKXzdENEWRSzPVakhhpAkhxqd dSdTKXzdENEWRSzPVakhhpAkhxqd = new LmbZyiZanDTITkLTIvRrQkCQStTE.dSdTKXzdENEWRSzPVakhhpAkhxqd
				{
					NxgOmvPpJKbZWTyuwLljHSiKSAVp = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.QzzwgmKQPAOvkCxEzGFvpXQEKzfn;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
						bool flag3 = false;
						bool flag4 = false;
						ButtonStateFlags buttonStateFlags;
						bool flag5;
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							buttonStateFlags = (P_0.iOdavyvglsRJMSaQiqNVvnWyeinW(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag5)
							{
								LmbZyiZanDTITkLTIvRrQkCQStTE lmbZyiZanDTITkLTIvRrQkCQStTE = LmbZyiZanDTITkLTIvRrQkCQStTE.kuiFofPMNSBCeimWMzARbIPboSrx(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA);
								if (lmbZyiZanDTITkLTIvRrQkCQStTE != null && lmbZyiZanDTITkLTIvRrQkCQStTE.ktBEPUHkcSRpUmxYaVcImmYXEIrb(true) != ButtonStateFlags.Off)
								{
									flag5 = true;
								}
							}
						}
						else
						{
							buttonStateFlags = P_0.cftCGKJlmpllERfsqWsBolAIXTuz(actionElementMap.xrZnVueTRmSKYHvJBgyRGORsqtGX);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag5)
						{
							if (!flag2)
							{
								flag3 = P_1.VJEonvPzQjDBvpUMzdIvQpoKYcKM(keyboardKeyCode, modifierKeyFlags, yVTedMIxFqWaUWhaGKNojIWgEYqLA, out flag4);
							}
							if (flag4 || modifierKeyFlags != ModifierKeyFlags.None)
							{
								dSdTKXzdENEWRSzPVakhhpAkhxqd.KCsvGRHbJTEhzXDIhcNwvApOjOff = flag3;
								LmbZyiZanDTITkLTIvRrQkCQStTE lmbZyiZanDTITkLTIvRrQkCQStTE = LmbZyiZanDTITkLTIvRrQkCQStTE.MGgmfOQoelfGRCJFFnkrUlmxyPEI(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, dSdTKXzdENEWRSzPVakhhpAkhxqd);
								if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
								{
									lmbZyiZanDTITkLTIvRrQkCQStTE.baiqmtnJZuucePgsbULscEmsutFM = flag3;
								}
								else if (flag3)
								{
									lmbZyiZanDTITkLTIvRrQkCQStTE.baiqmtnJZuucePgsbULscEmsutFM = true;
								}
								lmbZyiZanDTITkLTIvRrQkCQStTE.UTmaJkgcZCxZvoGDLjQQoiyPdShtA(ReInput.currentUpdateLoop, buttonStateFlags, true);
								buttonStateFlags = lmbZyiZanDTITkLTIvRrQkCQStTE.ktBEPUHkcSRpUmxYaVcImmYXEIrb(true);
							}
						}
						if (buttonStateFlags != ButtonStateFlags.Off)
						{
							SbWBZFHPSJAIVcylrdNuHXZmmNjWA(P_0, keyboardMap, actionElementMap, wzoQHPqALdrNTnDRAKRUbKCeEzAm, buttonStateFlags);
							P_2(arg1: true, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId);
							flag = true;
							continue;
						}
						if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.bagAqlYtnSflQzGpDUIhgVoooDIR != 0f)
						{
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.bagAqlYtnSflQzGpDUIhgVoooDIR = 0f;
						}
						if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.bxgFgasoEVAOdEQsklgrrpiWHdaQ != ButtonStateFlags.Off)
						{
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.bxgFgasoEVAOdEQsklgrrpiWHdaQ = ButtonStateFlags.Off;
						}
						P_2(arg1: false, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId);
					}
				}
				if (flag)
				{
					nKZgdImsxWtlkAUwPIoNHgQdbGSGA = ReInput.unscaledTime;
				}
			}

			private static void SbWBZFHPSJAIVcylrdNuHXZmmNjWA(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, SBynEInnXScqeNSQWonpGhTGfeBk P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.bagAqlYtnSflQzGpDUIhgVoooDIR = num;
				P_3.bxgFgasoEVAOdEQsklgrrpiWHdaQ = P_4;
				P_3.chyrEYodbtByMAAFRPqZnIctXjMO = P_0;
				P_3.WHtPHmJblqajKWmcjvvBYptPdSvr = ControllerType.Keyboard;
				P_3.kPzXJEmuOwTLGtDloOuuNdwcXoGF = ControllerElementType.Button;
				P_3.wpVbfiWDJOuSBXmONaxpfrriHZacA = P_2;
				P_3.hsUebZeSaYvmGSANsCjFDCtRaqZGA = P_1;
				if (P_3.ouAefOGjafBHSkdAvRoktlQQoWKm)
				{
					P_3.ouAefOGjafBHSkdAvRoktlQQoWKm = false;
				}
				if (P_3.OzDyKmiBDUgBdHMszLfPGMpPdpQf)
				{
					P_3.OzDyKmiBDUgBdHMszLfPGMpPdpQf = false;
				}
			}

			internal void PRHHNIprLhiABFXDKZlPRlYOFjDI(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!GDdxgjfcPSYtRjQrUeQjHPapDEQp || !P_0.enabled)
				{
					return;
				}
				yiZTVAYmYqfnMStnvrnpZDWxfexCA yiZTVAYmYqfnMStnvrnpZDWxfexCA2 = pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(ControllerType.Mouse).tLHWYncFxtGelWBkmFooasRaAXBz(0).LYmUAmbCzgGoTbembTlgBdvFhNexA;
				SBynEInnXScqeNSQWonpGhTGfeBk wzoQHPqALdrNTnDRAKRUbKCeEzAm = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.WzoQHPqALdrNTnDRAKRUbKCeEzAm;
				bool flag = false;
				int num = yiZTVAYmYqfnMStnvrnpZDWxfexCA2.dOLVGySRSIHymrnVvPaFOKsKLzWn;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)yiZTVAYmYqfnMStnvrnpZDWxfexCA2.rHRhNEMuWsAQVzLpRyfMzJvcfbxU(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.aXVuCzREgytjInHGJBGAdDfTzxrQ;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.iSNbyrbruIlpsNkmACDWdwPAxUNOb(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.iSNbyrbruIlpsNkmACDWdwPAxUNOb(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId);
									continue;
								}
							}
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.bagAqlYtnSflQzGpDUIhgVoooDIR = num2;
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.chyrEYodbtByMAAFRPqZnIctXjMO = P_0;
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.WHtPHmJblqajKWmcjvvBYptPdSvr = ControllerType.Mouse;
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.kPzXJEmuOwTLGtDloOuuNdwcXoGF = ControllerElementType.Axis;
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.wpVbfiWDJOuSBXmONaxpfrriHZacA = actionElementMap;
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.hsUebZeSaYvmGSANsCjFDCtRaqZGA = mouseMap;
							if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf)
							{
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf = false;
							}
							if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.cVsTVnIXpDfhbsmMuNoBCjMBUgJg != AxisCoordinateMode.Relative)
							{
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.cVsTVnIXpDfhbsmMuNoBCjMBUgJg = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.QzzwgmKQPAOvkCxEzGFvpXQEKzfn;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.WLGHtVFmzwndbXVJgbeTrXDgZPEK(actionElementMap2, actionId2, out var bagAqlYtnSflQzGpDUIhgVoooDIR, out wzoQHPqALdrNTnDRAKRUbKCeEzAm.ouAefOGjafBHSkdAvRoktlQQoWKm))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.cftCGKJlmpllERfsqWsBolAIXTuz(actionElementMap2.xrZnVueTRmSKYHvJBgyRGORsqtGX);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId2);
							continue;
						}
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.bagAqlYtnSflQzGpDUIhgVoooDIR = bagAqlYtnSflQzGpDUIhgVoooDIR;
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.bxgFgasoEVAOdEQsklgrrpiWHdaQ = buttonStateFlags;
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.chyrEYodbtByMAAFRPqZnIctXjMO = P_0;
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.WHtPHmJblqajKWmcjvvBYptPdSvr = ControllerType.Mouse;
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.kPzXJEmuOwTLGtDloOuuNdwcXoGF = ControllerElementType.Button;
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.wpVbfiWDJOuSBXmONaxpfrriHZacA = actionElementMap2;
						wzoQHPqALdrNTnDRAKRUbKCeEzAm.hsUebZeSaYvmGSANsCjFDCtRaqZGA = mouseMap;
						if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.ouAefOGjafBHSkdAvRoktlQQoWKm)
						{
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.ouAefOGjafBHSkdAvRoktlQQoWKm = false;
						}
						if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf)
						{
							wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf = false;
						}
						P_1(arg1: true, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					zvUvqiTPhuTfkqGuablCXJviHBEx = ReInput.unscaledTime;
				}
			}

			internal void LDHiTKPPbwFQICLIWIxaaqXPuTPdA(Action<bool, int, int> P_0)
			{
				URaZqzxcGRCcvaULqjPaTPaSBsNR<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void URaZqzxcGRCcvaULqjPaTPaSBsNR<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				gIJedRrdlfvGfpypDoGdkbLXCohk<_0001, _0002> gIJedRrdlfvGfpypDoGdkbLXCohk2 = (gIJedRrdlfvGfpypDoGdkbLXCohk<_0001, _0002>)pPDQdaRyZpmNuhNRmtdGwAjucCjC.fZqgDhJnxUCwMbBEGSSggqrznMWcc(P_0);
				SBynEInnXScqeNSQWonpGhTGfeBk wzoQHPqALdrNTnDRAKRUbKCeEzAm = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.WzoQHPqALdrNTnDRAKRUbKCeEzAm;
				int num = gIJedRrdlfvGfpypDoGdkbLXCohk2.YmSeLrtRLFpSMgEaKXjHdYhoBnBv();
				for (int i = 0; i < num; i++)
				{
					gIJedRrdlfvGfpypDoGdkbLXCohk<_0001, _0002>.hiWJtllRqMdCqcwtrhSJVifgeTuZ hiWJtllRqMdCqcwtrhSJVifgeTuZ = gIJedRrdlfvGfpypDoGdkbLXCohk2.zvMbuwhKhiBzRkZRDFUkocyNifGI(i);
					_0001 ceCCWHxtgtrfLYpuZqBgEmzIGJGG = hiWJtllRqMdCqcwtrhSJVifgeTuZ.CeCCWHxtgtrfLYpuZqBgEmzIGJGG;
					if (!ceCCWHxtgtrfLYpuZqBgEmzIGJGG.enabled)
					{
						continue;
					}
					global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0002> zfxPjujFGUgoCbyzcaKfutLOglBy = hiWJtllRqMdCqcwtrhSJVifgeTuZ.ZfxPjujFGUgoCbyzcaKfutLOglBy;
					bool flag = false;
					int num2 = zfxPjujFGUgoCbyzcaKfutLOglBy.PHddzgndMnzRWWZdLPxBNVqdUdeV();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = zfxPjujFGUgoCbyzcaKfutLOglBy.SypULfmhiRJaajsxCpMqFoMTkKpm(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.aXVuCzREgytjInHGJBGAdDfTzxrQ;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!ceCCWHxtgtrfLYpuZqBgEmzIGJGG.iSNbyrbruIlpsNkmACDWdwPAxUNOb(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									ceCCWHxtgtrfLYpuZqBgEmzIGJGG.iSNbyrbruIlpsNkmACDWdwPAxUNOb(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId);
										continue;
									}
								}
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.bagAqlYtnSflQzGpDUIhgVoooDIR = num3;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.chyrEYodbtByMAAFRPqZnIctXjMO = ceCCWHxtgtrfLYpuZqBgEmzIGJGG;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.WHtPHmJblqajKWmcjvvBYptPdSvr = P_0;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.kPzXJEmuOwTLGtDloOuuNdwcXoGF = ControllerElementType.Axis;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.wpVbfiWDJOuSBXmONaxpfrriHZacA = actionElementMap;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.hsUebZeSaYvmGSANsCjFDCtRaqZGA = val;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf = ceCCWHxtgtrfLYpuZqBgEmzIGJGG.calibrationMap.Axes[actionElementMap.xrZnVueTRmSKYHvJBgyRGORsqtGX].applyRangeCalibration;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.cVsTVnIXpDfhbsmMuNoBCjMBUgJg = ceCCWHxtgtrfLYpuZqBgEmzIGJGG.Axes[actionElementMap.elementIndex].ebyrXyRCdWERLtGljixMusqSBzocA?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.QzzwgmKQPAOvkCxEzGFvpXQEKzfn;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float bagAqlYtnSflQzGpDUIhgVoooDIR = 0f;
								int xrZnVueTRmSKYHvJBgyRGORsqtGX = actionElementMap2.xrZnVueTRmSKYHvJBgyRGORsqtGX;
								if (!mcMCICKxAtrtjLQwXAXwpzyTHmaE(ceCCWHxtgtrfLYpuZqBgEmzIGJGG, i, xrZnVueTRmSKYHvJBgyRGORsqtGX, actionElementMap2, zfxPjujFGUgoCbyzcaKfutLOglBy, actionId2, ref bagAqlYtnSflQzGpDUIhgVoooDIR) && !ceCCWHxtgtrfLYpuZqBgEmzIGJGG.WLGHtVFmzwndbXVJgbeTrXDgZPEK(actionElementMap2, actionId2, out bagAqlYtnSflQzGpDUIhgVoooDIR, out wzoQHPqALdrNTnDRAKRUbKCeEzAm.ouAefOGjafBHSkdAvRoktlQQoWKm))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = ceCCWHxtgtrfLYpuZqBgEmzIGJGG.cftCGKJlmpllERfsqWsBolAIXTuz(actionElementMap2.xrZnVueTRmSKYHvJBgyRGORsqtGX);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId2);
									continue;
								}
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.bagAqlYtnSflQzGpDUIhgVoooDIR = bagAqlYtnSflQzGpDUIhgVoooDIR;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.bxgFgasoEVAOdEQsklgrrpiWHdaQ = buttonStateFlags;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.chyrEYodbtByMAAFRPqZnIctXjMO = ceCCWHxtgtrfLYpuZqBgEmzIGJGG;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.WHtPHmJblqajKWmcjvvBYptPdSvr = P_0;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.kPzXJEmuOwTLGtDloOuuNdwcXoGF = ControllerElementType.Button;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.wpVbfiWDJOuSBXmONaxpfrriHZacA = actionElementMap2;
								wzoQHPqALdrNTnDRAKRUbKCeEzAm.hsUebZeSaYvmGSANsCjFDCtRaqZGA = val;
								if (wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf)
								{
									wzoQHPqALdrNTnDRAKRUbKCeEzAm.OzDyKmiBDUgBdHMszLfPGMpPdpQf = false;
								}
								P_1(arg1: true, YRfRQYlsuKTDHUiMKjGuDMclqkfAA.jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							hiWJtllRqMdCqcwtrhSJVifgeTuZ.bhVoIEFYkcEzsKTgvwTVIRcyoBzK();
						}
					}
				}
			}

			private bool mcMCICKxAtrtjLQwXAXwpzyTHmaE<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.zfVdfqKDuqZKjafBdqgdinjRQNeGb.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.zfVdfqKDuqZKjafBdqgdinjRQNeGb.GetUnknownHatButtons(P_2);
				if (UhxwWKKqbOxjexREZXRqxDDNVagl(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.oCcQScUEXrJhndBIOknbTkDOlquu(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool UhxwWKKqbOxjexREZXRqxDDNVagl<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (aKaRUtDAvTMwEyBAJpYAAuzCdFRD(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool aKaRUtDAvTMwEyBAJpYAAuzCdFRD<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::UeUsBXRzKVLCQLMbRoTxcbDAhmUZ<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.PHddzgndMnzRWWZdLPxBNVqdUdeV();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.SypULfmhiRJaajsxCpMqFoMTkKpm(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int xrZnVueTRmSKYHvJBgyRGORsqtGX = buttonMaps[j].xrZnVueTRmSKYHvJBgyRGORsqtGX;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(xrZnVueTRmSKYHvJBgyRGORsqtGX))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private const string rJCdjYjpvkFtNbeErGoMBUyNspPTA = "player";

		private readonly GCkLfqNtcKbVwGxJyqaDoIgNIHaV KwoqKDZYKDbbxTNWppgajTwqRqyj;

		private bool yibHdfZsehHWmDJisexIKrgBwjvhA;

		private int jPsZpqMAcPAnkudOsRQkwDRvcsej;

		private string RZoytfyhcUagrktgQlTRznMHDnAbA;

		private string mpVCHEgYPgHmJZxOzDjVroBHZCwl;

		private readonly string OTSuDabRuJLYKQYJYXprkUpHvTrF;

		private bool EwMMddzAgahigiVCdDUISuyeTsUR;

		private readonly int LKnxHKemQYCBgEEGJctGOOaXEvwwA;

		private readonly zepspERRxafWKJaGpLXDAMQMfvgE LPPxENVFdLqvQeTQWrBnSRmqHaSN;

		private int ExlPiaFNyrpqkaCsdzJFNVRmDrUq;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
					return -1;
				}
				return jPsZpqMAcPAnkudOsRQkwDRvcsej;
			}
			internal set
			{
				jPsZpqMAcPAnkudOsRQkwDRvcsej = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
					return string.Empty;
				}
				return RZoytfyhcUagrktgQlTRznMHDnAbA;
			}
			internal set
			{
				RZoytfyhcUagrktgQlTRznMHDnAbA = rZoytfyhcUagrktgQlTRznMHDnAbA;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return mpVCHEgYPgHmJZxOzDjVroBHZCwl;
				}
				return LPPxENVFdLqvQeTQWrBnSRmqHaSN.LoGZqdROKyuYHJXdnhuxPciDQjeL;
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
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
					return false;
				}
				return EwMMddzAgahigiVCdDUISuyeTsUR;
			}
			set
			{
				EwMMddzAgahigiVCdDUISuyeTsUR = value;
			}
		}

		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return mpVCHEgYPgHmJZxOzDjVroBHZCwl;
			}
			set
			{
				mpVCHEgYPgHmJZxOzDjVroBHZCwl = value;
				LPPxENVFdLqvQeTQWrBnSRmqHaSN.TebLFfuNscsSdmSSCRmDmNccAdoF();
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.keyCategory => "player";

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.scriptingName => RZoytfyhcUagrktgQlTRznMHDnAbA;

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.nonLocalizedDescriptiveName
		{
			get
			{
				return mpVCHEgYPgHmJZxOzDjVroBHZCwl;
			}
			set
			{
				mpVCHEgYPgHmJZxOzDjVroBHZCwl = value;
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.key => OTSuDabRuJLYKQYJYXprkUpHvTrF;

		int gDrCmzJNXwFvGTMAYKGQspUqeYD.autoGeneratedValueFlags
		{
			get
			{
				return ExlPiaFNyrpqkaCsdzJFNVRmDrUq;
			}
			set
			{
				ExlPiaFNyrpqkaCsdzJFNVRmDrUq = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, FBvloJYAnsSEnqZpZgYHeIbOgKik P_5, ControllerMapLayoutManager.ZwEHsomBYpCwhUwueCrLPncgybEq P_6, ControllerMapEnabler.JmqjWaNbmLkTeEMjBbAurWsDFFCl P_7)
		{
			yibHdfZsehHWmDJisexIKrgBwjvhA = P_0;
			jPsZpqMAcPAnkudOsRQkwDRvcsej = P_1;
			RZoytfyhcUagrktgQlTRznMHDnAbA = P_2;
			mpVCHEgYPgHmJZxOzDjVroBHZCwl = P_3;
			OTSuDabRuJLYKQYJYXprkUpHvTrF = P_4;
			LKnxHKemQYCBgEEGJctGOOaXEvwwA = ReInput.id;
			LPPxENVFdLqvQeTQWrBnSRmqHaSN = zepspERRxafWKJaGpLXDAMQMfvgE.HKzbZMduZchtOBhLaihmPtNUHVVO(this);
			controllers = new ControllerHelper(this, P_5, P_6, P_7);
			KwoqKDZYKDbbxTNWppgajTwqRqyj = ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq;
			TqrChPJvIXJDngZIbKFzbCeOnFSYb();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(jPsZpqMAcPAnkudOsRQkwDRvcsej));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.QjFgvPKGEeCadAwWpAOVbYVEwiocc() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.QjFgvPKGEeCadAwWpAOVbYVEwiocc() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.tkgMQvUaqSzRkgPvBglpNsGXRHuK() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.tkgMQvUaqSzRkgPvBglpNsGXRHuK() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.pQiccvFOkHaSfeEAGxAyBgsphfSic() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.pQiccvFOkHaSfeEAGxAyBgsphfSic() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.xBfyujgxwYPkKCzxfLPLJMmuQzPG() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.xBfyujgxwYPkKCzxfLPLJMmuQzPG() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.CppttvrfXZuypUSpWtnBEPhObOGp() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.CppttvrfXZuypUSpWtnBEPhObOGp() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.QwZBioUoWnclJYPKXrhzcsKZeMN() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.QwZBioUoWnclJYPKXrhzcsKZeMN() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.YIetwDuXfleVZXjOOGVpyoIZRdlg() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.YIetwDuXfleVZXjOOGVpyoIZRdlg() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.hDuEdSZIVodLmMgAcBClwJzyStxt(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.hDuEdSZIVodLmMgAcBClwJzyStxt(speed) ?? false;
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.wUCqyJpqbVGgXlUCgZmqnapuZFiL(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.wUCqyJpqbVGgXlUCgZmqnapuZFiL(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.MAsIOVeSXLcrzYnfXRltcrTDvsUAA(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.MAsIOVeSXLcrzYnfXRltcrTDvsUAA(speed) ?? false;
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.sOsQEzsgKiHXPzOVEBhITTUQrJSc(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.sOsQEzsgKiHXPzOVEBhITTUQrJSc(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.sOsQEzsgKiHXPzOVEBhITTUQrJSc(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.sOsQEzsgKiHXPzOVEBhITTUQrJSc(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.bIinHhvpUOIPAPGUJVspophPjzvH(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.bIinHhvpUOIPAPGUJVspophPjzvH(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.WIhbzSNjjwDnIIspHqtaHIgnUxqv(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.WIhbzSNjjwDnIIspHqtaHIgnUxqv(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.WIhbzSNjjwDnIIspHqtaHIgnUxqv(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.WIhbzSNjjwDnIIspHqtaHIgnUxqv(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.IjFBYreATrxTjLNbqySkhPrzZrjNA() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.IjFBYreATrxTjLNbqySkhPrzZrjNA() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.WPpvGUJVQDjdSfNgllfkKsCeAiPM() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.WPpvGUJVQDjdSfNgllfkKsCeAiPM() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.sRHHMiCACydmibRnOXTCQfEROLPI() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.sRHHMiCACydmibRnOXTCQfEROLPI() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.BTkggOefvqEUVCIxbmeoCMWRrttS() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.BTkggOefvqEUVCIxbmeoCMWRrttS() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.fVQgMTKMYhFErizSsNYktdPwEgAj() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.fVQgMTKMYhFErizSsNYktdPwEgAj() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.utjUHiKzTnssUhdvAnYCntvklNiU() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.utjUHiKzTnssUhdvAnYCntvklNiU() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.gEgAMcaSKCMofNvLoSPhPyGOeqnO() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.gEgAMcaSKCMofNvLoSPhPyGOeqnO() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.kjjRXcJVTQOmCmaRCMIrpUUnATRF(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.apXwMaSMmUJbNWqYzONWlCCXOrEh(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.fGbvvdpOKGpEgMvcHhBDwcTsyjsh(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.vYxysVnPasMQPcAEAbjVViPtzKHi(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.xRtzVootfuEQSObnZUkktWGzudHd() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.xRtzVootfuEQSObnZUkktWGzudHd() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.QFXCXYsEPPYOPXyjoFaESXVgAInI() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.QFXCXYsEPPYOPXyjoFaESXVgAInI() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.MZVcABaPnzwSAYScLIsjwTNwITCA() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.MZVcABaPnzwSAYScLIsjwTNwITCA() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.IlnDwsriqNmIJnrVMGHpsxuVmCDk() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.IlnDwsriqNmIJnrVMGHpsxuVmCDk() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.PkjAuEhiLFblGFpEoLUSgkwdAWMPc() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.PkjAuEhiLFblGFpEoLUSgkwdAWMPc() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.ahgIigrJpIhpTnxlRkyDggCAkbSe() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.ahgIigrJpIhpTnxlRkyDggCAkbSe() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.hMmBMCeSZmjRTcvFyylliQozOMsN() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.hMmBMCeSZmjRTcvFyylliQozOMsN() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.PVixsVWcKhmAyzCuiqalzruTETQV() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.PVixsVWcKhmAyzCuiqalzruTETQV() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.XGGeYmbOfRhTwqlTUNjJhyHmjBDTA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.XGGeYmbOfRhTwqlTUNjJhyHmjBDTA() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.APRUMcTqPXHnSsLFqUoHcEftujgM(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.APRUMcTqPXHnSsLFqUoHcEftujgM(speed) ?? false;
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.OeHFCiBFoMONSFkDxrjrhjfrdKyBb(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.OeHFCiBFoMONSFkDxrjrhjfrdKyBb(speed) ?? false;
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.kAUIGHIRmqgIhITYRXdfyDeKJHvGA(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.kAUIGHIRmqgIhITYRXdfyDeKJHvGA(speed) ?? false;
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.lzWSNJyuyDIVWfatOfBuxuMlyjQV(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.lzWSNJyuyDIVWfatOfBuxuMlyjQV(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.OjFDupAWRtqEHLCDApfpexwBEnJBb(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.OjFDupAWRtqEHLCDApfpexwBEnJBb(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.OjFDupAWRtqEHLCDApfpexwBEnJBb(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.OjFDupAWRtqEHLCDApfpexwBEnJBb(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.dXjwGMaeXYEoLItTeUrdPplGifLc() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.dXjwGMaeXYEoLItTeUrdPplGifLc() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.xGIVsgNZGAhBEPFOvKvKctfPctqN() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.xGIVsgNZGAhBEPFOvKvKctfPctqN() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.CirBXpYSwLpjktkuuieVfTCjxvsq() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.CirBXpYSwLpjktkuuieVfTCjxvsq() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.HkPSkWatznDEtFObKrhQofsAFDBy() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.HkPSkWatznDEtFObKrhQofsAFDBy() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.bnLTdeGiNoyyYqFMzrKaIlOcyqfD() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.bnLTdeGiNoyyYqFMzrKaIlOcyqfD() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.OAoJiIXLmaeobgaxEVYinJhHPJCFb() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.OAoJiIXLmaeobgaxEVYinJhHPJCFb() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.bVHaNgmFElRWmAMIPleLrwEkLgyI() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.bVHaNgmFElRWmAMIPleLrwEkLgyI() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.bUuxipqfwNcIpdmaZUPRncuFFWYfA(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.yGVCaoVSjNJNeGukeVPWxqbkGnQF(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.injsnuCXzBikmBaNcEcVBLvfImpRA(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.DGcdjNqELnAXkeiqvQJhfCqswOgjA(jPsZpqMAcPAnkudOsRQkwDRvcsej);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.xPiIAnbVqZPNUAWXLPBXtuczQHKS() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.xPiIAnbVqZPNUAWXLPBXtuczQHKS() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.TNbcLDUZTVlllUKOxakoDCFmaDtBA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.TNbcLDUZTVlllUKOxakoDCFmaDtBA() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.KnkutKftHwuYOokXdGbLzZTyJRsc() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.KnkutKftHwuYOokXdGbLzZTyJRsc() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.NfEoghEuLnJfqxUnwoWveanivKEy() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.NfEoghEuLnJfqxUnwoWveanivKEy() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.cXVwqwFLrwcAUZbciwKrYuIRvMfI() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.cXVwqwFLrwcAUZbciwKrYuIRvMfI() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.EGadHTOIaTgtghmXgjBjDCxfZOmzb() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.EGadHTOIaTgtghmXgjBjDCxfZOmzb() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.GYzBXZCNULNUAxGMBiEfwxfJKQoU() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.GYzBXZCNULNUAxGMBiEfwxfJKQoU() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.TdghQobrotBDkopEoLVTYJgouCgoA() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0f;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.TdghQobrotBDkopEoLVTYJgouCgoA() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.KnkutKftHwuYOokXdGbLzZTyJRsc();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.KnkutKftHwuYOokXdGbLzZTyJRsc();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.KnkutKftHwuYOokXdGbLzZTyJRsc();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.KnkutKftHwuYOokXdGbLzZTyJRsc();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.cXVwqwFLrwcAUZbciwKrYuIRvMfI();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.cXVwqwFLrwcAUZbciwKrYuIRvMfI();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.cXVwqwFLrwcAUZbciwKrYuIRvMfI();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.cXVwqwFLrwcAUZbciwKrYuIRvMfI();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.NfEoghEuLnJfqxUnwoWveanivKEy();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.NfEoghEuLnJfqxUnwoWveanivKEy();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.NfEoghEuLnJfqxUnwoWveanivKEy();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.NfEoghEuLnJfqxUnwoWveanivKEy();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.EGadHTOIaTgtghmXgjBjDCxfZOmzb();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionName, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.EGadHTOIaTgtghmXgjBjDCxfZOmzb();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, xAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.x = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.EGadHTOIaTgtghmXgjBjDCxfZOmzb();
			}
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, yAxisActionId, true);
			if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 != null)
			{
				result.y = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.EGadHTOIaTgtghmXgjBjDCxfZOmzb();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.XHMpxLAZsbwtHshVboUFPPUNrJPJ() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.XHMpxLAZsbwtHshVboUFPPUNrJPJ() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.DQQBWHuzXYkcrrQbJgJFMfvakGDD() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.DQQBWHuzXYkcrrQbJgJFMfvakGDD() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.SjxZOtsoDSNVsaaHoFqCGqdRPSnYA() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.SjxZOtsoDSNVsaaHoFqCGqdRPSnYA() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.tmZtXpTHwtcXbfYmOAiQWPwZJREI() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return 0.0;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.tmZtXpTHwtcXbfYmOAiQWPwZJREI() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.NOiGoaMiwHEZMfDSFCyCahPePLJWA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.NOiGoaMiwHEZMfDSFCyCahPePLJWA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.hCsYWozMXqlhFFjxTgkSfMRSGcmjb() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.hCsYWozMXqlhFFjxTgkSfMRSGcmjb() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.PqGEWjRRfsifPVfVxPOxhtJzyYQj() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.PqGEWjRRfsifPVfVxPOxhtJzyYQj() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.bllYlGUGQarspNvNsPkQMpRROjKU() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return AxisCoordinateMode.Absolute;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.bllYlGUGQarspNvNsPkQMpRROjKU() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.oYKlLZhmEjOVJzniVUEhpSMHDcNL();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.oYKlLZhmEjOVJzniVUEhpSMHDcNL();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.dGGDTxhsJsMSyBnPTtwkytBGfevn(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.dGGDTxhsJsMSyBnPTtwkytBGfevn(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.xjEfscgzlHvJWUMkQLOSoLtzLsOLA(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.xjEfscgzlHvJWUMkQLOSoLtzLsOLA(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.ypYyOaaWnlwKLoPcynBpNzdUHaJT(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionName, true)?.aFfeTPrJYcRssskAdiPKITNiDGkn(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return false;
			}
			return KwoqKDZYKDbbxTNWppgajTwqRqyj.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(jPsZpqMAcPAnkudOsRQkwDRvcsej, actionId, true)?.aFfeTPrJYcRssskAdiPKITNiDGkn(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.eTuovLeKSLolQuzzUMTgDzZfTMqh(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.CbeBrCoZbOcBDegIyYMNgAvuVxFd(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return;
			}
			int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
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
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.MEEBIiUEGlCnnTEOUzWQBbeBpjcg(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.HMVQbwmexMCysJKAAUKYvOzUXWPT(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return;
			}
			int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.QlTPMGVDJktyiUIpRiIlxdlZdFxT(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.SuhuIBJZHfAnUQzhQWhDAGeHfgOdA(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return;
			}
			int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.wTdzuNZKTYxMNWdmqEvzuFfGbUZr(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.xWSasEfsUHAzIsQcRNUqJxqoEgABA(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.LEzEXpVCfQeDJLqlajbRNUdmsfRN(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return;
			}
			int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.vvOTDpWQYOPdeUgDYMsdLMyaSBHr(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return;
			}
			int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.xnpFUWCCKdMgcGmXyFpvEBzkfIlrb(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.lskXvSnmRsYIDsOsWTSXuaKmbaNu(jPsZpqMAcPAnkudOsRQkwDRvcsej, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				return;
			}
			int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
				{
					ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
				}
				else
				{
					KwoqKDZYKDbbxTNWppgajTwqRqyj.RrfzlOIPKhLSsNAePlNYoahTHpCe(jPsZpqMAcPAnkudOsRQkwDRvcsej);
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
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
			if (ReInput._id != LKnxHKemQYCBgEEGJctGOOaXEvwwA)
			{
				ReInput.CheckInitialized(LKnxHKemQYCBgEEGJctGOOaXEvwwA);
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

		internal void pXqbfWjsigpcEpHFglyYyWtQQmVsA()
		{
			TqrChPJvIXJDngZIbKFzbCeOnFSYb();
		}

		private void TqrChPJvIXJDngZIbKFzbCeOnFSYb()
		{
			controllers.VYXZtmOJZxEYSXQZHqXXVczxfLXo();
			EwMMddzAgahigiVCdDUISuyeTsUR = false;
		}
	}
}
