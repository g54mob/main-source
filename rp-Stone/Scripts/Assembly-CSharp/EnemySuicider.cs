using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySuicider : MonoBehaviour
{
	public int explodeDistance = 2;

	public bool explodeIfKilled = true;

	public bool missOnEvasion = true;

	public Decoration explosionPrefab;

	public IntPosition explosionOffset;

	public string engagingLoopSfx;

	public string explosionSfx;

	public string movementSfx;

	public int damageDelay = 4;

	public float baseDamage = 10f;

	public float damagePerLevel;

	public int damageRange = 8;

	public float camShakeAmount = 2f;

	public float camShakeDuration = 0.3f;

	private Enemy myCharacter;

	private bool isExploding;

	private Sfx fuseSfx;

	private int lastX;

	private void HandleUpdateTic(Character c)
	{
		if (!myCharacter.Alive)
		{
			return;
		}
		if (isExploding)
		{
			if (--damageDelay <= 0)
			{
				ExplosionDamage();
				myCharacter.Die(Character.DeathReason.Custom);
			}
		}
		else if (myCharacter.PositionX - GameStates.Singleton.hero.PositionX <= explodeDistance)
		{
			BeginExplosion();
		}
		else if (lastX != myCharacter.PositionX && myCharacter.CurrentState != Enemy.State.Sleeping)
		{
			lastX = myCharacter.PositionX;
			SfxController.singleton.Play(movementSfx);
		}
	}

	private void BeginExplosion()
	{
		isExploding = true;
		myCharacter.ticsPerMove = 9999;
		myCharacter.Money = 0;
		if (fuseSfx != null)
		{
			fuseSfx.Stop();
		}
		SpawnVFX(explosionPrefab);
		SfxController.singleton.Play(explosionSfx);
		if (camShakeAmount > 0f)
		{
			CameraShake.singleton.ShakeCamera(camShakeAmount, camShakeDuration);
		}
	}

	protected void SpawnVFX(Character prefab)
	{
		if (prefab == null)
		{
			Utils.LogError("Prefab is null. Cannot spawn.", base.gameObject);
			return;
		}
		Character character = Object.Instantiate(prefab);
		character.PositionX = myCharacter.PositionX + explosionOffset.x;
		character.PositionY = myCharacter.PositionY + explosionOffset.y;
		character.PositionZ = myCharacter.PositionZ + explosionOffset.z;
		AsciiAnimation component = character.GetComponent<AsciiAnimation>();
		if (component != null)
		{
			component.Stop();
			component.Play();
		}
		GameStates.Singleton.level.AddCharacter(character);
		character.SetLevel(myCharacter.level);
	}

	private void ExplosionDamage()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.PositionX < myCharacter.PositionX - damageRange || hero.PositionX > myCharacter.PositionX + damageRange + myCharacter.CollisionWidth)
		{
			return;
		}
		if (missOnEvasion && hero.statModController != null)
		{
			float num = hero.statModController.ModChanceToEvade(hero.baseChanceToEvade);
			if (num > 0f && Random.Range(0f, 100f) <= num)
			{
				hero.ShowFloatingText(Te.xt("MISSED"));
				return;
			}
		}
		Damage damage = new Damage();
		damage.amount = Mathf.FloorToInt(baseDamage + damagePerLevel * (float)myCharacter.level);
		damage.isCritical = true;
		damage.type = Damage.Type.Melee;
		damage.Owner = myCharacter;
		hero.InflictDamage(damage);
	}

	private void HandleDamage(Character c, Damage dmg)
	{
		if (c == myCharacter)
		{
			if (isExploding)
			{
				dmg.amount = 0;
			}
			else if (explodeIfKilled && dmg.amount >= Mathf.CeilToInt(myCharacter.Armor) + myCharacter.Hitpoints)
			{
				BeginExplosion();
				ExplosionDamage();
			}
		}
	}

	private void HandleStateChanged(Enemy e, Enemy.State newState, Enemy.State prevState)
	{
		if (newState > Enemy.State.Sleeping && prevState == Enemy.State.Sleeping && fuseSfx == null)
		{
			fuseSfx = SfxController.singleton.Play(engagingLoopSfx);
		}
	}

	private void Awake()
	{
		myCharacter = GetComponent<Enemy>();
		if (!string.IsNullOrEmpty(engagingLoopSfx))
		{
			SfxController.singleton.Preload(engagingLoopSfx);
		}
		myCharacter.OnEnemyStateChange += HandleStateChanged;
		myCharacter.OnUpdateTic += HandleUpdateTic;
		Character.OnCharacterGoingToTakeDamage += HandleDamage;
	}

	private void OnDestroy()
	{
		myCharacter.OnEnemyStateChange -= HandleStateChanged;
		myCharacter.OnUpdateTic -= HandleUpdateTic;
		Character.OnCharacterGoingToTakeDamage -= HandleDamage;
	}
}
