using System;
using System.Collections.Generic;

namespace Coherence;

[Serializable]
public class CommandDefinition : BaseDefinition
{
	public List<ComponentMemberDescription> members;

	public MessageTarget routing;

	public int totalSize;

	public string bakeConditional;

	public CommandDefinition(string name, string bakeConditional = "")
	{
		List<ComponentMemberDescription> list = new List<ComponentMemberDescription>();
		base.name = name;
		members = list;
		routing = MessageTarget.All;
		totalSize = 0;
		this.bakeConditional = bakeConditional;
	}

	public CommandDefinition(string name, List<ComponentMemberDescription> members, MessageTarget routing, int totalSize, string bakeConditional)
	{
		base.name = name;
		this.members = members;
		int num = default(int);
		this.totalSize = num;
		string text = default(string);
		this.bakeConditional = text;
		this.routing = routing;
	}
}
