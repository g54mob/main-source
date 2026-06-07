using System;
using System.Text;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class LocalizationManager
	{
		private sealed class PvLwtEYERxBuOQQPKzLrjgebJOsP
		{
			[Serializable]
			private sealed class XSjnvtYZGNhFWlcdgzRozkaTNdwt
			{
				public static readonly XSjnvtYZGNhFWlcdgzRozkaTNdwt _003C_003E9 = new XSjnvtYZGNhFWlcdgzRozkaTNdwt();

				public static Action<gPdbPvViIcfmuVJElIIVfiLqZVrDA> _003C_003E9__7_0;

				internal void oezdeKKLiBvjmQpfYAmBwfcOZSXFA(gPdbPvViIcfmuVJElIIVfiLqZVrDA P_0)
				{
					P_0.Localize();
				}
			}

			private const float veTqgTnvzwiLZfTPvgfxbiIIdRhE = 60f;

			private readonly NQPwJDdoBKzgXcGsAuaFYHhxxYfw<gPdbPvViIcfmuVJElIIVfiLqZVrDA> xoqXaiKKtSJeHCHXPbHqnjKvfGpp;

			public bool lSmVyolKjKaxRtietvXtpTkdGnrb;

			public ILocalizedStringProvider snZVmZzlggjfXaodmhYmEtTKlpFp;

			public uint dxTsCFpBKFlPomOIZacJFoWJetjo;

			private Action<gPdbPvViIcfmuVJElIIVfiLqZVrDA> hNufzwCftTurlKeLEApoHaEwZAgfA = XSjnvtYZGNhFWlcdgzRozkaTNdwt._003C_003E9.oezdeKKLiBvjmQpfYAmBwfcOZSXFA;

			private Id itGOTfFwuyOtQcBcrJONCsVTetVO;

			public PvLwtEYERxBuOQQPKzLrjgebJOsP()
			{
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp = new NQPwJDdoBKzgXcGsAuaFYHhxxYfw<gPdbPvViIcfmuVJElIIVfiLqZVrDA>(60f);
				dxTsCFpBKFlPomOIZacJFoWJetjo = 0u;
				itGOTfFwuyOtQcBcrJONCsVTetVO = 1u;
			}

			public void ZSIEzbJHPHCNylBXJtSYruQNgSCy(ILocalizedStringProvider P_0)
			{
				snZVmZzlggjfXaodmhYmEtTKlpFp = P_0;
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
				if (snZVmZzlggjfXaodmhYmEtTKlpFp != null)
				{
					xoqXaiKKtSJeHCHXPbHqnjKvfGpp.CjjkaOYoURdeyiGrstLwvNNvLyrAA(hNufzwCftTurlKeLEApoHaEwZAgfA);
				}
			}

			public void YoqeEXKaBeYsMHaROyyFveNGcYmc()
			{
				if (snZVmZzlggjfXaodmhYmEtTKlpFp != null)
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

			public uint fyeqCafQbFyflbNbajUvornPxfgy(gPdbPvViIcfmuVJElIIVfiLqZVrDA P_0)
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
		public enum GetAndUpdateLocalizedStringResultFlags
		{
			None = 0,
			Failed = 1,
			IsCachedValue = 2,
			Changed = 4,
			JustLocalized = 8
		}

		private const char PLwtGAiCbQCcoDZREiniQMVqkbVvA = '_';

		private const char HzgcOUpDKkUHPczXzvBzeyOlnWqf = '/';

		private const string kkYKiiwLvrpItVQZKayzYXOETeYn = "/";

		internal const string hardwareTypeKey_universalKeyboard = "keyboard";

		internal const string hardwareTypeKey_universalMouse = "mouse";

		internal const string hardwareTypeKey_unknownController = "unknown_controller";

		internal const string localizationKeyAxisPoleSuffix_positive = "positive";

		internal const string localizationKeyAxisPoleSuffix_negative = "negative";

		internal const string localizationKeyAxisDirectionSuffix_horizontal = "horizontal";

		internal const string localizationKeyAxisDirectionSuffix_vertical = "vertical";

		internal const string localizationAndGlyphKeyCategory_controller = "controller";

		internal const string localizationAndGlyphKeyCategory_customController = "controller/custom";

		internal const string localizationAndGlyphKeyCategory_controllerTemplate = "controller/template";

		internal const string localizationAndGlyphKeyCategory_action = "action";

		internal const string localizationAndGlyphKeyCategory_inputActionCategory = "action/category";

		internal const string localizationAndGlyphKeyCategory_controllerMap = "controller_map";

		internal const string localizationAndGlyphKeyCategory_controllerMapCategory = "controller_map/category";

		internal const string localizationAndGlyphKeyCategory_layout = "controller_map/layout";

		internal const string localizationAndGlyphKeyCategory_player = "player";

		internal const string localizationAndGlyphKeyCategory_controllerElement = "controller/element";

		internal const string nonLocalizedDisplayNameAxisDirectionSuffix_horizontal = "Horizontal";

		internal const string nonLocalizedDisplayNameAxisDirectionSuffix_vertical = "Vertical";

		private static PvLwtEYERxBuOQQPKzLrjgebJOsP QxWLLdWggAzrIYfTYiauIDARQuKD;

		private static StringBuilder nUgRBxyXrGVtpFFAAfBgqVnEZZNk;

		public static bool isEnabled
		{
			get
			{
				if (QxWLLdWggAzrIYfTYiauIDARQuKD == null)
				{
					return false;
				}
				return QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp != null;
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

		public static ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				return QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp;
			}
			set
			{
				UxutMrQEmIhPMSKpnUzxzmTjetgV();
				QxWLLdWggAzrIYfTYiauIDARQuKD.ZSIEzbJHPHCNylBXJtSYruQNgSCy(value);
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
			QxWLLdWggAzrIYfTYiauIDARQuKD = new PvLwtEYERxBuOQQPKzLrjgebJOsP();
		}

		public static void Deinitialize()
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD != null)
			{
				QxWLLdWggAzrIYfTYiauIDARQuKD = null;
			}
		}

		public static void Add(gPdbPvViIcfmuVJElIIVfiLqZVrDA obj, ref Id id)
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
				throw new Exception(typeof(LocalizationManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp != null)
			{
				if (localizedString.TryGetLocalizedValue(null, QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out localizationVersionChanged, out result))
				{
					return true;
				}
				result = fallback;
				return false;
			}
			result = fallback;
			localizationVersionChanged = false;
			return false;
		}

		public static bool TryLocalizeString(LocalizedString localizedString, string key, uint localizationVersion, uint dependenciesVersion, out string result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp != null)
			{
				localizedString.Clear();
				bool versionChanged;
				return localizedString.TryGetLocalizedValue(key, QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (DNqlDytAIgSbpXRoGfqoeOnWzJxH(localizedString, parentKeys, keyCategory, fallback, out result))
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.JustLocalized;
					getAndUpdateLocalizedStringResultFlags &= (GetAndUpdateLocalizedStringResultFlags)(-2);
				}
				else
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Failed;
				}
			}
			return getAndUpdateLocalizedStringResultFlags;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, string key, string keyCategory, IReadOnlyList<string> parentKeys, string fallback, out string result)
		{
			if (QxWLLdWggAzrIYfTYiauIDARQuKD.snZVmZzlggjfXaodmhYmEtTKlpFp == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (DNqlDytAIgSbpXRoGfqoeOnWzJxH(localizedString, key, keyCategory, fallback, parentKeys, out result))
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.JustLocalized;
					getAndUpdateLocalizedStringResultFlags &= (GetAndUpdateLocalizedStringResultFlags)(-2);
				}
				else
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Failed;
				}
			}
			return getAndUpdateLocalizedStringResultFlags;
		}

		private static bool DNqlDytAIgSbpXRoGfqoeOnWzJxH(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
		{
			if (P_1 == null)
			{
				P_4 = P_3;
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
						AppendToKeyAsPath(sharedStringBuilder, P_1[num]);
						if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, 0u, out P_4))
						{
							result = true;
							break;
						}
					}
					num++;
					continue;
				}
				P_4 = P_3;
				break;
			}
			P_0.cachedValue = P_4;
			return result;
		}

		private static bool DNqlDytAIgSbpXRoGfqoeOnWzJxH(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_5 = P_3;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0u;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			if (P_4 != null)
			{
				for (int i = 0; i < P_4.Count; i++)
				{
					if (string.IsNullOrEmpty(P_4[i]))
					{
						continue;
					}
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(P_2);
					}
					AppendToKeyAsPath(sharedStringBuilder, P_4[i]);
					AppendToKeyAsPath(sharedStringBuilder, P_1);
					if (!TryLocalizeString(P_0, sharedStringBuilder.ToString(), QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out P_5))
					{
						continue;
					}
					goto IL_0080;
				}
			}
			if (P_4 == null || P_4.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(P_2);
				}
				AppendToKeyAsPath(sharedStringBuilder, P_1);
				if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), QxWLLdWggAzrIYfTYiauIDARQuKD.dxTsCFpBKFlPomOIZacJFoWJetjo, dependenciesVersion, out P_5))
				{
					result = true;
					goto IL_00df;
				}
			}
			P_5 = P_3;
			goto IL_00df;
			IL_00df:
			P_0.cachedValue = P_5;
			return result;
			IL_0080:
			result = true;
			goto IL_00df;
		}

		public static string ConcatenateKeyStrings(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
			{
				return b;
			}
			if (string.IsNullOrEmpty(b))
			{
				return a;
			}
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			sharedStringBuilder.Append(a);
			sharedStringBuilder.Append('_');
			sharedStringBuilder.Append(b);
			return sharedStringBuilder.ToString();
		}

		public static string AppendToKeyAsPath(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
			{
				return b;
			}
			if (string.IsNullOrEmpty(b))
			{
				return a;
			}
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			sharedStringBuilder.Append(a);
			sharedStringBuilder.Append('/');
			sharedStringBuilder.Append(b);
			return sharedStringBuilder.ToString();
		}

		public static StringBuilder AppendToKeyAsPath(StringBuilder sb, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return sb;
			}
			if (sb.Length > 0)
			{
				sb.Append('/');
			}
			sb.Append(value);
			return sb;
		}

		public static string AppendToKeyAxisPole(string a, Pole pole)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return AppendToKeyAsPath(a, (pole == Pole.Positive) ? "positive" : "negative");
		}

		public static string AppendToNameAxisPole(string text, Pole pole)
		{
			switch (pole)
			{
			case Pole.Positive:
				return text + " +";
			case Pole.Negative:
				return text + " -";
			default:
				return text;
			}
		}

		public static string AppendToKeyAxisDirection(string a, AxisDirection direction)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return AppendToKeyAsPath(a, (direction == AxisDirection.Vertical) ? "vertical" : "horizontal");
		}

		public static string AppendToNameAxisDirection(string a, AxisDirection direction)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return a + " " + ((direction == AxisDirection.Vertical) ? "Vertical" : "Horizontal");
		}

		public static string FormatKey(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			return StringTools.AddSpacesToCamelCase(text).Replace(' ', '_').ToLowerInvariant();
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
