using Pathfinding.RVO;
using UnityEngine;

public class UnitAudio : MonoBehaviour
{
	public enum LocomotionMode
	{
		Bounce = 0,
		Rolling = 1,
		Perpetual = 2,
		None = 3
	}

	public enum OneshotType
	{
		TakeDamage = 0,
		Attack = 1,
		Die = 2
	}

	public enum StepType
	{
		DefaultOnFoot = 0,
		Giant = 1,
		Fly = 2,
		SiegeRoll = 3,
		RacerRoll = 4,
		SquishyBounce = 5,
		ExploderRoll = 6,
		MonsterRider = 7,
		Slime = 8,
		FlyBig = 9,
		FlyWizzard = 10,
		Windboat = 11,
		Steamcastle = 12,
		Firestorm = 13
	}

	public enum DmgType
	{
		DefaultHumanoidOnFoot = 0,
		BigOrganic = 1,
		SmallOrganic = 2,
		Siege = 3
	}

	public enum DeathType
	{
		DefaultHumanoidOnFoot = 0,
		BigOrganic = 1,
		Siege = 2,
		Exploder = 3,
		Building = 4
	}

	public enum AttackType
	{
		DefaultSword = 0,
		MassiveBlunt = 1,
		FlyerSpit = 2,
		Flatbow = 3,
		Crossbow = 4,
		Catapult = 5,
		RacerBite = 6,
		HunterlingBite = 7,
		Ram = 8,
		Slime = 9,
		Healing = 10,
		Firespit = 11,
		Spear = 12,
		Wizard = 13,
		Spider = 14,
		Flail = 15,
		Windboat = 16,
		HeavyMechanical = 17
	}

	public LocomotionMode locomotionMode;

	public SimpleWalk walkSource;

	public float maxSpeed = 4f;

	public AudioSource stepSource;

	public AudioSource sfxSource;

	public AutoAttack attackTrigger;

	public Hp hp;

	public RVOController movementTrigger;

	public StepType step;

	[Range(0f, 1f)]
	public float stepVolume = 0.5f;

	public float stepPitchVariation = 0.1f;

	public AttackType attack;

	[Range(0f, 1f)]
	public float attackVolume = 0.5f;

	public float attackPitchVariation = 0.3f;

	public DeathType death;

	[Range(0f, 1f)]
	public float deathVolume = 0.5f;

	public float deathPitchVariation = 0.3f;

	public DmgType dmg;

	[Range(0f, 1f)]
	public float dmgVolume = 0.5f;

	public float dmgPitchVariation = 0.3f;

	private int rollPriority = 80;

	private int stepPriority = 110;

	private int damagePriority = 20;

	private int attackPriority = 10;

	private int deathPriority = 3;

	private AudioSet.ClipArray soundOnDmg;

	private AudioSet.ClipArray soundOnAttack;

	private AudioSet.ClipArray soundOnDeath;

	private AudioSet.ClipArray soundOnStep;

	private bool dead;

	private bool isBounceLocomotion => locomotionMode == LocomotionMode.Bounce;

	private bool isPerpetualLocomotion => locomotionMode == LocomotionMode.Perpetual;

	private bool isRollingLocomotion => locomotionMode == LocomotionMode.Rolling;

	private void Start()
	{
		if (locomotionMode == LocomotionMode.Bounce)
		{
			stepSource.priority = stepPriority;
		}
		else
		{
			stepSource.priority = rollPriority;
		}
		AudioSet audioContent = ThronefallAudioManager.Instance.audioContent;
		switch (step)
		{
		case StepType.DefaultOnFoot:
			soundOnStep = audioContent.DefaultOnFootStep;
			break;
		case StepType.Giant:
			soundOnStep = audioContent.GiantStep;
			break;
		case StepType.Fly:
			soundOnStep = audioContent.FlyingSmall;
			break;
		case StepType.FlyBig:
			soundOnStep = audioContent.FlyingBig;
			break;
		case StepType.SiegeRoll:
			soundOnStep = audioContent.SiegeRoll;
			break;
		case StepType.SquishyBounce:
			soundOnStep = audioContent.SquishyBounce;
			break;
		case StepType.RacerRoll:
			soundOnStep = audioContent.RacerRoll;
			break;
		case StepType.ExploderRoll:
			soundOnStep = audioContent.ExploderRoll;
			break;
		case StepType.MonsterRider:
			soundOnStep = audioContent.MonsterRiderGallop;
			break;
		case StepType.Slime:
			soundOnStep = audioContent.SlimeStep;
			break;
		case StepType.FlyWizzard:
			soundOnStep = audioContent.FlyingWizzard;
			break;
		case StepType.Windboat:
			soundOnStep = audioContent.WindboatFly;
			break;
		case StepType.Steamcastle:
			soundOnStep = audioContent.Steamcastle;
			break;
		case StepType.Firestorm:
			soundOnStep = audioContent.Firestorm;
			break;
		}
		switch (attack)
		{
		case AttackType.DefaultSword:
			soundOnAttack = audioContent.DefaultSwordAttack;
			break;
		case AttackType.Spear:
			soundOnAttack = audioContent.PlayerSpear;
			break;
		case AttackType.MassiveBlunt:
			soundOnAttack = audioContent.MassiveBluntAttack;
			break;
		case AttackType.FlyerSpit:
			soundOnAttack = audioContent.FlyerSpit;
			break;
		case AttackType.Crossbow:
			soundOnAttack = audioContent.CrossbowShot;
			break;
		case AttackType.Flatbow:
			soundOnAttack = audioContent.FlatbowShot;
			break;
		case AttackType.Catapult:
			soundOnAttack = audioContent.CatapultShot;
			break;
		case AttackType.RacerBite:
			soundOnAttack = audioContent.RacerBite;
			break;
		case AttackType.HunterlingBite:
			soundOnAttack = audioContent.HunterlingBite;
			break;
		case AttackType.Firespit:
			soundOnAttack = audioContent.FireSpit;
			break;
		case AttackType.Ram:
			soundOnAttack = audioContent.Ram;
			break;
		case AttackType.Slime:
			soundOnAttack = audioContent.SlimeSpit;
			break;
		case AttackType.Healing:
			soundOnAttack = audioContent.HealingProjectile;
			break;
		case AttackType.Wizard:
			soundOnAttack = audioContent.FlyingWizardCast;
			break;
		case AttackType.Spider:
			soundOnAttack = audioContent.SpiderBite;
			break;
		case AttackType.Flail:
			soundOnAttack = audioContent.FlailAttack;
			break;
		case AttackType.Windboat:
			soundOnAttack = audioContent.WindboatShot;
			break;
		case AttackType.HeavyMechanical:
			soundOnAttack = audioContent.WindboatShot;
			break;
		}
		switch (dmg)
		{
		case DmgType.DefaultHumanoidOnFoot:
			soundOnDmg = audioContent.DefaultHumanoidOnFootDamage;
			break;
		case DmgType.BigOrganic:
			soundOnDmg = audioContent.BigOrganicDamage;
			break;
		case DmgType.SmallOrganic:
			soundOnDmg = audioContent.SmallOrganicDamage;
			break;
		case DmgType.Siege:
			soundOnDmg = audioContent.SiegeDamage;
			break;
		}
		switch (death)
		{
		case DeathType.DefaultHumanoidOnFoot:
			soundOnDeath = audioContent.DefaultHumanoidOnFootDeath;
			break;
		case DeathType.BigOrganic:
			soundOnDeath = audioContent.BigOrganicDeath;
			break;
		case DeathType.Siege:
			soundOnDeath = audioContent.SiegeDeath;
			break;
		case DeathType.Exploder:
			soundOnDeath = audioContent.ExploderDeath;
			break;
		case DeathType.Building:
			soundOnDeath = audioContent.UnitBuildingCollpse;
			break;
		}
		if ((bool)hp)
		{
			hp.OnKillOrKnockout.AddListener(PlayDeath);
			hp.OnReceiveDamage.AddListener(PlayDMG);
			hp.OnRevive.AddListener(Revive);
		}
		if ((bool)attackTrigger)
		{
			attackTrigger.onAttackTriggered.AddListener(PlayAttack);
		}
		switch (locomotionMode)
		{
		case LocomotionMode.Rolling:
			stepSource.clip = soundOnStep.GetRandomClip();
			stepSource.volume = stepVolume;
			stepSource.loop = true;
			stepSource.pitch = Random.Range(1f - stepPitchVariation, 1f + stepPitchVariation);
			break;
		case LocomotionMode.Perpetual:
			stepSource.clip = soundOnStep.GetRandomClip();
			stepSource.volume = stepVolume;
			stepSource.loop = true;
			stepSource.pitch = Random.Range(1f - stepPitchVariation, 1f + stepPitchVariation);
			stepSource.Play();
			break;
		case LocomotionMode.Bounce:
			if ((bool)walkSource)
			{
				walkSource.onGroundContact.AddListener(PlayStep);
			}
			break;
		}
		if (isRollingLocomotion)
		{
			maxSpeed *= maxSpeed;
		}
	}

	private void Update()
	{
		if (dead)
		{
			return;
		}
		if (Time.timeScale < 0.1f)
		{
			stepSource.Pause();
		}
		else if (locomotionMode == LocomotionMode.Perpetual && !stepSource.isPlaying)
		{
			stepSource.Play();
		}
		else
		{
			if (locomotionMode != LocomotionMode.Rolling)
			{
				return;
			}
			if (movementTrigger.velocity.sqrMagnitude > 0.25f)
			{
				if (!stepSource.isPlaying)
				{
					stepSource.Play();
				}
				stepSource.volume = Mathf.Lerp(0f, stepVolume, movementTrigger.velocity.sqrMagnitude / maxSpeed);
			}
			else if (stepSource.isPlaying)
			{
				stepSource.Pause();
			}
		}
	}

	public void PlaySound(OneshotType soundType)
	{
		if (dead)
		{
			return;
		}
		switch (soundType)
		{
		case OneshotType.Attack:
			sfxSource.priority = attackPriority;
			sfxSource.pitch = Random.Range(1f - attackPitchVariation, 1f + attackPitchVariation);
			sfxSource.PlayOneShot(soundOnAttack.GetRandomClip(), attackVolume);
			break;
		case OneshotType.TakeDamage:
			if (!((double)hp.HpValue < 0.01))
			{
				sfxSource.priority = damagePriority;
				sfxSource.pitch = Random.Range(1f - dmgPitchVariation, 1f + dmgPitchVariation);
				sfxSource.PlayOneShot(soundOnDmg.GetRandomClip(), dmgVolume);
			}
			break;
		case OneshotType.Die:
			sfxSource.priority = deathPriority;
			sfxSource.pitch = Random.Range(1f - deathPitchVariation, 1f + deathPitchVariation);
			sfxSource.PlayOneShot(soundOnDeath.GetRandomClip(), deathVolume);
			break;
		}
	}

	private void PlayStep()
	{
		stepSource.priority = stepPriority;
		stepSource.pitch = Random.Range(1f - stepPitchVariation, 1f + stepPitchVariation);
		stepSource.PlayOneShot(soundOnStep.GetRandomClip(), stepVolume);
	}

	private void PlayAttack()
	{
		PlaySound(OneshotType.Attack);
	}

	private void PlayDMG(bool causedByPlayer)
	{
		PlaySound(OneshotType.TakeDamage);
	}

	private void PlayDeath()
	{
		PlaySound(OneshotType.Die);
		dead = true;
		if (!hp.getsKnockedOutInsteadOfDying)
		{
			sfxSource.transform.parent = null;
			Object.Destroy(sfxSource.gameObject, 3f);
		}
	}

	private void Revive()
	{
		dead = false;
	}
}
