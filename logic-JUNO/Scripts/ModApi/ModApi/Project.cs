using System;
using System.Reflection;

namespace ModApi
{
	public static class Project
	{
		public static class FileExtensions
		{
			public const string Craft = "sr2-craft";

			public const string Generic = "simplerockets2";

			public const string GenericLegacy = "sr2";

			public const string Mod = "sr2-mod";

			public const string Sandbox = "sr2-sandbox";
		}

		public const string ExecutableName = "SimpleRockets2";

		public const string DisplayName = "Juno: New Origins";

		public const string Name = "SimpleRockets 2";

		public const string UnityVersion = "2022.3.62f3";

		private static Assembly _mainAssembly;

		public static bool IsEditorModProject => false;

		public static Assembly MainAssembly
		{
			get
			{
				if (_mainAssembly == null)
				{
					_mainAssembly = Assembly.GetAssembly(Type.GetType("Assets.Scripts.Game, SimpleRockets2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", throwOnError: true, ignoreCase: false));
				}
				return _mainAssembly;
			}
		}
	}
}
