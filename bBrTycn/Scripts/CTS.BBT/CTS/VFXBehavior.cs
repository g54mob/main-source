using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class VFXBehavior : MonoBehaviour
	{
		[Serializable]
		private class ShaderCopyPosition : RendererUpdater
		{
			[SerializeField]
			private ShaderVariable _shaderVar;

			[SerializeField]
			private Transform _target;

			public override void Execute()
			{
				MaterialLoop();
			}

			protected override void ForEachMaterial(Material material)
			{
				material.SetVector(_shaderVar, _target.position);
			}
		}

		[Serializable]
		private class ShaderCopyWorldToObject : RendererUpdater
		{
			[SerializeField]
			private ShaderVariable _shaderVar;

			[SerializeField]
			private Transform _target;

			public override void Execute()
			{
				MaterialLoop();
			}

			protected override void ForEachMaterial(Material material)
			{
				material.SetMatrix(_shaderVar, _target.worldToLocalMatrix);
			}
		}

		[Serializable]
		private class ShaderSetRandomInt : RendererUpdater
		{
			[SerializeField]
			private ShaderVariable _shaderVar;

			[SerializeField]
			[MinMaxSlider(0f, 100f)]
			private Vector2Int _randomRange;

			private int _random;

			public override void Execute()
			{
				_random = UnityEngine.Random.Range(_randomRange.x, _randomRange.y);
				MaterialLoop();
			}

			protected override void ForEachMaterial(Material material)
			{
				material.SetInt(_shaderVar, _random);
			}
		}

		[Serializable]
		public class ObjectCopyTransform : VFXUpdater
		{
			[SerializeField]
			private Transform _object;

			[SerializeField]
			private SoftReference<Transform> _objectToFollow;

			[SerializeField]
			[ShowIf("_updatePosition")]
			private Vector3 _positionOffset;

			[SerializeField]
			private bool _updatePosition;

			[SerializeField]
			private bool _updateRotation;

			public override void Execute()
			{
				Transform transform = _objectToFollow.Get();
				if (!(transform == null))
				{
					if (_updatePosition)
					{
						_object.position = transform.position + _positionOffset;
					}
					if (_updateRotation)
					{
						_object.rotation = transform.rotation;
					}
				}
			}

			public void SetTarget(Transform target)
			{
				_objectToFollow = SoftReference.Create(target);
			}
		}

		[Serializable]
		private class ParticleCopyColliderShape : ParticleUpdater
		{
			[SerializeField]
			private Collider _collider;

			[SerializeField]
			[ShowIf("ColliderIsNull")]
			private bool _getColliderOnParent;

			public override void Execute()
			{
				if (!_collider)
				{
					if (_getColliderOnParent)
					{
						_collider = ParticleSystem.GetComponentInParent<Collider>();
					}
					else
					{
						_collider = ParticleSystem.GetComponent<Collider>();
					}
				}
				_ = (bool)_collider;
				Collider collider = _collider;
				if (!(collider is BoxCollider))
				{
					_ = collider is SphereCollider;
					return;
				}
				ParticleSystem.ShapeModule shape = ParticleSystem.shape;
				shape.shapeType = ParticleSystemShapeType.Box;
				shape.position = ParticleSystem.transform.InverseTransformPoint(_collider.bounds.center);
				shape.scale = _collider.bounds.size;
			}
		}

		[SerializeField]
		private ParticleSystem[] _particleSystems;

		[SerializeReference]
		[ArrayElementTitle]
		private VFXUpdater[] _updaters = Array.Empty<VFXUpdater>();

		private void PlayParticle(int index)
		{
			index = index.ClampIndex(_particleSystems);
			_particleSystems[index].Play();
		}

		private void StopParticles(int index)
		{
			index = index.ClampIndex(_particleSystems);
			_particleSystems[index].Stop();
		}

		public bool TryGetUpdater<TType>(out TType outUpdater) where TType : VFXUpdater
		{
			VFXUpdater[] updaters = _updaters;
			for (int i = 0; i < updaters.Length; i++)
			{
				if (updaters[i] is TType val)
				{
					outUpdater = val;
					return true;
				}
			}
			outUpdater = null;
			return false;
		}

		public CastArrayEnumerator<VFXUpdater, TType> Updaters<TType>()
		{
			return new CastArrayEnumerator<VFXUpdater, TType>(_updaters);
		}

		public List<TType> GetUpdaters<TType>() where TType : VFXUpdater
		{
			List<TType> list = new List<TType>();
			VFXUpdater[] updaters = _updaters;
			for (int i = 0; i < updaters.Length; i++)
			{
				if (updaters[i] is TType item)
				{
					list.Add(item);
				}
			}
			return list;
		}

		private void Awake()
		{
			VFXUpdater[] updaters = _updaters;
			for (int i = 0; i < updaters.Length; i++)
			{
				updaters[i].Setup();
			}
		}

		private void OnEnable()
		{
			VFXUpdater[] updaters = _updaters;
			foreach (VFXUpdater vFXUpdater in updaters)
			{
				if (vFXUpdater.Enabled)
				{
					UpdaterEnabled(vFXUpdater);
				}
			}
		}

		private void UpdaterEnabled(VFXUpdater updater)
		{
			updater.OnEnable();
			if (updater.OnStartOnly && updater.Delay != 0f)
			{
				StartCoroutine(DelayedExecute(updater));
			}
			else
			{
				updater.Execute();
			}
		}

		private IEnumerator DelayedExecute(VFXUpdater updater)
		{
			if (updater.Delay < 0f)
			{
				yield return null;
			}
			else
			{
				yield return Coroutines.WaitForSeconds(updater.Delay);
			}
			updater.Execute();
		}

		private void Update()
		{
			VFXUpdater[] updaters = _updaters;
			foreach (VFXUpdater vFXUpdater in updaters)
			{
				if (!vFXUpdater.OnStartOnly && vFXUpdater.Enabled)
				{
					vFXUpdater.Execute();
				}
			}
		}

		private void EnableBehavior(int index)
		{
			index = index.ClampIndex(_updaters);
			_updaters[index].Enabled = true;
			UpdaterEnabled(_updaters[index]);
		}

		private void UpdateBehavior(int index)
		{
			index = index.ClampIndex(_updaters);
			_updaters[index].Execute();
		}

		private void DisableBehavior(int index)
		{
			index = index.ClampIndex(_updaters);
			_updaters[index].Enabled = false;
		}
	}
}
