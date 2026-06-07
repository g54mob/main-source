using UnityEngine;

public class Mageblade : Weapon
{
	private int litCounter;

	public Sprite litSprite;

	public Sprite dimSprite;

	public override void CastSpell()
	{
		owner.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Mageblade, 0.9f, 1.1f, 1f);
		owner.AddAura(new Aura(Aura.Type.Damage, foreign: false, temp: false, null, owner.UPGRADED ? 4 : 2), 60);
		owner.BuffParticles("CA52C9", 60);
		litCounter += 60;
	}

	private void Update()
	{
		if (litCounter > 0)
		{
			GetComponent<SpriteRenderer>().sprite = litSprite;
			litCounter--;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = dimSprite;
		}
	}
}
