// add
using System;
using System.Collections;

namespace GptDeepResearch
{
	/// <summary>
	/// Represents a builtin function that can be auto-called if it has zero arity
	/// </summary>
	public class BuiltinFunctionValue
	{
		public string Name { get; }
		public int Arity { get; }
		public Func<object[], object> SyncInvoke { get; }
		public Func<object[], IEnumerator> AsyncInvoke { get; }

		/// <summary>
		/// Constructor for synchronous builtin functions
		/// </summary>
		public BuiltinFunctionValue(string name, int arity, Func<object[], object> syncInvoke)
		{
			Name = name;
			Arity = arity;
			SyncInvoke = syncInvoke;
			AsyncInvoke = null;
		}

		/// <summary>
		/// Constructor for asynchronous builtin functions (like scene commands)
		/// </summary>
		public BuiltinFunctionValue(string name, int arity, Func<object[], IEnumerator> asyncInvoke)
		{
			Name = name;
			Arity = arity;
			SyncInvoke = null;
			AsyncInvoke = asyncInvoke;
		}

		/// <summary>
		/// Check if this is a synchronous function
		/// </summary>
		public bool IsSync => SyncInvoke != null;

		/// <summary>
		/// Check if this is an asynchronous function
		/// </summary>
		public bool IsAsync => AsyncInvoke != null;

		public override string ToString()
		{
			return $"<builtin function '{Name}'>";
		}
	}
}