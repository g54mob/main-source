using UnityEngine;

public class PowerGraphTest : MonoBehaviour
{
	public AnimationCurve curveA;

	public AnimationCurve curveB;

	public AnimationCurve curveC;

	public AnimationCurve curveD;

	private void Start()
	{
		curveD = CombineWithLagueNoise(20, curveA, curveB, curveC);
	}

	public AnimationCurve CombineWithLagueNoise(int resolution, AnimationCurve geo, AnimationCurve fuel, AnimationCurve ox)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		float num = Mathf.Max((geo.length > 0) ? geo.keys[geo.length - 1].time : 0f, (fuel.length > 0) ? fuel.keys[fuel.length - 1].time : 0f, (ox.length > 0) ? ox.keys[ox.length - 1].time : 0f);
		float num2 = 0.5f;
		float num3 = 0.2f;
		for (int i = 0; i <= resolution; i++)
		{
			float time = num / (float)resolution * (float)i;
			float num4 = geo.Evaluate(time);
			float num5 = (fuel.Evaluate(time) - 0.5f) * 2f;
			float num6 = (ox.Evaluate(time) - 0.5f) * 2f;
			float num7 = 1f;
			float num8 = 0f;
			float num9 = 0f;
			num8 += num5 * num7;
			num9 += num7;
			num7 *= num2;
			num8 += num6 * num7;
			num9 += num7;
			num8 /= num9;
			float num10 = 1f + num8 * num3;
			float b = num4 * num10;
			animationCurve.AddKey(time, Mathf.Max(0f, b));
		}
		for (int j = 0; j < animationCurve.length; j++)
		{
			animationCurve.SmoothTangents(j, 0f);
		}
		return animationCurve;
	}
}
