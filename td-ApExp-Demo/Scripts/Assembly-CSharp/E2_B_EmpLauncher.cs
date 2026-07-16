using System;
using AudioSystem;
using UnityEngine;

public class E2_B_EmpLauncher : MonoBehaviour
{
	[SerializeField]
	private GameObject empPrefab;

	[SerializeField]
	private Transform empMuzzle;

	[SerializeField]
	private SoundData empShoot;

	[SerializeField]
	private SoundData deathSFX;

	private SoundBuilder SoundBuilder;

	[NonSerialized]
	public E2_B_BossBController boss;

	private Animator anim;

	private Unit target;

	[SerializeField]
	private float aimRotationSpeed;

	private void Start()
	{
		anim = GetComponent<Animator>();
		SoundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	private void Update()
	{
		if (target != null)
		{
			Vector3 upwards = target.transform.position - base.transform.position;
			Quaternion b = Quaternion.LookRotation(Vector3.forward, upwards);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, aimRotationSpeed * Time.deltaTime);
		}
	}

	public void SetTarget(Unit target)
	{
		this.target = target;
	}

	public void Launch()
	{
		anim.SetTrigger("Shoot");
		Shoot();
	}

	public void Shoot()
	{
		EMPProjectile component = UnityEngine.Object.Instantiate(empPrefab, empMuzzle.position, empMuzzle.rotation).GetComponent<EMPProjectile>();
		component.SourceUnit = boss;
		component.duration = 8f;
		component.SetTarget(target);
		SoundBuilder.Play(empShoot);
	}

	public void Explode()
	{
		SoundBuilder.Play(deathSFX);
		base.gameObject.GetComponent<ExplodeSprite>().Explode();
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
