public class Bush : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 5);
			PlayDebrisPuff(30);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f);
		}
	}

	public void AE_Shake()
	{
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 2);
		PlayDebrisPuff(5);
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.2f, 1.15f, 0.125f);
	}

	private void PlayDebrisPuff(int count)
	{
		if (base.entityExist)
		{
			ObjectID objectID = base.objectData.objectID;
			Manager.effects.PlayPuff(objectID switch
			{
				ObjectID.LandKelp => PuffID.KelpDebris, 
				ObjectID.MeadowBush => PuffID.GoldenLeafDebris, 
				_ => PuffID.LeafDebris, 
			}, base.transform.position, count);
		}
	}

	public override void OnPlayerTriggerEnter(PlayerController pc)
	{
		base.OnPlayerTriggerEnter(pc);
		if (spriteObjects[0] != null)
		{
			PlayShakeAnim(pc.RenderPosition, spriteObjects[0]);
		}
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.2f, 1.15f, 0.125f);
	}
}
