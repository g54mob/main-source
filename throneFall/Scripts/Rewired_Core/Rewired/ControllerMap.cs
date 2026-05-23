using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class oHDrqEFIhwdAGWigBvyrUzyUEmcG : IComparer<ActionElementMap>
		{
			public static oHDrqEFIhwdAGWigBvyrUzyUEmcG doBRlqHtybXefvzaJnNJcKklBGpl;

			public static oHDrqEFIhwdAGWigBvyrUzyUEmcG qageGEQhgHGEGhrzfRUEYNYoRKBl => doBRlqHtybXefvzaJnNJcKklBGpl ?? (doBRlqHtybXefvzaJnNJcKklBGpl = new oHDrqEFIhwdAGWigBvyrUzyUEmcG());

			public int Compare(ActionElementMap x, ActionElementMap y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				if (x._elementType == y._elementType)
				{
					return x.id.CompareTo(y.id);
				}
				if (x._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				} <= y._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				})
				{
					return -1;
				}
				return 1;
			}

			int IComparer<ActionElementMap>.Compare(ActionElementMap x, ActionElementMap y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Compare
				return this.Compare(x, y);
			}
		}

		private sealed class PMwKDtbDhxrYZIMQJpItKEGItByB : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int iYodkTIHaLyBbDdtNfPeSQLRselB;

			private ActionElementMap UBxUdAAkNCgGHFtYJgOSGGImuipbA;

			private int JVZZJFrkYBLqGhsMSnPLeCsOZvwF;

			public ControllerMap GgyowEnnSvljAVbfTMmeoFVSArpc;

			private int ojAHnEEvimFDKsfcqrpdrtPGxSrT;

			public int ZxjvlPwDitrwOYoAiQUEqLHrrOLc;

			private bool JTCkmZVRNdRUcbBKiiVlGzOrkvKNA;

			public bool JswDtPQSBuUkIkSDEaJqHpcyZfCh;

			private IList<ActionElementMap> vdleCaqBySFURhUNamuSyJECevFSA;

			private int sOhuyqKcljtAusIuDUOkOwUAfizX;

			private int bDXjyAWhJugfGaDLqzATMxPHSarWA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return UBxUdAAkNCgGHFtYJgOSGGImuipbA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UBxUdAAkNCgGHFtYJgOSGGImuipbA;
				}
			}

			[DebuggerHidden]
			public PMwKDtbDhxrYZIMQJpItKEGItByB(int P_0)
			{
				iYodkTIHaLyBbDdtNfPeSQLRselB = P_0;
				JVZZJFrkYBLqGhsMSnPLeCsOZvwF = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = iYodkTIHaLyBbDdtNfPeSQLRselB;
				ControllerMap ggyowEnnSvljAVbfTMmeoFVSArpc = GgyowEnnSvljAVbfTMmeoFVSArpc;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					iYodkTIHaLyBbDdtNfPeSQLRselB = -1;
					goto IL_00af;
				}
				iYodkTIHaLyBbDdtNfPeSQLRselB = -1;
				if (ReInput._id != ggyowEnnSvljAVbfTMmeoFVSArpc.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ggyowEnnSvljAVbfTMmeoFVSArpc.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return false;
				}
				if (ojAHnEEvimFDKsfcqrpdrtPGxSrT < 0)
				{
					return false;
				}
				vdleCaqBySFURhUNamuSyJECevFSA = ggyowEnnSvljAVbfTMmeoFVSArpc.ButtonMaps;
				sOhuyqKcljtAusIuDUOkOwUAfizX = ggyowEnnSvljAVbfTMmeoFVSArpc.buttonMapCount;
				bDXjyAWhJugfGaDLqzATMxPHSarWA = 0;
				goto IL_00bf;
				IL_00bf:
				if (bDXjyAWhJugfGaDLqzATMxPHSarWA < sOhuyqKcljtAusIuDUOkOwUAfizX)
				{
					ActionElementMap actionElementMap = vdleCaqBySFURhUNamuSyJECevFSA[bDXjyAWhJugfGaDLqzATMxPHSarWA];
					if (actionElementMap._actionId == ojAHnEEvimFDKsfcqrpdrtPGxSrT && (!JTCkmZVRNdRUcbBKiiVlGzOrkvKNA || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
					{
						UBxUdAAkNCgGHFtYJgOSGGImuipbA = actionElementMap;
						iYodkTIHaLyBbDdtNfPeSQLRselB = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				bDXjyAWhJugfGaDLqzATMxPHSarWA++;
				goto IL_00bf;
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				PMwKDtbDhxrYZIMQJpItKEGItByB pMwKDtbDhxrYZIMQJpItKEGItByB;
				if (iYodkTIHaLyBbDdtNfPeSQLRselB == -2 && JVZZJFrkYBLqGhsMSnPLeCsOZvwF == Environment.CurrentManagedThreadId)
				{
					iYodkTIHaLyBbDdtNfPeSQLRselB = 0;
					pMwKDtbDhxrYZIMQJpItKEGItByB = this;
				}
				else
				{
					pMwKDtbDhxrYZIMQJpItKEGItByB = new PMwKDtbDhxrYZIMQJpItKEGItByB(0);
					pMwKDtbDhxrYZIMQJpItKEGItByB.GgyowEnnSvljAVbfTMmeoFVSArpc = GgyowEnnSvljAVbfTMmeoFVSArpc;
				}
				pMwKDtbDhxrYZIMQJpItKEGItByB.ojAHnEEvimFDKsfcqrpdrtPGxSrT = ZxjvlPwDitrwOYoAiQUEqLHrrOLc;
				pMwKDtbDhxrYZIMQJpItKEGItByB.JTCkmZVRNdRUcbBKiiVlGzOrkvKNA = JswDtPQSBuUkIkSDEaJqHpcyZfCh;
				return pMwKDtbDhxrYZIMQJpItKEGItByB;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class aOYMIQmXGgRQXcEUsudzRrehIImU : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int VecLRuFRcZwqPJNYfTUiKfBuBMJf;

			private ElementAssignmentConflictInfo JmQmOHRyfXsynbqUjsigvEbmafEkA;

			private int ZedzpYPmmxwsTmDtFPQQbFwaAnwjA;

			public ControllerMap LfmCWriORJGpzyBRzeZMOaEGzRwh;

			private ControllerMap wobmeMAKlbWCkUHaSuVRnbcWdVUFA;

			public ControllerMap QSrgOIKrWibktfRhgmvbJAGWIoah;

			private bool ITpUDgxJbbRUtCgZFDxDdysOyUIE;

			public bool ZlPVwpBzlxNWOKDtxIhKCTEkXANE;

			private IList<ActionElementMap> IzqyusYMcNptmhndiZSxBdzVeLsK;

			private int xwiJbaHgKQDWLCQYHGnFjFkSrFpYA;

			private int BkttZzKkelCQggkpsgbfiCVwlOYxA;

			private ActionElementMap XvgtwmMJViMfwGhZOwFIkBYSMhIB;

			private int WRupjXwcWOCrUEggBCeOpyvaDNtFA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JmQmOHRyfXsynbqUjsigvEbmafEkA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JmQmOHRyfXsynbqUjsigvEbmafEkA;
				}
			}

			[DebuggerHidden]
			public aOYMIQmXGgRQXcEUsudzRrehIImU(int P_0)
			{
				VecLRuFRcZwqPJNYfTUiKfBuBMJf = P_0;
				ZedzpYPmmxwsTmDtFPQQbFwaAnwjA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int vecLRuFRcZwqPJNYfTUiKfBuBMJf = VecLRuFRcZwqPJNYfTUiKfBuBMJf;
				ControllerMap lfmCWriORJGpzyBRzeZMOaEGzRwh = LfmCWriORJGpzyBRzeZMOaEGzRwh;
				if (vecLRuFRcZwqPJNYfTUiKfBuBMJf != 0)
				{
					if (vecLRuFRcZwqPJNYfTUiKfBuBMJf != 1)
					{
						return false;
					}
					VecLRuFRcZwqPJNYfTUiKfBuBMJf = -1;
					goto IL_019c;
				}
				VecLRuFRcZwqPJNYfTUiKfBuBMJf = -1;
				if (ReInput._id != lfmCWriORJGpzyBRzeZMOaEGzRwh.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(lfmCWriORJGpzyBRzeZMOaEGzRwh.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return false;
				}
				if (wobmeMAKlbWCkUHaSuVRnbcWdVUFA == null || lfmCWriORJGpzyBRzeZMOaEGzRwh.rvqcoXOdpRAOewtDLUZbifwVfBME == null)
				{
					return false;
				}
				if (ITpUDgxJbbRUtCgZFDxDdysOyUIE && (!lfmCWriORJGpzyBRzeZMOaEGzRwh._enabled || !wobmeMAKlbWCkUHaSuVRnbcWdVUFA._enabled))
				{
					return false;
				}
				IzqyusYMcNptmhndiZSxBdzVeLsK = wobmeMAKlbWCkUHaSuVRnbcWdVUFA.ButtonMaps;
				if (IzqyusYMcNptmhndiZSxBdzVeLsK == null)
				{
					return false;
				}
				xwiJbaHgKQDWLCQYHGnFjFkSrFpYA = IzqyusYMcNptmhndiZSxBdzVeLsK.Count;
				BkttZzKkelCQggkpsgbfiCVwlOYxA = 0;
				goto IL_01d4;
				IL_01d4:
				if (BkttZzKkelCQggkpsgbfiCVwlOYxA < lfmCWriORJGpzyBRzeZMOaEGzRwh.rvqcoXOdpRAOewtDLUZbifwVfBME.Count)
				{
					XvgtwmMJViMfwGhZOwFIkBYSMhIB = lfmCWriORJGpzyBRzeZMOaEGzRwh.rvqcoXOdpRAOewtDLUZbifwVfBME[BkttZzKkelCQggkpsgbfiCVwlOYxA];
					if (!ITpUDgxJbbRUtCgZFDxDdysOyUIE || XvgtwmMJViMfwGhZOwFIkBYSMhIB.IdtDkaTUBQdYslzoHMBnxOLemrRM)
					{
						WRupjXwcWOCrUEggBCeOpyvaDNtFA = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (WRupjXwcWOCrUEggBCeOpyvaDNtFA < xwiJbaHgKQDWLCQYHGnFjFkSrFpYA)
				{
					ActionElementMap actionElementMap = IzqyusYMcNptmhndiZSxBdzVeLsK[WRupjXwcWOCrUEggBCeOpyvaDNtFA];
					if ((!ITpUDgxJbbRUtCgZFDxDdysOyUIE || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && XvgtwmMJViMfwGhZOwFIkBYSMhIB.CheckForAssignmentConflict(actionElementMap))
					{
						JmQmOHRyfXsynbqUjsigvEbmafEkA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(lfmCWriORJGpzyBRzeZMOaEGzRwh._categoryId).userAssignable, -1, lfmCWriORJGpzyBRzeZMOaEGzRwh._controllerType, lfmCWriORJGpzyBRzeZMOaEGzRwh._controllerId, lfmCWriORJGpzyBRzeZMOaEGzRwh._id, XvgtwmMJViMfwGhZOwFIkBYSMhIB.JtzYMpqdJGMyIjXIPHXXckWafklL, XvgtwmMJViMfwGhZOwFIkBYSMhIB._actionId, XvgtwmMJViMfwGhZOwFIkBYSMhIB._elementType, XvgtwmMJViMfwGhZOwFIkBYSMhIB._elementIdentifierId, XvgtwmMJViMfwGhZOwFIkBYSMhIB.keyCode, XvgtwmMJViMfwGhZOwFIkBYSMhIB.modifierKeyFlags);
						VecLRuFRcZwqPJNYfTUiKfBuBMJf = 1;
						return true;
					}
					goto IL_019c;
				}
				XvgtwmMJViMfwGhZOwFIkBYSMhIB = null;
				goto IL_01c4;
				IL_01c4:
				BkttZzKkelCQggkpsgbfiCVwlOYxA++;
				goto IL_01d4;
				IL_019c:
				WRupjXwcWOCrUEggBCeOpyvaDNtFA++;
				goto IL_01ac;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				aOYMIQmXGgRQXcEUsudzRrehIImU aOYMIQmXGgRQXcEUsudzRrehIImU2;
				if (VecLRuFRcZwqPJNYfTUiKfBuBMJf == -2 && ZedzpYPmmxwsTmDtFPQQbFwaAnwjA == Environment.CurrentManagedThreadId)
				{
					VecLRuFRcZwqPJNYfTUiKfBuBMJf = 0;
					aOYMIQmXGgRQXcEUsudzRrehIImU2 = this;
				}
				else
				{
					aOYMIQmXGgRQXcEUsudzRrehIImU2 = new aOYMIQmXGgRQXcEUsudzRrehIImU(0);
					aOYMIQmXGgRQXcEUsudzRrehIImU2.LfmCWriORJGpzyBRzeZMOaEGzRwh = LfmCWriORJGpzyBRzeZMOaEGzRwh;
				}
				aOYMIQmXGgRQXcEUsudzRrehIImU2.wobmeMAKlbWCkUHaSuVRnbcWdVUFA = QSrgOIKrWibktfRhgmvbJAGWIoah;
				aOYMIQmXGgRQXcEUsudzRrehIImU2.ITpUDgxJbbRUtCgZFDxDdysOyUIE = ZlPVwpBzlxNWOKDtxIhKCTEkXANE;
				return aOYMIQmXGgRQXcEUsudzRrehIImU2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class wCQmPbbzanfANDoPhotJzXaxHqKl : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int UvQFQERkskwQITyYOCHLKmsRZROC;

			private ElementAssignmentConflictInfo rcjTKrbTLUeUyYdQocgxivOIBMVU;

			private int lScNmmLgBLMrCFwEOAujFXnBaMmI;

			public ControllerMap XHTVroWSYozhHICqJCdWakYtDbGI;

			private ActionElementMap STCYgOVQsfMCVulXIyxzCyRONQKm;

			public ActionElementMap MUAYHosvVdZYYJSZdRlTNnmZBMx;

			private bool ZXrGNhrRIqDFAMoIUEPKYiMSpAbF;

			public bool JYUsTVMYhvcTcZCYMOTbBlZZzIgD;

			private int jKpgXsxNPnhldmqYLDzmwVrddRlp;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return rcjTKrbTLUeUyYdQocgxivOIBMVU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return rcjTKrbTLUeUyYdQocgxivOIBMVU;
				}
			}

			[DebuggerHidden]
			public wCQmPbbzanfANDoPhotJzXaxHqKl(int P_0)
			{
				UvQFQERkskwQITyYOCHLKmsRZROC = P_0;
				lScNmmLgBLMrCFwEOAujFXnBaMmI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int uvQFQERkskwQITyYOCHLKmsRZROC = UvQFQERkskwQITyYOCHLKmsRZROC;
				ControllerMap xHTVroWSYozhHICqJCdWakYtDbGI = XHTVroWSYozhHICqJCdWakYtDbGI;
				if (uvQFQERkskwQITyYOCHLKmsRZROC != 0)
				{
					if (uvQFQERkskwQITyYOCHLKmsRZROC != 1)
					{
						return false;
					}
					UvQFQERkskwQITyYOCHLKmsRZROC = -1;
					goto IL_0111;
				}
				UvQFQERkskwQITyYOCHLKmsRZROC = -1;
				if (ReInput._id != xHTVroWSYozhHICqJCdWakYtDbGI.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(xHTVroWSYozhHICqJCdWakYtDbGI.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return false;
				}
				if (STCYgOVQsfMCVulXIyxzCyRONQKm == null || xHTVroWSYozhHICqJCdWakYtDbGI.rvqcoXOdpRAOewtDLUZbifwVfBME == null)
				{
					return false;
				}
				if (ZXrGNhrRIqDFAMoIUEPKYiMSpAbF && (!xHTVroWSYozhHICqJCdWakYtDbGI._enabled || !STCYgOVQsfMCVulXIyxzCyRONQKm.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					return false;
				}
				jKpgXsxNPnhldmqYLDzmwVrddRlp = 0;
				goto IL_0121;
				IL_0111:
				jKpgXsxNPnhldmqYLDzmwVrddRlp++;
				goto IL_0121;
				IL_0121:
				if (jKpgXsxNPnhldmqYLDzmwVrddRlp < xHTVroWSYozhHICqJCdWakYtDbGI.rvqcoXOdpRAOewtDLUZbifwVfBME.Count)
				{
					ActionElementMap actionElementMap = xHTVroWSYozhHICqJCdWakYtDbGI.rvqcoXOdpRAOewtDLUZbifwVfBME[jKpgXsxNPnhldmqYLDzmwVrddRlp];
					if ((!ZXrGNhrRIqDFAMoIUEPKYiMSpAbF || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(STCYgOVQsfMCVulXIyxzCyRONQKm))
					{
						rcjTKrbTLUeUyYdQocgxivOIBMVU = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(xHTVroWSYozhHICqJCdWakYtDbGI._categoryId).userAssignable, -1, xHTVroWSYozhHICqJCdWakYtDbGI._controllerType, xHTVroWSYozhHICqJCdWakYtDbGI._controllerId, xHTVroWSYozhHICqJCdWakYtDbGI._id, actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						UvQFQERkskwQITyYOCHLKmsRZROC = 1;
						return true;
					}
					goto IL_0111;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				wCQmPbbzanfANDoPhotJzXaxHqKl wCQmPbbzanfANDoPhotJzXaxHqKl2;
				if (UvQFQERkskwQITyYOCHLKmsRZROC == -2 && lScNmmLgBLMrCFwEOAujFXnBaMmI == Environment.CurrentManagedThreadId)
				{
					UvQFQERkskwQITyYOCHLKmsRZROC = 0;
					wCQmPbbzanfANDoPhotJzXaxHqKl2 = this;
				}
				else
				{
					wCQmPbbzanfANDoPhotJzXaxHqKl2 = new wCQmPbbzanfANDoPhotJzXaxHqKl(0);
					wCQmPbbzanfANDoPhotJzXaxHqKl2.XHTVroWSYozhHICqJCdWakYtDbGI = XHTVroWSYozhHICqJCdWakYtDbGI;
				}
				wCQmPbbzanfANDoPhotJzXaxHqKl2.STCYgOVQsfMCVulXIyxzCyRONQKm = MUAYHosvVdZYYJSZdRlTNnmZBMx;
				wCQmPbbzanfANDoPhotJzXaxHqKl2.ZXrGNhrRIqDFAMoIUEPKYiMSpAbF = JYUsTVMYhvcTcZCYMOTbBlZZzIgD;
				return wCQmPbbzanfANDoPhotJzXaxHqKl2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class ekUNebxKAelngPjGUHfTKWIKRDuJA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int oUECjLnsUxADWpGGYIsbGrgTmRIdA;

			private ElementAssignmentConflictInfo CSgwwzOzKquvvBRTKsmujTNnGGnh;

			private int ZDvEGVflPwYTfRbQEFPXfDrimhik;

			public ControllerMap ixfyOgavAZUFARXChwKzNcpihXpu;

			private bool fYQWsAxufpoDmReyWmANaFKAIIci;

			public bool TFiRECDNYNgIIgsftOgGrFqBGWBe;

			private ElementAssignmentConflictCheck iltKqpzhFKUKjpsDNWAZzaMYezBl;

			public ElementAssignmentConflictCheck cMqSSCIDxmLJFGlVfYpnreQCAVtz;

			private ElementAssignment lKhwcNvskakfVBYGdEHXFhHIRZCS;

			private int MdsdWAEePeYwhZiCdgYPVnpVZNbk;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return CSgwwzOzKquvvBRTKsmujTNnGGnh;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return CSgwwzOzKquvvBRTKsmujTNnGGnh;
				}
			}

			[DebuggerHidden]
			public ekUNebxKAelngPjGUHfTKWIKRDuJA(int P_0)
			{
				oUECjLnsUxADWpGGYIsbGrgTmRIdA = P_0;
				ZDvEGVflPwYTfRbQEFPXfDrimhik = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = oUECjLnsUxADWpGGYIsbGrgTmRIdA;
				ControllerMap controllerMap = ixfyOgavAZUFARXChwKzNcpihXpu;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					oUECjLnsUxADWpGGYIsbGrgTmRIdA = -1;
					goto IL_0123;
				}
				oUECjLnsUxADWpGGYIsbGrgTmRIdA = -1;
				if (ReInput._id != controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return false;
				}
				if (fYQWsAxufpoDmReyWmANaFKAIIci && !controllerMap._enabled)
				{
					return false;
				}
				if (controllerMap.rvqcoXOdpRAOewtDLUZbifwVfBME == null)
				{
					return false;
				}
				lKhwcNvskakfVBYGdEHXFhHIRZCS = iltKqpzhFKUKjpsDNWAZzaMYezBl.ToElementAssignment();
				MdsdWAEePeYwhZiCdgYPVnpVZNbk = 0;
				goto IL_0133;
				IL_0133:
				if (MdsdWAEePeYwhZiCdgYPVnpVZNbk < controllerMap.rvqcoXOdpRAOewtDLUZbifwVfBME.Count)
				{
					ActionElementMap actionElementMap = controllerMap.rvqcoXOdpRAOewtDLUZbifwVfBME[MdsdWAEePeYwhZiCdgYPVnpVZNbk];
					if ((!fYQWsAxufpoDmReyWmANaFKAIIci || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != iltKqpzhFKUKjpsDNWAZzaMYezBl.elementMapId && actionElementMap.CheckForAssignmentConflict(lKhwcNvskakfVBYGdEHXFhHIRZCS))
					{
						CSgwwzOzKquvvBRTKsmujTNnGGnh = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						oUECjLnsUxADWpGGYIsbGrgTmRIdA = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				MdsdWAEePeYwhZiCdgYPVnpVZNbk++;
				goto IL_0133;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				ekUNebxKAelngPjGUHfTKWIKRDuJA ekUNebxKAelngPjGUHfTKWIKRDuJA2;
				if (oUECjLnsUxADWpGGYIsbGrgTmRIdA == -2 && ZDvEGVflPwYTfRbQEFPXfDrimhik == Environment.CurrentManagedThreadId)
				{
					oUECjLnsUxADWpGGYIsbGrgTmRIdA = 0;
					ekUNebxKAelngPjGUHfTKWIKRDuJA2 = this;
				}
				else
				{
					ekUNebxKAelngPjGUHfTKWIKRDuJA2 = new ekUNebxKAelngPjGUHfTKWIKRDuJA(0);
					ekUNebxKAelngPjGUHfTKWIKRDuJA2.ixfyOgavAZUFARXChwKzNcpihXpu = ixfyOgavAZUFARXChwKzNcpihXpu;
				}
				ekUNebxKAelngPjGUHfTKWIKRDuJA2.iltKqpzhFKUKjpsDNWAZzaMYezBl = cMqSSCIDxmLJFGlVfYpnreQCAVtz;
				ekUNebxKAelngPjGUHfTKWIKRDuJA2.fYQWsAxufpoDmReyWmANaFKAIIci = TFiRECDNYNgIIgsftOgGrFqBGWBe;
				return ekUNebxKAelngPjGUHfTKWIKRDuJA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class MaVAVBfItPtYqSSoxSLdqoWAiBmY : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int tuNZsuDDOmFvSjHXLcBFAdxGBImZ;

			private ActionElementMap nOWFtbHScxSXvCpaDMAfeYmfKcHAC;

			private int qAYhhHiCRKbjTCtsRnadGZuByxbMA;

			public ControllerMap gYhejKVtQwKhGBYiCFSBhqoiFLNf;

			private int YSPuFoNiTnhtfMmGycSlDqiaUgxR;

			public int mHFCXeglsIgQQyCZCdpcsMRSFNtEb;

			private bool RJDHCKxaMIsPyFmzftLjSUfhNeLg;

			public bool KjpSwdJdRnxMQYaHTjZDIGRLyxAd;

			private IEnumerator<ActionElementMap> xCvYJBkOnNeSsfqCoJoFenhMrOXbb;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return nOWFtbHScxSXvCpaDMAfeYmfKcHAC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nOWFtbHScxSXvCpaDMAfeYmfKcHAC;
				}
			}

			[DebuggerHidden]
			public MaVAVBfItPtYqSSoxSLdqoWAiBmY(int P_0)
			{
				tuNZsuDDOmFvSjHXLcBFAdxGBImZ = P_0;
				qAYhhHiCRKbjTCtsRnadGZuByxbMA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = tuNZsuDDOmFvSjHXLcBFAdxGBImZ;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						IgPQnIDyKfYPEadoHbvRibFgKDWA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = tuNZsuDDOmFvSjHXLcBFAdxGBImZ;
					ControllerMap controllerMap = gYhejKVtQwKhGBYiCFSBhqoiFLNf;
					switch (num)
					{
					default:
						return false;
					case 0:
						tuNZsuDDOmFvSjHXLcBFAdxGBImZ = -1;
						if (ReInput._id != controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						xCvYJBkOnNeSsfqCoJoFenhMrOXbb = controllerMap.AllMaps.GetEnumerator();
						tuNZsuDDOmFvSjHXLcBFAdxGBImZ = -3;
						break;
					case 1:
						tuNZsuDDOmFvSjHXLcBFAdxGBImZ = -3;
						break;
					}
					while (xCvYJBkOnNeSsfqCoJoFenhMrOXbb.MoveNext())
					{
						ActionElementMap current = xCvYJBkOnNeSsfqCoJoFenhMrOXbb.Current;
						if (current._actionId == YSPuFoNiTnhtfMmGycSlDqiaUgxR && (!RJDHCKxaMIsPyFmzftLjSUfhNeLg || current.IdtDkaTUBQdYslzoHMBnxOLemrRM))
						{
							nOWFtbHScxSXvCpaDMAfeYmfKcHAC = current;
							tuNZsuDDOmFvSjHXLcBFAdxGBImZ = 1;
							return true;
						}
					}
					IgPQnIDyKfYPEadoHbvRibFgKDWA();
					xCvYJBkOnNeSsfqCoJoFenhMrOXbb = null;
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

			private void IgPQnIDyKfYPEadoHbvRibFgKDWA()
			{
				tuNZsuDDOmFvSjHXLcBFAdxGBImZ = -1;
				if (xCvYJBkOnNeSsfqCoJoFenhMrOXbb != null)
				{
					xCvYJBkOnNeSsfqCoJoFenhMrOXbb.Dispose();
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
				MaVAVBfItPtYqSSoxSLdqoWAiBmY maVAVBfItPtYqSSoxSLdqoWAiBmY;
				if (tuNZsuDDOmFvSjHXLcBFAdxGBImZ == -2 && qAYhhHiCRKbjTCtsRnadGZuByxbMA == Environment.CurrentManagedThreadId)
				{
					tuNZsuDDOmFvSjHXLcBFAdxGBImZ = 0;
					maVAVBfItPtYqSSoxSLdqoWAiBmY = this;
				}
				else
				{
					maVAVBfItPtYqSSoxSLdqoWAiBmY = new MaVAVBfItPtYqSSoxSLdqoWAiBmY(0);
					maVAVBfItPtYqSSoxSLdqoWAiBmY.gYhejKVtQwKhGBYiCFSBhqoiFLNf = gYhejKVtQwKhGBYiCFSBhqoiFLNf;
				}
				maVAVBfItPtYqSSoxSLdqoWAiBmY.YSPuFoNiTnhtfMmGycSlDqiaUgxR = mHFCXeglsIgQQyCZCdpcsMRSFNtEb;
				maVAVBfItPtYqSSoxSLdqoWAiBmY.RJDHCKxaMIsPyFmzftLjSUfhNeLg = KjpSwdJdRnxMQYaHTjZDIGRLyxAd;
				return maVAVBfItPtYqSSoxSLdqoWAiBmY;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class HADaYpCTJJVfdOIbTgdUzaOlgYJCb : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int FRgRRFpeAKPlhwkDiwhRszNwmqno;

			private ActionElementMap JsMfTcpRWuKnOdZzGliWKELJVyMp;

			private int JgOSmcvbCyHsVZOopUEjmukgKSDA;

			public ControllerMap tyMYIJaXzYjwRtQzohuBzlpQjEQj;

			private IControllerElementTarget OCVrIqfFzyxAyTlMLOqTlKyRghZC;

			public IControllerElementTarget oRDGNXHBVZEHDcYkugsYJlrcMMjN;

			private bool EWTsFkpUngkZBYisnPOLmGluHsdN;

			public bool OLiRAlitQUiQkRxRKpzstJPsmWtj;

			private TempListPool.TList<ActionElementMap> YGwXHqdeTKkAoSKJQkMSPKaPuSm;

			private List<ActionElementMap>.Enumerator qFRSlPtkcPCfAMaUUcJPuMxFgdnbA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return JsMfTcpRWuKnOdZzGliWKELJVyMp;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JsMfTcpRWuKnOdZzGliWKELJVyMp;
				}
			}

			[DebuggerHidden]
			public HADaYpCTJJVfdOIbTgdUzaOlgYJCb(int P_0)
			{
				FRgRRFpeAKPlhwkDiwhRszNwmqno = P_0;
				JgOSmcvbCyHsVZOopUEjmukgKSDA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int fRgRRFpeAKPlhwkDiwhRszNwmqno = FRgRRFpeAKPlhwkDiwhRszNwmqno;
				if ((uint)(fRgRRFpeAKPlhwkDiwhRszNwmqno - -4) > 1u && fRgRRFpeAKPlhwkDiwhRszNwmqno != 1)
				{
					return;
				}
				try
				{
					if (fRgRRFpeAKPlhwkDiwhRszNwmqno != -4 && fRgRRFpeAKPlhwkDiwhRszNwmqno != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						oyQBQKKwuHohWdUKfFJXabkaExNcb();
					}
				}
				finally
				{
					FWMAxgvZfKIPAOzZGtXkeYXDmXVs();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int fRgRRFpeAKPlhwkDiwhRszNwmqno = FRgRRFpeAKPlhwkDiwhRszNwmqno;
					ControllerMap controllerMap = tyMYIJaXzYjwRtQzohuBzlpQjEQj;
					switch (fRgRRFpeAKPlhwkDiwhRszNwmqno)
					{
					default:
						return false;
					case 0:
					{
						FRgRRFpeAKPlhwkDiwhRszNwmqno = -1;
						if (ReInput._id != controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						YGwXHqdeTKkAoSKJQkMSPKaPuSm = TempListPool.GetTList<ActionElementMap>();
						FRgRRFpeAKPlhwkDiwhRszNwmqno = -3;
						List<ActionElementMap> list = YGwXHqdeTKkAoSKJQkMSPKaPuSm.list;
						controllerMap.UlFArbKTYQdEqAtLPNCFxsiTzHnb(OCVrIqfFzyxAyTlMLOqTlKyRghZC, false, -1, EWTsFkpUngkZBYisnPOLmGluHsdN, list, false, out var _);
						qFRSlPtkcPCfAMaUUcJPuMxFgdnbA = list.GetEnumerator();
						FRgRRFpeAKPlhwkDiwhRszNwmqno = -4;
						break;
					}
					case 1:
						FRgRRFpeAKPlhwkDiwhRszNwmqno = -4;
						break;
					}
					if (qFRSlPtkcPCfAMaUUcJPuMxFgdnbA.MoveNext())
					{
						ActionElementMap current = qFRSlPtkcPCfAMaUUcJPuMxFgdnbA.Current;
						JsMfTcpRWuKnOdZzGliWKELJVyMp = current;
						FRgRRFpeAKPlhwkDiwhRszNwmqno = 1;
						return true;
					}
					oyQBQKKwuHohWdUKfFJXabkaExNcb();
					qFRSlPtkcPCfAMaUUcJPuMxFgdnbA = default(List<ActionElementMap>.Enumerator);
					FWMAxgvZfKIPAOzZGtXkeYXDmXVs();
					YGwXHqdeTKkAoSKJQkMSPKaPuSm = null;
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

			private void FWMAxgvZfKIPAOzZGtXkeYXDmXVs()
			{
				FRgRRFpeAKPlhwkDiwhRszNwmqno = -1;
				if (YGwXHqdeTKkAoSKJQkMSPKaPuSm != null)
				{
					((IDisposable)YGwXHqdeTKkAoSKJQkMSPKaPuSm).Dispose();
				}
			}

			private void oyQBQKKwuHohWdUKfFJXabkaExNcb()
			{
				FRgRRFpeAKPlhwkDiwhRszNwmqno = -3;
				((IDisposable)qFRSlPtkcPCfAMaUUcJPuMxFgdnbA/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				HADaYpCTJJVfdOIbTgdUzaOlgYJCb hADaYpCTJJVfdOIbTgdUzaOlgYJCb;
				if (FRgRRFpeAKPlhwkDiwhRszNwmqno == -2 && JgOSmcvbCyHsVZOopUEjmukgKSDA == Environment.CurrentManagedThreadId)
				{
					FRgRRFpeAKPlhwkDiwhRszNwmqno = 0;
					hADaYpCTJJVfdOIbTgdUzaOlgYJCb = this;
				}
				else
				{
					hADaYpCTJJVfdOIbTgdUzaOlgYJCb = new HADaYpCTJJVfdOIbTgdUzaOlgYJCb(0);
					hADaYpCTJJVfdOIbTgdUzaOlgYJCb.tyMYIJaXzYjwRtQzohuBzlpQjEQj = tyMYIJaXzYjwRtQzohuBzlpQjEQj;
				}
				hADaYpCTJJVfdOIbTgdUzaOlgYJCb.OCVrIqfFzyxAyTlMLOqTlKyRghZC = oRDGNXHBVZEHDcYkugsYJlrcMMjN;
				hADaYpCTJJVfdOIbTgdUzaOlgYJCb.EWTsFkpUngkZBYisnPOLmGluHsdN = OLiRAlitQUiQkRxRKpzstJPsmWtj;
				return hADaYpCTJJVfdOIbTgdUzaOlgYJCb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class vSfejiFRLGBBIfcIwXrAQUmZWrZL : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int VlEbIMHyFsnntkeVdonoKbmGtVuY;

			private ActionElementMap HDBUbdkmlKPRvJFygkQhNslFcuhg;

			private int MWgCDwiUVUIvjKjKsFkPpdPTJbiaA;

			public ControllerMap nweFcsAOhOKwEmAFiZiStiYYLmbIA;

			private IControllerElementTarget oPGVTuvHWFkMfodMEWlMDWjgszlU;

			public IControllerElementTarget rDPhkBlUtyzaiRMmduKHubdAhvcGA;

			private int LjpPoCYdmJGAYNwCyAHAGWqrufFJA;

			public int qZQnBjkVlPCXXRxUyfgeXsWDwYXe;

			private bool elFvfSNMPkTYhYAwoohrqqWyzVAR;

			public bool tYxpLlnZQegKJfEitMdLCGQhvUhk;

			private TempListPool.TList<ActionElementMap> rndPdebrTaiEkZFPFdfZdpdsvfAHA;

			private List<ActionElementMap>.Enumerator bvvkukjtWIjUmiemRziTTEsslVDM;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return HDBUbdkmlKPRvJFygkQhNslFcuhg;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return HDBUbdkmlKPRvJFygkQhNslFcuhg;
				}
			}

			[DebuggerHidden]
			public vSfejiFRLGBBIfcIwXrAQUmZWrZL(int P_0)
			{
				VlEbIMHyFsnntkeVdonoKbmGtVuY = P_0;
				MWgCDwiUVUIvjKjKsFkPpdPTJbiaA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int vlEbIMHyFsnntkeVdonoKbmGtVuY = VlEbIMHyFsnntkeVdonoKbmGtVuY;
				if ((uint)(vlEbIMHyFsnntkeVdonoKbmGtVuY - -4) > 1u && vlEbIMHyFsnntkeVdonoKbmGtVuY != 1)
				{
					return;
				}
				try
				{
					if (vlEbIMHyFsnntkeVdonoKbmGtVuY != -4 && vlEbIMHyFsnntkeVdonoKbmGtVuY != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						bfBUOorufxyzGInAoGhHZlsJdwxd();
					}
				}
				finally
				{
					EspwbfAHAxXLXdCSydrStBAHvAhk();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int vlEbIMHyFsnntkeVdonoKbmGtVuY = VlEbIMHyFsnntkeVdonoKbmGtVuY;
					ControllerMap controllerMap = nweFcsAOhOKwEmAFiZiStiYYLmbIA;
					switch (vlEbIMHyFsnntkeVdonoKbmGtVuY)
					{
					default:
						return false;
					case 0:
					{
						VlEbIMHyFsnntkeVdonoKbmGtVuY = -1;
						if (ReInput._id != controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
						{
							ReInput.CheckInitialized(controllerMap.ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
							return false;
						}
						rndPdebrTaiEkZFPFdfZdpdsvfAHA = TempListPool.GetTList<ActionElementMap>();
						VlEbIMHyFsnntkeVdonoKbmGtVuY = -3;
						List<ActionElementMap> list = rndPdebrTaiEkZFPFdfZdpdsvfAHA.list;
						controllerMap.UlFArbKTYQdEqAtLPNCFxsiTzHnb(oPGVTuvHWFkMfodMEWlMDWjgszlU, true, LjpPoCYdmJGAYNwCyAHAGWqrufFJA, elFvfSNMPkTYhYAwoohrqqWyzVAR, list, false, out var _);
						bvvkukjtWIjUmiemRziTTEsslVDM = list.GetEnumerator();
						VlEbIMHyFsnntkeVdonoKbmGtVuY = -4;
						break;
					}
					case 1:
						VlEbIMHyFsnntkeVdonoKbmGtVuY = -4;
						break;
					}
					if (bvvkukjtWIjUmiemRziTTEsslVDM.MoveNext())
					{
						ActionElementMap current = bvvkukjtWIjUmiemRziTTEsslVDM.Current;
						HDBUbdkmlKPRvJFygkQhNslFcuhg = current;
						VlEbIMHyFsnntkeVdonoKbmGtVuY = 1;
						return true;
					}
					bfBUOorufxyzGInAoGhHZlsJdwxd();
					bvvkukjtWIjUmiemRziTTEsslVDM = default(List<ActionElementMap>.Enumerator);
					EspwbfAHAxXLXdCSydrStBAHvAhk();
					rndPdebrTaiEkZFPFdfZdpdsvfAHA = null;
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

			private void EspwbfAHAxXLXdCSydrStBAHvAhk()
			{
				VlEbIMHyFsnntkeVdonoKbmGtVuY = -1;
				if (rndPdebrTaiEkZFPFdfZdpdsvfAHA != null)
				{
					((IDisposable)rndPdebrTaiEkZFPFdfZdpdsvfAHA).Dispose();
				}
			}

			private void bfBUOorufxyzGInAoGhHZlsJdwxd()
			{
				VlEbIMHyFsnntkeVdonoKbmGtVuY = -3;
				((IDisposable)bvvkukjtWIjUmiemRziTTEsslVDM/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				vSfejiFRLGBBIfcIwXrAQUmZWrZL vSfejiFRLGBBIfcIwXrAQUmZWrZL2;
				if (VlEbIMHyFsnntkeVdonoKbmGtVuY == -2 && MWgCDwiUVUIvjKjKsFkPpdPTJbiaA == Environment.CurrentManagedThreadId)
				{
					VlEbIMHyFsnntkeVdonoKbmGtVuY = 0;
					vSfejiFRLGBBIfcIwXrAQUmZWrZL2 = this;
				}
				else
				{
					vSfejiFRLGBBIfcIwXrAQUmZWrZL2 = new vSfejiFRLGBBIfcIwXrAQUmZWrZL(0);
					vSfejiFRLGBBIfcIwXrAQUmZWrZL2.nweFcsAOhOKwEmAFiZiStiYYLmbIA = nweFcsAOhOKwEmAFiZiStiYYLmbIA;
				}
				vSfejiFRLGBBIfcIwXrAQUmZWrZL2.oPGVTuvHWFkMfodMEWlMDWjgszlU = rDPhkBlUtyzaiRMmduKHubdAhvcGA;
				vSfejiFRLGBBIfcIwXrAQUmZWrZL2.LjpPoCYdmJGAYNwCyAHAGWqrufFJA = qZQnBjkVlPCXXRxUyfgeXsWDwYXe;
				vSfejiFRLGBBIfcIwXrAQUmZWrZL2.elFvfSNMPkTYhYAwoohrqqWyzVAR = tYxpLlnZQegKJfEitMdLCGQhvUhk;
				return vSfejiFRLGBBIfcIwXrAQUmZWrZL2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name = string.Empty;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int ZrBpIhXfOlClfCCHUnfzsnOIhmEz;

		private readonly AList<ActionElementMap> rvqcoXOdpRAOewtDLUZbifwVfBME;

		private readonly ReadOnlyCollection<ActionElementMap> knPbzSGFJRuZaKGmgWGloOBxjAsQ;

		private readonly AList<ActionElementMap> YxTyBXcxRADQgdIOBbkAclPooSzG;

		private readonly ReadOnlyCollection<ActionElementMap> HvhenAvUXxqHHSVuIcVtWAfgnWWA;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int lSpNIxLSCmBWmlfAnMOUDqPjIbGIA;

		private static int oamDFKFvMUuPclnHcgNOCFzfVLyA
		{
			get
			{
				int result = lSpNIxLSCmBWmlfAnMOUDqPjIbGIA;
				if (lSpNIxLSCmBWmlfAnMOUDqPjIbGIA == int.MaxValue)
				{
					lSpNIxLSCmBWmlfAnMOUDqPjIbGIA = 0;
					return result;
				}
				lSpNIxLSCmBWmlfAnMOUDqPjIbGIA++;
				return result;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = num;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = text;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = guid;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return false;
				}
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return -1;
				}
				return _playerId;
			}
			internal set
			{
				_playerId = num;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = num;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return 0;
				}
				return YxTyBXcxRADQgdIOBbkAclPooSzG.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return 0;
				}
				return rvqcoXOdpRAOewtDLUZbifwVfBME.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return HvhenAvUXxqHHSVuIcVtWAfgnWWA;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return HvhenAvUXxqHHSVuIcVtWAfgnWWA;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
				{
					ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return knPbzSGFJRuZaKGmgWGloOBxjAsQ;
			}
		}

		internal AList<ActionElementMap> tVVQZXmeiSGqPDWfAiktOetHVuiqA => rvqcoXOdpRAOewtDLUZbifwVfBME;

		public ControllerMap()
		{
			_id = oamDFKFvMUuPclnHcgNOCFzfVLyA;
			_sourceMapId = -1;
			rvqcoXOdpRAOewtDLUZbifwVfBME = new AList<ActionElementMap>();
			knPbzSGFJRuZaKGmgWGloOBxjAsQ = new ReadOnlyCollection<ActionElementMap>(rvqcoXOdpRAOewtDLUZbifwVfBME);
			YxTyBXcxRADQgdIOBbkAclPooSzG = new AList<ActionElementMap>();
			HvhenAvUXxqHHSVuIcVtWAfgnWWA = new ReadOnlyCollection<ActionElementMap>(YxTyBXcxRADQgdIOBbkAclPooSzG);
			ZrBpIhXfOlClfCCHUnfzsnOIhmEz = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = oamDFKFvMUuPclnHcgNOCFzfVLyA;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			if (P_0.rvqcoXOdpRAOewtDLUZbifwVfBME != null)
			{
				int count = P_0.rvqcoXOdpRAOewtDLUZbifwVfBME.Count;
				for (int i = 0; i < count; i++)
				{
					xYigbSGXAAumvDpYeBvrBrADzoYN(new ActionElementMap(P_0.rvqcoXOdpRAOewtDLUZbifwVfBME[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			AList<ActionElementMap> yxTyBXcxRADQgdIOBbkAclPooSzG = YxTyBXcxRADQgdIOBbkAclPooSzG;
			for (int i = 0; i < yxTyBXcxRADQgdIOBbkAclPooSzG.Count; i++)
			{
				if (YxTyBXcxRADQgdIOBbkAclPooSzG[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			AList<ActionElementMap> yxTyBXcxRADQgdIOBbkAclPooSzG = YxTyBXcxRADQgdIOBbkAclPooSzG;
			for (int i = 0; i < yxTyBXcxRADQgdIOBbkAclPooSzG.Count; i++)
			{
				if (YxTyBXcxRADQgdIOBbkAclPooSzG[i].keyCode == keyCode && YxTyBXcxRADQgdIOBbkAclPooSzG[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> yxTyBXcxRADQgdIOBbkAclPooSzG = YxTyBXcxRADQgdIOBbkAclPooSzG;
			for (int i = 0; i < yxTyBXcxRADQgdIOBbkAclPooSzG.Count; i++)
			{
				if (YxTyBXcxRADQgdIOBbkAclPooSzG[i].JtzYMpqdJGMyIjXIPHXXckWafklL == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			AList<ActionElementMap> yxTyBXcxRADQgdIOBbkAclPooSzG = YxTyBXcxRADQgdIOBbkAclPooSzG;
			for (int i = 0; i < yxTyBXcxRADQgdIOBbkAclPooSzG.Count; i++)
			{
				if (YxTyBXcxRADQgdIOBbkAclPooSzG[i].JtzYMpqdJGMyIjXIPHXXckWafklL == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (GetElementMap(elementAssignment.elementMapId) == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, SVQbmGoCgjXlQooYDoNZCFflMVzP.UeHIoYfXRtOMvsmupeRJgnkNPpWjA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.tdLKgiuKWlzkkJjXwztgjBdYXkPE(this, actionElementMap);
			xYigbSGXAAumvDpYeBvrBrADzoYN(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			eAsBfRDagglhnicSbCkiExWHSBZOA eAsBfRDagglhnicSbCkiExWHSBZOA2 = eAsBfRDagglhnicSbCkiExWHSBZOA.vtdMuKFGBlggrefjvxNVIZCJriqZ(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, eAsBfRDagglhnicSbCkiExWHSBZOA2.farIvpkQhxAmLCAIebDOJzDZwiUT, eAsBfRDagglhnicSbCkiExWHSBZOA2.IBOJOEILlxMWeoMuYYIaLGfPDqMR, eAsBfRDagglhnicSbCkiExWHSBZOA2.bDLRGMPhlREQkJZFbcEAPeijhsvM, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			xYigbSGXAAumvDpYeBvrBrADzoYN(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, SVQbmGoCgjXlQooYDoNZCFflMVzP.UeHIoYfXRtOMvsmupeRJgnkNPpWjA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (atQHqsSPDBIixhmmTglHLLlJFcZg(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				xYigbSGXAAumvDpYeBvrBrADzoYN(elementMap);
			}
			if (atQHqsSPDBIixhmmTglHLLlJFcZg(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.RsdGSzmfVkGcoiEkkBUVplIRaolDA();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.tdLKgiuKWlzkkJjXwztgjBdYXkPE(this, elementMap);
			result = elementMap;
			return true;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			eAsBfRDagglhnicSbCkiExWHSBZOA eAsBfRDagglhnicSbCkiExWHSBZOA2 = eAsBfRDagglhnicSbCkiExWHSBZOA.vtdMuKFGBlggrefjvxNVIZCJriqZ(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, eAsBfRDagglhnicSbCkiExWHSBZOA2.farIvpkQhxAmLCAIebDOJzDZwiUT, eAsBfRDagglhnicSbCkiExWHSBZOA2.IBOJOEILlxMWeoMuYYIaLGfPDqMR, eAsBfRDagglhnicSbCkiExWHSBZOA2.bDLRGMPhlREQkJZFbcEAPeijhsvM, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				result = null;
				return false;
			}
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				xYigbSGXAAumvDpYeBvrBrADzoYN(elementMap);
			}
			if (atQHqsSPDBIixhmmTglHLLlJFcZg(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			dPlbLqJPIpqKVByoBbxwKcPmmhrac(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			int num = atQHqsSPDBIixhmmTglHLLlJFcZg(elementMapId);
			if (num < 0)
			{
				return false;
			}
			vsEKoWuAbjzYMXpEOySXsCSaeYAO(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i].JtzYMpqdJGMyIjXIPHXXckWafklL == elementMapId)
				{
					return rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				}
			}
			return null;
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = elementMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (!skipDisabledMaps || allMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					list.Add(allMap);
				}
			}
			return list.ToArray();
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(skipDisabledMaps: false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return UjKRdpolAWgWhIhFNERzeONGPEKGb(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			foreach (ActionElementMap allMap2 in AllMaps)
			{
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return cZhlovFicBbegtZKBDXbQpHySFih(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(MaVAVBfItPtYqSSoxSLdqoWAiBmY))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new MaVAVBfItPtYqSSoxSLdqoWAiBmY(-2)
			{
				gYhejKVtQwKhGBYiCFSBhqoiFLNf = this,
				mHFCXeglsIgQQyCZCdpcsMRSFNtEb = actionId,
				KjpSwdJdRnxMQYaHTjZDIGRLyxAd = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i]._actionId == actionId && (!skipDisabledMaps || rvqcoXOdpRAOewtDLUZbifwVfBME[i].IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					return rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, skipDisabledMaps);
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
			return result;
		}

		[IteratorStateMachine(typeof(HADaYpCTJJVfdOIbTgdUzaOlgYJCb))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new HADaYpCTJJVfdOIbTgdUzaOlgYJCb(-2)
			{
				tyMYIJaXzYjwRtQzohuBzlpQjEQj = this,
				oRDGNXHBVZEHDcYkugsYJlrcMMjN = elementTarget,
				OLiRAlitQUiQkRxRKpzstJPsmWtj = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, actionId, skipDisabledMaps);
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(vSfejiFRLGBBIfcIwXrAQUmZWrZL))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new vSfejiFRLGBBIfcIwXrAQUmZWrZL(-2)
			{
				nweFcsAOhOKwEmAFiZiStiYYLmbIA = this,
				rDPhkBlUtyzaiRMmduKHubdAhvcGA = elementTarget,
				qZQnBjkVlPCXXRxUyfgeXsWDwYXe = actionId,
				tYxpLlnZQegKJfEitMdLCGQhvUhk = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, skipDisabledMaps);
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			bool flag;
			return daBPlcrTfpFvPZUhwqVBCZWmbSyH(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, actionId, skipDisabledMaps);
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			bool flag;
			return daBPlcrTfpFvPZUhwqVBCZWmbSyH(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, skipDisabledMaps, results);
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			bool flag;
			return UlFArbKTYQdEqAtLPNCFxsiTzHnb(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2 = qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.UonzQUMBmRTcGnEIJcoQvobZckog(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2, actionId, skipDisabledMaps, results);
			qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			bool flag;
			return UlFArbKTYQdEqAtLPNCFxsiTzHnb(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			return NRywdmgQRRPVQktRbNMmmpfgXffv(predicate, false);
		}

		internal virtual ActionElementMap NRywdmgQRRPVQktRbNMmmpfgXffv(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return xDIGkpIfuXaWNaFSUfDTRkTUyIrk(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return FvRJBZpHmtrKIZhJYtShooONUZwU(predicate, false, results, false);
		}

		internal virtual int FvRJBZpHmtrKIZhJYtShooONUZwU(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return kBBPIgXpzJBAbDPpPXgjbwFuXXXaA(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
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
			int count = YxTyBXcxRADQgdIOBbkAclPooSzG.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = YxTyBXcxRADQgdIOBbkAclPooSzG[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
			}
		}

		public virtual void ClearElementMaps()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return;
			}
			rvqcoXOdpRAOewtDLUZbifwVfBME.Clear();
			YxTyBXcxRADQgdIOBbkAclPooSzG.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int num = 0;
			int count = YxTyBXcxRADQgdIOBbkAclPooSzG.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = YxTyBXcxRADQgdIOBbkAclPooSzG[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM != state)
				{
					actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null || index < 0 || index >= rvqcoXOdpRAOewtDLUZbifwVfBME.Count)
			{
				return null;
			}
			return rvqcoXOdpRAOewtDLUZbifwVfBME[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(rvqcoXOdpRAOewtDLUZbifwVfBME);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = rvqcoXOdpRAOewtDLUZbifwVfBME.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return MUrrGoUjbDBiWhuRLGuropmKzRIY(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
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
				ActionElementMap actionElementMap2 = rvqcoXOdpRAOewtDLUZbifwVfBME[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			InputAction inputAction = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.hblokcMPisiOeQwMIhTTYxyBYsjy(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return EgnvWttVZzOYqsuCulAEtGHhygvF(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(PMwKDtbDhxrYZIMQJpItKEGItByB))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new PMwKDtbDhxrYZIMQJpItKEGItByB(-2)
			{
				GgyowEnnSvljAVbfTMmeoFVSArpc = this,
				ZxjvlPwDitrwOYoAiQUEqLHrrOLc = actionId,
				JswDtPQSBuUkIkSDEaJqHpcyZfCh = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.enabled))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			int actionId = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			return xDIGkpIfuXaWNaFSUfDTRkTUyIrk(predicate, false);
		}

		internal ActionElementMap xDIGkpIfuXaWNaFSUfDTRkTUyIrk(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstButtonMapMatch", exception);
			}
			return null;
		}

		public int GetButtonMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return kBBPIgXpzJBAbDPpPXgjbwFuXXXaA(predicate, false, results, false);
		}

		internal int kBBPIgXpzJBAbDPpPXgjbwFuXXXaA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num2 = buttonMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
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
			int count = rvqcoXOdpRAOewtDLUZbifwVfBME.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					vsEKoWuAbjzYMXpEOySXsCSaeYAO(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			int num = 0;
			int count = rvqcoXOdpRAOewtDLUZbifwVfBME.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM != state)
				{
					actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM = state;
					num++;
				}
			}
			return num;
		}

		public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
		{
			return DoesElementAssignmentConflict(controllerMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
		{
			return DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
		{
			return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false);
		}

		public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return false;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int num = buttonMapCount;
			int count = buttonMaps.Count;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (skipDisabledMaps && !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (actionElementMap == null || rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
			{
				return false;
			}
			for (int i = 0; i < rvqcoXOdpRAOewtDLUZbifwVfBME.Count; i++)
			{
				ActionElementMap actionElementMap2 = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return false;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return false;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < rvqcoXOdpRAOewtDLUZbifwVfBME.Count; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if ((!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return ElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return ElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		[IteratorStateMachine(typeof(aOYMIQmXGgRQXcEUsudzRrehIImU))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new aOYMIQmXGgRQXcEUsudzRrehIImU(-2)
			{
				LfmCWriORJGpzyBRzeZMOaEGzRwh = this,
				QSrgOIKrWibktfRhgmvbJAGWIoah = controllerMap,
				ZlPVwpBzlxNWOKDtxIhKCTEkXANE = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(wCQmPbbzanfANDoPhotJzXaxHqKl))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new wCQmPbbzanfANDoPhotJzXaxHqKl(-2)
			{
				XHTVroWSYozhHICqJCdWakYtDbGI = this,
				MUAYHosvVdZYYJSZdRlTNnmZBMx = actionElementMap,
				JYUsTVMYhvcTcZCYMOTbBlZZzIgD = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(ekUNebxKAelngPjGUHfTKWIKRDuJA))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new ekUNebxKAelngPjGUHfTKWIKRDuJA(-2)
			{
				ixfyOgavAZUFARXChwKzNcpihXpu = this,
				cMqSSCIDxmLJFGlVfYpnreQCAVtz = conflictCheck,
				TFiRECDNYNgIIgsftOgGrFqBGWBe = skipDisabledMaps
			};
		}

		public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.rvqcoXOdpRAOewtDLUZbifwVfBME;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = list.Count;
			for (int num2 = rvqcoXOdpRAOewtDLUZbifwVfBME.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[num2];
				if (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(list[i]))
						{
							vsEKoWuAbjzYMXpEOySXsCSaeYAO(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return num;
			}
			for (int num2 = rvqcoXOdpRAOewtDLUZbifwVfBME.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = rvqcoXOdpRAOewtDLUZbifwVfBME[num2];
				if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					vsEKoWuAbjzYMXpEOySXsCSaeYAO(actionElementMap2.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = rvqcoXOdpRAOewtDLUZbifwVfBME.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[num2];
				if ((!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					vsEKoWuAbjzYMXpEOySXsCSaeYAO(actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return ItCUGWipsbSXnwPaLdhDyEkLPfzc(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return APpATFydmqdisQTNkPBnodjHbwzp(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return aHLeYxerPeUnYNeIEbCAvvtUSnFN(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return ItCUGWipsbSXnwPaLdhDyEkLPfzc(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return APpATFydmqdisQTNkPBnodjHbwzp(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			return aHLeYxerPeUnYNeIEbCAvvtUSnFN(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int ItCUGWipsbSXnwPaLdhDyEkLPfzc(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0._enabled))
			{
				return 0;
			}
			int num = 0;
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return num;
			}
			IList<ActionElementMap> list = P_0.rvqcoXOdpRAOewtDLUZbifwVfBME;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = list.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (!actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = list[j];
					if ((!P_1 || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int APpATFydmqdisQTNkPBnodjHbwzp(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.IdtDkaTUBQdYslzoHMBnxOLemrRM))
			{
				return 0;
			}
			int num = 0;
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
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int aHLeYxerPeUnYNeIEbCAvvtUSnFN(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return 0;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int num = 0;
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(controllerMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(actionElementMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(conflictCheck, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (YxTyBXcxRADQgdIOBbkAclPooSzG == null)
			{
				return num;
			}
			IList<ActionElementMap> yxTyBXcxRADQgdIOBbkAclPooSzG = controllerMap.YxTyBXcxRADQgdIOBbkAclPooSzG;
			if (yxTyBXcxRADQgdIOBbkAclPooSzG == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = yxTyBXcxRADQgdIOBbkAclPooSzG.Count;
			for (int num2 = YxTyBXcxRADQgdIOBbkAclPooSzG.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = YxTyBXcxRADQgdIOBbkAclPooSzG[num2];
				if (!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || yxTyBXcxRADQgdIOBbkAclPooSzG[i].IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.CheckForAssignmentConflict(yxTyBXcxRADQgdIOBbkAclPooSzG[i]))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num;
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (YxTyBXcxRADQgdIOBbkAclPooSzG == null)
			{
				return num;
			}
			for (int num2 = YxTyBXcxRADQgdIOBbkAclPooSzG.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = YxTyBXcxRADQgdIOBbkAclPooSzG[num2];
				if ((!skipDisabledMaps || actionElementMap2.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					try
					{
						actionToPerform(actionElementMap2);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (YxTyBXcxRADQgdIOBbkAclPooSzG == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = YxTyBXcxRADQgdIOBbkAclPooSzG.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = YxTyBXcxRADQgdIOBbkAclPooSzG[num2];
				if ((!skipDisabledMaps || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM) && actionElementMap.JtzYMpqdJGMyIjXIPHXXckWafklL != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					try
					{
						actionToPerform(actionElementMap);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return EmptyObjects<string>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return new string[0];
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = rvqcoXOdpRAOewtDLUZbifwVfBME[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return string.Empty;
			}
			try
			{
				return NWpUWwWpbjoJFhQBNcbFOjHtBHYb().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return string.Empty;
			}
			try
			{
				return NWpUWwWpbjoJFhQBNcbFOjHtBHYb().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				aeTKcrzfQkODTQybGHqaOyCSCntK aeTKcrzfQkODTQybGHqaOyCSCntK2 = ReInput.DytaXyfbAbvOuJTDkhfxSrywpOvW(templateTypeGuid);
				string text = ((aeTKcrzfQkODTQybGHqaOyCSCntK2 != null) ? aeTKcrzfQkODTQybGHqaOyCSCntK2.YEuOjukClCSuQmxSxaoCMfmRmnBq : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.OmGBmXDBMsEXItQMdHmegNNakQhzB(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (templateInterfaceType == null)
			{
				throw new ArgumentNullException("templateInterfaceType");
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.OmGBmXDBMsEXItQMdHmegNNakQhzB(controllerTemplate, this);
		}

		private ControllerTemplateMap roGhtdKcIhaZyRmbewlSNCaCdEVp(IControllerTemplate P_0)
		{
			if (ReInput._id != ZrBpIhXfOlClfCCHUnfzsnOIhmEz)
			{
				ReInput.CheckInitialized(ZrBpIhXfOlClfCCHUnfzsnOIhmEz);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.OmGBmXDBMsEXItQMdHmegNNakQhzB(P_0, this);
		}

		internal virtual bool oFdZMpJjJyspammNnQEQXfobMABp(ActionElementMap P_0)
		{
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_0._elementType))
			{
				return false;
			}
			xYigbSGXAAumvDpYeBvrBrADzoYN(P_0);
			return true;
		}

		internal virtual int UjKRdpolAWgWhIhFNERzeONGPEKGb(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = rvqcoXOdpRAOewtDLUZbifwVfBME.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || rvqcoXOdpRAOewtDLUZbifwVfBME[i].IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					P_0.Add(rvqcoXOdpRAOewtDLUZbifwVfBME[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap pemGBSalQNQYjohYAGBTankGHslaA(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_2))
			{
				return null;
			}
			int num = PNaJsMzrSfaVlzqIatuEyErhVDGE(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return rvqcoXOdpRAOewtDLUZbifwVfBME[num];
		}

		internal virtual int GFPBGygEJGRDENNwiJIkHlTcrEis(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_2)
			{
				P_1.Clear();
			}
			else
			{
				num = P_1.Count;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i]._elementIdentifierId == P_0)
				{
					P_1.Add(rvqcoXOdpRAOewtDLUZbifwVfBME[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool NnZBpgBBcNqbCrOiWLJipZMsNMtj(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i]._elementIdentifierId == P_0 && rvqcoXOdpRAOewtDLUZbifwVfBME[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int PNaJsMzrSfaVlzqIatuEyErhVDGE(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_2))
			{
				return -1;
			}
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i]._elementIdentifierId == P_0 && rvqcoXOdpRAOewtDLUZbifwVfBME[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int atQHqsSPDBIixhmmTglHLLlJFcZg(int P_0)
		{
			if (rvqcoXOdpRAOewtDLUZbifwVfBME == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i].JtzYMpqdJGMyIjXIPHXXckWafklL == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int MUrrGoUjbDBiWhuRLGuropmKzRIY(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = buttonMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (!P_0 || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int EgnvWttVZzOYqsuCulAEtGHhygvF(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_3)
			{
				P_2.Clear();
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return 0;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int cZhlovFicBbegtZKBDXbQpHySFih(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.IdtDkaTUBQdYslzoHMBnxOLemrRM))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap daBPlcrTfpFvPZUhwqVBCZWmbSyH(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!kJHTcGRFDwvoRDjOfUkkLcLUCkgz(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || rvqcoXOdpRAOewtDLUZbifwVfBME[i]._actionId == P_2) && (!P_3 || rvqcoXOdpRAOewtDLUZbifwVfBME[i].IdtDkaTUBQdYslzoHMBnxOLemrRM) && rvqcoXOdpRAOewtDLUZbifwVfBME[i].IsTarget(P_0))
				{
					return rvqcoXOdpRAOewtDLUZbifwVfBME[i];
				}
			}
			return null;
		}

		internal virtual int UlFArbKTYQdEqAtLPNCFxsiTzHnb(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_5)
			{
				P_4.Clear();
			}
			P_6 = false;
			if (P_1 && P_2 < 0)
			{
				P_6 = true;
				return num;
			}
			if (!kJHTcGRFDwvoRDjOfUkkLcLUCkgz(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || rvqcoXOdpRAOewtDLUZbifwVfBME[i]._actionId == P_2) && (!P_3 || rvqcoXOdpRAOewtDLUZbifwVfBME[i].IdtDkaTUBQdYslzoHMBnxOLemrRM) && rvqcoXOdpRAOewtDLUZbifwVfBME[i].IsTarget(P_0))
				{
					P_4.Add(rvqcoXOdpRAOewtDLUZbifwVfBME[i]);
					num++;
				}
			}
			return num;
		}

		internal void pQYBxmRnXReAIYjVDkJdTCXctEoP(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap != null && elementMap._elementType != P_1)
			{
				elementMap._elementType = P_1;
				if (P_1 == ControllerElementType.Button)
				{
					elementMap._axisRange = AxisRange.Full;
					elementMap._invert = false;
				}
				DeleteElementMap(P_0);
				rABROfEDwiWxichKRjAJaMtoqWMo(elementMap);
			}
		}

		internal virtual bool rABROfEDwiWxichKRjAJaMtoqWMo(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!wlUijeQREdXIAJdAynNbAwTUrZwI(P_0._elementType))
			{
				return false;
			}
			rvqcoXOdpRAOewtDLUZbifwVfBME.Add(P_0);
			pomCAwjEmQpDobmuvwRNpcKrsivIA(P_0);
			return true;
		}

		internal bool kJHTcGRFDwvoRDjOfUkkLcLUCkgz(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			Controller controller = P_0.controller;
			if (controller == null || controller.type != _controllerType || controller.id != _controllerId)
			{
				return false;
			}
			return true;
		}

		internal bool qESTfaKFuDWdLXNwHaloUDjbMBOQ(string P_0)
		{
			try
			{
				kCvDSGukbMnBdmPCsgkebjtPzZQF(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool RKLsmaPAZctazlWBrXTtKsDHpkUC(string P_0)
		{
			try
			{
				kCvDSGukbMnBdmPCsgkebjtPzZQF(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void pomCAwjEmQpDobmuvwRNpcKrsivIA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				YxTyBXcxRADQgdIOBbkAclPooSzG.Add(P_0);
				YxTyBXcxRADQgdIOBbkAclPooSzG.Sort(oHDrqEFIhwdAGWigBvyrUzyUEmcG.qageGEQhgHGEGhrzfRUEYNYoRKBl);
			}
		}

		internal void bwcafwKatcNdtKlmLOmQWWDqMRBc(int P_0)
		{
			int num = qbtDjxIPwTufrLSGqMXVQaujvHxnA(P_0);
			if (num >= 0)
			{
				YxTyBXcxRADQgdIOBbkAclPooSzG.RemoveAt(num);
			}
		}

		internal void TyaQRWFMelqyoPCgqRNbwsdTfYigA(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = qbtDjxIPwTufrLSGqMXVQaujvHxnA(P_0);
				if (num >= 0)
				{
					YxTyBXcxRADQgdIOBbkAclPooSzG[num] = P_1;
					YxTyBXcxRADQgdIOBbkAclPooSzG.Sort(oHDrqEFIhwdAGWigBvyrUzyUEmcG.qageGEQhgHGEGhrzfRUEYNYoRKBl);
				}
			}
		}

		internal static void dPlbLqJPIpqKVByoBbxwKcPmmhrac(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.RsdGSzmfVkGcoiEkkBUVplIRaolDA();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			P_0._elementIdentifierId = P_3;
			P_0._axisContribution = P_2;
			P_0._axisRange = P_5;
			if (P_4 == ControllerElementType.Axis)
			{
				P_0._invert = P_6;
			}
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId)?.tdLKgiuKWlzkkJjXwztgjBdYXkPE(this, map);
			}
		}

		internal virtual bool kCvDSGukbMnBdmPCsgkebjtPzZQF(SerializedObject P_0)
		{
			bool flag = false;
			_sourceMapId = -1;
			_categoryId = -1;
			_layoutId = -1;
			_name = string.Empty;
			_hardwareGuid = Guid.Empty;
			_enabled = true;
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
			P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
			P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
			P_0.TryGetDeserializedValueByRef("name", ref _name);
			P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
			P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.PrgcKkEfUlCmHYYlVROGdYJqqrgqA(value2);
						if (ActionElementMap.FafLWUVisEGIhtnPwShoQNryjuiw(actionElementMap))
						{
							xYigbSGXAAumvDpYeBvrBrADzoYN(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void DlmSYCzIIucAJHOoZCCoIGfCWPMK(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "dataVersion",
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string hDNykFqkGTdIdaCMqpOZhaRNJXwGb = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
				{
					MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "hardwareGuid",
					HDNykFqkGTdIdaCMqpOZhaRNJXwGb = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
				{
					MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "hardwareName",
					HDNykFqkGTdIdaCMqpOZhaRNJXwGb = hDNykFqkGTdIdaCMqpOZhaRNJXwGb
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				hwMaMUHTAbktdLOuownSwUDJVxiDA = "xmlns",
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "xsi",
				kGESCebYXkaHwqimYjUfiApoHXHAA = null,
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				hwMaMUHTAbktdLOuownSwUDJVxiDA = "xsi",
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "schemaLocation",
				kGESCebYXkaHwqimYjUfiApoHXHAA = null,
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
			});
			P_0.Add("sourceMapId", _sourceMapId);
			P_0.Add("categoryId", _categoryId);
			P_0.Add("layoutId", _layoutId);
			P_0.Add("name", _name);
			P_0.Add("hardwareGuid", _hardwareGuid);
			P_0.Add("enabled", _enabled);
			int num = buttonMapCount;
			List<object> list = new List<object>();
			P_0.Add("buttonMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (rvqcoXOdpRAOewtDLUZbifwVfBME[i] != null)
				{
					list.Add(rvqcoXOdpRAOewtDLUZbifwVfBME[i].ZbfJTMRtbmDfNrFSMKKfiGzhjUdo());
				}
			}
		}

		private bool wlUijeQREdXIAJdAynNbAwTUrZwI(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void vsEKoWuAbjzYMXpEOySXsCSaeYAO(int P_0, int P_1)
		{
			bwcafwKatcNdtKlmLOmQWWDqMRBc(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				rvqcoXOdpRAOewtDLUZbifwVfBME.RemoveAt(P_1);
			}
		}

		private void xYigbSGXAAumvDpYeBvrBrADzoYN(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				rvqcoXOdpRAOewtDLUZbifwVfBME.Add(P_0);
				pomCAwjEmQpDobmuvwRNpcKrsivIA(P_0);
			}
		}

		private void OMstnCGCGAJLleTJtlpfBvKzidggb(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				TyaQRWFMelqyoPCgqRNbwsdTfYigA(rvqcoXOdpRAOewtDLUZbifwVfBME[P_1].JtzYMpqdJGMyIjXIPHXXckWafklL, P_0);
				rvqcoXOdpRAOewtDLUZbifwVfBME[P_1] = P_0;
			}
		}

		private int qbtDjxIPwTufrLSGqMXVQaujvHxnA(int P_0)
		{
			if (YxTyBXcxRADQgdIOBbkAclPooSzG == null)
			{
				return -1;
			}
			int count = YxTyBXcxRADQgdIOBbkAclPooSzG.Count;
			for (int i = 0; i < count; i++)
			{
				if (YxTyBXcxRADQgdIOBbkAclPooSzG[i].JtzYMpqdJGMyIjXIPHXXckWafklL == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject NWpUWwWpbjoJFhQBNcbFOjHtBHYb()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			DlmSYCzIIucAJHOoZCCoIGfCWPMK(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap VCNuXHtewMrFgNwrcjRWWguohOtc(ControllerType P_0)
		{
			return P_0 switch
			{
				ControllerType.Keyboard => new KeyboardMap(), 
				ControllerType.Mouse => new MouseMap(), 
				ControllerType.Joystick => new JoystickMap(), 
				ControllerType.Custom => new CustomControllerMap(), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerMap yhcDnHWEcCKyYWCiWEaejISeqkXh(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.lwHEAnGmrTJeNiscEqBQoTmCfYjad(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.nZBfxCqZmvLSXObwPNbLnkamWNBL(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.nkowMCslevcIhjWMTAPzAtOQOgnV(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.qJKjKoLhTncWyGTTPhxDqnodLhyP(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = VCNuXHtewMrFgNwrcjRWWguohOtc(controllerType);
			try
			{
				controllerMap.qESTfaKFuDWdLXNwHaloUDjbMBOQ(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}

		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = VCNuXHtewMrFgNwrcjRWWguohOtc(controllerType);
			try
			{
				controllerMap.RKLsmaPAZctazlWBrXTtKsDHpkUC(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
