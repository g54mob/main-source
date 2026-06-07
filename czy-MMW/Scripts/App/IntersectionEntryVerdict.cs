public enum IntersectionEntryVerdict
{
	Unknown = 0,
	NoIntersectingLanes = 1,
	NoBlockingVehicles = 2,
	ExceededMaximumWaitTime = 3,
	NoReservedLane = 4,
	BlockedByTrafficLight = 5,
	BlockedByTraversingVehicle = 6,
	BlockedByInboundVehicle = 7,
	Shoved = 8,
	BlockedByUnsafeCrossing = 9,
	BlockedByCongestedCrossing = 10
}
