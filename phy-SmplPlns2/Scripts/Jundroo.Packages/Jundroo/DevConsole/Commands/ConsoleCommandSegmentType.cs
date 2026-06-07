namespace Jundroo.DevConsole.Commands
{
	internal enum ConsoleCommandSegmentType
	{
		Unknown = 0,
		FindAllChildGameObjects = 1,
		FindChildGameObjects = 2,
		FindChildComponents = 3,
		FindAllChildComponents = 4,
		FindMembers = 5,
		FindAllMembers = 6,
		GameObjectSelector = 7,
		ComponentSelector = 8,
		MemberSelector = 9,
		Command = 10,
		Argument = 11
	}
}
