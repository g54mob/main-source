using AK.Wwise;

public abstract class AkDragDropTriggerHandler : AkTriggerHandler
{
	protected abstract BaseType WwiseType { get; }

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
	}
}
