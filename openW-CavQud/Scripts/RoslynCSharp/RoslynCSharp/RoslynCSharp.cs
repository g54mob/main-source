using System.Collections.Generic;
using System.Diagnostics;
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
		private List<string> defineSymbols = new List<string>();

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

		public IList<string> DefineSymbols => defineSymbols;

		public static void LoadResources()
		{
			settings = Resources.Load<RoslynCSharp>("RoslynCSharpSettings");
			if (settings == null)
			{
				settings = ScriptableObject.CreateInstance<RoslynCSharp>();
				UnityEngine.Debug.LogWarningFormat("Failed to load settings asset '{0}' from resources. Default values will be used", "RoslynCSharpSettings");
			}
		}

		[Conditional("DEBUG")]
		public static void Log(string format, params object[] args)
		{
			if (Settings.LogLevel >= LogDetail.Info)
			{
				if (args.Length == 0)
				{
					UnityEngine.Debug.Log(format);
				}
				else
				{
					UnityEngine.Debug.LogFormat(format, args);
				}
			}
		}

		[Conditional("DEBUG")]
		public static void LogWarning(string format, params object[] args)
		{
			if (settings.LogLevel >= LogDetail.Warnings)
			{
				if (args.Length == 0)
				{
					UnityEngine.Debug.LogWarning(format);
				}
				else
				{
					UnityEngine.Debug.LogWarningFormat(format, args);
				}
			}
		}

		[Conditional("DEBUG")]
		public static void LogError(string format, params object[] args)
		{
			if (settings.LogLevel >= LogDetail.Errors)
			{
				if (args.Length == 0)
				{
					UnityEngine.Debug.LogError(format);
				}
				else
				{
					UnityEngine.Debug.LogErrorFormat(format, args);
				}
			}
		}
	}
}
