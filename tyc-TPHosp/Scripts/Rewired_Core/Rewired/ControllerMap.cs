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
		private class FYXVgMkJvnfHwzoCUNjmsPnpVDQ : IComparer<ActionElementMap>
		{
			public static FYXVgMkJvnfHwzoCUNjmsPnpVDQ NsGEioaOmaBNobdbukRVCkFCuYKO;

			public static FYXVgMkJvnfHwzoCUNjmsPnpVDQ Default => NsGEioaOmaBNobdbukRVCkFCuYKO ?? (NsGEioaOmaBNobdbukRVCkFCuYKO = new FYXVgMkJvnfHwzoCUNjmsPnpVDQ());

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

		private sealed class ruNbiMgfvckviAJXfuwioEiFpOFm : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

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
				ruNbiMgfvckviAJXfuwioEiFpOFm ruNbiMgfvckviAJXfuwioEiFpOFm2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					ruNbiMgfvckviAJXfuwioEiFpOFm2 = this;
				}
				else
				{
					ruNbiMgfvckviAJXfuwioEiFpOFm2 = new ruNbiMgfvckviAJXfuwioEiFpOFm(0);
					ruNbiMgfvckviAJXfuwioEiFpOFm2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				ruNbiMgfvckviAJXfuwioEiFpOFm2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
				ruNbiMgfvckviAJXfuwioEiFpOFm2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return ruNbiMgfvckviAJXfuwioEiFpOFm2;
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
						UyWmoWtlJwLLruFuHqmnZhGlapc = kdBZqupjvsCsVkwJiOeEQzkEDVO.AllMaps.GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00c3;
					case 2:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_00c3;
						}
						IL_00c3:
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
			public ruNbiMgfvckviAJXfuwioEiFpOFm(int _003C_003E1__state)
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

		private sealed class nmfesRNMMwacrupSEhhmXrFDWzo : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public IControllerElementTarget TEgEOzuJcAYDKPcYtMGbGLlSEyn;

			public IControllerElementTarget jcELyNXpDJBwHWlzxALZjKPhJZo;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public TempListPool.TList<ActionElementMap> cGsPCusfDyzwyAnhQoeBlsmtFlc;

			public List<ActionElementMap> FnlyCuDggOYgyJrywTFkCOBgUXw;

			public bool CHKWgyNNAgCxAXxaddtBTLWoNGx;

			public ActionElementMap GZipKvIgJodSRBWJQkPcFfymEru;

			public List<ActionElementMap>.Enumerator gTPskKFEgvCgCKJBBBHDHsAzrPY;

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
				nmfesRNMMwacrupSEhhmXrFDWzo nmfesRNMMwacrupSEhhmXrFDWzo2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					nmfesRNMMwacrupSEhhmXrFDWzo2 = this;
				}
				else
				{
					nmfesRNMMwacrupSEhhmXrFDWzo2 = new nmfesRNMMwacrupSEhhmXrFDWzo(0);
					nmfesRNMMwacrupSEhhmXrFDWzo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				nmfesRNMMwacrupSEhhmXrFDWzo2.TEgEOzuJcAYDKPcYtMGbGLlSEyn = jcELyNXpDJBwHWlzxALZjKPhJZo;
				nmfesRNMMwacrupSEhhmXrFDWzo2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return nmfesRNMMwacrupSEhhmXrFDWzo2;
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
					int num = uoxvBdjXZPeiUprcFCMcTbYvPLr;
					if (num != 0)
					{
						if (num == 3)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							goto IL_00d9;
						}
					}
					else
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id == kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							cGsPCusfDyzwyAnhQoeBlsmtFlc = TempListPool.GetTList<ActionElementMap>();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							FnlyCuDggOYgyJrywTFkCOBgUXw = cGsPCusfDyzwyAnhQoeBlsmtFlc.list;
							kdBZqupjvsCsVkwJiOeEQzkEDVO.dyceDrFMqmHuFuGxjUooOwevmZT(TEgEOzuJcAYDKPcYtMGbGLlSEyn, false, -1, sBBuxyRWJQpBnxBQfhNyotyrnMk, FnlyCuDggOYgyJrywTFkCOBgUXw, false, out CHKWgyNNAgCxAXxaddtBTLWoNGx);
							gTPskKFEgvCgCKJBBBHDHsAzrPY = FnlyCuDggOYgyJrywTFkCOBgUXw.GetEnumerator();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							goto IL_00d9;
						}
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					goto IL_00f2;
					IL_00d9:
					if (gTPskKFEgvCgCKJBBBHDHsAzrPY.MoveNext())
					{
						GZipKvIgJodSRBWJQkPcFfymEru = gTPskKFEgvCgCKJBBBHDHsAzrPY.Current;
						ajbaQItphrIyqhowgmMTfPkCBvcN = GZipKvIgJodSRBWJQkPcFfymEru;
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
						return true;
					}
					gBpYpEqVjAjrENgNTDssbFxbCcp();
					JSHtgiTOxsJcwvVHsjgiwBDzcYf();
					goto IL_00f2;
					IL_00f2:
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
				case 3:
					try
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								gBpYpEqVjAjrENgNTDssbFxbCcp();
							}
						}
						break;
					}
					finally
					{
						JSHtgiTOxsJcwvVHsjgiwBDzcYf();
					}
				}
			}

			[DebuggerHidden]
			public nmfesRNMMwacrupSEhhmXrFDWzo(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void JSHtgiTOxsJcwvVHsjgiwBDzcYf()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (cGsPCusfDyzwyAnhQoeBlsmtFlc != null)
				{
					((IDisposable)cGsPCusfDyzwyAnhQoeBlsmtFlc).Dispose();
				}
			}

			private void gBpYpEqVjAjrENgNTDssbFxbCcp()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
				((IDisposable)gTPskKFEgvCgCKJBBBHDHsAzrPY/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class faMGDxgZAywDZNwsqOehjwdQZgQ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public IControllerElementTarget TEgEOzuJcAYDKPcYtMGbGLlSEyn;

			public IControllerElementTarget jcELyNXpDJBwHWlzxALZjKPhJZo;

			public int KjaWgObGREamoandMdAXxTdnHIgu;

			public int YOXLccoEMCTpcLNYciWfwMnsHwE;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public TempListPool.TList<ActionElementMap> vJWjckzuRrkNKVxIwAYDUesGMRh;

			public List<ActionElementMap> SyaznJRCbEQbZijHSdBBpCgVQTK;

			public bool GQweEhUTQWgCdusMWgQwNtvKkrR;

			public ActionElementMap sJJFmGAEmsdsPGSvttjONEwLGZdV;

			public List<ActionElementMap>.Enumerator dAtZPMRFQDGaLHxWSaQYokFcMtTE;

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
				faMGDxgZAywDZNwsqOehjwdQZgQ faMGDxgZAywDZNwsqOehjwdQZgQ2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					faMGDxgZAywDZNwsqOehjwdQZgQ2 = this;
				}
				else
				{
					faMGDxgZAywDZNwsqOehjwdQZgQ2 = new faMGDxgZAywDZNwsqOehjwdQZgQ(0);
					faMGDxgZAywDZNwsqOehjwdQZgQ2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				faMGDxgZAywDZNwsqOehjwdQZgQ2.TEgEOzuJcAYDKPcYtMGbGLlSEyn = jcELyNXpDJBwHWlzxALZjKPhJZo;
				faMGDxgZAywDZNwsqOehjwdQZgQ2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
				faMGDxgZAywDZNwsqOehjwdQZgQ2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return faMGDxgZAywDZNwsqOehjwdQZgQ2;
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
					int num = uoxvBdjXZPeiUprcFCMcTbYvPLr;
					if (num != 0)
					{
						if (num == 3)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							goto IL_00de;
						}
					}
					else
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id == kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							vJWjckzuRrkNKVxIwAYDUesGMRh = TempListPool.GetTList<ActionElementMap>();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							SyaznJRCbEQbZijHSdBBpCgVQTK = vJWjckzuRrkNKVxIwAYDUesGMRh.list;
							kdBZqupjvsCsVkwJiOeEQzkEDVO.dyceDrFMqmHuFuGxjUooOwevmZT(TEgEOzuJcAYDKPcYtMGbGLlSEyn, true, KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk, SyaznJRCbEQbZijHSdBBpCgVQTK, false, out GQweEhUTQWgCdusMWgQwNtvKkrR);
							dAtZPMRFQDGaLHxWSaQYokFcMtTE = SyaznJRCbEQbZijHSdBBpCgVQTK.GetEnumerator();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							goto IL_00de;
						}
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					goto IL_00f7;
					IL_00de:
					if (dAtZPMRFQDGaLHxWSaQYokFcMtTE.MoveNext())
					{
						sJJFmGAEmsdsPGSvttjONEwLGZdV = dAtZPMRFQDGaLHxWSaQYokFcMtTE.Current;
						ajbaQItphrIyqhowgmMTfPkCBvcN = sJJFmGAEmsdsPGSvttjONEwLGZdV;
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
						return true;
					}
					xwUrjWZICvJtXKWahkQxgCdkqkb();
					AUIxGHFyyJYILDIZhAukrtilAml();
					goto IL_00f7;
					IL_00f7:
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
				case 3:
					try
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								xwUrjWZICvJtXKWahkQxgCdkqkb();
							}
						}
						break;
					}
					finally
					{
						AUIxGHFyyJYILDIZhAukrtilAml();
					}
				}
			}

			[DebuggerHidden]
			public faMGDxgZAywDZNwsqOehjwdQZgQ(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void AUIxGHFyyJYILDIZhAukrtilAml()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (vJWjckzuRrkNKVxIwAYDUesGMRh != null)
				{
					((IDisposable)vJWjckzuRrkNKVxIwAYDUesGMRh).Dispose();
				}
			}

			private void xwUrjWZICvJtXKWahkQxgCdkqkb()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
				((IDisposable)dAtZPMRFQDGaLHxWSaQYokFcMtTE/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class pzIgUUqGaMeKGbkvuXiKWrgXVaf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int KjaWgObGREamoandMdAXxTdnHIgu;

			public int YOXLccoEMCTpcLNYciWfwMnsHwE;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public IList<ActionElementMap> cgpcuPbrscKGovpXvjakUDFzHLxG;

			public int sjaBOLEDCJZGEqMmnJJfuLLPzich;

			public int IBBvFPBAeHgkACAzjHjXyMAdXvK;

			public ActionElementMap MLJWecTEXLaMqrOeafNUxBWAqRI;

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
				pzIgUUqGaMeKGbkvuXiKWrgXVaf pzIgUUqGaMeKGbkvuXiKWrgXVaf2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					pzIgUUqGaMeKGbkvuXiKWrgXVaf2 = this;
				}
				else
				{
					pzIgUUqGaMeKGbkvuXiKWrgXVaf2 = new pzIgUUqGaMeKGbkvuXiKWrgXVaf(0);
					pzIgUUqGaMeKGbkvuXiKWrgXVaf2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				pzIgUUqGaMeKGbkvuXiKWrgXVaf2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
				pzIgUUqGaMeKGbkvuXiKWrgXVaf2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return pzIgUUqGaMeKGbkvuXiKWrgXVaf2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
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
					cgpcuPbrscKGovpXvjakUDFzHLxG = kdBZqupjvsCsVkwJiOeEQzkEDVO.ButtonMaps;
					sjaBOLEDCJZGEqMmnJJfuLLPzich = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttonMapCount;
					IBBvFPBAeHgkACAzjHjXyMAdXvK = 0;
					goto IL_00e9;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00db;
					}
					IL_00db:
					IBBvFPBAeHgkACAzjHjXyMAdXvK++;
					goto IL_00e9;
					IL_00e9:
					if (IBBvFPBAeHgkACAzjHjXyMAdXvK >= sjaBOLEDCJZGEqMmnJJfuLLPzich)
					{
						break;
					}
					MLJWecTEXLaMqrOeafNUxBWAqRI = cgpcuPbrscKGovpXvjakUDFzHLxG[IBBvFPBAeHgkACAzjHjXyMAdXvK];
					if (MLJWecTEXLaMqrOeafNUxBWAqRI._actionId == KjaWgObGREamoandMdAXxTdnHIgu && (!sBBuxyRWJQpBnxBQfhNyotyrnMk || MLJWecTEXLaMqrOeafNUxBWAqRI.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = MLJWecTEXLaMqrOeafNUxBWAqRI;
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00db;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public pzIgUUqGaMeKGbkvuXiKWrgXVaf(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class TXPpuKwRLsdXtUTfKPEvnPKDxKP : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ControllerMap XKsXMwpOxrVrFXsnXueqVpKoaEV;

			public ControllerMap UkPuziaGThQCqHJbVOTnNlEiKOt;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public IList<ActionElementMap> CYaAmhmhBXjuzQYqcVXLPbMMaAl;

			public int npdDhckDhdGqIHhInTWspfuxfnw;

			public int VyWsYHnFVhFJuuNgIdqrSklZAim;

			public ActionElementMap efbLBFORGyPcyOmKleTnmOmIdok;

			public int wjtPkFbTUrkhPScKaSZNwiqdYte;

			public ActionElementMap iEXRnSIjzxaruKVvGVicKSeGcCai;

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
				TXPpuKwRLsdXtUTfKPEvnPKDxKP tXPpuKwRLsdXtUTfKPEvnPKDxKP;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					tXPpuKwRLsdXtUTfKPEvnPKDxKP = this;
				}
				else
				{
					tXPpuKwRLsdXtUTfKPEvnPKDxKP = new TXPpuKwRLsdXtUTfKPEvnPKDxKP(0);
					tXPpuKwRLsdXtUTfKPEvnPKDxKP.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				tXPpuKwRLsdXtUTfKPEvnPKDxKP.XKsXMwpOxrVrFXsnXueqVpKoaEV = UkPuziaGThQCqHJbVOTnNlEiKOt;
				tXPpuKwRLsdXtUTfKPEvnPKDxKP.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return tXPpuKwRLsdXtUTfKPEvnPKDxKP;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
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
					if (XKsXMwpOxrVrFXsnXueqVpKoaEV == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH == null || (sBBuxyRWJQpBnxBQfhNyotyrnMk && (!kdBZqupjvsCsVkwJiOeEQzkEDVO._enabled || !XKsXMwpOxrVrFXsnXueqVpKoaEV._enabled)))
					{
						break;
					}
					CYaAmhmhBXjuzQYqcVXLPbMMaAl = XKsXMwpOxrVrFXsnXueqVpKoaEV.ButtonMaps;
					if (CYaAmhmhBXjuzQYqcVXLPbMMaAl == null)
					{
						break;
					}
					npdDhckDhdGqIHhInTWspfuxfnw = CYaAmhmhBXjuzQYqcVXLPbMMaAl.Count;
					VyWsYHnFVhFJuuNgIdqrSklZAim = 0;
					goto IL_0211;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_01e4;
					}
					IL_01f2:
					if (wjtPkFbTUrkhPScKaSZNwiqdYte < npdDhckDhdGqIHhInTWspfuxfnw)
					{
						iEXRnSIjzxaruKVvGVicKSeGcCai = CYaAmhmhBXjuzQYqcVXLPbMMaAl[wjtPkFbTUrkhPScKaSZNwiqdYte];
						if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || iEXRnSIjzxaruKVvGVicKSeGcCai.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && efbLBFORGyPcyOmKleTnmOmIdok.CheckForAssignmentConflict(iEXRnSIjzxaruKVvGVicKSeGcCai))
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(kdBZqupjvsCsVkwJiOeEQzkEDVO._categoryId).userAssignable, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerType, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerId, kdBZqupjvsCsVkwJiOeEQzkEDVO._id, efbLBFORGyPcyOmKleTnmOmIdok.fOjavGziuUSawAgvwyVARpyRBVx, efbLBFORGyPcyOmKleTnmOmIdok._actionId, efbLBFORGyPcyOmKleTnmOmIdok._elementType, efbLBFORGyPcyOmKleTnmOmIdok._elementIdentifierId, efbLBFORGyPcyOmKleTnmOmIdok.keyCode, efbLBFORGyPcyOmKleTnmOmIdok.modifierKeyFlags);
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							return true;
						}
						goto IL_01e4;
					}
					goto IL_0203;
					IL_01e4:
					wjtPkFbTUrkhPScKaSZNwiqdYte++;
					goto IL_01f2;
					IL_0211:
					if (VyWsYHnFVhFJuuNgIdqrSklZAim >= kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH.Count)
					{
						break;
					}
					efbLBFORGyPcyOmKleTnmOmIdok = kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH[VyWsYHnFVhFJuuNgIdqrSklZAim];
					if (!sBBuxyRWJQpBnxBQfhNyotyrnMk || efbLBFORGyPcyOmKleTnmOmIdok.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
					{
						wjtPkFbTUrkhPScKaSZNwiqdYte = 0;
						goto IL_01f2;
					}
					goto IL_0203;
					IL_0203:
					VyWsYHnFVhFJuuNgIdqrSklZAim++;
					goto IL_0211;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public TXPpuKwRLsdXtUTfKPEvnPKDxKP(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class edBFagIzYUVmMXhbysXGQbeQlzw : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ActionElementMap laNInwdlemPELucvBOGimoeNQfc;

			public ActionElementMap ILxNeiUFNlXBMCfWlwycEgXzexcE;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public int lmOEMuLNiatSgFVBPaqYiOEGKtx;

			public ActionElementMap CAMntpSCIUaaNYCQzLlCbLajUaE;

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
				edBFagIzYUVmMXhbysXGQbeQlzw edBFagIzYUVmMXhbysXGQbeQlzw2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					edBFagIzYUVmMXhbysXGQbeQlzw2 = this;
				}
				else
				{
					edBFagIzYUVmMXhbysXGQbeQlzw2 = new edBFagIzYUVmMXhbysXGQbeQlzw(0);
					edBFagIzYUVmMXhbysXGQbeQlzw2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				edBFagIzYUVmMXhbysXGQbeQlzw2.laNInwdlemPELucvBOGimoeNQfc = ILxNeiUFNlXBMCfWlwycEgXzexcE;
				edBFagIzYUVmMXhbysXGQbeQlzw2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return edBFagIzYUVmMXhbysXGQbeQlzw2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
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
					if (laNInwdlemPELucvBOGimoeNQfc == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH == null || (sBBuxyRWJQpBnxBQfhNyotyrnMk && (!kdBZqupjvsCsVkwJiOeEQzkEDVO._enabled || !laNInwdlemPELucvBOGimoeNQfc.TAiAzEAcNOkrpYWJEmhYYqnFvpF)))
					{
						break;
					}
					lmOEMuLNiatSgFVBPaqYiOEGKtx = 0;
					goto IL_018a;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_017c;
					}
					IL_018a:
					if (lmOEMuLNiatSgFVBPaqYiOEGKtx >= kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH.Count)
					{
						break;
					}
					CAMntpSCIUaaNYCQzLlCbLajUaE = kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH[lmOEMuLNiatSgFVBPaqYiOEGKtx];
					if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || CAMntpSCIUaaNYCQzLlCbLajUaE.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && CAMntpSCIUaaNYCQzLlCbLajUaE.CheckForAssignmentConflict(laNInwdlemPELucvBOGimoeNQfc))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(kdBZqupjvsCsVkwJiOeEQzkEDVO._categoryId).userAssignable, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerType, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerId, kdBZqupjvsCsVkwJiOeEQzkEDVO._id, CAMntpSCIUaaNYCQzLlCbLajUaE.fOjavGziuUSawAgvwyVARpyRBVx, CAMntpSCIUaaNYCQzLlCbLajUaE._actionId, CAMntpSCIUaaNYCQzLlCbLajUaE._elementType, CAMntpSCIUaaNYCQzLlCbLajUaE._elementIdentifierId, CAMntpSCIUaaNYCQzLlCbLajUaE.keyCode, CAMntpSCIUaaNYCQzLlCbLajUaE.modifierKeyFlags);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_017c;
					IL_017c:
					lmOEMuLNiatSgFVBPaqYiOEGKtx++;
					goto IL_018a;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public edBFagIzYUVmMXhbysXGQbeQlzw(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class fbHbvpJgEpgLzHLgsFUaFLuxbvTP : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

			public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

			public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

			public bool jujLEVfWMealwLetaGacIFFBsHPi;

			public ElementAssignment baCBNukmdBdvQtHeLIRJpDIEvJUO;

			public int GrBTYFWJFSJqTqYSfeeMdOfIaUn;

			public ActionElementMap SkXPiIVVHDhCrAGIdDPsHGwQsXu;

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
				fbHbvpJgEpgLzHLgsFUaFLuxbvTP fbHbvpJgEpgLzHLgsFUaFLuxbvTP2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					fbHbvpJgEpgLzHLgsFUaFLuxbvTP2 = this;
				}
				else
				{
					fbHbvpJgEpgLzHLgsFUaFLuxbvTP2 = new fbHbvpJgEpgLzHLgsFUaFLuxbvTP(0);
					fbHbvpJgEpgLzHLgsFUaFLuxbvTP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				fbHbvpJgEpgLzHLgsFUaFLuxbvTP2.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
				fbHbvpJgEpgLzHLgsFUaFLuxbvTP2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
				return fbHbvpJgEpgLzHLgsFUaFLuxbvTP2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
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
					if ((sBBuxyRWJQpBnxBQfhNyotyrnMk && !kdBZqupjvsCsVkwJiOeEQzkEDVO._enabled) || kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH == null)
					{
						break;
					}
					baCBNukmdBdvQtHeLIRJpDIEvJUO = sADsWDUCiahlWYuuUKwcFHVfnhS.ToElementAssignment();
					GrBTYFWJFSJqTqYSfeeMdOfIaUn = 0;
					goto IL_019b;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_018d;
					}
					IL_019b:
					if (GrBTYFWJFSJqTqYSfeeMdOfIaUn >= kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH.Count)
					{
						break;
					}
					SkXPiIVVHDhCrAGIdDPsHGwQsXu = kdBZqupjvsCsVkwJiOeEQzkEDVO.eofklWOcrGncqJqATGOwKrseWjH[GrBTYFWJFSJqTqYSfeeMdOfIaUn];
					if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || SkXPiIVVHDhCrAGIdDPsHGwQsXu.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && SkXPiIVVHDhCrAGIdDPsHGwQsXu.fOjavGziuUSawAgvwyVARpyRBVx != sADsWDUCiahlWYuuUKwcFHVfnhS.elementMapId && SkXPiIVVHDhCrAGIdDPsHGwQsXu.CheckForAssignmentConflict(baCBNukmdBdvQtHeLIRJpDIEvJUO))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(kdBZqupjvsCsVkwJiOeEQzkEDVO._categoryId).userAssignable, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerType, kdBZqupjvsCsVkwJiOeEQzkEDVO._controllerId, kdBZqupjvsCsVkwJiOeEQzkEDVO._id, SkXPiIVVHDhCrAGIdDPsHGwQsXu.fOjavGziuUSawAgvwyVARpyRBVx, SkXPiIVVHDhCrAGIdDPsHGwQsXu._actionId, SkXPiIVVHDhCrAGIdDPsHGwQsXu._elementType, SkXPiIVVHDhCrAGIdDPsHGwQsXu._elementIdentifierId, SkXPiIVVHDhCrAGIdDPsHGwQsXu.keyCode, SkXPiIVVHDhCrAGIdDPsHGwQsXu.modifierKeyFlags);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_018d;
					IL_018d:
					GrBTYFWJFSJqTqYSfeeMdOfIaUn++;
					goto IL_019b;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public fbHbvpJgEpgLzHLgsFUaFLuxbvTP(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		private readonly AList<ActionElementMap> eofklWOcrGncqJqATGOwKrseWjH;

		private readonly ReadOnlyCollection<ActionElementMap> sWMtAXPzpWQmFLDSXdyXfydBzui;

		private readonly AList<ActionElementMap> BNlfWTDKHiJuxUqqXOBJLtGNIzLU;

		private readonly ReadOnlyCollection<ActionElementMap> PKjOwntjwhNkYiSFwbeGFjSltcj;

		protected int _playerId;

		protected int _controllerId;

		protected ControllerType _controllerType;

		private static int sYQDDvhCnrKSolgzMUaGKhazgWJx;

		private static int nextUid
		{
			get
			{
				int result = sYQDDvhCnrKSolgzMUaGKhazgWJx;
				if (sYQDDvhCnrKSolgzMUaGKhazgWJx == int.MaxValue)
				{
					sYQDDvhCnrKSolgzMUaGKhazgWJx = 0;
				}
				else
				{
					sYQDDvhCnrKSolgzMUaGKhazgWJx++;
				}
				return result;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = value;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = value;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = value;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return _playerId;
			}
			internal set
			{
				_playerId = value;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = value;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
			internal set
			{
				_controllerType = value;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return eofklWOcrGncqJqATGOwKrseWjH.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return PKjOwntjwhNkYiSFwbeGFjSltcj;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return sWMtAXPzpWQmFLDSXdyXfydBzui;
			}
		}

		internal AList<ActionElementMap> ButtonMaps_orig => eofklWOcrGncqJqATGOwKrseWjH;

		public ControllerMap()
		{
			_id = nextUid;
			_sourceMapId = -1;
			eofklWOcrGncqJqATGOwKrseWjH = new AList<ActionElementMap>();
			sWMtAXPzpWQmFLDSXdyXfydBzui = new ReadOnlyCollection<ActionElementMap>(eofklWOcrGncqJqATGOwKrseWjH);
			BNlfWTDKHiJuxUqqXOBJLtGNIzLU = new AList<ActionElementMap>();
			PKjOwntjwhNkYiSFwbeGFjSltcj = new ReadOnlyCollection<ActionElementMap>(BNlfWTDKHiJuxUqqXOBJLtGNIzLU);
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
		}

		public ControllerMap(ControllerMap source)
			: this()
		{
			_id = nextUid;
			_sourceMapId = source._sourceMapId;
			_categoryId = source._categoryId;
			_layoutId = source._layoutId;
			_name = source._name;
			_hardwareGuid = source._hardwareGuid;
			_enabled = source._enabled;
			_playerId = source._playerId;
			_controllerId = source._controllerId;
			_controllerType = source._controllerType;
			if (source.eofklWOcrGncqJqATGOwKrseWjH != null)
			{
				int count = source.eofklWOcrGncqJqATGOwKrseWjH.Count;
				for (int i = 0; i < count; i++)
				{
					rFQKqPOFlffkfbhLogsnuAZPWyqE(new ActionElementMap(source.eofklWOcrGncqJqATGOwKrseWjH[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			InputAction inputAction = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.DKnkpbidVxizCMbIYGpxrzjWVmZ(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			AList<ActionElementMap> bNlfWTDKHiJuxUqqXOBJLtGNIzLU = BNlfWTDKHiJuxUqqXOBJLtGNIzLU;
			for (int i = 0; i < bNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count; i++)
			{
				if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			AList<ActionElementMap> bNlfWTDKHiJuxUqqXOBJLtGNIzLU = BNlfWTDKHiJuxUqqXOBJLtGNIzLU;
			for (int i = 0; i < bNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count; i++)
			{
				if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].keyCode == keyCode && BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> bNlfWTDKHiJuxUqqXOBJLtGNIzLU = BNlfWTDKHiJuxUqqXOBJLtGNIzLU;
			for (int i = 0; i < bNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count; i++)
			{
				if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].fOjavGziuUSawAgvwyVARpyRBVx == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			AList<ActionElementMap> bNlfWTDKHiJuxUqqXOBJLtGNIzLU = BNlfWTDKHiJuxUqqXOBJLtGNIzLU;
			for (int i = 0; i < bNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count; i++)
			{
				if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].fOjavGziuUSawAgvwyVARpyRBVx == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementAssignment.elementMapId);
			if (elementMap == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, bEUEMZWgpCwBXKGSoWTyQESUVD.ImSGBfeSUdhdHajXEMFVtcmiijjJ(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.sSQYMATtZixpYjjUsqaWsAupijI(this, actionElementMap);
			rFQKqPOFlffkfbhLogsnuAZPWyqE(actionElementMap);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			TwhJHDwMitMPZPGfcRtEVjrcGrF twhJHDwMitMPZPGfcRtEVjrcGrF = TwhJHDwMitMPZPGfcRtEVjrcGrF.pKxcrghASbAgdGwMKtZePMtbdORa(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, twhJHDwMitMPZPGfcRtEVjrcGrF.RCfsEFwOpxyMtsvpZivwrNvBSuI, twhJHDwMitMPZPGfcRtEVjrcGrF.oRBMwSfgfFIxuTfPcHBtCIhGdNt, twhJHDwMitMPZPGfcRtEVjrcGrF.EUzOXCQPGfeOpZnmkDNSdDouKKMo, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			rFQKqPOFlffkfbhLogsnuAZPWyqE(actionElementMap);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, bEUEMZWgpCwBXKGSoWTyQESUVD.ImSGBfeSUdhdHajXEMFVtcmiijjJ(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			int num = AavsbHLpBWnyRojIGECaSMtUjTx(elementMapId);
			if (num < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				rFQKqPOFlffkfbhLogsnuAZPWyqE(elementMap);
			}
			num = AavsbHLpBWnyRojIGECaSMtUjTx(elementMapId);
			if (num < 0)
			{
				result = null;
				return false;
			}
			elementMap.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.sSQYMATtZixpYjjUsqaWsAupijI(this, elementMap);
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
			TwhJHDwMitMPZPGfcRtEVjrcGrF twhJHDwMitMPZPGfcRtEVjrcGrF = TwhJHDwMitMPZPGfcRtEVjrcGrF.pKxcrghASbAgdGwMKtZePMtbdORa(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, twhJHDwMitMPZPGfcRtEVjrcGrF.RCfsEFwOpxyMtsvpZivwrNvBSuI, twhJHDwMitMPZPGfcRtEVjrcGrF.oRBMwSfgfFIxuTfPcHBtCIhGdNt, twhJHDwMitMPZPGfcRtEVjrcGrF.EUzOXCQPGfeOpZnmkDNSdDouKKMo, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				result = null;
				return false;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementType))
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
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				rFQKqPOFlffkfbhLogsnuAZPWyqE(elementMap);
			}
			int num = AavsbHLpBWnyRojIGECaSMtUjTx(elementMapId);
			if (num < 0)
			{
				result = null;
				return false;
			}
			xavLFwNGgnystCpMvRrUZkwBdDN(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int num = AavsbHLpBWnyRojIGECaSMtUjTx(elementMapId);
			if (num < 0)
			{
				return false;
			}
			UCiOAoEllnqiaALgrLSeIRiNfiA(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i].fOjavGziuUSawAgvwyVARpyRBVx == elementMapId)
				{
					return eofklWOcrGncqJqATGOwKrseWjH[i];
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				if (!skipDisabledMaps || allMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return bZzFKiYesKDpdKuYgPjDSUSHvvYE(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
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
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return BGvXRGFtRGxLCvjTaLltejGrgpZ(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			ruNbiMgfvckviAJXfuwioEiFpOFm ruNbiMgfvckviAJXfuwioEiFpOFm2 = new ruNbiMgfvckviAJXfuwioEiFpOFm(-2);
			ruNbiMgfvckviAJXfuwioEiFpOFm2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			ruNbiMgfvckviAJXfuwioEiFpOFm2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
			ruNbiMgfvckviAJXfuwioEiFpOFm2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return ruNbiMgfvckviAJXfuwioEiFpOFm2;
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i]._actionId == actionId && (!skipDisabledMaps || eofklWOcrGncqJqATGOwKrseWjH[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					return eofklWOcrGncqJqATGOwKrseWjH[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = BIzzMnQbYdgezaQAnFAxzmYBsLQP.mlbUbmcCGlibSeAVWGWEZZOqvxX(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(bIzzMnQbYdgezaQAnFAxzmYBsLQP, skipDisabledMaps);
			BIzzMnQbYdgezaQAnFAxzmYBsLQP.bIxblVJXTRfjDgVIYRbYhAcCoIcF(bIzzMnQbYdgezaQAnFAxzmYBsLQP);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			nmfesRNMMwacrupSEhhmXrFDWzo nmfesRNMMwacrupSEhhmXrFDWzo2 = new nmfesRNMMwacrupSEhhmXrFDWzo(-2);
			nmfesRNMMwacrupSEhhmXrFDWzo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			nmfesRNMMwacrupSEhhmXrFDWzo2.jcELyNXpDJBwHWlzxALZjKPhJZo = elementTarget;
			nmfesRNMMwacrupSEhhmXrFDWzo2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return nmfesRNMMwacrupSEhhmXrFDWzo2;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = BIzzMnQbYdgezaQAnFAxzmYBsLQP.mlbUbmcCGlibSeAVWGWEZZOqvxX(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(bIzzMnQbYdgezaQAnFAxzmYBsLQP, actionId, skipDisabledMaps);
			BIzzMnQbYdgezaQAnFAxzmYBsLQP.bIxblVJXTRfjDgVIYRbYhAcCoIcF(bIzzMnQbYdgezaQAnFAxzmYBsLQP);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			faMGDxgZAywDZNwsqOehjwdQZgQ faMGDxgZAywDZNwsqOehjwdQZgQ2 = new faMGDxgZAywDZNwsqOehjwdQZgQ(-2);
			faMGDxgZAywDZNwsqOehjwdQZgQ2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			faMGDxgZAywDZNwsqOehjwdQZgQ2.jcELyNXpDJBwHWlzxALZjKPhJZo = elementTarget;
			faMGDxgZAywDZNwsqOehjwdQZgQ2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
			faMGDxgZAywDZNwsqOehjwdQZgQ2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return faMGDxgZAywDZNwsqOehjwdQZgQ2;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = BIzzMnQbYdgezaQAnFAxzmYBsLQP.mlbUbmcCGlibSeAVWGWEZZOqvxX(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(bIzzMnQbYdgezaQAnFAxzmYBsLQP, skipDisabledMaps);
			BIzzMnQbYdgezaQAnFAxzmYBsLQP.bIxblVJXTRfjDgVIYRbYhAcCoIcF(bIzzMnQbYdgezaQAnFAxzmYBsLQP);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			bool flag;
			return xeXzPaMQfzAZhpljIAZYHvYxvpQJ(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = BIzzMnQbYdgezaQAnFAxzmYBsLQP.mlbUbmcCGlibSeAVWGWEZZOqvxX(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(bIzzMnQbYdgezaQAnFAxzmYBsLQP, actionId, skipDisabledMaps);
			BIzzMnQbYdgezaQAnFAxzmYBsLQP.bIxblVJXTRfjDgVIYRbYhAcCoIcF(bIzzMnQbYdgezaQAnFAxzmYBsLQP);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			bool flag;
			return xeXzPaMQfzAZhpljIAZYHvYxvpQJ(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = BIzzMnQbYdgezaQAnFAxzmYBsLQP.mlbUbmcCGlibSeAVWGWEZZOqvxX(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(bIzzMnQbYdgezaQAnFAxzmYBsLQP, skipDisabledMaps, results);
			BIzzMnQbYdgezaQAnFAxzmYBsLQP.bIxblVJXTRfjDgVIYRbYhAcCoIcF(bIzzMnQbYdgezaQAnFAxzmYBsLQP);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			bool flag;
			return dyceDrFMqmHuFuGxjUooOwevmZT(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = BIzzMnQbYdgezaQAnFAxzmYBsLQP.mlbUbmcCGlibSeAVWGWEZZOqvxX(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(bIzzMnQbYdgezaQAnFAxzmYBsLQP, actionId, skipDisabledMaps, results);
			BIzzMnQbYdgezaQAnFAxzmYBsLQP.bIxblVJXTRfjDgVIYRbYhAcCoIcF(bIzzMnQbYdgezaQAnFAxzmYBsLQP);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			bool flag;
			return dyceDrFMqmHuFuGxjUooOwevmZT(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return tkbOsnEinwJolGhAcigCQSujOaY(predicate, false);
		}

		internal virtual ActionElementMap tkbOsnEinwJolGhAcigCQSujOaY(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return gSnGxTxkuxpBdGjWaQyQLrTArPa(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return FzAoneEcjVkDwjvpVtbpkwMdHpc(predicate, false, results, false);
		}

		internal virtual int FzAoneEcjVkDwjvpVtbpkwMdHpc(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return WfRFdTYmjnOgTjdCYHxSGfSCYSc(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
			int count = BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i];
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			eofklWOcrGncqJqATGOwKrseWjH.Clear();
			BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int num = 0;
			int count = BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF != state)
				{
					actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (eofklWOcrGncqJqATGOwKrseWjH == null || index < 0 || index >= eofklWOcrGncqJqATGOwKrseWjH.Count)
			{
				return null;
			}
			return eofklWOcrGncqJqATGOwKrseWjH[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(eofklWOcrGncqJqATGOwKrseWjH);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = eofklWOcrGncqJqATGOwKrseWjH.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return oPfdHfuSMIIvnHIaUdwxfcODxVRA(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
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
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
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
				ActionElementMap actionElementMap2 = eofklWOcrGncqJqATGOwKrseWjH[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return ejHJvkpvZUhZyEdaJeIqabJkzOk(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return ButtonMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			pzIgUUqGaMeKGbkvuXiKWrgXVaf pzIgUUqGaMeKGbkvuXiKWrgXVaf2 = new pzIgUUqGaMeKGbkvuXiKWrgXVaf(-2);
			pzIgUUqGaMeKGbkvuXiKWrgXVaf2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			pzIgUUqGaMeKGbkvuXiKWrgXVaf2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
			pzIgUUqGaMeKGbkvuXiKWrgXVaf2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return pzIgUUqGaMeKGbkvuXiKWrgXVaf2;
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return gSnGxTxkuxpBdGjWaQyQLrTArPa(predicate, false);
		}

		internal ActionElementMap gSnGxTxkuxpBdGjWaQyQLrTArPa(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return WfRFdTYmjnOgTjdCYHxSGfSCYSc(predicate, false, results, false);
		}

		internal int WfRFdTYmjnOgTjdCYHxSGfSCYSc(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int count = eofklWOcrGncqJqATGOwKrseWjH.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = eofklWOcrGncqJqATGOwKrseWjH[i];
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
			return DeleteButtonMapsWithAction(ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
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
			int num = buttonMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					UCiOAoEllnqiaALgrLSeIRiNfiA(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			int num = 0;
			int count = eofklWOcrGncqJqATGOwKrseWjH.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF != state)
				{
					actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF = state;
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (skipDisabledMaps && !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (actionElementMap == null || eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
			{
				return false;
			}
			for (int i = 0; i < eofklWOcrGncqJqATGOwKrseWjH.Count; i++)
			{
				ActionElementMap actionElementMap2 = eofklWOcrGncqJqATGOwKrseWjH[i];
				if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
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
			for (int i = 0; i < eofklWOcrGncqJqATGOwKrseWjH.Count; i++)
			{
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if ((!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			TXPpuKwRLsdXtUTfKPEvnPKDxKP tXPpuKwRLsdXtUTfKPEvnPKDxKP = new TXPpuKwRLsdXtUTfKPEvnPKDxKP(-2);
			tXPpuKwRLsdXtUTfKPEvnPKDxKP.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			tXPpuKwRLsdXtUTfKPEvnPKDxKP.UkPuziaGThQCqHJbVOTnNlEiKOt = controllerMap;
			tXPpuKwRLsdXtUTfKPEvnPKDxKP.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return tXPpuKwRLsdXtUTfKPEvnPKDxKP;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			edBFagIzYUVmMXhbysXGQbeQlzw edBFagIzYUVmMXhbysXGQbeQlzw2 = new edBFagIzYUVmMXhbysXGQbeQlzw(-2);
			edBFagIzYUVmMXhbysXGQbeQlzw2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			edBFagIzYUVmMXhbysXGQbeQlzw2.ILxNeiUFNlXBMCfWlwycEgXzexcE = actionElementMap;
			edBFagIzYUVmMXhbysXGQbeQlzw2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return edBFagIzYUVmMXhbysXGQbeQlzw2;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			fbHbvpJgEpgLzHLgsFUaFLuxbvTP fbHbvpJgEpgLzHLgsFUaFLuxbvTP2 = new fbHbvpJgEpgLzHLgsFUaFLuxbvTP(-2);
			fbHbvpJgEpgLzHLgsFUaFLuxbvTP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			fbHbvpJgEpgLzHLgsFUaFLuxbvTP2.zOaFzOkpHDjDdAUAbeoShTwGIGW = conflictCheck;
			fbHbvpJgEpgLzHLgsFUaFLuxbvTP2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
			return fbHbvpJgEpgLzHLgsFUaFLuxbvTP2;
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.eofklWOcrGncqJqATGOwKrseWjH;
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
			for (int num2 = eofklWOcrGncqJqATGOwKrseWjH.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[num2];
				if (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.CheckForAssignmentConflict(list[i]))
						{
							UCiOAoEllnqiaALgrLSeIRiNfiA(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx, num2);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return num;
			}
			for (int num2 = eofklWOcrGncqJqATGOwKrseWjH.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = eofklWOcrGncqJqATGOwKrseWjH[num2];
				if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					UCiOAoEllnqiaALgrLSeIRiNfiA(actionElementMap2.fOjavGziuUSawAgvwyVARpyRBVx, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
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
			for (int num2 = eofklWOcrGncqJqATGOwKrseWjH.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[num2];
				if ((!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					UCiOAoEllnqiaALgrLSeIRiNfiA(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return UGqGgetPHsxNPYgSqVMUrunQPoY(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return UGqGgetPHsxNPYgSqVMUrunQPoY(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return UGqGgetPHsxNPYgSqVMUrunQPoY(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return UGqGgetPHsxNPYgSqVMUrunQPoY(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return UGqGgetPHsxNPYgSqVMUrunQPoY(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			return UGqGgetPHsxNPYgSqVMUrunQPoY(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return num;
			}
			IList<ActionElementMap> list = P_0.eofklWOcrGncqJqATGOwKrseWjH;
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (!actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = list[j];
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

		internal virtual int UGqGgetPHsxNPYgSqVMUrunQPoY(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int UGqGgetPHsxNPYgSqVMUrunQPoY(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU == null)
			{
				return num;
			}
			IList<ActionElementMap> bNlfWTDKHiJuxUqqXOBJLtGNIzLU = controllerMap.BNlfWTDKHiJuxUqqXOBJLtGNIzLU;
			if (bNlfWTDKHiJuxUqqXOBJLtGNIzLU == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = bNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count;
			for (int num2 = BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = BNlfWTDKHiJuxUqqXOBJLtGNIzLU[num2];
				if (!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || bNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.CheckForAssignmentConflict(bNlfWTDKHiJuxUqqXOBJLtGNIzLU[i]))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
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
			if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU == null)
			{
				return num;
			}
			for (int num2 = BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = BNlfWTDKHiJuxUqqXOBJLtGNIzLU[num2];
				if ((!skipDisabledMaps || actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU == null)
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
			for (int num2 = BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = BNlfWTDKHiJuxUqqXOBJLtGNIzLU[num2];
				if ((!skipDisabledMaps || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF) && actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				array[i] = eofklWOcrGncqJqATGOwKrseWjH[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return string.Empty;
			}
			try
			{
				return qnRcKibdUQgUDehMYaMNRcmEEUp().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return string.Empty;
			}
			try
			{
				return qnRcKibdUQgUDehMYaMNRcmEEUp().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.WXZzghlyGEKLVUqxSWMufmDMvxn(templateTypeGuid);
				string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.wqxxWUNxKMbJQQfTibGCHiSXNpPr(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
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
			return ControllerTemplateMap.wqxxWUNxKMbJQQfTibGCHiSXNpPr(controllerTemplate, this);
		}

		private ControllerTemplateMap SJjOAkwNzQHHGNAXdRuECtEQYOx(IControllerTemplate P_0)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.wqxxWUNxKMbJQQfTibGCHiSXNpPr(P_0, this);
		}

		internal virtual bool CopwiDtmNQYJDxydZiwAXLfuDcb(ActionElementMap P_0)
		{
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0._elementType))
			{
				return false;
			}
			rFQKqPOFlffkfbhLogsnuAZPWyqE(P_0);
			return true;
		}

		internal virtual int bZzFKiYesKDpdKuYgPjDSUSHvvYE(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = eofklWOcrGncqJqATGOwKrseWjH.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || eofklWOcrGncqJqATGOwKrseWjH[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					P_0.Add(eofklWOcrGncqJqATGOwKrseWjH[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap OEEXiRZgUmNAmcZjKOEgqtSQHfU(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_2))
			{
				return null;
			}
			int num = OWJIOjZyBJlqXiyCHOXEfHdflhC(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return eofklWOcrGncqJqATGOwKrseWjH[num];
		}

		internal virtual int rUsNUewZlIBApQhnyPUZihAjfEEJ(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i]._elementIdentifierId == P_0)
				{
					P_1.Add(eofklWOcrGncqJqATGOwKrseWjH[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool hCMxapJcJIFqEfPfsHYAZdZWGUrw(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i]._elementIdentifierId == P_0 && eofklWOcrGncqJqATGOwKrseWjH[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int OWJIOjZyBJlqXiyCHOXEfHdflhC(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_2))
			{
				return -1;
			}
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i]._elementIdentifierId == P_0 && eofklWOcrGncqJqATGOwKrseWjH[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int AavsbHLpBWnyRojIGECaSMtUjTx(int P_0)
		{
			if (eofklWOcrGncqJqATGOwKrseWjH == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (eofklWOcrGncqJqATGOwKrseWjH[i].fOjavGziuUSawAgvwyVARpyRBVx == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int oPfdHfuSMIIvnHIaUdwxfcODxVRA(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (!P_0 || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int ejHJvkpvZUhZyEdaJeIqabJkzOk(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int BGvXRGFtRGxLCvjTaLltejGrgpZ(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = eofklWOcrGncqJqATGOwKrseWjH[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap xeXzPaMQfzAZhpljIAZYHvYxvpQJ(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!PhjlYMAnQIfLgLwpwkIlkfjIQjG(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || eofklWOcrGncqJqATGOwKrseWjH[i]._actionId == P_2) && (!P_3 || eofklWOcrGncqJqATGOwKrseWjH[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF) && eofklWOcrGncqJqATGOwKrseWjH[i].IsTarget(P_0))
				{
					return eofklWOcrGncqJqATGOwKrseWjH[i];
				}
			}
			return null;
		}

		internal virtual int dyceDrFMqmHuFuGxjUooOwevmZT(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!PhjlYMAnQIfLgLwpwkIlkfjIQjG(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || eofklWOcrGncqJqATGOwKrseWjH[i]._actionId == P_2) && (!P_3 || eofklWOcrGncqJqATGOwKrseWjH[i].TAiAzEAcNOkrpYWJEmhYYqnFvpF) && eofklWOcrGncqJqATGOwKrseWjH[i].IsTarget(P_0))
				{
					P_4.Add(eofklWOcrGncqJqATGOwKrseWjH[i]);
					num++;
				}
			}
			return num;
		}

		internal void wqcjdLtzIwzBXtPxQNlZEiUAIrC(int P_0, ControllerElementType P_1)
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
				anZEgqJfCTCyftlbtfLdZXMDqwn(elementMap);
			}
		}

		internal virtual bool anZEgqJfCTCyftlbtfLdZXMDqwn(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!RusVKQCzlApIiEmCwyIHRrBWWao(P_0._elementType))
			{
				return false;
			}
			eofklWOcrGncqJqATGOwKrseWjH.Add(P_0);
			FRQTqkDwWpdWKHBMBoaWjwrcTpS(P_0);
			return true;
		}

		internal bool PhjlYMAnQIfLgLwpwkIlkfjIQjG(IControllerElementTarget P_0)
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

		internal bool upgXVjgAapuDEkrYPRuySHNdfEO(string P_0)
		{
			try
			{
				JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool oHshqCkqMeppbeLmIyvHTLAZxmk(string P_0)
		{
			try
			{
				JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void FRQTqkDwWpdWKHBMBoaWjwrcTpS(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Add(P_0);
				BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Sort(FYXVgMkJvnfHwzoCUNjmsPnpVDQ.Default);
			}
		}

		internal void VVHSvWBKzFMzSNTHJDxASXBfVeB(int P_0)
		{
			int num = PAeVSOMdajDIEJecPEoqcxJTjYu(P_0);
			if (num >= 0)
			{
				BNlfWTDKHiJuxUqqXOBJLtGNIzLU.RemoveAt(num);
			}
		}

		internal void UeiQUagpwSRKTbdvvZBQKnDtdIy(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = PAeVSOMdajDIEJecPEoqcxJTjYu(P_0);
				if (num >= 0)
				{
					BNlfWTDKHiJuxUqqXOBJLtGNIzLU[num] = P_1;
					BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Sort(FYXVgMkJvnfHwzoCUNjmsPnpVDQ.Default);
				}
			}
		}

		internal static void xavLFwNGgnystCpMvRrUZkwBdDN(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
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
				ReInput.controllers.GetController(_controllerType, _controllerId).sSQYMATtZixpYjjUsqaWsAupijI(this, map);
			}
		}

		internal virtual bool JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
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
						actionElementMap.JYyEPkmZztzXfbEgKghAFieAytO(value2);
						if (ActionElementMap.zEsjsITBQsNpTxgsSdFrSEugfDhD(actionElementMap))
						{
							rFQKqPOFlffkfbhLogsnuAZPWyqE(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void ZpEgvAefsRlDDfhUwpzFAUZSfaaq(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				zYwYmGHTCLOJxCByvWzioBevSzj = "dataVersion",
				HpxePuhaScltgSCBmgsrsCpjliL = 2.ToString()
			});
			if (object.ReferenceEquals(GetType(), typeof(JoystickMap)))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string hpxePuhaScltgSCBmgsrsCpjliL = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
				{
					zYwYmGHTCLOJxCByvWzioBevSzj = "hardwareGuid",
					HpxePuhaScltgSCBmgsrsCpjliL = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
				{
					zYwYmGHTCLOJxCByvWzioBevSzj = "hardwareName",
					HpxePuhaScltgSCBmgsrsCpjliL = hpxePuhaScltgSCBmgsrsCpjliL
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				LwDBNnNFqBxCeHOdFxAkCpxXHQR = "xmlns",
				zYwYmGHTCLOJxCByvWzioBevSzj = "xsi",
				oseqaDGmYbdubOOmISVVBGRFzNc = null,
				HpxePuhaScltgSCBmgsrsCpjliL = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				LwDBNnNFqBxCeHOdFxAkCpxXHQR = "xsi",
				zYwYmGHTCLOJxCByvWzioBevSzj = "schemaLocation",
				oseqaDGmYbdubOOmISVVBGRFzNc = null,
				HpxePuhaScltgSCBmgsrsCpjliL = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (eofklWOcrGncqJqATGOwKrseWjH[i] != null)
				{
					list.Add(eofklWOcrGncqJqATGOwKrseWjH[i].qnRcKibdUQgUDehMYaMNRcmEEUp());
				}
			}
		}

		private bool RusVKQCzlApIiEmCwyIHRrBWWao(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void UCiOAoEllnqiaALgrLSeIRiNfiA(int P_0, int P_1)
		{
			VVHSvWBKzFMzSNTHJDxASXBfVeB(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				eofklWOcrGncqJqATGOwKrseWjH.RemoveAt(P_1);
			}
		}

		private void rFQKqPOFlffkfbhLogsnuAZPWyqE(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				eofklWOcrGncqJqATGOwKrseWjH.Add(P_0);
				FRQTqkDwWpdWKHBMBoaWjwrcTpS(P_0);
			}
		}

		private void jeHwnNsIKOQoIsfAFoPcuGHYiEj(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				UeiQUagpwSRKTbdvvZBQKnDtdIy(eofklWOcrGncqJqATGOwKrseWjH[P_1].fOjavGziuUSawAgvwyVARpyRBVx, P_0);
				eofklWOcrGncqJqATGOwKrseWjH[P_1] = P_0;
			}
		}

		private int PAeVSOMdajDIEJecPEoqcxJTjYu(int P_0)
		{
			if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU == null)
			{
				return -1;
			}
			int count = BNlfWTDKHiJuxUqqXOBJLtGNIzLU.Count;
			for (int i = 0; i < count; i++)
			{
				if (BNlfWTDKHiJuxUqqXOBJLtGNIzLU[i].fOjavGziuUSawAgvwyVARpyRBVx == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject qnRcKibdUQgUDehMYaMNRcmEEUp()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ZpEgvAefsRlDDfhUwpzFAUZSfaaq(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap AxGMnpcloIAUTQTSFCdghQatHHxd(ControllerType P_0)
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

		internal static ControllerMap cPddxWgeQLKoABjtJFakbMLbPOFb(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.cPddxWgeQLKoABjtJFakbMLbPOFb(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.cPddxWgeQLKoABjtJFakbMLbPOFb(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.cPddxWgeQLKoABjtJFakbMLbPOFb(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.cPddxWgeQLKoABjtJFakbMLbPOFb(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = AxGMnpcloIAUTQTSFCdghQatHHxd(controllerType);
			try
			{
				controllerMap.upgXVjgAapuDEkrYPRuySHNdfEO(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
