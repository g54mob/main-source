using System;
using System.Collections.Generic;

namespace RoslynCSharp.Compiler
{
	public sealed class AssemblyReferenceException : Exception
	{
		private Exception[] referenceExceptions;

		internal static readonly string msg = "One or more assembly references could not be resolved. See ReferenceExceptions for more information";

		public Exception[] ReferenceExceptions => referenceExceptions;

		public AssemblyReferenceException(ICollection<Exception> allExceptions)
			: base(msg)
		{
			referenceExceptions = new Exception[allExceptions.Count];
			int num = 0;
			foreach (Exception allException in allExceptions)
			{
				referenceExceptions[num] = allException;
				num++;
			}
		}
	}
}
