using System;
using UnityEngine;

namespace DigitalRuby.Tween
{
	public class QuaternionTween : Tween<Quaternion>
	{
		private static readonly Func<ITween<Quaternion>, Quaternion, Quaternion, float, Quaternion> LerpFunc = LerpQuaternion;

		private static Quaternion LerpQuaternion(ITween<Quaternion> t, Quaternion start, Quaternion end, float progress)
		{
			return Quaternion.Lerp(start, end, progress);
		}

		public QuaternionTween()
			: base(LerpFunc)
		{
		}
	}
}
