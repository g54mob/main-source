using System;
using AudioSystem;
using UnityEngine;

public class E2_7Chainer : EnemyBase
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData chainDangleSound;

	[SerializeField]
	private SoundData chainLatchSound;

	[SerializeField]
	private SoundData fireSound;

	[Header("Movement Fields")]
	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform headTF;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[Header("Chainer Fields")]
	[SerializeField]
	public float slowPercent = 25f;

	[SerializeField]
	private float attachRange = 0.1f;

	[SerializeField]
	private float maxChainLength = 0.2f;

	[SerializeField]
	private float leaveSpeed = 20f;

	[SerializeField]
	private Transform hookTF;

	[SerializeField]
	private Transform idleHookAnchor;

	[SerializeField]
	private Transform leftAnchor;

	[SerializeField]
	private Transform rightAnchor;

	[SerializeField]
	private ParticleSystem thrusterFirePs;

	[SerializeField]
	private GameObject handGo;

	private float retryTimer;

	[NonSerialized]
	public Transform OriginalTarget;

	private ChainController trainChain;

	private Vector3 aimTargetPos;

	public Transform TargetUnitTf;

	public bool IsThrowing;

	public bool IsAttached;

	public bool slowApplied;

	public bool trainChained;

	public bool enemyChained;

	private new float posSign => ((float)enemyPos != -1f) ? 1 : (-1);

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[5]
		{
			new E2_7Idle(sm, this),
			new E2_7Throwing(sm, this),
			new E2_7Attach(sm, this),
			new E2_7Leave(sm, this),
			new E2_7EMP(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		soundBuilder.Play(chainDangleSound);
	}

	private void AudioController_OnInitialized()
	{
	}

	private new void Start()
	{
		base.Start();
		leftWheelTrail.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		rightWheelTrail.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		idleHookAnchor.localScale = new Vector3(1f, (!(base.transform.position.y > 0f)) ? 1 : (-1), 1f);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			if (!IsChained)
			{
				base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
			}
		}
	}

	protected override void SetRelativeSpeedMult()
	{
		relativeSpeedMult = 1f;
	}

	public override void Move()
	{
		if (!IsChained)
		{
			Vector3 vector = ((!(TargetUnitTf == null)) ? TargetUnitTf.transform.position : Vector3.zero);
			float num = (float)enemyPos;
			float num2 = Train.Instance.Wagons[0].transform.position.y * num;
			float t = Mathf.PerlinNoise(Time.time, noiseSeed);
			float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
			float b = (Mathf.Lerp(minY + num2, maxY + num2, t) + targetOffsetY) * num;
			float b2 = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
			Vector3 position = base.transform.position;
			float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
			position.x = Mathf.Lerp(position.x, b2, t3);
			float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
			position.y = Mathf.Lerp(position.y, b, t4);
			if ((num == 1f && position.y < minY) || (num == -1f && position.y > minY))
			{
				position.y = minY;
			}
			if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
			{
				base.transform.position = position + GetPositionModifiers();
			}
			else
			{
				base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
			}
			base.Move();
			IsInPosition = position.x < vector.x + xVariation && position.x > vector.x - xVariation && position.y * num > minY && position.y * num < maxY;
		}
	}

	public void MoveBack()
	{
		if (IsChained)
		{
			return;
		}
		Vector3 vector = ((TargetUnitTf != null) ? TargetUnitTf.transform.position : Vector3.zero);
		float num = (float)enemyPos;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float y = (Mathf.Lerp(minY + vector.y, maxY + vector.y, t) + targetOffsetY) * num;
		float x = Mathf.Lerp(vector.x - xVariation * 2f, vector.x - xVariation, t2);
		Vector3 vector2 = new Vector3(x, y, 0f);
		Vector3 vector3 = GetNeighborAvoidanceVector();
		Vector3 vector4 = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed;
		float t4 = Time.deltaTime * base.MoveSpeed;
		vector4.x = Mathf.Lerp(vector4.x, vector2.x, t3);
		vector4.y = Mathf.Lerp(vector4.y, vector2.y, t4);
		if (Mathf.Abs(vector4.y) < minY)
		{
			vector4.y = minY * num;
		}
		Vector3 vector5 = vector4 - vector;
		if (vector5.magnitude > attachRange)
		{
			vector5 = vector5.normalized * attachRange;
			vector5.x = 0f - Mathf.Abs(vector5.x);
			if (num > 0f && vector5.y < 0f)
			{
				vector5.y = Mathf.Abs(vector5.y);
			}
			else if (num < 0f && vector5.y > 0f)
			{
				vector5.y = 0f - Mathf.Abs(vector5.y);
			}
			vector4 = vector + vector5;
		}
		base.transform.position = vector4 + vector3;
		IsInPosition = vector4.x < vector.x + xVariation && vector4.x > vector.x - xVariation && vector4.y * num > minY && vector4.y * num < maxY;
	}

	public void MoveAway()
	{
		if (!IsChained)
		{
			float num = (float)enemyPos;
			Vector3 vector = GetNeighborAvoidanceVector();
			Vector3 position = base.transform.position;
			float t = Time.deltaTime * base.MoveSpeed;
			position.x = Mathf.Lerp(position.x, 0f - leaveSpeed, t);
			if (Mathf.Abs(position.y) < minY)
			{
				position.y = minY * num;
			}
			base.transform.position = position + vector;
		}
	}

	public override void Aim()
	{
		Vector3 upwards = aimTargetPos - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		headTF.transform.rotation = Quaternion.RotateTowards(headTF.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		IsThrowing = true;
		hookTF.gameObject.SetActive(value: false);
		Transform transform = ((base.transform.position.y > 0f) ? rightAnchor : leftAnchor);
		GameObject gameObject = UnityEngine.Object.Instantiate(bullet, transform.position, transform.rotation, transform);
		trainChain = gameObject.GetComponent<ChainController>();
		trainChain.owner = this;
		trainChain.ExtensionState = ExtensionState.Expanding;
		trainChain.SetTarget(TargetUnitTf);
		trainChain.OnDestroyed += TrainChain_OnDestroyed1;
		soundBuilder.Play(shootSound);
		soundBuilder.FindAndStop(chainDangleSound, stopAll: true);
	}

	private void TrainChain_OnDestroyed1(ExtendableLinksComponent obj)
	{
		trainChain = null;
		soundBuilder.FindAndStop(chainDangleSound, stopAll: true);
		sm.ForceState("Leave");
		if (slowApplied)
		{
			slowApplied = false;
			IsAttached = false;
			Train.Instance.AddSlowDebuff(0f - slowPercent);
		}
		handGo.SetActive(value: false);
	}

	public bool IsInRange()
	{
		if (TargetUnitTf != null)
		{
			return (TargetUnitTf.transform.position - base.transform.position).magnitude <= attachRange;
		}
		return false;
	}

	public void AttachToTrain()
	{
		trainChain.ExtensionState = ExtensionState.Expanding;
		soundBuilder.Play(chainLatchSound);
		thrusterFirePs.Play(withChildren: true);
		handGo.SetActive(value: true);
		soundBuilder.FindAndStop(chainDangleSound, stopAll: true);
		soundBuilder.Play(fireSound);
		if (IsHacked)
		{
			trainChain.TargetTf.SetParent(trainChain.LastLink);
			if (trainChain.TargetTf.TryGetComponent<EnemyBase>(out var component))
			{
				component.OnChained();
			}
			enemyChained = true;
		}
		else
		{
			trainChained = true;
		}
	}

	public void DetachFromTrain()
	{
		if ((bool)trainChain)
		{
			trainChain.DestroyChain();
		}
		soundBuilder.FindAndStop(chainLatchSound);
		thrusterFirePs.Stop(withChildren: true);
		handGo.SetActive(value: false);
		if (slowApplied)
		{
			slowApplied = false;
			IsAttached = false;
			Train.Instance.AddSlowDebuff(0f - slowPercent);
		}
	}

	public bool IdleTick()
	{
		return (retryTimer -= Time.deltaTime) <= 0f;
	}

	public override void Target()
	{
	}

	public void SetTarget(Transform target)
	{
		TargetUnitTf = target;
	}

	public void SetOriginalTarget(Transform target)
	{
		SetTarget(target);
		OriginalTarget = target;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (leftWheelTrail.TryGetComponent<TireTrailController>(out var component))
		{
			component.Detach();
		}
		if (rightWheelTrail.TryGetComponent<TireTrailController>(out var component2))
		{
			component2.Detach();
		}
		if (slowApplied)
		{
			slowApplied = false;
			IsAttached = false;
			Train.Instance.AddSlowDebuff(0f - slowPercent);
		}
		base.OnDeath(info);
	}

	public override void EMP(float duration)
	{
		base.EMP(duration);
		thrusterFirePs.Stop();
	}

	public override void OnEMPEnd()
	{
		base.OnEMPEnd();
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		if (IsHacked)
		{
			if (trainChained)
			{
				DetachFromTrain();
				return;
			}
			SetTarget(UnitHelper.GetClosestEnemyOnSameSide(this).transform);
			if (TargetUnitTf == null)
			{
				sm.ForceState("Leave");
			}
			else
			{
				sm.ForceState("Idle");
			}
		}
		else if (!enemyChained && !trainChained)
		{
			SetTarget(OriginalTarget);
		}
	}

	public override void OnChained()
	{
		DetachFromTrain();
		base.OnChained();
	}
}
