using System;
using UnityEngine;

public class ClawAssembly : MonoBehaviour
{
	[SerializeField]
	private Transform arm1;

	[SerializeField]
	private Transform arm2;

	private SpriteRenderer arm1sr;

	private SpriteRenderer arm2sr;

	[SerializeField]
	private Transform clawTF;

	[SerializeField]
	public Claw claw;

	[SerializeField]
	private Transform hydraulicBase;

	[SerializeField]
	private Transform hydraulicRod;

	[SerializeField]
	private Transform hydraulicTarget;

	private BoxCollider2D controllerBc2d;

	[NonSerialized]
	public ModuleClaw module;

	public ParticleSystem shockPS;

	private float a1current;

	private float a2current;

	private const float ROD_SCALE_RATIO = 1.5f;

	public float Pivot1Angle
	{
		get
		{
			return arm1.eulerAngles.z;
		}
		private set
		{
			float num = Mathf.Abs(Mathf.DeltaAngle(value, 90f));
			arm1sr.flipY = num > 90f;
			arm2sr.flipY = num > 90f;
			arm1.rotation = Quaternion.AngleAxis(value, Vector3.forward);
		}
	}

	public float Pivot2Angle
	{
		get
		{
			return arm2.eulerAngles.z;
		}
		private set
		{
			arm2.rotation = Quaternion.AngleAxis(value, Vector3.forward);
		}
	}

	public BoxCollider2D ControllerBc2d
	{
		get
		{
			return controllerBc2d;
		}
		private set
		{
			controllerBc2d = value;
		}
	}

	public event Action OnPickup;

	public event Action<ResourceBoxData> OnResourcePickedUp;

	private void Awake()
	{
		arm1sr = arm1.GetComponent<SpriteRenderer>();
		arm2sr = arm2.GetComponent<SpriteRenderer>();
		controllerBc2d = base.transform.parent.GetComponent<BoxCollider2D>();
	}

	private void Start()
	{
		claw.OnPickup += Claw_OnPickup;
		claw.OnResourcePickedUp += Claw_OnResourcePickedUp;
	}

	private void Claw_OnPickup()
	{
		this.OnPickup?.Invoke();
	}

	private void Claw_OnResourcePickedUp(ResourceBoxData rbd)
	{
		this.OnResourcePickedUp?.Invoke(rbd);
	}

	public bool AdjustArmAngles((float, float) targetAngles, bool instant = false)
	{
		if (instant)
		{
			a1current = targetAngles.Item1;
			a2current = targetAngles.Item2;
			Pivot1Angle = a1current;
			Pivot2Angle = a2current;
			return true;
		}
		float num = Mathf.DeltaAngle(a1current, targetAngles.Item1);
		float num2 = Mathf.DeltaAngle(a2current, targetAngles.Item2);
		float currentSpeed = module.currentSpeed;
		float num3 = Mathf.Clamp(num, 0f - currentSpeed, currentSpeed);
		float num4 = Mathf.Clamp(num2, 0f - currentSpeed, currentSpeed);
		a1current += num3;
		a2current += num4;
		Pivot1Angle = a1current;
		Pivot2Angle = a2current;
		if (Mathf.Abs(num) <= 0.1f)
		{
			return Mathf.Abs(num2) <= 0.1f;
		}
		return false;
	}

	private void Update()
	{
		clawTF.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
		Vector3 upwards = hydraulicTarget.position - hydraulicBase.position;
		float magnitude = upwards.magnitude;
		hydraulicRod.localScale = new Vector3(1f, magnitude * 1.5f, 1f);
		hydraulicBase.rotation = Quaternion.LookRotation(Vector3.forward, upwards);
	}

	public void SetIsDeflecting(bool val)
	{
		claw.isDeflecting = val;
	}

	public void SetDeflectChance(float chance)
	{
		claw.deflectChance = chance;
	}
}
