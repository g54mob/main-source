namespace FluentAssertions.Equivalency
{
	public interface IOrderingRule
	{
		OrderStrictness Evaluate(IObjectInfo objectInfo);
	}
}
