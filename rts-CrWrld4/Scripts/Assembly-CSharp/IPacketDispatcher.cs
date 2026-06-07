public interface IPacketDispatcher
{
	bool DispatchPacket(UnitManager u, Packet.PACKET_TYPE type);
}
