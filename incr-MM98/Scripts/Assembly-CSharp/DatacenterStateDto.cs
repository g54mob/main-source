using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class DatacenterStateDto
{
	[Key(0)]
	public Dictionary<Datacenter, DatacenterDetailsStateDto> DatacenterDetails;
}
