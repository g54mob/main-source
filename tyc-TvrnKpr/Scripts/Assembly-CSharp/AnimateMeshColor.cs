using UnityEngine;

public class AnimateMeshColor : MonoBehaviour
{
	public Animator animator;

	public string resetColorState;

	public string animationState;

	public Color startColor;

	public Color endColor;

	private Material mat;

	private float completedAnimationPercentage;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
