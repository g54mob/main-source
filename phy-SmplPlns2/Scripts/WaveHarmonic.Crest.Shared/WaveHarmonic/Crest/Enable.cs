using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Enable : Decorator
	{
		public Enable(Type type, string member, object value)
		{
		}

		public Enable(Type type, string member)
		{
		}

		public Enable(Type type)
		{
		}

		public Enable(string property)
		{
		}

		public Enable(string property, object value)
		{
		}

		public Enable(RenderPipeline rp)
		{
		}
	}
}
