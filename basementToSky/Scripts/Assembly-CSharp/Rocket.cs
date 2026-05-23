using System;
using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;

public class Rocket : Item
{
	public float launchDuration = 1.5f;

	public float bounsLaunchDuration;

	public AnimationCurve myCurve;

	public AnimationCurve scaledCurve;

	private float launchTimer;

	public bool isLaunched;

	private bool neverTouchTheGround;

	public float trustPow;

	public float trustPowMult = 1f;

	private float trustPowPerkBounus;

	private float trustDurationPerkBouns;

	private float originalMass;

	public Transform camFollowPos;

	[Header("Damage Settings")]
	public float maxHealth = 100f;

	public float currentHealth;

	public float safeVelocityThreshold = 5f;

	public float damageMultiplier = 2f;

	public float damageCooldown = 0.5f;

	private float lastDamageTime;

	public bool crashed;

	public List<GameObject> crashedPartsNonPaint = new List<GameObject>();

	public List<GameObject> crashedPartPaint = new List<GameObject>();

	public Transform rocketVisualPos;

	public Transform rocketHeadPos;

	public GameObject rocketHead;

	public GameObject rocketBody;

	public List<GameObject> rocketWing = new List<GameObject>();

	public GameObject rocketMotor;

	public GameObject rocketNozzle;

	public GameObject rocketChip;

	public GameObject cameraModule;

	public GameObject wingControlModule;

	public RocketChip wingControlModuleCompo;

	public GameObject parachuteModule;

	public Rigidbody rb;

	public Transform cp;

	public Transform cm;

	private float trustForce;

	public ParticleSystem ps;

	public TrailRenderer tr;

	public Transform camPos;

	public Transform motorPos;

	public RocketBody body;

	public List<RocketWing> wings = new List<RocketWing>();

	public RocketHead head;

	public GameObject parachutePrefab;

	public Parachute parachute;

	private ScoreSystem scoreSystem;

	[SerializeField]
	private RenderTexture rtVideo;

	[SerializeField]
	private RenderTexture rtCameraModule;

	private bool mileStoneReached;

	private bool isScoring;

	public bool calculated;

	public string guid;

	public static event Action<GameObject> OnRetriveRocketActive;

	private void Awake()
	{
		if (string.IsNullOrEmpty(guid))
		{
			guid = Guid.NewGuid().ToString();
			Debug.Log(guid);
		}
		rb = GetComponent<Rigidbody>();
		rb.mass = 0f;
		RocketAttachment[] componentsInChildren = GetComponentsInChildren<RocketAttachment>();
		foreach (RocketAttachment obj in componentsInChildren)
		{
			obj.rocket = this;
			obj.rocketRb = rb;
		}
	}

	private void Start()
	{
		scoreSystem = GetComponent<ScoreSystem>();
		outLine = GetComponent<Outline>();
		calculated = false;
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		IgnoreCollisonInSameObject();
		if (ps != null)
		{
			ps.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
		launchDuration = myCurve.keys[myCurve.length - 1].time - myCurve.keys[0].time;
		currentHealth = maxHealth;
		lastDamageTime = 0f - damageCooldown;
		Block_DeployParachute.OnParachuteDeploy += Block_DeployParachute_OnParachuteDeploy;
		Block_RotateWing.OnRotateWing1 += Block_RotateWing_OnRotateWing1;
	}

	private void Block_RotateWing_OnRotateWing1(int arg1, float arg2)
	{
		if (calculated && !(wingControlModule == null) && !crashed)
		{
			wingControlModuleCompo.RotateWing(arg1, arg2);
		}
	}

	private void OnDestroy()
	{
		Block_DeployParachute.OnParachuteDeploy -= Block_DeployParachute_OnParachuteDeploy;
	}

	private void Block_DeployParachute_OnParachuteDeploy()
	{
		if (calculated && !(parachuteModule == null) && !crashed)
		{
			DeployParachute();
		}
	}

	private void Update()
	{
		if (calculated)
		{
			QuestManager.S.UpdateRecord(camFollowPos.transform.position.y);
		}
	}

	private void FixedUpdate()
	{
		if (calculated)
		{
			CalculateForce();
		}
		if (isScoring)
		{
			scoreSystem.GetScore();
		}
		if (!isLaunched)
		{
			return;
		}
		launchTimer += Time.deltaTime;
		float num = launchTimer;
		trustForce = scaledCurve.Evaluate(num) * trustPow * (trustPowMult + trustPowPerkBounus);
		body.SpendLiquid(num / (launchDuration + bounsLaunchDuration));
		if (!(num >= launchDuration + bounsLaunchDuration))
		{
			return;
		}
		isLaunched = false;
		launchTimer = 0f;
		if (ps != null)
		{
			ps.Stop(withChildren: true);
			if (tr != null)
			{
				tr.emitting = false;
			}
			AudioManager.S.StopRocketSFX();
			trustForce = 0f;
		}
		StartCoroutine(ActiveRetriveBtn());
	}

	public void LaunchRocket()
	{
		GameManager.S.rocketCamera.Priority = 2;
		GameManager.S.player.canControl = false;
		GameManager.S.rocketCamera.Follow = camFollowPos;
		GameManager.S.currentLanchedRocket = this;
		if (body.type == RocketType.Water)
		{
			GameManager.S.RocketLaunched(0);
			AudioManager.S.PlaySFX(AudioManager.S.waterRocketLaunched);
			AudioManager.S.PlayRocketSFX(AudioManager.S.waterRocketFlying);
		}
		if (body.type == RocketType.Gunpowder)
		{
			GameManager.S.RocketLaunched(1);
			AudioManager.S.PlaySFX(AudioManager.S.solidFuelRocketLaunched);
			AudioManager.S.PlayRocketSFX(AudioManager.S.solidFuelRocketFlying);
		}
		base.transform.SetParent(null);
		Collider[] componentsInChildren = base.transform.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			if (collider.GetComponent<MeshCollider>() == null)
			{
				collider.enabled = true;
			}
		}
		rb.isKinematic = false;
		neverTouchTheGround = true;
		isLaunched = true;
		if (ps != null)
		{
			StartCoroutine(PlayParticleNextFrame());
			if (tr != null)
			{
				tr.emitting = true;
			}
		}
		if (GameManager.S.rocketPerkList[0])
		{
			originalMass = rb.mass;
			rb.mass = originalMass * 0.8f;
		}
		if (GameManager.S.rocketPerkList[1])
		{
			trustPowPerkBounus = 0.1f;
		}
		else
		{
			trustPowPerkBounus = 0f;
		}
		if (GameManager.S.rocketPerkList[3])
		{
			trustDurationPerkBouns = 5f;
			bounsLaunchDuration += trustDurationPerkBouns;
			body.PowerCurveUpdate();
		}
		QuestManager.S.ResetMileStoneReached();
		UpdateCenterOfMass();
		scoreSystem.StartScore();
		calculated = true;
		isScoring = true;
		if (wingControlModule != null)
		{
			wingControlModule.GetComponent<RocketChip>().WingsRotInit();
		}
	}

	private IEnumerator PlayParticleNextFrame()
	{
		yield return null;
		ps.Clear();
		ps.Play();
	}

	public override void Interact()
	{
		if (!canGrab)
		{
			return;
		}
		if (GameManager.S.player.itemOnHand == null)
		{
			GameManager.S.player.GrabItem(base.gameObject);
			FirstPersonController.S.rocketOnHand = true;
			FirstPersonController.S.rocket = this;
			base.transform.localRotation *= Quaternion.Euler(-90f, 0f, 0f);
			base.transform.localPosition -= new Vector3(0f, 0.2f, 0f);
			body.SpendLiquid(0f);
			if (originalMass > 0f)
			{
				rb.mass = originalMass;
				originalMass = 0f;
			}
			if (trustDurationPerkBouns > 0f)
			{
				bounsLaunchDuration -= trustDurationPerkBouns;
				body.PowerCurveUpdate();
				trustDurationPerkBouns = 0f;
			}
			GameManager.S.RocketOnHand();
			ps.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			if (tr != null)
			{
				tr.emitting = false;
			}
			if (parachute != null)
			{
				UnityEngine.Object.Destroy(parachute.gameObject);
			}
		}
		else
		{
			GameManager.S.HandsFull();
		}
	}

	public void ResetLiquid()
	{
		body.SpendLiquid(0f);
		ps.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		if (tr != null)
		{
			tr.emitting = false;
		}
	}

	private void OnDrawGizmos()
	{
		if (TryGetComponent<Rigidbody>(out var _))
		{
			Gizmos.color = Color.red;
			Gizmos.color = Color.blue;
		}
	}

	private IEnumerator ActiveRetriveBtn()
	{
		yield return new WaitForSeconds(5f);
		Rocket.OnRetriveRocketActive?.Invoke(base.gameObject);
		isScoring = false;
		if (cameraModule != null)
		{
			Graphics.CopyTexture(rtCameraModule, rtVideo);
		}
	}

	public void DeployParachute()
	{
		if (parachute != null)
		{
			return;
		}
		AudioManager.S.PlaySFX(AudioManager.S.parachute);
		GameObject gameObject = UnityEngine.Object.Instantiate(parachutePrefab, rocketHeadPos);
		parachute = gameObject.GetComponent<Parachute>();
		parachute.rocketRb = rb;
		List<GameObject> obj = new List<GameObject> { head.gameObject };
		scoreSystem.ParachuteScore();
		foreach (GameObject item in obj)
		{
			MeshRenderer[] componentsInChildren = item.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				CwPaintableMeshTexture componentInChildren = item.GetComponentInChildren<CwPaintableMeshTexture>();
				GameObject gameObject2 = meshRenderer.gameObject;
				GameObject gameObject3 = new GameObject(gameObject2.name + "_Piece");
				gameObject3.transform.position = gameObject2.transform.position;
				gameObject3.transform.rotation = gameObject2.transform.rotation;
				gameObject3.transform.localScale = gameObject2.transform.lossyScale;
				MeshFilter component = gameObject2.GetComponent<MeshFilter>();
				if (component != null)
				{
					gameObject3.AddComponent<MeshFilter>().sharedMesh = component.sharedMesh;
				}
				MeshRenderer meshRenderer2 = gameObject3.AddComponent<MeshRenderer>();
				meshRenderer2.material = meshRenderer.sharedMaterial;
				if (!gameObject3.TryGetComponent<Rigidbody>(out var component2))
				{
					component2 = gameObject3.AddComponent<Rigidbody>();
				}
				if (componentInChildren != null)
				{
					Texture2D mainTexture = BakeRenderTexture(componentInChildren.Current);
					meshRenderer2.material.mainTexture = mainTexture;
					crashedPartPaint.Add(gameObject3);
				}
				else
				{
					crashedPartsNonPaint.Add(gameObject3);
				}
			}
			item.transform.localScale = Vector3.zero;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (neverTouchTheGround)
		{
			neverTouchTheGround = false;
			if (parachute != null && !crashed)
			{
				scoreSystem.PerfectLandingScore();
			}
			AudioManager.S.PlayRandomPitch(AudioManager.S.plasticImpact);
		}
		if (!calculated || Time.time < lastDamageTime + damageCooldown)
		{
			return;
		}
		float magnitude = collision.relativeVelocity.magnitude;
		Debug.Log(collision.relativeVelocity.magnitude);
		if (magnitude > safeVelocityThreshold)
		{
			lastDamageTime = Time.time;
			float num = (magnitude - safeVelocityThreshold) * damageMultiplier;
			if (parachute != null)
			{
				num *= 0.2f;
			}
			TakeDamage(num);
			Debug.Log(collision.gameObject.name);
			Debug.Log($"충돌 대미지 발생! 남은 체력: {currentHealth}");
		}
	}

	public void TakeDamage(float amount)
	{
		if (!crashed)
		{
			currentHealth -= amount;
			currentHealth = Mathf.Max(currentHealth, 0f);
			if (currentHealth <= 0f)
			{
				crashed = true;
				AudioManager.S.PlaySFX(AudioManager.S.rocketCrashed);
				Explode();
			}
		}
	}

	private Texture2D BakeRenderTexture(RenderTexture rt)
	{
		if (rt == null)
		{
			return null;
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = rt;
		Texture2D texture2D = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, mipChain: false);
		texture2D.ReadPixels(new Rect(0f, 0f, rt.width, rt.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		return texture2D;
	}

	private void Explode()
	{
		List<GameObject> list = new List<GameObject>();
		if (parachute == null)
		{
			list.Add(head.gameObject);
		}
		foreach (GameObject item in rocketWing)
		{
			list.Add(item);
		}
		list.Add(rocketNozzle);
		foreach (GameObject item2 in list)
		{
			MeshRenderer[] componentsInChildren = item2.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				CwPaintableMeshTexture componentInChildren = item2.GetComponentInChildren<CwPaintableMeshTexture>();
				GameObject gameObject = meshRenderer.gameObject;
				GameObject gameObject2 = new GameObject(gameObject.name + "_Piece");
				gameObject2.transform.position = gameObject.transform.position;
				gameObject2.transform.rotation = gameObject.transform.rotation;
				gameObject2.transform.localScale = gameObject.transform.lossyScale;
				MeshFilter component = gameObject.GetComponent<MeshFilter>();
				if (component != null)
				{
					gameObject2.AddComponent<MeshFilter>().sharedMesh = component.sharedMesh;
				}
				MeshRenderer meshRenderer2 = gameObject2.AddComponent<MeshRenderer>();
				meshRenderer2.material = meshRenderer.sharedMaterial;
				if (!gameObject2.TryGetComponent<Rigidbody>(out var component2))
				{
					component2 = gameObject2.AddComponent<Rigidbody>();
				}
				if (componentInChildren != null)
				{
					Texture2D mainTexture = BakeRenderTexture(componentInChildren.Current);
					meshRenderer2.material.mainTexture = mainTexture;
					crashedPartPaint.Add(gameObject2);
				}
				else
				{
					crashedPartsNonPaint.Add(gameObject2);
				}
				if (!gameObject2.TryGetComponent<MeshCollider>(out var component3))
				{
					component3 = gameObject2.AddComponent<MeshCollider>();
					if (component != null)
					{
						component3.sharedMesh = component.sharedMesh;
					}
				}
				component3.convex = true;
			}
			item2.transform.localScale = Vector3.zero;
		}
		scoreSystem.CrashedScore();
		GameManager.S.RocketCrashed();
	}

	private void IgnoreCollisonInSameObject()
	{
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			for (int j = i + 1; j < componentsInChildren.Length; j++)
			{
				Physics.IgnoreCollision(componentsInChildren[i], componentsInChildren[j]);
			}
		}
	}

	private void CalculateForce()
	{
		rb.AddForceAtPosition(base.transform.forward * trustForce, motorPos.position);
		rb.angularDamping = 1f + rb.linearVelocity.magnitude * 0.005f;
		if (!crashed)
		{
			foreach (RocketWing wing in wings)
			{
				wing.AddForces();
			}
		}
		body.AddForces();
		head.AddForces();
		if (parachute != null)
		{
			parachute.AddForces();
			if (rb.linearVelocity.sqrMagnitude > 0.1f)
			{
				Vector3 b = -rb.linearVelocity.normalized;
				parachute.transform.up = Vector3.Slerp(parachute.transform.up, b, Time.deltaTime * 3f);
			}
		}
	}

	public IEnumerator DelayedCalculateCP()
	{
		yield return null;
		CalculateTotalCP();
		UpdateCenterOfMass();
		Debug.Log(cp);
	}

	public void CalculateTotalCP()
	{
		Vector3 zero = Vector3.zero;
		float num = 0f;
		List<RocketAttachment> list = new List<RocketAttachment>();
		list.Add(body);
		list.Add(head);
		if (wings != null && wings.Count > 0)
		{
			foreach (RocketWing wing in wings)
			{
				list.Add(wing);
			}
		}
		foreach (RocketAttachment item in list)
		{
			Debug.Log(item);
			float onlyLiftMagnitude = item.GetOnlyLiftMagnitude();
			if (onlyLiftMagnitude > 0.0001f)
			{
				zero += item.GetPartPosition() * onlyLiftMagnitude;
				num += onlyLiftMagnitude;
			}
		}
		if (num > 0f)
		{
			Vector3 position = zero / num;
			cp.transform.position = position;
		}
	}

	public void UpdateCenterOfMass()
	{
		Vector3 zero = Vector3.zero;
		float num = 0f;
		RocketAttachment[] componentsInChildren = GetComponentsInChildren<RocketAttachment>();
		foreach (RocketAttachment rocketAttachment in componentsInChildren)
		{
			num += rocketAttachment.mass;
			Vector3 position = rocketAttachment.transform.TransformPoint(rocketAttachment.massOffset);
			Vector3 vector = rb.transform.InverseTransformPoint(position);
			zero += vector * rocketAttachment.mass;
		}
		if (num > 0f)
		{
			rb.centerOfMass = zero / num;
			cm.localPosition = zero / num;
		}
	}

	public void StretchAfterPeak(float extraTime)
	{
		if (myCurve == null || myCurve.length < 2)
		{
			return;
		}
		int num = 0;
		float num2 = myCurve.keys[0].value;
		for (int i = 1; i < myCurve.length; i++)
		{
			if (myCurve.keys[i].value > num2)
			{
				num2 = myCurve.keys[i].value;
				num = i;
			}
		}
		int num3 = Mathf.Min(num + 1, myCurve.length - 1);
		List<Keyframe> list = new List<Keyframe>();
		for (int j = 0; j <= num; j++)
		{
			list.Add(myCurve.keys[j]);
		}
		_ = myCurve.keys[num].time;
		float time = myCurve.keys[num3].time + extraTime;
		list.Add(new Keyframe(time, myCurve.keys[num3].value));
		for (int k = num3 + 1; k < myCurve.length; k++)
		{
			Keyframe keyframe = myCurve.keys[k];
			list.Add(new Keyframe(keyframe.time + extraTime, keyframe.value));
		}
		AnimationCurve animationCurve = new AnimationCurve(list.ToArray());
		for (int l = 0; l < animationCurve.length; l++)
		{
			animationCurve.SmoothTangents(l, 0f);
		}
		scaledCurve = animationCurve;
	}

	public void StretchCurveOverall(float extraTime)
	{
		if (myCurve == null || myCurve.length < 2)
		{
			return;
		}
		float time = myCurve.keys[0].time;
		float num = myCurve.keys[myCurve.length - 1].time - time;
		if (!(num <= 0f))
		{
			float num2 = (num + extraTime) / num;
			Keyframe[] array = new Keyframe[myCurve.length];
			for (int i = 0; i < myCurve.length; i++)
			{
				Keyframe keyframe = myCurve.keys[i];
				float time2 = time + (keyframe.time - time) * num2;
				float inTangent = keyframe.inTangent / num2;
				float outTangent = keyframe.outTangent / num2;
				array[i] = new Keyframe(time2, keyframe.value, inTangent, outTangent);
				array[i].weightedMode = keyframe.weightedMode;
				array[i].inWeight = keyframe.inWeight;
				array[i].outWeight = keyframe.outWeight;
			}
			scaledCurve = new AnimationCurve(array);
			scaledCurve.preWrapMode = myCurve.preWrapMode;
			scaledCurve.postWrapMode = myCurve.postWrapMode;
		}
	}
}
