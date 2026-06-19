public enum PickUpItemState : byte
{
	None = 0,
	IsBeingPickedUp = 1,
	ForcePickUp = 2,
	BlockPickupUntilReEnterStart = 3,
	BlockPickupUntilReEnterHasMovedAway = 4,
	HasBeenPickedUp = 5
}
