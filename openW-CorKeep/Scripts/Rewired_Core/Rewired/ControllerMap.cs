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
		private class NflAbolMayPdbWLkqXxHHJrBLpNc : IComparer<ActionElementMap>
		{
			public static NflAbolMayPdbWLkqXxHHJrBLpNc IDnasPlHOvGcSbbRmOETlMPqABeJ;

			public static NflAbolMayPdbWLkqXxHHJrBLpNc JnGLkxyhNVBElfWSYtEIRDlbiEUm => IDnasPlHOvGcSbbRmOETlMPqABeJ ?? (IDnasPlHOvGcSbbRmOETlMPqABeJ = new NflAbolMayPdbWLkqXxHHJrBLpNc());

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

		private sealed class LFixKTwcjYcXxWnkcAnNOyRPRiLJ : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int cWiiGWUNFaJZNbMvjWFKObnUlXDXA;

			private ActionElementMap WPhCcjrcnKiRcTVKEkEyvnGBeGhaA;

			private int uEPlMtgtYrgrAFYVJJuSUgZFaDkU;

			public ControllerMap WZoBVwBDlzTHeQGvPElZEmpSYBIbA;

			private int VkBaPakJunNAcHLNZVcfeKQAiIbcA;

			public int iqIlrxNMYHfnHPmDqNJhXzucfvZp;

			private bool aLKFDEvzrQFnCijwOvOaAZdCuZos;

			public bool scxGPCaSyPXprWIuMzMqhSStinIjb;

			private IList<ActionElementMap> ClKgKOeoClZDqhEpuicXOEFLPgYQ;

			private int TFrfaIJqzvHojuBticothoaDkARYB;

			private int JnyXtwsJvnwFDsQQMIiiUWyVtCKm;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return WPhCcjrcnKiRcTVKEkEyvnGBeGhaA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WPhCcjrcnKiRcTVKEkEyvnGBeGhaA;
				}
			}

			[DebuggerHidden]
			public LFixKTwcjYcXxWnkcAnNOyRPRiLJ(int P_0)
			{
				cWiiGWUNFaJZNbMvjWFKObnUlXDXA = P_0;
				uEPlMtgtYrgrAFYVJJuSUgZFaDkU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				ClKgKOeoClZDqhEpuicXOEFLPgYQ = null;
				cWiiGWUNFaJZNbMvjWFKObnUlXDXA = -2;
			}

			private bool MoveNext()
			{
				int num = cWiiGWUNFaJZNbMvjWFKObnUlXDXA;
				ControllerMap wZoBVwBDlzTHeQGvPElZEmpSYBIbA = WZoBVwBDlzTHeQGvPElZEmpSYBIbA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					cWiiGWUNFaJZNbMvjWFKObnUlXDXA = -1;
					goto IL_00af;
				}
				cWiiGWUNFaJZNbMvjWFKObnUlXDXA = -1;
				if (ReInput._id != wZoBVwBDlzTHeQGvPElZEmpSYBIbA.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(wZoBVwBDlzTHeQGvPElZEmpSYBIbA.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return false;
				}
				if (VkBaPakJunNAcHLNZVcfeKQAiIbcA < 0)
				{
					return false;
				}
				ClKgKOeoClZDqhEpuicXOEFLPgYQ = wZoBVwBDlzTHeQGvPElZEmpSYBIbA.ButtonMaps;
				TFrfaIJqzvHojuBticothoaDkARYB = wZoBVwBDlzTHeQGvPElZEmpSYBIbA.buttonMapCount;
				JnyXtwsJvnwFDsQQMIiiUWyVtCKm = 0;
				goto IL_00bf;
				IL_00bf:
				if (JnyXtwsJvnwFDsQQMIiiUWyVtCKm < TFrfaIJqzvHojuBticothoaDkARYB)
				{
					ActionElementMap actionElementMap = ClKgKOeoClZDqhEpuicXOEFLPgYQ[JnyXtwsJvnwFDsQQMIiiUWyVtCKm];
					if (actionElementMap._actionId == VkBaPakJunNAcHLNZVcfeKQAiIbcA && (!aLKFDEvzrQFnCijwOvOaAZdCuZos || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
					{
						WPhCcjrcnKiRcTVKEkEyvnGBeGhaA = actionElementMap;
						cWiiGWUNFaJZNbMvjWFKObnUlXDXA = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				JnyXtwsJvnwFDsQQMIiiUWyVtCKm++;
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
				LFixKTwcjYcXxWnkcAnNOyRPRiLJ lFixKTwcjYcXxWnkcAnNOyRPRiLJ;
				if (cWiiGWUNFaJZNbMvjWFKObnUlXDXA == -2 && uEPlMtgtYrgrAFYVJJuSUgZFaDkU == Environment.CurrentManagedThreadId)
				{
					cWiiGWUNFaJZNbMvjWFKObnUlXDXA = 0;
					lFixKTwcjYcXxWnkcAnNOyRPRiLJ = this;
				}
				else
				{
					lFixKTwcjYcXxWnkcAnNOyRPRiLJ = new LFixKTwcjYcXxWnkcAnNOyRPRiLJ(0);
					lFixKTwcjYcXxWnkcAnNOyRPRiLJ.WZoBVwBDlzTHeQGvPElZEmpSYBIbA = WZoBVwBDlzTHeQGvPElZEmpSYBIbA;
				}
				lFixKTwcjYcXxWnkcAnNOyRPRiLJ.VkBaPakJunNAcHLNZVcfeKQAiIbcA = iqIlrxNMYHfnHPmDqNJhXzucfvZp;
				lFixKTwcjYcXxWnkcAnNOyRPRiLJ.aLKFDEvzrQFnCijwOvOaAZdCuZos = scxGPCaSyPXprWIuMzMqhSStinIjb;
				return lFixKTwcjYcXxWnkcAnNOyRPRiLJ;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class GSDqTQgZpqBHLDaDrmNeCIWNtvgB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int fedmkwjaXGmwThxoFmyWosCZbGMK;

			private ElementAssignmentConflictInfo JfkjmXCAJdWyPpjvwOBQccHIchXzB;

			private int RaidnEAYWRSQzXRMeMJkVhzhHswH;

			public ControllerMap NphrNyKhKTCSHGneaAeNUhHZuDAH;

			private ControllerMap owqVSOlColgDhULENkaqAYrgJVkw;

			public ControllerMap pMEMXMeoxAmyXVcfgMOgmHSJbxLG;

			private bool UftJSqARygiHAQLiQHCNbiASEElZA;

			public bool LsBsRsZlUVaYPHuuCZHiqJMYrqgdA;

			private IList<ActionElementMap> XedKVxcLnascNfmEmDOHIlihArnW;

			private int CrADukPyFTEINMfAzGyZzfQZRlRb;

			private int ZuLGPMqqrtpKxTGklCIcVMTpqZiE;

			private ActionElementMap JEFOeEXVtBOnEgzZRnNsNSXregfQ;

			private int DBStumyhXQeomIsLclLcEhmJKTsQA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JfkjmXCAJdWyPpjvwOBQccHIchXzB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JfkjmXCAJdWyPpjvwOBQccHIchXzB;
				}
			}

			[DebuggerHidden]
			public GSDqTQgZpqBHLDaDrmNeCIWNtvgB(int P_0)
			{
				fedmkwjaXGmwThxoFmyWosCZbGMK = P_0;
				RaidnEAYWRSQzXRMeMJkVhzhHswH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				XedKVxcLnascNfmEmDOHIlihArnW = null;
				JEFOeEXVtBOnEgzZRnNsNSXregfQ = null;
				fedmkwjaXGmwThxoFmyWosCZbGMK = -2;
			}

			private bool MoveNext()
			{
				int num = fedmkwjaXGmwThxoFmyWosCZbGMK;
				ControllerMap nphrNyKhKTCSHGneaAeNUhHZuDAH = NphrNyKhKTCSHGneaAeNUhHZuDAH;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					fedmkwjaXGmwThxoFmyWosCZbGMK = -1;
					goto IL_019c;
				}
				fedmkwjaXGmwThxoFmyWosCZbGMK = -1;
				if (ReInput._id != nphrNyKhKTCSHGneaAeNUhHZuDAH.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(nphrNyKhKTCSHGneaAeNUhHZuDAH.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return false;
				}
				if (owqVSOlColgDhULENkaqAYrgJVkw == null || nphrNyKhKTCSHGneaAeNUhHZuDAH.QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
				{
					return false;
				}
				if (UftJSqARygiHAQLiQHCNbiASEElZA && (!nphrNyKhKTCSHGneaAeNUhHZuDAH._enabled || !owqVSOlColgDhULENkaqAYrgJVkw._enabled))
				{
					return false;
				}
				XedKVxcLnascNfmEmDOHIlihArnW = owqVSOlColgDhULENkaqAYrgJVkw.ButtonMaps;
				if (XedKVxcLnascNfmEmDOHIlihArnW == null)
				{
					return false;
				}
				CrADukPyFTEINMfAzGyZzfQZRlRb = XedKVxcLnascNfmEmDOHIlihArnW.Count;
				ZuLGPMqqrtpKxTGklCIcVMTpqZiE = 0;
				goto IL_01d4;
				IL_01d4:
				if (ZuLGPMqqrtpKxTGklCIcVMTpqZiE < nphrNyKhKTCSHGneaAeNUhHZuDAH.QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count)
				{
					JEFOeEXVtBOnEgzZRnNsNSXregfQ = nphrNyKhKTCSHGneaAeNUhHZuDAH.QsEBFwiqUNJUXsFQkdPdzvCCsdTl[ZuLGPMqqrtpKxTGklCIcVMTpqZiE];
					if (!UftJSqARygiHAQLiQHCNbiASEElZA || JEFOeEXVtBOnEgzZRnNsNSXregfQ.fpFEHHilwCsNTxvZcaeleakbBkQCb)
					{
						DBStumyhXQeomIsLclLcEhmJKTsQA = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (DBStumyhXQeomIsLclLcEhmJKTsQA < CrADukPyFTEINMfAzGyZzfQZRlRb)
				{
					ActionElementMap actionElementMap = XedKVxcLnascNfmEmDOHIlihArnW[DBStumyhXQeomIsLclLcEhmJKTsQA];
					if ((!UftJSqARygiHAQLiQHCNbiASEElZA || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && JEFOeEXVtBOnEgzZRnNsNSXregfQ.CheckForAssignmentConflict(actionElementMap))
					{
						JfkjmXCAJdWyPpjvwOBQccHIchXzB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(nphrNyKhKTCSHGneaAeNUhHZuDAH._categoryId).userAssignable, -1, nphrNyKhKTCSHGneaAeNUhHZuDAH._controllerType, nphrNyKhKTCSHGneaAeNUhHZuDAH._controllerId, nphrNyKhKTCSHGneaAeNUhHZuDAH._id, JEFOeEXVtBOnEgzZRnNsNSXregfQ.oETQtUYpoAHvrDdxockLYpfjFkywA, JEFOeEXVtBOnEgzZRnNsNSXregfQ._actionId, JEFOeEXVtBOnEgzZRnNsNSXregfQ._elementType, JEFOeEXVtBOnEgzZRnNsNSXregfQ._elementIdentifierId, JEFOeEXVtBOnEgzZRnNsNSXregfQ.keyCode, JEFOeEXVtBOnEgzZRnNsNSXregfQ.modifierKeyFlags);
						fedmkwjaXGmwThxoFmyWosCZbGMK = 1;
						return true;
					}
					goto IL_019c;
				}
				JEFOeEXVtBOnEgzZRnNsNSXregfQ = null;
				goto IL_01c4;
				IL_01c4:
				ZuLGPMqqrtpKxTGklCIcVMTpqZiE++;
				goto IL_01d4;
				IL_019c:
				DBStumyhXQeomIsLclLcEhmJKTsQA++;
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
				GSDqTQgZpqBHLDaDrmNeCIWNtvgB gSDqTQgZpqBHLDaDrmNeCIWNtvgB;
				if (fedmkwjaXGmwThxoFmyWosCZbGMK == -2 && RaidnEAYWRSQzXRMeMJkVhzhHswH == Environment.CurrentManagedThreadId)
				{
					fedmkwjaXGmwThxoFmyWosCZbGMK = 0;
					gSDqTQgZpqBHLDaDrmNeCIWNtvgB = this;
				}
				else
				{
					gSDqTQgZpqBHLDaDrmNeCIWNtvgB = new GSDqTQgZpqBHLDaDrmNeCIWNtvgB(0);
					gSDqTQgZpqBHLDaDrmNeCIWNtvgB.NphrNyKhKTCSHGneaAeNUhHZuDAH = NphrNyKhKTCSHGneaAeNUhHZuDAH;
				}
				gSDqTQgZpqBHLDaDrmNeCIWNtvgB.owqVSOlColgDhULENkaqAYrgJVkw = pMEMXMeoxAmyXVcfgMOgmHSJbxLG;
				gSDqTQgZpqBHLDaDrmNeCIWNtvgB.UftJSqARygiHAQLiQHCNbiASEElZA = LsBsRsZlUVaYPHuuCZHiqJMYrqgdA;
				return gSDqTQgZpqBHLDaDrmNeCIWNtvgB;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class ZKJNSHBGaNNeHyNAceYTIPRZgmcL : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int BxdujrRpVTtuhpXupCZBpiscoDmm;

			private ElementAssignmentConflictInfo bRYSBsMlgahvhseVMcztyYxPkiTX;

			private int YUlwhtbfouRbQceVGzUBwRgZFHPE;

			public ControllerMap eaChDKOkFOHqRpJTXnlSxvJdRMQu;

			private ActionElementMap TZTntUQFGclTegDSdYAwwBuuQjlk;

			public ActionElementMap FALzdoymJYTjnZJqjggIJRCvpDEr;

			private bool nQQNoLsJYEtEGcjjSHRDGquVBKsLA;

			public bool gjusWDZbbArBTgoTwmgKsnTGfKfZ;

			private int pQtBJheclqPosEBvAXgZEFsPpToaA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return bRYSBsMlgahvhseVMcztyYxPkiTX;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return bRYSBsMlgahvhseVMcztyYxPkiTX;
				}
			}

			[DebuggerHidden]
			public ZKJNSHBGaNNeHyNAceYTIPRZgmcL(int P_0)
			{
				BxdujrRpVTtuhpXupCZBpiscoDmm = P_0;
				YUlwhtbfouRbQceVGzUBwRgZFHPE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				BxdujrRpVTtuhpXupCZBpiscoDmm = -2;
			}

			private bool MoveNext()
			{
				int bxdujrRpVTtuhpXupCZBpiscoDmm = BxdujrRpVTtuhpXupCZBpiscoDmm;
				ControllerMap controllerMap = eaChDKOkFOHqRpJTXnlSxvJdRMQu;
				if (bxdujrRpVTtuhpXupCZBpiscoDmm != 0)
				{
					if (bxdujrRpVTtuhpXupCZBpiscoDmm != 1)
					{
						return false;
					}
					BxdujrRpVTtuhpXupCZBpiscoDmm = -1;
					goto IL_0111;
				}
				BxdujrRpVTtuhpXupCZBpiscoDmm = -1;
				if (ReInput._id != controllerMap.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(controllerMap.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return false;
				}
				if (TZTntUQFGclTegDSdYAwwBuuQjlk == null || controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
				{
					return false;
				}
				if (nQQNoLsJYEtEGcjjSHRDGquVBKsLA && (!controllerMap._enabled || !TZTntUQFGclTegDSdYAwwBuuQjlk.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					return false;
				}
				pQtBJheclqPosEBvAXgZEFsPpToaA = 0;
				goto IL_0121;
				IL_0111:
				pQtBJheclqPosEBvAXgZEFsPpToaA++;
				goto IL_0121;
				IL_0121:
				if (pQtBJheclqPosEBvAXgZEFsPpToaA < controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count)
				{
					ActionElementMap actionElementMap = controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl[pQtBJheclqPosEBvAXgZEFsPpToaA];
					if ((!nQQNoLsJYEtEGcjjSHRDGquVBKsLA || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(TZTntUQFGclTegDSdYAwwBuuQjlk))
					{
						bRYSBsMlgahvhseVMcztyYxPkiTX = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						BxdujrRpVTtuhpXupCZBpiscoDmm = 1;
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
				ZKJNSHBGaNNeHyNAceYTIPRZgmcL zKJNSHBGaNNeHyNAceYTIPRZgmcL;
				if (BxdujrRpVTtuhpXupCZBpiscoDmm == -2 && YUlwhtbfouRbQceVGzUBwRgZFHPE == Environment.CurrentManagedThreadId)
				{
					BxdujrRpVTtuhpXupCZBpiscoDmm = 0;
					zKJNSHBGaNNeHyNAceYTIPRZgmcL = this;
				}
				else
				{
					zKJNSHBGaNNeHyNAceYTIPRZgmcL = new ZKJNSHBGaNNeHyNAceYTIPRZgmcL(0);
					zKJNSHBGaNNeHyNAceYTIPRZgmcL.eaChDKOkFOHqRpJTXnlSxvJdRMQu = eaChDKOkFOHqRpJTXnlSxvJdRMQu;
				}
				zKJNSHBGaNNeHyNAceYTIPRZgmcL.TZTntUQFGclTegDSdYAwwBuuQjlk = FALzdoymJYTjnZJqjggIJRCvpDEr;
				zKJNSHBGaNNeHyNAceYTIPRZgmcL.nQQNoLsJYEtEGcjjSHRDGquVBKsLA = gjusWDZbbArBTgoTwmgKsnTGfKfZ;
				return zKJNSHBGaNNeHyNAceYTIPRZgmcL;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class lTtQucLWhtSlfVIPvGfmiRJEyUwH : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int evduHhDLGQhUdcsGFCsRXkiJNtAJ;

			private ElementAssignmentConflictInfo fbHaVerToeCdEPUVqoTxVtVcbhcH;

			private int BQFKTOtshsLWZWAVIzqKWhAdZJzp;

			public ControllerMap gooxXJrmaTJjtdKfluzJFnDeOrCP;

			private bool AENSxaTFKSaVMdmeXTKHfMuPlBxo;

			public bool zsbSAWUxRSWKUAOTCTfzGzmOpUO;

			private ElementAssignmentConflictCheck YtCyNJRlBrjtGfOPWLQeUdaSxwNY;

			public ElementAssignmentConflictCheck ypYBrgsxKpgIHHKTtLmKwuldFeOeA;

			private ElementAssignment CPcoRoeOkMMJqJmqXxgGljeRaGHFA;

			private int kwjMVeqGjokMddoItXQAXXnOHtVI;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return fbHaVerToeCdEPUVqoTxVtVcbhcH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return fbHaVerToeCdEPUVqoTxVtVcbhcH;
				}
			}

			[DebuggerHidden]
			public lTtQucLWhtSlfVIPvGfmiRJEyUwH(int P_0)
			{
				evduHhDLGQhUdcsGFCsRXkiJNtAJ = P_0;
				BQFKTOtshsLWZWAVIzqKWhAdZJzp = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				evduHhDLGQhUdcsGFCsRXkiJNtAJ = -2;
			}

			private bool MoveNext()
			{
				int num = evduHhDLGQhUdcsGFCsRXkiJNtAJ;
				ControllerMap controllerMap = gooxXJrmaTJjtdKfluzJFnDeOrCP;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					evduHhDLGQhUdcsGFCsRXkiJNtAJ = -1;
					goto IL_0123;
				}
				evduHhDLGQhUdcsGFCsRXkiJNtAJ = -1;
				if (ReInput._id != controllerMap.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(controllerMap.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return false;
				}
				if (AENSxaTFKSaVMdmeXTKHfMuPlBxo && !controllerMap._enabled)
				{
					return false;
				}
				if (controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
				{
					return false;
				}
				CPcoRoeOkMMJqJmqXxgGljeRaGHFA = YtCyNJRlBrjtGfOPWLQeUdaSxwNY.ToElementAssignment();
				kwjMVeqGjokMddoItXQAXXnOHtVI = 0;
				goto IL_0133;
				IL_0133:
				if (kwjMVeqGjokMddoItXQAXXnOHtVI < controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count)
				{
					ActionElementMap actionElementMap = controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl[kwjMVeqGjokMddoItXQAXXnOHtVI];
					if ((!AENSxaTFKSaVMdmeXTKHfMuPlBxo || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != YtCyNJRlBrjtGfOPWLQeUdaSxwNY.elementMapId && actionElementMap.CheckForAssignmentConflict(CPcoRoeOkMMJqJmqXxgGljeRaGHFA))
					{
						fbHaVerToeCdEPUVqoTxVtVcbhcH = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						evduHhDLGQhUdcsGFCsRXkiJNtAJ = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				kwjMVeqGjokMddoItXQAXXnOHtVI++;
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
				lTtQucLWhtSlfVIPvGfmiRJEyUwH lTtQucLWhtSlfVIPvGfmiRJEyUwH2;
				if (evduHhDLGQhUdcsGFCsRXkiJNtAJ == -2 && BQFKTOtshsLWZWAVIzqKWhAdZJzp == Environment.CurrentManagedThreadId)
				{
					evduHhDLGQhUdcsGFCsRXkiJNtAJ = 0;
					lTtQucLWhtSlfVIPvGfmiRJEyUwH2 = this;
				}
				else
				{
					lTtQucLWhtSlfVIPvGfmiRJEyUwH2 = new lTtQucLWhtSlfVIPvGfmiRJEyUwH(0);
					lTtQucLWhtSlfVIPvGfmiRJEyUwH2.gooxXJrmaTJjtdKfluzJFnDeOrCP = gooxXJrmaTJjtdKfluzJFnDeOrCP;
				}
				lTtQucLWhtSlfVIPvGfmiRJEyUwH2.YtCyNJRlBrjtGfOPWLQeUdaSxwNY = ypYBrgsxKpgIHHKTtLmKwuldFeOeA;
				lTtQucLWhtSlfVIPvGfmiRJEyUwH2.AENSxaTFKSaVMdmeXTKHfMuPlBxo = zsbSAWUxRSWKUAOTCTfzGzmOpUO;
				return lTtQucLWhtSlfVIPvGfmiRJEyUwH2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class LQtszOXQCICItNubLNRWBXGGpYKH : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int mCKKQqXDNrfcIEuxJIedpjmmLhfG;

			private ActionElementMap AfsrEpfhRuLGdTVnnJtCwbWSYAvf;

			private int zwJzaPHbRHqlmNAfIEpaoEyfQoBy;

			public ControllerMap JfedgHTjUdGudNCoCFTkYTwriali;

			private int vaoETJCxlFJmJAeLyeTdwOxgSiJdA;

			public int ltodDqfOUJXsWeLVGAVRKWufCobj;

			private bool qgEbWmcFWxnsSPdgRUaLwCDwzULfA;

			public bool ZeaRItCIfZNnCmCajIvZvnzPqhVM;

			private IEnumerator<ActionElementMap> AzjDZhVrYhCBshicWVHaBLwYJUIEA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return AfsrEpfhRuLGdTVnnJtCwbWSYAvf;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return AfsrEpfhRuLGdTVnnJtCwbWSYAvf;
				}
			}

			[DebuggerHidden]
			public LQtszOXQCICItNubLNRWBXGGpYKH(int P_0)
			{
				mCKKQqXDNrfcIEuxJIedpjmmLhfG = P_0;
				zwJzaPHbRHqlmNAfIEpaoEyfQoBy = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = mCKKQqXDNrfcIEuxJIedpjmmLhfG;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						tueWYSIyeVmSxbKwqzmXyewfTIRB();
					}
				}
				AzjDZhVrYhCBshicWVHaBLwYJUIEA = null;
				mCKKQqXDNrfcIEuxJIedpjmmLhfG = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = mCKKQqXDNrfcIEuxJIedpjmmLhfG;
					ControllerMap jfedgHTjUdGudNCoCFTkYTwriali = JfedgHTjUdGudNCoCFTkYTwriali;
					switch (num)
					{
					default:
						return false;
					case 0:
						mCKKQqXDNrfcIEuxJIedpjmmLhfG = -1;
						if (ReInput._id != jfedgHTjUdGudNCoCFTkYTwriali.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(jfedgHTjUdGudNCoCFTkYTwriali.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						AzjDZhVrYhCBshicWVHaBLwYJUIEA = jfedgHTjUdGudNCoCFTkYTwriali.AllMaps.GetEnumerator();
						mCKKQqXDNrfcIEuxJIedpjmmLhfG = -3;
						break;
					case 1:
						mCKKQqXDNrfcIEuxJIedpjmmLhfG = -3;
						break;
					}
					while (AzjDZhVrYhCBshicWVHaBLwYJUIEA.MoveNext())
					{
						ActionElementMap current = AzjDZhVrYhCBshicWVHaBLwYJUIEA.Current;
						if (current._actionId == vaoETJCxlFJmJAeLyeTdwOxgSiJdA && (!qgEbWmcFWxnsSPdgRUaLwCDwzULfA || current.fpFEHHilwCsNTxvZcaeleakbBkQCb))
						{
							AfsrEpfhRuLGdTVnnJtCwbWSYAvf = current;
							mCKKQqXDNrfcIEuxJIedpjmmLhfG = 1;
							return true;
						}
					}
					tueWYSIyeVmSxbKwqzmXyewfTIRB();
					AzjDZhVrYhCBshicWVHaBLwYJUIEA = null;
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

			private void tueWYSIyeVmSxbKwqzmXyewfTIRB()
			{
				mCKKQqXDNrfcIEuxJIedpjmmLhfG = -1;
				if (AzjDZhVrYhCBshicWVHaBLwYJUIEA != null)
				{
					AzjDZhVrYhCBshicWVHaBLwYJUIEA.Dispose();
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
				LQtszOXQCICItNubLNRWBXGGpYKH lQtszOXQCICItNubLNRWBXGGpYKH;
				if (mCKKQqXDNrfcIEuxJIedpjmmLhfG == -2 && zwJzaPHbRHqlmNAfIEpaoEyfQoBy == Environment.CurrentManagedThreadId)
				{
					mCKKQqXDNrfcIEuxJIedpjmmLhfG = 0;
					lQtszOXQCICItNubLNRWBXGGpYKH = this;
				}
				else
				{
					lQtszOXQCICItNubLNRWBXGGpYKH = new LQtszOXQCICItNubLNRWBXGGpYKH(0);
					lQtszOXQCICItNubLNRWBXGGpYKH.JfedgHTjUdGudNCoCFTkYTwriali = JfedgHTjUdGudNCoCFTkYTwriali;
				}
				lQtszOXQCICItNubLNRWBXGGpYKH.vaoETJCxlFJmJAeLyeTdwOxgSiJdA = ltodDqfOUJXsWeLVGAVRKWufCobj;
				lQtszOXQCICItNubLNRWBXGGpYKH.qgEbWmcFWxnsSPdgRUaLwCDwzULfA = ZeaRItCIfZNnCmCajIvZvnzPqhVM;
				return lQtszOXQCICItNubLNRWBXGGpYKH;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class ZCRzzqIfcLHFiTvzQiinDFdmlSOU : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int HGsnNIFFWlQLrIMLlgBnHnjQLoCIA;

			private ActionElementMap YrTAdgFflrgwGaBXkroPdmJnAhLzB;

			private int EBYyEbAmOmopSjJnwItwLTHpdhL;

			public ControllerMap PzLBcSPebVKNWaZCrtqriYkGZFtd;

			private IControllerElementTarget IoxljBZQgagCBiSEFUTwgUFQayBhb;

			public IControllerElementTarget heNjZOWsgJwLDrSPIIDFuaVEMMvM;

			private bool nYatlrHIhwtWYJfgaOffWlyydfpL;

			public bool qAuWFXKWCpurixVMgFldfovlHHsx;

			private TempListPool.TList<ActionElementMap> mnvcBCUeqsISmNfqQfwnpXUbPoGr;

			private List<ActionElementMap>.Enumerator lMzWvDhVWmZHqtVoCiKVukVmmidj;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return YrTAdgFflrgwGaBXkroPdmJnAhLzB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YrTAdgFflrgwGaBXkroPdmJnAhLzB;
				}
			}

			[DebuggerHidden]
			public ZCRzzqIfcLHFiTvzQiinDFdmlSOU(int P_0)
			{
				HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = P_0;
				EBYyEbAmOmopSjJnwItwLTHpdhL = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int hGsnNIFFWlQLrIMLlgBnHnjQLoCIA = HGsnNIFFWlQLrIMLlgBnHnjQLoCIA;
				if ((uint)(hGsnNIFFWlQLrIMLlgBnHnjQLoCIA - -4) <= 1u || hGsnNIFFWlQLrIMLlgBnHnjQLoCIA == 1)
				{
					try
					{
						if (hGsnNIFFWlQLrIMLlgBnHnjQLoCIA == -4 || hGsnNIFFWlQLrIMLlgBnHnjQLoCIA == 1)
						{
							try
							{
							}
							finally
							{
								gRBBxgOlCCbOxwVQYwLOmWFtKlsI();
							}
						}
					}
					finally
					{
						nSDakdKifVRReDgXgeHroWKQlVejA();
					}
				}
				mnvcBCUeqsISmNfqQfwnpXUbPoGr = null;
				lMzWvDhVWmZHqtVoCiKVukVmmidj = default(List<ActionElementMap>.Enumerator);
				HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int hGsnNIFFWlQLrIMLlgBnHnjQLoCIA = HGsnNIFFWlQLrIMLlgBnHnjQLoCIA;
					ControllerMap pzLBcSPebVKNWaZCrtqriYkGZFtd = PzLBcSPebVKNWaZCrtqriYkGZFtd;
					switch (hGsnNIFFWlQLrIMLlgBnHnjQLoCIA)
					{
					default:
						return false;
					case 0:
					{
						HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -1;
						if (ReInput._id != pzLBcSPebVKNWaZCrtqriYkGZFtd.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(pzLBcSPebVKNWaZCrtqriYkGZFtd.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						mnvcBCUeqsISmNfqQfwnpXUbPoGr = TempListPool.GetTList<ActionElementMap>();
						HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -3;
						List<ActionElementMap> list = mnvcBCUeqsISmNfqQfwnpXUbPoGr.list;
						pzLBcSPebVKNWaZCrtqriYkGZFtd.rBPavCiiyAlojGkIqSyYebDCbwCgA(IoxljBZQgagCBiSEFUTwgUFQayBhb, false, -1, nYatlrHIhwtWYJfgaOffWlyydfpL, list, false, out var _);
						lMzWvDhVWmZHqtVoCiKVukVmmidj = list.GetEnumerator();
						HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -4;
						break;
					}
					case 1:
						HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -4;
						break;
					}
					if (lMzWvDhVWmZHqtVoCiKVukVmmidj.MoveNext())
					{
						ActionElementMap current = lMzWvDhVWmZHqtVoCiKVukVmmidj.Current;
						YrTAdgFflrgwGaBXkroPdmJnAhLzB = current;
						HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = 1;
						return true;
					}
					gRBBxgOlCCbOxwVQYwLOmWFtKlsI();
					lMzWvDhVWmZHqtVoCiKVukVmmidj = default(List<ActionElementMap>.Enumerator);
					nSDakdKifVRReDgXgeHroWKQlVejA();
					mnvcBCUeqsISmNfqQfwnpXUbPoGr = null;
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

			private void nSDakdKifVRReDgXgeHroWKQlVejA()
			{
				HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -1;
				if (mnvcBCUeqsISmNfqQfwnpXUbPoGr != null)
				{
					((IDisposable)mnvcBCUeqsISmNfqQfwnpXUbPoGr).Dispose();
				}
			}

			private void gRBBxgOlCCbOxwVQYwLOmWFtKlsI()
			{
				HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = -3;
				((IDisposable)lMzWvDhVWmZHqtVoCiKVukVmmidj/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				ZCRzzqIfcLHFiTvzQiinDFdmlSOU zCRzzqIfcLHFiTvzQiinDFdmlSOU;
				if (HGsnNIFFWlQLrIMLlgBnHnjQLoCIA == -2 && EBYyEbAmOmopSjJnwItwLTHpdhL == Environment.CurrentManagedThreadId)
				{
					HGsnNIFFWlQLrIMLlgBnHnjQLoCIA = 0;
					zCRzzqIfcLHFiTvzQiinDFdmlSOU = this;
				}
				else
				{
					zCRzzqIfcLHFiTvzQiinDFdmlSOU = new ZCRzzqIfcLHFiTvzQiinDFdmlSOU(0);
					zCRzzqIfcLHFiTvzQiinDFdmlSOU.PzLBcSPebVKNWaZCrtqriYkGZFtd = PzLBcSPebVKNWaZCrtqriYkGZFtd;
				}
				zCRzzqIfcLHFiTvzQiinDFdmlSOU.IoxljBZQgagCBiSEFUTwgUFQayBhb = heNjZOWsgJwLDrSPIIDFuaVEMMvM;
				zCRzzqIfcLHFiTvzQiinDFdmlSOU.nYatlrHIhwtWYJfgaOffWlyydfpL = qAuWFXKWCpurixVMgFldfovlHHsx;
				return zCRzzqIfcLHFiTvzQiinDFdmlSOU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class frQjfzAdouhYmsoqQhgcYIeTfBoz : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int pmNkfSVZynSRKDqPwkLqTYmQLCdC;

			private ActionElementMap iwCFShjNWHOiPSTHQpTOKeYiTLjw;

			private int PlctqMoRmdBbPJjmyhpoVrxpfrof;

			public ControllerMap SogajeJJnRnNCVlwnFCYGKmUoLYx;

			private IControllerElementTarget CAFFcFxPXtjEWrNcCVspQfdOqsbs;

			public IControllerElementTarget VjYHnCIYGIUIvwTKstcJcgbErgpK;

			private int AYMlsINwnkwpKhuKbVecKYjGewOM;

			public int GQtwFWZCoAdDyBFtOlFLZOhfYDWGA;

			private bool FrwDMEmSNBuoLPnmcScaUNhbuVEb;

			public bool IkfVtgpuQOdWfaNTgdmIqLPjlCpW;

			private TempListPool.TList<ActionElementMap> NixHgBvKDMUMrBPookckQpncXvZQ;

			private List<ActionElementMap>.Enumerator KjhTjJHdHZArmcXONUvarFnQjmCEA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return iwCFShjNWHOiPSTHQpTOKeYiTLjw;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return iwCFShjNWHOiPSTHQpTOKeYiTLjw;
				}
			}

			[DebuggerHidden]
			public frQjfzAdouhYmsoqQhgcYIeTfBoz(int P_0)
			{
				pmNkfSVZynSRKDqPwkLqTYmQLCdC = P_0;
				PlctqMoRmdBbPJjmyhpoVrxpfrof = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = pmNkfSVZynSRKDqPwkLqTYmQLCdC;
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
								zrnJsVIMwHsRWUVTWepNfjJPkUwl();
							}
						}
					}
					finally
					{
						uOnKADZPDmpgErOHqqXVyXSEEdLl();
					}
				}
				NixHgBvKDMUMrBPookckQpncXvZQ = null;
				KjhTjJHdHZArmcXONUvarFnQjmCEA = default(List<ActionElementMap>.Enumerator);
				pmNkfSVZynSRKDqPwkLqTYmQLCdC = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = pmNkfSVZynSRKDqPwkLqTYmQLCdC;
					ControllerMap sogajeJJnRnNCVlwnFCYGKmUoLYx = SogajeJJnRnNCVlwnFCYGKmUoLYx;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						pmNkfSVZynSRKDqPwkLqTYmQLCdC = -1;
						if (ReInput._id != sogajeJJnRnNCVlwnFCYGKmUoLYx.mpBAUdzpHzgMSYkDvIbQtxSHbBac)
						{
							ReInput.CheckInitialized(sogajeJJnRnNCVlwnFCYGKmUoLYx.mpBAUdzpHzgMSYkDvIbQtxSHbBac);
							return false;
						}
						NixHgBvKDMUMrBPookckQpncXvZQ = TempListPool.GetTList<ActionElementMap>();
						pmNkfSVZynSRKDqPwkLqTYmQLCdC = -3;
						List<ActionElementMap> list = NixHgBvKDMUMrBPookckQpncXvZQ.list;
						sogajeJJnRnNCVlwnFCYGKmUoLYx.rBPavCiiyAlojGkIqSyYebDCbwCgA(CAFFcFxPXtjEWrNcCVspQfdOqsbs, true, AYMlsINwnkwpKhuKbVecKYjGewOM, FrwDMEmSNBuoLPnmcScaUNhbuVEb, list, false, out var _);
						KjhTjJHdHZArmcXONUvarFnQjmCEA = list.GetEnumerator();
						pmNkfSVZynSRKDqPwkLqTYmQLCdC = -4;
						break;
					}
					case 1:
						pmNkfSVZynSRKDqPwkLqTYmQLCdC = -4;
						break;
					}
					if (KjhTjJHdHZArmcXONUvarFnQjmCEA.MoveNext())
					{
						ActionElementMap current = KjhTjJHdHZArmcXONUvarFnQjmCEA.Current;
						iwCFShjNWHOiPSTHQpTOKeYiTLjw = current;
						pmNkfSVZynSRKDqPwkLqTYmQLCdC = 1;
						return true;
					}
					zrnJsVIMwHsRWUVTWepNfjJPkUwl();
					KjhTjJHdHZArmcXONUvarFnQjmCEA = default(List<ActionElementMap>.Enumerator);
					uOnKADZPDmpgErOHqqXVyXSEEdLl();
					NixHgBvKDMUMrBPookckQpncXvZQ = null;
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

			private void uOnKADZPDmpgErOHqqXVyXSEEdLl()
			{
				pmNkfSVZynSRKDqPwkLqTYmQLCdC = -1;
				if (NixHgBvKDMUMrBPookckQpncXvZQ != null)
				{
					((IDisposable)NixHgBvKDMUMrBPookckQpncXvZQ).Dispose();
				}
			}

			private void zrnJsVIMwHsRWUVTWepNfjJPkUwl()
			{
				pmNkfSVZynSRKDqPwkLqTYmQLCdC = -3;
				((IDisposable)KjhTjJHdHZArmcXONUvarFnQjmCEA/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				frQjfzAdouhYmsoqQhgcYIeTfBoz frQjfzAdouhYmsoqQhgcYIeTfBoz2;
				if (pmNkfSVZynSRKDqPwkLqTYmQLCdC == -2 && PlctqMoRmdBbPJjmyhpoVrxpfrof == Environment.CurrentManagedThreadId)
				{
					pmNkfSVZynSRKDqPwkLqTYmQLCdC = 0;
					frQjfzAdouhYmsoqQhgcYIeTfBoz2 = this;
				}
				else
				{
					frQjfzAdouhYmsoqQhgcYIeTfBoz2 = new frQjfzAdouhYmsoqQhgcYIeTfBoz(0);
					frQjfzAdouhYmsoqQhgcYIeTfBoz2.SogajeJJnRnNCVlwnFCYGKmUoLYx = SogajeJJnRnNCVlwnFCYGKmUoLYx;
				}
				frQjfzAdouhYmsoqQhgcYIeTfBoz2.CAFFcFxPXtjEWrNcCVspQfdOqsbs = VjYHnCIYGIUIvwTKstcJcgbErgpK;
				frQjfzAdouhYmsoqQhgcYIeTfBoz2.AYMlsINwnkwpKhuKbVecKYjGewOM = GQtwFWZCoAdDyBFtOlFLZOhfYDWGA;
				frQjfzAdouhYmsoqQhgcYIeTfBoz2.FrwDMEmSNBuoLPnmcScaUNhbuVEb = IkfVtgpuQOdWfaNTgdmIqLPjlCpW;
				return frQjfzAdouhYmsoqQhgcYIeTfBoz2;
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

		internal readonly int mpBAUdzpHzgMSYkDvIbQtxSHbBac;

		private double bJfKoqbavGWAUEJwlrUFjmflQUlJ;

		private readonly AList<ActionElementMap> QsEBFwiqUNJUXsFQkdPdzvCCsdTl;

		private readonly ReadOnlyCollection<ActionElementMap> JEtSHhqekFIbDCJFBzWfbowgHEbj;

		private readonly AList<ActionElementMap> vpxRYwSuNESIZtdukURAlmKtlAaG;

		private readonly ReadOnlyCollection<ActionElementMap> uBDbNUBevLCxgaOyPHJXTBhsnqZcA;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int GADcnKibrsCRNsbxIhdCHAgGywHAb;

		private static int JAsPNbOPiehVLtLWEDpbcUJMpQCy;

		private static int JFMAewvrIWUvwzIOcSRFLacaPSWr
		{
			get
			{
				int gADcnKibrsCRNsbxIhdCHAgGywHAb = GADcnKibrsCRNsbxIhdCHAgGywHAb;
				if (GADcnKibrsCRNsbxIhdCHAgGywHAb == int.MaxValue)
				{
					GADcnKibrsCRNsbxIhdCHAgGywHAb = 0;
					return gADcnKibrsCRNsbxIhdCHAgGywHAb;
				}
				GADcnKibrsCRNsbxIhdCHAgGywHAb++;
				return gADcnKibrsCRNsbxIhdCHAgGywHAb;
			}
		}

		internal static bool zteQuuSexOuGIMexYXxmoSFiwOFH => JAsPNbOPiehVLtLWEDpbcUJMpQCy > 0;

		public int id
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return 0;
				}
				return vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return 0;
				}
				return QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return uBDbNUBevLCxgaOyPHJXTBhsnqZcA;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return uBDbNUBevLCxgaOyPHJXTBhsnqZcA;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
				{
					ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return JEtSHhqekFIbDCJFBzWfbowgHEbj;
			}
		}

		public double modifiedTime
		{
			get
			{
				int count = vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
				double num = bJfKoqbavGWAUEJwlrUFjmflQUlJ;
				for (int i = 0; i < count; i++)
				{
					if (vpxRYwSuNESIZtdukURAlmKtlAaG[i] != null && vpxRYwSuNESIZtdukURAlmKtlAaG[i].modifiedTime > num)
					{
						num = vpxRYwSuNESIZtdukURAlmKtlAaG[i].modifiedTime;
					}
				}
				return num;
			}
		}

		public bool isModified
		{
			get
			{
				if (bJfKoqbavGWAUEJwlrUFjmflQUlJ > 0.0)
				{
					return true;
				}
				int count = vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
				for (int i = 0; i < count; i++)
				{
					if (vpxRYwSuNESIZtdukURAlmKtlAaG[i] != null && vpxRYwSuNESIZtdukURAlmKtlAaG[i].isModified)
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
					bJfKoqbavGWAUEJwlrUFjmflQUlJ = ReInput.realTime;
					return;
				}
				bJfKoqbavGWAUEJwlrUFjmflQUlJ = 0.0;
				int count = vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
				_ = bJfKoqbavGWAUEJwlrUFjmflQUlJ;
				for (int i = 0; i < count; i++)
				{
					if (vpxRYwSuNESIZtdukURAlmKtlAaG[i] != null)
					{
						vpxRYwSuNESIZtdukURAlmKtlAaG[i].isModified = value;
					}
				}
			}
		}

		internal AList<ActionElementMap> QzzwgmKQPAOvkCxEzGFvpXQEKzfn => QsEBFwiqUNJUXsFQkdPdzvCCsdTl;

		public ControllerMap()
		{
			_id = JFMAewvrIWUvwzIOcSRFLacaPSWr;
			_sourceMapId = -1;
			QsEBFwiqUNJUXsFQkdPdzvCCsdTl = new AList<ActionElementMap>();
			JEtSHhqekFIbDCJFBzWfbowgHEbj = new ReadOnlyCollection<ActionElementMap>(QsEBFwiqUNJUXsFQkdPdzvCCsdTl);
			vpxRYwSuNESIZtdukURAlmKtlAaG = new AList<ActionElementMap>();
			uBDbNUBevLCxgaOyPHJXTBhsnqZcA = new ReadOnlyCollection<ActionElementMap>(vpxRYwSuNESIZtdukURAlmKtlAaG);
			mpBAUdzpHzgMSYkDvIbQtxSHbBac = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = JFMAewvrIWUvwzIOcSRFLacaPSWr;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			QXFruTPDQsWAkpbQTcKsnAHJFyR();
			if (P_0.QsEBFwiqUNJUXsFQkdPdzvCCsdTl != null)
			{
				int count = P_0.QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
				for (int i = 0; i < count; i++)
				{
					IbCjAnavdGalMAHjHWOfAIxAblZRA(new ActionElementMap(P_0.QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]));
				}
			}
			rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			bJfKoqbavGWAUEJwlrUFjmflQUlJ = P_0.bJfKoqbavGWAUEJwlrUFjmflQUlJ;
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			AList<ActionElementMap> aList = vpxRYwSuNESIZtdukURAlmKtlAaG;
			for (int i = 0; i < aList.Count; i++)
			{
				if (vpxRYwSuNESIZtdukURAlmKtlAaG[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			AList<ActionElementMap> aList = vpxRYwSuNESIZtdukURAlmKtlAaG;
			for (int i = 0; i < aList.Count; i++)
			{
				if (vpxRYwSuNESIZtdukURAlmKtlAaG[i].keyCode == keyCode && vpxRYwSuNESIZtdukURAlmKtlAaG[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = vpxRYwSuNESIZtdukURAlmKtlAaG;
			for (int i = 0; i < aList.Count; i++)
			{
				if (vpxRYwSuNESIZtdukURAlmKtlAaG[i].oETQtUYpoAHvrDdxockLYpfjFkywA == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			AList<ActionElementMap> aList = vpxRYwSuNESIZtdukURAlmKtlAaG;
			for (int i = 0; i < aList.Count; i++)
			{
				if (vpxRYwSuNESIZtdukURAlmKtlAaG[i].oETQtUYpoAHvrDdxockLYpfjFkywA == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, nwsTruCLxjorysrNysDvPYrmMcrb.jufGHxaTwzWJImsLUguNuiJYioFNA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.MLdcpPOYjvtoDJPENGusyemNCWAq(this, actionElementMap);
			IbCjAnavdGalMAHjHWOfAIxAblZRA(actionElementMap);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			LoOOFopNymweGkhICBgeiHdUEeUL loOOFopNymweGkhICBgeiHdUEeUL = LoOOFopNymweGkhICBgeiHdUEeUL.UaVVPtvWihBrKzlASqiBWrxEWjrT(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, loOOFopNymweGkhICBgeiHdUEeUL.OMRhQCEiYlNzaSriRcREAoaCzxXd, loOOFopNymweGkhICBgeiHdUEeUL.rKeyPvoMRxPgPuZsprieAWrKjSHd, loOOFopNymweGkhICBgeiHdUEeUL.KodeWlfDCBFOFRAqGTjUYDBmAlyR, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			IbCjAnavdGalMAHjHWOfAIxAblZRA(actionElementMap);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, nwsTruCLxjorysrNysDvPYrmMcrb.jufGHxaTwzWJImsLUguNuiJYioFNA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (VvyAeBiZeXNHYhpPckZVSxcCOSUj(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Button;
				IbCjAnavdGalMAHjHWOfAIxAblZRA(elementMap);
			}
			if (VvyAeBiZeXNHYhpPckZVSxcCOSUj(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.oVNtKSQqscPoTmIFTjtPqClSbOoK();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			elementMap.rHgwzDeevogrpEWvEJimsIWKVGff();
			ReInput.controllers.Keyboard.MLdcpPOYjvtoDJPENGusyemNCWAq(this, elementMap);
			result = elementMap;
			NYrIpryxvdZqmpgEkCfTusMBMiPF();
			return true;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			LoOOFopNymweGkhICBgeiHdUEeUL loOOFopNymweGkhICBgeiHdUEeUL = LoOOFopNymweGkhICBgeiHdUEeUL.UaVVPtvWihBrKzlASqiBWrxEWjrT(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, loOOFopNymweGkhICBgeiHdUEeUL.OMRhQCEiYlNzaSriRcREAoaCzxXd, loOOFopNymweGkhICBgeiHdUEeUL.rKeyPvoMRxPgPuZsprieAWrKjSHd, loOOFopNymweGkhICBgeiHdUEeUL.KodeWlfDCBFOFRAqGTjUYDBmAlyR, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				result = null;
				return false;
			}
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(elementType))
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
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Button;
				IbCjAnavdGalMAHjHWOfAIxAblZRA(elementMap);
			}
			if (VvyAeBiZeXNHYhpPckZVSxcCOSUj(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			QdHGgBretdLFkyCDGZYipGsllcwO(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			NYrIpryxvdZqmpgEkCfTusMBMiPF();
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			int num = VvyAeBiZeXNHYhpPckZVSxcCOSUj(elementMapId);
			if (num < 0)
			{
				return false;
			}
			EhgEHzQVIvHRdHJzxjDZVtlzKXZEA(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].oETQtUYpoAHvrDdxockLYpfjFkywA == elementMapId)
				{
					return QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (!skipDisabledMaps || allMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return vqaXCYYIhKNPKOEecIkrfTkLlJDMA(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return NsDAUTdPDDxqNrCesiwnZQUpFRfaA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(LQtszOXQCICItNubLNRWBXGGpYKH))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new LQtszOXQCICItNubLNRWBXGGpYKH(-2)
			{
				JfedgHTjUdGudNCoCFTkYTwriali = this,
				ltodDqfOUJXsWeLVGAVRKWufCobj = actionId,
				ZeaRItCIfZNnCmCajIvZvnzPqhVM = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._actionId == actionId && (!skipDisabledMaps || QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					return QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, skipDisabledMaps);
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
			return result;
		}

		[IteratorStateMachine(typeof(ZCRzzqIfcLHFiTvzQiinDFdmlSOU))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new ZCRzzqIfcLHFiTvzQiinDFdmlSOU(-2)
			{
				PzLBcSPebVKNWaZCrtqriYkGZFtd = this,
				heNjZOWsgJwLDrSPIIDFuaVEMMvM = elementTarget,
				qAuWFXKWCpurixVMgFldfovlHHsx = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, actionId, skipDisabledMaps);
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(frQjfzAdouhYmsoqQhgcYIeTfBoz))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new frQjfzAdouhYmsoqQhgcYIeTfBoz(-2)
			{
				SogajeJJnRnNCVlwnFCYGKmUoLYx = this,
				VjYHnCIYGIUIvwTKstcJcgbErgpK = elementTarget,
				GQtwFWZCoAdDyBFtOlFLZOhfYDWGA = actionId,
				IkfVtgpuQOdWfaNTgdmIqLPjlCpW = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, skipDisabledMaps);
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			bool flag;
			return KxrsILBDQpdqcePUNUZVkTrjmufQA(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, actionId, skipDisabledMaps);
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			bool flag;
			return KxrsILBDQpdqcePUNUZVkTrjmufQA(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, skipDisabledMaps, results);
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			bool flag;
			return rBPavCiiyAlojGkIqSyYebDCbwCgA(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = JrHSDKJJRmfQuafjRnKcPPKpIBhpA.hCBMMpiSqNKuftopqJiKegMStdpm(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(jrHSDKJJRmfQuafjRnKcPPKpIBhpA, actionId, skipDisabledMaps, results);
			JrHSDKJJRmfQuafjRnKcPPKpIBhpA.mEWWRvXleLvCZfUUVlNaMPaNPoTO(jrHSDKJJRmfQuafjRnKcPPKpIBhpA);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			bool flag;
			return rBPavCiiyAlojGkIqSyYebDCbwCgA(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			return shYLCVYqeFdYjcuwKYtizeWbDwqy(predicate, false);
		}

		internal virtual ActionElementMap shYLCVYqeFdYjcuwKYtizeWbDwqy(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return OKenFGazOJnNyeUsnUjNYmgBxgai(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return eavfqqgRRryNzHBuhehtClpUwAzeb(predicate, false, results, false);
		}

		internal virtual int eavfqqgRRryNzHBuhehtClpUwAzeb(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return VwrslHnFQHQXGFCSeARfdbqdPWAFA(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			int count = vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = vpxRYwSuNESIZtdukURAlmKtlAaG[i];
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return;
			}
			QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Clear();
			vpxRYwSuNESIZtdukURAlmKtlAaG.Clear();
			NYrIpryxvdZqmpgEkCfTusMBMiPF();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int num = 0;
			int count = vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = vpxRYwSuNESIZtdukURAlmKtlAaG[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb != state)
				{
					actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null || index < 0 || index >= QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count)
			{
				return null;
			}
			return QsEBFwiqUNJUXsFQkdPdzvCCsdTl[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(QsEBFwiqUNJUXsFQkdPdzvCCsdTl);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return xfVXjBkZAVGhrgckqPJbcqZLUKTs(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
				ActionElementMap actionElementMap2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			InputAction inputAction = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.OyHTFLcgDilBXYhxjDyZLUPUhlgCA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return hGHOjSLPgnLbpeTHVWqYczIgnyiC(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(LFixKTwcjYcXxWnkcAnNOyRPRiLJ))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new LFixKTwcjYcXxWnkcAnNOyRPRiLJ(-2)
			{
				WZoBVwBDlzTHeQGvPElZEmpSYBIbA = this,
				iqIlrxNMYHfnHPmDqNJhXzucfvZp = actionId,
				scxGPCaSyPXprWIuMzMqhSStinIjb = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			int actionId = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			return OKenFGazOJnNyeUsnUjNYmgBxgai(predicate, false);
		}

		internal ActionElementMap OKenFGazOJnNyeUsnUjNYmgBxgai(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return VwrslHnFQHQXGFCSeARfdbqdPWAFA(predicate, false, results, false);
		}

		internal int VwrslHnFQHQXGFCSeARfdbqdPWAFA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			int count = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
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
			return DeleteButtonMapsWithAction(ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					EhgEHzQVIvHRdHJzxjDZVtlzKXZEA(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			int num = 0;
			int count = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb != state)
				{
					actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb = state;
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (skipDisabledMaps && !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			if (actionElementMap == null || QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
			{
				return false;
			}
			for (int i = 0; i < QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count; i++)
			{
				ActionElementMap actionElementMap2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return false;
			}
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
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
			for (int i = 0; i < QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count; i++)
			{
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if ((!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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

		[IteratorStateMachine(typeof(GSDqTQgZpqBHLDaDrmNeCIWNtvgB))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new GSDqTQgZpqBHLDaDrmNeCIWNtvgB(-2)
			{
				NphrNyKhKTCSHGneaAeNUhHZuDAH = this,
				pMEMXMeoxAmyXVcfgMOgmHSJbxLG = controllerMap,
				LsBsRsZlUVaYPHuuCZHiqJMYrqgdA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(ZKJNSHBGaNNeHyNAceYTIPRZgmcL))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new ZKJNSHBGaNNeHyNAceYTIPRZgmcL(-2)
			{
				eaChDKOkFOHqRpJTXnlSxvJdRMQu = this,
				FALzdoymJYTjnZJqjggIJRCvpDEr = actionElementMap,
				gjusWDZbbArBTgoTwmgKsnTGfKfZ = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(lTtQucLWhtSlfVIPvGfmiRJEyUwH))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new lTtQucLWhtSlfVIPvGfmiRJEyUwH(-2)
			{
				gooxXJrmaTJjtdKfluzJFnDeOrCP = this,
				ypYBrgsxKpgIHHKTtLmKwuldFeOeA = conflictCheck,
				zsbSAWUxRSWKUAOTCTfzGzmOpUO = skipDisabledMaps
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return num;
			}
			IList<ActionElementMap> qsEBFwiqUNJUXsFQkdPdzvCCsdTl = controllerMap.QsEBFwiqUNJUXsFQkdPdzvCCsdTl;
			if (qsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = qsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			for (int num2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[num2];
				if (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || qsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(qsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]))
						{
							EhgEHzQVIvHRdHJzxjDZVtlzKXZEA(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return num;
			}
			for (int num2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[num2];
				if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					EhgEHzQVIvHRdHJzxjDZVtlzKXZEA(actionElementMap2.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
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
			for (int num2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[num2];
				if ((!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					EhgEHzQVIvHRdHJzxjDZVtlzKXZEA(actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return nvmchnKoGxXFaoBqqNGNvPjIqMun(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return lcZlggKEXkqAPCwiNeGdvZOKjNuk(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return TkdZQUCDguLHxVfhnjqQyiCLqOMJ(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return nvmchnKoGxXFaoBqqNGNvPjIqMun(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return lcZlggKEXkqAPCwiNeGdvZOKjNuk(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return 0;
			}
			return TkdZQUCDguLHxVfhnjqQyiCLqOMJ(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int nvmchnKoGxXFaoBqqNGNvPjIqMun(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return num;
			}
			IList<ActionElementMap> qsEBFwiqUNJUXsFQkdPdzvCCsdTl = P_0.QsEBFwiqUNJUXsFQkdPdzvCCsdTl;
			if (qsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = qsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (!actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = qsEBFwiqUNJUXsFQkdPdzvCCsdTl[j];
					if ((!P_1 || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int lcZlggKEXkqAPCwiNeGdvZOKjNuk(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int TkdZQUCDguLHxVfhnjqQyiCLqOMJ(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (vpxRYwSuNESIZtdukURAlmKtlAaG == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.vpxRYwSuNESIZtdukURAlmKtlAaG;
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
			for (int num2 = vpxRYwSuNESIZtdukURAlmKtlAaG.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = vpxRYwSuNESIZtdukURAlmKtlAaG[num2];
				if (!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.CheckForAssignmentConflict(list[i]))
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
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
			if (vpxRYwSuNESIZtdukURAlmKtlAaG == null)
			{
				return num;
			}
			for (int num2 = vpxRYwSuNESIZtdukURAlmKtlAaG.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = vpxRYwSuNESIZtdukURAlmKtlAaG[num2];
				if ((!skipDisabledMaps || actionElementMap2.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			if (vpxRYwSuNESIZtdukURAlmKtlAaG == null)
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
			for (int num2 = vpxRYwSuNESIZtdukURAlmKtlAaG.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = vpxRYwSuNESIZtdukURAlmKtlAaG[num2];
				if ((!skipDisabledMaps || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb) && actionElementMap.oETQtUYpoAHvrDdxockLYpfjFkywA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				array[i] = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return string.Empty;
			}
			try
			{
				return iDuaxxMnInLjyxRlivDzZyCqnIWW().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return string.Empty;
			}
			try
			{
				return iDuaxxMnInLjyxRlivDzZyCqnIWW().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
				TOvbXCLGpcDMwICKloBsHgxZNTif tOvbXCLGpcDMwICKloBsHgxZNTif = ReInput.iVXcdPPjNjXrBRmVJUjdVLfzNocd(templateTypeGuid);
				string text = ((tOvbXCLGpcDMwICKloBsHgxZNTif != null) ? tOvbXCLGpcDMwICKloBsHgxZNTif.psWSGDUmMYArjDorAlBQoJJUZoExA : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.phkgPytItgWtvYBtYCZqEveflFeX(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
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
			return ControllerTemplateMap.phkgPytItgWtvYBtYCZqEveflFeX(controllerTemplate, this);
		}

		private ControllerTemplateMap IziSlCksntrVBXSWLVjEYBLNTMSH(IControllerTemplate P_0)
		{
			if (ReInput._id != mpBAUdzpHzgMSYkDvIbQtxSHbBac)
			{
				ReInput.CheckInitialized(mpBAUdzpHzgMSYkDvIbQtxSHbBac);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.phkgPytItgWtvYBtYCZqEveflFeX(P_0, this);
		}

		internal virtual bool ZsPqvQrjowcgLqmuMupUIUTcDTMs(ActionElementMap P_0)
		{
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_0._elementType))
			{
				return false;
			}
			IbCjAnavdGalMAHjHWOfAIxAblZRA(P_0);
			return true;
		}

		internal virtual int vqaXCYYIhKNPKOEecIkrfTkLlJDMA(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					P_0.Add(QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap YSEbqnGErPYLIWehbqoBhlTPihkeb(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_2))
			{
				return null;
			}
			int num = yeSwNhTrKtnYGhtLVUlYnhhoKdNl(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return QsEBFwiqUNJUXsFQkdPdzvCCsdTl[num];
		}

		internal virtual int vjtrFFQofKYynFPXHpVoAoxzXuhC(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._elementIdentifierId == P_0)
				{
					P_1.Add(QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool cApqyZdpFLngxdbLjgqiypzhAEct(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._elementIdentifierId == P_0 && QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int yeSwNhTrKtnYGhtLVUlYnhhoKdNl(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_2))
			{
				return -1;
			}
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._elementIdentifierId == P_0 && QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int VvyAeBiZeXNHYhpPckZVSxcCOSUj(int P_0)
		{
			if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].oETQtUYpoAHvrDdxockLYpfjFkywA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int xfVXjBkZAVGhrgckqPJbcqZLUKTs(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (!P_0 || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int hGHOjSLPgnLbpeTHVWqYczIgnyiC(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int NsDAUTdPDDxqNrCesiwnZQUpFRfaA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fpFEHHilwCsNTxvZcaeleakbBkQCb))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap KxrsILBDQpdqcePUNUZVkTrjmufQA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!TIloVlvQucKhqTgtArBoISsJnltu(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._actionId == P_2) && (!P_3 || QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].fpFEHHilwCsNTxvZcaeleakbBkQCb) && QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].IsTarget(P_0))
				{
					return QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i];
				}
			}
			return null;
		}

		internal virtual int rBPavCiiyAlojGkIqSyYebDCbwCgA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!TIloVlvQucKhqTgtArBoISsJnltu(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]._actionId == P_2) && (!P_3 || QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].fpFEHHilwCsNTxvZcaeleakbBkQCb) && QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].IsTarget(P_0))
				{
					P_4.Add(QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i]);
					num++;
				}
			}
			return num;
		}

		internal void AbiAfRteUVBHlKspuaxwGgFjLKlC(int P_0, ControllerElementType P_1)
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
				UShaZMuDukPvPwnrsztNpMZlRrNe(elementMap);
			}
		}

		internal virtual bool UShaZMuDukPvPwnrsztNpMZlRrNe(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!PcsLRFiwarKJxHWxHQkzRqpDaYze(P_0._elementType))
			{
				return false;
			}
			QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Add(P_0);
			IEKFdHyLBMRIBawFQLeZlGdsqfiP(P_0);
			return true;
		}

		internal bool TIloVlvQucKhqTgtArBoISsJnltu(IControllerElementTarget P_0)
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

		internal bool RNeOYPoEHRIsiNlToZQsNTYcDSPS(string P_0)
		{
			try
			{
				XQNasbYvCKmFWyBnNCTsukEWkaNM(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool iBjFSVlKzgmNUdLlAycNVGDMotNK(string P_0)
		{
			try
			{
				XQNasbYvCKmFWyBnNCTsukEWkaNM(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void IEKFdHyLBMRIBawFQLeZlGdsqfiP(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				vpxRYwSuNESIZtdukURAlmKtlAaG.Add(P_0);
				vpxRYwSuNESIZtdukURAlmKtlAaG.Sort(NflAbolMayPdbWLkqXxHHJrBLpNc.JnGLkxyhNVBElfWSYtEIRDlbiEUm);
				NYrIpryxvdZqmpgEkCfTusMBMiPF();
			}
		}

		internal void OVMcPGiNBsSQAOJWyFpceVfjMXGwA(int P_0)
		{
			int num = PSFEESzTRZjiICKtTVkXnbLsjGeJA(P_0);
			if (num >= 0)
			{
				vpxRYwSuNESIZtdukURAlmKtlAaG.RemoveAt(num);
				NYrIpryxvdZqmpgEkCfTusMBMiPF();
			}
		}

		internal void qBKYqzpkXrfxTBpBHVsfvIYAxJjs(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = PSFEESzTRZjiICKtTVkXnbLsjGeJA(P_0);
				if (num >= 0)
				{
					vpxRYwSuNESIZtdukURAlmKtlAaG[num] = P_1;
					vpxRYwSuNESIZtdukURAlmKtlAaG.Sort(NflAbolMayPdbWLkqXxHHJrBLpNc.JnGLkxyhNVBElfWSYtEIRDlbiEUm);
					NYrIpryxvdZqmpgEkCfTusMBMiPF();
				}
			}
		}

		internal static void QdHGgBretdLFkyCDGZYipGsllcwO(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.oVNtKSQqscPoTmIFTjtPqClSbOoK();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			P_0._elementIdentifierId = P_3;
			P_0._axisContribution = P_2;
			P_0._axisRange = P_5;
			if (P_4 == ControllerElementType.Axis)
			{
				P_0._invert = P_6;
			}
			P_0.rHgwzDeevogrpEWvEJimsIWKVGff();
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId)?.MLdcpPOYjvtoDJPENGusyemNCWAq(this, map);
			}
		}

		internal virtual bool XQNasbYvCKmFWyBnNCTsukEWkaNM(SerializedObject P_0)
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
						actionElementMap.eCQgvXXJzdnqwECUsFlURVcvFcrP(value2);
						if (ActionElementMap.evHDvbedLElPGfboBQYyRNAjBnjcA(actionElementMap))
						{
							IbCjAnavdGalMAHjHWOfAIxAblZRA(actionElementMap);
						}
					}
				}
			}
			NYrIpryxvdZqmpgEkCfTusMBMiPF();
			return flag;
		}

		internal virtual void ccGlFtRmhwrbuTunsxwiZCRPTZVC(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "dataVersion",
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string qqfRFgGAtDPLKSLpFGzHGleMdWxAb = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
				{
					pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "hardwareGuid",
					qqfRFgGAtDPLKSLpFGzHGleMdWxAb = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
				{
					pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "hardwareName",
					qqfRFgGAtDPLKSLpFGzHGleMdWxAb = qqfRFgGAtDPLKSLpFGzHGleMdWxAb
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				WxmFjndTttjqQAYFRlGSZJiUawrZ = "xmlns",
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "xsi",
				FnmpvPDmwsSGLmiBdhdjjjOdjSKDb = null,
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				WxmFjndTttjqQAYFRlGSZJiUawrZ = "xsi",
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "schemaLocation",
				FnmpvPDmwsSGLmiBdhdjjjOdjSKDb = null,
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i] != null)
				{
					list.Add(QsEBFwiqUNJUXsFQkdPdzvCCsdTl[i].gKPyKtvIOoYDmxjbtpXpzKKsHdmL());
				}
			}
		}

		private bool PcsLRFiwarKJxHWxHQkzRqpDaYze(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void EhgEHzQVIvHRdHJzxjDZVtlzKXZEA(int P_0, int P_1)
		{
			OVMcPGiNBsSQAOJWyFpceVfjMXGwA(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				QsEBFwiqUNJUXsFQkdPdzvCCsdTl.RemoveAt(P_1);
			}
		}

		private void IbCjAnavdGalMAHjHWOfAIxAblZRA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				QsEBFwiqUNJUXsFQkdPdzvCCsdTl.Add(P_0);
				IEKFdHyLBMRIBawFQLeZlGdsqfiP(P_0);
			}
		}

		private void xLEpGluvdCIWWJaeWDKdkhjcqkfO(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				qBKYqzpkXrfxTBpBHVsfvIYAxJjs(QsEBFwiqUNJUXsFQkdPdzvCCsdTl[P_1].oETQtUYpoAHvrDdxockLYpfjFkywA, P_0);
				QsEBFwiqUNJUXsFQkdPdzvCCsdTl[P_1] = P_0;
			}
		}

		private int PSFEESzTRZjiICKtTVkXnbLsjGeJA(int P_0)
		{
			if (vpxRYwSuNESIZtdukURAlmKtlAaG == null)
			{
				return -1;
			}
			int count = vpxRYwSuNESIZtdukURAlmKtlAaG.Count;
			for (int i = 0; i < count; i++)
			{
				if (vpxRYwSuNESIZtdukURAlmKtlAaG[i].oETQtUYpoAHvrDdxockLYpfjFkywA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject iDuaxxMnInLjyxRlivDzZyCqnIWW()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ccGlFtRmhwrbuTunsxwiZCRPTZVC(serializedObject);
			return serializedObject;
		}

		internal void NYrIpryxvdZqmpgEkCfTusMBMiPF()
		{
			if (!zteQuuSexOuGIMexYXxmoSFiwOFH)
			{
				bJfKoqbavGWAUEJwlrUFjmflQUlJ = ReInput.realTime;
			}
		}

		public static ControllerMap Create(Controller controller, int categoryId, int layoutId)
		{
			return TLEobasZFUPjrWXdtnOusyvdjpCg(controller, categoryId, layoutId);
		}

		internal static ControllerMap cqhZHeJRTSeEFHBVRFEAXCJriwBEA(ControllerType P_0)
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

		internal static ControllerMap TLEobasZFUPjrWXdtnOusyvdjpCg(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.YDfKfWCnUJFlcsnXDeXOChJkeRvu(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.ANjGDdEBPdEoyOMAokkZuXRxPUIc(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.CJCLlbCvZdqNSnSfcrefXBbDHzmX(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.PhiOTwnerjFBmSkwgINpfZEiwpoc(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = cqhZHeJRTSeEFHBVRFEAXCJriwBEA(controllerType);
			try
			{
				QXFruTPDQsWAkpbQTcKsnAHJFyR();
				controllerMap.RNeOYPoEHRIsiNlToZQsNTYcDSPS(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
			finally
			{
				rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = cqhZHeJRTSeEFHBVRFEAXCJriwBEA(controllerType);
			try
			{
				QXFruTPDQsWAkpbQTcKsnAHJFyR();
				controllerMap.iBjFSVlKzgmNUdLlAycNVGDMotNK(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
			finally
			{
				rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		internal static void QXFruTPDQsWAkpbQTcKsnAHJFyR()
		{
			JAsPNbOPiehVLtLWEDpbcUJMpQCy++;
		}

		internal static void rzztgLcwyNrsBpkJvbDdCIBmMzrLA()
		{
			JAsPNbOPiehVLtLWEDpbcUJMpQCy--;
			if (JAsPNbOPiehVLtLWEDpbcUJMpQCy < 0)
			{
				JAsPNbOPiehVLtLWEDpbcUJMpQCy = 0;
				Logger.LogError("Too many calls to disable internal modify mode!");
			}
		}
	}
}
