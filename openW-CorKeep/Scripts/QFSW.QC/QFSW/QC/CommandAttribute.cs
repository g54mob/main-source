using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace QFSW.QC
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	public class CommandAttribute : Attribute
	{
		public readonly string Alias;

		public readonly string Description;

		public readonly Platform SupportedPlatforms;

		public readonly MonoTargetType MonoTarget;

		public readonly bool Valid = true;

		public readonly uint ParamsInGlobalSuggestions;

		private static readonly char[] _bannedAliasChars = new char[9] { ' ', '(', ')', '{', '}', '[', ']', '<', '>' };

		public CommandAttribute([CallerMemberName] string aliasOverride = "", Platform supportedPlatforms = Platform.AllPlatforms, MonoTargetType targetType = MonoTargetType.Single, uint paramsInGlobalSuggestions = 0u)
		{
			Alias = aliasOverride;
			MonoTarget = targetType;
			SupportedPlatforms = supportedPlatforms;
			ParamsInGlobalSuggestions = paramsInGlobalSuggestions;
			for (int i = 0; i < _bannedAliasChars.Length; i++)
			{
				if (Alias.Contains(_bannedAliasChars[i]))
				{
					string message = $"Development Processor Error: Command with alias '{Alias}' contains the char '{_bannedAliasChars[i]}' which is banned. Unexpected behaviour may occur.";
					Debug.LogError(message);
					Valid = false;
					throw new ArgumentException(message, "aliasOverride");
				}
			}
		}

		public CommandAttribute(string aliasOverride, MonoTargetType targetType, Platform supportedPlatforms = Platform.AllPlatforms, uint paramsInGlobalSuggestions = 0u)
			: this(aliasOverride, supportedPlatforms, targetType, paramsInGlobalSuggestions)
		{
		}

		public CommandAttribute(string aliasOverride, string description, Platform supportedPlatforms = Platform.AllPlatforms, MonoTargetType targetType = MonoTargetType.Single, uint paramsInGlobalSuggestions = 0u)
			: this(aliasOverride, supportedPlatforms, targetType, paramsInGlobalSuggestions)
		{
			Description = description;
		}

		public CommandAttribute(string aliasOverride, string description, MonoTargetType targetType, Platform supportedPlatforms = Platform.AllPlatforms, uint paramsInGlobalSuggestions = 0u)
			: this(aliasOverride, description, supportedPlatforms, targetType, paramsInGlobalSuggestions)
		{
		}
	}
}
