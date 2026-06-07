using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[ExecuteInEditMode]
public class WaterManager : MonoBehaviour
{
	public class WaterHeightCalculation
	{
		public delegate void Callback(WaterHeightCalculation calculation);

		internal bool _queued;

		internal bool _locked;

		internal Exception _exception;

		private WaterManager _waterManager;

		private Transform _transform;

		private List<Vector3> _voxels;

		private Callback _callback;

		private Transform transform;

		private Action onWaterHeightCalculationCallback;

		public Vector3 Position { get; private set; }

		public float PositionWaterHeight { get; set; }

		public int VoxelCount { get; private set; }

		public Vector3[] VoxelPositions { get; private set; }

		public float[] VoxelWaterHeights { get; private set; }

		public bool ApplyForces { get; set; }

		public WaterHeightCalculation(Transform transform, Callback callback)
			: this(transform, null, callback)
		{
		}

		public WaterHeightCalculation(Transform transform, List<Vector3> voxels, Callback callback)
		{
			_waterManager = Instance;
			_transform = transform;
			_voxels = voxels;
			_callback = callback;
			if (voxels == null)
			{
				VoxelCount = 0;
				ApplyForces = false;
				return;
			}
			VoxelCount = voxels.Count;
			VoxelPositions = new Vector3[VoxelCount];
			VoxelWaterHeights = new float[VoxelCount];
			ApplyForces = true;
		}

		public WaterHeightCalculation(Transform transform, Action onWaterHeightCalculationCallback)
		{
			this.transform = transform;
			this.onWaterHeightCalculationCallback = onWaterHeightCalculationCallback;
		}

		public Vector3 UpdatePosition()
		{
			Position = _transform.position;
			return Position;
		}

		public Vector3 UpdateVoxelPosition(int index)
		{
			Vector3 vector = _transform.TransformPoint(_voxels[index]);
			VoxelPositions[index] = vector;
			return vector;
		}

		public void CopyVoxelWaterHeights(float[] arrayToCopyTo)
		{
			for (int i = 0; i < VoxelCount; i++)
			{
				arrayToCopyTo[i] = VoxelWaterHeights[i];
			}
		}

		public void Queue(Vector3 position)
		{
			if (!_locked)
			{
				Position = position;
				if (!_queued)
				{
					_queued = true;
					_waterManager.QueueWaterHeightCalcultation(this);
				}
			}
		}

		public void Queue(bool update = false)
		{
			if (_locked)
			{
				return;
			}
			if (update)
			{
				UpdatePosition();
				if (ApplyForces)
				{
					for (int i = 0; i < VoxelCount; i++)
					{
						UpdateVoxelPosition(i);
					}
				}
			}
			if (!_queued)
			{
				_queued = true;
				_waterManager.QueueWaterHeightCalcultation(this);
			}
		}

		internal void InvokeCallback()
		{
			if (_callback != null)
			{
				_callback(this);
			}
			_locked = false;
			_queued = false;
		}
	}

	private static WaterManager _instance;

	public const float NUMBER_OF_WAVES = 4f;

	[SerializeField]
	private Renderer _renderer;

	[Tooltip("If true, the WaveParameters will be updated in the shaders each frame.")]
	[SerializeField]
	private bool _refreshWaveParametersEachFrame = true;

	[Header("========================================================================================================================")]
	[Header("Gerstner Waves")]
	[Tooltip("Multiply all wavelength entries with this multiplier.")]
	[Range(0.001f, 10f)]
	[SerializeField]
	private float _waveLengthMultiplier = 1f;

	[Tooltip("Multiply all steepness entries with this multiplier.")]
	[Range(0f, 10f)]
	[SerializeField]
	private float _steepnessMultiplier = 1f;

	[Tooltip("Multiply all amplitude entries with this multiplier.")]
	[Range(0.001f, 10f)]
	[SerializeField]
	private float _amplitudeScaleMultiplier = 1f;

	[Tooltip("Multiply all speed entries with this multiplier.")]
	[Range(0f, 10f)]
	[SerializeField]
	private float _speedMultiplier = 1f;

	[Space]
	[Tooltip("Definition of first wave.")]
	[SerializeField]
	private WaveDefinition _wave01 = new WaveDefinition();

	[Tooltip("Definition of second wave.")]
	[SerializeField]
	private WaveDefinition _wave02 = new WaveDefinition();

	[Tooltip("Definition of third wave.")]
	[SerializeField]
	private WaveDefinition _wave03 = new WaveDefinition();

	[Tooltip("Definition of fourth wave.")]
	[SerializeField]
	private WaveDefinition _wave04 = new WaveDefinition();

	private bool _isInitialized;

	private Vector4 _wavelength;

	private Vector4 _speed;

	private Vector4 _phase;

	private Vector4 _amplitude;

	private Vector4 _steepness;

	private float _currentTime;

	private bool _isPaused;

	private bool _isDestroyed;

	private Thread _calculationThread;

	private List<WaterHeightCalculation> _mainCalculations;

	private List<WaterHeightCalculation> _sharedCalculations;

	private List<WaterHeightCalculation> _calculationCallbacks;

	private Exception _exception;

	private bool _doCalculations;

	private bool _doCalculationCallbacks;

	[HideInInspector]
	public const string _globalTimeString = "_GLOBAL_GERSTNER_Time";

	public static bool ApplicationQuitting;

	public static WaterManager Instance
	{
		get
		{
			if (_instance == null && !ApplicationQuitting)
			{
				_instance = UnityEngine.Object.FindAnyObjectByType<WaterManager>();
				if (_instance == null)
				{
					_instance = new GameObject
					{
						name = "_WATERMANAGER",
						hideFlags = HideFlags.NotEditable
					}.AddComponent<WaterManager>();
					Debug.Log("=====WaterManager Created=====");
				}
			}
			return _instance;
		}
	}

	public bool IsPaused => _isPaused;

	public static WaterManager CreateInstance()
	{
		return Instance;
	}

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (!_isInitialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		UpdateAndSetShaderProperties();
		int capacity = 1000;
		_calculationThread = new Thread(CalculateWaterHeightJob);
		_mainCalculations = new List<WaterHeightCalculation>(capacity);
		_sharedCalculations = new List<WaterHeightCalculation>(capacity);
		_calculationCallbacks = new List<WaterHeightCalculation>(capacity);
		_doCalculations = false;
		_isInitialized = true;
	}

	public void Update()
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		if (!_isPaused)
		{
			_currentTime += GameSpeedManager.WaterDeltaTime;
		}
		if (_refreshWaveParametersEachFrame)
		{
			UpdateAndSetShaderProperties();
		}
		UpdateGlobalWaveShaderVariables();
	}

	private void LateUpdate()
	{
		if (_exception != null)
		{
			lock (_exception)
			{
				throw _exception;
			}
		}
		if (!_doCalculationCallbacks)
		{
			return;
		}
		lock (_calculationCallbacks)
		{
			int count = _calculationCallbacks.Count;
			for (int i = 0; i < count; i++)
			{
				_calculationCallbacks[i].InvokeCallback();
			}
			_calculationCallbacks.Clear();
			_doCalculationCallbacks = false;
		}
	}

	private void FixedUpdate()
	{
		if (_mainCalculations == null || _mainCalculations.Count == 0)
		{
			return;
		}
		lock (_sharedCalculations)
		{
			_sharedCalculations.AddRange(_mainCalculations);
			_mainCalculations.Clear();
			_doCalculations = true;
			if (_calculationThread.ThreadState == ThreadState.Unstarted)
			{
				_calculationThread.Start();
			}
		}
	}

	public void OnApplicationQuit()
	{
		ApplicationQuitting = true;
	}

	private void OnDestroy()
	{
		_isDestroyed = true;
	}

	private void UpdateAndSetShaderProperties()
	{
		ApplyWaveDefition(_wave01, 0);
		ApplyWaveDefition(_wave02, 1);
		ApplyWaveDefition(_wave03, 2);
		ApplyWaveDefition(_wave04, 3);
		Shader.SetGlobalVector("_GLOBAL_GERSTNER_Wavelength", _wavelength);
		Shader.SetGlobalVector("_GLOBAL_GERSTNER_Speed", _speed);
		Shader.SetGlobalVector("_GLOBAL_GERSTNER_Phase", _phase);
		Shader.SetGlobalVector("_GLOBAL_GERSTNER_Amplitude", _amplitude);
		Shader.SetGlobalVector("_GLOBAL_GERSTNER_Steepness", _steepness);
		Shader.SetGlobalFloat("_GLOBAL_GERSTNER_Time", _currentTime);
		_isInitialized = true;
	}

	private void ApplyWaveDefition(WaveDefinition waveDefinition, int index)
	{
		waveDefinition.ApplyMultipliers(_waveLengthMultiplier, _speedMultiplier, _steepnessMultiplier, _amplitudeScaleMultiplier);
		_wavelength[index] = waveDefinition.Wavelength;
		_speed[index] = waveDefinition.Speed;
		_phase[index] = waveDefinition.Phase;
		_amplitude[index] = waveDefinition.Amplitude;
		_steepness[index] = waveDefinition.Steepness;
		Shader.SetGlobalVector(waveDefinition.ReturnNormalizedDirectionGlobal(index), waveDefinition.NormalizedDirection);
	}

	private void UpdateGlobalWaveShaderVariables()
	{
		Shader.SetGlobalFloat("_GLOBAL_GERSTNER_Time", _currentTime);
	}

	public void PauseWater()
	{
		_isPaused = !_isPaused;
	}

	public static float ReturnsGreatestCommonDivisor(float value1, float value2)
	{
		float num = 1f;
		if (value1 == 0f || value2 == 0f)
		{
			return 1f;
		}
		float num2 = Mathf.Abs(value1);
		float num3 = Mathf.Abs(value2);
		if (num2 == num3)
		{
			return num2;
		}
		if (num2 > num3 && num2 % num3 == 0f)
		{
			return num3;
		}
		if (num3 > num2 && num3 % num2 == 0f)
		{
			return num2;
		}
		while (num3 != 0f)
		{
			num = num3;
			num3 = num2 % num3;
			num2 = num;
		}
		return num;
	}

	public static float ReturnLowestCommonMultiple(float value1, float value2)
	{
		float num = Mathf.Abs(value1);
		float num2 = Mathf.Abs(value2);
		return num / ReturnsGreatestCommonDivisor(num, num2) * num2;
	}

	public Vector3 ReturnGerstnerPosition(Vector3 position)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		Vector3 vector = _wave01.ReturnWaveOffsetGerstner(position, _currentTime) + _wave02.ReturnWaveOffsetGerstner(position, _currentTime) + _wave03.ReturnWaveOffsetGerstner(position, _currentTime) + _wave04.ReturnWaveOffsetGerstner(position, _currentTime);
		return position + vector;
	}

	public float ReturnWaterHeightOnPoint(float groundXPosition, float groundZPosition)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		return _wave01.ReturnWaveOffsetGerstnerY(groundXPosition, groundZPosition, _currentTime) + _wave02.ReturnWaveOffsetGerstnerY(groundXPosition, groundZPosition, _currentTime) + _wave03.ReturnWaveOffsetGerstnerY(groundXPosition, groundZPosition, _currentTime) + _wave04.ReturnWaveOffsetGerstnerY(groundXPosition, groundZPosition, _currentTime);
	}

	public float ReturnWaterHeightOnPoint(Vector3 point)
	{
		return ReturnWaterHeightOnPoint(point.x, point.z);
	}

	private Vector3 ReturnWaveOffsetGerstner(float length, float speed, float phase, float amplitude, float numberOfWaves, float steepness, Vector2 direction, float x, float z, float time)
	{
		float num = Vector3.Dot(Vector3.Normalize(new Vector3(direction.x, direction.y, 0f)), new Vector3(x, z, 0f));
		float num2 = MathF.PI * 2f / length;
		float f = num2 * num + speed * time + phase;
		float num3 = Mathf.Cos(f);
		float num4 = Mathf.Sin(f);
		float num5 = steepness / (num2 * amplitude * numberOfWaves);
		Vector3 result = new Vector3(0f, 0f, 0f);
		result.x = num5 * amplitude * direction.x * num3;
		result.z = num5 * amplitude * direction.y * num3;
		result.y = amplitude * num4;
		return result;
	}

	internal void QueueWaterHeightCalcultation(WaterHeightCalculation calculation)
	{
		_mainCalculations.Add(calculation);
	}

	private void CalculateWaterHeightJob()
	{
		try
		{
			while (!ApplicationQuitting && !_isDestroyed)
			{
				if (!_doCalculations)
				{
					Thread.Sleep(16);
					continue;
				}
				lock (_sharedCalculations)
				{
					int count = _sharedCalculations.Count;
					for (int i = 0; i < count; i++)
					{
						WaterHeightCalculation waterHeightCalculation = _sharedCalculations[i];
						waterHeightCalculation._locked = true;
						waterHeightCalculation.PositionWaterHeight = ReturnWaterHeightOnPoint(waterHeightCalculation.Position);
						if (waterHeightCalculation.ApplyForces)
						{
							int voxelCount = waterHeightCalculation.VoxelCount;
							for (int j = 0; j < voxelCount; j++)
							{
								waterHeightCalculation.VoxelWaterHeights[j] = ReturnWaterHeightOnPoint(waterHeightCalculation.VoxelPositions[j]);
							}
						}
						lock (_calculationCallbacks)
						{
							_calculationCallbacks.Add(waterHeightCalculation);
							_doCalculationCallbacks = true;
						}
					}
					_sharedCalculations.Clear();
					_doCalculations = false;
				}
			}
		}
		catch (Exception exception)
		{
			if (_exception == null)
			{
				_exception = exception;
				return;
			}
			lock (_exception)
			{
				_exception = exception;
			}
		}
	}

	public static float ReturnWaterHeight(float groundXPosition, float groundZPosition)
	{
		if (Instance == null)
		{
			return 0f;
		}
		return Instance.ReturnWaterHeightOnPoint(groundXPosition, groundZPosition);
	}

	public static Material ReturnMaterial()
	{
		if (Instance == null)
		{
			return null;
		}
		return Instance.GetComponent<MeshRenderer>().sharedMaterial;
	}

	public static void SetMaterial(Material material)
	{
		if (!(Instance == null))
		{
			Instance.GetComponent<MeshRenderer>().sharedMaterial = material;
		}
	}
}
