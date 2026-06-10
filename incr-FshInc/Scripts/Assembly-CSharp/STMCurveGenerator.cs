using UnityEngine;

[ExecuteInEditMode]
public class STMCurveGenerator : MonoBehaviour
{
	public bool redraw;

	[Tooltip("A sine wave.")]
	public AnimationCurve sine;

	[Tooltip("A cos wave.")]
	public AnimationCurve cos;

	public AnimationCurve linear;

	public AnimationCurve inverseLinear;
}
