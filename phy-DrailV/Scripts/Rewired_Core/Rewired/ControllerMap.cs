using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class WTTFJhcfiMsvdcyjHiAZNBUAVfcd : IComparer<ActionElementMap>
		{
			public static WTTFJhcfiMsvdcyjHiAZNBUAVfcd OYQiqncsATCGrosbfEmmNOJBdCuX;

			public static WTTFJhcfiMsvdcyjHiAZNBUAVfcd LSiMwhYpzbixHWLRsspDEMspSxKF => OYQiqncsATCGrosbfEmmNOJBdCuX ?? (OYQiqncsATCGrosbfEmmNOJBdCuX = new WTTFJhcfiMsvdcyjHiAZNBUAVfcd());

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
				int num;
				switch (x._elementType)
				{
				case ControllerElementType.Button:
					num = 0;
					break;
				case ControllerElementType.Axis:
					num = 1;
					break;
				case ControllerElementType.CompoundElement:
					num = 2;
					break;
				default:
					throw new NotImplementedException();
				}
				int num2;
				switch (y._elementType)
				{
				case ControllerElementType.Button:
					num2 = 0;
					break;
				case ControllerElementType.Axis:
					num2 = 1;
					break;
				case ControllerElementType.CompoundElement:
					num2 = 2;
					break;
				default:
					throw new NotImplementedException();
				}
				if (num <= num2)
				{
					return -1;
				}
				return 1;
			}
		}

		private sealed class lvmiNWGYVVFJfqFIRbleZUhMfiVV : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

			public int JVHPuraouxduvcIEzsfWFTjVVggFb;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private IList<ActionElementMap> rwLZTeJsNtafvflykqfRNVAfOyHTA;

			private int vMZFJHFaEmTxVpkZzcCiweeVzYxqA;

			private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

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
			public lvmiNWGYVVFJfqFIRbleZUhMfiVV(int P_0)
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
				ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00af;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
				{
					return false;
				}
				rwLZTeJsNtafvflykqfRNVAfOyHTA = controllerMap.ButtonMaps;
				vMZFJHFaEmTxVpkZzcCiweeVzYxqA = controllerMap.buttonMapCount;
				jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
				goto IL_00bf;
				IL_00bf:
				if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < vMZFJHFaEmTxVpkZzcCiweeVzYxqA)
				{
					ActionElementMap actionElementMap = rwLZTeJsNtafvflykqfRNVAfOyHTA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA];
					if (actionElementMap._actionId == BOmXoDplzfnHtyBjNJvkkPzUlWST && (!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = actionElementMap;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
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
				lvmiNWGYVVFJfqFIRbleZUhMfiVV lvmiNWGYVVFJfqFIRbleZUhMfiVV2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					lvmiNWGYVVFJfqFIRbleZUhMfiVV2 = this;
				}
				else
				{
					lvmiNWGYVVFJfqFIRbleZUhMfiVV2 = new lvmiNWGYVVFJfqFIRbleZUhMfiVV(0);
					lvmiNWGYVVFJfqFIRbleZUhMfiVV2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				lvmiNWGYVVFJfqFIRbleZUhMfiVV2.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
				lvmiNWGYVVFJfqFIRbleZUhMfiVV2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return lvmiNWGYVVFJfqFIRbleZUhMfiVV2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class KIUvmHRaAEZaiQkKkGdJKYThOFwFA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private ControllerMap WLiuUldTXEcuIGVhKWPVeISBtYjL;

			public ControllerMap VjZXfzuBnUHXbbWlMycIUuGPGGJeb;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private IList<ActionElementMap> lCHCZrcoFlCfTgWubCRaCrtdgLjt;

			private int rLJMsjCpggXLexwUJClpxbSRSzch;

			private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

			private ActionElementMap OGxbZfBFGLIZHGUpbpRiLKcmsiBO;

			private int lzxcEIfPbLrgzCYMIFfPEFYSGRZlA;

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
			public KIUvmHRaAEZaiQkKkGdJKYThOFwFA(int P_0)
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
				ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_019c;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				if (WLiuUldTXEcuIGVhKWPVeISBtYjL == null || controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
				{
					return false;
				}
				if (bbJFyfBYztkbqyDKwjcJJfiCvWSr && (!controllerMap._enabled || !WLiuUldTXEcuIGVhKWPVeISBtYjL._enabled))
				{
					return false;
				}
				lCHCZrcoFlCfTgWubCRaCrtdgLjt = WLiuUldTXEcuIGVhKWPVeISBtYjL.ButtonMaps;
				if (lCHCZrcoFlCfTgWubCRaCrtdgLjt == null)
				{
					return false;
				}
				rLJMsjCpggXLexwUJClpxbSRSzch = lCHCZrcoFlCfTgWubCRaCrtdgLjt.Count;
				jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
				goto IL_01d4;
				IL_01d4:
				if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh.Count)
				{
					OGxbZfBFGLIZHGUpbpRiLKcmsiBO = controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA];
					if (!bbJFyfBYztkbqyDKwjcJJfiCvWSr || OGxbZfBFGLIZHGUpbpRiLKcmsiBO.KByWFLCBjjvqwXYVZFDfzPdklyjf)
					{
						lzxcEIfPbLrgzCYMIFfPEFYSGRZlA = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (lzxcEIfPbLrgzCYMIFfPEFYSGRZlA < rLJMsjCpggXLexwUJClpxbSRSzch)
				{
					ActionElementMap actionElementMap = lCHCZrcoFlCfTgWubCRaCrtdgLjt[lzxcEIfPbLrgzCYMIFfPEFYSGRZlA];
					if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && OGxbZfBFGLIZHGUpbpRiLKcmsiBO.CheckForAssignmentConflict(actionElementMap))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, OGxbZfBFGLIZHGUpbpRiLKcmsiBO.kqvbpTxWGdGtrNRdxLepeZkwTJDn, OGxbZfBFGLIZHGUpbpRiLKcmsiBO._actionId, OGxbZfBFGLIZHGUpbpRiLKcmsiBO._elementType, OGxbZfBFGLIZHGUpbpRiLKcmsiBO._elementIdentifierId, OGxbZfBFGLIZHGUpbpRiLKcmsiBO.keyCode, OGxbZfBFGLIZHGUpbpRiLKcmsiBO.modifierKeyFlags);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_019c;
				}
				OGxbZfBFGLIZHGUpbpRiLKcmsiBO = null;
				goto IL_01c4;
				IL_01c4:
				jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
				goto IL_01d4;
				IL_019c:
				lzxcEIfPbLrgzCYMIFfPEFYSGRZlA++;
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
				KIUvmHRaAEZaiQkKkGdJKYThOFwFA kIUvmHRaAEZaiQkKkGdJKYThOFwFA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					kIUvmHRaAEZaiQkKkGdJKYThOFwFA = this;
				}
				else
				{
					kIUvmHRaAEZaiQkKkGdJKYThOFwFA = new KIUvmHRaAEZaiQkKkGdJKYThOFwFA(0);
					kIUvmHRaAEZaiQkKkGdJKYThOFwFA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				kIUvmHRaAEZaiQkKkGdJKYThOFwFA.WLiuUldTXEcuIGVhKWPVeISBtYjL = VjZXfzuBnUHXbbWlMycIUuGPGGJeb;
				kIUvmHRaAEZaiQkKkGdJKYThOFwFA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return kIUvmHRaAEZaiQkKkGdJKYThOFwFA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class YLIErmCIuZRkesvRfkotgmLddWKIA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private ActionElementMap iTDfhpbZQXABExodAcvVPhaugdAhA;

			public ActionElementMap PnhRmbULhEBSLPPKimPLlyDMDlCy;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

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
			public YLIErmCIuZRkesvRfkotgmLddWKIA(int P_0)
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
				ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_0111;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				if (iTDfhpbZQXABExodAcvVPhaugdAhA == null || controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
				{
					return false;
				}
				if (bbJFyfBYztkbqyDKwjcJJfiCvWSr && (!controllerMap._enabled || !iTDfhpbZQXABExodAcvVPhaugdAhA.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_0121;
				IL_0111:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
				goto IL_0121;
				IL_0121:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh.Count)
				{
					ActionElementMap actionElementMap = controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
					if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(iTDfhpbZQXABExodAcvVPhaugdAhA))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
				YLIErmCIuZRkesvRfkotgmLddWKIA yLIErmCIuZRkesvRfkotgmLddWKIA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					yLIErmCIuZRkesvRfkotgmLddWKIA = this;
				}
				else
				{
					yLIErmCIuZRkesvRfkotgmLddWKIA = new YLIErmCIuZRkesvRfkotgmLddWKIA(0);
					yLIErmCIuZRkesvRfkotgmLddWKIA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				yLIErmCIuZRkesvRfkotgmLddWKIA.iTDfhpbZQXABExodAcvVPhaugdAhA = PnhRmbULhEBSLPPKimPLlyDMDlCy;
				yLIErmCIuZRkesvRfkotgmLddWKIA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return yLIErmCIuZRkesvRfkotgmLddWKIA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class CsSTIwOnUMQVDhiQGVznRTjQeIqm : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

			public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

			private ElementAssignment dWSfaeadGadlhgGcSiEKXzPTeKqk;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

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
			public CsSTIwOnUMQVDhiQGVznRTjQeIqm(int P_0)
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
				ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_0123;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				if (bbJFyfBYztkbqyDKwjcJJfiCvWSr && !controllerMap._enabled)
				{
					return false;
				}
				if (controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
				{
					return false;
				}
				dWSfaeadGadlhgGcSiEKXzPTeKqk = xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.ToElementAssignment();
				PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
				goto IL_0133;
				IL_0133:
				if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh.Count)
				{
					ActionElementMap actionElementMap = controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
					if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementMapId && actionElementMap.CheckForAssignmentConflict(dWSfaeadGadlhgGcSiEKXzPTeKqk))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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
				CsSTIwOnUMQVDhiQGVznRTjQeIqm csSTIwOnUMQVDhiQGVznRTjQeIqm;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					csSTIwOnUMQVDhiQGVznRTjQeIqm = this;
				}
				else
				{
					csSTIwOnUMQVDhiQGVznRTjQeIqm = new CsSTIwOnUMQVDhiQGVznRTjQeIqm(0);
					csSTIwOnUMQVDhiQGVznRTjQeIqm.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				csSTIwOnUMQVDhiQGVznRTjQeIqm.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
				csSTIwOnUMQVDhiQGVznRTjQeIqm.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return csSTIwOnUMQVDhiQGVznRTjQeIqm;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class qEFstUvLhpRoFqDgzLTXzTjAcQiv : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

			public int JVHPuraouxduvcIEzsfWFTjVVggFb;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private IEnumerator<ActionElementMap> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

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
			public qEFstUvLhpRoFqDgzLTXzTjAcQiv(int P_0)
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
					ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = controllerMap.AllMaps.GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					}
					while (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
					{
						ActionElementMap current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
						if (current._actionId == BOmXoDplzfnHtyBjNJvkkPzUlWST && (!bbJFyfBYztkbqyDKwjcJJfiCvWSr || current.KByWFLCBjjvqwXYVZFDfzPdklyjf))
						{
							vjnbYLtrPMftzpjohNfommerCnGo = current;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				qEFstUvLhpRoFqDgzLTXzTjAcQiv qEFstUvLhpRoFqDgzLTXzTjAcQiv2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					qEFstUvLhpRoFqDgzLTXzTjAcQiv2 = this;
				}
				else
				{
					qEFstUvLhpRoFqDgzLTXzTjAcQiv2 = new qEFstUvLhpRoFqDgzLTXzTjAcQiv(0);
					qEFstUvLhpRoFqDgzLTXzTjAcQiv2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				qEFstUvLhpRoFqDgzLTXzTjAcQiv2.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
				qEFstUvLhpRoFqDgzLTXzTjAcQiv2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return qEFstUvLhpRoFqDgzLTXzTjAcQiv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class lhDRwcgAXrqTAafbJjpkivxtwRXOA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private IControllerElementTarget EfoKWqiOCpEGBCMEcnvKzQlxoeDT;

			public IControllerElementTarget wBUHqUNJjoXfWXQdgnymGNNWmNON;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private TempListPool.TList<ActionElementMap> PIMCAjiVsmOjJdjPogxvPFAtYYJsA;

			private List<ActionElementMap>.Enumerator LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

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
			public lhDRwcgAXrqTAafbJjpkivxtwRXOA(int P_0)
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
					ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						PIMCAjiVsmOjJdjPogxvPFAtYYJsA = TempListPool.GetTList<ActionElementMap>();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						List<ActionElementMap> list = PIMCAjiVsmOjJdjPogxvPFAtYYJsA.list;
						controllerMap.wykkVuZXYDRrQxJtgKBZdFoATLny(EfoKWqiOCpEGBCMEcnvKzQlxoeDT, false, -1, bbJFyfBYztkbqyDKwjcJJfiCvWSr, list, false, out var _);
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = list.GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
						break;
					}
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
						break;
					}
					if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
					{
						ActionElementMap current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
						vjnbYLtrPMftzpjohNfommerCnGo = current;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					DZNbUKmveIqGkvckqgFZbMBdZwyW();
					LTEsUPlDRPIUwfjPOBEMaAhKHeOx = default(List<ActionElementMap>.Enumerator);
					MoEEbuduDHenVCeJgyjQicJHJnqHb();
					PIMCAjiVsmOjJdjPogxvPFAtYYJsA = null;
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
				if (PIMCAjiVsmOjJdjPogxvPFAtYYJsA != null)
				{
					((IDisposable)PIMCAjiVsmOjJdjPogxvPFAtYYJsA).Dispose();
				}
			}

			private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
				((IDisposable)LTEsUPlDRPIUwfjPOBEMaAhKHeOx/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				lhDRwcgAXrqTAafbJjpkivxtwRXOA lhDRwcgAXrqTAafbJjpkivxtwRXOA2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					lhDRwcgAXrqTAafbJjpkivxtwRXOA2 = this;
				}
				else
				{
					lhDRwcgAXrqTAafbJjpkivxtwRXOA2 = new lhDRwcgAXrqTAafbJjpkivxtwRXOA(0);
					lhDRwcgAXrqTAafbJjpkivxtwRXOA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				lhDRwcgAXrqTAafbJjpkivxtwRXOA2.EfoKWqiOCpEGBCMEcnvKzQlxoeDT = wBUHqUNJjoXfWXQdgnymGNNWmNON;
				lhDRwcgAXrqTAafbJjpkivxtwRXOA2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return lhDRwcgAXrqTAafbJjpkivxtwRXOA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class TNrDLxkRLmFtpNvQuXpqZpPDaXNeA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private IControllerElementTarget EfoKWqiOCpEGBCMEcnvKzQlxoeDT;

			public IControllerElementTarget wBUHqUNJjoXfWXQdgnymGNNWmNON;

			private int BOmXoDplzfnHtyBjNJvkkPzUlWST;

			public int JVHPuraouxduvcIEzsfWFTjVVggFb;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private TempListPool.TList<ActionElementMap> PIMCAjiVsmOjJdjPogxvPFAtYYJsA;

			private List<ActionElementMap>.Enumerator LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

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
			public TNrDLxkRLmFtpNvQuXpqZpPDaXNeA(int P_0)
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
					ControllerMap controllerMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMap.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						PIMCAjiVsmOjJdjPogxvPFAtYYJsA = TempListPool.GetTList<ActionElementMap>();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						List<ActionElementMap> list = PIMCAjiVsmOjJdjPogxvPFAtYYJsA.list;
						controllerMap.wykkVuZXYDRrQxJtgKBZdFoATLny(EfoKWqiOCpEGBCMEcnvKzQlxoeDT, true, BOmXoDplzfnHtyBjNJvkkPzUlWST, bbJFyfBYztkbqyDKwjcJJfiCvWSr, list, false, out var _);
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = list.GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
						break;
					}
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
						break;
					}
					if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
					{
						ActionElementMap current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
						vjnbYLtrPMftzpjohNfommerCnGo = current;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					DZNbUKmveIqGkvckqgFZbMBdZwyW();
					LTEsUPlDRPIUwfjPOBEMaAhKHeOx = default(List<ActionElementMap>.Enumerator);
					MoEEbuduDHenVCeJgyjQicJHJnqHb();
					PIMCAjiVsmOjJdjPogxvPFAtYYJsA = null;
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
				if (PIMCAjiVsmOjJdjPogxvPFAtYYJsA != null)
				{
					((IDisposable)PIMCAjiVsmOjJdjPogxvPFAtYYJsA).Dispose();
				}
			}

			private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
				((IDisposable)LTEsUPlDRPIUwfjPOBEMaAhKHeOx/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				TNrDLxkRLmFtpNvQuXpqZpPDaXNeA tNrDLxkRLmFtpNvQuXpqZpPDaXNeA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					tNrDLxkRLmFtpNvQuXpqZpPDaXNeA = this;
				}
				else
				{
					tNrDLxkRLmFtpNvQuXpqZpPDaXNeA = new TNrDLxkRLmFtpNvQuXpqZpPDaXNeA(0);
					tNrDLxkRLmFtpNvQuXpqZpPDaXNeA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				tNrDLxkRLmFtpNvQuXpqZpPDaXNeA.EfoKWqiOCpEGBCMEcnvKzQlxoeDT = wBUHqUNJjoXfWXQdgnymGNNWmNON;
				tNrDLxkRLmFtpNvQuXpqZpPDaXNeA.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
				tNrDLxkRLmFtpNvQuXpqZpPDaXNeA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return tNrDLxkRLmFtpNvQuXpqZpPDaXNeA;
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

		internal readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		private readonly AList<ActionElementMap> zopoePGaAzmIvMRuUdmJpJfRCTjh;

		private readonly ReadOnlyCollection<ActionElementMap> zwElWQVXWjJEEWdIWBFuWrfgtqKl;

		private readonly AList<ActionElementMap> MLzDQEBMnVsbwpdaMNieDCSKcrbMc;

		private readonly ReadOnlyCollection<ActionElementMap> QlvPqepwCUbRLvzBlZklkvMEeSVf;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int fxGaXscOVMhDlFhvBlRhBGySeCzCb;

		private static int zDtyNUOEekmtfLkCREvrANjxUWwz
		{
			get
			{
				int result = fxGaXscOVMhDlFhvBlRhBGySeCzCb;
				if (fxGaXscOVMhDlFhvBlRhBGySeCzCb == int.MaxValue)
				{
					fxGaXscOVMhDlFhvBlRhBGySeCzCb = 0;
					return result;
				}
				fxGaXscOVMhDlFhvBlRhBGySeCzCb++;
				return result;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return zopoePGaAzmIvMRuUdmJpJfRCTjh.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return QlvPqepwCUbRLvzBlZklkvMEeSVf;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return QlvPqepwCUbRLvzBlZklkvMEeSVf;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return zwElWQVXWjJEEWdIWBFuWrfgtqKl;
			}
		}

		internal AList<ActionElementMap> UetWStxkTEpvtiiHkgsRzKetHbwDA => zopoePGaAzmIvMRuUdmJpJfRCTjh;

		public ControllerMap()
		{
			_id = zDtyNUOEekmtfLkCREvrANjxUWwz;
			_sourceMapId = -1;
			zopoePGaAzmIvMRuUdmJpJfRCTjh = new AList<ActionElementMap>();
			zwElWQVXWjJEEWdIWBFuWrfgtqKl = new ReadOnlyCollection<ActionElementMap>(zopoePGaAzmIvMRuUdmJpJfRCTjh);
			MLzDQEBMnVsbwpdaMNieDCSKcrbMc = new AList<ActionElementMap>();
			QlvPqepwCUbRLvzBlZklkvMEeSVf = new ReadOnlyCollection<ActionElementMap>(MLzDQEBMnVsbwpdaMNieDCSKcrbMc);
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = zDtyNUOEekmtfLkCREvrANjxUWwz;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			if (P_0.zopoePGaAzmIvMRuUdmJpJfRCTjh != null)
			{
				int count = P_0.zopoePGaAzmIvMRuUdmJpJfRCTjh.Count;
				for (int i = 0; i < count; i++)
				{
					eLIEyCYlZCejkerZvgJWbUVqEaCW(new ActionElementMap(P_0.zopoePGaAzmIvMRuUdmJpJfRCTjh[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			InputAction inputAction = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AtKeaiuZuopusRbNFvrKAbfpRMOD(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			AList<ActionElementMap> mLzDQEBMnVsbwpdaMNieDCSKcrbMc = MLzDQEBMnVsbwpdaMNieDCSKcrbMc;
			for (int i = 0; i < mLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count; i++)
			{
				if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			AList<ActionElementMap> mLzDQEBMnVsbwpdaMNieDCSKcrbMc = MLzDQEBMnVsbwpdaMNieDCSKcrbMc;
			for (int i = 0; i < mLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count; i++)
			{
				if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].keyCode == keyCode && MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> mLzDQEBMnVsbwpdaMNieDCSKcrbMc = MLzDQEBMnVsbwpdaMNieDCSKcrbMc;
			for (int i = 0; i < mLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count; i++)
			{
				if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			AList<ActionElementMap> mLzDQEBMnVsbwpdaMNieDCSKcrbMc = MLzDQEBMnVsbwpdaMNieDCSKcrbMc;
			for (int i = 0; i < mLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count; i++)
			{
				if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, uAOMfTHsnTLbvEUpHTchXYOhMgjh.XLKAHwgEgKUaInaXPLsoBHajZhZyA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.vnEKgLVSpFebRqVrxBMjTwuUqPef(this, actionElementMap);
			eLIEyCYlZCejkerZvgJWbUVqEaCW(actionElementMap);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			WQqLGQywLMLNSSEEpkLCmvqBKOXC wQqLGQywLMLNSSEEpkLCmvqBKOXC = WQqLGQywLMLNSSEEpkLCmvqBKOXC.uknhQfjeaUxvodiETKkZmIhKpMdp(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, wQqLGQywLMLNSSEEpkLCmvqBKOXC.MIxLMWwQJMcJovsdIIGRAmxyypaL, wQqLGQywLMLNSSEEpkLCmvqBKOXC.fxNCAHtdCsJDvWYpfiXMfLfrfXVH, wQqLGQywLMLNSSEEpkLCmvqBKOXC.VNplPFQNgQXLmKziduylcvkLUOiO, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			eLIEyCYlZCejkerZvgJWbUVqEaCW(actionElementMap);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, uAOMfTHsnTLbvEUpHTchXYOhMgjh.XLKAHwgEgKUaInaXPLsoBHajZhZyA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (PZpsnQDdGbkpCpQuVfeBxxjjjjDf(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				eLIEyCYlZCejkerZvgJWbUVqEaCW(elementMap);
			}
			if (PZpsnQDdGbkpCpQuVfeBxxjjjjDf(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.wJjPIIRJfHhEbGedUconecGfiwzgB();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.vnEKgLVSpFebRqVrxBMjTwuUqPef(this, elementMap);
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
			WQqLGQywLMLNSSEEpkLCmvqBKOXC wQqLGQywLMLNSSEEpkLCmvqBKOXC = WQqLGQywLMLNSSEEpkLCmvqBKOXC.uknhQfjeaUxvodiETKkZmIhKpMdp(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, wQqLGQywLMLNSSEEpkLCmvqBKOXC.MIxLMWwQJMcJovsdIIGRAmxyypaL, wQqLGQywLMLNSSEEpkLCmvqBKOXC.fxNCAHtdCsJDvWYpfiXMfLfrfXVH, wQqLGQywLMLNSSEEpkLCmvqBKOXC.VNplPFQNgQXLmKziduylcvkLUOiO, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementType))
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
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				eLIEyCYlZCejkerZvgJWbUVqEaCW(elementMap);
			}
			if (PZpsnQDdGbkpCpQuVfeBxxjjjjDf(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			kgliNvNIGEEbkLKWaeYnFuesrFfgA(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int num = PZpsnQDdGbkpCpQuVfeBxxjjjjDf(elementMapId);
			if (num < 0)
			{
				return false;
			}
			HdssGtSXHKvblTAsgLhHxWikocap(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == elementMapId)
				{
					return zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (!skipDisabledMaps || allMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
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
			return qUjJSbIkSdkiytTMfSCgjDYetnkW(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
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

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return KnhZxXTPhhiXJgFttivQXWIEaevD(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
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

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new qEFstUvLhpRoFqDgzLTXzTjAcQiv(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				JVHPuraouxduvcIEzsfWFTjVVggFb = actionId,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._actionId == actionId && (!skipDisabledMaps || zopoePGaAzmIvMRuUdmJpJfRCTjh[i].KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					return zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
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
			return new lhDRwcgAXrqTAafbJjpkivxtwRXOA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				wBUHqUNJjoXfWXQdgnymGNNWmNON = elementTarget,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
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
			return new TNrDLxkRLmFtpNvQuXpqZpPDaXNeA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				wBUHqUNJjoXfWXQdgnymGNNWmNON = elementTarget,
				JVHPuraouxduvcIEzsfWFTjVVggFb = actionId,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			bool flag;
			return ofPtXzQRTSIwuudhHEmzQTQYglcR(elementTarget, false, -1, skipDisabledMaps, out flag);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			bool flag;
			return ofPtXzQRTSIwuudhHEmzQTQYglcR(elementTarget, true, actionId, skipDisabledMaps, out flag);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			bool flag;
			return wykkVuZXYDRrQxJtgKBZdFoATLny(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			bool flag;
			return wykkVuZXYDRrQxJtgKBZdFoATLny(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
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

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return cfrYXeAFAXObgTDGlHvdlEiYIbwJ(predicate, false);
		}

		internal virtual ActionElementMap cfrYXeAFAXObgTDGlHvdlEiYIbwJ(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return brbFrEhaYYkSaTTMreLrmjHfCNCS(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return QtKbwhWZNaFGzaJhCiMOiZQYYnAz(predicate, false, results, false);
		}

		internal virtual int QtKbwhWZNaFGzaJhCiMOiZQYYnAz(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return LNAHEYvSWCLMcnCHyyfxBQvSRCK(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			int count = MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i];
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			zopoePGaAzmIvMRuUdmJpJfRCTjh.Clear();
			MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			int num = 0;
			int count = MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf != state)
				{
					actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null || index < 0 || index >= zopoePGaAzmIvMRuUdmJpJfRCTjh.Count)
			{
				return null;
			}
			return zopoePGaAzmIvMRuUdmJpJfRCTjh[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(zopoePGaAzmIvMRuUdmJpJfRCTjh);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return npvVteuIuffoqRMqFRTGRbQCTFpX(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AtKeaiuZuopusRbNFvrKAbfpRMOD(actionName, true);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AtKeaiuZuopusRbNFvrKAbfpRMOD(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
				ActionElementMap actionElementMap2 = zopoePGaAzmIvMRuUdmJpJfRCTjh[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			InputAction inputAction = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AtKeaiuZuopusRbNFvrKAbfpRMOD(actionName, true);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			InputAction inputAction = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AtKeaiuZuopusRbNFvrKAbfpRMOD(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return ButtonMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new lvmiNWGYVVFJfqFIRbleZUhMfiVV(-2)
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

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetFirstButtonMapWithAction(actionId);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return brbFrEhaYYkSaTTMreLrmjHfCNCS(predicate, false);
		}

		internal ActionElementMap brbFrEhaYYkSaTTMreLrmjHfCNCS(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return LNAHEYvSWCLMcnCHyyfxBQvSRCK(predicate, false, results, false);
		}

		internal int LNAHEYvSWCLMcnCHyyfxBQvSRCK(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			int count = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
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
			return DeleteButtonMapsWithAction(ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					HdssGtSXHKvblTAsgLhHxWikocap(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			int num = 0;
			int count = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf != state)
				{
					actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf = state;
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (skipDisabledMaps && !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (actionElementMap == null || zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
			{
				return false;
			}
			for (int i = 0; i < zopoePGaAzmIvMRuUdmJpJfRCTjh.Count; i++)
			{
				ActionElementMap actionElementMap2 = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
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
			for (int i = 0; i < zopoePGaAzmIvMRuUdmJpJfRCTjh.Count; i++)
			{
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if ((!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new KIUvmHRaAEZaiQkKkGdJKYThOFwFA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				VjZXfzuBnUHXbbWlMycIUuGPGGJeb = controllerMap,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new YLIErmCIuZRkesvRfkotgmLddWKIA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				PnhRmbULhEBSLPPKimPLlyDMDlCy = actionElementMap,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new CsSTIwOnUMQVDhiQGVznRTjQeIqm(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				kFSVgsWFZyqOFXGOFRPLWNAXMqBB = conflictCheck,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.zopoePGaAzmIvMRuUdmJpJfRCTjh;
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
			for (int num2 = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[num2];
				if (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(list[i]))
						{
							HdssGtSXHKvblTAsgLhHxWikocap(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return num;
			}
			for (int num2 = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = zopoePGaAzmIvMRuUdmJpJfRCTjh[num2];
				if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					HdssGtSXHKvblTAsgLhHxWikocap(actionElementMap2.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
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
			for (int num2 = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[num2];
				if ((!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					HdssGtSXHKvblTAsgLhHxWikocap(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return XnaIBtzabDEqOJGIptytUUvthXus(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return XnaIBtzabDEqOJGIptytUUvthXus(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return XnaIBtzabDEqOJGIptytUUvthXus(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return XnaIBtzabDEqOJGIptytUUvthXus(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return XnaIBtzabDEqOJGIptytUUvthXus(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return XnaIBtzabDEqOJGIptytUUvthXus(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int XnaIBtzabDEqOJGIptytUUvthXus(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return num;
			}
			IList<ActionElementMap> list = P_0.zopoePGaAzmIvMRuUdmJpJfRCTjh;
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (!actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = list[j];
					if ((!P_1 || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int XnaIBtzabDEqOJGIptytUUvthXus(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int XnaIBtzabDEqOJGIptytUUvthXus(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc == null)
			{
				return num;
			}
			IList<ActionElementMap> mLzDQEBMnVsbwpdaMNieDCSKcrbMc = controllerMap.MLzDQEBMnVsbwpdaMNieDCSKcrbMc;
			if (mLzDQEBMnVsbwpdaMNieDCSKcrbMc == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = mLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count;
			for (int num2 = MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = MLzDQEBMnVsbwpdaMNieDCSKcrbMc[num2];
				if (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || mLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(mLzDQEBMnVsbwpdaMNieDCSKcrbMc[i]))
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
			if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc == null)
			{
				return num;
			}
			for (int num2 = MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = MLzDQEBMnVsbwpdaMNieDCSKcrbMc[num2];
				if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc == null)
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
			for (int num2 = MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = MLzDQEBMnVsbwpdaMNieDCSKcrbMc[num2];
				if ((!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				array[i] = zopoePGaAzmIvMRuUdmJpJfRCTjh[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return string.Empty;
			}
			try
			{
				return pMFmgpdCytjWAfCkBRuiiiznUeVd().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return string.Empty;
			}
			try
			{
				return pMFmgpdCytjWAfCkBRuiiiznUeVd().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				OkTaTaYFMOwbkgTtCFcCRyxWNNrJ okTaTaYFMOwbkgTtCFcCRyxWNNrJ = ReInput.vusCEvFeavAPqPHBYxnqdGTgSghv(templateTypeGuid);
				string text = ((okTaTaYFMOwbkgTtCFcCRyxWNNrJ != null) ? okTaTaYFMOwbkgTtCFcCRyxWNNrJ.ssCfdClydnxpavvQUhUhUoUenpUA : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.nJlwCBPYshlANXcZfYzzZmEsfjlW(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if ((object)templateInterfaceType == null)
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
			return ControllerTemplateMap.nJlwCBPYshlANXcZfYzzZmEsfjlW(controllerTemplate, this);
		}

		private ControllerTemplateMap HoROFXslCYKSiKUJIuTwxpLrGkUb(IControllerTemplate P_0)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.nJlwCBPYshlANXcZfYzzZmEsfjlW(P_0, this);
		}

		internal virtual bool BTbXqEjOhhCEMqppIILjeDzBegNdA(ActionElementMap P_0)
		{
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0._elementType))
			{
				return false;
			}
			eLIEyCYlZCejkerZvgJWbUVqEaCW(P_0);
			return true;
		}

		internal virtual int qUjJSbIkSdkiytTMfSCgjDYetnkW(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = zopoePGaAzmIvMRuUdmJpJfRCTjh.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || zopoePGaAzmIvMRuUdmJpJfRCTjh[i].KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					P_0.Add(zopoePGaAzmIvMRuUdmJpJfRCTjh[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap ZlQNMWXGePQbhjItLdrTTmObeJsv(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_2))
			{
				return null;
			}
			int num = BRSYgPNShekAbtuSKviuAFLUdUaJ(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return zopoePGaAzmIvMRuUdmJpJfRCTjh[num];
		}

		internal virtual int oogMArsWTzlTiTtbngheDoEYRUqt(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._elementIdentifierId == P_0)
				{
					P_1.Add(zopoePGaAzmIvMRuUdmJpJfRCTjh[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool qhCTumRebpVbHQKvnVtlUVJlsCTr(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._elementIdentifierId == P_0 && zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int BRSYgPNShekAbtuSKviuAFLUdUaJ(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_2))
			{
				return -1;
			}
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._elementIdentifierId == P_0 && zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int PZpsnQDdGbkpCpQuVfeBxxjjjjDf(int P_0)
		{
			if (zopoePGaAzmIvMRuUdmJpJfRCTjh == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int npvVteuIuffoqRMqFRTGRbQCTFpX(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (!P_0 || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int fkXFnxfPfdgEhcZiQMxLNXJZhSYJA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int KnhZxXTPhhiXJgFttivQXWIEaevD(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap ofPtXzQRTSIwuudhHEmzQTQYglcR(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!ChzveTMmmhcJpEzddZJQNdzjIPqf(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._actionId == P_2) && (!P_3 || zopoePGaAzmIvMRuUdmJpJfRCTjh[i].KByWFLCBjjvqwXYVZFDfzPdklyjf) && zopoePGaAzmIvMRuUdmJpJfRCTjh[i].IsTarget(P_0))
				{
					return zopoePGaAzmIvMRuUdmJpJfRCTjh[i];
				}
			}
			return null;
		}

		internal virtual int wykkVuZXYDRrQxJtgKBZdFoATLny(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!ChzveTMmmhcJpEzddZJQNdzjIPqf(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || zopoePGaAzmIvMRuUdmJpJfRCTjh[i]._actionId == P_2) && (!P_3 || zopoePGaAzmIvMRuUdmJpJfRCTjh[i].KByWFLCBjjvqwXYVZFDfzPdklyjf) && zopoePGaAzmIvMRuUdmJpJfRCTjh[i].IsTarget(P_0))
				{
					P_4.Add(zopoePGaAzmIvMRuUdmJpJfRCTjh[i]);
					num++;
				}
			}
			return num;
		}

		internal void nJqxGslZOByOFqDlBssAtoptIguB(int P_0, ControllerElementType P_1)
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
				hOLSMlXFsuVxuytviQkQgEIwFgJr(elementMap);
			}
		}

		internal virtual bool hOLSMlXFsuVxuytviQkQgEIwFgJr(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0._elementType))
			{
				return false;
			}
			zopoePGaAzmIvMRuUdmJpJfRCTjh.Add(P_0);
			GsCvwpRIyGKPFGmASeRnUQjFtwyl(P_0);
			return true;
		}

		internal bool ChzveTMmmhcJpEzddZJQNdzjIPqf(IControllerElementTarget P_0)
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

		internal bool pupFGbyyCYvRvYlYkoDbgDMrliM(string P_0)
		{
			try
			{
				IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool fneIkVyAwJMkkxAsVVGscjMmUqCN(string P_0)
		{
			try
			{
				IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void GsCvwpRIyGKPFGmASeRnUQjFtwyl(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Add(P_0);
				MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Sort(WTTFJhcfiMsvdcyjHiAZNBUAVfcd.LSiMwhYpzbixHWLRsspDEMspSxKF);
			}
		}

		internal void IXRwpJVZRkCuPAsBMckndrJQjFfO(int P_0)
		{
			int num = CAwDlHIqGUXjXMinURwDLJcwSVUC(P_0);
			if (num >= 0)
			{
				MLzDQEBMnVsbwpdaMNieDCSKcrbMc.RemoveAt(num);
			}
		}

		internal void XIyYClePMtKXAaHjegFnrwBOpaWJ(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = CAwDlHIqGUXjXMinURwDLJcwSVUC(P_0);
				if (num >= 0)
				{
					MLzDQEBMnVsbwpdaMNieDCSKcrbMc[num] = P_1;
					MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Sort(WTTFJhcfiMsvdcyjHiAZNBUAVfcd.LSiMwhYpzbixHWLRsspDEMspSxKF);
				}
			}
		}

		internal static void kgliNvNIGEEbkLKWaeYnFuesrFfgA(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.wJjPIIRJfHhEbGedUconecGfiwzgB();
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
				ReInput.controllers.GetController(_controllerType, _controllerId)?.vnEKgLVSpFebRqVrxBMjTwuUqPef(this, map);
			}
		}

		internal virtual bool IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
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
						actionElementMap.IqWUQdetEUgWKmOIFRihysPfqZgC(value2);
						if (ActionElementMap.iJkboRPqUFYIIceuRqjUryWVRsDe(actionElementMap))
						{
							eLIEyCYlZCejkerZvgJWbUVqEaCW(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void AkUcpXbtGgaSOLgGtBKaSvRfkwYX(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "dataVersion",
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string aNnyYrpgRHgHrBXsbJxMFrsUzupD = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
				{
					uEkKFXXRykNWeZGsmzkXBCXWCSXG = "hardwareGuid",
					ANnyYrpgRHgHrBXsbJxMFrsUzupD = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
				{
					uEkKFXXRykNWeZGsmzkXBCXWCSXG = "hardwareName",
					ANnyYrpgRHgHrBXsbJxMFrsUzupD = aNnyYrpgRHgHrBXsbJxMFrsUzupD
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				KxTTmcDyYaBSfMPvUfdDpAxeKhlL = "xmlns",
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "xsi",
				bQsOsCQXaUMzqJWgNvgeirDgvXAS = null,
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				KxTTmcDyYaBSfMPvUfdDpAxeKhlL = "xsi",
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "schemaLocation",
				bQsOsCQXaUMzqJWgNvgeirDgvXAS = null,
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (zopoePGaAzmIvMRuUdmJpJfRCTjh[i] != null)
				{
					list.Add(zopoePGaAzmIvMRuUdmJpJfRCTjh[i].pMFmgpdCytjWAfCkBRuiiiznUeVd());
				}
			}
		}

		private bool KmnLZLEHrawPjBsbETvFqnhSOYEb(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void HdssGtSXHKvblTAsgLhHxWikocap(int P_0, int P_1)
		{
			IXRwpJVZRkCuPAsBMckndrJQjFfO(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				zopoePGaAzmIvMRuUdmJpJfRCTjh.RemoveAt(P_1);
			}
		}

		private void eLIEyCYlZCejkerZvgJWbUVqEaCW(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				zopoePGaAzmIvMRuUdmJpJfRCTjh.Add(P_0);
				GsCvwpRIyGKPFGmASeRnUQjFtwyl(P_0);
			}
		}

		private void ywgwmbcgsnTdoPzJJVqERMmskiBc(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				XIyYClePMtKXAaHjegFnrwBOpaWJ(zopoePGaAzmIvMRuUdmJpJfRCTjh[P_1].kqvbpTxWGdGtrNRdxLepeZkwTJDn, P_0);
				zopoePGaAzmIvMRuUdmJpJfRCTjh[P_1] = P_0;
			}
		}

		private int CAwDlHIqGUXjXMinURwDLJcwSVUC(int P_0)
		{
			if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc == null)
			{
				return -1;
			}
			int count = MLzDQEBMnVsbwpdaMNieDCSKcrbMc.Count;
			for (int i = 0; i < count; i++)
			{
				if (MLzDQEBMnVsbwpdaMNieDCSKcrbMc[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject pMFmgpdCytjWAfCkBRuiiiznUeVd()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			AkUcpXbtGgaSOLgGtBKaSvRfkwYX(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap VxSNvmooWfTkIVcICGUZnqoUJPDW(ControllerType P_0)
		{
			switch (P_0)
			{
			case ControllerType.Keyboard:
				return new KeyboardMap();
			case ControllerType.Mouse:
				return new MouseMap();
			case ControllerType.Joystick:
				return new JoystickMap();
			case ControllerType.Custom:
				return new CustomControllerMap();
			default:
				throw new NotImplementedException();
			}
		}

		internal static ControllerMap nwnGfJyTiuAlTAipWVNZSlXoRWpgA(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			switch (P_0.type)
			{
			case ControllerType.Keyboard:
				return KeyboardMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(P_0.hardwareTypeGuid, P_1, P_2);
			case ControllerType.Mouse:
				return MouseMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(P_0.hardwareTypeGuid, P_1, P_2);
			case ControllerType.Joystick:
				return JoystickMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(P_0.hardwareTypeGuid, P_1, P_2);
			case ControllerType.Custom:
				return CustomControllerMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2);
			default:
				throw new NotImplementedException();
			}
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = VxSNvmooWfTkIVcICGUZnqoUJPDW(controllerType);
			try
			{
				controllerMap.pupFGbyyCYvRvYlYkoDbgDMrliM(xmlString);
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
			ControllerMap controllerMap = VxSNvmooWfTkIVcICGUZnqoUJPDW(controllerType);
			try
			{
				controllerMap.fneIkVyAwJMkkxAsVVGscjMmUqCN(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
