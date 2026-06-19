using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class KPowbyAOjOXOrvcTZSxdWfbYLmJ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public JoystickMap tdDUHJCJvhemGRBxcGYtRUjQnjV;

					public JoystickMap knCBLkNLXkuIFCDBlGcZsTysnZf;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public int vkNqqgLYPoacgSzXsBqZNlqMNBv;

					public Joystick XBJjGSbWuXXqQVqvGoNKGTwozWCb;

					public ElementAssignmentConflictInfo tncCrGyPVrXIKNiWXDyUohflpru;

					public IEnumerator<ElementAssignmentConflictInfo> wnoeKZBxhHgmFlvHvZSMaOqutkOD;

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
						KPowbyAOjOXOrvcTZSxdWfbYLmJ kPowbyAOjOXOrvcTZSxdWfbYLmJ;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							kPowbyAOjOXOrvcTZSxdWfbYLmJ = this;
						}
						else
						{
							kPowbyAOjOXOrvcTZSxdWfbYLmJ = new KPowbyAOjOXOrvcTZSxdWfbYLmJ(0);
							kPowbyAOjOXOrvcTZSxdWfbYLmJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						kPowbyAOjOXOrvcTZSxdWfbYLmJ.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						kPowbyAOjOXOrvcTZSxdWfbYLmJ.tdDUHJCJvhemGRBxcGYtRUjQnjV = knCBLkNLXkuIFCDBlGcZsTysnZf;
						kPowbyAOjOXOrvcTZSxdWfbYLmJ.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						kPowbyAOjOXOrvcTZSxdWfbYLmJ.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						return kPowbyAOjOXOrvcTZSxdWfbYLmJ;
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
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0 || tdDUHJCJvhemGRBxcGYtRUjQnjV == null)
								{
									break;
								}
								vkNqqgLYPoacgSzXsBqZNlqMNBv = 0;
								goto IL_012c;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_010b;
								}
								IL_010b:
								if (wnoeKZBxhHgmFlvHvZSMaOqutkOD.MoveNext())
								{
									tncCrGyPVrXIKNiWXDyUohflpru = wnoeKZBxhHgmFlvHvZSMaOqutkOD.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = tncCrGyPVrXIKNiWXDyUohflpru;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								nzyEedAcxlxiMgOIBGRdbRpIIknp();
								goto IL_011e;
								IL_011e:
								vkNqqgLYPoacgSzXsBqZNlqMNBv++;
								goto IL_012c;
								IL_012c:
								if (vkNqqgLYPoacgSzXsBqZNlqMNBv >= kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count)
								{
									break;
								}
								XBJjGSbWuXXqQVqvGoNKGTwozWCb = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[vkNqqgLYPoacgSzXsBqZNlqMNBv].pxFOUEuAQwwDMNyKdQhVGxLNflI;
								if (XBJjGSbWuXXqQVqvGoNKGTwozWCb.id == OxaYhfaGlOIumOWmOozrcdXdBYi)
								{
									wnoeKZBxhHgmFlvHvZSMaOqutkOD = kdBZqupjvsCsVkwJiOeEQzkEDVO.PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Joystick, OxaYhfaGlOIumOWmOozrcdXdBYi, tdDUHJCJvhemGRBxcGYtRUjQnjV, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD, kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[vkNqqgLYPoacgSzXsBqZNlqMNBv].nytTYXdOuEqgOKSTmLpKeODwQdx).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_010b;
								}
								goto IL_011e;
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
								nzyEedAcxlxiMgOIBGRdbRpIIknp();
							}
						}
					}

					[DebuggerHidden]
					public KPowbyAOjOXOrvcTZSxdWfbYLmJ(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void nzyEedAcxlxiMgOIBGRdbRpIIknp()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (wnoeKZBxhHgmFlvHvZSMaOqutkOD != null)
						{
							wnoeKZBxhHgmFlvHvZSMaOqutkOD.Dispose();
						}
					}
				}

				private sealed class wfSzKDUEsYseukmhzkNOzmFaBKS : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public JoystickMap tdDUHJCJvhemGRBxcGYtRUjQnjV;

					public JoystickMap knCBLkNLXkuIFCDBlGcZsTysnZf;

					public ActionElementMap zDxxeVQthcTQrXNTuckCqntFBMJ;

					public ActionElementMap zwrclSFEGAptHdMvIKRCbTPkMpdN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public int iruDJNNTOISYWFuVLhOVfHeygkb;

					public Joystick HsspjmBfqfgIXbQOhLybBrorgkf;

					public ElementAssignmentConflictInfo NwNgwuEVQpbXJoqQLDxyHgFOdMv;

					public IEnumerator<ElementAssignmentConflictInfo> lWpmKgJbmkGiVIiEJGiqYszGzCn;

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
						wfSzKDUEsYseukmhzkNOzmFaBKS wfSzKDUEsYseukmhzkNOzmFaBKS2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wfSzKDUEsYseukmhzkNOzmFaBKS2 = this;
						}
						else
						{
							wfSzKDUEsYseukmhzkNOzmFaBKS2 = new wfSzKDUEsYseukmhzkNOzmFaBKS(0);
							wfSzKDUEsYseukmhzkNOzmFaBKS2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						wfSzKDUEsYseukmhzkNOzmFaBKS2.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						wfSzKDUEsYseukmhzkNOzmFaBKS2.tdDUHJCJvhemGRBxcGYtRUjQnjV = knCBLkNLXkuIFCDBlGcZsTysnZf;
						wfSzKDUEsYseukmhzkNOzmFaBKS2.zDxxeVQthcTQrXNTuckCqntFBMJ = zwrclSFEGAptHdMvIKRCbTPkMpdN;
						wfSzKDUEsYseukmhzkNOzmFaBKS2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						wfSzKDUEsYseukmhzkNOzmFaBKS2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						return wfSzKDUEsYseukmhzkNOzmFaBKS2;
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
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0 || zDxxeVQthcTQrXNTuckCqntFBMJ == null)
								{
									break;
								}
								iruDJNNTOISYWFuVLhOVfHeygkb = 0;
								goto IL_0132;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0111;
								}
								IL_0111:
								if (lWpmKgJbmkGiVIiEJGiqYszGzCn.MoveNext())
								{
									NwNgwuEVQpbXJoqQLDxyHgFOdMv = lWpmKgJbmkGiVIiEJGiqYszGzCn.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = NwNgwuEVQpbXJoqQLDxyHgFOdMv;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								raYIZUbPHBPfTmJuiHZYELXBRehd();
								goto IL_0124;
								IL_0124:
								iruDJNNTOISYWFuVLhOVfHeygkb++;
								goto IL_0132;
								IL_0132:
								if (iruDJNNTOISYWFuVLhOVfHeygkb >= kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count)
								{
									break;
								}
								HsspjmBfqfgIXbQOhLybBrorgkf = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[iruDJNNTOISYWFuVLhOVfHeygkb].pxFOUEuAQwwDMNyKdQhVGxLNflI;
								if (HsspjmBfqfgIXbQOhLybBrorgkf.id == OxaYhfaGlOIumOWmOozrcdXdBYi)
								{
									lWpmKgJbmkGiVIiEJGiqYszGzCn = kdBZqupjvsCsVkwJiOeEQzkEDVO.PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Joystick, OxaYhfaGlOIumOWmOozrcdXdBYi, tdDUHJCJvhemGRBxcGYtRUjQnjV, zDxxeVQthcTQrXNTuckCqntFBMJ, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD, kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[iruDJNNTOISYWFuVLhOVfHeygkb].nytTYXdOuEqgOKSTmLpKeODwQdx).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0111;
								}
								goto IL_0124;
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
								raYIZUbPHBPfTmJuiHZYELXBRehd();
							}
						}
					}

					[DebuggerHidden]
					public wfSzKDUEsYseukmhzkNOzmFaBKS(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void raYIZUbPHBPfTmJuiHZYELXBRehd()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (lWpmKgJbmkGiVIiEJGiqYszGzCn != null)
						{
							lWpmKgJbmkGiVIiEJGiqYszGzCn.Dispose();
						}
					}
				}

				private sealed class AXmkBPIiiCKpBJOcdpGJBHojezjC : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public int NBgRMMooXJveNycDSzmdLHgFakB;

					public Joystick mJzGQpkGdDZoGpoIVfwTKiduhrCC;

					public ElementAssignmentConflictInfo fjJmOUxGkzQlvywXGiZbhjSVeqK;

					public IEnumerator<ElementAssignmentConflictInfo> PhcOjjmKlRFjYuWnBJFDbpWjQLk;

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
						AXmkBPIiiCKpBJOcdpGJBHojezjC aXmkBPIiiCKpBJOcdpGJBHojezjC;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							aXmkBPIiiCKpBJOcdpGJBHojezjC = this;
						}
						else
						{
							aXmkBPIiiCKpBJOcdpGJBHojezjC = new AXmkBPIiiCKpBJOcdpGJBHojezjC(0);
							aXmkBPIiiCKpBJOcdpGJBHojezjC.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						aXmkBPIiiCKpBJOcdpGJBHojezjC.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						aXmkBPIiiCKpBJOcdpGJBHojezjC.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						aXmkBPIiiCKpBJOcdpGJBHojezjC.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						return aXmkBPIiiCKpBJOcdpGJBHojezjC;
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
								if (sADsWDUCiahlWYuuUKwcFHVfnhS.controllerId < 0 || sADsWDUCiahlWYuuUKwcFHVfnhS.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								NBgRMMooXJveNycDSzmdLHgFakB = 0;
								goto IL_0135;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0114;
								}
								IL_0114:
								if (PhcOjjmKlRFjYuWnBJFDbpWjQLk.MoveNext())
								{
									fjJmOUxGkzQlvywXGiZbhjSVeqK = PhcOjjmKlRFjYuWnBJFDbpWjQLk.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = fjJmOUxGkzQlvywXGiZbhjSVeqK;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								XkZdRQILUXiJzdMrJyhTMpnEwUNG();
								goto IL_0127;
								IL_0127:
								NBgRMMooXJveNycDSzmdLHgFakB++;
								goto IL_0135;
								IL_0135:
								if (NBgRMMooXJveNycDSzmdLHgFakB >= kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count)
								{
									break;
								}
								mJzGQpkGdDZoGpoIVfwTKiduhrCC = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[NBgRMMooXJveNycDSzmdLHgFakB].pxFOUEuAQwwDMNyKdQhVGxLNflI;
								if (mJzGQpkGdDZoGpoIVfwTKiduhrCC.id == sADsWDUCiahlWYuuUKwcFHVfnhS.controllerId)
								{
									PhcOjjmKlRFjYuWnBJFDbpWjQLk = kdBZqupjvsCsVkwJiOeEQzkEDVO.PUKvSnYZhztTPYKjBETQOaMFwgy(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD, kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[NBgRMMooXJveNycDSzmdLHgFakB].nytTYXdOuEqgOKSTmLpKeODwQdx).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0114;
								}
								goto IL_0127;
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
								XkZdRQILUXiJzdMrJyhTMpnEwUNG();
							}
						}
					}

					[DebuggerHidden]
					public AXmkBPIiiCKpBJOcdpGJBHojezjC(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void XkZdRQILUXiJzdMrJyhTMpnEwUNG()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (PhcOjjmKlRFjYuWnBJFDbpWjQLk != null)
						{
							PhcOjjmKlRFjYuWnBJFDbpWjQLk.Dispose();
						}
					}
				}

				private sealed class joWajsfFSNsqrurlfceHfdqfsLtu : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomControllerMap vaFeHBHGXpfaBIEWonnaqpgDxIF;

					public CustomControllerMap QtcRzqtvBSYDEvTRmsUPKyXubAx;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public int QslKBVjCBlAoNPKUebySiSFKJhiB;

					public CustomController pMyHbegeFkvbMTQraxkfgbHAFVq;

					public ElementAssignmentConflictInfo bGRTdMIlFNMdQglcGjgrNGiuhzI;

					public IEnumerator<ElementAssignmentConflictInfo> tolzfKlNUdsBhjKtXPWrakgcfaj;

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
						joWajsfFSNsqrurlfceHfdqfsLtu joWajsfFSNsqrurlfceHfdqfsLtu2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							joWajsfFSNsqrurlfceHfdqfsLtu2 = this;
						}
						else
						{
							joWajsfFSNsqrurlfceHfdqfsLtu2 = new joWajsfFSNsqrurlfceHfdqfsLtu(0);
							joWajsfFSNsqrurlfceHfdqfsLtu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						joWajsfFSNsqrurlfceHfdqfsLtu2.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						joWajsfFSNsqrurlfceHfdqfsLtu2.vaFeHBHGXpfaBIEWonnaqpgDxIF = QtcRzqtvBSYDEvTRmsUPKyXubAx;
						joWajsfFSNsqrurlfceHfdqfsLtu2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						joWajsfFSNsqrurlfceHfdqfsLtu2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						return joWajsfFSNsqrurlfceHfdqfsLtu2;
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
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0 || vaFeHBHGXpfaBIEWonnaqpgDxIF == null)
								{
									break;
								}
								QslKBVjCBlAoNPKUebySiSFKJhiB = 0;
								goto IL_012d;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_010c;
								}
								IL_010c:
								if (tolzfKlNUdsBhjKtXPWrakgcfaj.MoveNext())
								{
									bGRTdMIlFNMdQglcGjgrNGiuhzI = tolzfKlNUdsBhjKtXPWrakgcfaj.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = bGRTdMIlFNMdQglcGjgrNGiuhzI;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								RMsnTsrqsoHPvwIuvDrWBaqLOMKm();
								goto IL_011f;
								IL_011f:
								QslKBVjCBlAoNPKUebySiSFKJhiB++;
								goto IL_012d;
								IL_012d:
								if (QslKBVjCBlAoNPKUebySiSFKJhiB >= kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count)
								{
									break;
								}
								pMyHbegeFkvbMTQraxkfgbHAFVq = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[QslKBVjCBlAoNPKUebySiSFKJhiB].pxFOUEuAQwwDMNyKdQhVGxLNflI;
								if (pMyHbegeFkvbMTQraxkfgbHAFVq.id == JlYBenWQMdppMjVUfGFFPIshODO)
								{
									tolzfKlNUdsBhjKtXPWrakgcfaj = kdBZqupjvsCsVkwJiOeEQzkEDVO.PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Custom, JlYBenWQMdppMjVUfGFFPIshODO, vaFeHBHGXpfaBIEWonnaqpgDxIF, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD, kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[QslKBVjCBlAoNPKUebySiSFKJhiB].nytTYXdOuEqgOKSTmLpKeODwQdx).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_010c;
								}
								goto IL_011f;
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
								RMsnTsrqsoHPvwIuvDrWBaqLOMKm();
							}
						}
					}

					[DebuggerHidden]
					public joWajsfFSNsqrurlfceHfdqfsLtu(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void RMsnTsrqsoHPvwIuvDrWBaqLOMKm()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (tolzfKlNUdsBhjKtXPWrakgcfaj != null)
						{
							tolzfKlNUdsBhjKtXPWrakgcfaj.Dispose();
						}
					}
				}

				private sealed class RqahAxIDpMiFhkdUTNVZZtGVClB : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomControllerMap vaFeHBHGXpfaBIEWonnaqpgDxIF;

					public CustomControllerMap QtcRzqtvBSYDEvTRmsUPKyXubAx;

					public ActionElementMap zDxxeVQthcTQrXNTuckCqntFBMJ;

					public ActionElementMap zwrclSFEGAptHdMvIKRCbTPkMpdN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public int XxRnCUspnhQSRNJkpAPnFbDvCEyQ;

					public CustomController JbjRQOIMIxKHLFOmMekaElNQdQw;

					public ElementAssignmentConflictInfo rckdLzsklcWaelTVAwMURqdZWOk;

					public IEnumerator<ElementAssignmentConflictInfo> rlFhFDBHURLtdidmNyuefdRDlme;

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
						RqahAxIDpMiFhkdUTNVZZtGVClB rqahAxIDpMiFhkdUTNVZZtGVClB;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							rqahAxIDpMiFhkdUTNVZZtGVClB = this;
						}
						else
						{
							rqahAxIDpMiFhkdUTNVZZtGVClB = new RqahAxIDpMiFhkdUTNVZZtGVClB(0);
							rqahAxIDpMiFhkdUTNVZZtGVClB.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						rqahAxIDpMiFhkdUTNVZZtGVClB.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						rqahAxIDpMiFhkdUTNVZZtGVClB.vaFeHBHGXpfaBIEWonnaqpgDxIF = QtcRzqtvBSYDEvTRmsUPKyXubAx;
						rqahAxIDpMiFhkdUTNVZZtGVClB.zDxxeVQthcTQrXNTuckCqntFBMJ = zwrclSFEGAptHdMvIKRCbTPkMpdN;
						rqahAxIDpMiFhkdUTNVZZtGVClB.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						rqahAxIDpMiFhkdUTNVZZtGVClB.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						return rqahAxIDpMiFhkdUTNVZZtGVClB;
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
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0 || zDxxeVQthcTQrXNTuckCqntFBMJ == null)
								{
									break;
								}
								XxRnCUspnhQSRNJkpAPnFbDvCEyQ = 0;
								goto IL_0133;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0112;
								}
								IL_0112:
								if (rlFhFDBHURLtdidmNyuefdRDlme.MoveNext())
								{
									rckdLzsklcWaelTVAwMURqdZWOk = rlFhFDBHURLtdidmNyuefdRDlme.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = rckdLzsklcWaelTVAwMURqdZWOk;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								ApkzrcHaEgGUUEfPyugWEHoqUhuA();
								goto IL_0125;
								IL_0125:
								XxRnCUspnhQSRNJkpAPnFbDvCEyQ++;
								goto IL_0133;
								IL_0133:
								if (XxRnCUspnhQSRNJkpAPnFbDvCEyQ >= kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count)
								{
									break;
								}
								JbjRQOIMIxKHLFOmMekaElNQdQw = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[XxRnCUspnhQSRNJkpAPnFbDvCEyQ].pxFOUEuAQwwDMNyKdQhVGxLNflI;
								if (JbjRQOIMIxKHLFOmMekaElNQdQw.id == JlYBenWQMdppMjVUfGFFPIshODO)
								{
									rlFhFDBHURLtdidmNyuefdRDlme = kdBZqupjvsCsVkwJiOeEQzkEDVO.PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Custom, JlYBenWQMdppMjVUfGFFPIshODO, vaFeHBHGXpfaBIEWonnaqpgDxIF, zDxxeVQthcTQrXNTuckCqntFBMJ, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD, kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[XxRnCUspnhQSRNJkpAPnFbDvCEyQ].nytTYXdOuEqgOKSTmLpKeODwQdx).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0112;
								}
								goto IL_0125;
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
								ApkzrcHaEgGUUEfPyugWEHoqUhuA();
							}
						}
					}

					[DebuggerHidden]
					public RqahAxIDpMiFhkdUTNVZZtGVClB(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void ApkzrcHaEgGUUEfPyugWEHoqUhuA()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (rlFhFDBHURLtdidmNyuefdRDlme != null)
						{
							rlFhFDBHURLtdidmNyuefdRDlme.Dispose();
						}
					}
				}

				private sealed class wyPanLAKegnKkuXIYpfsmCqMBcpo : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public int OaULpeegyBozepYLwdaeNHokNdV;

					public CustomController FOqKAhjfuJELJfMOXekIfgchrBDz;

					public ElementAssignmentConflictInfo RlrwUNPFmQVZrVnsvllDkxlFlUf;

					public IEnumerator<ElementAssignmentConflictInfo> wqGQbDCVZaeKmjtTwfDonIePyFb;

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
						wyPanLAKegnKkuXIYpfsmCqMBcpo wyPanLAKegnKkuXIYpfsmCqMBcpo2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wyPanLAKegnKkuXIYpfsmCqMBcpo2 = this;
						}
						else
						{
							wyPanLAKegnKkuXIYpfsmCqMBcpo2 = new wyPanLAKegnKkuXIYpfsmCqMBcpo(0);
							wyPanLAKegnKkuXIYpfsmCqMBcpo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						wyPanLAKegnKkuXIYpfsmCqMBcpo2.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						wyPanLAKegnKkuXIYpfsmCqMBcpo2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						wyPanLAKegnKkuXIYpfsmCqMBcpo2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						return wyPanLAKegnKkuXIYpfsmCqMBcpo2;
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
								if (sADsWDUCiahlWYuuUKwcFHVfnhS.controllerId < 0 || sADsWDUCiahlWYuuUKwcFHVfnhS.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								OaULpeegyBozepYLwdaeNHokNdV = 0;
								goto IL_0135;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0114;
								}
								IL_0114:
								if (wqGQbDCVZaeKmjtTwfDonIePyFb.MoveNext())
								{
									RlrwUNPFmQVZrVnsvllDkxlFlUf = wqGQbDCVZaeKmjtTwfDonIePyFb.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = RlrwUNPFmQVZrVnsvllDkxlFlUf;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								USmHecRuhxpOkcMTLnkMxPwVzWw();
								goto IL_0127;
								IL_0127:
								OaULpeegyBozepYLwdaeNHokNdV++;
								goto IL_0135;
								IL_0135:
								if (OaULpeegyBozepYLwdaeNHokNdV >= kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count)
								{
									break;
								}
								FOqKAhjfuJELJfMOXekIfgchrBDz = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[OaULpeegyBozepYLwdaeNHokNdV].pxFOUEuAQwwDMNyKdQhVGxLNflI;
								if (FOqKAhjfuJELJfMOXekIfgchrBDz.id == sADsWDUCiahlWYuuUKwcFHVfnhS.controllerId)
								{
									wqGQbDCVZaeKmjtTwfDonIePyFb = kdBZqupjvsCsVkwJiOeEQzkEDVO.PUKvSnYZhztTPYKjBETQOaMFwgy(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD, kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[OaULpeegyBozepYLwdaeNHokNdV].nytTYXdOuEqgOKSTmLpKeODwQdx).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0114;
								}
								goto IL_0127;
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
								USmHecRuhxpOkcMTLnkMxPwVzWw();
							}
						}
					}

					[DebuggerHidden]
					public wyPanLAKegnKkuXIYpfsmCqMBcpo(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void USmHecRuhxpOkcMTLnkMxPwVzWw()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (wqGQbDCVZaeKmjtTwfDonIePyFb != null)
						{
							wqGQbDCVZaeKmjtTwfDonIePyFb.Dispose();
						}
					}
				}

				private sealed class LRLDUHOSiVLoqfYbxhxxIdPnMNH<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where T : ControllerMap
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType WdGpHOJexeFXfmFkVyjWVoEPRod;

					public ControllerType LcfIxioPnFqYidkfjLRcvDEBZxW;

					public int VmCFeEBMXGKaXnCFbdDsJtZqWhX;

					public int QbdCbTcQUefkyJDrkCJsqWRdkJf;

					public T qkGkYiBCKMRlUDkWlCimpJVcFLq;

					public T tMIlNOjAsUKwVsLWIYSEUFTHGtX;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> QidGGffTtLaQgIafDqzbrSZHpaiO;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> DBuGkmVwBFWupmCHcIikesbWRBt;

					public InputMapCategory maFtAzLjUIHiPMiQOBBpXCLiHyJD;

					public int QlZqpgKSwAiFYsdWABHinYlTeBD;

					public ControllerMap mMPlJcpSLUwoOsbUlHkAQgxebEB;

					public ElementAssignmentConflictInfo pDsIWPieCxljkMFwarsBArbNbPRD;

					public ElementAssignmentConflictInfo HITNTdwgroazBASviPMidgxifRLJ;

					public IEnumerator<ElementAssignmentConflictInfo> mjWiiUuObuiFJISsuEfrdIynRric;

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
						LRLDUHOSiVLoqfYbxhxxIdPnMNH<T> lRLDUHOSiVLoqfYbxhxxIdPnMNH;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							lRLDUHOSiVLoqfYbxhxxIdPnMNH = this;
						}
						else
						{
							lRLDUHOSiVLoqfYbxhxxIdPnMNH = new LRLDUHOSiVLoqfYbxhxxIdPnMNH<T>(0);
							lRLDUHOSiVLoqfYbxhxxIdPnMNH.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						lRLDUHOSiVLoqfYbxhxxIdPnMNH.WdGpHOJexeFXfmFkVyjWVoEPRod = LcfIxioPnFqYidkfjLRcvDEBZxW;
						lRLDUHOSiVLoqfYbxhxxIdPnMNH.VmCFeEBMXGKaXnCFbdDsJtZqWhX = QbdCbTcQUefkyJDrkCJsqWRdkJf;
						lRLDUHOSiVLoqfYbxhxxIdPnMNH.qkGkYiBCKMRlUDkWlCimpJVcFLq = tMIlNOjAsUKwVsLWIYSEUFTHGtX;
						lRLDUHOSiVLoqfYbxhxxIdPnMNH.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						lRLDUHOSiVLoqfYbxhxxIdPnMNH.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						lRLDUHOSiVLoqfYbxhxxIdPnMNH.QidGGffTtLaQgIafDqzbrSZHpaiO = DBuGkmVwBFWupmCHcIikesbWRBt;
						return lRLDUHOSiVLoqfYbxhxxIdPnMNH;
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
								if (QidGGffTtLaQgIafDqzbrSZHpaiO == null || qkGkYiBCKMRlUDkWlCimpJVcFLq == null)
								{
									break;
								}
								maFtAzLjUIHiPMiQOBBpXCLiHyJD = ReInput.mapping.GetMapCategory(qkGkYiBCKMRlUDkWlCimpJVcFLq.categoryId);
								if (maFtAzLjUIHiPMiQOBBpXCLiHyJD == null)
								{
									break;
								}
								QlZqpgKSwAiFYsdWABHinYlTeBD = 0;
								goto IL_01a9;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0185;
								}
								IL_01a9:
								if (QlZqpgKSwAiFYsdWABHinYlTeBD >= QidGGffTtLaQgIafDqzbrSZHpaiO.Count)
								{
									break;
								}
								mMPlJcpSLUwoOsbUlHkAQgxebEB = QidGGffTtLaQgIafDqzbrSZHpaiO[QlZqpgKSwAiFYsdWABHinYlTeBD];
								if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || mMPlJcpSLUwoOsbUlHkAQgxebEB.enabled) && (CHBtzEcrnidqJpXrYvkBWeWbcbSD || !kdBZqupjvsCsVkwJiOeEQzkEDVO.QYPnYCHXOtclVpNVmFuVatcerNh(maFtAzLjUIHiPMiQOBBpXCLiHyJD, mMPlJcpSLUwoOsbUlHkAQgxebEB)))
								{
									mjWiiUuObuiFJISsuEfrdIynRric = mMPlJcpSLUwoOsbUlHkAQgxebEB.ElementAssignmentConflicts(qkGkYiBCKMRlUDkWlCimpJVcFLq, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0185;
								}
								goto IL_019b;
								IL_019b:
								QlZqpgKSwAiFYsdWABHinYlTeBD++;
								goto IL_01a9;
								IL_0185:
								if (mjWiiUuObuiFJISsuEfrdIynRric.MoveNext())
								{
									pDsIWPieCxljkMFwarsBArbNbPRD = mjWiiUuObuiFJISsuEfrdIynRric.Current;
									ref ElementAssignmentConflictInfo hITNTdwgroazBASviPMidgxifRLJ = ref HITNTdwgroazBASviPMidgxifRLJ;
									hITNTdwgroazBASviPMidgxifRLJ = new ElementAssignmentConflictInfo(pDsIWPieCxljkMFwarsBArbNbPRD);
									HITNTdwgroazBASviPMidgxifRLJ.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									HITNTdwgroazBASviPMidgxifRLJ.controllerType = WdGpHOJexeFXfmFkVyjWVoEPRod;
									HITNTdwgroazBASviPMidgxifRLJ.controllerId = VmCFeEBMXGKaXnCFbdDsJtZqWhX;
									ajbaQItphrIyqhowgmMTfPkCBvcN = HITNTdwgroazBASviPMidgxifRLJ;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								vSgRoMoiAefAOGjQrsKrjjFSiPC();
								goto IL_019b;
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
								vSgRoMoiAefAOGjQrsKrjjFSiPC();
							}
						}
					}

					[DebuggerHidden]
					public LRLDUHOSiVLoqfYbxhxxIdPnMNH(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void vSgRoMoiAefAOGjQrsKrjjFSiPC()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (mjWiiUuObuiFJISsuEfrdIynRric != null)
						{
							mjWiiUuObuiFJISsuEfrdIynRric.Dispose();
						}
					}
				}

				private sealed class jiTQiKjMHyYOqYbeoKCbkLqhdYgA<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where T : ControllerMap
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType WdGpHOJexeFXfmFkVyjWVoEPRod;

					public ControllerType LcfIxioPnFqYidkfjLRcvDEBZxW;

					public int VmCFeEBMXGKaXnCFbdDsJtZqWhX;

					public int QbdCbTcQUefkyJDrkCJsqWRdkJf;

					public T qkGkYiBCKMRlUDkWlCimpJVcFLq;

					public T tMIlNOjAsUKwVsLWIYSEUFTHGtX;

					public ActionElementMap tuJCzjwsFIpxMdqmHKdbpwNlQqz;

					public ActionElementMap PBfDvIDPVPOszqDGkeHFtEmMpGN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> QidGGffTtLaQgIafDqzbrSZHpaiO;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> DBuGkmVwBFWupmCHcIikesbWRBt;

					public InputMapCategory eWCKpvorQVgbbcGAvOjlDrXFbyq;

					public int VrUIKMAYZREfBGzAFPCSSABSJCV;

					public ControllerMap TaHNDcpScQMhRKAgvaihFIiHiTI;

					public ElementAssignmentConflictInfo qgpAhdNGkfnKGfaurFzhcUUUzOW;

					public ElementAssignmentConflictInfo gavbAjqtkJUZXeBhuaPbJODNtKKc;

					public IEnumerator<ElementAssignmentConflictInfo> kVCojHdkqOeZCKFJmviKCbaJsI;

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
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA<T> jiTQiKjMHyYOqYbeoKCbkLqhdYgA2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jiTQiKjMHyYOqYbeoKCbkLqhdYgA2 = this;
						}
						else
						{
							jiTQiKjMHyYOqYbeoKCbkLqhdYgA2 = new jiTQiKjMHyYOqYbeoKCbkLqhdYgA<T>(0);
							jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.WdGpHOJexeFXfmFkVyjWVoEPRod = LcfIxioPnFqYidkfjLRcvDEBZxW;
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.VmCFeEBMXGKaXnCFbdDsJtZqWhX = QbdCbTcQUefkyJDrkCJsqWRdkJf;
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.qkGkYiBCKMRlUDkWlCimpJVcFLq = tMIlNOjAsUKwVsLWIYSEUFTHGtX;
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.tuJCzjwsFIpxMdqmHKdbpwNlQqz = PBfDvIDPVPOszqDGkeHFtEmMpGN;
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.QidGGffTtLaQgIafDqzbrSZHpaiO = DBuGkmVwBFWupmCHcIikesbWRBt;
						return jiTQiKjMHyYOqYbeoKCbkLqhdYgA2;
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
								if (QidGGffTtLaQgIafDqzbrSZHpaiO == null || tuJCzjwsFIpxMdqmHKdbpwNlQqz == null)
								{
									break;
								}
								eWCKpvorQVgbbcGAvOjlDrXFbyq = ((qkGkYiBCKMRlUDkWlCimpJVcFLq != null) ? ReInput.mapping.GetMapCategory(qkGkYiBCKMRlUDkWlCimpJVcFLq.categoryId) : null);
								VrUIKMAYZREfBGzAFPCSSABSJCV = 0;
								goto IL_01a4;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0180;
								}
								IL_0180:
								if (kVCojHdkqOeZCKFJmviKCbaJsI.MoveNext())
								{
									qgpAhdNGkfnKGfaurFzhcUUUzOW = kVCojHdkqOeZCKFJmviKCbaJsI.Current;
									ref ElementAssignmentConflictInfo reference = ref gavbAjqtkJUZXeBhuaPbJODNtKKc;
									reference = new ElementAssignmentConflictInfo(qgpAhdNGkfnKGfaurFzhcUUUzOW);
									gavbAjqtkJUZXeBhuaPbJODNtKKc.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									gavbAjqtkJUZXeBhuaPbJODNtKKc.controllerType = WdGpHOJexeFXfmFkVyjWVoEPRod;
									gavbAjqtkJUZXeBhuaPbJODNtKKc.controllerId = VmCFeEBMXGKaXnCFbdDsJtZqWhX;
									ajbaQItphrIyqhowgmMTfPkCBvcN = gavbAjqtkJUZXeBhuaPbJODNtKKc;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								NuLnrAkrzYlzuXnNlitqYhLuzuw();
								goto IL_0196;
								IL_01a4:
								if (VrUIKMAYZREfBGzAFPCSSABSJCV >= QidGGffTtLaQgIafDqzbrSZHpaiO.Count)
								{
									break;
								}
								TaHNDcpScQMhRKAgvaihFIiHiTI = QidGGffTtLaQgIafDqzbrSZHpaiO[VrUIKMAYZREfBGzAFPCSSABSJCV];
								if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || TaHNDcpScQMhRKAgvaihFIiHiTI.enabled) && (CHBtzEcrnidqJpXrYvkBWeWbcbSD || !kdBZqupjvsCsVkwJiOeEQzkEDVO.QYPnYCHXOtclVpNVmFuVatcerNh(eWCKpvorQVgbbcGAvOjlDrXFbyq, TaHNDcpScQMhRKAgvaihFIiHiTI)))
								{
									kVCojHdkqOeZCKFJmviKCbaJsI = TaHNDcpScQMhRKAgvaihFIiHiTI.ElementAssignmentConflicts(tuJCzjwsFIpxMdqmHKdbpwNlQqz, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0180;
								}
								goto IL_0196;
								IL_0196:
								VrUIKMAYZREfBGzAFPCSSABSJCV++;
								goto IL_01a4;
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
								NuLnrAkrzYlzuXnNlitqYhLuzuw();
							}
						}
					}

					[DebuggerHidden]
					public jiTQiKjMHyYOqYbeoKCbkLqhdYgA(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void NuLnrAkrzYlzuXnNlitqYhLuzuw()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kVCojHdkqOeZCKFJmviKCbaJsI != null)
						{
							kVCojHdkqOeZCKFJmviKCbaJsI.Dispose();
						}
					}
				}

				private sealed class lpuvJUYczhOnHqWuujJfeNslFUP<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where T : ControllerMap
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> QidGGffTtLaQgIafDqzbrSZHpaiO;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> DBuGkmVwBFWupmCHcIikesbWRBt;

					public Player VnUcpBKBitiNadvlTyEwsdOANNU;

					public ControllerMap mZwghMHDyOAUqbuXMIPYbcoCEtzM;

					public InputMapCategory zlUSsQxLBzMNssNgKlQttyKpnIb;

					public int LJutffnqtCJBEncSYWRyARvYWug;

					public ControllerMap VeWbNvjYYVfZuFDHpdwwetkeCvh;

					public ElementAssignmentConflictInfo CqudlRcMtNLttcfAiGEoRgMRKjHC;

					public ElementAssignmentConflictInfo mafaMvJarawndJzjeLhPzVyIlue;

					public IEnumerator<ElementAssignmentConflictInfo> LFCWxqTFlFbNatiAZbnGQOjOMxm;

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
						lpuvJUYczhOnHqWuujJfeNslFUP<T> lpuvJUYczhOnHqWuujJfeNslFUP2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							lpuvJUYczhOnHqWuujJfeNslFUP2 = this;
						}
						else
						{
							lpuvJUYczhOnHqWuujJfeNslFUP2 = new lpuvJUYczhOnHqWuujJfeNslFUP<T>(0);
							lpuvJUYczhOnHqWuujJfeNslFUP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						lpuvJUYczhOnHqWuujJfeNslFUP2.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						lpuvJUYczhOnHqWuujJfeNslFUP2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						lpuvJUYczhOnHqWuujJfeNslFUP2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						lpuvJUYczhOnHqWuujJfeNslFUP2.QidGGffTtLaQgIafDqzbrSZHpaiO = DBuGkmVwBFWupmCHcIikesbWRBt;
						return lpuvJUYczhOnHqWuujJfeNslFUP2;
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
								if (QidGGffTtLaQgIafDqzbrSZHpaiO == null)
								{
									break;
								}
								VnUcpBKBitiNadvlTyEwsdOANNU = ReInput.players.GetPlayer(sADsWDUCiahlWYuuUKwcFHVfnhS.playerId);
								if (VnUcpBKBitiNadvlTyEwsdOANNU == null)
								{
									break;
								}
								mZwghMHDyOAUqbuXMIPYbcoCEtzM = VnUcpBKBitiNadvlTyEwsdOANNU.controllers.maps.GetMap(sADsWDUCiahlWYuuUKwcFHVfnhS.controllerType, sADsWDUCiahlWYuuUKwcFHVfnhS.controllerId, sADsWDUCiahlWYuuUKwcFHVfnhS.controllerMapId);
								zlUSsQxLBzMNssNgKlQttyKpnIb = ((mZwghMHDyOAUqbuXMIPYbcoCEtzM != null) ? ReInput.mapping.GetMapCategory(mZwghMHDyOAUqbuXMIPYbcoCEtzM.categoryId) : ReInput.mapping.GetMapCategory(sADsWDUCiahlWYuuUKwcFHVfnhS.controllerMapCategoryId));
								if (zlUSsQxLBzMNssNgKlQttyKpnIb == null)
								{
									break;
								}
								LJutffnqtCJBEncSYWRyARvYWug = 0;
								goto IL_0219;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_01f5;
								}
								IL_020b:
								LJutffnqtCJBEncSYWRyARvYWug++;
								goto IL_0219;
								IL_01f5:
								if (LFCWxqTFlFbNatiAZbnGQOjOMxm.MoveNext())
								{
									CqudlRcMtNLttcfAiGEoRgMRKjHC = LFCWxqTFlFbNatiAZbnGQOjOMxm.Current;
									ref ElementAssignmentConflictInfo reference = ref mafaMvJarawndJzjeLhPzVyIlue;
									reference = new ElementAssignmentConflictInfo(CqudlRcMtNLttcfAiGEoRgMRKjHC);
									mafaMvJarawndJzjeLhPzVyIlue.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									mafaMvJarawndJzjeLhPzVyIlue.controllerType = sADsWDUCiahlWYuuUKwcFHVfnhS.controllerType;
									mafaMvJarawndJzjeLhPzVyIlue.controllerId = sADsWDUCiahlWYuuUKwcFHVfnhS.controllerId;
									ajbaQItphrIyqhowgmMTfPkCBvcN = mafaMvJarawndJzjeLhPzVyIlue;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								FyVaUjemQjRmlqgJkQMUiNaEUZGf();
								goto IL_020b;
								IL_0219:
								if (LJutffnqtCJBEncSYWRyARvYWug >= QidGGffTtLaQgIafDqzbrSZHpaiO.Count)
								{
									break;
								}
								VeWbNvjYYVfZuFDHpdwwetkeCvh = QidGGffTtLaQgIafDqzbrSZHpaiO[LJutffnqtCJBEncSYWRyARvYWug];
								if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || VeWbNvjYYVfZuFDHpdwwetkeCvh.enabled) && (CHBtzEcrnidqJpXrYvkBWeWbcbSD || !kdBZqupjvsCsVkwJiOeEQzkEDVO.QYPnYCHXOtclVpNVmFuVatcerNh(zlUSsQxLBzMNssNgKlQttyKpnIb, VeWbNvjYYVfZuFDHpdwwetkeCvh)))
								{
									LFCWxqTFlFbNatiAZbnGQOjOMxm = VeWbNvjYYVfZuFDHpdwwetkeCvh.ElementAssignmentConflicts(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_01f5;
								}
								goto IL_020b;
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
								FyVaUjemQjRmlqgJkQMUiNaEUZGf();
							}
						}
					}

					[DebuggerHidden]
					public lpuvJUYczhOnHqWuujJfeNslFUP(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void FyVaUjemQjRmlqgJkQMUiNaEUZGf()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (LFCWxqTFlFbNatiAZbnGQOjOMxm != null)
						{
							LFCWxqTFlFbNatiAZbnGQOjOMxm.Dispose();
						}
					}
				}

				private readonly Player gESwCZhPTVpAneBRVEYFzquNJMi;

				private readonly ControllerHelper IqqFMkivXajbnQieKffNsZWOHNR;

				private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

				internal ConflictCheckingHelper(Player player, ControllerHelper parent)
				{
					fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
					gESwCZhPTVpAneBRVEYFzquNJMi = player;
					IqqFMkivXajbnQieKffNsZWOHNR = parent;
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
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
					return controllerType switch
					{
						ControllerType.Joystick => JeIWtKQTBXnyjCkiDAMmWaiiJsk(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => grekmIOqUshEKIQRaOdlrSSMZoo(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => emFXmSHxPCZvoGONqKjUcUduDKV(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => DFdzYgYcPgFYNkoMXQQtkhGuFPM(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => JeIWtKQTBXnyjCkiDAMmWaiiJsk(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => grekmIOqUshEKIQRaOdlrSSMZoo(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => emFXmSHxPCZvoGONqKjUcUduDKV(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => DFdzYgYcPgFYNkoMXQQtkhGuFPM(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return JeIWtKQTBXnyjCkiDAMmWaiiJsk(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return grekmIOqUshEKIQRaOdlrSSMZoo(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return emFXmSHxPCZvoGONqKjUcUduDKV(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return DFdzYgYcPgFYNkoMXQQtkhGuFPM(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => OVmodnTpthUtpqvipfivteyGGVL(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => bUTDGHUuYDffUhrbmCXprZxCMFET(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => SypGFGjsRWpPuavtmcmMKAnLbyG(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => baznHSJGgKGCZAcOofJRInLpyzmh(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => OVmodnTpthUtpqvipfivteyGGVL(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => bUTDGHUuYDffUhrbmCXprZxCMFET(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => SypGFGjsRWpPuavtmcmMKAnLbyG(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => baznHSJGgKGCZAcOofJRInLpyzmh(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return OVmodnTpthUtpqvipfivteyGGVL(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return bUTDGHUuYDffUhrbmCXprZxCMFET(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return SypGFGjsRWpPuavtmcmMKAnLbyG(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return baznHSJGgKGCZAcOofJRInLpyzmh(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps, bool forceCheckAllCategories)
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
					return controllerType switch
					{
						ControllerType.Joystick => xRqBqWbMswerNseUVdpgFLoCocek(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => GNfBhpBDaQXObKJdTfWawDZxlrIW(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => gqRgLYwXhghsxJBnHxTPNtkOJtgd(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => oEiLyVZoXriXDbfWEBQBSdqOeXM(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => xRqBqWbMswerNseUVdpgFLoCocek(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => GNfBhpBDaQXObKJdTfWawDZxlrIW(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => gqRgLYwXhghsxJBnHxTPNtkOJtgd(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => oEiLyVZoXriXDbfWEBQBSdqOeXM(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return xRqBqWbMswerNseUVdpgFLoCocek(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return GNfBhpBDaQXObKJdTfWawDZxlrIW(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return gqRgLYwXhghsxJBnHxTPNtkOJtgd(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return oEiLyVZoXriXDbfWEBQBSdqOeXM(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
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
					return controllerType switch
					{
						ControllerType.Joystick => XrrakVLUIvJCxksvvkbBsiLCWry(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => SMvnpwePjOFzEdCsFoypuhhOqTFA(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => jfjTCSLIZLJBNiRhECdBlZFntem(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => gdHVmJgkjQzYIcgryrfgFLhgkJF(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => XrrakVLUIvJCxksvvkbBsiLCWry(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => SMvnpwePjOFzEdCsFoypuhhOqTFA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => jfjTCSLIZLJBNiRhECdBlZFntem(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => gdHVmJgkjQzYIcgryrfgFLhgkJF(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return XrrakVLUIvJCxksvvkbBsiLCWry(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return SMvnpwePjOFzEdCsFoypuhhOqTFA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return jfjTCSLIZLJBNiRhECdBlZFntem(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return gdHVmJgkjQzYIcgryrfgFLhgkJF(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool JeIWtKQTBXnyjCkiDAMmWaiiJsk(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0 && rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Joystick, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx))
						{
							return true;
						}
					}
					return false;
				}

				private bool JeIWtKQTBXnyjCkiDAMmWaiiJsk(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0 && rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx))
						{
							return true;
						}
					}
					return false;
				}

				private bool JeIWtKQTBXnyjCkiDAMmWaiiJsk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0.controllerId && rIAztFUoGsfozaBNaLvltaNUjUM(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx))
						{
							return true;
						}
					}
					return false;
				}

				private bool grekmIOqUshEKIQRaOdlrSSMZoo(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Keyboard, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private bool grekmIOqUshEKIQRaOdlrSSMZoo(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private bool grekmIOqUshEKIQRaOdlrSSMZoo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return rIAztFUoGsfozaBNaLvltaNUjUM(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private bool emFXmSHxPCZvoGONqKjUcUduDKV(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Mouse, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private bool emFXmSHxPCZvoGONqKjUcUduDKV(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private bool emFXmSHxPCZvoGONqKjUcUduDKV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return rIAztFUoGsfozaBNaLvltaNUjUM(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private bool DFdzYgYcPgFYNkoMXQQtkhGuFPM(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0 && rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Custom, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx))
						{
							return true;
						}
					}
					return false;
				}

				private bool DFdzYgYcPgFYNkoMXQQtkhGuFPM(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0 && rIAztFUoGsfozaBNaLvltaNUjUM(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx))
						{
							return true;
						}
					}
					return false;
				}

				private bool DFdzYgYcPgFYNkoMXQQtkhGuFPM(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0.controllerId && rIAztFUoGsfozaBNaLvltaNUjUM(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> OVmodnTpthUtpqvipfivteyGGVL(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					KPowbyAOjOXOrvcTZSxdWfbYLmJ kPowbyAOjOXOrvcTZSxdWfbYLmJ = new KPowbyAOjOXOrvcTZSxdWfbYLmJ(-2);
					kPowbyAOjOXOrvcTZSxdWfbYLmJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					kPowbyAOjOXOrvcTZSxdWfbYLmJ.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					kPowbyAOjOXOrvcTZSxdWfbYLmJ.knCBLkNLXkuIFCDBlGcZsTysnZf = P_1;
					kPowbyAOjOXOrvcTZSxdWfbYLmJ.jujLEVfWMealwLetaGacIFFBsHPi = P_2;
					kPowbyAOjOXOrvcTZSxdWfbYLmJ.tszTRkROmrapuCTEblAHZJZKJOrE = P_3;
					return kPowbyAOjOXOrvcTZSxdWfbYLmJ;
				}

				private IEnumerable<ElementAssignmentConflictInfo> OVmodnTpthUtpqvipfivteyGGVL(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					wfSzKDUEsYseukmhzkNOzmFaBKS wfSzKDUEsYseukmhzkNOzmFaBKS2 = new wfSzKDUEsYseukmhzkNOzmFaBKS(-2);
					wfSzKDUEsYseukmhzkNOzmFaBKS2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					wfSzKDUEsYseukmhzkNOzmFaBKS2.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					wfSzKDUEsYseukmhzkNOzmFaBKS2.knCBLkNLXkuIFCDBlGcZsTysnZf = P_1;
					wfSzKDUEsYseukmhzkNOzmFaBKS2.zwrclSFEGAptHdMvIKRCbTPkMpdN = P_2;
					wfSzKDUEsYseukmhzkNOzmFaBKS2.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					wfSzKDUEsYseukmhzkNOzmFaBKS2.tszTRkROmrapuCTEblAHZJZKJOrE = P_4;
					return wfSzKDUEsYseukmhzkNOzmFaBKS2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> OVmodnTpthUtpqvipfivteyGGVL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					AXmkBPIiiCKpBJOcdpGJBHojezjC aXmkBPIiiCKpBJOcdpGJBHojezjC = new AXmkBPIiiCKpBJOcdpGJBHojezjC(-2);
					aXmkBPIiiCKpBJOcdpGJBHojezjC.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					aXmkBPIiiCKpBJOcdpGJBHojezjC.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					aXmkBPIiiCKpBJOcdpGJBHojezjC.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					aXmkBPIiiCKpBJOcdpGJBHojezjC.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					return aXmkBPIiiCKpBJOcdpGJBHojezjC;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bUTDGHUuYDffUhrbmCXprZxCMFET(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Keyboard, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> bUTDGHUuYDffUhrbmCXprZxCMFET(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> bUTDGHUuYDffUhrbmCXprZxCMFET(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return PUKvSnYZhztTPYKjBETQOaMFwgy(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> SypGFGjsRWpPuavtmcmMKAnLbyG(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Mouse, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> SypGFGjsRWpPuavtmcmMKAnLbyG(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return PUKvSnYZhztTPYKjBETQOaMFwgy(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> SypGFGjsRWpPuavtmcmMKAnLbyG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return PUKvSnYZhztTPYKjBETQOaMFwgy(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> baznHSJGgKGCZAcOofJRInLpyzmh(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					joWajsfFSNsqrurlfceHfdqfsLtu joWajsfFSNsqrurlfceHfdqfsLtu2 = new joWajsfFSNsqrurlfceHfdqfsLtu(-2);
					joWajsfFSNsqrurlfceHfdqfsLtu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					joWajsfFSNsqrurlfceHfdqfsLtu2.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					joWajsfFSNsqrurlfceHfdqfsLtu2.QtcRzqtvBSYDEvTRmsUPKyXubAx = P_1;
					joWajsfFSNsqrurlfceHfdqfsLtu2.jujLEVfWMealwLetaGacIFFBsHPi = P_2;
					joWajsfFSNsqrurlfceHfdqfsLtu2.tszTRkROmrapuCTEblAHZJZKJOrE = P_3;
					return joWajsfFSNsqrurlfceHfdqfsLtu2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> baznHSJGgKGCZAcOofJRInLpyzmh(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					RqahAxIDpMiFhkdUTNVZZtGVClB rqahAxIDpMiFhkdUTNVZZtGVClB = new RqahAxIDpMiFhkdUTNVZZtGVClB(-2);
					rqahAxIDpMiFhkdUTNVZZtGVClB.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					rqahAxIDpMiFhkdUTNVZZtGVClB.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					rqahAxIDpMiFhkdUTNVZZtGVClB.QtcRzqtvBSYDEvTRmsUPKyXubAx = P_1;
					rqahAxIDpMiFhkdUTNVZZtGVClB.zwrclSFEGAptHdMvIKRCbTPkMpdN = P_2;
					rqahAxIDpMiFhkdUTNVZZtGVClB.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					rqahAxIDpMiFhkdUTNVZZtGVClB.tszTRkROmrapuCTEblAHZJZKJOrE = P_4;
					return rqahAxIDpMiFhkdUTNVZZtGVClB;
				}

				private IEnumerable<ElementAssignmentConflictInfo> baznHSJGgKGCZAcOofJRInLpyzmh(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					wyPanLAKegnKkuXIYpfsmCqMBcpo wyPanLAKegnKkuXIYpfsmCqMBcpo2 = new wyPanLAKegnKkuXIYpfsmCqMBcpo(-2);
					wyPanLAKegnKkuXIYpfsmCqMBcpo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					wyPanLAKegnKkuXIYpfsmCqMBcpo2.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					wyPanLAKegnKkuXIYpfsmCqMBcpo2.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					wyPanLAKegnKkuXIYpfsmCqMBcpo2.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					return wyPanLAKegnKkuXIYpfsmCqMBcpo2;
				}

				private int xRqBqWbMswerNseUVdpgFLoCocek(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Joystick, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx);
						}
					}
					return num;
				}

				private int xRqBqWbMswerNseUVdpgFLoCocek(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx);
						}
					}
					return num;
				}

				private int xRqBqWbMswerNseUVdpgFLoCocek(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0.controllerId)
						{
							num += WBMczrVIDHFprFbklamWiPDzgKK(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx);
						}
					}
					return num;
				}

				private int GNfBhpBDaQXObKJdTfWawDZxlrIW(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Keyboard, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private int GNfBhpBDaQXObKJdTfWawDZxlrIW(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private int GNfBhpBDaQXObKJdTfWawDZxlrIW(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return WBMczrVIDHFprFbklamWiPDzgKK(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet);
				}

				private int gqRgLYwXhghsxJBnHxTPNtkOJtgd(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Mouse, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private int gqRgLYwXhghsxJBnHxTPNtkOJtgd(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private int gqRgLYwXhghsxJBnHxTPNtkOJtgd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return WBMczrVIDHFprFbklamWiPDzgKK(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet);
				}

				private int oEiLyVZoXriXDbfWEBQBSdqOeXM(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Custom, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx);
						}
					}
					return num;
				}

				private int oEiLyVZoXriXDbfWEBQBSdqOeXM(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += WBMczrVIDHFprFbklamWiPDzgKK(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx);
						}
					}
					return num;
				}

				private int oEiLyVZoXriXDbfWEBQBSdqOeXM(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0.controllerId)
						{
							num += WBMczrVIDHFprFbklamWiPDzgKK(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx);
						}
					}
					return num;
				}

				private int XrrakVLUIvJCxksvvkbBsiLCWry(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Joystick, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx, P_4);
						}
					}
					return num;
				}

				private int XrrakVLUIvJCxksvvkbBsiLCWry(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx, P_5);
						}
					}
					return num;
				}

				private int XrrakVLUIvJCxksvvkbBsiLCWry(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Count; i++)
					{
						Joystick pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0.controllerId)
						{
							num += UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.joystickSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx, P_3);
						}
					}
					return num;
				}

				private int SMvnpwePjOFzEdCsFoypuhhOqTFA(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Keyboard, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet, P_3);
				}

				private int SMvnpwePjOFzEdCsFoypuhhOqTFA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet, P_4);
				}

				private int SMvnpwePjOFzEdCsFoypuhhOqTFA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.keyboardMapSet, P_3);
				}

				private int jfjTCSLIZLJBNiRhECdBlZFntem(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Mouse, 0, P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet, P_3);
				}

				private int jfjTCSLIZLJBNiRhECdBlZFntem(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet, P_4);
				}

				private int jfjTCSLIZLJBNiRhECdBlZFntem(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.mouseMapSet, P_3);
				}

				private int gdHVmJgkjQzYIcgryrfgFLhgkJF(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Custom, P_0, P_1, P_2, P_3, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx, P_4);
						}
					}
					return num;
				}

				private int gdHVmJgkjQzYIcgryrfgFLhgkJF(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							num += UGqGgetPHsxNPYgSqVMUrunQPoY(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx, P_5);
						}
					}
					return num;
				}

				private int gdHVmJgkjQzYIcgryrfgFLhgkJF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Count; i++)
					{
						CustomController pxFOUEuAQwwDMNyKdQhVGxLNflI = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
						if (pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0.controllerId)
						{
							num += UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_2, IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet[i].nytTYXdOuEqgOKSTmLpKeODwQdx, P_3);
						}
					}
					return num;
				}

				private bool rIAztFUoGsfozaBNaLvltaNUjUM<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_5) where T : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return false;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_5.Count; i++)
					{
						ControllerMap controllerMap = P_5[i];
						if ((!P_3 || controllerMap.enabled) && (P_4 || !QYPnYCHXOtclVpNVmFuVatcerNh(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool rIAztFUoGsfozaBNaLvltaNUjUM<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_6) where T : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.Count; i++)
					{
						ControllerMap controllerMap = P_6[i];
						if ((!P_4 || controllerMap.enabled) && (P_5 || !QYPnYCHXOtclVpNVmFuVatcerNh(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool rIAztFUoGsfozaBNaLvltaNUjUM<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_3) where T : ControllerMap
				{
					if (P_3 == null)
					{
						return false;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return false;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_3.Count; i++)
					{
						ControllerMap controllerMap = P_3[i];
						if ((!P_1 || controllerMap.enabled) && (P_2 || !QYPnYCHXOtclVpNVmFuVatcerNh(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> PUKvSnYZhztTPYKjBETQOaMFwgy<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_5) where T : ControllerMap
				{
					LRLDUHOSiVLoqfYbxhxxIdPnMNH<T> lRLDUHOSiVLoqfYbxhxxIdPnMNH = new LRLDUHOSiVLoqfYbxhxxIdPnMNH<T>(-2);
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.LcfIxioPnFqYidkfjLRcvDEBZxW = P_0;
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.QbdCbTcQUefkyJDrkCJsqWRdkJf = P_1;
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.tMIlNOjAsUKwVsLWIYSEUFTHGtX = P_2;
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.tszTRkROmrapuCTEblAHZJZKJOrE = P_4;
					lRLDUHOSiVLoqfYbxhxxIdPnMNH.DBuGkmVwBFWupmCHcIikesbWRBt = P_5;
					return lRLDUHOSiVLoqfYbxhxxIdPnMNH;
				}

				private IEnumerable<ElementAssignmentConflictInfo> PUKvSnYZhztTPYKjBETQOaMFwgy<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_6) where T : ControllerMap
				{
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA<T> jiTQiKjMHyYOqYbeoKCbkLqhdYgA2 = new jiTQiKjMHyYOqYbeoKCbkLqhdYgA<T>(-2);
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.LcfIxioPnFqYidkfjLRcvDEBZxW = P_0;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.QbdCbTcQUefkyJDrkCJsqWRdkJf = P_1;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.tMIlNOjAsUKwVsLWIYSEUFTHGtX = P_2;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.PBfDvIDPVPOszqDGkeHFtEmMpGN = P_3;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.jujLEVfWMealwLetaGacIFFBsHPi = P_4;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.tszTRkROmrapuCTEblAHZJZKJOrE = P_5;
					jiTQiKjMHyYOqYbeoKCbkLqhdYgA2.DBuGkmVwBFWupmCHcIikesbWRBt = P_6;
					return jiTQiKjMHyYOqYbeoKCbkLqhdYgA2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> PUKvSnYZhztTPYKjBETQOaMFwgy<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_3) where T : ControllerMap
				{
					lpuvJUYczhOnHqWuujJfeNslFUP<T> lpuvJUYczhOnHqWuujJfeNslFUP2 = new lpuvJUYczhOnHqWuujJfeNslFUP<T>(-2);
					lpuvJUYczhOnHqWuujJfeNslFUP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					lpuvJUYczhOnHqWuujJfeNslFUP2.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					lpuvJUYczhOnHqWuujJfeNslFUP2.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					lpuvJUYczhOnHqWuujJfeNslFUP2.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					lpuvJUYczhOnHqWuujJfeNslFUP2.DBuGkmVwBFWupmCHcIikesbWRBt = P_3;
					return lpuvJUYczhOnHqWuujJfeNslFUP2;
				}

				private int WBMczrVIDHFprFbklamWiPDzgKK<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_5) where T : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.Count; i++)
					{
						ControllerMap controllerMap = P_5[i];
						if ((!P_3 || controllerMap.enabled) && (P_4 || !QYPnYCHXOtclVpNVmFuVatcerNh(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int WBMczrVIDHFprFbklamWiPDzgKK<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_6) where T : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.Count; i++)
					{
						ControllerMap controllerMap = P_6[i];
						if ((!P_4 || controllerMap.enabled) && (P_5 || !QYPnYCHXOtclVpNVmFuVatcerNh(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int WBMczrVIDHFprFbklamWiPDzgKK<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_3) where T : ControllerMap
				{
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.Count; i++)
					{
						ControllerMap controllerMap = P_3[i];
						if ((!P_1 || controllerMap.enabled) && (P_2 || !QYPnYCHXOtclVpNVmFuVatcerNh(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int UGqGgetPHsxNPYgSqVMUrunQPoY<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_5, List<ActionElementMap> P_6 = null) where T : ControllerMap
				{
					P_6?.Clear();
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.Count; i++)
					{
						ControllerMap controllerMap = P_5[i];
						if ((!P_3 || controllerMap.enabled) && (P_4 || !QYPnYCHXOtclVpNVmFuVatcerNh(mapCategory, controllerMap)))
						{
							num += controllerMap.UGqGgetPHsxNPYgSqVMUrunQPoY(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int UGqGgetPHsxNPYgSqVMUrunQPoY<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_6, List<ActionElementMap> P_7 = null) where T : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.Count; i++)
					{
						ControllerMap controllerMap = P_6[i];
						if ((!P_4 || controllerMap.enabled) && (P_5 || !QYPnYCHXOtclVpNVmFuVatcerNh(inputMapCategory, controllerMap)))
						{
							num += controllerMap.UGqGgetPHsxNPYgSqVMUrunQPoY(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int UGqGgetPHsxNPYgSqVMUrunQPoY<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::CimpQwMUTGMiTwuOvALwFOVgRyp<T> P_3, List<ActionElementMap> P_4 = null) where T : ControllerMap
				{
					P_4?.Clear();
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.Count; i++)
					{
						ControllerMap controllerMap = P_3[i];
						if ((!P_1 || controllerMap.enabled) && (P_2 || !QYPnYCHXOtclVpNVmFuVatcerNh(inputMapCategory, controllerMap)))
						{
							num += controllerMap.UGqGgetPHsxNPYgSqVMUrunQPoY(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool QYPnYCHXOtclVpNVmFuVatcerNh(InputMapCategory P_0, ControllerMap P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0.checkConflictsWithAllCategories)
					{
						return false;
					}
					IList<int> checkConflictsCategoryIds = P_0.checkConflictsCategoryIds;
					if (checkConflictsCategoryIds == null)
					{
						return true;
					}
					for (int i = 0; i < checkConflictsCategoryIds.Count; i++)
					{
						if (checkConflictsCategoryIds[i] == P_1.categoryId)
						{
							return false;
						}
					}
					return true;
				}
			}

			internal interface ozEDFrZmqchSdqXvkECRiiBJFWVg
			{
				jieiMfaxBWVupOguWuDBKohaarQ this[int index] { get; }

				ControllerType controllerType { get; }

				int Count { get; }

				bool YRagHVGgqrxCGUgBYtkIqvCxSddL(Controller P_0);

				bool YRagHVGgqrxCGUgBYtkIqvCxSddL(int P_0);

				void LRTqpOKaSyeswQyhlVNZgZllkau(int P_0);

				void LRTqpOKaSyeswQyhlVNZgZllkau(Controller P_0);

				void sSizjXaGummAfwQzjOxRTrpsaaY(int P_0);

				Controller ZbGtisIkVmOkbLNUAlpAicawGu(int P_0);

				Controller XLkibbsjMgAaKcvONPWosmQzExj(string P_0);

				int EZvGxHsqIFFuTapSiFVRnGzgbyW(Controller P_0);

				int EZvGxHsqIFFuTapSiFVRnGzgbyW(int P_0);

				int YZGeYkGlIGfrjfQjluTPpfRmhVOV(string P_0);

				void dLvQQBBPNcDLyfQfBHFGJrYJbsBD();

				jieiMfaxBWVupOguWuDBKohaarQ sGGfJsmegvsCOukIXQVwszxmlRT(int P_0);

				jieiMfaxBWVupOguWuDBKohaarQ sGGfJsmegvsCOukIXQVwszxmlRT(Controller P_0);

				void yyCUTFygyaeOphRDatdfpVepzGHn(jieiMfaxBWVupOguWuDBKohaarQ P_0);
			}

			internal interface jieiMfaxBWVupOguWuDBKohaarQ
			{
				aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet { get; }

				Controller controller { get; }

				double lastActiveTime { get; }
			}

			internal sealed class kbnxqpuiTgLkmUJPdswbZRMtQYO<TController, TMap> : ozEDFrZmqchSdqXvkECRiiBJFWVg where TController : Controller where TMap : ControllerMap
			{
				public class XMaIGYxSmxoTKaVsVqAuxacFodi : jieiMfaxBWVupOguWuDBKohaarQ
				{
					public TController pxFOUEuAQwwDMNyKdQhVGxLNflI;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<TMap> nytTYXdOuEqgOKSTmLpKeODwQdx;

					public double SSshgXtWAmLYnfrsdjIXHXblqzB;

					Controller jieiMfaxBWVupOguWuDBKohaarQ.controller => pxFOUEuAQwwDMNyKdQhVGxLNflI;

					aXnVKdRCFttLXjlGLvvowqKPhkUc jieiMfaxBWVupOguWuDBKohaarQ.mapSet => nytTYXdOuEqgOKSTmLpKeODwQdx;

					double jieiMfaxBWVupOguWuDBKohaarQ.lastActiveTime => SSshgXtWAmLYnfrsdjIXHXblqzB;

					public XMaIGYxSmxoTKaVsVqAuxacFodi(TController controller, global::CimpQwMUTGMiTwuOvALwFOVgRyp<TMap> mapSet)
					{
						pxFOUEuAQwwDMNyKdQhVGxLNflI = controller;
						nytTYXdOuEqgOKSTmLpKeODwQdx = mapSet;
					}

					public void ZqEEdiUDeOevjfnmGvhwDsnsnQm()
					{
						SSshgXtWAmLYnfrsdjIXHXblqzB = ReInput.unscaledTime;
					}
				}

				private List<XMaIGYxSmxoTKaVsVqAuxacFodi> JBeGhlFgiFxdOJckDGTWreONSQo;

				private List<TController> cfGODFbjtKaVDgoauYpCoaLDAvD;

				private ReadOnlyCollection<TController> HsNTaYgSNWmLEZPjezRJkaoRFfiC;

				private readonly ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

				public int Count => JBeGhlFgiFxdOJckDGTWreONSQo.Count;

				public IList<TController> Controllers_readOnly => HsNTaYgSNWmLEZPjezRJkaoRFfiC;

				public XMaIGYxSmxoTKaVsVqAuxacFodi this[int index] => JBeGhlFgiFxdOJckDGTWreONSQo[index];

				public ControllerType controllerType => beJOxBqDtyzXnNjzgKyRzARzFSQ;

				jieiMfaxBWVupOguWuDBKohaarQ ozEDFrZmqchSdqXvkECRiiBJFWVg.this[int index] => JBeGhlFgiFxdOJckDGTWreONSQo[index];

				public kbnxqpuiTgLkmUJPdswbZRMtQYO()
				{
					if (!object.ReferenceEquals(bEUEMZWgpCwBXKGSoWTyQESUVD.CwZeXoiPzKJANggANeOKVIlvMmmG<TController>(), typeof(TMap)))
					{
						throw new Exception(typeof(TController).Name + " cannot be used with a map of type " + typeof(TMap).Name);
					}
					beJOxBqDtyzXnNjzgKyRzARzFSQ = bEUEMZWgpCwBXKGSoWTyQESUVD.cBNLAYcmxbcLkZElXOxElVAbwGi(typeof(TController));
					JBeGhlFgiFxdOJckDGTWreONSQo = new List<XMaIGYxSmxoTKaVsVqAuxacFodi>();
					cfGODFbjtKaVDgoauYpCoaLDAvD = new List<TController>();
					HsNTaYgSNWmLEZPjezRJkaoRFfiC = new ReadOnlyCollection<TController>(cfGODFbjtKaVDgoauYpCoaLDAvD);
				}

				public XMaIGYxSmxoTKaVsVqAuxacFodi sGGfJsmegvsCOukIXQVwszxmlRT(int P_0)
				{
					if (beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Keyboard || beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
					if (num < 0)
					{
						return null;
					}
					return JBeGhlFgiFxdOJckDGTWreONSQo[num];
				}

				public XMaIGYxSmxoTKaVsVqAuxacFodi sGGfJsmegvsCOukIXQVwszxmlRT(TController P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return sGGfJsmegvsCOukIXQVwszxmlRT(P_0.id);
				}

				public void yyCUTFygyaeOphRDatdfpVepzGHn(XMaIGYxSmxoTKaVsVqAuxacFodi P_0)
				{
					if (P_0 != null)
					{
						JBeGhlFgiFxdOJckDGTWreONSQo.Add(P_0);
						cfGODFbjtKaVDgoauYpCoaLDAvD.Add(P_0.pxFOUEuAQwwDMNyKdQhVGxLNflI);
					}
				}

				public void LRTqpOKaSyeswQyhlVNZgZllkau(int P_0)
				{
					if (beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Keyboard || beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
					if (num < 0)
					{
						return;
					}
					for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Count; i++)
					{
						if (JBeGhlFgiFxdOJckDGTWreONSQo[i].pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							sSizjXaGummAfwQzjOxRTrpsaaY(i);
							break;
						}
					}
				}

				void ozEDFrZmqchSdqXvkECRiiBJFWVg.LRTqpOKaSyeswQyhlVNZgZllkau(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in LRTqpOKaSyeswQyhlVNZgZllkau
					this.LRTqpOKaSyeswQyhlVNZgZllkau(P_0);
				}

				public void LRTqpOKaSyeswQyhlVNZgZllkau(TController P_0)
				{
					if (P_0 != null && P_0.type == beJOxBqDtyzXnNjzgKyRzARzFSQ)
					{
						LRTqpOKaSyeswQyhlVNZgZllkau(P_0.id);
					}
				}

				public void sSizjXaGummAfwQzjOxRTrpsaaY(int P_0)
				{
					if (P_0 >= 0 && P_0 < JBeGhlFgiFxdOJckDGTWreONSQo.Count)
					{
						JBeGhlFgiFxdOJckDGTWreONSQo.RemoveAt(P_0);
						cfGODFbjtKaVDgoauYpCoaLDAvD.RemoveAt(P_0);
					}
				}

				void ozEDFrZmqchSdqXvkECRiiBJFWVg.sSizjXaGummAfwQzjOxRTrpsaaY(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in sSizjXaGummAfwQzjOxRTrpsaaY
					this.sSizjXaGummAfwQzjOxRTrpsaaY(P_0);
				}

				public TController ZbGtisIkVmOkbLNUAlpAicawGu(int P_0)
				{
					if (beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Keyboard || beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
					if (num < 0)
					{
						return null;
					}
					return JBeGhlFgiFxdOJckDGTWreONSQo[num].pxFOUEuAQwwDMNyKdQhVGxLNflI;
				}

				public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(int P_0)
				{
					if (beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Keyboard || beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Count; i++)
					{
						if (JBeGhlFgiFxdOJckDGTWreONSQo[i].pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool ozEDFrZmqchSdqXvkECRiiBJFWVg.YRagHVGgqrxCGUgBYtkIqvCxSddL(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in YRagHVGgqrxCGUgBYtkIqvCxSddL
					return this.YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0);
				}

				public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(TController P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != beJOxBqDtyzXnNjzgKyRzARzFSQ)
					{
						return false;
					}
					return YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0.id);
				}

				public int EZvGxHsqIFFuTapSiFVRnGzgbyW(int P_0)
				{
					if (beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Keyboard || beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Count; i++)
					{
						if (JBeGhlFgiFxdOJckDGTWreONSQo[i].pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int ozEDFrZmqchSdqXvkECRiiBJFWVg.EZvGxHsqIFFuTapSiFVRnGzgbyW(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in EZvGxHsqIFFuTapSiFVRnGzgbyW
					return this.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
				}

				public int EZvGxHsqIFFuTapSiFVRnGzgbyW(TController P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != beJOxBqDtyzXnNjzgKyRzARzFSQ)
					{
						return -1;
					}
					return EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0.id);
				}

				public int YZGeYkGlIGfrjfQjluTPpfRmhVOV(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Count; i++)
					{
						if (JBeGhlFgiFxdOJckDGTWreONSQo[i].pxFOUEuAQwwDMNyKdQhVGxLNflI.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int ozEDFrZmqchSdqXvkECRiiBJFWVg.YZGeYkGlIGfrjfQjluTPpfRmhVOV(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in YZGeYkGlIGfrjfQjluTPpfRmhVOV
					return this.YZGeYkGlIGfrjfQjluTPpfRmhVOV(P_0);
				}

				public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
				{
					JBeGhlFgiFxdOJckDGTWreONSQo.Clear();
					cfGODFbjtKaVDgoauYpCoaLDAvD.Clear();
				}

				void ozEDFrZmqchSdqXvkECRiiBJFWVg.dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
				{
					//ILSpy generated this explicit interface implementation from .override directive in dLvQQBBPNcDLyfQfBHFGJrYJbsBD
					this.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}

				private jieiMfaxBWVupOguWuDBKohaarQ crwGBTciyVDAKdixhMPBeoKQoAx(int P_0)
				{
					return sGGfJsmegvsCOukIXQVwszxmlRT(P_0);
				}

				jieiMfaxBWVupOguWuDBKohaarQ ozEDFrZmqchSdqXvkECRiiBJFWVg.sGGfJsmegvsCOukIXQVwszxmlRT(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in crwGBTciyVDAKdixhMPBeoKQoAx
					return this.crwGBTciyVDAKdixhMPBeoKQoAx(P_0);
				}

				private jieiMfaxBWVupOguWuDBKohaarQ crwGBTciyVDAKdixhMPBeoKQoAx(Controller P_0)
				{
					if (P_0 as TController == null)
					{
						return null;
					}
					return sGGfJsmegvsCOukIXQVwszxmlRT(P_0 as TController);
				}

				jieiMfaxBWVupOguWuDBKohaarQ ozEDFrZmqchSdqXvkECRiiBJFWVg.sGGfJsmegvsCOukIXQVwszxmlRT(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in crwGBTciyVDAKdixhMPBeoKQoAx
					return this.crwGBTciyVDAKdixhMPBeoKQoAx(P_0);
				}

				private void gHgDdHiKukCtryqueCeRemPNgCvE(jieiMfaxBWVupOguWuDBKohaarQ P_0)
				{
					yyCUTFygyaeOphRDatdfpVepzGHn((XMaIGYxSmxoTKaVsVqAuxacFodi)P_0);
				}

				void ozEDFrZmqchSdqXvkECRiiBJFWVg.yyCUTFygyaeOphRDatdfpVepzGHn(jieiMfaxBWVupOguWuDBKohaarQ P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in gHgDdHiKukCtryqueCeRemPNgCvE
					this.gHgDdHiKukCtryqueCeRemPNgCvE(P_0);
				}

				private void DFNwbTyNmumDpqVzyhlKQfqPfiS(Controller P_0)
				{
					LRTqpOKaSyeswQyhlVNZgZllkau(P_0 as TController);
				}

				void ozEDFrZmqchSdqXvkECRiiBJFWVg.LRTqpOKaSyeswQyhlVNZgZllkau(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in DFNwbTyNmumDpqVzyhlKQfqPfiS
					this.DFNwbTyNmumDpqVzyhlKQfqPfiS(P_0);
				}

				private Controller CETCDoisEhjOOGWAfTBjdgdkvQot(int P_0)
				{
					return ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
				}

				Controller ozEDFrZmqchSdqXvkECRiiBJFWVg.ZbGtisIkVmOkbLNUAlpAicawGu(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in CETCDoisEhjOOGWAfTBjdgdkvQot
					return this.CETCDoisEhjOOGWAfTBjdgdkvQot(P_0);
				}

				private bool aSyfTwDgoOkCeJKITCcwgvzrQtz(Controller P_0)
				{
					return YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0 as TController);
				}

				bool ozEDFrZmqchSdqXvkECRiiBJFWVg.YRagHVGgqrxCGUgBYtkIqvCxSddL(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in aSyfTwDgoOkCeJKITCcwgvzrQtz
					return this.aSyfTwDgoOkCeJKITCcwgvzrQtz(P_0);
				}

				private int GUdqqwXxwecIHWssCbxfIYDcGhT(Controller P_0)
				{
					return EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0 as TController);
				}

				int ozEDFrZmqchSdqXvkECRiiBJFWVg.EZvGxHsqIFFuTapSiFVRnGzgbyW(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in GUdqqwXxwecIHWssCbxfIYDcGhT
					return this.GUdqqwXxwecIHWssCbxfIYDcGhT(P_0);
				}

				private Controller VjlvzChlWacOgufBMGpMDBAgcpz(string P_0)
				{
					int num = YZGeYkGlIGfrjfQjluTPpfRmhVOV(P_0);
					if (num < 0)
					{
						return null;
					}
					return JBeGhlFgiFxdOJckDGTWreONSQo[num].pxFOUEuAQwwDMNyKdQhVGxLNflI;
				}

				Controller ozEDFrZmqchSdqXvkECRiiBJFWVg.XLkibbsjMgAaKcvONPWosmQzExj(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in VjlvzChlWacOgufBMGpMDBAgcpz
					return this.VjlvzChlWacOgufBMGpMDBAgcpz(P_0);
				}
			}

			internal class yIJYYECjyPGJVHuwiNkBdeHkvDn
			{
				public readonly int SpePdqugXpdSjGsMuRlyMjmlhHiD;

				private ControllerType[] wRXGvHIoGXrtfrXsFcOssnzdtFQ;

				private ozEDFrZmqchSdqXvkECRiiBJFWVg[] XlGWzTbBfmAhMjPFhAECJrEzBmuL;

				public ozEDFrZmqchSdqXvkECRiiBJFWVg JgFRckJPlsxwwoDknLaNPBypefe(int P_0)
				{
					return XlGWzTbBfmAhMjPFhAECJrEzBmuL[P_0];
				}

				public ControllerType xSAghSIVTBORbOgzbIHOvBeeOML(int P_0)
				{
					return wRXGvHIoGXrtfrXsFcOssnzdtFQ[P_0];
				}

				public yIJYYECjyPGJVHuwiNkBdeHkvDn(int length)
				{
					SpePdqugXpdSjGsMuRlyMjmlhHiD = MathTools.Max(0, length);
					wRXGvHIoGXrtfrXsFcOssnzdtFQ = new ControllerType[length];
					XlGWzTbBfmAhMjPFhAECJrEzBmuL = new ozEDFrZmqchSdqXvkECRiiBJFWVg[length];
				}

				public ozEDFrZmqchSdqXvkECRiiBJFWVg PErbMByiRLpfURxMubXbNOTjLuS(ControllerType P_0)
				{
					for (int i = 0; i < SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						if (P_0 == wRXGvHIoGXrtfrXsFcOssnzdtFQ[i])
						{
							return XlGWzTbBfmAhMjPFhAECJrEzBmuL[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void oZApGyNkPpBNhUUhbjNZjYkbbvC(int P_0, ControllerType P_1, ozEDFrZmqchSdqXvkECRiiBJFWVg P_2)
				{
					wRXGvHIoGXrtfrXsFcOssnzdtFQ[P_0] = P_1;
					XlGWzTbBfmAhMjPFhAECJrEzBmuL[P_0] = P_2;
				}
			}

			private class zxiPetcpStGdKraGRhVxmYBYdoV
			{
				public class hngEDaAqCbNinGghamFnidMGbbzL
				{
					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> nytTYXdOuEqgOKSTmLpKeODwQdx;

					public double pyPmPvjEEueDSBngCIxCGSXcOaC;

					public hngEDaAqCbNinGghamFnidMGbbzL(int joystickId, global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> mapSet, double lastConnectedTime)
					{
						OxaYhfaGlOIumOWmOozrcdXdBYi = joystickId;
						nytTYXdOuEqgOKSTmLpKeODwQdx = mapSet;
						pyPmPvjEEueDSBngCIxCGSXcOaC = lastConnectedTime;
					}
				}

				private readonly List<hngEDaAqCbNinGghamFnidMGbbzL> fopcRAyqeBjmZPOELjthAdVYQiB;

				private readonly Player gESwCZhPTVpAneBRVEYFzquNJMi;

				public zxiPetcpStGdKraGRhVxmYBYdoV(Player player)
				{
					gESwCZhPTVpAneBRVEYFzquNJMi = player;
					fopcRAyqeBjmZPOELjthAdVYQiB = new List<hngEDaAqCbNinGghamFnidMGbbzL>();
				}

				public void pNtVjMTCwjmfvmJXawLBYkfoTpi(Joystick P_0, global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> P_1)
				{
					for (int i = 0; i < fopcRAyqeBjmZPOELjthAdVYQiB.Count; i++)
					{
						hngEDaAqCbNinGghamFnidMGbbzL hngEDaAqCbNinGghamFnidMGbbzL2 = fopcRAyqeBjmZPOELjthAdVYQiB[i];
						if (hngEDaAqCbNinGghamFnidMGbbzL2.OxaYhfaGlOIumOWmOozrcdXdBYi == P_0.id)
						{
							hngEDaAqCbNinGghamFnidMGbbzL2.nytTYXdOuEqgOKSTmLpKeODwQdx = P_1;
							hngEDaAqCbNinGghamFnidMGbbzL2.pyPmPvjEEueDSBngCIxCGSXcOaC = ReInput.realTime;
							return;
						}
					}
					hngEDaAqCbNinGghamFnidMGbbzL item = new hngEDaAqCbNinGghamFnidMGbbzL(P_0.id, P_1, ReInput.realTime);
					fopcRAyqeBjmZPOELjthAdVYQiB.Add(item);
				}

				public void pNtVjMTCwjmfvmJXawLBYkfoTpi(kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi P_0)
				{
					pNtVjMTCwjmfvmJXawLBYkfoTpi(P_0.pxFOUEuAQwwDMNyKdQhVGxLNflI, P_0.nytTYXdOuEqgOKSTmLpKeODwQdx);
				}

				public void tQZTPgWjVqUoeRxXBpobvheRKCQ()
				{
					for (int i = 0; i < fopcRAyqeBjmZPOELjthAdVYQiB.Count; i++)
					{
						if (!gESwCZhPTVpAneBRVEYFzquNJMi.controllers.ContainsController(ControllerType.Joystick, fopcRAyqeBjmZPOELjthAdVYQiB[i].OxaYhfaGlOIumOWmOozrcdXdBYi))
						{
							fopcRAyqeBjmZPOELjthAdVYQiB[i].nytTYXdOuEqgOKSTmLpKeODwQdx = null;
						}
					}
				}

				public hngEDaAqCbNinGghamFnidMGbbzL SrKtvymlKprndkinEFXJTDBelLJ(int P_0)
				{
					int num = EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
					if (num < 0)
					{
						return null;
					}
					return fopcRAyqeBjmZPOELjthAdVYQiB[num];
				}

				public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(int P_0)
				{
					for (int i = 0; i < fopcRAyqeBjmZPOELjthAdVYQiB.Count; i++)
					{
						if (fopcRAyqeBjmZPOELjthAdVYQiB[i].OxaYhfaGlOIumOWmOozrcdXdBYi == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int EZvGxHsqIFFuTapSiFVRnGzgbyW(int P_0)
				{
					for (int i = 0; i < fopcRAyqeBjmZPOELjthAdVYQiB.Count; i++)
					{
						if (fopcRAyqeBjmZPOELjthAdVYQiB[i].OxaYhfaGlOIumOWmOozrcdXdBYi == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
				{
					fopcRAyqeBjmZPOELjthAdVYQiB.Clear();
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class LWxNXTOxiJhCwDJcZDKPZBqXqaK : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int NpLwVCySmrHjRKnjKEUnoNnHJJy;

					public int EaWdcFhMCWgetEeevahAjbRVArmF;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg ApkoGGTQzfroFvpnRORvVuZWjgM;

					public int JvOFyNcFibtSMJnvNXVYObJnbqQe;

					public int yIMOwLuEXFphVooIogzNFDXvsgy;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc OpXjJGdFeTGfpEsdZLUvLloxnIC;

					public int jXlaxvnLRdpSkioKaseLzboPbca;

					public int hoADhaIBLGgogfyTDoYQSgXVASX;

					ControllerMap IEnumerator<ControllerMap>.Current
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						LWxNXTOxiJhCwDJcZDKPZBqXqaK lWxNXTOxiJhCwDJcZDKPZBqXqaK;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							lWxNXTOxiJhCwDJcZDKPZBqXqaK = this;
						}
						else
						{
							lWxNXTOxiJhCwDJcZDKPZBqXqaK = new LWxNXTOxiJhCwDJcZDKPZBqXqaK(0);
							lWxNXTOxiJhCwDJcZDKPZBqXqaK.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return lWxNXTOxiJhCwDJcZDKPZBqXqaK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
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
							NpLwVCySmrHjRKnjKEUnoNnHJJy = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
							EaWdcFhMCWgetEeevahAjbRVArmF = 0;
							goto IL_0154;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								hoADhaIBLGgogfyTDoYQSgXVASX++;
								goto IL_0119;
							}
							IL_0119:
							if (hoADhaIBLGgogfyTDoYQSgXVASX < jXlaxvnLRdpSkioKaseLzboPbca)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = OpXjJGdFeTGfpEsdZLUvLloxnIC[hoADhaIBLGgogfyTDoYQSgXVASX];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								return true;
							}
							yIMOwLuEXFphVooIogzNFDXvsgy++;
							goto IL_0135;
							IL_0135:
							if (yIMOwLuEXFphVooIogzNFDXvsgy < JvOFyNcFibtSMJnvNXVYObJnbqQe)
							{
								OpXjJGdFeTGfpEsdZLUvLloxnIC = ApkoGGTQzfroFvpnRORvVuZWjgM[yIMOwLuEXFphVooIogzNFDXvsgy].mapSet;
								jXlaxvnLRdpSkioKaseLzboPbca = OpXjJGdFeTGfpEsdZLUvLloxnIC.Count;
								hoADhaIBLGgogfyTDoYQSgXVASX = 0;
								goto IL_0119;
							}
							EaWdcFhMCWgetEeevahAjbRVArmF++;
							goto IL_0154;
							IL_0154:
							if (EaWdcFhMCWgetEeevahAjbRVArmF >= NpLwVCySmrHjRKnjKEUnoNnHJJy)
							{
								break;
							}
							ApkoGGTQzfroFvpnRORvVuZWjgM = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(EaWdcFhMCWgetEeevahAjbRVArmF);
							JvOFyNcFibtSMJnvNXVYObJnbqQe = ApkoGGTQzfroFvpnRORvVuZWjgM.Count;
							yIMOwLuEXFphVooIogzNFDXvsgy = 0;
							goto IL_0135;
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
					public LWxNXTOxiJhCwDJcZDKPZBqXqaK(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class ewOFUOGTxZMbarYDkQqthfuZnVw<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<T>, IEnumerator<T> where T : ControllerMap
				{
					private T ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType VexKgiQlqwuDwQyNPAOoCqUimlX;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg MuAjXAtPkcPAJQJWWbaOIpqNNIQ;

					public int klQRAwVxecFWUNYncmumJnTGeoee;

					public int wpoVTUWrqPtsXzKBSJPLjfvjKgG;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc gKyRAsWvpjqfuKIlDseAZLkiEJzB;

					public int ZCdUNBbFMRpXgdNDAvRxsCylNcX;

					public int rCkippwyhlTMFBSWQUcutzAyydg;

					public int cqATPnANABamkkMltlHxZAGlhNZx;

					public int fwEahJjOjkkliMuxyoEPBMmzcYfF;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg JdDdcikfMpwYUfNvBwKjCVAPrjC;

					public int HPptdPFCkKdLXoRLhTUyAVKikRV;

					public int pPdjgmSAzEMWekfFLwugclFYZXU;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc sfKtSDebFIsOHrvDgIMmmMdEETDK;

					public int AnlGsDzLBGwEowboaMshLhqiqIi;

					public int mgCFTFCmxoRgBaJeFnmqaJlJfbTk;

					public T BWtpLvmvKgzVxrubIsOuujxMPSI;

					T IEnumerator<T>.Current
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
					IEnumerator<T> IEnumerable<T>.GetEnumerator()
					{
						ewOFUOGTxZMbarYDkQqthfuZnVw<T> ewOFUOGTxZMbarYDkQqthfuZnVw2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							ewOFUOGTxZMbarYDkQqthfuZnVw2 = this;
						}
						else
						{
							ewOFUOGTxZMbarYDkQqthfuZnVw2 = new ewOFUOGTxZMbarYDkQqthfuZnVw<T>(0);
							ewOFUOGTxZMbarYDkQqthfuZnVw2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return ewOFUOGTxZMbarYDkQqthfuZnVw2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<T>)this).GetEnumerator();
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
							if (bEUEMZWgpCwBXKGSoWTyQESUVD.YMoLVIIWiTPkmefXIKyfZeEBOIY<T>(out VexKgiQlqwuDwQyNPAOoCqUimlX))
							{
								MuAjXAtPkcPAJQJWWbaOIpqNNIQ = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(VexKgiQlqwuDwQyNPAOoCqUimlX);
								klQRAwVxecFWUNYncmumJnTGeoee = MuAjXAtPkcPAJQJWWbaOIpqNNIQ.Count;
								wpoVTUWrqPtsXzKBSJPLjfvjKgG = 0;
								goto IL_0127;
							}
							cqATPnANABamkkMltlHxZAGlhNZx = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
							fwEahJjOjkkliMuxyoEPBMmzcYfF = 0;
							goto IL_026b;
						case 1:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							rCkippwyhlTMFBSWQUcutzAyydg++;
							goto IL_010b;
						case 2:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								goto IL_0222;
							}
							IL_024c:
							if (pPdjgmSAzEMWekfFLwugclFYZXU < HPptdPFCkKdLXoRLhTUyAVKikRV)
							{
								sfKtSDebFIsOHrvDgIMmmMdEETDK = JdDdcikfMpwYUfNvBwKjCVAPrjC[pPdjgmSAzEMWekfFLwugclFYZXU].mapSet;
								AnlGsDzLBGwEowboaMshLhqiqIi = sfKtSDebFIsOHrvDgIMmmMdEETDK.Count;
								mgCFTFCmxoRgBaJeFnmqaJlJfbTk = 0;
								goto IL_0230;
							}
							fwEahJjOjkkliMuxyoEPBMmzcYfF++;
							goto IL_026b;
							IL_0230:
							if (mgCFTFCmxoRgBaJeFnmqaJlJfbTk < AnlGsDzLBGwEowboaMshLhqiqIi)
							{
								BWtpLvmvKgzVxrubIsOuujxMPSI = sfKtSDebFIsOHrvDgIMmmMdEETDK[mgCFTFCmxoRgBaJeFnmqaJlJfbTk] as T;
								if (BWtpLvmvKgzVxrubIsOuujxMPSI != null)
								{
									ajbaQItphrIyqhowgmMTfPkCBvcN = BWtpLvmvKgzVxrubIsOuujxMPSI;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								goto IL_0222;
							}
							pPdjgmSAzEMWekfFLwugclFYZXU++;
							goto IL_024c;
							IL_026b:
							if (fwEahJjOjkkliMuxyoEPBMmzcYfF >= cqATPnANABamkkMltlHxZAGlhNZx)
							{
								break;
							}
							JdDdcikfMpwYUfNvBwKjCVAPrjC = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(fwEahJjOjkkliMuxyoEPBMmzcYfF);
							HPptdPFCkKdLXoRLhTUyAVKikRV = JdDdcikfMpwYUfNvBwKjCVAPrjC.Count;
							pPdjgmSAzEMWekfFLwugclFYZXU = 0;
							goto IL_024c;
							IL_0127:
							if (wpoVTUWrqPtsXzKBSJPLjfvjKgG < klQRAwVxecFWUNYncmumJnTGeoee)
							{
								gKyRAsWvpjqfuKIlDseAZLkiEJzB = MuAjXAtPkcPAJQJWWbaOIpqNNIQ[wpoVTUWrqPtsXzKBSJPLjfvjKgG].mapSet;
								ZCdUNBbFMRpXgdNDAvRxsCylNcX = gKyRAsWvpjqfuKIlDseAZLkiEJzB.Count;
								rCkippwyhlTMFBSWQUcutzAyydg = 0;
								goto IL_010b;
							}
							break;
							IL_0222:
							mgCFTFCmxoRgBaJeFnmqaJlJfbTk++;
							goto IL_0230;
							IL_010b:
							if (rCkippwyhlTMFBSWQUcutzAyydg < ZCdUNBbFMRpXgdNDAvRxsCylNcX)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = (T)gKyRAsWvpjqfuKIlDseAZLkiEJzB[rCkippwyhlTMFBSWQUcutzAyydg];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								return true;
							}
							wpoVTUWrqPtsXzKBSJPLjfvjKgG++;
							goto IL_0127;
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
					public ewOFUOGTxZMbarYDkQqthfuZnVw(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class ZwUayOoJmtjVzYyNOwNBFLWtjLR : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg xwAlpMkaqisrvNNyqfZrVPqZfkbE;

					public int RVmVriZWfhvGuDNwwSrkjuWjwkC;

					public int GHYjIRXLBKFmjXOgCTMdZdjDhVt;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc jAuQkKeFPZkQeUaAlpXDJhogyLJ;

					public int eeXVPqqyMIKFNfhUkiSoxNTWzV;

					public int oeLKrysapwDbKiIEnMbYhuMZmQaD;

					ControllerMap IEnumerator<ControllerMap>.Current
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						ZwUayOoJmtjVzYyNOwNBFLWtjLR zwUayOoJmtjVzYyNOwNBFLWtjLR;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							zwUayOoJmtjVzYyNOwNBFLWtjLR = this;
						}
						else
						{
							zwUayOoJmtjVzYyNOwNBFLWtjLR = new ZwUayOoJmtjVzYyNOwNBFLWtjLR(0);
							zwUayOoJmtjVzYyNOwNBFLWtjLR.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						zwUayOoJmtjVzYyNOwNBFLWtjLR.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						return zwUayOoJmtjVzYyNOwNBFLWtjLR;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
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
							xwAlpMkaqisrvNNyqfZrVPqZfkbE = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
							RVmVriZWfhvGuDNwwSrkjuWjwkC = xwAlpMkaqisrvNNyqfZrVPqZfkbE.Count;
							GHYjIRXLBKFmjXOgCTMdZdjDhVt = 0;
							goto IL_010e;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								oeLKrysapwDbKiIEnMbYhuMZmQaD++;
								goto IL_00f2;
							}
							IL_010e:
							if (GHYjIRXLBKFmjXOgCTMdZdjDhVt >= RVmVriZWfhvGuDNwwSrkjuWjwkC)
							{
								break;
							}
							jAuQkKeFPZkQeUaAlpXDJhogyLJ = xwAlpMkaqisrvNNyqfZrVPqZfkbE[GHYjIRXLBKFmjXOgCTMdZdjDhVt].mapSet;
							eeXVPqqyMIKFNfhUkiSoxNTWzV = jAuQkKeFPZkQeUaAlpXDJhogyLJ.Count;
							oeLKrysapwDbKiIEnMbYhuMZmQaD = 0;
							goto IL_00f2;
							IL_00f2:
							if (oeLKrysapwDbKiIEnMbYhuMZmQaD < eeXVPqqyMIKFNfhUkiSoxNTWzV)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = jAuQkKeFPZkQeUaAlpXDJhogyLJ[oeLKrysapwDbKiIEnMbYhuMZmQaD];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								return true;
							}
							GHYjIRXLBKFmjXOgCTMdZdjDhVt++;
							goto IL_010e;
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
					public ZwUayOoJmtjVzYyNOwNBFLWtjLR(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class AdizKfGohmNxxiNGIgCcqUDlwyl : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int xPeeFDuTocYwnhaJrBCbItlrDKAe;

					public int GRdOpxNKCFYWbmqOeDFezHUKcsBb;

					public int QoPlkjsRLTpPiodWGNAnPCctieP;

					public int kRXjlVbaKetiAVWAAmxLISByNFG;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg TYlvFEynvQllXEAylEauTmvBEAU;

					public int QyLgHPJqjXufwauRcawaFtcWkNY;

					public int eyHbVfdNXLUFEIposekzxoaGJDHV;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc bpExDfvdjjpPxouAPwqoGkJOfTIA;

					public int zgGVgwQpnYARjVnwdIaDvPIeIpJ;

					public int rxFZvJMzpNkTqQVpsAHBslVVpTd;

					public ControllerMap hoLeQEvuuDMdNaYAHNYWcwXguqm;

					ControllerMap IEnumerator<ControllerMap>.Current
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						AdizKfGohmNxxiNGIgCcqUDlwyl adizKfGohmNxxiNGIgCcqUDlwyl;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							adizKfGohmNxxiNGIgCcqUDlwyl = this;
						}
						else
						{
							adizKfGohmNxxiNGIgCcqUDlwyl = new AdizKfGohmNxxiNGIgCcqUDlwyl(0);
							adizKfGohmNxxiNGIgCcqUDlwyl.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						adizKfGohmNxxiNGIgCcqUDlwyl.xPeeFDuTocYwnhaJrBCbItlrDKAe = GRdOpxNKCFYWbmqOeDFezHUKcsBb;
						return adizKfGohmNxxiNGIgCcqUDlwyl;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
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
							QoPlkjsRLTpPiodWGNAnPCctieP = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
							kRXjlVbaKetiAVWAAmxLISByNFG = 0;
							goto IL_0173;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								goto IL_012a;
							}
							IL_0154:
							if (eyHbVfdNXLUFEIposekzxoaGJDHV < QyLgHPJqjXufwauRcawaFtcWkNY)
							{
								bpExDfvdjjpPxouAPwqoGkJOfTIA = TYlvFEynvQllXEAylEauTmvBEAU[eyHbVfdNXLUFEIposekzxoaGJDHV].mapSet;
								zgGVgwQpnYARjVnwdIaDvPIeIpJ = bpExDfvdjjpPxouAPwqoGkJOfTIA.Count;
								rxFZvJMzpNkTqQVpsAHBslVVpTd = 0;
								goto IL_0138;
							}
							kRXjlVbaKetiAVWAAmxLISByNFG++;
							goto IL_0173;
							IL_0138:
							if (rxFZvJMzpNkTqQVpsAHBslVVpTd < zgGVgwQpnYARjVnwdIaDvPIeIpJ)
							{
								hoLeQEvuuDMdNaYAHNYWcwXguqm = bpExDfvdjjpPxouAPwqoGkJOfTIA[rxFZvJMzpNkTqQVpsAHBslVVpTd];
								if (hoLeQEvuuDMdNaYAHNYWcwXguqm.categoryId == xPeeFDuTocYwnhaJrBCbItlrDKAe)
								{
									ajbaQItphrIyqhowgmMTfPkCBvcN = hoLeQEvuuDMdNaYAHNYWcwXguqm;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									return true;
								}
								goto IL_012a;
							}
							eyHbVfdNXLUFEIposekzxoaGJDHV++;
							goto IL_0154;
							IL_0173:
							if (kRXjlVbaKetiAVWAAmxLISByNFG >= QoPlkjsRLTpPiodWGNAnPCctieP)
							{
								break;
							}
							TYlvFEynvQllXEAylEauTmvBEAU = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(kRXjlVbaKetiAVWAAmxLISByNFG);
							QyLgHPJqjXufwauRcawaFtcWkNY = TYlvFEynvQllXEAylEauTmvBEAU.Count;
							eyHbVfdNXLUFEIposekzxoaGJDHV = 0;
							goto IL_0154;
							IL_012a:
							rxFZvJMzpNkTqQVpsAHBslVVpTd++;
							goto IL_0138;
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
					public AdizKfGohmNxxiNGIgCcqUDlwyl(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class HBYgdpdfERlJbNmhVYGKldDXJZcD<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<T>, IEnumerator<T> where T : ControllerMap
				{
					private T ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int xPeeFDuTocYwnhaJrBCbItlrDKAe;

					public int GRdOpxNKCFYWbmqOeDFezHUKcsBb;

					public ControllerType SnENqrCvVGmQELpWwZSkwPJNekm;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg nJhDzphVvCvwpPjGUmxWlzjFMrgq;

					public int vIdPOwdOkURSiMVOZvmnOnyOEHbF;

					public int sFiBPqcSRdhPeISTmsrBkDXqtZnT;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc YnYfPKGuCqrXpWUSMjtjVrGiLOW;

					public int iWDZVTBnCABTAofybAPDIMJRmcO;

					public int pafaWteasWnpfgSsJQJuCfoHtfCl;

					public ControllerMap vLLfdzDyegwynIBYLjxjhzdWoZfl;

					public int ykYmwoKeTBTzSYNeGxwadnlPVaU;

					public int wImHsOCJtwIdjKEnuMlEvJdeALq;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg elVJwCEEmeNxtLYwNDlRVlvBuPD;

					public int HRckiPKvyexXmqUESdWqbUnjcYQ;

					public int whdZzJMqXGhhJMInwWIUGiFZCmZ;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc OVGnvStPVHhnmUoEyurHavhDIwI;

					public int QFKWlRkdQkKJifibUTOuSGZusuP;

					public int GikEIifpcDtKrfDYDmhxlyZycawj;

					public T tzHZFZAhwOdcHCqCHfbaXCrAaFNb;

					T IEnumerator<T>.Current
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
					IEnumerator<T> IEnumerable<T>.GetEnumerator()
					{
						HBYgdpdfERlJbNmhVYGKldDXJZcD<T> hBYgdpdfERlJbNmhVYGKldDXJZcD;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							hBYgdpdfERlJbNmhVYGKldDXJZcD = this;
						}
						else
						{
							hBYgdpdfERlJbNmhVYGKldDXJZcD = new HBYgdpdfERlJbNmhVYGKldDXJZcD<T>(0);
							hBYgdpdfERlJbNmhVYGKldDXJZcD.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						hBYgdpdfERlJbNmhVYGKldDXJZcD.xPeeFDuTocYwnhaJrBCbItlrDKAe = GRdOpxNKCFYWbmqOeDFezHUKcsBb;
						return hBYgdpdfERlJbNmhVYGKldDXJZcD;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<T>)this).GetEnumerator();
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
							if (bEUEMZWgpCwBXKGSoWTyQESUVD.YMoLVIIWiTPkmefXIKyfZeEBOIY<T>(out SnENqrCvVGmQELpWwZSkwPJNekm))
							{
								nJhDzphVvCvwpPjGUmxWlzjFMrgq = kdBZqupjvsCsVkwJiOeEQzkEDVO.xNElrBHIPiHboiHFMzuctndwTLY<T>();
								vIdPOwdOkURSiMVOZvmnOnyOEHbF = nJhDzphVvCvwpPjGUmxWlzjFMrgq.Count;
								sFiBPqcSRdhPeISTmsrBkDXqtZnT = 0;
								goto IL_0136;
							}
							ykYmwoKeTBTzSYNeGxwadnlPVaU = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
							wImHsOCJtwIdjKEnuMlEvJdeALq = 0;
							goto IL_0293;
						case 1:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_010c;
						case 2:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								goto IL_024a;
							}
							IL_0274:
							if (whdZzJMqXGhhJMInwWIUGiFZCmZ < HRckiPKvyexXmqUESdWqbUnjcYQ)
							{
								OVGnvStPVHhnmUoEyurHavhDIwI = elVJwCEEmeNxtLYwNDlRVlvBuPD[whdZzJMqXGhhJMInwWIUGiFZCmZ].mapSet;
								QFKWlRkdQkKJifibUTOuSGZusuP = OVGnvStPVHhnmUoEyurHavhDIwI.Count;
								GikEIifpcDtKrfDYDmhxlyZycawj = 0;
								goto IL_0258;
							}
							wImHsOCJtwIdjKEnuMlEvJdeALq++;
							goto IL_0293;
							IL_0258:
							if (GikEIifpcDtKrfDYDmhxlyZycawj < QFKWlRkdQkKJifibUTOuSGZusuP)
							{
								tzHZFZAhwOdcHCqCHfbaXCrAaFNb = OVGnvStPVHhnmUoEyurHavhDIwI[GikEIifpcDtKrfDYDmhxlyZycawj] as T;
								if (tzHZFZAhwOdcHCqCHfbaXCrAaFNb != null && tzHZFZAhwOdcHCqCHfbaXCrAaFNb.categoryId == xPeeFDuTocYwnhaJrBCbItlrDKAe)
								{
									ajbaQItphrIyqhowgmMTfPkCBvcN = tzHZFZAhwOdcHCqCHfbaXCrAaFNb;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								goto IL_024a;
							}
							whdZzJMqXGhhJMInwWIUGiFZCmZ++;
							goto IL_0274;
							IL_010c:
							pafaWteasWnpfgSsJQJuCfoHtfCl++;
							goto IL_011a;
							IL_0136:
							if (sFiBPqcSRdhPeISTmsrBkDXqtZnT < vIdPOwdOkURSiMVOZvmnOnyOEHbF)
							{
								YnYfPKGuCqrXpWUSMjtjVrGiLOW = nJhDzphVvCvwpPjGUmxWlzjFMrgq[sFiBPqcSRdhPeISTmsrBkDXqtZnT].mapSet;
								iWDZVTBnCABTAofybAPDIMJRmcO = YnYfPKGuCqrXpWUSMjtjVrGiLOW.Count;
								pafaWteasWnpfgSsJQJuCfoHtfCl = 0;
								goto IL_011a;
							}
							break;
							IL_0293:
							if (wImHsOCJtwIdjKEnuMlEvJdeALq >= ykYmwoKeTBTzSYNeGxwadnlPVaU)
							{
								break;
							}
							elVJwCEEmeNxtLYwNDlRVlvBuPD = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(wImHsOCJtwIdjKEnuMlEvJdeALq);
							HRckiPKvyexXmqUESdWqbUnjcYQ = elVJwCEEmeNxtLYwNDlRVlvBuPD.Count;
							whdZzJMqXGhhJMInwWIUGiFZCmZ = 0;
							goto IL_0274;
							IL_011a:
							if (pafaWteasWnpfgSsJQJuCfoHtfCl < iWDZVTBnCABTAofybAPDIMJRmcO)
							{
								vLLfdzDyegwynIBYLjxjhzdWoZfl = YnYfPKGuCqrXpWUSMjtjVrGiLOW[pafaWteasWnpfgSsJQJuCfoHtfCl];
								if (vLLfdzDyegwynIBYLjxjhzdWoZfl.categoryId == xPeeFDuTocYwnhaJrBCbItlrDKAe)
								{
									ajbaQItphrIyqhowgmMTfPkCBvcN = (T)vLLfdzDyegwynIBYLjxjhzdWoZfl;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									return true;
								}
								goto IL_010c;
							}
							sFiBPqcSRdhPeISTmsrBkDXqtZnT++;
							goto IL_0136;
							IL_024a:
							GikEIifpcDtKrfDYDmhxlyZycawj++;
							goto IL_0258;
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
					public HBYgdpdfERlJbNmhVYGKldDXJZcD(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class ctXAATNmtThZmGWyBNGYFeIVGhj : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int xPeeFDuTocYwnhaJrBCbItlrDKAe;

					public int GRdOpxNKCFYWbmqOeDFezHUKcsBb;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg jzGSZXshAqKhZjynZVnTIatjGftA;

					public int BoVIGjIPDRjEOissSIMHddKhFrcg;

					public int CYGEXmwAYdmxatYgkZQAfSsgVCZ;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc qYdQdwCQVlEtsBRfLAIPUoTvzSyN;

					public int kCkpZmTmmQtzIkQPgtcVKztfmUV;

					public int ktqXvhutagckCSfTypqklFvxGNTE;

					public ControllerMap fXSybiPlcMURtrxrxDOlWaOyWKC;

					ControllerMap IEnumerator<ControllerMap>.Current
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						ctXAATNmtThZmGWyBNGYFeIVGhj ctXAATNmtThZmGWyBNGYFeIVGhj2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							ctXAATNmtThZmGWyBNGYFeIVGhj2 = this;
						}
						else
						{
							ctXAATNmtThZmGWyBNGYFeIVGhj2 = new ctXAATNmtThZmGWyBNGYFeIVGhj(0);
							ctXAATNmtThZmGWyBNGYFeIVGhj2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						ctXAATNmtThZmGWyBNGYFeIVGhj2.xPeeFDuTocYwnhaJrBCbItlrDKAe = GRdOpxNKCFYWbmqOeDFezHUKcsBb;
						ctXAATNmtThZmGWyBNGYFeIVGhj2.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						return ctXAATNmtThZmGWyBNGYFeIVGhj2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
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
							jzGSZXshAqKhZjynZVnTIatjGftA = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
							BoVIGjIPDRjEOissSIMHddKhFrcg = jzGSZXshAqKhZjynZVnTIatjGftA.Count;
							CYGEXmwAYdmxatYgkZQAfSsgVCZ = 0;
							goto IL_012d;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								goto IL_0103;
							}
							IL_0103:
							ktqXvhutagckCSfTypqklFvxGNTE++;
							goto IL_0111;
							IL_0111:
							if (ktqXvhutagckCSfTypqklFvxGNTE < kCkpZmTmmQtzIkQPgtcVKztfmUV)
							{
								fXSybiPlcMURtrxrxDOlWaOyWKC = qYdQdwCQVlEtsBRfLAIPUoTvzSyN[ktqXvhutagckCSfTypqklFvxGNTE];
								if (fXSybiPlcMURtrxrxDOlWaOyWKC.categoryId == xPeeFDuTocYwnhaJrBCbItlrDKAe)
								{
									ajbaQItphrIyqhowgmMTfPkCBvcN = fXSybiPlcMURtrxrxDOlWaOyWKC;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									return true;
								}
								goto IL_0103;
							}
							CYGEXmwAYdmxatYgkZQAfSsgVCZ++;
							goto IL_012d;
							IL_012d:
							if (CYGEXmwAYdmxatYgkZQAfSsgVCZ >= BoVIGjIPDRjEOissSIMHddKhFrcg)
							{
								break;
							}
							qYdQdwCQVlEtsBRfLAIPUoTvzSyN = jzGSZXshAqKhZjynZVnTIatjGftA[CYGEXmwAYdmxatYgkZQAfSsgVCZ].mapSet;
							kCkpZmTmmQtzIkQPgtcVKztfmUV = qYdQdwCQVlEtsBRfLAIPUoTvzSyN.Count;
							ktqXvhutagckCSfTypqklFvxGNTE = 0;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public ctXAATNmtThZmGWyBNGYFeIVGhj(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class gjFUDNHJJJwWNbCBEFYFhuheOXe : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public int CFvZIzngCAllcpnpzFsjAIaUNFor;

					public int gJiasSjvWMcNhlaXoycDceMHmjk;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg TPVwCfmwSGTEbYoqKpkvgGdHadpc;

					public int VAaUnQlANLZEiRYrYGadXvnktjd;

					public int hfGiddJsbAruxQCWquPWriKMjvL;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc IYPpZKhPJuduMbhVdniROGHzfFr;

					public int FCvYVjsdAbnNLBgsDYYilhjlpUP;

					public int vCHSenbSZmRRokAvlHaOUEDqclM;

					public ControllerMap eeaAZODSxJBIodoffEsqNiuNGwBK;

					public ActionElementMap trehBOjscrErSxFQPbyFfrwOnEEG;

					public IEnumerator<ActionElementMap> KkNumukLSfBOFVVsSeaFllQfgMY;

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
						gjFUDNHJJJwWNbCBEFYFhuheOXe gjFUDNHJJJwWNbCBEFYFhuheOXe2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							gjFUDNHJJJwWNbCBEFYFhuheOXe2 = this;
						}
						else
						{
							gjFUDNHJJJwWNbCBEFYFhuheOXe2 = new gjFUDNHJJJwWNbCBEFYFhuheOXe(0);
							gjFUDNHJJJwWNbCBEFYFhuheOXe2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						gjFUDNHJJJwWNbCBEFYFhuheOXe2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						gjFUDNHJJJwWNbCBEFYFhuheOXe2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return gjFUDNHJJJwWNbCBEFYFhuheOXe2;
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
								CFvZIzngCAllcpnpzFsjAIaUNFor = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
								gJiasSjvWMcNhlaXoycDceMHmjk = 0;
								goto IL_01f5;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0196;
								}
								IL_01d6:
								if (hfGiddJsbAruxQCWquPWriKMjvL < VAaUnQlANLZEiRYrYGadXvnktjd)
								{
									IYPpZKhPJuduMbhVdniROGHzfFr = TPVwCfmwSGTEbYoqKpkvgGdHadpc[hfGiddJsbAruxQCWquPWriKMjvL].mapSet;
									FCvYVjsdAbnNLBgsDYYilhjlpUP = IYPpZKhPJuduMbhVdniROGHzfFr.Count;
									vCHSenbSZmRRokAvlHaOUEDqclM = 0;
									goto IL_01b7;
								}
								gJiasSjvWMcNhlaXoycDceMHmjk++;
								goto IL_01f5;
								IL_0196:
								if (KkNumukLSfBOFVVsSeaFllQfgMY.MoveNext())
								{
									trehBOjscrErSxFQPbyFfrwOnEEG = KkNumukLSfBOFVVsSeaFllQfgMY.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = trehBOjscrErSxFQPbyFfrwOnEEG;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								KQBrpQEDRlheTjYuThwzKCyHLxD();
								goto IL_01a9;
								IL_01a9:
								vCHSenbSZmRRokAvlHaOUEDqclM++;
								goto IL_01b7;
								IL_01f5:
								if (gJiasSjvWMcNhlaXoycDceMHmjk >= CFvZIzngCAllcpnpzFsjAIaUNFor)
								{
									break;
								}
								TPVwCfmwSGTEbYoqKpkvgGdHadpc = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(gJiasSjvWMcNhlaXoycDceMHmjk);
								VAaUnQlANLZEiRYrYGadXvnktjd = TPVwCfmwSGTEbYoqKpkvgGdHadpc.Count;
								hfGiddJsbAruxQCWquPWriKMjvL = 0;
								goto IL_01d6;
								IL_01b7:
								if (vCHSenbSZmRRokAvlHaOUEDqclM < FCvYVjsdAbnNLBgsDYYilhjlpUP)
								{
									eeaAZODSxJBIodoffEsqNiuNGwBK = IYPpZKhPJuduMbhVdniROGHzfFr[vCHSenbSZmRRokAvlHaOUEDqclM];
									if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || eeaAZODSxJBIodoffEsqNiuNGwBK.enabled) && eeaAZODSxJBIodoffEsqNiuNGwBK.ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
									{
										KkNumukLSfBOFVVsSeaFllQfgMY = eeaAZODSxJBIodoffEsqNiuNGwBK.ButtonMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
										uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
										goto IL_0196;
									}
									goto IL_01a9;
								}
								hfGiddJsbAruxQCWquPWriKMjvL++;
								goto IL_01d6;
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
								KQBrpQEDRlheTjYuThwzKCyHLxD();
							}
						}
					}

					[DebuggerHidden]
					public gjFUDNHJJJwWNbCBEFYFhuheOXe(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void KQBrpQEDRlheTjYuThwzKCyHLxD()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (KkNumukLSfBOFVVsSeaFllQfgMY != null)
						{
							KkNumukLSfBOFVVsSeaFllQfgMY.Dispose();
						}
					}
				}

				private sealed class czvtgefVzJPDJUBjUpzqKVQTVaM : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public int azOKtecHTimHBlYGTioPOsdWmlg;

					public int RzCjnNcfpgHYUvCZBmlrZHJZIPV;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg EzswYCMNZlnzuLQrrVIOqUcZapz;

					public int sLTdPzetOXxdtAroBjRFuLLEywa;

					public int pTkWYhKPAMktsWmzenorOjJpGHk;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc TVsCbHThjhtFECloVARKwXFQhOa;

					public int TdUjZeujcLofjlwyVcdOHQVXiYE;

					public int akASGhSOZiFYdpyLnLOOjOokoJu;

					public ControllerMapWithAxes KKgesKRzHENOpeQYrVPwosisrav;

					public ActionElementMap VMYrALmSecICDkGcKeebQFBJPgP;

					public IEnumerator<ActionElementMap> jUJRdosmgaJhPHRurKJaEqVIMQB;

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
						czvtgefVzJPDJUBjUpzqKVQTVaM czvtgefVzJPDJUBjUpzqKVQTVaM2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							czvtgefVzJPDJUBjUpzqKVQTVaM2 = this;
						}
						else
						{
							czvtgefVzJPDJUBjUpzqKVQTVaM2 = new czvtgefVzJPDJUBjUpzqKVQTVaM(0);
							czvtgefVzJPDJUBjUpzqKVQTVaM2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						czvtgefVzJPDJUBjUpzqKVQTVaM2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						czvtgefVzJPDJUBjUpzqKVQTVaM2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return czvtgefVzJPDJUBjUpzqKVQTVaM2;
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
								azOKtecHTimHBlYGTioPOsdWmlg = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
								RzCjnNcfpgHYUvCZBmlrZHJZIPV = 0;
								goto IL_0205;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_01a6;
								}
								IL_01e6:
								if (pTkWYhKPAMktsWmzenorOjJpGHk < sLTdPzetOXxdtAroBjRFuLLEywa)
								{
									TVsCbHThjhtFECloVARKwXFQhOa = EzswYCMNZlnzuLQrrVIOqUcZapz[pTkWYhKPAMktsWmzenorOjJpGHk].mapSet;
									TdUjZeujcLofjlwyVcdOHQVXiYE = TVsCbHThjhtFECloVARKwXFQhOa.Count;
									akASGhSOZiFYdpyLnLOOjOokoJu = 0;
									goto IL_01c7;
								}
								RzCjnNcfpgHYUvCZBmlrZHJZIPV++;
								goto IL_0205;
								IL_01b9:
								akASGhSOZiFYdpyLnLOOjOokoJu++;
								goto IL_01c7;
								IL_01a6:
								if (jUJRdosmgaJhPHRurKJaEqVIMQB.MoveNext())
								{
									VMYrALmSecICDkGcKeebQFBJPgP = jUJRdosmgaJhPHRurKJaEqVIMQB.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = VMYrALmSecICDkGcKeebQFBJPgP;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								yqSZBTluaSaipkEHXaYmAgvJcexJ();
								goto IL_01b9;
								IL_0205:
								if (RzCjnNcfpgHYUvCZBmlrZHJZIPV >= azOKtecHTimHBlYGTioPOsdWmlg)
								{
									break;
								}
								EzswYCMNZlnzuLQrrVIOqUcZapz = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(RzCjnNcfpgHYUvCZBmlrZHJZIPV);
								sLTdPzetOXxdtAroBjRFuLLEywa = EzswYCMNZlnzuLQrrVIOqUcZapz.Count;
								pTkWYhKPAMktsWmzenorOjJpGHk = 0;
								goto IL_01e6;
								IL_01c7:
								if (akASGhSOZiFYdpyLnLOOjOokoJu < TdUjZeujcLofjlwyVcdOHQVXiYE)
								{
									KKgesKRzHENOpeQYrVPwosisrav = TVsCbHThjhtFECloVARKwXFQhOa[akASGhSOZiFYdpyLnLOOjOokoJu] as ControllerMapWithAxes;
									if (KKgesKRzHENOpeQYrVPwosisrav != null && (!sBBuxyRWJQpBnxBQfhNyotyrnMk || KKgesKRzHENOpeQYrVPwosisrav.enabled) && KKgesKRzHENOpeQYrVPwosisrav.ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
									{
										jUJRdosmgaJhPHRurKJaEqVIMQB = KKgesKRzHENOpeQYrVPwosisrav.AxisMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
										uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
										goto IL_01a6;
									}
									goto IL_01b9;
								}
								pTkWYhKPAMktsWmzenorOjJpGHk++;
								goto IL_01e6;
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
								yqSZBTluaSaipkEHXaYmAgvJcexJ();
							}
						}
					}

					[DebuggerHidden]
					public czvtgefVzJPDJUBjUpzqKVQTVaM(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void yqSZBTluaSaipkEHXaYmAgvJcexJ()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (jUJRdosmgaJhPHRurKJaEqVIMQB != null)
						{
							jUJRdosmgaJhPHRurKJaEqVIMQB.Dispose();
						}
					}
				}

				private sealed class esvqSUKdJooVALrWqVChOHsVVXx : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public int HbgusbXpRcsExNEFsJhfdDVsmfo;

					public int McdKDvkLAtBGVNzksREZAYFjalR;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg mfNZKKExuQxliTpBJknQHZdRpUY;

					public int UBxYngTfPrOWQPcfjswBgbnkmeM;

					public int psKrVLHqpZrRNbMonpZWcQxTkUc;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc mZaibxwTmkwdwzzizEkwBLJFzVa;

					public int SeDaZHVvPMJRWOdaDbrYAANplyxk;

					public int UGcmxSoRQQFFftZcgjIySGQBRqA;

					public ControllerMap dBdrbNhhFCqacMRQkDYSYZESGMH;

					public ActionElementMap QDtMWckcDYDxSTkhDfBNZeqdWkJ;

					public IEnumerator<ActionElementMap> frYyrgYEHJDfIEJHeZujvLcipdg;

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
						esvqSUKdJooVALrWqVChOHsVVXx esvqSUKdJooVALrWqVChOHsVVXx2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							esvqSUKdJooVALrWqVChOHsVVXx2 = this;
						}
						else
						{
							esvqSUKdJooVALrWqVChOHsVVXx2 = new esvqSUKdJooVALrWqVChOHsVVXx(0);
							esvqSUKdJooVALrWqVChOHsVVXx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						esvqSUKdJooVALrWqVChOHsVVXx2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						esvqSUKdJooVALrWqVChOHsVVXx2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return esvqSUKdJooVALrWqVChOHsVVXx2;
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
								HbgusbXpRcsExNEFsJhfdDVsmfo = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
								McdKDvkLAtBGVNzksREZAYFjalR = 0;
								goto IL_01f5;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0196;
								}
								IL_01d6:
								if (psKrVLHqpZrRNbMonpZWcQxTkUc < UBxYngTfPrOWQPcfjswBgbnkmeM)
								{
									mZaibxwTmkwdwzzizEkwBLJFzVa = mfNZKKExuQxliTpBJknQHZdRpUY[psKrVLHqpZrRNbMonpZWcQxTkUc].mapSet;
									SeDaZHVvPMJRWOdaDbrYAANplyxk = mZaibxwTmkwdwzzizEkwBLJFzVa.Count;
									UGcmxSoRQQFFftZcgjIySGQBRqA = 0;
									goto IL_01b7;
								}
								McdKDvkLAtBGVNzksREZAYFjalR++;
								goto IL_01f5;
								IL_0196:
								if (frYyrgYEHJDfIEJHeZujvLcipdg.MoveNext())
								{
									QDtMWckcDYDxSTkhDfBNZeqdWkJ = frYyrgYEHJDfIEJHeZujvLcipdg.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = QDtMWckcDYDxSTkhDfBNZeqdWkJ;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								zaAcuLPBeSSrNZYbkNFmCSELcFS();
								goto IL_01a9;
								IL_01a9:
								UGcmxSoRQQFFftZcgjIySGQBRqA++;
								goto IL_01b7;
								IL_01f5:
								if (McdKDvkLAtBGVNzksREZAYFjalR >= HbgusbXpRcsExNEFsJhfdDVsmfo)
								{
									break;
								}
								mfNZKKExuQxliTpBJknQHZdRpUY = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(McdKDvkLAtBGVNzksREZAYFjalR);
								UBxYngTfPrOWQPcfjswBgbnkmeM = mfNZKKExuQxliTpBJknQHZdRpUY.Count;
								psKrVLHqpZrRNbMonpZWcQxTkUc = 0;
								goto IL_01d6;
								IL_01b7:
								if (UGcmxSoRQQFFftZcgjIySGQBRqA < SeDaZHVvPMJRWOdaDbrYAANplyxk)
								{
									dBdrbNhhFCqacMRQkDYSYZESGMH = mZaibxwTmkwdwzzizEkwBLJFzVa[UGcmxSoRQQFFftZcgjIySGQBRqA];
									if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || dBdrbNhhFCqacMRQkDYSYZESGMH.enabled) && dBdrbNhhFCqacMRQkDYSYZESGMH.ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
									{
										frYyrgYEHJDfIEJHeZujvLcipdg = dBdrbNhhFCqacMRQkDYSYZESGMH.ElementMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
										uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
										goto IL_0196;
									}
									goto IL_01a9;
								}
								psKrVLHqpZrRNbMonpZWcQxTkUc++;
								goto IL_01d6;
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
								zaAcuLPBeSSrNZYbkNFmCSELcFS();
							}
						}
					}

					[DebuggerHidden]
					public esvqSUKdJooVALrWqVChOHsVVXx(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void zaAcuLPBeSSrNZYbkNFmCSELcFS()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (frYyrgYEHJDfIEJHeZujvLcipdg != null)
						{
							frYyrgYEHJDfIEJHeZujvLcipdg.Dispose();
						}
					}
				}

				private sealed class ZuIvGUtQmKUvzyaDPCnSkiqbvcD : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public int xPeeFDuTocYwnhaJrBCbItlrDKAe;

					public int GRdOpxNKCFYWbmqOeDFezHUKcsBb;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg xUOHYbLbqCMfbPVedeYQHPKkAmZ;

					public int AHUfaeabpvJOVXTffusmONxYxVuR;

					public IList<ControllerMap> fNXcoacisuPapjKNdlblkIkFaVjU;

					public int aapZdiVJINGucQWpghjpdEtMZZur;

					ControllerMap IEnumerator<ControllerMap>.Current
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
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						ZuIvGUtQmKUvzyaDPCnSkiqbvcD zuIvGUtQmKUvzyaDPCnSkiqbvcD;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							zuIvGUtQmKUvzyaDPCnSkiqbvcD = this;
						}
						else
						{
							zuIvGUtQmKUvzyaDPCnSkiqbvcD = new ZuIvGUtQmKUvzyaDPCnSkiqbvcD(0);
							zuIvGUtQmKUvzyaDPCnSkiqbvcD.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						zuIvGUtQmKUvzyaDPCnSkiqbvcD.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						zuIvGUtQmKUvzyaDPCnSkiqbvcD.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						zuIvGUtQmKUvzyaDPCnSkiqbvcD.xPeeFDuTocYwnhaJrBCbItlrDKAe = GRdOpxNKCFYWbmqOeDFezHUKcsBb;
						return zuIvGUtQmKUvzyaDPCnSkiqbvcD;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							xUOHYbLbqCMfbPVedeYQHPKkAmZ = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
							AHUfaeabpvJOVXTffusmONxYxVuR = xUOHYbLbqCMfbPVedeYQHPKkAmZ.EZvGxHsqIFFuTapSiFVRnGzgbyW(KnonnCxGElFAypUKvIFykJitAex);
							if (AHUfaeabpvJOVXTffusmONxYxVuR < 0)
							{
								break;
							}
							fNXcoacisuPapjKNdlblkIkFaVjU = xUOHYbLbqCMfbPVedeYQHPKkAmZ[AHUfaeabpvJOVXTffusmONxYxVuR].mapSet.Maps;
							aapZdiVJINGucQWpghjpdEtMZZur = 0;
							goto IL_00e2;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								goto IL_00d4;
							}
							IL_00d4:
							aapZdiVJINGucQWpghjpdEtMZZur++;
							goto IL_00e2;
							IL_00e2:
							if (aapZdiVJINGucQWpghjpdEtMZZur >= fNXcoacisuPapjKNdlblkIkFaVjU.Count)
							{
								break;
							}
							if (fNXcoacisuPapjKNdlblkIkFaVjU[aapZdiVJINGucQWpghjpdEtMZZur].categoryId == xPeeFDuTocYwnhaJrBCbItlrDKAe)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = fNXcoacisuPapjKNdlblkIkFaVjU[aapZdiVJINGucQWpghjpdEtMZZur];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								return true;
							}
							goto IL_00d4;
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
					public ZuIvGUtQmKUvzyaDPCnSkiqbvcD(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class CmqLlPnmTGCTlsaKIcSxgneMRoKp<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<T>, IEnumerator<T> where T : ControllerMap
				{
					private T ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public int xPeeFDuTocYwnhaJrBCbItlrDKAe;

					public int GRdOpxNKCFYWbmqOeDFezHUKcsBb;

					public ControllerType SmgdCQbifWgtJckuXaiDMwgQWVZ;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg MpUEADkTVjJXjIeQhCwjGccEkDj;

					public int WTWevLtBBhqHFTIbfiEfoqnXSLl;

					public IList<T> KSFgQnaYcyLSnMAEADhiDGSgEaLX;

					public int skcOCOVBtDFXPclIGGnzooMumlzI;

					T IEnumerator<T>.Current
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
					IEnumerator<T> IEnumerable<T>.GetEnumerator()
					{
						CmqLlPnmTGCTlsaKIcSxgneMRoKp<T> cmqLlPnmTGCTlsaKIcSxgneMRoKp;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							cmqLlPnmTGCTlsaKIcSxgneMRoKp = this;
						}
						else
						{
							cmqLlPnmTGCTlsaKIcSxgneMRoKp = new CmqLlPnmTGCTlsaKIcSxgneMRoKp<T>(0);
							cmqLlPnmTGCTlsaKIcSxgneMRoKp.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						cmqLlPnmTGCTlsaKIcSxgneMRoKp.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						cmqLlPnmTGCTlsaKIcSxgneMRoKp.xPeeFDuTocYwnhaJrBCbItlrDKAe = GRdOpxNKCFYWbmqOeDFezHUKcsBb;
						return cmqLlPnmTGCTlsaKIcSxgneMRoKp;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<T>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						T val;
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							SmgdCQbifWgtJckuXaiDMwgQWVZ = bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>();
							MpUEADkTVjJXjIeQhCwjGccEkDj = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(SmgdCQbifWgtJckuXaiDMwgQWVZ);
							WTWevLtBBhqHFTIbfiEfoqnXSLl = MpUEADkTVjJXjIeQhCwjGccEkDj.EZvGxHsqIFFuTapSiFVRnGzgbyW(KnonnCxGElFAypUKvIFykJitAex);
							if (WTWevLtBBhqHFTIbfiEfoqnXSLl < 0)
							{
								break;
							}
							KSFgQnaYcyLSnMAEADhiDGSgEaLX = MpUEADkTVjJXjIeQhCwjGccEkDj[WTWevLtBBhqHFTIbfiEfoqnXSLl].mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB<T>();
							skcOCOVBtDFXPclIGGnzooMumlzI = 0;
							goto IL_00f6;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								goto IL_00e8;
							}
							IL_00e8:
							skcOCOVBtDFXPclIGGnzooMumlzI++;
							goto IL_00f6;
							IL_00f6:
							if (skcOCOVBtDFXPclIGGnzooMumlzI >= KSFgQnaYcyLSnMAEADhiDGSgEaLX.Count)
							{
								break;
							}
							val = KSFgQnaYcyLSnMAEADhiDGSgEaLX[skcOCOVBtDFXPclIGGnzooMumlzI];
							if (val.categoryId == xPeeFDuTocYwnhaJrBCbItlrDKAe)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = KSFgQnaYcyLSnMAEADhiDGSgEaLX[skcOCOVBtDFXPclIGGnzooMumlzI];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								return true;
							}
							goto IL_00e8;
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
					public CmqLlPnmTGCTlsaKIcSxgneMRoKp(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class anrrFKznjManUhXnigeUSoLsOhQU : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg ZWyfZhQGTulHLQMMRBNniOocMDMd;

					public int EBYMOTyooanixbgfnSsbZRxxptX;

					public IList<ControllerMap> xpgeSWURCpXQtZVKwMelUGPZcFDI;

					public int pbKTxWaDAwgOBixbZhsqoONfpzy;

					public ActionElementMap EZyAsDGfSJqGpYpJPddcNQWMaChq;

					public IEnumerator<ActionElementMap> COkXCiYzfmrAViXjMTILjqTRRfG;

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
						anrrFKznjManUhXnigeUSoLsOhQU anrrFKznjManUhXnigeUSoLsOhQU2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							anrrFKznjManUhXnigeUSoLsOhQU2 = this;
						}
						else
						{
							anrrFKznjManUhXnigeUSoLsOhQU2 = new anrrFKznjManUhXnigeUSoLsOhQU(0);
							anrrFKznjManUhXnigeUSoLsOhQU2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						anrrFKznjManUhXnigeUSoLsOhQU2.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						anrrFKznjManUhXnigeUSoLsOhQU2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						anrrFKznjManUhXnigeUSoLsOhQU2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return anrrFKznjManUhXnigeUSoLsOhQU2;
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
								if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
								{
									break;
								}
								ZWyfZhQGTulHLQMMRBNniOocMDMd = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
								EBYMOTyooanixbgfnSsbZRxxptX = 0;
								goto IL_0176;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0131;
								}
								IL_0131:
								if (COkXCiYzfmrAViXjMTILjqTRRfG.MoveNext())
								{
									EZyAsDGfSJqGpYpJPddcNQWMaChq = COkXCiYzfmrAViXjMTILjqTRRfG.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = EZyAsDGfSJqGpYpJPddcNQWMaChq;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								zPIiaOnZFzAvKCMEhuSavoCXQoC();
								goto IL_0144;
								IL_0176:
								if (EBYMOTyooanixbgfnSsbZRxxptX >= ZWyfZhQGTulHLQMMRBNniOocMDMd.Count)
								{
									break;
								}
								xpgeSWURCpXQtZVKwMelUGPZcFDI = ZWyfZhQGTulHLQMMRBNniOocMDMd[EBYMOTyooanixbgfnSsbZRxxptX].mapSet.Maps;
								pbKTxWaDAwgOBixbZhsqoONfpzy = 0;
								goto IL_0152;
								IL_0144:
								pbKTxWaDAwgOBixbZhsqoONfpzy++;
								goto IL_0152;
								IL_0152:
								if (pbKTxWaDAwgOBixbZhsqoONfpzy < xpgeSWURCpXQtZVKwMelUGPZcFDI.Count)
								{
									if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || xpgeSWURCpXQtZVKwMelUGPZcFDI[pbKTxWaDAwgOBixbZhsqoONfpzy].enabled) && xpgeSWURCpXQtZVKwMelUGPZcFDI[pbKTxWaDAwgOBixbZhsqoONfpzy].ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
									{
										COkXCiYzfmrAViXjMTILjqTRRfG = xpgeSWURCpXQtZVKwMelUGPZcFDI[pbKTxWaDAwgOBixbZhsqoONfpzy].ButtonMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
										uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
										goto IL_0131;
									}
									goto IL_0144;
								}
								EBYMOTyooanixbgfnSsbZRxxptX++;
								goto IL_0176;
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
								zPIiaOnZFzAvKCMEhuSavoCXQoC();
							}
						}
					}

					[DebuggerHidden]
					public anrrFKznjManUhXnigeUSoLsOhQU(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void zPIiaOnZFzAvKCMEhuSavoCXQoC()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (COkXCiYzfmrAViXjMTILjqTRRfG != null)
						{
							COkXCiYzfmrAViXjMTILjqTRRfG.Dispose();
						}
					}
				}

				private sealed class xgiTuUQAiEmORSEnJbTwAHjnnCJv : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg JdKDswlzYXHBepOeCbraSinntxl;

					public int kxyayvaIxSZqygGOhCLfsHWbCaHF;

					public IList<ControllerMap> KLnIUOOUctNbWsrJzWPzUVoDTXG;

					public int PhgbrtyYxevvbdHfOCtjfcLOXUu;

					public ActionElementMap knbuHWwTmeCXtrRIrgWNDdCerar;

					public IEnumerator<ActionElementMap> kuhRkkDYmIQYjeEvfjKokDIHVtz;

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
						xgiTuUQAiEmORSEnJbTwAHjnnCJv xgiTuUQAiEmORSEnJbTwAHjnnCJv2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							xgiTuUQAiEmORSEnJbTwAHjnnCJv2 = this;
						}
						else
						{
							xgiTuUQAiEmORSEnJbTwAHjnnCJv2 = new xgiTuUQAiEmORSEnJbTwAHjnnCJv(0);
							xgiTuUQAiEmORSEnJbTwAHjnnCJv2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						xgiTuUQAiEmORSEnJbTwAHjnnCJv2.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						xgiTuUQAiEmORSEnJbTwAHjnnCJv2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						xgiTuUQAiEmORSEnJbTwAHjnnCJv2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return xgiTuUQAiEmORSEnJbTwAHjnnCJv2;
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
								if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
								{
									break;
								}
								JdKDswlzYXHBepOeCbraSinntxl = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
								kxyayvaIxSZqygGOhCLfsHWbCaHF = 0;
								goto IL_0196;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0151;
								}
								IL_0164:
								PhgbrtyYxevvbdHfOCtjfcLOXUu++;
								goto IL_0172;
								IL_0196:
								if (kxyayvaIxSZqygGOhCLfsHWbCaHF >= JdKDswlzYXHBepOeCbraSinntxl.Count)
								{
									break;
								}
								KLnIUOOUctNbWsrJzWPzUVoDTXG = JdKDswlzYXHBepOeCbraSinntxl[kxyayvaIxSZqygGOhCLfsHWbCaHF].mapSet.Maps;
								PhgbrtyYxevvbdHfOCtjfcLOXUu = 0;
								goto IL_0172;
								IL_0151:
								if (kuhRkkDYmIQYjeEvfjKokDIHVtz.MoveNext())
								{
									knbuHWwTmeCXtrRIrgWNDdCerar = kuhRkkDYmIQYjeEvfjKokDIHVtz.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = knbuHWwTmeCXtrRIrgWNDdCerar;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								wneCEzjNSFVJWRWpAvdgtYaXDRub();
								goto IL_0164;
								IL_0172:
								if (PhgbrtyYxevvbdHfOCtjfcLOXUu < KLnIUOOUctNbWsrJzWPzUVoDTXG.Count)
								{
									if (!(KLnIUOOUctNbWsrJzWPzUVoDTXG[PhgbrtyYxevvbdHfOCtjfcLOXUu] is ControllerMapWithAxes))
									{
										break;
									}
									if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || KLnIUOOUctNbWsrJzWPzUVoDTXG[PhgbrtyYxevvbdHfOCtjfcLOXUu].enabled) && KLnIUOOUctNbWsrJzWPzUVoDTXG[PhgbrtyYxevvbdHfOCtjfcLOXUu].ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
									{
										kuhRkkDYmIQYjeEvfjKokDIHVtz = (KLnIUOOUctNbWsrJzWPzUVoDTXG[PhgbrtyYxevvbdHfOCtjfcLOXUu] as ControllerMapWithAxes).AxisMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
										uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
										goto IL_0151;
									}
									goto IL_0164;
								}
								kxyayvaIxSZqygGOhCLfsHWbCaHF++;
								goto IL_0196;
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
								wneCEzjNSFVJWRWpAvdgtYaXDRub();
							}
						}
					}

					[DebuggerHidden]
					public xgiTuUQAiEmORSEnJbTwAHjnnCJv(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void wneCEzjNSFVJWRWpAvdgtYaXDRub()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kuhRkkDYmIQYjeEvfjKokDIHVtz != null)
						{
							kuhRkkDYmIQYjeEvfjKokDIHVtz.Dispose();
						}
					}
				}

				private sealed class soARGmZLzoTHSAypHjPVcofbEOv : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg jmgdwWGPsNbWXtBzOyeUdyHgaqBD;

					public int nkesexIGSAfZUVhLsnByheoKWOk;

					public IList<ControllerMap> LTbLrYPGtBJzwOzpmDizSgnPEvI;

					public int PJRAbSDsDQvkORNKAjcPqGRmFVyW;

					public ActionElementMap buoVdxCLiAzwtBKjioZGPpLkuHf;

					public IEnumerator<ActionElementMap> pKnrSxdGzPsiBREjduRYxLvUfmAI;

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
						soARGmZLzoTHSAypHjPVcofbEOv soARGmZLzoTHSAypHjPVcofbEOv2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							soARGmZLzoTHSAypHjPVcofbEOv2 = this;
						}
						else
						{
							soARGmZLzoTHSAypHjPVcofbEOv2 = new soARGmZLzoTHSAypHjPVcofbEOv(0);
							soARGmZLzoTHSAypHjPVcofbEOv2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						soARGmZLzoTHSAypHjPVcofbEOv2.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						soARGmZLzoTHSAypHjPVcofbEOv2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						soARGmZLzoTHSAypHjPVcofbEOv2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return soARGmZLzoTHSAypHjPVcofbEOv2;
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
								if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
								{
									break;
								}
								jmgdwWGPsNbWXtBzOyeUdyHgaqBD = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
								nkesexIGSAfZUVhLsnByheoKWOk = 0;
								goto IL_0176;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0131;
								}
								IL_0131:
								if (pKnrSxdGzPsiBREjduRYxLvUfmAI.MoveNext())
								{
									buoVdxCLiAzwtBKjioZGPpLkuHf = pKnrSxdGzPsiBREjduRYxLvUfmAI.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = buoVdxCLiAzwtBKjioZGPpLkuHf;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								QGpEHkWavRgHvMqyxjbSFhUCxvt();
								goto IL_0144;
								IL_0176:
								if (nkesexIGSAfZUVhLsnByheoKWOk >= jmgdwWGPsNbWXtBzOyeUdyHgaqBD.Count)
								{
									break;
								}
								LTbLrYPGtBJzwOzpmDizSgnPEvI = jmgdwWGPsNbWXtBzOyeUdyHgaqBD[nkesexIGSAfZUVhLsnByheoKWOk].mapSet.Maps;
								PJRAbSDsDQvkORNKAjcPqGRmFVyW = 0;
								goto IL_0152;
								IL_0144:
								PJRAbSDsDQvkORNKAjcPqGRmFVyW++;
								goto IL_0152;
								IL_0152:
								if (PJRAbSDsDQvkORNKAjcPqGRmFVyW < LTbLrYPGtBJzwOzpmDizSgnPEvI.Count)
								{
									if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || LTbLrYPGtBJzwOzpmDizSgnPEvI[PJRAbSDsDQvkORNKAjcPqGRmFVyW].enabled) && LTbLrYPGtBJzwOzpmDizSgnPEvI[PJRAbSDsDQvkORNKAjcPqGRmFVyW].ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
									{
										pKnrSxdGzPsiBREjduRYxLvUfmAI = LTbLrYPGtBJzwOzpmDizSgnPEvI[PJRAbSDsDQvkORNKAjcPqGRmFVyW].ElementMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
										uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
										goto IL_0131;
									}
									goto IL_0144;
								}
								nkesexIGSAfZUVhLsnByheoKWOk++;
								goto IL_0176;
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
								QGpEHkWavRgHvMqyxjbSFhUCxvt();
							}
						}
					}

					[DebuggerHidden]
					public soARGmZLzoTHSAypHjPVcofbEOv(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void QGpEHkWavRgHvMqyxjbSFhUCxvt()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (pKnrSxdGzPsiBREjduRYxLvUfmAI != null)
						{
							pKnrSxdGzPsiBREjduRYxLvUfmAI.Dispose();
						}
					}
				}

				private sealed class iWKMLkmKDlwCCSfWKxKwnwEhkDu : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg CPWPKwOqMvhDcHXBBtvCoTiSRPA;

					public int PmcMVlqbwfDrCUHTQewjaxGwGoK;

					public IList<ControllerMap> nqpBjxjYXruSFuEPBrUkhmUeAiGg;

					public int dMgghpjPOVWFwioxXpoqVuWowim;

					public ActionElementMap nkaPXtVCLBlWMvZPqHRbkmJpiEo;

					public IEnumerator<ActionElementMap> hSUGSruWFDtQAkHaLnKhWCbbeyY;

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
						iWKMLkmKDlwCCSfWKxKwnwEhkDu iWKMLkmKDlwCCSfWKxKwnwEhkDu2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							iWKMLkmKDlwCCSfWKxKwnwEhkDu2 = this;
						}
						else
						{
							iWKMLkmKDlwCCSfWKxKwnwEhkDu2 = new iWKMLkmKDlwCCSfWKxKwnwEhkDu(0);
							iWKMLkmKDlwCCSfWKxKwnwEhkDu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						iWKMLkmKDlwCCSfWKxKwnwEhkDu2.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						iWKMLkmKDlwCCSfWKxKwnwEhkDu2.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						iWKMLkmKDlwCCSfWKxKwnwEhkDu2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						iWKMLkmKDlwCCSfWKxKwnwEhkDu2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return iWKMLkmKDlwCCSfWKxKwnwEhkDu2;
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
								if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
								{
									break;
								}
								CPWPKwOqMvhDcHXBBtvCoTiSRPA = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
								PmcMVlqbwfDrCUHTQewjaxGwGoK = CPWPKwOqMvhDcHXBBtvCoTiSRPA.EZvGxHsqIFFuTapSiFVRnGzgbyW(KnonnCxGElFAypUKvIFykJitAex);
								if (PmcMVlqbwfDrCUHTQewjaxGwGoK < 0)
								{
									break;
								}
								nqpBjxjYXruSFuEPBrUkhmUeAiGg = CPWPKwOqMvhDcHXBBtvCoTiSRPA[PmcMVlqbwfDrCUHTQewjaxGwGoK].mapSet.Maps;
								dMgghpjPOVWFwioxXpoqVuWowim = 0;
								goto IL_0169;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0148;
								}
								IL_015b:
								dMgghpjPOVWFwioxXpoqVuWowim++;
								goto IL_0169;
								IL_0148:
								if (hSUGSruWFDtQAkHaLnKhWCbbeyY.MoveNext())
								{
									nkaPXtVCLBlWMvZPqHRbkmJpiEo = hSUGSruWFDtQAkHaLnKhWCbbeyY.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = nkaPXtVCLBlWMvZPqHRbkmJpiEo;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								vxQPkCUgplHhEAQQcjnGhEwELwNp();
								goto IL_015b;
								IL_0169:
								if (dMgghpjPOVWFwioxXpoqVuWowim >= nqpBjxjYXruSFuEPBrUkhmUeAiGg.Count)
								{
									break;
								}
								if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || nqpBjxjYXruSFuEPBrUkhmUeAiGg[dMgghpjPOVWFwioxXpoqVuWowim].enabled) && nqpBjxjYXruSFuEPBrUkhmUeAiGg[dMgghpjPOVWFwioxXpoqVuWowim].ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
								{
									hSUGSruWFDtQAkHaLnKhWCbbeyY = nqpBjxjYXruSFuEPBrUkhmUeAiGg[dMgghpjPOVWFwioxXpoqVuWowim].ButtonMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0148;
								}
								goto IL_015b;
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
								vxQPkCUgplHhEAQQcjnGhEwELwNp();
							}
						}
					}

					[DebuggerHidden]
					public iWKMLkmKDlwCCSfWKxKwnwEhkDu(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void vxQPkCUgplHhEAQQcjnGhEwELwNp()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (hSUGSruWFDtQAkHaLnKhWCbbeyY != null)
						{
							hSUGSruWFDtQAkHaLnKhWCbbeyY.Dispose();
						}
					}
				}

				private sealed class OakATNNtfuuEGYBfsqdhODyiNMN : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg CaUeALDCUpedRtIcOFLZArhbHlR;

					public int CsWFNozhpzjZACxcKhxBQCPkSFv;

					public IList<ControllerMap> eoGEFcBTpdtpcILlaoRvJAdlIPf;

					public int dkRtwrUOBOHajkeAgUFuwzfdbHa;

					public ActionElementMap QuYKgOnpTDZopeKMOZYIIyKguo;

					public IEnumerator<ActionElementMap> TLWSTAGmGrOxudRtbcSpXTwimIh;

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
						OakATNNtfuuEGYBfsqdhODyiNMN oakATNNtfuuEGYBfsqdhODyiNMN;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							oakATNNtfuuEGYBfsqdhODyiNMN = this;
						}
						else
						{
							oakATNNtfuuEGYBfsqdhODyiNMN = new OakATNNtfuuEGYBfsqdhODyiNMN(0);
							oakATNNtfuuEGYBfsqdhODyiNMN.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						oakATNNtfuuEGYBfsqdhODyiNMN.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						oakATNNtfuuEGYBfsqdhODyiNMN.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						oakATNNtfuuEGYBfsqdhODyiNMN.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						oakATNNtfuuEGYBfsqdhODyiNMN.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return oakATNNtfuuEGYBfsqdhODyiNMN;
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
								if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
								{
									break;
								}
								CaUeALDCUpedRtIcOFLZArhbHlR = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
								CsWFNozhpzjZACxcKhxBQCPkSFv = CaUeALDCUpedRtIcOFLZArhbHlR.EZvGxHsqIFFuTapSiFVRnGzgbyW(KnonnCxGElFAypUKvIFykJitAex);
								if (CsWFNozhpzjZACxcKhxBQCPkSFv < 0)
								{
									break;
								}
								eoGEFcBTpdtpcILlaoRvJAdlIPf = CaUeALDCUpedRtIcOFLZArhbHlR[CsWFNozhpzjZACxcKhxBQCPkSFv].mapSet.Maps;
								dkRtwrUOBOHajkeAgUFuwzfdbHa = 0;
								goto IL_0189;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0168;
								}
								IL_0168:
								if (TLWSTAGmGrOxudRtbcSpXTwimIh.MoveNext())
								{
									QuYKgOnpTDZopeKMOZYIIyKguo = TLWSTAGmGrOxudRtbcSpXTwimIh.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = QuYKgOnpTDZopeKMOZYIIyKguo;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								YaGcSjdSwkAslFIqawIUaPjoyyca();
								goto IL_017b;
								IL_017b:
								dkRtwrUOBOHajkeAgUFuwzfdbHa++;
								goto IL_0189;
								IL_0189:
								if (dkRtwrUOBOHajkeAgUFuwzfdbHa >= eoGEFcBTpdtpcILlaoRvJAdlIPf.Count || !(eoGEFcBTpdtpcILlaoRvJAdlIPf[dkRtwrUOBOHajkeAgUFuwzfdbHa] is ControllerMapWithAxes))
								{
									break;
								}
								if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || eoGEFcBTpdtpcILlaoRvJAdlIPf[dkRtwrUOBOHajkeAgUFuwzfdbHa].enabled) && eoGEFcBTpdtpcILlaoRvJAdlIPf[dkRtwrUOBOHajkeAgUFuwzfdbHa].ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
								{
									TLWSTAGmGrOxudRtbcSpXTwimIh = (eoGEFcBTpdtpcILlaoRvJAdlIPf[dkRtwrUOBOHajkeAgUFuwzfdbHa] as ControllerMapWithAxes).AxisMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0168;
								}
								goto IL_017b;
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
								YaGcSjdSwkAslFIqawIUaPjoyyca();
							}
						}
					}

					[DebuggerHidden]
					public OakATNNtfuuEGYBfsqdhODyiNMN(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void YaGcSjdSwkAslFIqawIUaPjoyyca()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (TLWSTAGmGrOxudRtbcSpXTwimIh != null)
						{
							TLWSTAGmGrOxudRtbcSpXTwimIh.Dispose();
						}
					}
				}

				private sealed class agOahSLZDZFdsJfAuQQwTgkkBVl : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerType KuXUxnrnEEmYKlaMyJdtDYyuul;

					public ControllerType DVZsgAzIxkddCLsqBMwMTMemsil;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg ngOyELVHdyPrgQiyYZhxqDiryTe;

					public int owxzwmtFnRbKTysNvjnxqdISRRr;

					public IList<ControllerMap> YdSjVXBxenqRRZHylMwEBodwopg;

					public int nJKcCLcMVYipxqQRyGVzDQEspAQI;

					public ActionElementMap QKLeNVdAWgSqOxFBMdlUwpDHPBG;

					public IEnumerator<ActionElementMap> lboZrrHrUjDRsabWmvwRyqxDIGB;

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
						agOahSLZDZFdsJfAuQQwTgkkBVl agOahSLZDZFdsJfAuQQwTgkkBVl2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							agOahSLZDZFdsJfAuQQwTgkkBVl2 = this;
						}
						else
						{
							agOahSLZDZFdsJfAuQQwTgkkBVl2 = new agOahSLZDZFdsJfAuQQwTgkkBVl(0);
							agOahSLZDZFdsJfAuQQwTgkkBVl2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						agOahSLZDZFdsJfAuQQwTgkkBVl2.KuXUxnrnEEmYKlaMyJdtDYyuul = DVZsgAzIxkddCLsqBMwMTMemsil;
						agOahSLZDZFdsJfAuQQwTgkkBVl2.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						agOahSLZDZFdsJfAuQQwTgkkBVl2.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						agOahSLZDZFdsJfAuQQwTgkkBVl2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return agOahSLZDZFdsJfAuQQwTgkkBVl2;
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
								if (KjaWgObGREamoandMdAXxTdnHIgu < 0)
								{
									break;
								}
								ngOyELVHdyPrgQiyYZhxqDiryTe = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(KuXUxnrnEEmYKlaMyJdtDYyuul);
								owxzwmtFnRbKTysNvjnxqdISRRr = ngOyELVHdyPrgQiyYZhxqDiryTe.EZvGxHsqIFFuTapSiFVRnGzgbyW(KnonnCxGElFAypUKvIFykJitAex);
								if (owxzwmtFnRbKTysNvjnxqdISRRr < 0)
								{
									break;
								}
								YdSjVXBxenqRRZHylMwEBodwopg = ngOyELVHdyPrgQiyYZhxqDiryTe[owxzwmtFnRbKTysNvjnxqdISRRr].mapSet.Maps;
								nJKcCLcMVYipxqQRyGVzDQEspAQI = 0;
								goto IL_0169;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0148;
								}
								IL_015b:
								nJKcCLcMVYipxqQRyGVzDQEspAQI++;
								goto IL_0169;
								IL_0148:
								if (lboZrrHrUjDRsabWmvwRyqxDIGB.MoveNext())
								{
									QKLeNVdAWgSqOxFBMdlUwpDHPBG = lboZrrHrUjDRsabWmvwRyqxDIGB.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = QKLeNVdAWgSqOxFBMdlUwpDHPBG;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								foQlMrdrfhUOJIvAirhjZQaDdGJ();
								goto IL_015b;
								IL_0169:
								if (nJKcCLcMVYipxqQRyGVzDQEspAQI >= YdSjVXBxenqRRZHylMwEBodwopg.Count)
								{
									break;
								}
								if ((!sBBuxyRWJQpBnxBQfhNyotyrnMk || YdSjVXBxenqRRZHylMwEBodwopg[nJKcCLcMVYipxqQRyGVzDQEspAQI].enabled) && YdSjVXBxenqRRZHylMwEBodwopg[nJKcCLcMVYipxqQRyGVzDQEspAQI].ContainsAction(KjaWgObGREamoandMdAXxTdnHIgu))
								{
									lboZrrHrUjDRsabWmvwRyqxDIGB = YdSjVXBxenqRRZHylMwEBodwopg[nJKcCLcMVYipxqQRyGVzDQEspAQI].ElementMapsWithAction(KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk).GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0148;
								}
								goto IL_015b;
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
								foQlMrdrfhUOJIvAirhjZQaDdGJ();
							}
						}
					}

					[DebuggerHidden]
					public agOahSLZDZFdsJfAuQQwTgkkBVl(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void foQlMrdrfhUOJIvAirhjZQaDdGJ()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (lboZrrHrUjDRsabWmvwRyqxDIGB != null)
						{
							lboZrrHrUjDRsabWmvwRyqxDIGB.Dispose();
						}
					}
				}

				private sealed class ZqxfoFNhFZhmYhVoqoLPxmkMkHqv : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public MapHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IControllerElementTarget TEgEOzuJcAYDKPcYtMGbGLlSEyn;

					public IControllerElementTarget jcELyNXpDJBwHWlzxALZjKPhJZo;

					public bool zyJDaouvXmWESnaxMcMGfUteWNB;

					public bool INaJPwadwIRqaQLyTirCJsPEDsTF;

					public int KjaWgObGREamoandMdAXxTdnHIgu;

					public int YOXLccoEMCTpcLNYciWfwMnsHwE;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public Controller cHgKoDPklAFxeiKmjCVaGoaEgjg;

					public ozEDFrZmqchSdqXvkECRiiBJFWVg dLzYuLvjzQFRrFOfIYEBvsqTjqh;

					public int eWRrZqudqlCECaeIznNDNhpGjMES;

					public int XJXuhWngyYNIQBSGdWrsMlCycHEG;

					public aXnVKdRCFttLXjlGLvvowqKPhkUc rKMbZdGJfYlcbgeJlEEhOSPqDpll;

					public IList<ControllerMap> ocLCFUpLiOsqperXzjhQpvXeZjF;

					public int mAgajYJrnYXpvTZVFwGzfDQSKUbD;

					public int yaxGwfTwKuwgWuwAgYTApcIjjfe;

					public ControllerMap BplcnWanOqUCdvCXkGlVSdEfZpQF;

					public TempListPool.TList<ActionElementMap> XoXHXxZQIQHjvrPeHjUBeXqFron;

					public List<ActionElementMap> eoOMoDWxDdoaAItqmTiletLWAgY;

					public bool bmiOyTIAscEUvDowDlqcikKndwC;

					public ActionElementMap SuYjWvBOGZMyxMBEpurCepZNbQP;

					public List<ActionElementMap>.Enumerator onBAnRvLzFCVcKKUSVNNSaKbMva;

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
						ZqxfoFNhFZhmYhVoqoLPxmkMkHqv zqxfoFNhFZhmYhVoqoLPxmkMkHqv;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							zqxfoFNhFZhmYhVoqoLPxmkMkHqv = this;
						}
						else
						{
							zqxfoFNhFZhmYhVoqoLPxmkMkHqv = new ZqxfoFNhFZhmYhVoqoLPxmkMkHqv(0);
							zqxfoFNhFZhmYhVoqoLPxmkMkHqv.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						zqxfoFNhFZhmYhVoqoLPxmkMkHqv.TEgEOzuJcAYDKPcYtMGbGLlSEyn = jcELyNXpDJBwHWlzxALZjKPhJZo;
						zqxfoFNhFZhmYhVoqoLPxmkMkHqv.zyJDaouvXmWESnaxMcMGfUteWNB = INaJPwadwIRqaQLyTirCJsPEDsTF;
						zqxfoFNhFZhmYhVoqoLPxmkMkHqv.KjaWgObGREamoandMdAXxTdnHIgu = YOXLccoEMCTpcLNYciWfwMnsHwE;
						zqxfoFNhFZhmYhVoqoLPxmkMkHqv.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						return zqxfoFNhFZhmYhVoqoLPxmkMkHqv;
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
									goto IL_01aa;
								}
							}
							else
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (TEgEOzuJcAYDKPcYtMGbGLlSEyn != null)
								{
									cHgKoDPklAFxeiKmjCVaGoaEgjg = TEgEOzuJcAYDKPcYtMGbGLlSEyn.controller;
									if (cHgKoDPklAFxeiKmjCVaGoaEgjg != null)
									{
										dLzYuLvjzQFRrFOfIYEBvsqTjqh = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(cHgKoDPklAFxeiKmjCVaGoaEgjg.type);
										eWRrZqudqlCECaeIznNDNhpGjMES = dLzYuLvjzQFRrFOfIYEBvsqTjqh.Count;
										XJXuhWngyYNIQBSGdWrsMlCycHEG = 0;
										goto IL_01f0;
									}
								}
							}
							goto IL_0201;
							IL_0201:
							return false;
							IL_01c3:
							yaxGwfTwKuwgWuwAgYTApcIjjfe++;
							goto IL_01d1;
							IL_01d1:
							if (yaxGwfTwKuwgWuwAgYTApcIjjfe < mAgajYJrnYXpvTZVFwGzfDQSKUbD)
							{
								BplcnWanOqUCdvCXkGlVSdEfZpQF = ocLCFUpLiOsqperXzjhQpvXeZjF[yaxGwfTwKuwgWuwAgYTApcIjjfe];
								if (!sBBuxyRWJQpBnxBQfhNyotyrnMk || BplcnWanOqUCdvCXkGlVSdEfZpQF.enabled)
								{
									XoXHXxZQIQHjvrPeHjUBeXqFron = TempListPool.GetTList<ActionElementMap>();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									eoOMoDWxDdoaAItqmTiletLWAgY = XoXHXxZQIQHjvrPeHjUBeXqFron.list;
									BplcnWanOqUCdvCXkGlVSdEfZpQF.dyceDrFMqmHuFuGxjUooOwevmZT(TEgEOzuJcAYDKPcYtMGbGLlSEyn, zyJDaouvXmWESnaxMcMGfUteWNB, KjaWgObGREamoandMdAXxTdnHIgu, sBBuxyRWJQpBnxBQfhNyotyrnMk, eoOMoDWxDdoaAItqmTiletLWAgY, true, out bmiOyTIAscEUvDowDlqcikKndwC);
									onBAnRvLzFCVcKKUSVNNSaKbMva = eoOMoDWxDdoaAItqmTiletLWAgY.GetEnumerator();
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									goto IL_01aa;
								}
								goto IL_01c3;
							}
							XJXuhWngyYNIQBSGdWrsMlCycHEG++;
							goto IL_01f0;
							IL_01aa:
							if (onBAnRvLzFCVcKKUSVNNSaKbMva.MoveNext())
							{
								SuYjWvBOGZMyxMBEpurCepZNbQP = onBAnRvLzFCVcKKUSVNNSaKbMva.Current;
								ajbaQItphrIyqhowgmMTfPkCBvcN = SuYjWvBOGZMyxMBEpurCepZNbQP;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								return true;
							}
							thMNbPYPmOOMMiKSCAsYmgWgPqW();
							kNRJPRTxxUEwHHhlepSeDrYJYSA();
							goto IL_01c3;
							IL_01f0:
							if (XJXuhWngyYNIQBSGdWrsMlCycHEG < eWRrZqudqlCECaeIznNDNhpGjMES)
							{
								rKMbZdGJfYlcbgeJlEEhOSPqDpll = dLzYuLvjzQFRrFOfIYEBvsqTjqh[XJXuhWngyYNIQBSGdWrsMlCycHEG].mapSet;
								_ = rKMbZdGJfYlcbgeJlEEhOSPqDpll.Count;
								ocLCFUpLiOsqperXzjhQpvXeZjF = rKMbZdGJfYlcbgeJlEEhOSPqDpll.Maps;
								mAgajYJrnYXpvTZVFwGzfDQSKUbD = ocLCFUpLiOsqperXzjhQpvXeZjF.Count;
								yaxGwfTwKuwgWuwAgYTApcIjjfe = 0;
								goto IL_01d1;
							}
							goto IL_0201;
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
										thMNbPYPmOOMMiKSCAsYmgWgPqW();
									}
								}
								break;
							}
							finally
							{
								kNRJPRTxxUEwHHhlepSeDrYJYSA();
							}
						}
					}

					[DebuggerHidden]
					public ZqxfoFNhFZhmYhVoqoLPxmkMkHqv(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void kNRJPRTxxUEwHHhlepSeDrYJYSA()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (XoXHXxZQIQHjvrPeHjUBeXqFron != null)
						{
							((IDisposable)XoXHXxZQIQHjvrPeHjUBeXqFron).Dispose();
						}
					}

					private void thMNbPYPmOOMMiKSCAsYmgWgPqW()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						((IDisposable)onBAnRvLzFCVcKKUSVNNSaKbMva/*cast due to .constrained prefix*/).Dispose();
					}
				}

				private readonly HRJeTaRmGlgEoVaWhsuEDjticiT uiEFoBlKgTCSNUkEsySXJATkEDyd;

				private Player gESwCZhPTVpAneBRVEYFzquNJMi;

				private ControllerHelper IqqFMkivXajbnQieKffNsZWOHNR;

				private readonly ControllerMapEnabler cHNqpqKSLHedSrRQSLHeKlVznsn;

				private readonly ControllerMapLayoutManager CsIcntzQumzNgYCVTAqZiaMPtmwe;

				private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

				public ControllerMapLayoutManager layoutManager => CsIcntzQumzNgYCVTAqZiaMPtmwe;

				public ControllerMapEnabler mapEnabler => cHNqpqKSLHedSrRQSLHeKlVznsn;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.ULwJdKkNlZyMLRMUSpEcyLnEHMVd(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx);
					}
				}

				internal MapHelper(Player player, ControllerHelper parent, HRJeTaRmGlgEoVaWhsuEDjticiT startingControllerMapInfo, ControllerMapLayoutManager.PseBURjmDgdQyBrNSFfUTuoWirpM controllerMapLayoutManagerSettings, ControllerMapEnabler.FIAqEJWjdCiOptKWtsxrOjilkTn controllerMapEnablerSettings)
				{
					fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
					gESwCZhPTVpAneBRVEYFzquNJMi = player;
					IqqFMkivXajbnQieKffNsZWOHNR = parent;
					uiEFoBlKgTCSNUkEsySXJATkEDyd = startingControllerMapInfo;
					cHNqpqKSLHedSrRQSLHeKlVznsn = new ControllerMapEnabler(player, controllerMapEnablerSettings);
					CsIcntzQumzNgYCVTAqZiaMPtmwe = new ControllerMapLayoutManager(player, controllerMapLayoutManagerSettings);
					CsIcntzQumzNgYCVTAqZiaMPtmwe.ApplyCalledEvent += cHNqpqKSLHedSrRQSLHeKlVznsn.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC<T>(controllerId, categoryId, layoutId, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC<T>(controllerId, categoryName, layoutName, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC(controllerType, controllerId, categoryId, layoutId, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC(controllerType, controllerId, categoryName, layoutName, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					vrFcSdCGiMFDPirCGsoanoDGxchC(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
				}

				private void vrFcSdCGiMFDPirCGsoanoDGxchC<T>(int P_0, int P_1, int P_2, BoolOption P_3) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						kcXbmpEEbWYnmsaitLUVfRZmoRcC(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), P_0, P_1, P_2, P_3);
					}
				}

				private void vrFcSdCGiMFDPirCGsoanoDGxchC<T>(int P_0, string P_1, string P_2, BoolOption P_3) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						kcXbmpEEbWYnmsaitLUVfRZmoRcC(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), P_0, P_1, P_2, P_3);
					}
				}

				private void vrFcSdCGiMFDPirCGsoanoDGxchC(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void vrFcSdCGiMFDPirCGsoanoDGxchC(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, P_2, P_3, P_4);
					}
				}

				public IEnumerable<ControllerMap> GetAllMaps()
				{
					LWxNXTOxiJhCwDJcZDKPZBqXqaK lWxNXTOxiJhCwDJcZDKPZBqXqaK = new LWxNXTOxiJhCwDJcZDKPZBqXqaK(-2);
					lWxNXTOxiJhCwDJcZDKPZBqXqaK.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return lWxNXTOxiJhCwDJcZDKPZBqXqaK;
				}

				public int GetAllMaps(List<ControllerMap> results)
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
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB(results, true);
						}
					}
					return results.Count;
				}

				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					ewOFUOGTxZMbarYDkQqthfuZnVw<T> ewOFUOGTxZMbarYDkQqthfuZnVw2 = new ewOFUOGTxZMbarYDkQqthfuZnVw<T>(-2);
					ewOFUOGTxZMbarYDkQqthfuZnVw2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return ewOFUOGTxZMbarYDkQqthfuZnVw2;
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
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
					if (bEUEMZWgpCwBXKGSoWTyQESUVD.YMoLVIIWiTPkmefXIKyfZeEBOIY<T>(out var controllerType))
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int i = 0; i < count; i++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB(results, true);
						}
					}
					else
					{
						int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
						for (int j = 0; j < spePdqugXpdSjGsMuRlyMjmlhHiD; j++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg3 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(j);
							int count2 = ozEDFrZmqchSdqXvkECRiiBJFWVg3.Count;
							for (int k = 0; k < count2; k++)
							{
								ozEDFrZmqchSdqXvkECRiiBJFWVg3[k].mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB(results, true);
							}
						}
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					ZwUayOoJmtjVzYyNOwNBFLWtjLR zwUayOoJmtjVzYyNOwNBFLWtjLR = new ZwUayOoJmtjVzYyNOwNBFLWtjLR(-2);
					zwUayOoJmtjVzYyNOwNBFLWtjLR.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					zwUayOoJmtjVzYyNOwNBFLWtjLR.DVZsgAzIxkddCLsqBMwMTMemsil = controllerType;
					return zwUayOoJmtjVzYyNOwNBFLWtjLR;
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
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
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					AdizKfGohmNxxiNGIgCcqUDlwyl adizKfGohmNxxiNGIgCcqUDlwyl = new AdizKfGohmNxxiNGIgCcqUDlwyl(-2);
					adizKfGohmNxxiNGIgCcqUDlwyl.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					adizKfGohmNxxiNGIgCcqUDlwyl.GRdOpxNKCFYWbmqOeDFezHUKcsBb = categoryId;
					return adizKfGohmNxxiNGIgCcqUDlwyl;
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					HBYgdpdfERlJbNmhVYGKldDXJZcD<T> hBYgdpdfERlJbNmhVYGKldDXJZcD = new HBYgdpdfERlJbNmhVYGKldDXJZcD<T>(-2);
					hBYgdpdfERlJbNmhVYGKldDXJZcD.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					hBYgdpdfERlJbNmhVYGKldDXJZcD.GRdOpxNKCFYWbmqOeDFezHUKcsBb = categoryId;
					return hBYgdpdfERlJbNmhVYGKldDXJZcD;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					ctXAATNmtThZmGWyBNGYFeIVGhj ctXAATNmtThZmGWyBNGYFeIVGhj2 = new ctXAATNmtThZmGWyBNGYFeIVGhj(-2);
					ctXAATNmtThZmGWyBNGYFeIVGhj2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					ctXAATNmtThZmGWyBNGYFeIVGhj2.GRdOpxNKCFYWbmqOeDFezHUKcsBb = categoryId;
					ctXAATNmtThZmGWyBNGYFeIVGhj2.DVZsgAzIxkddCLsqBMwMTMemsil = controllerType;
					return ctXAATNmtThZmGWyBNGYFeIVGhj2;
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory(int categoryId, List<ControllerMap> results)
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
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory<T>(int categoryId, List<T> results) where T : ControllerMap
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
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					if (bEUEMZWgpCwBXKGSoWTyQESUVD.YMoLVIIWiTPkmefXIKyfZeEBOIY<T>(out var controllerType))
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int i = 0; i < count; i++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(categoryId, results, true);
						}
					}
					else
					{
						int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
						for (int j = 0; j < spePdqugXpdSjGsMuRlyMjmlhHiD; j++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg3 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(j);
							int count2 = ozEDFrZmqchSdqXvkECRiiBJFWVg3.Count;
							for (int k = 0; k < count2; k++)
							{
								ozEDFrZmqchSdqXvkECRiiBJFWVg3[k].mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType, results);
				}

				public int GetAllMapsInCategory(int categoryId, ControllerType controllerType, List<ControllerMap> results)
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
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return uoJIcLYqrQqZFbFteCmcNUwVYrz<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return uoJIcLYqrQqZFbFteCmcNUwVYrz(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMaps(controller.type, controller.id);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return CNmhFrwCwsxyncEehIRMDfLwTUV(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId);
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					ListTools.TryClear(results);
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return 0;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType).sGGfJsmegvsCOukIXQVwszxmlRT(controllerId)?.mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId, results);
				}

				public int GetMapsInCategory(Controller controller, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId, results);
				}

				public int GetMapsInCategory(Controller controller, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId, results);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return CNmhFrwCwsxyncEehIRMDfLwTUV<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory<T>(controllerId, mapCategoryId);
				}

				public int GetMapsInCategory<T>(int controllerId, int categoryId, List<T> results) where T : ControllerMap
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
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					jieiMfaxBWVupOguWuDBKohaarQ jieiMfaxBWVupOguWuDBKohaarQ2 = xNElrBHIPiHboiHFMzuctndwTLY<T>().sGGfJsmegvsCOukIXQVwszxmlRT(controllerId);
					if (jieiMfaxBWVupOguWuDBKohaarQ2 == null)
					{
						return 0;
					}
					jieiMfaxBWVupOguWuDBKohaarQ2.mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerId, mapCategoryId, results);
				}

				public T GetMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)nfKTjxAKEqBgexfqFJhZeyqPEvS(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)nfKTjxAKEqBgexfqFJhZeyqPEvS(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (T)nfKTjxAKEqBgexfqFJhZeyqPEvS(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet;
							ControllerMap controllerMap = mapSet.AhGgMyVkCTwXFsAnooMVJZOIhdM(mapId);
							if (controllerMap != null)
							{
								return controllerMap;
							}
						}
					}
					return null;
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, mapId);
				}

				public ControllerMap GetMap(Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryId, layoutId);
				}

				public ControllerMap GetMap(Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryName, layoutName);
				}

				public T GetFirstMapInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory<T>(controllerId, mapCategoryId);
				}

				public T GetFirstMapInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)iQfSgUicLzvdgnMskLMLWtCCvuo(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory(controllerType, controllerId, mapCategoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return iQfSgUicLzvdgnMskLMLWtCCvuo(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryName);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryId);
				}

				public void AddMap<T>(int controllerId, ControllerMap map) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, map, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(controller, map, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(controllerType, controllerId, map, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, map, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(controller, map, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(controllerType, controllerId, map, startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return klKUfWyjvtultfcPPNUSsChKBOIA(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return klKUfWyjvtultfcPPNUSsChKBOIA(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml<T>(controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromXml(ControllerType controllerType, int controllerId, List<string> xmlStrings)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml(controllerType, controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public bool AddMapFromJson<T>(int controllerId, string jsonString) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return faaQoXWQSnpJBSTbbfvqdvewTOn(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return faaQoXWQSnpJBSTbbfvqdvewTOn(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson<T>(controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromJson(ControllerType controllerType, int controllerId, List<string> jsonStrings)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson(controllerType, controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public void AddEmptyMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						SaGoYbnysNbpiICxYBeyXWTCPLK(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						SaGoYbnysNbpiICxYBeyXWTCPLK(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						SaGoYbnysNbpiICxYBeyXWTCPLK(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						AddEmptyMap(controllerType, controllerId, mapCategoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else if (mapId >= 0)
					{
						qvRrvzjilJDeaLzibIoIPdxKdWW(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						qvRrvzjilJDeaLzibIoIPdxKdWW(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						qvRrvzjilJDeaLzibIoIPdxKdWW(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else if (mapId >= 0)
					{
						qvRrvzjilJDeaLzibIoIPdxKdWW(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						qvRrvzjilJDeaLzibIoIPdxKdWW(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						qvRrvzjilJDeaLzibIoIPdxKdWW(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMaps(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMapsInCategory(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory<T>(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMapsInCategory(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i));
						for (int j = 0; j < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; j++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(controllerType, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
						for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.FCOtpjOvOZFuOGQPrGDxAJbQpGR(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory(controllerType, mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInLayout<T>(int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMapsInLayout(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.otFGhIhqhPfYBmEUeAWeEkaAMyL(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout(controllerType, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMapsForController(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMapsForController(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController<T>(controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(controllerId);
					if (num >= 0)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(controllerId);
					if (num >= 0)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController(controllerType, controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						ClearMapsForControllerInLayout(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(controllerId);
					if (num >= 0)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.otFGhIhqhPfYBmEUeAWeEkaAMyL(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout(controllerType, controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearAllMaps(bool userAssignableOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ClearMaps(IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i), userAssignableOnly);
					}
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return xZiEPaJGyoGVXFrhwoMWalHKJpbx(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return xZiEPaJGyoGVXFrhwoMWalHKJpbx(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
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
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ActionElementMap actionElementMap = xZiEPaJGyoGVXFrhwoMWalHKJpbx(IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
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

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return VJwrQvXKOWZzjsOZvndxvkXGjJZ(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return VJwrQvXKOWZzjsOZvndxvkXGjJZ(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					gjFUDNHJJJwWNbCBEFYFhuheOXe gjFUDNHJJJwWNbCBEFYFhuheOXe2 = new gjFUDNHJJJwWNbCBEFYFhuheOXe(-2);
					gjFUDNHJJJwWNbCBEFYFhuheOXe2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					gjFUDNHJJJwWNbCBEFYFhuheOXe2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
					gjFUDNHJJJwWNbCBEFYFhuheOXe2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
					return gjFUDNHJJJwWNbCBEFYFhuheOXe2;
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

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
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
					if (controller == null)
					{
						results.Clear();
						return 0;
					}
					return LWhXqiGZvfsDHYQmBeTNYFEIBLi(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return LWhXqiGZvfsDHYQmBeTNYFEIBLi(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return ejHJvkpvZUhZyEdaJeIqabJkzOk(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetButtonMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return dxeFTtFEStvhnbXumvSaBnOzxuBG(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return dxeFTtFEStvhnbXumvSaBnOzxuBG(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
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
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ActionElementMap actionElementMap = dxeFTtFEStvhnbXumvSaBnOzxuBG(IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
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

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return KSNEjJyZSTztsvCoRKlnXBnkgymd(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return KSNEjJyZSTztsvCoRKlnXBnkgymd(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					czvtgefVzJPDJUBjUpzqKVQTVaM czvtgefVzJPDJUBjUpzqKVQTVaM2 = new czvtgefVzJPDJUBjUpzqKVQTVaM(-2);
					czvtgefVzJPDJUBjUpzqKVQTVaM2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					czvtgefVzJPDJUBjUpzqKVQTVaM2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
					czvtgefVzJPDJUBjUpzqKVQTVaM2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
					return czvtgefVzJPDJUBjUpzqKVQTVaM2;
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return AxisMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return gcrlGwnGfzSRvmSZiFYjQNkCgzF(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
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
					return gcrlGwnGfzSRvmSZiFYjQNkCgzF(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return sFdBVmMweZKXvEzmlpUDCazVAiQ(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetAxisMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return pxYWkCweHyBWcpyyiCfJGKARCvz(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return pxYWkCweHyBWcpyyiCfJGKARCvz(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ActionElementMap actionElementMap = pxYWkCweHyBWcpyyiCfJGKARCvz(IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
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

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return UuARRBkrMmaqSKvRzCABTVKqLqjB(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return UuARRBkrMmaqSKvRzCABTVKqLqjB(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					esvqSUKdJooVALrWqVChOHsVVXx esvqSUKdJooVALrWqVChOHsVVXx2 = new esvqSUKdJooVALrWqVChOHsVVXx(-2);
					esvqSUKdJooVALrWqVChOHsVVXx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					esvqSUKdJooVALrWqVChOHsVVXx2.YOXLccoEMCTpcLNYciWfwMnsHwE = actionId;
					esvqSUKdJooVALrWqVChOHsVVXx2.jujLEVfWMealwLetaGacIFFBsHPi = skipDisabledMaps;
					return esvqSUKdJooVALrWqVChOHsVVXx2;
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

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return ePxSUKOolofWlfxjpSijeArfkCw(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return ePxSUKOolofWlfxjpSijeArfkCw(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int actionId = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return BGvXRGFtRGxLCvjTaLltejGrgpZ(actionId, skipDisabledMaps, results, false);
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
					return IIlySZvPpyrNkRnOuPoGduEVBk(elementTarget, false, -1, skipDisabledMaps);
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
					return IIlySZvPpyrNkRnOuPoGduEVBk(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
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
					return xeXzPaMQfzAZhpljIAZYHvYxvpQJ(elementTarget, false, -1, skipDisabledMaps);
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
					return xeXzPaMQfzAZhpljIAZYHvYxvpQJ(elementTarget, true, actionId, skipDisabledMaps);
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
					return dyceDrFMqmHuFuGxjUooOwevmZT(elementTarget, false, -1, skipDisabledMaps, results, false);
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
					return dyceDrFMqmHuFuGxjUooOwevmZT(elementTarget, true, actionId, skipDisabledMaps, results, false);
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

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<T>.array;
					}
					return GqtLvtnuOdVLQTIwtDemNdPjoFp<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return GqtLvtnuOdVLQTIwtDemNdPjoFp(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<T>.array;
					}
					return ExnHmhofOxCibhUWHPmjRZmDdWI<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return ExnHmhofOxCibhUWHPmjRZmDdWI(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ArrayTools.Combine(ref array, ExnHmhofOxCibhUWHPmjRZmDdWI(IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int num = 0;
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							num += ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet.rpfglZIJkcusTDdEQyxMcSgrvPR(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int num = 0;
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						num += ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.rpfglZIJkcusTDdEQyxMcSgrvPR(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return SetAllMapsEnabled(state, controller.type, controller.id);
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType).sGGfJsmegvsCOukIXQVwszxmlRT(controllerId)?.mapSet.rpfglZIJkcusTDdEQyxMcSgrvPR(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							num += ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet.scpFlyvnyYSspnAgGuquhzMpySR(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ControllerType controllerType = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.xSAghSIVTBORbOgzbIHOvBeeOML(i);
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							num += SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						num += ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.scpFlyvnyYSspnAgGuquhzMpySR(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId, int layoutId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						num += ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.scpFlyvnyYSspnAgGuquhzMpySR(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controller.type).sGGfJsmegvsCOukIXQVwszxmlRT(controller.id)?.mapSet.scpFlyvnyYSspnAgGuquhzMpySR(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					if (layoutId < 0)
					{
						return 0;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controller.type).sGGfJsmegvsCOukIXQVwszxmlRT(controller.id)?.mapSet.scpFlyvnyYSspnAgGuquhzMpySR(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controller.type, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId, layoutId);
				}

				public void LoadDefaultMaps(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						tFuuvXvEIhblfwKktQADqGJxmQI(false);
						break;
					case ControllerType.Keyboard:
						NcVkKPwxNNIsmzNYNMPcELAADNi(false);
						break;
					case ControllerType.Mouse:
						YcGDcTlWnJupoXBEHCLaNSzihyB(false);
						break;
					case ControllerType.Custom:
						bdQaujzwwxAbrBNBqTqeIbtzeizc(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (category == null)
					{
						return false;
					}
					return ContainsMapInCategory(category.id);
				}

				public bool ContainsMapInCategory(int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							if (ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet.PeooQDKzbxiHAumDgHAYHSJWaCP(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return false;
					}
					return ContainsMapInCategory(mapCategoryId);
				}

				public bool ContainsMapInCategory(ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						if (ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.PeooQDKzbxiHAumDgHAYHSJWaCP(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.TGBTlzxMydGPzMLlNNpkWykXunu(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.TGBTlzxMydGPzMLlNNpkWykXunu(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, behaviorName);
				}

				internal void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
				{
					cHNqpqKSLHedSrRQSLHeKlVznsn.LoadDefaults();
					CsIcntzQumzNgYCVTAqZiaMPtmwe.LoadDefaults();
				}

				internal void tFuuvXvEIhblfwKktQADqGJxmQI(bool P_0)
				{
					if (uiEFoBlKgTCSNUkEsySXJATkEDyd.zbPxhRbVNNQTOCTBGQMztPejLhz == null)
					{
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick);
					IqqFMkivXajbnQieKffNsZWOHNR.VXRpRQGmBLUsrQikVDSFCugvidLN.tQZTPgWjVqUoeRxXBpobvheRKCQ();
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi xMaIGYxSmxoTKaVsVqAuxacFodi = (kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi)ozEDFrZmqchSdqXvkECRiiBJFWVg2[i];
						bool[] array = null;
						if (!P_0)
						{
							int count2 = xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx.Count;
							array = new bool[count2];
							for (int j = 0; j < count2; j++)
							{
								array[j] = xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx[j].enabled;
							}
						}
						xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(false);
						for (int k = 0; k < uiEFoBlKgTCSNUkEsySXJATkEDyd.zbPxhRbVNNQTOCTBGQMztPejLhz.Length; k++)
						{
							iwXtvJqvFoGuivWrwuTStZPyfLO(xMaIGYxSmxoTKaVsVqAuxacFodi.pxFOUEuAQwwDMNyKdQhVGxLNflI, xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx, uiEFoBlKgTCSNUkEsySXJATkEDyd.zbPxhRbVNNQTOCTBGQMztPejLhz[k], P_0);
						}
						if (!P_0)
						{
							int num = MathTools.Min(array.Length, xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx.Count);
							for (int l = 0; l < num; l++)
							{
								xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx[l].enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = false;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.Apply();
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void NcVkKPwxNNIsmzNYNMPcELAADNi(bool P_0)
				{
					if (uiEFoBlKgTCSNUkEsySXJATkEDyd.WcHxNNEiyLFDOYJFlBkhsuHzRgw == null)
					{
						return;
					}
					aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Keyboard).sGGfJsmegvsCOukIXQVwszxmlRT(0).mapSet;
					bool[] array = null;
					if (!P_0)
					{
						int count = mapSet.Count;
						array = new bool[count];
						for (int i = 0; i < count; i++)
						{
							array[i] = mapSet[i].enabled;
						}
					}
					mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(false);
					for (int j = 0; j < uiEFoBlKgTCSNUkEsySXJATkEDyd.WcHxNNEiyLFDOYJFlBkhsuHzRgw.Length; j++)
					{
						DcnWExKAVFAKzCOeUjNwIgwFSGqO dcnWExKAVFAKzCOeUjNwIgwFSGqO = uiEFoBlKgTCSNUkEsySXJATkEDyd.WcHxNNEiyLFDOYJFlBkhsuHzRgw[j];
						if (dcnWExKAVFAKzCOeUjNwIgwFSGqO.categoryId >= 0 && dcnWExKAVFAKzCOeUjNwIgwFSGqO.layoutId >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, dcnWExKAVFAKzCOeUjNwIgwFSGqO.categoryId, dcnWExKAVFAKzCOeUjNwIgwFSGqO.layoutId);
							if (P_0)
							{
								keyboardMap.enabled = dcnWExKAVFAKzCOeUjNwIgwFSGqO.startEnabled;
							}
							rtpMzMuYagCBxfmnimOoYOyhqrK(ControllerType.Keyboard, 0, keyboardMap, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
						}
					}
					if (!P_0)
					{
						int num = MathTools.Min(array.Length, mapSet.Count);
						for (int k = 0; k < num; k++)
						{
							mapSet[k].enabled = array[k];
						}
					}
					bool loadFromUserDataStore = CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = false;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.Apply();
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void YcGDcTlWnJupoXBEHCLaNSzihyB(bool P_0)
				{
					if (uiEFoBlKgTCSNUkEsySXJATkEDyd.CRVXnWJROagVyjiakmRXllScXnJ == null)
					{
						return;
					}
					aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Mouse).sGGfJsmegvsCOukIXQVwszxmlRT(0).mapSet;
					bool[] array = null;
					if (!P_0)
					{
						int count = mapSet.Count;
						array = new bool[count];
						for (int i = 0; i < count; i++)
						{
							array[i] = mapSet[i].enabled;
						}
					}
					mapSet.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(false);
					for (int j = 0; j < uiEFoBlKgTCSNUkEsySXJATkEDyd.CRVXnWJROagVyjiakmRXllScXnJ.Length; j++)
					{
						DcnWExKAVFAKzCOeUjNwIgwFSGqO dcnWExKAVFAKzCOeUjNwIgwFSGqO = uiEFoBlKgTCSNUkEsySXJATkEDyd.CRVXnWJROagVyjiakmRXllScXnJ[j];
						if (dcnWExKAVFAKzCOeUjNwIgwFSGqO.categoryId >= 0 && dcnWExKAVFAKzCOeUjNwIgwFSGqO.layoutId >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, dcnWExKAVFAKzCOeUjNwIgwFSGqO.categoryId, dcnWExKAVFAKzCOeUjNwIgwFSGqO.layoutId);
							if (P_0)
							{
								mouseMap.enabled = dcnWExKAVFAKzCOeUjNwIgwFSGqO.startEnabled;
							}
							rtpMzMuYagCBxfmnimOoYOyhqrK(ControllerType.Mouse, 0, mouseMap, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
						}
					}
					if (!P_0)
					{
						int num = MathTools.Min(array.Length, mapSet.Count);
						for (int k = 0; k < num; k++)
						{
							mapSet[k].enabled = array[k];
						}
					}
					bool loadFromUserDataStore = CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = false;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.Apply();
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void bdQaujzwwxAbrBNBqTqeIbtzeizc(bool P_0)
				{
					if (uiEFoBlKgTCSNUkEsySXJATkEDyd.OZQZHAQmONWByjCRECZBrIFeiRV == null)
					{
						return;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>.XMaIGYxSmxoTKaVsVqAuxacFodi xMaIGYxSmxoTKaVsVqAuxacFodi = (kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>.XMaIGYxSmxoTKaVsVqAuxacFodi)ozEDFrZmqchSdqXvkECRiiBJFWVg2[i];
						bool[] array = null;
						if (!P_0)
						{
							int count2 = xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx.Count;
							array = new bool[count2];
							for (int j = 0; j < count2; j++)
							{
								array[j] = xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx[j].enabled;
							}
						}
						xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(false);
						for (int k = 0; k < uiEFoBlKgTCSNUkEsySXJATkEDyd.OZQZHAQmONWByjCRECZBrIFeiRV.Length; k++)
						{
							udmoJxBWlSsIxgancydegrxPsBs(xMaIGYxSmxoTKaVsVqAuxacFodi.pxFOUEuAQwwDMNyKdQhVGxLNflI, xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx, uiEFoBlKgTCSNUkEsySXJATkEDyd.OZQZHAQmONWByjCRECZBrIFeiRV[k], P_0);
						}
						if (!P_0)
						{
							int num = MathTools.Min(array.Length, xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx.Count);
							for (int l = 0; l < num; l++)
							{
								xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx[l].enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = false;
					CsIcntzQumzNgYCVTAqZiaMPtmwe.Apply();
					CsIcntzQumzNgYCVTAqZiaMPtmwe.loadFromUserDataStore = loadFromUserDataStore;
				}

				private ozEDFrZmqchSdqXvkECRiiBJFWVg xNElrBHIPiHboiHFMzuctndwTLY<T>() where T : ControllerMap
				{
					return IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(bEUEMZWgpCwBXKGSoWTyQESUVD.CopuTrtjBVrkWTQmpWAPqArJZCQ<T>());
				}

				internal global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> GNSjNyVFlGWFObrcnUPBvfIAuXb(Joystick P_0, bool P_1)
				{
					if (P_0 == null || uiEFoBlKgTCSNUkEsySXJATkEDyd.zbPxhRbVNNQTOCTBGQMztPejLhz == null)
					{
						return null;
					}
					global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> cimpQwMUTGMiTwuOvALwFOVgRyp = new global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap>(P_0.id);
					for (int i = 0; i < uiEFoBlKgTCSNUkEsySXJATkEDyd.zbPxhRbVNNQTOCTBGQMztPejLhz.Length; i++)
					{
						iwXtvJqvFoGuivWrwuTStZPyfLO(P_0, cimpQwMUTGMiTwuOvALwFOVgRyp, uiEFoBlKgTCSNUkEsySXJATkEDyd.zbPxhRbVNNQTOCTBGQMztPejLhz[i], P_1);
					}
					if (cimpQwMUTGMiTwuOvALwFOVgRyp.Count == 0)
					{
						return null;
					}
					return cimpQwMUTGMiTwuOvALwFOVgRyp;
				}

				private void iwXtvJqvFoGuivWrwuTStZPyfLO(Joystick P_0, global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> P_1, DcnWExKAVFAKzCOeUjNwIgwFSGqO P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.categoryId >= 0 && P_2.layoutId >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.dAntuILfYUUPSPWGcWNciDFsLko(P_0, P_2.categoryId, P_2.layoutId);
						UqhYnihUfIHBqSaeTWbwiJVKQLu(P_0, joystickMap);
						BoolOption boolOption = BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe;
						if (P_3)
						{
							boolOption = (P_2.startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
						}
						P_1.kXumKtfSBwewksMrxulEXBnmjdWG(joystickMap, boolOption);
					}
				}

				internal global::CimpQwMUTGMiTwuOvALwFOVgRyp<CustomControllerMap> LCVXrfdznweRpTvqVKrqYdjcbTX(CustomController P_0, bool P_1)
				{
					if (P_0 == null || uiEFoBlKgTCSNUkEsySXJATkEDyd.OZQZHAQmONWByjCRECZBrIFeiRV == null)
					{
						return null;
					}
					global::CimpQwMUTGMiTwuOvALwFOVgRyp<CustomControllerMap> cimpQwMUTGMiTwuOvALwFOVgRyp = new global::CimpQwMUTGMiTwuOvALwFOVgRyp<CustomControllerMap>(P_0.id);
					for (int i = 0; i < uiEFoBlKgTCSNUkEsySXJATkEDyd.OZQZHAQmONWByjCRECZBrIFeiRV.Length; i++)
					{
						udmoJxBWlSsIxgancydegrxPsBs(P_0, cimpQwMUTGMiTwuOvALwFOVgRyp, uiEFoBlKgTCSNUkEsySXJATkEDyd.OZQZHAQmONWByjCRECZBrIFeiRV[i], P_1);
					}
					if (cimpQwMUTGMiTwuOvALwFOVgRyp.Count == 0)
					{
						return null;
					}
					return cimpQwMUTGMiTwuOvALwFOVgRyp;
				}

				private void udmoJxBWlSsIxgancydegrxPsBs(CustomController P_0, global::CimpQwMUTGMiTwuOvALwFOVgRyp<CustomControllerMap> P_1, DcnWExKAVFAKzCOeUjNwIgwFSGqO P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.categoryId >= 0 && P_2.layoutId >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.AuMvOlnFHBkcQXDNUsENAfSzNfH(P_2.categoryId, P_0.sourceControllerId, P_2.layoutId);
						UqhYnihUfIHBqSaeTWbwiJVKQLu(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe;
						if (P_3)
						{
							boolOption = (P_2.startEnabled ? BoolOption.DfFGimvsWRFrdajtnMolskrJGYk : BoolOption.CXocyqxKKGDkBifdAihOrKSMotD);
						}
						P_1.kXumKtfSBwewksMrxulEXBnmjdWG(customControllerMap, boolOption);
					}
				}

				internal void UqhYnihUfIHBqSaeTWbwiJVKQLu(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
						P_0.UqhYnihUfIHBqSaeTWbwiJVKQLu(P_1);
					}
				}

				private IList<T> uoJIcLYqrQqZFbFteCmcNUwVYrz<T>(int P_0) where T : ControllerMap
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = xNElrBHIPiHboiHFMzuctndwTLY<T>();
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
					if (num < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB<T>();
				}

				private IList<T> uoJIcLYqrQqZFbFteCmcNUwVYrz<T>(Controller P_0) where T : ControllerMap
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = xNElrBHIPiHboiHFMzuctndwTLY<T>();
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2.sGGfJsmegvsCOukIXQVwszxmlRT(P_0)?.mapSet.YVxZtgPOIbGPiJfXEJlRdcBWVsB<T>();
				}

				private IList<ControllerMap> uoJIcLYqrQqZFbFteCmcNUwVYrz(ControllerType P_0, int P_1)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
				}

				private IList<ControllerMap> uoJIcLYqrQqZFbFteCmcNUwVYrz(Controller P_0)
				{
					return uoJIcLYqrQqZFbFteCmcNUwVYrz(P_0.type, P_0.id);
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, P_2, P_3, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(Controller P_0, int P_1, int P_2)
				{
					kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, P_2, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, P_2, P_3, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(Controller P_0, string P_1, string P_2)
				{
					kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, P_2, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num >= 0)
					{
						Controller controller = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller;
						ControllerMap controllerMap = ReInput.UserData.UlqVyTSDDBoZvjxnAEFEnfKUirw(controller, P_2, P_3);
						rtpMzMuYagCBxfmnimOoYOyhqrK(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void kcXbmpEEbWYnmsaitLUVfRZmoRcC(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					kcXbmpEEbWYnmsaitLUVfRZmoRcC(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void rtpMzMuYagCBxfmnimOoYOyhqrK(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0.type);
						int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0.id);
						if (num >= 0)
						{
							UqhYnihUfIHBqSaeTWbwiJVKQLu(P_0, P_1);
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.kXumKtfSBwewksMrxulEXBnmjdWG(P_1, P_2);
							cHNqpqKSLHedSrRQSLHeKlVznsn.Apply();
						}
					}
				}

				private void rtpMzMuYagCBxfmnimOoYOyhqrK(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						rtpMzMuYagCBxfmnimOoYOyhqrK(controller, P_2, P_3);
					}
				}

				private bool klKUfWyjvtultfcPPNUSsChKBOIA(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.AxGMnpcloIAUTQTSFCdghQatHHxd(P_0);
					if (!controllerMap.upgXVjgAapuDEkrYPRuySHNdfEO(P_2))
					{
						return false;
					}
					rtpMzMuYagCBxfmnimOoYOyhqrK(P_0, P_1, controllerMap, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
					return true;
				}

				private int YUoJsFTbUJaeqvBMNVOuXsjJbdd(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (klKUfWyjvtultfcPPNUSsChKBOIA(P_0, P_1, P_2[i]))
						{
							num2++;
						}
					}
					return num2;
				}

				private bool faaQoXWQSnpJBSTbbfvqdvewTOn(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.AxGMnpcloIAUTQTSFCdghQatHHxd(P_0);
					if (!controllerMap.oHshqCkqMeppbeLmIyvHTLAZxmk(P_2))
					{
						return false;
					}
					rtpMzMuYagCBxfmnimOoYOyhqrK(P_0, P_1, controllerMap, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
					return true;
				}

				private int SrGOidnBmiPcxZpmEnDoOTWiOsQ(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (faaQoXWQSnpJBSTbbfvqdvewTOn(P_0, P_1, P_2[i]))
						{
							num2++;
						}
					}
					return num2;
				}

				private void SaGoYbnysNbpiICxYBeyXWTCPLK(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num >= 0)
					{
						Controller controller = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller;
						ControllerMap controllerMap = ControllerMap.cPddxWgeQLKoABjtJFakbMLbPOFb(controller, P_2, P_3);
						rtpMzMuYagCBxfmnimOoYOyhqrK(controller.type, controller.id, controllerMap, BoolOption.YyyWBmKOJYtvATvDbTCopGoCFKe);
					}
				}

				private void SaGoYbnysNbpiICxYBeyXWTCPLK(Controller P_0, int P_1, int P_2)
				{
					SaGoYbnysNbpiICxYBeyXWTCPLK(P_0.type, P_0.id, P_1, P_2);
				}

				private void SaGoYbnysNbpiICxYBeyXWTCPLK(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						SaGoYbnysNbpiICxYBeyXWTCPLK(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void SaGoYbnysNbpiICxYBeyXWTCPLK(Controller P_0, string P_1, string P_2)
				{
					SaGoYbnysNbpiICxYBeyXWTCPLK(P_0.type, P_0.id, P_1, P_2);
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(ControllerType P_0, int P_1, int P_2)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num >= 0)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.obGjIYVtlqpWbqaUmUgWznBYgWi(P_2);
					}
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(Controller P_0, int P_1)
				{
					qvRrvzjilJDeaLzibIoIPdxKdWW(P_0.type, P_0.id, P_1);
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num >= 0)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_2);
					}
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(Controller P_0, ControllerMap P_1)
				{
					qvRrvzjilJDeaLzibIoIPdxKdWW(P_0.type, P_0.id, P_1.id);
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num >= 0)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_2, P_3);
					}
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(Controller P_0, int P_1, int P_2)
				{
					qvRrvzjilJDeaLzibIoIPdxKdWW(P_0.type, P_0.id, P_1, P_2);
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.FCOtpjOvOZFuOGQPrGDxAJbQpGR(mapCategoryId, layoutId);
						}
					}
				}

				private void qvRrvzjilJDeaLzibIoIPdxKdWW(Controller P_0, string P_1, string P_2)
				{
					qvRrvzjilJDeaLzibIoIPdxKdWW(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap nfKTjxAKEqBgexfqFJhZeyqPEvS(ControllerType P_0, int P_1, int P_2)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.AhGgMyVkCTwXFsAnooMVJZOIhdM(P_2);
				}

				private ControllerMap nfKTjxAKEqBgexfqFJhZeyqPEvS(Controller P_0, int P_1)
				{
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(P_0.type, P_0.id, P_1);
				}

				private ControllerMap nfKTjxAKEqBgexfqFJhZeyqPEvS(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.AhGgMyVkCTwXFsAnooMVJZOIhdM(P_2, P_3);
				}

				private ControllerMap nfKTjxAKEqBgexfqFJhZeyqPEvS(Controller P_0, int P_1, int P_2)
				{
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap nfKTjxAKEqBgexfqFJhZeyqPEvS(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap nfKTjxAKEqBgexfqFJhZeyqPEvS(Controller P_0, string P_1, string P_2)
				{
					return nfKTjxAKEqBgexfqFJhZeyqPEvS(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap iQfSgUicLzvdgnMskLMLWtCCvuo(ControllerType P_0, int P_1, int P_2)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.abSRUPMaTqksGXKCVmPDIunVziC(P_2);
				}

				private ControllerMap iQfSgUicLzvdgnMskLMLWtCCvuo(Controller P_0, int P_1)
				{
					return iQfSgUicLzvdgnMskLMLWtCCvuo(P_0.type, P_0.id, P_1);
				}

				private ControllerMap iQfSgUicLzvdgnMskLMLWtCCvuo(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return iQfSgUicLzvdgnMskLMLWtCCvuo(P_0, P_1, mapCategoryId);
				}

				private ControllerMap iQfSgUicLzvdgnMskLMLWtCCvuo(Controller P_0, string P_1)
				{
					return iQfSgUicLzvdgnMskLMLWtCCvuo(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] IEVBKyIbBTtZWMrAhyOqlqIhtzi(ControllerType P_0)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = 0;
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						num += ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Count;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; j++)
					{
						aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet;
						for (int k = 0; k < mapSet.Count; k++)
						{
							array[num] = mapSet[k];
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] GqtLvtnuOdVLQTIwtDemNdPjoFp(ControllerType P_0, int P_1, bool P_2)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet;
					for (int i = 0; i < mapSet.Count; i++)
					{
						ControllerMap controllerMap = mapSet[i];
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller;
						list.Add(ControllerMapSaveData.AxGMnpcloIAUTQTSFCdghQatHHxd(controller, controllerMap));
					}
					return list.ToArray();
				}

				private T[] GqtLvtnuOdVLQTIwtDemNdPjoFp<T>(int P_0, bool P_1) where T : ControllerMapSaveData
				{
					ControllerType controllerType = bEUEMZWgpCwBXKGSoWTyQESUVD.QArtBhHPXsBRkBXusELJmddQoWdX<T>();
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0);
					if (num < 0)
					{
						return null;
					}
					List<T> list = new List<T>();
					aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet;
					for (int i = 0; i < mapSet.Count; i++)
					{
						ControllerMap controllerMap = mapSet[i];
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller;
						list.Add(ControllerMapSaveData.AxGMnpcloIAUTQTSFCdghQatHHxd<T>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] ExnHmhofOxCibhUWHPmjRZmDdWI(ControllerType P_0, bool P_1)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet;
						for (int j = 0; j < mapSet.Count; j++)
						{
							ControllerMap controllerMap = mapSet[j];
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].controller;
							list.Add(ControllerMapSaveData.AxGMnpcloIAUTQTSFCdghQatHHxd(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private T[] ExnHmhofOxCibhUWHPmjRZmDdWI<T>(bool P_0) where T : ControllerMapSaveData
				{
					ControllerType controllerType = bEUEMZWgpCwBXKGSoWTyQESUVD.QArtBhHPXsBRkBXusELJmddQoWdX<T>();
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType);
					List<T> list = new List<T>();
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet;
						for (int j = 0; j < mapSet.Count; j++)
						{
							ControllerMap controllerMap = mapSet[j];
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].controller;
							list.Add(ControllerMapSaveData.AxGMnpcloIAUTQTSFCdghQatHHxd<T>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int pbuGMrCDiTXfduWnPcwPfrwCCEyT(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return 0;
					}
					return ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.ESPRzqahDrWFxFwrAMSRzIVLxXb(P_2, P_3, false);
				}

				private int pbuGMrCDiTXfduWnPcwPfrwCCEyT(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return pbuGMrCDiTXfduWnPcwPfrwCCEyT(P_0.type, P_0.id, P_1, P_2);
				}

				private int pbuGMrCDiTXfduWnPcwPfrwCCEyT(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return pbuGMrCDiTXfduWnPcwPfrwCCEyT(P_0, P_1, mapCategoryId, P_3);
				}

				private int pbuGMrCDiTXfduWnPcwPfrwCCEyT(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return pbuGMrCDiTXfduWnPcwPfrwCCEyT(P_0.type, P_0.id, P_1, P_2);
				}

				private IEnumerable<ControllerMap> CNmhFrwCwsxyncEehIRMDfLwTUV(ControllerType P_0, int P_1, int P_2)
				{
					ZuIvGUtQmKUvzyaDPCnSkiqbvcD zuIvGUtQmKUvzyaDPCnSkiqbvcD = new ZuIvGUtQmKUvzyaDPCnSkiqbvcD(-2);
					zuIvGUtQmKUvzyaDPCnSkiqbvcD.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					zuIvGUtQmKUvzyaDPCnSkiqbvcD.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					zuIvGUtQmKUvzyaDPCnSkiqbvcD.JaIbgBvkJnGWqmXPHauWGgRuboj = P_1;
					zuIvGUtQmKUvzyaDPCnSkiqbvcD.GRdOpxNKCFYWbmqOeDFezHUKcsBb = P_2;
					return zuIvGUtQmKUvzyaDPCnSkiqbvcD;
				}

				private IEnumerable<T> CNmhFrwCwsxyncEehIRMDfLwTUV<T>(int P_0, int P_1) where T : ControllerMap
				{
					CmqLlPnmTGCTlsaKIcSxgneMRoKp<T> cmqLlPnmTGCTlsaKIcSxgneMRoKp = new CmqLlPnmTGCTlsaKIcSxgneMRoKp<T>(-2);
					cmqLlPnmTGCTlsaKIcSxgneMRoKp.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					cmqLlPnmTGCTlsaKIcSxgneMRoKp.JaIbgBvkJnGWqmXPHauWGgRuboj = P_0;
					cmqLlPnmTGCTlsaKIcSxgneMRoKp.GRdOpxNKCFYWbmqOeDFezHUKcsBb = P_1;
					return cmqLlPnmTGCTlsaKIcSxgneMRoKp;
				}

				private ActionElementMap xZiEPaJGyoGVXFrhwoMWalHKJpbx(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								ActionElementMap firstButtonMapWithAction = maps[j].GetFirstButtonMapWithAction(P_1, P_2);
								if (firstButtonMapWithAction != null)
								{
									return firstButtonMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap xZiEPaJGyoGVXFrhwoMWalHKJpbx(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return xZiEPaJGyoGVXFrhwoMWalHKJpbx(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> VJwrQvXKOWZzjsOZvndxvkXGjJZ(ControllerType P_0, int P_1, bool P_2)
				{
					anrrFKznjManUhXnigeUSoLsOhQU anrrFKznjManUhXnigeUSoLsOhQU2 = new anrrFKznjManUhXnigeUSoLsOhQU(-2);
					anrrFKznjManUhXnigeUSoLsOhQU2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					anrrFKznjManUhXnigeUSoLsOhQU2.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					anrrFKznjManUhXnigeUSoLsOhQU2.YOXLccoEMCTpcLNYciWfwMnsHwE = P_1;
					anrrFKznjManUhXnigeUSoLsOhQU2.jujLEVfWMealwLetaGacIFFBsHPi = P_2;
					return anrrFKznjManUhXnigeUSoLsOhQU2;
				}

				private IEnumerable<ActionElementMap> VJwrQvXKOWZzjsOZvndxvkXGjJZ(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return VJwrQvXKOWZzjsOZvndxvkXGjJZ(P_0, num, P_2);
				}

				private ActionElementMap dxeFTtFEStvhnbXumvSaBnOzxuBG(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if (!(maps[j] is ControllerMapWithAxes))
							{
								return null;
							}
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								ActionElementMap firstAxisMapWithAction = (maps[j] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_1, P_2);
								if (firstAxisMapWithAction != null)
								{
									return firstAxisMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap dxeFTtFEStvhnbXumvSaBnOzxuBG(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return dxeFTtFEStvhnbXumvSaBnOzxuBG(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> KSNEjJyZSTztsvCoRKlnXBnkgymd(ControllerType P_0, int P_1, bool P_2)
				{
					xgiTuUQAiEmORSEnJbTwAHjnnCJv xgiTuUQAiEmORSEnJbTwAHjnnCJv2 = new xgiTuUQAiEmORSEnJbTwAHjnnCJv(-2);
					xgiTuUQAiEmORSEnJbTwAHjnnCJv2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					xgiTuUQAiEmORSEnJbTwAHjnnCJv2.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					xgiTuUQAiEmORSEnJbTwAHjnnCJv2.YOXLccoEMCTpcLNYciWfwMnsHwE = P_1;
					xgiTuUQAiEmORSEnJbTwAHjnnCJv2.jujLEVfWMealwLetaGacIFFBsHPi = P_2;
					return xgiTuUQAiEmORSEnJbTwAHjnnCJv2;
				}

				private IEnumerable<ActionElementMap> KSNEjJyZSTztsvCoRKlnXBnkgymd(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return KSNEjJyZSTztsvCoRKlnXBnkgymd(P_0, num, P_2);
				}

				private ActionElementMap pxYWkCweHyBWcpyyiCfJGKARCvz(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								ActionElementMap firstElementMapWithAction = maps[j].GetFirstElementMapWithAction(P_1, P_2);
								if (firstElementMapWithAction != null)
								{
									return firstElementMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap pxYWkCweHyBWcpyyiCfJGKARCvz(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return pxYWkCweHyBWcpyyiCfJGKARCvz(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> UuARRBkrMmaqSKvRzCABTVKqLqjB(ControllerType P_0, int P_1, bool P_2)
				{
					soARGmZLzoTHSAypHjPVcofbEOv soARGmZLzoTHSAypHjPVcofbEOv2 = new soARGmZLzoTHSAypHjPVcofbEOv(-2);
					soARGmZLzoTHSAypHjPVcofbEOv2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					soARGmZLzoTHSAypHjPVcofbEOv2.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					soARGmZLzoTHSAypHjPVcofbEOv2.YOXLccoEMCTpcLNYciWfwMnsHwE = P_1;
					soARGmZLzoTHSAypHjPVcofbEOv2.jujLEVfWMealwLetaGacIFFBsHPi = P_2;
					return soARGmZLzoTHSAypHjPVcofbEOv2;
				}

				private IEnumerable<ActionElementMap> UuARRBkrMmaqSKvRzCABTVKqLqjB(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return UuARRBkrMmaqSKvRzCABTVKqLqjB(P_0, num, P_2);
				}

				private int ejHJvkpvZUhZyEdaJeIqabJkzOk(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet;
							int count2 = mapSet.Count;
							for (int k = 0; k < count2; k++)
							{
								ControllerMap controllerMap = mapSet[k];
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.ejHJvkpvZUhZyEdaJeIqabJkzOk(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int sFdBVmMweZKXvEzmlpUDCazVAiQ(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet;
							int count2 = mapSet.Count;
							for (int k = 0; k < count2; k++)
							{
								if (mapSet[k] is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.sFdBVmMweZKXvEzmlpUDCazVAiQ(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int BGvXRGFtRGxLCvjTaLltejGrgpZ(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
					int spePdqugXpdSjGsMuRlyMjmlhHiD = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
					for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
					{
						ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i);
						int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
						for (int j = 0; j < count; j++)
						{
							aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[j].mapSet;
							int count2 = mapSet.Count;
							for (int k = 0; k < count2; k++)
							{
								ControllerMap controllerMap = mapSet[k];
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.BGvXRGFtRGxLCvjTaLltejGrgpZ(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int LWhXqiGZvfsDHYQmBeTNYFEIBLi(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								num += maps[j].ejHJvkpvZUhZyEdaJeIqabJkzOk(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int LWhXqiGZvfsDHYQmBeTNYFEIBLi(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return LWhXqiGZvfsDHYQmBeTNYFEIBLi(P_0, num, P_2, P_3, P_4);
				}

				private int gcrlGwnGfzSRvmSZiFYjQNkCgzF(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if (!(maps[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								num += (maps[j] as ControllerMapWithAxes).sFdBVmMweZKXvEzmlpUDCazVAiQ(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int gcrlGwnGfzSRvmSZiFYjQNkCgzF(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return gcrlGwnGfzSRvmSZiFYjQNkCgzF(P_0, num, P_2, P_3, P_4);
				}

				private int ePxSUKOolofWlfxjpSijeArfkCw(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					for (int i = 0; i < ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count; i++)
					{
						IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								num += maps[j].BGvXRGFtRGxLCvjTaLltejGrgpZ(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int ePxSUKOolofWlfxjpSijeArfkCw(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_1);
					return ePxSUKOolofWlfxjpSijeArfkCw(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap xZiEPaJGyoGVXFrhwoMWalHKJpbx(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							ActionElementMap firstButtonMapWithAction = maps[i].GetFirstButtonMapWithAction(P_2, P_3);
							if (firstButtonMapWithAction != null)
							{
								return firstButtonMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap xZiEPaJGyoGVXFrhwoMWalHKJpbx(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return xZiEPaJGyoGVXFrhwoMWalHKJpbx(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> VJwrQvXKOWZzjsOZvndxvkXGjJZ(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					iWKMLkmKDlwCCSfWKxKwnwEhkDu iWKMLkmKDlwCCSfWKxKwnwEhkDu2 = new iWKMLkmKDlwCCSfWKxKwnwEhkDu(-2);
					iWKMLkmKDlwCCSfWKxKwnwEhkDu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					iWKMLkmKDlwCCSfWKxKwnwEhkDu2.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					iWKMLkmKDlwCCSfWKxKwnwEhkDu2.JaIbgBvkJnGWqmXPHauWGgRuboj = P_1;
					iWKMLkmKDlwCCSfWKxKwnwEhkDu2.YOXLccoEMCTpcLNYciWfwMnsHwE = P_2;
					iWKMLkmKDlwCCSfWKxKwnwEhkDu2.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					return iWKMLkmKDlwCCSfWKxKwnwEhkDu2;
				}

				private IEnumerable<ActionElementMap> VJwrQvXKOWZzjsOZvndxvkXGjJZ(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return VJwrQvXKOWZzjsOZvndxvkXGjJZ(P_0, P_1, num, P_3);
				}

				private ActionElementMap dxeFTtFEStvhnbXumvSaBnOzxuBG(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if (!(maps[i] is ControllerMapWithAxes))
						{
							return null;
						}
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							ActionElementMap firstAxisMapWithAction = (maps[i] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_2, P_3);
							if (firstAxisMapWithAction != null)
							{
								return firstAxisMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap dxeFTtFEStvhnbXumvSaBnOzxuBG(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return dxeFTtFEStvhnbXumvSaBnOzxuBG(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> KSNEjJyZSTztsvCoRKlnXBnkgymd(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					OakATNNtfuuEGYBfsqdhODyiNMN oakATNNtfuuEGYBfsqdhODyiNMN = new OakATNNtfuuEGYBfsqdhODyiNMN(-2);
					oakATNNtfuuEGYBfsqdhODyiNMN.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					oakATNNtfuuEGYBfsqdhODyiNMN.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					oakATNNtfuuEGYBfsqdhODyiNMN.JaIbgBvkJnGWqmXPHauWGgRuboj = P_1;
					oakATNNtfuuEGYBfsqdhODyiNMN.YOXLccoEMCTpcLNYciWfwMnsHwE = P_2;
					oakATNNtfuuEGYBfsqdhODyiNMN.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					return oakATNNtfuuEGYBfsqdhODyiNMN;
				}

				private IEnumerable<ActionElementMap> KSNEjJyZSTztsvCoRKlnXBnkgymd(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return KSNEjJyZSTztsvCoRKlnXBnkgymd(P_0, P_1, num, P_3);
				}

				private ActionElementMap pxYWkCweHyBWcpyyiCfJGKARCvz(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							ActionElementMap firstElementMapWithAction = maps[i].GetFirstElementMapWithAction(P_2, P_3);
							if (firstElementMapWithAction != null)
							{
								return firstElementMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap pxYWkCweHyBWcpyyiCfJGKARCvz(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return pxYWkCweHyBWcpyyiCfJGKARCvz(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> UuARRBkrMmaqSKvRzCABTVKqLqjB(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					agOahSLZDZFdsJfAuQQwTgkkBVl agOahSLZDZFdsJfAuQQwTgkkBVl2 = new agOahSLZDZFdsJfAuQQwTgkkBVl(-2);
					agOahSLZDZFdsJfAuQQwTgkkBVl2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					agOahSLZDZFdsJfAuQQwTgkkBVl2.DVZsgAzIxkddCLsqBMwMTMemsil = P_0;
					agOahSLZDZFdsJfAuQQwTgkkBVl2.JaIbgBvkJnGWqmXPHauWGgRuboj = P_1;
					agOahSLZDZFdsJfAuQQwTgkkBVl2.YOXLccoEMCTpcLNYciWfwMnsHwE = P_2;
					agOahSLZDZFdsJfAuQQwTgkkBVl2.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					return agOahSLZDZFdsJfAuQQwTgkkBVl2;
				}

				private IEnumerable<ActionElementMap> UuARRBkrMmaqSKvRzCABTVKqLqjB(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return UuARRBkrMmaqSKvRzCABTVKqLqjB(P_0, P_1, num, P_3);
				}

				private int LWhXqiGZvfsDHYQmBeTNYFEIBLi(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						ControllerMap controllerMap = maps[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.ejHJvkpvZUhZyEdaJeIqabJkzOk(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int LWhXqiGZvfsDHYQmBeTNYFEIBLi(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return LWhXqiGZvfsDHYQmBeTNYFEIBLi(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int gcrlGwnGfzSRvmSZiFYjQNkCgzF(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = maps[i] as ControllerMapWithAxes;
						if (maps == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.sFdBVmMweZKXvEzmlpUDCazVAiQ(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int gcrlGwnGfzSRvmSZiFYjQNkCgzF(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return gcrlGwnGfzSRvmSZiFYjQNkCgzF(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int ePxSUKOolofWlfxjpSijeArfkCw(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
					int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> maps = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							num2 += maps[i].BGvXRGFtRGxLCvjTaLltejGrgpZ(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int ePxSUKOolofWlfxjpSijeArfkCw(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
					return ePxSUKOolofWlfxjpSijeArfkCw(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap xeXzPaMQfzAZhpljIAZYHvYxvpQJ(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					if (P_0 == null)
					{
						return null;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return null;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controller.type);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					for (int i = 0; i < count; i++)
					{
						aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet;
						_ = mapSet.Count;
						IList<ControllerMap> maps = mapSet.Maps;
						int count2 = maps.Count;
						for (int j = 0; j < count2; j++)
						{
							ControllerMap controllerMap = maps[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.xeXzPaMQfzAZhpljIAZYHvYxvpQJ(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				private IEnumerable<ActionElementMap> IIlySZvPpyrNkRnOuPoGduEVBk(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					ZqxfoFNhFZhmYhVoqoLPxmkMkHqv zqxfoFNhFZhmYhVoqoLPxmkMkHqv = new ZqxfoFNhFZhmYhVoqoLPxmkMkHqv(-2);
					zqxfoFNhFZhmYhVoqoLPxmkMkHqv.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					zqxfoFNhFZhmYhVoqoLPxmkMkHqv.jcELyNXpDJBwHWlzxALZjKPhJZo = P_0;
					zqxfoFNhFZhmYhVoqoLPxmkMkHqv.INaJPwadwIRqaQLyTirCJsPEDsTF = P_1;
					zqxfoFNhFZhmYhVoqoLPxmkMkHqv.YOXLccoEMCTpcLNYciWfwMnsHwE = P_2;
					zqxfoFNhFZhmYhVoqoLPxmkMkHqv.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					return zqxfoFNhFZhmYhVoqoLPxmkMkHqv;
				}

				private int dyceDrFMqmHuFuGxjUooOwevmZT(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_0 == null)
					{
						return 0;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return 0;
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = IqqFMkivXajbnQieKffNsZWOHNR.qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controller.type);
					int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
					int num = 0;
					for (int i = 0; i < count; i++)
					{
						aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].mapSet;
						_ = mapSet.Count;
						IList<ControllerMap> maps = mapSet.Maps;
						int count2 = maps.Count;
						for (int j = 0; j < count2; j++)
						{
							ControllerMap controllerMap = maps[j];
							if (!P_3 || controllerMap.enabled)
							{
								num += controllerMap.dyceDrFMqmHuFuGxjUooOwevmZT(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
							}
						}
					}
					return num;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class uKjmyvnrJCcsPqfrcsjZnGFocSMc : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public Joystick NArLjIAVtEHiGIedjNcmErVtMkL;

					public ControllerPollingInfo NUHPQHDsSEgQgPiouCKCrItTFdv;

					public ControllerPollingInfo rGAiNTECSpQUMyisNaWevBwnczR;

					public IEnumerator<ControllerPollingInfo> dEXhiNNhrvQiNOpcBIaioWopVcx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						uKjmyvnrJCcsPqfrcsjZnGFocSMc uKjmyvnrJCcsPqfrcsjZnGFocSMc2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							uKjmyvnrJCcsPqfrcsjZnGFocSMc2 = this;
						}
						else
						{
							uKjmyvnrJCcsPqfrcsjZnGFocSMc2 = new uKjmyvnrJCcsPqfrcsjZnGFocSMc(0);
							uKjmyvnrJCcsPqfrcsjZnGFocSMc2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						uKjmyvnrJCcsPqfrcsjZnGFocSMc2.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						return uKjmyvnrJCcsPqfrcsjZnGFocSMc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0)
								{
									break;
								}
								NArLjIAVtEHiGIedjNcmErVtMkL = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(OxaYhfaGlOIumOWmOozrcdXdBYi);
								if (NArLjIAVtEHiGIedjNcmErVtMkL == null)
								{
									break;
								}
								dEXhiNNhrvQiNOpcBIaioWopVcx = NArLjIAVtEHiGIedjNcmErVtMkL.PollForAllElements().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (dEXhiNNhrvQiNOpcBIaioWopVcx.MoveNext())
								{
									NUHPQHDsSEgQgPiouCKCrItTFdv = dEXhiNNhrvQiNOpcBIaioWopVcx.Current;
									ref ControllerPollingInfo reference = ref rGAiNTECSpQUMyisNaWevBwnczR;
									reference = new ControllerPollingInfo(NUHPQHDsSEgQgPiouCKCrItTFdv);
									rGAiNTECSpQUMyisNaWevBwnczR.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = rGAiNTECSpQUMyisNaWevBwnczR;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								xlARUvDxbqWgVhLiHEudcZxPSEd();
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
								xlARUvDxbqWgVhLiHEudcZxPSEd();
							}
						}
					}

					[DebuggerHidden]
					public uKjmyvnrJCcsPqfrcsjZnGFocSMc(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void xlARUvDxbqWgVhLiHEudcZxPSEd()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (dEXhiNNhrvQiNOpcBIaioWopVcx != null)
						{
							dEXhiNNhrvQiNOpcBIaioWopVcx.Dispose();
						}
					}
				}

				private sealed class ooujUiGXYnoqbnFFXqwtksvfnca : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public Joystick BrfrmIvHtAuusOQjOLIePuQsIcL;

					public ControllerPollingInfo iuDGQYoNoCBvvaipuFBEHXecHSQG;

					public ControllerPollingInfo rrfMxaoorInExZVPPZQtRpqVINV;

					public IEnumerator<ControllerPollingInfo> AUKeVIRoCIDWAHtgqETTxbDJnksO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ooujUiGXYnoqbnFFXqwtksvfnca ooujUiGXYnoqbnFFXqwtksvfnca2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							ooujUiGXYnoqbnFFXqwtksvfnca2 = this;
						}
						else
						{
							ooujUiGXYnoqbnFFXqwtksvfnca2 = new ooujUiGXYnoqbnFFXqwtksvfnca(0);
							ooujUiGXYnoqbnFFXqwtksvfnca2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						ooujUiGXYnoqbnFFXqwtksvfnca2.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						return ooujUiGXYnoqbnFFXqwtksvfnca2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0)
								{
									break;
								}
								BrfrmIvHtAuusOQjOLIePuQsIcL = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(OxaYhfaGlOIumOWmOozrcdXdBYi);
								if (BrfrmIvHtAuusOQjOLIePuQsIcL == null)
								{
									break;
								}
								AUKeVIRoCIDWAHtgqETTxbDJnksO = BrfrmIvHtAuusOQjOLIePuQsIcL.PollForAllElementsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (AUKeVIRoCIDWAHtgqETTxbDJnksO.MoveNext())
								{
									iuDGQYoNoCBvvaipuFBEHXecHSQG = AUKeVIRoCIDWAHtgqETTxbDJnksO.Current;
									ref ControllerPollingInfo reference = ref rrfMxaoorInExZVPPZQtRpqVINV;
									reference = new ControllerPollingInfo(iuDGQYoNoCBvvaipuFBEHXecHSQG);
									rrfMxaoorInExZVPPZQtRpqVINV.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = rrfMxaoorInExZVPPZQtRpqVINV;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								YRCxInTcIAtSzhukcbJuqlsvowc();
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
								YRCxInTcIAtSzhukcbJuqlsvowc();
							}
						}
					}

					[DebuggerHidden]
					public ooujUiGXYnoqbnFFXqwtksvfnca(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void YRCxInTcIAtSzhukcbJuqlsvowc()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (AUKeVIRoCIDWAHtgqETTxbDJnksO != null)
						{
							AUKeVIRoCIDWAHtgqETTxbDJnksO.Dispose();
						}
					}
				}

				private sealed class OVFworWqoMfwkWfkzRGjNURnBJh : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public Joystick yIhDhYjpcEjmHdgpDLgQYGNhyTPS;

					public ControllerPollingInfo YwJdOZuDfAadjRmLcWODknNNOsZ;

					public ControllerPollingInfo DXiAnioeavKzWfKbQVmcTlvOToi;

					public IEnumerator<ControllerPollingInfo> RtEgCIHTlrPTtOQpFPpqqPkeWkS;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						OVFworWqoMfwkWfkzRGjNURnBJh oVFworWqoMfwkWfkzRGjNURnBJh;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							oVFworWqoMfwkWfkzRGjNURnBJh = this;
						}
						else
						{
							oVFworWqoMfwkWfkzRGjNURnBJh = new OVFworWqoMfwkWfkzRGjNURnBJh(0);
							oVFworWqoMfwkWfkzRGjNURnBJh.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						oVFworWqoMfwkWfkzRGjNURnBJh.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						return oVFworWqoMfwkWfkzRGjNURnBJh;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0)
								{
									break;
								}
								yIhDhYjpcEjmHdgpDLgQYGNhyTPS = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(OxaYhfaGlOIumOWmOozrcdXdBYi);
								if (yIhDhYjpcEjmHdgpDLgQYGNhyTPS == null)
								{
									break;
								}
								RtEgCIHTlrPTtOQpFPpqqPkeWkS = yIhDhYjpcEjmHdgpDLgQYGNhyTPS.PollForAllButtons().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (RtEgCIHTlrPTtOQpFPpqqPkeWkS.MoveNext())
								{
									YwJdOZuDfAadjRmLcWODknNNOsZ = RtEgCIHTlrPTtOQpFPpqqPkeWkS.Current;
									ref ControllerPollingInfo dXiAnioeavKzWfKbQVmcTlvOToi = ref DXiAnioeavKzWfKbQVmcTlvOToi;
									dXiAnioeavKzWfKbQVmcTlvOToi = new ControllerPollingInfo(YwJdOZuDfAadjRmLcWODknNNOsZ);
									DXiAnioeavKzWfKbQVmcTlvOToi.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = DXiAnioeavKzWfKbQVmcTlvOToi;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								DehfGbOakJQcvtcxWDzupTGSimE();
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
								DehfGbOakJQcvtcxWDzupTGSimE();
							}
						}
					}

					[DebuggerHidden]
					public OVFworWqoMfwkWfkzRGjNURnBJh(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void DehfGbOakJQcvtcxWDzupTGSimE()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (RtEgCIHTlrPTtOQpFPpqqPkeWkS != null)
						{
							RtEgCIHTlrPTtOQpFPpqqPkeWkS.Dispose();
						}
					}
				}

				private sealed class fsxdZEnfRWgMyVCNsmnOWIHCMAk : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public Joystick rlpoPxOerhejtHgiZQwgUnUfRhMl;

					public ControllerPollingInfo EeDeKuYigjfPZiiPjXqEoqQsRQA;

					public ControllerPollingInfo ljgNMcAapDcEngjevbqncbwvkrSb;

					public IEnumerator<ControllerPollingInfo> dmdinWgesIXKgYmerMAAnimPXLW;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						fsxdZEnfRWgMyVCNsmnOWIHCMAk fsxdZEnfRWgMyVCNsmnOWIHCMAk2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							fsxdZEnfRWgMyVCNsmnOWIHCMAk2 = this;
						}
						else
						{
							fsxdZEnfRWgMyVCNsmnOWIHCMAk2 = new fsxdZEnfRWgMyVCNsmnOWIHCMAk(0);
							fsxdZEnfRWgMyVCNsmnOWIHCMAk2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						fsxdZEnfRWgMyVCNsmnOWIHCMAk2.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						return fsxdZEnfRWgMyVCNsmnOWIHCMAk2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0)
								{
									break;
								}
								rlpoPxOerhejtHgiZQwgUnUfRhMl = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(OxaYhfaGlOIumOWmOozrcdXdBYi);
								if (rlpoPxOerhejtHgiZQwgUnUfRhMl == null)
								{
									break;
								}
								dmdinWgesIXKgYmerMAAnimPXLW = rlpoPxOerhejtHgiZQwgUnUfRhMl.PollForAllButtonsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (dmdinWgesIXKgYmerMAAnimPXLW.MoveNext())
								{
									EeDeKuYigjfPZiiPjXqEoqQsRQA = dmdinWgesIXKgYmerMAAnimPXLW.Current;
									ref ControllerPollingInfo reference = ref ljgNMcAapDcEngjevbqncbwvkrSb;
									reference = new ControllerPollingInfo(EeDeKuYigjfPZiiPjXqEoqQsRQA);
									ljgNMcAapDcEngjevbqncbwvkrSb.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = ljgNMcAapDcEngjevbqncbwvkrSb;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								sVJWxrcPwslTQEvEmhkqGwkBYHF();
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
								sVJWxrcPwslTQEvEmhkqGwkBYHF();
							}
						}
					}

					[DebuggerHidden]
					public fsxdZEnfRWgMyVCNsmnOWIHCMAk(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void sVJWxrcPwslTQEvEmhkqGwkBYHF()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (dmdinWgesIXKgYmerMAAnimPXLW != null)
						{
							dmdinWgesIXKgYmerMAAnimPXLW.Dispose();
						}
					}
				}

				private sealed class jgBARxdyeuxVjPmKEHffcsIbRpEy : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int OxaYhfaGlOIumOWmOozrcdXdBYi;

					public int MibhWTgqkTLbCkKSakqrazvCUSlR;

					public Joystick coXxZGHfrtMOjxkqiPJgAPectsK;

					public ControllerPollingInfo NxVnsxylavkUtOXhLORrDXAxFcJ;

					public ControllerPollingInfo HeZoVcZobKaLDJgrrnLDFpQkdDhE;

					public IEnumerator<ControllerPollingInfo> gaomPbUhNCAmxdcRwDoccTCFzQLo;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						jgBARxdyeuxVjPmKEHffcsIbRpEy jgBARxdyeuxVjPmKEHffcsIbRpEy2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jgBARxdyeuxVjPmKEHffcsIbRpEy2 = this;
						}
						else
						{
							jgBARxdyeuxVjPmKEHffcsIbRpEy2 = new jgBARxdyeuxVjPmKEHffcsIbRpEy(0);
							jgBARxdyeuxVjPmKEHffcsIbRpEy2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						jgBARxdyeuxVjPmKEHffcsIbRpEy2.OxaYhfaGlOIumOWmOozrcdXdBYi = MibhWTgqkTLbCkKSakqrazvCUSlR;
						return jgBARxdyeuxVjPmKEHffcsIbRpEy2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (OxaYhfaGlOIumOWmOozrcdXdBYi < 0)
								{
									break;
								}
								coXxZGHfrtMOjxkqiPJgAPectsK = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(OxaYhfaGlOIumOWmOozrcdXdBYi);
								if (coXxZGHfrtMOjxkqiPJgAPectsK == null)
								{
									break;
								}
								gaomPbUhNCAmxdcRwDoccTCFzQLo = coXxZGHfrtMOjxkqiPJgAPectsK.PollForAllAxes().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (gaomPbUhNCAmxdcRwDoccTCFzQLo.MoveNext())
								{
									NxVnsxylavkUtOXhLORrDXAxFcJ = gaomPbUhNCAmxdcRwDoccTCFzQLo.Current;
									ref ControllerPollingInfo heZoVcZobKaLDJgrrnLDFpQkdDhE = ref HeZoVcZobKaLDJgrrnLDFpQkdDhE;
									heZoVcZobKaLDJgrrnLDFpQkdDhE = new ControllerPollingInfo(NxVnsxylavkUtOXhLORrDXAxFcJ);
									HeZoVcZobKaLDJgrrnLDFpQkdDhE.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = HeZoVcZobKaLDJgrrnLDFpQkdDhE;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								mFaatBvcpAzHTSTAYlNnvRLEOqE();
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
								mFaatBvcpAzHTSTAYlNnvRLEOqE();
							}
						}
					}

					[DebuggerHidden]
					public jgBARxdyeuxVjPmKEHffcsIbRpEy(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void mFaatBvcpAzHTSTAYlNnvRLEOqE()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (gaomPbUhNCAmxdcRwDoccTCFzQLo != null)
						{
							gaomPbUhNCAmxdcRwDoccTCFzQLo.Dispose();
						}
					}
				}

				private sealed class oOoMMzcSmMqFCfmlJIJrVLDjwqo : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<Joystick> DnIBIayqLYIsPJFvKZklHcwOYOP;

					public int BWKeGXDTCagjhzQzIOuQbLPvHaNV;

					public int LtzPjLLpetOLlrsjmwBDRkmJBgV;

					public ControllerPollingInfo mxdhPbdRLfUWMADIrHLswpAyAEX;

					public ControllerPollingInfo zxrfgkICRYsuYDdvfRaYVmVNiVGn;

					public IEnumerator<ControllerPollingInfo> IWXbPVGpIFoUAcyLUsTvXVgYPzkG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						oOoMMzcSmMqFCfmlJIJrVLDjwqo oOoMMzcSmMqFCfmlJIJrVLDjwqo2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							oOoMMzcSmMqFCfmlJIJrVLDjwqo2 = this;
						}
						else
						{
							oOoMMzcSmMqFCfmlJIJrVLDjwqo2 = new oOoMMzcSmMqFCfmlJIJrVLDjwqo(0);
							oOoMMzcSmMqFCfmlJIJrVLDjwqo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return oOoMMzcSmMqFCfmlJIJrVLDjwqo2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								DnIBIayqLYIsPJFvKZklHcwOYOP = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
								BWKeGXDTCagjhzQzIOuQbLPvHaNV = DnIBIayqLYIsPJFvKZklHcwOYOP.Count;
								LtzPjLLpetOLlrsjmwBDRkmJBgV = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (LtzPjLLpetOLlrsjmwBDRkmJBgV >= BWKeGXDTCagjhzQzIOuQbLPvHaNV)
								{
									break;
								}
								IWXbPVGpIFoUAcyLUsTvXVgYPzkG = DnIBIayqLYIsPJFvKZklHcwOYOP[LtzPjLLpetOLlrsjmwBDRkmJBgV].PollForAllElements().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (IWXbPVGpIFoUAcyLUsTvXVgYPzkG.MoveNext())
								{
									mxdhPbdRLfUWMADIrHLswpAyAEX = IWXbPVGpIFoUAcyLUsTvXVgYPzkG.Current;
									ref ControllerPollingInfo reference = ref zxrfgkICRYsuYDdvfRaYVmVNiVGn;
									reference = new ControllerPollingInfo(mxdhPbdRLfUWMADIrHLswpAyAEX);
									zxrfgkICRYsuYDdvfRaYVmVNiVGn.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = zxrfgkICRYsuYDdvfRaYVmVNiVGn;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								KDFhdiCVXaLGOeqJhRiIRoANNZj();
								LtzPjLLpetOLlrsjmwBDRkmJBgV++;
								goto IL_0108;
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
								KDFhdiCVXaLGOeqJhRiIRoANNZj();
							}
						}
					}

					[DebuggerHidden]
					public oOoMMzcSmMqFCfmlJIJrVLDjwqo(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void KDFhdiCVXaLGOeqJhRiIRoANNZj()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (IWXbPVGpIFoUAcyLUsTvXVgYPzkG != null)
						{
							IWXbPVGpIFoUAcyLUsTvXVgYPzkG.Dispose();
						}
					}
				}

				private sealed class WNvpOivHDvchtQmArUpqaLLlkgX : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<Joystick> GTiocUYgmLZAEGZJVCAcKNXkAi;

					public int igffFqeOCfECcbNNbqQqJBaXLdbT;

					public int pLmzFaMercqCBoUakvKffNfjgaF;

					public ControllerPollingInfo NUagAWaoBEsMgoQbOqNlhmZAsRi;

					public ControllerPollingInfo ZCDDElTkAzjXTfrczSrxZkpQOGYR;

					public IEnumerator<ControllerPollingInfo> oaFaNqEfOzFxYCGOjFgaJpQVJmUZ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						WNvpOivHDvchtQmArUpqaLLlkgX wNvpOivHDvchtQmArUpqaLLlkgX;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wNvpOivHDvchtQmArUpqaLLlkgX = this;
						}
						else
						{
							wNvpOivHDvchtQmArUpqaLLlkgX = new WNvpOivHDvchtQmArUpqaLLlkgX(0);
							wNvpOivHDvchtQmArUpqaLLlkgX.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return wNvpOivHDvchtQmArUpqaLLlkgX;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								GTiocUYgmLZAEGZJVCAcKNXkAi = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
								igffFqeOCfECcbNNbqQqJBaXLdbT = GTiocUYgmLZAEGZJVCAcKNXkAi.Count;
								pLmzFaMercqCBoUakvKffNfjgaF = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (pLmzFaMercqCBoUakvKffNfjgaF >= igffFqeOCfECcbNNbqQqJBaXLdbT)
								{
									break;
								}
								oaFaNqEfOzFxYCGOjFgaJpQVJmUZ = GTiocUYgmLZAEGZJVCAcKNXkAi[pLmzFaMercqCBoUakvKffNfjgaF].PollForAllElementsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (oaFaNqEfOzFxYCGOjFgaJpQVJmUZ.MoveNext())
								{
									NUagAWaoBEsMgoQbOqNlhmZAsRi = oaFaNqEfOzFxYCGOjFgaJpQVJmUZ.Current;
									ref ControllerPollingInfo zCDDElTkAzjXTfrczSrxZkpQOGYR = ref ZCDDElTkAzjXTfrczSrxZkpQOGYR;
									zCDDElTkAzjXTfrczSrxZkpQOGYR = new ControllerPollingInfo(NUagAWaoBEsMgoQbOqNlhmZAsRi);
									ZCDDElTkAzjXTfrczSrxZkpQOGYR.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = ZCDDElTkAzjXTfrczSrxZkpQOGYR;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								eAtUHrwGNQunfGRAQGAnJdIteog();
								pLmzFaMercqCBoUakvKffNfjgaF++;
								goto IL_0108;
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
								eAtUHrwGNQunfGRAQGAnJdIteog();
							}
						}
					}

					[DebuggerHidden]
					public WNvpOivHDvchtQmArUpqaLLlkgX(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void eAtUHrwGNQunfGRAQGAnJdIteog()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (oaFaNqEfOzFxYCGOjFgaJpQVJmUZ != null)
						{
							oaFaNqEfOzFxYCGOjFgaJpQVJmUZ.Dispose();
						}
					}
				}

				private sealed class oVFtVfKNfUnNUmaFEbCSUBRSCjX : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<Joystick> SHfdXDgWAxregCSmvZWmPaVDXikb;

					public int qyuiFAnFjWkGhwzmvHRnrvOjLXm;

					public int mOFWaIHCIpgwSRSeGRzncyKICiY;

					public ControllerPollingInfo dqsZBhizLrmCtbnojFOhMcsxprk;

					public ControllerPollingInfo xCTurXDYupcHpHWMNnvxmTOWLof;

					public IEnumerator<ControllerPollingInfo> nEApfZldMwWnLzdSFySMpjmPcTP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						oVFtVfKNfUnNUmaFEbCSUBRSCjX oVFtVfKNfUnNUmaFEbCSUBRSCjX2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							oVFtVfKNfUnNUmaFEbCSUBRSCjX2 = this;
						}
						else
						{
							oVFtVfKNfUnNUmaFEbCSUBRSCjX2 = new oVFtVfKNfUnNUmaFEbCSUBRSCjX(0);
							oVFtVfKNfUnNUmaFEbCSUBRSCjX2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return oVFtVfKNfUnNUmaFEbCSUBRSCjX2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								SHfdXDgWAxregCSmvZWmPaVDXikb = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
								qyuiFAnFjWkGhwzmvHRnrvOjLXm = SHfdXDgWAxregCSmvZWmPaVDXikb.Count;
								mOFWaIHCIpgwSRSeGRzncyKICiY = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (mOFWaIHCIpgwSRSeGRzncyKICiY >= qyuiFAnFjWkGhwzmvHRnrvOjLXm)
								{
									break;
								}
								nEApfZldMwWnLzdSFySMpjmPcTP = SHfdXDgWAxregCSmvZWmPaVDXikb[mOFWaIHCIpgwSRSeGRzncyKICiY].PollForAllButtons().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (nEApfZldMwWnLzdSFySMpjmPcTP.MoveNext())
								{
									dqsZBhizLrmCtbnojFOhMcsxprk = nEApfZldMwWnLzdSFySMpjmPcTP.Current;
									ref ControllerPollingInfo reference = ref xCTurXDYupcHpHWMNnvxmTOWLof;
									reference = new ControllerPollingInfo(dqsZBhizLrmCtbnojFOhMcsxprk);
									xCTurXDYupcHpHWMNnvxmTOWLof.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = xCTurXDYupcHpHWMNnvxmTOWLof;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								ZRaXJPAIgUaQwiQjeFPGMipYIauc();
								mOFWaIHCIpgwSRSeGRzncyKICiY++;
								goto IL_0108;
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
								ZRaXJPAIgUaQwiQjeFPGMipYIauc();
							}
						}
					}

					[DebuggerHidden]
					public oVFtVfKNfUnNUmaFEbCSUBRSCjX(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void ZRaXJPAIgUaQwiQjeFPGMipYIauc()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (nEApfZldMwWnLzdSFySMpjmPcTP != null)
						{
							nEApfZldMwWnLzdSFySMpjmPcTP.Dispose();
						}
					}
				}

				private sealed class ArbdLMJciiZvoEEyIjzucRXbymrK : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<Joystick> ohgfWuGzbgHLOjuFpCHPAUdXkSDD;

					public int qwEWTJViKxJznoNgOvecanquvvH;

					public int RqVtraHhTcaRaeBvYyWikoxihmTq;

					public ControllerPollingInfo VUpfUEiAOrblwPPWdBzJpnhEOdh;

					public ControllerPollingInfo QhvmAsQOkFiFVaRXeVRZGLjVpgHi;

					public IEnumerator<ControllerPollingInfo> PBSHomTHOdcWuJsrOauXnYhlRhI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ArbdLMJciiZvoEEyIjzucRXbymrK arbdLMJciiZvoEEyIjzucRXbymrK;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							arbdLMJciiZvoEEyIjzucRXbymrK = this;
						}
						else
						{
							arbdLMJciiZvoEEyIjzucRXbymrK = new ArbdLMJciiZvoEEyIjzucRXbymrK(0);
							arbdLMJciiZvoEEyIjzucRXbymrK.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return arbdLMJciiZvoEEyIjzucRXbymrK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								ohgfWuGzbgHLOjuFpCHPAUdXkSDD = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
								qwEWTJViKxJznoNgOvecanquvvH = ohgfWuGzbgHLOjuFpCHPAUdXkSDD.Count;
								RqVtraHhTcaRaeBvYyWikoxihmTq = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (RqVtraHhTcaRaeBvYyWikoxihmTq >= qwEWTJViKxJznoNgOvecanquvvH)
								{
									break;
								}
								PBSHomTHOdcWuJsrOauXnYhlRhI = ohgfWuGzbgHLOjuFpCHPAUdXkSDD[RqVtraHhTcaRaeBvYyWikoxihmTq].PollForAllButtonsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (PBSHomTHOdcWuJsrOauXnYhlRhI.MoveNext())
								{
									VUpfUEiAOrblwPPWdBzJpnhEOdh = PBSHomTHOdcWuJsrOauXnYhlRhI.Current;
									ref ControllerPollingInfo qhvmAsQOkFiFVaRXeVRZGLjVpgHi = ref QhvmAsQOkFiFVaRXeVRZGLjVpgHi;
									qhvmAsQOkFiFVaRXeVRZGLjVpgHi = new ControllerPollingInfo(VUpfUEiAOrblwPPWdBzJpnhEOdh);
									QhvmAsQOkFiFVaRXeVRZGLjVpgHi.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = QhvmAsQOkFiFVaRXeVRZGLjVpgHi;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								vIiwukccLvFpIDgjkibFKYdqJiy();
								RqVtraHhTcaRaeBvYyWikoxihmTq++;
								goto IL_0108;
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
								vIiwukccLvFpIDgjkibFKYdqJiy();
							}
						}
					}

					[DebuggerHidden]
					public ArbdLMJciiZvoEEyIjzucRXbymrK(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void vIiwukccLvFpIDgjkibFKYdqJiy()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (PBSHomTHOdcWuJsrOauXnYhlRhI != null)
						{
							PBSHomTHOdcWuJsrOauXnYhlRhI.Dispose();
						}
					}
				}

				private sealed class XLcEIIWykmAcyrzZLTJmVjJlgHAg : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<Joystick> fHTdfEIhKuOoWoSCtmZGIkvIimf;

					public int OicMwgOQIzSDsqhqllanaMPWCNGA;

					public int HFgUdTszqpGzfrLFMVreTBqvQsb;

					public ControllerPollingInfo CgUukFxSXGCcmkBjBoCrHmrMYhXt;

					public ControllerPollingInfo rjQfXrhKtcxlHFFBmaJAmqANuZkK;

					public IEnumerator<ControllerPollingInfo> mPhDYazyRMECqccnNKCABMxIaLa;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						XLcEIIWykmAcyrzZLTJmVjJlgHAg xLcEIIWykmAcyrzZLTJmVjJlgHAg;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							xLcEIIWykmAcyrzZLTJmVjJlgHAg = this;
						}
						else
						{
							xLcEIIWykmAcyrzZLTJmVjJlgHAg = new XLcEIIWykmAcyrzZLTJmVjJlgHAg(0);
							xLcEIIWykmAcyrzZLTJmVjJlgHAg.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return xLcEIIWykmAcyrzZLTJmVjJlgHAg;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								fHTdfEIhKuOoWoSCtmZGIkvIimf = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
								OicMwgOQIzSDsqhqllanaMPWCNGA = fHTdfEIhKuOoWoSCtmZGIkvIimf.Count;
								HFgUdTszqpGzfrLFMVreTBqvQsb = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (HFgUdTszqpGzfrLFMVreTBqvQsb >= OicMwgOQIzSDsqhqllanaMPWCNGA)
								{
									break;
								}
								mPhDYazyRMECqccnNKCABMxIaLa = fHTdfEIhKuOoWoSCtmZGIkvIimf[HFgUdTszqpGzfrLFMVreTBqvQsb].PollForAllAxes().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (mPhDYazyRMECqccnNKCABMxIaLa.MoveNext())
								{
									CgUukFxSXGCcmkBjBoCrHmrMYhXt = mPhDYazyRMECqccnNKCABMxIaLa.Current;
									ref ControllerPollingInfo reference = ref rjQfXrhKtcxlHFFBmaJAmqANuZkK;
									reference = new ControllerPollingInfo(CgUukFxSXGCcmkBjBoCrHmrMYhXt);
									rjQfXrhKtcxlHFFBmaJAmqANuZkK.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = rjQfXrhKtcxlHFFBmaJAmqANuZkK;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								MwVVjUhDseZUJDQrVAkCdWNVZbS();
								HFgUdTszqpGzfrLFMVreTBqvQsb++;
								goto IL_0108;
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
								MwVVjUhDseZUJDQrVAkCdWNVZbS();
							}
						}
					}

					[DebuggerHidden]
					public XLcEIIWykmAcyrzZLTJmVjJlgHAg(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void MwVVjUhDseZUJDQrVAkCdWNVZbS()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (mPhDYazyRMECqccnNKCABMxIaLa != null)
						{
							mPhDYazyRMECqccnNKCABMxIaLa.Dispose();
						}
					}
				}

				private sealed class kEPbnoVWPlWWpSHwqgPOFsMPgYU : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomController KfkgsgCRNOLYGEQvgZmWbZMIpCi;

					public ControllerPollingInfo UFbcJzjkcLCGVxgcHLkwgvoTdOug;

					public ControllerPollingInfo hDZwGMoreTAiwnoXrVespnOctdR;

					public IEnumerator<ControllerPollingInfo> FPoIxKiRiXqiztbUMmapXAZabJD;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						kEPbnoVWPlWWpSHwqgPOFsMPgYU kEPbnoVWPlWWpSHwqgPOFsMPgYU2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							kEPbnoVWPlWWpSHwqgPOFsMPgYU2 = this;
						}
						else
						{
							kEPbnoVWPlWWpSHwqgPOFsMPgYU2 = new kEPbnoVWPlWWpSHwqgPOFsMPgYU(0);
							kEPbnoVWPlWWpSHwqgPOFsMPgYU2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						kEPbnoVWPlWWpSHwqgPOFsMPgYU2.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						return kEPbnoVWPlWWpSHwqgPOFsMPgYU2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0)
								{
									break;
								}
								KfkgsgCRNOLYGEQvgZmWbZMIpCi = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(JlYBenWQMdppMjVUfGFFPIshODO);
								if (KfkgsgCRNOLYGEQvgZmWbZMIpCi == null)
								{
									break;
								}
								FPoIxKiRiXqiztbUMmapXAZabJD = KfkgsgCRNOLYGEQvgZmWbZMIpCi.PollForAllElements().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (FPoIxKiRiXqiztbUMmapXAZabJD.MoveNext())
								{
									UFbcJzjkcLCGVxgcHLkwgvoTdOug = FPoIxKiRiXqiztbUMmapXAZabJD.Current;
									ref ControllerPollingInfo reference = ref hDZwGMoreTAiwnoXrVespnOctdR;
									reference = new ControllerPollingInfo(UFbcJzjkcLCGVxgcHLkwgvoTdOug);
									hDZwGMoreTAiwnoXrVespnOctdR.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = hDZwGMoreTAiwnoXrVespnOctdR;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								AkyFByEdSQtGKkDfkOzkFkPAozOi();
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
								AkyFByEdSQtGKkDfkOzkFkPAozOi();
							}
						}
					}

					[DebuggerHidden]
					public kEPbnoVWPlWWpSHwqgPOFsMPgYU(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void AkyFByEdSQtGKkDfkOzkFkPAozOi()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (FPoIxKiRiXqiztbUMmapXAZabJD != null)
						{
							FPoIxKiRiXqiztbUMmapXAZabJD.Dispose();
						}
					}
				}

				private sealed class JrzlbfRcxddTDkrsbmLOlxHqDSNK : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomController hxsDyIolHsorEjwfFqnkHkMchHO;

					public ControllerPollingInfo zXiOxLzNWNrxbTmHWcFBuScjxxe;

					public ControllerPollingInfo GdEADbRaLPRBpVmgweHGZaepaCF;

					public IEnumerator<ControllerPollingInfo> KmFOEuMbeFHQfshduGavMUirgQc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						JrzlbfRcxddTDkrsbmLOlxHqDSNK jrzlbfRcxddTDkrsbmLOlxHqDSNK;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jrzlbfRcxddTDkrsbmLOlxHqDSNK = this;
						}
						else
						{
							jrzlbfRcxddTDkrsbmLOlxHqDSNK = new JrzlbfRcxddTDkrsbmLOlxHqDSNK(0);
							jrzlbfRcxddTDkrsbmLOlxHqDSNK.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						jrzlbfRcxddTDkrsbmLOlxHqDSNK.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						return jrzlbfRcxddTDkrsbmLOlxHqDSNK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0)
								{
									break;
								}
								hxsDyIolHsorEjwfFqnkHkMchHO = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(JlYBenWQMdppMjVUfGFFPIshODO);
								if (hxsDyIolHsorEjwfFqnkHkMchHO == null)
								{
									break;
								}
								KmFOEuMbeFHQfshduGavMUirgQc = hxsDyIolHsorEjwfFqnkHkMchHO.PollForAllElementsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (KmFOEuMbeFHQfshduGavMUirgQc.MoveNext())
								{
									zXiOxLzNWNrxbTmHWcFBuScjxxe = KmFOEuMbeFHQfshduGavMUirgQc.Current;
									ref ControllerPollingInfo gdEADbRaLPRBpVmgweHGZaepaCF = ref GdEADbRaLPRBpVmgweHGZaepaCF;
									gdEADbRaLPRBpVmgweHGZaepaCF = new ControllerPollingInfo(zXiOxLzNWNrxbTmHWcFBuScjxxe);
									GdEADbRaLPRBpVmgweHGZaepaCF.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = GdEADbRaLPRBpVmgweHGZaepaCF;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								VbACdizPAAMIrMphhETCLdCtweK();
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
								VbACdizPAAMIrMphhETCLdCtweK();
							}
						}
					}

					[DebuggerHidden]
					public JrzlbfRcxddTDkrsbmLOlxHqDSNK(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void VbACdizPAAMIrMphhETCLdCtweK()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (KmFOEuMbeFHQfshduGavMUirgQc != null)
						{
							KmFOEuMbeFHQfshduGavMUirgQc.Dispose();
						}
					}
				}

				private sealed class AVVCJQkJKqZDNsQZuWelJGqCiCQ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomController hgpHZpduHOlDthlhdwJJUpZrMKbu;

					public ControllerPollingInfo ycyemSigaMItSLfjKUPlpAMgzGok;

					public ControllerPollingInfo SkVbPebMehsDNXlinAilLnOnziu;

					public IEnumerator<ControllerPollingInfo> JoLwelZzcKRcSsmITbEXtoeXzFE;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						AVVCJQkJKqZDNsQZuWelJGqCiCQ aVVCJQkJKqZDNsQZuWelJGqCiCQ;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							aVVCJQkJKqZDNsQZuWelJGqCiCQ = this;
						}
						else
						{
							aVVCJQkJKqZDNsQZuWelJGqCiCQ = new AVVCJQkJKqZDNsQZuWelJGqCiCQ(0);
							aVVCJQkJKqZDNsQZuWelJGqCiCQ.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						aVVCJQkJKqZDNsQZuWelJGqCiCQ.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						return aVVCJQkJKqZDNsQZuWelJGqCiCQ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0)
								{
									break;
								}
								hgpHZpduHOlDthlhdwJJUpZrMKbu = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(JlYBenWQMdppMjVUfGFFPIshODO);
								if (hgpHZpduHOlDthlhdwJJUpZrMKbu == null)
								{
									break;
								}
								JoLwelZzcKRcSsmITbEXtoeXzFE = hgpHZpduHOlDthlhdwJJUpZrMKbu.PollForAllButtons().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (JoLwelZzcKRcSsmITbEXtoeXzFE.MoveNext())
								{
									ycyemSigaMItSLfjKUPlpAMgzGok = JoLwelZzcKRcSsmITbEXtoeXzFE.Current;
									ref ControllerPollingInfo skVbPebMehsDNXlinAilLnOnziu = ref SkVbPebMehsDNXlinAilLnOnziu;
									skVbPebMehsDNXlinAilLnOnziu = new ControllerPollingInfo(ycyemSigaMItSLfjKUPlpAMgzGok);
									SkVbPebMehsDNXlinAilLnOnziu.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = SkVbPebMehsDNXlinAilLnOnziu;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								ziCxdImlcSIHEbTkRGtmSgMdzth();
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
								ziCxdImlcSIHEbTkRGtmSgMdzth();
							}
						}
					}

					[DebuggerHidden]
					public AVVCJQkJKqZDNsQZuWelJGqCiCQ(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void ziCxdImlcSIHEbTkRGtmSgMdzth()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (JoLwelZzcKRcSsmITbEXtoeXzFE != null)
						{
							JoLwelZzcKRcSsmITbEXtoeXzFE.Dispose();
						}
					}
				}

				private sealed class PJTAPtrKUtQuGHbybHhxKrFDpNB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomController dHoCIEgfbDeiRqyUsMXmnndlMip;

					public ControllerPollingInfo nxVAjJRhAWVSMQBEwGyJSVPJrTU;

					public ControllerPollingInfo sPyAWztBZMOJkPeTrqkyJBwPxEZ;

					public IEnumerator<ControllerPollingInfo> fDfDtCehuLkjrOlyDfymHqkajFYQ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						PJTAPtrKUtQuGHbybHhxKrFDpNB pJTAPtrKUtQuGHbybHhxKrFDpNB;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							pJTAPtrKUtQuGHbybHhxKrFDpNB = this;
						}
						else
						{
							pJTAPtrKUtQuGHbybHhxKrFDpNB = new PJTAPtrKUtQuGHbybHhxKrFDpNB(0);
							pJTAPtrKUtQuGHbybHhxKrFDpNB.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						pJTAPtrKUtQuGHbybHhxKrFDpNB.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						return pJTAPtrKUtQuGHbybHhxKrFDpNB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0)
								{
									break;
								}
								dHoCIEgfbDeiRqyUsMXmnndlMip = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(JlYBenWQMdppMjVUfGFFPIshODO);
								if (dHoCIEgfbDeiRqyUsMXmnndlMip == null)
								{
									break;
								}
								fDfDtCehuLkjrOlyDfymHqkajFYQ = dHoCIEgfbDeiRqyUsMXmnndlMip.PollForAllButtonsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (fDfDtCehuLkjrOlyDfymHqkajFYQ.MoveNext())
								{
									nxVAjJRhAWVSMQBEwGyJSVPJrTU = fDfDtCehuLkjrOlyDfymHqkajFYQ.Current;
									ref ControllerPollingInfo reference = ref sPyAWztBZMOJkPeTrqkyJBwPxEZ;
									reference = new ControllerPollingInfo(nxVAjJRhAWVSMQBEwGyJSVPJrTU);
									sPyAWztBZMOJkPeTrqkyJBwPxEZ.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = sPyAWztBZMOJkPeTrqkyJBwPxEZ;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								rdZrRWyZKPOIIzhkRYnYqoKJeCF();
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
								rdZrRWyZKPOIIzhkRYnYqoKJeCF();
							}
						}
					}

					[DebuggerHidden]
					public PJTAPtrKUtQuGHbybHhxKrFDpNB(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void rdZrRWyZKPOIIzhkRYnYqoKJeCF()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (fDfDtCehuLkjrOlyDfymHqkajFYQ != null)
						{
							fDfDtCehuLkjrOlyDfymHqkajFYQ.Dispose();
						}
					}
				}

				private sealed class GQQtYkHErvUWNIDAUDLlJShEvtS : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JlYBenWQMdppMjVUfGFFPIshODO;

					public int ZaqTyICvdSXepCTkroSltHXMiJK;

					public CustomController cGhLYkohWjtLtFqkeglIkcFbcKk;

					public ControllerPollingInfo OvIbVIBPVjuqjsgTkBsJxyonXblm;

					public ControllerPollingInfo xYyXeRPuhCveguCBQFYOhyKvRHn;

					public IEnumerator<ControllerPollingInfo> iBWDjIITgeBnAykMpMqzhkowCDMk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						GQQtYkHErvUWNIDAUDLlJShEvtS gQQtYkHErvUWNIDAUDLlJShEvtS;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							gQQtYkHErvUWNIDAUDLlJShEvtS = this;
						}
						else
						{
							gQQtYkHErvUWNIDAUDLlJShEvtS = new GQQtYkHErvUWNIDAUDLlJShEvtS(0);
							gQQtYkHErvUWNIDAUDLlJShEvtS.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						gQQtYkHErvUWNIDAUDLlJShEvtS.JlYBenWQMdppMjVUfGFFPIshODO = ZaqTyICvdSXepCTkroSltHXMiJK;
						return gQQtYkHErvUWNIDAUDLlJShEvtS;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (JlYBenWQMdppMjVUfGFFPIshODO < 0)
								{
									break;
								}
								cGhLYkohWjtLtFqkeglIkcFbcKk = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(JlYBenWQMdppMjVUfGFFPIshODO);
								if (cGhLYkohWjtLtFqkeglIkcFbcKk == null)
								{
									break;
								}
								iBWDjIITgeBnAykMpMqzhkowCDMk = cGhLYkohWjtLtFqkeglIkcFbcKk.PollForAllAxes().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00dc;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (iBWDjIITgeBnAykMpMqzhkowCDMk.MoveNext())
								{
									OvIbVIBPVjuqjsgTkBsJxyonXblm = iBWDjIITgeBnAykMpMqzhkowCDMk.Current;
									ref ControllerPollingInfo reference = ref xYyXeRPuhCveguCBQFYOhyKvRHn;
									reference = new ControllerPollingInfo(OvIbVIBPVjuqjsgTkBsJxyonXblm);
									xYyXeRPuhCveguCBQFYOhyKvRHn.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = xYyXeRPuhCveguCBQFYOhyKvRHn;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								gIkneLncIjDbiXujPDtZAxyMSrj();
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
								gIkneLncIjDbiXujPDtZAxyMSrj();
							}
						}
					}

					[DebuggerHidden]
					public GQQtYkHErvUWNIDAUDLlJShEvtS(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void gIkneLncIjDbiXujPDtZAxyMSrj()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (iBWDjIITgeBnAykMpMqzhkowCDMk != null)
						{
							iBWDjIITgeBnAykMpMqzhkowCDMk.Dispose();
						}
					}
				}

				private sealed class jJWjkCOsMxnFTqEWQfNgXWgCMvx : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<CustomController> JDnrOUPFDZSCACNNthjrpqXmVDJ;

					public int RujKDqUZEIZiMgTjjRXBuSepOdQ;

					public int mblDIMjYHKdEEDAIaBEPgStPTTW;

					public ControllerPollingInfo CbBExEcZvvBhCHXRVvvemLXZGxMe;

					public ControllerPollingInfo uQmThOrNikqIXeIaqxVONlbPcsO;

					public IEnumerator<ControllerPollingInfo> zRgpYkXItCULxbeDxgAzdjmZEly;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						jJWjkCOsMxnFTqEWQfNgXWgCMvx jJWjkCOsMxnFTqEWQfNgXWgCMvx2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jJWjkCOsMxnFTqEWQfNgXWgCMvx2 = this;
						}
						else
						{
							jJWjkCOsMxnFTqEWQfNgXWgCMvx2 = new jJWjkCOsMxnFTqEWQfNgXWgCMvx(0);
							jJWjkCOsMxnFTqEWQfNgXWgCMvx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return jJWjkCOsMxnFTqEWQfNgXWgCMvx2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								JDnrOUPFDZSCACNNthjrpqXmVDJ = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
								RujKDqUZEIZiMgTjjRXBuSepOdQ = JDnrOUPFDZSCACNNthjrpqXmVDJ.Count;
								mblDIMjYHKdEEDAIaBEPgStPTTW = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (mblDIMjYHKdEEDAIaBEPgStPTTW >= RujKDqUZEIZiMgTjjRXBuSepOdQ)
								{
									break;
								}
								zRgpYkXItCULxbeDxgAzdjmZEly = JDnrOUPFDZSCACNNthjrpqXmVDJ[mblDIMjYHKdEEDAIaBEPgStPTTW].PollForAllElements().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (zRgpYkXItCULxbeDxgAzdjmZEly.MoveNext())
								{
									CbBExEcZvvBhCHXRVvvemLXZGxMe = zRgpYkXItCULxbeDxgAzdjmZEly.Current;
									ref ControllerPollingInfo reference = ref uQmThOrNikqIXeIaqxVONlbPcsO;
									reference = new ControllerPollingInfo(CbBExEcZvvBhCHXRVvvemLXZGxMe);
									uQmThOrNikqIXeIaqxVONlbPcsO.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = uQmThOrNikqIXeIaqxVONlbPcsO;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								rPUenghKVjhVzERMqmlixYcAQsZp();
								mblDIMjYHKdEEDAIaBEPgStPTTW++;
								goto IL_0108;
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
								rPUenghKVjhVzERMqmlixYcAQsZp();
							}
						}
					}

					[DebuggerHidden]
					public jJWjkCOsMxnFTqEWQfNgXWgCMvx(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void rPUenghKVjhVzERMqmlixYcAQsZp()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (zRgpYkXItCULxbeDxgAzdjmZEly != null)
						{
							zRgpYkXItCULxbeDxgAzdjmZEly.Dispose();
						}
					}
				}

				private sealed class UtrbKuXOscAouVMxmoNYwpwcgVP : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<CustomController> dzyBTyJMbjpJktzvokOdGUgHkCq;

					public int DmAtKeXrtsolwkxOwgqOhOKgLoe;

					public int nafaZLbqHtmkUiEVaNJKUlprIwy;

					public ControllerPollingInfo MvXPBzFujRVevbewuEkCGUjJJguG;

					public ControllerPollingInfo kwMWXqMnAfXUrjdUFVQkfdXLivp;

					public IEnumerator<ControllerPollingInfo> PhQAErvQFzbGrBPBiWpEHQsoBHXw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						UtrbKuXOscAouVMxmoNYwpwcgVP utrbKuXOscAouVMxmoNYwpwcgVP;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							utrbKuXOscAouVMxmoNYwpwcgVP = this;
						}
						else
						{
							utrbKuXOscAouVMxmoNYwpwcgVP = new UtrbKuXOscAouVMxmoNYwpwcgVP(0);
							utrbKuXOscAouVMxmoNYwpwcgVP.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return utrbKuXOscAouVMxmoNYwpwcgVP;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								dzyBTyJMbjpJktzvokOdGUgHkCq = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
								DmAtKeXrtsolwkxOwgqOhOKgLoe = dzyBTyJMbjpJktzvokOdGUgHkCq.Count;
								nafaZLbqHtmkUiEVaNJKUlprIwy = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (nafaZLbqHtmkUiEVaNJKUlprIwy >= DmAtKeXrtsolwkxOwgqOhOKgLoe)
								{
									break;
								}
								PhQAErvQFzbGrBPBiWpEHQsoBHXw = dzyBTyJMbjpJktzvokOdGUgHkCq[nafaZLbqHtmkUiEVaNJKUlprIwy].PollForAllElementsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (PhQAErvQFzbGrBPBiWpEHQsoBHXw.MoveNext())
								{
									MvXPBzFujRVevbewuEkCGUjJJguG = PhQAErvQFzbGrBPBiWpEHQsoBHXw.Current;
									ref ControllerPollingInfo reference = ref kwMWXqMnAfXUrjdUFVQkfdXLivp;
									reference = new ControllerPollingInfo(MvXPBzFujRVevbewuEkCGUjJJguG);
									kwMWXqMnAfXUrjdUFVQkfdXLivp.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = kwMWXqMnAfXUrjdUFVQkfdXLivp;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								OIrGeuhldtRkSvqJvMOTVDjTiHaA();
								nafaZLbqHtmkUiEVaNJKUlprIwy++;
								goto IL_0108;
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
								OIrGeuhldtRkSvqJvMOTVDjTiHaA();
							}
						}
					}

					[DebuggerHidden]
					public UtrbKuXOscAouVMxmoNYwpwcgVP(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void OIrGeuhldtRkSvqJvMOTVDjTiHaA()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (PhQAErvQFzbGrBPBiWpEHQsoBHXw != null)
						{
							PhQAErvQFzbGrBPBiWpEHQsoBHXw.Dispose();
						}
					}
				}

				private sealed class jyoGJFoFiEKZwGKFbAJUgXThIFB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<CustomController> bkmvPGpQXZmuZZNthMyhGpFUTnk;

					public int TnOhebffnrAHbblLulnqcdICuSNq;

					public int aqilWbLQpMwtasxdvlRatbpAZaN;

					public ControllerPollingInfo EffnPzGPdkJCmhnaQcqsdSKoUkrC;

					public ControllerPollingInfo muSEqCpwkwptVHwssWPbnmbflRv;

					public IEnumerator<ControllerPollingInfo> xrVfbRtCzboFREXSWiFmmoKaYbp;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						jyoGJFoFiEKZwGKFbAJUgXThIFB jyoGJFoFiEKZwGKFbAJUgXThIFB2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jyoGJFoFiEKZwGKFbAJUgXThIFB2 = this;
						}
						else
						{
							jyoGJFoFiEKZwGKFbAJUgXThIFB2 = new jyoGJFoFiEKZwGKFbAJUgXThIFB(0);
							jyoGJFoFiEKZwGKFbAJUgXThIFB2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return jyoGJFoFiEKZwGKFbAJUgXThIFB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								bkmvPGpQXZmuZZNthMyhGpFUTnk = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
								TnOhebffnrAHbblLulnqcdICuSNq = bkmvPGpQXZmuZZNthMyhGpFUTnk.Count;
								aqilWbLQpMwtasxdvlRatbpAZaN = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (aqilWbLQpMwtasxdvlRatbpAZaN >= TnOhebffnrAHbblLulnqcdICuSNq)
								{
									break;
								}
								xrVfbRtCzboFREXSWiFmmoKaYbp = bkmvPGpQXZmuZZNthMyhGpFUTnk[aqilWbLQpMwtasxdvlRatbpAZaN].PollForAllButtons().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (xrVfbRtCzboFREXSWiFmmoKaYbp.MoveNext())
								{
									EffnPzGPdkJCmhnaQcqsdSKoUkrC = xrVfbRtCzboFREXSWiFmmoKaYbp.Current;
									ref ControllerPollingInfo reference = ref muSEqCpwkwptVHwssWPbnmbflRv;
									reference = new ControllerPollingInfo(EffnPzGPdkJCmhnaQcqsdSKoUkrC);
									muSEqCpwkwptVHwssWPbnmbflRv.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = muSEqCpwkwptVHwssWPbnmbflRv;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								PrSvEombMVAdaNaBTOFqfSSZVUQ();
								aqilWbLQpMwtasxdvlRatbpAZaN++;
								goto IL_0108;
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
								PrSvEombMVAdaNaBTOFqfSSZVUQ();
							}
						}
					}

					[DebuggerHidden]
					public jyoGJFoFiEKZwGKFbAJUgXThIFB(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void PrSvEombMVAdaNaBTOFqfSSZVUQ()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (xrVfbRtCzboFREXSWiFmmoKaYbp != null)
						{
							xrVfbRtCzboFREXSWiFmmoKaYbp.Dispose();
						}
					}
				}

				private sealed class DsVZDbHKSRkWYNeLIuZiaAWJfAB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<CustomController> dtWiwUEetCzsEUUlabqsZYYzBKC;

					public int OXaMpGRPZQTrUhMcrkwFfWvgczJ;

					public int WDBhbIEIerXchciKqiXFrdvwFDaI;

					public ControllerPollingInfo fmosOeLJrIvtwZAWPKlFWZZXWnr;

					public ControllerPollingInfo hxGEhTDGyuyktMqPQJOANtISBmYk;

					public IEnumerator<ControllerPollingInfo> IsnFwfgapdwHnpCKKGyLLVBHQCk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						DsVZDbHKSRkWYNeLIuZiaAWJfAB dsVZDbHKSRkWYNeLIuZiaAWJfAB;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							dsVZDbHKSRkWYNeLIuZiaAWJfAB = this;
						}
						else
						{
							dsVZDbHKSRkWYNeLIuZiaAWJfAB = new DsVZDbHKSRkWYNeLIuZiaAWJfAB(0);
							dsVZDbHKSRkWYNeLIuZiaAWJfAB.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return dsVZDbHKSRkWYNeLIuZiaAWJfAB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								dtWiwUEetCzsEUUlabqsZYYzBKC = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
								OXaMpGRPZQTrUhMcrkwFfWvgczJ = dtWiwUEetCzsEUUlabqsZYYzBKC.Count;
								WDBhbIEIerXchciKqiXFrdvwFDaI = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (WDBhbIEIerXchciKqiXFrdvwFDaI >= OXaMpGRPZQTrUhMcrkwFfWvgczJ)
								{
									break;
								}
								IsnFwfgapdwHnpCKKGyLLVBHQCk = dtWiwUEetCzsEUUlabqsZYYzBKC[WDBhbIEIerXchciKqiXFrdvwFDaI].PollForAllButtonsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (IsnFwfgapdwHnpCKKGyLLVBHQCk.MoveNext())
								{
									fmosOeLJrIvtwZAWPKlFWZZXWnr = IsnFwfgapdwHnpCKKGyLLVBHQCk.Current;
									ref ControllerPollingInfo reference = ref hxGEhTDGyuyktMqPQJOANtISBmYk;
									reference = new ControllerPollingInfo(fmosOeLJrIvtwZAWPKlFWZZXWnr);
									hxGEhTDGyuyktMqPQJOANtISBmYk.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = hxGEhTDGyuyktMqPQJOANtISBmYk;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								GsrGPEzYqQxcQGoRcknVsyJAYvG();
								WDBhbIEIerXchciKqiXFrdvwFDaI++;
								goto IL_0108;
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
								GsrGPEzYqQxcQGoRcknVsyJAYvG();
							}
						}
					}

					[DebuggerHidden]
					public DsVZDbHKSRkWYNeLIuZiaAWJfAB(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void GsrGPEzYqQxcQGoRcknVsyJAYvG()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (IsnFwfgapdwHnpCKKGyLLVBHQCk != null)
						{
							IsnFwfgapdwHnpCKKGyLLVBHQCk.Dispose();
						}
					}
				}

				private sealed class hBqFXhkDssFjphsCfdlgjeIVrMIg : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IList<CustomController> kQHMNoKFnzanvaCexRhKiTtmSZPb;

					public int gholgZZugYUNDBSFgPLHXAUfqpJ;

					public int HVSjerqsRHkSLhcLRXSHVFQEBd;

					public ControllerPollingInfo RrvFZXxjJCzWvGKXsYEUJalKqsB;

					public ControllerPollingInfo MpoesrYUtMdfHZfAuIpPcPlrfbW;

					public IEnumerator<ControllerPollingInfo> IFbyDrVEQOPFbEsXhaqhFNnKZSu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						hBqFXhkDssFjphsCfdlgjeIVrMIg hBqFXhkDssFjphsCfdlgjeIVrMIg2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							hBqFXhkDssFjphsCfdlgjeIVrMIg2 = this;
						}
						else
						{
							hBqFXhkDssFjphsCfdlgjeIVrMIg2 = new hBqFXhkDssFjphsCfdlgjeIVrMIg(0);
							hBqFXhkDssFjphsCfdlgjeIVrMIg2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return hBqFXhkDssFjphsCfdlgjeIVrMIg2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								kQHMNoKFnzanvaCexRhKiTtmSZPb = kdBZqupjvsCsVkwJiOeEQzkEDVO.IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
								gholgZZugYUNDBSFgPLHXAUfqpJ = kQHMNoKFnzanvaCexRhKiTtmSZPb.Count;
								HVSjerqsRHkSLhcLRXSHVFQEBd = 0;
								goto IL_0108;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (HVSjerqsRHkSLhcLRXSHVFQEBd >= gholgZZugYUNDBSFgPLHXAUfqpJ)
								{
									break;
								}
								IFbyDrVEQOPFbEsXhaqhFNnKZSu = kQHMNoKFnzanvaCexRhKiTtmSZPb[HVSjerqsRHkSLhcLRXSHVFQEBd].PollForAllAxes().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e7;
								IL_00e7:
								if (IFbyDrVEQOPFbEsXhaqhFNnKZSu.MoveNext())
								{
									RrvFZXxjJCzWvGKXsYEUJalKqsB = IFbyDrVEQOPFbEsXhaqhFNnKZSu.Current;
									ref ControllerPollingInfo mpoesrYUtMdfHZfAuIpPcPlrfbW = ref MpoesrYUtMdfHZfAuIpPcPlrfbW;
									mpoesrYUtMdfHZfAuIpPcPlrfbW = new ControllerPollingInfo(RrvFZXxjJCzWvGKXsYEUJalKqsB);
									MpoesrYUtMdfHZfAuIpPcPlrfbW.playerId = kdBZqupjvsCsVkwJiOeEQzkEDVO.gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
									ajbaQItphrIyqhowgmMTfPkCBvcN = MpoesrYUtMdfHZfAuIpPcPlrfbW;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								MCLTNkVUQknTOYFjGpPkfpLQwQt();
								HVSjerqsRHkSLhcLRXSHVFQEBd++;
								goto IL_0108;
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
								MCLTNkVUQknTOYFjGpPkfpLQwQt();
							}
						}
					}

					[DebuggerHidden]
					public hBqFXhkDssFjphsCfdlgjeIVrMIg(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void MCLTNkVUQknTOYFjGpPkfpLQwQt()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (IFbyDrVEQOPFbEsXhaqhFNnKZSu != null)
						{
							IFbyDrVEQOPFbEsXhaqhFNnKZSu.Dispose();
						}
					}
				}

				private readonly Player gESwCZhPTVpAneBRVEYFzquNJMi;

				private readonly ControllerHelper IqqFMkivXajbnQieKffNsZWOHNR;

				private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

				internal PollingHelper(Player player, ControllerHelper parent)
				{
					fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
					gESwCZhPTVpAneBRVEYFzquNJMi = player;
					IqqFMkivXajbnQieKffNsZWOHNR = parent;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Joystick => rdGJuXrStgmfnXelKaOGpkeSefd(controllerId), 
						ControllerType.Mouse => rzJxhXDKpxDwjoPbvIrbdUHyheIr(), 
						ControllerType.Custom => gdAMPQcKADevcSlJIpFrfRcAOxn(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Joystick => zJsbaVfrRcowEzSDpFBFXTSoaKQ(controllerId), 
						ControllerType.Mouse => sKspVQCHtNAkEvazVAXaYGEpjBX(), 
						ControllerType.Custom => SEasjFmflggVTqguJyNFZsWzjFy(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Joystick => HYnLQWjvyZpncHURwYJjWToCfBm(controllerId), 
						ControllerType.Mouse => sAiaokcjMDKCsDZrgfHAhasUBXuc(), 
						ControllerType.Custom => VTJGpZPOWKtFoEVfkAvNzjHjpmH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Joystick => VXjjnGlVPbloKnfZutAomsOiqIJ(controllerId), 
						ControllerType.Mouse => OhqAXJPlKKAaaHiuafjWgUhAeodS(), 
						ControllerType.Custom => MoyLlkWoUuHAmbzHJPOHzuhtKTU(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX(), 
						ControllerType.Joystick => kcQIvKJJJNWmqwFMYMuyjkEgztX(controllerId), 
						ControllerType.Mouse => iVKCdfiRQANSqAoRGuGIsQoZKVv(), 
						ControllerType.Custom => aCiNVjazMwXrCJpoGiWuJGEOOZ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gAvgWIgfVZbXuFTWgjqyGdKUFRxA(), 
						ControllerType.Joystick => DQubbTveCDSUArAPdrjNXGYKVir(controllerId), 
						ControllerType.Mouse => ZooFcvkMsjmnEomcITTqPWxhapy(), 
						ControllerType.Custom => mAshBjCizaZoFfPzZdwdmJFLlpR(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UNbIRrbSwWaPpwzAWAJYgahWYve(), 
						ControllerType.Joystick => PmxAmTkoCsJxaDvxtwLoNsMQwNJa(controllerId), 
						ControllerType.Mouse => TTyoYZMohguwGZCZTlCpANfgGGB(), 
						ControllerType.Custom => BLWiRKbYmdfmIDLTQxKFvfwdBor(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gAvgWIgfVZbXuFTWgjqyGdKUFRxA(), 
						ControllerType.Joystick => vsDUowPZRvglIPHAgigUqgGgeOlh(controllerId), 
						ControllerType.Mouse => awSCqvjylhyTWfJPsmnKHANpeyZD(), 
						ControllerType.Custom => OshdBbPKEQXOtKOYqDntkchcTUoS(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UNbIRrbSwWaPpwzAWAJYgahWYve(), 
						ControllerType.Joystick => OYhgnGnVdGhRNWsvXZxobGZvbTd(controllerId), 
						ControllerType.Mouse => ARYkLJaQlDfnKwXxPMqbvhDkYgI(), 
						ControllerType.Custom => CFxnsvpCMNCuGjAIfRPObHhpmlV(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => GuwCOXEfElIdOJVYGrJCVNuanDa(controllerId), 
						ControllerType.Mouse => IrWUrxbhfOHHjzFPTPeMdNBGBMD(), 
						ControllerType.Custom => HUYoTxNRGNXcaHnNWgQlkrdPUoD(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Joystick => tPYgRPKhhVDjOUFQfmJfoLoevLE(), 
						ControllerType.Mouse => rzJxhXDKpxDwjoPbvIrbdUHyheIr(), 
						ControllerType.Custom => owDyqRuplqTKIMBsnJFxAYEZSzJ(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Joystick => RLxeqnbLpUYMAlzBvcyzYjZIMJFb(), 
						ControllerType.Mouse => sAiaokcjMDKCsDZrgfHAhasUBXuc(), 
						ControllerType.Custom => zfdHKhvTLsjKYIZWDHDCCTLKQaqk(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Joystick => HcyFWWBYldHSKRLdKkYhADlrYHi(), 
						ControllerType.Mouse => OhqAXJPlKKAaaHiuafjWgUhAeodS(), 
						ControllerType.Custom => ZVnabXpIUtnFumMppmSBCUuKQUW(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX(), 
						ControllerType.Joystick => SNXBYfaMocebwbdMYGdJctseTCW(), 
						ControllerType.Mouse => iVKCdfiRQANSqAoRGuGIsQoZKVv(), 
						ControllerType.Custom => sZnktTgKuipUdJWCRpeaIwUzQCH(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gAvgWIgfVZbXuFTWgjqyGdKUFRxA(), 
						ControllerType.Joystick => QbzynOjrnOnvocjncQfCACgbsUS(), 
						ControllerType.Mouse => ZooFcvkMsjmnEomcITTqPWxhapy(), 
						ControllerType.Custom => lKBAYRZBwSfgdnPyfoiNuNMHctMd(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UNbIRrbSwWaPpwzAWAJYgahWYve(), 
						ControllerType.Joystick => jSWKFzaBtDaxCdTuAXqkFlVBfiYx(), 
						ControllerType.Mouse => TTyoYZMohguwGZCZTlCpANfgGGB(), 
						ControllerType.Custom => PmkgcCkBjeZVCjctKfZQZIfmZmn(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => gAvgWIgfVZbXuFTWgjqyGdKUFRxA(), 
						ControllerType.Joystick => XjWvmrssIbttOhBAesLVKzhmDJZ(), 
						ControllerType.Mouse => awSCqvjylhyTWfJPsmnKHANpeyZD(), 
						ControllerType.Custom => AtSfiFgQODQAQAgVrkhiPyooONFu(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => UNbIRrbSwWaPpwzAWAJYgahWYve(), 
						ControllerType.Joystick => wAYzQZdOFdjBcGukUXuZNSQwOBYf(), 
						ControllerType.Mouse => ARYkLJaQlDfnKwXxPMqbvhDkYgI(), 
						ControllerType.Custom => mMONWadVQHiCiUwCrqqwFLeElTW(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => MdyEqSXmldqLboElPopNnzFbCGU(), 
						ControllerType.Mouse => IrWUrxbhfOHHjzFPTPeMdNBGBMD(), 
						ControllerType.Custom => cmLblIPEaIRbsSHdWaHCwBfiAEB(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo rdGJuXrStgmfnXelKaOGpkeSefd(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					Joystick joystick = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo zJsbaVfrRcowEzSDpFBFXTSoaKQ(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					Joystick joystick = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo HYnLQWjvyZpncHURwYJjWToCfBm(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					Joystick joystick = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo VXjjnGlVPbloKnfZutAomsOiqIJ(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					Joystick joystick = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo kcQIvKJJJNWmqwFMYMuyjkEgztX(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					Joystick joystick = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> DQubbTveCDSUArAPdrjNXGYKVir(int P_0)
				{
					uKjmyvnrJCcsPqfrcsjZnGFocSMc uKjmyvnrJCcsPqfrcsjZnGFocSMc2 = new uKjmyvnrJCcsPqfrcsjZnGFocSMc(-2);
					uKjmyvnrJCcsPqfrcsjZnGFocSMc2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					uKjmyvnrJCcsPqfrcsjZnGFocSMc2.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					return uKjmyvnrJCcsPqfrcsjZnGFocSMc2;
				}

				private IEnumerable<ControllerPollingInfo> PmxAmTkoCsJxaDvxtwLoNsMQwNJa(int P_0)
				{
					ooujUiGXYnoqbnFFXqwtksvfnca ooujUiGXYnoqbnFFXqwtksvfnca2 = new ooujUiGXYnoqbnFFXqwtksvfnca(-2);
					ooujUiGXYnoqbnFFXqwtksvfnca2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					ooujUiGXYnoqbnFFXqwtksvfnca2.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					return ooujUiGXYnoqbnFFXqwtksvfnca2;
				}

				private IEnumerable<ControllerPollingInfo> vsDUowPZRvglIPHAgigUqgGgeOlh(int P_0)
				{
					OVFworWqoMfwkWfkzRGjNURnBJh oVFworWqoMfwkWfkzRGjNURnBJh = new OVFworWqoMfwkWfkzRGjNURnBJh(-2);
					oVFworWqoMfwkWfkzRGjNURnBJh.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					oVFworWqoMfwkWfkzRGjNURnBJh.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					return oVFworWqoMfwkWfkzRGjNURnBJh;
				}

				private IEnumerable<ControllerPollingInfo> OYhgnGnVdGhRNWsvXZxobGZvbTd(int P_0)
				{
					fsxdZEnfRWgMyVCNsmnOWIHCMAk fsxdZEnfRWgMyVCNsmnOWIHCMAk2 = new fsxdZEnfRWgMyVCNsmnOWIHCMAk(-2);
					fsxdZEnfRWgMyVCNsmnOWIHCMAk2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					fsxdZEnfRWgMyVCNsmnOWIHCMAk2.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					return fsxdZEnfRWgMyVCNsmnOWIHCMAk2;
				}

				private IEnumerable<ControllerPollingInfo> GuwCOXEfElIdOJVYGrJCVNuanDa(int P_0)
				{
					jgBARxdyeuxVjPmKEHffcsIbRpEy jgBARxdyeuxVjPmKEHffcsIbRpEy2 = new jgBARxdyeuxVjPmKEHffcsIbRpEy(-2);
					jgBARxdyeuxVjPmKEHffcsIbRpEy2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					jgBARxdyeuxVjPmKEHffcsIbRpEy2.MibhWTgqkTLbCkKSakqrazvCUSlR = P_0;
					return jgBARxdyeuxVjPmKEHffcsIbRpEy2;
				}

				private ControllerPollingInfo tPYgRPKhhVDjOUFQfmJfoLoevLE()
				{
					IList<Joystick> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo nnInniYgLzlBNFCKzWAqEGaQjlH()
				{
					IList<Joystick> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo RLxeqnbLpUYMAlzBvcyzYjZIMJFb()
				{
					IList<Joystick> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo HcyFWWBYldHSKRLdKkYhADlrYHi()
				{
					IList<Joystick> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo SNXBYfaMocebwbdMYGdJctseTCW()
				{
					IList<Joystick> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						Joystick joystick = controllers_readOnly[i];
						ControllerPollingInfo result = joystick.PollForFirstAxis();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private IEnumerable<ControllerPollingInfo> QbzynOjrnOnvocjncQfCACgbsUS()
				{
					oOoMMzcSmMqFCfmlJIJrVLDjwqo oOoMMzcSmMqFCfmlJIJrVLDjwqo2 = new oOoMMzcSmMqFCfmlJIJrVLDjwqo(-2);
					oOoMMzcSmMqFCfmlJIJrVLDjwqo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return oOoMMzcSmMqFCfmlJIJrVLDjwqo2;
				}

				private IEnumerable<ControllerPollingInfo> jSWKFzaBtDaxCdTuAXqkFlVBfiYx()
				{
					WNvpOivHDvchtQmArUpqaLLlkgX wNvpOivHDvchtQmArUpqaLLlkgX = new WNvpOivHDvchtQmArUpqaLLlkgX(-2);
					wNvpOivHDvchtQmArUpqaLLlkgX.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return wNvpOivHDvchtQmArUpqaLLlkgX;
				}

				private IEnumerable<ControllerPollingInfo> XjWvmrssIbttOhBAesLVKzhmDJZ()
				{
					oVFtVfKNfUnNUmaFEbCSUBRSCjX oVFtVfKNfUnNUmaFEbCSUBRSCjX2 = new oVFtVfKNfUnNUmaFEbCSUBRSCjX(-2);
					oVFtVfKNfUnNUmaFEbCSUBRSCjX2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return oVFtVfKNfUnNUmaFEbCSUBRSCjX2;
				}

				private IEnumerable<ControllerPollingInfo> wAYzQZdOFdjBcGukUXuZNSQwOBYf()
				{
					ArbdLMJciiZvoEEyIjzucRXbymrK arbdLMJciiZvoEEyIjzucRXbymrK = new ArbdLMJciiZvoEEyIjzucRXbymrK(-2);
					arbdLMJciiZvoEEyIjzucRXbymrK.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return arbdLMJciiZvoEEyIjzucRXbymrK;
				}

				private IEnumerable<ControllerPollingInfo> MdyEqSXmldqLboElPopNnzFbCGU()
				{
					XLcEIIWykmAcyrzZLTJmVjJlgHAg xLcEIIWykmAcyrzZLTJmVjJlgHAg = new XLcEIIWykmAcyrzZLTJmVjJlgHAg(-2);
					xLcEIIWykmAcyrzZLTJmVjJlgHAg.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return xLcEIIWykmAcyrzZLTJmVjJlgHAg;
				}

				private ControllerPollingInfo HrcQQPJaqsradbKddMtWghIATrW()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.wvdeqoiczJHcRgbEahbuugxImYJk)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo sEIQPdfYxpzZVUCygKmdLOXrsSa()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.wvdeqoiczJHcRgbEahbuugxImYJk)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> gAvgWIgfVZbXuFTWgjqyGdKUFRxA()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.wvdeqoiczJHcRgbEahbuugxImYJk)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> UNbIRrbSwWaPpwzAWAJYgahWYve()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.wvdeqoiczJHcRgbEahbuugxImYJk)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo rzJxhXDKpxDwjoPbvIrbdUHyheIr()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo sKspVQCHtNAkEvazVAXaYGEpjBX()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo sAiaokcjMDKCsDZrgfHAhasUBXuc()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo OhqAXJPlKKAaaHiuafjWgUhAeodS()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo iVKCdfiRQANSqAoRGuGIsQoZKVv()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> ZooFcvkMsjmnEomcITTqPWxhapy()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> TTyoYZMohguwGZCZTlCpANfgGGB()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> awSCqvjylhyTWfJPsmnKHANpeyZD()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> ARYkLJaQlDfnKwXxPMqbvhDkYgI()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> IrWUrxbhfOHHjzFPTPeMdNBGBMD()
				{
					if (!IqqFMkivXajbnQieKffNsZWOHNR.LNloAmyCTcEELWuVZsOMuoDvDgB)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return IqqFMkivXajbnQieKffNsZWOHNR.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo gdAMPQcKADevcSlJIpFrfRcAOxn(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					CustomController customController = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo SEasjFmflggVTqguJyNFZsWzjFy(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					CustomController customController = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo VTJGpZPOWKtFoEVfkAvNzjHjpmH(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					CustomController customController = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo MoyLlkWoUuHAmbzHJPOHzuhtKTU(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					CustomController customController = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private ControllerPollingInfo aCiNVjazMwXrCJpoGiWuJGEOOZ(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					CustomController customController = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.ZbGtisIkVmOkbLNUAlpAicawGu(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> mAshBjCizaZoFfPzZdwdmJFLlpR(int P_0)
				{
					kEPbnoVWPlWWpSHwqgPOFsMPgYU kEPbnoVWPlWWpSHwqgPOFsMPgYU2 = new kEPbnoVWPlWWpSHwqgPOFsMPgYU(-2);
					kEPbnoVWPlWWpSHwqgPOFsMPgYU2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					kEPbnoVWPlWWpSHwqgPOFsMPgYU2.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					return kEPbnoVWPlWWpSHwqgPOFsMPgYU2;
				}

				private IEnumerable<ControllerPollingInfo> BLWiRKbYmdfmIDLTQxKFvfwdBor(int P_0)
				{
					JrzlbfRcxddTDkrsbmLOlxHqDSNK jrzlbfRcxddTDkrsbmLOlxHqDSNK = new JrzlbfRcxddTDkrsbmLOlxHqDSNK(-2);
					jrzlbfRcxddTDkrsbmLOlxHqDSNK.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					jrzlbfRcxddTDkrsbmLOlxHqDSNK.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					return jrzlbfRcxddTDkrsbmLOlxHqDSNK;
				}

				private IEnumerable<ControllerPollingInfo> OshdBbPKEQXOtKOYqDntkchcTUoS(int P_0)
				{
					AVVCJQkJKqZDNsQZuWelJGqCiCQ aVVCJQkJKqZDNsQZuWelJGqCiCQ = new AVVCJQkJKqZDNsQZuWelJGqCiCQ(-2);
					aVVCJQkJKqZDNsQZuWelJGqCiCQ.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					aVVCJQkJKqZDNsQZuWelJGqCiCQ.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					return aVVCJQkJKqZDNsQZuWelJGqCiCQ;
				}

				private IEnumerable<ControllerPollingInfo> CFxnsvpCMNCuGjAIfRPObHhpmlV(int P_0)
				{
					PJTAPtrKUtQuGHbybHhxKrFDpNB pJTAPtrKUtQuGHbybHhxKrFDpNB = new PJTAPtrKUtQuGHbybHhxKrFDpNB(-2);
					pJTAPtrKUtQuGHbybHhxKrFDpNB.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					pJTAPtrKUtQuGHbybHhxKrFDpNB.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					return pJTAPtrKUtQuGHbybHhxKrFDpNB;
				}

				private IEnumerable<ControllerPollingInfo> HUYoTxNRGNXcaHnNWgQlkrdPUoD(int P_0)
				{
					GQQtYkHErvUWNIDAUDLlJShEvtS gQQtYkHErvUWNIDAUDLlJShEvtS = new GQQtYkHErvUWNIDAUDLlJShEvtS(-2);
					gQQtYkHErvUWNIDAUDLlJShEvtS.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					gQQtYkHErvUWNIDAUDLlJShEvtS.ZaqTyICvdSXepCTkroSltHXMiJK = P_0;
					return gQQtYkHErvUWNIDAUDLlJShEvtS;
				}

				private ControllerPollingInfo owDyqRuplqTKIMBsnJFxAYEZSzJ()
				{
					IList<CustomController> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo BTgXzhgTgasnOzbifGtFfbSHRLc()
				{
					IList<CustomController> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo zfdHKhvTLsjKYIZWDHDCCTLKQaqk()
				{
					IList<CustomController> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo ZVnabXpIUtnFumMppmSBCUuKQUW()
				{
					IList<CustomController> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo sZnktTgKuipUdJWCRpeaIwUzQCH()
				{
					IList<CustomController> controllers_readOnly = IqqFMkivXajbnQieKffNsZWOHNR.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						CustomController customController = controllers_readOnly[i];
						ControllerPollingInfo result = customController.PollForFirstAxis();
						if (result.success)
						{
							result.playerId = gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx;
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private IEnumerable<ControllerPollingInfo> lKBAYRZBwSfgdnPyfoiNuNMHctMd()
				{
					jJWjkCOsMxnFTqEWQfNgXWgCMvx jJWjkCOsMxnFTqEWQfNgXWgCMvx2 = new jJWjkCOsMxnFTqEWQfNgXWgCMvx(-2);
					jJWjkCOsMxnFTqEWQfNgXWgCMvx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return jJWjkCOsMxnFTqEWQfNgXWgCMvx2;
				}

				private IEnumerable<ControllerPollingInfo> PmkgcCkBjeZVCjctKfZQZIfmZmn()
				{
					UtrbKuXOscAouVMxmoNYwpwcgVP utrbKuXOscAouVMxmoNYwpwcgVP = new UtrbKuXOscAouVMxmoNYwpwcgVP(-2);
					utrbKuXOscAouVMxmoNYwpwcgVP.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return utrbKuXOscAouVMxmoNYwpwcgVP;
				}

				private IEnumerable<ControllerPollingInfo> AtSfiFgQODQAQAgVrkhiPyooONFu()
				{
					jyoGJFoFiEKZwGKFbAJUgXThIFB jyoGJFoFiEKZwGKFbAJUgXThIFB2 = new jyoGJFoFiEKZwGKFbAJUgXThIFB(-2);
					jyoGJFoFiEKZwGKFbAJUgXThIFB2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return jyoGJFoFiEKZwGKFbAJUgXThIFB2;
				}

				private IEnumerable<ControllerPollingInfo> mMONWadVQHiCiUwCrqqwFLeElTW()
				{
					DsVZDbHKSRkWYNeLIuZiaAWJfAB dsVZDbHKSRkWYNeLIuZiaAWJfAB = new DsVZDbHKSRkWYNeLIuZiaAWJfAB(-2);
					dsVZDbHKSRkWYNeLIuZiaAWJfAB.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return dsVZDbHKSRkWYNeLIuZiaAWJfAB;
				}

				private IEnumerable<ControllerPollingInfo> cmLblIPEaIRbsSHdWaHCwBfiAEB()
				{
					hBqFXhkDssFjphsCfdlgjeIVrMIg hBqFXhkDssFjphsCfdlgjeIVrMIg2 = new hBqFXhkDssFjphsCfdlgjeIVrMIg(-2);
					hBqFXhkDssFjphsCfdlgjeIVrMIg2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return hBqFXhkDssFjphsCfdlgjeIVrMIg2;
				}
			}

			private sealed class gWfrVRhCUoBsidUJImTBooibORXe : IDisposable, IEnumerator, IEnumerable, IEnumerable<Controller>, IEnumerator<Controller>
			{
				private Controller ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public ControllerHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int EFVutrqMFcCRAyRFQaPlIxatVXw;

				public IList<Joystick> McJbmmdHJVbBWoeMnllpIdImjdhF;

				public int LFyUBFIdOkxqtPKMfdLMfgrniXXK;

				public int EwYAiDTDVvELCMKxJDSTbsFebFNH;

				public IList<CustomController> HYWlSNbVXoYaBHeNxjSAUZpMspk;

				public int hgLCWdnvClyjiZWylbIFgPiWxMK;

				Controller IEnumerator<Controller>.Current
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
				IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator()
				{
					gWfrVRhCUoBsidUJImTBooibORXe gWfrVRhCUoBsidUJImTBooibORXe2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						gWfrVRhCUoBsidUJImTBooibORXe2 = this;
					}
					else
					{
						gWfrVRhCUoBsidUJImTBooibORXe2 = new gWfrVRhCUoBsidUJImTBooibORXe(0);
						gWfrVRhCUoBsidUJImTBooibORXe2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return gWfrVRhCUoBsidUJImTBooibORXe2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
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
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.LNloAmyCTcEELWuVZsOMuoDvDgB)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.Mouse;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							return true;
						}
						goto IL_0083;
					case 1:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0083;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00b1;
					case 3:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						LFyUBFIdOkxqtPKMfdLMfgrniXXK++;
						goto IL_0111;
					case 4:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							hgLCWdnvClyjiZWylbIFgPiWxMK++;
							goto IL_017f;
						}
						IL_017f:
						if (hgLCWdnvClyjiZWylbIFgPiWxMK < EwYAiDTDVvELCMKxJDSTbsFebFNH)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = HYWlSNbVXoYaBHeNxjSAUZpMspk[hgLCWdnvClyjiZWylbIFgPiWxMK];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
							return true;
						}
						break;
						IL_00b1:
						EFVutrqMFcCRAyRFQaPlIxatVXw = kdBZqupjvsCsVkwJiOeEQzkEDVO.joystickCount;
						McJbmmdHJVbBWoeMnllpIdImjdhF = kdBZqupjvsCsVkwJiOeEQzkEDVO.Joysticks;
						LFyUBFIdOkxqtPKMfdLMfgrniXXK = 0;
						goto IL_0111;
						IL_0111:
						if (LFyUBFIdOkxqtPKMfdLMfgrniXXK < EFVutrqMFcCRAyRFQaPlIxatVXw)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = McJbmmdHJVbBWoeMnllpIdImjdhF[LFyUBFIdOkxqtPKMfdLMfgrniXXK];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						EwYAiDTDVvELCMKxJDSTbsFebFNH = kdBZqupjvsCsVkwJiOeEQzkEDVO.customControllerCount;
						HYWlSNbVXoYaBHeNxjSAUZpMspk = kdBZqupjvsCsVkwJiOeEQzkEDVO.CustomControllers;
						hgLCWdnvClyjiZWylbIFgPiWxMK = 0;
						goto IL_017f;
						IL_0083:
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.wvdeqoiczJHcRgbEahbuugxImYJk)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.Keyboard;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						goto IL_00b1;
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
				public gWfrVRhCUoBsidUJImTBooibORXe(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private readonly yIJYYECjyPGJVHuwiNkBdeHkvDn qaaiDhRyNtSbazhnTtGAJLqHvov;

			private bool LNloAmyCTcEELWuVZsOMuoDvDgB;

			private bool wvdeqoiczJHcRgbEahbuugxImYJk;

			private bool VqowzzvLyiotMwuKOZYLtqofhH;

			private double znyXvuSeLJwVaWmnwfsFLnjZeeV;

			private double byCzLCRNRsSPWJlubvghrbaeFdr;

			private SafeAction<ControllerAssignmentChangedEventArgs> pWvyrfsUztOKndvvFjHtjkmFqoF = new SafeAction<ControllerAssignmentChangedEventArgs>(delegate(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
			});

			private SafeAction<ControllerAssignmentChangedEventArgs> snNCpwBVHVskMsrTqffwYqzgENgh = new SafeAction<ControllerAssignmentChangedEventArgs>(delegate(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
			});

			private readonly zxiPetcpStGdKraGRhVxmYBYdoV VXRpRQGmBLUsrQikVDSFCugvidLN;

			private readonly Player gESwCZhPTVpAneBRVEYFzquNJMi;

			private readonly UpJYtIyHkhXTxTerpbIGIMQMINV DKDPSzxAYGPHIdvhCTFjPnGPODE;

			private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			[CompilerGenerated]
			private static Action<Exception> YvplfWbjwiFspspndrHcVXCSMoL;

			[CompilerGenerated]
			private static Action<Exception> QdcLsRDhWBgEwdpblNLsOasvBFY;

			private kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap> joystickSet => (kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick);

			private global::CimpQwMUTGMiTwuOvALwFOVgRyp<KeyboardMap> keyboardMapSet => (global::CimpQwMUTGMiTwuOvALwFOVgRyp<KeyboardMap>)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Keyboard).sGGfJsmegvsCOukIXQVwszxmlRT(0).mapSet;

			private global::CimpQwMUTGMiTwuOvALwFOVgRyp<MouseMap> mouseMapSet => (global::CimpQwMUTGMiTwuOvALwFOVgRyp<MouseMap>)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Mouse).sGGfJsmegvsCOukIXQVwszxmlRT(0).mapSet;

			private kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap> customControllerSet => (kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return LNloAmyCTcEELWuVZsOMuoDvDgB;
				}
				set
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						if (LNloAmyCTcEELWuVZsOMuoDvDgB == value)
						{
							return;
						}
						LNloAmyCTcEELWuVZsOMuoDvDgB = value;
						if (value)
						{
							DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(Mouse);
						}
						else
						{
							DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (pWvyrfsUztOKndvvFjHtjkmFqoF.Count > 0)
							{
								pWvyrfsUztOKndvvFjHtjkmFqoF.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (snNCpwBVHVskMsrTqffwYqzgENgh.Count > 0)
						{
							snNCpwBVHVskMsrTqffwYqzgENgh.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return wvdeqoiczJHcRgbEahbuugxImYJk;
				}
				set
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						if (wvdeqoiczJHcRgbEahbuugxImYJk == value)
						{
							return;
						}
						wvdeqoiczJHcRgbEahbuugxImYJk = value;
						if (value)
						{
							DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(Keyboard);
						}
						else
						{
							DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (pWvyrfsUztOKndvvFjHtjkmFqoF.Count > 0)
							{
								pWvyrfsUztOKndvvFjHtjkmFqoF.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (snNCpwBVHVskMsrTqffwYqzgENgh.Count > 0)
						{
							snNCpwBVHVskMsrTqffwYqzgENgh.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return VqowzzvLyiotMwuKOZYLtqofhH;
				}
				set
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						VqowzzvLyiotMwuKOZYLtqofhH = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick).Count;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick) as kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>).Controllers_readOnly;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom).Count;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom) as kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>).Controllers_readOnly;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				get
				{
					gWfrVRhCUoBsidUJImTBooibORXe gWfrVRhCUoBsidUJImTBooibORXe2 = new gWfrVRhCUoBsidUJImTBooibORXe(-2);
					gWfrVRhCUoBsidUJImTBooibORXe2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return gWfrVRhCUoBsidUJImTBooibORXe2;
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					pWvyrfsUztOKndvvFjHtjkmFqoF.AddDelegate(value);
				}
				remove
				{
					pWvyrfsUztOKndvvFjHtjkmFqoF.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					snNCpwBVHVskMsrTqffwYqzgENgh.AddDelegate(value);
				}
				remove
				{
					snNCpwBVHVskMsrTqffwYqzgENgh.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player player, HRJeTaRmGlgEoVaWhsuEDjticiT startingControllerMapInfo, ControllerMapLayoutManager.PseBURjmDgdQyBrNSFfUTuoWirpM controllerMapLayoutManagerSettings, ControllerMapEnabler.FIAqEJWjdCiOptKWtsxrOjilkTn controllerMapEnablerSettings)
			{
				fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
				gESwCZhPTVpAneBRVEYFzquNJMi = player;
				maps = new MapHelper(player, this, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
				polling = new PollingHelper(player, this);
				conflictChecking = new ConflictCheckingHelper(player, this);
				qaaiDhRyNtSbazhnTtGAJLqHvov = new yIJYYECjyPGJVHuwiNkBdeHkvDn(4);
				qaaiDhRyNtSbazhnTtGAJLqHvov.oZApGyNkPpBNhUUhbjNZjYkbbvC(0, ControllerType.Joystick, new kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>());
				qaaiDhRyNtSbazhnTtGAJLqHvov.oZApGyNkPpBNhUUhbjNZjYkbbvC(1, ControllerType.Keyboard, new kbnxqpuiTgLkmUJPdswbZRMtQYO<Keyboard, KeyboardMap>());
				qaaiDhRyNtSbazhnTtGAJLqHvov.oZApGyNkPpBNhUUhbjNZjYkbbvC(2, ControllerType.Mouse, new kbnxqpuiTgLkmUJPdswbZRMtQYO<Mouse, MouseMap>());
				qaaiDhRyNtSbazhnTtGAJLqHvov.oZApGyNkPpBNhUUhbjNZjYkbbvC(3, ControllerType.Custom, new kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>());
				VXRpRQGmBLUsrQikVDSFCugvidLN = new zxiPetcpStGdKraGRhVxmYBYdoV(player);
				DKDPSzxAYGPHIdvhCTFjPnGPODE = new UpJYtIyHkhXTxTerpbIGIMQMINV(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return (T)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(bEUEMZWgpCwBXKGSoWTyQESUVD.cBNLAYcmxbcLkZElXOxElVAbwGi<T>()).ZbGtisIkVmOkbLNUAlpAicawGu(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType).ZbGtisIkVmOkbLNUAlpAicawGu(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return (T)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(bEUEMZWgpCwBXKGSoWTyQESUVD.cBNLAYcmxbcLkZElXOxElVAbwGi<T>()).XLkibbsjMgAaKcvONPWosmQzExj(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(controllerType).XLkibbsjMgAaKcvONPWosmQzExj(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					ByLRMWSEaQYOtQxguVzbYinZLhi(controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					AddController(ControllerType.Keyboard, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					AddController(ControllerType.Mouse, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					ZeNcCgUkWoGJZAZOLSbHwfsXHTq(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						ByLRMWSEaQYOtQxguVzbYinZLhi(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						ZeNcCgUkWoGJZAZOLSbHwfsXHTq(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					ByLRMWSEaQYOtQxguVzbYinZLhi(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
					break;
				case ControllerType.Keyboard:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasKeyboard = true;
					break;
				case ControllerType.Mouse:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasMouse = true;
					break;
				case ControllerType.Custom:
					ZeNcCgUkWoGJZAZOLSbHwfsXHTq(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					nwaJKAsevjXsebhXFWcqRNNGQia(controllerId);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					RemoveController(ControllerType.Keyboard, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					RemoveController(ControllerType.Mouse, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					TPBQzKwhRwfWtmCNVYcejNFNlGQ(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					nwaJKAsevjXsebhXFWcqRNNGQia(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					TPBQzKwhRwfWtmCNVYcejNFNlGQ(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						nwaJKAsevjXsebhXFWcqRNNGQia(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						TPBQzKwhRwfWtmCNVYcejNFNlGQ(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return wvdeqoiczJHcRgbEahbuugxImYJk;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return LNloAmyCTcEELWuVZsOMuoDvDgB;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick).YRagHVGgqrxCGUgBYtkIqvCxSddL(controllerId), 
					ControllerType.Keyboard => wvdeqoiczJHcRgbEahbuugxImYJk, 
					ControllerType.Mouse => LNloAmyCTcEELWuVZsOMuoDvDgB, 
					ControllerType.Custom => qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom).YRagHVGgqrxCGUgBYtkIqvCxSddL(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				if (controller == null)
				{
					return false;
				}
				return ContainsController(controller.type, controller.id);
			}

			public void ClearControllersOfType<T>() where T : Controller
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					TNyFvClKzSCfdNUxKXetHcZHwMb();
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					hasKeyboard = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					hasMouse = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					elfjKusoOGwhddvaFQolzMSNohl();
					return;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(Controller)))
				{
					ClearAllControllers();
					return;
				}
				throw new NotImplementedException();
			}

			public void ClearControllersOfType(ControllerType controllerType)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					TNyFvClKzSCfdNUxKXetHcZHwMb();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					elfjKusoOGwhddvaFQolzMSNohl();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				TNyFvClKzSCfdNUxKXetHcZHwMb();
				elfjKusoOGwhddvaFQolzMSNohl();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				GGTEJobWqMfZnOZQzdDKBfORPdD(ControllerType.Joystick, ref result, ref num);
				if (LNloAmyCTcEELWuVZsOMuoDvDgB && znyXvuSeLJwVaWmnwfsFLnjZeeV > num)
				{
					result = Mouse;
					num = znyXvuSeLJwVaWmnwfsFLnjZeeV;
				}
				if (wvdeqoiczJHcRgbEahbuugxImYJk && byCzLCRNRsSPWJlubvghrbaeFdr > num)
				{
					result = Keyboard;
					num = byCzLCRNRsSPWJlubvghrbaeFdr;
				}
				GGTEJobWqMfZnOZQzdDKBfORPdD(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					GGTEJobWqMfZnOZQzdDKBfORPdD(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (wvdeqoiczJHcRgbEahbuugxImYJk && byCzLCRNRsSPWJlubvghrbaeFdr > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (LNloAmyCTcEELWuVZsOMuoDvDgB && znyXvuSeLJwVaWmnwfsFLnjZeeV > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void GGTEJobWqMfZnOZQzdDKBfORPdD(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
				int count = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count;
				for (int i = 0; i < count; i++)
				{
					double lastActiveTime = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].lastActiveTime;
					if (!(lastActiveTime <= P_2))
					{
						P_1 = ozEDFrZmqchSdqXvkECRiiBJFWVg2[i].controller;
						P_2 = lastActiveTime;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(bEUEMZWgpCwBXKGSoWTyQESUVD.cBNLAYcmxbcLkZElXOxElVAbwGi<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.MvGborIExmOgobVmPUOPCDhRdZd(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.MvGborIExmOgobVmPUOPCDhRdZd(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.CjdNlmspnwRwPMzNTWWEMLksHWK(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.CjdNlmspnwRwPMzNTWWEMLksHWK(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.rBtCdQwOhFJaLVTaHeAeaGEBcRb(gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				int spePdqugXpdSjGsMuRlyMjmlhHiD = qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
				for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
				{
					Controller controller = rbkbKapwUYkOJgKHigYxzLtebEi(qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i).controllerType, Controller.implementsTemplateDelegate_Guid, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				int spePdqugXpdSjGsMuRlyMjmlhHiD = qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD;
				for (int i = 0; i < spePdqugXpdSjGsMuRlyMjmlhHiD; i++)
				{
					Controller controller = rbkbKapwUYkOJgKHigYxzLtebEi(qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i).controllerType, Controller.implementsTemplateDelegate_Type, templateType);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate<T>() where T : class
			{
				return GetFirstControllerWithTemplate(typeof(T));
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return DKDPSzxAYGPHIdvhCTFjPnGPODE.PoxNLyEKfLBqvaizvkvHcJnPXMDH<TInterface>();
			}

			private Controller rbkbKapwUYkOJgKHigYxzLtebEi<TDelegateParam>(ControllerType P_0, Func<Controller, TDelegateParam, bool> P_1, TDelegateParam P_2)
			{
				switch (P_0)
				{
				case ControllerType.Joystick:
				{
					int num2 = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					for (int j = 0; j < num2; j++)
					{
						if (P_1(joysticks[j], P_2))
						{
							return joysticks[j];
						}
					}
					return null;
				}
				case ControllerType.Keyboard:
					if (wvdeqoiczJHcRgbEahbuugxImYJk && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (LNloAmyCTcEELWuVZsOMuoDvDgB && P_1(Mouse, P_2))
					{
						return Mouse;
					}
					return null;
				case ControllerType.Custom:
				{
					int num = customControllerCount;
					IList<CustomController> customControllers = CustomControllers;
					for (int i = 0; i < num; i++)
					{
						if (P_1(customControllers[i], P_2))
						{
							return customControllers[i];
						}
					}
					return null;
				}
				default:
					throw new NotImplementedException();
				}
			}

			internal void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
			{
				for (int i = 0; i < qaaiDhRyNtSbazhnTtGAJLqHvov.SpePdqugXpdSjGsMuRlyMjmlhHiD; i++)
				{
					qaaiDhRyNtSbazhnTtGAJLqHvov.JgFRckJPlsxwwoDknLaNPBypefe(i).dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
				qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Keyboard).yyCUTFygyaeOphRDatdfpVepzGHn(new kbnxqpuiTgLkmUJPdswbZRMtQYO<Keyboard, KeyboardMap>.XMaIGYxSmxoTKaVsVqAuxacFodi(ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.Keyboard, new global::CimpQwMUTGMiTwuOvALwFOVgRyp<KeyboardMap>(0)));
				qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Mouse).yyCUTFygyaeOphRDatdfpVepzGHn(new kbnxqpuiTgLkmUJPdswbZRMtQYO<Mouse, MouseMap>.XMaIGYxSmxoTKaVsVqAuxacFodi(ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.Mouse, new global::CimpQwMUTGMiTwuOvALwFOVgRyp<MouseMap>(0)));
				VXRpRQGmBLUsrQikVDSFCugvidLN.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				byCzLCRNRsSPWJlubvghrbaeFdr = 0.0;
				znyXvuSeLJwVaWmnwfsFLnjZeeV = 0.0;
				maps.EJpmrTgGvrhKjJnkpXbomYBpQTQ();
			}

			internal double VfSAtErJNgBtSKzOlHUHCtLZEbLQ(int P_0)
			{
				return VXRpRQGmBLUsrQikVDSFCugvidLN.SrKtvymlKprndkinEFXJTDBelLJ(P_0)?.pyPmPvjEEueDSBngCIxCGSXcOaC ?? (-1.0);
			}

			internal void ByLRMWSEaQYOtQxguVzbYinZLhi(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick);
				if (ozEDFrZmqchSdqXvkECRiiBJFWVg2.YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				zxiPetcpStGdKraGRhVxmYBYdoV.hngEDaAqCbNinGghamFnidMGbbzL hngEDaAqCbNinGghamFnidMGbbzL = VXRpRQGmBLUsrQikVDSFCugvidLN.SrKtvymlKprndkinEFXJTDBelLJ(P_0.id);
				kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi xMaIGYxSmxoTKaVsVqAuxacFodi;
				if (hngEDaAqCbNinGghamFnidMGbbzL != null && hngEDaAqCbNinGghamFnidMGbbzL.nytTYXdOuEqgOKSTmLpKeODwQdx != null)
				{
					xMaIGYxSmxoTKaVsVqAuxacFodi = new kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi(P_0, hngEDaAqCbNinGghamFnidMGbbzL.nytTYXdOuEqgOKSTmLpKeODwQdx);
				}
				else
				{
					global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap> cimpQwMUTGMiTwuOvALwFOVgRyp = maps.GNSjNyVFlGWFObrcnUPBvfIAuXb(P_0, true);
					if (cimpQwMUTGMiTwuOvALwFOVgRyp == null)
					{
						cimpQwMUTGMiTwuOvALwFOVgRyp = new global::CimpQwMUTGMiTwuOvALwFOVgRyp<JoystickMap>(P_0.id);
					}
					xMaIGYxSmxoTKaVsVqAuxacFodi = new kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi(P_0, cimpQwMUTGMiTwuOvALwFOVgRyp);
				}
				ozEDFrZmqchSdqXvkECRiiBJFWVg2.yyCUTFygyaeOphRDatdfpVepzGHn(xMaIGYxSmxoTKaVsVqAuxacFodi);
				VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(xMaIGYxSmxoTKaVsVqAuxacFodi);
				DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(P_0);
				maps.layoutManager.Apply();
				if (pWvyrfsUztOKndvvFjHtjkmFqoF.Count > 0)
				{
					pWvyrfsUztOKndvvFjHtjkmFqoF.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, P_0.id, ControllerType.Joystick, state: true));
				}
			}

			internal void ByLRMWSEaQYOtQxguVzbYinZLhi(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					ByLRMWSEaQYOtQxguVzbYinZLhi(joystick, P_1);
				}
			}

			internal void nwaJKAsevjXsebhXFWcqRNNGQia(int P_0)
			{
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick);
				if (ozEDFrZmqchSdqXvkECRiiBJFWVg2.YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0))
				{
					if (ozEDFrZmqchSdqXvkECRiiBJFWVg2.sGGfJsmegvsCOukIXQVwszxmlRT(P_0) is kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi xMaIGYxSmxoTKaVsVqAuxacFodi)
					{
						VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(xMaIGYxSmxoTKaVsVqAuxacFodi);
					}
					ozEDFrZmqchSdqXvkECRiiBJFWVg2.LRTqpOKaSyeswQyhlVNZgZllkau(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(joystick);
					if (snNCpwBVHVskMsrTqffwYqzgENgh.Count > 0)
					{
						snNCpwBVHVskMsrTqffwYqzgENgh.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, joystick.id, ControllerType.Joystick, state: false));
					}
				}
			}

			internal void nwaJKAsevjXsebhXFWcqRNNGQia(Joystick P_0)
			{
				if (P_0 != null)
				{
					nwaJKAsevjXsebhXFWcqRNNGQia(P_0.id);
				}
			}

			internal void TNyFvClKzSCfdNUxKXetHcZHwMb()
			{
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Joystick);
				for (int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count - 1; num >= 0; num--)
				{
					VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(ozEDFrZmqchSdqXvkECRiiBJFWVg2[num] as kbnxqpuiTgLkmUJPdswbZRMtQYO<Joystick, JoystickMap>.XMaIGYxSmxoTKaVsVqAuxacFodi);
					DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller);
					int id = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller.id;
					ozEDFrZmqchSdqXvkECRiiBJFWVg2.sSizjXaGummAfwQzjOxRTrpsaaY(num);
					if (snNCpwBVHVskMsrTqffwYqzgENgh.Count > 0)
					{
						snNCpwBVHVskMsrTqffwYqzgENgh.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, id, ControllerType.Joystick, state: false));
					}
				}
				ozEDFrZmqchSdqXvkECRiiBJFWVg2.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}

			internal void ZeNcCgUkWoGJZAZOLSbHwfsXHTq(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom);
				if (!ozEDFrZmqchSdqXvkECRiiBJFWVg2.YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::CimpQwMUTGMiTwuOvALwFOVgRyp<CustomControllerMap> cimpQwMUTGMiTwuOvALwFOVgRyp = maps.LCVXrfdznweRpTvqVKrqYdjcbTX(P_0, true);
					if (cimpQwMUTGMiTwuOvALwFOVgRyp == null)
					{
						cimpQwMUTGMiTwuOvALwFOVgRyp = new global::CimpQwMUTGMiTwuOvALwFOVgRyp<CustomControllerMap>(P_0.id);
					}
					kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>.XMaIGYxSmxoTKaVsVqAuxacFodi xMaIGYxSmxoTKaVsVqAuxacFodi = new kbnxqpuiTgLkmUJPdswbZRMtQYO<CustomController, CustomControllerMap>.XMaIGYxSmxoTKaVsVqAuxacFodi(P_0, cimpQwMUTGMiTwuOvALwFOVgRyp);
					ozEDFrZmqchSdqXvkECRiiBJFWVg2.yyCUTFygyaeOphRDatdfpVepzGHn(xMaIGYxSmxoTKaVsVqAuxacFodi);
					DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(P_0);
					maps.layoutManager.Apply();
					if (pWvyrfsUztOKndvvFjHtjkmFqoF.Count > 0)
					{
						pWvyrfsUztOKndvvFjHtjkmFqoF.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, P_0.id, ControllerType.Custom, state: true));
					}
				}
			}

			internal void ZeNcCgUkWoGJZAZOLSbHwfsXHTq(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					ZeNcCgUkWoGJZAZOLSbHwfsXHTq(customController, P_1);
				}
			}

			internal void TPBQzKwhRwfWtmCNVYcejNFNlGQ(int P_0)
			{
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom);
				if (ozEDFrZmqchSdqXvkECRiiBJFWVg2.YRagHVGgqrxCGUgBYtkIqvCxSddL(P_0))
				{
					ozEDFrZmqchSdqXvkECRiiBJFWVg2.sGGfJsmegvsCOukIXQVwszxmlRT(P_0);
					ozEDFrZmqchSdqXvkECRiiBJFWVg2.LRTqpOKaSyeswQyhlVNZgZllkau(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(customController);
					if (snNCpwBVHVskMsrTqffwYqzgENgh.Count > 0)
					{
						snNCpwBVHVskMsrTqffwYqzgENgh.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, customController.id, ControllerType.Custom, state: false));
					}
				}
			}

			internal void TPBQzKwhRwfWtmCNVYcejNFNlGQ(CustomController P_0)
			{
				if (P_0 != null)
				{
					TPBQzKwhRwfWtmCNVYcejNFNlGQ(P_0.id);
				}
			}

			internal void elfjKusoOGwhddvaFQolzMSNohl()
			{
				ozEDFrZmqchSdqXvkECRiiBJFWVg ozEDFrZmqchSdqXvkECRiiBJFWVg2 = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Custom);
				for (int num = ozEDFrZmqchSdqXvkECRiiBJFWVg2.Count - 1; num >= 0; num--)
				{
					DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller);
					int id = ozEDFrZmqchSdqXvkECRiiBJFWVg2[num].controller.id;
					ozEDFrZmqchSdqXvkECRiiBJFWVg2.sSizjXaGummAfwQzjOxRTrpsaaY(num);
					if (snNCpwBVHVskMsrTqffwYqzgENgh.Count > 0)
					{
						snNCpwBVHVskMsrTqffwYqzgENgh.Invoke(new ControllerAssignmentChangedEventArgs(gESwCZhPTVpAneBRVEYFzquNJMi.id, id, ControllerType.Custom, state: false));
					}
				}
				ozEDFrZmqchSdqXvkECRiiBJFWVg2.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}

			internal CustomController EEXCNqgVpUfeLKZrirmWsCPeGFli(int P_0)
			{
				CustomController customController = gESwCZhPTVpAneBRVEYFzquNJMi.QVMvcPQiQwPWraGoDPoVzaQDVuJ.EEXCNqgVpUfeLKZrirmWsCPeGFli(P_0);
				if (customController == null)
				{
					return null;
				}
				ZeNcCgUkWoGJZAZOLSbHwfsXHTq(customController, false);
				return customController;
			}

			internal void xAZfWMceZkUxrmChMHDWkCtOCNSs(Action<bool, int, int> P_0)
			{
				iRvwVguMTeNCFyqBZrHrHcUUmKB<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void IYekLagvIXUzYjPByyngxUUfTmq(Keyboard P_0, hMnkyrwLnsUHICLHhatCKMLfBPe P_1, Action<bool, int, int> P_2)
			{
				if (!wvdeqoiczJHcRgbEahbuugxImYJk || !P_0.enabled)
				{
					return;
				}
				IXIeKvaSORQFroTficHozSLyjLk eUaiPcvsYuDmCLEQtxOuILMawWB = dSBGNfhWmOBnJhxggXIGiXSpFLdE.eUaiPcvsYuDmCLEQtxOuILMawWB;
				bool flag = false;
				aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Keyboard).sGGfJsmegvsCOukIXQVwszxmlRT(0).mapSet;
				int count = mapSet.Count;
				for (int i = 0; i < count; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)mapSet[i];
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> buttonMaps_orig = keyboardMap.ButtonMaps_orig;
					int count2 = buttonMaps_orig._count;
					for (int j = 0; j < count2; j++)
					{
						ActionElementMap actionElementMap = buttonMaps_orig._items[j];
						if (!actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						bool flag2 = actionElementMap._modifierKey1 != ModifierKey.None || actionElementMap._modifierKey2 != ModifierKey.None || actionElementMap._modifierKey3 != ModifierKey.None;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						bool flag3 = false;
						ModifierKeyFlags modifierKeyFlags;
						JtVEtBYJhQtFKDuamlFmfbgoJGw jtVEtBYJhQtFKDuamlFmfbgoJGw;
						if (flag2)
						{
							modifierKeyFlags = actionElementMap.modifierKeyFlags;
							if (P_0.UajMhGPRKPMztrzwOEyXLqefmDv(keyboardKeyCode, modifierKeyFlags))
							{
								if (!P_1.JLMbojuGdjAHonLHgtDQZjapIqy(keyboardKeyCode, modifierKeyFlags))
								{
									jtVEtBYJhQtFKDuamlFmfbgoJGw = JtVEtBYJhQtFKDuamlFmfbgoJGw.DydAVEtKkgGfMIgCqQnyUpcWAgVj(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx);
									jtVEtBYJhQtFKDuamlFmfbgoJGw.utTCsXoTKybVZQvBnSJsGJBQBnh(ReInput.currentUpdateLoop, true);
									flag3 = true;
									goto IL_0120;
								}
							}
							else
							{
								jtVEtBYJhQtFKDuamlFmfbgoJGw = JtVEtBYJhQtFKDuamlFmfbgoJGw.SEQRoCPgdzgnwFkeVYDcMZYSQZs(actionElementMap.fOjavGziuUSawAgvwyVARpyRBVx);
								if (jtVEtBYJhQtFKDuamlFmfbgoJGw != null)
								{
									goto IL_0120;
								}
							}
							goto IL_0177;
						}
						modifierKeyFlags = ModifierKeyFlags.None;
						ButtonStateFlags buttonStateFlags = P_0.sJNRUDgBlgpVRmEmTGLlTIjHjJJ(actionElementMap.ofrrxjPHuwNabkrGucUvSPRIAGB);
						goto IL_013e;
						IL_013e:
						if (buttonStateFlags != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF && (flag3 || !P_1.JLMbojuGdjAHonLHgtDQZjapIqy(keyboardKeyCode, modifierKeyFlags)))
						{
							RnECfdkQMQhMQtBQPPVVnsXtfre(P_0, keyboardMap, actionElementMap, eUaiPcvsYuDmCLEQtxOuILMawWB, buttonStateFlags);
							P_2(arg1: true, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId);
							flag = true;
							continue;
						}
						goto IL_0177;
						IL_0120:
						buttonStateFlags = jtVEtBYJhQtFKDuamlFmfbgoJGw.yLkyycxzClFhuAQFTWmGasObrdy(true);
						goto IL_013e;
						IL_0177:
						if (eUaiPcvsYuDmCLEQtxOuILMawWB.HpxePuhaScltgSCBmgsrsCpjliL != 0f)
						{
							eUaiPcvsYuDmCLEQtxOuILMawWB.HpxePuhaScltgSCBmgsrsCpjliL = 0f;
						}
						if (eUaiPcvsYuDmCLEQtxOuILMawWB.foizlTVmYytexOFjtTkYhHmXiQC != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
						{
							eUaiPcvsYuDmCLEQtxOuILMawWB.foizlTVmYytexOFjtTkYhHmXiQC = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
						}
						P_2(arg1: false, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId);
					}
				}
				if (flag)
				{
					byCzLCRNRsSPWJlubvghrbaeFdr = ReInput.unscaledTime;
				}
			}

			private static void RnECfdkQMQhMQtBQPPVVnsXtfre(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, IXIeKvaSORQFroTficHozSLyjLk P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.HpxePuhaScltgSCBmgsrsCpjliL = num;
				P_3.foizlTVmYytexOFjtTkYhHmXiQC = P_4;
				P_3.pxFOUEuAQwwDMNyKdQhVGxLNflI = P_0;
				P_3.KuXUxnrnEEmYKlaMyJdtDYyuul = ControllerType.Keyboard;
				P_3.vfOgoNYdPlyNOyYmKzOzPipRXne = ControllerElementType.Button;
				P_3.laNInwdlemPELucvBOGimoeNQfc = P_2;
				P_3.XKsXMwpOxrVrFXsnXueqVpKoaEV = P_1;
				if (P_3.isBfJTbCjlLXPjHJYiieAIxdKiCB)
				{
					P_3.isBfJTbCjlLXPjHJYiieAIxdKiCB = false;
				}
				if (P_3.NxNFdaeaOElPXLgAPBoLILTJWNm)
				{
					P_3.NxNFdaeaOElPXLgAPBoLILTJWNm = false;
				}
			}

			internal void RrINqnuZWxMDgWXyTsAnckxvUBk(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!LNloAmyCTcEELWuVZsOMuoDvDgB || !P_0.enabled)
				{
					return;
				}
				aXnVKdRCFttLXjlGLvvowqKPhkUc mapSet = qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(ControllerType.Mouse).sGGfJsmegvsCOukIXQVwszxmlRT(0).mapSet;
				IXIeKvaSORQFroTficHozSLyjLk eUaiPcvsYuDmCLEQtxOuILMawWB = dSBGNfhWmOBnJhxggXIGiXSpFLdE.eUaiPcvsYuDmCLEQtxOuILMawWB;
				bool flag = false;
				int count = mapSet.Count;
				for (int i = 0; i < count; i++)
				{
					MouseMap mouseMap = (MouseMap)mapSet[i];
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> axisMaps_orig = mouseMap.AxisMaps_orig;
					if (axisMaps_orig != null)
					{
						int count2 = axisMaps_orig._count;
						for (int j = 0; j < count2; j++)
						{
							ActionElementMap actionElementMap = axisMaps_orig._items[j];
							if (!actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.ZvsqMyoYsqIgSAwCsiZaxBMNYOU(actionElementMap, actionId, true, false, out var num))
							{
								continue;
							}
							if (num == 0f)
							{
								P_0.ZvsqMyoYsqIgSAwCsiZaxBMNYOU(actionElementMap, actionId, true, true, out var num2);
								if (num2 == 0f)
								{
									P_1(arg1: false, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId);
									continue;
								}
							}
							eUaiPcvsYuDmCLEQtxOuILMawWB.HpxePuhaScltgSCBmgsrsCpjliL = num;
							eUaiPcvsYuDmCLEQtxOuILMawWB.pxFOUEuAQwwDMNyKdQhVGxLNflI = P_0;
							eUaiPcvsYuDmCLEQtxOuILMawWB.KuXUxnrnEEmYKlaMyJdtDYyuul = ControllerType.Mouse;
							eUaiPcvsYuDmCLEQtxOuILMawWB.vfOgoNYdPlyNOyYmKzOzPipRXne = ControllerElementType.Axis;
							eUaiPcvsYuDmCLEQtxOuILMawWB.laNInwdlemPELucvBOGimoeNQfc = actionElementMap;
							eUaiPcvsYuDmCLEQtxOuILMawWB.XKsXMwpOxrVrFXsnXueqVpKoaEV = mouseMap;
							if (eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm)
							{
								eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm = false;
							}
							if (eUaiPcvsYuDmCLEQtxOuILMawWB.xsXndYnsDYEZmSXyNiYhinTzVHV != AxisCoordinateMode.Relative)
							{
								eUaiPcvsYuDmCLEQtxOuILMawWB.xsXndYnsDYEZmSXyNiYhinTzVHV = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> buttonMaps_orig = mouseMap.ButtonMaps_orig;
					if (buttonMaps_orig == null)
					{
						continue;
					}
					int count3 = buttonMaps_orig._count;
					for (int k = 0; k < count3; k++)
					{
						ActionElementMap actionElementMap2 = buttonMaps_orig._items[k];
						if (!actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.nwifnFGXeLkkrTVqcjGTJytMfiJP(actionElementMap2, actionId2, out var hpxePuhaScltgSCBmgsrsCpjliL, out eUaiPcvsYuDmCLEQtxOuILMawWB.isBfJTbCjlLXPjHJYiieAIxdKiCB))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.sJNRUDgBlgpVRmEmTGLlTIjHjJJ(actionElementMap2.ofrrxjPHuwNabkrGucUvSPRIAGB);
						if (buttonStateFlags == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
						{
							P_1(arg1: false, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId2);
							continue;
						}
						eUaiPcvsYuDmCLEQtxOuILMawWB.HpxePuhaScltgSCBmgsrsCpjliL = hpxePuhaScltgSCBmgsrsCpjliL;
						eUaiPcvsYuDmCLEQtxOuILMawWB.foizlTVmYytexOFjtTkYhHmXiQC = buttonStateFlags;
						eUaiPcvsYuDmCLEQtxOuILMawWB.pxFOUEuAQwwDMNyKdQhVGxLNflI = P_0;
						eUaiPcvsYuDmCLEQtxOuILMawWB.KuXUxnrnEEmYKlaMyJdtDYyuul = ControllerType.Mouse;
						eUaiPcvsYuDmCLEQtxOuILMawWB.vfOgoNYdPlyNOyYmKzOzPipRXne = ControllerElementType.Button;
						eUaiPcvsYuDmCLEQtxOuILMawWB.laNInwdlemPELucvBOGimoeNQfc = actionElementMap2;
						eUaiPcvsYuDmCLEQtxOuILMawWB.XKsXMwpOxrVrFXsnXueqVpKoaEV = mouseMap;
						if (eUaiPcvsYuDmCLEQtxOuILMawWB.isBfJTbCjlLXPjHJYiieAIxdKiCB)
						{
							eUaiPcvsYuDmCLEQtxOuILMawWB.isBfJTbCjlLXPjHJYiieAIxdKiCB = false;
						}
						if (eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm)
						{
							eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm = false;
						}
						P_1(arg1: true, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					znyXvuSeLJwVaWmnwfsFLnjZeeV = ReInput.unscaledTime;
				}
			}

			internal void xaMDqwsWxRUBpkAPaAMYPpwCPVr(Action<bool, int, int> P_0)
			{
				iRvwVguMTeNCFyqBZrHrHcUUmKB<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void iRvwVguMTeNCFyqBZrHrHcUUmKB<T, TMap>(ControllerType P_0, Action<bool, int, int> P_1) where T : ControllerWithAxes where TMap : ControllerMapWithAxes
			{
				kbnxqpuiTgLkmUJPdswbZRMtQYO<T, TMap> kbnxqpuiTgLkmUJPdswbZRMtQYO2 = (kbnxqpuiTgLkmUJPdswbZRMtQYO<T, TMap>)qaaiDhRyNtSbazhnTtGAJLqHvov.PErbMByiRLpfURxMubXbNOTjLuS(P_0);
				IXIeKvaSORQFroTficHozSLyjLk eUaiPcvsYuDmCLEQtxOuILMawWB = dSBGNfhWmOBnJhxggXIGiXSpFLdE.eUaiPcvsYuDmCLEQtxOuILMawWB;
				int count = kbnxqpuiTgLkmUJPdswbZRMtQYO2.Count;
				for (int i = 0; i < count; i++)
				{
					kbnxqpuiTgLkmUJPdswbZRMtQYO<T, TMap>.XMaIGYxSmxoTKaVsVqAuxacFodi xMaIGYxSmxoTKaVsVqAuxacFodi = kbnxqpuiTgLkmUJPdswbZRMtQYO2[i];
					T pxFOUEuAQwwDMNyKdQhVGxLNflI = xMaIGYxSmxoTKaVsVqAuxacFodi.pxFOUEuAQwwDMNyKdQhVGxLNflI;
					if (!pxFOUEuAQwwDMNyKdQhVGxLNflI.enabled)
					{
						continue;
					}
					global::CimpQwMUTGMiTwuOvALwFOVgRyp<TMap> nytTYXdOuEqgOKSTmLpKeODwQdx = xMaIGYxSmxoTKaVsVqAuxacFodi.nytTYXdOuEqgOKSTmLpKeODwQdx;
					bool flag = false;
					int count2 = nytTYXdOuEqgOKSTmLpKeODwQdx.Count;
					for (int j = 0; j < count2; j++)
					{
						TMap xKsXMwpOxrVrFXsnXueqVpKoaEV = nytTYXdOuEqgOKSTmLpKeODwQdx[j];
						if (!xKsXMwpOxrVrFXsnXueqVpKoaEV.enabled)
						{
							continue;
						}
						AList<ActionElementMap> axisMaps_orig = xKsXMwpOxrVrFXsnXueqVpKoaEV.AxisMaps_orig;
						if (axisMaps_orig != null)
						{
							int count3 = axisMaps_orig._count;
							for (int k = 0; k < count3; k++)
							{
								ActionElementMap actionElementMap = axisMaps_orig._items[k];
								if (!actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!pxFOUEuAQwwDMNyKdQhVGxLNflI.ZvsqMyoYsqIgSAwCsiZaxBMNYOU(actionElementMap, actionId, false, false, out var num))
								{
									continue;
								}
								if (num == 0f)
								{
									pxFOUEuAQwwDMNyKdQhVGxLNflI.ZvsqMyoYsqIgSAwCsiZaxBMNYOU(actionElementMap, actionId, false, true, out var num2);
									if (num2 == 0f)
									{
										P_1(arg1: false, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId);
										continue;
									}
								}
								eUaiPcvsYuDmCLEQtxOuILMawWB.HpxePuhaScltgSCBmgsrsCpjliL = num;
								eUaiPcvsYuDmCLEQtxOuILMawWB.pxFOUEuAQwwDMNyKdQhVGxLNflI = pxFOUEuAQwwDMNyKdQhVGxLNflI;
								eUaiPcvsYuDmCLEQtxOuILMawWB.KuXUxnrnEEmYKlaMyJdtDYyuul = P_0;
								eUaiPcvsYuDmCLEQtxOuILMawWB.vfOgoNYdPlyNOyYmKzOzPipRXne = ControllerElementType.Axis;
								eUaiPcvsYuDmCLEQtxOuILMawWB.laNInwdlemPELucvBOGimoeNQfc = actionElementMap;
								eUaiPcvsYuDmCLEQtxOuILMawWB.XKsXMwpOxrVrFXsnXueqVpKoaEV = xKsXMwpOxrVrFXsnXueqVpKoaEV;
								eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm = pxFOUEuAQwwDMNyKdQhVGxLNflI.calibrationMap.Axes[actionElementMap.ofrrxjPHuwNabkrGucUvSPRIAGB].applyRangeCalibration;
								eUaiPcvsYuDmCLEQtxOuILMawWB.xsXndYnsDYEZmSXyNiYhinTzVHV = pxFOUEuAQwwDMNyKdQhVGxLNflI.Axes[actionElementMap.elementIndex].tfkhmJMDJkUYFJkJuabHOpbuotU?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> buttonMaps_orig = xKsXMwpOxrVrFXsnXueqVpKoaEV.ButtonMaps_orig;
						if (buttonMaps_orig != null)
						{
							int count4 = buttonMaps_orig._count;
							for (int l = 0; l < count4; l++)
							{
								ActionElementMap actionElementMap2 = buttonMaps_orig._items[l];
								if (!actionElementMap2.TAiAzEAcNOkrpYWJEmhYYqnFvpF || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float hpxePuhaScltgSCBmgsrsCpjliL = 0f;
								int ofrrxjPHuwNabkrGucUvSPRIAGB = actionElementMap2.ofrrxjPHuwNabkrGucUvSPRIAGB;
								if (!JIhEUTrgPMTLpuxCiBOWrjtxeAS(pxFOUEuAQwwDMNyKdQhVGxLNflI, i, ofrrxjPHuwNabkrGucUvSPRIAGB, actionElementMap2, nytTYXdOuEqgOKSTmLpKeODwQdx, actionId2, ref hpxePuhaScltgSCBmgsrsCpjliL))
								{
									ref bool isBfJTbCjlLXPjHJYiieAIxdKiCB = ref eUaiPcvsYuDmCLEQtxOuILMawWB.isBfJTbCjlLXPjHJYiieAIxdKiCB;
									if (!pxFOUEuAQwwDMNyKdQhVGxLNflI.nwifnFGXeLkkrTVqcjGTJytMfiJP(actionElementMap2, actionId2, out hpxePuhaScltgSCBmgsrsCpjliL, out isBfJTbCjlLXPjHJYiieAIxdKiCB))
									{
										continue;
									}
								}
								int ofrrxjPHuwNabkrGucUvSPRIAGB2 = actionElementMap2.ofrrxjPHuwNabkrGucUvSPRIAGB;
								ButtonStateFlags buttonStateFlags = pxFOUEuAQwwDMNyKdQhVGxLNflI.sJNRUDgBlgpVRmEmTGLlTIjHjJJ(ofrrxjPHuwNabkrGucUvSPRIAGB2);
								if (buttonStateFlags == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
								{
									P_1(arg1: false, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId2);
									continue;
								}
								eUaiPcvsYuDmCLEQtxOuILMawWB.HpxePuhaScltgSCBmgsrsCpjliL = hpxePuhaScltgSCBmgsrsCpjliL;
								eUaiPcvsYuDmCLEQtxOuILMawWB.foizlTVmYytexOFjtTkYhHmXiQC = buttonStateFlags;
								eUaiPcvsYuDmCLEQtxOuILMawWB.pxFOUEuAQwwDMNyKdQhVGxLNflI = pxFOUEuAQwwDMNyKdQhVGxLNflI;
								eUaiPcvsYuDmCLEQtxOuILMawWB.KuXUxnrnEEmYKlaMyJdtDYyuul = P_0;
								eUaiPcvsYuDmCLEQtxOuILMawWB.vfOgoNYdPlyNOyYmKzOzPipRXne = ControllerElementType.Button;
								eUaiPcvsYuDmCLEQtxOuILMawWB.laNInwdlemPELucvBOGimoeNQfc = actionElementMap2;
								eUaiPcvsYuDmCLEQtxOuILMawWB.XKsXMwpOxrVrFXsnXueqVpKoaEV = xKsXMwpOxrVrFXsnXueqVpKoaEV;
								if (eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm)
								{
									eUaiPcvsYuDmCLEQtxOuILMawWB.NxNFdaeaOElPXLgAPBoLILTJWNm = false;
								}
								P_1(arg1: true, gESwCZhPTVpAneBRVEYFzquNJMi.fOjavGziuUSawAgvwyVARpyRBVx, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							xMaIGYxSmxoTKaVsVqAuxacFodi.ZqEEdiUDeOevjfnmGvhwDsnsnQm();
						}
					}
				}
			}

			private bool JIhEUTrgPMTLpuxCiBOWrjtxeAS<TMap>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::CimpQwMUTGMiTwuOvALwFOVgRyp<TMap> P_4, int P_5, ref float P_6) where TMap : ControllerMapWithAxes
			{
				if (!P_0.ebxBmtwxyRprAbJBnnRdvbVCKbL.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.ebxBmtwxyRprAbJBnnRdvbVCKbL.GetUnknownHatButtons(P_2);
				if (XhRPWieoxyShZQGYemgXnijZrSY(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.nwifnFGXeLkkrTVqcjGTJytMfiJP(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool XhRPWieoxyShZQGYemgXnijZrSY<TMap>(UnknownControllerHat.HatButtons P_0, int P_1, global::CimpQwMUTGMiTwuOvALwFOVgRyp<TMap> P_2) where TMap : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (ZBDJpYDybdrRTUGyMbJNEOCFGHYm(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool ZBDJpYDybdrRTUGyMbJNEOCFGHYm<TMap>(UnknownControllerHat.HatButtons P_0, int P_1, global::CimpQwMUTGMiTwuOvALwFOVgRyp<TMap> P_2) where TMap : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int count = P_2.Count;
				for (int i = 0; i < count; i++)
				{
					TMap val = P_2[i];
					IList<ActionElementMap> buttonMaps = val.ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count2 = buttonMaps.Count;
					for (int j = 0; j < count2; j++)
					{
						int ofrrxjPHuwNabkrGucUvSPRIAGB = buttonMaps[j].ofrrxjPHuwNabkrGucUvSPRIAGB;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(ofrrxjPHuwNabkrGucUvSPRIAGB))
						{
							return true;
						}
					}
				}
				return false;
			}

			[CompilerGenerated]
			private static void bLodcsddrHTEuWTjOteQwJmDvMug(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
			}

			[CompilerGenerated]
			private static void vdDPquUVhIygxunWnvPcgIvBxCP(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
			}
		}

		private readonly ChYhaBSijJnTpdXwQSqYJssvGND QVMvcPQiQwPWraGoDPoVzaQDVuJ;

		private bool uMcRXLqSCKncxUuhrHSxgJcdCfv;

		private int fOjavGziuUSawAgvwyVARpyRBVx;

		private string YckvCvRVVkCnFoBTmVxvWZVKnMr;

		private string fbOypwWRvSqgneJJjLTapyNUKtH;

		private bool FMnadxjVOaUgagvSxyTwkypLtEG;

		private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return fOjavGziuUSawAgvwyVARpyRBVx;
			}
			internal set
			{
				fOjavGziuUSawAgvwyVARpyRBVx = value;
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
				return YckvCvRVVkCnFoBTmVxvWZVKnMr;
			}
			internal set
			{
				YckvCvRVVkCnFoBTmVxvWZVKnMr = value;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return string.Empty;
				}
				return fbOypwWRvSqgneJJjLTapyNUKtH;
			}
			internal set
			{
				fbOypwWRvSqgneJJjLTapyNUKtH = value;
			}
		}

		public bool isPlaying
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return FMnadxjVOaUgagvSxyTwkypLtEG;
			}
			set
			{
				FMnadxjVOaUgagvSxyTwkypLtEG = value;
			}
		}

		internal Player(bool isSystem, int playerId, string name, string descriptiveName, HRJeTaRmGlgEoVaWhsuEDjticiT startingControllerMapInfo, ControllerMapLayoutManager.PseBURjmDgdQyBrNSFfUTuoWirpM controllerMapLayoutManagerSettings, ControllerMapEnabler.FIAqEJWjdCiOptKWtsxrOjilkTn controllerMapEnablerSettings)
		{
			uMcRXLqSCKncxUuhrHSxgJcdCfv = isSystem;
			fOjavGziuUSawAgvwyVARpyRBVx = playerId;
			YckvCvRVVkCnFoBTmVxvWZVKnMr = name;
			fbOypwWRvSqgneJJjLTapyNUKtH = descriptiveName;
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
			controllers = new ControllerHelper(this, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
			QVMvcPQiQwPWraGoDPoVzaQDVuJ = ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco;
			EJpmrTgGvrhKjJnkpXbomYBpQTQ();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(fOjavGziuUSawAgvwyVARpyRBVx));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.tczGrLoSLQRKAWwrReBmbHatjKF() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.tczGrLoSLQRKAWwrReBmbHatjKF() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.wyMTjzWuSYHxxwaQSHqUbLUGgKg() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.wyMTjzWuSYHxxwaQSHqUbLUGgKg() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.KsQmhhakoIMsmFFssFWZgAtACAmj() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.KsQmhhakoIMsmFFssFWZgAtACAmj() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.hOuVCsfFccvyBzqOmUyNGejSnqg() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.hOuVCsfFccvyBzqOmUyNGejSnqg() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.qGdIlqXDgmmfISyLXYdCpbxYquo() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.qGdIlqXDgmmfISyLXYdCpbxYquo() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.bLTbjPpppdHjbxMklgpfIqXRyYp() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.bLTbjPpppdHjbxMklgpfIqXRyYp() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.uTpONumFLTkWQBGLiuKkYLcPhqBe() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.uTpONumFLTkWQBGLiuKkYLcPhqBe() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.whhBjVbfHOZRjSSbvvVshFrslSsJ(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.whhBjVbfHOZRjSSbvvVshFrslSsJ(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName)
		{
			return GetButtonDoublePressHold(actionName, 0f);
		}

		public bool GetButtonDoublePressHold(int actionId)
		{
			return GetButtonDoublePressHold(actionId, 0f);
		}

		public bool GetButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.QdNapEezgsjcIFSIbPqrnaMZYnq(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.QdNapEezgsjcIFSIbPqrnaMZYnq(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.TtNcTNwxGEmdaqaGhItPkYvZUdO(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.TtNcTNwxGEmdaqaGhItPkYvZUdO(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(string actionName)
		{
			return GetButtonDoublePressUp(actionName, 0f);
		}

		public bool GetButtonDoublePressUp(int actionId)
		{
			return GetButtonDoublePressUp(actionId, 0f);
		}

		public bool GetButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.aDlFclJjaCPQLDrdiNxmhIBTyMI(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.aDlFclJjaCPQLDrdiNxmhIBTyMI(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.aDlFclJjaCPQLDrdiNxmhIBTyMI(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.aDlFclJjaCPQLDrdiNxmhIBTyMI(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.sJWIGDsUFDoKbNAvyOYaskgwHl(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.sJWIGDsUFDoKbNAvyOYaskgwHl(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.lCGBACeaSOuNLNMWNtxBERBspZZe(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.lCGBACeaSOuNLNMWNtxBERBspZZe(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.lCGBACeaSOuNLNMWNtxBERBspZZe(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.lCGBACeaSOuNLNMWNtxBERBspZZe(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.dKbahpClgHBuTgUPoelgHzAZVwQ() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.dKbahpClgHBuTgUPoelgHzAZVwQ() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.axtYUltftYAAjLPpUwFjQcEktUM() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.axtYUltftYAAjLPpUwFjQcEktUM() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.OeXCqNiCLCaJzCiThgBniwNKGycT() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.OeXCqNiCLCaJzCiThgBniwNKGycT() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.fgiCbahJbtQhKcuDieKIRhCuqUh() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.fgiCbahJbtQhKcuDieKIRhCuqUh() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.iixuPYZWCGdNerQwVyFULoIHNjd() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.iixuPYZWCGdNerQwVyFULoIHNjd() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.gGlIKclBCWWWrDZXIZMThojjQoM() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.gGlIKclBCWWWrDZXIZMThojjQoM() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.FmdAkBdCmGnmfuYHekqHitZeeAud() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.FmdAkBdCmGnmfuYHekqHitZeeAud() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.bBbXsYHFeBvAjkinoiIFFuBLCBWS(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.bFKUBVJsrjxGlwNxhyQsURGSIqj(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.kNRsZXBAYLbdwHbcUybDHytAORr(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.jQwfojcbbLwzJLtlhXQHizmIhCz(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.WauVOxzcNMHVLRuwItTTKDEMssd() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.WauVOxzcNMHVLRuwItTTKDEMssd() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.qspOkCVETJmjRdLTpzzGWWkmhaO() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.qspOkCVETJmjRdLTpzzGWWkmhaO() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.KpRTXcEtyGlzHQYXMAstvlyskee() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.KpRTXcEtyGlzHQYXMAstvlyskee() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.KyvdceKirMVFNQGItYflXrFbvzb() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.KyvdceKirMVFNQGItYflXrFbvzb() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.ZwUMSLHJcuYAbRcebDaGJalfcRoE() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.ZwUMSLHJcuYAbRcebDaGJalfcRoE() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.VdfXOJuqKRFlPuSWWCQbwWJCAGE() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.VdfXOJuqKRFlPuSWWCQbwWJCAGE() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.IVMAHIftfIRpuOqIAGjgiDkkRjin() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.IVMAHIftfIRpuOqIAGjgiDkkRjin() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.HbNlUNgsylguLzJPkeRobqoYHepA() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.HbNlUNgsylguLzJPkeRobqoYHepA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.lwafttAKnLnDHJihTAGtqqzlIeee() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.lwafttAKnLnDHJihTAGtqqzlIeee() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.OTglXCPZGItNKXZxLhhMYgiYbsV(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.OTglXCPZGItNKXZxLhhMYgiYbsV(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName)
		{
			return GetNegativeButtonDoublePressHold(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressHold(int actionId)
		{
			return GetNegativeButtonDoublePressHold(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.WyLjqxgprRvoNWgecDgFAQkYIrgd(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.WyLjqxgprRvoNWgecDgFAQkYIrgd(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(string actionName)
		{
			return GetNegativeButtonDoublePressDown(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(int actionId)
		{
			return GetNegativeButtonDoublePressDown(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.mjCeSzCOEPPLFcKnhpcBmZPiIPEW(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.mjCeSzCOEPPLFcKnhpcBmZPiIPEW(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(string actionName)
		{
			return GetNegativeButtonDoublePressUp(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(int actionId)
		{
			return GetNegativeButtonDoublePressUp(actionId, 0f);
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.tmlloKqIdCfFITAoOYARyaxEtyv(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.tmlloKqIdCfFITAoOYARyaxEtyv(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.tmlloKqIdCfFITAoOYARyaxEtyv(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.tmlloKqIdCfFITAoOYARyaxEtyv(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.YtrbEJJmdYiNtYonULizSHGocQq(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.YtrbEJJmdYiNtYonULizSHGocQq(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.LIllZNjOorYAJCuobbEpGHmtgLG(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.LIllZNjOorYAJCuobbEpGHmtgLG(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.LIllZNjOorYAJCuobbEpGHmtgLG(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.LIllZNjOorYAJCuobbEpGHmtgLG(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.TrIFGfGydgzIrCnTzSmtpMPcFRs() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.TrIFGfGydgzIrCnTzSmtpMPcFRs() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.wUSQKFPgCYLyOVIaLcaREOOgaSd() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.wUSQKFPgCYLyOVIaLcaREOOgaSd() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.rUpFbmIxUmCKBTXGxQRfuvWzAnM() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.rUpFbmIxUmCKBTXGxQRfuvWzAnM() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.ibyWTTbBqaiJKzbJQgrdCnhaOoU() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.ibyWTTbBqaiJKzbJQgrdCnhaOoU() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.tQKWTalcnUHuIXUuxfVFuCyQaJWa() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.tQKWTalcnUHuIXUuxfVFuCyQaJWa() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.zTPDXluCTGkSgLXaycbrprdTzeO() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.zTPDXluCTGkSgLXaycbrprdTzeO() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.TTtEvsDAazCbegtEELzSwGKHTrig() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.TTtEvsDAazCbegtEELzSwGKHTrig() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.XMiSioRGzWKcpTLdUCWanpTXRyO(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.DFfOsSHSkVEaxLmynSHamJhfGyyh(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.mHmforKaWCqgzJraHcgcZvIRfQwf(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.ylkFjeYhAiHvOQiSlSTlKMHHfAa(fOjavGziuUSawAgvwyVARpyRBVx);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.vNaIOWRfUBghmmOJTErOPayDneE() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.vNaIOWRfUBghmmOJTErOPayDneE() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.xLNJqBNrswsjyXJMOJMtKTJstvH() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.xLNJqBNrswsjyXJMOJMtKTJstvH() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.aKtyyQJXaksGFdepXiicilcqmAz() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.aKtyyQJXaksGFdepXiicilcqmAz() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.bvPTHnqrzMoGbcmasrUYlTzxMan() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.bvPTHnqrzMoGbcmasrUYlTzxMan() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.YuvFXJjoKbLzYOyrEHknhYlkvhl() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.YuvFXJjoKbLzYOyrEHknhYlkvhl() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.aaRWGOqBZbRrpeNeRAkuZFnwpBQ() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.aaRWGOqBZbRrpeNeRAkuZFnwpBQ() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.cArkNyzMOorWWSNzObtLqCsVBtr() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.cArkNyzMOorWWSNzObtLqCsVBtr() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.PEyjSkXKMLLKdhBrSUBseXpmtSe() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.PEyjSkXKMLLKdhBrSUBseXpmtSe() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aKtyyQJXaksGFdepXiicilcqmAz();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aKtyyQJXaksGFdepXiicilcqmAz();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aKtyyQJXaksGFdepXiicilcqmAz();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aKtyyQJXaksGFdepXiicilcqmAz();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.YuvFXJjoKbLzYOyrEHknhYlkvhl();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.YuvFXJjoKbLzYOyrEHknhYlkvhl();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.YuvFXJjoKbLzYOyrEHknhYlkvhl();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.YuvFXJjoKbLzYOyrEHknhYlkvhl();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.bvPTHnqrzMoGbcmasrUYlTzxMan();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.bvPTHnqrzMoGbcmasrUYlTzxMan();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.bvPTHnqrzMoGbcmasrUYlTzxMan();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.bvPTHnqrzMoGbcmasrUYlTzxMan();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aaRWGOqBZbRrpeNeRAkuZFnwpBQ();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionName, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aaRWGOqBZbRrpeNeRAkuZFnwpBQ();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, xAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.x = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aaRWGOqBZbRrpeNeRAkuZFnwpBQ();
			}
			dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, yAxisActionId, true);
			if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2 != null)
			{
				result.y = dSBGNfhWmOBnJhxggXIGiXSpFLdE2.aaRWGOqBZbRrpeNeRAkuZFnwpBQ();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.jBvTvekhPPSnTfOevseVOoANboiD() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.jBvTvekhPPSnTfOevseVOoANboiD() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.lsDBpCjjvErUdqJrBXyEMtkgjQB() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.lsDBpCjjvErUdqJrBXyEMtkgjQB() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.scNpoQFixNaoKeooFtxzugQJONOQ() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.scNpoQFixNaoKeooFtxzugQJONOQ() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.oFztjPFMuTUcIoFzBnKJwlnLemu() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.oFztjPFMuTUcIoFzBnKJwlnLemu() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.goRWYwJTxXIwQvvlqTNFgLgQLGB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.goRWYwJTxXIwQvvlqTNFgLgQLGB() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.XvpCdaFqDlxJucqISdVdcRymbYxK() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.XvpCdaFqDlxJucqISdVdcRymbYxK() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.OLHQNyfSZNjlIVgYtdCCJpVzLZI() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.OLHQNyfSZNjlIVgYtdCCJpVzLZI() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.gDpejzNTeeJRDkNPCyOtpfpYGmg() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return AxisCoordinateMode.Absolute;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.gDpejzNTeeJRDkNPCyOtpfpYGmg() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.GFxJnxIrzgBDMuFACVhmcASDNQU();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.GFxJnxIrzgBDMuFACVhmcASDNQU();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionName, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return QVMvcPQiQwPWraGoDPoVzaQDVuJ.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(fOjavGziuUSawAgvwyVARpyRBVx, actionId, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.ClYADwuGCcDzxlqMVqgVHGhbARy(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.ClYADwuGCcDzxlqMVqgVHGhbARy(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, (object[])null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionId, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionName, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.ClYADwuGCcDzxlqMVqgVHGhbARy(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.ClYADwuGCcDzxlqMVqgVHGhbARy(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.PcvrLwJfQkATCIgvYbqASXVMKFCJ(fOjavGziuUSawAgvwyVARpyRBVx, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QVMvcPQiQwPWraGoDPoVzaQDVuJ.GnynYeRDnILdbolUyKDXfomUmyG(fOjavGziuUSawAgvwyVARpyRBVx);
				}
			}
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					num = MathTools.Max(joystick.GetVibration(motorIndex), num);
				}
			}
			return num;
		}

		public void StopVibration()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.StopVibration();
				}
			}
		}

		internal void QjNHfjHnCmaQyvCGKbwODraSxUWC()
		{
			EJpmrTgGvrhKjJnkpXbomYBpQTQ();
		}

		private void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
		{
			controllers.EJpmrTgGvrhKjJnkpXbomYBpQTQ();
			FMnadxjVOaUgagvSxyTwkypLtEG = false;
		}
	}
}
