using System.Linq;
using UnityEngine;

public class E4_B_Coalmancer : E4_B_Servant
{
	[Header("Coalmancer Fields")]
	[SerializeField]
	[Tooltip("How many seconds worth of coal are sucked per second")]
	private float coalSuckAmount = 5f;

	private int suckDirectionSign = 1;

	[field: SerializeField]
	public float SuckDuration { get; private set; }

	private new void Awake()
	{
		base.Awake();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E4_B_Coalmancer_Idle(sm, this),
			new E4_B_Coalmancer_Suck(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Start()
	{
		base.Start();
		base.TargetUnit = Train.Instance.Modules.FirstOrDefault((Module m) => m is ModuleFurnace);
	}

	public override void Shoot()
	{
		if (!(shotTimer > 0f) && !base.HealthComponent.isEMPd)
		{
			shotTimer = base.TimeBetweenShots;
			SuckCoal();
		}
	}

	private void SuckCoal()
	{
		float amount = (float)suckDirectionSign * coalSuckAmount;
		Train.Instance.DrainCoal(amount, this);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		if (IsHacked)
		{
			suckDirectionSign = -1;
		}
		else
		{
			suckDirectionSign = 1;
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}
}
