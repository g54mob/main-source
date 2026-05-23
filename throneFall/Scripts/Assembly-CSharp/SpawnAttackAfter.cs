using Shapes;
using UnityEngine;

public class SpawnAttackAfter : MonoBehaviour
{
	[SerializeField]
	private Weapon spwanAttackOnDeath;

	[SerializeField]
	private float delay;

	[SerializeField]
	private Disc disc;

	public ThronefallAudioManager.AudioOneShot sound;

	public bool mute;

	[SerializeField]
	private bool isPlayerAttack;

	public float damageMultiplyer = 1f;

	private float startRadius;

	private float startDelay;

	public Weapon SpwanAttackOnDeath
	{
		get
		{
			return spwanAttackOnDeath;
		}
		set
		{
			spwanAttackOnDeath = value;
		}
	}

	private TaggedObject taggedObject { get; set; }

	private void Start()
	{
		startRadius = disc.Radius;
		startDelay = delay;
		if (!mute)
		{
			ThronefallAudioManager.WorldSpaceOneShot(sound, base.transform.position);
		}
		if (isPlayerAttack)
		{
			damageMultiplyer *= PlayerUpgradeManager.instance.PlayerDamageMultiplyer;
		}
	}

	private void Update()
	{
		delay -= Time.deltaTime;
		if (delay <= 0f)
		{
			if ((bool)spwanAttackOnDeath)
			{
				spwanAttackOnDeath.Attack(base.transform.position, null, Vector3.zero, taggedObject, damageMultiplyer);
			}
			Object.Destroy(base.gameObject);
		}
		else
		{
			disc.Radius = Mathf.Lerp(startRadius, 0f, delay / startDelay);
		}
	}
}
