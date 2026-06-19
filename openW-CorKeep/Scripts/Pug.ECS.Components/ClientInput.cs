using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
[GhostComponent(PrefabType = GhostPrefabType.All, OwnerSendType = SendToOwnerType.SendToNonOwner)]
public struct ClientInput : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public NetworkTick Tick;

	[GhostField(Quantization = 1000, Composite = true)]
	public float2 cameraPosition;

	[GhostField]
	public int playedNotes;

	[GhostField(Quantization = 1000, Composite = true)]
	public float2 movementDirection;

	[GhostField(Quantization = 1000, Composite = true)]
	public float2 aimDirection;

	[GhostField(Quantization = 1000, Composite = true)]
	public float2 targetingDirection;

	[GhostField(Quantization = 1000, Composite = true)]
	public float2 mouseOrJoystickWorldPoint;

	[GhostField(Quantization = 1000, Composite = true)]
	public float2 joystickDirection;

	[GhostField]
	public short buttonSetMask;

	[GhostField]
	public byte equippedSlotIndex;

	[GhostField]
	public byte equipmentPresetIndex;

	[GhostField]
	public Direction facingDirection;

	[GhostField]
	public byte collectedAndEnabledSoulsMask;

	[GhostField]
	public byte deterministicInterpolationDelay;

	[GhostField]
	public bool prefersKeyboardAndMouse;

	[GhostField]
	public bool wasAiming;

	[GhostField]
	public bool useFishingMiniGame;

	public short padding;

	public NetworkTick InterpolationTick
	{
		get
		{
			if (!Tick.IsValid)
			{
				return NetworkTick.Invalid;
			}
			NetworkTick tick = Tick;
			tick.Subtract(deterministicInterpolationDelay);
			return tick;
		}
	}

	public void SetButtonState(CommandInputButtonStateNames name, bool val)
	{
		if (val)
		{
			buttonSetMask |= (short)name;
		}
		else
		{
			buttonSetMask &= (short)(~(int)name);
		}
	}

	public readonly bool IsButtonStateSet(CommandInputButtonStateNames name)
	{
		return ((uint)buttonSetMask & (uint)name) != 0;
	}

	public void SetAllButtonsFalse()
	{
		buttonSetMask = 0;
	}

	public readonly bool WasInputCreated()
	{
		return Tick.IsValid;
	}
}
