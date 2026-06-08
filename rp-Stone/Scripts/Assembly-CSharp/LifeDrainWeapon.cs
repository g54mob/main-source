using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class LifeDrainWeapon : MonoBehaviour
{
	public BurstAndGatherEmitter burstEmitter;

	public AsciiAnimation drainVFX;

	private Weapon myWeapon;

	private Character myOwner;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (myOwner == null)
		{
			myOwner = myWeapon.Owner;
			if (myOwner != null)
			{
				myOwner.OnPostDrawCharacter += HandleDraw;
			}
		}
		if (dmg.Owner == myOwner && myOwner != null)
		{
			burstEmitter.transform.position = new Vector3(c.lastDrawX + c.HeadPivotX, c.lastDrawY + c.HeadPivotY, 0f);
			burstEmitter.gatherDestination = new Vector3(myOwner.lastDrawX + myOwner.HeadPivotX, myOwner.lastDrawY + myOwner.HeadPivotY, 0f);
			burstEmitter.Emit();
			if (drainVFX != null)
			{
				drainVFX.Play();
			}
		}
	}

	private void HandleDraw(Character c, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (drainVFX != null && myWeapon.Owner.Alive)
		{
			drainVFX.Sprite.Draw(r, offsetX, offsetY);
		}
	}

	private void Awake()
	{
		myWeapon = GetComponent<Weapon>();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	private void OnDestroy()
	{
		myWeapon = null;
		if (myOwner != null)
		{
			myOwner.OnPostDrawCharacter -= HandleDraw;
			myOwner = null;
		}
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}
}
