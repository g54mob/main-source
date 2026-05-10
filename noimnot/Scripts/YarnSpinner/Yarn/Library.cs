using System;
using System.Collections.Generic;

namespace Yarn
{
	public class Library
	{
		internal Dictionary<string, Delegate> Delegates;

		public Delegate GetFunction(string name)
		{
			return null;
		}

		public void ImportLibrary(Library otherLibrary)
		{
		}

		public void RegisterFunction<TResult>(string name, Func<TResult> implementation)
		{
		}

		public void RegisterFunction<T1, TResult>(string name, Func<T1, TResult> implementation)
		{
		}

		public void RegisterFunction<T1, T2, TResult>(string name, Func<T1, T2, TResult> implementation)
		{
		}

		public void RegisterFunction<T1, T2, T3, TResult>(string name, Func<T1, T2, T3, TResult> implementation)
		{
		}

		public void RegisterFunction<T1, T2, T3, T4, TResult>(string name, Func<T1, T2, T3, T4, TResult> implementation)
		{
		}

		public void RegisterFunction<T1, T2, T3, T4, T5, TResult>(string name, Func<T1, T2, T3, T4, T5, TResult> implementation)
		{
		}

		public void RegisterFunction(string name, Delegate implementation)
		{
		}

		public bool FunctionExists(string name)
		{
			return false;
		}

		public void DeregisterFunction(string name)
		{
		}

		protected void RegisterMethods(IType type)
		{
		}

		public static string GenerateUniqueVisitedVariableForNode(string nodeName)
		{
			return null;
		}
	}
}
