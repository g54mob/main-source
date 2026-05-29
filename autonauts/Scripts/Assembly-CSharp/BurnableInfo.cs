public class BurnableInfo
{
	public enum Tier
	{
		Crude = 0,
		Normal = 1,
		Super = 2,
		Hay = 3,
		Fertiliser = 4,
		Total = 5
	}

	public static ObjectType GetObjectTypeFromTier(Tier NewTier)
	{
		ObjectType result = ObjectType.Log;
		switch (NewTier)
		{
		case Tier.Normal:
			result = ObjectType.Charcoal;
			break;
		case Tier.Super:
			result = ObjectType.Coal;
			break;
		case Tier.Hay:
			result = ObjectType.HayBale;
			break;
		case Tier.Fertiliser:
			result = ObjectType.Fertiliser;
			break;
		}
		return result;
	}
}
