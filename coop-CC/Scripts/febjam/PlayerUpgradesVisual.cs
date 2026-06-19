using Aggro.Core;
using UnityEngine;

[AlwaysActive]
public class PlayerUpgradesVisual : EntityBehaviourBase
{
	public enum ContainerStrategy
	{
		Enable = 0,
		Disable = 1
	}

	public PlayerUpgrade upgrade;

	public ContainerStrategy strategy;

	private GameObject _container;

	protected override void OnEntityCreated()
	{
		_container = base.gameObject;
	}

	protected override void OnUpdatePresentation()
	{
		switch (strategy)
		{
		case ContainerStrategy.Enable:
			_container.SetActive(base.entity.GetObject<PlayerUpgrades>().HasUpgrade(upgrade));
			break;
		case ContainerStrategy.Disable:
			_container.SetActive(!base.entity.GetObject<PlayerUpgrades>().HasUpgrade(upgrade));
			break;
		default:
			throw new InvalidEnumException();
		}
		_container.SetActive(base.entity.GetObject<PlayerUpgrades>().HasUpgrade(upgrade));
	}
}
