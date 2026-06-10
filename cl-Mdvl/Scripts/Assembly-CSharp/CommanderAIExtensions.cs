using System.Collections.Generic;
using NSMedieval.CommanderAI;
using NSMedieval.CommanderAI.Orders;

public static class CommanderAIExtensions
{
	public static void StopUnits(this IEnumerable<CommanderAIUnit> units)
	{
		foreach (CommanderAIUnit unit in units)
		{
			unit.CurrentOrder = MoveOrder.Stop(unit);
		}
	}
}
