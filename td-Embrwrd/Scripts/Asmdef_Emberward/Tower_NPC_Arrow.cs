using UnityEngine;

[SelectionBase]
public class Tower_NPC_Arrow : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private float shootInterval;

	[SerializeField]
	private GameObject bulletPrefab;

	[SerializeField]
	private Transform shootPosition;

	[SerializeField]
	private ParticleSystem particle_Burn;

	[SerializeField]
	private bool doTalk;

	[SerializeField]
	private bool isAttackable;

	private Vector3 headModelForward;

	private float shootTimer;

	private AMonsterBase currentTarget;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnBattleStart()
	{
	}

	private void ShowDialog(float delay, string locKey)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	protected void Shoot()
	{
	}

	public void ToggleIsAttackable(bool isAttackable)
	{
	}

	public void ToggleBurnEffect(bool isOn)
	{
	}

	public void AttackedEffect(float duration, float strengthMultiplier, float delay)
	{
	}

	public void PlayDestroyTowerAnim()
	{
	}
}
