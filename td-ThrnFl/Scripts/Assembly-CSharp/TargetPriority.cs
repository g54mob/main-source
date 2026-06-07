using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class TargetPriority
{
	[BalancingParameter(BalancingParameter.EType.Default)]
	public List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	[BalancingParameter(BalancingParameter.EType.Default)]
	public List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float range;

	private List<TaggedObject> allTaggedObjects = new List<TaggedObject>();

	private List<TaggedObject> objectsInRange = new List<TaggedObject>();

	private TagManager tagManager;

	public TaggedObject FindClosestTaggedObject(Vector3 _position)
	{
		TaggedObject taggedObject = TagManager.instance.FindClosestTaggedObjectWithTags(_position, mustHaveTags, mayNotHaveTags);
		if (taggedObject == null)
		{
			return null;
		}
		float num = ((!(taggedObject.colliderForBigOjectsToMeasureDistance != null)) ? (taggedObject.transform.position - _position).magnitude : (taggedObject.colliderForBigOjectsToMeasureDistance.ClosestPoint(_position) - _position).magnitude);
		if (num <= range)
		{
			return taggedObject;
		}
		return null;
	}

	public TaggedObject FindClosestTaggedObjectWithoutMaxDistanceCheck(Vector3 _position)
	{
		return TagManager.instance.FindClosestTaggedObjectWithTags(_position, mustHaveTags, mayNotHaveTags);
	}

	public void FindClosestTaggedObjects(Vector3 _position, TaggedObject[] _arrayToPopulate)
	{
		TagManager.instance.FindClosestTaggedObjectsWithTags(_position, mustHaveTags, mayNotHaveTags, _arrayToPopulate, range);
	}

	public void FindLowestHealthTaggedObjects(Vector3 _position, TaggedObject[] _arrayToPopulate, bool excludeFullHealthTargets)
	{
		TagManager.instance.FindLowestHealthTaggedObjectsWithTags(_position, mustHaveTags, mayNotHaveTags, _arrayToPopulate, range, excludeFullHealthTargets);
	}

	public TaggedObject FindHighestHealthObjectInRange(Vector3 _position)
	{
		tagManager = TagManager.instance;
		allTaggedObjects.Clear();
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		TaggedObject result = null;
		float num = 0f;
		for (int i = 0; i < allTaggedObjects.Count; i++)
		{
			if (!(tagManager.MeasureDistanceToTaggedObject(allTaggedObjects[i], _position) > range))
			{
				Hp hp = allTaggedObjects[i].Hp;
				if (hp.HpValue > num)
				{
					num = hp.HpValue;
					result = allTaggedObjects[i];
				}
			}
		}
		return result;
	}

	public void FindHighestHealthObjectsInRange(Vector3 _position, TaggedObject[] _arrayToPopulate)
	{
		tagManager = TagManager.instance;
		allTaggedObjects.Clear();
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		List<TaggedObject> list = (from obj in allTaggedObjects
			where tagManager.MeasureDistanceToTaggedObject(obj, _position) <= range
			orderby obj.Hp.HpValue descending
			select obj).ToList();
		int num = Mathf.Min(_arrayToPopulate.Length, list.Count);
		for (int num2 = 0; num2 < num; num2++)
		{
			_arrayToPopulate[num2] = list[num2];
		}
	}

	public void FindHighestMaxHealthObjectsInRange(Vector3 _position, TaggedObject[] _arrayToPopulate)
	{
		tagManager = TagManager.instance;
		allTaggedObjects.Clear();
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		List<TaggedObject> list = (from obj in allTaggedObjects
			where tagManager.MeasureDistanceToTaggedObject(obj, _position) <= range
			orderby obj.Hp.maxHp descending
			select obj).ToList();
		int num = Mathf.Min(_arrayToPopulate.Length, list.Count);
		for (int num2 = 0; num2 < num; num2++)
		{
			_arrayToPopulate[num2] = list[num2];
		}
	}

	public TaggedObject FindRandomObjectInRange(Vector3 _position)
	{
		tagManager = TagManager.instance;
		allTaggedObjects.Clear();
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		TaggedObject result = null;
		float num = 0f;
		for (int i = 0; i < allTaggedObjects.Count; i++)
		{
			if (!(tagManager.MeasureDistanceToTaggedObject(allTaggedObjects[i], _position) > range))
			{
				float value = UnityEngine.Random.value;
				if (value > num)
				{
					num = value;
					result = allTaggedObjects[i];
				}
			}
		}
		return result;
	}

	public void FindRandomObjectsInRange(Vector3 _position, TaggedObject[] _arrayToPopulate)
	{
		tagManager = TagManager.instance;
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		allTaggedObjects.ETShuffle(new System.Random());
		int num = 0;
		foreach (TaggedObject allTaggedObject in allTaggedObjects)
		{
			if (tagManager.MeasureDistanceToTaggedObject(allTaggedObject, _position) <= range)
			{
				_arrayToPopulate[num] = allTaggedObject;
				num++;
				if (num >= _arrayToPopulate.Length)
				{
					break;
				}
			}
		}
	}

	public TaggedObject FindLowestHealthObjectInRange(Vector3 _position, bool _excludeFullHealthTargets = true)
	{
		tagManager = TagManager.instance;
		allTaggedObjects.Clear();
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		TaggedObject result = null;
		float num = 100f;
		for (int i = 0; i < allTaggedObjects.Count; i++)
		{
			if (!(tagManager.MeasureDistanceToTaggedObject(allTaggedObjects[i], _position) > range))
			{
				Hp hp = allTaggedObjects[i].Hp;
				if ((!_excludeFullHealthTargets || !(hp.HpPercentage >= 1f)) && hp.HpPercentage < num)
				{
					num = hp.HpPercentage;
					result = allTaggedObjects[i];
				}
			}
		}
		return result;
	}

	public void FindLowestHealthObjectsInRange(Vector3 _position, TaggedObject[] _listToPopulate, bool _excludeFullHealthTargets = true)
	{
		tagManager = TagManager.instance;
		allTaggedObjects.Clear();
		tagManager.FindAllTaggedObjectsWithTags(allTaggedObjects, mustHaveTags, mayNotHaveTags);
		List<TaggedObject> list = (from obj in allTaggedObjects
			where tagManager.MeasureDistanceToTaggedObject(obj, _position) <= range && (!_excludeFullHealthTargets || !(obj.Hp.HpPercentage >= 1f))
			orderby obj.Hp.HpPercentage
			select obj).ToList();
		int num = Mathf.Min(_listToPopulate.Length, list.Count);
		for (int num2 = 0; num2 < num; num2++)
		{
			_listToPopulate[num2] = list[num2];
		}
	}

	public TaggedObject FindTaggedObject(Vector3 _position, out Vector3 _outPosition)
	{
		_outPosition = Vector3.zero;
		TaggedObject taggedObject = TagManager.instance.FindClosestTaggedObjectWithTags(_position, mustHaveTags, mayNotHaveTags);
		if (taggedObject == null)
		{
			return null;
		}
		float magnitude;
		if (taggedObject.colliderForBigOjectsToMeasureDistance != null)
		{
			_outPosition = taggedObject.colliderForBigOjectsToMeasureDistance.ClosestPoint(_position);
			magnitude = (_outPosition - _position).magnitude;
		}
		else
		{
			_outPosition = taggedObject.transform.position;
			magnitude = (_outPosition - _position).magnitude;
		}
		if (magnitude <= range)
		{
			return taggedObject;
		}
		return null;
	}

	public TaggedObject FindTaggedObjectCloseToHome(Vector3 _position, Vector3 _home, float _homeRange, out Vector3 _outPosition)
	{
		_outPosition = Vector3.zero;
		TaggedObject taggedObject = TagManager.instance.FindClosestTaggedObjectWithTags(_position, mustHaveTags, mayNotHaveTags);
		if (taggedObject == null)
		{
			return null;
		}
		if (taggedObject.colliderForBigOjectsToMeasureDistance != null)
		{
			_outPosition = taggedObject.colliderForBigOjectsToMeasureDistance.ClosestPoint(_position);
		}
		else
		{
			_outPosition = taggedObject.transform.position;
		}
		float magnitude = (_outPosition - _position).magnitude;
		_ = (_outPosition - _home).magnitude;
		if (magnitude <= range)
		{
			return taggedObject;
		}
		return null;
	}

	public TaggedObject FindTaggedObjectCloseToHomeInHomeRange(Vector3 _position, Vector3 _home, float _homeRange, out Vector3 _outPosition)
	{
		_outPosition = Vector3.zero;
		TaggedObject taggedObject = TagManager.instance.FindClosestTaggedObjectWithTags(_position, mustHaveTags, mayNotHaveTags);
		if (taggedObject == null)
		{
			return null;
		}
		if (taggedObject.colliderForBigOjectsToMeasureDistance != null)
		{
			_outPosition = taggedObject.colliderForBigOjectsToMeasureDistance.ClosestPoint(_position);
		}
		else
		{
			_outPosition = taggedObject.transform.position;
		}
		float magnitude = (_outPosition - _position).magnitude;
		float magnitude2 = (_outPosition - _home).magnitude;
		if (magnitude <= range && magnitude2 <= _homeRange)
		{
			return taggedObject;
		}
		return null;
	}
}
