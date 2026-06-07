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
		private sealed class vnkfVAhfMQmOzbEQIwKRDwrSuVFKA : IDisposable, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator, IEnumerator<ActionElementMap>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ActionElementMap vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMapWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

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
			public vnkfVAhfMQmOzbEQIwKRDwrSuVFKA(int P_0)
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
					ControllerMapWithAxes controllerMapWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						if (BOmXoDplzfnHtyBjNJvkkPzUlWST < 0)
						{
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = controllerMapWithAxes.AxisMaps.GetEnumerator();
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
				vnkfVAhfMQmOzbEQIwKRDwrSuVFKA vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2 = this;
				}
				else
				{
					vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2 = new vnkfVAhfMQmOzbEQIwKRDwrSuVFKA(0);
					vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2.BOmXoDplzfnHtyBjNJvkkPzUlWST = JVHPuraouxduvcIEzsfWFTjVVggFb;
				vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return vnkfVAhfMQmOzbEQIwKRDwrSuVFKA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class nPfavYGNNPqgmbCxfHXLjcFRZYknB : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMapWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private ControllerMap WLiuUldTXEcuIGVhKWPVeISBtYjL;

			public ControllerMap VjZXfzuBnUHXbbWlMycIUuGPGGJeb;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private IList<ActionElementMap> lCHCZrcoFlCfTgWubCRaCrtdgLjt;

			private int rLJMsjCpggXLexwUJClpxbSRSzch;

			private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

			private int YqICzTFCHypCsjwNxHxlQGCCyvCu;

			private ActionElementMap QebHWdeWhVTOemuAuyDejoxVsmbn;

			private int lRKDeQkLTvEAfeQwCUwkuEqMhzzOc;

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
			public nPfavYGNNPqgmbCxfHXLjcFRZYknB(int P_0)
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
					ControllerMapWithAxes controllerMapWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						if (WLiuUldTXEcuIGVhKWPVeISBtYjL == null)
						{
							return false;
						}
						BhdWnHwETjTwooLnNokUmKQRiiPK = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(WLiuUldTXEcuIGVhKWPVeISBtYjL, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00af;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00af;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_0232;
						}
						IL_0244:
						if (lRKDeQkLTvEAfeQwCUwkuEqMhzzOc < rLJMsjCpggXLexwUJClpxbSRSzch)
						{
							ActionElementMap actionElementMap = lCHCZrcoFlCfTgWubCRaCrtdgLjt[lRKDeQkLTvEAfeQwCUwkuEqMhzzOc];
							if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && QebHWdeWhVTOemuAuyDejoxVsmbn.CheckForAssignmentConflict(actionElementMap))
							{
								vjnbYLtrPMftzpjohNfommerCnGo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, QebHWdeWhVTOemuAuyDejoxVsmbn.kqvbpTxWGdGtrNRdxLepeZkwTJDn, QebHWdeWhVTOemuAuyDejoxVsmbn._actionId, QebHWdeWhVTOemuAuyDejoxVsmbn._elementType, QebHWdeWhVTOemuAuyDejoxVsmbn._elementIdentifierId, QebHWdeWhVTOemuAuyDejoxVsmbn.keyCode, QebHWdeWhVTOemuAuyDejoxVsmbn.modifierKeyFlags);
								hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
								return true;
							}
							goto IL_0232;
						}
						QebHWdeWhVTOemuAuyDejoxVsmbn = null;
						goto IL_025c;
						IL_0232:
						lRKDeQkLTvEAfeQwCUwkuEqMhzzOc++;
						goto IL_0244;
						IL_026e:
						if (YqICzTFCHypCsjwNxHxlQGCCyvCu < controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count)
						{
							QebHWdeWhVTOemuAuyDejoxVsmbn = controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs[YqICzTFCHypCsjwNxHxlQGCCyvCu];
							if (!bbJFyfBYztkbqyDKwjcJJfiCvWSr || QebHWdeWhVTOemuAuyDejoxVsmbn.KByWFLCBjjvqwXYVZFDfzPdklyjf)
							{
								lRKDeQkLTvEAfeQwCUwkuEqMhzzOc = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
						{
							ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
							vjnbYLtrPMftzpjohNfommerCnGo = current;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						BhdWnHwETjTwooLnNokUmKQRiiPK = null;
						if (!(WLiuUldTXEcuIGVhKWPVeISBtYjL is ControllerMapWithAxes controllerMapWithAxes2))
						{
							return false;
						}
						if (bbJFyfBYztkbqyDKwjcJJfiCvWSr && (!controllerMapWithAxes._enabled || !controllerMapWithAxes2._enabled))
						{
							return false;
						}
						lCHCZrcoFlCfTgWubCRaCrtdgLjt = controllerMapWithAxes2.AxisMaps;
						if (lCHCZrcoFlCfTgWubCRaCrtdgLjt == null)
						{
							return false;
						}
						rLJMsjCpggXLexwUJClpxbSRSzch = lCHCZrcoFlCfTgWubCRaCrtdgLjt.Count;
						YqICzTFCHypCsjwNxHxlQGCCyvCu = 0;
						goto IL_026e;
						IL_025c:
						YqICzTFCHypCsjwNxHxlQGCCyvCu++;
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
				nPfavYGNNPqgmbCxfHXLjcFRZYknB nPfavYGNNPqgmbCxfHXLjcFRZYknB2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					nPfavYGNNPqgmbCxfHXLjcFRZYknB2 = this;
				}
				else
				{
					nPfavYGNNPqgmbCxfHXLjcFRZYknB2 = new nPfavYGNNPqgmbCxfHXLjcFRZYknB(0);
					nPfavYGNNPqgmbCxfHXLjcFRZYknB2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				nPfavYGNNPqgmbCxfHXLjcFRZYknB2.WLiuUldTXEcuIGVhKWPVeISBtYjL = VjZXfzuBnUHXbbWlMycIUuGPGGJeb;
				nPfavYGNNPqgmbCxfHXLjcFRZYknB2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return nPfavYGNNPqgmbCxfHXLjcFRZYknB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class uvwcWbZCbADLFokOiQeEyrANzBFv : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMapWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private ActionElementMap iTDfhpbZQXABExodAcvVPhaugdAhA;

			public ActionElementMap PnhRmbULhEBSLPPKimPLlyDMDlCy;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private IEnumerator<ElementAssignmentConflictInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

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
			public uvwcWbZCbADLFokOiQeEyrANzBFv(int P_0)
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
					ControllerMapWithAxes controllerMapWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						if (iTDfhpbZQXABExodAcvVPhaugdAhA == null)
						{
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(iTDfhpbZQXABExodAcvVPhaugdAhA, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00ad;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00ad;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
						{
							ElementAssignmentConflictInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
							vjnbYLtrPMftzpjohNfommerCnGo = current;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
						if (bbJFyfBYztkbqyDKwjcJJfiCvWSr && (!controllerMapWithAxes._enabled || !iTDfhpbZQXABExodAcvVPhaugdAhA.KByWFLCBjjvqwXYVZFDfzPdklyjf))
						{
							return false;
						}
						if (controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
						{
							return false;
						}
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_01bb;
						IL_01bb:
						if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
							if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(iTDfhpbZQXABExodAcvVPhaugdAhA))
							{
								vjnbYLtrPMftzpjohNfommerCnGo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				uvwcWbZCbADLFokOiQeEyrANzBFv uvwcWbZCbADLFokOiQeEyrANzBFv2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					uvwcWbZCbADLFokOiQeEyrANzBFv2 = this;
				}
				else
				{
					uvwcWbZCbADLFokOiQeEyrANzBFv2 = new uvwcWbZCbADLFokOiQeEyrANzBFv(0);
					uvwcWbZCbADLFokOiQeEyrANzBFv2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				uvwcWbZCbADLFokOiQeEyrANzBFv2.iTDfhpbZQXABExodAcvVPhaugdAhA = PnhRmbULhEBSLPPKimPLlyDMDlCy;
				uvwcWbZCbADLFokOiQeEyrANzBFv2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return uvwcWbZCbADLFokOiQeEyrANzBFv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class CODdtMtQmzQlXMeQKShfCZDlxOXB : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerMapWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

			public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

			private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

			public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

			private ElementAssignment dWSfaeadGadlhgGcSiEKXzPTeKqk;

			private IEnumerator<ElementAssignmentConflictInfo> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

			private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

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
			public CODdtMtQmzQlXMeQKShfCZDlxOXB(int P_0)
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
					ControllerMapWithAxes controllerMapWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr).GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_009e;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_009e;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA < controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA];
							if ((!bbJFyfBYztkbqyDKwjcJJfiCvWSr || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementMapId && actionElementMap.CheckForAssignmentConflict(dWSfaeadGadlhgGcSiEKXzPTeKqk))
							{
								vjnbYLtrPMftzpjohNfommerCnGo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
						{
							ElementAssignmentConflictInfo current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
							vjnbYLtrPMftzpjohNfommerCnGo = current;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
						if (bbJFyfBYztkbqyDKwjcJJfiCvWSr && !controllerMapWithAxes._enabled)
						{
							return false;
						}
						if (controllerMapWithAxes.pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
						{
							return false;
						}
						dWSfaeadGadlhgGcSiEKXzPTeKqk = xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.ToElementAssignment();
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
						goto IL_01c7;
						IL_01b5:
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
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
				CODdtMtQmzQlXMeQKShfCZDlxOXB cODdtMtQmzQlXMeQKShfCZDlxOXB;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					cODdtMtQmzQlXMeQKShfCZDlxOXB = this;
				}
				else
				{
					cODdtMtQmzQlXMeQKShfCZDlxOXB = new CODdtMtQmzQlXMeQKShfCZDlxOXB(0);
					cODdtMtQmzQlXMeQKShfCZDlxOXB.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				cODdtMtQmzQlXMeQKShfCZDlxOXB.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
				cODdtMtQmzQlXMeQKShfCZDlxOXB.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
				return cODdtMtQmzQlXMeQKShfCZDlxOXB;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> pEwgUXDouZFbXHZRVeJGNBLeHOWs;

		private readonly ReadOnlyCollection<ActionElementMap> GlpwwCfcPUqbovXyzzpjPjpOHkdv;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
				{
					return 0;
				}
				return pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return GlpwwCfcPUqbovXyzzpjPjpOHkdv;
			}
		}

		internal AList<ActionElementMap> rStYJnklHSdEdVGPAEyZExxfflXh => (AList<ActionElementMap>)pEwgUXDouZFbXHZRVeJGNBLeHOWs;

		public ControllerMapWithAxes()
		{
			pEwgUXDouZFbXHZRVeJGNBLeHOWs = new AList<ActionElementMap>();
			GlpwwCfcPUqbovXyzzpjPjpOHkdv = new ReadOnlyCollection<ActionElementMap>(pEwgUXDouZFbXHZRVeJGNBLeHOWs);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			pEwgUXDouZFbXHZRVeJGNBLeHOWs = new AList<ActionElementMap>();
			GlpwwCfcPUqbovXyzzpjPjpOHkdv = new ReadOnlyCollection<ActionElementMap>(pEwgUXDouZFbXHZRVeJGNBLeHOWs);
			if (P_0.pEwgUXDouZFbXHZRVeJGNBLeHOWs != null)
			{
				int count = P_0.pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
				for (int i = 0; i < count; i++)
				{
					dFeqbacgppWZVmLhfBPmlfrDoQkH(new ActionElementMap(P_0.pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return false;
			}
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			dFeqbacgppWZVmLhfBPmlfrDoQkH(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				dFeqbacgppWZVmLhfBPmlfrDoQkH(elementMap);
			}
			if (tjanxllWRIryTNQlQBWZIdluPED(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.kgliNvNIGEEbkLKWaeYnFuesrFfgA(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = tjanxllWRIryTNQlQBWZIdluPED(elementMapId);
			if (num < 0)
			{
				return false;
			}
			DBbINcVVgbibFgIwSrIkeBIvUQAb(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return null;
			}
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == elementMapId)
				{
					return pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal override ActionElementMap cfrYXeAFAXObgTDGlHvdlEiYIbwJ(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.cfrYXeAFAXObgTDGlHvdlEiYIbwJ(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return GzxeuitddLCaelXjagtfjHnJnuOM(P_0, P_1);
		}

		internal override int QtKbwhWZNaFGzaJhCiMOiZQYYnAz(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.QtKbwhWZNaFGzaJhCiMOiZQYYnAz(P_0, P_1, P_2, P_3) + OnfBCQxTawimJDdiiltJXrlFHYfH(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			base.ClearElementMaps();
			pEwgUXDouZFbXHZRVeJGNBLeHOWs.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null || index < 0 || index >= pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count)
			{
				return null;
			}
			return pEwgUXDouZFbXHZRVeJGNBLeHOWs[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(pEwgUXDouZFbXHZRVeJGNBLeHOWs);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return wGxpLNcgFgfZkFoGAKoBpPeGUMxj(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
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
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
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
			int num = axisMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
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
				ActionElementMap actionElementMap2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return pLtPLpYzEmAgeTsckCkqdEboCooK(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new vnkfVAhfMQmOzbEQIwKRDwrSuVFKA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				JVHPuraouxduvcIEzsfWFTjVVggFb = actionId,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			int actionId = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName);
			return GetFirstAxisMapWithAction(actionId);
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
			IList<ActionElementMap> axisMaps = AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return GzxeuitddLCaelXjagtfjHnJnuOM(predicate, false);
		}

		internal ActionElementMap GzxeuitddLCaelXjagtfjHnJnuOM(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			return OnfBCQxTawimJDdiiltJXrlFHYfH(predicate, false, results, false);
		}

		internal int OnfBCQxTawimJDdiiltJXrlFHYfH(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
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
			return DeleteAxisMapsWithAction(ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
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
			int num = axisMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[num2] != null && pEwgUXDouZFbXHZRVeJGNBLeHOWs[num2]._actionId == actionId)
				{
					DBbINcVVgbibFgIwSrIkeBIvUQAb(pEwgUXDouZFbXHZRVeJGNBLeHOWs[num2].kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			int num = 0;
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf != state)
				{
					actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (skipDisabledMaps && !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
			{
				return false;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return false;
			}
			for (int i = 0; i < pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count; i++)
			{
				ActionElementMap actionElementMap2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if ((!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new nPfavYGNNPqgmbCxfHXLjcFRZYknB(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				VjZXfzuBnUHXbbWlMycIUuGPGGJeb = controllerMap,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new uvwcWbZCbADLFokOiQeEyrANzBFv(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				PnhRmbULhEBSLPPKimPLlyDMDlCy = actionElementMap,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new CODdtMtQmzQlXMeQKShfCZDlxOXB(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				kFSVgsWFZyqOFXGOFRPLWNAXMqBB = conflictCheck,
				sArRKCvKaVOofQinfjRFdePmZRhGA = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
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
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
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
			_ = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			int count = axisMaps.Count;
			for (int num2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[num2];
				if (!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							DBbINcVVgbibFgIwSrIkeBIvUQAb(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return num;
			}
			for (int num2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs[num2];
				if ((!skipDisabledMaps || actionElementMap2.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					DBbINcVVgbibFgIwSrIkeBIvUQAb(actionElementMap2.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
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
			for (int num2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[num2];
				if ((!skipDisabledMaps || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf) && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					DBbINcVVgbibFgIwSrIkeBIvUQAb(actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn, num2);
					num++;
				}
			}
			return num;
		}

		internal override int XnaIBtzabDEqOJGIptytUUvthXus(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
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
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (!actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
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

		internal override int XnaIBtzabDEqOJGIptytUUvthXus(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.KByWFLCBjjvqwXYVZFDfzPdklyjf))
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
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override int XnaIBtzabDEqOJGIptytUUvthXus(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.XnaIBtzabDEqOJGIptytUUvthXus(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
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
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf && actionElementMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				array[i] = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].elementIdentifierName;
			}
			return array;
		}

		internal override bool BTbXqEjOhhCEMqppIILjeDzBegNdA(ActionElementMap P_0)
		{
			if (base.BTbXqEjOhhCEMqppIILjeDzBegNdA(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(elementType))
			{
				return false;
			}
			dFeqbacgppWZVmLhfBPmlfrDoQkH(P_0);
			return true;
		}

		internal override int qUjJSbIkSdkiytTMfSCgjDYetnkW(List<ActionElementMap> P_0, bool P_1)
		{
			base.qUjJSbIkSdkiytTMfSCgjDYetnkW(P_0, P_1);
			int count = P_0.Count;
			int count2 = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					P_0.Add(pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]);
				}
			}
			return P_0.Count - count;
		}

		internal override ActionElementMap ZlQNMWXGePQbhjItLdrTTmObeJsv(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.ZlQNMWXGePQbhjItLdrTTmObeJsv(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_2))
			{
				return null;
			}
			int num = BRSYgPNShekAbtuSKviuAFLUdUaJ(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return pEwgUXDouZFbXHZRVeJGNBLeHOWs[num];
			}
			throw new NotImplementedException();
		}

		internal override int oogMArsWTzlTiTtbngheDoEYRUqt(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.oogMArsWTzlTiTtbngheDoEYRUqt(P_0, P_1, P_2);
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return P_1.Count - num;
			}
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._elementIdentifierId == P_0)
				{
					P_1.Add(pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]);
				}
			}
			return P_1.Count - num;
		}

		internal override bool qhCTumRebpVbHQKvnVtlUVJlsCTr(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.qhCTumRebpVbHQKvnVtlUVJlsCTr(P_0, P_1, P_2))
			{
				return true;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
				for (int i = 0; i < count; i++)
				{
					if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._elementIdentifierId == P_0 && pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal override int BRSYgPNShekAbtuSKviuAFLUdUaJ(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.BRSYgPNShekAbtuSKviuAFLUdUaJ(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_2))
			{
				return -1;
			}
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
				for (int i = 0; i < count; i++)
				{
					if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._elementIdentifierId == P_0 && pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int tjanxllWRIryTNQlQBWZIdluPED(int P_0)
		{
			if (pEwgUXDouZFbXHZRVeJGNBLeHOWs == null)
			{
				return -1;
			}
			int count = pEwgUXDouZFbXHZRVeJGNBLeHOWs.Count;
			for (int i = 0; i < count; i++)
			{
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].kqvbpTxWGdGtrNRdxLepeZkwTJDn == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int wGxpLNcgFgfZkFoGAKoBpPeGUMxj(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (!P_0 || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int pLtPLpYzEmAgeTsckCkqdEboCooK(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal override int KnhZxXTPhhiXJgFttivQXWIEaevD(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.KnhZxXTPhhiXJgFttivQXWIEaevD(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KByWFLCBjjvqwXYVZFDfzPdklyjf))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override ActionElementMap ofPtXzQRTSIwuudhHEmzQTQYglcR(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.ofPtXzQRTSIwuudhHEmzQTQYglcR(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._actionId == P_2) && (!P_3 || pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].KByWFLCBjjvqwXYVZFDfzPdklyjf) && pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].IsTarget(P_0))
				{
					return pEwgUXDouZFbXHZRVeJGNBLeHOWs[i];
				}
			}
			return null;
		}

		internal override int wykkVuZXYDRrQxJtgKBZdFoATLny(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.wykkVuZXYDRrQxJtgKBZdFoATLny(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]._actionId == P_2) && (!P_3 || pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].KByWFLCBjjvqwXYVZFDfzPdklyjf) && pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].IsTarget(P_0))
				{
					P_4.Add(pEwgUXDouZFbXHZRVeJGNBLeHOWs[i]);
					num++;
				}
			}
			return num;
		}

		internal override bool hOLSMlXFsuVxuytviQkQgEIwFgJr(ActionElementMap P_0)
		{
			if (base.hOLSMlXFsuVxuytviQkQgEIwFgJr(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!KmnLZLEHrawPjBsbETvFqnhSOYEb(P_0._elementType))
			{
				return false;
			}
			pEwgUXDouZFbXHZRVeJGNBLeHOWs.Add(P_0);
			GsCvwpRIyGKPFGmASeRnUQjFtwyl(P_0);
			return true;
		}

		private bool KmnLZLEHrawPjBsbETvFqnhSOYEb(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void DBbINcVVgbibFgIwSrIkeBIvUQAb(int P_0, int P_1)
		{
			IXRwpJVZRkCuPAsBMckndrJQjFfO(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				pEwgUXDouZFbXHZRVeJGNBLeHOWs.RemoveAt(P_1);
			}
		}

		private void dFeqbacgppWZVmLhfBPmlfrDoQkH(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				pEwgUXDouZFbXHZRVeJGNBLeHOWs.Add(P_0);
				GsCvwpRIyGKPFGmASeRnUQjFtwyl(P_0);
			}
		}

		private void sKoMKvqkZHBNNAUOuVBjBAshFFSs(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				XIyYClePMtKXAaHjegFnrwBOpaWJ(pEwgUXDouZFbXHZRVeJGNBLeHOWs[P_1].kqvbpTxWGdGtrNRdxLepeZkwTJDn, P_0);
				pEwgUXDouZFbXHZRVeJGNBLeHOWs[P_1] = P_0;
			}
		}

		internal override void AkUcpXbtGgaSOLgGtBKaSvRfkwYX(SerializedObject P_0)
		{
			base.AkUcpXbtGgaSOLgGtBKaSvRfkwYX(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (pEwgUXDouZFbXHZRVeJGNBLeHOWs[i] != null)
				{
					list.Add(pEwgUXDouZFbXHZRVeJGNBLeHOWs[i].pMFmgpdCytjWAfCkBRuiiiznUeVd());
				}
			}
		}

		internal override bool IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
		{
			bool flag = base.IqWUQdetEUgWKmOIFRihysPfqZgC(P_0);
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
						actionElementMap.IqWUQdetEUgWKmOIFRihysPfqZgC(value2);
						if (ActionElementMap.iJkboRPqUFYIIceuRqjUryWVRsDe(actionElementMap))
						{
							dFeqbacgppWZVmLhfBPmlfrDoQkH(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> BEzeKUXzVpUjDeZFXdRUUpvVVdaK(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> UvjGLRfVzLTkZOhqeiczFUWPVZpZ(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> GPfEzbeogMSELGjnOlicAictjgmTA(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
