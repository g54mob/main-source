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
		private sealed class hECOiMkzDyfICvsfOxevadOthIF : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMapWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int KjaWgObGREamoandMdAXxTdnHIgu;

			public int YOXLccoEMCTpcLNYciWfwMnsHwE;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public ActionElementMap wvYxQfabccyQhYdhItnuyHrnSHR;

			public IEnumerator<ActionElementMap> UyWmoWtlJwLLruFuHqmnZhGlapc;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				hECOiMkzDyfICvsfOxevadOthIF hECOiMkzDyfICvsfOxevadOthIF2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					hECOiMkzDyfICvsfOxevadOthIF2 = this;
				}
				else
				{
					hECOiMkzDyfICvsfOxevadOthIF2 = new hECOiMkzDyfICvsfOxevadOthIF(0);
					hECOiMkzDyfICvsfOxevadOthIF2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				hECOiMkzDyfICvsfOxevadOthIF2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
				hECOiMkzDyfICvsfOxevadOthIF2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return hECOiMkzDyfICvsfOxevadOthIF2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							break;
						}
						if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
						{
							break;
						}
						UyWmoWtlJwLLruFuHqmnZhGlapc = kdBZqupjvsCsVkwJiOeEQzkEDVO.AxisMaps.GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00cf;
					case 2:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_00cf;
						}
						IL_00cf:
						while (UyWmoWtlJwLLruFuHqmnZhGlapc.MoveNext())
						{
							wvYxQfabccyQhYdhItnuyHrnSHR = UyWmoWtlJwLLruFuHqmnZhGlapc.Current;
							if (wvYxQfabccyQhYdhItnuyHrnSHR._actionId == KjaWgObGREamoandMdAXxTdnHIgu && (!sBBuxyRWJQpBnxBQfhNyotyrnMk || wvYxQfabccyQhYdhItnuyHrnSHR.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = wvYxQfabccyQhYdhItnuyHrnSHR;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						CatKGlCjTaAzCMSRPLBtRvdjfSi();
						break;
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						CatKGlCjTaAzCMSRPLBtRvdjfSi();
					}
				}
			}

			[DebuggerHidden]
			public hECOiMkzDyfICvsfOxevadOthIF(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void CatKGlCjTaAzCMSRPLBtRvdjfSi()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (UyWmoWtlJwLLruFuHqmnZhGlapc != null)
				{
					UyWmoWtlJwLLruFuHqmnZhGlapc.Dispose();
				}
			}
		}

		private sealed class oKDFQgGMSFUxWLvbgBqBZFhjkGDN : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMapWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ControllerMap XKsXMwpOxrVrFXsnXueqVpKoaEV;

			public ControllerMap UkPuziaGThQCqHJbVOTnNlEiKOt;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public ElementAssignmentConflictInfo MSfORfhurdbaPimMVFktAHiZkHm;

			public ControllerMapWithAxes MjyxOQkqzFFrLZOdtxZahmCoyLt;

			public IList<ActionElementMap> gOwVHSNXYzOcxTgDrcwRToBJhXx;

			public int cIZyCoOxoJRcQlzsQuujUKcIKDC;

			public int mLZxZJKvMLdRFUhpDTOTtRQZJUF;

			public ActionElementMap IcaZFpWKkWAjPIcGGaydDvwwvIGh;

			public int FnQpUQRYkeWTgJOGvrlHLFpLVTt;

			public ActionElementMap PlTAlsTDVpZQmUDyWfcNAnRIPIKG;

			public IEnumerator<ElementAssignmentConflictInfo> gkmDRrRgIaJOUjTatrkkGFsnVvl;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				oKDFQgGMSFUxWLvbgBqBZFhjkGDN oKDFQgGMSFUxWLvbgBqBZFhjkGDN2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					oKDFQgGMSFUxWLvbgBqBZFhjkGDN2 = this;
				}
				else
				{
					oKDFQgGMSFUxWLvbgBqBZFhjkGDN2 = new oKDFQgGMSFUxWLvbgBqBZFhjkGDN(0);
					oKDFQgGMSFUxWLvbgBqBZFhjkGDN2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				oKDFQgGMSFUxWLvbgBqBZFhjkGDN2.XKsXMwpOxrVrFXsnXueqVpKoaEV = UkPuziaGThQCqHJbVOTnNlEiKOt;
				oKDFQgGMSFUxWLvbgBqBZFhjkGDN2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return oKDFQgGMSFUxWLvbgBqBZFhjkGDN2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							break;
						}
						if (XKsXMwpOxrVrFXsnXueqVpKoaEV == null)
						{
							break;
						}
						gkmDRrRgIaJOUjTatrkkGFsnVvl = ((ControllerMap)kdBZqupjvsCsVkwJiOeEQzkEDVO).ElementAssignmentConflicts(XKsXMwpOxrVrFXsnXueqVpKoaEV, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00b9;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00b9;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_026a;
						}
						IL_0297:
						if (mLZxZJKvMLdRFUhpDTOTtRQZJUF >= kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count)
						{
							break;
						}
						IcaZFpWKkWAjPIcGGaydDvwwvIGh = kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk[mLZxZJKvMLdRFUhpDTOTtRQZJUF];
						if (!sBBuxyRWJQpBnxBQfhNyotyrnMk || IcaZFpWKkWAjPIcGGaydDvwwvIGh.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
						{
							FnQpUQRYkeWTgJOGvrlHLFpLVTt = 0;
							goto IL_0278;
						}
						goto IL_0289;
						IL_026a:
						FnQpUQRYkeWTgJOGvrlHLFpLVTt++;
						goto IL_0278;
						IL_0278:
						if (FnQpUQRYkeWTgJOGvrlHLFpLVTt < cIZyCoOxoJRcQlzsQuujUKcIKDC)
						{
							PlTAlsTDVpZQmUDyWfcNAnRIPIKG = gOwVHSNXYzOcxTgDrcwRToBJhXx[FnQpUQRYkeWTgJOGvrlHLFpLVTt];
							if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || PlTAlsTDVpZQmUDyWfcNAnRIPIKG.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && IcaZFpWKkWAjPIcGGaydDvwwvIGh.CheckForAssignmentConflict(PlTAlsTDVpZQmUDyWfcNAnRIPIKG))
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(kdBZqupjvsCsVkwJiOeEQzkEDVO._categoryId).userAssignable, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerType, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerId, kdBZqupjvsCsVkwJiOeEQzkEDVO._id, IcaZFpWKkWAjPIcGGaydDvwwvIGh.fOjavGziuUSawAgvwyVARpyRBVx, IcaZFpWKkWAjPIcGGaydDvwwvIGh._actionId, IcaZFpWKkWAjPIcGGaydDvwwvIGh._elementType, IcaZFpWKkWAjPIcGGaydDvwwvIGh._elementIdentifierId, IcaZFpWKkWAjPIcGGaydDvwwvIGh.keyCode, IcaZFpWKkWAjPIcGGaydDvwwvIGh.modifierKeyFlags);
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								return true;
							}
							goto IL_026a;
						}
						goto IL_0289;
						IL_00b9:
						if (gkmDRrRgIaJOUjTatrkkGFsnVvl.MoveNext())
						{
							MSfORfhurdbaPimMVFktAHiZkHm = gkmDRrRgIaJOUjTatrkkGFsnVvl.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = MSfORfhurdbaPimMVFktAHiZkHm;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						XGSeoVfTVLCAzgmHyNRzdkHABVsT();
						MjyxOQkqzFFrLZOdtxZahmCoyLt = XKsXMwpOxrVrFXsnXueqVpKoaEV as ControllerMapWithAxes;
						if (MjyxOQkqzFFrLZOdtxZahmCoyLt == null || (sBBuxyRWJQpBnxBQfhNyotyrnMk && (!kdBZqupjvsCsVkwJiOeEQzkEDVO._enabled || !MjyxOQkqzFFrLZOdtxZahmCoyLt._enabled)))
						{
							break;
						}
						gOwVHSNXYzOcxTgDrcwRToBJhXx = MjyxOQkqzFFrLZOdtxZahmCoyLt.AxisMaps;
						if (gOwVHSNXYzOcxTgDrcwRToBJhXx == null)
						{
							break;
						}
						cIZyCoOxoJRcQlzsQuujUKcIKDC = gOwVHSNXYzOcxTgDrcwRToBJhXx.Count;
						mLZxZJKvMLdRFUhpDTOTtRQZJUF = 0;
						goto IL_0297;
						IL_0289:
						mLZxZJKvMLdRFUhpDTOTtRQZJUF++;
						goto IL_0297;
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						XGSeoVfTVLCAzgmHyNRzdkHABVsT();
					}
				}
			}

			[DebuggerHidden]
			public oKDFQgGMSFUxWLvbgBqBZFhjkGDN(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void XGSeoVfTVLCAzgmHyNRzdkHABVsT()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (gkmDRrRgIaJOUjTatrkkGFsnVvl != null)
				{
					gkmDRrRgIaJOUjTatrkkGFsnVvl.Dispose();
				}
			}
		}

		private sealed class iVasudWhhomSgTnegnSinaeejyy : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMapWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ActionElementMap laNInwdlemPELucvBOGimoeNQfc;

			public ActionElementMap ILxNeiUFNlXBMCfWlwycEgXzexcE;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public ElementAssignmentConflictInfo xBtoUcRkUDrioJgrjepYvKOieXPd;

			public int iruDJNNTOISYWFuVLhOVfHeygkb;

			public ActionElementMap beHvqAPCtDlmnhKLLxiCzpcMatN;

			public IEnumerator<ElementAssignmentConflictInfo> BhwXuwBRvXQrEKCswATimpTgYvO;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				iVasudWhhomSgTnegnSinaeejyy iVasudWhhomSgTnegnSinaeejyy2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					iVasudWhhomSgTnegnSinaeejyy2 = this;
				}
				else
				{
					iVasudWhhomSgTnegnSinaeejyy2 = new iVasudWhhomSgTnegnSinaeejyy(0);
					iVasudWhhomSgTnegnSinaeejyy2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				iVasudWhhomSgTnegnSinaeejyy2.laNInwdlemPELucvBOGimoeNQfc = ILxNeiUFNlXBMCfWlwycEgXzexcE;
				iVasudWhhomSgTnegnSinaeejyy2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return iVasudWhhomSgTnegnSinaeejyy2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							break;
						}
						if (laNInwdlemPELucvBOGimoeNQfc == null)
						{
							break;
						}
						BhwXuwBRvXQrEKCswATimpTgYvO = ((ControllerMap)kdBZqupjvsCsVkwJiOeEQzkEDVO).ElementAssignmentConflicts(laNInwdlemPELucvBOGimoeNQfc, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00b9;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00b9;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_01f6;
						}
						IL_00b9:
						if (BhwXuwBRvXQrEKCswATimpTgYvO.MoveNext())
						{
							xBtoUcRkUDrioJgrjepYvKOieXPd = BhwXuwBRvXQrEKCswATimpTgYvO.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = xBtoUcRkUDrioJgrjepYvKOieXPd;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						qndRYncdocFAKahyMdWxEgDWnUod();
						if ((sBBuxyRWJQpBnxBQfhNyotyrnMk && (!kdBZqupjvsCsVkwJiOeEQzkEDVO._enabled || !laNInwdlemPELucvBOGimoeNQfc.TAiAzEAcNOkrpYWJEmhYYqnFvpF)) || kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
						{
							break;
						}
						iruDJNNTOISYWFuVLhOVfHeygkb = 0;
						goto IL_0204;
						IL_01f6:
						iruDJNNTOISYWFuVLhOVfHeygkb++;
						goto IL_0204;
						IL_0204:
						if (iruDJNNTOISYWFuVLhOVfHeygkb >= kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count)
						{
							break;
						}
						beHvqAPCtDlmnhKLLxiCzpcMatN = kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk[iruDJNNTOISYWFuVLhOVfHeygkb];
						if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || beHvqAPCtDlmnhKLLxiCzpcMatN.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && beHvqAPCtDlmnhKLLxiCzpcMatN.CheckForAssignmentConflict(laNInwdlemPELucvBOGimoeNQfc))
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(kdBZqupjvsCsVkwJiOeEQzkEDVO._categoryId).userAssignable, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerType, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerId, kdBZqupjvsCsVkwJiOeEQzkEDVO._id, beHvqAPCtDlmnhKLLxiCzpcMatN.fOjavGziuUSawAgvwyVARpyRBVx, beHvqAPCtDlmnhKLLxiCzpcMatN._actionId, beHvqAPCtDlmnhKLLxiCzpcMatN._elementType, beHvqAPCtDlmnhKLLxiCzpcMatN._elementIdentifierId, beHvqAPCtDlmnhKLLxiCzpcMatN.keyCode, beHvqAPCtDlmnhKLLxiCzpcMatN.modifierKeyFlags);
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						goto IL_01f6;
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						qndRYncdocFAKahyMdWxEgDWnUod();
					}
				}
			}

			[DebuggerHidden]
			public iVasudWhhomSgTnegnSinaeejyy(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void qndRYncdocFAKahyMdWxEgDWnUod()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (BhwXuwBRvXQrEKCswATimpTgYvO != null)
				{
					BhwXuwBRvXQrEKCswATimpTgYvO.Dispose();
				}
			}
		}

		private sealed class TFZIjnEcnCZmFrAcerZcVjjPRAFL : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMapWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

			public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public ElementAssignmentConflictInfo LBrWgtmtqOGDudbSykiLXaADDll;

			public ElementAssignment jJYLbtDmacQRXkoboFrfFoeWuKt;

			public int UeFvfJdROskYZcvCYBRjHELtUVS;

			public ActionElementMap cEPgZpoZSgPPCkIkoyMEyyIzIKX;

			public IEnumerator<ElementAssignmentConflictInfo> pvTQdNOfwfrWAMQhKigxqbaUDju;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				TFZIjnEcnCZmFrAcerZcVjjPRAFL tFZIjnEcnCZmFrAcerZcVjjPRAFL;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					tFZIjnEcnCZmFrAcerZcVjjPRAFL = this;
				}
				else
				{
					tFZIjnEcnCZmFrAcerZcVjjPRAFL = new TFZIjnEcnCZmFrAcerZcVjjPRAFL(0);
					tFZIjnEcnCZmFrAcerZcVjjPRAFL.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				tFZIjnEcnCZmFrAcerZcVjjPRAFL.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
				tFZIjnEcnCZmFrAcerZcVjjPRAFL.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return tFZIjnEcnCZmFrAcerZcVjjPRAFL;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							break;
						}
						pvTQdNOfwfrWAMQhKigxqbaUDju = ((ControllerMap)kdBZqupjvsCsVkwJiOeEQzkEDVO).ElementAssignmentConflicts(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00ae;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00ae;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_0207;
						}
						IL_0215:
						if (UeFvfJdROskYZcvCYBRjHELtUVS >= kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count)
						{
							break;
						}
						cEPgZpoZSgPPCkIkoyMEyyIzIKX = kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk[UeFvfJdROskYZcvCYBRjHELtUVS];
						if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || cEPgZpoZSgPPCkIkoyMEyyIzIKX.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && cEPgZpoZSgPPCkIkoyMEyyIzIKX.fOjavGziuUSawAgvwyVARpyRBVx != sADsWDUCiahlWYuuUKwcFHVfnhS.elementMapId && cEPgZpoZSgPPCkIkoyMEyyIzIKX.CheckForAssignmentConflict(jJYLbtDmacQRXkoboFrfFoeWuKt))
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(kdBZqupjvsCsVkwJiOeEQzkEDVO._categoryId).userAssignable, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerType, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerId, kdBZqupjvsCsVkwJiOeEQzkEDVO._id, cEPgZpoZSgPPCkIkoyMEyyIzIKX.fOjavGziuUSawAgvwyVARpyRBVx, cEPgZpoZSgPPCkIkoyMEyyIzIKX._actionId, cEPgZpoZSgPPCkIkoyMEyyIzIKX._elementType, cEPgZpoZSgPPCkIkoyMEyyIzIKX._elementIdentifierId, cEPgZpoZSgPPCkIkoyMEyyIzIKX.keyCode, cEPgZpoZSgPPCkIkoyMEyyIzIKX.modifierKeyFlags);
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						goto IL_0207;
						IL_0207:
						UeFvfJdROskYZcvCYBRjHELtUVS++;
						goto IL_0215;
						IL_00ae:
						if (pvTQdNOfwfrWAMQhKigxqbaUDju.MoveNext())
						{
							LBrWgtmtqOGDudbSykiLXaADDll = pvTQdNOfwfrWAMQhKigxqbaUDju.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = LBrWgtmtqOGDudbSykiLXaADDll;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						DRqvPsmyPXJhAAlLLcwShAPRdYBa();
						if ((sBBuxyRWJQpBnxBQfhNyotyrnMk && !kdBZqupjvsCsVkwJiOeEQzkEDVO._enabled) || kdBZqupjvsCsVkwJiOeEQzkEDVO.yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
						{
							break;
						}
						jJYLbtDmacQRXkoboFrfFoeWuKt = sADsWDUCiahlWYuuUKwcFHVfnhS.ToElementAssignment();
						UeFvfJdROskYZcvCYBRjHELtUVS = 0;
						goto IL_0215;
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						DRqvPsmyPXJhAAlLLcwShAPRdYBa();
					}
				}
			}

			[DebuggerHidden]
			public TFZIjnEcnCZmFrAcerZcVjjPRAFL(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void DRqvPsmyPXJhAAlLLcwShAPRdYBa()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (pvTQdNOfwfrWAMQhKigxqbaUDju != null)
				{
					pvTQdNOfwfrWAMQhKigxqbaUDju.Dispose();
				}
			}
		}

		private readonly IList<ActionElementMap> yjmmfCDqEaKeMMIDUJBbsATRaSyk;

		private readonly ReadOnlyCollection<ActionElementMap> VMbXcFzbjjHgtFkiskAQletvSmHS;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
				{
					return 0;
				}
				return yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return VMbXcFzbjjHgtFkiskAQletvSmHS;
			}
		}

		internal AList<ActionElementMap> AxisMaps_orig => (AList<ActionElementMap>)yjmmfCDqEaKeMMIDUJBbsATRaSyk;

		public ControllerMapWithAxes()
		{
			yjmmfCDqEaKeMMIDUJBbsATRaSyk = new AList<ActionElementMap>();
			VMbXcFzbjjHgtFkiskAQletvSmHS = new ReadOnlyCollection<ActionElementMap>(yjmmfCDqEaKeMMIDUJBbsATRaSyk);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes controllerMap)
			: base(controllerMap)
		{
			yjmmfCDqEaKeMMIDUJBbsATRaSyk = new AList<ActionElementMap>();
			VMbXcFzbjjHgtFkiskAQletvSmHS = new ReadOnlyCollection<ActionElementMap>(yjmmfCDqEaKeMMIDUJBbsATRaSyk);
			if (controllerMap.yjmmfCDqEaKeMMIDUJBbsATRaSyk != null)
			{
				int count = controllerMap.yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
				for (int i = 0; i < count; i++)
				{
					mmowRhqGFKVMIfhzaakXWIncAoQJ(new ActionElementMap(controllerMap.yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return false;
			}
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			mmowRhqGFKVMIfhzaakXWIncAoQJ(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				mmowRhqGFKVMIfhzaakXWIncAoQJ(elementMap);
			}
			int num = abxoDchDKmHenQKTsvwlmUSSena(elementMapId);
			if (num < 0)
			{
				return false;
			}
			ControllerMap.xavLFwNGgnystCpMvRrUZkwBdDN(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = abxoDchDKmHenQKTsvwlmUSSena(elementMapId);
			if (num < 0)
			{
				return false;
			}
			OvRQStTtCArcshKSBOCxHBnzIlc(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			bool flag = base.DeleteElementMapsWithAction(actionId);
			return flag | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return null;
			}
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].fOjavGziuUSawAgvwyVARpyRBVx == elementMapId)
				{
					return yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal override ActionElementMap tkbOsnEinwJolGhAcigCQSujOaY(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.tkbOsnEinwJolGhAcigCQSujOaY(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return FSloPtfCNoajxyQvdqCCAilkhoeC(P_0, P_1);
		}

		internal override int FzAoneEcjVkDwjvpVtbpkwMdHpc(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.FzAoneEcjVkDwjvpVtbpkwMdHpc(P_0, P_1, P_2, P_3);
			return num + NSrRGBjxWThzMAfobEiogPxcHfJ(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			base.ClearElementMaps();
			yjmmfCDqEaKeMMIDUJBbsATRaSyk.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null || index < 0 || index >= yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count)
			{
				return null;
			}
			return yjmmfCDqEaKeMMIDUJBbsATRaSyk[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(yjmmfCDqEaKeMMIDUJBbsATRaSyk);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return xHnlSEatYPgQtAWIPjswYiOjOTH(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.DKnkpbidVxizCMbIYGpxrzjWVmZ(actionName, true);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.DKnkpbidVxizCMbIYGpxrzjWVmZ(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
				ActionElementMap actionElementMap2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			InputAction inputAction = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.DKnkpbidVxizCMbIYGpxrzjWVmZ(actionName, true);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			InputAction inputAction = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.DKnkpbidVxizCMbIYGpxrzjWVmZ(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return sFdBVmMweZKXvEzmlpUDCazVAiQ(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			hECOiMkzDyfICvsfOxevadOthIF hECOiMkzDyfICvsfOxevadOthIF2 = new hECOiMkzDyfICvsfOxevadOthIF(-2);
			hECOiMkzDyfICvsfOxevadOthIF2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			hECOiMkzDyfICvsfOxevadOthIF2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
			hECOiMkzDyfICvsfOxevadOthIF2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return hECOiMkzDyfICvsfOxevadOthIF2;
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return FSloPtfCNoajxyQvdqCCAilkhoeC(predicate, false);
		}

		internal ActionElementMap FSloPtfCNoajxyQvdqCCAilkhoeC(Predicate<ActionElementMap> P_0, bool P_1)
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return NSrRGBjxWThzMAfobEiogPxcHfJ(predicate, false, results, false);
		}

		internal int NSrRGBjxWThzMAfobEiogPxcHfJ(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
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
			return DeleteAxisMapsWithAction(ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[num2] != null && yjmmfCDqEaKeMMIDUJBbsATRaSyk[num2]._actionId == actionId)
				{
					OvRQStTtCArcshKSBOCxHBnzIlc(yjmmfCDqEaKeMMIDUJBbsATRaSyk[num2].fOjavGziuUSawAgvwyVARpyRBVx, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int num = 0;
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF != state)
				{
					actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (skipDisabledMaps && !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
			{
				return false;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return false;
			}
			for (int i = 0; i < yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count; i++)
			{
				ActionElementMap actionElementMap2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if ((!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			oKDFQgGMSFUxWLvbgBqBZFhjkGDN oKDFQgGMSFUxWLvbgBqBZFhjkGDN2 = new oKDFQgGMSFUxWLvbgBqBZFhjkGDN(-2);
			oKDFQgGMSFUxWLvbgBqBZFhjkGDN2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			oKDFQgGMSFUxWLvbgBqBZFhjkGDN2.UkPuziaGThQCqHJbVOTnNlEiKOt = controllerMap;
			oKDFQgGMSFUxWLvbgBqBZFhjkGDN2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return oKDFQgGMSFUxWLvbgBqBZFhjkGDN2;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			iVasudWhhomSgTnegnSinaeejyy iVasudWhhomSgTnegnSinaeejyy2 = new iVasudWhhomSgTnegnSinaeejyy(-2);
			iVasudWhhomSgTnegnSinaeejyy2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			iVasudWhhomSgTnegnSinaeejyy2.ILxNeiUFNlXBMCfWlwycEgXzexcE = actionElementMap;
			iVasudWhhomSgTnegnSinaeejyy2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return iVasudWhhomSgTnegnSinaeejyy2;
		}

		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			TFZIjnEcnCZmFrAcerZcVjjPRAFL tFZIjnEcnCZmFrAcerZcVjjPRAFL = new TFZIjnEcnCZmFrAcerZcVjjPRAFL(-2);
			tFZIjnEcnCZmFrAcerZcVjjPRAFL.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			tFZIjnEcnCZmFrAcerZcVjjPRAFL.zOaFzOkpHDjDdAUAbeoShTwGIGW = conflictCheck;
			tFZIjnEcnCZmFrAcerZcVjjPRAFL.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return tFZIjnEcnCZmFrAcerZcVjjPRAFL;
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
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
			_ = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			int count = axisMaps.Count;
			for (int num2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[num2];
				if (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							OvRQStTtCArcshKSBOCxHBnzIlc(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx, num2);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return num;
			}
			for (int num2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk[num2];
				if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					OvRQStTtCArcshKSBOCxHBnzIlc(actionElementMap2.fOjavGziuUSawAgvwyVARpyRBVx, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
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
			for (int num2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[num2];
				if ((!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					OvRQStTtCArcshKSBOCxHBnzIlc(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx, num2);
					num++;
				}
			}
			return num;
		}

		internal override int UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
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
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (!actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal override int UGqGgetPHsxNPYgSqVMUrunQPoY(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override int UGqGgetPHsxNPYgSqVMUrunQPoY(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
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
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				array[i] = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].elementIdentifierName;
			}
			return array;
		}

		internal override bool CopwiDtmNQYJDxydZiwAXLfuDcb(ActionElementMap P_0)
		{
			if (base.CopwiDtmNQYJDxydZiwAXLfuDcb(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementType))
			{
				return false;
			}
			mmowRhqGFKVMIfhzaakXWIncAoQJ(P_0);
			return true;
		}

		internal override int bZzFKiYesKDpdKuYgPjDSUSHvvYE(List<ActionElementMap> P_0, bool P_1)
		{
			base.bZzFKiYesKDpdKuYgPjDSUSHvvYE(P_0, P_1);
			int count = P_0.Count;
			int count2 = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					P_0.Add(yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]);
				}
			}
			return P_0.Count - count;
		}

		internal override ActionElementMap OEEXiRZgUmNAmcZjKOEgqtSQHfU(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.OEEXiRZgUmNAmcZjKOEgqtSQHfU(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_2))
			{
				return null;
			}
			int num = OWJIOjZyBJlqXiyCHOXEfHdflhC(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return yjmmfCDqEaKeMMIDUJBbsATRaSyk[num];
			}
			throw new NotImplementedException();
		}

		internal override int rUsNUewZlIBApQhnyPUZihAjfEEJ(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.rUsNUewZlIBApQhnyPUZihAjfEEJ(P_0, P_1, P_2);
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return P_1.Count - num;
			}
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._elementIdentifierId == P_0)
				{
					P_1.Add(yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]);
				}
			}
			return P_1.Count - num;
		}

		internal override bool hCMxapJcJIFqEfPfsHYAZdZWGUrw(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.hCMxapJcJIFqEfPfsHYAZdZWGUrw(P_0, P_1, P_2))
			{
				return true;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
				for (int i = 0; i < count; i++)
				{
					if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._elementIdentifierId == P_0 && yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal override int OWJIOjZyBJlqXiyCHOXEfHdflhC(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.OWJIOjZyBJlqXiyCHOXEfHdflhC(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_2))
			{
				return -1;
			}
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
				for (int i = 0; i < count; i++)
				{
					if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._elementIdentifierId == P_0 && yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int abxoDchDKmHenQKTsvwlmUSSena(int P_0)
		{
			if (yjmmfCDqEaKeMMIDUJBbsATRaSyk == null)
			{
				return -1;
			}
			int count = yjmmfCDqEaKeMMIDUJBbsATRaSyk.Count;
			for (int i = 0; i < count; i++)
			{
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].fOjavGziuUSawAgvwyVARpyRBVx == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int xHnlSEatYPgQtAWIPjswYiOjOTH(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (!P_0 || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int sFdBVmMweZKXvEzmlpUDCazVAiQ(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal override int BGvXRGFtRGxLCvjTaLltejGrgpZ(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.BGvXRGFtRGxLCvjTaLltejGrgpZ(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal override ActionElementMap xeXzPaMQfzAZhpljIAZYHvYxvpQJ(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.xeXzPaMQfzAZhpljIAZYHvYxvpQJ(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._actionId == P_2) && (!P_3 || yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF) && yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].IsTarget(P_0))
				{
					return yjmmfCDqEaKeMMIDUJBbsATRaSyk[i];
				}
			}
			return null;
		}

		internal override int dyceDrFMqmHuFuGxjUooOwevmZT(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.dyceDrFMqmHuFuGxjUooOwevmZT(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]._actionId == P_2) && (!P_3 || yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF) && yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].IsTarget(P_0))
				{
					P_4.Add(yjmmfCDqEaKeMMIDUJBbsATRaSyk[i]);
					num++;
				}
			}
			return num;
		}

		internal override bool anZEgqJfCTCyftlbtfLdZXMDqwn(ActionElementMap P_0)
		{
			if (base.anZEgqJfCTCyftlbtfLdZXMDqwn(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0._elementType))
			{
				return false;
			}
			yjmmfCDqEaKeMMIDUJBbsATRaSyk.Add(P_0);
			FRQTqkDwWpdWKHBMBoaWjwrcTpS(P_0);
			return true;
		}

		private bool RusVKQCzlApIiEmCwyIHRrBWWao(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void OvRQStTtCArcshKSBOCxHBnzIlc(int P_0, int P_1)
		{
			VVHSvWBKzFMzSNTHJDxASXBfVeB(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				yjmmfCDqEaKeMMIDUJBbsATRaSyk.RemoveAt(P_1);
			}
		}

		private void mmowRhqGFKVMIfhzaakXWIncAoQJ(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				yjmmfCDqEaKeMMIDUJBbsATRaSyk.Add(P_0);
				FRQTqkDwWpdWKHBMBoaWjwrcTpS(P_0);
			}
		}

		private void jqyQDcgYveKMUZwUdmtMeqgSTVa(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				UeiQUagpwSRKTbdvvZBQKnDtdIy(yjmmfCDqEaKeMMIDUJBbsATRaSyk[P_1].fOjavGziuUSawAgvwyVARpyRBVx, P_0);
				yjmmfCDqEaKeMMIDUJBbsATRaSyk[P_1] = P_0;
			}
		}

		internal override void ZpEgvAefsRlDDfhUwpzFAUZSfaaq(SerializedObject P_0)
		{
			base.ZpEgvAefsRlDDfhUwpzFAUZSfaaq(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (yjmmfCDqEaKeMMIDUJBbsATRaSyk[i] != null)
				{
					list.Add(yjmmfCDqEaKeMMIDUJBbsATRaSyk[i].qnRcKibdUQgUDehMYaMNRcmEEUp());
				}
			}
		}

		internal override bool JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
		{
			bool flag = base.JYyEPkmZztzXfbEgKghAFieAytO(P_0);
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
						actionElementMap.JYyEPkmZztzXfbEgKghAFieAytO(value2);
						if (ActionElementMap.zEsjsITBQsNpTxgsSdFrSEugfDhD(actionElementMap))
						{
							mmowRhqGFKVMIfhzaakXWIncAoQJ(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> ycRTliCKqgARkeGbHIgRDUHDMnMl(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> HsFYDOlDBvqIkSiUWUKJyvlqRHa(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> ZumTaPiqTIkUCSqExCDNeoIUIDGb(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
