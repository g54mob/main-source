using AudioSystem;
using UnityEngine;

public class CentipedeArmamentCannon : CentipedeArmament
{
	[SerializeField]
	private Transform muzzleTf;

	[SerializeField]
	private float aimSpeed = 90f;

	[SerializeField]
	private float damage = 1f;

	[SerializeField]
	private SoundData sfxShoot;

	private SoundBuilder SoundBuilder;

	private float targetAngleDst;

	private float minAngleToFire = 15f;

	private new void Awake()
	{
		base.Awake();
		SoundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	private void Update()
	{
		if (enemyCentipede.TargetUnit == null || enemyCentipede.TargetUnit.ignoreProjectiles)
		{
			enemyCentipede.Target();
		}
	}

	public override bool TryDisarm()
	{
		Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, base.transform.parent.up);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, quaternion, aimSpeed * Time.deltaTime);
		if (Vector3.Angle(base.transform.up, base.transform.parent.up) <= 1f)
		{
			base.transform.rotation = quaternion;
			return true;
		}
		return false;
	}

	public override void Aim()
	{
		if (enemyCentipede.TargetUnit == null)
		{
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.Euler(0f, 0f, 270f), aimSpeed * Time.deltaTime);
			return;
		}
		Vector3 vector = enemyCentipede.TargetUnit.transform.position - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, vector);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, aimSpeed * Time.deltaTime);
		targetAngleDst = Vector3.Angle(base.transform.up, vector);
	}

	public override void Fire()
	{
		if (!(enemyCentipede.TargetUnit == null) && !(targetAngleDst > minAngleToFire))
		{
			Projectile component = Object.Instantiate(spawnPrefab, muzzleTf.position, base.transform.rotation).GetComponent<Projectile>();
			component.sourceUnit = enemyCentipede;
			component.damage = damage;
			SoundBuilder.Play(sfxShoot);
			base.Anim.Play("Shooting", 0, 0f);
		}
	}
}
