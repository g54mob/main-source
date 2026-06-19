using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public static class PickUpSystemHelpers
{
	public const float PICKUP_DISTANCE = 0.3f;

	private const float PICKUP_SPEED = 8f;

	private const float PICKUP_DELAY = 0.3f;

	public static float DistanceMoved(PickUpItemCD pickUpItem, NetworkTick tick, float tickFraction, float timePerTick, float2 itemPosition, float2 targetPos, float2 targetPrevPos, float targetMovementCompensation, out float additionalDistanceMovedAdded)
	{
		additionalDistanceMovedAdded = 0f;
		float timeSinceStartPickup = GetTimeSinceStartPickup(pickUpItem, tick, tickFraction, timePerTick);
		float num = math.length(targetPos - itemPosition);
		float num2 = math.length(targetPrevPos - itemPosition);
		additionalDistanceMovedAdded = num2 - num;
		targetMovementCompensation += additionalDistanceMovedAdded;
		timeSinceStartPickup -= 0.3f;
		if (timeSinceStartPickup < 0f)
		{
			return targetMovementCompensation;
		}
		return timeSinceStartPickup * timeSinceStartPickup * 8f + targetMovementCompensation;
	}

	private static float GetTimeSinceStartPickup(PickUpItemCD pickUpItem, NetworkTick tick, float tickFraction, float timePerTick)
	{
		return timePerTick * ((float)tick.TicksSince(pickUpItem.tickWhenStartingPickUp) - 1f + tickFraction);
	}

	public static float3 GetPickupPosition(Entity targetEntity, float3 targetTransformPosition, ObjectID objectID, int variation, float3 direction, PugDatabase.DatabaseBankCD databaseBankCD, ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup)
	{
		float3 result = targetTransformPosition;
		result += PugDatabase.GetEntityLocalCenter(objectID, databaseBankCD.databaseBankBlob, variation, direction.x);
		if (inventoryAutoTransferEnabledLookup.HasComponent(targetEntity))
		{
			result.z -= 0.3f;
		}
		return result;
	}
}
