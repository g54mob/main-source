using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;
using ModApi.Flight.GameView;
using ModApi.Flight.UI;
using ModApi.Math;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Craft.FlightData
{
	public class CraftFlightData : ICraftFlightData
	{
		private Vector3? _angularVelocity;

		private ICraftScript _craftScript;

		private Vector3 _gravityFrame;

		private CraftOrbitData _orbit;

		private CraftPerformanceData _performance;

		private bool _structureChanged;

		private float _weightedThrottleResponse;

		public Vector3d Acceleration => _craftScript.ReferenceFrame.FrameToPlanetVector(AccelerationFrame);

		public Vector3 AccelerationFrame { get; private set; }

		public double AccelerationMagnitude { get; private set; }

		public List<IReactionEngine> ActiveEngines { get; private set; } = new List<IReactionEngine>();

		public List<IReactionControlNozzle> ActiveReactionControlNozzles { get; private set; } = new List<IReactionControlNozzle>();

		public double AltitudeAboveGroundLevel { get; private set; }

		public double AltitudeAboveSeaLevel { get; private set; }

		public double AltitudeAboveTerrain { get; private set; }

		public double AngleOfAttack => Mathd.Acos(Vector3d.Dot(SurfaceVelocity.normalized, CraftUp)) * 57.29578 - 90.0;

		public Vector3d AngularVelocity
		{
			get
			{
				if (!_angularVelocity.HasValue)
				{
					Vector3 vector = _craftScript.CenterOfMass.InverseTransformDirection(_craftScript.RootPart.BodyScript.RigidBody.angularVelocity);
					_angularVelocity = new Vector3(0f - vector.x, vector.y, 0f - vector.z);
				}
				return _angularVelocity.Value;
			}
		}

		public double AngularVelocityMagnitude { get; private set; }

		public AtmosphereSample AtmosphereSample { get; set; }

		public double BankAngle => Mathd.Acos(Vector3d.Dot(PositionNormalized, CraftRight)) * 57.29578 - 90.0;

		public Vector3d CraftForward { get; private set; }

		public Vector3d CraftRight => _craftScript.ReferenceFrame.FrameToPlanetVector(_craftScript.CenterOfMass.right).normalized;

		public Vector3d CraftUp => _craftScript.ReferenceFrame.FrameToPlanetVector(_craftScript.CenterOfMass.up).normalized;

		public float CurrentEngineThrust { get; private set; }

		public float CurrentEngineThrustUnscaled => CurrentEngineThrust * 100f;

		public float CurrentMass { get; private set; }

		public float CurrentMassUnscaled => CurrentMass * 100f;

		public float CurrentReactionControlNozzleThrust { get; private set; }

		public double DeltaVStage => _craftScript.FlightData.Performance.DeltaVStage;

		public Vector3 DragAcceleration => _craftScript.DragAcceleration;

		public float DragAccelerationMagnitude => _craftScript.DragAcceleration.magnitude;

		public Vector3d East { get; private set; }

		public float FuelMass
		{
			get
			{
				double num = 0.0;
				foreach (IFuelSource fuelSource in _craftScript.FuelSources.FuelSources)
				{
					if (fuelSource.FuelType != FuelType.Battery && fuelSource.TotalFuel > 9.999999747378752E-05)
					{
						num += fuelSource.TotalFuel * (double)fuelSource.FuelType.Density;
					}
				}
				return (float)(num * 0.009999999776482582);
			}
		}

		public Vector3d Gravity { get; private set; }

		public Vector3 GravityFrame
		{
			get
			{
				return _gravityFrame;
			}
			private set
			{
				_gravityFrame = value;
				GravityFrameNormalized = value.normalized;
				GravityMagnitude = _gravityFrame.magnitude;
			}
		}

		public Vector3 GravityFrameNormalized { get; private set; }

		public float GravityMagnitude { get; private set; }

		public bool Grounded { get; private set; }

		public double Heading
		{
			get
			{
				double x = Vector3d.Dot(CraftForward, North);
				double num = Mathd.Atan2(Vector3d.Dot(CraftForward, East), x) * 57.29578;
				if (num < 0.0)
				{
					num += 360.0;
				}
				return num;
			}
		}

		public bool InWater { get; private set; }

		public double LateralSurfaceVelocity { get; private set; }

		public float MachNumber { get; private set; }

		public float MaxActiveEngineThrust { get; private set; }

		public float MaxActiveEngineThrustUnscaled => MaxActiveEngineThrust * 100f;

		public INavSphereTarget NavSphereTarget { get; private set; }

		public Vector3d North { get; private set; }

		public ICraftOrbitData Orbit => _orbit;

		public float ParentPlanetOcclusion { get; private set; }

		public ICraftPerformanceData Performance
		{
			get
			{
				_performance.OnAccessed();
				return _performance;
			}
		}

		public double Pitch
		{
			get
			{
				double d = Vector3d.Dot(CraftForward, PositionNormalized);
				return 90.0 - Mathd.Acos(d) * 57.29578;
			}
		}

		public Vector3d Position { get; private set; }

		public Vector3d PositionNormalized { get; private set; }

		public float RemainingBattery { get; private set; }

		public float RemainingFuelInStage { get; private set; }

		public float RemainingMonopropellant { get; private set; }

		public double SideSlip => Mathd.Acos(Vector3d.Dot(SurfaceVelocity.normalized, CraftRight)) * 57.29578 - 90.0;

		public Vector3d SolarRadiationDirection { get; private set; }

		public Vector3 SolarRadiationFrameDirection { get; private set; }

		public double SolarRadiationIntensity { get; private set; } = 1.0;

		public bool SupportsWarpBurn { get; private set; }

		public Vector3d SurfaceVelocity { get; private set; }

		public Vector3 SurfaceVelocityFrame { get; private set; }

		public double SurfaceVelocityMagnitude { get; private set; }

		public double TimeDelta => FlightSceneScript.Instance.TimeManager.DeltaTime;

		public double TimeMultiplier => FlightSceneScript.Instance.TimeManager.CurrentMode.TimeMultiplier;

		public double TimeReal => (DateTime.Now - Game.Instance.StartTime).TotalSeconds;

		public Vector3d Velocity { get; private set; }

		public double VelocityMagnitude { get; private set; }

		public double VerticalSurfaceVelocity { get; private set; }

		public float WeightedThrottleResponse
		{
			get
			{
				return _weightedThrottleResponse;
			}
			private set
			{
				_weightedThrottleResponse = value;
				WeightedThrottleResponseTime = 1f / value;
			}
		}

		public float WeightedThrottleResponseTime { get; private set; }

		public event EventHandler<EventArgs> ActiveEnginesChanged;

		public CraftFlightData(ICraftScript craftScript)
		{
			_craftScript = craftScript;
			_orbit = new CraftOrbitData(craftScript);
			_performance = new CraftPerformanceData(this, craftScript);
		}

		public void FixedUpdate()
		{
			UpdateGravityForce();
			AltitudeAboveSeaLevel = _craftScript.GetAltitudeAboveSeaLevel(_craftScript.FramePosition);
		}

		public void InitializeFromSource(ICraftFlightData source)
		{
			AtmosphereSample = source.AtmosphereSample;
			AltitudeAboveGroundLevel = source.AltitudeAboveGroundLevel;
			AltitudeAboveSeaLevel = source.AltitudeAboveSeaLevel;
			AltitudeAboveTerrain = source.AltitudeAboveTerrain;
			Gravity = source.Gravity;
			GravityFrame = source.GravityFrame;
			GravityFrameNormalized = source.GravityFrameNormalized;
			GravityMagnitude = source.GravityMagnitude;
			ParentPlanetOcclusion = source.ParentPlanetOcclusion;
			SolarRadiationDirection = source.SolarRadiationDirection;
			SolarRadiationFrameDirection = source.SolarRadiationFrameDirection;
			SolarRadiationIntensity = source.SolarRadiationIntensity;
			SurfaceVelocityFrame = source.SurfaceVelocityFrame;
			SurfaceVelocityMagnitude = source.SurfaceVelocityMagnitude;
			Velocity = source.Velocity;
			VelocityMagnitude = source.VelocityMagnitude;
		}

		public void OnStructureChanged()
		{
			_structureChanged = true;
		}

		public void Update(INavSphere navSphere)
		{
			ICraftNode craftNode = _craftScript.CraftNode;
			Position = craftNode.Position;
			PositionNormalized = craftNode.Position.normalized;
			AltitudeAboveSeaLevel = craftNode.Altitude;
			AltitudeAboveGroundLevel = craftNode.AltitudeAgl;
			AltitudeAboveTerrain = craftNode.AltitudeAboveTerrain;
			Grounded = craftNode.InContactWithPlanet;
			InWater = craftNode.InContactWithWater;
			AtmosphereSample = craftNode.Parent.PlanetData.AtmosphereData.SampleAltitude(AltitudeAboveSeaLevel);
			CalculateParentPlanetOcclusion(craftNode);
			CalculateSolarRadiation(craftNode);
			if (_structureChanged)
			{
				_structureChanged = false;
				FindActiveEngines();
			}
			Velocity = craftNode.Velocity;
			VelocityMagnitude = Velocity.magnitude;
			IReferenceFrame referenceFrame = craftNode.ReferenceFrame;
			IBodyScript bodyScript = _craftScript.RootPart.BodyScript;
			SurfaceVelocityFrame = _craftScript.FrameVelocity + referenceFrame.FrameSurfaceVelocity;
			SurfaceVelocity = referenceFrame.FrameToPlanetVector(SurfaceVelocityFrame);
			SurfaceVelocityMagnitude = SurfaceVelocityFrame.magnitude;
			MachNumber = ((AtmosphereSample.AirDensity > 0f) ? bodyScript.MachNumber : 0f);
			East = Vector3d.Cross(PositionNormalized, Vector3d.up).normalized;
			North = Vector3d.Cross(East, PositionNormalized).normalized;
			VerticalSurfaceVelocity = (float)Vector3d.Dot(craftNode.Position.normalized, SurfaceVelocity);
			double a = SurfaceVelocity.sqrMagnitude - VerticalSurfaceVelocity * VerticalSurfaceVelocity;
			a = Mathd.Max(a, 0.0);
			LateralSurfaceVelocity = (float)Mathd.Sqrt(a);
			CraftForward = referenceFrame.FrameToPlanetVector(_craftScript.CenterOfMass.forward).normalized;
			AccelerationFrame = bodyScript.Acceleration;
			AccelerationMagnitude = bodyScript.AccelerationMagnitude;
			AngularVelocityMagnitude = bodyScript.RigidBody.angularVelocity.magnitude;
			_angularVelocity = null;
			double num = 0.0;
			double num2 = 0.0;
			MaxActiveEngineThrust = 0f;
			CurrentEngineThrust = 0f;
			WeightedThrottleResponse = 0f;
			CurrentMass = _craftScript.Mass;
			foreach (IReactionEngine activeEngine in ActiveEngines)
			{
				if (activeEngine.FuelSource != null)
				{
					num += activeEngine.FuelSource.TotalFuel;
					num2 += activeEngine.FuelSource.TotalCapacity;
					if (!activeEngine.FuelSource.IsEmpty || Game.InfiniteFuelEnabled)
					{
						MaxActiveEngineThrust += activeEngine.MaximumThrust;
						CurrentEngineThrust += activeEngine.CurrentThrust;
						WeightedThrottleResponse += activeEngine.ThrottleResponse * activeEngine.MaximumThrust;
					}
				}
			}
			CurrentReactionControlNozzleThrust = 0f;
			foreach (IReactionControlNozzle activeReactionControlNozzle in ActiveReactionControlNozzles)
			{
				CurrentReactionControlNozzleThrust += activeReactionControlNozzle.CurrentThrust;
			}
			if (MaxActiveEngineThrust > 0f)
			{
				WeightedThrottleResponse /= MaxActiveEngineThrust;
			}
			else
			{
				WeightedThrottleResponse = 1f;
			}
			if (num2 > 0.0)
			{
				if (num < 9.999999747378752E-05)
				{
					num = 0.0;
				}
				RemainingFuelInStage = (float)(num / num2);
			}
			else
			{
				RemainingFuelInStage = 0f;
			}
			ICommandPod activeCommandPod = _craftScript.ActiveCommandPod;
			if (activeCommandPod != null)
			{
				RemainingMonopropellant = activeCommandPod.MonoFuelSource.GetRemainingPercentage();
				RemainingBattery = activeCommandPod.BatteryFuelSource.GetRemainingPercentage();
			}
			if (_craftScript.CraftNode.IsPlayer)
			{
				NavSphereTarget = navSphere.Target;
			}
			else
			{
				NavSphereTarget = null;
			}
			_orbit.UpdateData();
		}

		private void CalculateParentPlanetOcclusion(ICraftNode craftNode)
		{
			if (craftNode.Parent.Parent == null)
			{
				ParentPlanetOcclusion = 1f;
				return;
			}
			double radius = craftNode.Parent.PlanetData.Radius;
			double num = AltitudeAboveSeaLevel - AltitudeAboveGroundLevel;
			radius += Mathd.Lerp(num, 0.0, AltitudeAboveGroundLevel * 0.0002);
			Vector3d solarPosition = craftNode.SolarPosition;
			Ray3d ray3d = new Ray3d(-solarPosition.normalized, solarPosition);
			Vector3d lhs = craftNode.Parent.SolarPosition - ray3d.Origin;
			double num2 = Vector3d.Dot(lhs, ray3d.Direction);
			if (num2 < 0.0)
			{
				ParentPlanetOcclusion = 1f;
				return;
			}
			double num3 = (Math.Sqrt(lhs.sqrMagnitude - num2 * num2) / radius - 0.985) * 66.66666666666661;
			ParentPlanetOcclusion = Mathf.Clamp01((float)num3);
		}

		private void CalculateSolarRadiation(ICraftNode craftNode)
		{
			Vector3d solarPosition = craftNode.SolarPosition;
			SolarRadiationDirection = solarPosition.normalized;
			SolarRadiationFrameDirection = craftNode.ReferenceFrame.PlanetToFrameVector(SolarRadiationDirection);
			if (ParentPlanetOcclusion >= 0.998f)
			{
				IPlanetData star = FlightSceneScript.Instance.FlightState.SolarSystemData.Planets.First((IPlanetData x) => x.Parent == null);
				SolarRadiationIntensity = MathUtils.SolarEnergyFlux(star, solarPosition.sqrMagnitude);
			}
			else
			{
				SolarRadiationIntensity = 0.0;
			}
		}

		private void FindActiveEngines()
		{
			ActiveEngines.Clear();
			ActiveReactionControlNozzles.Clear();
			SupportsWarpBurn = true;
			foreach (PartData part in _craftScript.Data.Assembly.Parts)
			{
				if (!part.Activated || !part.Enabled || part.PartScript.Disconnected)
				{
					continue;
				}
				IReactionControlNozzle modifier2;
				if (part.PartScript.GetModifierWithInterface<IReactionEngine>(out var modifier))
				{
					if (modifier.IsActive)
					{
						ActiveEngines.Add(modifier);
						SupportsWarpBurn = modifier.SupportsWarpBurn && SupportsWarpBurn;
					}
				}
				else if (part.PartScript.GetModifierWithInterface<IReactionControlNozzle>(out modifier2) && modifier2.IsActive)
				{
					ActiveReactionControlNozzles.Add(modifier2);
				}
			}
			this.ActiveEnginesChanged?.Invoke(this, EventArgs.Empty);
		}

		private void UpdateGravityForce()
		{
			IReferenceFrame referenceFrame = _craftScript.ReferenceFrame;
			ICraftNode craftNode = _craftScript.CraftNode;
			Vector3d position = referenceFrame.FrameToPlanetPosition(_craftScript.FramePosition);
			Gravity = craftNode.Parent.CalculateGravityVector(position, 1.0);
			GravityFrame = referenceFrame.PlanetToFrameVector(Gravity);
		}
	}
}
