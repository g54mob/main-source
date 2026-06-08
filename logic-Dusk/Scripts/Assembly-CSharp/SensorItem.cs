using System;
using System.Collections.Generic;
using UnityEngine;

public class SensorItem : DropableItem, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation, IUpdateCameraView
{
	private const float SCALE_SPEED_SLOW = 2.5f;

	private const float SCALE_SPEED_FAST = 5f;

	public Material scanMtl;

	public Material detectMtl;

	public float LineThicknessDV = 0.001f;

	public float LineThicknessSV = 0.01f;

	public AudioSource sensorSound;

	private EnemyManager enemyManager;

	private bool enemiesDetected;

	private Color _rectangleColorSlow;

	private Color _rectangleColorFast;

	private GameObject _sensorRectangle;

	private GameObject _horizontalLineTop;

	private GameObject _horizontalLineBottom;

	private GameObject _verticalLineLeft;

	private GameObject _verticalLineRight;

	private float _scaleSpeed;

	private Vector3 _targetScale;

	private Vector3 _roomMinCoordinate;

	private Vector3 _roomMaxCoordinate;

	private float _roomWidth;

	private float _lineHeightHalf;

	private float _lineWidthHalf;

	private float _lineWidthHalfDV;

	private float _lineWidthHalfSV;

	private Mesh _rectangleMesh;

	private bool _shouldUpdateThisFrame = true;

	private float _deltaElapsedCumulative;

	private float lineScale = 0.01f;

	private bool _isDockingBay;

	private BoardingShip _boardingShip;

	private bool _isRotated;

	private float _currentHitPoints;

	private bool _isDead;

	private bool hasBeenAttacked;

	private bool gameWasPaused;

	private int lastKnownState;

	private ColorBlinkManager _blinkManager = new ColorBlinkManager();

	private bool _linesWereHidden;

	private Vector3 posVec = Vector3.zero;

	private Vector3 posDeltaVec = Vector3.zero;

	private Vector3 horizScale = Vector3.zero;

	private Vector3 vertScale = Vector3.zero;

	private Vector3 horizTopPos = Vector3.zero;

	private Vector3 horizBottomPos = Vector3.zero;

	private Vector3 vertLeftPos = Vector3.zero;

	private Vector3 vertRightPos = Vector3.zero;

	private Vector3 startScaleMinVec = new Vector3(0f, 0.1f, 0f);

	private Vector3 startScaleMaxVec = Vector3.zero;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override DropItemType DropType
	{
		get
		{
			return DropItemType.Sensor;
		}
	}

	public Room CurrentRoom { get; set; }

	public Vector3 Position
	{
		get
		{
			if (base.transform != null)
			{
				return base.transform.position;
			}
			return Vector3.zero;
		}
	}

	public Collider ObjectCollider
	{
		get
		{
			return GetComponent<Collider>();
		}
	}

	public bool CanCollide
	{
		get
		{
			return true;
		}
	}

	public List<ICombatTarget> SubordinateTargets { get; set; }

	public bool IsHidden
	{
		get
		{
			return false;
		}
	}

	public Corridor CurrentCorridor { get; set; }

	public float CurrentHitPoints
	{
		get
		{
			return _currentHitPoints;
		}
	}

	public float TotalHitpoints
	{
		get
		{
			return 100f;
		}
	}

	public float TimeStunned { get; private set; }

	public bool IsDead
	{
		get
		{
			return _isDead;
		}
	}

	public bool IsStunned { get; private set; }

	public Vector3 StunPosition { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiCurrentHitpoints != CurrentHitPoints)
			{
				_guiString = " (" + Math.Round(CurrentHitPoints, 0) + ") ";
				guiCurrentHitpoints = CurrentHitPoints;
			}
			return _guiString;
		}
	}

	public void Initialize(Room room)
	{
		CurrentRoom = room;
		GetComponent<Renderer>().enabled = false;
		if (room is BoardingShip)
		{
			_isDockingBay = true;
			_boardingShip = (BoardingShip)room;
		}
	}

	public override void Start()
	{
		base.Start();
		_currentHitPoints = TotalHitpoints;
		enemyManager = EnemyManager.Instance;
		GetComponent<Renderer>().material = scanMtl;
		DungeonManager instance = DungeonManager.Instance;
		_sensorRectangle = UnityEngine.Object.Instantiate(ResourceManager.SensorRectanglePrefab);
		_sensorRectangle.GetComponent<Renderer>().enabled = false;
		_horizontalLineTop = ResourceManager.GetNextSensorPrefab();
		_horizontalLineBottom = ResourceManager.GetNextSensorPrefab();
		_verticalLineLeft = ResourceManager.GetNextSensorPrefab();
		_verticalLineRight = ResourceManager.GetNextSensorPrefab();
		_horizontalLineTop.transform.localScale = new Vector3(LineThicknessSV, 0.1f, LineThicknessSV);
		_horizontalLineBottom.transform.localScale = new Vector3(LineThicknessSV, 0.1f, LineThicknessSV);
		_verticalLineLeft.transform.localScale = new Vector3(LineThicknessSV, LineThicknessSV, LineThicknessSV);
		_verticalLineRight.transform.localScale = new Vector3(LineThicknessSV, LineThicknessSV, LineThicknessSV);
		Renderer component = _horizontalLineTop.GetComponent<Renderer>();
		bool flag = true;
		_verticalLineRight.GetComponent<Renderer>().enabled = flag;
		flag = flag;
		_verticalLineLeft.GetComponent<Renderer>().enabled = flag;
		flag = flag;
		_horizontalLineBottom.GetComponent<Renderer>().enabled = flag;
		component.enabled = flag;
		_rectangleMesh = _sensorRectangle.GetComponent<MeshFilter>().mesh;
		CalculateSpeedAndBounds();
		UpdateCameraView();
		_shouldUpdateThisFrame = true;
		_deltaElapsedCumulative = 0f;
		SetInactive();
		sensorSound.volume = GameAudio.RemoteVolume * 1f;
		if (!base.Deactivated && !IsDead && GlobalSettings.cameraMode == CameraMode.Drone)
		{
			sensorSound.Play();
		}
	}

	protected override void OnDestroy()
	{
		scanMtl = null;
		detectMtl = null;
		UnityEngine.Object.Destroy(_sensorRectangle);
		UnityEngine.Object.Destroy(_horizontalLineTop);
		UnityEngine.Object.Destroy(_horizontalLineBottom);
		UnityEngine.Object.Destroy(_verticalLineLeft);
		UnityEngine.Object.Destroy(_verticalLineRight);
		_sensorRectangle = null;
		_horizontalLineTop = null;
		_horizontalLineBottom = null;
		_verticalLineLeft = null;
		_verticalLineRight = null;
		base.OnDestroy();
	}

	protected override void Update()
	{
		if (IsDead)
		{
			return;
		}
		bool flag = _isDockingBay && _boardingShip.IsRedockingShip;
		if (!GlobalSettings.IsGamePaused && !flag)
		{
			bool flag2 = false;
			if (_linesWereHidden)
			{
				_linesWereHidden = false;
				enemiesDetected = false;
				flag2 = true;
				Renderer component = _horizontalLineTop.GetComponent<Renderer>();
				bool flag3 = true;
				_verticalLineRight.GetComponent<Renderer>().enabled = flag3;
				flag3 = flag3;
				_verticalLineLeft.GetComponent<Renderer>().enabled = flag3;
				flag3 = flag3;
				_horizontalLineBottom.GetComponent<Renderer>().enabled = flag3;
				component.enabled = flag3;
				CalculateSpeedAndBounds();
				SetInactive();
			}
			bool flag4 = enemiesDetected;
			enemiesDetected = false;
			if (CurrentRoom.knownEnemiesList != null)
			{
				int count = CurrentRoom.knownEnemiesList.Count;
				for (int i = 0; i < count; i++)
				{
					BaseEnemy baseEnemy = CurrentRoom.knownEnemiesList[i];
					if (!baseEnemy.IsDead)
					{
						enemiesDetected = true;
					}
				}
			}
			if (enemiesDetected != flag4)
			{
				if (enemiesDetected)
				{
					if (!flag2 && CurrentRoom != null)
					{
						SystemMessageManager.ShowSystemMessage("Sensor Triggered: " + CurrentRoom.Label, ConsoleMessageType.TriggerActivatedWarning, SystemMessageImageType.SensorNotify);
					}
					GetComponent<Renderer>().material = detectMtl;
					SetActive();
					DungeonManager.Instance.RandomBarkOnMiscSoundIfOwned();
				}
				else
				{
					if (!flag2 && CurrentRoom != null)
					{
						SystemMessageManager.ShowSystemMessage("Sensor Un-Triggered" + CurrentRoom.Label, ConsoleMessageType.TriggerDeactivatedWarning, SystemMessageImageType.SensorNotify);
					}
					GetComponent<Renderer>().material = scanMtl;
					SetInactive();
				}
			}
			if (!base.Deactivated && !base.Destroyed)
			{
				AnimateSensorRectangle();
			}
			if (!base.Deactivated && !IsDead && GlobalSettings.cameraMode == CameraMode.Drone && !sensorSound.isPlaying)
			{
				sensorSound.Play();
			}
			if (sensorSound.isPlaying)
			{
				sensorSound.volume = GameAudio.RemoteVolume * 1f;
			}
		}
		else if (flag && !_linesWereHidden)
		{
			_linesWereHidden = true;
			Renderer component2 = _horizontalLineTop.GetComponent<Renderer>();
			bool flag3 = false;
			_verticalLineRight.GetComponent<Renderer>().enabled = flag3;
			flag3 = flag3;
			_verticalLineLeft.GetComponent<Renderer>().enabled = flag3;
			flag3 = flag3;
			_horizontalLineBottom.GetComponent<Renderer>().enabled = flag3;
			component2.enabled = flag3;
		}
		if (!GlobalSettings.IsGamePaused)
		{
			if (_blinkManager.IsActive)
			{
				Color color = _blinkManager.Update(Time.deltaTime);
				GetComponent<Renderer>().material.color = color;
				if (dvOverlayObject != null)
				{
					dvOverlayObject.GetComponent<Renderer>().material.color = color;
				}
				if (svOverlayObject != null)
				{
					svOverlayObject.GetComponent<Renderer>().material.color = color;
				}
				if (IsDead)
				{
					SetDead();
				}
			}
			if (gameWasPaused)
			{
				bool flag5 = GameSaveFile.Get("O_CB", false);
				_rectangleColorSlow = (flag5 ? CurrentRoom.AreaSensorVisual.ColorBlindDeactivatedColor : CurrentRoom.AreaSensorVisual.DeactivatedColor);
				_rectangleColorFast = (flag5 ? CurrentRoom.AreaSensorVisual.ColorBlindActivatedColor : CurrentRoom.AreaSensorVisual.ActivatedColor);
				switch (lastKnownState)
				{
				case 0:
				{
					Material material2 = _horizontalLineTop.GetComponent<Renderer>().material;
					Color rectangleColorFast = _rectangleColorSlow;
					_verticalLineRight.GetComponent<Renderer>().material.color = rectangleColorFast;
					rectangleColorFast = rectangleColorFast;
					_verticalLineLeft.GetComponent<Renderer>().material.color = rectangleColorFast;
					rectangleColorFast = rectangleColorFast;
					_horizontalLineBottom.GetComponent<Renderer>().material.color = rectangleColorFast;
					material2.color = rectangleColorFast;
					break;
				}
				case 1:
				{
					Material material = _horizontalLineTop.GetComponent<Renderer>().material;
					Color rectangleColorFast = _rectangleColorFast;
					_verticalLineRight.GetComponent<Renderer>().material.color = rectangleColorFast;
					rectangleColorFast = rectangleColorFast;
					_verticalLineLeft.GetComponent<Renderer>().material.color = rectangleColorFast;
					rectangleColorFast = rectangleColorFast;
					_horizontalLineBottom.GetComponent<Renderer>().material.color = rectangleColorFast;
					material.color = rectangleColorFast;
					break;
				}
				}
			}
		}
		else if (sensorSound.isPlaying)
		{
			sensorSound.Pause();
		}
		gameWasPaused = GlobalSettings.IsGamePaused;
		base.Update();
	}

	private void AnimateSensorRectangle()
	{
		if (!_shouldUpdateThisFrame && !base.IsActive)
		{
			_deltaElapsedCumulative += Time.deltaTime;
			_shouldUpdateThisFrame = true;
			return;
		}
		float num = _deltaElapsedCumulative + Time.deltaTime;
		_shouldUpdateThisFrame = false;
		_deltaElapsedCumulative = 0f;
		Transform transform = _sensorRectangle.transform;
		transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, _scaleSpeed * num);
		float z = transform.position.z;
		posVec = base.transform.position;
		posVec.z = z;
		transform.position = posVec;
		Vector3 vector = transform.TransformPoint(_rectangleMesh.bounds.max);
		Vector3 vector2 = transform.TransformPoint(_rectangleMesh.bounds.min);
		if (_isRotated)
		{
			float x = vector.x;
			vector.x = vector2.x;
			vector2.x = x;
		}
		float num2 = Vector2.Distance(new Vector2(vector2.x, 0f), new Vector2(vector.x, 0f));
		float num3 = Vector2.Distance(new Vector2(vector2.y, 0f), new Vector2(vector.y, 0f));
		float num4 = 0f;
		float num5 = 0f;
		if (!_isRotated)
		{
			if (vector.y < _roomMinCoordinate.y)
			{
				num4 = _roomMinCoordinate.y - vector.y;
			}
			else if (vector2.y > _roomMaxCoordinate.y)
			{
				num4 = _roomMaxCoordinate.y - vector2.y;
			}
			if (vector.x < _roomMinCoordinate.x)
			{
				num5 = _roomMinCoordinate.x - vector.x;
			}
			else if (vector2.x > _roomMaxCoordinate.x)
			{
				num5 = _roomMaxCoordinate.x - vector2.x;
			}
		}
		else
		{
			if (vector.y < _roomMinCoordinate.y)
			{
				num4 = _roomMinCoordinate.y - vector.y;
			}
			else if (vector2.y > _roomMaxCoordinate.y)
			{
				num4 = _roomMaxCoordinate.y - vector2.y;
			}
			if (vector.x > _roomMinCoordinate.x)
			{
				num5 = _roomMinCoordinate.x - vector.x;
			}
			else if (vector2.x < _roomMaxCoordinate.x)
			{
				num5 = _roomMaxCoordinate.x - vector2.x;
			}
		}
		if (num5 != 0f || num4 != 0f)
		{
			posDeltaVec = transform.position;
			posDeltaVec.x += num5;
			posDeltaVec.y += num4;
			transform.position = posDeltaVec;
		}
		horizScale.x = transform.localScale.x;
		horizScale.y = 0.1f;
		horizScale.z = lineScale;
		vertScale.x = lineScale;
		vertScale.y = lineScale;
		vertScale.z = transform.localScale.z;
		_horizontalLineTop.transform.localScale = horizScale;
		_horizontalLineBottom.transform.localScale = horizScale;
		_verticalLineLeft.transform.localScale = vertScale;
		_verticalLineRight.transform.localScale = vertScale;
		horizTopPos = transform.position;
		horizBottomPos = transform.position;
		vertLeftPos = transform.position;
		vertRightPos = transform.position;
		float num6 = num3 / 2f;
		float num7 = num2 / 2f;
		horizTopPos.y += num6 - _lineHeightHalf;
		horizBottomPos.y += 0f - num6 + _lineHeightHalf;
		vertLeftPos.x += 0f - num7 + _lineWidthHalf;
		vertRightPos.x += num7 - _lineWidthHalf;
		_horizontalLineTop.transform.position = horizTopPos;
		_horizontalLineBottom.transform.position = horizBottomPos;
		_verticalLineLeft.transform.position = vertLeftPos;
		_verticalLineRight.transform.position = vertRightPos;
		if (!base.IsActive && (double)num2 >= (double)_roomWidth - 0.1)
		{
			StartScalingOutwards();
		}
		else if (base.IsActive && (double)num2 <= 0.1)
		{
			StartScalingInwards();
		}
	}

	public override void UpdateCameraView()
	{
		GetComponent<Renderer>().enabled = false;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			lineScale = LineThicknessDV;
			_lineWidthHalf = _lineWidthHalfDV;
			_lineHeightHalf = _lineWidthHalfDV;
			if (!base.Deactivated && !IsDead)
			{
				sensorSound.Play();
			}
		}
		else
		{
			lineScale = LineThicknessSV;
			_lineWidthHalf = _lineWidthHalfSV;
			_lineHeightHalf = _lineWidthHalfSV;
			if (sensorSound.isPlaying)
			{
				sensorSound.Pause();
			}
		}
	}

	public override void SetDeactivated()
	{
		base.SetDeactivated();
		if (_horizontalLineTop != null)
		{
			_horizontalLineTop.GetComponent<Renderer>().enabled = false;
		}
		if (_horizontalLineBottom != null)
		{
			_horizontalLineBottom.GetComponent<Renderer>().enabled = false;
		}
		if (_verticalLineLeft != null)
		{
			_verticalLineLeft.GetComponent<Renderer>().enabled = false;
		}
		if (_verticalLineRight != null)
		{
			_verticalLineRight.GetComponent<Renderer>().enabled = false;
		}
		_horizontalLineTop = null;
		_horizontalLineBottom = null;
		_verticalLineLeft = null;
		_verticalLineRight = null;
		if (sensorSound != null && sensorSound.isPlaying)
		{
			sensorSound.Stop();
		}
	}

	protected override void SetActive()
	{
		base.SetActive();
		CalculateSpeedAndBounds();
		StartScalingInwards();
	}

	protected override void SetInactive()
	{
		base.SetInactive();
		StartScalingOutwards();
	}

	private void CalculateSpeedAndBounds()
	{
		if (!(CurrentRoom == null))
		{
			_isRotated = CurrentRoom.transform.rotation.w >= 0.65f && CurrentRoom.transform.rotation.w <= 0.75f;
			Mesh mesh = _horizontalLineBottom.GetComponent<MeshFilter>().mesh;
			Vector3 vector = _horizontalLineBottom.transform.TransformPoint(mesh.bounds.max);
			Vector3 vector2 = _horizontalLineBottom.transform.TransformPoint(mesh.bounds.min);
			float num = Vector2.Distance(new Vector2(vector.y, 0f), new Vector2(vector2.y, 0f));
			Mesh mesh2 = _verticalLineLeft.GetComponent<MeshFilter>().mesh;
			Vector3 vector3 = _verticalLineLeft.transform.TransformPoint(mesh2.bounds.max);
			Vector3 vector4 = _verticalLineLeft.transform.TransformPoint(mesh2.bounds.min);
			float num2 = Vector2.Distance(new Vector2(vector3.x, 0f), new Vector2(vector4.x, 0f));
			_lineHeightHalf = num / 2f;
			_lineWidthHalf = (_lineWidthHalfSV = num2 / 2f);
			_lineWidthHalfDV *= Mathf.Abs(LineThicknessSV - LineThicknessSV);
			Mesh mesh3 = CurrentRoom.GetComponent<MeshFilter>().mesh;
			_roomMinCoordinate = CurrentRoom.transform.TransformPoint(mesh3.bounds.min);
			_roomMaxCoordinate = CurrentRoom.transform.TransformPoint(mesh3.bounds.max);
			_roomWidth = Vector2.Distance(new Vector2(_roomMinCoordinate.x, 0f), new Vector2(_roomMaxCoordinate.x, 0f));
			bool flag = GameSaveFile.Get("O_CB", false);
			_rectangleColorSlow = (flag ? CurrentRoom.AreaSensorVisual.ColorBlindDeactivatedColor : CurrentRoom.AreaSensorVisual.DeactivatedColor);
			_rectangleColorFast = (flag ? CurrentRoom.AreaSensorVisual.ColorBlindActivatedColor : CurrentRoom.AreaSensorVisual.ActivatedColor);
		}
	}

	private void StartScalingOutwards()
	{
		if (!(CurrentRoom == null))
		{
			float z = _sensorRectangle.transform.position.z;
			posVec = base.transform.position;
			posVec.z = z;
			_sensorRectangle.transform.position = posVec;
			_sensorRectangle.transform.localScale = startScaleMinVec;
			if (_horizontalLineTop.GetComponent<Renderer>().material.color != _rectangleColorSlow)
			{
				Material material = _horizontalLineTop.GetComponent<Renderer>().material;
				Color rectangleColorSlow = _rectangleColorSlow;
				_verticalLineRight.GetComponent<Renderer>().material.color = rectangleColorSlow;
				rectangleColorSlow = rectangleColorSlow;
				_verticalLineLeft.GetComponent<Renderer>().material.color = rectangleColorSlow;
				rectangleColorSlow = rectangleColorSlow;
				_horizontalLineBottom.GetComponent<Renderer>().material.color = rectangleColorSlow;
				material.color = rectangleColorSlow;
				lastKnownState = 0;
			}
			float num;
			float num2;
			if (_isRotated)
			{
				num = CurrentRoom.transform.localScale.y;
				num2 = CurrentRoom.transform.localScale.x;
			}
			else
			{
				num = CurrentRoom.transform.localScale.x;
				num2 = CurrentRoom.transform.localScale.y;
			}
			_targetScale.x = num / 10f;
			_targetScale.y = 0.1f;
			_targetScale.z = num2 / 10f;
			_scaleSpeed = 2.5f;
			_shouldUpdateThisFrame = true;
			_deltaElapsedCumulative = 0f;
		}
	}

	private void StartScalingInwards()
	{
		if (!(CurrentRoom == null))
		{
			float z = _sensorRectangle.transform.position.z;
			posVec = CurrentRoom.transform.position;
			posVec.z = z;
			_sensorRectangle.transform.position = posVec;
			float num;
			float num2;
			if (_isRotated)
			{
				num = CurrentRoom.transform.localScale.y;
				num2 = CurrentRoom.transform.localScale.x;
			}
			else
			{
				num = CurrentRoom.transform.localScale.x;
				num2 = CurrentRoom.transform.localScale.y;
			}
			startScaleMaxVec = CurrentRoom.transform.localScale;
			startScaleMaxVec.x = num / 10f;
			startScaleMaxVec.y = 0.1f;
			startScaleMaxVec.z = num2 / 10f;
			_sensorRectangle.transform.localScale = startScaleMaxVec;
			if (_horizontalLineTop.GetComponent<Renderer>().material.color != _rectangleColorFast)
			{
				Material material = _horizontalLineTop.GetComponent<Renderer>().material;
				Color rectangleColorFast = _rectangleColorFast;
				_verticalLineRight.GetComponent<Renderer>().material.color = rectangleColorFast;
				rectangleColorFast = rectangleColorFast;
				_verticalLineLeft.GetComponent<Renderer>().material.color = rectangleColorFast;
				rectangleColorFast = rectangleColorFast;
				_horizontalLineBottom.GetComponent<Renderer>().material.color = rectangleColorFast;
				material.color = rectangleColorFast;
				lastKnownState = 1;
			}
			_scaleSpeed = 5f;
			_targetScale = startScaleMinVec;
			_shouldUpdateThisFrame = true;
			_deltaElapsedCumulative = 0f;
		}
	}

	public override void Vaporize()
	{
		KillSensorExtras();
		base.Vaporize();
	}

	public void Stun(float durationMin, float durationMax)
	{
	}

	public void ClearStun()
	{
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (!IsDead)
		{
			if (attacker != null && !hasBeenAttacked)
			{
				SystemMessageManager.ShowSystemMessage("Sensor attacked in Room " + CurrentRoom.Label, ConsoleMessageType.Warning);
				hasBeenAttacked = true;
			}
			_blinkManager.Start(ActiveColor, DamageColor, 0.2f, 2);
			_currentHitPoints -= damage;
			if (_currentHitPoints <= 0f)
			{
				_currentHitPoints = 0f;
				_isDead = true;
				base.Destroyed = true;
				SetDead();
				KillSensorExtras();
			}
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}

	private void KillSensorExtras()
	{
		if (_horizontalLineTop != null)
		{
			UnityEngine.Object.Destroy(_horizontalLineTop);
		}
		if (_horizontalLineBottom != null)
		{
			UnityEngine.Object.Destroy(_horizontalLineBottom);
		}
		if (_verticalLineLeft != null)
		{
			UnityEngine.Object.Destroy(_verticalLineLeft);
		}
		if (_verticalLineRight != null)
		{
			UnityEngine.Object.Destroy(_verticalLineRight);
		}
		_horizontalLineTop = null;
		_horizontalLineBottom = null;
		_verticalLineLeft = null;
		_verticalLineRight = null;
		CurrentRoom = null;
	}
}
