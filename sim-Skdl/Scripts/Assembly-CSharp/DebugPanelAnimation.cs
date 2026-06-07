using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DebugPanelAnimation : MonoBehaviour
{
	public enum AnimationType
	{
		Alpha = 0,
		Scale = 1
	}

	[Header("Target Image")]
	public Image targetImage;

	[Header("Animation Settings")]
	public AnimationType animationType;

	public AnimationCurve alphaCurve;

	public float duration;

	private float timer;

	private bool isPlaying;

	private Color originalColor;

	private Vector3 originalScale;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Play()
	{
	}
}
