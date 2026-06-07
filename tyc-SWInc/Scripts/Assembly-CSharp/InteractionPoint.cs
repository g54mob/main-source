using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
	public class ActionSorter : IComparer<InteractionPoint>
	{
		public int Compare(InteractionPoint x, InteractionPoint y)
		{
			int action = (int)x.Action;
			return action.CompareTo((int)y.Action);
		}
	}

	public enum ActionType
	{
		Use = 0,
		Repair = 1,
		Social = 2,
		Serve = 3,
		Visit = 4,
		Test = 5
	}

	public ActionType Action;

	public bool MainAction = true;

	public bool ShowOnBuild = true;

	public bool AlwaysValid;

	public bool Outside;

	public bool TurnTo = true;

	private Actor _usedBy;

	public Furniture Parent;

	public InteractionPoint Child;

	public InteractionPoint DeferChild;

	public InteractionPoint ActiveDefer;

	public int Id;

	public bool NeedsReachCheck = true;

	public Actor.AnimationStates Animation;

	public int subAnimation;

	public float Range = -1f;

	private bool FreeNav;

	public int MinimumNeeded = 1;

	[NonSerialized]
	public List<Actor> CurrentQueue = new List<Actor>();

	public List<InteractionPoint> BlockedBy = new List<InteractionPoint>();

	[NonSerialized]
	public Vector3 pos;

	[NonSerialized]
	public Vector3 worldPos;

	[NonSerialized]
	public bool DirtyPos;

	[NonSerialized]
	public Matrix4x4 ActualPos;

	[NonSerialized]
	private bool _initialized;

	public Actor UsedBy
	{
		get
		{
			return _usedBy;
		}
		set
		{
			_usedBy = value;
			if (Parent.NeedsChair && Parent.ComputerChair != null)
			{
				Parent.ComputerChair.GetInteractionPoint(ActionType.Use, true).UsedBy = value;
			}
			if (Child != null && Child.UsedBy != UsedBy)
			{
				Child.UsedBy = UsedBy;
			}
			if (Parent.Table != null)
			{
				Parent.Table.UpdateUseStatus();
			}
			else if (Parent.SnappedTo != null && Parent.SnappedTo.Parent.Table != null)
			{
				Parent.SnappedTo.Parent.Table.UpdateUseStatus();
			}
		}
	}

	public bool IsBlocked
	{
		get
		{
			if (BlockedBy.Count > 0)
			{
				return BlockedBy.Any((InteractionPoint x) => x.UsedBy != null);
			}
			return false;
		}
	}

	public Vector2 Point
	{
		get
		{
			if (ActiveDefer == null)
			{
				Vector3 vector = (DirtyPos ? pos : base.transform.position);
				return new Vector2(vector.x, vector.z);
			}
			return ActiveDefer.Point;
		}
	}

	public float Rotation
	{
		get
		{
			if (!(ActiveDefer == null))
			{
				return ActiveDefer.Rotation;
			}
			return base.transform.rotation.eulerAngles.y;
		}
	}

	public int QueueLength
	{
		get
		{
			return CurrentQueue.Count;
		}
	}

	private void Awake()
	{
		InitializePosition();
	}

	public void InitializePosition()
	{
		if (!_initialized)
		{
			if (Parent != null)
			{
				ActualPos = Parent.transform.localToWorldMatrix.inverse * base.transform.localToWorldMatrix;
			}
			else
			{
				ActualPos = base.transform.localToWorldMatrix;
			}
			_initialized = true;
		}
	}

	public void UpdateFreeNav(bool threaded, bool allowMove)
	{
		allowMove |= Range > 0f;
		if (AlwaysValid)
		{
			FreeNav = true;
		}
		else if (Parent != null && Parent.InteractionParent != null)
		{
			if (Outside || Parent.IsReversed)
			{
				int floor = Parent.GetFloor();
				if (floor >= 0)
				{
					if (floor == 0)
					{
						FreeNav = GameSettings.Instance.sRoomManager.Outside.GetNodeAt((threaded ? pos : base.transform.position).FlattenVector3(), !threaded) != null;
					}
					else if (floor % 2 == 0)
					{
						int num = floor / 2;
						if (num < RoadManager.Floors)
						{
							Vector2 v = (threaded ? pos : base.transform.position).FlattenVector3();
							FreeNav = RoadManager.Instance.GetSegment(v, num, false) != null;
						}
					}
				}
				else
				{
					FreeNav = false;
				}
				return;
			}
			if (Parent.Parent != Parent.InteractionParent && Parent.Parent.FindFloorAtrium((threaded ? worldPos : base.transform.position).FlattenVector3()) != Parent.InteractionParent)
			{
				FreeNav = false;
				return;
			}
			Vector2 vector = (threaded ? (allowMove ? pos : worldPos).FlattenVector3() : (allowMove ? GetActualPos() : base.transform.position).FlattenVector3());
			if (allowMove)
			{
				float num2 = ((Range > 0f) ? Mathf.Max(Range * Range, 0.073f) : 0.073f);
				Vector2? vector2;
				FreeNav = Parent.InteractionParent.GetNavOrClosest(vector, out vector2, num2 * 0.5f, !threaded);
				if (FreeNav)
				{
					if (threaded)
					{
						pos = vector.ToVector3(worldPos.y);
						DirtyPos = true;
					}
					else
					{
						Vector3 vector3 = (base.transform.position = vector.ToVector3(base.transform.position.y));
						pos = vector3;
					}
				}
				else if (vector2.HasValue && (vector - vector2.Value).sqrMagnitude < num2)
				{
					FreeNav = true;
					if (threaded)
					{
						pos = vector2.Value.ToVector3(worldPos.y);
						DirtyPos = true;
					}
					else
					{
						Vector3 vector3 = (base.transform.position = vector2.Value.ToVector3(base.transform.position.y));
						pos = vector3;
					}
				}
			}
			else
			{
				FreeNav = Parent.InteractionParent.GetNodeAt(vector, !threaded) != null;
			}
		}
		else
		{
			FreeNav = false;
		}
	}

	public Vector3 GetActualPos()
	{
		return (Parent.transform.localToWorldMatrix * ActualPos).MultiplyPoint(Vector3.zero);
	}

	public void UpdateDefer()
	{
		InteractionPoint defer = Parent.GetDefer(Action);
		if (defer != null)
		{
			ActiveDefer = defer;
			return;
		}
		ActiveDefer = null;
		if (!FreeNav && !DeferChild.IsReferenceNull())
		{
			InteractionPoint deferChild = DeferChild;
			while (deferChild != null && deferChild != this && !deferChild.FreeNav)
			{
				deferChild = deferChild.DeferChild;
			}
			ActiveDefer = ((deferChild != this) ? deferChild : null);
		}
	}

	public bool Usable()
	{
		if (Parent == null || Parent.Parent == null)
		{
			return false;
		}
		if (!Parent.isTemporary && !FreeNav)
		{
			if (ActiveDefer != null)
			{
				return ActiveDefer.FreeNav;
			}
			return false;
		}
		return true;
	}

	private void OnDrawGizmos()
	{
		if (GameSettings.Instance.IsReferenceNull() || Parent.Parent == null || Parent.Parent.Floor == GameSettings.Instance.ActiveFloor)
		{
			Gizmos.color = ((Parent == null) ? Color.white : (Usable() ? Color.green : Color.red));
			if (ActiveDefer != null)
			{
				Gizmos.color = Color.cyan;
			}
			Gizmos.DrawSphere(Point.ToVector3(base.transform.position.y), 0.05f);
			Gizmos.color = Color.white;
			if (Child != null)
			{
				Gizmos.DrawLine(base.transform.position, Child.transform.position);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < BlockedBy.Count; i++)
		{
			Gizmos.DrawLine(base.transform.position, BlockedBy[i].transform.position);
		}
	}

	public bool CanQueue(Actor act, ActionType action)
	{
		if (CurrentQueue.Count < Parent.MaxQueue)
		{
			if (act.IsEmployee())
			{
				if (!Parent.Parent.CompatibleWithTeam(act.GetTeam()))
				{
					return false;
				}
				if (Parent.Parent.ForceRole >= 0 && (Employee.RoleToMask[Parent.Parent.ForceRole] & act.GetRole()) == 0)
				{
					return false;
				}
				if (action == ActionType.Use && ((Parent.Reserved != null && Parent.Reserved != act) || (Parent.OwnedBy != null && Parent.OwnedBy != act)))
				{
					return false;
				}
				if (Parent.HasUpg && Parent.upg.Broken)
				{
					return false;
				}
			}
			if (act.AItype != AI.AIType.Cook && !act.IsEmployee())
			{
				return false;
			}
			if (Parent.Type.Equals("Tray"))
			{
				if (action == ActionType.Serve)
				{
					if (!Parent.CanPlaceHoldable())
					{
						return false;
					}
				}
				else if (Parent.HasHoldables == 0)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public void RemoveFromQueue(Actor act)
	{
		for (int i = 0; i < CurrentQueue.Count; i++)
		{
			if (CurrentQueue[i] == act)
			{
				CurrentQueue.RemoveAt(i);
				break;
			}
		}
	}

	public bool IsInQueue(Actor act)
	{
		for (int i = 0; i < CurrentQueue.Count; i++)
		{
			if (CurrentQueue[i] == act)
			{
				return true;
			}
		}
		return false;
	}

	public void ClearQueue()
	{
		CurrentQueue.ForEach(delegate(Actor x)
		{
			x.InQueue.Remove(Parent.Type);
		});
		CurrentQueue.Clear();
	}

	public bool IsUp(Actor act)
	{
		return CurrentQueue[0] == act;
	}

	public void AddToQueue(Actor act)
	{
		if (!IsInQueue(act))
		{
			CurrentQueue.Add(act);
		}
	}

	public override string ToString()
	{
		if (Parent != null)
		{
			return Parent.name + " - " + Action;
		}
		return "InteractionPoint - " + Action;
	}
}
