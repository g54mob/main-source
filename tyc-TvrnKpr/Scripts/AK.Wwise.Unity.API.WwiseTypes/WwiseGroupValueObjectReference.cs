public abstract class WwiseGroupValueObjectReference : WwiseObjectReference
{
	public abstract WwiseObjectReference GroupObjectReference { get; set; }

	public abstract WwiseObjectType GroupWwiseObjectType { get; }

	public override string DisplayName => null;
}
