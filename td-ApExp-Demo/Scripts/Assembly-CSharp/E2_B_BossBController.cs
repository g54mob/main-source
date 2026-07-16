using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AudioSystem;
using UnityEngine;

public class E2_B_BossBController : E2_B_BossController
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData rpgFlyingSound;

	[Header("Weapons")]
	[Header("RPG")]
	[SerializeField]
	private Transform rpgLauncherN;

	[SerializeField]
	private Transform rpgLauncherS;

	[SerializeField]
	private float rpgDamage = 5f;

	[SerializeField]
	private GameObject rpgPrefab;

	[Header("Missile")]
	[SerializeField]
	private E2_B_ArmamentSilo missileLauncher;

	[SerializeField]
	private float missileDamage = 10f;

	[Header("EMP")]
	[SerializeField]
	private Transform empLauncherTf;

	[SerializeField]
	private Transform empMuzzle;

	[SerializeField]
	private E2_B_EmpLauncher empLauncher;

	[SerializeField]
	private GameObject empPrefab;

	[SerializeField]
	private int empCount;

	[SerializeField]
	private float empTimeBetweenShots = 1f;

	[SerializeField]
	private new float empDuration;

	[Header("Laser")]
	[SerializeField]
	private Transform laserTf;

	[SerializeField]
	private E2_B_Laser laser;

	[SerializeField]
	public LineRenderer laserLr;

	[SerializeField]
	public ParticleSystem laserChargePs;

	[SerializeField]
	private float chainChargeUpTime = 8f;

	[SerializeField]
	private float chainAttackDamage = 25f;

	[SerializeField]
	private float chainAttackExplosionSize = 0.3f;

	[Header("Misc")]
	[SerializeField]
	private Transform[] healingDronePositions;

	[SerializeField]
	private ParticleSystem laserFire;

	[SerializeField]
	private ParticleSystem mainFire;

	[SerializeField]
	private ExplodeSprite laserExplodeSprite;

	private Coroutine chainAttackCoroutine;

	private Unit lastBATarget1;

	private Unit lastBATarget2;

	private int rpgShotsOnSameTarget;

	private int healPosIndex;

	private Module lastEmpTarget;

	private Unit chainAttackTarget;

	private List<GameObject> StunPsList = new List<GameObject>();

	private new void Awake()
	{
		base.Awake();
		noiseSeed = Random.Range(50000, 100000);
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[11]
		{
			new E2_B_Enter(sm, this),
			new E2_B_Idle(sm, this),
			new E2_B_ChangeLocation(sm, this),
			new E2_B_Reviving(sm, this),
			new E2_B_SpecialAttack(sm, this),
			new E2_B_PrepareChainAttack(sm, this),
			new E2_B_ChainAttack(sm, this),
			new E2_B_FullDead(sm, this),
			new E2_B_Exit(sm, this),
			new E2_B_Dead(sm, this),
			new E2_B_EMP(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	public override void Start()
	{
		base.Start();
		canAimDuringSpecialAttack = true;
	}

	public override void Aim()
	{
		if (!isEMPd && lastEmpTarget == null)
		{
			lastEmpTarget = GetRandomModule();
			empLauncher.SetTarget(lastEmpTarget);
		}
	}

	private void Target1()
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => (bool)m && m != lastBATarget1).ToArray();
		base.TargetUnit = array[Random.Range(0, array.Length)];
	}

	private void Target2()
	{
		Module[] source = Train.Instance.Modules.Where((Module m) => m).ToArray();
		float maxHealth = source.Max((Module m) => m.HealthComponent.HealthCurrent);
		TargetUnit2 = source.FirstOrDefault((Module m) => m.HealthComponent.HealthCurrent == maxHealth);
	}

	public override void BasicAttack1()
	{
		if (isEMPd)
		{
			return;
		}
		base.BasicAttack1();
		if (!(base.TargetUnit == null) && IsInPosition)
		{
			RPG component = Object.Instantiate(rpgPrefab, rpgLauncherN.position, rpgLauncherN.rotation).GetComponent<RPG>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = rpgDamage;
			component.SetTarget(base.TargetUnit);
			if (++rpgShotsOnSameTarget >= 2)
			{
				rpgShotsOnSameTarget = 0;
				Target1();
			}
			soundBuilder.Play(rpgFlyingSound);
		}
	}

	public override void BasicAttack2()
	{
		if (!isEMPd)
		{
			base.BasicAttack2();
			if (!(TargetUnit2 == null) && IsInPosition)
			{
				missileLauncher.SetTarget(TargetUnit2);
				missileLauncher.Fire(missileDamage);
			}
		}
	}

	public override bool TickBasicAttack2()
	{
		if (isEMPd)
		{
			return false;
		}
		Target2();
		return base.TickBasicAttack2();
	}

	public Transform GetHealingDronePosition()
	{
		if (++healPosIndex >= 4)
		{
			healPosIndex = 0;
		}
		return healingDronePositions[healPosIndex];
	}

	public override void SpecialAttack()
	{
		if (!isEMPd)
		{
			base.SpecialAttack();
			StartCoroutine(FireEMPs());
		}
	}

	private IEnumerator FireEMPs()
	{
		for (int i = 0; i < empCount; i++)
		{
			empLauncher.Launch();
			lastEmpTarget = GetRandomModule();
			yield return new WaitForSeconds(0.2f);
			empLauncher.SetTarget(lastEmpTarget);
			yield return new WaitForSeconds(empTimeBetweenShots);
		}
		SpecialAttackComplete = true;
	}

	private Module GetRandomModule()
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => (bool)m && !(m is ModuleCannon)).ToArray();
		if (array.Length != 0)
		{
			Module[] array2 = array.Where((Module m) => !m.IsEMPattached).ToArray();
			if (array2.Length != 0)
			{
				Module[] array3 = array2.Where((Module m) => m != lastEmpTarget).ToArray();
				if (array3.Length != 0)
				{
					lastEmpTarget = array3[Random.Range(0, array3.Length)];
					return lastEmpTarget;
				}
				return array2[Random.Range(0, array2.Length)];
			}
			return array[Random.Range(0, array.Length)];
		}
		return null;
	}

	public override void TargetChainAttack()
	{
		float highestModuleHP = Train.Instance.Modules.Where((Module m) => m).Max((Module m) => m.HealthComponent.HealthCurrent);
		chainAttackTarget = Train.Instance.Modules.FirstOrDefault((Module m) => (bool)m && m.HealthComponent.HealthCurrent == highestModuleHP);
	}

	public override void AimChainAttack()
	{
		if (!isEMPd)
		{
			laserTf.GetComponent<AimerComponent>().SetTarget(chainAttackTarget.transform);
		}
	}

	public void StopAimingChainAttack()
	{
		laserTf.GetComponent<AimerComponent>().SetTarget(null);
	}

	public override void ChargeChainAttack()
	{
		if (!isEMPd)
		{
			base.ChargeChainAttack();
			laser.Charge();
			laserChargePs.Play();
		}
	}

	public override void ChainAttack()
	{
		if (isEMPd)
		{
			return;
		}
		base.ChainAttack();
		laserChargePs.Stop();
		RaycastHit2D[] array = Physics2D.RaycastAll(laserTf.position, laserTf.up, 10f, LayerMask.GetMask("Unit"));
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit2D raycastHit2D = array[i];
			if ((bool)raycastHit2D.collider)
			{
				Module componentInChildren = raycastHit2D.collider.gameObject.GetComponentInChildren<Module>();
				if ((bool)componentInChildren && componentInChildren.IsEnemy != base.IsEnemy)
				{
					laser.Shoot();
					SetLr(laserTf.position + laserTf.up * 0.01f, laserTf.position + laserTf.up * raycastHit2D.distance);
					StartCoroutine(LaserDamage(componentInChildren));
					soundBuilder.Play(shootSound);
					return;
				}
			}
			else
			{
				laser.Abort();
				FailLr();
			}
		}
		StopAimingChainAttack();
	}

	private IEnumerator LaserDamage(Module hitModule)
	{
		HealthChangeInfo info = new HealthChangeInfo(this, Train.Instance.HealthComponent, -50f);
		Train.Instance.HealthComponent.ChangeHealthWithInfo(info);
		yield return new WaitForSeconds(0.5f);
		hitModule.HealthComponent.ReduceHealthTo0(this);
	}

	private void FailLr()
	{
		SetLr(laserTf.position + laserTf.up * 0.01f, laserTf.position + laserTf.up * 10f);
	}

	public void SetLr(Vector2 startPos, Vector2 endPos)
	{
		StartCoroutine(DrawLaserAndFadeOut(startPos, endPos, 1f));
	}

	private IEnumerator DrawLaserAndFadeOut(Vector2 startPos, Vector2 endPos, float duration)
	{
		laserLr.enabled = true;
		laserLr.positionCount = 2;
		laserLr.SetPosition(0, startPos);
		laserLr.SetPosition(1, endPos);
		SpawnExplosion(endPos);
		Color startColor = new Color(1f, 0f, 0f, 1f);
		Color endColor = new Color(1f, 0f, 0f, 1f);
		laserLr.startColor = startColor;
		laserLr.endColor = endColor;
		float elapsed = 0f;
		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			float a = Mathf.Lerp(1f, 0f, elapsed / duration);
			Color startColor2 = new Color(startColor.r, startColor.g, startColor.b, a);
			Color endColor2 = new Color(endColor.r, endColor.g, endColor.b, a);
			laserLr.startColor = startColor2;
			laserLr.endColor = endColor2;
			yield return null;
		}
		laserLr.enabled = false;
	}

	private void SpawnExplosion(Vector2 pos)
	{
		float radius = chainAttackExplosionSize;
		Object.Instantiate(explosionPrefab, pos, Quaternion.identity).GetComponent<Explosion>().Initialize(this, radius, 0f);
	}

	public override void CancelChainAttack()
	{
		laserLr.enabled = false;
		laserChargePs.Stop();
	}

	public override void EMP(float duration)
	{
		if (!(sm.CurrentState.Key == "Reviving"))
		{
			base.EMP(duration);
			StunPsList.Add(Object.Instantiate(EnemyManager.Instance.StunPsPrefab, empLauncherTf.position, Quaternion.identity, empLauncherTf));
			StunPsList.Add(Object.Instantiate(EnemyManager.Instance.StunPsPrefab, laserTf.position, Quaternion.identity, laserTf));
			StunPsList.Add(Object.Instantiate(EnemyManager.Instance.StunPsPrefab, missileLauncher.transform.position, Quaternion.identity, missileLauncher.transform));
		}
	}

	public override void OnEMPEnd()
	{
		base.OnEMPEnd();
		foreach (GameObject stunPs in StunPsList)
		{
			Object.DestroyImmediate(stunPs);
		}
	}

	public override void OnFullDead()
	{
		base.OnFullDead();
		StartCoroutine(DeathAnimation());
	}

	private IEnumerator DeathAnimation()
	{
		yield return new WaitForSeconds(0.5f);
		Object.Instantiate(explosionPrefab, laserExplodeSprite.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, 0.25f, 0f);
		CameraController.Instance.Shake(0.35f, 0.3f);
		laserExplodeSprite.Explode();
		Object.Destroy(laserExplodeSprite.gameObject);
		laserFire.Stop();
		Object.Destroy(laserFire.gameObject);
		bodyAnim.Play("DozerBodySwivel");
		yield return new WaitForSeconds(1f);
		mainFire.Play();
		Object.Instantiate(explosionPrefab, empLauncher.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, 0.45f, 0f);
		CameraController.Instance.Shake(0.5f, 0.5f);
		empLauncher.Explode();
		yield return new WaitForSeconds(2f);
		Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, 0.8f, 0f);
		GetComponent<ExplodeSprite>().Explode();
		Object.Destroy(base.gameObject);
	}
}
