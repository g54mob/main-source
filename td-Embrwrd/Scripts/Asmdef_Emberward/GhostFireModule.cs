using UnityEngine;

public class GhostFireModule : MonoBehaviour
{
	[SerializeField]
	private Obj_FireSource fireSource;

	[SerializeField]
	private ParticleSystem particle_EffectTrigger;

	[SerializeField]
	private float effectTriggerInterval;

	[SerializeField]
	private float effectTriggerTimer;

	[SerializeField]
	private float damagePercentPerTick;

	private bool isInitialized;

	private bool IsUsingGhostFire;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}

	private void Start()
	{
	}

	private void Initialize()
	{
	}

	private void Update()
	{
	}

	private void TriggerEffect()
	{
	}
}
