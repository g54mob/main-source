using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	public sealed class UserData
	{
		private static class hQFlTczTooYVbHDgHBoiIhBpFsPe
		{
			private class RcUTquXHCAvyGaPBfMLfcnmCCaP
			{
				public enum VaqfwhdabaVjMHRIwcNHnsBJfXqg
				{
					ebxrZAcVKcRjSOJmQrDizoGypxh = 0,
					mgYrBQfuwOpdNKDSIbFbRLGIiFP = 1,
					TlFNkMkCRiFdCGurBhKbcSOElLcv = 2
				}

				public int ebxrZAcVKcRjSOJmQrDizoGypxh;

				public int mgYrBQfuwOpdNKDSIbFbRLGIiFP;

				public int TlFNkMkCRiFdCGurBhKbcSOElLcv;

				public int this[VaqfwhdabaVjMHRIwcNHnsBJfXqg type]
				{
					get
					{
						while (true)
						{
							int num = -356797150;
							while (true)
							{
								switch (num ^ -356797149)
								{
								case 3:
									break;
								case 1:
									switch (type)
									{
									default:
										goto IL_0036;
									case VaqfwhdabaVjMHRIwcNHnsBJfXqg.ebxrZAcVKcRjSOJmQrDizoGypxh:
										break;
									case VaqfwhdabaVjMHRIwcNHnsBJfXqg.mgYrBQfuwOpdNKDSIbFbRLGIiFP:
										return mgYrBQfuwOpdNKDSIbFbRLGIiFP;
									case VaqfwhdabaVjMHRIwcNHnsBJfXqg.TlFNkMkCRiFdCGurBhKbcSOElLcv:
										return TlFNkMkCRiFdCGurBhKbcSOElLcv;
									}
									goto default;
								default:
									return ebxrZAcVKcRjSOJmQrDizoGypxh;
								case 0:
									throw new NotImplementedException();
								}
								break;
								IL_0036:
								num = -356797149;
							}
						}
					}
					set
					{
						switch (type)
						{
						case VaqfwhdabaVjMHRIwcNHnsBJfXqg.ebxrZAcVKcRjSOJmQrDizoGypxh:
							while (true)
							{
								ebxrZAcVKcRjSOJmQrDizoGypxh = value;
								int num = -1711880762;
								while (true)
								{
									switch (num ^ -1711880765)
									{
									case 0:
										num = -1711880761;
										continue;
									case 4:
										break;
									case 2:
										goto end_IL_0040;
									case 1:
										goto IL_005d;
									case 5:
										return;
									default:
										goto end_IL_0003;
									}
									break;
								}
								continue;
								end_IL_0040:
								break;
							}
							goto case VaqfwhdabaVjMHRIwcNHnsBJfXqg.mgYrBQfuwOpdNKDSIbFbRLGIiFP;
						case VaqfwhdabaVjMHRIwcNHnsBJfXqg.mgYrBQfuwOpdNKDSIbFbRLGIiFP:
							mgYrBQfuwOpdNKDSIbFbRLGIiFP = value;
							return;
						case VaqfwhdabaVjMHRIwcNHnsBJfXqg.TlFNkMkCRiFdCGurBhKbcSOElLcv:
							goto IL_005d;
							IL_005d:
							TlFNkMkCRiFdCGurBhKbcSOElLcv = value;
							return;
							end_IL_0003:
							break;
						}
						throw new NotImplementedException();
					}
				}

				public RcUTquXHCAvyGaPBfMLfcnmCCaP(int origId, int otherId, int finalId)
				{
					ebxrZAcVKcRjSOJmQrDizoGypxh = origId;
					mgYrBQfuwOpdNKDSIbFbRLGIiFP = otherId;
					TlFNkMkCRiFdCGurBhKbcSOElLcv = finalId;
				}

				public override string ToString()
				{
					string text = "";
					text += StringTools.WriteVar("origId", ebxrZAcVKcRjSOJmQrDizoGypxh);
					while (true)
					{
						int num = 520957900;
						while (true)
						{
							switch (num ^ 0x1F0D2FCD)
							{
							case 2:
								break;
							case 1:
								goto IL_0040;
							default:
								return text + StringTools.WriteVar("finalId", TlFNkMkCRiFdCGurBhKbcSOElLcv);
							}
							break;
							IL_0040:
							text += StringTools.WriteVar("otherId", mgYrBQfuwOpdNKDSIbFbRLGIiFP);
							num = 520957901;
						}
					}
				}
			}

			private class htyiGeTIlIuunxGqoEdPhWYaYxJo<T>
			{
				public T WAXRrBwldppmaOlJLDIYCUmBYaD;

				public T NvWvpLcivPwaRMszPLXmXxMLzyb;

				public RcUTquXHCAvyGaPBfMLfcnmCCaP.VaqfwhdabaVjMHRIwcNHnsBJfXqg QiMDfljswXynnIIhmOOTitPrUQke;

				public IList<T> ngVMhuTMwJNCnlEAbYZPSBJKCKE;

				public bool snqztkQepdQnGBnhenGsIbqrmFF;

				public htyiGeTIlIuunxGqoEdPhWYaYxJo(T otherItem, T finalItem, RcUTquXHCAvyGaPBfMLfcnmCCaP.VaqfwhdabaVjMHRIwcNHnsBJfXqg idType, IList<T> finalItems, bool isCollision)
				{
					while (true)
					{
						int num = 1339925746;
						while (true)
						{
							switch (num ^ 0x4FDDA4F3)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								NvWvpLcivPwaRMszPLXmXxMLzyb = finalItem;
								QiMDfljswXynnIIhmOOTitPrUQke = idType;
								ngVMhuTMwJNCnlEAbYZPSBJKCKE = finalItems;
								snqztkQepdQnGBnhenGsIbqrmFF = isCollision;
								return;
							}
							break;
							IL_0024:
							WAXRrBwldppmaOlJLDIYCUmBYaD = otherItem;
							num = 1339925745;
						}
					}
				}
			}

			private sealed class SAhulRYeMNjjDdkhYioTHxuUhjaA
			{
				private sealed class PGiZipVFTuDIrfxsQbujkFIsoiq
				{
					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public htyiGeTIlIuunxGqoEdPhWYaYxJo<InputAction> TYovXjkOcRdoWLmukRjeRaWZFiY;

					public bool qqrniVTeXkYvHhqCNOnxXbHxizV(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD.categoryId;
					}

					public bool FErHgLbcwZSenOVXASaKSQFRANS(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD.behaviorId;
					}
				}

				private sealed class BucLYabkFeBFxgsioofQcoabmrm
				{
					public htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapLayoutManager_RuleSet_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;
				}

				private sealed class ESGWFEsKpDjSasoHSVBnUeUaEyFb
				{
					public BucLYabkFeBFxgsioofQcoabmrm eArEAgVImvbIGBrGKlfNbYorlfN;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int xbZRoYTggiqnHjvvautXHjWPbwq;

					public bool powfQIteFeSdaQfAlRkBDfmhpjQ(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[eArEAgVImvbIGBrGKlfNbYorlfN.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == xbZRoYTggiqnHjvvautXHjWPbwq;
					}
				}

				private sealed class UndgJubrnuxqXWvAffAYzcDaGFLt
				{
					public BucLYabkFeBFxgsioofQcoabmrm eArEAgVImvbIGBrGKlfNbYorlfN;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int xbZRoYTggiqnHjvvautXHjWPbwq;

					public bool LShppqWWCPaJcnWtGLAEbTsRPdE(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[eArEAgVImvbIGBrGKlfNbYorlfN.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == xbZRoYTggiqnHjvvautXHjWPbwq;
					}
				}

				private sealed class UnpsSLapeoruigQjgInEkhMUCsX
				{
					public BucLYabkFeBFxgsioofQcoabmrm eArEAgVImvbIGBrGKlfNbYorlfN;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int xbZRoYTggiqnHjvvautXHjWPbwq;

					public bool wfPOBlKHNmjHdqOOYWhYuAFtCuM(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[eArEAgVImvbIGBrGKlfNbYorlfN.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == xbZRoYTggiqnHjvvautXHjWPbwq;
					}
				}

				private sealed class HbGkmtCwmBzaLTHMzFxvYQguvc
				{
					public htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapEnabler_RuleSet_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;
				}

				private sealed class bTonhfPFyrwFASqCTHhpdlwGwst
				{
					public HbGkmtCwmBzaLTHMzFxvYQguvc ImkLKknnoOMcNcBvkUbAyJwezye;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int xbZRoYTggiqnHjvvautXHjWPbwq;

					public bool dqRITUABQFqUKTsFasUHzhkCxFz(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[ImkLKknnoOMcNcBvkUbAyJwezye.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == xbZRoYTggiqnHjvvautXHjWPbwq;
					}
				}

				private sealed class RNwTsGyKhviQRneSUwmrecJbZmn
				{
					public HbGkmtCwmBzaLTHMzFxvYQguvc ImkLKknnoOMcNcBvkUbAyJwezye;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int xbZRoYTggiqnHjvvautXHjWPbwq;

					public bool SrPCRqkLWLneETpUDIbCIDjKMhE(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[ImkLKknnoOMcNcBvkUbAyJwezye.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == xbZRoYTggiqnHjvvautXHjWPbwq;
					}
				}

				private sealed class vcVUMuXthBRGGRZeouXsmJxhhHC
				{
					public HbGkmtCwmBzaLTHMzFxvYQguvc ImkLKknnoOMcNcBvkUbAyJwezye;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int xbZRoYTggiqnHjvvautXHjWPbwq;

					public bool bbzlFypbegawyuFZXDobxsaOOCT(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[ImkLKknnoOMcNcBvkUbAyJwezye.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == xbZRoYTggiqnHjvvautXHjWPbwq;
					}
				}

				private sealed class PTCmFQWXzkJRQMMymGMmfAeHvhpb
				{
					private sealed class DzzSepSDEkkjcdfTIQDnxOVpJfW
					{
						public PTCmFQWXzkJRQMMymGMmfAeHvhpb SoEhKrmxLLhRNCtXhPjVBziOIwb;

						public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

						public Player_Editor.Mapping LnGQdTkvjCFdlrhTrhGIyQCHdZz;

						public bool TuIByZevwtgiIaNlNtycEBrYIaS(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
						{
							return P_0[SoEhKrmxLLhRNCtXhPjVBziOIwb.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == LnGQdTkvjCFdlrhTrhGIyQCHdZz.categoryId;
						}

						public bool lmWBTKSZGnVlNMluoBfgBCwPHzRM(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
						{
							return P_0[SoEhKrmxLLhRNCtXhPjVBziOIwb.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == LnGQdTkvjCFdlrhTrhGIyQCHdZz.layoutId;
						}
					}

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public htyiGeTIlIuunxGqoEdPhWYaYxJo<Player_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;

					public void cLMUjocJrneWlWDTWGNETWDhFiU(List<Player_Editor.Mapping> P_0, List<RcUTquXHCAvyGaPBfMLfcnmCCaP> P_1)
					{
						int num = 0;
						DzzSepSDEkkjcdfTIQDnxOVpJfW dzzSepSDEkkjcdfTIQDnxOVpJfW = default(DzzSepSDEkkjcdfTIQDnxOVpJfW);
						while (true)
						{
							int num2;
							int num3;
							if (num >= P_0.Count)
							{
								num2 = 965982654;
								num3 = num2;
							}
							else
							{
								num2 = 965982653;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x3993B9B8)
								{
								case 0:
									num2 = 965982653;
									continue;
								default:
									return;
								case 7:
									num++;
									num2 = 965982652;
									continue;
								case 3:
								{
									RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = P_1.Find(dzzSepSDEkkjcdfTIQDnxOVpJfW.lmWBTKSZGnVlNMluoBfgBCwPHzRM);
									dzzSepSDEkkjcdfTIQDnxOVpJfW.LnGQdTkvjCFdlrhTrhGIyQCHdZz.layoutId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
									num2 = 965982655;
									continue;
								}
								case 4:
									break;
								case 2:
									dzzSepSDEkkjcdfTIQDnxOVpJfW.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
									num2 = 965982649;
									continue;
								case 1:
								{
									dzzSepSDEkkjcdfTIQDnxOVpJfW.LnGQdTkvjCFdlrhTrhGIyQCHdZz = P_0[num];
									RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(dzzSepSDEkkjcdfTIQDnxOVpJfW.TuIByZevwtgiIaNlNtycEBrYIaS);
									dzzSepSDEkkjcdfTIQDnxOVpJfW.LnGQdTkvjCFdlrhTrhGIyQCHdZz.categoryId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
									num2 = 965982651;
									continue;
								}
								case 5:
									dzzSepSDEkkjcdfTIQDnxOVpJfW = new DzzSepSDEkkjcdfTIQDnxOVpJfW();
									dzzSepSDEkkjcdfTIQDnxOVpJfW.SoEhKrmxLLhRNCtXhPjVBziOIwb = this;
									num2 = 965982650;
									continue;
								case 6:
									return;
								}
								break;
							}
						}
					}
				}

				private sealed class ZKtYpqYzpnCuDziIvLCNffElxUa
				{
					public PTCmFQWXzkJRQMMymGMmfAeHvhpb SoEhKrmxLLhRNCtXhPjVBziOIwb;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public Player_Editor.CreateControllerInfo rAkUsdTnKPsjogOHmtoXScXdcVa;

					public bool pmsFGkkMftgeEeMvHhFntzewkTu(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[SoEhKrmxLLhRNCtXhPjVBziOIwb.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == rAkUsdTnKPsjogOHmtoXScXdcVa.sourceId;
					}
				}

				private sealed class pllrWCdNAOwufpfkdkCKbMWAYMv
				{
					public PTCmFQWXzkJRQMMymGMmfAeHvhpb SoEhKrmxLLhRNCtXhPjVBziOIwb;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int IcfehugnHVBDSlLvDDweqELIXNqm;

					public bool qxKMqUrOnspStdBDFFFLlbIALLY(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[SoEhKrmxLLhRNCtXhPjVBziOIwb.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == IcfehugnHVBDSlLvDDweqELIXNqm;
					}
				}

				private sealed class VIDIgnSPHEYuebQaEmXuRkQODJf
				{
					public PTCmFQWXzkJRQMMymGMmfAeHvhpb SoEhKrmxLLhRNCtXhPjVBziOIwb;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public int IcfehugnHVBDSlLvDDweqELIXNqm;

					public bool DtaIVXaxmpXIwfVTmhZiGCqyfuT(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[SoEhKrmxLLhRNCtXhPjVBziOIwb.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == IcfehugnHVBDSlLvDDweqELIXNqm;
					}
				}

				public UserData VSIQlSXoGrtTSUPbSmfBclKbHBB;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> SsbEVLTIbWsgOHcmbgkPFWutBvto;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> SEAxlZKkmhXGWQulotwsLcRQCvZ;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> SEfshPOIrHMtnqpzbElCsLiUazVa;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> lGfBjiWXRzewPZnfqILeCrKIDvc;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> JxDjicVKyEMuKcjzXecrKRysDayS;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> ZoeEsMhgrIVKMSOxpgqDZhOysyAT;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> tOFFRlDtGUJxWietCdmiDsRFAEoq;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> mwChnmOETAyyCvvuAlqkwXDYeNc;

				public Func<ControllerType, List<RcUTquXHCAvyGaPBfMLfcnmCCaP>> qLcgTUNRASzVuyeaicCnLfUsCBu;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> CqLxuNvQSBdAMUNikIivkBCWkLm;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> JjfaTLyWDOdfEyfBORsPCHrWwq;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> OBVyQAJOtjQKfACiROdUQjRjawQ;

				private static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> xuGJwufdhhEmcaPMATcJvyPNdayF;

				private static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> qQrafyZHpKBrhyFwgkfmUbmljdzd;

				public InputCategory iqyRTDlGHetyVIESRjUXsIgthcF(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					InputCategory inputCategory2 = default(InputCategory);
					if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
					{
						inputCategory2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
						goto IL_001b;
					}
					goto IL_0068;
					IL_0068:
					VSIQlSXoGrtTSUPbSmfBclKbHBB.AddActionCategory();
					int num = -2014015238;
					goto IL_0020;
					IL_001b:
					num = -2014015240;
					goto IL_0020;
					IL_0020:
					while (true)
					{
						switch (num ^ -2014015239)
						{
						case 4:
							break;
						case 1:
							num = -2014015237;
							continue;
						case 3:
							inputCategory2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
							num = -2014015237;
							continue;
						case 0:
							goto IL_0068;
						default:
						{
							inputCategory.id = inputCategory2.id;
							int index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputCategory2);
							P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputCategory;
							return inputCategory;
						}
						}
						break;
					}
					goto IL_001b;
				}

				public InputBehavior kVwGwCrVCRfmyivwOVOPSToItEg(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					if (!P_0.snqztkQepdQnGBnhenGsIbqrmFF)
					{
						goto IL_003f;
					}
					InputBehavior inputBehavior2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
					goto IL_006a;
					IL_003f:
					VSIQlSXoGrtTSUPbSmfBclKbHBB.AddInputBehavior();
					inputBehavior2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
					int num = 1255557473;
					goto IL_0022;
					IL_006a:
					inputBehavior.id = inputBehavior2.id;
					num = 1255557474;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num ^ 0x4AD64961)
						{
						case 2:
							num = 1255557472;
							continue;
						case 1:
							break;
						case 0:
							goto IL_006a;
						default:
						{
							int index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputBehavior2);
							P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputBehavior;
							return inputBehavior;
						}
						}
						break;
					}
					goto IL_003f;
				}

				public InputAction dADrqrPnMOzXHvPLlPZlrmjLBkE(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputAction> P_0)
				{
					PGiZipVFTuDIrfxsQbujkFIsoiq pGiZipVFTuDIrfxsQbujkFIsoiq = new PGiZipVFTuDIrfxsQbujkFIsoiq();
					pGiZipVFTuDIrfxsQbujkFIsoiq.TJIgXNvoSVJXczwAANQkpnqJerC = this;
					pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
					InputAction inputAction = default(InputAction);
					int num2 = default(int);
					InputAction inputAction2 = default(InputAction);
					int behaviorId = default(int);
					while (true)
					{
						int num = 1159123912;
						while (true)
						{
							int num4;
							int num5;
							switch (num ^ 0x4516D3C9)
							{
							case 4:
								break;
							case 6:
								inputAction = pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
								num = 1159123913;
								continue;
							case 3:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.AddAction(num2);
								inputAction = pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = 1159123913;
								continue;
							case 1:
							{
								inputAction2 = JsonTools.Clone(pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = SsbEVLTIbWsgOHcmbgkPFWutBvto.Find(pGiZipVFTuDIrfxsQbujkFIsoiq.qqrniVTeXkYvHhqCNOnxXbHxizV);
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP == null)
								{
									num = 1159123915;
									continue;
								}
								num4 = rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv;
								goto IL_00f6;
							}
							case 8:
								inputAction2.categoryId = num2;
								inputAction2.behaviorId = behaviorId;
								num = 1159123916;
								continue;
							case 2:
								num4 = 0;
								goto IL_00f6;
							case 0:
							{
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = SEAxlZKkmhXGWQulotwsLcRQCvZ.Find(pGiZipVFTuDIrfxsQbujkFIsoiq.FErHgLbcwZSenOVXASaKSQFRANS);
								behaviorId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : 0);
								inputAction2.id = inputAction.id;
								int num3;
								if (num2 != inputAction.categoryId)
								{
									num = 1159123918;
									num3 = num;
								}
								else
								{
									num = 1159123905;
									num3 = num;
								}
								continue;
							}
							case 7:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.ChangeActionCategory(inputAction.id, num2);
								num = 1159123905;
								continue;
							default:
								{
									int index = pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputAction);
									pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputAction2;
									return inputAction2;
								}
								IL_00f6:
								num2 = num4;
								if (!pGiZipVFTuDIrfxsQbujkFIsoiq.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									num = 1159123914;
									num5 = num;
								}
								else
								{
									num = 1159123919;
									num5 = num;
								}
								continue;
							}
							break;
						}
					}
				}

				public InputLayout fAfgAYFnaInFdicfyZZctQDQUthu(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					InputLayout inputLayout2 = default(InputLayout);
					if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
					{
						inputLayout2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
						goto IL_004a;
					}
					goto IL_009e;
					IL_009e:
					VSIQlSXoGrtTSUPbSmfBclKbHBB.AddKeyboardLayout();
					int num = 1018631667;
					goto IL_0025;
					IL_004a:
					inputLayout.id = inputLayout2.id;
					num = 1018631669;
					goto IL_0025;
					IL_0025:
					while (true)
					{
						switch (num ^ 0x3CB715F1)
						{
						case 3:
							num = 1018631664;
							continue;
						case 5:
							break;
						case 2:
							inputLayout2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
							num = 1018631668;
							continue;
						case 4:
						{
							int index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputLayout2);
							P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputLayout;
							num = 1018631665;
							continue;
						}
						case 1:
							goto IL_009e;
						default:
							return inputLayout;
						}
						break;
					}
					goto IL_004a;
				}

				public InputLayout NxlSbfmLoSFdqROpvcXZGZcbWODE(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
					{
						goto IL_0014;
					}
					goto IL_0073;
					IL_0014:
					int num = 486123179;
					goto IL_0019;
					IL_0019:
					InputLayout inputLayout2 = default(InputLayout);
					int index = default(int);
					while (true)
					{
						switch (num ^ 0x1CF9A6AA)
						{
						case 4:
							break;
						case 2:
							inputLayout.id = inputLayout2.id;
							index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputLayout2);
							num = 486123178;
							continue;
						case 5:
							num = 486123176;
							continue;
						case 1:
							inputLayout2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
							num = 486123183;
							continue;
						case 3:
							goto IL_0073;
						default:
							P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputLayout;
							return inputLayout;
						}
						break;
					}
					goto IL_0014;
					IL_0073:
					VSIQlSXoGrtTSUPbSmfBclKbHBB.AddMouseLayout();
					inputLayout2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
					num = 486123176;
					goto IL_0019;
				}

				public InputLayout juWgrwxZfelPYiAptbwQiDgzbvRz(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					InputLayout inputLayout2 = default(InputLayout);
					while (true)
					{
						int num = -87510581;
						while (true)
						{
							switch (num ^ -87510583)
							{
							case 0:
								break;
							case 2:
								if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									inputLayout2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
									num = -87510584;
									continue;
								}
								goto case 3;
							case 1:
							{
								inputLayout.id = inputLayout2.id;
								int index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputLayout2);
								P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputLayout;
								num = -87510579;
								continue;
							}
							case 3:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.AddJoystickLayout();
								inputLayout2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = -87510584;
								continue;
							default:
								return inputLayout;
							}
							break;
						}
					}
				}

				public InputLayout pXblyOzOuYdeYpuUXeysYDCdPyc(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					InputLayout inputLayout2 = default(InputLayout);
					while (true)
					{
						int num = 1748007844;
						while (true)
						{
							switch (num ^ 0x68307BA7)
							{
							case 4:
								break;
							case 2:
								num = 1748007846;
								continue;
							case 0:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.AddCustomControllerLayout();
								inputLayout2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = 1748007846;
								continue;
							case 3:
							{
								int num2;
								if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									num = 1748007842;
									num2 = num;
								}
								else
								{
									num = 1748007847;
									num2 = num;
								}
								continue;
							}
							case 5:
								inputLayout2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
								num = 1748007845;
								continue;
							default:
							{
								inputLayout.id = inputLayout2.id;
								int index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputLayout2);
								P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = inputLayout;
								return inputLayout;
							}
							}
							break;
						}
					}
				}

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> cdruiqRKuTPVgScUryLAXTHQUQp(ControllerType P_0)
				{
					switch (P_0)
					{
					default:
						while (true)
						{
							int num = 1367801840;
							while (true)
							{
								switch (num ^ 0x5186FFF3)
								{
								case 0:
									break;
								case 3:
									goto IL_0036;
								default:
									goto end_IL_0014;
								case 1:
									throw new NotImplementedException();
								}
								break;
								IL_0036:
								if (P_0 != ControllerType.Custom)
								{
									num = 1367801842;
									continue;
								}
								return mwChnmOETAyyCvvuAlqkwXDYeNc;
							}
							continue;
							end_IL_0014:
							break;
						}
						goto case ControllerType.Keyboard;
					case ControllerType.Keyboard:
						return JxDjicVKyEMuKcjzXecrKRysDayS;
					case ControllerType.Mouse:
						return ZoeEsMhgrIVKMSOxpgqDZhOysyAT;
					case ControllerType.Joystick:
						return tOFFRlDtGUJxWietCdmiDsRFAEoq;
					}
				}

				public CustomController_Editor HeafXSRuqvaxCOKftMHgnwnusNC(htyiGeTIlIuunxGqoEdPhWYaYxJo<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
					{
						goto IL_0014;
					}
					goto IL_0044;
					IL_0014:
					int num = -597564571;
					goto IL_0019;
					IL_0019:
					CustomController_Editor customController_Editor2 = default(CustomController_Editor);
					while (true)
					{
						switch (num ^ -597564569)
						{
						case 0:
							break;
						case 2:
							customController_Editor2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
							num = -597564572;
							continue;
						case 1:
							goto IL_0044;
						default:
						{
							customController_Editor.id = customController_Editor2.id;
							int index = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(customController_Editor2);
							P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = customController_Editor;
							return customController_Editor;
						}
						}
						break;
					}
					goto IL_0014;
					IL_0044:
					VSIQlSXoGrtTSUPbSmfBclKbHBB.AddCustomController();
					customController_Editor2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
					num = -597564572;
					goto IL_0019;
				}

				public ControllerMapLayoutManager_RuleSet_Editor oADHwGhNnkWIJNsuZHUBJLtnNbJB(htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					BucLYabkFeBFxgsioofQcoabmrm bucLYabkFeBFxgsioofQcoabmrm = new BucLYabkFeBFxgsioofQcoabmrm();
					int num6 = default(int);
					int num7 = default(int);
					int num8 = default(int);
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2 = default(ControllerMapLayoutManager_RuleSet_Editor);
					int num4 = default(int);
					object[] array = default(object[]);
					ControllerType controllerType2 = default(ControllerType);
					UndgJubrnuxqXWvAffAYzcDaGFLt undgJubrnuxqXWvAffAYzcDaGFLt = default(UndgJubrnuxqXWvAffAYzcDaGFLt);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = default(ControllerMapLayoutManager_Rule_Editor);
					List<int> list2 = default(List<int>);
					int num11 = default(int);
					int num10 = default(int);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = default(ControllerMapLayoutManager_Rule_Editor);
					ESGWFEsKpDjSasoHSVBnUeUaEyFb eSGWFEsKpDjSasoHSVBnUeUaEyFb = default(ESGWFEsKpDjSasoHSVBnUeUaEyFb);
					int num3 = default(int);
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = default(ControllerMapLayoutManager_RuleSet_Editor);
					ControllerType controllerType = default(ControllerType);
					UnpsSLapeoruigQjgInEkhMUCsX unpsSLapeoruigQjgInEkhMUCsX = default(UnpsSLapeoruigQjgInEkhMUCsX);
					List<RcUTquXHCAvyGaPBfMLfcnmCCaP> cqLxuNvQSBdAMUNikIivkBCWkLm = default(List<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = default(ControllerMapLayoutManager_Rule_Editor);
					int index = default(int);
					int num5 = default(int);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					while (true)
					{
						int num = -677854183;
						while (true)
						{
							switch (num ^ -677854186)
							{
							case 38:
								break;
							case 30:
								num6++;
								num = -677854154;
								continue;
							case 14:
							{
								int num9;
								if (num7 < num8)
								{
									num = -677854185;
									num9 = num;
								}
								else
								{
									num = -677854191;
									num9 = num;
								}
								continue;
							}
							case 7:
								if (bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									controllerMapLayoutManager_RuleSet_Editor2 = bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
									num = -677854197;
									continue;
								}
								goto case 37;
							case 24:
								num = -677854184;
								continue;
							case 15:
								bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
								num = -677854207;
								continue;
							case 13:
								num4++;
								num = -677854201;
								continue;
							case 28:
								array[1] = controllerType2;
								array[2] = " Layout Id found for old id: ";
								array[3] = undgJubrnuxqXWvAffAYzcDaGFLt.xbZRoYTggiqnHjvvautXHjWPbwq;
								num = -677854182;
								continue;
							case 31:
								if (controllerMapLayoutManager_Rule_Editor3.categoryIds != null)
								{
									list2 = new List<int>();
									num11 = ((controllerMapLayoutManager_Rule_Editor3.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor3.categoryIds.Count : 0);
									num10 = 0;
									num = -677854195;
									continue;
								}
								goto case 13;
							case 35:
							{
								int num13;
								if (controllerMapLayoutManager_Rule_Editor == null)
								{
									num = -677854203;
									num13 = num;
								}
								else
								{
									num = -677854153;
									num13 = num;
								}
								continue;
							}
							case 19:
								num7++;
								num = -677854184;
								continue;
							case 18:
								undgJubrnuxqXWvAffAYzcDaGFLt = new UndgJubrnuxqXWvAffAYzcDaGFLt();
								undgJubrnuxqXWvAffAYzcDaGFLt.eArEAgVImvbIGBrGKlfNbYorlfN = bucLYabkFeBFxgsioofQcoabmrm;
								undgJubrnuxqXWvAffAYzcDaGFLt.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								num = -677854156;
								continue;
							case 12:
								Logger.LogError(string.Concat(array));
								num = -677854200;
								continue;
							case 5:
								num10++;
								num = -677854208;
								continue;
							case 16:
								eSGWFEsKpDjSasoHSVBnUeUaEyFb = new ESGWFEsKpDjSasoHSVBnUeUaEyFb();
								eSGWFEsKpDjSasoHSVBnUeUaEyFb.eArEAgVImvbIGBrGKlfNbYorlfN = bucLYabkFeBFxgsioofQcoabmrm;
								num = -677854178;
								continue;
							case 22:
								if (num10 >= num11)
								{
									controllerMapLayoutManager_Rule_Editor3.categoryIds = list2;
									num = -677854181;
									continue;
								}
								goto case 16;
							case 25:
								num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
								num4 = 0;
								num = -677854201;
								continue;
							case 39:
								if (controllerType == ControllerType.Custom)
								{
									unpsSLapeoruigQjgInEkhMUCsX = new UnpsSLapeoruigQjgInEkhMUCsX();
									unpsSLapeoruigQjgInEkhMUCsX.eArEAgVImvbIGBrGKlfNbYorlfN = bucLYabkFeBFxgsioofQcoabmrm;
									unpsSLapeoruigQjgInEkhMUCsX.TJIgXNvoSVJXczwAANQkpnqJerC = this;
									cqLxuNvQSBdAMUNikIivkBCWkLm = CqLxuNvQSBdAMUNikIivkBCWkLm;
									num = -677854146;
									continue;
								}
								goto case 19;
							case 10:
								Logger.LogError("No new Map Category Id found for old id: " + eSGWFEsKpDjSasoHSVBnUeUaEyFb.xbZRoYTggiqnHjvvautXHjWPbwq);
								num = -677854189;
								continue;
							case 36:
								list2.Add(rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv);
								num = -677854189;
								continue;
							case 23:
								controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
								num = -677854193;
								continue;
							case 11:
							{
								controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[num4];
								int num15;
								if (controllerMapLayoutManager_Rule_Editor3 != null)
								{
									num = -677854199;
									num15 = num;
								}
								else
								{
									num = -677854181;
									num15 = num;
								}
								continue;
							}
							case 34:
							{
								controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[num6];
								int num14;
								if (controllerMapLayoutManager_Rule_Editor2 != null)
								{
									num = -677854196;
									num14 = num;
								}
								else
								{
									num = -677854200;
									num14 = num;
								}
								continue;
							}
							case 21:
								controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
								index = bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
								num = -677854177;
								continue;
							case 8:
								eSGWFEsKpDjSasoHSVBnUeUaEyFb.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								num = -677854192;
								continue;
							case 32:
								if (num6 >= num5)
								{
									num8 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
									num7 = 0;
									num = -677854194;
									continue;
								}
								goto case 18;
							case 3:
								controllerMapLayoutManager_Rule_Editor2.layoutId = rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv;
								num = -677854200;
								continue;
							case 4:
								num = -677854154;
								continue;
							case 0:
								controllerMapLayoutManager_Rule_Editor.controllerSetSelector.customControllerSourceId = rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv;
								num = -677854203;
								continue;
							case 6:
								eSGWFEsKpDjSasoHSVBnUeUaEyFb.xbZRoYTggiqnHjvvautXHjWPbwq = controllerMapLayoutManager_Rule_Editor3.categoryIds[num10];
								rcUTquXHCAvyGaPBfMLfcnmCCaP3 = lGfBjiWXRzewPZnfqILeCrKIDvc.Find(eSGWFEsKpDjSasoHSVBnUeUaEyFb.powfQIteFeSdaQfAlRkBDfmhpjQ);
								num = -677854188;
								continue;
							case 2:
							{
								int num12;
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null)
								{
									num = -677854158;
									num12 = num;
								}
								else
								{
									num = -677854180;
									num12 = num;
								}
								continue;
							}
							case 20:
								controllerType = controllerMapLayoutManager_Rule_Editor.controllerSetSelector.controllerType;
								num = -677854159;
								continue;
							case 29:
								num = -677854205;
								continue;
							case 37:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.AddControllerMapLayoutManagerRuleSet();
								controllerMapLayoutManager_RuleSet_Editor2 = bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = -677854205;
								continue;
							case 1:
								controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[num7];
								num = -677854155;
								continue;
							case 27:
								num = -677854208;
								continue;
							case 40:
								unpsSLapeoruigQjgInEkhMUCsX.xbZRoYTggiqnHjvvautXHjWPbwq = controllerMapLayoutManager_Rule_Editor.controllerSetSelector.customControllerSourceId;
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = cqLxuNvQSBdAMUNikIivkBCWkLm.Find(unpsSLapeoruigQjgInEkhMUCsX.wfPOBlKHNmjHdqOOYWhYuAFtCuM);
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2 == null)
								{
									controllerMapLayoutManager_Rule_Editor.controllerSetSelector.customControllerSourceId = -1;
									Logger.LogError("No new Custom Controller found for old id: " + unpsSLapeoruigQjgInEkhMUCsX.xbZRoYTggiqnHjvvautXHjWPbwq);
									num = -677854203;
									continue;
								}
								goto case 0;
							case 17:
								if (num4 >= num3)
								{
									num5 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
									num6 = 0;
									num = -677854190;
									continue;
								}
								goto case 11;
							case 26:
							{
								if (controllerMapLayoutManager_Rule_Editor2.layoutId <= 0)
								{
									goto case 30;
								}
								controllerType2 = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
								List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list = qLcgTUNRASzVuyeaicCnLfUsCBu(controllerType2);
								undgJubrnuxqXWvAffAYzcDaGFLt.xbZRoYTggiqnHjvvautXHjWPbwq = controllerMapLayoutManager_Rule_Editor2.layoutId;
								rcUTquXHCAvyGaPBfMLfcnmCCaP = list.Find(undgJubrnuxqXWvAffAYzcDaGFLt.LShppqWWCPaJcnWtGLAEbTsRPdE);
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP == null)
								{
									controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
									array = new object[4] { "No new ", null, null, null };
									num = -677854198;
									continue;
								}
								goto case 3;
							}
							case 33:
							{
								int num2;
								if (controllerMapLayoutManager_Rule_Editor.controllerSetSelector != null)
								{
									num = -677854206;
									num2 = num;
								}
								else
								{
									num = -677854203;
									num2 = num;
								}
								continue;
							}
							default:
								bucLYabkFeBFxgsioofQcoabmrm.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = controllerMapLayoutManager_RuleSet_Editor;
								return controllerMapLayoutManager_RuleSet_Editor;
							}
							break;
						}
					}
				}

				public ControllerMapEnabler_RuleSet_Editor AJfACGzHvzQJzOQYNiGEtSlRHQZ(htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					HbGkmtCwmBzaLTHMzFxvYQguvc hbGkmtCwmBzaLTHMzFxvYQguvc = new HbGkmtCwmBzaLTHMzFxvYQguvc();
					hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
					int num5 = default(int);
					int num6 = default(int);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = default(ControllerMapEnabler_Rule_Editor);
					List<int> list = default(List<int>);
					RNwTsGyKhviQRneSUwmrecJbZmn rNwTsGyKhviQRneSUwmrecJbZmn = default(RNwTsGyKhviQRneSUwmrecJbZmn);
					List<int> list3 = default(List<int>);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					bTonhfPFyrwFASqCTHhpdlwGwst bTonhfPFyrwFASqCTHhpdlwGwst2 = default(bTonhfPFyrwFASqCTHhpdlwGwst);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = default(ControllerMapEnabler_Rule_Editor);
					int num8 = default(int);
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = default(ControllerMapEnabler_RuleSet_Editor);
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2 = default(ControllerMapEnabler_RuleSet_Editor);
					int index = default(int);
					int num13 = default(int);
					int num12 = default(int);
					int num10 = default(int);
					ControllerType controllerType = default(ControllerType);
					List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list2 = default(List<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
					object[] array = default(object[]);
					int num2 = default(int);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					int num3 = default(int);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = default(ControllerMapEnabler_Rule_Editor);
					vcVUMuXthBRGGRZeouXsmJxhhHC vcVUMuXthBRGGRZeouXsmJxhhHC2 = default(vcVUMuXthBRGGRZeouXsmJxhhHC);
					int num11 = default(int);
					while (true)
					{
						int num = 1863251012;
						while (true)
						{
							int num9;
							switch (num ^ 0x6F0EF446)
							{
							case 37:
								break;
							case 6:
								if (num5 >= num6)
								{
									controllerMapEnabler_Rule_Editor.layoutIds = list;
									num = 1863251022;
									continue;
								}
								goto case 26;
							case 26:
								rNwTsGyKhviQRneSUwmrecJbZmn = new RNwTsGyKhviQRneSUwmrecJbZmn();
								rNwTsGyKhviQRneSUwmrecJbZmn.ImkLKknnoOMcNcBvkUbAyJwezye = hbGkmtCwmBzaLTHMzFxvYQguvc;
								num = 1863251021;
								continue;
							case 33:
								list3.Add(rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv);
								num = 1863251039;
								continue;
							case 12:
								num5++;
								num = 1863251008;
								continue;
							case 20:
								bTonhfPFyrwFASqCTHhpdlwGwst2 = new bTonhfPFyrwFASqCTHhpdlwGwst();
								bTonhfPFyrwFASqCTHhpdlwGwst2.ImkLKknnoOMcNcBvkUbAyJwezye = hbGkmtCwmBzaLTHMzFxvYQguvc;
								bTonhfPFyrwFASqCTHhpdlwGwst2.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								bTonhfPFyrwFASqCTHhpdlwGwst2.xbZRoYTggiqnHjvvautXHjWPbwq = controllerMapEnabler_Rule_Editor2.categoryIds[num8];
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = lGfBjiWXRzewPZnfqILeCrKIDvc.Find(bTonhfPFyrwFASqCTHhpdlwGwst2.dqRITUABQFqUKTsFasUHzhkCxFz);
								num = 1863251017;
								continue;
							case 27:
								controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
								index = hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(controllerMapEnabler_RuleSet_Editor2);
								num = 1863251044;
								continue;
							case 28:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.AddControllerMapEnablerRuleSet();
								controllerMapEnabler_RuleSet_Editor2 = hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = 1863251037;
								continue;
							case 9:
								num6 = ((controllerMapEnabler_Rule_Editor.layoutIds != null) ? controllerMapEnabler_Rule_Editor.layoutIds.Count : 0);
								num5 = 0;
								num = 1863251031;
								continue;
							case 5:
								if (num8 >= controllerMapEnabler_Rule_Editor2.categoryIds.Count)
								{
									controllerMapEnabler_Rule_Editor2.categoryIds = list3;
									num = 1863251038;
									continue;
								}
								goto case 20;
							case 38:
							{
								int num15;
								if (num13 >= num12)
								{
									num = 1863251009;
									num15 = num;
								}
								else
								{
									num = 1863251035;
									num15 = num;
								}
								continue;
							}
							case 11:
								rNwTsGyKhviQRneSUwmrecJbZmn.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								rNwTsGyKhviQRneSUwmrecJbZmn.xbZRoYTggiqnHjvvautXHjWPbwq = controllerMapEnabler_Rule_Editor.layoutIds[num5];
								num = 1863251010;
								continue;
							case 8:
								num10++;
								num = 1863251046;
								continue;
							case 35:
								controllerType = controllerMapEnabler_Rule_Editor.controllerSetSelector.controllerType;
								list2 = qLcgTUNRASzVuyeaicCnLfUsCBu(controllerType);
								list = new List<int>();
								num = 1863251023;
								continue;
							case 1:
								array = new object[4];
								num = 1863251020;
								continue;
							case 3:
								num = 1863251018;
								continue;
							case 25:
								num8++;
								num = 1863251011;
								continue;
							case 21:
								controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[num2];
								if (controllerMapEnabler_Rule_Editor2 != null && controllerMapEnabler_Rule_Editor2.categoryIds != null)
								{
									list3 = new List<int>();
									num8 = 0;
									num = 1863251011;
									continue;
								}
								goto case 24;
							case 14:
								list.Add(rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv);
								num = 1863251018;
								continue;
							case 2:
								controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
								num3 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
								num = 1863251030;
								continue;
							case 7:
								if (hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									controllerMapEnabler_RuleSet_Editor2 = hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
									num = 1863251037;
									continue;
								}
								goto case 28;
							case 36:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP3 == null)
								{
									controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
									num = 1863251024;
									continue;
								}
								goto case 30;
							case 31:
								num9 = 0;
								goto IL_039c;
							case 24:
								num2++;
								num = 1863251025;
								continue;
							case 17:
								num = 1863251008;
								continue;
							case 29:
								controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[num13];
								if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector != null)
								{
									ControllerType controllerType2 = controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType;
									if (controllerType2 == ControllerType.Custom)
									{
										vcVUMuXthBRGGRZeouXsmJxhhHC2 = new vcVUMuXthBRGGRZeouXsmJxhhHC();
										vcVUMuXthBRGGRZeouXsmJxhhHC2.ImkLKknnoOMcNcBvkUbAyJwezye = hbGkmtCwmBzaLTHMzFxvYQguvc;
										vcVUMuXthBRGGRZeouXsmJxhhHC2.TJIgXNvoSVJXczwAANQkpnqJerC = this;
										List<RcUTquXHCAvyGaPBfMLfcnmCCaP> cqLxuNvQSBdAMUNikIivkBCWkLm = CqLxuNvQSBdAMUNikIivkBCWkLm;
										vcVUMuXthBRGGRZeouXsmJxhhHC2.xbZRoYTggiqnHjvvautXHjWPbwq = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
										rcUTquXHCAvyGaPBfMLfcnmCCaP3 = cqLxuNvQSBdAMUNikIivkBCWkLm.Find(vcVUMuXthBRGGRZeouXsmJxhhHC2.bbzlFypbegawyuFZXDobxsaOOCT);
										num = 1863251042;
										continue;
									}
								}
								goto case 18;
							case 32:
								if (num10 >= num11)
								{
									num12 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
									num13 = 0;
									num = 1863251040;
									continue;
								}
								goto case 13;
							case 19:
								if (controllerMapEnabler_RuleSet_Editor.rules != null)
								{
									num9 = controllerMapEnabler_RuleSet_Editor.rules.Count;
									goto IL_039c;
								}
								num = 1863251033;
								continue;
							case 0:
								Logger.LogError(string.Concat(array));
								num = 1863251013;
								continue;
							case 10:
								array[0] = "No new ";
								array[1] = controllerType;
								array[2] = " Layout Id found for old id: ";
								array[3] = rNwTsGyKhviQRneSUwmrecJbZmn.xbZRoYTggiqnHjvvautXHjWPbwq;
								num = 1863251014;
								continue;
							case 18:
								num13++;
								num = 1863251040;
								continue;
							case 30:
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv;
								num = 1863251028;
								continue;
							case 15:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2 == null)
								{
									Logger.LogError("No new Map Category Id found for old id: " + bTonhfPFyrwFASqCTHhpdlwGwst2.xbZRoYTggiqnHjvvautXHjWPbwq);
									num = 1863251039;
									continue;
								}
								goto case 33;
							case 16:
								num2 = 0;
								num = 1863251025;
								continue;
							case 13:
								controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[num10];
								if (controllerMapEnabler_Rule_Editor != null)
								{
									int num14;
									if (controllerMapEnabler_Rule_Editor.layoutIds != null)
									{
										num = 1863251045;
										num14 = num;
									}
									else
									{
										num = 1863251022;
										num14 = num;
									}
									continue;
								}
								goto case 8;
							case 22:
								Logger.LogError("No new Custom Controller found for old id: " + vcVUMuXthBRGGRZeouXsmJxhhHC2.xbZRoYTggiqnHjvvautXHjWPbwq);
								num = 1863251028;
								continue;
							case 4:
							{
								rcUTquXHCAvyGaPBfMLfcnmCCaP = list2.Find(rNwTsGyKhviQRneSUwmrecJbZmn.SrPCRqkLWLneETpUDIbCIDjKMhE);
								int num7;
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP == null)
								{
									num = 1863251015;
									num7 = num;
								}
								else
								{
									num = 1863251016;
									num7 = num;
								}
								continue;
							}
							case 23:
							{
								int num4;
								if (num2 >= num3)
								{
									num = 1863251029;
									num4 = num;
								}
								else
								{
									num = 1863251027;
									num4 = num;
								}
								continue;
							}
							default:
								{
									hbGkmtCwmBzaLTHMzFxvYQguvc.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = controllerMapEnabler_RuleSet_Editor;
									return controllerMapEnabler_RuleSet_Editor;
								}
								IL_039c:
								num11 = num9;
								num10 = 0;
								num = 1863251046;
								continue;
							}
							break;
						}
					}
				}

				public Player_Editor VPIugcFWXKRiEMYGQWemMZSAsrp(htyiGeTIlIuunxGqoEdPhWYaYxJo<Player_Editor> P_0)
				{
					PTCmFQWXzkJRQMMymGMmfAeHvhpb pTCmFQWXzkJRQMMymGMmfAeHvhpb = new PTCmFQWXzkJRQMMymGMmfAeHvhpb();
					pTCmFQWXzkJRQMMymGMmfAeHvhpb.TJIgXNvoSVJXczwAANQkpnqJerC = this;
					pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
					Player_Editor player_Editor = JsonTools.Clone(pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
					Action<List<Player_Editor.Mapping>, List<RcUTquXHCAvyGaPBfMLfcnmCCaP>> action = pTCmFQWXzkJRQMMymGMmfAeHvhpb.cLMUjocJrneWlWDTWGNETWDhFiU;
					action(player_Editor.defaultKeyboardMaps, JxDjicVKyEMuKcjzXecrKRysDayS);
					action(player_Editor.defaultMouseMaps, ZoeEsMhgrIVKMSOxpgqDZhOysyAT);
					pllrWCdNAOwufpfkdkCKbMWAYMv pllrWCdNAOwufpfkdkCKbMWAYMv2 = default(pllrWCdNAOwufpfkdkCKbMWAYMv);
					Player_Editor.RuleSetMapping ruleSetMapping2 = default(Player_Editor.RuleSetMapping);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					Player_Editor player_Editor2 = default(Player_Editor);
					List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
					int num3 = default(int);
					VIDIgnSPHEYuebQaEmXuRkQODJf vIDIgnSPHEYuebQaEmXuRkQODJf = default(VIDIgnSPHEYuebQaEmXuRkQODJf);
					Player_Editor.RuleSetMapping ruleSetMapping = default(Player_Editor.RuleSetMapping);
					List<Player_Editor.RuleSetMapping> ruleSets2 = default(List<Player_Editor.RuleSetMapping>);
					int num5 = default(int);
					List<Player_Editor.RuleSetMapping> list = default(List<Player_Editor.RuleSetMapping>);
					List<Player_Editor.RuleSetMapping> list2 = default(List<Player_Editor.RuleSetMapping>);
					ZKtYpqYzpnCuDziIvLCNffElxUa zKtYpqYzpnCuDziIvLCNffElxUa = default(ZKtYpqYzpnCuDziIvLCNffElxUa);
					int num2 = default(int);
					Player_Editor player_Editor3 = default(Player_Editor);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					while (true)
					{
						int num = -45047740;
						while (true)
						{
							switch (num ^ -45047742)
							{
							case 33:
								break;
							case 35:
							{
								pllrWCdNAOwufpfkdkCKbMWAYMv2.IcfehugnHVBDSlLvDDweqELIXNqm = ruleSetMapping2.id;
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = JjfaTLyWDOdfEyfBORsPCHrWwq.Find(pllrWCdNAOwufpfkdkCKbMWAYMv2.qxKMqUrOnspStdBDFFFLlbIALLY);
								int num6;
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2 == null)
								{
									num = -45047719;
									num6 = num;
								}
								else
								{
									num = -45047717;
									num6 = num;
								}
								continue;
							}
							case 3:
								player_Editor2 = pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = -45047712;
								continue;
							case 32:
							{
								ruleSetMapping2 = ruleSets[num3];
								int num8;
								if (ruleSetMapping2 != null)
								{
									num = -45047711;
									num8 = num;
								}
								else
								{
									num = -45047716;
									num8 = num;
								}
								continue;
							}
							case 14:
								xuGJwufdhhEmcaPMATcJvyPNdayF = yOyOiWhprGBEjEJUnPeLlEbsQOqD;
								num = -45047738;
								continue;
							case 6:
								action(player_Editor.defaultJoystickMaps, tOFFRlDtGUJxWietCdmiDsRFAEoq);
								num = -45047742;
								continue;
							case 8:
								num = -45047712;
								continue;
							case 30:
								num3++;
								num = -45047725;
								continue;
							case 28:
								vIDIgnSPHEYuebQaEmXuRkQODJf = new VIDIgnSPHEYuebQaEmXuRkQODJf();
								vIDIgnSPHEYuebQaEmXuRkQODJf.SoEhKrmxLLhRNCtXhPjVBziOIwb = pTCmFQWXzkJRQMMymGMmfAeHvhpb;
								vIDIgnSPHEYuebQaEmXuRkQODJf.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								ruleSetMapping = ruleSets2[num5];
								num = -45047744;
								continue;
							case 17:
								if (num3 >= ruleSets.Count)
								{
									player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
									list2 = new List<Player_Editor.RuleSetMapping>();
									num = -45047741;
									continue;
								}
								goto case 19;
							case 9:
								zKtYpqYzpnCuDziIvLCNffElxUa = new ZKtYpqYzpnCuDziIvLCNffElxUa();
								num = -45047730;
								continue;
							case 34:
								player_Editor.id = player_Editor2.id;
								num = -45047726;
								continue;
							case 7:
							{
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = CqLxuNvQSBdAMUNikIivkBCWkLm.Find(zKtYpqYzpnCuDziIvLCNffElxUa.pmsFGkkMftgeEeMvHhFntzewkTu);
								zKtYpqYzpnCuDziIvLCNffElxUa.rAkUsdTnKPsjogOHmtoXScXdcVa.sourceId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num2++;
								num = -45047713;
								continue;
							}
							case 12:
								zKtYpqYzpnCuDziIvLCNffElxUa.SoEhKrmxLLhRNCtXhPjVBziOIwb = pTCmFQWXzkJRQMMymGMmfAeHvhpb;
								zKtYpqYzpnCuDziIvLCNffElxUa.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								zKtYpqYzpnCuDziIvLCNffElxUa.rAkUsdTnKPsjogOHmtoXScXdcVa = player_Editor.startingCustomControllers[num2];
								num = -45047739;
								continue;
							case 13:
								if (num5 < ruleSets2.Count)
								{
									goto case 28;
								}
								player_Editor.controllerMapEnablerSettings.ruleSets = list2;
								if (pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									player_Editor2 = pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
									player_Editor3 = JsonTools.Clone(player_Editor);
									player_Editor3.defaultKeyboardMaps.Clear();
									player_Editor3.defaultMouseMaps.Clear();
									player_Editor3.defaultJoystickMaps.Clear();
									player_Editor3.defaultCustomControllerMaps.Clear();
									player_Editor3.startingCustomControllers.Clear();
									num = -45047724;
									continue;
								}
								goto case 31;
							case 0:
								action(player_Editor.defaultCustomControllerMaps, mwChnmOETAyyCvvuAlqkwXDYeNc);
								num2 = 0;
								num = -45047713;
								continue;
							case 27:
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + pllrWCdNAOwufpfkdkCKbMWAYMv2.IcfehugnHVBDSlLvDDweqELIXNqm);
								num = -45047716;
								continue;
							case 2:
							{
								int num7;
								if (ruleSetMapping == null)
								{
									num = -45047736;
									num7 = num;
								}
								else
								{
									num = -45047723;
									num7 = num;
								}
								continue;
							}
							case 16:
							{
								int index = pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(player_Editor2);
								pTCmFQWXzkJRQMMymGMmfAeHvhpb.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = player_Editor;
								num = -45047731;
								continue;
							}
							case 18:
								num5 = 0;
								num = -45047720;
								continue;
							case 5:
							{
								List<Player_Editor.CreateControllerInfo> startingCustomControllers = player_Editor2.startingCustomControllers;
								List<Player_Editor.CreateControllerInfo> startingCustomControllers2 = player_Editor.startingCustomControllers;
								List<Player_Editor.CreateControllerInfo> startingCustomControllers3 = player_Editor3.startingCustomControllers;
								if (qQrafyZHpKBrhyFwgkfmUbmljdzd == null)
								{
									qQrafyZHpKBrhyFwgkfmUbmljdzd = PSmEcfYPFcgGdgVoTodfiHJkFiTl;
								}
								KHsyAUIsBgNjqabmJBWuJbuuYio(startingCustomControllers, startingCustomControllers2, startingCustomControllers3, qQrafyZHpKBrhyFwgkfmUbmljdzd);
								player_Editor = player_Editor3;
								num = -45047734;
								continue;
							}
							case 26:
								num = -45047729;
								continue;
							case 10:
								num5++;
								num = -45047729;
								continue;
							case 22:
							{
								int num4;
								if (xuGJwufdhhEmcaPMATcJvyPNdayF == null)
								{
									num = -45047732;
									num4 = num;
								}
								else
								{
									num = -45047738;
									num4 = num;
								}
								continue;
							}
							case 4:
							{
								Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = xuGJwufdhhEmcaPMATcJvyPNdayF;
								KHsyAUIsBgNjqabmJBWuJbuuYio(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
								KHsyAUIsBgNjqabmJBWuJbuuYio(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
								KHsyAUIsBgNjqabmJBWuJbuuYio(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
								KHsyAUIsBgNjqabmJBWuJbuuYio(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
								num = -45047737;
								continue;
							}
							case 11:
								num3 = 0;
								num = -45047725;
								continue;
							case 25:
								ruleSetMapping2 = ruleSetMapping2.Clone();
								ruleSetMapping2.id = rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv;
								list.Add(ruleSetMapping2);
								num = -45047716;
								continue;
							case 20:
								num = -45047736;
								continue;
							case 31:
								VSIQlSXoGrtTSUPbSmfBclKbHBB.AddPlayer();
								num = -45047743;
								continue;
							case 1:
								ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
								num = -45047728;
								continue;
							case 23:
								vIDIgnSPHEYuebQaEmXuRkQODJf.IcfehugnHVBDSlLvDDweqELIXNqm = ruleSetMapping.id;
								rcUTquXHCAvyGaPBfMLfcnmCCaP = OBVyQAJOtjQKfACiROdUQjRjawQ.Find(vIDIgnSPHEYuebQaEmXuRkQODJf.DtaIVXaxmpXIwfVTmhZiGCqyfuT);
								num = -45047718;
								continue;
							case 21:
								ruleSetMapping = ruleSetMapping.Clone();
								ruleSetMapping.id = rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv;
								list2.Add(ruleSetMapping);
								num = -45047736;
								continue;
							case 19:
								pllrWCdNAOwufpfkdkCKbMWAYMv2 = new pllrWCdNAOwufpfkdkCKbMWAYMv();
								pllrWCdNAOwufpfkdkCKbMWAYMv2.SoEhKrmxLLhRNCtXhPjVBziOIwb = pTCmFQWXzkJRQMMymGMmfAeHvhpb;
								pllrWCdNAOwufpfkdkCKbMWAYMv2.TJIgXNvoSVJXczwAANQkpnqJerC = this;
								num = -45047710;
								continue;
							case 24:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP == null)
								{
									Logger.LogError("No new Controller Map Enabler Set found for old id: " + vIDIgnSPHEYuebQaEmXuRkQODJf.IcfehugnHVBDSlLvDDweqELIXNqm);
									num = -45047722;
									continue;
								}
								goto case 21;
							case 29:
								if (num2 >= player_Editor.startingCustomControllers.Count)
								{
									list = new List<Player_Editor.RuleSetMapping>();
									ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
									num = -45047735;
									continue;
								}
								goto case 9;
							default:
								return player_Editor;
							}
							break;
						}
					}
				}

				private static int yOyOiWhprGBEjEJUnPeLlEbsQOqD(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num].categoryId == P_0.categoryId && P_1[num].layoutId == P_0.layoutId)
							{
								num2 = -2060300490;
							}
							else
							{
								num++;
								num2 = -2060300491;
							}
							while (true)
							{
								switch (num2 ^ -2060300491)
								{
								case 2:
									num2 = -2060300492;
									continue;
								case 1:
									break;
								case 3:
									return num;
								default:
									goto end_IL_0026;
								}
								break;
							}
							continue;
							end_IL_0026:
							break;
						}
					}
					return -1;
				}

				private static int PSmEcfYPFcgGdgVoTodfiHJkFiTl(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							if (P_1[num].sourceId == P_0.sourceId)
							{
								return num;
							}
							num++;
							int num2 = 486087823;
							while (true)
							{
								switch (num2 ^ 0x1CF91C8F)
								{
								case 2:
									num2 = 486087822;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0022;
								}
								break;
							}
							continue;
							end_IL_0022:
							break;
						}
					}
					return -1;
				}
			}

			private sealed class hjDURaqEGAFGzQwkLiNiAbZizfI
			{
				public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

				public List<int> uzzTLUjgfTiHdEhjkGDnpnRIUSv;

				public InputMapCategory UVDRRbjbxSDDbepRytVgFFwfVip(htyiGeTIlIuunxGqoEdPhWYaYxJo<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.WAXRrBwldppmaOlJLDIYCUmBYaD);
					InputMapCategory inputMapCategory2;
					if (P_0.snqztkQepdQnGBnhenGsIbqrmFF)
					{
						inputMapCategory2 = P_0.NvWvpLcivPwaRMszPLXmXxMLzyb;
						goto IL_001b;
					}
					goto IL_007c;
					IL_007c:
					TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.AddMapCategory();
					inputMapCategory2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
					int num = 1101547592;
					goto IL_0020;
					IL_001b:
					num = 1101547596;
					goto IL_0020;
					IL_0020:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x41A8484D)
						{
						case 4:
							break;
						case 5:
							num2 = P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(inputMapCategory2);
							num = 1101547599;
							continue;
						case 2:
							if (P_0.QiMDfljswXynnIIhmOOTitPrUQke == RcUTquXHCAvyGaPBfMLfcnmCCaP.VaqfwhdabaVjMHRIwcNHnsBJfXqg.mgYrBQfuwOpdNKDSIbFbRLGIiFP)
							{
								uzzTLUjgfTiHdEhjkGDnpnRIUSv.Add(num2);
								num = 1101547597;
								continue;
							}
							goto default;
						case 1:
							num = 1101547592;
							continue;
						case 3:
							goto IL_007c;
						default:
							inputMapCategory.id = inputMapCategory2.id;
							P_0.ngVMhuTMwJNCnlEAbYZPSBJKCKE[num2] = inputMapCategory;
							return inputMapCategory;
						}
						break;
					}
					goto IL_001b;
				}
			}

			private sealed class KRVQtNOElMQefFXbCqcRqKhvuSE
			{
				public hjDURaqEGAFGzQwkLiNiAbZizfI pddFjipsnIJtsUtCmTRxVcwEaHA;

				public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

				public int mgYrBQfuwOpdNKDSIbFbRLGIiFP;

				public bool wNZFyYBzYDZPCPEExLOzWKTeEon(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
				{
					return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == mgYrBQfuwOpdNKDSIbFbRLGIiFP;
				}
			}

			private sealed class wcUXXDjaDiyFescovjmwAPUNfJJ
			{
				private sealed class uSpCnEhJmHhKicfJjUXsuMQNThMh
				{
					public wcUXXDjaDiyFescovjmwAPUNfJJ ZEEXPEiUUAKXecqxThUeNJjHeNV;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor rAkUsdTnKPsjogOHmtoXScXdcVa;

					public bool DBxQJNBSBFLYkCttJjCEIPIeJik(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.categoryId;
					}

					public bool pVONkkBNqHdAUevVAsugjQNzsEO(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.layoutId;
					}
				}

				private sealed class cKyzvPJQIcEiRrqCvlmZVYHgOuF
				{
					public wcUXXDjaDiyFescovjmwAPUNfJJ ZEEXPEiUUAKXecqxThUeNJjHeNV;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor QdjUpOTkkdvVMYjwDhrGdDqMtalT;

					public htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;

					public bool EifBnvOtvvEORcQpPTMhAqJDLCo(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId;
					}

					public bool gHZNWsHYTfgiLbbtVodNppPUlxm(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId;
					}
				}

				private sealed class aHvOjuCUbOQGqSoMYSnGxNXryOD
				{
					public cKyzvPJQIcEiRrqCvlmZVYHgOuF TxpRcEBKoAaspUFDgqpXAmdPmJj;

					public wcUXXDjaDiyFescovjmwAPUNfJJ ZEEXPEiUUAKXecqxThUeNJjHeNV;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ActionElementMap LnGQdTkvjCFdlrhTrhGIyQCHdZz;

					public bool VWELfecMTCDTLaipodRseHnBjHqn(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TxpRcEBKoAaspUFDgqpXAmdPmJj.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId;
					}
				}

				public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> bGReLfdPyNCTgaEpmlwEMawxeRki;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> XYetBsyAgjuoAVrrBYXWgakTYWN;

				public int oXbcDtYkcGCMMQooIkyioILhXLG(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					uSpCnEhJmHhKicfJjUXsuMQNThMh uSpCnEhJmHhKicfJjUXsuMQNThMh2 = default(uSpCnEhJmHhKicfJjUXsuMQNThMh);
					Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP> predicate = default(Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					int num2 = default(int);
					while (true)
					{
						int num = 1556531494;
						while (true)
						{
							switch (num ^ 0x5CC6C927)
							{
							case 2:
								break;
							case 6:
							{
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(uSpCnEhJmHhKicfJjUXsuMQNThMh2.DBxQJNBSBFLYkCttJjCEIPIeJik);
								List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list = bGReLfdPyNCTgaEpmlwEMawxeRki;
								if (predicate == null)
								{
									predicate = uSpCnEhJmHhKicfJjUXsuMQNThMh2.pVONkkBNqHdAUevVAsugjQNzsEO;
								}
								rcUTquXHCAvyGaPBfMLfcnmCCaP = list.Find(predicate);
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null && rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].categoryId)
								{
									num = 1556531490;
									continue;
								}
								goto IL_00a4;
							}
							case 4:
								num = 1556531492;
								continue;
							case 0:
								return num2;
							case 5:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP != null && rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].layoutId)
								{
									num = 1556531495;
									continue;
								}
								goto IL_00a4;
							case 1:
								predicate = null;
								uSpCnEhJmHhKicfJjUXsuMQNThMh2 = new uSpCnEhJmHhKicfJjUXsuMQNThMh();
								uSpCnEhJmHhKicfJjUXsuMQNThMh2.ZEEXPEiUUAKXecqxThUeNJjHeNV = this;
								uSpCnEhJmHhKicfJjUXsuMQNThMh2.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								uSpCnEhJmHhKicfJjUXsuMQNThMh2.rAkUsdTnKPsjogOHmtoXScXdcVa = P_0;
								num2 = 0;
								num = 1556531491;
								continue;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 6;
								}
								IL_00a4:
								num2++;
								num = 1556531492;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor DAohaDVJsRioqnNoYrPvSASIPYL(htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> P_0)
				{
					cKyzvPJQIcEiRrqCvlmZVYHgOuF cKyzvPJQIcEiRrqCvlmZVYHgOuF2 = new cKyzvPJQIcEiRrqCvlmZVYHgOuF();
					cKyzvPJQIcEiRrqCvlmZVYHgOuF2.ZEEXPEiUUAKXecqxThUeNJjHeNV = this;
					aHvOjuCUbOQGqSoMYSnGxNXryOD aHvOjuCUbOQGqSoMYSnGxNXryOD2 = default(aHvOjuCUbOQGqSoMYSnGxNXryOD);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					int num2 = default(int);
					while (true)
					{
						int num = 195748196;
						while (true)
						{
							switch (num ^ 0xBAAE168)
							{
							case 4:
								break;
							case 10:
								aHvOjuCUbOQGqSoMYSnGxNXryOD2.TxpRcEBKoAaspUFDgqpXAmdPmJj = cKyzvPJQIcEiRrqCvlmZVYHgOuF2;
								aHvOjuCUbOQGqSoMYSnGxNXryOD2.ZEEXPEiUUAKXecqxThUeNJjHeNV = this;
								num = 195748207;
								continue;
							case 8:
							{
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT = JsonTools.Clone(cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(cKyzvPJQIcEiRrqCvlmZVYHgOuF2.EifBnvOtvvEORcQpPTMhAqJDLCo);
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = bGReLfdPyNCTgaEpmlwEMawxeRki.Find(cKyzvPJQIcEiRrqCvlmZVYHgOuF2.gHZNWsHYTfgiLbbtVodNppPUlxm);
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num = 195748202;
								continue;
							}
							case 12:
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
								num = 195748192;
								continue;
							case 14:
							{
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = TJIgXNvoSVJXczwAANQkpnqJerC.SEfshPOIrHMtnqpzbElCsLiUazVa.Find(aHvOjuCUbOQGqSoMYSnGxNXryOD2.VWELfecMTCDTLaipodRseHnBjHqn);
								aHvOjuCUbOQGqSoMYSnGxNXryOD2.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								aHvOjuCUbOQGqSoMYSnGxNXryOD2.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionCategoryId = ((TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(aHvOjuCUbOQGqSoMYSnGxNXryOD2.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId) != null) ? TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(aHvOjuCUbOQGqSoMYSnGxNXryOD2.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId).categoryId : 0);
								num = 195748203;
								continue;
							}
							case 5:
								TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.CreateKeyboardMap(cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId, cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId);
								controllerMap_Editor = cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = 195748201;
								continue;
							case 0:
								if (!cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									goto case 5;
								}
								controllerMap_Editor = cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
								controllerMap_Editor2 = JsonTools.Clone(cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT);
								controllerMap_Editor2.actionElementMaps.Clear();
								if (XYetBsyAgjuoAVrrBYXWgakTYWN == null)
								{
									XYetBsyAgjuoAVrrBYXWgakTYWN = boQvZKpsTkPAMgBkGotjPJnQFMI;
									num = 195748206;
									continue;
								}
								goto case 6;
							case 3:
								num2++;
								num = 195748195;
								continue;
							case 2:
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num2 = 0;
								num = 195748195;
								continue;
							case 6:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> xYetBsyAgjuoAVrrBYXWgakTYWN = XYetBsyAgjuoAVrrBYXWgakTYWN;
								KHsyAUIsBgNjqabmJBWuJbuuYio(controllerMap_Editor.actionElementMaps, cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps, controllerMap_Editor2.actionElementMaps, xYetBsyAgjuoAVrrBYXWgakTYWN);
								num = 195748193;
								continue;
							}
							case 9:
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT = controllerMap_Editor2;
								num = 195748201;
								continue;
							case 11:
							{
								int num3;
								if (num2 < cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps.Count)
								{
									num = 195748197;
									num3 = num;
								}
								else
								{
									num = 195748200;
									num3 = num;
								}
								continue;
							}
							case 7:
								aHvOjuCUbOQGqSoMYSnGxNXryOD2.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								aHvOjuCUbOQGqSoMYSnGxNXryOD2.LnGQdTkvjCFdlrhTrhGIyQCHdZz = cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps[num2];
								num = 195748198;
								continue;
							case 13:
								aHvOjuCUbOQGqSoMYSnGxNXryOD2 = new aHvOjuCUbOQGqSoMYSnGxNXryOD();
								num = 195748194;
								continue;
							default:
							{
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.id = controllerMap_Editor.id;
								int index = cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(controllerMap_Editor);
								cKyzvPJQIcEiRrqCvlmZVYHgOuF2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
								return cKyzvPJQIcEiRrqCvlmZVYHgOuF2.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
							}
							}
							break;
						}
					}
				}

				private static int boQvZKpsTkPAMgBkGotjPJnQFMI(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < P_1.Count)
						{
							num2 = 170476234;
							num3 = num2;
						}
						else
						{
							num2 = 170476232;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0xA2942C9)
							{
							case 0:
								num2 = 170476234;
								continue;
							case 4:
								break;
							case 2:
								if (P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								goto IL_0071;
							case 3:
								if (P_1[num]._keyboardKeyCode == P_0._keyboardKeyCode && P_1[num]._modifierKey1 == P_0._modifierKey1 && P_1[num]._modifierKey2 == P_0._modifierKey2 && P_1[num]._modifierKey3 == P_0._modifierKey3)
								{
									num2 = 170476235;
									continue;
								}
								goto IL_0071;
							default:
								{
									return -1;
								}
								IL_0071:
								num++;
								num2 = 170476237;
								continue;
							}
							break;
						}
					}
				}
			}

			private sealed class dxUqzBgbtBceCAuRLCgnfoedPAg
			{
				private sealed class vPzBaJjJvmiYqadgtBRsRCHdXcaL
				{
					public dxUqzBgbtBceCAuRLCgnfoedPAg rxnvYOzxwbrAFoSmJMTTvMmWQsR;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor rAkUsdTnKPsjogOHmtoXScXdcVa;

					public bool XCLImjEcmYBkgDYkynrHGcUSXurI(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.categoryId;
					}

					public bool YQugkByCjwAPCiEKvicFWRXzpenB(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.layoutId;
					}
				}

				private sealed class fQiaIsSkvdoFDlHtTtQSqOAmCHlI
				{
					public dxUqzBgbtBceCAuRLCgnfoedPAg rxnvYOzxwbrAFoSmJMTTvMmWQsR;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor QdjUpOTkkdvVMYjwDhrGdDqMtalT;

					public htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;

					public bool HSVwXeqdXxrYbeAcpbuwZUYRWYx(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId;
					}

					public bool ULKDDFhyxUKLPQHQbWUElRjAzUTt(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId;
					}
				}

				private sealed class JavCECFwSbQOHTYDsVGguaQvPhIz
				{
					public fQiaIsSkvdoFDlHtTtQSqOAmCHlI vHdFczsgYBzyRcqGKKozCTOtvIT;

					public dxUqzBgbtBceCAuRLCgnfoedPAg rxnvYOzxwbrAFoSmJMTTvMmWQsR;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ActionElementMap LnGQdTkvjCFdlrhTrhGIyQCHdZz;

					public bool VolyufefkVqCPqkAokmrJWsWLq(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[vHdFczsgYBzyRcqGKKozCTOtvIT.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId;
					}
				}

				public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> bGReLfdPyNCTgaEpmlwEMawxeRki;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> vmvMNXEgYVTEQzSXEsXkpnOkKkM;

				public int gVRJbGHlliwVlNBdWOpenRLgzdv(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					vPzBaJjJvmiYqadgtBRsRCHdXcaL vPzBaJjJvmiYqadgtBRsRCHdXcaL2 = new vPzBaJjJvmiYqadgtBRsRCHdXcaL();
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					int num2 = default(int);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					while (true)
					{
						int num = 1299829334;
						while (true)
						{
							switch (num ^ 0x4D79D257)
							{
							case 2:
								break;
							case 1:
								vPzBaJjJvmiYqadgtBRsRCHdXcaL2.rxnvYOzxwbrAFoSmJMTTvMmWQsR = this;
								vPzBaJjJvmiYqadgtBRsRCHdXcaL2.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								num = 1299829330;
								continue;
							case 4:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].categoryId)
								{
									num = 1299829328;
									continue;
								}
								goto IL_00f4;
							case 5:
								vPzBaJjJvmiYqadgtBRsRCHdXcaL2.rAkUsdTnKPsjogOHmtoXScXdcVa = P_0;
								num = 1299829329;
								continue;
							case 3:
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(vPzBaJjJvmiYqadgtBRsRCHdXcaL2.XCLImjEcmYBkgDYkynrHGcUSXurI);
								rcUTquXHCAvyGaPBfMLfcnmCCaP = bGReLfdPyNCTgaEpmlwEMawxeRki.Find(vPzBaJjJvmiYqadgtBRsRCHdXcaL2.YQugkByCjwAPCiEKvicFWRXzpenB);
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null)
								{
									num = 1299829331;
									continue;
								}
								goto IL_00f4;
							case 7:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP != null && rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_00f4;
							case 6:
								num2 = 0;
								num = 1299829335;
								continue;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 3;
								}
								IL_00f4:
								num2++;
								num = 1299829335;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor eBOOPBcFmiTImXeOKkQjYBjiadG(htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> P_0)
				{
					fQiaIsSkvdoFDlHtTtQSqOAmCHlI fQiaIsSkvdoFDlHtTtQSqOAmCHlI2 = new fQiaIsSkvdoFDlHtTtQSqOAmCHlI();
					JavCECFwSbQOHTYDsVGguaQvPhIz javCECFwSbQOHTYDsVGguaQvPhIz = default(JavCECFwSbQOHTYDsVGguaQvPhIz);
					int num2 = default(int);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					while (true)
					{
						int num = -1682287507;
						while (true)
						{
							switch (num ^ -1682287520)
							{
							case 0:
								break;
							case 6:
							{
								javCECFwSbQOHTYDsVGguaQvPhIz.LnGQdTkvjCFdlrhTrhGIyQCHdZz = fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps[num2];
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = TJIgXNvoSVJXczwAANQkpnqJerC.SEfshPOIrHMtnqpzbElCsLiUazVa.Find(javCECFwSbQOHTYDsVGguaQvPhIz.VolyufefkVqCPqkAokmrJWsWLq);
								javCECFwSbQOHTYDsVGguaQvPhIz.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								javCECFwSbQOHTYDsVGguaQvPhIz.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionCategoryId = ((TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(javCECFwSbQOHTYDsVGguaQvPhIz.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId) != null) ? TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(javCECFwSbQOHTYDsVGguaQvPhIz.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId).categoryId : 0);
								num2++;
								num = -1682287511;
								continue;
							}
							case 9:
							{
								int num4;
								if (num2 >= fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps.Count)
								{
									num = -1682287510;
									num4 = num;
								}
								else
								{
									num = -1682287519;
									num4 = num;
								}
								continue;
							}
							case 5:
								num = -1682287511;
								continue;
							case 3:
								vmvMNXEgYVTEQzSXEsXkpnOkKkM = ylHjXIkDlXADAyqMAsjvxlfqXTj;
								num = -1682287512;
								continue;
							case 10:
								if (fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									controllerMap_Editor = fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
									num = -1682287516;
									continue;
								}
								goto case 11;
							case 13:
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.rxnvYOzxwbrAFoSmJMTTvMmWQsR = this;
								num = -1682287508;
								continue;
							case 8:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> func = vmvMNXEgYVTEQzSXEsXkpnOkKkM;
								KHsyAUIsBgNjqabmJBWuJbuuYio(controllerMap_Editor.actionElementMaps, fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT = controllerMap_Editor2;
								num = -1682287513;
								continue;
							}
							case 1:
								javCECFwSbQOHTYDsVGguaQvPhIz = new JavCECFwSbQOHTYDsVGguaQvPhIz();
								javCECFwSbQOHTYDsVGguaQvPhIz.vHdFczsgYBzyRcqGKKozCTOtvIT = fQiaIsSkvdoFDlHtTtQSqOAmCHlI2;
								javCECFwSbQOHTYDsVGguaQvPhIz.rxnvYOzxwbrAFoSmJMTTvMmWQsR = this;
								num = -1682287518;
								continue;
							case 11:
								TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.CreateMouseMap(fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId, fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId);
								controllerMap_Editor = fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = -1682287513;
								continue;
							case 4:
							{
								controllerMap_Editor2 = JsonTools.Clone(fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT);
								controllerMap_Editor2.actionElementMaps.Clear();
								int num3;
								if (vmvMNXEgYVTEQzSXEsXkpnOkKkM == null)
								{
									num = -1682287517;
									num3 = num;
								}
								else
								{
									num = -1682287512;
									num3 = num;
								}
								continue;
							}
							case 12:
							{
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT = JsonTools.Clone(fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.HSVwXeqdXxrYbeAcpbuwZUYRWYx);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = bGReLfdPyNCTgaEpmlwEMawxeRki.Find(fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.ULKDDFhyxUKLPQHQbWUElRjAzUTt);
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num2 = 0;
								num = -1682287515;
								continue;
							}
							case 2:
								javCECFwSbQOHTYDsVGguaQvPhIz.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								num = -1682287514;
								continue;
							default:
							{
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT.id = controllerMap_Editor.id;
								int index = fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(controllerMap_Editor);
								fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
								return fQiaIsSkvdoFDlHtTtQSqOAmCHlI2.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
							}
							}
							break;
						}
					}
				}

				private static int ylHjXIkDlXADAyqMAsjvxlfqXTj(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2 = 532940496;
						while (true)
						{
							switch (num2 ^ 0x1FC406D2)
							{
							case 4:
								break;
							case 1:
								if (P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								goto IL_0052;
							case 3:
								if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange)
								{
									num2 = 532940499;
									continue;
								}
								goto IL_0052;
							case 2:
								num2 = 532940498;
								continue;
							default:
								{
									if (num >= P_1.Count)
									{
										return -1;
									}
									goto case 3;
								}
								IL_0052:
								num++;
								num2 = 532940498;
								continue;
							}
							break;
						}
					}
				}
			}

			private sealed class TSrWDUToNgoKNokrxexcvfEkAve
			{
				private sealed class KGWvVtdHoZeJbfFwJGtlIrcBUjZP
				{
					public TSrWDUToNgoKNokrxexcvfEkAve OiLCynKfIKIhJJHYqnomeUhlShK;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor rAkUsdTnKPsjogOHmtoXScXdcVa;

					public bool aaJTUNDuzxSfuTWcqkjcOsqqGCsg(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.categoryId;
					}

					public bool SSastbtZianbpEfeFDwKFXqshgr(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.layoutId;
					}
				}

				private sealed class XzwXXoApyXVZJlWWTklGjsHApyi
				{
					public TSrWDUToNgoKNokrxexcvfEkAve OiLCynKfIKIhJJHYqnomeUhlShK;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor QdjUpOTkkdvVMYjwDhrGdDqMtalT;

					public htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;

					public bool ZKGehVQikJYBgRWHkUWiHrXHqzu(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId;
					}

					public bool kVvRvxbHXxLbhjKgxydvKAJLqBV(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId;
					}
				}

				private sealed class SFyacggOVBerxepqPjiBOnmtbPQf
				{
					public XzwXXoApyXVZJlWWTklGjsHApyi NtmTEnXHxvIcxXCNcBduKUYOMGB;

					public TSrWDUToNgoKNokrxexcvfEkAve OiLCynKfIKIhJJHYqnomeUhlShK;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ActionElementMap LnGQdTkvjCFdlrhTrhGIyQCHdZz;

					public bool jNbcrzPBJJHjpOHPOLYmxbvjXGk(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[NtmTEnXHxvIcxXCNcBduKUYOMGB.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId;
					}
				}

				public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> bGReLfdPyNCTgaEpmlwEMawxeRki;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> wuHWrbEtUGctLXLOIXSPjHBAsHv;

				public int wnGODavOznqtsnoEWwhirAPZPTV(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP> predicate = default(Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
					KGWvVtdHoZeJbfFwJGtlIrcBUjZP kGWvVtdHoZeJbfFwJGtlIrcBUjZP = default(KGWvVtdHoZeJbfFwJGtlIrcBUjZP);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					int num2 = default(int);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					while (true)
					{
						int num = 1360680360;
						while (true)
						{
							switch (num ^ 0x511A55AE)
							{
							case 8:
								break;
							case 5:
							{
								List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list = bGReLfdPyNCTgaEpmlwEMawxeRki;
								if (predicate == null)
								{
									predicate = kGWvVtdHoZeJbfFwJGtlIrcBUjZP.SSastbtZianbpEfeFDwKFXqshgr;
								}
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = list.Find(predicate);
								if (kGWvVtdHoZeJbfFwJGtlIrcBUjZP.rAkUsdTnKPsjogOHmtoXScXdcVa.hardwareGuid == P_1[num2].hardwareGuid && rcUTquXHCAvyGaPBfMLfcnmCCaP != null)
								{
									num = 1360680365;
									continue;
								}
								goto IL_00e8;
							}
							case 7:
							{
								int num3;
								if (num2 >= P_1.Count)
								{
									num = 1360680364;
									num3 = num;
								}
								else
								{
									num = 1360680367;
									num3 = num;
								}
								continue;
							}
							case 1:
								rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(kGWvVtdHoZeJbfFwJGtlIrcBUjZP.aaJTUNDuzxSfuTWcqkjcOsqqGCsg);
								num = 1360680363;
								continue;
							case 4:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null && rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_00e8;
							case 3:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].categoryId)
								{
									num = 1360680362;
									continue;
								}
								goto IL_00e8;
							case 6:
								predicate = null;
								num = 1360680366;
								continue;
							case 0:
								kGWvVtdHoZeJbfFwJGtlIrcBUjZP = new KGWvVtdHoZeJbfFwJGtlIrcBUjZP();
								kGWvVtdHoZeJbfFwJGtlIrcBUjZP.OiLCynKfIKIhJJHYqnomeUhlShK = this;
								kGWvVtdHoZeJbfFwJGtlIrcBUjZP.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								kGWvVtdHoZeJbfFwJGtlIrcBUjZP.rAkUsdTnKPsjogOHmtoXScXdcVa = P_0;
								num2 = 0;
								num = 1360680361;
								continue;
							default:
								{
									return -1;
								}
								IL_00e8:
								num2++;
								num = 1360680361;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor qMixYhSvvNdPBGtdjmnrugkeKdy(htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> P_0)
				{
					XzwXXoApyXVZJlWWTklGjsHApyi xzwXXoApyXVZJlWWTklGjsHApyi = new XzwXXoApyXVZJlWWTklGjsHApyi();
					xzwXXoApyXVZJlWWTklGjsHApyi.OiLCynKfIKIhJJHYqnomeUhlShK = this;
					xzwXXoApyXVZJlWWTklGjsHApyi.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
					xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
					xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT = JsonTools.Clone(xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(xzwXXoApyXVZJlWWTklGjsHApyi.ZKGehVQikJYBgRWHkUWiHrXHqzu);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = bGReLfdPyNCTgaEpmlwEMawxeRki.Find(xzwXXoApyXVZJlWWTklGjsHApyi.kVvRvxbHXxLbhjKgxydvKAJLqBV);
					xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
					SFyacggOVBerxepqPjiBOnmtbPQf sFyacggOVBerxepqPjiBOnmtbPQf = default(SFyacggOVBerxepqPjiBOnmtbPQf);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					int num2 = default(int);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					while (true)
					{
						int num = -1232187289;
						while (true)
						{
							switch (num ^ -1232187294)
							{
							case 2:
								break;
							case 8:
								sFyacggOVBerxepqPjiBOnmtbPQf.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								sFyacggOVBerxepqPjiBOnmtbPQf.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionCategoryId = ((TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(sFyacggOVBerxepqPjiBOnmtbPQf.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId) != null) ? TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(sFyacggOVBerxepqPjiBOnmtbPQf.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId).categoryId : 0);
								num2++;
								num = -1232187290;
								continue;
							case 6:
								xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.id = controllerMap_Editor.id;
								num = -1232187287;
								continue;
							case 1:
								if (wuHWrbEtUGctLXLOIXSPjHBAsHv == null)
								{
									wuHWrbEtUGctLXLOIXSPjHBAsHv = ZZXftjmszqxukxejTKvyRaWkzWv;
									num = -1232187295;
									continue;
								}
								goto case 3;
							case 3:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> func = wuHWrbEtUGctLXLOIXSPjHBAsHv;
								KHsyAUIsBgNjqabmJBWuJbuuYio(controllerMap_Editor.actionElementMaps, xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
								xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT = controllerMap_Editor2;
								num = -1232187292;
								continue;
							}
							case 10:
								if (xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
								{
									controllerMap_Editor = xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
									controllerMap_Editor2 = JsonTools.Clone(xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT);
									controllerMap_Editor2.actionElementMaps.Clear();
									num = -1232187293;
									continue;
								}
								goto case 13;
							case 4:
							{
								int num3;
								if (num2 < xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps.Count)
								{
									num = -1232187291;
									num3 = num;
								}
								else
								{
									num = -1232187288;
									num3 = num;
								}
								continue;
							}
							case 13:
								TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.CreateJoystickMap(xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId, xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.hardwareGuid, xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId);
								num = -1232187282;
								continue;
							case 0:
								rcUTquXHCAvyGaPBfMLfcnmCCaP3 = TJIgXNvoSVJXczwAANQkpnqJerC.SEfshPOIrHMtnqpzbElCsLiUazVa.Find(sFyacggOVBerxepqPjiBOnmtbPQf.jNbcrzPBJJHjpOHPOLYmxbvjXGk);
								num = -1232187286;
								continue;
							case 12:
								controllerMap_Editor = xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = -1232187292;
								continue;
							case 5:
								xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num2 = 0;
								num = -1232187290;
								continue;
							case 7:
								sFyacggOVBerxepqPjiBOnmtbPQf = new SFyacggOVBerxepqPjiBOnmtbPQf();
								sFyacggOVBerxepqPjiBOnmtbPQf.NtmTEnXHxvIcxXCNcBduKUYOMGB = xzwXXoApyXVZJlWWTklGjsHApyi;
								num = -1232187285;
								continue;
							case 9:
								sFyacggOVBerxepqPjiBOnmtbPQf.OiLCynKfIKIhJJHYqnomeUhlShK = this;
								sFyacggOVBerxepqPjiBOnmtbPQf.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								sFyacggOVBerxepqPjiBOnmtbPQf.LnGQdTkvjCFdlrhTrhGIyQCHdZz = xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps[num2];
								num = -1232187294;
								continue;
							default:
							{
								int index = xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(controllerMap_Editor);
								xzwXXoApyXVZJlWWTklGjsHApyi.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
								return xzwXXoApyXVZJlWWTklGjsHApyi.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
							}
							}
							break;
						}
					}
				}

				private static int ZZXftjmszqxukxejTKvyRaWkzWv(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num >= P_1.Count)
						{
							num2 = -746144687;
							num3 = num2;
						}
						else
						{
							num2 = -746144684;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -746144688)
							{
							case 2:
								num2 = -746144684;
								continue;
							case 0:
								break;
							case 3:
								if (P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								goto IL_005d;
							case 4:
								if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange && P_1[num]._axisContribution == P_0._axisContribution)
								{
									num2 = -746144685;
									continue;
								}
								goto IL_005d;
							default:
								{
									return -1;
								}
								IL_005d:
								num++;
								num2 = -746144688;
								continue;
							}
							break;
						}
					}
				}
			}

			private sealed class vURvfBjAqiCltEOGLOBSpqaLyJJQ
			{
				private sealed class gabrxvdKidAnxJLjsIlJsVyxvDk
				{
					public vURvfBjAqiCltEOGLOBSpqaLyJJQ sZIYuwTpMmolSnYdowJFSdubNgD;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor rAkUsdTnKPsjogOHmtoXScXdcVa;

					public bool xeEecLMrOiVglikGoGnMaGsGltq(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.customControllerUid;
					}

					public bool SvLyYtwzxZyjWsfWcOTWqLkcMEt(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.categoryId;
					}

					public bool rTUKFgeIggAXbxQaQeaNCibqsal(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0.mgYrBQfuwOpdNKDSIbFbRLGIiFP == rAkUsdTnKPsjogOHmtoXScXdcVa.layoutId;
					}
				}

				private sealed class EWyWkPySYKcefiiQamuCIGuKvYg
				{
					public vURvfBjAqiCltEOGLOBSpqaLyJJQ sZIYuwTpMmolSnYdowJFSdubNgD;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ControllerMap_Editor QdjUpOTkkdvVMYjwDhrGdDqMtalT;

					public htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> TYovXjkOcRdoWLmukRjeRaWZFiY;

					public bool qjUrGlrvSOpuVAYOrmQlJFruVcq(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.customControllerUid;
					}

					public bool aobQZQouFJuKhuHdEfmCmhenRgg(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId;
					}

					public bool KifnOEWuDvsmsKfRXClvgdiEPbIe(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId;
					}
				}

				private sealed class AYhLRHdegCmVJXSEZSwwhnTQRHE
				{
					public EWyWkPySYKcefiiQamuCIGuKvYg UldbSodVBfLZHnntNXxIeCgweaE;

					public vURvfBjAqiCltEOGLOBSpqaLyJJQ sZIYuwTpMmolSnYdowJFSdubNgD;

					public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

					public ActionElementMap LnGQdTkvjCFdlrhTrhGIyQCHdZz;

					public bool pEgMMQTmlAjLWIabWnRDrLJoMkWQ(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
					{
						return P_0[UldbSodVBfLZHnntNXxIeCgweaE.TYovXjkOcRdoWLmukRjeRaWZFiY.QiMDfljswXynnIIhmOOTitPrUQke] == LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId;
					}
				}

				public SAhulRYeMNjjDdkhYioTHxuUhjaA TJIgXNvoSVJXczwAANQkpnqJerC;

				public List<RcUTquXHCAvyGaPBfMLfcnmCCaP> bGReLfdPyNCTgaEpmlwEMawxeRki;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> tEaFqgzSgCWtCYgiXEJjObBhltd;

				public int FuqzSQRdANmXsqOFnLRXQNdbFPwd(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					int num2 = default(int);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
					gabrxvdKidAnxJLjsIlJsVyxvDk gabrxvdKidAnxJLjsIlJsVyxvDk2 = default(gabrxvdKidAnxJLjsIlJsVyxvDk);
					Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP> predicate = default(Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
					Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP> predicate2 = default(Predicate<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
					while (true)
					{
						int num = -293782673;
						while (true)
						{
							switch (num ^ -293782674)
							{
							case 6:
								break;
							case 7:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].customControllerUid && rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null && rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].categoryId && rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null && rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_0080;
							case 2:
								gabrxvdKidAnxJLjsIlJsVyxvDk2 = new gabrxvdKidAnxJLjsIlJsVyxvDk();
								gabrxvdKidAnxJLjsIlJsVyxvDk2.sZIYuwTpMmolSnYdowJFSdubNgD = this;
								num = -293782674;
								continue;
							case 1:
								predicate = null;
								predicate2 = null;
								num = -293782676;
								continue;
							case 5:
								if (rcUTquXHCAvyGaPBfMLfcnmCCaP != null)
								{
									num = -293782679;
									continue;
								}
								goto IL_0080;
							case 0:
								gabrxvdKidAnxJLjsIlJsVyxvDk2.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								gabrxvdKidAnxJLjsIlJsVyxvDk2.rAkUsdTnKPsjogOHmtoXScXdcVa = P_0;
								num2 = 0;
								num = -293782678;
								continue;
							case 8:
							{
								rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.CqLxuNvQSBdAMUNikIivkBCWkLm.Find(gabrxvdKidAnxJLjsIlJsVyxvDk2.xeEecLMrOiVglikGoGnMaGsGltq);
								List<RcUTquXHCAvyGaPBfMLfcnmCCaP> lGfBjiWXRzewPZnfqILeCrKIDvc = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc;
								if (predicate == null)
								{
									predicate = gabrxvdKidAnxJLjsIlJsVyxvDk2.SvLyYtwzxZyjWsfWcOTWqLkcMEt;
								}
								rcUTquXHCAvyGaPBfMLfcnmCCaP2 = lGfBjiWXRzewPZnfqILeCrKIDvc.Find(predicate);
								List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list = bGReLfdPyNCTgaEpmlwEMawxeRki;
								if (predicate2 == null)
								{
									predicate2 = gabrxvdKidAnxJLjsIlJsVyxvDk2.rTUKFgeIggAXbxQaQeaNCibqsal;
								}
								rcUTquXHCAvyGaPBfMLfcnmCCaP3 = list.Find(predicate2);
								num = -293782677;
								continue;
							}
							case 4:
							{
								int num3;
								if (num2 < P_1.Count)
								{
									num = -293782682;
									num3 = num;
								}
								else
								{
									num = -293782675;
									num3 = num;
								}
								continue;
							}
							default:
								{
									return -1;
								}
								IL_0080:
								num2++;
								num = -293782678;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor dkbwiwVvPhOKDgIcsUhYMgAknGe(htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMap_Editor> P_0)
				{
					EWyWkPySYKcefiiQamuCIGuKvYg eWyWkPySYKcefiiQamuCIGuKvYg = new EWyWkPySYKcefiiQamuCIGuKvYg();
					eWyWkPySYKcefiiQamuCIGuKvYg.sZIYuwTpMmolSnYdowJFSdubNgD = this;
					eWyWkPySYKcefiiQamuCIGuKvYg.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					AYhLRHdegCmVJXSEZSwwhnTQRHE aYhLRHdegCmVJXSEZSwwhnTQRHE = default(AYhLRHdegCmVJXSEZSwwhnTQRHE);
					int num2 = default(int);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					while (true)
					{
						int num = 1181635656;
						while (true)
						{
							switch (num ^ 0x466E544E)
							{
							case 5:
								break;
							case 1:
								eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.id = controllerMap_Editor.id;
								num = 1181635653;
								continue;
							case 3:
							{
								aYhLRHdegCmVJXSEZSwwhnTQRHE.LnGQdTkvjCFdlrhTrhGIyQCHdZz = eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps[num2];
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = TJIgXNvoSVJXczwAANQkpnqJerC.SEfshPOIrHMtnqpzbElCsLiUazVa.Find(aYhLRHdegCmVJXSEZSwwhnTQRHE.pEgMMQTmlAjLWIabWnRDrLJoMkWQ);
								aYhLRHdegCmVJXSEZSwwhnTQRHE.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num = 1181635660;
								continue;
							}
							case 6:
								eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY = P_0;
								num = 1181635658;
								continue;
							case 0:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> func = tEaFqgzSgCWtCYgiXEJjObBhltd;
								KHsyAUIsBgNjqabmJBWuJbuuYio(controllerMap_Editor.actionElementMaps, eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
								eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT = controllerMap_Editor2;
								num = 1181635663;
								continue;
							}
							case 10:
								if (num2 >= eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.actionElementMaps.Count)
								{
									int num3;
									if (eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.snqztkQepdQnGBnhenGsIbqrmFF)
									{
										num = 1181635655;
										num3 = num;
									}
									else
									{
										num = 1181635657;
										num3 = num;
									}
									continue;
								}
								goto case 8;
							case 4:
							{
								eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT = JsonTools.Clone(eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.WAXRrBwldppmaOlJLDIYCUmBYaD);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP2 = TJIgXNvoSVJXczwAANQkpnqJerC.CqLxuNvQSBdAMUNikIivkBCWkLm.Find(eWyWkPySYKcefiiQamuCIGuKvYg.qjUrGlrvSOpuVAYOrmQlJFruVcq);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP3 = TJIgXNvoSVJXczwAANQkpnqJerC.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(eWyWkPySYKcefiiQamuCIGuKvYg.aobQZQouFJuKhuHdEfmCmhenRgg);
								RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP4 = bGReLfdPyNCTgaEpmlwEMawxeRki.Find(eWyWkPySYKcefiiQamuCIGuKvYg.KifnOEWuDvsmsKfRXClvgdiEPbIe);
								eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.customControllerUid = ((rcUTquXHCAvyGaPBfMLfcnmCCaP2 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP2.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP3 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP3.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId = ((rcUTquXHCAvyGaPBfMLfcnmCCaP4 != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP4.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
								num2 = 0;
								num = 1181635652;
								continue;
							}
							case 7:
								TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.CreateCustomControllerMap(eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.categoryId, eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.customControllerUid, eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT.layoutId);
								controllerMap_Editor = eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.Count - 1];
								num = 1181635663;
								continue;
							case 2:
								aYhLRHdegCmVJXSEZSwwhnTQRHE.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionCategoryId = ((TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(aYhLRHdegCmVJXSEZSwwhnTQRHE.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId) != null) ? TJIgXNvoSVJXczwAANQkpnqJerC.VSIQlSXoGrtTSUPbSmfBclKbHBB.GetActionById(aYhLRHdegCmVJXSEZSwwhnTQRHE.LnGQdTkvjCFdlrhTrhGIyQCHdZz._actionId).categoryId : 0);
								num2++;
								num = 1181635652;
								continue;
							case 9:
								controllerMap_Editor = eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.NvWvpLcivPwaRMszPLXmXxMLzyb;
								controllerMap_Editor2 = JsonTools.Clone(eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT);
								controllerMap_Editor2.actionElementMaps.Clear();
								if (tEaFqgzSgCWtCYgiXEJjObBhltd == null)
								{
									tEaFqgzSgCWtCYgiXEJjObBhltd = ANiVdXzwBcueMBjXssGBZlBNqDp;
									num = 1181635662;
									continue;
								}
								goto case 0;
							case 8:
								aYhLRHdegCmVJXSEZSwwhnTQRHE = new AYhLRHdegCmVJXSEZSwwhnTQRHE();
								aYhLRHdegCmVJXSEZSwwhnTQRHE.UldbSodVBfLZHnntNXxIeCgweaE = eWyWkPySYKcefiiQamuCIGuKvYg;
								aYhLRHdegCmVJXSEZSwwhnTQRHE.sZIYuwTpMmolSnYdowJFSdubNgD = this;
								aYhLRHdegCmVJXSEZSwwhnTQRHE.TJIgXNvoSVJXczwAANQkpnqJerC = TJIgXNvoSVJXczwAANQkpnqJerC;
								num = 1181635661;
								continue;
							default:
							{
								int index = eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE.IndexOf(controllerMap_Editor);
								eWyWkPySYKcefiiQamuCIGuKvYg.TYovXjkOcRdoWLmukRjeRaWZFiY.ngVMhuTMwJNCnlEAbYZPSBJKCKE[index] = eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
								return eWyWkPySYKcefiiQamuCIGuKvYg.QdjUpOTkkdvVMYjwDhrGdDqMtalT;
							}
							}
							break;
						}
					}
				}

				private static int ANiVdXzwBcueMBjXssGBZlBNqDp(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange)
							{
								num2 = 1588608760;
								goto IL_000c;
							}
							goto IL_002f;
							IL_002f:
							num++;
							num2 = 1588608763;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x5EB03EF8)
								{
								case 2:
									num2 = 1588608761;
									continue;
								case 4:
									return num;
								case 0:
									break;
								case 1:
									goto end_IL_000c;
								default:
									goto end_IL_0069;
								}
								if (P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									num2 = 1588608764;
									continue;
								}
								goto IL_002f;
								continue;
								end_IL_000c:
								break;
							}
							continue;
							end_IL_0069:
							break;
						}
					}
					return -1;
				}
			}

			private sealed class RtyeuaMwqHHDlZbHNFwZUuLhnfW<T> where T : class
			{
				public Func<T, int> xVhDpslijnRudIjxBtDpNWVJqFj;
			}

			private sealed class AhqVkjDALaHAiCMUMZWPYtsoqSD<T> where T : class
			{
				public RtyeuaMwqHHDlZbHNFwZUuLhnfW<T> oHfAacADzWBMBqBfPvLlSWDYlSf;

				public T QdjUpOTkkdvVMYjwDhrGdDqMtalT;

				public bool PnhZRhOHCaGFqiAZsWTrogpoVcM(RcUTquXHCAvyGaPBfMLfcnmCCaP P_0)
				{
					return P_0.TlFNkMkCRiFdCGurBhKbcSOElLcv == oHfAacADzWBMBqBfPvLlSWDYlSf.xVhDpslijnRudIjxBtDpNWVJqFj(QdjUpOTkkdvVMYjwDhrGdDqMtalT);
				}
			}

			[CompilerGenerated]
			private static Func<InputCategory, int> OGVWKEKxiIjoLuVKvFpRbkqSZdj;

			[CompilerGenerated]
			private static Func<InputCategory, string> MtEGJvvlfXMEqmnRUyjoDtysXak;

			[CompilerGenerated]
			private static Func<InputCategory, IList<InputCategory>, int> ZjLMGhBwiPPsgXyKiGyADIUeIXL;

			[CompilerGenerated]
			private static Func<InputBehavior, int> UWaqiYMuWipjTDeZKUjYmDKFcvP;

			[CompilerGenerated]
			private static Func<InputBehavior, string> eTXcHlVhiycjjYbygBdZssAJlsg;

			[CompilerGenerated]
			private static Func<InputBehavior, IList<InputBehavior>, int> thhfRtBkSsYhxlSfhPWEFFXwGSa;

			[CompilerGenerated]
			private static Func<InputAction, int> oSEuXbOcYJamyjTHhcjiUPCrOqM;

			[CompilerGenerated]
			private static Func<InputAction, string> tgxEVgxGCnLeSdreoqhNvsfkXvA;

			[CompilerGenerated]
			private static Func<InputAction, IList<InputAction>, int> CMxTDWblWtbPyNCxliithNardkZ;

			[CompilerGenerated]
			private static Func<InputMapCategory, int> KBdhCNEIVJLoCgToyrGcjUMAIZGb;

			[CompilerGenerated]
			private static Func<InputMapCategory, string> cEcPTtLmMVccfKBZgYUsGtxQnhoP;

			[CompilerGenerated]
			private static Func<InputMapCategory, IList<InputMapCategory>, int> gBiSrrKXqxnKMyajouQYIBGVieq;

			[CompilerGenerated]
			private static Func<InputLayout, int> WdqVrMfCGPceAJlSkknOwvNpOGQ;

			[CompilerGenerated]
			private static Func<InputLayout, string> MkoayhosEvZYbKCFNHjVSSFrLHJ;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> AWvEHDPkrydGatGWPVCsttGhed;

			[CompilerGenerated]
			private static Func<InputLayout, int> sFDmceeIqXYqqgQgswEMwhqVzzS;

			[CompilerGenerated]
			private static Func<InputLayout, string> LeuEgfpucrBDLEsGrNsGHyKGndq;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> WeUgkZcyszRWZUAYhZCFihUPGCa;

			[CompilerGenerated]
			private static Func<InputLayout, int> RtJKSpKJhiTIbElelhEiIFmkBQQG;

			[CompilerGenerated]
			private static Func<InputLayout, string> UzxCBZCOZHsfROMinUZdpyBEldb;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> ocuxEYCOrAGgdcJYnDsRYwRowuOA;

			[CompilerGenerated]
			private static Func<InputLayout, int> CYmEvLCEHioAEcVwfmRrBEwmpjO;

			[CompilerGenerated]
			private static Func<InputLayout, string> QveubAFFFsBrBHfKulYmKOiVOyy;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> CFTnMhTqkPKENekSxChyVrhLhTH;

			[CompilerGenerated]
			private static Func<CustomController_Editor, int> iLrkCRvoSJMckLHjFzIIFYgqtOZ;

			[CompilerGenerated]
			private static Func<CustomController_Editor, string> ZrYMPrfYYizTQocKsjTNYtuTDpj;

			[CompilerGenerated]
			private static Func<CustomController_Editor, IList<CustomController_Editor>, int> iThxPPMNqYfrFJhzKrtnXZBIosv;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, int> BdyUQMgshwJgItsYwaaMGshlJtN;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, string> jGEDEwJtRiTecOARQricsoAEtIsH;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> lEatxkcHRrmXaTdxSUgcnFJYgDT;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, int> MvDbDGzHlczpdqFDSSbMvbkpsoU;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, string> hLPXMONqnYARvrpoHEPOnvjQgMIf;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> lpCrcrnyhoUTLbclUvDwwOkqXi;

			[CompilerGenerated]
			private static Func<Player_Editor, int> ZtssGBynrLPnPobIGGfQJPshvAP;

			[CompilerGenerated]
			private static Func<Player_Editor, string> flaeGhDmjrfDWmwvtnNkDLuBlaBB;

			[CompilerGenerated]
			private static Func<Player_Editor, IList<Player_Editor>, int> hPWzqbBqEYcFWeQtlMNGvkxopngU;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> KzwPxfGJFbWinEIjedfRXguPrlN;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> ydoeKwDaxSgwTfrBAqjoceEYLVH;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> XbOEnbCIhwwuwJrPlHOykZRuzhWd;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> fCcAgrVpIUDIAycNYIEAarAtAPlb;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> ZJSsATluWWxRHBDidahDOfddPkF;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> CueilsShzREBGzGnPItKgnFuwcu;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> haSWByNqYuFpaFGcccbCHtVEfiRB;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> nCecxZMgsbomWmHOyzVWencDBox;

			public static UserData onbfkkhCIMQRhJJmpGvvIIMVRgn(UserData P_0, UserData P_1, bool P_2)
			{
				int num3 = default(int);
				InputMapCategory inputMapCategory = default(InputMapCategory);
				int num2 = default(int);
				SAhulRYeMNjjDdkhYioTHxuUhjaA sAhulRYeMNjjDdkhYioTHxuUhjaA = default(SAhulRYeMNjjDdkhYioTHxuUhjaA);
				int index = default(int);
				List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list2 = default(List<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
				dxUqzBgbtBceCAuRLCgnfoedPAg dxUqzBgbtBceCAuRLCgnfoedPAg2 = default(dxUqzBgbtBceCAuRLCgnfoedPAg);
				List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list4 = default(List<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapEnabler_RuleSet_Editor>, ControllerMapEnabler_RuleSet_Editor> func9 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapEnabler_RuleSet_Editor>, ControllerMapEnabler_RuleSet_Editor>);
				hjDURaqEGAFGzQwkLiNiAbZizfI hjDURaqEGAFGzQwkLiNiAbZizfI2 = default(hjDURaqEGAFGzQwkLiNiAbZizfI);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout> func = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout>);
				wcUXXDjaDiyFescovjmwAPUNfJJ wcUXXDjaDiyFescovjmwAPUNfJJ2 = default(wcUXXDjaDiyFescovjmwAPUNfJJ);
				RcUTquXHCAvyGaPBfMLfcnmCCaP rcUTquXHCAvyGaPBfMLfcnmCCaP = default(RcUTquXHCAvyGaPBfMLfcnmCCaP);
				KRVQtNOElMQefFXbCqcRqKhvuSE kRVQtNOElMQefFXbCqcRqKhvuSE = default(KRVQtNOElMQefFXbCqcRqKhvuSE);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout> func29 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout>);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout> func30 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout>);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout> func20 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputLayout>, InputLayout>);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<CustomController_Editor>, CustomController_Editor> func24 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<CustomController_Editor>, CustomController_Editor>);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapLayoutManager_RuleSet_Editor>, ControllerMapLayoutManager_RuleSet_Editor> func28 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<ControllerMapLayoutManager_RuleSet_Editor>, ControllerMapLayoutManager_RuleSet_Editor>);
				vURvfBjAqiCltEOGLOBSpqaLyJJQ vURvfBjAqiCltEOGLOBSpqaLyJJQ2 = default(vURvfBjAqiCltEOGLOBSpqaLyJJQ);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputAction>, InputAction> func5 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<InputAction>, InputAction>);
				Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<Player_Editor>, Player_Editor> func13 = default(Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<Player_Editor>, Player_Editor>);
				List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list = default(List<RcUTquXHCAvyGaPBfMLfcnmCCaP>);
				while (true)
				{
					int num = 475571007;
					while (true)
					{
						object obj;
						switch (num ^ 0x1C58A31E)
						{
						case 11:
							break;
						case 14:
							if (num3 >= inputMapCategory.checkConflictsCategoryIds_orig.Count)
							{
								num2++;
								num = 475571006;
								continue;
							}
							goto case 4;
						case 21:
							inputMapCategory = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.mapCategories[index];
							num3 = 0;
							num = 475570960;
							continue;
						case 26:
						{
							nXdModXFcPbqTjadJSZmPVSashD("Mouse Map", P_0.mouseMaps, (P_1 != null) ? P_1.mouseMaps : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.mouseMaps, P_2, list2, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, dxUqzBgbtBceCAuRLCgnfoedPAg2.gVRJbGHlliwVlNBdWOpenRLgzdv, dxUqzBgbtBceCAuRLCgnfoedPAg2.eBOOPBcFmiTImXeOKkQjYBjiadG);
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list3 = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							TSrWDUToNgoKNokrxexcvfEkAve tSrWDUToNgoKNokrxexcvfEkAve = new TSrWDUToNgoKNokrxexcvfEkAve();
							tSrWDUToNgoKNokrxexcvfEkAve.TJIgXNvoSVJXczwAANQkpnqJerC = sAhulRYeMNjjDdkhYioTHxuUhjaA;
							tSrWDUToNgoKNokrxexcvfEkAve.bGReLfdPyNCTgaEpmlwEMawxeRki = sAhulRYeMNjjDdkhYioTHxuUhjaA.tOFFRlDtGUJxWietCdmiDsRFAEoq;
							nXdModXFcPbqTjadJSZmPVSashD("Joystick Map", P_0.joystickMaps, (P_1 != null) ? P_1.joystickMaps : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.joystickMaps, P_2, list3, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, tSrWDUToNgoKNokrxexcvfEkAve.wnGODavOznqtsnoEWwhirAPZPTV, tSrWDUToNgoKNokrxexcvfEkAve.qMixYhSvvNdPBGtdjmnrugkeKdy);
							list4 = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							num = 475570952;
							continue;
						}
						case 31:
							func9 = null;
							num = 475571005;
							continue;
						case 32:
							if (num2 >= hjDURaqEGAFGzQwkLiNiAbZizfI2.uzzTLUjgfTiHdEhjkGDnpnRIUSv.Count)
							{
								sAhulRYeMNjjDdkhYioTHxuUhjaA.JxDjicVKyEMuKcjzXecrKRysDayS = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
								List<InputLayout> keyboardLayouts = P_0.keyboardLayouts;
								List<InputLayout> obj5 = ((P_1 != null) ? P_1.keyboardLayouts : null);
								List<InputLayout> keyboardLayouts2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.keyboardLayouts;
								List<RcUTquXHCAvyGaPBfMLfcnmCCaP> jxDjicVKyEMuKcjzXecrKRysDayS = sAhulRYeMNjjDdkhYioTHxuUhjaA.JxDjicVKyEMuKcjzXecrKRysDayS;
								Func<InputLayout, int> func14 = (InputLayout inputLayout) => inputLayout.id;
								Func<InputLayout, string> func15 = (InputLayout inputLayout) => inputLayout.name;
								Func<InputLayout, IList<InputLayout>, int> func16 = delegate(InputLayout inputLayout, IList<InputLayout> list6)
								{
									int num4 = 0;
									while (num4 < list6.Count)
									{
										while (true)
										{
											int num5;
											if (string.Equals(inputLayout.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												num5 = -722517832;
											}
											else
											{
												num4++;
												num5 = -722517829;
											}
											while (true)
											{
												switch (num5 ^ -722517830)
												{
												case 0:
													num5 = -722517831;
													continue;
												case 3:
													break;
												case 2:
													return num4;
												default:
													goto end_IL_0026;
												}
												break;
											}
											continue;
											end_IL_0026:
											break;
										}
									}
									return -1;
								};
								if (func == null)
								{
									func = sAhulRYeMNjjDdkhYioTHxuUhjaA.fAfgAYFnaInFdicfyZZctQDQUthu;
								}
								nXdModXFcPbqTjadJSZmPVSashD("Keyboard Layout", keyboardLayouts, obj5, keyboardLayouts2, P_2, jxDjicVKyEMuKcjzXecrKRysDayS, func14, func15, func16, func);
								num = 475570957;
								continue;
							}
							goto case 13;
						case 18:
							wcUXXDjaDiyFescovjmwAPUNfJJ2 = new wcUXXDjaDiyFescovjmwAPUNfJJ();
							num = 475570944;
							continue;
						case 5:
							P_0 = JsonTools.Clone(P_0);
							if (P_1 == null)
							{
								num = 475570953;
								continue;
							}
							obj = JsonTools.Clone(P_1);
							goto IL_07d2;
						case 25:
							inputMapCategory.checkConflictsCategoryIds_orig[num3] = ((rcUTquXHCAvyGaPBfMLfcnmCCaP != null) ? rcUTquXHCAvyGaPBfMLfcnmCCaP.TlFNkMkCRiFdCGurBhKbcSOElLcv : (-1));
							num3++;
							num = 475570960;
							continue;
						case 20:
							hjDURaqEGAFGzQwkLiNiAbZizfI2 = new hjDURaqEGAFGzQwkLiNiAbZizfI();
							hjDURaqEGAFGzQwkLiNiAbZizfI2.TJIgXNvoSVJXczwAANQkpnqJerC = sAhulRYeMNjjDdkhYioTHxuUhjaA;
							num = 475571004;
							continue;
						case 0:
							kRVQtNOElMQefFXbCqcRqKhvuSE.pddFjipsnIJtsUtCmTRxVcwEaHA = hjDURaqEGAFGzQwkLiNiAbZizfI2;
							kRVQtNOElMQefFXbCqcRqKhvuSE.TJIgXNvoSVJXczwAANQkpnqJerC = sAhulRYeMNjjDdkhYioTHxuUhjaA;
							kRVQtNOElMQefFXbCqcRqKhvuSE.mgYrBQfuwOpdNKDSIbFbRLGIiFP = inputMapCategory.checkConflictsCategoryIds_orig[num3];
							num = 475570961;
							continue;
						case 19:
						{
							sAhulRYeMNjjDdkhYioTHxuUhjaA.ZoeEsMhgrIVKMSOxpgqDZhOysyAT = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<InputLayout> mouseLayouts = P_0.mouseLayouts;
							List<InputLayout> obj9 = ((P_1 != null) ? P_1.mouseLayouts : null);
							List<InputLayout> mouseLayouts2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.mouseLayouts;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> zoeEsMhgrIVKMSOxpgqDZhOysyAT = sAhulRYeMNjjDdkhYioTHxuUhjaA.ZoeEsMhgrIVKMSOxpgqDZhOysyAT;
							Func<InputLayout, int> func31 = (InputLayout inputLayout) => inputLayout.id;
							Func<InputLayout, string> func32 = (InputLayout inputLayout) => inputLayout.name;
							Func<InputLayout, IList<InputLayout>, int> func33 = delegate(InputLayout inputLayout, IList<InputLayout> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 521879195;
									while (true)
									{
										switch (num5 ^ 0x1F1B3E9A)
										{
										case 3:
											break;
										case 1:
											num5 = 521879194;
											continue;
										case 2:
											if (string.Equals(inputLayout.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 521879194;
											continue;
										default:
											if (num4 >= list6.Count)
											{
												return -1;
											}
											goto case 2;
										}
										break;
									}
								}
							};
							if (func29 == null)
							{
								func29 = sAhulRYeMNjjDdkhYioTHxuUhjaA.NxlSbfmLoSFdqROpvcXZGZcbWODE;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Mouse Layout", mouseLayouts, obj9, mouseLayouts2, P_2, zoeEsMhgrIVKMSOxpgqDZhOysyAT, func31, func32, func33, func29);
							sAhulRYeMNjjDdkhYioTHxuUhjaA.tOFFRlDtGUJxWietCdmiDsRFAEoq = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<InputLayout> joystickLayouts = P_0.joystickLayouts;
							List<InputLayout> obj10 = ((P_1 != null) ? P_1.joystickLayouts : null);
							List<InputLayout> joystickLayouts2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.joystickLayouts;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> tOFFRlDtGUJxWietCdmiDsRFAEoq = sAhulRYeMNjjDdkhYioTHxuUhjaA.tOFFRlDtGUJxWietCdmiDsRFAEoq;
							Func<InputLayout, int> func34 = (InputLayout inputLayout) => inputLayout.id;
							Func<InputLayout, string> func35 = (InputLayout inputLayout) => inputLayout.name;
							Func<InputLayout, IList<InputLayout>, int> func36 = delegate(InputLayout inputLayout, IList<InputLayout> list6)
							{
								int num4 = 0;
								while (num4 < list6.Count)
								{
									while (true)
									{
										int num5;
										if (string.Equals(inputLayout.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											num5 = 1134885314;
										}
										else
										{
											num4++;
											num5 = 1134885315;
										}
										while (true)
										{
											switch (num5 ^ 0x43A4F9C2)
											{
											case 2:
												num5 = 1134885313;
												continue;
											case 3:
												break;
											case 0:
												return num4;
											default:
												goto end_IL_0026;
											}
											break;
										}
										continue;
										end_IL_0026:
										break;
									}
								}
								return -1;
							};
							if (func30 == null)
							{
								func30 = sAhulRYeMNjjDdkhYioTHxuUhjaA.juWgrwxZfelPYiAptbwQiDgzbvRz;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Joystick Layout", joystickLayouts, obj10, joystickLayouts2, P_2, tOFFRlDtGUJxWietCdmiDsRFAEoq, func34, func35, func36, func30);
							num = 475570969;
							continue;
						}
						case 8:
							list2 = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							dxUqzBgbtBceCAuRLCgnfoedPAg2 = new dxUqzBgbtBceCAuRLCgnfoedPAg();
							dxUqzBgbtBceCAuRLCgnfoedPAg2.TJIgXNvoSVJXczwAANQkpnqJerC = sAhulRYeMNjjDdkhYioTHxuUhjaA;
							num = 475570964;
							continue;
						case 3:
							func29 = null;
							func30 = null;
							func20 = null;
							func24 = null;
							func28 = null;
							num = 475570945;
							continue;
						case 22:
							vURvfBjAqiCltEOGLOBSpqaLyJJQ2 = new vURvfBjAqiCltEOGLOBSpqaLyJJQ();
							num = 475570972;
							continue;
						case 15:
							rcUTquXHCAvyGaPBfMLfcnmCCaP = sAhulRYeMNjjDdkhYioTHxuUhjaA.lGfBjiWXRzewPZnfqILeCrKIDvc.Find(kRVQtNOElMQefFXbCqcRqKhvuSE.wNZFyYBzYDZPCPEExLOzWKTeEon);
							num = 475570951;
							continue;
						case 9:
							if (P_1 != null)
							{
								sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.configVars = JsonTools.Clone(P_1.configVars);
								num = 475570959;
								continue;
							}
							goto case 17;
						case 34:
							hjDURaqEGAFGzQwkLiNiAbZizfI2.uzzTLUjgfTiHdEhjkGDnpnRIUSv = new List<int>();
							nXdModXFcPbqTjadJSZmPVSashD("Map Category", P_0.mapCategories, (P_1 != null) ? P_1.mapCategories : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.mapCategories, P_2, sAhulRYeMNjjDdkhYioTHxuUhjaA.lGfBjiWXRzewPZnfqILeCrKIDvc, (InputMapCategory inputMapCategory2) => inputMapCategory2.id, (InputMapCategory inputMapCategory2) => inputMapCategory2.name, delegate(InputMapCategory inputMapCategory2, IList<InputMapCategory> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 798536815;
									while (true)
									{
										switch (num5 ^ 0x2F98B46D)
										{
										case 0:
											break;
										case 2:
											num5 = 798536812;
											continue;
										case 3:
											if (string.Equals(inputMapCategory2.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 798536812;
											continue;
										default:
											if (num4 >= list6.Count)
											{
												return -1;
											}
											goto case 3;
										}
										break;
									}
								}
							}, hjDURaqEGAFGzQwkLiNiAbZizfI2.UVDRRbjbxSDDbepRytVgFFwfVip);
							num2 = 0;
							num = 475570946;
							continue;
						case 17:
							sAhulRYeMNjjDdkhYioTHxuUhjaA.SsbEVLTIbWsgOHcmbgkPFWutBvto = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							nXdModXFcPbqTjadJSZmPVSashD("Action Category", P_0.actionCategories, (P_1 != null) ? P_1.actionCategories : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.actionCategories, P_2, sAhulRYeMNjjDdkhYioTHxuUhjaA.SsbEVLTIbWsgOHcmbgkPFWutBvto, (InputCategory inputCategory) => inputCategory.id, (InputCategory inputCategory) => inputCategory.name, delegate(InputCategory inputCategory, IList<InputCategory> list6)
							{
								int num4 = 0;
								while (num4 < list6.Count)
								{
									while (true)
									{
										if (string.Equals(inputCategory.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											return num4;
										}
										num4++;
										int num5 = -1354383684;
										while (true)
										{
											switch (num5 ^ -1354383682)
											{
											case 0:
												num5 = -1354383681;
												continue;
											case 1:
												break;
											default:
												goto end_IL_0022;
											}
											break;
										}
										continue;
										end_IL_0022:
										break;
									}
								}
								return -1;
							}, sAhulRYeMNjjDdkhYioTHxuUhjaA.iqyRTDlGHetyVIESRjUXsIgthcF);
							sAhulRYeMNjjDdkhYioTHxuUhjaA.SEAxlZKkmhXGWQulotwsLcRQCvZ = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							nXdModXFcPbqTjadJSZmPVSashD("Input Behavior", P_0.inputBehaviors, (P_1 != null) ? P_1.inputBehaviors : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.inputBehaviors, P_2, sAhulRYeMNjjDdkhYioTHxuUhjaA.SEAxlZKkmhXGWQulotwsLcRQCvZ, (InputBehavior inputBehavior) => inputBehavior.id, (InputBehavior inputBehavior) => inputBehavior.name, delegate(InputBehavior inputBehavior, IList<InputBehavior> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 1483028245;
									while (true)
									{
										switch (num5 ^ 0x58653717)
										{
										case 3:
											break;
										case 2:
											num5 = 1483028247;
											continue;
										case 1:
											if (string.Equals(inputBehavior.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 1483028247;
											continue;
										default:
											if (num4 >= list6.Count)
											{
												return -1;
											}
											goto case 1;
										}
										break;
									}
								}
							}, sAhulRYeMNjjDdkhYioTHxuUhjaA.kVwGwCrVCRfmyivwOVOPSToItEg);
							num = 475570975;
							continue;
						case 10:
							dxUqzBgbtBceCAuRLCgnfoedPAg2.bGReLfdPyNCTgaEpmlwEMawxeRki = sAhulRYeMNjjDdkhYioTHxuUhjaA.ZoeEsMhgrIVKMSOxpgqDZhOysyAT;
							num = 475570948;
							continue;
						case 24:
							func = null;
							num = 475570973;
							continue;
						case 33:
							func5 = null;
							num = 475570950;
							continue;
						case 13:
							index = hjDURaqEGAFGzQwkLiNiAbZizfI2.uzzTLUjgfTiHdEhjkGDnpnRIUSv[num2];
							num = 475570955;
							continue;
						case 23:
							obj = null;
							goto IL_07d2;
						case 35:
							func13 = null;
							sAhulRYeMNjjDdkhYioTHxuUhjaA = new SAhulRYeMNjjDdkhYioTHxuUhjaA();
							if (P_0 == null)
							{
								throw new ArgumentNullException("orig");
							}
							goto case 5;
						case 30:
							wcUXXDjaDiyFescovjmwAPUNfJJ2.TJIgXNvoSVJXczwAANQkpnqJerC = sAhulRYeMNjjDdkhYioTHxuUhjaA;
							wcUXXDjaDiyFescovjmwAPUNfJJ2.bGReLfdPyNCTgaEpmlwEMawxeRki = sAhulRYeMNjjDdkhYioTHxuUhjaA.JxDjicVKyEMuKcjzXecrKRysDayS;
							num = 475570958;
							continue;
						case 28:
							num = 475571006;
							continue;
						case 7:
						{
							sAhulRYeMNjjDdkhYioTHxuUhjaA.mwChnmOETAyyCvvuAlqkwXDYeNc = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<InputLayout> customControllerLayouts = P_0.customControllerLayouts;
							List<InputLayout> obj6 = ((P_1 != null) ? P_1.customControllerLayouts : null);
							List<InputLayout> customControllerLayouts2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.customControllerLayouts;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> mwChnmOETAyyCvvuAlqkwXDYeNc = sAhulRYeMNjjDdkhYioTHxuUhjaA.mwChnmOETAyyCvvuAlqkwXDYeNc;
							Func<InputLayout, int> func17 = (InputLayout inputLayout) => inputLayout.id;
							Func<InputLayout, string> func18 = (InputLayout inputLayout) => inputLayout.name;
							Func<InputLayout, IList<InputLayout>, int> func19 = delegate(InputLayout inputLayout, IList<InputLayout> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 1248380209;
									while (true)
									{
										switch (num5 ^ 0x4A68C533)
										{
										case 4:
											break;
										case 3:
										{
											int num6;
											if (num4 >= list6.Count)
											{
												num5 = 1248380211;
												num6 = num5;
											}
											else
											{
												num5 = 1248380210;
												num6 = num5;
											}
											continue;
										}
										case 1:
											if (string.Equals(inputLayout.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 1248380208;
											continue;
										case 2:
											num5 = 1248380208;
											continue;
										default:
											return -1;
										}
										break;
									}
								}
							};
							if (func20 == null)
							{
								func20 = sAhulRYeMNjjDdkhYioTHxuUhjaA.pXblyOzOuYdeYpuUXeysYDCdPyc;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Custom Controller Layout", customControllerLayouts, obj6, customControllerLayouts2, P_2, mwChnmOETAyyCvvuAlqkwXDYeNc, func17, func18, func19, func20);
							sAhulRYeMNjjDdkhYioTHxuUhjaA.qLcgTUNRASzVuyeaicCnLfUsCBu = sAhulRYeMNjjDdkhYioTHxuUhjaA.cdruiqRKuTPVgScUryLAXTHQUQp;
							sAhulRYeMNjjDdkhYioTHxuUhjaA.CqLxuNvQSBdAMUNikIivkBCWkLm = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<CustomController_Editor> customControllers = P_0.customControllers;
							List<CustomController_Editor> obj7 = ((P_1 != null) ? P_1.customControllers : null);
							List<CustomController_Editor> customControllers2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.customControllers;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> cqLxuNvQSBdAMUNikIivkBCWkLm = sAhulRYeMNjjDdkhYioTHxuUhjaA.CqLxuNvQSBdAMUNikIivkBCWkLm;
							Func<CustomController_Editor, int> func21 = (CustomController_Editor customController_Editor) => customController_Editor.id;
							Func<CustomController_Editor, string> func22 = (CustomController_Editor customController_Editor) => customController_Editor.name;
							Func<CustomController_Editor, IList<CustomController_Editor>, int> func23 = delegate(CustomController_Editor customController_Editor, IList<CustomController_Editor> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5;
									int num6;
									if (num4 < list6.Count)
									{
										num5 = 1652306941;
										num6 = num5;
									}
									else
									{
										num5 = 1652306940;
										num6 = num5;
									}
									while (true)
									{
										switch (num5 ^ 0x627C33FC)
										{
										case 2:
											num5 = 1652306941;
											continue;
										case 1:
											if (string.Equals(customController_Editor.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 1652306943;
											continue;
										case 3:
											break;
										default:
											return -1;
										}
										break;
									}
								}
							};
							if (func24 == null)
							{
								func24 = sAhulRYeMNjjDdkhYioTHxuUhjaA.HeafXSRuqvaxCOKftMHgnwnusNC;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Custom Controller", customControllers, obj7, customControllers2, P_2, cqLxuNvQSBdAMUNikIivkBCWkLm, func21, func22, func23, func24);
							sAhulRYeMNjjDdkhYioTHxuUhjaA.JjfaTLyWDOdfEyfBORsPCHrWwq = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = P_0.controllerMapLayoutManagerRuleSets;
							List<ControllerMapLayoutManager_RuleSet_Editor> obj8 = ((P_1 != null) ? P_1.controllerMapLayoutManagerRuleSets : null);
							List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.controllerMapLayoutManagerRuleSets;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> jjfaTLyWDOdfEyfBORsPCHrWwq = sAhulRYeMNjjDdkhYioTHxuUhjaA.JjfaTLyWDOdfEyfBORsPCHrWwq;
							Func<ControllerMapLayoutManager_RuleSet_Editor, int> func25 = (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.id;
							Func<ControllerMapLayoutManager_RuleSet_Editor, string> func26 = (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.name;
							Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> func27 = delegate(ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 625219287;
									while (true)
									{
										switch (num5 ^ 0x254416D6)
										{
										case 4:
											break;
										case 1:
											num5 = 625219286;
											continue;
										case 2:
											if (string.Equals(controllerMapLayoutManager_RuleSet_Editor.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												num5 = 625219285;
											}
											else
											{
												num4++;
												num5 = 625219286;
											}
											continue;
										case 3:
											return num4;
										default:
											if (num4 >= list6.Count)
											{
												return -1;
											}
											goto case 2;
										}
										break;
									}
								}
							};
							if (func28 == null)
							{
								func28 = sAhulRYeMNjjDdkhYioTHxuUhjaA.oADHwGhNnkWIJNsuZHUBJLtnNbJB;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Layout Manager Set", controllerMapLayoutManagerRuleSets, obj8, controllerMapLayoutManagerRuleSets2, P_2, jjfaTLyWDOdfEyfBORsPCHrWwq, func25, func26, func27, func28);
							sAhulRYeMNjjDdkhYioTHxuUhjaA.OBVyQAJOtjQKfACiROdUQjRjawQ = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							num = 475570962;
							continue;
						}
						case 4:
							kRVQtNOElMQefFXbCqcRqKhvuSE = new KRVQtNOElMQefFXbCqcRqKhvuSE();
							num = 475570974;
							continue;
						case 1:
						{
							sAhulRYeMNjjDdkhYioTHxuUhjaA.SEfshPOIrHMtnqpzbElCsLiUazVa = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<InputAction> actions = P_0.actions;
							List<InputAction> obj2 = ((P_1 != null) ? P_1.actions : null);
							List<InputAction> actions2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.actions;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> sEfshPOIrHMtnqpzbElCsLiUazVa = sAhulRYeMNjjDdkhYioTHxuUhjaA.SEfshPOIrHMtnqpzbElCsLiUazVa;
							Func<InputAction, int> func2 = (InputAction inputAction) => inputAction.id;
							Func<InputAction, string> func3 = (InputAction inputAction) => inputAction.name;
							Func<InputAction, IList<InputAction>, int> func4 = delegate(InputAction inputAction, IList<InputAction> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 2048831161;
									while (true)
									{
										switch (num5 ^ 0x7A1EAEBA)
										{
										case 2:
											break;
										case 3:
											num5 = 2048831163;
											continue;
										case 0:
											if (string.Equals(inputAction.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 2048831163;
											continue;
										default:
											if (num4 >= list6.Count)
											{
												return -1;
											}
											goto case 0;
										}
										break;
									}
								}
							};
							if (func5 == null)
							{
								func5 = sAhulRYeMNjjDdkhYioTHxuUhjaA.dADrqrPnMOzXHvPLlPZlrmjLBkE;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Action", actions, obj2, actions2, P_2, sEfshPOIrHMtnqpzbElCsLiUazVa, func2, func3, func4, func5);
							num = 475570949;
							continue;
						}
						case 2:
							vURvfBjAqiCltEOGLOBSpqaLyJJQ2.TJIgXNvoSVJXczwAANQkpnqJerC = sAhulRYeMNjjDdkhYioTHxuUhjaA;
							vURvfBjAqiCltEOGLOBSpqaLyJJQ2.bGReLfdPyNCTgaEpmlwEMawxeRki = sAhulRYeMNjjDdkhYioTHxuUhjaA.mwChnmOETAyyCvvuAlqkwXDYeNc;
							nXdModXFcPbqTjadJSZmPVSashD("Custom Controller Map", P_0.customControllerMaps, (P_1 != null) ? P_1.customControllerMaps : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.customControllerMaps, P_2, list4, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, vURvfBjAqiCltEOGLOBSpqaLyJJQ2.FuqzSQRdANmXsqOFnLRXQNdbFPwd, vURvfBjAqiCltEOGLOBSpqaLyJJQ2.dkbwiwVvPhOKDgIcsUhYMgAknGe);
							num = 475570947;
							continue;
						case 12:
						{
							List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = P_0.controllerMapEnablerRuleSets;
							List<ControllerMapEnabler_RuleSet_Editor> obj3 = ((P_1 != null) ? P_1.controllerMapEnablerRuleSets : null);
							List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.controllerMapEnablerRuleSets;
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> oBVyQAJOtjQKfACiROdUQjRjawQ = sAhulRYeMNjjDdkhYioTHxuUhjaA.OBVyQAJOtjQKfACiROdUQjRjawQ;
							Func<ControllerMapEnabler_RuleSet_Editor, int> func6 = (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.id;
							Func<ControllerMapEnabler_RuleSet_Editor, string> func7 = (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.name;
							Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> func8 = delegate(ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor> list6)
							{
								int num4 = 0;
								while (num4 < list6.Count)
								{
									while (true)
									{
										int num5;
										if (string.Equals(controllerMapEnabler_RuleSet_Editor.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											num5 = 2031947638;
										}
										else
										{
											num4++;
											num5 = 2031947637;
										}
										while (true)
										{
											switch (num5 ^ 0x791D0F76)
											{
											case 2:
												num5 = 2031947639;
												continue;
											case 1:
												break;
											case 0:
												return num4;
											default:
												goto end_IL_0026;
											}
											break;
										}
										continue;
										end_IL_0026:
										break;
									}
								}
								return -1;
							};
							if (func9 == null)
							{
								func9 = sAhulRYeMNjjDdkhYioTHxuUhjaA.AJfACGzHvzQJzOQYNiGEtSlRHQZ;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Controller Map Enabler Set", controllerMapEnablerRuleSets, obj3, controllerMapEnablerRuleSets2, P_2, oBVyQAJOtjQKfACiROdUQjRjawQ, func6, func7, func8, func9);
							List<RcUTquXHCAvyGaPBfMLfcnmCCaP> list5 = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							List<Player_Editor> players = P_0.players;
							List<Player_Editor> obj4 = ((P_1 != null) ? P_1.players : null);
							List<Player_Editor> players2 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.players;
							Func<Player_Editor, int> func10 = (Player_Editor player_Editor) => player_Editor.id;
							Func<Player_Editor, string> func11 = (Player_Editor player_Editor) => player_Editor.name;
							Func<Player_Editor, IList<Player_Editor>, int> func12 = delegate(Player_Editor player_Editor, IList<Player_Editor> list6)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 1899758812;
									while (true)
									{
										switch (num5 ^ 0x713C04DD)
										{
										case 3:
											break;
										case 1:
											num5 = 1899758813;
											continue;
										case 2:
											if (string.Equals(player_Editor.name, list6[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 1899758813;
											continue;
										default:
											if (num4 >= list6.Count)
											{
												return -1;
											}
											goto case 2;
										}
										break;
									}
								}
							};
							if (func13 == null)
							{
								func13 = sAhulRYeMNjjDdkhYioTHxuUhjaA.VPIugcFWXKRiEMYGQWemMZSAsrp;
							}
							nXdModXFcPbqTjadJSZmPVSashD("Player", players, obj4, players2, P_2, list5, func10, func11, func12, func13);
							num = 475570968;
							continue;
						}
						case 27:
							sAhulRYeMNjjDdkhYioTHxuUhjaA.lGfBjiWXRzewPZnfqILeCrKIDvc = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							num = 475570954;
							continue;
						case 16:
							nXdModXFcPbqTjadJSZmPVSashD("Keyboard Map", P_0.keyboardMaps, (P_1 != null) ? P_1.keyboardMaps : null, sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB.keyboardMaps, P_2, list, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, wcUXXDjaDiyFescovjmwAPUNfJJ2.oXbcDtYkcGCMMQooIkyioILhXLG, wcUXXDjaDiyFescovjmwAPUNfJJ2.DAohaDVJsRioqnNoYrPvSASIPYL);
							num = 475570966;
							continue;
						case 6:
							list = new List<RcUTquXHCAvyGaPBfMLfcnmCCaP>();
							num = 475570956;
							continue;
						default:
							{
								return sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB;
							}
							IL_07d2:
							P_1 = (UserData)obj;
							sAhulRYeMNjjDdkhYioTHxuUhjaA.VSIQlSXoGrtTSUPbSmfBclKbHBB = (P_2 ? P_0 : new UserData(false));
							num = 475570967;
							continue;
						}
						break;
					}
				}
			}

			[Conditional("DEBUG_IMPORT")]
			private static void hMFpqRFMVHXBJAdIrSCLfoKQzDd(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void KHsyAUIsBgNjqabmJBWuJbuuYio<T>(IList<T> P_0, IList<T> P_1, IList<T> P_2, Func<T, IList<T>, int> P_3)
			{
				int num = 0;
				int num5 = default(int);
				T val = default(T);
				int num4 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num >= P_0.Count)
					{
						num2 = -191055314;
						num3 = num2;
					}
					else
					{
						num2 = -191055320;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -191055319)
						{
						case 3:
							num2 = -191055320;
							continue;
						default:
							return;
						case 6:
							num5 = P_3(val, P_2);
							num2 = -191055317;
							continue;
						case 5:
							num2 = -191055323;
							continue;
						case 12:
						{
							int num7;
							if (num4 >= P_1.Count)
							{
								num2 = -191055319;
								num7 = num2;
							}
							else
							{
								num2 = -191055327;
								num7 = num2;
							}
							continue;
						}
						case 10:
							P_2[num5] = val;
							num2 = -191055315;
							continue;
						case 2:
						{
							int num6;
							if (num5 < 0)
							{
								num2 = -191055326;
								num6 = num2;
							}
							else
							{
								num2 = -191055325;
								num6 = num2;
							}
							continue;
						}
						case 1:
							P_2.Add(P_0[num]);
							num++;
							num2 = -191055324;
							continue;
						case 9:
							num4++;
							num2 = -191055323;
							continue;
						case 7:
							if (P_1 != null)
							{
								num4 = 0;
								num2 = -191055316;
								continue;
							}
							return;
						case 8:
							val = P_1[num4];
							num2 = -191055313;
							continue;
						case 11:
							P_2.Add(val);
							num2 = -191055328;
							continue;
						case 4:
							num2 = -191055328;
							continue;
						case 13:
							break;
						case 0:
							return;
						}
						break;
					}
				}
			}

			private static void nXdModXFcPbqTjadJSZmPVSashD<T>(string P_0, IList<T> P_1, IList<T> P_2, IList<T> P_3, bool P_4, List<RcUTquXHCAvyGaPBfMLfcnmCCaP> P_5, Func<T, int> P_6, Func<T, string> P_7, Func<T, IList<T>, int> P_8, Func<htyiGeTIlIuunxGqoEdPhWYaYxJo<T>, T> P_9) where T : class
			{
				RtyeuaMwqHHDlZbHNFwZUuLhnfW<T> rtyeuaMwqHHDlZbHNFwZUuLhnfW = new RtyeuaMwqHHDlZbHNFwZUuLhnfW<T>();
				int num4 = default(int);
				int num2 = default(int);
				T val2 = default(T);
				T val = default(T);
				while (true)
				{
					int num = 602747034;
					while (true)
					{
						switch (num ^ 0x23ED309D)
						{
						case 14:
							break;
						default:
							return;
						case 12:
							if (num4 >= P_1.Count)
							{
								if (P_2 != null)
								{
									num2 = 0;
									num = 602747029;
									continue;
								}
								return;
							}
							goto case 2;
						case 2:
							val2 = P_1[num4];
							num = 602747037;
							continue;
						case 11:
							num = 602747038;
							continue;
						case 4:
						{
							T arg2 = P_9(new htyiGeTIlIuunxGqoEdPhWYaYxJo<T>(val, null, RcUTquXHCAvyGaPBfMLfcnmCCaP.VaqfwhdabaVjMHRIwcNHnsBJfXqg.mgYrBQfuwOpdNKDSIbFbRLGIiFP, P_3, false));
							P_5.Add(new RcUTquXHCAvyGaPBfMLfcnmCCaP(-1, rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(val), rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(arg2)));
							num = 602747035;
							continue;
						}
						case 6:
						{
							string text2 = ((!string.IsNullOrEmpty(P_7(val))) ? ("\"" + P_7(val) + "\"") : "");
							Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
							num = 602747038;
							continue;
						}
						case 3:
							num2++;
							num = 602747028;
							continue;
						case 13:
						{
							T arg = P_9(new htyiGeTIlIuunxGqoEdPhWYaYxJo<T>(val2, null, RcUTquXHCAvyGaPBfMLfcnmCCaP.VaqfwhdabaVjMHRIwcNHnsBJfXqg.ebxrZAcVKcRjSOJmQrDizoGypxh, P_3, false));
							P_5.Add(new RcUTquXHCAvyGaPBfMLfcnmCCaP(rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(val2), -1, rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(arg)));
							num = 602747036;
							continue;
						}
						case 0:
							if (P_4)
							{
								P_5.Add(new RcUTquXHCAvyGaPBfMLfcnmCCaP(rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(val2), -1, rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(val2)));
								num = 602747036;
								continue;
							}
							goto case 13;
						case 9:
						{
							int num5;
							if (num2 < P_2.Count)
							{
								num = 602747032;
								num5 = num;
							}
							else
							{
								num = 602747031;
								num5 = num;
							}
							continue;
						}
						case 7:
							rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj = P_6;
							num4 = 0;
							num = 602747025;
							continue;
						case 1:
							num4++;
							num = 602747025;
							continue;
						case 5:
						{
							val = P_2[num2];
							int num3 = P_8(val, P_3);
							if (num3 >= 0)
							{
								AhqVkjDALaHAiCMUMZWPYtsoqSD<T> ahqVkjDALaHAiCMUMZWPYtsoqSD = new AhqVkjDALaHAiCMUMZWPYtsoqSD<T>();
								ahqVkjDALaHAiCMUMZWPYtsoqSD.oHfAacADzWBMBqBfPvLlSWDYlSf = rtyeuaMwqHHDlZbHNFwZUuLhnfW;
								T finalItem = P_3[num3];
								ahqVkjDALaHAiCMUMZWPYtsoqSD.QdjUpOTkkdvVMYjwDhrGdDqMtalT = P_9(new htyiGeTIlIuunxGqoEdPhWYaYxJo<T>(val, finalItem, RcUTquXHCAvyGaPBfMLfcnmCCaP.VaqfwhdabaVjMHRIwcNHnsBJfXqg.mgYrBQfuwOpdNKDSIbFbRLGIiFP, P_3, true));
								P_5.Find(ahqVkjDALaHAiCMUMZWPYtsoqSD.PnhZRhOHCaGFqiAZsWTrogpoVcM).mgYrBQfuwOpdNKDSIbFbRLGIiFP = rtyeuaMwqHHDlZbHNFwZUuLhnfW.xVhDpslijnRudIjxBtDpNWVJqFj(val);
								string text = ((!string.IsNullOrEmpty(P_7(val))) ? ("\"" + P_7(val) + "\"") : "");
								Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
								num = 602747030;
								continue;
							}
							goto case 4;
						}
						case 8:
							num = 602747028;
							continue;
						case 10:
							return;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int nnggjHaTneAsOwMUznxbYRRcmUg(InputCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string IoSHNPWkhXECESMLsLZkGMOPttr(InputCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int KgIHIrXquPRpWfIGKfSuHiPljSlA(InputCategory P_0, IList<InputCategory> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							return num;
						}
						num++;
						int num2 = -1354383684;
						while (true)
						{
							switch (num2 ^ -1354383682)
							{
							case 0:
								num2 = -1354383681;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int gIngUyBvvpSRZcYUBLCnJIEBUgbq(InputBehavior P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string qdGvkviDXZdxbDcAKUWcpwShsmKK(InputBehavior P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int PNSQihdpuLRLzuyykRPTyNdiGdY(InputBehavior P_0, IList<InputBehavior> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 1483028245;
					while (true)
					{
						switch (num2 ^ 0x58653717)
						{
						case 3:
							break;
						case 2:
							num2 = 1483028247;
							continue;
						case 1:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 1483028247;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int KGpbNsugDdQeztCddAnFaClClhZG(InputAction P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string McqqHRnsbmHYiRbjIJqtKXPhlQj(InputAction P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int TyATuXAYyPObZUNQcGjlpwtQGRl(InputAction P_0, IList<InputAction> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 2048831161;
					while (true)
					{
						switch (num2 ^ 0x7A1EAEBA)
						{
						case 2:
							break;
						case 3:
							num2 = 2048831163;
							continue;
						case 0:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 2048831163;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int HtwfvUbJmSjjtcXMJOJUaxAEdMV(InputMapCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string PYWWopOfJKXQdQiWgrplVdgcBkJ(InputMapCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int mEoMRlPMTFurfToNuDbWwFIqVSi(InputMapCategory P_0, IList<InputMapCategory> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 798536815;
					while (true)
					{
						switch (num2 ^ 0x2F98B46D)
						{
						case 0:
							break;
						case 2:
							num2 = 798536812;
							continue;
						case 3:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 798536812;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int wkevxHycDiTJXDdCeLqvpOwEqzx(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string tYXNnbVjpjhWxEfxxvhqqazlNxv(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int XyTqcaAiyMGfuJXEresEgxDwZlx(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = -722517832;
						}
						else
						{
							num++;
							num2 = -722517829;
						}
						while (true)
						{
							switch (num2 ^ -722517830)
							{
							case 0:
								num2 = -722517831;
								continue;
							case 3:
								break;
							case 2:
								return num;
							default:
								goto end_IL_0026;
							}
							break;
						}
						continue;
						end_IL_0026:
						break;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int ZgPwTKIfMvofjwYrwCLoIhljpmc(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string qRhaepMHzKtKJgrJSudrAkWnkLN(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int SZfOKVopcLyZSqmuJaDdShnMBmD(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 521879195;
					while (true)
					{
						switch (num2 ^ 0x1F1B3E9A)
						{
						case 3:
							break;
						case 1:
							num2 = 521879194;
							continue;
						case 2:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 521879194;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int JujsycbiRTeRZbwSFtIomKarASI(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string jgqczlotQsHAQZtbYsiMvOtaIMB(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int oRtHIVrJPvAfuevLRvZgOoCjQsvY(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = 1134885314;
						}
						else
						{
							num++;
							num2 = 1134885315;
						}
						while (true)
						{
							switch (num2 ^ 0x43A4F9C2)
							{
							case 2:
								num2 = 1134885313;
								continue;
							case 3:
								break;
							case 0:
								return num;
							default:
								goto end_IL_0026;
							}
							break;
						}
						continue;
						end_IL_0026:
						break;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int VfTBXPJvsdhkKLyKuJDTseqHGKK(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string BDYeMTPVYyZkgVKqBniilwqculq(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int fXANHbcDjMdlQJtjtCNxfUThmAM(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 1248380209;
					while (true)
					{
						switch (num2 ^ 0x4A68C533)
						{
						case 4:
							break;
						case 3:
						{
							int num3;
							if (num >= P_1.Count)
							{
								num2 = 1248380211;
								num3 = num2;
							}
							else
							{
								num2 = 1248380210;
								num3 = num2;
							}
							continue;
						}
						case 1:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 1248380208;
							continue;
						case 2:
							num2 = 1248380208;
							continue;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int SzGbezVjfQLfzeNDcjXfcZTtQFj(CustomController_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string QVJXZsBqmTsIwfUvFWXbQBKWSTp(CustomController_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int KesQsvlbzckzvaUYxXtiFCgojkO(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < P_1.Count)
					{
						num2 = 1652306941;
						num3 = num2;
					}
					else
					{
						num2 = 1652306940;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x627C33FC)
						{
						case 2:
							num2 = 1652306941;
							continue;
						case 1:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 1652306943;
							continue;
						case 3:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int jLIOhKIGXPrLTSbcxFvxhpdYjhz(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string KGFhkJxqYhVquqorjrIBxQWAHio(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int DDTZxHwrNTNjgHarsYDejSNkvsx(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 625219287;
					while (true)
					{
						switch (num2 ^ 0x254416D6)
						{
						case 4:
							break;
						case 1:
							num2 = 625219286;
							continue;
						case 2:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								num2 = 625219285;
								continue;
							}
							num++;
							num2 = 625219286;
							continue;
						case 3:
							return num;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int bbXSaryeJAlqjNlAtEtjSIUnEpf(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string FCmgAhNXuSjSGkyfQMAlNxTAfPD(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int ozTfNVTRqvPYnsBGfGYUeJWzwFmC(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = 2031947638;
						}
						else
						{
							num++;
							num2 = 2031947637;
						}
						while (true)
						{
							switch (num2 ^ 0x791D0F76)
							{
							case 2:
								num2 = 2031947639;
								continue;
							case 1:
								break;
							case 0:
								return num;
							default:
								goto end_IL_0026;
							}
							break;
						}
						continue;
						end_IL_0026:
						break;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int WeTNEbtREtyCXACHIUEOJNIFDzGG(Player_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string qojkYiNtDieNgkygodMgXIOLbSN(Player_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int sRRviszGLPmmMGshfRWfnCqAqXY(Player_Editor P_0, IList<Player_Editor> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 1899758812;
					while (true)
					{
						switch (num2 ^ 0x713C04DD)
						{
						case 3:
							break;
						case 1:
							num2 = 1899758813;
							continue;
						case 2:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 1899758813;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int xiUWpmJEIqASvcgbNaUIfjyCsNwt(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string EOEAHtJjexerPapYlLQQaugoJpvO(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int fOGUfkSnLxExLquZBnbUBTtZrld(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string uTzquehcMZluUEAjtmeeyOQQFWf(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int IcKsUfCgziOloGxbScfhgOpwAuee(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string siCXoQrgfXplCPPGTlsiYdWVgVoD(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int YRnhMcQCFmfFQAuqzFgoPxGVYyG(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string HQIsaMiyiHkayBdunjhkOkpyPco(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}
		}

		private sealed class oQWMaesNxtkAUTnETBgCArQBpol : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string gOLsIvUagYjTsnfFxoDrjCWKnIG;

			public string PqgqlyVpPbbxVBxonFUFLIlCcziX;

			public int cxajIdvHgWRVzXfSJnEbjHXsCoJi;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0059;
				IL_0012:
				int num = -2052946421;
				goto IL_0017;
				IL_0017:
				oQWMaesNxtkAUTnETBgCArQBpol oQWMaesNxtkAUTnETBgCArQBpol2 = default(oQWMaesNxtkAUTnETBgCArQBpol);
				while (true)
				{
					switch (num ^ -2052946417)
					{
					case 0:
						break;
					case 4:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = -2052946419;
							continue;
						}
						goto IL_0059;
					case 2:
						oQWMaesNxtkAUTnETBgCArQBpol2 = this;
						num = -2052946420;
						continue;
					case 1:
						goto IL_0059;
					default:
						oQWMaesNxtkAUTnETBgCArQBpol2.gOLsIvUagYjTsnfFxoDrjCWKnIG = PqgqlyVpPbbxVBxonFUFLIlCcziX;
						return oQWMaesNxtkAUTnETBgCArQBpol2;
					}
					break;
				}
				goto IL_0012;
				IL_0059:
				oQWMaesNxtkAUTnETBgCArQBpol2 = new oQWMaesNxtkAUTnETBgCArQBpol(0);
				oQWMaesNxtkAUTnETBgCArQBpol2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -2052946420;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = -501064949;
					goto IL_001f;
				case 0:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (gOLsIvUagYjTsnfFxoDrjCWKnIG == null)
						{
							break;
						}
						int num4;
						if (gOLsIvUagYjTsnfFxoDrjCWKnIG == string.Empty)
						{
							num = -501064948;
							num4 = num;
						}
						else
						{
							num = -501064952;
							num4 = num;
						}
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -501064950)
						{
						case 0:
							num = -501064945;
							continue;
						case 7:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[cxajIdvHgWRVzXfSJnEbjHXsCoJi].tag.Equals(gOLsIvUagYjTsnfFxoDrjCWKnIG, StringComparison.OrdinalIgnoreCase))
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[cxajIdvHgWRVzXfSJnEbjHXsCoJi];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							}
							goto case 1;
						case 3:
							cxajIdvHgWRVzXfSJnEbjHXsCoJi = 0;
							num = -501064946;
							continue;
						case 2:
							break;
						case 5:
							goto end_IL_001f;
						case 4:
							goto IL_0118;
						case 1:
							cxajIdvHgWRVzXfSJnEbjHXsCoJi++;
							num = -501064946;
							continue;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories == null)
						{
							num = -501064948;
							num2 = num;
						}
						else
						{
							num = -501064951;
							num2 = num;
						}
						continue;
						IL_0118:
						int num3;
						if (cxajIdvHgWRVzXfSJnEbjHXsCoJi < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories.Count)
						{
							num = -501064947;
							num3 = num;
						}
						else
						{
							num = -501064948;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public oQWMaesNxtkAUTnETBgCArQBpol(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class eJvyjCvDNezNonWTSTsIaKFKDAa : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int svZTdoqdxtiuAiaKSfUWXjcgcXUC;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				eJvyjCvDNezNonWTSTsIaKFKDAa eJvyjCvDNezNonWTSTsIaKFKDAa2;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					eJvyjCvDNezNonWTSTsIaKFKDAa2 = this;
				}
				else
				{
					while (true)
					{
						eJvyjCvDNezNonWTSTsIaKFKDAa2 = new eJvyjCvDNezNonWTSTsIaKFKDAa(0);
						eJvyjCvDNezNonWTSTsIaKFKDAa2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = 2094472530;
						while (true)
						{
							switch (num ^ 0x7CD71D50)
							{
							case 0:
								num = 2094472529;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				return eJvyjCvDNezNonWTSTsIaKFKDAa2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = -1626441102;
					goto IL_001f;
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -1626441103;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1626441100)
						{
						case 0:
							num = -1626441104;
							continue;
						case 4:
							break;
						case 7:
							goto IL_0061;
						case 5:
							svZTdoqdxtiuAiaKSfUWXjcgcXUC++;
							num = -1626441101;
							continue;
						case 2:
							return true;
						case 8:
							num = -1626441101;
							continue;
						case 3:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[svZTdoqdxtiuAiaKSfUWXjcgcXUC].userAssignable)
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[svZTdoqdxtiuAiaKSfUWXjcgcXUC];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1626441098;
								continue;
							}
							goto case 5;
						case 6:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories != null)
							{
								svZTdoqdxtiuAiaKSfUWXjcgcXUC = 0;
								num = -1626441092;
								continue;
							}
							goto end_IL_0008;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0061:
						int num2;
						if (svZTdoqdxtiuAiaKSfUWXjcgcXUC >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories.Count)
						{
							num = -1626441099;
							num2 = num;
						}
						else
						{
							num = -1626441097;
							num2 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public eJvyjCvDNezNonWTSTsIaKFKDAa(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class KfRnXFwvjrVKFFJVmqzXciMAWbd : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string gOLsIvUagYjTsnfFxoDrjCWKnIG;

			public string PqgqlyVpPbbxVBxonFUFLIlCcziX;

			public int zvhWcxjEpEsfKFnQaCupmndkcpL;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				KfRnXFwvjrVKFFJVmqzXciMAWbd kfRnXFwvjrVKFFJVmqzXciMAWbd;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					kfRnXFwvjrVKFFJVmqzXciMAWbd = this;
				}
				else
				{
					while (true)
					{
						kfRnXFwvjrVKFFJVmqzXciMAWbd = new KfRnXFwvjrVKFFJVmqzXciMAWbd(0);
						int num = -932106249;
						while (true)
						{
							switch (num ^ -932106251)
							{
							case 0:
								num = -932106250;
								continue;
							case 3:
								break;
							case 2:
								kfRnXFwvjrVKFFJVmqzXciMAWbd.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = -932106252;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				kfRnXFwvjrVKFFJVmqzXciMAWbd.gOLsIvUagYjTsnfFxoDrjCWKnIG = PqgqlyVpPbbxVBxonFUFLIlCcziX;
				return kfRnXFwvjrVKFFJVmqzXciMAWbd;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = 529095825;
					while (true)
					{
						switch (num ^ 0x1F895C90)
						{
						case 2:
							break;
						case 4:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[zvhWcxjEpEsfKFnQaCupmndkcpL].userAssignable)
							{
								int num3;
								if (!ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[zvhWcxjEpEsfKFnQaCupmndkcpL].tag.Equals(gOLsIvUagYjTsnfFxoDrjCWKnIG, StringComparison.OrdinalIgnoreCase))
								{
									num = 529095829;
									num3 = num;
								}
								else
								{
									num = 529095824;
									num3 = num;
								}
								continue;
							}
							goto case 5;
						case 5:
							zvhWcxjEpEsfKFnQaCupmndkcpL++;
							num = 529095832;
							continue;
						case 1:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = 529095831;
								continue;
							case 0:
								break;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 529095829;
								continue;
							}
							goto case 3;
						case 6:
							zvhWcxjEpEsfKFnQaCupmndkcpL = 0;
							num = 529095832;
							continue;
						case 3:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (gOLsIvUagYjTsnfFxoDrjCWKnIG != null && !(gOLsIvUagYjTsnfFxoDrjCWKnIG == string.Empty))
							{
								int num4;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories == null)
								{
									num = 529095831;
									num4 = num;
								}
								else
								{
									num = 529095830;
									num4 = num;
								}
								continue;
							}
							goto default;
						case 8:
						{
							int num2;
							if (zvhWcxjEpEsfKFnQaCupmndkcpL >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories.Count)
							{
								num = 529095831;
								num2 = num;
							}
							else
							{
								num = 529095828;
								num2 = num;
							}
							continue;
						}
						case 0:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.mapCategories[zvhWcxjEpEsfKFnQaCupmndkcpL];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						default:
							return false;
						}
						break;
					}
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
			}

			[DebuggerHidden]
			public KfRnXFwvjrVKFFJVmqzXciMAWbd(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class YoIKuYxemWUWRtHOwFoTSKgRymF : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string gOLsIvUagYjTsnfFxoDrjCWKnIG;

			public string PqgqlyVpPbbxVBxonFUFLIlCcziX;

			public int vidBsJgUgwPQGicOAyGUeZfUYaEu;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_0065;
				IL_0028:
				int num;
				YoIKuYxemWUWRtHOwFoTSKgRymF yoIKuYxemWUWRtHOwFoTSKgRymF = default(YoIKuYxemWUWRtHOwFoTSKgRymF);
				while (true)
				{
					switch (num ^ 0x7EDAB4C9)
					{
					case 0:
						break;
					case 2:
						yoIKuYxemWUWRtHOwFoTSKgRymF = this;
						num = 2128262346;
						continue;
					case 1:
						yoIKuYxemWUWRtHOwFoTSKgRymF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 2128262346;
						continue;
					case 4:
						goto IL_0065;
					default:
						yoIKuYxemWUWRtHOwFoTSKgRymF.gOLsIvUagYjTsnfFxoDrjCWKnIG = PqgqlyVpPbbxVBxonFUFLIlCcziX;
						return yoIKuYxemWUWRtHOwFoTSKgRymF;
					}
					break;
				}
				goto IL_0023;
				IL_0065:
				yoIKuYxemWUWRtHOwFoTSKgRymF = new YoIKuYxemWUWRtHOwFoTSKgRymF(0);
				num = 2128262344;
				goto IL_0028;
				IL_0023:
				num = 2128262347;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (gOLsIvUagYjTsnfFxoDrjCWKnIG == null)
					{
						break;
					}
					int num2;
					if (!(gOLsIvUagYjTsnfFxoDrjCWKnIG == string.Empty))
					{
						num = -335957552;
						num2 = num;
					}
					else
					{
						num = -335957551;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -335957548;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -335957547)
						{
						case 0:
							num = -335957545;
							continue;
						case 3:
							break;
						case 5:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories != null)
							{
								vidBsJgUgwPQGicOAyGUeZfUYaEu = 0;
								num = -335957546;
								continue;
							}
							goto end_IL_0008;
						case 1:
							vidBsJgUgwPQGicOAyGUeZfUYaEu++;
							num = -335957546;
							continue;
						case 2:
							goto end_IL_001f;
						case 6:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[vidBsJgUgwPQGicOAyGUeZfUYaEu].tag.Equals(gOLsIvUagYjTsnfFxoDrjCWKnIG, StringComparison.OrdinalIgnoreCase))
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[vidBsJgUgwPQGicOAyGUeZfUYaEu];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							}
							goto case 1;
						default:
							goto end_IL_0008;
						}
						int num3;
						if (vidBsJgUgwPQGicOAyGUeZfUYaEu >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories.Count)
						{
							num = -335957551;
							num3 = num;
						}
						else
						{
							num = -335957549;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public YoIKuYxemWUWRtHOwFoTSKgRymF(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 1368820532;
					while (true)
					{
						switch (num ^ 0x51968B35)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 2:
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
						num = 1368820535;
					}
				}
			}
		}

		private sealed class iTdijQZJWmtqhXBVAApaGDvyBeI : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int QEgtepIYUOjTaSfsalgCJGHAIDl;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				iTdijQZJWmtqhXBVAApaGDvyBeI iTdijQZJWmtqhXBVAApaGDvyBeI2 = new iTdijQZJWmtqhXBVAApaGDvyBeI(0);
				iTdijQZJWmtqhXBVAApaGDvyBeI2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				int num = 1402429088;
				goto IL_0021;
				IL_001c:
				num = 1402429089;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x53975EA3)
					{
					case 0:
						break;
					case 2:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						iTdijQZJWmtqhXBVAApaGDvyBeI2 = this;
						num = 1402429088;
						continue;
					case 1:
						goto IL_004e;
					default:
						return iTdijQZJWmtqhXBVAApaGDvyBeI2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories == null)
					{
						break;
					}
					QEgtepIYUOjTaSfsalgCJGHAIDl = 0;
					num = -729957110;
					goto IL_001f;
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -729957112;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -729957109)
						{
						case 4:
							num = -729957111;
							continue;
						case 2:
							break;
						case 1:
							num = -729957107;
							continue;
						case 6:
							goto IL_0077;
						case 3:
							QEgtepIYUOjTaSfsalgCJGHAIDl++;
							num = -729957107;
							continue;
						case 0:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[QEgtepIYUOjTaSfsalgCJGHAIDl].userAssignable)
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[QEgtepIYUOjTaSfsalgCJGHAIDl];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							}
							goto case 3;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0077:
						int num2;
						if (QEgtepIYUOjTaSfsalgCJGHAIDl < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories.Count)
						{
							num = -729957109;
							num2 = num;
						}
						else
						{
							num = -729957106;
							num2 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public iTdijQZJWmtqhXBVAApaGDvyBeI(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class UKumDJguFMtydJdQpqrTqPhQEmVC : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string gOLsIvUagYjTsnfFxoDrjCWKnIG;

			public string PqgqlyVpPbbxVBxonFUFLIlCcziX;

			public int pvjJhWYgzSepTjFZYCWkXSAmfcL;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				UKumDJguFMtydJdQpqrTqPhQEmVC uKumDJguFMtydJdQpqrTqPhQEmVC;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					uKumDJguFMtydJdQpqrTqPhQEmVC = this;
				}
				else
				{
					while (true)
					{
						uKumDJguFMtydJdQpqrTqPhQEmVC = new UKumDJguFMtydJdQpqrTqPhQEmVC(0);
						int num = -559250603;
						while (true)
						{
							switch (num ^ -559250601)
							{
							case 0:
								num = -559250602;
								continue;
							case 1:
								break;
							case 2:
								uKumDJguFMtydJdQpqrTqPhQEmVC.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = -559250604;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				uKumDJguFMtydJdQpqrTqPhQEmVC.gOLsIvUagYjTsnfFxoDrjCWKnIG = PqgqlyVpPbbxVBxonFUFLIlCcziX;
				return uKumDJguFMtydJdQpqrTqPhQEmVC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -931950139;
					while (true)
					{
						switch (num ^ -931950131)
						{
						case 3:
							break;
						case 9:
						{
							int num4;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[pvjJhWYgzSepTjFZYCWkXSAmfcL].tag.Equals(gOLsIvUagYjTsnfFxoDrjCWKnIG, StringComparison.OrdinalIgnoreCase))
							{
								num = -931950132;
								num4 = num;
							}
							else
							{
								num = -931950137;
								num4 = num;
							}
							continue;
						}
						case 5:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = -931950135;
							continue;
						case 2:
						{
							int num5;
							if (pvjJhWYgzSepTjFZYCWkXSAmfcL < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories.Count)
							{
								num = -931950131;
								num5 = num;
							}
							else
							{
								num = -931950134;
								num5 = num;
							}
							continue;
						}
						case 0:
						{
							int num3;
							if (!ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[pvjJhWYgzSepTjFZYCWkXSAmfcL].userAssignable)
							{
								num = -931950137;
								num3 = num;
							}
							else
							{
								num = -931950140;
								num3 = num;
							}
							continue;
						}
						case 4:
							if (gOLsIvUagYjTsnfFxoDrjCWKnIG != null && !(gOLsIvUagYjTsnfFxoDrjCWKnIG == string.Empty))
							{
								int num2;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories != null)
								{
									num = -931950133;
									num2 = num;
								}
								else
								{
									num = -931950134;
									num2 = num;
								}
								continue;
							}
							goto default;
						case 6:
							pvjJhWYgzSepTjFZYCWkXSAmfcL = 0;
							num = -931950129;
							continue;
						case 8:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								break;
							default:
								num = -931950134;
								continue;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -931950137;
								continue;
							}
							goto case 5;
						case 1:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[pvjJhWYgzSepTjFZYCWkXSAmfcL];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 10:
							pvjJhWYgzSepTjFZYCWkXSAmfcL++;
							num = -931950129;
							continue;
						default:
							return false;
						}
						break;
					}
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
			}

			[DebuggerHidden]
			public UKumDJguFMtydJdQpqrTqPhQEmVC(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ZotaUMpuLztLMbkYAFrBEigzqW : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int vQmqktEhURpyEPPKqSMuPuoewoF;

			public InputAction wrXVBFCfgNuHIneUWnRuBPqWmFE;

			public InputCategory vCRAmFictOEOBdRPRyeSyiCGEQP;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				ZotaUMpuLztLMbkYAFrBEigzqW zotaUMpuLztLMbkYAFrBEigzqW;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					zotaUMpuLztLMbkYAFrBEigzqW = this;
				}
				else
				{
					while (true)
					{
						zotaUMpuLztLMbkYAFrBEigzqW = new ZotaUMpuLztLMbkYAFrBEigzqW(0);
						int num = 1372831834;
						while (true)
						{
							switch (num ^ 0x51D3C058)
							{
							case 0:
								num = 1372831835;
								continue;
							case 3:
								break;
							case 2:
								zotaUMpuLztLMbkYAFrBEigzqW.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = 1372831833;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				return zotaUMpuLztLMbkYAFrBEigzqW;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				default:
					num = -1309104472;
					goto IL_001a;
				case 0:
					goto IL_0070;
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -1309104465;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ -1309104477)
						{
						case 0:
							break;
						case 3:
							vQmqktEhURpyEPPKqSMuPuoewoF = 0;
							num = -1309104470;
							continue;
						case 8:
							goto IL_0070;
						case 2:
							RDkWcsTpvDaNZojjIZONnoEBXPC = wrXVBFCfgNuHIneUWnRuBPqWmFE;
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							num = -1309104474;
							continue;
						case 4:
							goto IL_0098;
						case 11:
							num = -1309104475;
							continue;
						case 7:
							vCRAmFictOEOBdRPRyeSyiCGEQP = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionCategoryById(wrXVBFCfgNuHIneUWnRuBPqWmFE.categoryId);
							if (vCRAmFictOEOBdRPRyeSyiCGEQP != null)
							{
								goto IL_00e7;
							}
							goto case 12;
						case 1:
							goto IL_0108;
						case 12:
							vQmqktEhURpyEPPKqSMuPuoewoF++;
							num = -1309104478;
							continue;
						case 13:
							goto IL_014c;
						case 5:
							return true;
						case 9:
							num = -1309104478;
							continue;
						case 10:
							wrXVBFCfgNuHIneUWnRuBPqWmFE = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[vQmqktEhURpyEPPKqSMuPuoewoF];
							num = -1309104476;
							continue;
						default:
							return false;
						}
						break;
						IL_014c:
						int num2;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions == null)
						{
							num = -1309104475;
							num2 = num;
						}
						else
						{
							num = -1309104480;
							num2 = num;
						}
						continue;
						IL_00e7:
						int num3;
						if (vCRAmFictOEOBdRPRyeSyiCGEQP.userAssignable)
						{
							num = -1309104473;
							num3 = num;
						}
						else
						{
							num = -1309104465;
							num3 = num;
						}
						continue;
						IL_0098:
						int num4;
						if (!wrXVBFCfgNuHIneUWnRuBPqWmFE.userAssignable)
						{
							num = -1309104465;
							num4 = num;
						}
						else
						{
							num = -1309104479;
							num4 = num;
						}
						continue;
						IL_0108:
						int num5;
						if (vQmqktEhURpyEPPKqSMuPuoewoF >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions.Count)
						{
							num = -1309104475;
							num5 = num;
						}
						else
						{
							num = -1309104471;
							num5 = num;
						}
					}
					goto default;
					IL_0070:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = -1309104466;
					goto IL_001a;
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
			}

			[DebuggerHidden]
			public ZotaUMpuLztLMbkYAFrBEigzqW(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -803764284;
					while (true)
					{
						switch (num ^ -803764283)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						num = -803764281;
					}
				}
			}
		}

		private sealed class sjUeSbgHePKoKMrjwjPKInRKXXh : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int ktxHeAJoixVrrIIOErBRXCCRTEU;

			public int IslvJkdNnYgqpcjgGkeWfRAPXtg;

			public bool FIDfkGGDLvsUMbeqZnGjNtUXzxCk;

			public bool BkjeYOTUtMCPLytEMfMWAwuYdGw;

			public int vZxBRCiNqRWifHHhzSKzmAMlxxXB;

			public InputAction ihifXlesUksWZLvjcgJfXzurKOvc;

			public int syuORrDGdIjOOxJWigsHnxVfeBB;

			public IEnumerator<int> KBORqVwXnVcSpKpHeoypSTBRBlU;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				sjUeSbgHePKoKMrjwjPKInRKXXh sjUeSbgHePKoKMrjwjPKInRKXXh2 = default(sjUeSbgHePKoKMrjwjPKInRKXXh);
				while (true)
				{
					switch (num ^ -1983089180)
					{
					case 2:
						break;
					case 1:
						sjUeSbgHePKoKMrjwjPKInRKXXh2 = this;
						num = -1983089177;
						continue;
					case 0:
						goto IL_004e;
					default:
						sjUeSbgHePKoKMrjwjPKInRKXXh2.ktxHeAJoixVrrIIOErBRXCCRTEU = IslvJkdNnYgqpcjgGkeWfRAPXtg;
						sjUeSbgHePKoKMrjwjPKInRKXXh2.FIDfkGGDLvsUMbeqZnGjNtUXzxCk = BkjeYOTUtMCPLytEMfMWAwuYdGw;
						return sjUeSbgHePKoKMrjwjPKInRKXXh2;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				sjUeSbgHePKoKMrjwjPKInRKXXh2 = new sjUeSbgHePKoKMrjwjPKInRKXXh(0);
				sjUeSbgHePKoKMrjwjPKInRKXXh2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -1983089177;
				goto IL_0028;
				IL_0023:
				num = -1983089179;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = -209641986;
						while (true)
						{
							switch (num ^ -209641990)
							{
							case 14:
								break;
							case 12:
							{
								int num2;
								if (syuORrDGdIjOOxJWigsHnxVfeBB >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions.Count)
								{
									num = -209641990;
									num2 = num;
								}
								else
								{
									num = -209641991;
									num2 = num;
								}
								continue;
							}
							case 13:
								syuORrDGdIjOOxJWigsHnxVfeBB++;
								num = -209641994;
								continue;
							case 5:
								if (!KBORqVwXnVcSpKpHeoypSTBRBlU.MoveNext())
								{
									eXftKEOBRvaCbMKWzGcMiuzQIutc();
									num = -209641990;
									continue;
								}
								goto case 8;
							case 11:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -209641985;
								continue;
							case 6:
								goto IL_00ca;
							case 9:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -209641985;
								continue;
							case 1:
								goto IL_0133;
							case 3:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[syuORrDGdIjOOxJWigsHnxVfeBB].categoryId == ktxHeAJoixVrrIIOErBRXCCRTEU)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[syuORrDGdIjOOxJWigsHnxVfeBB];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
									return true;
								}
								goto case 13;
							case 2:
								return true;
							case 7:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ihifXlesUksWZLvjcgJfXzurKOvc;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								num = -209641992;
								continue;
							case 10:
								syuORrDGdIjOOxJWigsHnxVfeBB = 0;
								num = -209641994;
								continue;
							case 8:
							{
								vZxBRCiNqRWifHHhzSKzmAMlxxXB = KBORqVwXnVcSpKpHeoypSTBRBlU.Current;
								ihifXlesUksWZLvjcgJfXzurKOvc = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionById(vZxBRCiNqRWifHHhzSKzmAMlxxXB);
								int num3;
								if (ihifXlesUksWZLvjcgJfXzurKOvc != null)
								{
									num = -209641987;
									num3 = num;
								}
								else
								{
									num = -209641985;
									num3 = num;
								}
								continue;
							}
							case 4:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 2:
									break;
								case 0:
									goto IL_00ca;
								case 3:
									goto IL_0133;
								default:
									goto IL_0237;
								case 1:
									goto IL_0241;
								}
								goto case 11;
							default:
								goto IL_0241;
								IL_0237:
								num = -209641990;
								continue;
								IL_0133:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -209641993;
								continue;
								IL_00ca:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories != null)
								{
									if (FIDfkGGDLvsUMbeqZnGjNtUXzxCk)
									{
										KBORqVwXnVcSpKpHeoypSTBRBlU = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SortedActionIdsInCategory(ktxHeAJoixVrrIIOErBRXCCRTEU).GetEnumerator();
										num = -209641997;
										continue;
									}
									goto case 10;
								}
								goto IL_0241;
								IL_0241:
								return false;
							}
							break;
						}
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						eXftKEOBRvaCbMKWzGcMiuzQIutc();
					}
				}
			}

			[DebuggerHidden]
			public sjUeSbgHePKoKMrjwjPKInRKXXh(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void eXftKEOBRvaCbMKWzGcMiuzQIutc()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				while (true)
				{
					int num = -1697393488;
					while (true)
					{
						switch (num ^ -1697393487)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (KBORqVwXnVcSpKpHeoypSTBRBlU != null)
							{
								goto IL_002d;
							}
							return;
						case 2:
							return;
						}
						break;
						IL_002d:
						KBORqVwXnVcSpKpHeoypSTBRBlU.Dispose();
						num = -1697393485;
					}
				}
			}
		}

		private sealed class wxoaBFKrZxGEuXYpPjcTeUItJDXg : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string VQfeONMHIFtvBBsKqofjtwsrlck;

			public string QzBklCBSFmgoTfXfgsewRZtlNbdq;

			public bool FIDfkGGDLvsUMbeqZnGjNtUXzxCk;

			public bool BkjeYOTUtMCPLytEMfMWAwuYdGw;

			public int VtSEaRhdyMKSSDZttFDIWwVDpPU;

			public InputCategory ivEnifUbkdeGQXsCDeCJKtFQCDZA;

			public int KoXCRwGwQmEoUyCrbKAyCNvTkno;

			public InputAction DPcfadYGNOhkfhZpGJDyRQCwXQe;

			public int YmZytEfkkStZPBCpneASKGaVNnH;

			public IEnumerator<int> ZLDbMElsqoNWqRjlLrjjaKzEfqwf;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0065;
				IL_0012:
				int num = 1847412111;
				goto IL_0017;
				IL_0017:
				wxoaBFKrZxGEuXYpPjcTeUItJDXg wxoaBFKrZxGEuXYpPjcTeUItJDXg2 = default(wxoaBFKrZxGEuXYpPjcTeUItJDXg);
				while (true)
				{
					switch (num ^ 0x6E1D458C)
					{
					case 0:
						break;
					case 3:
						goto IL_003c;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						num = 1847412105;
						continue;
					case 2:
						goto IL_0065;
					case 5:
						wxoaBFKrZxGEuXYpPjcTeUItJDXg2 = this;
						num = 1847412104;
						continue;
					default:
						wxoaBFKrZxGEuXYpPjcTeUItJDXg2.VQfeONMHIFtvBBsKqofjtwsrlck = QzBklCBSFmgoTfXfgsewRZtlNbdq;
						wxoaBFKrZxGEuXYpPjcTeUItJDXg2.FIDfkGGDLvsUMbeqZnGjNtUXzxCk = BkjeYOTUtMCPLytEMfMWAwuYdGw;
						return wxoaBFKrZxGEuXYpPjcTeUItJDXg2;
					}
					break;
					IL_003c:
					int num2;
					if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
					{
						num = 1847412110;
						num2 = num;
					}
					else
					{
						num = 1847412109;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0065:
				wxoaBFKrZxGEuXYpPjcTeUItJDXg2 = new wxoaBFKrZxGEuXYpPjcTeUItJDXg(0);
				wxoaBFKrZxGEuXYpPjcTeUItJDXg2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 1847412104;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 207170118;
						goto IL_0022;
					case 2:
						goto IL_009f;
					case 0:
						goto IL_0168;
					case 3:
						goto IL_0282;
					case 1:
						break;
						IL_0022:
						while (true)
						{
							switch (num ^ 0xC592A41)
							{
							case 0:
								break;
							case 1:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[YmZytEfkkStZPBCpneASKGaVNnH];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								result = true;
								goto end_IL_0000;
							case 6:
								goto IL_009f;
							case 13:
								goto IL_00b0;
							case 10:
								goto IL_00dc;
							case 12:
								KoXCRwGwQmEoUyCrbKAyCNvTkno = ZLDbMElsqoNWqRjlLrjjaKzEfqwf.Current;
								DPcfadYGNOhkfhZpGJDyRQCwXQe = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionById(KoXCRwGwQmEoUyCrbKAyCNvTkno);
								if (DPcfadYGNOhkfhZpGJDyRQCwXQe != null)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = DPcfadYGNOhkfhZpGJDyRQCwXQe;
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
									num = 207170114;
									continue;
								}
								goto case 8;
							case 9:
								goto IL_0168;
							case 4:
								YmZytEfkkStZPBCpneASKGaVNnH++;
								num = 207170124;
								continue;
							case 14:
								goto IL_023b;
							case 5:
								goto end_IL_0000;
							case 7:
								num = 207170115;
								continue;
							case 8:
								if (!ZLDbMElsqoNWqRjlLrjjaKzEfqwf.MoveNext())
								{
									YEwaBSTKEzhBhHKXhXeEcKocLWn();
									num = 207170115;
									continue;
								}
								goto case 12;
							case 11:
								goto IL_0282;
							case 3:
								result = true;
								num = 207170116;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00dc:
							int num2;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[YmZytEfkkStZPBCpneASKGaVNnH].categoryId == ivEnifUbkdeGQXsCDeCJKtFQCDZA.id)
							{
								num = 207170112;
								num2 = num;
							}
							else
							{
								num = 207170117;
								num2 = num;
							}
							continue;
							IL_00b0:
							int num3;
							if (YmZytEfkkStZPBCpneASKGaVNnH >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions.Count)
							{
								num = 207170115;
								num3 = num;
							}
							else
							{
								num = 207170123;
								num3 = num;
							}
						}
						goto default;
						IL_0282:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 207170117;
						goto IL_0022;
						IL_0168:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions == null || ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories == null || VQfeONMHIFtvBBsKqofjtwsrlck == null || VQfeONMHIFtvBBsKqofjtwsrlck == string.Empty)
						{
							break;
						}
						VtSEaRhdyMKSSDZttFDIWwVDpPU = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.IndexOfActionCategory(VQfeONMHIFtvBBsKqofjtwsrlck);
						if (VtSEaRhdyMKSSDZttFDIWwVDpPU < 0)
						{
							break;
						}
						ivEnifUbkdeGQXsCDeCJKtFQCDZA = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionCategory(VtSEaRhdyMKSSDZttFDIWwVDpPU);
						if (FIDfkGGDLvsUMbeqZnGjNtUXzxCk)
						{
							ZLDbMElsqoNWqRjlLrjjaKzEfqwf = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SortedActionIdsInCategory(ivEnifUbkdeGQXsCDeCJKtFQCDZA.id).GetEnumerator();
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							num = 207170121;
							goto IL_0022;
						}
						goto IL_023b;
						IL_023b:
						YmZytEfkkStZPBCpneASKGaVNnH = 0;
						num = 207170124;
						goto IL_0022;
						IL_009f:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 207170121;
						goto IL_0022;
						end_IL_0008:
						break;
					}
					result = false;
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						YEwaBSTKEzhBhHKXhXeEcKocLWn();
					}
				}
			}

			[DebuggerHidden]
			public wxoaBFKrZxGEuXYpPjcTeUItJDXg(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void YEwaBSTKEzhBhHKXhXeEcKocLWn()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (ZLDbMElsqoNWqRjlLrjjaKzEfqwf != null)
				{
					ZLDbMElsqoNWqRjlLrjjaKzEfqwf.Dispose();
				}
			}
		}

		private sealed class pIEOFjVYeoecLNTdPsdBODyFmTe : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string gOLsIvUagYjTsnfFxoDrjCWKnIG;

			public string PqgqlyVpPbbxVBxonFUFLIlCcziX;

			public int aypvxFkbzebbxWQiGafGjoiZEudB;

			public int ezEetCNKFhgihEwDPHPsrMchLWaF;

			public InputCategory bVmJxeBiNPtjynXpIOZIPufvfwM;

			public int oErsWyRpuggwKOTKrkvUCNUFWGA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_0070;
				IL_0070:
				pIEOFjVYeoecLNTdPsdBODyFmTe pIEOFjVYeoecLNTdPsdBODyFmTe2 = new pIEOFjVYeoecLNTdPsdBODyFmTe(0);
				int num = -110693477;
				goto IL_0021;
				IL_001c:
				num = -110693475;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -110693479)
					{
					case 0:
						break;
					case 3:
						pIEOFjVYeoecLNTdPsdBODyFmTe2.gOLsIvUagYjTsnfFxoDrjCWKnIG = PqgqlyVpPbbxVBxonFUFLIlCcziX;
						num = -110693473;
						continue;
					case 2:
						pIEOFjVYeoecLNTdPsdBODyFmTe2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -110693478;
						continue;
					case 1:
						goto IL_0070;
					case 5:
						num = -110693478;
						continue;
					case 4:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						pIEOFjVYeoecLNTdPsdBODyFmTe2 = this;
						num = -110693476;
						continue;
					default:
						return pIEOFjVYeoecLNTdPsdBODyFmTe2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					int num2;
					if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions == null)
					{
						num = -1671243860;
						num2 = num;
					}
					else
					{
						num = -1671243858;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -1671243867;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1671243867)
						{
						case 5:
							num = -1671243863;
							continue;
						case 12:
							break;
						case 0:
							oErsWyRpuggwKOTKrkvUCNUFWGA++;
							num = -1671243865;
							continue;
						case 2:
							goto IL_009d;
						case 6:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[ezEetCNKFhgihEwDPHPsrMchLWaF].tag.Equals(gOLsIvUagYjTsnfFxoDrjCWKnIG, StringComparison.OrdinalIgnoreCase))
							{
								bVmJxeBiNPtjynXpIOZIPufvfwM = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories[ezEetCNKFhgihEwDPHPsrMchLWaF];
								oErsWyRpuggwKOTKrkvUCNUFWGA = 0;
								num = -1671243865;
								continue;
							}
							goto case 1;
						case 1:
							ezEetCNKFhgihEwDPHPsrMchLWaF++;
							num = -1671243870;
							continue;
						case 3:
							num = -1671243870;
							continue;
						case 7:
							goto IL_0137;
						case 4:
							if (gOLsIvUagYjTsnfFxoDrjCWKnIG != null && !(gOLsIvUagYjTsnfFxoDrjCWKnIG == string.Empty))
							{
								aypvxFkbzebbxWQiGafGjoiZEudB = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions.Count;
								ezEetCNKFhgihEwDPHPsrMchLWaF = 0;
								num = -1671243866;
								continue;
							}
							goto end_IL_0008;
						case 8:
							goto IL_01aa;
						case 11:
							goto IL_01e6;
						case 10:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[oErsWyRpuggwKOTKrkvUCNUFWGA];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						default:
							goto end_IL_0008;
						}
						break;
						IL_01e6:
						int num3;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories == null)
						{
							num = -1671243860;
							num3 = num;
						}
						else
						{
							num = -1671243871;
							num3 = num;
						}
						continue;
						IL_0137:
						int num4;
						if (ezEetCNKFhgihEwDPHPsrMchLWaF < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories.Count)
						{
							num = -1671243869;
							num4 = num;
						}
						else
						{
							num = -1671243860;
							num4 = num;
						}
						continue;
						IL_009d:
						int num5;
						if (oErsWyRpuggwKOTKrkvUCNUFWGA < aypvxFkbzebbxWQiGafGjoiZEudB)
						{
							num = -1671243859;
							num5 = num;
						}
						else
						{
							num = -1671243868;
							num5 = num;
						}
						continue;
						IL_01aa:
						int num6;
						if (bVmJxeBiNPtjynXpIOZIPufvfwM.id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[oErsWyRpuggwKOTKrkvUCNUFWGA].categoryId)
						{
							num = -1671243867;
							num6 = num;
						}
						else
						{
							num = -1671243857;
							num6 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public pIEOFjVYeoecLNTdPsdBODyFmTe(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 1201969232;
					while (true)
					{
						switch (num ^ 0x47A49851)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						num = 1201969235;
					}
				}
			}
		}

		private sealed class wKolCALPFbAlWSSlsIaLhVcIHOtx : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int ktxHeAJoixVrrIIOErBRXCCRTEU;

			public int IslvJkdNnYgqpcjgGkeWfRAPXtg;

			public bool FIDfkGGDLvsUMbeqZnGjNtUXzxCk;

			public bool BkjeYOTUtMCPLytEMfMWAwuYdGw;

			public InputCategory gBYGOWXDbFdjCgLhyGJNNYrKnTj;

			public int aHyJulmMlMtwUCZqNgrJovHIARL;

			public InputAction bUKvCZVMBTGvSVsJIBpiIYqJblY;

			public int MSPgoQjIpPBaxDzTmISLdHRyeqFq;

			public InputAction bgRlAxETRrPQoQoPmIrVDFKYRozL;

			public IEnumerator<int> iryKuNKCyFFvxxXNYVEwDdoeaJO;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_0059;
				IL_0059:
				wKolCALPFbAlWSSlsIaLhVcIHOtx wKolCALPFbAlWSSlsIaLhVcIHOtx2 = new wKolCALPFbAlWSSlsIaLhVcIHOtx(0);
				int num = 479537658;
				goto IL_0021;
				IL_001c:
				num = 479537656;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x1C9529FA)
					{
					case 4:
						break;
					case 0:
						wKolCALPFbAlWSSlsIaLhVcIHOtx2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 479537663;
						continue;
					case 1:
						goto IL_0059;
					case 3:
						wKolCALPFbAlWSSlsIaLhVcIHOtx2 = this;
						num = 479537663;
						continue;
					case 2:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						num = 479537657;
						continue;
					default:
						wKolCALPFbAlWSSlsIaLhVcIHOtx2.ktxHeAJoixVrrIIOErBRXCCRTEU = IslvJkdNnYgqpcjgGkeWfRAPXtg;
						wKolCALPFbAlWSSlsIaLhVcIHOtx2.FIDfkGGDLvsUMbeqZnGjNtUXzxCk = BkjeYOTUtMCPLytEMfMWAwuYdGw;
						return wKolCALPFbAlWSSlsIaLhVcIHOtx2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 1849375127;
						goto IL_0022;
					case 2:
						goto IL_00a6;
					case 3:
						goto IL_016f;
					case 0:
						goto IL_0220;
					case 1:
						goto IL_02d4;
						IL_0022:
						while (true)
						{
							switch (num ^ 0x6E3B3984)
							{
							case 12:
								break;
							default:
								goto end_IL_0008;
							case 16:
								MSPgoQjIpPBaxDzTmISLdHRyeqFq = 0;
								num = 1849375104;
								continue;
							case 7:
								RDkWcsTpvDaNZojjIZONnoEBXPC = bgRlAxETRrPQoQoPmIrVDFKYRozL;
								num = 1849375118;
								continue;
							case 15:
								goto IL_00a6;
							case 17:
								gBYGOWXDbFdjCgLhyGJNNYrKnTj = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionCategoryById(ktxHeAJoixVrrIIOErBRXCCRTEU);
								if (gBYGOWXDbFdjCgLhyGJNNYrKnTj != null && gBYGOWXDbFdjCgLhyGJNNYrKnTj.userAssignable)
								{
									if (FIDfkGGDLvsUMbeqZnGjNtUXzxCk)
									{
										iryKuNKCyFFvxxXNYVEwDdoeaJO = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SortedActionIdsInCategory(gBYGOWXDbFdjCgLhyGJNNYrKnTj.id).GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 1849375105;
										continue;
									}
									goto case 16;
								}
								goto IL_02d4;
							case 5:
								num = 1849375111;
								continue;
							case 2:
								goto IL_012d;
							case 18:
								goto IL_014e;
							case 9:
								goto IL_016f;
							case 3:
								if (!iryKuNKCyFFvxxXNYVEwDdoeaJO.MoveNext())
								{
									CtNDGBhmAlfDIFPnaiNPIjgxrkPy();
									num = 1849375113;
									continue;
								}
								goto case 11;
							case 14:
								result = true;
								goto end_IL_0008;
							case 11:
								aHyJulmMlMtwUCZqNgrJovHIARL = iryKuNKCyFFvxxXNYVEwDdoeaJO.Current;
								bUKvCZVMBTGvSVsJIBpiIYqJblY = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionById(aHyJulmMlMtwUCZqNgrJovHIARL);
								if (bUKvCZVMBTGvSVsJIBpiIYqJblY != null && bUKvCZVMBTGvSVsJIBpiIYqJblY.userAssignable)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = bUKvCZVMBTGvSVsJIBpiIYqJblY;
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
									num = 1849375114;
									continue;
								}
								goto case 3;
							case 10:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								result = true;
								goto end_IL_0008;
							case 1:
								goto IL_0220;
							case 8:
								bgRlAxETRrPQoQoPmIrVDFKYRozL = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[MSPgoQjIpPBaxDzTmISLdHRyeqFq];
								if (bgRlAxETRrPQoQoPmIrVDFKYRozL.categoryId == gBYGOWXDbFdjCgLhyGJNNYrKnTj.id)
								{
									goto IL_0265;
								}
								goto case 0;
							case 4:
								goto IL_0286;
							case 0:
								MSPgoQjIpPBaxDzTmISLdHRyeqFq++;
								num = 1849375104;
								continue;
							case 19:
								num = 1849375113;
								continue;
							case 13:
								goto IL_02d4;
							case 6:
								goto end_IL_0008;
							}
							break;
							IL_0286:
							int num2;
							if (MSPgoQjIpPBaxDzTmISLdHRyeqFq < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions.Count)
							{
								num = 1849375116;
								num2 = num;
							}
							else
							{
								num = 1849375113;
								num2 = num;
							}
							continue;
							IL_014e:
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions != null)
							{
								num = 1849375110;
								num3 = num;
							}
							else
							{
								num = 1849375113;
								num3 = num;
							}
							continue;
							IL_012d:
							int num4;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories == null)
							{
								num = 1849375113;
								num4 = num;
							}
							else
							{
								num = 1849375125;
								num4 = num;
							}
							continue;
							IL_0265:
							int num5;
							if (bgRlAxETRrPQoQoPmIrVDFKYRozL.userAssignable)
							{
								num = 1849375107;
								num5 = num;
							}
							else
							{
								num = 1849375108;
								num5 = num;
							}
						}
						goto default;
						IL_0220:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 1849375126;
						goto IL_0022;
						IL_016f:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 1849375108;
						goto IL_0022;
						IL_02d4:
						result = false;
						num = 1849375106;
						goto IL_0022;
						IL_00a6:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 1849375111;
						goto IL_0022;
						end_IL_0008:
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -2089091106;
					while (true)
					{
						switch (num ^ -2089091105)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 1:
							case 2:
								try
								{
									return;
								}
								finally
								{
									CtNDGBhmAlfDIFPnaiNPIjgxrkPy();
								}
							}
							goto IL_0035;
						case 2:
							return;
						}
						break;
						IL_0035:
						num = -2089091107;
					}
				}
			}

			[DebuggerHidden]
			public wKolCALPFbAlWSSlsIaLhVcIHOtx(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void CtNDGBhmAlfDIFPnaiNPIjgxrkPy()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				while (true)
				{
					int num = -1115441436;
					while (true)
					{
						switch (num ^ -1115441435)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (iryKuNKCyFFvxxXNYVEwDdoeaJO != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						iryKuNKCyFFvxxXNYVEwDdoeaJO.Dispose();
						num = -1115441435;
					}
				}
			}
		}

		private sealed class hmgqutNeqAYOagOVSSskszwThei : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public string fqVKGKSmOPwWMIbiISpfIxYKkcG;

			public string NZzUPDHUUChjMwEWTcsNKFtpoea;

			public bool FIDfkGGDLvsUMbeqZnGjNtUXzxCk;

			public bool BkjeYOTUtMCPLytEMfMWAwuYdGw;

			public InputCategory uLEnPhtTAffUYfVmAPfRvQdDjaz;

			public int vSdnBfUwNlYaNBrKgDZOLOBGuHi;

			public InputAction vPUvGbHfmUSqJYOprjLuUCRbKGj;

			public int XbYeUyGulcxLOPTqKAHpERjBzZP;

			public InputAction nciGrMJKYmmQPhNxrYigsodWaQz;

			public IEnumerator<int> hBrTUfdqerMQQxeHqiXhZVmZlRj;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_0059;
				IL_0059:
				hmgqutNeqAYOagOVSSskszwThei hmgqutNeqAYOagOVSSskszwThei2 = new hmgqutNeqAYOagOVSSskszwThei(0);
				hmgqutNeqAYOagOVSSskszwThei2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				int num = 1336017717;
				goto IL_0021;
				IL_001c:
				num = 1336017718;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x4FA20337)
					{
					case 0:
						break;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						hmgqutNeqAYOagOVSSskszwThei2 = this;
						num = 1336017716;
						continue;
					case 3:
						num = 1336017717;
						continue;
					case 4:
						goto IL_0059;
					default:
						hmgqutNeqAYOagOVSSskszwThei2.fqVKGKSmOPwWMIbiISpfIxYKkcG = NZzUPDHUUChjMwEWTcsNKFtpoea;
						hmgqutNeqAYOagOVSSskszwThei2.FIDfkGGDLvsUMbeqZnGjNtUXzxCk = BkjeYOTUtMCPLytEMfMWAwuYdGw;
						return hmgqutNeqAYOagOVSSskszwThei2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						IL_0007:
						int num = -809854727;
						while (true)
						{
							switch (num ^ -809854733)
							{
							case 4:
								break;
							case 10:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 2:
									goto IL_0098;
								case 3:
									goto IL_00ef;
								case 0:
									goto IL_0148;
								case 1:
									goto IL_030e;
								}
								num = -809854731;
								continue;
							case 13:
								goto IL_0098;
							case 9:
								nciGrMJKYmmQPhNxrYigsodWaQz = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions[XbYeUyGulcxLOPTqKAHpERjBzZP];
								num = -809854745;
								continue;
							case 11:
								if (!hBrTUfdqerMQQxeHqiXhZVmZlRj.MoveNext())
								{
									iQGfZqieSnUECCVXKOqmmJTHCYGp();
									num = -809854733;
									continue;
								}
								goto case 15;
							case 21:
								goto IL_00ef;
							case 14:
							{
								int num3;
								if (uLEnPhtTAffUYfVmAPfRvQdDjaz == null)
								{
									num = -809854731;
									num3 = num;
								}
								else
								{
									num = -809854736;
									num3 = num;
								}
								continue;
							}
							case 7:
								if (vPUvGbHfmUSqJYOprjLuUCRbKGj.userAssignable)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = vPUvGbHfmUSqJYOprjLuUCRbKGj;
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
									result = true;
									num = -809854734;
									continue;
								}
								goto case 11;
							case 17:
								goto IL_0148;
							case 19:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								num = -809854725;
								continue;
							case 15:
							{
								vSdnBfUwNlYaNBrKgDZOLOBGuHi = hBrTUfdqerMQQxeHqiXhZVmZlRj.Current;
								vPUvGbHfmUSqJYOprjLuUCRbKGj = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionById(vSdnBfUwNlYaNBrKgDZOLOBGuHi);
								int num5;
								if (vPUvGbHfmUSqJYOprjLuUCRbKGj != null)
								{
									num = -809854732;
									num5 = num;
								}
								else
								{
									num = -809854728;
									num5 = num;
								}
								continue;
							}
							case 3:
								if (uLEnPhtTAffUYfVmAPfRvQdDjaz.userAssignable)
								{
									if (FIDfkGGDLvsUMbeqZnGjNtUXzxCk)
									{
										hBrTUfdqerMQQxeHqiXhZVmZlRj = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SortedActionIdsInCategory(uLEnPhtTAffUYfVmAPfRvQdDjaz.id).GetEnumerator();
										num = -809854735;
										continue;
									}
									goto case 22;
								}
								goto IL_030e;
							case 16:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions != null)
								{
									int num4;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories == null)
									{
										num = -809854731;
										num4 = num;
									}
									else
									{
										num = -809854721;
										num4 = num;
									}
									continue;
								}
								goto IL_030e;
							case 20:
								if (nciGrMJKYmmQPhNxrYigsodWaQz.categoryId == uLEnPhtTAffUYfVmAPfRvQdDjaz.id && nciGrMJKYmmQPhNxrYigsodWaQz.userAssignable)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = nciGrMJKYmmQPhNxrYigsodWaQz;
									num = -809854752;
									continue;
								}
								goto case 18;
							case 18:
								XbYeUyGulcxLOPTqKAHpERjBzZP++;
								num = -809854730;
								continue;
							case 8:
								result = true;
								goto end_IL_000c;
							case 0:
								num = -809854731;
								continue;
							case 5:
							{
								int num2;
								if (XbYeUyGulcxLOPTqKAHpERjBzZP >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions.Count)
								{
									num = -809854731;
									num2 = num;
								}
								else
								{
									num = -809854726;
									num2 = num;
								}
								continue;
							}
							case 1:
								goto end_IL_000c;
							case 22:
								XbYeUyGulcxLOPTqKAHpERjBzZP = 0;
								num = -809854730;
								continue;
							case 12:
								uLEnPhtTAffUYfVmAPfRvQdDjaz = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionCategory(fqVKGKSmOPwWMIbiISpfIxYKkcG);
								num = -809854723;
								continue;
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -809854728;
								continue;
							default:
								goto IL_030e;
								IL_030e:
								result = false;
								goto end_IL_000c;
								IL_0148:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -809854749;
								continue;
								IL_00ef:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -809854751;
								continue;
								IL_0098:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -809854728;
								continue;
							}
							goto IL_0007;
							continue;
							end_IL_000c:
							break;
						}
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						iQGfZqieSnUECCVXKOqmmJTHCYGp();
					}
				}
			}

			[DebuggerHidden]
			public hmgqutNeqAYOagOVSSskszwThei(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void iQGfZqieSnUECCVXKOqmmJTHCYGp()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (hBrTUfdqerMQQxeHqiXhZVmZlRj != null)
				{
					hBrTUfdqerMQQxeHqiXhZVmZlRj.Dispose();
				}
			}
		}

		private sealed class SPMiJDtDwELaRhatgCXWifFKtdI : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int IcfehugnHVBDSlLvDDweqELIXNqm;

			public int yDlfINvlLfFwFxkZYfdNACzTPYB;

			public int DVNcNhisEEDjTgNSalxEKOxlcHjP;

			public InputAction dWIXJOGLsiNbSAFllkCCuOerggK;

			public IEnumerator<int> eNNIOUoLJjTEJgagrOTPVEfdZhO;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0052;
				IL_0012:
				int num = -1621987922;
				goto IL_0017;
				IL_0017:
				SPMiJDtDwELaRhatgCXWifFKtdI sPMiJDtDwELaRhatgCXWifFKtdI = default(SPMiJDtDwELaRhatgCXWifFKtdI);
				while (true)
				{
					switch (num ^ -1621987921)
					{
					case 0:
						break;
					case 1:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							sPMiJDtDwELaRhatgCXWifFKtdI = this;
							num = -1621987924;
							continue;
						}
						goto IL_0052;
					case 4:
						goto IL_0052;
					case 3:
						num = -1621987923;
						continue;
					default:
						sPMiJDtDwELaRhatgCXWifFKtdI.IcfehugnHVBDSlLvDDweqELIXNqm = yDlfINvlLfFwFxkZYfdNACzTPYB;
						return sPMiJDtDwELaRhatgCXWifFKtdI;
					}
					break;
				}
				goto IL_0012;
				IL_0052:
				sPMiJDtDwELaRhatgCXWifFKtdI = new SPMiJDtDwELaRhatgCXWifFKtdI(0);
				sPMiJDtDwELaRhatgCXWifFKtdI.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -1621987923;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num;
					int num2;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 2:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 193809674;
						goto IL_0023;
					case 0:
						goto IL_006c;
						IL_0023:
						while (true)
						{
							switch (num ^ 0xB8D4D0F)
							{
							case 8:
								num = 193809678;
								continue;
							case 6:
								num = 193809674;
								continue;
							case 0:
								break;
							case 1:
								goto IL_006c;
							case 7:
								eNNIOUoLJjTEJgagrOTPVEfdZhO = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategoryMap.ActionIdsInCategory(IcfehugnHVBDSlLvDDweqELIXNqm).GetEnumerator();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 193809673;
								continue;
							case 3:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								return true;
							case 5:
								if (!eNNIOUoLJjTEJgagrOTPVEfdZhO.MoveNext())
								{
									hDvHJajozWBsJNjYBOoFDwWiaRgQ();
									num = 193809677;
									continue;
								}
								goto case 4;
							case 4:
								DVNcNhisEEDjTgNSalxEKOxlcHjP = eNNIOUoLJjTEJgagrOTPVEfdZhO.Current;
								dWIXJOGLsiNbSAFllkCCuOerggK = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionById(DVNcNhisEEDjTgNSalxEKOxlcHjP);
								if (dWIXJOGLsiNbSAFllkCCuOerggK != null)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = dWIXJOGLsiNbSAFllkCCuOerggK.name;
									num = 193809676;
									continue;
								}
								goto case 5;
							default:
								goto end_IL_0008;
							}
							break;
						}
						goto case 2;
						IL_006c:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories == null)
						{
							break;
						}
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions == null)
						{
							num = 193809677;
							num2 = num;
						}
						else
						{
							num = 193809672;
							num2 = num;
						}
						goto IL_0023;
						end_IL_0008:
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						hDvHJajozWBsJNjYBOoFDwWiaRgQ();
					}
				}
			}

			[DebuggerHidden]
			public SPMiJDtDwELaRhatgCXWifFKtdI(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 1143743028;
					while (true)
					{
						switch (num ^ 0x442C2236)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
						num = 1143743031;
					}
				}
			}

			private void hDvHJajozWBsJNjYBOoFDwWiaRgQ()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (eNNIOUoLJjTEJgagrOTPVEfdZhO != null)
				{
					eNNIOUoLJjTEJgagrOTPVEfdZhO.Dispose();
				}
			}
		}

		private sealed class ERpBNmHuSwmLyxxeaDVyiHeDnDTH : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int IcfehugnHVBDSlLvDDweqELIXNqm;

			public int yDlfINvlLfFwFxkZYfdNACzTPYB;

			public int XmOyauvPkvImRiPXfMnjiEVkEOnB;

			public InputAction lSLwtdreJxTfnDUzlVCKtCVQfcQ;

			public IEnumerator<int> gHVuxPHaZDHJpDaLxPGcTnJSjIy;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				ERpBNmHuSwmLyxxeaDVyiHeDnDTH eRpBNmHuSwmLyxxeaDVyiHeDnDTH = default(ERpBNmHuSwmLyxxeaDVyiHeDnDTH);
				while (true)
				{
					switch (num ^ -683476317)
					{
					case 0:
						break;
					case 3:
						eRpBNmHuSwmLyxxeaDVyiHeDnDTH = this;
						num = -683476319;
						continue;
					case 1:
						goto IL_004e;
					default:
						eRpBNmHuSwmLyxxeaDVyiHeDnDTH.IcfehugnHVBDSlLvDDweqELIXNqm = yDlfINvlLfFwFxkZYfdNACzTPYB;
						return eRpBNmHuSwmLyxxeaDVyiHeDnDTH;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				eRpBNmHuSwmLyxxeaDVyiHeDnDTH = new ERpBNmHuSwmLyxxeaDVyiHeDnDTH(0);
				eRpBNmHuSwmLyxxeaDVyiHeDnDTH.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -683476319;
				goto IL_0028;
				IL_0023:
				num = -683476320;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						goto IL_005b;
					case 2:
						goto IL_0097;
					default:
						goto IL_0145;
						IL_005b:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories != null)
						{
							int num2;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions == null)
							{
								num = 372274611;
								num2 = num;
							}
							else
							{
								num = 372274610;
								num2 = num;
							}
							goto IL_0023;
						}
						goto IL_0145;
						IL_0145:
						result = false;
						num = 372274609;
						goto IL_0023;
						IL_0023:
						while (true)
						{
							switch (num ^ 0x163075B1)
							{
							case 8:
								num = 372274608;
								continue;
							case 1:
								goto IL_005b;
							case 4:
								num = 372274614;
								continue;
							case 6:
								goto IL_0097;
							case 9:
								XmOyauvPkvImRiPXfMnjiEVkEOnB = gHVuxPHaZDHJpDaLxPGcTnJSjIy.Current;
								lSLwtdreJxTfnDUzlVCKtCVQfcQ = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.GetActionById(XmOyauvPkvImRiPXfMnjiEVkEOnB);
								if (lSLwtdreJxTfnDUzlVCKtCVQfcQ != null)
								{
									RDkWcsTpvDaNZojjIZONnoEBXPC = lSLwtdreJxTfnDUzlVCKtCVQfcQ.descriptiveName;
									num = 372274612;
									continue;
								}
								goto case 7;
							case 3:
								gHVuxPHaZDHJpDaLxPGcTnJSjIy = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategoryMap.ActionIdsInCategory(IcfehugnHVBDSlLvDDweqELIXNqm).GetEnumerator();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 372274613;
								continue;
							case 7:
								if (!gHVuxPHaZDHJpDaLxPGcTnJSjIy.MoveNext())
								{
									lEkovFTTfnDxhluvCEYLLfJwBsj();
									num = 372274611;
									continue;
								}
								goto case 9;
							case 2:
								goto IL_0145;
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								result = true;
								break;
							case 0:
								break;
							}
							break;
						}
						break;
						IL_0097:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 372274614;
						goto IL_0023;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						lEkovFTTfnDxhluvCEYLLfJwBsj();
					}
				}
			}

			[DebuggerHidden]
			public ERpBNmHuSwmLyxxeaDVyiHeDnDTH(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -729772615;
					while (true)
					{
						switch (num ^ -729772616)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						num = -729772614;
					}
				}
			}

			private void lEkovFTTfnDxhluvCEYLLfJwBsj()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				while (true)
				{
					int num = 1050120878;
					while (true)
					{
						switch (num ^ 0x3E9792AF)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (gHVuxPHaZDHJpDaLxPGcTnJSjIy != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						gHVuxPHaZDHJpDaLxPGcTnJSjIy.Dispose();
						num = 1050120879;
					}
				}
			}
		}

		private sealed class ZLhxEUKjCqfLrNagWYDMoVnbanm : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public UserData ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int IcfehugnHVBDSlLvDDweqELIXNqm;

			public int yDlfINvlLfFwFxkZYfdNACzTPYB;

			public int ZZWpvYhLWEBUdDbWNcofkuwmHHUG;

			public IEnumerator<int> jUafFozZKPUiiSanmpKlpgphAWk;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				ZLhxEUKjCqfLrNagWYDMoVnbanm zLhxEUKjCqfLrNagWYDMoVnbanm;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					zLhxEUKjCqfLrNagWYDMoVnbanm = this;
				}
				else
				{
					while (true)
					{
						zLhxEUKjCqfLrNagWYDMoVnbanm = new ZLhxEUKjCqfLrNagWYDMoVnbanm(0);
						zLhxEUKjCqfLrNagWYDMoVnbanm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = 1507766962;
						while (true)
						{
							switch (num ^ 0x59DEB2B3)
							{
							case 0:
								num = 1507766961;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				zLhxEUKjCqfLrNagWYDMoVnbanm.IcfehugnHVBDSlLvDDweqELIXNqm = yDlfINvlLfFwFxkZYfdNACzTPYB;
				return zLhxEUKjCqfLrNagWYDMoVnbanm;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					int num2;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 2:
						goto IL_005b;
					case 0:
						goto IL_008a;
					default:
						goto IL_00f4;
						IL_005b:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -99799118;
						goto IL_0023;
						IL_0023:
						while (true)
						{
							switch (num ^ -99799117)
							{
							case 5:
								num = -99799120;
								continue;
							case 8:
								goto IL_005b;
							case 6:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZZWpvYhLWEBUdDbWNcofkuwmHHUG;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								result = true;
								break;
							case 3:
								goto IL_008a;
							case 7:
								num = -99799118;
								continue;
							case 1:
								if (!jUafFozZKPUiiSanmpKlpgphAWk.MoveNext())
								{
									KKHWZNlpjYpDGgHgbaguofkbbwT();
									num = -99799119;
									continue;
								}
								goto case 4;
							case 4:
								ZZWpvYhLWEBUdDbWNcofkuwmHHUG = jUafFozZKPUiiSanmpKlpgphAWk.Current;
								num = -99799115;
								continue;
							case 2:
								goto IL_00f4;
							case 0:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actions != null)
								{
									jUafFozZKPUiiSanmpKlpgphAWk = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategoryMap.ActionIdsInCategory(IcfehugnHVBDSlLvDDweqELIXNqm).GetEnumerator();
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									num = -99799116;
									continue;
								}
								goto IL_00f4;
							case 9:
								break;
							}
							break;
						}
						break;
						IL_00f4:
						result = false;
						num = -99799110;
						goto IL_0023;
						IL_008a:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionCategories != null)
						{
							num = -99799117;
							num2 = num;
						}
						else
						{
							num = -99799119;
							num2 = num;
						}
						goto IL_0023;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -1548107933;
					while (true)
					{
						switch (num ^ -1548107934)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 1:
							case 2:
								try
								{
									return;
								}
								finally
								{
									KKHWZNlpjYpDGgHgbaguofkbbwT();
								}
							}
							goto IL_0035;
						case 2:
							return;
						}
						break;
						IL_0035:
						num = -1548107936;
					}
				}
			}

			[DebuggerHidden]
			public ZLhxEUKjCqfLrNagWYDMoVnbanm(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void KKHWZNlpjYpDGgHgbaguofkbbwT()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (jUafFozZKPUiiSanmpKlpgphAWk != null)
				{
					jUafFozZKPUiiSanmpKlpgphAWk.Dispose();
				}
			}
		}

		private sealed class yKHiOlAfmtuFRRZhsGutrXCxDQt
		{
			private sealed class OMtCGiyAjfRsbTyXSQKiUAouMME
			{
				public yKHiOlAfmtuFRRZhsGutrXCxDQt fCJaBLSFbrlgvzAGIUItNuBxMWh;

				public ControllerMap_Editor ABfeqjpzvjRcvRvJfJKblIZhrhM;

				public ControllerMap_Editor oUggHrhFoPXlKSaVAbqTbtQKHYOi;

				public bool VSvWAZwrAvGeInEvXoOQriEXQPy(InputLayout P_0)
				{
					return P_0.id == ABfeqjpzvjRcvRvJfJKblIZhrhM.id;
				}

				public bool ywyoAdnPBFCMZIkUvGuZHcVDvMD(InputLayout P_0)
				{
					return P_0.id == oUggHrhFoPXlKSaVAbqTbtQKHYOi.id;
				}
			}

			public List<InputLayout> IeiemSKkhKijZaCrFINGtGBZLAT;

			public int EmkxeyDqwTNaZoflyILNpsjCnFn(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				OMtCGiyAjfRsbTyXSQKiUAouMME oMtCGiyAjfRsbTyXSQKiUAouMME = new OMtCGiyAjfRsbTyXSQKiUAouMME();
				while (true)
				{
					int num = 1707592607;
					while (true)
					{
						switch (num ^ 0x65C7CB9D)
						{
						case 0:
							break;
						case 2:
							goto IL_0024;
						default:
						{
							oMtCGiyAjfRsbTyXSQKiUAouMME.oUggHrhFoPXlKSaVAbqTbtQKHYOi = P_1;
							int num2 = IeiemSKkhKijZaCrFINGtGBZLAT.FindIndex(oMtCGiyAjfRsbTyXSQKiUAouMME.VSvWAZwrAvGeInEvXoOQriEXQPy);
							int num3 = IeiemSKkhKijZaCrFINGtGBZLAT.FindIndex(oMtCGiyAjfRsbTyXSQKiUAouMME.ywyoAdnPBFCMZIkUvGuZHcVDvMD);
							if (num2 > num3)
							{
								return 1;
							}
							if (num2 < num3)
							{
								return -1;
							}
							return 0;
						}
						}
						break;
						IL_0024:
						oMtCGiyAjfRsbTyXSQKiUAouMME.fCJaBLSFbrlgvzAGIUItNuBxMWh = this;
						oMtCGiyAjfRsbTyXSQKiUAouMME.ABfeqjpzvjRcvRvJfJKblIZhrhM = P_0;
						num = 1707592604;
					}
				}
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars = new ConfigVars();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Player_Editor> players = new List<Player_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputAction> actions = new List<InputAction>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputCategory> actionCategories = new List<InputCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int playerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int inputBehaviorIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mapCategoryIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int keyboardLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mouseLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickMapIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int keyboardMapIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mouseMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapLayoutManagerSetIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate60;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate62;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate64;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate66;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate68;

		internal IList<Player_Editor> Players_readOnly { get; private set; }

		internal IList<InputAction> Actions_readOnly { get; private set; }

		internal IList<InputCategory> ActionCategories_readOnly { get; private set; }

		internal IList<InputBehavior> InputBehaviors_readOnly { get; private set; }

		internal IList<InputMapCategory> MapCategories_readOnly { get; private set; }

		internal IList<InputLayout> JoystickLayouts_readOnly { get; private set; }

		internal IList<InputLayout> KeyboardLayouts_readOnly { get; private set; }

		internal IList<InputLayout> MouseLayouts_readOnly { get; private set; }

		internal IList<InputLayout> CustomControllerLayouts_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> JoystickMaps_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> KeyboardMaps_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> MouseMaps_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> CustomControllerMaps_readOnly { get; private set; }

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> ControllerMapLayoutManagerRuleSets_readOnly { get; private set; }

		internal IList<ControllerMapEnabler_RuleSet_Editor> ControllerMapEnablerRuleSets_readOnly { get; private set; }

		public ConfigVars ConfigVars
		{
			get
			{
				return configVars;
			}
		}

		internal IEnumerable<InputMapCategory> UserAssignableMapCategories
		{
			get
			{
				eJvyjCvDNezNonWTSTsIaKFKDAa eJvyjCvDNezNonWTSTsIaKFKDAa2 = new eJvyjCvDNezNonWTSTsIaKFKDAa(-2);
				eJvyjCvDNezNonWTSTsIaKFKDAa2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return eJvyjCvDNezNonWTSTsIaKFKDAa2;
			}
		}

		internal IEnumerable<InputCategory> UserAssignableActionCategories
		{
			get
			{
				iTdijQZJWmtqhXBVAApaGDvyBeI iTdijQZJWmtqhXBVAApaGDvyBeI2 = new iTdijQZJWmtqhXBVAApaGDvyBeI(-2);
				iTdijQZJWmtqhXBVAApaGDvyBeI2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return iTdijQZJWmtqhXBVAApaGDvyBeI2;
			}
		}

		internal IEnumerable<InputAction> UserAssignableActions
		{
			get
			{
				ZotaUMpuLztLMbkYAFrBEigzqW zotaUMpuLztLMbkYAFrBEigzqW = new ZotaUMpuLztLMbkYAFrBEigzqW(-2);
				zotaUMpuLztLMbkYAFrBEigzqW.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return zotaUMpuLztLMbkYAFrBEigzqW;
			}
		}

		public int playerCount
		{
			get
			{
				if (players == null)
				{
					return 0;
				}
				return players.Count;
			}
		}

		internal IEnumerable<InputMapCategory> zAqXUEiiUEFjyIPgoSvWHaOOAYO(string P_0)
		{
			oQWMaesNxtkAUTnETBgCArQBpol oQWMaesNxtkAUTnETBgCArQBpol2 = new oQWMaesNxtkAUTnETBgCArQBpol(-2);
			oQWMaesNxtkAUTnETBgCArQBpol2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			oQWMaesNxtkAUTnETBgCArQBpol2.PqgqlyVpPbbxVBxonFUFLIlCcziX = P_0;
			return oQWMaesNxtkAUTnETBgCArQBpol2;
		}

		internal IEnumerable<InputMapCategory> NHcTWDOPpHiAhPfHPFrEdnRjgZGz(string P_0)
		{
			KfRnXFwvjrVKFFJVmqzXciMAWbd kfRnXFwvjrVKFFJVmqzXciMAWbd = new KfRnXFwvjrVKFFJVmqzXciMAWbd(-2);
			kfRnXFwvjrVKFFJVmqzXciMAWbd.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			kfRnXFwvjrVKFFJVmqzXciMAWbd.PqgqlyVpPbbxVBxonFUFLIlCcziX = P_0;
			return kfRnXFwvjrVKFFJVmqzXciMAWbd;
		}

		internal IEnumerable<InputCategory> HbBkzpjPqWKnvmHXweEoqZnJHSj(string P_0)
		{
			YoIKuYxemWUWRtHOwFoTSKgRymF yoIKuYxemWUWRtHOwFoTSKgRymF = new YoIKuYxemWUWRtHOwFoTSKgRymF(-2);
			yoIKuYxemWUWRtHOwFoTSKgRymF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			yoIKuYxemWUWRtHOwFoTSKgRymF.PqgqlyVpPbbxVBxonFUFLIlCcziX = P_0;
			return yoIKuYxemWUWRtHOwFoTSKgRymF;
		}

		internal IEnumerable<InputCategory> xtwCXEiSLmVNHhbFEfXnDCcXIeQh(string P_0)
		{
			UKumDJguFMtydJdQpqrTqPhQEmVC uKumDJguFMtydJdQpqrTqPhQEmVC = new UKumDJguFMtydJdQpqrTqPhQEmVC(-2);
			uKumDJguFMtydJdQpqrTqPhQEmVC.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			uKumDJguFMtydJdQpqrTqPhQEmVC.PqgqlyVpPbbxVBxonFUFLIlCcziX = P_0;
			return uKumDJguFMtydJdQpqrTqPhQEmVC;
		}

		internal IEnumerable<InputAction> MmsXihBHTfkqmUtCgNWsUAsZrwU(int P_0, bool P_1)
		{
			sjUeSbgHePKoKMrjwjPKInRKXXh sjUeSbgHePKoKMrjwjPKInRKXXh2 = new sjUeSbgHePKoKMrjwjPKInRKXXh(-2);
			sjUeSbgHePKoKMrjwjPKInRKXXh2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			sjUeSbgHePKoKMrjwjPKInRKXXh2.IslvJkdNnYgqpcjgGkeWfRAPXtg = P_0;
			sjUeSbgHePKoKMrjwjPKInRKXXh2.BkjeYOTUtMCPLytEMfMWAwuYdGw = P_1;
			return sjUeSbgHePKoKMrjwjPKInRKXXh2;
		}

		internal IEnumerable<InputAction> MmsXihBHTfkqmUtCgNWsUAsZrwU(string P_0, bool P_1)
		{
			wxoaBFKrZxGEuXYpPjcTeUItJDXg wxoaBFKrZxGEuXYpPjcTeUItJDXg2 = new wxoaBFKrZxGEuXYpPjcTeUItJDXg(-2);
			wxoaBFKrZxGEuXYpPjcTeUItJDXg2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			wxoaBFKrZxGEuXYpPjcTeUItJDXg2.QzBklCBSFmgoTfXfgsewRZtlNbdq = P_0;
			wxoaBFKrZxGEuXYpPjcTeUItJDXg2.BkjeYOTUtMCPLytEMfMWAwuYdGw = P_1;
			return wxoaBFKrZxGEuXYpPjcTeUItJDXg2;
		}

		internal IEnumerable<InputAction> HmJdnxGPsTHyBgPXzmCCDzLUHfh(string P_0)
		{
			pIEOFjVYeoecLNTdPsdBODyFmTe pIEOFjVYeoecLNTdPsdBODyFmTe2 = new pIEOFjVYeoecLNTdPsdBODyFmTe(-2);
			pIEOFjVYeoecLNTdPsdBODyFmTe2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			pIEOFjVYeoecLNTdPsdBODyFmTe2.PqgqlyVpPbbxVBxonFUFLIlCcziX = P_0;
			return pIEOFjVYeoecLNTdPsdBODyFmTe2;
		}

		internal IEnumerable<InputAction> zWAPhlXksWPjODmFwjQkjdwKFpYO(int P_0, bool P_1)
		{
			wKolCALPFbAlWSSlsIaLhVcIHOtx wKolCALPFbAlWSSlsIaLhVcIHOtx2 = new wKolCALPFbAlWSSlsIaLhVcIHOtx(-2);
			wKolCALPFbAlWSSlsIaLhVcIHOtx2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			wKolCALPFbAlWSSlsIaLhVcIHOtx2.IslvJkdNnYgqpcjgGkeWfRAPXtg = P_0;
			wKolCALPFbAlWSSlsIaLhVcIHOtx2.BkjeYOTUtMCPLytEMfMWAwuYdGw = P_1;
			return wKolCALPFbAlWSSlsIaLhVcIHOtx2;
		}

		internal IEnumerable<InputAction> zWAPhlXksWPjODmFwjQkjdwKFpYO(string P_0, bool P_1)
		{
			hmgqutNeqAYOagOVSSskszwThei hmgqutNeqAYOagOVSSskszwThei2 = new hmgqutNeqAYOagOVSSskszwThei(-2);
			hmgqutNeqAYOagOVSSskszwThei2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			hmgqutNeqAYOagOVSSskszwThei2.NZzUPDHUUChjMwEWTcsNKFtpoea = P_0;
			hmgqutNeqAYOagOVSSskszwThei2.BkjeYOTUtMCPLytEMfMWAwuYdGw = P_1;
			return hmgqutNeqAYOagOVSSskszwThei2;
		}

		public UserData()
			: this(true)
		{
		}

		private UserData(bool init)
		{
			if (init)
			{
				configVars.updateLoop = UpdateLoopSetting.Update;
				configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
				configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
				Player_Editor player_Editor = xkPlRfdDhdbQwGcBAKViUTWyaKs();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = wYPlRkyWlKzBfwFluUDoyXIZXSb();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = XnzApLRcXATUYmKKXdMHPIJzOUr();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = JCKvImtXObyamMoSdJdlETkBFFA();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = MRuWhnXcyXxedGPBuqruWjMkwWX();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = lJPLAFvwFWSpNMjvjceqzxyzOnx();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = HsYAEuoJsMgixjhiqiMzeZkQlsBA();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = IESIZuibhaXwmTIvuvkYbjIfFQg();
				inputLayout4.name = "Default";
				inputLayout4.descriptiveName = inputLayout4.name;
				customControllerLayouts.Add(inputLayout3);
			}
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			int num2 = default(int);
			while (true)
			{
				int num = -655527230;
				while (true)
				{
					switch (num ^ -655527229)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -655527231;
						continue;
					case 2:
						num = -655527225;
						continue;
					case 0:
						list.Add(actions[num2]);
						num2++;
						num = -655527225;
						continue;
					default:
						if (num2 >= actions.Count)
						{
							return list;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			int num2 = default(int);
			while (true)
			{
				int num = -775528763;
				while (true)
				{
					switch (num ^ -775528767)
					{
					case 0:
						break;
					case 4:
						num2 = 0;
						num = -775528765;
						continue;
					case 1:
						list.Add(inputBehaviors[num2].Clone());
						num = -775528766;
						continue;
					case 3:
						num2++;
						num = -775528765;
						continue;
					default:
						if (num2 >= inputBehaviors.Count)
						{
							return list;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			int num2 = default(int);
			KeyboardMap item = default(KeyboardMap);
			while (true)
			{
				int num = 1241685788;
				while (true)
				{
					switch (num ^ 0x4A029F1D)
					{
					case 0:
						break;
					case 1:
						num2 = 0;
						num = 1241685790;
						continue;
					case 4:
						item = keyboardMaps[num2].ndoqsxdYVLcHLqznrKTfuEDIfGL(containsActionDelegate);
						num = 1241685791;
						continue;
					case 2:
						list.Add(item);
						num2++;
						num = 1241685790;
						continue;
					default:
						if (num2 >= keyboardMaps.Count)
						{
							return list;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					MouseMap item = mouseMaps[num].krsRIxqaVDrrAMPqbGWejyVTGsP(containsActionDelegate);
					list.Add(item);
					num++;
					int num2 = 1308924161;
					while (true)
					{
						switch (num2 ^ 0x4E049903)
						{
						case 0:
							num2 = 1308924162;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(xkPlRfdDhdbQwGcBAKViUTWyaKs());
		}

		public void InsertPlayer(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 1107852002;
					while (true)
					{
						switch (num ^ 0x42087AE0)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						case 1:
							goto end_IL_0004;
						default:
							players.Insert(index, xkPlRfdDhdbQwGcBAKViUTWyaKs());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index >= players.Count)
						{
							num = 1107852001;
							num2 = num;
						}
						else
						{
							num = 1107852003;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeletePlayer(int index)
		{
			if (players != null && index >= 0)
			{
				if (index < players.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (-515120008 ^ -515120007)
					{
					case 0:
						break;
					case 1:
						goto end_IL_001a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_004a:
			players.RemoveAt(index);
		}

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
		}

		public void DuplicatePlayer(int index)
		{
			if (players != null)
			{
				Player_Editor player_Editor = default(Player_Editor);
				while (true)
				{
					int num = 642826331;
					while (true)
					{
						switch (num ^ 0x2650C058)
						{
						case 5:
							break;
						case 4:
							if (index == players.Count - 1)
							{
								players.Add(player_Editor);
								return;
							}
							goto default;
						case 1:
							goto end_IL_0008;
						case 2:
							player_Editor = players[index].Clone();
							player_Editor.id = GetNewPlayerId();
							player_Editor.name = StringTools.IterateName(player_Editor.name, -1, GetPlayerNames());
							player_Editor.assignMouseOnStart = false;
							num = 642826332;
							continue;
						case 3:
							goto IL_00b5;
						default:
							players.Insert(index + 1, player_Editor);
							return;
						}
						break;
						IL_00b5:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index >= players.Count)
						{
							num = 642826329;
							num2 = num;
						}
						else
						{
							num = 642826330;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public string[] GetPlayerNames()
		{
			if (players == null)
			{
				return null;
			}
			string[] array = new string[players.Count];
			int num = 0;
			while (num < players.Count)
			{
				while (true)
				{
					array[num] = players[num].name;
					num++;
					int num2 = 138373264;
					while (true)
					{
						switch (num2 ^ 0x83F6891)
						{
						case 0:
							num2 = 138373267;
							continue;
						case 2:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (true)
			{
				results.Clear();
				if (players == null)
				{
					break;
				}
				int num = 0;
				int num2 = -1969122469;
				while (true)
				{
					switch (num2 ^ -1969122472)
					{
					case 0:
						num2 = -1969122471;
						continue;
					case 1:
						break;
					case 2:
						results.Add(players[num].name);
						num++;
						num2 = -1969122469;
						continue;
					default:
						if (num >= players.Count)
						{
							return results.Count;
						}
						goto case 2;
					}
					break;
				}
			}
			return 0;
		}

		public int[] GetPlayerIds()
		{
			if (players == null)
			{
				goto IL_0008;
			}
			int[] array = new int[players.Count];
			int num = 0;
			int num2 = -998385672;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -998385671)
				{
				case 0:
					break;
				case 3:
					array[num] = players[num].id;
					num++;
					num2 = -998385667;
					continue;
				case 1:
					num2 = -998385667;
					continue;
				case 5:
					return null;
				case 4:
				{
					int num3;
					if (num < players.Count)
					{
						num2 = -998385670;
						num3 = num2;
					}
					else
					{
						num2 = -998385669;
						num3 = num2;
					}
					continue;
				}
				default:
					return array;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -998385668;
			goto IL_000d;
		}

		public int[] GetPlayerRuntimeIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			int num = 0;
			while (num < players.Count)
			{
				while (true)
				{
					IL_0068:
					int num2;
					if (num == 0)
					{
						array[num] = 9999999;
						num2 = -658533644;
						goto IL_0024;
					}
					goto IL_0049;
					IL_0024:
					while (true)
					{
						switch (num2 ^ -658533648)
						{
						case 2:
							num2 = -658533645;
							continue;
						case 5:
							break;
						case 4:
							num2 = -658533648;
							continue;
						case 0:
							num++;
							num2 = -658533647;
							continue;
						case 3:
							goto IL_0068;
						default:
							goto end_IL_0068;
						}
						break;
					}
					goto IL_0049;
					IL_0049:
					array[num] = num - 1;
					num2 = -658533648;
					goto IL_0024;
					continue;
					end_IL_0068:
					break;
				}
			}
			return array;
		}

		public int GetPlayerRuntimeIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			while (true)
			{
				results.Clear();
				int num = -314829894;
				while (true)
				{
					switch (num ^ -314829896)
					{
					case 5:
						num = -314829895;
						continue;
					case 7:
						num = -314829890;
						continue;
					case 4:
						num2++;
						num = -314829890;
						continue;
					case 1:
						break;
					case 3:
						results.Add(num2 - 1);
						num = -314829892;
						continue;
					case 2:
						if (players == null)
						{
							return 0;
						}
						num2 = 0;
						num = -314829889;
						continue;
					case 0:
						if (num2 == 0)
						{
							results.Add(9999999);
							num = -314829892;
							continue;
						}
						goto case 3;
					default:
						if (num2 >= players.Count)
						{
							return results.Count;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public string GetPlayerNameById(int id)
		{
			if (players == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (true)
			{
				int num2 = 608819878;
				while (true)
				{
					switch (num2 ^ 0x2449DAA7)
					{
					case 0:
						break;
					case 1:
						num2 = 608819876;
						continue;
					case 2:
						if (players[num].id == id)
						{
							return players[num].name;
						}
						num++;
						num2 = 608819876;
						continue;
					default:
						if (num >= players.Count)
						{
							return string.Empty;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public Player_Editor GetPlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				return null;
			}
			return players[index];
		}

		public int GetPlayerId(string name)
		{
			if (players == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = -701169947;
				while (true)
				{
					switch (num2 ^ -701169945)
					{
					case 3:
						break;
					case 2:
						num2 = -701169945;
						continue;
					case 1:
						if (players[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							return players[num].id;
						}
						num++;
						num2 = -701169945;
						continue;
					default:
						if (num >= players.Count)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool IsMouseAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 717319496;
				while (true)
				{
					switch (num ^ 0x2AC16D4A)
					{
					case 3:
						break;
					case 2:
						num2 = 0;
						num = 717319498;
						continue;
					case 1:
						if (players[num2].assignMouseOnStart)
						{
							return true;
						}
						num2++;
						num = 717319498;
						continue;
					default:
						if (num2 >= count)
						{
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public void ClearMouseAssignments()
		{
			if (players == null)
			{
				return;
			}
			while (true)
			{
				int count = players.Count;
				int num = 0;
				int num2 = -241362321;
				while (true)
				{
					switch (num2 ^ -241362324)
					{
					case 0:
						num2 = -241362323;
						continue;
					case 1:
						break;
					case 2:
						players[num].assignMouseOnStart = false;
						num++;
						num2 = -241362321;
						continue;
					default:
						if (num >= count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public bool IsKeyboardAssigned()
		{
			if (players == null)
			{
				goto IL_0008;
			}
			int count = players.Count;
			int num = 1231967369;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x496E548D)
				{
				case 0:
					break;
				case 3:
					return false;
				case 5:
					if (players[num2].assignKeyboardOnStart)
					{
						return true;
					}
					num2++;
					num = 1231967375;
					continue;
				case 1:
					num = 1231967375;
					continue;
				case 4:
					num2 = 0;
					num = 1231967372;
					continue;
				default:
					if (num2 >= count)
					{
						return false;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = 1231967374;
			goto IL_000d;
		}

		public void ClearKeyboardAssignments()
		{
			if (players == null)
			{
				return;
			}
			while (true)
			{
				int count = players.Count;
				int num = 0;
				int num2 = -200835716;
				while (true)
				{
					switch (num2 ^ -200835715)
					{
					case 0:
						num2 = -200835714;
						continue;
					default:
						return;
					case 1:
					{
						int num3;
						if (num >= count)
						{
							num2 = -200835713;
							num3 = num2;
						}
						else
						{
							num2 = -200835719;
							num3 = num2;
						}
						continue;
					}
					case 4:
						players[num].assignKeyboardOnStart = false;
						num2 = -200835720;
						continue;
					case 5:
						num++;
						num2 = -200835716;
						continue;
					case 3:
						break;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public void AddAction(int categoryId)
		{
			InputAction inputAction = NQcSIoMzGUscevccPhPYYqpTcKtc();
			inputAction.categoryId = categoryId;
			while (true)
			{
				int num = -1646630036;
				while (true)
				{
					switch (num ^ -1646630033)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						actions.Add(inputAction);
						num = -1646630035;
						continue;
					case 2:
						actionCategoryMap.AddAction(categoryId, inputAction.id);
						num = -1646630034;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions == null)
			{
				return;
			}
			while (true)
			{
				InputAction inputAction = NQcSIoMzGUscevccPhPYYqpTcKtc();
				inputAction.categoryId = categoryId;
				actions.Add(inputAction);
				int index = actionCategoryMap.IndexOfAction(categoryId, actionId);
				int num = 759416035;
				while (true)
				{
					switch (num ^ 0x2D43C4E2)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					default:
						actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
						return;
					}
					break;
					IL_0009:
					num = 759416032;
				}
			}
		}

		public void DeleteAction(int categoryId, int actionId)
		{
			int num = IndexOfActionCategory(categoryId);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1091433102;
				while (true)
				{
					switch (num2 ^ 0x410DF28D)
					{
					case 0:
						break;
					case 3:
						if (num < 0)
						{
							return;
						}
						goto case 1;
					case 1:
						num3 = IndexOfAction(actionId);
						if (num3 >= 0)
						{
							goto IL_004e;
						}
						return;
					case 2:
						goto IL_004e;
					default:
						actionCategoryMap.RemoveAction(categoryId, actionId);
						return;
					}
					break;
					IL_004e:
					actions.RemoveAt(num3);
					num2 = 1091433097;
				}
			}
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return actionCategoryMap.ReorderAction(categoryId, actionId, offsetDown, offsetNow);
		}

		public int DuplicateAction_FromButton(int categoryId, int actionId)
		{
			int num = IndexOfActionCategory(categoryId);
			if (num < 0)
			{
				return -1;
			}
			int num2 = IndexOfAction(actionId);
			if (num2 < 0)
			{
				return -1;
			}
			InputAction actionById = GetActionById(actionId);
			if (actionById == null)
			{
				return -1;
			}
			InputAction inputAction = actionById.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			if (num2 == actions.Count - 1)
			{
				goto IL_0064;
			}
			actions.Insert(num2 + 1, inputAction);
			int num3 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num3 + 1);
			int num4 = 1230220815;
			goto IL_0069;
			IL_0064:
			num4 = 1230220812;
			goto IL_0069;
			IL_0069:
			switch (num4 ^ 0x4953AE0E)
			{
			case 0:
				break;
			case 2:
				actions.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return actions.Count - 1;
			default:
				return num2 + 1;
			}
			goto IL_0064;
		}

		private int AptCeIAIjsQHUwrqvBJgjQSCJUgT(int P_0, InputAction P_1)
		{
			int num = IndexOfActionCategory(P_0);
			if (num < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			actions.Add(inputAction);
			return actions.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			string[] array = new string[actions.Count];
			int num = 0;
			int num2 = -1163127771;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1163127769)
				{
				case 0:
					break;
				case 3:
					return null;
				case 1:
					goto IL_0046;
				default:
					if (num < actions.Count)
					{
						goto IL_0046;
					}
					return array;
				}
				break;
				IL_0046:
				array[num] = actions[num].name;
				num++;
				num2 = -1163127771;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1163127772;
			goto IL_000d;
		}

		public int GetActionNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			while (true)
			{
				results.Clear();
				int num = 292089251;
				while (true)
				{
					switch (num ^ 0x1168EDA0)
					{
					case 0:
						num = 292089252;
						continue;
					case 2:
						results.Add(actions[num2].name);
						num = 292089253;
						continue;
					case 3:
						if (actions == null)
						{
							return 0;
						}
						num2 = 0;
						num = 292089249;
						continue;
					case 4:
						break;
					case 5:
						num2++;
						num = 292089249;
						continue;
					default:
						if (num2 >= actions.Count)
						{
							return results.Count;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int[] GetActionIds()
		{
			if (actions == null)
			{
				return null;
			}
			int[] array = new int[actions.Count];
			int num = 0;
			while (true)
			{
				int num2 = -746886577;
				while (true)
				{
					switch (num2 ^ -746886578)
					{
					case 4:
						break;
					case 1:
						num2 = -746886578;
						continue;
					case 3:
						num++;
						num2 = -746886578;
						continue;
					case 2:
						array[num] = actions[num].id;
						num2 = -746886579;
						continue;
					default:
						if (num >= actions.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int GetActionIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (true)
			{
				results.Clear();
				if (actions == null)
				{
					break;
				}
				int num = 0;
				int num2 = 2079399721;
				while (true)
				{
					switch (num2 ^ 0x7BF11F2C)
					{
					case 0:
						num2 = 2079399725;
						continue;
					case 2:
						num++;
						num2 = 2079399721;
						continue;
					case 3:
						results.Add(actions[num].id);
						num2 = 2079399726;
						continue;
					case 5:
					{
						int num3;
						if (num >= actions.Count)
						{
							num2 = 2079399720;
							num3 = num2;
						}
						else
						{
							num2 = 2079399727;
							num3 = num2;
						}
						continue;
					}
					case 1:
						break;
					default:
						return results.Count;
					}
					break;
				}
			}
			return 0;
		}

		public string GetActionNameById(int id)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1908162986;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x71BC41AA)
				{
				case 2:
					break;
				case 1:
					return string.Empty;
				case 3:
					if (actions[num].id != id)
					{
						goto IL_005f;
					}
					return actions[num].name;
				default:
					if (num >= actions.Count)
					{
						return string.Empty;
					}
					goto case 3;
				}
				break;
				IL_005f:
				num++;
				num2 = 1908162986;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1908162987;
			goto IL_000d;
		}

		public InputAction GetAction(int index)
		{
			if (actions != null)
			{
				while (true)
				{
					int num = 1497767106;
					while (true)
					{
						switch (num ^ 0x59461CC3)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						case 0:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= actions.Count)
						{
							num = 1497767104;
							continue;
						}
						return actions[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = 1497767107;
							num2 = num;
						}
						else
						{
							num = 1497767104;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputAction GetAction(string name)
		{
			if (actions == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return actions[num];
		}

		public InputAction GetActionById(int id)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1623629901;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1623629902)
				{
				case 0:
					break;
				case 2:
					return null;
				case 3:
					if (actions[num].id != id)
					{
						goto IL_0056;
					}
					return actions[num];
				default:
					if (num >= actions.Count)
					{
						return null;
					}
					goto case 3;
				}
				break;
				IL_0056:
				num++;
				num2 = -1623629901;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1623629904;
			goto IL_000d;
		}

		public int GetActionId(string name)
		{
			if (actions == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return actions[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories != null)
			{
				int current = default(int);
				while (true)
				{
					int num = 894999628;
					while (true)
					{
						switch (num ^ 0x35589C4D)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (actions == null)
						{
							num = 894999629;
							continue;
						}
						List<string> list = new List<string>();
						using (IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator())
						{
							while (true)
							{
								IL_00a3:
								int num2;
								int num3;
								if (enumerator.MoveNext())
								{
									num2 = 894999628;
									num3 = num2;
								}
								else
								{
									num2 = 894999625;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x35589C4D)
									{
									case 0:
										num2 = 894999628;
										continue;
									default:
										goto end_IL_0056;
									case 1:
										current = enumerator.Current;
										num2 = 894999630;
										continue;
									case 3:
									{
										InputAction actionById = GetActionById(current);
										if (actionById != null)
										{
											list.Add(actionById.name);
											num2 = 894999631;
											continue;
										}
										break;
									}
									case 2:
										break;
									case 4:
										goto end_IL_0056;
									}
									goto IL_00a3;
									continue;
									end_IL_0056:
									break;
								}
								break;
							}
						}
						return list.ToArray();
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			SPMiJDtDwELaRhatgCXWifFKtdI sPMiJDtDwELaRhatgCXWifFKtdI = new SPMiJDtDwELaRhatgCXWifFKtdI(-2);
			sPMiJDtDwELaRhatgCXWifFKtdI.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			sPMiJDtDwELaRhatgCXWifFKtdI.yDlfINvlLfFwFxkZYfdNACzTPYB = id;
			return sPMiJDtDwELaRhatgCXWifFKtdI;
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories != null)
			{
				List<string> list = default(List<string>);
				while (true)
				{
					int num = -1426407687;
					while (true)
					{
						switch (num ^ -1426407688)
						{
						case 0:
							break;
						case 1:
							goto IL_002a;
						case 2:
							goto end_IL_0008;
						default:
						{
							using (IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										int current = enumerator.Current;
										int num2 = -1426407687;
										while (true)
										{
											switch (num2 ^ -1426407688)
											{
											case 0:
												num2 = -1426407685;
												continue;
											case 3:
												break;
											case 1:
											{
												InputAction actionById = GetActionById(current);
												if (actionById != null)
												{
													list.Add(actionById.descriptiveName);
													num2 = -1426407686;
													continue;
												}
												goto end_IL_007e;
											}
											default:
												goto end_IL_007e;
											}
											break;
										}
										continue;
										end_IL_007e:
										break;
									}
								}
							}
							return list.ToArray();
						}
						}
						break;
						IL_002a:
						if (actions == null)
						{
							num = -1426407686;
							continue;
						}
						list = new List<string>();
						num = -1426407685;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			ERpBNmHuSwmLyxxeaDVyiHeDnDTH eRpBNmHuSwmLyxxeaDVyiHeDnDTH = new ERpBNmHuSwmLyxxeaDVyiHeDnDTH(-2);
			eRpBNmHuSwmLyxxeaDVyiHeDnDTH.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			eRpBNmHuSwmLyxxeaDVyiHeDnDTH.yDlfINvlLfFwFxkZYfdNACzTPYB = id;
			return eRpBNmHuSwmLyxxeaDVyiHeDnDTH;
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			List<int> list = default(List<int>);
			int num;
			if (actionCategories != null)
			{
				if (actions == null)
				{
					goto IL_0010;
				}
				list = new List<int>();
				num = -184138584;
				goto IL_0015;
			}
			goto IL_002e;
			IL_0015:
			switch (num ^ -184138582)
			{
			case 0:
				break;
			case 1:
				goto IL_002e;
			default:
			{
				using (IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							int current = enumerator.Current;
							list.Add(current);
							int num2 = -184138582;
							while (true)
							{
								switch (num2 ^ -184138582)
								{
								case 2:
									num2 = -184138581;
									continue;
								case 1:
									break;
								default:
									goto end_IL_006f;
								}
								break;
							}
							continue;
							end_IL_006f:
							break;
						}
					}
				}
				return list.ToArray();
			}
			}
			goto IL_0010;
			IL_002e:
			return null;
			IL_0010:
			num = -184138581;
			goto IL_0015;
		}

		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			ZLhxEUKjCqfLrNagWYDMoVnbanm zLhxEUKjCqfLrNagWYDMoVnbanm = new ZLhxEUKjCqfLrNagWYDMoVnbanm(-2);
			zLhxEUKjCqfLrNagWYDMoVnbanm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			zLhxEUKjCqfLrNagWYDMoVnbanm.yDlfINvlLfFwFxkZYfdNACzTPYB = id;
			return zLhxEUKjCqfLrNagWYDMoVnbanm;
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 72211937;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x44DDDE2)
				{
				case 0:
					break;
				case 1:
					return -1;
				case 2:
					if (actions[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= actions.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_004b:
				num++;
				num2 = 72211937;
			}
			goto IL_0008;
			IL_0008:
			num2 = 72211939;
			goto IL_000d;
		}

		public int IndexOfAction(string name)
		{
			if (actions == null)
			{
				return -1;
			}
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_001a;
				}
				num = 0;
				num2 = -957930806;
				goto IL_001f;
			}
			goto IL_0040;
			IL_001f:
			while (true)
			{
				switch (num2 ^ -957930806)
				{
				case 4:
					break;
				case 2:
					goto IL_0040;
				case 1:
					return num;
				case 3:
					goto IL_0058;
				default:
					if (num >= actions.Count)
					{
						return -1;
					}
					goto IL_0058;
				}
				break;
				IL_0058:
				if (!actions[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					num2 = -957930806;
				}
				else
				{
					num2 = -957930805;
				}
			}
			goto IL_001a;
			IL_001a:
			num2 = -957930808;
			goto IL_001f;
			IL_0040:
			return -1;
		}

		public void AddActionCategory()
		{
			InputCategory inputCategory = wYPlRkyWlKzBfwFluUDoyXIZXSb();
			actionCategories.Add(inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 1249100875;
					while (true)
					{
						switch (num ^ 0x4A73C449)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						case 1:
							goto end_IL_0004;
						default:
						{
							InputCategory inputCategory = wYPlRkyWlKzBfwFluUDoyXIZXSb();
							actionCategories.Insert(index, inputCategory);
							actionCategoryMap.AddCategory(inputCategory.id);
							return;
						}
						}
						break;
						IL_0026:
						int num2;
						if (index < actionCategories.Count)
						{
							num = 1249100874;
							num2 = num;
						}
						else
						{
							num = 1249100872;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories != null)
			{
				int num2 = default(int);
				int id = default(int);
				while (true)
				{
					int num = 1357180828;
					while (true)
					{
						switch (num ^ 0x50E4EF9A)
						{
						case 5:
							break;
						case 3:
							goto IL_0045;
						case 1:
							goto end_IL_0008;
						case 7:
							num2--;
							num = 1357180825;
							continue;
						case 2:
							if (actions[num2].categoryId == id)
							{
								actions.RemoveAt(num2);
								num = 1357180829;
								continue;
							}
							goto case 7;
						case 4:
							num2 = actions.Count - 1;
							num = 1357180825;
							continue;
						case 0:
							goto IL_00b9;
						case 6:
							goto IL_00d5;
						case 9:
							id = actionCategories[index].id;
							actionCategoryMap.RemoveCategory(id);
							num = 1357180826;
							continue;
						default:
							actionCategories.RemoveAt(index);
							return;
						}
						break;
						IL_00d5:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num3;
						if (index >= actionCategories.Count)
						{
							num = 1357180827;
							num3 = num;
						}
						else
						{
							num = 1357180819;
							num3 = num;
						}
						continue;
						IL_0045:
						int num4;
						if (num2 < 0)
						{
							num = 1357180818;
							num4 = num;
						}
						else
						{
							num = 1357180824;
							num4 = num;
						}
						continue;
						IL_00b9:
						int num5;
						if (actions != null)
						{
							num = 1357180830;
							num5 = num;
						}
						else
						{
							num = 1357180818;
							num5 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderActionCategory(int index, bool offsetDown, bool offsetNow)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				return false;
			}
			return ListTools.OffsetAtIndex(actionCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateActionCategory(int index, bool duplicateActions)
		{
			if (actionCategories == null || index < 0)
			{
				return;
			}
			int num3 = default(int);
			int id2 = default(int);
			InputAction inputAction = default(InputAction);
			int id = default(int);
			InputCategory inputCategory = default(InputCategory);
			while (true)
			{
				int num = 338823740;
				while (true)
				{
					switch (num ^ 0x14320A3A)
					{
					case 8:
						break;
					default:
						return;
					case 10:
						if (actions[num3].categoryId == id2)
						{
							int num6 = AptCeIAIjsQHUwrqvBJgjQSCJUgT(id2, actions[num3]);
							if (num6 >= 0)
							{
								inputAction = actions[num6];
								inputAction.categoryId = id;
								num = 338823736;
								continue;
							}
						}
						goto case 7;
					case 11:
						num3 = actions.Count - 1;
						num = 338823742;
						continue;
					case 4:
					{
						int num5;
						if (num3 < 0)
						{
							num = 338823743;
							num5 = num;
						}
						else
						{
							num = 338823728;
							num5 = num;
						}
						continue;
					}
					case 13:
						return;
					case 0:
						actionCategories.Insert(index + 1, inputCategory);
						num = 338823737;
						continue;
					case 12:
						if (index == actionCategories.Count - 1)
						{
							actionCategories.Add(inputCategory);
							num = 338823737;
							continue;
						}
						goto case 0;
					case 1:
						inputCategory = new InputCategory(actionCategories[index]);
						inputCategory.id = GetNewActionCategoryId();
						inputCategory.name = StringTools.IterateName(inputCategory.name, -1, GetActionCategoryNames());
						num = 338823734;
						continue;
					case 3:
						actionCategoryMap.AddCategory(inputCategory.id);
						if (duplicateActions)
						{
							id = inputCategory.id;
							id2 = actionCategories[index].id;
							num = 338823731;
							continue;
						}
						return;
					case 7:
						num3--;
						num = 338823742;
						continue;
					case 6:
					{
						int num4;
						if (index < actionCategories.Count)
						{
							num = 338823739;
							num4 = num;
						}
						else
						{
							num = 338823735;
							num4 = num;
						}
						continue;
					}
					case 9:
					{
						int num2;
						if (actions == null)
						{
							num = 338823743;
							num2 = num;
						}
						else
						{
							num = 338823729;
							num2 = num;
						}
						continue;
					}
					case 2:
						actionCategoryMap.AddAction(id, inputAction.id);
						num = 338823741;
						continue;
					case 5:
						return;
					}
					break;
				}
			}
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = IndexOfAction(actionId);
			if (num < 0)
			{
				goto IL_000c;
			}
			goto IL_0059;
			IL_000c:
			int num2 = -421940584;
			goto IL_0011;
			IL_0011:
			switch (num2 ^ -421940580)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0032;
			case 0:
				goto IL_0059;
			case 4:
				return;
			case 3:
				return;
			}
			goto IL_000c;
			IL_0059:
			if (actions[num].categoryId == newCategoryId)
			{
				return;
			}
			goto IL_0032;
			IL_0032:
			actionCategoryMap.ChangeCategory(actionId, newCategoryId);
			actions[num].categoryId = newCategoryId;
			num2 = -421940577;
			goto IL_0011;
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (actions != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3;
					int num4;
					if (num2 >= actions.Count)
					{
						num3 = -1268208853;
						num4 = num3;
					}
					else
					{
						num3 = -1268208851;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ -1268208849)
						{
						case 3:
							num3 = -1268208851;
							continue;
						case 0:
							break;
						case 1:
							num2++;
							num3 = -1268208849;
							continue;
						case 2:
							if (actions[num2].categoryId == id)
							{
								num++;
								num3 = -1268208850;
								continue;
							}
							goto case 1;
						default:
							goto end_IL_003e;
						}
						break;
					}
					continue;
					end_IL_003e:
					break;
				}
			}
			return num;
		}

		public int GetActionCategoryIndex(int id)
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -397504887;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -397504886)
				{
				case 2:
					break;
				case 1:
					return 0;
				case 0:
					if (actionCategories[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= actionCategories.Count)
					{
						return -1;
					}
					goto case 0;
				}
				break;
				IL_004b:
				num++;
				num2 = -397504887;
			}
			goto IL_0008;
			IL_0008:
			num2 = -397504885;
			goto IL_000d;
		}

		public string[] GetActionCategoryNames()
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			string[] array = new string[actionCategories.Count];
			int num = -1621968899;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1621968897)
				{
				case 4:
					break;
				case 5:
					return null;
				case 2:
					num2 = 0;
					num = -1621968897;
					continue;
				case 3:
					array[num2] = actionCategories[num2].name;
					num2++;
					num = -1621968898;
					continue;
				case 0:
					num = -1621968898;
					continue;
				default:
					if (num2 >= actionCategories.Count)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = -1621968902;
			goto IL_000d;
		}

		public int[] GetActionCategoryIds()
		{
			if (actionCategories == null)
			{
				return null;
			}
			int[] array = new int[actionCategories.Count];
			int num = 0;
			while (num < actionCategories.Count)
			{
				while (true)
				{
					array[num] = actionCategories[num].id;
					num++;
					int num2 = -668280681;
					while (true)
					{
						switch (num2 ^ -668280681)
						{
						case 2:
							num2 = -668280682;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public InputCategory GetActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				return null;
			}
			return actionCategories[index];
		}

		public InputCategory GetActionCategory(string name)
		{
			if (actionCategories == null)
			{
				return null;
			}
			int num = IndexOfActionCategory(name);
			if (num < 0)
			{
				return null;
			}
			return actionCategories[num];
		}

		public InputCategory GetActionCategoryById(int id)
		{
			int num = IndexOfActionCategory(id);
			while (true)
			{
				int num2 = 1313999917;
				while (true)
				{
					switch (num2 ^ 0x4E520C2F)
					{
					case 0:
						break;
					case 2:
						if (num < 0)
						{
							goto IL_002a;
						}
						return actionCategories[num];
					default:
						return null;
					}
					break;
					IL_002a:
					num2 = 1313999918;
				}
			}
		}

		public int GetActionCategoryId(string name)
		{
			if (actionCategories == null)
			{
				return -1;
			}
			int num = IndexOfActionCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return actionCategories[num].id;
		}

		public string GetActionCategoryNameById(int id)
		{
			if (actionCategories == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (num < actionCategories.Count)
			{
				while (true)
				{
					if (actionCategories[num].id == id)
					{
						return actionCategories[num].name;
					}
					num++;
					int num2 = 1147929208;
					while (true)
					{
						switch (num2 ^ 0x446C0279)
						{
						case 0:
							num2 = 1147929211;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return string.Empty;
		}

		public int IndexOfActionCategory(int id)
		{
			if (actionCategories == null)
			{
				return -1;
			}
			int num = 0;
			while (num < actionCategories.Count)
			{
				while (true)
				{
					if (actionCategories[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = -1043770342;
					while (true)
					{
						switch (num2 ^ -1043770341)
						{
						case 0:
							num2 = -1043770343;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public int IndexOfActionCategory(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (actionCategories == null)
				{
					return -1;
				}
				num = 0;
				num2 = 2038343185;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x797EA613)
				{
				case 0:
					break;
				case 1:
					goto IL_0036;
				case 3:
					goto IL_004b;
				case 2:
					goto IL_0072;
				default:
					return -1;
				}
				break;
				IL_0072:
				int num3;
				if (num < actionCategories.Count)
				{
					num2 = 2038343184;
					num3 = num2;
				}
				else
				{
					num2 = 2038343191;
					num3 = num2;
				}
				continue;
				IL_004b:
				if (actionCategories[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 2038343185;
			}
			goto IL_0010;
			IL_0010:
			num2 = 2038343186;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public int GetActionCategoryCount()
		{
			if (actionCategories == null)
			{
				return 0;
			}
			return actionCategories.Count;
		}

		public void AddInputBehavior()
		{
			inputBehaviors.Add(XnzApLRcXATUYmKKXdMHPIJzOUr());
		}

		public void InsertInputBehavior(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1103159576;
					while (true)
					{
						switch (num ^ -1103159575)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002a;
						case 4:
							inputBehaviors.Insert(index, XnzApLRcXATUYmKKXdMHPIJzOUr());
							num = -1103159575;
							continue;
						case 3:
							goto end_IL_0004;
						case 0:
							return;
						}
						break;
						IL_002a:
						int num2;
						if (index < inputBehaviors.Count)
						{
							num = -1103159571;
							num2 = num;
						}
						else
						{
							num = -1103159574;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors != null && index >= 0)
			{
				if (index >= inputBehaviors.Count)
				{
					goto IL_0023;
				}
				goto IL_00bb;
			}
			goto IL_00f9;
			IL_00f9:
			throw new ArgumentOutOfRangeException("index");
			IL_00bb:
			int id = inputBehaviors[index].id;
			int num = -1688265441;
			goto IL_0028;
			IL_0023:
			num = -1688265442;
			goto IL_0028;
			IL_0028:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1688265444)
				{
				case 8:
					break;
				default:
					return;
				case 1:
					if (actions[num2].behaviorId == id)
					{
						actions[num2].behaviorId = 0;
						num = -1688265445;
						continue;
					}
					goto case 7;
				case 7:
					num2++;
					num = -1688265447;
					continue;
				case 0:
					inputBehaviors.RemoveAt(index);
					num = -1688265446;
					continue;
				case 3:
					if (actions != null)
					{
						num2 = 0;
						num = -1688265447;
						continue;
					}
					goto case 0;
				case 4:
					goto IL_00bb;
				case 5:
					goto IL_00d7;
				case 2:
					goto IL_00f9;
				case 6:
					return;
				}
				break;
				IL_00d7:
				int num3;
				if (num2 < actions.Count)
				{
					num = -1688265443;
					num3 = num;
				}
				else
				{
					num = -1688265444;
					num3 = num;
				}
			}
			goto IL_0023;
		}

		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(inputBehaviors, index, offsetDown, offsetNow);
		}

		public void DuplicateInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0)
			{
				goto IL_009d;
			}
			if (index >= inputBehaviors.Count)
			{
				goto IL_0023;
			}
			goto IL_00b2;
			IL_00b2:
			InputBehavior inputBehavior = inputBehaviors[index].Clone();
			inputBehavior.id = GetNewInputBehaviorId();
			int num = -657758362;
			goto IL_0028;
			IL_009d:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num = -657758365;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ -657758366)
				{
				case 3:
					break;
				case 4:
					goto IL_0050;
				case 5:
					inputBehaviors.Add(inputBehavior);
					return;
				case 1:
					goto IL_009d;
				case 0:
					goto IL_00b2;
				default:
					inputBehaviors.Insert(index + 1, inputBehavior);
					return;
				}
				break;
				IL_0050:
				inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames());
				int num2;
				if (index != inputBehaviors.Count - 1)
				{
					num = -657758368;
					num2 = num;
				}
				else
				{
					num = -657758361;
					num2 = num;
				}
			}
			goto IL_0023;
		}

		public string[] GetInputBehaviorNames()
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			string[] array = new string[inputBehaviors.Count];
			int num = 0;
			int num2 = 864421474;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x33860662)
				{
				case 2:
					break;
				case 1:
					return null;
				case 3:
					goto IL_0046;
				default:
					if (num < inputBehaviors.Count)
					{
						goto IL_0046;
					}
					return array;
				}
				break;
				IL_0046:
				array[num] = inputBehaviors[num].name;
				num++;
				num2 = 864421474;
			}
			goto IL_0008;
			IL_0008:
			num2 = 864421475;
			goto IL_000d;
		}

		public int[] GetInputBehaviorIds()
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			int[] array = new int[inputBehaviors.Count];
			int num = 0;
			int num2 = 606022991;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x241F2D4D)
				{
				case 0:
					break;
				case 1:
					num++;
					num2 = 606022991;
					continue;
				case 3:
					array[num] = inputBehaviors[num].id;
					num2 = 606022988;
					continue;
				case 4:
					return null;
				default:
					if (num >= inputBehaviors.Count)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 606022985;
			goto IL_000d;
		}

		public InputBehavior GetInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				return null;
			}
			return inputBehaviors[index];
		}

		public InputBehavior GetInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int num = IndexOfInputBehavior(name);
			if (num < 0)
			{
				return null;
			}
			return inputBehaviors[num];
		}

		public InputBehavior GetInputBehaviorById(int id)
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1695414038;
				while (true)
				{
					switch (num2 ^ -1695414039)
					{
					case 0:
						break;
					case 3:
						num2 = -1695414040;
						continue;
					case 2:
						if (inputBehaviors[num].id == id)
						{
							return inputBehaviors[num];
						}
						num++;
						num2 = -1695414040;
						continue;
					default:
						if (num >= inputBehaviors.Count)
						{
							return null;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int GetInputBehaviorId(string name)
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			int num = IndexOfInputBehavior(name);
			int num2 = 1706301822;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ 0x65B4197F)
			{
			case 0:
				break;
			case 2:
				return -1;
			default:
				if (num < 0)
				{
					return -1;
				}
				return inputBehaviors[num].id;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1706301821;
			goto IL_000d;
		}

		public int IndexOfInputBehavior(int id)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = 0;
			while (num < inputBehaviors.Count)
			{
				while (true)
				{
					int num2;
					if (inputBehaviors[num].id == id)
					{
						num2 = -381636911;
					}
					else
					{
						num++;
						num2 = -381636909;
					}
					while (true)
					{
						switch (num2 ^ -381636909)
						{
						case 3:
							num2 = -381636910;
							continue;
						case 1:
							break;
						case 2:
							return num;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public int IndexOfInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_001a;
				}
				num = 0;
				num2 = -85637361;
				goto IL_001f;
			}
			goto IL_003c;
			IL_001f:
			while (true)
			{
				switch (num2 ^ -85637363)
				{
				case 0:
					break;
				case 3:
					goto IL_003c;
				case 1:
					goto IL_0047;
				default:
					if (num >= inputBehaviors.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (inputBehaviors[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = -85637361;
			}
			goto IL_001a;
			IL_003c:
			return -1;
			IL_001a:
			num2 = -85637362;
			goto IL_001f;
		}

		public void AddMapCategory()
		{
			mapCategories.Add(JCKvImtXObyamMoSdJdlETkBFFA());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= mapCategories.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0046:
			mapCategories.Insert(index, JCKvImtXObyamMoSdJdlETkBFFA());
			int num = -1891021659;
			goto IL_0017;
			IL_0012:
			num = -1891021660;
			goto IL_0017;
			IL_0017:
			switch (num ^ -1891021659)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 3:
				goto IL_0046;
			case 0:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteMapCategory(int index)
		{
			if (mapCategories != null && index >= 0)
			{
				if (index >= mapCategories.Count)
				{
					goto IL_0023;
				}
				goto IL_00ff;
			}
			goto IL_04bb;
			IL_00ff:
			int id = mapCategories[index].id;
			int num = default(int);
			int num2;
			if (joystickMaps != null)
			{
				num = joystickMaps.Count - 1;
				num2 = -1782638657;
				goto IL_0028;
			}
			goto IL_0384;
			IL_0487:
			int num3;
			if (customControllerMaps == null)
			{
				num2 = -1782638674;
				num3 = num2;
			}
			else
			{
				num2 = -1782638684;
				num3 = num2;
			}
			goto IL_0028;
			IL_0023:
			num2 = -1782638687;
			goto IL_0028;
			IL_0028:
			Player_Editor player_Editor = default(Player_Editor);
			int num8 = default(int);
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			int num7 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			int num9 = default(int);
			InputMapCategory inputMapCategory = default(InputMapCategory);
			while (true)
			{
				switch (num2 ^ -1782638663)
				{
				case 10:
					break;
				case 31:
					player_Editor = players[num8];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultKeyboardMaps, id);
						num2 = -1782638686;
						continue;
					}
					goto case 5;
				case 16:
					goto IL_00ff;
				case 18:
					goto IL_0134;
				case 3:
					num7++;
					num2 = -1782638692;
					continue;
				case 25:
					if (mouseMaps[num5].categoryId == id)
					{
						mouseMaps.RemoveAt(num5);
						num2 = -1782638665;
						continue;
					}
					goto case 14;
				case 36:
					goto IL_0189;
				case 26:
					goto IL_01a2;
				case 12:
					num4++;
					num2 = -1782638670;
					continue;
				case 20:
					goto IL_01ca;
				case 34:
					goto IL_01ed;
				case 28:
					if (players != null)
					{
						goto IL_0221;
					}
					goto default;
				case 13:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultCustomControllerMaps, id);
					num2 = -1782638660;
					continue;
				case 33:
					num6--;
					num2 = -1782638691;
					continue;
				case 19:
					goto IL_0265;
				case 21:
					if (keyboardMaps[num9].categoryId == id)
					{
						keyboardMaps.RemoveAt(num9);
						num2 = -1782638659;
						continue;
					}
					goto case 4;
				case 4:
					num9--;
					num2 = -1782638673;
					continue;
				case 9:
					if (joystickMaps[num].categoryId == id)
					{
						joystickMaps.RemoveAt(num);
						num2 = -1782638664;
						continue;
					}
					goto case 1;
				case 35:
					num2 = -1782638675;
					continue;
				case 1:
					num--;
					num2 = -1782638685;
					continue;
				case 11:
					goto IL_0302;
				case 6:
					num2 = -1782638685;
					continue;
				case 30:
					if (inputMapCategory.checkConflictsCategoryIds[num7] == id)
					{
						inputMapCategory.checkConflictsCategoryIds.RemoveAt(num7);
						num2 = -1782638662;
						continue;
					}
					goto case 3;
				case 14:
					num5--;
					num2 = -1782638677;
					continue;
				case 15:
					CS_0024_003C_003E9__CachedAnonymousMethodDelegate60 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
					{
						if (P_0 == null)
						{
							return;
						}
						while (true)
						{
							int num19 = P_0.Count - 1;
							int num20 = -1416184342;
							while (true)
							{
								switch (num20 ^ -1416184338)
								{
								case 6:
									num20 = -1416184337;
									continue;
								case 2:
								{
									int num22;
									if (P_0[num19].categoryId != P_1)
									{
										num20 = -1416184338;
										num22 = num20;
									}
									else
									{
										num20 = -1416184341;
										num22 = num20;
									}
									continue;
								}
								case 3:
								{
									int num21;
									if (P_0[num19] == null)
									{
										num20 = -1416184341;
										num21 = num20;
									}
									else
									{
										num20 = -1416184340;
										num21 = num20;
									}
									continue;
								}
								case 1:
									break;
								case 0:
									num19--;
									num20 = -1416184342;
									continue;
								case 5:
									P_0.RemoveAt(num19);
									num20 = -1416184338;
									continue;
								default:
									if (num19 < 0)
									{
										return;
									}
									goto case 3;
								}
								break;
							}
						}
					};
					num2 = -1782638671;
					continue;
				case 0:
					goto IL_0384;
				case 27:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultMouseMaps, id);
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultJoystickMaps, id);
					num2 = -1782638668;
					continue;
				case 22:
					goto IL_03cf;
				case 32:
					customControllerMaps.RemoveAt(num6);
					num2 = -1782638696;
					continue;
				case 5:
					num8++;
					num2 = -1782638675;
					continue;
				case 8:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate60;
					num8 = 0;
					num2 = -1782638694;
					continue;
				case 2:
					inputMapCategory = mapCategories[num4];
					if (inputMapCategory.checkConflictsCategoryIds != null)
					{
						num7 = 0;
						num2 = -1782638692;
						continue;
					}
					goto case 12;
				case 29:
					num6 = customControllerMaps.Count - 1;
					num2 = -1782638691;
					continue;
				case 37:
					goto IL_0463;
				case 7:
					goto IL_0487;
				case 23:
					if (mapCategories != null)
					{
						num4 = 0;
						num2 = -1782638670;
						continue;
					}
					goto case 28;
				case 24:
					goto IL_04bb;
				default:
					mapCategories.RemoveAt(index);
					return;
				}
				break;
				IL_0463:
				int num10;
				if (num7 >= inputMapCategory.checkConflictsCategoryIds.Count)
				{
					num2 = -1782638667;
					num10 = num2;
				}
				else
				{
					num2 = -1782638681;
					num10 = num2;
				}
				continue;
				IL_0221:
				int num11;
				if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate60 == null)
				{
					num2 = -1782638666;
					num11 = num2;
				}
				else
				{
					num2 = -1782638671;
					num11 = num2;
				}
				continue;
				IL_01ed:
				int num12;
				if (customControllerMaps[num6].categoryId == id)
				{
					num2 = -1782638695;
					num12 = num2;
				}
				else
				{
					num2 = -1782638696;
					num12 = num2;
				}
				continue;
				IL_03cf:
				int num13;
				if (num9 >= 0)
				{
					num2 = -1782638676;
					num13 = num2;
				}
				else
				{
					num2 = -1782638678;
					num13 = num2;
				}
				continue;
				IL_0134:
				int num14;
				if (num5 >= 0)
				{
					num2 = -1782638688;
					num14 = num2;
				}
				else
				{
					num2 = -1782638658;
					num14 = num2;
				}
				continue;
				IL_01a2:
				int num15;
				if (num < 0)
				{
					num2 = -1782638663;
					num15 = num2;
				}
				else
				{
					num2 = -1782638672;
					num15 = num2;
				}
				continue;
				IL_0302:
				int num16;
				if (num4 >= mapCategories.Count)
				{
					num2 = -1782638683;
					num16 = num2;
				}
				else
				{
					num2 = -1782638661;
					num16 = num2;
				}
				continue;
				IL_01ca:
				int num17;
				if (num8 >= players.Count)
				{
					num2 = -1782638680;
					num17 = num2;
				}
				else
				{
					num2 = -1782638682;
					num17 = num2;
				}
				continue;
				IL_0189:
				int num18;
				if (num6 < 0)
				{
					num2 = -1782638674;
					num18 = num2;
				}
				else
				{
					num2 = -1782638693;
					num18 = num2;
				}
			}
			goto IL_0023;
			IL_04bb:
			throw new ArgumentOutOfRangeException("index");
			IL_0384:
			if (keyboardMaps != null)
			{
				num9 = keyboardMaps.Count - 1;
				num2 = -1782638673;
				goto IL_0028;
			}
			goto IL_0265;
			IL_0265:
			if (mouseMaps != null)
			{
				num5 = mouseMaps.Count - 1;
				num2 = -1782638677;
				goto IL_0028;
			}
			goto IL_0487;
		}

		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mapCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
			if (mapCategories == null || index < 0)
			{
				goto IL_0108;
			}
			if (index >= mapCategories.Count)
			{
				goto IL_0023;
			}
			goto IL_037f;
			IL_0108:
			throw new ArgumentOutOfRangeException("index");
			IL_037f:
			InputMapCategory inputMapCategory = new InputMapCategory(mapCategories[index]);
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames());
			int num = -1832249825;
			goto IL_0028;
			IL_0023:
			num = -1832249837;
			goto IL_0028;
			IL_0028:
			int num3 = default(int);
			int id2 = default(int);
			int num2 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			int num9 = default(int);
			int id = default(int);
			int num7 = default(int);
			int num8 = default(int);
			while (true)
			{
				switch (num ^ -1832249838)
				{
				case 30:
					break;
				default:
					return;
				case 14:
					if (customControllerMaps[num3].categoryId == id2)
					{
						goto IL_00cc;
					}
					goto case 24;
				case 23:
					goto IL_00ef;
				case 1:
					goto IL_0108;
				case 19:
					goto IL_011d;
				case 13:
					if (index == mapCategories.Count - 1)
					{
						mapCategories.Add(inputMapCategory);
						num = -1832249848;
						continue;
					}
					goto case 6;
				case 20:
					num2 = DuplicateJoystickMap(num6);
					num = -1832249829;
					continue;
				case 6:
					mapCategories.Insert(index + 1, inputMapCategory);
					num = -1832249848;
					continue;
				case 17:
					if (keyboardMaps != null)
					{
						num4 = keyboardMaps.Count - 1;
						num = -1832249832;
						continue;
					}
					goto case 11;
				case 15:
					num6--;
					num = -1832249845;
					continue;
				case 7:
					num6 = joystickMaps.Count - 1;
					num = -1832249845;
					continue;
				case 28:
					goto IL_01e2;
				case 8:
					customControllerMaps[num9].categoryId = id;
					num = -1832249846;
					continue;
				case 5:
					num7 = DuplicateMouseMap(num8);
					num = -1832249852;
					continue;
				case 26:
					if (duplicateMaps)
					{
						id = inputMapCategory.id;
						num = -1832249842;
						continue;
					}
					return;
				case 11:
					if (mouseMaps != null)
					{
						num8 = mouseMaps.Count - 1;
						num = -1832249847;
						continue;
					}
					goto case 0;
				case 0:
					if (customControllerMaps != null)
					{
						num3 = customControllerMaps.Count - 1;
						num = -1832249841;
						continue;
					}
					return;
				case 18:
					num8--;
					num = -1832249847;
					continue;
				case 24:
					num3--;
					num = -1832249841;
					continue;
				case 12:
					goto IL_02bd;
				case 22:
					goto IL_02e5;
				case 27:
					goto IL_02fe;
				case 16:
					num4--;
					num = -1832249851;
					continue;
				case 2:
					mouseMaps[num7].categoryId = id;
					num = -1832249856;
					continue;
				case 29:
					goto IL_0344;
				case 25:
					goto IL_035d;
				case 10:
					num = -1832249851;
					continue;
				case 4:
					goto IL_037f;
				case 21:
					if (keyboardMaps[num4].categoryId == id2)
					{
						int num5 = DuplicateKeyboardMap(num4);
						if (num5 >= 0)
						{
							keyboardMaps[num5].categoryId = id;
							num = -1832249854;
							continue;
						}
					}
					goto case 16;
				case 9:
					if (num2 >= 0)
					{
						joystickMaps[num2].categoryId = id;
						num = -1832249827;
						continue;
					}
					goto case 15;
				case 3:
					return;
				}
				break;
				IL_035d:
				int num10;
				if (num6 < 0)
				{
					num = -1832249853;
					num10 = num;
				}
				else
				{
					num = -1832249826;
					num10 = num;
				}
				continue;
				IL_011d:
				int num11;
				if (mouseMaps[num8].categoryId != id2)
				{
					num = -1832249856;
					num11 = num;
				}
				else
				{
					num = -1832249833;
					num11 = num;
				}
				continue;
				IL_02bd:
				int num12;
				if (joystickMaps[num6].categoryId == id2)
				{
					num = -1832249850;
					num12 = num;
				}
				else
				{
					num = -1832249827;
					num12 = num;
				}
				continue;
				IL_0344:
				int num13;
				if (num3 >= 0)
				{
					num = -1832249828;
					num13 = num;
				}
				else
				{
					num = -1832249839;
					num13 = num;
				}
				continue;
				IL_02e5:
				int num14;
				if (num7 < 0)
				{
					num = -1832249856;
					num14 = num;
				}
				else
				{
					num = -1832249840;
					num14 = num;
				}
				continue;
				IL_00cc:
				num9 = DuplicateCustomControllerMap(num3);
				int num15;
				if (num9 >= 0)
				{
					num = -1832249830;
					num15 = num;
				}
				else
				{
					num = -1832249846;
					num15 = num;
				}
				continue;
				IL_02fe:
				int num16;
				if (num8 >= 0)
				{
					num = -1832249855;
					num16 = num;
				}
				else
				{
					num = -1832249838;
					num16 = num;
				}
				continue;
				IL_01e2:
				id2 = mapCategories[index].id;
				int num17;
				if (joystickMaps != null)
				{
					num = -1832249835;
					num17 = num;
				}
				else
				{
					num = -1832249853;
					num17 = num;
				}
				continue;
				IL_00ef:
				int num18;
				if (num4 >= 0)
				{
					num = -1832249849;
					num18 = num;
				}
				else
				{
					num = -1832249831;
					num18 = num;
				}
			}
			goto IL_0023;
		}

		public int GetMapCategoryMapCount(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps == null)
			{
				goto IL_0080;
			}
			int num2 = 0;
			goto IL_0150;
			IL_00bf:
			int num3 = default(int);
			int num4;
			if (mouseMaps != null)
			{
				num3 = 0;
				num4 = -1391757752;
				goto IL_0020;
			}
			goto IL_01a8;
			IL_0080:
			int num5 = default(int);
			if (keyboardMaps != null)
			{
				num5 = 0;
				num4 = -1391757732;
				goto IL_0020;
			}
			goto IL_00bf;
			IL_0150:
			int num6;
			if (num2 >= joystickMaps.Count)
			{
				num4 = -1391757730;
				num6 = num4;
			}
			else
			{
				num4 = -1391757753;
				num6 = num4;
			}
			goto IL_0020;
			IL_0234:
			return num;
			IL_01a8:
			int num7 = default(int);
			if (customControllerMaps != null)
			{
				num7 = 0;
				num4 = -1391757759;
				goto IL_0020;
			}
			goto IL_0234;
			IL_0020:
			while (true)
			{
				switch (num4 ^ -1391757748)
				{
				case 19:
					num4 = -1391757753;
					continue;
				case 18:
					break;
				case 8:
					num5++;
					num4 = -1391757747;
					continue;
				case 12:
					goto IL_009c;
				case 2:
					goto IL_00bf;
				case 6:
					if (mouseMaps[num3].categoryId == id)
					{
						num++;
						num4 = -1391757751;
						continue;
					}
					goto case 5;
				case 7:
					num++;
					num4 = -1391757756;
					continue;
				case 4:
					goto IL_0106;
				case 13:
					num4 = -1391757760;
					continue;
				case 5:
					num3++;
					num4 = -1391757752;
					continue;
				case 17:
					num7++;
					num4 = -1391757760;
					continue;
				case 3:
					goto IL_0150;
				case 14:
					num2++;
					num4 = -1391757745;
					continue;
				case 9:
					goto IL_0180;
				case 10:
					goto IL_01a8;
				case 16:
					num4 = -1391757747;
					continue;
				case 11:
					if (joystickMaps[num2].categoryId == id)
					{
						num++;
						num4 = -1391757758;
						continue;
					}
					goto case 14;
				case 15:
					if (customControllerMaps[num7].categoryId == id)
					{
						num++;
						num4 = -1391757731;
						continue;
					}
					goto case 17;
				case 1:
					goto IL_0212;
				default:
					goto IL_0234;
				}
				break;
				IL_0212:
				int num8;
				if (num5 < keyboardMaps.Count)
				{
					num4 = -1391757755;
					num8 = num4;
				}
				else
				{
					num4 = -1391757746;
					num8 = num4;
				}
				continue;
				IL_0106:
				int num9;
				if (num3 < mouseMaps.Count)
				{
					num4 = -1391757750;
					num9 = num4;
				}
				else
				{
					num4 = -1391757754;
					num9 = num4;
				}
				continue;
				IL_009c:
				int num10;
				if (num7 >= customControllerMaps.Count)
				{
					num4 = -1391757748;
					num10 = num4;
				}
				else
				{
					num4 = -1391757757;
					num10 = num4;
				}
				continue;
				IL_0180:
				int num11;
				if (keyboardMaps[num5].categoryId == id)
				{
					num4 = -1391757749;
					num11 = num4;
				}
				else
				{
					num4 = -1391757756;
					num11 = num4;
				}
			}
			goto IL_0080;
		}

		public int GetMapCategoryIndex(int id)
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 419663097;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x19038CF8)
				{
				case 4:
					break;
				case 3:
					return 0;
				case 1:
				{
					int num3;
					if (num < mapCategories.Count)
					{
						num2 = 419663096;
						num3 = num2;
					}
					else
					{
						num2 = 419663098;
						num3 = num2;
					}
					continue;
				}
				case 0:
					if (mapCategories[num].id == id)
					{
						return num;
					}
					num++;
					num2 = 419663097;
					continue;
				default:
					return -1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 419663099;
			goto IL_000d;
		}

		public string[] GetMapCategoryNames()
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			string[] array = new string[mapCategories.Count];
			int num = 473098585;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x1C32E95B)
				{
				case 3:
					break;
				case 0:
					array[num2] = mapCategories[num2].name;
					num2++;
					num = 473098591;
					continue;
				case 2:
					num2 = 0;
					num = 473098591;
					continue;
				case 1:
					return null;
				default:
					if (num2 >= mapCategories.Count)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = 473098586;
			goto IL_000d;
		}

		public int[] GetMapCategoryIds()
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int[] array = new int[mapCategories.Count];
			int num = 0;
			int num2 = 1493980140;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x590C53EF)
				{
				case 0:
					break;
				case 2:
					return null;
				case 1:
					goto IL_0046;
				default:
					if (num < mapCategories.Count)
					{
						goto IL_0046;
					}
					return array;
				}
				break;
				IL_0046:
				array[num] = mapCategories[num].id;
				num++;
				num2 = 1493980140;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1493980141;
			goto IL_000d;
		}

		public InputMapCategory GetMapCategory(int index)
		{
			if (mapCategories != null)
			{
				while (true)
				{
					int num = 902807515;
					while (true)
					{
						switch (num ^ 0x35CFBFDA)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						if (index >= mapCategories.Count)
						{
							num = 902807514;
							continue;
						}
						return mapCategories[index];
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputMapCategory GetMapCategory(string name)
		{
			if (mapCategories == null)
			{
				return null;
			}
			int num = IndexOfMapCategory(name);
			if (num < 0)
			{
				return null;
			}
			return mapCategories[num];
		}

		public InputMapCategory GetMapCategoryById(int id)
		{
			if (mapCategories == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < mapCategories.Count)
				{
					num2 = 326849797;
					num3 = num2;
				}
				else
				{
					num2 = 326849796;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x137B5506)
					{
					case 0:
						num2 = 326849797;
						continue;
					case 3:
						if (mapCategories[num].id == id)
						{
							return mapCategories[num];
						}
						num++;
						num2 = 326849799;
						continue;
					case 1:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		public int GetMapCategoryId(string name)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			int num = IndexOfMapCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return mapCategories[num].id;
		}

		public string GetMapCategoryNameById(int id)
		{
			if (mapCategories == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (num < mapCategories.Count)
			{
				while (true)
				{
					int num2;
					if (mapCategories[num].id == id)
					{
						num2 = 168392411;
					}
					else
					{
						num++;
						num2 = 168392408;
					}
					while (true)
					{
						switch (num2 ^ 0xA0976DB)
						{
						case 2:
							num2 = 168392410;
							continue;
						case 1:
							break;
						case 0:
							return mapCategories[num].name;
						default:
							goto end_IL_0034;
						}
						break;
					}
					continue;
					end_IL_0034:
					break;
				}
			}
			return string.Empty;
		}

		public int IndexOfMapCategory(int id)
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 655692083;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x27151133)
				{
				case 2:
					break;
				case 1:
					return -1;
				case 3:
					if (mapCategories[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= mapCategories.Count)
					{
						return -1;
					}
					goto case 3;
				}
				break;
				IL_004b:
				num++;
				num2 = 655692083;
			}
			goto IL_0008;
			IL_0008:
			num2 = 655692082;
			goto IL_000d;
		}

		public int IndexOfMapCategory(string name)
		{
			if (name != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 1630188430;
					while (true)
					{
						switch (num ^ 0x612AB38A)
						{
						case 2:
							break;
						case 4:
							goto IL_0031;
						case 5:
							return -1;
						case 3:
							goto IL_0050;
						case 0:
							goto end_IL_0003;
						case 6:
							goto IL_0080;
						default:
							return -1;
						}
						break;
						IL_0080:
						if (mapCategories[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							return num2;
						}
						num2++;
						num = 1630188425;
						continue;
						IL_0050:
						int num3;
						if (num2 < mapCategories.Count)
						{
							num = 1630188428;
							num3 = num;
						}
						else
						{
							num = 1630188427;
							num3 = num;
						}
						continue;
						IL_0031:
						if (name == string.Empty)
						{
							num = 1630188426;
						}
						else if (mapCategories != null)
						{
							num2 = 0;
							num = 1630188425;
						}
						else
						{
							num = 1630188431;
						}
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return -1;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					switch (0x20522AD4 ^ 0x20522AD6)
					{
					case 0:
						continue;
					case 2:
						if (controllerType == ControllerType.Custom)
						{
							return GetCustomControllerLayoutNames();
						}
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerType.Keyboard;
			case ControllerType.Keyboard:
				return GetKeyboardLayoutNames();
			case ControllerType.Mouse:
				return GetMouseLayoutNames();
			case ControllerType.Joystick:
				return GetJoystickLayoutNames();
			}
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return GetKeyboardLayoutIds();
			case ControllerType.Mouse:
				return GetMouseLayoutIds();
			case ControllerType.Joystick:
				return GetJoystickLayoutIds();
			case ControllerType.Custom:
				return GetCustomControllerLayoutIds();
			default:
				throw new NotImplementedException();
			}
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(MRuWhnXcyXxedGPBuqruWjMkwWX());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= joystickLayouts.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0046:
			joystickLayouts.Insert(index, MRuWhnXcyXxedGPBuqruWjMkwWX());
			int num = -175244905;
			goto IL_0017;
			IL_0012:
			num = -175244906;
			goto IL_0017;
			IL_0017:
			switch (num ^ -175244905)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 3:
				goto IL_0046;
			case 0:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0)
			{
				goto IL_0066;
			}
			if (index >= joystickLayouts.Count)
			{
				goto IL_001d;
			}
			goto IL_0131;
			IL_0131:
			int id = joystickLayouts[index].id;
			int num = default(int);
			int num2;
			if (joystickMaps != null)
			{
				num = joystickMaps.Count - 1;
				num2 = -817245694;
				goto IL_0022;
			}
			goto IL_0163;
			IL_00a9:
			joystickLayouts.RemoveAt(index);
			num2 = -817245687;
			goto IL_0022;
			IL_001d:
			num2 = -817245688;
			goto IL_0022;
			IL_0022:
			int num3 = default(int);
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			while (true)
			{
				switch (num2 ^ -817245682)
				{
				case 3:
					break;
				default:
					return;
				case 6:
					goto IL_0066;
				case 8:
					goto IL_0078;
				case 4:
					goto IL_0087;
				case 5:
					goto IL_00a9;
				case 0:
				{
					Player_Editor player_Editor = players[num3];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultJoystickMaps, id);
						num2 = -817245681;
						continue;
					}
					goto case 1;
				}
				case 11:
					if (joystickMaps[num].layoutId == id)
					{
						joystickMaps.RemoveAt(num);
						num2 = -817245689;
						continue;
					}
					goto case 9;
				case 12:
					goto IL_0119;
				case 2:
					goto IL_0131;
				case 10:
					goto IL_0163;
				case 1:
					num3++;
					num2 = -817245686;
					continue;
				case 9:
					num--;
					num2 = -817245694;
					continue;
				case 7:
					return;
				}
				break;
				IL_0119:
				int num4;
				if (num >= 0)
				{
					num2 = -817245691;
					num4 = num2;
				}
				else
				{
					num2 = -817245692;
					num4 = num2;
				}
				continue;
				IL_0087:
				int num5;
				if (num3 >= players.Count)
				{
					num2 = -817245685;
					num5 = num2;
				}
				else
				{
					num2 = -817245682;
					num5 = num2;
				}
			}
			goto IL_001d;
			IL_0066:
			throw new ArgumentOutOfRangeException("index");
			IL_0163:
			if (players != null)
			{
				if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate62 == null)
				{
					CS_0024_003C_003E9__CachedAnonymousMethodDelegate62 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
					{
						if (P_0 == null)
						{
							goto IL_0003;
						}
						goto IL_0068;
						IL_0003:
						int num6 = -941099146;
						goto IL_0008;
						IL_0008:
						int num7 = default(int);
						while (true)
						{
							switch (num6 ^ -941099149)
							{
							case 6:
								break;
							case 8:
								num6 = -941099151;
								continue;
							case 1:
								goto IL_0040;
							case 5:
								return;
							case 7:
								goto IL_0068;
							case 0:
								P_0.RemoveAt(num7);
								num6 = -941099152;
								continue;
							case 4:
							{
								int num8;
								if (P_0[num7] != null)
								{
									num6 = -941099150;
									num8 = num6;
								}
								else
								{
									num6 = -941099149;
									num8 = num6;
								}
								continue;
							}
							case 3:
								num7--;
								num6 = -941099151;
								continue;
							default:
								if (num7 < 0)
								{
									return;
								}
								goto case 4;
							}
							break;
							IL_0040:
							int num9;
							if (P_0[num7].layoutId == P_1)
							{
								num6 = -941099149;
								num9 = num6;
							}
							else
							{
								num6 = -941099152;
								num9 = num6;
							}
						}
						goto IL_0003;
						IL_0068:
						num7 = P_0.Count - 1;
						num6 = -941099141;
						goto IL_0008;
					};
					num2 = -817245690;
					goto IL_0022;
				}
				goto IL_0078;
			}
			goto IL_00a9;
			IL_0078:
			cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate62;
			num3 = 0;
			num2 = -817245686;
			goto IL_0022;
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (joystickLayouts == null || index < 0)
			{
				goto IL_0164;
			}
			if (index >= joystickLayouts.Count)
			{
				goto IL_0023;
			}
			goto IL_0191;
			IL_0164:
			throw new ArgumentOutOfRangeException("index");
			IL_0191:
			InputLayout inputLayout = joystickLayouts[index].Clone();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames());
			int num = -1667729654;
			goto IL_0028;
			IL_0023:
			num = -1667729651;
			goto IL_0028;
			IL_0028:
			int id2 = default(int);
			int num3 = default(int);
			int num2 = default(int);
			int id = default(int);
			while (true)
			{
				switch (num ^ -1667729653)
				{
				case 10:
					break;
				default:
					return;
				case 12:
					id2 = inputLayout.id;
					num = -1667729664;
					continue;
				case 0:
					num3--;
					num = -1667729661;
					continue;
				case 4:
					if (num2 >= 0)
					{
						joystickMaps[num2].layoutId = id2;
						num = -1667729653;
						continue;
					}
					goto case 0;
				case 3:
					if (joystickMaps[num3].layoutId == id)
					{
						num2 = DuplicateJoystickMap(num3);
						num = -1667729649;
						continue;
					}
					goto case 0;
				case 5:
					goto IL_00cf;
				case 13:
					joystickLayouts.Insert(index + 1, inputLayout);
					num = -1667729650;
					continue;
				case 9:
					if (joystickMaps != null)
					{
						num3 = joystickMaps.Count - 1;
						num = -1667729661;
						continue;
					}
					return;
				case 1:
					if (index == joystickLayouts.Count - 1)
					{
						joystickLayouts.Add(inputLayout);
						num = -1667729650;
						continue;
					}
					goto case 13;
				case 11:
					id = joystickLayouts[index].id;
					num = -1667729662;
					continue;
				case 6:
					goto IL_0164;
				case 8:
					goto IL_0179;
				case 2:
					goto IL_0191;
				case 7:
					return;
				}
				break;
				IL_0179:
				int num4;
				if (num3 >= 0)
				{
					num = -1667729656;
					num4 = num;
				}
				else
				{
					num = -1667729652;
					num4 = num;
				}
				continue;
				IL_00cf:
				int num5;
				if (duplicateMaps)
				{
					num = -1667729657;
					num5 = num;
				}
				else
				{
					num = -1667729652;
					num5 = num;
				}
			}
			goto IL_0023;
		}

		public int GetJoystickLayoutMapCount(int id)
		{
			if (joystickLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2;
			int num3;
			if (joystickMaps == null)
			{
				num2 = -153475604;
				num3 = num2;
			}
			else
			{
				num2 = -153475606;
				num3 = num2;
			}
			goto IL_000d;
			IL_0008:
			num2 = -153475602;
			goto IL_000d;
			IL_000d:
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -153475607)
				{
				case 0:
					break;
				case 1:
					num++;
					num2 = -153475603;
					continue;
				case 4:
					num4++;
					num2 = -153475615;
					continue;
				case 2:
					num2 = -153475615;
					continue;
				case 7:
					return 0;
				case 6:
				{
					int num6;
					if (joystickMaps[num4].layoutId != id)
					{
						num2 = -153475603;
						num6 = num2;
					}
					else
					{
						num2 = -153475608;
						num6 = num2;
					}
					continue;
				}
				case 3:
					num4 = 0;
					num2 = -153475605;
					continue;
				case 8:
				{
					int num5;
					if (num4 >= joystickMaps.Count)
					{
						num2 = -153475604;
						num5 = num2;
					}
					else
					{
						num2 = -153475601;
						num5 = num2;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
			goto IL_0008;
		}

		public int GetJoystickLayoutIndex(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (num < joystickLayouts.Count)
			{
				while (true)
				{
					int num2;
					if (joystickLayouts[num].id == id)
					{
						num2 = -455052346;
					}
					else
					{
						num++;
						num2 = -455052348;
					}
					while (true)
					{
						switch (num2 ^ -455052347)
						{
						case 0:
							num2 = -455052345;
							continue;
						case 2:
							break;
						case 3:
							return num;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public string[] GetJoystickLayoutNames()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			string[] array = new string[joystickLayouts.Count];
			int num2 = default(int);
			while (true)
			{
				int num = 1117134009;
				while (true)
				{
					switch (num ^ 0x42961CBD)
					{
					case 3:
						break;
					case 0:
					{
						int num3;
						if (num2 < joystickLayouts.Count)
						{
							num = 1117134012;
							num3 = num;
						}
						else
						{
							num = 1117134015;
							num3 = num;
						}
						continue;
					}
					case 1:
						array[num2] = joystickLayouts[num2].name;
						num2++;
						num = 1117134013;
						continue;
					case 4:
						num2 = 0;
						num = 1117134013;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetJoystickLayoutIds()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int[] array = new int[joystickLayouts.Count];
			int num = 0;
			while (true)
			{
				int num2 = -1454605025;
				while (true)
				{
					switch (num2 ^ -1454605027)
					{
					case 0:
						break;
					case 2:
						num2 = -1454605026;
						continue;
					case 1:
						array[num] = joystickLayouts[num].id;
						num++;
						num2 = -1454605026;
						continue;
					default:
						if (num >= joystickLayouts.Count)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public InputLayout GetJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				return null;
			}
			return joystickLayouts[index];
		}

		public InputLayout GetJoystickLayout(string name)
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int num = IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return null;
			}
			return joystickLayouts[num];
		}

		public InputLayout GetJoystickLayoutById(int id)
		{
			if (joystickLayouts == null)
			{
				goto IL_0008;
			}
			int num = IndexOfJoystickLayout(id);
			int num2;
			if (num < 0)
			{
				num2 = -1807824880;
				goto IL_000d;
			}
			return joystickLayouts[num];
			IL_0008:
			num2 = -1807824877;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -1807824879)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return null;
			}
			goto IL_0008;
		}

		public int GetJoystickLayoutId(string name)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			int num = IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return joystickLayouts[num].id;
		}

		public int IndexOfJoystickLayout(int id)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (num < joystickLayouts.Count)
			{
				while (true)
				{
					if (joystickLayouts[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 1410931522;
					while (true)
					{
						switch (num2 ^ 0x54191B43)
						{
						case 0:
							num2 = 1410931521;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public int IndexOfJoystickLayout(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (joystickLayouts == null)
				{
					return -1;
				}
				num = 0;
				num2 = -379326737;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -379326740)
				{
				case 0:
					break;
				case 1:
					goto IL_0036;
				case 3:
					goto IL_004b;
				case 2:
					goto IL_006a;
				default:
					return -1;
				}
				break;
				IL_006a:
				if (joystickLayouts[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = -379326737;
				continue;
				IL_004b:
				int num3;
				if (num < joystickLayouts.Count)
				{
					num2 = -379326738;
					num3 = num2;
				}
				else
				{
					num2 = -379326744;
					num3 = num2;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = -379326739;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			if (joystickLayouts != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -2071560612;
					while (true)
					{
						switch (num ^ -2071560611)
						{
						case 0:
							break;
						case 1:
							num2 = 0;
							num = -2071560615;
							continue;
						case 4:
							goto IL_0037;
						case 2:
							goto IL_0056;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0056:
						if (joystickLayouts[num2].id == id)
						{
							return joystickLayouts[num2].name;
						}
						num2++;
						num = -2071560615;
						continue;
						IL_0037:
						int num3;
						if (num2 < joystickLayouts.Count)
						{
							num = -2071560609;
							num3 = num;
						}
						else
						{
							num = -2071560610;
							num3 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return "Unknown";
		}

		public void AddKeyboardLayout()
		{
			keyboardLayouts.Add(lJPLAFvwFWSpNMjvjceqzxyzOnx());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index >= 0)
			{
				if (index < keyboardLayouts.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-1972531831 ^ -1972531832)
					{
					case 2:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			keyboardLayouts.Insert(index, lJPLAFvwFWSpNMjvjceqzxyzOnx());
		}

		public void DeleteKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0)
			{
				goto IL_00ff;
			}
			if (index >= keyboardLayouts.Count)
			{
				goto IL_0023;
			}
			goto IL_0199;
			IL_0199:
			int id = keyboardLayouts[index].id;
			int num = default(int);
			int num2;
			if (keyboardMaps != null)
			{
				num = keyboardMaps.Count - 1;
				num2 = 1365933688;
				goto IL_0028;
			}
			goto IL_0176;
			IL_01d7:
			keyboardLayouts.RemoveAt(index);
			return;
			IL_0023:
			num2 = 1365933684;
			goto IL_0028;
			IL_0028:
			int num3 = default(int);
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			while (true)
			{
				switch (num2 ^ 0x516A7E70)
				{
				case 2:
					break;
				case 0:
					num2 = 1365933683;
					continue;
				case 13:
				{
					Player_Editor player_Editor = players[num3];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultKeyboardMaps, id);
						num2 = 1365933687;
						continue;
					}
					goto case 7;
				}
				case 1:
					CS_0024_003C_003E9__CachedAnonymousMethodDelegate64 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
					{
						if (P_0 == null)
						{
							return;
						}
						while (true)
						{
							int num7 = P_0.Count - 1;
							int num8 = 1167924002;
							while (true)
							{
								switch (num8 ^ 0x459D1B26)
								{
								case 2:
									num8 = 1167924005;
									continue;
								default:
									return;
								case 4:
								{
									int num11;
									if (num7 < 0)
									{
										num8 = 1167924001;
										num11 = num8;
									}
									else
									{
										num8 = 1167924006;
										num11 = num8;
									}
									continue;
								}
								case 1:
									num7--;
									num8 = 1167924002;
									continue;
								case 6:
								{
									int num10;
									if (P_0[num7].layoutId == P_1)
									{
										num8 = 1167924003;
										num10 = num8;
									}
									else
									{
										num8 = 1167924007;
										num10 = num8;
									}
									continue;
								}
								case 0:
								{
									int num9;
									if (P_0[num7] != null)
									{
										num8 = 1167924000;
										num9 = num8;
									}
									else
									{
										num8 = 1167924003;
										num9 = num8;
									}
									continue;
								}
								case 5:
									P_0.RemoveAt(num7);
									num8 = 1167924007;
									continue;
								case 3:
									break;
								case 7:
									return;
								}
								break;
							}
						}
					};
					num2 = 1365933685;
					continue;
				case 15:
					num--;
					num2 = 1365933692;
					continue;
				case 14:
					if (keyboardMaps[num].layoutId == id)
					{
						keyboardMaps.RemoveAt(num);
						num2 = 1365933695;
						continue;
					}
					goto case 15;
				case 4:
					goto IL_00ff;
				case 7:
					num3++;
					num2 = 1365933683;
					continue;
				case 3:
					goto IL_0122;
				case 5:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate64;
					num2 = 1365933686;
					continue;
				case 12:
					goto IL_0154;
				case 8:
					num2 = 1365933692;
					continue;
				case 10:
					goto IL_0176;
				case 9:
					goto IL_0199;
				case 6:
					num3 = 0;
					num2 = 1365933680;
					continue;
				default:
					goto IL_01d7;
				}
				break;
				IL_0154:
				int num4;
				if (num >= 0)
				{
					num2 = 1365933694;
					num4 = num2;
				}
				else
				{
					num2 = 1365933690;
					num4 = num2;
				}
				continue;
				IL_0122:
				int num5;
				if (num3 >= players.Count)
				{
					num2 = 1365933691;
					num5 = num2;
				}
				else
				{
					num2 = 1365933693;
					num5 = num2;
				}
			}
			goto IL_0023;
			IL_0176:
			if (players != null)
			{
				int num6;
				if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate64 == null)
				{
					num2 = 1365933681;
					num6 = num2;
				}
				else
				{
					num2 = 1365933685;
					num6 = num2;
				}
				goto IL_0028;
			}
			goto IL_01d7;
			IL_00ff:
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (keyboardLayouts == null || index < 0)
			{
				goto IL_00c8;
			}
			if (index >= keyboardLayouts.Count)
			{
				goto IL_0023;
			}
			goto IL_0144;
			IL_0144:
			InputLayout inputLayout = keyboardLayouts[index].Clone();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames());
			int num;
			if (index == keyboardLayouts.Count - 1)
			{
				keyboardLayouts.Add(inputLayout);
				num = -744950717;
				goto IL_0028;
			}
			goto IL_0076;
			IL_0076:
			keyboardLayouts.Insert(index + 1, inputLayout);
			num = -744950717;
			goto IL_0028;
			IL_0023:
			num = -744950718;
			goto IL_0028;
			IL_0028:
			int num3 = default(int);
			int id2 = default(int);
			int num2 = default(int);
			int id = default(int);
			while (true)
			{
				switch (num ^ -744950720)
				{
				case 0:
					break;
				default:
					return;
				case 10:
					num = -744950712;
					continue;
				case 6:
					num3--;
					num = -744950712;
					continue;
				case 9:
					goto IL_0076;
				case 8:
					goto IL_008c;
				case 4:
					if (keyboardMaps[num3].layoutId == id2)
					{
						num2 = DuplicateKeyboardMap(num3);
						num = -744950715;
						continue;
					}
					goto case 6;
				case 2:
					goto IL_00c8;
				case 3:
					if (duplicateMaps)
					{
						id = inputLayout.id;
						id2 = keyboardLayouts[index].id;
						if (keyboardMaps != null)
						{
							num3 = keyboardMaps.Count - 1;
							num = -744950710;
							continue;
						}
					}
					return;
				case 5:
					if (num2 >= 0)
					{
						keyboardMaps[num2].layoutId = id;
						num = -744950714;
						continue;
					}
					goto case 6;
				case 7:
					goto IL_0144;
				case 1:
					return;
				}
				break;
				IL_008c:
				int num4;
				if (num3 >= 0)
				{
					num = -744950716;
					num4 = num;
				}
				else
				{
					num = -744950719;
					num4 = num;
				}
			}
			goto IL_0023;
			IL_00c8:
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetKeyboardLayoutMapCount(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (keyboardMaps != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3;
					int num4;
					if (num2 >= keyboardMaps.Count)
					{
						num3 = 1825639818;
						num4 = num3;
					}
					else
					{
						num3 = 1825639820;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x6CD10D88)
						{
						case 0:
							num3 = 1825639820;
							continue;
						case 4:
							if (keyboardMaps[num2].layoutId == id)
							{
								num++;
								num3 = 1825639817;
								continue;
							}
							goto case 1;
						case 1:
							num2++;
							num3 = 1825639819;
							continue;
						case 3:
							break;
						default:
							goto end_IL_0068;
						}
						break;
					}
					continue;
					end_IL_0068:
					break;
				}
			}
			return num;
		}

		public int GetKeyboardLayoutIndex(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (num < keyboardLayouts.Count)
			{
				while (true)
				{
					int num2;
					if (keyboardLayouts[num].id == id)
					{
						num2 = -1604053951;
					}
					else
					{
						num++;
						num2 = -1604053952;
					}
					while (true)
					{
						switch (num2 ^ -1604053949)
						{
						case 0:
							num2 = -1604053950;
							continue;
						case 1:
							break;
						case 2:
							return num;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public string[] GetKeyboardLayoutNames()
		{
			if (keyboardLayouts == null)
			{
				goto IL_0008;
			}
			string[] array = new string[keyboardLayouts.Count];
			int num = 0;
			int num2 = 1907741000;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x71B5D149)
				{
				case 2:
					break;
				case 3:
					return null;
				case 0:
					goto IL_0046;
				default:
					if (num < keyboardLayouts.Count)
					{
						goto IL_0046;
					}
					return array;
				}
				break;
				IL_0046:
				array[num] = keyboardLayouts[num].name;
				num++;
				num2 = 1907741000;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1907741002;
			goto IL_000d;
		}

		public int[] GetKeyboardLayoutIds()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int[] array = new int[keyboardLayouts.Count];
			int num = 0;
			while (num < keyboardLayouts.Count)
			{
				while (true)
				{
					array[num] = keyboardLayouts[num].id;
					num++;
					int num2 = 567497254;
					while (true)
					{
						switch (num2 ^ 0x21D35226)
						{
						case 2:
							num2 = 567497255;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public InputLayout GetKeyboardLayout(int index)
		{
			if (keyboardLayouts != null && index >= 0)
			{
				while (true)
				{
					int num = 553902056;
					while (true)
					{
						switch (num ^ 0x2103DFE9)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (index >= keyboardLayouts.Count)
						{
							num = 553902057;
							continue;
						}
						return keyboardLayouts[index];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
		}

		public InputLayout GetKeyboardLayout(string name)
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int num = IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return null;
			}
			return keyboardLayouts[num];
		}

		public InputLayout GetKeyboardLayoutById(int id)
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int num = IndexOfKeyboardLayout(id);
			if (num < 0)
			{
				return null;
			}
			return keyboardLayouts[num];
		}

		public int GetKeyboardLayoutId(string name)
		{
			if (keyboardLayouts == null)
			{
				return -1;
			}
			int num = IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return keyboardLayouts[num].id;
		}

		public int IndexOfKeyboardLayout(int id)
		{
			if (keyboardLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -732207068;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -732207068)
				{
				case 3:
					break;
				case 1:
					return -1;
				case 2:
					if (keyboardLayouts[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= keyboardLayouts.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_004b:
				num++;
				num2 = -732207068;
			}
			goto IL_0008;
			IL_0008:
			num2 = -732207067;
			goto IL_000d;
		}

		public int IndexOfKeyboardLayout(string name)
		{
			if (name != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -1718153919;
					while (true)
					{
						switch (num ^ -1718153916)
						{
						case 4:
							break;
						case 5:
							goto IL_0031;
						case 1:
							goto end_IL_0003;
						case 0:
							goto IL_0056;
						case 6:
							return num2;
						case 3:
							return -1;
						default:
							if (num2 >= keyboardLayouts.Count)
							{
								return -1;
							}
							goto IL_0056;
						}
						break;
						IL_0056:
						if (keyboardLayouts[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							num = -1718153918;
							continue;
						}
						num2++;
						num = -1718153914;
						continue;
						IL_0031:
						if (name == string.Empty)
						{
							num = -1718153915;
							continue;
						}
						if (keyboardLayouts == null)
						{
							num = -1718153913;
							continue;
						}
						num2 = 0;
						num = -1718153914;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return -1;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			if (keyboardLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= keyboardLayouts.Count)
					{
						num2 = -1533480316;
						num3 = num2;
					}
					else
					{
						num2 = -1533480313;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1533480315)
						{
						case 0:
							num2 = -1533480313;
							continue;
						case 2:
							break;
						case 3:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (keyboardLayouts[num].id == id)
						{
							return keyboardLayouts[num].name;
						}
						num++;
						num2 = -1533480314;
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
			}
			return "Unknown";
		}

		public void AddMouseLayout()
		{
			mouseLayouts.Add(HsYAEuoJsMgixjhiqiMzeZkQlsBA());
		}

		public void InsertMouseLayout(int index)
		{
			if (index >= 0)
			{
				if (index < mouseLayouts.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-611439266 ^ -611439265)
					{
					case 0:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			mouseLayouts.Insert(index, HsYAEuoJsMgixjhiqiMzeZkQlsBA());
		}

		public void DeleteMouseLayout(int index)
		{
			if (mouseLayouts != null && index >= 0)
			{
				if (index >= mouseLayouts.Count)
				{
					goto IL_0023;
				}
				goto IL_00de;
			}
			goto IL_01b8;
			IL_01b8:
			throw new ArgumentOutOfRangeException("index");
			IL_00de:
			int id = mouseLayouts[index].id;
			int num;
			int num2;
			if (mouseMaps != null)
			{
				num = -1714668355;
				num2 = num;
			}
			else
			{
				num = -1714668368;
				num2 = num;
			}
			goto IL_0028;
			IL_0023:
			num = -1714668365;
			goto IL_0028;
			IL_0028:
			int num4 = default(int);
			int num3 = default(int);
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			while (true)
			{
				switch (num ^ -1714668357)
				{
				case 10:
					break;
				default:
					return;
				case 14:
					mouseMaps.RemoveAt(num4);
					num = -1714668358;
					continue;
				case 16:
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate66 == null)
					{
						CS_0024_003C_003E9__CachedAnonymousMethodDelegate66 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
						{
							if (P_0 == null)
							{
								goto IL_0003;
							}
							goto IL_0073;
							IL_0003:
							int num9 = -1840739911;
							goto IL_0008;
							IL_0008:
							int num10 = default(int);
							while (true)
							{
								switch (num9 ^ -1840739909)
								{
								case 4:
									break;
								case 5:
									P_0.RemoveAt(num10);
									num9 = -1840739907;
									continue;
								case 3:
									num9 = -1840739909;
									continue;
								case 7:
									if (P_0[num10] == null)
									{
										goto case 5;
									}
									goto IL_0053;
								case 1:
									goto IL_0073;
								case 6:
									num10--;
									num9 = -1840739909;
									continue;
								case 2:
									return;
								default:
									if (num10 < 0)
									{
										return;
									}
									goto case 7;
								}
								break;
								IL_0053:
								int num11;
								if (P_0[num10].layoutId != P_1)
								{
									num9 = -1840739907;
									num11 = num9;
								}
								else
								{
									num9 = -1840739906;
									num11 = num9;
								}
							}
							goto IL_0003;
							IL_0073:
							num10 = P_0.Count - 1;
							num9 = -1840739912;
							goto IL_0008;
						};
						num = -1714668361;
						continue;
					}
					goto case 12;
				case 11:
					goto IL_00b4;
				case 1:
					num4--;
					num = -1714668356;
					continue;
				case 15:
					goto IL_00de;
				case 6:
					num4 = mouseMaps.Count - 1;
					num = -1714668353;
					continue;
				case 13:
					goto IL_0124;
				case 9:
				{
					Player_Editor player_Editor = players[num3];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultMouseMaps, id);
						num = -1714668357;
						continue;
					}
					goto case 0;
				}
				case 0:
					num3++;
					num = -1714668359;
					continue;
				case 7:
					goto IL_0184;
				case 4:
					num = -1714668356;
					continue;
				case 12:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate66;
					num3 = 0;
					num = -1714668359;
					continue;
				case 8:
					goto IL_01b8;
				case 2:
					goto IL_01cd;
				case 3:
					mouseLayouts.RemoveAt(index);
					num = -1714668354;
					continue;
				case 5:
					return;
				}
				break;
				IL_01cd:
				int num5;
				if (num3 < players.Count)
				{
					num = -1714668366;
					num5 = num;
				}
				else
				{
					num = -1714668360;
					num5 = num;
				}
				continue;
				IL_0124:
				int num6;
				if (mouseMaps[num4].layoutId != id)
				{
					num = -1714668358;
					num6 = num;
				}
				else
				{
					num = -1714668363;
					num6 = num;
				}
				continue;
				IL_00b4:
				int num7;
				if (players == null)
				{
					num = -1714668360;
					num7 = num;
				}
				else
				{
					num = -1714668373;
					num7 = num;
				}
				continue;
				IL_0184:
				int num8;
				if (num4 < 0)
				{
					num = -1714668368;
					num8 = num;
				}
				else
				{
					num = -1714668362;
					num8 = num;
				}
			}
			goto IL_0023;
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (mouseLayouts != null && index >= 0)
			{
				InputLayout inputLayout = default(InputLayout);
				int id2 = default(int);
				int id = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 2132831622;
					while (true)
					{
						switch (num ^ 0x7F206D81)
						{
						case 12:
							break;
						default:
							return;
						case 1:
							mouseLayouts.Insert(index + 1, inputLayout);
							num = 2132831625;
							continue;
						case 0:
							goto IL_0071;
						case 7:
							goto IL_0086;
						case 6:
							id2 = inputLayout.id;
							id = mouseLayouts[index].id;
							if (mouseMaps != null)
							{
								num2 = mouseMaps.Count - 1;
								num = 2132831621;
								continue;
							}
							return;
						case 4:
							num = 2132831617;
							continue;
						case 2:
							goto end_IL_0012;
						case 3:
							num2--;
							num = 2132831617;
							continue;
						case 9:
							inputLayout = mouseLayouts[index].Clone();
							inputLayout.id = GetNewMouseLayoutId();
							inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames());
							if (index == mouseLayouts.Count - 1)
							{
								mouseLayouts.Add(inputLayout);
								num = 2132831620;
								continue;
							}
							goto case 1;
						case 8:
							goto IL_0170;
						case 11:
							if (mouseMaps[num2].layoutId == id)
							{
								int num3 = DuplicateMouseMap(num2);
								if (num3 >= 0)
								{
									mouseMaps[num3].layoutId = id2;
									num = 2132831618;
									continue;
								}
							}
							goto case 3;
						case 5:
							num = 2132831625;
							continue;
						case 10:
							return;
						}
						break;
						IL_0170:
						int num4;
						if (duplicateMaps)
						{
							num = 2132831623;
							num4 = num;
						}
						else
						{
							num = 2132831627;
							num4 = num;
						}
						continue;
						IL_0086:
						int num5;
						if (index < mouseLayouts.Count)
						{
							num = 2132831624;
							num5 = num;
						}
						else
						{
							num = 2132831619;
							num5 = num;
						}
						continue;
						IL_0071:
						int num6;
						if (num2 < 0)
						{
							num = 2132831627;
							num6 = num;
						}
						else
						{
							num = 2132831626;
							num6 = num;
						}
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetMouseLayoutMapCount(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = 1518478252;
				while (true)
				{
					switch (num2 ^ 0x5A8223AF)
					{
					case 4:
						break;
					case 0:
					{
						int num4;
						if (num3 < mouseMaps.Count)
						{
							num2 = 1518478250;
							num4 = num2;
						}
						else
						{
							num2 = 1518478253;
							num4 = num2;
						}
						continue;
					}
					case 5:
						if (mouseMaps[num3].layoutId == id)
						{
							num++;
							num2 = 1518478254;
							continue;
						}
						goto case 1;
					case 3:
						if (mouseMaps != null)
						{
							num3 = 0;
							num2 = 1518478255;
							continue;
						}
						goto default;
					case 1:
						num3++;
						num2 = 1518478255;
						continue;
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetMouseLayoutIndex(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1117525339;
				while (true)
				{
					switch (num2 ^ 0x429C155A)
					{
					case 0:
						break;
					case 1:
						num2 = 1117525336;
						continue;
					case 3:
						if (mouseLayouts[num].id == id)
						{
							return num;
						}
						num++;
						num2 = 1117525336;
						continue;
					default:
						if (num >= mouseLayouts.Count)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public string[] GetMouseLayoutNames()
		{
			if (mouseLayouts == null)
			{
				goto IL_0008;
			}
			string[] array = new string[mouseLayouts.Count];
			int num = 0;
			int num2 = 234390849;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0xDF88543)
				{
				case 0:
					break;
				case 1:
					return null;
				case 2:
					num2 = 234390854;
					continue;
				case 5:
				{
					int num3;
					if (num >= mouseLayouts.Count)
					{
						num2 = 234390855;
						num3 = num2;
					}
					else
					{
						num2 = 234390848;
						num3 = num2;
					}
					continue;
				}
				case 3:
					array[num] = mouseLayouts[num].name;
					num++;
					num2 = 234390854;
					continue;
				default:
					return array;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 234390850;
			goto IL_000d;
		}

		public int[] GetMouseLayoutIds()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int[] array = new int[mouseLayouts.Count];
			int num = 0;
			while (true)
			{
				int num2 = 1765629291;
				while (true)
				{
					switch (num2 ^ 0x693D5D68)
					{
					case 0:
						break;
					case 3:
						num2 = 1765629290;
						continue;
					case 1:
						array[num] = mouseLayouts[num].id;
						num++;
						num2 = 1765629290;
						continue;
					default:
						if (num >= mouseLayouts.Count)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public InputLayout GetMouseLayout(int index)
		{
			if (mouseLayouts != null)
			{
				while (true)
				{
					int num = 1710245183;
					while (true)
					{
						switch (num ^ 0x65F0453D)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						if (index >= mouseLayouts.Count)
						{
							num = 1710245180;
							continue;
						}
						return mouseLayouts[index];
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputLayout GetMouseLayout(string name)
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int num = IndexOfMouseLayout(name);
			if (num < 0)
			{
				return null;
			}
			return mouseLayouts[num];
		}

		public InputLayout GetMouseLayoutById(int id)
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int num = IndexOfMouseLayout(id);
			if (num < 0)
			{
				return null;
			}
			return mouseLayouts[num];
		}

		public int GetMouseLayoutId(string name)
		{
			if (mouseLayouts == null)
			{
				return -1;
			}
			int num = IndexOfMouseLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return mouseLayouts[num].id;
		}

		public int IndexOfMouseLayout(int id)
		{
			if (mouseLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1559409307;
				while (true)
				{
					switch (num2 ^ -1559409306)
					{
					case 0:
						break;
					case 3:
						num2 = -1559409310;
						continue;
					case 1:
						if (mouseLayouts[num].id == id)
						{
							num2 = -1559409308;
							continue;
						}
						num++;
						num2 = -1559409310;
						continue;
					case 2:
						return num;
					default:
						if (num >= mouseLayouts.Count)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public int IndexOfMouseLayout(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (mouseLayouts == null)
				{
					return -1;
				}
				num = 0;
				num2 = 290774898;
				goto IL_0015;
			}
			goto IL_003e;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x1154DF76)
				{
				case 2:
					break;
				case 1:
					goto IL_003e;
				case 6:
					goto IL_0053;
				case 5:
					goto IL_0072;
				case 4:
					num2 = 290774896;
					continue;
				case 3:
					return num;
				default:
					return -1;
				}
				break;
				IL_0072:
				if (mouseLayouts[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num2 = 290774901;
					continue;
				}
				num++;
				num2 = 290774896;
				continue;
				IL_0053:
				int num3;
				if (num >= mouseLayouts.Count)
				{
					num2 = 290774902;
					num3 = num2;
				}
				else
				{
					num2 = 290774899;
					num3 = num2;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = 290774903;
			goto IL_0015;
			IL_003e:
			return -1;
		}

		public string GetMouseLayoutNameById(int id)
		{
			if (mouseLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= mouseLayouts.Count)
					{
						num2 = 1319691600;
						num3 = num2;
					}
					else
					{
						num2 = 1319691601;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4EA8E553)
						{
						case 4:
							num2 = 1319691601;
							continue;
						case 2:
							break;
						case 0:
							goto end_IL_0014;
						case 1:
							return mouseLayouts[num].name;
						default:
							goto end_IL_0050;
						}
						if (mouseLayouts[num].id == id)
						{
							num2 = 1319691602;
							continue;
						}
						num++;
						num2 = 1319691603;
						continue;
						end_IL_0014:
						break;
					}
					continue;
					end_IL_0050:
					break;
				}
			}
			return "Unknown";
		}

		public void AddCustomControllerLayout()
		{
			customControllerLayouts.Add(IESIZuibhaXwmTIvuvkYbjIfFQg());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -100027788;
					while (true)
					{
						switch (num ^ -100027787)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						case 0:
							goto end_IL_0004;
						default:
							customControllerLayouts.Insert(index, IESIZuibhaXwmTIvuvkYbjIfFQg());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index < customControllerLayouts.Count)
						{
							num = -100027786;
							num2 = num;
						}
						else
						{
							num = -100027787;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteCustomControllerLayout(int index)
		{
			if (customControllerLayouts != null && index >= 0)
			{
				Player_Editor player_Editor = default(Player_Editor);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				int id = default(int);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 1007851683;
					while (true)
					{
						switch (num ^ 0x3C1298AC)
						{
						case 5:
							break;
						default:
							return;
						case 6:
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultCustomControllerMaps, id);
								num = 1007851692;
								continue;
							}
							goto case 0;
						case 2:
							goto end_IL_000c;
						case 10:
							goto IL_009a;
						case 13:
							customControllerMaps.RemoveAt(num2);
							num = 1007851708;
							continue;
						case 14:
							goto IL_00d2;
						case 12:
							goto IL_00fa;
						case 11:
							goto IL_0128;
						case 0:
							num3++;
							num = 1007851686;
							continue;
						case 15:
							goto IL_0152;
						case 9:
							if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate68 == null)
							{
								CS_0024_003C_003E9__CachedAnonymousMethodDelegate68 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
								{
									if (P_0 == null)
									{
										return;
									}
									while (true)
									{
										int num10 = P_0.Count - 1;
										int num11 = -1653348882;
										while (true)
										{
											switch (num11 ^ -1653348886)
											{
											case 0:
												num11 = -1653348885;
												continue;
											case 2:
												P_0.RemoveAt(num10);
												num11 = -1653348881;
												continue;
											case 3:
												if (P_0[num10] != null)
												{
													int num12;
													if (P_0[num10].layoutId != P_1)
													{
														num11 = -1653348881;
														num12 = num11;
													}
													else
													{
														num11 = -1653348888;
														num12 = num11;
													}
													continue;
												}
												goto case 2;
											case 5:
												num10--;
												num11 = -1653348882;
												continue;
											case 1:
												break;
											default:
												if (num10 < 0)
												{
													return;
												}
												goto case 3;
											}
											break;
										}
									}
								};
								num = 1007851695;
								continue;
							}
							goto case 3;
						case 8:
							num2 = customControllerMaps.Count - 1;
							num = 1007851709;
							continue;
						case 17:
							goto IL_01ae;
						case 7:
							player_Editor = players[num3];
							num = 1007851690;
							continue;
						case 16:
							num2--;
							num = 1007851709;
							continue;
						case 3:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate68;
							num3 = 0;
							num = 1007851686;
							continue;
						case 1:
							customControllerLayouts.RemoveAt(index);
							num = 1007851688;
							continue;
						case 4:
							return;
						}
						break;
						IL_01ae:
						int num4;
						if (num2 < 0)
						{
							num = 1007851687;
							num4 = num;
						}
						else
						{
							num = 1007851682;
							num4 = num;
						}
						continue;
						IL_0128:
						int num5;
						if (players == null)
						{
							num = 1007851693;
							num5 = num;
						}
						else
						{
							num = 1007851685;
							num5 = num;
						}
						continue;
						IL_00d2:
						int num6;
						if (customControllerMaps[num2].layoutId == id)
						{
							num = 1007851681;
							num6 = num;
						}
						else
						{
							num = 1007851708;
							num6 = num;
						}
						continue;
						IL_0152:
						int num7;
						if (index < customControllerLayouts.Count)
						{
							num = 1007851680;
							num7 = num;
						}
						else
						{
							num = 1007851694;
							num7 = num;
						}
						continue;
						IL_009a:
						int num8;
						if (num3 < players.Count)
						{
							num = 1007851691;
							num8 = num;
						}
						else
						{
							num = 1007851693;
							num8 = num;
						}
						continue;
						IL_00fa:
						id = customControllerLayouts[index].id;
						int num9;
						if (customControllerMaps == null)
						{
							num = 1007851687;
							num9 = num;
						}
						else
						{
							num = 1007851684;
							num9 = num;
						}
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (customControllerLayouts != null)
			{
				int num3 = default(int);
				int id = default(int);
				InputLayout inputLayout = default(InputLayout);
				int num2 = default(int);
				int id2 = default(int);
				while (true)
				{
					int num = -317606353;
					while (true)
					{
						switch (num ^ -317606364)
						{
						case 7:
							break;
						default:
							return;
						case 10:
							customControllerMaps[num3].layoutId = id;
							num = -317606366;
							continue;
						case 3:
							goto IL_006a;
						case 11:
							goto IL_007f;
						case 2:
							goto end_IL_000b;
						case 1:
							inputLayout = customControllerLayouts[index].Clone();
							inputLayout.id = GetNewCustomControllerLayoutId();
							inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames());
							num = -317606368;
							continue;
						case 4:
							if (index == customControllerLayouts.Count - 1)
							{
								customControllerLayouts.Add(inputLayout);
								num = -317606367;
								continue;
							}
							goto case 9;
						case 9:
							customControllerLayouts.Insert(index + 1, inputLayout);
							num = -317606367;
							continue;
						case 6:
							num2--;
							num = -317606361;
							continue;
						case 0:
							if (customControllerMaps[num2].layoutId != id2)
							{
								goto case 6;
							}
							goto IL_015b;
						case 5:
							if (duplicateMaps)
							{
								id = inputLayout.id;
								id2 = customControllerLayouts[index].id;
								if (customControllerMaps != null)
								{
									num2 = customControllerMaps.Count - 1;
									num = -317606361;
									continue;
								}
							}
							return;
						case 8:
							return;
						}
						break;
						IL_015b:
						num3 = DuplicateCustomControllerMap(num2);
						int num4;
						if (num3 >= 0)
						{
							num = -317606354;
							num4 = num;
						}
						else
						{
							num = -317606366;
							num4 = num;
						}
						continue;
						IL_007f:
						if (index < 0)
						{
							goto end_IL_000b;
						}
						int num5;
						if (index >= customControllerLayouts.Count)
						{
							num = -317606362;
							num5 = num;
						}
						else
						{
							num = -317606363;
							num5 = num;
						}
						continue;
						IL_006a:
						int num6;
						if (num2 >= 0)
						{
							num = -317606364;
							num6 = num;
						}
						else
						{
							num = -317606356;
							num6 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetCustomControllerLayoutMapCount(int id)
		{
			if (customControllerLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (customControllerMaps != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3 = -1641168253;
					while (true)
					{
						switch (num3 ^ -1641168249)
						{
						case 2:
							break;
						case 3:
							num2++;
							num3 = -1641168250;
							continue;
						case 0:
							if (customControllerMaps[num2].layoutId == id)
							{
								num++;
								num3 = -1641168252;
								continue;
							}
							goto case 3;
						case 4:
							num3 = -1641168250;
							continue;
						case 1:
							goto IL_0071;
						default:
							goto end_IL_0016;
						}
						break;
						IL_0071:
						int num4;
						if (num2 >= customControllerMaps.Count)
						{
							num3 = -1641168254;
							num4 = num3;
						}
						else
						{
							num3 = -1641168249;
							num4 = num3;
						}
					}
					continue;
					end_IL_0016:
					break;
				}
			}
			return num;
		}

		public int GetCustomControllerLayoutIndex(int id)
		{
			if (customControllerLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (num < customControllerLayouts.Count)
			{
				while (true)
				{
					if (customControllerLayouts[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 2119117687;
					while (true)
					{
						switch (num2 ^ 0x7E4F2B77)
						{
						case 2:
							num2 = 2119117686;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerLayoutNames()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			string[] array = new string[customControllerLayouts.Count];
			int num2 = default(int);
			while (true)
			{
				int num = 763593773;
				while (true)
				{
					switch (num ^ 0x2D83842F)
					{
					case 0:
						break;
					case 2:
						num2 = 0;
						num = 763593771;
						continue;
					case 3:
						num2++;
						num = 763593771;
						continue;
					case 1:
						array[num2] = customControllerLayouts[num2].name;
						num = 763593772;
						continue;
					default:
						if (num2 >= customControllerLayouts.Count)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public int[] GetCustomControllerLayoutIds()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int[] array = new int[customControllerLayouts.Count];
			int num = 0;
			while (true)
			{
				int num2 = -271332074;
				while (true)
				{
					switch (num2 ^ -271332075)
					{
					case 0:
						break;
					case 3:
						num2 = -271332076;
						continue;
					case 2:
						array[num] = customControllerLayouts[num].id;
						num++;
						num2 = -271332076;
						continue;
					default:
						if (num >= customControllerLayouts.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public InputLayout GetCustomControllerLayout(int index)
		{
			if (customControllerLayouts != null)
			{
				while (true)
				{
					int num = -919945126;
					while (true)
					{
						switch (num ^ -919945128)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						if (index >= customControllerLayouts.Count)
						{
							num = -919945127;
							continue;
						}
						return customControllerLayouts[index];
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputLayout GetCustomControllerLayout(string name)
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int num = IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return null;
			}
			return customControllerLayouts[num];
		}

		public InputLayout GetCustomControllerLayoutById(int id)
		{
			if (customControllerLayouts == null)
			{
				goto IL_0008;
			}
			int num = IndexOfCustomControllerLayout(id);
			int num2;
			if (num < 0)
			{
				num2 = 342662214;
				goto IL_000d;
			}
			return customControllerLayouts[num];
			IL_0008:
			num2 = 342662213;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ 0x146C9C44)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
				return null;
			}
			goto IL_0008;
		}

		public int GetCustomControllerLayoutId(string name)
		{
			if (customControllerLayouts == null)
			{
				return -1;
			}
			int num = IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return customControllerLayouts[num].id;
		}

		public int IndexOfCustomControllerLayout(int id)
		{
			if (customControllerLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (num < customControllerLayouts.Count)
			{
				while (true)
				{
					if (customControllerLayouts[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 62757129;
					while (true)
					{
						switch (num2 ^ 0x3BD990B)
						{
						case 0:
							num2 = 62757130;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (customControllerLayouts == null)
				{
					return -1;
				}
				num = 0;
				num2 = -1259421082;
				goto IL_0015;
			}
			goto IL_0032;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -1259421081)
				{
				case 0:
					break;
				case 3:
					goto IL_0032;
				case 2:
					goto IL_0047;
				default:
					if (num >= customControllerLayouts.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (customControllerLayouts[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = -1259421082;
			}
			goto IL_0010;
			IL_0010:
			num2 = -1259421084;
			goto IL_0015;
			IL_0032:
			return -1;
		}

		public string GetCustomControllerLayoutNameById(int id)
		{
			if (customControllerLayouts != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -1467029400;
					while (true)
					{
						switch (num ^ -1467029396)
						{
						case 2:
							break;
						case 4:
							num2 = 0;
							num = -1467029396;
							continue;
						case 3:
							goto IL_003e;
						case 5:
							goto IL_006f;
						case 0:
							num = -1467029399;
							continue;
						default:
							goto end_IL_000b;
						}
						break;
						IL_006f:
						int num3;
						if (num2 < customControllerLayouts.Count)
						{
							num = -1467029393;
							num3 = num;
						}
						else
						{
							num = -1467029395;
							num3 = num;
						}
						continue;
						IL_003e:
						if (customControllerLayouts[num2].id == id)
						{
							return customControllerLayouts[num2].name;
						}
						num2++;
						num = -1467029399;
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			return "Unknown";
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			while (true)
			{
				switch (0x6F1E506D ^ 0x6F1E506C)
				{
				case 0:
					continue;
				case 1:
					switch (controllerType)
					{
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return GetKeyboardLayoutNameById(id);
					case ControllerType.Mouse:
						return GetMouseLayoutNameById(id);
					case ControllerType.Custom:
						return GetCustomControllerLayoutNameById(id);
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return GetJoystickLayoutNameById(id);
		}

		internal ControllerMap pbhAUzedVzeaQbVkyiUIXosZYPA(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			ControllerType type = P_0.type;
			int num = 1732633200;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x6745E270)
			{
			case 2:
				break;
			case 1:
				return null;
			case 0:
				switch (type)
				{
				case ControllerType.Joystick:
					break;
				case ControllerType.Keyboard:
					return FindKeyboardMap_Game(P_1, P_2);
				case ControllerType.Mouse:
					return FindMouseMap_Game(P_1, P_2);
				case ControllerType.Custom:
					return lejMVaByLdOJVLWYjPmUyMBPIzJ(P_1, ((CustomController)P_0).sourceControllerId, P_2);
				default:
					throw new NotImplementedException();
				}
				goto default;
			default:
				return MOavHkrPYmurnDiDKpIsOSpvUzG((Joystick)P_0, P_1, P_2);
			}
			goto IL_0003;
			IL_0003:
			num = 1732633201;
			goto IL_0008;
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1744646096;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1744646093)
				{
				case 0:
					break;
				case 2:
					return null;
				case 1:
					if (joystickMaps[num].categoryId != categoryId || joystickMaps[num].layoutId != layoutId || !(StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid))
					{
						goto IL_0088;
					}
					return joystickMaps[num];
				default:
					if (num >= joystickMaps.Count)
					{
						return null;
					}
					goto case 1;
				}
				break;
				IL_0088:
				num++;
				num2 = -1744646096;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1744646095;
			goto IL_000d;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			int num2 = default(int);
			while (true)
			{
				int num = 1833030704;
				while (true)
				{
					switch (num ^ 0x6D41D434)
					{
					case 2:
						break;
					case 4:
						if (joystickMaps == null)
						{
							return null;
						}
						num2 = 0;
						num = 1833030708;
						continue;
					case 1:
						if (joystickMaps[num2].id == id)
						{
							num = 1833030705;
							continue;
						}
						num2++;
						num = 1833030711;
						continue;
					case 0:
						num = 1833030711;
						continue;
					case 5:
						joystickMapIndex = num2;
						return joystickMaps[num2];
					default:
						if (num2 >= joystickMaps.Count)
						{
							return null;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			int num = 0;
			int num2 = 634444823;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x25D0DC13)
				{
				case 0:
					break;
				case 1:
					return null;
				case 2:
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						list.Add(joystickMaps[num]);
						num2 = 634444816;
						continue;
					}
					goto case 3;
				case 3:
					num++;
					num2 = 634444823;
					continue;
				default:
					if (num >= joystickMaps.Count)
					{
						return list;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 634444818;
			goto IL_000d;
		}

		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId && StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						return joystickMaps[num].id;
					}
					num++;
					int num2 = -1054484991;
					while (true)
					{
						switch (num2 ^ -1054484991)
						{
						case 2:
							num2 = -1054484992;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002f;
						}
						break;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return -1;
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -593523345;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -593523345)
				{
				case 2:
					break;
				case 1:
					return false;
				case 3:
					if (joystickMaps[num].categoryId != categoryId || joystickMaps[num].layoutId != layoutId || !(StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid))
					{
						goto IL_007d;
					}
					return true;
				default:
					if (num >= joystickMaps.Count)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_007d:
				num++;
				num2 = -593523345;
			}
			goto IL_0008;
			IL_0008:
			num2 = -593523346;
			goto IL_000d;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					int num2;
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						num2 = -1091025675;
					}
					else
					{
						num++;
						num2 = -1091025674;
					}
					while (true)
					{
						switch (num2 ^ -1091025676)
						{
						case 0:
							num2 = -1091025673;
							continue;
						case 3:
							break;
						case 1:
							return true;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return false;
		}

		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1686861479;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x648B76A4)
				{
				case 2:
					break;
				case 0:
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid && joystickMaps[num].categoryId == categoryId)
					{
						return true;
					}
					num++;
					num2 = 1686861477;
					continue;
				case 3:
					num2 = 1686861477;
					continue;
				case 4:
					return false;
				default:
					if (num >= joystickMaps.Count)
					{
						return false;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1686861472;
			goto IL_000d;
		}

		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			goto IL_0040;
			IL_0008:
			int num = -78345080;
			goto IL_000d;
			IL_000d:
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			while (true)
			{
				switch (num ^ -78345078)
				{
				case 0:
					break;
				case 2:
					joystickMaps = new List<ControllerMap_Editor>();
					num = -78345079;
					continue;
				case 3:
					goto IL_0040;
				case 1:
					controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
					num = -78345074;
					continue;
				default:
					joystickMaps.Add(controllerMap_Editor);
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_0040:
			controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewJoystickMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			num = -78345077;
			goto IL_000d;
		}

		public void DeleteJoystickMap(int id)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			goto IL_006c;
			IL_0008:
			int num = 1197615947;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x47622B49)
				{
				case 6:
					break;
				default:
					return;
				case 0:
					if (joystickMaps[num2].id == id)
					{
						joystickMaps.RemoveAt(num2);
						num = 1197615948;
						continue;
					}
					goto case 5;
				case 5:
					num2--;
					num = 1197615949;
					continue;
				case 1:
					goto IL_006c;
				case 2:
					return;
				case 4:
					goto IL_0089;
				case 3:
					num = 1197615949;
					continue;
				case 7:
					return;
				}
				break;
				IL_0089:
				int num3;
				if (num2 >= 0)
				{
					num = 1197615945;
					num3 = num;
				}
				else
				{
					num = 1197615950;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_006c:
			num2 = joystickMaps.Count - 1;
			num = 1197615946;
			goto IL_000d;
		}

		public int DuplicateJoystickMap(int index)
		{
			if (joystickMaps == null || index < 0)
			{
				goto IL_003c;
			}
			if (index >= joystickMaps.Count)
			{
				goto IL_001a;
			}
			goto IL_004e;
			IL_003c:
			throw new ArgumentOutOfRangeException("index");
			IL_004e:
			ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
			controllerMap_Editor.id = GetNewJoystickMapId();
			joystickMaps.Add(controllerMap_Editor);
			int num = -1656614122;
			goto IL_001f;
			IL_001a:
			num = -1656614124;
			goto IL_001f;
			IL_001f:
			switch (num ^ -1656614123)
			{
			case 0:
				break;
			case 1:
				goto IL_003c;
			case 2:
				goto IL_004e;
			default:
				return joystickMaps.Count - 1;
			}
			goto IL_001a;
		}

		internal JoystickMap vbOLdhqieuNfkwxPjTOapirSbTrK(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return MOavHkrPYmurnDiDKpIsOSpvUzG(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap MOavHkrPYmurnDiDKpIsOSpvUzG(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return MOavHkrPYmurnDiDKpIsOSpvUzG(P_0.hardwareJoystickMapIdentifier, P_1, P_2);
		}

		private JoystickMap MOavHkrPYmurnDiDKpIsOSpvUzG(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.rOAaoWrkpxRacuEqvnMgozPcpLi(guid);
			ControllerMap_Editor controllerMap_Editor = COQFMpDLPBCnPEURGIxceHpyQwNP(P_1, guid, P_2, false);
			JoystickMap joystickMap = default(JoystickMap);
			if (controllerMap_Editor != null)
			{
				while (true)
				{
					int num = -2057850007;
					while (true)
					{
						switch (num ^ -2057850008)
						{
						case 0:
							break;
						case 1:
							goto IL_003b;
						default:
							return joystickMap;
						}
						break;
						IL_003b:
						joystickMap = controllerMap_Editor.kCAcOinlULTTujekMkLRQhDUTUQ(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
						joystickMap.SetIdentity(guid, P_1, P_2);
						num = -2057850006;
					}
				}
			}
			if (hardwareJoystickMap != null)
			{
				using (IEnumerator<Guid> enumerator = hardwareJoystickMap.TemplateGuids.GetEnumerator())
				{
					while (true)
					{
						IL_00b0:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = -2057850007;
							num3 = num2;
						}
						else
						{
							num2 = -2057850004;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -2057850008)
							{
							case 0:
								num2 = -2057850007;
								continue;
							default:
								goto end_IL_008c;
							case 2:
								break;
							case 3:
								return joystickMap;
							case 1:
							{
								Guid current = enumerator.Current;
								if (current == Guid.Empty)
								{
									break;
								}
								HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.trWVNTJMAihjoCbseTOaZKfBTFD(current);
								if (!(hardwareJoystickTemplateMap != null))
								{
									break;
								}
								controllerMap_Editor = COQFMpDLPBCnPEURGIxceHpyQwNP(P_1, current, P_2, false);
								if (controllerMap_Editor != null)
								{
									joystickMap = AlCaJufIOVWsgEbSdLwEnsYoYRuD(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
									if (joystickMap != null)
									{
										joystickMap.SetIdentity(guid, P_1, P_2);
										num2 = -2057850005;
										continue;
									}
								}
								break;
							}
							case 4:
								goto end_IL_008c;
							}
							goto IL_00b0;
							continue;
							end_IL_008c:
							break;
						}
						break;
					}
				}
			}
			if (!(guid == Guid.Empty))
			{
				goto IL_0151;
			}
			goto IL_0181;
			IL_0156:
			int num4;
			while (true)
			{
				switch (num4 ^ -2057850008)
				{
				case 2:
					break;
				case 1:
					goto IL_0177;
				case 3:
					goto IL_0197;
				case 4:
					goto IL_01c9;
				default:
					return joystickMap;
				}
				break;
				IL_01c9:
				if (joystickMap != null)
				{
					return joystickMap;
				}
				goto IL_01ce;
				IL_0177:
				if (1 == 0)
				{
					goto IL_0181;
				}
				goto IL_01ce;
				IL_0197:
				if (controllerMap_Editor != null)
				{
					joystickMap = controllerMap_Editor.kCAcOinlULTTujekMkLRQhDUTUQ(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.SetIdentity(guid, P_1, P_2);
					num4 = -2057850004;
					continue;
				}
				goto IL_01ce;
				IL_01ce:
				joystickMap = JoystickMap.Blank(guid, P_1, P_2);
				num4 = -2057850008;
			}
			goto IL_0151;
			IL_0181:
			controllerMap_Editor = COQFMpDLPBCnPEURGIxceHpyQwNP(P_1, Guid.Empty, P_2, false);
			num4 = -2057850005;
			goto IL_0156;
			IL_0151:
			num4 = -2057850007;
			goto IL_0156;
		}

		private ControllerMap_Editor COQFMpDLPBCnPEURGIxceHpyQwNP(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = FCwTnbvdtkIKIyqtaufkCwZdKEN(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor FCwTnbvdtkIKIyqtaufkCwZdKEN(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 1031533418;
				while (true)
				{
					switch (num ^ 0x3D7BF36C)
					{
					case 3:
						break;
					case 0:
						return list[num2];
					case 7:
						NSSAtdeAriMlUvrWgvmsLXJFEBN(list, joystickLayouts);
						num = 1031533412;
						continue;
					case 4:
						if (num2 >= list.Count)
						{
							num3 = 0;
							num = 1031533414;
							continue;
						}
						goto case 9;
					case 2:
						return list[num3];
					case 6:
						if (list != null)
						{
							int num5;
							if (list.Count <= 0)
							{
								num = 1031533421;
								num5 = num;
							}
							else
							{
								num = 1031533419;
								num5 = num;
							}
							continue;
						}
						goto default;
					case 10:
					{
						int num4;
						if (num3 >= list.Count)
						{
							num = 1031533421;
							num4 = num;
						}
						else
						{
							num = 1031533417;
							num4 = num;
						}
						continue;
					}
					case 5:
						if (list[num3].categoryId != 0)
						{
							num3++;
							num = 1031533414;
						}
						else
						{
							num = 1031533422;
						}
						continue;
					case 9:
						if (list[num2].categoryId != P_0)
						{
							num2++;
							num = 1031533416;
						}
						else
						{
							num = 1031533420;
						}
						continue;
					case 8:
						num2 = 0;
						num = 1031533416;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		private JoystickMap AlCaJufIOVWsgEbSdLwEnsYoYRuD(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			string text;
			if (!P_2.TkGdiJCpMZREcRztmiuEgWCvstzA(controllerMap_Editor, P_3, P_0.guid, out text))
			{
				Logger.LogError(string.Concat("Error remapping joystick template ", P_2.Guid, " to joystick ", P_0.guid, "\nReason: ", text));
				return null;
			}
			return controllerMap_Editor.kCAcOinlULTTujekMkLRQhDUTUQ(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap jdbxmsfbPVeXAFdZytoRPcnmivWb(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.rOAaoWrkpxRacuEqvnMgozPcpLi(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.rOAaoWrkpxRacuEqvnMgozPcpLi(Guid.Empty);
			if (hardwareJoystickMap2 == null)
			{
				return null;
			}
			int[] buttons;
			int[] axes;
			hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, false, out buttons, out axes);
			if (buttons == null && axes == null)
			{
				return null;
			}
			bool flag = false;
			List<int> list = new List<int>();
			using (IEnumerator<ActionElementMap> enumerator = P_0.AllMaps.GetEnumerator())
			{
				string name = default(string);
				int num3 = default(int);
				int num2 = default(int);
				string text = default(string);
				int result = default(int);
				while (enumerator.MoveNext())
				{
					while (true)
					{
						IL_0158:
						ActionElementMap current = enumerator.Current;
						ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(current._elementIdentifierId);
						int num;
						if (elementIdentifier != null)
						{
							name = elementIdentifier.name;
							num = -631662586;
							goto IL_0067;
						}
						goto IL_010f;
						IL_0067:
						while (true)
						{
							switch (num ^ -631662591)
							{
							case 12:
								num = -631662582;
								continue;
							case 4:
								if (num3 < 0)
								{
									break;
								}
								if (num2 == 0)
								{
									goto IL_00b8;
								}
								goto case 3;
							case 1:
								flag = true;
								num = -631662583;
								continue;
							case 3:
								if (num2 == 1)
								{
									goto IL_00db;
								}
								goto case 6;
							case 6:
								text = Regex.Replace(name, "[^0-9]+", "");
								num = -631662589;
								continue;
							case 5:
								break;
							case 0:
								current._elementIdentifierId = axes[result];
								num = -631662592;
								continue;
							case 10:
								if (result < buttons.Length)
								{
									current._elementIdentifierId = buttons[result];
									num = -631662592;
									continue;
								}
								break;
							case 11:
								goto IL_0158;
							case 13:
								goto IL_0187;
							case 7:
								if (string.IsNullOrEmpty(name))
								{
									break;
								}
								num2 = 0;
								num3 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
								if (num3 < 0)
								{
									num3 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
									num2 = 1;
									num = -631662587;
									continue;
								}
								goto case 4;
							case 2:
								goto IL_01e3;
							case 9:
								goto IL_0209;
							default:
								goto end_IL_0158;
							}
							break;
							IL_0209:
							int num4;
							if (result < axes.Length)
							{
								num = -631662591;
								num4 = num;
							}
							else
							{
								num = -631662588;
								num4 = num;
							}
							continue;
							IL_00b8:
							int num5;
							if (buttons == null)
							{
								num = -631662588;
								num5 = num;
							}
							else
							{
								num = -631662590;
								num5 = num;
							}
							continue;
							IL_00db:
							int num6;
							if (axes == null)
							{
								num = -631662588;
								num6 = num;
							}
							else
							{
								num = -631662585;
								num6 = num;
							}
							continue;
							IL_01e3:
							Logger.Log(text);
							int num7;
							if (!int.TryParse(text, out result))
							{
								num = -631662588;
								num7 = num;
							}
							else
							{
								num = -631662580;
								num7 = num;
							}
							continue;
							IL_0187:
							int num8;
							if (num2 == 0)
							{
								num = -631662581;
								num8 = num;
							}
							else
							{
								num = -631662584;
								num8 = num;
							}
						}
						goto IL_010f;
						IL_010f:
						list.Add(current.KAixZgRycuVSHIYaEVNGzKGIdgV);
						num = -631662583;
						goto IL_0067;
						continue;
						end_IL_0158:
						break;
					}
				}
			}
			int num9 = 0;
			while (num9 < list.Count)
			{
				while (true)
				{
					P_0.DeleteElementMap(list[num9]);
					int num10 = -631662591;
					while (true)
					{
						switch (num10 ^ -631662591)
						{
						case 2:
							num10 = -631662592;
							continue;
						case 1:
							break;
						case 0:
							num9++;
							num10 = -631662590;
							continue;
						default:
							goto end_IL_0265;
						}
						break;
					}
					continue;
					end_IL_0265:
					break;
				}
			}
			if (!flag)
			{
				return null;
			}
			return P_0;
		}

		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1348518408;
				while (true)
				{
					switch (num2 ^ -1348518406)
					{
					case 3:
						break;
					case 2:
						num2 = -1348518405;
						continue;
					case 4:
						if (keyboardMaps[num].categoryId == categoryId && keyboardMaps[num].layoutId == layoutId)
						{
							num2 = -1348518406;
							continue;
						}
						num++;
						num2 = -1348518405;
						continue;
					case 0:
						return keyboardMaps[num];
					default:
						if (num >= keyboardMaps.Count)
						{
							return null;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -250491471;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -250491471)
				{
				case 5:
					break;
				case 6:
					return -1;
				case 0:
				{
					int num3;
					if (num < keyboardMaps.Count)
					{
						num2 = -250491467;
						num3 = num2;
					}
					else
					{
						num2 = -250491472;
						num3 = num2;
					}
					continue;
				}
				case 3:
					return keyboardMaps[num].id;
				case 4:
					if (keyboardMaps[num].categoryId == categoryId)
					{
						num2 = -250491469;
						continue;
					}
					goto IL_0075;
				case 2:
					if (keyboardMaps[num].layoutId == layoutId)
					{
						num2 = -250491470;
						continue;
					}
					goto IL_0075;
				default:
					{
						return -1;
					}
					IL_0075:
					num++;
					num2 = -250491471;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -250491465;
			goto IL_000d;
		}

		public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (keyboardMaps == null)
			{
				goto IL_000b;
			}
			int num = 0;
			int num2 = -292979122;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ -292979121)
				{
				case 0:
					break;
				case 1:
				{
					int num3;
					if (num < keyboardMaps.Count)
					{
						num2 = -292979126;
						num3 = num2;
					}
					else
					{
						num2 = -292979123;
						num3 = num2;
					}
					continue;
				}
				case 3:
					return true;
				case 4:
					if (keyboardMaps[num].layoutId == layoutId && StringTools.ToGuid(keyboardMaps[num].hardwareGuidString) == hardwareGuid)
					{
						num2 = -292979124;
						continue;
					}
					goto IL_005d;
				case 5:
					if (keyboardMaps[num].categoryId == categoryId)
					{
						num2 = -292979125;
						continue;
					}
					goto IL_005d;
				case 6:
					return false;
				default:
					{
						return false;
					}
					IL_005d:
					num++;
					num2 = -292979122;
					continue;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num2 = -292979127;
			goto IL_0010;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				keyboardMaps = new List<ControllerMap_Editor>();
				goto IL_0013;
			}
			goto IL_006d;
			IL_006d:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			int num = 501980623;
			goto IL_0018;
			IL_0013:
			num = 501980621;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ 0x1DEB9DCE)
				{
				case 0:
					break;
				case 2:
					keyboardMaps.Add(controllerMap_Editor);
					num = 501980618;
					continue;
				case 1:
					controllerMap_Editor.id = GetNewKeyboardMapId();
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					num = 501980620;
					continue;
				case 3:
					goto IL_006d;
				default:
					return false;
				}
				break;
			}
			goto IL_0013;
		}

		public void DeleteKeyboardMap(int id)
		{
			if (keyboardMaps == null)
			{
				return;
			}
			while (true)
			{
				int num = keyboardMaps.Count - 1;
				int num2 = 1364375704;
				while (true)
				{
					switch (num2 ^ 0x5152B89C)
					{
					case 2:
						num2 = 1364375709;
						continue;
					default:
						return;
					case 0:
						num--;
						num2 = 1364375704;
						continue;
					case 5:
						if (keyboardMaps[num].id == id)
						{
							keyboardMaps.RemoveAt(num);
							num2 = 1364375708;
							continue;
						}
						goto case 0;
					case 1:
						break;
					case 4:
					{
						int num3;
						if (num >= 0)
						{
							num2 = 1364375705;
							num3 = num2;
						}
						else
						{
							num2 = 1364375711;
							num3 = num2;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		public int DuplicateKeyboardMap(int index)
		{
			if (keyboardMaps != null && index >= 0)
			{
				if (index < keyboardMaps.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (-556285232 ^ -556285230)
					{
					case 0:
						break;
					case 2:
						goto end_IL_001a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_004a:
			ControllerMap_Editor controllerMap_Editor = keyboardMaps[index].Clone();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			keyboardMaps.Add(controllerMap_Editor);
			return keyboardMaps.Count - 1;
		}

		public ControllerMap_Editor GetKeyboardMapById(int id, out int keyboardMapIndex)
		{
			keyboardMapIndex = -1;
			if (keyboardMaps == null)
			{
				return null;
			}
			int num = 0;
			while (num < keyboardMaps.Count)
			{
				while (true)
				{
					if (keyboardMaps[num].id == id)
					{
						keyboardMapIndex = num;
						return keyboardMaps[num];
					}
					num++;
					int num2 = 1597264628;
					while (true)
					{
						switch (num2 ^ 0x5F3452F6)
						{
						case 0:
							num2 = 1597264631;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002f;
						}
						break;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return null;
		}

		public KeyboardMap FindKeyboardMap_Game(int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = bLnZuTeBbCgKgIbQYJPYTcmoxcE(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			if (controllerMap_Editor != null)
			{
				goto IL_0019;
			}
			goto IL_0057;
			IL_0019:
			int num = -567552245;
			goto IL_001e;
			IL_001e:
			KeyboardMap keyboardMap = default(KeyboardMap);
			while (true)
			{
				switch (num ^ -567552246)
				{
				case 2:
					break;
				case 1:
					keyboardMap = controllerMap_Editor.ndoqsxdYVLcHLqznrKTfuEDIfGL(containsActionDelegate);
					keyboardMap.SetIdentity(categoryId, layoutId);
					num = -567552246;
					continue;
				case 3:
					goto IL_0057;
				default:
					return keyboardMap;
				}
				break;
			}
			goto IL_0019;
			IL_0057:
			keyboardMap = KeyboardMap.Blank(categoryId, layoutId);
			num = -567552246;
			goto IL_001e;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < keyboardMaps.Count)
			{
				while (true)
				{
					if (keyboardMaps[num].categoryId == categoryId)
					{
						return true;
					}
					num++;
					int num2 = 223511712;
					while (true)
					{
						switch (num2 ^ 0xD5284A2)
						{
						case 0:
							num2 = 223511715;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return false;
		}

		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1676673130;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1676673132)
				{
				case 0:
					break;
				case 3:
					return false;
				case 1:
					if (keyboardMaps[num].categoryId != categoryId || keyboardMaps[num].layoutId != layoutId)
					{
						goto IL_005f;
					}
					return true;
				default:
					if (num >= keyboardMaps.Count)
					{
						return false;
					}
					goto case 1;
				}
				break;
				IL_005f:
				num++;
				num2 = -1676673130;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1676673129;
			goto IL_000d;
		}

		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < mouseMaps.Count)
				{
					num2 = -1002078163;
					num3 = num2;
				}
				else
				{
					num2 = -1002078168;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1002078167)
					{
					case 2:
						num2 = -1002078163;
						continue;
					case 0:
						break;
					case 3:
						return mouseMaps[num];
					case 4:
						if (mouseMaps[num].categoryId != categoryId || mouseMaps[num].layoutId != layoutId)
						{
							num++;
							num2 = -1002078167;
						}
						else
						{
							num2 = -1002078166;
						}
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public int GetMouseMapId(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					int num2;
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						num2 = -1564249828;
					}
					else
					{
						num++;
						num2 = -1564249826;
					}
					while (true)
					{
						switch (num2 ^ -1564249826)
						{
						case 3:
							num2 = -1564249825;
							continue;
						case 1:
							break;
						case 2:
							return mouseMaps[num].id;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (mouseMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1736847191;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x67862F57)
				{
				case 2:
					break;
				case 1:
					return false;
				case 3:
					if (mouseMaps[num].categoryId != categoryId || mouseMaps[num].layoutId != layoutId || !(StringTools.ToGuid(mouseMaps[num].hardwareGuidString) == hardwareGuid))
					{
						goto IL_007d;
					}
					return true;
				default:
					if (num >= mouseMaps.Count)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_007d:
				num++;
				num2 = 1736847191;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1736847190;
			goto IL_000d;
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				mouseMaps = new List<ControllerMap_Editor>();
				goto IL_0013;
			}
			goto IL_0065;
			IL_0065:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			int num = -1122529551;
			goto IL_0018;
			IL_0013:
			num = -1122529546;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -1122529550)
				{
				case 0:
					break;
				case 1:
					controllerMap_Editor.categoryId = categoryId;
					num = -1122529552;
					continue;
				case 2:
					controllerMap_Editor.layoutId = layoutId;
					mouseMaps.Add(controllerMap_Editor);
					num = -1122529545;
					continue;
				case 4:
					goto IL_0065;
				case 3:
					controllerMap_Editor.id = GetNewMouseMapId();
					num = -1122529549;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0013;
		}

		public void DeleteMouseMap(int id)
		{
			if (mouseMaps == null)
			{
				goto IL_0008;
			}
			goto IL_0084;
			IL_0008:
			int num = -19329237;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -19329238)
				{
				case 7:
					break;
				default:
					return;
				case 0:
					mouseMaps.RemoveAt(num2);
					num = -19329239;
					continue;
				case 3:
					num2--;
					num = -19329234;
					continue;
				case 6:
					goto IL_005f;
				case 2:
					goto IL_0084;
				case 1:
					return;
				case 5:
					num = -19329234;
					continue;
				case 4:
					goto IL_00b1;
				case 8:
					return;
				}
				break;
				IL_00b1:
				int num3;
				if (num2 < 0)
				{
					num = -19329246;
					num3 = num;
				}
				else
				{
					num = -19329236;
					num3 = num;
				}
				continue;
				IL_005f:
				int num4;
				if (mouseMaps[num2].id == id)
				{
					num = -19329238;
					num4 = num;
				}
				else
				{
					num = -19329239;
					num4 = num;
				}
			}
			goto IL_0008;
			IL_0084:
			num2 = mouseMaps.Count - 1;
			num = -19329233;
			goto IL_000d;
		}

		public int DuplicateMouseMap(int index)
		{
			if (mouseMaps != null)
			{
				while (true)
				{
					int num = -2116405405;
					while (true)
					{
						switch (num ^ -2116405406)
						{
						case 3:
							break;
						case 1:
							goto IL_002a;
						case 0:
							goto end_IL_0008;
						default:
						{
							ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
							controllerMap_Editor.id = GetNewMouseMapId();
							mouseMaps.Add(controllerMap_Editor);
							return mouseMaps.Count - 1;
						}
						}
						break;
						IL_002a:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index < mouseMaps.Count)
						{
							num = -2116405408;
							num2 = num;
						}
						else
						{
							num = -2116405406;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (mouseMaps == null)
			{
				goto IL_000e;
			}
			int num = 0;
			int num2 = -1577813962;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num2 ^ -1577813965)
				{
				case 0:
					break;
				case 6:
					mouseMapIndex = num;
					num2 = -1577813966;
					continue;
				case 1:
					return mouseMaps[num];
				case 7:
					if (mouseMaps[num].id != id)
					{
						num++;
						num2 = -1577813968;
					}
					else
					{
						num2 = -1577813963;
					}
					continue;
				case 3:
				{
					int num3;
					if (num < mouseMaps.Count)
					{
						num2 = -1577813964;
						num3 = num2;
					}
					else
					{
						num2 = -1577813967;
						num3 = num2;
					}
					continue;
				}
				case 5:
					num2 = -1577813968;
					continue;
				case 4:
					return null;
				default:
					return null;
				}
				break;
			}
			goto IL_000e;
			IL_000e:
			num2 = -1577813961;
			goto IL_0013;
		}

		public MouseMap FindMouseMap_Game(int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = bLnZuTeBbCgKgIbQYJPYTcmoxcE(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			if (controllerMap_Editor != null)
			{
				goto IL_0019;
			}
			goto IL_0057;
			IL_0019:
			int num = 489919208;
			goto IL_001e;
			IL_001e:
			MouseMap mouseMap = default(MouseMap);
			while (true)
			{
				switch (num ^ 0x1D3392E9)
				{
				case 3:
					break;
				case 1:
					mouseMap = controllerMap_Editor.krsRIxqaVDrrAMPqbGWejyVTGsP(containsActionDelegate);
					mouseMap.SetIdentity(categoryId, layoutId);
					num = 489919211;
					continue;
				case 0:
					goto IL_0057;
				default:
					return mouseMap;
				}
				break;
			}
			goto IL_0019;
			IL_0057:
			mouseMap = MouseMap.Blank(categoryId, layoutId);
			num = 489919211;
			goto IL_001e;
		}

		public bool HasMouseMapInCategory(int categoryId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					if (mouseMaps[num].categoryId == categoryId)
					{
						return true;
					}
					num++;
					int num2 = 130780492;
					while (true)
					{
						switch (num2 ^ 0x7CB8D4C)
						{
						case 2:
							num2 = 130780493;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return false;
		}

		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 389358593;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x17352403)
				{
				case 4:
					break;
				case 1:
					return false;
				case 2:
				{
					int num3;
					if (num < mouseMaps.Count)
					{
						num2 = 389358595;
						num3 = num2;
					}
					else
					{
						num2 = 389358592;
						num3 = num2;
					}
					continue;
				}
				case 0:
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						return true;
					}
					num++;
					num2 = 389358593;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 389358594;
			goto IL_000d;
		}

		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -147681787;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -147681787)
				{
				case 3:
					break;
				case 6:
					return null;
				case 1:
					if (customControllerMaps[num].layoutId == layoutId && customControllerMaps[num].customControllerUid == controllerUid)
					{
						num2 = -147681792;
						continue;
					}
					goto IL_00a2;
				case 2:
					if (customControllerMaps[num].categoryId == categoryId)
					{
						num2 = -147681788;
						continue;
					}
					goto IL_00a2;
				case 0:
					num2 = -147681791;
					continue;
				case 5:
					return customControllerMaps[num];
				default:
					{
						if (num >= customControllerMaps.Count)
						{
							return null;
						}
						goto case 2;
					}
					IL_00a2:
					num++;
					num2 = -147681791;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -147681789;
			goto IL_000d;
		}

		public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
		{
			customControllerMapIndex = -1;
			if (customControllerMaps == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = 194222555;
				while (true)
				{
					switch (num2 ^ 0xB9399DA)
					{
					case 4:
						break;
					case 3:
					{
						int num3;
						if (num >= customControllerMaps.Count)
						{
							num2 = 194222554;
							num3 = num2;
						}
						else
						{
							num2 = 194222552;
							num3 = num2;
						}
						continue;
					}
					case 2:
						if (customControllerMaps[num].id == mapId)
						{
							num2 = 194222559;
							continue;
						}
						num++;
						num2 = 194222553;
						continue;
					case 1:
						num2 = 194222553;
						continue;
					case 5:
						customControllerMapIndex = num;
						return customControllerMaps[num];
					default:
						return null;
					}
					break;
				}
			}
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (customControllerMaps == null)
			{
				goto IL_0008;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			int num = 0;
			int num2 = -733479562;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -733479564)
				{
				case 0:
					break;
				case 4:
					return null;
				case 1:
					num++;
					num2 = -733479562;
					continue;
				case 3:
					if (customControllerMaps[num].customControllerUid == controllerUid)
					{
						list.Add(customControllerMaps[num]);
						num2 = -733479563;
						continue;
					}
					goto case 1;
				default:
					if (num >= customControllerMaps.Count)
					{
						return list;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -733479568;
			goto IL_000d;
		}

		public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < customControllerMaps.Count)
				{
					num2 = 874025614;
					num3 = num2;
				}
				else
				{
					num2 = 874025609;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x3418928A)
					{
					case 2:
						num2 = 874025614;
						continue;
					case 1:
						break;
					case 5:
						return customControllerMaps[num].id;
					case 0:
						if (customControllerMaps[num].layoutId == layoutId && customControllerMaps[num].customControllerUid == controllerUid)
						{
							num2 = 874025615;
							continue;
						}
						goto IL_006c;
					case 4:
						if (customControllerMaps[num].categoryId == categoryId)
						{
							num2 = 874025610;
							continue;
						}
						goto IL_006c;
					default:
						{
							return -1;
						}
						IL_006c:
						num++;
						num2 = 874025611;
						continue;
					}
					break;
				}
			}
		}

		public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
		{
			if (customControllerMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 872596746;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x3402C509)
				{
				case 5:
					break;
				case 1:
					if (customControllerMaps[num].id == mapId)
					{
						return true;
					}
					goto IL_0048;
				case 3:
				{
					int num3;
					if (num >= customControllerMaps.Count)
					{
						num2 = 872596747;
						num3 = num2;
					}
					else
					{
						num2 = 872596745;
						num3 = num2;
					}
					continue;
				}
				case 4:
					return false;
				case 0:
					if (customControllerMaps[num].categoryId == categoryId && customControllerMaps[num].layoutId == layoutId)
					{
						num2 = 872596744;
						continue;
					}
					goto IL_0048;
				default:
					{
						return false;
					}
					IL_0048:
					num++;
					num2 = 872596746;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 872596749;
			goto IL_000d;
		}

		public bool HasCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					if (customControllerMaps[num].id == mapId)
					{
						return true;
					}
					num++;
					int num2 = -2121984500;
					while (true)
					{
						switch (num2 ^ -2121984498)
						{
						case 0:
							num2 = -2121984497;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return false;
		}

		public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					int num2;
					if (customControllerMaps[num].customControllerUid == controllerUid && customControllerMaps[num].categoryId == categoryId)
					{
						num2 = -303789230;
					}
					else
					{
						num++;
						num2 = -303789229;
					}
					while (true)
					{
						switch (num2 ^ -303789229)
						{
						case 3:
							num2 = -303789231;
							continue;
						case 2:
							break;
						case 1:
							return true;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return false;
		}

		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				goto IL_0008;
			}
			goto IL_0077;
			IL_0008:
			int num = -532795604;
			goto IL_000d;
			IL_000d:
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			while (true)
			{
				switch (num ^ -532795607)
				{
				case 3:
					break;
				case 5:
					customControllerMaps = new List<ControllerMap_Editor>();
					num = -532795608;
					continue;
				case 4:
					controllerMap_Editor.id = GetNewCustomControllerMapId();
					num = -532795607;
					continue;
				case 0:
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					controllerMap_Editor.hardwareGuidString = string.Empty;
					num = -532795605;
					continue;
				case 1:
					goto IL_0077;
				default:
					controllerMap_Editor.customControllerUid = controllerUid;
					customControllerMaps.Add(controllerMap_Editor);
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_0077:
			controllerMap_Editor = new ControllerMap_Editor();
			num = -532795603;
			goto IL_000d;
		}

		public void DeleteCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				goto IL_000b;
			}
			goto IL_008f;
			IL_000b:
			int num = -533502933;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -533502932)
				{
				case 5:
					break;
				case 7:
					return;
				case 0:
					customControllerMaps.RemoveAt(num2);
					num = -533502931;
					continue;
				case 2:
					num = -533502936;
					continue;
				case 1:
					num2--;
					num = -533502936;
					continue;
				case 3:
				{
					int num3;
					if (customControllerMaps[num2].id == mapId)
					{
						num = -533502932;
						num3 = num;
					}
					else
					{
						num = -533502931;
						num3 = num;
					}
					continue;
				}
				case 6:
					goto IL_008f;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000b;
			IL_008f:
			num2 = customControllerMaps.Count - 1;
			num = -533502930;
			goto IL_0010;
		}

		public int DuplicateCustomControllerMap(int index)
		{
			if (customControllerMaps != null && index >= 0)
			{
				if (index < customControllerMaps.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (-1637567199 ^ -1637567200)
					{
					case 2:
						break;
					case 1:
						goto end_IL_001a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_004a:
			ControllerMap_Editor controllerMap_Editor = customControllerMaps[index].Clone();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			customControllerMaps.Add(controllerMap_Editor);
			return customControllerMaps.Count - 1;
		}

		internal CustomControllerMap lejMVaByLdOJVLWYjPmUyMBPIzJ(Guid P_0, int P_1, int P_2)
		{
			return lejMVaByLdOJVLWYjPmUyMBPIzJ(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap lejMVaByLdOJVLWYjPmUyMBPIzJ(int P_0, int P_1, int P_2)
		{
			return lejMVaByLdOJVLWYjPmUyMBPIzJ(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap lejMVaByLdOJVLWYjPmUyMBPIzJ(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = DIeZldhcpjZEYWfhOuMpUiuzdRY(P_1, id, P_2, false);
			int num;
			CustomControllerMap customControllerMap = default(CustomControllerMap);
			if (controllerMap_Editor != null)
			{
				num = 1183951371;
			}
			else
			{
				customControllerMap = CustomControllerMap.Blank(id, P_1, P_2);
				num = 1183951369;
			}
			goto IL_0008;
			IL_0003:
			num = 1183951368;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x4691AA09)
				{
				case 3:
					break;
				case 1:
					return null;
				case 0:
					goto IL_0047;
				case 2:
					customControllerMap = controllerMap_Editor.YKtMNhFjlLIOLjZPscrQaUFCTuE(ContainsAction, P_0);
					customControllerMap.SetIdentity(id, P_1, P_2);
					return customControllerMap;
				default:
					return customControllerMap;
				}
				break;
				IL_0047:
				customControllerMap.SetIdentity(id, P_1, P_2);
				num = 1183951373;
			}
			goto IL_0003;
		}

		private ControllerMap_Editor DIeZldhcpjZEYWfhOuMpUiuzdRY(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = nIDglDAbHOVGgOHCEyYfWnZKuWJ(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor nIDglDAbHOVGgOHCEyYfWnZKuWJ(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				NSSAtdeAriMlUvrWgvmsLXJFEBN(list, customControllerLayouts);
				int num = 0;
				int num2 = default(int);
				while (true)
				{
					IL_00b8:
					int num3;
					if (num >= list.Count)
					{
						num2 = 0;
						num3 = -1500173217;
						goto IL_0033;
					}
					goto IL_0058;
					IL_0033:
					while (true)
					{
						switch (num3 ^ -1500173222)
						{
						case 4:
							num3 = -1500173223;
							continue;
						case 3:
							break;
						case 1:
							goto IL_007a;
						case 5:
							goto IL_009b;
						case 0:
							goto IL_00b8;
						default:
							goto end_IL_00b8;
						}
						break;
						IL_009b:
						int num4;
						if (num2 < list.Count)
						{
							num3 = -1500173221;
							num4 = num3;
						}
						else
						{
							num3 = -1500173224;
							num4 = num3;
						}
						continue;
						IL_007a:
						if (list[num2].categoryId == 0)
						{
							return list[num2];
						}
						num2++;
						num3 = -1500173217;
					}
					goto IL_0058;
					IL_0058:
					if (list[num].categoryId == P_0)
					{
						return list[num];
					}
					num++;
					num3 = -1500173222;
					goto IL_0033;
					continue;
					end_IL_00b8:
					break;
				}
			}
			return null;
		}

		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				while (true)
				{
					DeleteJoystickMap(id);
					int num = 732784792;
					while (true)
					{
						switch (num ^ 0x2BAD6899)
						{
						case 3:
							num = 732784795;
							continue;
						case 2:
							break;
						case 1:
							return;
						case 6:
							goto end_IL_0049;
						case 4:
							goto IL_006e;
						case 5:
							goto IL_007d;
						default:
							goto end_IL_0003;
						}
						break;
					}
					continue;
					end_IL_0049:
					break;
				}
				goto case ControllerType.Mouse;
			case ControllerType.Mouse:
				DeleteMouseMap(id);
				return;
			case ControllerType.Keyboard:
				goto IL_006e;
			case ControllerType.Custom:
				goto IL_007d;
				IL_007d:
				DeleteCustomControllerMap(id);
				return;
				IL_006e:
				DeleteKeyboardMap(id);
				return;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}

		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				if (joystickMaps == null)
				{
					return null;
				}
				return joystickMaps[index];
			case ControllerType.Keyboard:
				if (keyboardMaps == null)
				{
					return null;
				}
				return keyboardMaps[index];
			case ControllerType.Mouse:
				if (mouseMaps == null)
				{
					return null;
				}
				return mouseMaps[index];
			case ControllerType.Custom:
				if (customControllerMaps == null)
				{
					int num = 1963720278;
					while (true)
					{
						switch (num ^ 0x750BFE57)
						{
						case 0:
							goto IL_001e;
						case 2:
							break;
						default:
							return null;
						}
						break;
						IL_001e:
						num = 1963720277;
					}
					goto case ControllerType.Joystick;
				}
				return customControllerMaps[index];
			default:
				throw new NotImplementedException();
			}
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			while (true)
			{
				switch (0x5F92D31 ^ 0x5F92D30)
				{
				case 0:
					continue;
				case 1:
					switch (controllerType)
					{
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return GetKeyboardMapById(id, out controllerMapIndex);
					case ControllerType.Mouse:
						return GetMouseMapById(id, out controllerMapIndex);
					case ControllerType.Custom:
						return GetCustomControllerMapById(id, out controllerMapIndex);
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return GetJoystickMapById(id, out controllerMapIndex);
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				return DuplicateJoystickMap(index);
			case ControllerType.Keyboard:
				return DuplicateKeyboardMap(index);
			case ControllerType.Mouse:
				return DuplicateMouseMap(index);
			case ControllerType.Custom:
				return DuplicateCustomControllerMap(index);
			default:
				throw new NotImplementedException();
			}
		}

		internal ControllerTemplateMap LhDbrTpfSYSBdULgTcMMBVEnYVi(Guid P_0, int P_1, int P_2)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_1, P_0, P_2);
			if (joystickMap == null)
			{
				return null;
			}
			return joystickMap.tJImcqErHZwRyNYLzBIacCZByma();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				while (true)
				{
					int num = -1123404871;
					while (true)
					{
						switch (num ^ -1123404869)
						{
						case 0:
							break;
						case 2:
							customControllers = new List<CustomController_Editor>();
							num = -1123404870;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			customControllers.Add(MXDrOIoojAejhHSxnlbUTsghcNXe());
		}

		public void InsertCustomController(int index)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
				goto IL_0013;
			}
			goto IL_003d;
			IL_003d:
			int num;
			int num2;
			if (index < 0)
			{
				num = 1640750648;
				num2 = num;
			}
			else
			{
				num = 1640750654;
				num2 = num;
			}
			goto IL_0018;
			IL_0013:
			num = 1640750649;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ 0x61CBDE3B)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_003d;
				case 5:
					goto IL_0052;
				case 3:
					throw new ArgumentOutOfRangeException("index");
				case 4:
					customControllers.Insert(index, MXDrOIoojAejhHSxnlbUTsghcNXe());
					num = 1640750650;
					continue;
				case 1:
					return;
				}
				break;
				IL_0052:
				int num3;
				if (index < customControllers.Count)
				{
					num = 1640750655;
					num3 = num;
				}
				else
				{
					num = 1640750648;
					num3 = num;
				}
			}
			goto IL_0013;
		}

		public void DeleteCustomController(int index)
		{
			if (customControllers != null && index >= 0)
			{
				if (index >= customControllers.Count)
				{
					goto IL_0020;
				}
				goto IL_0076;
			}
			goto IL_00f0;
			IL_0076:
			int id = customControllers[index].id;
			int num = 1987330913;
			goto IL_0025;
			IL_00f0:
			throw new ArgumentOutOfRangeException("index");
			IL_0020:
			num = 1987330924;
			goto IL_0025;
			IL_0025:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x76744366)
				{
				case 0:
					break;
				case 9:
					num2 = customControllerMaps.Count - 1;
					num = 1987330926;
					continue;
				case 3:
					goto IL_0076;
				case 8:
					num = 1987330912;
					continue;
				case 7:
					goto IL_0096;
				case 2:
					customControllerMaps.RemoveAt(num2);
					num = 1987330915;
					continue;
				case 1:
					goto IL_00c8;
				case 10:
					goto IL_00f0;
				case 5:
					num2--;
					num = 1987330912;
					continue;
				case 6:
					goto IL_0113;
				default:
					customControllers.RemoveAt(index);
					return;
				}
				break;
				IL_0113:
				int num3;
				if (num2 >= 0)
				{
					num = 1987330919;
					num3 = num;
				}
				else
				{
					num = 1987330914;
					num3 = num;
				}
				continue;
				IL_00c8:
				int num4;
				if (customControllerMaps[num2].customControllerUid == id)
				{
					num = 1987330916;
					num4 = num;
				}
				else
				{
					num = 1987330915;
					num4 = num;
				}
				continue;
				IL_0096:
				int num5;
				if (customControllerMaps == null)
				{
					num = 1987330914;
					num5 = num;
				}
				else
				{
					num = 1987330927;
					num5 = num;
				}
			}
			goto IL_0020;
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			if (customControllers != null && index >= 0)
			{
				int id = default(int);
				CustomController_Editor customController_Editor = default(CustomController_Editor);
				int num3 = default(int);
				int id2 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 1506930740;
					while (true)
					{
						switch (num ^ 0x59D1F03B)
						{
						case 16:
							break;
						default:
							return;
						case 9:
							if (duplicateMaps)
							{
								id = customController_Editor.id;
								num = 1506930736;
								continue;
							}
							return;
						case 8:
							if (customControllerMaps[num3].customControllerUid == id2)
							{
								goto IL_0096;
							}
							goto case 7;
						case 5:
							customController_Editor = customControllers[index].Clone();
							customController_Editor.id = GetNewCustomControllerId();
							customController_Editor.typeGuid = Guid.NewGuid();
							num = 1506930747;
							continue;
						case 10:
							num3 = customControllerMaps.Count - 1;
							num = 1506930744;
							continue;
						case 12:
							customControllers.Insert(index + 1, customController_Editor);
							num = 1506930738;
							continue;
						case 11:
							id2 = customControllers[index].id;
							num = 1506930751;
							continue;
						case 7:
							num3--;
							num = 1506930744;
							continue;
						case 14:
							num = 1506930738;
							continue;
						case 1:
							customControllers.Add(customController_Editor);
							num = 1506930741;
							continue;
						case 6:
							customControllerMaps[num2].customControllerUid = id;
							num = 1506930748;
							continue;
						case 4:
							goto IL_0183;
						case 0:
							goto IL_019f;
						case 13:
							goto end_IL_0012;
						case 15:
							goto IL_01f0;
						case 3:
							goto IL_0212;
						case 2:
							return;
						}
						break;
						IL_0212:
						int num4;
						if (num3 >= 0)
						{
							num = 1506930739;
							num4 = num;
						}
						else
						{
							num = 1506930745;
							num4 = num;
						}
						continue;
						IL_019f:
						customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
						int num5;
						if (index == customControllers.Count - 1)
						{
							num = 1506930746;
							num5 = num;
						}
						else
						{
							num = 1506930743;
							num5 = num;
						}
						continue;
						IL_0096:
						num2 = DuplicateCustomControllerMap(num3);
						int num6;
						if (num2 < 0)
						{
							num = 1506930748;
							num6 = num;
						}
						else
						{
							num = 1506930749;
							num6 = num;
						}
						continue;
						IL_01f0:
						int num7;
						if (index < customControllers.Count)
						{
							num = 1506930750;
							num7 = num;
						}
						else
						{
							num = 1506930742;
							num7 = num;
						}
						continue;
						IL_0183:
						int num8;
						if (customControllerMaps != null)
						{
							num = 1506930737;
							num8 = num;
						}
						else
						{
							num = 1506930745;
							num8 = num;
						}
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetCustomControllerMapCount(int controllerUid)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -1678201953;
				while (true)
				{
					switch (num2 ^ -1678201956)
					{
					case 0:
						break;
					case 3:
					{
						int num4;
						if (customControllerMaps == null)
						{
							num2 = -1678201960;
							num4 = num2;
						}
						else
						{
							num2 = -1678201958;
							num4 = num2;
						}
						continue;
					}
					case 2:
					{
						int num5;
						if (num3 >= customControllerMaps.Count)
						{
							num2 = -1678201960;
							num5 = num2;
						}
						else
						{
							num2 = -1678201955;
							num5 = num2;
						}
						continue;
					}
					case 6:
						num3 = 0;
						num2 = -1678201954;
						continue;
					case 1:
						if (customControllerMaps[num3].customControllerUid == controllerUid)
						{
							num++;
							num2 = -1678201959;
							continue;
						}
						goto case 5;
					case 5:
						num3++;
						num2 = -1678201954;
						continue;
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetCustomControllerIndex(int id)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			while (num < customControllers.Count)
			{
				while (true)
				{
					int num2;
					if (customControllers[num].id == id)
					{
						num2 = -836429038;
					}
					else
					{
						num++;
						num2 = -836429039;
					}
					while (true)
					{
						switch (num2 ^ -836429040)
						{
						case 0:
							num2 = -836429037;
							continue;
						case 3:
							break;
						case 2:
							return num;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerNames()
		{
			if (customControllers == null)
			{
				return null;
			}
			string[] array = new string[customControllers.Count];
			int num = 0;
			while (true)
			{
				int num2 = -1051542519;
				while (true)
				{
					switch (num2 ^ -1051542520)
					{
					case 0:
						break;
					case 1:
						num2 = -1051542516;
						continue;
					case 4:
					{
						int num3;
						if (num < customControllers.Count)
						{
							num2 = -1051542518;
							num3 = num2;
						}
						else
						{
							num2 = -1051542517;
							num3 = num2;
						}
						continue;
					}
					case 2:
						array[num] = customControllers[num].name;
						num2 = -1051542515;
						continue;
					case 5:
						num++;
						num2 = -1051542516;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetCustomControllerIds()
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			int[] array = new int[customControllers.Count];
			int num = -1907446385;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1907446386)
				{
				case 3:
					break;
				case 2:
					return null;
				case 0:
					array[num2] = customControllers[num2].id;
					num2++;
					num = -1907446390;
					continue;
				case 1:
					num2 = 0;
					num = -1907446390;
					continue;
				default:
					if (num2 >= customControllers.Count)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = -1907446388;
			goto IL_000d;
		}

		public Guid[] GetCustomControllerGuids()
		{
			if (customControllers == null)
			{
				return null;
			}
			Guid[] array = new Guid[customControllers.Count];
			int num = 0;
			while (num < customControllers.Count)
			{
				while (true)
				{
					array[num] = customControllers[num].typeGuid;
					num++;
					int num2 = -672249671;
					while (true)
					{
						switch (num2 ^ -672249669)
						{
						case 0:
							num2 = -672249670;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public CustomController_Editor GetCustomController(int index)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				return null;
			}
			return customControllers[index];
		}

		public CustomController_Editor GetCustomController(string name)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(name);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public CustomController_Editor GetCustomControllerById(int id)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(id);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public CustomController_Editor GetCustomControllerByHardwareTypeGuid(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(hardwareTypeGuid);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public int GetCustomControllerId(string name)
		{
			if (customControllers == null)
			{
				return -1;
			}
			int num = IndexOfCustomController(name);
			if (num < 0)
			{
				return -1;
			}
			return customControllers[num].id;
		}

		public int IndexOfCustomController(int id)
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1559352248;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x5CF1D3BA)
				{
				case 4:
					break;
				case 1:
					return -1;
				case 0:
					if (customControllers[num].id == id)
					{
						return num;
					}
					num++;
					num2 = 1559352249;
					continue;
				case 2:
					num2 = 1559352249;
					continue;
				default:
					if (num >= customControllers.Count)
					{
						return -1;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1559352251;
			goto IL_000d;
		}

		public int IndexOfCustomController(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (customControllers == null)
				{
					return -1;
				}
				num = 0;
				num2 = 2011927335;
				goto IL_0015;
			}
			goto IL_007c;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x77EB9327)
				{
				case 2:
					break;
				case 0:
					goto IL_0036;
				case 3:
					goto IL_0055;
				case 1:
					goto IL_007c;
				default:
					return -1;
				}
				break;
				IL_0055:
				if (customControllers[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 2011927335;
				continue;
				IL_0036:
				int num3;
				if (num >= customControllers.Count)
				{
					num2 = 2011927331;
					num3 = num2;
				}
				else
				{
					num2 = 2011927332;
					num3 = num2;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = 2011927334;
			goto IL_0015;
			IL_007c:
			return -1;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -10688543;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -10688544)
				{
				case 0:
					break;
				case 3:
					return -1;
				case 2:
					if (!(customControllers[num].typeGuid == hardwareTypeGuid))
					{
						goto IL_0050;
					}
					return num;
				default:
					if (num >= customControllers.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_0050:
				num++;
				num2 = -10688543;
			}
			goto IL_0008;
			IL_0008:
			num2 = -10688541;
			goto IL_000d;
		}

		public string GetCustomControllerNameById(int id)
		{
			if (customControllers != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -665033644;
					while (true)
					{
						switch (num ^ -665033647)
						{
						case 4:
							break;
						case 2:
							goto IL_0035;
						case 0:
							goto IL_0054;
						case 3:
							return customControllers[num2].name;
						case 5:
							num2 = 0;
							num = -665033645;
							continue;
						default:
							goto end_IL_000b;
						}
						break;
						IL_0054:
						if (customControllers[num2].id == id)
						{
							num = -665033646;
							continue;
						}
						num2++;
						num = -665033645;
						continue;
						IL_0035:
						int num3;
						if (num2 < customControllers.Count)
						{
							num = -665033647;
							num3 = num;
						}
						else
						{
							num = -665033648;
							num3 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			return "Unknown";
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
			controllerMapLayoutManagerRuleSets.Add(SKbeLrasInhclDrgEyZUZmAugcZ());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index >= 0)
			{
				if (index < controllerMapLayoutManagerRuleSets.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (0x345BB315 ^ 0x345BB314)
					{
					case 2:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			controllerMapLayoutManagerRuleSets.Insert(index, SKbeLrasInhclDrgEyZUZmAugcZ());
		}

		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets != null && index >= 0)
			{
				int num2 = default(int);
				int id = default(int);
				List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
				int num3 = default(int);
				Player_Editor player_Editor = default(Player_Editor);
				while (true)
				{
					int num = -766083606;
					while (true)
					{
						switch (num ^ -766083603)
						{
						case 10:
							break;
						case 0:
							goto IL_005f;
						case 8:
							goto IL_007e;
						case 11:
							num2++;
							num = -766083603;
							continue;
						case 3:
							id = controllerMapLayoutManagerRuleSets[index].id;
							if (players != null)
							{
								num2 = 0;
								num = -766083612;
								continue;
							}
							goto default;
						case 12:
							if (ruleSets[num3] != null && ruleSets[num3].id == id)
							{
								ruleSets.RemoveAt(num3);
								num = -766083605;
								continue;
							}
							goto case 6;
						case 13:
							if (player_Editor != null)
							{
								ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
								if (ruleSets != null)
								{
									num3 = ruleSets.Count - 1;
									num = -766083604;
									continue;
								}
							}
							goto case 11;
						case 6:
							num3--;
							num = -766083611;
							continue;
						case 4:
							player_Editor = players[num2];
							num = -766083616;
							continue;
						case 5:
							goto end_IL_0012;
						case 9:
							num = -766083603;
							continue;
						case 1:
							num = -766083611;
							continue;
						case 7:
							goto IL_016d;
						default:
							controllerMapLayoutManagerRuleSets.RemoveAt(index);
							return;
						}
						break;
						IL_016d:
						int num4;
						if (index >= controllerMapLayoutManagerRuleSets.Count)
						{
							num = -766083608;
							num4 = num;
						}
						else
						{
							num = -766083602;
							num4 = num;
						}
						continue;
						IL_007e:
						int num5;
						if (num3 >= 0)
						{
							num = -766083615;
							num5 = num;
						}
						else
						{
							num = -766083610;
							num5 = num;
						}
						continue;
						IL_005f:
						int num6;
						if (num2 >= players.Count)
						{
							num = -766083601;
							num6 = num;
						}
						else
						{
							num = -766083607;
							num6 = num;
						}
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets != null && index >= 0)
			{
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = default(ControllerMapLayoutManager_RuleSet_Editor);
				while (true)
				{
					int num = 896295693;
					while (true)
					{
						switch (num ^ 0x356C6309)
						{
						case 0:
							break;
						case 4:
							goto IL_003b;
						case 1:
							controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
							controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
							controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
							if (index == controllerMapLayoutManagerRuleSets.Count - 1)
							{
								controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
								return;
							}
							goto default;
						case 2:
							goto end_IL_0012;
						default:
							controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
							return;
						}
						break;
						IL_003b:
						int num2;
						if (index >= controllerMapLayoutManagerRuleSets.Count)
						{
							num = 896295691;
							num2 = num;
						}
						else
						{
							num = 896295688;
							num2 = num;
						}
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (players != null)
			{
				int num2 = 0;
				List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
				Player_Editor player_Editor = default(Player_Editor);
				int num4 = default(int);
				while (true)
				{
					int num3 = 1107164228;
					while (true)
					{
						switch (num3 ^ 0x41FDFC4C)
						{
						case 2:
							break;
						case 6:
							goto IL_0062;
						case 7:
							ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
							if (ruleSets != null)
							{
								num4 = ruleSets.Count - 1;
								num3 = 1107164237;
								continue;
							}
							goto case 3;
						case 4:
							goto IL_0098;
						case 11:
							num++;
							num3 = 1107164230;
							continue;
						case 12:
							player_Editor = players[num2];
							num3 = 1107164232;
							continue;
						case 10:
							num4--;
							num3 = 1107164234;
							continue;
						case 3:
							num2++;
							num3 = 1107164233;
							continue;
						case 8:
							num3 = 1107164233;
							continue;
						case 5:
							goto IL_00fc;
						case 1:
							num3 = 1107164234;
							continue;
						case 9:
							if (ruleSets[num4] == null)
							{
								goto case 10;
							}
							goto IL_0132;
						default:
							goto end_IL_0019;
						}
						break;
						IL_0132:
						int num5;
						if (ruleSets[num4].id != id)
						{
							num3 = 1107164230;
							num5 = num3;
						}
						else
						{
							num3 = 1107164231;
							num5 = num3;
						}
						continue;
						IL_0098:
						int num6;
						if (player_Editor != null)
						{
							num3 = 1107164235;
							num6 = num3;
						}
						else
						{
							num3 = 1107164239;
							num6 = num3;
						}
						continue;
						IL_0062:
						int num7;
						if (num4 >= 0)
						{
							num3 = 1107164229;
							num7 = num3;
						}
						else
						{
							num3 = 1107164239;
							num7 = num3;
						}
						continue;
						IL_00fc:
						int num8;
						if (num2 >= players.Count)
						{
							num3 = 1107164236;
							num8 = num3;
						}
						else
						{
							num3 = 1107164224;
							num8 = num3;
						}
					}
					continue;
					end_IL_0019:
					break;
				}
			}
			return num;
		}

		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1813618337;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x6C199EA2)
				{
				case 0:
					break;
				case 1:
					return 0;
				case 2:
					if (controllerMapLayoutManagerRuleSets[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= controllerMapLayoutManagerRuleSets.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_004b:
				num++;
				num2 = 1813618337;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1813618339;
			goto IL_000d;
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				goto IL_0008;
			}
			string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
			int num = 0;
			int num2 = 839662593;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x320C3C05)
				{
				case 2:
					break;
				case 1:
					return null;
				case 3:
					array[num] = controllerMapLayoutManagerRuleSets[num].name;
					num++;
					num2 = 839662593;
					continue;
				case 4:
				{
					int num3;
					if (num >= controllerMapLayoutManagerRuleSets.Count)
					{
						num2 = 839662597;
						num3 = num2;
					}
					else
					{
						num2 = 839662598;
						num3 = num2;
					}
					continue;
				}
				default:
					return array;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 839662596;
			goto IL_000d;
		}

		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapLayoutManagerRuleSets.Count];
			int num = 0;
			while (true)
			{
				int num2 = 112778437;
				while (true)
				{
					switch (num2 ^ 0x6B8DCC6)
					{
					case 0:
						break;
					case 3:
						num2 = 112778439;
						continue;
					case 2:
						array[num] = controllerMapLayoutManagerRuleSets[num].id;
						num++;
						num2 = 112778439;
						continue;
					default:
						if (num >= controllerMapLayoutManagerRuleSets.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets != null && index >= 0)
			{
				while (true)
				{
					int num = 2142068824;
					while (true)
					{
						switch (num ^ 0x7FAD605A)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (index >= controllerMapLayoutManagerRuleSets.Count)
						{
							num = 2142068827;
							continue;
						}
						return controllerMapLayoutManagerRuleSets[index];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			while (true)
			{
				int num2 = 2093081432;
				while (true)
				{
					switch (num2 ^ 0x7CC1E35A)
					{
					case 0:
						break;
					case 2:
						if (num < 0)
						{
							goto IL_0034;
						}
						return controllerMapLayoutManagerRuleSets[num];
					default:
						return null;
					}
					break;
					IL_0034:
					num2 = 2093081435;
				}
			}
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSetById(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[num];
		}

		public int GetControllerMapLayoutManagerRuleSetId(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return controllerMapLayoutManagerRuleSets[num].id;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -8241606;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -8241607)
				{
				case 0:
					break;
				case 1:
					return -1;
				case 2:
					if (controllerMapLayoutManagerRuleSets[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= controllerMapLayoutManagerRuleSets.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_004b:
				num++;
				num2 = -8241606;
			}
			goto IL_0008;
			IL_0008:
			num2 = -8241608;
			goto IL_000d;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (controllerMapLayoutManagerRuleSets == null)
				{
					return -1;
				}
				num = 0;
				num2 = 617805746;
				goto IL_0015;
			}
			goto IL_003a;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x24D2F7B7)
				{
				case 4:
					break;
				case 1:
					goto IL_003a;
				case 3:
					return num;
				case 2:
					goto IL_005c;
				case 5:
					num2 = 617805751;
					continue;
				default:
					if (num >= controllerMapLayoutManagerRuleSets.Count)
					{
						return -1;
					}
					goto IL_005c;
				}
				break;
				IL_005c:
				if (!controllerMapLayoutManagerRuleSets[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					num2 = 617805751;
				}
				else
				{
					num2 = 617805748;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = 617805750;
			goto IL_0015;
			IL_003a:
			return -1;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < controllerMapLayoutManagerRuleSets.Count)
					{
						num2 = -215577007;
						num3 = num2;
					}
					else
					{
						num2 = -215577008;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -215577008)
						{
						case 2:
							num2 = -215577007;
							continue;
						case 1:
							break;
						case 3:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (controllerMapLayoutManagerRuleSets[num].id == id)
						{
							return controllerMapLayoutManagerRuleSets[num].name;
						}
						num++;
						num2 = -215577005;
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
			}
			return "Unknown";
		}

		public int GetControllerMapLayoutManagerRuleSetCount()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			return controllerMapLayoutManagerRuleSets.Count;
		}

		public void AddControllerMapEnablerRuleSet()
		{
			controllerMapEnablerRuleSets.Add(DnhLxyfEZALrQacqpiQiulGCpxB());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index >= 0)
			{
				if (index < controllerMapEnablerRuleSets.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-1116499204 ^ -1116499203)
					{
					case 0:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			controllerMapEnablerRuleSets.Insert(index, DnhLxyfEZALrQacqpiQiulGCpxB());
		}

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0)
			{
				goto IL_0137;
			}
			if (index >= controllerMapEnablerRuleSets.Count)
			{
				goto IL_0023;
			}
			goto IL_0160;
			IL_0137:
			throw new ArgumentOutOfRangeException("index");
			IL_0160:
			int id = controllerMapEnablerRuleSets[index].id;
			int num;
			int num2;
			if (players == null)
			{
				num = 996511768;
				num2 = num;
			}
			else
			{
				num = 996511763;
				num2 = num;
			}
			goto IL_0028;
			IL_0023:
			num = 996511773;
			goto IL_0028;
			IL_0028:
			int num3 = default(int);
			int num4 = default(int);
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			while (true)
			{
				switch (num ^ 0x3B65901F)
				{
				case 8:
					break;
				case 9:
					num3--;
					num = 996511771;
					continue;
				case 6:
					goto IL_007d;
				case 3:
					goto IL_009c;
				case 12:
					num4 = 0;
					num = 996511762;
					continue;
				case 13:
					num = 996511769;
					continue;
				case 4:
					goto IL_00c9;
				case 0:
					if (ruleSets[num3] != null && ruleSets[num3].id == id)
					{
						ruleSets.RemoveAt(num3);
						num = 996511766;
						continue;
					}
					goto case 9;
				case 10:
				{
					Player_Editor player_Editor = players[num4];
					if (player_Editor != null)
					{
						ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
						num = 996511772;
						continue;
					}
					goto case 11;
				}
				case 2:
					goto IL_0137;
				case 1:
					num3 = ruleSets.Count - 1;
					num = 996511771;
					continue;
				case 5:
					goto IL_0160;
				case 11:
					num4++;
					num = 996511769;
					continue;
				default:
					controllerMapEnablerRuleSets.RemoveAt(index);
					return;
				}
				break;
				IL_00c9:
				int num5;
				if (num3 >= 0)
				{
					num = 996511775;
					num5 = num;
				}
				else
				{
					num = 996511764;
					num5 = num;
				}
				continue;
				IL_009c:
				int num6;
				if (ruleSets != null)
				{
					num = 996511774;
					num6 = num;
				}
				else
				{
					num = 996511764;
					num6 = num;
				}
				continue;
				IL_007d:
				int num7;
				if (num4 >= players.Count)
				{
					num = 996511768;
					num7 = num;
				}
				else
				{
					num = 996511765;
					num7 = num;
				}
			}
			goto IL_0023;
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0)
			{
				goto IL_0043;
			}
			if (index >= controllerMapEnablerRuleSets.Count)
			{
				goto IL_001a;
			}
			goto IL_0055;
			IL_0043:
			throw new ArgumentOutOfRangeException("index");
			IL_00b2:
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = default(ControllerMapEnabler_RuleSet_Editor);
			controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
			int num = 1136397796;
			goto IL_001f;
			IL_001a:
			num = 1136397795;
			goto IL_001f;
			IL_001f:
			switch (num ^ 0x43BC0DE7)
			{
			case 2:
				break;
			default:
				return;
			case 4:
				goto IL_0043;
			case 0:
				goto IL_0055;
			case 1:
				goto IL_00b2;
			case 3:
				return;
			}
			goto IL_001a;
			IL_0055:
			controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
			if (index == controllerMapEnablerRuleSets.Count - 1)
			{
				controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
				return;
			}
			goto IL_00b2;
		}

		public int GetControllerMapEnablerRuleSetUsedCount(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			int num3 = default(int);
			Player_Editor player_Editor = default(Player_Editor);
			int num5 = default(int);
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			while (true)
			{
				int num2 = -32806394;
				while (true)
				{
					switch (num2 ^ -32806387)
					{
					case 10:
						break;
					case 11:
						if (players != null)
						{
							num3 = 0;
							num2 = -32806395;
							continue;
						}
						goto default;
					case 3:
					{
						player_Editor = players[num3];
						int num8;
						if (player_Editor != null)
						{
							num2 = -32806392;
							num8 = num2;
						}
						else
						{
							num2 = -32806390;
							num8 = num2;
						}
						continue;
					}
					case 1:
						num5--;
						num2 = -32806387;
						continue;
					case 4:
					{
						int num6;
						if (ruleSets != null)
						{
							num2 = -32806385;
							num6 = num2;
						}
						else
						{
							num2 = -32806390;
							num6 = num2;
						}
						continue;
					}
					case 2:
						num5 = ruleSets.Count - 1;
						num2 = -32806387;
						continue;
					case 7:
						num3++;
						num2 = -32806395;
						continue;
					case 5:
						ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
						num2 = -32806391;
						continue;
					case 0:
					{
						int num7;
						if (num5 >= 0)
						{
							num2 = -32806389;
							num7 = num2;
						}
						else
						{
							num2 = -32806390;
							num7 = num2;
						}
						continue;
					}
					case 6:
						if (ruleSets[num5] != null && ruleSets[num5].id == id)
						{
							num++;
							num2 = -32806388;
							continue;
						}
						goto case 1;
					case 8:
					{
						int num4;
						if (num3 >= players.Count)
						{
							num2 = -32806396;
							num4 = num2;
						}
						else
						{
							num2 = -32806386;
							num4 = num2;
						}
						continue;
					}
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetControllerMapEnablerRuleSetIndex(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < controllerMapEnablerRuleSets.Count)
				{
					num2 = -401692539;
					num3 = num2;
				}
				else
				{
					num2 = -401692538;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -401692538)
					{
					case 4:
						num2 = -401692539;
						continue;
					case 3:
						if (controllerMapEnablerRuleSets[num].id == id)
						{
							num2 = -401692540;
							continue;
						}
						num++;
						num2 = -401692537;
						continue;
					case 2:
						return num;
					case 1:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public string[] GetControllerMapEnablerRuleSetNames()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapEnablerRuleSets.Count];
			int num = 0;
			while (num < controllerMapEnablerRuleSets.Count)
			{
				while (true)
				{
					array[num] = controllerMapEnablerRuleSets[num].name;
					num++;
					int num2 = -1761477205;
					while (true)
					{
						switch (num2 ^ -1761477206)
						{
						case 0:
							num2 = -1761477208;
							continue;
						case 2:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public int[] GetControllerMapEnablerRuleSetIds()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapEnablerRuleSets.Count];
			int num2 = default(int);
			while (true)
			{
				int num = 644425572;
				while (true)
				{
					switch (num ^ 0x26692767)
					{
					case 0:
						break;
					case 5:
						array[num2] = controllerMapEnablerRuleSets[num2].id;
						num2++;
						num = 644425573;
						continue;
					case 1:
						num = 644425573;
						continue;
					case 3:
						num2 = 0;
						num = 644425574;
						continue;
					case 2:
					{
						int num3;
						if (num2 < controllerMapEnablerRuleSets.Count)
						{
							num = 644425570;
							num3 = num;
						}
						else
						{
							num = 644425571;
							num3 = num;
						}
						continue;
					}
					default:
						return array;
					}
					break;
				}
			}
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[index];
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(string name)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			while (true)
			{
				int num2 = -1409657456;
				while (true)
				{
					switch (num2 ^ -1409657455)
					{
					case 2:
						break;
					case 1:
						if (num < 0)
						{
							goto IL_0034;
						}
						return controllerMapEnablerRuleSets[num];
					default:
						return null;
					}
					break;
					IL_0034:
					num2 = -1409657455;
				}
			}
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSetById(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapEnablerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[num];
		}

		public int GetControllerMapEnablerRuleSetId(string name)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return controllerMapEnablerRuleSets[num].id;
		}

		public int IndexOfControllerMapEnablerRuleSet(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 826711894;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x31469F52)
				{
				case 3:
					break;
				case 0:
					if (controllerMapEnablerRuleSets[num].id == id)
					{
						return num;
					}
					num++;
					num2 = 826711895;
					continue;
				case 4:
					num2 = 826711895;
					continue;
				case 5:
				{
					int num3;
					if (num < controllerMapEnablerRuleSets.Count)
					{
						num2 = 826711890;
						num3 = num2;
					}
					else
					{
						num2 = 826711888;
						num3 = num2;
					}
					continue;
				}
				case 1:
					return -1;
				default:
					return -1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 826711891;
			goto IL_000d;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (controllerMapEnablerRuleSets == null)
				{
					return -1;
				}
				num = 0;
				num2 = -81550492;
				goto IL_0015;
			}
			goto IL_0064;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -81550489)
				{
				case 0:
					break;
				case 2:
					return num;
				case 4:
					goto IL_0043;
				case 1:
					goto IL_0064;
				default:
					if (num >= controllerMapEnablerRuleSets.Count)
					{
						return -1;
					}
					goto IL_0043;
				}
				break;
				IL_0043:
				if (!controllerMapEnablerRuleSets[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					num2 = -81550492;
				}
				else
				{
					num2 = -81550491;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = -81550490;
			goto IL_0015;
			IL_0064:
			return -1;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -1526260112;
					while (true)
					{
						switch (num ^ -1526260108)
						{
						case 0:
							break;
						case 3:
							goto IL_002e;
						case 2:
							goto IL_004d;
						case 4:
							num2 = 0;
							num = -1526260105;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_004d:
						if (controllerMapEnablerRuleSets[num2].id == id)
						{
							return controllerMapEnablerRuleSets[num2].name;
						}
						num2++;
						num = -1526260105;
						continue;
						IL_002e:
						int num3;
						if (num2 >= controllerMapEnablerRuleSets.Count)
						{
							num = -1526260107;
							num3 = num;
						}
						else
						{
							num = -1526260106;
							num3 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return "Unknown";
		}

		public int GetControllerMapEnablerRuleSetCount()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			return controllerMapEnablerRuleSets.Count;
		}

		public int GetNewPlayerId()
		{
			int result = playerIdCounter;
			playerIdCounter++;
			return result;
		}

		public int GetNewActionId()
		{
			int result = actionIdCounter;
			actionIdCounter++;
			return result;
		}

		public int GetNewActionCategoryId()
		{
			int result = actionCategoryIdCounter;
			actionCategoryIdCounter++;
			return result;
		}

		public int GetNewInputBehaviorId()
		{
			int result = inputBehaviorIdCounter;
			inputBehaviorIdCounter++;
			return result;
		}

		public int GetNewMapCategoryId()
		{
			int result = mapCategoryIdCounter;
			mapCategoryIdCounter++;
			return result;
		}

		public int GetNewJoystickLayoutId()
		{
			int result = joystickLayoutIdCounter;
			joystickLayoutIdCounter++;
			return result;
		}

		public int GetNewKeyboardLayoutId()
		{
			int result = keyboardLayoutIdCounter;
			keyboardLayoutIdCounter++;
			return result;
		}

		public int GetNewMouseLayoutId()
		{
			int result = mouseLayoutIdCounter;
			mouseLayoutIdCounter++;
			return result;
		}

		public int GetNewCustomControllerLayoutId()
		{
			int result = customControllerLayoutIdCounter;
			customControllerLayoutIdCounter++;
			return result;
		}

		public int GetNewJoystickMapId()
		{
			int result = joystickMapIdCounter;
			joystickMapIdCounter++;
			return result;
		}

		public int GetNewKeyboardMapId()
		{
			int result = keyboardMapIdCounter;
			keyboardMapIdCounter++;
			return result;
		}

		public int GetNewMouseMapId()
		{
			int result = mouseMapIdCounter;
			mouseMapIdCounter++;
			return result;
		}

		public int GetNewCustomControllerMapId()
		{
			int result = customControllerMapIdCounter;
			customControllerMapIdCounter++;
			return result;
		}

		public int GetNewCustomControllerId()
		{
			int result = customControllerIdCounter;
			customControllerIdCounter++;
			return result;
		}

		public int GetNewControllerMapLayoutManagerRuleSetId()
		{
			int result = controllerMapLayoutManagerSetIdCounter;
			controllerMapLayoutManagerSetIdCounter++;
			return result;
		}

		public int GetNewControllerMapEnablerRuleSetId()
		{
			int result = controllerMapEnablerSetIdCounter;
			controllerMapEnablerSetIdCounter++;
			return result;
		}

		private Player_Editor xkPlRfdDhdbQwGcBAKViUTWyaKs()
		{
			Player_Editor player_Editor = new Player_Editor();
			while (true)
			{
				int num = -633518912;
				while (true)
				{
					switch (num ^ -633518909)
					{
					case 5:
						break;
					case 3:
						player_Editor.id = GetNewPlayerId();
						player_Editor.name = StringTools.IterateName("Player", -1, GetPlayerNames());
						player_Editor.descriptiveName = player_Editor.name;
						player_Editor.startPlaying = true;
						num = -633518905;
						continue;
					case 1:
						player_Editor.assignKeyboardOnStart = true;
						num = -633518909;
						continue;
					case 4:
						if (players.Count == 1)
						{
							player_Editor.assignMouseOnStart = true;
							num = -633518910;
							continue;
						}
						goto case 1;
					case 0:
						player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
						player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
						num = -633518911;
						continue;
					default:
						return player_Editor;
					}
					break;
				}
			}
		}

		private InputAction NQcSIoMzGUscevccPhPYYqpTcKtc()
		{
			InputAction inputAction = new InputAction();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName("Action", -1, GetActionNames());
			inputAction.descriptiveName = inputAction.name;
			inputAction.type = InputActionType.Button;
			inputAction.userAssignable = true;
			inputAction.behaviorId = 0;
			return inputAction;
		}

		private InputCategory wYPlRkyWlKzBfwFluUDoyXIZXSb()
		{
			InputCategory inputCategory = new InputCategory();
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName("Category", -1, GetActionCategoryNames());
			inputCategory.descriptiveName = inputCategory.name;
			while (true)
			{
				int num = -1951432844;
				while (true)
				{
					switch (num ^ -1951432843)
					{
					case 2:
						break;
					case 1:
						goto IL_0053;
					default:
						return inputCategory;
					}
					break;
					IL_0053:
					inputCategory.userAssignable = true;
					num = -1951432843;
				}
			}
		}

		private InputBehavior XnzApLRcXATUYmKKXdMHPIJzOUr()
		{
			InputBehavior inputBehavior = new InputBehavior();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames());
			inputBehavior.digitalAxisSimulation = true;
			while (true)
			{
				int num = -587742885;
				while (true)
				{
					switch (num ^ -587742881)
					{
					case 0:
						break;
					case 2:
						inputBehavior.mouseOtherAxisSensitivity = 1f;
						num = -587742882;
						continue;
					case 1:
						inputBehavior.buttonDoublePressSpeed = 0.3f;
						inputBehavior.buttonShortPressTime = 0.25f;
						inputBehavior.buttonShortPressExpiresIn = 0f;
						num = -587742884;
						continue;
					case 4:
						inputBehavior.digitalAxisSnap = true;
						inputBehavior.digitalAxisInstantReverse = false;
						inputBehavior.digitalAxisGravity = 3f;
						num = -587742886;
						continue;
					case 5:
						inputBehavior.digitalAxisSensitivity = 3f;
						inputBehavior.mouseXYAxisMode = MouseXYAxisMode.MouseAxis;
						inputBehavior.mouseXYAxisSensitivity = 1f;
						inputBehavior.mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis;
						num = -587742883;
						continue;
					default:
						inputBehavior.buttonLongPressTime = 1f;
						inputBehavior.buttonLongPressExpiresIn = 0f;
						inputBehavior.buttonDeadZone = 0.5f;
						inputBehavior.buttonDownBuffer = 0f;
						return inputBehavior;
					}
					break;
				}
			}
		}

		private InputMapCategory JCKvImtXObyamMoSdJdlETkBFFA()
		{
			InputMapCategory inputMapCategory = new InputMapCategory();
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName("Category", -1, GetMapCategoryNames());
			inputMapCategory.descriptiveName = inputMapCategory.name;
			inputMapCategory.userAssignable = true;
			inputMapCategory.checkConflictsWithAllCategories = true;
			return inputMapCategory;
		}

		private InputLayout MRuWhnXcyXxedGPBuqruWjMkwWX()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewJoystickLayoutId();
			while (true)
			{
				int num = 661519173;
				while (true)
				{
					switch (num ^ 0x276DFB44)
					{
					case 0:
						break;
					case 1:
						goto IL_0030;
					default:
						return inputLayout;
					}
					break;
					IL_0030:
					inputLayout.name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames());
					inputLayout.descriptiveName = inputLayout.name;
					num = 661519174;
				}
			}
		}

		private InputLayout lJPLAFvwFWSpNMjvjceqzxyzOnx()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewKeyboardLayoutId();
			while (true)
			{
				int num = -31179638;
				while (true)
				{
					switch (num ^ -31179637)
					{
					case 2:
						break;
					case 1:
						goto IL_0030;
					default:
						inputLayout.descriptiveName = inputLayout.name;
						return inputLayout;
					}
					break;
					IL_0030:
					inputLayout.name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames());
					num = -31179637;
				}
			}
		}

		private InputLayout HsYAEuoJsMgixjhiqiMzeZkQlsBA()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout IESIZuibhaXwmTIvuvkYbjIfFQg()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private CustomController_Editor MXDrOIoojAejhHSxnlbUTsghcNXe()
		{
			CustomController_Editor customController_Editor = new CustomController_Editor();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
			customController_Editor.name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames());
			customController_Editor.descriptiveName = customController_Editor.name;
			return customController_Editor;
		}

		private ControllerMapLayoutManager_RuleSet_Editor SKbeLrasInhclDrgEyZUZmAugcZ()
		{
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = new ControllerMapLayoutManager_RuleSet_Editor();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames());
			return controllerMapLayoutManager_RuleSet_Editor;
		}

		private ControllerMapEnabler_RuleSet_Editor DnhLxyfEZALrQacqpiQiulGCpxB()
		{
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = new ControllerMapEnabler_RuleSet_Editor();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			while (true)
			{
				int num = 1326711632;
				while (true)
				{
					switch (num ^ 0x4F140351)
					{
					case 0:
						break;
					case 1:
						goto IL_0030;
					default:
						return controllerMapEnabler_RuleSet_Editor;
					}
					break;
					IL_0030:
					controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames());
					num = 1326711635;
				}
			}
		}

		private ControllerMap_Editor NjfqfUMJEvDANDeJDDYjuwLJeNJp(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int num = 0;
			while (num < P_0.Count)
			{
				while (true)
				{
					int num2;
					if (P_0[num].categoryId == P_1)
					{
						num2 = -1454846654;
						goto IL_000e;
					}
					goto IL_0058;
					IL_0041:
					if (P_0[num].layoutId == P_2)
					{
						return P_0[num];
					}
					goto IL_0058;
					IL_0058:
					num++;
					num2 = -1454846655;
					goto IL_000e;
					IL_000e:
					while (true)
					{
						switch (num2 ^ -1454846654)
						{
						case 2:
							num2 = -1454846653;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0041;
						default:
							goto end_IL_002b;
						}
						break;
					}
					continue;
					end_IL_002b:
					break;
				}
			}
			return null;
		}

		private ControllerMap_Editor bLnZuTeBbCgKgIbQYJPYTcmoxcE(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = NjfqfUMJEvDANDeJDDYjuwLJeNJp(P_0, P_2, P_3);
			while (true)
			{
				int num = -989885791;
				while (true)
				{
					switch (num ^ -989885789)
					{
					case 0:
						break;
					case 2:
						if (controllerMap_Editor != null)
						{
							return controllerMap_Editor;
						}
						if (P_4)
						{
							controllerMap_Editor = AYOwqppCLaOWDpjbyaOugptkBiG(P_0, P_1, P_2, P_3);
							if (controllerMap_Editor != null)
							{
								goto IL_0041;
							}
						}
						return null;
					default:
						return controllerMap_Editor;
					}
					break;
					IL_0041:
					num = -989885790;
				}
			}
		}

		private ControllerMap_Editor AYOwqppCLaOWDpjbyaOugptkBiG(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			int num2 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = 1950328518;
				while (true)
				{
					switch (num ^ 0x743FA6C7)
					{
					case 6:
						break;
					case 0:
						return list[num2];
					case 2:
					{
						int num5;
						if (num4 >= list.Count)
						{
							num = 1950328515;
							num5 = num;
						}
						else
						{
							num = 1950328527;
							num5 = num;
						}
						continue;
					}
					case 8:
						if (list[num4].categoryId == 0)
						{
							return list[num4];
						}
						num4++;
						num = 1950328517;
						continue;
					case 1:
						if (list != null && list.Count > 0)
						{
							NSSAtdeAriMlUvrWgvmsLXJFEBN(list, P_1);
							num2 = 0;
							num = 1950328514;
							continue;
						}
						goto default;
					case 9:
						num4 = 0;
						num = 1950328517;
						continue;
					case 3:
						if (list[num2].categoryId != P_2)
						{
							num2++;
							num = 1950328512;
						}
						else
						{
							num = 1950328519;
						}
						continue;
					case 5:
						num = 1950328512;
						continue;
					case 7:
					{
						int num3;
						if (num2 < list.Count)
						{
							num = 1950328516;
							num3 = num;
						}
						else
						{
							num = 1950328526;
							num3 = num;
						}
						continue;
					}
					default:
						return null;
					}
					break;
				}
			}
		}

		private void NSSAtdeAriMlUvrWgvmsLXJFEBN(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			yKHiOlAfmtuFRRZhsGutrXCxDQt yKHiOlAfmtuFRRZhsGutrXCxDQt2 = new yKHiOlAfmtuFRRZhsGutrXCxDQt();
			yKHiOlAfmtuFRRZhsGutrXCxDQt2.IeiemSKkhKijZaCrFINGtGBZLAT = P_1;
			if (P_0 != null)
			{
				if (yKHiOlAfmtuFRRZhsGutrXCxDQt2.IeiemSKkhKijZaCrFINGtGBZLAT == null)
				{
					goto IL_0018;
				}
				goto IL_0042;
			}
			return;
			IL_0042:
			P_0.Sort(yKHiOlAfmtuFRRZhsGutrXCxDQt2.EmkxeyDqwTNaZoflyILNpsjCnFn);
			int num = 1957194521;
			goto IL_001d;
			IL_0018:
			num = 1957194520;
			goto IL_001d;
			IL_001d:
			switch (num ^ 0x74A86B19)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_0042;
			case 0:
				return;
			}
			goto IL_0018;
		}

		internal void dFyvOnKBbTYzKLbxHBbiIGdcrpeH()
		{
			Players_readOnly = new ReadOnlyCollection<Player_Editor>(players);
			int num2 = default(int);
			while (true)
			{
				int num = -1142843116;
				while (true)
				{
					switch (num ^ -1142843115)
					{
					case 2:
						break;
					case 0:
					{
						int num3;
						if (num2 < mapCategories.Count)
						{
							num = -1142843114;
							num3 = num;
						}
						else
						{
							num = -1142843118;
							num3 = num;
						}
						continue;
					}
					case 5:
						MapCategories_readOnly = new ReadOnlyCollection<InputMapCategory>(mapCategories);
						JoystickLayouts_readOnly = new ReadOnlyCollection<InputLayout>(joystickLayouts);
						KeyboardLayouts_readOnly = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
						num = -1142843107;
						continue;
					case 1:
						Actions_readOnly = new ReadOnlyCollection<InputAction>(actions);
						ActionCategories_readOnly = new ReadOnlyCollection<InputCategory>(actionCategories);
						InputBehaviors_readOnly = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
						num = -1142843120;
						continue;
					case 6:
						CustomControllerMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
						ControllerMapLayoutManagerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
						ControllerMapEnablerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
						if (mapCategories != null)
						{
							num2 = 0;
							num = -1142843115;
							continue;
						}
						goto default;
					case 3:
						mapCategories[num2].dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
						num = -1142843119;
						continue;
					case 8:
						MouseLayouts_readOnly = new ReadOnlyCollection<InputLayout>(mouseLayouts);
						CustomControllerLayouts_readOnly = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
						JoystickMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
						KeyboardMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
						MouseMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
						num = -1142843117;
						continue;
					case 4:
						num2++;
						num = -1142843115;
						continue;
					default:
						containsActionDelegate = ContainsAction;
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return hQFlTczTooYVbHDgHBoiIhBpFsPe.onbfkkhCIMQRhJJmpGvvIIMVRgn(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return hQFlTczTooYVbHDgHBoiIhBpFsPe.onbfkkhCIMQRhJJmpGvvIIMVRgn(orig, null, false);
		}

		[CompilerGenerated]
		private static void dYbgWZzxhVLsMRTwNVDMEBopHGd(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = -1416184342;
				while (true)
				{
					switch (num2 ^ -1416184338)
					{
					case 6:
						num2 = -1416184337;
						continue;
					case 2:
					{
						int num4;
						if (P_0[num].categoryId != P_1)
						{
							num2 = -1416184338;
							num4 = num2;
						}
						else
						{
							num2 = -1416184341;
							num4 = num2;
						}
						continue;
					}
					case 3:
					{
						int num3;
						if (P_0[num] == null)
						{
							num2 = -1416184341;
							num3 = num2;
						}
						else
						{
							num2 = -1416184340;
							num3 = num2;
						}
						continue;
					}
					case 1:
						break;
					case 0:
						num--;
						num2 = -1416184342;
						continue;
					case 5:
						P_0.RemoveAt(num);
						num2 = -1416184338;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void didqLLZkbGrbmanVoFFqHJXzDgXG(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0068;
			IL_0003:
			int num = -941099146;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -941099149)
				{
				case 6:
					break;
				case 8:
					num = -941099151;
					continue;
				case 1:
					goto IL_0040;
				case 5:
					return;
				case 7:
					goto IL_0068;
				case 0:
					P_0.RemoveAt(num2);
					num = -941099152;
					continue;
				case 4:
				{
					int num3;
					if (P_0[num2] != null)
					{
						num = -941099150;
						num3 = num;
					}
					else
					{
						num = -941099149;
						num3 = num;
					}
					continue;
				}
				case 3:
					num2--;
					num = -941099151;
					continue;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 4;
				}
				break;
				IL_0040:
				int num4;
				if (P_0[num2].layoutId == P_1)
				{
					num = -941099149;
					num4 = num;
				}
				else
				{
					num = -941099152;
					num4 = num;
				}
			}
			goto IL_0003;
			IL_0068:
			num2 = P_0.Count - 1;
			num = -941099141;
			goto IL_0008;
		}

		[CompilerGenerated]
		private static void afKgLWiUlmEPpfSYSxoscJZOXkZ(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 1167924002;
				while (true)
				{
					switch (num2 ^ 0x459D1B26)
					{
					case 2:
						num2 = 1167924005;
						continue;
					default:
						return;
					case 4:
					{
						int num5;
						if (num < 0)
						{
							num2 = 1167924001;
							num5 = num2;
						}
						else
						{
							num2 = 1167924006;
							num5 = num2;
						}
						continue;
					}
					case 1:
						num--;
						num2 = 1167924002;
						continue;
					case 6:
					{
						int num4;
						if (P_0[num].layoutId == P_1)
						{
							num2 = 1167924003;
							num4 = num2;
						}
						else
						{
							num2 = 1167924007;
							num4 = num2;
						}
						continue;
					}
					case 0:
					{
						int num3;
						if (P_0[num] != null)
						{
							num2 = 1167924000;
							num3 = num2;
						}
						else
						{
							num2 = 1167924003;
							num3 = num2;
						}
						continue;
					}
					case 5:
						P_0.RemoveAt(num);
						num2 = 1167924007;
						continue;
					case 3:
						break;
					case 7:
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void KaOIRsMUwFOSLGvlsujUlnJEuHf(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0073;
			IL_0003:
			int num = -1840739911;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1840739909)
				{
				case 4:
					break;
				case 5:
					P_0.RemoveAt(num2);
					num = -1840739907;
					continue;
				case 3:
					num = -1840739909;
					continue;
				case 7:
					if (P_0[num2] == null)
					{
						goto case 5;
					}
					goto IL_0053;
				case 1:
					goto IL_0073;
				case 6:
					num2--;
					num = -1840739909;
					continue;
				case 2:
					return;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 7;
				}
				break;
				IL_0053:
				int num3;
				if (P_0[num2].layoutId != P_1)
				{
					num = -1840739907;
					num3 = num;
				}
				else
				{
					num = -1840739906;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_0073:
			num2 = P_0.Count - 1;
			num = -1840739912;
			goto IL_0008;
		}

		[CompilerGenerated]
		private static void udgGsKdLjHPvGQNDIeuzQXXTbxy(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = -1653348882;
				while (true)
				{
					switch (num2 ^ -1653348886)
					{
					case 0:
						num2 = -1653348885;
						continue;
					case 2:
						P_0.RemoveAt(num);
						num2 = -1653348881;
						continue;
					case 3:
						if (P_0[num] != null)
						{
							int num3;
							if (P_0[num].layoutId != P_1)
							{
								num2 = -1653348881;
								num3 = num2;
							}
							else
							{
								num2 = -1653348888;
								num3 = num2;
							}
							continue;
						}
						goto case 2;
					case 5:
						num--;
						num2 = -1653348882;
						continue;
					case 1:
						break;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}
	}
}
