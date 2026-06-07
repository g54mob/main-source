using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	public class ResolutionMonitor : SingletonScriptableObject<ResolutionMonitor>
	{
		[SerializeField]
		private Vector2 optimizedResolutionFallback;

		[SerializeField]
		private float optimizedDpiFallback;

		[SerializeField]
		private string fallbackName;

		[SerializeField]
		private StaticSizerMethod[] staticSizerMethods;

		[SerializeField]
		private DpiManager dpiManager;

		private ScreenTypeConditions currentScreenConfig;

		[SerializeField]
		private List<ScreenTypeConditions> optimizedScreens;

		private static Dictionary<string, ScreenTypeConditions> lookUpScreens;

		private static HashSet<string> screenTags;

		private static Vector2 lastScreenResolution;

		private static float lastDpi;

		private static bool isDirty;

		private static string FilePath => null;

		[Obsolete]
		public static Vector2 OptimizedResolution
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[Obsolete]
		public static float OptimizedDpi
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Vector2 CurrentResolution => default(Vector2);

		public static float CurrentDpi => 0f;

		public string FallbackName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static Vector2 OptimizedResolutionFallback => default(Vector2);

		public static float OptimizedDpiFallback => 0f;

		public List<ScreenTypeConditions> OptimizedScreens => null;

		public static IEnumerable<string> CurrentScreenTags => null;

		public static ScreenTypeConditions CurrentScreenConfiguration => null;

		public static bool AddScreenTag(string screenTag)
		{
			return false;
		}

		public static bool RemoveScreenTag(string screenTag)
		{
			return false;
		}

		public static void ClearScreenTags()
		{
		}

		public static ScreenTypeConditions GetConfig(string name)
		{
			return null;
		}

		public static ScreenInfo GetOpimizedScreenInfo(string name)
		{
			return null;
		}

		public static IEnumerable<ScreenTypeConditions> GetCurrentScreenConfigurations()
		{
			return null;
		}

		private void OnEnable()
		{
		}

		public static float InvokeStaticMethod(ImpactMode mode, Component caller, Vector2 optimizedResolution, Vector2 actualResolution, float optimizedDpi, float actualDpi)
		{
			return 0f;
		}

		public static void SetDirty()
		{
		}

		public static float GetOptimizedDpi(string screenName)
		{
			return 0f;
		}

		public static Vector2 GetOptimizedResolution(string screenName)
		{
			return default(Vector2);
		}

		public static bool IsOptimizedResolution(int width, int height)
		{
			return false;
		}

		public static void Update()
		{
		}

		public static void CallResolutionChanged()
		{
		}

		public void ResolutionChanged()
		{
		}

		private static IEnumerable<IResolutionDependency> AllResolutionDependencies()
		{
			return null;
		}

		private static IEnumerable<GameObject> GetAllEditableObjects()
		{
			return null;
		}

		private static IEnumerable<GameObject> IterateHierarchy(GameObject root)
		{
			return null;
		}

		private static Vector2 GetCurrentResolution()
		{
			return default(Vector2);
		}

		private float GetCurrentDpi()
		{
			return 0f;
		}
	}
}
