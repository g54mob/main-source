using Aggro.Core;

public class ActivatedSlipout : EntityBehaviourBase, IBoxActivated
{
	public void ServerBoxActivated(ActivationContext context)
	{
		BoxCharge obj2;
		if (context.causer.TryGetObject<VehicleController>(out var obj))
		{
			obj.RequestSlipOut(isBananaSlip: true);
		}
		else if (context.causer.TryGetObject<BoxCharge>(out obj2))
		{
			obj2.ServerStopCharging();
		}
	}
}
