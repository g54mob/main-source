using System;
using DevConsole;
using MadGoat_SSAA;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;
using UnityStandardAssets.ImageEffects;

public class CameraScript : MonoBehaviour
{
	public static float FlyCamDistance = 1f;

	private Vector2 TargetPos;

	private bool GotoTarget;

	private Vector3 lastPos;

	private Quaternion Target;

	public float ScrollSpeed = 20f;

	public float ZoomSpeed = 500f;

	public float RotationSpeed = 10f;

	public float DragMomentum = 10f;

	public float DragSlowdown = 1f;

	public float SkyscraperDitherOffset = 16f;

	public float NormalFOV = 15f;

	public float TopDownFOV = 5f;

	private float _currentZoom = 100f;

	private float _topDownFactor;

	public bool FlyMode;

	public float FOV;

	public AntiAliasing SMAA;

	public MadGoatSSAA SSAScript;

	public SSAOPro SSAO;

	public TiltShift TiltScript;

	public AnimationCurve TiltArea;

	public AnimationCurve AmbIntensity;

	public AnimationCurve AmbRadius;

	public AnimationCurve LowSfx;

	public AnimationCurve HighSfx;

	public AnimationCurve DaySfx;

	public Antialiasing AntiAlias;

	public BloomOptimized Bloom;

	public GlobalFog Fog;

	public ScreenSpaceReflection SSR;

	public static CameraScript Instance;

	private AudioSource WinterWind;

	private AudioSource HighWind;

	private AudioSource BirdSound;

	private AudioSource CricketSound;

	private AudioSource PipeSound;

	private int birdPlay = 1;

	private float lastBird;

	private int LastFloor;

	private Vector2 Momentum = Vector2.zero;

	[NonSerialized]
	public Camera mainCam;

	public Shader DataShader;

	public GameObject GroundMesh;

	public GameObject UndergroundMesh;

	public RawImage SaveIndicator;

	private bool DoneSaving;

	public bool TopDown = true;

	public bool FlyLockFloor;

	public int FlyFloor;

	public GameObject StopFollowButton;

	private ColorCorrectionLookup DataColors;

	public AudioListener Listener;

	private Vector3 lastDragPos;

	[NonSerialized]
	private bool isDragging;

	[NonSerialized]
	public bool wasDragging;

	[NonSerialized]
	public bool wasRotating;

	public Transform Follow;

	public float ZoomMin = 15f;

	public float ZoomMax = 430f;

	public Vector3 LastPos;

	public Vector3 LastPosMomentum;

	public Vector3 LastCamPos;

	public Vector3 LastListenerPos;

	public Vector2 FlatForward;

	public GammaSaturation GSat;

	public Text FloorLabel;

	public ServerWireRenderer WireRender;

	private bool _usingTouch;

	private Vector2 _touch1;

	private Vector2 _touch2;

	private Vector2 _touchPos;

	private float _touchZoom;

	private float _touchRot;

	public static float ScreenUpscale
	{
		get
		{
			return (float)Options.SSAA / 10f;
		}
	}

	public static bool WasDragging
	{
		get
		{
			if (Instance != null)
			{
				return Instance.wasDragging;
			}
			return false;
		}
	}

	public float NormalizedZoom
	{
		get
		{
			return _currentZoom.MapRange(ZoomMin, ZoomMax, 0f, 1f);
		}
	}

	public bool IsTopDownOrFree
	{
		get
		{
			if (!TopDown)
			{
				return FlyMode;
			}
			return true;
		}
	}

	public int GetCameraFloor()
	{
		if (!FlyMode)
		{
			return GameSettings.Instance.ActiveFloor;
		}
		return Mathf.FloorToInt(mainCam.transform.position.y / 2f);
	}

	private void Start()
	{
		mainCam = Camera.main;
		AudioSource[] components = GetComponents<AudioSource>();
		WinterWind = components[0];
		HighWind = components[1];
		BirdSound = components[2];
		CricketSound = components[3];
		PipeSound = components[4];
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		ApplyOptions();
		ApplySpeeds();
		UpdatePostFX();
		lastBird = 5f;
		DataColors = mainCam.GetComponents<ColorCorrectionLookup>()[2];
		WireRender.enabled = false;
	}

	public static void ApplySpeeds()
	{
		if (Instance != null)
		{
			Instance.ScrollSpeed = Options.ScrollSpeed;
			Instance.ZoomSpeed = Options.ZoomSpeed;
			Instance.RotationSpeed = Options.RotationSpeed;
		}
	}

	public static void GotoPos(Vector2 pos)
	{
		if (Instance != null)
		{
			Instance.TargetPos = pos;
			Instance.GotoTarget = true;
		}
	}

	public static void ApplyOptions()
	{
		if (Instance != null)
		{
			Instance.SSAScript.multiplier = (float)Options.SSAA / 10f;
			Instance.SSAScript.enabled = Options.SSAA > 10;
			Instance.SSR.enabled = Options.SSR;
			Instance.SSAO.enabled = Options.AmbientOcclusion;
			Instance.Bloom.enabled = Options.Bloom;
			Instance.TiltScript.enabled = Options.TiltShift;
			Instance.EvaluateTiltshift();
			Instance.AntiAlias.enabled = Options.FXAA;
			Instance.SMAA.enabled = Options.SMAA;
			Instance.UpdatePostFX();
			Instance.GSat.Gamma = Options.Gamma;
			TimeOfDay.Instance.UpdateProbeState();
		}
		else if (MainMenuController.Instance != null)
		{
			MainMenuController.Instance.ApplyOptions();
		}
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void RefreshZoom()
	{
		_currentZoom = 0f - mainCam.transform.localPosition.z;
	}

	public void StopFollowing()
	{
		Follow = null;
	}

	private void RefreshFlyMode()
	{
		if (FlyMode)
		{
			if (!Cheats.CeilingMeshes)
			{
				Cheats.CeilingMeshes = true;
				GameSettings.Instance.sRoomManager.Rooms.ForEach(delegate(Room x)
				{
					x.DirtyOuterMesh = true;
					x.DirtyInnerMesh = true;
				});
			}
			UndergroundMesh.SetActive(true);
			GroundMesh.SetActive(true);
			Momentum = Vector2.zero;
			HUD.Instance.BuildMode = false;
			BuildController.Instance.ClearBuild();
			LastFloor = GameSettings.Instance.ActiveFloor;
			GameSettings.Instance.ActiveFloor = 100;
			GameSettings.Instance.sRoomManager.ChangeFloor();
			FOV = mainCam.fieldOfView;
			TiltScript.blurArea = 0f;
			SSAO.Intensity = 2f;
			SSAO.Radius = 1.2f;
			FOV = 40f;
		}
		else
		{
			GameSettings.Instance.ActiveFloor = LastFloor;
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
		Furniture.UpdateEdgeDetection();
		Fog.height = ((!FlyMode) ? 1 : (-1));
		Fog.startDistance = (FlyMode ? 10 : 0);
		mainCam.fieldOfView = NormalFOV;
		mainCam.nearClipPlane = (FlyMode ? 0.5f : 2f);
		mainCam.farClipPlane = (FlyMode ? (125f * FlyCamDistance) : 700f);
		SSAO.CutoffDistance = (FlyMode ? (100f * FlyCamDistance) : 500f);
		mainCam.transform.localPosition = new Vector3(0f, 0f, 0f - _currentZoom);
		mainCam.transform.localRotation = Quaternion.identity;
		Target = mainCam.transform.rotation;
		Cursor.lockState = (FlyMode ? CursorLockMode.Locked : Options.CursorLock());
		Cursor.visible = !FlyMode;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		FlatForward = mainCam.transform.forward.FlattenVector3().normalized;
		FloorLabel.text = GameSettings.Instance.ActiveFloor.ToString();
		if (isDragging)
		{
			wasDragging |= (LastPos - base.transform.position).magnitude > 0.2f;
		}
		if (wasDragging && !InputController.GetKey(InputController.Keys.DragCamera, true) && !InputController.GetKeyUp(InputController.Keys.DragCamera, true))
		{
			wasDragging = false;
		}
		if (isDragging && !InputController.GetKey(InputController.Keys.DragCamera, true))
		{
			isDragging = false;
			WindowManager.SetCursorOverride(null);
			Momentum = (base.transform.position - LastPosMomentum).FlattenVector3() * (DragMomentum / _currentZoom);
			if (!wasDragging)
			{
				Momentum = Vector2.zero;
			}
		}
		DataColors.enabled = DataOverlay.HasActive;
		if (DoneSaving)
		{
			SaveIndicator.enabled = false;
			DoneSaving = false;
		}
		float num = ((GameSettings.GameSpeed == 0f) ? 0f : 1f);
		lastBird -= Time.deltaTime;
		if (lastBird <= 0f)
		{
			birdPlay = 1 - birdPlay;
			lastBird = UnityEngine.Random.Range(2f, 10f);
		}
		float t = Time.deltaTime * (float)((GameSettings.GameSpeed == 0f) ? 10 : 2);
		HighWind.volume = Mathf.Lerp(HighWind.volume, (GameSettings.Instance.ActiveFloor == -1) ? 0f : (HighSfx.Evaluate(_currentZoom / 600f) * num), t);
		float snowTemp = TimeOfDay.Instance.GetSnowTemp(0f);
		float num2 = ((GameSettings.Instance.ActiveFloor == -1) ? 0f : (LowSfx.Evaluate(_currentZoom / 600f) * num));
		WinterWind.volume = Mathf.Lerp(WinterWind.volume, num2 * snowTemp, t);
		float num3 = DaySfx.Evaluate(((float)TimeOfDay.Instance.Hour + TimeOfDay.Instance.Minute / 60f) / 24f);
		BirdSound.volume = ((GameSettings.Instance.CliType == GameData.ClimateType.Warm) ? 0f : Mathf.Lerp(BirdSound.volume, (float)birdPlay * num2 * (1f - snowTemp) * 0.5f * num3, t));
		CricketSound.volume = Mathf.Lerp(CricketSound.volume, num2 * (1f - snowTemp) * 0.5f * (1f - num3), t);
		PipeSound.volume = Mathf.Lerp(PipeSound.volume, (GameSettings.Instance.ActiveFloor == -1) ? 0.75f : 0f, t);
		if (StopFollowButton.activeSelf != (Follow != null))
		{
			StopFollowButton.SetActive(Follow != null);
		}
		if (!GameSettings.FreezeGame || FlyMode)
		{
			if (InputController.GetKeyDown(InputController.Keys.ToggleCamera) || (GameSettings.FreezeGame && FlyMode))
			{
				Shader.SetGlobalVector("_DitherFocusPos", Vector4.zero);
				Shader.SetGlobalVector("_DitherCamPos", Vector4.zero);
				FlyMode = !FlyMode;
				RefreshFlyMode();
			}
			if (FlyMode)
			{
				_topDownFactor = 0f;
				FlyCam();
			}
			else
			{
				if (!SkraperGen.NeverTransparent && (!EnvironmentEditor.Instance.gameObject.activeSelf || EnvironmentEditor.Instance.CurrentType != EnvironmentEditor.EditorType.Skyscraper))
				{
					Shader.SetGlobalVector("_DitherFocusPos", base.transform.position + base.transform.forward.ReplaceY(0f).normalized * SkyscraperDitherOffset);
					Shader.SetGlobalVector("_DitherCamPos", mainCam.transform.position);
				}
				else
				{
					Shader.SetGlobalVector("_DitherFocusPos", Vector4.zero);
					Shader.SetGlobalVector("_DitherCamPos", Vector4.zero);
				}
				_topDownFactor = Mathf.Clamp01(_topDownFactor + (float)(TopDown ? 1 : (-1)) * Time.deltaTime * 5f);
				Fog.distanceFog = !TopDown;
				EvaluateTiltshift();
				Cursor.lockState = (FlyMode ? CursorLockMode.Locked : Options.CursorLock());
				Cursor.visible = !FlyMode;
				if (IsFollowing())
				{
					TopDown = false;
					Vector3 v = Follow.position;
					Actor component = Follow.GetComponent<Actor>();
					if (component != null)
					{
						v = component.ActualPosition;
					}
					MoveTo(v.FlattenVector3(), Mathf.FloorToInt((v.y + 0.1f) / 2f), true);
				}
				StandardCam();
			}
		}
		LastCamPos = mainCam.transform.position;
		LastListenerPos = Listener.transform.position;
	}

	private void EvaluateTiltshift()
	{
		float time = _currentZoom.MapRange(15f, 200f, 0f, 1f, true);
		TiltScript.blurArea = Mathf.Lerp(TiltArea.Evaluate(time) * ScreenUpscale, 0f, _topDownFactor);
	}

	private void OnFileSaved(int id, string filepath)
	{
		DoneSaving = true;
	}

	public void FlyCam()
	{
		Vector2 joystickAxis = InputController.GetJoystickAxis(0);
		Vector3 vector = new Vector3(Input.GetAxis("Mouse X") + joystickAxis.x * 0.5f, Input.GetAxis("Mouse Y") - joystickAxis.y * 0.5f, 0f);
		Target *= Quaternion.Euler((0f - vector.y) * Time.deltaTime * RotationSpeed * 10f, vector.x * Time.deltaTime * RotationSpeed * 10f, 0f);
		Target = Quaternion.Euler(Target.eulerAngles.x, Target.eulerAngles.y, 0f);
		mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation, Target, 0.25f);
		Vector3 zero = Vector3.zero;
		GameSettings.Instance.LODDirty = true;
		bool num = mainCam.transform.position.y >= 0f;
		if (FlyLockFloor)
		{
			joystickAxis = InputController.GetJoystickAxis(1);
			zero = (mainCam.transform.right * joystickAxis.x - mainCam.transform.forward * joystickAxis.y) * ScrollSpeed;
			if (InputController.GetKey(InputController.Keys.MoveUp, true))
			{
				zero += mainCam.transform.forward;
			}
			if (InputController.GetKey(InputController.Keys.MoveLeft, true))
			{
				zero -= mainCam.transform.right;
			}
			if (InputController.GetKey(InputController.Keys.MoveDown, true))
			{
				zero -= mainCam.transform.forward;
			}
			if (InputController.GetKey(InputController.Keys.MoveRight, true))
			{
				zero += mainCam.transform.right;
			}
			if (InputController.GetKeyDown(InputController.Keys.FloorUp))
			{
				FlyFloor++;
			}
			if (InputController.GetKeyDown(InputController.Keys.FloorDown))
			{
				FlyFloor = Mathf.Max(-1, FlyFloor - 1);
			}
			bool key = Input.GetKey(KeyCode.LeftShift);
			zero = zero.ReplaceY(0f).normalized * Time.deltaTime * ScrollSpeed / (key ? 2 : 8);
			Vector3 position = mainCam.transform.position;
			mainCam.transform.position = new Vector3(position.x + zero.x, Mathf.Lerp(position.y, (float)FlyFloor * 2f - 0.7f, Time.deltaTime * 10f), position.z + zero.z);
		}
		else
		{
			joystickAxis = InputController.GetJoystickAxis(1);
			zero = (Vector3.right * joystickAxis.x - Vector3.forward * joystickAxis.y) * ScrollSpeed;
			if (InputController.GetKey(InputController.Keys.MoveUp, true))
			{
				zero += Vector3.forward;
			}
			if (InputController.GetKey(InputController.Keys.MoveLeft, true))
			{
				zero += Vector3.left;
			}
			if (InputController.GetKey(InputController.Keys.MoveDown, true))
			{
				zero += Vector3.back;
			}
			if (InputController.GetKey(InputController.Keys.MoveRight, true))
			{
				zero += Vector3.right;
			}
			if (InputController.GetKey(InputController.Keys.FloorUp, true))
			{
				zero += Vector3.up;
			}
			if (InputController.GetKey(InputController.Keys.FloorDown, true))
			{
				zero += Vector3.down;
			}
			bool key2 = Input.GetKey(KeyCode.LeftShift);
			mainCam.transform.position = mainCam.transform.position + mainCam.transform.rotation * zero.normalized * Time.deltaTime * ScrollSpeed / (key2 ? 2 : 8);
		}
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			FlyFloor = Mathf.FloorToInt((mainCam.transform.position.y + 1f) / 2f);
			FlyLockFloor = !FlyLockFloor;
		}
		FOV = Mathf.Clamp(FOV - Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed * 0.5f, 10f, 120f);
		mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, FOV, 0.1f);
		mainCam.transform.position = new Vector3(Mathf.Clamp(mainCam.transform.position.x, 0f, 256f), Mathf.Clamp(mainCam.transform.position.y, -2f, 128f), Mathf.Clamp(mainCam.transform.position.z, 0f, 256f));
		if (num != mainCam.transform.position.y >= 0f)
		{
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
	}

	public bool IsFollowing()
	{
		if (Follow != null)
		{
			return Follow.gameObject.activeSelf;
		}
		return false;
	}

	public void StandardCam()
	{
		if (HUD.Instance.BuildMode && InputController.GetKeyDown(InputController.Keys.TopDown))
		{
			TopDown = !TopDown;
			Furniture.UpdateEdgeDetection();
		}
		bool flag = IsFollowing();
		if (!flag)
		{
			TouchCode();
		}
		float num = ScrollSpeed * mainCam.fieldOfView / 30f * Time.deltaTime;
		Vector2 joystickAxis = InputController.GetJoystickAxis(1);
		Vector3 vector = Vector3.right * joystickAxis.x - Vector3.forward * joystickAxis.y;
		vector = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f) * (num * vector);
		Vector3 movement = (flag ? Vector3.zero : vector);
		if (!flag)
		{
			if (InputController.GetKey(InputController.Keys.MoveUp))
			{
				GotoTarget = false;
				float f = base.transform.rotation.eulerAngles.y / 180f * (float)Math.PI;
				movement = new Vector3(movement.x + Mathf.Sin(f) * num, movement.y, movement.z + Mathf.Cos(f) * num);
			}
			if (InputController.GetKey(InputController.Keys.MoveDown))
			{
				GotoTarget = false;
				float f2 = base.transform.rotation.eulerAngles.y / 180f * (float)Math.PI;
				movement = new Vector3(movement.x - Mathf.Sin(f2) * num, movement.y, movement.z - Mathf.Cos(f2) * num);
			}
			if (InputController.GetKey(InputController.Keys.MoveLeft))
			{
				GotoTarget = false;
				float f3 = (base.transform.rotation.eulerAngles.y - 90f) / 180f * (float)Math.PI;
				movement = new Vector3(movement.x + Mathf.Sin(f3) * num, movement.y, movement.z + Mathf.Cos(f3) * num);
			}
			if (InputController.GetKey(InputController.Keys.MoveRight))
			{
				GotoTarget = false;
				float f4 = (base.transform.rotation.eulerAngles.y + 90f) / 180f * (float)Math.PI;
				movement = new Vector3(movement.x + Mathf.Sin(f4) * num, movement.y, movement.z + Mathf.Cos(f4) * num);
			}
		}
		if (GotoTarget)
		{
			if (Mathf.Approximately(base.transform.position.x, TargetPos.x) && Mathf.Approximately(base.transform.position.z, TargetPos.y))
			{
				GotoTarget = false;
			}
			else
			{
				GameSettings.Instance.LODDirty = true;
				base.transform.position = new Vector3(Mathf.Lerp(base.transform.position.x, TargetPos.x, Time.deltaTime * 8f), base.transform.position.y, Mathf.Lerp(base.transform.position.z, TargetPos.y, Time.deltaTime * 8f));
			}
		}
		if (!flag && Options.EdgeScroll)
		{
			EdgeScroll(ref movement, num);
		}
		movement += Momentum.ToVector3(0f);
		Momentum = (flag ? Vector2.zero : Vector2.Lerp(Momentum, Vector2.zero, Time.deltaTime * DragSlowdown));
		if (!flag && BuildController.Instance.CanChangeFloor())
		{
			if (InputController.GetKeyDown(InputController.Keys.FloorDown))
			{
				int activeFloor = GameSettings.Instance.ActiveFloor;
				GameSettings.Instance.ActiveFloor = Mathf.Max(-1, GameSettings.Instance.ActiveFloor - ((!RoadBuildCube.Instance.gameObject.activeSelf) ? 1 : 2));
				if ((BuildController.Instance.IsBuildingRoom() && BuildController.Instance.FenceMode) || RoadBuildCube.Instance.gameObject.activeSelf)
				{
					GameSettings.Instance.ActiveFloor = Mathf.Max(0, GameSettings.Instance.ActiveFloor);
				}
				else if (AtriumTool.Instance.gameObject.activeSelf)
				{
					GameSettings.Instance.ActiveFloor = Mathf.Clamp(GameSettings.Instance.ActiveFloor, 1, GameSettings.MaxFloor - 1);
				}
				UpdateFloorSound(activeFloor);
				Furniture.UpdateEdgeDetection();
				GameSettings.Instance.sRoomManager.ChangeFloor();
			}
			if (InputController.GetKeyDown(InputController.Keys.FloorUp))
			{
				int activeFloor2 = GameSettings.Instance.ActiveFloor;
				GameSettings.Instance.ActiveFloor = Mathf.Min(GameSettings.MaxFloor, GameSettings.Instance.ActiveFloor + ((!RoadBuildCube.Instance.gameObject.activeSelf) ? 1 : 2));
				if (RoadBuildCube.Instance.gameObject.activeSelf)
				{
					GameSettings.Instance.ActiveFloor = Mathf.Min((RoadManager.Floors - 1) * 2, GameSettings.Instance.ActiveFloor);
				}
				UpdateFloorSound(activeFloor2);
				Furniture.UpdateEdgeDetection();
				GameSettings.Instance.sRoomManager.ChangeFloor();
			}
		}
		if (GameSettings.Instance.ActiveFloor == -1)
		{
			UndergroundMesh.SetActive(true);
			GroundMesh.SetActive(false);
		}
		else
		{
			UndergroundMesh.SetActive(false);
			GroundMesh.SetActive(true);
		}
		float num2 = _currentZoom / 125f;
		float num3 = ((DevConsole.Console.isOpen || BuildController.Instance.AutoPlacePanel.activeSelf || EnvironmentEditor.DisableScroll() || CurveBuilder.DisableScroll() || GUICheck.OverGUI || SelectorController.Instance.rcPanel.IsCounting()) ? 0f : Input.GetAxis("Mouse ScrollWheel"));
		Vector2 vector2 = Vector2.zero;
		if (!flag && num3 != 0f)
		{
			vector2 = HUD.Instance.GetMouseProj();
		}
		Vector2 vector3 = Vector2.zero;
		if (InputController.GetKey(InputController.Keys.RotateCamera))
		{
			if (!InputController.GetKeyDown(InputController.Keys.RotateCamera))
			{
				vector3 = Input.mousePosition - lastPos;
				wasRotating = true;
				WindowManager.SetCursorOverride("Rotate");
			}
			lastPos = Input.mousePosition;
		}
		else if (wasRotating)
		{
			wasRotating = false;
			WindowManager.SetCursorOverride(null);
		}
		float num4 = (float)((InputController.GetKey(InputController.Keys.TurnLeft) ? 1 : 0) - (InputController.GetKey(InputController.Keys.TurnRight) ? 1 : 0)) * Time.deltaTime * 5f + vector3.x * 0.01f;
		float num5 = (float)((InputController.GetKey(InputController.Keys.TurnDown) ? 1 : 0) - (InputController.GetKey(InputController.Keys.TurnUp) ? 1 : 0)) * Time.deltaTime * 5f + vector3.y * 0.01f;
		joystickAxis = InputController.GetJoystickAxis(0);
		num4 -= joystickAxis.x * 0.2f;
		num5 += joystickAxis.y * 0.2f;
		GameSettings.Instance.LODDirty |= IsChanging(movement.x) || IsChanging(movement.y) || IsChanging(vector2.x) || IsChanging(vector2.y) || IsChanging(num5) || IsChanging(num4);
		base.transform.SetPositionAndRotation(new Vector3(Mathf.Clamp(base.transform.position.x + movement.x * num2 + vector2.x, 0f, 256f), Mathf.Lerp(base.transform.position.y, GameSettings.Instance.ActiveFloor * 2, 0.1f), Mathf.Clamp(base.transform.position.z + movement.z * num2 + vector2.y, 0f, 256f)), Quaternion.Euler(TopDown ? Mathf.Lerp(base.transform.rotation.eulerAngles.x, 90f, _topDownFactor) : Mathf.Clamp(base.transform.rotation.eulerAngles.x - num5 * RotationSpeed, 8f, 65f), base.transform.rotation.eulerAngles.y + num4 * RotationSpeed, 0f));
		if (num4 != 0f || num5 != 0f)
		{
			Furniture.UpdateEdgeDetection();
		}
		float num6 = (((InputController.GetKey(InputController.Keys.ZoomIn) ? Time.deltaTime : 0f) - (InputController.GetKey(InputController.Keys.ZoomOut) ? Time.deltaTime : 0f)) * 5f + num3) * ZoomSpeed * num2;
		GameSettings.Instance.LODDirty |= IsChanging(num6);
		_currentZoom -= num6;
		if (TopDown)
		{
			_currentZoom = Mathf.Clamp(_currentZoom, ZoomMin * 2f, ZoomMax / 2f);
		}
		else
		{
			_currentZoom = Mathf.Clamp(_currentZoom, ZoomMin, ZoomMax);
		}
		mainCam.transform.localPosition = new Vector3(mainCam.transform.localPosition.x, mainCam.transform.localPosition.y, Mathf.Lerp(mainCam.transform.localPosition.z, (0f - _currentZoom) * Mathf.Lerp(1f, 2f, _topDownFactor), 1f));
		if (num3 != 0f && !flag)
		{
			GotoTarget = false;
			GameSettings.Instance.LODDirty = true;
			base.transform.position += (vector2 - HUD.Instance.GetMouseProj()).ToVector3(0f);
		}
		if (!Mathf.Approximately(num6, 0f))
		{
			UpdatePostFX();
		}
		mainCam.fieldOfView = Mathf.Lerp(NormalFOV, TopDownFOV, _topDownFactor);
		if (!IsUsingTouch() && !flag)
		{
			if (isDragging)
			{
				Ray ray = SSAScript.ScreenPointToRay(Input.mousePosition);
				Plane plane = new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2));
				float enter = 0f;
				plane.Raycast(ray, out enter);
				Vector3 point = ray.GetPoint(enter);
				Vector3 vector4 = lastDragPos - point;
				LastPosMomentum = base.transform.position;
				GameSettings.Instance.LODDirty |= IsChanging(vector4.x) || IsChanging(vector4.y);
				base.transform.position = new Vector3(Mathf.Clamp(base.transform.position.x + vector4.x, 0f, 256f), base.transform.position.y, Mathf.Clamp(base.transform.position.z + vector4.z, 0f, 256f));
			}
			if (!GUICheck.OverGUI && InputController.GetKeyDown(InputController.Keys.DragCamera))
			{
				isDragging = true;
				GotoTarget = false;
				Momentum = Vector2.zero;
				Ray ray2 = SSAScript.ScreenPointToRay(Input.mousePosition);
				Plane plane2 = new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2));
				float enter2 = 0f;
				plane2.Raycast(ray2, out enter2);
				lastDragPos = ray2.GetPoint(enter2);
				LastPos = base.transform.position;
				WindowManager.SetCursorOverride("Move3D");
			}
		}
	}

	private bool IsChanging(float value)
	{
		if (!(value < -0.0001f))
		{
			return value > 0.0001f;
		}
		return true;
	}

	private bool IsUsingTouch()
	{
		return Input.touchCount > 1;
	}

	private Vector2 GetTouchPos(int i)
	{
		return Input.GetTouch(i).position;
	}

	private void TouchCode()
	{
		if (IsUsingTouch())
		{
			if (_usingTouch)
			{
				Vector2 touchPos = GetTouchPos(0);
				Vector2 touchPos2 = GetTouchPos(1);
				float num = touchPos2.Atan2(touchPos) - _touch2.Atan2(_touch1);
				Vector3 eulerAngles = base.transform.rotation.eulerAngles;
				base.transform.rotation = Quaternion.Euler(eulerAngles.x, _touchRot + num, eulerAngles.z);
				Vector2 vector = touchPos2 - _touch2;
				Vector2 vector2 = touchPos - _touch1;
				Vector3 vector3 = base.transform.rotation * ((vector + vector2) * 0.5f * Vector2.Dot(vector2.normalized, vector.normalized)).ToVector3(0f) * (_currentZoom / (float)Screen.width);
				base.transform.position = new Vector3(_touchPos.x - vector3.x, base.transform.position.y, _touchPos.y - vector3.z);
				float num2 = (_touch1 - _touch2).magnitude - (touchPos - touchPos2).magnitude;
				num2 = num2 / (float)Screen.width * (ZoomMax - ZoomMin);
				_currentZoom = _touchZoom + num2;
			}
			else
			{
				_touch1 = GetTouchPos(0);
				_touch2 = GetTouchPos(1);
				_touchPos = base.transform.position.FlattenVector3();
				_touchZoom = _currentZoom;
				_touchRot = base.transform.rotation.eulerAngles.y;
				_usingTouch = true;
			}
		}
		else
		{
			_usingTouch = false;
		}
	}

	public void UpdatePostFX()
	{
		float time = _currentZoom.MapRange(15f, 200f, 0f, 1f, true);
		SSAO.Intensity = AmbIntensity.Evaluate(time);
		SSAO.Radius = AmbRadius.Evaluate(time);
	}

	public void EdgeScroll(ref Vector3 movement, float TScrollSpeed)
	{
		float num = base.transform.rotation.eulerAngles.y / 180f * (float)Math.PI;
		float value = ((Input.mousePosition.x >= (float)(Screen.width - 2)) ? 1f : 0f) - ((Input.mousePosition.x <= 2f) ? 1f : 0f);
		value = Mathf.Clamp(value, -1f, 1f);
		float value2 = ((Input.mousePosition.y >= (float)(Screen.height - 2)) ? 1f : 0f) - ((Input.mousePosition.y <= 2f) ? 1f : 0f);
		value2 = Mathf.Clamp(value2, -1f, 1f);
		if (value2 != 0f || value != 0f)
		{
			GotoTarget = false;
		}
		movement = new Vector3(movement.x + Mathf.Sin(num) * TScrollSpeed * value2 + Mathf.Sin(num + (float)Math.PI / 2f) * TScrollSpeed * value, movement.y, movement.z + Mathf.Cos(num) * TScrollSpeed * value2 + Mathf.Cos(num + (float)Math.PI / 2f) * TScrollSpeed * value);
	}

	public void ChangeFloor(int amount)
	{
		if (BuildController.Instance.CanChangeFloor())
		{
			int activeFloor = GameSettings.Instance.ActiveFloor;
			GameSettings.Instance.ActiveFloor = Mathf.Clamp(GameSettings.Instance.ActiveFloor + amount, (!BuildController.Instance.IsBuildingRoom() || !BuildController.Instance.FenceMode) ? (-1) : 0, GameSettings.MaxFloor);
			UpdateFloorSound(activeFloor);
			Furniture.UpdateEdgeDetection();
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
	}

	public void UpdateFloorSound(int last)
	{
		if (last != GameSettings.Instance.ActiveFloor)
		{
			float pitch = 1f + Mathf.Clamp((float)GameSettings.Instance.ActiveFloor / 50f, -0.5f, 0.5f);
			UISoundFX.PlaySFX((last < GameSettings.Instance.ActiveFloor) ? "FloorUp" : "FloorDown", pitch);
		}
	}

	public void Deserialize(WriteDictionary input)
	{
		FlyMode = (bool)input["FlyMode"];
		GameSettings.Instance.ActiveFloor = (int)input["ActiveFloor"];
		GameSettings.Instance.UpdateCutoffShaders();
		base.transform.SetPositionAndRotation(input.Get<SVector3>("Position").ZeroNaN(), (SVector3)input["Rotation"]);
		mainCam.transform.SetPositionAndRotation(input.Get<SVector3>("CamPosition").ZeroNaN(), (SVector3)input["CamRotation"]);
		_currentZoom = input.Get("CamZoom", _currentZoom);
		UpdatePostFX();
	}

	public WriteDictionary Serialize()
	{
		WriteDictionary writeDictionary = new WriteDictionary("Camera");
		writeDictionary["FlyMode"] = FlyMode;
		writeDictionary["ActiveFloor"] = GameSettings.Instance.ActiveFloor;
		writeDictionary["Position"] = (SVector3)base.transform.position;
		writeDictionary["Rotation"] = (SVector3)base.transform.rotation;
		writeDictionary["CamPosition"] = (SVector3)mainCam.transform.position;
		writeDictionary["CamRotation"] = (SVector3)mainCam.transform.rotation;
		writeDictionary["CamZoom"] = _currentZoom;
		return writeDictionary;
	}

	public float GetZoomLevel()
	{
		return _currentZoom.MapRange(ZoomMin, ZoomMax, 0f, 1f);
	}

	public void MoveTo(Vector2 p, int floor, bool force = false)
	{
		if (floor <= GameSettings.MaxFloor || force)
		{
			if (floor > GameSettings.MaxFloor && force)
			{
				floor = GameSettings.MaxFloor;
			}
			if (floor != GameSettings.Instance.ActiveFloor)
			{
				GameSettings.Instance.ActiveFloor = floor;
				Furniture.UpdateEdgeDetection();
				GameSettings.Instance.sRoomManager.ChangeFloor();
			}
			GotoPos(p);
		}
	}
}
