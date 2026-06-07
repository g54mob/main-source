using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : Controller
{
	private const float UPDATE_TARGET_TIME = 0.5f;

	private PerceptionAI perceptionAI;

	private List<Enemy> enemies;

	private bool keepTarget;

	private Tower controlledTower;

	[SerializeField]
	private List<TowerTargetProvider> targetProviders;

	private TowerTargetProvider firstTargetProvider;

	private TowerTargetProvider secondTargetProvider;

	private TowerTargetProvider fallbackTargetProvider;

	private Coroutine updateTargetCoroutine;

	private List<Enemy> auxTargetsList;

	public PerceptionAI PerceptionAI
	{
		get
		{
			return perceptionAI;
		}
		private set
		{
			perceptionAI = value;
		}
	}

	public bool KeepTarget
	{
		get
		{
			return keepTarget;
		}
		set
		{
			keepTarget = value;
		}
	}

	public List<TowerTargetProvider> TargetProviders => targetProviders;

	public TowerTargetProvider FirstTargetProvider
	{
		get
		{
			return firstTargetProvider;
		}
		set
		{
			firstTargetProvider = value;
		}
	}

	public TowerTargetProvider SecondTargetProvider
	{
		get
		{
			return secondTargetProvider;
		}
		set
		{
			secondTargetProvider = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		PerceptionAI = GetComponent<PerceptionAI>();
		enemies = new List<Enemy>();
		auxTargetsList = new List<Enemy>();
		fallbackTargetProvider = TargetProviders[0];
		FirstTargetProvider = fallbackTargetProvider;
		SecondTargetProvider = fallbackTargetProvider;
	}

	protected override void Start()
	{
		base.Start();
		PerceptionAI.onEnterPerception += OnEnterPerception;
		PerceptionAI.onExitPerception += OnExitPerception;
		this.StartCoroutineCheckingVar(UpdateTargetCoroutine(), ref updateTargetCoroutine);
	}

	public override void Possess(Character newCharacter)
	{
		base.Possess(newCharacter);
		controlledTower = newCharacter as Tower;
		KeepTarget = controlledTower.CombatComponent.StartWithKeepTarget;
		if (controlledTower.DefaultTargetProvider != null)
		{
			FirstTargetProvider = controlledTower.DefaultTargetProvider;
		}
	}

	private IEnumerator UpdateTargetCoroutine()
	{
		WaitForSeconds wfs = new WaitForSeconds(0.5f);
		while (true)
		{
			if (!controlledTower.Target || !KeepTarget)
			{
				UpdateTarget();
			}
			yield return wfs;
		}
	}

	private void UpdateTarget()
	{
		auxTargetsList.Clear();
		if (FirstTargetProvider == SecondTargetProvider)
		{
			auxTargetsList = FirstTargetProvider?.GetTarget(controlledTower, enemies);
		}
		else
		{
			auxTargetsList = FirstTargetProvider.GetTarget(controlledTower, enemies);
			if (auxTargetsList != null && auxTargetsList.Count > 1)
			{
				auxTargetsList = SecondTargetProvider?.GetTarget(controlledTower, auxTargetsList);
			}
		}
		if (auxTargetsList == null || auxTargetsList.Count == 0)
		{
			auxTargetsList = fallbackTargetProvider?.GetTarget(controlledTower, enemies);
		}
		else if (auxTargetsList.Count > 1)
		{
			auxTargetsList = fallbackTargetProvider?.GetTarget(controlledTower, new List<Enemy>(auxTargetsList));
		}
		if (auxTargetsList != null && auxTargetsList.Count > 0)
		{
			controlledTower.Target = auxTargetsList[0];
		}
	}

	public void SetRange(float radius)
	{
		PerceptionAI.ProximityRadius = radius;
	}

	private void OnEnterPerception(GameObject go, PerceptionAI.ESense sense)
	{
		Enemy component = go.GetComponent<Enemy>();
		if ((bool)component)
		{
			enemies.AddUnique(component);
			component.onDie += OnEnemyDies;
		}
	}

	private void OnExitPerception(GameObject go, PerceptionAI.ESense sense)
	{
		Enemy component = go.GetComponent<Enemy>();
		if ((bool)component)
		{
			enemies.Remove(component);
			component.onDie -= OnEnemyDies;
			if (component == controlledTower.Target)
			{
				controlledTower.Target = null;
				UpdateTarget();
			}
		}
	}

	private void OnEnemyDies(Enemy enemy)
	{
		enemy.onDie -= OnEnemyDies;
		enemies.Remove(enemy);
		if (controlledTower.Target == enemy)
		{
			controlledTower.Target = null;
			UpdateTarget();
		}
	}
}
