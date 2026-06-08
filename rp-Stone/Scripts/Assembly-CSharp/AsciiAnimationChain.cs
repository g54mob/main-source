using UnityEngine;

[RequireComponent(typeof(AsciiSpriteChain))]
public class AsciiAnimationChain : AsciiAnimation
{
	public AsciiAnimation[] animations;

	private AsciiSpriteChain spriteChain;

	private AsciiAnimation currentAnimation;

	private int index;

	private void HandleAnimationEnded(AsciiAnimation anm)
	{
		anm.OnEnded -= HandleAnimationEnded;
		int num = index + 1;
		Stop();
		if (looping || num < animations.Length)
		{
			index = num % animations.Length;
			Play();
		}
	}

	protected override void Update()
	{
	}

	public override void Play()
	{
		if (!base.Playing)
		{
			if (animations.Length == 0)
			{
				Utils.LogError("There are no animations in this animation chain '" + this?.ToString() + "'", base.gameObject);
				return;
			}
			currentAnimation = animations[index];
			if (currentAnimation.looping)
			{
				currentAnimation.looping = false;
				Utils.LogWarning(this?.ToString() + " cannot have a looping animation (" + currentAnimation?.ToString() + ") in an animation chain. Setting loop to false.", base.gameObject);
			}
			currentAnimation.gameObject.SetActive(value: true);
			spriteChain.currentSprite = currentAnimation.GetComponent<AsciiSprite>();
			currentAnimation.OnEnded += HandleAnimationEnded;
		}
		currentAnimation.Play();
		base.Playing = true;
		base.Paused = false;
	}

	public override void Stop()
	{
		base.Playing = false;
		base.Paused = false;
		if (currentAnimation != null)
		{
			currentAnimation.OnEnded -= HandleAnimationEnded;
			currentAnimation.Stop();
			currentAnimation.gameObject.SetActive(value: false);
			currentAnimation = null;
			index = 0;
		}
	}

	public override void Pause()
	{
		base.Paused = true;
		if (currentAnimation != null)
		{
			currentAnimation.Pause();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		spriteChain = GetComponent<AsciiSpriteChain>();
		if (randomStartTime && animations.Length > 1)
		{
			index = Random.Range(0, animations.Length);
		}
	}

	protected override void Start()
	{
		AsciiSprite[] componentsInChildren = GetComponentsInChildren<AsciiSprite>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i] != spriteChain)
			{
				componentsInChildren[i].Load();
			}
		}
		for (int j = 0; j < animations.Length; j++)
		{
			animations[j].gameObject.SetActive(value: false);
		}
		base.Start();
	}
}
