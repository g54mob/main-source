using Pug.Conversion;

public class MerchantConverter : SingleAuthoringComponentConverter<MerchantAuthoring>
{
	protected override void Convert(MerchantAuthoring authoring)
	{
		EnsureHasComponent<MerchantCD>();
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasBuffer<MerchantItemInfoBuffer>();
		foreach (MerchantItemInfo item in authoring.items)
		{
			AddToBuffer(new MerchantItemInfoBuffer
			{
				objectID = item.objectID,
				amount = item.amount,
				requirementToBeAvailable = item.requirementToBeAvailable
			});
		}
	}
}
