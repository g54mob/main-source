using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class VolumetricExplosionScript : MonoBehaviour
	{
		[SerializeField]
		private bool _debugRepeat;

		[SerializeField]
		private float _duration = 12f;

		[SerializeField]
		private float _fadeStart = 0.5f;

		[SerializeField]
		private bool _hasParticles = true;

		private Light _light;

		[SerializeField]
		private AnimationCurve _lightCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		private GameObject _lightGameObject;

		private Transform _lightTransform;

		private Material _material;

		[SerializeField]
		[Tooltip("Bounds covering the maximum possible area of the explosion in mesh space. This should NOT be adjusted for scale.")]
		private Bounds _maxMeshBounds = new Bounds(Vector3.zero, Vector3.one);

		private MeshFilter _meshFilter;

		private float _particleStart = 0.5f;

		private bool _particlesTriggered;

		private ParticleSystem _particleSystem;

		[SerializeField]
		[Range(0f, 2f)]
		private float _raiseAmount = 0.9f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _shroom = 0.7f;

		[SerializeField]
		private bool _stem = true;

		[SerializeField]
		private float _time;

		[SerializeField]
		private AnimationCurve _timeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private float _voronoiIntensity = 2f;

		public float Duration
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

		public float FadeStart
		{
			get
			{
				return _fadeStart;
			}
			set
			{
				_fadeStart = value;
			}
		}

		public float RaiseAmount
		{
			get
			{
				return _raiseAmount;
			}
			set
			{
				_raiseAmount = value;
			}
		}

		public float Shroom
		{
			get
			{
				return _shroom;
			}
			set
			{
				_shroom = Mathf.Clamp01(value);
			}
		}

		public bool Stem
		{
			get
			{
				return _stem;
			}
			set
			{
				_stem = value;
			}
		}

		public float VoronoiIntensity
		{
			get
			{
				return _voronoiIntensity;
			}
			set
			{
				_voronoiIntensity = value;
			}
		}

		[ContextMenu("Restart Explosion")]
		public void Restart()
		{
			_time = 0f;
			UpdateMaterialPropertiesAndSome();
			if (_particleSystem != null && _particleSystem.isPlaying)
			{
				_particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			}
		}

		[ContextMenu("Update Material Properties")]
		public void UpdateMaterialPropertiesAndSome()
		{
			_material.SetFloat("_RaiseAmount", _raiseAmount);
			_material.SetFloat("_Shroom", _shroom);
			_material.SetFloat("_FadeStart", _fadeStart);
			_material.SetInt("_Stem", _stem ? 1 : 0);
			_material.SetFloat("_VoronoiIntensity", _voronoiIntensity);
			string path = "Flight/Explosions/ExplosionVoronoi" + Random.Range(1, 5);
			_material.SetTexture("_VoronoiTexture", Resources.Load<Texture>(path));
			_particleStart = _fadeStart - _fadeStart * 0.1f;
		}

		protected void Start()
		{
			_meshFilter = GetComponent<MeshFilter>();
			_material = GetComponent<MeshRenderer>().material;
			_meshFilter.mesh.bounds = _maxMeshBounds;
			_light = GetComponentInChildren<Light>();
			_lightGameObject = _light.gameObject;
			_lightTransform = _light.transform;
			UpdateMaterialPropertiesAndSome();
			base.transform.Rotate(Vector3.up, Random.value * 360f);
			if (_hasParticles)
			{
				_particleSystem = GetComponentInChildren<ParticleSystem>();
			}
		}

		protected void Update()
		{
			if (_duration > 0f)
			{
				_time += Time.deltaTime / _duration;
			}
			if (_debugRepeat)
			{
				float time = _time;
				_time %= 1f;
				if (time > _time && _particleSystem != null)
				{
					_particlesTriggered = false;
					_particleSystem.Stop();
				}
			}
			float num = Mathf.Clamp01(_timeCurve.Evaluate(_time));
			_material.SetFloat("_Time01", num);
			float num2 = _lightCurve.Evaluate(num);
			_light.intensity = num2 * 1000f * base.transform.localScale.y;
			_light.range = 100f * base.transform.localScale.y;
			_light.colorTemperature = num2 * 6000f;
			if (_lightGameObject.activeSelf && Mathf.Approximately(_light.intensity, 0f))
			{
				_lightGameObject.SetActive(value: false);
			}
			else if (!_lightGameObject.activeSelf && _light.intensity > 0f)
			{
				_lightGameObject.SetActive(value: true);
			}
			_lightTransform.localPosition = new Vector3(0f, num * 8f * _raiseAmount, 0f);
			if (_particleSystem != null && !_particlesTriggered && num >= _particleStart)
			{
				_particleSystem.transform.localPosition = 4.2f * Mathf.Clamp01(Mathf.Lerp(0f, _raiseAmount, num / _particleStart)) * Vector3.up;
				ParticleSystem.MainModule main = _particleSystem.main;
				main.duration = _duration;
				ParticleSystem.MinMaxCurve startLifetime = main.startLifetime;
				startLifetime.constantMin = _duration * 0.666f;
				startLifetime.constantMax = _duration * 0.833f;
				main.startLifetime = startLifetime;
				_particleSystem.Play();
				_particlesTriggered = true;
			}
		}
	}
}
