using UnityEngine;

public struct RoomCon
{
	public PathNode<Vector3> Connection;

	public PathNode<Vector3> Room;

	public PathNode<Vector3> SubConnection;

	public PathNode<Vector3> ReverseConnection
	{
		get
		{
			return SubConnection ?? Connection;
		}
	}

	public PathNode<Vector3> ReverseSubConnection
	{
		get
		{
			if (SubConnection != null)
			{
				return Connection;
			}
			return null;
		}
	}

	public RoomCon(PathNode<Vector3> connection, PathNode<Vector3> room, PathNode<Vector3> subConnection)
	{
		Connection = connection;
		Room = room;
		SubConnection = subConnection;
	}

	public RoomCon(PathNode<Vector3> connection, PathNode<Vector3> room)
	{
		Connection = connection;
		Room = room;
		SubConnection = null;
	}

	public override string ToString()
	{
		if (SubConnection != null)
		{
			return string.Concat(Connection, " -> ", SubConnection, " -> ", Room);
		}
		return string.Concat(Connection, " -> ", Room);
	}
}
