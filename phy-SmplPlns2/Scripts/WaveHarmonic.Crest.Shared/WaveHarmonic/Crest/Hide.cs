using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Hide : Decorator
	{
		public Hide(Type type, string member, object value)
		{
		}

		public Hide(Type type, string member)
		{
		}

		public Hide(Type type)
		{
		}

		public Hide(string property)
		{
		}

		public Hide(string property, object value)
		{
		}

		public Hide(RenderPipeline rp)
		{
		}
	}
}
