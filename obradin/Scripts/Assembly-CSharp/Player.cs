using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public class Spot
	{
		public Vector3 footPos;

		public Quaternion look;

		public Spot()
		{
		}

		public Spot(Transform transform)
		{
			look = transform.rotation;
			footPos = transform.position;
		}

		public Spot(Vector3 footPos_, Quaternion look_)
		{
			footPos = footPos_;
			look = look_;
		}
	}

	public Transform head;

	public Camera mainCamera;

	public AudioClip jumpBoardingAudioClip;

	public PlayerStart playerStart;

	[Readonly]
	public Navigator navigator;

	[Readonly]
	public MouseLook cameraMouseLook;

	[Readonly]
	public MouseLook playerMouseLook;

	[Readonly]
	public WalkwayMotor motor;

	[Readonly]
	public Hand hand;

	[Readonly]
	public WatchHand watchHand;

	[Readonly]
	public Zoomer zoomer;

	private Vector3 eyeOffset_;

	private int disableInputCountdown;

	private int disableMovementCountdown;

	private float cameraDefaultFov;

	private Spot exploringSpot;

	[NonSerialized]
	public Plane[] mainCameraFrustumPlanes = new Plane[6];

	public const float kFovMin = 40f;

	public static Player instance;

	private static int nonPlayerLayerMask;

	public static float cameraFovT
	{
		get
		{
			if (instance != null)
			{
				return Util.LerpScale(instance.mainCamera.fieldOfView, 40f, instance.cameraDefaultFov, 0f, 1f);
			}
			return 60f;
		}
	}

	private bool enableInput
	{
		get
		{
			return Clock.play.running && ((motor != null && motor.canControl) || (motor == null && cameraMouseLook.enabled));
		}
		set
		{
			if (motor != null)
			{
				motor.canControl = value;
			}
			cameraMouseLook.enabled = value;
			playerMouseLook.enabled = value;
		}
	}

	public Vector3 eyeOffset
	{
		get
		{
			return eyeOffset_;
		}
	}

	public Vector3 eyePos
	{
		get
		{
			return base.transform.position + eyeOffset;
		}
		set
		{
			motor.WarpToFootPos(value - eyeOffset + footOffset);
		}
	}

	public Vector3 footOffset
	{
		get
		{
			return new Vector3(0f, (0f - motor.height) * 0.5f, 0f);
		}
	}

	public Vector3 footPos
	{
		get
		{
			return base.transform.position + footOffset;
		}
		set
		{
			motor.WarpToFootPos(value);
		}
	}

	public Quaternion look
	{
		get
		{
			return Quaternion.Euler(mainCamera.transform.localRotation.eulerAngles.x, base.transform.rotation.eulerAngles.y, 0f);
		}
		set
		{
			cameraMouseLook.Look(value);
			playerMouseLook.Look(value);
		}
	}

	public bool inputEnabled
	{
		get
		{
			return enableInput;
		}
	}

	public bool inputAndMovementEnabled
	{
		get
		{
			return inputEnabled && (motor == null || motor.enabled);
		}
	}

	public bool exploringNormally
	{
		get
		{
			return enableInput && motor != null && motor.enabled && !watchHand.inHunt && watchHand.exploringForce == WatchHand.ExploringForce.None;
		}
	}

	public Transform watchDialTransform
	{
		get
		{
			return watchHand.dialTransform;
		}
	}

	private void Awake()
	{
		nonPlayerLayerMask = ~(1 << LayerMask.NameToLayer("Player"));
		eyeOffset_ = head.transform.localPosition;
	}

	private void OnEnable()
	{
		instance = this;
	}

	private void OnDisable()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	private void Start()
	{
		if (Game.isExploring)
		{
			exploringSpot = SaveData.it.GetPlayerExploringSpot();
			if (exploringSpot != null)
			{
				footPos = exploringSpot.footPos;
				look = exploringSpot.look;
			}
			else
			{
				WarpToPlayerStart();
				exploringSpot = new Spot(playerStart.transform.position, playerStart.transform.rotation);
			}
		}
		else
		{
			WarpToPlayerStart();
		}
		cameraDefaultFov = mainCamera.fieldOfView;
	}

	public void MoveToFootPos(Vector3 footPos)
	{
		motor.MoveToFootPos(footPos);
	}

	public void WarpToPlayerStart()
	{
		if (!(playerStart == null))
		{
			DropToFloor(playerStart.transform.position);
			playerMouseLook.Look(playerStart.transform.rotation);
			cameraMouseLook.Look(Quaternion.Euler(playerStart.lookUpDownAngle, 0f, 0f));
		}
	}

	public void DropToFloor(Vector3 wantFootPos)
	{
		Vector3 origin = wantFootPos + 0.1f * Vector3.up;
		RaycastHit hitInfo = default(RaycastHit);
		int num = 1 << LayerMask.NameToLayer("Player");
		if (Physics.Raycast(origin, Vector3.down, out hitInfo, 1f, ~num))
		{
			wantFootPos = hitInfo.point + 0.001f * Vector3.up;
		}
		if (motor != null)
		{
			motor.WarpToFootPos(wantFootPos);
		}
	}

	private void Update()
	{
		if (disableInputCountdown == 1)
		{
			enableInput = true;
			disableInputCountdown = 0;
		}
		else
		{
			disableInputCountdown = Mathf.Max(0, disableInputCountdown - 1);
		}
		if (disableMovementCountdown == 1)
		{
			if (motor != null)
			{
				motor.enabled = true;
			}
			disableMovementCountdown = 0;
		}
		else
		{
			disableMovementCountdown = Mathf.Max(0, disableMovementCountdown - 1);
		}
		StoreExploringSpotInSaveData();
	}

	private void StoreExploringSpotInSaveData()
	{
		if (exploringSpot != null && motor.publishedToTransformAtLeastOnce && exploringNormally)
		{
			exploringSpot.footPos = footPos;
			exploringSpot.look = look;
			SaveData.it.SetPlayerExploringSpot(exploringSpot);
		}
	}

	public void SetGhostReveal(WatchHand.ExploringForce exploringForce)
	{
		watchHand.exploringForce = exploringForce;
		if (exploringForce == WatchHand.ExploringForce.None)
		{
			StoreExploringSpotInSaveData();
		}
	}

	public void UpdateMainCameraFrustumPlanes()
	{
		GeometryUtilityAllocFree.CalculateFrustumPlanes(mainCamera, mainCameraFrustumPlanes);
	}

	public void DisableInputForOneFrame()
	{
		enableInput = false;
		disableInputCountdown = 2;
	}

	public void DisableMovementForOneFrame()
	{
		if (motor != null)
		{
			motor.enabled = false;
		}
		disableMovementCountdown = 2;
	}

	public void FillSpot(Spot spot)
	{
		spot.footPos = footPos;
		spot.look = look;
	}

	public Navigator.Mark GetNavigatorMark()
	{
		if (navigator == null)
		{
			return default(Navigator.Mark);
		}
		return navigator.GetMark(base.transform.position, base.transform.forward);
	}

	public void RemoveNavigator()
	{
		navigator = null;
	}

	public static bool CanSee(Vector3 worldPos)
	{
		Camera camera = instance.mainCamera;
		Vector3 vector = camera.WorldToViewportPoint(worldPos);
		if (vector.x < 0f || vector.x > 1f || vector.y < 0f || vector.y > 1f || vector.z < 0f)
		{
			return false;
		}
		int layerMask = nonPlayerLayerMask;
		Vector3 position = camera.transform.position;
		bool flag = Physics.Raycast(position, worldPos - position, (worldPos - position).magnitude, layerMask);
		return !flag;
	}
}
