using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class OnChange : Decorator
	{
		public OnChange(bool skipIfInactive = true)
		{
		}

		public OnChange(Type type, bool skipIfInactive = true)
		{
		}
	}
}
