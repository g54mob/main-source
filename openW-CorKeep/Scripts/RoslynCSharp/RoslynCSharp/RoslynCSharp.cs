using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Trivial.CodeSecurity;
using UnityEngine;

namespace RoslynCSharp
{
	public sealed class RoslynCSharp : ScriptableObject
	{
		public enum LogDetail
		{
			None = 0,
			Errors = 1,
			Warnings = 2,
			Info = 3
		}

		private static RoslynCSharp settings;

		[SerializeField]
		[HideInInspector]
		private bool securityCheckCode = true;

		[SerializeField]
		[HideInInspector]
		private bool allowPInvoke;

		[SerializeField]
		[HideInInspector]
		private CodeSecurityRestrictions securityRestrictions = new CodeSecurityRestrictions();

		[SerializeField]
		[HideInInspector]
		private LogDetail logDetail = LogDetail.Errors;

		[SerializeField]
		[HideInInspector]
		private bool allowUnsafeCode;

		[SerializeField]
		[HideInInspector]
		private bool allowOptimizeCode = true;

		[SerializeField]
		[HideInInspector]
		private bool allowConcurrentCompile = true;

		[SerializeField]
		[HideInInspector]
		private bool deterministic;

		[SerializeField]
		[HideInInspector]
		private bool generateInMemory = true;

		[SerializeField]
		[HideInInspector]
		private bool generateSymbols = true;

		[SerializeField]
		[HideInInspector]
		private int warningLevel = 4;

		[SerializeField]
		[HideInInspector]
		private LanguageVersion languageVersion;

		[SerializeField]
		[HideInInspector]
		private Platform targetPlatform;

		[SerializeField]
		[HideInInspector]
		private List<string> refeferences = new List<string>();

		[SerializeField]
		[HideInInspector]
		private List<AssemblyReferenceAsset> referenceAssets = new List<AssemblyReferenceAsset>();

		[SerializeField]
		[HideInInspector]
		private List<string> defineSymbols = new List<string>();

		[SerializeField]
		[HideInInspector]
		private bool allowHotReloading = true;

		[SerializeField]
		[HideInInspector]
		private bool hotReloadCopySerializedFields = true;

		[SerializeField]
		[HideInInspector]
		private bool hotReloadCopyNonSerializedFields = true;

		[SerializeField]
		[HideInInspector]
		private bool hotReloadDestroyOriginalScript = true;

		[SerializeField]
		[HideInInspector]
		private bool hotReloadDisableOriginalScript = true;

		[SerializeField]
		[HideInInspector]
		private bool hotReloadSecurityCheckCode;

		[SerializeField]
		[HideInInspector]
		private bool hotReloadUseCSharpProjectReferences = true;

		public const string settingsName = "RoslynCSharpSettings";

		public static RoslynCSharp Settings
		{
			get
			{
				if (settings == null)
				{
					LoadResources();
				}
				return settings;
			}
		}

		public bool SecurityCheckCode
		{
			get
			{
				return securityCheckCode;
			}
			set
			{
				securityCheckCode = value;
			}
		}

		public bool AllowPInvoke
		{
			get
			{
				return allowPInvoke;
			}
			set
			{
				allowPInvoke = value;
			}
		}

		public CodeSecurityRestrictions SecurityRestrictions => securityRestrictions;

		public LogDetail LogLevel
		{
			get
			{
				return logDetail;
			}
			set
			{
				logDetail = value;
			}
		}

		public bool AllowUnsafeCode
		{
			get
			{
				return allowUnsafeCode;
			}
			set
			{
				allowUnsafeCode = value;
			}
		}

		public bool AllowOptimizeCode
		{
			get
			{
				return allowOptimizeCode;
			}
			set
			{
				allowOptimizeCode = value;
			}
		}

		public bool AllowConcurrentCompile
		{
			get
			{
				return allowConcurrentCompile;
			}
			set
			{
				allowConcurrentCompile = value;
			}
		}

		public bool Deterministic
		{
			get
			{
				return deterministic;
			}
			set
			{
				deterministic = value;
			}
		}

		public bool GenerateInMemory
		{
			get
			{
				return generateInMemory;
			}
			set
			{
				generateInMemory = value;
			}
		}

		public bool GenerateSymbols
		{
			get
			{
				return generateSymbols;
			}
			set
			{
				generateSymbols = value;
			}
		}

		public int WarningLevel
		{
			get
			{
				return warningLevel;
			}
			set
			{
				warningLevel = value;
			}
		}

		public LanguageVersion LanguageVersion
		{
			get
			{
				return languageVersion;
			}
			set
			{
				languageVersion = value;
			}
		}

		public Platform TargetPlatform
		{
			get
			{
				return targetPlatform;
			}
			set
			{
				targetPlatform = value;
			}
		}

		public IList<string> References => refeferences;

		public IList<AssemblyReferenceAsset> ReferenceAssets => referenceAssets;

		public IList<string> DefineSymbols => defineSymbols;

		public bool AllowHotReloading
		{
			get
			{
				return allowHotReloading;
			}
			set
			{
				allowHotReloading = value;
			}
		}

		public bool HotReloadCopySerializedFields
		{
			get
			{
				return hotReloadCopySerializedFields;
			}
			set
			{
				hotReloadCopySerializedFields = value;
			}
		}

		public bool HotReloadCopyNonSerializedFields
		{
			get
			{
				return hotReloadCopyNonSerializedFields;
			}
			set
			{
				hotReloadCopyNonSerializedFields = value;
			}
		}

		public bool HotReloadDestroyOriginalScript
		{
			get
			{
				return hotReloadDestroyOriginalScript;
			}
			set
			{
				hotReloadDestroyOriginalScript = value;
			}
		}

		public bool HotReloadDisableOriginalScript
		{
			get
			{
				return hotReloadDisableOriginalScript;
			}
			set
			{
				hotReloadDisableOriginalScript = value;
			}
		}

		public bool HotReloadSecurityCheckCode
		{
			get
			{
				return hotReloadSecurityCheckCode;
			}
			set
			{
				hotReloadSecurityCheckCode = value;
			}
		}

		public bool HotReloadUseCSharpProjectReferences
		{
			get
			{
				return hotReloadUseCSharpProjectReferences;
			}
			set
			{
				hotReloadUseCSharpProjectReferences = value;
			}
		}

		public static void LoadResources()
		{
			settings = Resources.Load<RoslynCSharp>("RoslynCSharpSettings");
			if (settings == null)
			{
				settings = ScriptableObject.CreateInstance<RoslynCSharp>();
				Debug.LogWarningFormat("Failed to load settings asset '{0}' from resources. Default values will be used", "RoslynCSharpSettings");
			}
		}

		public static void Log(string format, params object[] args)
		{
			if (Settings.LogLevel >= LogDetail.Info)
			{
				if (args.Length == 0)
				{
					Debug.Log(format);
				}
				else
				{
					Debug.LogFormat(format, args);
				}
			}
		}

		public static void LogWarning(string format, params object[] args)
		{
			if (settings.LogLevel >= LogDetail.Warnings)
			{
				if (args.Length == 0)
				{
					Debug.LogWarning(format);
				}
				else
				{
					Debug.LogWarningFormat(format, args);
				}
			}
		}

		public static void LogError(string format, params object[] args)
		{
			if (settings.LogLevel >= LogDetail.Errors)
			{
				if (args.Length == 0)
				{
					Debug.LogError(format);
				}
				else
				{
					Debug.LogErrorFormat(format, args);
				}
			}
		}
	}
}
