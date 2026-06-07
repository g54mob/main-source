using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[ExecuteInEditMode]
	[AddComponentMenu("Dreamteck/Splines/Users/Particle Controller")]
	public class ParticleController : SplineUser
	{
		public enum EmitPoint
		{
			Beginning = 0,
			Ending = 1,
			Random = 2,
			Ordered = 3
		}

		public enum MotionType
		{
			None = 0,
			UseParticleSystem = 1,
			FollowForward = 2,
			FollowBackward = 3,
			ByNormal = 4,
			ByNormalRandomized = 5
		}

		public enum Wrap
		{
			Default = 0,
			Loop = 1
		}

		public class Particle
		{
			internal Vector2 startOffset = Vector2.zero;

			internal Vector2 endOffset = Vector2.zero;

			internal float cycleSpeed;

			internal Color startColor = Color.white;

			internal double startPercent;

			internal double GetSplinePercent(Wrap wrap, ParticleSystem.Particle particle, MotionType motionType)
			{
				float num = particle.remainingLifetime / particle.startLifetime;
				if (motionType == MotionType.FollowBackward)
				{
					num = 1f - num;
				}
				switch (wrap)
				{
				case Wrap.Default:
					return DMath.Clamp01(startPercent + (double)((1f - num) * cycleSpeed));
				case Wrap.Loop:
				{
					double num2 = startPercent + (1.0 - (double)num) * (double)cycleSpeed;
					if (num2 > 1.0)
					{
						num2 -= (double)Mathf.FloorToInt((float)num2);
					}
					return num2;
				}
				default:
					return 0.0;
				}
			}
		}

		[SerializeField]
		[HideInInspector]
		private ParticleSystem _particleSystem;

		private ParticleSystemRenderer _renderer;

		[HideInInspector]
		public bool pauseWhenNotVisible;

		[HideInInspector]
		public Vector2 offset = Vector2.zero;

		[HideInInspector]
		public bool volumetric;

		[HideInInspector]
		public bool emitFromShell;

		[HideInInspector]
		public bool apply3DRotation;

		[HideInInspector]
		public Vector2 scale = Vector2.one;

		[HideInInspector]
		public EmitPoint emitPoint;

		[HideInInspector]
		public MotionType motionType = MotionType.UseParticleSystem;

		[HideInInspector]
		public Wrap wrapMode;

		[HideInInspector]
		public float minCycles = 1f;

		[HideInInspector]
		public float maxCycles = 1f;

		private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[0];

		private Particle[] _controllers = new Particle[0];

		private int _particleCount;

		private int _birthIndex;

		private List<Vector4> _customParticleData = new List<Vector4>();

		public ParticleSystem particleSystemComponent
		{
			get
			{
				return _particleSystem;
			}
			set
			{
				_particleSystem = value;
				_renderer = _particleSystem.GetComponent<ParticleSystemRenderer>();
			}
		}

		protected override void LateRun()
		{
			if (_particleSystem == null)
			{
				return;
			}
			if (pauseWhenNotVisible)
			{
				if (_renderer == null)
				{
					_renderer = _particleSystem.GetComponent<ParticleSystemRenderer>();
				}
				if (!_renderer.isVisible)
				{
					return;
				}
			}
			int maxParticles = _particleSystem.main.maxParticles;
			if (_particles.Length != maxParticles)
			{
				_particles = new ParticleSystem.Particle[maxParticles];
				_customParticleData = new List<Vector4>(maxParticles);
				Particle[] array = new Particle[maxParticles];
				for (int i = 0; i < array.Length && i < _controllers.Length; i++)
				{
					array[i] = _controllers[i];
				}
				_controllers = array;
			}
			_particleCount = _particleSystem.GetParticles(_particles);
			_particleSystem.GetCustomParticleData(_customParticleData, ParticleSystemCustomData.Custom1);
			bool flag = _particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.Local;
			Transform transform = _particleSystem.transform;
			for (int j = 0; j < _particleCount; j++)
			{
				if (_controllers[j] == null)
				{
					_controllers[j] = new Particle();
				}
				if (flag)
				{
					TransformParticle(ref _particles[j], transform);
				}
				if (_customParticleData[j].w < 1f)
				{
					OnParticleBorn(j);
				}
				HandleParticle(j);
				if (flag)
				{
					InverseTransformParticle(ref _particles[j], transform);
				}
			}
			_particleSystem.SetCustomParticleData(_customParticleData, ParticleSystemCustomData.Custom1);
			_particleSystem.SetParticles(_particles, _particleCount);
		}

		private void TransformParticle(ref ParticleSystem.Particle particle, Transform trs)
		{
			particle.position = trs.TransformPoint(particle.position);
			_ = apply3DRotation;
			particle.velocity = trs.TransformDirection(particle.velocity);
		}

		private void InverseTransformParticle(ref ParticleSystem.Particle particle, Transform trs)
		{
			particle.position = trs.InverseTransformPoint(particle.position);
			particle.velocity = trs.InverseTransformDirection(particle.velocity);
		}

		protected override void Reset()
		{
			base.Reset();
			updateMethod = UpdateMethod.LateUpdate;
			if (_particleSystem == null)
			{
				_particleSystem = GetComponent<ParticleSystem>();
			}
		}

		private void HandleParticle(int index)
		{
			float num = _particles[index].remainingLifetime / _particles[index].startLifetime;
			if (motionType != MotionType.FollowBackward && motionType != MotionType.FollowForward && motionType != MotionType.None)
			{
				return;
			}
			Evaluate(_controllers[index].GetSplinePercent(wrapMode, _particles[index], motionType), ref evalResult);
			ModifySample(ref evalResult);
			Vector3 right = evalResult.right;
			_particles[index].position = evalResult.position;
			if (apply3DRotation)
			{
				_particles[index].rotation3D = evalResult.rotation.eulerAngles;
			}
			Vector2 vector = offset;
			if (volumetric)
			{
				if (motionType != MotionType.None)
				{
					vector += Vector2.Lerp(_controllers[index].startOffset, _controllers[index].endOffset, 1f - num);
					vector.x *= scale.x;
					vector.y *= scale.y;
				}
				else
				{
					vector += _controllers[index].startOffset;
				}
			}
			_particles[index].position += right * (vector.x * evalResult.size) + evalResult.up * (vector.y * evalResult.size);
			_particles[index].velocity = evalResult.forward;
			_particles[index].startColor = _controllers[index].startColor * evalResult.color;
		}

		private void OnParticleBorn(int index)
		{
			Vector4 value = _customParticleData[index];
			value.w = 1f;
			_customParticleData[index] = value;
			double num = 0.0;
			float num2 = Mathf.Lerp(_particleSystem.emission.rateOverTime.constantMin, _particleSystem.emission.rateOverTime.constantMax, 0.5f) * _particleSystem.main.startLifetime.constantMax;
			_birthIndex++;
			if ((float)_birthIndex > num2)
			{
				_birthIndex = 0;
			}
			switch (emitPoint)
			{
			case EmitPoint.Beginning:
				num = 0.0;
				break;
			case EmitPoint.Ending:
				num = 1.0;
				break;
			case EmitPoint.Random:
				num = Random.Range(0f, 1f);
				break;
			case EmitPoint.Ordered:
				num = ((num2 > 0f) ? ((float)_birthIndex / num2) : 0f);
				break;
			}
			Evaluate(num, ref evalResult);
			ModifySample(ref evalResult);
			_controllers[index].startColor = _particles[index].startColor;
			_controllers[index].startPercent = num;
			_controllers[index].cycleSpeed = Random.Range(minCycles, maxCycles);
			Vector2 vector = Vector2.zero;
			if (volumetric)
			{
				vector = ((!emitFromShell) ? Random.insideUnitCircle : ((Vector2)(Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward) * Vector2.right)));
			}
			_controllers[index].startOffset = vector * 0.5f;
			_controllers[index].endOffset = Random.insideUnitCircle * 0.5f;
			Vector3 vector2 = Vector3.Cross(evalResult.forward, evalResult.up);
			_particles[index].position = evalResult.position + vector2 * _controllers[index].startOffset.x * evalResult.size * scale.x + evalResult.up * _controllers[index].startOffset.y * evalResult.size * scale.y;
			float x = _particleSystem.forceOverLifetime.x.constantMax;
			float y = _particleSystem.forceOverLifetime.y.constantMax;
			float z = _particleSystem.forceOverLifetime.z.constantMax;
			if (_particleSystem.forceOverLifetime.randomized)
			{
				x = Random.Range(_particleSystem.forceOverLifetime.x.constantMin, _particleSystem.forceOverLifetime.x.constantMax);
				y = Random.Range(_particleSystem.forceOverLifetime.y.constantMin, _particleSystem.forceOverLifetime.y.constantMax);
				z = Random.Range(_particleSystem.forceOverLifetime.z.constantMin, _particleSystem.forceOverLifetime.z.constantMax);
			}
			float num3 = _particles[index].startLifetime - _particles[index].remainingLifetime;
			Vector3 vector3 = new Vector3(x, y, z) * 0.5f * (num3 * num3);
			float constantMax = _particleSystem.main.startSpeed.constantMax;
			if (motionType == MotionType.ByNormal)
			{
				_particles[index].position += evalResult.up * constantMax * (_particles[index].startLifetime - _particles[index].remainingLifetime);
				_particles[index].position += vector3;
				_particles[index].velocity = evalResult.up * constantMax + new Vector3(x, y, z) * num3;
			}
			else if (motionType == MotionType.ByNormalRandomized)
			{
				Vector3 vector4 = Quaternion.AngleAxis(Random.Range(0f, 360f), evalResult.forward) * evalResult.up;
				_particles[index].position += vector4 * constantMax * (_particles[index].startLifetime - _particles[index].remainingLifetime);
				_particles[index].position += vector3;
				_particles[index].velocity = vector4 * constantMax + new Vector3(x, y, z) * num3;
			}
			HandleParticle(index);
		}
	}
}
