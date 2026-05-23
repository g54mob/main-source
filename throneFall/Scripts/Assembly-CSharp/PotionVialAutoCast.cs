public class PotionVialAutoCast : ManualAttack
{
	public override TaggedObject FindAttackTarget(bool _choosePreferredTargetIfPossible = false)
	{
		if (_choosePreferredTargetIfPossible && (bool)preferredTarget && TagManager.instance.MeasureDistanceToTaggedObject(preferredTarget, base.transform.position) <= targetPriorities[0].range)
		{
			return preferredTarget;
		}
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = ((i != 0) ? targetPriorities[i].FindClosestTaggedObject(base.transform.position) : targetPriorities[i].FindLowestHealthObjectInRange(base.transform.position));
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}

	public override TaggedObject FindAttackTargetWithInfiniteRange(bool _choosePreferredTargetIfPossible = false)
	{
		for (int i = 1; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindClosestTaggedObjectWithoutMaxDistanceCheck(base.transform.position);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}
}
