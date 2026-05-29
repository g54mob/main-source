namespace CTS
{
	public interface IRoomAssignable : IBBTObject, IObject
	{
		RoomAssignations RoomAssignations { get; }
	}
}
