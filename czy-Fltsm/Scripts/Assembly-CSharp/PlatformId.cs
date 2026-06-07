using System;
using UnityEngine;

[Serializable]
public struct PlatformId
{
	[SerializeField]
	private uint _steamId;

	public uint SteamID => _steamId;
}
