using Unity.Entities;

public struct AimIndicatorCachedStatesCD : IComponentData, IQueryTypeParameter
{
	public bool hasAimValidStateAndIntactWeapon;

	public bool isMortar;

	public bool isCommandMinion;

	public bool isBeamWeapon;

	public bool isRanged;

	public bool hasAnyAimIndicatorActive
	{
		get
		{
			if (!isMortar && !isCommandMinion && !isBeamWeapon)
			{
				return isRanged;
			}
			return true;
		}
	}
}
