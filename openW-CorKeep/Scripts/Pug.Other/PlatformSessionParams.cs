using System;
using System.Text;

[Serializable]
public class PlatformSessionParams
{
	public string SessionId;

	public string JoinString;

	public string WorldName;

	public WorldMode WorldMode;

	public int IconIndex;

	public uint MaxPlayers;

	public bool IsHosting;

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Session ID: " + SessionId);
		stringBuilder.AppendLine("JoinString ID: " + JoinString);
		stringBuilder.AppendLine("WorldName: " + WorldName);
		stringBuilder.AppendLine($"WorldMode: {WorldMode}");
		stringBuilder.AppendLine($"IconIndex: {IconIndex}");
		stringBuilder.AppendLine($"MaxPlayers: {MaxPlayers}");
		stringBuilder.AppendLine($"IsHosting: {IsHosting}");
		return stringBuilder.ToString();
	}
}
