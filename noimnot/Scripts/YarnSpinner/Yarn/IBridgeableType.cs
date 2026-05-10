namespace Yarn
{
	internal interface IBridgeableType<out TBridgedType> : IType
	{
		TBridgedType DefaultValue { get; }

		TBridgedType ToBridgedType(Value value);
	}
}
