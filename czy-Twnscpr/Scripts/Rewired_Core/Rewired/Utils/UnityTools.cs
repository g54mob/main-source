using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	public static class UnityTools
	{
		public enum UnityVersion
		{
			UNITY_2_6 = 0,
			UNITY_2_6_1 = 1,
			UNITY_3_0 = 2,
			UNITY_3_0_0 = 3,
			UNITY_3_1 = 4,
			UNITY_3_2 = 5,
			UNITY_3_3 = 6,
			UNITY_3_4 = 7,
			UNITY_3_5 = 8,
			UNITY_3_5_2 = 9,
			UNITY_3_5_7 = 10,
			UNITY_3_MAX = 11,
			UNITY_4_0 = 12,
			UNITY_4_0_1 = 13,
			UNITY_4_1 = 14,
			UNITY_4_2 = 15,
			UNITY_4_3 = 16,
			UNITY_4_4 = 17,
			UNITY_4_5 = 18,
			UNITY_4_6 = 19,
			UNITY_4_6_3p1 = 20,
			UNITY_4_6_3p1Plus = 21,
			UNITY_4_7 = 22,
			UNITY_4_8 = 23,
			UNITY_4_9 = 24,
			UNITY_4_MAX = 25,
			UNITY_5_0 = 26,
			UNITY_5_0_0p1 = 27,
			UNITY_5_0_0p1Plus = 28,
			UNITY_5_0_1 = 29,
			UNITY_5_0_2 = 30,
			UNITY_5_1 = 31,
			UNITY_5_2 = 32,
			UNITY_5_3 = 33,
			UNITY_5_4 = 34,
			UNITY_5_5 = 35,
			UNITY_5_6 = 36,
			UNITY_5_7 = 37,
			UNITY_5_8 = 38,
			UNITY_5_9 = 39,
			UNITY_5_MAX = 40,
			UNITY_2017_0 = 41,
			UNITY_2017_1 = 42,
			UNITY_2017_2 = 43,
			UNITY_2017_3 = 44,
			UNITY_2017_4 = 45,
			UNITY_2017_5 = 46,
			UNITY_2017_6 = 47,
			UNITY_2017_7 = 48,
			UNITY_2017_8 = 49,
			UNITY_2017_9 = 50,
			UNITY_2017_MAX = 51,
			UNITY_2018_0 = 52,
			UNITY_2018_1 = 53,
			UNITY_2018_2 = 54,
			UNITY_2018_3 = 55,
			UNITY_2018_4 = 56,
			UNITY_2018_5 = 57,
			UNITY_2018_6 = 58,
			UNITY_2018_7 = 59,
			UNITY_2018_8 = 60,
			UNITY_2018_9 = 61,
			UNITY_2018_MAX = 62,
			UNITY_2019_0 = 63,
			UNITY_2019_1 = 64,
			UNITY_2019_2 = 65,
			UNITY_2019_3 = 66,
			UNITY_2019_4 = 67,
			UNITY_2019_5 = 68,
			UNITY_2019_6 = 69,
			UNITY_2019_7 = 70,
			UNITY_2019_8 = 71,
			UNITY_2019_9 = 72,
			UNITY_2019_MAX = 73,
			UNITY_2020_0 = 74,
			UNITY_2020_1 = 75,
			UNITY_2020_2 = 76,
			UNITY_2020_3 = 77,
			UNITY_2020_4 = 78,
			UNITY_2020_5 = 79,
			UNITY_2020_6 = 80,
			UNITY_2020_7 = 81,
			UNITY_2020_8 = 82,
			UNITY_2020_9 = 83,
			UNITY_2020_MAX = 84,
			UNITY_2021_0 = 85,
			UNITY_2021_1 = 86,
			UNITY_2021_2 = 87,
			UNITY_2021_3 = 88,
			UNITY_2021_4 = 89,
			UNITY_2021_5 = 90,
			UNITY_2021_6 = 91,
			UNITY_2021_7 = 92,
			UNITY_2021_8 = 93,
			UNITY_2021_9 = 94,
			UNITY_2021_MAX = 95,
			UNITY_2022_0 = 96,
			UNITY_2022_1 = 97,
			UNITY_2022_2 = 98,
			UNITY_2022_3 = 99,
			UNITY_2022_4 = 100,
			UNITY_2022_5 = 101,
			UNITY_2022_6 = 102,
			UNITY_2022_7 = 103,
			UNITY_2022_8 = 104,
			UNITY_2022_9 = 105,
			UNITY_2022_MAX = 106,
			UNITY_2023_0 = 107,
			UNITY_2023_1 = 108,
			UNITY_2023_2 = 109,
			UNITY_2023_3 = 110,
			UNITY_2023_4 = 111,
			UNITY_2023_5 = 112,
			UNITY_2023_6 = 113,
			UNITY_2023_7 = 114,
			UNITY_2023_8 = 115,
			UNITY_2023_9 = 116,
			UNITY_2023_MAX = 117,
			UNITY_2024_0 = 118,
			UNITY_2024_1 = 119,
			UNITY_2024_2 = 120,
			UNITY_2024_3 = 121,
			UNITY_2024_4 = 122,
			UNITY_2024_5 = 123,
			UNITY_2024_6 = 124,
			UNITY_2024_7 = 125,
			UNITY_2024_8 = 126,
			UNITY_2024_9 = 127,
			UNITY_2024_MAX = 128,
			UNITY_2025_0 = 129,
			UNITY_2025_1 = 130,
			UNITY_2025_2 = 131,
			UNITY_2025_3 = 132,
			UNITY_2025_4 = 133,
			UNITY_2025_5 = 134,
			UNITY_2025_6 = 135,
			UNITY_2025_7 = 136,
			UNITY_2025_8 = 137,
			UNITY_2025_9 = 138,
			UNITY_2025_MAX = 139,
			Unknown = 1000
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
		internal class UnityVersionClass
		{
			public enum SJUgeJHvvuRgsolpMwEikLWLORGg
			{
				hnfKnGJajsNexmETDXJbfGoNGnW = 0,
				eGxOdjbKneYNgPpoKWJnUPTWKnf = 1,
				CtttqujwEmTVQNIFVijgZxoNTvy = 2
			}

			public readonly int major;

			public readonly int minor;

			public readonly int maintenance;

			public readonly SJUgeJHvvuRgsolpMwEikLWLORGg type;

			public readonly int build;

			public UnityVersionClass(string versionString)
			{
			}

			public override string ToString()
			{
				return null;
			}

			private string MzcDhjKhTIIWiXpLzqiofHSDKls(SJUgeJHvvuRgsolpMwEikLWLORGg P_0)
			{
				return null;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public static bool operator <(UnityVersionClass a, UnityVersionClass b)
			{
				return false;
			}

			public static bool operator >(UnityVersionClass a, UnityVersionClass b)
			{
				return false;
			}

			public static bool operator >=(UnityVersionClass a, UnityVersionClass b)
			{
				return false;
			}

			public static bool operator <=(UnityVersionClass a, UnityVersionClass b)
			{
				return false;
			}

			public static bool operator ==(UnityVersionClass a, UnityVersionClass b)
			{
				return false;
			}

			public static bool operator !=(UnityVersionClass a, UnityVersionClass b)
			{
				return false;
			}

			public static int Comparison(UnityVersionClass a, UnityVersionClass b)
			{
				return 0;
			}

			public static bool IsValidVersionString(string versionString)
			{
				return false;
			}

			private static int dVlFNUWrgkvEydOpMSVEWjqLhXt(SJUgeJHvvuRgsolpMwEikLWLORGg P_0)
			{
				return 0;
			}
		}

		private const UnityVersion hlTJDmuWiHLctnBRVkzOmTryUwm = UnityVersion.UNITY_5_0;

		private static UnityVersionClass QFusfZoUEmBCgVttVrnIeNtJrSs;

		private static UnityVersion aOceiXEbVyAwwjUGMdhRHOKbVchi;

		private static string UwQBYFltInwTbZrvYEkjZtiLSZo;

		private static Platform REyssPEqakiTutvceOtoglnmKyF;

		private static EditorPlatform oPUAJMywrLEmBbqmOIkACwccdcP;

		private static bool GILnYdEGOxrtfaALwLRmLATRvNR;

		private static bool kmEfLNkViRABrvNGUeLWSgIPLpvD;

		private static bool vjLWQYYhMbClNAqEhGSDkKnZjvN;

		private static WebplayerPlatform IGPMXAYNVLCwoLQnyhpjGNBMIbR;

		private static bool rSgOoXkHTugXPiPodwtPSWARIbv;

		private static bool soEvQKaUmZMATdCzPjqCvFMkOEI;

		private static bool mOweZDKNViXVouLIMRuvaRbVHge;

		private static bool yVYGWCPJeRQpRZnSISFZoVEMYNv;

		private static bool tNmkcIjmjyrqCcAPXtuhqaGqnSs;

		private static bool ENYGgbGaaGeroCnUiSMMqLdWgmZw;

		private static string uazyINcSUmPfrMKPxYMFrEIwnJs;

		private static ScriptingBackend aGNAriJuIPnulWgplaQLFTtidFqs;

		private static ScriptingAPILevel BFAhYvbIyxNeJFQPDuoCJakVRyRU;

		private static IExternalTools YIvbtUVWYAmZdcaOnwjyLSPoWsV;

		private static bool vyyuJrTvhZrOkFAgFhwejnxvmRR;

		[CompilerGenerated]
		private static IAndroidFallbackPlatformHelper WxNGNPlcwwCWXCcqqTkojrrZHgg;

		[CustomObfuscation]
		internal static UnityVersionClass unityVersionObj => null;

		public static UnityVersion unityVersion => default(UnityVersion);

		public static string unityVersionString => null;

		public static Platform platform => default(Platform);

		[CustomObfuscation]
		internal static Platform effectivePlatform => default(Platform);

		public static EditorPlatform editorPlatform => default(EditorPlatform);

		public static bool isEditor => false;

		public static bool isPlaying => false;

		public static bool isDebugBuild => false;

		public static WebplayerPlatform webplayerPlatform => default(WebplayerPlatform);

		public static bool logToDebugLog => false;

		[CustomObfuscation]
		internal static bool editorPlatformMatchesBuildPlatform => false;

		public static bool isSupportedVersion3 => false;

		public static bool isSupportedVersion4 => false;

		public static bool supports2DColliders => false;

		public static bool supportsSortingLayers => false;

		public static bool supportsUnityUI => false;

		public static bool supportsTouchControls => false;

		public static bool isAndroidPlatform => false;

		public static bool isIOSPlatform => false;

		public static bool isStandalonePlatform => false;

		public static bool windowsJoystickNamesReturnsEmptyStringsIfJoystickNull => false;

		public static bool supportsUnityUIGraphicRaycastTarget => false;

		public static bool supportsNestedPrefabs => false;

		public static bool supportsWindowsAppStore => false;

		public static bool supportsWindowsUWP => false;

		public static bool supportsWindowsUWP_IL2CPP => false;

		public static bool supportsXboxOne => false;

		public static bool supportsStadia => false;

		[CustomObfuscation]
		internal static ScriptingBackend scriptingBackend => default(ScriptingBackend);

		[CustomObfuscation]
		internal static ScriptingAPILevel scriptingAPILevel => default(ScriptingAPILevel);

		public static IExternalTools externalTools => null;

		internal static IAndroidFallbackPlatformHelper androidFallbackPlatformHelper
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		[CustomObfuscation]
		internal static bool isInitialized => false;

		private static bool initialized => false;

		private static bool nfskJaACbeMIaNVpffRYwtYzJkx()
		{
			return false;
		}

		internal static void nKQbCtkHPOPnqlOqEQhEesshditg(Platform P_0, EditorPlatform P_1, bool P_2, WebplayerPlatform P_3, ScriptingBackend P_4, ScriptingAPILevel P_5, IExternalTools P_6)
		{
		}

		public static WebplayerPlatform DetermineWebplayerPlatformType(Platform platform, EditorPlatform editorPlatform)
		{
			return default(WebplayerPlatform);
		}

		public static bool IsUnityVersionInRange(string minVersionStr, string maxVersionStr)
		{
			return false;
		}

		private static bool zuaZerIAqbfwrAHwzFPHxBxTQze(string P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		private static void AzTNJIYIyhgkRWUCqHoIUjzieXX()
		{
		}

		private static UnityVersion qkykzErMIFpqkJJOrOWbUfZcJss(string P_0)
		{
			return default(UnityVersion);
		}

		private static UnityVersion renMXEuehrCqwCBKXOyWTzSVJpm(int P_0)
		{
			return default(UnityVersion);
		}

		private static UnityVersion qAiqqdnpmkPQYZoNAkLHPIwztqe(int P_0)
		{
			return default(UnityVersion);
		}

		private static void VtyptetqYfhoVNGastpVLalVCRm()
		{
		}

		internal static Type WsGCxaqtIzjzrZHvaijeDPGJVug(bktPuUwtrWiVldAFZbTLMoTDhqfI P_0)
		{
			return null;
		}

		private static Type HiWzpXwdYVWRjRmjMygGBodqWwK(bktPuUwtrWiVldAFZbTLMoTDhqfI P_0)
		{
			return null;
		}

		public static List<string> GetCurrentPlatformResourecesDLLPaths()
		{
			return null;
		}

		public static Transform FindTransformInChildren(Transform transform, string name)
		{
			return null;
		}

		public static Transform FindTransformInChildren(GameObject gameObject, string name)
		{
			return null;
		}

		public static GameObject FindGameObjectInChildren(GameObject gameObject, string name)
		{
			return null;
		}

		public static GameObject FindGameObjectInChildren(Transform transform, string name)
		{
			return null;
		}

		public static T GetComponent<T>(Transform transform) where T : class
		{
			return null;
		}

		public static T GetComponent<T>(Component component) where T : class
		{
			return null;
		}

		public static T GetComponent<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static T GetComponent<T>(Transform transform, bool includeInactive) where T : class
		{
			return null;
		}

		public static T GetComponent<T>(Component component, bool includeInactive) where T : class
		{
			return null;
		}

		public static T GetComponent<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			return null;
		}

		public static Component GetComponent(Transform transform, Type type, bool includeInactive)
		{
			return null;
		}

		public static Component GetComponent(Component component, Type type, bool includeInactive)
		{
			return null;
		}

		public static Component GetComponent(GameObject gameObject, Type type, bool includeInactive)
		{
			return null;
		}

		public static Component GetComponent(Transform transform, Type type)
		{
			return null;
		}

		public static Component GetComponent(Component component, Type type)
		{
			return null;
		}

		public static Component GetComponent(GameObject gameObject, Type type)
		{
			return null;
		}

		public static T GetComponentInChildren<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static T GetComponentInChildren<T>(Component component) where T : class
		{
			return null;
		}

		public static T GetComponentInChildren<T>(Transform transform) where T : class
		{
			return null;
		}

		public static T GetComponentInChildren<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			return null;
		}

		public static T GetComponentInChildren<T>(Component component, bool includeInactive) where T : class
		{
			return null;
		}

		public static T GetComponentInChildren<T>(Transform transform, bool includeInactive) where T : class
		{
			return null;
		}

		public static Component GetComponentInChildren(GameObject gameObject, Type type)
		{
			return null;
		}

		public static Component GetComponentInChildren(Component component, Type type)
		{
			return null;
		}

		public static Component GetComponentInChildren(Transform transform, Type type)
		{
			return null;
		}

		public static Component GetComponentInChildren(GameObject gameObject, Type type, bool includeInactive)
		{
			return null;
		}

		public static Component GetComponentInChildren(Component component, Type type, bool includeInactive)
		{
			return null;
		}

		public static Component GetComponentInChildren(Transform transform, Type type, bool includeInactive)
		{
			return null;
		}

		public static T GetComponentInSelfOrChildren<T>(Transform transform) where T : class
		{
			return null;
		}

		public static T GetComponentInSelfOrChildren<T>(Component component) where T : class
		{
			return null;
		}

		public static T GetComponentInSelfOrChildren<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static T GetComponentInParents<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static T GetComponentInParents<T>(Component component) where T : class
		{
			return null;
		}

		public static T GetComponentInParents<T>(Transform transform) where T : class
		{
			return null;
		}

		public static T GetComponentInSelfOrParents<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static T GetComponentInSelfOrParents<T>(Component component) where T : class
		{
			return null;
		}

		public static T GetComponentInSelfOrParents<T>(Transform transform) where T : class
		{
			return null;
		}

		public static List<T> GetComponents<T>(Transform transform) where T : class
		{
			return null;
		}

		public static List<T> GetComponents<T>(Component component) where T : class
		{
			return null;
		}

		public static List<T> GetComponents<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static List<T> GetComponents<T>(Transform transform, bool includeInactive) where T : class
		{
			return null;
		}

		public static List<T> GetComponents<T>(Component component, bool includeInactive) where T : class
		{
			return null;
		}

		public static List<T> GetComponents<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			return null;
		}

		public static List<Component> GetComponents(Transform transform, Type type)
		{
			return null;
		}

		public static List<Component> GetComponents(Component component, Type type)
		{
			return null;
		}

		public static List<Component> GetComponents(GameObject gameObject, Type type)
		{
			return null;
		}

		public static List<Component> GetComponents(Transform transform, Type type, bool includeInactive)
		{
			return null;
		}

		public static List<Component> GetComponents(Component component, Type type, bool includeInactive)
		{
			return null;
		}

		public static List<Component> GetComponents(GameObject gameObject, Type type, bool includeInactive)
		{
			return null;
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInChildren<T>(Component component) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform, bool includeInactive) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInChildren<T>(Component component, bool includeInactive) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			return null;
		}

		public static List<Component> GetComponentsInChildren(Transform transform)
		{
			return null;
		}

		public static List<Component> GetComponentsInChildren(Component component)
		{
			return null;
		}

		public static List<Component> GetComponentsInChildren(GameObject gameObject)
		{
			return null;
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(Transform transform) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(Component component) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInParents<T>(Transform transform) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInParents<T>(Component component) where T : class
		{
			return null;
		}

		public static List<T> GetComponentsInParents<T>(GameObject gameObject) where T : class
		{
			return null;
		}

		public static List<Component> GetComponentsInParents(Transform transform)
		{
			return null;
		}

		public static List<Component> GetComponentsInParents(Component component)
		{
			return null;
		}

		public static List<Component> GetComponentsInParents(GameObject gameObject)
		{
			return null;
		}

		public static int GetComponents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponents<T>(Component component, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponents<T>(Transform transform, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponents<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponents<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponents(Transform transform, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponents(Component component, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponents(GameObject gameObject, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponents(Transform transform, Type type, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponents(Component component, Type type, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponents(GameObject gameObject, Type type, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren(Transform transform, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren(Component component, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren(GameObject gameObject, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren<T>(Transform transform, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren<T>(Transform transform, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInChildren(Transform transform, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInChildren(Component component, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInChildren(GameObject gameObject, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInParents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInParents<T>(Component component, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInParents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			return 0;
		}

		public static int GetComponentsInParents(Transform transform, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInParents(Component component, List<Component> results, bool append)
		{
			return 0;
		}

		public static int GetComponentsInParents(GameObject gameObject, List<Component> results, bool append)
		{
			return 0;
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate, bool includeChildren) where T : class
		{
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate) where T : class
		{
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate, bool includeChildren) where T : class
		{
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate) where T : class
		{
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate, bool includeChildren) where T : class
		{
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
		}

		public static void ForEachComponentInChildren<T>(Transform transform, Action<T> @delegate) where T : class
		{
		}

		public static void ForEachComponentInChildren<T>(Component component, Action<T> @delegate) where T : class
		{
		}

		public static void ForEachComponentInChildren<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
		}

		public static bool IsEnabled(Component component)
		{
			return false;
		}

		public static bool IsActiveAndEnabled(Component component)
		{
			return false;
		}

		public static UnityEngine.Object Instantiate(UnityEngine.Object original, Transform parent, bool instantiateInWorldSpace)
		{
			return null;
		}

		public static UnityEngine.Object Instantiate(UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace)
		{
			return null;
		}

		public static T Instantiate<T>(UnityEngine.Object original, Transform parent, bool instantiateInWorldSpace) where T : UnityEngine.Object
		{
			return null;
		}

		public static T Instantiate<T>(UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace) where T : UnityEngine.Object
		{
			return null;
		}

		public static Vector3 TransformPoint(Transform from, Transform to, Vector3 point)
		{
			return default(Vector3);
		}

		public static Vector3 TransformPoint(Transform from, Transform to)
		{
			return default(Vector3);
		}

		public static Vector3 TransformDirection(Transform from, Transform to, Vector3 direction)
		{
			return default(Vector3);
		}

		public static Vector3 TransformDirection(Transform from, Transform to)
		{
			return default(Vector3);
		}

		public static Vector3 TransformVector(Transform from, Transform to, Vector3 vector)
		{
			return default(Vector3);
		}

		public static Vector3 TransformVector(Transform from, Transform to)
		{
			return default(Vector3);
		}

		public static Rect TransformRect(Transform from, Transform to, Rect rect)
		{
			return default(Rect);
		}

		public static void DebugDrawCross(Vector3 position, float length, Color color)
		{
		}

		public static void DebugDrawCross(Vector3 position, float length, Color color, float duration)
		{
		}

		[CustomObfuscation]
		internal static bool IsObjectInScene<T>(T @object) where T : UnityEngine.Object
		{
			return false;
		}

		public static string GetUnityInputAxisName(int unityJoystickIndex, int axisIndex)
		{
			return null;
		}

		public static string GetUnityInputAxisNameByJoystickId(int unityJoystickId, int axisIndex)
		{
			return null;
		}

		public static string GetUnityInputButtonName(int unityJoystickIndex, int buttonIndex)
		{
			return null;
		}

		public static string GetUnityInputButtonNameByJoystickId(int unityJoystickId, int buttonIndex)
		{
			return null;
		}

		public static bool IsValidUnityJoystickName(string name)
		{
			return false;
		}

		public static AnimationCurve Copy(AnimationCurve orig)
		{
			return null;
		}

		public static bool IsNullOrDestroyed(object @object)
		{
			return false;
		}

		public static bool IsNullOrDestroyed<T>(T @object) where T : class
		{
			return false;
		}

		private static T NOrqVPLsamBykpCfmlMgpTaGQkm<T>(T P_0) where T : class
		{
			return null;
		}

		internal static ButtonStateFlags PShSztBmuaZaRPcfDskKjABWeih(KeyCode P_0)
		{
			return default(ButtonStateFlags);
		}

		internal static ButtonStateFlags GcQePpiafhoRDeIbiFcQbxTpLzm(string P_0)
		{
			return default(ButtonStateFlags);
		}
	}
}
