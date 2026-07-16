using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E2_3MedicSquad : EnemyBase
{
	[Header("Squad Fields")]
	[SerializeField]
	public List<E2_3Medic> Medics;

	[SerializeField]
	private float chargeTime;

	[SerializeField]
	private float distanceFromTrain;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[NonSerialized]
	public float chargingTimer;

	private new float posSign
	{
		get
		{
			if (!(base.transform.position.y >= 0f))
			{
				return -1f;
			}
			return 1f;
		}
	}

	public float ChargeTime => chargeTime;

	public bool AllDead => Medics.All((E2_3Medic m) => m.HealthComponent.IsDead || m.IsHacked);

	public event Action<HealthChangeInfo> OnAllDied;

	private new void Awake()
	{
	}

	private new void Start()
	{
		Target();
		SetMedicPositions(base.TargetUnit.transform.position + new Vector3(0f, distanceFromTrain * posSign, 0f));
		int medicSquadIterator = EnemyManager.Instance.GetMedicSquadIterator();
		foreach (E2_3Medic medic in Medics)
		{
			medic.transform.SetParent(EnemyManager.Instance.transform);
			medic.SetSquadColors(medicSquadIterator);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			relativeSpeedMult = Train.Instance.TrainSpeedNormalized;
			if (relativeSpeedMult < 1f && !IsInPosition)
			{
				relativeSpeedMult = 1f;
			}
		}
	}

	protected new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
			Move();
		}
	}

	public override void Move()
	{
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : Vector3.zero);
		vector += new Vector3(0f, distanceFromTrain * posSign, 0f);
		float num = Train.Instance.Wagons[0].transform.position.y * posSign;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed) / 10f;
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed) / 10f;
		float b = (Mathf.Lerp(minY + num, maxY + num, t) + targetOffsetY) * posSign;
		float b2 = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		float t3 = (IsInPosition ? 0f : (Time.deltaTime * base.MoveSpeed * relativeSpeedMult));
		vector.x = Mathf.Lerp(vector.x, b2, t3);
		float t4 = (IsInPosition ? 0f : (Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult));
		vector.y = Mathf.Lerp(vector.y, b, t4);
		if ((posSign == 1f && vector.y < minY) || (posSign == -1f && vector.y > minY))
		{
			vector.y = minY;
		}
		SetMedicPositions(vector + new Vector3(0f, 0.2f, 0f));
	}

	private void SetMedicPositions(Vector3 targetCenter)
	{
		if (targetCenter.y <= 0f)
		{
			Medics[1].targetPos = targetCenter + new Vector3(0.22f, -0.15f * posSign, 0f);
			Medics[0].targetPos = targetCenter + new Vector3(-0.22f, -0.15f * posSign, 0f);
			Medics[2].targetPos = targetCenter + new Vector3(0f, 0.15f * posSign, 0f);
		}
		else
		{
			Medics[1].targetPos = targetCenter + new Vector3(0.22f, -0.15f * posSign, 0f);
			Medics[2].targetPos = targetCenter + new Vector3(-0.22f, -0.15f * posSign, 0f);
			Medics[0].targetPos = targetCenter + new Vector3(0f, 0.15f * posSign, 0f);
		}
	}

	public override void Target()
	{
		if (UnityEngine.Random.value <= 0.3f)
		{
			base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(Medics[0]);
		}
		else
		{
			base.TargetUnit = UnitHelper.GetRandomEnemyUnit(Medics[0]);
		}
	}

	public void OnMedicDeath()
	{
		if (AllDead)
		{
			for (int i = 0; i < Medics.Count; i++)
			{
				HealthChangeInfo obj = new HealthChangeInfo(null, Medics[i].HealthComponent, 0f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
				this.OnAllDied?.Invoke(obj);
			}
		}
		else if (chargingTimer <= 0f)
		{
			sm.ForceState("Charging");
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
		foreach (E2_3Medic medic in Medics)
		{
			medic.Kill(info);
		}
	}

	public override void EMP(float duration)
	{
		base.EMP(duration);
	}

	public override void OnEMPEnd()
	{
		base.OnEMPEnd();
	}

	public override void Hack(bool isHacked)
	{
	}
}
