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
		private static class EOBbGZLmWHhOTxhjzoamLlwlEx
		{
			private class mldQVwfGWMIYCEomGCSLdjMzMyJ
			{
				public enum rmfvGWjDzfhrPmVBdBvIgIDcWAr
				{
					VVufcHGAAQKefGtCuZnoHaqpVcN = 0,
					JVXBRqfXueiCkTMNcKBxQjoHwfxP = 1,
					sAKYwxELDKIrbyyslYnFomEqhKC = 2
				}

				public int VVufcHGAAQKefGtCuZnoHaqpVcN;

				public int JVXBRqfXueiCkTMNcKBxQjoHwfxP;

				public int sAKYwxELDKIrbyyslYnFomEqhKC;

				public int this[rmfvGWjDzfhrPmVBdBvIgIDcWAr type]
				{
					get
					{
						return type switch
						{
							rmfvGWjDzfhrPmVBdBvIgIDcWAr.VVufcHGAAQKefGtCuZnoHaqpVcN => VVufcHGAAQKefGtCuZnoHaqpVcN, 
							rmfvGWjDzfhrPmVBdBvIgIDcWAr.JVXBRqfXueiCkTMNcKBxQjoHwfxP => JVXBRqfXueiCkTMNcKBxQjoHwfxP, 
							rmfvGWjDzfhrPmVBdBvIgIDcWAr.sAKYwxELDKIrbyyslYnFomEqhKC => sAKYwxELDKIrbyyslYnFomEqhKC, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (type)
						{
						case rmfvGWjDzfhrPmVBdBvIgIDcWAr.VVufcHGAAQKefGtCuZnoHaqpVcN:
							VVufcHGAAQKefGtCuZnoHaqpVcN = value;
							break;
						case rmfvGWjDzfhrPmVBdBvIgIDcWAr.JVXBRqfXueiCkTMNcKBxQjoHwfxP:
							JVXBRqfXueiCkTMNcKBxQjoHwfxP = value;
							break;
						case rmfvGWjDzfhrPmVBdBvIgIDcWAr.sAKYwxELDKIrbyyslYnFomEqhKC:
							sAKYwxELDKIrbyyslYnFomEqhKC = value;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public mldQVwfGWMIYCEomGCSLdjMzMyJ(int origId, int otherId, int finalId)
				{
					VVufcHGAAQKefGtCuZnoHaqpVcN = origId;
					JVXBRqfXueiCkTMNcKBxQjoHwfxP = otherId;
					sAKYwxELDKIrbyyslYnFomEqhKC = finalId;
				}

				public override string ToString()
				{
					string text = "";
					text += StringTools.WriteVar("origId", VVufcHGAAQKefGtCuZnoHaqpVcN);
					text += StringTools.WriteVar("otherId", JVXBRqfXueiCkTMNcKBxQjoHwfxP);
					return text + StringTools.WriteVar("finalId", sAKYwxELDKIrbyyslYnFomEqhKC);
				}
			}

			private class cZLOdDIumDYkDZFvhYOclIrWViM<T>
			{
				public T pvWFxzKxnLSsVUfuhbHEklmKEkfe;

				public T gpPKZjURlbtJeQNirBHucjPQfJDA;

				public mldQVwfGWMIYCEomGCSLdjMzMyJ.rmfvGWjDzfhrPmVBdBvIgIDcWAr rGJPsZGmchUwIUleWWPNJcpgFgS;

				public IList<T> EAOJWPvuzZdSUfZJKFFDodDeqqg;

				public bool TYzMJHaauFcrCbTsSvvwmqZujWxQ;

				public cZLOdDIumDYkDZFvhYOclIrWViM(T otherItem, T finalItem, mldQVwfGWMIYCEomGCSLdjMzMyJ.rmfvGWjDzfhrPmVBdBvIgIDcWAr idType, IList<T> finalItems, bool isCollision)
				{
					pvWFxzKxnLSsVUfuhbHEklmKEkfe = otherItem;
					gpPKZjURlbtJeQNirBHucjPQfJDA = finalItem;
					rGJPsZGmchUwIUleWWPNJcpgFgS = idType;
					EAOJWPvuzZdSUfZJKFFDodDeqqg = finalItems;
					TYzMJHaauFcrCbTsSvvwmqZujWxQ = isCollision;
				}
			}

			private sealed class WFbHeUEVPiMzIiIbTldTTILXvbSe
			{
				private sealed class cBHDgLRluPwBZaAeFKDtzFOBhTf
				{
					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public cZLOdDIumDYkDZFvhYOclIrWViM<InputAction> krbfVTDEmdCGfHJdGtNodlokSfiE;

					public bool DuqjNzjQDGlnarbPpOUhtjLkFKt(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe.categoryId;
					}

					public bool ifcSIhBkcpVnYOaKwmQMswzStNg(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe.behaviorId;
					}
				}

				private sealed class rWkvqnbVZTWtcXCvsFHQbvMnafR
				{
					public cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMapLayoutManager_RuleSet_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;
				}

				private sealed class BpeGIYvHDmSPFAJXsKYhOvmgIJO
				{
					public rWkvqnbVZTWtcXCvsFHQbvMnafR JjeGaGbZmToMdTpJsirDFoGwePn;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int CVMSgLtooYEeCzscEbPbbmUKKAO;

					public bool CKvwrkBZXYYKLGHERmXZtUDmDHi(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[JjeGaGbZmToMdTpJsirDFoGwePn.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == CVMSgLtooYEeCzscEbPbbmUKKAO;
					}
				}

				private sealed class IKsjFndmZoFoYBgHSPGvabBbmawF
				{
					public rWkvqnbVZTWtcXCvsFHQbvMnafR JjeGaGbZmToMdTpJsirDFoGwePn;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int CVMSgLtooYEeCzscEbPbbmUKKAO;

					public bool wegRPZmPOfFPTzvLodBYBbvOzbo(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[JjeGaGbZmToMdTpJsirDFoGwePn.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == CVMSgLtooYEeCzscEbPbbmUKKAO;
					}
				}

				private sealed class AxhWHIqEljuNmYNyLNVvKJneDen
				{
					public rWkvqnbVZTWtcXCvsFHQbvMnafR JjeGaGbZmToMdTpJsirDFoGwePn;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int CVMSgLtooYEeCzscEbPbbmUKKAO;

					public bool JeCGqNqsPUbQQyiXmDAMbOnotIcg(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[JjeGaGbZmToMdTpJsirDFoGwePn.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == CVMSgLtooYEeCzscEbPbbmUKKAO;
					}
				}

				private sealed class VQtMZgWajnlmbjKITukvJHPMUVx
				{
					public cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMapEnabler_RuleSet_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;
				}

				private sealed class YBELCVWMfogEJcffaeOAFcuiEce
				{
					public VQtMZgWajnlmbjKITukvJHPMUVx lyfRjOTQzmHxggJWIfUAKDYvxFW;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int CVMSgLtooYEeCzscEbPbbmUKKAO;

					public bool QuAbqaaJIrjyxJKEAYxTXMQXprJ(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[lyfRjOTQzmHxggJWIfUAKDYvxFW.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == CVMSgLtooYEeCzscEbPbbmUKKAO;
					}
				}

				private sealed class pKTJRXJxeFIteOcPIACpgIFJVEQ
				{
					public VQtMZgWajnlmbjKITukvJHPMUVx lyfRjOTQzmHxggJWIfUAKDYvxFW;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int CVMSgLtooYEeCzscEbPbbmUKKAO;

					public bool niSRefSXHdAWFVJmvBKbgwbNPoa(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[lyfRjOTQzmHxggJWIfUAKDYvxFW.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == CVMSgLtooYEeCzscEbPbbmUKKAO;
					}
				}

				private sealed class XuCfgvSqkvURJxAzwyviTiwbAyyf
				{
					public VQtMZgWajnlmbjKITukvJHPMUVx lyfRjOTQzmHxggJWIfUAKDYvxFW;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int CVMSgLtooYEeCzscEbPbbmUKKAO;

					public bool EMoFZGbNkMqZFKaCvgiviBAFFmpl(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[lyfRjOTQzmHxggJWIfUAKDYvxFW.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == CVMSgLtooYEeCzscEbPbbmUKKAO;
					}
				}

				private sealed class WYlMGhiLuAqCiRRmGdkLQKHjjDF
				{
					private sealed class MFSjfgbZNkjxOlqgBsQJwSUdWnBM
					{
						public WYlMGhiLuAqCiRRmGdkLQKHjjDF nvPgMJYNBpoPaACMJfNtdKyBYHj;

						public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

						public Player_Editor.Mapping sCZiujcEtiokSidOXBUYOQmKEdNw;

						public bool etLyUtMjaHaRpGsczKhuDyBJAiyr(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
						{
							return P_0[nvPgMJYNBpoPaACMJfNtdKyBYHj.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == sCZiujcEtiokSidOXBUYOQmKEdNw.categoryId;
						}

						public bool MbLZbcsFUFLYoOzxQldimYUYELz(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
						{
							return P_0[nvPgMJYNBpoPaACMJfNtdKyBYHj.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == sCZiujcEtiokSidOXBUYOQmKEdNw.layoutId;
						}
					}

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public cZLOdDIumDYkDZFvhYOclIrWViM<Player_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;

					public void BADHeEMplLDFAKnOwSEAdcleOtu(List<Player_Editor.Mapping> P_0, List<mldQVwfGWMIYCEomGCSLdjMzMyJ> P_1)
					{
						for (int i = 0; i < P_0.Count; i++)
						{
							MFSjfgbZNkjxOlqgBsQJwSUdWnBM mFSjfgbZNkjxOlqgBsQJwSUdWnBM = new MFSjfgbZNkjxOlqgBsQJwSUdWnBM();
							mFSjfgbZNkjxOlqgBsQJwSUdWnBM.nvPgMJYNBpoPaACMJfNtdKyBYHj = this;
							mFSjfgbZNkjxOlqgBsQJwSUdWnBM.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
							mFSjfgbZNkjxOlqgBsQJwSUdWnBM.sCZiujcEtiokSidOXBUYOQmKEdNw = P_0[i];
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(mFSjfgbZNkjxOlqgBsQJwSUdWnBM.etLyUtMjaHaRpGsczKhuDyBJAiyr);
							mFSjfgbZNkjxOlqgBsQJwSUdWnBM.sCZiujcEtiokSidOXBUYOQmKEdNw.categoryId = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
							mldQVwfGWMIYCEomGCSLdjMzMyJ2 = P_1.Find(mFSjfgbZNkjxOlqgBsQJwSUdWnBM.MbLZbcsFUFLYoOzxQldimYUYELz);
							mFSjfgbZNkjxOlqgBsQJwSUdWnBM.sCZiujcEtiokSidOXBUYOQmKEdNw.layoutId = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
						}
					}
				}

				private sealed class FkgGAxjJPgbWugEvRfxYIZdNmrRe
				{
					public WYlMGhiLuAqCiRRmGdkLQKHjjDF nvPgMJYNBpoPaACMJfNtdKyBYHj;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public Player_Editor.CreateControllerInfo KBzfyXGfCzjBFAaMHStTNgtCuSIR;

					public bool AdzCzQeWnZpTfNomlnlbVLKxqMWw(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[nvPgMJYNBpoPaACMJfNtdKyBYHj.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == KBzfyXGfCzjBFAaMHStTNgtCuSIR.sourceId;
					}
				}

				private sealed class CDFjlVkjqxzzbkhIktwMZKYaEpfI
				{
					public WYlMGhiLuAqCiRRmGdkLQKHjjDF nvPgMJYNBpoPaACMJfNtdKyBYHj;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int bKgRNMZoNfkYtHsWtkGguFjJhGW;

					public bool RZJPsADxOAlQffRYfEVPCJBJBjzF(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[nvPgMJYNBpoPaACMJfNtdKyBYHj.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == bKgRNMZoNfkYtHsWtkGguFjJhGW;
					}
				}

				private sealed class kfjleKQdqEJgFZTSGBcMJrYVINs
				{
					public WYlMGhiLuAqCiRRmGdkLQKHjjDF nvPgMJYNBpoPaACMJfNtdKyBYHj;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public int bKgRNMZoNfkYtHsWtkGguFjJhGW;

					public bool wTpkgvINrJFsJzGSSWlyihinTBl(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[nvPgMJYNBpoPaACMJfNtdKyBYHj.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == bKgRNMZoNfkYtHsWtkGguFjJhGW;
					}
				}

				public UserData gRDRgXbGFHkCfIifqpbBMdginMv;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> tDyxLfpxzsDadLjiPgcPeeQuTlL;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> xkRaJlcuoDIjvSgeKOvknuxViNp;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> nUiZhXqlPtUGheksVhWpGYpBFnU;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> KvwtjEanLLXWmHamSMVecXuBlQG;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> snOMnOlmvkDezcAuxuFnlcWlbIQ;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> kytObkGwzgvLrYMiTcWTTFmxMKe;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> YJMxRLhSEeYGjaKuskBsKZhKqnE;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> VARLJEkDLmZllvXviageIOtFdiK;

				public Func<ControllerType, List<mldQVwfGWMIYCEomGCSLdjMzMyJ>> ZdpDMsdjSwoSLYghOgszmvadivEK;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> jgMFPtVoIbUvhEiUCgCrShkJDYM;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> aSmnStzUGtGYGALilmPipsvcCKW;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> xhKmSgpbYFCpdjKZflCxouJewKGl;

				private static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> EqHAkSFfxFFwTBfNqoZJWcpUUeI;

				private static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> NjyzPExkhedSWdadKzxuHqSamRRR;

				public InputCategory LulffzXJjYXNaYXFzYCXOdCgYfr(cZLOdDIumDYkDZFvhYOclIrWViM<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputCategory inputCategory2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputCategory2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddActionCategory();
						inputCategory2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					inputCategory.id = inputCategory2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputCategory2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputCategory;
					return inputCategory;
				}

				public InputBehavior LurQbaRXAnTKNqPtmICXuOIZwUM(cZLOdDIumDYkDZFvhYOclIrWViM<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputBehavior inputBehavior2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputBehavior2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddInputBehavior();
						inputBehavior2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputBehavior2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputBehavior;
					return inputBehavior;
				}

				public InputAction OmSeFVGbGakIwAnOABBplTRtOfkP(cZLOdDIumDYkDZFvhYOclIrWViM<InputAction> P_0)
				{
					cBHDgLRluPwBZaAeFKDtzFOBhTf cBHDgLRluPwBZaAeFKDtzFOBhTf2 = new cBHDgLRluPwBZaAeFKDtzFOBhTf();
					cBHDgLRluPwBZaAeFKDtzFOBhTf2.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
					cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					InputAction inputAction = JsonTools.Clone(cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					int num = tDyxLfpxzsDadLjiPgcPeeQuTlL.Find(cBHDgLRluPwBZaAeFKDtzFOBhTf2.DuqjNzjQDGlnarbPpOUhtjLkFKt)?.sAKYwxELDKIrbyyslYnFomEqhKC ?? 0;
					InputAction inputAction2;
					if (cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputAction2 = cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddAction(num);
						inputAction2 = cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					int behaviorId = xkRaJlcuoDIjvSgeKOvknuxViNp.Find(cBHDgLRluPwBZaAeFKDtzFOBhTf2.ifcSIhBkcpVnYOaKwmQMswzStNg)?.sAKYwxELDKIrbyyslYnFomEqhKC ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = behaviorId;
					int index = cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputAction2);
					cBHDgLRluPwBZaAeFKDtzFOBhTf2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputAction;
					return inputAction;
				}

				public InputLayout GZeuQmXquecmWcTsIVdmmYfLJxL(cZLOdDIumDYkDZFvhYOclIrWViM<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputLayout inputLayout2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputLayout2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddKeyboardLayout();
						inputLayout2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputLayout2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout aEmHLVEBkedGRFpkTGDBgzKcOozB(cZLOdDIumDYkDZFvhYOclIrWViM<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputLayout inputLayout2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputLayout2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddMouseLayout();
						inputLayout2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputLayout2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout OfXFMQNgvImVjsTyLgNSxFKmNQl(cZLOdDIumDYkDZFvhYOclIrWViM<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputLayout inputLayout2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputLayout2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddJoystickLayout();
						inputLayout2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputLayout2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout YLmKyfFkMcRxjbHefigoswTcYuE(cZLOdDIumDYkDZFvhYOclIrWViM<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputLayout inputLayout2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputLayout2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddCustomControllerLayout();
						inputLayout2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputLayout2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = inputLayout;
					return inputLayout;
				}

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> FusGEChpklSqVAwNDTqGbQtJeqJ(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => snOMnOlmvkDezcAuxuFnlcWlbIQ, 
						ControllerType.Mouse => kytObkGwzgvLrYMiTcWTTFmxMKe, 
						ControllerType.Joystick => YJMxRLhSEeYGjaKuskBsKZhKqnE, 
						ControllerType.Custom => VARLJEkDLmZllvXviageIOtFdiK, 
						_ => throw new NotImplementedException(), 
					};
				}

				public CustomController_Editor ewpcLqHpwJkZtzAyNGAyFRFghWeJ(cZLOdDIumDYkDZFvhYOclIrWViM<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					CustomController_Editor customController_Editor2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						customController_Editor2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddCustomController();
						customController_Editor2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(customController_Editor2);
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = customController_Editor;
					return customController_Editor;
				}

				public ControllerMapLayoutManager_RuleSet_Editor HpKSxwxJjEjpgyYhdAxBpNvmRjb(cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					rWkvqnbVZTWtcXCvsFHQbvMnafR rWkvqnbVZTWtcXCvsFHQbvMnafR2 = new rWkvqnbVZTWtcXCvsFHQbvMnafR();
					rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					int num = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int i = 0; i < num; i++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[i];
						if (controllerMapLayoutManager_Rule_Editor == null || controllerMapLayoutManager_Rule_Editor.categoryIds == null)
						{
							continue;
						}
						List<int> list = new List<int>();
						int num2 = ((controllerMapLayoutManager_Rule_Editor.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor.categoryIds.Count : 0);
						for (int j = 0; j < num2; j++)
						{
							BpeGIYvHDmSPFAJXsKYhOvmgIJO bpeGIYvHDmSPFAJXsKYhOvmgIJO = new BpeGIYvHDmSPFAJXsKYhOvmgIJO();
							bpeGIYvHDmSPFAJXsKYhOvmgIJO.JjeGaGbZmToMdTpJsirDFoGwePn = rWkvqnbVZTWtcXCvsFHQbvMnafR2;
							bpeGIYvHDmSPFAJXsKYhOvmgIJO.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
							bpeGIYvHDmSPFAJXsKYhOvmgIJO.CVMSgLtooYEeCzscEbPbbmUKKAO = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = KvwtjEanLLXWmHamSMVecXuBlQG.Find(bpeGIYvHDmSPFAJXsKYhOvmgIJO.CKvwrkBZXYYKLGHERmXZtUDmDHi);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + bpeGIYvHDmSPFAJXsKYhOvmgIJO.CVMSgLtooYEeCzscEbPbbmUKKAO);
							}
							else
							{
								list.Add(mldQVwfGWMIYCEomGCSLdjMzMyJ2.sAKYwxELDKIrbyyslYnFomEqhKC);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						IKsjFndmZoFoYBgHSPGvabBbmawF ksjFndmZoFoYBgHSPGvabBbmawF = new IKsjFndmZoFoYBgHSPGvabBbmawF();
						ksjFndmZoFoYBgHSPGvabBbmawF.JjeGaGbZmToMdTpJsirDFoGwePn = rWkvqnbVZTWtcXCvsFHQbvMnafR2;
						ksjFndmZoFoYBgHSPGvabBbmawF.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list2 = ZdpDMsdjSwoSLYghOgszmvadivEK(controllerType);
							ksjFndmZoFoYBgHSPGvabBbmawF.CVMSgLtooYEeCzscEbPbbmUKKAO = controllerMapLayoutManager_Rule_Editor2.layoutId;
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = list2.Find(ksjFndmZoFoYBgHSPGvabBbmawF.wegRPZmPOfFPTzvLodBYBbvOzbo);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError(string.Concat("No new ", controllerType, " Layout Id found for old id: ", ksjFndmZoFoYBgHSPGvabBbmawF.CVMSgLtooYEeCzscEbPbbmUKKAO));
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 == null || controllerMapLayoutManager_Rule_Editor3.controllerSetSelector == null)
						{
							continue;
						}
						ControllerType controllerType2 = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType;
						if (controllerType2 == ControllerType.Custom)
						{
							AxhWHIqEljuNmYNyLNVvKJneDen axhWHIqEljuNmYNyLNVvKJneDen = new AxhWHIqEljuNmYNyLNVvKJneDen();
							axhWHIqEljuNmYNyLNVvKJneDen.JjeGaGbZmToMdTpJsirDFoGwePn = rWkvqnbVZTWtcXCvsFHQbvMnafR2;
							axhWHIqEljuNmYNyLNVvKJneDen.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
							List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list3 = jgMFPtVoIbUvhEiUCgCrShkJDYM;
							axhWHIqEljuNmYNyLNVvKJneDen.CVMSgLtooYEeCzscEbPbbmUKKAO = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = list3.Find(axhWHIqEljuNmYNyLNVvKJneDen.JeCGqNqsPUbQQyiXmDAMbOnotIcg);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + axhWHIqEljuNmYNyLNVvKJneDen.CVMSgLtooYEeCzscEbPbbmUKKAO);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = mldQVwfGWMIYCEomGCSLdjMzMyJ4.sAKYwxELDKIrbyyslYnFomEqhKC;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					rWkvqnbVZTWtcXCvsFHQbvMnafR2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				public ControllerMapEnabler_RuleSet_Editor rdkwqyVYbLouYAQJpDYUJEVMnon(cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					VQtMZgWajnlmbjKITukvJHPMUVx vQtMZgWajnlmbjKITukvJHPMUVx = new VQtMZgWajnlmbjKITukvJHPMUVx();
					vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					int num = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int i = 0; i < num; i++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[i];
						if (controllerMapEnabler_Rule_Editor == null || controllerMapEnabler_Rule_Editor.categoryIds == null)
						{
							continue;
						}
						List<int> list = new List<int>();
						for (int j = 0; j < controllerMapEnabler_Rule_Editor.categoryIds.Count; j++)
						{
							YBELCVWMfogEJcffaeOAFcuiEce yBELCVWMfogEJcffaeOAFcuiEce = new YBELCVWMfogEJcffaeOAFcuiEce();
							yBELCVWMfogEJcffaeOAFcuiEce.lyfRjOTQzmHxggJWIfUAKDYvxFW = vQtMZgWajnlmbjKITukvJHPMUVx;
							yBELCVWMfogEJcffaeOAFcuiEce.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
							yBELCVWMfogEJcffaeOAFcuiEce.CVMSgLtooYEeCzscEbPbbmUKKAO = controllerMapEnabler_Rule_Editor.categoryIds[j];
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = KvwtjEanLLXWmHamSMVecXuBlQG.Find(yBELCVWMfogEJcffaeOAFcuiEce.QuAbqaaJIrjyxJKEAYxTXMQXprJ);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + yBELCVWMfogEJcffaeOAFcuiEce.CVMSgLtooYEeCzscEbPbbmUKKAO);
							}
							else
							{
								list.Add(mldQVwfGWMIYCEomGCSLdjMzMyJ2.sAKYwxELDKIrbyyslYnFomEqhKC);
							}
						}
						controllerMapEnabler_Rule_Editor.categoryIds = list;
					}
					int num2 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num2; k++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[k];
						if (controllerMapEnabler_Rule_Editor2 == null || controllerMapEnabler_Rule_Editor2.layoutIds == null)
						{
							continue;
						}
						ControllerType controllerType = controllerMapEnabler_Rule_Editor2.controllerSetSelector.controllerType;
						List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list2 = ZdpDMsdjSwoSLYghOgszmvadivEK(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							pKTJRXJxeFIteOcPIACpgIFJVEQ pKTJRXJxeFIteOcPIACpgIFJVEQ2 = new pKTJRXJxeFIteOcPIACpgIFJVEQ();
							pKTJRXJxeFIteOcPIACpgIFJVEQ2.lyfRjOTQzmHxggJWIfUAKDYvxFW = vQtMZgWajnlmbjKITukvJHPMUVx;
							pKTJRXJxeFIteOcPIACpgIFJVEQ2.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
							pKTJRXJxeFIteOcPIACpgIFJVEQ2.CVMSgLtooYEeCzscEbPbbmUKKAO = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = list2.Find(pKTJRXJxeFIteOcPIACpgIFJVEQ2.niSRefSXHdAWFVJmvBKbgwbNPoa);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ3 == null)
							{
								Logger.LogError(string.Concat("No new ", controllerType, " Layout Id found for old id: ", pKTJRXJxeFIteOcPIACpgIFJVEQ2.CVMSgLtooYEeCzscEbPbbmUKKAO));
							}
							else
							{
								list3.Add(mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC);
							}
						}
						controllerMapEnabler_Rule_Editor2.layoutIds = list3;
					}
					int num4 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int m = 0; m < num4; m++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[m];
						if (controllerMapEnabler_Rule_Editor3 == null || controllerMapEnabler_Rule_Editor3.controllerSetSelector == null)
						{
							continue;
						}
						ControllerType controllerType2 = controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType;
						if (controllerType2 == ControllerType.Custom)
						{
							XuCfgvSqkvURJxAzwyviTiwbAyyf xuCfgvSqkvURJxAzwyviTiwbAyyf = new XuCfgvSqkvURJxAzwyviTiwbAyyf();
							xuCfgvSqkvURJxAzwyviTiwbAyyf.lyfRjOTQzmHxggJWIfUAKDYvxFW = vQtMZgWajnlmbjKITukvJHPMUVx;
							xuCfgvSqkvURJxAzwyviTiwbAyyf.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
							List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list4 = jgMFPtVoIbUvhEiUCgCrShkJDYM;
							xuCfgvSqkvURJxAzwyviTiwbAyyf.CVMSgLtooYEeCzscEbPbbmUKKAO = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = list4.Find(xuCfgvSqkvURJxAzwyviTiwbAyyf.EMoFZGbNkMqZFKaCvgiviBAFFmpl);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + xuCfgvSqkvURJxAzwyviTiwbAyyf.CVMSgLtooYEeCzscEbPbbmUKKAO);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = mldQVwfGWMIYCEomGCSLdjMzMyJ4.sAKYwxELDKIrbyyslYnFomEqhKC;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						controllerMapEnabler_RuleSet_Editor2 = vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					vQtMZgWajnlmbjKITukvJHPMUVx.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				public Player_Editor sLHYnUnADkIwzYhHyuEoajaHRWD(cZLOdDIumDYkDZFvhYOclIrWViM<Player_Editor> P_0)
				{
					WYlMGhiLuAqCiRRmGdkLQKHjjDF wYlMGhiLuAqCiRRmGdkLQKHjjDF = new WYlMGhiLuAqCiRRmGdkLQKHjjDF();
					wYlMGhiLuAqCiRRmGdkLQKHjjDF.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
					wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					Player_Editor player_Editor = JsonTools.Clone(wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					Action<List<Player_Editor.Mapping>, List<mldQVwfGWMIYCEomGCSLdjMzMyJ>> action = wYlMGhiLuAqCiRRmGdkLQKHjjDF.BADHeEMplLDFAKnOwSEAdcleOtu;
					action(player_Editor.defaultKeyboardMaps, snOMnOlmvkDezcAuxuFnlcWlbIQ);
					action(player_Editor.defaultMouseMaps, kytObkGwzgvLrYMiTcWTTFmxMKe);
					action(player_Editor.defaultJoystickMaps, YJMxRLhSEeYGjaKuskBsKZhKqnE);
					action(player_Editor.defaultCustomControllerMaps, VARLJEkDLmZllvXviageIOtFdiK);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						FkgGAxjJPgbWugEvRfxYIZdNmrRe fkgGAxjJPgbWugEvRfxYIZdNmrRe = new FkgGAxjJPgbWugEvRfxYIZdNmrRe();
						fkgGAxjJPgbWugEvRfxYIZdNmrRe.nvPgMJYNBpoPaACMJfNtdKyBYHj = wYlMGhiLuAqCiRRmGdkLQKHjjDF;
						fkgGAxjJPgbWugEvRfxYIZdNmrRe.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
						fkgGAxjJPgbWugEvRfxYIZdNmrRe.KBzfyXGfCzjBFAaMHStTNgtCuSIR = player_Editor.startingCustomControllers[i];
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = jgMFPtVoIbUvhEiUCgCrShkJDYM.Find(fkgGAxjJPgbWugEvRfxYIZdNmrRe.AdzCzQeWnZpTfNomlnlbVLKxqMWw);
						fkgGAxjJPgbWugEvRfxYIZdNmrRe.KBzfyXGfCzjBFAaMHStTNgtCuSIR.sourceId = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						CDFjlVkjqxzzbkhIktwMZKYaEpfI cDFjlVkjqxzzbkhIktwMZKYaEpfI = new CDFjlVkjqxzzbkhIktwMZKYaEpfI();
						cDFjlVkjqxzzbkhIktwMZKYaEpfI.nvPgMJYNBpoPaACMJfNtdKyBYHj = wYlMGhiLuAqCiRRmGdkLQKHjjDF;
						cDFjlVkjqxzzbkhIktwMZKYaEpfI.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							cDFjlVkjqxzzbkhIktwMZKYaEpfI.bKgRNMZoNfkYtHsWtkGguFjJhGW = ruleSetMapping.id;
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = aSmnStzUGtGYGALilmPipsvcCKW.Find(cDFjlVkjqxzzbkhIktwMZKYaEpfI.RZJPsADxOAlQffRYfEVPCJBJBjzF);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + cDFjlVkjqxzzbkhIktwMZKYaEpfI.bKgRNMZoNfkYtHsWtkGguFjJhGW);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						kfjleKQdqEJgFZTSGBcMJrYVINs kfjleKQdqEJgFZTSGBcMJrYVINs2 = new kfjleKQdqEJgFZTSGBcMJrYVINs();
						kfjleKQdqEJgFZTSGBcMJrYVINs2.nvPgMJYNBpoPaACMJfNtdKyBYHj = wYlMGhiLuAqCiRRmGdkLQKHjjDF;
						kfjleKQdqEJgFZTSGBcMJrYVINs2.mZFtphVMrjsiRjFTsSjaTADAHlg = this;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							kfjleKQdqEJgFZTSGBcMJrYVINs2.bKgRNMZoNfkYtHsWtkGguFjJhGW = ruleSetMapping2.id;
							mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = xhKmSgpbYFCpdjKZflCxouJewKGl.Find(kfjleKQdqEJgFZTSGBcMJrYVINs2.wTpkgvINrJFsJzGSSWlyihinTBl);
							if (mldQVwfGWMIYCEomGCSLdjMzMyJ4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + kfjleKQdqEJgFZTSGBcMJrYVINs2.bKgRNMZoNfkYtHsWtkGguFjJhGW);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = mldQVwfGWMIYCEomGCSLdjMzMyJ4.sAKYwxELDKIrbyyslYnFomEqhKC;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						player_Editor2 = wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						if (EqHAkSFfxFFwTBfNqoZJWcpUUeI == null)
						{
							EqHAkSFfxFFwTBfNqoZJWcpUUeI = HtzGwmHdyfbAORBXfwDOkVxlaSO;
						}
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> eqHAkSFfxFFwTBfNqoZJWcpUUeI = EqHAkSFfxFFwTBfNqoZJWcpUUeI;
						duhcImKyPISwVLglzTGsujUtNQSa(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, eqHAkSFfxFFwTBfNqoZJWcpUUeI);
						duhcImKyPISwVLglzTGsujUtNQSa(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, eqHAkSFfxFFwTBfNqoZJWcpUUeI);
						duhcImKyPISwVLglzTGsujUtNQSa(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, eqHAkSFfxFFwTBfNqoZJWcpUUeI);
						duhcImKyPISwVLglzTGsujUtNQSa(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, eqHAkSFfxFFwTBfNqoZJWcpUUeI);
						List<Player_Editor.CreateControllerInfo> startingCustomControllers = player_Editor2.startingCustomControllers;
						List<Player_Editor.CreateControllerInfo> startingCustomControllers2 = player_Editor.startingCustomControllers;
						List<Player_Editor.CreateControllerInfo> startingCustomControllers3 = player_Editor3.startingCustomControllers;
						if (NjyzPExkhedSWdadKzxuHqSamRRR == null)
						{
							NjyzPExkhedSWdadKzxuHqSamRRR = wdnOlNkVaExFYNzpdfIdvadQEXf;
						}
						duhcImKyPISwVLglzTGsujUtNQSa(startingCustomControllers, startingCustomControllers2, startingCustomControllers3, NjyzPExkhedSWdadKzxuHqSamRRR);
						player_Editor = player_Editor3;
					}
					else
					{
						gRDRgXbGFHkCfIifqpbBMdginMv.AddPlayer();
						player_Editor2 = wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(player_Editor2);
					wYlMGhiLuAqCiRRmGdkLQKHjjDF.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = player_Editor;
					return player_Editor;
				}

				private static int HtzGwmHdyfbAORBXfwDOkVxlaSO(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i].categoryId == P_0.categoryId && P_1[i].layoutId == P_0.layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				private static int wdnOlNkVaExFYNzpdfIdvadQEXf(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i].sourceId == P_0.sourceId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class aJOFKAgCzaaECtjxOPXsnCjwnxf
			{
				public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

				public List<int> DaqqrdJsatePmJWwCyYdPPNZMgLW;

				public InputMapCategory tFSTlNXJbuniCgdUIrJizbGucUN(cZLOdDIumDYkDZFvhYOclIrWViM<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					InputMapCategory inputMapCategory2;
					if (P_0.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						inputMapCategory2 = P_0.gpPKZjURlbtJeQNirBHucjPQfJDA;
					}
					else
					{
						mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.AddMapCategory();
						inputMapCategory2 = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					int num = P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(inputMapCategory2);
					if (P_0.rGJPsZGmchUwIUleWWPNJcpgFgS == mldQVwfGWMIYCEomGCSLdjMzMyJ.rmfvGWjDzfhrPmVBdBvIgIDcWAr.JVXBRqfXueiCkTMNcKBxQjoHwfxP)
					{
						DaqqrdJsatePmJWwCyYdPPNZMgLW.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.EAOJWPvuzZdSUfZJKFFDodDeqqg[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class VrOUddvBFEmTPbrFeieFjOAYFUma
			{
				public aJOFKAgCzaaECtjxOPXsnCjwnxf WSkFsITrZoSoDIVkSTKrtQVRSOq;

				public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

				public int JVXBRqfXueiCkTMNcKBxQjoHwfxP;

				public bool HcKCPoDXYneQjFTFNGBluMlhWkH(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
				{
					return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == JVXBRqfXueiCkTMNcKBxQjoHwfxP;
				}
			}

			private sealed class tFlXIQOMZWVNVtOMElLckbeHYJi
			{
				private sealed class OUUReqAnOYQrHknKLyjLwQzyMyR
				{
					public tFlXIQOMZWVNVtOMElLckbeHYJi evRjwkKaCqKcFkPknEOwbzDKrWt;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor KBzfyXGfCzjBFAaMHStTNgtCuSIR;

					public bool iUwecjdrArvaXUtahufWkMnpbbEi(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.categoryId;
					}

					public bool SbTRvOlaLxiKjysimYeiPiwsRIs(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.layoutId;
					}
				}

				private sealed class sRjOZhbtyApWJZkHWBGPZmszdKNG
				{
					public tFlXIQOMZWVNVtOMElLckbeHYJi evRjwkKaCqKcFkPknEOwbzDKrWt;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor lheHhijiDZqMdQbJbplIfCFRQFB;

					public cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;

					public bool nQoerFkrjNehgwcLvuJzyWEOSnK(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.categoryId;
					}

					public bool HcWmOAvJITVwnbcBxrFiJvTJXYr(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.layoutId;
					}
				}

				private sealed class tgYNrGpIfuHbpEUPvlqGFrjvbrr
				{
					public sRjOZhbtyApWJZkHWBGPZmszdKNG inqUFavcKeXTAOYJKpKLoXsOtHR;

					public tFlXIQOMZWVNVtOMElLckbeHYJi evRjwkKaCqKcFkPknEOwbzDKrWt;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ActionElementMap sCZiujcEtiokSidOXBUYOQmKEdNw;

					public bool wJNlIQTJcqEawhqKPMgdqVqhaS(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[inqUFavcKeXTAOYJKpKLoXsOtHR.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == sCZiujcEtiokSidOXBUYOQmKEdNw._actionId;
					}
				}

				public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> KPYjKRXyilgdPcHiMorMqUSshOW;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> cylgNKCoaNHJrLyajnCYQwMUtaf;

				public int RBoIAFupcaTpbUJtsWqeOobelta(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					OUUReqAnOYQrHknKLyjLwQzyMyR oUUReqAnOYQrHknKLyjLwQzyMyR = new OUUReqAnOYQrHknKLyjLwQzyMyR();
					oUUReqAnOYQrHknKLyjLwQzyMyR.evRjwkKaCqKcFkPknEOwbzDKrWt = this;
					oUUReqAnOYQrHknKLyjLwQzyMyR.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					oUUReqAnOYQrHknKLyjLwQzyMyR.KBzfyXGfCzjBFAaMHStTNgtCuSIR = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(oUUReqAnOYQrHknKLyjLwQzyMyR.iUwecjdrArvaXUtahufWkMnpbbEi);
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(oUUReqAnOYQrHknKLyjLwQzyMyR.SbTRvOlaLxiKjysimYeiPiwsRIs);
						if (mldQVwfGWMIYCEomGCSLdjMzMyJ2 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ2.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].categoryId && mldQVwfGWMIYCEomGCSLdjMzMyJ3 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor iLzAhxhbirHSBxGtcTxtgtkLsNr(cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> P_0)
				{
					sRjOZhbtyApWJZkHWBGPZmszdKNG sRjOZhbtyApWJZkHWBGPZmszdKNG2 = new sRjOZhbtyApWJZkHWBGPZmszdKNG();
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.evRjwkKaCqKcFkPknEOwbzDKrWt = this;
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB = JsonTools.Clone(sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(sRjOZhbtyApWJZkHWBGPZmszdKNG2.nQoerFkrjNehgwcLvuJzyWEOSnK);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(sRjOZhbtyApWJZkHWBGPZmszdKNG2.HcWmOAvJITVwnbcBxrFiJvTJXYr);
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId = mldQVwfGWMIYCEomGCSLdjMzMyJ3?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					for (int i = 0; i < sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps.Count; i++)
					{
						tgYNrGpIfuHbpEUPvlqGFrjvbrr tgYNrGpIfuHbpEUPvlqGFrjvbrr2 = new tgYNrGpIfuHbpEUPvlqGFrjvbrr();
						tgYNrGpIfuHbpEUPvlqGFrjvbrr2.inqUFavcKeXTAOYJKpKLoXsOtHR = sRjOZhbtyApWJZkHWBGPZmszdKNG2;
						tgYNrGpIfuHbpEUPvlqGFrjvbrr2.evRjwkKaCqKcFkPknEOwbzDKrWt = this;
						tgYNrGpIfuHbpEUPvlqGFrjvbrr2.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
						tgYNrGpIfuHbpEUPvlqGFrjvbrr2.sCZiujcEtiokSidOXBUYOQmKEdNw = sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps[i];
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = mZFtphVMrjsiRjFTsSjaTADAHlg.nUiZhXqlPtUGheksVhWpGYpBFnU.Find(tgYNrGpIfuHbpEUPvlqGFrjvbrr2.wJNlIQTJcqEawhqKPMgdqVqhaS);
						tgYNrGpIfuHbpEUPvlqGFrjvbrr2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId = mldQVwfGWMIYCEomGCSLdjMzMyJ4?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
						tgYNrGpIfuHbpEUPvlqGFrjvbrr2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionCategoryId = ((mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(tgYNrGpIfuHbpEUPvlqGFrjvbrr2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId) != null) ? mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(tgYNrGpIfuHbpEUPvlqGFrjvbrr2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						controllerMap_Editor = sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (cylgNKCoaNHJrLyajnCYQwMUtaf == null)
						{
							cylgNKCoaNHJrLyajnCYQwMUtaf = OlLaPgcXgWBelomdmMovEbDDmfkj;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> func = cylgNKCoaNHJrLyajnCYQwMUtaf;
						duhcImKyPISwVLglzTGsujUtNQSa(controllerMap_Editor.actionElementMaps, sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB = controllerMap_Editor2;
					}
					else
					{
						mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.CreateKeyboardMap(sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId, sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId);
						controllerMap_Editor = sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB.id = controllerMap_Editor.id;
					int index = sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(controllerMap_Editor);
					sRjOZhbtyApWJZkHWBGPZmszdKNG2.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB;
					return sRjOZhbtyApWJZkHWBGPZmszdKNG2.lheHhijiDZqMdQbJbplIfCFRQFB;
				}

				private static int OlLaPgcXgWBelomdmMovEbDDmfkj(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._keyboardKeyCode == P_0._keyboardKeyCode && P_1[i]._modifierKey1 == P_0._modifierKey1 && P_1[i]._modifierKey2 == P_0._modifierKey2 && P_1[i]._modifierKey3 == P_0._modifierKey3 && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class IsHWdJPRYUHPZwYebreaBnrqGNN
			{
				private sealed class GGAyffXTfkcGFYWvwyEPlzCqhsv
				{
					public IsHWdJPRYUHPZwYebreaBnrqGNN UCecuqRhgVepgqGzdoLRBgSTvGt;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor KBzfyXGfCzjBFAaMHStTNgtCuSIR;

					public bool cuYUXPmkVsHuDYjhWvCRKkVTIAH(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.categoryId;
					}

					public bool bgvKMvQGpOypxEtXBihZxTviKED(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.layoutId;
					}
				}

				private sealed class UblGhXABRKifyUeYTMCqwAxsNfQL
				{
					public IsHWdJPRYUHPZwYebreaBnrqGNN UCecuqRhgVepgqGzdoLRBgSTvGt;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor lheHhijiDZqMdQbJbplIfCFRQFB;

					public cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;

					public bool whUdxKWPFHrlYekhDyimrxiAfgJ(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.categoryId;
					}

					public bool pAHrSvOkboiwqLOJJOkCdfLFmLl(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.layoutId;
					}
				}

				private sealed class wssddaIAaXEIdYqVBUbBpuXklcm
				{
					public UblGhXABRKifyUeYTMCqwAxsNfQL KBigbVAOCnAxogCTgIVjmGgeDDl;

					public IsHWdJPRYUHPZwYebreaBnrqGNN UCecuqRhgVepgqGzdoLRBgSTvGt;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ActionElementMap sCZiujcEtiokSidOXBUYOQmKEdNw;

					public bool qohmUUNoxCLLbTCtywswHGiprxK(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[KBigbVAOCnAxogCTgIVjmGgeDDl.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == sCZiujcEtiokSidOXBUYOQmKEdNw._actionId;
					}
				}

				public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> KPYjKRXyilgdPcHiMorMqUSshOW;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> EAqliribGnUsjzqSaRkyJlytmju;

				public int TrSRssrdrCyfSJegernuXDfbZaJ(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					GGAyffXTfkcGFYWvwyEPlzCqhsv gGAyffXTfkcGFYWvwyEPlzCqhsv = new GGAyffXTfkcGFYWvwyEPlzCqhsv();
					gGAyffXTfkcGFYWvwyEPlzCqhsv.UCecuqRhgVepgqGzdoLRBgSTvGt = this;
					gGAyffXTfkcGFYWvwyEPlzCqhsv.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					gGAyffXTfkcGFYWvwyEPlzCqhsv.KBzfyXGfCzjBFAaMHStTNgtCuSIR = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(gGAyffXTfkcGFYWvwyEPlzCqhsv.cuYUXPmkVsHuDYjhWvCRKkVTIAH);
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(gGAyffXTfkcGFYWvwyEPlzCqhsv.bgvKMvQGpOypxEtXBihZxTviKED);
						if (mldQVwfGWMIYCEomGCSLdjMzMyJ2 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ2.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].categoryId && mldQVwfGWMIYCEomGCSLdjMzMyJ3 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor HUFDavIqPYkkDNoBoQshiiPxuCa(cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> P_0)
				{
					UblGhXABRKifyUeYTMCqwAxsNfQL ublGhXABRKifyUeYTMCqwAxsNfQL = new UblGhXABRKifyUeYTMCqwAxsNfQL();
					ublGhXABRKifyUeYTMCqwAxsNfQL.UCecuqRhgVepgqGzdoLRBgSTvGt = this;
					ublGhXABRKifyUeYTMCqwAxsNfQL.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB = JsonTools.Clone(ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(ublGhXABRKifyUeYTMCqwAxsNfQL.whUdxKWPFHrlYekhDyimrxiAfgJ);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(ublGhXABRKifyUeYTMCqwAxsNfQL.pAHrSvOkboiwqLOJJOkCdfLFmLl);
					ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId = mldQVwfGWMIYCEomGCSLdjMzMyJ3?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					for (int i = 0; i < ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps.Count; i++)
					{
						wssddaIAaXEIdYqVBUbBpuXklcm wssddaIAaXEIdYqVBUbBpuXklcm2 = new wssddaIAaXEIdYqVBUbBpuXklcm();
						wssddaIAaXEIdYqVBUbBpuXklcm2.KBigbVAOCnAxogCTgIVjmGgeDDl = ublGhXABRKifyUeYTMCqwAxsNfQL;
						wssddaIAaXEIdYqVBUbBpuXklcm2.UCecuqRhgVepgqGzdoLRBgSTvGt = this;
						wssddaIAaXEIdYqVBUbBpuXklcm2.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
						wssddaIAaXEIdYqVBUbBpuXklcm2.sCZiujcEtiokSidOXBUYOQmKEdNw = ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps[i];
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = mZFtphVMrjsiRjFTsSjaTADAHlg.nUiZhXqlPtUGheksVhWpGYpBFnU.Find(wssddaIAaXEIdYqVBUbBpuXklcm2.qohmUUNoxCLLbTCtywswHGiprxK);
						wssddaIAaXEIdYqVBUbBpuXklcm2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId = mldQVwfGWMIYCEomGCSLdjMzMyJ4?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
						wssddaIAaXEIdYqVBUbBpuXklcm2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionCategoryId = ((mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(wssddaIAaXEIdYqVBUbBpuXklcm2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId) != null) ? mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(wssddaIAaXEIdYqVBUbBpuXklcm2.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						controllerMap_Editor = ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (EAqliribGnUsjzqSaRkyJlytmju == null)
						{
							EAqliribGnUsjzqSaRkyJlytmju = TbMvPkGUpbiiduDZysbfFmVvPrH;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> eAqliribGnUsjzqSaRkyJlytmju = EAqliribGnUsjzqSaRkyJlytmju;
						duhcImKyPISwVLglzTGsujUtNQSa(controllerMap_Editor.actionElementMaps, ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps, controllerMap_Editor2.actionElementMaps, eAqliribGnUsjzqSaRkyJlytmju);
						ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB = controllerMap_Editor2;
					}
					else
					{
						mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.CreateMouseMap(ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId, ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId);
						controllerMap_Editor = ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB.id = controllerMap_Editor.id;
					int index = ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(controllerMap_Editor);
					ublGhXABRKifyUeYTMCqwAxsNfQL.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB;
					return ublGhXABRKifyUeYTMCqwAxsNfQL.lheHhijiDZqMdQbJbplIfCFRQFB;
				}

				private static int TbMvPkGUpbiiduDZysbfFmVvPrH(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class zNGsfbyOIZKuxTcqneYkEqNEAoL
			{
				private sealed class JSBcMctJhWHDqxycxGddOjIUeyq
				{
					public zNGsfbyOIZKuxTcqneYkEqNEAoL xDEpaIeRbsOfyVbEIwpgCPuoHuu;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor KBzfyXGfCzjBFAaMHStTNgtCuSIR;

					public bool TkYaGffdsRCOFBhZUhaycGSbaTG(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.categoryId;
					}

					public bool bLLlYPRLXAsUUMBgQUZmjArvQPY(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.layoutId;
					}
				}

				private sealed class PxBUeYRjzckyvgoYbWiJXdLEctM
				{
					public zNGsfbyOIZKuxTcqneYkEqNEAoL xDEpaIeRbsOfyVbEIwpgCPuoHuu;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor lheHhijiDZqMdQbJbplIfCFRQFB;

					public cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;

					public bool ebNHUzkNmtDfRdPCASGqebfjUMWk(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.categoryId;
					}

					public bool PbsjtVDSTFoyYprRTeozcinKGKvG(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.layoutId;
					}
				}

				private sealed class CIumiqoWwzQEknIQhILSZWhQsLR
				{
					public PxBUeYRjzckyvgoYbWiJXdLEctM mDzJjXviBVdzGNXUUVTyiOmHrcz;

					public zNGsfbyOIZKuxTcqneYkEqNEAoL xDEpaIeRbsOfyVbEIwpgCPuoHuu;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ActionElementMap sCZiujcEtiokSidOXBUYOQmKEdNw;

					public bool SWkKOPdkLhGkQkYMihJcoDZsLpKA(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[mDzJjXviBVdzGNXUUVTyiOmHrcz.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == sCZiujcEtiokSidOXBUYOQmKEdNw._actionId;
					}
				}

				public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> KPYjKRXyilgdPcHiMorMqUSshOW;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> PFGgyLAcWmkLkNLVoYDFHPbNkWHC;

				public int RoJbqYgPrTsFPtjFcnoeONpKCpnI(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					JSBcMctJhWHDqxycxGddOjIUeyq jSBcMctJhWHDqxycxGddOjIUeyq = new JSBcMctJhWHDqxycxGddOjIUeyq();
					jSBcMctJhWHDqxycxGddOjIUeyq.xDEpaIeRbsOfyVbEIwpgCPuoHuu = this;
					jSBcMctJhWHDqxycxGddOjIUeyq.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					jSBcMctJhWHDqxycxGddOjIUeyq.KBzfyXGfCzjBFAaMHStTNgtCuSIR = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(jSBcMctJhWHDqxycxGddOjIUeyq.TkYaGffdsRCOFBhZUhaycGSbaTG);
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(jSBcMctJhWHDqxycxGddOjIUeyq.bLLlYPRLXAsUUMBgQUZmjArvQPY);
						if (jSBcMctJhWHDqxycxGddOjIUeyq.KBzfyXGfCzjBFAaMHStTNgtCuSIR.hardwareGuid == P_1[i].hardwareGuid && mldQVwfGWMIYCEomGCSLdjMzMyJ2 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ2.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].categoryId && mldQVwfGWMIYCEomGCSLdjMzMyJ3 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor FdjHTFambroYmaCeHoyxTIEhKXOe(cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> P_0)
				{
					PxBUeYRjzckyvgoYbWiJXdLEctM pxBUeYRjzckyvgoYbWiJXdLEctM = new PxBUeYRjzckyvgoYbWiJXdLEctM();
					pxBUeYRjzckyvgoYbWiJXdLEctM.xDEpaIeRbsOfyVbEIwpgCPuoHuu = this;
					pxBUeYRjzckyvgoYbWiJXdLEctM.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB = JsonTools.Clone(pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(pxBUeYRjzckyvgoYbWiJXdLEctM.ebNHUzkNmtDfRdPCASGqebfjUMWk);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(pxBUeYRjzckyvgoYbWiJXdLEctM.PbsjtVDSTFoyYprRTeozcinKGKvG);
					pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId = mldQVwfGWMIYCEomGCSLdjMzMyJ3?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					for (int i = 0; i < pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps.Count; i++)
					{
						CIumiqoWwzQEknIQhILSZWhQsLR cIumiqoWwzQEknIQhILSZWhQsLR = new CIumiqoWwzQEknIQhILSZWhQsLR();
						cIumiqoWwzQEknIQhILSZWhQsLR.mDzJjXviBVdzGNXUUVTyiOmHrcz = pxBUeYRjzckyvgoYbWiJXdLEctM;
						cIumiqoWwzQEknIQhILSZWhQsLR.xDEpaIeRbsOfyVbEIwpgCPuoHuu = this;
						cIumiqoWwzQEknIQhILSZWhQsLR.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
						cIumiqoWwzQEknIQhILSZWhQsLR.sCZiujcEtiokSidOXBUYOQmKEdNw = pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps[i];
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = mZFtphVMrjsiRjFTsSjaTADAHlg.nUiZhXqlPtUGheksVhWpGYpBFnU.Find(cIumiqoWwzQEknIQhILSZWhQsLR.SWkKOPdkLhGkQkYMihJcoDZsLpKA);
						cIumiqoWwzQEknIQhILSZWhQsLR.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId = mldQVwfGWMIYCEomGCSLdjMzMyJ4?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
						cIumiqoWwzQEknIQhILSZWhQsLR.sCZiujcEtiokSidOXBUYOQmKEdNw._actionCategoryId = ((mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(cIumiqoWwzQEknIQhILSZWhQsLR.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId) != null) ? mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(cIumiqoWwzQEknIQhILSZWhQsLR.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						controllerMap_Editor = pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (PFGgyLAcWmkLkNLVoYDFHPbNkWHC == null)
						{
							PFGgyLAcWmkLkNLVoYDFHPbNkWHC = oJSLeHGHjIYKLfemfgjqxcctFgHh;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> pFGgyLAcWmkLkNLVoYDFHPbNkWHC = PFGgyLAcWmkLkNLVoYDFHPbNkWHC;
						duhcImKyPISwVLglzTGsujUtNQSa(controllerMap_Editor.actionElementMaps, pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps, controllerMap_Editor2.actionElementMaps, pFGgyLAcWmkLkNLVoYDFHPbNkWHC);
						pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB = controllerMap_Editor2;
					}
					else
					{
						mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.CreateJoystickMap(pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId, pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.hardwareGuid, pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId);
						controllerMap_Editor = pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB.id = controllerMap_Editor.id;
					int index = pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(controllerMap_Editor);
					pxBUeYRjzckyvgoYbWiJXdLEctM.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB;
					return pxBUeYRjzckyvgoYbWiJXdLEctM.lheHhijiDZqMdQbJbplIfCFRQFB;
				}

				private static int oJSLeHGHjIYKLfemfgjqxcctFgHh(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class ZVefcEmQQUlaTTGbHkrNHIHQHki
			{
				private sealed class wmvoVZJNqUVXXlIjVjOFKzLxnBW
				{
					public ZVefcEmQQUlaTTGbHkrNHIHQHki DqDdYGlfIArQvfmgStXVkRGejGh;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor KBzfyXGfCzjBFAaMHStTNgtCuSIR;

					public bool UuRMOpeMZENqSoLoYzFWSKvPVcU(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.customControllerUid;
					}

					public bool lUIBuRIIhdHPbHwLCPMKtYKzGgHb(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.categoryId;
					}

					public bool GFXSaMUOqGUcAprpiaiPgNPtSvF(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0.JVXBRqfXueiCkTMNcKBxQjoHwfxP == KBzfyXGfCzjBFAaMHStTNgtCuSIR.layoutId;
					}
				}

				private sealed class FeROfEzVzcZSyMFROljzktXJDLI
				{
					public ZVefcEmQQUlaTTGbHkrNHIHQHki DqDdYGlfIArQvfmgStXVkRGejGh;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ControllerMap_Editor lheHhijiDZqMdQbJbplIfCFRQFB;

					public cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> krbfVTDEmdCGfHJdGtNodlokSfiE;

					public bool XaTpRuVkdowANWpNJJgMhLdradE(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.customControllerUid;
					}

					public bool XzgGwoHMJbfPWeasDmiIxSOKoGYq(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.categoryId;
					}

					public bool zcCagreNHJVREEAFbdfCHCdBHki(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == lheHhijiDZqMdQbJbplIfCFRQFB.layoutId;
					}
				}

				private sealed class UKEPpRuvYhOhOcCwlVSBfEjYtHu
				{
					public FeROfEzVzcZSyMFROljzktXJDLI lykLLyTXLPQsydesbZFrUpkfrUG;

					public ZVefcEmQQUlaTTGbHkrNHIHQHki DqDdYGlfIArQvfmgStXVkRGejGh;

					public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

					public ActionElementMap sCZiujcEtiokSidOXBUYOQmKEdNw;

					public bool WxHccnxjeyyzgioofJBvfxrPMsa(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
					{
						return P_0[lykLLyTXLPQsydesbZFrUpkfrUG.krbfVTDEmdCGfHJdGtNodlokSfiE.rGJPsZGmchUwIUleWWPNJcpgFgS] == sCZiujcEtiokSidOXBUYOQmKEdNw._actionId;
					}
				}

				public WFbHeUEVPiMzIiIbTldTTILXvbSe mZFtphVMrjsiRjFTsSjaTADAHlg;

				public List<mldQVwfGWMIYCEomGCSLdjMzMyJ> KPYjKRXyilgdPcHiMorMqUSshOW;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> WkrerUHXmifzdMIxnlGxDixyEBDt;

				public int aTrcaopZUxTaRoAYRYRToQZelrE(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					wmvoVZJNqUVXXlIjVjOFKzLxnBW wmvoVZJNqUVXXlIjVjOFKzLxnBW2 = new wmvoVZJNqUVXXlIjVjOFKzLxnBW();
					wmvoVZJNqUVXXlIjVjOFKzLxnBW2.DqDdYGlfIArQvfmgStXVkRGejGh = this;
					wmvoVZJNqUVXXlIjVjOFKzLxnBW2.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					wmvoVZJNqUVXXlIjVjOFKzLxnBW2.KBzfyXGfCzjBFAaMHStTNgtCuSIR = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.jgMFPtVoIbUvhEiUCgCrShkJDYM.Find(wmvoVZJNqUVXXlIjVjOFKzLxnBW2.UuRMOpeMZENqSoLoYzFWSKvPVcU);
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(wmvoVZJNqUVXXlIjVjOFKzLxnBW2.lUIBuRIIhdHPbHwLCPMKtYKzGgHb);
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(wmvoVZJNqUVXXlIjVjOFKzLxnBW2.GFXSaMUOqGUcAprpiaiPgNPtSvF);
						if (mldQVwfGWMIYCEomGCSLdjMzMyJ2 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ2.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].customControllerUid && mldQVwfGWMIYCEomGCSLdjMzMyJ3 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ3.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].categoryId && mldQVwfGWMIYCEomGCSLdjMzMyJ4 != null && mldQVwfGWMIYCEomGCSLdjMzMyJ4.sAKYwxELDKIrbyyslYnFomEqhKC == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor MpaTMWnzTZinqscnCcOOCggbzRS(cZLOdDIumDYkDZFvhYOclIrWViM<ControllerMap_Editor> P_0)
				{
					FeROfEzVzcZSyMFROljzktXJDLI feROfEzVzcZSyMFROljzktXJDLI = new FeROfEzVzcZSyMFROljzktXJDLI();
					feROfEzVzcZSyMFROljzktXJDLI.DqDdYGlfIArQvfmgStXVkRGejGh = this;
					feROfEzVzcZSyMFROljzktXJDLI.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
					feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE = P_0;
					feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB = JsonTools.Clone(feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.pvWFxzKxnLSsVUfuhbHEklmKEkfe);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = mZFtphVMrjsiRjFTsSjaTADAHlg.jgMFPtVoIbUvhEiUCgCrShkJDYM.Find(feROfEzVzcZSyMFROljzktXJDLI.XaTpRuVkdowANWpNJJgMhLdradE);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ3 = mZFtphVMrjsiRjFTsSjaTADAHlg.KvwtjEanLLXWmHamSMVecXuBlQG.Find(feROfEzVzcZSyMFROljzktXJDLI.XzgGwoHMJbfPWeasDmiIxSOKoGYq);
					mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ4 = KPYjKRXyilgdPcHiMorMqUSshOW.Find(feROfEzVzcZSyMFROljzktXJDLI.zcCagreNHJVREEAFbdfCHCdBHki);
					feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.customControllerUid = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId = mldQVwfGWMIYCEomGCSLdjMzMyJ3?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId = mldQVwfGWMIYCEomGCSLdjMzMyJ4?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					for (int i = 0; i < feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps.Count; i++)
					{
						UKEPpRuvYhOhOcCwlVSBfEjYtHu uKEPpRuvYhOhOcCwlVSBfEjYtHu = new UKEPpRuvYhOhOcCwlVSBfEjYtHu();
						uKEPpRuvYhOhOcCwlVSBfEjYtHu.lykLLyTXLPQsydesbZFrUpkfrUG = feROfEzVzcZSyMFROljzktXJDLI;
						uKEPpRuvYhOhOcCwlVSBfEjYtHu.DqDdYGlfIArQvfmgStXVkRGejGh = this;
						uKEPpRuvYhOhOcCwlVSBfEjYtHu.mZFtphVMrjsiRjFTsSjaTADAHlg = mZFtphVMrjsiRjFTsSjaTADAHlg;
						uKEPpRuvYhOhOcCwlVSBfEjYtHu.sCZiujcEtiokSidOXBUYOQmKEdNw = feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps[i];
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ5 = mZFtphVMrjsiRjFTsSjaTADAHlg.nUiZhXqlPtUGheksVhWpGYpBFnU.Find(uKEPpRuvYhOhOcCwlVSBfEjYtHu.WxHccnxjeyyzgioofJBvfxrPMsa);
						uKEPpRuvYhOhOcCwlVSBfEjYtHu.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId = mldQVwfGWMIYCEomGCSLdjMzMyJ5?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
						uKEPpRuvYhOhOcCwlVSBfEjYtHu.sCZiujcEtiokSidOXBUYOQmKEdNw._actionCategoryId = ((mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(uKEPpRuvYhOhOcCwlVSBfEjYtHu.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId) != null) ? mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.GetActionById(uKEPpRuvYhOhOcCwlVSBfEjYtHu.sCZiujcEtiokSidOXBUYOQmKEdNw._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.TYzMJHaauFcrCbTsSvvwmqZujWxQ)
					{
						controllerMap_Editor = feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.gpPKZjURlbtJeQNirBHucjPQfJDA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (WkrerUHXmifzdMIxnlGxDixyEBDt == null)
						{
							WkrerUHXmifzdMIxnlGxDixyEBDt = rzlJfxDZFIRNvHmKEAsVzKtGzlD;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> wkrerUHXmifzdMIxnlGxDixyEBDt = WkrerUHXmifzdMIxnlGxDixyEBDt;
						duhcImKyPISwVLglzTGsujUtNQSa(controllerMap_Editor.actionElementMaps, feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.actionElementMaps, controllerMap_Editor2.actionElementMaps, wkrerUHXmifzdMIxnlGxDixyEBDt);
						feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB = controllerMap_Editor2;
					}
					else
					{
						mZFtphVMrjsiRjFTsSjaTADAHlg.gRDRgXbGFHkCfIifqpbBMdginMv.CreateCustomControllerMap(feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.categoryId, feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.customControllerUid, feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.layoutId);
						controllerMap_Editor = feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.Count - 1];
					}
					feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB.id = controllerMap_Editor.id;
					int index = feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg.IndexOf(controllerMap_Editor);
					feROfEzVzcZSyMFROljzktXJDLI.krbfVTDEmdCGfHJdGtNodlokSfiE.EAOJWPvuzZdSUfZJKFFDodDeqqg[index] = feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB;
					return feROfEzVzcZSyMFROljzktXJDLI.lheHhijiDZqMdQbJbplIfCFRQFB;
				}

				private static int rzlJfxDZFIRNvHmKEAsVzKtGzlD(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class CAKWXejSWuofuNKTrtksuGrOChJj<T> where T : class
			{
				public Func<T, int> CrykrYPbpNGoKdAkrIxxmtrSlELp;
			}

			private sealed class KpWADUouovcQZsPJIXmvrfVruor<T> where T : class
			{
				public CAKWXejSWuofuNKTrtksuGrOChJj<T> NCataOiQVkIyoykItWnlqKqXhVV;

				public T lheHhijiDZqMdQbJbplIfCFRQFB;

				public bool wIgFpXqtPUEnJiyAYdErUbTtmng(mldQVwfGWMIYCEomGCSLdjMzMyJ P_0)
				{
					return P_0.sAKYwxELDKIrbyyslYnFomEqhKC == NCataOiQVkIyoykItWnlqKqXhVV.CrykrYPbpNGoKdAkrIxxmtrSlELp(lheHhijiDZqMdQbJbplIfCFRQFB);
				}
			}

			[CompilerGenerated]
			private static Func<InputCategory, int> tiYccuJekwnCackRBPRTxTKjHvNy;

			[CompilerGenerated]
			private static Func<InputCategory, string> fTDQurNBbvIfXcqsaoakXfHvpxQc;

			[CompilerGenerated]
			private static Func<InputCategory, IList<InputCategory>, int> uKLkZBlejpTNoTFGveQEtancwxU;

			[CompilerGenerated]
			private static Func<InputBehavior, int> fqhQCwwWaEYNyVQquSQWEkFCUct;

			[CompilerGenerated]
			private static Func<InputBehavior, string> JpWNMhtJnEjHIjQmSLThbAQiNZGU;

			[CompilerGenerated]
			private static Func<InputBehavior, IList<InputBehavior>, int> YrqtUFvMoMWDEjsmRDEWdGtlawS;

			[CompilerGenerated]
			private static Func<InputAction, int> PhRXCVaHGlJZZxTKHabygPseiQg;

			[CompilerGenerated]
			private static Func<InputAction, string> UvuaiYaFWBFotOrfKywFHPBbCvsJ;

			[CompilerGenerated]
			private static Func<InputAction, IList<InputAction>, int> vMybQqBzEDUPZVckNDarDiEuTWn;

			[CompilerGenerated]
			private static Func<InputMapCategory, int> rAokAzovHfBtvVUxICrmwOiFtFu;

			[CompilerGenerated]
			private static Func<InputMapCategory, string> JHnnTTfILbZSfJQlYWyZTVSPNMC;

			[CompilerGenerated]
			private static Func<InputMapCategory, IList<InputMapCategory>, int> LljViRgUoLVGfcycEcmQgGqKTKA;

			[CompilerGenerated]
			private static Func<InputLayout, int> hIfOrFBJEvVZDLheWQgfGOHiFigd;

			[CompilerGenerated]
			private static Func<InputLayout, string> zNpoMICmqsFkdOEJhsPdapegRnz;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> rpLlohhSqNjIjwgXkUPOOEDXNIF;

			[CompilerGenerated]
			private static Func<InputLayout, int> RANMQLYavtHVuofCeYKQKGESHqd;

			[CompilerGenerated]
			private static Func<InputLayout, string> asxEUZXgmXsNsEDXFPWGncHNVRU;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> zxVuAjEVgTQsqOXNLcVXYMTKAiW;

			[CompilerGenerated]
			private static Func<InputLayout, int> iTGyRHqczWvCMEPpHOFwdcSxakq;

			[CompilerGenerated]
			private static Func<InputLayout, string> bQkYthqrDrRKsKajVUFpZwhNQFJ;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> XXrutemcfqADKDmJRSkHODhntIk;

			[CompilerGenerated]
			private static Func<InputLayout, int> jNlNYnqPAWjbrwhuJZchfiGbLnm;

			[CompilerGenerated]
			private static Func<InputLayout, string> pejIKonVXSiwuNnFQJroaWYUlqC;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> hGrcJxjgpItiXmRBkxscbRGIlvQ;

			[CompilerGenerated]
			private static Func<CustomController_Editor, int> RbmgcxXTMfTNVVXelEkUpKAhkyj;

			[CompilerGenerated]
			private static Func<CustomController_Editor, string> sRJfZFSEAvWnibJYTNNeBEYLRR;

			[CompilerGenerated]
			private static Func<CustomController_Editor, IList<CustomController_Editor>, int> JfgFRdwSPwdKgHFyaBdxlpzFqMJz;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, int> qJtDayFWpUZynkpVSKsMiiBkvdtt;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, string> AgLqPGZWZCZaBSCOmeuuWkwVYuG;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> CflGPGONFPEDJRtmoXMqVznRFEz;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, int> rEQYrwXkrYJAAusOkWfKZFWikSa;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, string> CrCkXedItaKwWnCtzeRUbPJVWouO;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> AQinDGDScTtrsTApTUlZWMcfGAE;

			[CompilerGenerated]
			private static Func<Player_Editor, int> kkuMYwYJhLtwGoGkmTSdfhjreNmi;

			[CompilerGenerated]
			private static Func<Player_Editor, string> CelqoDWQlLoTxmDqBPQcpfEIOUn;

			[CompilerGenerated]
			private static Func<Player_Editor, IList<Player_Editor>, int> WaTfCBftQebejWZmBXuYSzDvZAO;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> fqxcxZcqPXttWFMwQsbZLhYIjNfb;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> HwdpOAhkaggFJbnmwDouCSQJeln;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> ebVFwFoVtWVeJBXEVMAehffdjZe;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> KMjwMXpOMmZpdaQCqSYGLhwaKlR;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> oPINWwHiwqeKyZMOQdwfiQNoaxAG;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> pShjOCuEbnmfxlNwjejUKQpbAYEQ;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> IpTxXYfgGEFMDXTjYKfCNPpXcIpF;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> KWtAIhfagLGNxMsZErfIVOACznRm;

			public static UserData XImAuIRApcwcMBrvVxengcVQCDZ(UserData P_0, UserData P_1, bool P_2)
			{
				WFbHeUEVPiMzIiIbTldTTILXvbSe wFbHeUEVPiMzIiIbTldTTILXvbSe = new WFbHeUEVPiMzIiIbTldTTILXvbSe();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv = (P_2 ? P_0 : new UserData(init: false));
				if (P_1 != null)
				{
					wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.configVars = JsonTools.Clone(P_1.configVars);
				}
				wFbHeUEVPiMzIiIbTldTTILXvbSe.tDyxLfpxzsDadLjiPgcPeeQuTlL = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Action Category", P_0.actionCategories, P_1?.actionCategories, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.actionCategories, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.tDyxLfpxzsDadLjiPgcPeeQuTlL, (InputCategory inputCategory) => inputCategory.id, (InputCategory inputCategory) => inputCategory.name, delegate(InputCategory inputCategory, IList<InputCategory> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputCategory.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.LulffzXJjYXNaYXFzYCXOdCgYfr);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.xkRaJlcuoDIjvSgeKOvknuxViNp = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.inputBehaviors, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.xkRaJlcuoDIjvSgeKOvknuxViNp, (InputBehavior inputBehavior) => inputBehavior.id, (InputBehavior inputBehavior) => inputBehavior.name, delegate(InputBehavior inputBehavior, IList<InputBehavior> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputBehavior.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.LurQbaRXAnTKNqPtmICXuOIZwUM);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.nUiZhXqlPtUGheksVhWpGYpBFnU = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Action", P_0.actions, P_1?.actions, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.actions, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.nUiZhXqlPtUGheksVhWpGYpBFnU, (InputAction inputAction) => inputAction.id, (InputAction inputAction) => inputAction.name, delegate(InputAction inputAction, IList<InputAction> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputAction.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.OmSeFVGbGakIwAnOABBplTRtOfkP);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.KvwtjEanLLXWmHamSMVecXuBlQG = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				aJOFKAgCzaaECtjxOPXsnCjwnxf aJOFKAgCzaaECtjxOPXsnCjwnxf2 = new aJOFKAgCzaaECtjxOPXsnCjwnxf();
				aJOFKAgCzaaECtjxOPXsnCjwnxf2.mZFtphVMrjsiRjFTsSjaTADAHlg = wFbHeUEVPiMzIiIbTldTTILXvbSe;
				aJOFKAgCzaaECtjxOPXsnCjwnxf2.DaqqrdJsatePmJWwCyYdPPNZMgLW = new List<int>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Map Category", P_0.mapCategories, P_1?.mapCategories, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.mapCategories, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.KvwtjEanLLXWmHamSMVecXuBlQG, (InputMapCategory inputMapCategory2) => inputMapCategory2.id, (InputMapCategory inputMapCategory2) => inputMapCategory2.name, delegate(InputMapCategory inputMapCategory2, IList<InputMapCategory> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputMapCategory2.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, aJOFKAgCzaaECtjxOPXsnCjwnxf2.tFSTlNXJbuniCgdUIrJizbGucUN);
				for (int num = 0; num < aJOFKAgCzaaECtjxOPXsnCjwnxf2.DaqqrdJsatePmJWwCyYdPPNZMgLW.Count; num++)
				{
					int index = aJOFKAgCzaaECtjxOPXsnCjwnxf2.DaqqrdJsatePmJWwCyYdPPNZMgLW[num];
					InputMapCategory inputMapCategory = wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.mapCategories[index];
					for (int num2 = 0; num2 < inputMapCategory.checkConflictsCategoryIds_orig.Count; num2++)
					{
						VrOUddvBFEmTPbrFeieFjOAYFUma vrOUddvBFEmTPbrFeieFjOAYFUma = new VrOUddvBFEmTPbrFeieFjOAYFUma();
						vrOUddvBFEmTPbrFeieFjOAYFUma.WSkFsITrZoSoDIVkSTKrtQVRSOq = aJOFKAgCzaaECtjxOPXsnCjwnxf2;
						vrOUddvBFEmTPbrFeieFjOAYFUma.mZFtphVMrjsiRjFTsSjaTADAHlg = wFbHeUEVPiMzIiIbTldTTILXvbSe;
						vrOUddvBFEmTPbrFeieFjOAYFUma.JVXBRqfXueiCkTMNcKBxQjoHwfxP = inputMapCategory.checkConflictsCategoryIds_orig[num2];
						mldQVwfGWMIYCEomGCSLdjMzMyJ mldQVwfGWMIYCEomGCSLdjMzMyJ2 = wFbHeUEVPiMzIiIbTldTTILXvbSe.KvwtjEanLLXWmHamSMVecXuBlQG.Find(vrOUddvBFEmTPbrFeieFjOAYFUma.HcKCPoDXYneQjFTFNGBluMlhWkH);
						inputMapCategory.checkConflictsCategoryIds_orig[num2] = mldQVwfGWMIYCEomGCSLdjMzMyJ2?.sAKYwxELDKIrbyyslYnFomEqhKC ?? (-1);
					}
				}
				wFbHeUEVPiMzIiIbTldTTILXvbSe.snOMnOlmvkDezcAuxuFnlcWlbIQ = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.keyboardLayouts, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.snOMnOlmvkDezcAuxuFnlcWlbIQ, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.GZeuQmXquecmWcTsIVdmmYfLJxL);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.kytObkGwzgvLrYMiTcWTTFmxMKe = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.mouseLayouts, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.kytObkGwzgvLrYMiTcWTTFmxMKe, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.aEmHLVEBkedGRFpkTGDBgzKcOozB);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.YJMxRLhSEeYGjaKuskBsKZhKqnE = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.joystickLayouts, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.YJMxRLhSEeYGjaKuskBsKZhKqnE, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.OfXFMQNgvImVjsTyLgNSxFKmNQl);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.VARLJEkDLmZllvXviageIOtFdiK = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.customControllerLayouts, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.VARLJEkDLmZllvXviageIOtFdiK, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.YLmKyfFkMcRxjbHefigoswTcYuE);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.ZdpDMsdjSwoSLYghOgszmvadivEK = wFbHeUEVPiMzIiIbTldTTILXvbSe.FusGEChpklSqVAwNDTqGbQtJeqJ;
				wFbHeUEVPiMzIiIbTldTTILXvbSe.jgMFPtVoIbUvhEiUCgCrShkJDYM = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Custom Controller", P_0.customControllers, P_1?.customControllers, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.customControllers, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.jgMFPtVoIbUvhEiUCgCrShkJDYM, (CustomController_Editor customController_Editor) => customController_Editor.id, (CustomController_Editor customController_Editor) => customController_Editor.name, delegate(CustomController_Editor customController_Editor, IList<CustomController_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(customController_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.ewpcLqHpwJkZtzAyNGAyFRFghWeJ);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.aSmnStzUGtGYGALilmPipsvcCKW = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.controllerMapLayoutManagerRuleSets, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.aSmnStzUGtGYGALilmPipsvcCKW, (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.id, (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.name, delegate(ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(controllerMapLayoutManager_RuleSet_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.HpKSxwxJjEjpgyYhdAxBpNvmRjb);
				wFbHeUEVPiMzIiIbTldTTILXvbSe.xhKmSgpbYFCpdjKZflCxouJewKGl = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.controllerMapEnablerRuleSets, P_2, wFbHeUEVPiMzIiIbTldTTILXvbSe.xhKmSgpbYFCpdjKZflCxouJewKGl, (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.id, (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.name, delegate(ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(controllerMapEnabler_RuleSet_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.rdkwqyVYbLouYAQJpDYUJEVMnon);
				List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				UrowqBpPsjCTicjcjSZcdzkghFpc("Player", P_0.players, P_1?.players, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.players, P_2, list, (Player_Editor player_Editor) => player_Editor.id, (Player_Editor player_Editor) => player_Editor.name, delegate(Player_Editor player_Editor, IList<Player_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(player_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, wFbHeUEVPiMzIiIbTldTTILXvbSe.sLHYnUnADkIwzYhHyuEoajaHRWD);
				List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list2 = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				tFlXIQOMZWVNVtOMElLckbeHYJi tFlXIQOMZWVNVtOMElLckbeHYJi2 = new tFlXIQOMZWVNVtOMElLckbeHYJi();
				tFlXIQOMZWVNVtOMElLckbeHYJi2.mZFtphVMrjsiRjFTsSjaTADAHlg = wFbHeUEVPiMzIiIbTldTTILXvbSe;
				tFlXIQOMZWVNVtOMElLckbeHYJi2.KPYjKRXyilgdPcHiMorMqUSshOW = wFbHeUEVPiMzIiIbTldTTILXvbSe.snOMnOlmvkDezcAuxuFnlcWlbIQ;
				UrowqBpPsjCTicjcjSZcdzkghFpc("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.keyboardMaps, P_2, list2, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, tFlXIQOMZWVNVtOMElLckbeHYJi2.RBoIAFupcaTpbUJtsWqeOobelta, tFlXIQOMZWVNVtOMElLckbeHYJi2.iLzAhxhbirHSBxGtcTxtgtkLsNr);
				List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list3 = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				IsHWdJPRYUHPZwYebreaBnrqGNN isHWdJPRYUHPZwYebreaBnrqGNN = new IsHWdJPRYUHPZwYebreaBnrqGNN();
				isHWdJPRYUHPZwYebreaBnrqGNN.mZFtphVMrjsiRjFTsSjaTADAHlg = wFbHeUEVPiMzIiIbTldTTILXvbSe;
				isHWdJPRYUHPZwYebreaBnrqGNN.KPYjKRXyilgdPcHiMorMqUSshOW = wFbHeUEVPiMzIiIbTldTTILXvbSe.kytObkGwzgvLrYMiTcWTTFmxMKe;
				UrowqBpPsjCTicjcjSZcdzkghFpc("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.mouseMaps, P_2, list3, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, isHWdJPRYUHPZwYebreaBnrqGNN.TrSRssrdrCyfSJegernuXDfbZaJ, isHWdJPRYUHPZwYebreaBnrqGNN.HUFDavIqPYkkDNoBoQshiiPxuCa);
				List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list4 = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				zNGsfbyOIZKuxTcqneYkEqNEAoL zNGsfbyOIZKuxTcqneYkEqNEAoL2 = new zNGsfbyOIZKuxTcqneYkEqNEAoL();
				zNGsfbyOIZKuxTcqneYkEqNEAoL2.mZFtphVMrjsiRjFTsSjaTADAHlg = wFbHeUEVPiMzIiIbTldTTILXvbSe;
				zNGsfbyOIZKuxTcqneYkEqNEAoL2.KPYjKRXyilgdPcHiMorMqUSshOW = wFbHeUEVPiMzIiIbTldTTILXvbSe.YJMxRLhSEeYGjaKuskBsKZhKqnE;
				UrowqBpPsjCTicjcjSZcdzkghFpc("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.joystickMaps, P_2, list4, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, zNGsfbyOIZKuxTcqneYkEqNEAoL2.RoJbqYgPrTsFPtjFcnoeONpKCpnI, zNGsfbyOIZKuxTcqneYkEqNEAoL2.FdjHTFambroYmaCeHoyxTIEhKXOe);
				List<mldQVwfGWMIYCEomGCSLdjMzMyJ> list5 = new List<mldQVwfGWMIYCEomGCSLdjMzMyJ>();
				ZVefcEmQQUlaTTGbHkrNHIHQHki zVefcEmQQUlaTTGbHkrNHIHQHki = new ZVefcEmQQUlaTTGbHkrNHIHQHki();
				zVefcEmQQUlaTTGbHkrNHIHQHki.mZFtphVMrjsiRjFTsSjaTADAHlg = wFbHeUEVPiMzIiIbTldTTILXvbSe;
				zVefcEmQQUlaTTGbHkrNHIHQHki.KPYjKRXyilgdPcHiMorMqUSshOW = wFbHeUEVPiMzIiIbTldTTILXvbSe.VARLJEkDLmZllvXviageIOtFdiK;
				UrowqBpPsjCTicjcjSZcdzkghFpc("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv.customControllerMaps, P_2, list5, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, zVefcEmQQUlaTTGbHkrNHIHQHki.aTrcaopZUxTaRoAYRYRToQZelrE, zVefcEmQQUlaTTGbHkrNHIHQHki.MpaTMWnzTZinqscnCcOOCggbzRS);
				return wFbHeUEVPiMzIiIbTldTTILXvbSe.gRDRgXbGFHkCfIifqpbBMdginMv;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void YAjWvWjXhPusJWZNDUDeBgHVrVo(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void duhcImKyPISwVLglzTGsujUtNQSa<T>(IList<T> P_0, IList<T> P_1, IList<T> P_2, Func<T, IList<T>, int> P_3)
			{
				for (int i = 0; i < P_0.Count; i++)
				{
					P_2.Add(P_0[i]);
				}
				if (P_1 == null)
				{
					return;
				}
				for (int j = 0; j < P_1.Count; j++)
				{
					T val = P_1[j];
					int num = P_3(val, P_2);
					if (num >= 0)
					{
						P_2[num] = val;
					}
					else
					{
						P_2.Add(val);
					}
				}
			}

			private static void UrowqBpPsjCTicjcjSZcdzkghFpc<T>(string P_0, IList<T> P_1, IList<T> P_2, IList<T> P_3, bool P_4, List<mldQVwfGWMIYCEomGCSLdjMzMyJ> P_5, Func<T, int> P_6, Func<T, string> P_7, Func<T, IList<T>, int> P_8, Func<cZLOdDIumDYkDZFvhYOclIrWViM<T>, T> P_9) where T : class
			{
				CAKWXejSWuofuNKTrtksuGrOChJj<T> cAKWXejSWuofuNKTrtksuGrOChJj = new CAKWXejSWuofuNKTrtksuGrOChJj<T>();
				cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					T val = P_1[i];
					if (P_4)
					{
						P_5.Add(new mldQVwfGWMIYCEomGCSLdjMzMyJ(cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(val), -1, cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(val)));
						continue;
					}
					T arg = P_9(new cZLOdDIumDYkDZFvhYOclIrWViM<T>(val, null, mldQVwfGWMIYCEomGCSLdjMzMyJ.rmfvGWjDzfhrPmVBdBvIgIDcWAr.VVufcHGAAQKefGtCuZnoHaqpVcN, P_3, isCollision: false));
					P_5.Add(new mldQVwfGWMIYCEomGCSLdjMzMyJ(cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(val), -1, cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(arg)));
				}
				if (P_2 == null)
				{
					return;
				}
				for (int j = 0; j < P_2.Count; j++)
				{
					T val2 = P_2[j];
					int num = P_8(val2, P_3);
					if (num >= 0)
					{
						KpWADUouovcQZsPJIXmvrfVruor<T> kpWADUouovcQZsPJIXmvrfVruor = new KpWADUouovcQZsPJIXmvrfVruor<T>();
						kpWADUouovcQZsPJIXmvrfVruor.NCataOiQVkIyoykItWnlqKqXhVV = cAKWXejSWuofuNKTrtksuGrOChJj;
						T finalItem = P_3[num];
						kpWADUouovcQZsPJIXmvrfVruor.lheHhijiDZqMdQbJbplIfCFRQFB = P_9(new cZLOdDIumDYkDZFvhYOclIrWViM<T>(val2, finalItem, mldQVwfGWMIYCEomGCSLdjMzMyJ.rmfvGWjDzfhrPmVBdBvIgIDcWAr.JVXBRqfXueiCkTMNcKBxQjoHwfxP, P_3, isCollision: true));
						P_5.Find(kpWADUouovcQZsPJIXmvrfVruor.wIgFpXqtPUEnJiyAYdErUbTtmng).JVXBRqfXueiCkTMNcKBxQjoHwfxP = cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						T arg2 = P_9(new cZLOdDIumDYkDZFvhYOclIrWViM<T>(val2, null, mldQVwfGWMIYCEomGCSLdjMzMyJ.rmfvGWjDzfhrPmVBdBvIgIDcWAr.JVXBRqfXueiCkTMNcKBxQjoHwfxP, P_3, isCollision: false));
						P_5.Add(new mldQVwfGWMIYCEomGCSLdjMzMyJ(-1, cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(val2), cAKWXejSWuofuNKTrtksuGrOChJj.CrykrYPbpNGoKdAkrIxxmtrSlELp(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}

			[CompilerGenerated]
			private static int QYllCHSrNWvUHwGDZhhzkGzrXAs(InputCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string xvTbsfytZhlGrMSeODsyksCQPJT(InputCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int tFLqiDlhebWFblMTkMnqhAdgypJ(InputCategory P_0, IList<InputCategory> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int XrcytQDlbZuRqKDZtWxfmKcUOvN(InputBehavior P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string BJRMwPIDFjfMKwGBesImYRocBQw(InputBehavior P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int mWVSLXHkHfqJMctRSPLDKRObNaS(InputBehavior P_0, IList<InputBehavior> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int zVaVhWGLZTQTAnSiDMrLaGZTRXd(InputAction P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string xfzLYlLfwVnadRNucbLqFaxmJDqH(InputAction P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int ieRyhzmJghufuImBYkMnRqBBHyR(InputAction P_0, IList<InputAction> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int cFvTRgTyPeIrGkNKbRqQImlXqel(InputMapCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string uNBWgXiMNafiQACBAXvlKfCtpQzg(InputMapCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int HhJzFNrTztIKLZQUDdQyGkhYsQK(InputMapCategory P_0, IList<InputMapCategory> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int TEpBxpYiBKfcuBpDGpqfXqODyPP(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string OyUXPTvxBrxCDpoDVhqSMNPuRHp(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int emYWbOqoAqIvNHDuDmLYMzInJBX(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int kgAAbygBGTCEWewsSTRujsPkeGAD(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string LSkqWDgvLqRQuycsmAqzJusiEWbE(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int lagEklIIqpOPfCybBhezTuNtLbxQ(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int iScWiUTVIbmsmdNcxUQoEGxombo(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string UTfCMFAGCCBqnuTqiXyIBRZpsubj(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int RHokOnNIPFCXNjPUvTAeWwewQkT(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int iGQphhpZzPGWTXtlCcNHWrQARis(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string wVBUAphXGMVqZRfzfUdcBpAhtIQ(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int SBNtBXElagCahBBeXBovmdfejeo(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int noHyORlJraTIYsNCKfFnhRpyYtJ(CustomController_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string pRYgrMixixMBFFvkzwWlQgiRRgNk(CustomController_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int nvthaXHgbEmBIaqXVzJgbkMvVBe(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int MqTtuumBZxFWgSWjRxpnZdJNNTP(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string ddMWxbJSDBVDFeHqTYXXLtsPKDA(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int aIChjfCkprBwNbXhELKcNVqjeZVf(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int YLIAADMNbmBXQNTpNIhvwmPsXLX(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string ihzgzPzaFwKnnwyLoWdfjxzPJep(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int RkCnirdFiHfyYsgNNSIWxxuqvtS(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int pHYeHxZWfPrcvQKFaUWqreDCJwf(Player_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string HzkfEAdfRKvTNIebEelmmzoIqcpL(Player_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int PxEYkCNDThkLpEgwZSMfPUIBpVk(Player_Editor P_0, IList<Player_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int ArBugYxnOKurWutctMGGXqMTChM(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string lALwnThLqDdGybOFPUrUCGAliPT(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int SKPBoOuYRZGduaKYjxXAvfJATvF(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string VfwaWCeLGpbWtNKwLEaiXSkPprNd(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int rUHkHAuxwCQXxWsQerlOWJPxWEU(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string JuPIWaFdtvFMbXcFrBmgHqyGjfGa(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int hHueRGiGZKkYhiktDkguVqaMMla(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string kwZqIoYAwzoFTJJuLlRiqeBvKjO(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}
		}

		private sealed class XXWWOIibJKdtXZFjayWaGkIKSR : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string TiGkGVqxuceQNvPSLIihRfkPdJqa;

			public string mufPbKpVOBEtofbeNAVPePuPBCK;

			public int ZnnmNXXfsicGEHWXbWxdFbttOhz;

			InputMapCategory IEnumerator<InputMapCategory>.Current
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
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				XXWWOIibJKdtXZFjayWaGkIKSR xXWWOIibJKdtXZFjayWaGkIKSR;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					xXWWOIibJKdtXZFjayWaGkIKSR = this;
				}
				else
				{
					xXWWOIibJKdtXZFjayWaGkIKSR = new XXWWOIibJKdtXZFjayWaGkIKSR(0);
					xXWWOIibJKdtXZFjayWaGkIKSR.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				xXWWOIibJKdtXZFjayWaGkIKSR.TiGkGVqxuceQNvPSLIihRfkPdJqa = mufPbKpVOBEtofbeNAVPePuPBCK;
				return xXWWOIibJKdtXZFjayWaGkIKSR;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (TiGkGVqxuceQNvPSLIihRfkPdJqa == null || TiGkGVqxuceQNvPSLIihRfkPdJqa == string.Empty || kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories == null)
					{
						break;
					}
					ZnnmNXXfsicGEHWXbWxdFbttOhz = 0;
					goto IL_00bd;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00af;
					}
					IL_00af:
					ZnnmNXXfsicGEHWXbWxdFbttOhz++;
					goto IL_00bd;
					IL_00bd:
					if (ZnnmNXXfsicGEHWXbWxdFbttOhz >= kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[ZnnmNXXfsicGEHWXbWxdFbttOhz].tag.Equals(TiGkGVqxuceQNvPSLIihRfkPdJqa, StringComparison.OrdinalIgnoreCase))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[ZnnmNXXfsicGEHWXbWxdFbttOhz];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00af;
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
			public XXWWOIibJKdtXZFjayWaGkIKSR(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class NdkLAsHhPMCWJxHEkqNAAnrDfbKc : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int NsSgtOdQbNGFdoiRiRKKFjIxElgT;

			InputMapCategory IEnumerator<InputMapCategory>.Current
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
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				NdkLAsHhPMCWJxHEkqNAAnrDfbKc ndkLAsHhPMCWJxHEkqNAAnrDfbKc;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					ndkLAsHhPMCWJxHEkqNAAnrDfbKc = this;
				}
				else
				{
					ndkLAsHhPMCWJxHEkqNAAnrDfbKc = new NdkLAsHhPMCWJxHEkqNAAnrDfbKc(0);
					ndkLAsHhPMCWJxHEkqNAAnrDfbKc.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return ndkLAsHhPMCWJxHEkqNAAnrDfbKc;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories == null)
					{
						break;
					}
					NsSgtOdQbNGFdoiRiRKKFjIxElgT = 0;
					goto IL_008e;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0080;
					}
					IL_0080:
					NsSgtOdQbNGFdoiRiRKKFjIxElgT++;
					goto IL_008e;
					IL_008e:
					if (NsSgtOdQbNGFdoiRiRKKFjIxElgT >= kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[NsSgtOdQbNGFdoiRiRKKFjIxElgT].userAssignable)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[NsSgtOdQbNGFdoiRiRKKFjIxElgT];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0080;
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
			public NdkLAsHhPMCWJxHEkqNAAnrDfbKc(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class hCTtpLGnFWlsgJGWDdJiCihTJPq : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string TiGkGVqxuceQNvPSLIihRfkPdJqa;

			public string mufPbKpVOBEtofbeNAVPePuPBCK;

			public int MEcCQFHbfgBWbTwXMVopAVVdGLj;

			InputMapCategory IEnumerator<InputMapCategory>.Current
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
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				hCTtpLGnFWlsgJGWDdJiCihTJPq hCTtpLGnFWlsgJGWDdJiCihTJPq2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					hCTtpLGnFWlsgJGWDdJiCihTJPq2 = this;
				}
				else
				{
					hCTtpLGnFWlsgJGWDdJiCihTJPq2 = new hCTtpLGnFWlsgJGWDdJiCihTJPq(0);
					hCTtpLGnFWlsgJGWDdJiCihTJPq2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				hCTtpLGnFWlsgJGWDdJiCihTJPq2.TiGkGVqxuceQNvPSLIihRfkPdJqa = mufPbKpVOBEtofbeNAVPePuPBCK;
				return hCTtpLGnFWlsgJGWDdJiCihTJPq2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (TiGkGVqxuceQNvPSLIihRfkPdJqa == null || TiGkGVqxuceQNvPSLIihRfkPdJqa == string.Empty || kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories == null)
					{
						break;
					}
					MEcCQFHbfgBWbTwXMVopAVVdGLj = 0;
					goto IL_00dd;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00cf;
					}
					IL_00cf:
					MEcCQFHbfgBWbTwXMVopAVVdGLj++;
					goto IL_00dd;
					IL_00dd:
					if (MEcCQFHbfgBWbTwXMVopAVVdGLj >= kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[MEcCQFHbfgBWbTwXMVopAVVdGLj].userAssignable && kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[MEcCQFHbfgBWbTwXMVopAVVdGLj].tag.Equals(TiGkGVqxuceQNvPSLIihRfkPdJqa, StringComparison.OrdinalIgnoreCase))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.mapCategories[MEcCQFHbfgBWbTwXMVopAVVdGLj];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00cf;
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
			public hCTtpLGnFWlsgJGWDdJiCihTJPq(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class tyHWssXesohJwpRlWewLiOUAScp : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string TiGkGVqxuceQNvPSLIihRfkPdJqa;

			public string mufPbKpVOBEtofbeNAVPePuPBCK;

			public int CrmObraNoCjFbavVwWtAxcZXGym;

			InputCategory IEnumerator<InputCategory>.Current
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
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				tyHWssXesohJwpRlWewLiOUAScp tyHWssXesohJwpRlWewLiOUAScp2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					tyHWssXesohJwpRlWewLiOUAScp2 = this;
				}
				else
				{
					tyHWssXesohJwpRlWewLiOUAScp2 = new tyHWssXesohJwpRlWewLiOUAScp(0);
					tyHWssXesohJwpRlWewLiOUAScp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				tyHWssXesohJwpRlWewLiOUAScp2.TiGkGVqxuceQNvPSLIihRfkPdJqa = mufPbKpVOBEtofbeNAVPePuPBCK;
				return tyHWssXesohJwpRlWewLiOUAScp2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (TiGkGVqxuceQNvPSLIihRfkPdJqa == null || TiGkGVqxuceQNvPSLIihRfkPdJqa == string.Empty || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null)
					{
						break;
					}
					CrmObraNoCjFbavVwWtAxcZXGym = 0;
					goto IL_00bd;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00af;
					}
					IL_00af:
					CrmObraNoCjFbavVwWtAxcZXGym++;
					goto IL_00bd;
					IL_00bd:
					if (CrmObraNoCjFbavVwWtAxcZXGym >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[CrmObraNoCjFbavVwWtAxcZXGym].tag.Equals(TiGkGVqxuceQNvPSLIihRfkPdJqa, StringComparison.OrdinalIgnoreCase))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[CrmObraNoCjFbavVwWtAxcZXGym];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00af;
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
			public tyHWssXesohJwpRlWewLiOUAScp(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class TQgrKuzaVUYEYZpYqaYgeYllnjs : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int nvnDRTjkAicKRyWhEnlSupnRlbNW;

			InputCategory IEnumerator<InputCategory>.Current
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
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				TQgrKuzaVUYEYZpYqaYgeYllnjs tQgrKuzaVUYEYZpYqaYgeYllnjs;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					tQgrKuzaVUYEYZpYqaYgeYllnjs = this;
				}
				else
				{
					tQgrKuzaVUYEYZpYqaYgeYllnjs = new TQgrKuzaVUYEYZpYqaYgeYllnjs(0);
					tQgrKuzaVUYEYZpYqaYgeYllnjs.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return tQgrKuzaVUYEYZpYqaYgeYllnjs;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null)
					{
						break;
					}
					nvnDRTjkAicKRyWhEnlSupnRlbNW = 0;
					goto IL_008e;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0080;
					}
					IL_0080:
					nvnDRTjkAicKRyWhEnlSupnRlbNW++;
					goto IL_008e;
					IL_008e:
					if (nvnDRTjkAicKRyWhEnlSupnRlbNW >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[nvnDRTjkAicKRyWhEnlSupnRlbNW].userAssignable)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[nvnDRTjkAicKRyWhEnlSupnRlbNW];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0080;
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
			public TQgrKuzaVUYEYZpYqaYgeYllnjs(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class xrqpvEULsJHYADRkFbXMIFHPQcp : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string TiGkGVqxuceQNvPSLIihRfkPdJqa;

			public string mufPbKpVOBEtofbeNAVPePuPBCK;

			public int CRgsncgrweLPgpLUiUQCzJolIPh;

			InputCategory IEnumerator<InputCategory>.Current
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
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				xrqpvEULsJHYADRkFbXMIFHPQcp xrqpvEULsJHYADRkFbXMIFHPQcp2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					xrqpvEULsJHYADRkFbXMIFHPQcp2 = this;
				}
				else
				{
					xrqpvEULsJHYADRkFbXMIFHPQcp2 = new xrqpvEULsJHYADRkFbXMIFHPQcp(0);
					xrqpvEULsJHYADRkFbXMIFHPQcp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				xrqpvEULsJHYADRkFbXMIFHPQcp2.TiGkGVqxuceQNvPSLIihRfkPdJqa = mufPbKpVOBEtofbeNAVPePuPBCK;
				return xrqpvEULsJHYADRkFbXMIFHPQcp2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (TiGkGVqxuceQNvPSLIihRfkPdJqa == null || TiGkGVqxuceQNvPSLIihRfkPdJqa == string.Empty || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null)
					{
						break;
					}
					CRgsncgrweLPgpLUiUQCzJolIPh = 0;
					goto IL_00dd;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00cf;
					}
					IL_00cf:
					CRgsncgrweLPgpLUiUQCzJolIPh++;
					goto IL_00dd;
					IL_00dd:
					if (CRgsncgrweLPgpLUiUQCzJolIPh >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[CRgsncgrweLPgpLUiUQCzJolIPh].userAssignable && kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[CRgsncgrweLPgpLUiUQCzJolIPh].tag.Equals(TiGkGVqxuceQNvPSLIihRfkPdJqa, StringComparison.OrdinalIgnoreCase))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[CRgsncgrweLPgpLUiUQCzJolIPh];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00cf;
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
			public xrqpvEULsJHYADRkFbXMIFHPQcp(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class sxhmJceDtxmEaAGwuIQjxTMpJLc : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int GTbMEJwQOhTwrPLWOIucxKopKtn;

			public InputAction XSQqfpuDrpBZrcbFmPvyPlUVlAqN;

			public InputCategory QjUniWYnqiEjltXAtuwiAqOFMmo;

			InputAction IEnumerator<InputAction>.Current
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
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				sxhmJceDtxmEaAGwuIQjxTMpJLc sxhmJceDtxmEaAGwuIQjxTMpJLc2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					sxhmJceDtxmEaAGwuIQjxTMpJLc2 = this;
				}
				else
				{
					sxhmJceDtxmEaAGwuIQjxTMpJLc2 = new sxhmJceDtxmEaAGwuIQjxTMpJLc(0);
					sxhmJceDtxmEaAGwuIQjxTMpJLc2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return sxhmJceDtxmEaAGwuIQjxTMpJLc2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null)
					{
						break;
					}
					GTbMEJwQOhTwrPLWOIucxKopKtn = 0;
					goto IL_00c1;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00b3;
					}
					IL_00b3:
					GTbMEJwQOhTwrPLWOIucxKopKtn++;
					goto IL_00c1;
					IL_00c1:
					if (GTbMEJwQOhTwrPLWOIucxKopKtn >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actions.Count)
					{
						break;
					}
					XSQqfpuDrpBZrcbFmPvyPlUVlAqN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[GTbMEJwQOhTwrPLWOIucxKopKtn];
					QjUniWYnqiEjltXAtuwiAqOFMmo = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionCategoryById(XSQqfpuDrpBZrcbFmPvyPlUVlAqN.categoryId);
					if (QjUniWYnqiEjltXAtuwiAqOFMmo != null && QjUniWYnqiEjltXAtuwiAqOFMmo.userAssignable && XSQqfpuDrpBZrcbFmPvyPlUVlAqN.userAssignable)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = XSQqfpuDrpBZrcbFmPvyPlUVlAqN;
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00b3;
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
			public sxhmJceDtxmEaAGwuIQjxTMpJLc(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ZdXvWLKOafdLlYQmWhPGwrlBTjF : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int XDkOPonjwJMNAMbToDXPhuoQata;

			public int vHkclQFtjoAXYpYdaFyWVwwIEHE;

			public bool gRSOlsrlLFrRfuvvxGffBfcYTXq;

			public bool uFiHKuctdqozwasFeBnYLeUHfLQe;

			public int OMwhNyxQirHiWDdeXhQjkekiuPn;

			public InputAction BVjdLVGnUKzuwzpoWLWdFcIgkdJ;

			public int JevXmDpRvyjlpjJLKFqXBLhmdVl;

			public IEnumerator<int> pvTQdNOfwfrWAMQhKigxqbaUDju;

			InputAction IEnumerator<InputAction>.Current
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
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				ZdXvWLKOafdLlYQmWhPGwrlBTjF zdXvWLKOafdLlYQmWhPGwrlBTjF;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					zdXvWLKOafdLlYQmWhPGwrlBTjF = this;
				}
				else
				{
					zdXvWLKOafdLlYQmWhPGwrlBTjF = new ZdXvWLKOafdLlYQmWhPGwrlBTjF(0);
					zdXvWLKOafdLlYQmWhPGwrlBTjF.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				zdXvWLKOafdLlYQmWhPGwrlBTjF.XDkOPonjwJMNAMbToDXPhuoQata = vHkclQFtjoAXYpYdaFyWVwwIEHE;
				zdXvWLKOafdLlYQmWhPGwrlBTjF.gRSOlsrlLFrRfuvvxGffBfcYTXq = uFiHKuctdqozwasFeBnYLeUHfLQe;
				return zdXvWLKOafdLlYQmWhPGwrlBTjF;
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
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null)
						{
							break;
						}
						if (gRSOlsrlLFrRfuvvxGffBfcYTXq)
						{
							pvTQdNOfwfrWAMQhKigxqbaUDju = kdBZqupjvsCsVkwJiOeEQzkEDVO.SortedActionIdsInCategory(XDkOPonjwJMNAMbToDXPhuoQata).GetEnumerator();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_00ca;
						}
						JevXmDpRvyjlpjJLKFqXBLhmdVl = 0;
						goto IL_014a;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00ca;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_013c;
						}
						IL_00ca:
						while (pvTQdNOfwfrWAMQhKigxqbaUDju.MoveNext())
						{
							OMwhNyxQirHiWDdeXhQjkekiuPn = pvTQdNOfwfrWAMQhKigxqbaUDju.Current;
							BVjdLVGnUKzuwzpoWLWdFcIgkdJ = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionById(OMwhNyxQirHiWDdeXhQjkekiuPn);
							if (BVjdLVGnUKzuwzpoWLWdFcIgkdJ != null)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = BVjdLVGnUKzuwzpoWLWdFcIgkdJ;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						DRqvPsmyPXJhAAlLLcwShAPRdYBa();
						break;
						IL_013c:
						JevXmDpRvyjlpjJLKFqXBLhmdVl++;
						goto IL_014a;
						IL_014a:
						if (JevXmDpRvyjlpjJLKFqXBLhmdVl >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actions.Count)
						{
							break;
						}
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[JevXmDpRvyjlpjJLKFqXBLhmdVl].categoryId == XDkOPonjwJMNAMbToDXPhuoQata)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[JevXmDpRvyjlpjJLKFqXBLhmdVl];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						goto IL_013c;
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
			public ZdXvWLKOafdLlYQmWhPGwrlBTjF(int _003C_003E1__state)
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

		private sealed class TBnjYfDiPLziDMNevgsTamemhyh : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string wHqaOdeYSzCpmBPGMjenDCOiAYO;

			public string llKFTmnFZEBCkHuaGseizgPmJsJ;

			public bool gRSOlsrlLFrRfuvvxGffBfcYTXq;

			public bool uFiHKuctdqozwasFeBnYLeUHfLQe;

			public int cuZGiniHyiDdpvBmLENAbmbkWFqz;

			public InputCategory LLMGHywODbHhFaTrGlJBfjJtxh;

			public int zyYtyUomOKmrnyaaZEGgAaFUoJCP;

			public InputAction iGpKSRoLwwTGWBkysPsJdibzaUj;

			public int lmOEMuLNiatSgFVBPaqYiOEGKtx;

			public IEnumerator<int> sASwgaFNkUsbPTvazVztOHJFOGE;

			InputAction IEnumerator<InputAction>.Current
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
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				TBnjYfDiPLziDMNevgsTamemhyh tBnjYfDiPLziDMNevgsTamemhyh;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					tBnjYfDiPLziDMNevgsTamemhyh = this;
				}
				else
				{
					tBnjYfDiPLziDMNevgsTamemhyh = new TBnjYfDiPLziDMNevgsTamemhyh(0);
					tBnjYfDiPLziDMNevgsTamemhyh.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				tBnjYfDiPLziDMNevgsTamemhyh.wHqaOdeYSzCpmBPGMjenDCOiAYO = llKFTmnFZEBCkHuaGseizgPmJsJ;
				tBnjYfDiPLziDMNevgsTamemhyh.gRSOlsrlLFrRfuvvxGffBfcYTXq = uFiHKuctdqozwasFeBnYLeUHfLQe;
				return tBnjYfDiPLziDMNevgsTamemhyh;
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
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null || wHqaOdeYSzCpmBPGMjenDCOiAYO == null || wHqaOdeYSzCpmBPGMjenDCOiAYO == string.Empty)
						{
							break;
						}
						cuZGiniHyiDdpvBmLENAbmbkWFqz = kdBZqupjvsCsVkwJiOeEQzkEDVO.IndexOfActionCategory(wHqaOdeYSzCpmBPGMjenDCOiAYO);
						if (cuZGiniHyiDdpvBmLENAbmbkWFqz < 0)
						{
							break;
						}
						LLMGHywODbHhFaTrGlJBfjJtxh = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionCategory(cuZGiniHyiDdpvBmLENAbmbkWFqz);
						if (gRSOlsrlLFrRfuvvxGffBfcYTXq)
						{
							sASwgaFNkUsbPTvazVztOHJFOGE = kdBZqupjvsCsVkwJiOeEQzkEDVO.SortedActionIdsInCategory(LLMGHywODbHhFaTrGlJBfjJtxh.id).GetEnumerator();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_0129;
						}
						lmOEMuLNiatSgFVBPaqYiOEGKtx = 0;
						goto IL_01ae;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_0129;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_01a0;
						}
						IL_0129:
						while (sASwgaFNkUsbPTvazVztOHJFOGE.MoveNext())
						{
							zyYtyUomOKmrnyaaZEGgAaFUoJCP = sASwgaFNkUsbPTvazVztOHJFOGE.Current;
							iGpKSRoLwwTGWBkysPsJdibzaUj = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionById(zyYtyUomOKmrnyaaZEGgAaFUoJCP);
							if (iGpKSRoLwwTGWBkysPsJdibzaUj != null)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = iGpKSRoLwwTGWBkysPsJdibzaUj;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						bstNYavZMFVOSDfFNFTQEMQrqnJR();
						break;
						IL_01a0:
						lmOEMuLNiatSgFVBPaqYiOEGKtx++;
						goto IL_01ae;
						IL_01ae:
						if (lmOEMuLNiatSgFVBPaqYiOEGKtx >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actions.Count)
						{
							break;
						}
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[lmOEMuLNiatSgFVBPaqYiOEGKtx].categoryId == LLMGHywODbHhFaTrGlJBfjJtxh.id)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[lmOEMuLNiatSgFVBPaqYiOEGKtx];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						goto IL_01a0;
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
						bstNYavZMFVOSDfFNFTQEMQrqnJR();
					}
				}
			}

			[DebuggerHidden]
			public TBnjYfDiPLziDMNevgsTamemhyh(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void bstNYavZMFVOSDfFNFTQEMQrqnJR()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (sASwgaFNkUsbPTvazVztOHJFOGE != null)
				{
					sASwgaFNkUsbPTvazVztOHJFOGE.Dispose();
				}
			}
		}

		private sealed class OdRhTrlkaANenPoqfzDLuOCYzUl : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string TiGkGVqxuceQNvPSLIihRfkPdJqa;

			public string mufPbKpVOBEtofbeNAVPePuPBCK;

			public int DccXDtIXhQgCUEDhwodQPaQMyIN;

			public int ZMPNZuhXRNPHCsWJpJnssKNemEW;

			public InputCategory YrxVsIdFNzSKLhEcwNMQdDRaWLk;

			public int VTgfQSvOvCALxGXGBNoYeXxQuPo;

			InputAction IEnumerator<InputAction>.Current
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
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				OdRhTrlkaANenPoqfzDLuOCYzUl odRhTrlkaANenPoqfzDLuOCYzUl;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					odRhTrlkaANenPoqfzDLuOCYzUl = this;
				}
				else
				{
					odRhTrlkaANenPoqfzDLuOCYzUl = new OdRhTrlkaANenPoqfzDLuOCYzUl(0);
					odRhTrlkaANenPoqfzDLuOCYzUl.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				odRhTrlkaANenPoqfzDLuOCYzUl.TiGkGVqxuceQNvPSLIihRfkPdJqa = mufPbKpVOBEtofbeNAVPePuPBCK;
				return odRhTrlkaANenPoqfzDLuOCYzUl;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null || TiGkGVqxuceQNvPSLIihRfkPdJqa == null || TiGkGVqxuceQNvPSLIihRfkPdJqa == string.Empty)
					{
						break;
					}
					DccXDtIXhQgCUEDhwodQPaQMyIN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions.Count;
					ZMPNZuhXRNPHCsWJpJnssKNemEW = 0;
					goto IL_0152;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0128;
					}
					IL_0152:
					if (ZMPNZuhXRNPHCsWJpJnssKNemEW >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories.Count)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[ZMPNZuhXRNPHCsWJpJnssKNemEW].tag.Equals(TiGkGVqxuceQNvPSLIihRfkPdJqa, StringComparison.OrdinalIgnoreCase))
					{
						YrxVsIdFNzSKLhEcwNMQdDRaWLk = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories[ZMPNZuhXRNPHCsWJpJnssKNemEW];
						VTgfQSvOvCALxGXGBNoYeXxQuPo = 0;
						goto IL_0136;
					}
					goto IL_0144;
					IL_0128:
					VTgfQSvOvCALxGXGBNoYeXxQuPo++;
					goto IL_0136;
					IL_0144:
					ZMPNZuhXRNPHCsWJpJnssKNemEW++;
					goto IL_0152;
					IL_0136:
					if (VTgfQSvOvCALxGXGBNoYeXxQuPo < DccXDtIXhQgCUEDhwodQPaQMyIN)
					{
						if (YrxVsIdFNzSKLhEcwNMQdDRaWLk.id == kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[VTgfQSvOvCALxGXGBNoYeXxQuPo].categoryId)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[VTgfQSvOvCALxGXGBNoYeXxQuPo];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							return true;
						}
						goto IL_0128;
					}
					goto IL_0144;
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
			public OdRhTrlkaANenPoqfzDLuOCYzUl(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class NjPoqalHLoMnlWmEayTEzGfHkXT : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int XDkOPonjwJMNAMbToDXPhuoQata;

			public int vHkclQFtjoAXYpYdaFyWVwwIEHE;

			public bool gRSOlsrlLFrRfuvvxGffBfcYTXq;

			public bool uFiHKuctdqozwasFeBnYLeUHfLQe;

			public InputCategory ZOQPisnQRBKwSiYSSMoPfdqPFth;

			public int FsnGFHCbvuNWdGftzxqPQrxLvnd;

			public InputAction MhJBNttvDhdhbFVAmrNoavYIdJmd;

			public int tGYIJwRApfBfMvxMICYLngrnSDr;

			public InputAction IIooVomDJRtXuYWSpjFjtwNlSRj;

			public IEnumerator<int> JHpEalwDAlukOrkWqeRyxGLtbKqH;

			InputAction IEnumerator<InputAction>.Current
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
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				NjPoqalHLoMnlWmEayTEzGfHkXT njPoqalHLoMnlWmEayTEzGfHkXT;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					njPoqalHLoMnlWmEayTEzGfHkXT = this;
				}
				else
				{
					njPoqalHLoMnlWmEayTEzGfHkXT = new NjPoqalHLoMnlWmEayTEzGfHkXT(0);
					njPoqalHLoMnlWmEayTEzGfHkXT.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				njPoqalHLoMnlWmEayTEzGfHkXT.XDkOPonjwJMNAMbToDXPhuoQata = vHkclQFtjoAXYpYdaFyWVwwIEHE;
				njPoqalHLoMnlWmEayTEzGfHkXT.gRSOlsrlLFrRfuvvxGffBfcYTXq = uFiHKuctdqozwasFeBnYLeUHfLQe;
				return njPoqalHLoMnlWmEayTEzGfHkXT;
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
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null)
						{
							break;
						}
						ZOQPisnQRBKwSiYSSMoPfdqPFth = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionCategoryById(XDkOPonjwJMNAMbToDXPhuoQata);
						if (ZOQPisnQRBKwSiYSSMoPfdqPFth == null || !ZOQPisnQRBKwSiYSSMoPfdqPFth.userAssignable)
						{
							break;
						}
						if (gRSOlsrlLFrRfuvvxGffBfcYTXq)
						{
							JHpEalwDAlukOrkWqeRyxGLtbKqH = kdBZqupjvsCsVkwJiOeEQzkEDVO.SortedActionIdsInCategory(ZOQPisnQRBKwSiYSSMoPfdqPFth.id).GetEnumerator();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_010e;
						}
						tGYIJwRApfBfMvxMICYLngrnSDr = 0;
						goto IL_019c;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_010e;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_018e;
						}
						IL_018e:
						tGYIJwRApfBfMvxMICYLngrnSDr++;
						goto IL_019c;
						IL_019c:
						if (tGYIJwRApfBfMvxMICYLngrnSDr >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actions.Count)
						{
							break;
						}
						IIooVomDJRtXuYWSpjFjtwNlSRj = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[tGYIJwRApfBfMvxMICYLngrnSDr];
						if (IIooVomDJRtXuYWSpjFjtwNlSRj.categoryId == ZOQPisnQRBKwSiYSSMoPfdqPFth.id && IIooVomDJRtXuYWSpjFjtwNlSRj.userAssignable)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = IIooVomDJRtXuYWSpjFjtwNlSRj;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						goto IL_018e;
						IL_010e:
						while (JHpEalwDAlukOrkWqeRyxGLtbKqH.MoveNext())
						{
							FsnGFHCbvuNWdGftzxqPQrxLvnd = JHpEalwDAlukOrkWqeRyxGLtbKqH.Current;
							MhJBNttvDhdhbFVAmrNoavYIdJmd = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionById(FsnGFHCbvuNWdGftzxqPQrxLvnd);
							if (MhJBNttvDhdhbFVAmrNoavYIdJmd != null && MhJBNttvDhdhbFVAmrNoavYIdJmd.userAssignable)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = MhJBNttvDhdhbFVAmrNoavYIdJmd;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						jhGcffKYUBoPzFbuAXmLXYGwEir();
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
						jhGcffKYUBoPzFbuAXmLXYGwEir();
					}
				}
			}

			[DebuggerHidden]
			public NjPoqalHLoMnlWmEayTEzGfHkXT(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void jhGcffKYUBoPzFbuAXmLXYGwEir()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (JHpEalwDAlukOrkWqeRyxGLtbKqH != null)
				{
					JHpEalwDAlukOrkWqeRyxGLtbKqH.Dispose();
				}
			}
		}

		private sealed class UyfEBTrqRydRNaSoqiSaOWkOEiG : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public string MkbMgkcOgkCBdCAgGtMjsORLGYKb;

			public string qaqgafKzAcUSluaVjKiXjsBsFEOQ;

			public bool gRSOlsrlLFrRfuvvxGffBfcYTXq;

			public bool uFiHKuctdqozwasFeBnYLeUHfLQe;

			public InputCategory PMLDDRRKZVhAjvHCcEXfbVaMrZVB;

			public int CGqBVZEoFLNziTTXKeVWNbbXkUYD;

			public InputAction CJRJHRtiowCbaSLyJrngkPbqryL;

			public int iiLOAwucgSHMifLGizWPIonCCBpD;

			public InputAction AHhRykjKLCzHezsCJmAuMaLDqsL;

			public IEnumerator<int> SlqaiRXklTnXxjMRULkjhSEAlrZ;

			InputAction IEnumerator<InputAction>.Current
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
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				UyfEBTrqRydRNaSoqiSaOWkOEiG uyfEBTrqRydRNaSoqiSaOWkOEiG;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					uyfEBTrqRydRNaSoqiSaOWkOEiG = this;
				}
				else
				{
					uyfEBTrqRydRNaSoqiSaOWkOEiG = new UyfEBTrqRydRNaSoqiSaOWkOEiG(0);
					uyfEBTrqRydRNaSoqiSaOWkOEiG.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				uyfEBTrqRydRNaSoqiSaOWkOEiG.MkbMgkcOgkCBdCAgGtMjsORLGYKb = qaqgafKzAcUSluaVjKiXjsBsFEOQ;
				uyfEBTrqRydRNaSoqiSaOWkOEiG.gRSOlsrlLFrRfuvvxGffBfcYTXq = uFiHKuctdqozwasFeBnYLeUHfLQe;
				return uyfEBTrqRydRNaSoqiSaOWkOEiG;
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
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null)
						{
							break;
						}
						PMLDDRRKZVhAjvHCcEXfbVaMrZVB = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionCategory(MkbMgkcOgkCBdCAgGtMjsORLGYKb);
						if (PMLDDRRKZVhAjvHCcEXfbVaMrZVB == null || !PMLDDRRKZVhAjvHCcEXfbVaMrZVB.userAssignable)
						{
							break;
						}
						if (gRSOlsrlLFrRfuvvxGffBfcYTXq)
						{
							SlqaiRXklTnXxjMRULkjhSEAlrZ = kdBZqupjvsCsVkwJiOeEQzkEDVO.SortedActionIdsInCategory(PMLDDRRKZVhAjvHCcEXfbVaMrZVB.id).GetEnumerator();
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_010e;
						}
						iiLOAwucgSHMifLGizWPIonCCBpD = 0;
						goto IL_019c;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_010e;
					case 3:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_018e;
						}
						IL_018e:
						iiLOAwucgSHMifLGizWPIonCCBpD++;
						goto IL_019c;
						IL_019c:
						if (iiLOAwucgSHMifLGizWPIonCCBpD >= kdBZqupjvsCsVkwJiOeEQzkEDVO.actions.Count)
						{
							break;
						}
						AHhRykjKLCzHezsCJmAuMaLDqsL = kdBZqupjvsCsVkwJiOeEQzkEDVO.actions[iiLOAwucgSHMifLGizWPIonCCBpD];
						if (AHhRykjKLCzHezsCJmAuMaLDqsL.categoryId == PMLDDRRKZVhAjvHCcEXfbVaMrZVB.id && AHhRykjKLCzHezsCJmAuMaLDqsL.userAssignable)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = AHhRykjKLCzHezsCJmAuMaLDqsL;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							return true;
						}
						goto IL_018e;
						IL_010e:
						while (SlqaiRXklTnXxjMRULkjhSEAlrZ.MoveNext())
						{
							CGqBVZEoFLNziTTXKeVWNbbXkUYD = SlqaiRXklTnXxjMRULkjhSEAlrZ.Current;
							CJRJHRtiowCbaSLyJrngkPbqryL = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionById(CGqBVZEoFLNziTTXKeVWNbbXkUYD);
							if (CJRJHRtiowCbaSLyJrngkPbqryL != null && CJRJHRtiowCbaSLyJrngkPbqryL.userAssignable)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = CJRJHRtiowCbaSLyJrngkPbqryL;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						NzNrxGOQARvMrTDGqjocvFpOmcw();
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
						NzNrxGOQARvMrTDGqjocvFpOmcw();
					}
				}
			}

			[DebuggerHidden]
			public UyfEBTrqRydRNaSoqiSaOWkOEiG(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void NzNrxGOQARvMrTDGqjocvFpOmcw()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (SlqaiRXklTnXxjMRULkjhSEAlrZ != null)
				{
					SlqaiRXklTnXxjMRULkjhSEAlrZ.Dispose();
				}
			}
		}

		private sealed class bUFJOlReawYaklKuKLNEUPbNbDg : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int bKgRNMZoNfkYtHsWtkGguFjJhGW;

			public int VsmaxtXFeNTUmzSoypBVeZhIoBr;

			public int aEYfvDAUKmMPiDgHNlJQodLxhlX;

			public InputAction IDNFfwByaGXqzkGaLqYEPCCkjOeq;

			public IEnumerator<int> HICDgeUNJPwocqlfZAMBlHJsozi;

			string IEnumerator<string>.Current
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
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				bUFJOlReawYaklKuKLNEUPbNbDg bUFJOlReawYaklKuKLNEUPbNbDg2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					bUFJOlReawYaklKuKLNEUPbNbDg2 = this;
				}
				else
				{
					bUFJOlReawYaklKuKLNEUPbNbDg2 = new bUFJOlReawYaklKuKLNEUPbNbDg(0);
					bUFJOlReawYaklKuKLNEUPbNbDg2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				bUFJOlReawYaklKuKLNEUPbNbDg2.bKgRNMZoNfkYtHsWtkGguFjJhGW = VsmaxtXFeNTUmzSoypBVeZhIoBr;
				return bUFJOlReawYaklKuKLNEUPbNbDg2;
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
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null)
						{
							break;
						}
						HICDgeUNJPwocqlfZAMBlHJsozi = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategoryMap.ActionIdsInCategory(bKgRNMZoNfkYtHsWtkGguFjJhGW).GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00c2;
					case 2:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_00c2;
						}
						IL_00c2:
						while (HICDgeUNJPwocqlfZAMBlHJsozi.MoveNext())
						{
							aEYfvDAUKmMPiDgHNlJQodLxhlX = HICDgeUNJPwocqlfZAMBlHJsozi.Current;
							IDNFfwByaGXqzkGaLqYEPCCkjOeq = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionById(aEYfvDAUKmMPiDgHNlJQodLxhlX);
							if (IDNFfwByaGXqzkGaLqYEPCCkjOeq != null)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = IDNFfwByaGXqzkGaLqYEPCCkjOeq.name;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						WmqlsEAObeBLipMDngeJWianejQ();
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
						WmqlsEAObeBLipMDngeJWianejQ();
					}
				}
			}

			[DebuggerHidden]
			public bUFJOlReawYaklKuKLNEUPbNbDg(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void WmqlsEAObeBLipMDngeJWianejQ()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (HICDgeUNJPwocqlfZAMBlHJsozi != null)
				{
					HICDgeUNJPwocqlfZAMBlHJsozi.Dispose();
				}
			}
		}

		private sealed class jkavbOWuAOuKHdLlWRpqbBIYaxp : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int bKgRNMZoNfkYtHsWtkGguFjJhGW;

			public int VsmaxtXFeNTUmzSoypBVeZhIoBr;

			public int ibDeSOVPqHaNcDuIXwlxaHdBNiD;

			public InputAction QRAkSLVfPBegQkXyNxFInJbVLAcf;

			public IEnumerator<int> RRWZSfhaHrvwINlYLiDwdNvNeDE;

			string IEnumerator<string>.Current
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
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				jkavbOWuAOuKHdLlWRpqbBIYaxp jkavbOWuAOuKHdLlWRpqbBIYaxp2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					jkavbOWuAOuKHdLlWRpqbBIYaxp2 = this;
				}
				else
				{
					jkavbOWuAOuKHdLlWRpqbBIYaxp2 = new jkavbOWuAOuKHdLlWRpqbBIYaxp(0);
					jkavbOWuAOuKHdLlWRpqbBIYaxp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				jkavbOWuAOuKHdLlWRpqbBIYaxp2.bKgRNMZoNfkYtHsWtkGguFjJhGW = VsmaxtXFeNTUmzSoypBVeZhIoBr;
				return jkavbOWuAOuKHdLlWRpqbBIYaxp2;
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
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null)
						{
							break;
						}
						RRWZSfhaHrvwINlYLiDwdNvNeDE = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategoryMap.ActionIdsInCategory(bKgRNMZoNfkYtHsWtkGguFjJhGW).GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00c2;
					case 2:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_00c2;
						}
						IL_00c2:
						while (RRWZSfhaHrvwINlYLiDwdNvNeDE.MoveNext())
						{
							ibDeSOVPqHaNcDuIXwlxaHdBNiD = RRWZSfhaHrvwINlYLiDwdNvNeDE.Current;
							QRAkSLVfPBegQkXyNxFInJbVLAcf = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetActionById(ibDeSOVPqHaNcDuIXwlxaHdBNiD);
							if (QRAkSLVfPBegQkXyNxFInJbVLAcf != null)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = QRAkSLVfPBegQkXyNxFInJbVLAcf.descriptiveName;
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
								return true;
							}
						}
						AVldCtHlnNncENlviQOJJfDrNnUq();
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
						AVldCtHlnNncENlviQOJJfDrNnUq();
					}
				}
			}

			[DebuggerHidden]
			public jkavbOWuAOuKHdLlWRpqbBIYaxp(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void AVldCtHlnNncENlviQOJJfDrNnUq()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (RRWZSfhaHrvwINlYLiDwdNvNeDE != null)
				{
					RRWZSfhaHrvwINlYLiDwdNvNeDE.Dispose();
				}
			}
		}

		private sealed class qdoaoqiLYGDoIfJxoIZSOCTaBHKc : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public UserData kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int bKgRNMZoNfkYtHsWtkGguFjJhGW;

			public int VsmaxtXFeNTUmzSoypBVeZhIoBr;

			public int gZRNcqPAWihMUNTFtajNUOerjgX;

			public IEnumerator<int> CBnhtAXMEjRyTEqFSQmvJDdqenG;

			int IEnumerator<int>.Current
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
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				qdoaoqiLYGDoIfJxoIZSOCTaBHKc qdoaoqiLYGDoIfJxoIZSOCTaBHKc2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					qdoaoqiLYGDoIfJxoIZSOCTaBHKc2 = this;
				}
				else
				{
					qdoaoqiLYGDoIfJxoIZSOCTaBHKc2 = new qdoaoqiLYGDoIfJxoIZSOCTaBHKc(0);
					qdoaoqiLYGDoIfJxoIZSOCTaBHKc2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				qdoaoqiLYGDoIfJxoIZSOCTaBHKc2.bKgRNMZoNfkYtHsWtkGguFjJhGW = VsmaxtXFeNTUmzSoypBVeZhIoBr;
				return qdoaoqiLYGDoIfJxoIZSOCTaBHKc2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategories == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.actions == null)
						{
							break;
						}
						CBnhtAXMEjRyTEqFSQmvJDdqenG = kdBZqupjvsCsVkwJiOeEQzkEDVO.actionCategoryMap.ActionIdsInCategory(bKgRNMZoNfkYtHsWtkGguFjJhGW).GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_0098;
					case 2:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							goto IL_0098;
						}
						IL_0098:
						if (CBnhtAXMEjRyTEqFSQmvJDdqenG.MoveNext())
						{
							gZRNcqPAWihMUNTFtajNUOerjgX = CBnhtAXMEjRyTEqFSQmvJDdqenG.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = gZRNcqPAWihMUNTFtajNUOerjgX;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						bBEgijXmxwFQnfqhBsqauKKkqIhB();
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
						bBEgijXmxwFQnfqhBsqauKKkqIhB();
					}
				}
			}

			[DebuggerHidden]
			public qdoaoqiLYGDoIfJxoIZSOCTaBHKc(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void bBEgijXmxwFQnfqhBsqauKKkqIhB()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (CBnhtAXMEjRyTEqFSQmvJDdqenG != null)
				{
					CBnhtAXMEjRyTEqFSQmvJDdqenG.Dispose();
				}
			}
		}

		private sealed class FbGoDLyhmJcUyTCeEWdjRooqlbF
		{
			private sealed class vXEFkPmjNOqfzuZQfsMiGifFsWV
			{
				public FbGoDLyhmJcUyTCeEWdjRooqlbF CUENYfkdVZBWAezHeWUdMvjiiwJm;

				public ControllerMap_Editor fmiyCZXvdFCBWTjMPhSrLknizZk;

				public ControllerMap_Editor JSffCNviejhMhwjEgVmNZseKfks;

				public bool qhscsdULATdFxfnozVKGVLeOghSR(InputLayout P_0)
				{
					return P_0.id == fmiyCZXvdFCBWTjMPhSrLknizZk.id;
				}

				public bool BArabPNTNjzEeCcXVoOLzqpAiLn(InputLayout P_0)
				{
					return P_0.id == JSffCNviejhMhwjEgVmNZseKfks.id;
				}
			}

			public List<InputLayout> jHzmKImaeBuLMiUZFESZZZgQTbo;

			public int xyzRBWfSivUsmoNsSpYHTOIZFBB(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				vXEFkPmjNOqfzuZQfsMiGifFsWV vXEFkPmjNOqfzuZQfsMiGifFsWV2 = new vXEFkPmjNOqfzuZQfsMiGifFsWV();
				vXEFkPmjNOqfzuZQfsMiGifFsWV2.CUENYfkdVZBWAezHeWUdMvjiiwJm = this;
				vXEFkPmjNOqfzuZQfsMiGifFsWV2.fmiyCZXvdFCBWTjMPhSrLknizZk = P_0;
				vXEFkPmjNOqfzuZQfsMiGifFsWV2.JSffCNviejhMhwjEgVmNZseKfks = P_1;
				int num = jHzmKImaeBuLMiUZFESZZZgQTbo.FindIndex(vXEFkPmjNOqfzuZQfsMiGifFsWV2.qhscsdULATdFxfnozVKGVLeOghSR);
				int num2 = jHzmKImaeBuLMiUZFESZZZgQTbo.FindIndex(vXEFkPmjNOqfzuZQfsMiGifFsWV2.BArabPNTNjzEeCcXVoOLzqpAiLn);
				if (num > num2)
				{
					return 1;
				}
				if (num < num2)
				{
					return -1;
				}
				return 0;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars = new ConfigVars();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Player_Editor> players = new List<Player_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputAction> actions = new List<InputAction>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputCategory> actionCategories = new List<InputCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int playerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int actionCategoryIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int inputBehaviorIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mapCategoryIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapLayoutManagerSetIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

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

		public ConfigVars ConfigVars => configVars;

		internal IEnumerable<InputMapCategory> UserAssignableMapCategories
		{
			get
			{
				NdkLAsHhPMCWJxHEkqNAAnrDfbKc ndkLAsHhPMCWJxHEkqNAAnrDfbKc = new NdkLAsHhPMCWJxHEkqNAAnrDfbKc(-2);
				ndkLAsHhPMCWJxHEkqNAAnrDfbKc.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return ndkLAsHhPMCWJxHEkqNAAnrDfbKc;
			}
		}

		internal IEnumerable<InputCategory> UserAssignableActionCategories
		{
			get
			{
				TQgrKuzaVUYEYZpYqaYgeYllnjs tQgrKuzaVUYEYZpYqaYgeYllnjs = new TQgrKuzaVUYEYZpYqaYgeYllnjs(-2);
				tQgrKuzaVUYEYZpYqaYgeYllnjs.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return tQgrKuzaVUYEYZpYqaYgeYllnjs;
			}
		}

		internal IEnumerable<InputAction> UserAssignableActions
		{
			get
			{
				sxhmJceDtxmEaAGwuIQjxTMpJLc sxhmJceDtxmEaAGwuIQjxTMpJLc2 = new sxhmJceDtxmEaAGwuIQjxTMpJLc(-2);
				sxhmJceDtxmEaAGwuIQjxTMpJLc2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return sxhmJceDtxmEaAGwuIQjxTMpJLc2;
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

		internal IEnumerable<InputMapCategory> KLxUdmCBCmPUZQpdQCUWpGaZTgw(string P_0)
		{
			XXWWOIibJKdtXZFjayWaGkIKSR xXWWOIibJKdtXZFjayWaGkIKSR = new XXWWOIibJKdtXZFjayWaGkIKSR(-2);
			xXWWOIibJKdtXZFjayWaGkIKSR.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			xXWWOIibJKdtXZFjayWaGkIKSR.mufPbKpVOBEtofbeNAVPePuPBCK = P_0;
			return xXWWOIibJKdtXZFjayWaGkIKSR;
		}

		internal IEnumerable<InputMapCategory> cRngqjkIldbxIHSIfwrCHSxuEvc(string P_0)
		{
			hCTtpLGnFWlsgJGWDdJiCihTJPq hCTtpLGnFWlsgJGWDdJiCihTJPq2 = new hCTtpLGnFWlsgJGWDdJiCihTJPq(-2);
			hCTtpLGnFWlsgJGWDdJiCihTJPq2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			hCTtpLGnFWlsgJGWDdJiCihTJPq2.mufPbKpVOBEtofbeNAVPePuPBCK = P_0;
			return hCTtpLGnFWlsgJGWDdJiCihTJPq2;
		}

		internal IEnumerable<InputCategory> sVMBiBXgoyIEWkVUSWZaOMHUbUL(string P_0)
		{
			tyHWssXesohJwpRlWewLiOUAScp tyHWssXesohJwpRlWewLiOUAScp2 = new tyHWssXesohJwpRlWewLiOUAScp(-2);
			tyHWssXesohJwpRlWewLiOUAScp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			tyHWssXesohJwpRlWewLiOUAScp2.mufPbKpVOBEtofbeNAVPePuPBCK = P_0;
			return tyHWssXesohJwpRlWewLiOUAScp2;
		}

		internal IEnumerable<InputCategory> AulGmsHARQKcmjjGmvHbujQSnEsf(string P_0)
		{
			xrqpvEULsJHYADRkFbXMIFHPQcp xrqpvEULsJHYADRkFbXMIFHPQcp2 = new xrqpvEULsJHYADRkFbXMIFHPQcp(-2);
			xrqpvEULsJHYADRkFbXMIFHPQcp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			xrqpvEULsJHYADRkFbXMIFHPQcp2.mufPbKpVOBEtofbeNAVPePuPBCK = P_0;
			return xrqpvEULsJHYADRkFbXMIFHPQcp2;
		}

		internal IEnumerable<InputAction> nArLdFtrHDPJFSqVWpRakNGSbJq(int P_0, bool P_1)
		{
			ZdXvWLKOafdLlYQmWhPGwrlBTjF zdXvWLKOafdLlYQmWhPGwrlBTjF = new ZdXvWLKOafdLlYQmWhPGwrlBTjF(-2);
			zdXvWLKOafdLlYQmWhPGwrlBTjF.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			zdXvWLKOafdLlYQmWhPGwrlBTjF.vHkclQFtjoAXYpYdaFyWVwwIEHE = P_0;
			zdXvWLKOafdLlYQmWhPGwrlBTjF.uFiHKuctdqozwasFeBnYLeUHfLQe = P_1;
			return zdXvWLKOafdLlYQmWhPGwrlBTjF;
		}

		internal IEnumerable<InputAction> nArLdFtrHDPJFSqVWpRakNGSbJq(string P_0, bool P_1)
		{
			TBnjYfDiPLziDMNevgsTamemhyh tBnjYfDiPLziDMNevgsTamemhyh = new TBnjYfDiPLziDMNevgsTamemhyh(-2);
			tBnjYfDiPLziDMNevgsTamemhyh.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			tBnjYfDiPLziDMNevgsTamemhyh.llKFTmnFZEBCkHuaGseizgPmJsJ = P_0;
			tBnjYfDiPLziDMNevgsTamemhyh.uFiHKuctdqozwasFeBnYLeUHfLQe = P_1;
			return tBnjYfDiPLziDMNevgsTamemhyh;
		}

		internal IEnumerable<InputAction> ybWAFDKqydVBoHuSPMEEBhrTKZDE(string P_0)
		{
			OdRhTrlkaANenPoqfzDLuOCYzUl odRhTrlkaANenPoqfzDLuOCYzUl = new OdRhTrlkaANenPoqfzDLuOCYzUl(-2);
			odRhTrlkaANenPoqfzDLuOCYzUl.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			odRhTrlkaANenPoqfzDLuOCYzUl.mufPbKpVOBEtofbeNAVPePuPBCK = P_0;
			return odRhTrlkaANenPoqfzDLuOCYzUl;
		}

		internal IEnumerable<InputAction> AaLREFnuDoCnfLQTWKJsNAlJVcs(int P_0, bool P_1)
		{
			NjPoqalHLoMnlWmEayTEzGfHkXT njPoqalHLoMnlWmEayTEzGfHkXT = new NjPoqalHLoMnlWmEayTEzGfHkXT(-2);
			njPoqalHLoMnlWmEayTEzGfHkXT.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			njPoqalHLoMnlWmEayTEzGfHkXT.vHkclQFtjoAXYpYdaFyWVwwIEHE = P_0;
			njPoqalHLoMnlWmEayTEzGfHkXT.uFiHKuctdqozwasFeBnYLeUHfLQe = P_1;
			return njPoqalHLoMnlWmEayTEzGfHkXT;
		}

		internal IEnumerable<InputAction> AaLREFnuDoCnfLQTWKJsNAlJVcs(string P_0, bool P_1)
		{
			UyfEBTrqRydRNaSoqiSaOWkOEiG uyfEBTrqRydRNaSoqiSaOWkOEiG = new UyfEBTrqRydRNaSoqiSaOWkOEiG(-2);
			uyfEBTrqRydRNaSoqiSaOWkOEiG.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			uyfEBTrqRydRNaSoqiSaOWkOEiG.qaqgafKzAcUSluaVjKiXjsBsFEOQ = P_0;
			uyfEBTrqRydRNaSoqiSaOWkOEiG.uFiHKuctdqozwasFeBnYLeUHfLQe = P_1;
			return uyfEBTrqRydRNaSoqiSaOWkOEiG;
		}

		public UserData()
			: this(init: true)
		{
		}

		private UserData(bool init)
		{
			if (init)
			{
				configVars.updateLoop = UpdateLoopSetting.Update;
				configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
				configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
				Player_Editor player_Editor = EaSmHPRszHnWPAzMkqPioBijTcO();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = HnWHDMUcWemAQslaOhEkGGuQkjBH();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = wWqKsbbwDwKgvajJtcfBzBzklqF();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = ujZpNmLqFFQNFEBrFcRzdovMWdfo();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = vxxBkXxcwdeLEIDKSMtqwZefGGx();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = IAATrtDHqmGrwUggJiiiCDRufiHZ();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = cKVYoUQhcoXFWvGxMdMbIzSHdOfx();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = xEZocrAIjSikZBIFMrfcPnVmFva();
				inputLayout4.name = "Default";
				inputLayout4.descriptiveName = inputLayout4.name;
				customControllerLayouts.Add(inputLayout3);
			}
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			for (int i = 0; i < actions.Count; i++)
			{
				list.Add(actions[i]);
			}
			return list;
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				list.Add(inputBehaviors[i].Clone());
			}
			return list;
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				KeyboardMap item = keyboardMaps[i].KwfOJnXLMpymzikcNMzwApPJcxo(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].PVnofDGBurSbjOzoPESgXvbEMmt(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(EaSmHPRszHnWPAzMkqPioBijTcO());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, EaSmHPRszHnWPAzMkqPioBijTcO());
		}

		public void DeletePlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.RemoveAt(index);
		}

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
		}

		public void DuplicatePlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Player_Editor player_Editor = players[index].Clone();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName(player_Editor.name, -1, GetPlayerNames());
			player_Editor.assignMouseOnStart = false;
			if (index == players.Count - 1)
			{
				players.Add(player_Editor);
			}
			else
			{
				players.Insert(index + 1, player_Editor);
			}
		}

		public string[] GetPlayerNames()
		{
			if (players == null)
			{
				return null;
			}
			string[] array = new string[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = players[i].name;
			}
			return array;
		}

		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			for (int i = 0; i < players.Count; i++)
			{
				results.Add(players[i].name);
			}
			return results.Count;
		}

		public int[] GetPlayerIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = players[i].id;
			}
			return array;
		}

		public int[] GetPlayerRuntimeIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				if (i == 0)
				{
					array[i] = 9999999;
				}
				else
				{
					array[i] = i - 1;
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
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (i == 0)
				{
					results.Add(9999999);
				}
				else
				{
					results.Add(i - 1);
				}
			}
			return results.Count;
		}

		public string GetPlayerNameById(int id)
		{
			if (players == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].id == id)
				{
					return players[i].name;
				}
			}
			return string.Empty;
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
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return players[i].id;
				}
			}
			return -1;
		}

		public bool IsMouseAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				if (players[i].assignMouseOnStart)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearMouseAssignments()
		{
			if (players != null)
			{
				int count = players.Count;
				for (int i = 0; i < count; i++)
				{
					players[i].assignMouseOnStart = false;
				}
			}
		}

		public bool IsKeyboardAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				if (players[i].assignKeyboardOnStart)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearKeyboardAssignments()
		{
			if (players != null)
			{
				int count = players.Count;
				for (int i = 0; i < count; i++)
				{
					players[i].assignKeyboardOnStart = false;
				}
			}
		}

		public void AddAction(int categoryId)
		{
			InputAction inputAction = ilvtqKqoAwfFDdptfJPImOHOLmX();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions != null)
			{
				InputAction inputAction = ilvtqKqoAwfFDdptfJPImOHOLmX();
				inputAction.categoryId = categoryId;
				actions.Add(inputAction);
				int index = actionCategoryMap.IndexOfAction(categoryId, actionId);
				actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
			}
		}

		public void DeleteAction(int categoryId, int actionId)
		{
			int num = IndexOfActionCategory(categoryId);
			if (num >= 0)
			{
				int num2 = IndexOfAction(actionId);
				if (num2 >= 0)
				{
					actions.RemoveAt(num2);
					actionCategoryMap.RemoveAction(categoryId, actionId);
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
				actions.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return actions.Count - 1;
			}
			actions.Insert(num2 + 1, inputAction);
			int num3 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num3 + 1);
			return num2 + 1;
		}

		private int rXwIVaaGnSiDjamxBXKmgAwRuBI(int P_0, InputAction P_1)
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
				return null;
			}
			string[] array = new string[actions.Count];
			for (int i = 0; i < actions.Count; i++)
			{
				array[i] = actions[i].name;
			}
			return array;
		}

		public int GetActionNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (actions == null)
			{
				return 0;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				results.Add(actions[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (actions == null)
			{
				return null;
			}
			int[] array = new int[actions.Count];
			for (int i = 0; i < actions.Count; i++)
			{
				array[i] = actions[i].id;
			}
			return array;
		}

		public int GetActionIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (actions == null)
			{
				return 0;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				results.Add(actions[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (actions == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].id == id)
				{
					return actions[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (actions == null || index < 0 || index >= actions.Count)
			{
				return null;
			}
			return actions[index];
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
				return null;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].id == id)
				{
					return actions[i];
				}
			}
			return null;
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
			if (actionCategories == null || actions == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = GetActionById(item);
				if (actionById != null)
				{
					list.Add(actionById.name);
				}
			}
			return list.ToArray();
		}

		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			bUFJOlReawYaklKuKLNEUPbNbDg bUFJOlReawYaklKuKLNEUPbNbDg2 = new bUFJOlReawYaklKuKLNEUPbNbDg(-2);
			bUFJOlReawYaklKuKLNEUPbNbDg2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			bUFJOlReawYaklKuKLNEUPbNbDg2.VsmaxtXFeNTUmzSoypBVeZhIoBr = id;
			return bUFJOlReawYaklKuKLNEUPbNbDg2;
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || actions == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = GetActionById(item);
				if (actionById != null)
				{
					list.Add(actionById.descriptiveName);
				}
			}
			return list.ToArray();
		}

		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			jkavbOWuAOuKHdLlWRpqbBIYaxp jkavbOWuAOuKHdLlWRpqbBIYaxp2 = new jkavbOWuAOuKHdLlWRpqbBIYaxp(-2);
			jkavbOWuAOuKHdLlWRpqbBIYaxp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			jkavbOWuAOuKHdLlWRpqbBIYaxp2.VsmaxtXFeNTUmzSoypBVeZhIoBr = id;
			return jkavbOWuAOuKHdLlWRpqbBIYaxp2;
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || actions == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				list.Add(item);
			}
			return list.ToArray();
		}

		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			qdoaoqiLYGDoIfJxoIZSOCTaBHKc qdoaoqiLYGDoIfJxoIZSOCTaBHKc2 = new qdoaoqiLYGDoIfJxoIZSOCTaBHKc(-2);
			qdoaoqiLYGDoIfJxoIZSOCTaBHKc2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			qdoaoqiLYGDoIfJxoIZSOCTaBHKc2.VsmaxtXFeNTUmzSoypBVeZhIoBr = id;
			return qdoaoqiLYGDoIfJxoIZSOCTaBHKc2;
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (actions == null)
			{
				return -1;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (actions == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputCategory inputCategory = HnWHDMUcWemAQslaOhEkGGuQkjBH();
			actionCategories.Add(inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputCategory inputCategory = HnWHDMUcWemAQslaOhEkGGuQkjBH();
			actionCategories.Insert(index, inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = actionCategories[index].id;
			actionCategoryMap.RemoveCategory(id);
			if (actions != null)
			{
				for (int num = actions.Count - 1; num >= 0; num--)
				{
					if (actions[num].categoryId == id)
					{
						actions.RemoveAt(num);
					}
				}
			}
			actionCategories.RemoveAt(index);
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
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				return;
			}
			InputCategory inputCategory = new InputCategory(actionCategories[index]);
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName(inputCategory.name, -1, GetActionCategoryNames());
			if (index == actionCategories.Count - 1)
			{
				actionCategories.Add(inputCategory);
			}
			else
			{
				actionCategories.Insert(index + 1, inputCategory);
			}
			actionCategoryMap.AddCategory(inputCategory.id);
			if (!duplicateActions || actions == null)
			{
				return;
			}
			int id = inputCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = actions[list[j]];
				int num = rXwIVaaGnSiDjamxBXKmgAwRuBI(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = actions[num];
					inputAction2.categoryId = id;
					dictionary.Add(inputAction.id, inputAction2.id);
				}
			}
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id2))
			{
				if (dictionary.TryGetValue(item, out var value))
				{
					actionCategoryMap.AddAction(id, value);
				}
			}
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = IndexOfAction(actionId);
			if (num >= 0 && actions[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				actions[num].categoryId = newCategoryId;
			}
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
				for (int i = 0; i < actions.Count; i++)
				{
					if (actions[i].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetActionCategoryIndex(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetActionCategoryNames()
		{
			if (actionCategories == null)
			{
				return null;
			}
			string[] array = new string[actionCategories.Count];
			for (int i = 0; i < actionCategories.Count; i++)
			{
				array[i] = actionCategories[i].name;
			}
			return array;
		}

		public int[] GetActionCategoryIds()
		{
			if (actionCategories == null)
			{
				return null;
			}
			int[] array = new int[actionCategories.Count];
			for (int i = 0; i < actionCategories.Count; i++)
			{
				array[i] = actionCategories[i].id;
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
			if (num < 0)
			{
				return null;
			}
			return actionCategories[num];
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
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return actionCategories[i].name;
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
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfActionCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
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
			inputBehaviors.Add(wWqKsbbwDwKgvajJtcfBzBzklqF());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, wWqKsbbwDwKgvajJtcfBzBzklqF());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (actions != null)
			{
				for (int i = 0; i < actions.Count; i++)
				{
					if (actions[i].behaviorId == id)
					{
						actions[i].behaviorId = 0;
					}
				}
			}
			inputBehaviors.RemoveAt(index);
		}

		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(inputBehaviors, index, offsetDown, offsetNow);
		}

		public void DuplicateInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputBehavior inputBehavior = inputBehaviors[index].Clone();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames());
			if (index == inputBehaviors.Count - 1)
			{
				inputBehaviors.Add(inputBehavior);
			}
			else
			{
				inputBehaviors.Insert(index + 1, inputBehavior);
			}
		}

		public string[] GetInputBehaviorNames()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			string[] array = new string[inputBehaviors.Count];
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				array[i] = inputBehaviors[i].name;
			}
			return array;
		}

		public int[] GetInputBehaviorIds()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int[] array = new int[inputBehaviors.Count];
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				array[i] = inputBehaviors[i].id;
			}
			return array;
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
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].id == id)
				{
					return inputBehaviors[i];
				}
			}
			return null;
		}

		public int GetInputBehaviorId(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = IndexOfInputBehavior(name);
			if (num < 0)
			{
				return -1;
			}
			return inputBehaviors[num].id;
		}

		public int IndexOfInputBehavior(int id)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].id == id)
				{
					return i;
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
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddMapCategory()
		{
			mapCategories.Add(ujZpNmLqFFQNFEBrFcRzdovMWdfo());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, ujZpNmLqFFQNFEBrFcRzdovMWdfo());
		}

		public void DeleteMapCategory(int index)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = mapCategories[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].categoryId == id)
					{
						joystickMaps.RemoveAt(num);
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int num2 = keyboardMaps.Count - 1; num2 >= 0; num2--)
				{
					if (keyboardMaps[num2].categoryId == id)
					{
						keyboardMaps.RemoveAt(num2);
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int num3 = mouseMaps.Count - 1; num3 >= 0; num3--)
				{
					if (mouseMaps[num3].categoryId == id)
					{
						mouseMaps.RemoveAt(num3);
					}
				}
			}
			if (customControllerMaps != null)
			{
				for (int num4 = customControllerMaps.Count - 1; num4 >= 0; num4--)
				{
					if (customControllerMaps[num4].categoryId == id)
					{
						customControllerMaps.RemoveAt(num4);
					}
				}
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					InputMapCategory inputMapCategory = mapCategories[i];
					if (inputMapCategory.checkConflictsCategoryIds == null)
					{
						continue;
					}
					for (int j = 0; j < inputMapCategory.checkConflictsCategoryIds.Count; j++)
					{
						if (inputMapCategory.checkConflictsCategoryIds[j] == id)
						{
							inputMapCategory.checkConflictsCategoryIds.RemoveAt(j);
						}
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = delegate(List<Player_Editor.Mapping> P_0, int P_1)
				{
					if (P_0 != null)
					{
						for (int num6 = P_0.Count - 1; num6 >= 0; num6--)
						{
							if (P_0[num6] == null || P_0[num6].categoryId == P_1)
							{
								P_0.RemoveAt(num6);
							}
						}
					}
				};
				for (int num5 = 0; num5 < players.Count; num5++)
				{
					Player_Editor player_Editor = players[num5];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
						action(player_Editor.defaultMouseMaps, id);
						action(player_Editor.defaultJoystickMaps, id);
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			mapCategories.RemoveAt(index);
		}

		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mapCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputMapCategory inputMapCategory = new InputMapCategory(mapCategories[index]);
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames());
			if (index == mapCategories.Count - 1)
			{
				mapCategories.Add(inputMapCategory);
			}
			else
			{
				mapCategories.Insert(index + 1, inputMapCategory);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputMapCategory.id;
			int id2 = mapCategories[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].categoryId == id2)
					{
						int num2 = DuplicateJoystickMap(num);
						if (num2 >= 0)
						{
							joystickMaps[num2].categoryId = id;
						}
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int num3 = keyboardMaps.Count - 1; num3 >= 0; num3--)
				{
					if (keyboardMaps[num3].categoryId == id2)
					{
						int num4 = DuplicateKeyboardMap(num3);
						if (num4 >= 0)
						{
							keyboardMaps[num4].categoryId = id;
						}
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int num5 = mouseMaps.Count - 1; num5 >= 0; num5--)
				{
					if (mouseMaps[num5].categoryId == id2)
					{
						int num6 = DuplicateMouseMap(num5);
						if (num6 >= 0)
						{
							mouseMaps[num6].categoryId = id;
						}
					}
				}
			}
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num7 = customControllerMaps.Count - 1; num7 >= 0; num7--)
			{
				if (customControllerMaps[num7].categoryId == id2)
				{
					int num8 = DuplicateCustomControllerMap(num7);
					if (num8 >= 0)
					{
						customControllerMaps[num8].categoryId = id;
					}
				}
			}
		}

		public int GetMapCategoryMapCount(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps != null)
			{
				for (int i = 0; i < joystickMaps.Count; i++)
				{
					if (joystickMaps[i].categoryId == id)
					{
						num++;
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int j = 0; j < keyboardMaps.Count; j++)
				{
					if (keyboardMaps[j].categoryId == id)
					{
						num++;
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int k = 0; k < mouseMaps.Count; k++)
				{
					if (mouseMaps[k].categoryId == id)
					{
						num++;
					}
				}
			}
			if (customControllerMaps != null)
			{
				for (int l = 0; l < customControllerMaps.Count; l++)
				{
					if (customControllerMaps[l].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetMapCategoryIndex(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetMapCategoryNames()
		{
			if (mapCategories == null)
			{
				return null;
			}
			string[] array = new string[mapCategories.Count];
			for (int i = 0; i < mapCategories.Count; i++)
			{
				array[i] = mapCategories[i].name;
			}
			return array;
		}

		public int[] GetMapCategoryIds()
		{
			if (mapCategories == null)
			{
				return null;
			}
			int[] array = new int[mapCategories.Count];
			for (int i = 0; i < mapCategories.Count; i++)
			{
				array[i] = mapCategories[i].id;
			}
			return array;
		}

		public InputMapCategory GetMapCategory(int index)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				return null;
			}
			return mapCategories[index];
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
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return mapCategories[i];
				}
			}
			return null;
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
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return mapCategories[i].name;
				}
			}
			return string.Empty;
		}

		public int IndexOfMapCategory(int id)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfMapCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			return controllerType switch
			{
				ControllerType.Keyboard => GetKeyboardLayoutNames(), 
				ControllerType.Mouse => GetMouseLayoutNames(), 
				ControllerType.Joystick => GetJoystickLayoutNames(), 
				ControllerType.Custom => GetCustomControllerLayoutNames(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			return controllerType switch
			{
				ControllerType.Keyboard => GetKeyboardLayoutIds(), 
				ControllerType.Mouse => GetMouseLayoutIds(), 
				ControllerType.Joystick => GetJoystickLayoutIds(), 
				ControllerType.Custom => GetCustomControllerLayoutIds(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(vxxBkXxcwdeLEIDKSMtqwZefGGx());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, vxxBkXxcwdeLEIDKSMtqwZefGGx());
		}

		public void DeleteJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = joystickLayouts[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].layoutId == id)
					{
						joystickMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = delegate(List<Player_Editor.Mapping> P_0, int P_1)
				{
					if (P_0 != null)
					{
						for (int num3 = P_0.Count - 1; num3 >= 0; num3--)
						{
							if (P_0[num3] == null || P_0[num3].layoutId == P_1)
							{
								P_0.RemoveAt(num3);
							}
						}
					}
				};
				for (int num2 = 0; num2 < players.Count; num2++)
				{
					Player_Editor player_Editor = players[num2];
					if (player_Editor != null)
					{
						action(player_Editor.defaultJoystickMaps, id);
					}
				}
			}
			joystickLayouts.RemoveAt(index);
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = joystickLayouts[index].Clone();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames());
			if (index == joystickLayouts.Count - 1)
			{
				joystickLayouts.Add(inputLayout);
			}
			else
			{
				joystickLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = joystickLayouts[index].id;
			if (joystickMaps == null)
			{
				return;
			}
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].layoutId == id2)
				{
					int num2 = DuplicateJoystickMap(num);
					if (num2 >= 0)
					{
						joystickMaps[num2].layoutId = id;
					}
				}
			}
		}

		public int GetJoystickLayoutMapCount(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps != null)
			{
				for (int i = 0; i < joystickMaps.Count; i++)
				{
					if (joystickMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetJoystickLayoutIndex(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return i;
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
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				array[i] = joystickLayouts[i].name;
			}
			return array;
		}

		public int[] GetJoystickLayoutIds()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int[] array = new int[joystickLayouts.Count];
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				array[i] = joystickLayouts[i].id;
			}
			return array;
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
				return null;
			}
			int num = IndexOfJoystickLayout(id);
			if (num < 0)
			{
				return null;
			}
			return joystickLayouts[num];
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
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfJoystickLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (joystickLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			if (joystickLayouts != null)
			{
				for (int i = 0; i < joystickLayouts.Count; i++)
				{
					if (joystickLayouts[i].id == id)
					{
						return joystickLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddKeyboardLayout()
		{
			keyboardLayouts.Add(IAATrtDHqmGrwUggJiiiCDRufiHZ());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, IAATrtDHqmGrwUggJiiiCDRufiHZ());
		}

		public void DeleteKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = keyboardLayouts[index].id;
			if (keyboardMaps != null)
			{
				for (int num = keyboardMaps.Count - 1; num >= 0; num--)
				{
					if (keyboardMaps[num].layoutId == id)
					{
						keyboardMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = delegate(List<Player_Editor.Mapping> P_0, int P_1)
				{
					if (P_0 != null)
					{
						for (int num3 = P_0.Count - 1; num3 >= 0; num3--)
						{
							if (P_0[num3] == null || P_0[num3].layoutId == P_1)
							{
								P_0.RemoveAt(num3);
							}
						}
					}
				};
				for (int num2 = 0; num2 < players.Count; num2++)
				{
					Player_Editor player_Editor = players[num2];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
					}
				}
			}
			keyboardLayouts.RemoveAt(index);
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = keyboardLayouts[index].Clone();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames());
			if (index == keyboardLayouts.Count - 1)
			{
				keyboardLayouts.Add(inputLayout);
			}
			else
			{
				keyboardLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = keyboardLayouts[index].id;
			if (keyboardMaps == null)
			{
				return;
			}
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].layoutId == id2)
				{
					int num2 = DuplicateKeyboardMap(num);
					if (num2 >= 0)
					{
						keyboardMaps[num2].layoutId = id;
					}
				}
			}
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
				for (int i = 0; i < keyboardMaps.Count; i++)
				{
					if (keyboardMaps[i].layoutId == id)
					{
						num++;
					}
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
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetKeyboardLayoutNames()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			string[] array = new string[keyboardLayouts.Count];
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				array[i] = keyboardLayouts[i].name;
			}
			return array;
		}

		public int[] GetKeyboardLayoutIds()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int[] array = new int[keyboardLayouts.Count];
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				array[i] = keyboardLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				return null;
			}
			return keyboardLayouts[index];
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
				return -1;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfKeyboardLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (keyboardLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			if (keyboardLayouts != null)
			{
				for (int i = 0; i < keyboardLayouts.Count; i++)
				{
					if (keyboardLayouts[i].id == id)
					{
						return keyboardLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddMouseLayout()
		{
			mouseLayouts.Add(cKVYoUQhcoXFWvGxMdMbIzSHdOfx());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, cKVYoUQhcoXFWvGxMdMbIzSHdOfx());
		}

		public void DeleteMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = mouseLayouts[index].id;
			if (mouseMaps != null)
			{
				for (int num = mouseMaps.Count - 1; num >= 0; num--)
				{
					if (mouseMaps[num].layoutId == id)
					{
						mouseMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = delegate(List<Player_Editor.Mapping> P_0, int P_1)
				{
					if (P_0 != null)
					{
						for (int num3 = P_0.Count - 1; num3 >= 0; num3--)
						{
							if (P_0[num3] == null || P_0[num3].layoutId == P_1)
							{
								P_0.RemoveAt(num3);
							}
						}
					}
				};
				for (int num2 = 0; num2 < players.Count; num2++)
				{
					Player_Editor player_Editor = players[num2];
					if (player_Editor != null)
					{
						action(player_Editor.defaultMouseMaps, id);
					}
				}
			}
			mouseLayouts.RemoveAt(index);
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = mouseLayouts[index].Clone();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames());
			if (index == mouseLayouts.Count - 1)
			{
				mouseLayouts.Add(inputLayout);
			}
			else
			{
				mouseLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = mouseLayouts[index].id;
			if (mouseMaps == null)
			{
				return;
			}
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].layoutId == id2)
				{
					int num2 = DuplicateMouseMap(num);
					if (num2 >= 0)
					{
						mouseMaps[num2].layoutId = id;
					}
				}
			}
		}

		public int GetMouseLayoutMapCount(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (mouseMaps != null)
			{
				for (int i = 0; i < mouseMaps.Count; i++)
				{
					if (mouseMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetMouseLayoutIndex(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetMouseLayoutNames()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			string[] array = new string[mouseLayouts.Count];
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				array[i] = mouseLayouts[i].name;
			}
			return array;
		}

		public int[] GetMouseLayoutIds()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int[] array = new int[mouseLayouts.Count];
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				array[i] = mouseLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				return null;
			}
			return mouseLayouts[index];
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
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfMouseLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (mouseLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetMouseLayoutNameById(int id)
		{
			if (mouseLayouts != null)
			{
				for (int i = 0; i < mouseLayouts.Count; i++)
				{
					if (mouseLayouts[i].id == id)
					{
						return mouseLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddCustomControllerLayout()
		{
			customControllerLayouts.Add(xEZocrAIjSikZBIFMrfcPnVmFva());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, xEZocrAIjSikZBIFMrfcPnVmFva());
		}

		public void DeleteCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = customControllerLayouts[index].id;
			if (customControllerMaps != null)
			{
				for (int num = customControllerMaps.Count - 1; num >= 0; num--)
				{
					if (customControllerMaps[num].layoutId == id)
					{
						customControllerMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = delegate(List<Player_Editor.Mapping> P_0, int P_1)
				{
					if (P_0 != null)
					{
						for (int num3 = P_0.Count - 1; num3 >= 0; num3--)
						{
							if (P_0[num3] == null || P_0[num3].layoutId == P_1)
							{
								P_0.RemoveAt(num3);
							}
						}
					}
				};
				for (int num2 = 0; num2 < players.Count; num2++)
				{
					Player_Editor player_Editor = players[num2];
					if (player_Editor != null)
					{
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			customControllerLayouts.RemoveAt(index);
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = customControllerLayouts[index].Clone();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames());
			if (index == customControllerLayouts.Count - 1)
			{
				customControllerLayouts.Add(inputLayout);
			}
			else
			{
				customControllerLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = customControllerLayouts[index].id;
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].layoutId == id2)
				{
					int num2 = DuplicateCustomControllerMap(num);
					if (num2 >= 0)
					{
						customControllerMaps[num2].layoutId = id;
					}
				}
			}
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
				for (int i = 0; i < customControllerMaps.Count; i++)
				{
					if (customControllerMaps[i].layoutId == id)
					{
						num++;
					}
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
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return i;
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
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				array[i] = customControllerLayouts[i].name;
			}
			return array;
		}

		public int[] GetCustomControllerLayoutIds()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int[] array = new int[customControllerLayouts.Count];
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				array[i] = customControllerLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				return null;
			}
			return customControllerLayouts[index];
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
				return null;
			}
			int num = IndexOfCustomControllerLayout(id);
			if (num < 0)
			{
				return null;
			}
			return customControllerLayouts[num];
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
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (customControllerLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetCustomControllerLayoutNameById(int id)
		{
			if (customControllerLayouts != null)
			{
				for (int i = 0; i < customControllerLayouts.Count; i++)
				{
					if (customControllerLayouts[i].id == id)
					{
						return customControllerLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			return controllerType switch
			{
				ControllerType.Joystick => GetJoystickLayoutNameById(id), 
				ControllerType.Keyboard => GetKeyboardLayoutNameById(id), 
				ControllerType.Mouse => GetMouseLayoutNameById(id), 
				ControllerType.Custom => GetCustomControllerLayoutNameById(id), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal ControllerMap UlqVyTSDDBoZvjxnAEFEnfKUirw(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => dAntuILfYUUPSPWGcWNciDFsLko((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => AuMvOlnFHBkcQXDNUsENAfSzNfH(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return joystickMaps[i];
				}
			}
			return null;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			if (joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].id == id)
				{
					joystickMapIndex = i;
					return joystickMaps[i];
				}
			}
			return null;
		}

		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					list.Add(joystickMaps[i]);
				}
			}
			return list;
		}

		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return joystickMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid && joystickMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				joystickMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewJoystickMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
			joystickMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteJoystickMap(int id)
		{
			if (joystickMaps == null)
			{
				return;
			}
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].id == id)
				{
					joystickMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateJoystickMap(int index)
		{
			if (joystickMaps == null || index < 0 || index >= joystickMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
			controllerMap_Editor.id = GetNewJoystickMapId();
			joystickMaps.Add(controllerMap_Editor);
			return joystickMaps.Count - 1;
		}

		internal JoystickMap YIRXiPCBuWEhVcNSXWLaNpLRdOL(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return dAntuILfYUUPSPWGcWNciDFsLko(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap dAntuILfYUUPSPWGcWNciDFsLko(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return dAntuILfYUUPSPWGcWNciDFsLko(P_0.hardwareJoystickMapIdentifier, P_1, P_2);
		}

		private JoystickMap dAntuILfYUUPSPWGcWNciDFsLko(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.QaLWEoBkhPPZHwFxXAQmGTvzudU(guid);
			ControllerMap_Editor controllerMap_Editor = pkHysBrHRzSwMWEVmzaenPLdWdN(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.BXRveYJiGthwHCrxumNHiopILusN(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.viTAFDZZNWpqhySlhxkBuvuTuVi(guid, P_1, P_2);
				return joystickMap;
			}
			if (hardwareJoystickMap != null)
			{
				foreach (Guid templateGuid in hardwareJoystickMap.TemplateGuids)
				{
					if (templateGuid == Guid.Empty)
					{
						continue;
					}
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.WXZzghlyGEKLVUqxSWMufmDMvxn(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = pkHysBrHRzSwMWEVmzaenPLdWdN(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = xoZbZGahKvXiXvaNBaeCOAkzVhW(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.viTAFDZZNWpqhySlhxkBuvuTuVi(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = pkHysBrHRzSwMWEVmzaenPLdWdN(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.BXRveYJiGthwHCrxumNHiopILusN(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.viTAFDZZNWpqhySlhxkBuvuTuVi(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.cPddxWgeQLKoABjtJFakbMLbPOFb(guid, P_1, P_2);
		}

		private ControllerMap_Editor pkHysBrHRzSwMWEVmzaenPLdWdN(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = sWzunTXUnItUpofuIezysWjorit(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor sWzunTXUnItUpofuIezysWjorit(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				yhXYBBWwlKwOvhrNEcxednbKdwp(list, joystickLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_0)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		private JoystickMap xoZbZGahKvXiXvaNBaeCOAkzVhW(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.oERSJxXTExfRHjgmEaCWwoaqHFN(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError(string.Concat("Error remapping joystick template ", P_2.Guid, " to joystick ", P_0.guid, "\nReason: ", text));
				return null;
			}
			return controllerMap_Editor.BXRveYJiGthwHCrxumNHiopILusN(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap OwsuJWLTJdOsbRCMIrsZzaZlaHig(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.QaLWEoBkhPPZHwFxXAQmGTvzudU(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.QaLWEoBkhPPZHwFxXAQmGTvzudU(Guid.Empty);
			if (hardwareJoystickMap2 == null)
			{
				return null;
			}
			hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, isDefaultMap: false, out var buttons, out var axes);
			if (buttons == null && axes == null)
			{
				return null;
			}
			bool flag = false;
			List<int> list = new List<int>();
			foreach (ActionElementMap allMap in P_0.AllMaps)
			{
				ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(allMap._elementIdentifierId);
				if (elementIdentifier != null)
				{
					string name = elementIdentifier.name;
					if (!string.IsNullOrEmpty(name))
					{
						int num = 0;
						int num2 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
						if (num2 < 0)
						{
							num2 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
							num = 1;
						}
						if (num2 >= 0 && (num != 0 || buttons != null) && (num != 1 || axes != null))
						{
							string text = Regex.Replace(name, "[^0-9]+", "");
							Logger.Log(text);
							if (int.TryParse(text, out var result))
							{
								if (num == 0)
								{
									if (result < buttons.Length)
									{
										allMap._elementIdentifierId = buttons[result];
										goto IL_0124;
									}
								}
								else if (result < axes.Length)
								{
									allMap._elementIdentifierId = axes[result];
									goto IL_0124;
								}
							}
						}
					}
				}
				list.Add(allMap.fOjavGziuUSawAgvwyVARpyRBVx);
				continue;
				IL_0124:
				flag = true;
			}
			for (int i = 0; i < list.Count; i++)
			{
				P_0.DeleteElementMap(list[i]);
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
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return keyboardMaps[i];
				}
			}
			return null;
		}

		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return keyboardMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId && StringTools.ToGuid(keyboardMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				keyboardMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			keyboardMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteKeyboardMap(int id)
		{
			if (keyboardMaps == null)
			{
				return;
			}
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].id == id)
				{
					keyboardMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateKeyboardMap(int index)
		{
			if (keyboardMaps == null || index < 0 || index >= keyboardMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
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
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].id == id)
				{
					keyboardMapIndex = i;
					return keyboardMaps[i];
				}
			}
			return null;
		}

		public KeyboardMap FindKeyboardMap_Game(Keyboard keyboard, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = AzckrvUFzsSJZOwBweBMpoCfiVi(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.KwfOJnXLMpymzikcNMzwApPJcxo(containsActionDelegate);
				keyboardMap.viTAFDZZNWpqhySlhxkBuvuTuVi(keyboard.EAIQLWgbsQDNGcJuOWaoPBaXKTl, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.cPddxWgeQLKoABjtJFakbMLbPOFb(keyboard.EAIQLWgbsQDNGcJuOWaoPBaXKTl, categoryId, layoutId);
			}
			return keyboardMap;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return mouseMaps[i];
				}
			}
			return null;
		}

		public int GetMouseMapId(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return mouseMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId && StringTools.ToGuid(mouseMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				mouseMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewMouseMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			mouseMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteMouseMap(int id)
		{
			if (mouseMaps == null)
			{
				return;
			}
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].id == id)
				{
					mouseMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateMouseMap(int index)
		{
			if (mouseMaps == null || index < 0 || index >= mouseMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
			controllerMap_Editor.id = GetNewMouseMapId();
			mouseMaps.Add(controllerMap_Editor);
			return mouseMaps.Count - 1;
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].id == id)
				{
					mouseMapIndex = i;
					return mouseMaps[i];
				}
			}
			return null;
		}

		public MouseMap FindMouseMap_Game(Mouse mouse, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = AzckrvUFzsSJZOwBweBMpoCfiVi(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.PVnofDGBurSbjOzoPESgXvbEMmt(containsActionDelegate);
				mouseMap.viTAFDZZNWpqhySlhxkBuvuTuVi(mouse.EAIQLWgbsQDNGcJuOWaoPBaXKTl, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.cPddxWgeQLKoABjtJFakbMLbPOFb(mouse.EAIQLWgbsQDNGcJuOWaoPBaXKTl, categoryId, layoutId);
			}
			return mouseMap;
		}

		public bool HasMouseMapInCategory(int categoryId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
				{
					return customControllerMaps[i];
				}
			}
			return null;
		}

		public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
		{
			customControllerMapIndex = -1;
			if (customControllerMaps == null)
			{
				return null;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].id == mapId)
				{
					customControllerMapIndex = i;
					return customControllerMaps[i];
				}
			}
			return null;
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid)
				{
					list.Add(customControllerMaps[i]);
				}
			}
			return list;
		}

		public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
				{
					return customControllerMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].id == mapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].id == mapId)
				{
					return true;
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
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid && customControllerMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				customControllerMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = string.Empty;
			controllerMap_Editor.customControllerUid = controllerUid;
			customControllerMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].id == mapId)
				{
					customControllerMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateCustomControllerMap(int index)
		{
			if (customControllerMaps == null || index < 0 || index >= customControllerMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = customControllerMaps[index].Clone();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			customControllerMaps.Add(controllerMap_Editor);
			return customControllerMaps.Count - 1;
		}

		internal CustomControllerMap AuMvOlnFHBkcQXDNUsENAfSzNfH(Guid P_0, int P_1, int P_2)
		{
			return AuMvOlnFHBkcQXDNUsENAfSzNfH(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap AuMvOlnFHBkcQXDNUsENAfSzNfH(int P_0, int P_1, int P_2)
		{
			return AuMvOlnFHBkcQXDNUsENAfSzNfH(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap AuMvOlnFHBkcQXDNUsENAfSzNfH(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = qNpetRJBeJDkjaGucMunwaUuPjcY(P_1, id, P_2, false);
			CustomControllerMap customControllerMap;
			if (controllerMap_Editor != null)
			{
				customControllerMap = controllerMap_Editor.pQcUsRpQvjhuorbCMtVOEaxZenk(ContainsAction, P_0);
				customControllerMap.viTAFDZZNWpqhySlhxkBuvuTuVi(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			customControllerMap = CustomControllerMap.cPddxWgeQLKoABjtJFakbMLbPOFb(P_0.typeGuid, id, P_1, P_2);
			customControllerMap.viTAFDZZNWpqhySlhxkBuvuTuVi(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap;
		}

		private ControllerMap_Editor qNpetRJBeJDkjaGucMunwaUuPjcY(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = AbQPYBoSngKwXKdWkKwjeeZZDAr(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor AbQPYBoSngKwXKdWkKwjeeZZDAr(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				yhXYBBWwlKwOvhrNEcxednbKdwp(list, customControllerLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_0)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				DeleteJoystickMap(id);
				break;
			case ControllerType.Keyboard:
				DeleteKeyboardMap(id);
				break;
			case ControllerType.Mouse:
				DeleteMouseMap(id);
				break;
			case ControllerType.Custom:
				DeleteCustomControllerMap(id);
				break;
			default:
				throw new NotImplementedException();
			}
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
					return null;
				}
				return customControllerMaps[index];
			default:
				throw new NotImplementedException();
			}
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			return controllerType switch
			{
				ControllerType.Joystick => GetJoystickMapById(id, out controllerMapIndex), 
				ControllerType.Keyboard => GetKeyboardMapById(id, out controllerMapIndex), 
				ControllerType.Mouse => GetMouseMapById(id, out controllerMapIndex), 
				ControllerType.Custom => GetCustomControllerMapById(id, out controllerMapIndex), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			return controllerType switch
			{
				ControllerType.Joystick => DuplicateJoystickMap(index), 
				ControllerType.Keyboard => DuplicateKeyboardMap(index), 
				ControllerType.Mouse => DuplicateMouseMap(index), 
				ControllerType.Custom => DuplicateCustomControllerMap(index), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal ControllerTemplateMap eiSwDrNBAkymCImtrGOWbbgubhUY(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.SJjOAkwNzQHHGNAXdRuECtEQYOx();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(hMOmisOdygAQnEafHbiQICagtab());
		}

		public void InsertCustomController(int index)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			if (index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllers.Insert(index, hMOmisOdygAQnEafHbiQICagtab());
		}

		public void DeleteCustomController(int index)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = customControllers[index].id;
			if (customControllerMaps != null)
			{
				for (int num = customControllerMaps.Count - 1; num >= 0; num--)
				{
					if (customControllerMaps[num].customControllerUid == id)
					{
						customControllerMaps.RemoveAt(num);
					}
				}
			}
			customControllers.RemoveAt(index);
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CustomController_Editor customController_Editor = customControllers[index].Clone();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
			customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
			if (index == customControllers.Count - 1)
			{
				customControllers.Add(customController_Editor);
			}
			else
			{
				customControllers.Insert(index + 1, customController_Editor);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = customController_Editor.id;
			int id2 = customControllers[index].id;
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].customControllerUid == id2)
				{
					int num2 = DuplicateCustomControllerMap(num);
					if (num2 >= 0)
					{
						customControllerMaps[num2].customControllerUid = id;
					}
				}
			}
		}

		public int GetCustomControllerMapCount(int controllerUid)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			if (customControllerMaps != null)
			{
				for (int i = 0; i < customControllerMaps.Count; i++)
				{
					if (customControllerMaps[i].customControllerUid == controllerUid)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetCustomControllerIndex(int id)
		{
			if (customControllers == null)
			{
				return 0;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return i;
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
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].name;
			}
			return array;
		}

		public int[] GetCustomControllerIds()
		{
			if (customControllers == null)
			{
				return null;
			}
			int[] array = new int[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].id;
			}
			return array;
		}

		public Guid[] GetCustomControllerGuids()
		{
			if (customControllers == null)
			{
				return null;
			}
			Guid[] array = new Guid[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				ref Guid reference = ref array[i];
				reference = customControllers[i].typeGuid;
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
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomController(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].typeGuid == hardwareTypeGuid)
				{
					return i;
				}
			}
			return -1;
		}

		public string GetCustomControllerNameById(int id)
		{
			if (customControllers != null)
			{
				for (int i = 0; i < customControllers.Count; i++)
				{
					if (customControllers[i].id == id)
					{
						return customControllers[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
			controllerMapLayoutManagerRuleSets.Add(xeknpTEpUPDkALrryVCGjwVrWBl());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, xeknpTEpUPDkALrryVCGjwVrWBl());
		}

		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = controllerMapLayoutManagerRuleSets[index].id;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num = ruleSets.Count - 1; num >= 0; num--)
					{
						if (ruleSets[num] != null && ruleSets[num].id == id)
						{
							ruleSets.RemoveAt(num);
						}
					}
				}
			}
			controllerMapLayoutManagerRuleSets.RemoveAt(index);
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
			if (index == controllerMapLayoutManagerRuleSets.Count - 1)
			{
				controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
			}
			else
			{
				controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
			}
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
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
					{
						if (ruleSets[num2] != null && ruleSets[num2].id == id)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = controllerMapLayoutManagerRuleSets[i].name;
			}
			return array;
		}

		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = controllerMapLayoutManagerRuleSets[i].id;
			}
			return array;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[index];
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[num];
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
				return -1;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
				{
					if (controllerMapLayoutManagerRuleSets[i].id == id)
					{
						return controllerMapLayoutManagerRuleSets[i].name;
					}
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
			controllerMapEnablerRuleSets.Add(mcmvnSTfZsuapcorRDQkWekPGHhi());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, mcmvnSTfZsuapcorRDQkWekPGHhi());
		}

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = controllerMapEnablerRuleSets[index].id;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num = ruleSets.Count - 1; num >= 0; num--)
					{
						if (ruleSets[num] != null && ruleSets[num].id == id)
						{
							ruleSets.RemoveAt(num);
						}
					}
				}
			}
			controllerMapEnablerRuleSets.RemoveAt(index);
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
			if (index == controllerMapEnablerRuleSets.Count - 1)
			{
				controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
			}
			else
			{
				controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
			}
		}

		public int GetControllerMapEnablerRuleSetUsedCount(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
					{
						if (ruleSets[num2] != null && ruleSets[num2].id == id)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public int GetControllerMapEnablerRuleSetIndex(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetControllerMapEnablerRuleSetNames()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapEnablerRuleSets.Count];
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = controllerMapEnablerRuleSets[i].name;
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
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = controllerMapEnablerRuleSets[i].id;
			}
			return array;
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
			if (num < 0)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[num];
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
				return -1;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
				{
					if (controllerMapEnablerRuleSets[i].id == id)
					{
						return controllerMapEnablerRuleSets[i].name;
					}
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

		private Player_Editor EaSmHPRszHnWPAzMkqPioBijTcO()
		{
			Player_Editor player_Editor = new Player_Editor();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName("Player", -1, GetPlayerNames());
			player_Editor.descriptiveName = player_Editor.name;
			player_Editor.startPlaying = true;
			if (players.Count == 1)
			{
				player_Editor.assignMouseOnStart = true;
			}
			player_Editor.assignKeyboardOnStart = true;
			player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
			player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
			return player_Editor;
		}

		private InputAction ilvtqKqoAwfFDdptfJPImOHOLmX()
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

		private InputCategory HnWHDMUcWemAQslaOhEkGGuQkjBH()
		{
			InputCategory inputCategory = new InputCategory();
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName("Category", -1, GetActionCategoryNames());
			inputCategory.descriptiveName = inputCategory.name;
			inputCategory.userAssignable = true;
			return inputCategory;
		}

		private InputBehavior wWqKsbbwDwKgvajJtcfBzBzklqF()
		{
			InputBehavior inputBehavior = new InputBehavior();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames());
			inputBehavior.digitalAxisSimulation = true;
			inputBehavior.digitalAxisSnap = true;
			inputBehavior.digitalAxisInstantReverse = false;
			inputBehavior.digitalAxisGravity = 3f;
			inputBehavior.digitalAxisSensitivity = 3f;
			inputBehavior.mouseXYAxisMode = MouseXYAxisMode.MouseAxis;
			inputBehavior.mouseXYAxisSensitivity = 1f;
			inputBehavior.mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis;
			inputBehavior.mouseOtherAxisSensitivity = 1f;
			inputBehavior.buttonDoublePressSpeed = 0.3f;
			inputBehavior.buttonShortPressTime = 0.25f;
			inputBehavior.buttonShortPressExpiresIn = 0f;
			inputBehavior.buttonLongPressTime = 1f;
			inputBehavior.buttonLongPressExpiresIn = 0f;
			inputBehavior.buttonDeadZone = 0.5f;
			inputBehavior.buttonDownBuffer = 0f;
			return inputBehavior;
		}

		private InputMapCategory ujZpNmLqFFQNFEBrFcRzdovMWdfo()
		{
			InputMapCategory inputMapCategory = new InputMapCategory();
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName("Category", -1, GetMapCategoryNames());
			inputMapCategory.descriptiveName = inputMapCategory.name;
			inputMapCategory.userAssignable = true;
			inputMapCategory.checkConflictsWithAllCategories = true;
			return inputMapCategory;
		}

		private InputLayout vxxBkXxcwdeLEIDKSMtqwZefGGx()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout IAATrtDHqmGrwUggJiiiCDRufiHZ()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout cKVYoUQhcoXFWvGxMdMbIzSHdOfx()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout xEZocrAIjSikZBIFMrfcPnVmFva()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private CustomController_Editor hMOmisOdygAQnEafHbiQICagtab()
		{
			CustomController_Editor customController_Editor = new CustomController_Editor();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
			customController_Editor.name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames());
			customController_Editor.descriptiveName = customController_Editor.name;
			return customController_Editor;
		}

		private ControllerMapLayoutManager_RuleSet_Editor xeknpTEpUPDkALrryVCGjwVrWBl()
		{
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = new ControllerMapLayoutManager_RuleSet_Editor();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames());
			return controllerMapLayoutManager_RuleSet_Editor;
		}

		private ControllerMapEnabler_RuleSet_Editor mcmvnSTfZsuapcorRDQkWekPGHhi()
		{
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = new ControllerMapEnabler_RuleSet_Editor();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames());
			return controllerMapEnabler_RuleSet_Editor;
		}

		private ControllerMap_Editor mNeFiygAZWduZwIpCWxrAxOwpvE(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].categoryId == P_1 && P_0[i].layoutId == P_2)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private ControllerMap_Editor AzckrvUFzsSJZOwBweBMpoCfiVi(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = mNeFiygAZWduZwIpCWxrAxOwpvE(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = joDwGBRuPKhnulDmIaMuEAZnESkt(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor joDwGBRuPKhnulDmIaMuEAZnESkt(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				yhXYBBWwlKwOvhrNEcxednbKdwp(list, P_1);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_2)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		private void yhXYBBWwlKwOvhrNEcxednbKdwp(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			FbGoDLyhmJcUyTCeEWdjRooqlbF fbGoDLyhmJcUyTCeEWdjRooqlbF = new FbGoDLyhmJcUyTCeEWdjRooqlbF();
			fbGoDLyhmJcUyTCeEWdjRooqlbF.jHzmKImaeBuLMiUZFESZZZgQTbo = P_1;
			if (P_0 != null && fbGoDLyhmJcUyTCeEWdjRooqlbF.jHzmKImaeBuLMiUZFESZZZgQTbo != null)
			{
				P_0.Sort(fbGoDLyhmJcUyTCeEWdjRooqlbF.xyzRBWfSivUsmoNsSpYHTOIZFBB);
			}
		}

		internal void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
		{
			Players_readOnly = new ReadOnlyCollection<Player_Editor>(players);
			Actions_readOnly = new ReadOnlyCollection<InputAction>(actions);
			ActionCategories_readOnly = new ReadOnlyCollection<InputCategory>(actionCategories);
			InputBehaviors_readOnly = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			MapCategories_readOnly = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			JoystickLayouts_readOnly = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			KeyboardLayouts_readOnly = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			MouseLayouts_readOnly = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			CustomControllerLayouts_readOnly = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			JoystickMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			KeyboardMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			MouseMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			CustomControllerMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			ControllerMapLayoutManagerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			ControllerMapEnablerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					mapCategories[i].EJpmrTgGvrhKjJnkpXbomYBpQTQ();
				}
			}
			containsActionDelegate = ContainsAction;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return EOBbGZLmWHhOTxhjzoamLlwlEx.XImAuIRApcwcMBrvVxengcVQCDZ(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return EOBbGZLmWHhOTxhjzoamLlwlEx.XImAuIRApcwcMBrvVxengcVQCDZ(orig, null, false);
		}

		[CompilerGenerated]
		private static void GeoxQlLIzvNujLSvvDHMwVGmPgF(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].categoryId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		[CompilerGenerated]
		private static void UrkzxYxhHcOVvgSpKVmOdxDoGdk(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		[CompilerGenerated]
		private static void JXJjumKmnMqJEtAJmkUiQbXZOah(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		[CompilerGenerated]
		private static void zmBDmWaeqrItacWkSPmSHHvHPIPU(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		[CompilerGenerated]
		private static void JIfOyiXvKtKgpMEbecSvkjQKPCM(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}
	}
}
