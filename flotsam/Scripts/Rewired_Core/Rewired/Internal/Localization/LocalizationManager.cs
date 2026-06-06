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
		private sealed class SohpkbvSKXcRmXsMsLVmeTsDTTvf
		{
			[Serializable]
			private sealed class YAGlphpniVvfsRDBvcLnMOEoSpXl
			{
				public static readonly YAGlphpniVvfsRDBvcLnMOEoSpXl _003C_003E9 = new YAGlphpniVvfsRDBvcLnMOEoSpXl();

				public static Action<fuTAbCyJgOZBWWgBXmUSttFWWuoi> _003C_003E9__7_0;

				internal void wfpJtQSQhneDqFyigPeCcvXfhxqE(fuTAbCyJgOZBWWgBXmUSttFWWuoi P_0)
				{
					P_0.Localize();
				}
			}

			private const float IfvFQGoNbLccuDRebhMTjfJPhgBdA = 60f;

			private readonly global::KzfQCuMWKcBHvhIjiQIELWzVhLyv<fuTAbCyJgOZBWWgBXmUSttFWWuoi> HAYjnNARXXTpnybiFkMzVeCowgbq;

			public bool cVlmIXIRhFeOtVIyqrdbKNpMePqo;

			public ILocalizedStringProvider SStOSXaBlPpmIGLyMzSgizBsVArK;

			public uint iKdFpVfGxtSmmtTrBBSKrgYLChqvA;

			private Action<fuTAbCyJgOZBWWgBXmUSttFWWuoi> LvgonaeCnhCyFoqqTTCMHwElpRbP = YAGlphpniVvfsRDBvcLnMOEoSpXl._003C_003E9.wfpJtQSQhneDqFyigPeCcvXfhxqE;

			private Id wPeSQNTUXxMETyStIplkvlNnjwFs;

			public SohpkbvSKXcRmXsMsLVmeTsDTTvf()
			{
				HAYjnNARXXTpnybiFkMzVeCowgbq = new global::KzfQCuMWKcBHvhIjiQIELWzVhLyv<fuTAbCyJgOZBWWgBXmUSttFWWuoi>(60f);
				iKdFpVfGxtSmmtTrBBSKrgYLChqvA = 0u;
				wPeSQNTUXxMETyStIplkvlNnjwFs = 1u;
			}

			public void xFpRmlDOVSHuFqXeOcZVREkLhvrV(ILocalizedStringProvider P_0)
			{
				SStOSXaBlPpmIGLyMzSgizBsVArK = P_0;
				if (P_0 != null)
				{
					iKdFpVfGxtSmmtTrBBSKrgYLChqvA = wPeSQNTUXxMETyStIplkvlNnjwFs.id;
					wPeSQNTUXxMETyStIplkvlNnjwFs.Increment();
				}
				else
				{
					iKdFpVfGxtSmmtTrBBSKrgYLChqvA = 0u;
				}
				MCfwFdsREWXqtoqqlzuwmAzWzgpS();
			}

			public void ISnsDZlkxNjqdexcxNtiEQzbhUt(bool P_0)
			{
				if (P_0 != cVlmIXIRhFeOtVIyqrdbKNpMePqo)
				{
					cVlmIXIRhFeOtVIyqrdbKNpMePqo = P_0;
					if (P_0)
					{
						LXfKWZaEbiALxMJEqjHqyvtxluj();
					}
				}
			}

			public void LXfKWZaEbiALxMJEqjHqyvtxluj()
			{
				if (SStOSXaBlPpmIGLyMzSgizBsVArK != null)
				{
					HAYjnNARXXTpnybiFkMzVeCowgbq.cDSrTXhbnOhragUUBjpNUNZmnQXY(LvgonaeCnhCyFoqqTTCMHwElpRbP);
				}
			}

			public void hVFQCxpGadfLaAbJUfLRLeAWFXAg()
			{
				if (SStOSXaBlPpmIGLyMzSgizBsVArK != null)
				{
					iKdFpVfGxtSmmtTrBBSKrgYLChqvA = wPeSQNTUXxMETyStIplkvlNnjwFs.id;
					wPeSQNTUXxMETyStIplkvlNnjwFs.Increment();
					if (cVlmIXIRhFeOtVIyqrdbKNpMePqo)
					{
						LXfKWZaEbiALxMJEqjHqyvtxluj();
					}
					else
					{
						MCfwFdsREWXqtoqqlzuwmAzWzgpS();
					}
				}
			}

			public uint AfjGdXIfaaSuxvWocsIWrTAFkuCRA(fuTAbCyJgOZBWWgBXmUSttFWWuoi P_0)
			{
				return HAYjnNARXXTpnybiFkMzVeCowgbq.hIvovHVycAsETKhbyBaTjGTJZfpk(P_0);
			}

			public bool VCLfNRleZdwYLaCMiyiOaSwXFTcJ(uint P_0)
			{
				return HAYjnNARXXTpnybiFkMzVeCowgbq.mWWzFZepvjeRDDpPaQhsUmEzGyxyA(P_0);
			}

			public void MCfwFdsREWXqtoqqlzuwmAzWzgpS()
			{
				HAYjnNARXXTpnybiFkMzVeCowgbq.QBBfslHhUSFaibroWpVWnhhNeeBH();
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

		private const char SnBSkXSEhjpXfBeJRMiPYFgxjsco = '_';

		private const char aOyPAtTaWtzulMLEAhGfEAxhxHjF = '/';

		private const string TjVfsCFWyneXrlmRbWKBMTwYIjoHb = "/";

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

		private static SohpkbvSKXcRmXsMsLVmeTsDTTvf ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb;

		private static StringBuilder sOzIUBkncuPuUZvVaJltbpIgEsen;

		public static bool isEnabled
		{
			get
			{
				if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb == null)
				{
					return false;
				}
				return ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK != null;
			}
		}

		public static uint version
		{
			get
			{
				dZNARpKgUjakTXKKYBSqgnUfBtuOA();
				return ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA;
			}
		}

		public static ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				dZNARpKgUjakTXKKYBSqgnUfBtuOA();
				return ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK;
			}
			set
			{
				dZNARpKgUjakTXKKYBSqgnUfBtuOA();
				ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.xFpRmlDOVSHuFqXeOcZVREkLhvrV(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				dZNARpKgUjakTXKKYBSqgnUfBtuOA();
				return ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.cVlmIXIRhFeOtVIyqrdbKNpMePqo;
			}
			set
			{
				dZNARpKgUjakTXKKYBSqgnUfBtuOA();
				ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.ISnsDZlkxNjqdexcxNtiEQzbhUt(value);
			}
		}

		public static void Initialize()
		{
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb != null)
			{
				throw new Exception("Already initialized");
			}
			ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb = new SohpkbvSKXcRmXsMsLVmeTsDTTvf();
		}

		public static void Deinitialize()
		{
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb != null)
			{
				ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb = null;
			}
		}

		public static void Add(fuTAbCyJgOZBWWgBXmUSttFWWuoi obj, ref Id id)
		{
			dZNARpKgUjakTXKKYBSqgnUfBtuOA();
			id = ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.AfjGdXIfaaSuxvWocsIWrTAFkuCRA(obj);
		}

		public static bool Remove(ref Id id)
		{
			dZNARpKgUjakTXKKYBSqgnUfBtuOA();
			bool result = ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.VCLfNRleZdwYLaCMiyiOaSwXFTcJ(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			dZNARpKgUjakTXKKYBSqgnUfBtuOA();
			ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.LXfKWZaEbiALxMJEqjHqyvtxluj();
		}

		public static void Reload()
		{
			dZNARpKgUjakTXKKYBSqgnUfBtuOA();
			ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.hVFQCxpGadfLaAbJUfLRLeAWFXAg();
		}

		private static void dZNARpKgUjakTXKKYBSqgnUfBtuOA()
		{
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb == null)
			{
				throw new Exception(typeof(LocalizationManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
		{
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK != null)
			{
				if (localizedString.TryGetLocalizedValue(null, ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK, ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, dependenciesVersion, out localizationVersionChanged, out result))
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
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK != null)
			{
				localizedString.Clear();
				bool versionChanged;
				return localizedString.TryGetLocalizedValue(key, ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK, ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
		{
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (EoTDfwnZRVcLZAXiYiUirHuTXYdb(localizedString, parentKeys, keyCategory, fallback, out result))
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
			if (ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.SStOSXaBlPpmIGLyMzSgizBsVArK == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (yHSjqJAJCxVkoqpnpxQsXwrHUPtb(localizedString, key, keyCategory, fallback, parentKeys, out result))
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

		private static bool EoTDfwnZRVcLZAXiYiUirHuTXYdb(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
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
						if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, 0u, out P_4))
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

		private static bool yHSjqJAJCxVkoqpnpxQsXwrHUPtb(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
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
					if (!TryLocalizeString(P_0, sharedStringBuilder.ToString(), ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, dependenciesVersion, out P_5))
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
				if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), ZQkJdrhkMQCfGbpuWhVeBLnzrfyhb.iKdFpVfGxtSmmtTrBBSKrgYLChqvA, dependenciesVersion, out P_5))
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
			if (sOzIUBkncuPuUZvVaJltbpIgEsen != null)
			{
				sOzIUBkncuPuUZvVaJltbpIgEsen.Length = 0;
				return sOzIUBkncuPuUZvVaJltbpIgEsen;
			}
			return sOzIUBkncuPuUZvVaJltbpIgEsen = new StringBuilder();
		}
	}
}
