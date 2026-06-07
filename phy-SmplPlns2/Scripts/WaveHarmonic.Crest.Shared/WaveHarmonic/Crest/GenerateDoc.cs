using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
	internal sealed class GenerateDoc : Attribute
	{
	}
}
