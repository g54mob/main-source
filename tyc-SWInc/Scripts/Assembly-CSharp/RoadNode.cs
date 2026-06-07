using System;
using System.Collections.Generic;
using UnityEngine;

public class RoadNode : Selectable
{
	public enum ParkingAssign
	{
		Anyone = 0,
		Employees = 1,
		Staff = 2,
		Guests = 3,
		Deliveries = 4,
		Cooks = 5
	}

	public static string[] ParkingAssignStrings = new string[6] { "Anyone", "Employees", "Staff", "Guests", "Deliveries", "Cooks" };

	public bool Parking;

	public bool Taken;

	public bool Left;

	public bool IsInput;

	public bool IsOutput;

	public bool Unreachable;

	public bool Bike;

	public float Weight = 1f;

	public int ID;

	public PathNode<Vector3> self;

	private bool init;

	public RoadNode[] Connected;

	[NonSerialized]
	public Vector2[] NavMesh;

	public ParkingAssign Assign;

	public RoadSegment Parent;

	public CarScript GhostCar;

	private static HashSet<PathNode<Vector3>> _visited = new HashSet<PathNode<Vector3>>();

	public PathNode<Vector3> PathTo(RoadSegment goal, PathNode<Vector3> from, List<Vector3> path)
	{
		_visited.Clear();
		return SubPathTo(goal, from, path, Parent, path.Count, true);
	}

	private PathNode<Vector3> SubPathTo(RoadSegment goal, PathNode<Vector3> from, List<Vector3> path, RoadSegment start, int insert, bool first)
	{
		if (_visited.Add(from))
		{
			RoadNode roadNode = from.Tag as RoadNode;
			if (roadNode == null || roadNode.Parent == start)
			{
				List<PathNode<Vector3>> connections = from.GetConnections();
				for (int i = 0; i < connections.Count; i++)
				{
					PathNode<Vector3> pathNode = SubPathTo(goal, connections[i], path, start, insert, false);
					if (pathNode != null)
					{
						if (!first)
						{
							path.Insert(insert, from.Point);
						}
						return pathNode;
					}
				}
			}
			else if (roadNode.Parent == goal)
			{
				path.Insert(insert, from.Point);
				return from;
			}
		}
		return null;
	}

	public void Init(bool left)
	{
		Left = left;
		if (init)
		{
			return;
		}
		init = true;
		self = new PathNode<Vector3>(new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z), this);
		self.Weight = Weight;
		for (int i = 0; i < Connected.Length; i++)
		{
			RoadNode roadNode = Connected[i];
			roadNode.Init(left);
			self.AddConnection(roadNode.self);
		}
		if (Parking)
		{
			if (Parent.floor == 0)
			{
				float num = Mathf.Abs(Mathf.Cos(base.transform.rotation.eulerAngles.y * ((float)Math.PI / 180f)));
				Vector2 vector = new Vector2(2f * num + 0.9f * (1f - num), 0.9f * num + 2f * (1f - num));
				NavMesh = new Vector2[4]
				{
					new Vector2(base.transform.position.x - vector.x, base.transform.position.z - vector.y),
					new Vector2(base.transform.position.x + vector.x, base.transform.position.z - vector.y),
					new Vector2(base.transform.position.x + vector.x, base.transform.position.z + vector.y),
					new Vector2(base.transform.position.x - vector.x, base.transform.position.z + vector.y)
				};
			}
			RoadManager.Instance.RegisterParking(this);
		}
	}

	public Vector2 GetPos()
	{
		RoadSegment component = base.transform.parent.GetComponent<RoadSegment>();
		if (component != null)
		{
			return new Vector2(component.x, component.y);
		}
		return new Vector2(0f, 0f);
	}

	private void OnDestroy()
	{
		if (GameSettings.IsQuitting)
		{
			return;
		}
		if (HUD.Instance != null)
		{
			HUD.Instance.UnreachableParking.Remove(this);
		}
		if (RoadManager.Instance != null)
		{
			RoadManager.Instance.CheckUnreachable.Remove(this);
			if (Parking)
			{
				RoadManager.Instance.DeregisterParking(this);
			}
			if (GhostCar != null)
			{
				RoadManager.Instance.DestroyCar(GhostCar);
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (Parking && RoadManager.Instance != null)
		{
			Gizmos.color = Color.white;
			switch (RoadManager.Instance.PlayerParking(this))
			{
			case RoadManager.ParkingState.Public:
				Gizmos.color = Color.green;
				break;
			case RoadManager.ParkingState.Player:
				Gizmos.color = Color.yellow;
				break;
			case RoadManager.ParkingState.Closed:
				Gizmos.color = Color.red;
				break;
			}
			Gizmos.DrawSphere(base.transform.position + Vector3.up * 0.5f, 0.1f);
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (self != null)
		{
			Gizmos.color = (Left ? Color.blue : Color.green);
			foreach (PathNode<Vector3> connection in self.GetConnections())
			{
				try
				{
					Gizmos.DrawLine(base.transform.position, ((RoadNode)connection.Tag).transform.position);
				}
				catch (Exception)
				{
					Gizmos.DrawSphere(base.transform.position, 1f);
				}
			}
		}
		else
		{
			Gizmos.color = Color.red;
			RoadNode[] connected = Connected;
			foreach (RoadNode roadNode in connected)
			{
				try
				{
					Gizmos.DrawLine(base.transform.position, roadNode.transform.position);
				}
				catch (Exception)
				{
					Gizmos.DrawSphere(base.transform.position, 1f);
				}
			}
		}
		Gizmos.color = ((!Parking) ? Color.white : (Taken ? Color.red : Color.green));
		Gizmos.DrawSphere(base.transform.position, Parking ? 0.3f : 0.1f);
		Gizmos.color = Color.white;
	}

	public int GetRoadFloor()
	{
		return Parent.floor;
	}

	public override int GetFloor()
	{
		return Parent.floor * 2;
	}

	public override Vector2 GetFlatPos()
	{
		return base.transform.position.FlattenVector3();
	}

	public override string[] GetActions()
	{
		return new string[3] { "AssignParking", "SelectNearParking", "SelectParkedPeople" };
	}

	public override bool IsSelectionRestricted()
	{
		if (!Bike && Parking && !GameSettings.Instance.RentMode)
		{
			return RoadManager.Instance.PlayerParking(this) != RoadManager.ParkingState.Player;
		}
		return true;
	}

	public override bool IsSelectableInView()
	{
		return !Bike;
	}

	public override bool SingleMat()
	{
		return true;
	}

	public override string[] GetExtendedIconInfo()
	{
		return new string[1] { "Parking" };
	}

	public override string[] GetExtendedInfo()
	{
		return new string[1] { Assign.ToString().Loc() };
	}

	public override string GetInfo()
	{
		return (Taken ? "Taken" : "Free").Loc();
	}

	public override bool CanRectSelect()
	{
		return !Bike;
	}
}
