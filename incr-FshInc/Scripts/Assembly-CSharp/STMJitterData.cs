using UnityEngine;

[CreateAssetMenu(fileName = "New Jitter Data", menuName = "Super Text Mesh/Jitter Data", order = 1)]
public class STMJitterData : ScriptableObject
{
	public float amount;

	public bool perlin;

	public float perlinTimeMulti = 20f;

	public AnimationCurve distance = new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));

	public AnimationCurve distanceOverTime = new AnimationCurve(new Keyframe(0f, 1f, 0f, 0f), new Keyframe(1f, 1f, 0f, 0f));

	[Range(0.0001f, 100f)]
	public float distanceOverTimeMulti = 1f;
}
