using System.Collections.Generic;
using Assets.Scripts.Flight;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyWaterPhysics : WaterPhysics<IBodyWaterPhysics>, IBodyWaterPhysics, IWaterPhysics<IBodyWaterPhysics>
	{
		private BodyScript _bodyScript;

		private float _defaultAngularDrag;

		private PrecisionModeType? _precisionModePartOverride;

		public override IBodyScript BodyScript => _bodyScript;

		public bool IsPrecisionModePerPart
		{
			get
			{
				if (PrecisionMode != PrecisionModeType.Low)
				{
					return PrecisionMode == PrecisionModeType.NotifyOnly;
				}
				return true;
			}
		}

		public override PrecisionModeType PrecisionMode
		{
			get
			{
				return base.PrecisionMode;
			}
			set
			{
				_bodyScript.RigidBody.angularDrag = _defaultAngularDrag;
				base.PrecisionMode = value;
			}
		}

		public PrecisionModeType? PrecisionModePartOverride
		{
			get
			{
				return _precisionModePartOverride;
			}
			set
			{
				_precisionModePartOverride = value;
				SetPartsPrecision(value);
			}
		}

		public BodyWaterPhysics(BodyScript bodyScript)
		{
			_bodyScript = bodyScript;
			_defaultAngularDrag = _bodyScript.RigidBody.angularDrag;
			CalculateTotalDisplacement();
			InitializeBase();
		}

		public override void Update()
		{
			WaterState state = ApplyWaterPhysics();
			SendEvents(state, this);
		}

		private void ApplyBuoyancy()
		{
			BodyScript bodyScript = _bodyScript;
			Rigidbody rigidBody = bodyScript.RigidBody;
			ICraftScript craftScript = bodyScript.CraftScript;
			if (base.TotalDisplacementVolumeScaled == 0f)
			{
				float displacedVolume = (base.DisplacedVolumeScaled = 0f);
				base.DisplacedVolume = displacedVolume;
				UnderWaterAmount = ((!(craftScript.GetAltitudeAboveSeaLevel(rigidBody.worldCenterOfMass) > 0f)) ? 1 : 0);
				return;
			}
			Vector3 vector = (((FlightSceneScript.Instance != null) ? FlightSceneScript.Instance.CraftBiomeData : null)?.WaterConfig.Density ?? 1000f) * 0.01f * -craftScript.GravityForce;
			float num2 = 0f;
			float num3 = 0f;
			if (PrecisionMode == PrecisionModeType.High || PrecisionMode == PrecisionModeType.Med)
			{
				_ = bodyScript.PartGroups;
				foreach (PartData part in bodyScript.Data.Parts)
				{
					IPartScript partScript = part.PartScript;
					if (partScript.Data.BuoyancyScale > 0f && partScript.WaterPhysics.PrecisionMode != PrecisionModeType.NotifyOnly && !(part.PartDrag.TotalArea < 0.1f))
					{
						IPartWaterPhysics waterPhysics = partScript.WaterPhysics;
						num3 += waterPhysics.DisplacedVolume;
						num2 += waterPhysics.DisplacedVolumeScaled;
						Vector3 force = waterPhysics.DisplacedVolumeScaled * vector;
						rigidBody.AddForceAtPosition(force, partScript.Transform.position);
					}
				}
			}
			else if (PrecisionMode == PrecisionModeType.Low || PrecisionMode == PrecisionModeType.NotifyOnly)
			{
				bool num4 = bodyScript.CraftScript.GetAltitudeAboveSeaLevel(bodyScript.RigidBody.position) < 0f;
				num3 = (num4 ? base.TotalDisplacementVolume : 0f);
				num2 = (num4 ? base.TotalDisplacementVolumeScaled : 0f);
				if (PrecisionMode != PrecisionModeType.NotifyOnly)
				{
					rigidBody.AddForce(num2 * vector);
				}
			}
			else
			{
				Debug.LogErrorFormat("Unsupported precision mode: {0}", PrecisionMode.ToString());
			}
			base.DisplacedVolume = num3;
			base.DisplacedVolumeScaled = num2;
			UnderWaterAmount = num2 / base.TotalDisplacementVolumeScaled;
		}

		private WaterState ApplyWaterPhysics()
		{
			bool isInWater = base.IsInWater;
			ApplyBuoyancy();
			WaterState state = WaterPhysics<IBodyWaterPhysics>.GetState(base.IsInWater, isInWater);
			if (PrecisionMode == PrecisionModeType.High)
			{
				ReduceBobbing();
			}
			return state;
		}

		private void CalculateTotalDisplacement()
		{
			List<IPartGroupScript> partGroups = _bodyScript.PartGroups;
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < partGroups.Count; i++)
			{
				List<PartData> parts = partGroups[i].Data.Parts;
				for (int j = 0; j < parts.Count; j++)
				{
					IPartScript partScript = parts[j].PartScript;
					if (partScript.Data.BuoyancyScale > 0f)
					{
						num += partScript.WaterPhysics.TotalDisplacementVolume;
						num2 += partScript.WaterPhysics.TotalDisplacementVolumeScaled;
					}
				}
			}
			base.TotalDisplacementVolume = num;
			base.TotalDisplacementVolumeScaled = num2;
		}

		private void ReduceBobbing()
		{
			float underWaterAmount = UnderWaterAmount;
			if (underWaterAmount > 0f && underWaterAmount < 1f)
			{
				Rigidbody rigidBody = _bodyScript.RigidBody;
				ICraftScript craftScript = _bodyScript.CraftScript;
				if (true)
				{
					float num = Vector3.Dot(craftScript.GravityNormal, rigidBody.velocity);
					Vector3 force = craftScript.GravityNormal * (0f - num) * 1f;
					rigidBody.AddForce(force, ForceMode.Acceleration);
				}
				else
				{
					float num2 = Vector3.Dot(craftScript.GravityNormal, rigidBody.velocity);
					Vector3 b = rigidBody.velocity - craftScript.GravityForce.normalized * num2;
					rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, b, Time.deltaTime);
				}
			}
		}

		private void SetPartsPrecision(PrecisionModeType? precisionMode)
		{
			if (!precisionMode.HasValue)
			{
				Debug.LogError("Setting default precision is not yet supported.");
			}
			List<IPartGroupScript> partGroups = _bodyScript.PartGroups;
			for (int i = 0; i < partGroups.Count; i++)
			{
				List<PartData> parts = partGroups[i].Data.Parts;
				for (int j = 0; j < parts.Count; j++)
				{
					IPartScript partScript = parts[j].PartScript;
					if (partScript.Data.BuoyancyScale > 0f)
					{
						partScript.WaterPhysics.PrecisionMode = precisionMode.Value;
					}
				}
			}
		}
	}
}
