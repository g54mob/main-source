using System.Collections.Generic;
using UnityEngine;

public class ObjectIDCategory : ScriptableObject
{
	public string category;

	public Sprite icon;

	[SerializeField]
	private List<ObjectID> objectIds;

	private readonly Dictionary<ObjectIDCategory, List<ObjectID>> _children = new Dictionary<ObjectIDCategory, List<ObjectID>>();

	private readonly HashSet<ObjectID> _objectIds = new HashSet<ObjectID>();

	public HashSet<ObjectID> ObjectIds => _objectIds;

	public ObjectIDCategory ParentCategory { get; private set; }

	public bool Contains(ObjectID objectId)
	{
		return _objectIds.Contains(objectId);
	}

	public void Add(ObjectID objectId)
	{
		objectIds.Add(objectId);
		if (ParentCategory != null)
		{
			ParentCategory.UpdateChild(this);
		}
	}

	public void SetParentCategory(ObjectIDCategory newParentCategory)
	{
		UpdateObjectIdsSet();
		if (ParentCategory != null)
		{
			if (newParentCategory == ParentCategory)
			{
				ParentCategory.UpdateChild(this);
				return;
			}
			ParentCategory.UpdateChild(this, remove: true);
			ParentCategory = null;
		}
		ParentCategory = newParentCategory;
		if (ParentCategory != null)
		{
			ParentCategory.UpdateChild(this);
		}
	}

	private void OnDestroy()
	{
		if (ParentCategory == null)
		{
			ParentCategory.UpdateChild(this, remove: true);
		}
	}

	private void UpdateChild(ObjectIDCategory child, bool remove = false)
	{
		if (_children.TryGetValue(child, out var value))
		{
			if (remove)
			{
				_children.Remove(child);
			}
		}
		else if (!remove)
		{
			value = new List<ObjectID>();
			_children.Add(child, value);
		}
		if (remove)
		{
			return;
		}
		value.Clear();
		foreach (ObjectID objectId in child.ObjectIds)
		{
			value.Add(objectId);
		}
		UpdateObjectIdsSet();
	}

	public void UpdateObjectIdsSet()
	{
		_objectIds.Clear();
		foreach (ObjectID objectId in objectIds)
		{
			_objectIds.Add(objectId);
		}
		foreach (List<ObjectID> value in _children.Values)
		{
			foreach (ObjectID item in value)
			{
				_objectIds.Add(item);
			}
		}
	}

	public override string ToString()
	{
		if (!(ParentCategory != null))
		{
			return category;
		}
		return ParentCategory.category + "/" + category;
	}
}
