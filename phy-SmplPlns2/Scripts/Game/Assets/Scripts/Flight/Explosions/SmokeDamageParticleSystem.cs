using System.Collections.Generic;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class SmokeDamageParticleSystem : MonoBehaviour
	{
		[SerializeField]
		private float _emissionRatePerEmitter;

		[SerializeField]
		private float _emissionRatePerPosition;

		[SerializeField]
		private float _emissionRateQualityLowMultiplier = 1f;

		[SerializeField]
		private float _maximumNumberOfDamagePositions = 10f;

		[SerializeField]
		private float _minimumDistanceBetweenDamagePositions = 5f;

		private ParticleSystem.ShapeModule _shape;

		protected float BaseLifetime { get; private set; }

		protected Mesh DamageMesh { get; private set; }

		protected List<SmokeDamageParticleSystemPosition> DamagePositions { get; private set; }

		protected float EmissionRatePerEmitter => _emissionRatePerEmitter;

		protected float EmissionRatePerPosition => _emissionRatePerPosition;

		protected ParticleSystem SmokeParticles { get; private set; }

		public SmokeDamageParticleSystemPosition AddDamagePosition(Vector3 position, Vector3 normal, float size, int emitterCount)
		{
			float num = _minimumDistanceBetweenDamagePositions * _minimumDistanceBetweenDamagePositions;
			for (int i = 0; i < DamagePositions.Count; i++)
			{
				SmokeDamageParticleSystemPosition smokeDamageParticleSystemPosition = DamagePositions[i];
				if ((position - smokeDamageParticleSystemPosition.Position).sqrMagnitude < num)
				{
					return null;
				}
			}
			if ((float)DamagePositions.Count == _maximumNumberOfDamagePositions)
			{
				DamagePositions.RemoveAt(0);
			}
			SmokeDamageParticleSystemPosition smokeDamageParticleSystemPosition2 = new SmokeDamageParticleSystemPosition(position, normal, size, emitterCount, this);
			DamagePositions.Add(smokeDamageParticleSystemPosition2);
			UpdateSystem();
			return smokeDamageParticleSystemPosition2;
		}

		public void SetLifetimeScale(float scale)
		{
			ParticleSystem.MainModule main = SmokeParticles.main;
			main.startLifetime = new ParticleSystem.MinMaxCurve(BaseLifetime * scale);
		}

		public void UpdateSystem()
		{
			UpdateDamageMesh();
			UpdateEmissions();
		}

		protected virtual void Awake()
		{
			SmokeParticles = GetComponent<ParticleSystem>();
			DamagePositions = new List<SmokeDamageParticleSystemPosition>();
			DamageMesh = new Mesh();
		}

		protected virtual void OnDestroy()
		{
			Object.Destroy(DamageMesh);
		}

		protected virtual void Start()
		{
			BaseLifetime = SmokeParticles.main.startLifetime.constant;
			UpdateDamageMesh();
			ParticleSystem.EmissionModule emission = SmokeParticles.emission;
			emission.enabled = false;
			emission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
			_shape = SmokeParticles.shape;
			MeshFilter firstChild = Utilities.GetFirstChild<MeshFilter>("SmokeDamageDebugMesh", this);
			if (firstChild != null)
			{
				firstChild.mesh = DamageMesh;
			}
			SmokeParticles.Play();
		}

		private float GetEmissionRateMultiplier()
		{
			if (!Game.Instance.Device.IsMobileBuild)
			{
				return 1f;
			}
			return _emissionRateQualityLowMultiplier;
		}

		private void UpdateDamageMesh()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < DamagePositions.Count; i++)
			{
				SmokeDamageParticleSystemPosition smokeDamageParticleSystemPosition = DamagePositions[i];
				if (smokeDamageParticleSystemPosition.Enabled)
				{
					num += smokeDamageParticleSystemPosition.VertexCount;
					num2 += smokeDamageParticleSystemPosition.EmitterCount * 3;
				}
			}
			Vector3[] array = new Vector3[num];
			Vector3[] normals = new Vector3[num];
			int[] triangles = new int[num2];
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			for (int j = 0; j < DamagePositions.Count; j++)
			{
				SmokeDamageParticleSystemPosition smokeDamageParticleSystemPosition2 = DamagePositions[j];
				if (smokeDamageParticleSystemPosition2.Enabled)
				{
					smokeDamageParticleSystemPosition2.UpdateMesh(array, normals, triangles, num3, num4, num5);
					num3 += smokeDamageParticleSystemPosition2.VertexCount;
					num4 += smokeDamageParticleSystemPosition2.VertexCount;
					num5 += smokeDamageParticleSystemPosition2.EmitterCount * 3;
				}
			}
			ParticleSystem.ShapeModule shape = SmokeParticles.shape;
			if (array.Length == 0)
			{
				shape.enabled = false;
				return;
			}
			DamageMesh.triangles = null;
			DamageMesh.vertices = array;
			DamageMesh.normals = normals;
			DamageMesh.triangles = triangles;
			shape.enabled = true;
		}

		private void UpdateEmissions()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < DamagePositions.Count; i++)
			{
				SmokeDamageParticleSystemPosition smokeDamageParticleSystemPosition = DamagePositions[i];
				if (smokeDamageParticleSystemPosition.Enabled)
				{
					num++;
					num2 += smokeDamageParticleSystemPosition.EmitterCount;
				}
			}
			ParticleSystem.EmissionModule emission = SmokeParticles.emission;
			emission.rateOverTime = new ParticleSystem.MinMaxCurve(((float)num * EmissionRatePerPosition + (float)num2 * EmissionRatePerEmitter) * GetEmissionRateMultiplier());
			bool flag = num > 0;
			if (!flag && emission.enabled && SmokeParticles.particleCount == 0)
			{
				emission.enabled = false;
			}
			else if (flag && !emission.enabled)
			{
				emission.enabled = true;
				if (_shape.mesh == null && DamageMesh.vertices.Length != 0)
				{
					_shape.mesh = DamageMesh;
				}
			}
		}
	}
}
