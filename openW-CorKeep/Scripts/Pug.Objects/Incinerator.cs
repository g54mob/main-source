using Pug.Sprite;
using UnityEngine;

public class Incinerator : Extractor
{
	public SpriteObject animationEventSprite;

	public ParticleSystem sparkSystem;

	private static readonly int sparkID = SpriteAsset.StringToHash("spark");

	protected override void Awake()
	{
		base.Awake();
		animationEventSprite.onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		animationEventSprite.onAnimationEvent -= HandleAnimationEvent;
	}

	private void HandleAnimationEvent(int hash)
	{
		if (hash == sparkID)
		{
			sparkSystem.Play(withChildren: true);
		}
	}
}
