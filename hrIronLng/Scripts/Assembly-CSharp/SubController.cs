using TMPro;
using UnityEngine;

public class SubController : MonoBehaviour, ISaveObject
{
	public struct SubData
	{
		public Vector3 MyPosition;

		public Vector3 MyRotation;
	}

	private Vector3 MoveVector;

	private Vector3 RotateVector;

	public float AccelSpeed;

	public float RotateAccelSpeed;

	public float MaxMoveSpeed;

	public float MaxRotSpeed;

	public TMP_Text xCoors;

	public TMP_Text yCoors;

	public TMP_Text Angle;

	public float DirectionDecay;

	public float RotationDecay;

	[HideInInspector]
	public float[] Proximities;

	public TMP_Text[] ProxText;

	public BlinkerScript[] ProxBlinkers;

	public MainComputerController Comp;

	public SubSoundScript MotorForwardSound;

	public SubSoundScript MotorLeftSound;

	public SubSoundScript MotorRightSound;

	public SubSoundScript WaterForwardSound;

	public SubSoundScript WaterLeftSound;

	public SubSoundScript WaterRightSound;

	public bool DoingEye;

	[HideInInspector]
	public bool RotateSoundDirection;

	public GameObject EyeQuad;

	public GameObject FakeBlocker;

	private MainComputerController MainComp;

	public AudioSource MonsterImpact;

	public AudioSource MonsterAttack;

	public AudioSource MonsterAttackMusic;

	public float ProximityMaxDistance;

	public LayerMask ProximityLayers;

	private float MonsterAttackDelay;

	private bool DoAttack;

	public LightControlScript LightCont;

	private MyMouseLook Mouse;

	[HideInInspector]
	public bool Dead;

	public AudioSource SubDieSound;

	public float DeadWaitTime;

	[HideInInspector]
	public Vector3 LastCheckpointPosition;

	private SteamScript SScript;

	private SubData MyData;

	public string MyID => "Fake_Sub";

	private void Start()
	{
		Proximities = new float[4];
		MainComp = GameObject.Find("MainComputer").GetComponent<MainComputerController>();
		Mouse = GameObject.Find("PlayerCamera").GetComponent<MyMouseLook>();
		SScript = GameObject.Find("SteamObject").GetComponent<SteamScript>();
	}

	private void Update()
	{
		if (Dead)
		{
			DeadWaitTime -= Time.deltaTime;
			if (DeadWaitTime <= 0f)
			{
				Application.LoadLevel("Menu");
			}
		}
		base.transform.position += Time.deltaTime * MoveVector;
		base.transform.Rotate(RotateVector * Time.deltaTime * 360f);
		float num = DirectionDecay * Time.deltaTime;
		if (num > MoveVector.magnitude)
		{
			num = MoveVector.magnitude;
		}
		MoveVector = MoveVector.normalized * (MoveVector.magnitude - num);
		float num2 = RotationDecay * Time.deltaTime;
		if (num2 > RotateVector.magnitude)
		{
			num2 = RotateVector.magnitude;
		}
		RotateVector = RotateVector.normalized * (RotateVector.magnitude - num2);
		MotorForwardSound.SetIndex(MoveVector.magnitude / MaxMoveSpeed);
		WaterForwardSound.SetIndex(MoveVector.magnitude / MaxMoveSpeed);
		if (RotateSoundDirection)
		{
			MotorLeftSound.SetIndex(RotateVector.magnitude / MaxRotSpeed);
			WaterLeftSound.SetIndex(RotateVector.magnitude / MaxRotSpeed);
			MotorRightSound.SetIndex(0f);
			WaterRightSound.SetIndex(0f);
		}
		else
		{
			MotorRightSound.SetIndex(RotateVector.magnitude / MaxRotSpeed);
			WaterRightSound.SetIndex(RotateVector.magnitude / MaxRotSpeed);
			MotorLeftSound.SetIndex(0f);
			WaterLeftSound.SetIndex(0f);
		}
		if (DoAttack)
		{
			MonsterAttackDelay -= Time.deltaTime;
			if (MonsterAttackDelay <= 0f)
			{
				DoMonsterAttack();
				MonsterAttackDelay = 0f;
				DoAttack = false;
			}
		}
	}

	private void FixedUpdate()
	{
		xCoors.text = base.transform.position.x.ToString("000.00");
		yCoors.text = base.transform.position.z.ToString("000.00");
		Angle.text = base.transform.localEulerAngles.y.ToString("000.00");
		CheckProximity();
		for (int i = 0; i < 4; i++)
		{
			if (Proximities[i] < ProximityMaxDistance)
			{
				ProxText[i].text = Proximities[i].ToString("00.0");
			}
			else
			{
				ProxText[i].text = "*";
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (Proximities[j] < ProximityMaxDistance)
			{
				if (!ProxBlinkers[j].DoingBlink)
				{
					ProxBlinkers[j].DoingBlink = true;
					ProxBlinkers[j].UpdateBlinkState(b: true);
				}
				ProxBlinkers[j].DoingBlink = true;
				ProxBlinkers[j].MyDelay = Proximities[j] / ProximityMaxDistance * 0.5f;
			}
			else
			{
				ProxBlinkers[j].DoingBlink = false;
			}
		}
		if (DoingEye)
		{
			FakeBlocker.SetActive(value: true);
			if (CheckEyeAngle())
			{
				EyeQuad.SetActive(value: true);
			}
			else
			{
				EyeQuad.SetActive(value: false);
			}
		}
		else
		{
			FakeBlocker.SetActive(value: false);
			EyeQuad.SetActive(value: false);
		}
	}

	public void SetMonsterAttack()
	{
		DoAttack = true;
		MonsterAttackDelay = 2.3f;
		MonsterAttack.Play();
	}

	private void DoMonsterAttack()
	{
		LightCont.Activate();
		MainComp.ResetScreen();
		Mouse.RumbleAmount = 20f;
		MonsterImpact.Play();
		MonsterAttackMusic.Play();
	}

	public bool CheckEyeAngle()
	{
		bool result = false;
		if (base.transform.localEulerAngles.y < 180f && base.transform.localEulerAngles.y > 0f)
		{
			result = true;
		}
		return result;
	}

	public void AddVelocity(float v, Vector3 r)
	{
		Comp.ResetScreen();
		MoveVector += v * AccelSpeed * Time.deltaTime * base.transform.forward;
		if (Mathf.Abs(MoveVector.magnitude) > MaxMoveSpeed)
		{
			MoveVector = MoveVector.normalized * MaxMoveSpeed;
		}
		RotateVector += r * Time.deltaTime * RotateAccelSpeed;
		if (Mathf.Abs(RotateVector.magnitude) > MaxRotSpeed)
		{
			RotateVector = RotateVector.normalized * MaxRotSpeed;
		}
		if (r.y < 0f)
		{
			RotateSoundDirection = false;
		}
		else
		{
			RotateSoundDirection = true;
		}
	}

	public void CheckProximity()
	{
		for (int i = 0; i < 4; i++)
		{
			Vector3 direction = base.transform.forward;
			if (i == 0)
			{
				direction = Vector3.forward;
			}
			if (i == 1)
			{
				direction = Vector3.right;
			}
			if (i == 2)
			{
				direction = -Vector3.forward;
			}
			if (i == 3)
			{
				direction = -Vector3.right;
			}
			Physics.Raycast(base.transform.position, direction, out var hitInfo, ProximityMaxDistance, ProximityLayers);
			if ((bool)hitInfo.transform)
			{
				Proximities[i] = hitInfo.distance;
			}
			else
			{
				Proximities[i] = ProximityMaxDistance;
			}
			if (Dead)
			{
				Proximities[i] = ProximityMaxDistance;
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			DoDeath();
		}
	}

	public void DoDeath()
	{
		Dead = true;
		GameObject.Find("DeadScreen").GetComponent<CanvasGroup>().alpha = 1f;
		SScript.UnlockCheevo("crash_sub");
		SubDieSound.Play();
	}

	public object SaveData()
	{
		Vector3 myPosition = new Vector3(LastCheckpointPosition.x, base.transform.position.y, LastCheckpointPosition.z);
		MyData.MyPosition = myPosition;
		MyData.MyRotation = base.transform.localEulerAngles;
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (SubData)dataIn;
		base.transform.position = MyData.MyPosition;
		base.transform.localEulerAngles = MyData.MyRotation;
	}
}
