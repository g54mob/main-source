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
		private static class eMeIxqqaTFSeMCDXccyhspIGbSN
		{
			private class GkyhoIQBeHFACrBfBiSyZKBkYrQ
			{
				public enum DnOdgdfYYHmyBPwdrHiWKceMLvaF
				{
					zBGYaAbJxDBpvRcDluLfJWDVTZt = 0,
					xfjmwOaSRpLpsDYbloVqtAHlbrNI = 1,
					EhetiEzMuFhUxtiWwSximdVKlei = 2
				}

				public int zBGYaAbJxDBpvRcDluLfJWDVTZt;

				public int xfjmwOaSRpLpsDYbloVqtAHlbrNI;

				public int EhetiEzMuFhUxtiWwSximdVKlei;

				public int this[DnOdgdfYYHmyBPwdrHiWKceMLvaF type]
				{
					get
					{
						return type switch
						{
							DnOdgdfYYHmyBPwdrHiWKceMLvaF.zBGYaAbJxDBpvRcDluLfJWDVTZt => zBGYaAbJxDBpvRcDluLfJWDVTZt, 
							DnOdgdfYYHmyBPwdrHiWKceMLvaF.xfjmwOaSRpLpsDYbloVqtAHlbrNI => xfjmwOaSRpLpsDYbloVqtAHlbrNI, 
							DnOdgdfYYHmyBPwdrHiWKceMLvaF.EhetiEzMuFhUxtiWwSximdVKlei => EhetiEzMuFhUxtiWwSximdVKlei, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (type)
						{
						case DnOdgdfYYHmyBPwdrHiWKceMLvaF.zBGYaAbJxDBpvRcDluLfJWDVTZt:
							zBGYaAbJxDBpvRcDluLfJWDVTZt = value;
							break;
						case DnOdgdfYYHmyBPwdrHiWKceMLvaF.xfjmwOaSRpLpsDYbloVqtAHlbrNI:
							xfjmwOaSRpLpsDYbloVqtAHlbrNI = value;
							break;
						case DnOdgdfYYHmyBPwdrHiWKceMLvaF.EhetiEzMuFhUxtiWwSximdVKlei:
							EhetiEzMuFhUxtiWwSximdVKlei = value;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public GkyhoIQBeHFACrBfBiSyZKBkYrQ(int origId, int otherId, int finalId)
				{
					zBGYaAbJxDBpvRcDluLfJWDVTZt = origId;
					xfjmwOaSRpLpsDYbloVqtAHlbrNI = otherId;
					EhetiEzMuFhUxtiWwSximdVKlei = finalId;
				}

				public override string ToString()
				{
					string text = "";
					text += StringTools.WriteVar("origId", zBGYaAbJxDBpvRcDluLfJWDVTZt);
					text += StringTools.WriteVar("otherId", xfjmwOaSRpLpsDYbloVqtAHlbrNI);
					return text + StringTools.WriteVar("finalId", EhetiEzMuFhUxtiWwSximdVKlei);
				}
			}

			private class elxRTNKzwqpQGibvBdnYvpImxhh<T>
			{
				public T ZHkTAJbgICMdPJVCcMTDwfBsSyP;

				public T GwlYqTpXGesqsDLIqyRxnIocAXnG;

				public GkyhoIQBeHFACrBfBiSyZKBkYrQ.DnOdgdfYYHmyBPwdrHiWKceMLvaF ZzWyfYzJmAxYGLMaFQEuROAKagp;

				public IList<T> mFkoHiOtRmUpCevxURSCuJGncCW;

				public bool dPZDkrINXGHUWxKGFjjrCaqgICXv;

				public elxRTNKzwqpQGibvBdnYvpImxhh(T otherItem, T finalItem, GkyhoIQBeHFACrBfBiSyZKBkYrQ.DnOdgdfYYHmyBPwdrHiWKceMLvaF idType, IList<T> finalItems, bool isCollision)
				{
					ZHkTAJbgICMdPJVCcMTDwfBsSyP = otherItem;
					GwlYqTpXGesqsDLIqyRxnIocAXnG = finalItem;
					ZzWyfYzJmAxYGLMaFQEuROAKagp = idType;
					mFkoHiOtRmUpCevxURSCuJGncCW = finalItems;
					dPZDkrINXGHUWxKGFjjrCaqgICXv = isCollision;
				}
			}

			private sealed class UkxxlaLacAhjZgfcHrLynNXtTWB
			{
				private sealed class KFiZUIZCrflHjNkVxDhzkolodEoK
				{
					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public elxRTNKzwqpQGibvBdnYvpImxhh<InputAction> KeXSsfxzHaxvpIOLRbTpatLuCvYy;

					public bool lrKXcBQloZYEoaYrkKTizEeGGWT(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP.categoryId;
					}

					public bool SBYnXJqZZkisWNhqtgIPeYOgnNO(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP.behaviorId;
					}
				}

				private sealed class ToFexieEeUzqIfWaMicgfKdOLygE
				{
					public elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMapLayoutManager_RuleSet_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;
				}

				private sealed class sBXSJjFWqhUiYDZEpxogtveSRcP
				{
					public ToFexieEeUzqIfWaMicgfKdOLygE jgEVVaQiREBdhGWlzfvYEPrSfZZV;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int mcyncWCGTHCtgiqKDxdCxGPwRMm;

					public bool yqBBtUixmPzAPVppOecYvknGFDK(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[jgEVVaQiREBdhGWlzfvYEPrSfZZV.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == mcyncWCGTHCtgiqKDxdCxGPwRMm;
					}
				}

				private sealed class kUKjKnQmdxqJBUoiuLkLFdBhZuX
				{
					public ToFexieEeUzqIfWaMicgfKdOLygE jgEVVaQiREBdhGWlzfvYEPrSfZZV;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int mcyncWCGTHCtgiqKDxdCxGPwRMm;

					public bool GbGGgrDTbcseNdqbzhHJyLCqMnUL(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[jgEVVaQiREBdhGWlzfvYEPrSfZZV.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == mcyncWCGTHCtgiqKDxdCxGPwRMm;
					}
				}

				private sealed class jbCBRZCsUYLUZDTSEfbOlruJEHFT
				{
					public ToFexieEeUzqIfWaMicgfKdOLygE jgEVVaQiREBdhGWlzfvYEPrSfZZV;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int mcyncWCGTHCtgiqKDxdCxGPwRMm;

					public bool jlcVHvLlsHOjQlntlEIZfCUSqUO(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[jgEVVaQiREBdhGWlzfvYEPrSfZZV.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == mcyncWCGTHCtgiqKDxdCxGPwRMm;
					}
				}

				private sealed class WnROZuPzsasiPiJmDwLxxOtPWFj
				{
					public elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMapEnabler_RuleSet_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;
				}

				private sealed class PtbZwcfUsUfbpEhGZesViqJOIlcc
				{
					public WnROZuPzsasiPiJmDwLxxOtPWFj NUNGGyboAvFKsMrcXtCBEKfFhJei;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int mcyncWCGTHCtgiqKDxdCxGPwRMm;

					public bool irobUIFlzibElKUkRNAKGXtvtdrL(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[NUNGGyboAvFKsMrcXtCBEKfFhJei.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == mcyncWCGTHCtgiqKDxdCxGPwRMm;
					}
				}

				private sealed class EcNUQhlJoKGVzNsiEvCnXBwSEGz
				{
					public WnROZuPzsasiPiJmDwLxxOtPWFj NUNGGyboAvFKsMrcXtCBEKfFhJei;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int mcyncWCGTHCtgiqKDxdCxGPwRMm;

					public bool PUwDLBajgijlPnCGwLAabmIdkuMU(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[NUNGGyboAvFKsMrcXtCBEKfFhJei.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == mcyncWCGTHCtgiqKDxdCxGPwRMm;
					}
				}

				private sealed class nPhukHzKMolSvPZjjtzARlmXHqe
				{
					public WnROZuPzsasiPiJmDwLxxOtPWFj NUNGGyboAvFKsMrcXtCBEKfFhJei;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int mcyncWCGTHCtgiqKDxdCxGPwRMm;

					public bool kaYswcqrNLKkRvKiiEkcJzzrFqB(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[NUNGGyboAvFKsMrcXtCBEKfFhJei.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == mcyncWCGTHCtgiqKDxdCxGPwRMm;
					}
				}

				private sealed class LCpYdyiZYZKCBezPecsVjqwhOVC
				{
					private sealed class TJdvearFimUjNelWTgOIkVbeVHth
					{
						public LCpYdyiZYZKCBezPecsVjqwhOVC PLnTvnthoaDLwHpeWbpYfdtpuSfh;

						public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

						public Player_Editor.Mapping QmnsBHpEIboFYisgQWATQkVoDvxc;

						public bool AxfIbJbDBADypHbScMpxieenXwY(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
						{
							return P_0[PLnTvnthoaDLwHpeWbpYfdtpuSfh.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == QmnsBHpEIboFYisgQWATQkVoDvxc.categoryId;
						}

						public bool ilzjWIHazIKriZbFZAjrEajyUZPd(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
						{
							return P_0[PLnTvnthoaDLwHpeWbpYfdtpuSfh.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == QmnsBHpEIboFYisgQWATQkVoDvxc.layoutId;
						}
					}

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public elxRTNKzwqpQGibvBdnYvpImxhh<Player_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;

					public void trlWNopyKKHwQHYgpiUBvKUYXdU(List<Player_Editor.Mapping> P_0, List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> P_1)
					{
						for (int i = 0; i < P_0.Count; i++)
						{
							TJdvearFimUjNelWTgOIkVbeVHth tJdvearFimUjNelWTgOIkVbeVHth = new TJdvearFimUjNelWTgOIkVbeVHth();
							tJdvearFimUjNelWTgOIkVbeVHth.PLnTvnthoaDLwHpeWbpYfdtpuSfh = this;
							tJdvearFimUjNelWTgOIkVbeVHth.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
							tJdvearFimUjNelWTgOIkVbeVHth.QmnsBHpEIboFYisgQWATQkVoDvxc = P_0[i];
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(tJdvearFimUjNelWTgOIkVbeVHth.AxfIbJbDBADypHbScMpxieenXwY);
							tJdvearFimUjNelWTgOIkVbeVHth.QmnsBHpEIboFYisgQWATQkVoDvxc.categoryId = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
							gkyhoIQBeHFACrBfBiSyZKBkYrQ = P_1.Find(tJdvearFimUjNelWTgOIkVbeVHth.ilzjWIHazIKriZbFZAjrEajyUZPd);
							tJdvearFimUjNelWTgOIkVbeVHth.QmnsBHpEIboFYisgQWATQkVoDvxc.layoutId = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
						}
					}
				}

				private sealed class gpaZnItaUVfVQJouzFWHushwVpW
				{
					public LCpYdyiZYZKCBezPecsVjqwhOVC PLnTvnthoaDLwHpeWbpYfdtpuSfh;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public Player_Editor.CreateControllerInfo afRqPnGQripoBdEmFTzWwSWESMg;

					public bool qqZNUqjOUAdczFdWudfgbDdHBQum(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[PLnTvnthoaDLwHpeWbpYfdtpuSfh.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == afRqPnGQripoBdEmFTzWwSWESMg.sourceId;
					}
				}

				private sealed class OFfqICZOAkedFIJvhzzhVALSgzH
				{
					public LCpYdyiZYZKCBezPecsVjqwhOVC PLnTvnthoaDLwHpeWbpYfdtpuSfh;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int RUucinekeLVhzGKuGszOeYlJzub;

					public bool nFvFVmFavHTfzUiuaeZQtXwjRxVm(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[PLnTvnthoaDLwHpeWbpYfdtpuSfh.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == RUucinekeLVhzGKuGszOeYlJzub;
					}
				}

				private sealed class KByKiipeOGRRzeFFVIUksiEyfKxC
				{
					public LCpYdyiZYZKCBezPecsVjqwhOVC PLnTvnthoaDLwHpeWbpYfdtpuSfh;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public int RUucinekeLVhzGKuGszOeYlJzub;

					public bool SZPzLHndCATLPkOyRAbxCiNXdFJj(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[PLnTvnthoaDLwHpeWbpYfdtpuSfh.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == RUucinekeLVhzGKuGszOeYlJzub;
					}
				}

				public UserData GOjmxUUnpAZhvTlUnjrGUkJEtMH;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> LUYOhJYIGxcmlSiFMWeEyyhKbBx;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> DexqfHRdVQWanFiAXbtdnjKnuXR;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> JAOwDNDjUygzCxCIEevNAKjbGZN;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> seQDIwHfkWMkyEnKRNEdwBNvituK;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> OtkbfeEnZdfybijYwKewXvtJHQwj;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> ClXlCXlYmvEfNNIHQuFKTZfHKOS;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> uPsWpvCVbbnLxdWstaVjEQVooqe;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> pxbowoXgybishipDdyyhMOQhqzq;

				public Func<ControllerType, List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>> frNpdKKMbpkrVbnJXEqurlJNRni;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> BxiTiTsqnmmhlZEgNgIeiYDzTGgh;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> MOIbxXOLlcEpOfDMalVfqdOGTQet;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> TxyBvUDYlGcErWHdqFMqIesjWQen;

				private static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> gWpBbeoiMGOcBKqpzaqMCqYuAUq;

				private static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> ztMhgkSDGzgbQDjJTLztbcxCTDbn;

				public InputCategory drZOePwzoPgDyDlfkCGCEGlUdAT(elxRTNKzwqpQGibvBdnYvpImxhh<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputCategory inputCategory2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputCategory2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddActionCategory();
						inputCategory2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					inputCategory.id = inputCategory2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputCategory2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputCategory;
					return inputCategory;
				}

				public InputBehavior tnPxhAejaokEHbiTrKKImHrjuJg(elxRTNKzwqpQGibvBdnYvpImxhh<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputBehavior inputBehavior2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputBehavior2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddInputBehavior();
						inputBehavior2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputBehavior2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputBehavior;
					return inputBehavior;
				}

				public InputAction uFmOoxQplbcfecemQqLyJJkyetKw(elxRTNKzwqpQGibvBdnYvpImxhh<InputAction> P_0)
				{
					KFiZUIZCrflHjNkVxDhzkolodEoK kFiZUIZCrflHjNkVxDhzkolodEoK = new KFiZUIZCrflHjNkVxDhzkolodEoK();
					kFiZUIZCrflHjNkVxDhzkolodEoK.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
					kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					InputAction inputAction = JsonTools.Clone(kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					int num = LUYOhJYIGxcmlSiFMWeEyyhKbBx.Find(kFiZUIZCrflHjNkVxDhzkolodEoK.lrKXcBQloZYEoaYrkKTizEeGGWT)?.EhetiEzMuFhUxtiWwSximdVKlei ?? 0;
					InputAction inputAction2;
					if (kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputAction2 = kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddAction(num);
						inputAction2 = kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					int behaviorId = DexqfHRdVQWanFiAXbtdnjKnuXR.Find(kFiZUIZCrflHjNkVxDhzkolodEoK.SBYnXJqZZkisWNhqtgIPeYOgnNO)?.EhetiEzMuFhUxtiWwSximdVKlei ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = behaviorId;
					int index = kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputAction2);
					kFiZUIZCrflHjNkVxDhzkolodEoK.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputAction;
					return inputAction;
				}

				public InputLayout mtELWcmPDrNJCxYcRJNpuENlLbx(elxRTNKzwqpQGibvBdnYvpImxhh<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputLayout inputLayout2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputLayout2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddKeyboardLayout();
						inputLayout2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputLayout2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout IRGaMfjPkxbcBSQUAVZCxnGUszJ(elxRTNKzwqpQGibvBdnYvpImxhh<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputLayout inputLayout2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputLayout2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddMouseLayout();
						inputLayout2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputLayout2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout iRvcRywbOTJVbzLAKPiDbodGfZJ(elxRTNKzwqpQGibvBdnYvpImxhh<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputLayout inputLayout2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputLayout2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddJoystickLayout();
						inputLayout2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputLayout2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout aYQpxOsCNvgLreVnkiTtwNDKSao(elxRTNKzwqpQGibvBdnYvpImxhh<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputLayout inputLayout2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputLayout2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddCustomControllerLayout();
						inputLayout2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputLayout2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = inputLayout;
					return inputLayout;
				}

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> tJKXtsKKJsEZNNAfCfgPbfYrqapF(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => OtkbfeEnZdfybijYwKewXvtJHQwj, 
						ControllerType.Mouse => ClXlCXlYmvEfNNIHQuFKTZfHKOS, 
						ControllerType.Joystick => uPsWpvCVbbnLxdWstaVjEQVooqe, 
						ControllerType.Custom => pxbowoXgybishipDdyyhMOQhqzq, 
						_ => throw new NotImplementedException(), 
					};
				}

				public CustomController_Editor UjRQiOKfHYgkfBTYCHAdyNgNlSMv(elxRTNKzwqpQGibvBdnYvpImxhh<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					CustomController_Editor customController_Editor2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						customController_Editor2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddCustomController();
						customController_Editor2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(customController_Editor2);
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[index] = customController_Editor;
					return customController_Editor;
				}

				public ControllerMapLayoutManager_RuleSet_Editor xswnYKSQzZWiAtRqiESDvcbSDhN(elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					ToFexieEeUzqIfWaMicgfKdOLygE toFexieEeUzqIfWaMicgfKdOLygE = new ToFexieEeUzqIfWaMicgfKdOLygE();
					toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
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
							sBXSJjFWqhUiYDZEpxogtveSRcP sBXSJjFWqhUiYDZEpxogtveSRcP2 = new sBXSJjFWqhUiYDZEpxogtveSRcP();
							sBXSJjFWqhUiYDZEpxogtveSRcP2.jgEVVaQiREBdhGWlzfvYEPrSfZZV = toFexieEeUzqIfWaMicgfKdOLygE;
							sBXSJjFWqhUiYDZEpxogtveSRcP2.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
							sBXSJjFWqhUiYDZEpxogtveSRcP2.mcyncWCGTHCtgiqKDxdCxGPwRMm = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = seQDIwHfkWMkyEnKRNEdwBNvituK.Find(sBXSJjFWqhUiYDZEpxogtveSRcP2.yqBBtUixmPzAPVppOecYvknGFDK);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + sBXSJjFWqhUiYDZEpxogtveSRcP2.mcyncWCGTHCtgiqKDxdCxGPwRMm);
							}
							else
							{
								list.Add(gkyhoIQBeHFACrBfBiSyZKBkYrQ.EhetiEzMuFhUxtiWwSximdVKlei);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						kUKjKnQmdxqJBUoiuLkLFdBhZuX kUKjKnQmdxqJBUoiuLkLFdBhZuX2 = new kUKjKnQmdxqJBUoiuLkLFdBhZuX();
						kUKjKnQmdxqJBUoiuLkLFdBhZuX2.jgEVVaQiREBdhGWlzfvYEPrSfZZV = toFexieEeUzqIfWaMicgfKdOLygE;
						kUKjKnQmdxqJBUoiuLkLFdBhZuX2.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list2 = frNpdKKMbpkrVbnJXEqurlJNRni(controllerType);
							kUKjKnQmdxqJBUoiuLkLFdBhZuX2.mcyncWCGTHCtgiqKDxdCxGPwRMm = controllerMapLayoutManager_Rule_Editor2.layoutId;
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = list2.Find(kUKjKnQmdxqJBUoiuLkLFdBhZuX2.GbGGgrDTbcseNdqbzhHJyLCqMnUL);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ2 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError(string.Concat("No new ", controllerType, " Layout Id found for old id: ", kUKjKnQmdxqJBUoiuLkLFdBhZuX2.mcyncWCGTHCtgiqKDxdCxGPwRMm));
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei;
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
							jbCBRZCsUYLUZDTSEfbOlruJEHFT jbCBRZCsUYLUZDTSEfbOlruJEHFT2 = new jbCBRZCsUYLUZDTSEfbOlruJEHFT();
							jbCBRZCsUYLUZDTSEfbOlruJEHFT2.jgEVVaQiREBdhGWlzfvYEPrSfZZV = toFexieEeUzqIfWaMicgfKdOLygE;
							jbCBRZCsUYLUZDTSEfbOlruJEHFT2.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
							List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> bxiTiTsqnmmhlZEgNgIeiYDzTGgh = BxiTiTsqnmmhlZEgNgIeiYDzTGgh;
							jbCBRZCsUYLUZDTSEfbOlruJEHFT2.mcyncWCGTHCtgiqKDxdCxGPwRMm = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = bxiTiTsqnmmhlZEgNgIeiYDzTGgh.Find(jbCBRZCsUYLUZDTSEfbOlruJEHFT2.jlcVHvLlsHOjQlntlEIZfCUSqUO);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ3 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + jbCBRZCsUYLUZDTSEfbOlruJEHFT2.mcyncWCGTHCtgiqKDxdCxGPwRMm);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = gkyhoIQBeHFACrBfBiSyZKBkYrQ3.EhetiEzMuFhUxtiWwSximdVKlei;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					toFexieEeUzqIfWaMicgfKdOLygE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				public ControllerMapEnabler_RuleSet_Editor FhWiZMejEKsDWNypkkALHgkcBaHh(elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					WnROZuPzsasiPiJmDwLxxOtPWFj wnROZuPzsasiPiJmDwLxxOtPWFj = new WnROZuPzsasiPiJmDwLxxOtPWFj();
					wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
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
							PtbZwcfUsUfbpEhGZesViqJOIlcc ptbZwcfUsUfbpEhGZesViqJOIlcc = new PtbZwcfUsUfbpEhGZesViqJOIlcc();
							ptbZwcfUsUfbpEhGZesViqJOIlcc.NUNGGyboAvFKsMrcXtCBEKfFhJei = wnROZuPzsasiPiJmDwLxxOtPWFj;
							ptbZwcfUsUfbpEhGZesViqJOIlcc.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
							ptbZwcfUsUfbpEhGZesViqJOIlcc.mcyncWCGTHCtgiqKDxdCxGPwRMm = controllerMapEnabler_Rule_Editor.categoryIds[j];
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = seQDIwHfkWMkyEnKRNEdwBNvituK.Find(ptbZwcfUsUfbpEhGZesViqJOIlcc.irobUIFlzibElKUkRNAKGXtvtdrL);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + ptbZwcfUsUfbpEhGZesViqJOIlcc.mcyncWCGTHCtgiqKDxdCxGPwRMm);
							}
							else
							{
								list.Add(gkyhoIQBeHFACrBfBiSyZKBkYrQ.EhetiEzMuFhUxtiWwSximdVKlei);
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
						List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list2 = frNpdKKMbpkrVbnJXEqurlJNRni(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							EcNUQhlJoKGVzNsiEvCnXBwSEGz ecNUQhlJoKGVzNsiEvCnXBwSEGz = new EcNUQhlJoKGVzNsiEvCnXBwSEGz();
							ecNUQhlJoKGVzNsiEvCnXBwSEGz.NUNGGyboAvFKsMrcXtCBEKfFhJei = wnROZuPzsasiPiJmDwLxxOtPWFj;
							ecNUQhlJoKGVzNsiEvCnXBwSEGz.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
							ecNUQhlJoKGVzNsiEvCnXBwSEGz.mcyncWCGTHCtgiqKDxdCxGPwRMm = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = list2.Find(ecNUQhlJoKGVzNsiEvCnXBwSEGz.PUwDLBajgijlPnCGwLAabmIdkuMU);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ2 == null)
							{
								Logger.LogError(string.Concat("No new ", controllerType, " Layout Id found for old id: ", ecNUQhlJoKGVzNsiEvCnXBwSEGz.mcyncWCGTHCtgiqKDxdCxGPwRMm));
							}
							else
							{
								list3.Add(gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei);
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
							nPhukHzKMolSvPZjjtzARlmXHqe nPhukHzKMolSvPZjjtzARlmXHqe2 = new nPhukHzKMolSvPZjjtzARlmXHqe();
							nPhukHzKMolSvPZjjtzARlmXHqe2.NUNGGyboAvFKsMrcXtCBEKfFhJei = wnROZuPzsasiPiJmDwLxxOtPWFj;
							nPhukHzKMolSvPZjjtzARlmXHqe2.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
							List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> bxiTiTsqnmmhlZEgNgIeiYDzTGgh = BxiTiTsqnmmhlZEgNgIeiYDzTGgh;
							nPhukHzKMolSvPZjjtzARlmXHqe2.mcyncWCGTHCtgiqKDxdCxGPwRMm = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = bxiTiTsqnmmhlZEgNgIeiYDzTGgh.Find(nPhukHzKMolSvPZjjtzARlmXHqe2.kaYswcqrNLKkRvKiiEkcJzzrFqB);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ3 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + nPhukHzKMolSvPZjjtzARlmXHqe2.mcyncWCGTHCtgiqKDxdCxGPwRMm);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = gkyhoIQBeHFACrBfBiSyZKBkYrQ3.EhetiEzMuFhUxtiWwSximdVKlei;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						controllerMapEnabler_RuleSet_Editor2 = wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					wnROZuPzsasiPiJmDwLxxOtPWFj.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				public Player_Editor IplzWeAqqhXFnVJrxUwdsVLhMOd(elxRTNKzwqpQGibvBdnYvpImxhh<Player_Editor> P_0)
				{
					LCpYdyiZYZKCBezPecsVjqwhOVC lCpYdyiZYZKCBezPecsVjqwhOVC = new LCpYdyiZYZKCBezPecsVjqwhOVC();
					lCpYdyiZYZKCBezPecsVjqwhOVC.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
					lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					Player_Editor player_Editor = JsonTools.Clone(lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					Action<List<Player_Editor.Mapping>, List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>> action = lCpYdyiZYZKCBezPecsVjqwhOVC.trlWNopyKKHwQHYgpiUBvKUYXdU;
					action(player_Editor.defaultKeyboardMaps, OtkbfeEnZdfybijYwKewXvtJHQwj);
					action(player_Editor.defaultMouseMaps, ClXlCXlYmvEfNNIHQuFKTZfHKOS);
					action(player_Editor.defaultJoystickMaps, uPsWpvCVbbnLxdWstaVjEQVooqe);
					action(player_Editor.defaultCustomControllerMaps, pxbowoXgybishipDdyyhMOQhqzq);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						gpaZnItaUVfVQJouzFWHushwVpW gpaZnItaUVfVQJouzFWHushwVpW2 = new gpaZnItaUVfVQJouzFWHushwVpW();
						gpaZnItaUVfVQJouzFWHushwVpW2.PLnTvnthoaDLwHpeWbpYfdtpuSfh = lCpYdyiZYZKCBezPecsVjqwhOVC;
						gpaZnItaUVfVQJouzFWHushwVpW2.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
						gpaZnItaUVfVQJouzFWHushwVpW2.afRqPnGQripoBdEmFTzWwSWESMg = player_Editor.startingCustomControllers[i];
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = BxiTiTsqnmmhlZEgNgIeiYDzTGgh.Find(gpaZnItaUVfVQJouzFWHushwVpW2.qqZNUqjOUAdczFdWudfgbDdHBQum);
						gpaZnItaUVfVQJouzFWHushwVpW2.afRqPnGQripoBdEmFTzWwSWESMg.sourceId = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						OFfqICZOAkedFIJvhzzhVALSgzH oFfqICZOAkedFIJvhzzhVALSgzH = new OFfqICZOAkedFIJvhzzhVALSgzH();
						oFfqICZOAkedFIJvhzzhVALSgzH.PLnTvnthoaDLwHpeWbpYfdtpuSfh = lCpYdyiZYZKCBezPecsVjqwhOVC;
						oFfqICZOAkedFIJvhzzhVALSgzH.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							oFfqICZOAkedFIJvhzzhVALSgzH.RUucinekeLVhzGKuGszOeYlJzub = ruleSetMapping.id;
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = MOIbxXOLlcEpOfDMalVfqdOGTQet.Find(oFfqICZOAkedFIJvhzzhVALSgzH.nFvFVmFavHTfzUiuaeZQtXwjRxVm);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ2 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + oFfqICZOAkedFIJvhzzhVALSgzH.RUucinekeLVhzGKuGszOeYlJzub);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						KByKiipeOGRRzeFFVIUksiEyfKxC kByKiipeOGRRzeFFVIUksiEyfKxC = new KByKiipeOGRRzeFFVIUksiEyfKxC();
						kByKiipeOGRRzeFFVIUksiEyfKxC.PLnTvnthoaDLwHpeWbpYfdtpuSfh = lCpYdyiZYZKCBezPecsVjqwhOVC;
						kByKiipeOGRRzeFFVIUksiEyfKxC.GgxAsVodlqRSRkGttBGrZqxoaRED = this;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							kByKiipeOGRRzeFFVIUksiEyfKxC.RUucinekeLVhzGKuGszOeYlJzub = ruleSetMapping2.id;
							GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = TxyBvUDYlGcErWHdqFMqIesjWQen.Find(kByKiipeOGRRzeFFVIUksiEyfKxC.SZPzLHndCATLPkOyRAbxCiNXdFJj);
							if (gkyhoIQBeHFACrBfBiSyZKBkYrQ3 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + kByKiipeOGRRzeFFVIUksiEyfKxC.RUucinekeLVhzGKuGszOeYlJzub);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = gkyhoIQBeHFACrBfBiSyZKBkYrQ3.EhetiEzMuFhUxtiWwSximdVKlei;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						player_Editor2 = lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						if (gWpBbeoiMGOcBKqpzaqMCqYuAUq == null)
						{
							gWpBbeoiMGOcBKqpzaqMCqYuAUq = tKJnNQinMxWIUYQrUywWyriPuNo;
						}
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = gWpBbeoiMGOcBKqpzaqMCqYuAUq;
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						List<Player_Editor.CreateControllerInfo> startingCustomControllers = player_Editor2.startingCustomControllers;
						List<Player_Editor.CreateControllerInfo> startingCustomControllers2 = player_Editor.startingCustomControllers;
						List<Player_Editor.CreateControllerInfo> startingCustomControllers3 = player_Editor3.startingCustomControllers;
						if (ztMhgkSDGzgbQDjJTLztbcxCTDbn == null)
						{
							ztMhgkSDGzgbQDjJTLztbcxCTDbn = YTVxHxNvoZSUKQKVsfhubgKibWT;
						}
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(startingCustomControllers, startingCustomControllers2, startingCustomControllers3, ztMhgkSDGzgbQDjJTLztbcxCTDbn);
						player_Editor = player_Editor3;
					}
					else
					{
						GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddPlayer();
						player_Editor2 = lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(player_Editor2);
					lCpYdyiZYZKCBezPecsVjqwhOVC.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = player_Editor;
					return player_Editor;
				}

				private static int tKJnNQinMxWIUYQrUywWyriPuNo(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				private static int YTVxHxNvoZSUKQKVsfhubgKibWT(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

			private sealed class VEKGMEoXGpwDKUKklaRqkXFmpKOc
			{
				public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

				public List<int> nGYfCLGeZkkgaJHALSQifZeDtmdz;

				public InputMapCategory HTyfExwjClDPGcduBOZvvpvCOExf(elxRTNKzwqpQGibvBdnYvpImxhh<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					InputMapCategory inputMapCategory2;
					if (P_0.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						inputMapCategory2 = P_0.GwlYqTpXGesqsDLIqyRxnIocAXnG;
					}
					else
					{
						GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.AddMapCategory();
						inputMapCategory2 = P_0.mFkoHiOtRmUpCevxURSCuJGncCW[P_0.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					int num = P_0.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(inputMapCategory2);
					if (P_0.ZzWyfYzJmAxYGLMaFQEuROAKagp == GkyhoIQBeHFACrBfBiSyZKBkYrQ.DnOdgdfYYHmyBPwdrHiWKceMLvaF.xfjmwOaSRpLpsDYbloVqtAHlbrNI)
					{
						nGYfCLGeZkkgaJHALSQifZeDtmdz.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.mFkoHiOtRmUpCevxURSCuJGncCW[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class xklmEXuAJGgoDZaGHjdoBeMHfpbG
			{
				public VEKGMEoXGpwDKUKklaRqkXFmpKOc gFQuPsoUGnbUFDIvFJMijlXhYZW;

				public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

				public int xfjmwOaSRpLpsDYbloVqtAHlbrNI;

				public bool fLmzHYehOyFOnUpbUGnssOpBQzp(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
				{
					return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == xfjmwOaSRpLpsDYbloVqtAHlbrNI;
				}
			}

			private sealed class ukAOcKknQLiQfrbHjrghRQDdeIW
			{
				private sealed class OfofgmnpkbgjRvGzwqSYSxXYVJy
				{
					public ukAOcKknQLiQfrbHjrghRQDdeIW EydAXKhtNjXZBvUpuCUbhsXavnP;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor afRqPnGQripoBdEmFTzWwSWESMg;

					public bool ShQSVZYmfwJJBHgYoEtBceMPxneA(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.categoryId;
					}

					public bool cyxDSmDSeeOzdxnYnhozGPFAGCWs(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.layoutId;
					}
				}

				private sealed class BQCTsRwyzzrHgTKdZtwBnqmxahE
				{
					public ukAOcKknQLiQfrbHjrghRQDdeIW EydAXKhtNjXZBvUpuCUbhsXavnP;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor VXEmcMEiFGaBhTLNgIvDEzzpeMpI;

					public elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;

					public bool NNISGrVhKCUOmdZtghFkwmdyizw(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId;
					}

					public bool tisFHeYTsGupgkDGofXMBaUxVva(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId;
					}
				}

				private sealed class wxRicHbNcgBygaPGYYWGzdqoZdo
				{
					public BQCTsRwyzzrHgTKdZtwBnqmxahE EtExFYSGRjgmYHckRajWCiyyqbnB;

					public ukAOcKknQLiQfrbHjrghRQDdeIW EydAXKhtNjXZBvUpuCUbhsXavnP;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ActionElementMap QmnsBHpEIboFYisgQWATQkVoDvxc;

					public bool GSvaZmhdivNFgjpSFDplpaaYhva(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[EtExFYSGRjgmYHckRajWCiyyqbnB.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == QmnsBHpEIboFYisgQWATQkVoDvxc._actionId;
					}
				}

				public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> kCeAlbgcPyDFHbJYJJcNyJfYcvg;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> MEXyectGTCqalAbAqCIXOXbmfoHA;

				public int bYYvxvXkRjFGtLMZrAuxUTOAabUJ(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					OfofgmnpkbgjRvGzwqSYSxXYVJy ofofgmnpkbgjRvGzwqSYSxXYVJy = new OfofgmnpkbgjRvGzwqSYSxXYVJy();
					ofofgmnpkbgjRvGzwqSYSxXYVJy.EydAXKhtNjXZBvUpuCUbhsXavnP = this;
					ofofgmnpkbgjRvGzwqSYSxXYVJy.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					ofofgmnpkbgjRvGzwqSYSxXYVJy.afRqPnGQripoBdEmFTzWwSWESMg = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(ofofgmnpkbgjRvGzwqSYSxXYVJy.ShQSVZYmfwJJBHgYoEtBceMPxneA);
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(ofofgmnpkbgjRvGzwqSYSxXYVJy.cyxDSmDSeeOzdxnYnhozGPFAGCWs);
						if (gkyhoIQBeHFACrBfBiSyZKBkYrQ != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].categoryId && gkyhoIQBeHFACrBfBiSyZKBkYrQ2 != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor UXVpnXMgRkexFwaHtiTwuGJnrwT(elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> P_0)
				{
					BQCTsRwyzzrHgTKdZtwBnqmxahE bQCTsRwyzzrHgTKdZtwBnqmxahE = new BQCTsRwyzzrHgTKdZtwBnqmxahE();
					bQCTsRwyzzrHgTKdZtwBnqmxahE.EydAXKhtNjXZBvUpuCUbhsXavnP = this;
					bQCTsRwyzzrHgTKdZtwBnqmxahE.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = JsonTools.Clone(bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(bQCTsRwyzzrHgTKdZtwBnqmxahE.NNISGrVhKCUOmdZtghFkwmdyizw);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(bQCTsRwyzzrHgTKdZtwBnqmxahE.tisFHeYTsGupgkDGofXMBaUxVva);
					bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId = gkyhoIQBeHFACrBfBiSyZKBkYrQ2?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					for (int i = 0; i < bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps.Count; i++)
					{
						wxRicHbNcgBygaPGYYWGzdqoZdo wxRicHbNcgBygaPGYYWGzdqoZdo2 = new wxRicHbNcgBygaPGYYWGzdqoZdo();
						wxRicHbNcgBygaPGYYWGzdqoZdo2.EtExFYSGRjgmYHckRajWCiyyqbnB = bQCTsRwyzzrHgTKdZtwBnqmxahE;
						wxRicHbNcgBygaPGYYWGzdqoZdo2.EydAXKhtNjXZBvUpuCUbhsXavnP = this;
						wxRicHbNcgBygaPGYYWGzdqoZdo2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
						wxRicHbNcgBygaPGYYWGzdqoZdo2.QmnsBHpEIboFYisgQWATQkVoDvxc = bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps[i];
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = GgxAsVodlqRSRkGttBGrZqxoaRED.JAOwDNDjUygzCxCIEevNAKjbGZN.Find(wxRicHbNcgBygaPGYYWGzdqoZdo2.GSvaZmhdivNFgjpSFDplpaaYhva);
						wxRicHbNcgBygaPGYYWGzdqoZdo2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId = gkyhoIQBeHFACrBfBiSyZKBkYrQ3?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
						wxRicHbNcgBygaPGYYWGzdqoZdo2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionCategoryId = ((GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(wxRicHbNcgBygaPGYYWGzdqoZdo2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId) != null) ? GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(wxRicHbNcgBygaPGYYWGzdqoZdo2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						controllerMap_Editor = bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (MEXyectGTCqalAbAqCIXOXbmfoHA == null)
						{
							MEXyectGTCqalAbAqCIXOXbmfoHA = eOrLaWsSHFiRflDXfnwgxosjIbI;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> mEXyectGTCqalAbAqCIXOXbmfoHA = MEXyectGTCqalAbAqCIXOXbmfoHA;
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(controllerMap_Editor.actionElementMaps, bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps, controllerMap_Editor2.actionElementMaps, mEXyectGTCqalAbAqCIXOXbmfoHA);
						bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = controllerMap_Editor2;
					}
					else
					{
						GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.CreateKeyboardMap(bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId, bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId);
						controllerMap_Editor = bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.id = controllerMap_Editor.id;
					int index = bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(controllerMap_Editor);
					bQCTsRwyzzrHgTKdZtwBnqmxahE.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
					return bQCTsRwyzzrHgTKdZtwBnqmxahE.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
				}

				private static int eOrLaWsSHFiRflDXfnwgxosjIbI(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class uyFREQoYAZCWUKDOUKZYUovvoam
			{
				private sealed class zwBybVeQXodgmtxMLDiJcsEAJSsF
				{
					public uyFREQoYAZCWUKDOUKZYUovvoam aWSTVIwBaMMHkzHteVHSZhbtCHJ;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor afRqPnGQripoBdEmFTzWwSWESMg;

					public bool WayblxBINdhgTXcDDexEGSTxcKhb(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.categoryId;
					}

					public bool RtTrQDdEIBgLnZHbUXqQriCYAMj(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.layoutId;
					}
				}

				private sealed class DxduIzBxZZdEnsWWUfngCEEdfdAb
				{
					public uyFREQoYAZCWUKDOUKZYUovvoam aWSTVIwBaMMHkzHteVHSZhbtCHJ;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor VXEmcMEiFGaBhTLNgIvDEzzpeMpI;

					public elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;

					public bool MQqCegrEeGMySlcZIcihzwNoiMj(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId;
					}

					public bool LEtQVhdWmzPuoYpQOCJTheTdwJX(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId;
					}
				}

				private sealed class iRihFKQAxVcNXJtyJnkLGztOHjD
				{
					public DxduIzBxZZdEnsWWUfngCEEdfdAb kIWVQzbvviApwvKnppIiozDWlRX;

					public uyFREQoYAZCWUKDOUKZYUovvoam aWSTVIwBaMMHkzHteVHSZhbtCHJ;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ActionElementMap QmnsBHpEIboFYisgQWATQkVoDvxc;

					public bool YlVZvycuWHKcbEXBhqupHRJDkni(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[kIWVQzbvviApwvKnppIiozDWlRX.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == QmnsBHpEIboFYisgQWATQkVoDvxc._actionId;
					}
				}

				public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> kCeAlbgcPyDFHbJYJJcNyJfYcvg;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> gnSXJZTinweLduIipUclHATXakKE;

				public int vXuCwKIbAVxJYSzUbDzxDJQPHRj(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					zwBybVeQXodgmtxMLDiJcsEAJSsF zwBybVeQXodgmtxMLDiJcsEAJSsF2 = new zwBybVeQXodgmtxMLDiJcsEAJSsF();
					zwBybVeQXodgmtxMLDiJcsEAJSsF2.aWSTVIwBaMMHkzHteVHSZhbtCHJ = this;
					zwBybVeQXodgmtxMLDiJcsEAJSsF2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					zwBybVeQXodgmtxMLDiJcsEAJSsF2.afRqPnGQripoBdEmFTzWwSWESMg = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(zwBybVeQXodgmtxMLDiJcsEAJSsF2.WayblxBINdhgTXcDDexEGSTxcKhb);
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(zwBybVeQXodgmtxMLDiJcsEAJSsF2.RtTrQDdEIBgLnZHbUXqQriCYAMj);
						if (gkyhoIQBeHFACrBfBiSyZKBkYrQ != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].categoryId && gkyhoIQBeHFACrBfBiSyZKBkYrQ2 != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor rhttRZjTsFhTJWlvxkugoTcPiMG(elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> P_0)
				{
					DxduIzBxZZdEnsWWUfngCEEdfdAb dxduIzBxZZdEnsWWUfngCEEdfdAb = new DxduIzBxZZdEnsWWUfngCEEdfdAb();
					dxduIzBxZZdEnsWWUfngCEEdfdAb.aWSTVIwBaMMHkzHteVHSZhbtCHJ = this;
					dxduIzBxZZdEnsWWUfngCEEdfdAb.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = JsonTools.Clone(dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(dxduIzBxZZdEnsWWUfngCEEdfdAb.MQqCegrEeGMySlcZIcihzwNoiMj);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(dxduIzBxZZdEnsWWUfngCEEdfdAb.LEtQVhdWmzPuoYpQOCJTheTdwJX);
					dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId = gkyhoIQBeHFACrBfBiSyZKBkYrQ2?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					for (int i = 0; i < dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps.Count; i++)
					{
						iRihFKQAxVcNXJtyJnkLGztOHjD iRihFKQAxVcNXJtyJnkLGztOHjD2 = new iRihFKQAxVcNXJtyJnkLGztOHjD();
						iRihFKQAxVcNXJtyJnkLGztOHjD2.kIWVQzbvviApwvKnppIiozDWlRX = dxduIzBxZZdEnsWWUfngCEEdfdAb;
						iRihFKQAxVcNXJtyJnkLGztOHjD2.aWSTVIwBaMMHkzHteVHSZhbtCHJ = this;
						iRihFKQAxVcNXJtyJnkLGztOHjD2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
						iRihFKQAxVcNXJtyJnkLGztOHjD2.QmnsBHpEIboFYisgQWATQkVoDvxc = dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps[i];
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = GgxAsVodlqRSRkGttBGrZqxoaRED.JAOwDNDjUygzCxCIEevNAKjbGZN.Find(iRihFKQAxVcNXJtyJnkLGztOHjD2.YlVZvycuWHKcbEXBhqupHRJDkni);
						iRihFKQAxVcNXJtyJnkLGztOHjD2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId = gkyhoIQBeHFACrBfBiSyZKBkYrQ3?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
						iRihFKQAxVcNXJtyJnkLGztOHjD2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionCategoryId = ((GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(iRihFKQAxVcNXJtyJnkLGztOHjD2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId) != null) ? GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(iRihFKQAxVcNXJtyJnkLGztOHjD2.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						controllerMap_Editor = dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (gnSXJZTinweLduIipUclHATXakKE == null)
						{
							gnSXJZTinweLduIipUclHATXakKE = dosGiWfIQsVRdrzfrHzwHYkPvdr;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> func = gnSXJZTinweLduIipUclHATXakKE;
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(controllerMap_Editor.actionElementMaps, dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = controllerMap_Editor2;
					}
					else
					{
						GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.CreateMouseMap(dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId, dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId);
						controllerMap_Editor = dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.id = controllerMap_Editor.id;
					int index = dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(controllerMap_Editor);
					dxduIzBxZZdEnsWWUfngCEEdfdAb.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
					return dxduIzBxZZdEnsWWUfngCEEdfdAb.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
				}

				private static int dosGiWfIQsVRdrzfrHzwHYkPvdr(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class iJFfgLgXmBXMMPEMAbOPobJwFJc
			{
				private sealed class ebppnfOxhkSOxLldeQNpdvNQlcg
				{
					public iJFfgLgXmBXMMPEMAbOPobJwFJc ZkmeVoLWClCKwBAgJNvhQQREcgYO;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor afRqPnGQripoBdEmFTzWwSWESMg;

					public bool vAyLMNYfYYazVKBRPwpzgLtFask(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.categoryId;
					}

					public bool DsrAphiykBaxQaHECFNjDzAhRFdc(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.layoutId;
					}
				}

				private sealed class icNMBUqrjtPShXzDSPVaEkRSGYKD
				{
					public iJFfgLgXmBXMMPEMAbOPobJwFJc ZkmeVoLWClCKwBAgJNvhQQREcgYO;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor VXEmcMEiFGaBhTLNgIvDEzzpeMpI;

					public elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;

					public bool WRvWbRLtDysOPAVoDEArjySuMsc(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId;
					}

					public bool rXOvWraOmGPRUihhSKkgwcAcUCZ(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId;
					}
				}

				private sealed class CZMnrSZaFKmqBeBTBefrplcweeW
				{
					public icNMBUqrjtPShXzDSPVaEkRSGYKD OaFZMtUBaAaQSYxwPBTjuWBrIoRe;

					public iJFfgLgXmBXMMPEMAbOPobJwFJc ZkmeVoLWClCKwBAgJNvhQQREcgYO;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ActionElementMap QmnsBHpEIboFYisgQWATQkVoDvxc;

					public bool mtYyhfMeoiiTSIJqxxJpwPkUlzaF(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[OaFZMtUBaAaQSYxwPBTjuWBrIoRe.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == QmnsBHpEIboFYisgQWATQkVoDvxc._actionId;
					}
				}

				public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> kCeAlbgcPyDFHbJYJJcNyJfYcvg;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> lZmPXpXabbrgkIevzJJADQWzUtl;

				public int hRnnXyoKSKmaDiapbygnFnEgFfRf(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					ebppnfOxhkSOxLldeQNpdvNQlcg ebppnfOxhkSOxLldeQNpdvNQlcg2 = new ebppnfOxhkSOxLldeQNpdvNQlcg();
					ebppnfOxhkSOxLldeQNpdvNQlcg2.ZkmeVoLWClCKwBAgJNvhQQREcgYO = this;
					ebppnfOxhkSOxLldeQNpdvNQlcg2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					ebppnfOxhkSOxLldeQNpdvNQlcg2.afRqPnGQripoBdEmFTzWwSWESMg = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(ebppnfOxhkSOxLldeQNpdvNQlcg2.vAyLMNYfYYazVKBRPwpzgLtFask);
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(ebppnfOxhkSOxLldeQNpdvNQlcg2.DsrAphiykBaxQaHECFNjDzAhRFdc);
						if (ebppnfOxhkSOxLldeQNpdvNQlcg2.afRqPnGQripoBdEmFTzWwSWESMg.hardwareGuid == P_1[i].hardwareGuid && gkyhoIQBeHFACrBfBiSyZKBkYrQ != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].categoryId && gkyhoIQBeHFACrBfBiSyZKBkYrQ2 != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor rnJQchTJAgQtwXkQQkwsOabZmPm(elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> P_0)
				{
					icNMBUqrjtPShXzDSPVaEkRSGYKD icNMBUqrjtPShXzDSPVaEkRSGYKD2 = new icNMBUqrjtPShXzDSPVaEkRSGYKD();
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.ZkmeVoLWClCKwBAgJNvhQQREcgYO = this;
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = JsonTools.Clone(icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(icNMBUqrjtPShXzDSPVaEkRSGYKD2.WRvWbRLtDysOPAVoDEArjySuMsc);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(icNMBUqrjtPShXzDSPVaEkRSGYKD2.rXOvWraOmGPRUihhSKkgwcAcUCZ);
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId = gkyhoIQBeHFACrBfBiSyZKBkYrQ2?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					for (int i = 0; i < icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps.Count; i++)
					{
						CZMnrSZaFKmqBeBTBefrplcweeW cZMnrSZaFKmqBeBTBefrplcweeW = new CZMnrSZaFKmqBeBTBefrplcweeW();
						cZMnrSZaFKmqBeBTBefrplcweeW.OaFZMtUBaAaQSYxwPBTjuWBrIoRe = icNMBUqrjtPShXzDSPVaEkRSGYKD2;
						cZMnrSZaFKmqBeBTBefrplcweeW.ZkmeVoLWClCKwBAgJNvhQQREcgYO = this;
						cZMnrSZaFKmqBeBTBefrplcweeW.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
						cZMnrSZaFKmqBeBTBefrplcweeW.QmnsBHpEIboFYisgQWATQkVoDvxc = icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps[i];
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = GgxAsVodlqRSRkGttBGrZqxoaRED.JAOwDNDjUygzCxCIEevNAKjbGZN.Find(cZMnrSZaFKmqBeBTBefrplcweeW.mtYyhfMeoiiTSIJqxxJpwPkUlzaF);
						cZMnrSZaFKmqBeBTBefrplcweeW.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId = gkyhoIQBeHFACrBfBiSyZKBkYrQ3?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
						cZMnrSZaFKmqBeBTBefrplcweeW.QmnsBHpEIboFYisgQWATQkVoDvxc._actionCategoryId = ((GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(cZMnrSZaFKmqBeBTBefrplcweeW.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId) != null) ? GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(cZMnrSZaFKmqBeBTBefrplcweeW.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						controllerMap_Editor = icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (lZmPXpXabbrgkIevzJJADQWzUtl == null)
						{
							lZmPXpXabbrgkIevzJJADQWzUtl = AwawRtrUCFnPRuBSeHftphDJkyn;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> func = lZmPXpXabbrgkIevzJJADQWzUtl;
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(controllerMap_Editor.actionElementMaps, icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = controllerMap_Editor2;
					}
					else
					{
						GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.CreateJoystickMap(icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId, icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.hardwareGuid, icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId);
						controllerMap_Editor = icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.id = controllerMap_Editor.id;
					int index = icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(controllerMap_Editor);
					icNMBUqrjtPShXzDSPVaEkRSGYKD2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
					return icNMBUqrjtPShXzDSPVaEkRSGYKD2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
				}

				private static int AwawRtrUCFnPRuBSeHftphDJkyn(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class DYszmDQaEGWJmfKvVkvXtlIgFwb
			{
				private sealed class cemquptMdwTCaQKRjUjiolLpUcM
				{
					public DYszmDQaEGWJmfKvVkvXtlIgFwb dtvzOaYenPtdnuDOTHRMsGlWQSX;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor afRqPnGQripoBdEmFTzWwSWESMg;

					public bool gGnrgZTvlXyrOlGtTrgLGSzlDxg(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.customControllerUid;
					}

					public bool RogDNpzjYeubzxblJHIBYndLuwt(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.categoryId;
					}

					public bool gSxDXmlJPNjLIemLlbeAedcVAWlb(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0.xfjmwOaSRpLpsDYbloVqtAHlbrNI == afRqPnGQripoBdEmFTzWwSWESMg.layoutId;
					}
				}

				private sealed class oeqLIieXQkGtXmoJnUKDBEPSgwb
				{
					public DYszmDQaEGWJmfKvVkvXtlIgFwb dtvzOaYenPtdnuDOTHRMsGlWQSX;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ControllerMap_Editor VXEmcMEiFGaBhTLNgIvDEzzpeMpI;

					public elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> KeXSsfxzHaxvpIOLRbTpatLuCvYy;

					public bool bQnDwSigUrDfHmJdOCcJUpEZkhqG(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.customControllerUid;
					}

					public bool bTGRRQrgyinmOfGKrPuBIMvGREu(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId;
					}

					public bool TCOHDUBmkEiCRFVmqltqBRxdPTM(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId;
					}
				}

				private sealed class ZCpVBmsFsTDjwhcXeosLcmqxbzk
				{
					public oeqLIieXQkGtXmoJnUKDBEPSgwb DpKCiYIwwMbViEsGGeLweYBUJQuZ;

					public DYszmDQaEGWJmfKvVkvXtlIgFwb dtvzOaYenPtdnuDOTHRMsGlWQSX;

					public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

					public ActionElementMap QmnsBHpEIboFYisgQWATQkVoDvxc;

					public bool weBBBWQpIbVNbxjCtLXMjUKNIpI(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
					{
						return P_0[DpKCiYIwwMbViEsGGeLweYBUJQuZ.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZzWyfYzJmAxYGLMaFQEuROAKagp] == QmnsBHpEIboFYisgQWATQkVoDvxc._actionId;
					}
				}

				public UkxxlaLacAhjZgfcHrLynNXtTWB GgxAsVodlqRSRkGttBGrZqxoaRED;

				public List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> kCeAlbgcPyDFHbJYJJcNyJfYcvg;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> ceLOWscMLpVUxFkXuYsiaiOQEVj;

				public int GnDRVGUrXwZwFfmDYXIAwmpMliS(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					cemquptMdwTCaQKRjUjiolLpUcM cemquptMdwTCaQKRjUjiolLpUcM2 = new cemquptMdwTCaQKRjUjiolLpUcM();
					cemquptMdwTCaQKRjUjiolLpUcM2.dtvzOaYenPtdnuDOTHRMsGlWQSX = this;
					cemquptMdwTCaQKRjUjiolLpUcM2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					cemquptMdwTCaQKRjUjiolLpUcM2.afRqPnGQripoBdEmFTzWwSWESMg = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.BxiTiTsqnmmhlZEgNgIeiYDzTGgh.Find(cemquptMdwTCaQKRjUjiolLpUcM2.gGnrgZTvlXyrOlGtTrgLGSzlDxg);
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(cemquptMdwTCaQKRjUjiolLpUcM2.RogDNpzjYeubzxblJHIBYndLuwt);
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(cemquptMdwTCaQKRjUjiolLpUcM2.gSxDXmlJPNjLIemLlbeAedcVAWlb);
						if (gkyhoIQBeHFACrBfBiSyZKBkYrQ != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].customControllerUid && gkyhoIQBeHFACrBfBiSyZKBkYrQ2 != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ2.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].categoryId && gkyhoIQBeHFACrBfBiSyZKBkYrQ3 != null && gkyhoIQBeHFACrBfBiSyZKBkYrQ3.EhetiEzMuFhUxtiWwSximdVKlei == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				public ControllerMap_Editor ajMDfmUSoCHEklUPPLIJokTVyHg(elxRTNKzwqpQGibvBdnYvpImxhh<ControllerMap_Editor> P_0)
				{
					oeqLIieXQkGtXmoJnUKDBEPSgwb oeqLIieXQkGtXmoJnUKDBEPSgwb2 = new oeqLIieXQkGtXmoJnUKDBEPSgwb();
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.dtvzOaYenPtdnuDOTHRMsGlWQSX = this;
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy = P_0;
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = JsonTools.Clone(oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.ZHkTAJbgICMdPJVCcMTDwfBsSyP);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = GgxAsVodlqRSRkGttBGrZqxoaRED.BxiTiTsqnmmhlZEgNgIeiYDzTGgh.Find(oeqLIieXQkGtXmoJnUKDBEPSgwb2.bQnDwSigUrDfHmJdOCcJUpEZkhqG);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ2 = GgxAsVodlqRSRkGttBGrZqxoaRED.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(oeqLIieXQkGtXmoJnUKDBEPSgwb2.bTGRRQrgyinmOfGKrPuBIMvGREu);
					GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ3 = kCeAlbgcPyDFHbJYJJcNyJfYcvg.Find(oeqLIieXQkGtXmoJnUKDBEPSgwb2.TCOHDUBmkEiCRFVmqltqBRxdPTM);
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.customControllerUid = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId = gkyhoIQBeHFACrBfBiSyZKBkYrQ2?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId = gkyhoIQBeHFACrBfBiSyZKBkYrQ3?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					for (int i = 0; i < oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps.Count; i++)
					{
						ZCpVBmsFsTDjwhcXeosLcmqxbzk zCpVBmsFsTDjwhcXeosLcmqxbzk = new ZCpVBmsFsTDjwhcXeosLcmqxbzk();
						zCpVBmsFsTDjwhcXeosLcmqxbzk.DpKCiYIwwMbViEsGGeLweYBUJQuZ = oeqLIieXQkGtXmoJnUKDBEPSgwb2;
						zCpVBmsFsTDjwhcXeosLcmqxbzk.dtvzOaYenPtdnuDOTHRMsGlWQSX = this;
						zCpVBmsFsTDjwhcXeosLcmqxbzk.GgxAsVodlqRSRkGttBGrZqxoaRED = GgxAsVodlqRSRkGttBGrZqxoaRED;
						zCpVBmsFsTDjwhcXeosLcmqxbzk.QmnsBHpEIboFYisgQWATQkVoDvxc = oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps[i];
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ4 = GgxAsVodlqRSRkGttBGrZqxoaRED.JAOwDNDjUygzCxCIEevNAKjbGZN.Find(zCpVBmsFsTDjwhcXeosLcmqxbzk.weBBBWQpIbVNbxjCtLXMjUKNIpI);
						zCpVBmsFsTDjwhcXeosLcmqxbzk.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId = gkyhoIQBeHFACrBfBiSyZKBkYrQ4?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
						zCpVBmsFsTDjwhcXeosLcmqxbzk.QmnsBHpEIboFYisgQWATQkVoDvxc._actionCategoryId = ((GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(zCpVBmsFsTDjwhcXeosLcmqxbzk.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId) != null) ? GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.GetActionById(zCpVBmsFsTDjwhcXeosLcmqxbzk.QmnsBHpEIboFYisgQWATQkVoDvxc._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.dPZDkrINXGHUWxKGFjjrCaqgICXv)
					{
						controllerMap_Editor = oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.GwlYqTpXGesqsDLIqyRxnIocAXnG;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI);
						controllerMap_Editor2.actionElementMaps.Clear();
						if (ceLOWscMLpVUxFkXuYsiaiOQEVj == null)
						{
							ceLOWscMLpVUxFkXuYsiaiOQEVj = HMVmZRgqlVqLfWgjLABKvIUcjLl;
						}
						Func<ActionElementMap, IList<ActionElementMap>, int> func = ceLOWscMLpVUxFkXuYsiaiOQEVj;
						LnTmlEHyuHnTJlPDyeCxdjbZkGw(controllerMap_Editor.actionElementMaps, oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = controllerMap_Editor2;
					}
					else
					{
						GgxAsVodlqRSRkGttBGrZqxoaRED.GOjmxUUnpAZhvTlUnjrGUkJEtMH.CreateCustomControllerMap(oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.categoryId, oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.customControllerUid, oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.layoutId);
						controllerMap_Editor = oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.Count - 1];
					}
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI.id = controllerMap_Editor.id;
					int index = oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW.IndexOf(controllerMap_Editor);
					oeqLIieXQkGtXmoJnUKDBEPSgwb2.KeXSsfxzHaxvpIOLRbTpatLuCvYy.mFkoHiOtRmUpCevxURSCuJGncCW[index] = oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
					return oeqLIieXQkGtXmoJnUKDBEPSgwb2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI;
				}

				private static int HMVmZRgqlVqLfWgjLABKvIUcjLl(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class SzusrcmBJFDZPOxILrnNEfChbxf<T> where T : class
			{
				public Func<T, int> uXAzYqkGMYVJOZwEqdnuxJIgmWr;
			}

			private sealed class omuzLqnIcFUOrjSKHCYzqHyIOHK<T> where T : class
			{
				public SzusrcmBJFDZPOxILrnNEfChbxf<T> zOWEVeHXwbzRmjRsyQbayFZnDFzF;

				public T VXEmcMEiFGaBhTLNgIvDEzzpeMpI;

				public bool QpAuIpXleNSEHtfeLoUqMkmPbxId(GkyhoIQBeHFACrBfBiSyZKBkYrQ P_0)
				{
					return P_0.EhetiEzMuFhUxtiWwSximdVKlei == zOWEVeHXwbzRmjRsyQbayFZnDFzF.uXAzYqkGMYVJOZwEqdnuxJIgmWr(VXEmcMEiFGaBhTLNgIvDEzzpeMpI);
				}
			}

			[CompilerGenerated]
			private static Func<InputCategory, int> PmeoLENjVdqradxzAbNULklxmtj;

			[CompilerGenerated]
			private static Func<InputCategory, string> FAvhTPDqUaDKTodCdpatGpqANdgh;

			[CompilerGenerated]
			private static Func<InputCategory, IList<InputCategory>, int> YIeVAjKvJscyFSsxZeHPjPZXstX;

			[CompilerGenerated]
			private static Func<InputBehavior, int> RwBlWWTuhVfOyIBofGvDMzVuOiZ;

			[CompilerGenerated]
			private static Func<InputBehavior, string> lBwChDiMCNpkGIBYkPNeCKjDtZcu;

			[CompilerGenerated]
			private static Func<InputBehavior, IList<InputBehavior>, int> gEEAMjMGzVgbOcXUGNTXxUWFyKc;

			[CompilerGenerated]
			private static Func<InputAction, int> fQrGpdZezgSgJksuSNnrkXZEsCE;

			[CompilerGenerated]
			private static Func<InputAction, string> gFMlHseAbAVLtwzNXBaWRLiDwnA;

			[CompilerGenerated]
			private static Func<InputAction, IList<InputAction>, int> RGSYrKwtHSzOFOIyKaiyRzDOWcR;

			[CompilerGenerated]
			private static Func<InputMapCategory, int> FUWNJDRoeqqdnYFGRAajsEFfbOE;

			[CompilerGenerated]
			private static Func<InputMapCategory, string> deNUqzIpdkwpUUlsZUyhJKmnFYa;

			[CompilerGenerated]
			private static Func<InputMapCategory, IList<InputMapCategory>, int> leBGNzZPNYgnbdvKTwwXMiTqcScL;

			[CompilerGenerated]
			private static Func<InputLayout, int> PFTcWxhovySeFDIOHuocNKsQRsSH;

			[CompilerGenerated]
			private static Func<InputLayout, string> BAJCdqdfTjaNzaPtFePgWeHIOrNi;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> LLrAHJDMLMtpnbvrfBHTUOgniOrW;

			[CompilerGenerated]
			private static Func<InputLayout, int> bFwbxkxIZicwTfmVFCEFGCxaHXG;

			[CompilerGenerated]
			private static Func<InputLayout, string> QfZvnpmzBIJcoRyzADnZxDHbHCe;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> XGnfvVrlJCGJedJzUgNQDIkBkegL;

			[CompilerGenerated]
			private static Func<InputLayout, int> IQgdXlRTMLbWURbPUfOnafpHisCe;

			[CompilerGenerated]
			private static Func<InputLayout, string> TdMnWRHxcwotmBdTUrJaPVKbJPp;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> vbHNKULaUzykOQfxIkBEUxCXKHK;

			[CompilerGenerated]
			private static Func<InputLayout, int> RATwUXRUgLIdlpFJYHssbcpTfLA;

			[CompilerGenerated]
			private static Func<InputLayout, string> ZAXyhAORkPjPoGqtTDjxyRjunec;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> XgmDffEoFuSmqzgfOrCpdomobTF;

			[CompilerGenerated]
			private static Func<CustomController_Editor, int> tNUdZJyWvqSoJIpSowERhRlFNcF;

			[CompilerGenerated]
			private static Func<CustomController_Editor, string> OnzEFdkTdXrMxnZxLPuAeOhgJmf;

			[CompilerGenerated]
			private static Func<CustomController_Editor, IList<CustomController_Editor>, int> dVAueVTvajSfqAVOzuhyxDSdEEhi;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, int> WdZpVCxMUZELfgmhXbeLgJgEOtZ;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, string> yjUZeyicHgqPOXivHanoODrZggK;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> eLFvgefVkCRmRWrQbCMvDMCljOPd;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, int> ZXyHGCquOVSjOnFmrQvBPhtWAAQj;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, string> iEuVIOEBQrDzUcJLcVlNBIqddcY;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> cnWAsqaUNGeGqBQJCqbCHIJTdKqT;

			[CompilerGenerated]
			private static Func<Player_Editor, int> UQObpUihGUQDQDtKpDCkPdAVvZCb;

			[CompilerGenerated]
			private static Func<Player_Editor, string> iHPPfqzYEOHBfpWIUDthlramQEX;

			[CompilerGenerated]
			private static Func<Player_Editor, IList<Player_Editor>, int> uJtnRxUlHvXCjPhOCNbTKsmNJcu;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> DZDmYhVLaICMUHhWNOjWxZfesZV;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> vLBGhgfSLnOiHMgKzGutPKjfttPM;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> MupiluRUHPwXTScnMOfKlYJVFOz;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> qgVijfKzrzOWdrlypTAFBITUBvxa;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> QcodzUCqNlBnuHCiiBycmokXEhqm;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> PZJXduFhUaCvhgcWkhpHWWYLYok;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> mzhSwaMpIBprLAVuDxGNJSQtIDt;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> oGFlfTNFPCGwjvUtPcpTcUpwkxhr;

			public static UserData hPOzNiwavldFMYQXIDniqgXapIz(UserData P_0, UserData P_1, bool P_2)
			{
				UkxxlaLacAhjZgfcHrLynNXtTWB ukxxlaLacAhjZgfcHrLynNXtTWB = new UkxxlaLacAhjZgfcHrLynNXtTWB();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH = (P_2 ? P_0 : new UserData(init: false));
				if (P_1 != null)
				{
					ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.configVars = JsonTools.Clone(P_1.configVars);
				}
				ukxxlaLacAhjZgfcHrLynNXtTWB.LUYOhJYIGxcmlSiFMWeEyyhKbBx = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Action Category", P_0.actionCategories, P_1?.actionCategories, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.actionCategories, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.LUYOhJYIGxcmlSiFMWeEyyhKbBx, (InputCategory inputCategory) => inputCategory.id, (InputCategory inputCategory) => inputCategory.name, delegate(InputCategory inputCategory, IList<InputCategory> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputCategory.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.drZOePwzoPgDyDlfkCGCEGlUdAT);
				ukxxlaLacAhjZgfcHrLynNXtTWB.DexqfHRdVQWanFiAXbtdnjKnuXR = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.inputBehaviors, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.DexqfHRdVQWanFiAXbtdnjKnuXR, (InputBehavior inputBehavior) => inputBehavior.id, (InputBehavior inputBehavior) => inputBehavior.name, delegate(InputBehavior inputBehavior, IList<InputBehavior> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputBehavior.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.tnPxhAejaokEHbiTrKKImHrjuJg);
				ukxxlaLacAhjZgfcHrLynNXtTWB.JAOwDNDjUygzCxCIEevNAKjbGZN = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Action", P_0.actions, P_1?.actions, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.actions, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.JAOwDNDjUygzCxCIEevNAKjbGZN, (InputAction inputAction) => inputAction.id, (InputAction inputAction) => inputAction.name, delegate(InputAction inputAction, IList<InputAction> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputAction.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.uFmOoxQplbcfecemQqLyJJkyetKw);
				ukxxlaLacAhjZgfcHrLynNXtTWB.seQDIwHfkWMkyEnKRNEdwBNvituK = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				VEKGMEoXGpwDKUKklaRqkXFmpKOc vEKGMEoXGpwDKUKklaRqkXFmpKOc = new VEKGMEoXGpwDKUKklaRqkXFmpKOc();
				vEKGMEoXGpwDKUKklaRqkXFmpKOc.GgxAsVodlqRSRkGttBGrZqxoaRED = ukxxlaLacAhjZgfcHrLynNXtTWB;
				vEKGMEoXGpwDKUKklaRqkXFmpKOc.nGYfCLGeZkkgaJHALSQifZeDtmdz = new List<int>();
				gBSiFpYWXorckapMarJfvQFDfFR("Map Category", P_0.mapCategories, P_1?.mapCategories, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.mapCategories, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.seQDIwHfkWMkyEnKRNEdwBNvituK, (InputMapCategory inputMapCategory2) => inputMapCategory2.id, (InputMapCategory inputMapCategory2) => inputMapCategory2.name, delegate(InputMapCategory inputMapCategory2, IList<InputMapCategory> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputMapCategory2.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, vEKGMEoXGpwDKUKklaRqkXFmpKOc.HTyfExwjClDPGcduBOZvvpvCOExf);
				for (int num = 0; num < vEKGMEoXGpwDKUKklaRqkXFmpKOc.nGYfCLGeZkkgaJHALSQifZeDtmdz.Count; num++)
				{
					int index = vEKGMEoXGpwDKUKklaRqkXFmpKOc.nGYfCLGeZkkgaJHALSQifZeDtmdz[num];
					InputMapCategory inputMapCategory = ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.mapCategories[index];
					for (int num2 = 0; num2 < inputMapCategory.checkConflictsCategoryIds_orig.Count; num2++)
					{
						xklmEXuAJGgoDZaGHjdoBeMHfpbG xklmEXuAJGgoDZaGHjdoBeMHfpbG2 = new xklmEXuAJGgoDZaGHjdoBeMHfpbG();
						xklmEXuAJGgoDZaGHjdoBeMHfpbG2.gFQuPsoUGnbUFDIvFJMijlXhYZW = vEKGMEoXGpwDKUKklaRqkXFmpKOc;
						xklmEXuAJGgoDZaGHjdoBeMHfpbG2.GgxAsVodlqRSRkGttBGrZqxoaRED = ukxxlaLacAhjZgfcHrLynNXtTWB;
						xklmEXuAJGgoDZaGHjdoBeMHfpbG2.xfjmwOaSRpLpsDYbloVqtAHlbrNI = inputMapCategory.checkConflictsCategoryIds_orig[num2];
						GkyhoIQBeHFACrBfBiSyZKBkYrQ gkyhoIQBeHFACrBfBiSyZKBkYrQ = ukxxlaLacAhjZgfcHrLynNXtTWB.seQDIwHfkWMkyEnKRNEdwBNvituK.Find(xklmEXuAJGgoDZaGHjdoBeMHfpbG2.fLmzHYehOyFOnUpbUGnssOpBQzp);
						inputMapCategory.checkConflictsCategoryIds_orig[num2] = gkyhoIQBeHFACrBfBiSyZKBkYrQ?.EhetiEzMuFhUxtiWwSximdVKlei ?? (-1);
					}
				}
				ukxxlaLacAhjZgfcHrLynNXtTWB.OtkbfeEnZdfybijYwKewXvtJHQwj = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.keyboardLayouts, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.OtkbfeEnZdfybijYwKewXvtJHQwj, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.mtELWcmPDrNJCxYcRJNpuENlLbx);
				ukxxlaLacAhjZgfcHrLynNXtTWB.ClXlCXlYmvEfNNIHQuFKTZfHKOS = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.mouseLayouts, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.ClXlCXlYmvEfNNIHQuFKTZfHKOS, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.IRGaMfjPkxbcBSQUAVZCxnGUszJ);
				ukxxlaLacAhjZgfcHrLynNXtTWB.uPsWpvCVbbnLxdWstaVjEQVooqe = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.joystickLayouts, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.uPsWpvCVbbnLxdWstaVjEQVooqe, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.iRvcRywbOTJVbzLAKPiDbodGfZJ);
				ukxxlaLacAhjZgfcHrLynNXtTWB.pxbowoXgybishipDdyyhMOQhqzq = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.customControllerLayouts, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.pxbowoXgybishipDdyyhMOQhqzq, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(inputLayout.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.aYQpxOsCNvgLreVnkiTtwNDKSao);
				ukxxlaLacAhjZgfcHrLynNXtTWB.frNpdKKMbpkrVbnJXEqurlJNRni = ukxxlaLacAhjZgfcHrLynNXtTWB.tJKXtsKKJsEZNNAfCfgPbfYrqapF;
				ukxxlaLacAhjZgfcHrLynNXtTWB.BxiTiTsqnmmhlZEgNgIeiYDzTGgh = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Custom Controller", P_0.customControllers, P_1?.customControllers, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.customControllers, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.BxiTiTsqnmmhlZEgNgIeiYDzTGgh, (CustomController_Editor customController_Editor) => customController_Editor.id, (CustomController_Editor customController_Editor) => customController_Editor.name, delegate(CustomController_Editor customController_Editor, IList<CustomController_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(customController_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.UjRQiOKfHYgkfBTYCHAdyNgNlSMv);
				ukxxlaLacAhjZgfcHrLynNXtTWB.MOIbxXOLlcEpOfDMalVfqdOGTQet = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.controllerMapLayoutManagerRuleSets, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.MOIbxXOLlcEpOfDMalVfqdOGTQet, (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.id, (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.name, delegate(ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(controllerMapLayoutManager_RuleSet_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.xswnYKSQzZWiAtRqiESDvcbSDhN);
				ukxxlaLacAhjZgfcHrLynNXtTWB.TxyBvUDYlGcErWHdqFMqIesjWQen = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.controllerMapEnablerRuleSets, P_2, ukxxlaLacAhjZgfcHrLynNXtTWB.TxyBvUDYlGcErWHdqFMqIesjWQen, (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.id, (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.name, delegate(ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(controllerMapEnabler_RuleSet_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.FhWiZMejEKsDWNypkkALHgkcBaHh);
				List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				gBSiFpYWXorckapMarJfvQFDfFR("Player", P_0.players, P_1?.players, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.players, P_2, list, (Player_Editor player_Editor) => player_Editor.id, (Player_Editor player_Editor) => player_Editor.name, delegate(Player_Editor player_Editor, IList<Player_Editor> list6)
				{
					for (int i = 0; i < list6.Count; i++)
					{
						if (string.Equals(player_Editor.name, list6[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}, ukxxlaLacAhjZgfcHrLynNXtTWB.IplzWeAqqhXFnVJrxUwdsVLhMOd);
				List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list2 = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				ukAOcKknQLiQfrbHjrghRQDdeIW ukAOcKknQLiQfrbHjrghRQDdeIW2 = new ukAOcKknQLiQfrbHjrghRQDdeIW();
				ukAOcKknQLiQfrbHjrghRQDdeIW2.GgxAsVodlqRSRkGttBGrZqxoaRED = ukxxlaLacAhjZgfcHrLynNXtTWB;
				ukAOcKknQLiQfrbHjrghRQDdeIW2.kCeAlbgcPyDFHbJYJJcNyJfYcvg = ukxxlaLacAhjZgfcHrLynNXtTWB.OtkbfeEnZdfybijYwKewXvtJHQwj;
				gBSiFpYWXorckapMarJfvQFDfFR("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.keyboardMaps, P_2, list2, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, ukAOcKknQLiQfrbHjrghRQDdeIW2.bYYvxvXkRjFGtLMZrAuxUTOAabUJ, ukAOcKknQLiQfrbHjrghRQDdeIW2.UXVpnXMgRkexFwaHtiTwuGJnrwT);
				List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list3 = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				uyFREQoYAZCWUKDOUKZYUovvoam uyFREQoYAZCWUKDOUKZYUovvoam2 = new uyFREQoYAZCWUKDOUKZYUovvoam();
				uyFREQoYAZCWUKDOUKZYUovvoam2.GgxAsVodlqRSRkGttBGrZqxoaRED = ukxxlaLacAhjZgfcHrLynNXtTWB;
				uyFREQoYAZCWUKDOUKZYUovvoam2.kCeAlbgcPyDFHbJYJJcNyJfYcvg = ukxxlaLacAhjZgfcHrLynNXtTWB.ClXlCXlYmvEfNNIHQuFKTZfHKOS;
				gBSiFpYWXorckapMarJfvQFDfFR("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.mouseMaps, P_2, list3, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, uyFREQoYAZCWUKDOUKZYUovvoam2.vXuCwKIbAVxJYSzUbDzxDJQPHRj, uyFREQoYAZCWUKDOUKZYUovvoam2.rhttRZjTsFhTJWlvxkugoTcPiMG);
				List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list4 = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				iJFfgLgXmBXMMPEMAbOPobJwFJc iJFfgLgXmBXMMPEMAbOPobJwFJc2 = new iJFfgLgXmBXMMPEMAbOPobJwFJc();
				iJFfgLgXmBXMMPEMAbOPobJwFJc2.GgxAsVodlqRSRkGttBGrZqxoaRED = ukxxlaLacAhjZgfcHrLynNXtTWB;
				iJFfgLgXmBXMMPEMAbOPobJwFJc2.kCeAlbgcPyDFHbJYJJcNyJfYcvg = ukxxlaLacAhjZgfcHrLynNXtTWB.uPsWpvCVbbnLxdWstaVjEQVooqe;
				gBSiFpYWXorckapMarJfvQFDfFR("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.joystickMaps, P_2, list4, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, iJFfgLgXmBXMMPEMAbOPobJwFJc2.hRnnXyoKSKmaDiapbygnFnEgFfRf, iJFfgLgXmBXMMPEMAbOPobJwFJc2.rnJQchTJAgQtwXkQQkwsOabZmPm);
				List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> list5 = new List<GkyhoIQBeHFACrBfBiSyZKBkYrQ>();
				DYszmDQaEGWJmfKvVkvXtlIgFwb dYszmDQaEGWJmfKvVkvXtlIgFwb = new DYszmDQaEGWJmfKvVkvXtlIgFwb();
				dYszmDQaEGWJmfKvVkvXtlIgFwb.GgxAsVodlqRSRkGttBGrZqxoaRED = ukxxlaLacAhjZgfcHrLynNXtTWB;
				dYszmDQaEGWJmfKvVkvXtlIgFwb.kCeAlbgcPyDFHbJYJJcNyJfYcvg = ukxxlaLacAhjZgfcHrLynNXtTWB.pxbowoXgybishipDdyyhMOQhqzq;
				gBSiFpYWXorckapMarJfvQFDfFR("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH.customControllerMaps, P_2, list5, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, dYszmDQaEGWJmfKvVkvXtlIgFwb.GnDRVGUrXwZwFfmDYXIAwmpMliS, dYszmDQaEGWJmfKvVkvXtlIgFwb.ajMDfmUSoCHEklUPPLIJokTVyHg);
				return ukxxlaLacAhjZgfcHrLynNXtTWB.GOjmxUUnpAZhvTlUnjrGUkJEtMH;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void aNyxlXUpcoTLaRevCEMEVKRfHpr(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void LnTmlEHyuHnTJlPDyeCxdjbZkGw<T>(IList<T> P_0, IList<T> P_1, IList<T> P_2, Func<T, IList<T>, int> P_3)
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

			private static void gBSiFpYWXorckapMarJfvQFDfFR<T>(string P_0, IList<T> P_1, IList<T> P_2, IList<T> P_3, bool P_4, List<GkyhoIQBeHFACrBfBiSyZKBkYrQ> P_5, Func<T, int> P_6, Func<T, string> P_7, Func<T, IList<T>, int> P_8, Func<elxRTNKzwqpQGibvBdnYvpImxhh<T>, T> P_9) where T : class
			{
				SzusrcmBJFDZPOxILrnNEfChbxf<T> szusrcmBJFDZPOxILrnNEfChbxf = new SzusrcmBJFDZPOxILrnNEfChbxf<T>();
				szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					T val = P_1[i];
					if (P_4)
					{
						P_5.Add(new GkyhoIQBeHFACrBfBiSyZKBkYrQ(szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(val), -1, szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(val)));
						continue;
					}
					T arg = P_9(new elxRTNKzwqpQGibvBdnYvpImxhh<T>(val, null, GkyhoIQBeHFACrBfBiSyZKBkYrQ.DnOdgdfYYHmyBPwdrHiWKceMLvaF.zBGYaAbJxDBpvRcDluLfJWDVTZt, P_3, isCollision: false));
					P_5.Add(new GkyhoIQBeHFACrBfBiSyZKBkYrQ(szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(val), -1, szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(arg)));
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
						omuzLqnIcFUOrjSKHCYzqHyIOHK<T> omuzLqnIcFUOrjSKHCYzqHyIOHK2 = new omuzLqnIcFUOrjSKHCYzqHyIOHK<T>();
						omuzLqnIcFUOrjSKHCYzqHyIOHK2.zOWEVeHXwbzRmjRsyQbayFZnDFzF = szusrcmBJFDZPOxILrnNEfChbxf;
						T finalItem = P_3[num];
						omuzLqnIcFUOrjSKHCYzqHyIOHK2.VXEmcMEiFGaBhTLNgIvDEzzpeMpI = P_9(new elxRTNKzwqpQGibvBdnYvpImxhh<T>(val2, finalItem, GkyhoIQBeHFACrBfBiSyZKBkYrQ.DnOdgdfYYHmyBPwdrHiWKceMLvaF.xfjmwOaSRpLpsDYbloVqtAHlbrNI, P_3, isCollision: true));
						P_5.Find(omuzLqnIcFUOrjSKHCYzqHyIOHK2.QpAuIpXleNSEHtfeLoUqMkmPbxId).xfjmwOaSRpLpsDYbloVqtAHlbrNI = szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						T arg2 = P_9(new elxRTNKzwqpQGibvBdnYvpImxhh<T>(val2, null, GkyhoIQBeHFACrBfBiSyZKBkYrQ.DnOdgdfYYHmyBPwdrHiWKceMLvaF.xfjmwOaSRpLpsDYbloVqtAHlbrNI, P_3, isCollision: false));
						P_5.Add(new GkyhoIQBeHFACrBfBiSyZKBkYrQ(-1, szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(val2), szusrcmBJFDZPOxILrnNEfChbxf.uXAzYqkGMYVJOZwEqdnuxJIgmWr(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}

			[CompilerGenerated]
			private static int iPPdnlblaBKCFtfpIOnecwWgFEAn(InputCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string JLxAOBRgSqcOpCHiVELpBaTgkJrr(InputCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int VchaFvQgDsCbrAuhxMYnntWSFcdE(InputCategory P_0, IList<InputCategory> P_1)
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
			private static int lfUXfyoGNABOgRxioEqaiJfcSRx(InputBehavior P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string bCdxxrpkkanOtbhEfKChYDkWKGN(InputBehavior P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int EJddzjaoJsJJWpONNPpUEuiRJxW(InputBehavior P_0, IList<InputBehavior> P_1)
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
			private static int PjQIQorSuYfkOgGUWnjAyHopGFHj(InputAction P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string JVNZzZwMLGCTtMzGnlBpoyIAIVG(InputAction P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int QxngQNZtNqDMoDpfLhAwLWqzTkp(InputAction P_0, IList<InputAction> P_1)
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
			private static int YvByROkFFnAxGpNdwRRJGsBxwaB(InputMapCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string QXjFPpXTofwDWVinBapirWbDtIR(InputMapCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int jeFGgzUQusjJKWieTdYBStFZmie(InputMapCategory P_0, IList<InputMapCategory> P_1)
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
			private static int riBgzLteWDDkwCdHJqmtNnfvHBx(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string iUqwgtSrMGKqEefAOrInWQwKBQz(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int WSmjteVUDjtYZGdbAeeXGGCZGNp(InputLayout P_0, IList<InputLayout> P_1)
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
			private static int IZcMUCZrlIzjKvIVVBQnyeDMGEu(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string xYSfrzELunMtmEzSbrsgvwZtIGLL(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int HeSQJRfaZoGkxffHsaeeNsovgxLa(InputLayout P_0, IList<InputLayout> P_1)
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
			private static int UOCvdkaZcoPRiwTnoQglMcjYjuS(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string mGBQjxtMjHUDzUfEtZyVFewHakZD(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int duWAHVcXiYFnZgCeyKLpMVHEmWh(InputLayout P_0, IList<InputLayout> P_1)
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
			private static int MMkDITAYCKVdLFSJZlZUUSneIwUa(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string AgvEvBSqvBGHLbQRqmrvfFtkXIyB(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int uyrOifxqYflgxSPEUNSckQQQylK(InputLayout P_0, IList<InputLayout> P_1)
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
			private static int TBxlbbQLKljpOjxeNdBiGdKBMtbI(CustomController_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string XUyrWeGmTmpuTcyCocMcapFdhux(CustomController_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int JlXzXvkPULAsMnWfGoRbdGrRCJGD(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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
			private static int mjfDVMDGcivrcDqNIClsPEwxxFn(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string ZImpTBiynMmPBbbICiYQHtTfnKg(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int IFqUMLneMuAFXFKFVwGlWHTDNLta(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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
			private static int mBmlKdtxuzsjQUgrOASeiBFCDNn(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string CDBDUdOHXzhvbjRIbEGcCfYbHPRS(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int lWaCmJWyFAYpYblxGCoFtvDOjUm(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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
			private static int TDmVGvcltAQQaBBsjfKBrlXqdNI(Player_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string fSIQlyOoyVuSLhiPTizbtmJutuZ(Player_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int dlwvWwosTaqmnLSFEGIwVafphmS(Player_Editor P_0, IList<Player_Editor> P_1)
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
			private static int wKhFRsUirXjYAhgQiAQPbThzfnyC(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string VnxiEfUBRWozaeavUCMPYgpJGDxa(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int kNnyTyNiGChnkduQghdDnigoNqx(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string jtOlryezfmTjrXrUIOgdQgHpflf(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int RBfLDrTYSPjGBHwMvjraKekJWTg(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string hHzzhSyHEadYlCNbsqybiFBijfw(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int JuQaLqRjmXCBvvURMuubTZNqOvI(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string CtbfhCtUHkBkHAOYGlvpGuwTbrqF(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}
		}

		private sealed class bLxlfgbPIQKhrWdvkboLouHuRCr : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string jViWlhVTBxhzBmqmOfeiJkFhjZQ;

			public string WQHivsClkQrgkkTRIQoQskwrJmc;

			public int ruJbLfoHPdAHKbMrcgEkYTYDkQVf;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				bLxlfgbPIQKhrWdvkboLouHuRCr bLxlfgbPIQKhrWdvkboLouHuRCr2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					bLxlfgbPIQKhrWdvkboLouHuRCr2 = this;
				}
				else
				{
					bLxlfgbPIQKhrWdvkboLouHuRCr2 = new bLxlfgbPIQKhrWdvkboLouHuRCr(0);
					bLxlfgbPIQKhrWdvkboLouHuRCr2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				bLxlfgbPIQKhrWdvkboLouHuRCr2.jViWlhVTBxhzBmqmOfeiJkFhjZQ = WQHivsClkQrgkkTRIQoQskwrJmc;
				return bLxlfgbPIQKhrWdvkboLouHuRCr2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (jViWlhVTBxhzBmqmOfeiJkFhjZQ == null || jViWlhVTBxhzBmqmOfeiJkFhjZQ == string.Empty || GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories == null)
					{
						break;
					}
					ruJbLfoHPdAHKbMrcgEkYTYDkQVf = 0;
					goto IL_00bd;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00af;
					}
					IL_00af:
					ruJbLfoHPdAHKbMrcgEkYTYDkQVf++;
					goto IL_00bd;
					IL_00bd:
					if (ruJbLfoHPdAHKbMrcgEkYTYDkQVf >= GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[ruJbLfoHPdAHKbMrcgEkYTYDkQVf].tag.Equals(jViWlhVTBxhzBmqmOfeiJkFhjZQ, StringComparison.OrdinalIgnoreCase))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[ruJbLfoHPdAHKbMrcgEkYTYDkQVf];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public bLxlfgbPIQKhrWdvkboLouHuRCr(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class dQOXrAsEsBNfVeHypJNFSZYrDng : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int lVyRCejAWOuqxrbzbsARpWdNhbO;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				dQOXrAsEsBNfVeHypJNFSZYrDng dQOXrAsEsBNfVeHypJNFSZYrDng2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					dQOXrAsEsBNfVeHypJNFSZYrDng2 = this;
				}
				else
				{
					dQOXrAsEsBNfVeHypJNFSZYrDng2 = new dQOXrAsEsBNfVeHypJNFSZYrDng(0);
					dQOXrAsEsBNfVeHypJNFSZYrDng2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return dQOXrAsEsBNfVeHypJNFSZYrDng2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories == null)
					{
						break;
					}
					lVyRCejAWOuqxrbzbsARpWdNhbO = 0;
					goto IL_008e;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0080;
					}
					IL_0080:
					lVyRCejAWOuqxrbzbsARpWdNhbO++;
					goto IL_008e;
					IL_008e:
					if (lVyRCejAWOuqxrbzbsARpWdNhbO >= GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[lVyRCejAWOuqxrbzbsARpWdNhbO].userAssignable)
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[lVyRCejAWOuqxrbzbsARpWdNhbO];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public dQOXrAsEsBNfVeHypJNFSZYrDng(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class TFkOeHbxEEAvuAHoRpXACTJnNRt : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string jViWlhVTBxhzBmqmOfeiJkFhjZQ;

			public string WQHivsClkQrgkkTRIQoQskwrJmc;

			public int aOIfInsKRtdajIhjJoRyIUaPDsH;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				TFkOeHbxEEAvuAHoRpXACTJnNRt tFkOeHbxEEAvuAHoRpXACTJnNRt;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					tFkOeHbxEEAvuAHoRpXACTJnNRt = this;
				}
				else
				{
					tFkOeHbxEEAvuAHoRpXACTJnNRt = new TFkOeHbxEEAvuAHoRpXACTJnNRt(0);
					tFkOeHbxEEAvuAHoRpXACTJnNRt.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				tFkOeHbxEEAvuAHoRpXACTJnNRt.jViWlhVTBxhzBmqmOfeiJkFhjZQ = WQHivsClkQrgkkTRIQoQskwrJmc;
				return tFkOeHbxEEAvuAHoRpXACTJnNRt;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (jViWlhVTBxhzBmqmOfeiJkFhjZQ == null || jViWlhVTBxhzBmqmOfeiJkFhjZQ == string.Empty || GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories == null)
					{
						break;
					}
					aOIfInsKRtdajIhjJoRyIUaPDsH = 0;
					goto IL_00dd;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00cf;
					}
					IL_00cf:
					aOIfInsKRtdajIhjJoRyIUaPDsH++;
					goto IL_00dd;
					IL_00dd:
					if (aOIfInsKRtdajIhjJoRyIUaPDsH >= GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[aOIfInsKRtdajIhjJoRyIUaPDsH].userAssignable && GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[aOIfInsKRtdajIhjJoRyIUaPDsH].tag.Equals(jViWlhVTBxhzBmqmOfeiJkFhjZQ, StringComparison.OrdinalIgnoreCase))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.mapCategories[aOIfInsKRtdajIhjJoRyIUaPDsH];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public TFkOeHbxEEAvuAHoRpXACTJnNRt(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class NKhdrCoWFrmKcmufFHyIctteIYT : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string jViWlhVTBxhzBmqmOfeiJkFhjZQ;

			public string WQHivsClkQrgkkTRIQoQskwrJmc;

			public int gMzjZNVaFAZzrnJnOHJnaNdAhU;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				NKhdrCoWFrmKcmufFHyIctteIYT nKhdrCoWFrmKcmufFHyIctteIYT;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					nKhdrCoWFrmKcmufFHyIctteIYT = this;
				}
				else
				{
					nKhdrCoWFrmKcmufFHyIctteIYT = new NKhdrCoWFrmKcmufFHyIctteIYT(0);
					nKhdrCoWFrmKcmufFHyIctteIYT.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				nKhdrCoWFrmKcmufFHyIctteIYT.jViWlhVTBxhzBmqmOfeiJkFhjZQ = WQHivsClkQrgkkTRIQoQskwrJmc;
				return nKhdrCoWFrmKcmufFHyIctteIYT;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (jViWlhVTBxhzBmqmOfeiJkFhjZQ == null || jViWlhVTBxhzBmqmOfeiJkFhjZQ == string.Empty || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null)
					{
						break;
					}
					gMzjZNVaFAZzrnJnOHJnaNdAhU = 0;
					goto IL_00bd;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00af;
					}
					IL_00af:
					gMzjZNVaFAZzrnJnOHJnaNdAhU++;
					goto IL_00bd;
					IL_00bd:
					if (gMzjZNVaFAZzrnJnOHJnaNdAhU >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[gMzjZNVaFAZzrnJnOHJnaNdAhU].tag.Equals(jViWlhVTBxhzBmqmOfeiJkFhjZQ, StringComparison.OrdinalIgnoreCase))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[gMzjZNVaFAZzrnJnOHJnaNdAhU];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public NKhdrCoWFrmKcmufFHyIctteIYT(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class fxUGjYiEkXehUXGafYYtCmYPkrUo : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int BjRRczFcfvdxFaLVBDtVUbMjtnzp;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				fxUGjYiEkXehUXGafYYtCmYPkrUo fxUGjYiEkXehUXGafYYtCmYPkrUo2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					fxUGjYiEkXehUXGafYYtCmYPkrUo2 = this;
				}
				else
				{
					fxUGjYiEkXehUXGafYYtCmYPkrUo2 = new fxUGjYiEkXehUXGafYYtCmYPkrUo(0);
					fxUGjYiEkXehUXGafYYtCmYPkrUo2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return fxUGjYiEkXehUXGafYYtCmYPkrUo2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null)
					{
						break;
					}
					BjRRczFcfvdxFaLVBDtVUbMjtnzp = 0;
					goto IL_008e;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0080;
					}
					IL_0080:
					BjRRczFcfvdxFaLVBDtVUbMjtnzp++;
					goto IL_008e;
					IL_008e:
					if (BjRRczFcfvdxFaLVBDtVUbMjtnzp >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[BjRRczFcfvdxFaLVBDtVUbMjtnzp].userAssignable)
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[BjRRczFcfvdxFaLVBDtVUbMjtnzp];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public fxUGjYiEkXehUXGafYYtCmYPkrUo(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class RkVOCZlLmxsDWKPlOvxMYpqpSyX : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string jViWlhVTBxhzBmqmOfeiJkFhjZQ;

			public string WQHivsClkQrgkkTRIQoQskwrJmc;

			public int gXUFAEIDTpjuofoshBSLRbPTOZJ;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				RkVOCZlLmxsDWKPlOvxMYpqpSyX rkVOCZlLmxsDWKPlOvxMYpqpSyX;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					rkVOCZlLmxsDWKPlOvxMYpqpSyX = this;
				}
				else
				{
					rkVOCZlLmxsDWKPlOvxMYpqpSyX = new RkVOCZlLmxsDWKPlOvxMYpqpSyX(0);
					rkVOCZlLmxsDWKPlOvxMYpqpSyX.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				rkVOCZlLmxsDWKPlOvxMYpqpSyX.jViWlhVTBxhzBmqmOfeiJkFhjZQ = WQHivsClkQrgkkTRIQoQskwrJmc;
				return rkVOCZlLmxsDWKPlOvxMYpqpSyX;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (jViWlhVTBxhzBmqmOfeiJkFhjZQ == null || jViWlhVTBxhzBmqmOfeiJkFhjZQ == string.Empty || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null)
					{
						break;
					}
					gXUFAEIDTpjuofoshBSLRbPTOZJ = 0;
					goto IL_00dd;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00cf;
					}
					IL_00cf:
					gXUFAEIDTpjuofoshBSLRbPTOZJ++;
					goto IL_00dd;
					IL_00dd:
					if (gXUFAEIDTpjuofoshBSLRbPTOZJ >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[gXUFAEIDTpjuofoshBSLRbPTOZJ].userAssignable && GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[gXUFAEIDTpjuofoshBSLRbPTOZJ].tag.Equals(jViWlhVTBxhzBmqmOfeiJkFhjZQ, StringComparison.OrdinalIgnoreCase))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[gXUFAEIDTpjuofoshBSLRbPTOZJ];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public RkVOCZlLmxsDWKPlOvxMYpqpSyX(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class UJVZiUViCktTsXVCzEmqflzBBqG : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int qqXrstFSpwuJpElzNQLbpTlJYvF;

			public InputAction xZyfOZjHEoLetQebbflzMfvxSOSS;

			public InputCategory qgidHyCzZbQYpEkuuemflKzdluUE;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				UJVZiUViCktTsXVCzEmqflzBBqG uJVZiUViCktTsXVCzEmqflzBBqG;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					uJVZiUViCktTsXVCzEmqflzBBqG = this;
				}
				else
				{
					uJVZiUViCktTsXVCzEmqflzBBqG = new UJVZiUViCktTsXVCzEmqflzBBqG(0);
					uJVZiUViCktTsXVCzEmqflzBBqG.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return uJVZiUViCktTsXVCzEmqflzBBqG;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null)
					{
						break;
					}
					qqXrstFSpwuJpElzNQLbpTlJYvF = 0;
					goto IL_00c1;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00b3;
					}
					IL_00b3:
					qqXrstFSpwuJpElzNQLbpTlJYvF++;
					goto IL_00c1;
					IL_00c1:
					if (qqXrstFSpwuJpElzNQLbpTlJYvF >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actions.Count)
					{
						break;
					}
					xZyfOZjHEoLetQebbflzMfvxSOSS = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[qqXrstFSpwuJpElzNQLbpTlJYvF];
					qgidHyCzZbQYpEkuuemflKzdluUE = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionCategoryById(xZyfOZjHEoLetQebbflzMfvxSOSS.categoryId);
					if (qgidHyCzZbQYpEkuuemflKzdluUE != null && qgidHyCzZbQYpEkuuemflKzdluUE.userAssignable && xZyfOZjHEoLetQebbflzMfvxSOSS.userAssignable)
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = xZyfOZjHEoLetQebbflzMfvxSOSS;
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public UJVZiUViCktTsXVCzEmqflzBBqG(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class xGxgbdvJVcJcnXJSDGZFqLWnGvv : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int zqAbbQKjZIxdMXcdnGTMIvZqkoIN;

			public int BRGUXuaIYdkcUaJirwpZVBicNpi;

			public bool WEktSRGaCISzvdXdcSEaVJaaZCK;

			public bool APIQfSQKAreSgfnttKxZwpbrQDi;

			public int uUgQUZENsqsUCAGFAYaDgVpOLXH;

			public InputAction jYDUrKhxdVUyGmEvLTgPZtzSmxF;

			public int rxXgDpYEWjzCvmrnLjwKPpCAQnV;

			public IEnumerator<int> TbflGFzCIegMUBWwFNgaaCYefLCG;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				xGxgbdvJVcJcnXJSDGZFqLWnGvv xGxgbdvJVcJcnXJSDGZFqLWnGvv2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					xGxgbdvJVcJcnXJSDGZFqLWnGvv2 = this;
				}
				else
				{
					xGxgbdvJVcJcnXJSDGZFqLWnGvv2 = new xGxgbdvJVcJcnXJSDGZFqLWnGvv(0);
					xGxgbdvJVcJcnXJSDGZFqLWnGvv2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				xGxgbdvJVcJcnXJSDGZFqLWnGvv2.zqAbbQKjZIxdMXcdnGTMIvZqkoIN = BRGUXuaIYdkcUaJirwpZVBicNpi;
				xGxgbdvJVcJcnXJSDGZFqLWnGvv2.WEktSRGaCISzvdXdcSEaVJaaZCK = APIQfSQKAreSgfnttKxZwpbrQDi;
				return xGxgbdvJVcJcnXJSDGZFqLWnGvv2;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null)
						{
							break;
						}
						if (WEktSRGaCISzvdXdcSEaVJaaZCK)
						{
							TbflGFzCIegMUBWwFNgaaCYefLCG = GxphHAMqMhNBLjnlhXuBQmXaALiE.SortedActionIdsInCategory(zqAbbQKjZIxdMXcdnGTMIvZqkoIN).GetEnumerator();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_00ca;
						}
						rxXgDpYEWjzCvmrnLjwKPpCAQnV = 0;
						goto IL_014a;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00ca;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_013c;
						}
						IL_00ca:
						while (TbflGFzCIegMUBWwFNgaaCYefLCG.MoveNext())
						{
							uUgQUZENsqsUCAGFAYaDgVpOLXH = TbflGFzCIegMUBWwFNgaaCYefLCG.Current;
							jYDUrKhxdVUyGmEvLTgPZtzSmxF = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionById(uUgQUZENsqsUCAGFAYaDgVpOLXH);
							if (jYDUrKhxdVUyGmEvLTgPZtzSmxF != null)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = jYDUrKhxdVUyGmEvLTgPZtzSmxF;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						zbOGcIPpsCGOSHnnKIyVBOylOKpv();
						break;
						IL_013c:
						rxXgDpYEWjzCvmrnLjwKPpCAQnV++;
						goto IL_014a;
						IL_014a:
						if (rxXgDpYEWjzCvmrnLjwKPpCAQnV >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actions.Count)
						{
							break;
						}
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[rxXgDpYEWjzCvmrnLjwKPpCAQnV].categoryId == zqAbbQKjZIxdMXcdnGTMIvZqkoIN)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[rxXgDpYEWjzCvmrnLjwKPpCAQnV];
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						zbOGcIPpsCGOSHnnKIyVBOylOKpv();
					}
				}
			}

			[DebuggerHidden]
			public xGxgbdvJVcJcnXJSDGZFqLWnGvv(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void zbOGcIPpsCGOSHnnKIyVBOylOKpv()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (TbflGFzCIegMUBWwFNgaaCYefLCG != null)
				{
					TbflGFzCIegMUBWwFNgaaCYefLCG.Dispose();
				}
			}
		}

		private sealed class bZVERDgyYoSFMDWkSgMiqJGepVU : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string IoMLELZfpedpmEsbXqbePOvGtOe;

			public string FBwEiQCWmZbcaQyWFtmjjzeYNRr;

			public bool WEktSRGaCISzvdXdcSEaVJaaZCK;

			public bool APIQfSQKAreSgfnttKxZwpbrQDi;

			public int IXtrLBylXzFMfKSSAKBTHaWkuNWq;

			public InputCategory zQpvdjPoBUMIrAWtmAbMFpQdpJB;

			public int XLigRgTBdFXYvtvYGTEpiSccWBa;

			public InputAction CnRrMfDIidasKINCnLVjraLFHcaI;

			public int PscUdWeGHvezsCSdIcuJEchoCbXO;

			public IEnumerator<int> YoyHRQalJJfINWCYieniAOmbHKqG;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				bZVERDgyYoSFMDWkSgMiqJGepVU bZVERDgyYoSFMDWkSgMiqJGepVU2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					bZVERDgyYoSFMDWkSgMiqJGepVU2 = this;
				}
				else
				{
					bZVERDgyYoSFMDWkSgMiqJGepVU2 = new bZVERDgyYoSFMDWkSgMiqJGepVU(0);
					bZVERDgyYoSFMDWkSgMiqJGepVU2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				bZVERDgyYoSFMDWkSgMiqJGepVU2.IoMLELZfpedpmEsbXqbePOvGtOe = FBwEiQCWmZbcaQyWFtmjjzeYNRr;
				bZVERDgyYoSFMDWkSgMiqJGepVU2.WEktSRGaCISzvdXdcSEaVJaaZCK = APIQfSQKAreSgfnttKxZwpbrQDi;
				return bZVERDgyYoSFMDWkSgMiqJGepVU2;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null || IoMLELZfpedpmEsbXqbePOvGtOe == null || IoMLELZfpedpmEsbXqbePOvGtOe == string.Empty)
						{
							break;
						}
						IXtrLBylXzFMfKSSAKBTHaWkuNWq = GxphHAMqMhNBLjnlhXuBQmXaALiE.IndexOfActionCategory(IoMLELZfpedpmEsbXqbePOvGtOe);
						if (IXtrLBylXzFMfKSSAKBTHaWkuNWq < 0)
						{
							break;
						}
						zQpvdjPoBUMIrAWtmAbMFpQdpJB = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionCategory(IXtrLBylXzFMfKSSAKBTHaWkuNWq);
						if (WEktSRGaCISzvdXdcSEaVJaaZCK)
						{
							YoyHRQalJJfINWCYieniAOmbHKqG = GxphHAMqMhNBLjnlhXuBQmXaALiE.SortedActionIdsInCategory(zQpvdjPoBUMIrAWtmAbMFpQdpJB.id).GetEnumerator();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_0129;
						}
						PscUdWeGHvezsCSdIcuJEchoCbXO = 0;
						goto IL_01ae;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_0129;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_01a0;
						}
						IL_0129:
						while (YoyHRQalJJfINWCYieniAOmbHKqG.MoveNext())
						{
							XLigRgTBdFXYvtvYGTEpiSccWBa = YoyHRQalJJfINWCYieniAOmbHKqG.Current;
							CnRrMfDIidasKINCnLVjraLFHcaI = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionById(XLigRgTBdFXYvtvYGTEpiSccWBa);
							if (CnRrMfDIidasKINCnLVjraLFHcaI != null)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = CnRrMfDIidasKINCnLVjraLFHcaI;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						DIZfpEeWjURdKxUhQfPRLGxRaxvw();
						break;
						IL_01a0:
						PscUdWeGHvezsCSdIcuJEchoCbXO++;
						goto IL_01ae;
						IL_01ae:
						if (PscUdWeGHvezsCSdIcuJEchoCbXO >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actions.Count)
						{
							break;
						}
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[PscUdWeGHvezsCSdIcuJEchoCbXO].categoryId == zQpvdjPoBUMIrAWtmAbMFpQdpJB.id)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[PscUdWeGHvezsCSdIcuJEchoCbXO];
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						DIZfpEeWjURdKxUhQfPRLGxRaxvw();
					}
				}
			}

			[DebuggerHidden]
			public bZVERDgyYoSFMDWkSgMiqJGepVU(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void DIZfpEeWjURdKxUhQfPRLGxRaxvw()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (YoyHRQalJJfINWCYieniAOmbHKqG != null)
				{
					YoyHRQalJJfINWCYieniAOmbHKqG.Dispose();
				}
			}
		}

		private sealed class iJzQkvCRXLuQgEWQqjdYkjfkjgu : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string jViWlhVTBxhzBmqmOfeiJkFhjZQ;

			public string WQHivsClkQrgkkTRIQoQskwrJmc;

			public int rVKGuHxAMFrvQHJZzalVHnrwBYz;

			public int palyrSQcmSbeIxaquFNvbwdQQkcr;

			public InputCategory kXRCsiIVkgnxPaLExRPTjhqYDWOe;

			public int vGOuhuWGAXLclVXwYmkDknUkBuS;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				iJzQkvCRXLuQgEWQqjdYkjfkjgu iJzQkvCRXLuQgEWQqjdYkjfkjgu2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					iJzQkvCRXLuQgEWQqjdYkjfkjgu2 = this;
				}
				else
				{
					iJzQkvCRXLuQgEWQqjdYkjfkjgu2 = new iJzQkvCRXLuQgEWQqjdYkjfkjgu(0);
					iJzQkvCRXLuQgEWQqjdYkjfkjgu2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				iJzQkvCRXLuQgEWQqjdYkjfkjgu2.jViWlhVTBxhzBmqmOfeiJkFhjZQ = WQHivsClkQrgkkTRIQoQskwrJmc;
				return iJzQkvCRXLuQgEWQqjdYkjfkjgu2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null || jViWlhVTBxhzBmqmOfeiJkFhjZQ == null || jViWlhVTBxhzBmqmOfeiJkFhjZQ == string.Empty)
					{
						break;
					}
					rVKGuHxAMFrvQHJZzalVHnrwBYz = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions.Count;
					palyrSQcmSbeIxaquFNvbwdQQkcr = 0;
					goto IL_0152;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0128;
					}
					IL_0152:
					if (palyrSQcmSbeIxaquFNvbwdQQkcr >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories.Count)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[palyrSQcmSbeIxaquFNvbwdQQkcr].tag.Equals(jViWlhVTBxhzBmqmOfeiJkFhjZQ, StringComparison.OrdinalIgnoreCase))
					{
						kXRCsiIVkgnxPaLExRPTjhqYDWOe = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories[palyrSQcmSbeIxaquFNvbwdQQkcr];
						vGOuhuWGAXLclVXwYmkDknUkBuS = 0;
						goto IL_0136;
					}
					goto IL_0144;
					IL_0128:
					vGOuhuWGAXLclVXwYmkDknUkBuS++;
					goto IL_0136;
					IL_0144:
					palyrSQcmSbeIxaquFNvbwdQQkcr++;
					goto IL_0152;
					IL_0136:
					if (vGOuhuWGAXLclVXwYmkDknUkBuS < rVKGuHxAMFrvQHJZzalVHnrwBYz)
					{
						if (kXRCsiIVkgnxPaLExRPTjhqYDWOe.id == GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[vGOuhuWGAXLclVXwYmkDknUkBuS].categoryId)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[vGOuhuWGAXLclVXwYmkDknUkBuS];
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
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
			public iJzQkvCRXLuQgEWQqjdYkjfkjgu(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class fKZDUWEwiUhftJiATepKxFtrgij : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int zqAbbQKjZIxdMXcdnGTMIvZqkoIN;

			public int BRGUXuaIYdkcUaJirwpZVBicNpi;

			public bool WEktSRGaCISzvdXdcSEaVJaaZCK;

			public bool APIQfSQKAreSgfnttKxZwpbrQDi;

			public InputCategory zBeDHMbEyQVnKdnePYKGOtTljRFA;

			public int ziNCzvnpQndkpFcFwvhSYiKlIbTi;

			public InputAction avbMiJGSaopAfIiojTZnmppitVC;

			public int LTctTGsCIueqGqDmNnCGvxUTnSN;

			public InputAction iFaTVbTIkWMMVJleZzOQjcTtKWf;

			public IEnumerator<int> dyDUXXBArqQDUgsivKJhrbuXmCU;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				fKZDUWEwiUhftJiATepKxFtrgij fKZDUWEwiUhftJiATepKxFtrgij2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					fKZDUWEwiUhftJiATepKxFtrgij2 = this;
				}
				else
				{
					fKZDUWEwiUhftJiATepKxFtrgij2 = new fKZDUWEwiUhftJiATepKxFtrgij(0);
					fKZDUWEwiUhftJiATepKxFtrgij2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				fKZDUWEwiUhftJiATepKxFtrgij2.zqAbbQKjZIxdMXcdnGTMIvZqkoIN = BRGUXuaIYdkcUaJirwpZVBicNpi;
				fKZDUWEwiUhftJiATepKxFtrgij2.WEktSRGaCISzvdXdcSEaVJaaZCK = APIQfSQKAreSgfnttKxZwpbrQDi;
				return fKZDUWEwiUhftJiATepKxFtrgij2;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null)
						{
							break;
						}
						zBeDHMbEyQVnKdnePYKGOtTljRFA = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionCategoryById(zqAbbQKjZIxdMXcdnGTMIvZqkoIN);
						if (zBeDHMbEyQVnKdnePYKGOtTljRFA == null || !zBeDHMbEyQVnKdnePYKGOtTljRFA.userAssignable)
						{
							break;
						}
						if (WEktSRGaCISzvdXdcSEaVJaaZCK)
						{
							dyDUXXBArqQDUgsivKJhrbuXmCU = GxphHAMqMhNBLjnlhXuBQmXaALiE.SortedActionIdsInCategory(zBeDHMbEyQVnKdnePYKGOtTljRFA.id).GetEnumerator();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_010e;
						}
						LTctTGsCIueqGqDmNnCGvxUTnSN = 0;
						goto IL_019c;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_010e;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_018e;
						}
						IL_018e:
						LTctTGsCIueqGqDmNnCGvxUTnSN++;
						goto IL_019c;
						IL_019c:
						if (LTctTGsCIueqGqDmNnCGvxUTnSN >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actions.Count)
						{
							break;
						}
						iFaTVbTIkWMMVJleZzOQjcTtKWf = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[LTctTGsCIueqGqDmNnCGvxUTnSN];
						if (iFaTVbTIkWMMVJleZzOQjcTtKWf.categoryId == zBeDHMbEyQVnKdnePYKGOtTljRFA.id && iFaTVbTIkWMMVJleZzOQjcTtKWf.userAssignable)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = iFaTVbTIkWMMVJleZzOQjcTtKWf;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							return true;
						}
						goto IL_018e;
						IL_010e:
						while (dyDUXXBArqQDUgsivKJhrbuXmCU.MoveNext())
						{
							ziNCzvnpQndkpFcFwvhSYiKlIbTi = dyDUXXBArqQDUgsivKJhrbuXmCU.Current;
							avbMiJGSaopAfIiojTZnmppitVC = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionById(ziNCzvnpQndkpFcFwvhSYiKlIbTi);
							if (avbMiJGSaopAfIiojTZnmppitVC != null && avbMiJGSaopAfIiojTZnmppitVC.userAssignable)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = avbMiJGSaopAfIiojTZnmppitVC;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						HQuVRhvflEHzMOCYPHQVVnDQAFQ();
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						HQuVRhvflEHzMOCYPHQVVnDQAFQ();
					}
				}
			}

			[DebuggerHidden]
			public fKZDUWEwiUhftJiATepKxFtrgij(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void HQuVRhvflEHzMOCYPHQVVnDQAFQ()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (dyDUXXBArqQDUgsivKJhrbuXmCU != null)
				{
					dyDUXXBArqQDUgsivKJhrbuXmCU.Dispose();
				}
			}
		}

		private sealed class cLHzvlCmZnCTXbpohkKzSEvwASq : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public string oQJBJUbDRbxolMTCNeGoZuqbdGav;

			public string WDWRNPQLjdMffjhdoBmUCeaUnOuV;

			public bool WEktSRGaCISzvdXdcSEaVJaaZCK;

			public bool APIQfSQKAreSgfnttKxZwpbrQDi;

			public InputCategory tSztodibgMvtrkCwfVBmLqRmdNpK;

			public int mtIMsdRUeYuUiAyrPRBRfQSzXQw;

			public InputAction sWzWkzIbTroIaLrUISbduwIMaiv;

			public int AfretQjVNTRtyqWwtgIKUuAkQRFW;

			public InputAction aENyVYYddDIEogIGGZyxEdgxIahH;

			public IEnumerator<int> gbQDnbeaNUJQvkoqLfDklQriGdb;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				cLHzvlCmZnCTXbpohkKzSEvwASq cLHzvlCmZnCTXbpohkKzSEvwASq2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					cLHzvlCmZnCTXbpohkKzSEvwASq2 = this;
				}
				else
				{
					cLHzvlCmZnCTXbpohkKzSEvwASq2 = new cLHzvlCmZnCTXbpohkKzSEvwASq(0);
					cLHzvlCmZnCTXbpohkKzSEvwASq2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				cLHzvlCmZnCTXbpohkKzSEvwASq2.oQJBJUbDRbxolMTCNeGoZuqbdGav = WDWRNPQLjdMffjhdoBmUCeaUnOuV;
				cLHzvlCmZnCTXbpohkKzSEvwASq2.WEktSRGaCISzvdXdcSEaVJaaZCK = APIQfSQKAreSgfnttKxZwpbrQDi;
				return cLHzvlCmZnCTXbpohkKzSEvwASq2;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null)
						{
							break;
						}
						tSztodibgMvtrkCwfVBmLqRmdNpK = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionCategory(oQJBJUbDRbxolMTCNeGoZuqbdGav);
						if (tSztodibgMvtrkCwfVBmLqRmdNpK == null || !tSztodibgMvtrkCwfVBmLqRmdNpK.userAssignable)
						{
							break;
						}
						if (WEktSRGaCISzvdXdcSEaVJaaZCK)
						{
							gbQDnbeaNUJQvkoqLfDklQriGdb = GxphHAMqMhNBLjnlhXuBQmXaALiE.SortedActionIdsInCategory(tSztodibgMvtrkCwfVBmLqRmdNpK.id).GetEnumerator();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_010e;
						}
						AfretQjVNTRtyqWwtgIKUuAkQRFW = 0;
						goto IL_019c;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_010e;
					case 3:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_018e;
						}
						IL_018e:
						AfretQjVNTRtyqWwtgIKUuAkQRFW++;
						goto IL_019c;
						IL_019c:
						if (AfretQjVNTRtyqWwtgIKUuAkQRFW >= GxphHAMqMhNBLjnlhXuBQmXaALiE.actions.Count)
						{
							break;
						}
						aENyVYYddDIEogIGGZyxEdgxIahH = GxphHAMqMhNBLjnlhXuBQmXaALiE.actions[AfretQjVNTRtyqWwtgIKUuAkQRFW];
						if (aENyVYYddDIEogIGGZyxEdgxIahH.categoryId == tSztodibgMvtrkCwfVBmLqRmdNpK.id && aENyVYYddDIEogIGGZyxEdgxIahH.userAssignable)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = aENyVYYddDIEogIGGZyxEdgxIahH;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							return true;
						}
						goto IL_018e;
						IL_010e:
						while (gbQDnbeaNUJQvkoqLfDklQriGdb.MoveNext())
						{
							mtIMsdRUeYuUiAyrPRBRfQSzXQw = gbQDnbeaNUJQvkoqLfDklQriGdb.Current;
							sWzWkzIbTroIaLrUISbduwIMaiv = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionById(mtIMsdRUeYuUiAyrPRBRfQSzXQw);
							if (sWzWkzIbTroIaLrUISbduwIMaiv != null && sWzWkzIbTroIaLrUISbduwIMaiv.userAssignable)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = sWzWkzIbTroIaLrUISbduwIMaiv;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						zjzOkJrtGCIhWScDpkKzvKkmqgU();
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						zjzOkJrtGCIhWScDpkKzvKkmqgU();
					}
				}
			}

			[DebuggerHidden]
			public cLHzvlCmZnCTXbpohkKzSEvwASq(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void zjzOkJrtGCIhWScDpkKzvKkmqgU()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (gbQDnbeaNUJQvkoqLfDklQriGdb != null)
				{
					gbQDnbeaNUJQvkoqLfDklQriGdb.Dispose();
				}
			}
		}

		private sealed class NQbXhXcbPvxJewnARPBFMYIlNRW : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int RUucinekeLVhzGKuGszOeYlJzub;

			public int xEIXnHqHuUBkikuizEtAgIauAuZh;

			public int WoaChwhxbznspQdaEbRmmmBBbHp;

			public InputAction yWjNKCPvPTTSvDyWWQDXEylIAYC;

			public IEnumerator<int> hPqtRUxLwEGXgrUVWBMGjjwCylC;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				NQbXhXcbPvxJewnARPBFMYIlNRW nQbXhXcbPvxJewnARPBFMYIlNRW;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					nQbXhXcbPvxJewnARPBFMYIlNRW = this;
				}
				else
				{
					nQbXhXcbPvxJewnARPBFMYIlNRW = new NQbXhXcbPvxJewnARPBFMYIlNRW(0);
					nQbXhXcbPvxJewnARPBFMYIlNRW.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				nQbXhXcbPvxJewnARPBFMYIlNRW.RUucinekeLVhzGKuGszOeYlJzub = xEIXnHqHuUBkikuizEtAgIauAuZh;
				return nQbXhXcbPvxJewnARPBFMYIlNRW;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null)
						{
							break;
						}
						hPqtRUxLwEGXgrUVWBMGjjwCylC = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategoryMap.ActionIdsInCategory(RUucinekeLVhzGKuGszOeYlJzub).GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00c2;
					case 2:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_00c2;
						}
						IL_00c2:
						while (hPqtRUxLwEGXgrUVWBMGjjwCylC.MoveNext())
						{
							WoaChwhxbznspQdaEbRmmmBBbHp = hPqtRUxLwEGXgrUVWBMGjjwCylC.Current;
							yWjNKCPvPTTSvDyWWQDXEylIAYC = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionById(WoaChwhxbznspQdaEbRmmmBBbHp);
							if (yWjNKCPvPTTSvDyWWQDXEylIAYC != null)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = yWjNKCPvPTTSvDyWWQDXEylIAYC.name;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						caSEosnWOnqHomKzskXOAMNZzNo();
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						caSEosnWOnqHomKzskXOAMNZzNo();
					}
				}
			}

			[DebuggerHidden]
			public NQbXhXcbPvxJewnARPBFMYIlNRW(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void caSEosnWOnqHomKzskXOAMNZzNo()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (hPqtRUxLwEGXgrUVWBMGjjwCylC != null)
				{
					hPqtRUxLwEGXgrUVWBMGjjwCylC.Dispose();
				}
			}
		}

		private sealed class FItKmhWhJBDXAaNLNPhuvtwMhVt : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int RUucinekeLVhzGKuGszOeYlJzub;

			public int xEIXnHqHuUBkikuizEtAgIauAuZh;

			public int QklhnqiPtWiYkKsUWnmIoCCbcdh;

			public InputAction syizdxaByEdPSIGYAPZHCBMctCGF;

			public IEnumerator<int> nLamzDMhyyhPOWsyMeLtlAKniPkj;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				FItKmhWhJBDXAaNLNPhuvtwMhVt fItKmhWhJBDXAaNLNPhuvtwMhVt;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					fItKmhWhJBDXAaNLNPhuvtwMhVt = this;
				}
				else
				{
					fItKmhWhJBDXAaNLNPhuvtwMhVt = new FItKmhWhJBDXAaNLNPhuvtwMhVt(0);
					fItKmhWhJBDXAaNLNPhuvtwMhVt.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				fItKmhWhJBDXAaNLNPhuvtwMhVt.RUucinekeLVhzGKuGszOeYlJzub = xEIXnHqHuUBkikuizEtAgIauAuZh;
				return fItKmhWhJBDXAaNLNPhuvtwMhVt;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null)
						{
							break;
						}
						nLamzDMhyyhPOWsyMeLtlAKniPkj = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategoryMap.ActionIdsInCategory(RUucinekeLVhzGKuGszOeYlJzub).GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00c2;
					case 2:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_00c2;
						}
						IL_00c2:
						while (nLamzDMhyyhPOWsyMeLtlAKniPkj.MoveNext())
						{
							QklhnqiPtWiYkKsUWnmIoCCbcdh = nLamzDMhyyhPOWsyMeLtlAKniPkj.Current;
							syizdxaByEdPSIGYAPZHCBMctCGF = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetActionById(QklhnqiPtWiYkKsUWnmIoCCbcdh);
							if (syizdxaByEdPSIGYAPZHCBMctCGF != null)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = syizdxaByEdPSIGYAPZHCBMctCGF.descriptiveName;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						qIVPrNIJUSDNADyRhRGICtyXezuI();
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						qIVPrNIJUSDNADyRhRGICtyXezuI();
					}
				}
			}

			[DebuggerHidden]
			public FItKmhWhJBDXAaNLNPhuvtwMhVt(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void qIVPrNIJUSDNADyRhRGICtyXezuI()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (nLamzDMhyyhPOWsyMeLtlAKniPkj != null)
				{
					nLamzDMhyyhPOWsyMeLtlAKniPkj.Dispose();
				}
			}
		}

		private sealed class IgMPgSPGvPJJAIoDdJHBMOqYTBa : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public UserData GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int RUucinekeLVhzGKuGszOeYlJzub;

			public int xEIXnHqHuUBkikuizEtAgIauAuZh;

			public int KVxuQIiQpzMpSYOnceleMmjXnuS;

			public IEnumerator<int> esPOLqubfsywFNGEDfUeLSiQDwc;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				IgMPgSPGvPJJAIoDdJHBMOqYTBa igMPgSPGvPJJAIoDdJHBMOqYTBa;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					igMPgSPGvPJJAIoDdJHBMOqYTBa = this;
				}
				else
				{
					igMPgSPGvPJJAIoDdJHBMOqYTBa = new IgMPgSPGvPJJAIoDdJHBMOqYTBa(0);
					igMPgSPGvPJJAIoDdJHBMOqYTBa.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				igMPgSPGvPJJAIoDdJHBMOqYTBa.RUucinekeLVhzGKuGszOeYlJzub = xEIXnHqHuUBkikuizEtAgIauAuZh;
				return igMPgSPGvPJJAIoDdJHBMOqYTBa;
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
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategories == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.actions == null)
						{
							break;
						}
						esPOLqubfsywFNGEDfUeLSiQDwc = GxphHAMqMhNBLjnlhXuBQmXaALiE.actionCategoryMap.ActionIdsInCategory(RUucinekeLVhzGKuGszOeYlJzub).GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_0098;
					case 2:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_0098;
						}
						IL_0098:
						if (esPOLqubfsywFNGEDfUeLSiQDwc.MoveNext())
						{
							KVxuQIiQpzMpSYOnceleMmjXnuS = esPOLqubfsywFNGEDfUeLSiQDwc.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = KVxuQIiQpzMpSYOnceleMmjXnuS;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						FRkVNHgWEjvlfjmNARenElrCwUH();
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
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						FRkVNHgWEjvlfjmNARenElrCwUH();
					}
				}
			}

			[DebuggerHidden]
			public IgMPgSPGvPJJAIoDdJHBMOqYTBa(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void FRkVNHgWEjvlfjmNARenElrCwUH()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (esPOLqubfsywFNGEDfUeLSiQDwc != null)
				{
					esPOLqubfsywFNGEDfUeLSiQDwc.Dispose();
				}
			}
		}

		private sealed class jhuARnREJCyZcKcUFlEaFaVGYfb
		{
			private sealed class enaOTwJNvMOalJKKCLCaQzxUeVP
			{
				public jhuARnREJCyZcKcUFlEaFaVGYfb wKqFpJEPeMMpGFubrkImdnGGWgts;

				public ControllerMap_Editor FzCIvtwBEWqiAMvsUgGqBBCOPJY;

				public ControllerMap_Editor xmFIgjGNxavJrroAlgIEXNVskcM;

				public bool OQGJINvahUmersmImEWJBEZsnFo(InputLayout P_0)
				{
					return P_0.id == FzCIvtwBEWqiAMvsUgGqBBCOPJY.id;
				}

				public bool txTNJbynewQEaRflYieEbnGujkL(InputLayout P_0)
				{
					return P_0.id == xmFIgjGNxavJrroAlgIEXNVskcM.id;
				}
			}

			public List<InputLayout> TyHBfuAXHWAyIIfnKDAEdHLAgzOw;

			public int BUTgsekSNkrHyQxWRuMQeZhdjPha(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				enaOTwJNvMOalJKKCLCaQzxUeVP enaOTwJNvMOalJKKCLCaQzxUeVP2 = new enaOTwJNvMOalJKKCLCaQzxUeVP();
				enaOTwJNvMOalJKKCLCaQzxUeVP2.wKqFpJEPeMMpGFubrkImdnGGWgts = this;
				enaOTwJNvMOalJKKCLCaQzxUeVP2.FzCIvtwBEWqiAMvsUgGqBBCOPJY = P_0;
				enaOTwJNvMOalJKKCLCaQzxUeVP2.xmFIgjGNxavJrroAlgIEXNVskcM = P_1;
				int num = TyHBfuAXHWAyIIfnKDAEdHLAgzOw.FindIndex(enaOTwJNvMOalJKKCLCaQzxUeVP2.OQGJINvahUmersmImEWJBEZsnFo);
				int num2 = TyHBfuAXHWAyIIfnKDAEdHLAgzOw.FindIndex(enaOTwJNvMOalJKKCLCaQzxUeVP2.txTNJbynewQEaRflYieEbnGujkL);
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
				dQOXrAsEsBNfVeHypJNFSZYrDng dQOXrAsEsBNfVeHypJNFSZYrDng2 = new dQOXrAsEsBNfVeHypJNFSZYrDng(-2);
				dQOXrAsEsBNfVeHypJNFSZYrDng2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
				return dQOXrAsEsBNfVeHypJNFSZYrDng2;
			}
		}

		internal IEnumerable<InputCategory> UserAssignableActionCategories
		{
			get
			{
				fxUGjYiEkXehUXGafYYtCmYPkrUo fxUGjYiEkXehUXGafYYtCmYPkrUo2 = new fxUGjYiEkXehUXGafYYtCmYPkrUo(-2);
				fxUGjYiEkXehUXGafYYtCmYPkrUo2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
				return fxUGjYiEkXehUXGafYYtCmYPkrUo2;
			}
		}

		internal IEnumerable<InputAction> UserAssignableActions
		{
			get
			{
				UJVZiUViCktTsXVCzEmqflzBBqG uJVZiUViCktTsXVCzEmqflzBBqG = new UJVZiUViCktTsXVCzEmqflzBBqG(-2);
				uJVZiUViCktTsXVCzEmqflzBBqG.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
				return uJVZiUViCktTsXVCzEmqflzBBqG;
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

		internal IEnumerable<InputMapCategory> sEJhUIpyftedXZWXTArRzfRbHwW(string P_0)
		{
			bLxlfgbPIQKhrWdvkboLouHuRCr bLxlfgbPIQKhrWdvkboLouHuRCr2 = new bLxlfgbPIQKhrWdvkboLouHuRCr(-2);
			bLxlfgbPIQKhrWdvkboLouHuRCr2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			bLxlfgbPIQKhrWdvkboLouHuRCr2.WQHivsClkQrgkkTRIQoQskwrJmc = P_0;
			return bLxlfgbPIQKhrWdvkboLouHuRCr2;
		}

		internal IEnumerable<InputMapCategory> SAFLTFRKTqUcISynofaBLUpKzsI(string P_0)
		{
			TFkOeHbxEEAvuAHoRpXACTJnNRt tFkOeHbxEEAvuAHoRpXACTJnNRt = new TFkOeHbxEEAvuAHoRpXACTJnNRt(-2);
			tFkOeHbxEEAvuAHoRpXACTJnNRt.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			tFkOeHbxEEAvuAHoRpXACTJnNRt.WQHivsClkQrgkkTRIQoQskwrJmc = P_0;
			return tFkOeHbxEEAvuAHoRpXACTJnNRt;
		}

		internal IEnumerable<InputCategory> McycczgUVnhzYjRmBgMpORmytlt(string P_0)
		{
			NKhdrCoWFrmKcmufFHyIctteIYT nKhdrCoWFrmKcmufFHyIctteIYT = new NKhdrCoWFrmKcmufFHyIctteIYT(-2);
			nKhdrCoWFrmKcmufFHyIctteIYT.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			nKhdrCoWFrmKcmufFHyIctteIYT.WQHivsClkQrgkkTRIQoQskwrJmc = P_0;
			return nKhdrCoWFrmKcmufFHyIctteIYT;
		}

		internal IEnumerable<InputCategory> gXDRHMtKwHvXyuAkhcBghwveWUO(string P_0)
		{
			RkVOCZlLmxsDWKPlOvxMYpqpSyX rkVOCZlLmxsDWKPlOvxMYpqpSyX = new RkVOCZlLmxsDWKPlOvxMYpqpSyX(-2);
			rkVOCZlLmxsDWKPlOvxMYpqpSyX.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			rkVOCZlLmxsDWKPlOvxMYpqpSyX.WQHivsClkQrgkkTRIQoQskwrJmc = P_0;
			return rkVOCZlLmxsDWKPlOvxMYpqpSyX;
		}

		internal IEnumerable<InputAction> ZMNXUvImaIeaHRjjFmXhcOnslTW(int P_0, bool P_1)
		{
			xGxgbdvJVcJcnXJSDGZFqLWnGvv xGxgbdvJVcJcnXJSDGZFqLWnGvv2 = new xGxgbdvJVcJcnXJSDGZFqLWnGvv(-2);
			xGxgbdvJVcJcnXJSDGZFqLWnGvv2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			xGxgbdvJVcJcnXJSDGZFqLWnGvv2.BRGUXuaIYdkcUaJirwpZVBicNpi = P_0;
			xGxgbdvJVcJcnXJSDGZFqLWnGvv2.APIQfSQKAreSgfnttKxZwpbrQDi = P_1;
			return xGxgbdvJVcJcnXJSDGZFqLWnGvv2;
		}

		internal IEnumerable<InputAction> ZMNXUvImaIeaHRjjFmXhcOnslTW(string P_0, bool P_1)
		{
			bZVERDgyYoSFMDWkSgMiqJGepVU bZVERDgyYoSFMDWkSgMiqJGepVU2 = new bZVERDgyYoSFMDWkSgMiqJGepVU(-2);
			bZVERDgyYoSFMDWkSgMiqJGepVU2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			bZVERDgyYoSFMDWkSgMiqJGepVU2.FBwEiQCWmZbcaQyWFtmjjzeYNRr = P_0;
			bZVERDgyYoSFMDWkSgMiqJGepVU2.APIQfSQKAreSgfnttKxZwpbrQDi = P_1;
			return bZVERDgyYoSFMDWkSgMiqJGepVU2;
		}

		internal IEnumerable<InputAction> WKkKolPzPcLkyzugSnSXlOKzbPr(string P_0)
		{
			iJzQkvCRXLuQgEWQqjdYkjfkjgu iJzQkvCRXLuQgEWQqjdYkjfkjgu2 = new iJzQkvCRXLuQgEWQqjdYkjfkjgu(-2);
			iJzQkvCRXLuQgEWQqjdYkjfkjgu2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			iJzQkvCRXLuQgEWQqjdYkjfkjgu2.WQHivsClkQrgkkTRIQoQskwrJmc = P_0;
			return iJzQkvCRXLuQgEWQqjdYkjfkjgu2;
		}

		internal IEnumerable<InputAction> cWbeulKVHddpbQNuRYZlRUrtTjG(int P_0, bool P_1)
		{
			fKZDUWEwiUhftJiATepKxFtrgij fKZDUWEwiUhftJiATepKxFtrgij2 = new fKZDUWEwiUhftJiATepKxFtrgij(-2);
			fKZDUWEwiUhftJiATepKxFtrgij2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			fKZDUWEwiUhftJiATepKxFtrgij2.BRGUXuaIYdkcUaJirwpZVBicNpi = P_0;
			fKZDUWEwiUhftJiATepKxFtrgij2.APIQfSQKAreSgfnttKxZwpbrQDi = P_1;
			return fKZDUWEwiUhftJiATepKxFtrgij2;
		}

		internal IEnumerable<InputAction> cWbeulKVHddpbQNuRYZlRUrtTjG(string P_0, bool P_1)
		{
			cLHzvlCmZnCTXbpohkKzSEvwASq cLHzvlCmZnCTXbpohkKzSEvwASq2 = new cLHzvlCmZnCTXbpohkKzSEvwASq(-2);
			cLHzvlCmZnCTXbpohkKzSEvwASq2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			cLHzvlCmZnCTXbpohkKzSEvwASq2.WDWRNPQLjdMffjhdoBmUCeaUnOuV = P_0;
			cLHzvlCmZnCTXbpohkKzSEvwASq2.APIQfSQKAreSgfnttKxZwpbrQDi = P_1;
			return cLHzvlCmZnCTXbpohkKzSEvwASq2;
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
				Player_Editor player_Editor = qmiZoxcnSWvfHDomviJjjeRDfiku();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = rZsTuivVzndqMzeSRfGlApLacxh();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = ItMYXHKnqzmZbpjzabVKbAKABct();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = MgtDaUjkoCjyRdTJgOXcDqKqebDp();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = TKHkhhQaBgoaILZoNzahcTRRSTJ();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = snqEEPfyHpuEgxRGQNipiNiJEsdd();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = GUvHHgnFNlYwYkZVXuKutDrluIX();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = XLvcNPCbEFBPXrCvJHhxhHcSgzYe();
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
				KeyboardMap item = keyboardMaps[i].uCZxujmTmeDtkpQYCAYcQWnzgGD(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].tRTFehbFgyFfnRPHYjAlJAOeXEB(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(qmiZoxcnSWvfHDomviJjjeRDfiku());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, qmiZoxcnSWvfHDomviJjjeRDfiku());
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
			InputAction inputAction = QoPDHaVShtomRimNgFZDonccEyx();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions != null)
			{
				InputAction inputAction = QoPDHaVShtomRimNgFZDonccEyx();
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

		private int XlGxOnTUQHRbKpDoMHtWoRwnusK(int P_0, InputAction P_1)
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
			NQbXhXcbPvxJewnARPBFMYIlNRW nQbXhXcbPvxJewnARPBFMYIlNRW = new NQbXhXcbPvxJewnARPBFMYIlNRW(-2);
			nQbXhXcbPvxJewnARPBFMYIlNRW.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			nQbXhXcbPvxJewnARPBFMYIlNRW.xEIXnHqHuUBkikuizEtAgIauAuZh = id;
			return nQbXhXcbPvxJewnARPBFMYIlNRW;
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
			FItKmhWhJBDXAaNLNPhuvtwMhVt fItKmhWhJBDXAaNLNPhuvtwMhVt = new FItKmhWhJBDXAaNLNPhuvtwMhVt(-2);
			fItKmhWhJBDXAaNLNPhuvtwMhVt.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			fItKmhWhJBDXAaNLNPhuvtwMhVt.xEIXnHqHuUBkikuizEtAgIauAuZh = id;
			return fItKmhWhJBDXAaNLNPhuvtwMhVt;
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
			IgMPgSPGvPJJAIoDdJHBMOqYTBa igMPgSPGvPJJAIoDdJHBMOqYTBa = new IgMPgSPGvPJJAIoDdJHBMOqYTBa(-2);
			igMPgSPGvPJJAIoDdJHBMOqYTBa.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			igMPgSPGvPJJAIoDdJHBMOqYTBa.xEIXnHqHuUBkikuizEtAgIauAuZh = id;
			return igMPgSPGvPJJAIoDdJHBMOqYTBa;
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
			InputCategory inputCategory = rZsTuivVzndqMzeSRfGlApLacxh();
			actionCategories.Add(inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputCategory inputCategory = rZsTuivVzndqMzeSRfGlApLacxh();
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
				int num = XlGxOnTUQHRbKpDoMHtWoRwnusK(id2, inputAction);
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
			inputBehaviors.Add(ItMYXHKnqzmZbpjzabVKbAKABct());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, ItMYXHKnqzmZbpjzabVKbAKABct());
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
			mapCategories.Add(MgtDaUjkoCjyRdTJgOXcDqKqebDp());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, MgtDaUjkoCjyRdTJgOXcDqKqebDp());
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
			joystickLayouts.Add(TKHkhhQaBgoaILZoNzahcTRRSTJ());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, TKHkhhQaBgoaILZoNzahcTRRSTJ());
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
			keyboardLayouts.Add(snqEEPfyHpuEgxRGQNipiNiJEsdd());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, snqEEPfyHpuEgxRGQNipiNiJEsdd());
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
			mouseLayouts.Add(GUvHHgnFNlYwYkZVXuKutDrluIX());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, GUvHHgnFNlYwYkZVXuKutDrluIX());
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
			customControllerLayouts.Add(XLvcNPCbEFBPXrCvJHhxhHcSgzYe());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, XLvcNPCbEFBPXrCvJHhxhHcSgzYe());
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

		internal ControllerMap ifCgZrpoeKFgfwvVVGARrzzwHdG(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => TNNQzekbpHjCKEeRbKifsgkUPMA((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => afCOBqOskEPFuQelOCcHQoUgyBZ(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap uYfcyxtdZVDjPEdyMfUvmLwnlbjG(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return TNNQzekbpHjCKEeRbKifsgkUPMA(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap TNNQzekbpHjCKEeRbKifsgkUPMA(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return TNNQzekbpHjCKEeRbKifsgkUPMA(P_0.hardwareJoystickMapIdentifier, P_1, P_2);
		}

		private JoystickMap TNNQzekbpHjCKEeRbKifsgkUPMA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.oNdHtGaPAUegFfNDYBItOQKRuna(guid);
			ControllerMap_Editor controllerMap_Editor = RQpVOfQFcgfbkPxktnrfvAuJnCR(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.tanjLwgqvguHXmkTbUHAsfGzpwI(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.RcfaEbycwVRZfrTukoZSsFIdNiG(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.cLdABFWHhJhGBDqNNUOhtHkebrR(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = RQpVOfQFcgfbkPxktnrfvAuJnCR(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = XjIOqZIzoioJsajOasTjSRLppcg(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.RcfaEbycwVRZfrTukoZSsFIdNiG(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = RQpVOfQFcgfbkPxktnrfvAuJnCR(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.tanjLwgqvguHXmkTbUHAsfGzpwI(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.RcfaEbycwVRZfrTukoZSsFIdNiG(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.SYXlQmHOzCKJIifRKNsrYHodbMla(guid, P_1, P_2);
		}

		private ControllerMap_Editor RQpVOfQFcgfbkPxktnrfvAuJnCR(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = QgTEEfcrKFaEbzvIDxbdepGSwsV(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor QgTEEfcrKFaEbzvIDxbdepGSwsV(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				CRfiudhMQHfvfgTjHzrdnNIiPkP(list, joystickLayouts);
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

		private JoystickMap XjIOqZIzoioJsajOasTjSRLppcg(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.EipdJGwxIiCZlyOlRuRIeVBITpl(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError(string.Concat("Error remapping joystick template ", P_2.Guid, " to joystick ", P_0.guid, "\nReason: ", text));
				return null;
			}
			return controllerMap_Editor.tanjLwgqvguHXmkTbUHAsfGzpwI(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap mFSfmoyLuoBJfcScZQaEdpqbBREJ(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.oNdHtGaPAUegFfNDYBItOQKRuna(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.oNdHtGaPAUegFfNDYBItOQKRuna(Guid.Empty);
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
				list.Add(allMap.JYRMuwETpVNRqJXmtBgBFhZdTeP);
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
			ControllerMap_Editor controllerMap_Editor = imKzYNjbCdIoHCZvfxNZpbnTGJWc(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.uCZxujmTmeDtkpQYCAYcQWnzgGD(containsActionDelegate);
				keyboardMap.RcfaEbycwVRZfrTukoZSsFIdNiG(keyboard.whqrPnRNEDctHvdjThUpHsqpUGr, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.SYXlQmHOzCKJIifRKNsrYHodbMla(keyboard.whqrPnRNEDctHvdjThUpHsqpUGr, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = imKzYNjbCdIoHCZvfxNZpbnTGJWc(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.tRTFehbFgyFfnRPHYjAlJAOeXEB(containsActionDelegate);
				mouseMap.RcfaEbycwVRZfrTukoZSsFIdNiG(mouse.whqrPnRNEDctHvdjThUpHsqpUGr, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.SYXlQmHOzCKJIifRKNsrYHodbMla(mouse.whqrPnRNEDctHvdjThUpHsqpUGr, categoryId, layoutId);
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

		internal CustomControllerMap afCOBqOskEPFuQelOCcHQoUgyBZ(Guid P_0, int P_1, int P_2)
		{
			return afCOBqOskEPFuQelOCcHQoUgyBZ(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap afCOBqOskEPFuQelOCcHQoUgyBZ(int P_0, int P_1, int P_2)
		{
			return afCOBqOskEPFuQelOCcHQoUgyBZ(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap afCOBqOskEPFuQelOCcHQoUgyBZ(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = AKJSWzqgLUSFbZNOtimquWjGrdK(P_1, id, P_2, false);
			CustomControllerMap customControllerMap;
			if (controllerMap_Editor != null)
			{
				customControllerMap = controllerMap_Editor.XJOEFjCjAumIcsocXRzBCPKdVbK(ContainsAction, P_0);
				customControllerMap.RcfaEbycwVRZfrTukoZSsFIdNiG(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			customControllerMap = CustomControllerMap.SYXlQmHOzCKJIifRKNsrYHodbMla(P_0.typeGuid, id, P_1, P_2);
			customControllerMap.RcfaEbycwVRZfrTukoZSsFIdNiG(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap;
		}

		private ControllerMap_Editor AKJSWzqgLUSFbZNOtimquWjGrdK(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = ereDxfbBKjqBBQZofXyeNqeldKJd(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor ereDxfbBKjqBBQZofXyeNqeldKJd(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				CRfiudhMQHfvfgTjHzrdnNIiPkP(list, customControllerLayouts);
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

		internal ControllerTemplateMap WKyHsVifphzVQBJXsCGVKpHIutgR(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.aJzvccXmqmmnZEDsEgDhWqEexYq();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(HTwNvCjmYvtxCDCSCvWJQatMtNV());
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
			customControllers.Insert(index, HTwNvCjmYvtxCDCSCvWJQatMtNV());
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
			controllerMapLayoutManagerRuleSets.Add(PhOYnNhvxSeQkMBLbHTvfNBPQLZ());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, PhOYnNhvxSeQkMBLbHTvfNBPQLZ());
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
			controllerMapEnablerRuleSets.Add(CPSGEqengfJJjtQHIkIvEDDruZN());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, CPSGEqengfJJjtQHIkIvEDDruZN());
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

		private Player_Editor qmiZoxcnSWvfHDomviJjjeRDfiku()
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

		private InputAction QoPDHaVShtomRimNgFZDonccEyx()
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

		private InputCategory rZsTuivVzndqMzeSRfGlApLacxh()
		{
			InputCategory inputCategory = new InputCategory();
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName("Category", -1, GetActionCategoryNames());
			inputCategory.descriptiveName = inputCategory.name;
			inputCategory.userAssignable = true;
			return inputCategory;
		}

		private InputBehavior ItMYXHKnqzmZbpjzabVKbAKABct()
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

		private InputMapCategory MgtDaUjkoCjyRdTJgOXcDqKqebDp()
		{
			InputMapCategory inputMapCategory = new InputMapCategory();
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName("Category", -1, GetMapCategoryNames());
			inputMapCategory.descriptiveName = inputMapCategory.name;
			inputMapCategory.userAssignable = true;
			inputMapCategory.checkConflictsWithAllCategories = true;
			return inputMapCategory;
		}

		private InputLayout TKHkhhQaBgoaILZoNzahcTRRSTJ()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout snqEEPfyHpuEgxRGQNipiNiJEsdd()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout GUvHHgnFNlYwYkZVXuKutDrluIX()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout XLvcNPCbEFBPXrCvJHhxhHcSgzYe()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private CustomController_Editor HTwNvCjmYvtxCDCSCvWJQatMtNV()
		{
			CustomController_Editor customController_Editor = new CustomController_Editor();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
			customController_Editor.name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames());
			customController_Editor.descriptiveName = customController_Editor.name;
			return customController_Editor;
		}

		private ControllerMapLayoutManager_RuleSet_Editor PhOYnNhvxSeQkMBLbHTvfNBPQLZ()
		{
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = new ControllerMapLayoutManager_RuleSet_Editor();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames());
			return controllerMapLayoutManager_RuleSet_Editor;
		}

		private ControllerMapEnabler_RuleSet_Editor CPSGEqengfJJjtQHIkIvEDDruZN()
		{
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = new ControllerMapEnabler_RuleSet_Editor();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames());
			return controllerMapEnabler_RuleSet_Editor;
		}

		private ControllerMap_Editor YDEiVAJpvOKWsjjisAJcQcQulQR(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor imKzYNjbCdIoHCZvfxNZpbnTGJWc(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = YDEiVAJpvOKWsjjisAJcQcQulQR(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = ZxrFlfoaqVWEqouOXmYhImmLfIY(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor ZxrFlfoaqVWEqouOXmYhImmLfIY(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				CRfiudhMQHfvfgTjHzrdnNIiPkP(list, P_1);
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

		private void CRfiudhMQHfvfgTjHzrdnNIiPkP(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			jhuARnREJCyZcKcUFlEaFaVGYfb jhuARnREJCyZcKcUFlEaFaVGYfb2 = new jhuARnREJCyZcKcUFlEaFaVGYfb();
			jhuARnREJCyZcKcUFlEaFaVGYfb2.TyHBfuAXHWAyIIfnKDAEdHLAgzOw = P_1;
			if (P_0 != null && jhuARnREJCyZcKcUFlEaFaVGYfb2.TyHBfuAXHWAyIIfnKDAEdHLAgzOw != null)
			{
				P_0.Sort(jhuARnREJCyZcKcUFlEaFaVGYfb2.BUTgsekSNkrHyQxWRuMQeZhdjPha);
			}
		}

		internal void iDBXctPcOcjjzWbKaCnxuPiVNUc()
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
					mapCategories[i].iDBXctPcOcjjzWbKaCnxuPiVNUc();
				}
			}
			containsActionDelegate = ContainsAction;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return eMeIxqqaTFSeMCDXccyhspIGbSN.hPOzNiwavldFMYQXIDniqgXapIz(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return eMeIxqqaTFSeMCDXccyhspIGbSN.hPOzNiwavldFMYQXIDniqgXapIz(orig, null, false);
		}

		[CompilerGenerated]
		private static void wxChzXsyGqODjOxLoJHZgSnAAul(List<Player_Editor.Mapping> P_0, int P_1)
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
		private static void gHCOULYVUphgLpQmXHZpltGGUfB(List<Player_Editor.Mapping> P_0, int P_1)
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
		private static void xbtSfUhYiNZPScfphkapQGAtMwV(List<Player_Editor.Mapping> P_0, int P_1)
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
		private static void HFfPJsPGDyQGyHgWHqgFNcAjTKl(List<Player_Editor.Mapping> P_0, int P_1)
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
		private static void rFLbwWweGahbhJSmtbccegIedXaa(List<Player_Editor.Mapping> P_0, int P_1)
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
