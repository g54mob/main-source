using UnityEngine;

namespace Restory.Constants
{
	public static class ProjectConstants
	{
		public static class Infrastructure
		{
			public static readonly string ProjectTag = "RST";
		}

		public static class Animations
		{
			public static readonly int ActivateTrigger = Animator.StringToHash("Activate");

			public static readonly int ActivateInstantlyTrigger = Animator.StringToHash("ActivateInstantly");

			public static readonly int LeftClickTrigger = Animator.StringToHash("LeftClick");

			public static readonly int DragTrigger = Animator.StringToHash("Drag");

			public static readonly int DragTopDownTrigger = Animator.StringToHash("DragTopDown");

			public static readonly int DragDownTopTrigger = Animator.StringToHash("DragDownTop");

			public static readonly int DiagonalTrigger = Animator.StringToHash("Diagonal");

			public static readonly int Wheel = Animator.StringToHash("Wheel");

			public static readonly int RightButtonHoldAndDrag = Animator.StringToHash("RmbHoldAndDrag");
		}

		public static class Layers
		{
			public static readonly int DeviceContainerMask = LayerMask.GetMask("DeviceContainer");

			public static readonly int DeviceMask = LayerMask.GetMask("Device");

			public static readonly int PlacementMask = LayerMask.GetMask("Placement");

			public static readonly int ElementsMask = LayerMask.GetMask("Elements");

			public static readonly int AssembleMask = LayerMask.GetMask("Assemble");

			public static readonly int ObstaclesMask = LayerMask.GetMask("Obstacles");

			public static readonly int ProjectionsMask = LayerMask.GetMask("Projections");

			public static readonly int EquipmentMask = LayerMask.GetMask("Equipment");

			public static readonly int ClickableObjectsMask = LayerMask.GetMask("ClickableObjects");

			public static readonly int TransferMask = LayerMask.GetMask("Transfer");

			public static readonly int InteractiveObjectsMask = LayerMask.GetMask("InteractiveObjects");

			public static readonly int StorageMask = LayerMask.GetMask("Storage");

			public static readonly int ShipmentMask = LayerMask.GetMask("Shipment");

			public static readonly int SolderingMask = LayerMask.GetMask("Soldering");

			public static readonly int StorageBlockersMask = LayerMask.GetMask("StorageBlockers");

			public static readonly int DeviceContainer = LayerMask.NameToLayer("DeviceContainer");

			public static readonly int Device = LayerMask.NameToLayer("Device");

			public static readonly int Placement = LayerMask.NameToLayer("Placement");

			public static readonly int Elements = LayerMask.NameToLayer("Elements");

			public static readonly int Assemble = LayerMask.NameToLayer("Assemble");

			public static readonly int Obstacles = LayerMask.NameToLayer("Obstacles");

			public static readonly int Dragging = LayerMask.NameToLayer("Dragging");

			public static readonly int Projections = LayerMask.NameToLayer("Projections");

			public static readonly int Equipment = LayerMask.NameToLayer("Equipment");

			public static readonly int ClickableObjects = LayerMask.NameToLayer("ClickableObjects");

			public static readonly int Transfer = LayerMask.NameToLayer("Transfer");

			public static readonly int InteractiveObjects = LayerMask.NameToLayer("InteractiveObjects");

			public static readonly int Storage = LayerMask.NameToLayer("Storage");

			public static readonly int Shipment = LayerMask.NameToLayer("Shipment");

			public static readonly int Soldering = LayerMask.NameToLayer("Soldering");

			public static readonly int StorageBlockers = LayerMask.NameToLayer("StorageBlockers");
		}

		public static class MaterialProperties
		{
			public static readonly int Color = Shader.PropertyToID("_Color");

			public static readonly int Emission = Shader.PropertyToID("_Emission");

			public static readonly int Number = Shader.PropertyToID("_Number");

			public static readonly int ErrorIntensity = Shader.PropertyToID("_Error_Intensity");

			public static readonly int RefractionStrength = Shader.PropertyToID("_Refraction_Strength");
		}
	}
}
