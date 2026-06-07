using System;
using UnityEngine;

namespace DigitalRuby.Tween
{
	public class Vector4Tween : Tween<Vector4>
	{
		private static readonly Func<ITween<Vector4>, Vector4, Vector4, float, Vector4> LerpFunc = LerpVector4;

		private static Vector4 LerpVector4(ITween<Vector4> t, Vector4 start, Vector4 end, float progress)
		{
			return Vector4.Lerp(start, end, progress);
		}

		public Vector4Tween()
			: base(LerpFunc)
		{
		}
	}
}
