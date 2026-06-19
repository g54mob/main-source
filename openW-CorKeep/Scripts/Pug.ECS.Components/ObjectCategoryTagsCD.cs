using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;

public struct ObjectCategoryTagsCD : IComponentData, IQueryTypeParameter
{
	public ulong tagsBitMask;

	public static bool HasAnyMatches(ulong tags1, ulong tags2)
	{
		return (tags1 & tags2) != 0;
	}

	public static bool HasTag(ulong tags, ObjectCategoryTag tag)
	{
		ulong num = (ulong)(1L << (int)tag);
		return (tags & num) != 0;
	}

	public static ulong ConvertToBitMask(List<ObjectCategoryTag> tags)
	{
		ulong num = 0uL;
		for (int i = 0; i < tags.Count; i++)
		{
			num |= (ulong)(1L << (int)tags[i]);
		}
		return num;
	}

	public static List<ObjectCategoryTag> ConvertToList(ulong tagsMask)
	{
		List<ObjectCategoryTag> list = new List<ObjectCategoryTag>();
		foreach (ObjectCategoryTag item in Enum.GetValues(typeof(ObjectCategoryTag)).Cast<ObjectCategoryTag>())
		{
			if ((tagsMask & (ulong)(1L << (int)item)) != 0L)
			{
				list.Add(item);
			}
		}
		return list;
	}
}
