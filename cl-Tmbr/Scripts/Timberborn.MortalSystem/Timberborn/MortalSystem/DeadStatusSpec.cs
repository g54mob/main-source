using Timberborn.BlueprintSystem;

namespace Timberborn.MortalSystem
{
	internal record DeadStatusSpec : ComponentSpec
	{
		[Serialize]
		public string DeadStatusLocKey { get; init; }
	}
}
