using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	[GameLoopExecutionOrder(-4900)]
	public class BodyScript : MonoBehaviourBase, IBodyScript, IFlightStart, IGameLoopItem, IFlightFixedUpdate, IFlightUpdate
	{
		private float _averageReEntryEffectStrength;

		private PositionBiomeData _biomeData;

		private BodyCollisionHandler _bodyCollisionHandler;

		private DragPhysics _dragPhysics;

		private Drag _frameDrag = new Drag();

		private float _lastInertiaTensorRecalculationMass;

		private Vector3? _lastVelocity;

		private PartLookup _partIsland;

		private float _plasmaTemperature;

		private bool _recalculateMass;

		private bool _recenteredThisFrame;

		private EnumSetting<ImageEffectsQualitySettings.ReEntryQuality> _reentryQuality;

		private ISingleSound _reentrySound;

		private Rigidbody _rigidBody;

		private Quaternion _rotationCache;

		private DragTable _tempDragTable;

		private float _totalPartAngularDrag;

		private Drag _totalPartDrag;

		private Transform _transform;

		private float _vaporTrailStrength;

		private BodyWaterPhysics _waterPhysics;

		[SerializeField]
		private PrecisionModeType _waterPrecisionBody = PrecisionModeType.High;

		[SerializeField]
		private PrecisionModeType _waterPrecisionPart = PrecisionModeType.High;

		public static bool EnableDragLift { get; set; }

		public Vector3 Acceleration { get; private set; }

		public float AccelerationMagnitude { get; private set; }

		public bool ApplyStandardForces { get; set; } = true;

		public IBodyCollisionHandler BodyCollisionHandler => _bodyCollisionHandler;

		public Vector3 CenterOfMass
		{
			get
			{
				return Data.CenterOfMass;
			}
			set
			{
				_rigidBody.centerOfMass = value;
				Data.CenterOfMass = value;
			}
		}

		public bool CollidingWithTerrain => _bodyCollisionHandler.CollidingWithTerrain;

		public ICraftScript CraftScript { get; private set; }

		public BodyData Data { get; private set; }

		public bool Disconnected { get; set; }

		public Vector3 DragForce { get; private set; }

		public float FluidDensity { get; private set; }

		public GameObject GameObject => base.gameObject;

		public bool IsDebris { get; set; }

		public List<IBodyJoint> Joints { get; private set; }

		public float MachNumber => _dragPhysics.MachNumber;

		public List<IPartGroupScript> PartGroups { get; private set; }

		IReadOnlyList<IPartGroupScript> IBodyScript.PartGroups => PartGroups;

		public PartLookup PartIsland
		{
			get
			{
				if (_partIsland == null)
				{
					_partIsland = new PartLookup();
					if (Data.Parts.Count > 0)
					{
						foreach (PartData part in new PartGraph(Data.Parts[0], breakOnRigidBodyBoundary: false).Parts)
						{
							_partIsland.AddPart(part);
							BodyScript bodyScript = part.PartScript.BodyScript as BodyScript;
							if (bodyScript._partIsland == null)
							{
								bodyScript._partIsland = _partIsland;
							}
							else if (bodyScript._partIsland != _partIsland)
							{
								Debug.LogErrorFormat("Body {0} thinks it should be in multiple part graphs.", bodyScript.Data.Id);
							}
						}
					}
				}
				return _partIsland;
			}
			set
			{
				_partIsland = value;
			}
		}

		public float ReEntryEffectStrength => _averageReEntryEffectStrength;

		public Rigidbody RigidBody => _rigidBody;

		public Vector3 SurfaceVelocity => _rigidBody.velocity + CraftScript.ReferenceFrame.FrameSurfaceVelocity;

		public Transform Transform => _transform;

		public bool UpdateAngularDrag { get; set; } = true;

		public float VelocityMagnitude => _dragPhysics.VelocityMagnitude;

		public Vector3 VelocityNormalized => _dragPhysics.VelocityNormalized;

		public float VelocitySquared => _dragPhysics.VelocitySquared;

		public IBodyWaterPhysics WaterPhysics => _waterPhysics;

		public bool WaterPhysicsEnabled { get; private set; }

		public Vector3 WorldCenterOfMass
		{
			get
			{
				return _transform.TransformPoint(Data.CenterOfMass);
			}
			set
			{
				CenterOfMass = _transform.InverseTransformPoint(value);
			}
		}

		public event BodyScriptDelegate UnloadedFromGameView;

		public void AddFrameDrag(Drag.DragDirection direction, float drag, Vector3 position)
		{
			_frameDrag.AddDrag(direction, drag, position, 0f);
		}

		public void CalculateDrag()
		{
			_totalPartDrag = new Drag();
			float num = 0f;
			int num2 = 0;
			foreach (PartData part in Data.Parts)
			{
				if (part.PartType.IncludeInBodyDrag)
				{
					_totalPartDrag.AddDrag(part.PartDrag);
					num += part.Config.DragScaleAngular;
					num2++;
				}
			}
			_totalPartAngularDrag = num / (float)num2;
		}

		public float EstimatePartDragForce(Drag partDrag)
		{
			return _dragPhysics.EstimatePartDragForce(partDrag, FluidDensity);
		}

		public float EstimateWaterImpact(Drag partDrag)
		{
			return _waterPhysics.UnderWaterAmount * _dragPhysics.EstimatePartDragForceDelta(partDrag, CraftScript.AtmosphereSample.AirDensity, _biomeData.WaterConfig.Density);
		}

		public void ExplodePart(IPartScript part, float power)
		{
			_bodyCollisionHandler.ExplodePart(part, power);
		}

		[Obsolete]
		public void ExplodePart(IPartScript part, float power, int numCascades)
		{
			ExplodePart(part, power);
		}

		public void FlightEnd()
		{
			foreach (IBodyJoint joint in Joints)
			{
				(joint as BodyJoint).FlightEnd();
			}
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			bool flag = false;
			if (_rigidBody != null)
			{
				_dragPhysics.InitializeFrame(SurfaceVelocity, CraftScript.AtmosphereSample.SpeedOfSound, EnableDragLift);
				if (!RigidBody.isKinematic && ApplyStandardForces)
				{
					ICraftScript craftScript = CraftScript;
					bool flag2 = (WaterPhysicsEnabled = craftScript.CraftNode.Parent.PlanetData.HasWater && craftScript.FlightData.AltitudeAboveSeaLevel < 200.0);
					if (_totalPartDrag != null)
					{
						if (flag2)
						{
							_waterPhysics.Update();
						}
						float num = (flag2 ? _waterPhysics.UnderWaterAmount : 0f);
						float num2 = (1f - num) * craftScript.AtmosphereSample.AirDensity;
						float num3 = num * _biomeData.WaterConfig.Density;
						FluidDensity = num2 + num3;
						ApplyDrag(FluidDensity);
						if (UpdateAngularDrag)
						{
							LerpAngularDrag(0.05f * Mathf.Max(0.1f, 10f * Mathf.Pow(FluidDensity, 0.33f)), 0.5f);
						}
					}
					else
					{
						FluidDensity = 0f;
						_rigidBody.angularDrag = 0.0050000004f;
					}
					_bodyCollisionHandler.FixedUpdate();
					flag = true;
					if (_lastVelocity.HasValue && !_recenteredThisFrame)
					{
						Acceleration = (RigidBody.velocity - _lastVelocity.Value) / frame.DeltaTime;
						AccelerationMagnitude = Acceleration.magnitude;
					}
					_lastVelocity = RigidBody.velocity;
				}
			}
			if (!flag)
			{
				_lastVelocity = null;
			}
			_recenteredThisFrame = false;
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_rigidBody.centerOfMass = Data.CenterOfMass;
			_lastInertiaTensorRecalculationMass = Data.Mass;
			if (RigidBody.velocity == Vector3.zero)
			{
				_rigidBody.Sleep();
			}
			StartCoroutine(FirstFrameUpdate());
			_reentrySound = Game.Instance.FlightScene.SingleSoundManager.GetSingleSound("Audio/Sounds/FireLoop");
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (frame.IsWarping)
			{
				_dragPhysics.InitializeFrame(SurfaceVelocity, CraftScript.AtmosphereSample.SpeedOfSound, EnableDragLift);
			}
			_bodyCollisionHandler.Update();
			if (_recalculateMass)
			{
				_recalculateMass = false;
				RecalculateMass();
				if (Mathf.Min(Data.Mass, _lastInertiaTensorRecalculationMass) / Mathf.Max(Data.Mass, _lastInertiaTensorRecalculationMass, 1f) <= 0.975f)
				{
					_lastInertiaTensorRecalculationMass = Data.Mass;
					CraftScript.QueueInertiaTensorRecalculation(this);
				}
				CraftScript.SetMassChanged();
			}
			_rotationCache = _transform.rotation;
			if (_averageReEntryEffectStrength > 0f)
			{
				float a = Vector3.Distance(Game.Instance.FlightScene.ViewManager.GameView.GameCamera.FramePosition, WorldCenterOfMass);
				a = Mathf.Max(a, 10f);
				if (a < 1000f)
				{
					_reentrySound.AddPosition(WorldCenterOfMass, _averageReEntryEffectStrength * 10f / a);
				}
			}
		}

		public void Initialize(CraftScript craftScript, BodyData body, Rigidbody rigidBody)
		{
			Data = body;
			MoveToCraft(craftScript);
			SetBody(rigidBody);
			_biomeData = ((FlightSceneScript.Instance != null) ? FlightSceneScript.Instance.CraftBiomeData : null);
		}

		public void MoveToCraft(CraftScript craftScript)
		{
			_transform.SetParent(craftScript.Transform, worldPositionStays: true);
			CraftScript = craftScript;
			_bodyCollisionHandler = new BodyCollisionHandler(this, craftScript);
		}

		public void OnCraftStructureChanging()
		{
			_partIsland = null;
		}

		public void OnInitialized()
		{
			_waterPhysics = new BodyWaterPhysics(this);
		}

		public void OnPartMassChanged()
		{
			_recalculateMass = true;
		}

		public void OnRecentered()
		{
			_recenteredThisFrame = true;
		}

		public void QueuePartGroupForDestruction(IPartGroupScript partGroup)
		{
			_bodyCollisionHandler.QueuePartGroupForDisconnect(partGroup, disable: true);
		}

		public void QueuePartGroupForDisconnect(IPartGroupScript partGroup)
		{
			_bodyCollisionHandler.QueuePartGroupForDisconnect(partGroup, disable: false);
		}

		public void RecalculateMass()
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (PartData part in Data.Parts)
			{
				float mass = part.Mass;
				Vector3 vector = part.PartScript.Transform.TransformPoint(part.PartScript.Data.Config.CenterOfMass);
				zero += vector * mass;
				num += mass;
			}
			Vector3 worldCenterOfMass;
			if (num > 0.005f)
			{
				worldCenterOfMass = zero / num;
			}
			else
			{
				num = 0.005f;
				worldCenterOfMass = Transform.position;
			}
			Data.Mass = num;
			if (_rigidBody != null)
			{
				WorldCenterOfMass = worldCenterOfMass;
				_rigidBody.mass = Data.Mass;
			}
		}

		public void SetBody(Rigidbody body)
		{
			_rigidBody = body;
		}

		public void SetCollidingWithTerrainFlag(bool? collidingWithTerrain)
		{
			_bodyCollisionHandler.SetCollidingWithTerrainOverrideFlag(collidingWithTerrain);
		}

		public void UpdateHeatAndEffects(in FlightFrameData frame)
		{
			float deltaTime = ((frame.DeltaTimeWorld > 1.0) ? 1f : ((float)frame.DeltaTimeWorld));
			bool flag = _reentryQuality.Value != ImageEffectsQualitySettings.ReEntryQuality.Off;
			if (DragPhysics.HeatDamageEnabled || flag)
			{
				UpdatePartTemperatures(deltaTime);
			}
			if (flag)
			{
				UpdateReentryEffectValues(deltaTime);
			}
		}

		protected virtual void Awake()
		{
			_transform = base.transform;
			_dragPhysics = new DragPhysics(_transform);
			Joints = new List<IBodyJoint>();
			PartGroups = new List<IPartGroupScript>();
			_reentryQuality = Game.Instance.QualitySettings.ImageEffects.ReEntry;
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			_bodyCollisionHandler.OnCollisionEnter(collision);
		}

		protected virtual void OnCollisionStay(Collision collision)
		{
			_bodyCollisionHandler.OnCollisionStay(collision);
		}

		protected virtual void OnJointBreak(float breakForce)
		{
			_bodyCollisionHandler.OnJointBreak();
		}

		private void ApplyDrag(float fluidDensity)
		{
			if (_dragPhysics.VelocityMagnitude > 0f && fluidDensity > 0f)
			{
				DragForce = _dragPhysics.GetDragForce(_totalPartDrag, _rigidBody.mass, fluidDensity, EnableDragLift);
				_rigidBody.AddForce(DragForce);
				_dragPhysics.ApplyFrameDrag(_frameDrag, _rigidBody, fluidDensity);
				_frameDrag.ClearDrag();
			}
			else
			{
				DragForce = Vector3.zero;
			}
		}

		private IEnumerator FirstFrameUpdate()
		{
			yield return null;
			if (_rigidBody != null)
			{
				_rigidBody.centerOfMass = Data.CenterOfMass;
			}
		}

		private void LerpAngularDrag(float targetVal, float time)
		{
			if (_rigidBody.angularDrag != targetVal && !Utilities.CompareFloats(_rigidBody.angularDrag, targetVal))
			{
				_rigidBody.angularDrag = Mathf.Lerp(_rigidBody.angularDrag, targetVal, Time.deltaTime * time);
			}
			else if (_rigidBody.angularDrag != targetVal)
			{
				_rigidBody.angularDrag = targetVal;
			}
		}

		private void OnDestroy()
		{
			if (Game.InFlightScene)
			{
				this.UnloadedFromGameView?.Invoke(this);
				this.UnloadedFromGameView = null;
			}
			_waterPhysics?.Dispose();
		}

		private void OnValidate()
		{
			if (_waterPhysics != null)
			{
				if (_waterPhysics.PrecisionMode != _waterPrecisionBody)
				{
					_waterPhysics.PrecisionMode = _waterPrecisionBody;
				}
				if (!_waterPhysics.PrecisionModePartOverride.HasValue || _waterPrecisionPart != _waterPhysics.PrecisionModePartOverride.Value)
				{
					_waterPhysics.PrecisionModePartOverride = _waterPrecisionPart;
				}
			}
		}

		private void UpdatePartTemperatures(float deltaTime)
		{
			bool heatDamageEnabled = DragPhysics.HeatDamageEnabled;
			DragTable dragTable = _dragPhysics.DragTable;
			float num;
			float num2;
			if (FluidDensity > 0f)
			{
				AtmosphereSample atmosphereSample = CraftScript.AtmosphereSample;
				num = DragPhysics.CalculateStagnationPointTemperature(atmosphereSample.Temperature, _dragPhysics.MachNumber);
				num2 = Mathf.Clamp(50000f * atmosphereSample.AirDensity, 1f, 2000f);
				_plasmaTemperature = num * Mathf.Clamp01(num2 * 0.01f);
			}
			else
			{
				_plasmaTemperature = 0f;
				ICraftFlightData flightData = CraftScript.FlightData;
				num = (float)Mathd.Pow(1.0 * flightData.SolarRadiationIntensity / 5.670373E-08, 0.25);
				dragTable = _tempDragTable ?? (_tempDragTable = new DragTable());
				Vector3 solarRadiationFrameDirection = flightData.SolarRadiationFrameDirection;
				Vector3 vector = Quaternion.Inverse(_rotationCache) * solarRadiationFrameDirection;
				dragTable.SetValuesFromVector(-vector);
				num2 = 50f;
			}
			foreach (PartData part in Data.Parts)
			{
				PartScript partScript = (PartScript)part.PartScript;
				if (partScript.Data.PartDrag.IsOccluded)
				{
					partScript.Temperature = 288.706f;
					continue;
				}
				float temperature = partScript.Temperature;
				float num3 = num;
				float h = num2;
				Drag partDrag = part.PartDrag;
				float num4 = dragTable.CalculateDragCoefficientTimesArea(partDrag);
				float num5 = partDrag.TotalArea - num4;
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				float num6 = partScript.WaterPhysics?.UnderWaterAmount ?? 0f;
				if (num6 > 0f)
				{
					if (num6 < 1f)
					{
						num3 = Mathf.Lerp(num, _biomeData.WaterConfig.Temperature, partScript.WaterPhysics.UnderWaterAmount);
						h = Mathf.Lerp(num2, 2000f, partScript.WaterPhysics.UnderWaterAmount);
						num4 = partDrag.TotalArea;
						num5 = 0f;
					}
					else
					{
						num3 = _biomeData.WaterConfig.Temperature;
						h = Mathf.Clamp(50000f * _biomeData.WaterConfig.Density, 1f, 2000f);
						num4 = partDrag.TotalArea;
						num5 = 0f;
					}
				}
				float num7 = DragPhysics.CalculateConvectionHeat(h, num3, num4, 10f, 288.706f, num5, temperature, partScript.ThermalMass, deltaTime);
				IReadOnlyList<IHeatSource> heatSources = partScript.HeatSources;
				for (int i = 0; i < heatSources.Count; i++)
				{
					IHeatSource heatSource = heatSources[i];
					float temperature2 = heatSource.Temperature;
					if (!(temperature2 <= 0f))
					{
						float heatTransferRate = heatSource.GetHeatTransferRate(partScript);
						if (heatTransferRate > 0f)
						{
							num7 += heatTransferRate * Mathf.Max(0f, DragPhysics.CalculateConvectionHeat(h, temperature2, 0.2f * partDrag.TotalArea, 10f, 288.706f, 0f, temperature, partScript.ThermalMass, deltaTime));
							num3 = Mathf.Max(num3, temperature2);
						}
					}
				}
				temperature = (partScript.Temperature = temperature + Mathf.Sign(num7) * Mathf.Min(Mathf.Abs(num7), Mathf.Abs(num3 - temperature)));
				IConfigData config = part.Config;
				if (heatDamageEnabled && temperature > config.MaxTemperature)
				{
					float num9 = (temperature - config.MaxTemperature) * 0.017f * deltaTime;
					float num10 = num9;
					if (config.HeatShield > 0f)
					{
						num10 -= config.HeatShield;
						config.HeatShield -= num9;
					}
					if (num10 > 0f)
					{
						partScript.TakeDamage(num10, PartDamageType.Heat);
					}
				}
			}
		}

		private void UpdateReentryEffectValues(float deltaTime)
		{
			bool flag = (_waterPhysics?.UnderWaterAmount ?? 0f) <= 0f;
			float num = Mathf.Sqrt(FluidDensity);
			_vaporTrailStrength = Mathf.Lerp(_vaporTrailStrength, 1.5f * Mathf.Clamp01(10f * MachNumber - 9.99f) * Mathf.Clamp01(num - 1f / num + 1f), deltaTime * 2.5f);
			float num2 = 0.25f * _plasmaTemperature;
			float num3 = 0f;
			foreach (PartData part in Data.Parts)
			{
				PartScript partScript = (PartScript)part.PartScript;
				IPartWaterPhysics waterPhysics = partScript.WaterPhysics;
				if ((waterPhysics != null) ? (waterPhysics.UnderWaterAmount <= 0f) : flag)
				{
					float num4 = Mathf.Clamp01((0.75f * partScript.Temperature + num2 - 670f) / 1070f);
					num3 += num4;
					partScript.UpdateReentryEffectValues(num4, _vaporTrailStrength * Mathf.Min(1f, partScript.Data.PartDrag.TotalArea));
				}
				else
				{
					partScript.UpdateReentryEffectValues(0f, 0f);
				}
			}
			if (Game.Instance.QualitySettings.ImageEffects.ReEntry.Value == ImageEffectsQualitySettings.ReEntryQuality.On)
			{
				_averageReEntryEffectStrength = num3 / (float)Data.Parts.Count;
			}
			else
			{
				_averageReEntryEffectStrength = 0f;
			}
		}
	}
}
