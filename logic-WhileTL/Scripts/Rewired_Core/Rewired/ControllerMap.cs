using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class tIJFOWMdHGaXZBsAyCSncWwVwLgbA : IComparer<ActionElementMap>
		{
			public static tIJFOWMdHGaXZBsAyCSncWwVwLgbA bPGhEsCmNTbAPJBiQCMCWwkESCog;

			public static tIJFOWMdHGaXZBsAyCSncWwVwLgbA ccczNqsNLdBVbHnxRjOzBZTknCGZ => bPGhEsCmNTbAPJBiQCMCWwkESCog ?? (bPGhEsCmNTbAPJBiQCMCWwkESCog = new tIJFOWMdHGaXZBsAyCSncWwVwLgbA());

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
		}

		private sealed class ZLNTCQapqrkkWyMwUQRrGQOlfJlF : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

			public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private IList<ActionElementMap> CnZKxhlYbjQPBCcWHbVfSjfiGgPCA;

			private int AqHISUCyicWJlXNxGkuCxIBUYUxh;

			private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public ZLNTCQapqrkkWyMwUQRrGQOlfJlF(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00af;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
				{
					return false;
				}
				CnZKxhlYbjQPBCcWHbVfSjfiGgPCA = gZXxEqHwrHYIyUJtInpLwgTukJaY.ButtonMaps;
				AqHISUCyicWJlXNxGkuCxIBUYUxh = gZXxEqHwrHYIyUJtInpLwgTukJaY.buttonMapCount;
				AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
				goto IL_00bf;
				IL_00bf:
				if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < AqHISUCyicWJlXNxGkuCxIBUYUxh)
				{
					ActionElementMap actionElementMap = CnZKxhlYbjQPBCcWHbVfSjfiGgPCA[AEpFbNhiazpfukEJmuNHcDAbfQLWA];
					if (actionElementMap._actionId == oRajQOHwRbMrJNwZiDDGjrEZUMQf && (!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionElementMap;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
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
				ZLNTCQapqrkkWyMwUQRrGQOlfJlF zLNTCQapqrkkWyMwUQRrGQOlfJlF;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					zLNTCQapqrkkWyMwUQRrGQOlfJlF = this;
				}
				else
				{
					zLNTCQapqrkkWyMwUQRrGQOlfJlF = new ZLNTCQapqrkkWyMwUQRrGQOlfJlF(0);
					zLNTCQapqrkkWyMwUQRrGQOlfJlF.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				zLNTCQapqrkkWyMwUQRrGQOlfJlF.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
				zLNTCQapqrkkWyMwUQRrGQOlfJlF.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return zLNTCQapqrkkWyMwUQRrGQOlfJlF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class cfXHGHRaAFcZTTsmnDSiZEkMGQpkA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private ControllerMap bCyRjgRlhEVQenEXvcdthvtYiSbS;

			public ControllerMap gaBeQySvDEkRFhRLfUogfFxSYGFm;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private IList<ActionElementMap> WzDfSucMhnOOxDPQAAdGoPCEiNbpE;

			private int EvVtLykcKkWsKUacotsBslzWbUsy;

			private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

			private ActionElementMap jDlIMuBxqJZypjMZSGzCYuDvbkJFA;

			private int KPzcVBnmZXDxZtyglRXvOitPTlXE;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public cfXHGHRaAFcZTTsmnDSiZEkMGQpkA(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_019c;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				if (bCyRjgRlhEVQenEXvcdthvtYiSbS == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
				{
					return false;
				}
				if (SkVfnydpDzxVINVmPxKjrMVDeYYIA && (!gZXxEqHwrHYIyUJtInpLwgTukJaY._enabled || !bCyRjgRlhEVQenEXvcdthvtYiSbS._enabled))
				{
					return false;
				}
				WzDfSucMhnOOxDPQAAdGoPCEiNbpE = bCyRjgRlhEVQenEXvcdthvtYiSbS.ButtonMaps;
				if (WzDfSucMhnOOxDPQAAdGoPCEiNbpE == null)
				{
					return false;
				}
				EvVtLykcKkWsKUacotsBslzWbUsy = WzDfSucMhnOOxDPQAAdGoPCEiNbpE.Count;
				AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
				goto IL_01d4;
				IL_01d4:
				if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA.Count)
				{
					jDlIMuBxqJZypjMZSGzCYuDvbkJFA = gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA[AEpFbNhiazpfukEJmuNHcDAbfQLWA];
					if (!SkVfnydpDzxVINVmPxKjrMVDeYYIA || jDlIMuBxqJZypjMZSGzCYuDvbkJFA.llkLFSoLVtaASCstwdnHCsIDxnhYb)
					{
						KPzcVBnmZXDxZtyglRXvOitPTlXE = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (KPzcVBnmZXDxZtyglRXvOitPTlXE < EvVtLykcKkWsKUacotsBslzWbUsy)
				{
					ActionElementMap actionElementMap = WzDfSucMhnOOxDPQAAdGoPCEiNbpE[KPzcVBnmZXDxZtyglRXvOitPTlXE];
					if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && jDlIMuBxqJZypjMZSGzCYuDvbkJFA.CheckForAssignmentConflict(actionElementMap))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(gZXxEqHwrHYIyUJtInpLwgTukJaY._categoryId).userAssignable, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerType, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerId, gZXxEqHwrHYIyUJtInpLwgTukJaY._id, jDlIMuBxqJZypjMZSGzCYuDvbkJFA.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, jDlIMuBxqJZypjMZSGzCYuDvbkJFA._actionId, jDlIMuBxqJZypjMZSGzCYuDvbkJFA._elementType, jDlIMuBxqJZypjMZSGzCYuDvbkJFA._elementIdentifierId, jDlIMuBxqJZypjMZSGzCYuDvbkJFA.keyCode, jDlIMuBxqJZypjMZSGzCYuDvbkJFA.modifierKeyFlags);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_019c;
				}
				jDlIMuBxqJZypjMZSGzCYuDvbkJFA = null;
				goto IL_01c4;
				IL_01c4:
				AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
				goto IL_01d4;
				IL_019c:
				KPzcVBnmZXDxZtyglRXvOitPTlXE++;
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
				cfXHGHRaAFcZTTsmnDSiZEkMGQpkA cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2 = this;
				}
				else
				{
					cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2 = new cfXHGHRaAFcZTTsmnDSiZEkMGQpkA(0);
					cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2.bCyRjgRlhEVQenEXvcdthvtYiSbS = gaBeQySvDEkRFhRLfUogfFxSYGFm;
				cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return cfXHGHRaAFcZTTsmnDSiZEkMGQpkA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class LykzCYMvaNoZTDHppIDwyNVMQmRl : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private ActionElementMap JkHyuiFgCXoofKLRpBbmEBHplCHc;

			public ActionElementMap cQtxXqgBqUrChgcaDbepmAeZBhIT;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public LykzCYMvaNoZTDHppIDwyNVMQmRl(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0111;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				if (JkHyuiFgCXoofKLRpBbmEBHplCHc == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
				{
					return false;
				}
				if (SkVfnydpDzxVINVmPxKjrMVDeYYIA && (!gZXxEqHwrHYIyUJtInpLwgTukJaY._enabled || !JkHyuiFgCXoofKLRpBbmEBHplCHc.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_0121;
				IL_0111:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
				goto IL_0121;
				IL_0121:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA.Count)
				{
					ActionElementMap actionElementMap = gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
					if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(JkHyuiFgCXoofKLRpBbmEBHplCHc))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(gZXxEqHwrHYIyUJtInpLwgTukJaY._categoryId).userAssignable, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerType, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerId, gZXxEqHwrHYIyUJtInpLwgTukJaY._id, actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
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
				LykzCYMvaNoZTDHppIDwyNVMQmRl lykzCYMvaNoZTDHppIDwyNVMQmRl;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					lykzCYMvaNoZTDHppIDwyNVMQmRl = this;
				}
				else
				{
					lykzCYMvaNoZTDHppIDwyNVMQmRl = new LykzCYMvaNoZTDHppIDwyNVMQmRl(0);
					lykzCYMvaNoZTDHppIDwyNVMQmRl.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				lykzCYMvaNoZTDHppIDwyNVMQmRl.JkHyuiFgCXoofKLRpBbmEBHplCHc = cQtxXqgBqUrChgcaDbepmAeZBhIT;
				lykzCYMvaNoZTDHppIDwyNVMQmRl.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return lykzCYMvaNoZTDHppIDwyNVMQmRl;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class vLMbFAlQwIHKIrUeNPBbZTseTMmj : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

			public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

			private ElementAssignment OtCsirUpserIPTwOvBSmQLmQSmum;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public vLMbFAlQwIHKIrUeNPBbZTseTMmj(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0123;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				if (SkVfnydpDzxVINVmPxKjrMVDeYYIA && !gZXxEqHwrHYIyUJtInpLwgTukJaY._enabled)
				{
					return false;
				}
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
				{
					return false;
				}
				OtCsirUpserIPTwOvBSmQLmQSmum = WeJFlXuVmFcPnwQYoDnnchsJRzmFA.ToElementAssignment();
				eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
				goto IL_0133;
				IL_0133:
				if (eolRghqutZOOIGqvOFTzJOGfYTsn < gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA.Count)
				{
					ActionElementMap actionElementMap = gZXxEqHwrHYIyUJtInpLwgTukJaY.SlfqpGgretWLVbgAffHfHgUMMIdFA[eolRghqutZOOIGqvOFTzJOGfYTsn];
					if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementMapId && actionElementMap.CheckForAssignmentConflict(OtCsirUpserIPTwOvBSmQLmQSmum))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(gZXxEqHwrHYIyUJtInpLwgTukJaY._categoryId).userAssignable, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerType, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerId, gZXxEqHwrHYIyUJtInpLwgTukJaY._id, actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				eolRghqutZOOIGqvOFTzJOGfYTsn++;
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
				vLMbFAlQwIHKIrUeNPBbZTseTMmj vLMbFAlQwIHKIrUeNPBbZTseTMmj2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					vLMbFAlQwIHKIrUeNPBbZTseTMmj2 = this;
				}
				else
				{
					vLMbFAlQwIHKIrUeNPBbZTseTMmj2 = new vLMbFAlQwIHKIrUeNPBbZTseTMmj(0);
					vLMbFAlQwIHKIrUeNPBbZTseTMmj2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				vLMbFAlQwIHKIrUeNPBbZTseTMmj2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
				vLMbFAlQwIHKIrUeNPBbZTseTMmj2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return vLMbFAlQwIHKIrUeNPBbZTseTMmj2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class xwSvypuVuuIKyqXcLGLFIbAbcDNBA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

			public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private IEnumerator<ActionElementMap> otVuTclWHkLrdVIElDnnPoApusjv;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public xwSvypuVuuIKyqXcLGLFIbAbcDNBA(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.AllMaps.GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					}
					while (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
					{
						ActionElementMap current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
						if (current._actionId == oRajQOHwRbMrJNwZiDDGjrEZUMQf && (!SkVfnydpDzxVINVmPxKjrMVDeYYIA || current.llkLFSoLVtaASCstwdnHCsIDxnhYb))
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
					}
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
					otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				xwSvypuVuuIKyqXcLGLFIbAbcDNBA xwSvypuVuuIKyqXcLGLFIbAbcDNBA2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					xwSvypuVuuIKyqXcLGLFIbAbcDNBA2 = this;
				}
				else
				{
					xwSvypuVuuIKyqXcLGLFIbAbcDNBA2 = new xwSvypuVuuIKyqXcLGLFIbAbcDNBA(0);
					xwSvypuVuuIKyqXcLGLFIbAbcDNBA2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				xwSvypuVuuIKyqXcLGLFIbAbcDNBA2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
				xwSvypuVuuIKyqXcLGLFIbAbcDNBA2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return xwSvypuVuuIKyqXcLGLFIbAbcDNBA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class DjLydsFzMULkiTBpNwyfqzRngEvu : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private IControllerElementTarget rVgBEjIeKffMbzgnTZciiDWgcyTG;

			public IControllerElementTarget HQhUPrZFsWAouBRHfSQZsgJAROS;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private TempListPool.TList<ActionElementMap> gmSBoszUSgWPrIbnXRKFSNxaObRj;

			private List<ActionElementMap>.Enumerator kdOQxMRxfBprWWxzhobszTGNskAP;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public DjLydsFzMULkiTBpNwyfqzRngEvu(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if ((uint)(gwbUsvLqBorYvZEWvPDttSzVhFNo - -4) > 1u && gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
				{
					return;
				}
				try
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != -4 && gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						cjHgXFFYGWhdIQKUJynxjVusYouQA();
					}
				}
				finally
				{
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						gmSBoszUSgWPrIbnXRKFSNxaObRj = TempListPool.GetTList<ActionElementMap>();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						List<ActionElementMap> list = gmSBoszUSgWPrIbnXRKFSNxaObRj.list;
						gZXxEqHwrHYIyUJtInpLwgTukJaY.DByGazdclNMniEHyXlrfkPzVFmhE(rVgBEjIeKffMbzgnTZciiDWgcyTG, false, -1, SkVfnydpDzxVINVmPxKjrMVDeYYIA, list, false, out var _);
						kdOQxMRxfBprWWxzhobszTGNskAP = list.GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
						break;
					}
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
						break;
					}
					if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
					{
						ActionElementMap current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					cjHgXFFYGWhdIQKUJynxjVusYouQA();
					kdOQxMRxfBprWWxzhobszTGNskAP = default(List<ActionElementMap>.Enumerator);
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
					gmSBoszUSgWPrIbnXRKFSNxaObRj = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (gmSBoszUSgWPrIbnXRKFSNxaObRj != null)
				{
					((IDisposable)gmSBoszUSgWPrIbnXRKFSNxaObRj).Dispose();
				}
			}

			private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
				((IDisposable)kdOQxMRxfBprWWxzhobszTGNskAP/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				DjLydsFzMULkiTBpNwyfqzRngEvu djLydsFzMULkiTBpNwyfqzRngEvu;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					djLydsFzMULkiTBpNwyfqzRngEvu = this;
				}
				else
				{
					djLydsFzMULkiTBpNwyfqzRngEvu = new DjLydsFzMULkiTBpNwyfqzRngEvu(0);
					djLydsFzMULkiTBpNwyfqzRngEvu.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				djLydsFzMULkiTBpNwyfqzRngEvu.rVgBEjIeKffMbzgnTZciiDWgcyTG = HQhUPrZFsWAouBRHfSQZsgJAROS;
				djLydsFzMULkiTBpNwyfqzRngEvu.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return djLydsFzMULkiTBpNwyfqzRngEvu;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class BldmJdiZOXtskTTzJVBWeaKBKKHB : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private IControllerElementTarget rVgBEjIeKffMbzgnTZciiDWgcyTG;

			public IControllerElementTarget HQhUPrZFsWAouBRHfSQZsgJAROS;

			private int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

			public int imPhNiAdSzPIDbaiYHKoCuSQkYkF;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private TempListPool.TList<ActionElementMap> gmSBoszUSgWPrIbnXRKFSNxaObRj;

			private List<ActionElementMap>.Enumerator kdOQxMRxfBprWWxzhobszTGNskAP;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public BldmJdiZOXtskTTzJVBWeaKBKKHB(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if ((uint)(gwbUsvLqBorYvZEWvPDttSzVhFNo - -4) > 1u && gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
				{
					return;
				}
				try
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != -4 && gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						cjHgXFFYGWhdIQKUJynxjVusYouQA();
					}
				}
				finally
				{
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					ControllerMap gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						gmSBoszUSgWPrIbnXRKFSNxaObRj = TempListPool.GetTList<ActionElementMap>();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						List<ActionElementMap> list = gmSBoszUSgWPrIbnXRKFSNxaObRj.list;
						gZXxEqHwrHYIyUJtInpLwgTukJaY.DByGazdclNMniEHyXlrfkPzVFmhE(rVgBEjIeKffMbzgnTZciiDWgcyTG, true, oRajQOHwRbMrJNwZiDDGjrEZUMQf, SkVfnydpDzxVINVmPxKjrMVDeYYIA, list, false, out var _);
						kdOQxMRxfBprWWxzhobszTGNskAP = list.GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
						break;
					}
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
						break;
					}
					if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
					{
						ActionElementMap current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					cjHgXFFYGWhdIQKUJynxjVusYouQA();
					kdOQxMRxfBprWWxzhobszTGNskAP = default(List<ActionElementMap>.Enumerator);
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
					gmSBoszUSgWPrIbnXRKFSNxaObRj = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (gmSBoszUSgWPrIbnXRKFSNxaObRj != null)
				{
					((IDisposable)gmSBoszUSgWPrIbnXRKFSNxaObRj).Dispose();
				}
			}

			private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
				((IDisposable)kdOQxMRxfBprWWxzhobszTGNskAP/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				BldmJdiZOXtskTTzJVBWeaKBKKHB bldmJdiZOXtskTTzJVBWeaKBKKHB;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					bldmJdiZOXtskTTzJVBWeaKBKKHB = this;
				}
				else
				{
					bldmJdiZOXtskTTzJVBWeaKBKKHB = new BldmJdiZOXtskTTzJVBWeaKBKKHB(0);
					bldmJdiZOXtskTTzJVBWeaKBKKHB.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				bldmJdiZOXtskTTzJVBWeaKBKKHB.rVgBEjIeKffMbzgnTZciiDWgcyTG = HQhUPrZFsWAouBRHfSQZsgJAROS;
				bldmJdiZOXtskTTzJVBWeaKBKKHB.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
				bldmJdiZOXtskTTzJVBWeaKBKKHB.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return bldmJdiZOXtskTTzJVBWeaKBKKHB;
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

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		private readonly AList<ActionElementMap> SlfqpGgretWLVbgAffHfHgUMMIdFA;

		private readonly ReadOnlyCollection<ActionElementMap> YFYTeNnSjbevktFsdHrORDIdwfYS;

		private readonly AList<ActionElementMap> bphTGVsFPTfUAOmAtmCSVDrlTdrP;

		private readonly ReadOnlyCollection<ActionElementMap> bOjpcpLgmCUoxOrnMvJJtgtXAcTO;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int QNIaCncYjQEaJUXLuulPVkBZXMlx;

		private static int YufSeXkYYuGgFwUwgPnDOhSwWduK
		{
			get
			{
				int qNIaCncYjQEaJUXLuulPVkBZXMlx = QNIaCncYjQEaJUXLuulPVkBZXMlx;
				if (QNIaCncYjQEaJUXLuulPVkBZXMlx == int.MaxValue)
				{
					QNIaCncYjQEaJUXLuulPVkBZXMlx = 0;
					return qNIaCncYjQEaJUXLuulPVkBZXMlx;
				}
				QNIaCncYjQEaJUXLuulPVkBZXMlx++;
				return qNIaCncYjQEaJUXLuulPVkBZXMlx;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return SlfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return bOjpcpLgmCUoxOrnMvJJtgtXAcTO;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return YFYTeNnSjbevktFsdHrORDIdwfYS;
			}
		}

		internal AList<ActionElementMap> fHfLawVRnAIjFLcvXQTtiXDuzgak => SlfqpGgretWLVbgAffHfHgUMMIdFA;

		public ControllerMap()
		{
			_id = YufSeXkYYuGgFwUwgPnDOhSwWduK;
			_sourceMapId = -1;
			SlfqpGgretWLVbgAffHfHgUMMIdFA = new AList<ActionElementMap>();
			YFYTeNnSjbevktFsdHrORDIdwfYS = new ReadOnlyCollection<ActionElementMap>(SlfqpGgretWLVbgAffHfHgUMMIdFA);
			bphTGVsFPTfUAOmAtmCSVDrlTdrP = new AList<ActionElementMap>();
			bOjpcpLgmCUoxOrnMvJJtgtXAcTO = new ReadOnlyCollection<ActionElementMap>(bphTGVsFPTfUAOmAtmCSVDrlTdrP);
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = YufSeXkYYuGgFwUwgPnDOhSwWduK;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			if (P_0.SlfqpGgretWLVbgAffHfHgUMMIdFA != null)
			{
				int count = P_0.SlfqpGgretWLVbgAffHfHgUMMIdFA.Count;
				for (int i = 0; i < count; i++)
				{
					NcSfHLizhYUfENhzWbDscqhtySGC(new ActionElementMap(P_0.SlfqpGgretWLVbgAffHfHgUMMIdFA[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			InputAction inputAction = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.tcSJxzCVlgQKAcLFeGJqBHMyePYq(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			AList<ActionElementMap> aList = bphTGVsFPTfUAOmAtmCSVDrlTdrP;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bphTGVsFPTfUAOmAtmCSVDrlTdrP[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			AList<ActionElementMap> aList = bphTGVsFPTfUAOmAtmCSVDrlTdrP;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bphTGVsFPTfUAOmAtmCSVDrlTdrP[i].keyCode == keyCode && bphTGVsFPTfUAOmAtmCSVDrlTdrP[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = bphTGVsFPTfUAOmAtmCSVDrlTdrP;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bphTGVsFPTfUAOmAtmCSVDrlTdrP[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			AList<ActionElementMap> aList = bphTGVsFPTfUAOmAtmCSVDrlTdrP;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bphTGVsFPTfUAOmAtmCSVDrlTdrP[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, DXYiJElpUHxcPboaihvPaElwMWxMA.aCQAIhcPWADBaJBnivAKwIRUgnHRA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.OkYVVItyDNIRrZjZSvdPINJLnmkM(this, actionElementMap);
			NcSfHLizhYUfENhzWbDscqhtySGC(actionElementMap);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			xaijMTONWGaQwpgcGMXwxXYSGTBf xaijMTONWGaQwpgcGMXwxXYSGTBf2 = xaijMTONWGaQwpgcGMXwxXYSGTBf.NTxAmacLUGlIUyGmoNWhlsCBEOtgA(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, xaijMTONWGaQwpgcGMXwxXYSGTBf2.nzfZvDQnXKqkICFGlyOrPWOlmguD, xaijMTONWGaQwpgcGMXwxXYSGTBf2.YTTRFWBQsmcWJbGBSbSislQmCzHgA, xaijMTONWGaQwpgcGMXwxXYSGTBf2.cEzMDCmFUSaoGnwAGIGDxrRWOOsj, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			NcSfHLizhYUfENhzWbDscqhtySGC(actionElementMap);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, DXYiJElpUHxcPboaihvPaElwMWxMA.aCQAIhcPWADBaJBnivAKwIRUgnHRA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (gjbMfZxbTjGXsCEugRNrrmIqlhFBA(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				NcSfHLizhYUfENhzWbDscqhtySGC(elementMap);
			}
			if (gjbMfZxbTjGXsCEugRNrrmIqlhFBA(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.OkYVVItyDNIRrZjZSvdPINJLnmkM(this, elementMap);
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
			xaijMTONWGaQwpgcGMXwxXYSGTBf xaijMTONWGaQwpgcGMXwxXYSGTBf2 = xaijMTONWGaQwpgcGMXwxXYSGTBf.NTxAmacLUGlIUyGmoNWhlsCBEOtgA(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, xaijMTONWGaQwpgcGMXwxXYSGTBf2.nzfZvDQnXKqkICFGlyOrPWOlmguD, xaijMTONWGaQwpgcGMXwxXYSGTBf2.YTTRFWBQsmcWJbGBSbSislQmCzHgA, xaijMTONWGaQwpgcGMXwxXYSGTBf2.cEzMDCmFUSaoGnwAGIGDxrRWOOsj, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementType))
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
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				NcSfHLizhYUfENhzWbDscqhtySGC(elementMap);
			}
			if (gjbMfZxbTjGXsCEugRNrrmIqlhFBA(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			ZrtIahhmIxYEsjoTmVZvDNbEDnp(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int num = gjbMfZxbTjGXsCEugRNrrmIqlhFBA(elementMapId);
			if (num < 0)
			{
				return false;
			}
			uggTQuuevCAFDgmIPNsrumVdaXmf(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == elementMapId)
				{
					return SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (!skipDisabledMaps || allMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return FypTeLaodvFAxEmfQucQyrphhmyc(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return zwdxASlITbuZpVbhYqYmCmlNvatv(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new xwSvypuVuuIKyqXcLGLFIbAbcDNBA(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._actionId == actionId && (!skipDisabledMaps || SlfqpGgretWLVbgAffHfHgUMMIdFA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					return SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, skipDisabledMaps);
			xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new DjLydsFzMULkiTBpNwyfqzRngEvu(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				HQhUPrZFsWAouBRHfSQZsgJAROS = elementTarget,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, actionId, skipDisabledMaps);
			xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new BldmJdiZOXtskTTzJVBWeaKBKKHB(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				HQhUPrZFsWAouBRHfSQZsgJAROS = elementTarget,
				imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, skipDisabledMaps);
			xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			bool flag;
			return XVBIGuwjdUxtMPnVgYILXbpHJhcM(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, actionId, skipDisabledMaps);
			xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			bool flag;
			return XVBIGuwjdUxtMPnVgYILXbpHJhcM(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, skipDisabledMaps, results);
			xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			bool flag;
			return DByGazdclNMniEHyXlrfkPzVFmhE(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			xExZPlwOYSQiIkFqHDDyWovrVnsK xExZPlwOYSQiIkFqHDDyWovrVnsK2 = xExZPlwOYSQiIkFqHDDyWovrVnsK.CadQRsOQEKbSlMKveBVLdGfIYlpR(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(xExZPlwOYSQiIkFqHDDyWovrVnsK2, actionId, skipDisabledMaps, results);
			xExZPlwOYSQiIkFqHDDyWovrVnsK.NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			bool flag;
			return DByGazdclNMniEHyXlrfkPzVFmhE(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return RonMLbkNpJKdGqSoGRzVuzLDUssH(predicate, false);
		}

		internal virtual ActionElementMap RonMLbkNpJKdGqSoGRzVuzLDUssH(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return EHfuHvLoEGlGGcynGzLpfkEaTAgc(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return jCSFvuasncGvDlZRjYaiaOdTjdOEb(predicate, false, results, false);
		}

		internal virtual int jCSFvuasncGvDlZRjYaiaOdTjdOEb(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return sBPGGVcViOjceNysqDKLethmLGUn(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			int count = bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = bphTGVsFPTfUAOmAtmCSVDrlTdrP[i];
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			SlfqpGgretWLVbgAffHfHgUMMIdFA.Clear();
			bphTGVsFPTfUAOmAtmCSVDrlTdrP.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int num = 0;
			int count = bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = bphTGVsFPTfUAOmAtmCSVDrlTdrP[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb != state)
				{
					actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null || index < 0 || index >= SlfqpGgretWLVbgAffHfHgUMMIdFA.Count)
			{
				return null;
			}
			return SlfqpGgretWLVbgAffHfHgUMMIdFA[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(SlfqpGgretWLVbgAffHfHgUMMIdFA);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return MYrBChDMUlgPMPsWcihgWAfNgFfbb(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.tcSJxzCVlgQKAcLFeGJqBHMyePYq(actionName, true);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.tcSJxzCVlgQKAcLFeGJqBHMyePYq(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
				ActionElementMap actionElementMap2 = SlfqpGgretWLVbgAffHfHgUMMIdFA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			InputAction inputAction = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.tcSJxzCVlgQKAcLFeGJqBHMyePYq(actionName, true);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			InputAction inputAction = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.tcSJxzCVlgQKAcLFeGJqBHMyePYq(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return IAFaiPDVSznVecIdjDdpGufUQUZb(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return ButtonMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new ZLNTCQapqrkkWyMwUQRrGQOlfJlF(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return EHfuHvLoEGlGGcynGzLpfkEaTAgc(predicate, false);
		}

		internal ActionElementMap EHfuHvLoEGlGGcynGzLpfkEaTAgc(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sBPGGVcViOjceNysqDKLethmLGUn(predicate, false, results, false);
		}

		internal int sBPGGVcViOjceNysqDKLethmLGUn(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			int count = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
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
			return DeleteButtonMapsWithAction(ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					uggTQuuevCAFDgmIPNsrumVdaXmf(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int num = 0;
			int count = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb != state)
				{
					actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb = state;
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (skipDisabledMaps && !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (actionElementMap == null || SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
			{
				return false;
			}
			for (int i = 0; i < SlfqpGgretWLVbgAffHfHgUMMIdFA.Count; i++)
			{
				ActionElementMap actionElementMap2 = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
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
			for (int i = 0; i < SlfqpGgretWLVbgAffHfHgUMMIdFA.Count; i++)
			{
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if ((!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			return new cfXHGHRaAFcZTTsmnDSiZEkMGQpkA(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				gaBeQySvDEkRFhRLfUogfFxSYGFm = controllerMap,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new LykzCYMvaNoZTDHppIDwyNVMQmRl(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				cQtxXqgBqUrChgcaDbepmAeZBhIT = actionElementMap,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new vLMbFAlQwIHKIrUeNPBbZTseTMmj(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				FCYmIzsyhgDFawLsaVlrNOiKvCgn = conflictCheck,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return num;
			}
			IList<ActionElementMap> slfqpGgretWLVbgAffHfHgUMMIdFA = controllerMap.SlfqpGgretWLVbgAffHfHgUMMIdFA;
			if (slfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = slfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			for (int num2 = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[num2];
				if (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || slfqpGgretWLVbgAffHfHgUMMIdFA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(slfqpGgretWLVbgAffHfHgUMMIdFA[i]))
						{
							uggTQuuevCAFDgmIPNsrumVdaXmf(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return num;
			}
			for (int num2 = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = SlfqpGgretWLVbgAffHfHgUMMIdFA[num2];
				if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					uggTQuuevCAFDgmIPNsrumVdaXmf(actionElementMap2.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
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
			for (int num2 = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[num2];
				if ((!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					uggTQuuevCAFDgmIPNsrumVdaXmf(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sWqUNaVaNBJPqcgsUJCHjBMovBmz(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sWqUNaVaNBJPqcgsUJCHjBMovBmz(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sWqUNaVaNBJPqcgsUJCHjBMovBmz(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sWqUNaVaNBJPqcgsUJCHjBMovBmz(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sWqUNaVaNBJPqcgsUJCHjBMovBmz(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return sWqUNaVaNBJPqcgsUJCHjBMovBmz(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return num;
			}
			IList<ActionElementMap> slfqpGgretWLVbgAffHfHgUMMIdFA = P_0.SlfqpGgretWLVbgAffHfHgUMMIdFA;
			if (slfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = slfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (!actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = slfqpGgretWLVbgAffHfHgUMMIdFA[j];
					if ((!P_1 || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int sWqUNaVaNBJPqcgsUJCHjBMovBmz(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int sWqUNaVaNBJPqcgsUJCHjBMovBmz(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (bphTGVsFPTfUAOmAtmCSVDrlTdrP == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.bphTGVsFPTfUAOmAtmCSVDrlTdrP;
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
			for (int num2 = bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = bphTGVsFPTfUAOmAtmCSVDrlTdrP[num2];
				if (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(list[i]))
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
			if (bphTGVsFPTfUAOmAtmCSVDrlTdrP == null)
			{
				return num;
			}
			for (int num2 = bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = bphTGVsFPTfUAOmAtmCSVDrlTdrP[num2];
				if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (bphTGVsFPTfUAOmAtmCSVDrlTdrP == null)
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
			for (int num2 = bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = bphTGVsFPTfUAOmAtmCSVDrlTdrP[num2];
				if ((!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				array[i] = SlfqpGgretWLVbgAffHfHgUMMIdFA[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return string.Empty;
			}
			try
			{
				return OwZlvwNnIfDEsAMweyvGbtLoYQJtA().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return string.Empty;
			}
			try
			{
				return OwZlvwNnIfDEsAMweyvGbtLoYQJtA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.wgDfcpFFKvqeeKkPsJPdHHqsdbZZA(templateTypeGuid);
				string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.AnbJyIviMxdyjeorIFdTSYjhrGvh(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			return ControllerTemplateMap.AnbJyIviMxdyjeorIFdTSYjhrGvh(controllerTemplate, this);
		}

		private ControllerTemplateMap oKBKVEIzNCapqdIgxAUzoKSmASoCA(IControllerTemplate P_0)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.AnbJyIviMxdyjeorIFdTSYjhrGvh(P_0, this);
		}

		internal virtual bool gWhjoTRNRldWcTlFdhKHpqWCipZj(ActionElementMap P_0)
		{
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0._elementType))
			{
				return false;
			}
			NcSfHLizhYUfENhzWbDscqhtySGC(P_0);
			return true;
		}

		internal virtual int FypTeLaodvFAxEmfQucQyrphhmyc(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = SlfqpGgretWLVbgAffHfHgUMMIdFA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || SlfqpGgretWLVbgAffHfHgUMMIdFA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					P_0.Add(SlfqpGgretWLVbgAffHfHgUMMIdFA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap qUEPKPvkMFttTKBFyJTdYJlytPmN(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_2))
			{
				return null;
			}
			int num = oAGjXWxtieiPDWaUxbBGdPcPAtcsA(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return SlfqpGgretWLVbgAffHfHgUMMIdFA[num];
		}

		internal virtual int PEwFZaChDbchEucRIZNOWilLQAcJ(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(SlfqpGgretWLVbgAffHfHgUMMIdFA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool VXUvTtrVTpEhfzkNENjDZPkaAeTk(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._elementIdentifierId == P_0 && SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int oAGjXWxtieiPDWaUxbBGdPcPAtcsA(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_2))
			{
				return -1;
			}
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._elementIdentifierId == P_0 && SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int gjbMfZxbTjGXsCEugRNrrmIqlhFBA(int P_0)
		{
			if (SlfqpGgretWLVbgAffHfHgUMMIdFA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int MYrBChDMUlgPMPsWcihgWAfNgFfbb(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (!P_0 || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int IAFaiPDVSznVecIdjDdpGufUQUZb(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int zwdxASlITbuZpVbhYqYmCmlNvatv(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap XVBIGuwjdUxtMPnVgYILXbpHJhcM(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!lDpVuQgSUvdRPxnJAdvkDGOeHIwUA(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._actionId == P_2) && (!P_3 || SlfqpGgretWLVbgAffHfHgUMMIdFA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb) && SlfqpGgretWLVbgAffHfHgUMMIdFA[i].IsTarget(P_0))
				{
					return SlfqpGgretWLVbgAffHfHgUMMIdFA[i];
				}
			}
			return null;
		}

		internal virtual int DByGazdclNMniEHyXlrfkPzVFmhE(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!lDpVuQgSUvdRPxnJAdvkDGOeHIwUA(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || SlfqpGgretWLVbgAffHfHgUMMIdFA[i]._actionId == P_2) && (!P_3 || SlfqpGgretWLVbgAffHfHgUMMIdFA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb) && SlfqpGgretWLVbgAffHfHgUMMIdFA[i].IsTarget(P_0))
				{
					P_4.Add(SlfqpGgretWLVbgAffHfHgUMMIdFA[i]);
					num++;
				}
			}
			return num;
		}

		internal void ItoekDNGrRnXcNalqdEOaVLijYodA(int P_0, ControllerElementType P_1)
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
				GyVpFotNIqdiYVGDDCqmhxxpOwJuA(elementMap);
			}
		}

		internal virtual bool GyVpFotNIqdiYVGDDCqmhxxpOwJuA(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0._elementType))
			{
				return false;
			}
			SlfqpGgretWLVbgAffHfHgUMMIdFA.Add(P_0);
			hIEtbwrFIIEqlrpiphrHFXIOwruhA(P_0);
			return true;
		}

		internal bool lDpVuQgSUvdRPxnJAdvkDGOeHIwUA(IControllerElementTarget P_0)
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

		internal bool AKoiGBWTSOgKxCCVfbEbkmuDWlgqA(string P_0)
		{
			try
			{
				xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool WqkzUgQGMPNMmYMhyoCrrrilwIbc(string P_0)
		{
			try
			{
				xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void hIEtbwrFIIEqlrpiphrHFXIOwruhA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				bphTGVsFPTfUAOmAtmCSVDrlTdrP.Add(P_0);
				bphTGVsFPTfUAOmAtmCSVDrlTdrP.Sort(tIJFOWMdHGaXZBsAyCSncWwVwLgbA.ccczNqsNLdBVbHnxRjOzBZTknCGZ);
			}
		}

		internal void joHyuKrTbmJjdnZpnGwJorcRRFvL(int P_0)
		{
			int num = vJgUGIsKsSrofzqIpptfOHenMvCk(P_0);
			if (num >= 0)
			{
				bphTGVsFPTfUAOmAtmCSVDrlTdrP.RemoveAt(num);
			}
		}

		internal void qFsvJwABwnghwTSPDhITCaiDdtOSA(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = vJgUGIsKsSrofzqIpptfOHenMvCk(P_0);
				if (num >= 0)
				{
					bphTGVsFPTfUAOmAtmCSVDrlTdrP[num] = P_1;
					bphTGVsFPTfUAOmAtmCSVDrlTdrP.Sort(tIJFOWMdHGaXZBsAyCSncWwVwLgbA.ccczNqsNLdBVbHnxRjOzBZTknCGZ);
				}
			}
		}

		internal static void ZrtIahhmIxYEsjoTmVZvDNbEDnp(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
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
				ReInput.controllers.GetController(_controllerType, _controllerId)?.OkYVVItyDNIRrZjZSvdPINJLnmkM(this, map);
			}
		}

		internal virtual bool xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
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
						actionElementMap.xIgDRHQmTOVJkRVsknhXpBHuPygR(value2);
						if (ActionElementMap.RgypiEzrKNlXmJDSoHMwaLTKYTNS(actionElementMap))
						{
							NcSfHLizhYUfENhzWbDscqhtySGC(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void tnEqLMFFwugjoHOyMvcImNymgKGl(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "dataVersion",
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
				{
					DBsVPUbyEmkoGqiATtBbUGsLwABr = "hardwareGuid",
					pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
				{
					DBsVPUbyEmkoGqiATtBbUGsLwABr = "hardwareName",
					pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = pWbMhcBQKZEHHDwvEOhqpAUJhzfpA
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				zgPaEzAbwsGcNWlXnJVzKkGnHIbhb = "xmlns",
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "xsi",
				OTermNiKyMWnSeUawIBObeynBxKj = null,
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				zgPaEzAbwsGcNWlXnJVzKkGnHIbhb = "xsi",
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "schemaLocation",
				OTermNiKyMWnSeUawIBObeynBxKj = null,
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (SlfqpGgretWLVbgAffHfHgUMMIdFA[i] != null)
				{
					list.Add(SlfqpGgretWLVbgAffHfHgUMMIdFA[i].OwZlvwNnIfDEsAMweyvGbtLoYQJtA());
				}
			}
		}

		private bool xpaHEEmovzSZludOYCvBdjOwVMINA(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void uggTQuuevCAFDgmIPNsrumVdaXmf(int P_0, int P_1)
		{
			joHyuKrTbmJjdnZpnGwJorcRRFvL(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				SlfqpGgretWLVbgAffHfHgUMMIdFA.RemoveAt(P_1);
			}
		}

		private void NcSfHLizhYUfENhzWbDscqhtySGC(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				SlfqpGgretWLVbgAffHfHgUMMIdFA.Add(P_0);
				hIEtbwrFIIEqlrpiphrHFXIOwruhA(P_0);
			}
		}

		private void TtuktjOOQbbkPGkBmivGPKznAyqWA(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				qFsvJwABwnghwTSPDhITCaiDdtOSA(SlfqpGgretWLVbgAffHfHgUMMIdFA[P_1].HZrDwOTOuvYGJkZRWDMDnUPlFNTs, P_0);
				SlfqpGgretWLVbgAffHfHgUMMIdFA[P_1] = P_0;
			}
		}

		private int vJgUGIsKsSrofzqIpptfOHenMvCk(int P_0)
		{
			if (bphTGVsFPTfUAOmAtmCSVDrlTdrP == null)
			{
				return -1;
			}
			int count = bphTGVsFPTfUAOmAtmCSVDrlTdrP.Count;
			for (int i = 0; i < count; i++)
			{
				if (bphTGVsFPTfUAOmAtmCSVDrlTdrP[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject OwZlvwNnIfDEsAMweyvGbtLoYQJtA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			tnEqLMFFwugjoHOyMvcImNymgKGl(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap goGesjEFofcTayLyzynfoITRPCBk(ControllerType P_0)
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

		internal static ControllerMap WzvmTWEFCkKUnRYLvufrwGixUEhp(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = goGesjEFofcTayLyzynfoITRPCBk(controllerType);
			try
			{
				controllerMap.AKoiGBWTSOgKxCCVfbEbkmuDWlgqA(xmlString);
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
			ControllerMap controllerMap = goGesjEFofcTayLyzynfoITRPCBk(controllerType);
			try
			{
				controllerMap.WqkzUgQGMPNMmYMhyoCrrrilwIbc(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
