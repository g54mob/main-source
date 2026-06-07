using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
	public string Name;

	public int Id;

	public bool CheckValid = true;

	public bool UseForOrientation = true;

	public SnapPoint[] InitLinks;

	public Vector2[] Surface;

	[NonSerialized]
	private Vector2[] _finalizedSurface;

	[NonSerialized]
	private Vector3 _lastPos;

	[NonSerialized]
	private Vector3 _lastRot;

	[NonSerialized]
	public HashSet<SnapPoint> Links = new HashSet<SnapPoint>();

	private Furniture _usedBy;

	[NonSerialized]
	private HashSet<Furniture> _usedBys = new HashSet<Furniture>();

	public Furniture Parent;

	public bool IsValid = true;

	public bool HasMain;

	public SnapPoint[] Blocking;

	[NonSerialized]
	public Vector3 pos;

	public bool HasSurface
	{
		get
		{
			if (Surface != null)
			{
				return Surface.Length > 2;
			}
			return false;
		}
	}

	public Furniture MainUsedBy
	{
		get
		{
			return _usedBy;
		}
	}

	public int UsedByCount
	{
		get
		{
			return _usedBys.Count;
		}
	}

	public bool IsMainSnap(Furniture f)
	{
		if (f.CanSnapSurface)
		{
			return !HasSurface;
		}
		return true;
	}

	public Vector3 FixPosition(Furniture f)
	{
		return FixPosition(f.SnapPointOffset);
	}

	public Vector3 FixPosition(Vector3 spo)
	{
		return GetRealPos() + base.transform.rotation * spo;
	}

	public Vector2[] GetFinalizedSurface(bool forceUpdate = false)
	{
		if (forceUpdate || base.transform.position != _lastPos || base.transform.rotation.eulerAngles != _lastRot)
		{
			_lastPos = base.transform.position;
			_lastRot = base.transform.rotation.eulerAngles;
			if (_finalizedSurface == null || _finalizedSurface.Length != Surface.Length)
			{
				_finalizedSurface = new Vector2[Surface.Length];
			}
			for (int i = 0; i < Surface.Length; i++)
			{
				_finalizedSurface[i] = base.transform.localToWorldMatrix.MultiplyPoint(Surface[i].ToVector3(0f)).FlattenVector3();
			}
		}
		return _finalizedSurface;
	}

	public void SetUsedBy(Furniture f, bool attach = true)
	{
		if (attach)
		{
			if (!_usedBys.Add(f))
			{
				return;
			}
			Furniture usedBy = _usedBy;
			int num;
			if (usedBy != null)
			{
				num = (IsMainSnap(usedBy) ? 1 : 0);
				if (num != 0)
				{
					_usedBys.Remove(usedBy);
				}
			}
			else
			{
				num = 0;
			}
			UpdateUsedBy();
			if (num != 0)
			{
				Parent.NotifySnapPoint(this, usedBy, false);
			}
			Parent.NotifySnapPoint(this, f, true);
		}
		else if (_usedBys.Remove(f))
		{
			UpdateUsedBy();
			Parent.NotifySnapPoint(this, f, false);
		}
	}

	public void ClearUsedBy()
	{
		foreach (Furniture usedBy in _usedBys)
		{
			Parent.NotifySnapPoint(this, usedBy, false);
		}
		_usedBys.Clear();
		UpdateUsedBy();
	}

	public void ForEachUsed(Action<Furniture> action)
	{
		if (UsedByCount > 0)
		{
			if (UsedByCount == 1)
			{
				action(_usedBy);
			}
			else
			{
				_usedBys.ForEachEnum(action);
			}
		}
	}

	public Furniture FindFirst(Func<Furniture, bool> query)
	{
		if (UsedByCount > 0)
		{
			if (UsedByCount != 1)
			{
				return _usedBys.FirstOrDefault(query);
			}
			if (query(_usedBy))
			{
				return _usedBy;
			}
		}
		return null;
	}

	public bool AnyUsed(Func<Furniture, bool> query)
	{
		if (UsedByCount > 0)
		{
			if (UsedByCount != 1)
			{
				return _usedBys.Any(query);
			}
			return query(_usedBy);
		}
		return false;
	}

	private void UpdateUsedBy()
	{
		HasMain = false;
		bool flag = false;
		Furniture usedBy = null;
		foreach (Furniture usedBy2 in _usedBys)
		{
			if (IsMainSnap(usedBy2))
			{
				HasMain = true;
				usedBy = usedBy2;
				break;
			}
			if (!flag)
			{
				usedBy = usedBy2;
				flag = true;
			}
		}
		_usedBy = usedBy;
	}

	public IEnumerable<Furniture> GetAllUsedBy()
	{
		foreach (Furniture usedBy in _usedBys)
		{
			yield return usedBy;
		}
	}

	public bool IsUsedBy(Furniture f)
	{
		return _usedBys.Contains(f);
	}

	public bool IsFree(bool main)
	{
		if (HasMain)
		{
			return false;
		}
		if (Blocking != null)
		{
			for (int i = 0; i < Blocking.Length; i++)
			{
				if (Blocking[i].HasMain)
				{
					return false;
				}
			}
		}
		if (main)
		{
			return UsedByCount == 0;
		}
		return true;
	}

	public bool IsFree(Furniture reference)
	{
		if (HasMain)
		{
			return _usedBy == reference;
		}
		if (Blocking != null)
		{
			for (int i = 0; i < Blocking.Length; i++)
			{
				SnapPoint snapPoint = Blocking[i];
				if (snapPoint.HasMain)
				{
					return snapPoint._usedBy == reference;
				}
			}
		}
		if (!reference.CanSnapSurface)
		{
			return UsedByCount == 0;
		}
		return true;
	}

	public Vector3 KeepWithinSurface(Vector3 input, float radius)
	{
		Vector2 vector = input.FlattenVector3();
		Vector2[] finalizedSurface = GetFinalizedSurface();
		if (!Utilities.IsInside(vector, finalizedSurface, radius))
		{
			Vector2 v = vector;
			float num = float.MaxValue;
			for (int i = 0; i < finalizedSurface.Length; i++)
			{
				Vector2 offset = Utilities.GetOffset(i, finalizedSurface, radius, true);
				Vector2 offset2 = Utilities.GetOffset((i + 1) % finalizedSurface.Length, finalizedSurface, radius, true);
				Vector2 res;
				if (Utilities.ProjectToLine(vector, offset, offset2, out res))
				{
					float sqrMagnitude = (vector - res).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						v = res;
					}
				}
				else
				{
					float sqrMagnitude2 = (vector - offset).sqrMagnitude;
					if (sqrMagnitude2 < num)
					{
						num = sqrMagnitude2;
						v = offset;
					}
				}
			}
			return v.ToVector3(input.y);
		}
		return vector.ToVector3(input.y);
	}

	public bool IsWithinSurface(Vector3 input, float radius)
	{
		return Utilities.IsInside(input.FlattenVector3(), GetFinalizedSurface(), radius);
	}

	public bool CheckCollisions(Vector2 p, float radius, Furniture reference, FurnitureBuilder context)
	{
		if (HasSurface && !HasMain && radius > 0f)
		{
			if (context != null)
			{
				context.SetError(null);
			}
			foreach (Furniture usedBy in _usedBys)
			{
				if (usedBy.SurfaceSnapRadius > 0f && usedBy != reference && (usedBy.transform.position.FlattenVector3() - p).magnitude < usedBy.SurfaceSnapRadius + radius)
				{
					if (context != null)
					{
						ErrorOverlay.Instance.ShowError("FurnitureOccupied");
						context.SetError(usedBy);
					}
					return false;
				}
			}
			return true;
		}
		if (HasMain)
		{
			return MainUsedBy == reference;
		}
		return true;
	}

	public bool SuspendValidCheck(Furniture reference)
	{
		if (!HasMain && HasSurface)
		{
			return reference.CanSnapSurface;
		}
		return false;
	}

	public void Awake()
	{
		if (InitLinks != null)
		{
			for (int i = 0; i < InitLinks.Length; i++)
			{
				SnapPoint snapPoint = InitLinks[i];
				Links.Add(snapPoint);
				snapPoint.Links.Add(this);
			}
		}
	}

	public Vector3 GetRealPos()
	{
		return Matrix4x4.TRS(Parent.GetOriginalPositionWithOffset(), Parent.transform.rotation, Parent.transform.localScale).MultiplyPoint(GetLocalPosition());
	}

	public Vector3 GetLocalPosition()
	{
		Vector3 vector = base.transform.localPosition;
		Transform parent = base.transform.parent;
		Transform transform = Parent.transform;
		while (parent != transform && parent != null)
		{
			vector = Matrix4x4.TRS(parent.localPosition, parent.localRotation, parent.localScale).MultiplyPoint(vector);
			parent = parent.parent;
		}
		return vector;
	}

	public void UpdateValid(bool threaded)
	{
		if (Parent != null && Parent.Parent != null)
		{
			Vector3 vector = (threaded ? pos : GetRealPos());
			float floorOffset = vector.y.GetFloorOffset(Parent.Floor);
			IsValid = !CheckValid || FurnitureBuilder.IsValid(Parent, vector, new Vector2[1]
			{
				new Vector2(vector.x, vector.z)
			}, floorOffset - 0.001f, floorOffset + 0.001f, Parent.Parent, false, true, Parent);
		}
		else
		{
			IsValid = false;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		if (InitLinks == null || InitLinks.Length == 0)
		{
			bool flag = false;
			SnapPoint[] snapPoints = Parent.SnapPoints;
			foreach (SnapPoint snapPoint in snapPoints)
			{
				if (snapPoint != this && snapPoint.InitLinks != null && snapPoint.InitLinks.Contains(this))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Gizmos.DrawCube(base.transform.position, Vector3.one * 0.1f);
			}
		}
		Gizmos.color = Color.white;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		if (InitLinks != null && InitLinks.Length != 0)
		{
			for (int i = 0; i < InitLinks.Length; i++)
			{
				Gizmos.DrawLine(base.transform.position, InitLinks[i].transform.position);
			}
		}
		else
		{
			foreach (SnapPoint link in Links)
			{
				Gizmos.DrawLine(base.transform.position, link.transform.position);
			}
		}
		if (HasSurface)
		{
			Gizmos.color = Color.yellow;
			float y = base.transform.position.y;
			Vector2[] finalizedSurface = GetFinalizedSurface(true);
			for (int j = 0; j < finalizedSurface.Length; j++)
			{
				Vector2 v = finalizedSurface[j];
				Gizmos.DrawLine(to: finalizedSurface[(j + 1) % finalizedSurface.Length].ToVector3(y), from: v.ToVector3(y));
			}
		}
	}
}
