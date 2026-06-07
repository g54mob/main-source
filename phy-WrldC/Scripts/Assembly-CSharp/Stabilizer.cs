using UnityEngine;

public class Stabilizer : BaseComponentView
{
	[SerializeField]
	private bool isTorqueGizmo;

	private PidController pidAngX;

	private PidController pidAngY;

	private PidController pidAngZ;

	private PidController pidPosX;

	private PidController pidPosY;

	private PidController pidPosZ;

	private Rigidbody rb;

	private LogicIO angleActiveInput;

	private LogicIO positionActiveInput;

	private LogicIO strengthInput;

	private bool isAngleControlOn;

	private bool isPositionControlOn;

	public float maxAngForce = 50f;

	public float maxPosForce = 50f;

	public float a_kp = 8f;

	public float a_ki;

	public float a_kd;

	public float p_kp = 8f;

	public float p_ki;

	public float p_kd;

	private float angVX;

	private float angVY;

	private float angVZ;

	private float angForceX;

	private float angForceY;

	private float angForceZ;

	private float posVX;

	private float posVY;

	private float posVZ;

	private float posForceX;

	private float posForceY;

	private float posForceZ;

	private Renderer thisRenderer;

	private float maxStrength;

	private float currentPercentilStrength;

	public Vector3 AngForceVector { get; private set; }

	public Vector3 PosForceVector { get; private set; }

	public bool IsStabilizerOn
	{
		get
		{
			if (!isAngleControlOn)
			{
				return isPositionControlOn;
			}
			return true;
		}
	}

	private void Awake()
	{
		thisRenderer = GetComponentInChildren<Renderer>(includeInactive: true);
		SetMaterialEmission(isOn: false);
	}

	private void Update()
	{
		if (angleActiveInput.ReadDigitalSignal())
		{
			isAngleControlOn = !isAngleControlOn;
			SetMaterialEmission(isAngleControlOn || isPositionControlOn);
		}
		if (positionActiveInput.ReadDigitalSignal())
		{
			isPositionControlOn = !isPositionControlOn;
			SetMaterialEmission(isAngleControlOn || isPositionControlOn);
		}
		currentPercentilStrength = strengthInput.ReadAnalogSignal();
	}

	private void FixedUpdate()
	{
		if (isAngleControlOn)
		{
			PidController pidController = pidAngX;
			PidController pidController2 = pidAngY;
			float num = (pidAngZ.KP = a_kp * currentPercentilStrength);
			float kP = (pidController2.KP = num);
			pidController.KP = kP;
			PidController pidController3 = pidAngX;
			PidController pidController4 = pidAngY;
			num = (pidAngZ.KI = a_ki);
			kP = (pidController4.KI = num);
			pidController3.KI = kP;
			PidController pidController5 = pidAngX;
			PidController pidController6 = pidAngY;
			num = (pidAngZ.KD = a_kd);
			kP = (pidController6.KD = num);
			pidController5.KD = kP;
			angVX = rb.angularVelocity.x;
			angVY = rb.angularVelocity.y;
			angVZ = rb.angularVelocity.z;
			angForceX = pidAngX.Compute(angVX, 0f, Time.fixedDeltaTime);
			angForceY = pidAngY.Compute(angVY, 0f, Time.fixedDeltaTime);
			angForceZ = pidAngZ.Compute(angVZ, 0f, Time.fixedDeltaTime);
			AngForceVector = new Vector3(angForceX, angForceY, angForceZ);
			rb.AddTorque(AngForceVector, ForceMode.Force);
		}
		if (isPositionControlOn)
		{
			PidController pidController7 = pidPosX;
			PidController pidController8 = pidPosY;
			float num = (pidPosZ.KP = p_kp * currentPercentilStrength);
			float kP = (pidController8.KP = num);
			pidController7.KP = kP;
			PidController pidController9 = pidPosX;
			PidController pidController10 = pidPosY;
			num = (pidPosZ.KI = p_ki);
			kP = (pidController10.KI = num);
			pidController9.KI = kP;
			PidController pidController11 = pidPosX;
			PidController pidController12 = pidPosY;
			num = (pidPosZ.KD = p_kd);
			kP = (pidController12.KD = num);
			pidController11.KD = kP;
			posVX = rb.velocity.x;
			posVY = rb.velocity.y;
			posVZ = rb.velocity.z;
			posForceX = pidPosX.Compute(posVX, 0f, Time.fixedDeltaTime);
			posForceY = pidPosY.Compute(posVY, 0f, Time.fixedDeltaTime);
			posForceZ = pidPosZ.Compute(posVZ, 0f, Time.fixedDeltaTime);
			PosForceVector = new Vector3(posForceX, posForceY, posForceZ);
			rb.AddForce(PosForceVector, ForceMode.Force);
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		isAngleControlOn = false;
		isPositionControlOn = false;
		SetMaterialEmission(isOn: false);
		AngForceVector = Vector3.zero;
		float signal = (currentPercentilStrength = base.BlockBodyView.OverridableProperties.GetPropertyAsFloat("stb_strength", 0.5f));
		strengthInput.SetSignal(signal);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		rb = GetComponent<Rigidbody>();
		maxStrength = properties.GetPropertyAsFloat("strength");
		a_kp = (p_kp = maxStrength);
		a_ki = (p_ki = 0f);
		a_kd = (p_kd = 0f);
		pidAngX = new PidController(a_kp, a_ki, a_kd)
		{
			OutputMinValue = 0f - maxAngForce,
			OutputMaxValue = maxAngForce
		};
		pidAngY = new PidController(a_kp, a_ki, a_kd)
		{
			OutputMinValue = 0f - maxAngForce,
			OutputMaxValue = maxAngForce
		};
		pidAngZ = new PidController(a_kp, a_ki, a_kd)
		{
			OutputMinValue = 0f - maxAngForce,
			OutputMaxValue = maxAngForce
		};
		pidPosX = new PidController(p_kp, p_ki, p_kd)
		{
			OutputMinValue = 0f - maxPosForce,
			OutputMaxValue = maxPosForce
		};
		pidPosY = new PidController(p_kp, p_ki, p_kd)
		{
			OutputMinValue = 0f - maxPosForce,
			OutputMaxValue = maxPosForce
		};
		pidPosZ = new PidController(p_kp, p_ki, p_kd)
		{
			OutputMinValue = 0f - maxPosForce,
			OutputMaxValue = maxPosForce
		};
		base.BlockBodyView.OnSetMaterialEvent += OnSetMaterialHandler;
		base.gameObject.AddComponent<StabilizerGlobePositioner>();
		base.gameObject.AddComponent<StabilizerReplay>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		angleActiveInput = base.BlockBodyView.AddLogicIO(new LogicIO("stb_ang_active", LogicIODirection.Input, digitalSignal: false)
		{
			DefaultKeyType = LogicIODefaultKeyType.UpToDown
		});
		positionActiveInput = base.BlockBodyView.AddLogicIO(new LogicIO("stb_pos_active", LogicIODirection.Input, digitalSignal: false)
		{
			DefaultKeyType = LogicIODefaultKeyType.UpToDown
		});
		strengthInput = base.BlockBodyView.AddLogicIO(new LogicIO("stb_strength_input", LogicIODirection.Input, 0.5f)
		{
			IsInputWithoutKey = true
		});
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		pidAngX.Reset();
		pidAngY.Reset();
		pidAngZ.Reset();
		pidPosX.Reset();
		pidPosY.Reset();
		pidPosZ.Reset();
		SetMaterialEmission(isOn: false);
	}

	protected override void InternalInitializeModel()
	{
		base.InternalInitializeModel();
		base.BlockBodyView.OnSetMaterialEvent += OnSetMaterialHandler;
	}

	public override string GetComponentName()
	{
		return typeof(Stabilizer).Name;
	}

	private void OnSetMaterialHandler(bool isMainMaterial)
	{
		SetMaterialEmission(isOn: false);
	}

	public void SetMaterialEmission(bool isOn)
	{
		thisRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
		thisRenderer.material.EnableKeyword("_EMISSION");
		thisRenderer.material.SetColor("_EmissionColor", Color.HSVToRGB(0f, 0f, isOn ? 5 : 0));
	}

	private void OnDrawGizmos()
	{
		DrawAngForceColor(isTorqueGizmo ? angForceX : posForceX, Vector3.right, Color.red);
		DrawAngForceColor(isTorqueGizmo ? angForceY : posForceY, Vector3.up, Color.green);
		DrawAngForceColor(isTorqueGizmo ? angForceZ : posForceZ, Vector3.forward, Color.blue);
		void DrawAngForceColor(float angForce, Vector3 direction, Color lineColor)
		{
			Gizmos.color = lineColor;
			Gizmos.DrawLine(base.transform.position - direction, base.transform.position + direction);
			Gizmos.DrawSphere(base.transform.position + direction * (angForce / maxAngForce), 0.05f);
		}
	}
}
