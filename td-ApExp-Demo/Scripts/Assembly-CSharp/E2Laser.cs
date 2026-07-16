using System;
using System.Collections.Generic;
using UnityEngine;

public class E2Laser : EnemyBase
{
	[SerializeField]
	private float minLaserDistance;

	[SerializeField]
	private float maxLaserDistance;

	private LineRenderer lr;

	[SerializeField]
	private float anglePerSec = 15f;

	[SerializeField]
	private Transform turretTF;

	[NonSerialized]
	[HideInInspector]
	public Unit targetUnit2;

	private Quaternion targetRotation;

	private float rotationTime;

	[NonSerialized]
	[HideInInspector]
	public bool isFiringComplete;

	[NonSerialized]
	[HideInInspector]
	public List<Unit> unitsHitList;

	[field: Header("Laser Settings")]
	[field: SerializeField]
	public float TimeToCharge { get; private set; }

	public bool RotateTarget1To2 { get; private set; }

	protected new void Awake()
	{
		base.Awake();
		lr = base.transform.Find("Laser").GetComponent<LineRenderer>();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[5]
		{
			new E2Idle(sm, this),
			new BMoveState(sm, this),
			new E2LaserCharge(sm, this),
			new E2LaserShoot(sm, this),
			new BEMPState(sm, this)
		});
		unitsHitList = new List<Unit>();
	}

	private new void Start()
	{
		base.Start();
		PS = base.gameObject.GetComponentInChildren<ParticleSystem>();
	}

	private new void Update()
	{
		base.Update();
		if (base.TargetUnit == null)
		{
			Target();
		}
	}

	public void RandomizeRotateDirection()
	{
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			RotateTarget1To2 = true;
		}
		else
		{
			RotateTarget1To2 = false;
		}
	}

	public void FlipRotateDirection()
	{
		RotateTarget1To2 = !RotateTarget1To2;
	}

	public override void Target()
	{
		if (base.IsEnemy)
		{
			(Unit, Unit) twoModulesByDstApart = UnitHelper.GetTwoModulesByDstApart(3f);
			(base.TargetUnit, targetUnit2) = twoModulesByDstApart;
		}
		else
		{
			Unit randomLiveEnemyUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			Unit randomLiveEnemyUnit2 = UnitHelper.GetRandomLiveEnemyUnit(this);
			Unit unit = (base.TargetUnit = randomLiveEnemyUnit);
			targetUnit2 = randomLiveEnemyUnit2;
		}
		if (!(base.TargetUnit == null))
		{
			Vector3 normalized = ((RotateTarget1To2 ? base.TargetUnit.transform.position : targetUnit2.transform.position) - turretTF.position).normalized;
			targetRotation = Quaternion.LookRotation(Vector3.forward, normalized);
			Vector3 normalized2 = ((RotateTarget1To2 ? targetUnit2.transform.position : base.TargetUnit.transform.position) - turretTF.position).normalized;
			Quaternion b = Quaternion.LookRotation(Vector3.forward, normalized2);
			float num = Quaternion.Angle(targetRotation, b);
			rotationTime = num / anglePerSec;
			base.Anim.SetFloat("ShootMult", 1f / rotationTime);
		}
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			float num = Quaternion.Angle(turretTF.rotation, targetRotation);
			float num2 = Mathf.Min(1f, anglePerSec * Time.deltaTime / num);
			turretTF.rotation = Quaternion.Lerp(turretTF.rotation, targetRotation, num2);
			if (num2 >= 1f)
			{
				isFiringComplete = true;
			}
		}
	}

	public override void Shoot()
	{
		RaycastHit2D[] array = Physics2D.RaycastAll(turretTF.position, turretTF.up, maxLaserDistance * 2f, LayerMask.GetMask("Unit", "Enemy"));
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit2D raycastHit2D = array[i];
			if (raycastHit2D.collider == null)
			{
				FailLr();
				continue;
			}
			if (!raycastHit2D.collider.TryGetComponent<Unit>(out var component))
			{
				component = raycastHit2D.collider.GetComponentInChildren<Unit>();
			}
			if (component == null)
			{
				FailLr();
				continue;
			}
			if (component.IsEnemy == base.IsEnemy)
			{
				FailLr();
				continue;
			}
			SetLr(turretTF.position + turretTF.up * minLaserDistance, turretTF.position + turretTF.up * raycastHit2D.distance);
			if (!unitsHitList.Contains(component))
			{
				HealthChangeInfo info = new HealthChangeInfo(this, component.HealthComponent, 0f - damage);
				component.HealthComponent.ChangeHealthWithInfo(info);
				unitsHitList.Add(component);
			}
		}
	}

	private void FailLr()
	{
		SetLr(turretTF.position + turretTF.up * minLaserDistance, turretTF.position + turretTF.up * maxLaserDistance);
	}

	public void SetLr(Vector2 startPos, Vector2 endPos)
	{
		lr.SetPosition(0, startPos);
		lr.SetPosition(1, endPos);
	}

	public override void EMP(float duration)
	{
		base.EMP(duration);
		PS.Stop();
	}
}
