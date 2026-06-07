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
		private sealed class KuJfZTcYQPBOfZPevHMnfTWZrxRVA
		{
			[Serializable]
			private sealed class ICsjFPEShXHHnDBnoHpkArsyRezdA
			{
				public static readonly ICsjFPEShXHHnDBnoHpkArsyRezdA _003C_003E9;

				public static Action<hBzNigJHHYVhBUvxQvwFEBzIfsKT> _003C_003E9__7_0;

				internal void olRqdRfDWjsYGFTYvSGLDZBdFMAj(hBzNigJHHYVhBUvxQvwFEBzIfsKT P_0)
				{
				}
			}

			private const float CYDaIeTejRSolPkAgXZSSFtNOMpl = 60f;

			private readonly global::EJHkKdhIhufcPvJgxVXUmFKPjIQb<hBzNigJHHYVhBUvxQvwFEBzIfsKT> HCcBRjjDOJriwmBIKPnsupkeYHZL;

			public bool oWVqvpxjQRwgnHYgfwuwhLmSvIFc;

			public ILocalizedStringProvider CBbklJBvBzCXUQYDpgbHVvcbzVqA;

			public uint aKTVYlfjxzGknHCZAFQDVAmTXYSi;

			private Action<hBzNigJHHYVhBUvxQvwFEBzIfsKT> HaCYIGTNhtfUGuhOOOHXmLytxvXO;

			private Id sQMkRdgzHpmROeaPZgkzIdrhKAnT;

			public void lVESNkiJOIPCkXYXGvKkpIJJeFl(ILocalizedStringProvider P_0)
			{
			}

			public void QesPFpaWmpTvrnmPlDeoGHavyBkpA(bool P_0)
			{
			}

			public void XFhQFumESzaAQdrxZajECDJfNVCbb()
			{
			}

			public void dWxEqFWsopxTvEJjJDsUyHsOnriR()
			{
			}

			public uint OBJPejUlemCQwIaWdeRDaveFmCyV(hBzNigJHHYVhBUvxQvwFEBzIfsKT P_0)
			{
				return 0u;
			}

			public bool RFpeJhCSDrBOIwXcllxXJXQHHzCt(uint P_0)
			{
				return false;
			}

			public void GwDCbPFQSMLCqmrAwirnBIFKoELr()
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

		private const char INdgitjMvlaXsDvxQADIjrExvESAA = '_';

		private const char yQONnBqhqpWNwOtnBHugdponQVXO = '/';

		private const string ThvKwspJwrrYieLbsHpKayQENaEH = "/";

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

		private static KuJfZTcYQPBOfZPevHMnfTWZrxRVA FJMJdNOCMCLYTdlCPGJbwbZvJqYK;

		private static StringBuilder sGLeXfTgCeMXJJbOpoooKoPoIgEC;

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

		public static void Add(hBzNigJHHYVhBUvxQvwFEBzIfsKT obj, ref Id id)
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

		private static void pGfSmTtOEdzIANMuHiRpYpwdsTGQ()
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

		private static bool QpzMvBAoNZVGOMatJajFgKrskvuRA(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
		{
			P_4 = null;
			return false;
		}

		private static bool qNuqVKjkNhrnvsXTwcsRsACTTgpX(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
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
