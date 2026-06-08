using Timberborn.BlueprintSystem;

namespace Timberborn.CharactersGame
{
	internal record CharacterBirthNotifierSpec : ComponentSpec
	{
		[Serialize]
		public string NotificationLocKey { get; init; }
	}
}
