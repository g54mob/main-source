public abstract class SecurityGuardState
{
	public SecurityGuardStateController sc;

	public SecurityGuard securityGuard;

	public virtual void OnEnter(SecurityGuardStateController stateController)
	{
	}

	public virtual void OnUpdate()
	{
	}

	public virtual void OnExit()
	{
	}

	public virtual void OnShoplifterDetected(Shoplifter shoplifter, bool OnAlert)
	{
	}
}
