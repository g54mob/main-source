using System;
using System.Collections.Generic;

[Serializable]
public class SlotRequirement : IEquatable<SlotRequirement>
{
	public bool requirementAppliesToAllSlots;

	public bool dontShowAnyHint;

	public bool showInfoText;

	public List<ObjectCategoryTag> acceptsObjectsWithTags;

	public List<ObjectID> acceptsObjectIds;

	public bool denyLegendaryRarity;

	public bool Equals(SlotRequirement other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (acceptsObjectsWithTags.Count != other.acceptsObjectsWithTags.Count || acceptsObjectIds.Count != other.acceptsObjectIds.Count)
		{
			return false;
		}
		for (int i = 0; i < acceptsObjectsWithTags.Count; i++)
		{
			if (acceptsObjectsWithTags[i] != other.acceptsObjectsWithTags[i])
			{
				return false;
			}
		}
		for (int j = 0; j < acceptsObjectIds.Count; j++)
		{
			if (acceptsObjectIds[j] != other.acceptsObjectIds[j])
			{
				return false;
			}
		}
		if (requirementAppliesToAllSlots == other.requirementAppliesToAllSlots && dontShowAnyHint == other.dontShowAnyHint)
		{
			return showInfoText == other.showInfoText;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((SlotRequirement)obj);
	}
}
