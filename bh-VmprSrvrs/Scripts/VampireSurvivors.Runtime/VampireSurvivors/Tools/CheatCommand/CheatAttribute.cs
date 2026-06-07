using System;

namespace VampireSurvivors.Tools.CheatCommand
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class CheatAttribute : Attribute
	{
		public string Alias { get; }

		public CheatAttribute(string alias = null)
		{
		}
	}
}
