public class AutoAttackHighestHealth : AutoAttack
{
	public override TaggedObject FindAutoAttackTarget()
	{
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindHighestHealthObjectInRange(base.transform.position);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}
}
