using System.Collections.Generic;
using UnityEngine;

public class ChristmasLightDecoration : EntityMonoBehaviour
{
	public List<SpriteRenderer> emissiveSprites;

	public override Vector3 center => GetCenter();

	protected override void Awake()
	{
		base.Awake();
		foreach (SpriteRenderer emissiveSprite in emissiveSprites)
		{
			emissiveSprite.material.SetColor("_Emissive", Color.white * 2f);
		}
	}

	private Vector3 GetCenter()
	{
		return objectVariants[base.variation].objectsToEnable[0].transform.position;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 2);
		Manager.effects.PlayPuff(PuffID.FireFloaters, particleOptions.particleSpawnLocations[0].position, 5);
		Manager.effects.PlayPuff(PuffID.SparksMachine, particleOptions.particleSpawnLocations[0].position, 2);
	}
}
