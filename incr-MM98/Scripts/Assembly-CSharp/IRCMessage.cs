using UnityEngine;

public readonly struct IRCMessage
{
	private static int _sequence;

	public readonly long Sequence;

	public readonly IRCChannel Channel;

	public readonly string Username;

	public readonly string Message;

	public readonly Color Color;

	public IRCMessage(IRCChannel channel, string username, string message, Color color)
	{
		Sequence = ++_sequence;
		Channel = channel;
		Username = username;
		Message = message;
		Color = color;
	}
}
