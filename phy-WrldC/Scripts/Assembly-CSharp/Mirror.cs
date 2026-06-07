using UnityEngine;

public class Mirror : BaseComponentView
{
	private GameObject mirrorObject;

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		mirrorObject.SetActive(value: true);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		mirrorObject = base.transform.FindChildRecursively("Mirror").gameObject;
		mirrorObject.tag = "MirrorZone";
		base.gameObject.AddComponent<MirrorReplay>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		mirrorObject.SetActive(value: false);
	}

	protected override void InternalInitializeGizmos<MirrorModel>(MirrorModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		InstantiateGizmoObject("MirrorGizmo");
	}

	public override string GetComponentName()
	{
		return typeof(Mirror).Name;
	}
}
