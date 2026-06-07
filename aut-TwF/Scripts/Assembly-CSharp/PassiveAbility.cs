public abstract class PassiveAbility : Ability
{
	public override bool IsLocked
	{
		get
		{
			return base.IsLocked;
		}
		set
		{
			if (base.IsLocked != value)
			{
				base.IsLocked = value;
				if (base.IsLocked)
				{
					EndAbility();
				}
				else
				{
					StartAbility();
				}
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		StartAbility();
	}

	private void OnDestroy()
	{
		EndAbility();
	}

	public virtual bool CanActivate()
	{
		return CanActivate_Internal();
	}

	public bool StartAbility()
	{
		if (!CanActivate() || !StartAbility_Internal())
		{
			return false;
		}
		OnActivate();
		return true;
	}

	protected void EndAbility()
	{
		OnEndAbility();
		EndAbility_Internal();
	}

	protected abstract void OnActivate();

	protected virtual void OnEndAbility()
	{
	}
}
