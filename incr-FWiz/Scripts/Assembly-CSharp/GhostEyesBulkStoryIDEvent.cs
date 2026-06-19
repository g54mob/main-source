using FMODUnity;
using UnityEngine;

public class GhostEyesBulkStoryIDEvent : StoryIDEvent
{
	public Animator GhostEyesAnimator;

	public string BulkAnimationBoolName;

	public SpriteRenderer WindowSpriteRenderer;

	public Sprite WindowSprite;

	public Sprite BrokenWindowSprite;

	public bool Broken;

	public ParticleSystem BrokenWindowEffect;

	public EventReference BulkSound;

	public EventReference BulkAndGlassBreakSound;

	public override void Trigger()
	{
	}

	public void SetWindowBroken()
	{
	}
}
