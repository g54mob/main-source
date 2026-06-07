using System;
using System.Collections.Generic;

namespace com.ootii.Helpers
{
	public sealed class AssemblyHelper
	{
		private static readonly object mLock;

		private static AssemblyHelper mInstance;

		private string _AssemblyInfo;

		private List<Type> mFoundTypes;

		public static AssemblyHelper Instance => null;

		public string AssemblyInfo => null;

		public List<Type> FoundTypes => null;

		private AssemblyHelper()
		{
		}

		static AssemblyHelper()
		{
		}

		public string GetAssemblyQualifiedName(string rClassName, bool rThisAssembly = true)
		{
			return null;
		}

		public static Type ResolveType(string rTypeString)
		{
			return null;
		}

		public static Type ResolveType(string rTypeString, out bool rNameChanged)
		{
			rNameChanged = default(bool);
			return null;
		}
	}
}
