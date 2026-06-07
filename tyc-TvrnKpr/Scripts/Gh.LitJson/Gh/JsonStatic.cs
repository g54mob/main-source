using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gh
{
	public static class JsonStatic
	{
		public static readonly List<RestoreReferenceInfo> RestoreReferenceList;

		private static List<Assembly> _assemblies;

		private static readonly Dictionary<string, Type> _typeLookup;

		public static Type GetType(string name)
		{
			return null;
		}
	}
}
