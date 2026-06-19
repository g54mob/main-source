using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class OctopusTentacle : EntityMonoBehaviour
{
	private readonly int m_AttackEvent = SpriteAsset.StringToHash("attack");

	protected override bool updateAnimOrientation => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	private void WaterSplash(Vector3 effectPosition)
	{
		AudioManager.Sfx(SfxID.puddle2, effectPosition, 0.6f, 1.1f, 0.1f, reuse: true);
		AudioManager.Sfx(SfxID.splash, effectPosition, 0.8f, 0.75f, 0.1f, reuse: true);
		Manager.effects.PlayPuff(PuffID.WaterSplash, effectPosition, 20);
		Manager.effects.PlayPuff(PuffID.WaterSplashMist, effectPosition, 20);
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_AttackEvent == hash)
		{
			AnimationOrientationCD componentData = EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world);
			Vector3 vector = XScaler.position + componentData.facingDirection.vec3 * 2f;
			if (Manager.multiMap.GetTileLayerLookup().GetTopTile(vector.ToWorld().RoundToInt2()).tileType == TileType.water)
			{
				WaterSplash(vector);
			}
			else
			{
				Manager.effects.PlayPuff(PuffID.DirtImpact, vector);
			}
		}
	}
}
