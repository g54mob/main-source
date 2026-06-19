using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class Turtle : Cattle
{
	public List<ParticleSystem> bubblesParticleSystems;

	private readonly int m_bubbleEvent = SpriteAsset.StringToHash("bubbles");

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += OnAnimationEvent;
	}

	private void OnAnimationEvent(int hash)
	{
		if (hash == m_bubbleEvent)
		{
			switch (Direction.FromVector(GetAnimOrientationVec3()).id)
			{
			case Direction.Id.back:
				bubblesParticleSystems[0].Play();
				break;
			case Direction.Id.left:
			case Direction.Id.right:
				bubblesParticleSystems[1].Play();
				break;
			case Direction.Id.forward:
				bubblesParticleSystems[2].Play();
				break;
			}
		}
	}
}
