using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Show : Decorator
	{
		public Show(Type type, string member, object value)
		{
		}

		public Show(Type type, string member)
		{
		}

		public Show(Type type)
		{
		}

		public Show(string property)
		{
		}

		public Show(string property, object value)
		{
		}

		public Show(RenderPipeline rp)
		{
		}
	}
}
