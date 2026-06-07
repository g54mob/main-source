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
		private class FLrcWuXQukeHZbPdxGGGBCZcoWtdb : IComparer<ActionElementMap>
		{
			public static FLrcWuXQukeHZbPdxGGGBCZcoWtdb UcvytOLWzzYyqOrXfNUgqFpFTCcF;

			public static FLrcWuXQukeHZbPdxGGGBCZcoWtdb LlAHqyETvFFiJWluDkklCcpSFDYN => UcvytOLWzzYyqOrXfNUgqFpFTCcF ?? (UcvytOLWzzYyqOrXfNUgqFpFTCcF = new FLrcWuXQukeHZbPdxGGGBCZcoWtdb());

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

		private sealed class DkezfUOOLSiNHlrMxLqmFHLmgIHn : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int eUsAUNfsniqBjZxDynGzwubdBYVZ;

			private ActionElementMap UKhMAiJDRIVPKewkLVpVwBGiiHtM;

			private int ucDzWuGFevUrsuPxOATtXWFeYsuG;

			public ControllerMap UAyXnuvRJlNWOnTRAqkqztjlSKlb;

			private int HgNkRtjnAtOCUiItQytCBuWnPTnL;

			public int ovAwtyfzqTEttcmzbyIGUOeRHwDr;

			private bool cKOFFZBBPWOpmRDSVgDHVPnlcSoRA;

			public bool awdETPsCGXtnPbkYJNHBPKCWdsIJA;

			private IList<ActionElementMap> QnMcUNUBujDTKMmTztXsRnJmjqAi;

			private int FFdFaRQyPtMmHsUFjVbItBoDgLBcA;

			private int HigXedYHxpkyvVsQFPoDDyCostMd;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return UKhMAiJDRIVPKewkLVpVwBGiiHtM;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UKhMAiJDRIVPKewkLVpVwBGiiHtM;
				}
			}

			[DebuggerHidden]
			public DkezfUOOLSiNHlrMxLqmFHLmgIHn(int P_0)
			{
				eUsAUNfsniqBjZxDynGzwubdBYVZ = P_0;
				ucDzWuGFevUrsuPxOATtXWFeYsuG = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				QnMcUNUBujDTKMmTztXsRnJmjqAi = null;
				eUsAUNfsniqBjZxDynGzwubdBYVZ = -2;
			}

			private bool MoveNext()
			{
				int num = eUsAUNfsniqBjZxDynGzwubdBYVZ;
				ControllerMap uAyXnuvRJlNWOnTRAqkqztjlSKlb = UAyXnuvRJlNWOnTRAqkqztjlSKlb;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					eUsAUNfsniqBjZxDynGzwubdBYVZ = -1;
					goto IL_00af;
				}
				eUsAUNfsniqBjZxDynGzwubdBYVZ = -1;
				if (ReInput._id != uAyXnuvRJlNWOnTRAqkqztjlSKlb.eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(uAyXnuvRJlNWOnTRAqkqztjlSKlb.eVbcYJFeNpDqytUEinVYaObkrqXt);
					return false;
				}
				if (HgNkRtjnAtOCUiItQytCBuWnPTnL < 0)
				{
					return false;
				}
				QnMcUNUBujDTKMmTztXsRnJmjqAi = uAyXnuvRJlNWOnTRAqkqztjlSKlb.ButtonMaps;
				FFdFaRQyPtMmHsUFjVbItBoDgLBcA = uAyXnuvRJlNWOnTRAqkqztjlSKlb.buttonMapCount;
				HigXedYHxpkyvVsQFPoDDyCostMd = 0;
				goto IL_00bf;
				IL_00bf:
				if (HigXedYHxpkyvVsQFPoDDyCostMd < FFdFaRQyPtMmHsUFjVbItBoDgLBcA)
				{
					ActionElementMap actionElementMap = QnMcUNUBujDTKMmTztXsRnJmjqAi[HigXedYHxpkyvVsQFPoDDyCostMd];
					if (actionElementMap._actionId == HgNkRtjnAtOCUiItQytCBuWnPTnL && (!cKOFFZBBPWOpmRDSVgDHVPnlcSoRA || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
					{
						UKhMAiJDRIVPKewkLVpVwBGiiHtM = actionElementMap;
						eUsAUNfsniqBjZxDynGzwubdBYVZ = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				HigXedYHxpkyvVsQFPoDDyCostMd++;
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
				DkezfUOOLSiNHlrMxLqmFHLmgIHn dkezfUOOLSiNHlrMxLqmFHLmgIHn;
				if (eUsAUNfsniqBjZxDynGzwubdBYVZ == -2 && ucDzWuGFevUrsuPxOATtXWFeYsuG == Environment.CurrentManagedThreadId)
				{
					eUsAUNfsniqBjZxDynGzwubdBYVZ = 0;
					dkezfUOOLSiNHlrMxLqmFHLmgIHn = this;
				}
				else
				{
					dkezfUOOLSiNHlrMxLqmFHLmgIHn = new DkezfUOOLSiNHlrMxLqmFHLmgIHn(0);
					dkezfUOOLSiNHlrMxLqmFHLmgIHn.UAyXnuvRJlNWOnTRAqkqztjlSKlb = UAyXnuvRJlNWOnTRAqkqztjlSKlb;
				}
				dkezfUOOLSiNHlrMxLqmFHLmgIHn.HgNkRtjnAtOCUiItQytCBuWnPTnL = ovAwtyfzqTEttcmzbyIGUOeRHwDr;
				dkezfUOOLSiNHlrMxLqmFHLmgIHn.cKOFFZBBPWOpmRDSVgDHVPnlcSoRA = awdETPsCGXtnPbkYJNHBPKCWdsIJA;
				return dkezfUOOLSiNHlrMxLqmFHLmgIHn;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class KsVkPEWCjcIZpoXQqItaRrKswcfO : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int bZtsjtRzKGohyGQfOtbsbOiyaYjb;

			private ElementAssignmentConflictInfo HgiGuMmSxbmQnOyNfGhlvFPVwWVl;

			private int RCuhxHoeqPQKJccYtPBZKtEYUsyD;

			public ControllerMap HtptqrarXZURdlBVlRFuHBBwffUq;

			private ControllerMap ichRTrRGxTDBFjwWrtLpLnFeOqwA;

			public ControllerMap zIMCfLUBPOgxlcDDjBuTtdYseULf;

			private bool YKpZMtcDEexZivLMNvNijtQngJtq;

			public bool HOXVRtzMoToEbDXGTtEZUOOrhpicA;

			private IList<ActionElementMap> NkraLeJIDaRalrKwhLFisPeEjidIb;

			private int ApIHMhfbUDgUwjlTiHVZoebscYtiA;

			private int NPLYoNITiftnNayriDeDCICSniai;

			private ActionElementMap JcVBwRgnDZlpauBpWjAXnIPOMzzxA;

			private int JEGxmnYIrQRoCDTrfnCXammcaWaFA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return HgiGuMmSxbmQnOyNfGhlvFPVwWVl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return HgiGuMmSxbmQnOyNfGhlvFPVwWVl;
				}
			}

			[DebuggerHidden]
			public KsVkPEWCjcIZpoXQqItaRrKswcfO(int P_0)
			{
				bZtsjtRzKGohyGQfOtbsbOiyaYjb = P_0;
				RCuhxHoeqPQKJccYtPBZKtEYUsyD = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				NkraLeJIDaRalrKwhLFisPeEjidIb = null;
				JcVBwRgnDZlpauBpWjAXnIPOMzzxA = null;
				bZtsjtRzKGohyGQfOtbsbOiyaYjb = -2;
			}

			private bool MoveNext()
			{
				int num = bZtsjtRzKGohyGQfOtbsbOiyaYjb;
				ControllerMap htptqrarXZURdlBVlRFuHBBwffUq = HtptqrarXZURdlBVlRFuHBBwffUq;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					bZtsjtRzKGohyGQfOtbsbOiyaYjb = -1;
					goto IL_019c;
				}
				bZtsjtRzKGohyGQfOtbsbOiyaYjb = -1;
				if (ReInput._id != htptqrarXZURdlBVlRFuHBBwffUq.eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(htptqrarXZURdlBVlRFuHBBwffUq.eVbcYJFeNpDqytUEinVYaObkrqXt);
					return false;
				}
				if (ichRTrRGxTDBFjwWrtLpLnFeOqwA == null || htptqrarXZURdlBVlRFuHBBwffUq.SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
				{
					return false;
				}
				if (YKpZMtcDEexZivLMNvNijtQngJtq && (!htptqrarXZURdlBVlRFuHBBwffUq._enabled || !ichRTrRGxTDBFjwWrtLpLnFeOqwA._enabled))
				{
					return false;
				}
				NkraLeJIDaRalrKwhLFisPeEjidIb = ichRTrRGxTDBFjwWrtLpLnFeOqwA.ButtonMaps;
				if (NkraLeJIDaRalrKwhLFisPeEjidIb == null)
				{
					return false;
				}
				ApIHMhfbUDgUwjlTiHVZoebscYtiA = NkraLeJIDaRalrKwhLFisPeEjidIb.Count;
				NPLYoNITiftnNayriDeDCICSniai = 0;
				goto IL_01d4;
				IL_01d4:
				if (NPLYoNITiftnNayriDeDCICSniai < htptqrarXZURdlBVlRFuHBBwffUq.SuKJYfOmUVLUdVwLfktWyYifxJBd.Count)
				{
					JcVBwRgnDZlpauBpWjAXnIPOMzzxA = htptqrarXZURdlBVlRFuHBBwffUq.SuKJYfOmUVLUdVwLfktWyYifxJBd[NPLYoNITiftnNayriDeDCICSniai];
					if (!YKpZMtcDEexZivLMNvNijtQngJtq || JcVBwRgnDZlpauBpWjAXnIPOMzzxA.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
					{
						JEGxmnYIrQRoCDTrfnCXammcaWaFA = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (JEGxmnYIrQRoCDTrfnCXammcaWaFA < ApIHMhfbUDgUwjlTiHVZoebscYtiA)
				{
					ActionElementMap actionElementMap = NkraLeJIDaRalrKwhLFisPeEjidIb[JEGxmnYIrQRoCDTrfnCXammcaWaFA];
					if ((!YKpZMtcDEexZivLMNvNijtQngJtq || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && JcVBwRgnDZlpauBpWjAXnIPOMzzxA.CheckForAssignmentConflict(actionElementMap))
					{
						HgiGuMmSxbmQnOyNfGhlvFPVwWVl = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(htptqrarXZURdlBVlRFuHBBwffUq._categoryId).userAssignable, -1, htptqrarXZURdlBVlRFuHBBwffUq._controllerType, htptqrarXZURdlBVlRFuHBBwffUq._controllerId, htptqrarXZURdlBVlRFuHBBwffUq._id, JcVBwRgnDZlpauBpWjAXnIPOMzzxA.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, JcVBwRgnDZlpauBpWjAXnIPOMzzxA._actionId, JcVBwRgnDZlpauBpWjAXnIPOMzzxA._elementType, JcVBwRgnDZlpauBpWjAXnIPOMzzxA._elementIdentifierId, JcVBwRgnDZlpauBpWjAXnIPOMzzxA.keyCode, JcVBwRgnDZlpauBpWjAXnIPOMzzxA.modifierKeyFlags);
						bZtsjtRzKGohyGQfOtbsbOiyaYjb = 1;
						return true;
					}
					goto IL_019c;
				}
				JcVBwRgnDZlpauBpWjAXnIPOMzzxA = null;
				goto IL_01c4;
				IL_01c4:
				NPLYoNITiftnNayriDeDCICSniai++;
				goto IL_01d4;
				IL_019c:
				JEGxmnYIrQRoCDTrfnCXammcaWaFA++;
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
				KsVkPEWCjcIZpoXQqItaRrKswcfO ksVkPEWCjcIZpoXQqItaRrKswcfO;
				if (bZtsjtRzKGohyGQfOtbsbOiyaYjb == -2 && RCuhxHoeqPQKJccYtPBZKtEYUsyD == Environment.CurrentManagedThreadId)
				{
					bZtsjtRzKGohyGQfOtbsbOiyaYjb = 0;
					ksVkPEWCjcIZpoXQqItaRrKswcfO = this;
				}
				else
				{
					ksVkPEWCjcIZpoXQqItaRrKswcfO = new KsVkPEWCjcIZpoXQqItaRrKswcfO(0);
					ksVkPEWCjcIZpoXQqItaRrKswcfO.HtptqrarXZURdlBVlRFuHBBwffUq = HtptqrarXZURdlBVlRFuHBBwffUq;
				}
				ksVkPEWCjcIZpoXQqItaRrKswcfO.ichRTrRGxTDBFjwWrtLpLnFeOqwA = zIMCfLUBPOgxlcDDjBuTtdYseULf;
				ksVkPEWCjcIZpoXQqItaRrKswcfO.YKpZMtcDEexZivLMNvNijtQngJtq = HOXVRtzMoToEbDXGTtEZUOOrhpicA;
				return ksVkPEWCjcIZpoXQqItaRrKswcfO;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class LHFBMIlSCZHrzPfcdpWgDuRkpZeH : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int DzrNbinNvVjtZSPQuZFoyKiNjvuGA;

			private ElementAssignmentConflictInfo lUAPJlqJMyKfLZXrXnqSxotwmhTw;

			private int IufkHcDdFqfDBVaGLBgdilBwpWJQA;

			public ControllerMap uYYGBTDmpKckpWOnInivJcZIcLAUA;

			private ActionElementMap JCZzjPisokrRSPJxkDWJrsuNBZhI;

			public ActionElementMap ZvNLdpGonOEzHqEMstrdQKASFAEP;

			private bool dUYYoKWieOiYiFXHHgSeszsyCPaAA;

			public bool oEmrMIppFUBHzNLxpApppzFzULjo;

			private int rSjhTiYGVkDmWjiTZwleLOkuBOalA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return lUAPJlqJMyKfLZXrXnqSxotwmhTw;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return lUAPJlqJMyKfLZXrXnqSxotwmhTw;
				}
			}

			[DebuggerHidden]
			public LHFBMIlSCZHrzPfcdpWgDuRkpZeH(int P_0)
			{
				DzrNbinNvVjtZSPQuZFoyKiNjvuGA = P_0;
				IufkHcDdFqfDBVaGLBgdilBwpWJQA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				DzrNbinNvVjtZSPQuZFoyKiNjvuGA = -2;
			}

			private bool MoveNext()
			{
				int dzrNbinNvVjtZSPQuZFoyKiNjvuGA = DzrNbinNvVjtZSPQuZFoyKiNjvuGA;
				ControllerMap controllerMap = uYYGBTDmpKckpWOnInivJcZIcLAUA;
				if (dzrNbinNvVjtZSPQuZFoyKiNjvuGA != 0)
				{
					if (dzrNbinNvVjtZSPQuZFoyKiNjvuGA != 1)
					{
						return false;
					}
					DzrNbinNvVjtZSPQuZFoyKiNjvuGA = -1;
					goto IL_0111;
				}
				DzrNbinNvVjtZSPQuZFoyKiNjvuGA = -1;
				if (ReInput._id != controllerMap.eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(controllerMap.eVbcYJFeNpDqytUEinVYaObkrqXt);
					return false;
				}
				if (JCZzjPisokrRSPJxkDWJrsuNBZhI == null || controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
				{
					return false;
				}
				if (dUYYoKWieOiYiFXHHgSeszsyCPaAA && (!controllerMap._enabled || !JCZzjPisokrRSPJxkDWJrsuNBZhI.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					return false;
				}
				rSjhTiYGVkDmWjiTZwleLOkuBOalA = 0;
				goto IL_0121;
				IL_0111:
				rSjhTiYGVkDmWjiTZwleLOkuBOalA++;
				goto IL_0121;
				IL_0121:
				if (rSjhTiYGVkDmWjiTZwleLOkuBOalA < controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd.Count)
				{
					ActionElementMap actionElementMap = controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd[rSjhTiYGVkDmWjiTZwleLOkuBOalA];
					if ((!dUYYoKWieOiYiFXHHgSeszsyCPaAA || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(JCZzjPisokrRSPJxkDWJrsuNBZhI))
					{
						lUAPJlqJMyKfLZXrXnqSxotwmhTw = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						DzrNbinNvVjtZSPQuZFoyKiNjvuGA = 1;
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
				LHFBMIlSCZHrzPfcdpWgDuRkpZeH lHFBMIlSCZHrzPfcdpWgDuRkpZeH;
				if (DzrNbinNvVjtZSPQuZFoyKiNjvuGA == -2 && IufkHcDdFqfDBVaGLBgdilBwpWJQA == Environment.CurrentManagedThreadId)
				{
					DzrNbinNvVjtZSPQuZFoyKiNjvuGA = 0;
					lHFBMIlSCZHrzPfcdpWgDuRkpZeH = this;
				}
				else
				{
					lHFBMIlSCZHrzPfcdpWgDuRkpZeH = new LHFBMIlSCZHrzPfcdpWgDuRkpZeH(0);
					lHFBMIlSCZHrzPfcdpWgDuRkpZeH.uYYGBTDmpKckpWOnInivJcZIcLAUA = uYYGBTDmpKckpWOnInivJcZIcLAUA;
				}
				lHFBMIlSCZHrzPfcdpWgDuRkpZeH.JCZzjPisokrRSPJxkDWJrsuNBZhI = ZvNLdpGonOEzHqEMstrdQKASFAEP;
				lHFBMIlSCZHrzPfcdpWgDuRkpZeH.dUYYoKWieOiYiFXHHgSeszsyCPaAA = oEmrMIppFUBHzNLxpApppzFzULjo;
				return lHFBMIlSCZHrzPfcdpWgDuRkpZeH;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class bWlIrllZodEzFunpyBfTzBEzxIyD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int gxzkbebcxUnATFEiKRrqCaiuAECI;

			private ElementAssignmentConflictInfo tcHaSnXUXyMrcgxqbnFAKTkVshke;

			private int LPRCNBgBJeWGrGtvPldniNICLItdA;

			public ControllerMap ajuOJCVYIPkzBKFJoHqsQvZPosGr;

			private bool GYLSkdlqZSFsmAUJWXuqienwYihD;

			public bool bfscMDaHXNjQudomEBWYwgbTbkKCA;

			private ElementAssignmentConflictCheck YPSpVIbMvlulspGtDcTHewkjXvNaA;

			public ElementAssignmentConflictCheck krGhnlSZmlJUttVzomjbdunUvjYt;

			private ElementAssignment GtszRpWMAGYXSwJUWLptwdaedFNEA;

			private int ediWlpSNcPONbQsbwYjaCpmtUDMb;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return tcHaSnXUXyMrcgxqbnFAKTkVshke;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tcHaSnXUXyMrcgxqbnFAKTkVshke;
				}
			}

			[DebuggerHidden]
			public bWlIrllZodEzFunpyBfTzBEzxIyD(int P_0)
			{
				gxzkbebcxUnATFEiKRrqCaiuAECI = P_0;
				LPRCNBgBJeWGrGtvPldniNICLItdA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				gxzkbebcxUnATFEiKRrqCaiuAECI = -2;
			}

			private bool MoveNext()
			{
				int num = gxzkbebcxUnATFEiKRrqCaiuAECI;
				ControllerMap controllerMap = ajuOJCVYIPkzBKFJoHqsQvZPosGr;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					gxzkbebcxUnATFEiKRrqCaiuAECI = -1;
					goto IL_0123;
				}
				gxzkbebcxUnATFEiKRrqCaiuAECI = -1;
				if (ReInput._id != controllerMap.eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(controllerMap.eVbcYJFeNpDqytUEinVYaObkrqXt);
					return false;
				}
				if (GYLSkdlqZSFsmAUJWXuqienwYihD && !controllerMap._enabled)
				{
					return false;
				}
				if (controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
				{
					return false;
				}
				GtszRpWMAGYXSwJUWLptwdaedFNEA = YPSpVIbMvlulspGtDcTHewkjXvNaA.ToElementAssignment();
				ediWlpSNcPONbQsbwYjaCpmtUDMb = 0;
				goto IL_0133;
				IL_0133:
				if (ediWlpSNcPONbQsbwYjaCpmtUDMb < controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd.Count)
				{
					ActionElementMap actionElementMap = controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd[ediWlpSNcPONbQsbwYjaCpmtUDMb];
					if ((!GYLSkdlqZSFsmAUJWXuqienwYihD || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != YPSpVIbMvlulspGtDcTHewkjXvNaA.elementMapId && actionElementMap.CheckForAssignmentConflict(GtszRpWMAGYXSwJUWLptwdaedFNEA))
					{
						tcHaSnXUXyMrcgxqbnFAKTkVshke = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						gxzkbebcxUnATFEiKRrqCaiuAECI = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				ediWlpSNcPONbQsbwYjaCpmtUDMb++;
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
				bWlIrllZodEzFunpyBfTzBEzxIyD bWlIrllZodEzFunpyBfTzBEzxIyD2;
				if (gxzkbebcxUnATFEiKRrqCaiuAECI == -2 && LPRCNBgBJeWGrGtvPldniNICLItdA == Environment.CurrentManagedThreadId)
				{
					gxzkbebcxUnATFEiKRrqCaiuAECI = 0;
					bWlIrllZodEzFunpyBfTzBEzxIyD2 = this;
				}
				else
				{
					bWlIrllZodEzFunpyBfTzBEzxIyD2 = new bWlIrllZodEzFunpyBfTzBEzxIyD(0);
					bWlIrllZodEzFunpyBfTzBEzxIyD2.ajuOJCVYIPkzBKFJoHqsQvZPosGr = ajuOJCVYIPkzBKFJoHqsQvZPosGr;
				}
				bWlIrllZodEzFunpyBfTzBEzxIyD2.YPSpVIbMvlulspGtDcTHewkjXvNaA = krGhnlSZmlJUttVzomjbdunUvjYt;
				bWlIrllZodEzFunpyBfTzBEzxIyD2.GYLSkdlqZSFsmAUJWXuqienwYihD = bfscMDaHXNjQudomEBWYwgbTbkKCA;
				return bWlIrllZodEzFunpyBfTzBEzxIyD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class DtvOlJbDyKOYBuvDMWVhMHUjesYU : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int maSQsrxLtrrKyzrCGFEWexbVArbf;

			private ActionElementMap UIubVqTtpoJUBqnLcISdzknzFxtg;

			private int ptNhDIhNtVcwEaUJRoFTpPsOzMTi;

			public ControllerMap NIgnWIvvmlUrFsgQFYpXNPmAlalJ;

			private int dvsELYVOJByTvDyzvEAMNclDvmDl;

			public int lWcdAxBccLHCuFGvPGXmXKyKfVvO;

			private bool qACIGvbnihDiwEOMEyluHjTLoZRr;

			public bool PjsVYmyUNDRNmVDCyjuieypyPiPN;

			private IEnumerator<ActionElementMap> YTfDFshuurDDEFlETyINAucjDZMt;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return UIubVqTtpoJUBqnLcISdzknzFxtg;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UIubVqTtpoJUBqnLcISdzknzFxtg;
				}
			}

			[DebuggerHidden]
			public DtvOlJbDyKOYBuvDMWVhMHUjesYU(int P_0)
			{
				maSQsrxLtrrKyzrCGFEWexbVArbf = P_0;
				ptNhDIhNtVcwEaUJRoFTpPsOzMTi = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = maSQsrxLtrrKyzrCGFEWexbVArbf;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						rsaKCLypIHefJCDmxevTdyoAAzCI();
					}
				}
				YTfDFshuurDDEFlETyINAucjDZMt = null;
				maSQsrxLtrrKyzrCGFEWexbVArbf = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = maSQsrxLtrrKyzrCGFEWexbVArbf;
					ControllerMap nIgnWIvvmlUrFsgQFYpXNPmAlalJ = NIgnWIvvmlUrFsgQFYpXNPmAlalJ;
					switch (num)
					{
					default:
						return false;
					case 0:
						maSQsrxLtrrKyzrCGFEWexbVArbf = -1;
						if (ReInput._id != nIgnWIvvmlUrFsgQFYpXNPmAlalJ.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(nIgnWIvvmlUrFsgQFYpXNPmAlalJ.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						YTfDFshuurDDEFlETyINAucjDZMt = nIgnWIvvmlUrFsgQFYpXNPmAlalJ.AllMaps.GetEnumerator();
						maSQsrxLtrrKyzrCGFEWexbVArbf = -3;
						break;
					case 1:
						maSQsrxLtrrKyzrCGFEWexbVArbf = -3;
						break;
					}
					while (YTfDFshuurDDEFlETyINAucjDZMt.MoveNext())
					{
						ActionElementMap current = YTfDFshuurDDEFlETyINAucjDZMt.Current;
						if (current._actionId == dvsELYVOJByTvDyzvEAMNclDvmDl && (!qACIGvbnihDiwEOMEyluHjTLoZRr || current.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
						{
							UIubVqTtpoJUBqnLcISdzknzFxtg = current;
							maSQsrxLtrrKyzrCGFEWexbVArbf = 1;
							return true;
						}
					}
					rsaKCLypIHefJCDmxevTdyoAAzCI();
					YTfDFshuurDDEFlETyINAucjDZMt = null;
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

			private void rsaKCLypIHefJCDmxevTdyoAAzCI()
			{
				maSQsrxLtrrKyzrCGFEWexbVArbf = -1;
				if (YTfDFshuurDDEFlETyINAucjDZMt != null)
				{
					YTfDFshuurDDEFlETyINAucjDZMt.Dispose();
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
				DtvOlJbDyKOYBuvDMWVhMHUjesYU dtvOlJbDyKOYBuvDMWVhMHUjesYU;
				if (maSQsrxLtrrKyzrCGFEWexbVArbf == -2 && ptNhDIhNtVcwEaUJRoFTpPsOzMTi == Environment.CurrentManagedThreadId)
				{
					maSQsrxLtrrKyzrCGFEWexbVArbf = 0;
					dtvOlJbDyKOYBuvDMWVhMHUjesYU = this;
				}
				else
				{
					dtvOlJbDyKOYBuvDMWVhMHUjesYU = new DtvOlJbDyKOYBuvDMWVhMHUjesYU(0);
					dtvOlJbDyKOYBuvDMWVhMHUjesYU.NIgnWIvvmlUrFsgQFYpXNPmAlalJ = NIgnWIvvmlUrFsgQFYpXNPmAlalJ;
				}
				dtvOlJbDyKOYBuvDMWVhMHUjesYU.dvsELYVOJByTvDyzvEAMNclDvmDl = lWcdAxBccLHCuFGvPGXmXKyKfVvO;
				dtvOlJbDyKOYBuvDMWVhMHUjesYU.qACIGvbnihDiwEOMEyluHjTLoZRr = PjsVYmyUNDRNmVDCyjuieypyPiPN;
				return dtvOlJbDyKOYBuvDMWVhMHUjesYU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class JeDLhhuPSTrDYsgVJTjEIlpHZsUL : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int XfkyTPjtqjEVTxkpuuSGuJblzpQX;

			private ActionElementMap OsJifrPSXdbeikRtsgronQBbwwZp;

			private int KcHdYBXXSQaUFpzhwpiCnvPucPhk;

			public ControllerMap TDDALHnnEPYTiNcfkKyGvGKpoSdY;

			private IControllerElementTarget YSxwzIdSKiRAnrieEhSZFTRlNzLtA;

			public IControllerElementTarget xJHBDBgwUNSVxBKfLGQiOlNdhHvmA;

			private bool xVsRtilhHadIkmrCpZmMNEsXKirP;

			public bool ayaQZSqWubsrKIsohfgOacpIwImy;

			private TempListPool.TList<ActionElementMap> aInkYFeMsuCMSmSsRvhOkUSQdVMd;

			private List<ActionElementMap>.Enumerator ljpUEIHjegTVCQnQHbjulTBVhszh;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return OsJifrPSXdbeikRtsgronQBbwwZp;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return OsJifrPSXdbeikRtsgronQBbwwZp;
				}
			}

			[DebuggerHidden]
			public JeDLhhuPSTrDYsgVJTjEIlpHZsUL(int P_0)
			{
				XfkyTPjtqjEVTxkpuuSGuJblzpQX = P_0;
				KcHdYBXXSQaUFpzhwpiCnvPucPhk = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int xfkyTPjtqjEVTxkpuuSGuJblzpQX = XfkyTPjtqjEVTxkpuuSGuJblzpQX;
				if ((uint)(xfkyTPjtqjEVTxkpuuSGuJblzpQX - -4) <= 1u || xfkyTPjtqjEVTxkpuuSGuJblzpQX == 1)
				{
					try
					{
						if (xfkyTPjtqjEVTxkpuuSGuJblzpQX == -4 || xfkyTPjtqjEVTxkpuuSGuJblzpQX == 1)
						{
							try
							{
							}
							finally
							{
								goRLFfiqvExHHPKoJduptmFETYaF();
							}
						}
					}
					finally
					{
						ztRHumGPLDQNUHqdvhEQaRYzvWiKA();
					}
				}
				aInkYFeMsuCMSmSsRvhOkUSQdVMd = null;
				ljpUEIHjegTVCQnQHbjulTBVhszh = default(List<ActionElementMap>.Enumerator);
				XfkyTPjtqjEVTxkpuuSGuJblzpQX = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int xfkyTPjtqjEVTxkpuuSGuJblzpQX = XfkyTPjtqjEVTxkpuuSGuJblzpQX;
					ControllerMap tDDALHnnEPYTiNcfkKyGvGKpoSdY = TDDALHnnEPYTiNcfkKyGvGKpoSdY;
					switch (xfkyTPjtqjEVTxkpuuSGuJblzpQX)
					{
					default:
						return false;
					case 0:
					{
						XfkyTPjtqjEVTxkpuuSGuJblzpQX = -1;
						if (ReInput._id != tDDALHnnEPYTiNcfkKyGvGKpoSdY.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(tDDALHnnEPYTiNcfkKyGvGKpoSdY.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						aInkYFeMsuCMSmSsRvhOkUSQdVMd = TempListPool.GetTList<ActionElementMap>();
						XfkyTPjtqjEVTxkpuuSGuJblzpQX = -3;
						List<ActionElementMap> list = aInkYFeMsuCMSmSsRvhOkUSQdVMd.list;
						tDDALHnnEPYTiNcfkKyGvGKpoSdY.xVXvATEIJOyARtowfnOzbVGdtuAe(YSxwzIdSKiRAnrieEhSZFTRlNzLtA, false, -1, xVsRtilhHadIkmrCpZmMNEsXKirP, list, false, out var _);
						ljpUEIHjegTVCQnQHbjulTBVhszh = list.GetEnumerator();
						XfkyTPjtqjEVTxkpuuSGuJblzpQX = -4;
						break;
					}
					case 1:
						XfkyTPjtqjEVTxkpuuSGuJblzpQX = -4;
						break;
					}
					if (ljpUEIHjegTVCQnQHbjulTBVhszh.MoveNext())
					{
						ActionElementMap current = ljpUEIHjegTVCQnQHbjulTBVhszh.Current;
						OsJifrPSXdbeikRtsgronQBbwwZp = current;
						XfkyTPjtqjEVTxkpuuSGuJblzpQX = 1;
						return true;
					}
					goRLFfiqvExHHPKoJduptmFETYaF();
					ljpUEIHjegTVCQnQHbjulTBVhszh = default(List<ActionElementMap>.Enumerator);
					ztRHumGPLDQNUHqdvhEQaRYzvWiKA();
					aInkYFeMsuCMSmSsRvhOkUSQdVMd = null;
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

			private void ztRHumGPLDQNUHqdvhEQaRYzvWiKA()
			{
				XfkyTPjtqjEVTxkpuuSGuJblzpQX = -1;
				if (aInkYFeMsuCMSmSsRvhOkUSQdVMd != null)
				{
					((IDisposable)aInkYFeMsuCMSmSsRvhOkUSQdVMd).Dispose();
				}
			}

			private void goRLFfiqvExHHPKoJduptmFETYaF()
			{
				XfkyTPjtqjEVTxkpuuSGuJblzpQX = -3;
				((IDisposable)ljpUEIHjegTVCQnQHbjulTBVhszh/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				JeDLhhuPSTrDYsgVJTjEIlpHZsUL jeDLhhuPSTrDYsgVJTjEIlpHZsUL;
				if (XfkyTPjtqjEVTxkpuuSGuJblzpQX == -2 && KcHdYBXXSQaUFpzhwpiCnvPucPhk == Environment.CurrentManagedThreadId)
				{
					XfkyTPjtqjEVTxkpuuSGuJblzpQX = 0;
					jeDLhhuPSTrDYsgVJTjEIlpHZsUL = this;
				}
				else
				{
					jeDLhhuPSTrDYsgVJTjEIlpHZsUL = new JeDLhhuPSTrDYsgVJTjEIlpHZsUL(0);
					jeDLhhuPSTrDYsgVJTjEIlpHZsUL.TDDALHnnEPYTiNcfkKyGvGKpoSdY = TDDALHnnEPYTiNcfkKyGvGKpoSdY;
				}
				jeDLhhuPSTrDYsgVJTjEIlpHZsUL.YSxwzIdSKiRAnrieEhSZFTRlNzLtA = xJHBDBgwUNSVxBKfLGQiOlNdhHvmA;
				jeDLhhuPSTrDYsgVJTjEIlpHZsUL.xVsRtilhHadIkmrCpZmMNEsXKirP = ayaQZSqWubsrKIsohfgOacpIwImy;
				return jeDLhhuPSTrDYsgVJTjEIlpHZsUL;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class htOdkJcKPoUQVFKRRzFoJsFyKbgE : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int zlPiSRdFrffGmwxGfLfJUTYtUKbL;

			private ActionElementMap eBQfIwJPkJNulijzFXWjVEGNIKdkA;

			private int FpupqFAWdlZMhoMKjsQBOPbEeTig;

			public ControllerMap OOylnEfTcZXGqsMiqFClXBaxWkQH;

			private IControllerElementTarget OaLsQvXhjuWiVSUPctOULzpirlsA;

			public IControllerElementTarget ROOBJayyoKuMXBTfjiimlzthFady;

			private int AwAzoNdwPeuryICkcHlTHWfvExCaA;

			public int ISxqZTtCWOdBOCoXXZEgAFtEMEUHA;

			private bool HIhBDNqKiVokKcIRzQDVDJROrzZv;

			public bool KmrRnjRgwQpKFXdtbpdtdmHOXFty;

			private TempListPool.TList<ActionElementMap> VOvfwANjtIeSJciYbqhLcNvHQqRab;

			private List<ActionElementMap>.Enumerator GDtFJKvzKZhuKJurGorPkvStthWe;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return eBQfIwJPkJNulijzFXWjVEGNIKdkA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return eBQfIwJPkJNulijzFXWjVEGNIKdkA;
				}
			}

			[DebuggerHidden]
			public htOdkJcKPoUQVFKRRzFoJsFyKbgE(int P_0)
			{
				zlPiSRdFrffGmwxGfLfJUTYtUKbL = P_0;
				FpupqFAWdlZMhoMKjsQBOPbEeTig = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = zlPiSRdFrffGmwxGfLfJUTYtUKbL;
				if ((uint)(num - -4) <= 1u || num == 1)
				{
					try
					{
						if (num == -4 || num == 1)
						{
							try
							{
							}
							finally
							{
								bPxckMcqQRTsiKvfBsxgXoJgjdqsA();
							}
						}
					}
					finally
					{
						inpdGSaxxooyecGtbsfcUjGfVLXDA();
					}
				}
				VOvfwANjtIeSJciYbqhLcNvHQqRab = null;
				GDtFJKvzKZhuKJurGorPkvStthWe = default(List<ActionElementMap>.Enumerator);
				zlPiSRdFrffGmwxGfLfJUTYtUKbL = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = zlPiSRdFrffGmwxGfLfJUTYtUKbL;
					ControllerMap oOylnEfTcZXGqsMiqFClXBaxWkQH = OOylnEfTcZXGqsMiqFClXBaxWkQH;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						zlPiSRdFrffGmwxGfLfJUTYtUKbL = -1;
						if (ReInput._id != oOylnEfTcZXGqsMiqFClXBaxWkQH.eVbcYJFeNpDqytUEinVYaObkrqXt)
						{
							ReInput.CheckInitialized(oOylnEfTcZXGqsMiqFClXBaxWkQH.eVbcYJFeNpDqytUEinVYaObkrqXt);
							return false;
						}
						VOvfwANjtIeSJciYbqhLcNvHQqRab = TempListPool.GetTList<ActionElementMap>();
						zlPiSRdFrffGmwxGfLfJUTYtUKbL = -3;
						List<ActionElementMap> list = VOvfwANjtIeSJciYbqhLcNvHQqRab.list;
						oOylnEfTcZXGqsMiqFClXBaxWkQH.xVXvATEIJOyARtowfnOzbVGdtuAe(OaLsQvXhjuWiVSUPctOULzpirlsA, true, AwAzoNdwPeuryICkcHlTHWfvExCaA, HIhBDNqKiVokKcIRzQDVDJROrzZv, list, false, out var _);
						GDtFJKvzKZhuKJurGorPkvStthWe = list.GetEnumerator();
						zlPiSRdFrffGmwxGfLfJUTYtUKbL = -4;
						break;
					}
					case 1:
						zlPiSRdFrffGmwxGfLfJUTYtUKbL = -4;
						break;
					}
					if (GDtFJKvzKZhuKJurGorPkvStthWe.MoveNext())
					{
						ActionElementMap current = GDtFJKvzKZhuKJurGorPkvStthWe.Current;
						eBQfIwJPkJNulijzFXWjVEGNIKdkA = current;
						zlPiSRdFrffGmwxGfLfJUTYtUKbL = 1;
						return true;
					}
					bPxckMcqQRTsiKvfBsxgXoJgjdqsA();
					GDtFJKvzKZhuKJurGorPkvStthWe = default(List<ActionElementMap>.Enumerator);
					inpdGSaxxooyecGtbsfcUjGfVLXDA();
					VOvfwANjtIeSJciYbqhLcNvHQqRab = null;
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

			private void inpdGSaxxooyecGtbsfcUjGfVLXDA()
			{
				zlPiSRdFrffGmwxGfLfJUTYtUKbL = -1;
				if (VOvfwANjtIeSJciYbqhLcNvHQqRab != null)
				{
					((IDisposable)VOvfwANjtIeSJciYbqhLcNvHQqRab).Dispose();
				}
			}

			private void bPxckMcqQRTsiKvfBsxgXoJgjdqsA()
			{
				zlPiSRdFrffGmwxGfLfJUTYtUKbL = -3;
				((IDisposable)GDtFJKvzKZhuKJurGorPkvStthWe/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				htOdkJcKPoUQVFKRRzFoJsFyKbgE htOdkJcKPoUQVFKRRzFoJsFyKbgE2;
				if (zlPiSRdFrffGmwxGfLfJUTYtUKbL == -2 && FpupqFAWdlZMhoMKjsQBOPbEeTig == Environment.CurrentManagedThreadId)
				{
					zlPiSRdFrffGmwxGfLfJUTYtUKbL = 0;
					htOdkJcKPoUQVFKRRzFoJsFyKbgE2 = this;
				}
				else
				{
					htOdkJcKPoUQVFKRRzFoJsFyKbgE2 = new htOdkJcKPoUQVFKRRzFoJsFyKbgE(0);
					htOdkJcKPoUQVFKRRzFoJsFyKbgE2.OOylnEfTcZXGqsMiqFClXBaxWkQH = OOylnEfTcZXGqsMiqFClXBaxWkQH;
				}
				htOdkJcKPoUQVFKRRzFoJsFyKbgE2.OaLsQvXhjuWiVSUPctOULzpirlsA = ROOBJayyoKuMXBTfjiimlzthFady;
				htOdkJcKPoUQVFKRRzFoJsFyKbgE2.AwAzoNdwPeuryICkcHlTHWfvExCaA = ISxqZTtCWOdBOCoXXZEgAFtEMEUHA;
				htOdkJcKPoUQVFKRRzFoJsFyKbgE2.HIhBDNqKiVokKcIRzQDVDJROrzZv = KmrRnjRgwQpKFXdtbpdtdmHOXFty;
				return htOdkJcKPoUQVFKRRzFoJsFyKbgE2;
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

		internal readonly int eVbcYJFeNpDqytUEinVYaObkrqXt;

		private double zhjCrlPmNQQBilxUugVouuzWBgli;

		private readonly AList<ActionElementMap> SuKJYfOmUVLUdVwLfktWyYifxJBd;

		private readonly ReadOnlyCollection<ActionElementMap> ZkxCIeCiWBcIhjjbAfoCCkeJoSjDA;

		private readonly AList<ActionElementMap> xntVCxamQGYOxKYZdHFvoveUaVuh;

		private readonly ReadOnlyCollection<ActionElementMap> qwVXCNfBsDxXCnYFYCsgGdLDjtZC;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int GdXotZLcNaEJjISFHzkjiVoDJzFBb;

		private static int FxoTXumZKweNjUesBrgYxORtBNUjA;

		private static int FaCaNnPoqWzzCQkDrMZmMioRLwIe
		{
			get
			{
				int gdXotZLcNaEJjISFHzkjiVoDJzFBb = GdXotZLcNaEJjISFHzkjiVoDJzFBb;
				if (GdXotZLcNaEJjISFHzkjiVoDJzFBb == int.MaxValue)
				{
					GdXotZLcNaEJjISFHzkjiVoDJzFBb = 0;
					return gdXotZLcNaEJjISFHzkjiVoDJzFBb;
				}
				GdXotZLcNaEJjISFHzkjiVoDJzFBb++;
				return gdXotZLcNaEJjISFHzkjiVoDJzFBb;
			}
		}

		internal static bool bXuCYzgaSWwQwnpVFQfBnyFBhfFj => FxoTXumZKweNjUesBrgYxORtBNUjA > 0;

		public int id
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return 0;
				}
				return xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return 0;
				}
				return SuKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return qwVXCNfBsDxXCnYFYCsgGdLDjtZC;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return qwVXCNfBsDxXCnYFYCsgGdLDjtZC;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
				{
					ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return ZkxCIeCiWBcIhjjbAfoCCkeJoSjDA;
			}
		}

		public double modifiedTime
		{
			get
			{
				int count = xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
				double num = zhjCrlPmNQQBilxUugVouuzWBgli;
				for (int i = 0; i < count; i++)
				{
					if (xntVCxamQGYOxKYZdHFvoveUaVuh[i] != null && xntVCxamQGYOxKYZdHFvoveUaVuh[i].modifiedTime > num)
					{
						num = xntVCxamQGYOxKYZdHFvoveUaVuh[i].modifiedTime;
					}
				}
				return num;
			}
		}

		public bool isModified
		{
			get
			{
				if (zhjCrlPmNQQBilxUugVouuzWBgli > 0.0)
				{
					return true;
				}
				int count = xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
				for (int i = 0; i < count; i++)
				{
					if (xntVCxamQGYOxKYZdHFvoveUaVuh[i] != null && xntVCxamQGYOxKYZdHFvoveUaVuh[i].isModified)
					{
						return true;
					}
				}
				return false;
			}
			set
			{
				if (value)
				{
					zhjCrlPmNQQBilxUugVouuzWBgli = ReInput.realTime;
					return;
				}
				zhjCrlPmNQQBilxUugVouuzWBgli = 0.0;
				int count = xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
				_ = zhjCrlPmNQQBilxUugVouuzWBgli;
				for (int i = 0; i < count; i++)
				{
					if (xntVCxamQGYOxKYZdHFvoveUaVuh[i] != null)
					{
						xntVCxamQGYOxKYZdHFvoveUaVuh[i].isModified = value;
					}
				}
			}
		}

		internal AList<ActionElementMap> OurlyxeFzWBnIptcmgMKsPUxiwjO => SuKJYfOmUVLUdVwLfktWyYifxJBd;

		public ControllerMap()
		{
			_id = FaCaNnPoqWzzCQkDrMZmMioRLwIe;
			_sourceMapId = -1;
			SuKJYfOmUVLUdVwLfktWyYifxJBd = new AList<ActionElementMap>();
			ZkxCIeCiWBcIhjjbAfoCCkeJoSjDA = new ReadOnlyCollection<ActionElementMap>(SuKJYfOmUVLUdVwLfktWyYifxJBd);
			xntVCxamQGYOxKYZdHFvoveUaVuh = new AList<ActionElementMap>();
			qwVXCNfBsDxXCnYFYCsgGdLDjtZC = new ReadOnlyCollection<ActionElementMap>(xntVCxamQGYOxKYZdHFvoveUaVuh);
			eVbcYJFeNpDqytUEinVYaObkrqXt = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = FaCaNnPoqWzzCQkDrMZmMioRLwIe;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			SgBcrvnOtECGyjPXXClnObWapWwBb();
			if (P_0.SuKJYfOmUVLUdVwLfktWyYifxJBd != null)
			{
				int count = P_0.SuKJYfOmUVLUdVwLfktWyYifxJBd.Count;
				for (int i = 0; i < count; i++)
				{
					UAQGCwKkDSPvmqXTCNuGVxxpaJDI(new ActionElementMap(P_0.SuKJYfOmUVLUdVwLfktWyYifxJBd[i]));
				}
			}
			tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			zhjCrlPmNQQBilxUugVouuzWBgli = P_0.zhjCrlPmNQQBilxUugVouuzWBgli;
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			InputAction inputAction = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.MaBqBGMglwlFblDVqevucOFjoimZA(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			AList<ActionElementMap> aList = xntVCxamQGYOxKYZdHFvoveUaVuh;
			for (int i = 0; i < aList.Count; i++)
			{
				if (xntVCxamQGYOxKYZdHFvoveUaVuh[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			AList<ActionElementMap> aList = xntVCxamQGYOxKYZdHFvoveUaVuh;
			for (int i = 0; i < aList.Count; i++)
			{
				if (xntVCxamQGYOxKYZdHFvoveUaVuh[i].keyCode == keyCode && xntVCxamQGYOxKYZdHFvoveUaVuh[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = xntVCxamQGYOxKYZdHFvoveUaVuh;
			for (int i = 0; i < aList.Count; i++)
			{
				if (xntVCxamQGYOxKYZdHFvoveUaVuh[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			AList<ActionElementMap> aList = xntVCxamQGYOxKYZdHFvoveUaVuh;
			for (int i = 0; i < aList.Count; i++)
			{
				if (xntVCxamQGYOxKYZdHFvoveUaVuh[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, bVcNkmaJvbHeBNQRpaleQvWHeXqv.hprGByjpElSVqTapPvrydgHxKrZq(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.EfvdQpyXFryBbeksYVlLvkBmPQQC(this, actionElementMap);
			UAQGCwKkDSPvmqXTCNuGVxxpaJDI(actionElementMap);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			ZmQAsnFateHowPIRZHWVpzpnRNMx zmQAsnFateHowPIRZHWVpzpnRNMx = ZmQAsnFateHowPIRZHWVpzpnRNMx.GwHsVqHKGnDpyMlwValsgFvdlihHA(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, zmQAsnFateHowPIRZHWVpzpnRNMx.QKPjhXmRwvNIIzfJCjVfDFypgwPG, zmQAsnFateHowPIRZHWVpzpnRNMx.dPwiQmWMwlHGtFtdaaDXReMzJoZo, zmQAsnFateHowPIRZHWVpzpnRNMx.KRhiCoPDaDVztaJOVEfxVBBBDmyt, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			UAQGCwKkDSPvmqXTCNuGVxxpaJDI(actionElementMap);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, bVcNkmaJvbHeBNQRpaleQvWHeXqv.hprGByjpElSVqTapPvrydgHxKrZq(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (RwuwMhYATcZkBWbvgMwBNmBzBCyB(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Button;
				UAQGCwKkDSPvmqXTCNuGVxxpaJDI(elementMap);
			}
			if (RwuwMhYATcZkBWbvgMwBNmBzBCyB(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.crLlVTiUiqPOhNdOCmHobhupgSse();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			elementMap.bficrGUDNywRTpHoFGmJjjCndKvX();
			ReInput.controllers.Keyboard.EfvdQpyXFryBbeksYVlLvkBmPQQC(this, elementMap);
			result = elementMap;
			DEraIyQiBlsRSAaUjxRenWgmpJJT();
			return true;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			ZmQAsnFateHowPIRZHWVpzpnRNMx zmQAsnFateHowPIRZHWVpzpnRNMx = ZmQAsnFateHowPIRZHWVpzpnRNMx.GwHsVqHKGnDpyMlwValsgFvdlihHA(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, zmQAsnFateHowPIRZHWVpzpnRNMx.QKPjhXmRwvNIIzfJCjVfDFypgwPG, zmQAsnFateHowPIRZHWVpzpnRNMx.dPwiQmWMwlHGtFtdaaDXReMzJoZo, zmQAsnFateHowPIRZHWVpzpnRNMx.KRhiCoPDaDVztaJOVEfxVBBBDmyt, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				result = null;
				return false;
			}
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(elementType))
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
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Button;
				UAQGCwKkDSPvmqXTCNuGVxxpaJDI(elementMap);
			}
			if (RwuwMhYATcZkBWbvgMwBNmBzBCyB(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			IDJjaUCBNnGXUSVrFFTHXssIHzsaA(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			DEraIyQiBlsRSAaUjxRenWgmpJJT();
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			int num = RwuwMhYATcZkBWbvgMwBNmBzBCyB(elementMapId);
			if (num < 0)
			{
				return false;
			}
			QGafBaenmztNXqWFoPOsyahYYWLR(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == elementMapId)
				{
					return SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				if (!skipDisabledMaps || allMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return jLiOCZmkHIDRyrrIzWdIIlgyZKXm(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
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
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return LPMKAKNrPSmdGMWdQtQBGKFQKxwb(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(DtvOlJbDyKOYBuvDMWVhMHUjesYU))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new DtvOlJbDyKOYBuvDMWVhMHUjesYU(-2)
			{
				NIgnWIvvmlUrFsgQFYpXNPmAlalJ = this,
				lWcdAxBccLHCuFGvPGXmXKyKfVvO = actionId,
				PjsVYmyUNDRNmVDCyjuieypyPiPN = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._actionId == actionId && (!skipDisabledMaps || SuKJYfOmUVLUdVwLfktWyYifxJBd[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					return SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, skipDisabledMaps);
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
			return result;
		}

		[IteratorStateMachine(typeof(JeDLhhuPSTrDYsgVJTjEIlpHZsUL))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new JeDLhhuPSTrDYsgVJTjEIlpHZsUL(-2)
			{
				TDDALHnnEPYTiNcfkKyGvGKpoSdY = this,
				xJHBDBgwUNSVxBKfLGQiOlNdhHvmA = elementTarget,
				ayaQZSqWubsrKIsohfgOacpIwImy = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, actionId, skipDisabledMaps);
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(htOdkJcKPoUQVFKRRzFoJsFyKbgE))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new htOdkJcKPoUQVFKRRzFoJsFyKbgE(-2)
			{
				OOylnEfTcZXGqsMiqFClXBaxWkQH = this,
				ROOBJayyoKuMXBTfjiimlzthFady = elementTarget,
				ISxqZTtCWOdBOCoXXZEgAFtEMEUHA = actionId,
				KmrRnjRgwQpKFXdtbpdtdmHOXFty = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, skipDisabledMaps);
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			bool flag;
			return KArrUOdDybdkCKycWMMqbUtKVtfsA(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, actionId, skipDisabledMaps);
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			bool flag;
			return KArrUOdDybdkCKycWMMqbUtKVtfsA(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, skipDisabledMaps, results);
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			bool flag;
			return xVXvATEIJOyARtowfnOzbVGdtuAe(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk xuJpBJvxrqVOEMAPQQDPCLYEUJbk = XuJpBJvxrqVOEMAPQQDPCLYEUJbk.vZNASuCGODMiXWePrYVtzaOvfwfs(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xuJpBJvxrqVOEMAPQQDPCLYEUJbk, actionId, skipDisabledMaps, results);
			XuJpBJvxrqVOEMAPQQDPCLYEUJbk.gBYtRmxJUHEApkMkUIYRtLusajDpA(xuJpBJvxrqVOEMAPQQDPCLYEUJbk);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			bool flag;
			return xVXvATEIJOyARtowfnOzbVGdtuAe(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			return sEEZASgeCTfEHdNKZIwJegYcGniSB(predicate, false);
		}

		internal virtual ActionElementMap sEEZASgeCTfEHdNKZIwJegYcGniSB(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return CgozBHKamZxZUVLUwPkmJxcimqeJ(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return aTzfofhvprNRBsUCiwcGsmftAHteA(predicate, false, results, false);
		}

		internal virtual int aTzfofhvprNRBsUCiwcGsmftAHteA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return JZtOzMHTaLhJcswwlNYSiVeYXVUi(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
			int count = xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = xntVCxamQGYOxKYZdHFvoveUaVuh[i];
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return;
			}
			SuKJYfOmUVLUdVwLfktWyYifxJBd.Clear();
			xntVCxamQGYOxKYZdHFvoveUaVuh.Clear();
			DEraIyQiBlsRSAaUjxRenWgmpJJT();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int num = 0;
			int count = xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = xntVCxamQGYOxKYZdHFvoveUaVuh[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb != state)
				{
					actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null || index < 0 || index >= SuKJYfOmUVLUdVwLfktWyYifxJBd.Count)
			{
				return null;
			}
			return SuKJYfOmUVLUdVwLfktWyYifxJBd[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(SuKJYfOmUVLUdVwLfktWyYifxJBd);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return hGDnxYUKsHEbBTyKrcOQdnLcKNNt(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
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
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
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
				ActionElementMap actionElementMap2 = SuKJYfOmUVLUdVwLfktWyYifxJBd[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return lkBCrZtdEzTNPDljURszfhzPaVej(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(DkezfUOOLSiNHlrMxLqmFHLmgIHn))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new DkezfUOOLSiNHlrMxLqmFHLmgIHn(-2)
			{
				UAyXnuvRJlNWOnTRAqkqztjlSKlb = this,
				ovAwtyfzqTEttcmzbyIGUOeRHwDr = actionId,
				awdETPsCGXtnPbkYJNHBPKCWdsIJA = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			int actionId = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			return CgozBHKamZxZUVLUwPkmJxcimqeJ(predicate, false);
		}

		internal ActionElementMap CgozBHKamZxZUVLUwPkmJxcimqeJ(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return JZtOzMHTaLhJcswwlNYSiVeYXVUi(predicate, false, results, false);
		}

		internal int JZtOzMHTaLhJcswwlNYSiVeYXVUi(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int count = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
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
			return DeleteButtonMapsWithAction(ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
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
			int num = buttonMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					QGafBaenmztNXqWFoPOsyahYYWLR(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			int num = 0;
			int count = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb != state)
				{
					actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb = state;
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (skipDisabledMaps && !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			if (actionElementMap == null || SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
			{
				return false;
			}
			for (int i = 0; i < SuKJYfOmUVLUdVwLfktWyYifxJBd.Count; i++)
			{
				ActionElementMap actionElementMap2 = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return false;
			}
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
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
			for (int i = 0; i < SuKJYfOmUVLUdVwLfktWyYifxJBd.Count; i++)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if ((!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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

		[IteratorStateMachine(typeof(KsVkPEWCjcIZpoXQqItaRrKswcfO))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new KsVkPEWCjcIZpoXQqItaRrKswcfO(-2)
			{
				HtptqrarXZURdlBVlRFuHBBwffUq = this,
				zIMCfLUBPOgxlcDDjBuTtdYseULf = controllerMap,
				HOXVRtzMoToEbDXGTtEZUOOrhpicA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(LHFBMIlSCZHrzPfcdpWgDuRkpZeH))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new LHFBMIlSCZHrzPfcdpWgDuRkpZeH(-2)
			{
				uYYGBTDmpKckpWOnInivJcZIcLAUA = this,
				ZvNLdpGonOEzHqEMstrdQKASFAEP = actionElementMap,
				oEmrMIppFUBHzNLxpApppzFzULjo = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(bWlIrllZodEzFunpyBfTzBEzxIyD))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new bWlIrllZodEzFunpyBfTzBEzxIyD(-2)
			{
				ajuOJCVYIPkzBKFJoHqsQvZPosGr = this,
				krGhnlSZmlJUttVzomjbdunUvjYt = conflictCheck,
				bfscMDaHXNjQudomEBWYwgbTbkKCA = skipDisabledMaps
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return num;
			}
			IList<ActionElementMap> suKJYfOmUVLUdVwLfktWyYifxJBd = controllerMap.SuKJYfOmUVLUdVwLfktWyYifxJBd;
			if (suKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = suKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			for (int num2 = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[num2];
				if (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || suKJYfOmUVLUdVwLfktWyYifxJBd[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(suKJYfOmUVLUdVwLfktWyYifxJBd[i]))
						{
							QGafBaenmztNXqWFoPOsyahYYWLR(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return num;
			}
			for (int num2 = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = SuKJYfOmUVLUdVwLfktWyYifxJBd[num2];
				if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					QGafBaenmztNXqWFoPOsyahYYWLR(actionElementMap2.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
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
			for (int num2 = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[num2];
				if ((!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					QGafBaenmztNXqWFoPOsyahYYWLR(actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return zeztsRkmbKBGcHGbkLmxixfnHyMA(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return xARvIziAnsCgxrFCUVjIgaMtFsaHA(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return RijTjPgqOiHkBmeJciVrzMTgrgKF(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return zeztsRkmbKBGcHGbkLmxixfnHyMA(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return xARvIziAnsCgxrFCUVjIgaMtFsaHA(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return 0;
			}
			return RijTjPgqOiHkBmeJciVrzMTgrgKF(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int zeztsRkmbKBGcHGbkLmxixfnHyMA(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return num;
			}
			IList<ActionElementMap> suKJYfOmUVLUdVwLfktWyYifxJBd = P_0.SuKJYfOmUVLUdVwLfktWyYifxJBd;
			if (suKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = suKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (!actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = suKJYfOmUVLUdVwLfktWyYifxJBd[j];
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

		internal virtual int xARvIziAnsCgxrFCUVjIgaMtFsaHA(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int RijTjPgqOiHkBmeJciVrzMTgrgKF(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (xntVCxamQGYOxKYZdHFvoveUaVuh == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.xntVCxamQGYOxKYZdHFvoveUaVuh;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = list.Count;
			for (int num2 = xntVCxamQGYOxKYZdHFvoveUaVuh.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = xntVCxamQGYOxKYZdHFvoveUaVuh[num2];
				if (!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.CheckForAssignmentConflict(list[i]))
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
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
			if (xntVCxamQGYOxKYZdHFvoveUaVuh == null)
			{
				return num;
			}
			for (int num2 = xntVCxamQGYOxKYZdHFvoveUaVuh.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = xntVCxamQGYOxKYZdHFvoveUaVuh[num2];
				if ((!skipDisabledMaps || actionElementMap2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			if (xntVCxamQGYOxKYZdHFvoveUaVuh == null)
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
			for (int num2 = xntVCxamQGYOxKYZdHFvoveUaVuh.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = xntVCxamQGYOxKYZdHFvoveUaVuh[num2];
				if ((!skipDisabledMaps || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && actionElementMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				array[i] = SuKJYfOmUVLUdVwLfktWyYifxJBd[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return string.Empty;
			}
			try
			{
				return azmpAmqwsdtPAUTonYdOICgZZuQE().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return string.Empty;
			}
			try
			{
				return azmpAmqwsdtPAUTonYdOICgZZuQE().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
				LrxjGZteHmJMKhKqexjHMLnoIwmG lrxjGZteHmJMKhKqexjHMLnoIwmG = ReInput.maXAkWnYBdMDlaPIAIBSdMHOSOsOA(templateTypeGuid);
				string text = ((lrxjGZteHmJMKhKqexjHMLnoIwmG != null) ? lrxjGZteHmJMKhKqexjHMLnoIwmG.pVYpWKuNwApnRJoZBAKraKRvLpUHb : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.hMyFPrbDZmsMHOxNFaMNrLgAkAwIA(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
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
			return ControllerTemplateMap.hMyFPrbDZmsMHOxNFaMNrLgAkAwIA(controllerTemplate, this);
		}

		private ControllerTemplateMap YBoOvDYZqnjmjiiFIQDtFDLuMWQI(IControllerTemplate P_0)
		{
			if (ReInput._id != eVbcYJFeNpDqytUEinVYaObkrqXt)
			{
				ReInput.CheckInitialized(eVbcYJFeNpDqytUEinVYaObkrqXt);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.hMyFPrbDZmsMHOxNFaMNrLgAkAwIA(P_0, this);
		}

		internal virtual bool LqBWpTNVWgCahBpYNHcxDtZTDUKt(ActionElementMap P_0)
		{
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_0._elementType))
			{
				return false;
			}
			UAQGCwKkDSPvmqXTCNuGVxxpaJDI(P_0);
			return true;
		}

		internal virtual int jLiOCZmkHIDRyrrIzWdIIlgyZKXm(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = SuKJYfOmUVLUdVwLfktWyYifxJBd.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || SuKJYfOmUVLUdVwLfktWyYifxJBd[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					P_0.Add(SuKJYfOmUVLUdVwLfktWyYifxJBd[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap WUEgoskwDJPRgXjNyRzamrFiRkqs(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_2))
			{
				return null;
			}
			int num = aAMiwmpEmdzmmAPnWDlzmhPNViXf(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return SuKJYfOmUVLUdVwLfktWyYifxJBd[num];
		}

		internal virtual int xhndsUmEMIbUZqInGbwJJVaGZCvX(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._elementIdentifierId == P_0)
				{
					P_1.Add(SuKJYfOmUVLUdVwLfktWyYifxJBd[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool cdhaxGXtpPjMZObHwdOTnzVMDJkC(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._elementIdentifierId == P_0 && SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int aAMiwmpEmdzmmAPnWDlzmhPNViXf(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_2))
			{
				return -1;
			}
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._elementIdentifierId == P_0 && SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int RwuwMhYATcZkBWbvgMwBNmBzBCyB(int P_0)
		{
			if (SuKJYfOmUVLUdVwLfktWyYifxJBd == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int hGDnxYUKsHEbBTyKrcOQdnLcKNNt(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (!P_0 || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int lkBCrZtdEzTNPDljURszfhzPaVej(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int LPMKAKNrPSmdGMWdQtQBGKFQKxwb(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.hrXjVMVBGWHRhCIrzlnSmtoGojQeb))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap KArrUOdDybdkCKycWMMqbUtKVtfsA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!JNlzNcDPQeZbAsvXFDUNXoukWitV(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._actionId == P_2) && (!P_3 || SuKJYfOmUVLUdVwLfktWyYifxJBd[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && SuKJYfOmUVLUdVwLfktWyYifxJBd[i].IsTarget(P_0))
				{
					return SuKJYfOmUVLUdVwLfktWyYifxJBd[i];
				}
			}
			return null;
		}

		internal virtual int xVXvATEIJOyARtowfnOzbVGdtuAe(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!JNlzNcDPQeZbAsvXFDUNXoukWitV(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || SuKJYfOmUVLUdVwLfktWyYifxJBd[i]._actionId == P_2) && (!P_3 || SuKJYfOmUVLUdVwLfktWyYifxJBd[i].hrXjVMVBGWHRhCIrzlnSmtoGojQeb) && SuKJYfOmUVLUdVwLfktWyYifxJBd[i].IsTarget(P_0))
				{
					P_4.Add(SuKJYfOmUVLUdVwLfktWyYifxJBd[i]);
					num++;
				}
			}
			return num;
		}

		internal void UGuYgGVZKXVfNbvQbryOLFsKAFlj(int P_0, ControllerElementType P_1)
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
				GPdkcFUsjoTOrNAJlHqqwoEMaYBR(elementMap);
			}
		}

		internal virtual bool GPdkcFUsjoTOrNAJlHqqwoEMaYBR(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!XXyBlKQJIzAHDoHXAJVUUgieBlts(P_0._elementType))
			{
				return false;
			}
			SuKJYfOmUVLUdVwLfktWyYifxJBd.Add(P_0);
			WEOFbWYubWBUzHTzVhrcAwdLmeydA(P_0);
			return true;
		}

		internal bool JNlzNcDPQeZbAsvXFDUNXoukWitV(IControllerElementTarget P_0)
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

		internal bool DSwzGEIPxVsmAwNxbOBVGsSTDVPr(string P_0)
		{
			try
			{
				LmTqdyqGkCajsHdLEdEZdPWfUzJl(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool cYpJMAZAHaucwCGHTHnaOlZdlVNm(string P_0)
		{
			try
			{
				LmTqdyqGkCajsHdLEdEZdPWfUzJl(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void WEOFbWYubWBUzHTzVhrcAwdLmeydA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				xntVCxamQGYOxKYZdHFvoveUaVuh.Add(P_0);
				xntVCxamQGYOxKYZdHFvoveUaVuh.Sort(FLrcWuXQukeHZbPdxGGGBCZcoWtdb.LlAHqyETvFFiJWluDkklCcpSFDYN);
				DEraIyQiBlsRSAaUjxRenWgmpJJT();
			}
		}

		internal void CUlJDIMfaiGkqhgipiTqWlDEKbSC(int P_0)
		{
			int num = LyBEYHXQpPfuqEzVUUlgkKLFGFykA(P_0);
			if (num >= 0)
			{
				xntVCxamQGYOxKYZdHFvoveUaVuh.RemoveAt(num);
				DEraIyQiBlsRSAaUjxRenWgmpJJT();
			}
		}

		internal void kWWKsaFzfxhjruhxYEbWimOfkCnRA(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = LyBEYHXQpPfuqEzVUUlgkKLFGFykA(P_0);
				if (num >= 0)
				{
					xntVCxamQGYOxKYZdHFvoveUaVuh[num] = P_1;
					xntVCxamQGYOxKYZdHFvoveUaVuh.Sort(FLrcWuXQukeHZbPdxGGGBCZcoWtdb.LlAHqyETvFFiJWluDkklCcpSFDYN);
					DEraIyQiBlsRSAaUjxRenWgmpJJT();
				}
			}
		}

		internal static void IDJjaUCBNnGXUSVrFFTHXssIHzsaA(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.crLlVTiUiqPOhNdOCmHobhupgSse();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			P_0._elementIdentifierId = P_3;
			P_0._axisContribution = P_2;
			P_0._axisRange = P_5;
			if (P_4 == ControllerElementType.Axis)
			{
				P_0._invert = P_6;
			}
			P_0.bficrGUDNywRTpHoFGmJjjCndKvX();
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId)?.EfvdQpyXFryBbeksYVlLvkBmPQQC(this, map);
			}
		}

		internal virtual bool LmTqdyqGkCajsHdLEdEZdPWfUzJl(SerializedObject P_0)
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
						actionElementMap.qbSInOBzRpLbKGdknAatzCqAWxtMA(value2);
						if (ActionElementMap.aODDhkZGfEYPsGiSODPHcMQUMixpA(actionElementMap))
						{
							UAQGCwKkDSPvmqXTCNuGVxxpaJDI(actionElementMap);
						}
					}
				}
			}
			DEraIyQiBlsRSAaUjxRenWgmpJJT();
			return flag;
		}

		internal virtual void wYUtAyzJWerCAyBPvoWTKhOuCwNg(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "dataVersion",
				colvBdeALTpVyhJTAuogspkzwFfR = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string colvBdeALTpVyhJTAuogspkzwFfR = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
				{
					pdYiVMKqONWNQjSqPcOhYrKSabZR = "hardwareGuid",
					colvBdeALTpVyhJTAuogspkzwFfR = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
				{
					pdYiVMKqONWNQjSqPcOhYrKSabZR = "hardwareName",
					colvBdeALTpVyhJTAuogspkzwFfR = colvBdeALTpVyhJTAuogspkzwFfR
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				YwqFzwdFPbsmyhvzUHNjHImbnvlAA = "xmlns",
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "xsi",
				JQeynGdKCohWfFHxkPiAfoQUYTUPA = null,
				colvBdeALTpVyhJTAuogspkzwFfR = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				YwqFzwdFPbsmyhvzUHNjHImbnvlAA = "xsi",
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "schemaLocation",
				JQeynGdKCohWfFHxkPiAfoQUYTUPA = null,
				colvBdeALTpVyhJTAuogspkzwFfR = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (SuKJYfOmUVLUdVwLfktWyYifxJBd[i] != null)
				{
					list.Add(SuKJYfOmUVLUdVwLfktWyYifxJBd[i].mPXookHxaeOSKUADmcsOiVKFOQqi());
				}
			}
		}

		private bool XXyBlKQJIzAHDoHXAJVUUgieBlts(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void QGafBaenmztNXqWFoPOsyahYYWLR(int P_0, int P_1)
		{
			CUlJDIMfaiGkqhgipiTqWlDEKbSC(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				SuKJYfOmUVLUdVwLfktWyYifxJBd.RemoveAt(P_1);
			}
		}

		private void UAQGCwKkDSPvmqXTCNuGVxxpaJDI(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				SuKJYfOmUVLUdVwLfktWyYifxJBd.Add(P_0);
				WEOFbWYubWBUzHTzVhrcAwdLmeydA(P_0);
			}
		}

		private void bPGXYeIHZILCqmqGTeHUxlhBGnbn(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				kWWKsaFzfxhjruhxYEbWimOfkCnRA(SuKJYfOmUVLUdVwLfktWyYifxJBd[P_1].gjHUlVyQSQsjZEOHtHfmeehEQpiIA, P_0);
				SuKJYfOmUVLUdVwLfktWyYifxJBd[P_1] = P_0;
			}
		}

		private int LyBEYHXQpPfuqEzVUUlgkKLFGFykA(int P_0)
		{
			if (xntVCxamQGYOxKYZdHFvoveUaVuh == null)
			{
				return -1;
			}
			int count = xntVCxamQGYOxKYZdHFvoveUaVuh.Count;
			for (int i = 0; i < count; i++)
			{
				if (xntVCxamQGYOxKYZdHFvoveUaVuh[i].gjHUlVyQSQsjZEOHtHfmeehEQpiIA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject azmpAmqwsdtPAUTonYdOICgZZuQE()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			wYUtAyzJWerCAyBPvoWTKhOuCwNg(serializedObject);
			return serializedObject;
		}

		internal void DEraIyQiBlsRSAaUjxRenWgmpJJT()
		{
			if (!bXuCYzgaSWwQwnpVFQfBnyFBhfFj)
			{
				zhjCrlPmNQQBilxUugVouuzWBgli = ReInput.realTime;
			}
		}

		public static ControllerMap Create(Controller controller, int categoryId, int layoutId)
		{
			return RGWeWlUjVEJhFbPqqedJvIlSkpWG(controller, categoryId, layoutId);
		}

		internal static ControllerMap qsvHbdffvMuvxyqzGXpxONTMtALL(ControllerType P_0)
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

		internal static ControllerMap RGWeWlUjVEJhFbPqqedJvIlSkpWG(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.MitadNEcsVptWOBpQJnpDDXTaMvGb(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.KMtKRacDvbhYEhVwvclsvpNAaEMcA(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.QGQzxeoUrvqTgKgBjcpIIMruduyiA(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.TNybGMHEEnuLhzpMldXmhoTTqjfkA(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = qsvHbdffvMuvxyqzGXpxONTMtALL(controllerType);
			try
			{
				SgBcrvnOtECGyjPXXClnObWapWwBb();
				controllerMap.DSwzGEIPxVsmAwNxbOBVGsSTDVPr(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
			finally
			{
				tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			}
		}

		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = qsvHbdffvMuvxyqzGXpxONTMtALL(controllerType);
			try
			{
				SgBcrvnOtECGyjPXXClnObWapWwBb();
				controllerMap.cYpJMAZAHaucwCGHTHnaOlZdlVNm(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
			finally
			{
				tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			}
		}

		internal static void SgBcrvnOtECGyjPXXClnObWapWwBb()
		{
			FxoTXumZKweNjUesBrgYxORtBNUjA++;
		}

		internal static void tvbsaMCIOZDkpfIxmIGWXRPXoybbA()
		{
			FxoTXumZKweNjUesBrgYxORtBNUjA--;
			if (FxoTXumZKweNjUesBrgYxORtBNUjA < 0)
			{
				FxoTXumZKweNjUesBrgYxORtBNUjA = 0;
				Logger.LogError("Too many calls to disable internal modify mode!");
			}
		}
	}
}
