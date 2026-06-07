using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class HistoryStateDto
{
	[Key(0)]
	public List<HistoryEntryDto> Releases = new List<HistoryEntryDto>();
}
