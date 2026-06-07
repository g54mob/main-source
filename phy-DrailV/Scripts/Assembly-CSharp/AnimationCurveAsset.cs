using UnityEngine;

[CreateAssetMenu(menuName = "DV/AnimationCurve asset")]
public class AnimationCurveAsset : ScriptableObject
{
	public AnimationCurve curve;

	public float Evaluate(float t)
	{
		return curve.Evaluate(t);
	}
}
