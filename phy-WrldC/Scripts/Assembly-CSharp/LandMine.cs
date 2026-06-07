using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : DynamicObjectBase, IExplosiveObject
{
	[SerializeField]
	private float explosionPower = 500f;

	[SerializeField]
	private float explosionDamage = 100f;

	[SerializeField]
	private float explosionRadius = 5f;

	[SerializeField]
	private float triggerDelay = 3f;

	[SerializeField]
	private float triggerRadius = 0.5f;

	[SerializeField]
	private float impactTrigger = 10f;

	[SerializeField]
	private bool isTriggerNoReturn;

	[SerializeField]
	private GameObject explosionPrefab;

	private TriggerEvents triggerEvents;

	private SphereCollider sphereColliderTrigger;

	private Light mineLedLight;

	private Material material;

	private SimpleExplosion simpleExplosion;

	private HashSet<GameObject> objectsInCollision;

	private bool shouldExplode;

	private bool hasExploded;

	private float timeCounter;

	private bool shouldBeep;

	private float beepCycleSize;

	private float beepCounter;

	private bool isTriggerNoReturnActivated;

	public bool IsLedOn { get; private set; }

	public event Action OnBeepEvent;

	public event Action OnExplosionEvent;

	protected override void Awake()
	{
		base.Awake();
		objectsInCollision = new HashSet<GameObject>();
		triggerEvents = base.transform.GetComponentInChildren<TriggerEvents>();
		sphereColliderTrigger = base.transform.GetComponentInChildren<SphereCollider>();
		mineLedLight = base.transform.GetComponentInChildren<Light>();
		material = GetComponent<Renderer>().material;
		simpleExplosion = base.gameObject.AddComponent<SimpleExplosion>();
		triggerEvents.OnTriggerEnterEvent += TriggerEnterHandler;
		triggerEvents.OnTriggerExitEvent += TriggerExitHandler;
		Recycle();
	}

	protected override void AddReplayComponents()
	{
		base.AddReplayComponents();
		base.gameObject.AddComponent<LandMineReplay>();
	}

	public override void SetExistence(bool isExisting)
	{
		base.SetExistence(isExisting);
		if (!isExisting)
		{
			mineLedLight.enabled = false;
		}
	}

	public override void Recycle()
	{
		base.Recycle();
		sphereColliderTrigger.radius = triggerRadius;
		base.gameObject.SetActive(value: true);
		objectsInCollision.Clear();
		shouldExplode = false;
		hasExploded = false;
		timeCounter = 0f;
		isTriggerNoReturnActivated = false;
		ResetTimers();
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
	}

	protected override void OnDestroyedObject()
	{
		base.OnDestroyedObject();
		StartCoroutine(DelayedExplosion(0.1f));
	}

	private IEnumerator DelayedExplosion(float delay)
	{
		yield return new WaitForSeconds(delay);
		shouldExplode = true;
	}

	private void TriggerEnterHandler(Collider obj)
	{
		if (!(obj.gameObject.GetComponentInParent<Rigidbody>() == null) && !objectsInCollision.Contains(obj.gameObject))
		{
			objectsInCollision.Add(obj.gameObject);
		}
	}

	private void TriggerExitHandler(Collider obj)
	{
		if (objectsInCollision.Contains(obj.gameObject))
		{
			objectsInCollision.Remove(obj.gameObject);
		}
	}

	private void ResetTimers()
	{
		SetLedOnOff(isOn: false);
		beepCounter = 0f;
		beepCycleSize = triggerDelay / 6f;
		shouldBeep = true;
	}

	public void SetLedOnOff(bool isOn)
	{
		if (!base.IsExisting)
		{
			isOn = false;
		}
		material.SetColor("_EmissionColor", isOn ? Color.HSVToRGB(0f, 0f, 5f) : Color.HSVToRGB(0f, 0f, 0f));
		mineLedLight.enabled = isOn;
		IsLedOn = isOn;
	}

	private void Update()
	{
		if (!base.IsInAction || hasExploded)
		{
			return;
		}
		if (objectsInCollision.Count > 0 || isTriggerNoReturnActivated)
		{
			timeCounter += Time.deltaTime;
			if (isTriggerNoReturn && !isTriggerNoReturnActivated)
			{
				isTriggerNoReturnActivated = true;
			}
		}
		else
		{
			timeCounter = 0f;
			if (beepCounter != 0f || mineLedLight.enabled)
			{
				ResetTimers();
			}
		}
		if (timeCounter > beepCounter && shouldBeep)
		{
			SetLedOnOff(isOn: true);
			if (this.OnBeepEvent != null)
			{
				this.OnBeepEvent();
			}
			beepCounter += beepCycleSize;
			shouldBeep = false;
		}
		else if (timeCounter > beepCounter && !shouldBeep)
		{
			SetLedOnOff(isOn: false);
			beepCycleSize /= 1.5f;
			beepCounter += beepCycleSize;
			shouldBeep = true;
		}
		if (timeCounter >= triggerDelay || shouldExplode)
		{
			hasExploded = true;
			GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(explosionPrefab);
			particlesInstance.transform.position = base.transform.position;
			particlesInstance.transform.rotation = base.transform.rotation;
			particlesInstance.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
			simpleExplosion.Power = explosionPower;
			simpleExplosion.Damage = explosionDamage;
			simpleExplosion.Radius = explosionRadius;
			simpleExplosion.Explode();
			if (this.OnExplosionEvent != null)
			{
				this.OnExplosionEvent();
			}
			SetExistence(isExisting: false);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude >= impactTrigger)
		{
			shouldExplode = true;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, explosionRadius);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(base.transform.position, triggerRadius);
		if (sphereColliderTrigger != null)
		{
			sphereColliderTrigger.radius = triggerRadius;
		}
	}
}
