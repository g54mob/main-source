using AK.Wwise;
using UnityEngine;

[AddComponentMenu("Wwise/AkWwiseTrigger")]
[ExecuteInEditMode]
public class AkWwiseTrigger : AkDragDropTriggerHandler
{
	public Trigger data;

	protected override BaseType WwiseType => null;

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}
}
