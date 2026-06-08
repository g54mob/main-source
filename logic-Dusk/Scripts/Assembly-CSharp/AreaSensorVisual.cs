using UnityEngine;

public class AreaSensorVisual : MonoBehaviour
{
	private const float TIME_FOR_LINE_SWEEP_SLOW = 2f;

	private const float TIME_FOR_LINE_SWEEP_INCONCLUSIVE = 1f;

	private const float TIME_FOR_LINE_SWEEP_FAST = 0.5f;

	public Color DeactivatedColor;

	public Color ActivatedColor;

	public Color InconclusiveColor = Color.yellow;

	public Color ColorBlindDeactivatedColor;

	public Color ColorBlindActivatedColor;

	public Color ColorBlindInconclusiveColor = Color.yellow;

	private GameObject _horizontalLine;

	private GameObject _verticalLine;

	private Room _myRoom;

	private int _enabledReferenceCount;

	private float _horizontalLineVelocity;

	private float _verticalLineVelocity;

	private float _horizontalInconclusiveSpeed;

	private float _verticalInconclusiveSpeed;

	private float _horizontalSlowSpeed;

	private float _verticalSlowSpeed;

	private float _horizontalFastSpeed;

	private float _verticalFastSpeed;

	private EnemyManager _enemyManager;

	private bool _enemiesDetected;

	private Vector3 _roomMinCoordinate;

	private Vector3 _roomMaxCoordinate;

	private bool _shouldUpdateThisFrame = true;

	private float _deltaElapsedCumulative;

	private bool distanceRestriction;

	private float distance;

	private Vector3 distanceOriginPoint = Vector3.zero;

	private bool gameWasPaused;

	private int lastKnownState;

	private Material _horizontalLineMat;

	private Material _verticalLineMat;

	public bool IsEnabled
	{
		get
		{
			return _enabledReferenceCount > 0;
		}
	}

	public bool EnemiesDetected
	{
		get
		{
			return _enemiesDetected;
		}
	}

	public bool IsSetAsInconcolusive { get; private set; }

	private void Start()
	{
		DungeonManager instance = DungeonManager.Instance;
		if (instance != null)
		{
			_horizontalLine = ResourceManager.GetNextSensorPrefab();
			_verticalLine = ResourceManager.GetNextSensorPrefab();
			_horizontalLine.SetActive(false);
			_verticalLine.SetActive(false);
		}
		else if (!GlobalSettings.IsGameEditor)
		{
			Debug.LogWarning("NOT initializing AreaSensorVisual properly");
		}
		_enemyManager = EnemyManager.Instance;
	}

	public void FirstTimeInitialize(Room room)
	{
		_myRoom = room;
	}

	public void Enable(float distance, Vector3 distanceOriginPoint)
	{
		distanceRestriction = true;
		this.distance = distance;
		this.distanceOriginPoint = distanceOriginPoint;
		Enable();
	}

	public void Enable()
	{
		Enable(false);
	}

	public void OnDestroy()
	{
		Object.DestroyImmediate(_verticalLineMat);
		Object.DestroyImmediate(_horizontalLineMat);
	}

	public void Enable(bool asInconclusive)
	{
		if (!asInconclusive)
		{
			lastKnownState = 0;
		}
		else
		{
			lastKnownState = 2;
		}
		IsSetAsInconcolusive = asInconclusive;
		if (_enabledReferenceCount == 0)
		{
			bool flag = GameSaveFile.Get("O_CB", false);
			bool flag2 = _myRoom.transform.rotation.w >= 0.65f && _myRoom.transform.rotation.w <= 0.75f;
			CalculateSpeedAndBounds();
			float num;
			float num2;
			if (!flag2)
			{
				num = _myRoom.transform.localScale.x;
				num2 = _myRoom.transform.localScale.y;
			}
			else
			{
				num = _myRoom.transform.localScale.y;
				num2 = _myRoom.transform.localScale.x;
			}
			_horizontalLine.SetActive(true);
			_verticalLine.SetActive(true);
			if (!_horizontalLineMat)
			{
				_horizontalLineMat = _horizontalLine.GetComponent<Renderer>().material;
			}
			if (!_verticalLineMat)
			{
				_verticalLineMat = _verticalLine.GetComponent<Renderer>().material;
			}
			_horizontalLine.GetComponent<Renderer>().enabled = true;
			_horizontalLine.transform.position = new Vector3(_myRoom.transform.position.x, _myRoom.transform.position.y, -0.2f);
			_horizontalLine.transform.localScale = new Vector3(num / 10f, 0.1f, 0.01f);
			if (!asInconclusive)
			{
				_horizontalLineMat.color = (flag ? ColorBlindDeactivatedColor : DeactivatedColor);
			}
			else
			{
				_horizontalLineMat.color = (flag ? ColorBlindInconclusiveColor : InconclusiveColor);
			}
			if (!IsSetAsInconcolusive)
			{
				_horizontalLineVelocity = _horizontalSlowSpeed;
			}
			else
			{
				_horizontalLineVelocity = _horizontalInconclusiveSpeed;
			}
			_verticalLine.GetComponent<Renderer>().enabled = true;
			_verticalLine.transform.position = new Vector3(_myRoom.transform.position.x, _myRoom.transform.position.y, -0.2f);
			_verticalLine.transform.localScale = new Vector3(0.01f, 0.01f, num2 / 10f);
			if (!asInconclusive)
			{
				_verticalLineMat.color = (flag ? ColorBlindDeactivatedColor : DeactivatedColor);
			}
			else
			{
				_verticalLineMat.color = (flag ? ColorBlindInconclusiveColor : InconclusiveColor);
			}
			if (!IsSetAsInconcolusive)
			{
				_verticalLineVelocity = _verticalSlowSpeed;
			}
			else
			{
				_verticalLineVelocity = _verticalInconclusiveSpeed;
			}
			_shouldUpdateThisFrame = true;
			_deltaElapsedCumulative = 0f;
			_enemiesDetected = false;
		}
		_enabledReferenceCount++;
	}

	public void Disable()
	{
		_enabledReferenceCount--;
		if (_enabledReferenceCount <= 0)
		{
			_enabledReferenceCount = 0;
			_horizontalLine.SetActive(false);
			_verticalLine.SetActive(false);
			_horizontalLine.GetComponent<Renderer>().enabled = false;
			_verticalLine.GetComponent<Renderer>().enabled = false;
		}
	}

	public void ForceDisableRegardlessOfReferenceCount()
	{
		_enabledReferenceCount = 0;
		Disable();
	}

	private void Update()
	{
		if (!GlobalSettings.IsGamePaused && IsEnabled)
		{
			if (gameWasPaused)
			{
				bool flag = GameSaveFile.Get("O_CB", false);
				switch (lastKnownState)
				{
				case 0:
					_horizontalLineMat.color = (flag ? ColorBlindDeactivatedColor : DeactivatedColor);
					_verticalLineMat.color = (flag ? ColorBlindDeactivatedColor : DeactivatedColor);
					break;
				case 1:
					_horizontalLineMat.color = (flag ? ColorBlindActivatedColor : ActivatedColor);
					_verticalLineMat.color = (flag ? ColorBlindActivatedColor : ActivatedColor);
					break;
				case 2:
					_horizontalLineMat.color = (flag ? ColorBlindInconclusiveColor : InconclusiveColor);
					_verticalLineMat.color = (flag ? ColorBlindInconclusiveColor : InconclusiveColor);
					break;
				}
			}
			if (!IsSetAsInconcolusive)
			{
				AttemptToDetectEnemies();
			}
			MoveSensorLines();
		}
		gameWasPaused = GlobalSettings.IsGamePaused;
	}

	private void AttemptToDetectEnemies()
	{
		bool enemiesDetected = _enemiesDetected;
		_enemiesDetected = false;
		int count = _myRoom.knownEnemiesList.Count;
		for (int i = 0; i < count; i++)
		{
			BaseEnemy baseEnemy = _myRoom.knownEnemiesList[i];
			if (baseEnemy.IsDead || baseEnemy.GetType() == typeof(SlimeEnemy))
			{
				continue;
			}
			if (distanceRestriction)
			{
				if (Vector3.Distance(baseEnemy.transform.position, distanceOriginPoint) < distance)
				{
					_enemiesDetected = true;
				}
			}
			else
			{
				_enemiesDetected = true;
			}
			break;
		}
		if (_enemiesDetected == enemiesDetected)
		{
			return;
		}
		bool flag = GameSaveFile.Get("O_CB", false);
		if (_enemiesDetected)
		{
			_horizontalLineMat.color = (flag ? ColorBlindActivatedColor : ActivatedColor);
			_verticalLineMat.color = (flag ? ColorBlindActivatedColor : ActivatedColor);
			if (_horizontalLineVelocity > 0f)
			{
				_horizontalLineVelocity = _horizontalFastSpeed;
			}
			else
			{
				_horizontalLineVelocity = 0f - _horizontalFastSpeed;
			}
			if (_verticalLineVelocity > 0f)
			{
				_verticalLineVelocity = _verticalFastSpeed;
			}
			else
			{
				_verticalLineVelocity = 0f - _verticalFastSpeed;
			}
			SystemMessageManager.ShowSystemMessage("Sensor Activated: " + _myRoom.Label, ConsoleMessageType.TriggerActivatedWarning, SystemMessageImageType.SensorNotify);
			if (!GlobalSettings.IsTutorial)
			{
				GlobalSettings.AreaSensorUsedOnce = true;
				DungeonManager.Instance.RandomBarkOnMiscSoundIfOwned();
			}
			lastKnownState = 1;
		}
		else
		{
			_horizontalLineMat.color = (flag ? ColorBlindDeactivatedColor : DeactivatedColor);
			_verticalLineMat.color = (flag ? ColorBlindDeactivatedColor : DeactivatedColor);
			if (_horizontalLineVelocity > 0f)
			{
				_horizontalLineVelocity = _horizontalSlowSpeed;
			}
			else
			{
				_horizontalLineVelocity = 0f - _horizontalSlowSpeed;
			}
			if (_verticalLineVelocity > 0f)
			{
				_verticalLineVelocity = _verticalSlowSpeed;
			}
			else
			{
				_verticalLineVelocity = 0f - _verticalSlowSpeed;
			}
			SystemMessageManager.ShowSystemMessage("Sensor Deactivated: " + _myRoom.Label, ConsoleMessageType.TriggerDeactivatedWarning, SystemMessageImageType.SensorNotify);
			lastKnownState = 0;
		}
	}

	private void MoveSensorLines()
	{
		if (!_shouldUpdateThisFrame)
		{
			_deltaElapsedCumulative += Time.deltaTime;
			_shouldUpdateThisFrame = true;
			return;
		}
		float num = _deltaElapsedCumulative + Time.deltaTime;
		_shouldUpdateThisFrame = false;
		_deltaElapsedCumulative = 0f;
		if ((_horizontalLineVelocity > 0f && _horizontalLine.transform.position.y > _roomMaxCoordinate.y) || (_horizontalLineVelocity < 0f && _horizontalLine.transform.position.y < _roomMinCoordinate.y))
		{
			_horizontalLineVelocity = 0f - _horizontalLineVelocity;
			_verticalLineVelocity = 0f - _verticalLineVelocity;
		}
		_horizontalLine.transform.position += _horizontalLineVelocity * Vector3.up * num;
		_verticalLine.transform.position += _verticalLineVelocity * Vector3.right * num;
	}

	private void CalculateSpeedAndBounds()
	{
		Mesh mesh = _myRoom.GetComponent<MeshFilter>().mesh;
		_roomMinCoordinate = _myRoom.transform.TransformPoint(mesh.bounds.min);
		_roomMaxCoordinate = _myRoom.transform.TransformPoint(mesh.bounds.max);
		float num = Vector3.Distance(new Vector3(0f, _roomMinCoordinate.y, 0f), new Vector3(0f, _roomMaxCoordinate.y, 0f));
		float num2 = Vector3.Distance(new Vector3(_roomMinCoordinate.x, 0f, 0f), new Vector3(_roomMaxCoordinate.x, 0f, 0f));
		_horizontalInconclusiveSpeed = num / 1f;
		_verticalInconclusiveSpeed = num2 / 1f;
		_horizontalSlowSpeed = num / 2f;
		_verticalSlowSpeed = num2 / 2f;
		_horizontalFastSpeed = num / 0.5f;
		_verticalFastSpeed = num2 / 0.5f;
	}
}
