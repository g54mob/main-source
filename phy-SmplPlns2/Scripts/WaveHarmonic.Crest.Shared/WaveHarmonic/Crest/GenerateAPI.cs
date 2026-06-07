using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	internal sealed class GenerateAPI : Attribute
	{
		public readonly Getter _Getter;

		public readonly Setter _Setter;

		public readonly string _Name;

		public readonly string _ScriptingSymbol;

		public GenerateAPI(Getter getter = Getter.Default, Setter setter = Setter.Default, string name = null, string symbol = null)
		{
			_Getter = getter;
			_Setter = setter;
			_Name = name;
			_ScriptingSymbol = symbol;
		}

		public GenerateAPI(Setter setter, string name = null, string symbol = null)
		{
			_Setter = setter;
			_Name = name;
			_ScriptingSymbol = symbol;
		}
	}
}
