using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

public class HydraBossStalactite : EntityMonoBehaviour
{
	public List<SpriteObject> StalactiteSprites;

	public List<GameObject> Shadows;

	private readonly int CrackEvent = SpriteAsset.StringToHash("crack");

	private readonly int BreakEvent = SpriteAsset.StringToHash("break");

	private readonly int HideEvent = SpriteAsset.StringToHash("hide");

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	private void HandleAnimationEvent(int hash)
	{
		if (hash == CrackEvent)
		{
			foreach (SpriteObject stalactiteSprite in StalactiteSprites)
			{
				stalactiteSprite.PlayTransformAnimation(-54247569);
			}
			return;
		}
		if (hash == BreakEvent)
		{
			foreach (GameObject shadow in Shadows)
			{
				shadow.SetActive(value: false);
			}
			return;
		}
		if (hash == HideEvent && XScaler != null)
		{
			XScaler.gameObject.SetActive(value: false);
		}
	}
}
