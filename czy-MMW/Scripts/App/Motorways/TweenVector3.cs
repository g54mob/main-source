using UnityEngine;

namespace Motorways
{
	public class TweenVector3 : Tween<Vector3>
	{
		protected override Vector3 LerpValue(Vector3 startValue, Vector3 endValue, float alpha)
		{
			return startValue + (endValue - startValue) * alpha;
		}
	}
}
