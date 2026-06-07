using System;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IConfigData
	{
		bool AutoActivateIfNoStageOrActivationGroup { get; }

		float BuoyancyBaseScale { get; }

		float BuoyancyUserScale { get; }

		bool CanExplode { get; }

		bool CastShadows { get; set; }

		Vector3 CenterOfMass { get; set; }

		float CollisionDisconnectImpulse { get; set; }

		float CollisionDisconnectVelocity { get; }

		float CollisionExplodeImpulse { get; set; }

		float CollisionExplodeVelocity { get; }

		bool CollisionPreventExternalDisconnections { get; }

		PartCollisionVelocityMode CollisionVelocityMode { get; }

		float DragScale { get; }

		float DragScaleActive { get; }

		float DragScaleAngular { get; }

		float Explosiveness { get; }

		bool FuelLineOverride { get; }

		float HeatShield { get; set; }

		bool IgnoreValidation { get; }

		bool IncludeInDrag { get; }

		float InertiaTensorBaseScale { get; }

		float InertiaTensorMin { get; }

		float InertiaTensorUserScale { get; }

		int InitialCraftNodeId { get; }

		float MassScale { get; }

		float MaxDamage { get; }

		float MaxDrag { get; }

		float MaxDragActive { get; }

		float MaxTemperature { get; set; }

		OcclusionCalculationType OcclusionCalculation { get; }

		PartCollisionHandlingMethod PartCollisionHandling { get; }

		PartCollisionResponseType PartCollisionResponse { get; }

		Vector3 PartScale { get; }

		bool PartSelectionEnabled { get; }

		float PartThermalMassRatio { get; }

		bool PreventDebris { get; set; }

		float PriceScale { get; }

		bool RaiseWaterEventsEvenIfNotBuoyant { get; }

		PartMeshRenderQueue RenderQueue { get; set; }

		StageActivationType StageActivationType { get; }

		bool SupportsActivation { get; set; }

		bool SupportsTransparency { get; }

		string TutorialId { get; }

		event EventHandler<EventArgs> RenderQueueChanged;
	}
}
