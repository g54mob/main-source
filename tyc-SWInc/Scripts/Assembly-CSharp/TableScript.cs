using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TableScript : MonoBehaviour
{
	[NonSerialized]
	private List<KeyValuePair<SnapPoint, Holdable>> Items = new List<KeyValuePair<SnapPoint, Holdable>>();

	public Furniture FurnComp;

	[NonSerialized]
	public HashSet<TableScript> Children = new HashSet<TableScript>();

	public TableScript Parent;

	public float TableHeight = 1f;

	private Color color;

	private int _tableReserved = -1;

	public int FreeChairs;

	public int FreeEmptyChairs;

	public int UsedChairs;

	[NonSerialized]
	private List<Furniture> _cachedChairs;

	[NonSerialized]
	private List<Furniture> _cachedEmptyChairs;

	private bool _dirtyStatus = true;

	private static List<Furniture> _singleFun = new List<Furniture>();

	[NonSerialized]
	private uint[] _serializedTableGroup;

	[NonSerialized]
	private uint _serializedParent;

	[NonSerialized]
	private bool _hasDeserialized;

	public int TableReserved
	{
		get
		{
			if (Parent == null || Parent == this)
			{
				UpdateStatus(false);
				return _tableReserved;
			}
			return Parent.TableReserved;
		}
		set
		{
			if (Parent == null || Parent == this)
			{
				_tableReserved = value;
				_dirtyStatus = true;
			}
			else
			{
				Parent.TableReserved = value;
				Parent._dirtyStatus = true;
			}
		}
	}

	private void Start()
	{
		if (FurnComp.isTemporary)
		{
			return;
		}
		if (Parent == null)
		{
			Parent = this;
		}
		if (!FurnComp.Deserialized)
		{
			Vector3 vector = Utilities.HSVToRGB(UnityEngine.Random.Range(0f, 360f), 0.75f, 1f);
			color = new Color(vector.x, vector.y, vector.z);
		}
		if (Parent == this)
		{
			if (FurnComp.Deserialized && FurnComp.UsableForTableGroup())
			{
				FurnComp.Parent.TableParents.Add(this);
			}
			UpdateStatus(true);
		}
	}

	public void PostDeserialize()
	{
		if (_hasDeserialized && _serializedTableGroup != null)
		{
			Furniture furniture = Writeable.STGetDeserializedObject(_serializedParent) as Furniture;
			if (furniture != null && !FurnComp.isTemporary)
			{
				Parent = furniture.GetComponent<TableScript>();
			}
			Children.AddRange(from x in _serializedTableGroup
				select Writeable.STGetDeserializedObject(x) as Furniture into x
				where x != null && !x.isTemporary
				select x.GetComponent<TableScript>());
		}
	}

	public void MakeDirty()
	{
		_dirtyStatus = true;
		if (Parent != null)
		{
			Parent._dirtyStatus = true;
		}
	}

	public void UpdateUseStatus()
	{
		if (Parent != null && Parent != this)
		{
			Parent.UpdateUseStatus();
			return;
		}
		if (_cachedEmptyChairs == null)
		{
			UpdateStatus(true);
			return;
		}
		FreeChairs = 0;
		FreeEmptyChairs = 0;
		UsedChairs = 0;
		for (int i = 0; i < _cachedEmptyChairs.Count; i++)
		{
			CountChair(_cachedEmptyChairs[i]);
		}
		if (_tableReserved > -1 && FreeChairs > 0 && UsedChairs == 0 && UsedChairs == 0)
		{
			_tableReserved = -1;
		}
	}

	public void UpdateStatus(bool force)
	{
		if (Parent != null && Parent != this)
		{
			Parent.UpdateStatus(force);
		}
		else
		{
			if (!force && !_dirtyStatus)
			{
				return;
			}
			if (_cachedChairs == null)
			{
				_cachedChairs = new List<Furniture>();
				_cachedEmptyChairs = new List<Furniture>();
			}
			else
			{
				_cachedChairs.Clear();
				_cachedEmptyChairs.Clear();
			}
			FreeChairs = 0;
			FreeEmptyChairs = 0;
			UsedChairs = 0;
			if (FurnComp.Type.Equals("Chair"))
			{
				_cachedChairs.Add(FurnComp);
				_cachedEmptyChairs.Add(FurnComp);
				CountChair(FurnComp);
			}
			for (int i = 0; i < FurnComp.SnapPoints.Length; i++)
			{
				SnapPoint snapPoint = FurnComp.SnapPoints[i];
				if (snapPoint.MainUsedBy != null && snapPoint.MainUsedBy.Type.Equals("Chair"))
				{
					_cachedChairs.Add(snapPoint.MainUsedBy);
					if (snapPoint.Links.Count == 0 || snapPoint.Links.All((SnapPoint z) => z.MainUsedBy == null || !z.MainUsedBy.DisableTableGrouping))
					{
						_cachedEmptyChairs.Add(snapPoint.MainUsedBy);
						CountChair(snapPoint.MainUsedBy);
					}
				}
			}
			foreach (TableScript child in Children)
			{
				if (child == null)
				{
					FurnComp.Parent.RecalculateTableGroups();
					continue;
				}
				child._cachedChairs = null;
				child._cachedEmptyChairs = null;
				if (child.FurnComp.Type.Equals("Chair"))
				{
					_cachedChairs.Add(child.FurnComp);
					_cachedEmptyChairs.Add(child.FurnComp);
					CountChair(child.FurnComp);
				}
				for (int num = 0; num < child.FurnComp.SnapPoints.Length; num++)
				{
					SnapPoint snapPoint2 = child.FurnComp.SnapPoints[num];
					if (snapPoint2.MainUsedBy != null && snapPoint2.MainUsedBy.Type.Equals("Chair"))
					{
						_cachedChairs.Add(snapPoint2.MainUsedBy);
						if (snapPoint2.Links.Count == 0 || snapPoint2.Links.All((SnapPoint z) => z.MainUsedBy == null || !z.MainUsedBy.DisableTableGrouping))
						{
							_cachedEmptyChairs.Add(snapPoint2.MainUsedBy);
							CountChair(snapPoint2.MainUsedBy);
						}
					}
				}
			}
			if (_tableReserved > -1 && FreeChairs > 0 && UsedChairs == 0 && UsedChairs == 0)
			{
				_tableReserved = -1;
			}
			_dirtyStatus = false;
		}
	}

	private void CountChair(Furniture chair)
	{
		int num = 0;
		for (int i = 0; i < chair.InteractionPoints.Length; i++)
		{
			if (chair.InteractionPoints[i].Action == InteractionPoint.ActionType.Use)
			{
				num++;
				if (chair.InteractionPoints[i].UsedBy != null)
				{
					UsedChairs++;
				}
			}
		}
		FreeChairs += num;
		if (chair.SnappedTo == null || chair.SnappedTo.Links.All((SnapPoint z) => !z.HasMain))
		{
			FreeEmptyChairs += num;
		}
	}

	public IEnumerable<TableScript> GetChildren()
	{
		if (Parent == null || Parent == this)
		{
			yield return this;
			foreach (TableScript child in Children)
			{
				yield return child;
			}
			yield break;
		}
		yield return Parent;
		foreach (TableScript child2 in Parent.Children)
		{
			yield return child2;
		}
	}

	public int CountFreeChairs(bool empty, bool used)
	{
		return Mathf.Max(0, (empty ? FreeEmptyChairs : FreeChairs) - ((!used) ? UsedChairs : 0));
	}

	private void CheckIfInitialized()
	{
		if (_cachedChairs == null)
		{
			UpdateStatus(true);
		}
	}

	public Furniture GetFreeChair(Actor act, bool empty = false)
	{
		TableScript tableScript = ((Parent == null) ? this : Parent);
		tableScript.CheckIfInitialized();
		List<Furniture> list = (empty ? tableScript._cachedEmptyChairs : tableScript._cachedChairs);
		Furniture result = null;
		bool flag = false;
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			if ((!flag || furniture.OwnedBy == act) && furniture.CanUse(act, InteractionPoint.ActionType.Use))
			{
				if (furniture.OwnedBy == act)
				{
					return furniture;
				}
				result = furniture;
				flag = true;
			}
		}
		return result;
	}

	public List<Furniture> GetFreeChairs()
	{
		TableScript obj = ((Parent == null) ? this : Parent);
		obj.CheckIfInitialized();
		return obj._cachedEmptyChairs;
	}

	public void ReserveTables(bool reserve, bool open = false)
	{
		if (reserve)
		{
			TableReserved = ((!open) ? 1 : 0);
		}
		else
		{
			TableReserved = -1;
		}
	}

	public Holdable GetHoldable(SnapPoint point)
	{
		return Items.WhereSelect((KeyValuePair<SnapPoint, Holdable> x) => x.Key == point, (KeyValuePair<SnapPoint, Holdable> x) => x.Value).FirstOrDefault();
	}

	public bool PlaceHoldable(Holdable item, SnapPoint snapPoint)
	{
		if (Items.Any((KeyValuePair<SnapPoint, Holdable> x) => x.Key == snapPoint))
		{
			return false;
		}
		Items.Add(new KeyValuePair<SnapPoint, Holdable>(snapPoint, item));
		item.transform.parent = base.transform;
		if (snapPoint.HasMain && snapPoint.MainUsedBy != null)
		{
			Quaternion rotation = snapPoint.MainUsedBy.transform.rotation;
			item.transform.SetPositionAndRotation(snapPoint.transform.position + rotation * new Vector3(-0.4f, 0f, 0.4f), rotation);
		}
		else
		{
			item.transform.SetPositionAndRotation(snapPoint.transform.position, Quaternion.identity);
		}
		item.Parent = this;
		return true;
	}

	public void PlaceHoldable(Holdable item, Transform seating)
	{
		Items.Add(new KeyValuePair<SnapPoint, Holdable>(null, item));
		item.transform.parent = base.transform;
		item.transform.SetPositionAndRotation(seating.transform.position + Vector3.up * TableHeight + seating.transform.forward * 0.3f, Quaternion.identity);
		item.Parent = this;
	}

	public List<Furniture> GetChairs(bool onlyEmpty)
	{
		if (Parent != null && Parent != this)
		{
			return GetChairs(onlyEmpty);
		}
		if (FurnComp.Type.Equals("Chair"))
		{
			_singleFun.Clear();
			_singleFun.Add(FurnComp);
			return _singleFun;
		}
		CheckIfInitialized();
		if (!onlyEmpty)
		{
			return _cachedChairs;
		}
		return _cachedEmptyChairs;
	}

	private void FixedUpdate()
	{
		if (FurnComp.isTemporary || GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		bool flag = !FurnComp.Parent.IsReferenceNull() && FurnComp.Parent.Floor == CameraScript.Instance.GetCameraFloor();
		for (int i = 0; i < Items.Count; i++)
		{
			KeyValuePair<SnapPoint, Holdable> keyValuePair = Items[i];
			if (keyValuePair.Value == null || keyValuePair.Value.gameObject == null)
			{
				Items.RemoveAt(i);
				i--;
				continue;
			}
			Renderer[] renderers = keyValuePair.Value.Renderers;
			if (renderers.Length != 0 && renderers[0].enabled != flag)
			{
				for (int j = 0; j < renderers.Length; j++)
				{
					renderers[j].enabled = flag;
				}
			}
		}
	}

	public bool IsOnlyUser(Actor act)
	{
		if (Parent != null && Parent != this)
		{
			return Parent.IsOnlyUser(act);
		}
		if (UsedChairs > 1)
		{
			return false;
		}
		CheckIfInitialized();
		for (int i = 0; i < _cachedChairs.Count; i++)
		{
			Furniture furniture = _cachedChairs[i];
			for (int j = 0; j < furniture.InteractionPoints.Length; j++)
			{
				InteractionPoint interactionPoint = furniture.InteractionPoints[j];
				if (interactionPoint.Action == InteractionPoint.ActionType.Use && interactionPoint.UsedBy != null && interactionPoint.UsedBy != act)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void DecoupleHoldable(Holdable item)
	{
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i].Value == item)
			{
				Items.RemoveAt(i);
				i--;
			}
		}
	}

	private void OnDestroy()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		Furniture component = GetComponent<Furniture>();
		if (component.isTemporary)
		{
			return;
		}
		if (component.Parent != null)
		{
			component.Parent.RemoveFurniture(component);
			component.Parent.RemoveTable(this);
		}
		for (int num = Items.Count - 1; num >= 0; num--)
		{
			if (num < Items.Count)
			{
				Items[num].Value.DestroyMe();
			}
		}
	}

	public void Init()
	{
		FurnComp.Parent.AddTable(new Vector2(FurnComp.transform.position.x, FurnComp.transform.position.z), this);
	}

	public void SerializeState(WriteDictionary dict)
	{
		dict["TableChildren"] = (from x in Children
			where x != null
			select x.FurnComp.DID).ToArray();
		dict["TableReserveStatus"] = _tableReserved;
		dict["TableParent"] = ((Parent == null) ? FurnComp.DID : Parent.FurnComp.DID);
		dict["TableGroupColor"] = (SVector3)color;
	}

	public void DeserializeState(WriteDictionary dict)
	{
		_hasDeserialized = true;
		_serializedTableGroup = dict.Get<uint[]>("TableChildren", null);
		_serializedParent = dict.Get("TableParent", 0u);
		color = dict.Get("TableGroupColor", new SVector3(1f, 1f, 1f, 1f));
		_tableReserved = dict.Get("TableReserveStatus", -1);
	}

	private void OnDrawGizmos()
	{
		float radius = 0.1f;
		if (Parent == null || Parent == this)
		{
			radius = 0.2f;
			switch (_tableReserved)
			{
			case -1:
				Gizmos.color = color;
				break;
			case 0:
				Gizmos.color = Color.white;
				break;
			case 1:
				Gizmos.color = Color.black;
				break;
			}
		}
		else
		{
			switch (Parent._tableReserved)
			{
			case -1:
				Gizmos.color = Parent.color;
				break;
			case 0:
				Gizmos.color = Color.white;
				break;
			case 1:
				Gizmos.color = Color.black;
				break;
			}
		}
		Gizmos.DrawSphere(base.transform.position + Vector3.up * 1.5f, radius);
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube(base.transform.position + Vector3.up * TableHeight, new Vector3(1f, 0f, 1f));
	}
}
