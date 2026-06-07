using System.Collections.Generic;
using UnityEngine;

public class TaggedObject : MonoBehaviour, ISaveLoad
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private List<TagManager.ETag> tags = new List<TagManager.ETag>();

	private TagManager tagManager;

	private Hp hp;

	public Collider colliderForBigOjectsToMeasureDistance;

	private Shrine shrineCache;

	public List<TagManager.ETag> Tags => tags;

	public Hp Hp
	{
		get
		{
			if (!hp)
			{
				hp = GetComponent<Hp>();
			}
			return hp;
		}
	}

	public Shrine Shrine
	{
		get
		{
			if ((bool)shrineCache)
			{
				return shrineCache;
			}
			return GetComponent<Shrine>();
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		TagManager.ETag[] value = new TagManager.ETag[0];
		MatchSaveLoadHandler.TryLoadValue(guid, base.gameObject.name + "_tags", ref value);
		if (value.Length != 0)
		{
			tags = new List<TagManager.ETag>(value);
		}
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, base.gameObject.name + "_tags", tags.ToArray());
	}

	private void OnEnable()
	{
		if (tagManager == null)
		{
			tagManager = TagManager.instance;
		}
		tagManager.AddTaggedObject(this);
	}

	private void OnDisable()
	{
		if (tagManager == null)
		{
			tagManager = TagManager.instance;
		}
		tagManager.RemoveTaggedObject(this);
	}

	public void AddTag(TagManager.ETag _tag)
	{
		if (!tags.Contains(_tag))
		{
			tags.Add(_tag);
			tagManager.AddTag(this, _tag);
		}
	}

	public void RemoveTag(TagManager.ETag _tag)
	{
		if (tags.Contains(_tag))
		{
			tags.Remove(_tag);
			tagManager.RemoveTag(this, _tag);
		}
	}
}
