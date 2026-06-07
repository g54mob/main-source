using System.Collections.Generic;

public interface IRoyaltyItem
{
	bool HasWorkRoyalties { get; }

	IEnumerable<KeyValuePair<Company, float>> GetWorkRoyalties();

	void AddWorkRoyalty(Company c, float r);
}
