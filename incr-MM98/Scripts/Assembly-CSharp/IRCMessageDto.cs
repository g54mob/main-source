using MessagePack;
using UnityEngine;

[MessagePackObject(false)]
public class IRCMessageDto
{
	[Key(0)]
	public IRCChannel Channel;

	[Key(1)]
	public string Username;

	[Key(2)]
	public string Message;

	[Key(5)]
	public Color Color;
}
