using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Disable : Decorator
	{
		public Disable(Type type, string member, object value)
		{
		}

		public Disable(Type type, string member)
		{
		}

		public Disable(Type type)
		{
		}

		public Disable(string property)
		{
		}

		public Disable(string property, object value)
		{
		}

		public Disable(RenderPipeline rp)
		{
		}
	}
}
