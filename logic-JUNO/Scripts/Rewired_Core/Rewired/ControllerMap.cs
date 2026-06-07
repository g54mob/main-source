using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class FSbhMIVhgNzYbVzdoFUrPEWtTkuS : IComparer<ActionElementMap>
		{
			public static FSbhMIVhgNzYbVzdoFUrPEWtTkuS SXpsgyLUlEFDAqPvifBPpFWQWbhS;

			public static FSbhMIVhgNzYbVzdoFUrPEWtTkuS PtKLHIIIdciAffumGvgGpRwHrrHmA => SXpsgyLUlEFDAqPvifBPpFWQWbhS ?? (SXpsgyLUlEFDAqPvifBPpFWQWbhS = new FSbhMIVhgNzYbVzdoFUrPEWtTkuS());

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

		private sealed class gzGgtBghOUkdjtLBsqBMEReKvFRGB : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int NvCbGuKSGsCeqFOaiaRJdXaBqADyC;

			private ActionElementMap hQHYSKUESxMniWoFcsZMPGiHSqff;

			private int kQbxoVrJTaHFzyeHhQJVrNIhGlgcA;

			public ControllerMap xFMIRwivsngnKZQkyFayFlnHtalnb;

			private int XCaeGOEKzTHBxzcfPVLtmgffXktO;

			public int eWZbCvGeCEOvTeZvrecKUnbYKNClA;

			private bool azmHFTHXCEINFoIXRchtaBwEfFQIA;

			public bool yMKbopeKPPHEDphFxGYgvOLJPvUuA;

			private IList<ActionElementMap> AWTAfamxlxrUyNdUNzQISAojORBp;

			private int VEZDigMekSMkJfXlaswsDhgxKjjj;

			private int GDrTOVUOFZxfiQIUDsXmopFsChMB;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return hQHYSKUESxMniWoFcsZMPGiHSqff;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hQHYSKUESxMniWoFcsZMPGiHSqff;
				}
			}

			[DebuggerHidden]
			public gzGgtBghOUkdjtLBsqBMEReKvFRGB(int P_0)
			{
				NvCbGuKSGsCeqFOaiaRJdXaBqADyC = P_0;
				kQbxoVrJTaHFzyeHhQJVrNIhGlgcA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int nvCbGuKSGsCeqFOaiaRJdXaBqADyC = NvCbGuKSGsCeqFOaiaRJdXaBqADyC;
				ControllerMap controllerMap = xFMIRwivsngnKZQkyFayFlnHtalnb;
				if (nvCbGuKSGsCeqFOaiaRJdXaBqADyC != 0)
				{
					if (nvCbGuKSGsCeqFOaiaRJdXaBqADyC != 1)
					{
						return false;
					}
					NvCbGuKSGsCeqFOaiaRJdXaBqADyC = -1;
					goto IL_00af;
				}
				NvCbGuKSGsCeqFOaiaRJdXaBqADyC = -1;
				if (ReInput._id != controllerMap.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(controllerMap.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return false;
				}
				if (XCaeGOEKzTHBxzcfPVLtmgffXktO < 0)
				{
					return false;
				}
				AWTAfamxlxrUyNdUNzQISAojORBp = controllerMap.ButtonMaps;
				VEZDigMekSMkJfXlaswsDhgxKjjj = controllerMap.buttonMapCount;
				GDrTOVUOFZxfiQIUDsXmopFsChMB = 0;
				goto IL_00bf;
				IL_00bf:
				if (GDrTOVUOFZxfiQIUDsXmopFsChMB < VEZDigMekSMkJfXlaswsDhgxKjjj)
				{
					ActionElementMap actionElementMap = AWTAfamxlxrUyNdUNzQISAojORBp[GDrTOVUOFZxfiQIUDsXmopFsChMB];
					if (actionElementMap._actionId == XCaeGOEKzTHBxzcfPVLtmgffXktO && (!azmHFTHXCEINFoIXRchtaBwEfFQIA || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
					{
						hQHYSKUESxMniWoFcsZMPGiHSqff = actionElementMap;
						NvCbGuKSGsCeqFOaiaRJdXaBqADyC = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				GDrTOVUOFZxfiQIUDsXmopFsChMB++;
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
				gzGgtBghOUkdjtLBsqBMEReKvFRGB gzGgtBghOUkdjtLBsqBMEReKvFRGB2;
				if (NvCbGuKSGsCeqFOaiaRJdXaBqADyC == -2 && kQbxoVrJTaHFzyeHhQJVrNIhGlgcA == Environment.CurrentManagedThreadId)
				{
					NvCbGuKSGsCeqFOaiaRJdXaBqADyC = 0;
					gzGgtBghOUkdjtLBsqBMEReKvFRGB2 = this;
				}
				else
				{
					gzGgtBghOUkdjtLBsqBMEReKvFRGB2 = new gzGgtBghOUkdjtLBsqBMEReKvFRGB(0);
					gzGgtBghOUkdjtLBsqBMEReKvFRGB2.xFMIRwivsngnKZQkyFayFlnHtalnb = xFMIRwivsngnKZQkyFayFlnHtalnb;
				}
				gzGgtBghOUkdjtLBsqBMEReKvFRGB2.XCaeGOEKzTHBxzcfPVLtmgffXktO = eWZbCvGeCEOvTeZvrecKUnbYKNClA;
				gzGgtBghOUkdjtLBsqBMEReKvFRGB2.azmHFTHXCEINFoIXRchtaBwEfFQIA = yMKbopeKPPHEDphFxGYgvOLJPvUuA;
				return gzGgtBghOUkdjtLBsqBMEReKvFRGB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class VfsnYAgTBJEMgteJXbZrUuWAkOsK : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ooAqmoPHlkzqqWWDOgtgBLdHInPgA;

			private ElementAssignmentConflictInfo iSqtJLDticmiEaFXIQgewyDXTCAL;

			private int suDKmSTtZMueodqzesmQmIiHRdsF;

			public ControllerMap sOSmbzcMWqbCIbxKOsGSkNevLZkZA;

			private ControllerMap RfRBdEYhaUhANFcvplfXkVUjQhGO;

			public ControllerMap rmBlHCKXTVstGugkJcYrFUcfTuaPA;

			private bool lSZcreadWAnVAkHxwjlFDgAitQGQb;

			public bool eIdychNVkMSVtFwAKPcxRorXkhZt;

			private IList<ActionElementMap> lnYFgcUgharTZukFLbIdQbJwYHuK;

			private int AlGAGgVvZhTAkBrLqsXNWIGpwtrS;

			private int kqLifvAfhIOQXheHBFBbDCvPwxKf;

			private ActionElementMap sRUXEcIcGLfAWeDkhKSPLxnxYmbGA;

			private int hiYGaVenPhjKfzhfoYtItXFJryph;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return iSqtJLDticmiEaFXIQgewyDXTCAL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return iSqtJLDticmiEaFXIQgewyDXTCAL;
				}
			}

			[DebuggerHidden]
			public VfsnYAgTBJEMgteJXbZrUuWAkOsK(int P_0)
			{
				ooAqmoPHlkzqqWWDOgtgBLdHInPgA = P_0;
				suDKmSTtZMueodqzesmQmIiHRdsF = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ooAqmoPHlkzqqWWDOgtgBLdHInPgA;
				ControllerMap controllerMap = sOSmbzcMWqbCIbxKOsGSkNevLZkZA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					ooAqmoPHlkzqqWWDOgtgBLdHInPgA = -1;
					goto IL_019c;
				}
				ooAqmoPHlkzqqWWDOgtgBLdHInPgA = -1;
				if (ReInput._id != controllerMap.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(controllerMap.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return false;
				}
				if (RfRBdEYhaUhANFcvplfXkVUjQhGO == null || controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV == null)
				{
					return false;
				}
				if (lSZcreadWAnVAkHxwjlFDgAitQGQb && (!controllerMap._enabled || !RfRBdEYhaUhANFcvplfXkVUjQhGO._enabled))
				{
					return false;
				}
				lnYFgcUgharTZukFLbIdQbJwYHuK = RfRBdEYhaUhANFcvplfXkVUjQhGO.ButtonMaps;
				if (lnYFgcUgharTZukFLbIdQbJwYHuK == null)
				{
					return false;
				}
				AlGAGgVvZhTAkBrLqsXNWIGpwtrS = lnYFgcUgharTZukFLbIdQbJwYHuK.Count;
				kqLifvAfhIOQXheHBFBbDCvPwxKf = 0;
				goto IL_01d4;
				IL_01d4:
				if (kqLifvAfhIOQXheHBFBbDCvPwxKf < controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV.Count)
				{
					sRUXEcIcGLfAWeDkhKSPLxnxYmbGA = controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV[kqLifvAfhIOQXheHBFBbDCvPwxKf];
					if (!lSZcreadWAnVAkHxwjlFDgAitQGQb || sRUXEcIcGLfAWeDkhKSPLxnxYmbGA.vWZNVuVXYnOfJimlqfUderrRDbRk)
					{
						hiYGaVenPhjKfzhfoYtItXFJryph = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (hiYGaVenPhjKfzhfoYtItXFJryph < AlGAGgVvZhTAkBrLqsXNWIGpwtrS)
				{
					ActionElementMap actionElementMap = lnYFgcUgharTZukFLbIdQbJwYHuK[hiYGaVenPhjKfzhfoYtItXFJryph];
					if ((!lSZcreadWAnVAkHxwjlFDgAitQGQb || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && sRUXEcIcGLfAWeDkhKSPLxnxYmbGA.CheckForAssignmentConflict(actionElementMap))
					{
						iSqtJLDticmiEaFXIQgewyDXTCAL = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, sRUXEcIcGLfAWeDkhKSPLxnxYmbGA.kzHrLfsGRteEloHDejoDrezLTRte, sRUXEcIcGLfAWeDkhKSPLxnxYmbGA._actionId, sRUXEcIcGLfAWeDkhKSPLxnxYmbGA._elementType, sRUXEcIcGLfAWeDkhKSPLxnxYmbGA._elementIdentifierId, sRUXEcIcGLfAWeDkhKSPLxnxYmbGA.keyCode, sRUXEcIcGLfAWeDkhKSPLxnxYmbGA.modifierKeyFlags);
						ooAqmoPHlkzqqWWDOgtgBLdHInPgA = 1;
						return true;
					}
					goto IL_019c;
				}
				sRUXEcIcGLfAWeDkhKSPLxnxYmbGA = null;
				goto IL_01c4;
				IL_01c4:
				kqLifvAfhIOQXheHBFBbDCvPwxKf++;
				goto IL_01d4;
				IL_019c:
				hiYGaVenPhjKfzhfoYtItXFJryph++;
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
				VfsnYAgTBJEMgteJXbZrUuWAkOsK vfsnYAgTBJEMgteJXbZrUuWAkOsK;
				if (ooAqmoPHlkzqqWWDOgtgBLdHInPgA == -2 && suDKmSTtZMueodqzesmQmIiHRdsF == Environment.CurrentManagedThreadId)
				{
					ooAqmoPHlkzqqWWDOgtgBLdHInPgA = 0;
					vfsnYAgTBJEMgteJXbZrUuWAkOsK = this;
				}
				else
				{
					vfsnYAgTBJEMgteJXbZrUuWAkOsK = new VfsnYAgTBJEMgteJXbZrUuWAkOsK(0);
					vfsnYAgTBJEMgteJXbZrUuWAkOsK.sOSmbzcMWqbCIbxKOsGSkNevLZkZA = sOSmbzcMWqbCIbxKOsGSkNevLZkZA;
				}
				vfsnYAgTBJEMgteJXbZrUuWAkOsK.RfRBdEYhaUhANFcvplfXkVUjQhGO = rmBlHCKXTVstGugkJcYrFUcfTuaPA;
				vfsnYAgTBJEMgteJXbZrUuWAkOsK.lSZcreadWAnVAkHxwjlFDgAitQGQb = eIdychNVkMSVtFwAKPcxRorXkhZt;
				return vfsnYAgTBJEMgteJXbZrUuWAkOsK;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class ZIkwTnfDpCaYuCWMEYCNmEWKnTIl : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int vRoXeURabDpejWizpSqZFvOwvpGp;

			private ElementAssignmentConflictInfo UJDpIzruIvoZVLiRDMZnjxmzqcBl;

			private int IHEDEaBxQojBdYQRzenpOtXaABkI;

			public ControllerMap gevtwwATLZpvmZlrwGqUlRkYQvAS;

			private ActionElementMap jYmDmCFzMMIFibMnnLcfFHvdhdIm;

			public ActionElementMap jUoCzDqwqozXhJkTcIvvKJLTutUP;

			private bool uuLzjpdtELkBnJfzfgkIDVWblNhHb;

			public bool sTwyHVEWJGxmFORVvlsrKILkGNkhA;

			private int MbNfcyzAQWrnAxvBmdDshRNOgzfu;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return UJDpIzruIvoZVLiRDMZnjxmzqcBl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UJDpIzruIvoZVLiRDMZnjxmzqcBl;
				}
			}

			[DebuggerHidden]
			public ZIkwTnfDpCaYuCWMEYCNmEWKnTIl(int P_0)
			{
				vRoXeURabDpejWizpSqZFvOwvpGp = P_0;
				IHEDEaBxQojBdYQRzenpOtXaABkI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = vRoXeURabDpejWizpSqZFvOwvpGp;
				ControllerMap controllerMap = gevtwwATLZpvmZlrwGqUlRkYQvAS;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					vRoXeURabDpejWizpSqZFvOwvpGp = -1;
					goto IL_0111;
				}
				vRoXeURabDpejWizpSqZFvOwvpGp = -1;
				if (ReInput._id != controllerMap.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(controllerMap.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return false;
				}
				if (jYmDmCFzMMIFibMnnLcfFHvdhdIm == null || controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV == null)
				{
					return false;
				}
				if (uuLzjpdtELkBnJfzfgkIDVWblNhHb && (!controllerMap._enabled || !jYmDmCFzMMIFibMnnLcfFHvdhdIm.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					return false;
				}
				MbNfcyzAQWrnAxvBmdDshRNOgzfu = 0;
				goto IL_0121;
				IL_0111:
				MbNfcyzAQWrnAxvBmdDshRNOgzfu++;
				goto IL_0121;
				IL_0121:
				if (MbNfcyzAQWrnAxvBmdDshRNOgzfu < controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV.Count)
				{
					ActionElementMap actionElementMap = controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV[MbNfcyzAQWrnAxvBmdDshRNOgzfu];
					if ((!uuLzjpdtELkBnJfzfgkIDVWblNhHb || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(jYmDmCFzMMIFibMnnLcfFHvdhdIm))
					{
						UJDpIzruIvoZVLiRDMZnjxmzqcBl = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						vRoXeURabDpejWizpSqZFvOwvpGp = 1;
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
				ZIkwTnfDpCaYuCWMEYCNmEWKnTIl zIkwTnfDpCaYuCWMEYCNmEWKnTIl;
				if (vRoXeURabDpejWizpSqZFvOwvpGp == -2 && IHEDEaBxQojBdYQRzenpOtXaABkI == Environment.CurrentManagedThreadId)
				{
					vRoXeURabDpejWizpSqZFvOwvpGp = 0;
					zIkwTnfDpCaYuCWMEYCNmEWKnTIl = this;
				}
				else
				{
					zIkwTnfDpCaYuCWMEYCNmEWKnTIl = new ZIkwTnfDpCaYuCWMEYCNmEWKnTIl(0);
					zIkwTnfDpCaYuCWMEYCNmEWKnTIl.gevtwwATLZpvmZlrwGqUlRkYQvAS = gevtwwATLZpvmZlrwGqUlRkYQvAS;
				}
				zIkwTnfDpCaYuCWMEYCNmEWKnTIl.jYmDmCFzMMIFibMnnLcfFHvdhdIm = jUoCzDqwqozXhJkTcIvvKJLTutUP;
				zIkwTnfDpCaYuCWMEYCNmEWKnTIl.uuLzjpdtELkBnJfzfgkIDVWblNhHb = sTwyHVEWJGxmFORVvlsrKILkGNkhA;
				return zIkwTnfDpCaYuCWMEYCNmEWKnTIl;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class PcgTMlfEPFBlJQfXpbJRDDcvjloOA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int LmygKDtkVGdFjqHXlaCbiwAeFxWuA;

			private ElementAssignmentConflictInfo xgUXBrIwyZpgEWGKxMQuwgtYUqhr;

			private int uoJRnBjHUZIAEYWLhhjZiMHRAMcu;

			public ControllerMap HiNlVkswHuPArKXDQOYxIvLDMhrp;

			private bool OTkyzWhWrAeSLCjzzMKXnOuncfai;

			public bool wbShwUhVGoDspYbjKOcIDuhFeaFNb;

			private ElementAssignmentConflictCheck BHVUnzjSKdLKYqsYuwUNqcwpCPXs;

			public ElementAssignmentConflictCheck NSQxCUUdaRPMwFkCURyjuvmdtOfi;

			private ElementAssignment SbFVVHptUHrCeOLXQvcNYkvrbYOg;

			private int zWOOGWYCUBIGAQBXCMYZAaBkyxzO;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return xgUXBrIwyZpgEWGKxMQuwgtYUqhr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return xgUXBrIwyZpgEWGKxMQuwgtYUqhr;
				}
			}

			[DebuggerHidden]
			public PcgTMlfEPFBlJQfXpbJRDDcvjloOA(int P_0)
			{
				LmygKDtkVGdFjqHXlaCbiwAeFxWuA = P_0;
				uoJRnBjHUZIAEYWLhhjZiMHRAMcu = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int lmygKDtkVGdFjqHXlaCbiwAeFxWuA = LmygKDtkVGdFjqHXlaCbiwAeFxWuA;
				ControllerMap hiNlVkswHuPArKXDQOYxIvLDMhrp = HiNlVkswHuPArKXDQOYxIvLDMhrp;
				if (lmygKDtkVGdFjqHXlaCbiwAeFxWuA != 0)
				{
					if (lmygKDtkVGdFjqHXlaCbiwAeFxWuA != 1)
					{
						return false;
					}
					LmygKDtkVGdFjqHXlaCbiwAeFxWuA = -1;
					goto IL_0123;
				}
				LmygKDtkVGdFjqHXlaCbiwAeFxWuA = -1;
				if (ReInput._id != hiNlVkswHuPArKXDQOYxIvLDMhrp.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(hiNlVkswHuPArKXDQOYxIvLDMhrp.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return false;
				}
				if (OTkyzWhWrAeSLCjzzMKXnOuncfai && !hiNlVkswHuPArKXDQOYxIvLDMhrp._enabled)
				{
					return false;
				}
				if (hiNlVkswHuPArKXDQOYxIvLDMhrp.WsKzJXCxukeCLrQgapetdQPaWPWV == null)
				{
					return false;
				}
				SbFVVHptUHrCeOLXQvcNYkvrbYOg = BHVUnzjSKdLKYqsYuwUNqcwpCPXs.ToElementAssignment();
				zWOOGWYCUBIGAQBXCMYZAaBkyxzO = 0;
				goto IL_0133;
				IL_0133:
				if (zWOOGWYCUBIGAQBXCMYZAaBkyxzO < hiNlVkswHuPArKXDQOYxIvLDMhrp.WsKzJXCxukeCLrQgapetdQPaWPWV.Count)
				{
					ActionElementMap actionElementMap = hiNlVkswHuPArKXDQOYxIvLDMhrp.WsKzJXCxukeCLrQgapetdQPaWPWV[zWOOGWYCUBIGAQBXCMYZAaBkyxzO];
					if ((!OTkyzWhWrAeSLCjzzMKXnOuncfai || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != BHVUnzjSKdLKYqsYuwUNqcwpCPXs.elementMapId && actionElementMap.CheckForAssignmentConflict(SbFVVHptUHrCeOLXQvcNYkvrbYOg))
					{
						xgUXBrIwyZpgEWGKxMQuwgtYUqhr = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(hiNlVkswHuPArKXDQOYxIvLDMhrp._categoryId).userAssignable, -1, hiNlVkswHuPArKXDQOYxIvLDMhrp._controllerType, hiNlVkswHuPArKXDQOYxIvLDMhrp._controllerId, hiNlVkswHuPArKXDQOYxIvLDMhrp._id, actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						LmygKDtkVGdFjqHXlaCbiwAeFxWuA = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				zWOOGWYCUBIGAQBXCMYZAaBkyxzO++;
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
				PcgTMlfEPFBlJQfXpbJRDDcvjloOA pcgTMlfEPFBlJQfXpbJRDDcvjloOA;
				if (LmygKDtkVGdFjqHXlaCbiwAeFxWuA == -2 && uoJRnBjHUZIAEYWLhhjZiMHRAMcu == Environment.CurrentManagedThreadId)
				{
					LmygKDtkVGdFjqHXlaCbiwAeFxWuA = 0;
					pcgTMlfEPFBlJQfXpbJRDDcvjloOA = this;
				}
				else
				{
					pcgTMlfEPFBlJQfXpbJRDDcvjloOA = new PcgTMlfEPFBlJQfXpbJRDDcvjloOA(0);
					pcgTMlfEPFBlJQfXpbJRDDcvjloOA.HiNlVkswHuPArKXDQOYxIvLDMhrp = HiNlVkswHuPArKXDQOYxIvLDMhrp;
				}
				pcgTMlfEPFBlJQfXpbJRDDcvjloOA.BHVUnzjSKdLKYqsYuwUNqcwpCPXs = NSQxCUUdaRPMwFkCURyjuvmdtOfi;
				pcgTMlfEPFBlJQfXpbJRDDcvjloOA.OTkyzWhWrAeSLCjzzMKXnOuncfai = wbShwUhVGoDspYbjKOcIDuhFeaFNb;
				return pcgTMlfEPFBlJQfXpbJRDDcvjloOA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class rLtcgFGcgqUCJBpvGrpllVmtxMwJ : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int YkffwuJXZJutnoMOmJrBBvPfqsqs;

			private ActionElementMap KyQMnfOpaALEmsjyjutdVUrzISVb;

			private int VreBAVqtSlMjuuDlwVSrMdSkDHdHA;

			public ControllerMap BGLmBIPmXZQSzMofzitJiBMJUtHp;

			private int hAbkFaDwUWrvQJKZXGodUHKLaMljA;

			public int ZkjiFajvhdEHhVAThDZyBxGbpenC;

			private bool sIxeeUGbfxAuBWWtKoXjHfmYClRcA;

			public bool fwTObpRAYCoxbZZAkJNVROiaEQGeA;

			private IEnumerator<ActionElementMap> YQVkKNaovsSJDhDNPYGTcLXnueHG;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return KyQMnfOpaALEmsjyjutdVUrzISVb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KyQMnfOpaALEmsjyjutdVUrzISVb;
				}
			}

			[DebuggerHidden]
			public rLtcgFGcgqUCJBpvGrpllVmtxMwJ(int P_0)
			{
				YkffwuJXZJutnoMOmJrBBvPfqsqs = P_0;
				VreBAVqtSlMjuuDlwVSrMdSkDHdHA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int ykffwuJXZJutnoMOmJrBBvPfqsqs = YkffwuJXZJutnoMOmJrBBvPfqsqs;
				if (ykffwuJXZJutnoMOmJrBBvPfqsqs == -3 || ykffwuJXZJutnoMOmJrBBvPfqsqs == 1)
				{
					try
					{
					}
					finally
					{
						zWQCvfgUfbbYcspsLYHfjtXixgDt();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int ykffwuJXZJutnoMOmJrBBvPfqsqs = YkffwuJXZJutnoMOmJrBBvPfqsqs;
					ControllerMap bGLmBIPmXZQSzMofzitJiBMJUtHp = BGLmBIPmXZQSzMofzitJiBMJUtHp;
					switch (ykffwuJXZJutnoMOmJrBBvPfqsqs)
					{
					default:
						return false;
					case 0:
						YkffwuJXZJutnoMOmJrBBvPfqsqs = -1;
						if (ReInput._id != bGLmBIPmXZQSzMofzitJiBMJUtHp.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(bGLmBIPmXZQSzMofzitJiBMJUtHp.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						YQVkKNaovsSJDhDNPYGTcLXnueHG = bGLmBIPmXZQSzMofzitJiBMJUtHp.AllMaps.GetEnumerator();
						YkffwuJXZJutnoMOmJrBBvPfqsqs = -3;
						break;
					case 1:
						YkffwuJXZJutnoMOmJrBBvPfqsqs = -3;
						break;
					}
					while (YQVkKNaovsSJDhDNPYGTcLXnueHG.MoveNext())
					{
						ActionElementMap current = YQVkKNaovsSJDhDNPYGTcLXnueHG.Current;
						if (current._actionId == hAbkFaDwUWrvQJKZXGodUHKLaMljA && (!sIxeeUGbfxAuBWWtKoXjHfmYClRcA || current.vWZNVuVXYnOfJimlqfUderrRDbRk))
						{
							KyQMnfOpaALEmsjyjutdVUrzISVb = current;
							YkffwuJXZJutnoMOmJrBBvPfqsqs = 1;
							return true;
						}
					}
					zWQCvfgUfbbYcspsLYHfjtXixgDt();
					YQVkKNaovsSJDhDNPYGTcLXnueHG = null;
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

			private void zWQCvfgUfbbYcspsLYHfjtXixgDt()
			{
				YkffwuJXZJutnoMOmJrBBvPfqsqs = -1;
				if (YQVkKNaovsSJDhDNPYGTcLXnueHG != null)
				{
					YQVkKNaovsSJDhDNPYGTcLXnueHG.Dispose();
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
				rLtcgFGcgqUCJBpvGrpllVmtxMwJ rLtcgFGcgqUCJBpvGrpllVmtxMwJ2;
				if (YkffwuJXZJutnoMOmJrBBvPfqsqs == -2 && VreBAVqtSlMjuuDlwVSrMdSkDHdHA == Environment.CurrentManagedThreadId)
				{
					YkffwuJXZJutnoMOmJrBBvPfqsqs = 0;
					rLtcgFGcgqUCJBpvGrpllVmtxMwJ2 = this;
				}
				else
				{
					rLtcgFGcgqUCJBpvGrpllVmtxMwJ2 = new rLtcgFGcgqUCJBpvGrpllVmtxMwJ(0);
					rLtcgFGcgqUCJBpvGrpllVmtxMwJ2.BGLmBIPmXZQSzMofzitJiBMJUtHp = BGLmBIPmXZQSzMofzitJiBMJUtHp;
				}
				rLtcgFGcgqUCJBpvGrpllVmtxMwJ2.hAbkFaDwUWrvQJKZXGodUHKLaMljA = ZkjiFajvhdEHhVAThDZyBxGbpenC;
				rLtcgFGcgqUCJBpvGrpllVmtxMwJ2.sIxeeUGbfxAuBWWtKoXjHfmYClRcA = fwTObpRAYCoxbZZAkJNVROiaEQGeA;
				return rLtcgFGcgqUCJBpvGrpllVmtxMwJ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class iGjfdzRbWgdzKNAaePjWvJmSgERk : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int awYkuTpCJtlsIrcIJFMPjRtXGwtj;

			private ActionElementMap wbsbyihlJZppdcduteQILSbeYGIW;

			private int alWgngagyhKDXHQHNDuWQcMPjaOlA;

			public ControllerMap MpsJlFysgpdjqiacVoNNigZhnJUMA;

			private IControllerElementTarget xxxwSepPYXjGNQhemckDoeeglUHW;

			public IControllerElementTarget ZBdjtTFZSauFozWpLAOGUkRPFstEA;

			private bool lIzmNmjLyTiKiJFvYbpJdlPPbAzU;

			public bool zBUpFhwlJpiiBSoSfXzgwMtLMBrj;

			private TempListPool.TList<ActionElementMap> vUcePRjcxaBgzdbPbcSScPwbDKaYc;

			private List<ActionElementMap>.Enumerator TSpTjFlUnmqIfJWRhJnZnIXgLVvT;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return wbsbyihlJZppdcduteQILSbeYGIW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wbsbyihlJZppdcduteQILSbeYGIW;
				}
			}

			[DebuggerHidden]
			public iGjfdzRbWgdzKNAaePjWvJmSgERk(int P_0)
			{
				awYkuTpCJtlsIrcIJFMPjRtXGwtj = P_0;
				alWgngagyhKDXHQHNDuWQcMPjaOlA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = awYkuTpCJtlsIrcIJFMPjRtXGwtj;
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
						VaavFYenTqhIxiPuSlERkYCPNSFC();
					}
				}
				finally
				{
					ydgEYcxBgvSNjXVCzOhcjBxkgfRZ();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = awYkuTpCJtlsIrcIJFMPjRtXGwtj;
					ControllerMap mpsJlFysgpdjqiacVoNNigZhnJUMA = MpsJlFysgpdjqiacVoNNigZhnJUMA;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						awYkuTpCJtlsIrcIJFMPjRtXGwtj = -1;
						if (ReInput._id != mpsJlFysgpdjqiacVoNNigZhnJUMA.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(mpsJlFysgpdjqiacVoNNigZhnJUMA.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						vUcePRjcxaBgzdbPbcSScPwbDKaYc = TempListPool.GetTList<ActionElementMap>();
						awYkuTpCJtlsIrcIJFMPjRtXGwtj = -3;
						List<ActionElementMap> list = vUcePRjcxaBgzdbPbcSScPwbDKaYc.list;
						mpsJlFysgpdjqiacVoNNigZhnJUMA.biNGvbASEzcfdrNskXzGrsWeiLTVA(xxxwSepPYXjGNQhemckDoeeglUHW, false, -1, lIzmNmjLyTiKiJFvYbpJdlPPbAzU, list, false, out var _);
						TSpTjFlUnmqIfJWRhJnZnIXgLVvT = list.GetEnumerator();
						awYkuTpCJtlsIrcIJFMPjRtXGwtj = -4;
						break;
					}
					case 1:
						awYkuTpCJtlsIrcIJFMPjRtXGwtj = -4;
						break;
					}
					if (TSpTjFlUnmqIfJWRhJnZnIXgLVvT.MoveNext())
					{
						ActionElementMap current = TSpTjFlUnmqIfJWRhJnZnIXgLVvT.Current;
						wbsbyihlJZppdcduteQILSbeYGIW = current;
						awYkuTpCJtlsIrcIJFMPjRtXGwtj = 1;
						return true;
					}
					VaavFYenTqhIxiPuSlERkYCPNSFC();
					TSpTjFlUnmqIfJWRhJnZnIXgLVvT = default(List<ActionElementMap>.Enumerator);
					ydgEYcxBgvSNjXVCzOhcjBxkgfRZ();
					vUcePRjcxaBgzdbPbcSScPwbDKaYc = null;
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

			private void ydgEYcxBgvSNjXVCzOhcjBxkgfRZ()
			{
				awYkuTpCJtlsIrcIJFMPjRtXGwtj = -1;
				if (vUcePRjcxaBgzdbPbcSScPwbDKaYc != null)
				{
					((IDisposable)vUcePRjcxaBgzdbPbcSScPwbDKaYc).Dispose();
				}
			}

			private void VaavFYenTqhIxiPuSlERkYCPNSFC()
			{
				awYkuTpCJtlsIrcIJFMPjRtXGwtj = -3;
				((IDisposable)TSpTjFlUnmqIfJWRhJnZnIXgLVvT/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				iGjfdzRbWgdzKNAaePjWvJmSgERk iGjfdzRbWgdzKNAaePjWvJmSgERk2;
				if (awYkuTpCJtlsIrcIJFMPjRtXGwtj == -2 && alWgngagyhKDXHQHNDuWQcMPjaOlA == Environment.CurrentManagedThreadId)
				{
					awYkuTpCJtlsIrcIJFMPjRtXGwtj = 0;
					iGjfdzRbWgdzKNAaePjWvJmSgERk2 = this;
				}
				else
				{
					iGjfdzRbWgdzKNAaePjWvJmSgERk2 = new iGjfdzRbWgdzKNAaePjWvJmSgERk(0);
					iGjfdzRbWgdzKNAaePjWvJmSgERk2.MpsJlFysgpdjqiacVoNNigZhnJUMA = MpsJlFysgpdjqiacVoNNigZhnJUMA;
				}
				iGjfdzRbWgdzKNAaePjWvJmSgERk2.xxxwSepPYXjGNQhemckDoeeglUHW = ZBdjtTFZSauFozWpLAOGUkRPFstEA;
				iGjfdzRbWgdzKNAaePjWvJmSgERk2.lIzmNmjLyTiKiJFvYbpJdlPPbAzU = zBUpFhwlJpiiBSoSfXzgwMtLMBrj;
				return iGjfdzRbWgdzKNAaePjWvJmSgERk2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class SABCKeBlYxVFzodNPHHOXvOsieNy : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int qOcdMegQUFdSFpYBOBaiyWJxvakC;

			private ActionElementMap mWrNlneegdPTKUhvZIKpONRcjWtU;

			private int dSrcaIvCxLbCqOTNdYHmkxqiLqS;

			public ControllerMap WMgTovOsvTatbXQPuYGTpslbCtPA;

			private IControllerElementTarget FWiuUudGNgEBYrtZbTaAMwXTLWzF;

			public IControllerElementTarget MinTTuboQXkZWKnQGqRepHQtZgkb;

			private int myBHYICmtcGshGvBPnlSZEGIkZTP;

			public int TSyPYniXioSsgCaqBBTaCSSeBYDAA;

			private bool HbhWBARsSZGoGXVpRXMvrweLdhEk;

			public bool ATJIAfdQBFeewcPrEloBFioQGXtY;

			private TempListPool.TList<ActionElementMap> QTXAUsxpYFEuRMpCkROLcHVHFXWD;

			private List<ActionElementMap>.Enumerator GmFXxylgLhcWVvAfafQLQvSDhbPgA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return mWrNlneegdPTKUhvZIKpONRcjWtU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return mWrNlneegdPTKUhvZIKpONRcjWtU;
				}
			}

			[DebuggerHidden]
			public SABCKeBlYxVFzodNPHHOXvOsieNy(int P_0)
			{
				qOcdMegQUFdSFpYBOBaiyWJxvakC = P_0;
				dSrcaIvCxLbCqOTNdYHmkxqiLqS = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = qOcdMegQUFdSFpYBOBaiyWJxvakC;
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
						WcnihYkhtWhkIcBeJgeHLSHogBtLA();
					}
				}
				finally
				{
					lnPuNpCXJSoVoiGFPEZScgwkkHtY();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = qOcdMegQUFdSFpYBOBaiyWJxvakC;
					ControllerMap wMgTovOsvTatbXQPuYGTpslbCtPA = WMgTovOsvTatbXQPuYGTpslbCtPA;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						qOcdMegQUFdSFpYBOBaiyWJxvakC = -1;
						if (ReInput._id != wMgTovOsvTatbXQPuYGTpslbCtPA.ocpJEhDKZGwjCNHUhUPdlzibnEKu)
						{
							ReInput.CheckInitialized(wMgTovOsvTatbXQPuYGTpslbCtPA.ocpJEhDKZGwjCNHUhUPdlzibnEKu);
							return false;
						}
						QTXAUsxpYFEuRMpCkROLcHVHFXWD = TempListPool.GetTList<ActionElementMap>();
						qOcdMegQUFdSFpYBOBaiyWJxvakC = -3;
						List<ActionElementMap> list = QTXAUsxpYFEuRMpCkROLcHVHFXWD.list;
						wMgTovOsvTatbXQPuYGTpslbCtPA.biNGvbASEzcfdrNskXzGrsWeiLTVA(FWiuUudGNgEBYrtZbTaAMwXTLWzF, true, myBHYICmtcGshGvBPnlSZEGIkZTP, HbhWBARsSZGoGXVpRXMvrweLdhEk, list, false, out var _);
						GmFXxylgLhcWVvAfafQLQvSDhbPgA = list.GetEnumerator();
						qOcdMegQUFdSFpYBOBaiyWJxvakC = -4;
						break;
					}
					case 1:
						qOcdMegQUFdSFpYBOBaiyWJxvakC = -4;
						break;
					}
					if (GmFXxylgLhcWVvAfafQLQvSDhbPgA.MoveNext())
					{
						ActionElementMap current = GmFXxylgLhcWVvAfafQLQvSDhbPgA.Current;
						mWrNlneegdPTKUhvZIKpONRcjWtU = current;
						qOcdMegQUFdSFpYBOBaiyWJxvakC = 1;
						return true;
					}
					WcnihYkhtWhkIcBeJgeHLSHogBtLA();
					GmFXxylgLhcWVvAfafQLQvSDhbPgA = default(List<ActionElementMap>.Enumerator);
					lnPuNpCXJSoVoiGFPEZScgwkkHtY();
					QTXAUsxpYFEuRMpCkROLcHVHFXWD = null;
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

			private void lnPuNpCXJSoVoiGFPEZScgwkkHtY()
			{
				qOcdMegQUFdSFpYBOBaiyWJxvakC = -1;
				if (QTXAUsxpYFEuRMpCkROLcHVHFXWD != null)
				{
					((IDisposable)QTXAUsxpYFEuRMpCkROLcHVHFXWD).Dispose();
				}
			}

			private void WcnihYkhtWhkIcBeJgeHLSHogBtLA()
			{
				qOcdMegQUFdSFpYBOBaiyWJxvakC = -3;
				((IDisposable)GmFXxylgLhcWVvAfafQLQvSDhbPgA/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				SABCKeBlYxVFzodNPHHOXvOsieNy sABCKeBlYxVFzodNPHHOXvOsieNy;
				if (qOcdMegQUFdSFpYBOBaiyWJxvakC == -2 && dSrcaIvCxLbCqOTNdYHmkxqiLqS == Environment.CurrentManagedThreadId)
				{
					qOcdMegQUFdSFpYBOBaiyWJxvakC = 0;
					sABCKeBlYxVFzodNPHHOXvOsieNy = this;
				}
				else
				{
					sABCKeBlYxVFzodNPHHOXvOsieNy = new SABCKeBlYxVFzodNPHHOXvOsieNy(0);
					sABCKeBlYxVFzodNPHHOXvOsieNy.WMgTovOsvTatbXQPuYGTpslbCtPA = WMgTovOsvTatbXQPuYGTpslbCtPA;
				}
				sABCKeBlYxVFzodNPHHOXvOsieNy.FWiuUudGNgEBYrtZbTaAMwXTLWzF = MinTTuboQXkZWKnQGqRepHQtZgkb;
				sABCKeBlYxVFzodNPHHOXvOsieNy.myBHYICmtcGshGvBPnlSZEGIkZTP = TSyPYniXioSsgCaqBBTaCSSeBYDAA;
				sABCKeBlYxVFzodNPHHOXvOsieNy.HbhWBARsSZGoGXVpRXMvrweLdhEk = ATJIAfdQBFeewcPrEloBFioQGXtY;
				return sABCKeBlYxVFzodNPHHOXvOsieNy;
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

		internal readonly int ocpJEhDKZGwjCNHUhUPdlzibnEKu;

		private readonly AList<ActionElementMap> WsKzJXCxukeCLrQgapetdQPaWPWV;

		private readonly ReadOnlyCollection<ActionElementMap> JfpHWQMTKqKBFHnvTNctdLxIMiqV;

		private readonly AList<ActionElementMap> jJhoZVefAveFVkkDaZBWfClVEGfdA;

		private readonly ReadOnlyCollection<ActionElementMap> gHZFLhxsDyyqiPeWXgUXhRuYjHMFA;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int IHDbbvXjJNWMDcHTYcJAKmnWPMGf;

		private static int NlOgwBgZenmqgNosoiSHNXfSYjHU
		{
			get
			{
				int iHDbbvXjJNWMDcHTYcJAKmnWPMGf = IHDbbvXjJNWMDcHTYcJAKmnWPMGf;
				if (IHDbbvXjJNWMDcHTYcJAKmnWPMGf == int.MaxValue)
				{
					IHDbbvXjJNWMDcHTYcJAKmnWPMGf = 0;
					return iHDbbvXjJNWMDcHTYcJAKmnWPMGf;
				}
				IHDbbvXjJNWMDcHTYcJAKmnWPMGf++;
				return iHDbbvXjJNWMDcHTYcJAKmnWPMGf;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return 0;
				}
				return jJhoZVefAveFVkkDaZBWfClVEGfdA.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return 0;
				}
				return WsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return gHZFLhxsDyyqiPeWXgUXhRuYjHMFA;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return gHZFLhxsDyyqiPeWXgUXhRuYjHMFA;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
				{
					ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return JfpHWQMTKqKBFHnvTNctdLxIMiqV;
			}
		}

		internal AList<ActionElementMap> WlfiRVollhePcNcyfbYblQBgHIiM => WsKzJXCxukeCLrQgapetdQPaWPWV;

		public ControllerMap()
		{
			_id = NlOgwBgZenmqgNosoiSHNXfSYjHU;
			_sourceMapId = -1;
			WsKzJXCxukeCLrQgapetdQPaWPWV = new AList<ActionElementMap>();
			JfpHWQMTKqKBFHnvTNctdLxIMiqV = new ReadOnlyCollection<ActionElementMap>(WsKzJXCxukeCLrQgapetdQPaWPWV);
			jJhoZVefAveFVkkDaZBWfClVEGfdA = new AList<ActionElementMap>();
			gHZFLhxsDyyqiPeWXgUXhRuYjHMFA = new ReadOnlyCollection<ActionElementMap>(jJhoZVefAveFVkkDaZBWfClVEGfdA);
			ocpJEhDKZGwjCNHUhUPdlzibnEKu = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = NlOgwBgZenmqgNosoiSHNXfSYjHU;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			if (P_0.WsKzJXCxukeCLrQgapetdQPaWPWV != null)
			{
				int count = P_0.WsKzJXCxukeCLrQgapetdQPaWPWV.Count;
				for (int i = 0; i < count; i++)
				{
					KgYSnWEDTvJkAImFFHLvdYemGAWTA(new ActionElementMap(P_0.WsKzJXCxukeCLrQgapetdQPaWPWV[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			AList<ActionElementMap> aList = jJhoZVefAveFVkkDaZBWfClVEGfdA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (jJhoZVefAveFVkkDaZBWfClVEGfdA[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			AList<ActionElementMap> aList = jJhoZVefAveFVkkDaZBWfClVEGfdA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (jJhoZVefAveFVkkDaZBWfClVEGfdA[i].keyCode == keyCode && jJhoZVefAveFVkkDaZBWfClVEGfdA[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = jJhoZVefAveFVkkDaZBWfClVEGfdA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (jJhoZVefAveFVkkDaZBWfClVEGfdA[i].kzHrLfsGRteEloHDejoDrezLTRte == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			AList<ActionElementMap> aList = jJhoZVefAveFVkkDaZBWfClVEGfdA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (jJhoZVefAveFVkkDaZBWfClVEGfdA[i].kzHrLfsGRteEloHDejoDrezLTRte == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, tqmHLUqTfYnnflPJaWxRPIPYjlrx.puzVnKjbWWaKIdOxIXdDkfWaAHYeA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.KQvZlmyPDCAbJMosZEJiaypfudNPA(this, actionElementMap);
			KgYSnWEDTvJkAImFFHLvdYemGAWTA(actionElementMap);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			JtYFKZPBhTNfUhaTQWIccnmyitDHA jtYFKZPBhTNfUhaTQWIccnmyitDHA = JtYFKZPBhTNfUhaTQWIccnmyitDHA.AANRuYPSSUukSiXkYtVRWtokGEcI(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, jtYFKZPBhTNfUhaTQWIccnmyitDHA.ITLnhbeZiAHQuDkXRitGAbtkVAWO, jtYFKZPBhTNfUhaTQWIccnmyitDHA.fmyPeGMdaEiIDJhhbYicQWLapWWIA, jtYFKZPBhTNfUhaTQWIccnmyitDHA.SOpykEFkiaGQFjSMIiCSrYCMmWvqA, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			KgYSnWEDTvJkAImFFHLvdYemGAWTA(actionElementMap);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, tqmHLUqTfYnnflPJaWxRPIPYjlrx.puzVnKjbWWaKIdOxIXdDkfWaAHYeA(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (XowdciIwOqiGUKwrulCFDUnqKbHfA(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				KgYSnWEDTvJkAImFFHLvdYemGAWTA(elementMap);
			}
			if (XowdciIwOqiGUKwrulCFDUnqKbHfA(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.iOBvpvyXULsKZzpvLHyLcmgkTAbM();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.KQvZlmyPDCAbJMosZEJiaypfudNPA(this, elementMap);
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
			JtYFKZPBhTNfUhaTQWIccnmyitDHA jtYFKZPBhTNfUhaTQWIccnmyitDHA = JtYFKZPBhTNfUhaTQWIccnmyitDHA.AANRuYPSSUukSiXkYtVRWtokGEcI(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, jtYFKZPBhTNfUhaTQWIccnmyitDHA.ITLnhbeZiAHQuDkXRitGAbtkVAWO, jtYFKZPBhTNfUhaTQWIccnmyitDHA.fmyPeGMdaEiIDJhhbYicQWLapWWIA, jtYFKZPBhTNfUhaTQWIccnmyitDHA.SOpykEFkiaGQFjSMIiCSrYCMmWvqA, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				result = null;
				return false;
			}
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(elementType))
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
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				KgYSnWEDTvJkAImFFHLvdYemGAWTA(elementMap);
			}
			if (XowdciIwOqiGUKwrulCFDUnqKbHfA(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			CeVoAmLHxQSjknnHUHqszbVVJNxd(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			int num = XowdciIwOqiGUKwrulCFDUnqKbHfA(elementMapId);
			if (num < 0)
			{
				return false;
			}
			OakNxSqaeSdWhYtPlFUTniaBsoSV(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i].kzHrLfsGRteEloHDejoDrezLTRte == elementMapId)
				{
					return WsKzJXCxukeCLrQgapetdQPaWPWV[i];
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (!skipDisabledMaps || allMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return hpqSabusThMLITaQcbpxXKvxXcUQ(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return TmXDUiZTjaAxVkVMuzfnVVNJDceO(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(rLtcgFGcgqUCJBpvGrpllVmtxMwJ))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new rLtcgFGcgqUCJBpvGrpllVmtxMwJ(-2)
			{
				BGLmBIPmXZQSzMofzitJiBMJUtHp = this,
				ZkjiFajvhdEHhVAThDZyBxGbpenC = actionId,
				fwTObpRAYCoxbZZAkJNVROiaEQGeA = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i]._actionId == actionId && (!skipDisabledMaps || WsKzJXCxukeCLrQgapetdQPaWPWV[i].vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					return WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = LmZJVlxQhHHugoUPZHYcFkBNejmj.pkDXGCQjAiRHdkJFwjAEsOHuJOav(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(lmZJVlxQhHHugoUPZHYcFkBNejmj, skipDisabledMaps);
			LmZJVlxQhHHugoUPZHYcFkBNejmj.agEPZUxPMkDBVgJqZEjgICltJWCl(lmZJVlxQhHHugoUPZHYcFkBNejmj);
			return result;
		}

		[IteratorStateMachine(typeof(iGjfdzRbWgdzKNAaePjWvJmSgERk))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new iGjfdzRbWgdzKNAaePjWvJmSgERk(-2)
			{
				MpsJlFysgpdjqiacVoNNigZhnJUMA = this,
				ZBdjtTFZSauFozWpLAOGUkRPFstEA = elementTarget,
				zBUpFhwlJpiiBSoSfXzgwMtLMBrj = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = LmZJVlxQhHHugoUPZHYcFkBNejmj.pkDXGCQjAiRHdkJFwjAEsOHuJOav(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(lmZJVlxQhHHugoUPZHYcFkBNejmj, actionId, skipDisabledMaps);
			LmZJVlxQhHHugoUPZHYcFkBNejmj.agEPZUxPMkDBVgJqZEjgICltJWCl(lmZJVlxQhHHugoUPZHYcFkBNejmj);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(SABCKeBlYxVFzodNPHHOXvOsieNy))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new SABCKeBlYxVFzodNPHHOXvOsieNy(-2)
			{
				WMgTovOsvTatbXQPuYGTpslbCtPA = this,
				MinTTuboQXkZWKnQGqRepHQtZgkb = elementTarget,
				TSyPYniXioSsgCaqBBTaCSSeBYDAA = actionId,
				ATJIAfdQBFeewcPrEloBFioQGXtY = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = LmZJVlxQhHHugoUPZHYcFkBNejmj.pkDXGCQjAiRHdkJFwjAEsOHuJOav(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(lmZJVlxQhHHugoUPZHYcFkBNejmj, skipDisabledMaps);
			LmZJVlxQhHHugoUPZHYcFkBNejmj.agEPZUxPMkDBVgJqZEjgICltJWCl(lmZJVlxQhHHugoUPZHYcFkBNejmj);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			bool flag;
			return IspGxunnuOvRuAdoVQLNZwuTNSyf(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = LmZJVlxQhHHugoUPZHYcFkBNejmj.pkDXGCQjAiRHdkJFwjAEsOHuJOav(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(lmZJVlxQhHHugoUPZHYcFkBNejmj, actionId, skipDisabledMaps);
			LmZJVlxQhHHugoUPZHYcFkBNejmj.agEPZUxPMkDBVgJqZEjgICltJWCl(lmZJVlxQhHHugoUPZHYcFkBNejmj);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			bool flag;
			return IspGxunnuOvRuAdoVQLNZwuTNSyf(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = LmZJVlxQhHHugoUPZHYcFkBNejmj.pkDXGCQjAiRHdkJFwjAEsOHuJOav(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(lmZJVlxQhHHugoUPZHYcFkBNejmj, skipDisabledMaps, results);
			LmZJVlxQhHHugoUPZHYcFkBNejmj.agEPZUxPMkDBVgJqZEjgICltJWCl(lmZJVlxQhHHugoUPZHYcFkBNejmj);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			bool flag;
			return biNGvbASEzcfdrNskXzGrsWeiLTVA(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = LmZJVlxQhHHugoUPZHYcFkBNejmj.pkDXGCQjAiRHdkJFwjAEsOHuJOav(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(lmZJVlxQhHHugoUPZHYcFkBNejmj, actionId, skipDisabledMaps, results);
			LmZJVlxQhHHugoUPZHYcFkBNejmj.agEPZUxPMkDBVgJqZEjgICltJWCl(lmZJVlxQhHHugoUPZHYcFkBNejmj);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			bool flag;
			return biNGvbASEzcfdrNskXzGrsWeiLTVA(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			return iuEMKcoaYuVSxnbUEyRwlXTDXQpl(predicate, false);
		}

		internal virtual ActionElementMap iuEMKcoaYuVSxnbUEyRwlXTDXQpl(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return QPgTxlEVaaBiatAGzaPLIKzlhWvNA(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return kmxcRNjEbMkIpQCMnmoprJkiXrcq(predicate, false, results, false);
		}

		internal virtual int kmxcRNjEbMkIpQCMnmoprJkiXrcq(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return RQpjzcPLocWTUEeemSUjhvrNrTJj(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			int count = jJhoZVefAveFVkkDaZBWfClVEGfdA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = jJhoZVefAveFVkkDaZBWfClVEGfdA[i];
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return;
			}
			WsKzJXCxukeCLrQgapetdQPaWPWV.Clear();
			jJhoZVefAveFVkkDaZBWfClVEGfdA.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int num = 0;
			int count = jJhoZVefAveFVkkDaZBWfClVEGfdA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = jJhoZVefAveFVkkDaZBWfClVEGfdA[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk != state)
				{
					actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null || index < 0 || index >= WsKzJXCxukeCLrQgapetdQPaWPWV.Count)
			{
				return null;
			}
			return WsKzJXCxukeCLrQgapetdQPaWPWV[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(WsKzJXCxukeCLrQgapetdQPaWPWV);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = WsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return xXPhycYHgaevntKUkInjcqMfhOUh(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
				ActionElementMap actionElementMap2 = WsKzJXCxukeCLrQgapetdQPaWPWV[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			InputAction inputAction = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.UrFBGeUydNKZVDjXjxgTLOAaAyxj(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return zTHVYxfYKEvCfbotZgLCGceWRGbcA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(gzGgtBghOUkdjtLBsqBMEReKvFRGB))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new gzGgtBghOUkdjtLBsqBMEReKvFRGB(-2)
			{
				xFMIRwivsngnKZQkyFayFlnHtalnb = this,
				eWZbCvGeCEOvTeZvrecKUnbYKNClA = actionId,
				yMKbopeKPPHEDphFxGYgvOLJPvUuA = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			int actionId = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			return QPgTxlEVaaBiatAGzaPLIKzlhWvNA(predicate, false);
		}

		internal ActionElementMap QPgTxlEVaaBiatAGzaPLIKzlhWvNA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return RQpjzcPLocWTUEeemSUjhvrNrTJj(predicate, false, results, false);
		}

		internal int RQpjzcPLocWTUEeemSUjhvrNrTJj(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			int count = WsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
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
			return DeleteButtonMapsWithAction(ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					OakNxSqaeSdWhYtPlFUTniaBsoSV(actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			int num = 0;
			int count = WsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk != state)
				{
					actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk = state;
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (skipDisabledMaps && !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			if (actionElementMap == null || WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
			{
				return false;
			}
			for (int i = 0; i < WsKzJXCxukeCLrQgapetdQPaWPWV.Count; i++)
			{
				ActionElementMap actionElementMap2 = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return false;
			}
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
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
			for (int i = 0; i < WsKzJXCxukeCLrQgapetdQPaWPWV.Count; i++)
			{
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if ((!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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

		[IteratorStateMachine(typeof(VfsnYAgTBJEMgteJXbZrUuWAkOsK))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new VfsnYAgTBJEMgteJXbZrUuWAkOsK(-2)
			{
				sOSmbzcMWqbCIbxKOsGSkNevLZkZA = this,
				rmBlHCKXTVstGugkJcYrFUcfTuaPA = controllerMap,
				eIdychNVkMSVtFwAKPcxRorXkhZt = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(ZIkwTnfDpCaYuCWMEYCNmEWKnTIl))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new ZIkwTnfDpCaYuCWMEYCNmEWKnTIl(-2)
			{
				gevtwwATLZpvmZlrwGqUlRkYQvAS = this,
				jUoCzDqwqozXhJkTcIvvKJLTutUP = actionElementMap,
				sTwyHVEWJGxmFORVvlsrKILkGNkhA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(PcgTMlfEPFBlJQfXpbJRDDcvjloOA))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new PcgTMlfEPFBlJQfXpbJRDDcvjloOA(-2)
			{
				HiNlVkswHuPArKXDQOYxIvLDMhrp = this,
				NSQxCUUdaRPMwFkCURyjuvmdtOfi = conflictCheck,
				wbShwUhVGoDspYbjKOcIDuhFeaFNb = skipDisabledMaps
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return num;
			}
			IList<ActionElementMap> wsKzJXCxukeCLrQgapetdQPaWPWV = controllerMap.WsKzJXCxukeCLrQgapetdQPaWPWV;
			if (wsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = wsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			for (int num2 = WsKzJXCxukeCLrQgapetdQPaWPWV.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[num2];
				if (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || wsKzJXCxukeCLrQgapetdQPaWPWV[i].vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(wsKzJXCxukeCLrQgapetdQPaWPWV[i]))
						{
							OakNxSqaeSdWhYtPlFUTniaBsoSV(actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, num2);
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return num;
			}
			for (int num2 = WsKzJXCxukeCLrQgapetdQPaWPWV.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = WsKzJXCxukeCLrQgapetdQPaWPWV[num2];
				if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					OakNxSqaeSdWhYtPlFUTniaBsoSV(actionElementMap2.kzHrLfsGRteEloHDejoDrezLTRte, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
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
			for (int num2 = WsKzJXCxukeCLrQgapetdQPaWPWV.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[num2];
				if ((!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					OakNxSqaeSdWhYtPlFUTniaBsoSV(actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return lhoZhSkWcQiKkhcUsCDVAbumRbhbA(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return jjBRzRaCxXgpPBoKPyxthlDsuMvW(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return JrrMBvqXYDRKjEDTxGqUHoNrLTPEA(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return lhoZhSkWcQiKkhcUsCDVAbumRbhbA(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return jjBRzRaCxXgpPBoKPyxthlDsuMvW(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return 0;
			}
			return JrrMBvqXYDRKjEDTxGqUHoNrLTPEA(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int lhoZhSkWcQiKkhcUsCDVAbumRbhbA(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return num;
			}
			IList<ActionElementMap> wsKzJXCxukeCLrQgapetdQPaWPWV = P_0.WsKzJXCxukeCLrQgapetdQPaWPWV;
			if (wsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = wsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (!actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = wsKzJXCxukeCLrQgapetdQPaWPWV[j];
					if ((!P_1 || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int jjBRzRaCxXgpPBoKPyxthlDsuMvW(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int JrrMBvqXYDRKjEDTxGqUHoNrLTPEA(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (jJhoZVefAveFVkkDaZBWfClVEGfdA == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.jJhoZVefAveFVkkDaZBWfClVEGfdA;
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
			for (int num2 = jJhoZVefAveFVkkDaZBWfClVEGfdA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = jJhoZVefAveFVkkDaZBWfClVEGfdA[num2];
				if (!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.CheckForAssignmentConflict(list[i]))
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
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
			if (jJhoZVefAveFVkkDaZBWfClVEGfdA == null)
			{
				return num;
			}
			for (int num2 = jJhoZVefAveFVkkDaZBWfClVEGfdA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = jJhoZVefAveFVkkDaZBWfClVEGfdA[num2];
				if ((!skipDisabledMaps || actionElementMap2.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			if (jJhoZVefAveFVkkDaZBWfClVEGfdA == null)
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
			for (int num2 = jJhoZVefAveFVkkDaZBWfClVEGfdA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = jJhoZVefAveFVkkDaZBWfClVEGfdA[num2];
				if ((!skipDisabledMaps || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk) && actionElementMap.kzHrLfsGRteEloHDejoDrezLTRte != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				array[i] = WsKzJXCxukeCLrQgapetdQPaWPWV[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return string.Empty;
			}
			try
			{
				return elcGbUBkuCdkgRqLuIUfuLZAJpJSA().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return string.Empty;
			}
			try
			{
				return elcGbUBkuCdkgRqLuIUfuLZAJpJSA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.JygnrFiMhuenDfjLmROYbiKJJoKeA(templateTypeGuid);
				string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.pNwDHdFNwRNhqTVrAOeAOvaVaDhE(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
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
			return ControllerTemplateMap.pNwDHdFNwRNhqTVrAOeAOvaVaDhE(controllerTemplate, this);
		}

		private ControllerTemplateMap YYysKjQnDOIaZAVcFbKKEISrPqZSA(IControllerTemplate P_0)
		{
			if (ReInput._id != ocpJEhDKZGwjCNHUhUPdlzibnEKu)
			{
				ReInput.CheckInitialized(ocpJEhDKZGwjCNHUhUPdlzibnEKu);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.pNwDHdFNwRNhqTVrAOeAOvaVaDhE(P_0, this);
		}

		internal virtual bool LtPlOjVYNTfYZlErEqgWUUqCmfNC(ActionElementMap P_0)
		{
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_0._elementType))
			{
				return false;
			}
			KgYSnWEDTvJkAImFFHLvdYemGAWTA(P_0);
			return true;
		}

		internal virtual int hpqSabusThMLITaQcbpxXKvxXcUQ(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = WsKzJXCxukeCLrQgapetdQPaWPWV.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || WsKzJXCxukeCLrQgapetdQPaWPWV[i].vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					P_0.Add(WsKzJXCxukeCLrQgapetdQPaWPWV[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap EoMduUgdNytAMhPHzClBtYEjnCnv(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_2))
			{
				return null;
			}
			int num = uKQzuGflsGWiYcDzJtLWvdiMIfKiA(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return WsKzJXCxukeCLrQgapetdQPaWPWV[num];
		}

		internal virtual int xonFjqeWWbHFzWPtLrmcEPfLfugx(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i]._elementIdentifierId == P_0)
				{
					P_1.Add(WsKzJXCxukeCLrQgapetdQPaWPWV[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool sapUymPQxuCcfmyfjEnyybsZOplQ(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i]._elementIdentifierId == P_0 && WsKzJXCxukeCLrQgapetdQPaWPWV[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int uKQzuGflsGWiYcDzJtLWvdiMIfKiA(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_2))
			{
				return -1;
			}
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i]._elementIdentifierId == P_0 && WsKzJXCxukeCLrQgapetdQPaWPWV[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int XowdciIwOqiGUKwrulCFDUnqKbHfA(int P_0)
		{
			if (WsKzJXCxukeCLrQgapetdQPaWPWV == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i].kzHrLfsGRteEloHDejoDrezLTRte == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int xXPhycYHgaevntKUkInjcqMfhOUh(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (!P_0 || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int zTHVYxfYKEvCfbotZgLCGceWRGbcA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int TmXDUiZTjaAxVkVMuzfnVVNJDceO(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.vWZNVuVXYnOfJimlqfUderrRDbRk))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap IspGxunnuOvRuAdoVQLNZwuTNSyf(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!BQlLXSRISTwcqMLWKIAyOdnxYEwC(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || WsKzJXCxukeCLrQgapetdQPaWPWV[i]._actionId == P_2) && (!P_3 || WsKzJXCxukeCLrQgapetdQPaWPWV[i].vWZNVuVXYnOfJimlqfUderrRDbRk) && WsKzJXCxukeCLrQgapetdQPaWPWV[i].IsTarget(P_0))
				{
					return WsKzJXCxukeCLrQgapetdQPaWPWV[i];
				}
			}
			return null;
		}

		internal virtual int biNGvbASEzcfdrNskXzGrsWeiLTVA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!BQlLXSRISTwcqMLWKIAyOdnxYEwC(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || WsKzJXCxukeCLrQgapetdQPaWPWV[i]._actionId == P_2) && (!P_3 || WsKzJXCxukeCLrQgapetdQPaWPWV[i].vWZNVuVXYnOfJimlqfUderrRDbRk) && WsKzJXCxukeCLrQgapetdQPaWPWV[i].IsTarget(P_0))
				{
					P_4.Add(WsKzJXCxukeCLrQgapetdQPaWPWV[i]);
					num++;
				}
			}
			return num;
		}

		internal void WbqiCeDeQwtYzDyWsetnYnxHaumU(int P_0, ControllerElementType P_1)
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
				ElxoijAztPBQPndXqbcVrWBFEkYHA(elementMap);
			}
		}

		internal virtual bool ElxoijAztPBQPndXqbcVrWBFEkYHA(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(P_0._elementType))
			{
				return false;
			}
			WsKzJXCxukeCLrQgapetdQPaWPWV.Add(P_0);
			SSQfFmKlDdRCBfFbKpGLxXqWYkrf(P_0);
			return true;
		}

		internal bool BQlLXSRISTwcqMLWKIAyOdnxYEwC(IControllerElementTarget P_0)
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

		internal bool VvySwuCpMwjDaSvcwRNyTBJCnfAE(string P_0)
		{
			try
			{
				ZVXtcMiUwlpvErxTZfSqcUNoHRIn(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool ejfYXwPrPRljIwxBWRzLTvKeBZKM(string P_0)
		{
			try
			{
				ZVXtcMiUwlpvErxTZfSqcUNoHRIn(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void SSQfFmKlDdRCBfFbKpGLxXqWYkrf(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				jJhoZVefAveFVkkDaZBWfClVEGfdA.Add(P_0);
				jJhoZVefAveFVkkDaZBWfClVEGfdA.Sort(FSbhMIVhgNzYbVzdoFUrPEWtTkuS.PtKLHIIIdciAffumGvgGpRwHrrHmA);
			}
		}

		internal void QIOZVxWMlTDVWBVkcoVaNAuTusPJ(int P_0)
		{
			int num = HmLQAnFzJspEYDbRVtTLbsEIpbtJ(P_0);
			if (num >= 0)
			{
				jJhoZVefAveFVkkDaZBWfClVEGfdA.RemoveAt(num);
			}
		}

		internal void sNYoQWBqtQgiROknVvKfdbNoiBeH(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = HmLQAnFzJspEYDbRVtTLbsEIpbtJ(P_0);
				if (num >= 0)
				{
					jJhoZVefAveFVkkDaZBWfClVEGfdA[num] = P_1;
					jJhoZVefAveFVkkDaZBWfClVEGfdA.Sort(FSbhMIVhgNzYbVzdoFUrPEWtTkuS.PtKLHIIIdciAffumGvgGpRwHrrHmA);
				}
			}
		}

		internal static void CeVoAmLHxQSjknnHUHqszbVVJNxd(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.iOBvpvyXULsKZzpvLHyLcmgkTAbM();
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
				ReInput.controllers.GetController(_controllerType, _controllerId)?.KQvZlmyPDCAbJMosZEJiaypfudNPA(this, map);
			}
		}

		internal virtual bool ZVXtcMiUwlpvErxTZfSqcUNoHRIn(SerializedObject P_0)
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
						actionElementMap.gCKvccrHYEoqqBekokCUNAtDNOif(value2);
						if (ActionElementMap.shTAdQDevfqGEetMFpDyDnHLMEor(actionElementMap))
						{
							KgYSnWEDTvJkAImFFHLvdYemGAWTA(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void uwAYdMrDJPhumhAFmaccaZNzGqEyA(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "dataVersion",
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string wqpBUPsVbkYZOHRjZkDHzExwrqmJ = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
				{
					rVQdJsUVGueUoRlsQQCEHMDLFJOq = "hardwareGuid",
					wqpBUPsVbkYZOHRjZkDHzExwrqmJ = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
				{
					rVQdJsUVGueUoRlsQQCEHMDLFJOq = "hardwareName",
					wqpBUPsVbkYZOHRjZkDHzExwrqmJ = wqpBUPsVbkYZOHRjZkDHzExwrqmJ
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				GXuxQnHFoIjGhTjGJBCERvyaPbcC = "xmlns",
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "xsi",
				JTcffmzfUBZAVjPblkObnRNPpqZG = null,
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				GXuxQnHFoIjGhTjGJBCERvyaPbcC = "xsi",
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "schemaLocation",
				JTcffmzfUBZAVjPblkObnRNPpqZG = null,
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (WsKzJXCxukeCLrQgapetdQPaWPWV[i] != null)
				{
					list.Add(WsKzJXCxukeCLrQgapetdQPaWPWV[i].yLLQaYNTgPqJqwARjNubvJJUJcvv());
				}
			}
		}

		private bool ZiuYHoSvSWCTdIYLXvRtVlpdHxwl(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void OakNxSqaeSdWhYtPlFUTniaBsoSV(int P_0, int P_1)
		{
			QIOZVxWMlTDVWBVkcoVaNAuTusPJ(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				WsKzJXCxukeCLrQgapetdQPaWPWV.RemoveAt(P_1);
			}
		}

		private void KgYSnWEDTvJkAImFFHLvdYemGAWTA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				WsKzJXCxukeCLrQgapetdQPaWPWV.Add(P_0);
				SSQfFmKlDdRCBfFbKpGLxXqWYkrf(P_0);
			}
		}

		private void tsKSgKYRxxTFMOSUENaxqHcEPJql(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				sNYoQWBqtQgiROknVvKfdbNoiBeH(WsKzJXCxukeCLrQgapetdQPaWPWV[P_1].kzHrLfsGRteEloHDejoDrezLTRte, P_0);
				WsKzJXCxukeCLrQgapetdQPaWPWV[P_1] = P_0;
			}
		}

		private int HmLQAnFzJspEYDbRVtTLbsEIpbtJ(int P_0)
		{
			if (jJhoZVefAveFVkkDaZBWfClVEGfdA == null)
			{
				return -1;
			}
			int count = jJhoZVefAveFVkkDaZBWfClVEGfdA.Count;
			for (int i = 0; i < count; i++)
			{
				if (jJhoZVefAveFVkkDaZBWfClVEGfdA[i].kzHrLfsGRteEloHDejoDrezLTRte == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject elcGbUBkuCdkgRqLuIUfuLZAJpJSA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			uwAYdMrDJPhumhAFmaccaZNzGqEyA(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap ypbYJNxChdplXGglBbDKJNWHdLYsA(ControllerType P_0)
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

		internal static ControllerMap BRYuuRABvxNOfRJFzyiqkuaVFYPO(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.QzFzdDuccugshrrKBtQQCEKWyaRb(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.IutFGGubdGcNoGJysPpFgsIVHoRbb(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.KxOlJQwGhYKpCgBPwhupJvotQUvj(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.JvsHWcJkUQLUTXzMkcTLfkOAgVihA(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = ypbYJNxChdplXGglBbDKJNWHdLYsA(controllerType);
			try
			{
				controllerMap.VvySwuCpMwjDaSvcwRNyTBJCnfAE(xmlString);
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
			ControllerMap controllerMap = ypbYJNxChdplXGglBbDKJNWHdLYsA(controllerType);
			try
			{
				controllerMap.ejfYXwPrPRljIwxBWRzLTvKeBZKM(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
