using AudioSystem;
using UnityEngine;

public class EnemyCentipede : EnemyBase
{
	[HideInInspector]
	public CentipedeController controller;

	public bool isReadyToOpenAndArm;

	public CentipedeArmament arma;

	public Animator plateAnim;

	public Animator rustAnim;

	public BoxCollider2D bc2d;

	[SerializeField]
	private SoundData plateOpenSound;

	private new void Awake()
	{
		base.Awake();
		bc2d = GetComponent<BoxCollider2D>();
		if ((bool)base.transform.Find("Plate"))
		{
			plateAnim = base.transform.Find("Plate").GetComponent<Animator>();
		}
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[6]
		{
			new E1_B_Idle(sm, this),
			new E1_B_OpenAndArm(sm, this),
			new E1_B_AimAndFire(sm, this),
			new E1_B_DisarmAndClose(sm, this),
			new E1_B_Destroyed(sm, this),
			new E1_B_EMP(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		controller.OnEnemyDeath(this);
		Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation).GetComponent<Explosion>().Initialize(this, explosionScale, 0.25f);
		Object.Destroy(arma.gameObject);
		sm.ForceState("Destroyed");
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		arma.OnSegmentFactionChanged();
	}

	public void PlayOpenPlateSound()
	{
		soundBuilder.Play(plateOpenSound);
	}
}
