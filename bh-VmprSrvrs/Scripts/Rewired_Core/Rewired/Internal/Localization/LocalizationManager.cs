using System;
using System.Text;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class LocalizationManager
	{
		private sealed class YpnSIdrQbgETthsrhKMKukKKRvLKA
		{
			[Serializable]
			private sealed class KGEoMxfoGoSItyeywqpLQnyjAkzP
			{
				public static readonly KGEoMxfoGoSItyeywqpLQnyjAkzP _003C_003E9;

				public static Action<xhTIrAyzidwqJvnsOZtknehDNwYU> _003C_003E9__7_0;

				internal void qvvDkrCBxMcXQheFjlAymsBcdPMSA(xhTIrAyzidwqJvnsOZtknehDNwYU P_0)
				{
				}
			}

			private const float KcpxSemQcqLDvsBQqFMhllmKOlVc = 60f;

			private readonly global::SDbdmeMnWVcFaOaKxZtoBBwQxdSF<xhTIrAyzidwqJvnsOZtknehDNwYU> JZYWbXWggywjgJTJKHIHTojpOdPF;

			public bool qFffCPAEMuhEawMBtmqHGpZVbwAf;

			public ILocalizedStringProvider OprxpTwjGcLiVdoPTaIEkzhtxcLj;

			public uint yvdcKFIASCzDfgISOZDysJiCBBGKA;

			private Action<xhTIrAyzidwqJvnsOZtknehDNwYU> XIiDXwDaYIMLUEZLKuFsvFsgbtHbb;

			private Id yMyfiVVniQnlQZdGHifOhzjiGNjg;

			public void xxpPrpRggbXHUZaPFeEpVdOAOTLw(ILocalizedStringProvider P_0)
			{
			}

			public void YBKgOXLJRWGktORSdieNsBgwEHgBA(bool P_0)
			{
			}

			public void XdJGOMDAxApNKYJoFXjbyWBmEXSO()
			{
			}

			public void bMHrjzpLPSnWtxvaXVujLNaBVnsS()
			{
			}

			public uint WbdFIFfLXXELkvrLnfRcHVgSTCqtA(xhTIrAyzidwqJvnsOZtknehDNwYU P_0)
			{
				return 0u;
			}

			public bool ZaJtYFfQcGpRCXVjfcvgudOElvOR(uint P_0)
			{
				return false;
			}

			public void UhhyCbwTzzNQcHGTydKCwFBPiIXP()
			{
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

		private const char EvDNbLErUSpYkgwqWKDhYpSqVKSn = '_';

		private const char eseGcfNMNYhQckvuPRoDqUyaAVROA = '/';

		private const string TVVBHWIXRITooTmmwEVrLdGFUREv = "/";

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

		private static YpnSIdrQbgETthsrhKMKukKKRvLKA TQmUxPbjRbEHXWJOZOEzLDiuBOKA;

		private static StringBuilder ySxzBQoXNvTJEouktiFNbcchYAhB;

		public static bool isEnabled => false;

		public static uint version => 0u;

		public static ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static void Initialize()
		{
		}

		public static void Deinitialize()
		{
		}

		public static void Add(xhTIrAyzidwqJvnsOZtknehDNwYU obj, ref Id id)
		{
		}

		public static bool Remove(ref Id id)
		{
			return false;
		}

		public static void Prefetch()
		{
		}

		public static void Reload()
		{
		}

		private static void tfJhvdCQbQILMvulFqNUDpakzNMBA()
		{
		}

		public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
		{
			localizationVersionChanged = default(bool);
			result = null;
			return false;
		}

		public static bool TryLocalizeString(LocalizedString localizedString, string key, uint localizationVersion, uint dependenciesVersion, out string result)
		{
			result = null;
			return false;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
		{
			result = null;
			return default(GetAndUpdateLocalizedStringResultFlags);
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, string key, string keyCategory, IReadOnlyList<string> parentKeys, string fallback, out string result)
		{
			result = null;
			return default(GetAndUpdateLocalizedStringResultFlags);
		}

		private static bool MTRkmlzUmmJJUpDuFLjcrZvltvas(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
		{
			P_4 = null;
			return false;
		}

		private static bool oSYDMcKmmMEknJwYqnqgXxCQbkfW(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
		{
			P_5 = null;
			return false;
		}

		public static string ConcatenateKeyStrings(string a, string b)
		{
			return null;
		}

		public static string AppendToKeyAsPath(string a, string b)
		{
			return null;
		}

		public static StringBuilder AppendToKeyAsPath(StringBuilder sb, string value)
		{
			return null;
		}

		public static string AppendToKeyAxisPole(string a, Pole pole)
		{
			return null;
		}

		public static string AppendToNameAxisPole(string text, Pole pole)
		{
			return null;
		}

		public static string AppendToKeyAxisDirection(string a, AxisDirection direction)
		{
			return null;
		}

		public static string AppendToNameAxisDirection(string a, AxisDirection direction)
		{
			return null;
		}

		public static string FormatKey(string text)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			return null;
		}
	}
}
