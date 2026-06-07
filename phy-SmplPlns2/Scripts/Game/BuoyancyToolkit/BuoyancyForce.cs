using System;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Misc.SimpleBehaviours;
using UnityEngine;

namespace BuoyancyToolkit
{
	public class BuoyancyForce : PartInFluidVolumeScript
	{
		public float VolumeUnderWaterPercent;

		protected static Dictionary<int, bool> _rigidBodiesImpactVelocityAdjustment = new Dictionary<int, bool>();

		protected int _rigidBodyInstanceId;

		protected GameObject _waterSurfaceParticleEffectsInstance;

		protected ParticleSystem _waterSurfaceParticleSystem;

		protected ParticleSystem.EmissionModule _waterSurfaceParticleSystemEmission;

		protected ParticleSystem.MainModule _waterSurfaceParticleSystemMain;

		private static AnimationCurve _floatingBlockForceAdjustment;

		private float _maxParticlesStartSize;

		private float _percentOfMassInRigidBody;

		private float _waterHeightDisplacement;

		private Action<float> _waterHeightQueryCallback;

		private bool _waterHeightRequest;

		public bool ReduceBuoyancyIfBySelf { get; set; }

		public override void OnFluidVolumeEnter()
		{
			SimulateEnteredFluidBody(PartInFluidVolumeScript._waterFluidVolume);
			if (PartInFluidVolumeScript._waterSurfaceParticleEffects != null)
			{
				_waterSurfaceParticleSystemEmission.enabled = true;
			}
		}

		public override void OnFluidVolumeExit()
		{
			if (PartInFluidVolumeScript._waterSurfaceParticleEffects != null)
			{
				_waterSurfaceParticleSystemEmission.enabled = false;
			}
			_rigidBodiesImpactVelocityAdjustment[_rigidBodyInstanceId] = false;
		}

		public override void Recalculate()
		{
			base.Recalculate();
			if (base.BuoyanceForceRigidBody != null)
			{
				_rigidBodyInstanceId = base.BuoyanceForceRigidBody.GetInstanceID();
				if (!_rigidBodiesImpactVelocityAdjustment.ContainsKey(_rigidBodyInstanceId))
				{
					_rigidBodiesImpactVelocityAdjustment.Add(_rigidBodyInstanceId, value: false);
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (!_firstFrame && !PauseManager.Paused && _part.PhysicsEnabled)
			{
				SimulateBuoyancy();
			}
		}

		protected void SimulateBuoyancy()
		{
			FluidVolume waterFluidVolume = PartInFluidVolumeScript._waterFluidVolume;
			Bounds bounds = _buoyancyCollider.bounds;
			float num = GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault() + _waterHeightDisplacement;
			if (_waterHeightRequest)
			{
				FlightSceneScript.Instance.WaterQueryManager.QueryHeightDisplacement(bounds.center, _waterHeightQueryCallback);
				_waterHeightRequest = false;
			}
			float num2 = 0f - num;
			float num3 = bounds.min.y + num2;
			float num4 = bounds.max.y + num2;
			bounds.Expand(PartInFluidVolumeScript._boundsExtentBias);
			if (num3 <= 0f && GameWorld.Instance.SeaLevel.HasValue)
			{
				_isSubmerged = true;
				float num5 = 0f;
				float num6 = num4 - num3;
				if (num4 <= 0f)
				{
					_isCompletelySubmerged = true;
					num5 = 1f;
				}
				else
				{
					num5 = Mathf.Clamp(Mathf.Abs(num3) / num6, 0f, 1f);
					_isCompletelySubmerged = false;
				}
				VolumeUnderWaterPercent = num5;
				float num7 = (0f - Physics.gravity.y) * Time.fixedDeltaTime;
				num7 = ((!(_weightFactor > 0f)) ? (num7 * (waterFluidVolume.density * num5 * base.PartVolume * 0.01f * base.BuoyancyScale)) : (num7 * (_weightFactor * _originalMass * num5)));
				if (ReduceBuoyancyIfBySelf)
				{
					_percentOfMassInRigidBody = _originalMass / base.BuoyanceForceRigidBody.mass;
					num7 *= _floatingBlockForceAdjustment.Evaluate(_percentOfMassInRigidBody);
				}
				base.BuoyanceForceRigidBody.AddForceAtPosition(Vector3.up * num7, bounds.center, ForceMode.Impulse);
			}
			else
			{
				_isSubmerged = false;
				_isCompletelySubmerged = false;
			}
		}

		protected void SimulateEnteredFluidBody(FluidVolume fluidVolume)
		{
			if (_rigidBodyInstanceId != base.BuoyanceForceRigidBody.GetInstanceID())
			{
				Recalculate();
			}
			if (ImpactVelocityAdjustment != null && !_rigidBodiesImpactVelocityAdjustment[_rigidBodyInstanceId] && !base.BuoyanceForceRigidBody.isKinematic)
			{
				float time = Mathf.Clamp(Mathf.Abs(base.BuoyanceForceRigidBody.linearVelocity.y), 0f, 100f) / 100f;
				float num = ImpactVelocityAdjustment.Evaluate(time);
				base.BuoyanceForceRigidBody.linearVelocity = new Vector3(base.BuoyanceForceRigidBody.linearVelocity.x, base.BuoyanceForceRigidBody.linearVelocity.y * num, base.BuoyanceForceRigidBody.linearVelocity.z);
				_rigidBodiesImpactVelocityAdjustment[_rigidBodyInstanceId] = true;
			}
		}

		protected override void Start()
		{
			base.Start();
			_waterHeightQueryCallback = delegate(float x)
			{
				_waterHeightDisplacement = x;
			};
			if (PartInFluidVolumeScript._waterSurfaceParticleEffects == null)
			{
				PartInFluidVolumeScript._waterSurfaceParticleEffects = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("ParticleEffects/WaterSurfaceParticles"));
			}
			if (PartInFluidVolumeScript._waterSurfaceParticleEffects != null)
			{
				_waterSurfaceParticleEffectsInstance = UnityEngine.Object.Instantiate(PartInFluidVolumeScript._waterSurfaceParticleEffects);
				_waterSurfaceParticleSystem = _waterSurfaceParticleEffectsInstance.GetComponent<ParticleSystem>();
				_waterSurfaceParticleSystemEmission = _waterSurfaceParticleSystem.emission;
				_waterSurfaceParticleSystemMain = _waterSurfaceParticleSystem.main;
				_waterSurfaceParticleEffectsInstance.transform.parent = base.transform;
				_waterSurfaceParticleSystemEmission.enabled = false;
				_maxParticlesAndEmissionRate = _waterSurfaceParticleSystemEmission.rateOverTime.constantMax;
				_maxParticlesStartSize = _waterSurfaceParticleSystemMain.startSize.constant;
			}
			_originalMass = _part.Part.LoadedMass;
			if (_floatingBlockForceAdjustment == null)
			{
				_floatingBlockForceAdjustment = Resources.Load<GameObject>("Data/Water/FloatingBlockForceAdjustment").GetComponent<AnimationCurveScript>().AnimationCurve;
			}
		}

		protected override void Update()
		{
			base.Update();
			if (PauseManager.Paused)
			{
				if (_waterSurfaceParticleSystem != null)
				{
					_waterSurfaceParticleSystem.Pause(withChildren: true);
				}
			}
			else
			{
				_waterHeightRequest = true;
				if (_waterSurfaceParticleSystem != null)
				{
					if (_waterSurfaceParticleSystem.isPaused)
					{
						_waterSurfaceParticleSystem.Play(withChildren: true);
					}
					if (base.IsCompletelySubmerged)
					{
						_waterSurfaceParticleSystemEmission.enabled = false;
					}
					else if (base.IsSubmerged)
					{
						_waterSurfaceParticleSystemEmission.enabled = true;
						float magnitude = base.BuoyanceForceRigidBody.linearVelocity.magnitude;
						ParticleSystem.MinMaxCurve rateOverTime = new ParticleSystem.MinMaxCurve(Mathf.Clamp(magnitude, 2f, _maxParticlesAndEmissionRate));
						_waterSurfaceParticleSystemEmission.rateOverTime = rateOverTime;
						_waterSurfaceParticleSystemMain.maxParticles = (int)(rateOverTime.constantMax * _waterSurfaceParticleSystemMain.startLifetime.constant);
						_waterSurfaceParticleSystemMain.startSize = Mathf.Clamp(magnitude, 2f, _maxParticlesStartSize);
					}
					else
					{
						_waterSurfaceParticleSystemEmission.enabled = false;
					}
				}
			}
			if (_waterSurfaceParticleEffectsInstance != null)
			{
				Vector3 position = base.transform.position;
				float y = GameWorld.Instance.SeaLevel.GetValueOrDefault() - GameWorld.Instance.FloatingOriginOffset.y;
				_waterSurfaceParticleEffectsInstance.transform.position = new Vector3(position.x, y, position.z);
			}
		}
	}
}
