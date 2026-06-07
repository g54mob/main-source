using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class FuseController : SimComponent
	{
		public readonly float setThreshold;

		public readonly bool isActiveWhenOverThreshold;

		public readonly FuseReference fuseRef;

		public PortReference controllingPort;

		public FuseController(FuseControllerDefinition fcDef)
			: base(fcDef.ID)
		{
			setThreshold = fcDef.setThreshold;
			isActiveWhenOverThreshold = fcDef.isActiveWhenOverThreshold;
			fuseRef = AddFuseReference(fcDef.fuseId);
			controllingPort = AddPortReference(fcDef.controllingPort);
		}

		public override void Tick(float delta)
		{
			bool flag = controllingPort.Value > setThreshold;
			if (!isActiveWhenOverThreshold)
			{
				flag = !flag;
			}
			if (flag != fuseRef.State)
			{
				fuseRef.ChangeState(flag);
			}
		}
	}
}
