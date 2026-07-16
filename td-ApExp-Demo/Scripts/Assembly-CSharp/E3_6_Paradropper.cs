using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E3_6_Paradropper : EnemyBase
{
	[Header("Paradropper Fields")]
	[SerializeField]
	private List<SpriteRenderer> planeParts;

	[SerializeField]
	private float yVariation = 0.3f;

	[SerializeField]
	private float xDistanceFromTrain;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private float dropProximityToModule;

	[SerializeField]
	[Range(0f, 1f)]
	private float moduleDropChance = 0.7f;

	[SerializeField]
	private float waitTime;

	[SerializeField]
	private float flyBackSpeed = 0.6f;

	[SerializeField]
	private float flyForwardSpeed = 0.25f;

	private Vector2 targetPos;

	private Color normalColor = new Color(1f, 1f, 1f, 1f);

	private Color transparentColor = new Color(1f, 1f, 1f, 0f);

	public float DropProximityToModule => dropProximityToModule;

	public float ModuleDropChance => moduleDropChance;

	public float WaitTime => waitTime;

	public Vector3 TargetPos => targetPos;

	private new void Awake()
	{
		base.Awake();
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E3_6_Enter(sm, this),
			new E3_6_Drop(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
		}
	}

	public override void Move()
	{
		base.transform.position += base.transform.right * flyForwardSpeed * Time.deltaTime;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(base.transform.position.y - yVariation, base.transform.position.y + yVariation, t) + targetOffsetY;
		float t2 = Time.deltaTime * flyForwardSpeed;
		Vector3 position = base.transform.position;
		position.y = Mathf.Lerp(position.y, b, t2);
		base.transform.position = position;
		IsInPosition = position.x > targetPos.x;
	}

	public void MoveBack()
	{
		base.transform.position -= base.transform.right * flyBackSpeed * Time.deltaTime;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(base.transform.position.y - yVariation, base.transform.position.y + yVariation, t) + targetOffsetY;
		float t2 = Time.deltaTime * flyBackSpeed;
		Vector3 position = base.transform.position;
		position.y = Mathf.Lerp(position.y, b, t2);
		base.transform.position = position;
		IsInPosition = position.x < targetPos.x;
	}

	public void SetStartingPos()
	{
		float num = Random.Range(minY, maxY);
		float num2 = ((Random.Range(0f, 1f) > 0.5f) ? 1 : (-1));
		targetPos = new Vector2(Train.Instance.GetLastWagonLeftPosX() - xDistanceFromTrain, num * num2);
	}

	public void SetForwardPos()
	{
		float num = 0f;
		num = ((Random.Range(0, 2) != 1) ? maxY : minY);
		_ = targetPos;
		targetPos = new Vector2(Train.Instance.GetFirstWagonRightPosX() + xDistanceFromTrain, num);
	}

	public void SetPlaneFlyOver()
	{
		ignoreProjectiles = true;
		base.transform.localScale = Vector3.one * 1.5f;
		base.transform.position = new Vector3(3f, Random.Range(0f - maxY, maxY), 0f);
		planeParts.ForEach(delegate(SpriteRenderer x)
		{
			x.color = transparentColor;
		});
		SetStartingPos();
	}

	public void SetPlaneFlyNormal()
	{
		ignoreProjectiles = false;
		base.transform.localScale = Vector3.one;
		planeParts.ForEach(delegate(SpriteRenderer x)
		{
			x.color = normalColor;
		});
		SetForwardPos();
	}

	public E3_6_Chicken SpawnChicken(Unit target)
	{
		if (ignoreProjectiles || Random.Range(0f, 1f) > moduleDropChance)
		{
			return null;
		}
		EnemyManager instance = EnemyManager.Instance;
		GameObject enemyPrefab = bullet;
		Vector3? spawnPos = muzzleTF.position;
		E3_6_Chicken component = instance.SpawnEnemy(enemyPrefab, null, spawnPos).GetComponent<E3_6_Chicken>();
		if ((object)component != null)
		{
			Debug.LogWarning("Chicken spawned");
			return component;
		}
		return null;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}

	public override void Despawn()
	{
		base.Despawn();
	}

	internal Module[] GetDropTargets()
	{
		if (Train.Instance?.Modules == null)
		{
			return new Module[0];
		}
		Module[] array = Train.Instance.Modules.Where((Module m) => m != null && !(m is ModuleCannon)).ToArray();
		Module[] array2 = new Module[array.Length];
		for (int num = 0; num < array.Length; num++)
		{
			array2[num] = array[^(num + 1)];
		}
		return array2;
	}
}
