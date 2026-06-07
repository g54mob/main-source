using System;
using System.Collections.Generic;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Theme Manager", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-200)]
	public class ThemeManager : MonoBehaviour
	{
		private static ThemeManager s_instance;

		private static bool s_initialized;

		public static readonly Dictionary<Guid, List<ThemeTarget>> ThemeTargets;

		public static ThemeManager Instance => null;

		public static bool ApplicationIsQuitting { get; private set; }

		public static bool AutoSave => false;

		public static ThemesDatabase Database => null;

		protected ThemeManager()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public ThemeData GetTheme(Guid themeId)
		{
			return null;
		}

		public ThemeData GetTheme(string themeName)
		{
			return null;
		}

		public ThemeVariantData GetVariant(Guid variantId)
		{
			return null;
		}

		public ThemeVariantData GetVariant(Guid themeId, Guid variantId)
		{
			return null;
		}

		public ThemeVariantData GetVariant(Guid themeId, string variantName)
		{
			return null;
		}

		public ThemeVariantData GetVariant(string themeName, Guid variantId)
		{
			return null;
		}

		public ThemeVariantData GetVariant(string themeName, string variantName)
		{
			return null;
		}

		public static void ActivateVariant(Guid themeId, Guid variantId)
		{
		}

		public static void ActivateVariant(Guid themeId, string variantName)
		{
		}

		public static void ActivateVariant(string themeName, Guid variantId)
		{
		}

		public static void ActivateVariant(string themeName, string variantName)
		{
		}

		public static void ActivateVariant(Guid variantId)
		{
		}

		public static void Init()
		{
		}

		public static void LoadActiveVariant(ThemeData theme)
		{
		}

		public static void RegisterTarget(ThemeTarget target)
		{
		}

		public static void SaveActiveVariant(ThemeData theme)
		{
		}

		public static void UnregisterTarget(ThemeTarget target)
		{
		}

		public static void UpdateTargets()
		{
		}

		public static void UpdateTargets(ThemeData themeData)
		{
		}

		public static void UpdateTargets(Guid themeId)
		{
		}

		private static ThemeManager AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
