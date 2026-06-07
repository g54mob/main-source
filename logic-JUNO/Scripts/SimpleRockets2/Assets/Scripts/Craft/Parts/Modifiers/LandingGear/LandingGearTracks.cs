using Assets.Scripts.CustomWheelCollider;
using Assets.Scripts.Flight;
using ModApi.Audio;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class LandingGearTracks
	{
		private PositionBiomeData _biomeData;

		private ResizableWheelColliderNew _collider;

		private PartScript _partScript;

		private ISingleSound _sound;

		private TireTrackRenderer _tireTrackRenderer;

		public LandingGearTracks(ResizableWheelColliderNew collider, PartScript partScript)
		{
			Initialize(collider, partScript);
		}

		public void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			if (_partScript.CraftScript.CraftNode.IsPhysicsEnabled)
			{
				_tireTrackRenderer.MoveAllSections(positionDelta);
			}
		}

		public void Update()
		{
			bool updating = false;
			ResizableWheelColliderNew collider = _collider;
			float num = 0f;
			TireTrackRenderer tireTrackRenderer = _tireTrackRenderer;
			_partScript.BodyScript.SetCollidingWithTerrainFlag(null);
			if (collider.IsGrounded)
			{
				tireTrackRenderer.transform.SetPositionAndRotation(collider.LastGroundPoint + collider.LastGroundNormal * 0.1f, Quaternion.LookRotation(collider.transform.forward, -collider.LastGroundNormal));
				tireTrackRenderer.CurrentOpacityMultiplier = ((collider.OffroadPercentage < 0.3f) ? 1f : _biomeData.TireTrackStrength);
				tireTrackRenderer.Width = collider.ContactPatchWidth;
				_partScript.BodyScript.SetCollidingWithTerrainFlag(true);
				float num2 = ((!(collider.BrakeInput > 0f)) ? 1 : 2);
				float f = collider.ForwardSlip / collider.ForwardFriction.AsymptoteSlip * num2;
				num = (Mathf.Max(b: Mathf.Abs(collider.SidewaysSlip / collider.SidewaysFriction.AsymptoteSlip * 4f), a: Mathf.Abs(f)) * collider.SurfaceFriction - 1f) / 5f;
				num = Mathf.Clamp(num, 0f, 1f);
				num *= num;
				bool flag = collider.LastGroundCollider.gameObject.layer == 31 || collider.LastGroundCollider.gameObject.layer == 30;
				if ((collider.OffroadPercentage > 0.3f || num > 0.1f) && !flag)
				{
					updating = true;
				}
			}
			if (_sound != null && num > 0f && _partScript.WaterPhysics.UnderWaterAmount < 0.2f && collider.OffroadPercentage < 0.3f)
			{
				_sound.AddPosition(collider.WheelColliderCenter, num * (1f - collider.OffroadPercentage));
			}
			tireTrackRenderer.Updating = updating;
		}

		private void Initialize(ResizableWheelColliderNew collider, PartScript partScript)
		{
			_partScript = partScript;
			_collider = collider;
			GameObject gameObject = new GameObject("TireTracks");
			gameObject.transform.SetParent(collider.transform, worldPositionStays: false);
			TireTrackRenderer tireTrackRenderer = gameObject.AddComponent<TireTrackRenderer>();
			tireTrackRenderer.Initialize(Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/TireTracks"));
			_tireTrackRenderer = tireTrackRenderer;
			_sound = Game.Instance.FlightScene.SingleSoundManager.GetSingleSound("Audio/Sounds/tireSkid");
			_biomeData = FlightSceneScript.Instance?.CraftBiomeData;
		}
	}
}
