using Pug.UnityExtensions;
using Unity.Collections;

public struct CraftingPrerequisites
{
	public OptionalValue<DataBlockAddress> ContentBundlePresent;

	public OptionalValue<DataBlockAddress> ContentBundleAbsent;

	public bool BirdBossKilled;

	public bool OctopusBossKilled;

	public bool ScarabBossKilled;

	public bool HydraBossNatureKilled;

	public bool HydraBossSeaKilled;

	public bool HydraBossDesertKilled;

	public bool HasAny()
	{
		if (!ContentBundlePresent.hasValue && !ContentBundleAbsent.hasValue && !BirdBossKilled && !OctopusBossKilled && !ScarabBossKilled && !HydraBossNatureKilled && !HydraBossSeaKilled)
		{
			return HydraBossDesertKilled;
		}
		return true;
	}

	public bool IsSatisfied(NativeHashSet<DataBlockAddress> activeBundles, WorldInfoCD worldInfo)
	{
		if (!HasAny())
		{
			return true;
		}
		if (ContentBundlePresent.hasValue && activeBundles.Contains(ContentBundlePresent.value))
		{
			return true;
		}
		if (ContentBundleAbsent.hasValue && !activeBundles.Contains(ContentBundleAbsent.value))
		{
			return true;
		}
		if (BirdBossKilled && worldInfo.birdBossBeenKilled)
		{
			return true;
		}
		if (OctopusBossKilled && worldInfo.octopusBossHasBeenKilled)
		{
			return true;
		}
		if (ScarabBossKilled && worldInfo.scarabHasBeenKilled)
		{
			return true;
		}
		if (HydraBossNatureKilled && worldInfo.hydraBossNatureHasBeenKilled)
		{
			return true;
		}
		if (HydraBossSeaKilled && worldInfo.hydraBossSeaHasBeenKilled)
		{
			return true;
		}
		if (HydraBossDesertKilled && worldInfo.hydraBossDesertHasBeenKilled)
		{
			return true;
		}
		return false;
	}
}
