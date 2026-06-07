using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartWaterPhysics : WaterPhysics<IPartWaterPhysics>, IPartWaterPhysics, IWaterPhysics<IPartWaterPhysics>
	{
		private PartScript _partScript;

		public override IBodyScript BodyScript => _partScript.BodyScript;

		public bool Enabled { get; set; } = true;

		public IPartScript PartScript => _partScript;

		public override PrecisionModeType PrecisionMode
		{
			get
			{
				return base.PrecisionMode;
			}
			set
			{
				if (value == PrecisionModeType.High && _partScript.PrimaryCollider == null)
				{
					Debug.LogWarning("High precision water physics requires a part collider, defaulting to low.");
					base.PrecisionMode = PrecisionModeType.Low;
				}
				else
				{
					base.PrecisionMode = value;
				}
			}
		}

		public override float UnderWaterAmount
		{
			get
			{
				return base.UnderWaterAmount;
			}
			protected set
			{
				base.UnderWaterAmount = value;
				base.DisplacedVolumeScaled = base.DisplacedVolume * PartScript.Data.BuoyancyScale;
			}
		}

		public PartWaterPhysics(PartScript partScript)
		{
			_partScript = partScript;
			CalculateMaxDisplacementVolume();
			InitializeBase();
		}

		public override void Update()
		{
			if (Enabled)
			{
				bool isInWater = base.IsInWater;
				UnderWaterAmount = CalculateUnderwaterPercent();
				WaterState state = WaterPhysics<IPartWaterPhysics>.GetState(base.IsInWater, isInWater);
				SendEvents(state, this);
				if (state == WaterState.Enter && PartScript.Data.Config.PartCollisionResponse != PartCollisionResponseType.None)
				{
					BodyScript.BodyCollisionHandler.CollidePart(new PartFlightCollision(PartScript.BodyScript.EstimateWaterImpact(PartScript.Data.PartDrag), PartScript.BodyScript.RigidBody.velocity.magnitude, PartScript));
				}
			}
		}

		private void CalculateMaxDisplacementVolume()
		{
			IModifierWaterPhysicsConfig modifierWithInterface = _partScript.GetModifierWithInterface<IModifierWaterPhysicsConfig>();
			if (modifierWithInterface != null)
			{
				base.TotalDisplacementVolume = modifierWithInterface.PartVolume;
			}
			else if (_partScript.PrimaryCollider != null)
			{
				Bounds bounds = _partScript.PrimaryCollider.bounds;
				base.TotalDisplacementVolume = bounds.size.x * bounds.size.y * bounds.size.z * 0.25f;
			}
			else
			{
				Debug.LogWarningFormat("{0} has no primary collider, disabling buoyancy and setting to Notify-Only.", PartScript.ToString());
				PrecisionMode = PrecisionModeType.NotifyOnly;
				base.TotalDisplacementVolume = 0f;
			}
			base.TotalDisplacementVolumeScaled = base.TotalDisplacementVolume * PartScript.Data.BuoyancyScale;
		}

		private float CalculateUnderwaterPercent()
		{
			float result = 0f;
			if (PrecisionMode == PrecisionModeType.High)
			{
				if (!_partScript.PrimaryCollider.enabled)
				{
					Debug.LogWarning("Part: " + _partScript.name + " - Collider (" + _partScript.PrimaryCollider.name + ") is disabled...switchinig to medium water physics precision");
					PrecisionMode = PrecisionModeType.Med;
				}
				else
				{
					result = _partScript.CraftScript.GetColliderSubmergedPercent(_partScript.PrimaryCollider);
				}
			}
			else if (PrecisionMode == PrecisionModeType.NotifyOnly || PrecisionMode == PrecisionModeType.Low || PrecisionMode == PrecisionModeType.Med)
			{
				result = ((!(_partScript.CraftScript.GetAltitudeAboveSeaLevel(_partScript.transform.position) > 0f)) ? 1 : 0);
			}
			else
			{
				Debug.LogFormat("Unsupported water precision mode: {0}", PrecisionMode.ToString());
			}
			return result;
		}
	}
}
