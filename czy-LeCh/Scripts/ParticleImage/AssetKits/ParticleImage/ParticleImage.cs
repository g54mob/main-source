using System;
using System.Collections.Generic;
using System.Linq;
using AssetKits.ParticleImage.Enumerations;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace AssetKits.ParticleImage
{
	[AddComponentMenu("UI/Particle Image/Particle Image")]
	[RequireComponent(typeof(CanvasRenderer))]
	public sealed class ParticleImage : MaskableGraphic
	{
		[SerializeField]
		private ParticleImage _main;

		[SerializeField]
		private ParticleImage[] _children;

		private RectTransform _canvasRect;

		private Mesh _mesh;

		private Mesh.MeshDataArray _meshDataArray;

		private Mesh.MeshData _meshData;

		private Mesh.MeshDataArray _trailMeshDataArray;

		private Mesh.MeshData _trailMeshData;

		[SerializeField]
		private Simulation _space;

		[SerializeField]
		private TimeScale _timeScale = TimeScale.Normal;

		[SerializeField]
		private Module _emitterConstraintEnabled = new Module(enabled: false);

		[SerializeField]
		private Transform _emitterConstraintTransform;

		[SerializeField]
		private EmitterShape _shape = EmitterShape.Circle;

		[SerializeField]
		private SpreadType _spread;

		[SerializeField]
		private float _spreadLoop = 1f;

		[SerializeField]
		private float _startDelay;

		[SerializeField]
		private float _radius = 50f;

		[SerializeField]
		private float _width = 100f;

		[SerializeField]
		private float _height = 100f;

		[SerializeField]
		private float _angle = 45f;

		[SerializeField]
		private float _length = 100f;

		[SerializeField]
		private bool _fitRect;

		[SerializeField]
		private bool _emitOnSurface = true;

		[SerializeField]
		private float _emitterThickness;

		[SerializeField]
		private bool _loop = true;

		[SerializeField]
		private bool _prewarm;

		[SerializeField]
		private float _duration = 5f;

		[SerializeField]
		private PlayMode _playMode = PlayMode.OnAwake;

		[SerializeField]
		private SeparatedMinMaxCurve _startSize = new SeparatedMinMaxCurve(40f);

		[SerializeField]
		private ParticleSystem.MinMaxGradient _startColor = new ParticleSystem.MinMaxGradient(Color.white);

		[SerializeField]
		private ParticleSystem.MinMaxCurve _lifetime = new ParticleSystem.MinMaxCurve(1f);

		[SerializeField]
		private ParticleSystem.MinMaxCurve _startSpeed = new ParticleSystem.MinMaxCurve(2f);

		[SerializeField]
		private ParticleSystem.MinMaxGradient _colorOverLifetime = new ParticleSystem.MinMaxGradient(new Gradient());

		[SerializeField]
		private ParticleSystem.MinMaxGradient _colorBySpeed = new ParticleSystem.MinMaxGradient(new Gradient());

		[SerializeField]
		private SpeedRange _colorSpeedRange = new SpeedRange(0f, 1f);

		[SerializeField]
		private SeparatedMinMaxCurve _sizeOverLifetime = new SeparatedMinMaxCurve(new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f)));

		[SerializeField]
		private SeparatedMinMaxCurve _sizeBySpeed = new SeparatedMinMaxCurve(new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f)));

		[SerializeField]
		private SpeedRange _sizeSpeedRange = new SpeedRange(0f, 1f);

		[SerializeField]
		private SeparatedMinMaxCurve _startRotation = new SeparatedMinMaxCurve(0f);

		[SerializeField]
		private SeparatedMinMaxCurve _rotationOverLifetime = new SeparatedMinMaxCurve(0f);

		[SerializeField]
		private SeparatedMinMaxCurve _rotationBySpeed = new SeparatedMinMaxCurve(new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f)));

		[SerializeField]
		private SpeedRange _rotationSpeedRange = new SpeedRange(0f, 1f);

		[SerializeField]
		private ParticleSystem.MinMaxCurve _speedOverLifetime = new ParticleSystem.MinMaxCurve(1f);

		[SerializeField]
		private bool _alignToDirection;

		[SerializeField]
		private ParticleSystem.MinMaxCurve _gravity = new ParticleSystem.MinMaxCurve(-9.81f);

		[SerializeField]
		private Module _targetModule = new Module(enabled: false);

		[SerializeField]
		private Transform _attractorTarget;

		[SerializeField]
		private ParticleSystem.MinMaxCurve _toTarget = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		[SerializeField]
		private AttractorType _targetMode;

		[SerializeField]
		private Module _noiseModule = new Module(enabled: false);

		[SerializeField]
		private Module _gravityModule = new Module(enabled: false);

		[SerializeField]
		private Module _vortexModule = new Module(enabled: false);

		[SerializeField]
		private Module _velocityModule = new Module(enabled: false);

		[SerializeField]
		private Simulation _velocitySpace;

		[SerializeField]
		private SeparatedMinMaxCurve _velocityOverLifetime = new SeparatedMinMaxCurve(0f, separated: true, separable: false);

		[SerializeField]
		private ParticleSystem.MinMaxCurve _vortexStrength;

		[SerializeField]
		private Module _sheetModule = new Module(enabled: false);

		[SerializeField]
		private Vector2Int _textureTile = Vector2Int.one;

		[SerializeField]
		private SheetType _sheetType = SheetType.FPS;

		public NativeArray<SpriteSheet> sheetsArray;

		[SerializeField]
		private ParticleSystem.MinMaxCurve _frameOverTime;

		[SerializeField]
		private ParticleSystem.MinMaxCurve _startFrame = new ParticleSystem.MinMaxCurve(0f);

		[SerializeField]
		private SpeedRange _frameSpeedRange = new SpeedRange(0f, 1f);

		[SerializeField]
		private int _textureSheetFPS = 25;

		[SerializeField]
		private int _textureSheetCycles = 1;

		private List<Particle> _particles = new List<Particle>(128);

		private ParticlePool _pool;

		[SerializeField]
		private float _rate = 50f;

		[SerializeField]
		private float _rateOverLifetime;

		[SerializeField]
		private float _rateOverDistance;

		[SerializeField]
		private List<Burst> _bursts = new List<Burst>();

		[FormerlySerializedAs("_trailRenderer")]
		[SerializeField]
		private ParticleTrailRenderer _particleTrailRenderer;

		[SerializeField]
		private Module _trailModule;

		[SerializeField]
		private ParticleSystem.MinMaxCurve _trailWidth = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f)));

		[SerializeField]
		private float _trailLifetime = 1f;

		[SerializeField]
		private float _minimumVertexDistance = 10f;

		[SerializeField]
		private ParticleSystem.MinMaxGradient _trailColorOverLifetime = new ParticleSystem.MinMaxGradient(Color.white);

		[SerializeField]
		private ParticleSystem.MinMaxGradient _trailColorOverTrail = new ParticleSystem.MinMaxGradient(Color.white);

		[SerializeField]
		private Material _trailMaterial;

		[SerializeField]
		private bool _inheritParticleColor;

		[SerializeField]
		private bool _dieWithParticle;

		[Range(0f, 1f)]
		[SerializeField]
		private float _trailRatio = 1f;

		private float _time;

		private float _playback;

		private float _loopTimer;

		private float _t;

		private float _t2;

		private float _burstTimer;

		private Noise _noise = new Noise();

		[SerializeField]
		private Vector2 _noiseOffset;

		[SerializeField]
		private float _noiseFrequency = 1f;

		[SerializeField]
		private float _noiseStrength = 1f;

		private bool _noiseDebug;

		private Vector2Int _noiseViewSize = new Vector2Int(64, 64);

		[SerializeField]
		private Module _multithreadModule = new Module(enabled: false);

		[SerializeField]
		private bool _multithreadEnabled;

		private bool _emitting;

		private bool _playing;

		private bool _stopped;

		private bool _paused;

		[SerializeField]
		private UnityEvent _onStart = new UnityEvent();

		[SerializeField]
		private UnityEvent _onFirstParticleFinish = new UnityEvent();

		[SerializeField]
		private UnityEvent _onParticleFinish = new UnityEvent();

		[SerializeField]
		private UnityEvent _onLastParticleFinish = new UnityEvent();

		[SerializeField]
		private UnityEvent _onStop = new UnityEvent();

		private Vector3 _lastPosition;

		private Vector3 _deltaPosition;

		private Camera _camera;

		private bool _firstParticleFinished;

		private int _orderPerSec;

		private int _orderOverLife;

		private int _orderOverDistance;

		public bool moduleEmitterFoldout;

		public bool moduleParticleFoldout;

		public bool moduleMovementFoldout;

		public bool moduleEventsFoldout;

		public bool moduleAdvancedFoldout;

		[SerializeField]
		private Sprite m_Sprite;

		[SerializeField]
		[Obsolete("Use sprite instead")]
		private Texture m_Texture;

		public ParticleImage[] children
		{
			get
			{
				return _children;
			}
			private set
			{
				_children = value;
			}
		}

		public ParticleImage main
		{
			get
			{
				if (_main == null)
				{
					_main = GetMain();
				}
				return _main;
			}
			private set
			{
				_main = value;
			}
		}

		public bool isMain => main == this;

		public RectTransform canvasRect
		{
			get
			{
				return _canvasRect;
			}
			set
			{
				_canvasRect = value;
			}
		}

		public Mesh mesh
		{
			get
			{
				if (_mesh == null)
				{
					_mesh = new Mesh();
					_mesh.MarkDynamic();
				}
				return _mesh;
			}
		}

		public Simulation space
		{
			get
			{
				return _space;
			}
			set
			{
				_space = value;
			}
		}

		public TimeScale timeScale
		{
			get
			{
				return _timeScale;
			}
			set
			{
				_timeScale = value;
			}
		}

		public bool emitterConstraintEnabled
		{
			get
			{
				return _emitterConstraintEnabled.enabled;
			}
			set
			{
				_emitterConstraintEnabled.enabled = value;
			}
		}

		public Transform emitterConstraintTransform
		{
			get
			{
				return _emitterConstraintTransform;
			}
			set
			{
				_emitterConstraintTransform = value;
			}
		}

		public EmitterShape shape
		{
			get
			{
				return _shape;
			}
			set
			{
				_shape = value;
			}
		}

		public SpreadType spreadType
		{
			get
			{
				return _spread;
			}
			set
			{
				_spread = value;
			}
		}

		public float spreadLoop
		{
			get
			{
				return _spreadLoop;
			}
			set
			{
				_spreadLoop = value;
			}
		}

		public float startDelay
		{
			get
			{
				return _startDelay;
			}
			set
			{
				_startDelay = value;
			}
		}

		public float circleRadius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public float rectWidth
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public float rectHeight
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		public float directionAngle
		{
			get
			{
				return _angle;
			}
			set
			{
				_angle = value;
			}
		}

		public float lineLength
		{
			get
			{
				return _length;
			}
			set
			{
				_length = value;
			}
		}

		public bool fitRect
		{
			get
			{
				return _fitRect;
			}
			set
			{
				_fitRect = value;
				if (value)
				{
					FitRect();
				}
			}
		}

		public bool emitOnSurface
		{
			get
			{
				return _emitOnSurface;
			}
			set
			{
				_emitOnSurface = value;
			}
		}

		public float emitterThickness
		{
			get
			{
				return _emitterThickness;
			}
			set
			{
				_emitterThickness = value;
			}
		}

		public bool loop
		{
			get
			{
				return _loop;
			}
			set
			{
				_loop = value;
			}
		}

		public bool prewarm
		{
			get
			{
				return _prewarm;
			}
			set
			{
				_prewarm = value;
			}
		}

		public float duration
		{
			get
			{
				return _duration;
			}
			set
			{
				_duration = value;
			}
		}

		public PlayMode PlayMode
		{
			get
			{
				return _playMode;
			}
			set
			{
				_playMode = value;
				if (isMain && children != null)
				{
					ParticleImage[] array = children;
					for (int i = 0; i < array.Length; i++)
					{
						array[i]._playMode = value;
					}
				}
				else if (!isMain)
				{
					main.PlayMode = value;
				}
			}
		}

		public SeparatedMinMaxCurve startSize
		{
			get
			{
				return _startSize;
			}
			set
			{
				_startSize = value;
			}
		}

		public ParticleSystem.MinMaxGradient startColor
		{
			get
			{
				return _startColor;
			}
			set
			{
				_startColor = value;
			}
		}

		public ParticleSystem.MinMaxCurve lifetime
		{
			get
			{
				return _lifetime;
			}
			set
			{
				_lifetime = value;
			}
		}

		public ParticleSystem.MinMaxCurve startSpeed
		{
			get
			{
				return _startSpeed;
			}
			set
			{
				_startSpeed = value;
			}
		}

		public ParticleSystem.MinMaxGradient colorOverLifetime
		{
			get
			{
				return _colorOverLifetime;
			}
			set
			{
				_colorOverLifetime = value;
			}
		}

		public ParticleSystem.MinMaxGradient colorBySpeed
		{
			get
			{
				return _colorBySpeed;
			}
			set
			{
				_colorBySpeed = value;
			}
		}

		public SpeedRange colorSpeedRange
		{
			get
			{
				return _colorSpeedRange;
			}
			set
			{
				_colorSpeedRange = value;
			}
		}

		public SeparatedMinMaxCurve sizeOverLifetime
		{
			get
			{
				return _sizeOverLifetime;
			}
			set
			{
				_sizeOverLifetime = value;
			}
		}

		public SeparatedMinMaxCurve sizeBySpeed
		{
			get
			{
				return _sizeBySpeed;
			}
			set
			{
				_sizeBySpeed = value;
			}
		}

		public SpeedRange sizeSpeedRange
		{
			get
			{
				return _sizeSpeedRange;
			}
			set
			{
				_sizeSpeedRange = value;
			}
		}

		public SeparatedMinMaxCurve startRotation
		{
			get
			{
				return _startRotation;
			}
			set
			{
				_startRotation = value;
			}
		}

		public SeparatedMinMaxCurve rotationOverLifetime
		{
			get
			{
				return _rotationOverLifetime;
			}
			set
			{
				_rotationOverLifetime = value;
			}
		}

		public SeparatedMinMaxCurve rotationBySpeed
		{
			get
			{
				return _rotationBySpeed;
			}
			set
			{
				_rotationBySpeed = value;
			}
		}

		public SpeedRange rotationSpeedRange
		{
			get
			{
				return _rotationSpeedRange;
			}
			set
			{
				_rotationSpeedRange = value;
			}
		}

		public ParticleSystem.MinMaxCurve speedOverLifetime
		{
			get
			{
				return _speedOverLifetime;
			}
			set
			{
				_speedOverLifetime = value;
			}
		}

		public bool alignToDirection
		{
			get
			{
				return _alignToDirection;
			}
			set
			{
				_alignToDirection = value;
			}
		}

		public ParticleSystem.MinMaxCurve gravity
		{
			get
			{
				return _gravity;
			}
			set
			{
				_gravity = value;
			}
		}

		public bool attractorEnabled
		{
			get
			{
				return _targetModule.enabled;
			}
			set
			{
				_targetModule.enabled = value;
			}
		}

		public Transform attractorTarget
		{
			get
			{
				return _attractorTarget;
			}
			set
			{
				_attractorTarget = value;
			}
		}

		public ParticleSystem.MinMaxCurve attractorLerp
		{
			get
			{
				return _toTarget;
			}
			set
			{
				_toTarget = value;
			}
		}

		public AttractorType attractorType
		{
			get
			{
				return _targetMode;
			}
			set
			{
				_targetMode = value;
			}
		}

		public bool noiseEnabled
		{
			get
			{
				return _noiseModule.enabled;
			}
			set
			{
				_noiseModule.enabled = value;
			}
		}

		public bool gravityEnabled
		{
			get
			{
				return _gravityModule.enabled;
			}
			set
			{
				_gravityModule.enabled = value;
			}
		}

		public bool vortexEnabled
		{
			get
			{
				return _vortexModule.enabled;
			}
			set
			{
				_vortexModule.enabled = value;
			}
		}

		public bool velocityEnabled
		{
			get
			{
				return _velocityModule.enabled;
			}
			set
			{
				_velocityModule.enabled = value;
			}
		}

		public Simulation velocitySpace
		{
			get
			{
				return _velocitySpace;
			}
			set
			{
				_velocitySpace = value;
			}
		}

		public SeparatedMinMaxCurve velocityOverLifetime
		{
			get
			{
				return _velocityOverLifetime;
			}
			set
			{
				_velocityOverLifetime = value;
			}
		}

		public ParticleSystem.MinMaxCurve vortexStrength
		{
			get
			{
				return _vortexStrength;
			}
			set
			{
				_vortexStrength = value;
			}
		}

		public bool textureSheetEnabled
		{
			get
			{
				return _sheetModule.enabled;
			}
			set
			{
				_sheetModule.enabled = value;
			}
		}

		public Vector2Int textureTile
		{
			get
			{
				return _textureTile;
			}
			set
			{
				_textureTile = value;
			}
		}

		public SheetType textureSheetType
		{
			get
			{
				return _sheetType;
			}
			set
			{
				_sheetType = value;
			}
		}

		public ParticleSystem.MinMaxCurve textureSheetFrameOverTime
		{
			get
			{
				return _frameOverTime;
			}
			set
			{
				_frameOverTime = value;
			}
		}

		public ParticleSystem.MinMaxCurve textureSheetStartFrame
		{
			get
			{
				return _startFrame;
			}
			set
			{
				_startFrame = value;
			}
		}

		public SpeedRange textureSheetFrameSpeedRange
		{
			get
			{
				return _frameSpeedRange;
			}
			set
			{
				_frameSpeedRange = value;
			}
		}

		public int textureSheetFPS
		{
			get
			{
				return _textureSheetFPS;
			}
			set
			{
				_textureSheetFPS = value;
			}
		}

		public int textureSheetCycles
		{
			get
			{
				return _textureSheetCycles;
			}
			set
			{
				_textureSheetCycles = value;
			}
		}

		public List<Particle> particles => _particles;

		public ParticlePool pool
		{
			get
			{
				if (_pool == null)
				{
					_pool = new ParticlePool((int)(_rate + _rateOverLifetime + _rateOverDistance), this);
				}
				return _pool;
			}
		}

		public int particleCount => _particles.Count;

		public float rateOverTime
		{
			get
			{
				return _rate;
			}
			set
			{
				_rate = value;
			}
		}

		public float rateOverLifetime
		{
			get
			{
				return _rateOverLifetime;
			}
			set
			{
				_rateOverLifetime = value;
			}
		}

		public float rateOverDistance
		{
			get
			{
				return _rateOverDistance;
			}
			set
			{
				_rateOverDistance = value;
			}
		}

		public ParticleTrailRenderer particleTrailRenderer
		{
			get
			{
				if (trailsEnabled)
				{
					if (!_particleTrailRenderer)
					{
						_particleTrailRenderer = GetComponentInChildren<ParticleTrailRenderer>();
						if (!_particleTrailRenderer)
						{
							GameObject obj = new GameObject("Trails");
							obj.transform.parent = base.transform;
							obj.transform.localPosition = Vector3.zero;
							obj.transform.localScale = Vector3.one;
							obj.transform.localEulerAngles = Vector3.zero;
							obj.AddComponent<CanvasRenderer>();
							ParticleTrailRenderer particleTrailRenderer = obj.AddComponent<ParticleTrailRenderer>();
							particleTrailRenderer.raycastTarget = false;
							_particleTrailRenderer = particleTrailRenderer;
						}
					}
					return _particleTrailRenderer;
				}
				return null;
			}
			set
			{
				_particleTrailRenderer = value;
			}
		}

		public bool trailsEnabled
		{
			get
			{
				return _trailModule.enabled;
			}
			set
			{
				_trailModule.enabled = value;
			}
		}

		public ParticleSystem.MinMaxCurve trailWidth
		{
			get
			{
				return _trailWidth;
			}
			set
			{
				_trailWidth = value;
			}
		}

		public float trailLifetime
		{
			get
			{
				return _trailLifetime;
			}
			set
			{
				_trailLifetime = value;
			}
		}

		public float minimumVertexDistance
		{
			get
			{
				return _minimumVertexDistance;
			}
			set
			{
				_minimumVertexDistance = value;
			}
		}

		public ParticleSystem.MinMaxGradient trailColorOverLifetime
		{
			get
			{
				return _trailColorOverLifetime;
			}
			set
			{
				_trailColorOverLifetime = value;
			}
		}

		public ParticleSystem.MinMaxGradient trailColorOverTrail
		{
			get
			{
				return _trailColorOverTrail;
			}
			set
			{
				_trailColorOverTrail = value;
			}
		}

		public Material trailMaterial
		{
			get
			{
				return _trailMaterial;
			}
			set
			{
				_trailMaterial = value;
				if ((bool)_particleTrailRenderer)
				{
					_particleTrailRenderer.material = value;
					particleTrailRenderer.SetMaterialDirty();
				}
			}
		}

		public bool inheritParticleColor
		{
			get
			{
				return _inheritParticleColor;
			}
			set
			{
				_inheritParticleColor = value;
			}
		}

		public bool dieWithParticle
		{
			get
			{
				return _dieWithParticle;
			}
			set
			{
				_dieWithParticle = value;
			}
		}

		public float trailRatio
		{
			get
			{
				return _trailRatio;
			}
			set
			{
				_trailRatio = Mathf.Clamp01(value);
			}
		}

		public float time => _time;

		public float playback => _playback;

		public Noise noise
		{
			get
			{
				return _noise;
			}
			set
			{
				_noise = value;
			}
		}

		public Vector2 noiseOffset
		{
			get
			{
				return _noiseOffset;
			}
			set
			{
				_noiseOffset = value;
			}
		}

		public float noiseFrequency
		{
			get
			{
				return _noiseFrequency;
			}
			set
			{
				_noiseFrequency = value;
				_noise.SetFrequency(_noiseFrequency);
			}
		}

		public float noiseStrength
		{
			get
			{
				return _noiseStrength;
			}
			set
			{
				_noiseStrength = value;
			}
		}

		public bool noiseDebug
		{
			get
			{
				return _noiseDebug;
			}
			set
			{
				_noiseDebug = value;
			}
		}

		public Vector2Int noiseViewSize
		{
			get
			{
				return _noiseViewSize;
			}
			set
			{
				_noiseViewSize = value;
			}
		}

		public bool multithreadEnabled
		{
			get
			{
				if (_multithreadModule.enabled)
				{
					return _multithreadEnabled;
				}
				return false;
			}
			set
			{
				if (isMain && children != null)
				{
					ParticleImage[] array = children;
					foreach (ParticleImage obj in array)
					{
						obj._multithreadEnabled = value;
						obj._multithreadModule.enabled = value;
					}
				}
				else if (!isMain)
				{
					main._multithreadEnabled = value;
					main._multithreadModule.enabled = value;
				}
			}
		}

		public bool isEmitting
		{
			get
			{
				return _emitting;
			}
			private set
			{
				_emitting = value;
			}
		}

		public bool isPlaying
		{
			get
			{
				return _playing;
			}
			private set
			{
				_playing = value;
			}
		}

		public bool isStopped
		{
			get
			{
				return _stopped;
			}
			private set
			{
				_stopped = value;
			}
		}

		public bool isPaused
		{
			get
			{
				return _paused;
			}
			private set
			{
				_paused = value;
			}
		}

		public UnityEvent onParticleStarted => _onStart;

		public UnityEvent onFirstParticleFinished => _onFirstParticleFinish;

		public UnityEvent onAnyParticleFinished => _onParticleFinish;

		public UnityEvent onLastParticleFinished => _onLastParticleFinish;

		public UnityEvent onParticleStop => _onStop;

		public Vector3 deltaPosition => _deltaPosition;

		private Camera mainCamera
		{
			get
			{
				if (_camera == null)
				{
					_camera = Camera.main;
				}
				return _camera;
			}
		}

		private bool CanStop
		{
			get
			{
				if (children != null)
				{
					bool result = true;
					ParticleImage[] array = children;
					foreach (ParticleImage particleImage in array)
					{
						if (particleImage.isEmitting || particleImage.particleCount > 0)
						{
							result = false;
							break;
						}
					}
					return result;
				}
				return true;
			}
		}

		public override Material material
		{
			get
			{
				return base.material;
			}
			set
			{
				if (!(m_Material == value))
				{
					m_Material = value;
					SetMaterialDirty();
				}
			}
		}

		public Sprite sprite
		{
			get
			{
				return m_Sprite;
			}
			set
			{
				if (!(m_Sprite == value))
				{
					m_Sprite = value;
					SetMaterialDirty();
				}
			}
		}

		[Obsolete("Use sprite instead")]
		public Texture texture
		{
			get
			{
				return m_Texture;
			}
			set
			{
				if (!(m_Texture == value))
				{
					m_Texture = value;
					SetMaterialDirty();
				}
			}
		}

		public override Texture mainTexture
		{
			get
			{
				if (sprite != null)
				{
					return sprite.texture;
				}
				if (!(m_Texture == null))
				{
					return m_Texture;
				}
				return Graphic.s_WhiteTexture;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (isMain)
			{
				children = GetChildren();
			}
			if (fitRect)
			{
				FitRect();
			}
			main = GetMain();
			main.children = main.GetChildren();
			_playMode = main.PlayMode;
			_multithreadEnabled = main._multithreadEnabled;
			_multithreadModule.enabled = main._multithreadModule.enabled;
			_lastPosition = base.transform.position;
			if ((bool)base.canvas)
			{
				canvasRect = base.canvas.gameObject.GetComponent<RectTransform>();
			}
			RecalculateMasking();
			RecalculateClipping();
			Clear();
			if (PlayMode == PlayMode.OnAwake && Application.isPlaying)
			{
				Play();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (isMain)
			{
				children = GetChildren();
			}
			if (fitRect)
			{
				FitRect();
			}
			main = GetMain();
			main.children = main.GetChildren();
			_playMode = main.PlayMode;
			_multithreadEnabled = main._multithreadEnabled;
			_multithreadModule.enabled = main._multithreadModule.enabled;
			_lastPosition = base.transform.position;
			if ((bool)base.canvas && canvasRect == null)
			{
				canvasRect = base.canvas.gameObject.GetComponent<RectTransform>();
			}
			_noise.SetNoiseType(Noise.NoiseType.OpenSimplex2);
			_noise.SetFrequency(_noiseFrequency / 100f);
			if (PlayMode == PlayMode.OnEnable && Application.isPlaying)
			{
				Stop(stopAndClear: true);
				Clear();
				Play();
			}
			RecalculateMasking();
			RecalculateClipping();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		public ParticleImage GetMain()
		{
			if ((bool)base.transform.parent && base.transform.parent.TryGetComponent<ParticleImage>(out var component))
			{
				return component.GetMain();
			}
			return this;
		}

		public ParticleImage[] GetChildren()
		{
			if (base.transform.childCount <= 0)
			{
				return null;
			}
			IEnumerable<ParticleImage> source = from t in GetComponentsInChildren<ParticleImage>()
				where t != this
				select t;
			if (source.Any())
			{
				return source.ToArray();
			}
			return null;
		}

		private void OnTransformChildrenChanged()
		{
			main = GetMain();
			if (isMain)
			{
				children = GetChildren();
			}
		}

		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			main = GetMain();
			if (isMain)
			{
				children = GetChildren();
			}
		}

		public void Play()
		{
			main.DoPlay();
		}

		private void DoPlay()
		{
			if (isMain && children != null)
			{
				ParticleImage[] array = children;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DoPlay();
				}
			}
			_t = 1f / _rate;
			_time = 0f;
			_burstTimer = 0f;
			for (int j = 0; j < _bursts.Count; j++)
			{
				_bursts[j].used = false;
			}
			isEmitting = true;
			isPlaying = true;
			isPaused = false;
			isStopped = false;
			if (prewarm)
			{
				Prewarm();
			}
			Simulate((_timeScale == TimeScale.Normal) ? Time.deltaTime : Time.unscaledDeltaTime, prewarm);
			OnParticleStart();
		}

		public void Pause()
		{
			main.DoPause();
		}

		private void DoPause()
		{
			if (isMain && children != null)
			{
				ParticleImage[] array = children;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DoPause();
				}
			}
			isEmitting = false;
			isPlaying = false;
			isPaused = true;
		}

		public void Stop()
		{
			Stop(stopAndClear: false);
		}

		public void Stop(bool stopAndClear)
		{
			main.DoStop(stopAndClear);
		}

		private void DoStop(bool stopAndClear)
		{
			if (isMain && children != null)
			{
				ParticleImage[] array = children;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DoStop(stopAndClear);
				}
			}
			_orderPerSec = 0;
			_orderOverLife = 0;
			_orderOverDistance = 0;
			for (int j = 0; j < _bursts.Count; j++)
			{
				_bursts[j].used = false;
			}
			if (stopAndClear)
			{
				isStopped = true;
				isPlaying = false;
				Clear();
			}
			isEmitting = false;
			if (isPaused)
			{
				isPaused = false;
				isStopped = true;
				isPlaying = false;
				Clear();
			}
			for (int k = 0; k < _bursts.Count; k++)
			{
				_bursts[k].used = false;
			}
			_firstParticleFinished = false;
			OnParticleStop();
		}

		public void Clear()
		{
			main.DoClear();
		}

		private void DoClear()
		{
			if (isMain && children != null)
			{
				ParticleImage[] array = children;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DoClear();
				}
			}
			for (int j = 0; j < _bursts.Count; j++)
			{
				_bursts[j].used = false;
			}
			_time = 0f;
			_playback = 0f;
			_burstTimer = 0f;
			_particles.Clear();
			mesh.Clear();
			base.canvasRenderer.SetMesh(mesh);
			SetMaterialDirty();
			if ((bool)particleTrailRenderer)
			{
				particleTrailRenderer.Clear();
			}
		}

		private void Update()
		{
			Simulate((_timeScale == TimeScale.Normal) ? Time.deltaTime : Time.unscaledDeltaTime);
			if (!noiseEnabled || !_noiseDebug)
			{
				return;
			}
			int num = _noiseViewSize.x / 2;
			int num2 = _noiseViewSize.y / 2;
			for (int i = -num; i < num; i++)
			{
				for (int j = -num2; j < num2; j++)
				{
					Vector3 vector = new Vector3(i * 10, j * 10, 0f);
					float num3 = _noise.GetNoise(vector.x + noiseOffset.x, vector.y + noiseOffset.y);
					if (space == Simulation.World)
					{
						num3 = _noise.GetNoise(vector.x + base.transform.localPosition.x + noiseOffset.x, vector.y + base.transform.localPosition.y + noiseOffset.y);
					}
					Debug.DrawLine(RotatePointAroundCenter((vector + base.transform.localPosition) * canvasRect.localScale.x, canvasRect.eulerAngles) + canvasRect.position, RotatePointAroundCenter((vector + base.transform.localPosition + new Vector3(Mathf.Cos(num3 * MathF.PI), Mathf.Sin(num3 * MathF.PI)) * 10f) * canvasRect.localScale.x, canvasRect.eulerAngles) + canvasRect.position, new Color(num3, num3.Remap(-1f, 1f, 1f, 0f), 0f));
				}
			}
		}

		private Vector3 RotatePointAroundCenter(Vector3 point, Vector3 angles)
		{
			return Quaternion.Euler(angles) * point;
		}

		private void UpdateSheets()
		{
			sheetsArray = new NativeArray<SpriteSheet>(textureTile.x * textureTile.y, multithreadEnabled ? Allocator.TempJob : Allocator.Temp);
			if (textureSheetEnabled)
			{
				for (int num = textureTile.y - 1; num > -1; num--)
				{
					for (int i = 0; i < textureTile.x; i++)
					{
						sheetsArray[(textureTile.y - 1 - num) * textureTile.x + i] = new SpriteSheet(new Vector2(1f / (float)textureTile.x * (float)(i + 1), 1f / (float)textureTile.y * (float)(num + 1)), new Vector2(1f / (float)textureTile.x * (float)i, 1f / (float)textureTile.y * (float)num));
					}
				}
			}
			else if (sprite != null)
			{
				Vector4 outerUV = DataUtility.GetOuterUV(sprite);
				sheetsArray[0] = new SpriteSheet(new Vector2(outerUV[2], outerUV[3]), new Vector2(outerUV[0], outerUV[1]));
			}
			else
			{
				sheetsArray[0] = new SpriteSheet(new Vector2(1f, 1f), new Vector2(0f, 0f));
			}
		}

		private void Prewarm()
		{
			int num = Mathf.FloorToInt(duration * 2f / 0.01f);
			for (int i = 0; i < num; i++)
			{
				Simulate(0.01f, prewarming: true);
			}
		}

		private void Simulate(float deltaTime, bool prewarming = false)
		{
			if (isEmitting && !base.canvasRenderer.cull)
			{
				if (_rate > 0f && (_time < _duration + _startDelay || _loop) && _time > _startDelay)
				{
					float num = 1f / _rate;
					_t += deltaTime;
					while (_t >= num)
					{
						_t -= num;
						_orderPerSec++;
						if (!multithreadEnabled)
						{
							_particles.Add(GenerateParticle(_orderPerSec, 1, null, _t));
						}
					}
				}
				if (_rateOverLifetime > 0f && _duration > 0f && (_time < _duration + _startDelay || _loop) && _time >= _startDelay)
				{
					float num2 = _duration / _rateOverLifetime;
					_t2 += deltaTime;
					while (_t2 >= num2)
					{
						_t2 -= num2;
						_orderOverLife++;
						if (!multithreadEnabled)
						{
							_particles.Add(GenerateParticle(_orderOverLife, 2, null, _t2));
						}
					}
				}
				if (_rateOverDistance > 0f && _deltaPosition.magnitude > 1f / _rateOverDistance)
				{
					_orderOverDistance++;
					if (!multithreadEnabled)
					{
						_particles.Add(GenerateParticle(_orderOverDistance, 3, null, 0f));
					}
					_lastPosition = base.transform.position;
				}
				if (_bursts != null)
				{
					for (int i = 0; i < _bursts.Count; i++)
					{
						if (!(_burstTimer >= _bursts[i].time + _startDelay) || _bursts[i].used)
						{
							continue;
						}
						for (int j = 0; j < _bursts[i].count; j++)
						{
							if (!multithreadEnabled)
							{
								_particles.Add(GenerateParticle(j, 0, _bursts[i], 0f));
							}
						}
						_bursts[i].used = true;
					}
				}
				if (_loop && _burstTimer >= _duration)
				{
					_burstTimer = 0f;
					for (int k = 0; k < _bursts.Count; k++)
					{
						_bursts[k].used = false;
					}
				}
				if (_time >= _duration + _startDelay && !_loop)
				{
					isEmitting = false;
				}
				if (_loop && _loopTimer >= _duration + _startDelay)
				{
					_loopTimer = 0f;
					_orderPerSec = 0;
					_orderOverLife = 0;
					_orderOverDistance = 0;
				}
			}
			if (isPlaying && particleCount <= 0 && !isEmitting && isMain && CanStop)
			{
				Stop(stopAndClear: true);
			}
			if (!isPlaying)
			{
				return;
			}
			_deltaPosition = base.transform.position - _lastPosition;
			if ((bool)_emitterConstraintTransform && _emitterConstraintEnabled.enabled)
			{
				if (_emitterConstraintTransform is RectTransform)
				{
					base.transform.position = _emitterConstraintTransform.position;
				}
				else
				{
					Vector3 vector = mainCamera.WorldToViewportPoint(_emitterConstraintTransform.position);
					Vector3 position = new Vector3(vector.x.Remap(0.5f, 1.5f, 0f, canvasRect.rect.width), vector.y.Remap(0.5f, 1.5f, 0f, canvasRect.rect.height), 0f);
					position = canvasRect.transform.TransformPoint(position);
					position = base.transform.parent.InverseTransformPoint(position);
					base.transform.localPosition = position;
				}
			}
			if (!prewarming)
			{
				_playback += deltaTime;
			}
			_time += deltaTime;
			_loopTimer += deltaTime;
			_burstTimer += deltaTime;
			UpdateSheets();
			if (trailsEnabled)
			{
				int num3 = 0;
				for (int l = 0; l < _particles.Count; l++)
				{
					num3 += _particles[l].trailPoints.Count;
				}
				particleTrailRenderer.PrepareMeshData(num3, _particles.Count);
			}
			NativeArray<Vector3> vertices = new NativeArray<Vector3>(particles.Count * 4, Allocator.Temp);
			NativeArray<int> indices = new NativeArray<int>(particles.Count * 6, Allocator.Temp);
			NativeArray<Vector2> uvs = new NativeArray<Vector2>(particles.Count * 4, Allocator.Temp);
			NativeArray<Color> colors = new NativeArray<Color>(particles.Count * 4, Allocator.Temp);
			int num4 = 0;
			int num5 = 0;
			for (int num6 = particles.Count - 1; num6 >= 0; num6--)
			{
				_particles[num6].Simulate(deltaTime);
				if (!(_particles[num6].TimeSinceBorn > _particles[num6].Lifetime || prewarming))
				{
					vertices[num4] = particles[num6].points[0];
					vertices[num4 + 1] = particles[num6].points[1];
					vertices[num4 + 2] = particles[num6].points[2];
					vertices[num4 + 3] = particles[num6].points[3];
					indices[num5] = num4;
					indices[num5 + 1] = num4 + 2;
					indices[num5 + 2] = num4 + 1;
					indices[num5 + 3] = num4;
					indices[num5 + 4] = num4 + 3;
					indices[num5 + 5] = num4 + 2;
					uvs[num4] = sheetsArray[particles[num6].GetSheetId].size;
					uvs[num4 + 1] = new Vector2(sheetsArray[particles[num6].GetSheetId].pos.x, sheetsArray[particles[num6].GetSheetId].size.y);
					uvs[num4 + 2] = sheetsArray[particles[num6].GetSheetId].pos;
					uvs[num4 + 3] = new Vector2(sheetsArray[particles[num6].GetSheetId].size.x, sheetsArray[particles[num6].GetSheetId].pos.y);
					colors[num4] = particles[num6].Color;
					colors[num4 + 1] = particles[num6].Color;
					colors[num4 + 2] = particles[num6].Color;
					colors[num4 + 3] = particles[num6].Color;
					num4 += 4;
					num5 += 6;
				}
			}
			if (particles.Count > 0)
			{
				mesh.Clear();
				if (vertices.Length > 0)
				{
					mesh.SetVertices(vertices);
					mesh.SetIndices(indices, MeshTopology.Triangles, 0);
					mesh.SetUVs(0, uvs);
					mesh.SetColors(colors);
				}
			}
			mesh.RecalculateBounds();
			base.canvasRenderer.SetMesh(mesh);
			if (trailsEnabled)
			{
				particleTrailRenderer.SetMeshData();
			}
			for (int num7 = particles.Count - 1; num7 >= 0; num7--)
			{
				if (_particles[num7].TimeSinceBorn > _particles[num7].Lifetime && (_particles[num7].trailPoints.Count <= 1 || _dieWithParticle))
				{
					OnAnyParticleFinished();
					pool.Release(_particles[num7]);
					_particles.RemoveAt(num7);
					if (!_firstParticleFinished)
					{
						_firstParticleFinished = true;
						OnFirstParticleFinished();
					}
					if (particleCount < 1)
					{
						OnLastParticleFinished();
					}
				}
			}
		}

		public void AddBurst(float time, int count)
		{
			_bursts.Add(new Burst(time, count));
		}

		public void RemoveBurst(int index)
		{
			_bursts.RemoveAt(index);
		}

		public void SetBurst(int index, float time, int count)
		{
			if (_bursts.Count > index)
			{
				_bursts[index] = new Burst(time, count);
			}
		}

		private Vector2 GetPointOnRect(float angle, float w, float h)
		{
			float num = Mathf.Sin(angle);
			float num2 = Mathf.Cos(angle);
			float num3 = ((num > 0f) ? (h / 2f) : (h / -2f));
			float num4 = ((num2 > 0f) ? (w / 2f) : (w / -2f));
			if (Mathf.Abs(num4 * num) < Mathf.Abs(num3 * num2))
			{
				num3 = num4 * num / num2;
			}
			else
			{
				num4 = num3 * num2 / num;
			}
			return new Vector2(num4, num3);
		}

		private Particle GenerateParticle(int order, int source, Burst burst, float startTime)
		{
			float num = 0f;
			switch (source)
			{
			case 0:
				num = (float)order * (360f / (float)burst.count) * _spreadLoop;
				break;
			case 1:
				num = (float)order * (360f / _rate) / _duration * _spreadLoop;
				break;
			case 2:
				num = (float)order * (360f / _rateOverLifetime) * _spreadLoop;
				break;
			case 3:
				num = (float)order * (360f / _rateOverDistance) / _duration * _spreadLoop;
				break;
			}
			Vector2 startPosition = Vector2.zero;
			switch (_shape)
			{
			case EmitterShape.Point:
				startPosition = Vector2.zero;
				break;
			case EmitterShape.Circle:
				if (_emitOnSurface)
				{
					startPosition = ((_spread != SpreadType.Random) ? ((Vector2)(RotateOnAngle(new Vector3(0f, UnityEngine.Random.Range(0f, 1f), 0f), num) * _radius)) : (UnityEngine.Random.insideUnitCircle * _radius));
				}
				else if (_spread == SpreadType.Random)
				{
					Vector2 normalized = UnityEngine.Random.insideUnitCircle.normalized;
					startPosition = Vector3.Lerp(normalized * _radius, normalized * (_radius - _emitterThickness), UnityEngine.Random.value);
				}
				else
				{
					startPosition = RotateOnAngle(new Vector3(0f, 1f, 0f), num) * UnityEngine.Random.Range(_radius, _radius - _emitterThickness);
				}
				break;
			case EmitterShape.Rectangle:
			{
				if (_emitOnSurface)
				{
					startPosition = ((_spread != SpreadType.Uniform) ? ((Vector2)new Vector3(UnityEngine.Random.Range((0f - _width) / 2f, _width / 2f), UnityEngine.Random.Range((0f - _height) / 2f, _height / 2f))) : Vector2.Lerp(GetPointOnRect(num * (MathF.PI / 180f), _width, _height), Vector2.one, UnityEngine.Random.value));
					break;
				}
				float num2 = UnityEngine.Random.Range(0f, 360f);
				if (_spread == SpreadType.Uniform)
				{
					num2 = num;
				}
				startPosition = Vector2.Lerp(GetPointOnRect(num2 * (MathF.PI / 180f), _width, _height), GetPointOnRect(num2 * (MathF.PI / 180f), _width - _emitterThickness, _height - _emitterThickness), UnityEngine.Random.value);
				break;
			}
			case EmitterShape.Line:
				startPosition = ((_spread != SpreadType.Uniform) ? ((Vector2)new Vector3(UnityEngine.Random.Range((0f - _length) / 2f, _length / 2f), 0f)) : ((Vector2)new Vector3(Mathf.Repeat(num, 361f).Remap(0f, 360f, (0f - _length) / 2f, _length / 2f), 0f)));
				break;
			case EmitterShape.Directional:
				startPosition = Vector3.zero;
				break;
			}
			_ = space;
			_ = 1;
			Vector3 vector = Vector3.zero;
			switch (_shape)
			{
			case EmitterShape.Point:
				vector = ((_spread != SpreadType.Uniform) ? ((Vector3)(UnityEngine.Random.insideUnitCircle.normalized * _startSpeed.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value))) : (RotateOnAngle(new Vector3(0f, 1f, 0f), num) * _startSpeed.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value)));
				break;
			case EmitterShape.Circle:
				vector = startPosition.normalized * _startSpeed.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value);
				break;
			case EmitterShape.Rectangle:
				vector = startPosition.normalized * _startSpeed.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value);
				break;
			case EmitterShape.Line:
				vector = ((space == Simulation.World) ? base.transform.up : Vector3.up) * _startSpeed.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value);
				break;
			case EmitterShape.Directional:
			{
				float num3 = 0f;
				num3 = ((space == Simulation.World) ? ((_spread != SpreadType.Uniform) ? (UnityEngine.Random.Range((0f - _angle) / 2f, _angle / 2f) - base.transform.eulerAngles.z) : (Mathf.Repeat(num, 361f).Remap(0f, 360f, (0f - _angle) / 2f, _angle / 2f) - base.transform.eulerAngles.z)) : ((_spread != SpreadType.Uniform) ? UnityEngine.Random.Range((0f - _angle) / 2f, _angle / 2f) : Mathf.Repeat(num, 361f).Remap(0f, 360f, (0f - _angle) / 2f, _angle / 2f)));
				vector = RotateOnAngle(num3) * _startSpeed.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value);
				break;
			}
			}
			Particle particle = pool.Get();
			particle.Initialize(startPosition, vector, _startRotation.EvaluateZ(UnityEngine.Random.value, UnityEngine.Random.value), _startColor.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value), _startSize.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value), _lifetime.Evaluate(UnityEngine.Random.value, UnityEngine.Random.value), startTime);
			return particle;
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			if (fitRect)
			{
				FitRect();
			}
			if (!_emitOnSurface)
			{
				switch (_shape)
				{
				case EmitterShape.Circle:
					_emitterThickness = Mathf.Clamp(_emitterThickness, 0f, _radius);
					break;
				case EmitterShape.Rectangle:
					_emitterThickness = Mathf.Clamp(_emitterThickness, 0f, (base.rectTransform.sizeDelta.x < base.rectTransform.sizeDelta.y) ? _width : _height);
					break;
				case EmitterShape.Line:
					_emitterThickness = Mathf.Clamp(_emitterThickness, 0f, _radius);
					break;
				}
			}
		}

		private void FitRect()
		{
			switch (_shape)
			{
			case EmitterShape.Circle:
				if (base.rectTransform.rect.width > base.rectTransform.rect.height)
				{
					_radius = base.rectTransform.rect.height / 2f;
				}
				else
				{
					_radius = base.rectTransform.rect.width / 2f;
				}
				break;
			case EmitterShape.Rectangle:
				_width = base.rectTransform.rect.width;
				_height = base.rectTransform.rect.height;
				break;
			case EmitterShape.Line:
				_length = base.rectTransform.rect.width;
				break;
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		protected override void UpdateGeometry()
		{
		}

		private Vector3 RotateOnAngle(float angle)
		{
			float f = angle * (MathF.PI / 180f);
			return new Vector3(Mathf.Sin(f), Mathf.Cos(f), 0f) * 1f;
		}

		private Vector3 RotateOnAngle(Vector3 p, float angle)
		{
			return Quaternion.Euler(new Vector3(0f, 0f, angle)) * p;
		}

		public Vector3 WorldToViewportPoint(Vector3 position)
		{
			return mainCamera.WorldToViewportPoint(position);
		}

		private void OnParticleStart()
		{
			onParticleStarted.Invoke();
		}

		private void OnFirstParticleFinished()
		{
			onFirstParticleFinished.Invoke();
		}

		private void OnAnyParticleFinished()
		{
			onAnyParticleFinished.Invoke();
		}

		private void OnLastParticleFinished()
		{
			onLastParticleFinished.Invoke();
		}

		private void OnParticleStop()
		{
			onParticleStop.Invoke();
		}
	}
}
