using System;
using System.Reflection;
using UnityEngine;

namespace Jundroo.Common
{
	public static class Project
	{
		public static class FileExtensions
		{
			public const string Craft = "sp2-craft";

			public const string Generic = "SimplePlanes2";

			public const string GenericLegacy = "sp2";

			public const string Mod = "sp2-mod";

			public const string ModAndroid = "sp2-mod-android";
		}

		public static class Name
		{
			public const string AbbreviationLowercase = "sp2";

			public const string AbbreviationUppercase = "SP2";

			public const string Display = "SimplePlanes 2";

			public const string DisplayNoSpaces = "SimplePlanes2";

			public const string ExecutableNoExtension = "SimplePlanes 2";

			public const string LowercaseNoSpaces = "simpleplanes2";

			public const string Package = "com.jundroo.SimplePlanes2";
		}

		public const string SteamAppID = "2840470";

		public const string UnityVersion = "6000.0.59f2";

		public const string UrlScheme = "simpleplanes2://";

		private static Assembly _mainAssembly;

		public static bool IsEditorModProject => false;

		public static Assembly MainAssembly
		{
			get
			{
				if (_mainAssembly == null)
				{
					_mainAssembly = Assembly.GetAssembly(Type.GetType("Assets.Scripts.Game, Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", throwOnError: true, ignoreCase: false));
				}
				return _mainAssembly;
			}
		}

		public static string PersistentDataPath => Application.persistentDataPath;
	}
}
