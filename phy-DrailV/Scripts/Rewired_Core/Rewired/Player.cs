using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Rewired.Config;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player : jtAeQMwqfCHdCmeHvhaRCqwDmBxb
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class aqFezRdfUkqIWIUrgOMzWnNvMlWFB : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					private CustomControllerMap iMOTycYwgQJAOdjETFGjwKllT;

					public CustomControllerMap DajLgnbDjcVFpkPbeLaDtkbBtLmc;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public aqFezRdfUkqIWIUrgOMzWnNvMlWFB(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00eb;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0 || iMOTycYwgQJAOdjETFGjwKllT == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							goto IL_0117;
							IL_00eb:
							if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
							{
								ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
							goto IL_0105;
							IL_0117:
							if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								if (conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).yBVYaZymnHfILCjQopwadWNgxbeH.id == GKMAkeKDuSYwRgXGsIoemQeEFFeiA)
								{
									LTEsUPlDRPIUwfjPOBEMaAhKHeOx = conflictCheckingHelper.IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Custom, GKMAkeKDuSYwRgXGsIoemQeEFFeiA, iMOTycYwgQJAOdjETFGjwKllT, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN, conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).gYfvSSlCQdvlHXoFtXExDLDXhhRu).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
						aqFezRdfUkqIWIUrgOMzWnNvMlWFB aqFezRdfUkqIWIUrgOMzWnNvMlWFB2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							aqFezRdfUkqIWIUrgOMzWnNvMlWFB2 = this;
						}
						else
						{
							aqFezRdfUkqIWIUrgOMzWnNvMlWFB2 = new aqFezRdfUkqIWIUrgOMzWnNvMlWFB(0);
							aqFezRdfUkqIWIUrgOMzWnNvMlWFB2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						aqFezRdfUkqIWIUrgOMzWnNvMlWFB2.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						aqFezRdfUkqIWIUrgOMzWnNvMlWFB2.iMOTycYwgQJAOdjETFGjwKllT = DajLgnbDjcVFpkPbeLaDtkbBtLmc;
						aqFezRdfUkqIWIUrgOMzWnNvMlWFB2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						aqFezRdfUkqIWIUrgOMzWnNvMlWFB2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						return aqFezRdfUkqIWIUrgOMzWnNvMlWFB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class mSoboFzSjOXZqwwSGuYBTKxCgXTO : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					private ActionElementMap yChnYOSSLFUSaChNzFvrDutuRmpk;

					public ActionElementMap irfbfPdSapgmElNrHAavHgDhtrXec;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private CustomControllerMap iMOTycYwgQJAOdjETFGjwKllT;

					public CustomControllerMap DajLgnbDjcVFpkPbeLaDtkbBtLmc;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public mSoboFzSjOXZqwwSGuYBTKxCgXTO(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00f1;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0 || yChnYOSSLFUSaChNzFvrDutuRmpk == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							goto IL_011d;
							IL_00f1:
							if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
							{
								ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
							goto IL_010b;
							IL_011d:
							if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								if (conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).yBVYaZymnHfILCjQopwadWNgxbeH.id == GKMAkeKDuSYwRgXGsIoemQeEFFeiA)
								{
									LTEsUPlDRPIUwfjPOBEMaAhKHeOx = conflictCheckingHelper.IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Custom, GKMAkeKDuSYwRgXGsIoemQeEFFeiA, iMOTycYwgQJAOdjETFGjwKllT, yChnYOSSLFUSaChNzFvrDutuRmpk, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN, conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).gYfvSSlCQdvlHXoFtXExDLDXhhRu).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
						mSoboFzSjOXZqwwSGuYBTKxCgXTO mSoboFzSjOXZqwwSGuYBTKxCgXTO2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							mSoboFzSjOXZqwwSGuYBTKxCgXTO2 = this;
						}
						else
						{
							mSoboFzSjOXZqwwSGuYBTKxCgXTO2 = new mSoboFzSjOXZqwwSGuYBTKxCgXTO(0);
							mSoboFzSjOXZqwwSGuYBTKxCgXTO2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						mSoboFzSjOXZqwwSGuYBTKxCgXTO2.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						mSoboFzSjOXZqwwSGuYBTKxCgXTO2.iMOTycYwgQJAOdjETFGjwKllT = DajLgnbDjcVFpkPbeLaDtkbBtLmc;
						mSoboFzSjOXZqwwSGuYBTKxCgXTO2.yChnYOSSLFUSaChNzFvrDutuRmpk = irfbfPdSapgmElNrHAavHgDhtrXec;
						mSoboFzSjOXZqwwSGuYBTKxCgXTO2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						mSoboFzSjOXZqwwSGuYBTKxCgXTO2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						return mSoboFzSjOXZqwwSGuYBTKxCgXTO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class esHECTpHGYihKHGXkattbnHjjnzcB : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public esHECTpHGYihKHGXkattbnHjjnzcB(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00f3;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerId < 0 || xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							goto IL_011f;
							IL_00f3:
							if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
							{
								ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
							goto IL_010d;
							IL_011f:
							if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								if (conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).yBVYaZymnHfILCjQopwadWNgxbeH.id == xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerId)
								{
									LTEsUPlDRPIUwfjPOBEMaAhKHeOx = conflictCheckingHelper.IvUzLqMedOsqEXZGEndrjvisgHCl(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN, conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).gYfvSSlCQdvlHXoFtXExDLDXhhRu).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
						esHECTpHGYihKHGXkattbnHjjnzcB esHECTpHGYihKHGXkattbnHjjnzcB2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							esHECTpHGYihKHGXkattbnHjjnzcB2 = this;
						}
						else
						{
							esHECTpHGYihKHGXkattbnHjjnzcB2 = new esHECTpHGYihKHGXkattbnHjjnzcB(0);
							esHECTpHGYihKHGXkattbnHjjnzcB2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						esHECTpHGYihKHGXkattbnHjjnzcB2.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						esHECTpHGYihKHGXkattbnHjjnzcB2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						esHECTpHGYihKHGXkattbnHjjnzcB2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						return esHECTpHGYihKHGXkattbnHjjnzcB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class RbtoIoeNjlWsoplRlfeeyrNdFYwiA<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where _0001 : ControllerMap
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> BnvaYsgxTsTNdibbAgKYmfHkJsGXA;

					public BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> OVeKqfJjvuNVyzvTfSZVFRbfGDFt;

					private _0001 xJWgEzHzghWsJGGAkpTFQSFVNBWs;

					public _0001 qmWlFVvGxfBcMzIKTlRzrfTaGKrl;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType VYSrnVLDBJSLmlHeYFUhiSEsBKLG;

					public ControllerType UGvErvwDJcvDvcPxeygBQxSeghqq;

					private int YgMjkXVVtfPjEsGZuCmZEgVLDzdSA;

					public int XAvUWQywgHgmxGxadxrDHDoOciNG;

					private InputMapCategory uiOSKtjxRpdFKPIPHrTfTOAVvFxQ;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public RbtoIoeNjlWsoplRlfeeyrNdFYwiA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_014a;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BnvaYsgxTsTNdibbAgKYmfHkJsGXA == null || xJWgEzHzghWsJGGAkpTFQSFVNBWs == null)
							{
								return false;
							}
							uiOSKtjxRpdFKPIPHrTfTOAVvFxQ = ReInput.mapping.GetMapCategory(xJWgEzHzghWsJGGAkpTFQSFVNBWs.categoryId);
							if (uiOSKtjxRpdFKPIPHrTfTOAVvFxQ == null)
							{
								return false;
							}
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0176;
							IL_0176:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BnvaYsgxTsTNdibbAgKYmfHkJsGXA.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								ControllerMap controllerMap = BnvaYsgxTsTNdibbAgKYmfHkJsGXA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMap.enabled) && (BdJzrReMTTznOknxLtXkjkYMDbiN || !conflictCheckingHelper.LzZQEPNuwImsAaFFhULmFDaPtPZy(uiOSKtjxRpdFKPIPHrTfTOAVvFxQ, controllerMap)))
								{
									BhdWnHwETjTwooLnNokUmKQRiiPK = controllerMap.ElementAssignmentConflicts(xJWgEzHzghWsJGGAkpTFQSFVNBWs, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								elementAssignmentConflictInfo.controllerType = VYSrnVLDBJSLmlHeYFUhiSEsBKLG;
								elementAssignmentConflictInfo.controllerId = YgMjkXVVtfPjEsGZuCmZEgVLDzdSA;
								vjnbYLtrPMftzpjohNfommerCnGo = elementAssignmentConflictInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							goto IL_0164;
							IL_0164:
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						RbtoIoeNjlWsoplRlfeeyrNdFYwiA<_0001> rbtoIoeNjlWsoplRlfeeyrNdFYwiA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							rbtoIoeNjlWsoplRlfeeyrNdFYwiA = this;
						}
						else
						{
							rbtoIoeNjlWsoplRlfeeyrNdFYwiA = new RbtoIoeNjlWsoplRlfeeyrNdFYwiA<_0001>(0);
							rbtoIoeNjlWsoplRlfeeyrNdFYwiA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						rbtoIoeNjlWsoplRlfeeyrNdFYwiA.VYSrnVLDBJSLmlHeYFUhiSEsBKLG = UGvErvwDJcvDvcPxeygBQxSeghqq;
						rbtoIoeNjlWsoplRlfeeyrNdFYwiA.YgMjkXVVtfPjEsGZuCmZEgVLDzdSA = XAvUWQywgHgmxGxadxrDHDoOciNG;
						rbtoIoeNjlWsoplRlfeeyrNdFYwiA.xJWgEzHzghWsJGGAkpTFQSFVNBWs = qmWlFVvGxfBcMzIKTlRzrfTaGKrl;
						rbtoIoeNjlWsoplRlfeeyrNdFYwiA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						rbtoIoeNjlWsoplRlfeeyrNdFYwiA.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						rbtoIoeNjlWsoplRlfeeyrNdFYwiA.BnvaYsgxTsTNdibbAgKYmfHkJsGXA = OVeKqfJjvuNVyzvTfSZVFRbfGDFt;
						return rbtoIoeNjlWsoplRlfeeyrNdFYwiA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class iClTcIiKLXVbDajvyaOXPTCrnkYv<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where _0001 : ControllerMap
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> BnvaYsgxTsTNdibbAgKYmfHkJsGXA;

					public BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> OVeKqfJjvuNVyzvTfSZVFRbfGDFt;

					private ActionElementMap czBjHeoirxaeBwMyIUOKKVRUCmFQ;

					public ActionElementMap OApHoBHhleZnmfgFhkPsMrArjrnO;

					private _0001 xJWgEzHzghWsJGGAkpTFQSFVNBWs;

					public _0001 qmWlFVvGxfBcMzIKTlRzrfTaGKrl;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType VYSrnVLDBJSLmlHeYFUhiSEsBKLG;

					public ControllerType UGvErvwDJcvDvcPxeygBQxSeghqq;

					private int YgMjkXVVtfPjEsGZuCmZEgVLDzdSA;

					public int XAvUWQywgHgmxGxadxrDHDoOciNG;

					private InputMapCategory uiOSKtjxRpdFKPIPHrTfTOAVvFxQ;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public iClTcIiKLXVbDajvyaOXPTCrnkYv(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0141;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BnvaYsgxTsTNdibbAgKYmfHkJsGXA == null || czBjHeoirxaeBwMyIUOKKVRUCmFQ == null)
							{
								return false;
							}
							uiOSKtjxRpdFKPIPHrTfTOAVvFxQ = ((xJWgEzHzghWsJGGAkpTFQSFVNBWs != null) ? ReInput.mapping.GetMapCategory(xJWgEzHzghWsJGGAkpTFQSFVNBWs.categoryId) : null);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_016d;
							IL_016d:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BnvaYsgxTsTNdibbAgKYmfHkJsGXA.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								ControllerMap controllerMap = BnvaYsgxTsTNdibbAgKYmfHkJsGXA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMap.enabled) && (BdJzrReMTTznOknxLtXkjkYMDbiN || !conflictCheckingHelper.LzZQEPNuwImsAaFFhULmFDaPtPZy(uiOSKtjxRpdFKPIPHrTfTOAVvFxQ, controllerMap)))
								{
									BhdWnHwETjTwooLnNokUmKQRiiPK = controllerMap.ElementAssignmentConflicts(czBjHeoirxaeBwMyIUOKKVRUCmFQ, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_016d;
							IL_0141:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								elementAssignmentConflictInfo.controllerType = VYSrnVLDBJSLmlHeYFUhiSEsBKLG;
								elementAssignmentConflictInfo.controllerId = YgMjkXVVtfPjEsGZuCmZEgVLDzdSA;
								vjnbYLtrPMftzpjohNfommerCnGo = elementAssignmentConflictInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						iClTcIiKLXVbDajvyaOXPTCrnkYv<_0001> iClTcIiKLXVbDajvyaOXPTCrnkYv2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							iClTcIiKLXVbDajvyaOXPTCrnkYv2 = this;
						}
						else
						{
							iClTcIiKLXVbDajvyaOXPTCrnkYv2 = new iClTcIiKLXVbDajvyaOXPTCrnkYv<_0001>(0);
							iClTcIiKLXVbDajvyaOXPTCrnkYv2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.VYSrnVLDBJSLmlHeYFUhiSEsBKLG = UGvErvwDJcvDvcPxeygBQxSeghqq;
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.YgMjkXVVtfPjEsGZuCmZEgVLDzdSA = XAvUWQywgHgmxGxadxrDHDoOciNG;
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.xJWgEzHzghWsJGGAkpTFQSFVNBWs = qmWlFVvGxfBcMzIKTlRzrfTaGKrl;
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.czBjHeoirxaeBwMyIUOKKVRUCmFQ = OApHoBHhleZnmfgFhkPsMrArjrnO;
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						iClTcIiKLXVbDajvyaOXPTCrnkYv2.BnvaYsgxTsTNdibbAgKYmfHkJsGXA = OVeKqfJjvuNVyzvTfSZVFRbfGDFt;
						return iClTcIiKLXVbDajvyaOXPTCrnkYv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class VovLrcfIKmoEAFgVqKJWOsqwJHqM<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where _0001 : ControllerMap
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> BnvaYsgxTsTNdibbAgKYmfHkJsGXA;

					public BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> OVeKqfJjvuNVyzvTfSZVFRbfGDFt;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private InputMapCategory uiOSKtjxRpdFKPIPHrTfTOAVvFxQ;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public VovLrcfIKmoEAFgVqKJWOsqwJHqM(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_01ab;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BnvaYsgxTsTNdibbAgKYmfHkJsGXA == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerType, xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerId, xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerMapId);
							uiOSKtjxRpdFKPIPHrTfTOAVvFxQ = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerMapCategoryId));
							if (uiOSKtjxRpdFKPIPHrTfTOAVvFxQ == null)
							{
								return false;
							}
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_01d7;
							IL_01ab:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								elementAssignmentConflictInfo.controllerType = xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerType;
								elementAssignmentConflictInfo.controllerId = xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerId;
								vjnbYLtrPMftzpjohNfommerCnGo = elementAssignmentConflictInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							goto IL_01c5;
							IL_01d7:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BnvaYsgxTsTNdibbAgKYmfHkJsGXA.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								ControllerMap controllerMap = BnvaYsgxTsTNdibbAgKYmfHkJsGXA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMap.enabled) && (BdJzrReMTTznOknxLtXkjkYMDbiN || !conflictCheckingHelper.LzZQEPNuwImsAaFFhULmFDaPtPZy(uiOSKtjxRpdFKPIPHrTfTOAVvFxQ, controllerMap)))
								{
									BhdWnHwETjTwooLnNokUmKQRiiPK = controllerMap.ElementAssignmentConflicts(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						VovLrcfIKmoEAFgVqKJWOsqwJHqM<_0001> vovLrcfIKmoEAFgVqKJWOsqwJHqM;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vovLrcfIKmoEAFgVqKJWOsqwJHqM = this;
						}
						else
						{
							vovLrcfIKmoEAFgVqKJWOsqwJHqM = new VovLrcfIKmoEAFgVqKJWOsqwJHqM<_0001>(0);
							vovLrcfIKmoEAFgVqKJWOsqwJHqM.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						vovLrcfIKmoEAFgVqKJWOsqwJHqM.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						vovLrcfIKmoEAFgVqKJWOsqwJHqM.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						vovLrcfIKmoEAFgVqKJWOsqwJHqM.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						vovLrcfIKmoEAFgVqKJWOsqwJHqM.BnvaYsgxTsTNdibbAgKYmfHkJsGXA = OVeKqfJjvuNVyzvTfSZVFRbfGDFt;
						return vovLrcfIKmoEAFgVqKJWOsqwJHqM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class IUUciTcTFPhjYNpzAptgdkeAcOzCb : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					private JoystickMap iYPWnSOIZMhoRIrtffHSidvpgvvP;

					public JoystickMap nHQaDnBIpPavKeTDoaJgzRaNsBFpA;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public IUUciTcTFPhjYNpzAptgdkeAcOzCb(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00ea;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0 || iYPWnSOIZMhoRIrtffHSidvpgvvP == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							goto IL_0116;
							IL_00ea:
							if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
							{
								ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
							goto IL_0104;
							IL_0116:
							if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								if (conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).yBVYaZymnHfILCjQopwadWNgxbeH.id == ZRqGPmiZYbBMxFgPHLFMZTmGNtUC)
								{
									LTEsUPlDRPIUwfjPOBEMaAhKHeOx = conflictCheckingHelper.IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Joystick, ZRqGPmiZYbBMxFgPHLFMZTmGNtUC, iYPWnSOIZMhoRIrtffHSidvpgvvP, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN, conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).gYfvSSlCQdvlHXoFtXExDLDXhhRu).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
						IUUciTcTFPhjYNpzAptgdkeAcOzCb iUUciTcTFPhjYNpzAptgdkeAcOzCb;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							iUUciTcTFPhjYNpzAptgdkeAcOzCb = this;
						}
						else
						{
							iUUciTcTFPhjYNpzAptgdkeAcOzCb = new IUUciTcTFPhjYNpzAptgdkeAcOzCb(0);
							iUUciTcTFPhjYNpzAptgdkeAcOzCb.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						iUUciTcTFPhjYNpzAptgdkeAcOzCb.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						iUUciTcTFPhjYNpzAptgdkeAcOzCb.iYPWnSOIZMhoRIrtffHSidvpgvvP = nHQaDnBIpPavKeTDoaJgzRaNsBFpA;
						iUUciTcTFPhjYNpzAptgdkeAcOzCb.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						iUUciTcTFPhjYNpzAptgdkeAcOzCb.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						return iUUciTcTFPhjYNpzAptgdkeAcOzCb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class MeosLCAxqxPMpeCOLENTibkCHjdnA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					private ActionElementMap yChnYOSSLFUSaChNzFvrDutuRmpk;

					public ActionElementMap irfbfPdSapgmElNrHAavHgDhtrXec;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private JoystickMap iYPWnSOIZMhoRIrtffHSidvpgvvP;

					public JoystickMap nHQaDnBIpPavKeTDoaJgzRaNsBFpA;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public MeosLCAxqxPMpeCOLENTibkCHjdnA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00f0;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0 || yChnYOSSLFUSaChNzFvrDutuRmpk == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							goto IL_011c;
							IL_00f0:
							if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
							{
								ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
							goto IL_010a;
							IL_011c:
							if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								if (conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).yBVYaZymnHfILCjQopwadWNgxbeH.id == ZRqGPmiZYbBMxFgPHLFMZTmGNtUC)
								{
									LTEsUPlDRPIUwfjPOBEMaAhKHeOx = conflictCheckingHelper.IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Joystick, ZRqGPmiZYbBMxFgPHLFMZTmGNtUC, iYPWnSOIZMhoRIrtffHSidvpgvvP, yChnYOSSLFUSaChNzFvrDutuRmpk, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN, conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).gYfvSSlCQdvlHXoFtXExDLDXhhRu).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
						MeosLCAxqxPMpeCOLENTibkCHjdnA meosLCAxqxPMpeCOLENTibkCHjdnA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							meosLCAxqxPMpeCOLENTibkCHjdnA = this;
						}
						else
						{
							meosLCAxqxPMpeCOLENTibkCHjdnA = new MeosLCAxqxPMpeCOLENTibkCHjdnA(0);
							meosLCAxqxPMpeCOLENTibkCHjdnA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						meosLCAxqxPMpeCOLENTibkCHjdnA.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						meosLCAxqxPMpeCOLENTibkCHjdnA.iYPWnSOIZMhoRIrtffHSidvpgvvP = nHQaDnBIpPavKeTDoaJgzRaNsBFpA;
						meosLCAxqxPMpeCOLENTibkCHjdnA.yChnYOSSLFUSaChNzFvrDutuRmpk = irfbfPdSapgmElNrHAavHgDhtrXec;
						meosLCAxqxPMpeCOLENTibkCHjdnA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						meosLCAxqxPMpeCOLENTibkCHjdnA.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						return meosLCAxqxPMpeCOLENTibkCHjdnA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class PJQkuKEhCscKikzlUmMohffWOdxeb : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					public ConflictCheckingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public PJQkuKEhCscKikzlUmMohffWOdxeb(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							ConflictCheckingHelper conflictCheckingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00f3;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerId < 0 || xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							goto IL_011f;
							IL_00f3:
							if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
							{
								ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
							goto IL_010d;
							IL_011f:
							if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx())
							{
								if (conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).yBVYaZymnHfILCjQopwadWNgxbeH.id == xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.controllerId)
								{
									LTEsUPlDRPIUwfjPOBEMaAhKHeOx = conflictCheckingHelper.IvUzLqMedOsqEXZGEndrjvisgHCl(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN, conflictCheckingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XFqmAWzGaybkkIOLbVBNhzaWDOgGA).gYfvSSlCQdvlHXoFtXExDLDXhhRu).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
						PJQkuKEhCscKikzlUmMohffWOdxeb pJQkuKEhCscKikzlUmMohffWOdxeb;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							pJQkuKEhCscKikzlUmMohffWOdxeb = this;
						}
						else
						{
							pJQkuKEhCscKikzlUmMohffWOdxeb = new PJQkuKEhCscKikzlUmMohffWOdxeb(0);
							pJQkuKEhCscKikzlUmMohffWOdxeb.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						pJQkuKEhCscKikzlUmMohffWOdxeb.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						pJQkuKEhCscKikzlUmMohffWOdxeb.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						pJQkuKEhCscKikzlUmMohffWOdxeb.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						return pJQkuKEhCscKikzlUmMohffWOdxeb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV;

				private readonly ControllerHelper TqAZNEcFJkyctXeLFKcYDRxOBxRA;

				private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
					tYEyiSjpdwwbqdDLYhlcYJwwGWGV = P_0;
					TqAZNEcFJkyctXeLFKcYDRxOBxRA = P_1;
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return GZUMXBOuruiXsXAwYxYJtPuTVDKK(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return bPskePCryZiGJFbDproSCOExBAUi(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return jgPbRXPhbfvUpBQFvglnVFxLGLhaA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return AlndKHEExHYfXtsMMnLpJpUJPAfE(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return GZUMXBOuruiXsXAwYxYJtPuTVDKK(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return bPskePCryZiGJFbDproSCOExBAUi(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return jgPbRXPhbfvUpBQFvglnVFxLGLhaA(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return AlndKHEExHYfXtsMMnLpJpUJPAfE(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return GZUMXBOuruiXsXAwYxYJtPuTVDKK(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return bPskePCryZiGJFbDproSCOExBAUi(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return jgPbRXPhbfvUpBQFvglnVFxLGLhaA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return AlndKHEExHYfXtsMMnLpJpUJPAfE(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return FpanjaLbBYGiaAzsgORMpIuvTFzcA(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return guJaYQgCyemeVHcnadaAHspgtBAsC(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return FSzAvRvrvzqRndtzvXAhbCloFeir(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return abphrPFTYxHWOFLGxqHoShTKIbGu(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return FpanjaLbBYGiaAzsgORMpIuvTFzcA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return guJaYQgCyemeVHcnadaAHspgtBAsC(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return FSzAvRvrvzqRndtzvXAhbCloFeir(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return abphrPFTYxHWOFLGxqHoShTKIbGu(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return FpanjaLbBYGiaAzsgORMpIuvTFzcA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return guJaYQgCyemeVHcnadaAHspgtBAsC(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return FSzAvRvrvzqRndtzvXAhbCloFeir(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return abphrPFTYxHWOFLGxqHoShTKIbGu(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return LHpfnweBUdMFysIpQplBdaTBIbuac(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return xjHCDXJeDVzjktQrOGaujUydvtYfc(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return xDqRqSZmjSAvIEiGPkywOxwjlLsHA(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return LHpfnweBUdMFysIpQplBdaTBIbuac(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return xjHCDXJeDVzjktQrOGaujUydvtYfc(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return xDqRqSZmjSAvIEiGPkywOxwjlLsHA(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return LHpfnweBUdMFysIpQplBdaTBIbuac(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return xjHCDXJeDVzjktQrOGaujUydvtYfc(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return xDqRqSZmjSAvIEiGPkywOxwjlLsHA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return SvkoWBXuCCOmzvopgZuGJNunUAxb(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return VtfrxlovDjJsBVJiMETYCvljTtjm(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return ykvViJJjdkKOGrdnNxRuEQFEzuMF(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return txRzuAeODldVVhKnrHOHytvHLVjp(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return SvkoWBXuCCOmzvopgZuGJNunUAxb(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Keyboard:
						return VtfrxlovDjJsBVJiMETYCvljTtjm(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Mouse:
						return ykvViJJjdkKOGrdnNxRuEQFEzuMF(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					case ControllerType.Custom:
						return txRzuAeODldVVhKnrHOHytvHLVjp(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					default:
						throw new NotImplementedException();
					}
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return SvkoWBXuCCOmzvopgZuGJNunUAxb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return VtfrxlovDjJsBVJiMETYCvljTtjm(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ykvViJJjdkKOGrdnNxRuEQFEzuMF(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return txRzuAeODldVVhKnrHOHytvHLVjp(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool GZUMXBOuruiXsXAwYxYJtPuTVDKK(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0 && cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Joystick, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu))
						{
							return true;
						}
					}
					return false;
				}

				private bool GZUMXBOuruiXsXAwYxYJtPuTVDKK(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0 && cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu))
						{
							return true;
						}
					}
					return false;
				}

				private bool GZUMXBOuruiXsXAwYxYJtPuTVDKK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0.controllerId && cVYxmFOOAvwehtZMCckKYcLmfisF(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu))
						{
							return true;
						}
					}
					return false;
				}

				private bool bPskePCryZiGJFbDproSCOExBAUi(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Keyboard, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private bool bPskePCryZiGJFbDproSCOExBAUi(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private bool bPskePCryZiGJFbDproSCOExBAUi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return cVYxmFOOAvwehtZMCckKYcLmfisF(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private bool jgPbRXPhbfvUpBQFvglnVFxLGLhaA(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Mouse, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private bool jgPbRXPhbfvUpBQFvglnVFxLGLhaA(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private bool jgPbRXPhbfvUpBQFvglnVFxLGLhaA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return cVYxmFOOAvwehtZMCckKYcLmfisF(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private bool AlndKHEExHYfXtsMMnLpJpUJPAfE(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0 && cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Custom, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu))
						{
							return true;
						}
					}
					return false;
				}

				private bool AlndKHEExHYfXtsMMnLpJpUJPAfE(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0 && cVYxmFOOAvwehtZMCckKYcLmfisF(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu))
						{
							return true;
						}
					}
					return false;
				}

				private bool AlndKHEExHYfXtsMMnLpJpUJPAfE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0.controllerId && cVYxmFOOAvwehtZMCckKYcLmfisF(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> FpanjaLbBYGiaAzsgORMpIuvTFzcA(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new IUUciTcTFPhjYNpzAptgdkeAcOzCb(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0,
						nHQaDnBIpPavKeTDoaJgzRaNsBFpA = P_1,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_2,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> FpanjaLbBYGiaAzsgORMpIuvTFzcA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new MeosLCAxqxPMpeCOLENTibkCHjdnA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0,
						nHQaDnBIpPavKeTDoaJgzRaNsBFpA = P_1,
						irfbfPdSapgmElNrHAavHgDhtrXec = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_4
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> FpanjaLbBYGiaAzsgORMpIuvTFzcA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new PJQkuKEhCscKikzlUmMohffWOdxeb(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> guJaYQgCyemeVHcnadaAHspgtBAsC(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Keyboard, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private IEnumerable<ElementAssignmentConflictInfo> guJaYQgCyemeVHcnadaAHspgtBAsC(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private IEnumerable<ElementAssignmentConflictInfo> guJaYQgCyemeVHcnadaAHspgtBAsC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return IvUzLqMedOsqEXZGEndrjvisgHCl(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private IEnumerable<ElementAssignmentConflictInfo> FSzAvRvrvzqRndtzvXAhbCloFeir(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Mouse, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private IEnumerable<ElementAssignmentConflictInfo> FSzAvRvrvzqRndtzvXAhbCloFeir(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return IvUzLqMedOsqEXZGEndrjvisgHCl(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private IEnumerable<ElementAssignmentConflictInfo> FSzAvRvrvzqRndtzvXAhbCloFeir(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return IvUzLqMedOsqEXZGEndrjvisgHCl(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private IEnumerable<ElementAssignmentConflictInfo> abphrPFTYxHWOFLGxqHoShTKIbGu(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new aqFezRdfUkqIWIUrgOMzWnNvMlWFB(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0,
						DajLgnbDjcVFpkPbeLaDtkbBtLmc = P_1,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_2,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> abphrPFTYxHWOFLGxqHoShTKIbGu(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new mSoboFzSjOXZqwwSGuYBTKxCgXTO(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0,
						DajLgnbDjcVFpkPbeLaDtkbBtLmc = P_1,
						irfbfPdSapgmElNrHAavHgDhtrXec = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_4
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> abphrPFTYxHWOFLGxqHoShTKIbGu(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new esHECTpHGYihKHGXkattbnHjjnzcB(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2
					};
				}

				private int cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Joystick, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu);
						}
					}
					return num;
				}

				private int cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu);
						}
					}
					return num;
				}

				private int cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0.controllerId)
						{
							num += JcUkdgPilwHQsSqwqaXrFlDURYiS(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu);
						}
					}
					return num;
				}

				private int LHpfnweBUdMFysIpQplBdaTBIbuac(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Keyboard, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private int LHpfnweBUdMFysIpQplBdaTBIbuac(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private int LHpfnweBUdMFysIpQplBdaTBIbuac(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return JcUkdgPilwHQsSqwqaXrFlDURYiS(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU);
				}

				private int xjHCDXJeDVzjktQrOGaujUydvtYfc(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Mouse, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private int xjHCDXJeDVzjktQrOGaujUydvtYfc(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private int xjHCDXJeDVzjktQrOGaujUydvtYfc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return JcUkdgPilwHQsSqwqaXrFlDURYiS(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD);
				}

				private int xDqRqSZmjSAvIEiGPkywOxwjlLsHA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Custom, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu);
						}
					}
					return num;
				}

				private int xDqRqSZmjSAvIEiGPkywOxwjlLsHA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += JcUkdgPilwHQsSqwqaXrFlDURYiS(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu);
						}
					}
					return num;
				}

				private int xDqRqSZmjSAvIEiGPkywOxwjlLsHA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0.controllerId)
						{
							num += JcUkdgPilwHQsSqwqaXrFlDURYiS(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu);
						}
					}
					return num;
				}

				private int SvkoWBXuCCOmzvopgZuGJNunUAxb(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Joystick, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu, P_4);
						}
					}
					return num;
				}

				private int SvkoWBXuCCOmzvopgZuGJNunUAxb(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu, P_5);
						}
					}
					return num;
				}

				private int SvkoWBXuCCOmzvopgZuGJNunUAxb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0.controllerId)
						{
							num += XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu, P_3);
						}
					}
					return num;
				}

				private int VtfrxlovDjJsBVJiMETYCvljTtjm(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Keyboard, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU, P_3);
				}

				private int VtfrxlovDjJsBVJiMETYCvljTtjm(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU, P_4);
				}

				private int VtfrxlovDjJsBVJiMETYCvljTtjm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.AVbKDPRWTeUtPIkeowuHdDONLIqU, P_3);
				}

				private int ykvViJJjdkKOGrdnNxRuEQFEzuMF(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Mouse, 0, P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD, P_3);
				}

				private int ykvViJJjdkKOGrdnNxRuEQFEzuMF(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD, P_4);
				}

				private int ykvViJJjdkKOGrdnNxRuEQFEzuMF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.PJxfZnmoRYSScdILDjxiruFcEPGD, P_3);
				}

				private int txRzuAeODldVVhKnrHOHytvHLVjp(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Custom, P_0, P_1, P_2, P_3, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu, P_4);
						}
					}
					return num;
				}

				private int txRzuAeODldVVhKnrHOHytvHLVjp(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							num += XnaIBtzabDEqOJGIptytUUvthXus(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu, P_5);
						}
					}
					return num;
				}

				private int txRzuAeODldVVhKnrHOHytvHLVjp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0.controllerId)
						{
							num += XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu, P_3);
						}
					}
					return num;
				}

				private bool cVYxmFOOAvwehtZMCckKYcLmfisF<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_5.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool cVYxmFOOAvwehtZMCckKYcLmfisF<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_6.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool cVYxmFOOAvwehtZMCckKYcLmfisF<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_3.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> IvUzLqMedOsqEXZGEndrjvisgHCl<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_5) where _0001 : ControllerMap
				{
					return new RbtoIoeNjlWsoplRlfeeyrNdFYwiA<_0001>(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						UGvErvwDJcvDvcPxeygBQxSeghqq = P_0,
						XAvUWQywgHgmxGxadxrDHDoOciNG = P_1,
						qmWlFVvGxfBcMzIKTlRzrfTaGKrl = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_4,
						OVeKqfJjvuNVyzvTfSZVFRbfGDFt = P_5
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> IvUzLqMedOsqEXZGEndrjvisgHCl<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_6) where _0001 : ControllerMap
				{
					return new iClTcIiKLXVbDajvyaOXPTCrnkYv<_0001>(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						UGvErvwDJcvDvcPxeygBQxSeghqq = P_0,
						XAvUWQywgHgmxGxadxrDHDoOciNG = P_1,
						qmWlFVvGxfBcMzIKTlRzrfTaGKrl = P_2,
						OApHoBHhleZnmfgFhkPsMrArjrnO = P_3,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_4,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_5,
						OVeKqfJjvuNVyzvTfSZVFRbfGDFt = P_6
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> IvUzLqMedOsqEXZGEndrjvisgHCl<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_3) where _0001 : ControllerMap
				{
					return new VovLrcfIKmoEAFgVqKJWOsqwJHqM<_0001>(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2,
						OVeKqfJjvuNVyzvTfSZVFRbfGDFt = P_3
					};
				}

				private int JcUkdgPilwHQsSqwqaXrFlDURYiS<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_5) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_5.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int JcUkdgPilwHQsSqwqaXrFlDURYiS<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_6.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int JcUkdgPilwHQsSqwqaXrFlDURYiS<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_3) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_3.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int XnaIBtzabDEqOJGIptytUUvthXus<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_5.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_5.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(mapCategory, controllerMap)))
						{
							num += controllerMap.XnaIBtzabDEqOJGIptytUUvthXus(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int XnaIBtzabDEqOJGIptytUUvthXus<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_6.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(inputMapCategory, controllerMap)))
						{
							num += controllerMap.XnaIBtzabDEqOJGIptytUUvthXus(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int XnaIBtzabDEqOJGIptytUUvthXus<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
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
					for (int i = 0; i < P_3.DLziBsJZuZhaylJgkqoiHaUPORcx(); i++)
					{
						ControllerMap controllerMap = P_3.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !LzZQEPNuwImsAaFFhULmFDaPtPZy(inputMapCategory, controllerMap)))
						{
							num += controllerMap.XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool LzZQEPNuwImsAaFFhULmFDaPtPZy(InputMapCategory P_0, ControllerMap P_1)
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
			internal interface nUMJXuTXYTQLuvshdhtoVCFirCzU
			{
				sOqjGwajlbTzcTCmBjowEffZChuAb TOeQjtXAmEJKcihHdegXiMOIfTTY { get; }

				ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK { get; }

				int ZQqQltuirEhRybMOxWCRGTiKWPGW { get; }

				bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(Controller P_0);

				bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(int P_0);

				void IxFqxZIAiVbfdZQpsgscCLjEykOMA(int P_0);

				void IxFqxZIAiVbfdZQpsgscCLjEykOMA(Controller P_0);

				void fryvpKcsKNOTszIpycKowSnDVcct(int P_0);

				Controller gAPABsuepoxQLaHJJhjKlywBeNAd(int P_0);

				Controller MfaqjmeWeRxfLpVEUprLRtESfATi(string P_0);

				int PujFpIgnaejxCcbCzrcoRIpZaecab(Controller P_0);

				int PujFpIgnaejxCcbCzrcoRIpZaecab(int P_0);

				int LyWaQjhUsbqwstDlyqashQZEBNglc(string P_0);

				void wJjPIIRJfHhEbGedUconecGfiwzgB();

				sOqjGwajlbTzcTCmBjowEffZChuAb jcQIPleqWWsZNlvEYGkHBahJWVvN(int P_0);

				sOqjGwajlbTzcTCmBjowEffZChuAb jcQIPleqWWsZNlvEYGkHBahJWVvN(Controller P_0);

				void tYMyBEevSVHNsMkZbTQKkymAqAxR(sOqjGwajlbTzcTCmBjowEffZChuAb P_0);
			}

			internal interface sOqjGwajlbTzcTCmBjowEffZChuAb
			{
				zWbUQgTovQtSYwaKIfEFDBCoWmolA gYfvSSlCQdvlHXoFtXExDLDXhhRu { get; }

				Controller yBVYaZymnHfILCjQopwadWNgxbeH { get; }

				double VwJrKGtqkVWatknkuEeZyTsQsrAc { get; }
			}

			[DefaultMember("Item")]
			internal sealed class bWznjLeWeHSDvTNXqXHswVZMMsQb<_0001, _0002> : nUMJXuTXYTQLuvshdhtoVCFirCzU where _0001 : Controller where _0002 : ControllerMap
			{
				public class gUNePuOAXTTEQajyoClOIDiOHUoU : sOqjGwajlbTzcTCmBjowEffZChuAb
				{
					public _0001 yBVYaZymnHfILCjQopwadWNgxbeH;

					public BNyqYlWalrCfOzrCabaRaoJZBeLP<_0002> gYfvSSlCQdvlHXoFtXExDLDXhhRu;

					public double VwJrKGtqkVWatknkuEeZyTsQsrAc;

					Controller sOqjGwajlbTzcTCmBjowEffZChuAb.UbLJSrKoKfARTfsyXWCouJyrymrc => yBVYaZymnHfILCjQopwadWNgxbeH;

					zWbUQgTovQtSYwaKIfEFDBCoWmolA sOqjGwajlbTzcTCmBjowEffZChuAb.pNpXNVxaiFIaSxkqLCOEzOLRTNVR => gYfvSSlCQdvlHXoFtXExDLDXhhRu;

					double sOqjGwajlbTzcTCmBjowEffZChuAb.VgAzzUeqzdywkScmkJJtmAbnnCLI => VwJrKGtqkVWatknkuEeZyTsQsrAc;

					public gUNePuOAXTTEQajyoClOIDiOHUoU(_0001 P_0, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0002> P_1)
					{
						yBVYaZymnHfILCjQopwadWNgxbeH = P_0;
						gYfvSSlCQdvlHXoFtXExDLDXhhRu = P_1;
					}

					public void IlUOIvCsKbaokuBeHIhLqfpLIMMQ()
					{
						VwJrKGtqkVWatknkuEeZyTsQsrAc = ReInput.unscaledTime;
					}
				}

				private List<gUNePuOAXTTEQajyoClOIDiOHUoU> YWqICyZAZaepLWeAIxsfAwguINSd;

				private List<_0001> tkSEiOzjDjtUGfqufnQnNdVwHOzv;

				private ReadOnlyCollection<_0001> ASZUuTcTfdCGRMuzbKguFwieaxUm;

				private readonly ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

				int nUMJXuTXYTQLuvshdhtoVCFirCzU.ZQqQltuirEhRybMOxWCRGTiKWPGW => YWqICyZAZaepLWeAIxsfAwguINSd.Count;

				public IList<_0001> obQHJhFYcXmdSoAwadTzguTKNZpjA => ASZUuTcTfdCGRMuzbKguFwieaxUm;

				public gUNePuOAXTTEQajyoClOIDiOHUoU TOeQjtXAmEJKcihHdegXiMOIfTTY => YWqICyZAZaepLWeAIxsfAwguINSd[P_0];

				ControllerType nUMJXuTXYTQLuvshdhtoVCFirCzU.JZuBcglRGrLdTTkjRHBAWiKZgoVK => ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

				sOqjGwajlbTzcTCmBjowEffZChuAb nUMJXuTXYTQLuvshdhtoVCFirCzU.GxrOwPLzYsdVwBUutuTsmAwaFCkl => YWqICyZAZaepLWeAIxsfAwguINSd[P_0];

				public bWznjLeWeHSDvTNXqXHswVZMMsQb()
				{
					if ((object)uAOMfTHsnTLbvEUpHTchXYOhMgjh.BPPAFbbDFtiDUWhQIPhrffpUyeUtA<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					ueTsfWyPNTdEyAOjfZNcYrBGNSmq = uAOMfTHsnTLbvEUpHTchXYOhMgjh.dCDiSNmXZWjCxMjhOfIfIHAULWGO(typeof(_0001));
					YWqICyZAZaepLWeAIxsfAwguINSd = new List<gUNePuOAXTTEQajyoClOIDiOHUoU>();
					tkSEiOzjDjtUGfqufnQnNdVwHOzv = new List<_0001>();
					ASZUuTcTfdCGRMuzbKguFwieaxUm = new ReadOnlyCollection<_0001>(tkSEiOzjDjtUGfqufnQnNdVwHOzv);
				}

				public gUNePuOAXTTEQajyoClOIDiOHUoU jcQIPleqWWsZNlvEYGkHBahJWVvN(int P_0)
				{
					if (ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Keyboard || ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = PujFpIgnaejxCcbCzrcoRIpZaecab(P_0);
					if (num < 0)
					{
						return null;
					}
					return YWqICyZAZaepLWeAIxsfAwguINSd[num];
				}

				public gUNePuOAXTTEQajyoClOIDiOHUoU jcQIPleqWWsZNlvEYGkHBahJWVvN(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return jcQIPleqWWsZNlvEYGkHBahJWVvN(P_0.id);
				}

				public void tYMyBEevSVHNsMkZbTQKkymAqAxR(gUNePuOAXTTEQajyoClOIDiOHUoU P_0)
				{
					if (P_0 != null)
					{
						YWqICyZAZaepLWeAIxsfAwguINSd.Add(P_0);
						tkSEiOzjDjtUGfqufnQnNdVwHOzv.Add(P_0.yBVYaZymnHfILCjQopwadWNgxbeH);
					}
				}

				public void IxFqxZIAiVbfdZQpsgscCLjEykOMA(int P_0)
				{
					if (ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Keyboard || ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (PujFpIgnaejxCcbCzrcoRIpZaecab(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Count; i++)
					{
						if (YWqICyZAZaepLWeAIxsfAwguINSd[i].yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							fryvpKcsKNOTszIpycKowSnDVcct(i);
							break;
						}
					}
				}

				void nUMJXuTXYTQLuvshdhtoVCFirCzU.IxFqxZIAiVbfdZQpsgscCLjEykOMA(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in IxFqxZIAiVbfdZQpsgscCLjEykOMA
					this.IxFqxZIAiVbfdZQpsgscCLjEykOMA(P_0);
				}

				public void IxFqxZIAiVbfdZQpsgscCLjEykOMA(_0001 P_0)
				{
					if (P_0 != null && P_0.type == ueTsfWyPNTdEyAOjfZNcYrBGNSmq)
					{
						IxFqxZIAiVbfdZQpsgscCLjEykOMA(P_0.id);
					}
				}

				public void fryvpKcsKNOTszIpycKowSnDVcct(int P_0)
				{
					if (P_0 >= 0 && P_0 < YWqICyZAZaepLWeAIxsfAwguINSd.Count)
					{
						YWqICyZAZaepLWeAIxsfAwguINSd.RemoveAt(P_0);
						tkSEiOzjDjtUGfqufnQnNdVwHOzv.RemoveAt(P_0);
					}
				}

				void nUMJXuTXYTQLuvshdhtoVCFirCzU.fryvpKcsKNOTszIpycKowSnDVcct(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in fryvpKcsKNOTszIpycKowSnDVcct
					this.fryvpKcsKNOTszIpycKowSnDVcct(P_0);
				}

				public _0001 gAPABsuepoxQLaHJJhjKlywBeNAd(int P_0)
				{
					if (ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Keyboard || ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = PujFpIgnaejxCcbCzrcoRIpZaecab(P_0);
					if (num < 0)
					{
						return null;
					}
					return YWqICyZAZaepLWeAIxsfAwguINSd[num].yBVYaZymnHfILCjQopwadWNgxbeH;
				}

				public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(int P_0)
				{
					if (ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Keyboard || ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Count; i++)
					{
						if (YWqICyZAZaepLWeAIxsfAwguINSd[i].yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool nUMJXuTXYTQLuvshdhtoVCFirCzU.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in XrqcBMeuSMEFFHtBARTfiYGSMlVMB
					return this.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0);
				}

				public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != ueTsfWyPNTdEyAOjfZNcYrBGNSmq)
					{
						return false;
					}
					return XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0.id);
				}

				public int PujFpIgnaejxCcbCzrcoRIpZaecab(int P_0)
				{
					if (ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Keyboard || ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Count; i++)
					{
						if (YWqICyZAZaepLWeAIxsfAwguINSd[i].yBVYaZymnHfILCjQopwadWNgxbeH.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int nUMJXuTXYTQLuvshdhtoVCFirCzU.PujFpIgnaejxCcbCzrcoRIpZaecab(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in PujFpIgnaejxCcbCzrcoRIpZaecab
					return this.PujFpIgnaejxCcbCzrcoRIpZaecab(P_0);
				}

				public int PujFpIgnaejxCcbCzrcoRIpZaecab(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != ueTsfWyPNTdEyAOjfZNcYrBGNSmq)
					{
						return -1;
					}
					return PujFpIgnaejxCcbCzrcoRIpZaecab(P_0.id);
				}

				public int LyWaQjhUsbqwstDlyqashQZEBNglc(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Count; i++)
					{
						if (YWqICyZAZaepLWeAIxsfAwguINSd[i].yBVYaZymnHfILCjQopwadWNgxbeH.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int nUMJXuTXYTQLuvshdhtoVCFirCzU.LyWaQjhUsbqwstDlyqashQZEBNglc(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in LyWaQjhUsbqwstDlyqashQZEBNglc
					return this.LyWaQjhUsbqwstDlyqashQZEBNglc(P_0);
				}

				public void wJjPIIRJfHhEbGedUconecGfiwzgB()
				{
					YWqICyZAZaepLWeAIxsfAwguINSd.Clear();
					tkSEiOzjDjtUGfqufnQnNdVwHOzv.Clear();
				}

				void nUMJXuTXYTQLuvshdhtoVCFirCzU.wJjPIIRJfHhEbGedUconecGfiwzgB()
				{
					//ILSpy generated this explicit interface implementation from .override directive in wJjPIIRJfHhEbGedUconecGfiwzgB
					this.wJjPIIRJfHhEbGedUconecGfiwzgB();
				}

				private sOqjGwajlbTzcTCmBjowEffZChuAb rajMOHiYcyIDPcewTxqBLsBxgRbc(int P_0)
				{
					return jcQIPleqWWsZNlvEYGkHBahJWVvN(P_0);
				}

				sOqjGwajlbTzcTCmBjowEffZChuAb nUMJXuTXYTQLuvshdhtoVCFirCzU.jcQIPleqWWsZNlvEYGkHBahJWVvN(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in rajMOHiYcyIDPcewTxqBLsBxgRbc
					return this.rajMOHiYcyIDPcewTxqBLsBxgRbc(P_0);
				}

				private sOqjGwajlbTzcTCmBjowEffZChuAb rajMOHiYcyIDPcewTxqBLsBxgRbc(Controller P_0)
				{
					if (P_0 as _0001 == null)
					{
						return null;
					}
					return jcQIPleqWWsZNlvEYGkHBahJWVvN(P_0 as _0001);
				}

				sOqjGwajlbTzcTCmBjowEffZChuAb nUMJXuTXYTQLuvshdhtoVCFirCzU.jcQIPleqWWsZNlvEYGkHBahJWVvN(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in rajMOHiYcyIDPcewTxqBLsBxgRbc
					return this.rajMOHiYcyIDPcewTxqBLsBxgRbc(P_0);
				}

				private void lBoJvKqUWHkocdwkvqVyPKZcfQLHA(sOqjGwajlbTzcTCmBjowEffZChuAb P_0)
				{
					tYMyBEevSVHNsMkZbTQKkymAqAxR((gUNePuOAXTTEQajyoClOIDiOHUoU)P_0);
				}

				void nUMJXuTXYTQLuvshdhtoVCFirCzU.tYMyBEevSVHNsMkZbTQKkymAqAxR(sOqjGwajlbTzcTCmBjowEffZChuAb P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in lBoJvKqUWHkocdwkvqVyPKZcfQLHA
					this.lBoJvKqUWHkocdwkvqVyPKZcfQLHA(P_0);
				}

				private void AbXotYwoWVbsahBnfQmrxdquvQeG(Controller P_0)
				{
					IxFqxZIAiVbfdZQpsgscCLjEykOMA(P_0 as _0001);
				}

				void nUMJXuTXYTQLuvshdhtoVCFirCzU.IxFqxZIAiVbfdZQpsgscCLjEykOMA(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in AbXotYwoWVbsahBnfQmrxdquvQeG
					this.AbXotYwoWVbsahBnfQmrxdquvQeG(P_0);
				}

				private Controller PEBjVdgoyMlHFDVCdygGEFrKFAODc(int P_0)
				{
					return gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
				}

				Controller nUMJXuTXYTQLuvshdhtoVCFirCzU.gAPABsuepoxQLaHJJhjKlywBeNAd(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in PEBjVdgoyMlHFDVCdygGEFrKFAODc
					return this.PEBjVdgoyMlHFDVCdygGEFrKFAODc(P_0);
				}

				private bool zXihpfPMYhponGMWEvtVRtzEAJBf(Controller P_0)
				{
					return XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0 as _0001);
				}

				bool nUMJXuTXYTQLuvshdhtoVCFirCzU.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in zXihpfPMYhponGMWEvtVRtzEAJBf
					return this.zXihpfPMYhponGMWEvtVRtzEAJBf(P_0);
				}

				private int BvlkVbNDTZzDUHoeJWuApEERIivG(Controller P_0)
				{
					return PujFpIgnaejxCcbCzrcoRIpZaecab(P_0 as _0001);
				}

				int nUMJXuTXYTQLuvshdhtoVCFirCzU.PujFpIgnaejxCcbCzrcoRIpZaecab(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in BvlkVbNDTZzDUHoeJWuApEERIivG
					return this.BvlkVbNDTZzDUHoeJWuApEERIivG(P_0);
				}

				private Controller OHbbkXhjmXdzlxhVHrqhaDKPJnHs(string P_0)
				{
					int num = LyWaQjhUsbqwstDlyqashQZEBNglc(P_0);
					if (num < 0)
					{
						return null;
					}
					return YWqICyZAZaepLWeAIxsfAwguINSd[num].yBVYaZymnHfILCjQopwadWNgxbeH;
				}

				Controller nUMJXuTXYTQLuvshdhtoVCFirCzU.MfaqjmeWeRxfLpVEUprLRtESfATi(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in OHbbkXhjmXdzlxhVHrqhaDKPJnHs
					return this.OHbbkXhjmXdzlxhVHrqhaDKPJnHs(P_0);
				}
			}

			internal class jNBSQHQFEwfOYkOuniRstKTZlZDy
			{
				public readonly int ZQqQltuirEhRybMOxWCRGTiKWPGW;

				private ControllerType[] vrLFpCEbcqwkasUgOcfVPMbMaFmV;

				private nUMJXuTXYTQLuvshdhtoVCFirCzU[] YLSXrUlzZZpcZwTTaOxvYAMSOmKQ;

				public nUMJXuTXYTQLuvshdhtoVCFirCzU UaPXSbLpVTkKprByyepiorcSlOWH(int P_0)
				{
					return YLSXrUlzZZpcZwTTaOxvYAMSOmKQ[P_0];
				}

				public ControllerType gNOEbBClxcJMmDKnoysbMauBfOjX(int P_0)
				{
					return vrLFpCEbcqwkasUgOcfVPMbMaFmV[P_0];
				}

				public jNBSQHQFEwfOYkOuniRstKTZlZDy(int P_0)
				{
					ZQqQltuirEhRybMOxWCRGTiKWPGW = MathTools.Max(0, P_0);
					vrLFpCEbcqwkasUgOcfVPMbMaFmV = new ControllerType[P_0];
					YLSXrUlzZZpcZwTTaOxvYAMSOmKQ = new nUMJXuTXYTQLuvshdhtoVCFirCzU[P_0];
				}

				public nUMJXuTXYTQLuvshdhtoVCFirCzU KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType P_0)
				{
					for (int i = 0; i < ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						if (P_0 == vrLFpCEbcqwkasUgOcfVPMbMaFmV[i])
						{
							return YLSXrUlzZZpcZwTTaOxvYAMSOmKQ[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void ftQlYzLUxILQoPXvwgamKMqUEnsiA(int P_0, ControllerType P_1, nUMJXuTXYTQLuvshdhtoVCFirCzU P_2)
				{
					vrLFpCEbcqwkasUgOcfVPMbMaFmV[P_0] = P_1;
					YLSXrUlzZZpcZwTTaOxvYAMSOmKQ[P_0] = P_2;
				}
			}

			private class mdyLmCgBkWJXboeOKOYPVOgtbend
			{
				public class ELbCLVCdwSPLHPUkhCTLNYpoZUSp
				{
					public int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> gYfvSSlCQdvlHXoFtXExDLDXhhRu;

					public double oxZBwgdegRLKVSbsFSMljJNBHkup;

					public ELbCLVCdwSPLHPUkhCTLNYpoZUSp(int P_0, BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> P_1, double P_2)
					{
						ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = P_0;
						gYfvSSlCQdvlHXoFtXExDLDXhhRu = P_1;
						oxZBwgdegRLKVSbsFSMljJNBHkup = P_2;
					}
				}

				private readonly List<ELbCLVCdwSPLHPUkhCTLNYpoZUSp> kPbexRcNIgkoIUHQQYRQrEHvMBzi;

				private readonly Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV;

				public mdyLmCgBkWJXboeOKOYPVOgtbend(Player P_0)
				{
					tYEyiSjpdwwbqdDLYhlcYJwwGWGV = P_0;
					kPbexRcNIgkoIUHQQYRQrEHvMBzi = new List<ELbCLVCdwSPLHPUkhCTLNYpoZUSp>();
				}

				public void etdZpFVoMIOwufjLtmaknStPcvGU(Joystick P_0, BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> P_1)
				{
					for (int i = 0; i < kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count; i++)
					{
						ELbCLVCdwSPLHPUkhCTLNYpoZUSp eLbCLVCdwSPLHPUkhCTLNYpoZUSp = kPbexRcNIgkoIUHQQYRQrEHvMBzi[i];
						if (eLbCLVCdwSPLHPUkhCTLNYpoZUSp.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC == P_0.id)
						{
							eLbCLVCdwSPLHPUkhCTLNYpoZUSp.gYfvSSlCQdvlHXoFtXExDLDXhhRu = P_1;
							eLbCLVCdwSPLHPUkhCTLNYpoZUSp.oxZBwgdegRLKVSbsFSMljJNBHkup = ReInput.realTime;
							return;
						}
					}
					ELbCLVCdwSPLHPUkhCTLNYpoZUSp item = new ELbCLVCdwSPLHPUkhCTLNYpoZUSp(P_0.id, P_1, ReInput.realTime);
					kPbexRcNIgkoIUHQQYRQrEHvMBzi.Add(item);
				}

				public void etdZpFVoMIOwufjLtmaknStPcvGU(bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU P_0)
				{
					etdZpFVoMIOwufjLtmaknStPcvGU(P_0.yBVYaZymnHfILCjQopwadWNgxbeH, P_0.gYfvSSlCQdvlHXoFtXExDLDXhhRu);
				}

				public void ulPBypIpiDZHdSjLKAnGIFgoEIuI()
				{
					for (int i = 0; i < kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count; i++)
					{
						if (!tYEyiSjpdwwbqdDLYhlcYJwwGWGV.controllers.ContainsController(ControllerType.Joystick, kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].ZRqGPmiZYbBMxFgPHLFMZTmGNtUC))
						{
							kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].gYfvSSlCQdvlHXoFtXExDLDXhhRu = null;
						}
					}
				}

				public ELbCLVCdwSPLHPUkhCTLNYpoZUSp VLYfOpamoUspknlbDaegsxFBZShK(int P_0)
				{
					int num = PujFpIgnaejxCcbCzrcoRIpZaecab(P_0);
					if (num < 0)
					{
						return null;
					}
					return kPbexRcNIgkoIUHQQYRQrEHvMBzi[num];
				}

				public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(int P_0)
				{
					for (int i = 0; i < kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count; i++)
					{
						if (kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].ZRqGPmiZYbBMxFgPHLFMZTmGNtUC == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int PujFpIgnaejxCcbCzrcoRIpZaecab(int P_0)
				{
					for (int i = 0; i < kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count; i++)
					{
						if (kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].ZRqGPmiZYbBMxFgPHLFMZTmGNtUC == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void wJjPIIRJfHhEbGedUconecGfiwzgB()
				{
					kPbexRcNIgkoIUHQQYRQrEHvMBzi.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class DwNulXMGVjXBJyXLovObdlifguyhA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private int WMSfvXvKrxbLMoEvsaLAsMlIcsUw;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU uljbftxXIVJdHismIWUtpcHQUzzQ;

					private int EsUJEQZITdaNcCAqEhVQzaWsPdOZ;

					private int lzxcEIfPbLrgzCYMIFfPEFYSGRZlA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA IUMzVDWIxDdAoLnsDKWcECYzEdwO;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					private IEnumerator<ActionElementMap> rMdmteecWoSAcwTJktclkGasrQQl;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public DwNulXMGVjXBJyXLovObdlifguyhA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0177;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
							{
								ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
								return false;
							}
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							WMSfvXvKrxbLMoEvsaLAsMlIcsUw = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_01f7;
							IL_0177:
							if (rMdmteecWoSAcwTJktclkGasrQQl.MoveNext())
							{
								ActionElementMap current = rMdmteecWoSAcwTJktclkGasrQQl.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							rMdmteecWoSAcwTJktclkGasrQQl = null;
							goto IL_0191;
							IL_0191:
							mIvawggAsicKJrIkGTVLQUHFwCBbA++;
							goto IL_01a3;
							IL_01cd:
							if (lzxcEIfPbLrgzCYMIFfPEFYSGRZlA < EsUJEQZITdaNcCAqEhVQzaWsPdOZ)
							{
								IUMzVDWIxDdAoLnsDKWcECYzEdwO = uljbftxXIVJdHismIWUtpcHQUzzQ.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lzxcEIfPbLrgzCYMIFfPEFYSGRZlA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								iTuojJSPVkJDjnJynjDwbzNuaknW = IUMzVDWIxDdAoLnsDKWcECYzEdwO.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
								goto IL_01a3;
							}
							uljbftxXIVJdHismIWUtpcHQUzzQ = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_01f7;
							IL_01a3:
							if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
							{
								if (IUMzVDWIxDdAoLnsDKWcECYzEdwO.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA) is ControllerMapWithAxes controllerMapWithAxes && (!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									rMdmteecWoSAcwTJktclkGasrQQl = controllerMapWithAxes.AxisMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							IUMzVDWIxDdAoLnsDKWcECYzEdwO = null;
							lzxcEIfPbLrgzCYMIFfPEFYSGRZlA++;
							goto IL_01cd;
							IL_01f7:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < WMSfvXvKrxbLMoEvsaLAsMlIcsUw)
							{
								uljbftxXIVJdHismIWUtpcHQUzzQ = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
								EsUJEQZITdaNcCAqEhVQzaWsPdOZ = uljbftxXIVJdHismIWUtpcHQUzzQ.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								lzxcEIfPbLrgzCYMIFfPEFYSGRZlA = 0;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (rMdmteecWoSAcwTJktclkGasrQQl != null)
						{
							rMdmteecWoSAcwTJktclkGasrQQl.Dispose();
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
						DwNulXMGVjXBJyXLovObdlifguyhA dwNulXMGVjXBJyXLovObdlifguyhA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							dwNulXMGVjXBJyXLovObdlifguyhA = this;
						}
						else
						{
							dwNulXMGVjXBJyXLovObdlifguyhA = new DwNulXMGVjXBJyXLovObdlifguyhA(0);
							dwNulXMGVjXBJyXLovObdlifguyhA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						dwNulXMGVjXBJyXLovObdlifguyhA.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						dwNulXMGVjXBJyXLovObdlifguyhA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return dwNulXMGVjXBJyXLovObdlifguyhA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class SgpjvFtGtzWiLiKkuIyedTntCMOSA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private int WMSfvXvKrxbLMoEvsaLAsMlIcsUw;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU uljbftxXIVJdHismIWUtpcHQUzzQ;

					private int EsUJEQZITdaNcCAqEhVQzaWsPdOZ;

					private int lzxcEIfPbLrgzCYMIFfPEFYSGRZlA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA IUMzVDWIxDdAoLnsDKWcECYzEdwO;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					private IEnumerator<ActionElementMap> rMdmteecWoSAcwTJktclkGasrQQl;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public SgpjvFtGtzWiLiKkuIyedTntCMOSA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_016c;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
							{
								ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
								return false;
							}
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							WMSfvXvKrxbLMoEvsaLAsMlIcsUw = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_01ec;
							IL_016c:
							if (rMdmteecWoSAcwTJktclkGasrQQl.MoveNext())
							{
								ActionElementMap current = rMdmteecWoSAcwTJktclkGasrQQl.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							rMdmteecWoSAcwTJktclkGasrQQl = null;
							goto IL_0186;
							IL_0186:
							mIvawggAsicKJrIkGTVLQUHFwCBbA++;
							goto IL_0198;
							IL_01c2:
							if (lzxcEIfPbLrgzCYMIFfPEFYSGRZlA < EsUJEQZITdaNcCAqEhVQzaWsPdOZ)
							{
								IUMzVDWIxDdAoLnsDKWcECYzEdwO = uljbftxXIVJdHismIWUtpcHQUzzQ.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lzxcEIfPbLrgzCYMIFfPEFYSGRZlA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								iTuojJSPVkJDjnJynjDwbzNuaknW = IUMzVDWIxDdAoLnsDKWcECYzEdwO.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
								goto IL_0198;
							}
							uljbftxXIVJdHismIWUtpcHQUzzQ = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_01ec;
							IL_0198:
							if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
							{
								ControllerMap controllerMap = IUMzVDWIxDdAoLnsDKWcECYzEdwO.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA);
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMap.enabled) && controllerMap.ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									rMdmteecWoSAcwTJktclkGasrQQl = controllerMap.ButtonMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							IUMzVDWIxDdAoLnsDKWcECYzEdwO = null;
							lzxcEIfPbLrgzCYMIFfPEFYSGRZlA++;
							goto IL_01c2;
							IL_01ec:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < WMSfvXvKrxbLMoEvsaLAsMlIcsUw)
							{
								uljbftxXIVJdHismIWUtpcHQUzzQ = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
								EsUJEQZITdaNcCAqEhVQzaWsPdOZ = uljbftxXIVJdHismIWUtpcHQUzzQ.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								lzxcEIfPbLrgzCYMIFfPEFYSGRZlA = 0;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (rMdmteecWoSAcwTJktclkGasrQQl != null)
						{
							rMdmteecWoSAcwTJktclkGasrQQl.Dispose();
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
						SgpjvFtGtzWiLiKkuIyedTntCMOSA sgpjvFtGtzWiLiKkuIyedTntCMOSA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							sgpjvFtGtzWiLiKkuIyedTntCMOSA = this;
						}
						else
						{
							sgpjvFtGtzWiLiKkuIyedTntCMOSA = new SgpjvFtGtzWiLiKkuIyedTntCMOSA(0);
							sgpjvFtGtzWiLiKkuIyedTntCMOSA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						sgpjvFtGtzWiLiKkuIyedTntCMOSA.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						sgpjvFtGtzWiLiKkuIyedTntCMOSA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return sgpjvFtGtzWiLiKkuIyedTntCMOSA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class BbmzxARKpLawonENdlRXYQELVDlv : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IList<ControllerMap> GFHbunybglKeLtZgrJNdoqtkyeeW;

					private int tdwXqnewaJsEvqbhYEOsNMqnLdFN;

					private IEnumerator<ActionElementMap> ceWXjKiKEhVRMBdWSWJrDlcGmNsn;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public BbmzxARKpLawonENdlRXYQELVDlv(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0150;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_01ab;
							IL_0150:
							if (ceWXjKiKEhVRMBdWSWJrDlcGmNsn.MoveNext())
							{
								ActionElementMap current = ceWXjKiKEhVRMBdWSWJrDlcGmNsn.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							ceWXjKiKEhVRMBdWSWJrDlcGmNsn = null;
							goto IL_016a;
							IL_017c:
							if (tdwXqnewaJsEvqbhYEOsNMqnLdFN < GFHbunybglKeLtZgrJNdoqtkyeeW.Count)
							{
								if (!(GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].enabled) && GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									ceWXjKiKEhVRMBdWSWJrDlcGmNsn = (GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN] as ControllerMapWithAxes).AxisMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							GFHbunybglKeLtZgrJNdoqtkyeeW = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_01ab;
							IL_016a:
							tdwXqnewaJsEvqbhYEOsNMqnLdFN++;
							goto IL_017c;
							IL_01ab:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW)
							{
								GFHbunybglKeLtZgrJNdoqtkyeeW = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(PrfhaiCANHhjwtWLxlpNIHvkLSmF).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
								tdwXqnewaJsEvqbhYEOsNMqnLdFN = 0;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ceWXjKiKEhVRMBdWSWJrDlcGmNsn != null)
						{
							ceWXjKiKEhVRMBdWSWJrDlcGmNsn.Dispose();
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
						BbmzxARKpLawonENdlRXYQELVDlv bbmzxARKpLawonENdlRXYQELVDlv;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							bbmzxARKpLawonENdlRXYQELVDlv = this;
						}
						else
						{
							bbmzxARKpLawonENdlRXYQELVDlv = new BbmzxARKpLawonENdlRXYQELVDlv(0);
							bbmzxARKpLawonENdlRXYQELVDlv.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						bbmzxARKpLawonENdlRXYQELVDlv.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						bbmzxARKpLawonENdlRXYQELVDlv.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						bbmzxARKpLawonENdlRXYQELVDlv.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return bbmzxARKpLawonENdlRXYQELVDlv;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class JVVsbpjVqOISBlGewhtTzOvzdUbM : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private IList<ControllerMap> wxOWIycVdZxNjHKVLklWBOWcSZUI;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ActionElementMap> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public JVVsbpjVqOISBlGewhtTzOvzdUbM(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_014f;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
							int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(JMclHNzguIWZrgtWkveVPuuQQUBf);
							if (num2 < 0)
							{
								return false;
							}
							wxOWIycVdZxNjHKVLklWBOWcSZUI = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num2).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_017b;
							IL_014f:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ActionElementMap current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							goto IL_0169;
							IL_017b:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wxOWIycVdZxNjHKVLklWBOWcSZUI.Count)
							{
								if (!(wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].enabled) && wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									BhdWnHwETjTwooLnNokUmKQRiiPK = (wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF] as ControllerMapWithAxes).AxisMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						JVVsbpjVqOISBlGewhtTzOvzdUbM jVVsbpjVqOISBlGewhtTzOvzdUbM;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							jVVsbpjVqOISBlGewhtTzOvzdUbM = this;
						}
						else
						{
							jVVsbpjVqOISBlGewhtTzOvzdUbM = new JVVsbpjVqOISBlGewhtTzOvzdUbM(0);
							jVVsbpjVqOISBlGewhtTzOvzdUbM.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						jVVsbpjVqOISBlGewhtTzOvzdUbM.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						jVVsbpjVqOISBlGewhtTzOvzdUbM.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						jVVsbpjVqOISBlGewhtTzOvzdUbM.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						jVVsbpjVqOISBlGewhtTzOvzdUbM.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return jVVsbpjVqOISBlGewhtTzOvzdUbM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class AUKZShrKlbTRYiYmNGpwpIDMxzee : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IList<ControllerMap> GFHbunybglKeLtZgrJNdoqtkyeeW;

					private int tdwXqnewaJsEvqbhYEOsNMqnLdFN;

					private IEnumerator<ActionElementMap> ceWXjKiKEhVRMBdWSWJrDlcGmNsn;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public AUKZShrKlbTRYiYmNGpwpIDMxzee(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_012c;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0187;
							IL_012c:
							if (ceWXjKiKEhVRMBdWSWJrDlcGmNsn.MoveNext())
							{
								ActionElementMap current = ceWXjKiKEhVRMBdWSWJrDlcGmNsn.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							ceWXjKiKEhVRMBdWSWJrDlcGmNsn = null;
							goto IL_0146;
							IL_0158:
							if (tdwXqnewaJsEvqbhYEOsNMqnLdFN < GFHbunybglKeLtZgrJNdoqtkyeeW.Count)
							{
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].enabled) && GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									ceWXjKiKEhVRMBdWSWJrDlcGmNsn = GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].ButtonMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							GFHbunybglKeLtZgrJNdoqtkyeeW = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_0187;
							IL_0146:
							tdwXqnewaJsEvqbhYEOsNMqnLdFN++;
							goto IL_0158;
							IL_0187:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW)
							{
								GFHbunybglKeLtZgrJNdoqtkyeeW = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(PrfhaiCANHhjwtWLxlpNIHvkLSmF).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
								tdwXqnewaJsEvqbhYEOsNMqnLdFN = 0;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ceWXjKiKEhVRMBdWSWJrDlcGmNsn != null)
						{
							ceWXjKiKEhVRMBdWSWJrDlcGmNsn.Dispose();
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
						AUKZShrKlbTRYiYmNGpwpIDMxzee aUKZShrKlbTRYiYmNGpwpIDMxzee;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							aUKZShrKlbTRYiYmNGpwpIDMxzee = this;
						}
						else
						{
							aUKZShrKlbTRYiYmNGpwpIDMxzee = new AUKZShrKlbTRYiYmNGpwpIDMxzee(0);
							aUKZShrKlbTRYiYmNGpwpIDMxzee.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						aUKZShrKlbTRYiYmNGpwpIDMxzee.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						aUKZShrKlbTRYiYmNGpwpIDMxzee.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						aUKZShrKlbTRYiYmNGpwpIDMxzee.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return aUKZShrKlbTRYiYmNGpwpIDMxzee;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class raVymdmwGdkqEmSuCglXjBhczrMD : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private IList<ControllerMap> wxOWIycVdZxNjHKVLklWBOWcSZUI;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ActionElementMap> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public raVymdmwGdkqEmSuCglXjBhczrMD(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_012b;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
							int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(JMclHNzguIWZrgtWkveVPuuQQUBf);
							if (num2 < 0)
							{
								return false;
							}
							wxOWIycVdZxNjHKVLklWBOWcSZUI = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num2).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0157;
							IL_012b:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ActionElementMap current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							goto IL_0145;
							IL_0157:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wxOWIycVdZxNjHKVLklWBOWcSZUI.Count)
							{
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].enabled) && wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									BhdWnHwETjTwooLnNokUmKQRiiPK = wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].ButtonMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						raVymdmwGdkqEmSuCglXjBhczrMD raVymdmwGdkqEmSuCglXjBhczrMD2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							raVymdmwGdkqEmSuCglXjBhczrMD2 = this;
						}
						else
						{
							raVymdmwGdkqEmSuCglXjBhczrMD2 = new raVymdmwGdkqEmSuCglXjBhczrMD(0);
							raVymdmwGdkqEmSuCglXjBhczrMD2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						raVymdmwGdkqEmSuCglXjBhczrMD2.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						raVymdmwGdkqEmSuCglXjBhczrMD2.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						raVymdmwGdkqEmSuCglXjBhczrMD2.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						raVymdmwGdkqEmSuCglXjBhczrMD2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return raVymdmwGdkqEmSuCglXjBhczrMD2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class vVIlZeBzmopEvdDeCYGnRIhEwcBI : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IList<ControllerMap> GFHbunybglKeLtZgrJNdoqtkyeeW;

					private int tdwXqnewaJsEvqbhYEOsNMqnLdFN;

					private IEnumerator<ActionElementMap> ceWXjKiKEhVRMBdWSWJrDlcGmNsn;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public vVIlZeBzmopEvdDeCYGnRIhEwcBI(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_012c;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0187;
							IL_012c:
							if (ceWXjKiKEhVRMBdWSWJrDlcGmNsn.MoveNext())
							{
								ActionElementMap current = ceWXjKiKEhVRMBdWSWJrDlcGmNsn.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							ceWXjKiKEhVRMBdWSWJrDlcGmNsn = null;
							goto IL_0146;
							IL_0158:
							if (tdwXqnewaJsEvqbhYEOsNMqnLdFN < GFHbunybglKeLtZgrJNdoqtkyeeW.Count)
							{
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].enabled) && GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									ceWXjKiKEhVRMBdWSWJrDlcGmNsn = GFHbunybglKeLtZgrJNdoqtkyeeW[tdwXqnewaJsEvqbhYEOsNMqnLdFN].ElementMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							GFHbunybglKeLtZgrJNdoqtkyeeW = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_0187;
							IL_0146:
							tdwXqnewaJsEvqbhYEOsNMqnLdFN++;
							goto IL_0158;
							IL_0187:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW)
							{
								GFHbunybglKeLtZgrJNdoqtkyeeW = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(PrfhaiCANHhjwtWLxlpNIHvkLSmF).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
								tdwXqnewaJsEvqbhYEOsNMqnLdFN = 0;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ceWXjKiKEhVRMBdWSWJrDlcGmNsn != null)
						{
							ceWXjKiKEhVRMBdWSWJrDlcGmNsn.Dispose();
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
						vVIlZeBzmopEvdDeCYGnRIhEwcBI vVIlZeBzmopEvdDeCYGnRIhEwcBI2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vVIlZeBzmopEvdDeCYGnRIhEwcBI2 = this;
						}
						else
						{
							vVIlZeBzmopEvdDeCYGnRIhEwcBI2 = new vVIlZeBzmopEvdDeCYGnRIhEwcBI(0);
							vVIlZeBzmopEvdDeCYGnRIhEwcBI2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						vVIlZeBzmopEvdDeCYGnRIhEwcBI2.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						vVIlZeBzmopEvdDeCYGnRIhEwcBI2.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						vVIlZeBzmopEvdDeCYGnRIhEwcBI2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return vVIlZeBzmopEvdDeCYGnRIhEwcBI2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class KRHgTsIssrfdMmnDKfEPHwUAThvaA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private IList<ControllerMap> wxOWIycVdZxNjHKVLklWBOWcSZUI;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ActionElementMap> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public KRHgTsIssrfdMmnDKfEPHwUAThvaA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_012b;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
							int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(JMclHNzguIWZrgtWkveVPuuQQUBf);
							if (num2 < 0)
							{
								return false;
							}
							wxOWIycVdZxNjHKVLklWBOWcSZUI = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num2).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0157;
							IL_012b:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ActionElementMap current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							goto IL_0145;
							IL_0157:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wxOWIycVdZxNjHKVLklWBOWcSZUI.Count)
							{
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].enabled) && wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									BhdWnHwETjTwooLnNokUmKQRiiPK = wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].ElementMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						KRHgTsIssrfdMmnDKfEPHwUAThvaA kRHgTsIssrfdMmnDKfEPHwUAThvaA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							kRHgTsIssrfdMmnDKfEPHwUAThvaA = this;
						}
						else
						{
							kRHgTsIssrfdMmnDKfEPHwUAThvaA = new KRHgTsIssrfdMmnDKfEPHwUAThvaA(0);
							kRHgTsIssrfdMmnDKfEPHwUAThvaA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						kRHgTsIssrfdMmnDKfEPHwUAThvaA.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						kRHgTsIssrfdMmnDKfEPHwUAThvaA.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						kRHgTsIssrfdMmnDKfEPHwUAThvaA.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						kRHgTsIssrfdMmnDKfEPHwUAThvaA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return kRHgTsIssrfdMmnDKfEPHwUAThvaA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class RMzdBRHfzDbShYETPekDelVKKgFtB : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private int mvqfXCGaCTnnaEkBuqpKdOnEgOqVA;

					public int FrrnxkXqcsEFarRYbqqHIgYdPqfP;

					private IList<ControllerMap> wxOWIycVdZxNjHKVLklWBOWcSZUI;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public RMzdBRHfzDbShYETPekDelVKKgFtB(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_00b0;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(JMclHNzguIWZrgtWkveVPuuQQUBf);
						if (num2 < 0)
						{
							return false;
						}
						wxOWIycVdZxNjHKVLklWBOWcSZUI = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num2).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_00c2;
						IL_00c2:
						if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wxOWIycVdZxNjHKVLklWBOWcSZUI.Count)
						{
							if (wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].categoryId == mvqfXCGaCTnnaEkBuqpKdOnEgOqVA)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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
						RMzdBRHfzDbShYETPekDelVKKgFtB rMzdBRHfzDbShYETPekDelVKKgFtB;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							rMzdBRHfzDbShYETPekDelVKKgFtB = this;
						}
						else
						{
							rMzdBRHfzDbShYETPekDelVKKgFtB = new RMzdBRHfzDbShYETPekDelVKKgFtB(0);
							rMzdBRHfzDbShYETPekDelVKKgFtB.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						rMzdBRHfzDbShYETPekDelVKKgFtB.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						rMzdBRHfzDbShYETPekDelVKKgFtB.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						rMzdBRHfzDbShYETPekDelVKKgFtB.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA = FrrnxkXqcsEFarRYbqqHIgYdPqfP;
						return rMzdBRHfzDbShYETPekDelVKKgFtB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class kqFacCbqtWcGnYCqubPCLCsujDfAA<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<_0001>, IEnumerator<_0001> where _0001 : ControllerMap
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private _0001 vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private int mvqfXCGaCTnnaEkBuqpKdOnEgOqVA;

					public int FrrnxkXqcsEFarRYbqqHIgYdPqfP;

					private IList<_0001> wxOWIycVdZxNjHKVLklWBOWcSZUI;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public kqFacCbqtWcGnYCqubPCLCsujDfAA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_00b9;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						ControllerType controllerType = uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<_0001>();
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(JMclHNzguIWZrgtWkveVPuuQQUBf);
						if (num2 < 0)
						{
							return false;
						}
						wxOWIycVdZxNjHKVLklWBOWcSZUI = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num2).gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA<_0001>();
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_00cb;
						IL_00cb:
						if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wxOWIycVdZxNjHKVLklWBOWcSZUI.Count)
						{
							if (wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].categoryId == mvqfXCGaCTnnaEkBuqpKdOnEgOqVA)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = wxOWIycVdZxNjHKVLklWBOWcSZUI[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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
						kqFacCbqtWcGnYCqubPCLCsujDfAA<_0001> kqFacCbqtWcGnYCqubPCLCsujDfAA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							kqFacCbqtWcGnYCqubPCLCsujDfAA2 = this;
						}
						else
						{
							kqFacCbqtWcGnYCqubPCLCsujDfAA2 = new kqFacCbqtWcGnYCqubPCLCsujDfAA<_0001>(0);
							kqFacCbqtWcGnYCqubPCLCsujDfAA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						kqFacCbqtWcGnYCqubPCLCsujDfAA2.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						kqFacCbqtWcGnYCqubPCLCsujDfAA2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA = FrrnxkXqcsEFarRYbqqHIgYdPqfP;
						return kqFacCbqtWcGnYCqubPCLCsujDfAA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class wurtLGyeYUfySdVgcnAmrETaxnQAA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private int WMSfvXvKrxbLMoEvsaLAsMlIcsUw;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU uljbftxXIVJdHismIWUtpcHQUzzQ;

					private int EsUJEQZITdaNcCAqEhVQzaWsPdOZ;

					private int lzxcEIfPbLrgzCYMIFfPEFYSGRZlA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA IUMzVDWIxDdAoLnsDKWcECYzEdwO;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					private IEnumerator<ActionElementMap> rMdmteecWoSAcwTJktclkGasrQQl;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public wurtLGyeYUfySdVgcnAmrETaxnQAA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_016c;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
							{
								ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
								return false;
							}
							if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
							{
								return false;
							}
							WMSfvXvKrxbLMoEvsaLAsMlIcsUw = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_01ec;
							IL_016c:
							if (rMdmteecWoSAcwTJktclkGasrQQl.MoveNext())
							{
								ActionElementMap current = rMdmteecWoSAcwTJktclkGasrQQl.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							rMdmteecWoSAcwTJktclkGasrQQl = null;
							goto IL_0186;
							IL_0186:
							mIvawggAsicKJrIkGTVLQUHFwCBbA++;
							goto IL_0198;
							IL_01c2:
							if (lzxcEIfPbLrgzCYMIFfPEFYSGRZlA < EsUJEQZITdaNcCAqEhVQzaWsPdOZ)
							{
								IUMzVDWIxDdAoLnsDKWcECYzEdwO = uljbftxXIVJdHismIWUtpcHQUzzQ.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lzxcEIfPbLrgzCYMIFfPEFYSGRZlA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								iTuojJSPVkJDjnJynjDwbzNuaknW = IUMzVDWIxDdAoLnsDKWcECYzEdwO.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
								goto IL_0198;
							}
							uljbftxXIVJdHismIWUtpcHQUzzQ = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_01ec;
							IL_0198:
							if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
							{
								ControllerMap controllerMap = IUMzVDWIxDdAoLnsDKWcECYzEdwO.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA);
								if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMap.enabled) && controllerMap.ContainsAction(BOmXoDplzfnHtyBjNJvkkPzUlWST))
								{
									rMdmteecWoSAcwTJktclkGasrQQl = controllerMap.ElementMapsWithAction(BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							IUMzVDWIxDdAoLnsDKWcECYzEdwO = null;
							lzxcEIfPbLrgzCYMIFfPEFYSGRZlA++;
							goto IL_01c2;
							IL_01ec:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < WMSfvXvKrxbLMoEvsaLAsMlIcsUw)
							{
								uljbftxXIVJdHismIWUtpcHQUzzQ = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
								EsUJEQZITdaNcCAqEhVQzaWsPdOZ = uljbftxXIVJdHismIWUtpcHQUzzQ.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								lzxcEIfPbLrgzCYMIFfPEFYSGRZlA = 0;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (rMdmteecWoSAcwTJktclkGasrQQl != null)
						{
							rMdmteecWoSAcwTJktclkGasrQQl.Dispose();
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
						wurtLGyeYUfySdVgcnAmrETaxnQAA wurtLGyeYUfySdVgcnAmrETaxnQAA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							wurtLGyeYUfySdVgcnAmrETaxnQAA2 = this;
						}
						else
						{
							wurtLGyeYUfySdVgcnAmrETaxnQAA2 = new wurtLGyeYUfySdVgcnAmrETaxnQAA(0);
							wurtLGyeYUfySdVgcnAmrETaxnQAA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						wurtLGyeYUfySdVgcnAmrETaxnQAA2.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						wurtLGyeYUfySdVgcnAmrETaxnQAA2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return wurtLGyeYUfySdVgcnAmrETaxnQAA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class TyUttYNfguyEVzcmunynufOfblK : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IControllerElementTarget EfoKWqiOCpEGBCMEcnvKzQlxoeDT;

					public IControllerElementTarget wBUHqUNJjoXfWXQdgnymGNNWmNON;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool uJLXfoVRHRRRakqTZvhMUAPYbpL;

					public bool ZGoiVbqrMfuvpBfqWWCdwkDzogdx;

					private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

					public int JVHPuraouxduvcIEzsfWFTjVVggFb;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int pLHLGuNzLacpmWGXoTnHVngjOdqM;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IList<ControllerMap> wUYIuiOHoFSePGlDpBiCfRSpnYrUA;

					private int oDCOEwsLZCnmLeqzdqtRUJEJVOGI;

					private int lRKDeQkLTvEAfeQwCUwkuEqMhzzOc;

					private TempListPool.TList<ActionElementMap> rTGDhHjYSNgxivbrsTazuAOdIWYd;

					private List<ActionElementMap>.Enumerator fHGSDjUmbqNTVOmACcZbYFLAbiaN;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public TyUttYNfguyEVzcmunynufOfblK(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if ((uint)(num - -4) > 1u && num != 1)
						{
							return;
						}
						try
						{
							if (num != -4 && num != 1)
							{
								return;
							}
							try
							{
							}
							finally
							{
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
							}
						}
						finally
						{
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_017c;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (EfoKWqiOCpEGBCMEcnvKzQlxoeDT == null)
							{
								return false;
							}
							Controller controller = EfoKWqiOCpEGBCMEcnvKzQlxoeDT.controller;
							if (controller == null)
							{
								return false;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controller.type);
							pLHLGuNzLacpmWGXoTnHVngjOdqM = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_01e4;
							IL_017c:
							if (fHGSDjUmbqNTVOmACcZbYFLAbiaN.MoveNext())
							{
								ActionElementMap current = fHGSDjUmbqNTVOmACcZbYFLAbiaN.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							DZNbUKmveIqGkvckqgFZbMBdZwyW();
							fHGSDjUmbqNTVOmACcZbYFLAbiaN = default(List<ActionElementMap>.Enumerator);
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							rTGDhHjYSNgxivbrsTazuAOdIWYd = null;
							goto IL_01a8;
							IL_01e4:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < pLHLGuNzLacpmWGXoTnHVngjOdqM)
							{
								zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(jvxdoEIJKbJWSnuzXZhzUFhyeYVdA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								_ = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								wUYIuiOHoFSePGlDpBiCfRSpnYrUA = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.STYcwQzrTqawulspAxBpyXIsFtBI;
								oDCOEwsLZCnmLeqzdqtRUJEJVOGI = wUYIuiOHoFSePGlDpBiCfRSpnYrUA.Count;
								lRKDeQkLTvEAfeQwCUwkuEqMhzzOc = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (lRKDeQkLTvEAfeQwCUwkuEqMhzzOc < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
							{
								ControllerMap controllerMap = wUYIuiOHoFSePGlDpBiCfRSpnYrUA[lRKDeQkLTvEAfeQwCUwkuEqMhzzOc];
								if (!bbJFyfBYztkbqyDKwjcJJfiCvWSr || controllerMap.enabled)
								{
									rTGDhHjYSNgxivbrsTazuAOdIWYd = TempListPool.GetTList<ActionElementMap>();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
									List<ActionElementMap> list = rTGDhHjYSNgxivbrsTazuAOdIWYd.list;
									controllerMap.wykkVuZXYDRrQxJtgKBZdFoATLny(EfoKWqiOCpEGBCMEcnvKzQlxoeDT, uJLXfoVRHRRRakqTZvhMUAPYbpL, BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr, list, true, out var _);
									fHGSDjUmbqNTVOmACcZbYFLAbiaN = list.GetEnumerator();
									hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							wUYIuiOHoFSePGlDpBiCfRSpnYrUA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_01e4;
							IL_01a8:
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (rTGDhHjYSNgxivbrsTazuAOdIWYd != null)
						{
							((IDisposable)rTGDhHjYSNgxivbrsTazuAOdIWYd).Dispose();
						}
					}

					private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						((IDisposable)fHGSDjUmbqNTVOmACcZbYFLAbiaN/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						TyUttYNfguyEVzcmunynufOfblK tyUttYNfguyEVzcmunynufOfblK;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							tyUttYNfguyEVzcmunynufOfblK = this;
						}
						else
						{
							tyUttYNfguyEVzcmunynufOfblK = new TyUttYNfguyEVzcmunynufOfblK(0);
							tyUttYNfguyEVzcmunynufOfblK.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						tyUttYNfguyEVzcmunynufOfblK.EfoKWqiOCpEGBCMEcnvKzQlxoeDT = wBUHqUNJjoXfWXQdgnymGNNWmNON;
						tyUttYNfguyEVzcmunynufOfblK.uJLXfoVRHRRRakqTZvhMUAPYbpL = ZGoiVbqrMfuvpBfqWWCdwkDzogdx;
						tyUttYNfguyEVzcmunynufOfblK.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
						tyUttYNfguyEVzcmunynufOfblK.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						return tyUttYNfguyEVzcmunynufOfblK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class ADUgdjfoUGRcrYEkzFohUlbORFiA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int WMSfvXvKrxbLMoEvsaLAsMlIcsUw;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU uljbftxXIVJdHismIWUtpcHQUzzQ;

					private int EsUJEQZITdaNcCAqEhVQzaWsPdOZ;

					private int lzxcEIfPbLrgzCYMIFfPEFYSGRZlA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA IUMzVDWIxDdAoLnsDKWcECYzEdwO;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public ADUgdjfoUGRcrYEkzFohUlbORFiA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							mIvawggAsicKJrIkGTVLQUHFwCBbA++;
							goto IL_0104;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						WMSfvXvKrxbLMoEvsaLAsMlIcsUw = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_0151;
						IL_0104:
						if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = IUMzVDWIxDdAoLnsDKWcECYzEdwO.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA);
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						IUMzVDWIxDdAoLnsDKWcECYzEdwO = null;
						lzxcEIfPbLrgzCYMIFfPEFYSGRZlA++;
						goto IL_0129;
						IL_0129:
						if (lzxcEIfPbLrgzCYMIFfPEFYSGRZlA < EsUJEQZITdaNcCAqEhVQzaWsPdOZ)
						{
							IUMzVDWIxDdAoLnsDKWcECYzEdwO = uljbftxXIVJdHismIWUtpcHQUzzQ.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lzxcEIfPbLrgzCYMIFfPEFYSGRZlA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							iTuojJSPVkJDjnJynjDwbzNuaknW = IUMzVDWIxDdAoLnsDKWcECYzEdwO.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
							goto IL_0104;
						}
						uljbftxXIVJdHismIWUtpcHQUzzQ = null;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						goto IL_0151;
						IL_0151:
						if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < WMSfvXvKrxbLMoEvsaLAsMlIcsUw)
						{
							uljbftxXIVJdHismIWUtpcHQUzzQ = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
							EsUJEQZITdaNcCAqEhVQzaWsPdOZ = uljbftxXIVJdHismIWUtpcHQUzzQ.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							lzxcEIfPbLrgzCYMIFfPEFYSGRZlA = 0;
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
						ADUgdjfoUGRcrYEkzFohUlbORFiA aDUgdjfoUGRcrYEkzFohUlbORFiA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							aDUgdjfoUGRcrYEkzFohUlbORFiA = this;
						}
						else
						{
							aDUgdjfoUGRcrYEkzFohUlbORFiA = new ADUgdjfoUGRcrYEkzFohUlbORFiA(0);
							aDUgdjfoUGRcrYEkzFohUlbORFiA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return aDUgdjfoUGRcrYEkzFohUlbORFiA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class ZaQgpEjdoTgGNLpezRtRdzJzhwYoA<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<_0001>, IEnumerator<_0001> where _0001 : ControllerMap
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private _0001 vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int LvgzQEdcYOuFKvcfytYJQVmWyrSg;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA TfficZUhxVAPqNTmBjBAsabaBduHA;

					private int oDCOEwsLZCnmLeqzdqtRUJEJVOGI;

					private int lRKDeQkLTvEAfeQwCUwkuEqMhzzOc;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public ZaQgpEjdoTgGNLpezRtRdzJzhwYoA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
							{
								ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
								return false;
							}
							if (uAOMfTHsnTLbvEUpHTchXYOhMgjh.XiwRDJOlGaIdvbITXANGklQcDAsaA<_0001>(out var controllerType))
							{
								RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
								LvgzQEdcYOuFKvcfytYJQVmWyrSg = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
								goto IL_011b;
							}
							LvgzQEdcYOuFKvcfytYJQVmWyrSg = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_0264;
						}
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc++;
							goto IL_00f6;
						case 2:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								goto IL_0207;
							}
							IL_0207:
							mIvawggAsicKJrIkGTVLQUHFwCBbA++;
							goto IL_0217;
							IL_0264:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA >= LvgzQEdcYOuFKvcfytYJQVmWyrSg)
							{
								break;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(jvxdoEIJKbJWSnuzXZhzUFhyeYVdA);
							oDCOEwsLZCnmLeqzdqtRUJEJVOGI = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc = 0;
							goto IL_023c;
							IL_011b:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < LvgzQEdcYOuFKvcfytYJQVmWyrSg)
							{
								TfficZUhxVAPqNTmBjBAsabaBduHA = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(jvxdoEIJKbJWSnuzXZhzUFhyeYVdA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								oDCOEwsLZCnmLeqzdqtRUJEJVOGI = TfficZUhxVAPqNTmBjBAsabaBduHA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								lRKDeQkLTvEAfeQwCUwkuEqMhzzOc = 0;
								goto IL_00f6;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = null;
							break;
							IL_0217:
							if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
							{
								if (TfficZUhxVAPqNTmBjBAsabaBduHA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA) is _0001 val)
								{
									vjnbYLtrPMftzpjohNfommerCnGo = val;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								goto IL_0207;
							}
							TfficZUhxVAPqNTmBjBAsabaBduHA = null;
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc++;
							goto IL_023c;
							IL_023c:
							if (lRKDeQkLTvEAfeQwCUwkuEqMhzzOc < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
							{
								TfficZUhxVAPqNTmBjBAsabaBduHA = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lRKDeQkLTvEAfeQwCUwkuEqMhzzOc).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								iTuojJSPVkJDjnJynjDwbzNuaknW = TfficZUhxVAPqNTmBjBAsabaBduHA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
								goto IL_0217;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_0264;
							IL_00f6:
							if (lRKDeQkLTvEAfeQwCUwkuEqMhzzOc < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = (_0001)TfficZUhxVAPqNTmBjBAsabaBduHA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lRKDeQkLTvEAfeQwCUwkuEqMhzzOc);
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							TfficZUhxVAPqNTmBjBAsabaBduHA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
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
						ZaQgpEjdoTgGNLpezRtRdzJzhwYoA<_0001> zaQgpEjdoTgGNLpezRtRdzJzhwYoA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							zaQgpEjdoTgGNLpezRtRdzJzhwYoA = this;
						}
						else
						{
							zaQgpEjdoTgGNLpezRtRdzJzhwYoA = new ZaQgpEjdoTgGNLpezRtRdzJzhwYoA<_0001>(0);
							zaQgpEjdoTgGNLpezRtRdzJzhwYoA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return zaQgpEjdoTgGNLpezRtRdzJzhwYoA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class lCStlFXaiPdhRYdaxblXEUOKTZncA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int RWFejTkgrbEFjrzoWaJQCaTkRyxrA;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA TfficZUhxVAPqNTmBjBAsabaBduHA;

					private int oDCOEwsLZCnmLeqzdqtRUJEJVOGI;

					private int lRKDeQkLTvEAfeQwCUwkuEqMhzzOc;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public lCStlFXaiPdhRYdaxblXEUOKTZncA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc++;
							goto IL_00e2;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
						RWFejTkgrbEFjrzoWaJQCaTkRyxrA = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
						goto IL_0107;
						IL_00e2:
						if (lRKDeQkLTvEAfeQwCUwkuEqMhzzOc < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = TfficZUhxVAPqNTmBjBAsabaBduHA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lRKDeQkLTvEAfeQwCUwkuEqMhzzOc);
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						TfficZUhxVAPqNTmBjBAsabaBduHA = null;
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
						goto IL_0107;
						IL_0107:
						if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < RWFejTkgrbEFjrzoWaJQCaTkRyxrA)
						{
							TfficZUhxVAPqNTmBjBAsabaBduHA = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(jvxdoEIJKbJWSnuzXZhzUFhyeYVdA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							oDCOEwsLZCnmLeqzdqtRUJEJVOGI = TfficZUhxVAPqNTmBjBAsabaBduHA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc = 0;
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
						lCStlFXaiPdhRYdaxblXEUOKTZncA lCStlFXaiPdhRYdaxblXEUOKTZncA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							lCStlFXaiPdhRYdaxblXEUOKTZncA2 = this;
						}
						else
						{
							lCStlFXaiPdhRYdaxblXEUOKTZncA2 = new lCStlFXaiPdhRYdaxblXEUOKTZncA(0);
							lCStlFXaiPdhRYdaxblXEUOKTZncA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						lCStlFXaiPdhRYdaxblXEUOKTZncA2.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						return lCStlFXaiPdhRYdaxblXEUOKTZncA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class uulPknwQTWutyUMzkRwTWcKTcbTU : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int mvqfXCGaCTnnaEkBuqpKdOnEgOqVA;

					public int FrrnxkXqcsEFarRYbqqHIgYdPqfP;

					private int WMSfvXvKrxbLMoEvsaLAsMlIcsUw;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU uljbftxXIVJdHismIWUtpcHQUzzQ;

					private int EsUJEQZITdaNcCAqEhVQzaWsPdOZ;

					private int lzxcEIfPbLrgzCYMIFfPEFYSGRZlA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA IUMzVDWIxDdAoLnsDKWcECYzEdwO;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public uulPknwQTWutyUMzkRwTWcKTcbTU(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_0104;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						WMSfvXvKrxbLMoEvsaLAsMlIcsUw = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_0161;
						IL_0104:
						mIvawggAsicKJrIkGTVLQUHFwCBbA++;
						goto IL_0114;
						IL_0161:
						if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < WMSfvXvKrxbLMoEvsaLAsMlIcsUw)
						{
							uljbftxXIVJdHismIWUtpcHQUzzQ = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(PrfhaiCANHhjwtWLxlpNIHvkLSmF);
							EsUJEQZITdaNcCAqEhVQzaWsPdOZ = uljbftxXIVJdHismIWUtpcHQUzzQ.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							lzxcEIfPbLrgzCYMIFfPEFYSGRZlA = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
						{
							ControllerMap controllerMap = IUMzVDWIxDdAoLnsDKWcECYzEdwO.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA);
							if (controllerMap.categoryId == mvqfXCGaCTnnaEkBuqpKdOnEgOqVA)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = controllerMap;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							goto IL_0104;
						}
						IUMzVDWIxDdAoLnsDKWcECYzEdwO = null;
						lzxcEIfPbLrgzCYMIFfPEFYSGRZlA++;
						goto IL_0139;
						IL_0139:
						if (lzxcEIfPbLrgzCYMIFfPEFYSGRZlA < EsUJEQZITdaNcCAqEhVQzaWsPdOZ)
						{
							IUMzVDWIxDdAoLnsDKWcECYzEdwO = uljbftxXIVJdHismIWUtpcHQUzzQ.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lzxcEIfPbLrgzCYMIFfPEFYSGRZlA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							iTuojJSPVkJDjnJynjDwbzNuaknW = IUMzVDWIxDdAoLnsDKWcECYzEdwO.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
							goto IL_0114;
						}
						uljbftxXIVJdHismIWUtpcHQUzzQ = null;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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
						uulPknwQTWutyUMzkRwTWcKTcbTU uulPknwQTWutyUMzkRwTWcKTcbTU2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							uulPknwQTWutyUMzkRwTWcKTcbTU2 = this;
						}
						else
						{
							uulPknwQTWutyUMzkRwTWcKTcbTU2 = new uulPknwQTWutyUMzkRwTWcKTcbTU(0);
							uulPknwQTWutyUMzkRwTWcKTcbTU2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						uulPknwQTWutyUMzkRwTWcKTcbTU2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA = FrrnxkXqcsEFarRYbqqHIgYdPqfP;
						return uulPknwQTWutyUMzkRwTWcKTcbTU2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class yOJlcqrScKJqtBSzTrDHGniILGgA<_0001> : IDisposable, IEnumerable, IEnumerator, IEnumerable<_0001>, IEnumerator<_0001> where _0001 : ControllerMap
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private _0001 vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int mvqfXCGaCTnnaEkBuqpKdOnEgOqVA;

					public int FrrnxkXqcsEFarRYbqqHIgYdPqfP;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU RSUKtdVQWGoHxzOZDpqeTHAvgEFaA;

					private int LvgzQEdcYOuFKvcfytYJQVmWyrSg;

					private int XrCkLqCGTBLGvQNeiXTREfoQXvzr;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA TfficZUhxVAPqNTmBjBAsabaBduHA;

					private int oDCOEwsLZCnmLeqzdqtRUJEJVOGI;

					private int eKOKGSdNBaSkXxPSzWnyJGsVRZSe;

					private int iTuojJSPVkJDjnJynjDwbzNuaknW;

					private int mIvawggAsicKJrIkGTVLQUHFwCBbA;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public yOJlcqrScKJqtBSzTrDHGniILGgA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
							{
								ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
								return false;
							}
							if (uAOMfTHsnTLbvEUpHTchXYOhMgjh.XiwRDJOlGaIdvbITXANGklQcDAsaA<_0001>(out var _))
							{
								RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.qoOrHOBHuXOIvjxLJWjRAudNZMol<_0001>();
								LvgzQEdcYOuFKvcfytYJQVmWyrSg = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								XrCkLqCGTBLGvQNeiXTREfoQXvzr = 0;
								goto IL_0124;
							}
							LvgzQEdcYOuFKvcfytYJQVmWyrSg = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							XrCkLqCGTBLGvQNeiXTREfoQXvzr = 0;
							goto IL_0287;
						}
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_00eb;
						case 2:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								goto IL_0224;
							}
							IL_0224:
							mIvawggAsicKJrIkGTVLQUHFwCBbA++;
							goto IL_0236;
							IL_00eb:
							eKOKGSdNBaSkXxPSzWnyJGsVRZSe++;
							goto IL_00fd;
							IL_0124:
							if (XrCkLqCGTBLGvQNeiXTREfoQXvzr < LvgzQEdcYOuFKvcfytYJQVmWyrSg)
							{
								TfficZUhxVAPqNTmBjBAsabaBduHA = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(XrCkLqCGTBLGvQNeiXTREfoQXvzr).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								oDCOEwsLZCnmLeqzdqtRUJEJVOGI = TfficZUhxVAPqNTmBjBAsabaBduHA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								eKOKGSdNBaSkXxPSzWnyJGsVRZSe = 0;
								goto IL_00fd;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = null;
							break;
							IL_0287:
							if (XrCkLqCGTBLGvQNeiXTREfoQXvzr >= LvgzQEdcYOuFKvcfytYJQVmWyrSg)
							{
								break;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(XrCkLqCGTBLGvQNeiXTREfoQXvzr);
							oDCOEwsLZCnmLeqzdqtRUJEJVOGI = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							eKOKGSdNBaSkXxPSzWnyJGsVRZSe = 0;
							goto IL_025d;
							IL_0236:
							if (mIvawggAsicKJrIkGTVLQUHFwCBbA < iTuojJSPVkJDjnJynjDwbzNuaknW)
							{
								if (TfficZUhxVAPqNTmBjBAsabaBduHA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(mIvawggAsicKJrIkGTVLQUHFwCBbA) is _0001 val && val.categoryId == mvqfXCGaCTnnaEkBuqpKdOnEgOqVA)
								{
									vjnbYLtrPMftzpjohNfommerCnGo = val;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								goto IL_0224;
							}
							TfficZUhxVAPqNTmBjBAsabaBduHA = null;
							eKOKGSdNBaSkXxPSzWnyJGsVRZSe++;
							goto IL_025d;
							IL_00fd:
							if (eKOKGSdNBaSkXxPSzWnyJGsVRZSe < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
							{
								ControllerMap controllerMap = TfficZUhxVAPqNTmBjBAsabaBduHA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(eKOKGSdNBaSkXxPSzWnyJGsVRZSe);
								if (controllerMap.categoryId == mvqfXCGaCTnnaEkBuqpKdOnEgOqVA)
								{
									vjnbYLtrPMftzpjohNfommerCnGo = (_0001)controllerMap;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
									return true;
								}
								goto IL_00eb;
							}
							TfficZUhxVAPqNTmBjBAsabaBduHA = null;
							XrCkLqCGTBLGvQNeiXTREfoQXvzr++;
							goto IL_0124;
							IL_025d:
							if (eKOKGSdNBaSkXxPSzWnyJGsVRZSe < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
							{
								TfficZUhxVAPqNTmBjBAsabaBduHA = RSUKtdVQWGoHxzOZDpqeTHAvgEFaA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(eKOKGSdNBaSkXxPSzWnyJGsVRZSe).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
								iTuojJSPVkJDjnJynjDwbzNuaknW = TfficZUhxVAPqNTmBjBAsabaBduHA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
								mIvawggAsicKJrIkGTVLQUHFwCBbA = 0;
								goto IL_0236;
							}
							RSUKtdVQWGoHxzOZDpqeTHAvgEFaA = null;
							XrCkLqCGTBLGvQNeiXTREfoQXvzr++;
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
						yOJlcqrScKJqtBSzTrDHGniILGgA<_0001> yOJlcqrScKJqtBSzTrDHGniILGgA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							yOJlcqrScKJqtBSzTrDHGniILGgA2 = this;
						}
						else
						{
							yOJlcqrScKJqtBSzTrDHGniILGgA2 = new yOJlcqrScKJqtBSzTrDHGniILGgA<_0001>(0);
							yOJlcqrScKJqtBSzTrDHGniILGgA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						yOJlcqrScKJqtBSzTrDHGniILGgA2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA = FrrnxkXqcsEFarRYbqqHIgYdPqfP;
						return yOJlcqrScKJqtBSzTrDHGniILGgA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class OsHQsruqrEgcDtjtMFadivlFuiKlA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerMap vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public MapHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK;

					public ControllerType MqPaOXjZWPyrPMgBSrXvwsjXgGZF;

					private int mvqfXCGaCTnnaEkBuqpKdOnEgOqVA;

					public int FrrnxkXqcsEFarRYbqqHIgYdPqfP;

					private nUMJXuTXYTQLuvshdhtoVCFirCzU OumFGuEIioAjABKeoBknVxHWqoBMA;

					private int pLHLGuNzLacpmWGXoTnHVngjOdqM;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private zWbUQgTovQtSYwaKIfEFDBCoWmolA TfficZUhxVAPqNTmBjBAsabaBduHA;

					private int oDCOEwsLZCnmLeqzdqtRUJEJVOGI;

					private int lRKDeQkLTvEAfeQwCUwkuEqMhzzOc;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public OsHQsruqrEgcDtjtMFadivlFuiKlA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						MapHelper mapHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_00e2;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(mapHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						OumFGuEIioAjABKeoBknVxHWqoBMA = mapHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(JZuBcglRGrLdTTkjRHBAWiKZgoVK);
						pLHLGuNzLacpmWGXoTnHVngjOdqM = OumFGuEIioAjABKeoBknVxHWqoBMA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
						goto IL_0117;
						IL_00f2:
						if (lRKDeQkLTvEAfeQwCUwkuEqMhzzOc < oDCOEwsLZCnmLeqzdqtRUJEJVOGI)
						{
							ControllerMap controllerMap = TfficZUhxVAPqNTmBjBAsabaBduHA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(lRKDeQkLTvEAfeQwCUwkuEqMhzzOc);
							if (controllerMap.categoryId == mvqfXCGaCTnnaEkBuqpKdOnEgOqVA)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = controllerMap;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							goto IL_00e2;
						}
						TfficZUhxVAPqNTmBjBAsabaBduHA = null;
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
						goto IL_0117;
						IL_00e2:
						lRKDeQkLTvEAfeQwCUwkuEqMhzzOc++;
						goto IL_00f2;
						IL_0117:
						if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < pLHLGuNzLacpmWGXoTnHVngjOdqM)
						{
							TfficZUhxVAPqNTmBjBAsabaBduHA = OumFGuEIioAjABKeoBknVxHWqoBMA.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(jvxdoEIJKbJWSnuzXZhzUFhyeYVdA).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							oDCOEwsLZCnmLeqzdqtRUJEJVOGI = TfficZUhxVAPqNTmBjBAsabaBduHA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							lRKDeQkLTvEAfeQwCUwkuEqMhzzOc = 0;
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
						OsHQsruqrEgcDtjtMFadivlFuiKlA osHQsruqrEgcDtjtMFadivlFuiKlA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							osHQsruqrEgcDtjtMFadivlFuiKlA = this;
						}
						else
						{
							osHQsruqrEgcDtjtMFadivlFuiKlA = new OsHQsruqrEgcDtjtMFadivlFuiKlA(0);
							osHQsruqrEgcDtjtMFadivlFuiKlA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						osHQsruqrEgcDtjtMFadivlFuiKlA.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA = FrrnxkXqcsEFarRYbqqHIgYdPqfP;
						osHQsruqrEgcDtjtMFadivlFuiKlA.JZuBcglRGrLdTTkjRHBAWiKZgoVK = MqPaOXjZWPyrPMgBSrXvwsjXgGZF;
						return osHQsruqrEgcDtjtMFadivlFuiKlA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly WWVuXrRYVOzShWUocNjzkxVTwGrG hIOjgIlEMczPWRZStLfqmaVNKZGn;

				private Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV;

				private ControllerHelper TqAZNEcFJkyctXeLFKcYDRxOBxRA;

				private readonly ControllerMapEnabler znDMhdUqdgHwTusUVVuVrkHUGoHfA;

				private readonly ControllerMapLayoutManager RTSFfeIfEJMQvUPZEKHgFJAawsOKA;

				private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

				public ControllerMapLayoutManager layoutManager => RTSFfeIfEJMQvUPZEKHgFJAawsOKA;

				public ControllerMapEnabler mapEnabler => znDMhdUqdgHwTusUVVuVrkHUGoHfA;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.BLmglDisFscRMEbYRzrZHWrhAOln(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, WWVuXrRYVOzShWUocNjzkxVTwGrG P_2, ControllerMapLayoutManager.QMsaCCjejTLLpcQRJGrdNeitKrRP P_3, ControllerMapEnabler.KiSiAESwVlRDyuCSgIKOzduAyJHX P_4)
				{
					oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
					tYEyiSjpdwwbqdDLYhlcYJwwGWGV = P_0;
					TqAZNEcFJkyctXeLFKcYDRxOBxRA = P_1;
					hIOjgIlEMczPWRZStLfqmaVNKZGn = P_2;
					znDMhdUqdgHwTusUVVuVrkHUGoHfA = new ControllerMapEnabler(P_0, P_4);
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA = new ControllerMapLayoutManager(P_0, P_3);
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.aTfPeuQNwbUzmVZeXSyKszoeHzXb += znDMhdUqdgHwTusUVVuVrkHUGoHfA.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					sWRdYuEIGryWGRsUzHRLLNZKggaMA(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void sWRdYuEIGryWGRsUzHRLLNZKggaMA<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						hiPvikIdVzMupnvagnnccKDHgTQM(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void sWRdYuEIGryWGRsUzHRLLNZKggaMA<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						hiPvikIdVzMupnvagnnccKDHgTQM(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void sWRdYuEIGryWGRsUzHRLLNZKggaMA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void sWRdYuEIGryWGRsUzHRLLNZKggaMA(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, P_2, P_3, P_4);
					}
				}

				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new ADUgdjfoUGRcrYEkzFohUlbORFiA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num; j++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA(results, true);
						}
					}
					return results.Count;
				}

				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new ZaQgpEjdoTgGNLpezRtRdzJzhwYoA<T>(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (uAOMfTHsnTLbvEUpHTchXYOhMgjh.XiwRDJOlGaIdvbITXANGklQcDAsaA<T>(out var controllerType))
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int i = 0; i < num; i++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA(results, true);
						}
					}
					else
					{
						int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < zQqQltuirEhRybMOxWCRGTiKWPGW; j++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU3 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(j);
							int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU3.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							for (int k = 0; k < num2; k++)
							{
								nUMJXuTXYTQLuvshdhtoVCFirCzU3.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k).gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA(results, true);
							}
						}
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new lCStlFXaiPdhRYdaxblXEUOKTZncA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new uulPknwQTWutyUMzkRwTWcKTcbTU(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						FrrnxkXqcsEFarRYbqqHIgYdPqfP = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new yOJlcqrScKJqtBSzTrDHGniILGgA<T>(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						FrrnxkXqcsEFarRYbqqHIgYdPqfP = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new OsHQsruqrEgcDtjtMFadivlFuiKlA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						FrrnxkXqcsEFarRYbqqHIgYdPqfP = categoryId,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num; j++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (uAOMfTHsnTLbvEUpHTchXYOhMgjh.XiwRDJOlGaIdvbITXANGklQcDAsaA<T>(out var controllerType))
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int i = 0; i < num; i++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(categoryId, results, true);
						}
					}
					else
					{
						int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < zQqQltuirEhRybMOxWCRGTiKWPGW; j++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU3 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(j);
							int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU3.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							for (int k = 0; k < num2; k++)
							{
								nUMJXuTXYTQLuvshdhtoVCFirCzU3.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k).gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return bqVYgUAqBpvaKoTnxhUBcRgmAHPl<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return bqVYgUAqBpvaKoTnxhUBcRgmAHPl(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					return BtyiZkcDOZnhezZscgetgGVXaGlZ(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType).jcQIPleqWWsZNlvEYGkHBahJWVvN(controllerId)?.gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return BtyiZkcDOZnhezZscgetgGVXaGlZ<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					sOqjGwajlbTzcTCmBjowEffZChuAb sOqjGwajlbTzcTCmBjowEffZChuAb2 = qoOrHOBHuXOIvjxLJWjRAudNZMol<T>().jcQIPleqWWsZNlvEYGkHBahJWVvN(controllerId);
					if (sOqjGwajlbTzcTCmBjowEffZChuAb2 == null)
					{
						return 0;
					}
					sOqjGwajlbTzcTCmBjowEffZChuAb2.gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)wLUXiyCuiPKPxezsKeSQJsVwGOPE(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)wLUXiyCuiPKPxezsKeSQJsVwGOPE(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (T)wLUXiyCuiPKPxezsKeSQJsVwGOPE(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.DNQJGhFagurOCvMbnebqcNAnYhqV(mapId);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)hwpwmDurpEQypoPipjTwlGUbbiAN(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return hwpwmDurpEQypoPipjTwlGUbbiAN(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return xlUylFazFQucmgoDGelrLwjdeMwP(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return xlUylFazFQucmgoDGelrLwjdeMwP(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return gUqMiECHwSkMERWpwcKNSBqHoMTt(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return gUqMiECHwSkMERWpwcKNSBqHoMTt(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						RVQRQmdSEoOidVpfJxwRuEPlxZsR(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						RVQRQmdSEoOidVpfJxwRuEPlxZsR(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						RVQRQmdSEoOidVpfJxwRuEPlxZsR(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else if (mapId >= 0)
					{
						dVZbxmbuBeKPvEgucinbiljtSGqq(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						dVZbxmbuBeKPvEgucinbiljtSGqq(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						dVZbxmbuBeKPvEgucinbiljtSGqq(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else if (mapId >= 0)
					{
						dVZbxmbuBeKPvEgucinbiljtSGqq(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						dVZbxmbuBeKPvEgucinbiljtSGqq(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						dVZbxmbuBeKPvEgucinbiljtSGqq(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMaps(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMapsInCategory(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMapsInCategory(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i));
						for (int j = 0; j < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; j++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
						for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMapsInLayout(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.zHmEXGtWBsmURzWbphTHzuFpMIhd(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMapsForController(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMapsForController(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(controllerId);
					if (num >= 0)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(controllerId);
					if (num >= 0)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ClearMapsForControllerInLayout(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(controllerId);
					if (num >= 0)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.zHmEXGtWBsmURzWbphTHzuFpMIhd(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ClearMaps(TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i), userAssignableOnly);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return auqKJxHrKBUEMqidjhbvJAJovxDkA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return auqKJxHrKBUEMqidjhbvJAJovxDkA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ActionElementMap actionElementMap = auqKJxHrKBUEMqidjhbvJAJovxDkA(TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return SfghliPkqrAXovDIoUXKWsgrjhhg(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return SfghliPkqrAXovDIoUXKWsgrjhhg(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new SgpjvFtGtzWiLiKkuIyedTntCMOSA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						JVHPuraouxduvcIEzsfWFTjVVggFb = actionId,
						sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					return AjdLvPMfCVfWnZCUdXcSnZjnTrbb(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return AjdLvPMfCVfWnZCUdXcSnZjnTrbb(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return eBseNodGqWNciAWifLhRKMAGukzhA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return eBseNodGqWNciAWifLhRKMAGukzhA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ActionElementMap actionElementMap = eBseNodGqWNciAWifLhRKMAGukzhA(TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return ByXipWeKgeoafsKaWWWWmHhNqtEK(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return ByXipWeKgeoafsKaWWWWmHhNqtEK(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new DwNulXMGVjXBJyXLovObdlifguyhA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						JVHPuraouxduvcIEzsfWFTjVVggFb = actionId,
						sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return nBhHMlfSVWSUcfyNzfjWnzudPlzw(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return nBhHMlfSVWSUcfyNzfjWnzudPlzw(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return pLtPLpYzEmAgeTsckCkqdEboCooK(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return iXIbOLmYbJrOryrqnafihwGwWCPX(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return iXIbOLmYbJrOryrqnafihwGwWCPX(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ActionElementMap actionElementMap = iXIbOLmYbJrOryrqnafihwGwWCPX(TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return LNQNZYyRaJBpPyULisvuupQDIsLN(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return LNQNZYyRaJBpPyULisvuupQDIsLN(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new wurtLGyeYUfySdVgcnAmrETaxnQAA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						JVHPuraouxduvcIEzsfWFTjVVggFb = actionId,
						sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return zNlORBANBLmisqYxanxMBqtCCmWG(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return zNlORBANBLmisqYxanxMBqtCCmWG(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return KnhZxXTPhhiXJgFttivQXWIEaevD(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(wortGyCOkKTpqRUAkJvQBKSaUPen, skipDisabledMaps);
					WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return XoSkNuDnGYkWdhdUDkPGpiGhNgYC(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(wortGyCOkKTpqRUAkJvQBKSaUPen, actionId, skipDisabledMaps);
					WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return XoSkNuDnGYkWdhdUDkPGpiGhNgYC(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(wortGyCOkKTpqRUAkJvQBKSaUPen, skipDisabledMaps);
					WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return ofPtXzQRTSIwuudhHEmzQTQYglcR(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(wortGyCOkKTpqRUAkJvQBKSaUPen, actionId, skipDisabledMaps);
					WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return ofPtXzQRTSIwuudhHEmzQTQYglcR(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(wortGyCOkKTpqRUAkJvQBKSaUPen, skipDisabledMaps, results);
					WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return wykkVuZXYDRrQxJtgKBZdFoATLny(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(wortGyCOkKTpqRUAkJvQBKSaUPen, actionId, skipDisabledMaps, results);
					WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return wykkVuZXYDRrQxJtgKBZdFoATLny(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<T>.array;
					}
					return XvdPdstIuSeSJAFgqSTVmSNERZBN<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return XvdPdstIuSeSJAFgqSTVmSNERZBN(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<T>.array;
					}
					return NwxbNquLuGzrsqOAGcZOhyyqxCmoA<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return NwxbNquLuGzrsqOAGcZOhyyqxCmoA(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ArrayTools.Combine(ref array, NwxbNquLuGzrsqOAGcZOhyyqxCmoA(TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int num = 0;
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num2; j++)
						{
							num += nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.oRhsJiCtLRzExGpxFRfCVIJDrdxd(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int num = 0;
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num2; i++)
					{
						num += nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.oRhsJiCtLRzExGpxFRfCVIJDrdxd(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType).jcQIPleqWWsZNlvEYGkHBahJWVvN(controllerId)?.gYfvSSlCQdvlHXoFtXExDLDXhhRu.oRhsJiCtLRzExGpxFRfCVIJDrdxd(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num2; j++)
						{
							num += nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.nCxZqrxgLpPOeaAADaPXGUnMlwhM(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ControllerType controllerType = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.gNOEbBClxcJMmDKnoysbMauBfOjX(i);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num2; i++)
					{
						num += nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.nCxZqrxgLpPOeaAADaPXGUnMlwhM(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num2; i++)
					{
						num += nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.nCxZqrxgLpPOeaAADaPXGUnMlwhM(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controller.type).jcQIPleqWWsZNlvEYGkHBahJWVvN(controller.id)?.gYfvSSlCQdvlHXoFtXExDLDXhhRu.nCxZqrxgLpPOeaAADaPXGUnMlwhM(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controller.type).jcQIPleqWWsZNlvEYGkHBahJWVvN(controller.id)?.gYfvSSlCQdvlHXoFtXExDLDXhhRu.nCxZqrxgLpPOeaAADaPXGUnMlwhM(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						eaccZKzRmIcnwrGyalPuBpVEadmK(false);
						break;
					case ControllerType.Keyboard:
						OGNeQCaKpeqbbqjCSYcDrdGrhVAeA(false);
						break;
					case ControllerType.Mouse:
						ZdYVXGfaJcxnvYPSYdyByenJrdzL(false);
						break;
					case ControllerType.Custom:
						acAeaohUKMPsmInJtEHZlyjObaTp(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num; j++)
						{
							if (nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu.SyycyKATBElpJbRFjLenmGRbNwfn(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num; i++)
					{
						if (nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.SyycyKATBElpJbRFjLenmGRbNwfn(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.SFJZdklJEKfUiGPbWOYRazmyxtQuA(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.SFJZdklJEKfUiGPbWOYRazmyxtQuA(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, behaviorName);
				}

				internal void TlzckGoQDITHcUYaslQXPQBOhTwq()
				{
					znDMhdUqdgHwTusUVVuVrkHUGoHfA.LoadDefaults();
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.LoadDefaults();
				}

				internal void eaccZKzRmIcnwrGyalPuBpVEadmK(bool P_0)
				{
					if (hIOjgIlEMczPWRZStLfqmaVNKZGn.kBXtkEthbyiTJTgBVatOcKuUvPJdA == null)
					{
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick);
					TqAZNEcFJkyctXeLFKcYDRxOBxRA.AXHLLNOarmUpwPzyUrjqTImAJvzZ.ulPBypIpiDZHdSjLKAnGIFgoEIuI();
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num; i++)
					{
						bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU gUNePuOAXTTEQajyoClOIDiOHUoU = (bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU)nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.DLziBsJZuZhaylJgkqoiHaUPORcx();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).enabled;
							}
						}
						gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(false);
						for (int k = 0; k < hIOjgIlEMczPWRZStLfqmaVNKZGn.kBXtkEthbyiTJTgBVatOcKuUvPJdA.Length; k++)
						{
							xXHxnQgPrXfpvFetpDwngKTjVTaNb(gUNePuOAXTTEQajyoClOIDiOHUoU.yBVYaZymnHfILCjQopwadWNgxbeH, gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu, hIOjgIlEMczPWRZStLfqmaVNKZGn.kBXtkEthbyiTJTgBVatOcKuUvPJdA[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.DLziBsJZuZhaylJgkqoiHaUPORcx());
							for (int l = 0; l < num3; l++)
							{
								gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = false;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.Apply();
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void OGNeQCaKpeqbbqjCSYcDrdGrhVAeA(bool P_0)
				{
					if (hIOjgIlEMczPWRZStLfqmaVNKZGn.JCRbtEWTOkiKHTGXkoBGRlLGBwQm == null)
					{
						return;
					}
					zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Keyboard).jcQIPleqWWsZNlvEYGkHBahJWVvN(0).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
					bool[] array = null;
					if (!P_0)
					{
						int num = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).enabled;
						}
					}
					zWbUQgTovQtSYwaKIfEFDBCoWmolA2.wJjPIIRJfHhEbGedUconecGfiwzgB(false);
					for (int j = 0; j < hIOjgIlEMczPWRZStLfqmaVNKZGn.JCRbtEWTOkiKHTGXkoBGRlLGBwQm.Length; j++)
					{
						QBdQosWNnkVEuHmqVyCFNjseiAQp qBdQosWNnkVEuHmqVyCFNjseiAQp = hIOjgIlEMczPWRZStLfqmaVNKZGn.JCRbtEWTOkiKHTGXkoBGRlLGBwQm[j];
						if (qBdQosWNnkVEuHmqVyCFNjseiAQp.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA >= 0 && qBdQosWNnkVEuHmqVyCFNjseiAQp.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, qBdQosWNnkVEuHmqVyCFNjseiAQp.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA, qBdQosWNnkVEuHmqVyCFNjseiAQp.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ);
							if (P_0)
							{
								keyboardMap.enabled = qBdQosWNnkVEuHmqVyCFNjseiAQp.DoNfQwgTKQBrVFJHmFCNAySARDIAc;
							}
							gYbofPyXOZOSeuSddafZrncWFtiW(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW);
						for (int k = 0; k < num2; k++)
						{
							zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = false;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.Apply();
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void ZdYVXGfaJcxnvYPSYdyByenJrdzL(bool P_0)
				{
					if (hIOjgIlEMczPWRZStLfqmaVNKZGn.XPJWfFXouLcWrhognxaweKWXrtrSA == null)
					{
						return;
					}
					zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Mouse).jcQIPleqWWsZNlvEYGkHBahJWVvN(0).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
					bool[] array = null;
					if (!P_0)
					{
						int num = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).enabled;
						}
					}
					zWbUQgTovQtSYwaKIfEFDBCoWmolA2.wJjPIIRJfHhEbGedUconecGfiwzgB(false);
					for (int j = 0; j < hIOjgIlEMczPWRZStLfqmaVNKZGn.XPJWfFXouLcWrhognxaweKWXrtrSA.Length; j++)
					{
						QBdQosWNnkVEuHmqVyCFNjseiAQp qBdQosWNnkVEuHmqVyCFNjseiAQp = hIOjgIlEMczPWRZStLfqmaVNKZGn.XPJWfFXouLcWrhognxaweKWXrtrSA[j];
						if (qBdQosWNnkVEuHmqVyCFNjseiAQp.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA >= 0 && qBdQosWNnkVEuHmqVyCFNjseiAQp.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, qBdQosWNnkVEuHmqVyCFNjseiAQp.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA, qBdQosWNnkVEuHmqVyCFNjseiAQp.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ);
							if (P_0)
							{
								mouseMap.enabled = qBdQosWNnkVEuHmqVyCFNjseiAQp.DoNfQwgTKQBrVFJHmFCNAySARDIAc;
							}
							gYbofPyXOZOSeuSddafZrncWFtiW(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW);
						for (int k = 0; k < num2; k++)
						{
							zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = false;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.Apply();
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void acAeaohUKMPsmInJtEHZlyjObaTp(bool P_0)
				{
					if (hIOjgIlEMczPWRZStLfqmaVNKZGn.ReELbHOMeiVOvgADTEmoCKFXqNjq == null)
					{
						return;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num; i++)
					{
						bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>.gUNePuOAXTTEQajyoClOIDiOHUoU gUNePuOAXTTEQajyoClOIDiOHUoU = (bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>.gUNePuOAXTTEQajyoClOIDiOHUoU)nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.DLziBsJZuZhaylJgkqoiHaUPORcx();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).enabled;
							}
						}
						gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.wJjPIIRJfHhEbGedUconecGfiwzgB(false);
						for (int k = 0; k < hIOjgIlEMczPWRZStLfqmaVNKZGn.ReELbHOMeiVOvgADTEmoCKFXqNjq.Length; k++)
						{
							dCuuDeVLBpURmzjtvvQVDGxwZBKy(gUNePuOAXTTEQajyoClOIDiOHUoU.yBVYaZymnHfILCjQopwadWNgxbeH, gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu, hIOjgIlEMczPWRZStLfqmaVNKZGn.ReELbHOMeiVOvgADTEmoCKFXqNjq[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.DLziBsJZuZhaylJgkqoiHaUPORcx());
							for (int l = 0; l < num3; l++)
							{
								gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = false;
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.Apply();
					RTSFfeIfEJMQvUPZEKHgFJAawsOKA.loadFromUserDataStore = loadFromUserDataStore;
				}

				private nUMJXuTXYTQLuvshdhtoVCFirCzU qoOrHOBHuXOIvjxLJWjRAudNZMol<_0001>() where _0001 : ControllerMap
				{
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(uAOMfTHsnTLbvEUpHTchXYOhMgjh.XhIiIdTNiByfMHGggxzLSYyeBeJA<_0001>());
				}

				internal BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> XGGiHvDuRxfWZcjkoFymEYUloNDv(Joystick P_0, bool P_1)
				{
					if (P_0 == null || hIOjgIlEMczPWRZStLfqmaVNKZGn.kBXtkEthbyiTJTgBVatOcKuUvPJdA == null)
					{
						return null;
					}
					BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> bNyqYlWalrCfOzrCabaRaoJZBeLP = new BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap>(P_0.id);
					for (int i = 0; i < hIOjgIlEMczPWRZStLfqmaVNKZGn.kBXtkEthbyiTJTgBVatOcKuUvPJdA.Length; i++)
					{
						xXHxnQgPrXfpvFetpDwngKTjVTaNb(P_0, bNyqYlWalrCfOzrCabaRaoJZBeLP, hIOjgIlEMczPWRZStLfqmaVNKZGn.kBXtkEthbyiTJTgBVatOcKuUvPJdA[i], P_1);
					}
					if (bNyqYlWalrCfOzrCabaRaoJZBeLP.DLziBsJZuZhaylJgkqoiHaUPORcx() == 0)
					{
						return null;
					}
					return bNyqYlWalrCfOzrCabaRaoJZBeLP;
				}

				private void xXHxnQgPrXfpvFetpDwngKTjVTaNb(Joystick P_0, BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> P_1, QBdQosWNnkVEuHmqVyCFNjseiAQp P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA >= 0 && P_2.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.gUxChVRBsjPPDWpUfylXVbZXrBYU(P_0, P_2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA, P_2.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ);
						LJxUfrjqRngGjfLkARGJwZXpwXAOA(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.DoNfQwgTKQBrVFJHmFCNAySARDIAc ? BoolOption.True : BoolOption.False);
						}
						P_1.fyeqCafQbFyflbNbajUvornPxfgy(joystickMap, boolOption);
					}
				}

				internal BNyqYlWalrCfOzrCabaRaoJZBeLP<CustomControllerMap> MhLuxsxiHHVMkUswMfgZhzvXLujH(CustomController P_0, bool P_1)
				{
					if (P_0 == null || hIOjgIlEMczPWRZStLfqmaVNKZGn.ReELbHOMeiVOvgADTEmoCKFXqNjq == null)
					{
						return null;
					}
					BNyqYlWalrCfOzrCabaRaoJZBeLP<CustomControllerMap> bNyqYlWalrCfOzrCabaRaoJZBeLP = new BNyqYlWalrCfOzrCabaRaoJZBeLP<CustomControllerMap>(P_0.id);
					for (int i = 0; i < hIOjgIlEMczPWRZStLfqmaVNKZGn.ReELbHOMeiVOvgADTEmoCKFXqNjq.Length; i++)
					{
						dCuuDeVLBpURmzjtvvQVDGxwZBKy(P_0, bNyqYlWalrCfOzrCabaRaoJZBeLP, hIOjgIlEMczPWRZStLfqmaVNKZGn.ReELbHOMeiVOvgADTEmoCKFXqNjq[i], P_1);
					}
					if (bNyqYlWalrCfOzrCabaRaoJZBeLP.DLziBsJZuZhaylJgkqoiHaUPORcx() == 0)
					{
						return null;
					}
					return bNyqYlWalrCfOzrCabaRaoJZBeLP;
				}

				private void dCuuDeVLBpURmzjtvvQVDGxwZBKy(CustomController P_0, BNyqYlWalrCfOzrCabaRaoJZBeLP<CustomControllerMap> P_1, QBdQosWNnkVEuHmqVyCFNjseiAQp P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA >= 0 && P_2.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.DSafZsvlKsnfESZPCZvSdrEpJHPB(P_2.mvqfXCGaCTnnaEkBuqpKdOnEgOqVA, P_0.sourceControllerId, P_2.dQSoHMAxKhEhFuTjKJRKZqfDNMNJ);
						LJxUfrjqRngGjfLkARGJwZXpwXAOA(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.DoNfQwgTKQBrVFJHmFCNAySARDIAc ? BoolOption.True : BoolOption.False);
						}
						P_1.fyeqCafQbFyflbNbajUvornPxfgy(customControllerMap, boolOption);
					}
				}

				internal void LJxUfrjqRngGjfLkARGJwZXpwXAOA(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
						P_0.LJxUfrjqRngGjfLkARGJwZXpwXAOA(P_1);
					}
				}

				private IList<_0001> bqVYgUAqBpvaKoTnxhUBcRgmAHPl<_0001>(int P_0) where _0001 : ControllerMap
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = qoOrHOBHuXOIvjxLJWjRAudNZMol<_0001>();
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA<_0001>();
				}

				private IList<_0001> bqVYgUAqBpvaKoTnxhUBcRgmAHPl<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return qoOrHOBHuXOIvjxLJWjRAudNZMol<_0001>().jcQIPleqWWsZNlvEYGkHBahJWVvN(P_0)?.gYfvSSlCQdvlHXoFtXExDLDXhhRu.BCfgjzJDoAqCxKYJFjQytURbTojpA<_0001>();
				}

				private IList<ControllerMap> bqVYgUAqBpvaKoTnxhUBcRgmAHPl(ControllerType P_0, int P_1)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
				}

				private IList<ControllerMap> bqVYgUAqBpvaKoTnxhUBcRgmAHPl(Controller P_0)
				{
					return bqVYgUAqBpvaKoTnxhUBcRgmAHPl(P_0.type, P_0.id);
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(Controller P_0, int P_1, int P_2)
				{
					hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, P_2, BoolOption.Default);
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(Controller P_0, string P_1, string P_2)
				{
					hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, P_2, BoolOption.Default);
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num >= 0)
					{
						Controller controller = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH;
						ControllerMap controllerMap = ReInput.UserData.XLaZeIAcluXGguEpDszvQZYdfxQf(controller, P_2, P_3);
						gYbofPyXOZOSeuSddafZrncWFtiW(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					hiPvikIdVzMupnvagnnccKDHgTQM(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						hiPvikIdVzMupnvagnnccKDHgTQM(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void hiPvikIdVzMupnvagnnccKDHgTQM(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					hiPvikIdVzMupnvagnnccKDHgTQM(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void gYbofPyXOZOSeuSddafZrncWFtiW(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0.type);
						int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_0.id);
						if (num >= 0)
						{
							LJxUfrjqRngGjfLkARGJwZXpwXAOA(P_0, P_1);
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.fyeqCafQbFyflbNbajUvornPxfgy(P_1, P_2);
							znDMhdUqdgHwTusUVVuVrkHUGoHfA.Apply();
						}
					}
				}

				private void gYbofPyXOZOSeuSddafZrncWFtiW(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						gYbofPyXOZOSeuSddafZrncWFtiW(controller, P_2, P_3);
					}
				}

				private bool xlUylFazFQucmgoDGelrLwjdeMwP(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0).PujFpIgnaejxCcbCzrcoRIpZaecab(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.VxSNvmooWfTkIVcICGUZnqoUJPDW(P_0);
					if (!controllerMap.pupFGbyyCYvRvYlYkoDbgDMrliM(P_2))
					{
						return false;
					}
					gYbofPyXOZOSeuSddafZrncWFtiW(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int TvyDHMXBJefPhaBNUahLizekjJXL(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0).PujFpIgnaejxCcbCzrcoRIpZaecab(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (xlUylFazFQucmgoDGelrLwjdeMwP(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool gUqMiECHwSkMERWpwcKNSBqHoMTt(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0).PujFpIgnaejxCcbCzrcoRIpZaecab(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.VxSNvmooWfTkIVcICGUZnqoUJPDW(P_0);
					if (!controllerMap.fneIkVyAwJMkkxAsVVGscjMmUqCN(P_2))
					{
						return false;
					}
					gYbofPyXOZOSeuSddafZrncWFtiW(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int HKJOaXxnLMYyAUrFKQVEhBZRSGpA(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0).PujFpIgnaejxCcbCzrcoRIpZaecab(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (gUqMiECHwSkMERWpwcKNSBqHoMTt(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void RVQRQmdSEoOidVpfJxwRuEPlxZsR(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num >= 0)
					{
						Controller controller = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH;
						ControllerMap controllerMap = ControllerMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(controller, P_2, P_3);
						gYbofPyXOZOSeuSddafZrncWFtiW(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void RVQRQmdSEoOidVpfJxwRuEPlxZsR(Controller P_0, int P_1, int P_2)
				{
					RVQRQmdSEoOidVpfJxwRuEPlxZsR(P_0.type, P_0.id, P_1, P_2);
				}

				private void RVQRQmdSEoOidVpfJxwRuEPlxZsR(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						RVQRQmdSEoOidVpfJxwRuEPlxZsR(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void RVQRQmdSEoOidVpfJxwRuEPlxZsR(Controller P_0, string P_1, string P_2)
				{
					RVQRQmdSEoOidVpfJxwRuEPlxZsR(P_0.type, P_0.id, P_1, P_2);
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(ControllerType P_0, int P_1, int P_2)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num >= 0)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.zFWfCRDHVVMPgnPQlKVvGpBvRGGP(P_2);
					}
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(Controller P_0, int P_1)
				{
					dVZbxmbuBeKPvEgucinbiljtSGqq(P_0.type, P_0.id, P_1);
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num >= 0)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_2);
					}
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(Controller P_0, ControllerMap P_1)
				{
					dVZbxmbuBeKPvEgucinbiljtSGqq(P_0.type, P_0.id, P_1.id);
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num >= 0)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_2, P_3);
					}
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(Controller P_0, int P_1, int P_2)
				{
					dVZbxmbuBeKPvEgucinbiljtSGqq(P_0.type, P_0.id, P_1, P_2);
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(mapCategoryId, layoutId);
						}
					}
				}

				private void dVZbxmbuBeKPvEgucinbiljtSGqq(Controller P_0, string P_1, string P_2)
				{
					dVZbxmbuBeKPvEgucinbiljtSGqq(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap wLUXiyCuiPKPxezsKeSQJsVwGOPE(ControllerType P_0, int P_1, int P_2)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					return nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.DNQJGhFagurOCvMbnebqcNAnYhqV(P_2);
				}

				private ControllerMap wLUXiyCuiPKPxezsKeSQJsVwGOPE(Controller P_0, int P_1)
				{
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(P_0.type, P_0.id, P_1);
				}

				private ControllerMap wLUXiyCuiPKPxezsKeSQJsVwGOPE(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					return nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.DNQJGhFagurOCvMbnebqcNAnYhqV(P_2, P_3);
				}

				private ControllerMap wLUXiyCuiPKPxezsKeSQJsVwGOPE(Controller P_0, int P_1, int P_2)
				{
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap wLUXiyCuiPKPxezsKeSQJsVwGOPE(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap wLUXiyCuiPKPxezsKeSQJsVwGOPE(Controller P_0, string P_1, string P_2)
				{
					return wLUXiyCuiPKPxezsKeSQJsVwGOPE(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap hwpwmDurpEQypoPipjTwlGUbbiAN(ControllerType P_0, int P_1, int P_2)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					return nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.nbAJCAGtUDvnFCEEIJDsjpkyWfgS(P_2);
				}

				private ControllerMap hwpwmDurpEQypoPipjTwlGUbbiAN(Controller P_0, int P_1)
				{
					return hwpwmDurpEQypoPipjTwlGUbbiAN(P_0.type, P_0.id, P_1);
				}

				private ControllerMap hwpwmDurpEQypoPipjTwlGUbbiAN(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return hwpwmDurpEQypoPipjTwlGUbbiAN(P_0, P_1, mapCategoryId);
				}

				private ControllerMap hwpwmDurpEQypoPipjTwlGUbbiAN(Controller P_0, string P_1)
				{
					return hwpwmDurpEQypoPipjTwlGUbbiAN(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] HkFDKHWDfksAGHhxmVstWOqKvEHk(ControllerType P_0)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = 0;
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						num += nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; j++)
					{
						zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
						for (int k = 0; k < zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW; k++)
						{
							array[num] = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] XvdPdstIuSeSJAFgqSTVmSNERZBN(ControllerType P_0, int P_1, bool P_2)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
					for (int i = 0; i < zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ControllerMap controllerMap = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH;
						list.Add(ControllerMapSaveData.VxSNvmooWfTkIVcICGUZnqoUJPDW(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] XvdPdstIuSeSJAFgqSTVmSNERZBN<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = uAOMfTHsnTLbvEUpHTchXYOhMgjh.BFhPJuTSfRAKfWOopkccSyfpnIHq<_0001>();
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
					for (int i = 0; i < zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						ControllerMap controllerMap = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH;
						list.Add(ControllerMapSaveData.VxSNvmooWfTkIVcICGUZnqoUJPDW<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] NwxbNquLuGzrsqOAGcZOhyyqxCmoA(ControllerType P_0, bool P_1)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
						for (int j = 0; j < zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW; j++)
						{
							ControllerMap controllerMap = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH;
							list.Add(ControllerMapSaveData.VxSNvmooWfTkIVcICGUZnqoUJPDW(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] NwxbNquLuGzrsqOAGcZOhyyqxCmoA<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = uAOMfTHsnTLbvEUpHTchXYOhMgjh.BFhPJuTSfRAKfWOopkccSyfpnIHq<_0001>();
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
						for (int j = 0; j < zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW; j++)
						{
							ControllerMap controllerMap = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH;
							list.Add(ControllerMapSaveData.VxSNvmooWfTkIVcICGUZnqoUJPDW<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int mUmASefRKofkiiVzFAJqZEovSQCDb(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return 0;
					}
					return nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.VXZJrvsSnUPusWufVbpmONxopgDh(P_2, P_3, false);
				}

				private int mUmASefRKofkiiVzFAJqZEovSQCDb(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return mUmASefRKofkiiVzFAJqZEovSQCDb(P_0.type, P_0.id, P_1, P_2);
				}

				private int mUmASefRKofkiiVzFAJqZEovSQCDb(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return mUmASefRKofkiiVzFAJqZEovSQCDb(P_0, P_1, mapCategoryId, P_3);
				}

				private int mUmASefRKofkiiVzFAJqZEovSQCDb(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return mUmASefRKofkiiVzFAJqZEovSQCDb(P_0.type, P_0.id, P_1, P_2);
				}

				private IEnumerable<ControllerMap> BtyiZkcDOZnhezZscgetgGVXaGlZ(ControllerType P_0, int P_1, int P_2)
				{
					return new RMzdBRHfzDbShYETPekDelVKKgFtB(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_1,
						FrrnxkXqcsEFarRYbqqHIgYdPqfP = P_2
					};
				}

				private IEnumerable<_0001> BtyiZkcDOZnhezZscgetgGVXaGlZ<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new kqFacCbqtWcGnYCqubPCLCsujDfAA<_0001>(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_0,
						FrrnxkXqcsEFarRYbqqHIgYdPqfP = P_1
					};
				}

				private ActionElementMap auqKJxHrKBUEMqidjhbvJAJovxDkA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
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

				private ActionElementMap auqKJxHrKBUEMqidjhbvJAJovxDkA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return auqKJxHrKBUEMqidjhbvJAJovxDkA(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> SfghliPkqrAXovDIoUXKWsgrjhhg(ControllerType P_0, int P_1, bool P_2)
				{
					return new AUKZShrKlbTRYiYmNGpwpIDMxzee(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_1,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_2
					};
				}

				private IEnumerable<ActionElementMap> SfghliPkqrAXovDIoUXKWsgrjhhg(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return SfghliPkqrAXovDIoUXKWsgrjhhg(P_0, num, P_2);
				}

				private ActionElementMap eBseNodGqWNciAWifLhRKMAGukzhA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
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

				private ActionElementMap eBseNodGqWNciAWifLhRKMAGukzhA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return eBseNodGqWNciAWifLhRKMAGukzhA(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> ByXipWeKgeoafsKaWWWWmHhNqtEK(ControllerType P_0, int P_1, bool P_2)
				{
					return new BbmzxARKpLawonENdlRXYQELVDlv(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_1,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_2
					};
				}

				private IEnumerable<ActionElementMap> ByXipWeKgeoafsKaWWWWmHhNqtEK(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return ByXipWeKgeoafsKaWWWWmHhNqtEK(P_0, num, P_2);
				}

				private ActionElementMap iXIbOLmYbJrOryrqnafihwGwWCPX(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
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

				private ActionElementMap iXIbOLmYbJrOryrqnafihwGwWCPX(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return iXIbOLmYbJrOryrqnafihwGwWCPX(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> LNQNZYyRaJBpPyULisvuupQDIsLN(ControllerType P_0, int P_1, bool P_2)
				{
					return new vVIlZeBzmopEvdDeCYGnRIhEwcBI(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_1,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_2
					};
				}

				private IEnumerable<ActionElementMap> LNQNZYyRaJBpPyULisvuupQDIsLN(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return LNQNZYyRaJBpPyULisvuupQDIsLN(P_0, num, P_2);
				}

				private int fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num2; j++)
						{
							zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							int num3 = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int pLtPLpYzEmAgeTsckCkqdEboCooK(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num2; j++)
						{
							zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							int num3 = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							for (int k = 0; k < num3; k++)
							{
								if (zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.pLtPLpYzEmAgeTsckCkqdEboCooK(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int KnhZxXTPhhiXJgFttivQXWIEaevD(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int zQqQltuirEhRybMOxWCRGTiKWPGW = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i);
						int num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						for (int j = 0; j < num2; j++)
						{
							zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
							int num3 = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.KnhZxXTPhhiXJgFttivQXWIEaevD(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int AjdLvPMfCVfWnZCUdXcSnZjnTrbb(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int AjdLvPMfCVfWnZCUdXcSnZjnTrbb(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return AjdLvPMfCVfWnZCUdXcSnZjnTrbb(P_0, num, P_2, P_3, P_4);
				}

				private int nBhHMlfSVWSUcfyNzfjWnzudPlzw(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).pLtPLpYzEmAgeTsckCkqdEboCooK(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int nBhHMlfSVWSUcfyNzfjWnzudPlzw(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return nBhHMlfSVWSUcfyNzfjWnzudPlzw(P_0, num, P_2, P_3, P_4);
				}

				private int zNlORBANBLmisqYxanxMBqtCCmWG(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					for (int i = 0; i < nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
					{
						IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].KnhZxXTPhhiXJgFttivQXWIEaevD(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int zNlORBANBLmisqYxanxMBqtCCmWG(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_1);
					return zNlORBANBLmisqYxanxMBqtCCmWG(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap auqKJxHrKBUEMqidjhbvJAJovxDkA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
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

				private ActionElementMap auqKJxHrKBUEMqidjhbvJAJovxDkA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return auqKJxHrKBUEMqidjhbvJAJovxDkA(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> SfghliPkqrAXovDIoUXKWsgrjhhg(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new raVymdmwGdkqEmSuCglXjBhczrMD(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_1,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3
					};
				}

				private IEnumerable<ActionElementMap> SfghliPkqrAXovDIoUXKWsgrjhhg(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return SfghliPkqrAXovDIoUXKWsgrjhhg(P_0, P_1, num, P_3);
				}

				private ActionElementMap eBseNodGqWNciAWifLhRKMAGukzhA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
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

				private ActionElementMap eBseNodGqWNciAWifLhRKMAGukzhA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return eBseNodGqWNciAWifLhRKMAGukzhA(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> ByXipWeKgeoafsKaWWWWmHhNqtEK(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new JVVsbpjVqOISBlGewhtTzOvzdUbM(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_1,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3
					};
				}

				private IEnumerable<ActionElementMap> ByXipWeKgeoafsKaWWWWmHhNqtEK(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return ByXipWeKgeoafsKaWWWWmHhNqtEK(P_0, P_1, num, P_3);
				}

				private ActionElementMap iXIbOLmYbJrOryrqnafihwGwWCPX(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
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

				private ActionElementMap iXIbOLmYbJrOryrqnafihwGwWCPX(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return iXIbOLmYbJrOryrqnafihwGwWCPX(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> LNQNZYyRaJBpPyULisvuupQDIsLN(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new KRHgTsIssrfdMmnDKfEPHwUAThvaA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						MqPaOXjZWPyrPMgBSrXvwsjXgGZF = P_0,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_1,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3
					};
				}

				private IEnumerable<ActionElementMap> LNQNZYyRaJBpPyULisvuupQDIsLN(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return LNQNZYyRaJBpPyULisvuupQDIsLN(P_0, P_1, num, P_3);
				}

				private int AjdLvPMfCVfWnZCUdXcSnZjnTrbb(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int AjdLvPMfCVfWnZCUdXcSnZjnTrbb(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return AjdLvPMfCVfWnZCUdXcSnZjnTrbb(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int nBhHMlfSVWSUcfyNzfjWnzudPlzw(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.pLtPLpYzEmAgeTsckCkqdEboCooK(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int nBhHMlfSVWSUcfyNzfjWnzudPlzw(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return nBhHMlfSVWSUcfyNzfjWnzudPlzw(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int zNlORBANBLmisqYxanxMBqtCCmWG(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).gYfvSSlCQdvlHXoFtXExDLDXhhRu.STYcwQzrTqawulspAxBpyXIsFtBI;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].KnhZxXTPhhiXJgFttivQXWIEaevD(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int zNlORBANBLmisqYxanxMBqtCCmWG(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
					return zNlORBANBLmisqYxanxMBqtCCmWG(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap ofPtXzQRTSIwuudhHEmzQTQYglcR(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controller.type);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					for (int i = 0; i < num; i++)
					{
						zWbUQgTovQtSYwaKIfEFDBCoWmolA obj = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
						_ = obj.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						IList<ControllerMap> list = obj.STYcwQzrTqawulspAxBpyXIsFtBI;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.ofPtXzQRTSIwuudhHEmzQTQYglcR(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				private IEnumerable<ActionElementMap> XoSkNuDnGYkWdhdUDkPGpiGhNgYC(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new TyUttYNfguyEVzcmunynufOfblK(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						wBUHqUNJjoXfWXQdgnymGNNWmNON = P_0,
						ZGoiVbqrMfuvpBfqWWCdwkDzogdx = P_1,
						JVHPuraouxduvcIEzsfWFTjVVggFb = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3
					};
				}

				private int wykkVuZXYDRrQxJtgKBZdFoATLny(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
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
					nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controller.type);
					int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						zWbUQgTovQtSYwaKIfEFDBCoWmolA obj = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
						_ = obj.ZQqQltuirEhRybMOxWCRGTiKWPGW;
						IList<ControllerMap> list = obj.STYcwQzrTqawulspAxBpyXIsFtBI;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.wykkVuZXYDRrQxJtgKBZdFoATLny(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
							}
						}
					}
					return num2;
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class EaXFjlcPsjwtkjjLVSocCOZjevMcA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int ezTdnIGfSToEbTLpvfyDvodAFlz;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public EaXFjlcPsjwtkjjLVSocCOZjevMcA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							ezTdnIGfSToEbTLpvfyDvodAFlz = BJrakWAcuniYwCCjFGDLJNzTErjEc.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < ezTdnIGfSToEbTLpvfyDvodAFlz)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = BJrakWAcuniYwCCjFGDLJNzTErjEc[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllAxes().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						EaXFjlcPsjwtkjjLVSocCOZjevMcA eaXFjlcPsjwtkjjLVSocCOZjevMcA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							eaXFjlcPsjwtkjjLVSocCOZjevMcA = this;
						}
						else
						{
							eaXFjlcPsjwtkjjLVSocCOZjevMcA = new EaXFjlcPsjwtkjjLVSocCOZjevMcA(0);
							eaXFjlcPsjwtkjjLVSocCOZjevMcA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return eaXFjlcPsjwtkjjLVSocCOZjevMcA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kVcwYotfqDeSANzeWiskBoXmIdYE : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int ezTdnIGfSToEbTLpvfyDvodAFlz;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public kVcwYotfqDeSANzeWiskBoXmIdYE(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							ezTdnIGfSToEbTLpvfyDvodAFlz = BJrakWAcuniYwCCjFGDLJNzTErjEc.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < ezTdnIGfSToEbTLpvfyDvodAFlz)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = BJrakWAcuniYwCCjFGDLJNzTErjEc[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllButtons().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						kVcwYotfqDeSANzeWiskBoXmIdYE kVcwYotfqDeSANzeWiskBoXmIdYE2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							kVcwYotfqDeSANzeWiskBoXmIdYE2 = this;
						}
						else
						{
							kVcwYotfqDeSANzeWiskBoXmIdYE2 = new kVcwYotfqDeSANzeWiskBoXmIdYE(0);
							kVcwYotfqDeSANzeWiskBoXmIdYE2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return kVcwYotfqDeSANzeWiskBoXmIdYE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class tjYLsMCxIUcezhMXDeJOKoIztkRv : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int ezTdnIGfSToEbTLpvfyDvodAFlz;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public tjYLsMCxIUcezhMXDeJOKoIztkRv(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							ezTdnIGfSToEbTLpvfyDvodAFlz = BJrakWAcuniYwCCjFGDLJNzTErjEc.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < ezTdnIGfSToEbTLpvfyDvodAFlz)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = BJrakWAcuniYwCCjFGDLJNzTErjEc[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllButtonsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						tjYLsMCxIUcezhMXDeJOKoIztkRv tjYLsMCxIUcezhMXDeJOKoIztkRv2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							tjYLsMCxIUcezhMXDeJOKoIztkRv2 = this;
						}
						else
						{
							tjYLsMCxIUcezhMXDeJOKoIztkRv2 = new tjYLsMCxIUcezhMXDeJOKoIztkRv(0);
							tjYLsMCxIUcezhMXDeJOKoIztkRv2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return tjYLsMCxIUcezhMXDeJOKoIztkRv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WxcTnuCBbJUhqmWgwIQNfftLgyah : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int ezTdnIGfSToEbTLpvfyDvodAFlz;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public WxcTnuCBbJUhqmWgwIQNfftLgyah(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							ezTdnIGfSToEbTLpvfyDvodAFlz = BJrakWAcuniYwCCjFGDLJNzTErjEc.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < ezTdnIGfSToEbTLpvfyDvodAFlz)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = BJrakWAcuniYwCCjFGDLJNzTErjEc[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllElements().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						WxcTnuCBbJUhqmWgwIQNfftLgyah wxcTnuCBbJUhqmWgwIQNfftLgyah;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							wxcTnuCBbJUhqmWgwIQNfftLgyah = this;
						}
						else
						{
							wxcTnuCBbJUhqmWgwIQNfftLgyah = new WxcTnuCBbJUhqmWgwIQNfftLgyah(0);
							wxcTnuCBbJUhqmWgwIQNfftLgyah.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return wxcTnuCBbJUhqmWgwIQNfftLgyah;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RlYkOwhKOVzCVSjimkvzQAEDlaBd : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int ezTdnIGfSToEbTLpvfyDvodAFlz;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public RlYkOwhKOVzCVSjimkvzQAEDlaBd(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							ezTdnIGfSToEbTLpvfyDvodAFlz = BJrakWAcuniYwCCjFGDLJNzTErjEc.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < ezTdnIGfSToEbTLpvfyDvodAFlz)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = BJrakWAcuniYwCCjFGDLJNzTErjEc[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllElementsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						RlYkOwhKOVzCVSjimkvzQAEDlaBd rlYkOwhKOVzCVSjimkvzQAEDlaBd;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							rlYkOwhKOVzCVSjimkvzQAEDlaBd = this;
						}
						else
						{
							rlYkOwhKOVzCVSjimkvzQAEDlaBd = new RlYkOwhKOVzCVSjimkvzQAEDlaBd(0);
							rlYkOwhKOVzCVSjimkvzQAEDlaBd.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return rlYkOwhKOVzCVSjimkvzQAEDlaBd;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class JLaCIpXrkEpcXMOdAVIznJZghzaw : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int mCcZrCBSuQOTERqBSYIyyVCfoFvv;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public JLaCIpXrkEpcXMOdAVIznJZghzaw(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							mCcZrCBSuQOTERqBSYIyyVCfoFvv = dFvibRcRDVveDJeYGllnIcmjkeicA.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < mCcZrCBSuQOTERqBSYIyyVCfoFvv)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = dFvibRcRDVveDJeYGllnIcmjkeicA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllAxes().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						JLaCIpXrkEpcXMOdAVIznJZghzaw jLaCIpXrkEpcXMOdAVIznJZghzaw;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							jLaCIpXrkEpcXMOdAVIznJZghzaw = this;
						}
						else
						{
							jLaCIpXrkEpcXMOdAVIznJZghzaw = new JLaCIpXrkEpcXMOdAVIznJZghzaw(0);
							jLaCIpXrkEpcXMOdAVIznJZghzaw.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return jLaCIpXrkEpcXMOdAVIznJZghzaw;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class vVULXndcnhYzqMTVIuLrtiOtoLUb : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int mCcZrCBSuQOTERqBSYIyyVCfoFvv;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public vVULXndcnhYzqMTVIuLrtiOtoLUb(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							mCcZrCBSuQOTERqBSYIyyVCfoFvv = dFvibRcRDVveDJeYGllnIcmjkeicA.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < mCcZrCBSuQOTERqBSYIyyVCfoFvv)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = dFvibRcRDVveDJeYGllnIcmjkeicA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllButtons().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						vVULXndcnhYzqMTVIuLrtiOtoLUb vVULXndcnhYzqMTVIuLrtiOtoLUb2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vVULXndcnhYzqMTVIuLrtiOtoLUb2 = this;
						}
						else
						{
							vVULXndcnhYzqMTVIuLrtiOtoLUb2 = new vVULXndcnhYzqMTVIuLrtiOtoLUb(0);
							vVULXndcnhYzqMTVIuLrtiOtoLUb2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return vVULXndcnhYzqMTVIuLrtiOtoLUb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IbSRFLmqFwAYCePWhuZynskBjqYH : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int mCcZrCBSuQOTERqBSYIyyVCfoFvv;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public IbSRFLmqFwAYCePWhuZynskBjqYH(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							mCcZrCBSuQOTERqBSYIyyVCfoFvv = dFvibRcRDVveDJeYGllnIcmjkeicA.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < mCcZrCBSuQOTERqBSYIyyVCfoFvv)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = dFvibRcRDVveDJeYGllnIcmjkeicA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllButtonsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						IbSRFLmqFwAYCePWhuZynskBjqYH ibSRFLmqFwAYCePWhuZynskBjqYH;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							ibSRFLmqFwAYCePWhuZynskBjqYH = this;
						}
						else
						{
							ibSRFLmqFwAYCePWhuZynskBjqYH = new IbSRFLmqFwAYCePWhuZynskBjqYH(0);
							ibSRFLmqFwAYCePWhuZynskBjqYH.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return ibSRFLmqFwAYCePWhuZynskBjqYH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ucFrbLAIbdmiQNLTFPOsSMUwqalM : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int mCcZrCBSuQOTERqBSYIyyVCfoFvv;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public ucFrbLAIbdmiQNLTFPOsSMUwqalM(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							mCcZrCBSuQOTERqBSYIyyVCfoFvv = dFvibRcRDVveDJeYGllnIcmjkeicA.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < mCcZrCBSuQOTERqBSYIyyVCfoFvv)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = dFvibRcRDVveDJeYGllnIcmjkeicA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllElements().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						ucFrbLAIbdmiQNLTFPOsSMUwqalM ucFrbLAIbdmiQNLTFPOsSMUwqalM2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							ucFrbLAIbdmiQNLTFPOsSMUwqalM2 = this;
						}
						else
						{
							ucFrbLAIbdmiQNLTFPOsSMUwqalM2 = new ucFrbLAIbdmiQNLTFPOsSMUwqalM(0);
							ucFrbLAIbdmiQNLTFPOsSMUwqalM2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return ucFrbLAIbdmiQNLTFPOsSMUwqalM2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class EPrGazPRMAupLaRUaFubAiZLrLbT : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int mCcZrCBSuQOTERqBSYIyyVCfoFvv;

					private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

					private IEnumerator<ControllerPollingInfo> bkquoUcymlRMmAtNBtrWsdUMfoBeA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public EPrGazPRMAupLaRUaFubAiZLrLbT(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00c5;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
							mCcZrCBSuQOTERqBSYIyyVCfoFvv = dFvibRcRDVveDJeYGllnIcmjkeicA.Count;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
							goto IL_00f1;
							IL_00c5:
							if (bkquoUcymlRMmAtNBtrWsdUMfoBeA.MoveNext())
							{
								ControllerPollingInfo current = bkquoUcymlRMmAtNBtrWsdUMfoBeA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							bkquoUcymlRMmAtNBtrWsdUMfoBeA = null;
							jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
							goto IL_00f1;
							IL_00f1:
							if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < mCcZrCBSuQOTERqBSYIyyVCfoFvv)
							{
								bkquoUcymlRMmAtNBtrWsdUMfoBeA = dFvibRcRDVveDJeYGllnIcmjkeicA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].PollForAllElementsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (bkquoUcymlRMmAtNBtrWsdUMfoBeA != null)
						{
							bkquoUcymlRMmAtNBtrWsdUMfoBeA.Dispose();
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
						EPrGazPRMAupLaRUaFubAiZLrLbT ePrGazPRMAupLaRUaFubAiZLrLbT;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							ePrGazPRMAupLaRUaFubAiZLrLbT = this;
						}
						else
						{
							ePrGazPRMAupLaRUaFubAiZLrLbT = new EPrGazPRMAupLaRUaFubAiZLrLbT(0);
							ePrGazPRMAupLaRUaFubAiZLrLbT.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return ePrGazPRMAupLaRUaFubAiZLrLbT;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class dwvARxRkqcGMsVZvUYqaDFlxbrxn : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public dwvARxRkqcGMsVZvUYqaDFlxbrxn(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(GKMAkeKDuSYwRgXGsIoemQeEFFeiA);
								if (customController == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = customController.PollForAllAxes().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						dwvARxRkqcGMsVZvUYqaDFlxbrxn dwvARxRkqcGMsVZvUYqaDFlxbrxn2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							dwvARxRkqcGMsVZvUYqaDFlxbrxn2 = this;
						}
						else
						{
							dwvARxRkqcGMsVZvUYqaDFlxbrxn2 = new dwvARxRkqcGMsVZvUYqaDFlxbrxn(0);
							dwvARxRkqcGMsVZvUYqaDFlxbrxn2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						dwvARxRkqcGMsVZvUYqaDFlxbrxn2.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						return dwvARxRkqcGMsVZvUYqaDFlxbrxn2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RCdclibAzHWeQNRdnaPPYnSyAOvuA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public RCdclibAzHWeQNRdnaPPYnSyAOvuA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(GKMAkeKDuSYwRgXGsIoemQeEFFeiA);
								if (customController == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = customController.PollForAllButtons().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						RCdclibAzHWeQNRdnaPPYnSyAOvuA rCdclibAzHWeQNRdnaPPYnSyAOvuA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							rCdclibAzHWeQNRdnaPPYnSyAOvuA = this;
						}
						else
						{
							rCdclibAzHWeQNRdnaPPYnSyAOvuA = new RCdclibAzHWeQNRdnaPPYnSyAOvuA(0);
							rCdclibAzHWeQNRdnaPPYnSyAOvuA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						rCdclibAzHWeQNRdnaPPYnSyAOvuA.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						return rCdclibAzHWeQNRdnaPPYnSyAOvuA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class eoCVfIvItUcbGnwCAqprtCojbphZ : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public eoCVfIvItUcbGnwCAqprtCojbphZ(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(GKMAkeKDuSYwRgXGsIoemQeEFFeiA);
								if (customController == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = customController.PollForAllButtonsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						eoCVfIvItUcbGnwCAqprtCojbphZ eoCVfIvItUcbGnwCAqprtCojbphZ2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							eoCVfIvItUcbGnwCAqprtCojbphZ2 = this;
						}
						else
						{
							eoCVfIvItUcbGnwCAqprtCojbphZ2 = new eoCVfIvItUcbGnwCAqprtCojbphZ(0);
							eoCVfIvItUcbGnwCAqprtCojbphZ2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						eoCVfIvItUcbGnwCAqprtCojbphZ2.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						return eoCVfIvItUcbGnwCAqprtCojbphZ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class krNZklDokcEzNBtzeJahBSJyjDVQA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public krNZklDokcEzNBtzeJahBSJyjDVQA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(GKMAkeKDuSYwRgXGsIoemQeEFFeiA);
								if (customController == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = customController.PollForAllElements().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						krNZklDokcEzNBtzeJahBSJyjDVQA krNZklDokcEzNBtzeJahBSJyjDVQA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							krNZklDokcEzNBtzeJahBSJyjDVQA2 = this;
						}
						else
						{
							krNZklDokcEzNBtzeJahBSJyjDVQA2 = new krNZklDokcEzNBtzeJahBSJyjDVQA(0);
							krNZklDokcEzNBtzeJahBSJyjDVQA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						krNZklDokcEzNBtzeJahBSJyjDVQA2.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						return krNZklDokcEzNBtzeJahBSJyjDVQA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xSWcXhlMIXXvhsGZUKeMwBAdFIoW : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int GKMAkeKDuSYwRgXGsIoemQeEFFeiA;

					public int GZcTEpEXInUciLcXqFDOMdXpbcyo;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public xSWcXhlMIXXvhsGZUKeMwBAdFIoW(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (GKMAkeKDuSYwRgXGsIoemQeEFFeiA < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(GKMAkeKDuSYwRgXGsIoemQeEFFeiA);
								if (customController == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = customController.PollForAllElementsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						xSWcXhlMIXXvhsGZUKeMwBAdFIoW xSWcXhlMIXXvhsGZUKeMwBAdFIoW2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							xSWcXhlMIXXvhsGZUKeMwBAdFIoW2 = this;
						}
						else
						{
							xSWcXhlMIXXvhsGZUKeMwBAdFIoW2 = new xSWcXhlMIXXvhsGZUKeMwBAdFIoW(0);
							xSWcXhlMIXXvhsGZUKeMwBAdFIoW2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						xSWcXhlMIXXvhsGZUKeMwBAdFIoW2.GKMAkeKDuSYwRgXGsIoemQeEFFeiA = GZcTEpEXInUciLcXqFDOMdXpbcyo;
						return xSWcXhlMIXXvhsGZUKeMwBAdFIoW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class NXdcyjCJRVxEqAMqLynQGFusClVP : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public NXdcyjCJRVxEqAMqLynQGFusClVP(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(ZRqGPmiZYbBMxFgPHLFMZTmGNtUC);
								if (joystick == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = joystick.PollForAllAxes().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						NXdcyjCJRVxEqAMqLynQGFusClVP nXdcyjCJRVxEqAMqLynQGFusClVP;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							nXdcyjCJRVxEqAMqLynQGFusClVP = this;
						}
						else
						{
							nXdcyjCJRVxEqAMqLynQGFusClVP = new NXdcyjCJRVxEqAMqLynQGFusClVP(0);
							nXdcyjCJRVxEqAMqLynQGFusClVP.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						nXdcyjCJRVxEqAMqLynQGFusClVP.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						return nXdcyjCJRVxEqAMqLynQGFusClVP;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class KvdqaxuOOEFepTKXIJLEfEpfGvYBA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public KvdqaxuOOEFepTKXIJLEfEpfGvYBA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(ZRqGPmiZYbBMxFgPHLFMZTmGNtUC);
								if (joystick == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = joystick.PollForAllButtons().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						KvdqaxuOOEFepTKXIJLEfEpfGvYBA kvdqaxuOOEFepTKXIJLEfEpfGvYBA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							kvdqaxuOOEFepTKXIJLEfEpfGvYBA = this;
						}
						else
						{
							kvdqaxuOOEFepTKXIJLEfEpfGvYBA = new KvdqaxuOOEFepTKXIJLEfEpfGvYBA(0);
							kvdqaxuOOEFepTKXIJLEfEpfGvYBA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						kvdqaxuOOEFepTKXIJLEfEpfGvYBA.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						return kvdqaxuOOEFepTKXIJLEfEpfGvYBA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ddkxacEBmCleumfZYzqYXuMENJWA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public ddkxacEBmCleumfZYzqYXuMENJWA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(ZRqGPmiZYbBMxFgPHLFMZTmGNtUC);
								if (joystick == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = joystick.PollForAllButtonsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						ddkxacEBmCleumfZYzqYXuMENJWA ddkxacEBmCleumfZYzqYXuMENJWA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							ddkxacEBmCleumfZYzqYXuMENJWA2 = this;
						}
						else
						{
							ddkxacEBmCleumfZYzqYXuMENJWA2 = new ddkxacEBmCleumfZYzqYXuMENJWA(0);
							ddkxacEBmCleumfZYzqYXuMENJWA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						ddkxacEBmCleumfZYzqYXuMENJWA2.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						return ddkxacEBmCleumfZYzqYXuMENJWA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class VUNzhQXiaoCqsRwTKFejytbzgUok : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public VUNzhQXiaoCqsRwTKFejytbzgUok(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(ZRqGPmiZYbBMxFgPHLFMZTmGNtUC);
								if (joystick == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = joystick.PollForAllElements().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						VUNzhQXiaoCqsRwTKFejytbzgUok vUNzhQXiaoCqsRwTKFejytbzgUok;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vUNzhQXiaoCqsRwTKFejytbzgUok = this;
						}
						else
						{
							vUNzhQXiaoCqsRwTKFejytbzgUok = new VUNzhQXiaoCqsRwTKFejytbzgUok(0);
							vUNzhQXiaoCqsRwTKFejytbzgUok.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						vUNzhQXiaoCqsRwTKFejytbzgUok.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						return vUNzhQXiaoCqsRwTKFejytbzgUok;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class YPFwyNkVeshErUPlEKznJOUsHpOs : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int ZRqGPmiZYbBMxFgPHLFMZTmGNtUC;

					public int PMtAEEkuCccwZeLWnTFAhYltpIRVA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public YPFwyNkVeshErUPlEKznJOUsHpOs(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (ZRqGPmiZYbBMxFgPHLFMZTmGNtUC < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(ZRqGPmiZYbBMxFgPHLFMZTmGNtUC);
								if (joystick == null)
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = joystick.PollForAllElementsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
								vjnbYLtrPMftzpjohNfommerCnGo = controllerPollingInfo;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						YPFwyNkVeshErUPlEKznJOUsHpOs yPFwyNkVeshErUPlEKznJOUsHpOs;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							yPFwyNkVeshErUPlEKznJOUsHpOs = this;
						}
						else
						{
							yPFwyNkVeshErUPlEKznJOUsHpOs = new YPFwyNkVeshErUPlEKznJOUsHpOs(0);
							yPFwyNkVeshErUPlEKznJOUsHpOs.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						yPFwyNkVeshErUPlEKznJOUsHpOs.ZRqGPmiZYbBMxFgPHLFMZTmGNtUC = PMtAEEkuCccwZeLWnTFAhYltpIRVA;
						return yPFwyNkVeshErUPlEKznJOUsHpOs;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV;

				private readonly ControllerHelper TqAZNEcFJkyctXeLFKcYDRxOBxRA;

				private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
					tYEyiSjpdwwbqdDLYhlcYJwwGWGV = P_0;
					TqAZNEcFJkyctXeLFKcYDRxOBxRA = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Joystick:
						return ejYPOOdmKNdgkStTLPEdEehziMPe(controllerId);
					case ControllerType.Mouse:
						return cXZtpKDQPOkhyrVtgHCQnELHyciM();
					case ControllerType.Custom:
						return pcIWrJebwwbQtTtbLQBGMmHbKRNk(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Joystick:
						return wjgagChGtVvfXsLPqPkmojQZvYot(controllerId);
					case ControllerType.Mouse:
						return nuSreGCzpEBxxicywpMubCTEltzc();
					case ControllerType.Custom:
						return VlmwmYmdHFjTAdmoWBzuooKKrtYI(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Joystick:
						return QtbHNHvyUsymtObBvGbKbAwvotMs(controllerId);
					case ControllerType.Mouse:
						return zaagIdowssLQhSunvoZjUnmlPsMH();
					case ControllerType.Custom:
						return WuTMFGBEyfuDrPFVvtdmAAlAbtzX(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Joystick:
						return UYzfhPjkfANhXsiNxjrRNRCZCSvS(controllerId);
					case ControllerType.Mouse:
						return XgyGPKhNoljdhVjitvWvLjnXgePrA();
					case ControllerType.Custom:
						return PUiPdtWiaZgHfkqLAnzmqCjSEUemA(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					case ControllerType.Joystick:
						return vGGfpHRXpyfrjfCYHWHBClQHSjxw(controllerId);
					case ControllerType.Mouse:
						return zSvEifalrfODDNoABFpRPGMyCfAc();
					case ControllerType.Custom:
						return vGMNcClDtvYQoZbjbFcrXFYlAPrH(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return rvnaOLgaxuIAxIIEbkBLpUOjqDTlA();
					case ControllerType.Joystick:
						return OOizvKrkGiVWXuZbcCbkwaApPqTl(controllerId);
					case ControllerType.Mouse:
						return IjcPqNgsAItaNjmrDiSLuMLCgiID();
					case ControllerType.Custom:
						return zAapFwGrVVOlKsDdYBSOHHBullnn(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return FIphJcbQIzbEoapGNLwdDVrxfnAEA();
					case ControllerType.Joystick:
						return OlhEuGAcuZKqzlylgMuHUHYzSNlbA(controllerId);
					case ControllerType.Mouse:
						return COmnSQIbXFupBKNHIxuIhGhHfUfs();
					case ControllerType.Custom:
						return QQGCgJbWECVeNSoTJFWiQVgIGmDaA(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return rvnaOLgaxuIAxIIEbkBLpUOjqDTlA();
					case ControllerType.Joystick:
						return wYPIvrDAtQElNWiMpRXhNEKPNKLV(controllerId);
					case ControllerType.Mouse:
						return zpGBymewFWBWBgEBpYYhrXVAverw();
					case ControllerType.Custom:
						return RMxPteBcefeLaBVGhREANIpFLCKv(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return FIphJcbQIzbEoapGNLwdDVrxfnAEA();
					case ControllerType.Joystick:
						return NsvEfTnPPlFSKbVxATgDNODWrFJxA(controllerId);
					case ControllerType.Mouse:
						return LQRwQnXcKswcCvRcqnVrYlUoAOqb();
					case ControllerType.Custom:
						return DGpfocvmQoPUZwAXowPlQvrQgfvD(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Joystick:
						return NViOXQCFiQDgDArKDDqnjkaZTXUGA(controllerId);
					case ControllerType.Mouse:
						return HQKEnqngVrHYwwXNURtjEUNpGPjm();
					case ControllerType.Custom:
						return AOQiAvLtdvAreSrKGTzeNrBUAMTB(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Joystick:
						return ypMqnEYHLwirLNfYkgLEJCqBAZoR();
					case ControllerType.Mouse:
						return cXZtpKDQPOkhyrVtgHCQnELHyciM();
					case ControllerType.Custom:
						return bUTuxCoEPXUMPFracgmKxBSgClvx();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Joystick:
						return WnjFweDJRngPJBkZEuLYROLCbNhwB();
					case ControllerType.Mouse:
						return zaagIdowssLQhSunvoZjUnmlPsMH();
					case ControllerType.Custom:
						return qgtDCoIbnLQDRiUGKwqhGwVzVeChA();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Joystick:
						return KwkFCJLsMCEPwWHxRXnzdLdGGtJb();
					case ControllerType.Mouse:
						return XgyGPKhNoljdhVjitvWvLjnXgePrA();
					case ControllerType.Custom:
						return WvdxiMtZoIIglhTzqpCqhjkfCfcJ();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					case ControllerType.Joystick:
						return ZnNJGuqKEZfLpqZURYMmNlmNKnag();
					case ControllerType.Mouse:
						return zSvEifalrfODDNoABFpRPGMyCfAc();
					case ControllerType.Custom:
						return navsxKifmZkqqSOQGGBVxtgCYmlG();
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return rvnaOLgaxuIAxIIEbkBLpUOjqDTlA();
					case ControllerType.Joystick:
						return DBhqvXxfHjgtvrMjptbrneoAgmkW();
					case ControllerType.Mouse:
						return IjcPqNgsAItaNjmrDiSLuMLCgiID();
					case ControllerType.Custom:
						return elNBQONYQdWdwwYoyBVyXZOoDjcn();
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return FIphJcbQIzbEoapGNLwdDVrxfnAEA();
					case ControllerType.Joystick:
						return szGOZwgcZoIuVIhwTCJTGlTiHoaQ();
					case ControllerType.Mouse:
						return COmnSQIbXFupBKNHIxuIhGhHfUfs();
					case ControllerType.Custom:
						return UNuaRNmbTJMkLuDfTGKlemfXVJBk();
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return rvnaOLgaxuIAxIIEbkBLpUOjqDTlA();
					case ControllerType.Joystick:
						return YJGzfywfcOfmLwaOriTkFlfZrBbrA();
					case ControllerType.Mouse:
						return zpGBymewFWBWBgEBpYYhrXVAverw();
					case ControllerType.Custom:
						return ZsGecQDEgguHLNvTsoSBGZoNXHbSA();
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return FIphJcbQIzbEoapGNLwdDVrxfnAEA();
					case ControllerType.Joystick:
						return hVQtYAdUnYfGfhsyRyNshpENBZgx();
					case ControllerType.Mouse:
						return LQRwQnXcKswcCvRcqnVrYlUoAOqb();
					case ControllerType.Custom:
						return phCZPrrsaebcpTnQmPfDsUctvTmj();
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Joystick:
						return HDiIkLFAHWUCutohMeYaOcPMdSkFA();
					case ControllerType.Mouse:
						return HQKEnqngVrHYwwXNURtjEUNpGPjm();
					case ControllerType.Custom:
						return nSVfeBTisfOodDapRLInNDpZgGbR();
					default:
						throw new NotImplementedException();
					}
				}

				private ControllerPollingInfo ejYPOOdmKNdgkStTLPEdEehziMPe(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					Joystick joystick = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo wjgagChGtVvfXsLPqPkmojQZvYot(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					Joystick joystick = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo QtbHNHvyUsymtObBvGbKbAwvotMs(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					Joystick joystick = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo UYzfhPjkfANhXsiNxjrRNRCZCSvS(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					Joystick joystick = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo vGGfpHRXpyfrjfCYHWHBClQHSjxw(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					Joystick joystick = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> OOizvKrkGiVWXuZbcCbkwaApPqTl(int P_0)
				{
					return new VUNzhQXiaoCqsRwTKFejytbzgUok(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> OlhEuGAcuZKqzlylgMuHUHYzSNlbA(int P_0)
				{
					return new YPFwyNkVeshErUPlEKznJOUsHpOs(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> wYPIvrDAtQElNWiMpRXhNEKPNKLV(int P_0)
				{
					return new KvdqaxuOOEFepTKXIJLEfEpfGvYBA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> NsvEfTnPPlFSKbVxATgDNODWrFJxA(int P_0)
				{
					return new ddkxacEBmCleumfZYzqYXuMENJWA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> NViOXQCFiQDgDArKDDqnjkaZTXUGA(int P_0)
				{
					return new NXdcyjCJRVxEqAMqLynQGFusClVP(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						PMtAEEkuCccwZeLWnTFAhYltpIRVA = P_0
					};
				}

				private ControllerPollingInfo ypMqnEYHLwirLNfYkgLEJCqBAZoR()
				{
					IList<Joystick> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo apShCnCKWQcmOORYuxnFjmchzrnf()
				{
					IList<Joystick> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo WnjFweDJRngPJBkZEuLYROLCbNhwB()
				{
					IList<Joystick> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo KwkFCJLsMCEPwWHxRXnzdLdGGtJb()
				{
					IList<Joystick> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo ZnNJGuqKEZfLpqZURYMmNlmNKnag()
				{
					IList<Joystick> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.wTVjGBEHdWuQtbRoAMEnHdUSjVZg.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private IEnumerable<ControllerPollingInfo> DBhqvXxfHjgtvrMjptbrneoAgmkW()
				{
					return new ucFrbLAIbdmiQNLTFPOsSMUwqalM(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> szGOZwgcZoIuVIhwTCJTGlTiHoaQ()
				{
					return new EPrGazPRMAupLaRUaFubAiZLrLbT(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> YJGzfywfcOfmLwaOriTkFlfZrBbrA()
				{
					return new vVULXndcnhYzqMTVIuLrtiOtoLUb(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> hVQtYAdUnYfGfhsyRyNshpENBZgx()
				{
					return new IbSRFLmqFwAYCePWhuZynskBjqYH(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> HDiIkLFAHWUCutohMeYaOcPMdSkFA()
				{
					return new JLaCIpXrkEpcXMOdAVIznJZghzaw(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private ControllerPollingInfo MQqpWWBmMNwtawUzwaIpBtWdCncr()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.hqtaydwRTeyrOgkCiESPCFtXBOdjb)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo jaSBAmrHXAJkKXNerfnGasZMuqYmA()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.hqtaydwRTeyrOgkCiESPCFtXBOdjb)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> rvnaOLgaxuIAxIIEbkBLpUOjqDTlA()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.hqtaydwRTeyrOgkCiESPCFtXBOdjb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> FIphJcbQIzbEoapGNLwdDVrxfnAEA()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.hqtaydwRTeyrOgkCiESPCFtXBOdjb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo cXZtpKDQPOkhyrVtgHCQnELHyciM()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo nuSreGCzpEBxxicywpMubCTEltzc()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo zaagIdowssLQhSunvoZjUnmlPsMH()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo XgyGPKhNoljdhVjitvWvLjnXgePrA()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo zSvEifalrfODDNoABFpRPGMyCfAc()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> IjcPqNgsAItaNjmrDiSLuMLCgiID()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> COmnSQIbXFupBKNHIxuIhGhHfUfs()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> zpGBymewFWBWBgEBpYYhrXVAverw()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> LQRwQnXcKswcCvRcqnVrYlUoAOqb()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> HQKEnqngVrHYwwXNURtjEUNpGPjm()
				{
					if (!TqAZNEcFJkyctXeLFKcYDRxOBxRA.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return TqAZNEcFJkyctXeLFKcYDRxOBxRA.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo pcIWrJebwwbQtTtbLQBGMmHbKRNk(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					CustomController customController = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo VlmwmYmdHFjTAdmoWBzuooKKrtYI(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					CustomController customController = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo WuTMFGBEyfuDrPFVvtdmAAlAbtzX(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					CustomController customController = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo PUiPdtWiaZgHfkqLAnzmqCjSEUemA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					CustomController customController = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private ControllerPollingInfo vGMNcClDtvYQoZbjbFcrXFYlAPrH(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					CustomController customController = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> zAapFwGrVVOlKsDdYBSOHHBullnn(int P_0)
				{
					return new krNZklDokcEzNBtzeJahBSJyjDVQA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> QQGCgJbWECVeNSoTJFWiQVgIGmDaA(int P_0)
				{
					return new xSWcXhlMIXXvhsGZUKeMwBAdFIoW(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> RMxPteBcefeLaBVGhREANIpFLCKv(int P_0)
				{
					return new RCdclibAzHWeQNRdnaPPYnSyAOvuA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> DGpfocvmQoPUZwAXowPlQvrQgfvD(int P_0)
				{
					return new eoCVfIvItUcbGnwCAqprtCojbphZ(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0
					};
				}

				private IEnumerable<ControllerPollingInfo> AOQiAvLtdvAreSrKGTzeNrBUAMTB(int P_0)
				{
					return new dwvARxRkqcGMsVZvUYqaDFlxbrxn(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
						GZcTEpEXInUciLcXqFDOMdXpbcyo = P_0
					};
				}

				private ControllerPollingInfo bUTuxCoEPXUMPFracgmKxBSgClvx()
				{
					IList<CustomController> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo McJTuSgrPGdijixFotMaQjWaNvcc()
				{
					IList<CustomController> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo qgtDCoIbnLQDRiUGKwqhGwVzVeChA()
				{
					IList<CustomController> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo WvdxiMtZoIIglhTzqpCqhjkfCfcJ()
				{
					IList<CustomController> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo navsxKifmZkqqSOQGGBVxtgCYmlG()
				{
					IList<CustomController> list = TqAZNEcFJkyctXeLFKcYDRxOBxRA.RcZLNAxmXXbPoDnGQnTkuRUWCmiuA.obQHJhFYcXmdSoAwadTzguTKNZpjA;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn;
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private IEnumerable<ControllerPollingInfo> elNBQONYQdWdwwYoyBVyXZOoDjcn()
				{
					return new WxcTnuCBbJUhqmWgwIQNfftLgyah(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> UNuaRNmbTJMkLuDfTGKlemfXVJBk()
				{
					return new RlYkOwhKOVzCVSjimkvzQAEDlaBd(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> ZsGecQDEgguHLNvTsoSBGZoNXHbSA()
				{
					return new kVcwYotfqDeSANzeWiskBoXmIdYE(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> phCZPrrsaebcpTnQmPfDsUctvTmj()
				{
					return new tjYLsMCxIUcezhMXDeJOKoIztkRv(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				private IEnumerable<ControllerPollingInfo> nSVfeBTisfOodDapRLInNDpZgGbR()
				{
					return new EaXFjlcPsjwtkjjLVSocCOZjevMcA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}
			}

			[Serializable]
			private sealed class umUCOXZVBRiQuilGMEZNJsBnLHGeb
			{
				public static readonly umUCOXZVBRiQuilGMEZNJsBnLHGeb _003C_003E9 = new umUCOXZVBRiQuilGMEZNJsBnLHGeb();

				public static Action<Exception> _003C_003E9__23_0;

				public static Action<Exception> _003C_003E9__23_1;

				internal void qeGQuZRAkawSyrWrCRnOCJjaOgdB(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void IIXlWdVmCCSwQgaQXouaqnacKIaY(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class kPZMDTiHDvgpyxkGrNZecohpqdLj : IDisposable, IEnumerable, IEnumerator, IEnumerable<Controller>, IEnumerator<Controller>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Controller vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public ControllerHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int ejTMCkenHDVEzckkUhSPQavYCCUj;

				private IList<Joystick> SGGHJqEAEAIDtxumeEsqaoovqTVI;

				private int tPDcuwaNTwOiDyHAhngoFqTdUArpB;

				private IList<CustomController> YubeOlIkhVEDJeEfldwIRJNDHBiCb;

				private int EOszwgjZcBsxmpYIFCcGYBJGOvyo;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public kPZMDTiHDvgpyxkGrNZecohpqdLj(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					ControllerHelper controllerHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerHelper.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						if (controllerHelper.QnbwIjuPrLBLMNgRAIdzHbXAearJA)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = controllerHelper.Mouse;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						goto IL_0070;
					case 2:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						goto IL_0094;
					case 3:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						EOszwgjZcBsxmpYIFCcGYBJGOvyo++;
						goto IL_00ec;
					case 4:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							EOszwgjZcBsxmpYIFCcGYBJGOvyo++;
							break;
						}
						IL_0094:
						ejTMCkenHDVEzckkUhSPQavYCCUj = controllerHelper.joystickCount;
						SGGHJqEAEAIDtxumeEsqaoovqTVI = controllerHelper.Joysticks;
						EOszwgjZcBsxmpYIFCcGYBJGOvyo = 0;
						goto IL_00ec;
						IL_00ec:
						if (EOszwgjZcBsxmpYIFCcGYBJGOvyo < ejTMCkenHDVEzckkUhSPQavYCCUj)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = SGGHJqEAEAIDtxumeEsqaoovqTVI[EOszwgjZcBsxmpYIFCcGYBJGOvyo];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 3;
							return true;
						}
						tPDcuwaNTwOiDyHAhngoFqTdUArpB = controllerHelper.customControllerCount;
						YubeOlIkhVEDJeEfldwIRJNDHBiCb = controllerHelper.CustomControllers;
						EOszwgjZcBsxmpYIFCcGYBJGOvyo = 0;
						break;
						IL_0070:
						if (controllerHelper.hqtaydwRTeyrOgkCiESPCFtXBOdjb)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = controllerHelper.Keyboard;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
							return true;
						}
						goto IL_0094;
					}
					if (EOszwgjZcBsxmpYIFCcGYBJGOvyo < tPDcuwaNTwOiDyHAhngoFqTdUArpB)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = YubeOlIkhVEDJeEfldwIRJNDHBiCb[EOszwgjZcBsxmpYIFCcGYBJGOvyo];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 4;
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
					kPZMDTiHDvgpyxkGrNZecohpqdLj kPZMDTiHDvgpyxkGrNZecohpqdLj2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						kPZMDTiHDvgpyxkGrNZecohpqdLj2 = this;
					}
					else
					{
						kPZMDTiHDvgpyxkGrNZecohpqdLj2 = new kPZMDTiHDvgpyxkGrNZecohpqdLj(0);
						kPZMDTiHDvgpyxkGrNZecohpqdLj2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return kPZMDTiHDvgpyxkGrNZecohpqdLj2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly jNBSQHQFEwfOYkOuniRstKTZlZDy wAwcNGKKdJvjwtGZQrWymqAtXJA;

			private bool QnbwIjuPrLBLMNgRAIdzHbXAearJA;

			private bool hqtaydwRTeyrOgkCiESPCFtXBOdjb;

			private bool OFsqJkdtKPhjsJcCZzZfglmFtyne;

			private double wMmWbhKcneDWxcHpfpDgTwfonwjaA;

			private double kSQzDJFOnNHpPQHeiKSEYCwRqjHt;

			private SafeAction<ControllerAssignmentChangedEventArgs> wVfcKmubgKHvaoktWEmCGackfifO = new SafeAction<ControllerAssignmentChangedEventArgs>(umUCOXZVBRiQuilGMEZNJsBnLHGeb._003C_003E9.qeGQuZRAkawSyrWrCRnOCJjaOgdB);

			private SafeAction<ControllerAssignmentChangedEventArgs> nNXgvpeTjqZtVSaPjVUTQNbLgLODb = new SafeAction<ControllerAssignmentChangedEventArgs>(umUCOXZVBRiQuilGMEZNJsBnLHGeb._003C_003E9.IIXlWdVmCCSwQgaQXouaqnacKIaY);

			private readonly mdyLmCgBkWJXboeOKOYPVOgtbend AXHLLNOarmUpwPzyUrjqTImAJvzZ;

			private readonly Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV;

			private readonly XPTCKTooCGCKcMxzkZtfjnOrnRvn WKPQYqlNclnKBgRtFDmKjqOuBDsSA;

			private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap> wTVjGBEHdWuQtbRoAMEnHdUSjVZg => (bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick);

			private BNyqYlWalrCfOzrCabaRaoJZBeLP<KeyboardMap> AVbKDPRWTeUtPIkeowuHdDONLIqU => (BNyqYlWalrCfOzrCabaRaoJZBeLP<KeyboardMap>)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Keyboard).jcQIPleqWWsZNlvEYGkHBahJWVvN(0).gYfvSSlCQdvlHXoFtXExDLDXhhRu;

			private BNyqYlWalrCfOzrCabaRaoJZBeLP<MouseMap> PJxfZnmoRYSScdILDjxiruFcEPGD => (BNyqYlWalrCfOzrCabaRaoJZBeLP<MouseMap>)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Mouse).jcQIPleqWWsZNlvEYGkHBahJWVvN(0).gYfvSSlCQdvlHXoFtXExDLDXhhRu;

			private bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap> RcZLNAxmXXbPoDnGQnTkuRUWCmiuA => (bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return QnbwIjuPrLBLMNgRAIdzHbXAearJA;
				}
				set
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						if (QnbwIjuPrLBLMNgRAIdzHbXAearJA == value)
						{
							return;
						}
						QnbwIjuPrLBLMNgRAIdzHbXAearJA = value;
						if (value)
						{
							WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(Mouse);
						}
						else
						{
							WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (wVfcKmubgKHvaoktWEmCGackfifO.Count > 0)
							{
								wVfcKmubgKHvaoktWEmCGackfifO.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Count > 0)
						{
							nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return hqtaydwRTeyrOgkCiESPCFtXBOdjb;
				}
				set
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						if (hqtaydwRTeyrOgkCiESPCFtXBOdjb == value)
						{
							return;
						}
						hqtaydwRTeyrOgkCiESPCFtXBOdjb = value;
						if (value)
						{
							WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(Keyboard);
						}
						else
						{
							WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (wVfcKmubgKHvaoktWEmCGackfifO.Count > 0)
							{
								wVfcKmubgKHvaoktWEmCGackfifO.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Count > 0)
						{
							nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return OFsqJkdtKPhjsJcCZzZfglmFtyne;
				}
				set
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						OFsqJkdtKPhjsJcCZzZfglmFtyne = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick).ZQqQltuirEhRybMOxWCRGTiKWPGW;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick) as bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>).obQHJhFYcXmdSoAwadTzguTKNZpjA;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom).ZQqQltuirEhRybMOxWCRGTiKWPGW;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom) as bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>).obQHJhFYcXmdSoAwadTzguTKNZpjA;
				}
			}

			public IEnumerable<Controller> Controllers => new kPZMDTiHDvgpyxkGrNZecohpqdLj(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					wVfcKmubgKHvaoktWEmCGackfifO.AddDelegate(value);
				}
				remove
				{
					wVfcKmubgKHvaoktWEmCGackfifO.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					nNXgvpeTjqZtVSaPjVUTQNbLgLODb.AddDelegate(value);
				}
				remove
				{
					nNXgvpeTjqZtVSaPjVUTQNbLgLODb.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, WWVuXrRYVOzShWUocNjzkxVTwGrG P_1, ControllerMapLayoutManager.QMsaCCjejTLLpcQRJGrdNeitKrRP P_2, ControllerMapEnabler.KiSiAESwVlRDyuCSgIKOzduAyJHX P_3)
			{
				oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
				tYEyiSjpdwwbqdDLYhlcYJwwGWGV = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				wAwcNGKKdJvjwtGZQrWymqAtXJA = new jNBSQHQFEwfOYkOuniRstKTZlZDy(4);
				wAwcNGKKdJvjwtGZQrWymqAtXJA.ftQlYzLUxILQoPXvwgamKMqUEnsiA(0, ControllerType.Joystick, new bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>());
				wAwcNGKKdJvjwtGZQrWymqAtXJA.ftQlYzLUxILQoPXvwgamKMqUEnsiA(1, ControllerType.Keyboard, new bWznjLeWeHSDvTNXqXHswVZMMsQb<Keyboard, KeyboardMap>());
				wAwcNGKKdJvjwtGZQrWymqAtXJA.ftQlYzLUxILQoPXvwgamKMqUEnsiA(2, ControllerType.Mouse, new bWznjLeWeHSDvTNXqXHswVZMMsQb<Mouse, MouseMap>());
				wAwcNGKKdJvjwtGZQrWymqAtXJA.ftQlYzLUxILQoPXvwgamKMqUEnsiA(3, ControllerType.Custom, new bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>());
				AXHLLNOarmUpwPzyUrjqTImAJvzZ = new mdyLmCgBkWJXboeOKOYPVOgtbend(P_0);
				WKPQYqlNclnKBgRtFDmKjqOuBDsSA = new XPTCKTooCGCKcMxzkZtfjnOrnRvn(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return (T)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(uAOMfTHsnTLbvEUpHTchXYOhMgjh.dCDiSNmXZWjCxMjhOfIfIHAULWGO<T>()).gAPABsuepoxQLaHJJhjKlywBeNAd(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType).gAPABsuepoxQLaHJJhjKlywBeNAd(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return (T)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(uAOMfTHsnTLbvEUpHTchXYOhMgjh.dCDiSNmXZWjCxMjhOfIfIHAULWGO<T>()).MfaqjmeWeRxfLpVEUprLRtESfATi(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(controllerType).MfaqjmeWeRxfLpVEUprLRtESfATi(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					OXDLUVEiAffTyVMkdFIAAbfqttALA(controllerId, removeFromOtherPlayers);
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
					UkDCStQxuTTzKRfUCpNqHNkmXkEG(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						OXDLUVEiAffTyVMkdFIAAbfqttALA(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						UkDCStQxuTTzKRfUCpNqHNkmXkEG(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					OXDLUVEiAffTyVMkdFIAAbfqttALA(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
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
					UkDCStQxuTTzKRfUCpNqHNkmXkEG(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					acqHFXgWWsCzAizcMtRVoFtwGOcb(controllerId);
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
					YpPprTyCjXINuDdRSIPPjCHwrQiRA(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					acqHFXgWWsCzAizcMtRVoFtwGOcb(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					YpPprTyCjXINuDdRSIPPjCHwrQiRA(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						acqHFXgWWsCzAizcMtRVoFtwGOcb(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						YpPprTyCjXINuDdRSIPPjCHwrQiRA(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return hqtaydwRTeyrOgkCiESPCFtXBOdjb;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return QnbwIjuPrLBLMNgRAIdzHbXAearJA;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick).XrqcBMeuSMEFFHtBARTfiYGSMlVMB(controllerId);
				case ControllerType.Keyboard:
					return hqtaydwRTeyrOgkCiESPCFtXBOdjb;
				case ControllerType.Mouse:
					return QnbwIjuPrLBLMNgRAIdzHbXAearJA;
				case ControllerType.Custom:
					return wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom).XrqcBMeuSMEFFHtBARTfiYGSMlVMB(controllerId);
				default:
					throw new NotImplementedException();
				}
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					QtkhdZpXTnGoaEifPlVSqkDyjYDQ();
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
					dQpnDdiCwxApayhaIbzCEsMqzeFq();
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					QtkhdZpXTnGoaEifPlVSqkDyjYDQ();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					dQpnDdiCwxApayhaIbzCEsMqzeFq();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				QtkhdZpXTnGoaEifPlVSqkDyjYDQ();
				dQpnDdiCwxApayhaIbzCEsMqzeFq();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				RnDIChpjYduxcNHDwaIlcoKaeDnr(ControllerType.Joystick, ref result, ref num);
				if (QnbwIjuPrLBLMNgRAIdzHbXAearJA && wMmWbhKcneDWxcHpfpDgTwfonwjaA > num)
				{
					result = Mouse;
					num = wMmWbhKcneDWxcHpfpDgTwfonwjaA;
				}
				if (hqtaydwRTeyrOgkCiESPCFtXBOdjb && kSQzDJFOnNHpPQHeiKSEYCwRqjHt > num)
				{
					result = Keyboard;
					num = kSQzDJFOnNHpPQHeiKSEYCwRqjHt;
				}
				RnDIChpjYduxcNHDwaIlcoKaeDnr(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					RnDIChpjYduxcNHDwaIlcoKaeDnr(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (hqtaydwRTeyrOgkCiESPCFtXBOdjb && kSQzDJFOnNHpPQHeiKSEYCwRqjHt > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (QnbwIjuPrLBLMNgRAIdzHbXAearJA && wMmWbhKcneDWxcHpfpDgTwfonwjaA > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void RnDIChpjYduxcNHDwaIlcoKaeDnr(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
				int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
				for (int i = 0; i < num; i++)
				{
					double num2 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).VwJrKGtqkVWatknkuEeZyTsQsrAc;
					if (!(num2 <= P_2))
					{
						P_1 = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).yBVYaZymnHfILCjQopwadWNgxbeH;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(uAOMfTHsnTLbvEUpHTchXYOhMgjh.dCDiSNmXZWjCxMjhOfIfIHAULWGO<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.BvWzsmEDKXHJdamXSxHkvlEaBMPC(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.BvWzsmEDKXHJdamXSxHkvlEaBMPC(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.HdlHQrgKTRKuUNntUzSxdjLVFDaK(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.HdlHQrgKTRKuUNntUzSxdjLVFDaK(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.uVdGGwwgzyMStSFKWTNiNKHqwfHD(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				int zQqQltuirEhRybMOxWCRGTiKWPGW = wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
				for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
				{
					Controller controller = qaslmpfGilCtKfXZpBDYCcZFFjODA(wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i).JZuBcglRGrLdTTkjRHBAWiKZgoVK, Controller.WcqwKmwpCxmvXgoRwtTsSsgNfarO, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				int zQqQltuirEhRybMOxWCRGTiKWPGW = wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW;
				for (int i = 0; i < zQqQltuirEhRybMOxWCRGTiKWPGW; i++)
				{
					Controller controller = qaslmpfGilCtKfXZpBDYCcZFFjODA(wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i).JZuBcglRGrLdTTkjRHBAWiKZgoVK, Controller.mOJFQgdpynnJgyTCLVelnuyaORMv, templateType);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return WKPQYqlNclnKBgRtFDmKjqOuBDsSA.EThRTrEQTiAbwrmxuQKaeHxocOdfA<TInterface>();
			}

			private Controller qaslmpfGilCtKfXZpBDYCcZFFjODA<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
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
					if (hqtaydwRTeyrOgkCiESPCFtXBOdjb && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (QnbwIjuPrLBLMNgRAIdzHbXAearJA && P_1(Mouse, P_2))
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

			internal void TlzckGoQDITHcUYaslQXPQBOhTwq()
			{
				for (int i = 0; i < wAwcNGKKdJvjwtGZQrWymqAtXJA.ZQqQltuirEhRybMOxWCRGTiKWPGW; i++)
				{
					wAwcNGKKdJvjwtGZQrWymqAtXJA.UaPXSbLpVTkKprByyepiorcSlOWH(i).wJjPIIRJfHhEbGedUconecGfiwzgB();
				}
				wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Keyboard).tYMyBEevSVHNsMkZbTQKkymAqAxR(new bWznjLeWeHSDvTNXqXHswVZMMsQb<Keyboard, KeyboardMap>.gUNePuOAXTTEQajyoClOIDiOHUoU(ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.ksIrgmIMxbskrWvzAPRFSsoyIedU, new BNyqYlWalrCfOzrCabaRaoJZBeLP<KeyboardMap>(0)));
				wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Mouse).tYMyBEevSVHNsMkZbTQKkymAqAxR(new bWznjLeWeHSDvTNXqXHswVZMMsQb<Mouse, MouseMap>.gUNePuOAXTTEQajyoClOIDiOHUoU(ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.PFBHIEavSNmCtRpAbjOJnbVrdybGA, new BNyqYlWalrCfOzrCabaRaoJZBeLP<MouseMap>(0)));
				AXHLLNOarmUpwPzyUrjqTImAJvzZ.wJjPIIRJfHhEbGedUconecGfiwzgB();
				kSQzDJFOnNHpPQHeiKSEYCwRqjHt = 0.0;
				wMmWbhKcneDWxcHpfpDgTwfonwjaA = 0.0;
				maps.TlzckGoQDITHcUYaslQXPQBOhTwq();
			}

			internal double GZEcbVtzbDdmPovWgthqUjFayzlm(int P_0)
			{
				return AXHLLNOarmUpwPzyUrjqTImAJvzZ.VLYfOpamoUspknlbDaegsxFBZShK(P_0)?.oxZBwgdegRLKVSbsFSMljJNBHkup ?? (-1.0);
			}

			internal void OXDLUVEiAffTyVMkdFIAAbfqttALA(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick);
				if (nUMJXuTXYTQLuvshdhtoVCFirCzU2.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				mdyLmCgBkWJXboeOKOYPVOgtbend.ELbCLVCdwSPLHPUkhCTLNYpoZUSp eLbCLVCdwSPLHPUkhCTLNYpoZUSp = AXHLLNOarmUpwPzyUrjqTImAJvzZ.VLYfOpamoUspknlbDaegsxFBZShK(P_0.id);
				bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU gUNePuOAXTTEQajyoClOIDiOHUoU;
				if (eLbCLVCdwSPLHPUkhCTLNYpoZUSp != null && eLbCLVCdwSPLHPUkhCTLNYpoZUSp.gYfvSSlCQdvlHXoFtXExDLDXhhRu != null)
				{
					gUNePuOAXTTEQajyoClOIDiOHUoU = new bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU(P_0, eLbCLVCdwSPLHPUkhCTLNYpoZUSp.gYfvSSlCQdvlHXoFtXExDLDXhhRu);
				}
				else
				{
					BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap> bNyqYlWalrCfOzrCabaRaoJZBeLP = maps.XGGiHvDuRxfWZcjkoFymEYUloNDv(P_0, true);
					if (bNyqYlWalrCfOzrCabaRaoJZBeLP == null)
					{
						bNyqYlWalrCfOzrCabaRaoJZBeLP = new BNyqYlWalrCfOzrCabaRaoJZBeLP<JoystickMap>(P_0.id);
					}
					gUNePuOAXTTEQajyoClOIDiOHUoU = new bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU(P_0, bNyqYlWalrCfOzrCabaRaoJZBeLP);
				}
				nUMJXuTXYTQLuvshdhtoVCFirCzU2.tYMyBEevSVHNsMkZbTQKkymAqAxR(gUNePuOAXTTEQajyoClOIDiOHUoU);
				AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(gUNePuOAXTTEQajyoClOIDiOHUoU);
				WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(P_0);
				maps.layoutManager.Apply();
				if (wVfcKmubgKHvaoktWEmCGackfifO.Count > 0)
				{
					wVfcKmubgKHvaoktWEmCGackfifO.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void OXDLUVEiAffTyVMkdFIAAbfqttALA(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					OXDLUVEiAffTyVMkdFIAAbfqttALA(joystick, P_1);
				}
			}

			internal void acqHFXgWWsCzAizcMtRVoFtwGOcb(int P_0)
			{
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick);
				if (nUMJXuTXYTQLuvshdhtoVCFirCzU2.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0))
				{
					if (nUMJXuTXYTQLuvshdhtoVCFirCzU2.jcQIPleqWWsZNlvEYGkHBahJWVvN(P_0) is bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU gUNePuOAXTTEQajyoClOIDiOHUoU)
					{
						AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(gUNePuOAXTTEQajyoClOIDiOHUoU);
					}
					nUMJXuTXYTQLuvshdhtoVCFirCzU2.IxFqxZIAiVbfdZQpsgscCLjEykOMA(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(joystick);
					if (nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Count > 0)
					{
						nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void acqHFXgWWsCzAizcMtRVoFtwGOcb(Joystick P_0)
			{
				if (P_0 != null)
				{
					acqHFXgWWsCzAizcMtRVoFtwGOcb(P_0.id);
				}
			}

			internal void QtkhdZpXTnGoaEifPlVSqkDyjYDQ()
			{
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Joystick);
				for (int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW - 1; num >= 0; num--)
				{
					AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num) as bWznjLeWeHSDvTNXqXHswVZMMsQb<Joystick, JoystickMap>.gUNePuOAXTTEQajyoClOIDiOHUoU);
					WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH);
					int id = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH.id;
					nUMJXuTXYTQLuvshdhtoVCFirCzU2.fryvpKcsKNOTszIpycKowSnDVcct(num);
					if (nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Count > 0)
					{
						nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, id, ControllerType.Joystick, false));
					}
				}
				nUMJXuTXYTQLuvshdhtoVCFirCzU2.wJjPIIRJfHhEbGedUconecGfiwzgB();
			}

			internal void UkDCStQxuTTzKRfUCpNqHNkmXkEG(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom);
				if (!nUMJXuTXYTQLuvshdhtoVCFirCzU2.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					BNyqYlWalrCfOzrCabaRaoJZBeLP<CustomControllerMap> bNyqYlWalrCfOzrCabaRaoJZBeLP = maps.MhLuxsxiHHVMkUswMfgZhzvXLujH(P_0, true);
					if (bNyqYlWalrCfOzrCabaRaoJZBeLP == null)
					{
						bNyqYlWalrCfOzrCabaRaoJZBeLP = new BNyqYlWalrCfOzrCabaRaoJZBeLP<CustomControllerMap>(P_0.id);
					}
					bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>.gUNePuOAXTTEQajyoClOIDiOHUoU gUNePuOAXTTEQajyoClOIDiOHUoU = new bWznjLeWeHSDvTNXqXHswVZMMsQb<CustomController, CustomControllerMap>.gUNePuOAXTTEQajyoClOIDiOHUoU(P_0, bNyqYlWalrCfOzrCabaRaoJZBeLP);
					nUMJXuTXYTQLuvshdhtoVCFirCzU2.tYMyBEevSVHNsMkZbTQKkymAqAxR(gUNePuOAXTTEQajyoClOIDiOHUoU);
					WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(P_0);
					maps.layoutManager.Apply();
					if (wVfcKmubgKHvaoktWEmCGackfifO.Count > 0)
					{
						wVfcKmubgKHvaoktWEmCGackfifO.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void UkDCStQxuTTzKRfUCpNqHNkmXkEG(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					UkDCStQxuTTzKRfUCpNqHNkmXkEG(customController, P_1);
				}
			}

			internal void YpPprTyCjXINuDdRSIPPjCHwrQiRA(int P_0)
			{
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom);
				if (nUMJXuTXYTQLuvshdhtoVCFirCzU2.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0))
				{
					nUMJXuTXYTQLuvshdhtoVCFirCzU2.jcQIPleqWWsZNlvEYGkHBahJWVvN(P_0);
					nUMJXuTXYTQLuvshdhtoVCFirCzU2.IxFqxZIAiVbfdZQpsgscCLjEykOMA(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(customController);
					if (nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Count > 0)
					{
						nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void YpPprTyCjXINuDdRSIPPjCHwrQiRA(CustomController P_0)
			{
				if (P_0 != null)
				{
					YpPprTyCjXINuDdRSIPPjCHwrQiRA(P_0.id);
				}
			}

			internal void dQpnDdiCwxApayhaIbzCEsMqzeFq()
			{
				nUMJXuTXYTQLuvshdhtoVCFirCzU nUMJXuTXYTQLuvshdhtoVCFirCzU2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Custom);
				for (int num = nUMJXuTXYTQLuvshdhtoVCFirCzU2.ZQqQltuirEhRybMOxWCRGTiKWPGW - 1; num >= 0; num--)
				{
					WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH);
					int id = nUMJXuTXYTQLuvshdhtoVCFirCzU2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(num).yBVYaZymnHfILCjQopwadWNgxbeH.id;
					nUMJXuTXYTQLuvshdhtoVCFirCzU2.fryvpKcsKNOTszIpycKowSnDVcct(num);
					if (nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Count > 0)
					{
						nNXgvpeTjqZtVSaPjVUTQNbLgLODb.Invoke(new ControllerAssignmentChangedEventArgs(tYEyiSjpdwwbqdDLYhlcYJwwGWGV.id, id, ControllerType.Custom, false));
					}
				}
				nUMJXuTXYTQLuvshdhtoVCFirCzU2.wJjPIIRJfHhEbGedUconecGfiwzgB();
			}

			internal CustomController REFjFzjqVfBzOqUbhgBnBtJFDRDQb(int P_0)
			{
				CustomController customController = tYEyiSjpdwwbqdDLYhlcYJwwGWGV.TqCbnAKmmZEXypoBWqhkYUuqNUrC.REFjFzjqVfBzOqUbhgBnBtJFDRDQb(P_0);
				if (customController == null)
				{
					return null;
				}
				UkDCStQxuTTzKRfUCpNqHNkmXkEG(customController, false);
				return customController;
			}

			internal void wBRIUXiElXioypFpFtqzzuddeLqv(Action<bool, int, int> P_0)
			{
				dshXPziXzRREUpvTEefCkRItElnm<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void HumsPpwGPmDwPqsPrVFAUXEKJiYK(Keyboard P_0, qhdGsmuaRZPOXBEZmmGhxzHSRVAx P_1, Action<bool, int, int> P_2)
			{
				if (!hqtaydwRTeyrOgkCiESPCFtXBOdjb || !P_0.enabled)
				{
					return;
				}
				LsWsboySkoBfynWzdTgJAlBRhZOh hpqeHlhNkXEtXIIYwFbZmpIBKEpz = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.hpqeHlhNkXEtXIIYwFbZmpIBKEpz;
				bool flag = false;
				zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Keyboard).jcQIPleqWWsZNlvEYGkHBahJWVvN(0).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
				int num = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				qhdGsmuaRZPOXBEZmmGhxzHSRVAx.HLpggwfgeYKXOQPBzlqCYYEdkQtCA hLpggwfgeYKXOQPBzlqCYYEdkQtCA = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? qhdGsmuaRZPOXBEZmmGhxzHSRVAx.HLpggwfgeYKXOQPBzlqCYYEdkQtCA.OverlapModifiers : qhdGsmuaRZPOXBEZmmGhxzHSRVAx.HLpggwfgeYKXOQPBzlqCYYEdkQtCA.Normal);
				WYNKNWIFczeVHUyRjGlNScqXANMC.KtsEclDDNAMtzXpypcdeiyHyEFolA ktsEclDDNAMtzXpypcdeiyHyEFolA = new WYNKNWIFczeVHUyRjGlNScqXANMC.KtsEclDDNAMtzXpypcdeiyHyEFolA
				{
					GXybZxkxlIHHsGOkUaQgyHDMDCGc = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.UetWStxkTEpvtiiHkgsRzKetHbwDA;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
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
							buttonStateFlags = (P_0.JgbGnLHDygzucaRiXhLugJqAHZZv(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag5)
							{
								WYNKNWIFczeVHUyRjGlNScqXANMC wYNKNWIFczeVHUyRjGlNScqXANMC = WYNKNWIFczeVHUyRjGlNScqXANMC.VjGNvPXHUExSrGcFIxHRneMhGBUk(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn);
								if (wYNKNWIFczeVHUyRjGlNScqXANMC != null && wYNKNWIFczeVHUyRjGlNScqXANMC.xlyWqlnToOPAbVjNGAzzNUGWChIEA(true) != ButtonStateFlags.Off)
								{
									flag5 = true;
								}
							}
						}
						else
						{
							buttonStateFlags = P_0.dQXLgNytWHwEWvOMAjCewCOwnIlD(actionElementMap.nAznauVeWTEKclGKxeRUvILhqOtm);
							flag5 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag5)
						{
							if (!flag2)
							{
								flag3 = P_1.MFWbxwoqZEdCvebVzqqrorySkkUT(keyboardKeyCode, modifierKeyFlags, hLpggwfgeYKXOQPBzlqCYYEdkQtCA, out flag4);
							}
							if (flag4 || modifierKeyFlags != ModifierKeyFlags.None)
							{
								ktsEclDDNAMtzXpypcdeiyHyEFolA.JeAenAwJIaCwIKhPcmfPuNhocdJM = flag3;
								WYNKNWIFczeVHUyRjGlNScqXANMC wYNKNWIFczeVHUyRjGlNScqXANMC = WYNKNWIFczeVHUyRjGlNScqXANMC.ARtThZfcYFFcPpcOdDABFOcvJqddb(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, ktsEclDDNAMtzXpypcdeiyHyEFolA);
								if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
								{
									wYNKNWIFczeVHUyRjGlNScqXANMC.OeQLYUPDDBkdHhbaaYeQwJgkelpZ = flag3;
								}
								else if (flag3)
								{
									wYNKNWIFczeVHUyRjGlNScqXANMC.OeQLYUPDDBkdHhbaaYeQwJgkelpZ = true;
								}
								wYNKNWIFczeVHUyRjGlNScqXANMC.fytesVmSgMdEYCdUSfupqQQYLxEPA(ReInput.currentUpdateLoop, buttonStateFlags, true);
								buttonStateFlags = wYNKNWIFczeVHUyRjGlNScqXANMC.xlyWqlnToOPAbVjNGAzzNUGWChIEA(true);
							}
						}
						if (buttonStateFlags != ButtonStateFlags.Off)
						{
							SHUfSowDcrJJPsmGSdekUTHMonYq(P_0, keyboardMap, actionElementMap, hpqeHlhNkXEtXIIYwFbZmpIBKEpz, buttonStateFlags);
							P_2(arg1: true, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId);
							flag = true;
							continue;
						}
						if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ANnyYrpgRHgHrBXsbJxMFrsUzupD != 0f)
						{
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ANnyYrpgRHgHrBXsbJxMFrsUzupD = 0f;
						}
						if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yosdEGXbKTmXvLCTuoObSZLwiwch != ButtonStateFlags.Off)
						{
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yosdEGXbKTmXvLCTuoObSZLwiwch = ButtonStateFlags.Off;
						}
						P_2(arg1: false, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId);
					}
				}
				if (flag)
				{
					kSQzDJFOnNHpPQHeiKSEYCwRqjHt = ReInput.unscaledTime;
				}
			}

			private static void SHUfSowDcrJJPsmGSdekUTHMonYq(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, LsWsboySkoBfynWzdTgJAlBRhZOh P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.ANnyYrpgRHgHrBXsbJxMFrsUzupD = num;
				P_3.yosdEGXbKTmXvLCTuoObSZLwiwch = P_4;
				P_3.yBVYaZymnHfILCjQopwadWNgxbeH = P_0;
				P_3.JZuBcglRGrLdTTkjRHBAWiKZgoVK = ControllerType.Keyboard;
				P_3.ugEcvEUjcYzrLriOHSDCiapaTNEm = ControllerElementType.Button;
				P_3.iTDfhpbZQXABExodAcvVPhaugdAhA = P_2;
				P_3.WLiuUldTXEcuIGVhKWPVeISBtYjL = P_1;
				if (P_3.dQPDPGDORKiCYcKZFTVFTzltYieY)
				{
					P_3.dQPDPGDORKiCYcKZFTVFTzltYieY = false;
				}
				if (P_3.WRDZmnmqsvkiMGETQLckvVbiNyMd)
				{
					P_3.WRDZmnmqsvkiMGETQLckvVbiNyMd = false;
				}
			}

			internal void SXUBxgwfTURelJBIWZLOBaLGIqKC(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!QnbwIjuPrLBLMNgRAIdzHbXAearJA || !P_0.enabled)
				{
					return;
				}
				zWbUQgTovQtSYwaKIfEFDBCoWmolA zWbUQgTovQtSYwaKIfEFDBCoWmolA2 = wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(ControllerType.Mouse).jcQIPleqWWsZNlvEYGkHBahJWVvN(0).gYfvSSlCQdvlHXoFtXExDLDXhhRu;
				LsWsboySkoBfynWzdTgJAlBRhZOh hpqeHlhNkXEtXIIYwFbZmpIBKEpz = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.hpqeHlhNkXEtXIIYwFbZmpIBKEpz;
				bool flag = false;
				int num = zWbUQgTovQtSYwaKIfEFDBCoWmolA2.ZQqQltuirEhRybMOxWCRGTiKWPGW;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)zWbUQgTovQtSYwaKIfEFDBCoWmolA2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.rStYJnklHSdEdVGPAEyZExxfflXh;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.AagpSncLUJqzNNHIlFoNYYQgJOuo(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.AagpSncLUJqzNNHIlFoNYYQgJOuo(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId);
									continue;
								}
							}
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ANnyYrpgRHgHrBXsbJxMFrsUzupD = num2;
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yBVYaZymnHfILCjQopwadWNgxbeH = P_0;
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.JZuBcglRGrLdTTkjRHBAWiKZgoVK = ControllerType.Mouse;
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ugEcvEUjcYzrLriOHSDCiapaTNEm = ControllerElementType.Axis;
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iTDfhpbZQXABExodAcvVPhaugdAhA = actionElementMap;
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WLiuUldTXEcuIGVhKWPVeISBtYjL = mouseMap;
							if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd)
							{
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd = false;
							}
							if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iQLmvDvgdhYGdVFoALHMLSpWIJxU != AxisCoordinateMode.Relative)
							{
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iQLmvDvgdhYGdVFoALHMLSpWIJxU = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.UetWStxkTEpvtiiHkgsRzKetHbwDA;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.cPwDhWDVSywpgVGgnkreoRvfHonz(actionElementMap2, actionId2, out var aNnyYrpgRHgHrBXsbJxMFrsUzupD, out hpqeHlhNkXEtXIIYwFbZmpIBKEpz.dQPDPGDORKiCYcKZFTVFTzltYieY))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.dQXLgNytWHwEWvOMAjCewCOwnIlD(actionElementMap2.nAznauVeWTEKclGKxeRUvILhqOtm);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId2);
							continue;
						}
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ANnyYrpgRHgHrBXsbJxMFrsUzupD = aNnyYrpgRHgHrBXsbJxMFrsUzupD;
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yosdEGXbKTmXvLCTuoObSZLwiwch = buttonStateFlags;
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yBVYaZymnHfILCjQopwadWNgxbeH = P_0;
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.JZuBcglRGrLdTTkjRHBAWiKZgoVK = ControllerType.Mouse;
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ugEcvEUjcYzrLriOHSDCiapaTNEm = ControllerElementType.Button;
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iTDfhpbZQXABExodAcvVPhaugdAhA = actionElementMap2;
						hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WLiuUldTXEcuIGVhKWPVeISBtYjL = mouseMap;
						if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.dQPDPGDORKiCYcKZFTVFTzltYieY)
						{
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.dQPDPGDORKiCYcKZFTVFTzltYieY = false;
						}
						if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd)
						{
							hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd = false;
						}
						P_1(arg1: true, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					wMmWbhKcneDWxcHpfpDgTwfonwjaA = ReInput.unscaledTime;
				}
			}

			internal void caETbsyyCqXguvCilhhJafEbFVkb(Action<bool, int, int> P_0)
			{
				dshXPziXzRREUpvTEefCkRItElnm<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void dshXPziXzRREUpvTEefCkRItElnm<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				bWznjLeWeHSDvTNXqXHswVZMMsQb<_0001, _0002> bWznjLeWeHSDvTNXqXHswVZMMsQb2 = (bWznjLeWeHSDvTNXqXHswVZMMsQb<_0001, _0002>)wAwcNGKKdJvjwtGZQrWymqAtXJA.KKhSmWsVzgiELAFInwiOcPHOuLyK(P_0);
				LsWsboySkoBfynWzdTgJAlBRhZOh hpqeHlhNkXEtXIIYwFbZmpIBKEpz = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.hpqeHlhNkXEtXIIYwFbZmpIBKEpz;
				int num = bWznjLeWeHSDvTNXqXHswVZMMsQb2.DLziBsJZuZhaylJgkqoiHaUPORcx();
				for (int i = 0; i < num; i++)
				{
					bWznjLeWeHSDvTNXqXHswVZMMsQb<_0001, _0002>.gUNePuOAXTTEQajyoClOIDiOHUoU gUNePuOAXTTEQajyoClOIDiOHUoU = bWznjLeWeHSDvTNXqXHswVZMMsQb2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i);
					_0001 yBVYaZymnHfILCjQopwadWNgxbeH = gUNePuOAXTTEQajyoClOIDiOHUoU.yBVYaZymnHfILCjQopwadWNgxbeH;
					if (!yBVYaZymnHfILCjQopwadWNgxbeH.enabled)
					{
						continue;
					}
					BNyqYlWalrCfOzrCabaRaoJZBeLP<_0002> gYfvSSlCQdvlHXoFtXExDLDXhhRu = gUNePuOAXTTEQajyoClOIDiOHUoU.gYfvSSlCQdvlHXoFtXExDLDXhhRu;
					bool flag = false;
					int num2 = gYfvSSlCQdvlHXoFtXExDLDXhhRu.DLziBsJZuZhaylJgkqoiHaUPORcx();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = gYfvSSlCQdvlHXoFtXExDLDXhhRu.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.rStYJnklHSdEdVGPAEyZExxfflXh;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!yBVYaZymnHfILCjQopwadWNgxbeH.AagpSncLUJqzNNHIlFoNYYQgJOuo(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									yBVYaZymnHfILCjQopwadWNgxbeH.AagpSncLUJqzNNHIlFoNYYQgJOuo(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId);
										continue;
									}
								}
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ANnyYrpgRHgHrBXsbJxMFrsUzupD = num3;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yBVYaZymnHfILCjQopwadWNgxbeH = yBVYaZymnHfILCjQopwadWNgxbeH;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.JZuBcglRGrLdTTkjRHBAWiKZgoVK = P_0;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ugEcvEUjcYzrLriOHSDCiapaTNEm = ControllerElementType.Axis;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iTDfhpbZQXABExodAcvVPhaugdAhA = actionElementMap;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WLiuUldTXEcuIGVhKWPVeISBtYjL = val;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd = yBVYaZymnHfILCjQopwadWNgxbeH.calibrationMap.Axes[actionElementMap.nAznauVeWTEKclGKxeRUvILhqOtm].applyRangeCalibration;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iQLmvDvgdhYGdVFoALHMLSpWIJxU = yBVYaZymnHfILCjQopwadWNgxbeH.Axes[actionElementMap.elementIndex].wzuKsMAQzNUDQMPTfMKsvinBDhokA?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.UetWStxkTEpvtiiHkgsRzKetHbwDA;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float aNnyYrpgRHgHrBXsbJxMFrsUzupD = 0f;
								int nAznauVeWTEKclGKxeRUvILhqOtm = actionElementMap2.nAznauVeWTEKclGKxeRUvILhqOtm;
								if (!ChxABCdJtpUNgxvOpkPlAIdEemqL(yBVYaZymnHfILCjQopwadWNgxbeH, i, nAznauVeWTEKclGKxeRUvILhqOtm, actionElementMap2, gYfvSSlCQdvlHXoFtXExDLDXhhRu, actionId2, ref aNnyYrpgRHgHrBXsbJxMFrsUzupD) && !yBVYaZymnHfILCjQopwadWNgxbeH.cPwDhWDVSywpgVGgnkreoRvfHonz(actionElementMap2, actionId2, out aNnyYrpgRHgHrBXsbJxMFrsUzupD, out hpqeHlhNkXEtXIIYwFbZmpIBKEpz.dQPDPGDORKiCYcKZFTVFTzltYieY))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = yBVYaZymnHfILCjQopwadWNgxbeH.dQXLgNytWHwEWvOMAjCewCOwnIlD(actionElementMap2.nAznauVeWTEKclGKxeRUvILhqOtm);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId2);
									continue;
								}
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ANnyYrpgRHgHrBXsbJxMFrsUzupD = aNnyYrpgRHgHrBXsbJxMFrsUzupD;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yosdEGXbKTmXvLCTuoObSZLwiwch = buttonStateFlags;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.yBVYaZymnHfILCjQopwadWNgxbeH = yBVYaZymnHfILCjQopwadWNgxbeH;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.JZuBcglRGrLdTTkjRHBAWiKZgoVK = P_0;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.ugEcvEUjcYzrLriOHSDCiapaTNEm = ControllerElementType.Button;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.iTDfhpbZQXABExodAcvVPhaugdAhA = actionElementMap2;
								hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WLiuUldTXEcuIGVhKWPVeISBtYjL = val;
								if (hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd)
								{
									hpqeHlhNkXEtXIIYwFbZmpIBKEpz.WRDZmnmqsvkiMGETQLckvVbiNyMd = false;
								}
								P_1(arg1: true, tYEyiSjpdwwbqdDLYhlcYJwwGWGV.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							gUNePuOAXTTEQajyoClOIDiOHUoU.IlUOIvCsKbaokuBeHIhLqfpLIMMQ();
						}
					}
				}
			}

			private bool ChxABCdJtpUNgxvOpkPlAIdEemqL<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.fcpRkkeLOqieJylVwWSUEEJhOXpJ.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.fcpRkkeLOqieJylVwWSUEEJhOXpJ.GetUnknownHatButtons(P_2);
				if (WiHLDdgNNZNuEHArvFCaKatmlTmj(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.cPwDhWDVSywpgVGgnkreoRvfHonz(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool WiHLDdgNNZNuEHArvFCaKatmlTmj<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (MHTFjHXnFEmICNamXbymxLWazBsr(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool MHTFjHXnFEmICNamXbymxLWazBsr<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, BNyqYlWalrCfOzrCabaRaoJZBeLP<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.DLziBsJZuZhaylJgkqoiHaUPORcx();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int nAznauVeWTEKclGKxeRUvILhqOtm = buttonMaps[j].nAznauVeWTEKclGKxeRUvILhqOtm;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(nAznauVeWTEKclGKxeRUvILhqOtm))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private const string mzVPpYpnwixRejNdGdywXfXJhtkv = "player";

		private readonly FNKIgOISFgsKyonqFvBnwwgKMXdU TqCbnAKmmZEXypoBWqhkYUuqNUrC;

		private bool hlsNFAeJapFhoHqtyrhIDamSdxLZ;

		private int kqvbpTxWGdGtrNRdxLepeZkwTJDn;

		private string XXuYUuZFvXwuYxiNryIOxzHdIWPU;

		private string oVEUjfQhRnvdedHVoLcBSPJzxjnu;

		private readonly string iznbkRlQcoGkZtBlmfunFSNsZtUK;

		private bool ELvglkBwoPAptkyImmeNDHbmiScpA;

		private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		private readonly ySFzLcEuqAOMOxTEGgUhEEdHrazE oGPaEasMppAsagimCGQlgSqfnxSs;

		private int rDnRVTAZXyaVlJOBjDydLOTjrRpD;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return kqvbpTxWGdGtrNRdxLepeZkwTJDn;
			}
			internal set
			{
				kqvbpTxWGdGtrNRdxLepeZkwTJDn = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				return XXuYUuZFvXwuYxiNryIOxzHdIWPU;
			}
			internal set
			{
				XXuYUuZFvXwuYxiNryIOxzHdIWPU = xXuYUuZFvXwuYxiNryIOxzHdIWPU;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return oVEUjfQhRnvdedHVoLcBSPJzxjnu;
				}
				return oGPaEasMppAsagimCGQlgSqfnxSs.jXwgbYbEpdqHGeBdCbXEcskUaWaFA;
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return ELvglkBwoPAptkyImmeNDHbmiScpA;
			}
			set
			{
				ELvglkBwoPAptkyImmeNDHbmiScpA = value;
			}
		}

		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return oVEUjfQhRnvdedHVoLcBSPJzxjnu;
			}
			set
			{
				oVEUjfQhRnvdedHVoLcBSPJzxjnu = value;
				oGPaEasMppAsagimCGQlgSqfnxSs.dsySnzlaDCdVTBdBHhqcOjWsSalGA();
			}
		}

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.keyCategory => "player";

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.scriptingName => XXuYUuZFvXwuYxiNryIOxzHdIWPU;

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.nonLocalizedDescriptiveName
		{
			get
			{
				return oVEUjfQhRnvdedHVoLcBSPJzxjnu;
			}
			set
			{
				oVEUjfQhRnvdedHVoLcBSPJzxjnu = value;
			}
		}

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.key => iznbkRlQcoGkZtBlmfunFSNsZtUK;

		int jtAeQMwqfCHdCmeHvhaRCqwDmBxb.autoGeneratedValueFlags
		{
			get
			{
				return rDnRVTAZXyaVlJOBjDydLOTjrRpD;
			}
			set
			{
				rDnRVTAZXyaVlJOBjDydLOTjrRpD = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, WWVuXrRYVOzShWUocNjzkxVTwGrG P_5, ControllerMapLayoutManager.QMsaCCjejTLLpcQRJGrdNeitKrRP P_6, ControllerMapEnabler.KiSiAESwVlRDyuCSgIKOzduAyJHX P_7)
		{
			hlsNFAeJapFhoHqtyrhIDamSdxLZ = P_0;
			kqvbpTxWGdGtrNRdxLepeZkwTJDn = P_1;
			XXuYUuZFvXwuYxiNryIOxzHdIWPU = P_2;
			oVEUjfQhRnvdedHVoLcBSPJzxjnu = P_3;
			iznbkRlQcoGkZtBlmfunFSNsZtUK = P_4;
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
			oGPaEasMppAsagimCGQlgSqfnxSs = ySFzLcEuqAOMOxTEGgUhEEdHrazE.VxSNvmooWfTkIVcICGUZnqoUJPDW(this);
			controllers = new ControllerHelper(this, P_5, P_6, P_7);
			TqCbnAKmmZEXypoBWqhkYUuqNUrC = ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb;
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(kqvbpTxWGdGtrNRdxLepeZkwTJDn));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.aBjKkYedffJMBNyjOkVFOWaUaAhq() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.aBjKkYedffJMBNyjOkVFOWaUaAhq() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.jYWxpmOgglOGuxLGHjZnFKAvkMEVA() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.jYWxpmOgglOGuxLGHjZnFKAvkMEVA() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.NSCNnosVEfppjSDmbInqdnhriOUCb() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.NSCNnosVEfppjSDmbInqdnhriOUCb() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.qveZUhnPEVcbIJyEhVLiIhpjriCfA() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.qveZUhnPEVcbIJyEhVLiIhpjriCfA() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.rHtSQnVSLBplJZRFObHrOFjzcoQK() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.rHtSQnVSLBplJZRFObHrOFjzcoQK() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.csDrdChbJQIOmksuuVxOxEagdqDu() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.csDrdChbJQIOmksuuVxOxEagdqDu() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.jVbQtlyEpufFHIoPlezNcnoiygzJA() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.jVbQtlyEpufFHIoPlezNcnoiygzJA() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.fGrfpCetbdrKqeHbFsuPvafPRESbB(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.fGrfpCetbdrKqeHbFsuPvafPRESbB(speed) ?? false;
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.RcXDvTiiILQzTCKEyfHSAYQmjxOV(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.RcXDvTiiILQzTCKEyfHSAYQmjxOV(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.GzDJQAgdenEgvphMsgEaElrcFvuTA(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.GzDJQAgdenEgvphMsgEaElrcFvuTA(speed) ?? false;
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.rYvZrqLIEfQSIYbjvmJRAFXiqciG(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.rYvZrqLIEfQSIYbjvmJRAFXiqciG(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.rYvZrqLIEfQSIYbjvmJRAFXiqciG(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.rYvZrqLIEfQSIYbjvmJRAFXiqciG(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.dQHQTENqnyfFFiAjapdkHkNZNRzb(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.dQHQTENqnyfFFiAjapdkHkNZNRzb(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.wKnbzcWwOaLrOzSBtGWFcSCeammv() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.wKnbzcWwOaLrOzSBtGWFcSCeammv() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.nvhKouvEJvdTwMHxRHsUnWQJpIqN() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.nvhKouvEJvdTwMHxRHsUnWQJpIqN() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.PdHcAEwphxEAeVbNuimEHvTzFeWgA() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.PdHcAEwphxEAeVbNuimEHvTzFeWgA() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.sLaxixlWJSqMBnbTfnalgnERAeXk() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.sLaxixlWJSqMBnbTfnalgnERAeXk() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.jYqabKZmwtoSQsSFjJmkhmYbPIFD() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.jYqabKZmwtoSQsSFjJmkhmYbPIFD() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.tAtdOjdZyxcBaKsDNFasfYtMXWcq() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.tAtdOjdZyxcBaKsDNFasfYtMXWcq() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.QmlGqIFOMvtlmEVTrTFoiHXNYGYBA() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.QmlGqIFOMvtlmEVTrTFoiHXNYGYBA() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.qUrTyDHTIgqTctTvrtbwBHLaBFwy(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.aEUyVOBuXYFDinYfgLbRvsUvMkLv(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.jtBwSKTmuecbdEtqRZNsystzKhTF(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.slkeuaEzXgYgYFQvyTdkJJsbNEViA(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.PbmZLevtftCnMKgsLjcibFAvEqNdA() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.PbmZLevtftCnMKgsLjcibFAvEqNdA() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.lQflqVBPjiOaAwdHezMflrsJAygFA() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.lQflqVBPjiOaAwdHezMflrsJAygFA() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.BUDvRzCDOdNgSDFFXUnYMQiVSgEo() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.BUDvRzCDOdNgSDFFXUnYMQiVSgEo() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.HelmxrCyZjEmODVCgMtGwDwOrjHf() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.HelmxrCyZjEmODVCgMtGwDwOrjHf() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.MwMEOSDIIFPGmIGayVPhiNpATkQH() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.MwMEOSDIIFPGmIGayVPhiNpATkQH() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.QjvTGGincqjqIbxSLkbGWDLjDQuqA() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.QjvTGGincqjqIbxSLkbGWDLjDQuqA() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.LcUGNRHrNzbefybEPWAFRskoKhOvA() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.LcUGNRHrNzbefybEPWAFRskoKhOvA() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.QFDHMOeOEOExSdgRtNyXnQixJsHoA() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.QFDHMOeOEOExSdgRtNyXnQixJsHoA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.iPoDluKIPcUUSfnvMOzWXPhECoWjA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.iPoDluKIPcUUSfnvMOzWXPhECoWjA() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.FzqOFPHPyvGIVUQrCGUhfYylwPxh(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.FzqOFPHPyvGIVUQrCGUhfYylwPxh(speed) ?? false;
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.DyBFksccVwqlIJdyxdRmDnwtBhAjb(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.DyBFksccVwqlIJdyxdRmDnwtBhAjb(speed) ?? false;
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.xPOfYcFAqcbGQXNpkmPkGuHehRgWB(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.xPOfYcFAqcbGQXNpkmPkGuHehRgWB(speed) ?? false;
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.ctxzUBojHfaMDKluBWpwDbvbWeTO(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.ctxzUBojHfaMDKluBWpwDbvbWeTO(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.ctxzUBojHfaMDKluBWpwDbvbWeTO(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.ctxzUBojHfaMDKluBWpwDbvbWeTO(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.TTdplYZkHbfsyVDzFsLCzAwVeYYD(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.TTdplYZkHbfsyVDzFsLCzAwVeYYD(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.IibrkGxpYUNpGLFuwWQMdmaEFqwi(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.IibrkGxpYUNpGLFuwWQMdmaEFqwi(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.IibrkGxpYUNpGLFuwWQMdmaEFqwi(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.IibrkGxpYUNpGLFuwWQMdmaEFqwi(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.UEfZNGvENjameDloZdGLWGDrNETA() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.UEfZNGvENjameDloZdGLWGDrNETA() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.rzYKbXTMvvIApGCKOLCHjMrDgBuf() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.rzYKbXTMvvIApGCKOLCHjMrDgBuf() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.avyVqEOPNYRRSMRmPrcRJvCUOLZ() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.avyVqEOPNYRRSMRmPrcRJvCUOLZ() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.pAoCECnEGXfuTmEPNDDQlTrTSAoL() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.pAoCECnEGXfuTmEPNDDQlTrTSAoL() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.epYInvbADrkzNKygaikcJwafHBur() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.epYInvbADrkzNKygaikcJwafHBur() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.aODPQqwcjhbzrAQcbMXYMkzoKxaq() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.aODPQqwcjhbzrAQcbMXYMkzoKxaq() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.COhDpfBOOMpezHoIGQMbFrKVmpCnb() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.COhDpfBOOMpezHoIGQMbFrKVmpCnb() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.IhqYotTsPxnlgOhvBpnLINHiBeop(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.OZpskBRqCuiruaOykOqXAFdESsYOb(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.jNcBwoAokpEjcPAoSMPLskMeYEOVA(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.pGsCXnCUqHHyHZECiHeOhbZepYShA(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.eUmWvRTEecgodbzDAHEtwMggHcmhA() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.eUmWvRTEecgodbzDAHEtwMggHcmhA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.mrZLVQNpOVrhrEGEJhmYbVTHCtdM() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.mrZLVQNpOVrhrEGEJhmYbVTHCtdM() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.mtDFbsoRVlrEoxEmreAlGujQTODw() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.mtDFbsoRVlrEoxEmreAlGujQTODw() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.NwhhRAfbaWNuJFqlJkXCStnDAvJS() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.NwhhRAfbaWNuJFqlJkXCStnDAvJS() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.hUkWLcyhKkGyVnBbrhNUuNsSzzfB() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.hUkWLcyhKkGyVnBbrhNUuNsSzzfB() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.rgjeHltckJwFXBOdZKIcLKeaujPV() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.rgjeHltckJwFXBOdZKIcLKeaujPV() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.YjodcvLLiiMIiuQlBtRHFinVIpAV() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.YjodcvLLiiMIiuQlBtRHFinVIpAV() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.NwhhRAfbaWNuJFqlJkXCStnDAvJS();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.NwhhRAfbaWNuJFqlJkXCStnDAvJS();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.NwhhRAfbaWNuJFqlJkXCStnDAvJS();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.NwhhRAfbaWNuJFqlJkXCStnDAvJS();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.mtDFbsoRVlrEoxEmreAlGujQTODw();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.mtDFbsoRVlrEoxEmreAlGujQTODw();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.mtDFbsoRVlrEoxEmreAlGujQTODw();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.mtDFbsoRVlrEoxEmreAlGujQTODw();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.hUkWLcyhKkGyVnBbrhNUuNsSzzfB();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionName, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.hUkWLcyhKkGyVnBbrhNUuNsSzzfB();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, xAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.x = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.hUkWLcyhKkGyVnBbrhNUuNsSzzfB();
			}
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, yAxisActionId, true);
			if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 != null)
			{
				result.y = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.hUkWLcyhKkGyVnBbrhNUuNsSzzfB();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.kgnNbvqDxiCoChuiiZNsNfKwboQwA() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.kgnNbvqDxiCoChuiiZNsNfKwboQwA() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.gyVTKVxNShoWkvjtCqbzlgWNhlRc() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.gyVTKVxNShoWkvjtCqbzlgWNhlRc() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.fWZqwFFoFkbvFvemEQwUNXEsDKsj() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.fWZqwFFoFkbvFvemEQwUNXEsDKsj() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.hGppqWNmmuXeHfzECKOsTbXcooQe() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.hGppqWNmmuXeHfzECKOsTbXcooQe() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.fNFIsnXuHuRWXglfvwbqJEcpiNtm() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.fNFIsnXuHuRWXglfvwbqJEcpiNtm() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.GafpUbHFjWFAhtVWTQgYuLoNBGNCA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.GafpUbHFjWFAhtVWTQgYuLoNBGNCA() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.RsTSttdtpigyBMEEySbvksLKRMqf() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.RsTSttdtpigyBMEEySbvksLKRMqf() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.lXzwAqBGGBAWYnLZRuZOEsdjmqSn() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return AxisCoordinateMode.Absolute;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.lXzwAqBGGBAWYnLZRuZOEsdjmqSn() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.LZhBfaIDDDONHnFPFohPDwSgLKoK();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.LZhBfaIDDDONHnFPFohPDwSgLKoK();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionName, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return TqCbnAKmmZEXypoBWqhkYUuqNUrC.spuIPZtVjMmDKIpmbCpwlvidgLqV(kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionId, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.FRKOkrggsFUysyoSQRSawmtATWQH(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.FRKOkrggsFUysyoSQRSawmtATWQH(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.FRKOkrggsFUysyoSQRSawmtATWQH(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.FRKOkrggsFUysyoSQRSawmtATWQH(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.QGnlTvJhyLAlRpEjXeLnweJnwVst(kqvbpTxWGdGtrNRdxLepeZkwTJDn, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					TqCbnAKmmZEXypoBWqhkYUuqNUrC.RTipuxHoXnMqsfhIfxhgSsynkdqH(kqvbpTxWGdGtrNRdxLepeZkwTJDn);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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

		internal void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
		{
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}

		private void TlzckGoQDITHcUYaslQXPQBOhTwq()
		{
			controllers.TlzckGoQDITHcUYaslQXPQBOhTwq();
			ELvglkBwoPAptkyImmeNDHbmiScpA = false;
		}
	}
}
