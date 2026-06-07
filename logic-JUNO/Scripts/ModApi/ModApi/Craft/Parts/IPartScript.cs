using System;
using System.Collections.Generic;
using ModApi.Design;
using ModApi.Flight.GameView;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IPartScript
	{
		List<AttachPointScript> AttachPointScripts { get; }

		bool AttachPointsEnabled { get; }

		IFuelSource BatteryFuelSource { get; }

		IBodyScript BodyScript { get; }

		List<PartColliderScript> Colliders { get; }

		bool CollisionSoundsEnabled { get; set; }

		ICommandPod CommandPod { get; }

		ICraftScript CraftScript { get; }

		PartData Data { get; }

		PartDesignerInteractionMode DesignerInteractionMode { get; set; }

		bool Disconnected { get; }

		float FluidDisplacementVolume { get; }

		GameObject GameObject { get; }

		bool HasFlightProgram { get; }

		List<PartModifierScript> Modifiers { get; }

		IPartGroupScript PartGroup { get; }

		IPartMaterialScript PartMaterialScript { get; }

		Collider PrimaryCollider { get; }

		float ReEntryEffectStrength { get; }

		ISymmetrySlice SymmetrySlice { get; set; }

		float Temperature { get; }

		Transform Transform { get; }

		float VaporTrailStrength { get; }

		IPartWaterPhysics WaterPhysics { get; }

		event CommandPodChangedHandler CommandPodChanged;

		event PartScriptConnectedDelegate ConnectedToPart;

		event PartMovedToNewCraftDelegate MovedToNewCraft;

		event PartScriptDestroyedDelegate PartDestroyed;

		bool AcceptConnection(AttachPointScript ourAttachPoint, AttachPointScript targetAttachPoint);

		void Activate();

		Bounds CalculateBounds();

		void Deactivate();

		void FocusCameraOnPart(bool focus);

		InspectorModel GenerateInspectorModel();

		float GetEstimatedDragForce();

		T GetModifier<T>() where T : PartModifierScript;

		List<T> GetModifiers<T>() where T : PartModifierScript;

		List<T> GetModifiersWithInterface<T>() where T : class;

		T GetModifierWithInterface<T>() where T : class;

		bool GetModifierWithInterface<T>(out T modifier) where T : class;

		IGameViewPointerEventHandler HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent);

		void InitializeColliders();

		void OnAttachmentDestroyed(PartConnection.Attachment attachment);

		void OnCommandPodChanged();

		void OnCraftStructureChanged();

		void OnModifiersCreated();

		[Obsolete("Use TakeDamage(float, PartDamageType) instead.")]
		void TakeDamage(float damage, bool heatDamage);

		void TakeDamage(float damage, PartDamageType type = PartDamageType.Basic);

		void ToggleActivationState();

		void UpdateAttachPoints();
	}
}
