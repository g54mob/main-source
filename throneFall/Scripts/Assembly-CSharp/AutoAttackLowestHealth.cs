public class AutoAttackLowestHealth : AutoAttack
{
	public bool excludeFullHealthTargets = true;

	public override TaggedObject FindAutoAttackTarget()
	{
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindLowestHealthObjectInRange(base.transform.position, excludeFullHealthTargets);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}
}
