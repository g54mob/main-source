using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class IRCStateDto
{
	[Key(0)]
	public List<IRCMessageDto> Messages = new List<IRCMessageDto>();

	[Key(1)]
	public LoggedSystemLoadType SystemLoad;
}
