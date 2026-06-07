using System;
using UnityEngine;

namespace DV
{
	public static class Layers
	{
		public enum DVLayer
		{
			Default = 0,
			TransparentFX = 1,
			Ignore_Raycast = 2,
			Builtin_3 = 3,
			Water = 4,
			UI = 5,
			Builtin_6 = 6,
			Builtin_7 = 7,
			Terrain = 8,
			Player = 9,
			Train_Big_Collider = 10,
			Train_Walkable = 11,
			Train_Interior = 12,
			Interactable = 13,
			Teleport_Destination = 14,
			Laser_Pointer_Target = 15,
			Camera_Dampening = 16,
			Render_Elements = 20,
			No_Teleport_Interaction = 21,
			Inventory = 22,
			Controller = 23,
			Hazmat = 24,
			PostProcessing = 25,
			Grabbed_Item = 26,
			World_Item = 27,
			Reflection_Probe_Only = 28,
			Gadget_Mesh_Placing = 29
		}

		[Flags]
		public enum DVLayerMask
		{
			None = 0,
			Default = 1,
			TransparentFX = 2,
			Ignore_Raycast = 4,
			Builtin_3 = 8,
			Water = 0x10,
			UI = 0x20,
			Builtin_6 = 0x40,
			Builtin_7 = 0x80,
			Terrain = 0x100,
			Player = 0x200,
			Train_Big_Collider = 0x400,
			Train_Walkable = 0x800,
			Train_Interior = 0x1000,
			Interactable = 0x2000,
			Teleport_Destination = 0x4000,
			Laser_Pointer_Target = 0x8000,
			Camera_Dampening = 0x10000,
			Render_Elements = 0x100000,
			No_Teleport_Interaction = 0x200000,
			Inventory = 0x400000,
			Controller = 0x800000,
			Hazmat = 0x1000000,
			PostProcessing = 0x2000000,
			Grabbed_Item = 0x4000000,
			World_Item = 0x8000000,
			Reflection_Probe_Only = 0x10000000,
			Gadget_Mesh_Placing = 0x20000000,
			Everything = int.MinValue
		}

		public const string Default = "Default";

		public const string Ignore_Raycast = "Ignore Raycast";

		public const string Water = "Water";

		public const string TransparentFX = "TransparentFX";

		public const string UI = "UI";

		public const string Terrain = "Terrain";

		public const string Player = "Player";

		public const string Train_Big_Collider = "Train_Big_Collider";

		public const string Train_Walkable = "Train_Walkable";

		public const string Train_Interior = "Train_Interior";

		public const string Interactable = "Interactable";

		public const string Teleport_Destination = "Teleport_Destination";

		public const string Laser_Pointer_Target = "Laser_Pointer_Target";

		public const string Camera_Dampening = "Camera_Dampening";

		public const string Render_Elements = "Render_Elements";

		public const string No_Teleport_Interaction = "No_Teleport_Interaction";

		public const string Inventory = "Inventory";

		public const string Controller = "Controller";

		public const string Hazmat = "Hazmat";

		public const string PostProcessing = "PostProcessing";

		public const string Grabbed_Item = "Grabbed_Item";

		public const string World_Item = "World_Item";

		public const string Reflection_Probe_Only = "Reflection_Probe_Only";

		public const string Gadget_Mesh_Placing = "Gadget_Mesh_Placing";

		public static DVLayerMask ToDVLayerMask(this DVLayer layer)
		{
			return (DVLayerMask)(1 << layer.ToInt());
		}

		public static int ToInt(this DVLayer layer)
		{
			return (int)layer;
		}

		public static int ToInt(this DVLayerMask mask)
		{
			return (int)mask;
		}

		public static DVLayer ToDVLayerEnum(this int layer)
		{
			return (DVLayer)layer;
		}

		public static DVLayerMask ToDVLayerMaskEnum(this int mask)
		{
			return (DVLayerMask)mask;
		}

		public static LayerMask ToLayerMask(this DVLayerMask mask)
		{
			return (int)mask;
		}

		public static DVLayerMask ToLayerMask(this LayerMask mask)
		{
			return (DVLayerMask)(int)mask;
		}

		public static bool IsLayerPartOfMask(this int layer, DVLayerMask mask)
		{
			return (mask & layer.ToDVLayerEnum().ToDVLayerMask()) != 0;
		}
	}
}
