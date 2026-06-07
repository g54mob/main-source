using System;
using System.Collections.Generic;

[Serializable]
public class DamageModifyer
{
	[BalancingParameter(BalancingParameter.EType.Default)]
	public List<TagManager.ETag> requiredTags = new List<TagManager.ETag>();

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float damageAdded;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float damageMultiplyer = 1f;

	public bool AppliesTo(TaggedObject _taggedObject)
	{
		for (int i = 0; i < requiredTags.Count; i++)
		{
			if (!_taggedObject.Tags.Contains(requiredTags[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static float CalculateDamageOnTarget(TaggedObject _taggedObject, List<DamageModifyer> _damageModifyers, float _finalDamageMultiplyer = 1f)
	{
		float num = 0f;
		for (int i = 0; i < _damageModifyers.Count; i++)
		{
			DamageModifyer damageModifyer = _damageModifyers[i];
			if (damageModifyer.AppliesTo(_taggedObject))
			{
				num += damageModifyer.damageAdded;
				num *= damageModifyer.damageMultiplyer;
			}
		}
		return num * _finalDamageMultiplyer;
	}
}
