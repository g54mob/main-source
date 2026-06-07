using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class OperationStateDto
{
	[Key(0)]
	public Dictionary<Operation, int> Activations = new Dictionary<Operation, int>();

	[Key(1)]
	public Dictionary<Operation, List<OperationInstanceStateDto>> Instances = new Dictionary<Operation, List<OperationInstanceStateDto>>();
}
