using System;
using UnityEngine;

public class ModuleClaw : Module
{
	[SerializeField]
	private GameObject clawAssemblyPrefab;

	[SerializeField]
	private float armLength;

	private const float CLAW_HALF_LENGTH = 0.05f;

	private GameObject clawAssemblyGO;

	private ClawAssembly c1;

	private ClawAssembly c2;

	public bool isShocking;

	public float collectExplosionDamage;

	public bool isAudioPlaying;

	private Vector2 currentPoint;

	private Vector2 targetVector;

	private (float, float) c1target;

	private (float, float) c2target;

	private bool isClawMoving;

	private bool isInteracting;

	private bool isStartingPositionSet;

	public ParticleSystem resourceImplosionPS;

	private bool isUsingPresetAngles;

	public float currentSpeed;

	[SerializeField]
	private float stickSpeedMult = 0.5f;

	[SerializeField]
	private FloatingResourceDisplay resourcePickuipFloatingText;

	private bool hasSwitchedTracks;

	private bool isReturningToStraightPath;

	private bool hasInteractedDuringTurn;

	private Vector2 lastAimPoint;

	[field: SerializeField]
	public float ShockRadius { get; private set; }

	[field: SerializeField]
	public float TimeBetweenShocks { get; private set; }

	public event Action OnSecondClawCreated;

	public event Action OnPickup;

	private new void Awake()
	{
		base.Awake();
		clawAssemblyGO = UnityEngine.Object.Instantiate(clawAssemblyPrefab, base.transform);
		c1 = clawAssemblyGO.GetComponent<ClawAssembly>();
		c1.module = this;
		c1target = (c1.Pivot1Angle, c1.Pivot2Angle);
	}

	private new void Start()
	{
		base.Start();
		c1.OnPickup += Claw_OnPickup;
		c1.OnResourcePickedUp += Claw_OnResourceCollected;
		base.OuterPartOutline = clawAssemblyGO.GetComponent<Outline>();
		TrackManager.Instance.OnSwitchingToOtherPath += delegate
		{
			hasSwitchedTracks = true;
		};
		TrackManager.Instance.OnReturningToStraightPath += delegate
		{
			if (hasSwitchedTracks)
			{
				isReturningToStraightPath = true;
			}
		};
	}

	protected override void SetEmpSoundChannels()
	{
	}

	private void Claw_OnPickup()
	{
		this.OnPickup?.Invoke();
		Debug.LogWarning("Claw Pickup Invoked");
	}

	private void Claw_OnResourceCollected(ResourceBoxData rbData)
	{
		if (rbData != null)
		{
			_ = rbData.ResourcePosition;
			if (!(resourcePickuipFloatingText == null))
			{
				Debug.LogWarning("Claw Pickup Resource Invoked");
				resourcePickuipFloatingText.SpawnResourceText(rbData.ResourcePosition, rbData.ResourceAmount, rbData.ResourceType);
			}
		}
	}

	public override void AddResource(float amount, ResourceTypes resourceType)
	{
		UpdateMainStat(amount);
		base.AddResource(amount, resourceType);
	}

	private new void Update()
	{
		base.Update();
		if (base.IsEMPattached || (!isStartingPositionSet && !isInteracting && !isUsingPresetAngles))
		{
			return;
		}
		if (!isUsingPresetAngles && isInteracting)
		{
			if (c2 == null)
			{
				c1target = CalculateArmAngles(targetVector);
			}
			else
			{
				targetVector.y = Mathf.Abs(targetVector.y);
				c1target = CalculateArmAngles(targetVector);
				Vector3 vector = new Vector3(targetVector.x, 0f - targetVector.y);
				c2target = CalculateArmAngles(vector);
			}
		}
		bool num = !c1.AdjustArmAngles(c1target);
		ClawAssembly clawAssembly = c2;
		isClawMoving = num & ((object)clawAssembly == null || !clawAssembly.AdjustArmAngles(c2target));
		if (!isClawMoving)
		{
			isUsingPresetAngles = false;
		}
		SetAudioPlaying(isClawMoving);
		Interactor interactor = base.Interactable.Interactor;
		if ((object)interactor != null && interactor.GetComponent<PlayerController>().IsGamepad)
		{
			currentSpeed = stickSpeedMult;
		}
		else
		{
			currentSpeed = GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.deltaTime;
		}
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		base.OnInteractStart(interactor);
		currentPoint = (targetVector = (Vector2)c1.claw.transform.position - (Vector2)base.transform.position) + new Vector2(0.05f, 0f);
		isInteracting = true;
		isUsingPresetAngles = false;
		ModuleStartAiming();
		if (hasSwitchedTracks)
		{
			hasInteractedDuringTurn = true;
		}
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		base.OnInteractEnd(interactor);
		isInteracting = false;
		isAudioPlaying = false;
		ModuleEndAiming();
	}

	protected override void HandleLevelStarted()
	{
		isUsingPresetAngles = true;
		if (c2 == null)
		{
			c1target = (90f * (float)((UnityEngine.Random.Range(0, 2) != 0) ? 1 : (-1)), 0f);
		}
		else
		{
			c1target = (90f, 0f);
			c2target = (-90f, 0f);
		}
		targetVector = GetTargetVectorFromArmAngles(c1target.Item1, c1target.Item2);
		isStartingPositionSet = true;
	}

	protected override void HandleLevelCompleted()
	{
		isUsingPresetAngles = true;
		isStartingPositionSet = false;
		c1target = (0f, 0f);
		c2target = (0f, 0f);
	}

	protected override void OnSetPoint(Vector2 point)
	{
		if (!((lastAimPoint - point).magnitude < aimPosThreashold))
		{
			lastAimPoint = point;
			targetVector = (Vector2)Camera.main.ScreenToWorldPoint(point) + new Vector2(-0.05f, 0f) - (Vector2)base.transform.position;
		}
	}

	protected override void OnTranslatePoint(Vector2 point)
	{
		if (point.magnitude > 0.01f)
		{
			SetAudioPlaying(isPlaying: true);
		}
		else
		{
			SetAudioPlaying(isPlaying: false);
		}
		if (isUsingPresetAngles)
		{
			if (!(point.sqrMagnitude >= 0.01f))
			{
				return;
			}
			isUsingPresetAngles = false;
		}
		currentPoint += point * currentSpeed * Time.deltaTime;
		currentPoint = Vector2.ClampMagnitude(currentPoint, armLength * 2f);
		targetVector = currentPoint + new Vector2(-0.05f, 0f);
		c1target = CalculateArmAngles(targetVector);
		if (c2 != null)
		{
			Vector2 vector = new Vector2(targetVector.x, 0f - targetVector.y);
			c2target = CalculateArmAngles(vector);
		}
		c1.AdjustArmAngles(c1target, instant: true);
		if (c2 != null)
		{
			c2.AdjustArmAngles(c2target, instant: true);
		}
	}

	private (float, float) CalculateArmAngles(Vector2 targetVector)
	{
		float magnitude = targetVector.magnitude;
		float num = Mathf.Atan2(targetVector.y, targetVector.x) * 57.29578f;
		float num2 = Mathf.Acos(Mathf.Clamp(magnitude, 0f, armLength * 2f) / 2f / armLength) * 57.29578f;
		float item;
		float item2;
		if (num > 0f)
		{
			item = num + num2;
			item2 = num - num2;
		}
		else
		{
			item = num - num2;
			item2 = num + num2;
		}
		return (item, item2);
	}

	private Vector2 GetTargetVectorFromArmAngles(float a1, float a2)
	{
		float num = (a1 + a2) * 0.5f;
		float num2 = Mathf.Abs(a1 - a2) * 0.5f;
		float f = num * (MathF.PI / 180f);
		float f2 = num2 * (MathF.PI / 180f);
		float num3 = 2f * armLength * Mathf.Cos(f2);
		return new Vector2(num3 * Mathf.Cos(f), num3 * Mathf.Sin(f));
	}

	public void SetAudioPlaying(bool isPlaying)
	{
		if (!isClawMoving || isAudioPlaying != isPlaying)
		{
			isAudioPlaying = isPlaying;
			if (isPlaying)
			{
				PlayModuleUniqueSound();
			}
			else
			{
				StopModuleUniqueSound(stopAll: true);
			}
		}
	}

	public void InstantiateC2()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(clawAssemblyPrefab, base.transform);
		c2 = gameObject.GetComponent<ClawAssembly>();
		c2.module = this;
		c2.OnPickup += Claw_OnPickup;
		c2.OnResourcePickedUp += Claw_OnResourceCollected;
		this.OnSecondClawCreated?.Invoke();
	}

	public void SetIsDeflecting(bool val)
	{
		c1.SetIsDeflecting(val);
		if ((bool)c2)
		{
			c2.SetIsDeflecting(val);
		}
	}

	public void SetDeflectChance(float chance)
	{
		c1.SetDeflectChance(chance);
		if ((bool)c2)
		{
			c2.SetDeflectChance(chance);
		}
	}

	public void CompensateTurn(bool isUp)
	{
		if (isInteracting)
		{
			return;
		}
		if (isUp)
		{
			targetVector.y += -0.4f;
			c1target = CalculateArmAngles(targetVector);
			if (c2 != null)
			{
				if (hasSwitchedTracks && isReturningToStraightPath && !hasInteractedDuringTurn)
				{
					Vector2 vector = new Vector2(targetVector.x, 0f - targetVector.y);
					c2target = CalculateArmAngles(vector);
					hasSwitchedTracks = false;
					isReturningToStraightPath = false;
				}
				else
				{
					Vector2 vector2 = new Vector2(targetVector.x, 0f - targetVector.y - 0.8f);
					c2target = CalculateArmAngles(vector2);
				}
				hasInteractedDuringTurn = false;
			}
			return;
		}
		targetVector.y += 0.4f;
		c1target = CalculateArmAngles(targetVector);
		if (c2 != null)
		{
			if (hasSwitchedTracks && isReturningToStraightPath && !hasInteractedDuringTurn)
			{
				Vector2 vector3 = new Vector2(targetVector.x, 0f - targetVector.y);
				c2target = CalculateArmAngles(vector3);
				hasSwitchedTracks = false;
				isReturningToStraightPath = false;
			}
			else
			{
				Vector2 vector4 = new Vector2(targetVector.x, 0f - targetVector.y + 0.8f);
				c2target = CalculateArmAngles(vector4);
			}
			hasInteractedDuringTurn = false;
		}
	}
}
