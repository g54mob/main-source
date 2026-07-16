using System;
using UnityEngine;

public class LinkComponent : EnemyComponent
{
	[SerializeField]
	private ExtendableLinksComponent parent;

	public LinkPosition linkPosition;

	[NonSerialized]
	public bool triggerBaseDeath;

	protected new void Awake()
	{
		base.Awake();
	}

	public new virtual void Start()
	{
		base.Start();
		base.HealthComponent.OnHealthChanged += HealthComponent_OnHealthChanged;
	}

	public virtual void SetChainController(ExtendableLinksComponent chainController)
	{
		parent = chainController;
	}

	public virtual void HealthComponent_OnHealthChanged(HealthChangeInfo info)
	{
		parent.OnLinkDamaged(info);
	}

	public override void EMP(float duration)
	{
	}

	public override void OnEMPEnd()
	{
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (triggerBaseDeath)
		{
			base.OnDeath(info);
		}
	}
}
