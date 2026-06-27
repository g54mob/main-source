using Restory.Gameplay.Devices;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public interface IDisassembleTooltipHandler
	{
		void ShowDisassemblingTooltip(Device targetDevice);

		void ShowAssemblingTooltip(Device targetDevice);
	}
}
