using MessagePack;

[MessagePackObject(false)]
public class ComponentUnlockedStateDto
{
	[Key(0)]
	public ComponentUnlockRequirement.RequirementType Requirement;

	[Key(1)]
	public double Value;
}
