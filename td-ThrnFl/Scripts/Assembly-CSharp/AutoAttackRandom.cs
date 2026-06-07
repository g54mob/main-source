public class AutoAttackRandom : AutoAttack
{
	public override TaggedObject FindAutoAttackTarget()
	{
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindRandomObjectInRange(base.transform.position);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}
}
