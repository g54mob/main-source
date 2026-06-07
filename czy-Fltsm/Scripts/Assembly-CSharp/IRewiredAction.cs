using I2.Loc;

public interface IRewiredAction
{
	int ActionId { get; }

	int SortingOrder { get; }

	LocalizedString Description { get; }

	LocalizedString Prefix { get; }

	void Enable()
	{
	}

	void Disable()
	{
	}

	bool VisibleInRewiredActionInfoBar();
}
