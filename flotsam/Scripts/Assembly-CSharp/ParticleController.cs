using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Flotsam/Particle Controller")]
public class ParticleController : MonoBehaviour
{
	[SerializeField]
	private bool _ignoreChildren;

	private bool _poolingEnaled;

	private bool _isPooled;

	private ParticleController _prefab;

	private ParticleSystem _particleSystem;

	private bool _trackTransform;

	private Transform _trackedTransform;

	private Vector3 _offset;

	private static Dictionary<ParticleController, List<ParticleController>> _pool = new Dictionary<ParticleController, List<ParticleController>>(8);

	public bool IsAlive => _particleSystem.IsAlive(!_ignoreChildren);

	private void Reset()
	{
		if (_particleSystem == null)
		{
			_particleSystem = GetComponent<ParticleSystem>();
		}
	}

	private void Awake()
	{
		_poolingEnaled = true;
		_isPooled = false;
		if (_particleSystem == null)
		{
			_particleSystem = GetComponentInChildren<ParticleSystem>();
		}
	}

	private void Update()
	{
		if (!_isPooled)
		{
			if (_trackTransform)
			{
				base.transform.position = _trackedTransform.position + _trackedTransform.rotation * _offset;
			}
			if (_poolingEnaled && !IsAlive)
			{
				Pool();
			}
		}
	}

	private void OnDestroy()
	{
		if (base.gameObject.scene.isLoaded)
		{
			Debug.LogFormat("ParticleController '{0}' was destroyed", base.name);
		}
	}

	public void Initialize(Transform transformToTrack = null, Vector3 offset = default(Vector3))
	{
		if (_particleSystem == null)
		{
			_particleSystem = GetComponentInChildren<ParticleSystem>();
		}
		if (transformToTrack != null)
		{
			_trackTransform = true;
			_trackedTransform = transformToTrack;
			_offset = offset;
		}
	}

	public ParticleSystem DisablePooling()
	{
		_poolingEnaled = false;
		if (_particleSystem == null)
		{
			_particleSystem = GetComponent<ParticleSystem>();
		}
		ParticleSystem.MainModule main = _particleSystem.main;
		main.playOnAwake = false;
		return _particleSystem;
	}

	public void Play()
	{
		_particleSystem.Play();
	}

	private void Pool()
	{
		if (_prefab == null)
		{
			Debug.LogErrorFormat("Unable to pool ParticleController '{0}' because it has now reference to its prefab", base.name);
			Object.Destroy(base.gameObject);
			return;
		}
		_particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		_trackTransform = false;
		_trackedTransform = null;
		_isPooled = true;
		if (_pool.TryGetValue(_prefab, out var value))
		{
			value.AddUnique(this);
			return;
		}
		_pool.Add(_prefab, new List<ParticleController> { this });
	}

	public static ParticleController Spawn(ParticleController prefab, Transform transform, Vector3 offset)
	{
		ParticleController instance = GetInstance(prefab, transform.position, transform.rotation);
		instance.Initialize(transform, offset);
		return instance;
	}

	public static ParticleController Spawn(ParticleController prefab, Vector3 position, Quaternion rotation)
	{
		ParticleController instance = GetInstance(prefab, position, rotation);
		instance.Initialize();
		return instance;
	}

	private static ParticleController GetInstance(ParticleController prefab, Vector3 position, Quaternion rotation)
	{
		ParticleController particleController;
		if (_pool.TryGetValue(prefab, out var value) && 0 < value.Count)
		{
			int num = value.Count - 1;
			while (0 <= num)
			{
				particleController = value[num];
				value.RemoveAt(num--);
				if ((bool)particleController)
				{
					particleController._isPooled = false;
					particleController.transform.SetPositionAndRotation(position, rotation);
					if (particleController._particleSystem.main.playOnAwake)
					{
						particleController.Play();
					}
					return particleController;
				}
			}
		}
		particleController = Object.Instantiate(prefab, position, rotation);
		particleController._prefab = prefab;
		return particleController;
	}
}
