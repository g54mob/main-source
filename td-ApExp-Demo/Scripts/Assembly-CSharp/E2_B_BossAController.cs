using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AudioSystem;
using UnityEngine;

public class E2_B_BossAController : E2_B_BossController
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData chainLatch;

	[SerializeField]
	private Transform wheel1;

	[SerializeField]
	private Transform wheel2;

	[Header("Weapons")]
	[SerializeField]
	private Transform turret1;

	[SerializeField]
	private E2_B_GarbageThrower thrower1;

	[SerializeField]
	private Transform muzzle1;

	[SerializeField]
	private Transform turret2;

	[SerializeField]
	private E2_B_GarbageThrower thrower2;

	[SerializeField]
	private Transform muzzle2;

	[SerializeField]
	private float turretShotTime = 4f;

	[SerializeField]
	public float turretDamage = 2f;

	[Header("Attacks")]
	[SerializeField]
	private int healBotCount = 4;

	[SerializeField]
	private float healBotDeployTime = 2f;

	[SerializeField]
	private float healBotHealth = 2f;

	[SerializeField]
	private float healAmount = 1f;

	[SerializeField]
	private float healInterval = 1f;

	[Header("Special")]
	[SerializeField]
	private E2_B_ArmamentSpawner spawner;

	[Header("ChainAttack")]
	[SerializeField]
	private GameObject chainPrefab;

	[SerializeField]
	private Transform chainAnchor;

	[SerializeField]
	private int numberOfChains = 4;

	[SerializeField]
	private float chainHealth = 5f;

	[Header("Misc")]
	[SerializeField]
	private ParticleSystem hatchFire;

	[SerializeField]
	private ParticleSystem grillsFire;

	[SerializeField]
	private ExplodeSprite explodeWheel;

	private List<ExtendableLinksComponent> chains;

	private int activeChains;

	private Unit lastBATarget1;

	private Unit lastBATarget2;

	private Coroutine chainCoroutine;

	private List<GameObject> StunPsList = new List<GameObject>();

	public float DroneHealth => healBotHealth;

	public float HealAmount => healAmount;

	public float HealInterval => healInterval;

	private new void Awake()
	{
		base.Awake();
		noiseSeed = Random.Range(0, 50000);
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
		chains = new List<ExtendableLinksComponent>();
	}

	public override void Start()
	{
		base.Start();
	}

	public override void Aim()
	{
		if (!isEMPd)
		{
			if ((bool)turret1)
			{
				Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, base.TargetUnit.transform.position.y) - base.transform.position;
				Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
				turret1.transform.rotation = Quaternion.RotateTowards(turret1.transform.rotation, to, Time.deltaTime * 60f);
			}
			if ((bool)turret2)
			{
				Vector3 upwards2 = new Vector3(TargetUnit2.transform.position.x, TargetUnit2.transform.position.y) - base.transform.position;
				Quaternion to2 = Quaternion.LookRotation(Vector3.forward, upwards2);
				turret2.transform.rotation = Quaternion.RotateTowards(turret2.transform.rotation, to2, Time.deltaTime * 60f);
			}
		}
	}

	public override void Target()
	{
		Target1();
		Target2();
	}

	public void Target1()
	{
		Module[] array = (from m in Train.Instance.Modules.Where((Module m) => m).ToArray()
			where m != lastBATarget1 && m != TargetUnit2
			select m).ToArray();
		base.TargetUnit = array[Random.Range(0, array.Length)];
		lastBATarget1 = base.TargetUnit;
		thrower1.TargetUnit = base.TargetUnit;
	}

	public void Target2()
	{
		Module[] array = (from m in Train.Instance.Modules.Where((Module m) => m).ToArray()
			where m != lastBATarget2 && m != base.TargetUnit
			select m).ToArray();
		TargetUnit2 = array[Random.Range(0, array.Length)];
		lastBATarget2 = TargetUnit2;
		thrower2.TargetUnit = TargetUnit2;
	}

	protected override void RotateWheel(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxWheelAngle;
		float z2 = Mathf.Lerp(z, b, Time.deltaTime * relativeSpeedMult);
		Quaternion rotation = Quaternion.Euler(0f, 0f, z2);
		if ((bool)wheel1)
		{
			wheel1.rotation = rotation;
		}
		wheel2.rotation = rotation;
	}

	public override void BasicAttack1()
	{
		if (!isEMPd)
		{
			base.BasicAttack1();
			if (!(base.TargetUnit == null) && IsInPosition)
			{
				thrower1.GetComponent<Animator>().SetTrigger("Throw");
			}
		}
	}

	public override void BasicAttack2()
	{
		if (!isEMPd)
		{
			base.BasicAttack2();
			if (!(TargetUnit2 == null) && IsInPosition)
			{
				thrower2.GetComponent<Animator>().SetTrigger("Throw");
			}
		}
	}

	public override void SpecialAttack()
	{
		if (!isEMPd)
		{
			base.SpecialAttack();
			StartCoroutine(SpawnHealBotsCoroutine());
		}
	}

	private IEnumerator SpawnHealBotsCoroutine()
	{
		for (int i = 0; i < healBotCount; i++)
		{
			spawner.PlaySpawnAnim();
			yield return new WaitForSeconds(healBotDeployTime);
		}
		SpecialAttackComplete = true;
	}

	public override void ChargeChainAttack()
	{
		if (!isEMPd)
		{
			base.ChargeChainAttack();
			targetPos += new Vector3(-1f, 0f, 0f);
			chainCoroutine = StartCoroutine(ThrowChains());
		}
	}

	public override void ChainAttack()
	{
		if (!isEMPd)
		{
			base.ChainAttack();
			StartCoroutine(ReleaseChains());
		}
	}

	private IEnumerator ThrowChains()
	{
		activeChains = numberOfChains;
		for (int i = 0; i < numberOfChains; i++)
		{
			GameObject obj = Object.Instantiate(chainPrefab, chainAnchor.GetChild(i));
			Module module = Train.Instance.Modules[i];
			ChainController component = obj.GetComponent<ChainController>();
			component.ExtensionState = ExtensionState.Expanding;
			component.OnDestroyed += ChainDestroyed;
			component.OnAttached += ChainAttached;
			component.SetHealth(chainHealth);
			component.SetTarget(module.ModuleSlot.NorthAnchor);
			chains.Add(component);
			soundBuilder.Play(shootSound);
			yield return new WaitForSeconds(0.3f);
		}
		yield return null;
	}

	private void ChainAttached(ExtendableLinksComponent obj)
	{
		Train.Instance.AddSlowDebuff(25f);
		soundBuilder.Play(chainLatch);
	}

	public void ChainDestroyed(ExtendableLinksComponent chain)
	{
		chain.OnDestroyed -= ChainDestroyed;
		chain.OnAttached -= ChainAttached;
		chains.Remove(chain);
		if (--activeChains <= 0)
		{
			chains = new List<ExtendableLinksComponent>();
			dualBossController.ChainsBroke = true;
			dualBossController.sm.ForceState("Exit");
		}
	}

	public IEnumerator ReleaseChains()
	{
		if (chainCoroutine != null)
		{
			StopCoroutine(chainCoroutine);
		}
		foreach (ExtendableLinksComponent chain in chains)
		{
			chain.OnDestroyed -= ChainDestroyed;
		}
		chains = new List<ExtendableLinksComponent>();
		for (int i = 0; i < chainAnchor.childCount; i++)
		{
			if (chainAnchor.GetChild(i).childCount > 0)
			{
				Object.Destroy(chainAnchor.GetChild(i).GetChild(0).gameObject);
			}
		}
		Train.Instance.RemoveSlowDebuff();
		dualBossController.sm.ForceState("Idle");
		yield return null;
	}

	public override void EMP(float duration)
	{
		if (!(sm.CurrentState.Key == "Reviving"))
		{
			base.EMP(duration);
			StunPsList.Add(Object.Instantiate(EnemyManager.Instance.StunPsPrefab, thrower1.transform.position, Quaternion.identity, thrower1.transform));
			StunPsList.Add(Object.Instantiate(EnemyManager.Instance.StunPsPrefab, thrower2.transform.position, Quaternion.identity, thrower2.transform));
			StunPsList.Add(Object.Instantiate(EnemyManager.Instance.StunPsPrefab, spawner.transform.position, Quaternion.identity, spawner.transform));
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

	public override void CancelChainAttack()
	{
		base.CancelChainAttack();
	}

	protected override void OnBossDeath()
	{
		base.OnBossDeath();
		thrower1.Burn(burn: true);
		thrower2.Burn(burn: true);
	}

	protected override void OnBossRevive()
	{
		base.OnBossRevive();
		thrower1.Burn(burn: false);
		thrower2.Burn(burn: false);
	}

	public override void OnFullDead()
	{
		base.OnFullDead();
		StartCoroutine(DeathAnimation());
	}

	private IEnumerator DeathAnimation()
	{
		explodeWheel.Explode();
		Object.Destroy(explodeWheel.gameObject);
		bodyAnim.Play("TruckBodySwivel");
		yield return new WaitForSeconds(1f);
		thrower1.Explode();
		yield return new WaitForSeconds(0.5f);
		thrower2.Explode();
		yield return new WaitForSeconds(1f);
		Object.Instantiate(explosionPrefab, spawner.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, 0.6f, 0f);
		CameraController.Instance.Shake(0.5f, 0.5f);
		spawner.hatchTop.Explode();
		Object.Destroy(spawner.hatchTop.gameObject);
		spawner.hatchBottom.Explode();
		Object.Destroy(spawner.hatchBottom.gameObject);
		hatchFire.Play();
		yield return new WaitForSeconds(0.5f);
		grillsFire.Play();
		yield return new WaitForSeconds(0.5f);
		Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, 0.8f, 0f);
		GetComponent<ExplodeSprite>().Explode();
		Object.Destroy(base.gameObject);
	}
}
