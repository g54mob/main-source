using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TagManager : MonoBehaviour
{
	public enum ETag
	{
		NONE = 39,
		PlayerOwned = 0,
		EnemyOwned = 1,
		Player = 2,
		CastleCenter = 3,
		MeeleFighter = 4,
		RangedFighter = 5,
		Flying = 6,
		PlayerUnit = 7,
		Building = 8,
		SiegeWeapon = 9,
		AUTO_Alive = 10,
		AUTO_KnockedOutAndHealOnDawn = 11,
		Wall = 12,
		InfrastructureEconomy = 13,
		TakesReducedDamageFromPlayerAttacks = 14,
		PracticeTargets = 15,
		FastMoving = 16,
		ArmoredAgainstRanged = 17,
		VulnerableVsRanged = 18,
		Monster = 19,
		House = 20,
		WallOrTower = 21,
		AUTO_Commanded = 22,
		TakesIncreasedDamageFromTowers = 23,
		Tower = 24,
		AUTO_NoReviveNextMorning = 25,
		PlayerOwnedPriorityTarget = 26,
		BlockableEnemyProjectile = 27,
		Boss = 28,
		UselessWallThatDoesNotBlockPath = 29,
		Healer = 30,
		MagicProjectile = 31,
		NaturallyVulnerableToSplash = 32,
		NaturallyHighHealthTarget = 33,
		UnreachableForBigEnemiesDueToLevelDesign = 34,
		PlayerShrine = 35,
		VodooCursed = 36,
		PlayerHeroUnit = 37,
		FireAndExplosionResistant = 38,
		Humanoid = 40,
		LargeUnit = 41,
		Exploding = 42,
		TrainingFacility = 43,
		Bridge = 44
	}

	public static TagManager instance;

	[SerializeField]
	private Dictionary<ETag, List<TaggedObject>> dictonaryOfListsOfTaggedObjects;

	private List<TaggedObject> tempTaggedObjectList = new List<TaggedObject>();

	private List<TaggedObject> bufferedPlayerUnits = new List<TaggedObject>();

	private List<TaggedObject> bufferedEnemyUnits = new List<TaggedObject>();

	private List<TaggedObject> bufferedPlayers = new List<TaggedObject>();

	public List<BuildingInteractor> playerBuildingInteractors = new List<BuildingInteractor>();

	public List<Coin> freeCoins = new List<Coin>();

	public List<Coin> coins = new List<Coin>();

	public IReadOnlyList<TaggedObject> PlayerUnits => bufferedPlayerUnits.AsReadOnly();

	public IReadOnlyList<TaggedObject> EnemyUnits => bufferedEnemyUnits.AsReadOnly();

	public IReadOnlyList<TaggedObject> Players => bufferedPlayers.AsReadOnly();

	private void OnEnable()
	{
		instance = this;
		dictonaryOfListsOfTaggedObjects = new Dictionary<ETag, List<TaggedObject>>();
		for (int i = 0; i < Enum.GetValues(typeof(ETag)).Length; i++)
		{
			dictonaryOfListsOfTaggedObjects.Add((ETag)i, new List<TaggedObject>());
		}
	}

	public void AddTaggedObject(TaggedObject _taggedObject)
	{
		foreach (ETag tag in _taggedObject.Tags)
		{
			AddTag(_taggedObject, tag);
			if (tag == ETag.EnemyOwned)
			{
				bufferedEnemyUnits.Add(_taggedObject);
			}
			if (tag == ETag.PlayerUnit)
			{
				bufferedPlayerUnits.Add(_taggedObject);
			}
			if (tag == ETag.Player)
			{
				bufferedPlayers.Add(_taggedObject);
			}
		}
	}

	public void RemoveTaggedObject(TaggedObject _taggedObject)
	{
		if (bufferedEnemyUnits.Contains(_taggedObject))
		{
			bufferedEnemyUnits.Remove(_taggedObject);
		}
		if (bufferedPlayerUnits.Contains(_taggedObject))
		{
			bufferedPlayerUnits.Remove(_taggedObject);
		}
		foreach (ETag tag in _taggedObject.Tags)
		{
			RemoveTag(_taggedObject, tag);
		}
	}

	public void AddTag(TaggedObject _taggedObject, ETag _tag)
	{
		List<TaggedObject> list = dictonaryOfListsOfTaggedObjects[_tag];
		if (!list.Contains(_taggedObject))
		{
			list.Add(_taggedObject);
		}
	}

	public void RemoveTag(TaggedObject _taggedObject, ETag _tag)
	{
		List<TaggedObject> list = dictonaryOfListsOfTaggedObjects[_tag];
		if (list.Contains(_taggedObject))
		{
			list.Remove(_taggedObject);
		}
	}

	public int CountObjectsWithTag(ETag _tag)
	{
		return dictonaryOfListsOfTaggedObjects[_tag].Count;
	}

	public void FindAllTaggedObjectsWithTags(List<TaggedObject> _listToPolulate, List<ETag> _mustHaveTags, List<ETag> _mayNotHaveTags)
	{
		_listToPolulate.Clear();
		if (_mustHaveTags.Count <= 0)
		{
			return;
		}
		List<TaggedObject> list = null;
		int num = int.MaxValue;
		for (int i = 0; i < _mustHaveTags.Count; i++)
		{
			List<TaggedObject> list2 = dictonaryOfListsOfTaggedObjects[_mustHaveTags[i]];
			if (list2.Count < num)
			{
				list = list2;
				num = list2.Count;
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		for (int j = 0; j < list.Count; j++)
		{
			TaggedObject taggedObject = list[j];
			List<ETag> tags = taggedObject.Tags;
			bool flag = true;
			if (_mustHaveTags != null)
			{
				for (int k = 0; k < _mustHaveTags.Count; k++)
				{
					if (!tags.Contains(_mustHaveTags[k]))
					{
						flag = false;
						break;
					}
				}
			}
			if (_mayNotHaveTags != null)
			{
				for (int l = 0; l < _mayNotHaveTags.Count; l++)
				{
					if (tags.Contains(_mayNotHaveTags[l]))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				_listToPolulate.Add(taggedObject);
			}
		}
	}

	public void FindAllTaggedObjectsWithTag(List<TaggedObject> _listToPolulate, ETag _mustHaveTag)
	{
		_listToPolulate.Clear();
		_listToPolulate.AddRange(dictonaryOfListsOfTaggedObjects[_mustHaveTag]);
	}

	public List<TaggedObject> FindAllTaggedObjectsWithTagDirect_UseWithCare(ETag _mustHaveTag)
	{
		return dictonaryOfListsOfTaggedObjects[_mustHaveTag];
	}

	public TaggedObject FindClosestTaggedObjectWithTags(Vector3 _position, List<ETag> _mustHaveTags, List<ETag> _mayNotHaveTags)
	{
		tempTaggedObjectList.Clear();
		FindAllTaggedObjectsWithTags(tempTaggedObjectList, _mustHaveTags, _mayNotHaveTags);
		TaggedObject result = null;
		float num = float.MaxValue;
		for (int i = 0; i < tempTaggedObjectList.Count; i++)
		{
			TaggedObject taggedObject = tempTaggedObjectList[i];
			float num2 = MeasureDistanceToTaggedObject(taggedObject, _position);
			if (num2 < num)
			{
				num = num2;
				result = taggedObject;
			}
		}
		return result;
	}

	public void FindClosestTaggedObjectsWithTags(Vector3 _position, List<ETag> _mustHaveTags, List<ETag> _mayNotHaveTags, TaggedObject[] _arrayToPopulate, float maxDistance)
	{
		for (int i = 0; i < _arrayToPopulate.Length; i++)
		{
			_arrayToPopulate[i] = null;
		}
		tempTaggedObjectList.Clear();
		FindAllTaggedObjectsWithTags(tempTaggedObjectList, _mustHaveTags, _mayNotHaveTags);
		var list = (from taggedObject in tempTaggedObjectList
			select new
			{
				TaggedObject = taggedObject,
				Distance = MeasureDistanceToTaggedObject(taggedObject, _position)
			} into obj
			where obj.Distance <= maxDistance
			orderby obj.Distance
			select obj).ToList();
		for (int num = 0; num < _arrayToPopulate.Length && num < list.Count; num++)
		{
			_arrayToPopulate[num] = list[num].TaggedObject;
		}
	}

	public void FindLowestHealthTaggedObjectsWithTags(Vector3 _position, List<ETag> _mustHaveTags, List<ETag> _mayNotHaveTags, TaggedObject[] _arrayToPopulate, float maxDistance, bool excludeFullHealthTargets)
	{
		for (int i = 0; i < _arrayToPopulate.Length; i++)
		{
			_arrayToPopulate[i] = null;
		}
		tempTaggedObjectList.Clear();
		FindAllTaggedObjectsWithTags(tempTaggedObjectList, _mustHaveTags, _mayNotHaveTags);
		foreach (TaggedObject tempTaggedObject in tempTaggedObjectList)
		{
			if (MeasureDistanceToTaggedObject(tempTaggedObject, _position) > maxDistance || (excludeFullHealthTargets && tempTaggedObject.Hp.HpPercentage >= 1f))
			{
				continue;
			}
			int num = -1;
			float num2 = float.MaxValue;
			for (int j = 0; j < _arrayToPopulate.Length; j++)
			{
				if (_arrayToPopulate[j] == null)
				{
					num = j;
					break;
				}
				float hpPercentage = _arrayToPopulate[j].Hp.HpPercentage;
				if (hpPercentage < num2)
				{
					num = j;
					num2 = hpPercentage;
				}
			}
			if (num != -1 && (num2 > tempTaggedObject.Hp.HpPercentage || _arrayToPopulate[num] == null))
			{
				_arrayToPopulate[num] = tempTaggedObject;
			}
		}
	}

	public float MeasureDistanceToTaggedObject(TaggedObject _taggedObj, Vector3 _pos)
	{
		if (_taggedObj.colliderForBigOjectsToMeasureDistance != null)
		{
			return (_taggedObj.colliderForBigOjectsToMeasureDistance.ClosestPoint(_pos) - _pos).magnitude;
		}
		return (_taggedObj.transform.position - _pos).magnitude;
	}

	public int CountAllTaggedObjectsWithTag(ETag _mustHaveTag)
	{
		return dictonaryOfListsOfTaggedObjects[_mustHaveTag].Count;
	}

	public int CountAllTaggedObjectsWithTag(ETag _mustHaveTag, ETag _AndMustHaveTag = ETag.NONE, ETag _MayNotHaveTag = ETag.NONE)
	{
		int num = dictonaryOfListsOfTaggedObjects[_mustHaveTag].Count;
		foreach (TaggedObject item in dictonaryOfListsOfTaggedObjects[_mustHaveTag])
		{
			if ((_AndMustHaveTag != ETag.NONE && !item.Tags.Contains(_AndMustHaveTag)) || (_MayNotHaveTag != ETag.NONE && item.Tags.Contains(_MayNotHaveTag)))
			{
				num--;
			}
		}
		return num;
	}
}
