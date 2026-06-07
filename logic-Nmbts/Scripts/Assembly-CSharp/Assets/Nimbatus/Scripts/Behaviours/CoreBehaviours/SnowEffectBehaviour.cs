using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class SnowEffectBehaviour : CoreBehaviour
	{
		public GameObject SnowParticleSystem;

		private float _maxScale;

		private bool _stopCoroutine;

		private List<ParticleSystem> _particleSystems;

		private Bounds _bound;

		private Camera _camera;

		private Plane[] _planes;

		protected override void OnInit()
		{
			_stopCoroutine = false;
			OwnWorldObject.StartCoroutine(ScaleCoroutine());
			_maxScale = (float)WorldController.TerrainSettings.PlanetSize * 2f;
			_camera = Camera.main;
			_planes = new Plane[6];
			_particleSystems = new List<ParticleSystem>();
			int num = 24;
			float num2 = (float)WorldController.TerrainSettings.PlanetSize * 1.4f;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(SnowParticleSystem);
				float f = (float)Math.PI * 2f / (float)num * (float)i;
				gameObject.transform.position = new Vector3(OwnWorldObject.transform.position.x + Mathf.Cos(f) * num2, OwnWorldObject.transform.position.x + Mathf.Sin(f) * num2, 0f);
				gameObject.transform.parent = OwnWorldObject.transform;
				_particleSystems.Add(gameObject.GetComponentInChildren<ParticleSystem>());
			}
			foreach (ParticleSystem particleSystem in _particleSystems)
			{
				particleSystem.Play();
			}
		}

		private IEnumerator ScaleCoroutine()
		{
			while (!_stopCoroutine)
			{
				yield return null;
			}
		}

		protected override void OnUpdate()
		{
			_planes = GeometryUtility.CalculateFrustumPlanes(_camera);
			foreach (ParticleSystem particleSystem in _particleSystems)
			{
				Color color = Color.red;
				_bound = new Bounds(particleSystem.transform.position, new Vector3(300f, 300f, 1f));
				if (GeometryUtility.TestPlanesAABB(_planes, _bound))
				{
					particleSystem.Play();
					color = Color.green;
				}
				else
				{
					particleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
				}
				Vector3 vector = new Vector3(_bound.center.x - _bound.extents.x, _bound.center.y + _bound.extents.y, _bound.center.z);
				Vector3 vector2 = new Vector3(_bound.center.x + _bound.extents.x, _bound.center.y + _bound.extents.y, _bound.center.z);
				Vector3 vector3 = new Vector3(_bound.center.x + _bound.extents.x, _bound.center.y - _bound.extents.y, _bound.center.z);
				Vector3 vector4 = new Vector3(_bound.center.x - _bound.extents.x, _bound.center.y - _bound.extents.y, _bound.center.z);
				Debug.DrawLine(vector, vector2, color);
				Debug.DrawLine(vector2, vector3, color);
				Debug.DrawLine(vector3, vector4, color);
				Debug.DrawLine(vector4, vector, color);
			}
		}

		protected override void OnRelease()
		{
			_stopCoroutine = false;
		}
	}
}
