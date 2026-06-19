using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

public class VoidClubTrail : CrystalSpikeTrail
{
	public List<SpriteObject> globSprites;

	public float centerOffsetMax = 0.1f;

	public float globOffsetMax = 0.5f;

	public override void OnOccupied()
	{
		base.OnOccupied();
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			GameObject gameObject = spriteObject.gameObject;
			gameObject.transform.localPosition = new Vector3(Random.Range(0f - centerOffsetMax, centerOffsetMax), gameObject.transform.localPosition.y, Random.Range(0f - centerOffsetMax, centerOffsetMax));
			spriteObject.animationTimescale = Random.Range(0.8f, 1.1f);
			spriteObject.PlayAnimation(-1878077465, forceResetTime: true, skipTransition: true);
			spriteObject.SetVariantByIndex(Random.Range(0, 3));
			spriteObject.ApplyVisualChange();
		}
		foreach (SpriteObject globSprite in globSprites)
		{
			if (Random.value > 0.5f)
			{
				GameObject gameObject2 = globSprite.gameObject;
				gameObject2.transform.localPosition = new Vector3(Random.Range(0f - globOffsetMax, globOffsetMax), gameObject2.transform.localPosition.y, Random.Range(0f - globOffsetMax, globOffsetMax));
				globSprite.animationTimescale = Random.Range(0.8f, 1.1f);
				globSprite.PlayAnimation(-568891545, forceResetTime: true, skipTransition: true);
				globSprite.SetVariantByIndex(Random.Range(0, 3));
				globSprite.ApplyVisualChange();
			}
		}
	}
}
