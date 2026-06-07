public class RequiredGenericFlag : Requirement
{
	public delegate bool EvalDelegate();

	public EntityId imageItem;

	public readonly string tooltipLocalizationKey;

	private readonly EvalDelegate evalDelegate;

	public RequiredGenericFlag(EvalDelegate evaluationDelegate, EntityId targetImageItem, string localizationKey)
	{
		evalDelegate = evaluationDelegate;
		imageItem = targetImageItem.GetCopy();
		tooltipLocalizationKey = localizationKey;
	}

	public override Requirement GetCopy()
	{
		return new RequiredGenericFlag(evalDelegate, imageItem.GetCopy(), tooltipLocalizationKey);
	}

	public override bool IsMet()
	{
		if (evalDelegate != null)
		{
			return evalDelegate();
		}
		return false;
	}
}
