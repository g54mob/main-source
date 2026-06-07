using System;
using FishNet.Connection;

namespace Assets.Scripts.Multiplayer
{
	public delegate void ReceiveFlightSceneServerRpcDelegate(ArraySegment<byte> data, NetworkConnection sender);
}
