using UnityEngine;

[CreateAssetMenu(fileName = "New Draw Animation", menuName = "Super Text Mesh/Draw Animation Data", order = 1)]
public class STMDrawAnimData : ScriptableObject
{
	[Tooltip("How long the Draw Animation will last.")]
	public float animTime;

	public AnimationCurve animCurve = new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));

	public Vector3 startScale = Vector3.one;

	public Vector3 startOffset = Vector3.zero;

	[Tooltip("How long the fade animation will last.")]
	public float fadeTime;

	public AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));

	[Tooltip("Starting color for read out text.")]
	public Color32 startColor = Color.clear;
}
