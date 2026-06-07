using System;
using UnityEngine;

namespace Motorways
{
	public class TweenRadians : Tween<float>
	{
		protected override float LerpValue(float startValue, float endValue, float alpha)
		{
			return Mathf.LerpAngle(startValue * 57.29578f, endValue * 57.29578f, alpha) * ((float)Math.PI / 180f);
		}
	}
}
