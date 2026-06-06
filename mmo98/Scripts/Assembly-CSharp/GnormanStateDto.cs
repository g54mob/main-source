using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class GnormanStateDto
{
	[Key(0)]
	public GnormanAction Action;

	[Key(1)]
	public int Index;

	[Key(2)]
	public int MaxIndex;

	[Key(3)]
	public List<GnormanAction> TutorialActionsStarted = new List<GnormanAction>();

	[Key(4)]
	public List<GnormanAction> TutorialActionsQueue = new List<GnormanAction>();

	[Key(5)]
	public Gullibleness Gullibleness;
}
