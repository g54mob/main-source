using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using Google.Apis.Util;

namespace Google.Apis.Requests
{
	public sealed class VersionHeaderBuilder
	{
		private static readonly Lazy<string> s_environmentVersion = new Lazy<string>(GetEnvironmentVersion);

		public const string HeaderName = "x-goog-api-client";

		private readonly List<string> _names = new List<string>();

		private readonly List<string> _values = new List<string>();

		public VersionHeaderBuilder AppendVersion(string name, string version)
		{
			name.ThrowIfNull("name");
			version.ThrowIfNull("version");
			CheckArgument(name.Length > 0 && !name.Contains(" ") && !name.Contains("/"), "name", "Invalid name: " + name);
			CheckArgument(!version.Contains(" ") && !version.Contains("/"), "version", "Invalid version: " + version);
			CheckArgument(!_names.Contains(name), "name", "Names in version headers must be unique");
			_names.Add(name);
			_values.Add(version);
			return this;
		}

		private static void CheckArgument(bool condition, string paramName, string message)
		{
			if (!condition)
			{
				throw new ArgumentException(message, paramName);
			}
		}

		public VersionHeaderBuilder AppendAssemblyVersion(string name, Type type)
		{
			return AppendVersion(name, FormatAssemblyVersion(type));
		}

		public VersionHeaderBuilder AppendDotNetEnvironment()
		{
			return AppendVersion("gl-dotnet", s_environmentVersion.Value);
		}

		private static bool IsHeaderNameValueValid(string nameOrValue)
		{
			if (!nameOrValue.Contains(" "))
			{
				return !nameOrValue.Contains("/");
			}
			return false;
		}

		private static string GetEnvironmentVersion()
		{
			string text = FormatVersion(Environment.Version);
			return GetEntryAssemblyVersionOrNull() ?? text ?? "";
		}

		private static string GetEntryAssemblyVersionOrNull()
		{
			try
			{
				MethodInfo methodInfo = typeof(Assembly).GetTypeInfo().DeclaredMethods.Where((MethodInfo m) => m.Name == "GetEntryAssembly" && m.IsStatic && m.GetParameters().Length == 0 && m.ReturnType == typeof(Assembly)).FirstOrDefault();
				if (methodInfo == null)
				{
					return null;
				}
				string text = ((Assembly)methodInfo.Invoke(null, new object[0]))?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
				return (text == null) ? null : FormatVersion(new FrameworkName(text).Version);
			}
			catch
			{
				return null;
			}
		}

		private static string FormatAssemblyVersion(Type type)
		{
			Assembly assembly = type.GetTypeInfo().Assembly;
			string text = assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion;
			if (text != null && IsHeaderNameValueValid(text))
			{
				return FormatInformationalVersion(text);
			}
			string text2 = assembly.GetCustomAttributes<AssemblyFileVersionAttribute>().FirstOrDefault()?.Version;
			if (text2 != null)
			{
				return string.Join(".", text2.Split(new char[1] { '.' }).Take(3));
			}
			return FormatVersion(assembly.GetName().Version);
		}

		internal static string FormatInformationalVersion(string info)
		{
			int num = Math.Max(info.LastIndexOf('.'), info.LastIndexOf('+'));
			if (num == -1 || num != info.Length - 41)
			{
				return info;
			}
			for (int i = num + 1; i < info.Length; i++)
			{
				char c = info[i];
				if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
				{
					return info;
				}
			}
			return info.Substring(0, num);
		}

		private static string FormatVersion(Version version)
		{
			if (!(version != null))
			{
				return "";
			}
			return $"{version.Major}.{version.Minor}.{((version.Build != -1) ? version.Build : 0)}";
		}

		public override string ToString()
		{
			return string.Join(" ", _names.Zip(_values, (string name, string value) => name + "/" + value));
		}

		public VersionHeaderBuilder Clone()
		{
			VersionHeaderBuilder versionHeaderBuilder = new VersionHeaderBuilder();
			versionHeaderBuilder._names.AddRange(_names);
			versionHeaderBuilder._values.AddRange(_values);
			return versionHeaderBuilder;
		}
	}
}
