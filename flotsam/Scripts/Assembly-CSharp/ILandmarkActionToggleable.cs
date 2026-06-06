using System.Collections;

public interface ILandmarkActionToggleable : IToggleable
{
	string Label { get; }

	bool Unlocked { get; }

	IEnumerator Unlock();

	bool TryReturnRequiredItemAndCost(out ItemProperties requiredItem, out int cost);
}
