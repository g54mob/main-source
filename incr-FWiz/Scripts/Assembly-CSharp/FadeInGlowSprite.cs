using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeInGlowSprite : MonoBehaviour
{
	public SpriteRenderer SpriteRenderer;

	public Light2D Light;

	public Ease Ease;

	public float AnimationTime;

	private void OnEnable()
	{
	}
}
