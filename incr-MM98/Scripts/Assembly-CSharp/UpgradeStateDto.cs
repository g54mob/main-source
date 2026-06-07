using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class UpgradeStateDto
{
	[Key(0)]
	public HashSet<UpgradeNode> Unlocked = new HashSet<UpgradeNode>();

	[Key(1)]
	public HashSet<UpgradeNode> Visited = new HashSet<UpgradeNode>();
}
