using Factory;
using Factory.Pools;
using UnityEngine;

[Serializable(1)]
public class VehicleDispatchRecord : IReusable
{
	public int SimulationFrame;

	public Vector2Int HouseCoordinates;

	public Vector2Int DestinationCoordinates;

	public override bool Equals(object obj)
	{
		if (obj is VehicleDispatchRecord vehicleDispatchRecord)
		{
			return this == vehicleDispatchRecord;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return SimulationFrame ^ HouseCoordinates.GetHashCode() ^ DestinationCoordinates.GetHashCode();
	}

	public static bool operator ==(VehicleDispatchRecord a, VehicleDispatchRecord b)
	{
		bool flag = (object)a == null;
		bool flag2 = (object)b == null;
		if (flag && flag2)
		{
			return true;
		}
		if (flag || flag2)
		{
			return false;
		}
		if (a.SimulationFrame == b.SimulationFrame && a.HouseCoordinates == b.HouseCoordinates)
		{
			return a.DestinationCoordinates == b.DestinationCoordinates;
		}
		return false;
	}

	public static bool operator !=(VehicleDispatchRecord a, VehicleDispatchRecord b)
	{
		return !(a == b);
	}

	public void Reset()
	{
		SimulationFrame = 0;
		HouseCoordinates = default(Vector2Int);
		DestinationCoordinates = default(Vector2Int);
	}
}
