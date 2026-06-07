using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerMapWithAxes : ControllerMap
	{
		private sealed class MQqaWDFNgAWrVfNintwfrMAVCTXt : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ActionElementMap USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMapWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

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
			public MQqaWDFNgAWrVfNintwfrMAVCTXt(int P_0)
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
					ControllerMapWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
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
						if (oRajQOHwRbMrJNwZiDDGjrEZUMQf < 0)
						{
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.AxisMaps.GetEnumerator();
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
				MQqaWDFNgAWrVfNintwfrMAVCTXt mQqaWDFNgAWrVfNintwfrMAVCTXt;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					mQqaWDFNgAWrVfNintwfrMAVCTXt = this;
				}
				else
				{
					mQqaWDFNgAWrVfNintwfrMAVCTXt = new MQqaWDFNgAWrVfNintwfrMAVCTXt(0);
					mQqaWDFNgAWrVfNintwfrMAVCTXt.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				mQqaWDFNgAWrVfNintwfrMAVCTXt.oRajQOHwRbMrJNwZiDDGjrEZUMQf = imPhNiAdSzPIDbaiYHKoCuSQkYkF;
				mQqaWDFNgAWrVfNintwfrMAVCTXt.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return mQqaWDFNgAWrVfNintwfrMAVCTXt;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class UglawBhpjFoNEjiDwNvzzggKeOgz : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMapWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private ControllerMap bCyRjgRlhEVQenEXvcdthvtYiSbS;

			public ControllerMap gaBeQySvDEkRFhRLfUogfFxSYGFm;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private IList<ActionElementMap> WzDfSucMhnOOxDPQAAdGoPCEiNbpE;

			private int EvVtLykcKkWsKUacotsBslzWbUsy;

			private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

			private int rTWcoAkXzojjYIxHEZYFNxnJpLMC;

			private ActionElementMap jHhCVmwBBLDnKkFkBprSHkSOOkndb;

			private int CvEbIJnzztnOHpNEfWcAJTRohMvK;

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
			public UglawBhpjFoNEjiDwNvzzggKeOgz(int P_0)
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
					ControllerMapWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
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
						if (bCyRjgRlhEVQenEXvcdthvtYiSbS == null)
						{
							return false;
						}
						mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = ((ControllerMap)gZXxEqHwrHYIyUJtInpLwgTukJaY).ElementAssignmentConflicts(bCyRjgRlhEVQenEXvcdthvtYiSbS, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00af;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00af;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_0232;
						}
						IL_0244:
						if (CvEbIJnzztnOHpNEfWcAJTRohMvK < EvVtLykcKkWsKUacotsBslzWbUsy)
						{
							ActionElementMap actionElementMap = WzDfSucMhnOOxDPQAAdGoPCEiNbpE[CvEbIJnzztnOHpNEfWcAJTRohMvK];
							if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && jHhCVmwBBLDnKkFkBprSHkSOOkndb.CheckForAssignmentConflict(actionElementMap))
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(gZXxEqHwrHYIyUJtInpLwgTukJaY._categoryId).userAssignable, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerType, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerId, gZXxEqHwrHYIyUJtInpLwgTukJaY._id, jHhCVmwBBLDnKkFkBprSHkSOOkndb.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, jHhCVmwBBLDnKkFkBprSHkSOOkndb._actionId, jHhCVmwBBLDnKkFkBprSHkSOOkndb._elementType, jHhCVmwBBLDnKkFkBprSHkSOOkndb._elementIdentifierId, jHhCVmwBBLDnKkFkBprSHkSOOkndb.keyCode, jHhCVmwBBLDnKkFkBprSHkSOOkndb.modifierKeyFlags);
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
								return true;
							}
							goto IL_0232;
						}
						jHhCVmwBBLDnKkFkBprSHkSOOkndb = null;
						goto IL_025c;
						IL_0232:
						CvEbIJnzztnOHpNEfWcAJTRohMvK++;
						goto IL_0244;
						IL_026e:
						if (rTWcoAkXzojjYIxHEZYFNxnJpLMC < gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA.Count)
						{
							jHhCVmwBBLDnKkFkBprSHkSOOkndb = gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA[rTWcoAkXzojjYIxHEZYFNxnJpLMC];
							if (!SkVfnydpDzxVINVmPxKjrMVDeYYIA || jHhCVmwBBLDnKkFkBprSHkSOOkndb.llkLFSoLVtaASCstwdnHCsIDxnhYb)
							{
								CvEbIJnzztnOHpNEfWcAJTRohMvK = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
						{
							ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
						if (!(bCyRjgRlhEVQenEXvcdthvtYiSbS is ControllerMapWithAxes controllerMapWithAxes))
						{
							return false;
						}
						if (SkVfnydpDzxVINVmPxKjrMVDeYYIA && (!gZXxEqHwrHYIyUJtInpLwgTukJaY._enabled || !controllerMapWithAxes._enabled))
						{
							return false;
						}
						WzDfSucMhnOOxDPQAAdGoPCEiNbpE = controllerMapWithAxes.AxisMaps;
						if (WzDfSucMhnOOxDPQAAdGoPCEiNbpE == null)
						{
							return false;
						}
						EvVtLykcKkWsKUacotsBslzWbUsy = WzDfSucMhnOOxDPQAAdGoPCEiNbpE.Count;
						rTWcoAkXzojjYIxHEZYFNxnJpLMC = 0;
						goto IL_026e;
						IL_025c:
						rTWcoAkXzojjYIxHEZYFNxnJpLMC++;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
				{
					mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
				UglawBhpjFoNEjiDwNvzzggKeOgz uglawBhpjFoNEjiDwNvzzggKeOgz;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					uglawBhpjFoNEjiDwNvzzggKeOgz = this;
				}
				else
				{
					uglawBhpjFoNEjiDwNvzzggKeOgz = new UglawBhpjFoNEjiDwNvzzggKeOgz(0);
					uglawBhpjFoNEjiDwNvzzggKeOgz.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				uglawBhpjFoNEjiDwNvzzggKeOgz.bCyRjgRlhEVQenEXvcdthvtYiSbS = gaBeQySvDEkRFhRLfUogfFxSYGFm;
				uglawBhpjFoNEjiDwNvzzggKeOgz.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return uglawBhpjFoNEjiDwNvzzggKeOgz;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class PsiEbcCbZEokxOFsLsUeprbWVTDMA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMapWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private ActionElementMap JkHyuiFgCXoofKLRpBbmEBHplCHc;

			public ActionElementMap cQtxXqgBqUrChgcaDbepmAeZBhIT;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private IEnumerator<ElementAssignmentConflictInfo> otVuTclWHkLrdVIElDnnPoApusjv;

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
			public PsiEbcCbZEokxOFsLsUeprbWVTDMA(int P_0)
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
					ControllerMapWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
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
						if (JkHyuiFgCXoofKLRpBbmEBHplCHc == null)
						{
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = ((ControllerMap)gZXxEqHwrHYIyUJtInpLwgTukJaY).ElementAssignmentConflicts(JkHyuiFgCXoofKLRpBbmEBHplCHc, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00ad;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00ad;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
						{
							ElementAssignmentConflictInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						otVuTclWHkLrdVIElDnnPoApusjv = null;
						if (SkVfnydpDzxVINVmPxKjrMVDeYYIA && (!gZXxEqHwrHYIyUJtInpLwgTukJaY._enabled || !JkHyuiFgCXoofKLRpBbmEBHplCHc.llkLFSoLVtaASCstwdnHCsIDxnhYb))
						{
							return false;
						}
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
						{
							return false;
						}
						eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
						goto IL_01bb;
						IL_01bb:
						if (eolRghqutZOOIGqvOFTzJOGfYTsn < gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA.Count)
						{
							ActionElementMap actionElementMap = gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA[eolRghqutZOOIGqvOFTzJOGfYTsn];
							if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(JkHyuiFgCXoofKLRpBbmEBHplCHc))
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(gZXxEqHwrHYIyUJtInpLwgTukJaY._categoryId).userAssignable, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerType, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerId, gZXxEqHwrHYIyUJtInpLwgTukJaY._id, actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						eolRghqutZOOIGqvOFTzJOGfYTsn++;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				PsiEbcCbZEokxOFsLsUeprbWVTDMA psiEbcCbZEokxOFsLsUeprbWVTDMA;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					psiEbcCbZEokxOFsLsUeprbWVTDMA = this;
				}
				else
				{
					psiEbcCbZEokxOFsLsUeprbWVTDMA = new PsiEbcCbZEokxOFsLsUeprbWVTDMA(0);
					psiEbcCbZEokxOFsLsUeprbWVTDMA.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				psiEbcCbZEokxOFsLsUeprbWVTDMA.JkHyuiFgCXoofKLRpBbmEBHplCHc = cQtxXqgBqUrChgcaDbepmAeZBhIT;
				psiEbcCbZEokxOFsLsUeprbWVTDMA.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return psiEbcCbZEokxOFsLsUeprbWVTDMA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class plVKywTUknjQJzhGtgpBXekcbhMn : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerMapWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

			public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

			private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

			public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

			private ElementAssignment OtCsirUpserIPTwOvBSmQLmQSmum;

			private IEnumerator<ElementAssignmentConflictInfo> kdOQxMRxfBprWWxzhobszTGNskAP;

			private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

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
			public plVKywTUknjQJzhGtgpBXekcbhMn(int P_0)
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
					ControllerMapWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
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
						kdOQxMRxfBprWWxzhobszTGNskAP = ((ControllerMap)gZXxEqHwrHYIyUJtInpLwgTukJaY).ElementAssignmentConflicts(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA).GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_009e;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_009e;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (AEpFbNhiazpfukEJmuNHcDAbfQLWA < gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA.Count)
						{
							ActionElementMap actionElementMap = gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA[AEpFbNhiazpfukEJmuNHcDAbfQLWA];
							if ((!SkVfnydpDzxVINVmPxKjrMVDeYYIA || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementMapId && actionElementMap.CheckForAssignmentConflict(OtCsirUpserIPTwOvBSmQLmQSmum))
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(gZXxEqHwrHYIyUJtInpLwgTukJaY._categoryId).userAssignable, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerType, gZXxEqHwrHYIyUJtInpLwgTukJaY._controllerId, gZXxEqHwrHYIyUJtInpLwgTukJaY._id, actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
						{
							ElementAssignmentConflictInfo current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						kdOQxMRxfBprWWxzhobszTGNskAP = null;
						if (SkVfnydpDzxVINVmPxKjrMVDeYYIA && !gZXxEqHwrHYIyUJtInpLwgTukJaY._enabled)
						{
							return false;
						}
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
						{
							return false;
						}
						OtCsirUpserIPTwOvBSmQLmQSmum = WeJFlXuVmFcPnwQYoDnnchsJRzmFA.ToElementAssignment();
						AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
						goto IL_01c7;
						IL_01b5:
						AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
				{
					kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
				plVKywTUknjQJzhGtgpBXekcbhMn plVKywTUknjQJzhGtgpBXekcbhMn2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					plVKywTUknjQJzhGtgpBXekcbhMn2 = this;
				}
				else
				{
					plVKywTUknjQJzhGtgpBXekcbhMn2 = new plVKywTUknjQJzhGtgpBXekcbhMn(0);
					plVKywTUknjQJzhGtgpBXekcbhMn2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				plVKywTUknjQJzhGtgpBXekcbhMn2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
				plVKywTUknjQJzhGtgpBXekcbhMn2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
				return plVKywTUknjQJzhGtgpBXekcbhMn2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> IBcBfWcjSFIsjpqtymOgqKeddGELA;

		private readonly ReadOnlyCollection<ActionElementMap> voxtTVPClYMQGCHMWJNLATOZaOfL;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
				{
					return 0;
				}
				return IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return voxtTVPClYMQGCHMWJNLATOZaOfL;
			}
		}

		internal AList<ActionElementMap> GPlzLcAOtWAUBGwtdgGxSZUwAxXqA => (AList<ActionElementMap>)IBcBfWcjSFIsjpqtymOgqKeddGELA;

		public ControllerMapWithAxes()
		{
			IBcBfWcjSFIsjpqtymOgqKeddGELA = new AList<ActionElementMap>();
			voxtTVPClYMQGCHMWJNLATOZaOfL = new ReadOnlyCollection<ActionElementMap>(IBcBfWcjSFIsjpqtymOgqKeddGELA);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			IBcBfWcjSFIsjpqtymOgqKeddGELA = new AList<ActionElementMap>();
			voxtTVPClYMQGCHMWJNLATOZaOfL = new ReadOnlyCollection<ActionElementMap>(IBcBfWcjSFIsjpqtymOgqKeddGELA);
			if (P_0.IBcBfWcjSFIsjpqtymOgqKeddGELA != null)
			{
				int count = P_0.IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
				for (int i = 0; i < count; i++)
				{
					CpoMvrShTlXntBmNCebSkyGOtesY(new ActionElementMap(P_0.IBcBfWcjSFIsjpqtymOgqKeddGELA[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return false;
			}
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			CpoMvrShTlXntBmNCebSkyGOtesY(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				CpoMvrShTlXntBmNCebSkyGOtesY(elementMap);
			}
			if (MYxEriPiRVntYqCxCNscIhpygsOeA(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.ZrtIahhmIxYEsjoTmVZvDNbEDnp(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = MYxEriPiRVntYqCxCNscIhpygsOeA(elementMapId);
			if (num < 0)
			{
				return false;
			}
			qeVDFUbQvrDFHDxanyLsbhgRmUUW(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return null;
			}
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == elementMapId)
				{
					return IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal override ActionElementMap RonMLbkNpJKdGqSoGRzVuzLDUssH(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.RonMLbkNpJKdGqSoGRzVuzLDUssH(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return xVlGbfcHLRDJSwKLFvHFWoYWUmEgA(P_0, P_1);
		}

		internal override int jCSFvuasncGvDlZRjYaiaOdTjdOEb(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.jCSFvuasncGvDlZRjYaiaOdTjdOEb(P_0, P_1, P_2, P_3) + fkrUGDJiKqeRxHmGHgPdGAScIHzJb(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			base.ClearElementMaps();
			IBcBfWcjSFIsjpqtymOgqKeddGELA.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null || index < 0 || index >= IBcBfWcjSFIsjpqtymOgqKeddGELA.Count)
			{
				return null;
			}
			return IBcBfWcjSFIsjpqtymOgqKeddGELA[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(IBcBfWcjSFIsjpqtymOgqKeddGELA);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return RDpuoEAXlwKQKwcmzIohguXDwGrFA(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
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
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
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
			int num = axisMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
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
				ActionElementMap actionElementMap2 = IBcBfWcjSFIsjpqtymOgqKeddGELA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return AInCQcdygmFlEHaSEZaUCkYWhGekc(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new MQqaWDFNgAWrVfNintwfrMAVCTXt(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				imPhNiAdSzPIDbaiYHKoCuSQkYkF = actionId,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
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
			IList<ActionElementMap> axisMaps = AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int actionId = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return xVlGbfcHLRDJSwKLFvHFWoYWUmEgA(predicate, false);
		}

		internal ActionElementMap xVlGbfcHLRDJSwKLFvHFWoYWUmEgA(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			return fkrUGDJiKqeRxHmGHgPdGAScIHzJb(predicate, false, results, false);
		}

		internal int fkrUGDJiKqeRxHmGHgPdGAScIHzJb(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
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
			return DeleteAxisMapsWithAction(ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
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
			int num = axisMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA[num2] != null && IBcBfWcjSFIsjpqtymOgqKeddGELA[num2]._actionId == actionId)
				{
					qeVDFUbQvrDFHDxanyLsbhgRmUUW(IBcBfWcjSFIsjpqtymOgqKeddGELA[num2].HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int num = 0;
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb != state)
				{
					actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (skipDisabledMaps && !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
			{
				return false;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return false;
			}
			for (int i = 0; i < IBcBfWcjSFIsjpqtymOgqKeddGELA.Count; i++)
			{
				ActionElementMap actionElementMap2 = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < IBcBfWcjSFIsjpqtymOgqKeddGELA.Count; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if ((!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new UglawBhpjFoNEjiDwNvzzggKeOgz(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				gaBeQySvDEkRFhRLfUogfFxSYGFm = controllerMap,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new PsiEbcCbZEokxOFsLsUeprbWVTDMA(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				cQtxXqgBqUrChgcaDbepmAeZBhIT = actionElementMap,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new plVKywTUknjQJzhGtgpBXekcbhMn(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				FCYmIzsyhgDFawLsaVlrNOiKvCgn = conflictCheck,
				XrxFLJTgUPTsBtuHGrpvxRqvDedI = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
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
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
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
			_ = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			int count = axisMaps.Count;
			for (int num2 = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[num2];
				if (!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							qeVDFUbQvrDFHDxanyLsbhgRmUUW(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return num;
			}
			for (int num2 = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = IBcBfWcjSFIsjpqtymOgqKeddGELA[num2];
				if ((!skipDisabledMaps || actionElementMap2.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					qeVDFUbQvrDFHDxanyLsbhgRmUUW(actionElementMap2.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
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
			for (int num2 = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[num2];
				if ((!skipDisabledMaps || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb) && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					qeVDFUbQvrDFHDxanyLsbhgRmUUW(actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs, num2);
					num++;
				}
			}
			return num;
		}

		internal override int sWqUNaVaNBJPqcgsUJCHjBMovBmz(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
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
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (!actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
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

		internal override int sWqUNaVaNBJPqcgsUJCHjBMovBmz(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.llkLFSoLVtaASCstwdnHCsIDxnhYb))
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
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override int sWqUNaVaNBJPqcgsUJCHjBMovBmz(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.sWqUNaVaNBJPqcgsUJCHjBMovBmz(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
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
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb && actionElementMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				array[i] = IBcBfWcjSFIsjpqtymOgqKeddGELA[i].elementIdentifierName;
			}
			return array;
		}

		internal override bool gWhjoTRNRldWcTlFdhKHpqWCipZj(ActionElementMap P_0)
		{
			if (base.gWhjoTRNRldWcTlFdhKHpqWCipZj(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(elementType))
			{
				return false;
			}
			CpoMvrShTlXntBmNCebSkyGOtesY(P_0);
			return true;
		}

		internal override int FypTeLaodvFAxEmfQucQyrphhmyc(List<ActionElementMap> P_0, bool P_1)
		{
			base.FypTeLaodvFAxEmfQucQyrphhmyc(P_0, P_1);
			int count = P_0.Count;
			int count2 = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || IBcBfWcjSFIsjpqtymOgqKeddGELA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					P_0.Add(IBcBfWcjSFIsjpqtymOgqKeddGELA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal override ActionElementMap qUEPKPvkMFttTKBFyJTdYJlytPmN(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.qUEPKPvkMFttTKBFyJTdYJlytPmN(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_2))
			{
				return null;
			}
			int num = oAGjXWxtieiPDWaUxbBGdPcPAtcsA(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return IBcBfWcjSFIsjpqtymOgqKeddGELA[num];
			}
			throw new NotImplementedException();
		}

		internal override int PEwFZaChDbchEucRIZNOWilLQAcJ(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.PEwFZaChDbchEucRIZNOWilLQAcJ(P_0, P_1, P_2);
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return P_1.Count - num;
			}
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(IBcBfWcjSFIsjpqtymOgqKeddGELA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal override bool VXUvTtrVTpEhfzkNENjDZPkaAeTk(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.VXUvTtrVTpEhfzkNENjDZPkaAeTk(P_0, P_1, P_2))
			{
				return true;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
				for (int i = 0; i < count; i++)
				{
					if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._elementIdentifierId == P_0 && IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal override int oAGjXWxtieiPDWaUxbBGdPcPAtcsA(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.oAGjXWxtieiPDWaUxbBGdPcPAtcsA(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_2))
			{
				return -1;
			}
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
				for (int i = 0; i < count; i++)
				{
					if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._elementIdentifierId == P_0 && IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int MYxEriPiRVntYqCxCNscIhpygsOeA(int P_0)
		{
			if (IBcBfWcjSFIsjpqtymOgqKeddGELA == null)
			{
				return -1;
			}
			int count = IBcBfWcjSFIsjpqtymOgqKeddGELA.Count;
			for (int i = 0; i < count; i++)
			{
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i].HZrDwOTOuvYGJkZRWDMDnUPlFNTs == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int RDpuoEAXlwKQKwcmzIohguXDwGrFA(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (!P_0 || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int AInCQcdygmFlEHaSEZaUCkYWhGekc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal override int zwdxASlITbuZpVbhYqYmCmlNvatv(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.zwdxASlITbuZpVbhYqYmCmlNvatv(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.llkLFSoLVtaASCstwdnHCsIDxnhYb))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override ActionElementMap XVBIGuwjdUxtMPnVgYILXbpHJhcM(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.XVBIGuwjdUxtMPnVgYILXbpHJhcM(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._actionId == P_2) && (!P_3 || IBcBfWcjSFIsjpqtymOgqKeddGELA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb) && IBcBfWcjSFIsjpqtymOgqKeddGELA[i].IsTarget(P_0))
				{
					return IBcBfWcjSFIsjpqtymOgqKeddGELA[i];
				}
			}
			return null;
		}

		internal override int DByGazdclNMniEHyXlrfkPzVFmhE(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.DByGazdclNMniEHyXlrfkPzVFmhE(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || IBcBfWcjSFIsjpqtymOgqKeddGELA[i]._actionId == P_2) && (!P_3 || IBcBfWcjSFIsjpqtymOgqKeddGELA[i].llkLFSoLVtaASCstwdnHCsIDxnhYb) && IBcBfWcjSFIsjpqtymOgqKeddGELA[i].IsTarget(P_0))
				{
					P_4.Add(IBcBfWcjSFIsjpqtymOgqKeddGELA[i]);
					num++;
				}
			}
			return num;
		}

		internal override bool GyVpFotNIqdiYVGDDCqmhxxpOwJuA(ActionElementMap P_0)
		{
			if (base.GyVpFotNIqdiYVGDDCqmhxxpOwJuA(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!xpaHEEmovzSZludOYCvBdjOwVMINA(P_0._elementType))
			{
				return false;
			}
			IBcBfWcjSFIsjpqtymOgqKeddGELA.Add(P_0);
			hIEtbwrFIIEqlrpiphrHFXIOwruhA(P_0);
			return true;
		}

		private bool xpaHEEmovzSZludOYCvBdjOwVMINA(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void qeVDFUbQvrDFHDxanyLsbhgRmUUW(int P_0, int P_1)
		{
			joHyuKrTbmJjdnZpnGwJorcRRFvL(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				IBcBfWcjSFIsjpqtymOgqKeddGELA.RemoveAt(P_1);
			}
		}

		private void CpoMvrShTlXntBmNCebSkyGOtesY(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				IBcBfWcjSFIsjpqtymOgqKeddGELA.Add(P_0);
				hIEtbwrFIIEqlrpiphrHFXIOwruhA(P_0);
			}
		}

		private void LuyuRwGFfZKsrjiwRYjXYTZmrJUW(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				qFsvJwABwnghwTSPDhITCaiDdtOSA(IBcBfWcjSFIsjpqtymOgqKeddGELA[P_1].HZrDwOTOuvYGJkZRWDMDnUPlFNTs, P_0);
				IBcBfWcjSFIsjpqtymOgqKeddGELA[P_1] = P_0;
			}
		}

		internal override void tnEqLMFFwugjoHOyMvcImNymgKGl(SerializedObject P_0)
		{
			base.tnEqLMFFwugjoHOyMvcImNymgKGl(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (IBcBfWcjSFIsjpqtymOgqKeddGELA[i] != null)
				{
					list.Add(IBcBfWcjSFIsjpqtymOgqKeddGELA[i].OwZlvwNnIfDEsAMweyvGbtLoYQJtA());
				}
			}
		}

		internal override bool xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
			bool flag = base.xIgDRHQmTOVJkRVsknhXpBHuPygR(P_0);
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
						actionElementMap.xIgDRHQmTOVJkRVsknhXpBHuPygR(value2);
						if (ActionElementMap.RgypiEzrKNlXmJDSoHMwaLTKYTNS(actionElementMap))
						{
							CpoMvrShTlXntBmNCebSkyGOtesY(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> qblcbDKfpvlnbgJvFcJoxFOPGJiVB(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> nYzEvKbcTVDLdGjGNqQVPBjWYFru(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> rSneLsSEWAnurCFFtiGYhzDwlqyN(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
