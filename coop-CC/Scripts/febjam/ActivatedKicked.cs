using Aggro.Core;

public class ActivatedKicked : EntityBehaviourBase, IBoxActivated
{
	public void ServerBoxActivated(ActivationContext context)
	{
		if (context.causer.TryGetObject<BoxActivator>(out var obj))
		{
			ActivationContext context2 = new ActivationContext
			{
				type = ActivationContextType.Kicked,
				causer = base.entity
			};
			obj.RequestActivate(context2);
		}
	}
}
