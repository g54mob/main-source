using CTS.Core;

namespace CTS
{
	public class ActionFindClosestCage : ActionFindClosestInteractor<Cell>, IGive<MachineBase>
	{
		public new MachineBase Get()
		{
			return base.FoundInteractor;
		}
	}
}
