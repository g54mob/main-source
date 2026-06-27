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
	public sealed class Player : leeNpeIpkRWAaDYnewmtyKpQcRpw
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class siQcFxPRSWBWLvucPROkBwUZUcuK : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int HfndvNBWHaxFdRyMYEPEIjlOZtufA;

					private ElementAssignmentConflictInfo wXZrblSLvJeXDbSijZShcFPSUhIC;

					private int rxEUaWVhATLxurqKnkfSpzvgiyRq;

					private int DNFLroGHvYbgsItIEttPJJOSRcNg;

					public int AfVaIDKdiyRTrOyrLVFcUczsJWGB;

					private CustomControllerMap TBaZvHembycuEzezQmqEfqsHNfXh;

					public CustomControllerMap nVVGpCFPKawVDcstIkxBkMpXmYrI;

					public ConflictCheckingHelper MBDJFQuZOQvkcuBuGGGpKDEvtqPG;

					private bool zgktPmFdVpQUybWGyBeEVRoJsWxT;

					public bool PRkqVoZfqVZGplLsimublbzNeUeG;

					private bool twSkUlGOrVuTNebaKIhcjFeVjeJY;

					public bool OLqibNGHtPJwIYDMowqENeAfRPJF;

					private int uCPFzlfrDPkqbgxQnlJECKIQmKSeA;

					private IEnumerator<ElementAssignmentConflictInfo> eBPlwOUMaWKQWujecLOsPPBWxYKc;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wXZrblSLvJeXDbSijZShcFPSUhIC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wXZrblSLvJeXDbSijZShcFPSUhIC;
						}
					}

					[DebuggerHidden]
					public siQcFxPRSWBWLvucPROkBwUZUcuK(int P_0)
					{
						HfndvNBWHaxFdRyMYEPEIjlOZtufA = P_0;
						rxEUaWVhATLxurqKnkfSpzvgiyRq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hfndvNBWHaxFdRyMYEPEIjlOZtufA = HfndvNBWHaxFdRyMYEPEIjlOZtufA;
						if (hfndvNBWHaxFdRyMYEPEIjlOZtufA == -3 || hfndvNBWHaxFdRyMYEPEIjlOZtufA == 1)
						{
							try
							{
							}
							finally
							{
								FWkQXHbncvloisVRKtSGXZFlUVwf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int hfndvNBWHaxFdRyMYEPEIjlOZtufA = HfndvNBWHaxFdRyMYEPEIjlOZtufA;
							ConflictCheckingHelper mBDJFQuZOQvkcuBuGGGpKDEvtqPG = MBDJFQuZOQvkcuBuGGGpKDEvtqPG;
							if (hfndvNBWHaxFdRyMYEPEIjlOZtufA != 0)
							{
								if (hfndvNBWHaxFdRyMYEPEIjlOZtufA != 1)
								{
									return false;
								}
								HfndvNBWHaxFdRyMYEPEIjlOZtufA = -3;
								goto IL_00eb;
							}
							HfndvNBWHaxFdRyMYEPEIjlOZtufA = -1;
							if (DNFLroGHvYbgsItIEttPJJOSRcNg < 0 || TBaZvHembycuEzezQmqEfqsHNfXh == null)
							{
								return false;
							}
							uCPFzlfrDPkqbgxQnlJECKIQmKSeA = 0;
							goto IL_0117;
							IL_00eb:
							if (eBPlwOUMaWKQWujecLOsPPBWxYKc.MoveNext())
							{
								ElementAssignmentConflictInfo current = eBPlwOUMaWKQWujecLOsPPBWxYKc.Current;
								wXZrblSLvJeXDbSijZShcFPSUhIC = current;
								HfndvNBWHaxFdRyMYEPEIjlOZtufA = 1;
								return true;
							}
							FWkQXHbncvloisVRKtSGXZFlUVwf();
							eBPlwOUMaWKQWujecLOsPPBWxYKc = null;
							goto IL_0105;
							IL_0117:
							if (uCPFzlfrDPkqbgxQnlJECKIQmKSeA < mBDJFQuZOQvkcuBuGGGpKDEvtqPG.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif())
							{
								if (mBDJFQuZOQvkcuBuGGGpKDEvtqPG.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(uCPFzlfrDPkqbgxQnlJECKIQmKSeA).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == DNFLroGHvYbgsItIEttPJJOSRcNg)
								{
									eBPlwOUMaWKQWujecLOsPPBWxYKc = mBDJFQuZOQvkcuBuGGGpKDEvtqPG.nlcRJgZGjVaeSwSCYnYLsAlXEtkHA(ControllerType.Custom, DNFLroGHvYbgsItIEttPJJOSRcNg, TBaZvHembycuEzezQmqEfqsHNfXh, zgktPmFdVpQUybWGyBeEVRoJsWxT, twSkUlGOrVuTNebaKIhcjFeVjeJY, mBDJFQuZOQvkcuBuGGGpKDEvtqPG.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(uCPFzlfrDPkqbgxQnlJECKIQmKSeA).AhOWBwQXlUjEXgrPOgQMKEMCgKcP).GetEnumerator();
									HfndvNBWHaxFdRyMYEPEIjlOZtufA = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							uCPFzlfrDPkqbgxQnlJECKIQmKSeA++;
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

					private void FWkQXHbncvloisVRKtSGXZFlUVwf()
					{
						HfndvNBWHaxFdRyMYEPEIjlOZtufA = -1;
						if (eBPlwOUMaWKQWujecLOsPPBWxYKc != null)
						{
							eBPlwOUMaWKQWujecLOsPPBWxYKc.Dispose();
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
						siQcFxPRSWBWLvucPROkBwUZUcuK siQcFxPRSWBWLvucPROkBwUZUcuK2;
						if (HfndvNBWHaxFdRyMYEPEIjlOZtufA == -2 && rxEUaWVhATLxurqKnkfSpzvgiyRq == Environment.CurrentManagedThreadId)
						{
							HfndvNBWHaxFdRyMYEPEIjlOZtufA = 0;
							siQcFxPRSWBWLvucPROkBwUZUcuK2 = this;
						}
						else
						{
							siQcFxPRSWBWLvucPROkBwUZUcuK2 = new siQcFxPRSWBWLvucPROkBwUZUcuK(0);
							siQcFxPRSWBWLvucPROkBwUZUcuK2.MBDJFQuZOQvkcuBuGGGpKDEvtqPG = MBDJFQuZOQvkcuBuGGGpKDEvtqPG;
						}
						siQcFxPRSWBWLvucPROkBwUZUcuK2.DNFLroGHvYbgsItIEttPJJOSRcNg = AfVaIDKdiyRTrOyrLVFcUczsJWGB;
						siQcFxPRSWBWLvucPROkBwUZUcuK2.TBaZvHembycuEzezQmqEfqsHNfXh = nVVGpCFPKawVDcstIkxBkMpXmYrI;
						siQcFxPRSWBWLvucPROkBwUZUcuK2.zgktPmFdVpQUybWGyBeEVRoJsWxT = PRkqVoZfqVZGplLsimublbzNeUeG;
						siQcFxPRSWBWLvucPROkBwUZUcuK2.twSkUlGOrVuTNebaKIhcjFeVjeJY = OLqibNGHtPJwIYDMowqENeAfRPJF;
						return siQcFxPRSWBWLvucPROkBwUZUcuK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ylrxbzNpbymQnTITLDLGKvcDIutdb : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int dYoDUesEHkabszWaQhpOjQoMYReuA;

					private ElementAssignmentConflictInfo uuJhzneBCSsXmXNgYLiTQScKMLtj;

					private int rqhqzCoeTqCNJTPmJpsvtBfrMkxH;

					private int sVZgSmJHmtQdcOUuKeuIzqMhFQquA;

					public int zHFUdSvmXqBkXEQSbLpDenmvsJrQ;

					private ActionElementMap pMqwyXVkRXQgWBIxVexuHpyGeNmoA;

					public ActionElementMap WxFukwwtMXNmMnVxHzRRDuLtbLJI;

					public ConflictCheckingHelper hWhzHmIjZGWnYAPADgjqKuWvDdMEA;

					private CustomControllerMap CVyDZcAgbwOKTNgqICsvFiSSGaVHA;

					public CustomControllerMap WAgSXDwARqKNsNQjVqMThhKmfjGh;

					private bool FHYAVoATJCYFRucIeyJOpolXqrjrA;

					public bool OpfnnONjpbpzwRSVPvDcbByakHTk;

					private bool ovCumbdQOWSUZIwkLwzuZEbIBEyX;

					public bool JVXEFydpWDLnieqfhPWGwIpyYbzLA;

					private int kxtiAGxOSmVtFxinyYQMTKyrfmcHA;

					private IEnumerator<ElementAssignmentConflictInfo> oGZcpSFGPPXUmsQkMuZYwVWGLHpe;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return uuJhzneBCSsXmXNgYLiTQScKMLtj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uuJhzneBCSsXmXNgYLiTQScKMLtj;
						}
					}

					[DebuggerHidden]
					public ylrxbzNpbymQnTITLDLGKvcDIutdb(int P_0)
					{
						dYoDUesEHkabszWaQhpOjQoMYReuA = P_0;
						rqhqzCoeTqCNJTPmJpsvtBfrMkxH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dYoDUesEHkabszWaQhpOjQoMYReuA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								QidfDlQYAnJuCXxlVjyiMCtUvdOh();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = dYoDUesEHkabszWaQhpOjQoMYReuA;
							ConflictCheckingHelper conflictCheckingHelper = hWhzHmIjZGWnYAPADgjqKuWvDdMEA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dYoDUesEHkabszWaQhpOjQoMYReuA = -3;
								goto IL_00f1;
							}
							dYoDUesEHkabszWaQhpOjQoMYReuA = -1;
							if (sVZgSmJHmtQdcOUuKeuIzqMhFQquA < 0 || pMqwyXVkRXQgWBIxVexuHpyGeNmoA == null)
							{
								return false;
							}
							kxtiAGxOSmVtFxinyYQMTKyrfmcHA = 0;
							goto IL_011d;
							IL_00f1:
							if (oGZcpSFGPPXUmsQkMuZYwVWGLHpe.MoveNext())
							{
								ElementAssignmentConflictInfo current = oGZcpSFGPPXUmsQkMuZYwVWGLHpe.Current;
								uuJhzneBCSsXmXNgYLiTQScKMLtj = current;
								dYoDUesEHkabszWaQhpOjQoMYReuA = 1;
								return true;
							}
							QidfDlQYAnJuCXxlVjyiMCtUvdOh();
							oGZcpSFGPPXUmsQkMuZYwVWGLHpe = null;
							goto IL_010b;
							IL_011d:
							if (kxtiAGxOSmVtFxinyYQMTKyrfmcHA < conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif())
							{
								if (conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(kxtiAGxOSmVtFxinyYQMTKyrfmcHA).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == sVZgSmJHmtQdcOUuKeuIzqMhFQquA)
								{
									oGZcpSFGPPXUmsQkMuZYwVWGLHpe = conflictCheckingHelper.ZfpzdgqzYqeYwNYCKKVSgFTNLYuS(ControllerType.Custom, sVZgSmJHmtQdcOUuKeuIzqMhFQquA, CVyDZcAgbwOKTNgqICsvFiSSGaVHA, pMqwyXVkRXQgWBIxVexuHpyGeNmoA, FHYAVoATJCYFRucIeyJOpolXqrjrA, ovCumbdQOWSUZIwkLwzuZEbIBEyX, conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(kxtiAGxOSmVtFxinyYQMTKyrfmcHA).AhOWBwQXlUjEXgrPOgQMKEMCgKcP).GetEnumerator();
									dYoDUesEHkabszWaQhpOjQoMYReuA = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							kxtiAGxOSmVtFxinyYQMTKyrfmcHA++;
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

					private void QidfDlQYAnJuCXxlVjyiMCtUvdOh()
					{
						dYoDUesEHkabszWaQhpOjQoMYReuA = -1;
						if (oGZcpSFGPPXUmsQkMuZYwVWGLHpe != null)
						{
							oGZcpSFGPPXUmsQkMuZYwVWGLHpe.Dispose();
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
						ylrxbzNpbymQnTITLDLGKvcDIutdb ylrxbzNpbymQnTITLDLGKvcDIutdb2;
						if (dYoDUesEHkabszWaQhpOjQoMYReuA == -2 && rqhqzCoeTqCNJTPmJpsvtBfrMkxH == Environment.CurrentManagedThreadId)
						{
							dYoDUesEHkabszWaQhpOjQoMYReuA = 0;
							ylrxbzNpbymQnTITLDLGKvcDIutdb2 = this;
						}
						else
						{
							ylrxbzNpbymQnTITLDLGKvcDIutdb2 = new ylrxbzNpbymQnTITLDLGKvcDIutdb(0);
							ylrxbzNpbymQnTITLDLGKvcDIutdb2.hWhzHmIjZGWnYAPADgjqKuWvDdMEA = hWhzHmIjZGWnYAPADgjqKuWvDdMEA;
						}
						ylrxbzNpbymQnTITLDLGKvcDIutdb2.sVZgSmJHmtQdcOUuKeuIzqMhFQquA = zHFUdSvmXqBkXEQSbLpDenmvsJrQ;
						ylrxbzNpbymQnTITLDLGKvcDIutdb2.CVyDZcAgbwOKTNgqICsvFiSSGaVHA = WAgSXDwARqKNsNQjVqMThhKmfjGh;
						ylrxbzNpbymQnTITLDLGKvcDIutdb2.pMqwyXVkRXQgWBIxVexuHpyGeNmoA = WxFukwwtMXNmMnVxHzRRDuLtbLJI;
						ylrxbzNpbymQnTITLDLGKvcDIutdb2.FHYAVoATJCYFRucIeyJOpolXqrjrA = OpfnnONjpbpzwRSVPvDcbByakHTk;
						ylrxbzNpbymQnTITLDLGKvcDIutdb2.ovCumbdQOWSUZIwkLwzuZEbIBEyX = JVXEFydpWDLnieqfhPWGwIpyYbzLA;
						return ylrxbzNpbymQnTITLDLGKvcDIutdb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class yZWDozDAeacaXzEBduboTcOcKfNL : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int LMTeLTCBnKMgcgGgLmfyNaiaMNuU;

					private ElementAssignmentConflictInfo sJBFuXviTEeyjoLVmumrbgWYDFZAA;

					private int cYxejkBGFlWpoKcyfmdrldNfHpeIb;

					private ElementAssignmentConflictCheck TWDDHVjnPrvjJjQewgauTYiYewts;

					public ElementAssignmentConflictCheck LENHPvsxXPQDcTzxNnzscRcZPQvf;

					public ConflictCheckingHelper kbTCjCQkPJYPMTIbadDFHJtLqMvY;

					private bool mehMTUEoDOcVyAzlfPUcADNXtFet;

					public bool JhrRIDtvfQsgckeAkelapcGgketM;

					private bool HuTWjSQvssfYsoCkYdTyelZXTcWsA;

					public bool GmfMiSRjqpZivnuesMgmfrShnmXN;

					private int BbSRswtFeTewgmdMYAbCamznFaVCA;

					private IEnumerator<ElementAssignmentConflictInfo> RFBdDlUdbRMZiUtdctAOIntBejNi;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return sJBFuXviTEeyjoLVmumrbgWYDFZAA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sJBFuXviTEeyjoLVmumrbgWYDFZAA;
						}
					}

					[DebuggerHidden]
					public yZWDozDAeacaXzEBduboTcOcKfNL(int P_0)
					{
						LMTeLTCBnKMgcgGgLmfyNaiaMNuU = P_0;
						cYxejkBGFlWpoKcyfmdrldNfHpeIb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int lMTeLTCBnKMgcgGgLmfyNaiaMNuU = LMTeLTCBnKMgcgGgLmfyNaiaMNuU;
						if (lMTeLTCBnKMgcgGgLmfyNaiaMNuU == -3 || lMTeLTCBnKMgcgGgLmfyNaiaMNuU == 1)
						{
							try
							{
							}
							finally
							{
								PijRpDmqTlgkeGAklLXaRSCoPNnFb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int lMTeLTCBnKMgcgGgLmfyNaiaMNuU = LMTeLTCBnKMgcgGgLmfyNaiaMNuU;
							ConflictCheckingHelper conflictCheckingHelper = kbTCjCQkPJYPMTIbadDFHJtLqMvY;
							if (lMTeLTCBnKMgcgGgLmfyNaiaMNuU != 0)
							{
								if (lMTeLTCBnKMgcgGgLmfyNaiaMNuU != 1)
								{
									return false;
								}
								LMTeLTCBnKMgcgGgLmfyNaiaMNuU = -3;
								goto IL_00f3;
							}
							LMTeLTCBnKMgcgGgLmfyNaiaMNuU = -1;
							if (TWDDHVjnPrvjJjQewgauTYiYewts.controllerId < 0 || TWDDHVjnPrvjJjQewgauTYiYewts.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							BbSRswtFeTewgmdMYAbCamznFaVCA = 0;
							goto IL_011f;
							IL_00f3:
							if (RFBdDlUdbRMZiUtdctAOIntBejNi.MoveNext())
							{
								ElementAssignmentConflictInfo current = RFBdDlUdbRMZiUtdctAOIntBejNi.Current;
								sJBFuXviTEeyjoLVmumrbgWYDFZAA = current;
								LMTeLTCBnKMgcgGgLmfyNaiaMNuU = 1;
								return true;
							}
							PijRpDmqTlgkeGAklLXaRSCoPNnFb();
							RFBdDlUdbRMZiUtdctAOIntBejNi = null;
							goto IL_010d;
							IL_011f:
							if (BbSRswtFeTewgmdMYAbCamznFaVCA < conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif())
							{
								if (conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(BbSRswtFeTewgmdMYAbCamznFaVCA).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == TWDDHVjnPrvjJjQewgauTYiYewts.controllerId)
								{
									RFBdDlUdbRMZiUtdctAOIntBejNi = conflictCheckingHelper.emVTAzfANJgbrltFBUThhYwOlDGt(TWDDHVjnPrvjJjQewgauTYiYewts, mehMTUEoDOcVyAzlfPUcADNXtFet, HuTWjSQvssfYsoCkYdTyelZXTcWsA, conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(BbSRswtFeTewgmdMYAbCamznFaVCA).AhOWBwQXlUjEXgrPOgQMKEMCgKcP).GetEnumerator();
									LMTeLTCBnKMgcgGgLmfyNaiaMNuU = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							BbSRswtFeTewgmdMYAbCamznFaVCA++;
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

					private void PijRpDmqTlgkeGAklLXaRSCoPNnFb()
					{
						LMTeLTCBnKMgcgGgLmfyNaiaMNuU = -1;
						if (RFBdDlUdbRMZiUtdctAOIntBejNi != null)
						{
							RFBdDlUdbRMZiUtdctAOIntBejNi.Dispose();
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
						yZWDozDAeacaXzEBduboTcOcKfNL yZWDozDAeacaXzEBduboTcOcKfNL2;
						if (LMTeLTCBnKMgcgGgLmfyNaiaMNuU == -2 && cYxejkBGFlWpoKcyfmdrldNfHpeIb == Environment.CurrentManagedThreadId)
						{
							LMTeLTCBnKMgcgGgLmfyNaiaMNuU = 0;
							yZWDozDAeacaXzEBduboTcOcKfNL2 = this;
						}
						else
						{
							yZWDozDAeacaXzEBduboTcOcKfNL2 = new yZWDozDAeacaXzEBduboTcOcKfNL(0);
							yZWDozDAeacaXzEBduboTcOcKfNL2.kbTCjCQkPJYPMTIbadDFHJtLqMvY = kbTCjCQkPJYPMTIbadDFHJtLqMvY;
						}
						yZWDozDAeacaXzEBduboTcOcKfNL2.TWDDHVjnPrvjJjQewgauTYiYewts = LENHPvsxXPQDcTzxNnzscRcZPQvf;
						yZWDozDAeacaXzEBduboTcOcKfNL2.mehMTUEoDOcVyAzlfPUcADNXtFet = JhrRIDtvfQsgckeAkelapcGgketM;
						yZWDozDAeacaXzEBduboTcOcKfNL2.HuTWjSQvssfYsoCkYdTyelZXTcWsA = GmfMiSRjqpZivnuesMgmfrShnmXN;
						return yZWDozDAeacaXzEBduboTcOcKfNL2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZgPFKKOjLRdtGUKqgznMEWszhGN<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int srcTOsqVNvgmkZyrdDOauKDUfxTCA;

					private ElementAssignmentConflictInfo tKxuUEXVczUZJDhtEBYeOcJvDtkt;

					private int ZGSieHMrcoFenISlDrawhJsXduyC;

					private global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> znnGadUsicCmqatWVnXIFcdFMmhmA;

					public global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> CjCLKQAyljbDYnHxyUCOtCRnBGNb;

					private _0001 KgaYjueDiJtiVfndiKzOWyZMlNow;

					public _0001 dQmrFhoYXJLpENFgtYlrjAjnarlu;

					private bool ukwLNckHElPFdcMwdgZcrAhXbZSp;

					public bool MqEKSHEPAAwrDATyNJFiJYVVkiEO;

					private bool xRQLBpINpTmGSytDBIZGisvGIiAT;

					public bool FcXsTTQixCANZJYFrJRFMlAgoEXdA;

					public ConflictCheckingHelper vxzTiWyKruvXSBcojcFNqKsPFoew;

					private ControllerType OCYhIQCDmKhtOPiJCukkJVkGgJveb;

					public ControllerType LecELpOuUlaezlrqyMlbtNsExoFy;

					private int pDYdbOdUTbwPkzPOBJWAhGXxuzmCA;

					public int sjlcPTeZhPPAGOkgUHwAhrxqZAuOA;

					private InputMapCategory lyQhHXfxlRfwamzOIBLSFYZKYcTd;

					private int XnFrrWptZfbBnqvlbsnOkziuXVhe;

					private IEnumerator<ElementAssignmentConflictInfo> qWJgJReWcDxSutvztiAGdxTXdfJIA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tKxuUEXVczUZJDhtEBYeOcJvDtkt;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tKxuUEXVczUZJDhtEBYeOcJvDtkt;
						}
					}

					[DebuggerHidden]
					public ZgPFKKOjLRdtGUKqgznMEWszhGN(int P_0)
					{
						srcTOsqVNvgmkZyrdDOauKDUfxTCA = P_0;
						ZGSieHMrcoFenISlDrawhJsXduyC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = srcTOsqVNvgmkZyrdDOauKDUfxTCA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								GXSezajaTcEWJfQgoTtPSwpWwQPe();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = srcTOsqVNvgmkZyrdDOauKDUfxTCA;
							ConflictCheckingHelper conflictCheckingHelper = vxzTiWyKruvXSBcojcFNqKsPFoew;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								srcTOsqVNvgmkZyrdDOauKDUfxTCA = -3;
								goto IL_014a;
							}
							srcTOsqVNvgmkZyrdDOauKDUfxTCA = -1;
							if (znnGadUsicCmqatWVnXIFcdFMmhmA == null || KgaYjueDiJtiVfndiKzOWyZMlNow == null)
							{
								return false;
							}
							lyQhHXfxlRfwamzOIBLSFYZKYcTd = ReInput.mapping.GetMapCategory(KgaYjueDiJtiVfndiKzOWyZMlNow.categoryId);
							if (lyQhHXfxlRfwamzOIBLSFYZKYcTd == null)
							{
								return false;
							}
							XnFrrWptZfbBnqvlbsnOkziuXVhe = 0;
							goto IL_0176;
							IL_0176:
							if (XnFrrWptZfbBnqvlbsnOkziuXVhe < znnGadUsicCmqatWVnXIFcdFMmhmA.YzKYnaKJzjbvJEXDdyXusrltRUPjA())
							{
								ControllerMap controllerMap = znnGadUsicCmqatWVnXIFcdFMmhmA.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(XnFrrWptZfbBnqvlbsnOkziuXVhe);
								if ((!ukwLNckHElPFdcMwdgZcrAhXbZSp || controllerMap.enabled) && (xRQLBpINpTmGSytDBIZGisvGIiAT || !conflictCheckingHelper.NbQXMaNGdbaNmhZMeGgnOfGXqNReb(lyQhHXfxlRfwamzOIBLSFYZKYcTd, controllerMap)))
								{
									qWJgJReWcDxSutvztiAGdxTXdfJIA = controllerMap.ElementAssignmentConflicts(KgaYjueDiJtiVfndiKzOWyZMlNow, ukwLNckHElPFdcMwdgZcrAhXbZSp).GetEnumerator();
									srcTOsqVNvgmkZyrdDOauKDUfxTCA = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (qWJgJReWcDxSutvztiAGdxTXdfJIA.MoveNext())
							{
								ElementAssignmentConflictInfo current = qWJgJReWcDxSutvztiAGdxTXdfJIA.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.bOsBZQuhSpYeaCwOWsUGnESRErwc.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								elementAssignmentConflictInfo.controllerType = OCYhIQCDmKhtOPiJCukkJVkGgJveb;
								elementAssignmentConflictInfo.controllerId = pDYdbOdUTbwPkzPOBJWAhGXxuzmCA;
								tKxuUEXVczUZJDhtEBYeOcJvDtkt = elementAssignmentConflictInfo;
								srcTOsqVNvgmkZyrdDOauKDUfxTCA = 1;
								return true;
							}
							GXSezajaTcEWJfQgoTtPSwpWwQPe();
							qWJgJReWcDxSutvztiAGdxTXdfJIA = null;
							goto IL_0164;
							IL_0164:
							XnFrrWptZfbBnqvlbsnOkziuXVhe++;
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

					private void GXSezajaTcEWJfQgoTtPSwpWwQPe()
					{
						srcTOsqVNvgmkZyrdDOauKDUfxTCA = -1;
						if (qWJgJReWcDxSutvztiAGdxTXdfJIA != null)
						{
							qWJgJReWcDxSutvztiAGdxTXdfJIA.Dispose();
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
						ZgPFKKOjLRdtGUKqgznMEWszhGN<_0001> zgPFKKOjLRdtGUKqgznMEWszhGN;
						if (srcTOsqVNvgmkZyrdDOauKDUfxTCA == -2 && ZGSieHMrcoFenISlDrawhJsXduyC == Environment.CurrentManagedThreadId)
						{
							srcTOsqVNvgmkZyrdDOauKDUfxTCA = 0;
							zgPFKKOjLRdtGUKqgznMEWszhGN = this;
						}
						else
						{
							zgPFKKOjLRdtGUKqgznMEWszhGN = new ZgPFKKOjLRdtGUKqgznMEWszhGN<_0001>(0);
							zgPFKKOjLRdtGUKqgznMEWszhGN.vxzTiWyKruvXSBcojcFNqKsPFoew = vxzTiWyKruvXSBcojcFNqKsPFoew;
						}
						zgPFKKOjLRdtGUKqgznMEWszhGN.OCYhIQCDmKhtOPiJCukkJVkGgJveb = LecELpOuUlaezlrqyMlbtNsExoFy;
						zgPFKKOjLRdtGUKqgznMEWszhGN.pDYdbOdUTbwPkzPOBJWAhGXxuzmCA = sjlcPTeZhPPAGOkgUHwAhrxqZAuOA;
						zgPFKKOjLRdtGUKqgznMEWszhGN.KgaYjueDiJtiVfndiKzOWyZMlNow = dQmrFhoYXJLpENFgtYlrjAjnarlu;
						zgPFKKOjLRdtGUKqgznMEWszhGN.ukwLNckHElPFdcMwdgZcrAhXbZSp = MqEKSHEPAAwrDATyNJFiJYVVkiEO;
						zgPFKKOjLRdtGUKqgznMEWszhGN.xRQLBpINpTmGSytDBIZGisvGIiAT = FcXsTTQixCANZJYFrJRFMlAgoEXdA;
						zgPFKKOjLRdtGUKqgznMEWszhGN.znnGadUsicCmqatWVnXIFcdFMmhmA = CjCLKQAyljbDYnHxyUCOtCRnBGNb;
						return zgPFKKOjLRdtGUKqgznMEWszhGN;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class uvwEOoUpTpqQGRNorBVSdxXaCXiBb<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int DXLjFhHxgjVdyEDoGUVEGakjDafdA;

					private ElementAssignmentConflictInfo ABGpsAJaDOwFVUAiONRjltPWtlRl;

					private int DaSkEQeYqSBDTPzvcMahCjHxXtew;

					private global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> rvODgcRrgXIBSexDLSzlsMotbieC;

					public global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> gmdCdUiJUlKqoqtiFkfScOHGKMUD;

					private ActionElementMap HhULfIOVaXUMDGeLwktRjovkBHlc;

					public ActionElementMap ltDsJDcJHEkeutYYZuNniklYBunm;

					private _0001 tZJJKTGNTGsBqpnJTZBRXNCGknGU;

					public _0001 jTXMabZCrpyBrHkmhNdKxjYtmDNs;

					private bool uiWXzgnVZdOvsYqJtQCCdmXKyOWC;

					public bool DCtcrhOqzvouyeXxghStcVqwqbhH;

					private bool kuRReePiUBULyZVptONmXnAcLcDK;

					public bool oYebwWBVKPwFzpvPSMZveluBjffpA;

					public ConflictCheckingHelper UnCWEPbSnVRzZVOmYCCQooCpVsWb;

					private ControllerType ywbvBhXAHJeOmnHVMrUCvpNRHSzY;

					public ControllerType KcLJAtEnihKdAdaHkWmPwmPLjFKIA;

					private int ZqOtRbaHlfWaESaJZBsJPEEffulBA;

					public int MRamlApvtWSqrhXuYUUHXWuhpJDd;

					private InputMapCategory rdNzXKbaDEuECKyLnIdZVbIBTVSy;

					private int uxslhwQBTMWoNVitlrbJQqFSkpyw;

					private IEnumerator<ElementAssignmentConflictInfo> oRwcNahqLGgJCEjxnicmUhwbFOTo;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ABGpsAJaDOwFVUAiONRjltPWtlRl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ABGpsAJaDOwFVUAiONRjltPWtlRl;
						}
					}

					[DebuggerHidden]
					public uvwEOoUpTpqQGRNorBVSdxXaCXiBb(int P_0)
					{
						DXLjFhHxgjVdyEDoGUVEGakjDafdA = P_0;
						DaSkEQeYqSBDTPzvcMahCjHxXtew = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dXLjFhHxgjVdyEDoGUVEGakjDafdA = DXLjFhHxgjVdyEDoGUVEGakjDafdA;
						if (dXLjFhHxgjVdyEDoGUVEGakjDafdA == -3 || dXLjFhHxgjVdyEDoGUVEGakjDafdA == 1)
						{
							try
							{
							}
							finally
							{
								weFJtJNhNEiPLCQcqlHxBeBfFBonb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int dXLjFhHxgjVdyEDoGUVEGakjDafdA = DXLjFhHxgjVdyEDoGUVEGakjDafdA;
							ConflictCheckingHelper unCWEPbSnVRzZVOmYCCQooCpVsWb = UnCWEPbSnVRzZVOmYCCQooCpVsWb;
							if (dXLjFhHxgjVdyEDoGUVEGakjDafdA != 0)
							{
								if (dXLjFhHxgjVdyEDoGUVEGakjDafdA != 1)
								{
									return false;
								}
								DXLjFhHxgjVdyEDoGUVEGakjDafdA = -3;
								goto IL_0141;
							}
							DXLjFhHxgjVdyEDoGUVEGakjDafdA = -1;
							if (rvODgcRrgXIBSexDLSzlsMotbieC == null || HhULfIOVaXUMDGeLwktRjovkBHlc == null)
							{
								return false;
							}
							rdNzXKbaDEuECKyLnIdZVbIBTVSy = ((tZJJKTGNTGsBqpnJTZBRXNCGknGU != null) ? ReInput.mapping.GetMapCategory(tZJJKTGNTGsBqpnJTZBRXNCGknGU.categoryId) : null);
							uxslhwQBTMWoNVitlrbJQqFSkpyw = 0;
							goto IL_016d;
							IL_016d:
							if (uxslhwQBTMWoNVitlrbJQqFSkpyw < rvODgcRrgXIBSexDLSzlsMotbieC.YzKYnaKJzjbvJEXDdyXusrltRUPjA())
							{
								ControllerMap controllerMap = rvODgcRrgXIBSexDLSzlsMotbieC.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(uxslhwQBTMWoNVitlrbJQqFSkpyw);
								if ((!uiWXzgnVZdOvsYqJtQCCdmXKyOWC || controllerMap.enabled) && (kuRReePiUBULyZVptONmXnAcLcDK || !unCWEPbSnVRzZVOmYCCQooCpVsWb.NbQXMaNGdbaNmhZMeGgnOfGXqNReb(rdNzXKbaDEuECKyLnIdZVbIBTVSy, controllerMap)))
								{
									oRwcNahqLGgJCEjxnicmUhwbFOTo = controllerMap.ElementAssignmentConflicts(HhULfIOVaXUMDGeLwktRjovkBHlc, uiWXzgnVZdOvsYqJtQCCdmXKyOWC).GetEnumerator();
									DXLjFhHxgjVdyEDoGUVEGakjDafdA = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							uxslhwQBTMWoNVitlrbJQqFSkpyw++;
							goto IL_016d;
							IL_0141:
							if (oRwcNahqLGgJCEjxnicmUhwbFOTo.MoveNext())
							{
								ElementAssignmentConflictInfo current = oRwcNahqLGgJCEjxnicmUhwbFOTo.Current;
								ElementAssignmentConflictInfo aBGpsAJaDOwFVUAiONRjltPWtlRl = new ElementAssignmentConflictInfo(current);
								aBGpsAJaDOwFVUAiONRjltPWtlRl.playerId = unCWEPbSnVRzZVOmYCCQooCpVsWb.bOsBZQuhSpYeaCwOWsUGnESRErwc.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								aBGpsAJaDOwFVUAiONRjltPWtlRl.controllerType = ywbvBhXAHJeOmnHVMrUCvpNRHSzY;
								aBGpsAJaDOwFVUAiONRjltPWtlRl.controllerId = ZqOtRbaHlfWaESaJZBsJPEEffulBA;
								ABGpsAJaDOwFVUAiONRjltPWtlRl = aBGpsAJaDOwFVUAiONRjltPWtlRl;
								DXLjFhHxgjVdyEDoGUVEGakjDafdA = 1;
								return true;
							}
							weFJtJNhNEiPLCQcqlHxBeBfFBonb();
							oRwcNahqLGgJCEjxnicmUhwbFOTo = null;
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

					private void weFJtJNhNEiPLCQcqlHxBeBfFBonb()
					{
						DXLjFhHxgjVdyEDoGUVEGakjDafdA = -1;
						if (oRwcNahqLGgJCEjxnicmUhwbFOTo != null)
						{
							oRwcNahqLGgJCEjxnicmUhwbFOTo.Dispose();
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
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb<_0001> uvwEOoUpTpqQGRNorBVSdxXaCXiBb2;
						if (DXLjFhHxgjVdyEDoGUVEGakjDafdA == -2 && DaSkEQeYqSBDTPzvcMahCjHxXtew == Environment.CurrentManagedThreadId)
						{
							DXLjFhHxgjVdyEDoGUVEGakjDafdA = 0;
							uvwEOoUpTpqQGRNorBVSdxXaCXiBb2 = this;
						}
						else
						{
							uvwEOoUpTpqQGRNorBVSdxXaCXiBb2 = new uvwEOoUpTpqQGRNorBVSdxXaCXiBb<_0001>(0);
							uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.UnCWEPbSnVRzZVOmYCCQooCpVsWb = UnCWEPbSnVRzZVOmYCCQooCpVsWb;
						}
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.ywbvBhXAHJeOmnHVMrUCvpNRHSzY = KcLJAtEnihKdAdaHkWmPwmPLjFKIA;
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.ZqOtRbaHlfWaESaJZBsJPEEffulBA = MRamlApvtWSqrhXuYUUHXWuhpJDd;
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.tZJJKTGNTGsBqpnJTZBRXNCGknGU = jTXMabZCrpyBrHkmhNdKxjYtmDNs;
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.HhULfIOVaXUMDGeLwktRjovkBHlc = ltDsJDcJHEkeutYYZuNniklYBunm;
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.uiWXzgnVZdOvsYqJtQCCdmXKyOWC = DCtcrhOqzvouyeXxghStcVqwqbhH;
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.kuRReePiUBULyZVptONmXnAcLcDK = oYebwWBVKPwFzpvPSMZveluBjffpA;
						uvwEOoUpTpqQGRNorBVSdxXaCXiBb2.rvODgcRrgXIBSexDLSzlsMotbieC = gmdCdUiJUlKqoqtiFkfScOHGKMUD;
						return uvwEOoUpTpqQGRNorBVSdxXaCXiBb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class NeycWLBWIaTROcCdASLSsjjEuMfb<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int bmQbIMfonLgmYINuGcwsLKJQpqkgc;

					private ElementAssignmentConflictInfo CWWFlShuXGMVtylPtmzOsFNuBmOsA;

					private int SfaCSIjwdtTneVwHxOxbKFJNCqDRA;

					private global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> NuYAnCEAppUVXXcEXbTezlnrAjdeA;

					public global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> iHcGagnCJfpaiihMKvJQMmaOzxxb;

					private ElementAssignmentConflictCheck aXvwlPtkQKLSjoAUsjDuAaYWcWjp;

					public ElementAssignmentConflictCheck aiMHpwTxIcpmLQCKPBeNGYZPIDMt;

					private bool ErUCKVsntKlhiDnTzcDXdXRlvwqDA;

					public bool HxNNpppPZFEdHrRVfcXnbXZdkuAp;

					private bool FYTlPKcUpLbGvmmlthdHJdagmBpV;

					public bool rCLtsVtLGbvDVeAGoDOXcJfcqjSqA;

					public ConflictCheckingHelper LrtWHXttGTzDYTEoXJpyRfoQKLKx;

					private InputMapCategory cpQSxjHlzMGcgwvStiElWYdAuYml;

					private int uFsLunDTDHHliAQIMnKPVqYvbEEi;

					private IEnumerator<ElementAssignmentConflictInfo> tbtaRTdWXlBnpeOTfYaNDRyoMWamB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return CWWFlShuXGMVtylPtmzOsFNuBmOsA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CWWFlShuXGMVtylPtmzOsFNuBmOsA;
						}
					}

					[DebuggerHidden]
					public NeycWLBWIaTROcCdASLSsjjEuMfb(int P_0)
					{
						bmQbIMfonLgmYINuGcwsLKJQpqkgc = P_0;
						SfaCSIjwdtTneVwHxOxbKFJNCqDRA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bmQbIMfonLgmYINuGcwsLKJQpqkgc;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								YtIWLntaFWoiiAwDFxJbQzhmCEAi();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = bmQbIMfonLgmYINuGcwsLKJQpqkgc;
							ConflictCheckingHelper lrtWHXttGTzDYTEoXJpyRfoQKLKx = LrtWHXttGTzDYTEoXJpyRfoQKLKx;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bmQbIMfonLgmYINuGcwsLKJQpqkgc = -3;
								goto IL_01ab;
							}
							bmQbIMfonLgmYINuGcwsLKJQpqkgc = -1;
							if (NuYAnCEAppUVXXcEXbTezlnrAjdeA == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(aXvwlPtkQKLSjoAUsjDuAaYWcWjp.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(aXvwlPtkQKLSjoAUsjDuAaYWcWjp.controllerType, aXvwlPtkQKLSjoAUsjDuAaYWcWjp.controllerId, aXvwlPtkQKLSjoAUsjDuAaYWcWjp.controllerMapId);
							cpQSxjHlzMGcgwvStiElWYdAuYml = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(aXvwlPtkQKLSjoAUsjDuAaYWcWjp.controllerMapCategoryId));
							if (cpQSxjHlzMGcgwvStiElWYdAuYml == null)
							{
								return false;
							}
							uFsLunDTDHHliAQIMnKPVqYvbEEi = 0;
							goto IL_01d7;
							IL_01ab:
							if (tbtaRTdWXlBnpeOTfYaNDRyoMWamB.MoveNext())
							{
								ElementAssignmentConflictInfo current = tbtaRTdWXlBnpeOTfYaNDRyoMWamB.Current;
								ElementAssignmentConflictInfo cWWFlShuXGMVtylPtmzOsFNuBmOsA = new ElementAssignmentConflictInfo(current);
								cWWFlShuXGMVtylPtmzOsFNuBmOsA.playerId = lrtWHXttGTzDYTEoXJpyRfoQKLKx.bOsBZQuhSpYeaCwOWsUGnESRErwc.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								cWWFlShuXGMVtylPtmzOsFNuBmOsA.controllerType = aXvwlPtkQKLSjoAUsjDuAaYWcWjp.controllerType;
								cWWFlShuXGMVtylPtmzOsFNuBmOsA.controllerId = aXvwlPtkQKLSjoAUsjDuAaYWcWjp.controllerId;
								CWWFlShuXGMVtylPtmzOsFNuBmOsA = cWWFlShuXGMVtylPtmzOsFNuBmOsA;
								bmQbIMfonLgmYINuGcwsLKJQpqkgc = 1;
								return true;
							}
							YtIWLntaFWoiiAwDFxJbQzhmCEAi();
							tbtaRTdWXlBnpeOTfYaNDRyoMWamB = null;
							goto IL_01c5;
							IL_01d7:
							if (uFsLunDTDHHliAQIMnKPVqYvbEEi < NuYAnCEAppUVXXcEXbTezlnrAjdeA.YzKYnaKJzjbvJEXDdyXusrltRUPjA())
							{
								ControllerMap controllerMap = NuYAnCEAppUVXXcEXbTezlnrAjdeA.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(uFsLunDTDHHliAQIMnKPVqYvbEEi);
								if ((!ErUCKVsntKlhiDnTzcDXdXRlvwqDA || controllerMap.enabled) && (FYTlPKcUpLbGvmmlthdHJdagmBpV || !lrtWHXttGTzDYTEoXJpyRfoQKLKx.NbQXMaNGdbaNmhZMeGgnOfGXqNReb(cpQSxjHlzMGcgwvStiElWYdAuYml, controllerMap)))
								{
									tbtaRTdWXlBnpeOTfYaNDRyoMWamB = controllerMap.ElementAssignmentConflicts(aXvwlPtkQKLSjoAUsjDuAaYWcWjp, ErUCKVsntKlhiDnTzcDXdXRlvwqDA).GetEnumerator();
									bmQbIMfonLgmYINuGcwsLKJQpqkgc = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							uFsLunDTDHHliAQIMnKPVqYvbEEi++;
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

					private void YtIWLntaFWoiiAwDFxJbQzhmCEAi()
					{
						bmQbIMfonLgmYINuGcwsLKJQpqkgc = -1;
						if (tbtaRTdWXlBnpeOTfYaNDRyoMWamB != null)
						{
							tbtaRTdWXlBnpeOTfYaNDRyoMWamB.Dispose();
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
						NeycWLBWIaTROcCdASLSsjjEuMfb<_0001> neycWLBWIaTROcCdASLSsjjEuMfb;
						if (bmQbIMfonLgmYINuGcwsLKJQpqkgc == -2 && SfaCSIjwdtTneVwHxOxbKFJNCqDRA == Environment.CurrentManagedThreadId)
						{
							bmQbIMfonLgmYINuGcwsLKJQpqkgc = 0;
							neycWLBWIaTROcCdASLSsjjEuMfb = this;
						}
						else
						{
							neycWLBWIaTROcCdASLSsjjEuMfb = new NeycWLBWIaTROcCdASLSsjjEuMfb<_0001>(0);
							neycWLBWIaTROcCdASLSsjjEuMfb.LrtWHXttGTzDYTEoXJpyRfoQKLKx = LrtWHXttGTzDYTEoXJpyRfoQKLKx;
						}
						neycWLBWIaTROcCdASLSsjjEuMfb.aXvwlPtkQKLSjoAUsjDuAaYWcWjp = aiMHpwTxIcpmLQCKPBeNGYZPIDMt;
						neycWLBWIaTROcCdASLSsjjEuMfb.ErUCKVsntKlhiDnTzcDXdXRlvwqDA = HxNNpppPZFEdHrRVfcXnbXZdkuAp;
						neycWLBWIaTROcCdASLSsjjEuMfb.FYTlPKcUpLbGvmmlthdHJdagmBpV = rCLtsVtLGbvDVeAGoDOXcJfcqjSqA;
						neycWLBWIaTROcCdASLSsjjEuMfb.NuYAnCEAppUVXXcEXbTezlnrAjdeA = iHcGagnCJfpaiihMKvJQMmaOzxxb;
						return neycWLBWIaTROcCdASLSsjjEuMfb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class GUNbutbtFnuHZMXuBcIjEzdXdBLH : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int SoqsbIMqWLjhLIaAyhvHHrQPVlHm;

					private ElementAssignmentConflictInfo oSUglCWjvTEEHAUfHSlbLcBUSwMQA;

					private int MEWFmeDIxbMLneKbAZFXWCXJpTxTB;

					private int wgIYtPpfUfKoOIXMIpFrrrMBeLwf;

					public int dnqZYPIhSMMPToKKqVqFYzfYFWkI;

					private JoystickMap YnXApoCViBkKRHVPdKUwRPblyjfAB;

					public JoystickMap mqYAjyBJXjnfCPDkdUrNdlZBQcgSA;

					public ConflictCheckingHelper JcYiOkSxyECvHnIGgwmPEETOZbEw;

					private bool bInVJZexyrxlknESNQKqotkKqYGi;

					public bool JvqCsubOCPydAwCVDOQNLbRRbASm;

					private bool abYlQOktVafvMxBrDigGZjZGcsnY;

					public bool AepRrZljPsuYRzjnZQaluPHRgRRFA;

					private int cDDlEOYHydfFVchBkAJgAdABSrFwb;

					private IEnumerator<ElementAssignmentConflictInfo> dIRUZrnAdSXddMiHLKMnpzdeviwp;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oSUglCWjvTEEHAUfHSlbLcBUSwMQA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oSUglCWjvTEEHAUfHSlbLcBUSwMQA;
						}
					}

					[DebuggerHidden]
					public GUNbutbtFnuHZMXuBcIjEzdXdBLH(int P_0)
					{
						SoqsbIMqWLjhLIaAyhvHHrQPVlHm = P_0;
						MEWFmeDIxbMLneKbAZFXWCXJpTxTB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int soqsbIMqWLjhLIaAyhvHHrQPVlHm = SoqsbIMqWLjhLIaAyhvHHrQPVlHm;
						if (soqsbIMqWLjhLIaAyhvHHrQPVlHm == -3 || soqsbIMqWLjhLIaAyhvHHrQPVlHm == 1)
						{
							try
							{
							}
							finally
							{
								LKEnHWpcLXTrxIPpvyxiLxHVmPIJ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int soqsbIMqWLjhLIaAyhvHHrQPVlHm = SoqsbIMqWLjhLIaAyhvHHrQPVlHm;
							ConflictCheckingHelper jcYiOkSxyECvHnIGgwmPEETOZbEw = JcYiOkSxyECvHnIGgwmPEETOZbEw;
							if (soqsbIMqWLjhLIaAyhvHHrQPVlHm != 0)
							{
								if (soqsbIMqWLjhLIaAyhvHHrQPVlHm != 1)
								{
									return false;
								}
								SoqsbIMqWLjhLIaAyhvHHrQPVlHm = -3;
								goto IL_00ea;
							}
							SoqsbIMqWLjhLIaAyhvHHrQPVlHm = -1;
							if (wgIYtPpfUfKoOIXMIpFrrrMBeLwf < 0 || YnXApoCViBkKRHVPdKUwRPblyjfAB == null)
							{
								return false;
							}
							cDDlEOYHydfFVchBkAJgAdABSrFwb = 0;
							goto IL_0116;
							IL_00ea:
							if (dIRUZrnAdSXddMiHLKMnpzdeviwp.MoveNext())
							{
								ElementAssignmentConflictInfo current = dIRUZrnAdSXddMiHLKMnpzdeviwp.Current;
								oSUglCWjvTEEHAUfHSlbLcBUSwMQA = current;
								SoqsbIMqWLjhLIaAyhvHHrQPVlHm = 1;
								return true;
							}
							LKEnHWpcLXTrxIPpvyxiLxHVmPIJ();
							dIRUZrnAdSXddMiHLKMnpzdeviwp = null;
							goto IL_0104;
							IL_0116:
							if (cDDlEOYHydfFVchBkAJgAdABSrFwb < jcYiOkSxyECvHnIGgwmPEETOZbEw.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif())
							{
								if (jcYiOkSxyECvHnIGgwmPEETOZbEw.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(cDDlEOYHydfFVchBkAJgAdABSrFwb).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == wgIYtPpfUfKoOIXMIpFrrrMBeLwf)
								{
									dIRUZrnAdSXddMiHLKMnpzdeviwp = jcYiOkSxyECvHnIGgwmPEETOZbEw.nlcRJgZGjVaeSwSCYnYLsAlXEtkHA(ControllerType.Joystick, wgIYtPpfUfKoOIXMIpFrrrMBeLwf, YnXApoCViBkKRHVPdKUwRPblyjfAB, bInVJZexyrxlknESNQKqotkKqYGi, abYlQOktVafvMxBrDigGZjZGcsnY, jcYiOkSxyECvHnIGgwmPEETOZbEw.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(cDDlEOYHydfFVchBkAJgAdABSrFwb).AhOWBwQXlUjEXgrPOgQMKEMCgKcP).GetEnumerator();
									SoqsbIMqWLjhLIaAyhvHHrQPVlHm = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							cDDlEOYHydfFVchBkAJgAdABSrFwb++;
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

					private void LKEnHWpcLXTrxIPpvyxiLxHVmPIJ()
					{
						SoqsbIMqWLjhLIaAyhvHHrQPVlHm = -1;
						if (dIRUZrnAdSXddMiHLKMnpzdeviwp != null)
						{
							dIRUZrnAdSXddMiHLKMnpzdeviwp.Dispose();
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
						GUNbutbtFnuHZMXuBcIjEzdXdBLH gUNbutbtFnuHZMXuBcIjEzdXdBLH;
						if (SoqsbIMqWLjhLIaAyhvHHrQPVlHm == -2 && MEWFmeDIxbMLneKbAZFXWCXJpTxTB == Environment.CurrentManagedThreadId)
						{
							SoqsbIMqWLjhLIaAyhvHHrQPVlHm = 0;
							gUNbutbtFnuHZMXuBcIjEzdXdBLH = this;
						}
						else
						{
							gUNbutbtFnuHZMXuBcIjEzdXdBLH = new GUNbutbtFnuHZMXuBcIjEzdXdBLH(0);
							gUNbutbtFnuHZMXuBcIjEzdXdBLH.JcYiOkSxyECvHnIGgwmPEETOZbEw = JcYiOkSxyECvHnIGgwmPEETOZbEw;
						}
						gUNbutbtFnuHZMXuBcIjEzdXdBLH.wgIYtPpfUfKoOIXMIpFrrrMBeLwf = dnqZYPIhSMMPToKKqVqFYzfYFWkI;
						gUNbutbtFnuHZMXuBcIjEzdXdBLH.YnXApoCViBkKRHVPdKUwRPblyjfAB = mqYAjyBJXjnfCPDkdUrNdlZBQcgSA;
						gUNbutbtFnuHZMXuBcIjEzdXdBLH.bInVJZexyrxlknESNQKqotkKqYGi = JvqCsubOCPydAwCVDOQNLbRRbASm;
						gUNbutbtFnuHZMXuBcIjEzdXdBLH.abYlQOktVafvMxBrDigGZjZGcsnY = AepRrZljPsuYRzjnZQaluPHRgRRFA;
						return gUNbutbtFnuHZMXuBcIjEzdXdBLH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class EKfSIgeqlRDfcDVyEULYFnZJQJrB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int cMYkaOgaqHLiVbPMmYunkGnkbaZz;

					private ElementAssignmentConflictInfo npaFOPXMOuixDlbYlQAFznSikseW;

					private int BBckaPaDObrLvrjMcEKDDgQNTGSfA;

					private int tyxFflibeJfKqLUQUFRIOjQyKvMT;

					public int TzaOzcISsGDzXFWABGGcBlsIidBh;

					private ActionElementMap HSlBDaqgBsaDKjAzaiYGQNLvwdXNA;

					public ActionElementMap bjnbhWmaPuEVVuWDpgSbdFLWvJZy;

					public ConflictCheckingHelper gHJMmhelDwWwFONUVweKtXiEYQRE;

					private JoystickMap RNgwTHOlkNjoDsdSwjlJUsehinZk;

					public JoystickMap zkRnkCORzNmSqCJCMEukYbcfqWJu;

					private bool MpDasTLxMcidwlBsBfsxJaMxNgfCA;

					public bool dyIImnVAwWnmPLCIYpjRqtbMFbBv;

					private bool sUGuBpejcDUCYLkRJhkYRDRtSGAN;

					public bool kjaMEfkajxHgjcgdebtcxKNSOdhXA;

					private int NdTHrbEoMKsvDrxhCazPnxIDucONA;

					private IEnumerator<ElementAssignmentConflictInfo> NNAluqQschrBPnAuqmvYybvjYAYn;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return npaFOPXMOuixDlbYlQAFznSikseW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return npaFOPXMOuixDlbYlQAFznSikseW;
						}
					}

					[DebuggerHidden]
					public EKfSIgeqlRDfcDVyEULYFnZJQJrB(int P_0)
					{
						cMYkaOgaqHLiVbPMmYunkGnkbaZz = P_0;
						BBckaPaDObrLvrjMcEKDDgQNTGSfA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cMYkaOgaqHLiVbPMmYunkGnkbaZz;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								DiWrFVzhmhlVpqqsESYRpWCycCLv();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = cMYkaOgaqHLiVbPMmYunkGnkbaZz;
							ConflictCheckingHelper conflictCheckingHelper = gHJMmhelDwWwFONUVweKtXiEYQRE;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cMYkaOgaqHLiVbPMmYunkGnkbaZz = -3;
								goto IL_00f0;
							}
							cMYkaOgaqHLiVbPMmYunkGnkbaZz = -1;
							if (tyxFflibeJfKqLUQUFRIOjQyKvMT < 0 || HSlBDaqgBsaDKjAzaiYGQNLvwdXNA == null)
							{
								return false;
							}
							NdTHrbEoMKsvDrxhCazPnxIDucONA = 0;
							goto IL_011c;
							IL_00f0:
							if (NNAluqQschrBPnAuqmvYybvjYAYn.MoveNext())
							{
								ElementAssignmentConflictInfo current = NNAluqQschrBPnAuqmvYybvjYAYn.Current;
								npaFOPXMOuixDlbYlQAFznSikseW = current;
								cMYkaOgaqHLiVbPMmYunkGnkbaZz = 1;
								return true;
							}
							DiWrFVzhmhlVpqqsESYRpWCycCLv();
							NNAluqQschrBPnAuqmvYybvjYAYn = null;
							goto IL_010a;
							IL_011c:
							if (NdTHrbEoMKsvDrxhCazPnxIDucONA < conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif())
							{
								if (conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(NdTHrbEoMKsvDrxhCazPnxIDucONA).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == tyxFflibeJfKqLUQUFRIOjQyKvMT)
								{
									NNAluqQschrBPnAuqmvYybvjYAYn = conflictCheckingHelper.ZfpzdgqzYqeYwNYCKKVSgFTNLYuS(ControllerType.Joystick, tyxFflibeJfKqLUQUFRIOjQyKvMT, RNgwTHOlkNjoDsdSwjlJUsehinZk, HSlBDaqgBsaDKjAzaiYGQNLvwdXNA, MpDasTLxMcidwlBsBfsxJaMxNgfCA, sUGuBpejcDUCYLkRJhkYRDRtSGAN, conflictCheckingHelper.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(NdTHrbEoMKsvDrxhCazPnxIDucONA).AhOWBwQXlUjEXgrPOgQMKEMCgKcP).GetEnumerator();
									cMYkaOgaqHLiVbPMmYunkGnkbaZz = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							NdTHrbEoMKsvDrxhCazPnxIDucONA++;
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

					private void DiWrFVzhmhlVpqqsESYRpWCycCLv()
					{
						cMYkaOgaqHLiVbPMmYunkGnkbaZz = -1;
						if (NNAluqQschrBPnAuqmvYybvjYAYn != null)
						{
							NNAluqQschrBPnAuqmvYybvjYAYn.Dispose();
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
						EKfSIgeqlRDfcDVyEULYFnZJQJrB eKfSIgeqlRDfcDVyEULYFnZJQJrB;
						if (cMYkaOgaqHLiVbPMmYunkGnkbaZz == -2 && BBckaPaDObrLvrjMcEKDDgQNTGSfA == Environment.CurrentManagedThreadId)
						{
							cMYkaOgaqHLiVbPMmYunkGnkbaZz = 0;
							eKfSIgeqlRDfcDVyEULYFnZJQJrB = this;
						}
						else
						{
							eKfSIgeqlRDfcDVyEULYFnZJQJrB = new EKfSIgeqlRDfcDVyEULYFnZJQJrB(0);
							eKfSIgeqlRDfcDVyEULYFnZJQJrB.gHJMmhelDwWwFONUVweKtXiEYQRE = gHJMmhelDwWwFONUVweKtXiEYQRE;
						}
						eKfSIgeqlRDfcDVyEULYFnZJQJrB.tyxFflibeJfKqLUQUFRIOjQyKvMT = TzaOzcISsGDzXFWABGGcBlsIidBh;
						eKfSIgeqlRDfcDVyEULYFnZJQJrB.RNgwTHOlkNjoDsdSwjlJUsehinZk = zkRnkCORzNmSqCJCMEukYbcfqWJu;
						eKfSIgeqlRDfcDVyEULYFnZJQJrB.HSlBDaqgBsaDKjAzaiYGQNLvwdXNA = bjnbhWmaPuEVVuWDpgSbdFLWvJZy;
						eKfSIgeqlRDfcDVyEULYFnZJQJrB.MpDasTLxMcidwlBsBfsxJaMxNgfCA = dyIImnVAwWnmPLCIYpjRqtbMFbBv;
						eKfSIgeqlRDfcDVyEULYFnZJQJrB.sUGuBpejcDUCYLkRJhkYRDRtSGAN = kjaMEfkajxHgjcgdebtcxKNSOdhXA;
						return eKfSIgeqlRDfcDVyEULYFnZJQJrB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class JRXtRaceMGLCtGSeRBKbJfwFIvVg : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int nWDlNYBQmbUDpdlpgViAqfyoCJJj;

					private ElementAssignmentConflictInfo wFftkqYOMkDGNdSFAuzzQrPYLcIY;

					private int DYLmSWDCQTDNrPIWprhEOMJCvBUM;

					private ElementAssignmentConflictCheck CLzbuBRHOtWMZMdrEKYxydMipMsg;

					public ElementAssignmentConflictCheck GCqfoxeYfkSOUbHCQZZbiSmDIttiA;

					public ConflictCheckingHelper JHCSLJgEKbVvVuZyrVuISScuKIte;

					private bool sxDFcYKgJnDxjfXILkfqlvAWDtcEA;

					public bool ZwaaSKVHGLGqxqZQttITmBfxrCyR;

					private bool VVOjaMrdNyQSCIKSaeItGpQQTwZpA;

					public bool QENDHqvPizPzcvbOuDdGIPLbWJpt;

					private int JzJFhxkzNuQmcVOxyydHlnImGEOc;

					private IEnumerator<ElementAssignmentConflictInfo> YwZGILNajxCNmSfHBqsyyHnCNNTU;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wFftkqYOMkDGNdSFAuzzQrPYLcIY;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wFftkqYOMkDGNdSFAuzzQrPYLcIY;
						}
					}

					[DebuggerHidden]
					public JRXtRaceMGLCtGSeRBKbJfwFIvVg(int P_0)
					{
						nWDlNYBQmbUDpdlpgViAqfyoCJJj = P_0;
						DYLmSWDCQTDNrPIWprhEOMJCvBUM = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = nWDlNYBQmbUDpdlpgViAqfyoCJJj;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								lICNJdxAjODPXWsxgkivvcVJTnPq();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = nWDlNYBQmbUDpdlpgViAqfyoCJJj;
							ConflictCheckingHelper jHCSLJgEKbVvVuZyrVuISScuKIte = JHCSLJgEKbVvVuZyrVuISScuKIte;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								nWDlNYBQmbUDpdlpgViAqfyoCJJj = -3;
								goto IL_00f3;
							}
							nWDlNYBQmbUDpdlpgViAqfyoCJJj = -1;
							if (CLzbuBRHOtWMZMdrEKYxydMipMsg.controllerId < 0 || CLzbuBRHOtWMZMdrEKYxydMipMsg.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							JzJFhxkzNuQmcVOxyydHlnImGEOc = 0;
							goto IL_011f;
							IL_00f3:
							if (YwZGILNajxCNmSfHBqsyyHnCNNTU.MoveNext())
							{
								ElementAssignmentConflictInfo current = YwZGILNajxCNmSfHBqsyyHnCNNTU.Current;
								wFftkqYOMkDGNdSFAuzzQrPYLcIY = current;
								nWDlNYBQmbUDpdlpgViAqfyoCJJj = 1;
								return true;
							}
							lICNJdxAjODPXWsxgkivvcVJTnPq();
							YwZGILNajxCNmSfHBqsyyHnCNNTU = null;
							goto IL_010d;
							IL_011f:
							if (JzJFhxkzNuQmcVOxyydHlnImGEOc < jHCSLJgEKbVvVuZyrVuISScuKIte.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif())
							{
								if (jHCSLJgEKbVvVuZyrVuISScuKIte.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(JzJFhxkzNuQmcVOxyydHlnImGEOc).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == CLzbuBRHOtWMZMdrEKYxydMipMsg.controllerId)
								{
									YwZGILNajxCNmSfHBqsyyHnCNNTU = jHCSLJgEKbVvVuZyrVuISScuKIte.emVTAzfANJgbrltFBUThhYwOlDGt(CLzbuBRHOtWMZMdrEKYxydMipMsg, sxDFcYKgJnDxjfXILkfqlvAWDtcEA, VVOjaMrdNyQSCIKSaeItGpQQTwZpA, jHCSLJgEKbVvVuZyrVuISScuKIte.GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(JzJFhxkzNuQmcVOxyydHlnImGEOc).AhOWBwQXlUjEXgrPOgQMKEMCgKcP).GetEnumerator();
									nWDlNYBQmbUDpdlpgViAqfyoCJJj = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							JzJFhxkzNuQmcVOxyydHlnImGEOc++;
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

					private void lICNJdxAjODPXWsxgkivvcVJTnPq()
					{
						nWDlNYBQmbUDpdlpgViAqfyoCJJj = -1;
						if (YwZGILNajxCNmSfHBqsyyHnCNNTU != null)
						{
							YwZGILNajxCNmSfHBqsyyHnCNNTU.Dispose();
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
						JRXtRaceMGLCtGSeRBKbJfwFIvVg jRXtRaceMGLCtGSeRBKbJfwFIvVg;
						if (nWDlNYBQmbUDpdlpgViAqfyoCJJj == -2 && DYLmSWDCQTDNrPIWprhEOMJCvBUM == Environment.CurrentManagedThreadId)
						{
							nWDlNYBQmbUDpdlpgViAqfyoCJJj = 0;
							jRXtRaceMGLCtGSeRBKbJfwFIvVg = this;
						}
						else
						{
							jRXtRaceMGLCtGSeRBKbJfwFIvVg = new JRXtRaceMGLCtGSeRBKbJfwFIvVg(0);
							jRXtRaceMGLCtGSeRBKbJfwFIvVg.JHCSLJgEKbVvVuZyrVuISScuKIte = JHCSLJgEKbVvVuZyrVuISScuKIte;
						}
						jRXtRaceMGLCtGSeRBKbJfwFIvVg.CLzbuBRHOtWMZMdrEKYxydMipMsg = GCqfoxeYfkSOUbHCQZZbiSmDIttiA;
						jRXtRaceMGLCtGSeRBKbJfwFIvVg.sxDFcYKgJnDxjfXILkfqlvAWDtcEA = ZwaaSKVHGLGqxqZQttITmBfxrCyR;
						jRXtRaceMGLCtGSeRBKbJfwFIvVg.VVOjaMrdNyQSCIKSaeItGpQQTwZpA = QENDHqvPizPzcvbOuDdGIPLbWJpt;
						return jRXtRaceMGLCtGSeRBKbJfwFIvVg;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player bOsBZQuhSpYeaCwOWsUGnESRErwc;

				private readonly ControllerHelper GQmmiMBhGOLNjwDnXBaVVpnoDKYW;

				private readonly int xIMMVCIRsnpxBzHIgWXDrnVrtKXB;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					xIMMVCIRsnpxBzHIgWXDrnVrtKXB = ReInput.id;
					bOsBZQuhSpYeaCwOWsUGnESRErwc = P_0;
					GQmmiMBhGOLNjwDnXBaVVpnoDKYW = P_1;
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => eQSBQmqLTwRhuUylxekiGWaDfrbL(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => GzWdJKsarYahhESZAVGwRyFTejZyA(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => IYjNWCIxsJzRKgkAdhkYtqoJzyFi(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => baorMoaplZEOrGSIsiqnCfbMSYbxA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => nhDOQnrTCebOYOiKhirijQZfJyYoA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => mBHzagaxnNxuLEUmimUHXoowhKqE(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => TUqiwhQjLvZufTFkVbDpzcXbtALo(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => PenBntqoFXexioDwwOdEIAsedTOjA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return QcYBPOFlHoCvgMeaTgMCOBHyYRqAA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return eCJSMNSQPRGRCZjBpQQvrcapPpRk(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return GqfqjJzIVxViJKwuXrMcrAcdFSGhA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return orLrByGshPCOzmtJagYJPUyQsGfH(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => vABajYpytzijePcrwWglGYdxbWoD(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => zElBKQEUAOPfgzyuednAOiGGCDXm(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => tyivptKXYlEQeTxPsINpBkHJFdVS(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => cjyShXbpTklWlZcNBtOTsOnHBwlGA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => EsUYIpCDCaGOJZntqdqjviDLgiUI(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => lZEhuCQkriREQViIorprYYlDkeGx(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => ErhtxgAgnliHKAlcplBOkLDAzgSjA(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => LRDkiSAGvQYeRTHslFhefzchBxJb(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return ZITAySiucyfKAtVJjOyJbTfckzAUb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return LdqiUxHgOMrHdIyoalAJzsVPMldO(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return oyeLObbowmlORfmyvMzGsPjUcLYX(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return CYDCXpqZkAbEBcKHeUFHlFHDQTJK(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => QUdZbpPWhprFHgnMQjnHFauBipYiA(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => OXAuVIxsRbgGybFsywigrlDujRpkA(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => YmGRAshdyHkLzlGjGyZlXnwMuAav(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => vHIwEITgDbvTGBGpyjanHKROYWct(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => IcvtvQIhBlKuiueHleTPJUSSwufV(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => vpnLLupapBwmJFeLPmfUtpODgbWs(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => fNBPDdTwRJHgzxMsMOQYmjokdYDz(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => EdhWwzFSwtXVKZHFWcGTkXMphAiy(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return tTonxxzUomTYLIbhMFqVrZZmHUHy(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return rnSOIhjcEIEhMjKgbAMclPXJitcG(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return mXLvoUInFujahNVPzZHamkdNitnV(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return SWZUqJpaMaifakMXVyCUjHZjfZfZ(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => ooPCkPALUqxwoiFDVBGQAIiHOpAr(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => crpIoDvemoceGdElbBkLPVtvvwiHA(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => zboizwotUrlJNFJwOFKAZhIXjfPl(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => OymKvbDwJeKZLrSBCpfiHjeVxxFd(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => skyDhBTuZYpSmSWGCUPHJlaGccQHA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => zbSATLGQwZRmUujlKNTnqAZAuDNb(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => NSuccAeKLemyvIPFfeePHoSnDQXM(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => vcCVggygRNUvutRzMVNlbAfiLzaJ(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
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
					if (ReInput._id != xIMMVCIRsnpxBzHIgWXDrnVrtKXB)
					{
						ReInput.CheckInitialized(xIMMVCIRsnpxBzHIgWXDrnVrtKXB);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return SvkJxrEfGoQAIsUxIfUotHuiuCpB(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return tbGHhHghhoDDPdpVFIOfMePZGMTR(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return RNBMHMCchzXfWFezvzdzFlknBMfo(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return HkSYRValLQkJgSoxNPrBjqdwbnHx(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool eQSBQmqLTwRhuUylxekiGWaDfrbL(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0 && AiXvIGqWlzUrbAnAWSsKjHIaVjeo(ControllerType.Joystick, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP))
						{
							return true;
						}
					}
					return false;
				}

				private bool nhDOQnrTCebOYOiKhirijQZfJyYoA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0 && YZSdvSSokPIhILvIffrbhfxgHGRi(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP))
						{
							return true;
						}
					}
					return false;
				}

				private bool QcYBPOFlHoCvgMeaTgMCOBHyYRqAA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0.controllerId && lIoesRemfTcsFpMVCrOlAfqLNbBM(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP))
						{
							return true;
						}
					}
					return false;
				}

				private bool GzWdJKsarYahhESZAVGwRyFTejZyA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return AiXvIGqWlzUrbAnAWSsKjHIaVjeo(ControllerType.Keyboard, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private bool mBHzagaxnNxuLEUmimUHXoowhKqE(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return YZSdvSSokPIhILvIffrbhfxgHGRi(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private bool eCJSMNSQPRGRCZjBpQQvrcapPpRk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return lIoesRemfTcsFpMVCrOlAfqLNbBM(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private bool IYjNWCIxsJzRKgkAdhkYtqoJzyFi(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return AiXvIGqWlzUrbAnAWSsKjHIaVjeo(ControllerType.Mouse, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private bool TUqiwhQjLvZufTFkVbDpzcXbtALo(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return YZSdvSSokPIhILvIffrbhfxgHGRi(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private bool GqfqjJzIVxViJKwuXrMcrAcdFSGhA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return lIoesRemfTcsFpMVCrOlAfqLNbBM(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private bool baorMoaplZEOrGSIsiqnCfbMSYbxA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0 && AiXvIGqWlzUrbAnAWSsKjHIaVjeo(ControllerType.Custom, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP))
						{
							return true;
						}
					}
					return false;
				}

				private bool PenBntqoFXexioDwwOdEIAsedTOjA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0 && YZSdvSSokPIhILvIffrbhfxgHGRi(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP))
						{
							return true;
						}
					}
					return false;
				}

				private bool orLrByGshPCOzmtJagYJPUyQsGfH(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0.controllerId && lIoesRemfTcsFpMVCrOlAfqLNbBM(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(GUNbutbtFnuHZMXuBcIjEzdXdBLH))]
				private IEnumerable<ElementAssignmentConflictInfo> vABajYpytzijePcrwWglGYdxbWoD(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new GUNbutbtFnuHZMXuBcIjEzdXdBLH(-2)
					{
						JcYiOkSxyECvHnIGgwmPEETOZbEw = this,
						dnqZYPIhSMMPToKKqVqFYzfYFWkI = P_0,
						mqYAjyBJXjnfCPDkdUrNdlZBQcgSA = P_1,
						JvqCsubOCPydAwCVDOQNLbRRbASm = P_2,
						AepRrZljPsuYRzjnZQaluPHRgRRFA = P_3
					};
				}

				[IteratorStateMachine(typeof(EKfSIgeqlRDfcDVyEULYFnZJQJrB))]
				private IEnumerable<ElementAssignmentConflictInfo> EsUYIpCDCaGOJZntqdqjviDLgiUI(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new EKfSIgeqlRDfcDVyEULYFnZJQJrB(-2)
					{
						gHJMmhelDwWwFONUVweKtXiEYQRE = this,
						TzaOzcISsGDzXFWABGGcBlsIidBh = P_0,
						zkRnkCORzNmSqCJCMEukYbcfqWJu = P_1,
						bjnbhWmaPuEVVuWDpgSbdFLWvJZy = P_2,
						dyIImnVAwWnmPLCIYpjRqtbMFbBv = P_3,
						kjaMEfkajxHgjcgdebtcxKNSOdhXA = P_4
					};
				}

				[IteratorStateMachine(typeof(JRXtRaceMGLCtGSeRBKbJfwFIvVg))]
				private IEnumerable<ElementAssignmentConflictInfo> ZITAySiucyfKAtVJjOyJbTfckzAUb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new JRXtRaceMGLCtGSeRBKbJfwFIvVg(-2)
					{
						JHCSLJgEKbVvVuZyrVuISScuKIte = this,
						GCqfoxeYfkSOUbHCQZZbiSmDIttiA = P_0,
						ZwaaSKVHGLGqxqZQttITmBfxrCyR = P_1,
						QENDHqvPizPzcvbOuDdGIPLbWJpt = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> zElBKQEUAOPfgzyuednAOiGGCDXm(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return nlcRJgZGjVaeSwSCYnYLsAlXEtkHA(ControllerType.Keyboard, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private IEnumerable<ElementAssignmentConflictInfo> lZEhuCQkriREQViIorprYYlDkeGx(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return ZfpzdgqzYqeYwNYCKKVSgFTNLYuS(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private IEnumerable<ElementAssignmentConflictInfo> LdqiUxHgOMrHdIyoalAJzsVPMldO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return emVTAzfANJgbrltFBUThhYwOlDGt(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private IEnumerable<ElementAssignmentConflictInfo> tyivptKXYlEQeTxPsINpBkHJFdVS(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return nlcRJgZGjVaeSwSCYnYLsAlXEtkHA(ControllerType.Mouse, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private IEnumerable<ElementAssignmentConflictInfo> ErhtxgAgnliHKAlcplBOkLDAzgSjA(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return ZfpzdgqzYqeYwNYCKKVSgFTNLYuS(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private IEnumerable<ElementAssignmentConflictInfo> oyeLObbowmlORfmyvMzGsPjUcLYX(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return emVTAzfANJgbrltFBUThhYwOlDGt(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				[IteratorStateMachine(typeof(siQcFxPRSWBWLvucPROkBwUZUcuK))]
				private IEnumerable<ElementAssignmentConflictInfo> cjyShXbpTklWlZcNBtOTsOnHBwlGA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new siQcFxPRSWBWLvucPROkBwUZUcuK(-2)
					{
						MBDJFQuZOQvkcuBuGGGpKDEvtqPG = this,
						AfVaIDKdiyRTrOyrLVFcUczsJWGB = P_0,
						nVVGpCFPKawVDcstIkxBkMpXmYrI = P_1,
						PRkqVoZfqVZGplLsimublbzNeUeG = P_2,
						OLqibNGHtPJwIYDMowqENeAfRPJF = P_3
					};
				}

				[IteratorStateMachine(typeof(ylrxbzNpbymQnTITLDLGKvcDIutdb))]
				private IEnumerable<ElementAssignmentConflictInfo> LRDkiSAGvQYeRTHslFhefzchBxJb(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new ylrxbzNpbymQnTITLDLGKvcDIutdb(-2)
					{
						hWhzHmIjZGWnYAPADgjqKuWvDdMEA = this,
						zHFUdSvmXqBkXEQSbLpDenmvsJrQ = P_0,
						WAgSXDwARqKNsNQjVqMThhKmfjGh = P_1,
						WxFukwwtMXNmMnVxHzRRDuLtbLJI = P_2,
						OpfnnONjpbpzwRSVPvDcbByakHTk = P_3,
						JVXEFydpWDLnieqfhPWGwIpyYbzLA = P_4
					};
				}

				[IteratorStateMachine(typeof(yZWDozDAeacaXzEBduboTcOcKfNL))]
				private IEnumerable<ElementAssignmentConflictInfo> CYDCXpqZkAbEBcKHeUFHlFHDQTJK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new yZWDozDAeacaXzEBduboTcOcKfNL(-2)
					{
						kbTCjCQkPJYPMTIbadDFHJtLqMvY = this,
						LENHPvsxXPQDcTzxNnzscRcZPQvf = P_0,
						JhrRIDtvfQsgckeAkelapcGgketM = P_1,
						GmfMiSRjqpZivnuesMgmfrShnmXN = P_2
					};
				}

				private int QUdZbpPWhprFHgnMQjnHFauBipYiA(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += ELnPjNAsNlaHWEaRGomqNLFrRIDk(ControllerType.Joystick, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
						}
					}
					return num;
				}

				private int IcvtvQIhBlKuiueHleTPJUSSwufV(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += YZDyQugxwyDQFRRifzIoOouoaskiA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
						}
					}
					return num;
				}

				private int tTonxxzUomTYLIbhMFqVrZZmHUHy(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0.controllerId)
						{
							num += rVouhIgNkRzJywdXxUaAuKWTGTBq(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
						}
					}
					return num;
				}

				private int OXAuVIxsRbgGybFsywigrlDujRpkA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return ELnPjNAsNlaHWEaRGomqNLFrRIDk(ControllerType.Keyboard, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private int vpnLLupapBwmJFeLPmfUtpODgbWs(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return YZDyQugxwyDQFRRifzIoOouoaskiA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private int rnSOIhjcEIEhMjKgbAMclPXJitcG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return rVouhIgNkRzJywdXxUaAuKWTGTBq(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF);
				}

				private int YmGRAshdyHkLzlGjGyZlXnwMuAav(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return ELnPjNAsNlaHWEaRGomqNLFrRIDk(ControllerType.Mouse, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private int fNBPDdTwRJHgzxMsMOQYmjokdYDz(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return YZDyQugxwyDQFRRifzIoOouoaskiA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private int mXLvoUInFujahNVPzZHamkdNitnV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return rVouhIgNkRzJywdXxUaAuKWTGTBq(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo);
				}

				private int vHIwEITgDbvTGBGpyjanHKROYWct(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += ELnPjNAsNlaHWEaRGomqNLFrRIDk(ControllerType.Custom, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
						}
					}
					return num;
				}

				private int EdhWwzFSwtXVKZHFWcGTkXMphAiy(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += YZDyQugxwyDQFRRifzIoOouoaskiA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
						}
					}
					return num;
				}

				private int SWZUqJpaMaifakMXVyCUjHZjfZfZ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0.controllerId)
						{
							num += rVouhIgNkRzJywdXxUaAuKWTGTBq(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
						}
					}
					return num;
				}

				private int ooPCkPALUqxwoiFDVBGQAIiHOpAr(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += qEUAPDxjgShFtUBBVETyENyktvle(ControllerType.Joystick, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP, P_4);
						}
					}
					return num;
				}

				private int skyDhBTuZYpSmSWGCUPHJlaGccQHA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += bQAgNIyPRtlntpEYfaTJLMRSqmNL(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP, P_5);
						}
					}
					return num;
				}

				private int SvkJxrEfGoQAIsUxIfUotHuiuCpB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0.controllerId)
						{
							num += DCEdnnFAAwCJgoYvSykYuFprLwbEb(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.RerutvSyIzmYQSLwpqAVLQqcJZSb.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP, P_3);
						}
					}
					return num;
				}

				private int crpIoDvemoceGdElbBkLPVtvvwiHA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return qEUAPDxjgShFtUBBVETyENyktvle(ControllerType.Keyboard, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF, P_3);
				}

				private int zbSATLGQwZRmUujlKNTnqAZAuDNb(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return bQAgNIyPRtlntpEYfaTJLMRSqmNL(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF, P_4);
				}

				private int tbGHhHghhoDDPdpVFIOfMePZGMTR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return DCEdnnFAAwCJgoYvSykYuFprLwbEb(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.UEapLssqzvVHusFKsJEzKqHBIQeF, P_3);
				}

				private int zboizwotUrlJNFJwOFKAZhIXjfPl(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return qEUAPDxjgShFtUBBVETyENyktvle(ControllerType.Mouse, 0, P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo, P_3);
				}

				private int NSuccAeKLemyvIPFfeePHoSnDQXM(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return bQAgNIyPRtlntpEYfaTJLMRSqmNL(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo, P_4);
				}

				private int RNBMHMCchzXfWFezvzdzFlknBMfo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return DCEdnnFAAwCJgoYvSykYuFprLwbEb(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.rsfXuEglhaAlYArNLwHffqTDozVo, P_3);
				}

				private int OymKvbDwJeKZLrSBCpfiHjeVxxFd(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += qEUAPDxjgShFtUBBVETyENyktvle(ControllerType.Custom, P_0, P_1, P_2, P_3, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP, P_4);
						}
					}
					return num;
				}

				private int vcCVggygRNUvutRzMVNlbAfiLzaJ(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							num += bQAgNIyPRtlntpEYfaTJLMRSqmNL(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP, P_5);
						}
					}
					return num;
				}

				private int HkSYRValLQkJgSoxNPrBjqdwbnHx(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.FxvPkjCuyRakVnYBeVfaLDkcEYif(); i++)
					{
						if (GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0.controllerId)
						{
							num += DCEdnnFAAwCJgoYvSykYuFprLwbEb(P_0, P_1, P_2, GQmmiMBhGOLNjwDnXBaVVpnoDKYW.uMUnplavNfXyyPpjOLeReTgUViSF.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i).AhOWBwQXlUjEXgrPOgQMKEMCgKcP, P_3);
						}
					}
					return num;
				}

				private bool AiXvIGqWlzUrbAnAWSsKjHIaVjeo<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_5.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool YZSdvSSokPIhILvIffrbhfxgHGRi<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_6.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool lIoesRemfTcsFpMVCrOlAfqLNbBM<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_3.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(ZgPFKKOjLRdtGUKqgznMEWszhGN))]
				private IEnumerable<ElementAssignmentConflictInfo> nlcRJgZGjVaeSwSCYnYLsAlXEtkHA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_5) where _0001 : ControllerMap
				{
					return new ZgPFKKOjLRdtGUKqgznMEWszhGN<_0001>(-2)
					{
						vxzTiWyKruvXSBcojcFNqKsPFoew = this,
						LecELpOuUlaezlrqyMlbtNsExoFy = P_0,
						sjlcPTeZhPPAGOkgUHwAhrxqZAuOA = P_1,
						dQmrFhoYXJLpENFgtYlrjAjnarlu = P_2,
						MqEKSHEPAAwrDATyNJFiJYVVkiEO = P_3,
						FcXsTTQixCANZJYFrJRFMlAgoEXdA = P_4,
						CjCLKQAyljbDYnHxyUCOtCRnBGNb = P_5
					};
				}

				[IteratorStateMachine(typeof(uvwEOoUpTpqQGRNorBVSdxXaCXiBb))]
				private IEnumerable<ElementAssignmentConflictInfo> ZfpzdgqzYqeYwNYCKKVSgFTNLYuS<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_6) where _0001 : ControllerMap
				{
					return new uvwEOoUpTpqQGRNorBVSdxXaCXiBb<_0001>(-2)
					{
						UnCWEPbSnVRzZVOmYCCQooCpVsWb = this,
						KcLJAtEnihKdAdaHkWmPwmPLjFKIA = P_0,
						MRamlApvtWSqrhXuYUUHXWuhpJDd = P_1,
						jTXMabZCrpyBrHkmhNdKxjYtmDNs = P_2,
						ltDsJDcJHEkeutYYZuNniklYBunm = P_3,
						DCtcrhOqzvouyeXxghStcVqwqbhH = P_4,
						oYebwWBVKPwFzpvPSMZveluBjffpA = P_5,
						gmdCdUiJUlKqoqtiFkfScOHGKMUD = P_6
					};
				}

				[IteratorStateMachine(typeof(NeycWLBWIaTROcCdASLSsjjEuMfb))]
				private IEnumerable<ElementAssignmentConflictInfo> emVTAzfANJgbrltFBUThhYwOlDGt<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_3) where _0001 : ControllerMap
				{
					return new NeycWLBWIaTROcCdASLSsjjEuMfb<_0001>(-2)
					{
						LrtWHXttGTzDYTEoXJpyRfoQKLKx = this,
						aiMHpwTxIcpmLQCKPBeNGYZPIDMt = P_0,
						HxNNpppPZFEdHrRVfcXnbXZdkuAp = P_1,
						rCLtsVtLGbvDVeAGoDOXcJfcqjSqA = P_2,
						iHcGagnCJfpaiihMKvJQMmaOzxxb = P_3
					};
				}

				private int ELnPjNAsNlaHWEaRGomqNLFrRIDk<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_5.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int YZDyQugxwyDQFRRifzIoOouoaskiA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_6.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int rVouhIgNkRzJywdXxUaAuKWTGTBq<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_3.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int qEUAPDxjgShFtUBBVETyENyktvle<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_5.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(mapCategory, controllerMap)))
						{
							num += controllerMap.wGJXfttiznxlxdlGIfuiHggUqnTV(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int bQAgNIyPRtlntpEYfaTJLMRSqmNL<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_6.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(inputMapCategory, controllerMap)))
						{
							num += controllerMap.mHsExafuwcnSQXWQrJQEBJLSIWLCA(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int DCEdnnFAAwCJgoYvSykYuFprLwbEb<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.YzKYnaKJzjbvJEXDdyXusrltRUPjA(); i++)
					{
						ControllerMap controllerMap = P_3.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !NbQXMaNGdbaNmhZMeGgnOfGXqNReb(inputMapCategory, controllerMap)))
						{
							num += controllerMap.MZIiBSxUJkBlkAMDPNstKEDPEHpn(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool NbQXMaNGdbaNmhZMeGgnOfGXqNReb(InputMapCategory P_0, ControllerMap P_1)
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
			internal interface jpRWCWnSWjIHbShgmaKtrbKdevFr
			{
				wczNLWUjiDwjnkhfMjCrRBaAdUQr mcFUzMKPJFShpANCCeazIgkMQnkKA { get; }

				ControllerType MpzowibvORwAEjBGqRZIiSHQOVec { get; }

				int flFZvPVsPcNnBeWIGSaTgKMcStvJ { get; }

				bool OXQcHLrQpAEUmCnAIGUgeOPvaaHO(Controller P_0);

				bool GRMIiFyjqWcQFahZLMeaEplJYumtB(int P_0);

				void rWiPalmtgflXjFGWQDhXctDypNop(int P_0);

				void ersjwnmOVgjTVBpdJTTZTLqKDTwEA(Controller P_0);

				void QnObWMMHibUgrDdgMWrcUIjBXRYc(int P_0);

				Controller fTvKlfcMwIZxZSoxSPJHwjMOhRgkA(int P_0);

				Controller orcFyEysCJMuBrOvToMRIdIWcfMEA(string P_0);

				int KzJAbgcCWGrCyyvJCqKgCbTWNxBH(Controller P_0);

				int pkBnWPGhiVStKNCTHndxrrusHaYt(int P_0);

				int ZzZNzSiGcySMnWRIxbnLOJGRdZvBA(string P_0);

				void kAZHRZGWBRTUOiPyceAuqAENqxgtA();

				wczNLWUjiDwjnkhfMjCrRBaAdUQr iueOmjDBOlDOqNGYWGAHBWIslogRA(int P_0);

				wczNLWUjiDwjnkhfMjCrRBaAdUQr LjcKgiNFTsAiJOuexMiTFOdugAEy(Controller P_0);

				void QyjajlnRkTYODzAYNObNbrAGHPN(wczNLWUjiDwjnkhfMjCrRBaAdUQr P_0);
			}

			internal interface wczNLWUjiDwjnkhfMjCrRBaAdUQr
			{
				jeabHUrstoKHDRpNBCZSFbPvOBSHb YjPKnaUBIafYYbhEPJJXDUgXqwPK { get; }

				Controller LEdXAULnordCtHuhKNePXQiSgnCX { get; }

				double YqUvlKjdcOagFIswNEKIDRXForJxb { get; }
			}

			[DefaultMember("Item")]
			internal sealed class fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<_0001, _0002> : jpRWCWnSWjIHbShgmaKtrbKdevFr where _0001 : Controller where _0002 : ControllerMap
			{
				public class wwphrnUdZYgdrhKBPyggpYmosQFH : wczNLWUjiDwjnkhfMjCrRBaAdUQr
				{
					public _0001 BYlFGRIAVlFFEDTQdwYJaaaeCxfbB;

					public global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0002> AhOWBwQXlUjEXgrPOgQMKEMCgKcP;

					public double PBTyvgbNlEbCnJYjaYEXEbrvyqpr;

					Controller wczNLWUjiDwjnkhfMjCrRBaAdUQr.DjDErhGBPfNkKGTFgORLxjcNReFZ => BYlFGRIAVlFFEDTQdwYJaaaeCxfbB;

					jeabHUrstoKHDRpNBCZSFbPvOBSHb wczNLWUjiDwjnkhfMjCrRBaAdUQr.YHGAVEVKNbiPqXwrcVSccYGyeuqn => AhOWBwQXlUjEXgrPOgQMKEMCgKcP;

					double wczNLWUjiDwjnkhfMjCrRBaAdUQr.UtaiopBRAYORZUFPPjALoauHrrXb => PBTyvgbNlEbCnJYjaYEXEbrvyqpr;

					public wwphrnUdZYgdrhKBPyggpYmosQFH(_0001 P_0, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0002> P_1)
					{
						BYlFGRIAVlFFEDTQdwYJaaaeCxfbB = P_0;
						AhOWBwQXlUjEXgrPOgQMKEMCgKcP = P_1;
					}

					public void egavmYiJFmhkhgXYJcUcuknwANUBb()
					{
						PBTyvgbNlEbCnJYjaYEXEbrvyqpr = ReInput.unscaledTime;
					}
				}

				private List<wwphrnUdZYgdrhKBPyggpYmosQFH> kkozwWsoEWNQQGdELELlpbbVcbGP;

				private List<_0001> SQiydlFglHPyESFjKEyOwSJcEZADA;

				private ReadOnlyCollection<_0001> CPPgyaEWFnDvvdJcKFAiIyLtHonj;

				private readonly ControllerType xUnwtKzuHiubKfXcbodYhbqQwCTK;

				int jpRWCWnSWjIHbShgmaKtrbKdevFr.flFZvPVsPcNnBeWIGSaTgKMcStvJ => kkozwWsoEWNQQGdELELlpbbVcbGP.Count;

				public IList<_0001> ZiXPUFLXNqwSVjqWhnioHgxwxwAp => CPPgyaEWFnDvvdJcKFAiIyLtHonj;

				public wwphrnUdZYgdrhKBPyggpYmosQFH ljMnVRSbxMufuMVTnbqBFaEdqaqD => kkozwWsoEWNQQGdELELlpbbVcbGP[P_0];

				ControllerType jpRWCWnSWjIHbShgmaKtrbKdevFr.MpzowibvORwAEjBGqRZIiSHQOVec => xUnwtKzuHiubKfXcbodYhbqQwCTK;

				wczNLWUjiDwjnkhfMjCrRBaAdUQr jpRWCWnSWjIHbShgmaKtrbKdevFr.vRdBffgwwheyNMfICDPhzfCYKgiL => kkozwWsoEWNQQGdELELlpbbVcbGP[index];

				public fxgNmVGnKrGZwkEOjCQYjAEXUlWcA()
				{
					if ((object)moNrVnhMyxFSevnVWYTclYHmdtVI.UcymfpEUEGwogwpzEombQtOGDEmq<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					xUnwtKzuHiubKfXcbodYhbqQwCTK = moNrVnhMyxFSevnVWYTclYHmdtVI.NiWZsfpPqypjVjipJZcZdwmeDEYA(typeof(_0001));
					kkozwWsoEWNQQGdELELlpbbVcbGP = new List<wwphrnUdZYgdrhKBPyggpYmosQFH>();
					SQiydlFglHPyESFjKEyOwSJcEZADA = new List<_0001>();
					CPPgyaEWFnDvvdJcKFAiIyLtHonj = new ReadOnlyCollection<_0001>(SQiydlFglHPyESFjKEyOwSJcEZADA);
				}

				public wwphrnUdZYgdrhKBPyggpYmosQFH nuzvKpMFgfSRontADHNZOUDjjjxR(int P_0)
				{
					if (xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Keyboard || xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = hhvPpFHZoVsXHrpdSdaFJrOgAWLz(P_0);
					if (num < 0)
					{
						return null;
					}
					return kkozwWsoEWNQQGdELELlpbbVcbGP[num];
				}

				public wwphrnUdZYgdrhKBPyggpYmosQFH JFfhBeLWUrUmZrYchXJtjkWtOWBC(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return nuzvKpMFgfSRontADHNZOUDjjjxR(P_0.id);
				}

				public void VZPZXaCAQnTZJiqvFELiSkGJpUxp(wwphrnUdZYgdrhKBPyggpYmosQFH P_0)
				{
					if (P_0 != null)
					{
						kkozwWsoEWNQQGdELELlpbbVcbGP.Add(P_0);
						SQiydlFglHPyESFjKEyOwSJcEZADA.Add(P_0.BYlFGRIAVlFFEDTQdwYJaaaeCxfbB);
					}
				}

				public void VSaIJdTauWWArwdLyVcqxtXtgLUD(int P_0)
				{
					if (xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Keyboard || xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (hhvPpFHZoVsXHrpdSdaFJrOgAWLz(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < kkozwWsoEWNQQGdELELlpbbVcbGP.Count; i++)
					{
						if (kkozwWsoEWNQQGdELELlpbbVcbGP[i].BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							ugYmbeMkqzmVlmLLObUPFCFEwTvOA(i);
							break;
						}
					}
				}

				void jpRWCWnSWjIHbShgmaKtrbKdevFr.rWiPalmtgflXjFGWQDhXctDypNop(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in VSaIJdTauWWArwdLyVcqxtXtgLUD
					this.VSaIJdTauWWArwdLyVcqxtXtgLUD(P_0);
				}

				public void OTtfITvTCKDDKsdNSVEBrdihAUnA(_0001 P_0)
				{
					if (P_0 != null && P_0.type == xUnwtKzuHiubKfXcbodYhbqQwCTK)
					{
						VSaIJdTauWWArwdLyVcqxtXtgLUD(P_0.id);
					}
				}

				public void ugYmbeMkqzmVlmLLObUPFCFEwTvOA(int P_0)
				{
					if (P_0 >= 0 && P_0 < kkozwWsoEWNQQGdELELlpbbVcbGP.Count)
					{
						kkozwWsoEWNQQGdELELlpbbVcbGP.RemoveAt(P_0);
						SQiydlFglHPyESFjKEyOwSJcEZADA.RemoveAt(P_0);
					}
				}

				void jpRWCWnSWjIHbShgmaKtrbKdevFr.QnObWMMHibUgrDdgMWrcUIjBXRYc(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in ugYmbeMkqzmVlmLLObUPFCFEwTvOA
					this.ugYmbeMkqzmVlmLLObUPFCFEwTvOA(P_0);
				}

				public _0001 qFpfRnHQpApgQCDpHUWhKxHZUwbYA(int P_0)
				{
					if (xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Keyboard || xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = hhvPpFHZoVsXHrpdSdaFJrOgAWLz(P_0);
					if (num < 0)
					{
						return null;
					}
					return kkozwWsoEWNQQGdELELlpbbVcbGP[num].BYlFGRIAVlFFEDTQdwYJaaaeCxfbB;
				}

				public bool TRCxezKDZlAgopMIDVGLVFjrsFNe(int P_0)
				{
					if (xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Keyboard || xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < kkozwWsoEWNQQGdELELlpbbVcbGP.Count; i++)
					{
						if (kkozwWsoEWNQQGdELELlpbbVcbGP[i].BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool jpRWCWnSWjIHbShgmaKtrbKdevFr.GRMIiFyjqWcQFahZLMeaEplJYumtB(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in TRCxezKDZlAgopMIDVGLVFjrsFNe
					return this.TRCxezKDZlAgopMIDVGLVFjrsFNe(P_0);
				}

				public bool xVtajuNWyZDbMgskkQERjhnoVMGEA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != xUnwtKzuHiubKfXcbodYhbqQwCTK)
					{
						return false;
					}
					return TRCxezKDZlAgopMIDVGLVFjrsFNe(P_0.id);
				}

				public int hhvPpFHZoVsXHrpdSdaFJrOgAWLz(int P_0)
				{
					if (xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Keyboard || xUnwtKzuHiubKfXcbodYhbqQwCTK == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < kkozwWsoEWNQQGdELELlpbbVcbGP.Count; i++)
					{
						if (kkozwWsoEWNQQGdELELlpbbVcbGP[i].BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int jpRWCWnSWjIHbShgmaKtrbKdevFr.pkBnWPGhiVStKNCTHndxrrusHaYt(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in hhvPpFHZoVsXHrpdSdaFJrOgAWLz
					return this.hhvPpFHZoVsXHrpdSdaFJrOgAWLz(P_0);
				}

				public int TaYLWHWjXqdfcDdPLIGtgEcMxcHdA(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != xUnwtKzuHiubKfXcbodYhbqQwCTK)
					{
						return -1;
					}
					return hhvPpFHZoVsXHrpdSdaFJrOgAWLz(P_0.id);
				}

				public int SBqEimgcbQQgEJWfmBRLZorUuCxE(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < kkozwWsoEWNQQGdELELlpbbVcbGP.Count; i++)
					{
						if (kkozwWsoEWNQQGdELELlpbbVcbGP[i].BYlFGRIAVlFFEDTQdwYJaaaeCxfbB.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int jpRWCWnSWjIHbShgmaKtrbKdevFr.ZzZNzSiGcySMnWRIxbnLOJGRdZvBA(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SBqEimgcbQQgEJWfmBRLZorUuCxE
					return this.SBqEimgcbQQgEJWfmBRLZorUuCxE(P_0);
				}

				public void DbNNHsjjBQBcQSqpHjmwwBnmfXkc()
				{
					kkozwWsoEWNQQGdELELlpbbVcbGP.Clear();
					SQiydlFglHPyESFjKEyOwSJcEZADA.Clear();
				}

				void jpRWCWnSWjIHbShgmaKtrbKdevFr.kAZHRZGWBRTUOiPyceAuqAENqxgtA()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DbNNHsjjBQBcQSqpHjmwwBnmfXkc
					this.DbNNHsjjBQBcQSqpHjmwwBnmfXkc();
				}

				wczNLWUjiDwjnkhfMjCrRBaAdUQr jpRWCWnSWjIHbShgmaKtrbKdevFr.GetEntry(int controllerId)
				{
					return nuzvKpMFgfSRontADHNZOUDjjjxR(controllerId);
				}

				wczNLWUjiDwjnkhfMjCrRBaAdUQr jpRWCWnSWjIHbShgmaKtrbKdevFr.GetEntry(Controller controller)
				{
					if (controller as _0001 == null)
					{
						return null;
					}
					return JFfhBeLWUrUmZrYchXJtjkWtOWBC(controller as _0001);
				}

				void jpRWCWnSWjIHbShgmaKtrbKdevFr.AddEntry(wczNLWUjiDwjnkhfMjCrRBaAdUQr entry)
				{
					VZPZXaCAQnTZJiqvFELiSkGJpUxp((wwphrnUdZYgdrhKBPyggpYmosQFH)entry);
				}

				void jpRWCWnSWjIHbShgmaKtrbKdevFr.RemoveController(Controller controller)
				{
					OTtfITvTCKDDKsdNSVEBrdihAUnA(controller as _0001);
				}

				Controller jpRWCWnSWjIHbShgmaKtrbKdevFr.GetController(int controllerId)
				{
					return qFpfRnHQpApgQCDpHUWhKxHZUwbYA(controllerId);
				}

				bool jpRWCWnSWjIHbShgmaKtrbKdevFr.Contains(Controller controller)
				{
					return xVtajuNWyZDbMgskkQERjhnoVMGEA(controller as _0001);
				}

				int jpRWCWnSWjIHbShgmaKtrbKdevFr.IndexOf(Controller controller)
				{
					return TaYLWHWjXqdfcDdPLIGtgEcMxcHdA(controller as _0001);
				}

				Controller jpRWCWnSWjIHbShgmaKtrbKdevFr.GetControllerWithTag(string tag)
				{
					int num = SBqEimgcbQQgEJWfmBRLZorUuCxE(tag);
					if (num < 0)
					{
						return null;
					}
					return kkozwWsoEWNQQGdELELlpbbVcbGP[num].BYlFGRIAVlFFEDTQdwYJaaaeCxfbB;
				}
			}

			internal class dOKBRfwFUAFZTvAdwxGpaPOGhqvv
			{
				public readonly int qQKAnjIDCwrNyABAEPmVWZtlKjkKc;

				private ControllerType[] CkYQxRXSTxgfzkBwRJKEPKHyMUID;

				private jpRWCWnSWjIHbShgmaKtrbKdevFr[] JtOdKHVOgMdXbXIyVKJQOaYlHbT;

				public jpRWCWnSWjIHbShgmaKtrbKdevFr iFkHZDHCCVPAOUDYaCFscxifVwhzB(int P_0)
				{
					return JtOdKHVOgMdXbXIyVKJQOaYlHbT[P_0];
				}

				public ControllerType bJhBQizlEpwNfJaJnhMIhzolqdW(int P_0)
				{
					return CkYQxRXSTxgfzkBwRJKEPKHyMUID[P_0];
				}

				public dOKBRfwFUAFZTvAdwxGpaPOGhqvv(int P_0)
				{
					qQKAnjIDCwrNyABAEPmVWZtlKjkKc = MathTools.Max(0, P_0);
					CkYQxRXSTxgfzkBwRJKEPKHyMUID = new ControllerType[P_0];
					JtOdKHVOgMdXbXIyVKJQOaYlHbT = new jpRWCWnSWjIHbShgmaKtrbKdevFr[P_0];
				}

				public jpRWCWnSWjIHbShgmaKtrbKdevFr eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType P_0)
				{
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						if (P_0 == CkYQxRXSTxgfzkBwRJKEPKHyMUID[i])
						{
							return JtOdKHVOgMdXbXIyVKJQOaYlHbT[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void EVIMNCRYSOPVVpSUlmkTJFyiCntt(int P_0, ControllerType P_1, jpRWCWnSWjIHbShgmaKtrbKdevFr P_2)
				{
					CkYQxRXSTxgfzkBwRJKEPKHyMUID[P_0] = P_1;
					JtOdKHVOgMdXbXIyVKJQOaYlHbT[P_0] = P_2;
				}
			}

			private class yWllGWQoPyFKMJvrPnBBdNNybQBW
			{
				public class YeqQXpXjuyYaOpdrgiOMyCqvDbkGA
				{
					public int kQzrjAPnruplFGewAqdPgodltsZu;

					public global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> BPxFSLqVTGkaeMfHuAzHETrFbjbNA;

					public double uVOYzEyfCFyDpJCynEYqEsDaFYjB;

					public YeqQXpXjuyYaOpdrgiOMyCqvDbkGA(int P_0, global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> P_1, double P_2)
					{
						kQzrjAPnruplFGewAqdPgodltsZu = P_0;
						BPxFSLqVTGkaeMfHuAzHETrFbjbNA = P_1;
						uVOYzEyfCFyDpJCynEYqEsDaFYjB = P_2;
					}
				}

				private readonly List<YeqQXpXjuyYaOpdrgiOMyCqvDbkGA> fnGRBUmEcMIPFVugmfNLHSWZKgzEA;

				private readonly Player WjgxwpUQedgmJLKANksSAiSwQBPK;

				public yWllGWQoPyFKMJvrPnBBdNNybQBW(Player P_0)
				{
					WjgxwpUQedgmJLKANksSAiSwQBPK = P_0;
					fnGRBUmEcMIPFVugmfNLHSWZKgzEA = new List<YeqQXpXjuyYaOpdrgiOMyCqvDbkGA>();
				}

				public void WMFAKIKcCqiTfZxqBQjkdOyRFMqFb(Joystick P_0, global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> P_1)
				{
					for (int i = 0; i < fnGRBUmEcMIPFVugmfNLHSWZKgzEA.Count; i++)
					{
						YeqQXpXjuyYaOpdrgiOMyCqvDbkGA yeqQXpXjuyYaOpdrgiOMyCqvDbkGA = fnGRBUmEcMIPFVugmfNLHSWZKgzEA[i];
						if (yeqQXpXjuyYaOpdrgiOMyCqvDbkGA.kQzrjAPnruplFGewAqdPgodltsZu == P_0.id)
						{
							yeqQXpXjuyYaOpdrgiOMyCqvDbkGA.BPxFSLqVTGkaeMfHuAzHETrFbjbNA = P_1;
							yeqQXpXjuyYaOpdrgiOMyCqvDbkGA.uVOYzEyfCFyDpJCynEYqEsDaFYjB = ReInput.realTime;
							return;
						}
					}
					YeqQXpXjuyYaOpdrgiOMyCqvDbkGA item = new YeqQXpXjuyYaOpdrgiOMyCqvDbkGA(P_0.id, P_1, ReInput.realTime);
					fnGRBUmEcMIPFVugmfNLHSWZKgzEA.Add(item);
				}

				public void WUuGYgoRoIjAECEpfGbEYErcjygAA(fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH P_0)
				{
					WMFAKIKcCqiTfZxqBQjkdOyRFMqFb(P_0.BYlFGRIAVlFFEDTQdwYJaaaeCxfbB, P_0.AhOWBwQXlUjEXgrPOgQMKEMCgKcP);
				}

				public void WqaagYnLMSptLCatcguZFtiufblBb()
				{
					for (int i = 0; i < fnGRBUmEcMIPFVugmfNLHSWZKgzEA.Count; i++)
					{
						if (!WjgxwpUQedgmJLKANksSAiSwQBPK.controllers.ContainsController(ControllerType.Joystick, fnGRBUmEcMIPFVugmfNLHSWZKgzEA[i].kQzrjAPnruplFGewAqdPgodltsZu))
						{
							fnGRBUmEcMIPFVugmfNLHSWZKgzEA[i].BPxFSLqVTGkaeMfHuAzHETrFbjbNA = null;
						}
					}
				}

				public YeqQXpXjuyYaOpdrgiOMyCqvDbkGA LNWTOyVdpvmbdZHTOelMXotPbIZCA(int P_0)
				{
					int num = UjYXoYRWQnqWTSCKsScLIVJEBhii(P_0);
					if (num < 0)
					{
						return null;
					}
					return fnGRBUmEcMIPFVugmfNLHSWZKgzEA[num];
				}

				public bool pibgLBQvNDpaCaXAlyfluXqviFaj(int P_0)
				{
					for (int i = 0; i < fnGRBUmEcMIPFVugmfNLHSWZKgzEA.Count; i++)
					{
						if (fnGRBUmEcMIPFVugmfNLHSWZKgzEA[i].kQzrjAPnruplFGewAqdPgodltsZu == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int UjYXoYRWQnqWTSCKsScLIVJEBhii(int P_0)
				{
					for (int i = 0; i < fnGRBUmEcMIPFVugmfNLHSWZKgzEA.Count; i++)
					{
						if (fnGRBUmEcMIPFVugmfNLHSWZKgzEA[i].kQzrjAPnruplFGewAqdPgodltsZu == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void CIKhLotFEloHxeXaEHnWWrcoXigg()
				{
					fnGRBUmEcMIPFVugmfNLHSWZKgzEA.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class TDIAedsMFJMMYTGWnqTyVqfwbDEO : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int mnflldJcUicBIyOJmKPoNnAkEkegA;

					private ActionElementMap OStDctIQYeODJGIQCmZYXxahUUDAc;

					private int JHFQTQqDxOpWDceXPPyMjBFDysLn;

					public MapHelper TKkDjTkEPgDMeYZXTVSwMJPksLqz;

					private int TtLEQSVylVEVLBcLYaWTlQqlxDDr;

					public int veGEGEUuariQiHiJtWYkjaIgmStn;

					private bool vVfLMjsxCuWJoTdqaaoiSVtKXftK;

					public bool XIdfHxxKSpxeMQMiwDbuDaLNOJwX;

					private int lmZNDnxDSECjYAYZeAVVIiPkmSnu;

					private int abhhAHmArVsxqUzJqvNydaKhGlsy;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr AMEtDgXnwIymSoBbgdzDwKngtARk;

					private int TElWVPsyvWpyyQIpSpjcjqZSjbnd;

					private int hrLtZEtyWKGEtRatpQzORfUMyOZH;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb zQMXgMgAeqPjFNtlxEbkPRNrKRgN;

					private int DStCTKwcGSfKgjQCLfsHpTDQevVeA;

					private int HsLBIeRPohDJqyUEHyZXLGJdEROD;

					private IEnumerator<ActionElementMap> YjQieMxsWiBZhcUjADobTNGFxeZK;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return OStDctIQYeODJGIQCmZYXxahUUDAc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OStDctIQYeODJGIQCmZYXxahUUDAc;
						}
					}

					[DebuggerHidden]
					public TDIAedsMFJMMYTGWnqTyVqfwbDEO(int P_0)
					{
						mnflldJcUicBIyOJmKPoNnAkEkegA = P_0;
						JHFQTQqDxOpWDceXPPyMjBFDysLn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mnflldJcUicBIyOJmKPoNnAkEkegA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								fNdvqscxRJgsasyGwFoGpgDTclrx();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = mnflldJcUicBIyOJmKPoNnAkEkegA;
							MapHelper tKkDjTkEPgDMeYZXTVSwMJPksLqz = TKkDjTkEPgDMeYZXTVSwMJPksLqz;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mnflldJcUicBIyOJmKPoNnAkEkegA = -3;
								goto IL_0177;
							}
							mnflldJcUicBIyOJmKPoNnAkEkegA = -1;
							if (ReInput._id != tKkDjTkEPgDMeYZXTVSwMJPksLqz.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
							{
								ReInput.CheckInitialized(tKkDjTkEPgDMeYZXTVSwMJPksLqz.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
								return false;
							}
							if (TtLEQSVylVEVLBcLYaWTlQqlxDDr < 0)
							{
								return false;
							}
							lmZNDnxDSECjYAYZeAVVIiPkmSnu = tKkDjTkEPgDMeYZXTVSwMJPksLqz.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
							abhhAHmArVsxqUzJqvNydaKhGlsy = 0;
							goto IL_01f7;
							IL_0177:
							if (YjQieMxsWiBZhcUjADobTNGFxeZK.MoveNext())
							{
								ActionElementMap current = YjQieMxsWiBZhcUjADobTNGFxeZK.Current;
								OStDctIQYeODJGIQCmZYXxahUUDAc = current;
								mnflldJcUicBIyOJmKPoNnAkEkegA = 1;
								return true;
							}
							fNdvqscxRJgsasyGwFoGpgDTclrx();
							YjQieMxsWiBZhcUjADobTNGFxeZK = null;
							goto IL_0191;
							IL_0191:
							HsLBIeRPohDJqyUEHyZXLGJdEROD++;
							goto IL_01a3;
							IL_01cd:
							if (hrLtZEtyWKGEtRatpQzORfUMyOZH < TElWVPsyvWpyyQIpSpjcjqZSjbnd)
							{
								zQMXgMgAeqPjFNtlxEbkPRNrKRgN = AMEtDgXnwIymSoBbgdzDwKngtARk.AWmOltvgZLyyeShVGMDDYeiwNhPG(hrLtZEtyWKGEtRatpQzORfUMyOZH).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								DStCTKwcGSfKgjQCLfsHpTDQevVeA = zQMXgMgAeqPjFNtlxEbkPRNrKRgN.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								HsLBIeRPohDJqyUEHyZXLGJdEROD = 0;
								goto IL_01a3;
							}
							AMEtDgXnwIymSoBbgdzDwKngtARk = null;
							abhhAHmArVsxqUzJqvNydaKhGlsy++;
							goto IL_01f7;
							IL_01a3:
							if (HsLBIeRPohDJqyUEHyZXLGJdEROD < DStCTKwcGSfKgjQCLfsHpTDQevVeA)
							{
								if (zQMXgMgAeqPjFNtlxEbkPRNrKRgN.sraFvIhbtwaREyBqnZUbJclkEDGC(HsLBIeRPohDJqyUEHyZXLGJdEROD) is ControllerMapWithAxes controllerMapWithAxes && (!vVfLMjsxCuWJoTdqaaoiSVtKXftK || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(TtLEQSVylVEVLBcLYaWTlQqlxDDr))
								{
									YjQieMxsWiBZhcUjADobTNGFxeZK = controllerMapWithAxes.AxisMapsWithAction(TtLEQSVylVEVLBcLYaWTlQqlxDDr, vVfLMjsxCuWJoTdqaaoiSVtKXftK).GetEnumerator();
									mnflldJcUicBIyOJmKPoNnAkEkegA = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							zQMXgMgAeqPjFNtlxEbkPRNrKRgN = null;
							hrLtZEtyWKGEtRatpQzORfUMyOZH++;
							goto IL_01cd;
							IL_01f7:
							if (abhhAHmArVsxqUzJqvNydaKhGlsy < lmZNDnxDSECjYAYZeAVVIiPkmSnu)
							{
								AMEtDgXnwIymSoBbgdzDwKngtARk = tKkDjTkEPgDMeYZXTVSwMJPksLqz.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(abhhAHmArVsxqUzJqvNydaKhGlsy);
								TElWVPsyvWpyyQIpSpjcjqZSjbnd = AMEtDgXnwIymSoBbgdzDwKngtARk.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
								hrLtZEtyWKGEtRatpQzORfUMyOZH = 0;
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

					private void fNdvqscxRJgsasyGwFoGpgDTclrx()
					{
						mnflldJcUicBIyOJmKPoNnAkEkegA = -1;
						if (YjQieMxsWiBZhcUjADobTNGFxeZK != null)
						{
							YjQieMxsWiBZhcUjADobTNGFxeZK.Dispose();
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
						TDIAedsMFJMMYTGWnqTyVqfwbDEO tDIAedsMFJMMYTGWnqTyVqfwbDEO;
						if (mnflldJcUicBIyOJmKPoNnAkEkegA == -2 && JHFQTQqDxOpWDceXPPyMjBFDysLn == Environment.CurrentManagedThreadId)
						{
							mnflldJcUicBIyOJmKPoNnAkEkegA = 0;
							tDIAedsMFJMMYTGWnqTyVqfwbDEO = this;
						}
						else
						{
							tDIAedsMFJMMYTGWnqTyVqfwbDEO = new TDIAedsMFJMMYTGWnqTyVqfwbDEO(0);
							tDIAedsMFJMMYTGWnqTyVqfwbDEO.TKkDjTkEPgDMeYZXTVSwMJPksLqz = TKkDjTkEPgDMeYZXTVSwMJPksLqz;
						}
						tDIAedsMFJMMYTGWnqTyVqfwbDEO.TtLEQSVylVEVLBcLYaWTlQqlxDDr = veGEGEUuariQiHiJtWYkjaIgmStn;
						tDIAedsMFJMMYTGWnqTyVqfwbDEO.vVfLMjsxCuWJoTdqaaoiSVtKXftK = XIdfHxxKSpxeMQMiwDbuDaLNOJwX;
						return tDIAedsMFJMMYTGWnqTyVqfwbDEO;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class CNawMvTbvBrqEThxvvDpbauqnZgd : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int hEcWVaBvgAUhiKaeMDpswcKypciJ;

					private ActionElementMap SGiaNYEDMjKqwdANNJrxgYNNcCyV;

					private int cTnQIeWLNXKmsGCLEWYvTsPCjCOI;

					public MapHelper ZfEEXsTJXekEOgYhwJzsdatKDZDQ;

					private int ZPdvdTlcCGCbPOdrkRbluwflQRFk;

					public int LCWVHBUCxNAKUXJasvPIBeGEfxrE;

					private bool ZcvKKSSndYYDihAqJCTECWJnFtVrA;

					public bool vwxtSFZKBmcidybeWnDbumIzfmnCA;

					private int sEiYWtdWHojzHjwXTKzteIbOvJxQ;

					private int nKHxYChnwJPCOCWqFDKTBDrnwfpL;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr kBGnLMMjYYGiCycmvIbbiYNcnhYb;

					private int nluATnKleBfPiCtmeSAUTbaMGYDdc;

					private int JKjAQtnhQtvWzYylJEFoHPgjGzIv;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb ZpnGGfLdvSVZZkgyhzXoIxGXjuIg;

					private int MbVOaKUxlmcdurjcRsTIyAMMgqDcA;

					private int ppmecWhQwViVhCYxgEtYixjybzXHb;

					private IEnumerator<ActionElementMap> NyGsLVTrvYyagGDGaAqvlDBVhPmBA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return SGiaNYEDMjKqwdANNJrxgYNNcCyV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SGiaNYEDMjKqwdANNJrxgYNNcCyV;
						}
					}

					[DebuggerHidden]
					public CNawMvTbvBrqEThxvvDpbauqnZgd(int P_0)
					{
						hEcWVaBvgAUhiKaeMDpswcKypciJ = P_0;
						cTnQIeWLNXKmsGCLEWYvTsPCjCOI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hEcWVaBvgAUhiKaeMDpswcKypciJ;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								YaFJeOvTBfWAPpeQTsYpMVJtYenK();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hEcWVaBvgAUhiKaeMDpswcKypciJ;
							MapHelper zfEEXsTJXekEOgYhwJzsdatKDZDQ = ZfEEXsTJXekEOgYhwJzsdatKDZDQ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hEcWVaBvgAUhiKaeMDpswcKypciJ = -3;
								goto IL_016c;
							}
							hEcWVaBvgAUhiKaeMDpswcKypciJ = -1;
							if (ReInput._id != zfEEXsTJXekEOgYhwJzsdatKDZDQ.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
							{
								ReInput.CheckInitialized(zfEEXsTJXekEOgYhwJzsdatKDZDQ.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
								return false;
							}
							if (ZPdvdTlcCGCbPOdrkRbluwflQRFk < 0)
							{
								return false;
							}
							sEiYWtdWHojzHjwXTKzteIbOvJxQ = zfEEXsTJXekEOgYhwJzsdatKDZDQ.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
							nKHxYChnwJPCOCWqFDKTBDrnwfpL = 0;
							goto IL_01ec;
							IL_016c:
							if (NyGsLVTrvYyagGDGaAqvlDBVhPmBA.MoveNext())
							{
								ActionElementMap current = NyGsLVTrvYyagGDGaAqvlDBVhPmBA.Current;
								SGiaNYEDMjKqwdANNJrxgYNNcCyV = current;
								hEcWVaBvgAUhiKaeMDpswcKypciJ = 1;
								return true;
							}
							YaFJeOvTBfWAPpeQTsYpMVJtYenK();
							NyGsLVTrvYyagGDGaAqvlDBVhPmBA = null;
							goto IL_0186;
							IL_0186:
							ppmecWhQwViVhCYxgEtYixjybzXHb++;
							goto IL_0198;
							IL_01c2:
							if (JKjAQtnhQtvWzYylJEFoHPgjGzIv < nluATnKleBfPiCtmeSAUTbaMGYDdc)
							{
								ZpnGGfLdvSVZZkgyhzXoIxGXjuIg = kBGnLMMjYYGiCycmvIbbiYNcnhYb.AWmOltvgZLyyeShVGMDDYeiwNhPG(JKjAQtnhQtvWzYylJEFoHPgjGzIv).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								MbVOaKUxlmcdurjcRsTIyAMMgqDcA = ZpnGGfLdvSVZZkgyhzXoIxGXjuIg.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								ppmecWhQwViVhCYxgEtYixjybzXHb = 0;
								goto IL_0198;
							}
							kBGnLMMjYYGiCycmvIbbiYNcnhYb = null;
							nKHxYChnwJPCOCWqFDKTBDrnwfpL++;
							goto IL_01ec;
							IL_0198:
							if (ppmecWhQwViVhCYxgEtYixjybzXHb < MbVOaKUxlmcdurjcRsTIyAMMgqDcA)
							{
								ControllerMap controllerMap = ZpnGGfLdvSVZZkgyhzXoIxGXjuIg.sraFvIhbtwaREyBqnZUbJclkEDGC(ppmecWhQwViVhCYxgEtYixjybzXHb);
								if ((!ZcvKKSSndYYDihAqJCTECWJnFtVrA || controllerMap.enabled) && controllerMap.ContainsAction(ZPdvdTlcCGCbPOdrkRbluwflQRFk))
								{
									NyGsLVTrvYyagGDGaAqvlDBVhPmBA = controllerMap.ButtonMapsWithAction(ZPdvdTlcCGCbPOdrkRbluwflQRFk, ZcvKKSSndYYDihAqJCTECWJnFtVrA).GetEnumerator();
									hEcWVaBvgAUhiKaeMDpswcKypciJ = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							ZpnGGfLdvSVZZkgyhzXoIxGXjuIg = null;
							JKjAQtnhQtvWzYylJEFoHPgjGzIv++;
							goto IL_01c2;
							IL_01ec:
							if (nKHxYChnwJPCOCWqFDKTBDrnwfpL < sEiYWtdWHojzHjwXTKzteIbOvJxQ)
							{
								kBGnLMMjYYGiCycmvIbbiYNcnhYb = zfEEXsTJXekEOgYhwJzsdatKDZDQ.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(nKHxYChnwJPCOCWqFDKTBDrnwfpL);
								nluATnKleBfPiCtmeSAUTbaMGYDdc = kBGnLMMjYYGiCycmvIbbiYNcnhYb.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
								JKjAQtnhQtvWzYylJEFoHPgjGzIv = 0;
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

					private void YaFJeOvTBfWAPpeQTsYpMVJtYenK()
					{
						hEcWVaBvgAUhiKaeMDpswcKypciJ = -1;
						if (NyGsLVTrvYyagGDGaAqvlDBVhPmBA != null)
						{
							NyGsLVTrvYyagGDGaAqvlDBVhPmBA.Dispose();
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
						CNawMvTbvBrqEThxvvDpbauqnZgd cNawMvTbvBrqEThxvvDpbauqnZgd;
						if (hEcWVaBvgAUhiKaeMDpswcKypciJ == -2 && cTnQIeWLNXKmsGCLEWYvTsPCjCOI == Environment.CurrentManagedThreadId)
						{
							hEcWVaBvgAUhiKaeMDpswcKypciJ = 0;
							cNawMvTbvBrqEThxvvDpbauqnZgd = this;
						}
						else
						{
							cNawMvTbvBrqEThxvvDpbauqnZgd = new CNawMvTbvBrqEThxvvDpbauqnZgd(0);
							cNawMvTbvBrqEThxvvDpbauqnZgd.ZfEEXsTJXekEOgYhwJzsdatKDZDQ = ZfEEXsTJXekEOgYhwJzsdatKDZDQ;
						}
						cNawMvTbvBrqEThxvvDpbauqnZgd.ZPdvdTlcCGCbPOdrkRbluwflQRFk = LCWVHBUCxNAKUXJasvPIBeGEfxrE;
						cNawMvTbvBrqEThxvvDpbauqnZgd.ZcvKKSSndYYDihAqJCTECWJnFtVrA = vwxtSFZKBmcidybeWnDbumIzfmnCA;
						return cNawMvTbvBrqEThxvvDpbauqnZgd;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class ZBbFgeryzdjfxEcAaqOWcVLMAuBr : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int cExjHySVXnuwDcCTjeyfaaHbpPT;

					private ActionElementMap bvAiZUmBmrSNqyqPUdJWoxLgGmgl;

					private int WdJvlzWilAhjUMnNsnxqwkJtwRNW;

					private int nRYbZqIFrsTkEugVZZuIHOHRTaQv;

					public int rVJWxliBREGzkFuBbAkiaqzhWzik;

					public MapHelper SojcoIDyVpwZpkHXRtlyePrzJMGY;

					private ControllerType rUzKKSNzREYdTXgDobwhVTVnOgPo;

					public ControllerType qsENTbkjyRUSaBNDXQadjIwczgtf;

					private bool QGwLoSFNCNBamHCNGOQDKOhNxOiDA;

					public bool JazNDdYSWeVnInaBsvaBjGHkwuuk;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr FDpyTQxCQWKejuHJqvZHZEPQeFfZ;

					private int aEyKHNxqyXZLFcnWnbVFiEldMQbcb;

					private IList<ControllerMap> jXTJgmGLqylsBNZiDOXsVibrvDNK;

					private int MjbTpUIDMVGNfHYflZjNSqMLiCPE;

					private IEnumerator<ActionElementMap> NGYThErkOXttcZvALDWLQGbGDkdC;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return bvAiZUmBmrSNqyqPUdJWoxLgGmgl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bvAiZUmBmrSNqyqPUdJWoxLgGmgl;
						}
					}

					[DebuggerHidden]
					public ZBbFgeryzdjfxEcAaqOWcVLMAuBr(int P_0)
					{
						cExjHySVXnuwDcCTjeyfaaHbpPT = P_0;
						WdJvlzWilAhjUMnNsnxqwkJtwRNW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cExjHySVXnuwDcCTjeyfaaHbpPT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								lVzDbsasUJeFsUkcCGzUGOGFRWuHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = cExjHySVXnuwDcCTjeyfaaHbpPT;
							MapHelper sojcoIDyVpwZpkHXRtlyePrzJMGY = SojcoIDyVpwZpkHXRtlyePrzJMGY;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cExjHySVXnuwDcCTjeyfaaHbpPT = -3;
								goto IL_0150;
							}
							cExjHySVXnuwDcCTjeyfaaHbpPT = -1;
							if (nRYbZqIFrsTkEugVZZuIHOHRTaQv < 0)
							{
								return false;
							}
							FDpyTQxCQWKejuHJqvZHZEPQeFfZ = sojcoIDyVpwZpkHXRtlyePrzJMGY.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(rUzKKSNzREYdTXgDobwhVTVnOgPo);
							aEyKHNxqyXZLFcnWnbVFiEldMQbcb = 0;
							goto IL_01ab;
							IL_0150:
							if (NGYThErkOXttcZvALDWLQGbGDkdC.MoveNext())
							{
								ActionElementMap current = NGYThErkOXttcZvALDWLQGbGDkdC.Current;
								bvAiZUmBmrSNqyqPUdJWoxLgGmgl = current;
								cExjHySVXnuwDcCTjeyfaaHbpPT = 1;
								return true;
							}
							lVzDbsasUJeFsUkcCGzUGOGFRWuHb();
							NGYThErkOXttcZvALDWLQGbGDkdC = null;
							goto IL_016a;
							IL_017c:
							if (MjbTpUIDMVGNfHYflZjNSqMLiCPE < jXTJgmGLqylsBNZiDOXsVibrvDNK.Count)
							{
								if (!(jXTJgmGLqylsBNZiDOXsVibrvDNK[MjbTpUIDMVGNfHYflZjNSqMLiCPE] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!QGwLoSFNCNBamHCNGOQDKOhNxOiDA || jXTJgmGLqylsBNZiDOXsVibrvDNK[MjbTpUIDMVGNfHYflZjNSqMLiCPE].enabled) && jXTJgmGLqylsBNZiDOXsVibrvDNK[MjbTpUIDMVGNfHYflZjNSqMLiCPE].ContainsAction(nRYbZqIFrsTkEugVZZuIHOHRTaQv))
								{
									NGYThErkOXttcZvALDWLQGbGDkdC = (jXTJgmGLqylsBNZiDOXsVibrvDNK[MjbTpUIDMVGNfHYflZjNSqMLiCPE] as ControllerMapWithAxes).AxisMapsWithAction(nRYbZqIFrsTkEugVZZuIHOHRTaQv, QGwLoSFNCNBamHCNGOQDKOhNxOiDA).GetEnumerator();
									cExjHySVXnuwDcCTjeyfaaHbpPT = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							jXTJgmGLqylsBNZiDOXsVibrvDNK = null;
							aEyKHNxqyXZLFcnWnbVFiEldMQbcb++;
							goto IL_01ab;
							IL_016a:
							MjbTpUIDMVGNfHYflZjNSqMLiCPE++;
							goto IL_017c;
							IL_01ab:
							if (aEyKHNxqyXZLFcnWnbVFiEldMQbcb < FDpyTQxCQWKejuHJqvZHZEPQeFfZ.flFZvPVsPcNnBeWIGSaTgKMcStvJ)
							{
								jXTJgmGLqylsBNZiDOXsVibrvDNK = FDpyTQxCQWKejuHJqvZHZEPQeFfZ.AWmOltvgZLyyeShVGMDDYeiwNhPG(aEyKHNxqyXZLFcnWnbVFiEldMQbcb).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
								MjbTpUIDMVGNfHYflZjNSqMLiCPE = 0;
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

					private void lVzDbsasUJeFsUkcCGzUGOGFRWuHb()
					{
						cExjHySVXnuwDcCTjeyfaaHbpPT = -1;
						if (NGYThErkOXttcZvALDWLQGbGDkdC != null)
						{
							NGYThErkOXttcZvALDWLQGbGDkdC.Dispose();
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
						ZBbFgeryzdjfxEcAaqOWcVLMAuBr zBbFgeryzdjfxEcAaqOWcVLMAuBr;
						if (cExjHySVXnuwDcCTjeyfaaHbpPT == -2 && WdJvlzWilAhjUMnNsnxqwkJtwRNW == Environment.CurrentManagedThreadId)
						{
							cExjHySVXnuwDcCTjeyfaaHbpPT = 0;
							zBbFgeryzdjfxEcAaqOWcVLMAuBr = this;
						}
						else
						{
							zBbFgeryzdjfxEcAaqOWcVLMAuBr = new ZBbFgeryzdjfxEcAaqOWcVLMAuBr(0);
							zBbFgeryzdjfxEcAaqOWcVLMAuBr.SojcoIDyVpwZpkHXRtlyePrzJMGY = SojcoIDyVpwZpkHXRtlyePrzJMGY;
						}
						zBbFgeryzdjfxEcAaqOWcVLMAuBr.rUzKKSNzREYdTXgDobwhVTVnOgPo = qsENTbkjyRUSaBNDXQadjIwczgtf;
						zBbFgeryzdjfxEcAaqOWcVLMAuBr.nRYbZqIFrsTkEugVZZuIHOHRTaQv = rVJWxliBREGzkFuBbAkiaqzhWzik;
						zBbFgeryzdjfxEcAaqOWcVLMAuBr.QGwLoSFNCNBamHCNGOQDKOhNxOiDA = JazNDdYSWeVnInaBsvaBjGHkwuuk;
						return zBbFgeryzdjfxEcAaqOWcVLMAuBr;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class TCQksDFcyyDLSEGtpJoYVhsqCjVjA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int jLWBAgjiIjPEWjYfjxNdJMfHdeOgb;

					private ActionElementMap EnvZGvzGbHRzRmRiIxCZpUaGsxBr;

					private int wHqisBJPjYMkdvVRjbJpKfGYnaZm;

					private int UcOiCftTbkElhFCbnpDcpXbTTJmqA;

					public int XLbWKUDdgkohyOvkncKPQGfWvroO;

					public MapHelper wtbgGkFCmBGHtNpgAbcEMKbWXjgh;

					private ControllerType fYYcdsBfYpoKnzpdxdnFhjsJskUH;

					public ControllerType GNwNycuoaFvQQkFzZtkRtShZPPVv;

					private int kBahUEPRIlQSLrRXBDRDkjEwCUGE;

					public int hPZfLucMGwuablBupScAOTcgkStPA;

					private bool hBhwbHIPysfRoDnOBhxUlUPnaQPC;

					public bool EuLcGsTJPvVbIxirUXVEJtbGxUcc;

					private IList<ControllerMap> vOuPNoheNtlqhMVilySMNPwOxrGF;

					private int vpkhxtwIKoBagMIiUEYyDzJBKkCi;

					private IEnumerator<ActionElementMap> dkpZifGlboQNYINkvIpFjBMYelmpA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return EnvZGvzGbHRzRmRiIxCZpUaGsxBr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return EnvZGvzGbHRzRmRiIxCZpUaGsxBr;
						}
					}

					[DebuggerHidden]
					public TCQksDFcyyDLSEGtpJoYVhsqCjVjA(int P_0)
					{
						jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = P_0;
						wHqisBJPjYMkdvVRjbJpKfGYnaZm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = jLWBAgjiIjPEWjYfjxNdJMfHdeOgb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								mWnYIYCuiyafOhgKITSCAkdYesDs();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = jLWBAgjiIjPEWjYfjxNdJMfHdeOgb;
							MapHelper mapHelper = wtbgGkFCmBGHtNpgAbcEMKbWXjgh;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = -3;
								goto IL_014f;
							}
							jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = -1;
							if (UcOiCftTbkElhFCbnpDcpXbTTJmqA < 0)
							{
								return false;
							}
							jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(fYYcdsBfYpoKnzpdxdnFhjsJskUH);
							int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(kBahUEPRIlQSLrRXBDRDkjEwCUGE);
							if (num2 < 0)
							{
								return false;
							}
							vOuPNoheNtlqhMVilySMNPwOxrGF = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num2).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
							vpkhxtwIKoBagMIiUEYyDzJBKkCi = 0;
							goto IL_017b;
							IL_014f:
							if (dkpZifGlboQNYINkvIpFjBMYelmpA.MoveNext())
							{
								ActionElementMap current = dkpZifGlboQNYINkvIpFjBMYelmpA.Current;
								EnvZGvzGbHRzRmRiIxCZpUaGsxBr = current;
								jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = 1;
								return true;
							}
							mWnYIYCuiyafOhgKITSCAkdYesDs();
							dkpZifGlboQNYINkvIpFjBMYelmpA = null;
							goto IL_0169;
							IL_017b:
							if (vpkhxtwIKoBagMIiUEYyDzJBKkCi < vOuPNoheNtlqhMVilySMNPwOxrGF.Count)
							{
								if (!(vOuPNoheNtlqhMVilySMNPwOxrGF[vpkhxtwIKoBagMIiUEYyDzJBKkCi] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!hBhwbHIPysfRoDnOBhxUlUPnaQPC || vOuPNoheNtlqhMVilySMNPwOxrGF[vpkhxtwIKoBagMIiUEYyDzJBKkCi].enabled) && vOuPNoheNtlqhMVilySMNPwOxrGF[vpkhxtwIKoBagMIiUEYyDzJBKkCi].ContainsAction(UcOiCftTbkElhFCbnpDcpXbTTJmqA))
								{
									dkpZifGlboQNYINkvIpFjBMYelmpA = (vOuPNoheNtlqhMVilySMNPwOxrGF[vpkhxtwIKoBagMIiUEYyDzJBKkCi] as ControllerMapWithAxes).AxisMapsWithAction(UcOiCftTbkElhFCbnpDcpXbTTJmqA, hBhwbHIPysfRoDnOBhxUlUPnaQPC).GetEnumerator();
									jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							vpkhxtwIKoBagMIiUEYyDzJBKkCi++;
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

					private void mWnYIYCuiyafOhgKITSCAkdYesDs()
					{
						jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = -1;
						if (dkpZifGlboQNYINkvIpFjBMYelmpA != null)
						{
							dkpZifGlboQNYINkvIpFjBMYelmpA.Dispose();
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
						TCQksDFcyyDLSEGtpJoYVhsqCjVjA tCQksDFcyyDLSEGtpJoYVhsqCjVjA;
						if (jLWBAgjiIjPEWjYfjxNdJMfHdeOgb == -2 && wHqisBJPjYMkdvVRjbJpKfGYnaZm == Environment.CurrentManagedThreadId)
						{
							jLWBAgjiIjPEWjYfjxNdJMfHdeOgb = 0;
							tCQksDFcyyDLSEGtpJoYVhsqCjVjA = this;
						}
						else
						{
							tCQksDFcyyDLSEGtpJoYVhsqCjVjA = new TCQksDFcyyDLSEGtpJoYVhsqCjVjA(0);
							tCQksDFcyyDLSEGtpJoYVhsqCjVjA.wtbgGkFCmBGHtNpgAbcEMKbWXjgh = wtbgGkFCmBGHtNpgAbcEMKbWXjgh;
						}
						tCQksDFcyyDLSEGtpJoYVhsqCjVjA.fYYcdsBfYpoKnzpdxdnFhjsJskUH = GNwNycuoaFvQQkFzZtkRtShZPPVv;
						tCQksDFcyyDLSEGtpJoYVhsqCjVjA.kBahUEPRIlQSLrRXBDRDkjEwCUGE = hPZfLucMGwuablBupScAOTcgkStPA;
						tCQksDFcyyDLSEGtpJoYVhsqCjVjA.UcOiCftTbkElhFCbnpDcpXbTTJmqA = XLbWKUDdgkohyOvkncKPQGfWvroO;
						tCQksDFcyyDLSEGtpJoYVhsqCjVjA.hBhwbHIPysfRoDnOBhxUlUPnaQPC = EuLcGsTJPvVbIxirUXVEJtbGxUcc;
						return tCQksDFcyyDLSEGtpJoYVhsqCjVjA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class MnFfCHNHABZQRPpNQCZhBHTVVKCnA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int oMmzYnSGHuSxFagPlxaUqmmhZIBc;

					private ActionElementMap GiHzhvpxJzVEhwYwZMkOlFJsrhkC;

					private int aIsmjwiLBOvEfmEYCBFdkwSaQSzFA;

					private int dhnFPNtvAvyOggAniiojCfbbpshxA;

					public int ZAuWKuiOFXQGqFNzkjvrLneXcyBr;

					public MapHelper vjacusHnnuguoorGYoSjGZiYSbMZA;

					private ControllerType HsTBCwJfEzUFlMERYIIWBNSDujCh;

					public ControllerType yyDNDhbJlyAgxurroGRoiszrbpwvA;

					private bool lhHzbujpVyhpgsWCoIGXyAVDIJPW;

					public bool ntLCuYSfCWEGAKmeCzxkwiywngIf;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr oyFDAkHqGfyLYLwYwCSLVruUebcFb;

					private int rOapXWYkcbCejGmnmvWzWrQvlmJL;

					private IList<ControllerMap> dvyaBWXuOmEjIIpwQpNwfSejBlqq;

					private int uzMeBvgXvJHftGSqeyYQCQlbhIlu;

					private IEnumerator<ActionElementMap> AbXGfYiVDRPseetbPEjVJpMvTVKHA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return GiHzhvpxJzVEhwYwZMkOlFJsrhkC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GiHzhvpxJzVEhwYwZMkOlFJsrhkC;
						}
					}

					[DebuggerHidden]
					public MnFfCHNHABZQRPpNQCZhBHTVVKCnA(int P_0)
					{
						oMmzYnSGHuSxFagPlxaUqmmhZIBc = P_0;
						aIsmjwiLBOvEfmEYCBFdkwSaQSzFA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = oMmzYnSGHuSxFagPlxaUqmmhZIBc;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								OHlFNLebfMknwFDrvUFfXYNrfNEnA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = oMmzYnSGHuSxFagPlxaUqmmhZIBc;
							MapHelper mapHelper = vjacusHnnuguoorGYoSjGZiYSbMZA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								oMmzYnSGHuSxFagPlxaUqmmhZIBc = -3;
								goto IL_012c;
							}
							oMmzYnSGHuSxFagPlxaUqmmhZIBc = -1;
							if (dhnFPNtvAvyOggAniiojCfbbpshxA < 0)
							{
								return false;
							}
							oyFDAkHqGfyLYLwYwCSLVruUebcFb = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(HsTBCwJfEzUFlMERYIIWBNSDujCh);
							rOapXWYkcbCejGmnmvWzWrQvlmJL = 0;
							goto IL_0187;
							IL_012c:
							if (AbXGfYiVDRPseetbPEjVJpMvTVKHA.MoveNext())
							{
								ActionElementMap current = AbXGfYiVDRPseetbPEjVJpMvTVKHA.Current;
								GiHzhvpxJzVEhwYwZMkOlFJsrhkC = current;
								oMmzYnSGHuSxFagPlxaUqmmhZIBc = 1;
								return true;
							}
							OHlFNLebfMknwFDrvUFfXYNrfNEnA();
							AbXGfYiVDRPseetbPEjVJpMvTVKHA = null;
							goto IL_0146;
							IL_0158:
							if (uzMeBvgXvJHftGSqeyYQCQlbhIlu < dvyaBWXuOmEjIIpwQpNwfSejBlqq.Count)
							{
								if ((!lhHzbujpVyhpgsWCoIGXyAVDIJPW || dvyaBWXuOmEjIIpwQpNwfSejBlqq[uzMeBvgXvJHftGSqeyYQCQlbhIlu].enabled) && dvyaBWXuOmEjIIpwQpNwfSejBlqq[uzMeBvgXvJHftGSqeyYQCQlbhIlu].ContainsAction(dhnFPNtvAvyOggAniiojCfbbpshxA))
								{
									AbXGfYiVDRPseetbPEjVJpMvTVKHA = dvyaBWXuOmEjIIpwQpNwfSejBlqq[uzMeBvgXvJHftGSqeyYQCQlbhIlu].ButtonMapsWithAction(dhnFPNtvAvyOggAniiojCfbbpshxA, lhHzbujpVyhpgsWCoIGXyAVDIJPW).GetEnumerator();
									oMmzYnSGHuSxFagPlxaUqmmhZIBc = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							dvyaBWXuOmEjIIpwQpNwfSejBlqq = null;
							rOapXWYkcbCejGmnmvWzWrQvlmJL++;
							goto IL_0187;
							IL_0146:
							uzMeBvgXvJHftGSqeyYQCQlbhIlu++;
							goto IL_0158;
							IL_0187:
							if (rOapXWYkcbCejGmnmvWzWrQvlmJL < oyFDAkHqGfyLYLwYwCSLVruUebcFb.flFZvPVsPcNnBeWIGSaTgKMcStvJ)
							{
								dvyaBWXuOmEjIIpwQpNwfSejBlqq = oyFDAkHqGfyLYLwYwCSLVruUebcFb.AWmOltvgZLyyeShVGMDDYeiwNhPG(rOapXWYkcbCejGmnmvWzWrQvlmJL).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
								uzMeBvgXvJHftGSqeyYQCQlbhIlu = 0;
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

					private void OHlFNLebfMknwFDrvUFfXYNrfNEnA()
					{
						oMmzYnSGHuSxFagPlxaUqmmhZIBc = -1;
						if (AbXGfYiVDRPseetbPEjVJpMvTVKHA != null)
						{
							AbXGfYiVDRPseetbPEjVJpMvTVKHA.Dispose();
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
						MnFfCHNHABZQRPpNQCZhBHTVVKCnA mnFfCHNHABZQRPpNQCZhBHTVVKCnA;
						if (oMmzYnSGHuSxFagPlxaUqmmhZIBc == -2 && aIsmjwiLBOvEfmEYCBFdkwSaQSzFA == Environment.CurrentManagedThreadId)
						{
							oMmzYnSGHuSxFagPlxaUqmmhZIBc = 0;
							mnFfCHNHABZQRPpNQCZhBHTVVKCnA = this;
						}
						else
						{
							mnFfCHNHABZQRPpNQCZhBHTVVKCnA = new MnFfCHNHABZQRPpNQCZhBHTVVKCnA(0);
							mnFfCHNHABZQRPpNQCZhBHTVVKCnA.vjacusHnnuguoorGYoSjGZiYSbMZA = vjacusHnnuguoorGYoSjGZiYSbMZA;
						}
						mnFfCHNHABZQRPpNQCZhBHTVVKCnA.HsTBCwJfEzUFlMERYIIWBNSDujCh = yyDNDhbJlyAgxurroGRoiszrbpwvA;
						mnFfCHNHABZQRPpNQCZhBHTVVKCnA.dhnFPNtvAvyOggAniiojCfbbpshxA = ZAuWKuiOFXQGqFNzkjvrLneXcyBr;
						mnFfCHNHABZQRPpNQCZhBHTVVKCnA.lhHzbujpVyhpgsWCoIGXyAVDIJPW = ntLCuYSfCWEGAKmeCzxkwiywngIf;
						return mnFfCHNHABZQRPpNQCZhBHTVVKCnA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class zAMqdRCweJizVPEBHgxENAWfBYudA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int pNKzToWVPUZQPyXlEaHFwpGOpmiB;

					private ActionElementMap ecXGPKrOWKWljeatlUbNvQIwmlBi;

					private int TQyadviOVWGGYwkZzQJMyfPUNJOh;

					private int KJqlwtaDaDCHHJufkGrvdVhcoQQzA;

					public int ZrzDsrJdkKFmKAMeKtmijmnxbMeh;

					public MapHelper oQfvSRYwNDulBdLkpnOXoweWhrVN;

					private ControllerType yasMebDObwFDHIysbtkJWlAAgKWpA;

					public ControllerType pWgfeijpjoDiuKJrByOCEtjaCLaO;

					private int GGvhSLGCoSOZHYvxreaElTRppDkl;

					public int iVaBeUrkXWONwPMXJBdTdKOSoJezA;

					private bool sQoyDdIhbmtPzsROyjZSJDbuVGVi;

					public bool xVxMOWoVSJAwQmNofOGgcjcyphTJ;

					private IList<ControllerMap> wvqufIxFESLrLhcNTAmBnqshwyeo;

					private int xQbaHkdpsMkeazTlUNnyrlXaiyLd;

					private IEnumerator<ActionElementMap> samvoTSKVmEAmiAndzknNdKOUtPcA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ecXGPKrOWKWljeatlUbNvQIwmlBi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ecXGPKrOWKWljeatlUbNvQIwmlBi;
						}
					}

					[DebuggerHidden]
					public zAMqdRCweJizVPEBHgxENAWfBYudA(int P_0)
					{
						pNKzToWVPUZQPyXlEaHFwpGOpmiB = P_0;
						TQyadviOVWGGYwkZzQJMyfPUNJOh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pNKzToWVPUZQPyXlEaHFwpGOpmiB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								XcfNeQqMhPGMsaVdAuJhgMTHoOkl();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = pNKzToWVPUZQPyXlEaHFwpGOpmiB;
							MapHelper mapHelper = oQfvSRYwNDulBdLkpnOXoweWhrVN;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pNKzToWVPUZQPyXlEaHFwpGOpmiB = -3;
								goto IL_012b;
							}
							pNKzToWVPUZQPyXlEaHFwpGOpmiB = -1;
							if (KJqlwtaDaDCHHJufkGrvdVhcoQQzA < 0)
							{
								return false;
							}
							jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(yasMebDObwFDHIysbtkJWlAAgKWpA);
							int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(GGvhSLGCoSOZHYvxreaElTRppDkl);
							if (num2 < 0)
							{
								return false;
							}
							wvqufIxFESLrLhcNTAmBnqshwyeo = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num2).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
							xQbaHkdpsMkeazTlUNnyrlXaiyLd = 0;
							goto IL_0157;
							IL_012b:
							if (samvoTSKVmEAmiAndzknNdKOUtPcA.MoveNext())
							{
								ActionElementMap current = samvoTSKVmEAmiAndzknNdKOUtPcA.Current;
								ecXGPKrOWKWljeatlUbNvQIwmlBi = current;
								pNKzToWVPUZQPyXlEaHFwpGOpmiB = 1;
								return true;
							}
							XcfNeQqMhPGMsaVdAuJhgMTHoOkl();
							samvoTSKVmEAmiAndzknNdKOUtPcA = null;
							goto IL_0145;
							IL_0157:
							if (xQbaHkdpsMkeazTlUNnyrlXaiyLd < wvqufIxFESLrLhcNTAmBnqshwyeo.Count)
							{
								if ((!sQoyDdIhbmtPzsROyjZSJDbuVGVi || wvqufIxFESLrLhcNTAmBnqshwyeo[xQbaHkdpsMkeazTlUNnyrlXaiyLd].enabled) && wvqufIxFESLrLhcNTAmBnqshwyeo[xQbaHkdpsMkeazTlUNnyrlXaiyLd].ContainsAction(KJqlwtaDaDCHHJufkGrvdVhcoQQzA))
								{
									samvoTSKVmEAmiAndzknNdKOUtPcA = wvqufIxFESLrLhcNTAmBnqshwyeo[xQbaHkdpsMkeazTlUNnyrlXaiyLd].ButtonMapsWithAction(KJqlwtaDaDCHHJufkGrvdVhcoQQzA, sQoyDdIhbmtPzsROyjZSJDbuVGVi).GetEnumerator();
									pNKzToWVPUZQPyXlEaHFwpGOpmiB = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							xQbaHkdpsMkeazTlUNnyrlXaiyLd++;
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

					private void XcfNeQqMhPGMsaVdAuJhgMTHoOkl()
					{
						pNKzToWVPUZQPyXlEaHFwpGOpmiB = -1;
						if (samvoTSKVmEAmiAndzknNdKOUtPcA != null)
						{
							samvoTSKVmEAmiAndzknNdKOUtPcA.Dispose();
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
						zAMqdRCweJizVPEBHgxENAWfBYudA zAMqdRCweJizVPEBHgxENAWfBYudA2;
						if (pNKzToWVPUZQPyXlEaHFwpGOpmiB == -2 && TQyadviOVWGGYwkZzQJMyfPUNJOh == Environment.CurrentManagedThreadId)
						{
							pNKzToWVPUZQPyXlEaHFwpGOpmiB = 0;
							zAMqdRCweJizVPEBHgxENAWfBYudA2 = this;
						}
						else
						{
							zAMqdRCweJizVPEBHgxENAWfBYudA2 = new zAMqdRCweJizVPEBHgxENAWfBYudA(0);
							zAMqdRCweJizVPEBHgxENAWfBYudA2.oQfvSRYwNDulBdLkpnOXoweWhrVN = oQfvSRYwNDulBdLkpnOXoweWhrVN;
						}
						zAMqdRCweJizVPEBHgxENAWfBYudA2.yasMebDObwFDHIysbtkJWlAAgKWpA = pWgfeijpjoDiuKJrByOCEtjaCLaO;
						zAMqdRCweJizVPEBHgxENAWfBYudA2.GGvhSLGCoSOZHYvxreaElTRppDkl = iVaBeUrkXWONwPMXJBdTdKOSoJezA;
						zAMqdRCweJizVPEBHgxENAWfBYudA2.KJqlwtaDaDCHHJufkGrvdVhcoQQzA = ZrzDsrJdkKFmKAMeKtmijmnxbMeh;
						zAMqdRCweJizVPEBHgxENAWfBYudA2.sQoyDdIhbmtPzsROyjZSJDbuVGVi = xVxMOWoVSJAwQmNofOGgcjcyphTJ;
						return zAMqdRCweJizVPEBHgxENAWfBYudA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class vbHLyUdjjGlcwWbEPgTivriHfXfbA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int kIftlcaAczjDkSzItDpeOhorJYqO;

					private ActionElementMap WaieyHDtjFhTKSvXGXRSKnClczIA;

					private int YpUDEzDfArMIdKQgVdudYrSURSY;

					private int FKLULPEhjEfSyMdebbotFRbFtJymA;

					public int cjlRuUzjWOLZZOVBvWlwwUCADGAT;

					public MapHelper tPsWDEFSvRBVGeYXNbARFXuGrzBIb;

					private ControllerType JbBPlbNrVNDkzcXKaRNqdzRJmKTX;

					public ControllerType NAJCbQwAYMarAFaiSBKKubbehtHvA;

					private bool HmbGWSPepIvIwsPVOxfZxPgfTcE;

					public bool eLevniKoDDRrtsQVsTRniQuZFKOd;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr WFUlSTuZQdELPVmZbhEzCojDQhkQ;

					private int QfHidsNykxsYlmfOhtlXpLrJEtAm;

					private IList<ControllerMap> GFlOOOnbZooDxVJSEaeneXCCLEmK;

					private int vWEdcEuwfzyzXxlaBpMUiYrkNWRI;

					private IEnumerator<ActionElementMap> molaFqRrKdohoivcFosWwCBEHBwJA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WaieyHDtjFhTKSvXGXRSKnClczIA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WaieyHDtjFhTKSvXGXRSKnClczIA;
						}
					}

					[DebuggerHidden]
					public vbHLyUdjjGlcwWbEPgTivriHfXfbA(int P_0)
					{
						kIftlcaAczjDkSzItDpeOhorJYqO = P_0;
						YpUDEzDfArMIdKQgVdudYrSURSY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = kIftlcaAczjDkSzItDpeOhorJYqO;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								rowfhgBObPjIFaggMrJzjezBbGGmA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = kIftlcaAczjDkSzItDpeOhorJYqO;
							MapHelper mapHelper = tPsWDEFSvRBVGeYXNbARFXuGrzBIb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								kIftlcaAczjDkSzItDpeOhorJYqO = -3;
								goto IL_012c;
							}
							kIftlcaAczjDkSzItDpeOhorJYqO = -1;
							if (FKLULPEhjEfSyMdebbotFRbFtJymA < 0)
							{
								return false;
							}
							WFUlSTuZQdELPVmZbhEzCojDQhkQ = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(JbBPlbNrVNDkzcXKaRNqdzRJmKTX);
							QfHidsNykxsYlmfOhtlXpLrJEtAm = 0;
							goto IL_0187;
							IL_012c:
							if (molaFqRrKdohoivcFosWwCBEHBwJA.MoveNext())
							{
								ActionElementMap current = molaFqRrKdohoivcFosWwCBEHBwJA.Current;
								WaieyHDtjFhTKSvXGXRSKnClczIA = current;
								kIftlcaAczjDkSzItDpeOhorJYqO = 1;
								return true;
							}
							rowfhgBObPjIFaggMrJzjezBbGGmA();
							molaFqRrKdohoivcFosWwCBEHBwJA = null;
							goto IL_0146;
							IL_0158:
							if (vWEdcEuwfzyzXxlaBpMUiYrkNWRI < GFlOOOnbZooDxVJSEaeneXCCLEmK.Count)
							{
								if ((!HmbGWSPepIvIwsPVOxfZxPgfTcE || GFlOOOnbZooDxVJSEaeneXCCLEmK[vWEdcEuwfzyzXxlaBpMUiYrkNWRI].enabled) && GFlOOOnbZooDxVJSEaeneXCCLEmK[vWEdcEuwfzyzXxlaBpMUiYrkNWRI].ContainsAction(FKLULPEhjEfSyMdebbotFRbFtJymA))
								{
									molaFqRrKdohoivcFosWwCBEHBwJA = GFlOOOnbZooDxVJSEaeneXCCLEmK[vWEdcEuwfzyzXxlaBpMUiYrkNWRI].ElementMapsWithAction(FKLULPEhjEfSyMdebbotFRbFtJymA, HmbGWSPepIvIwsPVOxfZxPgfTcE).GetEnumerator();
									kIftlcaAczjDkSzItDpeOhorJYqO = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							GFlOOOnbZooDxVJSEaeneXCCLEmK = null;
							QfHidsNykxsYlmfOhtlXpLrJEtAm++;
							goto IL_0187;
							IL_0146:
							vWEdcEuwfzyzXxlaBpMUiYrkNWRI++;
							goto IL_0158;
							IL_0187:
							if (QfHidsNykxsYlmfOhtlXpLrJEtAm < WFUlSTuZQdELPVmZbhEzCojDQhkQ.flFZvPVsPcNnBeWIGSaTgKMcStvJ)
							{
								GFlOOOnbZooDxVJSEaeneXCCLEmK = WFUlSTuZQdELPVmZbhEzCojDQhkQ.AWmOltvgZLyyeShVGMDDYeiwNhPG(QfHidsNykxsYlmfOhtlXpLrJEtAm).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
								vWEdcEuwfzyzXxlaBpMUiYrkNWRI = 0;
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

					private void rowfhgBObPjIFaggMrJzjezBbGGmA()
					{
						kIftlcaAczjDkSzItDpeOhorJYqO = -1;
						if (molaFqRrKdohoivcFosWwCBEHBwJA != null)
						{
							molaFqRrKdohoivcFosWwCBEHBwJA.Dispose();
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
						vbHLyUdjjGlcwWbEPgTivriHfXfbA vbHLyUdjjGlcwWbEPgTivriHfXfbA2;
						if (kIftlcaAczjDkSzItDpeOhorJYqO == -2 && YpUDEzDfArMIdKQgVdudYrSURSY == Environment.CurrentManagedThreadId)
						{
							kIftlcaAczjDkSzItDpeOhorJYqO = 0;
							vbHLyUdjjGlcwWbEPgTivriHfXfbA2 = this;
						}
						else
						{
							vbHLyUdjjGlcwWbEPgTivriHfXfbA2 = new vbHLyUdjjGlcwWbEPgTivriHfXfbA(0);
							vbHLyUdjjGlcwWbEPgTivriHfXfbA2.tPsWDEFSvRBVGeYXNbARFXuGrzBIb = tPsWDEFSvRBVGeYXNbARFXuGrzBIb;
						}
						vbHLyUdjjGlcwWbEPgTivriHfXfbA2.JbBPlbNrVNDkzcXKaRNqdzRJmKTX = NAJCbQwAYMarAFaiSBKKubbehtHvA;
						vbHLyUdjjGlcwWbEPgTivriHfXfbA2.FKLULPEhjEfSyMdebbotFRbFtJymA = cjlRuUzjWOLZZOVBvWlwwUCADGAT;
						vbHLyUdjjGlcwWbEPgTivriHfXfbA2.HmbGWSPepIvIwsPVOxfZxPgfTcE = eLevniKoDDRrtsQVsTRniQuZFKOd;
						return vbHLyUdjjGlcwWbEPgTivriHfXfbA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class OtYQIWyEmBuWZDuGZXfESZRTKNRL : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int TOzaHNCQTmknlBBWuSiGiVwFHkkUB;

					private ActionElementMap dweWaRPoPoAiTTiuDxFaZKDrBJFz;

					private int JUDbMkGBCjtVChRMOPdjjXkApNuob;

					private int NckbTakGJDepxWhmAMkOlaBVaffkA;

					public int LqXQdOthbCWYmppksGPkbLwgOsOQ;

					public MapHelper tydgTWIiTBAeeRNEZnMsphFGpcRKA;

					private ControllerType vYEKUdEnVLofcVbiRTFvhSrjIepd;

					public ControllerType ZroDKwcaGBtlsDrwnSbzyKvijvbB;

					private int tLYcdAjKvMvEfwKPDeNpztSBRXPE;

					public int awbtNhOQEjiXXPqKTMnreZqSWkOJ;

					private bool ZAsaHilATyrTatmeLhrRFNackOaNA;

					public bool iDvMjxwZNCuFhIzZNpijvvzOwrH;

					private IList<ControllerMap> zUUCmlJuJTzViloLpAVEmQsUnHSGA;

					private int wHfmZevfWWskKYkGenFQCzkczAaG;

					private IEnumerator<ActionElementMap> XeYnASSebpjjBFCojxHAiqIslTho;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return dweWaRPoPoAiTTiuDxFaZKDrBJFz;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dweWaRPoPoAiTTiuDxFaZKDrBJFz;
						}
					}

					[DebuggerHidden]
					public OtYQIWyEmBuWZDuGZXfESZRTKNRL(int P_0)
					{
						TOzaHNCQTmknlBBWuSiGiVwFHkkUB = P_0;
						JUDbMkGBCjtVChRMOPdjjXkApNuob = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int tOzaHNCQTmknlBBWuSiGiVwFHkkUB = TOzaHNCQTmknlBBWuSiGiVwFHkkUB;
						if (tOzaHNCQTmknlBBWuSiGiVwFHkkUB == -3 || tOzaHNCQTmknlBBWuSiGiVwFHkkUB == 1)
						{
							try
							{
							}
							finally
							{
								erfQsPaqgaTatKlOKcflsjixsavJ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int tOzaHNCQTmknlBBWuSiGiVwFHkkUB = TOzaHNCQTmknlBBWuSiGiVwFHkkUB;
							MapHelper mapHelper = tydgTWIiTBAeeRNEZnMsphFGpcRKA;
							if (tOzaHNCQTmknlBBWuSiGiVwFHkkUB != 0)
							{
								if (tOzaHNCQTmknlBBWuSiGiVwFHkkUB != 1)
								{
									return false;
								}
								TOzaHNCQTmknlBBWuSiGiVwFHkkUB = -3;
								goto IL_012b;
							}
							TOzaHNCQTmknlBBWuSiGiVwFHkkUB = -1;
							if (NckbTakGJDepxWhmAMkOlaBVaffkA < 0)
							{
								return false;
							}
							jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(vYEKUdEnVLofcVbiRTFvhSrjIepd);
							int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(tLYcdAjKvMvEfwKPDeNpztSBRXPE);
							if (num < 0)
							{
								return false;
							}
							zUUCmlJuJTzViloLpAVEmQsUnHSGA = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
							wHfmZevfWWskKYkGenFQCzkczAaG = 0;
							goto IL_0157;
							IL_012b:
							if (XeYnASSebpjjBFCojxHAiqIslTho.MoveNext())
							{
								ActionElementMap current = XeYnASSebpjjBFCojxHAiqIslTho.Current;
								dweWaRPoPoAiTTiuDxFaZKDrBJFz = current;
								TOzaHNCQTmknlBBWuSiGiVwFHkkUB = 1;
								return true;
							}
							erfQsPaqgaTatKlOKcflsjixsavJ();
							XeYnASSebpjjBFCojxHAiqIslTho = null;
							goto IL_0145;
							IL_0157:
							if (wHfmZevfWWskKYkGenFQCzkczAaG < zUUCmlJuJTzViloLpAVEmQsUnHSGA.Count)
							{
								if ((!ZAsaHilATyrTatmeLhrRFNackOaNA || zUUCmlJuJTzViloLpAVEmQsUnHSGA[wHfmZevfWWskKYkGenFQCzkczAaG].enabled) && zUUCmlJuJTzViloLpAVEmQsUnHSGA[wHfmZevfWWskKYkGenFQCzkczAaG].ContainsAction(NckbTakGJDepxWhmAMkOlaBVaffkA))
								{
									XeYnASSebpjjBFCojxHAiqIslTho = zUUCmlJuJTzViloLpAVEmQsUnHSGA[wHfmZevfWWskKYkGenFQCzkczAaG].ElementMapsWithAction(NckbTakGJDepxWhmAMkOlaBVaffkA, ZAsaHilATyrTatmeLhrRFNackOaNA).GetEnumerator();
									TOzaHNCQTmknlBBWuSiGiVwFHkkUB = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							wHfmZevfWWskKYkGenFQCzkczAaG++;
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

					private void erfQsPaqgaTatKlOKcflsjixsavJ()
					{
						TOzaHNCQTmknlBBWuSiGiVwFHkkUB = -1;
						if (XeYnASSebpjjBFCojxHAiqIslTho != null)
						{
							XeYnASSebpjjBFCojxHAiqIslTho.Dispose();
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
						OtYQIWyEmBuWZDuGZXfESZRTKNRL otYQIWyEmBuWZDuGZXfESZRTKNRL;
						if (TOzaHNCQTmknlBBWuSiGiVwFHkkUB == -2 && JUDbMkGBCjtVChRMOPdjjXkApNuob == Environment.CurrentManagedThreadId)
						{
							TOzaHNCQTmknlBBWuSiGiVwFHkkUB = 0;
							otYQIWyEmBuWZDuGZXfESZRTKNRL = this;
						}
						else
						{
							otYQIWyEmBuWZDuGZXfESZRTKNRL = new OtYQIWyEmBuWZDuGZXfESZRTKNRL(0);
							otYQIWyEmBuWZDuGZXfESZRTKNRL.tydgTWIiTBAeeRNEZnMsphFGpcRKA = tydgTWIiTBAeeRNEZnMsphFGpcRKA;
						}
						otYQIWyEmBuWZDuGZXfESZRTKNRL.vYEKUdEnVLofcVbiRTFvhSrjIepd = ZroDKwcaGBtlsDrwnSbzyKvijvbB;
						otYQIWyEmBuWZDuGZXfESZRTKNRL.tLYcdAjKvMvEfwKPDeNpztSBRXPE = awbtNhOQEjiXXPqKTMnreZqSWkOJ;
						otYQIWyEmBuWZDuGZXfESZRTKNRL.NckbTakGJDepxWhmAMkOlaBVaffkA = LqXQdOthbCWYmppksGPkbLwgOsOQ;
						otYQIWyEmBuWZDuGZXfESZRTKNRL.ZAsaHilATyrTatmeLhrRFNackOaNA = iDvMjxwZNCuFhIzZNpijvvzOwrH;
						return otYQIWyEmBuWZDuGZXfESZRTKNRL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class LFkQbnFWvnRiifWISjCQLYAVHkzE : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int cNYOIDjGAdixwgUSQrsAqZpbXhVrA;

					private ControllerMap VyjDbmBLgjSzWMYUuHvHSAHgrTWMA;

					private int RgOqskzqZXAohlSguhCzhvcvndqY;

					public MapHelper AbaySPfHPccmXDrIMzbsDVuDigVfA;

					private ControllerType qVQBKqEIApNmgJFhnOUzmfGmIjAi;

					public ControllerType uGxjaYsVvbFqbNnYKyHtLFmtkMaQ;

					private int dkdgIJjLWZHWeCNBNMUrNzwKslku;

					public int aZJXfMYNWGzbhaGlnihkhlNiYUXW;

					private int RcptvKLvaSoXUdswMexxsBIbEVMD;

					public int uxNYOcNFLFHWVmoxIaiIlSTyhTYN;

					private IList<ControllerMap> jFTVMOmZXAyLrOkvCNojzbPSnWuh;

					private int mxwxbFAXjsddWLzJCRqIZpsssjH;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return VyjDbmBLgjSzWMYUuHvHSAHgrTWMA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VyjDbmBLgjSzWMYUuHvHSAHgrTWMA;
						}
					}

					[DebuggerHidden]
					public LFkQbnFWvnRiifWISjCQLYAVHkzE(int P_0)
					{
						cNYOIDjGAdixwgUSQrsAqZpbXhVrA = P_0;
						RgOqskzqZXAohlSguhCzhvcvndqY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = cNYOIDjGAdixwgUSQrsAqZpbXhVrA;
						MapHelper abaySPfHPccmXDrIMzbsDVuDigVfA = AbaySPfHPccmXDrIMzbsDVuDigVfA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							cNYOIDjGAdixwgUSQrsAqZpbXhVrA = -1;
							goto IL_00b0;
						}
						cNYOIDjGAdixwgUSQrsAqZpbXhVrA = -1;
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = abaySPfHPccmXDrIMzbsDVuDigVfA.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(qVQBKqEIApNmgJFhnOUzmfGmIjAi);
						int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(dkdgIJjLWZHWeCNBNMUrNzwKslku);
						if (num2 < 0)
						{
							return false;
						}
						jFTVMOmZXAyLrOkvCNojzbPSnWuh = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num2).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
						mxwxbFAXjsddWLzJCRqIZpsssjH = 0;
						goto IL_00c2;
						IL_00c2:
						if (mxwxbFAXjsddWLzJCRqIZpsssjH < jFTVMOmZXAyLrOkvCNojzbPSnWuh.Count)
						{
							if (jFTVMOmZXAyLrOkvCNojzbPSnWuh[mxwxbFAXjsddWLzJCRqIZpsssjH].categoryId == RcptvKLvaSoXUdswMexxsBIbEVMD)
							{
								VyjDbmBLgjSzWMYUuHvHSAHgrTWMA = jFTVMOmZXAyLrOkvCNojzbPSnWuh[mxwxbFAXjsddWLzJCRqIZpsssjH];
								cNYOIDjGAdixwgUSQrsAqZpbXhVrA = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						mxwxbFAXjsddWLzJCRqIZpsssjH++;
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
						LFkQbnFWvnRiifWISjCQLYAVHkzE lFkQbnFWvnRiifWISjCQLYAVHkzE;
						if (cNYOIDjGAdixwgUSQrsAqZpbXhVrA == -2 && RgOqskzqZXAohlSguhCzhvcvndqY == Environment.CurrentManagedThreadId)
						{
							cNYOIDjGAdixwgUSQrsAqZpbXhVrA = 0;
							lFkQbnFWvnRiifWISjCQLYAVHkzE = this;
						}
						else
						{
							lFkQbnFWvnRiifWISjCQLYAVHkzE = new LFkQbnFWvnRiifWISjCQLYAVHkzE(0);
							lFkQbnFWvnRiifWISjCQLYAVHkzE.AbaySPfHPccmXDrIMzbsDVuDigVfA = AbaySPfHPccmXDrIMzbsDVuDigVfA;
						}
						lFkQbnFWvnRiifWISjCQLYAVHkzE.qVQBKqEIApNmgJFhnOUzmfGmIjAi = uGxjaYsVvbFqbNnYKyHtLFmtkMaQ;
						lFkQbnFWvnRiifWISjCQLYAVHkzE.dkdgIJjLWZHWeCNBNMUrNzwKslku = aZJXfMYNWGzbhaGlnihkhlNiYUXW;
						lFkQbnFWvnRiifWISjCQLYAVHkzE.RcptvKLvaSoXUdswMexxsBIbEVMD = uxNYOcNFLFHWVmoxIaiIlSTyhTYN;
						return lFkQbnFWvnRiifWISjCQLYAVHkzE;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class sVOnxiCixoXZcjvpdCLFqFtljuZv<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int SsURHLQtnEMStiIwbLQauJvzBfAX;

					private _0001 wgvCNRLCmoHMbPAIytEdjKUatoWF;

					private int bsSeCphxTdhJWsPKStwaysTuqVOt;

					public MapHelper lQuNAJOTLqcaJSKVvVdjYeyaEJVG;

					private int RfhIJQiVqUhSfENHKhcmEHYDIDGaB;

					public int EfnGejLTWAZbFJeATrWHYUoRvnGb;

					private int ZgZjQUDbebTwJMrkBQjVFDXdATmd;

					public int JGXwDrrnWwgFFfxGqrjXLKbCfFmTA;

					private IList<_0001> NvxrvhSeJpnjYuQaojGZQcQWrpZO;

					private int dKSuFnlSiCPvDbBjodfNnTHImxPi;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return wgvCNRLCmoHMbPAIytEdjKUatoWF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wgvCNRLCmoHMbPAIytEdjKUatoWF;
						}
					}

					[DebuggerHidden]
					public sVOnxiCixoXZcjvpdCLFqFtljuZv(int P_0)
					{
						SsURHLQtnEMStiIwbLQauJvzBfAX = P_0;
						bsSeCphxTdhJWsPKStwaysTuqVOt = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int ssURHLQtnEMStiIwbLQauJvzBfAX = SsURHLQtnEMStiIwbLQauJvzBfAX;
						MapHelper mapHelper = lQuNAJOTLqcaJSKVvVdjYeyaEJVG;
						if (ssURHLQtnEMStiIwbLQauJvzBfAX != 0)
						{
							if (ssURHLQtnEMStiIwbLQauJvzBfAX != 1)
							{
								return false;
							}
							SsURHLQtnEMStiIwbLQauJvzBfAX = -1;
							goto IL_00b9;
						}
						SsURHLQtnEMStiIwbLQauJvzBfAX = -1;
						ControllerType controllerType = moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<_0001>();
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(RfhIJQiVqUhSfENHKhcmEHYDIDGaB);
						if (num < 0)
						{
							return false;
						}
						NvxrvhSeJpnjYuQaojGZQcQWrpZO = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.LNnZRItgVASjgkpqiLDpWkcwbmMJ<_0001>();
						dKSuFnlSiCPvDbBjodfNnTHImxPi = 0;
						goto IL_00cb;
						IL_00cb:
						if (dKSuFnlSiCPvDbBjodfNnTHImxPi < NvxrvhSeJpnjYuQaojGZQcQWrpZO.Count)
						{
							if (NvxrvhSeJpnjYuQaojGZQcQWrpZO[dKSuFnlSiCPvDbBjodfNnTHImxPi].categoryId == ZgZjQUDbebTwJMrkBQjVFDXdATmd)
							{
								wgvCNRLCmoHMbPAIytEdjKUatoWF = NvxrvhSeJpnjYuQaojGZQcQWrpZO[dKSuFnlSiCPvDbBjodfNnTHImxPi];
								SsURHLQtnEMStiIwbLQauJvzBfAX = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						dKSuFnlSiCPvDbBjodfNnTHImxPi++;
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
						sVOnxiCixoXZcjvpdCLFqFtljuZv<_0001> sVOnxiCixoXZcjvpdCLFqFtljuZv2;
						if (SsURHLQtnEMStiIwbLQauJvzBfAX == -2 && bsSeCphxTdhJWsPKStwaysTuqVOt == Environment.CurrentManagedThreadId)
						{
							SsURHLQtnEMStiIwbLQauJvzBfAX = 0;
							sVOnxiCixoXZcjvpdCLFqFtljuZv2 = this;
						}
						else
						{
							sVOnxiCixoXZcjvpdCLFqFtljuZv2 = new sVOnxiCixoXZcjvpdCLFqFtljuZv<_0001>(0);
							sVOnxiCixoXZcjvpdCLFqFtljuZv2.lQuNAJOTLqcaJSKVvVdjYeyaEJVG = lQuNAJOTLqcaJSKVvVdjYeyaEJVG;
						}
						sVOnxiCixoXZcjvpdCLFqFtljuZv2.RfhIJQiVqUhSfENHKhcmEHYDIDGaB = EfnGejLTWAZbFJeATrWHYUoRvnGb;
						sVOnxiCixoXZcjvpdCLFqFtljuZv2.ZgZjQUDbebTwJMrkBQjVFDXdATmd = JGXwDrrnWwgFFfxGqrjXLKbCfFmTA;
						return sVOnxiCixoXZcjvpdCLFqFtljuZv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class gBmWVeIEMukjJacbfnHjwxOluIcX : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int euBYKWxncZBmqaAUbUdNbsvzEfitA;

					private ActionElementMap WeQDyuzljicCiCCUMhENowFhKlie;

					private int YLJyoZHcKoKbysdKHXTJEwrucyul;

					public MapHelper iUvxhvdfdQGWMbqPOSDfWdUzqeTSA;

					private int agyfvxDhWEvHSqCzqqqVOkvkSPDHA;

					public int XjfgNCEbWmfkjvqebHmxERviLRSzA;

					private bool JyZbghDkKWANWbmyggiiEMgTxAjW;

					public bool EYJfFfShNooSKakejDEnHtxcsrhsA;

					private int LmSswGIIJvvuIGMKzLHhTOEWEEl;

					private int TtZqhnwDPJpTiGFhkFsVkvBoengAA;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr yWTuMyWnsAUZnQWTOGBXLGHtnjNj;

					private int hxfLdXafVtmQTYhHspvLWkxngNQD;

					private int ZeWobHimoNFUeXaxfdLnJRDfTaLC;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb mlRjdydCpqiGUHRZFPVVVnagDRsH;

					private int vheiiOGiEqelztviojzKetRwNGIdA;

					private int OMrMVBQVdVepTKCChWMrLhJIPGiN;

					private IEnumerator<ActionElementMap> KcgBpDeDHxKjygVREKkSkGJZFwWz;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WeQDyuzljicCiCCUMhENowFhKlie;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WeQDyuzljicCiCCUMhENowFhKlie;
						}
					}

					[DebuggerHidden]
					public gBmWVeIEMukjJacbfnHjwxOluIcX(int P_0)
					{
						euBYKWxncZBmqaAUbUdNbsvzEfitA = P_0;
						YLJyoZHcKoKbysdKHXTJEwrucyul = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = euBYKWxncZBmqaAUbUdNbsvzEfitA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								mPpMqNELRnBBKsjGthHcwQFsBZKF();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = euBYKWxncZBmqaAUbUdNbsvzEfitA;
							MapHelper mapHelper = iUvxhvdfdQGWMbqPOSDfWdUzqeTSA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								euBYKWxncZBmqaAUbUdNbsvzEfitA = -3;
								goto IL_016c;
							}
							euBYKWxncZBmqaAUbUdNbsvzEfitA = -1;
							if (ReInput._id != mapHelper.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
							{
								ReInput.CheckInitialized(mapHelper.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
								return false;
							}
							if (agyfvxDhWEvHSqCzqqqVOkvkSPDHA < 0)
							{
								return false;
							}
							LmSswGIIJvvuIGMKzLHhTOEWEEl = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
							TtZqhnwDPJpTiGFhkFsVkvBoengAA = 0;
							goto IL_01ec;
							IL_016c:
							if (KcgBpDeDHxKjygVREKkSkGJZFwWz.MoveNext())
							{
								ActionElementMap current = KcgBpDeDHxKjygVREKkSkGJZFwWz.Current;
								WeQDyuzljicCiCCUMhENowFhKlie = current;
								euBYKWxncZBmqaAUbUdNbsvzEfitA = 1;
								return true;
							}
							mPpMqNELRnBBKsjGthHcwQFsBZKF();
							KcgBpDeDHxKjygVREKkSkGJZFwWz = null;
							goto IL_0186;
							IL_0186:
							OMrMVBQVdVepTKCChWMrLhJIPGiN++;
							goto IL_0198;
							IL_01c2:
							if (ZeWobHimoNFUeXaxfdLnJRDfTaLC < hxfLdXafVtmQTYhHspvLWkxngNQD)
							{
								mlRjdydCpqiGUHRZFPVVVnagDRsH = yWTuMyWnsAUZnQWTOGBXLGHtnjNj.AWmOltvgZLyyeShVGMDDYeiwNhPG(ZeWobHimoNFUeXaxfdLnJRDfTaLC).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								vheiiOGiEqelztviojzKetRwNGIdA = mlRjdydCpqiGUHRZFPVVVnagDRsH.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								OMrMVBQVdVepTKCChWMrLhJIPGiN = 0;
								goto IL_0198;
							}
							yWTuMyWnsAUZnQWTOGBXLGHtnjNj = null;
							TtZqhnwDPJpTiGFhkFsVkvBoengAA++;
							goto IL_01ec;
							IL_0198:
							if (OMrMVBQVdVepTKCChWMrLhJIPGiN < vheiiOGiEqelztviojzKetRwNGIdA)
							{
								ControllerMap controllerMap = mlRjdydCpqiGUHRZFPVVVnagDRsH.sraFvIhbtwaREyBqnZUbJclkEDGC(OMrMVBQVdVepTKCChWMrLhJIPGiN);
								if ((!JyZbghDkKWANWbmyggiiEMgTxAjW || controllerMap.enabled) && controllerMap.ContainsAction(agyfvxDhWEvHSqCzqqqVOkvkSPDHA))
								{
									KcgBpDeDHxKjygVREKkSkGJZFwWz = controllerMap.ElementMapsWithAction(agyfvxDhWEvHSqCzqqqVOkvkSPDHA, JyZbghDkKWANWbmyggiiEMgTxAjW).GetEnumerator();
									euBYKWxncZBmqaAUbUdNbsvzEfitA = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							mlRjdydCpqiGUHRZFPVVVnagDRsH = null;
							ZeWobHimoNFUeXaxfdLnJRDfTaLC++;
							goto IL_01c2;
							IL_01ec:
							if (TtZqhnwDPJpTiGFhkFsVkvBoengAA < LmSswGIIJvvuIGMKzLHhTOEWEEl)
							{
								yWTuMyWnsAUZnQWTOGBXLGHtnjNj = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(TtZqhnwDPJpTiGFhkFsVkvBoengAA);
								hxfLdXafVtmQTYhHspvLWkxngNQD = yWTuMyWnsAUZnQWTOGBXLGHtnjNj.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
								ZeWobHimoNFUeXaxfdLnJRDfTaLC = 0;
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

					private void mPpMqNELRnBBKsjGthHcwQFsBZKF()
					{
						euBYKWxncZBmqaAUbUdNbsvzEfitA = -1;
						if (KcgBpDeDHxKjygVREKkSkGJZFwWz != null)
						{
							KcgBpDeDHxKjygVREKkSkGJZFwWz.Dispose();
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
						gBmWVeIEMukjJacbfnHjwxOluIcX gBmWVeIEMukjJacbfnHjwxOluIcX2;
						if (euBYKWxncZBmqaAUbUdNbsvzEfitA == -2 && YLJyoZHcKoKbysdKHXTJEwrucyul == Environment.CurrentManagedThreadId)
						{
							euBYKWxncZBmqaAUbUdNbsvzEfitA = 0;
							gBmWVeIEMukjJacbfnHjwxOluIcX2 = this;
						}
						else
						{
							gBmWVeIEMukjJacbfnHjwxOluIcX2 = new gBmWVeIEMukjJacbfnHjwxOluIcX(0);
							gBmWVeIEMukjJacbfnHjwxOluIcX2.iUvxhvdfdQGWMbqPOSDfWdUzqeTSA = iUvxhvdfdQGWMbqPOSDfWdUzqeTSA;
						}
						gBmWVeIEMukjJacbfnHjwxOluIcX2.agyfvxDhWEvHSqCzqqqVOkvkSPDHA = XjfgNCEbWmfkjvqebHmxERviLRSzA;
						gBmWVeIEMukjJacbfnHjwxOluIcX2.JyZbghDkKWANWbmyggiiEMgTxAjW = EYJfFfShNooSKakejDEnHtxcsrhsA;
						return gBmWVeIEMukjJacbfnHjwxOluIcX2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class VXbleZgRxUDrPsontxXpDzmBYWTf : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int GSrQDZMJwDwRZubZsyaatwcyGkNy;

					private ActionElementMap tDgegxLbKQfQTGGhQOdUECQtKawGb;

					private int rqeYWEHdMHYGHAcIefNjFvKDOHaGb;

					private IControllerElementTarget gBLtmXeGRvaKtjRxWDJkEafPAnQx;

					public IControllerElementTarget XgsLpBceesEXTdbBYOFbuSrOOAMLA;

					public MapHelper WsftHbUHQILzxCHLJqDampREdVqd;

					private bool uXHhaCEMxLalScHPDzLZLHAEaBIEA;

					public bool tMvZOFpETEOKNXuFSoyFdzcuDDKH;

					private bool edqFkJiMtESpyFQVvEFHzJHPrLwHA;

					public bool NZaCoKhOirjpRmDFVBvDgMiaqSDI;

					private int VwwOQsdNjJxhLAivawtkPecucgjZ;

					public int lhnAZihTauFmSUsnXyiXnsCUDobJb;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr RyltfgZVKzmGTUqOBzbnMbRrGBdO;

					private int mQuAFJanOEFqHHvlJUIOZzSEbDbD;

					private int TkrlIqmkewDaJSOIkhNlHQktbbnWA;

					private IList<ControllerMap> RbnKVrZehxwcRZLrkURTQFvEARMq;

					private int CFxqbKSGqOUFKnhtkaFDkZfAsNCd;

					private int yMOcFWgKypQydObyCIVgWSiUhEzAA;

					private TempListPool.TList<ActionElementMap> CUzHacljLyETQeiGerwADPASjFSgb;

					private List<ActionElementMap>.Enumerator yXxEQuDxvyixGgtjphovavbBLrcPA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return tDgegxLbKQfQTGGhQOdUECQtKawGb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tDgegxLbKQfQTGGhQOdUECQtKawGb;
						}
					}

					[DebuggerHidden]
					public VXbleZgRxUDrPsontxXpDzmBYWTf(int P_0)
					{
						GSrQDZMJwDwRZubZsyaatwcyGkNy = P_0;
						rqeYWEHdMHYGHAcIefNjFvKDOHaGb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gSrQDZMJwDwRZubZsyaatwcyGkNy = GSrQDZMJwDwRZubZsyaatwcyGkNy;
						if ((uint)(gSrQDZMJwDwRZubZsyaatwcyGkNy - -4) > 1u && gSrQDZMJwDwRZubZsyaatwcyGkNy != 1)
						{
							return;
						}
						try
						{
							if (gSrQDZMJwDwRZubZsyaatwcyGkNy != -4 && gSrQDZMJwDwRZubZsyaatwcyGkNy != 1)
							{
								return;
							}
							try
							{
							}
							finally
							{
								ejwUmBmGYFhZcKgOFYdANzCSNPDu();
							}
						}
						finally
						{
							rGtLmGxGIwHsiCoyaYCxQyzdQFsVA();
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gSrQDZMJwDwRZubZsyaatwcyGkNy = GSrQDZMJwDwRZubZsyaatwcyGkNy;
							MapHelper wsftHbUHQILzxCHLJqDampREdVqd = WsftHbUHQILzxCHLJqDampREdVqd;
							if (gSrQDZMJwDwRZubZsyaatwcyGkNy != 0)
							{
								if (gSrQDZMJwDwRZubZsyaatwcyGkNy != 1)
								{
									return false;
								}
								GSrQDZMJwDwRZubZsyaatwcyGkNy = -4;
								goto IL_017c;
							}
							GSrQDZMJwDwRZubZsyaatwcyGkNy = -1;
							if (gBLtmXeGRvaKtjRxWDJkEafPAnQx == null)
							{
								return false;
							}
							Controller controller = gBLtmXeGRvaKtjRxWDJkEafPAnQx.controller;
							if (controller == null)
							{
								return false;
							}
							RyltfgZVKzmGTUqOBzbnMbRrGBdO = wsftHbUHQILzxCHLJqDampREdVqd.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controller.type);
							mQuAFJanOEFqHHvlJUIOZzSEbDbD = RyltfgZVKzmGTUqOBzbnMbRrGBdO.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							TkrlIqmkewDaJSOIkhNlHQktbbnWA = 0;
							goto IL_01e4;
							IL_017c:
							if (yXxEQuDxvyixGgtjphovavbBLrcPA.MoveNext())
							{
								ActionElementMap current = yXxEQuDxvyixGgtjphovavbBLrcPA.Current;
								tDgegxLbKQfQTGGhQOdUECQtKawGb = current;
								GSrQDZMJwDwRZubZsyaatwcyGkNy = 1;
								return true;
							}
							ejwUmBmGYFhZcKgOFYdANzCSNPDu();
							yXxEQuDxvyixGgtjphovavbBLrcPA = default(List<ActionElementMap>.Enumerator);
							rGtLmGxGIwHsiCoyaYCxQyzdQFsVA();
							CUzHacljLyETQeiGerwADPASjFSgb = null;
							goto IL_01a8;
							IL_01e4:
							if (TkrlIqmkewDaJSOIkhNlHQktbbnWA < mQuAFJanOEFqHHvlJUIOZzSEbDbD)
							{
								jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = RyltfgZVKzmGTUqOBzbnMbRrGBdO.AWmOltvgZLyyeShVGMDDYeiwNhPG(TkrlIqmkewDaJSOIkhNlHQktbbnWA).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								_ = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								RbnKVrZehxwcRZLrkURTQFvEARMq = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
								CFxqbKSGqOUFKnhtkaFDkZfAsNCd = RbnKVrZehxwcRZLrkURTQFvEARMq.Count;
								yMOcFWgKypQydObyCIVgWSiUhEzAA = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (yMOcFWgKypQydObyCIVgWSiUhEzAA < CFxqbKSGqOUFKnhtkaFDkZfAsNCd)
							{
								ControllerMap controllerMap = RbnKVrZehxwcRZLrkURTQFvEARMq[yMOcFWgKypQydObyCIVgWSiUhEzAA];
								if (!uXHhaCEMxLalScHPDzLZLHAEaBIEA || controllerMap.enabled)
								{
									CUzHacljLyETQeiGerwADPASjFSgb = TempListPool.GetTList<ActionElementMap>();
									GSrQDZMJwDwRZubZsyaatwcyGkNy = -3;
									List<ActionElementMap> list = CUzHacljLyETQeiGerwADPASjFSgb.list;
									controllerMap.ggkUfUXAPQaWoiBsYcQlTMWUVBprA(gBLtmXeGRvaKtjRxWDJkEafPAnQx, edqFkJiMtESpyFQVvEFHzJHPrLwHA, VwwOQsdNjJxhLAivawtkPecucgjZ, uXHhaCEMxLalScHPDzLZLHAEaBIEA, list, true, out var _);
									yXxEQuDxvyixGgtjphovavbBLrcPA = list.GetEnumerator();
									GSrQDZMJwDwRZubZsyaatwcyGkNy = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							RbnKVrZehxwcRZLrkURTQFvEARMq = null;
							TkrlIqmkewDaJSOIkhNlHQktbbnWA++;
							goto IL_01e4;
							IL_01a8:
							yMOcFWgKypQydObyCIVgWSiUhEzAA++;
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

					private void rGtLmGxGIwHsiCoyaYCxQyzdQFsVA()
					{
						GSrQDZMJwDwRZubZsyaatwcyGkNy = -1;
						if (CUzHacljLyETQeiGerwADPASjFSgb != null)
						{
							((IDisposable)CUzHacljLyETQeiGerwADPASjFSgb).Dispose();
						}
					}

					private void ejwUmBmGYFhZcKgOFYdANzCSNPDu()
					{
						GSrQDZMJwDwRZubZsyaatwcyGkNy = -3;
						((IDisposable)yXxEQuDxvyixGgtjphovavbBLrcPA/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						VXbleZgRxUDrPsontxXpDzmBYWTf vXbleZgRxUDrPsontxXpDzmBYWTf;
						if (GSrQDZMJwDwRZubZsyaatwcyGkNy == -2 && rqeYWEHdMHYGHAcIefNjFvKDOHaGb == Environment.CurrentManagedThreadId)
						{
							GSrQDZMJwDwRZubZsyaatwcyGkNy = 0;
							vXbleZgRxUDrPsontxXpDzmBYWTf = this;
						}
						else
						{
							vXbleZgRxUDrPsontxXpDzmBYWTf = new VXbleZgRxUDrPsontxXpDzmBYWTf(0);
							vXbleZgRxUDrPsontxXpDzmBYWTf.WsftHbUHQILzxCHLJqDampREdVqd = WsftHbUHQILzxCHLJqDampREdVqd;
						}
						vXbleZgRxUDrPsontxXpDzmBYWTf.gBLtmXeGRvaKtjRxWDJkEafPAnQx = XgsLpBceesEXTdbBYOFbuSrOOAMLA;
						vXbleZgRxUDrPsontxXpDzmBYWTf.edqFkJiMtESpyFQVvEFHzJHPrLwHA = NZaCoKhOirjpRmDFVBvDgMiaqSDI;
						vXbleZgRxUDrPsontxXpDzmBYWTf.VwwOQsdNjJxhLAivawtkPecucgjZ = lhnAZihTauFmSUsnXyiXnsCUDobJb;
						vXbleZgRxUDrPsontxXpDzmBYWTf.uXHhaCEMxLalScHPDzLZLHAEaBIEA = tMvZOFpETEOKNXuFSoyFdzcuDDKH;
						return vXbleZgRxUDrPsontxXpDzmBYWTf;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class SBSohTDLognIlltXfjEryluipybL : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int bnUmPfvgIiIQeKfCKXGRocrbXKdc;

					private ControllerMap hbPWvnWqopFFVfkzXvhmLmGylRhL;

					private int chChSeWIILPJWYtVOSkPYOjvwILP;

					public MapHelper YuHamRyfoBiHfALefruzwUVrWxEd;

					private int ZlmQrVeYzJdmSdXWQuOYFClzBygDA;

					private int aJJgsSfbnkEJaffoIyEKAMuFtGFQ;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr sBbQDqOyUbeuyvpDGljfAuYwaIgd;

					private int kqfastVAGMgNUJBKNNQghLucZiyp;

					private int ecOptSiknKIrECvhyoPsnmDcPnoAA;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb kEOIrXliKwfIMAvuvGaMlqOsjiLzA;

					private int AARwBOQJIpjYXPmpFnfXGCekbobS;

					private int yxvGsChQaAogwuYGhfCzcThAkEWvB;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return hbPWvnWqopFFVfkzXvhmLmGylRhL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hbPWvnWqopFFVfkzXvhmLmGylRhL;
						}
					}

					[DebuggerHidden]
					public SBSohTDLognIlltXfjEryluipybL(int P_0)
					{
						bnUmPfvgIiIQeKfCKXGRocrbXKdc = P_0;
						chChSeWIILPJWYtVOSkPYOjvwILP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = bnUmPfvgIiIQeKfCKXGRocrbXKdc;
						MapHelper yuHamRyfoBiHfALefruzwUVrWxEd = YuHamRyfoBiHfALefruzwUVrWxEd;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							bnUmPfvgIiIQeKfCKXGRocrbXKdc = -1;
							yxvGsChQaAogwuYGhfCzcThAkEWvB++;
							goto IL_0104;
						}
						bnUmPfvgIiIQeKfCKXGRocrbXKdc = -1;
						if (ReInput._id != yuHamRyfoBiHfALefruzwUVrWxEd.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
						{
							ReInput.CheckInitialized(yuHamRyfoBiHfALefruzwUVrWxEd.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
							return false;
						}
						ZlmQrVeYzJdmSdXWQuOYFClzBygDA = yuHamRyfoBiHfALefruzwUVrWxEd.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
						aJJgsSfbnkEJaffoIyEKAMuFtGFQ = 0;
						goto IL_0151;
						IL_0104:
						if (yxvGsChQaAogwuYGhfCzcThAkEWvB < AARwBOQJIpjYXPmpFnfXGCekbobS)
						{
							hbPWvnWqopFFVfkzXvhmLmGylRhL = kEOIrXliKwfIMAvuvGaMlqOsjiLzA.sraFvIhbtwaREyBqnZUbJclkEDGC(yxvGsChQaAogwuYGhfCzcThAkEWvB);
							bnUmPfvgIiIQeKfCKXGRocrbXKdc = 1;
							return true;
						}
						kEOIrXliKwfIMAvuvGaMlqOsjiLzA = null;
						ecOptSiknKIrECvhyoPsnmDcPnoAA++;
						goto IL_0129;
						IL_0129:
						if (ecOptSiknKIrECvhyoPsnmDcPnoAA < kqfastVAGMgNUJBKNNQghLucZiyp)
						{
							kEOIrXliKwfIMAvuvGaMlqOsjiLzA = sBbQDqOyUbeuyvpDGljfAuYwaIgd.AWmOltvgZLyyeShVGMDDYeiwNhPG(ecOptSiknKIrECvhyoPsnmDcPnoAA).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							AARwBOQJIpjYXPmpFnfXGCekbobS = kEOIrXliKwfIMAvuvGaMlqOsjiLzA.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							yxvGsChQaAogwuYGhfCzcThAkEWvB = 0;
							goto IL_0104;
						}
						sBbQDqOyUbeuyvpDGljfAuYwaIgd = null;
						aJJgsSfbnkEJaffoIyEKAMuFtGFQ++;
						goto IL_0151;
						IL_0151:
						if (aJJgsSfbnkEJaffoIyEKAMuFtGFQ < ZlmQrVeYzJdmSdXWQuOYFClzBygDA)
						{
							sBbQDqOyUbeuyvpDGljfAuYwaIgd = yuHamRyfoBiHfALefruzwUVrWxEd.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(aJJgsSfbnkEJaffoIyEKAMuFtGFQ);
							kqfastVAGMgNUJBKNNQghLucZiyp = sBbQDqOyUbeuyvpDGljfAuYwaIgd.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							ecOptSiknKIrECvhyoPsnmDcPnoAA = 0;
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
						SBSohTDLognIlltXfjEryluipybL sBSohTDLognIlltXfjEryluipybL;
						if (bnUmPfvgIiIQeKfCKXGRocrbXKdc == -2 && chChSeWIILPJWYtVOSkPYOjvwILP == Environment.CurrentManagedThreadId)
						{
							bnUmPfvgIiIQeKfCKXGRocrbXKdc = 0;
							sBSohTDLognIlltXfjEryluipybL = this;
						}
						else
						{
							sBSohTDLognIlltXfjEryluipybL = new SBSohTDLognIlltXfjEryluipybL(0);
							sBSohTDLognIlltXfjEryluipybL.YuHamRyfoBiHfALefruzwUVrWxEd = YuHamRyfoBiHfALefruzwUVrWxEd;
						}
						return sBSohTDLognIlltXfjEryluipybL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class VZTuawNVsxBRQGrvwybKVGQuVwaC<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int myfGnATSXQQsDPlGjhtjfKcQbwQcb;

					private _0001 aFbeWqSKCLhTiPfjNjnwAhZcjQNCA;

					private int xuFUOCyeuxwvMXoWSqxDFkDLpVNn;

					public MapHelper uGRfvXfQnuWNggDMiNuiJtrPcZBEb;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr XhvAUarwIsivojiupQcsVikUmCte;

					private int SZTROLLJZTzmjXNoBwmkJnJfYfCE;

					private int LILbtlCMBWbidtmxbqoFFFxxbBRQA;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb kmNiKKgbrJXkvnDXHzyluoEcvqsq;

					private int tntcyUBVdmyBgqEJINPaADpgTmzM;

					private int iXuXtLZRlFfhSUIeXFZTJwoLsDsm;

					private int mdsWaFpITrGMoKTVbHVSMiwXMLeWA;

					private int iFcWEgCiHQaysTDkwIQOGOhKWexq;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return aFbeWqSKCLhTiPfjNjnwAhZcjQNCA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aFbeWqSKCLhTiPfjNjnwAhZcjQNCA;
						}
					}

					[DebuggerHidden]
					public VZTuawNVsxBRQGrvwybKVGQuVwaC(int P_0)
					{
						myfGnATSXQQsDPlGjhtjfKcQbwQcb = P_0;
						xuFUOCyeuxwvMXoWSqxDFkDLpVNn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = myfGnATSXQQsDPlGjhtjfKcQbwQcb;
						MapHelper mapHelper = uGRfvXfQnuWNggDMiNuiJtrPcZBEb;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							myfGnATSXQQsDPlGjhtjfKcQbwQcb = -1;
							if (ReInput._id != mapHelper.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
							{
								ReInput.CheckInitialized(mapHelper.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
								return false;
							}
							if (moNrVnhMyxFSevnVWYTclYHmdtVI.UZAFWWKgIIIkiKjsWvxCGmCOwHhdA<_0001>(out var controllerType))
							{
								XhvAUarwIsivojiupQcsVikUmCte = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
								SZTROLLJZTzmjXNoBwmkJnJfYfCE = XhvAUarwIsivojiupQcsVikUmCte.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
								LILbtlCMBWbidtmxbqoFFFxxbBRQA = 0;
								goto IL_011b;
							}
							SZTROLLJZTzmjXNoBwmkJnJfYfCE = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
							LILbtlCMBWbidtmxbqoFFFxxbBRQA = 0;
							goto IL_0264;
						}
						case 1:
							myfGnATSXQQsDPlGjhtjfKcQbwQcb = -1;
							iXuXtLZRlFfhSUIeXFZTJwoLsDsm++;
							goto IL_00f6;
						case 2:
							{
								myfGnATSXQQsDPlGjhtjfKcQbwQcb = -1;
								goto IL_0207;
							}
							IL_0207:
							iFcWEgCiHQaysTDkwIQOGOhKWexq++;
							goto IL_0217;
							IL_0264:
							if (LILbtlCMBWbidtmxbqoFFFxxbBRQA >= SZTROLLJZTzmjXNoBwmkJnJfYfCE)
							{
								break;
							}
							XhvAUarwIsivojiupQcsVikUmCte = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(LILbtlCMBWbidtmxbqoFFFxxbBRQA);
							tntcyUBVdmyBgqEJINPaADpgTmzM = XhvAUarwIsivojiupQcsVikUmCte.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							iXuXtLZRlFfhSUIeXFZTJwoLsDsm = 0;
							goto IL_023c;
							IL_011b:
							if (LILbtlCMBWbidtmxbqoFFFxxbBRQA < SZTROLLJZTzmjXNoBwmkJnJfYfCE)
							{
								kmNiKKgbrJXkvnDXHzyluoEcvqsq = XhvAUarwIsivojiupQcsVikUmCte.AWmOltvgZLyyeShVGMDDYeiwNhPG(LILbtlCMBWbidtmxbqoFFFxxbBRQA).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								tntcyUBVdmyBgqEJINPaADpgTmzM = kmNiKKgbrJXkvnDXHzyluoEcvqsq.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								iXuXtLZRlFfhSUIeXFZTJwoLsDsm = 0;
								goto IL_00f6;
							}
							XhvAUarwIsivojiupQcsVikUmCte = null;
							break;
							IL_0217:
							if (iFcWEgCiHQaysTDkwIQOGOhKWexq < mdsWaFpITrGMoKTVbHVSMiwXMLeWA)
							{
								if (kmNiKKgbrJXkvnDXHzyluoEcvqsq.sraFvIhbtwaREyBqnZUbJclkEDGC(iFcWEgCiHQaysTDkwIQOGOhKWexq) is _0001 val)
								{
									aFbeWqSKCLhTiPfjNjnwAhZcjQNCA = val;
									myfGnATSXQQsDPlGjhtjfKcQbwQcb = 2;
									return true;
								}
								goto IL_0207;
							}
							kmNiKKgbrJXkvnDXHzyluoEcvqsq = null;
							iXuXtLZRlFfhSUIeXFZTJwoLsDsm++;
							goto IL_023c;
							IL_023c:
							if (iXuXtLZRlFfhSUIeXFZTJwoLsDsm < tntcyUBVdmyBgqEJINPaADpgTmzM)
							{
								kmNiKKgbrJXkvnDXHzyluoEcvqsq = XhvAUarwIsivojiupQcsVikUmCte.AWmOltvgZLyyeShVGMDDYeiwNhPG(iXuXtLZRlFfhSUIeXFZTJwoLsDsm).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								mdsWaFpITrGMoKTVbHVSMiwXMLeWA = kmNiKKgbrJXkvnDXHzyluoEcvqsq.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								iFcWEgCiHQaysTDkwIQOGOhKWexq = 0;
								goto IL_0217;
							}
							XhvAUarwIsivojiupQcsVikUmCte = null;
							LILbtlCMBWbidtmxbqoFFFxxbBRQA++;
							goto IL_0264;
							IL_00f6:
							if (iXuXtLZRlFfhSUIeXFZTJwoLsDsm < tntcyUBVdmyBgqEJINPaADpgTmzM)
							{
								aFbeWqSKCLhTiPfjNjnwAhZcjQNCA = (_0001)kmNiKKgbrJXkvnDXHzyluoEcvqsq.sraFvIhbtwaREyBqnZUbJclkEDGC(iXuXtLZRlFfhSUIeXFZTJwoLsDsm);
								myfGnATSXQQsDPlGjhtjfKcQbwQcb = 1;
								return true;
							}
							kmNiKKgbrJXkvnDXHzyluoEcvqsq = null;
							LILbtlCMBWbidtmxbqoFFFxxbBRQA++;
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
						VZTuawNVsxBRQGrvwybKVGQuVwaC<_0001> vZTuawNVsxBRQGrvwybKVGQuVwaC;
						if (myfGnATSXQQsDPlGjhtjfKcQbwQcb == -2 && xuFUOCyeuxwvMXoWSqxDFkDLpVNn == Environment.CurrentManagedThreadId)
						{
							myfGnATSXQQsDPlGjhtjfKcQbwQcb = 0;
							vZTuawNVsxBRQGrvwybKVGQuVwaC = this;
						}
						else
						{
							vZTuawNVsxBRQGrvwybKVGQuVwaC = new VZTuawNVsxBRQGrvwybKVGQuVwaC<_0001>(0);
							vZTuawNVsxBRQGrvwybKVGQuVwaC.uGRfvXfQnuWNggDMiNuiJtrPcZBEb = uGRfvXfQnuWNggDMiNuiJtrPcZBEb;
						}
						return vZTuawNVsxBRQGrvwybKVGQuVwaC;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class piLVernuspcoOvOfcMsMaYRZJeRT : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int RDbvWqXfCwBzMZdhfLZaPZwdriSj;

					private ControllerMap YEEcyChEUNMjvHfycYBknEOseMOgA;

					private int QHAZJlmQewZbUtGBBbDyVcabhhQs;

					public MapHelper hrBHITuYMmItTlLYyWOTsnBnbNyc;

					private ControllerType rbLrWOivWbNEZNhsgBsTDeyXvrTK;

					public ControllerType wxBIJDIdQKMtCTOGJexKuXblYMMV;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr qhhcrkBAPLpQlvmMNgAvBLgGyVnnB;

					private int pueladyqrRWAXxiUEjOQJGRtqiuq;

					private int eWNMKRLcWfagsprboqdTZCNbONvo;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb JsuNtCjOCbRfXNDRoDRsojkabLpA;

					private int PdZjXEGDYkSbFHDDGAmREXMVJCIAb;

					private int cRNzHLucRmLwGZnmRxAshzMtWBCk;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return YEEcyChEUNMjvHfycYBknEOseMOgA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YEEcyChEUNMjvHfycYBknEOseMOgA;
						}
					}

					[DebuggerHidden]
					public piLVernuspcoOvOfcMsMaYRZJeRT(int P_0)
					{
						RDbvWqXfCwBzMZdhfLZaPZwdriSj = P_0;
						QHAZJlmQewZbUtGBBbDyVcabhhQs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int rDbvWqXfCwBzMZdhfLZaPZwdriSj = RDbvWqXfCwBzMZdhfLZaPZwdriSj;
						MapHelper mapHelper = hrBHITuYMmItTlLYyWOTsnBnbNyc;
						if (rDbvWqXfCwBzMZdhfLZaPZwdriSj != 0)
						{
							if (rDbvWqXfCwBzMZdhfLZaPZwdriSj != 1)
							{
								return false;
							}
							RDbvWqXfCwBzMZdhfLZaPZwdriSj = -1;
							cRNzHLucRmLwGZnmRxAshzMtWBCk++;
							goto IL_00e2;
						}
						RDbvWqXfCwBzMZdhfLZaPZwdriSj = -1;
						if (ReInput._id != mapHelper.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
						{
							ReInput.CheckInitialized(mapHelper.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
							return false;
						}
						qhhcrkBAPLpQlvmMNgAvBLgGyVnnB = mapHelper.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(rbLrWOivWbNEZNhsgBsTDeyXvrTK);
						pueladyqrRWAXxiUEjOQJGRtqiuq = qhhcrkBAPLpQlvmMNgAvBLgGyVnnB.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						eWNMKRLcWfagsprboqdTZCNbONvo = 0;
						goto IL_0107;
						IL_00e2:
						if (cRNzHLucRmLwGZnmRxAshzMtWBCk < PdZjXEGDYkSbFHDDGAmREXMVJCIAb)
						{
							YEEcyChEUNMjvHfycYBknEOseMOgA = JsuNtCjOCbRfXNDRoDRsojkabLpA.sraFvIhbtwaREyBqnZUbJclkEDGC(cRNzHLucRmLwGZnmRxAshzMtWBCk);
							RDbvWqXfCwBzMZdhfLZaPZwdriSj = 1;
							return true;
						}
						JsuNtCjOCbRfXNDRoDRsojkabLpA = null;
						eWNMKRLcWfagsprboqdTZCNbONvo++;
						goto IL_0107;
						IL_0107:
						if (eWNMKRLcWfagsprboqdTZCNbONvo < pueladyqrRWAXxiUEjOQJGRtqiuq)
						{
							JsuNtCjOCbRfXNDRoDRsojkabLpA = qhhcrkBAPLpQlvmMNgAvBLgGyVnnB.AWmOltvgZLyyeShVGMDDYeiwNhPG(eWNMKRLcWfagsprboqdTZCNbONvo).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							PdZjXEGDYkSbFHDDGAmREXMVJCIAb = JsuNtCjOCbRfXNDRoDRsojkabLpA.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							cRNzHLucRmLwGZnmRxAshzMtWBCk = 0;
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
						piLVernuspcoOvOfcMsMaYRZJeRT piLVernuspcoOvOfcMsMaYRZJeRT2;
						if (RDbvWqXfCwBzMZdhfLZaPZwdriSj == -2 && QHAZJlmQewZbUtGBBbDyVcabhhQs == Environment.CurrentManagedThreadId)
						{
							RDbvWqXfCwBzMZdhfLZaPZwdriSj = 0;
							piLVernuspcoOvOfcMsMaYRZJeRT2 = this;
						}
						else
						{
							piLVernuspcoOvOfcMsMaYRZJeRT2 = new piLVernuspcoOvOfcMsMaYRZJeRT(0);
							piLVernuspcoOvOfcMsMaYRZJeRT2.hrBHITuYMmItTlLYyWOTsnBnbNyc = hrBHITuYMmItTlLYyWOTsnBnbNyc;
						}
						piLVernuspcoOvOfcMsMaYRZJeRT2.rbLrWOivWbNEZNhsgBsTDeyXvrTK = wxBIJDIdQKMtCTOGJexKuXblYMMV;
						return piLVernuspcoOvOfcMsMaYRZJeRT2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class wuknIXANpcaNbbanzUcYoXZYEjVc : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int GVxFZiMwJmzeBLIfXohLWhnaXYyu;

					private ControllerMap DLGsdDmBbbVexVktuUwQYnPINwnd;

					private int WnIbxhENRJIdalosmBefNeSNQtwHA;

					public MapHelper RTerWSzAGObCNjVhqlPqlFtmmwbHA;

					private int tgQgJeeAcvbKXtQuccDcghalzAYk;

					public int JEOkglQffMkxzbqQauqyAzbZnSEW;

					private int IrllUfsKXKrZSwHYvykmjrYatlZH;

					private int ujqGerngLdaUpoTGKVTcRPCaIvQH;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr xzSWbBtNwDCoWyyvcudMhdhnMMdT;

					private int WrLTURiteKSjFsXUPSWYZvroUQof;

					private int jybFaegQODjsiFVSXPmqQaYtgpUL;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb HCiSwOXtxsYYbQGhhLAFHkSKLlKF;

					private int XoDBWPAHmklmViXufhADcmGeGflQB;

					private int kBjrJOVZOvdTtBCxzviueLRgBgnG;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return DLGsdDmBbbVexVktuUwQYnPINwnd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DLGsdDmBbbVexVktuUwQYnPINwnd;
						}
					}

					[DebuggerHidden]
					public wuknIXANpcaNbbanzUcYoXZYEjVc(int P_0)
					{
						GVxFZiMwJmzeBLIfXohLWhnaXYyu = P_0;
						WnIbxhENRJIdalosmBefNeSNQtwHA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int gVxFZiMwJmzeBLIfXohLWhnaXYyu = GVxFZiMwJmzeBLIfXohLWhnaXYyu;
						MapHelper rTerWSzAGObCNjVhqlPqlFtmmwbHA = RTerWSzAGObCNjVhqlPqlFtmmwbHA;
						if (gVxFZiMwJmzeBLIfXohLWhnaXYyu != 0)
						{
							if (gVxFZiMwJmzeBLIfXohLWhnaXYyu != 1)
							{
								return false;
							}
							GVxFZiMwJmzeBLIfXohLWhnaXYyu = -1;
							goto IL_0104;
						}
						GVxFZiMwJmzeBLIfXohLWhnaXYyu = -1;
						if (ReInput._id != rTerWSzAGObCNjVhqlPqlFtmmwbHA.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
						{
							ReInput.CheckInitialized(rTerWSzAGObCNjVhqlPqlFtmmwbHA.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
							return false;
						}
						IrllUfsKXKrZSwHYvykmjrYatlZH = rTerWSzAGObCNjVhqlPqlFtmmwbHA.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
						ujqGerngLdaUpoTGKVTcRPCaIvQH = 0;
						goto IL_0161;
						IL_0104:
						kBjrJOVZOvdTtBCxzviueLRgBgnG++;
						goto IL_0114;
						IL_0161:
						if (ujqGerngLdaUpoTGKVTcRPCaIvQH < IrllUfsKXKrZSwHYvykmjrYatlZH)
						{
							xzSWbBtNwDCoWyyvcudMhdhnMMdT = rTerWSzAGObCNjVhqlPqlFtmmwbHA.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(ujqGerngLdaUpoTGKVTcRPCaIvQH);
							WrLTURiteKSjFsXUPSWYZvroUQof = xzSWbBtNwDCoWyyvcudMhdhnMMdT.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							jybFaegQODjsiFVSXPmqQaYtgpUL = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (kBjrJOVZOvdTtBCxzviueLRgBgnG < XoDBWPAHmklmViXufhADcmGeGflQB)
						{
							ControllerMap controllerMap = HCiSwOXtxsYYbQGhhLAFHkSKLlKF.sraFvIhbtwaREyBqnZUbJclkEDGC(kBjrJOVZOvdTtBCxzviueLRgBgnG);
							if (controllerMap.categoryId == tgQgJeeAcvbKXtQuccDcghalzAYk)
							{
								DLGsdDmBbbVexVktuUwQYnPINwnd = controllerMap;
								GVxFZiMwJmzeBLIfXohLWhnaXYyu = 1;
								return true;
							}
							goto IL_0104;
						}
						HCiSwOXtxsYYbQGhhLAFHkSKLlKF = null;
						jybFaegQODjsiFVSXPmqQaYtgpUL++;
						goto IL_0139;
						IL_0139:
						if (jybFaegQODjsiFVSXPmqQaYtgpUL < WrLTURiteKSjFsXUPSWYZvroUQof)
						{
							HCiSwOXtxsYYbQGhhLAFHkSKLlKF = xzSWbBtNwDCoWyyvcudMhdhnMMdT.AWmOltvgZLyyeShVGMDDYeiwNhPG(jybFaegQODjsiFVSXPmqQaYtgpUL).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							XoDBWPAHmklmViXufhADcmGeGflQB = HCiSwOXtxsYYbQGhhLAFHkSKLlKF.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							kBjrJOVZOvdTtBCxzviueLRgBgnG = 0;
							goto IL_0114;
						}
						xzSWbBtNwDCoWyyvcudMhdhnMMdT = null;
						ujqGerngLdaUpoTGKVTcRPCaIvQH++;
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
						wuknIXANpcaNbbanzUcYoXZYEjVc wuknIXANpcaNbbanzUcYoXZYEjVc2;
						if (GVxFZiMwJmzeBLIfXohLWhnaXYyu == -2 && WnIbxhENRJIdalosmBefNeSNQtwHA == Environment.CurrentManagedThreadId)
						{
							GVxFZiMwJmzeBLIfXohLWhnaXYyu = 0;
							wuknIXANpcaNbbanzUcYoXZYEjVc2 = this;
						}
						else
						{
							wuknIXANpcaNbbanzUcYoXZYEjVc2 = new wuknIXANpcaNbbanzUcYoXZYEjVc(0);
							wuknIXANpcaNbbanzUcYoXZYEjVc2.RTerWSzAGObCNjVhqlPqlFtmmwbHA = RTerWSzAGObCNjVhqlPqlFtmmwbHA;
						}
						wuknIXANpcaNbbanzUcYoXZYEjVc2.tgQgJeeAcvbKXtQuccDcghalzAYk = JEOkglQffMkxzbqQauqyAzbZnSEW;
						return wuknIXANpcaNbbanzUcYoXZYEjVc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class kpROmIESUWSAtAQVcRkQtiwvaFal<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int KUdsFeoDAlhCfDooGkUPpBSodhgib;

					private _0001 ucfiKFhCenigdeEcVEWBYGwqGFFMA;

					private int VTQPrerzZuKpayrxCNCKZYnbAzWM;

					public MapHelper ZygjaDPPphjIkGdKXwvZfkgXoIWoA;

					private int CmSMSLDIUmLParqIOWDNcGTuHNaw;

					public int yvJhTnFInmbzlUntYaaEksDfDbrK;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr wunEczYUrFCuDsnicSNIqDpnAUxJ;

					private int ogADxGCXhUkauOQCZKmciQGdwZcac;

					private int ePeFmSfzSShSZGnnUkpWRUZaOHItA;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb AeXrKYcVtqNVcRDrKTvEzBMVJBJy;

					private int VLGtvnGBjMhbcApPEGZvGLvKKxfNc;

					private int iOhavDnvVXWtNPrhhKPZbEigPkXL;

					private int dkLzQmDriSwADcydzxUPDgxiqqYK;

					private int cxsKGngioLIDWunZuvvTxGjrxHbQ;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return ucfiKFhCenigdeEcVEWBYGwqGFFMA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ucfiKFhCenigdeEcVEWBYGwqGFFMA;
						}
					}

					[DebuggerHidden]
					public kpROmIESUWSAtAQVcRkQtiwvaFal(int P_0)
					{
						KUdsFeoDAlhCfDooGkUPpBSodhgib = P_0;
						VTQPrerzZuKpayrxCNCKZYnbAzWM = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int kUdsFeoDAlhCfDooGkUPpBSodhgib = KUdsFeoDAlhCfDooGkUPpBSodhgib;
						MapHelper zygjaDPPphjIkGdKXwvZfkgXoIWoA = ZygjaDPPphjIkGdKXwvZfkgXoIWoA;
						switch (kUdsFeoDAlhCfDooGkUPpBSodhgib)
						{
						default:
							return false;
						case 0:
						{
							KUdsFeoDAlhCfDooGkUPpBSodhgib = -1;
							if (ReInput._id != zygjaDPPphjIkGdKXwvZfkgXoIWoA.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
							{
								ReInput.CheckInitialized(zygjaDPPphjIkGdKXwvZfkgXoIWoA.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
								return false;
							}
							if (moNrVnhMyxFSevnVWYTclYHmdtVI.UZAFWWKgIIIkiKjsWvxCGmCOwHhdA<_0001>(out var _))
							{
								wunEczYUrFCuDsnicSNIqDpnAUxJ = zygjaDPPphjIkGdKXwvZfkgXoIWoA.HVBznEjBNYHSynFXednauozNdqqs<_0001>();
								ogADxGCXhUkauOQCZKmciQGdwZcac = wunEczYUrFCuDsnicSNIqDpnAUxJ.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
								ePeFmSfzSShSZGnnUkpWRUZaOHItA = 0;
								goto IL_0124;
							}
							ogADxGCXhUkauOQCZKmciQGdwZcac = zygjaDPPphjIkGdKXwvZfkgXoIWoA.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
							ePeFmSfzSShSZGnnUkpWRUZaOHItA = 0;
							goto IL_0287;
						}
						case 1:
							KUdsFeoDAlhCfDooGkUPpBSodhgib = -1;
							goto IL_00eb;
						case 2:
							{
								KUdsFeoDAlhCfDooGkUPpBSodhgib = -1;
								goto IL_0224;
							}
							IL_0224:
							cxsKGngioLIDWunZuvvTxGjrxHbQ++;
							goto IL_0236;
							IL_00eb:
							iOhavDnvVXWtNPrhhKPZbEigPkXL++;
							goto IL_00fd;
							IL_0124:
							if (ePeFmSfzSShSZGnnUkpWRUZaOHItA < ogADxGCXhUkauOQCZKmciQGdwZcac)
							{
								AeXrKYcVtqNVcRDrKTvEzBMVJBJy = wunEczYUrFCuDsnicSNIqDpnAUxJ.AWmOltvgZLyyeShVGMDDYeiwNhPG(ePeFmSfzSShSZGnnUkpWRUZaOHItA).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								VLGtvnGBjMhbcApPEGZvGLvKKxfNc = AeXrKYcVtqNVcRDrKTvEzBMVJBJy.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								iOhavDnvVXWtNPrhhKPZbEigPkXL = 0;
								goto IL_00fd;
							}
							wunEczYUrFCuDsnicSNIqDpnAUxJ = null;
							break;
							IL_0287:
							if (ePeFmSfzSShSZGnnUkpWRUZaOHItA >= ogADxGCXhUkauOQCZKmciQGdwZcac)
							{
								break;
							}
							wunEczYUrFCuDsnicSNIqDpnAUxJ = zygjaDPPphjIkGdKXwvZfkgXoIWoA.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(ePeFmSfzSShSZGnnUkpWRUZaOHItA);
							VLGtvnGBjMhbcApPEGZvGLvKKxfNc = wunEczYUrFCuDsnicSNIqDpnAUxJ.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							iOhavDnvVXWtNPrhhKPZbEigPkXL = 0;
							goto IL_025d;
							IL_0236:
							if (cxsKGngioLIDWunZuvvTxGjrxHbQ < dkLzQmDriSwADcydzxUPDgxiqqYK)
							{
								if (AeXrKYcVtqNVcRDrKTvEzBMVJBJy.sraFvIhbtwaREyBqnZUbJclkEDGC(cxsKGngioLIDWunZuvvTxGjrxHbQ) is _0001 val && val.categoryId == CmSMSLDIUmLParqIOWDNcGTuHNaw)
								{
									ucfiKFhCenigdeEcVEWBYGwqGFFMA = val;
									KUdsFeoDAlhCfDooGkUPpBSodhgib = 2;
									return true;
								}
								goto IL_0224;
							}
							AeXrKYcVtqNVcRDrKTvEzBMVJBJy = null;
							iOhavDnvVXWtNPrhhKPZbEigPkXL++;
							goto IL_025d;
							IL_00fd:
							if (iOhavDnvVXWtNPrhhKPZbEigPkXL < VLGtvnGBjMhbcApPEGZvGLvKKxfNc)
							{
								ControllerMap controllerMap = AeXrKYcVtqNVcRDrKTvEzBMVJBJy.sraFvIhbtwaREyBqnZUbJclkEDGC(iOhavDnvVXWtNPrhhKPZbEigPkXL);
								if (controllerMap.categoryId == CmSMSLDIUmLParqIOWDNcGTuHNaw)
								{
									ucfiKFhCenigdeEcVEWBYGwqGFFMA = (_0001)controllerMap;
									KUdsFeoDAlhCfDooGkUPpBSodhgib = 1;
									return true;
								}
								goto IL_00eb;
							}
							AeXrKYcVtqNVcRDrKTvEzBMVJBJy = null;
							ePeFmSfzSShSZGnnUkpWRUZaOHItA++;
							goto IL_0124;
							IL_025d:
							if (iOhavDnvVXWtNPrhhKPZbEigPkXL < VLGtvnGBjMhbcApPEGZvGLvKKxfNc)
							{
								AeXrKYcVtqNVcRDrKTvEzBMVJBJy = wunEczYUrFCuDsnicSNIqDpnAUxJ.AWmOltvgZLyyeShVGMDDYeiwNhPG(iOhavDnvVXWtNPrhhKPZbEigPkXL).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
								dkLzQmDriSwADcydzxUPDgxiqqYK = AeXrKYcVtqNVcRDrKTvEzBMVJBJy.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
								cxsKGngioLIDWunZuvvTxGjrxHbQ = 0;
								goto IL_0236;
							}
							wunEczYUrFCuDsnicSNIqDpnAUxJ = null;
							ePeFmSfzSShSZGnnUkpWRUZaOHItA++;
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
						kpROmIESUWSAtAQVcRkQtiwvaFal<_0001> kpROmIESUWSAtAQVcRkQtiwvaFal2;
						if (KUdsFeoDAlhCfDooGkUPpBSodhgib == -2 && VTQPrerzZuKpayrxCNCKZYnbAzWM == Environment.CurrentManagedThreadId)
						{
							KUdsFeoDAlhCfDooGkUPpBSodhgib = 0;
							kpROmIESUWSAtAQVcRkQtiwvaFal2 = this;
						}
						else
						{
							kpROmIESUWSAtAQVcRkQtiwvaFal2 = new kpROmIESUWSAtAQVcRkQtiwvaFal<_0001>(0);
							kpROmIESUWSAtAQVcRkQtiwvaFal2.ZygjaDPPphjIkGdKXwvZfkgXoIWoA = ZygjaDPPphjIkGdKXwvZfkgXoIWoA;
						}
						kpROmIESUWSAtAQVcRkQtiwvaFal2.CmSMSLDIUmLParqIOWDNcGTuHNaw = yvJhTnFInmbzlUntYaaEksDfDbrK;
						return kpROmIESUWSAtAQVcRkQtiwvaFal2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class MeIrCBOvqmfEMSsRTvAmXasGRlsK : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int oUzFKEwGexdAbjuIFrPnBUxnhSnbb;

					private ControllerMap pbjTNJqlOWDPKuvkludiRlLtWLGL;

					private int JJcJPjSsRYmgJAWoCJUPvDhnNgrP;

					public MapHelper DbMLzadYMDoQKkoqZdLojxrFdiIH;

					private ControllerType zsOGWWoVlFYTlYHUPPXefYpoIagg;

					public ControllerType tRGmlsVgbjEyJhMngmKvKYdHEZFfA;

					private int jcoEvlSvKAhxsSqjChOucmeGrqswA;

					public int szqiyWrIApKqeeoiVUHvUtYyUIze;

					private jpRWCWnSWjIHbShgmaKtrbKdevFr YiBCfKpHekcnLyfLLgkVXgNCwqdK;

					private int sGscSmkuuCiKdbcaOzcbMUKAMeom;

					private int mlMnEDLLwzhFuvWbaPKWrzHecmHP;

					private jeabHUrstoKHDRpNBCZSFbPvOBSHb KiGDUraaYVqKNGBPQjEJhtzjmlobB;

					private int YNNqsWmlFXhrUChqpIwCNOxlhPzS;

					private int NsZyXWXaIOEbYgzEXWfZaJDbJxCAA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return pbjTNJqlOWDPKuvkludiRlLtWLGL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return pbjTNJqlOWDPKuvkludiRlLtWLGL;
						}
					}

					[DebuggerHidden]
					public MeIrCBOvqmfEMSsRTvAmXasGRlsK(int P_0)
					{
						oUzFKEwGexdAbjuIFrPnBUxnhSnbb = P_0;
						JJcJPjSsRYmgJAWoCJUPvDhnNgrP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = oUzFKEwGexdAbjuIFrPnBUxnhSnbb;
						MapHelper dbMLzadYMDoQKkoqZdLojxrFdiIH = DbMLzadYMDoQKkoqZdLojxrFdiIH;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							oUzFKEwGexdAbjuIFrPnBUxnhSnbb = -1;
							goto IL_00e2;
						}
						oUzFKEwGexdAbjuIFrPnBUxnhSnbb = -1;
						if (ReInput._id != dbMLzadYMDoQKkoqZdLojxrFdiIH.CPYQAhZYsVejvVnCfXAAeYhsEVJV)
						{
							ReInput.CheckInitialized(dbMLzadYMDoQKkoqZdLojxrFdiIH.CPYQAhZYsVejvVnCfXAAeYhsEVJV);
							return false;
						}
						YiBCfKpHekcnLyfLLgkVXgNCwqdK = dbMLzadYMDoQKkoqZdLojxrFdiIH.UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(zsOGWWoVlFYTlYHUPPXefYpoIagg);
						sGscSmkuuCiKdbcaOzcbMUKAMeom = YiBCfKpHekcnLyfLLgkVXgNCwqdK.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						mlMnEDLLwzhFuvWbaPKWrzHecmHP = 0;
						goto IL_0117;
						IL_00f2:
						if (NsZyXWXaIOEbYgzEXWfZaJDbJxCAA < YNNqsWmlFXhrUChqpIwCNOxlhPzS)
						{
							ControllerMap controllerMap = KiGDUraaYVqKNGBPQjEJhtzjmlobB.sraFvIhbtwaREyBqnZUbJclkEDGC(NsZyXWXaIOEbYgzEXWfZaJDbJxCAA);
							if (controllerMap.categoryId == jcoEvlSvKAhxsSqjChOucmeGrqswA)
							{
								pbjTNJqlOWDPKuvkludiRlLtWLGL = controllerMap;
								oUzFKEwGexdAbjuIFrPnBUxnhSnbb = 1;
								return true;
							}
							goto IL_00e2;
						}
						KiGDUraaYVqKNGBPQjEJhtzjmlobB = null;
						mlMnEDLLwzhFuvWbaPKWrzHecmHP++;
						goto IL_0117;
						IL_00e2:
						NsZyXWXaIOEbYgzEXWfZaJDbJxCAA++;
						goto IL_00f2;
						IL_0117:
						if (mlMnEDLLwzhFuvWbaPKWrzHecmHP < sGscSmkuuCiKdbcaOzcbMUKAMeom)
						{
							KiGDUraaYVqKNGBPQjEJhtzjmlobB = YiBCfKpHekcnLyfLLgkVXgNCwqdK.AWmOltvgZLyyeShVGMDDYeiwNhPG(mlMnEDLLwzhFuvWbaPKWrzHecmHP).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							YNNqsWmlFXhrUChqpIwCNOxlhPzS = KiGDUraaYVqKNGBPQjEJhtzjmlobB.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							NsZyXWXaIOEbYgzEXWfZaJDbJxCAA = 0;
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
						MeIrCBOvqmfEMSsRTvAmXasGRlsK meIrCBOvqmfEMSsRTvAmXasGRlsK;
						if (oUzFKEwGexdAbjuIFrPnBUxnhSnbb == -2 && JJcJPjSsRYmgJAWoCJUPvDhnNgrP == Environment.CurrentManagedThreadId)
						{
							oUzFKEwGexdAbjuIFrPnBUxnhSnbb = 0;
							meIrCBOvqmfEMSsRTvAmXasGRlsK = this;
						}
						else
						{
							meIrCBOvqmfEMSsRTvAmXasGRlsK = new MeIrCBOvqmfEMSsRTvAmXasGRlsK(0);
							meIrCBOvqmfEMSsRTvAmXasGRlsK.DbMLzadYMDoQKkoqZdLojxrFdiIH = DbMLzadYMDoQKkoqZdLojxrFdiIH;
						}
						meIrCBOvqmfEMSsRTvAmXasGRlsK.jcoEvlSvKAhxsSqjChOucmeGrqswA = szqiyWrIApKqeeoiVUHvUtYyUIze;
						meIrCBOvqmfEMSsRTvAmXasGRlsK.zsOGWWoVlFYTlYHUPPXefYpoIagg = tRGmlsVgbjEyJhMngmKvKYdHEZFfA;
						return meIrCBOvqmfEMSsRTvAmXasGRlsK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly GdOldZdkCaFseCtTjjUkzAqYRXRaA dnObRmzcqeFmeLxfaguqRXgQhioE;

				private Player fFOOZwoPaInojjhNMJojtuFOvZWs;

				private ControllerHelper UpHoGoqMGXnLIaICOqgMBZfNytOj;

				private readonly ControllerMapEnabler PeyElLVrfvefLjNbNBEzYlkjUOosA;

				private readonly ControllerMapLayoutManager ZFMBPvRUfwoSEOhPPBJBcagWpKpK;

				private readonly int CPYQAhZYsVejvVnCfXAAeYhsEVJV;

				public ControllerMapLayoutManager layoutManager => ZFMBPvRUfwoSEOhPPBJBcagWpKpK;

				public ControllerMapEnabler mapEnabler => PeyElLVrfvefLjNbNBEzYlkjUOosA;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
						{
							ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return fFOOZwoPaInojjhNMJojtuFOvZWs.FLHSwBondVMFwICiFrRDNPxufqTW.KPosqjUxyvnPglXSXWmDpcrqwcsK(fFOOZwoPaInojjhNMJojtuFOvZWs.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, GdOldZdkCaFseCtTjjUkzAqYRXRaA P_2, ControllerMapLayoutManager.SLxTBaXfrhZCyLfCEqNyvKbuXYzr P_3, ControllerMapEnabler.MpLdxmCiVDCEhjPNCfTXmDrkNyfGc P_4)
				{
					CPYQAhZYsVejvVnCfXAAeYhsEVJV = ReInput.id;
					fFOOZwoPaInojjhNMJojtuFOvZWs = P_0;
					UpHoGoqMGXnLIaICOqgMBZfNytOj = P_1;
					dnObRmzcqeFmeLxfaguqRXgQhioE = P_2;
					PeyElLVrfvefLjNbNBEzYlkjUOosA = new ControllerMapEnabler(P_0, P_4);
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK = new ControllerMapLayoutManager(P_0, P_3);
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.ehSAyjNmedqbmedMJpcyZCbhtRlW += PeyElLVrfvefLjNbNBEzYlkjUOosA.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					zOZRdompVpqSYspaNdbFGSRbJOAs<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					fcRWrHlICzTQHVhKadzapMoDhzex<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					oDGtvpTxzLSMhRTtqFEGVFQbuKPl(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					XKuIJEcSzsVCeDAqzpsZhphKlQZG(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					zOZRdompVpqSYspaNdbFGSRbJOAs<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					fcRWrHlICzTQHVhKadzapMoDhzex<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					oDGtvpTxzLSMhRTtqFEGVFQbuKPl(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					XKuIJEcSzsVCeDAqzpsZhphKlQZG(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void zOZRdompVpqSYspaNdbFGSRbJOAs<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						KGaHajjFfRwAjmVMpnkYguxzAQvX(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void fcRWrHlICzTQHVhKadzapMoDhzex<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						TQjpQTSOtBroBVKSNIYtoPylbTSe(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void oDGtvpTxzLSMhRTtqFEGVFQbuKPl(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						KGaHajjFfRwAjmVMpnkYguxzAQvX(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void XKuIJEcSzsVCeDAqzpsZhphKlQZG(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						TQjpQTSOtBroBVKSNIYtoPylbTSe(P_0, P_1, P_2, P_3, P_4);
					}
				}

				[IteratorStateMachine(typeof(SBSohTDLognIlltXfjEryluipybL))]
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new SBSohTDLognIlltXfjEryluipybL(-2)
					{
						YuHamRyfoBiHfALefruzwUVrWxEd = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num; j++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.vIYIzuqmISvoQmLXBgWvuFTaInuK(results, true);
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(VZTuawNVsxBRQGrvwybKVGQuVwaC))]
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new VZTuawNVsxBRQGrvwybKVGQuVwaC<T>(-2)
					{
						uGRfvXfQnuWNggDMiNuiJtrPcZBEb = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (moNrVnhMyxFSevnVWYTclYHmdtVI.UZAFWWKgIIIkiKjsWvxCGmCOwHhdA<T>(out var controllerType))
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int i = 0; i < num; i++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.qbYsBtQDNQUJQIqMoSrmapCKMBOi(results, true);
						}
					}
					else
					{
						int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
						for (int j = 0; j < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; j++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr3 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(j);
							int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr3.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							for (int k = 0; k < num2; k++)
							{
								jpRWCWnSWjIHbShgmaKtrbKdevFr3.AWmOltvgZLyyeShVGMDDYeiwNhPG(k).YjPKnaUBIafYYbhEPJJXDUgXqwPK.qbYsBtQDNQUJQIqMoSrmapCKMBOi(results, true);
							}
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(piLVernuspcoOvOfcMsMaYRZJeRT))]
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new piLVernuspcoOvOfcMsMaYRZJeRT(-2)
					{
						hrBHITuYMmItTlLYyWOTsnBnbNyc = this,
						wxBIJDIdQKMtCTOGJexKuXblYMMV = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.vIYIzuqmISvoQmLXBgWvuFTaInuK(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				[IteratorStateMachine(typeof(wuknIXANpcaNbbanzUcYoXZYEjVc))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new wuknIXANpcaNbbanzUcYoXZYEjVc(-2)
					{
						RTerWSzAGObCNjVhqlPqlFtmmwbHA = this,
						JEOkglQffMkxzbqQauqyAzbZnSEW = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				[IteratorStateMachine(typeof(kpROmIESUWSAtAQVcRkQtiwvaFal))]
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new kpROmIESUWSAtAQVcRkQtiwvaFal<T>(-2)
					{
						ZygjaDPPphjIkGdKXwvZfkgXoIWoA = this,
						yvJhTnFInmbzlUntYaaEksDfDbrK = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				[IteratorStateMachine(typeof(MeIrCBOvqmfEMSsRTvAmXasGRlsK))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new MeIrCBOvqmfEMSsRTvAmXasGRlsK(-2)
					{
						DbMLzadYMDoQKkoqZdLojxrFdiIH = this,
						szqiyWrIApKqeeoiVUHvUtYyUIze = categoryId,
						tRGmlsVgbjEyJhMngmKvKYdHEZFfA = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num; j++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.hchBNRjUIPApDVDpfcSmuIAlzORj(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (moNrVnhMyxFSevnVWYTclYHmdtVI.UZAFWWKgIIIkiKjsWvxCGmCOwHhdA<T>(out var controllerType))
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int i = 0; i < num; i++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.MeIhnZkjzYReobkIzILTghQbSnEdA(categoryId, results, true);
						}
					}
					else
					{
						int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
						for (int j = 0; j < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; j++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr3 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(j);
							int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr3.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
							for (int k = 0; k < num2; k++)
							{
								jpRWCWnSWjIHbShgmaKtrbKdevFr3.AWmOltvgZLyyeShVGMDDYeiwNhPG(k).YjPKnaUBIafYYbhEPJJXDUgXqwPK.MeIhnZkjzYReobkIzILTghQbSnEdA(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.hchBNRjUIPApDVDpfcSmuIAlzORj(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return vOqJJdIXsMnvYMVCABTBDyyCbJdX<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return JkZjEDOaGAPIrMYCnHxQGCCsAEyBA(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					return bncxQRsiJVirUZFIoFeoVdStYxkO(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					return UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType).iueOmjDBOlDOqNGYWGAHBWIslogRA(controllerId)?.YjPKnaUBIafYYbhEPJJXDUgXqwPK.hchBNRjUIPApDVDpfcSmuIAlzORj(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return IDghaNgTkZULxEJuhXJUtiMrXuDA<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					wczNLWUjiDwjnkhfMjCrRBaAdUQr wczNLWUjiDwjnkhfMjCrRBaAdUQr2 = HVBznEjBNYHSynFXednauozNdqqs<T>().iueOmjDBOlDOqNGYWGAHBWIslogRA(controllerId);
					if (wczNLWUjiDwjnkhfMjCrRBaAdUQr2 == null)
					{
						return 0;
					}
					wczNLWUjiDwjnkhfMjCrRBaAdUQr2.YjPKnaUBIafYYbhEPJJXDUgXqwPK.MeIhnZkjzYReobkIzILTghQbSnEdA(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)GcCuwARKXIsVQLsyRmubWraLTVay(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)RHdTvJnkWwBXOZOicfPVrpQYjPNN(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return (T)aEDtkcRTUYMXtajFUKZFhfimCvas(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.ksWwHxSfKUqWChdTDjQNKYWcKHFJ(mapId);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return GcCuwARKXIsVQLsyRmubWraLTVay(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return RHdTvJnkWwBXOZOicfPVrpQYjPNN(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return aEDtkcRTUYMXtajFUKZFhfimCvas(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)YirLhbyqfPRtMttfDBOmeLvsSjIX(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return YirLhbyqfPRtMttfDBOmeLvsSjIX(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						KSOBGvMMiVJljcezpVqGDvtKxubl(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						HxOpWDcNsbfsgzMkvHjbnOawTQtX(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						KSOBGvMMiVJljcezpVqGDvtKxubl(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						KSOBGvMMiVJljcezpVqGDvtKxubl(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						HxOpWDcNsbfsgzMkvHjbnOawTQtX(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						KSOBGvMMiVJljcezpVqGDvtKxubl(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return false;
					}
					return UAoyFJyLFPnkpQhejDkRlPRTiPZR(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return false;
					}
					return UAoyFJyLFPnkpQhejDkRlPRTiPZR(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return false;
					}
					return XFwWPErMRCJFUGAgAwCxKJtqlDsx(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return false;
					}
					return XFwWPErMRCJFUGAgAwCxKJtqlDsx(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						TCwSKUUNqleWyMUBlIGOKTwgjwnr(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						FyKUttCbOWXsLqnYivadpAaqpwfj(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						TCwSKUUNqleWyMUBlIGOKTwgjwnr(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else if (mapId >= 0)
					{
						ktaLdAEbRsKsPuXsCMDRcoTgfVim(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						axWAzkoILsCxOIPmHDDCzsHVfBDaA(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						WArNjVSHePQgVTIDpHMWBzijPXbgA(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else if (mapId >= 0)
					{
						ktaLdAEbRsKsPuXsCMDRcoTgfVim(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						axWAzkoILsCxOIPmHDDCzsHVfBDaA(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						WArNjVSHePQgVTIDpHMWBzijPXbgA(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMaps(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.RfdfQMuYHGCCaTxHAimlmSLRPkdi(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMapsInCategory(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMapsInCategory(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i));
						for (int j = 0; j < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; j++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OHrUdHmOTfLZdmEIAFrYCRnITQgDA(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OHrUdHmOTfLZdmEIAFrYCRnITQgDA(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
						for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.MAZEGuHyWNSimtlGnGcNWtoSFlwj(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMapsInLayout(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.jtDwFcpEeUCSqwxmURPHTITIlFbF(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMapsForController(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMapsForController(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(controllerId);
					if (num >= 0)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.RfdfQMuYHGCCaTxHAimlmSLRPkdi(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(controllerId);
					if (num >= 0)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OHrUdHmOTfLZdmEIAFrYCRnITQgDA(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
					}
					else
					{
						ClearMapsForControllerInLayout(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(controllerId);
					if (num >= 0)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.jtDwFcpEeUCSqwxmURPHTITIlFbF(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					for (int i = 0; i < UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						ClearMaps(UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i), userAssignableOnly);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return AaHvRULeNPYaxFVnHsGSbDCtclgK(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return CymIKzOXORgnUktPQyoFdgQaDvrF(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						ActionElementMap actionElementMap = CymIKzOXORgnUktPQyoFdgQaDvrF(UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return jvzQeOcqNmTZUlgOKBZEtbXGChdw(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return VkPBCjIXLSoMygzDqfJKsoIMckXmA(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(CNawMvTbvBrqEThxvvDpbauqnZgd))]
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new CNawMvTbvBrqEThxvvDpbauqnZgd(-2)
					{
						ZfEEXsTJXekEOgYhwJzsdatKDZDQ = this,
						LCWVHBUCxNAKUXJasvPIBeGEfxrE = actionId,
						vwxtSFZKBmcidybeWnDbumIzfmnCA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					return LhnTCVYYnbpoLDqsvfrMkYdOOCJW(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					return ssOhQiwPnyzmHEigPxBMiqpIxlzg(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return TTTVliXmFBaSBoQAPKBGvJZXIjyS(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return kONVCiBhkJZKtTFuuLoqrTJSWDEg(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return obAihIAdtMBLqPhBveRADrMkZnKIb(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						ActionElementMap actionElementMap = obAihIAdtMBLqPhBveRADrMkZnKIb(UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return pSnFOKMbpjStVpXuEfRaKOKVPaTk(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return RdyLcMqZriPEDCFWdfBbEaTyeHpaA(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(TDIAedsMFJMMYTGWnqTyVqfwbDEO))]
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new TDIAedsMFJMMYTGWnqTyVqfwbDEO(-2)
					{
						TKkDjTkEPgDMeYZXTVSwMJPksLqz = this,
						veGEGEUuariQiHiJtWYkjaIgmStn = actionId,
						XIdfHxxKSpxeMQMiwDbuDaLNOJwX = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return jmJhepqQBMKInOOOAmKOLBdTMDqV(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return YdwWnmxEYlUPcrzeweUNjkphWIYw(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return LdyHxjebXGnKacfNeyernNSnjxQCb(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GnAsbRFugsejtZfVuqkjYfYYEEJm(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return KnaFFAHkDsKPlZfbknPmErTQtCbrA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						ActionElementMap actionElementMap = KnaFFAHkDsKPlZfbknPmErTQtCbrA(UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return tdxEKedArgZAipoHyFUNmrgYarav(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return dGwEUHhLYIQvtuKrxxVnTuDQibAFb(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(gBmWVeIEMukjJacbfnHjwxOluIcX))]
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new gBmWVeIEMukjJacbfnHjwxOluIcX(-2)
					{
						iUvxhvdfdQGWMbqPOSDfWdUzqeTSA = this,
						XjfgNCEbWmfkjvqebHmxERviLRSzA = actionId,
						EYJfFfShNooSKakejDEnHtxcsrhsA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return pGPWcRpUEIboVvVpoMcTXshfdZsG(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					return IaFPyJaxVqtTnprxRzCZRnSIDOhK(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return SkyGBHecePLThPEBLPtLAhTRPdvpA(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, skipDisabledMaps);
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return lwGEreKvNOIDEcHGfNASkilGhvTkc(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, actionId, skipDisabledMaps);
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return lwGEreKvNOIDEcHGfNASkilGhvTkc(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, skipDisabledMaps);
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return CMhCRRgoquVyXwiVYhxyoexyJqhG(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, actionId, skipDisabledMaps);
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return CMhCRRgoquVyXwiVYhxyoexyJqhG(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, skipDisabledMaps, results);
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return uVVQRPqMhfRhaHJKQOUsJPXBldpD(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = QpmNXOwiqgDcvsLLtrkLzeVpLiAW.kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qpmNXOwiqgDcvsLLtrkLzeVpLiAW, actionId, skipDisabledMaps, results);
					QpmNXOwiqgDcvsLLtrkLzeVpLiAW.ldvVnfwjLZGuCeomzYzHsndJPPgX(qpmNXOwiqgDcvsLLtrkLzeVpLiAW);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return uVVQRPqMhfRhaHJKQOUsJPXBldpD(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int actionId = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<T>.array;
					}
					return yJXnUYRHQZEXJDkkUlGIwPWfWokUA<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return WvZxDQIfIyuOGdCEsbciBVVMPGMkA(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<T>.array;
					}
					return fsSKqlXRbrFkSFetlwbpeuMTVfD<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return XvlXhsSetUpOnoWDsrGnOubWAdLo(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						ArrayTools.Combine(ref array, XvlXhsSetUpOnoWDsrGnOubWAdLo(UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int num = 0;
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num2; j++)
						{
							num += jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.URyqjRHIlnWAEJShVVJMvzShsBMi(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int num = 0;
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num2; i++)
					{
						num += jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.URyqjRHIlnWAEJShVVJMvzShsBMi(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					return UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType).iueOmjDBOlDOqNGYWGAHBWIslogRA(controllerId)?.YjPKnaUBIafYYbhEPJJXDUgXqwPK.URyqjRHIlnWAEJShVVJMvzShsBMi(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num2; j++)
						{
							num += jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.avaBWRcfXHAoWvsEInGcUgQANWkFb(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						ControllerType controllerType = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.bJhBQizlEpwNfJaJnhMIhzolqdW(i);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num2; i++)
					{
						num += jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.avaBWRcfXHAoWvsEInGcUgQANWkFb(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num2; i++)
					{
						num += jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.FlarzwTgZkewQwBuAnNDVwoYcyiN(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					return UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controller.type).iueOmjDBOlDOqNGYWGAHBWIslogRA(controller.id)?.YjPKnaUBIafYYbhEPJJXDUgXqwPK.avaBWRcfXHAoWvsEInGcUgQANWkFb(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					return UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controller.type).iueOmjDBOlDOqNGYWGAHBWIslogRA(controller.id)?.YjPKnaUBIafYYbhEPJJXDUgXqwPK.FlarzwTgZkewQwBuAnNDVwoYcyiN(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						GLLFITqShNTyIEXNNhjFKGoqTyIB(false);
						break;
					case ControllerType.Keyboard:
						CNVzMCqaRbuLiMCBvRATJUhGeBHA(false);
						break;
					case ControllerType.Mouse:
						MhirTlpsOVhUveaPclxDpqjUUIOR(false);
						break;
					case ControllerType.Custom:
						gRaKLglCbDeEZwsQmrrwZpifwPzH(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num; j++)
						{
							if (jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK.DIjVoaneOSdSACVsRPnymspIBcmib(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
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
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num; i++)
					{
						if (jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.DIjVoaneOSdSACVsRPnymspIBcmib(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return fFOOZwoPaInojjhNMJojtuFOvZWs.FLHSwBondVMFwICiFrRDNPxufqTW.MrZdBRkTKSFptotNpZzmHmxWnIYX(fFOOZwoPaInojjhNMJojtuFOvZWs.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != CPYQAhZYsVejvVnCfXAAeYhsEVJV)
					{
						ReInput.CheckInitialized(CPYQAhZYsVejvVnCfXAAeYhsEVJV);
						return null;
					}
					return fFOOZwoPaInojjhNMJojtuFOvZWs.FLHSwBondVMFwICiFrRDNPxufqTW.ZJftCxyafRgHdKBNXPAUKBOxxqAiA(fFOOZwoPaInojjhNMJojtuFOvZWs.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, behaviorName);
				}

				internal void BXiYNfMaEPvMTElbKtmrlYRmEmKk()
				{
					PeyElLVrfvefLjNbNBEzYlkjUOosA.LoadDefaults();
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.LoadDefaults();
				}

				internal void GLLFITqShNTyIEXNNhjFKGoqTyIB(bool P_0)
				{
					if (dnObRmzcqeFmeLxfaguqRXgQhioE.GUGXJjYRklAXTbGjSPKSlJgLchtF == null)
					{
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick);
					UpHoGoqMGXnLIaICOqgMBZfNytOj.TYovfIszswbQEXSvpewkGghabwKZ.WqaagYnLMSptLCatcguZFtiufblBb();
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num; i++)
					{
						fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH wwphrnUdZYgdrhKBPyggpYmosQFH = (fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH)jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.YzKYnaKJzjbvJEXDdyXusrltRUPjA();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(j).enabled;
							}
						}
						wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.dunbAEkzIjpkOCwFNHnqFJUcRQDz(false);
						for (int k = 0; k < dnObRmzcqeFmeLxfaguqRXgQhioE.GUGXJjYRklAXTbGjSPKSlJgLchtF.Length; k++)
						{
							zHiMBXnnyVbtCZDDDlmDvzTNxmCd(wwphrnUdZYgdrhKBPyggpYmosQFH.BYlFGRIAVlFFEDTQdwYJaaaeCxfbB, wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP, dnObRmzcqeFmeLxfaguqRXgQhioE.GUGXJjYRklAXTbGjSPKSlJgLchtF[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.YzKYnaKJzjbvJEXDdyXusrltRUPjA());
							for (int l = 0; l < num3; l++)
							{
								wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = false;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.Apply();
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void CNVzMCqaRbuLiMCBvRATJUhGeBHA(bool P_0)
				{
					if (dnObRmzcqeFmeLxfaguqRXgQhioE.SfEUtYQHMqHOyhAvUcdOFhFXoVRFA == null)
					{
						return;
					}
					jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Keyboard).iueOmjDBOlDOqNGYWGAHBWIslogRA(0).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
					bool[] array = null;
					if (!P_0)
					{
						int num = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(i).enabled;
						}
					}
					jeabHUrstoKHDRpNBCZSFbPvOBSHb2.RfdfQMuYHGCCaTxHAimlmSLRPkdi(false);
					for (int j = 0; j < dnObRmzcqeFmeLxfaguqRXgQhioE.SfEUtYQHMqHOyhAvUcdOFhFXoVRFA.Length; j++)
					{
						YvgbLCaTdWCMneyjIddESvlhjraVA yvgbLCaTdWCMneyjIddESvlhjraVA = dnObRmzcqeFmeLxfaguqRXgQhioE.SfEUtYQHMqHOyhAvUcdOFhFXoVRFA[j];
						if (yvgbLCaTdWCMneyjIddESvlhjraVA.pgiZybxRzOTttKujkFILHJlocnbBA >= 0 && yvgbLCaTdWCMneyjIddESvlhjraVA.KkmUcKgYXjsOaZHFkzZUSgjVHYqf >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, yvgbLCaTdWCMneyjIddESvlhjraVA.pgiZybxRzOTttKujkFILHJlocnbBA, yvgbLCaTdWCMneyjIddESvlhjraVA.KkmUcKgYXjsOaZHFkzZUSgjVHYqf);
							if (P_0)
							{
								keyboardMap.enabled = yvgbLCaTdWCMneyjIddESvlhjraVA.HnvKHQfvdSDVMEtErUPbZWcEhJPJ;
							}
							KSOBGvMMiVJljcezpVqGDvtKxubl(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt);
						for (int k = 0; k < num2; k++)
						{
							jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = false;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.Apply();
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void MhirTlpsOVhUveaPclxDpqjUUIOR(bool P_0)
				{
					if (dnObRmzcqeFmeLxfaguqRXgQhioE.OezJfqIkcQGTehLHVkdniwNcVADnB == null)
					{
						return;
					}
					jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Mouse).iueOmjDBOlDOqNGYWGAHBWIslogRA(0).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
					bool[] array = null;
					if (!P_0)
					{
						int num = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(i).enabled;
						}
					}
					jeabHUrstoKHDRpNBCZSFbPvOBSHb2.RfdfQMuYHGCCaTxHAimlmSLRPkdi(false);
					for (int j = 0; j < dnObRmzcqeFmeLxfaguqRXgQhioE.OezJfqIkcQGTehLHVkdniwNcVADnB.Length; j++)
					{
						YvgbLCaTdWCMneyjIddESvlhjraVA yvgbLCaTdWCMneyjIddESvlhjraVA = dnObRmzcqeFmeLxfaguqRXgQhioE.OezJfqIkcQGTehLHVkdniwNcVADnB[j];
						if (yvgbLCaTdWCMneyjIddESvlhjraVA.pgiZybxRzOTttKujkFILHJlocnbBA >= 0 && yvgbLCaTdWCMneyjIddESvlhjraVA.KkmUcKgYXjsOaZHFkzZUSgjVHYqf >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, yvgbLCaTdWCMneyjIddESvlhjraVA.pgiZybxRzOTttKujkFILHJlocnbBA, yvgbLCaTdWCMneyjIddESvlhjraVA.KkmUcKgYXjsOaZHFkzZUSgjVHYqf);
							if (P_0)
							{
								mouseMap.enabled = yvgbLCaTdWCMneyjIddESvlhjraVA.HnvKHQfvdSDVMEtErUPbZWcEhJPJ;
							}
							KSOBGvMMiVJljcezpVqGDvtKxubl(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt);
						for (int k = 0; k < num2; k++)
						{
							jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = false;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.Apply();
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void gRaKLglCbDeEZwsQmrrwZpifwPzH(bool P_0)
				{
					if (dnObRmzcqeFmeLxfaguqRXgQhioE.ofCHzSHloMnZwWhRtVzvOVNoWMLy == null)
					{
						return;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num; i++)
					{
						fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>.wwphrnUdZYgdrhKBPyggpYmosQFH wwphrnUdZYgdrhKBPyggpYmosQFH = (fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>.wwphrnUdZYgdrhKBPyggpYmosQFH)jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.YzKYnaKJzjbvJEXDdyXusrltRUPjA();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(j).enabled;
							}
						}
						wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.dunbAEkzIjpkOCwFNHnqFJUcRQDz(false);
						for (int k = 0; k < dnObRmzcqeFmeLxfaguqRXgQhioE.ofCHzSHloMnZwWhRtVzvOVNoWMLy.Length; k++)
						{
							YTSqTeYqiUPMVCPwddWajmmBplCM(wwphrnUdZYgdrhKBPyggpYmosQFH.BYlFGRIAVlFFEDTQdwYJaaaeCxfbB, wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP, dnObRmzcqeFmeLxfaguqRXgQhioE.ofCHzSHloMnZwWhRtVzvOVNoWMLy[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.YzKYnaKJzjbvJEXDdyXusrltRUPjA());
							for (int l = 0; l < num3; l++)
							{
								wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = false;
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.Apply();
					ZFMBPvRUfwoSEOhPPBJBcagWpKpK.loadFromUserDataStore = loadFromUserDataStore;
				}

				private jpRWCWnSWjIHbShgmaKtrbKdevFr HVBznEjBNYHSynFXednauozNdqqs<_0001>() where _0001 : ControllerMap
				{
					return UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(moNrVnhMyxFSevnVWYTclYHmdtVI.BPfcqinxhiNWUdPZTeGqROmfJAAR<_0001>());
				}

				internal global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> FyAvHiSptgydrMEFzIZcIrdjmWQp(Joystick P_0, bool P_1)
				{
					if (P_0 == null || dnObRmzcqeFmeLxfaguqRXgQhioE.GUGXJjYRklAXTbGjSPKSlJgLchtF == null)
					{
						return null;
					}
					global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> farFCHilnTaPUOHyjpIPWUDENJjC = new global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap>(P_0.id);
					for (int i = 0; i < dnObRmzcqeFmeLxfaguqRXgQhioE.GUGXJjYRklAXTbGjSPKSlJgLchtF.Length; i++)
					{
						zHiMBXnnyVbtCZDDDlmDvzTNxmCd(P_0, farFCHilnTaPUOHyjpIPWUDENJjC, dnObRmzcqeFmeLxfaguqRXgQhioE.GUGXJjYRklAXTbGjSPKSlJgLchtF[i], P_1);
					}
					if (farFCHilnTaPUOHyjpIPWUDENJjC.YzKYnaKJzjbvJEXDdyXusrltRUPjA() == 0)
					{
						return null;
					}
					return farFCHilnTaPUOHyjpIPWUDENJjC;
				}

				private void zHiMBXnnyVbtCZDDDlmDvzTNxmCd(Joystick P_0, global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> P_1, YvgbLCaTdWCMneyjIddESvlhjraVA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.pgiZybxRzOTttKujkFILHJlocnbBA >= 0 && P_2.KkmUcKgYXjsOaZHFkzZUSgjVHYqf >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.xDZwXbEkVZRakTvMLrpwClMerKHh(P_0, P_2.pgiZybxRzOTttKujkFILHJlocnbBA, P_2.KkmUcKgYXjsOaZHFkzZUSgjVHYqf);
						ZObaaEOWJCUGSFVciZmydJCyrGXj(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.HnvKHQfvdSDVMEtErUPbZWcEhJPJ ? BoolOption.True : BoolOption.False);
						}
						P_1.saOUJUcjGXUOuYCxFCGSzztodwQN(joystickMap, boolOption);
					}
				}

				internal global::FarFCHilnTaPUOHyjpIPWUDENJjC<CustomControllerMap> aozCAvnASoxQESrOLHLpJeAUPEPiA(CustomController P_0, bool P_1)
				{
					if (P_0 == null || dnObRmzcqeFmeLxfaguqRXgQhioE.ofCHzSHloMnZwWhRtVzvOVNoWMLy == null)
					{
						return null;
					}
					global::FarFCHilnTaPUOHyjpIPWUDENJjC<CustomControllerMap> farFCHilnTaPUOHyjpIPWUDENJjC = new global::FarFCHilnTaPUOHyjpIPWUDENJjC<CustomControllerMap>(P_0.id);
					for (int i = 0; i < dnObRmzcqeFmeLxfaguqRXgQhioE.ofCHzSHloMnZwWhRtVzvOVNoWMLy.Length; i++)
					{
						YTSqTeYqiUPMVCPwddWajmmBplCM(P_0, farFCHilnTaPUOHyjpIPWUDENJjC, dnObRmzcqeFmeLxfaguqRXgQhioE.ofCHzSHloMnZwWhRtVzvOVNoWMLy[i], P_1);
					}
					if (farFCHilnTaPUOHyjpIPWUDENJjC.YzKYnaKJzjbvJEXDdyXusrltRUPjA() == 0)
					{
						return null;
					}
					return farFCHilnTaPUOHyjpIPWUDENJjC;
				}

				private void YTSqTeYqiUPMVCPwddWajmmBplCM(CustomController P_0, global::FarFCHilnTaPUOHyjpIPWUDENJjC<CustomControllerMap> P_1, YvgbLCaTdWCMneyjIddESvlhjraVA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.pgiZybxRzOTttKujkFILHJlocnbBA >= 0 && P_2.KkmUcKgYXjsOaZHFkzZUSgjVHYqf >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.KXAiRfDQanCwvlzzVuoqYkPCLMYm(P_2.pgiZybxRzOTttKujkFILHJlocnbBA, P_0.sourceControllerId, P_2.KkmUcKgYXjsOaZHFkzZUSgjVHYqf);
						ZObaaEOWJCUGSFVciZmydJCyrGXj(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.HnvKHQfvdSDVMEtErUPbZWcEhJPJ ? BoolOption.True : BoolOption.False);
						}
						P_1.saOUJUcjGXUOuYCxFCGSzztodwQN(customControllerMap, boolOption);
					}
				}

				internal void ZObaaEOWJCUGSFVciZmydJCyrGXj(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = fFOOZwoPaInojjhNMJojtuFOvZWs.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
						P_0.FeQHluiWzbggXquWcpGEIuFssFTaA(P_1);
					}
				}

				private IList<_0001> vOqJJdIXsMnvYMVCABTBDyyCbJdX<_0001>(int P_0) where _0001 : ControllerMap
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = HVBznEjBNYHSynFXednauozNdqqs<_0001>();
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.LNnZRItgVASjgkpqiLDpWkcwbmMJ<_0001>();
				}

				private IList<_0001> TZfvFpOseLVsysEPNdwFHqwWRiLq<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return HVBznEjBNYHSynFXednauozNdqqs<_0001>().LjcKgiNFTsAiJOuexMiTFOdugAEy(P_0)?.YjPKnaUBIafYYbhEPJJXDUgXqwPK.LNnZRItgVASjgkpqiLDpWkcwbmMJ<_0001>();
				}

				private IList<ControllerMap> JkZjEDOaGAPIrMYCnHxQGCCsAEyBA(ControllerType P_0, int P_1)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
				}

				private IList<ControllerMap> TZfvFpOseLVsysEPNdwFHqwWRiLq(Controller P_0)
				{
					return JkZjEDOaGAPIrMYCnHxQGCCsAEyBA(P_0.type, P_0.id);
				}

				private void EBWIPZhPQieBbUPxdPNfsCTXFSPwA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					KGaHajjFfRwAjmVMpnkYguxzAQvX(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void hvIHPqJoAgObWelhSGusQCpnAYyL(Controller P_0, int P_1, int P_2)
				{
					RfjqQNgwXPNRxPIzRCZrqgWvXxpe(P_0, P_1, P_2, BoolOption.Default);
				}

				private void jmOFZcyszpAPNUxyBducTHqFCXYM(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					TQjpQTSOtBroBVKSNIYtoPylbTSe(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void VGFhtrTOWPYkSyCFdEmiMPwsKGTx(Controller P_0, string P_1, string P_2)
				{
					ZFvjKCTqYBrGQHkjnujkqMxpPCsR(P_0, P_1, P_2, BoolOption.Default);
				}

				private void KGaHajjFfRwAjmVMpnkYguxzAQvX(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num >= 0)
					{
						Controller controller = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX;
						ControllerMap controllerMap = ReInput.UserData.gpTdgMWdIjjfKTDdirChMNOgXGTB(controller, P_2, P_3);
						KSOBGvMMiVJljcezpVqGDvtKxubl(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void RfjqQNgwXPNRxPIzRCZrqgWvXxpe(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					KGaHajjFfRwAjmVMpnkYguxzAQvX(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void TQjpQTSOtBroBVKSNIYtoPylbTSe(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						KGaHajjFfRwAjmVMpnkYguxzAQvX(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void ZFvjKCTqYBrGQHkjnujkqMxpPCsR(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					TQjpQTSOtBroBVKSNIYtoPylbTSe(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void HxOpWDcNsbfsgzMkvHjbnOawTQtX(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0.type);
						int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_0.id);
						if (num >= 0)
						{
							ZObaaEOWJCUGSFVciZmydJCyrGXj(P_0, P_1);
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.giIXvKLSxDKSmaaocfSisWudeHUF(P_1, P_2);
							PeyElLVrfvefLjNbNBEzYlkjUOosA.Apply();
						}
					}
				}

				private void KSOBGvMMiVJljcezpVqGDvtKxubl(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						HxOpWDcNsbfsgzMkvHjbnOawTQtX(controller, P_2, P_3);
					}
				}

				private bool UAoyFJyLFPnkpQhejDkRlPRTiPZR(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0).pkBnWPGhiVStKNCTHndxrrusHaYt(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.jQKDXoimuSpEWcCdpBenThEztXonA(P_0);
					if (!controllerMap.MFaAXBJyXaUpDOnUWyDXvVkOxez(P_2))
					{
						return false;
					}
					KSOBGvMMiVJljcezpVqGDvtKxubl(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int cdHdtTYIahUTrJDOTLtvDjMyQZi(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0).pkBnWPGhiVStKNCTHndxrrusHaYt(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (UAoyFJyLFPnkpQhejDkRlPRTiPZR(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool XFwWPErMRCJFUGAgAwCxKJtqlDsx(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0).pkBnWPGhiVStKNCTHndxrrusHaYt(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.jQKDXoimuSpEWcCdpBenThEztXonA(P_0);
					if (!controllerMap.pgQbXDUmKkGKZAkRwZMiPjMIfDeGb(P_2))
					{
						return false;
					}
					KSOBGvMMiVJljcezpVqGDvtKxubl(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int oFbHaBkNnIIpebRNhYCASqcWeMguA(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0).pkBnWPGhiVStKNCTHndxrrusHaYt(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (XFwWPErMRCJFUGAgAwCxKJtqlDsx(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void TCwSKUUNqleWyMUBlIGOKTwgjwnr(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num >= 0)
					{
						Controller controller = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX;
						ControllerMap controllerMap = ControllerMap.CBbGqaKJwSYpkPPFPCLVxIghJIzWA(controller, P_2, P_3);
						KSOBGvMMiVJljcezpVqGDvtKxubl(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void fbaXKscPVRVmChzgMUakRbZLxZch(Controller P_0, int P_1, int P_2)
				{
					TCwSKUUNqleWyMUBlIGOKTwgjwnr(P_0.type, P_0.id, P_1, P_2);
				}

				private void FyKUttCbOWXsLqnYivadpAaqpwfj(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						TCwSKUUNqleWyMUBlIGOKTwgjwnr(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void JxofvvEXrOXSNrIgjlgWQaJMcDQJA(Controller P_0, string P_1, string P_2)
				{
					FyKUttCbOWXsLqnYivadpAaqpwfj(P_0.type, P_0.id, P_1, P_2);
				}

				private void ktaLdAEbRsKsPuXsCMDRcoTgfVim(ControllerType P_0, int P_1, int P_2)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num >= 0)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.TVRGRZEcudMZxfkdkxScLICwPsqnB(P_2);
					}
				}

				private void KAbjGaKHMxcPpmHPOFOegFpcCAbQ(Controller P_0, int P_1)
				{
					ktaLdAEbRsKsPuXsCMDRcoTgfVim(P_0.type, P_0.id, P_1);
				}

				private void FkEEKqsbeyzRtqiaGFtvPcChCIibA(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num >= 0)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.RlaMhWAAZrXfGrEZBQUYJhXxvVYo(P_2);
					}
				}

				private void pigaVnLNfTmeqJxraaVtAjnkcXyM(Controller P_0, ControllerMap P_1)
				{
					ktaLdAEbRsKsPuXsCMDRcoTgfVim(P_0.type, P_0.id, P_1.id);
				}

				private void axWAzkoILsCxOIPmHDDCzsHVfBDaA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num >= 0)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.MAZEGuHyWNSimtlGnGcNWtoSFlwj(P_2, P_3);
					}
				}

				private void augDLOfrYWonxaFgzZoAXfbILQvN(Controller P_0, int P_1, int P_2)
				{
					axWAzkoILsCxOIPmHDDCzsHVfBDaA(P_0.type, P_0.id, P_1, P_2);
				}

				private void WArNjVSHePQgVTIDpHMWBzijPXbgA(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.MAZEGuHyWNSimtlGnGcNWtoSFlwj(mapCategoryId, layoutId);
						}
					}
				}

				private void uxKjePqNNxwNpoOQjHmbksARMZNL(Controller P_0, string P_1, string P_2)
				{
					WArNjVSHePQgVTIDpHMWBzijPXbgA(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap GcCuwARKXIsVQLsyRmubWraLTVay(ControllerType P_0, int P_1, int P_2)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					return jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.ksWwHxSfKUqWChdTDjQNKYWcKHFJ(P_2);
				}

				private ControllerMap veWbCDTgBYxEYOjEpclIaaMTkMQOA(Controller P_0, int P_1)
				{
					return GcCuwARKXIsVQLsyRmubWraLTVay(P_0.type, P_0.id, P_1);
				}

				private ControllerMap RHdTvJnkWwBXOZOicfPVrpQYjPNN(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					return jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.oOKEfEDflQqLComWNArSvJxPANQuA(P_2, P_3);
				}

				private ControllerMap MXWQZLZhQRAeReoKpBeKViJrlTli(Controller P_0, int P_1, int P_2)
				{
					return RHdTvJnkWwBXOZOicfPVrpQYjPNN(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap aEDtkcRTUYMXtajFUKZFhfimCvas(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return RHdTvJnkWwBXOZOicfPVrpQYjPNN(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap ZACOanovoICJMuImMUTqqgmaUxJh(Controller P_0, string P_1, string P_2)
				{
					return aEDtkcRTUYMXtajFUKZFhfimCvas(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap YirLhbyqfPRtMttfDBOmeLvsSjIX(ControllerType P_0, int P_1, int P_2)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					return jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.fKiFNWRMizJllyBXiwbpmCrRAuihA(P_2);
				}

				private ControllerMap TBPvSgJdhzMTpNqdYbKlGeKoRPSbA(Controller P_0, int P_1)
				{
					return YirLhbyqfPRtMttfDBOmeLvsSjIX(P_0.type, P_0.id, P_1);
				}

				private ControllerMap smlcgWcwnlmMusRsRaDoCOpcqXhIb(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return YirLhbyqfPRtMttfDBOmeLvsSjIX(P_0, P_1, mapCategoryId);
				}

				private ControllerMap hKRGHYYBDpeQSsEqaRAcgbLeMlEO(Controller P_0, string P_1)
				{
					return smlcgWcwnlmMusRsRaDoCOpcqXhIb(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] UYKeGICUfWSYiJoGyirujmHYxZJM(ControllerType P_0)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = 0;
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						num += jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; j++)
					{
						jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
						for (int k = 0; k < jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt; k++)
						{
							array[num] = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] WvZxDQIfIyuOGdCEsbciBVVMPGMkA(ControllerType P_0, int P_1, bool P_2)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
					for (int i = 0; i < jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt; i++)
					{
						ControllerMap controllerMap = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX;
						list.Add(ControllerMapSaveData.YpqAOsXFJwAdEKpZuywlBcqBHaBrA(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] yJXnUYRHQZEXJDkkUlGIwPWfWokUA<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = moNrVnhMyxFSevnVWYTclYHmdtVI.dHlGoYwWtiJBUBHSUgoJGERjUnTt<_0001>();
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
					for (int i = 0; i < jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt; i++)
					{
						ControllerMap controllerMap = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX;
						list.Add(ControllerMapSaveData.YpqAOsXFJwAdEKpZuywlBcqBHaBrA<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] XvlXhsSetUpOnoWDsrGnOubWAdLo(ControllerType P_0, bool P_1)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
						for (int j = 0; j < jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt; j++)
						{
							ControllerMap controllerMap = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).LEdXAULnordCtHuhKNePXQiSgnCX;
							list.Add(ControllerMapSaveData.YpqAOsXFJwAdEKpZuywlBcqBHaBrA(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] fsSKqlXRbrFkSFetlwbpeuMTVfD<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = moNrVnhMyxFSevnVWYTclYHmdtVI.dHlGoYwWtiJBUBHSUgoJGERjUnTt<_0001>();
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
						for (int j = 0; j < jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt; j++)
						{
							ControllerMap controllerMap = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).LEdXAULnordCtHuhKNePXQiSgnCX;
							list.Add(ControllerMapSaveData.YpqAOsXFJwAdEKpZuywlBcqBHaBrA<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int oHZxrHXnHiXiUBACGGqPLpWwyvOI(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return 0;
					}
					return jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.hchBNRjUIPApDVDpfcSmuIAlzORj(P_2, P_3, false);
				}

				private int rDudCpHKCkemCsuahLYQScwGsptTA(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return oHZxrHXnHiXiUBACGGqPLpWwyvOI(P_0.type, P_0.id, P_1, P_2);
				}

				private int nXOxIFFPGaJBPDyxhwHXJtPdcUdWA(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return oHZxrHXnHiXiUBACGGqPLpWwyvOI(P_0, P_1, mapCategoryId, P_3);
				}

				private int OALnwMhvZPNiABNPFASWzEamTmSd(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return nXOxIFFPGaJBPDyxhwHXJtPdcUdWA(P_0.type, P_0.id, P_1, P_2);
				}

				[IteratorStateMachine(typeof(LFkQbnFWvnRiifWISjCQLYAVHkzE))]
				private IEnumerable<ControllerMap> bncxQRsiJVirUZFIoFeoVdStYxkO(ControllerType P_0, int P_1, int P_2)
				{
					return new LFkQbnFWvnRiifWISjCQLYAVHkzE(-2)
					{
						AbaySPfHPccmXDrIMzbsDVuDigVfA = this,
						uGxjaYsVvbFqbNnYKyHtLFmtkMaQ = P_0,
						aZJXfMYNWGzbhaGlnihkhlNiYUXW = P_1,
						uxNYOcNFLFHWVmoxIaiIlSTyhTYN = P_2
					};
				}

				[IteratorStateMachine(typeof(sVOnxiCixoXZcjvpdCLFqFtljuZv))]
				private IEnumerable<_0001> IDghaNgTkZULxEJuhXJUtiMrXuDA<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new sVOnxiCixoXZcjvpdCLFqFtljuZv<_0001>(-2)
					{
						lQuNAJOTLqcaJSKVvVdjYeyaEJVG = this,
						EfnGejLTWAZbFJeATrWHYUoRvnGb = P_0,
						JGXwDrrnWwgFFfxGqrjXLKbCfFmTA = P_1
					};
				}

				private ActionElementMap CymIKzOXORgnUktPQyoFdgQaDvrF(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
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

				private ActionElementMap vvqhLEOQZqxErjmIQBXrxlHKTiyA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return CymIKzOXORgnUktPQyoFdgQaDvrF(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(MnFfCHNHABZQRPpNQCZhBHTVVKCnA))]
				private IEnumerable<ActionElementMap> VkPBCjIXLSoMygzDqfJKsoIMckXmA(ControllerType P_0, int P_1, bool P_2)
				{
					return new MnFfCHNHABZQRPpNQCZhBHTVVKCnA(-2)
					{
						vjacusHnnuguoorGYoSjGZiYSbMZA = this,
						yyDNDhbJlyAgxurroGRoiszrbpwvA = P_0,
						ZAuWKuiOFXQGqFNzkjvrLneXcyBr = P_1,
						ntLCuYSfCWEGAKmeCzxkwiywngIf = P_2
					};
				}

				private IEnumerable<ActionElementMap> HweavYWfjlprgvXODjahvJYGcgAB(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return VkPBCjIXLSoMygzDqfJKsoIMckXmA(P_0, num, P_2);
				}

				private ActionElementMap obAihIAdtMBLqPhBveRADrMkZnKIb(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
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

				private ActionElementMap FxSdFtltnZbRZDVoFavXdrbJKnVqB(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return obAihIAdtMBLqPhBveRADrMkZnKIb(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(ZBbFgeryzdjfxEcAaqOWcVLMAuBr))]
				private IEnumerable<ActionElementMap> RdyLcMqZriPEDCFWdfBbEaTyeHpaA(ControllerType P_0, int P_1, bool P_2)
				{
					return new ZBbFgeryzdjfxEcAaqOWcVLMAuBr(-2)
					{
						SojcoIDyVpwZpkHXRtlyePrzJMGY = this,
						qsENTbkjyRUSaBNDXQadjIwczgtf = P_0,
						rVJWxliBREGzkFuBbAkiaqzhWzik = P_1,
						JazNDdYSWeVnInaBsvaBjGHkwuuk = P_2
					};
				}

				private IEnumerable<ActionElementMap> DaAcKyGkiLyBPouoyJTJdvmAhlfIB(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return RdyLcMqZriPEDCFWdfBbEaTyeHpaA(P_0, num, P_2);
				}

				private ActionElementMap KnaFFAHkDsKPlZfbknPmErTQtCbrA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
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

				private ActionElementMap ExCSQZXbWYdkeHvAfMyfoOUhkfQC(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return KnaFFAHkDsKPlZfbknPmErTQtCbrA(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(vbHLyUdjjGlcwWbEPgTivriHfXfbA))]
				private IEnumerable<ActionElementMap> dGwEUHhLYIQvtuKrxxVnTuDQibAFb(ControllerType P_0, int P_1, bool P_2)
				{
					return new vbHLyUdjjGlcwWbEPgTivriHfXfbA(-2)
					{
						tPsWDEFSvRBVGeYXNbARFXuGrzBIb = this,
						NAJCbQwAYMarAFaiSBKKubbehtHvA = P_0,
						cjlRuUzjWOLZZOVBvWlwwUCADGAT = P_1,
						eLevniKoDDRrtsQVsTRniQuZFKOd = P_2
					};
				}

				private IEnumerable<ActionElementMap> ESbSSradMNEUSicbonSJMRODQCVX(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return dGwEUHhLYIQvtuKrxxVnTuDQibAFb(P_0, num, P_2);
				}

				private int TTTVliXmFBaSBoQAPKBGvJZXIjyS(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num2; j++)
						{
							jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							int num3 = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.evuAGWdmBtXdeDdtbgwnSOyyQUPhA(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int LdyHxjebXGnKacfNeyernNSnjxQCb(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num2; j++)
						{
							jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							int num3 = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							for (int k = 0; k < num3; k++)
							{
								if (jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.VOcVbUIzhfxsVVgzSTRZlwURMvuu(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int SkyGBHecePLThPEBLPtLAhTRPdvpA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
					for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
					{
						jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i);
						int num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
						for (int j = 0; j < num2; j++)
						{
							jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(j).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
							int num3 = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.AvmYEXAwkVTWWehMOUUIzJXxGqQr(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int ssOhQiwPnyzmHEigPxBMiqpIxlzg(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].evuAGWdmBtXdeDdtbgwnSOyyQUPhA(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int CDXqJdCIppBnrPlxBQgHISFmkNwf(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return ssOhQiwPnyzmHEigPxBMiqpIxlzg(P_0, num, P_2, P_3, P_4);
				}

				private int YdwWnmxEYlUPcrzeweUNjkphWIYw(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).VOcVbUIzhfxsVVgzSTRZlwURMvuu(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int WNIvRJphcKUyUnYLhnyJeGckAtLT(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return YdwWnmxEYlUPcrzeweUNjkphWIYw(P_0, num, P_2, P_3, P_4);
				}

				private int IaFPyJaxVqtTnprxRzCZRnSIDOhK(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					for (int i = 0; i < jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ; i++)
					{
						IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].AvmYEXAwkVTWWehMOUUIzJXxGqQr(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int AEzdSgRJZQtHoEcUwyBhYFpiaYPEA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_1);
					return IaFPyJaxVqtTnprxRzCZRnSIDOhK(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap AaHvRULeNPYaxFVnHsGSbDCtclgK(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
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

				private ActionElementMap OYHeRHkGbvqSHBvYswaWBKRWpbLL(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return AaHvRULeNPYaxFVnHsGSbDCtclgK(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(zAMqdRCweJizVPEBHgxENAWfBYudA))]
				private IEnumerable<ActionElementMap> jvzQeOcqNmTZUlgOKBZEtbXGChdw(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new zAMqdRCweJizVPEBHgxENAWfBYudA(-2)
					{
						oQfvSRYwNDulBdLkpnOXoweWhrVN = this,
						pWgfeijpjoDiuKJrByOCEtjaCLaO = P_0,
						iVaBeUrkXWONwPMXJBdTdKOSoJezA = P_1,
						ZrzDsrJdkKFmKAMeKtmijmnxbMeh = P_2,
						xVxMOWoVSJAwQmNofOGgcjcyphTJ = P_3
					};
				}

				private IEnumerable<ActionElementMap> OYjPtoaJNafjvCwZIbCtpfiSfVEbA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return jvzQeOcqNmTZUlgOKBZEtbXGChdw(P_0, P_1, num, P_3);
				}

				private ActionElementMap kONVCiBhkJZKtTFuuLoqrTJSWDEg(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
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

				private ActionElementMap ocZtJyZLfovwlztfGdOwTNlfCche(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return kONVCiBhkJZKtTFuuLoqrTJSWDEg(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(TCQksDFcyyDLSEGtpJoYVhsqCjVjA))]
				private IEnumerable<ActionElementMap> pSnFOKMbpjStVpXuEfRaKOKVPaTk(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new TCQksDFcyyDLSEGtpJoYVhsqCjVjA(-2)
					{
						wtbgGkFCmBGHtNpgAbcEMKbWXjgh = this,
						GNwNycuoaFvQQkFzZtkRtShZPPVv = P_0,
						hPZfLucMGwuablBupScAOTcgkStPA = P_1,
						XLbWKUDdgkohyOvkncKPQGfWvroO = P_2,
						EuLcGsTJPvVbIxirUXVEJtbGxUcc = P_3
					};
				}

				private IEnumerable<ActionElementMap> dFLcGuKnByhoicUbiTHxdVSBFfCO(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return pSnFOKMbpjStVpXuEfRaKOKVPaTk(P_0, P_1, num, P_3);
				}

				private ActionElementMap GnAsbRFugsejtZfVuqkjYfYYEEJm(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
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

				private ActionElementMap mcXdoCtUVNYezPdYYztQfgUrmFxE(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return GnAsbRFugsejtZfVuqkjYfYYEEJm(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(OtYQIWyEmBuWZDuGZXfESZRTKNRL))]
				private IEnumerable<ActionElementMap> tdxEKedArgZAipoHyFUNmrgYarav(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new OtYQIWyEmBuWZDuGZXfESZRTKNRL(-2)
					{
						tydgTWIiTBAeeRNEZnMsphFGpcRKA = this,
						ZroDKwcaGBtlsDrwnSbzyKvijvbB = P_0,
						awbtNhOQEjiXXPqKTMnreZqSWkOJ = P_1,
						LqXQdOthbCWYmppksGPkbLwgOsOQ = P_2,
						iDvMjxwZNCuFhIzZNpijvvzOwrH = P_3
					};
				}

				private IEnumerable<ActionElementMap> oXnKZHVouKUOXcSWjGMdPPAsInWAA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return tdxEKedArgZAipoHyFUNmrgYarav(P_0, P_1, num, P_3);
				}

				private int LhnTCVYYnbpoLDqsvfrMkYdOOCJW(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.evuAGWdmBtXdeDdtbgwnSOyyQUPhA(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int IERtfcapJYxFbeIWvcmuCzuhdExGA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return LhnTCVYYnbpoLDqsvfrMkYdOOCJW(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int jmJhepqQBMKInOOOAmKOLBdTMDqV(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.VOcVbUIzhfxsVVgzSTRZlwURMvuu(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int pjmqJGRJXDuDvXwSbmaynyHVoMhG(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return jmJhepqQBMKInOOOAmKOLBdTMDqV(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int pGPWcRpUEIboVvVpoMcTXshfdZsG(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.pkBnWPGhiVStKNCTHndxrrusHaYt(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).YjPKnaUBIafYYbhEPJJXDUgXqwPK.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].AvmYEXAwkVTWWehMOUUIzJXxGqQr(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int nxjLbsXYJrsJtxfYMjNVRJrnbXFEA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
					return pGPWcRpUEIboVvVpoMcTXshfdZsG(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap CMhCRRgoquVyXwiVYhxyoexyJqhG(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controller.type);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					for (int i = 0; i < num; i++)
					{
						jeabHUrstoKHDRpNBCZSFbPvOBSHb obj = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
						_ = obj.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
						IList<ControllerMap> list = obj.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.DjWWuZsxtpUwnYvonxAcnwebFqAJ(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				[IteratorStateMachine(typeof(VXbleZgRxUDrPsontxXpDzmBYWTf))]
				private IEnumerable<ActionElementMap> lwGEreKvNOIDEcHGfNASkilGhvTkc(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new VXbleZgRxUDrPsontxXpDzmBYWTf(-2)
					{
						WsftHbUHQILzxCHLJqDampREdVqd = this,
						XgsLpBceesEXTdbBYOFbuSrOOAMLA = P_0,
						NZaCoKhOirjpRmDFVBvDgMiaqSDI = P_1,
						lhnAZihTauFmSUsnXyiXnsCUDobJb = P_2,
						tMvZOFpETEOKNXuFSoyFdzcuDDKH = P_3
					};
				}

				private int uVVQRPqMhfRhaHJKQOUsJPXBldpD(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = UpHoGoqMGXnLIaICOqgMBZfNytOj.uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controller.type);
					int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						jeabHUrstoKHDRpNBCZSFbPvOBSHb obj = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
						_ = obj.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
						IList<ControllerMap> list = obj.OoSEBuCJhUdxVYPGdCOHitpseeqxA;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.ggkUfUXAPQaWoiBsYcQlTMWUVBprA(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
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
				private sealed class KzYWgNSoqBlkxIVIEvtpwkKgcAqT : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int DwExuOZfFMeCCHbWOBhuuSSaLxrO;

					private ControllerPollingInfo zZfdUNoToWSIdrmTPcCzQJJhJEdE;

					private int dDJAbwDFoGMHASfiHdbDcoQljhlm;

					public PollingHelper gJjqOEOMsUSAhxSNWfoBWsQmSUhF;

					private IList<CustomController> OhxJGujJqxWTIdWdiJqSJnUnMWcM;

					private int goKvOPFZibLoOAuwalpDECHiThaK;

					private int BNeNxLAVHPvasJexMeYNBiLRaZpW;

					private IEnumerator<ControllerPollingInfo> lbpUuJZrJlmpYHqJQzUWJTqInMLm;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zZfdUNoToWSIdrmTPcCzQJJhJEdE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zZfdUNoToWSIdrmTPcCzQJJhJEdE;
						}
					}

					[DebuggerHidden]
					public KzYWgNSoqBlkxIVIEvtpwkKgcAqT(int P_0)
					{
						DwExuOZfFMeCCHbWOBhuuSSaLxrO = P_0;
						dDJAbwDFoGMHASfiHdbDcoQljhlm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dwExuOZfFMeCCHbWOBhuuSSaLxrO = DwExuOZfFMeCCHbWOBhuuSSaLxrO;
						if (dwExuOZfFMeCCHbWOBhuuSSaLxrO == -3 || dwExuOZfFMeCCHbWOBhuuSSaLxrO == 1)
						{
							try
							{
							}
							finally
							{
								CyTFZRclzhWyMHiFlOQNsPplysee();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int dwExuOZfFMeCCHbWOBhuuSSaLxrO = DwExuOZfFMeCCHbWOBhuuSSaLxrO;
							PollingHelper pollingHelper = gJjqOEOMsUSAhxSNWfoBWsQmSUhF;
							if (dwExuOZfFMeCCHbWOBhuuSSaLxrO != 0)
							{
								if (dwExuOZfFMeCCHbWOBhuuSSaLxrO != 1)
								{
									return false;
								}
								DwExuOZfFMeCCHbWOBhuuSSaLxrO = -3;
								goto IL_00c5;
							}
							DwExuOZfFMeCCHbWOBhuuSSaLxrO = -1;
							OhxJGujJqxWTIdWdiJqSJnUnMWcM = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							goKvOPFZibLoOAuwalpDECHiThaK = OhxJGujJqxWTIdWdiJqSJnUnMWcM.Count;
							BNeNxLAVHPvasJexMeYNBiLRaZpW = 0;
							goto IL_00f1;
							IL_00c5:
							if (lbpUuJZrJlmpYHqJQzUWJTqInMLm.MoveNext())
							{
								ControllerPollingInfo current = lbpUuJZrJlmpYHqJQzUWJTqInMLm.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								zZfdUNoToWSIdrmTPcCzQJJhJEdE = controllerPollingInfo;
								DwExuOZfFMeCCHbWOBhuuSSaLxrO = 1;
								return true;
							}
							CyTFZRclzhWyMHiFlOQNsPplysee();
							lbpUuJZrJlmpYHqJQzUWJTqInMLm = null;
							BNeNxLAVHPvasJexMeYNBiLRaZpW++;
							goto IL_00f1;
							IL_00f1:
							if (BNeNxLAVHPvasJexMeYNBiLRaZpW < goKvOPFZibLoOAuwalpDECHiThaK)
							{
								lbpUuJZrJlmpYHqJQzUWJTqInMLm = OhxJGujJqxWTIdWdiJqSJnUnMWcM[BNeNxLAVHPvasJexMeYNBiLRaZpW].PollForAllAxes().GetEnumerator();
								DwExuOZfFMeCCHbWOBhuuSSaLxrO = -3;
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

					private void CyTFZRclzhWyMHiFlOQNsPplysee()
					{
						DwExuOZfFMeCCHbWOBhuuSSaLxrO = -1;
						if (lbpUuJZrJlmpYHqJQzUWJTqInMLm != null)
						{
							lbpUuJZrJlmpYHqJQzUWJTqInMLm.Dispose();
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
						KzYWgNSoqBlkxIVIEvtpwkKgcAqT kzYWgNSoqBlkxIVIEvtpwkKgcAqT;
						if (DwExuOZfFMeCCHbWOBhuuSSaLxrO == -2 && dDJAbwDFoGMHASfiHdbDcoQljhlm == Environment.CurrentManagedThreadId)
						{
							DwExuOZfFMeCCHbWOBhuuSSaLxrO = 0;
							kzYWgNSoqBlkxIVIEvtpwkKgcAqT = this;
						}
						else
						{
							kzYWgNSoqBlkxIVIEvtpwkKgcAqT = new KzYWgNSoqBlkxIVIEvtpwkKgcAqT(0);
							kzYWgNSoqBlkxIVIEvtpwkKgcAqT.gJjqOEOMsUSAhxSNWfoBWsQmSUhF = gJjqOEOMsUSAhxSNWfoBWsQmSUhF;
						}
						return kzYWgNSoqBlkxIVIEvtpwkKgcAqT;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wpxadSkFopCfHiqvGRdjzpflvzcPb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int WhJcnrpQPHEbsXhvenmtAOnRZCjO;

					private ControllerPollingInfo BSmYghnVTJOZFmDtUqpoyfvTUQVF;

					private int DiwYMyFklhTPfcmuqhqHFVnmeRej;

					public PollingHelper qKYmyizgWbhqoqkmRvniiOjKofAr;

					private IList<CustomController> WjJbjoacTehhzSpUqUZnBVhRICaQ;

					private int yBocSbMYIfhFdFuhrDpSNZImETfP;

					private int MltzgXrBcLCLfIUNsqzKMutLpofE;

					private IEnumerator<ControllerPollingInfo> voLLoPbQROoSvFTobIqTTHYieuhF;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BSmYghnVTJOZFmDtUqpoyfvTUQVF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BSmYghnVTJOZFmDtUqpoyfvTUQVF;
						}
					}

					[DebuggerHidden]
					public wpxadSkFopCfHiqvGRdjzpflvzcPb(int P_0)
					{
						WhJcnrpQPHEbsXhvenmtAOnRZCjO = P_0;
						DiwYMyFklhTPfcmuqhqHFVnmeRej = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int whJcnrpQPHEbsXhvenmtAOnRZCjO = WhJcnrpQPHEbsXhvenmtAOnRZCjO;
						if (whJcnrpQPHEbsXhvenmtAOnRZCjO == -3 || whJcnrpQPHEbsXhvenmtAOnRZCjO == 1)
						{
							try
							{
							}
							finally
							{
								ClcenfKKIcMoLzzCEFrpimJurJbAA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int whJcnrpQPHEbsXhvenmtAOnRZCjO = WhJcnrpQPHEbsXhvenmtAOnRZCjO;
							PollingHelper pollingHelper = qKYmyizgWbhqoqkmRvniiOjKofAr;
							if (whJcnrpQPHEbsXhvenmtAOnRZCjO != 0)
							{
								if (whJcnrpQPHEbsXhvenmtAOnRZCjO != 1)
								{
									return false;
								}
								WhJcnrpQPHEbsXhvenmtAOnRZCjO = -3;
								goto IL_00c5;
							}
							WhJcnrpQPHEbsXhvenmtAOnRZCjO = -1;
							WjJbjoacTehhzSpUqUZnBVhRICaQ = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							yBocSbMYIfhFdFuhrDpSNZImETfP = WjJbjoacTehhzSpUqUZnBVhRICaQ.Count;
							MltzgXrBcLCLfIUNsqzKMutLpofE = 0;
							goto IL_00f1;
							IL_00c5:
							if (voLLoPbQROoSvFTobIqTTHYieuhF.MoveNext())
							{
								ControllerPollingInfo current = voLLoPbQROoSvFTobIqTTHYieuhF.Current;
								ControllerPollingInfo bSmYghnVTJOZFmDtUqpoyfvTUQVF = new ControllerPollingInfo(current);
								bSmYghnVTJOZFmDtUqpoyfvTUQVF.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								BSmYghnVTJOZFmDtUqpoyfvTUQVF = bSmYghnVTJOZFmDtUqpoyfvTUQVF;
								WhJcnrpQPHEbsXhvenmtAOnRZCjO = 1;
								return true;
							}
							ClcenfKKIcMoLzzCEFrpimJurJbAA();
							voLLoPbQROoSvFTobIqTTHYieuhF = null;
							MltzgXrBcLCLfIUNsqzKMutLpofE++;
							goto IL_00f1;
							IL_00f1:
							if (MltzgXrBcLCLfIUNsqzKMutLpofE < yBocSbMYIfhFdFuhrDpSNZImETfP)
							{
								voLLoPbQROoSvFTobIqTTHYieuhF = WjJbjoacTehhzSpUqUZnBVhRICaQ[MltzgXrBcLCLfIUNsqzKMutLpofE].PollForAllButtons().GetEnumerator();
								WhJcnrpQPHEbsXhvenmtAOnRZCjO = -3;
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

					private void ClcenfKKIcMoLzzCEFrpimJurJbAA()
					{
						WhJcnrpQPHEbsXhvenmtAOnRZCjO = -1;
						if (voLLoPbQROoSvFTobIqTTHYieuhF != null)
						{
							voLLoPbQROoSvFTobIqTTHYieuhF.Dispose();
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
						wpxadSkFopCfHiqvGRdjzpflvzcPb wpxadSkFopCfHiqvGRdjzpflvzcPb2;
						if (WhJcnrpQPHEbsXhvenmtAOnRZCjO == -2 && DiwYMyFklhTPfcmuqhqHFVnmeRej == Environment.CurrentManagedThreadId)
						{
							WhJcnrpQPHEbsXhvenmtAOnRZCjO = 0;
							wpxadSkFopCfHiqvGRdjzpflvzcPb2 = this;
						}
						else
						{
							wpxadSkFopCfHiqvGRdjzpflvzcPb2 = new wpxadSkFopCfHiqvGRdjzpflvzcPb(0);
							wpxadSkFopCfHiqvGRdjzpflvzcPb2.qKYmyizgWbhqoqkmRvniiOjKofAr = qKYmyizgWbhqoqkmRvniiOjKofAr;
						}
						return wpxadSkFopCfHiqvGRdjzpflvzcPb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lIDfkQuQogleJMCdSUPpwPiIXrBb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int uwMHQWPhdsltdsDmCGyjSptPeTOZ;

					private ControllerPollingInfo fKAZwjVUeNREVhtcMoJBaFEMAStW;

					private int dLgubMIpeRUKodeekpzwaTniqnhB;

					public PollingHelper dpVmIVcgouxAbTxcyMHiwdLXUeQt;

					private IList<CustomController> EXafjIUeeBLoGdMkstbnexeZOywg;

					private int iXfUeoKxHmOwMmaNPDZjdEVzFdWOA;

					private int GeDplnptAWBJDiFlqRzapRUYHtGb;

					private IEnumerator<ControllerPollingInfo> pkjREcarsDggMylOsTegjFuSujZG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return fKAZwjVUeNREVhtcMoJBaFEMAStW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return fKAZwjVUeNREVhtcMoJBaFEMAStW;
						}
					}

					[DebuggerHidden]
					public lIDfkQuQogleJMCdSUPpwPiIXrBb(int P_0)
					{
						uwMHQWPhdsltdsDmCGyjSptPeTOZ = P_0;
						dLgubMIpeRUKodeekpzwaTniqnhB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = uwMHQWPhdsltdsDmCGyjSptPeTOZ;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								sqoazfthodySiicccnpJALBQOWPS();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = uwMHQWPhdsltdsDmCGyjSptPeTOZ;
							PollingHelper pollingHelper = dpVmIVcgouxAbTxcyMHiwdLXUeQt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								uwMHQWPhdsltdsDmCGyjSptPeTOZ = -3;
								goto IL_00c5;
							}
							uwMHQWPhdsltdsDmCGyjSptPeTOZ = -1;
							EXafjIUeeBLoGdMkstbnexeZOywg = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							iXfUeoKxHmOwMmaNPDZjdEVzFdWOA = EXafjIUeeBLoGdMkstbnexeZOywg.Count;
							GeDplnptAWBJDiFlqRzapRUYHtGb = 0;
							goto IL_00f1;
							IL_00c5:
							if (pkjREcarsDggMylOsTegjFuSujZG.MoveNext())
							{
								ControllerPollingInfo current = pkjREcarsDggMylOsTegjFuSujZG.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								fKAZwjVUeNREVhtcMoJBaFEMAStW = controllerPollingInfo;
								uwMHQWPhdsltdsDmCGyjSptPeTOZ = 1;
								return true;
							}
							sqoazfthodySiicccnpJALBQOWPS();
							pkjREcarsDggMylOsTegjFuSujZG = null;
							GeDplnptAWBJDiFlqRzapRUYHtGb++;
							goto IL_00f1;
							IL_00f1:
							if (GeDplnptAWBJDiFlqRzapRUYHtGb < iXfUeoKxHmOwMmaNPDZjdEVzFdWOA)
							{
								pkjREcarsDggMylOsTegjFuSujZG = EXafjIUeeBLoGdMkstbnexeZOywg[GeDplnptAWBJDiFlqRzapRUYHtGb].PollForAllButtonsDown().GetEnumerator();
								uwMHQWPhdsltdsDmCGyjSptPeTOZ = -3;
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

					private void sqoazfthodySiicccnpJALBQOWPS()
					{
						uwMHQWPhdsltdsDmCGyjSptPeTOZ = -1;
						if (pkjREcarsDggMylOsTegjFuSujZG != null)
						{
							pkjREcarsDggMylOsTegjFuSujZG.Dispose();
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
						lIDfkQuQogleJMCdSUPpwPiIXrBb lIDfkQuQogleJMCdSUPpwPiIXrBb2;
						if (uwMHQWPhdsltdsDmCGyjSptPeTOZ == -2 && dLgubMIpeRUKodeekpzwaTniqnhB == Environment.CurrentManagedThreadId)
						{
							uwMHQWPhdsltdsDmCGyjSptPeTOZ = 0;
							lIDfkQuQogleJMCdSUPpwPiIXrBb2 = this;
						}
						else
						{
							lIDfkQuQogleJMCdSUPpwPiIXrBb2 = new lIDfkQuQogleJMCdSUPpwPiIXrBb(0);
							lIDfkQuQogleJMCdSUPpwPiIXrBb2.dpVmIVcgouxAbTxcyMHiwdLXUeQt = dpVmIVcgouxAbTxcyMHiwdLXUeQt;
						}
						return lIDfkQuQogleJMCdSUPpwPiIXrBb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class YwpGGMuJhdZWfNedrCDYTayMrTYN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int JSIxRFOYggfncXMWufAleyhwzJmP;

					private ControllerPollingInfo oRXWZkOnNPMvHnCmGgtngDSVpeQSA;

					private int WIdDprJHiJorKgbgIRCqqREmfCDOA;

					public PollingHelper uOxTLXlKXsfPMgyQSYJYeYkSibPF;

					private IList<CustomController> xunQXJPgMUGdBjYcAWCcOGwLadMC;

					private int NnENLXJyZizrmyLoqvSxVxqZqYsc;

					private int WOUyjUAeZFkaYeqZKdlfBDZrlLvD;

					private IEnumerator<ControllerPollingInfo> HOkfPBDuQEjQPJMwMGUYxTPNNyEVA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oRXWZkOnNPMvHnCmGgtngDSVpeQSA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oRXWZkOnNPMvHnCmGgtngDSVpeQSA;
						}
					}

					[DebuggerHidden]
					public YwpGGMuJhdZWfNedrCDYTayMrTYN(int P_0)
					{
						JSIxRFOYggfncXMWufAleyhwzJmP = P_0;
						WIdDprJHiJorKgbgIRCqqREmfCDOA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int jSIxRFOYggfncXMWufAleyhwzJmP = JSIxRFOYggfncXMWufAleyhwzJmP;
						if (jSIxRFOYggfncXMWufAleyhwzJmP == -3 || jSIxRFOYggfncXMWufAleyhwzJmP == 1)
						{
							try
							{
							}
							finally
							{
								ApTPSZZeXDeXzoOzMCgzOUDTVPqd();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int jSIxRFOYggfncXMWufAleyhwzJmP = JSIxRFOYggfncXMWufAleyhwzJmP;
							PollingHelper pollingHelper = uOxTLXlKXsfPMgyQSYJYeYkSibPF;
							if (jSIxRFOYggfncXMWufAleyhwzJmP != 0)
							{
								if (jSIxRFOYggfncXMWufAleyhwzJmP != 1)
								{
									return false;
								}
								JSIxRFOYggfncXMWufAleyhwzJmP = -3;
								goto IL_00c5;
							}
							JSIxRFOYggfncXMWufAleyhwzJmP = -1;
							xunQXJPgMUGdBjYcAWCcOGwLadMC = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							NnENLXJyZizrmyLoqvSxVxqZqYsc = xunQXJPgMUGdBjYcAWCcOGwLadMC.Count;
							WOUyjUAeZFkaYeqZKdlfBDZrlLvD = 0;
							goto IL_00f1;
							IL_00c5:
							if (HOkfPBDuQEjQPJMwMGUYxTPNNyEVA.MoveNext())
							{
								ControllerPollingInfo current = HOkfPBDuQEjQPJMwMGUYxTPNNyEVA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								oRXWZkOnNPMvHnCmGgtngDSVpeQSA = controllerPollingInfo;
								JSIxRFOYggfncXMWufAleyhwzJmP = 1;
								return true;
							}
							ApTPSZZeXDeXzoOzMCgzOUDTVPqd();
							HOkfPBDuQEjQPJMwMGUYxTPNNyEVA = null;
							WOUyjUAeZFkaYeqZKdlfBDZrlLvD++;
							goto IL_00f1;
							IL_00f1:
							if (WOUyjUAeZFkaYeqZKdlfBDZrlLvD < NnENLXJyZizrmyLoqvSxVxqZqYsc)
							{
								HOkfPBDuQEjQPJMwMGUYxTPNNyEVA = xunQXJPgMUGdBjYcAWCcOGwLadMC[WOUyjUAeZFkaYeqZKdlfBDZrlLvD].PollForAllElements().GetEnumerator();
								JSIxRFOYggfncXMWufAleyhwzJmP = -3;
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

					private void ApTPSZZeXDeXzoOzMCgzOUDTVPqd()
					{
						JSIxRFOYggfncXMWufAleyhwzJmP = -1;
						if (HOkfPBDuQEjQPJMwMGUYxTPNNyEVA != null)
						{
							HOkfPBDuQEjQPJMwMGUYxTPNNyEVA.Dispose();
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
						YwpGGMuJhdZWfNedrCDYTayMrTYN ywpGGMuJhdZWfNedrCDYTayMrTYN;
						if (JSIxRFOYggfncXMWufAleyhwzJmP == -2 && WIdDprJHiJorKgbgIRCqqREmfCDOA == Environment.CurrentManagedThreadId)
						{
							JSIxRFOYggfncXMWufAleyhwzJmP = 0;
							ywpGGMuJhdZWfNedrCDYTayMrTYN = this;
						}
						else
						{
							ywpGGMuJhdZWfNedrCDYTayMrTYN = new YwpGGMuJhdZWfNedrCDYTayMrTYN(0);
							ywpGGMuJhdZWfNedrCDYTayMrTYN.uOxTLXlKXsfPMgyQSYJYeYkSibPF = uOxTLXlKXsfPMgyQSYJYeYkSibPF;
						}
						return ywpGGMuJhdZWfNedrCDYTayMrTYN;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RXFEjYBNWdbgUzOgxBpqKmPAgOxab : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int RGGXJsFphikgtRmTGdwXHHzyXzCY;

					private ControllerPollingInfo nxMOwcaPPKtsiSfsESzmYYMlqEyO;

					private int AEQxFTdjAFLAmNHfbnrxalspjXjP;

					public PollingHelper mbKGipiuzcxKQqSFHOhSOmBgkzFO;

					private IList<CustomController> aEvwVGcFtHMhGpEsuDccmBLKHiLy;

					private int WQcGqqtdltBLZDzJqVBAKUyemaHO;

					private int pWrpBVGNnhlDMwdLjWNajWYXSnXR;

					private IEnumerator<ControllerPollingInfo> MhMPTqFrnOqbTTPidAweIFyQbBAs;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return nxMOwcaPPKtsiSfsESzmYYMlqEyO;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nxMOwcaPPKtsiSfsESzmYYMlqEyO;
						}
					}

					[DebuggerHidden]
					public RXFEjYBNWdbgUzOgxBpqKmPAgOxab(int P_0)
					{
						RGGXJsFphikgtRmTGdwXHHzyXzCY = P_0;
						AEQxFTdjAFLAmNHfbnrxalspjXjP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rGGXJsFphikgtRmTGdwXHHzyXzCY = RGGXJsFphikgtRmTGdwXHHzyXzCY;
						if (rGGXJsFphikgtRmTGdwXHHzyXzCY == -3 || rGGXJsFphikgtRmTGdwXHHzyXzCY == 1)
						{
							try
							{
							}
							finally
							{
								ANKAYrvxZXejOmBtFwAHkjsIlMib();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int rGGXJsFphikgtRmTGdwXHHzyXzCY = RGGXJsFphikgtRmTGdwXHHzyXzCY;
							PollingHelper pollingHelper = mbKGipiuzcxKQqSFHOhSOmBgkzFO;
							if (rGGXJsFphikgtRmTGdwXHHzyXzCY != 0)
							{
								if (rGGXJsFphikgtRmTGdwXHHzyXzCY != 1)
								{
									return false;
								}
								RGGXJsFphikgtRmTGdwXHHzyXzCY = -3;
								goto IL_00c5;
							}
							RGGXJsFphikgtRmTGdwXHHzyXzCY = -1;
							aEvwVGcFtHMhGpEsuDccmBLKHiLy = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							WQcGqqtdltBLZDzJqVBAKUyemaHO = aEvwVGcFtHMhGpEsuDccmBLKHiLy.Count;
							pWrpBVGNnhlDMwdLjWNajWYXSnXR = 0;
							goto IL_00f1;
							IL_00c5:
							if (MhMPTqFrnOqbTTPidAweIFyQbBAs.MoveNext())
							{
								ControllerPollingInfo current = MhMPTqFrnOqbTTPidAweIFyQbBAs.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								nxMOwcaPPKtsiSfsESzmYYMlqEyO = controllerPollingInfo;
								RGGXJsFphikgtRmTGdwXHHzyXzCY = 1;
								return true;
							}
							ANKAYrvxZXejOmBtFwAHkjsIlMib();
							MhMPTqFrnOqbTTPidAweIFyQbBAs = null;
							pWrpBVGNnhlDMwdLjWNajWYXSnXR++;
							goto IL_00f1;
							IL_00f1:
							if (pWrpBVGNnhlDMwdLjWNajWYXSnXR < WQcGqqtdltBLZDzJqVBAKUyemaHO)
							{
								MhMPTqFrnOqbTTPidAweIFyQbBAs = aEvwVGcFtHMhGpEsuDccmBLKHiLy[pWrpBVGNnhlDMwdLjWNajWYXSnXR].PollForAllElementsDown().GetEnumerator();
								RGGXJsFphikgtRmTGdwXHHzyXzCY = -3;
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

					private void ANKAYrvxZXejOmBtFwAHkjsIlMib()
					{
						RGGXJsFphikgtRmTGdwXHHzyXzCY = -1;
						if (MhMPTqFrnOqbTTPidAweIFyQbBAs != null)
						{
							MhMPTqFrnOqbTTPidAweIFyQbBAs.Dispose();
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
						RXFEjYBNWdbgUzOgxBpqKmPAgOxab rXFEjYBNWdbgUzOgxBpqKmPAgOxab;
						if (RGGXJsFphikgtRmTGdwXHHzyXzCY == -2 && AEQxFTdjAFLAmNHfbnrxalspjXjP == Environment.CurrentManagedThreadId)
						{
							RGGXJsFphikgtRmTGdwXHHzyXzCY = 0;
							rXFEjYBNWdbgUzOgxBpqKmPAgOxab = this;
						}
						else
						{
							rXFEjYBNWdbgUzOgxBpqKmPAgOxab = new RXFEjYBNWdbgUzOgxBpqKmPAgOxab(0);
							rXFEjYBNWdbgUzOgxBpqKmPAgOxab.mbKGipiuzcxKQqSFHOhSOmBgkzFO = mbKGipiuzcxKQqSFHOhSOmBgkzFO;
						}
						return rXFEjYBNWdbgUzOgxBpqKmPAgOxab;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class PDdYHJlNacCnCdnuJaRqgTABvUOtB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int PggPqlOTEviLoNffgkRWfhfssSgg;

					private ControllerPollingInfo ymqzwZSLxCxwKNCcWeJvWCQxphnh;

					private int oPTeLKeRofPamkKQCmbZRLzlhetg;

					public PollingHelper cPedKZHoGxTvjAAhRJQEjZZEzozOA;

					private IList<Joystick> DjKKjrmgkbIyFUTaoGxvsKjYpvFe;

					private int ZndHkUVgCvYFVFlpYIQXdAlFSKLIA;

					private int qaXCXoZeXwAJeFrunbEbKQANeOzjA;

					private IEnumerator<ControllerPollingInfo> XbnYSnbqRXPowdBZWRHGUHiYGwKR;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ymqzwZSLxCxwKNCcWeJvWCQxphnh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ymqzwZSLxCxwKNCcWeJvWCQxphnh;
						}
					}

					[DebuggerHidden]
					public PDdYHJlNacCnCdnuJaRqgTABvUOtB(int P_0)
					{
						PggPqlOTEviLoNffgkRWfhfssSgg = P_0;
						oPTeLKeRofPamkKQCmbZRLzlhetg = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pggPqlOTEviLoNffgkRWfhfssSgg = PggPqlOTEviLoNffgkRWfhfssSgg;
						if (pggPqlOTEviLoNffgkRWfhfssSgg == -3 || pggPqlOTEviLoNffgkRWfhfssSgg == 1)
						{
							try
							{
							}
							finally
							{
								MIBhhypsMvxsFbaQgeMyrQWXxgKF();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int pggPqlOTEviLoNffgkRWfhfssSgg = PggPqlOTEviLoNffgkRWfhfssSgg;
							PollingHelper pollingHelper = cPedKZHoGxTvjAAhRJQEjZZEzozOA;
							if (pggPqlOTEviLoNffgkRWfhfssSgg != 0)
							{
								if (pggPqlOTEviLoNffgkRWfhfssSgg != 1)
								{
									return false;
								}
								PggPqlOTEviLoNffgkRWfhfssSgg = -3;
								goto IL_00c5;
							}
							PggPqlOTEviLoNffgkRWfhfssSgg = -1;
							DjKKjrmgkbIyFUTaoGxvsKjYpvFe = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							ZndHkUVgCvYFVFlpYIQXdAlFSKLIA = DjKKjrmgkbIyFUTaoGxvsKjYpvFe.Count;
							qaXCXoZeXwAJeFrunbEbKQANeOzjA = 0;
							goto IL_00f1;
							IL_00c5:
							if (XbnYSnbqRXPowdBZWRHGUHiYGwKR.MoveNext())
							{
								ControllerPollingInfo current = XbnYSnbqRXPowdBZWRHGUHiYGwKR.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								ymqzwZSLxCxwKNCcWeJvWCQxphnh = controllerPollingInfo;
								PggPqlOTEviLoNffgkRWfhfssSgg = 1;
								return true;
							}
							MIBhhypsMvxsFbaQgeMyrQWXxgKF();
							XbnYSnbqRXPowdBZWRHGUHiYGwKR = null;
							qaXCXoZeXwAJeFrunbEbKQANeOzjA++;
							goto IL_00f1;
							IL_00f1:
							if (qaXCXoZeXwAJeFrunbEbKQANeOzjA < ZndHkUVgCvYFVFlpYIQXdAlFSKLIA)
							{
								XbnYSnbqRXPowdBZWRHGUHiYGwKR = DjKKjrmgkbIyFUTaoGxvsKjYpvFe[qaXCXoZeXwAJeFrunbEbKQANeOzjA].PollForAllAxes().GetEnumerator();
								PggPqlOTEviLoNffgkRWfhfssSgg = -3;
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

					private void MIBhhypsMvxsFbaQgeMyrQWXxgKF()
					{
						PggPqlOTEviLoNffgkRWfhfssSgg = -1;
						if (XbnYSnbqRXPowdBZWRHGUHiYGwKR != null)
						{
							XbnYSnbqRXPowdBZWRHGUHiYGwKR.Dispose();
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
						PDdYHJlNacCnCdnuJaRqgTABvUOtB pDdYHJlNacCnCdnuJaRqgTABvUOtB;
						if (PggPqlOTEviLoNffgkRWfhfssSgg == -2 && oPTeLKeRofPamkKQCmbZRLzlhetg == Environment.CurrentManagedThreadId)
						{
							PggPqlOTEviLoNffgkRWfhfssSgg = 0;
							pDdYHJlNacCnCdnuJaRqgTABvUOtB = this;
						}
						else
						{
							pDdYHJlNacCnCdnuJaRqgTABvUOtB = new PDdYHJlNacCnCdnuJaRqgTABvUOtB(0);
							pDdYHJlNacCnCdnuJaRqgTABvUOtB.cPedKZHoGxTvjAAhRJQEjZZEzozOA = cPedKZHoGxTvjAAhRJQEjZZEzozOA;
						}
						return pDdYHJlNacCnCdnuJaRqgTABvUOtB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xCHTAtDmmHKXyjuKTLbGZyhkFThw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int dtFfxrwUpLHCdNhaTKfjNJUwhCbH;

					private ControllerPollingInfo sIWwTeuLDbseEBTIoUDjEbvvYlQW;

					private int jhnADIAhZSHGJRIpYJGNnhUfOQiw;

					public PollingHelper KuGoPBEiHqgxXEMlMClFHtRIiAIl;

					private IList<Joystick> GoDhlzPAFIcihcgMybJtanSsVHqaA;

					private int rLDEGoPEDIcuMEsMlMAljMUhUdatc;

					private int lZOwFVMWmehuzXlzJRgtjvHmMaBj;

					private IEnumerator<ControllerPollingInfo> bBIPtgiTMLwBbPuEaoNCnXGcbrOw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return sIWwTeuLDbseEBTIoUDjEbvvYlQW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sIWwTeuLDbseEBTIoUDjEbvvYlQW;
						}
					}

					[DebuggerHidden]
					public xCHTAtDmmHKXyjuKTLbGZyhkFThw(int P_0)
					{
						dtFfxrwUpLHCdNhaTKfjNJUwhCbH = P_0;
						jhnADIAhZSHGJRIpYJGNnhUfOQiw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dtFfxrwUpLHCdNhaTKfjNJUwhCbH;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								GOjZiWTKFjHtKAKAEvaCLMQiGYlZA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = dtFfxrwUpLHCdNhaTKfjNJUwhCbH;
							PollingHelper kuGoPBEiHqgxXEMlMClFHtRIiAIl = KuGoPBEiHqgxXEMlMClFHtRIiAIl;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dtFfxrwUpLHCdNhaTKfjNJUwhCbH = -3;
								goto IL_00c5;
							}
							dtFfxrwUpLHCdNhaTKfjNJUwhCbH = -1;
							GoDhlzPAFIcihcgMybJtanSsVHqaA = kuGoPBEiHqgxXEMlMClFHtRIiAIl.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							rLDEGoPEDIcuMEsMlMAljMUhUdatc = GoDhlzPAFIcihcgMybJtanSsVHqaA.Count;
							lZOwFVMWmehuzXlzJRgtjvHmMaBj = 0;
							goto IL_00f1;
							IL_00c5:
							if (bBIPtgiTMLwBbPuEaoNCnXGcbrOw.MoveNext())
							{
								ControllerPollingInfo current = bBIPtgiTMLwBbPuEaoNCnXGcbrOw.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = kuGoPBEiHqgxXEMlMClFHtRIiAIl.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								sIWwTeuLDbseEBTIoUDjEbvvYlQW = controllerPollingInfo;
								dtFfxrwUpLHCdNhaTKfjNJUwhCbH = 1;
								return true;
							}
							GOjZiWTKFjHtKAKAEvaCLMQiGYlZA();
							bBIPtgiTMLwBbPuEaoNCnXGcbrOw = null;
							lZOwFVMWmehuzXlzJRgtjvHmMaBj++;
							goto IL_00f1;
							IL_00f1:
							if (lZOwFVMWmehuzXlzJRgtjvHmMaBj < rLDEGoPEDIcuMEsMlMAljMUhUdatc)
							{
								bBIPtgiTMLwBbPuEaoNCnXGcbrOw = GoDhlzPAFIcihcgMybJtanSsVHqaA[lZOwFVMWmehuzXlzJRgtjvHmMaBj].PollForAllButtons().GetEnumerator();
								dtFfxrwUpLHCdNhaTKfjNJUwhCbH = -3;
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

					private void GOjZiWTKFjHtKAKAEvaCLMQiGYlZA()
					{
						dtFfxrwUpLHCdNhaTKfjNJUwhCbH = -1;
						if (bBIPtgiTMLwBbPuEaoNCnXGcbrOw != null)
						{
							bBIPtgiTMLwBbPuEaoNCnXGcbrOw.Dispose();
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
						xCHTAtDmmHKXyjuKTLbGZyhkFThw xCHTAtDmmHKXyjuKTLbGZyhkFThw2;
						if (dtFfxrwUpLHCdNhaTKfjNJUwhCbH == -2 && jhnADIAhZSHGJRIpYJGNnhUfOQiw == Environment.CurrentManagedThreadId)
						{
							dtFfxrwUpLHCdNhaTKfjNJUwhCbH = 0;
							xCHTAtDmmHKXyjuKTLbGZyhkFThw2 = this;
						}
						else
						{
							xCHTAtDmmHKXyjuKTLbGZyhkFThw2 = new xCHTAtDmmHKXyjuKTLbGZyhkFThw(0);
							xCHTAtDmmHKXyjuKTLbGZyhkFThw2.KuGoPBEiHqgxXEMlMClFHtRIiAIl = KuGoPBEiHqgxXEMlMClFHtRIiAIl;
						}
						return xCHTAtDmmHKXyjuKTLbGZyhkFThw2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class UUTZSfGqJEqLPZkVirnxHibKcKmeA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int kOcBQJfBeCCRteuphRqOPmSRvyYSb;

					private ControllerPollingInfo ZhHfoWQGmPmmSCrOXdQILHJVeZHBA;

					private int SyiWuVBEyhfQKwPDTvnqMBEupyJK;

					public PollingHelper SzSeqaXKDBPJgQQhdBgjyuueSIBQ;

					private IList<Joystick> cTodizanysqepeteKfJWMOlrpuhQb;

					private int hkSdBVXtATDgzkLQzJiFflqSCJHI;

					private int OKycFIoKFxcgmwspgHjQTAexwfdS;

					private IEnumerator<ControllerPollingInfo> vCWCeLFmrxjMvuTXJCdvaOpBSmzNb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZhHfoWQGmPmmSCrOXdQILHJVeZHBA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZhHfoWQGmPmmSCrOXdQILHJVeZHBA;
						}
					}

					[DebuggerHidden]
					public UUTZSfGqJEqLPZkVirnxHibKcKmeA(int P_0)
					{
						kOcBQJfBeCCRteuphRqOPmSRvyYSb = P_0;
						SyiWuVBEyhfQKwPDTvnqMBEupyJK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = kOcBQJfBeCCRteuphRqOPmSRvyYSb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								iojpVVVBUfMGXNfnGUkRUmQMPvho();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = kOcBQJfBeCCRteuphRqOPmSRvyYSb;
							PollingHelper szSeqaXKDBPJgQQhdBgjyuueSIBQ = SzSeqaXKDBPJgQQhdBgjyuueSIBQ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								kOcBQJfBeCCRteuphRqOPmSRvyYSb = -3;
								goto IL_00c5;
							}
							kOcBQJfBeCCRteuphRqOPmSRvyYSb = -1;
							cTodizanysqepeteKfJWMOlrpuhQb = szSeqaXKDBPJgQQhdBgjyuueSIBQ.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							hkSdBVXtATDgzkLQzJiFflqSCJHI = cTodizanysqepeteKfJWMOlrpuhQb.Count;
							OKycFIoKFxcgmwspgHjQTAexwfdS = 0;
							goto IL_00f1;
							IL_00c5:
							if (vCWCeLFmrxjMvuTXJCdvaOpBSmzNb.MoveNext())
							{
								ControllerPollingInfo current = vCWCeLFmrxjMvuTXJCdvaOpBSmzNb.Current;
								ControllerPollingInfo zhHfoWQGmPmmSCrOXdQILHJVeZHBA = new ControllerPollingInfo(current);
								zhHfoWQGmPmmSCrOXdQILHJVeZHBA.playerId = szSeqaXKDBPJgQQhdBgjyuueSIBQ.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								ZhHfoWQGmPmmSCrOXdQILHJVeZHBA = zhHfoWQGmPmmSCrOXdQILHJVeZHBA;
								kOcBQJfBeCCRteuphRqOPmSRvyYSb = 1;
								return true;
							}
							iojpVVVBUfMGXNfnGUkRUmQMPvho();
							vCWCeLFmrxjMvuTXJCdvaOpBSmzNb = null;
							OKycFIoKFxcgmwspgHjQTAexwfdS++;
							goto IL_00f1;
							IL_00f1:
							if (OKycFIoKFxcgmwspgHjQTAexwfdS < hkSdBVXtATDgzkLQzJiFflqSCJHI)
							{
								vCWCeLFmrxjMvuTXJCdvaOpBSmzNb = cTodizanysqepeteKfJWMOlrpuhQb[OKycFIoKFxcgmwspgHjQTAexwfdS].PollForAllButtonsDown().GetEnumerator();
								kOcBQJfBeCCRteuphRqOPmSRvyYSb = -3;
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

					private void iojpVVVBUfMGXNfnGUkRUmQMPvho()
					{
						kOcBQJfBeCCRteuphRqOPmSRvyYSb = -1;
						if (vCWCeLFmrxjMvuTXJCdvaOpBSmzNb != null)
						{
							vCWCeLFmrxjMvuTXJCdvaOpBSmzNb.Dispose();
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
						UUTZSfGqJEqLPZkVirnxHibKcKmeA uUTZSfGqJEqLPZkVirnxHibKcKmeA;
						if (kOcBQJfBeCCRteuphRqOPmSRvyYSb == -2 && SyiWuVBEyhfQKwPDTvnqMBEupyJK == Environment.CurrentManagedThreadId)
						{
							kOcBQJfBeCCRteuphRqOPmSRvyYSb = 0;
							uUTZSfGqJEqLPZkVirnxHibKcKmeA = this;
						}
						else
						{
							uUTZSfGqJEqLPZkVirnxHibKcKmeA = new UUTZSfGqJEqLPZkVirnxHibKcKmeA(0);
							uUTZSfGqJEqLPZkVirnxHibKcKmeA.SzSeqaXKDBPJgQQhdBgjyuueSIBQ = SzSeqaXKDBPJgQQhdBgjyuueSIBQ;
						}
						return uUTZSfGqJEqLPZkVirnxHibKcKmeA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class mIWsFhkziJhVFmAMQNjlmDohLRTd : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zbwwRLrSRlGKraLHpQwuxwqqPVAc;

					private ControllerPollingInfo oXpAJHLmuPfEWDoPqWUHJOzrTzUs;

					private int zIeCZCbUgIdpaesuhhSbZCifzILfB;

					public PollingHelper mtaKrmqEOkTkxKqUuIENKDTdgzdB;

					private IList<Joystick> pRIzbkozmUNMUxBzxrAXgaYqXzJn;

					private int XKZdsHliUbLCpEHugzLYlrVlLMgk;

					private int QcoljyFcixDOApHDXemkQpFGFazR;

					private IEnumerator<ControllerPollingInfo> IdaQYFSquPFGfasnzUmxIPrzOItL;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oXpAJHLmuPfEWDoPqWUHJOzrTzUs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oXpAJHLmuPfEWDoPqWUHJOzrTzUs;
						}
					}

					[DebuggerHidden]
					public mIWsFhkziJhVFmAMQNjlmDohLRTd(int P_0)
					{
						zbwwRLrSRlGKraLHpQwuxwqqPVAc = P_0;
						zIeCZCbUgIdpaesuhhSbZCifzILfB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zbwwRLrSRlGKraLHpQwuxwqqPVAc;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								rDEKqItImiekHlNXXLPVSUUoDeAB();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = zbwwRLrSRlGKraLHpQwuxwqqPVAc;
							PollingHelper pollingHelper = mtaKrmqEOkTkxKqUuIENKDTdgzdB;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								zbwwRLrSRlGKraLHpQwuxwqqPVAc = -3;
								goto IL_00c5;
							}
							zbwwRLrSRlGKraLHpQwuxwqqPVAc = -1;
							pRIzbkozmUNMUxBzxrAXgaYqXzJn = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							XKZdsHliUbLCpEHugzLYlrVlLMgk = pRIzbkozmUNMUxBzxrAXgaYqXzJn.Count;
							QcoljyFcixDOApHDXemkQpFGFazR = 0;
							goto IL_00f1;
							IL_00c5:
							if (IdaQYFSquPFGfasnzUmxIPrzOItL.MoveNext())
							{
								ControllerPollingInfo current = IdaQYFSquPFGfasnzUmxIPrzOItL.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								oXpAJHLmuPfEWDoPqWUHJOzrTzUs = controllerPollingInfo;
								zbwwRLrSRlGKraLHpQwuxwqqPVAc = 1;
								return true;
							}
							rDEKqItImiekHlNXXLPVSUUoDeAB();
							IdaQYFSquPFGfasnzUmxIPrzOItL = null;
							QcoljyFcixDOApHDXemkQpFGFazR++;
							goto IL_00f1;
							IL_00f1:
							if (QcoljyFcixDOApHDXemkQpFGFazR < XKZdsHliUbLCpEHugzLYlrVlLMgk)
							{
								IdaQYFSquPFGfasnzUmxIPrzOItL = pRIzbkozmUNMUxBzxrAXgaYqXzJn[QcoljyFcixDOApHDXemkQpFGFazR].PollForAllElements().GetEnumerator();
								zbwwRLrSRlGKraLHpQwuxwqqPVAc = -3;
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

					private void rDEKqItImiekHlNXXLPVSUUoDeAB()
					{
						zbwwRLrSRlGKraLHpQwuxwqqPVAc = -1;
						if (IdaQYFSquPFGfasnzUmxIPrzOItL != null)
						{
							IdaQYFSquPFGfasnzUmxIPrzOItL.Dispose();
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
						mIWsFhkziJhVFmAMQNjlmDohLRTd mIWsFhkziJhVFmAMQNjlmDohLRTd2;
						if (zbwwRLrSRlGKraLHpQwuxwqqPVAc == -2 && zIeCZCbUgIdpaesuhhSbZCifzILfB == Environment.CurrentManagedThreadId)
						{
							zbwwRLrSRlGKraLHpQwuxwqqPVAc = 0;
							mIWsFhkziJhVFmAMQNjlmDohLRTd2 = this;
						}
						else
						{
							mIWsFhkziJhVFmAMQNjlmDohLRTd2 = new mIWsFhkziJhVFmAMQNjlmDohLRTd(0);
							mIWsFhkziJhVFmAMQNjlmDohLRTd2.mtaKrmqEOkTkxKqUuIENKDTdgzdB = mtaKrmqEOkTkxKqUuIENKDTdgzdB;
						}
						return mIWsFhkziJhVFmAMQNjlmDohLRTd2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class UjelPBhEGmoxMFVwvfumeSpUoDUc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int VHaxAshPwFuKrhzUtPimuUxPRxvL;

					private ControllerPollingInfo dRXwhfgjMZQlqZDwdjzwkcxpbGzQ;

					private int yIDiLWahOUdJbSsmZQDPshPrOkRe;

					public PollingHelper MIWoZKpNXftDmodkiBFUiCDObeyc;

					private IList<Joystick> GuHLQaYfjGZDrBDucSMUjFRBJQJo;

					private int rWGIjMRPoNqjhmcWvKZeObVpGLrgA;

					private int kNvAqGFRcpgyVCJWfjUcghwFbSeTE;

					private IEnumerator<ControllerPollingInfo> LbAFbPezxClzJembOeYbUjEGxHqn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dRXwhfgjMZQlqZDwdjzwkcxpbGzQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dRXwhfgjMZQlqZDwdjzwkcxpbGzQ;
						}
					}

					[DebuggerHidden]
					public UjelPBhEGmoxMFVwvfumeSpUoDUc(int P_0)
					{
						VHaxAshPwFuKrhzUtPimuUxPRxvL = P_0;
						yIDiLWahOUdJbSsmZQDPshPrOkRe = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int vHaxAshPwFuKrhzUtPimuUxPRxvL = VHaxAshPwFuKrhzUtPimuUxPRxvL;
						if (vHaxAshPwFuKrhzUtPimuUxPRxvL == -3 || vHaxAshPwFuKrhzUtPimuUxPRxvL == 1)
						{
							try
							{
							}
							finally
							{
								BrfZxbpjgkFSqNAHpSOCiwWZfCSH();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int vHaxAshPwFuKrhzUtPimuUxPRxvL = VHaxAshPwFuKrhzUtPimuUxPRxvL;
							PollingHelper mIWoZKpNXftDmodkiBFUiCDObeyc = MIWoZKpNXftDmodkiBFUiCDObeyc;
							if (vHaxAshPwFuKrhzUtPimuUxPRxvL != 0)
							{
								if (vHaxAshPwFuKrhzUtPimuUxPRxvL != 1)
								{
									return false;
								}
								VHaxAshPwFuKrhzUtPimuUxPRxvL = -3;
								goto IL_00c5;
							}
							VHaxAshPwFuKrhzUtPimuUxPRxvL = -1;
							GuHLQaYfjGZDrBDucSMUjFRBJQJo = mIWoZKpNXftDmodkiBFUiCDObeyc.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
							rWGIjMRPoNqjhmcWvKZeObVpGLrgA = GuHLQaYfjGZDrBDucSMUjFRBJQJo.Count;
							kNvAqGFRcpgyVCJWfjUcghwFbSeTE = 0;
							goto IL_00f1;
							IL_00c5:
							if (LbAFbPezxClzJembOeYbUjEGxHqn.MoveNext())
							{
								ControllerPollingInfo current = LbAFbPezxClzJembOeYbUjEGxHqn.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = mIWoZKpNXftDmodkiBFUiCDObeyc.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								dRXwhfgjMZQlqZDwdjzwkcxpbGzQ = controllerPollingInfo;
								VHaxAshPwFuKrhzUtPimuUxPRxvL = 1;
								return true;
							}
							BrfZxbpjgkFSqNAHpSOCiwWZfCSH();
							LbAFbPezxClzJembOeYbUjEGxHqn = null;
							kNvAqGFRcpgyVCJWfjUcghwFbSeTE++;
							goto IL_00f1;
							IL_00f1:
							if (kNvAqGFRcpgyVCJWfjUcghwFbSeTE < rWGIjMRPoNqjhmcWvKZeObVpGLrgA)
							{
								LbAFbPezxClzJembOeYbUjEGxHqn = GuHLQaYfjGZDrBDucSMUjFRBJQJo[kNvAqGFRcpgyVCJWfjUcghwFbSeTE].PollForAllElementsDown().GetEnumerator();
								VHaxAshPwFuKrhzUtPimuUxPRxvL = -3;
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

					private void BrfZxbpjgkFSqNAHpSOCiwWZfCSH()
					{
						VHaxAshPwFuKrhzUtPimuUxPRxvL = -1;
						if (LbAFbPezxClzJembOeYbUjEGxHqn != null)
						{
							LbAFbPezxClzJembOeYbUjEGxHqn.Dispose();
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
						UjelPBhEGmoxMFVwvfumeSpUoDUc ujelPBhEGmoxMFVwvfumeSpUoDUc;
						if (VHaxAshPwFuKrhzUtPimuUxPRxvL == -2 && yIDiLWahOUdJbSsmZQDPshPrOkRe == Environment.CurrentManagedThreadId)
						{
							VHaxAshPwFuKrhzUtPimuUxPRxvL = 0;
							ujelPBhEGmoxMFVwvfumeSpUoDUc = this;
						}
						else
						{
							ujelPBhEGmoxMFVwvfumeSpUoDUc = new UjelPBhEGmoxMFVwvfumeSpUoDUc(0);
							ujelPBhEGmoxMFVwvfumeSpUoDUc.MIWoZKpNXftDmodkiBFUiCDObeyc = MIWoZKpNXftDmodkiBFUiCDObeyc;
						}
						return ujelPBhEGmoxMFVwvfumeSpUoDUc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fdaJLRBbmMoBvZyaZGRzptygDEZiA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int DxbvliMLlZIOqiJMftlWnDMuOIXs;

					private ControllerPollingInfo uirBYYWBBlKLQtAgPgflwMlvfIaiA;

					private int iZYCdpGzPethDwWXeoNckbecWSPqA;

					private int BkDHWSIGxGoUzzesglATLINgWoeT;

					public int ZIlCJBbiVengKoouzazYZpzTrvOw;

					public PollingHelper FGZtzxjVTKspKRcjrhARhpiUOZHyA;

					private IEnumerator<ControllerPollingInfo> bjTDdUejnzMXXJuqDubqmwHdNZtl;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return uirBYYWBBlKLQtAgPgflwMlvfIaiA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uirBYYWBBlKLQtAgPgflwMlvfIaiA;
						}
					}

					[DebuggerHidden]
					public fdaJLRBbmMoBvZyaZGRzptygDEZiA(int P_0)
					{
						DxbvliMLlZIOqiJMftlWnDMuOIXs = P_0;
						iZYCdpGzPethDwWXeoNckbecWSPqA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dxbvliMLlZIOqiJMftlWnDMuOIXs = DxbvliMLlZIOqiJMftlWnDMuOIXs;
						if (dxbvliMLlZIOqiJMftlWnDMuOIXs == -3 || dxbvliMLlZIOqiJMftlWnDMuOIXs == 1)
						{
							try
							{
							}
							finally
							{
								PXtVlQCWGMNcVPFhvZQVmoYwMzkL();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int dxbvliMLlZIOqiJMftlWnDMuOIXs = DxbvliMLlZIOqiJMftlWnDMuOIXs;
							PollingHelper fGZtzxjVTKspKRcjrhARhpiUOZHyA = FGZtzxjVTKspKRcjrhARhpiUOZHyA;
							switch (dxbvliMLlZIOqiJMftlWnDMuOIXs)
							{
							default:
								return false;
							case 0:
							{
								DxbvliMLlZIOqiJMftlWnDMuOIXs = -1;
								if (BkDHWSIGxGoUzzesglATLINgWoeT < 0)
								{
									return false;
								}
								CustomController customController = fGZtzxjVTKspKRcjrhARhpiUOZHyA.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(BkDHWSIGxGoUzzesglATLINgWoeT);
								if (customController == null)
								{
									return false;
								}
								bjTDdUejnzMXXJuqDubqmwHdNZtl = customController.PollForAllAxes().GetEnumerator();
								DxbvliMLlZIOqiJMftlWnDMuOIXs = -3;
								break;
							}
							case 1:
								DxbvliMLlZIOqiJMftlWnDMuOIXs = -3;
								break;
							}
							if (bjTDdUejnzMXXJuqDubqmwHdNZtl.MoveNext())
							{
								ControllerPollingInfo current = bjTDdUejnzMXXJuqDubqmwHdNZtl.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = fGZtzxjVTKspKRcjrhARhpiUOZHyA.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								uirBYYWBBlKLQtAgPgflwMlvfIaiA = controllerPollingInfo;
								DxbvliMLlZIOqiJMftlWnDMuOIXs = 1;
								return true;
							}
							PXtVlQCWGMNcVPFhvZQVmoYwMzkL();
							bjTDdUejnzMXXJuqDubqmwHdNZtl = null;
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

					private void PXtVlQCWGMNcVPFhvZQVmoYwMzkL()
					{
						DxbvliMLlZIOqiJMftlWnDMuOIXs = -1;
						if (bjTDdUejnzMXXJuqDubqmwHdNZtl != null)
						{
							bjTDdUejnzMXXJuqDubqmwHdNZtl.Dispose();
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
						fdaJLRBbmMoBvZyaZGRzptygDEZiA fdaJLRBbmMoBvZyaZGRzptygDEZiA2;
						if (DxbvliMLlZIOqiJMftlWnDMuOIXs == -2 && iZYCdpGzPethDwWXeoNckbecWSPqA == Environment.CurrentManagedThreadId)
						{
							DxbvliMLlZIOqiJMftlWnDMuOIXs = 0;
							fdaJLRBbmMoBvZyaZGRzptygDEZiA2 = this;
						}
						else
						{
							fdaJLRBbmMoBvZyaZGRzptygDEZiA2 = new fdaJLRBbmMoBvZyaZGRzptygDEZiA(0);
							fdaJLRBbmMoBvZyaZGRzptygDEZiA2.FGZtzxjVTKspKRcjrhARhpiUOZHyA = FGZtzxjVTKspKRcjrhARhpiUOZHyA;
						}
						fdaJLRBbmMoBvZyaZGRzptygDEZiA2.BkDHWSIGxGoUzzesglATLINgWoeT = ZIlCJBbiVengKoouzazYZpzTrvOw;
						return fdaJLRBbmMoBvZyaZGRzptygDEZiA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class HWsAwQkwfbrbBiMawvQYHhNrbxRX : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int NeoEtPJUuKRnEHJsYqsdsPnOOonfA;

					private ControllerPollingInfo eHIQkbfcxkARjfhSGybOFbTrHoXX;

					private int QVFuTufOGQkiqGVqDofHsVXMjPEE;

					private int zWwcyucoWHfIqJhSAgQiAJHJrEDfA;

					public int xUTwFrdoApSSgCejnWOoeGlKnBUC;

					public PollingHelper riAIeepAJuJaTGDhNAlxayWQxzku;

					private IEnumerator<ControllerPollingInfo> hGmshCkbnQjAUbytOgfVPHuppUdpA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return eHIQkbfcxkARjfhSGybOFbTrHoXX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return eHIQkbfcxkARjfhSGybOFbTrHoXX;
						}
					}

					[DebuggerHidden]
					public HWsAwQkwfbrbBiMawvQYHhNrbxRX(int P_0)
					{
						NeoEtPJUuKRnEHJsYqsdsPnOOonfA = P_0;
						QVFuTufOGQkiqGVqDofHsVXMjPEE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int neoEtPJUuKRnEHJsYqsdsPnOOonfA = NeoEtPJUuKRnEHJsYqsdsPnOOonfA;
						if (neoEtPJUuKRnEHJsYqsdsPnOOonfA == -3 || neoEtPJUuKRnEHJsYqsdsPnOOonfA == 1)
						{
							try
							{
							}
							finally
							{
								OFvBxDlOFuVsCNvOaApxXvaSTeFb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int neoEtPJUuKRnEHJsYqsdsPnOOonfA = NeoEtPJUuKRnEHJsYqsdsPnOOonfA;
							PollingHelper pollingHelper = riAIeepAJuJaTGDhNAlxayWQxzku;
							switch (neoEtPJUuKRnEHJsYqsdsPnOOonfA)
							{
							default:
								return false;
							case 0:
							{
								NeoEtPJUuKRnEHJsYqsdsPnOOonfA = -1;
								if (zWwcyucoWHfIqJhSAgQiAJHJrEDfA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(zWwcyucoWHfIqJhSAgQiAJHJrEDfA);
								if (customController == null)
								{
									return false;
								}
								hGmshCkbnQjAUbytOgfVPHuppUdpA = customController.PollForAllButtons().GetEnumerator();
								NeoEtPJUuKRnEHJsYqsdsPnOOonfA = -3;
								break;
							}
							case 1:
								NeoEtPJUuKRnEHJsYqsdsPnOOonfA = -3;
								break;
							}
							if (hGmshCkbnQjAUbytOgfVPHuppUdpA.MoveNext())
							{
								ControllerPollingInfo current = hGmshCkbnQjAUbytOgfVPHuppUdpA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								eHIQkbfcxkARjfhSGybOFbTrHoXX = controllerPollingInfo;
								NeoEtPJUuKRnEHJsYqsdsPnOOonfA = 1;
								return true;
							}
							OFvBxDlOFuVsCNvOaApxXvaSTeFb();
							hGmshCkbnQjAUbytOgfVPHuppUdpA = null;
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

					private void OFvBxDlOFuVsCNvOaApxXvaSTeFb()
					{
						NeoEtPJUuKRnEHJsYqsdsPnOOonfA = -1;
						if (hGmshCkbnQjAUbytOgfVPHuppUdpA != null)
						{
							hGmshCkbnQjAUbytOgfVPHuppUdpA.Dispose();
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
						HWsAwQkwfbrbBiMawvQYHhNrbxRX hWsAwQkwfbrbBiMawvQYHhNrbxRX;
						if (NeoEtPJUuKRnEHJsYqsdsPnOOonfA == -2 && QVFuTufOGQkiqGVqDofHsVXMjPEE == Environment.CurrentManagedThreadId)
						{
							NeoEtPJUuKRnEHJsYqsdsPnOOonfA = 0;
							hWsAwQkwfbrbBiMawvQYHhNrbxRX = this;
						}
						else
						{
							hWsAwQkwfbrbBiMawvQYHhNrbxRX = new HWsAwQkwfbrbBiMawvQYHhNrbxRX(0);
							hWsAwQkwfbrbBiMawvQYHhNrbxRX.riAIeepAJuJaTGDhNAlxayWQxzku = riAIeepAJuJaTGDhNAlxayWQxzku;
						}
						hWsAwQkwfbrbBiMawvQYHhNrbxRX.zWwcyucoWHfIqJhSAgQiAJHJrEDfA = xUTwFrdoApSSgCejnWOoeGlKnBUC;
						return hWsAwQkwfbrbBiMawvQYHhNrbxRX;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class qHTGKmkFxgUiHQGFFUsoNNpqOENIA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int AjLnDAToGshrygIKGJfZDiPfuLCkb;

					private ControllerPollingInfo KpvIYutyNDnlWodfGiIgkPNNPAqc;

					private int kWxZScvZoALNmCGNZvHilqUQuhWw;

					private int vJXGJfJcDkgIzkvcLwwpmvNrQMAi;

					public int qbaKNjhPDZAMjkaYdttRanVmYoMpA;

					public PollingHelper yclsgFTvvpVcGZFzNwjyAunNzXoc;

					private IEnumerator<ControllerPollingInfo> ZqJqKBwHqaTahaMIGvbuYsTuxDDD;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KpvIYutyNDnlWodfGiIgkPNNPAqc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KpvIYutyNDnlWodfGiIgkPNNPAqc;
						}
					}

					[DebuggerHidden]
					public qHTGKmkFxgUiHQGFFUsoNNpqOENIA(int P_0)
					{
						AjLnDAToGshrygIKGJfZDiPfuLCkb = P_0;
						kWxZScvZoALNmCGNZvHilqUQuhWw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ajLnDAToGshrygIKGJfZDiPfuLCkb = AjLnDAToGshrygIKGJfZDiPfuLCkb;
						if (ajLnDAToGshrygIKGJfZDiPfuLCkb == -3 || ajLnDAToGshrygIKGJfZDiPfuLCkb == 1)
						{
							try
							{
							}
							finally
							{
								tqjPNJoWAaNTmeQtKsqJUHmYEosgA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ajLnDAToGshrygIKGJfZDiPfuLCkb = AjLnDAToGshrygIKGJfZDiPfuLCkb;
							PollingHelper pollingHelper = yclsgFTvvpVcGZFzNwjyAunNzXoc;
							switch (ajLnDAToGshrygIKGJfZDiPfuLCkb)
							{
							default:
								return false;
							case 0:
							{
								AjLnDAToGshrygIKGJfZDiPfuLCkb = -1;
								if (vJXGJfJcDkgIzkvcLwwpmvNrQMAi < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(vJXGJfJcDkgIzkvcLwwpmvNrQMAi);
								if (customController == null)
								{
									return false;
								}
								ZqJqKBwHqaTahaMIGvbuYsTuxDDD = customController.PollForAllButtonsDown().GetEnumerator();
								AjLnDAToGshrygIKGJfZDiPfuLCkb = -3;
								break;
							}
							case 1:
								AjLnDAToGshrygIKGJfZDiPfuLCkb = -3;
								break;
							}
							if (ZqJqKBwHqaTahaMIGvbuYsTuxDDD.MoveNext())
							{
								ControllerPollingInfo current = ZqJqKBwHqaTahaMIGvbuYsTuxDDD.Current;
								ControllerPollingInfo kpvIYutyNDnlWodfGiIgkPNNPAqc = new ControllerPollingInfo(current);
								kpvIYutyNDnlWodfGiIgkPNNPAqc.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								KpvIYutyNDnlWodfGiIgkPNNPAqc = kpvIYutyNDnlWodfGiIgkPNNPAqc;
								AjLnDAToGshrygIKGJfZDiPfuLCkb = 1;
								return true;
							}
							tqjPNJoWAaNTmeQtKsqJUHmYEosgA();
							ZqJqKBwHqaTahaMIGvbuYsTuxDDD = null;
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

					private void tqjPNJoWAaNTmeQtKsqJUHmYEosgA()
					{
						AjLnDAToGshrygIKGJfZDiPfuLCkb = -1;
						if (ZqJqKBwHqaTahaMIGvbuYsTuxDDD != null)
						{
							ZqJqKBwHqaTahaMIGvbuYsTuxDDD.Dispose();
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
						qHTGKmkFxgUiHQGFFUsoNNpqOENIA qHTGKmkFxgUiHQGFFUsoNNpqOENIA2;
						if (AjLnDAToGshrygIKGJfZDiPfuLCkb == -2 && kWxZScvZoALNmCGNZvHilqUQuhWw == Environment.CurrentManagedThreadId)
						{
							AjLnDAToGshrygIKGJfZDiPfuLCkb = 0;
							qHTGKmkFxgUiHQGFFUsoNNpqOENIA2 = this;
						}
						else
						{
							qHTGKmkFxgUiHQGFFUsoNNpqOENIA2 = new qHTGKmkFxgUiHQGFFUsoNNpqOENIA(0);
							qHTGKmkFxgUiHQGFFUsoNNpqOENIA2.yclsgFTvvpVcGZFzNwjyAunNzXoc = yclsgFTvvpVcGZFzNwjyAunNzXoc;
						}
						qHTGKmkFxgUiHQGFFUsoNNpqOENIA2.vJXGJfJcDkgIzkvcLwwpmvNrQMAi = qbaKNjhPDZAMjkaYdttRanVmYoMpA;
						return qHTGKmkFxgUiHQGFFUsoNNpqOENIA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class yxAzWJhKaGgXWALidnLukiAjeIfk : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int TNKOMOmfPvdqAwLTQPINNufyprpk;

					private ControllerPollingInfo tXnGwCyisLelhPhmJbdaFdRQqCAfb;

					private int NXTNwWTkMxJfRfLwrGceWtXSaWvEA;

					private int SekcTQHAkzLUmJMXNlnQecFkXHEOB;

					public int CatvDCqWpcVFptBIDgQiLHVbCRyx;

					public PollingHelper iauAZEwVTatNrJVZCssfpUpagDQE;

					private IEnumerator<ControllerPollingInfo> HZBXfjooWCmyJnCHXczNzIdCtngO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tXnGwCyisLelhPhmJbdaFdRQqCAfb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tXnGwCyisLelhPhmJbdaFdRQqCAfb;
						}
					}

					[DebuggerHidden]
					public yxAzWJhKaGgXWALidnLukiAjeIfk(int P_0)
					{
						TNKOMOmfPvdqAwLTQPINNufyprpk = P_0;
						NXTNwWTkMxJfRfLwrGceWtXSaWvEA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int tNKOMOmfPvdqAwLTQPINNufyprpk = TNKOMOmfPvdqAwLTQPINNufyprpk;
						if (tNKOMOmfPvdqAwLTQPINNufyprpk == -3 || tNKOMOmfPvdqAwLTQPINNufyprpk == 1)
						{
							try
							{
							}
							finally
							{
								OqTYOkfMsFwyWhIvWtfyqfnWqcaN();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int tNKOMOmfPvdqAwLTQPINNufyprpk = TNKOMOmfPvdqAwLTQPINNufyprpk;
							PollingHelper pollingHelper = iauAZEwVTatNrJVZCssfpUpagDQE;
							switch (tNKOMOmfPvdqAwLTQPINNufyprpk)
							{
							default:
								return false;
							case 0:
							{
								TNKOMOmfPvdqAwLTQPINNufyprpk = -1;
								if (SekcTQHAkzLUmJMXNlnQecFkXHEOB < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(SekcTQHAkzLUmJMXNlnQecFkXHEOB);
								if (customController == null)
								{
									return false;
								}
								HZBXfjooWCmyJnCHXczNzIdCtngO = customController.PollForAllElements().GetEnumerator();
								TNKOMOmfPvdqAwLTQPINNufyprpk = -3;
								break;
							}
							case 1:
								TNKOMOmfPvdqAwLTQPINNufyprpk = -3;
								break;
							}
							if (HZBXfjooWCmyJnCHXczNzIdCtngO.MoveNext())
							{
								ControllerPollingInfo current = HZBXfjooWCmyJnCHXczNzIdCtngO.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								tXnGwCyisLelhPhmJbdaFdRQqCAfb = controllerPollingInfo;
								TNKOMOmfPvdqAwLTQPINNufyprpk = 1;
								return true;
							}
							OqTYOkfMsFwyWhIvWtfyqfnWqcaN();
							HZBXfjooWCmyJnCHXczNzIdCtngO = null;
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

					private void OqTYOkfMsFwyWhIvWtfyqfnWqcaN()
					{
						TNKOMOmfPvdqAwLTQPINNufyprpk = -1;
						if (HZBXfjooWCmyJnCHXczNzIdCtngO != null)
						{
							HZBXfjooWCmyJnCHXczNzIdCtngO.Dispose();
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
						yxAzWJhKaGgXWALidnLukiAjeIfk yxAzWJhKaGgXWALidnLukiAjeIfk2;
						if (TNKOMOmfPvdqAwLTQPINNufyprpk == -2 && NXTNwWTkMxJfRfLwrGceWtXSaWvEA == Environment.CurrentManagedThreadId)
						{
							TNKOMOmfPvdqAwLTQPINNufyprpk = 0;
							yxAzWJhKaGgXWALidnLukiAjeIfk2 = this;
						}
						else
						{
							yxAzWJhKaGgXWALidnLukiAjeIfk2 = new yxAzWJhKaGgXWALidnLukiAjeIfk(0);
							yxAzWJhKaGgXWALidnLukiAjeIfk2.iauAZEwVTatNrJVZCssfpUpagDQE = iauAZEwVTatNrJVZCssfpUpagDQE;
						}
						yxAzWJhKaGgXWALidnLukiAjeIfk2.SekcTQHAkzLUmJMXNlnQecFkXHEOB = CatvDCqWpcVFptBIDgQiLHVbCRyx;
						return yxAzWJhKaGgXWALidnLukiAjeIfk2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class zSJDdNjHInyKmWLAJdRDMYDgolWlA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int rogfJzPuYcVvusmGUgVTujvjHJtX;

					private ControllerPollingInfo KjzTVIQcvwGlKOItdrYZsvCtuiBm;

					private int ORWjSqnYTndlUNAoExlUhSeEpzOr;

					private int LtMBgdQPDgGqhKCvFkZTgqJbMPFz;

					public int fsXlsDEzSjeKwdjlTdASIJIPLEnp;

					public PollingHelper gMyktrVgpELyFYWfqURrcAmILWzQ;

					private IEnumerator<ControllerPollingInfo> YYMHqpvzuXoMbJbCxEysCMCTosLq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KjzTVIQcvwGlKOItdrYZsvCtuiBm;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KjzTVIQcvwGlKOItdrYZsvCtuiBm;
						}
					}

					[DebuggerHidden]
					public zSJDdNjHInyKmWLAJdRDMYDgolWlA(int P_0)
					{
						rogfJzPuYcVvusmGUgVTujvjHJtX = P_0;
						ORWjSqnYTndlUNAoExlUhSeEpzOr = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rogfJzPuYcVvusmGUgVTujvjHJtX;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								gXsfXccTNKPDBEOUnsjdnUawbDpMA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rogfJzPuYcVvusmGUgVTujvjHJtX;
							PollingHelper pollingHelper = gMyktrVgpELyFYWfqURrcAmILWzQ;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								rogfJzPuYcVvusmGUgVTujvjHJtX = -1;
								if (LtMBgdQPDgGqhKCvFkZTgqJbMPFz < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(LtMBgdQPDgGqhKCvFkZTgqJbMPFz);
								if (customController == null)
								{
									return false;
								}
								YYMHqpvzuXoMbJbCxEysCMCTosLq = customController.PollForAllElementsDown().GetEnumerator();
								rogfJzPuYcVvusmGUgVTujvjHJtX = -3;
								break;
							}
							case 1:
								rogfJzPuYcVvusmGUgVTujvjHJtX = -3;
								break;
							}
							if (YYMHqpvzuXoMbJbCxEysCMCTosLq.MoveNext())
							{
								ControllerPollingInfo current = YYMHqpvzuXoMbJbCxEysCMCTosLq.Current;
								ControllerPollingInfo kjzTVIQcvwGlKOItdrYZsvCtuiBm = new ControllerPollingInfo(current);
								kjzTVIQcvwGlKOItdrYZsvCtuiBm.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								KjzTVIQcvwGlKOItdrYZsvCtuiBm = kjzTVIQcvwGlKOItdrYZsvCtuiBm;
								rogfJzPuYcVvusmGUgVTujvjHJtX = 1;
								return true;
							}
							gXsfXccTNKPDBEOUnsjdnUawbDpMA();
							YYMHqpvzuXoMbJbCxEysCMCTosLq = null;
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

					private void gXsfXccTNKPDBEOUnsjdnUawbDpMA()
					{
						rogfJzPuYcVvusmGUgVTujvjHJtX = -1;
						if (YYMHqpvzuXoMbJbCxEysCMCTosLq != null)
						{
							YYMHqpvzuXoMbJbCxEysCMCTosLq.Dispose();
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
						zSJDdNjHInyKmWLAJdRDMYDgolWlA zSJDdNjHInyKmWLAJdRDMYDgolWlA2;
						if (rogfJzPuYcVvusmGUgVTujvjHJtX == -2 && ORWjSqnYTndlUNAoExlUhSeEpzOr == Environment.CurrentManagedThreadId)
						{
							rogfJzPuYcVvusmGUgVTujvjHJtX = 0;
							zSJDdNjHInyKmWLAJdRDMYDgolWlA2 = this;
						}
						else
						{
							zSJDdNjHInyKmWLAJdRDMYDgolWlA2 = new zSJDdNjHInyKmWLAJdRDMYDgolWlA(0);
							zSJDdNjHInyKmWLAJdRDMYDgolWlA2.gMyktrVgpELyFYWfqURrcAmILWzQ = gMyktrVgpELyFYWfqURrcAmILWzQ;
						}
						zSJDdNjHInyKmWLAJdRDMYDgolWlA2.LtMBgdQPDgGqhKCvFkZTgqJbMPFz = fsXlsDEzSjeKwdjlTdASIJIPLEnp;
						return zSJDdNjHInyKmWLAJdRDMYDgolWlA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class BskZhPcoBbQubrmzIRvRgwxfDOnr : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int DNYBmlHcTlZgDweEgsRGczwYcsOG;

					private ControllerPollingInfo XgHmxmhXUsqwYMlCtdulOlosIAOG;

					private int GuphICpyOuWAMsADFIvRLYklLlij;

					private int aMxWFbWThEwLdgeouWrrOsXkHuqS;

					public int fUEgZnWIbKbrbdrnkQBVGvFSLsehA;

					public PollingHelper amnAWPuvKuiWrUhNUHWKKSidiNQHA;

					private IEnumerator<ControllerPollingInfo> GBibrDIPNhAaCpzXSkvaITgaGMbAb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return XgHmxmhXUsqwYMlCtdulOlosIAOG;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return XgHmxmhXUsqwYMlCtdulOlosIAOG;
						}
					}

					[DebuggerHidden]
					public BskZhPcoBbQubrmzIRvRgwxfDOnr(int P_0)
					{
						DNYBmlHcTlZgDweEgsRGczwYcsOG = P_0;
						GuphICpyOuWAMsADFIvRLYklLlij = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dNYBmlHcTlZgDweEgsRGczwYcsOG = DNYBmlHcTlZgDweEgsRGczwYcsOG;
						if (dNYBmlHcTlZgDweEgsRGczwYcsOG == -3 || dNYBmlHcTlZgDweEgsRGczwYcsOG == 1)
						{
							try
							{
							}
							finally
							{
								bmKHMMlYMrTZIlifbIaGpBDKNpop();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int dNYBmlHcTlZgDweEgsRGczwYcsOG = DNYBmlHcTlZgDweEgsRGczwYcsOG;
							PollingHelper pollingHelper = amnAWPuvKuiWrUhNUHWKKSidiNQHA;
							switch (dNYBmlHcTlZgDweEgsRGczwYcsOG)
							{
							default:
								return false;
							case 0:
							{
								DNYBmlHcTlZgDweEgsRGczwYcsOG = -1;
								if (aMxWFbWThEwLdgeouWrrOsXkHuqS < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(aMxWFbWThEwLdgeouWrrOsXkHuqS);
								if (joystick == null)
								{
									return false;
								}
								GBibrDIPNhAaCpzXSkvaITgaGMbAb = joystick.PollForAllAxes().GetEnumerator();
								DNYBmlHcTlZgDweEgsRGczwYcsOG = -3;
								break;
							}
							case 1:
								DNYBmlHcTlZgDweEgsRGczwYcsOG = -3;
								break;
							}
							if (GBibrDIPNhAaCpzXSkvaITgaGMbAb.MoveNext())
							{
								ControllerPollingInfo current = GBibrDIPNhAaCpzXSkvaITgaGMbAb.Current;
								ControllerPollingInfo xgHmxmhXUsqwYMlCtdulOlosIAOG = new ControllerPollingInfo(current);
								xgHmxmhXUsqwYMlCtdulOlosIAOG.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								XgHmxmhXUsqwYMlCtdulOlosIAOG = xgHmxmhXUsqwYMlCtdulOlosIAOG;
								DNYBmlHcTlZgDweEgsRGczwYcsOG = 1;
								return true;
							}
							bmKHMMlYMrTZIlifbIaGpBDKNpop();
							GBibrDIPNhAaCpzXSkvaITgaGMbAb = null;
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

					private void bmKHMMlYMrTZIlifbIaGpBDKNpop()
					{
						DNYBmlHcTlZgDweEgsRGczwYcsOG = -1;
						if (GBibrDIPNhAaCpzXSkvaITgaGMbAb != null)
						{
							GBibrDIPNhAaCpzXSkvaITgaGMbAb.Dispose();
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
						BskZhPcoBbQubrmzIRvRgwxfDOnr bskZhPcoBbQubrmzIRvRgwxfDOnr;
						if (DNYBmlHcTlZgDweEgsRGczwYcsOG == -2 && GuphICpyOuWAMsADFIvRLYklLlij == Environment.CurrentManagedThreadId)
						{
							DNYBmlHcTlZgDweEgsRGczwYcsOG = 0;
							bskZhPcoBbQubrmzIRvRgwxfDOnr = this;
						}
						else
						{
							bskZhPcoBbQubrmzIRvRgwxfDOnr = new BskZhPcoBbQubrmzIRvRgwxfDOnr(0);
							bskZhPcoBbQubrmzIRvRgwxfDOnr.amnAWPuvKuiWrUhNUHWKKSidiNQHA = amnAWPuvKuiWrUhNUHWKKSidiNQHA;
						}
						bskZhPcoBbQubrmzIRvRgwxfDOnr.aMxWFbWThEwLdgeouWrrOsXkHuqS = fUEgZnWIbKbrbdrnkQBVGvFSLsehA;
						return bskZhPcoBbQubrmzIRvRgwxfDOnr;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class YncpHQYIakdyycWBuURZZmwWYwDA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XErlNCdxoCcQnNpePhGgbXzljbkKA;

					private ControllerPollingInfo GDjykCTSItFWReKqipuimTOMnkqf;

					private int CPWrzzpvOMWqXEBsstipRWgmuazP;

					private int pXezJdfYtHLCrkCdVaafYNhpIdukA;

					public int vakPkfuUPOfoGfNAgftwTAaEdQny;

					public PollingHelper RwUfQRIolYxkyhzttcUtDNIFUxNtA;

					private IEnumerator<ControllerPollingInfo> WenGgUgbUCCqJdVvfJosQRGGqtqvB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GDjykCTSItFWReKqipuimTOMnkqf;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GDjykCTSItFWReKqipuimTOMnkqf;
						}
					}

					[DebuggerHidden]
					public YncpHQYIakdyycWBuURZZmwWYwDA(int P_0)
					{
						XErlNCdxoCcQnNpePhGgbXzljbkKA = P_0;
						CPWrzzpvOMWqXEBsstipRWgmuazP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xErlNCdxoCcQnNpePhGgbXzljbkKA = XErlNCdxoCcQnNpePhGgbXzljbkKA;
						if (xErlNCdxoCcQnNpePhGgbXzljbkKA == -3 || xErlNCdxoCcQnNpePhGgbXzljbkKA == 1)
						{
							try
							{
							}
							finally
							{
								EckYuVgLQEokvvsBBqDiUooHjwAhA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int xErlNCdxoCcQnNpePhGgbXzljbkKA = XErlNCdxoCcQnNpePhGgbXzljbkKA;
							PollingHelper rwUfQRIolYxkyhzttcUtDNIFUxNtA = RwUfQRIolYxkyhzttcUtDNIFUxNtA;
							switch (xErlNCdxoCcQnNpePhGgbXzljbkKA)
							{
							default:
								return false;
							case 0:
							{
								XErlNCdxoCcQnNpePhGgbXzljbkKA = -1;
								if (pXezJdfYtHLCrkCdVaafYNhpIdukA < 0)
								{
									return false;
								}
								Joystick joystick = rwUfQRIolYxkyhzttcUtDNIFUxNtA.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(pXezJdfYtHLCrkCdVaafYNhpIdukA);
								if (joystick == null)
								{
									return false;
								}
								WenGgUgbUCCqJdVvfJosQRGGqtqvB = joystick.PollForAllButtons().GetEnumerator();
								XErlNCdxoCcQnNpePhGgbXzljbkKA = -3;
								break;
							}
							case 1:
								XErlNCdxoCcQnNpePhGgbXzljbkKA = -3;
								break;
							}
							if (WenGgUgbUCCqJdVvfJosQRGGqtqvB.MoveNext())
							{
								ControllerPollingInfo current = WenGgUgbUCCqJdVvfJosQRGGqtqvB.Current;
								ControllerPollingInfo gDjykCTSItFWReKqipuimTOMnkqf = new ControllerPollingInfo(current);
								gDjykCTSItFWReKqipuimTOMnkqf.playerId = rwUfQRIolYxkyhzttcUtDNIFUxNtA.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								GDjykCTSItFWReKqipuimTOMnkqf = gDjykCTSItFWReKqipuimTOMnkqf;
								XErlNCdxoCcQnNpePhGgbXzljbkKA = 1;
								return true;
							}
							EckYuVgLQEokvvsBBqDiUooHjwAhA();
							WenGgUgbUCCqJdVvfJosQRGGqtqvB = null;
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

					private void EckYuVgLQEokvvsBBqDiUooHjwAhA()
					{
						XErlNCdxoCcQnNpePhGgbXzljbkKA = -1;
						if (WenGgUgbUCCqJdVvfJosQRGGqtqvB != null)
						{
							WenGgUgbUCCqJdVvfJosQRGGqtqvB.Dispose();
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
						YncpHQYIakdyycWBuURZZmwWYwDA yncpHQYIakdyycWBuURZZmwWYwDA;
						if (XErlNCdxoCcQnNpePhGgbXzljbkKA == -2 && CPWrzzpvOMWqXEBsstipRWgmuazP == Environment.CurrentManagedThreadId)
						{
							XErlNCdxoCcQnNpePhGgbXzljbkKA = 0;
							yncpHQYIakdyycWBuURZZmwWYwDA = this;
						}
						else
						{
							yncpHQYIakdyycWBuURZZmwWYwDA = new YncpHQYIakdyycWBuURZZmwWYwDA(0);
							yncpHQYIakdyycWBuURZZmwWYwDA.RwUfQRIolYxkyhzttcUtDNIFUxNtA = RwUfQRIolYxkyhzttcUtDNIFUxNtA;
						}
						yncpHQYIakdyycWBuURZZmwWYwDA.pXezJdfYtHLCrkCdVaafYNhpIdukA = vakPkfuUPOfoGfNAgftwTAaEdQny;
						return yncpHQYIakdyycWBuURZZmwWYwDA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class brtPoWkkTcakbHkaPgwbpKnNlwbo : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sTTeYMVBkRzcqqEeMbwODWDoUgBSA;

					private ControllerPollingInfo SOzJOGrucevBzXglAjOWlTNFYBUB;

					private int vKKVWdbskDLazyHqAKncpdOBhLLX;

					private int rlVZMkQmjqYnPmPkpkjTNiiizuHj;

					public int ZdKYGUDMQgxVoRdFFlqOpZpwcsdv;

					public PollingHelper BMrxDcZbDWcVQZJXGreNgNlPiWPf;

					private IEnumerator<ControllerPollingInfo> BeCkuKttRLCKdxfbzYvxXGESHWek;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return SOzJOGrucevBzXglAjOWlTNFYBUB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SOzJOGrucevBzXglAjOWlTNFYBUB;
						}
					}

					[DebuggerHidden]
					public brtPoWkkTcakbHkaPgwbpKnNlwbo(int P_0)
					{
						sTTeYMVBkRzcqqEeMbwODWDoUgBSA = P_0;
						vKKVWdbskDLazyHqAKncpdOBhLLX = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sTTeYMVBkRzcqqEeMbwODWDoUgBSA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								QMHBtcBxvwSgeeEdYaryOmvJXbnK();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = sTTeYMVBkRzcqqEeMbwODWDoUgBSA;
							PollingHelper bMrxDcZbDWcVQZJXGreNgNlPiWPf = BMrxDcZbDWcVQZJXGreNgNlPiWPf;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								sTTeYMVBkRzcqqEeMbwODWDoUgBSA = -1;
								if (rlVZMkQmjqYnPmPkpkjTNiiizuHj < 0)
								{
									return false;
								}
								Joystick joystick = bMrxDcZbDWcVQZJXGreNgNlPiWPf.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(rlVZMkQmjqYnPmPkpkjTNiiizuHj);
								if (joystick == null)
								{
									return false;
								}
								BeCkuKttRLCKdxfbzYvxXGESHWek = joystick.PollForAllButtonsDown().GetEnumerator();
								sTTeYMVBkRzcqqEeMbwODWDoUgBSA = -3;
								break;
							}
							case 1:
								sTTeYMVBkRzcqqEeMbwODWDoUgBSA = -3;
								break;
							}
							if (BeCkuKttRLCKdxfbzYvxXGESHWek.MoveNext())
							{
								ControllerPollingInfo current = BeCkuKttRLCKdxfbzYvxXGESHWek.Current;
								ControllerPollingInfo sOzJOGrucevBzXglAjOWlTNFYBUB = new ControllerPollingInfo(current);
								sOzJOGrucevBzXglAjOWlTNFYBUB.playerId = bMrxDcZbDWcVQZJXGreNgNlPiWPf.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								SOzJOGrucevBzXglAjOWlTNFYBUB = sOzJOGrucevBzXglAjOWlTNFYBUB;
								sTTeYMVBkRzcqqEeMbwODWDoUgBSA = 1;
								return true;
							}
							QMHBtcBxvwSgeeEdYaryOmvJXbnK();
							BeCkuKttRLCKdxfbzYvxXGESHWek = null;
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

					private void QMHBtcBxvwSgeeEdYaryOmvJXbnK()
					{
						sTTeYMVBkRzcqqEeMbwODWDoUgBSA = -1;
						if (BeCkuKttRLCKdxfbzYvxXGESHWek != null)
						{
							BeCkuKttRLCKdxfbzYvxXGESHWek.Dispose();
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
						brtPoWkkTcakbHkaPgwbpKnNlwbo brtPoWkkTcakbHkaPgwbpKnNlwbo2;
						if (sTTeYMVBkRzcqqEeMbwODWDoUgBSA == -2 && vKKVWdbskDLazyHqAKncpdOBhLLX == Environment.CurrentManagedThreadId)
						{
							sTTeYMVBkRzcqqEeMbwODWDoUgBSA = 0;
							brtPoWkkTcakbHkaPgwbpKnNlwbo2 = this;
						}
						else
						{
							brtPoWkkTcakbHkaPgwbpKnNlwbo2 = new brtPoWkkTcakbHkaPgwbpKnNlwbo(0);
							brtPoWkkTcakbHkaPgwbpKnNlwbo2.BMrxDcZbDWcVQZJXGreNgNlPiWPf = BMrxDcZbDWcVQZJXGreNgNlPiWPf;
						}
						brtPoWkkTcakbHkaPgwbpKnNlwbo2.rlVZMkQmjqYnPmPkpkjTNiiizuHj = ZdKYGUDMQgxVoRdFFlqOpZpwcsdv;
						return brtPoWkkTcakbHkaPgwbpKnNlwbo2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ViCdqwhJcQljtaIONUbiAFiojVWBA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int kMzROeLWEcxVDBtgyIKsVjWfHgvh;

					private ControllerPollingInfo wdJpNrEPagmmwtebphtnEnsFZxVl;

					private int InPmwodorvEUEVAhiUwdVebEdLsA;

					private int XRWCiwEHSDvkmuzbBTekLxHOwlpkA;

					public int DfMLXxXDYLgrlIqSpXTGUGflkmAlA;

					public PollingHelper klzpeangbwwiHuavnNPafRLazWui;

					private IEnumerator<ControllerPollingInfo> gpNByNdyAwmXyBmKytVIpOaSWazx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wdJpNrEPagmmwtebphtnEnsFZxVl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wdJpNrEPagmmwtebphtnEnsFZxVl;
						}
					}

					[DebuggerHidden]
					public ViCdqwhJcQljtaIONUbiAFiojVWBA(int P_0)
					{
						kMzROeLWEcxVDBtgyIKsVjWfHgvh = P_0;
						InPmwodorvEUEVAhiUwdVebEdLsA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = kMzROeLWEcxVDBtgyIKsVjWfHgvh;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								dymOsamtWQfIqHXRJAZzzejPuUom();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = kMzROeLWEcxVDBtgyIKsVjWfHgvh;
							PollingHelper pollingHelper = klzpeangbwwiHuavnNPafRLazWui;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								kMzROeLWEcxVDBtgyIKsVjWfHgvh = -1;
								if (XRWCiwEHSDvkmuzbBTekLxHOwlpkA < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(XRWCiwEHSDvkmuzbBTekLxHOwlpkA);
								if (joystick == null)
								{
									return false;
								}
								gpNByNdyAwmXyBmKytVIpOaSWazx = joystick.PollForAllElements().GetEnumerator();
								kMzROeLWEcxVDBtgyIKsVjWfHgvh = -3;
								break;
							}
							case 1:
								kMzROeLWEcxVDBtgyIKsVjWfHgvh = -3;
								break;
							}
							if (gpNByNdyAwmXyBmKytVIpOaSWazx.MoveNext())
							{
								ControllerPollingInfo current = gpNByNdyAwmXyBmKytVIpOaSWazx.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								wdJpNrEPagmmwtebphtnEnsFZxVl = controllerPollingInfo;
								kMzROeLWEcxVDBtgyIKsVjWfHgvh = 1;
								return true;
							}
							dymOsamtWQfIqHXRJAZzzejPuUom();
							gpNByNdyAwmXyBmKytVIpOaSWazx = null;
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

					private void dymOsamtWQfIqHXRJAZzzejPuUom()
					{
						kMzROeLWEcxVDBtgyIKsVjWfHgvh = -1;
						if (gpNByNdyAwmXyBmKytVIpOaSWazx != null)
						{
							gpNByNdyAwmXyBmKytVIpOaSWazx.Dispose();
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
						ViCdqwhJcQljtaIONUbiAFiojVWBA viCdqwhJcQljtaIONUbiAFiojVWBA;
						if (kMzROeLWEcxVDBtgyIKsVjWfHgvh == -2 && InPmwodorvEUEVAhiUwdVebEdLsA == Environment.CurrentManagedThreadId)
						{
							kMzROeLWEcxVDBtgyIKsVjWfHgvh = 0;
							viCdqwhJcQljtaIONUbiAFiojVWBA = this;
						}
						else
						{
							viCdqwhJcQljtaIONUbiAFiojVWBA = new ViCdqwhJcQljtaIONUbiAFiojVWBA(0);
							viCdqwhJcQljtaIONUbiAFiojVWBA.klzpeangbwwiHuavnNPafRLazWui = klzpeangbwwiHuavnNPafRLazWui;
						}
						viCdqwhJcQljtaIONUbiAFiojVWBA.XRWCiwEHSDvkmuzbBTekLxHOwlpkA = DfMLXxXDYLgrlIqSpXTGUGflkmAlA;
						return viCdqwhJcQljtaIONUbiAFiojVWBA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class OJErnfQGiMDTyjsmTHmejkTxyKap : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int rilHIeVUjkNiIaDZxalfDAEXpeVLA;

					private ControllerPollingInfo bDUGOAUvcyDuJjcBBGOIKRJXyUiAA;

					private int heohhafpaDEwzsYgYBYggEzLXbQY;

					private int nFNEHpSdwNskLeCFXsShzBDLNNDQ;

					public int obUrBTQPOzjvTchpuLaLHwPhMGxwb;

					public PollingHelper ESmTlulgwnQUUeJuPqBInsjtPIxw;

					private IEnumerator<ControllerPollingInfo> tkjCApxNcCDbaHmYKWWOQecZqlPn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return bDUGOAUvcyDuJjcBBGOIKRJXyUiAA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bDUGOAUvcyDuJjcBBGOIKRJXyUiAA;
						}
					}

					[DebuggerHidden]
					public OJErnfQGiMDTyjsmTHmejkTxyKap(int P_0)
					{
						rilHIeVUjkNiIaDZxalfDAEXpeVLA = P_0;
						heohhafpaDEwzsYgYBYggEzLXbQY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rilHIeVUjkNiIaDZxalfDAEXpeVLA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								KvldHKNwfcIavmzoNRFeKHvPjHZp();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rilHIeVUjkNiIaDZxalfDAEXpeVLA;
							PollingHelper eSmTlulgwnQUUeJuPqBInsjtPIxw = ESmTlulgwnQUUeJuPqBInsjtPIxw;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								rilHIeVUjkNiIaDZxalfDAEXpeVLA = -1;
								if (nFNEHpSdwNskLeCFXsShzBDLNNDQ < 0)
								{
									return false;
								}
								Joystick joystick = eSmTlulgwnQUUeJuPqBInsjtPIxw.YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(nFNEHpSdwNskLeCFXsShzBDLNNDQ);
								if (joystick == null)
								{
									return false;
								}
								tkjCApxNcCDbaHmYKWWOQecZqlPn = joystick.PollForAllElementsDown().GetEnumerator();
								rilHIeVUjkNiIaDZxalfDAEXpeVLA = -3;
								break;
							}
							case 1:
								rilHIeVUjkNiIaDZxalfDAEXpeVLA = -3;
								break;
							}
							if (tkjCApxNcCDbaHmYKWWOQecZqlPn.MoveNext())
							{
								ControllerPollingInfo current = tkjCApxNcCDbaHmYKWWOQecZqlPn.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = eSmTlulgwnQUUeJuPqBInsjtPIxw.MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
								bDUGOAUvcyDuJjcBBGOIKRJXyUiAA = controllerPollingInfo;
								rilHIeVUjkNiIaDZxalfDAEXpeVLA = 1;
								return true;
							}
							KvldHKNwfcIavmzoNRFeKHvPjHZp();
							tkjCApxNcCDbaHmYKWWOQecZqlPn = null;
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

					private void KvldHKNwfcIavmzoNRFeKHvPjHZp()
					{
						rilHIeVUjkNiIaDZxalfDAEXpeVLA = -1;
						if (tkjCApxNcCDbaHmYKWWOQecZqlPn != null)
						{
							tkjCApxNcCDbaHmYKWWOQecZqlPn.Dispose();
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
						OJErnfQGiMDTyjsmTHmejkTxyKap oJErnfQGiMDTyjsmTHmejkTxyKap;
						if (rilHIeVUjkNiIaDZxalfDAEXpeVLA == -2 && heohhafpaDEwzsYgYBYggEzLXbQY == Environment.CurrentManagedThreadId)
						{
							rilHIeVUjkNiIaDZxalfDAEXpeVLA = 0;
							oJErnfQGiMDTyjsmTHmejkTxyKap = this;
						}
						else
						{
							oJErnfQGiMDTyjsmTHmejkTxyKap = new OJErnfQGiMDTyjsmTHmejkTxyKap(0);
							oJErnfQGiMDTyjsmTHmejkTxyKap.ESmTlulgwnQUUeJuPqBInsjtPIxw = ESmTlulgwnQUUeJuPqBInsjtPIxw;
						}
						oJErnfQGiMDTyjsmTHmejkTxyKap.nFNEHpSdwNskLeCFXsShzBDLNNDQ = obUrBTQPOzjvTchpuLaLHwPhMGxwb;
						return oJErnfQGiMDTyjsmTHmejkTxyKap;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player MDZyTTjmQuFebBztTvNFKCiWXMjfA;

				private readonly ControllerHelper YTDdEJpsargdMhvaOWLAdQpQMXhdb;

				private readonly int PoRIbEBGzGisbZuKzLjTUmoPvaDW;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					PoRIbEBGzGisbZuKzLjTUmoPvaDW = ReInput.id;
					MDZyTTjmQuFebBztTvNFKCiWXMjfA = P_0;
					YTDdEJpsargdMhvaOWLAdQpQMXhdb = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => MhWpSGqHqybHnmdYFjKbIKZGaPsL(), 
						ControllerType.Joystick => mxnRTOZKzqvjTGiPjCoWmSkSApJv(controllerId), 
						ControllerType.Mouse => qWkFTpTannPLeGuHnxIhHDfkoqHc(), 
						ControllerType.Custom => WziNfILcxMGhVAVZuPDTXllyVzyGA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => kGYGXrmTzKoFCLhfwgMGxszBNmiU(), 
						ControllerType.Joystick => iHEGixFzPjEyPHPeDAsOasIFCJpGB(controllerId), 
						ControllerType.Mouse => LxHrIjHIQACXykddbCwDFrVcOtztA(), 
						ControllerType.Custom => SWrqGJHdNmeLgZvbWnQEqUGYmgKV(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => MhWpSGqHqybHnmdYFjKbIKZGaPsL(), 
						ControllerType.Joystick => umQgQxyfzTIYVnegOLCrmdWWNqjf(controllerId), 
						ControllerType.Mouse => JNZlOTRUkfcxOGuunfZvJjQgOORp(), 
						ControllerType.Custom => qafvbBmbEtiSKFXdxySOPKrgoyktA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => kGYGXrmTzKoFCLhfwgMGxszBNmiU(), 
						ControllerType.Joystick => cksmDCCzCKoxCnBnQjyjUmtUETTF(controllerId), 
						ControllerType.Mouse => OXUOWSacAcanoDuEMEFlBVsbghUdc(), 
						ControllerType.Custom => heqMsIQCawyWFuRmqoIcEbFkTHkK(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj(), 
						ControllerType.Joystick => QFTmHLOeeGaNhIYMcqgrabNqpZvoA(controllerId), 
						ControllerType.Mouse => OoGYIzFCrFgbBIDgDrUelhpWeOFr(), 
						ControllerType.Custom => BXzYKUTbDKnmdJskwVkYxYatmvhy(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => FtkNDRghpVERSQcNvsshepCAHmnJA(), 
						ControllerType.Joystick => pHnXEMNBgzcxfnvoTdxRMUpVhdCP(controllerId), 
						ControllerType.Mouse => YyDySmiMdzDfHFFGisjMeOqjGdVoA(), 
						ControllerType.Custom => WFgjNlMctFHQkDWDAdJogZcWgkEk(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => uxhypVtzZRQKIHlSvMkTNyeHdBvO(), 
						ControllerType.Joystick => VEvdFzUbQrDapfVBYNhxLgfklaLbA(controllerId), 
						ControllerType.Mouse => YvRxuQkdbGusXqOXwNzfeXEYsBgH(), 
						ControllerType.Custom => EEKyVbuDVdibfXdmeLIKRHhvktUE(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => FtkNDRghpVERSQcNvsshepCAHmnJA(), 
						ControllerType.Joystick => GqyHeXOGjpBydDRGguSfSqWCtMzRA(controllerId), 
						ControllerType.Mouse => DtLRfIDeYXdToCbepAjqtoRsBkNw(), 
						ControllerType.Custom => BQXzJrariAkuyCgOEJIfDyMeCzqM(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => uxhypVtzZRQKIHlSvMkTNyeHdBvO(), 
						ControllerType.Joystick => ruAUAkimriJALbWLIKaaWDtgNAtF(controllerId), 
						ControllerType.Mouse => imtvajiQuALjoVwDGpcNvggilKgS(), 
						ControllerType.Custom => SzulFsPjIxAuLKpXnEoOYwIPyWqV(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => TDAafBkWqlavrxSudKbCPicGboZrA(controllerId), 
						ControllerType.Mouse => dNpOTqxJmQbmKqnhPsDnVUbQjzKr(), 
						ControllerType.Custom => aXoyUBVBMgPEXVJPkqBPYiZRSoJH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => MhWpSGqHqybHnmdYFjKbIKZGaPsL(), 
						ControllerType.Joystick => kKDaCmRMBoqCZfgntOJUjrpvHpcH(), 
						ControllerType.Mouse => qWkFTpTannPLeGuHnxIhHDfkoqHc(), 
						ControllerType.Custom => QcMFhiMJnSjbgDTFPtQpkbWPLzbRA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => MhWpSGqHqybHnmdYFjKbIKZGaPsL(), 
						ControllerType.Joystick => slmkLsSdixotVwVUiGKnKsCHrHri(), 
						ControllerType.Mouse => JNZlOTRUkfcxOGuunfZvJjQgOORp(), 
						ControllerType.Custom => lBEPSYDeqtSTgBuzwLqFzMGxNsWr(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => kGYGXrmTzKoFCLhfwgMGxszBNmiU(), 
						ControllerType.Joystick => JpoOpoIXhdZHPYaEUGnMAPKEKAXx(), 
						ControllerType.Mouse => OXUOWSacAcanoDuEMEFlBVsbghUdc(), 
						ControllerType.Custom => MDqEySuBybbBBjLnMGfzolWyQuxcA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj(), 
						ControllerType.Joystick => DCxaZPGyxOifwCeqwOsmcIZpywRAA(), 
						ControllerType.Mouse => OoGYIzFCrFgbBIDgDrUelhpWeOFr(), 
						ControllerType.Custom => TIcBghZTWENerdacnDaNJvJgrbbF(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => FtkNDRghpVERSQcNvsshepCAHmnJA(), 
						ControllerType.Joystick => WxKEKAcfhlapSlJZtyocosBQhBdHb(), 
						ControllerType.Mouse => YyDySmiMdzDfHFFGisjMeOqjGdVoA(), 
						ControllerType.Custom => UolCoPNtIqZqfNSkGgQQgPOkcntGb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => uxhypVtzZRQKIHlSvMkTNyeHdBvO(), 
						ControllerType.Joystick => gBoKqnRyJyYAwyGZSEuXAvThpubV(), 
						ControllerType.Mouse => YvRxuQkdbGusXqOXwNzfeXEYsBgH(), 
						ControllerType.Custom => ODSPVskcCVJIXVizBNAXXbMrokJJ(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => FtkNDRghpVERSQcNvsshepCAHmnJA(), 
						ControllerType.Joystick => USrReCIDyzDDmQTgCbLdeZzOJbFW(), 
						ControllerType.Mouse => DtLRfIDeYXdToCbepAjqtoRsBkNw(), 
						ControllerType.Custom => dBwwqBJVAdRxOaajLMzZhlFQuztl(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => uxhypVtzZRQKIHlSvMkTNyeHdBvO(), 
						ControllerType.Joystick => sTkrQeKqwgNuLPBdtSUSZMnKdePd(), 
						ControllerType.Mouse => imtvajiQuALjoVwDGpcNvggilKgS(), 
						ControllerType.Custom => MfSeKGhMSnviYqDKhjmZYDsIOHrU(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != PoRIbEBGzGisbZuKzLjTUmoPvaDW)
					{
						ReInput.CheckInitialized(PoRIbEBGzGisbZuKzLjTUmoPvaDW);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => vOFwOepEUwODhtkduFzrQTfnRGnu(), 
						ControllerType.Mouse => dNpOTqxJmQbmKqnhPsDnVUbQjzKr(), 
						ControllerType.Custom => ColMzOQkoBCjuIIhrFenviLYXetM(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo mxnRTOZKzqvjTGiPjCoWmSkSApJv(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					Joystick joystick = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo iHEGixFzPjEyPHPeDAsOasIFCJpGB(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					Joystick joystick = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo umQgQxyfzTIYVnegOLCrmdWWNqjf(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					Joystick joystick = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo cksmDCCzCKoxCnBnQjyjUmtUETTF(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					Joystick joystick = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo QFTmHLOeeGaNhIYMcqgrabNqpZvoA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					Joystick joystick = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				[IteratorStateMachine(typeof(ViCdqwhJcQljtaIONUbiAFiojVWBA))]
				private IEnumerable<ControllerPollingInfo> pHnXEMNBgzcxfnvoTdxRMUpVhdCP(int P_0)
				{
					return new ViCdqwhJcQljtaIONUbiAFiojVWBA(-2)
					{
						klzpeangbwwiHuavnNPafRLazWui = this,
						DfMLXxXDYLgrlIqSpXTGUGflkmAlA = P_0
					};
				}

				[IteratorStateMachine(typeof(OJErnfQGiMDTyjsmTHmejkTxyKap))]
				private IEnumerable<ControllerPollingInfo> VEvdFzUbQrDapfVBYNhxLgfklaLbA(int P_0)
				{
					return new OJErnfQGiMDTyjsmTHmejkTxyKap(-2)
					{
						ESmTlulgwnQUUeJuPqBInsjtPIxw = this,
						obUrBTQPOzjvTchpuLaLHwPhMGxwb = P_0
					};
				}

				[IteratorStateMachine(typeof(YncpHQYIakdyycWBuURZZmwWYwDA))]
				private IEnumerable<ControllerPollingInfo> GqyHeXOGjpBydDRGguSfSqWCtMzRA(int P_0)
				{
					return new YncpHQYIakdyycWBuURZZmwWYwDA(-2)
					{
						RwUfQRIolYxkyhzttcUtDNIFUxNtA = this,
						vakPkfuUPOfoGfNAgftwTAaEdQny = P_0
					};
				}

				[IteratorStateMachine(typeof(brtPoWkkTcakbHkaPgwbpKnNlwbo))]
				private IEnumerable<ControllerPollingInfo> ruAUAkimriJALbWLIKaaWDtgNAtF(int P_0)
				{
					return new brtPoWkkTcakbHkaPgwbpKnNlwbo(-2)
					{
						BMrxDcZbDWcVQZJXGreNgNlPiWPf = this,
						ZdKYGUDMQgxVoRdFFlqOpZpwcsdv = P_0
					};
				}

				[IteratorStateMachine(typeof(BskZhPcoBbQubrmzIRvRgwxfDOnr))]
				private IEnumerable<ControllerPollingInfo> TDAafBkWqlavrxSudKbCPicGboZrA(int P_0)
				{
					return new BskZhPcoBbQubrmzIRvRgwxfDOnr(-2)
					{
						amnAWPuvKuiWrUhNUHWKKSidiNQHA = this,
						fUEgZnWIbKbrbdrnkQBVGvFSLsehA = P_0
					};
				}

				private ControllerPollingInfo kKDaCmRMBoqCZfgntOJUjrpvHpcH()
				{
					IList<Joystick> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo XjNCKtJmlaDsbaLicUzFlXxAMHAJ()
				{
					IList<Joystick> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo slmkLsSdixotVwVUiGKnKsCHrHri()
				{
					IList<Joystick> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo JpoOpoIXhdZHPYaEUGnMAPKEKAXx()
				{
					IList<Joystick> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo DCxaZPGyxOifwCeqwOsmcIZpywRAA()
				{
					IList<Joystick> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.RerutvSyIzmYQSLwpqAVLQqcJZSb.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				[IteratorStateMachine(typeof(mIWsFhkziJhVFmAMQNjlmDohLRTd))]
				private IEnumerable<ControllerPollingInfo> WxKEKAcfhlapSlJZtyocosBQhBdHb()
				{
					return new mIWsFhkziJhVFmAMQNjlmDohLRTd(-2)
					{
						mtaKrmqEOkTkxKqUuIENKDTdgzdB = this
					};
				}

				[IteratorStateMachine(typeof(UjelPBhEGmoxMFVwvfumeSpUoDUc))]
				private IEnumerable<ControllerPollingInfo> gBoKqnRyJyYAwyGZSEuXAvThpubV()
				{
					return new UjelPBhEGmoxMFVwvfumeSpUoDUc(-2)
					{
						MIWoZKpNXftDmodkiBFUiCDObeyc = this
					};
				}

				[IteratorStateMachine(typeof(xCHTAtDmmHKXyjuKTLbGZyhkFThw))]
				private IEnumerable<ControllerPollingInfo> USrReCIDyzDDmQTgCbLdeZzOJbFW()
				{
					return new xCHTAtDmmHKXyjuKTLbGZyhkFThw(-2)
					{
						KuGoPBEiHqgxXEMlMClFHtRIiAIl = this
					};
				}

				[IteratorStateMachine(typeof(UUTZSfGqJEqLPZkVirnxHibKcKmeA))]
				private IEnumerable<ControllerPollingInfo> sTkrQeKqwgNuLPBdtSUSZMnKdePd()
				{
					return new UUTZSfGqJEqLPZkVirnxHibKcKmeA(-2)
					{
						SzSeqaXKDBPJgQQhdBgjyuueSIBQ = this
					};
				}

				[IteratorStateMachine(typeof(PDdYHJlNacCnCdnuJaRqgTABvUOtB))]
				private IEnumerable<ControllerPollingInfo> vOFwOepEUwODhtkduFzrQTfnRGnu()
				{
					return new PDdYHJlNacCnCdnuJaRqgTABvUOtB(-2)
					{
						cPedKZHoGxTvjAAhRJQEjZZEzozOA = this
					};
				}

				private ControllerPollingInfo MhWpSGqHqybHnmdYFjKbIKZGaPsL()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.hbdpHKaWlaczISAqKemTfyDarQjwA)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo kGYGXrmTzKoFCLhfwgMGxszBNmiU()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.hbdpHKaWlaczISAqKemTfyDarQjwA)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> FtkNDRghpVERSQcNvsshepCAHmnJA()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.hbdpHKaWlaczISAqKemTfyDarQjwA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> uxhypVtzZRQKIHlSvMkTNyeHdBvO()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.hbdpHKaWlaczISAqKemTfyDarQjwA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo qWkFTpTannPLeGuHnxIhHDfkoqHc()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo LxHrIjHIQACXykddbCwDFrVcOtztA()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo JNZlOTRUkfcxOGuunfZvJjQgOORp()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo OXUOWSacAcanoDuEMEFlBVsbghUdc()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo OoGYIzFCrFgbBIDgDrUelhpWeOFr()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> YyDySmiMdzDfHFFGisjMeOqjGdVoA()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> YvRxuQkdbGusXqOXwNzfeXEYsBgH()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> DtLRfIDeYXdToCbepAjqtoRsBkNw()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> imtvajiQuALjoVwDGpcNvggilKgS()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> dNpOTqxJmQbmKqnhPsDnVUbQjzKr()
				{
					if (!YTDdEJpsargdMhvaOWLAdQpQMXhdb.DEWennYbaKFDGoKNyRcStBbtPjpX)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return YTDdEJpsargdMhvaOWLAdQpQMXhdb.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo WziNfILcxMGhVAVZuPDTXllyVzyGA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					CustomController customController = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo SWrqGJHdNmeLgZvbWnQEqUGYmgKV(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					CustomController customController = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo qafvbBmbEtiSKFXdxySOPKrgoyktA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					CustomController customController = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo heqMsIQCawyWFuRmqoIcEbFkTHkK(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					CustomController customController = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				private ControllerPollingInfo BXzYKUTbDKnmdJskwVkYxYatmvhy(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					CustomController customController = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.qFpfRnHQpApgQCDpHUWhKxHZUwbYA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
					}
					return result;
				}

				[IteratorStateMachine(typeof(yxAzWJhKaGgXWALidnLukiAjeIfk))]
				private IEnumerable<ControllerPollingInfo> WFgjNlMctFHQkDWDAdJogZcWgkEk(int P_0)
				{
					return new yxAzWJhKaGgXWALidnLukiAjeIfk(-2)
					{
						iauAZEwVTatNrJVZCssfpUpagDQE = this,
						CatvDCqWpcVFptBIDgQiLHVbCRyx = P_0
					};
				}

				[IteratorStateMachine(typeof(zSJDdNjHInyKmWLAJdRDMYDgolWlA))]
				private IEnumerable<ControllerPollingInfo> EEKyVbuDVdibfXdmeLIKRHhvktUE(int P_0)
				{
					return new zSJDdNjHInyKmWLAJdRDMYDgolWlA(-2)
					{
						gMyktrVgpELyFYWfqURrcAmILWzQ = this,
						fsXlsDEzSjeKwdjlTdASIJIPLEnp = P_0
					};
				}

				[IteratorStateMachine(typeof(HWsAwQkwfbrbBiMawvQYHhNrbxRX))]
				private IEnumerable<ControllerPollingInfo> BQXzJrariAkuyCgOEJIfDyMeCzqM(int P_0)
				{
					return new HWsAwQkwfbrbBiMawvQYHhNrbxRX(-2)
					{
						riAIeepAJuJaTGDhNAlxayWQxzku = this,
						xUTwFrdoApSSgCejnWOoeGlKnBUC = P_0
					};
				}

				[IteratorStateMachine(typeof(qHTGKmkFxgUiHQGFFUsoNNpqOENIA))]
				private IEnumerable<ControllerPollingInfo> SzulFsPjIxAuLKpXnEoOYwIPyWqV(int P_0)
				{
					return new qHTGKmkFxgUiHQGFFUsoNNpqOENIA(-2)
					{
						yclsgFTvvpVcGZFzNwjyAunNzXoc = this,
						qbaKNjhPDZAMjkaYdttRanVmYoMpA = P_0
					};
				}

				[IteratorStateMachine(typeof(fdaJLRBbmMoBvZyaZGRzptygDEZiA))]
				private IEnumerable<ControllerPollingInfo> aXoyUBVBMgPEXVJPkqBPYiZRSoJH(int P_0)
				{
					return new fdaJLRBbmMoBvZyaZGRzptygDEZiA(-2)
					{
						FGZtzxjVTKspKRcjrhARhpiUOZHyA = this,
						ZIlCJBbiVengKoouzazYZpzTrvOw = P_0
					};
				}

				private ControllerPollingInfo QcMFhiMJnSjbgDTFPtQpkbWPLzbRA()
				{
					IList<CustomController> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo uTnMOKaGNnclEGXkyeaViCQCpBhq()
				{
					IList<CustomController> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo lBEPSYDeqtSTgBuzwLqFzMGxNsWr()
				{
					IList<CustomController> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo MDqEySuBybbBBjLnMGfzolWyQuxcA()
				{
					IList<CustomController> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo TIcBghZTWENerdacnDaNJvJgrbbF()
				{
					IList<CustomController> list = YTDdEJpsargdMhvaOWLAdQpQMXhdb.uMUnplavNfXyyPpjOLeReTgUViSF.ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = MDZyTTjmQuFebBztTvNFKCiWXMjfA.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				[IteratorStateMachine(typeof(YwpGGMuJhdZWfNedrCDYTayMrTYN))]
				private IEnumerable<ControllerPollingInfo> UolCoPNtIqZqfNSkGgQQgPOkcntGb()
				{
					return new YwpGGMuJhdZWfNedrCDYTayMrTYN(-2)
					{
						uOxTLXlKXsfPMgyQSYJYeYkSibPF = this
					};
				}

				[IteratorStateMachine(typeof(RXFEjYBNWdbgUzOgxBpqKmPAgOxab))]
				private IEnumerable<ControllerPollingInfo> ODSPVskcCVJIXVizBNAXXbMrokJJ()
				{
					return new RXFEjYBNWdbgUzOgxBpqKmPAgOxab(-2)
					{
						mbKGipiuzcxKQqSFHOhSOmBgkzFO = this
					};
				}

				[IteratorStateMachine(typeof(wpxadSkFopCfHiqvGRdjzpflvzcPb))]
				private IEnumerable<ControllerPollingInfo> dBwwqBJVAdRxOaajLMzZhlFQuztl()
				{
					return new wpxadSkFopCfHiqvGRdjzpflvzcPb(-2)
					{
						qKYmyizgWbhqoqkmRvniiOjKofAr = this
					};
				}

				[IteratorStateMachine(typeof(lIDfkQuQogleJMCdSUPpwPiIXrBb))]
				private IEnumerable<ControllerPollingInfo> MfSeKGhMSnviYqDKhjmZYDsIOHrU()
				{
					return new lIDfkQuQogleJMCdSUPpwPiIXrBb(-2)
					{
						dpVmIVcgouxAbTxcyMHiwdLXUeQt = this
					};
				}

				[IteratorStateMachine(typeof(KzYWgNSoqBlkxIVIEvtpwkKgcAqT))]
				private IEnumerable<ControllerPollingInfo> ColMzOQkoBCjuIIhrFenviLYXetM()
				{
					return new KzYWgNSoqBlkxIVIEvtpwkKgcAqT(-2)
					{
						gJjqOEOMsUSAhxSNWfoBWsQmSUhF = this
					};
				}
			}

			[Serializable]
			private sealed class mEDFantSXxJujKQTZGMYMOEaiqij
			{
				public static readonly mEDFantSXxJujKQTZGMYMOEaiqij _003C_003E9 = new mEDFantSXxJujKQTZGMYMOEaiqij();

				public static Action<Exception> _003C_003E9__23_0;

				public static Action<Exception> _003C_003E9__23_1;

				internal void mAVfjRudOzIqLjvJzjTkXiCppSbJA(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void uaOyWnOWlCnEBaaceEdgVwzYXNSN(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class ovKkBbCCPVNppQlPqISpkWgyRVxHA : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
			{
				private int nLlEbbhkGsbUkAOFHsYlACYFENuQc;

				private Controller tqqOLmexJybInBnkgWcsqIcbjFwo;

				private int QLLuTKiglEUqiifkAtgQvwjIUuTm;

				public ControllerHelper RxgqDuCyiqADTSXTGsGLsTIYGRwg;

				private int YsgcQtUoBHMNRgxyraZTsuzMkQht;

				private IList<Joystick> CGidlxIPyQhEeYtjlPLTEgtuWmljA;

				private int VQPuwMwBMZCGdPgutRLfGnnmcaaT;

				private IList<CustomController> VxfClOFmnfJGnXITVFaiNTcTLtxJ;

				private int RuSNBvsaVAAwBZdhtvGQYjsWRXwt;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return tqqOLmexJybInBnkgWcsqIcbjFwo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return tqqOLmexJybInBnkgWcsqIcbjFwo;
					}
				}

				[DebuggerHidden]
				public ovKkBbCCPVNppQlPqISpkWgyRVxHA(int P_0)
				{
					nLlEbbhkGsbUkAOFHsYlACYFENuQc = P_0;
					QLLuTKiglEUqiifkAtgQvwjIUuTm = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = nLlEbbhkGsbUkAOFHsYlACYFENuQc;
					ControllerHelper rxgqDuCyiqADTSXTGsGLsTIYGRwg = RxgqDuCyiqADTSXTGsGLsTIYGRwg;
					switch (num)
					{
					default:
						return false;
					case 0:
						nLlEbbhkGsbUkAOFHsYlACYFENuQc = -1;
						if (ReInput._id != rxgqDuCyiqADTSXTGsGLsTIYGRwg.QXliPddRsqGrAgbrzwixartFsKeRA)
						{
							ReInput.CheckInitialized(rxgqDuCyiqADTSXTGsGLsTIYGRwg.QXliPddRsqGrAgbrzwixartFsKeRA);
							return false;
						}
						if (rxgqDuCyiqADTSXTGsGLsTIYGRwg.DEWennYbaKFDGoKNyRcStBbtPjpX)
						{
							tqqOLmexJybInBnkgWcsqIcbjFwo = rxgqDuCyiqADTSXTGsGLsTIYGRwg.Mouse;
							nLlEbbhkGsbUkAOFHsYlACYFENuQc = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						nLlEbbhkGsbUkAOFHsYlACYFENuQc = -1;
						goto IL_0070;
					case 2:
						nLlEbbhkGsbUkAOFHsYlACYFENuQc = -1;
						goto IL_0094;
					case 3:
						nLlEbbhkGsbUkAOFHsYlACYFENuQc = -1;
						RuSNBvsaVAAwBZdhtvGQYjsWRXwt++;
						goto IL_00ec;
					case 4:
						{
							nLlEbbhkGsbUkAOFHsYlACYFENuQc = -1;
							RuSNBvsaVAAwBZdhtvGQYjsWRXwt++;
							break;
						}
						IL_0094:
						YsgcQtUoBHMNRgxyraZTsuzMkQht = rxgqDuCyiqADTSXTGsGLsTIYGRwg.joystickCount;
						CGidlxIPyQhEeYtjlPLTEgtuWmljA = rxgqDuCyiqADTSXTGsGLsTIYGRwg.Joysticks;
						RuSNBvsaVAAwBZdhtvGQYjsWRXwt = 0;
						goto IL_00ec;
						IL_00ec:
						if (RuSNBvsaVAAwBZdhtvGQYjsWRXwt < YsgcQtUoBHMNRgxyraZTsuzMkQht)
						{
							tqqOLmexJybInBnkgWcsqIcbjFwo = CGidlxIPyQhEeYtjlPLTEgtuWmljA[RuSNBvsaVAAwBZdhtvGQYjsWRXwt];
							nLlEbbhkGsbUkAOFHsYlACYFENuQc = 3;
							return true;
						}
						VQPuwMwBMZCGdPgutRLfGnnmcaaT = rxgqDuCyiqADTSXTGsGLsTIYGRwg.customControllerCount;
						VxfClOFmnfJGnXITVFaiNTcTLtxJ = rxgqDuCyiqADTSXTGsGLsTIYGRwg.CustomControllers;
						RuSNBvsaVAAwBZdhtvGQYjsWRXwt = 0;
						break;
						IL_0070:
						if (rxgqDuCyiqADTSXTGsGLsTIYGRwg.hbdpHKaWlaczISAqKemTfyDarQjwA)
						{
							tqqOLmexJybInBnkgWcsqIcbjFwo = rxgqDuCyiqADTSXTGsGLsTIYGRwg.Keyboard;
							nLlEbbhkGsbUkAOFHsYlACYFENuQc = 2;
							return true;
						}
						goto IL_0094;
					}
					if (RuSNBvsaVAAwBZdhtvGQYjsWRXwt < VQPuwMwBMZCGdPgutRLfGnnmcaaT)
					{
						tqqOLmexJybInBnkgWcsqIcbjFwo = VxfClOFmnfJGnXITVFaiNTcTLtxJ[RuSNBvsaVAAwBZdhtvGQYjsWRXwt];
						nLlEbbhkGsbUkAOFHsYlACYFENuQc = 4;
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
					ovKkBbCCPVNppQlPqISpkWgyRVxHA ovKkBbCCPVNppQlPqISpkWgyRVxHA2;
					if (nLlEbbhkGsbUkAOFHsYlACYFENuQc == -2 && QLLuTKiglEUqiifkAtgQvwjIUuTm == Environment.CurrentManagedThreadId)
					{
						nLlEbbhkGsbUkAOFHsYlACYFENuQc = 0;
						ovKkBbCCPVNppQlPqISpkWgyRVxHA2 = this;
					}
					else
					{
						ovKkBbCCPVNppQlPqISpkWgyRVxHA2 = new ovKkBbCCPVNppQlPqISpkWgyRVxHA(0);
						ovKkBbCCPVNppQlPqISpkWgyRVxHA2.RxgqDuCyiqADTSXTGsGLsTIYGRwg = RxgqDuCyiqADTSXTGsGLsTIYGRwg;
					}
					return ovKkBbCCPVNppQlPqISpkWgyRVxHA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly dOKBRfwFUAFZTvAdwxGpaPOGhqvv uueNAgsGPvZIbkSfUpRlQGRqFBScA;

			private bool DEWennYbaKFDGoKNyRcStBbtPjpX;

			private bool hbdpHKaWlaczISAqKemTfyDarQjwA;

			private bool DXcSInMbvVPpOuddmcAyGgzqIxCHA;

			private double yntgvobaAgCtnxhMMKXhfhosgatFA;

			private double ctshoABSQYLnrZUoxUemtaVlzArj;

			private SafeAction<ControllerAssignmentChangedEventArgs> jNlEgzJDpWIjbvlRbEiWhkxATHbAA = new SafeAction<ControllerAssignmentChangedEventArgs>(mEDFantSXxJujKQTZGMYMOEaiqij._003C_003E9.mAVfjRudOzIqLjvJzjTkXiCppSbJA);

			private SafeAction<ControllerAssignmentChangedEventArgs> PEzcbxltXlprwsufmUKPmweURhRc = new SafeAction<ControllerAssignmentChangedEventArgs>(mEDFantSXxJujKQTZGMYMOEaiqij._003C_003E9.uaOyWnOWlCnEBaaceEdgVwzYXNSN);

			private readonly yWllGWQoPyFKMJvrPnBBdNNybQBW TYovfIszswbQEXSvpewkGghabwKZ;

			private readonly Player JNGEYREZFAlJODwlkiADqvRbVgQF;

			private readonly HiQYFvQnIapBdxxovqraTdXiGgLw oVUFnIGXidUDJSaOsJzspRydYRQo;

			private readonly int QXliPddRsqGrAgbrzwixartFsKeRA;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap> RerutvSyIzmYQSLwpqAVLQqcJZSb => (fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick);

			private global::FarFCHilnTaPUOHyjpIPWUDENJjC<KeyboardMap> UEapLssqzvVHusFKsJEzKqHBIQeF => (global::FarFCHilnTaPUOHyjpIPWUDENJjC<KeyboardMap>)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Keyboard).iueOmjDBOlDOqNGYWGAHBWIslogRA(0).YjPKnaUBIafYYbhEPJJXDUgXqwPK;

			private global::FarFCHilnTaPUOHyjpIPWUDENJjC<MouseMap> rsfXuEglhaAlYArNLwHffqTDozVo => (global::FarFCHilnTaPUOHyjpIPWUDENJjC<MouseMap>)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Mouse).iueOmjDBOlDOqNGYWGAHBWIslogRA(0).YjPKnaUBIafYYbhEPJJXDUgXqwPK;

			private fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap> uMUnplavNfXyyPpjOLeReTgUViSF => (fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return false;
					}
					return DEWennYbaKFDGoKNyRcStBbtPjpX;
				}
				set
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						if (DEWennYbaKFDGoKNyRcStBbtPjpX == value)
						{
							return;
						}
						DEWennYbaKFDGoKNyRcStBbtPjpX = value;
						if (value)
						{
							oVUFnIGXidUDJSaOsJzspRydYRQo.nfEkqZqZRNUInmTJUkYYXDLywkdD(Mouse);
						}
						else
						{
							oVUFnIGXidUDJSaOsJzspRydYRQo.IlxVkhbJblcRsHURxmeSjqVJSnQRA(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Count > 0)
							{
								jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (PEzcbxltXlprwsufmUKPmweURhRc.Count > 0)
						{
							PEzcbxltXlprwsufmUKPmweURhRc.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return false;
					}
					return hbdpHKaWlaczISAqKemTfyDarQjwA;
				}
				set
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						if (hbdpHKaWlaczISAqKemTfyDarQjwA == value)
						{
							return;
						}
						hbdpHKaWlaczISAqKemTfyDarQjwA = value;
						if (value)
						{
							oVUFnIGXidUDJSaOsJzspRydYRQo.nfEkqZqZRNUInmTJUkYYXDLywkdD(Keyboard);
						}
						else
						{
							oVUFnIGXidUDJSaOsJzspRydYRQo.IlxVkhbJblcRsHURxmeSjqVJSnQRA(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Count > 0)
							{
								jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (PEzcbxltXlprwsufmUKPmweURhRc.Count > 0)
						{
							PEzcbxltXlprwsufmUKPmweURhRc.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return false;
					}
					return DXcSInMbvVPpOuddmcAyGgzqIxCHA;
				}
				set
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						DXcSInMbvVPpOuddmcAyGgzqIxCHA = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return 0;
					}
					return uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick).flFZvPVsPcNnBeWIGSaTgKMcStvJ;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick) as fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>).ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return 0;
					}
					return uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom).flFZvPVsPcNnBeWIGSaTgKMcStvJ;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom) as fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>).ZiXPUFLXNqwSVjqWhnioHgxwxwAp;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				[IteratorStateMachine(typeof(ovKkBbCCPVNppQlPqISpkWgyRVxHA))]
				get
				{
					return new ovKkBbCCPVNppQlPqISpkWgyRVxHA(-2)
					{
						RxgqDuCyiqADTSXTGsGLsTIYGRwg = this
					};
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					jNlEgzJDpWIjbvlRbEiWhkxATHbAA.AddDelegate(value);
				}
				remove
				{
					jNlEgzJDpWIjbvlRbEiWhkxATHbAA.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					PEzcbxltXlprwsufmUKPmweURhRc.AddDelegate(value);
				}
				remove
				{
					PEzcbxltXlprwsufmUKPmweURhRc.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, GdOldZdkCaFseCtTjjUkzAqYRXRaA P_1, ControllerMapLayoutManager.SLxTBaXfrhZCyLfCEqNyvKbuXYzr P_2, ControllerMapEnabler.MpLdxmCiVDCEhjPNCfTXmDrkNyfGc P_3)
			{
				QXliPddRsqGrAgbrzwixartFsKeRA = ReInput.id;
				JNGEYREZFAlJODwlkiADqvRbVgQF = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				uueNAgsGPvZIbkSfUpRlQGRqFBScA = new dOKBRfwFUAFZTvAdwxGpaPOGhqvv(4);
				uueNAgsGPvZIbkSfUpRlQGRqFBScA.EVIMNCRYSOPVVpSUlmkTJFyiCntt(0, ControllerType.Joystick, new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>());
				uueNAgsGPvZIbkSfUpRlQGRqFBScA.EVIMNCRYSOPVVpSUlmkTJFyiCntt(1, ControllerType.Keyboard, new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Keyboard, KeyboardMap>());
				uueNAgsGPvZIbkSfUpRlQGRqFBScA.EVIMNCRYSOPVVpSUlmkTJFyiCntt(2, ControllerType.Mouse, new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Mouse, MouseMap>());
				uueNAgsGPvZIbkSfUpRlQGRqFBScA.EVIMNCRYSOPVVpSUlmkTJFyiCntt(3, ControllerType.Custom, new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>());
				TYovfIszswbQEXSvpewkGghabwKZ = new yWllGWQoPyFKMJvrPnBBdNNybQBW(P_0);
				oVUFnIGXidUDJSaOsJzspRydYRQo = new HiQYFvQnIapBdxxovqraTdXiGgLw(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				return (T)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(moNrVnhMyxFSevnVWYTclYHmdtVI.kdWDDQlNysyeMSiTdEzmUlUWJJKf<T>()).fTvKlfcMwIZxZSoxSPJHwjMOhRgkA(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				return uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType).fTvKlfcMwIZxZSoxSPJHwjMOhRgkA(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				return (T)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(moNrVnhMyxFSevnVWYTclYHmdtVI.kdWDDQlNysyeMSiTdEzmUlUWJJKf<T>()).orcFyEysCJMuBrOvToMRIdIWcfMEA(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				return uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(controllerType).orcFyEysCJMuBrOvToMRIdIWcfMEA(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					NxToYrFaAjvunmRZcnqQQpdGbnBCA(controllerId, removeFromOtherPlayers);
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
					oNqPgNWjuapcrhhNOagTNRoneEaFA(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						tBeKinwvFPvMaGNohApbTvgJUcRe(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						mIQtmapFJfJNDwyvlheTDcPDoEPp(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					tBeKinwvFPvMaGNohApbTvgJUcRe(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
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
					mIQtmapFJfJNDwyvlheTDcPDoEPp(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					tCZcInyidnblUKepOHVREAbyiuIfA(controllerId);
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
					HhWiUUFfiCIxrfSIRuPpPlstScLVA(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					tCZcInyidnblUKepOHVREAbyiuIfA(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					HhWiUUFfiCIxrfSIRuPpPlstScLVA(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						WoLyvxVxaOGmOayuVloVBsbYBYst(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						epoFkErIWYIJNhGbsqhnmLswvJCc(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return hbdpHKaWlaczISAqKemTfyDarQjwA;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return DEWennYbaKFDGoKNyRcStBbtPjpX;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick).GRMIiFyjqWcQFahZLMeaEplJYumtB(controllerId), 
					ControllerType.Keyboard => hbdpHKaWlaczISAqKemTfyDarQjwA, 
					ControllerType.Mouse => DEWennYbaKFDGoKNyRcStBbtPjpX, 
					ControllerType.Custom => uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom).GRMIiFyjqWcQFahZLMeaEplJYumtB(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
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
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					XKRMDhddktXnBUdZTskcaoKNZdik();
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
					iZRuvIhVfXWANnPfzfaLYnqkhGWg();
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
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					XKRMDhddktXnBUdZTskcaoKNZdik();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					iZRuvIhVfXWANnPfzfaLYnqkhGWg();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return;
				}
				XKRMDhddktXnBUdZTskcaoKNZdik();
				iZRuvIhVfXWANnPfzfaLYnqkhGWg();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				jcGMOgvIKnTjHhTjsdplmAjQXstk(ControllerType.Joystick, ref result, ref num);
				if (DEWennYbaKFDGoKNyRcStBbtPjpX && yntgvobaAgCtnxhMMKXhfhosgatFA > num)
				{
					result = Mouse;
					num = yntgvobaAgCtnxhMMKXhfhosgatFA;
				}
				if (hbdpHKaWlaczISAqKemTfyDarQjwA && ctshoABSQYLnrZUoxUemtaVlzArj > num)
				{
					result = Keyboard;
					num = ctshoABSQYLnrZUoxUemtaVlzArj;
				}
				jcGMOgvIKnTjHhTjsdplmAjQXstk(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					jcGMOgvIKnTjHhTjsdplmAjQXstk(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (hbdpHKaWlaczISAqKemTfyDarQjwA && ctshoABSQYLnrZUoxUemtaVlzArj > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (DEWennYbaKFDGoKNyRcStBbtPjpX && yntgvobaAgCtnxhMMKXhfhosgatFA > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void jcGMOgvIKnTjHhTjsdplmAjQXstk(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
				int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ;
				for (int i = 0; i < num; i++)
				{
					double num2 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).YqUvlKjdcOagFIswNEKIDRXForJxb;
					if (!(num2 <= P_2))
					{
						P_1 = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(i).LEdXAULnordCtHuhKNePXQiSgnCX;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(moNrVnhMyxFSevnVWYTclYHmdtVI.kdWDDQlNysyeMSiTdEzmUlUWJJKf<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						JNGEYREZFAlJODwlkiADqvRbVgQF.FLHSwBondVMFwICiFrRDNPxufqTW.WHxQayJoxWPGeZgfWCstmflFmniR(JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						JNGEYREZFAlJODwlkiADqvRbVgQF.FLHSwBondVMFwICiFrRDNPxufqTW.lNYGIccFnSFTrbWRgkerIENoLXgeb(JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						JNGEYREZFAlJODwlkiADqvRbVgQF.FLHSwBondVMFwICiFrRDNPxufqTW.DuugnkzhmgEPrLsqYFfQuwBttzVg(JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						JNGEYREZFAlJODwlkiADqvRbVgQF.FLHSwBondVMFwICiFrRDNPxufqTW.JtrEzIbGFDmvrQtizjzHdSFYwexHA(JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
					{
						ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					}
					else
					{
						JNGEYREZFAlJODwlkiADqvRbVgQF.FLHSwBondVMFwICiFrRDNPxufqTW.UiaCMZGsFEpDxRjjqLReaFhELLyIb(JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
				for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
				{
					Controller controller = fxgGKzxoaHChRtnnnXSCFMKyeCgt(uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i).MpzowibvORwAEjBGqRZIiSHQOVec, Controller.FWQwaXBZWWFHHutFHVaGHadmFoHn, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return null;
				}
				int qQKAnjIDCwrNyABAEPmVWZtlKjkKc = uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc;
				for (int i = 0; i < qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
				{
					Controller controller = fxgGKzxoaHChRtnnnXSCFMKyeCgt(uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i).MpzowibvORwAEjBGqRZIiSHQOVec, Controller.qcOmCOCGqkBlTdkUaWfuGplhrPeP, templateType);
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
				if (ReInput._id != QXliPddRsqGrAgbrzwixartFsKeRA)
				{
					ReInput.CheckInitialized(QXliPddRsqGrAgbrzwixartFsKeRA);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return oVUFnIGXidUDJSaOsJzspRydYRQo.HAdedHyoXZKkmMTAwgYAQrwqrIeW<TInterface>();
			}

			private Controller fxgGKzxoaHChRtnnnXSCFMKyeCgt<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
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
					if (hbdpHKaWlaczISAqKemTfyDarQjwA && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (DEWennYbaKFDGoKNyRcStBbtPjpX && P_1(Mouse, P_2))
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

			internal void YHytikfuunkpDEZrfMVolDcriDeK()
			{
				for (int i = 0; i < uueNAgsGPvZIbkSfUpRlQGRqFBScA.qQKAnjIDCwrNyABAEPmVWZtlKjkKc; i++)
				{
					uueNAgsGPvZIbkSfUpRlQGRqFBScA.iFkHZDHCCVPAOUDYaCFscxifVwhzB(i).kAZHRZGWBRTUOiPyceAuqAENqxgtA();
				}
				uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Keyboard).QyjajlnRkTYODzAYNObNbrAGHPN(new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Keyboard, KeyboardMap>.wwphrnUdZYgdrhKBPyggpYmosQFH(ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.DgfFcsFEypGvKCatIhkeSdaWtzwHc, new global::FarFCHilnTaPUOHyjpIPWUDENJjC<KeyboardMap>(0)));
				uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Mouse).QyjajlnRkTYODzAYNObNbrAGHPN(new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Mouse, MouseMap>.wwphrnUdZYgdrhKBPyggpYmosQFH(ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.DSSddfFhMNEuZUeDpMEBaimidxHxB, new global::FarFCHilnTaPUOHyjpIPWUDENJjC<MouseMap>(0)));
				TYovfIszswbQEXSvpewkGghabwKZ.CIKhLotFEloHxeXaEHnWWrcoXigg();
				ctshoABSQYLnrZUoxUemtaVlzArj = 0.0;
				yntgvobaAgCtnxhMMKXhfhosgatFA = 0.0;
				maps.BXiYNfMaEPvMTElbKtmrlYRmEmKk();
			}

			internal double ijaPyyBveGpVMOkFGIzUmWbzjqhgA(int P_0)
			{
				return TYovfIszswbQEXSvpewkGghabwKZ.LNWTOyVdpvmbdZHTOelMXotPbIZCA(P_0)?.uVOYzEyfCFyDpJCynEYqEsDaFYjB ?? (-1.0);
			}

			internal void tBeKinwvFPvMaGNohApbTvgJUcRe(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick);
				if (jpRWCWnSWjIHbShgmaKtrbKdevFr2.GRMIiFyjqWcQFahZLMeaEplJYumtB(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				yWllGWQoPyFKMJvrPnBBdNNybQBW.YeqQXpXjuyYaOpdrgiOMyCqvDbkGA yeqQXpXjuyYaOpdrgiOMyCqvDbkGA = TYovfIszswbQEXSvpewkGghabwKZ.LNWTOyVdpvmbdZHTOelMXotPbIZCA(P_0.id);
				fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH wwphrnUdZYgdrhKBPyggpYmosQFH;
				if (yeqQXpXjuyYaOpdrgiOMyCqvDbkGA != null && yeqQXpXjuyYaOpdrgiOMyCqvDbkGA.BPxFSLqVTGkaeMfHuAzHETrFbjbNA != null)
				{
					wwphrnUdZYgdrhKBPyggpYmosQFH = new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH(P_0, yeqQXpXjuyYaOpdrgiOMyCqvDbkGA.BPxFSLqVTGkaeMfHuAzHETrFbjbNA);
				}
				else
				{
					global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap> farFCHilnTaPUOHyjpIPWUDENJjC = maps.FyAvHiSptgydrMEFzIZcIrdjmWQp(P_0, true);
					if (farFCHilnTaPUOHyjpIPWUDENJjC == null)
					{
						farFCHilnTaPUOHyjpIPWUDENJjC = new global::FarFCHilnTaPUOHyjpIPWUDENJjC<JoystickMap>(P_0.id);
					}
					wwphrnUdZYgdrhKBPyggpYmosQFH = new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH(P_0, farFCHilnTaPUOHyjpIPWUDENJjC);
				}
				jpRWCWnSWjIHbShgmaKtrbKdevFr2.QyjajlnRkTYODzAYNObNbrAGHPN(wwphrnUdZYgdrhKBPyggpYmosQFH);
				TYovfIszswbQEXSvpewkGghabwKZ.WUuGYgoRoIjAECEpfGbEYErcjygAA(wwphrnUdZYgdrhKBPyggpYmosQFH);
				oVUFnIGXidUDJSaOsJzspRydYRQo.nfEkqZqZRNUInmTJUkYYXDLywkdD(P_0);
				maps.layoutManager.Apply();
				if (jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Count > 0)
				{
					jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void NxToYrFaAjvunmRZcnqQQpdGbnBCA(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					tBeKinwvFPvMaGNohApbTvgJUcRe(joystick, P_1);
				}
			}

			internal void tCZcInyidnblUKepOHVREAbyiuIfA(int P_0)
			{
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick);
				if (jpRWCWnSWjIHbShgmaKtrbKdevFr2.GRMIiFyjqWcQFahZLMeaEplJYumtB(P_0))
				{
					if (jpRWCWnSWjIHbShgmaKtrbKdevFr2.iueOmjDBOlDOqNGYWGAHBWIslogRA(P_0) is fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH wwphrnUdZYgdrhKBPyggpYmosQFH)
					{
						TYovfIszswbQEXSvpewkGghabwKZ.WUuGYgoRoIjAECEpfGbEYErcjygAA(wwphrnUdZYgdrhKBPyggpYmosQFH);
					}
					jpRWCWnSWjIHbShgmaKtrbKdevFr2.rWiPalmtgflXjFGWQDhXctDypNop(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					oVUFnIGXidUDJSaOsJzspRydYRQo.IlxVkhbJblcRsHURxmeSjqVJSnQRA(joystick);
					if (PEzcbxltXlprwsufmUKPmweURhRc.Count > 0)
					{
						PEzcbxltXlprwsufmUKPmweURhRc.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void WoLyvxVxaOGmOayuVloVBsbYBYst(Joystick P_0)
			{
				if (P_0 != null)
				{
					tCZcInyidnblUKepOHVREAbyiuIfA(P_0.id);
				}
			}

			internal void XKRMDhddktXnBUdZTskcaoKNZdik()
			{
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Joystick);
				for (int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ - 1; num >= 0; num--)
				{
					TYovfIszswbQEXSvpewkGghabwKZ.WUuGYgoRoIjAECEpfGbEYErcjygAA(jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num) as fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<Joystick, JoystickMap>.wwphrnUdZYgdrhKBPyggpYmosQFH);
					oVUFnIGXidUDJSaOsJzspRydYRQo.IlxVkhbJblcRsHURxmeSjqVJSnQRA(jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX);
					int id = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX.id;
					jpRWCWnSWjIHbShgmaKtrbKdevFr2.QnObWMMHibUgrDdgMWrcUIjBXRYc(num);
					if (PEzcbxltXlprwsufmUKPmweURhRc.Count > 0)
					{
						PEzcbxltXlprwsufmUKPmweURhRc.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, id, ControllerType.Joystick, false));
					}
				}
				jpRWCWnSWjIHbShgmaKtrbKdevFr2.kAZHRZGWBRTUOiPyceAuqAENqxgtA();
			}

			internal void mIQtmapFJfJNDwyvlheTDcPDoEPp(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom);
				if (!jpRWCWnSWjIHbShgmaKtrbKdevFr2.GRMIiFyjqWcQFahZLMeaEplJYumtB(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::FarFCHilnTaPUOHyjpIPWUDENJjC<CustomControllerMap> farFCHilnTaPUOHyjpIPWUDENJjC = maps.aozCAvnASoxQESrOLHLpJeAUPEPiA(P_0, true);
					if (farFCHilnTaPUOHyjpIPWUDENJjC == null)
					{
						farFCHilnTaPUOHyjpIPWUDENJjC = new global::FarFCHilnTaPUOHyjpIPWUDENJjC<CustomControllerMap>(P_0.id);
					}
					fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>.wwphrnUdZYgdrhKBPyggpYmosQFH wwphrnUdZYgdrhKBPyggpYmosQFH = new fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<CustomController, CustomControllerMap>.wwphrnUdZYgdrhKBPyggpYmosQFH(P_0, farFCHilnTaPUOHyjpIPWUDENJjC);
					jpRWCWnSWjIHbShgmaKtrbKdevFr2.QyjajlnRkTYODzAYNObNbrAGHPN(wwphrnUdZYgdrhKBPyggpYmosQFH);
					oVUFnIGXidUDJSaOsJzspRydYRQo.nfEkqZqZRNUInmTJUkYYXDLywkdD(P_0);
					maps.layoutManager.Apply();
					if (jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Count > 0)
					{
						jNlEgzJDpWIjbvlRbEiWhkxATHbAA.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void oNqPgNWjuapcrhhNOagTNRoneEaFA(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					mIQtmapFJfJNDwyvlheTDcPDoEPp(customController, P_1);
				}
			}

			internal void HhWiUUFfiCIxrfSIRuPpPlstScLVA(int P_0)
			{
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom);
				if (jpRWCWnSWjIHbShgmaKtrbKdevFr2.GRMIiFyjqWcQFahZLMeaEplJYumtB(P_0))
				{
					jpRWCWnSWjIHbShgmaKtrbKdevFr2.iueOmjDBOlDOqNGYWGAHBWIslogRA(P_0);
					jpRWCWnSWjIHbShgmaKtrbKdevFr2.rWiPalmtgflXjFGWQDhXctDypNop(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					oVUFnIGXidUDJSaOsJzspRydYRQo.IlxVkhbJblcRsHURxmeSjqVJSnQRA(customController);
					if (PEzcbxltXlprwsufmUKPmweURhRc.Count > 0)
					{
						PEzcbxltXlprwsufmUKPmweURhRc.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void epoFkErIWYIJNhGbsqhnmLswvJCc(CustomController P_0)
			{
				if (P_0 != null)
				{
					HhWiUUFfiCIxrfSIRuPpPlstScLVA(P_0.id);
				}
			}

			internal void iZRuvIhVfXWANnPfzfaLYnqkhGWg()
			{
				jpRWCWnSWjIHbShgmaKtrbKdevFr jpRWCWnSWjIHbShgmaKtrbKdevFr2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Custom);
				for (int num = jpRWCWnSWjIHbShgmaKtrbKdevFr2.flFZvPVsPcNnBeWIGSaTgKMcStvJ - 1; num >= 0; num--)
				{
					oVUFnIGXidUDJSaOsJzspRydYRQo.IlxVkhbJblcRsHURxmeSjqVJSnQRA(jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX);
					int id = jpRWCWnSWjIHbShgmaKtrbKdevFr2.AWmOltvgZLyyeShVGMDDYeiwNhPG(num).LEdXAULnordCtHuhKNePXQiSgnCX.id;
					jpRWCWnSWjIHbShgmaKtrbKdevFr2.QnObWMMHibUgrDdgMWrcUIjBXRYc(num);
					if (PEzcbxltXlprwsufmUKPmweURhRc.Count > 0)
					{
						PEzcbxltXlprwsufmUKPmweURhRc.Invoke(new ControllerAssignmentChangedEventArgs(JNGEYREZFAlJODwlkiADqvRbVgQF.id, id, ControllerType.Custom, false));
					}
				}
				jpRWCWnSWjIHbShgmaKtrbKdevFr2.kAZHRZGWBRTUOiPyceAuqAENqxgtA();
			}

			internal CustomController izMkLYZUWWHmVzGbQjLccqSLKyzh(int P_0)
			{
				CustomController customController = JNGEYREZFAlJODwlkiADqvRbVgQF.FLHSwBondVMFwICiFrRDNPxufqTW.OnAhnnQHKixkcuMWkpqEUJNLAIkDA(P_0);
				if (customController == null)
				{
					return null;
				}
				mIQtmapFJfJNDwyvlheTDcPDoEPp(customController, false);
				return customController;
			}

			internal void vkGGBgCVTFJZUQvFctbLaHrhpICOb(Action<bool, int, int> P_0)
			{
				FJLwXnOwfTnWmzelUWbFpZzQFTwl<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void AvgqAuqkqEXxZCcXbPrkthNffejD(Keyboard P_0, qBmpMUOLStHEYgGorZQuTYzZgBuC P_1, Action<bool, int, int> P_2)
			{
				if (!hbdpHKaWlaczISAqKemTfyDarQjwA || !P_0.enabled)
				{
					return;
				}
				JgTDzUEMiIEWzoCkejSUegUfYWkVB nZFkCZNNgvuNGulfcVdzXuBiECpU = gjGAZYHMtBrBPTgtywbcfPTZqEdL.NZFkCZNNgvuNGulfcVdzXuBiECpU;
				bool flag = false;
				jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Keyboard).iueOmjDBOlDOqNGYWGAHBWIslogRA(0).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
				int num = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				qBmpMUOLStHEYgGorZQuTYzZgBuC.TrudBKKdcsfMBskYqKlTsJDuivBFA trudBKKdcsfMBskYqKlTsJDuivBFA = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? qBmpMUOLStHEYgGorZQuTYzZgBuC.TrudBKKdcsfMBskYqKlTsJDuivBFA.OverlapModifiers : qBmpMUOLStHEYgGorZQuTYzZgBuC.TrudBKKdcsfMBskYqKlTsJDuivBFA.Normal);
				MRKePyazVTmdOdidqsXOcYtQuvkU.ahIrTDYEUXggKjTPrKKChNowHIRpA ahIrTDYEUXggKjTPrKKChNowHIRpA = new MRKePyazVTmdOdidqsXOcYtQuvkU.ahIrTDYEUXggKjTPrKKChNowHIRpA
				{
					OIZqgzicTEvcFKKYKXJAtfIQnYye = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.XJOdguxXwMRhhVigJirOJaRIWSEt;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj)
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
							buttonStateFlags = (P_0.nRIufaGBUegfLaPgCqzaLKRqdDMCA(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag5)
							{
								MRKePyazVTmdOdidqsXOcYtQuvkU mRKePyazVTmdOdidqsXOcYtQuvkU = MRKePyazVTmdOdidqsXOcYtQuvkU.rEJwcpqicCoKnzCoggngDWTlfAIh(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk);
								if (mRKePyazVTmdOdidqsXOcYtQuvkU != null && mRKePyazVTmdOdidqsXOcYtQuvkU.xgmQEHuJPCchuhoFOGpJEbtNqnhN(true) != ButtonStateFlags.Off)
								{
									flag5 = true;
								}
							}
						}
						else
						{
							buttonStateFlags = P_0.ldCWXEWHrzPWFgYlYEOyXHwAqhRe(actionElementMap.coqXdmPghseNBOvihWdoifSiCjzh);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag5)
						{
							if (!flag2)
							{
								flag3 = P_1.GrPxfPsjbCpiBuoBJiSTypNKVtOB(keyboardKeyCode, modifierKeyFlags, trudBKKdcsfMBskYqKlTsJDuivBFA, out flag4);
							}
							if (flag4 || modifierKeyFlags != ModifierKeyFlags.None)
							{
								ahIrTDYEUXggKjTPrKKChNowHIRpA.BhREzJwdcXaoacEmRgGVEHqIKWQoB = flag3;
								MRKePyazVTmdOdidqsXOcYtQuvkU mRKePyazVTmdOdidqsXOcYtQuvkU = MRKePyazVTmdOdidqsXOcYtQuvkU.BXNqqItjXjrVOXjvxORMcShpsPbT(actionElementMap.xYazCGhLJSNpewHjYMCgVGmvJCJk, ahIrTDYEUXggKjTPrKKChNowHIRpA);
								if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
								{
									mRKePyazVTmdOdidqsXOcYtQuvkU.qkDqfzMotoQQxMWSTvBPUhlqYFog = flag3;
								}
								else if (flag3)
								{
									mRKePyazVTmdOdidqsXOcYtQuvkU.qkDqfzMotoQQxMWSTvBPUhlqYFog = true;
								}
								mRKePyazVTmdOdidqsXOcYtQuvkU.RMPXLiVPcQjhyBDbrdgxOIdDvzIQ(ReInput.currentUpdateLoop, buttonStateFlags, true);
								buttonStateFlags = mRKePyazVTmdOdidqsXOcYtQuvkU.xgmQEHuJPCchuhoFOGpJEbtNqnhN(true);
							}
						}
						if (buttonStateFlags != ButtonStateFlags.Off)
						{
							DbvCBHsYxDotCdcRZFdZndGsDkUBA(P_0, keyboardMap, actionElementMap, nZFkCZNNgvuNGulfcVdzXuBiECpU, buttonStateFlags);
							P_2(arg1: true, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId);
							flag = true;
							continue;
						}
						if (nZFkCZNNgvuNGulfcVdzXuBiECpU.wMFTkrhNYSiDFmpXjFcCgCfolwhuA != 0f)
						{
							nZFkCZNNgvuNGulfcVdzXuBiECpU.wMFTkrhNYSiDFmpXjFcCgCfolwhuA = 0f;
						}
						if (nZFkCZNNgvuNGulfcVdzXuBiECpU.oHNoqcZbHXiegBfUOCOIPGjKQdLk != ButtonStateFlags.Off)
						{
							nZFkCZNNgvuNGulfcVdzXuBiECpU.oHNoqcZbHXiegBfUOCOIPGjKQdLk = ButtonStateFlags.Off;
						}
						P_2(arg1: false, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId);
					}
				}
				if (flag)
				{
					ctshoABSQYLnrZUoxUemtaVlzArj = ReInput.unscaledTime;
				}
			}

			private static void DbvCBHsYxDotCdcRZFdZndGsDkUBA(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, JgTDzUEMiIEWzoCkejSUegUfYWkVB P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.wMFTkrhNYSiDFmpXjFcCgCfolwhuA = num;
				P_3.oHNoqcZbHXiegBfUOCOIPGjKQdLk = P_4;
				P_3.hgVVdSFLSrbWVHOnncMsHlbfyInU = P_0;
				P_3.HZESPmoDAoPRVJpSHkZgwMuBDzCN = ControllerType.Keyboard;
				P_3.pSSELSDZzuydRHaXCiaXajzIogvaB = ControllerElementType.Button;
				P_3.nTuVjctMeCwaWMwejRNMBNwqIuBw = P_2;
				P_3.gkfEkRVUJAEFBaRxMIBeUfqJzTwdA = P_1;
				if (P_3.nIlgyGcfJrLjVLdqPMYHTsPKyRpn)
				{
					P_3.nIlgyGcfJrLjVLdqPMYHTsPKyRpn = false;
				}
				if (P_3.REkjeeTdoSBWiQOYJybiegkZyWbt)
				{
					P_3.REkjeeTdoSBWiQOYJybiegkZyWbt = false;
				}
			}

			internal void EwaGZSQEeljCYkYnezbunpPOOqmiA(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!DEWennYbaKFDGoKNyRcStBbtPjpX || !P_0.enabled)
				{
					return;
				}
				jeabHUrstoKHDRpNBCZSFbPvOBSHb jeabHUrstoKHDRpNBCZSFbPvOBSHb2 = uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(ControllerType.Mouse).iueOmjDBOlDOqNGYWGAHBWIslogRA(0).YjPKnaUBIafYYbhEPJJXDUgXqwPK;
				JgTDzUEMiIEWzoCkejSUegUfYWkVB nZFkCZNNgvuNGulfcVdzXuBiECpU = gjGAZYHMtBrBPTgtywbcfPTZqEdL.NZFkCZNNgvuNGulfcVdzXuBiECpU;
				bool flag = false;
				int num = jeabHUrstoKHDRpNBCZSFbPvOBSHb2.aniKhwdBtMFSfkzhFrEqsKvGLSxt;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)jeabHUrstoKHDRpNBCZSFbPvOBSHb2.sraFvIhbtwaREyBqnZUbJclkEDGC(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.nMqKclaILiuPNcXmtCkhJbgHzQSu;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.doeoSlOqRUDmnfjUcrCbKfGtIzkl(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.doeoSlOqRUDmnfjUcrCbKfGtIzkl(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId);
									continue;
								}
							}
							nZFkCZNNgvuNGulfcVdzXuBiECpU.wMFTkrhNYSiDFmpXjFcCgCfolwhuA = num2;
							nZFkCZNNgvuNGulfcVdzXuBiECpU.hgVVdSFLSrbWVHOnncMsHlbfyInU = P_0;
							nZFkCZNNgvuNGulfcVdzXuBiECpU.HZESPmoDAoPRVJpSHkZgwMuBDzCN = ControllerType.Mouse;
							nZFkCZNNgvuNGulfcVdzXuBiECpU.pSSELSDZzuydRHaXCiaXajzIogvaB = ControllerElementType.Axis;
							nZFkCZNNgvuNGulfcVdzXuBiECpU.nTuVjctMeCwaWMwejRNMBNwqIuBw = actionElementMap;
							nZFkCZNNgvuNGulfcVdzXuBiECpU.gkfEkRVUJAEFBaRxMIBeUfqJzTwdA = mouseMap;
							if (nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt)
							{
								nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt = false;
							}
							if (nZFkCZNNgvuNGulfcVdzXuBiECpU.zoPjLhlbwFnTylPOOifkihqHpnym != AxisCoordinateMode.Relative)
							{
								nZFkCZNNgvuNGulfcVdzXuBiECpU.zoPjLhlbwFnTylPOOifkihqHpnym = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.XJOdguxXwMRhhVigJirOJaRIWSEt;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.RptbHJCcIuiLyZQvQNPcvZWySinAA(actionElementMap2, actionId2, out var wMFTkrhNYSiDFmpXjFcCgCfolwhuA, out nZFkCZNNgvuNGulfcVdzXuBiECpU.nIlgyGcfJrLjVLdqPMYHTsPKyRpn))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.ldCWXEWHrzPWFgYlYEOyXHwAqhRe(actionElementMap2.coqXdmPghseNBOvihWdoifSiCjzh);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId2);
							continue;
						}
						nZFkCZNNgvuNGulfcVdzXuBiECpU.wMFTkrhNYSiDFmpXjFcCgCfolwhuA = wMFTkrhNYSiDFmpXjFcCgCfolwhuA;
						nZFkCZNNgvuNGulfcVdzXuBiECpU.oHNoqcZbHXiegBfUOCOIPGjKQdLk = buttonStateFlags;
						nZFkCZNNgvuNGulfcVdzXuBiECpU.hgVVdSFLSrbWVHOnncMsHlbfyInU = P_0;
						nZFkCZNNgvuNGulfcVdzXuBiECpU.HZESPmoDAoPRVJpSHkZgwMuBDzCN = ControllerType.Mouse;
						nZFkCZNNgvuNGulfcVdzXuBiECpU.pSSELSDZzuydRHaXCiaXajzIogvaB = ControllerElementType.Button;
						nZFkCZNNgvuNGulfcVdzXuBiECpU.nTuVjctMeCwaWMwejRNMBNwqIuBw = actionElementMap2;
						nZFkCZNNgvuNGulfcVdzXuBiECpU.gkfEkRVUJAEFBaRxMIBeUfqJzTwdA = mouseMap;
						if (nZFkCZNNgvuNGulfcVdzXuBiECpU.nIlgyGcfJrLjVLdqPMYHTsPKyRpn)
						{
							nZFkCZNNgvuNGulfcVdzXuBiECpU.nIlgyGcfJrLjVLdqPMYHTsPKyRpn = false;
						}
						if (nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt)
						{
							nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt = false;
						}
						P_1(arg1: true, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					yntgvobaAgCtnxhMMKXhfhosgatFA = ReInput.unscaledTime;
				}
			}

			internal void WAkDqYmIXisBbVcxgLHXKObHiseB(Action<bool, int, int> P_0)
			{
				FJLwXnOwfTnWmzelUWbFpZzQFTwl<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void FJLwXnOwfTnWmzelUWbFpZzQFTwl<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<_0001, _0002> fxgNmVGnKrGZwkEOjCQYjAEXUlWcA2 = (fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<_0001, _0002>)uueNAgsGPvZIbkSfUpRlQGRqFBScA.eHVBefQhISgSNOMmqiVPKCcbkdvS(P_0);
				JgTDzUEMiIEWzoCkejSUegUfYWkVB nZFkCZNNgvuNGulfcVdzXuBiECpU = gjGAZYHMtBrBPTgtywbcfPTZqEdL.NZFkCZNNgvuNGulfcVdzXuBiECpU;
				int num = fxgNmVGnKrGZwkEOjCQYjAEXUlWcA2.FxvPkjCuyRakVnYBeVfaLDkcEYif();
				for (int i = 0; i < num; i++)
				{
					fxgNmVGnKrGZwkEOjCQYjAEXUlWcA<_0001, _0002>.wwphrnUdZYgdrhKBPyggpYmosQFH wwphrnUdZYgdrhKBPyggpYmosQFH = fxgNmVGnKrGZwkEOjCQYjAEXUlWcA2.ihvXgqWSGmVwWbEzjbWBOdzHdBvr(i);
					_0001 bYlFGRIAVlFFEDTQdwYJaaaeCxfbB = wwphrnUdZYgdrhKBPyggpYmosQFH.BYlFGRIAVlFFEDTQdwYJaaaeCxfbB;
					if (!bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.enabled)
					{
						continue;
					}
					global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0002> ahOWBwQXlUjEXgrPOgQMKEMCgKcP = wwphrnUdZYgdrhKBPyggpYmosQFH.AhOWBwQXlUjEXgrPOgQMKEMCgKcP;
					bool flag = false;
					int num2 = ahOWBwQXlUjEXgrPOgQMKEMCgKcP.YzKYnaKJzjbvJEXDdyXusrltRUPjA();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = ahOWBwQXlUjEXgrPOgQMKEMCgKcP.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.nMqKclaILiuPNcXmtCkhJbgHzQSu;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.amuHcHIpLQrjMsPzQKBWApxhXPxj || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.doeoSlOqRUDmnfjUcrCbKfGtIzkl(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.doeoSlOqRUDmnfjUcrCbKfGtIzkl(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId);
										continue;
									}
								}
								nZFkCZNNgvuNGulfcVdzXuBiECpU.wMFTkrhNYSiDFmpXjFcCgCfolwhuA = num3;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.hgVVdSFLSrbWVHOnncMsHlbfyInU = bYlFGRIAVlFFEDTQdwYJaaaeCxfbB;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.HZESPmoDAoPRVJpSHkZgwMuBDzCN = P_0;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.pSSELSDZzuydRHaXCiaXajzIogvaB = ControllerElementType.Axis;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.nTuVjctMeCwaWMwejRNMBNwqIuBw = actionElementMap;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.gkfEkRVUJAEFBaRxMIBeUfqJzTwdA = val;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt = bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.calibrationMap.Axes[actionElementMap.coqXdmPghseNBOvihWdoifSiCjzh].applyRangeCalibration;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.zoPjLhlbwFnTylPOOifkihqHpnym = bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.Axes[actionElementMap.elementIndex].hGVuzmiWOAnhEmGFXjTzQspEcSPiA?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.XJOdguxXwMRhhVigJirOJaRIWSEt;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.amuHcHIpLQrjMsPzQKBWApxhXPxj || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float wMFTkrhNYSiDFmpXjFcCgCfolwhuA = 0f;
								int coqXdmPghseNBOvihWdoifSiCjzh = actionElementMap2.coqXdmPghseNBOvihWdoifSiCjzh;
								if (!hFhAGKxwllbZgFMyxJwJKHqZnyZSA(bYlFGRIAVlFFEDTQdwYJaaaeCxfbB, i, coqXdmPghseNBOvihWdoifSiCjzh, actionElementMap2, ahOWBwQXlUjEXgrPOgQMKEMCgKcP, actionId2, ref wMFTkrhNYSiDFmpXjFcCgCfolwhuA) && !bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.RptbHJCcIuiLyZQvQNPcvZWySinAA(actionElementMap2, actionId2, out wMFTkrhNYSiDFmpXjFcCgCfolwhuA, out nZFkCZNNgvuNGulfcVdzXuBiECpU.nIlgyGcfJrLjVLdqPMYHTsPKyRpn))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = bYlFGRIAVlFFEDTQdwYJaaaeCxfbB.ldCWXEWHrzPWFgYlYEOyXHwAqhRe(actionElementMap2.coqXdmPghseNBOvihWdoifSiCjzh);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId2);
									continue;
								}
								nZFkCZNNgvuNGulfcVdzXuBiECpU.wMFTkrhNYSiDFmpXjFcCgCfolwhuA = wMFTkrhNYSiDFmpXjFcCgCfolwhuA;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.oHNoqcZbHXiegBfUOCOIPGjKQdLk = buttonStateFlags;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.hgVVdSFLSrbWVHOnncMsHlbfyInU = bYlFGRIAVlFFEDTQdwYJaaaeCxfbB;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.HZESPmoDAoPRVJpSHkZgwMuBDzCN = P_0;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.pSSELSDZzuydRHaXCiaXajzIogvaB = ControllerElementType.Button;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.nTuVjctMeCwaWMwejRNMBNwqIuBw = actionElementMap2;
								nZFkCZNNgvuNGulfcVdzXuBiECpU.gkfEkRVUJAEFBaRxMIBeUfqJzTwdA = val;
								if (nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt)
								{
									nZFkCZNNgvuNGulfcVdzXuBiECpU.REkjeeTdoSBWiQOYJybiegkZyWbt = false;
								}
								P_1(arg1: true, JNGEYREZFAlJODwlkiADqvRbVgQF.kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							wwphrnUdZYgdrhKBPyggpYmosQFH.egavmYiJFmhkhgXYJcUcuknwANUBb();
						}
					}
				}
			}

			private bool hFhAGKxwllbZgFMyxJwJKHqZnyZSA<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.ucqtfsuOTseRsybfPGjEFawPmfNK.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.ucqtfsuOTseRsybfPGjEFawPmfNK.GetUnknownHatButtons(P_2);
				if (VzIGaQbnKMjBfWuydibRfPSNquLgA(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.dFXwCyhgmrZdmeNmqvZMxkEALXTQ(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool VzIGaQbnKMjBfWuydibRfPSNquLgA<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (vZLHFbkdpTCoBhlpvZLjggvSzCqDA(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool vZLHFbkdpTCoBhlpvZLjggvSzCqDA<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::FarFCHilnTaPUOHyjpIPWUDENJjC<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.YzKYnaKJzjbvJEXDdyXusrltRUPjA();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.XbWjUpPUFPlxzgnJsRTTvhFDiBGcA(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int coqXdmPghseNBOvihWdoifSiCjzh = buttonMaps[j].coqXdmPghseNBOvihWdoifSiCjzh;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(coqXdmPghseNBOvihWdoifSiCjzh))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private const string kznwtUOLQgHZWuFaNtEriahXKUsO = "player";

		private readonly FbTdHcsBNUVZtBghOGVsEuhLuePk FLHSwBondVMFwICiFrRDNPxufqTW;

		private bool dPQbUbiTmzopbYONIThvPGpVMhWE;

		private int kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;

		private string ECTZizRnLUdQgzpUwwhwXKPVdKdEA;

		private string pQavACDNcqufUQRqPRhuTWABiyLu;

		private readonly string FitPwmOyZRmuHNjvmhyEOKqDOUUG;

		private bool PLtFEfiQFkTIdBlqPnofFupiPTpzA;

		private readonly int CWUBFGFinUErraLefZFzrkdJfUNCb;

		private readonly oEEgoKqIygbHTIQCNsneyiTKzIXQA AyuOTNuDOJXWRvfmsDnYwRleHBju;

		private int HIAgGimVOjAfhbQrZnaSpAIcCbbd;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
					return -1;
				}
				return kvTiPcxeLRNwlbOaWbnRAmMnEZTDA;
			}
			internal set
			{
				kvTiPcxeLRNwlbOaWbnRAmMnEZTDA = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
					return string.Empty;
				}
				return ECTZizRnLUdQgzpUwwhwXKPVdKdEA;
			}
			internal set
			{
				ECTZizRnLUdQgzpUwwhwXKPVdKdEA = eCTZizRnLUdQgzpUwwhwXKPVdKdEA;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return pQavACDNcqufUQRqPRhuTWABiyLu;
				}
				return AyuOTNuDOJXWRvfmsDnYwRleHBju.YYpaixksduwqUQfFFmPUzWfHjhDu;
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
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
					return false;
				}
				return PLtFEfiQFkTIdBlqPnofFupiPTpzA;
			}
			set
			{
				PLtFEfiQFkTIdBlqPnofFupiPTpzA = value;
			}
		}

		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return pQavACDNcqufUQRqPRhuTWABiyLu;
			}
			set
			{
				pQavACDNcqufUQRqPRhuTWABiyLu = value;
				AyuOTNuDOJXWRvfmsDnYwRleHBju.GvKqFlBIauBSccpqkijaDCUIwlHHB();
			}
		}

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.keyCategory => "player";

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.scriptingName => ECTZizRnLUdQgzpUwwhwXKPVdKdEA;

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.nonLocalizedDescriptiveName
		{
			get
			{
				return pQavACDNcqufUQRqPRhuTWABiyLu;
			}
			set
			{
				pQavACDNcqufUQRqPRhuTWABiyLu = value;
			}
		}

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.key => FitPwmOyZRmuHNjvmhyEOKqDOUUG;

		int leeNpeIpkRWAaDYnewmtyKpQcRpw.autoGeneratedValueFlags
		{
			get
			{
				return HIAgGimVOjAfhbQrZnaSpAIcCbbd;
			}
			set
			{
				HIAgGimVOjAfhbQrZnaSpAIcCbbd = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, GdOldZdkCaFseCtTjjUkzAqYRXRaA P_5, ControllerMapLayoutManager.SLxTBaXfrhZCyLfCEqNyvKbuXYzr P_6, ControllerMapEnabler.MpLdxmCiVDCEhjPNCfTXmDrkNyfGc P_7)
		{
			dPQbUbiTmzopbYONIThvPGpVMhWE = P_0;
			kvTiPcxeLRNwlbOaWbnRAmMnEZTDA = P_1;
			ECTZizRnLUdQgzpUwwhwXKPVdKdEA = P_2;
			pQavACDNcqufUQRqPRhuTWABiyLu = P_3;
			FitPwmOyZRmuHNjvmhyEOKqDOUUG = P_4;
			CWUBFGFinUErraLefZFzrkdJfUNCb = ReInput.id;
			AyuOTNuDOJXWRvfmsDnYwRleHBju = oEEgoKqIygbHTIQCNsneyiTKzIXQA.CXYVDSKouccTTATbQGDZttKGiskv(this);
			controllers = new ControllerHelper(this, P_5, P_6, P_7);
			FLHSwBondVMFwICiFrRDNPxufqTW = ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb;
			MPWzvJAdwTbxyMyAqlTUazzhudfe();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.FuonpZfnMsIoctilHoaxyYdyBhPe() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.FuonpZfnMsIoctilHoaxyYdyBhPe() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.mZHiYnhZVMTDhjZLvRUEntHJjuHw() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.mZHiYnhZVMTDhjZLvRUEntHJjuHw() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.iqFazvtbRNuTyRjsZusNMBvfGFtk() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.iqFazvtbRNuTyRjsZusNMBvfGFtk() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.eaIDsdFDPMpzBFuLLeduvIngcxyu() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.eaIDsdFDPMpzBFuLLeduvIngcxyu() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.LnEbufSAmJfOiJrZgUBgkniKbpvX() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.LnEbufSAmJfOiJrZgUBgkniKbpvX() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.PJZLJevQXCnMsBKtiMDQTOvWZFnT() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.PJZLJevQXCnMsBKtiMDQTOvWZFnT() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.JALHxVPoifuEKIMLkheSGexBueSw() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.JALHxVPoifuEKIMLkheSGexBueSw() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.kGVFSQmZygeFnVSkIMyACXcsjYWn(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.kGVFSQmZygeFnVSkIMyACXcsjYWn(speed) ?? false;
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.tLnEeLgQKBjaCqeaCLrHJskehaDz(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.tLnEeLgQKBjaCqeaCLrHJskehaDz(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.PgZCDPfFiDhZucAZhsJWDBAJMPxs(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.PgZCDPfFiDhZucAZhsJWDBAJMPxs(speed) ?? false;
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.vqNJSnFQVahdImpeivdjhKUQqIsu(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.vqNJSnFQVahdImpeivdjhKUQqIsu(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.vqNJSnFQVahdImpeivdjhKUQqIsu(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.vqNJSnFQVahdImpeivdjhKUQqIsu(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.ozTbjfKCrGMmVLCadArSyWqVaEObb(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.ozTbjfKCrGMmVLCadArSyWqVaEObb(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.JyAydMepCujFNZILhDNDebzzCUXNA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.JyAydMepCujFNZILhDNDebzzCUXNA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.JyAydMepCujFNZILhDNDebzzCUXNA(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.JyAydMepCujFNZILhDNDebzzCUXNA(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.RdgEOnrsqnbnoGfNCoCLhpgdSwMI() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.RdgEOnrsqnbnoGfNCoCLhpgdSwMI() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.TQEUkSuCbHhTRsNYHVLHwiBiAJmv() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.TQEUkSuCbHhTRsNYHVLHwiBiAJmv() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.nhyiJcforsMXtqvHiOplkNBDEfiw() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.nhyiJcforsMXtqvHiOplkNBDEfiw() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.MIDVkEBmOouwYDzNPnAVakZFrYSM() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.MIDVkEBmOouwYDzNPnAVakZFrYSM() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.eNzEkBkljlqfudduKyxPNXKocpfeA() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.eNzEkBkljlqfudduKyxPNXKocpfeA() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.lHIaTenSobuARamRaqWxXFuiuQLm() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.lHIaTenSobuARamRaqWxXFuiuQLm() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.lHFTMgTyfAsIuMPvUDjKbrRCkFKdb() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.lHFTMgTyfAsIuMPvUDjKbrRCkFKdb() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.haEfTicuoCJaJBrzcccAWZTIjpiNc(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.rtafuaHzVCVbOeVeVWwzqBRVThxQA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.oySEjlYobOvDlDJLpzZkKyQklTRP(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.eKOEuHOvqcFaAzoaeDXcvjOfEKst(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.msOjfiReGuRiDPUDpEwZNkNvVPqQ() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.msOjfiReGuRiDPUDpEwZNkNvVPqQ() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.JHqcOAeTyVPcUAOVUnjtNiImbhGqA() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.JHqcOAeTyVPcUAOVUnjtNiImbhGqA() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.LJmoiCBrurlAHBkmMLoPOkULXlcW() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.LJmoiCBrurlAHBkmMLoPOkULXlcW() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.XBGdRySTTRFUMBwxafaWnApTtRmJA() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.XBGdRySTTRFUMBwxafaWnApTtRmJA() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.YVCTqAOcuTWFVseiADubHQfIHfvNA() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.YVCTqAOcuTWFVseiADubHQfIHfvNA() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.lWFlSmMbcEHZkEyFhvQJUQnAIBhtA() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.lWFlSmMbcEHZkEyFhvQJUQnAIBhtA() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.kVBACYjrkutBMvqbSDIGIJrfbfTH() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.kVBACYjrkutBMvqbSDIGIJrfbfTH() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.YrNCuRzVhdeutyyIGfMETTxXEubP() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.YrNCuRzVhdeutyyIGfMETTxXEubP() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.QgnCBglsGTlDpsjbieHyUVQwLeym() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.QgnCBglsGTlDpsjbieHyUVQwLeym() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.NMwEhakyyZNMHxttUYJeQiizHIVv(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.NMwEhakyyZNMHxttUYJeQiizHIVv(speed) ?? false;
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.XyoIVcyTTAxYTlnfVDbUXDonhvTx(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.XyoIVcyTTAxYTlnfVDbUXDonhvTx(speed) ?? false;
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.ngxWDFyCNcCegAzotQFUbmjKqQQL(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.ngxWDFyCNcCegAzotQFUbmjKqQQL(speed) ?? false;
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.NwEDQpiPCmWnaFrueFvwiluVimmHA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.NwEDQpiPCmWnaFrueFvwiluVimmHA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.NwEDQpiPCmWnaFrueFvwiluVimmHA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.NwEDQpiPCmWnaFrueFvwiluVimmHA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.mItFFVLDNLBtTwmTiuhZPnTrMVfK(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.mItFFVLDNLBtTwmTiuhZPnTrMVfK(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.sBAumCLTDURyhTfNUHsApUkQnXIU() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.sBAumCLTDURyhTfNUHsApUkQnXIU() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.evftNegrlGWJROygXVZfWvcDcQTr() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.evftNegrlGWJROygXVZfWvcDcQTr() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.NZYxPhfNRFZLbmhUATIoHwFxWSLu() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.NZYxPhfNRFZLbmhUATIoHwFxWSLu() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.KrmAAGjLIditkgMZfoBjWGpOAsakc() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.KrmAAGjLIditkgMZfoBjWGpOAsakc() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.sSwnZwbvPqQCDbKtZFLHjyuaoFYWA() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.sSwnZwbvPqQCDbKtZFLHjyuaoFYWA() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.XYXatCuaXaSAkxfLudqJltsNhkhO() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.XYXatCuaXaSAkxfLudqJltsNhkhO() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.wiyiayBClpifliNehzHgFFTiWoTqA() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.wiyiayBClpifliNehzHgFFTiWoTqA() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.kmBvtfTMVVlqyupOvhdcHEtRFzzz(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.xbycMseyCLktzoJOWbznmZqmHxzHA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.lSCnwYdMmXAxSGjTIEqLlyqzLUkb(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.OVLYdHHnuhvtzfzGBrxEeNzslnRQ(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.gPZMYfIPDBtBNTDdtvmsTnjpmMzh() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.gPZMYfIPDBtBNTDdtvmsTnjpmMzh() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.CZOvPBfJwDOFaTGwZlGBxECaagQkA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.CZOvPBfJwDOFaTGwZlGBxECaagQkA() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.ZPNikWIZSmUXPbeCTkmoPmYwisik() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.ZPNikWIZSmUXPbeCTkmoPmYwisik() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.GxmEpxBgzHPvglBWBgWeIaoEfdAb() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.GxmEpxBgzHPvglBWBgWeIaoEfdAb() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.tBoKoceMomaWNQNUUBYOAkRNkCYBb() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.tBoKoceMomaWNQNUUBYOAkRNkCYBb() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.RVNYFNnpJBJRpfldEntQCieHQtHUA() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.RVNYFNnpJBJRpfldEntQCieHQtHUA() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.JeQxFDvtzLcrLojuzCoIbGuPerTBb() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.JeQxFDvtzLcrLojuzCoIbGuPerTBb() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.CzBCLiMsRnnUruPoEvngzQvapSZL() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0f;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.CzBCLiMsRnnUruPoEvngzQvapSZL() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.ZPNikWIZSmUXPbeCTkmoPmYwisik();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.ZPNikWIZSmUXPbeCTkmoPmYwisik();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.ZPNikWIZSmUXPbeCTkmoPmYwisik();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.ZPNikWIZSmUXPbeCTkmoPmYwisik();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.tBoKoceMomaWNQNUUBYOAkRNkCYBb();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.tBoKoceMomaWNQNUUBYOAkRNkCYBb();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.tBoKoceMomaWNQNUUBYOAkRNkCYBb();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.tBoKoceMomaWNQNUUBYOAkRNkCYBb();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.GxmEpxBgzHPvglBWBgWeIaoEfdAb();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.GxmEpxBgzHPvglBWBgWeIaoEfdAb();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.GxmEpxBgzHPvglBWBgWeIaoEfdAb();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.GxmEpxBgzHPvglBWBgWeIaoEfdAb();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.RVNYFNnpJBJRpfldEntQCieHQtHUA();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionName, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.RVNYFNnpJBJRpfldEntQCieHQtHUA();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, xAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.x = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.RVNYFNnpJBJRpfldEntQCieHQtHUA();
			}
			gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, yAxisActionId, true);
			if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2 != null)
			{
				result.y = gjGAZYHMtBrBPTgtywbcfPTZqEdL2.RVNYFNnpJBJRpfldEntQCieHQtHUA();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.GThSpZrNBbRSSzzzFHAkhAPPqCqn() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.GThSpZrNBbRSSzzzFHAkhAPPqCqn() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.MihHPPLRGWQMdehgttUgkyiqHNqy() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.MihHPPLRGWQMdehgttUgkyiqHNqy() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.BDYUJxPlkYvnzrCdGWgbIZqXpAYJ() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.BDYUJxPlkYvnzrCdGWgbIZqXpAYJ() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.wpuuxnmzVrpOmkQSerkzkLtZeerFA() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return 0.0;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.wpuuxnmzVrpOmkQSerkzkLtZeerFA() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.ARLWQobzNTSpXqggzrOhBsWogoeP() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.ARLWQobzNTSpXqggzrOhBsWogoeP() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.cZBDCgGfqgALOiALvrWzEiOWGZRyA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.cZBDCgGfqgALOiALvrWzEiOWGZRyA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.YHrHKtqmuumUAQYnDefGLfEhgBveA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.YHrHKtqmuumUAQYnDefGLfEhgBveA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.sWCddKnMroSYiETpGrWfqpSNOIlO() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return AxisCoordinateMode.Absolute;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.sWCddKnMroSYiETpGrWfqpSNOIlO() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.fddHjNCEbpRsAgsOjraMEXNMZukac();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.fddHjNCEbpRsAgsOjraMEXNMZukac();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.ydnFcnKfeakCbANdvCOTGECSfFSV(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.ydnFcnKfeakCbANdvCOTGECSfFSV(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.aSjozqWQYVhvXFhGgiShlOcjBOrj(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.aSjozqWQYVhvXFhGgiShlOcjBOrj(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.pXjAKwLoAxucOfGKCbnMfuaMGTchA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionName, true)?.zZWDpFQvuoSVtlynHnaxkgQwxhTj(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return false;
			}
			return FLHSwBondVMFwICiFrRDNPxufqTW.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, actionId, true)?.zZWDpFQvuoSVtlynHnaxkgQwxhTj(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.bMBlCBFzxJHlHzPxwktZdUrhaDZd(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.RDVgHOVVkWDWMdnyUKiqOgTgSkkV(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return;
			}
			int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
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
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.LzfRBcvhvzjmiQisimVvvPcZjCPdA(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.EbqGOyIHMSkOduOugMijjFmBSpoZb(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return;
			}
			int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.ZzcGBAoteqlTjXXLrkEMDniTBcWZ(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.XhSAETyPejOHZRLLsHJgimtHmHlib(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return;
			}
			int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.viKFbRCcoMBXUfBGeWgKeKoCKfuuc(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.kJvqhSTntFTtVHAMrmwNhCvoPulj(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.OHUuKleGKYxnAWYNOkNkhxeasEqT(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return;
			}
			int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.agfALxrwtQaXnJXduUuCjedeIyks(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return;
			}
			int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.wvIAjIbpzxWBrlIzMNzYryShfUWc(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.iQFvxIKYauoqAbPWupQoKBPsXtcG(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				return;
			}
			int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
				{
					ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
				}
				else
				{
					FLHSwBondVMFwICiFrRDNPxufqTW.OHGGbCvlibDdnGNgzpBbSdnDrgrM(kvTiPcxeLRNwlbOaWbnRAmMnEZTDA);
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
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
			if (ReInput._id != CWUBFGFinUErraLefZFzrkdJfUNCb)
			{
				ReInput.CheckInitialized(CWUBFGFinUErraLefZFzrkdJfUNCb);
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

		internal void qjJhuMNvVkIZZENjSAjbkTcIJMql()
		{
			MPWzvJAdwTbxyMyAqlTUazzhudfe();
		}

		private void MPWzvJAdwTbxyMyAqlTUazzhudfe()
		{
			controllers.YHytikfuunkpDEZrfMVolDcriDeK();
			PLtFEfiQFkTIdBlqPnofFupiPTpzA = false;
		}
	}
}
