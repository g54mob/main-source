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
		private sealed class zbNCxTvrNFlzjgaHQhNPwgZfEZwt
		{
			[Serializable]
			private sealed class lOuGiXhiiNwahmOYLSOKQCpGQaYi
			{
				public static readonly lOuGiXhiiNwahmOYLSOKQCpGQaYi _003C_003E9 = new lOuGiXhiiNwahmOYLSOKQCpGQaYi();

				public static Action<IfopinoSAuQZnpEvFIfBnubyAxLB> _003C_003E9__7_0;

				internal void VcVyBVAPXpdoMyxNSfDhgKzRnopC(IfopinoSAuQZnpEvFIfBnubyAxLB P_0)
				{
					P_0.Localize();
				}
			}

			private const float hpJkrgeJgZIldDydDFwwctmctwQPB = 60f;

			private readonly global::nvBlnMElFudOyJAqIDsjvVIbYJjZ<IfopinoSAuQZnpEvFIfBnubyAxLB> yNwgWfSFSBFMmJTbdRiUAFpCYiojA;

			public bool BZLRtzSDaXFZgqNpIiDKBOOiHNvPA;

			public ILocalizedStringProvider fDBPrnepiZQtJlSrePPVquoQlXao;

			public uint TMBCQvdWmjtjtCwevFsvFgfelxhyb;

			private Action<IfopinoSAuQZnpEvFIfBnubyAxLB> oWKdFWsJibqhCJLrnemhLilJfPwJA = lOuGiXhiiNwahmOYLSOKQCpGQaYi._003C_003E9.VcVyBVAPXpdoMyxNSfDhgKzRnopC;

			private Id HbCAflTsEbiPCARmcHHBargJBiGic;

			public zbNCxTvrNFlzjgaHQhNPwgZfEZwt()
			{
				yNwgWfSFSBFMmJTbdRiUAFpCYiojA = new global::nvBlnMElFudOyJAqIDsjvVIbYJjZ<IfopinoSAuQZnpEvFIfBnubyAxLB>(60f);
				TMBCQvdWmjtjtCwevFsvFgfelxhyb = 0u;
				HbCAflTsEbiPCARmcHHBargJBiGic = 1u;
			}

			public void GpNOXNRAGQynCBRhiYjuJDTrnxsO(ILocalizedStringProvider P_0)
			{
				fDBPrnepiZQtJlSrePPVquoQlXao = P_0;
				if (P_0 != null)
				{
					TMBCQvdWmjtjtCwevFsvFgfelxhyb = HbCAflTsEbiPCARmcHHBargJBiGic.id;
					HbCAflTsEbiPCARmcHHBargJBiGic.Increment();
				}
				else
				{
					TMBCQvdWmjtjtCwevFsvFgfelxhyb = 0u;
				}
				dZNWeNkrTUihqVIvNNKDorQmtaox();
			}

			public void bPmAdpVbpxYjwIcAEFfCmrIBjGXf(bool P_0)
			{
				if (P_0 != BZLRtzSDaXFZgqNpIiDKBOOiHNvPA)
				{
					BZLRtzSDaXFZgqNpIiDKBOOiHNvPA = P_0;
					if (P_0)
					{
						sqzYmLNFbthJSOEIiOCgqStJzjzE();
					}
				}
			}

			public void sqzYmLNFbthJSOEIiOCgqStJzjzE()
			{
				if (fDBPrnepiZQtJlSrePPVquoQlXao != null)
				{
					yNwgWfSFSBFMmJTbdRiUAFpCYiojA.VQypiftOqKaitpdJhMReTskQUMET(oWKdFWsJibqhCJLrnemhLilJfPwJA);
				}
			}

			public void YYpnTHhlqzadxbhKqNEsDrjcFcXl()
			{
				if (fDBPrnepiZQtJlSrePPVquoQlXao != null)
				{
					TMBCQvdWmjtjtCwevFsvFgfelxhyb = HbCAflTsEbiPCARmcHHBargJBiGic.id;
					HbCAflTsEbiPCARmcHHBargJBiGic.Increment();
					if (BZLRtzSDaXFZgqNpIiDKBOOiHNvPA)
					{
						sqzYmLNFbthJSOEIiOCgqStJzjzE();
					}
					else
					{
						dZNWeNkrTUihqVIvNNKDorQmtaox();
					}
				}
			}

			public uint loDDChnrlsypmzNjIPwtBbpvCuFZ(IfopinoSAuQZnpEvFIfBnubyAxLB P_0)
			{
				return yNwgWfSFSBFMmJTbdRiUAFpCYiojA.KzNFDaXdZQnOsbknYnymfwQnPwRB(P_0);
			}

			public bool amfSybpGDbdjMFDFCIprcfFfCDrM(uint P_0)
			{
				return yNwgWfSFSBFMmJTbdRiUAFpCYiojA.XUsTejstazeMUIrOUEBLcuzNrmoX(P_0);
			}

			public void dZNWeNkrTUihqVIvNNKDorQmtaox()
			{
				yNwgWfSFSBFMmJTbdRiUAFpCYiojA.zmlKINPFJCScnWBdabJphDQrfoCKA();
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

		private const char xCjjOhUwttaQamKbbgGoMHBVqQri = '_';

		private const char DSkJLJjztokqlYCuHJGQLhRtoug = '/';

		private const string sJtcFmdSjtIEwGRSLrssbPFiujrZb = "/";

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

		private static zbNCxTvrNFlzjgaHQhNPwgZfEZwt qdWfCBtNDWduROCduYrPPrKJFhlr;

		private static StringBuilder ZKHEhbgEbcuhJidMIONUpAzQKmbS;

		public static bool isEnabled
		{
			get
			{
				if (qdWfCBtNDWduROCduYrPPrKJFhlr == null)
				{
					return false;
				}
				return qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao != null;
			}
		}

		public static uint version
		{
			get
			{
				UMrxuNGHFhIxSebVaIkHjjlXMvvu();
				return qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb;
			}
		}

		public static ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				UMrxuNGHFhIxSebVaIkHjjlXMvvu();
				return qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao;
			}
			set
			{
				UMrxuNGHFhIxSebVaIkHjjlXMvvu();
				qdWfCBtNDWduROCduYrPPrKJFhlr.GpNOXNRAGQynCBRhiYjuJDTrnxsO(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				UMrxuNGHFhIxSebVaIkHjjlXMvvu();
				return qdWfCBtNDWduROCduYrPPrKJFhlr.BZLRtzSDaXFZgqNpIiDKBOOiHNvPA;
			}
			set
			{
				UMrxuNGHFhIxSebVaIkHjjlXMvvu();
				qdWfCBtNDWduROCduYrPPrKJFhlr.bPmAdpVbpxYjwIcAEFfCmrIBjGXf(value);
			}
		}

		public static void Initialize()
		{
			if (qdWfCBtNDWduROCduYrPPrKJFhlr != null)
			{
				throw new Exception("Already initialized");
			}
			qdWfCBtNDWduROCduYrPPrKJFhlr = new zbNCxTvrNFlzjgaHQhNPwgZfEZwt();
		}

		public static void Deinitialize()
		{
			if (qdWfCBtNDWduROCduYrPPrKJFhlr != null)
			{
				qdWfCBtNDWduROCduYrPPrKJFhlr = null;
			}
		}

		public static void Add(IfopinoSAuQZnpEvFIfBnubyAxLB obj, ref Id id)
		{
			UMrxuNGHFhIxSebVaIkHjjlXMvvu();
			id = qdWfCBtNDWduROCduYrPPrKJFhlr.loDDChnrlsypmzNjIPwtBbpvCuFZ(obj);
		}

		public static bool Remove(ref Id id)
		{
			UMrxuNGHFhIxSebVaIkHjjlXMvvu();
			bool result = qdWfCBtNDWduROCduYrPPrKJFhlr.amfSybpGDbdjMFDFCIprcfFfCDrM(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			UMrxuNGHFhIxSebVaIkHjjlXMvvu();
			qdWfCBtNDWduROCduYrPPrKJFhlr.sqzYmLNFbthJSOEIiOCgqStJzjzE();
		}

		public static void Reload()
		{
			UMrxuNGHFhIxSebVaIkHjjlXMvvu();
			qdWfCBtNDWduROCduYrPPrKJFhlr.YYpnTHhlqzadxbhKqNEsDrjcFcXl();
		}

		private static void UMrxuNGHFhIxSebVaIkHjjlXMvvu()
		{
			if (qdWfCBtNDWduROCduYrPPrKJFhlr == null)
			{
				throw new Exception(typeof(LocalizationManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
		{
			if (qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao != null)
			{
				if (localizedString.TryGetLocalizedValue(null, qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao, qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, dependenciesVersion, out localizationVersionChanged, out result))
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
			if (qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao != null)
			{
				localizedString.Clear();
				bool versionChanged;
				return localizedString.TryGetLocalizedValue(key, qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao, qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
		{
			if (qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (daleZtdClZrCCtQYkWxMbczYPVSB(localizedString, parentKeys, keyCategory, fallback, out result))
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
			if (qdWfCBtNDWduROCduYrPPrKJFhlr.fDBPrnepiZQtJlSrePPVquoQlXao == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (PEyWdUSEPrWpsJogNTBtPVOtIEOC(localizedString, key, keyCategory, fallback, parentKeys, out result))
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

		private static bool daleZtdClZrCCtQYkWxMbczYPVSB(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
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
						if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, 0u, out P_4))
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

		private static bool PEyWdUSEPrWpsJogNTBtPVOtIEOC(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
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
					if (!TryLocalizeString(P_0, sharedStringBuilder.ToString(), qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, dependenciesVersion, out P_5))
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
				if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), qdWfCBtNDWduROCduYrPPrKJFhlr.TMBCQvdWmjtjtCwevFsvFgfelxhyb, dependenciesVersion, out P_5))
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
			return pole switch
			{
				Pole.Positive => text + " +", 
				Pole.Negative => text + " -", 
				_ => text, 
			};
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
			if (ZKHEhbgEbcuhJidMIONUpAzQKmbS != null)
			{
				ZKHEhbgEbcuhJidMIONUpAzQKmbS.Length = 0;
				return ZKHEhbgEbcuhJidMIONUpAzQKmbS;
			}
			return ZKHEhbgEbcuhJidMIONUpAzQKmbS = new StringBuilder();
		}
	}
}
