using System;
using UnityEngine;

namespace LeTai.Common
{
	public static class SpanUtils
	{
		public static Vector4 ToVector4(ReadOnlySpan<float> span)
		{
			return default(Vector4);
		}

		public static SpanWriter<T> WriterFor<T>(Span<T> span)
		{
			return default(SpanWriter<T>);
		}
	}
}
