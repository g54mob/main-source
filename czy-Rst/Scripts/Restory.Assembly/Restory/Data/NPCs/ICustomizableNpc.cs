using Restory.Data.Microstories;

namespace Restory.Data.NPCs
{
	public interface ICustomizableNpc
	{
		NpcCustomizationOptions Customization { get; }
	}
}
