using System;
using System.Reflection;

namespace Jundroo.ModTools
{
	internal static class Project
	{
		public const string Name = "SimpleRockets 2";

		public const string UnityVersion = "2022.3.62f3";

		private static MethodInfo _getPropertyMainAssembly;

		private static Type _projectType;

		public static bool IsEditorModProject => false;

		public static Assembly MainAssembly => (Assembly)_getPropertyMainAssembly.Invoke(null, null);

		static Project()
		{
			_projectType = Type.GetType("ModApi.Project, ModApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", throwOnError: true, ignoreCase: false);
			_getPropertyMainAssembly = _projectType.GetProperty("MainAssembly", BindingFlags.Static | BindingFlags.Public).GetGetMethod();
		}
	}
}
