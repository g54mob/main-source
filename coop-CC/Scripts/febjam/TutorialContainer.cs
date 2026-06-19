using Aggro.Core;
using UnityEngine;

public class TutorialContainer : EntityBehaviourBase
{
	public enum ContainerType
	{
		Boost = 0,
		Stress = 1
	}

	public ContainerType type;

	public GameObject container;

	protected override void OnEntityCreated()
	{
		container.SetActive(value: false);
	}

	public void CheckShow(ContainerType type)
	{
		if (type == this.type)
		{
			container.SetActive(value: true);
		}
	}

	public void CheckHide(ContainerType type)
	{
		if (type == this.type)
		{
			container.SetActive(value: false);
		}
	}
}
