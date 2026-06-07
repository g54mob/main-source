using System;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class GlyphManager
	{
		private sealed class QKBByyyzwLPKyEbZlAOlFtVLAqXnA
		{
			[Serializable]
			private sealed class kpLGedYYVUlEnmBTitIMsrKHCjjG
			{
				public static readonly kpLGedYYVUlEnmBTitIMsrKHCjjG _003C_003E9 = new kpLGedYYVUlEnmBTitIMsrKHCjjG();

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void oezdeKKLiBvjmQpfYAmBwfcOZSXFA(IPrefetch P_0)
				{
					P_0.Prefetch();
				}
			}

			private const float veTqgTnvzwiLZfTPvgfxbiIIdRhE = 60f;

			private readonly NQPwJDdoBKzgXcGsAuaFYHhxxYfw<IPrefetch> xoqXaiKKtSJeHCHXPbHqnjKvfGpp;

			public bool lSmVyolKjKaxRtietvXtpTkdGnrb;

			public IGlyphProvider AMRefIPHeYIeIXXDzkkcEKoFqyDm;

			public uint dxTsCFpBKFlPomOIZacJFoWJetjo;

			private Action<IPrefetch> hNufzwCftTurlKeLEApoHaEwZAgfA = kpLGedYYVUlEnmBTitIMsrKHCjjG._003C_003E9.oezdeKKLiBvjmQpfYAmBwfcOZSXFA;

			private Id itGOTfFwuyOtQcBcrJONCsVTetVO;

			public QKBByyyzwLPKyEbZlAOlFtVLAqXnA()
			{
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp = new NQPwJDdoBKzgXcGsAuaFYHhxxYfw<IPrefetch>(60f);
				dxTsCFpBKFlPomOIZacJFoWJetjo = 0u;
				itGOTfFwuyOtQcBcrJONCsVTetVO = 1u;
			}

			public void HdTJsfhBGNjTzDihoizdrasQjRKRA(IGlyphProvider P_0)
			{
				AMRefIPHeYIeIXXDzkkcEKoFqyDm = P_0;
				if (P_0 != null)
				{
					dxTsCFpBKFlPomOIZacJFoWJetjo = itGOTfFwuyOtQcBcrJONCsVTetVO.id;
					itGOTfFwuyOtQcBcrJONCsVTetVO.Increment();
				}
				else
				{
					dxTsCFpBKFlPomOIZacJFoWJetjo = 0u;
				}
				XldwkgfODhsAMdkotkEWhrHBlCPR();
			}

			public void UPzeMejsNimgvJsrknWoaGqCzwXSA(bool P_0)
			{
				if (P_0 != lSmVyolKjKaxRtietvXtpTkdGnrb)
				{
					lSmVyolKjKaxRtietvXtpTkdGnrb = P_0;
					if (P_0)
					{
						NYroOIhgvasFuLpkgvyYujumdYPP();
					}
				}
			}

			public void NYroOIhgvasFuLpkgvyYujumdYPP()
			{
				if (AMRefIPHeYIeIXXDzkkcEKoFqyDm != null)
				{
					xoqXaiKKtSJeHCHXPbHqnjKvfGpp.CjjkaOYoURdeyiGrstLwvNNvLyrAA(hNufzwCftTurlKeLEApoHaEwZAgfA);
				}
			}

			public void YoqeEXKaBeYsMHaROyyFveNGcYmc()
			{
				if (AMRefIPHeYIeIXXDzkkcEKoFqyDm != null)
				{
					dxTsCFpBKFlPomOIZacJFoWJetjo = itGOTfFwuyOtQcBcrJONCsVTetVO.id;
					itGOTfFwuyOtQcBcrJONCsVTetVO.Increment();
					if (lSmVyolKjKaxRtietvXtpTkdGnrb)
					{
						NYroOIhgvasFuLpkgvyYujumdYPP();
					}
					else
					{
						XldwkgfODhsAMdkotkEWhrHBlCPR();
					}
				}
			}

			public uint fyeqCafQbFyflbNbajUvornPxfgy(IPrefetch P_0)
			{
				return xoqXaiKKtSJeHCHXPbHqnjKvfGpp.fyeqCafQbFyflbNbajUvornPxfgy(P_0);
			}

			public bool QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(uint P_0)
			{
				return xoqXaiKKtSJeHCHXPbHqnjKvfGpp.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_0);
			}

			public void XldwkgfODhsAMdkotkEWhrHBlCPR()
			{
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp.XldwkgfODhsAMdkotkEWhrHBlCPR();
			}
		}

		[CustomObfuscation(rename = false)]
		public enum GetAndUpdateGlyphResultFlags
		{
			None = 0,
			Failed = 1,
			IsCachedValue = 2,
			Changed = 4,
			JustGot = 8
		}

		private static QKBByyyzwLPKyEbZlAOlFtVLAqXnA QxWLLdWggAzrIYfTYiauIDARQuKD;

		private static StringBuilder nUgRBxyXrGVtpFFAAfBgqVnEZZNk;

		public static bool isEnabled
		{
			get
			{
				if (QxWLLdWggAzrIYfTYiauIDARQuKD == null)
				{
					return false;
				}
				return QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm != null;
			}
		}

		public static uint version
		{
			get
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				return QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo;
			}
		}

		public static IGlyphProvider glyphProvider
		{
			get
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				return QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm;
			}
			set
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				QxWLLdWggAzrIYfTYiauIDARQuKD.HdTJsfhBGNjTzDihoizdrasQjRKRA(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				return QxWLLdWggAzrIYfTYiauIDARQuKD.lSmVyolKjKaxRtietvXtpTkdGnrb;
			}
			set
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				QxWLLdWggAzrIYfTYiauIDARQuKD.UPzeMejsNimgvJsrknWoaGqCzwXSA(value);
			}
		}

		public static void Initialize()
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD != null)
			{
				throw new Exception("Already initialized");
			}
			QxWLLdWggAzrIYfTYiauIDARQuKD = new QKBByyyzwLPKyEbZlAOlFtVLAqXnA();
		}

		public static void Deinitialize()
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD != null)
			{
				QxWLLdWggAzrIYfTYiauIDARQuKD = null;
			}
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
			UxutMrQEmIhPMSKpnUzxzmTjetgV();
			id = QxWLLdWggAzrIYfTYiauIDARQuKD.fyeqCafQbFyflbNbajUvornPxfgy(obj);
		}

		public static bool Remove(ref Id id)
		{
			UxutMrQEmIhPMSKpnUzxzmTjetgV();
			bool result = QxWLLdWggAzrIYfTYiauIDARQuKD.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			UxutMrQEmIhPMSKpnUzxzmTjetgV();
			QxWLLdWggAzrIYfTYiauIDARQuKD.NYroOIhgvasFuLpkgvyYujumdYPP();
		}

		public static void Reload()
		{
			UxutMrQEmIhPMSKpnUzxzmTjetgV();
			QxWLLdWggAzrIYfTYiauIDARQuKD.YoqeEXKaBeYsMHaROyyFveNGcYmc();
		}

		private static void UxutMrQEmIhPMSKpnUzxzmTjetgV()
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm != null)
			{
				return keyedGlyph.TryGetValue(null, QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm != null)
			{
				keyedGlyph.Clear();
				bool versionChanged;
				return keyedGlyph.TryGetValue(key, QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (jEbfbccJNsNwNeBjdrgQOUJWiVsx(keyedGlyph, parentKeys, keyCategory, out result))
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, string key, string keyCategory, IReadOnlyList<string> parentKeys, out object result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.AMRefIPHeYIeIXXDzkkcEKoFqyDm == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (jEbfbccJNsNwNeBjdrgQOUJWiVsx(keyedGlyph, key, keyCategory, parentKeys, out result))
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		private static bool jEbfbccJNsNwNeBjdrgQOUJWiVsx(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
		{
			if (P_1 == null)
			{
				P_3 = null;
				return false;
			}
			bool result = false;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			int num = 0;
			while (true)
			{
				if (num < P_1.Count)
				{
					if (!string.IsNullOrEmpty(P_1[num]))
					{
						sharedStringBuilder.Length = 0;
						if (flag)
						{
							sharedStringBuilder.Append(P_2);
						}
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1[num]);
						if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, 0u, out P_3))
						{
							result = true;
							break;
						}
					}
					num++;
					continue;
				}
				P_3 = null;
				break;
			}
			P_0.cachedValue = P_3;
			return result;
		}

		private static bool jEbfbccJNsNwNeBjdrgQOUJWiVsx(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_4 = null;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0u;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			if (P_3 != null)
			{
				for (int i = 0; i < P_3.Count; i++)
				{
					if (string.IsNullOrEmpty(P_3[i]))
					{
						continue;
					}
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(P_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_3[i]);
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1);
					if (!TryGetGlyph(P_0, sharedStringBuilder.ToString(), QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out P_4))
					{
						continue;
					}
					goto IL_007d;
				}
			}
			if (P_3 == null || P_3.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(P_2);
				}
				LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1);
				if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out P_4))
				{
					result = true;
					goto IL_00d9;
				}
			}
			P_4 = null;
			goto IL_00d9;
			IL_00d9:
			P_0.cachedValue = P_4;
			return result;
			IL_007d:
			result = true;
			goto IL_00d9;
		}

		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			if (nUgRBxyXrGVtpFFAAfBgqVnEZZNk != null)
			{
				nUgRBxyXrGVtpFFAAfBgqVnEZZNk.Length = 0;
				return nUgRBxyXrGVtpFFAAfBgqVnEZZNk;
			}
			return nUgRBxyXrGVtpFFAAfBgqVnEZZNk = new StringBuilder();
		}
	}
}
